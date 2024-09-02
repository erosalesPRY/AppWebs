<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EasyNetLiveChat.aspx.cs" Inherits="SIMANET_W22R.HelpDesk.ChatBox.EasyNetLiveChat" %>

<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb.Form.Controls" TagPrefix="cc3" %>
<%@ Register Assembly="EasyControlWeb" Namespace="EasyControlWeb" TagPrefix="cc1" %>
<%@ Register assembly="EasyControlWeb" namespace="EasyControlWeb.Filtro" tagprefix="cc2" %>
<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

    <link href="../../Recursos/css/EasyNetLiveChat.css" rel="stylesheet" />

<style>
 .status-ContactGrp {
  width: 10px;
  height: 10px;
  border-radius: 50%;
  background-color: red;
   border: 2px solid white;
  bottom: 0;
  /*right: 0;*/
  left:10;
  position: absolute;
}



/*BadGet - Insignia usado en los link*/
.badge1{
    position: relative;
   /* margin-left: -5.1%;
    margin-top: 8.5%;*/
   right:-15px;
   bottom:-30px;
}

    .badge1 {
        display: inline-block;
        min-width: 10px;
        padding: 3px 7px;
        font-size: 12px;
        /* font-weight: 700;*/
        line-height: 1;
        color: red;
        text-align: center;
        white-space: nowrap;
        vertical-align: middle;
        background-color: transparent;
        border-radius: 10px;
        
    }

    .modal-body {
        background-image: url("../../Recursos/img/HeaderChat.png");
        background-repeat: no-repeat;
    }

    .chat-area-header {
        background-color:transparent;
    }
  .form-control
   {   
        background-color:red;
   }

</style>

<script>

       

    function MsgBE(_IdContactOrg, _IdContactDes, _IdMsg, _Texto) {
        this.IdContactOrg = _IdContactOrg;
        this.IdContactDes = _IdContactDes;
        this.IdMsg = _IdMsg;
        this.Texto = _Texto;
    }


    
const toggleButton = document.querySelector('.dark-light');
const colors = document.querySelectorAll('.color');

colors.forEach(color => {
  color.addEventListener('click', (e) => {
    colors.forEach(c => c.classList.remove('selected'));
    const theme = color.getAttribute('data-color');
    document.body.setAttribute('data-theme', theme);
    color.classList.add('selected');
  });
});

toggleButton.addEventListener('click', () => {
  document.body.classList.toggle('dark-mode');
});

 const ConfigButton = document.querySelector('.settings');

    ConfigButton.addEventListener('click', () => {
        if (NetSuite.LiveChat.LinkService == null) {
            var msgConfig = { Titulo: "Conficuración de Servicio", Descripcion: "No cuenta con configuracion de servicio" };
            var oMsg = new SIMA.MessageBox(msgConfig);
            oMsg.Alert();
        }
        else {
            NetSuite.LiveChat.LinkService();
        }
    });


</script>


