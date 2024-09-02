<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProbarControl.aspx.cs" Inherits="SIMANET_W22R.Test.ProbarControl" %>


<%@ Register assembly="EasyControlWeb" namespace="EasyControlWeb.Form.Controls" tagprefix="cc1" %>
<%@ Register assembly="EasyControlWeb" namespace="EasyControlWeb.Filtro" tagprefix="cc2" %>
<%@ Register Src="~/Controles/Header.ascx" TagPrefix="uc1" TagName="Header" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
 
       
    <link rel="stylesheet" href="https://netdna.bootstrapcdn.com/bootstrap/4.0.0-beta/css/bootstrap.min.css">

    <!--<script  src="https://ajax.googleapis.com/ajax/libs/jquery/1.12.4/jquery.min.js"></script>-->

    <script src="../Recursos/Js/jquery.min.js"></script>
    <script src="../Recursos/LibSIMA/Objetcs.js"></script>
    <script src="../Recursos/LibSIMA/AccesoDatosBase.js"></script>
  
   
         <link href="http://code.jquery.com/ui/1.10.4/themes/ui-lightness/jquery-ui.css" rel="stylesheet"> 
    <!--     <script src="http://ajax.googleapis.com/ajax/libs/jqueryui/1.8/jquery-ui.min.js" type = "text/javascript"></script>-->
    <script src="../Recursos/Js/jquery-ui.min.js"></script>

      <script>




          function onItemSeleccionado(value, ItemBE) {
              alert(value);
          }

          function PersonalizaIems(ul, item) {
              var cmll = "\"";

              var iTemplate = '<a href="#" class="list-group-item list-group-item-action d-flex justify-content-between align-items-center">'
                  + '<div class= "flex-column">' + item.Nombre
                  + '    <p><small>' + item.Email + ' ess</small></p>'
                  + '    <span class="badge badge-info badge-pill"> ' + item.Edad + ' Edad</span>'
                  + '</div>'
                  + '<div class="image-parent">'
                  + '<img src="..." class="img-fluid" alt="quixote">'
                  + '</div>'
                  + '</a>';

              iTemplate = '<a href="#" class="list-group-item list-group-item-action d-flex justify-content-between align-items-center">'
                      + '<div class= "flex-column">' + item.Nombre
                      + '    <p><small>' + item.Email + ' ess</small></p>'
                      + '    <span class="badge badge-info badge-pill"> ' + item.Edad + ' Edad</span>'
                      + '</div>'
                      + '<div class="image-parent">'
                      + '<img class=" rounded-circle" width="60px" src="https://s3.eu-central-1.amazonaws.com/bootstrapbaymisc/blog/24_days_bootstrap/robert.jpg" alt="Bologna">'
                      + '</div>'
                      + '</a>';

              var oCustomTemplateBE = new EasyAutocompletar1.CustomTemplateBE(ul, item, iTemplate);
              return EasyAutocompletar1.SetCustomTemplate(oCustomTemplateBE);


          }
      </script>


</head>
<body>
    <form id="form1" runat="server">
        <table>
            <tr>
                <td>
                  
                </td>
            </tr>
            <tr>
                <td>
                  <cc1:EasyAutocompletar ID="EasyAutocompletar1" runat="server"  DisplayText="Nombre" ValueField="Edad" fnOnSelected="onItemSeleccionado" fncTempaleCustom="PersonalizaIems" >
                           <DataInterconect MetodoConexion="PaginaASPX">
                               <UrlWebService>/GestiondeCalidad/Proceso.aspx</UrlWebService>
                               <UrlWebServicieParams>
                                   <cc2:EasyFiltroParamURLws  ParamName="IdPrc" Paramvalue="99" ObtenerValor="Fijo" />
                               </UrlWebServicieParams>
                           </DataInterconect>
                       </cc1:EasyAutocompletar>
                </td>
            </tr>

        </table>
       
      
    </form>
</body>
</html>
