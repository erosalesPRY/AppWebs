﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Actividades_OT.aspx.cs" Inherits="SIMANET_W22R.GestionProduccion.OT.Actividades_OT" %>


<!-- ************ REFERENCIAS A LOS CONTROLES ************* -->
<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Form" TagPrefix="cc5" %>
<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Form.Controls" TagPrefix="cc3" %>
<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Filtro" TagPrefix="cc2" %>
<%@ Register Src="~/Controles/Header.ascx" TagPrefix="uc1" TagName="Header" %>

<!-- <%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb" TagPrefix="cc1" %> -->
<!-- <%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Form.Base" TagPrefix="cc4" %> -->

<!-- ******************************************************************* -->
<!-- ************ REFERENCIAS A ESTILOS ************* -->
<link rel="stylesheet" type="text/css" href="<%= ResolveUrl("~/Recursos/css/StyleEasy.css") %> ">

<!DOCTYPE html>


<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title>Actividades de Ordenes de Trabajo</title>
        <script>
        function actualizar_autorizacion(idtrabajador, estado) {
            alert(idtrabajador);
        }

        function OnEasyGridButton_Click(btn, data) {
            // alert();
            pbConfirmar.Show();
        }

        function fnPopup() {

            pbConfirmar.Show();
        }

        function Espera() {
            SIMA.Utilitario.Helper.Wait('Actividades', 1000, function () { });
        }

        </script>
    <style type="text/css">
        .auto-style1 {
            height: 26px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
       <!-- **************** inicio tabla contenido de la pagina****************************************** --->
        <table style="width:100%";  border="0">
         <!-- **************************cabecera******************************** --->
         <tr>
                <td class="auto-style1">
                    <uc1:Header runat="server" ID="Header" IdGestorFiltro="EasyGestorFiltro1" /> 
                </td>
                <td>   </td>
          </tr>
         <!-- ******  cuerpo CON EASY FROM **************************************************** -->
        <tr>
            <td colspan ="3" >
                <center>
                      <h1 class="display-6">ACTIVIDADES DE OT</h1>
                      <p class="lead mb-0">Modificación de Actividades de Orden de Trabajo</p>
                      <p class="font-italic"></p>
                </center>
            </td> 
        </tr>  
            <!-- ******cuerpo**************************************************** -->
         <tr>
         <td> 
         
               <table class="w-100" border="0"  >
                  <!--   *******fila espacio*************************  -->                           
                 <tr>
                     <td colspan="2" >  <h2> FILTROS DE BÚSQUEDA</h2> </td>
                 </tr> 
                 <tr>
                     <td colspan="3">&nbsp;</td>
                  </tr>
                 <!--   ************class="auto-style2"********************  -->                            
                 <tr>
                     <td width="15%" >
                         <asp:Label ID="Label2" runat="server" Text="N° de Orden de Trabajo:" CssClass="form-control sin_borde"
                             BorderWidth="0px" Width="100%"></asp:Label>
                     </td>
                     <td colspan="2">
                       <cc3:EasyNumericBox ID="enbOTs" runat="server" CssClass="form-control" NroDecimales="0" STYLE="width:90px" EnableOnChange="True" 
                           Requerido="True" MensajeValida="Este dato es obligatorio" Etiqueta="N° OT">
                         <EasyStyle Ancho="Dos" TipoTalla="xs"></EasyStyle>
                     </cc3:EasyNumericBox>
                     </td>
                 </tr>
               <!--   *******fila espacio*************************  -->    
                 <tr>
                     <td >&nbsp;</td>
                     <td colspan="2">
                         &nbsp;</td>
                 </tr>
               <!--   ********************************  -->       
                  <tr>
                    <td  width="15%">
                        <asp:Label ID="Label1" runat="server" Text="Línea de Negocio:" CssClass="form-control sin_borde" 
                            BorderWidth="0px" Width="100%"></asp:Label>
                    </td>
                    <td class="auto-style2" colspan="2" >
                          <cc3:EasyDropdownList ID="EDDL_LineaNegocio" runat="server" Width="34%" 
                           OnSelectedIndexChanged="EDDL_LineaNegocio_SelectedIndexChanged" 
                           OnTextChanged="EDDL_LineaNegocio_SelectedIndexChanged"
                           EnableOnChange="True"  
                           autocomplete="on" CssClass="form-control" Requerido="True" AutoPostBack="True" MensajeValida="Este dato es obligatorio" Etiqueta="Línea Negocio">
                       </cc3:EasyDropdownList>
       
                    </td>
                </tr>
                <!--   *******fila espacio*************************  -->                           
               
                 <tr>
                     <td >&nbsp;</td>
                     <td colspan="2">    &nbsp;</td>
                 </tr>

                 <tr>
                     <td  width="15%" class="auto-style1">
                         <asp:Label ID="Label3" runat="server" Text="Actividad:" CssClass="form-control sin_borde" 
                              BorderWidth="0px" Width="100%"></asp:Label>
                     </td>
                     <td  class="auto-style1" width="25%"  >
                          <cc3:EasyDropdownList ID="EDDL_Actividad" runat="server" Width="90%" MensajeValida="Este dato es obligatorio" Requerido="True" Etiqueta="Actividades">
                          </cc3:EasyDropdownList>
                        
                     </td>
                     <td >
                         <asp:ImageButton ID="btnCarga" runat="server" ImageAlign="Middle" ToolTip ="Listas Actividades"  
                            ImageUrl="~/Recursos/img/buscar.png" OnClick="btnCarga_Click" Width="50px" Height="30px"  />
                          <asp:Panel ID="pnlMessage" runat="server"></asp:Panel>
                     </td>
                 </tr>
              <!--   *******fila espacio*************************  -->    
                 <tr>
                     <td >&nbsp;</td>
                     <td colspan="2">
                         &nbsp;</td>
                 </tr>
                  <!--   ********************************  -->     
                  <tr>
                     <td colspan="2" >  <h2> DATOS DE ACTUALIZACIÓN</h2> </td>
                 </tr>  
                      <!--   ********************************  -->    
                   <tr>
                      <td colspan="2"  > 
                         <!--  -->
 
                        <asp:Label ID="lblmensaje" runat="server" Text="" BorderWidth="0px"
                            CssClass="form-control alert-warning" Width ="100%" ></asp:Label>
     
                      </td>
                       <td >&nbsp;</td>
                  </tr>
       
                 <tr>
                     <td width="15%" class="auto-style3">
                         <asp:Label ID="Label4" runat="server" Text="Usuario Solicitante Cambio:" CssClass="form-control"
                              BorderWidth="0px" Width="100%"></asp:Label>
                     </td>
                    <td width="28%" >
                          <cc3:EasyAutocompletar ID="EAC_usuarios" runat="server" Width="35%" DisplayText="V_DESCRIPCION" ValueField="CODIGO" 
                              fnOnSelected="Actividades_OT.onEasyFind_Selected" 
                              fncTempaleCustom="Actividades_OT.onDisplayTemplateUsuUNIX" 
                              MensajeValida="Este dato es obligatorio" EnableOnChange="True" Etiqueta="Usuario Solicita">
                        <EasyStyle Ancho="Dos" TipoTalla="sm"></EasyStyle>
                        <DataInterconect MetodoConexion="WebServiceInterno">
                            <UrlWebService>/General/TablasGenerales.asmx</UrlWebService>
                            <Metodo>ListaU</Metodo>
                              <UrlWebServicieParams>
                                  <cc2:EasyFiltroParamURLws ObtenerValor="Session" ParamName="UserName" Paramvalue="UserName" TipodeDato="String" />
                            </UrlWebServicieParams>
                              </DataInterconect>
                          </cc3:EasyAutocompletar>
 

                     </td>
                     <td >&nbsp;</td>
                 </tr>
                <!--   *******fila espacio*************************  -->    
                 <tr>
                     <td colspan="3"  >&nbsp;</td>
                
                 </tr>
                 <!--   *******fila espacio*************************  -->    
                <tr>
                    <td >&nbsp;</td>
                </tr>

                <!--   ********************************  -->   
              <!--   ********************************  -->   
                  <tr>
                     <td  width="15%">   
                         <asp:Label ID="Label6" runat="server" Text="DESCRIPCIÓN A ACTUALIZAR:" CssClass="form-control sin_borde"
                              BorderWidth="0px" Width="100%" Visible ="true" ></asp:Label></td>
                        <td colspan="2">
                            <cc3:EasyTextBox ID="ETdescripcion" runat="server" Width="32%"
                                
                                MensajeValida="Este dato es obligatorio" 
                                Requerido="True"
                                TextMode="MultiLine" Font-Size="Large" MaxLength="2000" Etiqueta="Descripcion Actividad"></cc3:EasyTextBox>

                            
                     </td>
                 </tr>  
                 <!--   *******fila espacio*************************  -->    
                <tr>
                    <td >&nbsp;</td>
                </tr>

                   <tr>
                     <td  width="15%">   
                      
                     </td>

                    <td colspan="2">
                        <asp:Button ID="btnActualizar" runat="server" Text="Aceptar"  CssClass="button-celeste" 
                            onClientClick="javascript:if(!confirm('Esta seguro Actualizar la Descripción de la Actividad?') ) { return false; } else { Espera(); }  ;"  
                            OnClick="btnActualizar_Click" />
                     </td> 
                 </tr>
               <!--   *******fila espacio*************************  -->    
                <tr>
                    <td >&nbsp;</td>
                </tr>

               </table>
         </td>
          <td>

         </td>
     </tr> 
     
        </table>
       <!-- ****************fin tabla****************************************** --->
    </form>
       <!-- **************** BLOQUE DE PROCEDIMIENTO Y FUNCIONES JAVASCRIPT ****************************************** --->
    <script>
        // para usar esta funcion: <cc2:EasyFiltroParamURLws ObtenerValor="FunctionScript" ParamName="v_ambiente" Paramvalue="Actividades_OT.ObteberAmbiente" TipodeDato="String"></cc2:EasyFiltroParamURLws>
        Actividades_OT.ObtenerAmbiente = function () {
            return IMA.Utilitario.Helper.Configuracion.Leer("Seguridad", "Ambiente");
        }

        Actividades_OT.onEasyFind_Selected = function (value, ItemBE) {
           
        }
        Actividades_OT.onDisplayTemplateUsuUNIX = function (ul, item) {
            var cmll = "\"";
            iTemplate = '<a href="#" class="list-group-item list-group-item-action d-flex justify-content-between align-items-center">'
                + '         <div class= "flex-column">' + item.V_DESCRIPCION
                + '             <p><small style="font-weight: bold">User:</small> <small style ="color:red">' + item.CODIGO + '</small><br>'
            //    + '             <img class=" rounded-circle" width="60px" src="' + Actividades_OT.PathFotosPersonal + item.NroDocIdentidad + '.jpg" alt="Usuario:=' + item.V_DESCRIPCION + '"  onerror="this.onerror=null;this.src=SIMA.Utilitario.Constantes.ImgDataURL.ImgSF;">'
                + '         </div>'
                + '</a>';
            var oCustomTemplateBE = new EAC_usuarios.CustomTemplateBE(ul, item, iTemplate);
            return EAC_usuarios.SetCustomTemplate(oCustomTemplateBE);
        }

       


    </script>
</body>
</html>
