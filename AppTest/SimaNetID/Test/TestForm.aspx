<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestForm.aspx.cs" Inherits="SIMANET_W22R.Test.TestForm" %>

<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Form" TagPrefix="cc3" %>
<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Form.Controls" TagPrefix="cc1" %>
<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Filtro" TagPrefix="cc2" %>

<%@ Register Src="~/Controles/Header.ascx" TagPrefix="uc1" TagName="Header" %>



<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

    

    <script>
        //Evento para El control Autocmpletar    
        function onItemSeleccionado(value, ItemBE) {
            
        }

        function onDisplayTemplatePersonal(ul, item) {
            var cmll = "\""; var iTemplate = null;
                iTemplate = '<a href="#" class="list-group-item list-group-item-action d-flex justify-content-between align-items-center">'
                    + '<div class= "flex-column">' + item.ApellidosyNombres
                    + '    <p><small style="font-weight: bold">Nro PR:</small> <small style ="color:red">' + item.NroPersonal + '</small>'
                    + '    <small style="font-weight: bold">AREA:</small><small style="color:blue;text-transform: capitalize;">' + item.NombreArea + '</small></p>'
                    + '    <span class="badge badge-info "> ' + item.Email + '</span>'
                    + '</div>'
                    + '<div class="image-parent">'
                    + '</div>'
                    + '</a>';

            var oCustomTemplateBE = new EasyListAutocompletar1.CustomTemplateBE(ul, item, iTemplate);

            return EasyListAutocompletar1.SetCustomTemplate(oCustomTemplateBE);


        }
        function onClickItemList(oIemBE) {
            //var vCode = document.getElementById("vCode");

            //alert(oIemBE.IdPersonal);
            alert(EasyForm1_lstfind.GetListValue());
        }

        function ItemplateCustom(oItemBE) {
            alert();
            return "eddy jose";
        }
        /*
        forms step: https://www.hitechparks.com/web/product/form-wizard-multi-step-form-validation/classic/Format-1/employee.html

        */
    </script>
</head>
<body>
   
    <form id="form1" runat="server">
        <table style="width:100%">
            <tr>
                <td>
                    <uc1:Header runat="server" ID="Header" />
                </td>
            </tr>
            <tr>
                <td>
                    <cc3:EasyForm ID="EasyForm1" runat="server">
<Cabecera Titulo="" Descripcion="" Snippetby=""></Cabecera>
                        <Secciones>
                            <cc3:EasyFormSeccion Titulo="demo">
                                <ItemsCtrl>
                                    <cc1:EasyListAutocompletar ID="lstfind" runat="server"   EnableOnChange="False" Etiqueta="demo" fncLstItemOnClick="onClickItemList" fncLstItemOnDelete="" fncTempaleCustom="" fncTempaleCustomItemList="" fnOnClick=""  LstValueField="" MensajeValida="no ingreso" Placeholder="demo" Requerido="False" NroCarIni="2"  DisplayText="ApellidosyNombres" ValueField="IdPersonal" CssClass="ContentLisItem" ClassItem="LstItem" >
                                        <EasyStyle Ancho="Once"  TipoTalla="md"/>
                                        <DataInterconect MetodoConexion="WebServiceInterno">
                                           <UrlWebService>/RecursosHumanos/Personal.asmx</UrlWebService>
                                           <Metodo>BuscarPersona</Metodo>
                                           <UrlWebServicieParams>
                                               <cc2:EasyFiltroParamURLws  ParamName="PSima" Paramvalue="1" ObtenerValor="Fijo" TipodeDato="Int"/>
                                               <cc2:EasyFiltroParamURLws  ParamName="UserName" Paramvalue="UserName" ObtenerValor="Session" />
                                           </UrlWebServicieParams>
                                       </DataInterconect>
                                    </cc1:EasyListAutocompletar>
                                </ItemsCtrl>
                            </cc3:EasyFormSeccion>
                        </Secciones>
                    </cc3:EasyForm></td>
            </tr>
            <tr>
                <td>
                   
                </td>
            </tr>

        </table>


      



        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Button" />


      



    </form>

</body>
</html>
