using EasyControlWeb;
using EasyControlWeb.Errors;
using EasyControlWeb.Form.Controls;
using SIMANET_W22R.ClasesExtendidas;
using SIMANET_W22R.Exceptiones;
using SIMANET_W22R.srvSeguridad;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.Remoting.Contexts;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using static EasyControlWeb.EasyUtilitario;
using static EasyControlWeb.EasyUtilitario.Helper;

namespace SIMANET_W22R
{
    public class PaginaBase : System.Web.UI.Page
    {
        #region Controles 
            EasyUsuario oUsuario = new EasyUsuario();
            EasyNavigatorHistorial oEasyNavigatorHistorial = new EasyNavigatorHistorial();
            EasyMessageBox oeasyMessageBox;

        #endregion
        #region  Constantes que se deberan de usuar en todos los modulos
            public static string KEYIDGENERAL = "idGen";
        

        public static string KEYMODOPAGINA= "Modo";
            public static string KEYQCENTROOPERATIVO = "IdCeo";
            public static string KEYQAÑO = "Anio";
            public static string KEYQIDMES = "IdMes";
            public static string KEYQFECHA = "Fecha";
            public static string KEYQIDPROCESO = "IdPrc";
            public static string KEYQIDESTADO = "IdEst";
            public static string KEYQDESCRIPCION = "Descrip";
            public static string KEYQAPELLIDOSNOMBRES = "ApellidosyNombres";

            public static string KEYQIDTABLAGENERAL = "IdTblGen";
            public static string KEYQIDITEMTABLAGENERAL = "IdItemTblGen";

            public static string KEYQRAZONSOCIALCLIENTE = "RazonSocialCliente";

            public static string KEYQQUIENLLAMA = "QLlama";
            public static string KEYQEDITABLE = "mEdit";



        #endregion

        #region Propiedades Publicas

        public int IdProceso { get { return Convert.ToInt32(Page.Request.Params[KEYQIDPROCESO]); } }
        public string IdCentroOperativo{
                get { return Page.Request.Params[KEYQCENTROOPERATIVO]; }
            }
            public string Año
            {
                get { return Page.Request.Params[KEYQAÑO]; }
            }
            public string IdMes
            {
                get { return Page.Request.Params[KEYQIDMES]; }
            }
            public string Fecha
            {
                get { return Page.Request.Params[KEYQFECHA]; }
            }
            public EasyUtilitario.Enumerados.ModoPagina ModoPagina {
                    get { return (EasyUtilitario.Enumerados.ModoPagina)System.Enum.Parse(typeof(EasyUtilitario.Enumerados.ModoPagina), Page.Request.Params[EasyUtilitario.Constantes.Pagina.KeyParams.Modo].ToString());  }
            }

            public int IdEstado { get { return Convert.ToInt32(Page.Request.Params[KEYQIDESTADO]); } }
            public string Descripcion
            {
                get { return Page.Request.Params[KEYQDESCRIPCION]; }
            }

            public string ApellidosyNombres
            {
                get { return Page.Request.Params[KEYQAPELLIDOSNOMBRES]; }
            }
            public string RazonSocialCliente
            {
                get { return Page.Request.Params[KEYQRAZONSOCIALCLIENTE]; }
            }
            public int ModoEditable { get { return Convert.ToInt32(Page.Request.Params[KEYQEDITABLE]); } }


        public string IdTablaGeneral { get { return Page.Request.Params[KEYQIDTABLAGENERAL]; } }
        
        #endregion
        #region Propiedades de entrega de datos
        public string UsuarioLogin{
                get {
                    try
                    {
                        Session["UserName"] = ((EasyUsuario)EasyUtilitario.Helper.Sessiones.Usuario.get()).Login;
                        return ((EasyUsuario)EasyUtilitario.Helper.Sessiones.Usuario.get()).Login;
                    }
                    catch (Exception ex) {
                        return "Udefault";
                    }
                }
            }
            public int UsuarioId { 
                get {
                        try
                        {
                            Session["IdUsuario"] = ((EasyUsuario)EasyUtilitario.Helper.Sessiones.Usuario.get()).IdUsuario;
                            return ((EasyUsuario)EasyUtilitario.Helper.Sessiones.Usuario.get()).IdUsuario;
                        }
                        catch (Exception ex) {
                            return 0;
                        }
                }
            }
        #endregion

        #region datos usuario Logueado
        public UsuarioBE DatosUsuario { 
            get {
                    return (UsuarioBE)Session["UserBE"];
                }
        }
        #endregion


        public PaginaBase() {
           // this.Load += new EventHandler(this.Page_Load);
        }

