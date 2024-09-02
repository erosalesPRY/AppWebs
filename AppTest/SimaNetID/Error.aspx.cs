﻿using EasyControlWeb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIMANET_W22R

{
    public partial class Error : PaginaBase
    {
      //  Exception LastError;
        String ErrMessage;
        public string[,] StyleBase
        {
            get
            {
                return new string[9, 2]{
                                                  { "bootstrap", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/bootstrap.min.css" }
                                                 ,{ "Autobusqueda",EasyUtilitario.Helper.Pagina.PathSite() + "/Recursos/css/jquery-ui.css"}
                                                 ,{ "bootstrap-datepicker3",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/1.4.1.bootstrap-datepicker3.css"}
                                                 ,{ "jquery-confirm.min.css",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/jquery-confirm.min.css"}
                                                 ,{ "font-awesome.min.css", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/font-awesome.min.css"}
                                                 ,{ "StyleEasy", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/StyleEasy.css"}
                                                 ,{ "EasyStyleProgressBar", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/EasyStyleProgressBar.css"}
                                                 ,{ "jqx.base", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/jqx.base.css"}
                                                 ,{ "jqx.light", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/css/jqx.light.css"}
                                                };
            }
        }
        public string[,] ScriptBase
        {
            get
            {
                return new string[16, 2]{
                                                 { "Core", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/jquery.min.js"}
                                                 ,{ "bootstrap.min",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/4.5.2.bootstrap.min.js"}
                                                 ,{ "jquery-confirm.min",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/jquery-confirm.min.js"}
                                                 ,{ "Objects", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/LibSIMA/Objetcs.js"}
                                                 ,{ "EasyConect",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/LibSIMA/EasyDataInterConect.js"}
                                                 ,{ "AccesoDatosBase", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/LibSIMA/AccesoDatosBase.js"}
                                                 ,{ "SIMA.GidView.Entended", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/LibSIMA/SIMA.GidView.Entended.js"}
                                                 ,{ "HtmlToCanvas", EasyUtilitario.Helper.Pagina.PathSite()+  "/Recursos/LibSIMA/HtmlToCanvas.js"}
                                                 ,{ "EasyControlSetting", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/LibSIMA/EasyControlSetting.js"}
                                                 ,{ "jquery-ui.min", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/jquery-ui.min.js"}
                                                 ,{ "datepicker", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/1.4.1.bootstrap-datepicker.min.js"}
                                                 ,{ "bootstrap-waitingfor", EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/bootstrap-waitingfor.js"}
                                                 ,{ "jqxcore",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/jqxcore.js"}
                                                 ,{ "jqxmenu",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/jqxmenu.js"}
                                                 ,{ "menuContext",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/Js/simple-context-menu.min.js"}
                                                 ,{ "ConstPrc",EasyUtilitario.Helper.Pagina.PathSite()+"/Recursos/LibSIMA/ConstanteProcesos.js"}
                                                };

            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            string ScriptRedirect = "";
                ScriptRedirect = @"<script>
                                            (function(){
                                                document.getElementById('LblPagina').innerText = sessionStorage.getItem('Pagina');
                                                document.getElementById('LblMetodo').innerText = sessionStorage.getItem('Metodo');
                                                document.getElementById('LblSource').innerText = sessionStorage.getItem('Origen');
                                                document.getElementById('LblDescripcion').innerText = sessionStorage.getItem('Mensaje');
                                            })();
                                 </script>";
            
            string strBE = ((System.Web.UI.Page)HttpContext.Current.Handler).Session["Error"].ToString();

            Dictionary<string, string> oEntity = EasyUtilitario.Helper.Data.SeriaizedDiccionario(strBE);

            LblPagina.InnerText = oEntity["Pagina"].ToString();
            LblMetodo.InnerText = oEntity["Metodo"].ToString();
            LblSource.InnerText = oEntity["Origen"].ToString();
            LblDescripcion.InnerText = oEntity["Mensaje"].ToString();

            Header1.RegistrarLibs(Page.Header,Controles.Header.TipoLib.Style, this.StyleBase, true);
            Header1.RegistrarLibs(Page.Header, Controles.Header.TipoLib.Script, this.ScriptBase, true);


            ((System.Web.UI.Page)System.Web.HttpContext.Current.Handler).RegisterStartupScript("Error2021", ScriptRedirect + strBE);
        }

    }
}