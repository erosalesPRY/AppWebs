using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
/**   REFERENCIAS A LIBRERIAS PARA REST **/
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Xml;
using System.Text;
using System.Data;
//using Microsoft.Reporting.WebForms;
using System.Text.RegularExpressions;
using EasyControlWeb;
using System.Diagnostics;
using EasyControlWeb.Filtro;
using System.IO;
/*  Referenciarmos al servicio */
using SIMANET_W22R.srvProdManodeObra;
using SIMANET_W22R.InterfaceUI;

namespace SIMANET_W22R.ManodeObra
{

    public partial class Planilla_Conformidad : PaginaBase, IPaginaBase
    {
        //   String sServicio = "http://10.10.90.138:7060/xml_oracle/xml_api.";

        //  produccion:   String sServicio = "http://10.10.90.138:7060/xml_oracle/xml_api.";
        //  desarrollo:   String sServicio = "http://10.10.90.168:7060/xml_oracle/xml_api.";

        // TODOS LAS INSTANCIAS APUNTAN AL MISMO SERVIDOR, Solo se diferencian en el nombre del metodo, si termina en: _test es para desarrollo
        //  string sMetodo_lee = "get_planilla_test?";
        //  string sMetodo_envia = "post_planilla_test?";


        String sParametros = "", url = "", sUser = "";
        string C_filtro = "", C_data_filtro = "", C_tipo_filtro = "", c_pto = "";
        Int64 N_total = 0;
        Int64 n_opcion = 0;
        int N_Total_filtro = 0;
        public DataTable dt= new DataTable();
        protected void Page_Load(object sender, EventArgs e)
        {

            if (!Page.IsPostBack)
            {

                this.LlenarJScript();

                sUser = this.UsuarioLogin;
                if (sUser != null && Session["sUser"] == null)
                {
                    Session["sUser"] = sUser;
                }

                Session["Filtro"] = "";
                prCargaCombos();

                //  prIgualarNivelAprob();
                this.LlenarGrilla(EasyGestorFiltro1.getFilterString()); // funcion para filtro de la grilla
            }

        }

        // **********SECCIÓN DE PROCEDIMIENTOS Y FUNCIONES ************************************************************************
        #region PROC_FUNC

