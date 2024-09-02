<%@ Page Language="C#" AutoEventWireup="true"  Async="true" 
    CodeBehind="Planilla_Conformidad.aspx.cs" 
    Inherits="SIMANET_W22R.Test.Planilla_Conformidad" %> 

<!-- ************ REFERENCIAS A LOS CONTROLES ************* -->
<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Form.Controls" TagPrefix="cc3" %>
<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Filtro" TagPrefix="cc2" %>
<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb" TagPrefix="cc1" %>
<%@ Register Src="~/Controles/Header.ascx" TagPrefix="uc1" TagName="Header" %>
<!DOCTYPE html>

<!-- ************ Para pobrar ingresar la url: http://localhost/SIMANET_W22R/TEST/Planilla_Oracle_unisys.aspx ************* -->
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
    
    <style type="text/css">
        .auto-style1 {
            height: 191px;
        }


    </style>

    <script>
        function actualizar_autorizacion(idtrabajador, estado) {
            alert(idtrabajador);
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
            </tr>
         <!-- ******cuerpo**************************************************** -->
            <tr>
                <td> 
                
                      <table class="w-100" >
                        <tr>
                            <td class="auto-style2">Línea de Negocio:</td>
                            <td>
                                <cc3:EasyDropdownList ID="EDDL_LineaNegocio" runat="server" Width="30%">
                                </cc3:EasyDropdownList>
                               
                            </td>
                           
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Área Usuaria:</td>
                            <td>
                               <cc3:EasyDropdownList ID="EDDL_AreaUsuaria" runat="server" Width="30%">
                                </cc3:EasyDropdownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td class="auto-style2">Tipo de Planilla:</td>
                            <td>
                                   <cc3:EasyDropdownList ID="EDDL_TipoPlanilla" runat="server" Width="30%">
                                </cc3:EasyDropdownList>
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                            <td>
                                &nbsp;</td>
                        </tr>
                        
                        <tr>
                            <td class="auto-style2">Fecha Planilla:</td>
                           <td>
                               <br/>
                                <cc3:EasyDatepicker ID="dpFechaPlanilla" runat="server" autocomplete="off" CssClass="form-control"
                                     data-validate="true" EnableOnChange="False" Etiqueta="Fecha Inspección" FormatoFecha="dd/mm/yyyy"
                         Hoy="" Placeholder="Seleccione fecha Planilla" Requerido="True" Width="30%"
                        MensajeValida="Fecha de inspección obligatoria">                                    
                                    <EasyStyle Ancho="Dos"></EasyStyle>                                    
                       </cc3:EasyDatepicker>    <!--  fncSelectDate="FechaInspeccion_onSelect" -->
 
                            </td>
                        </tr>
                        <tr>
                            <td class="auto-style2">&nbsp;</td>
                           <td>
                                &nbsp;</td>
                        </tr>
                       <tr>
                           <td></td>
                           <td> 
                              <!--  -->
                          <br/>
             
                            <asp:ImageButton ID="btnCarga" runat="server" ImageAlign="Middle" ImageUrl="~/Recursos/img/web-button.png" OnClick="btnCarga_Click" Width="50px" />
                             <asp:Label ID="lblmensaje" runat="server" Text="mensaje"></asp:Label>
     
                           </td>
                       </tr>
                             
                      </table>
                </td>
            </tr> 
                       <tr>
                            <td class="auto-style2">Nivel Conformidad:
                           
                                  <cc3:EasyDropdownList ID="EDDL_NivelConformidad" runat="server" Width="30%">
                                </cc3:EasyDropdownList>
                            <td> 
                            </td>
                        </tr>
            <tr>
                <td style="width:100%; height:100%">
               <!-- ******grilla**************************************************** -->
              <cc1:EasyGridView ID="GVplanilla" runat="server" AutoGenerateColumns="False" ShowFooter="True" 
                    TituloHeader="Conformidad Planilla Mano de obra"  
                    ToolBarButtonClick  ="OnEasyGridButton_Click" 
                    Width ="100%" 
                    AllowPaging="True"
                    OnRowDataBound="GVplanilla_RowDataBound" 
                    OnEasyGridButton_Click="GVplanilla_EasyGridButton_Click" OnRowDeleting="GVplanilla_RowDeleting" OnSelectedIndexChanged="GVplanilla_SelectedIndexChanged"
                
                    >
             
               
               <HeaderStyle CssClass="HeaderGrilla" />
                          <PagerStyle HorizontalAlign="Center" />
                          <RowStyle CssClass="ItemGrilla" Height="25px" />
                       
                <EasyGridButtons>  
               
                   <cc1:EasyGridButton ID="btnConformidad" Descripcion="" Icono="fa fa-plus-square-o" MsgConfirm="" RunAtServer="True" 
                        Texto="Dar Conformidad a todos"    Ubicacion="Derecha" />
                    <cc1:EasyGridButton ID="btnAnularC" Descripcion="" Icono="fa fa-undo"
                         MsgConfirm  ="Desea Anular la Conformidad de toda la planilla" RequiereSelecciondeReg="false" SolicitaConfirmar="true" RunAtServer="True" 
                          Texto="Anular Conformidad a todos"    Ubicacion="Derecha" />
                     <cc1:EasyGridButton ID="btnImprimir" Descripcion="" Icono="fa fa-undo"  RequiereSelecciondeReg="false" SolicitaConfirmar="true" RunAtServer="True" 
                        Texto="Imprimir Planilla"    Ubicacion="Derecha" />
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
                   <asp:BoundField DataField="Especialidad_t" HeaderText="ESPECIALIDAD" SortExpression="Especialidad del colaborador" >
                    <ItemStyle HorizontalAlign="Left" />
                 </asp:BoundField>
                 <asp:BoundField DataField="ot" HeaderText="O.T." SortExpression="Orden de trabajo" >
                    <ItemStyle HorizontalAlign="Left" />
                 </asp:BoundField>
                 <asp:BoundField DataField="trabajo" HeaderText="TRABAJO GENERAL" SortExpression="Trabajo programado" >
                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="TRUE" />
                </asp:BoundField>
                <asp:BoundField DataField="atv_crv" HeaderText="ACTIVIDAD" SortExpression="Actividad" >
                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Wrap="false" />
                </asp:BoundField>
                 <asp:BoundField DataField="DET_LAB" HeaderText="DESCRIPCIÓN" SortExpression="Descripción de Actividad" >
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
                   <asp:TemplateField>
                     
                   </asp:TemplateField>
                   
                   <asp:TemplateField HeaderText="Conf." >
 
                          <ItemTemplate>
                                <asp:ImageButton ID="BtSI" runat="server" ToolTip="Conformidad" CommandName= "Select" ImageUrl ="~/Recursos/img/ok_green_x32.png" 
                                    onClientClick="javascript:if(!confirm('Esta seguro de dar conformidad al empleado?') ) { return false; };"  
                                    visible =   '<%# (Eval("CONFORM").ToString() =="NO"?true:false)       %>'
                                    />
                                <asp:ImageButton ID="BtnNO" runat="server" ToolTip="Anular Conformidad" CommandName ="Delete" ImageUrl ="~/Recursos/img/anular_undo_red_x32.png" 
                                    onClientClick="javascript:if(!confirm('Esta seguro retirar dar conformidad al empleado?') ) { return false; };"  
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

                </td>
            </tr>
        </table>
        <!-- ****************fin tabla****************************************** --->

    </form>
</body>
</html>