</head>
<body style="width:80%;background-color: coral;">
    <form id="form1" runat="server" >         
        <div style="width:100%;height:600px;">
                             <div class="header">
                                 <div  class="search-bar1"  style="width:100%">
                                        <cc3:EasyAutocompletar ID="EasyAcFindContacto" Width="100%" runat="server" NroCarIni="1"  DisplayText="NOMBRECONTACTO" ValueField="ID_CONTACT" fnOnSelected="EasyNetLiveChat.OnItemSelected" fncTempaleCustom="EasyNetLiveChat.ItemplateContactos">
                                            <EasyStyle Ancho="Dos"></EasyStyle>
                                            <DataInterconect MetodoConexion="WebServiceExterno">
                                                <UrlWebService>http://localhost:1000/Core/HelpDesk/ChatBox/ICharBoxManager.asmx</UrlWebService>
                                                <Metodo>ListarContatos</Metodo>
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
                         <div id= "HeadContact" class="chat-area-header" style="margin-bottom: 25px;">
                                <div id="LblContact" class="chat-area-title" ></div>
                                <div id="LstContact" class="chat-area-group"></div>
                         </div>
            

                         <div class="chat-area" style="height:75%;">
                             <div id="ContentChat" class="chat-area-main" style="width:100%;height:100%;">

                             </div>
                         </div>
                         <div class="chat-area-footer">
                                 <svg xmlns = "http://www.w3.org/2000/svg" viewBox = "0 0 24 24" fill = "none" stroke = "currentColor" stroke-width="1.5" stroke - linecap="round" stroke - linejoin="round" class="feather feather-video" >
                                         <path d="M23 7l-7 5 7 5V7z" />
                                         <rect x="1" y="5" width="15" height="14" rx="2" ry="2" />
                                 </svg>
                                 <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-image">
                                     <rect x="3" y="3" width="18" height="18" rx="2" ry="2" />
                                     <circle cx="8.5" cy="8.5" r="1.5" />
                                     <path d="M21 15l-5-5L5 21" />
                                 </svg>
                                 <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-plus-circle">
                                     <circle cx="12" cy="12" r="10" />
                                     <path d="M12 8v8M8 12h8" />
                                 </svg>
                                 <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-paperclip">
                                      <path d="M21.44 11.05l-9.19 9.19a6 6 0 01-8.49-8.49l9.19-9.19a4 4 0 015.66 5.66l-9.2 9.19a2 2 0 01-2.83-2.83l8.49-8.48" />
                                 </svg>
                                 <input type="text" placeholder="Escribe un mensaje aquí..." style="border-width:1px;  border-style: dotted;border-color: gray;"  onkeydown="EasyNetLiveChat.InputMensaje(this);"/>
                                 <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-smile">
                                     <circle cx="12" cy="12" r="10" />
                                     <path d="M8 14s1.5 2 4 2 4-2 4-2M9 9h.01M15 9h.01" />
                                 </svg>
                                 <svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-thumbs-up">
                                     <path d="M14 9V5a3 3 0 00-3-3l-4 9v11h11.28a2 2 0 002-1.7l1.38-9a2 2 0 00-2-2.3zM7 22H4a2 2 0 01-2-2v-7a2 2 0 012-2h3" />
                                 </svg>
                         </div> 
                         <div>  
                         </div>
                         </div>

     
       
        
    </form>