        // Llena datos iniciales
        protected void prCargaCombos(Int64 n_caso = 0) // parametro caso: sirve para reutilizar este procedimiento y ejecutar solo una parte de el
        {
            // 1:AreaUsuaria
            // 2:TipoPlanilla
            // 3:LineaNegocio
            // 4:TipoConformidad

            string slinea = "*";
            // Llamada al servicio REST, el ip es del servicio de producción oracle JDE

            //**************** TIPO PLANILLA****************************************
            if (n_caso == 0 || n_caso == 2)
            {
                try
                {
                    ManodeObraSoapClient oMOB = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
                    DataTable dt = oMOB.ListarTiposPlanilla();

                    if (dt != null)
                    {

                        EDDL_TipoPlanilla.DataSource = dt;  // nombre_de_la_tabla  ["TipoPlanilla"]
                        EDDL_TipoPlanilla.DataTextField = "etiqueta"; // NOM_AUS
                        EDDL_TipoPlanilla.DataValueField = "COD_TIP_PLL";
                        EDDL_TipoPlanilla.DataBind();
                    }
                    else
                    {
                        lblmensaje.Text = "Sin registros";
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("fallo:", ex.Message);
                    this.lblmensaje.Text = "prCargaCombos() " + ex.Message + " ListarTiposPlanilla";
                }
            }
            //**************** LINEA DE NEGOCIO ******************
            if (n_caso == 0 || n_caso == 3)
            {

                try
                {
                    ManodeObraSoapClient oMOB = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
                    DataTable dt = oMOB.ListarLineasNegocio();
                    if (dt != null)
                    {

                        EDDL_LineaNegocio.DataSource = dt;  // nombre_de_la_tabla  ["planilla"]
                        EDDL_LineaNegocio.DataTextField = "etiqueta"; // NOM_AUS
                        EDDL_LineaNegocio.DataValueField = "COD_DIV";
                        EDDL_LineaNegocio.SelectedIndex = -1; // por defeto seleccionamos vacio el primer item
                        EDDL_LineaNegocio.DataBind();
                    }
                    else
                    {
                        lblmensaje.Text = "Sin registros";

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("fallo:", "prCargaCombos " + ex.Message);
                    this.lblmensaje.Text = "prCargaCombos() " + ex.Message + " ListarLineasNegocio";
                }

            }
            //**************** NIVELES CONFORMIDAD************************************************
            if (n_caso == 0 || n_caso == 4)
            {
                try
                {

                    ManodeObraSoapClient oMOB = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
                    DataTable dt = oMOB.ListarNivelesConformidad();

                    if (dt != null)
                    {


                        //------
                        EDDL_NivelConformidad.Enabled = true;
                        EDDL_NivelConformidad.DataSource = dt;  // nombre_de_la_tabla  ["TipoConformidad"]
                        EDDL_NivelConformidad.DataTextField = "etiqueta"; // + " " + "CONFORMIDAD"
                        EDDL_NivelConformidad.DataValueField = "TIPO";
                        EDDL_NivelConformidad.DataBind();
                        EDDL_NivelConformidad.Enabled = false;
                        //------------
                        EDDL_NivelConformidad1.Enabled = true;
                        EDDL_NivelConformidad1.DataSource = dt;  // nombre_de_la_tabla  ["TipoConformidad"]
                        EDDL_NivelConformidad1.DataTextField = "etiqueta"; // + " " + "CONFORMIDAD"
                        EDDL_NivelConformidad1.DataValueField = "TIPO";
                        EDDL_NivelConformidad1.DataBind();
                        EDDL_NivelConformidad1.Enabled = false;
                        prIgualarNivelAprob();

                    }
                    else
                    {
                        lblmensaje.Text = "Sin registros";

                    }


                }
                catch (Exception ex)
                {
                    Console.WriteLine("fallo:", ex.Message);
                    this.lblmensaje.Text = "prCargaCombos() " + ex.Message + " ListarNivelesConformidad";
                }
            }
            //**************** AREA USUARIA*************nota: se coloca al final para que filtre en base al primer registro de la linea de negoico cargada***************************
            if (n_caso == 0 || n_caso == 1)
            {
                if (n_caso == 0)
                {
                    slinea = "*"; //---muestra todas
                }
                else
                {
                    slinea = EDDL_LineaNegocio.SelectedValue; //---muestra especifica
                }


                try
                {
                    ManodeObraSoapClient oMOB = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
                    DataTable dt = oMOB.ListarAreasUsuarias(slinea);

                    EDDL_AreaUsuaria.DataSource = dt;  // nombre_de_la_tabla  ["planilla"]
                    EDDL_AreaUsuaria.DataTextField = "etiqueta"; // NOM_AUS
                    EDDL_AreaUsuaria.DataValueField = "COD_AUS";
                    EDDL_AreaUsuaria.DataBind();
                    EDDL_AreaUsuaria.SelectedIndex = -1;




                }
                catch (Exception ex)
                {
                    Console.WriteLine("fallo:", ex.Message);
                    this.lblmensaje.Text = "prCargaCombos() " + ex.Message + " ListarAreasUsuarias";
                }
            }


        }

        // igual el combo de nivel de aprobación  de acuerdo al perfil del usuario conectado
        protected void prIgualarNivelAprob()
        // trae EL Nivel de Aprobacion asignado al usuario
        {
            // los niveles se asginan en JDE en la UDC  UA/CP 
            // *: Permite todos los Niveles, (usado por los desarrolladores)
            // $: Solo consulta, oculta botones  de conformidad
            DataTable dt;

            try
            {
                if (sUser == null || sUser == "")
                {
                    c_pto = "1";
                    sUser = UsuarioLogin;
                }



                // credenciales, Estos valores se deberian encriptar con con un algoritmo y guardado en un archivo txt
                string snivel = "";

                // Llamada al servicio REST, el ip es del servicio de producción oracle JDE
                ManodeObraSoapClient oMOB = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
                dt = oMOB.BuscarNivelAprobacion(sUser);

                c_pto = "2";
                if (dt != null)
                {

                    if (dt.Rows.Count > 0)
                    {

                        c_pto = "6";
                        snivel = dt.Rows[0][1].ToString();   // nombre_de_la_tabla standar ["Table"]
                        LblNivelUser.Text = snivel;


                        if (snivel == "*")  //-- usuario con todos los niveles
                        {
                            c_pto = "7";
                            EDDL_NivelConformidad.Enabled = true;
                            EDDL_NivelConformidad1.Enabled = true;

                        }
                        else if (snivel == "$")  //-- usuario solo lectura
                        {
                            //this.GVplanilla.EasyGridButtons["btnConformidad"].visible= false ;  

                            // inactivamos la seleccion de nivel de conformidad
                            EDDL_NivelConformidad.SelectedIndex = -1;
                            EDDL_NivelConformidad.Enabled = false;
                            EDDL_NivelConformidad.Visible = false;
                            this.Label6.Visible = false;

                            EDDL_NivelConformidad1.SelectedIndex = -1;
                            EDDL_NivelConformidad1.Enabled = false;
                            EDDL_NivelConformidad1.Visible = false;

                            if (GVplanilla.Rows.Count == 0)
                            {
                                c_pto = "7.1";
                            }
                            else
                            {
                                for (int i = 0; i < GVplanilla.Rows.Count; i++)
                                {
                                    c_pto = "7.2";
                                    GVplanilla.Rows[i].FindControl("BtSI").Visible = false;
                                    GVplanilla.Rows[i].FindControl("BtnNO").Visible = false;
                                }

                            }

                        }
                        else
                        {
                            c_pto = "8";
                            if (snivel != "")
                            {
                                EDDL_NivelConformidad.SelectedValue = snivel;
                                EDDL_NivelConformidad1.Enabled = true;
                                EDDL_NivelConformidad1.SelectedValue = snivel;
                                EDDL_NivelConformidad1.Enabled = false;
                            }

                        }
                    }
                    else
                    {
                        c_pto = "9";
                        lblmensaje.Text = "Usuario sin Nivel de Aprobación";
                        EDDL_NivelConformidad.Enabled = false;
                        EDDL_NivelConformidad1.Enabled = false;

                    }



                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("fallo:", ex.Message);
                this.lblmensaje.Text = "prIgualarNivelAprob <br/>" + c_pto + " " + ex.Message.Trim() + " ";
            }




        }

        // da conformidad General
        protected void prDarConformidad(Int64 N_PR = 0, Int64 n_opc = 0)  // PARAMETROS: PR Y OPCION DE PROCEDIMIENTO (0:Captura del form principal, 1: captura del popup) 
        {

            try
            {
                Int64 contador = 0, n_opcion = 1; // operacion a realizar 1 dar conformidad
                DataTable dt= new DataTable();

                // si el nivel no es permitido saldrá

                if (LblNivelUser.Text == "$")
                {


                    //MsgBox = new EasyMessageBox();
                    MsgBox.ID = "Msg";
                    MsgBox.Titulo = "AUTORIZACIÓN";
                    string msg = "Su usuario No esta autorizado para realizar Proceso de Conformidad de Planilla";
                    MsgBox.Contenido = msg;
                    MsgBox.Tipo = EasyUtilitario.Enumerados.MessageBox.Tipo.AlertType;
                    MsgBox.AlertStyle = EasyUtilitario.Enumerados.MessageBox.AlertStyle.modern;
                    Page.Controls.Add(MsgBox);

                    return;
                }

                // Llamada al servicio REST, el ip es del servicio de producción oracle JDE

                // ***** PARAMETROS **************
                String sTipoPL = EDDL_TipoPlanilla.SelectedValue; // TIPO DE PLANILLA (se esta capturando de un txt pero deberia ser una lista desplegable asociada al servicio web oracle
                String sTaller = EDDL_AreaUsuaria.SelectedValue; // taller como ejemplo, se coloca en duro, pero eberia ser una lista desplegable asociada al servicio web oracle
                String sLinea = EDDL_LineaNegocio.SelectedValue;
                String sNivelC;

                if (n_opc == 0)  // VALIDA DE QUE VENTANA  VIENE LA ACCION
                {
                    sNivelC = EDDL_NivelConformidad.SelectedValue;
                }
                else
                {
                    sNivelC = EDDL_NivelConformidad1.SelectedValue;
                }

                String C_FECHA = dpFechaPlanilla.Text;

                // ******* validacion de datos de variables*************
                if (sTipoPL == null)
                { sTipoPL = "inc"; }

                if ((sUser == null || sUser == "") && this.UsuarioLogin != null)
                { sUser = this.UsuarioLogin; }
                else if (sUser == null && Session["sUser"] != null)
                { sUser = (string)Session["sUser"]; }
                else
                { sUser = "Simanet"; }


                //------ VALIDA SI EXISTEN DATOS EN LA GRILLA PARA EJECUTAR LA ACCIÓN -------------------
                N_total = this.GVplanilla.Rows.Count;



                //*************CONSIDERAMOS LOS FILTROS **************************************************************************
                try
                {
                    C_filtro = (string)Session["Filtro"];
                    C_data_filtro = (string)Session["data_Filtro"];
                    C_tipo_filtro = (string)Session["tipo_Filtro"];

                    if (Session["total_Filtro"] != null)
                    {
                        N_Total_filtro = (int)Session["total_Filtro"];
                    }

                    if (C_data_filtro != null)
                    {
                        C_data_filtro = C_data_filtro.ToUpper().Trim();
                    }
                }
                catch (Exception ex)
                {
                    C_filtro = "";
                    C_data_filtro = "";
                    C_tipo_filtro = "";
                    N_Total_filtro = 0;

                }


                if (C_filtro == "SI")
                {
                    C_tipo_filtro = C_tipo_filtro.ToUpper();
                    switch (C_tipo_filtro)
                    {
                        case "OT":
                        case "PROYECTO":
                            // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************
                            if (N_PR > 0)
                            {
                                sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + C_FECHA + "&c_linea=" + sLinea
                                          + "&C_conformidad=" + sNivelC + "&n_opcion=" + n_opcion + "&n_pr=" + N_PR + "&c_user=" + sUser;

                                ManodeObraSoapClient oMOB = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
                               // dt = oMOB.Conformidad_ok(n_opcion, C_FECHA, sUser, sNivelC, N_PR, sTipoPL, sTaller, sLinea,null, null, null);
                                /*
                                    string C_FECHA        , string sUser             , string sNivelC = "L", 
                                    Int64 N_PR = 0       , string sTipoPL=null      , string sTaller="X32", string sLinea ="RN", 
                                    string sfiltro = "NO", string sTipo_filtro = "" , string sdata_filtro=""
                                */
                            }
                            else
                            {
                                sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + C_FECHA + "&c_linea=" + sLinea
                                          + "&C_conformidad=" + sNivelC + "&n_opcion=" + n_opcion + "&n_pr=" + N_PR + "&c_user=" + sUser
                                          + "&c_firma=" + C_data_filtro.Trim() + "&C_filtro=" + C_tipo_filtro.ToUpper();

                                ManodeObraSoapClient oMOB = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
                               // dt = oMOB.Conformidad_ok(n_opcion, C_FECHA, sUser, sNivelC, N_PR, sTipoPL, sTaller, sLinea,C_filtro, C_tipo_filtro, C_data_filtro);
                                /*
                                    string C_FECHA        , string sUser             , string sNivelC = "L", 
                                    Int64 N_PR = 0       , string sTipoPL=null      , string sTaller="X32", string sLinea ="RN", 
                                    string C_filtro = "NO", string C_tipo_filtro = "" , string sdata_filtro=""
                                */
                            }


                            //----- limpiamos filtros
                            Session["Filtro"] = "";
                            Session["data_Filtro"] = "";
                            Session["tipo_Filtro"] = "";
                            break;



                        default:
                            // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************
                            if (N_PR > 0)
                            {
                                sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + C_FECHA + "&c_linea=" + sLinea
                                          + "&C_conformidad=" + sNivelC + "&n_opcion=" + n_opcion + "&n_pr=" + N_PR + "&c_user=" + sUser;

                                ManodeObraSoapClient oMOB = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
                               // dt = oMOB.Conformidad_ok(n_opcion, C_FECHA, sUser, sNivelC, N_PR, sTipoPL, sTaller, sLinea,null, null, null);
                                /*
                                    string C_FECHA        , string sUser             , string sNivelC = "L", 
                                    Int64 N_PR = 0       , string sTipoPL=null      , string sTaller="X32", string sLinea ="RN", 
                                    string C_filtro = "NO", string C_tipo_filtro = "" , string C_data_filtro=""
                                */
                            }
                            else //---- masiva
                            {
                                sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + C_FECHA + "&c_linea=" + sLinea
                                              + "&C_conformidad=" + sNivelC + "&n_opcion=" + n_opcion + "&c_user=" + sUser;

                                ManodeObraSoapClient oMOB = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
                               // dt = oMOB.Conformidad_ok(n_opcion, C_FECHA, sUser, sNivelC, N_PR, sTipoPL, sTaller, sLinea,null, null, null);
                                /*
                                    string C_FECHA        , string sUser             , string sNivelC = "L", 
                                    Int64 N_PR = 0       , string sTipoPL=null      , string sTaller="X32", string sLinea ="RN", 
                                    string C_filtro = "NO", string C_tipo_filtro = "" , string C_data_filtro=""
                                */
                            }

                            break;
                    }
                }
                else if (C_filtro == "NO")
                {
                    if (N_PR > 0) // unico y sin filtros
                    {
                        sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + C_FECHA + "&c_linea=" + sLinea
                                  + "&C_conformidad=" + sNivelC + "&n_opcion=" + n_opcion + "&n_pr=" + N_PR + "&c_user=" + sUser + "&c_firma=-";

                        ManodeObraSoapClient oMOB = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
                       // dt = oMOB.Conformidad_ok(n_opcion, C_FECHA, sUser, sNivelC, N_PR, sTipoPL, sTaller, sLinea,null, null, null);
                        /*
                            string C_FECHA        , string sUser             , string sNivelC = "L", 
                            Int64 N_PR = 0       , string sTipoPL=null      , string sTaller="X32", string sLinea ="RN", 
                            string C_filtro = "NO", string C_tipo_filtro = "" , string C_data_filtro=""
                        */
                    }
                    else //---- masiva
                    {
                        sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + C_FECHA + "&c_linea=" + sLinea
                                      + "&C_conformidad=" + sNivelC + "&n_opcion=" + n_opcion + "&c_user=" + sUser + "&c_firma=-";

                        ManodeObraSoapClient oMOB = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
                      //  dt = oMOB.Conformidad_ok(n_opcion, C_FECHA, sUser, sNivelC, N_PR, sTipoPL, sTaller, sLinea,null, null, null);
                        /*
                            string C_FECHA        , string sUser             , string sNivelC = "L", 
                            Int64 N_PR = 0       , string sTipoPL=null      , string sTaller="X32", string sLinea ="RN", 
                            string C_filtro = "NO", string C_tipo_filtro = "" , string C_data_filtro=""
                        */
                    }
                }
                else
                {
                    dt = null;
                }
                //*************************************************************




                try
                {
                    if (dt != null)
                    {
                        // contamos los registos
                        if (dt.Rows.Count > 0)
                        {
                            if (N_Total_filtro > 0)
                            {
                                contador = N_Total_filtro;
                            }
                            else
                            {
                                contador = dt.Rows.Count;
                                lblmensaje.Text = dt.Rows[0][0].ToString();
                            }
                            lblmensaje.Text = " Total de registros afectados   " + contador + ", solo a los  que han tenido el mismo Nivel de conformidad/ filtro";
                        }
                        else
                        {
                            lblmensaje.Text = "Transacción No efectuada!";

                        }


                        prListar();
                    }
                    C_filtro = "";
                    C_data_filtro = "";
                    C_tipo_filtro = "";
                    N_Total_filtro = 0;

                }

                catch (Exception ex)
                {
                    Console.WriteLine("fallo:", ex.Message);
                    this.lblmensaje.Text = "prDarConformidad \n" + ex.Message + " ";
                }

            }

            catch (Exception ex)
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(1).GetMethod().Name + "/" + stack.GetFrame(0).GetMethod().Name;
                //this.LanzarException(NombreMetodo, ex);
                this.lblmensaje.Text = NombreMetodo + " \n" + ex.Message + " ";


            }
        }

        // Anular conformidad General
        protected void prAnularConformidad(Int64 N_PR = 0)
        {

            Int64 contador = 0;

            DataTable dt=new DataTable();
            if ((sUser == null || sUser == "") && this.UsuarioLogin != null)
            { sUser = this.UsuarioLogin; }
            else if (sUser == null && Session["sUser"] != null)
            { sUser = (string)Session["sUser"]; }
            else
            { sUser = "Simanet"; }


            if (LblNivelUser.Text == "$")
            {


                //MsgBox = new EasyMessageBox();
                MsgBox.ID = "Msg";
                MsgBox.Titulo = "AUTORIZACIÓN";
                string msg = "Su usuario No esta autorizado para Anular Proceso de Conformidad de Planilla";
                MsgBox.Contenido = msg;
                MsgBox.Tipo = EasyUtilitario.Enumerados.MessageBox.Tipo.AlertType;
                MsgBox.AlertStyle = EasyUtilitario.Enumerados.MessageBox.AlertStyle.modern;
                Page.Controls.Add(MsgBox);

                return;
            }
            // Llamada al servicio REST, el ip es del servicio de producción oracle JDE

            // ***** PARAMETROS **************
            String sTipoPL = EDDL_TipoPlanilla.SelectedValue; // TIPO DE PLANILLA (se esta capturando de un txt pero deberia ser una lista desplegable asociada al servicio web oracle
            String sTaller = EDDL_AreaUsuaria.SelectedValue; // taller como ejemplo, se coloca en duro, pero eberia ser una lista desplegable asociada al servicio web oracle
            String sLinea = EDDL_LineaNegocio.SelectedValue;
            String C_FECHA = dpFechaPlanilla.Text;
            String sNivelC = EDDL_NivelConformidad1.SelectedValue;

            n_opcion = -1; // anula conformidad
                           // ******* validacion de datos de variables*************
            if (sTipoPL == null)
            { sTipoPL = "inc"; }


            // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************

            try
            {

                //*************CONSIDERAMOS LOS FILTROS **************************************************************************
                try
                {
                    C_filtro = (String)Session["Filtro"];
                    C_data_filtro = (String)Session["data_Filtro"];
                    C_tipo_filtro = (String)Session["tipo_Filtro"];
                }
                catch
                {

                    C_data_filtro = "";
                    C_tipo_filtro = "";

                }


                if (C_filtro == "SI")
                {
                    if (C_tipo_filtro == null)
                    {
                        C_tipo_filtro = "";
                    }
                    C_tipo_filtro = C_tipo_filtro.ToUpper();
                    switch (C_tipo_filtro)
                    {
                        case "OT":
                        case "PROYECTO":
                            // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************
                            sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + C_FECHA + "&c_linea=" + sLinea +
                                           "&n_opcion=" + n_opcion + "&n_pr=" + N_PR + "&c_firma=" + C_data_filtro + "&c_filtro=" + C_tipo_filtro;


                            ManodeObraSoapClient oMOB = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
                           // dt = oMOB.Conformidad_ok(n_opcion, C_FECHA, sUser, sNivelC, N_PR, sTipoPL, sTaller, sLinea,C_filtro, C_tipo_filtro, C_data_filtro);
                            /*
                                string C_FECHA        , string sUser             , string sNivelC = "L", 
                                Int64 N_PR = 0       , string sTipoPL=null      , string sTaller="X32", string sLinea ="RN", 
                                string C_filtro = "NO", string C_tipo_filtro = "" , string C_data_filtro=""
                            */
                            //----- limpiamos filtros
                            Session["Filtro"] = "";
                            Session["data_Filtro"] = "";
                            Session["tipo_Filtro"] = "";
                            break;


                        default:
                            // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************
                            sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + C_FECHA + "&c_linea=" + sLinea +
                                        "&n_opcion=" + n_opcion + "&n_pr=" + N_PR + "&c_firma=-";

                            ManodeObraSoapClient oMOB1 = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
                           // dt = oMOB1.Conformidad_ok(n_opcion, C_FECHA, sUser, sNivelC, N_PR, sTipoPL, sTaller, sLinea,null, null, null);
                            /*
                                string C_FECHA        , string sUser             , string sNivelC = "L", 
                                Int64 N_PR = 0       , string sTipoPL=null      , string sTaller="X32", string sLinea ="RN", 
                                string C_filtro = "NO", string C_tipo_filtro = "" , string C_data_filtro=""
                            */
                            break;
                    }
                }
                else  //---  ANULA SIN FILTRO, CONDICIONES: PR
                {
                    sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + C_FECHA + "&c_linea=" + sLinea +
                                        "&n_opcion=" + n_opcion + "&n_pr=" + N_PR + "&c_firma=-";
                    ManodeObraSoapClient oMOB = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
                    //dt = oMOB.Conformidad_ok(n_opcion, C_FECHA, sUser, sNivelC, N_PR, sTipoPL, sTaller, sLinea,null, null, null);
                    /*
                        string C_FECHA        , string sUser             , string sNivelC = "L", 
                        Int64 N_PR = 0       , string sTipoPL=null      , string sTaller="X32", string sLinea ="RN", 
                        string C_filtro = "NO", string C_tipo_filtro = "" , string C_data_filtro=""
                    */

                }
                //*************************************************************



                {

                    if (dt != null)
                    {
                        // contamos los registos
                        if (dt.Rows.Count > 0)
                        {
                            if (C_filtro == "SI")
                            {
                                if (Session["total_Filtro"] != null)
                                {
                                    N_total = (int)Session["total_Filtro"];
                                    lblmensaje.Text = " Total de registros afectados   " + N_total;
                                }
                            }
                            else
                            {
                                contador = dt.Rows.Count;
                                lblmensaje.Text = " Total de registros afectados   " + contador;
                            }

                        }
                        else
                        {
                            lblmensaje.Text = "Transacción No efectuada!";
                        }


                    }
                    else
                    {
                        lblmensaje.Text = " No se pudo enviar información! ";
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("fallo:", ex.Message);
                this.lblmensaje.Text = "prAnularConformidad \n" + ex.Message + " ";
            }





        }

        protected void prListar(Int64 n_opcion = 0) // OBTIENE UNA PLANILLA, Para filtrar solo las aprobadas pasar 1
        {

            Int64 contador = 0;

            // captura de valores ingresados por los usarios desde los controles
            String sTipoPL = EDDL_TipoPlanilla.SelectedValue; // TIPO DE PLANILLA (se esta capturando de un txt pero deberia ser una lista desplegable asociada al servicio web oracle
            String cTaller = EDDL_AreaUsuaria.SelectedValue; // taller como ejemplo, se coloca en duro, pero eberia ser una lista desplegable asociada al servicio web oracle
            String C_FECHA = dpFechaPlanilla.Text;

            string C_Linea = "";  //--- * muestra todos los registros 
            c_pto = "1";
            if (n_opcion == 0)
            {
                C_Linea = "*";
            }
            else
            {
                C_Linea = null;
            }


            // ******* validacion de datos de variables*************
            if (sTipoPL == null)
            { sTipoPL = "inc"; }

            // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************
            c_pto = "2";

            try
            {

                ManodeObraSoapClient oMOB = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
               // DataTable dt = oMOB.BuscarPlanilla_ok(sTipoPL, cTaller, C_FECHA, n_opcion);
                // quitamos los saltos
                c_pto = "3";
                //    get_contenido = get_contenido.Replace("\r\n", "").Replace("\n", "").Replace("\r", "");


                // contamos los registos
                if (dt != null)
                {
                    c_pto = "4";
                    contador = dt.Rows.Count;
                    lblmensaje.Text = " Total de registros =  " + contador;
                    Session["Planillas"] = dt;
                    GVplanilla.DataSource = dt;  // nombre_de_la_tabla  ["planilla"]
                    c_pto = "5";
                    GVplanilla.DataBind();

                }
                else
                {
                    c_pto = "6";
                    GVplanilla.DataSource = null;
                    GVplanilla.DataBind();
                    lblmensaje.Text = "Sin registros";
                }

                prIgualarNivelAprob();

            }
            catch (Exception ex)
            {

                if (ex.Message != "La columna 'bookmark' ya pertenece a DataTable.")
                {
                    StackTrace stack = new StackTrace();
                    string NombreMetodo = stack.GetFrame(1).GetMethod().Name + "/" + stack.GetFrame(0).GetMethod().Name;
                    this.lblmensaje.Text = this.lblmensaje.Text.Trim() + NombreMetodo + " " + ex.Message + " verificar el pto=" + c_pto;
                }


            }
        }

        public void LlenarGrilla(string strFilter)
        {
            String sfiltro = "";
            Int64 iPosicion1 = 0, iPosicion2 = 0, iPosicion3 = 0, iPosicion4 = 0;

            try
            {

                DataTable dt = new DataTable();
                dt = (DataTable)Session["Planillas"]; // reutilizamos el valor captura de la grilla en la úlitma consulta. Para no ir a consumir el servicio nuevamente


                if (dt is null)
                {
                    int i = 0;
                }
                else
                {
                    DataView dv = dt.DefaultView;
                    if (strFilter.Length > 0)
                    {
                        Session["Filtro"] = "SI";
                        dv.RowFilter = strFilter;
                        sfiltro = strFilter.Substring(0);
                        iPosicion1 = -1; // desde donde aparace el valor
                        iPosicion3 = -1; // desde donde aparace el tipo filtro
                        iPosicion4 = -1;
                        //-- extraemos del filtro el valor ---
                        //--- indices
                        iPosicion1 = sfiltro.IndexOf("="); // desde donde aparace el valor
                        iPosicion3 = sfiltro.IndexOf("("); // desde donde aparace el tipo filtro
                        iPosicion4 = sfiltro.IndexOf(","); // desde donde termino el tipo filtro

                        if (iPosicion1 == -1) // --SI NO ENCONTRO EL CARACTER DEL FILTRO ES PORQUE USO LIKE
                        {

                            iPosicion1 = sfiltro.IndexOf("%"); // desde donde aparece el valor
                            iPosicion2 = (sfiltro.Length - 2);
                            N_total = iPosicion2 - iPosicion1;
                            Session["data_Filtro"] = sfiltro.Substring((int)(iPosicion1 + 1), (int)N_total).Replace("%", "").Replace("'", ""); // dato del filtro
                            Session["tipo_Filtro"] = sfiltro.Substring((int)(iPosicion3 + 1), (int)(iPosicion4 - iPosicion3 - 1));
                            Session["total_Filtro"] = dv.Count;
                        }

                        else if (iPosicion1 > 0)
                        {
                            iPosicion2 = (sfiltro.Length - 2);
                            Session["data_Filtro"] = sfiltro.Substring((int)(iPosicion1 + 2), 8); // dato del filtro
                            Session["tipo_Filtro"] = sfiltro.Substring((int)(iPosicion3 + 1), (int)(iPosicion4 - iPosicion3 - 1)); // tipo  del filtro
                            Session["total_Filtro"] = dv.Count;
                        }


                    }
                    GVplanilla.DataSource = dv;
                    GVplanilla.DataBind();
                    lblmensaje.Text = " Total de registros Filtrados =  " + dv.Count;
                }

            }
            catch (Exception ex)
            {
                // StackTrace stack = new StackTrace();
                // string NombreMetodo = stack.GetFrame(1).GetMethod().Name + "/" + stack.GetFrame(0).GetMethod().Name;
                // this.LanzarException(NombreMetodo, ex);
                lblmensaje.Text = "LlenarGrilla() " + ex.Message;
            }
        }

        private byte[] ConvertirFirma2(string dni)
        {
            try
            {


                //byte[] imagebyte = System.IO.File.ReadAllBytes(Server.MapPath("~/Firma/" + dni + ".jpg"));
                //return imagebyte;
                FileStream imagen = new FileStream(Server.MapPath("~/Recursos/Firmas/" + dni + ".jpeg"), FileMode.OpenOrCreate, FileAccess.ReadWrite);
                Byte[] arreglo = new Byte[imagen.Length];
                BinaryReader reader = new BinaryReader(imagen);
                arreglo = reader.ReadBytes(Convert.ToInt32(imagen.Length));
                imagen.Close();
                return arreglo;
            }
            catch (Exception ex)
            {
                //StackTrace stack = new StackTrace();
                //string NombreMetodo = stack.GetFrame(1).GetMethod().Name + "/" + stack.GetFrame(0).GetMethod().Name;
                //this.LanzarException(NombreMetodo, ex);
                lblmensaje.Text = "ConvertirFirma2 " + ex.Message;
                return null;
            }
        }

        private void prAprobadorxNivel(int inivel)
        {

            String sTipoPL = EDDL_TipoPlanilla.SelectedValue; // TIPO DE PLANILLA (se esta capturando de un txt pero deberia ser una lista desplegable asociada al servicio web oracle
            String sTaller = EDDL_AreaUsuaria.SelectedValue; // taller como ejemplo, se coloca en duro, pero eberia ser una lista desplegable asociada al servicio web oracle
            String C_FECHA = dpFechaPlanilla.Text;
            string c_aprobo = "";
            DataTable dt;

            try
            {


                ManodeObraSoapClient oMOB = new ManodeObraSoapClient();  // REFERENCIA AL SERVICIO
                dt = oMOB.BuscarAprobador(sTipoPL, sTaller, C_FECHA, inivel);
                if (dt != null)
                {

                    if (dt.Rows.Count > 0)
                    {

                        switch (inivel)
                        {
                            case 1:
                                lblAprobador1.Text = dt.Rows[0][1].ToString();   // obtenemos el usuario aprobador del nivel respectivo
                                break;
                            case 2:
                                lblAprobador2.Text = dt.Rows[0][1].ToString();   // obtenemos el usuario aprobador del nivel respectivo
                                break;
                            case 3:
                                lblAprobador3.Text = dt.Rows[0][1].ToString();   // obtenemos el usuario aprobador del nivel respectivo
                                break;
                            case 4:
                                lblAprobador4.Text = dt.Rows[0][1].ToString();   // obtenemos el usuario aprobador del nivel respectivo
                                break;
                        }





                    }
                    else
                    {
                        lblmensaje.Text = "Sin registros";
                        c_aprobo = "";

                    }


                }


            }
            catch (Exception ex)
            {

                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(1).GetMethod().Name + "/" + stack.GetFrame(0).GetMethod().Name;
                //this.LanzarException(NombreMetodo, ex);
                this.lblmensaje.Text = NombreMetodo + "<br/>" + ex.Message + " ";


            }
        }

        #endregion

        //***************** EVENTOS EN CONTROLES *************************************************************
        #region EVENTOS
        protected void btnCarga_Click(object sender, ImageClickEventArgs e)
        {
            try
            {
                prListar();
                prAprobadorxNivel(1);
                prAprobadorxNivel(2);
                prAprobadorxNivel(3);
                prAprobadorxNivel(4);
            }
            catch (Exception ex)
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(1).GetMethod().Name + "/" + stack.GetFrame(0).GetMethod().Name;
                // this.LanzarException(NombreMetodo, ex);
                lblmensaje.Text = NombreMetodo + "<br/> " + ex.Message;
            }
        }
        protected void GVplanilla_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {


                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    String S_ColorLetra = "Red", S_ColorLetra2 = "Green";
                    String S_ColorFondo = "White";

                    DataRowView drv = (DataRowView)e.Row.DataItem; // captura de los valores de la fila
                    DataRow dr = drv.Row; // pasamos los valores captrurados de la fila a un objeto fila de datos
                    String sPR = (String)dr["cod_tra"];

                    if (GVplanilla.Rows.Count > -1) // validamos que tenga registros
                    {

                        e.Row.Cells[1].Font.Bold = true;
                        e.Row.Cells[1].Font.Name = "Century Gothic";
                        e.Row.Cells[1].Font.Size = 15;
                        //---indicamos la columna afecta, este caso la 0
                        if (e.Row.Cells[1].Text == "NO")
                        {


                            if (S_ColorLetra != "")
                            { e.Row.Cells[1].ForeColor = System.Drawing.Color.FromName(S_ColorLetra); }
                            else
                            { e.Row.Cells[1].ForeColor = System.Drawing.Color.Black; }

                        }
                        else
                        {
                            if (S_ColorLetra2 != "")
                            { e.Row.Cells[1].ForeColor = System.Drawing.Color.FromName(S_ColorLetra2); }
                            else
                            { e.Row.Cells[1].ForeColor = System.Drawing.Color.Black; }
                        }

                    }



                    //------------CREAMOS CONTROLES POR CODIGO-----PARA USARLOS CON JAVASCRIPT----------------------
                    /*
                    CheckBox chk = new CheckBox();
                    chk.Checked = true;
                    chk.Attributes["onclick"] = "actualizar_autorizacion('" +  dr["cod_tra"] + "' ,1); ";  // COLOCAMOS SU EVENTO JS
                    e.Row.Cells[13].Controls.Add(chk)    ;
                    */
                    //--------------------------------------


                    //  CheckBox  CHK_CONF  = e.Row.FindControl("Chck_Conformidad"). ;  // DropDownList
                }
            }
            catch (Exception ex)
            {
                // StackTrace stack = new StackTrace();
                //  string NombreMetodo = stack.GetFrame(1).GetMethod().Name + "/" + stack.GetFrame(0).GetMethod().Name;
                //   this.LanzarException(NombreMetodo, ex);
                lblmensaje.Text = "GVplanilla_RowDataBound " + ex.Message;



            }

        }
        // Evento de los botones PRINCIPALES de la grilla
        protected void GVplanilla_EasyGridButton_Click(EasyControlWeb.EasyGridButton oEasyGridButton, Dictionary<String, String> Recodset)
        {
            try
            {

                switch (oEasyGridButton.Id)
                {
                    case "btnConformidad":
                        prDarConformidad();
                        prListar();
                        break;
                    case "btnAnularC":
                        prAnularConformidad();
                        prListar();
                        break;
                    case "btnImprimir":
                        // capturamos los valores para enviarlos  a la cabecera del reporte


                        byte[] bFirma;

                        //*************CABECERA DEL REPORTE *************************
                        // creamos el datatable
                        DataTable dtcabecera = new DataTable("Cab_Planilla");
                        // definimos las columnas
                        DataColumn col_1 = new DataColumn("cod_ceo");
                        DataColumn col_2 = new DataColumn("fec_tbj");
                        DataColumn col_3 = new DataColumn("mod_tbj");
                        DataColumn col_4 = new DataColumn("cod_div");
                        DataColumn col_5 = new DataColumn("cod_tll");

                        // insertamos las columnas a la tabla
                        dtcabecera.Columns.Add(col_1);
                        dtcabecera.Columns.Add(col_2);
                        dtcabecera.Columns.Add(col_3);
                        dtcabecera.Columns.Add(col_4);
                        dtcabecera.Columns.Add(col_5);
                        // pasamos los valores a la tabla
                        DataRow fila = dtcabecera.NewRow();
                        fila["cod_ceo"] = "1";
                        fila["fec_tbj"] = dpFechaPlanilla.Text;
                        fila["mod_tbj"] = EDDL_TipoPlanilla.SelectedValue;
                        fila["cod_div"] = EDDL_LineaNegocio.SelectedValue;
                        fila["cod_tll"] = EDDL_AreaUsuaria.SelectedValue;
                        fila["fec_tbj"] = dpFechaPlanilla.Text;
                        // insertamos los valores de la fila a la tabla
                        dtcabecera.Rows.Add(fila);

                        // guardamos en una variable sesion para pasar la tabla
                        Session["Cab_Planillas"] = dtcabecera;

                        //*******************FIRMAS***********************

                        DataTable dtfirma = new DataTable("Firma");

                        // definimos ESTRUCTURA de las columnas
                        DataColumn col_01 = new DataColumn("niv_1");
                        col_01.DataType = typeof(byte[]);
                        col_01.ReadOnly = false;
                        col_01.Unique = false;

                        DataColumn col_02 = new DataColumn("niv_2");
                        col_02.DataType = typeof(byte[]);
                        col_02.ReadOnly = false;
                        col_02.Unique = false;

                        DataColumn col_03 = new DataColumn("niv_3");
                        col_03.DataType = typeof(byte[]);
                        col_03.ReadOnly = false;
                        col_03.Unique = false;

                        DataColumn col_04 = new DataColumn("niv_4");
                        col_04.DataType = typeof(byte[]);
                        col_04.ReadOnly = false;
                        col_04.Unique = false;

                        // insertamos las columnas a la tabla
                        dtfirma.Columns.Add(col_01);
                        dtfirma.Columns.Add(col_02);
                        dtfirma.Columns.Add(col_03);
                        dtfirma.Columns.Add(col_04);

                        // pasamos los valores a la tabla
                        DataRow fila01 = dtfirma.NewRow();

                        /*
                        foreach (DataRow firma in dtfirma.Rows)
                        {
                        */

                        // TRAEMOS EL NIVEL DE CONFORMIDAD EN EL QUE SE ENCUENTRA LA PLANILLA ***
                        // Y SU DATA
                        //   string currentPage = this.Page.Request.AppRelativeCurrentExecutionFilePath;
                        //  Response.Redirect(currentPage);

                        if (lblAprobador1.Text != "")
                        {
                            fila01["niv_1"] = ConvertirFirma2(lblAprobador1.Text);
                            // validamos si existe la imagen
                            if (fila01["niv_1"] != null)
                            {
                                bFirma = (byte[])fila01["niv_1"];
                                if (bFirma.Length == 0)  // si no se obtuvo la imagen colocamos una por defecto
                                { fila01["niv_1"] = ConvertirFirma2("sin_imagen"); }   // VHERIZ
                            }
                        }

                        //------------------------------------------------
                        if (lblAprobador2.Text != "")
                        {
                            fila01["niv_2"] = ConvertirFirma2(lblAprobador2.Text);
                            // validamos si existe la imagen
                            if (fila01["niv_2"] != null)
                            {
                                bFirma = (byte[])fila01["niv_1"];
                                if (bFirma.Length == 0)  // si no se obtuvo la imagen colocamos una por defecto
                                { fila01["niv_2"] = ConvertirFirma2("sin_imagen"); }   // gsalazar
                            }

                        }

                        //------------------------------------------------
                        if (lblAprobador3.Text != "")
                        {
                            fila01["niv_3"] = ConvertirFirma2(lblAprobador3.Text);
                            // validamos si existe la imagen
                            if (fila01["niv_3"] != null)
                            {
                                bFirma = (byte[])fila01["niv_3"];
                                if (bFirma.Length == 0)  // si no se obtuvo la imagen colocamos una por defecto
                                { fila01["niv_3"] = ConvertirFirma2("sin_imagen"); }   // LDELACRUZ
                            }

                        }
                        //------------------------------------------------
                        if (lblAprobador4.Text != "")
                        {
                            fila01["niv_4"] = ConvertirFirma2(lblAprobador4.Text);
                            // validamos si existe la imagen
                            if (fila01["niv_4"] != null)
                            {
                                bFirma = (byte[])fila01["niv_4"];
                                if (bFirma.Length == 0)  // si no se obtuvo la imagen colocamos una por defecto
                                { fila01["niv_4"] = ConvertirFirma2("sin_imagen"); }   // VABREGU
                            }


                        }
                        //------------------------------------------------






                        // insertamos los valores de la fila a la tabla
                        dtfirma.Rows.Add(fila01);

                        Session["firmas"] = dtfirma;

                        // volvemos a cargar los regisros solo los aprobados
                        prListar(1);

                        myHyperLink_Click(this, EventArgs.Empty);
                        break;

                }
            }
            catch (Exception ex)
            {
                //  StackTrace stack = new StackTrace();
                //  string NombreMetodo = stack.GetFrame(1).GetMethod().Name + "/" + stack.GetFrame(0).GetMethod().Name;
                // this.LanzarException(NombreMetodo, ex);
                lblmensaje.Text = "GVplanilla_EasyGridButton_Click() " + ex.Message;

            }

        }
        //--------------------------------

        //--- Evento que  "DA CONFORMIDAD UNICA"  al empleado seleccionaldo en la  Planilla, EN UN CONTROL DENTRO DE LA GRILLA, PARA EL CONTROL CON EL COMANTDO "SELECT"
        protected void GVplanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            string msg = "entro select";
            try
            {


                // Obtén el GridView que disparó el evento
                GridView gridView = (GridView)sender;

                // Verifica si hay una fila seleccionada en el GridView
                if (gridView.SelectedIndex >= 0)
                {
                    // Obtiene la fila seleccionada del GridView
                    GridViewRow selectedRow = gridView.SelectedRow;

                    // Accede al valor de la columna deseada en la fila seleccionada
                    string sPR = selectedRow.Cells[2].Text; // Reemplaza 0 con el índice de la columna que deseas capturar

                    if (Regex.IsMatch(sPR, @"^\d+$"))
                    {



                        String strScript;
                        //  Type  csType=   Me.[GetType]()m
                        // ClientScriptManager CS = Page.ClientScript;

                        //----------script --------------------------------
                        /*
                        strScript = ("<script language='javascript'>");
                        strScript += ("  function OnEasyGridButton_Click() {pbConfirmar.Show() } ;  ");
                        strScript += ("</script>");
                        */
                        //-----------------------------------------------
                        // -----llamas a ejecutar el script—
                        // ClientScript.RegisterStartupScript(csType, "CierraPage", strScript, false)
                        //  ScriptManager.RegisterStartupScript(this, typeof(Page), "Popup", strScript, false);

                        Int64 nPR = Int64.Parse(sPR); // parseamos su cumple con valor numerico
                        Session["PR"] = nPR; // Colocamos para uso de el POPUP
                        prDarConformidad(nPR);
                        prListar();
                    }
                    else
                    {
                        string s_script = "<script>alert('¡El identificador del Empleado No es válido!');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", s_script, false);
                    }

                }
            }