       protected override void OnLoad(EventArgs e)
       {
            
            if (!Page.IsPostBack)
            {
                oUsuario = EasyUtilitario.Helper.Sessiones.Usuario.get();
                try
                {
                    
                    if (!Page.IsPostBack)
                    {
                        oEasyNavigatorHistorial.getAllCtrlMemoryValue();
                    }
                    
                    this.ValidarPagina("");

                }
                catch (SIMAExceptionSeguridadAccesoForms ex)
                {

                    LanzarException(ex);
                }
                base.OnLoad(e);
            }
            this.ListarConstantesPagina();
        }
       


        public void IrA(EasyControlWeb.Form.Controls.EasyNavigatorBE oEasyNavigatorBE,params object[] LstCtrl) {
            if (LstCtrl.Length > 0)
            {
                oEasyNavigatorHistorial.SavePageCtrlStatus(LstCtrl);
            }
            oEasyNavigatorHistorial.IrA(oEasyNavigatorBE);
            
        }
        public void Atras()
        {
            oEasyNavigatorHistorial.Atras();
        }


        public string Param(string Nombre) {
            return Page.Request.Params[Nombre];
        }
      
       



        public void ValidarPagina(string Origen) {
            EasyUsuario oEasyUsuario = new EasyUsuario();
                if (oEasyUsuario.ValidaPagina()==false) {
                //throw new Exception("Ud. No cuenta con accesos a esta pagina");
                    throw new SIMAExceptionSeguridadAccesoForms("Ud. No cuenta con accesos a esta pagina");
            }
        }
        //public void LanzarException(Exception ex)
        public void LanzarException(SIMAExceptionSeguridadAccesoForms ex)
        {
            StackTrace stack = new StackTrace();
            string NombreMetodo = stack.GetFrame(0).GetMethod().Name;
            LanzarException(NombreMetodo, ex);
        }
        public void LanzarException(string Event, Exception ex)
        {
            EasyErrorControls oEasyErrorControls = new EasyErrorControls();
            string[] PagSplit = Page.Request.Url.AbsolutePath.Split('/');
            string Pagina = PagSplit[PagSplit.GetUpperBound(0)];
                string Autorizado = EasyUtilitario.Helper.Configuracion.Leer("FormsFree", Pagina);
                if ((Autorizado == null) || (Autorizado == "0"))
                {
                   
                    oEasyErrorControls.Origen = ex.TargetSite.Name;
                    string msg = ex.Message.Replace("'", "").Replace("'", "").Replace("\n", "");
                    oEasyErrorControls.Mensaje = msg;
                    oEasyErrorControls.Pagina = Pagina;
                    oEasyErrorControls.LanzarException(Event);
                }
        }
        public string GetPageName() {
            //string[] PagSplit = Page.Request.Url.AbsolutePath.Split('/');
            string[] PagSplit = HttpContext.Current.Request.Url.AbsolutePath.Split('/');
            string Pagina = PagSplit[PagSplit.GetUpperBound(0)].Replace(".aspx", "");
            return Pagina;
        }

       
        public void ErrorDisplay(SIMAExceptionSeguridadAccesoForms ex) {
            string cmll = EasyUtilitario.Constantes.Caracteres.ComillaDoble;
            oeasyMessageBox = new EasyMessageBox();
            oeasyMessageBox.ID = "Msg";
            oeasyMessageBox.Titulo = "Error";
            string msg = ex.Message.Replace("'", "").Replace("'", "").Replace("\n","");
            oeasyMessageBox.Contenido = msg;
            oeasyMessageBox.Tipo = EasyUtilitario.Enumerados.MessageBox.Tipo.AlertType;
            oeasyMessageBox.AlertStyle = EasyUtilitario.Enumerados.MessageBox.AlertStyle.modern;
            Page.Controls.Add(oeasyMessageBox);
        }

