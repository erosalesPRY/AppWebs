﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EasyNetLiveChatFind.aspx.cs" Inherits="SIMANET_W22R.HelpDesk.ChatBox.EasyNetLiveChatFind" %>

<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Form.Controls" TagPrefix="cc3" %>
<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb" TagPrefix="cc1" %>
<%@ Register assembly="EasyControlWeb" namespace="EasyControlWeb.Filtro" tagprefix="cc2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div class="header">
         <div class="logo">
             <svg viewBox="0 0 513 513" fill="currentColor" xmlns="http://www.w3.org/2000/svg">
             <path d="M256.025.05C117.67-2.678 3.184 107.038.025 245.383a240.703 240.703 0 0085.333 182.613v73.387c0 5.891 4.776 10.667 10.667 10.667a10.67 10.67 0 005.653-1.621l59.456-37.141a264.142 264.142 0 0094.891 17.429c138.355 2.728 252.841-106.988 256-245.333C508.866 107.038 394.38-2.678 256.025.05z" />
             <path d="M330.518 131.099l-213.825 130.08c-7.387 4.494-5.74 15.711 2.656 17.97l72.009 19.374a9.88 9.88 0 007.703-1.094l32.882-20.003-10.113 37.136a9.88 9.88 0 001.083 7.704l38.561 63.826c4.488 7.427 15.726 5.936 18.003-2.425l65.764-241.49c2.337-8.582-7.092-15.72-14.723-11.078zM266.44 356.177l-24.415-40.411 15.544-57.074c2.336-8.581-7.093-15.719-14.723-11.078l-50.536 30.744-45.592-12.266L319.616 160.91 266.44 356.177z" fill="#fff" /></svg>
         </div>
        <div  class="search-bar">
             <cc3:EasyAutocompletar ID="EasyAcFindAprobador" runat="server" NroCarIni="1"  DisplayText="ApellidosyNombres" ValueField="IdPersonal" fnOnSelected="EasyNetLiveChatFind.OnItemSelected" fncTempaleCustom="EasyNetLiveChatFind.ItemplateAprobador">
                 <EasyStyle Ancho="Dos"></EasyStyle>
                 <DataInterconect MetodoConexion="WebServiceInterno">
                      <UrlWebService>/GestiondeCalidad/Proceso.asmx</UrlWebService>
                      <Metodo>BuscarAprobadores</Metodo>
                      <UrlWebServicieParams>
                          <cc2:EasyFiltroParamURLws  ParamName="UserName" Paramvalue="UserName" ObtenerValor="Session" />
                      </UrlWebServicieParams>
                  </DataInterconect>
             </cc3:EasyAutocompletar>   
         </div>
         <div class="user-settings">
             <div class="dark-light">
                 <svg viewBox="0 0 24 24" stroke="currentColor" stroke-width="1.5" fill="none" stroke-linecap="round" stroke-linejoin="round">
                     <path d="M21 12.79A9 9 0 1111.21 3 7 7 0 0021 12.79z" />
                 </svg>
             </div>
             <div class="settings">
                 <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round">
                     <circle cx="12" cy="12" r="3" />
                     <path d="M19.4 15a1.65 1.65 0 00.33 1.82l.06.06a2 2 0 010 2.83 2 2 0 01-2.83 0l-.06-.06a1.65 1.65 0 00-1.82-.33 1.65 1.65 0 00-1 1.51V21a2 2 0 01-2 2 2 2 0 01-2-2v-.09A1.65 1.65 0 009 19.4a1.65 1.65 0 00-1.82.33l-.06.06a2 2 0 01-2.83 0 2 2 0 010-2.83l.06-.06a1.65 1.65 0 00.33-1.82 1.65 1.65 0 00-1.51-1H3a2 2 0 01-2-2 2 2 0 012-2h.09A1.65 1.65 0 004.6 9a1.65 1.65 0 00-.33-1.82l-.06-.06a2 2 0 010-2.83 2 2 0 012.83 0l.06.06a1.65 1.65 0 001.82.33H9a1.65 1.65 0 001-1.51V3a2 2 0 012-2 2 2 0 012 2v.09a1.65 1.65 0 001 1.51 1.65 1.65 0 001.82-.33l.06-.06a2 2 0 012.83 0 2 2 0 010 2.83l-.06.06a1.65 1.65 0 00-.33 1.82V9a1.65 1.65 0 001.51 1H21a2 2 0 012 2 2 2 0 01-2 2h-.09a1.65 1.65 0 00-1.51 1z" />
                 </svg>
             </div>
         </div>
     </div>
    </form>
</body>
     <script>
   
         EasyNetLiveChatFind.ItemplateAprobador = function (ul, item) {
         var cmll = "\""; var iTemplate = null;
         var ImgFirma = item.Firma;
         var ItemUser = '<table style="width:100%">'
             + ' <tr>'
             + '     <td rowspan="3" align="center" style="width:5%"><img class=" rounded-circle" width = "60px" src = "' + EasyNetLiveChatFind.PathFotosPersonal + item.NroDocIdentidad + '.jpg"  onerror = "this.onerror=null;this.src=SIMA.Utilitario.Constantes.ImgDataURL.ImgSF;"></td>'
             + '     <td class="Etiqueta" style="font-size: 14px;width:75%">' + item.ApellidosyNombres + '</td>'
             + '     <td rowspan="3" align="center" style="width:40%"><img width = "80px" height="50px" src = "' + ImgFirma + '" onerror = "this.onerror=null;this.src=SIMA.Utilitario.Constantes.ImgDataURL.ImgSFNormal;"></td>'
             + ' </tr>'
             + ' <tr>'
             + '    <td style="font-size: 10px;color:gray;">' + item.NombreArea + '</td>'
             + ' </tr>'
             + ' <tr>'
             + '     <td  style="font-weight: bold; font-size: 12px;color:gray; font-style: italic;">' + item.Email + '</td>'
             + '</tr>'
             + '</table>';

         iTemplate = '<a href="#" class="list-group-item list-group-item-action d-flex justify-content-between align-items-center">'
             + ItemUser
             + '</a>';

         var oCustomTemplateBE = new EasyAcFindAprobador.CustomTemplateBE(ul, item, iTemplate);

         return EasyAcFindAprobador.SetCustomTemplate(oCustomTemplateBE);
     }

     EasyNetLiveChatFind.OnItemSelected = function (value, ItemBE) {
             alert()    
     }
     </script>
</html>
