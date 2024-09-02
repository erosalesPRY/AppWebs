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
////using Microsoft.Reporting.WebForms;
using System.Text.RegularExpressions;

namespace SIMANET_W22R.Test
{

    public partial class Planilla_Oracle_unisys : System.Web.UI.Page
    {
        String sServicio = "http://10.10.90.168:7060/xml_oracle/xml_api.";

        //  produccion:   String sServicio = "http://10.10.90.138:7060/xml_oracle/xml_api.";
        //  desarrollo:   String sServicio = "http://10.10.90.168:7060/xml_oracle/xml_api.";

        String sParametros = "", url ="";

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                prCargaCombos();
            }
            
        }

        protected async void btnCarga_Click(object sender, ImageClickEventArgs e)
        {
            prListar();
          
        }
      
        protected void GVplanilla_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            if (e.Row.RowType == DataControlRowType.DataRow)
            {
                DataRowView drv = (DataRowView)e.Row.DataItem; // captura de los valores de la fila
                DataRow dr = drv.Row; // pasamos los valores captrurados de la fila a un objeto fila de datos
                String sPR = (String)dr["cod_tra"];
                //------------CREAMOS CONTROLES POR CODIGO-----PARA USARLOS CON JAVASCRIPT----------------------
                CheckBox chk = new CheckBox();
                chk.Checked = true;
                chk.Attributes["onclick"] = "actualizar_autorizacion('" +  dr["cod_tra"] + "' ,1); ";  // COLOCAMOS SU EVENTO JS
                e.Row.Cells[13].Controls.Add(chk)    ;
                //--------------------------------------


              //  CheckBox  CHK_CONF  = e.Row.FindControl("Chck_Conformidad"). ;  // DropDownList
            }
        }

        // Evento de los botones PRINCIPALES de la grilla
        protected void GVplanilla_EasyGridButton_Click(EasyControlWeb.EasyGridButton oEasyGridButton, Dictionary<String, String> Recodset)
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
            }
        }

        //--- Evento que  "DA CONFORMIDAD UNICA"  al empleado seleccionaldo en la  Planilla, EN UN CONTROL DENTRO DE LA GRILLA, PARA EL CONTROL CON EL COMANTDO "SELECT"
        protected void GVplanilla_SelectedIndexChanged(object sender, EventArgs e)
        {
            string msg = "entro select";
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
                    Int64 nPR = Int64.Parse(sPR); // parseamos su cumple con valor numerico
                    prDarConformidad(nPR);
                    prListar();
                }
                else
                {
                    string s_script = "<script>alert('¡El indentificador del Empleado No es válido!');</script>";
                    ScriptManager.RegisterStartupScript(this, typeof(Page), "Alerta", s_script, false);
                }
                
            }

            
            
        }
        //--- EVENTO DE CONTROL DENTRO DE LA GRILLA, PARA EL CONTROL CON EL COMANTDO "DELETE"
        protected void GVplanilla_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            string msg = "entro delete";
        }

        protected void btnImprimirPla_Click(object sender, EventArgs e)
        {

        }

        // **********SECCIÓN DE PROCEDIMIENTOS Y FUNCIONES ************************************************************************
        // Llena datos iniciales
        protected async void prCargaCombos()
        {

            Int64 contador = 0;
            Int64 n_opcion;
            String sParametros = "";
            // credenciales, Estos valores se deberian encriptar con con un algoritmo y guardado en un archivo txt
            string susername = "integracion_jde";
            string spassword = "integracion_jde";

            // Llamada al servicio REST, el ip es del servicio de producción oracle JDE
            String sMetodo = "get_planilla?"; // En este metodo esta expuesta toda la información necesaria


            // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************
            n_opcion = 3; // LineaNegocio
            sParametros = "n_opcion=" + n_opcion;

            try
            {
                using (var servicio_web = new HttpClient())
                {


                    // Autentificación 
                    servicio_web.DefaultRequestHeaders.Authorization =
                      new AuthenticationHeaderValue("Basic",
                      Convert.ToBase64String(Encoding.ASCII.GetBytes(susername + ":" + spassword)));


                    var resultado = await servicio_web.GetAsync(sServicio + sMetodo + sParametros);
                    string get_contenido = await resultado.Content.ReadAsStringAsync();

                    // Aquí va el código para procesar el resultado obtenido

                    // Analizar la respuesta y cargar el XML
                    XmlDocument Mi_xml = new XmlDocument();
                    Mi_xml.LoadXml(get_contenido);

                    // Obtener los nodos que contienen los datos que necesita
                    XmlNodeList datos_XML = Mi_xml.SelectNodes("//LineaNegocio"); // se coloca el nombre de nodo que es la tabla/vista


                    // ***** colocar los datos en una grilla************
                    DataSet conjunto_dx = new DataSet();
                    conjunto_dx.ReadXml(new XmlNodeReader(Mi_xml)); // leemos el   XmlNodeList  = datos_XML.CreateNavigator().ReadSubtree()



                    EDDL_LineaNegocio.DataSource = conjunto_dx.Tables[0];  // nombre_de_la_tabla  ["planilla"]
                    EDDL_LineaNegocio.DataTextField = "etiqueta"; // NOM_AUS
                    EDDL_LineaNegocio.DataValueField = "COD_DIV";
                    EDDL_LineaNegocio.DataBind();




                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("fallo:", ex.Message);
                this.lblmensaje.Text = ex.Message + " ";
            }

            //*********************************************************
            n_opcion = 1; // AreaUsuaria
            sParametros = "n_opcion=" + n_opcion;

            try
            {
                using (var servicio_web = new HttpClient())
                {


                    // Autentificación 
                    servicio_web.DefaultRequestHeaders.Authorization =
                      new AuthenticationHeaderValue("Basic",
                      Convert.ToBase64String(Encoding.ASCII.GetBytes(susername + ":" + spassword)));


                    var resultado = await servicio_web.GetAsync(sServicio + sMetodo + sParametros);
                    string get_contenido = await resultado.Content.ReadAsStringAsync();

                    // Aquí va el código para procesar el resultado obtenido

                    // Analizar la respuesta y cargar el XML
                    XmlDocument Mi_xml = new XmlDocument();
                    Mi_xml.LoadXml(get_contenido);

                    // Obtener los nodos que contienen los datos que necesita
                    XmlNodeList datos_XML = Mi_xml.SelectNodes("//AreaUsuaria"); // se coloca el nombre de nodo que es la tabla/vista


                    // ***** colocar los datos en una grilla************
                    DataSet conjunto_dx = new DataSet();
                    conjunto_dx.ReadXml(new XmlNodeReader(Mi_xml)); // leemos el   XmlNodeList  = datos_XML.CreateNavigator().ReadSubtree()



                    EDDL_AreaUsuaria.DataSource = conjunto_dx.Tables[0];  // nombre_de_la_tabla  ["planilla"]
                    EDDL_AreaUsuaria.DataTextField = "etiqueta"; // NOM_AUS
                    EDDL_AreaUsuaria.DataValueField = "COD_AUS";
                    EDDL_AreaUsuaria.DataBind();




                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("fallo:", ex.Message);
                this.lblmensaje.Text = ex.Message + " ";
            }
            //*********************************************************
            n_opcion = 2; // TipoPlanilla
            sParametros = "n_opcion=" + n_opcion;

            try
            {
                using (var servicio_web = new HttpClient())
                {


                    // Autentificación 
                    servicio_web.DefaultRequestHeaders.Authorization =
                      new AuthenticationHeaderValue("Basic",
                      Convert.ToBase64String(Encoding.ASCII.GetBytes(susername + ":" + spassword)));


                    var resultado = await servicio_web.GetAsync(sServicio + sMetodo + sParametros);
                    string get_contenido = await resultado.Content.ReadAsStringAsync();

                    // Aquí va el código para procesar el resultado obtenido

                    // Analizar la respuesta y cargar el XML
                    XmlDocument Mi_xml = new XmlDocument();
                    Mi_xml.LoadXml(get_contenido);

                    // Obtener los nodos que contienen los datos que necesita
                    XmlNodeList datos_XML = Mi_xml.SelectNodes("//TipoPlanilla"); // se coloca el nombre de nodo que es la tabla/vista


                    // ***** colocar los datos en una grilla************
                    DataSet conjunto_dx = new DataSet();
                    conjunto_dx.ReadXml(new XmlNodeReader(Mi_xml)); // leemos el   XmlNodeList  = datos_XML.CreateNavigator().ReadSubtree()



                    EDDL_TipoPlanilla.DataSource = conjunto_dx.Tables[0];  // nombre_de_la_tabla  ["TipoPlanilla"]
                    EDDL_TipoPlanilla.DataTextField = "etiqueta"; // NOM_AUS
                    EDDL_TipoPlanilla.DataValueField = "COD_TIP_PLL";
                    EDDL_TipoPlanilla.DataBind();




                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("fallo:", ex.Message);
                this.lblmensaje.Text = ex.Message + " ";
            }

            //*********************************************************
            n_opcion = 4; // TipoConformidad
            sParametros = "n_opcion=" + n_opcion;

            try
            {
                using (var servicio_web = new HttpClient())
                {


                    // Autentificación 
                    servicio_web.DefaultRequestHeaders.Authorization =
                      new AuthenticationHeaderValue("Basic",
                      Convert.ToBase64String(Encoding.ASCII.GetBytes(susername + ":" + spassword)));


                    var resultado = await servicio_web.GetAsync(sServicio + sMetodo + sParametros);
                    string get_contenido = await resultado.Content.ReadAsStringAsync();

                    // Aquí va el código para procesar el resultado obtenido

                    // Analizar la respuesta y cargar el XML
                    XmlDocument Mi_xml = new XmlDocument();
                    Mi_xml.LoadXml(get_contenido);

                    // Obtener los nodos que contienen los datos que necesita
                    XmlNodeList datos_XML = Mi_xml.SelectNodes("//TipoConformidad"); // se coloca el nombre de nodo que es la tabla/vista


                    // ***** colocar los datos en una grilla************
                    DataSet conjunto_dx = new DataSet();
                    conjunto_dx.ReadXml(new XmlNodeReader(Mi_xml)); // leemos el   XmlNodeList  = datos_XML.CreateNavigator().ReadSubtree()



                    EDDL_NivelConformidad.DataSource = conjunto_dx.Tables[0];  // nombre_de_la_tabla  ["TipoConformidad"]
                    EDDL_NivelConformidad.DataTextField = "etiqueta"; // + " " + "CONFORMIDAD"
                    EDDL_NivelConformidad.DataValueField = "TIPO";
                    EDDL_NivelConformidad.DataBind();




                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("fallo:", ex.Message);
                this.lblmensaje.Text = ex.Message + " ";
            }



        }
       
        // da conformidad General
        protected async void prDarConformidad(Int64 N_PR = 0)
        {

            Int64 contador = 0;
            Int64 n_opcion;

            // credenciales, Estos valores se deberian encriptar con con un algoritmo y guardado en un archivo txt
            string susername = "integracion_jde";
            string spassword = "integracion_jde";

            // Llamada al servicio REST, el ip es del servicio de producción oracle JDE
            String sMetodo = "post_planilla?"; // En este metodo se envia información a la bd mediante el servicio

            // ***** PARAMETROS **************
            String sTipoPL = EDDL_TipoPlanilla.SelectedValue; // TIPO DE PLANILLA (se esta capturando de un txt pero deberia ser una lista desplegable asociada al servicio web oracle
            String sTaller = EDDL_AreaUsuaria.SelectedValue; // taller como ejemplo, se coloca en duro, pero eberia ser una lista desplegable asociada al servicio web oracle
            String sLinea = EDDL_LineaNegocio.SelectedValue;
            String sNivelC = EDDL_NivelConformidad.SelectedValue;
            String C_FECHA = dpFechaPlanilla.Text;
            n_opcion = 1;
            // ******* validacion de datos de variables*************
            if (sTipoPL == null)
            { sTipoPL = "inc"; }

            // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************
            sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + C_FECHA + "&c_linea=" + sLinea + "&C_conformidad=" + sNivelC + "&n_opcion=" + n_opcion + "&n_pr=" + N_PR;


            try
            {
                using (var servicio_web = new HttpClient())
                {


                    // Autentificación 
                    servicio_web.DefaultRequestHeaders.Authorization =
                      new AuthenticationHeaderValue("Basic",
                      Convert.ToBase64String(Encoding.ASCII.GetBytes(susername + ":" + spassword)));

                    url = sServicio + sMetodo;
                    HttpContent contenido = new StringContent(sParametros, Encoding.UTF8, "text/plain"); ;

                    //var respuesta = await servicio_web.PostAsync(url, contenido);

                    HttpResponseMessage resultado = await servicio_web.PostAsync(url, contenido);

                    if (resultado.IsSuccessStatusCode)
                    {
                        // Aquí va el código para procesar el resultado obtenido
                        string get_contenido = await resultado.Content.ReadAsStringAsync();

                        // Analizar la respuesta y cargar el XML
                        XmlDocument Mi_xml = new XmlDocument();
                        Mi_xml.LoadXml(get_contenido);

                        // Obtener los nodos que contienen los datos que necesita
                        XmlNodeList datos_XML = Mi_xml.SelectNodes("//Conformidad"); // se coloca el nombre de nodo que es la tabla/vista


                        // ***** colocar los datos en una grilla************
                        DataSet conjunto_dx = new DataSet();
                        conjunto_dx.ReadXml(new XmlNodeReader(Mi_xml)); // leemos el   XmlNodeList  = datos_XML.CreateNavigator().ReadSubtree()

                        // contamos los registos
                        contador = conjunto_dx.Tables[0].Rows.Count;
                        lblmensaje.Text = " Total de registros afectados   " + contador;

                    }
                    else
                    {
                        lblmensaje.Text = " No se pudo enviar información! " + resultado.IsSuccessStatusCode;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("fallo:", ex.Message);
                this.lblmensaje.Text = ex.Message + " ";
            }





        }
        
        // Anular conformidad General
        protected async void prAnularConformidad(Int64 N_PR = 0)
        {

            Int64 contador = 0;
            Int64 n_opcion;

            // credenciales, Estos valores se deberian encriptar con con un algoritmo y guardado en un archivo txt
            string susername = "integracion_jde";
            string spassword = "integracion_jde";

            // Llamada al servicio REST, el ip es del servicio de producción oracle JDE
            String sMetodo = "post_planilla?"; // En este metodo se envia información a la bd mediante el servicio

            // ***** PARAMETROS **************
            String sTipoPL = EDDL_TipoPlanilla.SelectedValue; // TIPO DE PLANILLA (se esta capturando de un txt pero deberia ser una lista desplegable asociada al servicio web oracle
            String sTaller = EDDL_AreaUsuaria.SelectedValue; // taller como ejemplo, se coloca en duro, pero eberia ser una lista desplegable asociada al servicio web oracle
            String sLinea = EDDL_LineaNegocio.SelectedValue;
            String sNivelC = EDDL_NivelConformidad.SelectedValue;
            String C_FECHA = dpFechaPlanilla.Text;

            n_opcion = -1; // anula conformidad
                           // ******* validacion de datos de variables*************
            if (sTipoPL == null)
            { sTipoPL = "inc"; }

            // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************
            sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + sTaller + "&d_fecha=" + C_FECHA + "&c_linea=" + sLinea + "&n_opcion=" + n_opcion + "&n_pr=" + N_PR;




            try
            {
                using (var servicio_web = new HttpClient())
                {


                    // Autentificación 
                    servicio_web.DefaultRequestHeaders.Authorization =
                      new AuthenticationHeaderValue("Basic",
                      Convert.ToBase64String(Encoding.ASCII.GetBytes(susername + ":" + spassword)));

                    url = sServicio + sMetodo;
                    HttpContent contenido = new StringContent(sParametros, Encoding.UTF8, "text/plain"); ;

                    //var respuesta = await servicio_web.PostAsync(url, contenido);

                    HttpResponseMessage resultado = await servicio_web.PostAsync(url, contenido);

                    if (resultado.IsSuccessStatusCode)
                    {
                        // Aquí va el código para procesar el resultado obtenido
                        string get_contenido = await resultado.Content.ReadAsStringAsync();

                        // Analizar la respuesta y cargar el XML
                        XmlDocument Mi_xml = new XmlDocument();
                        Mi_xml.LoadXml(get_contenido);

                        // Obtener los nodos que contienen los datos que necesita
                        XmlNodeList datos_XML = Mi_xml.SelectNodes("//Conformidad"); // se coloca el nombre de nodo que es la tabla/vista


                        // ***** colocar los datos en una grilla************
                        DataSet conjunto_dx = new DataSet();
                        conjunto_dx.ReadXml(new XmlNodeReader(Mi_xml)); // leemos el   XmlNodeList  = datos_XML.CreateNavigator().ReadSubtree()

                        // contamos los registos
                        contador = conjunto_dx.Tables[0].Rows.Count;
                        lblmensaje.Text = " Total de registros afectados   " + contador;

                    }
                    else
                    {
                        lblmensaje.Text = " No se pudo enviar información! " + resultado.IsSuccessStatusCode;
                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("fallo:", ex.Message);
                this.lblmensaje.Text = ex.Message + " ";
            }





        }

        protected async void prListar()
        {
            // carga(this);

            Int64 contador = 0;

            // credenciales, Estos valores se deberian encriptar con con un algoritmo y guardado en un archivo txt
            string susername = "integracion_jde";
            string spassword = "integracion_jde";

            // Llamada al servicio REST, el ip es del servicio de producción oracle JDE

            String sMetodo = "get_planilla?"; // En este metodo esta expuesta toda la información necesaria

            // captura de valores ingresados por los usarios desde los controles
            String sTipoPL = EDDL_TipoPlanilla.SelectedValue; // TIPO DE PLANILLA (se esta capturando de un txt pero deberia ser una lista desplegable asociada al servicio web oracle
            String cTaller = EDDL_AreaUsuaria.SelectedValue; // taller como ejemplo, se coloca en duro, pero eberia ser una lista desplegable asociada al servicio web oracle
            String C_FECHA = dpFechaPlanilla.Text;

            //  DateTime fechacalendario = cfecha.SelectedDate;   // cfecha.SelectedDate; (date)dpFechaPlanilla.Text
            //  String C_FECHA = fechacalendario.ToString("dd/MM/yyyy"); // FECHA PLANILLA, se esta colocando una fecha inicial en duro, pero tambien se puede usar este control calendario el cual debe cambiarse con un control personalizado


            // ******* validacion de datos de variables*************
            if (sTipoPL == null)
            { sTipoPL = "inc"; }

            // **************Parametros de consulta, de acuerdo a los valores enviados retornará un tipo de información **************
            String sParametros = "c_mod=" + sTipoPL + "&c_tll_ini=" + cTaller + "&d_fecha=" + C_FECHA;

            try
            {
                using (var servicio_web = new HttpClient())
                {


                    // Autentificación 
                    servicio_web.DefaultRequestHeaders.Authorization =
                      new AuthenticationHeaderValue("Basic",
                      Convert.ToBase64String(Encoding.ASCII.GetBytes(susername + ":" + spassword)));


                    var resultado = await servicio_web.GetAsync(sServicio + sMetodo + sParametros);
                    string get_contenido = await resultado.Content.ReadAsStringAsync();

                    // Aquí va el código para procesar el resultado obtenido

                    // Analizar la respuesta y cargar el XML
                    XmlDocument Mi_xml = new XmlDocument();
                    Mi_xml.LoadXml(get_contenido);

                    // Obtener los nodos que contienen los datos que necesita
                    XmlNodeList datos_XML = Mi_xml.SelectNodes("//Planilla"); // se coloca el nombre de nodo que es la tabla/vista


                    // ***** colocar los datos en una grilla************
                    DataSet conjunto_dx = new DataSet();
                    conjunto_dx.ReadXml(new XmlNodeReader(Mi_xml)); // leemos el   XmlNodeList  = datos_XML.CreateNavigator().ReadSubtree()

                    // contamos los registos
                    contador = conjunto_dx.Tables[0].Rows.Count;
                    lblmensaje.Text = " Total de registros =  " + contador;
                    Session["Planillas"] = conjunto_dx.Tables[0];
                    GVplanilla.DataSource = conjunto_dx.Tables[0];  // nombre_de_la_tabla  ["planilla"]
                    GVplanilla.DataBind();

                }
            }
            catch (Exception ex)
            {
             //   Console.WriteLine("fallo:", ex.Message);
                this.lblmensaje.Text = ex.Message + " ";
            }
        }

    }
}