        public void ListarConstantesPagina()
        {
            string Pagina = GetPageName();
            string cmll = EasyUtilitario.Constantes.Caracteres.ComillaDoble;
            string ScriptConatantes = "";

        //ws://localhost:4649/Chat?name=erosales&Plataforma=WebID&FormId=
            /************************************************************************************************************************************/
            string DatosUsuario = "IdUsuario=" + oUsuario.IdUsuario.ToString() + "&" + "UserName=" + oUsuario.Login;
            string strParam = ((Page.ClientQueryString.Length > 0) ? Page.ClientQueryString + "&" + DatosUsuario : DatosUsuario);

            string FormCreate = @"var " + Pagina + @"={};
                                      " + Pagina + @".Name='" + Pagina + @"';
                                      " + Pagina + @".Params =  FormParams('" + strParam + @"');
                                      var GlobalEntorno={};
                                          GlobalEntorno =  " + Pagina + @";
                                          GlobalEntorno.PageName =  '" + Pagina + @"';
                                          GlobalEntorno.UserName =  '" + oUsuario.Login + @"';
                                          GlobalEntorno.PathFotosPersonal= " + cmll + EasyUtilitario.Helper.Configuracion.PathFotos + cmll + @"
                                      " + Pagina + @".PathFotosPersonal = GlobalEntorno.PathFotosPersonal;
            ";
            Page.RegisterClientScriptBlock("ParamPag", "<script>\n" + FormCreate + "\n" + "</script>");

            /*Registrar Ref path webservice-------------------------------------------------------------------------------------------------------*/
            string PathWSCore = EasyUtilitario.Helper.Configuracion.Leer("ConfigBase", "PathBaseWSCore");
            string WebServiceCliente = @"var ConnectedService={};
                                          ConnectedService.PathNetCore='" + PathWSCore + @"'
                                          ConnectedService.ControlInspeccionesSoapClient='" + PathWSCore +  @"GestionCalidad/ControlInspecciones.asmx';
                                          ConnectedService.GeneralSoapClient='" + PathWSCore + @"General/General.asmx';
                                    ";
            Page.RegisterClientScriptBlock("WebService", "<script>\n" + WebServiceCliente + "\n" + "</script>");
            /*-------------------------------------------------------------------------------------------------------------------------------------*/
           

            string LogCliente =  Pagina + @".Trace= {};
                             " + Pagina + @".Trace.Log  = {};
                             " + Pagina + @".Trace.Log.Find = function (_Key,NodoId) {
                                                                                var NodoEncontrado = null;
                                                                                var NodoCollection = new Array();
                                                                                var DataLog = localStorage.getItem(UsuarioBE.UserName +_Key)
                                                                                var ArrLog = new Array();
                                                                                var Encontrado = false;

                                                                                if (DataLog!=null) {
                                                                                    ArrLog = DataLog.split('@');
                                                                                    ArrLog.forEach(function (item, p) {
                                                                                        var NodoBE = item.toString().SerializedToObject();
                                                                                        if (NodoBE.id.toString().Equal(NodoId)) {
                                                                                            Encontrado = true;
                                                                                            NodoEncontrado = NodoBE;
                                                                                        }
                                                                                        else {
                                                                                            NodoCollection.Add(NodoBE);
                                                                                        }
                                                                                    });
                                                                                    return { NodoBE: NodoEncontrado, DBLog: NodoCollection };
                                                                                }
                                                                                return { NodoBE: null, DBLog: NodoCollection };
                                                                            }
                                        " + Pagina + @".Trace.Log.Save = function (_Key,LogBECollections) {
                                                                                var strLog = '';
                                                                                LogBECollections.DBLog.forEach(function (item, i) {
                                                                                    strLog += ((i == 0) ? '' : '@') + item.Serialized(item,false);
                                                                                });
                                                                                localStorage.setItem(UsuarioBE.UserName + _Key, strLog);
            
                                                                                }
                                        " + Pagina + @".Trace.Log.Clear = function (_Key) {
                                                                                    localStorage.removeItem(UsuarioBE.UserName + _Key);
                                                                                }

                                        ";
            Page.RegisterClientScriptBlock("LogLocal", "<script>\n" + LogCliente + "\n" + "</script>");
            /*-------------------------------------------------------------------------------------------------------------------------------------*/

            /* List<FieldInfo> fl = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                                 .Where(fi => fi.IsLiteral && !fi.IsInitOnly && fi.IsSecurityTransparent == false).ToList();*/

            List<FieldInfo> fl = this.GetType().GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
                                                        .Where(fi =>fi.IsSecurityTransparent == false).ToList();
            foreach (FieldInfo fi in fl)
            {
                //ScriptConatantes += Pagina + EasyUtilitario.Constantes.Caracteres.Punto + fi.Name + EasyUtilitario.Constantes.Caracteres.SignoIgual + cmll + fi.GetRawConstantValue().ToString().Trim() + cmll + EasyUtilitario.Constantes.Caracteres.PuntoyComa + "\n";
                ScriptConatantes += Pagina + EasyUtilitario.Constantes.Caracteres.Punto + fi.Name + EasyUtilitario.Constantes.Caracteres.SignoIgual + cmll + fi.GetValue(this) + cmll + EasyUtilitario.Constantes.Caracteres.PuntoyComa + "\n";
            }

           // ScriptConatantes += Pagina + EasyUtilitario.Constantes.Caracteres.Punto + "PathFotosPersonal = " + cmll + EasyUtilitario.Helper.Configuracion.PathFotos + cmll;

            Page.RegisterClientScriptBlock("ConstPag", "<script>\n" + ScriptConatantes + "\n" + "</script>");

            //Registra Usuario logueado
            UsuarioBE oUsuarioBE = (new SeguridadSoapClient()).GetDatosUsuario(this.UsuarioId);

            

            string ScriptUser = @" var UsuarioBE ={};
                                        UsuarioBE.IdUsuario =  " + this.UsuarioId + @";
                                        UsuarioBE.UserName  = '" + this.UsuarioLogin + @"';
                                        UsuarioBE.IdPersonal =  " + oUsuarioBE.IdPersonal + @";
                                        UsuarioBE.ApellidosyNombres = '" + oUsuarioBE.ApellidosyNombres + @"';
                                        UsuarioBE.IdCentrOperativo = '" + oUsuarioBE.IdCentroOperativo + @"';
                                        UsuarioBE.NroDocumento = '" + oUsuarioBE.NroDocumento + @"';
                                        UsuarioBE.CodPersonal = '" + oUsuarioBE.CodPersonal +"'; ";

            Page.RegisterClientScriptBlock("UserInfo", "<script>\n" + ScriptUser + "\n" + "</script>");




        }