</body>

     <script>
         var oContactoDestinoSelected = null;
         var cmll = "\"";
         EasyNetLiveChat.PathUrlServiceChat = "http://localhost:1000/Core/HelpDesk/ChatBox/ICharBoxManager.asmx";
         EasyNetLiveChat.ItemplateContactos = function (ul, item) {
             var Foto = ((item.ISGRUPO == 1) ? item.FOTO_GRUPO : GlobalEntorno.PathFotosPersonal + item.NRODOCUMENTO + ".jpg");
             var IcoEmail = ((SIMA.Utilitario.Helper.Data.ValidarEmail(item.EMAIL) == true) ? SIMA.Utilitario.Constantes.ImgDataURL.CardEMail : SIMA.Utilitario.Constantes.ImgDataURL.CardSinEmail);
             var ItemUser = '<table style="width:100%">'
                             + ' <tr>'
                             + '     <td rowspan="3" align="center" style="width:15%"><img class=" rounded-circle" width = "45px"  height="45px" src = "' + Foto + '"  onerror = "this.onerror=null;this.src=SIMA.Utilitario.Constantes.ImgDataURL.ImgSF;"></td>'
                             + '     <td class="Etiqueta" style="width:85%">' + item.NOMBRECONTACTO + '</td>'
                             + '     <td rowspan="3" align="center" style="width:10%"><img class=" rounded-circle" width = "25px" src = "' + IcoEmail + '" onerror = "this.onerror=null;this.src=SIMA.Utilitario.Constantes.ImgDataURL.ImgSF;"></td>'
                             + ' </tr>'
                             + ' <tr>'
                             + '    <td>' + item.SITUACION + '</td>'
                             + ' </tr>'
                             + ' <tr>'
                             + '     <td>' + item.EMAIL + '</td>'
                             + '</tr>'
                             + '</table>';

             iTemplate = '<a href="#" class="list-group-item list-group-item-action d-flex justify-content-between align-items-center">'
                 + ItemUser
                 + '</a>';

             var oCustomTemplateBE = new EasyAcFindContacto.CustomTemplateBE(ul, item, iTemplate);

             return EasyAcFindContacto.SetCustomTemplate(oCustomTemplateBE);
         }

         EasyNetLiveChat.ITemplateLstUsuarioContacto = function (oContactoBE) {
             var iTemplate = ' <div style="border-color: transparent;">' + '<img class="chat-area-profile" style="width:35px;height:35px;" src="' + GlobalEntorno.PathFotosPersonal + oContactoBE.NRODOCUMENTO + ".jpg" + '" alt="' + oContactoBE.NOMBRECONTACTO + '" />' +'<div  class="status-ContactGrp"></div></div>'; 
             return iTemplate;
         }
         EasyNetLiveChat.ITemplateLstUsuarioContactoCount = function (NroAdd) {
             var iTemplate = '<span>+' + NroAdd + '</span>';
             return iTemplate;
         }
        

         EasyNetLiveChat.OnItemSelected = function (value, ItemBE) {
             //Registra Libreria
             var PathChatBoxService = Page.Request.ApplicationPath + "/Recursos/LibSIMA/ChatBoxServiceBroker/" + ItemBE.LIB_JS_SRVBROKER.toString().Replace(" ","");
             Using(PathChatBoxService, { dom: true });

             //Instancia la clase contacto con el registro de contacto seleccionado
             oContactoDestinoSelected = new NetSuite.LiveChat.ContactBE();
             oContactoDestinoSelected.Id = ItemBE.ID_CONTACT;
             oContactoDestinoSelected.Foto = GlobalEntorno.PathFotosPersonal + ItemBE.NRODOCUMENTO + '.JPG'; 
             oContactoDestinoSelected.ApellidosYnombres = ItemBE.NOMBRECONTACTO;


             //Limpiar Contenedor
             var LstContactos = jNet.get('LstContact');
             LstContactos.clear();


             jNet.get('LblContact').innerHTML = ItemBE.NOMBRECONTACTO;

             if (ItemBE.ISGRUPO == 1) {//Grupo de Usuarios
                 var oEasyDataInterConect = new EasyDataInterConect();
                 oEasyDataInterConect.MetododeConexion = ModoInterConect.WebServiceExterno;
                 oEasyDataInterConect.UrlWebService = EasyNetLiveChat.PathUrlServiceChat;
                 oEasyDataInterConect.Metodo = "ListarMiembros";

                 var oParamCollections = new SIMA.ParamCollections();
                 var oParam = new SIMA.Param("IdContacto", ItemBE.ID_CONTACT, TipodeDato.Int);
                 oParamCollections.Add(oParam);
                 oParam = new SIMA.Param("UserName", UsuarioBE.UserName);
                 oParamCollections.Add(oParam);

                 oEasyDataInterConect.ParamsCollection = oParamCollections;

                 var oEasyDataResult = new EasyDataResult(oEasyDataInterConect);
                 var Cant = 0;
                 oEasyDataResult.getDataTable().Rows.forEach(function (oDR, i) {
                     //Verificar si los usuarios estan conectados
                     LstContactos.innerHTML += EasyNetLiveChat.ITemplateLstUsuarioContacto(oDR);
                     Cant = i;
                 });
                 if (Cant > 1) {
                     LstContactos.innerHTML += EasyNetLiveChat.ITemplateLstUsuarioContactoCount(Cant);
                 }
             }
             else {//Usuario Individual
                 LstContactos.innerHTML += EasyNetLiveChat.ITemplateLstUsuarioContacto(ItemBE);
             }
           // jNet.get('HeadContact').innerHTML += '<br><div class="">' + ItemBE.DESCRIPCION + '</div>';

             //Carga Plataforma de dialogo 
             EasyNetLiveChat.ListaHistorialChat(1, ItemBE.ID_CONTACT);
         }

         EasyNetLiveChat.ListaHistorialChat = function (IdContactoOrg,IdContactDes) {
             var oContentChat = jNet.get('ContentChat');
             oContentChat.clear();

             var oEasyDataInterConect = new EasyDataInterConect();
             oEasyDataInterConect.MetododeConexion = ModoInterConect.WebServiceExterno;
             oEasyDataInterConect.UrlWebService = EasyNetLiveChat.PathUrlServiceChat; 
             oEasyDataInterConect.Metodo = "LstHistorialDialogo";

             var oParamCollections = new SIMA.ParamCollections();
             var oParam = new SIMA.Param("IdContactoOrg", IdContactoOrg);
             oParamCollections.Add(oParam);
             oParam = new SIMA.Param("IdContactoDes", IdContactDes, TipodeDato.Int);
             oParamCollections.Add(oParam);
             oParam = new SIMA.Param("UserName", UsuarioBE.UserName);
             oParamCollections.Add(oParam);

             oEasyDataInterConect.ParamsCollection = oParamCollections;

             var oEasyDataResult = new EasyDataResult(oEasyDataInterConect);
             oEasyDataResult.getDataTable().Rows.forEach(function (oDR, i) {
                 var oContactBE = new NetSuite.LiveChat.ContactBE();
                 oContactBE.Foto = GlobalEntorno.PathFotosPersonal + oDR.NRODOCUMENTO + '.JPG';
                 oContactBE.IdMsg = oDR.ID_MSG;
                 oContactBE.MessageHTML = EasyNetLiveChat.ListaHistorialChatContenido(oContactBE.IdMsg);
                 if (IdContactoOrg == oDR.ID_CONTACT_ORG) {
                     oContentChat.innerHTML += NetSuite.LiveChat.ItemplateChatOwner(oContactBE);
                 }
                 else {
                     oContentChat.innerHTML += NetSuite.LiveChat.ItemplateChatContact(oContactBE);
                 }
             });
         }

         EasyNetLiveChat.Badget = function (IdContents) {
             var strHTMLLike = "";

             var oEasyDataInterConect = new EasyDataInterConect();
             oEasyDataInterConect.MetododeConexion = ModoInterConect.WebServiceExterno;
             oEasyDataInterConect.UrlWebService = EasyNetLiveChat.PathUrlServiceChat;
             oEasyDataInterConect.Metodo = "LstHistorialDialogoContenidoLikes";

             var oParamCollections = new SIMA.ParamCollections();
             var oParam = new SIMA.Param("Idmsg", IdContents);
             oParamCollections.Add(oParam);
             oParam = new SIMA.Param("UserName", UsuarioBE.UserName);
             oParamCollections.Add(oParam);

             oEasyDataInterConect.ParamsCollection = oParamCollections;

             var oEasyDataResult = new EasyDataResult(oEasyDataInterConect);
             var pos = 100;
             try {
                 oEasyDataResult.getDataTable().Rows.forEach(function (oDataRow, i) {
                     var _Likes = "+" + oDataRow.NROLIKE
                     strHTMLLike += '<span class="badge1 rounded-pill text-danger"   style=" right: ' + pos + 'px">' + _Likes + '<img style="width:20px" src = "' + oDataRow.CMEDIA + '" /> </span>';
                     pos = pos + 30;
                 });
             }
             catch (ex) {

             }

             return strHTMLLike;
         }

         EasyNetLiveChat.ListaHistorialChatContenido = function (IdMsg) {
             var strLstMsg = "";
             var oEasyDataInterConect = new EasyDataInterConect();
             oEasyDataInterConect.MetododeConexion = ModoInterConect.WebServiceExterno;
             oEasyDataInterConect.UrlWebService = EasyNetLiveChat.PathUrlServiceChat;
             oEasyDataInterConect.Metodo = "LstHistorialDialogoContenido";

             var oParamCollections = new SIMA.ParamCollections();
             var oParam = new SIMA.Param("Idmsg", IdMsg);
             oParamCollections.Add(oParam);
             oParam = new SIMA.Param("UserName", UsuarioBE.UserName);
             oParamCollections.Add(oParam);

             oEasyDataInterConect.ParamsCollection = oParamCollections;

             var oEasyDataResult = new EasyDataResult(oEasyDataInterConect);
             oEasyDataResult.getDataTable().Rows.forEach(function (oDataRow, i) {
                 var strBE = "";
                 var htmBadgetLike = EasyNetLiveChat.Badget(oDataRow.ID_CONTENTS);
                 strLstMsg += '         <div class="chat-msg-text"  Data="' + strBE.Serialized(oDataRow) + '"  id="' + oDataRow.ID_CONTENTS + '">' + oDataRow.TEXT + htmBadgetLike + '</div>';
             });
             return strLstMsg;
         }

         var Pos = 0;
         EasyNetLiveChat.InputMensaje = function (e) {
             if (event.keyCode === 13) {
                 if (oContactoDestinoSelected != null) {

                     var oContactBE = new NetSuite.LiveChat.ContactBE();
                        oContactBE.Foto = GlobalEntorno.PathFotosPersonal + UsuarioBE.NroDocumento + '.JPG';
                        oContactBE.Id = Pos;
                        oContactBE.MessageHTML = NetSuite.LiveChat.ITemplateMessaje(oContactBE, e.value);
                     NetSuite.LiveChat.EnviaMensaje(oContactBE);
                     Pos++;
                     e.value = "";
                 }
                 else {
                     var msgConfig = { Titulo: "Segurida de envió", Descripcion: "No se ha seleccionado Contacto de destino" };
                     var oMsg = new SIMA.MessageBox(msgConfig);
                     oMsg.Alert();
                 }
             }
           
         }


     </script>






</html>