            catch (Exception ex)
            {

                this.lblmensaje.Text = " GVplanilla_SelectedIndexChanged " + ex.Message + " ";
            }

        }
        //--- EVENTO que "ANULA LA CONFORMIDAD " de un CONTROL DENTRO DE LA GRILLA, PARA EL CONTROL CON EL COMANTDO "DELETE"
        protected void GVplanilla_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string msg = "entro delete";
            string sPR = "";
            Int32 ifilas = GVplanilla.Rows.Count; // capturamos el total de filas
            Int32 icol = GVplanilla.Rows.Count; // capturamos el total de columnas

            //******** METODO 01 ***********
            // Obtén el GridView que disparó el evento
            GridView gridView = (GridView)sender;
            GridViewRow selectedRow;  // instancio objeto fila de grilla

            //******** METODO 02 ***********
            // usamos el metodo de la grilla que es un control personalizado
            Dictionary<string, string> iRowSelect = GVplanilla.getDataItemSelected();
            icol = iRowSelect.Count;



            try
            {
                if (ifilas >= 1)
                {
                    selectedRow = this.GVplanilla.SelectedRow;
                    // Obtiene la fila seleccionada del GridView
                    // Accede al valor de la columna deseada en la fila seleccionada
                    if ((selectedRow is null) && (icol > 0))
                    {
                        sPR = iRowSelect["COD_TRA"].ToString(); // Reemplaza 0 con el índice de la columna que deseas capturar
                    }
                    else
                    {
                        sPR = selectedRow.Cells[2].Text; // Reemplaza 0 con el índice de la columna que deseas capturar
                    }


                }
                else
                {
                    if (gridView.SelectedIndex >= 0)
                    {
                        ifilas = gridView.Rows.Count;
                        selectedRow = gridView.SelectedRow;
                        // Obtiene la fila seleccionada del GridView
                        // Accede al valor de la columna deseada en la fila seleccionada
                        sPR = selectedRow.Cells[2].Text; // Reemplaza 0 con el índice de la columna que deseas capturar

                    }
                }

                // Verifica si hay una fila seleccionada en el GridView
                if (ifilas >= 1)
                {

                    if (Regex.IsMatch(sPR, @"^\d+$"))
                    {
                        Int64 nPR = Int64.Parse(sPR); // parseamos su cumple con valor numerico
                        prAnularConformidad(nPR);
                        prListar();
                    }
                    else
                    {
                        string s_script = "<script>alert('¡El indentificador del Empleado No es válido!');</script>";
                        ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", s_script, false);
                    }

                }

            }
            catch (Exception ex)
            {

                this.lblmensaje.Text = "GVplanilla_RowDeleting() " + ex.Message + " ";
            }

        }
        protected void myHyperLink_Click(object sender, EventArgs e)
        {
            try
            {


                // Redireccionar a otro formulario web
                //   Response.Redirect("~/Test/ReportePLL.aspx");
                // URL del formulario web que deseas abrir en una nueva pestaña
                string surl = "./ReportePLL.aspx";

                // Generar el script de JavaScript para abrir una nueva ventana o pestaña
                string _script = "window.open('" + surl + "', '_blank');";

                // Registrar el script en el lado del cliente para que se ejecute en la carga de la página
                ClientScript.RegisterStartupScript(this.GetType(), "AbrirReporte", _script, true);
            }
            catch (Exception ex)
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(1).GetMethod().Name + "/" + stack.GetFrame(0).GetMethod().Name;
                this.LanzarException(NombreMetodo, ex);
                lblmensaje.Text = "myHyperLink_Click " + ex.Message;



            }
        }

        //****************************************************************************
        // **************** Acciones en evento clic de la ventanan POPUP ************
        //****************************************************************************
        protected void pbConfirmar_Click1()
        {
            Int64 sPR = 0;
            // Acciones en evento clic de la ventanan POPUP -----------------------
            //    EasyUtilitario.Helper.Genericos.RegistraBlockScript("key", "waitingDialog.message('Subiendo');");

            //*************CONSIDERAMOS LOS FILTROS **************************************************************************
            try
            {
                c_pto = "1";
                C_filtro = (string)Session["Filtro"]; c_pto = "2";
                C_data_filtro = (string)Session["data_Filtro"]; c_pto = "3";
                C_tipo_filtro = (string)Session["tipo_Filtro"]; c_pto = "4";

                if (Session["total_Filtro"] != null)
                {
                    c_pto = "5";
                    N_Total_filtro = (int)Session["total_Filtro"];
                }

                if (C_data_filtro != null)
                {
                    c_pto = "6";
                    C_data_filtro = C_data_filtro.ToUpper().Trim();
                }
                else // No tiene filtro, recien se inicia, pero si esta aqui ya esta procesando
                {
                    c_pto = "7";
                    Session["Filtro"] = "NO";
                    C_filtro = "NO";
                }
            }
            catch (Exception ex)
            {
                C_filtro = "";
                C_data_filtro = "";
                C_tipo_filtro = "";
                N_Total_filtro = 0;

            }


            try
            {

                if (Session["PR"] != null)
                {
                    c_pto = "8";
                    sPR = (Int64)Session["PR"];
                }




                if (sPR > 0)
                {
                    c_pto = "9";
                    prDarConformidad(sPR, 1);  // se indica desde que pantalla se da el parametro para dar conformidad
                    Session["PR"] = "";  // limpiamos
                }
                else
                {
                    c_pto = "10";
                    prDarConformidad(0, 1);  // se indica desde que pantalla se da el parametro para dar conformidad
                }



                //  prListar(); // prDarConformidad Ya emplea el procedimiento prListar
            }
            catch (Exception ex)
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(1).GetMethod().Name + "/" + stack.GetFrame(0).GetMethod().Name;
                // this.LanzarException(NombreMetodo, ex);
                lblmensaje.Text = NombreMetodo + "<br> " + ex.Message + " " + c_pto;
            }
        }

        // cambio en la seleccion de registro de la linea de negocio
        protected void EDDL_LineaNegocio_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sCodLinea;
            try
            {
                sCodLinea = EDDL_LineaNegocio.SelectedValue;
                prCargaCombos(1); // solo recargamos las areas usuarias
                prIgualarNivelAprob();
            }
            catch (Exception ex)
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(1).GetMethod().Name + "/" + stack.GetFrame(0).GetMethod().Name;
                //  this.LanzarException(NombreMetodo, ex);
                lblmensaje.Text = NombreMetodo + " " + ex.Message;
            }
        }
        // *******  CAMBIO EN  EL NIVEL DE CORFORMIDAD ****
        protected void EDDL_NivelConformidad1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Int64 nIndice;
            try
            {

                EDDL_NivelConformidad1.SelectedIndex = EDDL_NivelConformidad.SelectedIndex;
                // EDDL_NivelConformidad1.Enabled = false; // bloquea el querer cambiar por que no estan autorizados
            }
            catch (Exception ex)
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(1).GetMethod().Name + "/" + stack.GetFrame(0).GetMethod().Name;
                // this.LanzarException(NombreMetodo, ex);
                lblmensaje.Text = NombreMetodo + " " + ex.Message;
            }
        }

        //---- procedimientos para el el contorl filtro
        protected void EasyGestorFiltro1_ProcessCompleted(string FiltroResultante, List<EasyFiltroItem> lstEasyFiltroItem)
        {
            try
            {

                this.LlenarGrilla(FiltroResultante);
            }
            catch (Exception ex)
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(1).GetMethod().Name + "/" + stack.GetFrame(0).GetMethod().Name;
                //   this.LanzarException(NombreMetodo, ex);

                lblmensaje.Text = NombreMetodo + " " + ex.Message;


            }
        }

        #endregion

        #region procedimientos_referenciados

        public void LlenarGrilla()
        {
            throw new NotImplementedException();
        }

        public void LlenarCombos()
        {
            throw new NotImplementedException();
        }

        public void LlenarDatos()
        {
            throw new NotImplementedException();
        }

        public void CargarModoNuevo()
        {
            throw new NotImplementedException();
        }

        public void CargarModoModificar()
        {
            throw new NotImplementedException();
        }

        public int Agregar()
        {
            throw new NotImplementedException();
        }

        public int Modificar()
        {
            throw new NotImplementedException();
        }

        public void LlenarJScript()
        {
            this.btnCarga.Attributes[EasyUtilitario.Enumerados.EventosJavaScript.onclick.ToString()] = "Espera();";
        }

        public void RegistrarJScript()
        {
            throw new NotImplementedException();
        }

        public void Imprimir()
        {
            throw new NotImplementedException();
        }

        public void Exportar()
        {
            throw new NotImplementedException();
        }

        public void ConfigurarAccesoControles()
        {
            throw new NotImplementedException();
        }

        public bool ValidarFiltros()
        {
            throw new NotImplementedException();
        }

        public bool ValidarDatos()
        {
            throw new NotImplementedException();
        }

        #endregion

    }

}


