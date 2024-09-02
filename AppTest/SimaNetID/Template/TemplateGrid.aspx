<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TemplateGrid.aspx.cs" Inherits="SIMANET_W22R.Template.TemplateGrid" %>



<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Form.Controls" TagPrefix="cc3" %>

<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Filtro" TagPrefix="cc2" %>

<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb" TagPrefix="cc1" %>

<%@ Register Src="~/Controles/Header.ascx" TagPrefix="uc1" TagName="Header" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
      <!-- **************** inicio tabla contenido de la pagina****************************************** --->
        <table style="width:100%;  border="0">
        <!-- **************************cabecera******************************** --->
         <tr>
                <td>
                    <uc1:Header runat="server" ID="Header" IdGestorFiltro="EasyGestorFiltro1" /> 

                </td>
            </tr>
         <!-- ******cuerpo**************************************************** -->
            <tr>
                <td style="width:100%; height:100%">
               <!-- ******grilla**************************************************** -->
           <cc1:EasyGridView ID="EasyGridView1" runat="server" AutoGenerateColumns="False" ShowFooter="True" 
                    TituloHeader="Gestion de Calidad" ToolBarButtonClick="OnEasyGridButton_Click" Width="100%" 
                    AllowPaging="True" OnRowDataBound="EasyGridView1_RowDataBound"
                    OnEasyGridDetalle_Click="EasyGridView1_EasyGridDetalle_Click" 
                    OnPageIndexChanged="EasyGridView1_PageIndexChanged" 
                    OnEasyGridButton_Click="EasyGridView1_EasyGridButton_Click">
            
                <EasyGridButtons>  
               
                   <cc1:EasyGridButton ID="btnAgregar" Descripcion="" Icono="fa fa-plus-square-o" MsgConfirm="" RunAtServer="True" Texto="Agregar" 
                       Ubicacion="Derecha" />
                    <cc1:EasyGridButton ID="btnEliminar" Descripcion="" Icono="fa fa-undo" MsgConfirm="Desea Eliminar este registro" RequiereSelecciondeReg="true" SolicitaConfirmar="true" RunAtServer="True" Texto="Eliminar" 
                        Ubicacion="Derecha" />
                    <cc1:EasyGridButton ID="btnAgregarInspec" Descripcion="" Icono="fa fa-plus-square-o" MsgConfirm="" RequiereSelecciondeReg="true"  RunAtServer="False" Texto="Inspector" 
                        Ubicacion="Centro" />
                    <cc1:EasyGridButton ID="btnInspecPartcicipa" Descripcion="" Icono="fa fa-plus-square-o" MsgConfirm="" RequiereSelecciondeReg="True" RunAtServer="False" SolicitaConfirmar="False" Texto="Inpector Participante" 
                        Ubicacion="Centro" />
                    <cc1:EasyGridButton ID="btnResponsableArea" Descripcion="" Icono="fa fa-plus-square-o" MsgConfirm="" RequiereSelecciondeReg="true" RunAtServer="False" SolicitaConfirmar="False" Texto="Responsable" 
                        Ubicacion="Centro" />
              </EasyGridButtons>
             
               <EasyStyleBtn ClassName="btn btn-primary" FontSize="1em" TextColor="white" />
              <EasyExtended ItemColorMouseMove="#CDE6F7" ItemColorSeleccionado="#ffcc66"
               RowItemClick="" idgestorfiltro="EasyGestorFiltro1"></EasyExtended>
              <EasyRowGroup GroupedDepth="0" ColIniRowMerge="0"></EasyRowGroup>
              <AlternatingRowStyle CssClass="AlternateItemGrilla" />
                      
               <Columns>
                  <asp:BoundField DataField="NroReporte" HeaderText="N° REPORTE" />
                  <asp:BoundField DataField="Fecha" HeaderText="FECHA DE INSPECCION" SortExpression="Fecha" DataFormatString="{0:dd/MM/yyyy}" >
                    <ItemStyle HorizontalAlign="Center" Width="4%" />
                  </asp:BoundField>
                  <asp:BoundField DataField="TipoInspeccion" HeaderText="TIPO DE INSPECCION" SortExpression="TipoInspeccion" >
                    <ItemStyle HorizontalAlign="Left" />
                 </asp:BoundField>
                 <asp:BoundField DataField="NombreProyecto" HeaderText="PROYECTO / CLIENTE" SortExpression="NombreProyecto" >
                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" Wrap="False" />
                </asp:BoundField>
                <asp:BoundField DataField="Descripcion" HeaderText="DESCRIPCION" >
                   <ItemStyle HorizontalAlign="Left" VerticalAlign="Middle" Width="30%" />
                </asp:BoundField>
                <asp:BoundField HeaderText="INSPECTORES/PARTICIPANTES" />
                <asp:BoundField HeaderText="PERSONAL ENCARGADO" />
                <asp:BoundField DataField="TipoProceso" HeaderText="PROCESO CONTRUCTIVO" SortExpression="TipoProceso" >
                   <ItemStyle HorizontalAlign="Left" />
                 </asp:BoundField>
                 <asp:BoundField DataField="TipoSIstema" HeaderText="SISTEMA /  MODULO  /ZONA /PRUEBAS" SortExpression="TipoSIstema" >
                    <ItemStyle HorizontalAlign="Left" />
                 </asp:BoundField>
              </Columns>
                 
                          <HeaderStyle CssClass="HeaderGrilla" />
                          <PagerStyle HorizontalAlign="Center" />
                          <RowStyle CssClass="ItemGrilla" Height="25px" />
                       
              </cc1:EasyGridView>
              </td>
            </tr>
         <!-- ********************************************************** --->   
           <tr>
                <td>

                    <cc1:EasyGridView ID="EasyGridView2" runat="server">
                          <HeaderStyle CssClass="HeaderGrilla" />
                          <PagerStyle HorizontalAlign="Center" />
                          <RowStyle CssClass="ItemGrilla" Height="25px" />


                    </cc1:EasyGridView>
                </td>
            </tr>
        </table>
        <!-- ****************fin tabla****************************************** --->
    </form>
</body>
</html>
