<%@ Page Language="C#" AutoEventWireup="true" Async="true" 
    CodeBehind="Planilla_Conformidad.aspx.cs"
   Inherits="SIMANET_W22R.ManodeObra.Planilla_Conformidad"  %>

<!-- ************ REFERENCIAS A LOS CONTROLES ************* -->
<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Form.Controls" TagPrefix="cc3" %>
<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Filtro" TagPrefix="cc2" %>
<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb" TagPrefix="cc1" %>
<%@ Register Src="~/Controles/Header.ascx" TagPrefix="uc1" TagName="Header" %>

<!DOCTYPE html>
<!--  Para cambiar icono de botones elegir de la siguiente pagina: https://fontawesome.com/v4/icons/ -->
<!-- ************ Para pobrar ingresar la url: http://localhost/SIMANET_W22R/TEST/Planilla_Oracle_unisys.aspx ************* -->
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
    <style type="text/css">
        .auto-style1 {
            height: 191px;
        }


        .auto-style2 {
            height: 29px;
        }


        .auto-style3 {
            height: 57px;
        }


    </style>


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
            SIMA.Utilitario.Helper.Wait('Planilla', 1000, function () { });
        }

    </script>


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
              <td>

                </td>
            </tr>
         <!-- ******cuerpo**************************************************** -->
            <tr>
                <td> 
                
                      <table class="w-100" border="0"  >
                        <tr>
                            <td  width="15%">
                                <asp:Label ID="Label1" runat="server" Text="Línea de Negocio:" CssClass="form-control sin_borde" 
                                    BorderWidth="0px" Width="100%"></asp:Label>
                            </td>
                            <td class="auto-style2" colspan="2" >
                                <cc3:EasyDropdownList ID="EDDL_LineaNegocio" runat="server" Width="30%" 
                                    OnSelectedIndexChanged="EDDL_LineaNegocio_SelectedIndexChanged"
                                    EnableOnChange="True"  
                                    autocomplete="on" CssClass="form-control" Requerido="False" AutoPostBack="True">
                                </cc3:EasyDropdownList>
                               
                            </td>
                         <!--   *******fila espacio*************************  -->                           
                        </tr>
                        <tr>
                            <td >&nbsp;</td>
                            <td colspan="2">    &nbsp;</td>
                        </tr>
                        <!--   ************class="auto-style2"********************  -->                            
                        <tr>
                            <td width="15%" >
                                <asp:Label ID="Label2" runat="server" Text="Área Usuaria:" CssClass="form-control sin_borde"
                                    BorderWidth="0px" Width="100%"></asp:Label>
                            </td>
                            <td colspan="2">
                               <cc3:EasyDropdownList ID="EDDL_AreaUsuaria" runat="server" Width="30%">
                                </cc3:EasyDropdownList>
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
                                <asp:Label ID="Label3" runat="server" Text="Tipo de Planilla:" CssClass="form-control sin_borde" 
                                     BorderWidth="0px" Width="100%"></asp:Label>
                            </td>
                            <td colspan="2">
                                   <cc3:EasyDropdownList ID="EDDL_TipoPlanilla" runat="server" Width="30%">
                                </cc3:EasyDropdownList>
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
                            <td width="15%" class="auto-style3">
                                <asp:Label ID="Label4" runat="server" Text="Fecha Planilla:" CssClass="form-control"
                                     BorderWidth="0px" Width="100%"></asp:Label>
                            </td>
                           <td width="20%">
                               
                                <cc3:EasyDatepicker ID="dpFechaPlanilla" runat="server" autocomplete="off" CssClass="form-control"
                                     data-validate="true" EnableOnChange="False" Etiqueta="Fecha Inspección" FormatoFecha="dd/mm/yyyy"
                                      Hoy="" Placeholder="Seleccione fecha Planilla" Requerido="True" Width="100%"
                                         MensajeValida="Fecha de Planilla">                                    
                                    <EasyStyle Ancho="Dos"></EasyStyle>                                    
                               </cc3:EasyDatepicker>    <!--  fncSelectDate="FechaInspeccion_onSelect" -->
                            </td>
                            <td>
                                <asp:ImageButton ID="btnCarga" runat="server" ImageAlign="Middle"  
                                    ImageUrl="~/Recursos/img/buscar.png" OnClick="btnCarga_Click" Width="50px" Height="30px"  />
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
                           <td width="15%">
                           <!--  ruta del reporte  NavigateUrl="~/Test/ReportePLL.aspx" --> 
                               <asp:HyperLink ID="HPL_imprimir" runat="server"  OnClick="myHyperLink_Click"></asp:HyperLink>
                               
                           </td>
                           <td colspan="2"> 
                              <!--  -->
                          <br/>
             
                             <asp:Label ID="lblmensaje" runat="server" Text="" BorderWidth="0px"
                                 CssClass="form-control" Width ="30%" ></asp:Label>
     
                           </td>
                       </tr>
                     <!--   ********************************  -->   
                         <tr>
                            <td  width="15%">   
                                <asp:Label ID="Label6" runat="server" Text="NIVEL DE APROBACIÓN:" CssClass="form-control sin_borde"
                                     BorderWidth="0px" Width="100%" Visible ="true" ></asp:Label></td>
                           <td colspan="2">
                                  <cc3:EasyDropdownList ID="EDDL_NivelConformidad" runat="server" Width="30%" 
                                                         Visible ="true"   >
                                </cc3:EasyDropdownList>
 
                            </td>
                        </tr>  
                               <tr>
                            <td  width="15%">   
                                <asp:Label ID="lblAprobador1" runat="server"  CssClass="form-control sin_borde"
                                           BorderWidth="0px" Width="100%" Visible ="false" ></asp:Label>
                                <asp:Label ID="lblAprobador2" runat="server"  CssClass="form-control sin_borde"
                                           BorderWidth="0px" Width="100%" Visible ="false" ></asp:Label>
                                <asp:Label ID="lblAprobador3" runat="server"  CssClass="form-control sin_borde"
                                           BorderWidth="0px" Width="100%" Visible ="false" ></asp:Label>
                                <asp:Label ID="lblAprobador4" runat="server"  CssClass="form-control sin_borde"
                                           BorderWidth="0px" Width="100%" Visible ="false" ></asp:Label>
                                  <asp:Label ID="LblNivelUser" runat="server"  CssClass="form-control sin_borde"
                                           BorderWidth="0px" Width="100%" Visible ="false" ></asp:Label>
                            </td>

                           <td colspan="2">
                            </td> 
                        </tr>
                      </table>
                </td>
                 <td>

                </td>
            </tr> 
           <!--   **********FILA GRILLAS**********************  -->   
            <tr>
                <td style="width:100%; height:100%" colspan="2">
               <!-- ******grilla**************************************************** -->
                 <!--  eventos de la grilla:  OnEasyGridButton_Click: para botones en la parte superior
                                              OnRowDeleting y OnSelectedIndexChanged para botones en la FILA
                        los iconos de los botones se cargar el nombre de acuerdo al arhivo css: awesome:
                               https://fontawesome.com/v4/icons/
                     -->
                    <cc1:EasyGridView ID="GVplanilla" runat="server" AutoGenerateColumns="False" ShowFooter="True" 
                    TituloHeader="Conformidad Planilla Mano de obra"  
                    ToolBarButtonClick  ="OnEasyGridButton_Click" 
                    Width ="100%" 
                    AllowPaging="True"
                    OnRowDataBound="GVplanilla_RowDataBound" 
                    OnEasyGridButton_Click="GVplanilla_EasyGridButton_Click" 
                    OnRowDeleting ="GVplanilla_RowDeleting" OnSelectedIndexChanged="GVplanilla_SelectedIndexChanged"
                    
                    >
             
               
               <HeaderStyle CssClass="HeaderGrilla" />
                          <PagerStyle HorizontalAlign="Center" />
                          <RowStyle CssClass="ItemGrilla" Height="25px" />
                       
               
                <EasyGridButtons>  
               
                   <cc1:EasyGridButton ID="btnConformidad" Descripcion="" Icono="fa fa-thumbs-o-up" 
                       MsgConfirm="" RunAtServer="false" 
                        Texto="Dar Conformidad a todos"    Ubicacion="Izquierda" />
                    <cc1:EasyGridButton ID="btnAnularC" Descripcion="" Icono="fa fa-undo"
                         MsgConfirm  ="Desea Anular la Conformidad de toda la planilla visualizada" RequiereSelecciondeReg="false" SolicitaConfirmar="true" RunAtServer="True" 
                          Texto="Anular Conformidad a todos"    Ubicacion="centro" />
                     <cc1:EasyGridButton ID="btnImprimir" Descripcion="" Icono="fa fa-print" 
                         MsgConfirm="" RequiereSelecciondeReg="false" SolicitaConfirmar="false" RunAtServer="True" 
                        Texto="Imprimir Planilla"    Ubicacion="Centro" />
              </EasyGridButtons>
             
               <EasyStyleBtn ClassName="btn btn-primary" FontSize="1em" TextColor="white" />
              <EasyExtended ItemColorMouseMove="#CDE6F7" ItemColorSeleccionado="#ffcc66"
               RowItemClick="" idgestorfiltro="EasyGestorFiltro1"></EasyExtended>
              <EasyRowGroup GroupedDepth="0" ColIniRowMerge="0"></EasyRowGroup>
              <AlternatingRowStyle CssClass="AlternateItemGrilla" />
                      
               <Columns>
                 <asp:BoundField DataField="CONFORM" HeaderText="CONFORMI." SortExpression="Conformidad" >
                    <ItemStyle HorizontalAlign="Left" />
                 </asp:BoundField>
                 <asp:BoundField DataField="cod_tra" HeaderText="P. R." SortExpression="Porta Retrato" >
                    <ItemStyle HorizontalAlign="Left" />
                 </asp:BoundField>
                  <asp:BoundField DataField="nombre" HeaderText="TRABAJADOR" SortExpression="trabajador" >
                    <ItemStyle HorizontalAlign="Left" />
                 </asp:BoundField>
                   <asp:BoundField DataField="Especialidad_t" HeaderText="ESPECIALIDAD TRAB." SortExpression="Especialidad del colaborador" >
                    <ItemStyle HorizontalAlign="Left" />
                 </asp:BoundField>
                 <asp:BoundField DataField="ot" HeaderText="O.T." SortExpression="Orden de trabajo" >
                    <ItemStyle HorizontalAlign="Left" />
                 </asp:BoundField>
            
                <asp:BoundField DataField="atv_crv" HeaderText="ACTIVIDAD" SortExpression="Actividad" >
                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                </asp:BoundField>

                <asp:BoundField DataField="COD_ESPE_REQUE" HeaderText="COD. ESPEC. REQUERIDA" SortExpression="Código Especialidad requerida" >
                   <ItemStyle HorizontalAlign="Left" />
                </asp:BoundField>
                <asp:BoundField DataField="Especialidad_requerida" HeaderText="ESPECIALIDAD REQUERIDA" SortExpression="Especialidad requerida" >
                   <ItemStyle HorizontalAlign="Left" />
                 </asp:BoundField>
                 <asp:BoundField DataField="modalidad" HeaderText="MODALIDAD" SortExpression="Modalidad de incentivo o sobretiempo" >
                    <ItemStyle HorizontalAlign="Left" />
                 </asp:BoundField>
                 <asp:BoundField DataField="CNT_HR" HeaderText="HRS" SortExpression="Cantidad de horas laboradas" >
                    <ItemStyle HorizontalAlign="Left" />
                 </asp:BoundField>
                <asp:BoundField DataField="UNIDAD" HeaderText="CLIENTE" SortExpression="Unidad a que se realiza el trabajo" >
                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="true" />
                </asp:BoundField>
                <asp:BoundField DataField="PROYECTO" HeaderText="PROYECTO" SortExpression="Proyecto en el que se ejecuta la OT" >
                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="true" />
                </asp:BoundField>
                 <asp:BoundField DataField="DET_LAB" HeaderText="DESCRIPCIÓN TRABAJO" SortExpression="Descripción de Actividad" >
                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="POR_AVA" HeaderText="% AVANCE" SortExpression="Descripción de Actividad" >
                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                </asp:BoundField>

                 <asp:TemplateField HeaderText="ACCIÓN">
 
                          <ItemTemplate>
                                <asp:ImageButton ID="BtSI"  runat="server" ToolTip="Conformidad" CommandName= "Select" 
                                    ImageUrl ="~/Recursos/img/ok_sky_blue_x32.png" 
                                    onClientClick="fnPopup();"  
                                    visible =   '<%# (Eval("CONFORM").ToString() =="NO"?true:false)    %>'
                                    />
                                <asp:ImageButton ID="BtnNO" runat="server" ToolTip="Anular Conformidad" CommandName ="Delete" 
                                    ImageUrl ="~/Recursos/img/anular_undo_sky_bluex32.png" 
                                    onClientClick="javascript:if(!confirm('Esta seguro retirar dar conformidad al empleado?') ) { return false; } else { Espera(); }  ;"  
                                    visible =   '<%# (Eval("CONFORM").ToString() !="NO"?true:false)       %>'
                                    />

                            
                           </ItemTemplate>

                 </asp:TemplateField>
              </Columns>
              </cc1:EasyGridView>


              </td>
            </tr>
         <!-- ********************************************************** --->   
           <tr>
                <td>
                     <cc3:EasyMessageBox ID="MsgBox" runat="server" />
                </td>
                <td>

                </td>
            </tr>
        </table>
        <!-- ****************fin tabla****************************************** --->
         <cc3:EasyPopupBase ID="pbConfirmar" runat="server" DisplayButtons="true" OnClick="pbConfirmar_Click1" RunatServer ="true"  Titulo ="Nivel de Conformidad">
                <table id="pp">
                  <tr>
                            <td  width="15%">   <asp:Label ID="Label5" runat="server" Text="Nivel Conformidad:" 
                                  BorderWidth="0px" CssClass="form-control" Width="100%"></asp:Label></td>
                           <td colspan="2">
                                  <cc3:EasyDropdownList ID="EDDL_NivelConformidad1" runat="server" 
                                                        Width="30%"  AutoPostBack="True"  OnSelectedIndexChanged="EDDL_NivelConformidad1_SelectedIndexChanged"  >
                                </cc3:EasyDropdownList>
 
                            </td>
                        </tr>  
             </table>

             </cc3:EasyPopupBase>      
        
        
            <cc2:EasyGestorFiltro ID="EasyGestorFiltro1" runat="server" EasyFiltroCampos-Capacity="4"
                            OnProcessCompleted ="EasyGestorFiltro1_ProcessCompleted">
                
                 <cc2:EasyFiltroCampo Descripcion="Código Trabajador" Nombre="cod_tra" TipodeDato="Int">
                        <EasyControlAsociado NroDecimales="0" TemplateType="EasyITemplateNumericBox" />
                    </cc2:EasyFiltroCampo>
                   
                   <cc2:EasyFiltroCampo Descripcion="Orden de Trabajo" Nombre="ot" TipodeDato= "String" >
                       <EasyControlAsociado TemplateType="EasyITemplateTextBox"></EasyControlAsociado>
                  </cc2:EasyFiltroCampo>

                 <cc2:EasyFiltroCampo Descripcion="Proyecto" Nombre="Proyecto" TipodeDato="String">
                     <EasyControlAsociado TemplateType="EasyITemplateTextBox" />
                 </cc2:EasyFiltroCampo>

             </cc2:EasyGestorFiltro>
    </form>
</body>

</html>
