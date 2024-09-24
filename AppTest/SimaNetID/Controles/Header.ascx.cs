using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using EasyControlWeb;
using EasyControlWeb.Errors;
using EasyControlWeb.Filtro;
using EasyControlWeb.Form.Controls;
using Org.BouncyCastle.Asn1.Pkcs;
using SIMANET_W22R;
using SIMANET_W22R.Exceptiones;
using SIMANET_W22R.HelpDesk;
using SIMANET_W22R.HelpDesk.ChatBot;
using static System.Net.WebRequestMethods;
using static EasyControlWeb.EasyUtilitario.Enumerados;

namespace SIMANET_W22R.Controles
{
    /*
     * Autor:Rosales Azabache Eddy 
     */
    public partial class Header : System.Web.UI.UserControl {
        #region Variables Locales 
        const string NombreFuncion = "SystemMnuOptions";
        #endregion
        public string IdGestorFiltro
        {
            get { return (string)this.ViewState["CtrlFiltroRel"]; }
            set { this.ViewState["CtrlFiltroRel"] = value; }
        }
        public enum TipoLib {
            Style,
            Script,
            ScriptFrag,
        }
        public string[,] StyleBase {
            get { return new string[10, 2]{
                                                  { "bootstrap", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/bootstrap.min.css" }
                                                 /*,{ "jquery-ui",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/1.10.4.jquery-ui.css"} crea conflito con el treeview
                                                 ,{ "Autobusqueda","http://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css"}*/
                                                 ,{ "Autobusqueda",EasyUtilitario.Helper.Pagina.PathSite() + "/Recursos/css/jquery-ui.css"}
                                                 ,{ "bootstrap-datepicker3",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/1.4.1.bootstrap-datepicker3.css"}
                                                 ,{ "jquery-confirm.min.css",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/jquery-confirm.min.css"}
                                                 ,{ "font-awesome.min.css", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/font-awesome.min.css"}
                                                 ,{ "StyleEasy", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/StyleEasy.css"}
                                                 ,{ "EasyStyleProgressBar", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/EasyStyleProgressBar.css"}
                                                 ,{ "EasyNetLiveChat", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/EasyNetLiveChatx.css"}
                                                 ,{ "jqx.base", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/jqx.base.css"}
                                                 ,{ "jqx.light", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/jqx.light.css"}
                                                };
            }
        }

        public string[,] ScriptBase
        {
            get { return new string[18, 2]{
                                                /*  { "Core", "https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"}*/
                                                 { "Core", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/jquery.min.js"}
                                                 ,{ "bootstrap.min",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/4.5.2.bootstrap.min.js"}
                                                 ,{ "jquery-confirm.min",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/jquery-confirm.min.js"}
                                                // ,{ "jspdf.min",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/1.5.3-jspdf.min.js"}
                                                // ,{ "jspdf.plugin.autotable", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/3.5.6-jspdf.plugin.autotable.js"}
                                                 ,{ "Objects", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/LibSIMA/Objetcs.js"}
                                                 ,{ "Socket", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/LibSIMA/NetSuiteSocket.js"}
                                                 ,{ "EasyConect",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/LibSIMA/EasyDataInterConect.js"}
                                                 ,{ "AccesoDatosBase", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/LibSIMA/AccesoDatosBase.js"}
                                                 ,{ "SIMA.GidView.Entended", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/LibSIMA/SIMA.GidView.Entended.js"}
                                                 ,{ "HtmlToCanvas", EasyUtilitario.Helper.Pagina.PathSite()+  "/Recursos/LibSIMA/HtmlToCanvas.js"}
                                                 ,{ "EasyControlSetting", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/LibSIMA/EasyControlSetting.js"}
                                                 ,{ "jquery-ui.min", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/jquery-ui.min.js"}
                                                 //,{ "jquery-ui.min", "http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js"}
                                                 //,{ "jquery-ui.min", "http://code.jquery.com/ui/1.13.0/jquery-ui.min.js"}
                                                 ,{ "datepicker", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/1.4.1.bootstrap-datepicker.min.js"}
                                                 ,{ "bootstrap-waitingfor", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/bootstrap-waitingfor.js"}
                                                 ,{ "jqxcore",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/jqxcore.js"}
                                                 ,{ "jqxmenu",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/jqxmenu.js"}
                                                // ,{ "menuContext","https://www.jqueryscript.net/demo/simple-dynamic-context-menu/dist/js/simple-context-menu.min.js"}
                                                 ,{ "menuContext",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/simple-context-menu.min.js"}
                                                 ,{ "ConstPrc",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/LibSIMA/ConstanteProcesos.js"}
                                                 ,{ "ConfigBase",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/LibSIMA/MasterConfig.js"}
                                                };

            }
        }
        public string[,] InitDefBase
        {
            get
            {
                string PScript = @"var Page = {};
                                        Page.Response = {};
                                        Page.Response.redirect = function (Url) {
                                            window.location.href = Url;
                                        }
                                        Page.Response.OnLoadComplete = null;
                                        Page.Response.CtrlDestino = null;
                                        Page.Response.Load = function (UrlPage) {
                                            if (Page.Response.CtrlDestino != null) {
                                                var fncLink = ((Page.Response.OnLoadComplete != null) ? Page.Response.OnLoadComplete : " + EasyUtilitario.Constantes.Caracteres.ComillaDoble + EasyUtilitario.Constantes.Caracteres.ComillaDoble +@");
                                                jNet.get(Page.Response.CtrlDestino).load(UrlPage, " + EasyUtilitario.Constantes.Caracteres.ComillaDoble + EasyUtilitario.Constantes.Caracteres.ComillaDoble + @", fncLink);
                                            }
                                        }
                                        Page.Request = {};
                                        Page.Request.App_Protocol_Path_Name = "+ EasyUtilitario.Constantes.Caracteres.ComillaDoble + EasyUtilitario.Helper.Pagina.PathSite() + EasyUtilitario.Constantes.Caracteres.ComillaDoble  + @";
                                        Page.Request.ApplicationPath = Page.Request.App_Protocol_Path_Name;
                                        Page.Request.Params = new Array();
                                        ";
                return new string[1, 1] { { PScript } };
            }
        }

        public string[,] InitMenu {
            get
            {
                return new string[1, 1] { { "$.jqx.theme = 'light';" } };
            }
        }

        string[,] TagCtrl = new string[2, 5] {{ "link","href" ,"rel","stylesheet","Estylos Base"}
                                                  ,{ "script","src" ,"type", "text/javascript","Scripts Base"}
                                                 };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // EasyNavigatorBarMenu1.IconColor = "#a8a8a8";
                EasyNavigatorBarMenu1.IconColor = "white";
                EasyNavigatorBarMenu1.IconColorOver = "green";
                this.btnIconMenu.Style.Add("display", "none");
            }
            try
            {
                /*-----------------------------DEFINICION DEL PATH DEL APP---------------------------*/
                RegistrarLibs(Page.Header, TipoLib.ScriptFrag, this.InitDefBase);

                /*---------------Carga Los Stylos y Librerias Base-------------------*/
                RegistrarLibs(Page.Header,TipoLib.Style,this.StyleBase);
                RegistrarLibs(Page.Header, TipoLib.Script, this.ScriptBase);
                RegistrarLibs(Page.Header, TipoLib.ScriptFrag, this.InitMenu);
                /*-------------------------------------------------------------------*/

                LoadOpcionesdeMenu();

                EasyNavigatorBarIconBE oEasyNavigatorBarIconBE = new EasyNavigatorBarIconBE();
                oEasyNavigatorBarIconBE.fa_icon = "fa fa-filter";
                oEasyNavigatorBarIconBE.Text = "Filtrar";
                //  string fcGestorFiltro = ((IdGestorFiltro != null) ? IdGestorFiltro + "_OpenWinModal('" + IdGestorFiltro + "_Crit');" : "");
                string fcGestorFiltro = ((IdGestorFiltro != null) ? IdGestorFiltro + "_Init();" : "");
                oEasyNavigatorBarIconBE.call_fcScript =  fcGestorFiltro; 
                

                EasyNavigatorBarMenu1.OptionsIcon.Add(oEasyNavigatorBarIconBE);

                oEasyNavigatorBarIconBE = new EasyNavigatorBarIconBE();
                oEasyNavigatorBarIconBE.fa_icon = "fa fa-print";
                oEasyNavigatorBarIconBE.Text = "Previo";
                oEasyNavigatorBarIconBE.call_fcScript = "PrintPrevio();";
                EasyNavigatorBarMenu1.OptionsIcon.Add(oEasyNavigatorBarIconBE);



                oEasyNavigatorBarIconBE = new EasyNavigatorBarIconBE();
                oEasyNavigatorBarIconBE.fa_icon = "fa fa-bell-o";
                oEasyNavigatorBarIconBE.Text = "Alerta";
                //oEasyNavigatorBarIconBE.call_fcScript = "NetSuite.LiveChat.Show('ChatRoom');"; 
                oEasyNavigatorBarIconBE.call_fcScript = "LiveChat_OnLoad();";
                EasyNavigatorBarMenu1.OptionsIcon.Add(oEasyNavigatorBarIconBE);



                oEasyNavigatorBarIconBE = new EasyNavigatorBarIconBE();
                oEasyNavigatorBarIconBE.fa_icon = "fa fa-camera-retro";
                oEasyNavigatorBarIconBE.Text = "SnapShot";
                oEasyNavigatorBarIconBE.call_fcScript = "SnapShotFlash();";
                EasyNavigatorBarMenu1.OptionsIcon.Add(oEasyNavigatorBarIconBE);

               /* oEasyNavigatorBarIconBE = new EasyNavigatorBarIconBE();
                oEasyNavigatorBarIconBE.fa_icon = "../../Recursos/img/Infinity.gif";
                oEasyNavigatorBarIconBE.Text = "";
                oEasyNavigatorBarIconBE.TipoImg =true;
                EasyNavigatorBarMenu1.OptionsIcon.Add(oEasyNavigatorBarIconBE);*/

                /*Establece la funcion Script para las opsciones de menu del sistema*/
                EasyNavigatorBarMenu1.fc_OnMenuItem_Click = NombreFuncion;

                /*Obtiene el usuario logueado*/
                EasyNavigatorBarMenu1.SetUser(EasyUtilitario.Helper.Sessiones.Usuario.get());

                //Registra script de funcionalidad del menu options
                Page.RegisterClientScriptBlock("MnuOPSys", ScriptMnuOpSystem());



                string ScriptMenuIco = @"<script>
                                                function PrintPrevio()
                                                    {
                                                        __doPostBack('" + this.btnIconMenu.UniqueID + @"', 'ReportExploreV2');
                                                    }
                                            </script>";
                Page.RegisterClientScriptBlock("IconBTN", ScriptMenuIco);


                string cmll = EasyUtilitario.Constantes.Caracteres.ComillaDoble;
                string Iconochat = @"'<div  style=" + cmll + "display: flex;" + cmll + @">'
                                      +'<div class=" + cmll + "logo" + cmll  + @">'
                                        +'<svg viewBox=" +cmll +"0 0 513 513" + cmll +" fill=" + cmll + "currentColor" + cmll +" xmlns=" + cmll + "http://www.w3.org/2000/svg" + cmll + @">'
                                            +'<path d=" + cmll+ "M256.025.05C117.67-2.678 3.184 107.038.025 245.383a240.703 240.703 0 0085.333 182.613v73.387c0 5.891 4.776 10.667 10.667 10.667a10.67 10.67 0 005.653-1.621l59.456-37.141a264.142 264.142 0 0094.891 17.429c138.355 2.728 252.841-106.988 256-245.333C508.866 107.038 394.38-2.678 256.025.05z" + cmll + @"/>'
                                            +'<path d=" + cmll + "M330.518 131.099l-213.825 130.08c-7.387 4.494-5.74 15.711 2.656 17.97l72.009 19.374a9.88 9.88 0 007.703-1.094l32.882-20.003-10.113 37.136a9.88 9.88 0 001.083 7.704l38.561 63.826c4.488 7.427 15.726 5.936 18.003-2.425l65.764-241.49c2.337-8.582-7.092-15.72-14.723-11.078zM266.44 356.177l-24.415-40.411 15.544-57.074c2.336-8.581-7.093-15.719-14.723-11.078l-50.536 30.744-45.592-12.266L319.616 160.91 266.44 356.177z"+ cmll + " fill =" + cmll +"#fff" + cmll + @"/>'
                                        +'</svg>'
                                    +'</div>'
                                    +'  <div style= " + cmll + "padding-left:20px;" +cmll + @">  NetSuiteChatBots</div>'
                                    +'</div>'";

                string ScriptLiveChat = @"<script>
                                                 function LiveChat_OnLoad () {
                                                    //Verifica si existe servicio de Listener
                                                    if(NetSuite.Manager.Infinity.User.Contectado==false){
                                                        var msgConfig = { Titulo: 'Advertencia', Descripcion: 'Listener SIMA NetSuiteSocket no se enceuentra activo'};
                                                        var oMsg = new SIMA.MessageBox(msgConfig);
                                                        oMsg.Alert();
                                                        return
                                                    }
                                                    if(UsuarioBE.CodPersonal.toString().length==0){
                                                        var msgConfig = { Titulo: 'Advertencia', Descripcion: 'Maestro de personal SIMANET, Usuario no tiene asociado el código de personal del Mod O7 Solutions'};
                                                        var oMsg = new SIMA.MessageBox(msgConfig);
                                                        oMsg.Alert();
                                                        return
                                                    }

                                                    if(UsuarioBE.IdContacto=='0'){
                                                        var oContactBE = new NetSuite.LiveChat.ContactBE();
                                                            oContactBE.IdContacto = 0;
                                                            oContactBE.Foto = '';
                                                            oContactBE.Nombre = '';
                                                            oContactBE.Tipo=0;
                                                            oContactBE.CodPersonal=UsuarioBE.CodPersonal;

                                                        var oParamCollections = new SIMA.ParamCollections();
                                                        var oParam = new SIMA.Param('IdContacto', oContactBE.IdContacto, TipodeDato.Int);
                                                            oParamCollections.Add(oParam);
                                                            oParam = new SIMA.Param('IsGrupo', oContactBE.Tipo, TipodeDato.Int);
                                                            oParamCollections.Add(oParam);
                                                            oParam = new SIMA.Param('NombreGrupo',oContactBE.Nombre);
                                                            oParamCollections.Add(oParam);
                                                            oParam = new SIMA.Param('FotoGrupo', oContactBE.Foto);
                                                            oParamCollections.Add(oParam);
                                                            oParam = new SIMA.Param('LIB_JS_SRVBROKER', '');
                                                            oParamCollections.Add(oParam);
                                                            oParam = new SIMA.Param('Descripcion', '');
                                                            oParamCollections.Add(oParam);
                                                            oParam = new SIMA.Param('CodPersonal',  oContactBE.CodPersonal);
                                                            oParamCollections.Add(oParam);
                                                            oParam = new SIMA.Param('IdUsuario', UsuarioBE.IdUsuario, TipodeDato.Int);
                                                            oParamCollections.Add(oParam);

                                                        var oEasyDataInterConect = new EasyDataInterConect();
                                                             oEasyDataInterConect.MetododeConexion = ModoInterConect.WebServiceExterno;
                                                             oEasyDataInterConect.UrlWebService = ConnectedService.PathNetCore + 'HelpDesk/ChatBot/IChatBotManager.asmx'; 
                                                             oEasyDataInterConect.Metodo = 'IRegistrarContactoyGrupo';
                                                             oEasyDataInterConect.ParamsCollection = oParamCollections;

                                                        var oEasyDataResult = new EasyDataResult(oEasyDataInterConect);
                                                        var objResultBE=oEasyDataResult.sendData().toString().SerializedToObject();
                                                        UsuarioBE.IdContacto=objResultBE.IDCONTACTO

                                                    }
                                                    
                                                    var urlPag = Page.Request.ApplicationPath + '/HelpDesk/ChatBot/EasyNetLiveChat.aspx';
                                                    var oColletionParams = new SIMA.ParamCollections();
                                                    var oParam = new SIMA.Param('QLlama', GlobalEntorno.PageName);
                                                        oColletionParams.Add(oParam);
                                                        " + EasyPopupLiveChat.ClientID + @".Titulo=" + Iconochat + @" ;
                                                        " + EasyPopupLiveChat.ClientID + @".Load(urlPag, oColletionParams, false);
                                                        NetSuite.LiveChat.WndPopupIface =jNet.get('" + EasyPopupLiveChat.ClientID + @"');
                                                        NetSuite.Manager.Infinity.InterfaceLoad=true;
                                                    
                                                }

                                                function LiveChat_OnClose(){
                                                    NetSuite.Manager.Infinity.InterfaceLoad=true;
                                                }

                                                //Implementacones para el control de socket chatbot
                                                window.onload=function(){
                                                    window.ClosePorApp=false;
                                                }
                                                window.onbeforeunload = function(evt){
                                                        if(window.ClosePorApp){
                                                            NetSuite.LiveChat.close();//Cierra la conexion con el Listener NetSuiteWebSocket
                                                        }

                                                }

                                         </script>";
                Page.RegisterClientScriptBlock("IconMsg1", ScriptLiveChat);



            }
            catch (Exception ex) {
                
                this.LanzarException("Se esta intentando ingresar de forma INCORRECTA, Error Usuario no Autenticado", ex.TargetSite.Name);
            }
           
        }
        void LoadOpcionesdeMenu() {
            try
            {
                EasyUsuario oEasyUsuario = EasyUtilitario.Helper.Sessiones.Usuario.get();
                if (oEasyUsuario != null)
                {
                    DataTable dtOp = oEasyUsuario.getOpcions();
                    Int64 N_total = 0;
                    if (dtOp is null)
                    {
                        N_total = 0;
                    }
                    else
                    {
                        N_total = dtOp.Rows.Count;
                    }

                    if (N_total > 0)
                    {
                        try
                        {
                            foreach (DataRow dr in dtOp.Select("TipoMenu=1"))
                            {
                                EasyNavigatorBarMenuBE oEasyNavigatorBarMenuBE = new EasyNavigatorBarMenuBE();
                                oEasyNavigatorBarMenuBE.IdOpcion = Convert.ToInt32(dr["IdOpcion"].ToString());
                                oEasyNavigatorBarMenuBE.IdOpcionPadre = Convert.ToInt32(dr["IdPadre"].ToString());
                                oEasyNavigatorBarMenuBE.Nombre = dr["Nombre"].ToString();
                                oEasyNavigatorBarMenuBE.RutaPag = dr["Descripcion"].ToString();
                                DataRow[] drHijos = dtOp.Select("IdPadre='" + oEasyNavigatorBarMenuBE.IdOpcion.ToString() + "' and TipoMenu=1");
                                oEasyNavigatorBarMenuBE.NroSubItems = 0;
                                if (drHijos != null)
                                {
                                    int LenghtCar = 0;
                                    foreach (DataRow drh in drHijos)
                                    {
                                        string NomMenu = drh["Nombre"].ToString();
                                        if (LenghtCar < NomMenu.Length)
                                        {
                                            LenghtCar = NomMenu.Length;
                                        }
                                    }
                                    switch (LenghtCar)
                                    {
                                        case int n when (n >= 0 && n <= 15):
                                            oEasyNavigatorBarMenuBE.AnchoGrp = 130;
                                            break;
                                        case int n when (n >= 16 && n <= 20):
                                            oEasyNavigatorBarMenuBE.AnchoGrp = 180;
                                            break;
                                        case int n when (n >= 21 && n <= 25):
                                            oEasyNavigatorBarMenuBE.AnchoGrp = 185;
                                            break;
                                        case int n when (n >= 26 && n <= 32):
                                            oEasyNavigatorBarMenuBE.AnchoGrp = 220;
                                            break;
                                        case int n when (n >= 33 && n <= 36):
                                            oEasyNavigatorBarMenuBE.AnchoGrp = 260;
                                            break;
                                        case int n when (n >= 37 && n <= 38):
                                            oEasyNavigatorBarMenuBE.AnchoGrp = 310;
                                            break;
                                        case int n when (n >= 39 && n <= 40):
                                            oEasyNavigatorBarMenuBE.AnchoGrp = 280;
                                            break;
                                        case int n when (n >= 41 && n <= 50):
                                            oEasyNavigatorBarMenuBE.AnchoGrp = 330;
                                            break;
                                        case int n when (n >= 51 && n <= 60):
                                            oEasyNavigatorBarMenuBE.AnchoGrp = 335;
                                            break;

                                    }

                                    oEasyNavigatorBarMenuBE.NroSubItems = drHijos.Count();
                                }
                                EasyNavigatorBarMenu1.CollectionMenu.Add(oEasyNavigatorBarMenuBE);
                            }
                        }
                        catch (Exception ex)
                        {

                            this.LanzarException("Usuario Autenticado sin accesos de menú establecidos, Consulte con el Adminstrador de SIMANET", ex.TargetSite.Name);
                        }
                    }
                    else
                    {
                        this.LanzarException("Usuario Autenticado sin accesos de menú establecidos, Consulte con el Adminstrador de SIMANET", "CONEXIÓN");
                    }
                }
                else {
                    // Exception oex = new Exception("Session de usuario a expirado, por favor volver a autenticar");
                    SIMAExceptionSeguridadAccesoForms oex = new SIMAExceptionSeguridadAccesoForms("Session de usuario a expirado, por favor volver a autenticar");
                     (new PaginaBase()).LanzarException(oex);
                }
            }
            catch (SIMAExceptionSeguridadAccesoForms ex) {
                (new PaginaBase()).LanzarException(ex);
            }
        }
        protected void EasyNavigatorBarMenu1_HelpSnapShot(EasyControlWeb.Form.Controls.EasySnapShotBE oEasySnapShotBE)
        {
            string NomFile = EasyControlWeb.EasyUtilitario.Helper.Configuracion.Leer("ArchivosAPP", "PathSnapShot") + "Mnu_" + oEasySnapShotBE.IdRef + ".png";
            oEasySnapShotBE.LocalStorage = NomFile;
            EasyControlWeb.EasyUtilitario.Helper.Genericos.SubirArchivo(oEasySnapShotBE.LocalStorage, oEasySnapShotBE.ImgByteArray);
        }

            string PaginaLogin = EasyUtilitario.Helper.Pagina.PathSite()+ "/Login.aspx";
        string ScriptMnuOpSystem() {
            string _sc = @"<script>
                                function " + NombreFuncion  + @"(_key, _Tipo, _IdUser) {
                                    switch(_key){
                                        case 'Key2'://Configuraciones de modulos
                                                LoadConfigMaster();
                                            break;
                                        case 'Key4':
                                            window.ClosePorApp=true;//Indica que la ventana se esta cerrando correctamente mediante el aplicativo en caso sea falso  es un cierre abrupto
                                            Page.Response.redirect('" + PaginaLogin + @"');
                                        break;
                                    
                                    }
                                }
                           </script>
                         ";
            return _sc;
        }
        public void LanzarException(string Mensaje,string TargetSite)
        {
            string[] PagSplit = Page.Request.Url.AbsolutePath.Split('/');
            string Pagina = PagSplit[PagSplit.GetUpperBound(0)];
            string Autorizado = EasyUtilitario.Helper.Configuracion.Leer("FormsFree", Pagina);
            if ((Autorizado == null) || (Autorizado == "0"))
            {
                EasyErrorControls oEasyErrorControls = new EasyErrorControls();
                oEasyErrorControls.Origen = TargetSite; //ex.TargetSite.Name;
                oEasyErrorControls.Mensaje = Mensaje;
                oEasyErrorControls.Pagina = Pagina;
                oEasyErrorControls.LanzarException("OnLoad");
            }
        }

        protected void btnIconMenu_Click(object sender, EventArgs e)
        {
            HttpRequest ContextRequest = ((System.Web.UI.Page)HttpContext.Current.Handler).Request;
            string Argument = ContextRequest["__EVENTARGUMENT"];
            switch (Argument) {
                case "ReportExploreV2":
                    EasyControlWeb.Form.Controls.EasyNavigatorBE oEasyNavigatorBE = new EasyControlWeb.Form.Controls.EasyNavigatorBE();
                    
                    oEasyNavigatorBE.Texto = "Explorador de Reportes";
                    oEasyNavigatorBE.Descripcion = "Explorador de reportes";
                    oEasyNavigatorBE.Pagina = "/GestionReportes/"+ Argument + ".aspx";
                    (new PaginaBase()).IrA(oEasyNavigatorBE);
                    break;

            }
        }

        public void RegistrarLibs(HtmlHead oPagina, TipoLib oTipoLib, string[,] LibRef,bool Secuencia)
        {
            Type csType = this.GetType();
            ClientScriptManager cs = Page.ClientScript;
            int idxTag = ((oTipoLib == TipoLib.Style) ? 0 : 1);
            string cmll = EasyUtilitario.Constantes.Caracteres.ComillaDoble;
            for (int i = 0; i < LibRef.GetLength(0); i++)
            {
                if (!cs.IsClientScriptBlockRegistered(csType, LibRef[i, 0]))
                {
                    StringBuilder csText = new StringBuilder();
                    csText.Append("<" + TagCtrl[idxTag, 0] + " " + TagCtrl[idxTag, 2] +"=" + cmll + TagCtrl[idxTag, 3] + cmll  + " " + TagCtrl[idxTag, 1] +  "=" + cmll + LibRef[i, 1] + cmll + "> </" + TagCtrl[idxTag, 0]  + ">\n");
                    cs.RegisterClientScriptBlock(csType, LibRef[i, 0], csText.ToString());
                }

            }
        }

        public void RegistrarLibs(HtmlHead oPagina, TipoLib oTipoLib , string[,] LibRef) {
            
            int  idxTag = ((oTipoLib == TipoLib.Style) ? 0: 1);
            try
            {
                if (oPagina != null)
                {
                    switch (oTipoLib)
                    {
                        case TipoLib.Style:
                        case TipoLib.Script:
                            oPagina.Controls.Add(new LiteralControl("\n"));
                            oPagina.Controls.Add(new LiteralControl("<!--Registros de " + TagCtrl[idxTag, 4] + "-->\n"));
                            for (int i = 0; i < LibRef.GetLength(0); i++)
                            {
                                HtmlGenericControl CtrlLib = new HtmlGenericControl(TagCtrl[idxTag, 0]);
                                CtrlLib.Attributes["id"] = LibRef[i, 0];
                                CtrlLib.Attributes[TagCtrl[idxTag, 1]] = LibRef[i, 1];
                                CtrlLib.Attributes[TagCtrl[idxTag, 2]] = TagCtrl[idxTag, 3];
                                oPagina.Controls.Add(CtrlLib);

                                oPagina.Controls.Add(new LiteralControl("\n"));
                            }
                            break;
                        case TipoLib.ScriptFrag:
                            oPagina.Controls.Add(new LiteralControl("<script>\n"));
                            for (int i = 0; i < LibRef.GetLength(0); i++)
                            {
                                oPagina.Controls.Add(new LiteralControl(LibRef[i, 0] + "\n"));
                            }
                            oPagina.Controls.Add(new LiteralControl("</script>\n"));
                            break;
                    }
                }
            }
            catch (Exception ex) { 

            }
         
            /*String csName = "scJQuery";
                Type csType = this.GetType();
                ClientScriptManager cs = Page.ClientScript;

                if (!cs.IsClientScriptBlockRegistered(csType, csName))
                {
                    StringBuilder csText = new StringBuilder();
                    csText.Append("<script type=\"text/javascript\" src=\"https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js\"> </script>");
                    cs.RegisterClientScriptBlock(csType, csName, csText.ToString());
                }
                */
        }

    }
}