        public string UpperCaseFirstChar(string text)
        {
            return Regex.Replace(text, " ^ [a-z]", m => m.Value.ToUpper());
        }

        public  void EntityInJavascriptFromServer(System.Type t)
        {
            string LstProperty = "";
            string LstParametros = "";
            string NombreBE = t.Name;

            string PropertyBase = "";
            string NomField = "";

            BindingFlags flags = BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance;
            foreach (FieldInfo F in t.GetFields(flags)) // Aqui ocurre la magia :)           
            {
                NomField = F.Name.Substring(0, (F.Name.Length - 5));
                NomField = this.UpperCaseFirstChar(NomField);
                LstParametros += "_" + NomField + EasyUtilitario.Constantes.Caracteres.Coma;
                LstProperty += "this." + NomField + EasyUtilitario.Constantes.Caracteres.SignoIgual + "_" + NomField + EasyUtilitario.Constantes.Caracteres.PuntoyComa + "\n";
            }

            //Prpiedades de la clase heredada
            flags = BindingFlags.Instance | BindingFlags.Static | BindingFlags.Public |BindingFlags.NonPublic | BindingFlags.FlattenHierarchy |BindingFlags.DeclaredOnly;
            //FieldInfo[] fl = t.BaseType.GetFields(flags);
           
            foreach (FieldInfo F in t.BaseType.GetFields(flags))
            {
                NomField = F.Name.Substring(0, (F.Name.Length - 5));
                NomField = this.UpperCaseFirstChar(NomField);
                LstParametros += "_" + NomField + EasyUtilitario.Constantes.Caracteres.Coma;
                LstProperty += "this." + NomField + EasyUtilitario.Constantes.Caracteres.SignoIgual + "_" + NomField + EasyUtilitario.Constantes.Caracteres.PuntoyComa + "\n";

            }

            string ScriptBE = "function " + NombreBE + "(" + LstParametros.Substring(0, LstParametros.Length - 1) + @"){" + "\n" + @"
                                     " + LstProperty + @"
                                }" + "\n";

            EasyUtilitario.Helper.Pagina.DEBUG(ScriptBE);

            Page.RegisterClientScriptBlock("Entity", "<script>\n" + ScriptBE + "\n" + "</script>");
        }

        #region Agentes JavaScript
                public void DataTableToXML(DataTable dt)
                {

                    try
                    {
                        TransformsData(dt);
                    }
                    catch (Exception ex)
                    {
                        TransformsData(EasyUtilitario.Helper.Data.Error(this.GetPageName(), ex.Message));
                    }
                }
                public void EntityToXML(object obj)
                {
                    string returnCarr = EasyUtilitario.Constantes.Caracteres.RetornoCarr;
                    string cmll = EasyUtilitario.Constantes.Caracteres.ComillaDoble;
                    try
                    {
                        string Structura = "<DocumentElement>";
                        if (obj == null)
                        {
                            Structura += "<Error>";
                            Structura += returnCarr;
                            Structura += "<Number>0001</Number>";
                            Structura += returnCarr;
                            Structura += "<Descripcion>No DataFound</Descripcion>";
                            Structura += returnCarr;
                            Structura += "</Error>";
                            Structura += returnCarr;
                        }
                        else
                        {
                            Type typeData = obj.GetType();
                            int idx = 0;
                            Structura += "<Entity Name='" + typeData.Name + "'>";
                            Structura += returnCarr;
                            foreach (var propertyInfo in typeData.GetProperties())
                            {
                                if (propertyInfo.GetValue(obj, propertyInfo.GetIndexParameters()) != null)
                                {
                                    Structura += "<" + propertyInfo.Name.ToString() + ">" + propertyInfo.GetValue(obj, propertyInfo.GetIndexParameters()) + "</" + propertyInfo.Name.ToString() + ">";
                                }
                                else
                                {
                                    Structura += "<" + propertyInfo.Name.ToString() + "/>";
                                }
                                Structura += returnCarr;
                            }
                            Structura += "</Entity>";
                        }
                        Structura += "</DocumentElement>";

                        TransformsData(Structura);
                    }
                    catch (Exception ex)
                    {
                        TransformsData(EasyUtilitario.Helper.Data.Error(this.GetPageName(), ex.Message));
                    }
                }
                public void DiccionaryToEntityJS(string strEntity)
                {
                    string returnCarr = EasyUtilitario.Constantes.Caracteres.RetornoCarr;
                    string cmll = EasyUtilitario.Constantes.Caracteres.ComillaDoble;
                    try
                    {
                        string Structura = "<DocumentElement>";
                                Structura += returnCarr;
                                Structura += "<DictionaryBE Name='objJava'>";
                                Structura += returnCarr;
                                Structura += "<Esquema>" + strEntity + "</Esquema>";
                                Structura += returnCarr;
                                Structura += "</DictionaryBE>";
                                Structura += returnCarr;
                                Structura += "</DocumentElement>";

                        TransformsData(Structura);
                    }
                    catch (Exception ex)
                    {
                        TransformsData(EasyUtilitario.Helper.Data.Error(this.GetPageName(), ex.Message));
                    }
                }
                public void ResultNonQuery(string strValue)
                {
                    string returnCarr = EasyUtilitario.Constantes.Caracteres.RetornoCarr;
                    string cmll = EasyUtilitario.Constantes.Caracteres.ComillaDoble;
                    try
                    {
                        string Structura = "<DocumentElement>";
                        Structura += returnCarr;
                        Structura += "<NonQuery Name='objJava'>";
                        Structura += returnCarr;
                        Structura += "<Result>" + strValue + "</Result>";
                        Structura += returnCarr;
                        Structura += "</NonQuery>";
                        Structura += returnCarr;
                        Structura += "</DocumentElement>";

                        TransformsData(Structura);
                    }
                    catch (Exception ex)
                    {
                        TransformsData(EasyUtilitario.Helper.Data.Error(this.GetPageName(), ex.Message));
                    }
                }

        public void ErrorToXML(string ErroNumber,string Origen,Exception ex)
                {
                    string returnCarr = EasyUtilitario.Constantes.Caracteres.RetornoCarr;
                    string Structura = "<DocumentElement>";
                            Structura += "<Error>";
                            Structura += returnCarr;
                            Structura += "<Number>" + ErroNumber  + "</Number>";
                            Structura += returnCarr;
                            Structura += "<Origen>" + Origen + "</Origen>";
                            Structura += returnCarr;
                            Structura += "<Descripcion>" +ex.Message + "</Descripcion>";
                            Structura += returnCarr;
                            Structura += "</Error>";
                            Structura += returnCarr;
                    Structura += "</DocumentElement>";
                    TransformsData(Structura);
                }

                 void TransformsData(string StrSerializado)
                {
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.Buffer = true;
                    // Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
                    HttpContext.Current.Response.ContentType = "text/xml"; ;
                    HttpContext.Current.Response.Charset = "";
                    HttpContext.Current.Response.Output.Write(StrSerializado);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.Close();

                }

                void TransformsData(DataTable dt)
                {
                    string result;
                    using (StringWriter sw = new StringWriter())
                    {
                        if (dt != null)
                        {
                            dt.WriteXml(sw);
                            result = sw.ToString();
                        }
                        else {
                            result = "NoDataFound";
                        }
                    }
                    HttpContext.Current.Response.ClearContent();
                    HttpContext.Current.Response.Buffer = true;
                    // Response.AddHeader("content-disposition", "attachment; filename=DemoExcel.xls");
                    HttpContext.Current.Response.ContentType = "text/xml"; ;
                    HttpContext.Current.Response.Charset = "";
                    HttpContext.Current.Response.Output.Write(result);
                    HttpContext.Current.Response.Flush();
                    HttpContext.Current.Response.Close();
        }
        #endregion

    }

}