<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EasyNetLiveChat.aspx.cs" Inherits="SIMANET_W22R.HelpDesk.ChatBot.EasyNetLiveChat" %>

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
    /*
        --https://jsfiddle.net/XNnHC/1808/
    */
       

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
                             <div class="header" id="ChatHeader">
                                 <div  class="search-bar1"  style="width:100%">
                                        <cc3:EasyAutocompletar ID="EasyAcFindContacto" Width="100%" runat="server" NroCarIni="1"  DisplayText="NOMBRECONTACTO" ValueField="ID_CONTACT" fnOnSelected="EasyNetLiveChat.OnItemSelected" fncTempaleCustom="EasyNetLiveChat.ItemplateContactos">
                                            <EasyStyle Ancho="Dos"></EasyStyle>
                                            <DataInterconect MetodoConexion="WebServiceExterno">
                                                <UrlWebService>http://localhost:1000/Core/HelpDesk/ChatBot/IChatBotManager.asmx</UrlWebService>
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
                         <div id="ChatFooter" class="chat-area-footer">
                              
                         </div> 

                        <div>  
                    </div>
                </div>

     
       
        
    </form>
</body>

     <script>
         var btns = [
                      ['Left',true,'<svg xmlns = "http://www.w3.org/2000/svg" viewBox = "0 0 24 24" fill = "none" stroke = "currentColor" stroke-width="1.5" stroke - linecap="round" stroke - linejoin="round" class="feather feather-video"><path d = "M23 7l-7 5 7 5V7z" /><rect x="1" y="5" width="15" height="14" rx="2" ry="2"/></svg>']
                     , ['Left', true,'<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-image"><rect x = "3" y = "3" width = "18" height = "18" rx = "2" ry = "2" /><circle cx="8.5" cy="8.5" r="1.5" /><path d="M21 15l-5-5L5 21"/></svg>']
                     , ['Left', true,'<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-plus-circle">< circle cx = "12" cy = "12" r = "10" /><path d="M12 8v8M8 12h8"/></svg>']
                     , ['Left', true,'<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-paperclip">< path d = "M21.44 11.05l-9.19 9.19a6 6 0 01-8.49-8.49l9.19-9.19a4 4 0 015.66 5.66l-9.2 9.19a2 2 0 01-2.83-2.83l8.49-8.48"/></svg>']
                     , ['Center', true,'<input type="text" placeholder="Escribe un mensaje aquí..." style="border-width:1px;  border-style: dotted;border-color: gray;" onkeydown="EasyNetLiveChat.InputMensaje(this);"/>']
                     , ['Rigth', true,'<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-smile"><circle cx = "12" cy = "12" r = "10" /><path d="M8 14s1.5 2 4 2 4-2 4-2M9 9h.01M15 9h.01"/></svg>']
                     , ['Rigth', false,'<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-thumbs-up"><path d = "M14 9V5a3 3 0 00-3-3l-4 9v11h11.28a2 2 0 002-1.7l1.38-9a2 2 0 00-2-2.3zM7 22H4a2 2 0 01-2-2v-7a2 2 0 012-2h3"/></svg>']
                   ];

        
       /*  
         btns.forEach((score, i) => {

             alert(score[0] + ' - ' + score[1] + ' - ' + i);
         });

         */

         

         var oContactoDestinoBE = null;

         var oContactoSendDestinoSeleccionadoBE = null;
         var cmll = "\"";
         EasyNetLiveChat.PathUrlServiceChat = ConnectedService.PathNetCore + "HelpDesk/ChatBot/IChatBotManager.asmx";

         EasyNetLiveChat.FotoContacto = function (NroDocumento) {
             return GlobalEntorno.PathFotosPersonal + NroDocumento + ".jpg";
         }
         EasyNetLiveChat.Data = {};
         EasyNetLiveChat.Render = {};
         EasyNetLiveChat.Panel = {};
         EasyNetLiveChat.Panel.Header = function () {return jNet.get('ChatHeader');}
         EasyNetLiveChat.Panel.Contactos = {};
         EasyNetLiveChat.Panel.Contactos.Right = function(){return jNet.get('LstContact');}
         EasyNetLiveChat.Panel.Contactos.Left = function () { return jNet.get('LblContact'); }
         EasyNetLiveChat.Panel.Body = function () { return jNet.get('ContentChat'); }
         EasyNetLiveChat.Panel.Footer = function () { return jNet.get('ChatFooter'); }

         EasyNetLiveChat.Panel.Footer.Controls = [
                                                    ['Left', false, '<svg xmlns = "http://www.w3.org/2000/svg" viewBox = "0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-video"><path d = "M23 7l-7 5 7 5V7z"/><rect x="1" y="5" width="15" height="14" rx="2" ry="2"/></svg>']
                                                  , ['Left', false, '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-image"><rect x = "3" y = "3" width = "18" height = "18" rx = "2" ry = "2" /><circle cx="8.5" cy="8.5" r="1.5"/><path d="M21 15l-5-5L5 21"/></svg>']
                                                  , ['Left', true, '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-plus-circle"><circle cx="12" cy="12" r="10"/><path d="M12 8v8M8 12h8"/></svg>']
                                                  , ['Left', true, '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-paperclip"><path d = "M21.44 11.05l-9.19 9.19a6 6 0 01-8.49-8.49l9.19-9.19a4 4 0 015.66 5.66l-9.2 9.19a2 2 0 01-2.83-2.83l8.49-8.48"/></svg>']
                                                  , ['Center', true, '<input type="text" placeholder="Escribe un mensaje aquí..." style="border-width:1px;  border-style: dotted;border-color: gray;" onkeydown="EasyNetLiveChat.InputMensaje(this);"/>']
                                                  , ['Rigth', true, '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-smile"><circle cx = "12" cy = "12" r = "10"/><path d="M8 14s1.5 2 4 2 4-2 4-2M9 9h.01M15 9h.01"/></svg>']
                                                  , ['Rigth', true, '<svg xmlns="http://www.w3.org/2000/svg" viewBox="0 0 24 24" fill="none" stroke="currentColor" stroke-width="1.5" stroke-linecap="round" stroke-linejoin="round" class="feather feather-thumbs-up"><path d = "M14 9V5a3 3 0 00-3-3l-4 9v11h11.28a2 2 0 002-1.7l1.38-9a2 2 0 00-2-2.3zM7 22H4a2 2 0 01-2-2v-7a2 2 0 012-2h3"/></svg>']
                                                 ];
         EasyNetLiveChat.Panel.Footer.Controls.Load = function () {
             var _Footer = EasyNetLiveChat.Panel.Footer();
             EasyNetLiveChat.Panel.Footer.Controls.forEach((btn, i) => {
                 if (btn[1] == true) {
                     _Footer.innerHTML += btn[2];
                 }
             });
         }
         EasyNetLiveChat.Panel.Footer.Controls.Load();


         EasyNetLiveChat.ItemplateContactos = function (ul, item) {
             var Foto = ((item.ISGRUPO == 1) ? item.FOTO_GRUPO : EasyNetLiveChat.FotoContacto(item.NRODOCUMENTO)); 
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

         EasyNetLiveChat.ITemplateLstUsuarioContacto = function (Modalidad, _ContactoDestinoBE) {
             var cmll = "\"";
             var strData = "";
             strData = strData.Serialized(_ContactoDestinoBE).Replace(cmll,"'");
             var iTemplate = ' <div style="border-color: transparent;">' + '<img class="chat-area-profile" style="width:35px;height:35px;" src="' + _ContactoDestinoBE.Foto + '" alt="' + _ContactoDestinoBE.Nombre + '" Data="' + strData + '" Modalidad= "' + Modalidad + '"onclick="EasyNetLiveChat.Panel.Contactos.onClick(this);" />' + '<div  class="status-ContactGrp"></div></div>'; 
             return iTemplate;
         }
         EasyNetLiveChat.ITemplateInfoContacto = function (_ContactoDestinoBE) {
             var cmll = "\"";
             var strData = "";
             strData = strData.Serialized(_ContactoDestinoBE).Replace(cmll, "'");
             var iTemplate = '';
             var Modalidad = ((_ContactoDestinoBE.Tipo == 1) ? EasyNetLiveChat.Enum.Modalidad.GrupoDestino : "Usuario");
             iTemplate = '<div style="border-color: transparent;">' + '<img class="chat-area-profile" style="width:35px;height:35px;" src="' + _ContactoDestinoBE.Foto + '" alt="' + _ContactoDestinoBE.Nombre + '" Data="' + strData + '" Modalidad= "'+ Modalidad +'" onclick="EasyNetLiveChat.Panel.Contactos.onClick(this);" />' + '<div  class="status-ContactGrp"></div></div>';
             return iTemplate;
         }


         EasyNetLiveChat.ITemplateLstUsuarioContactoCount = function (NroAdd) {
             var iTemplate = '<span>+' + NroAdd + '</span>';
             return iTemplate;
         }

         EasyNetLiveChat.Modalidad = null;
         EasyNetLiveChat.Enum = {};
         EasyNetLiveChat.Enum.Modalidad = {
             ContactDestino: "CD",
             GrupoDestino:"GD",
             UsuSend: "US",
             Grupo: "Grp",
         }

         EasyNetLiveChat.Panel.Contactos.onClick = function (e) {
             var cmll = "\"";
             var ImgUsuario = jNet.get(e);
             var Modalidad = ImgUsuario.attr("Modalidad");
             var strData = ImgUsuario.attr("Data").toString();
             var oContactoBE = strData.SerializedToObject();//Informacion del Contacto

             EasyNetLiveChat.Modalidad = Modalidad;

             switch (Modalidad) {
                 case EasyNetLiveChat.Enum.Modalidad.ContactDestino:
                     //Usuario Destino Seleccionado
                     oContactoSendDestinoSeleccionadoBE = oContactoBE;
                     NetSuite.LiveChat.WndPopupIface.Task.Excecute('Load historial chat..', function () {
                         /*parametros de ingreso Contacto Origen - Destino */
                         EasyNetLiveChat.Render.ChatHistoryDialogo(oContactoDestinoBE.IdContacto, oContactoBE.IdContacto);
                     });
                     
                     break;
                 case EasyNetLiveChat.Enum.Modalidad.GrupoDestino:

                     //if (EasyNetLiveChat.Data.VerificarPertenezcoAlGrupo(value))
                     if (oContactoBE.IdContacto != UsuarioBE.IdContacto) {//ContactoBE viene a ser el Usuario o Grupo Seleccionado y 
                         EasyNetLiveChat.Render.ChatHistoryDialogo(UsuarioBE.IdContacto, oContactoBE.IdContacto);//Verifica los Mensaje recibidos al grupo (ContactoBE) del usuario(UsuarioBE-Usuario logueado)
                     }

                     //alert("Usuario de Grupo " + oContactoBE.Tipo + UsuarioBE.IdContacto);

                     //aler();
                    /* NetSuite.LiveChat.WndPopupIface.Task.Excecute('Load historial chat..', function () {
                         EasyNetLiveChat.Render.ChatHistoryDialogo(UsuarioBE.IdContacto, oContactoBE.IdContacto);

                     });*/
                     break;
                 case "Usuario":
                     break;

             }
         }

         EasyNetLiveChat.IdMiembroGrupoSeleccionado = 0;


         EasyNetLiveChat.OnItemSelected = function (value, ItemBE) {
             EasyNetLiveChat.Panel.Contactos.Right().clear();
             //Registra Libreria según el  servio implementado
             var PathChatBoxService = Page.Request.ApplicationPath + "/Recursos/LibSIMA/ChatBotServiceBroker/" + ItemBE.LIB_JS_SRVBROKER.toString().Replace(" ", "");
             var options = { dom: true, Prefijo: 'Helpdesk', Id: ItemBE.ID_CONTACT };
             UndoUsing(options);

             Using(PathChatBoxService, options);

             //Datos del Contacto Destino
            // oContactoBE = ItemBE;//Contacto destio seleccionado
             oContactoDestinoBE = new NetSuite.LiveChat.ContactBE();
             oContactoDestinoBE.IdContacto = ItemBE.ID_CONTACT
             oContactoDestinoBE.Foto = ((ItemBE.ISGRUPO == '1') ? ItemBE.FOTO_GRUPO : EasyNetLiveChat.FotoContacto(ItemBE.NRODOCUMENTO));
             oContactoDestinoBE.Nombre = ItemBE.NOMBRECONTACTO;
             oContactoDestinoBE.Tipo = ItemBE.ISGRUPO;

             EasyNetLiveChat.Panel.Contactos.Left().clear();
             EasyNetLiveChat.Panel.Contactos.Left().innerHTML = EasyNetLiveChat.ITemplateInfoContacto(oContactoDestinoBE);
             EasyNetLiveChat.Panel.Contactos.Right().clear();
             

             NetSuite.LiveChat.WndPopupIface.Task.Excecute('Load historial chat..', function () {
                 if (EasyNetLiveChat.Data.VerificarPertenezcoAlGrupo(value)) {

                     EasyNetLiveChat.Render.ContactosSendMSGtoGRP(value);
                 }
                 else {
                     EasyNetLiveChat.Render.MiembrosdeGrupoSeleccionado(oContactoDestinoBE);
                 }

                 EasyNetLiveChat.Render.ChatHistoryDialogo(UsuarioBE.IdContacto, oContactoDestinoBE.IdContacto);
             });
             


         }


         EasyNetLiveChat.Render.ContactosSendMSGtoGRP = function (IdGrupoServicios) {
             var Cant = 0;
             EasyNetLiveChat.Data.LstMiembroContactosSendToGRP(IdGrupoServicios).Rows.forEach(function (oDR, i) {
             var ContactSendBE = new NetSuite.LiveChat.ContactBE();
                 ContactSendBE.IdContacto = oDR.ID_CONTACT_ORG;
                 ContactSendBE.Nombre = oDR.NOMBRECONTACTO;
                 ContactSendBE.Foto = EasyNetLiveChat.FotoContacto(oDR.NRODOCUMENTO);
                 ContactSendBE.EMail = oDR.EMAIL;
                 //Verificar si los usuarios estan conectados
                 //EasyNetLiveChat.Panel.Contactos.Right().innerHTML += EasyNetLiveChat.ITemplateLstUsuarioContacto("UsuSend", ContactSendBE);
                 EasyNetLiveChat.Panel.Contactos.Right().innerHTML += EasyNetLiveChat.ITemplateLstUsuarioContacto(EasyNetLiveChat.Enum.Modalidad.ContactDestino, ContactSendBE);
                    Cant = i;
                });
                if (Cant > 1) {
                    EasyNetLiveChat.Panel.Contactos.Right().innerHTML += EasyNetLiveChat.ITemplateLstUsuarioContactoCount(Cant);
                }
         } 
         EasyNetLiveChat.Render.MiembrosdeGrupoSeleccionado = function (_ContactoDestinoBE) {
             if (_ContactoDestinoBE.Tipo == 1) {//Grupo de Usuarios
                 var Cant = 0;
                 EasyNetLiveChat.Data.LstMiembroGrupoSeleccionado(_ContactoDestinoBE.IdContacto).Rows.forEach(function (oDR, i) {
                     //Verificar si los usuarios estan conectados
                     var oContactBE = new NetSuite.LiveChat.ContactBE();
                     oContactBE.Foto = EasyNetLiveChat.FotoContacto(oDR.NRODOCUMENTO);;
                     oContactBE.Nombre = oDR.APELLIDOSYNOMBRES;
                     EasyNetLiveChat.Panel.Contactos.Right().innerHTML += EasyNetLiveChat.ITemplateLstUsuarioContacto("Grupo", oContactBE);
                     Cant = i;
                 });
                 if (Cant > 1) {
                     EasyNetLiveChat.Panel.Contactos.Right().innerHTML += EasyNetLiveChat.ITemplateLstUsuarioContactoCount(Cant);
                }
             }
         } 
         EasyNetLiveChat.Render.ChatHistoryDialogo = function(IdContactoOrg, IdContactDes) {
             EasyNetLiveChat.Panel.Body().clear();

             EasyNetLiveChat.Data.ListarHistorialChatDialogo(IdContactoOrg, IdContactDes).Rows.forEach(function (oDR, i) {
                     var oContactBE = new NetSuite.LiveChat.ContactBE();
                         oContactBE.Foto = EasyNetLiveChat.FotoContacto(oDR.NRODOCUMENTO);;

                    var _MensajeBE = new NetSuite.LiveChat.MensajeBE();
                        _MensajeBE.ContactoFrom = oContactBE;
                        _MensajeBE.IdMsg = oDR.ID_MSG;
                        _MensajeBE.AllContenidoBE = EasyNetLiveChat.Data.ListaHistorialChatContenido(_MensajeBE.IdMsg);

                    if (IdContactoOrg == oDR.ID_CONTACT_ORG) {

                         EasyNetLiveChat.Panel.Body().innerHTML += NetSuite.LiveChat.ItemplateChatOwner(_MensajeBE);
                     }
                     else {
                         EasyNetLiveChat.Panel.Body().innerHTML += NetSuite.LiveChat.ItemplateChatContact(_MensajeBE);
                     }
             });
             //Objeto Creado en Header.ascx
             NetSuite.LiveChat.WndPopupIface.ProgressBar.Hide();
         }

         EasyNetLiveChat.Data.LstMiembroContactosSendToGRP = function (IdGrupoServicios) {
             var oEasyDataInterConect = new EasyDataInterConect();
             oEasyDataInterConect.MetododeConexion = ModoInterConect.WebServiceExterno;
             oEasyDataInterConect.UrlWebService = EasyNetLiveChat.PathUrlServiceChat;
             oEasyDataInterConect.Metodo = "LstContactSendtoGrupo";

             var oParamCollections = new SIMA.ParamCollections();
             var oParam = new SIMA.Param("IdContactGrupo", IdGrupoServicios, TipodeDato.Int);
             oParamCollections.Add(oParam);
             oParam = new SIMA.Param("UserName", UsuarioBE.UserName);
             oParamCollections.Add(oParam);

             oEasyDataInterConect.ParamsCollection = oParamCollections;

             var oEasyDataResult = new EasyDataResult(oEasyDataInterConect);
             return oEasyDataResult.getDataTable();
         }
         EasyNetLiveChat.Data.LstMiembroGrupoSeleccionado = function (IdContacto) {
             var oEasyDataInterConect = new EasyDataInterConect();
             oEasyDataInterConect.MetododeConexion = ModoInterConect.WebServiceExterno;
             oEasyDataInterConect.UrlWebService = EasyNetLiveChat.PathUrlServiceChat;
             oEasyDataInterConect.Metodo = "ListarMiembros";

             var oParamCollections = new SIMA.ParamCollections();
             var oParam = new SIMA.Param("IdContacto", IdContacto, TipodeDato.Int);
             oParamCollections.Add(oParam);
             oParam = new SIMA.Param("UserName", UsuarioBE.UserName);
             oParamCollections.Add(oParam);

             oEasyDataInterConect.ParamsCollection = oParamCollections;

             var oEasyDataResult = new EasyDataResult(oEasyDataInterConect);
             return oEasyDataResult.getDataTable();
         }
         EasyNetLiveChat.Data.VerificarPertenezcoAlGrupo = function (IdContactoGrupo) {

             EasyNetLiveChat.IdMiembroGrupoSeleccionado = 0;

             var oEasyDataInterConect = new EasyDataInterConect();
             oEasyDataInterConect.MetododeConexion = ModoInterConect.WebServiceExterno;
             oEasyDataInterConect.UrlWebService = EasyNetLiveChat.PathUrlServiceChat;
             oEasyDataInterConect.Metodo = "IsMiembrodeGrupo";

             var oParamCollections = new SIMA.ParamCollections();
             var oParam = new SIMA.Param("IdContactGrupo", IdContactoGrupo, TipodeDato.Int);
             oParamCollections.Add(oParam);
             oParam = new SIMA.Param("CodPersona", UsuarioBE.CodPersonal);
             oParamCollections.Add(oParam);
             oParam = new SIMA.Param("UserName", UsuarioBE.UserName);
             oParamCollections.Add(oParam);

             oEasyDataInterConect.ParamsCollection = oParamCollections;

             var oEasyDataResult = new EasyDataResult(oEasyDataInterConect);

             oEasyDataResult.getDataTable().Rows.forEach(function (oDR, i) {
                 //Verificar si los usuarios estan conectados
                 EasyNetLiveChat.IdMiembroGrupoSeleccionado = oDR["ID_MIEMBRO"];

             });

             return (EasyNetLiveChat.IdMiembroGrupoSeleccionado == 0) ? false : true;


         }

         EasyNetLiveChat.Data.ListarHistorialChatDialogo = function (IdContactoOrg, IdContactDes) {
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
             return oEasyDataResult.getDataTable();
         }

         EasyNetLiveChat.Data.ListarHistorialChatDialogoContenido = function(IdMsg){
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
             
             return oEasyDataResult.getDataTable();
         }

         // EasyNetLiveChat.Badget = function (IdContents) {
         EasyNetLiveChat.Data.Badget = function (IdContents) {
             //var strHTMLLike = "";
             var CollectionMsgLike = new Array();
             var oEasyDataInterConect = new EasyDataInterConect();
             oEasyDataInterConect.MetododeConexion = ModoInterConect.WebServiceExterno;
             oEasyDataInterConect.UrlWebService = EasyNetLiveChat.PathUrlServiceChat;
             oEasyDataInterConect.Metodo = "LstHistorialDialogoContenidoLikes";

             var oParamCollections = new SIMA.ParamCollections();
             var oParam = new SIMA.Param("IdContents", IdContents);
             oParamCollections.Add(oParam);
             oParam = new SIMA.Param("UserName", UsuarioBE.UserName);
             oParamCollections.Add(oParam);

             oEasyDataInterConect.ParamsCollection = oParamCollections;

             var oEasyDataResult = new EasyDataResult(oEasyDataInterConect);
             //var pos = 100;
             try {
                 oEasyDataResult.getDataTable().Rows.forEach(function (oDataRow, i) {
                     //var _Likes = "+" + oDataRow.NROLIKE
                     //strHTMLLike += '<span class="badge1 rounded-pill text-danger"   style=" right: ' + pos + 'px">' + _Likes + '<img style="width:20px" src = "' + oDataRow.CMEDIA + '" /> </span>';
                     //pos = pos + 30;
                     var oMensajeContenidoLikesBE = new NetSuite.LiveChat.MensajeContenidoLikesBE();
                        oMensajeContenidoLikesBE.NroLikes = oDataRow.NROLIKE;
                        oMensajeContenidoLikesBE.Icono = oDataRow.CMEDIA;
                     CollectionMsgLike.Add(oMensajeContenidoLikesBE);
                 });
             }
             catch (ex) {

             }
             //  return strHTMLLike;
             return CollectionMsgLike; 
         }

         EasyNetLiveChat.Data.ListaHistorialChatContenido = function (IdMsg) {
             var CollectionMsgContenido = new Array();
             EasyNetLiveChat.Data.ListarHistorialChatDialogoContenido(IdMsg).Rows.forEach(function (oDataRow, i) {
                 var MensajeContenidoBE = new NetSuite.LiveChat.MensajeContenidoBE();
                 MensajeContenidoBE.IdMsg = IdMsg;
                 MensajeContenidoBE.IdContenido = oDataRow.ID_CONTENTS;
                 MensajeContenidoBE.Texto = oDataRow.TEXT;
                 MensajeContenidoBE.AllLikes = EasyNetLiveChat.Data.Badget(oDataRow.ID_CONTENTS);

                 CollectionMsgContenido.Add(MensajeContenidoBE);
             });
             return CollectionMsgContenido;
         }

         /*
         EasyNetLiveChat.HtmlChatContenido = function (oContenidoBE) {
             var cmll = "\"";
             var strBE = "";
             var htmlLike = EasyNetLiveChat.HtmlChatContenidoLikes(oContenidoBE.AllLikes);
             strBE = strBE.Serialized(oContenidoBE).Replace(cmll, "'");
             return '         <div class="chat-msg-text"  Data="' + strBE + '"  id="' + oContenidoBE.IdContenido + '" onclick="NetSuite.LiveChat.bubble.Click(this);"   >' + oContenidoBE.Texto + ((htmlLike == undefined) ? "" : htmlLike) + '</div>';
         }
         EasyNetLiveChat.HtmlChatContenidoLikes = function (AllMensajeContenidoLikes) {
             var pos = 100;
             var strHTMLLike = "";
             if (AllMensajeContenidoLikes == null) { return ""; }
             AllMensajeContenidoLikes.forEach(function (oMensajeContenidoLikesBE, i) {
                 var _Likes = "+" + oMensajeContenidoLikesBE.NroLikes
                 strHTMLLike += '<span class="badge1 rounded-pill text-danger"   style=" right: ' + pos + 'px">' + oMensajeContenidoLikesBE.NroLikes + '<img style="width:20px" src = "' + oMensajeContenidoLikesBE.Icono + '" /> </span>';
                 pos = pos + 30;
             });
            return strHTMLLike;
         }
         */

         EasyNetLiveChat.Data.GuardarMensaje = function (oMensajeBE) {
             var ContactoFromBE = oMensajeBE.ContactoFrom;
             var ContactoToBE = oMensajeBE.ContactoTo;
             var oMensajeContenidoBE = oMensajeBE.AllContenidoBE[0];

             var oParamCollections = new SIMA.ParamCollections();
             var oParam = new SIMA.Param("IdMiembro", ContactoFromBE.IdMiembro, TipodeDato.Int);
             oParamCollections.Add(oParam);
             oParam = new SIMA.Param("Texto", oMensajeContenidoBE.Texto);
             oParamCollections.Add(oParam);
             oParam = new SIMA.Param("IdContactOrg", ContactoFromBE.IdContacto, TipodeDato.Int);
             oParamCollections.Add(oParam);
             oParam = new SIMA.Param("IdContactDes", ContactoToBE.IdContacto, TipodeDato.Int);
             oParamCollections.Add(oParam);

             var oEasyDataInterConect = new EasyDataInterConect();
             oEasyDataInterConect.MetododeConexion = ModoInterConect.WebServiceExterno;
             oEasyDataInterConect.UrlWebService = EasyNetLiveChat.PathUrlServiceChat;
             oEasyDataInterConect.Metodo = "RegistrarMensajeyContenidoClient";
             oEasyDataInterConect.ParamsCollection = oParamCollections;

             var oEasyDataResult = new EasyDataResult(oEasyDataInterConect);
             return oEasyDataResult.sendData().toString().SerializedToObject();
         }

         var Pos = 0;
         EasyNetLiveChat.InputMensaje = function (e) {
             if (event.keyCode === 13) {

                 if (oContactoDestinoBE != null) {

                     var oMensajeBE = new NetSuite.LiveChat.MensajeBE();
                     switch (EasyNetLiveChat.Modalidad) {
                         case EasyNetLiveChat.Enum.Modalidad.ContactDestino:
                             var oCntOrigenBE = new NetSuite.LiveChat.ContactBE();
                             oCntOrigenBE.IdContacto = oContactoDestinoBE.IdContacto;
                             oCntOrigenBE.IdMiembro = EasyNetLiveChat.IdMiembroGrupoSeleccionado;//Id del Miebro del Grupo seleccionado que correponde al usuario logueado 
                             oCntOrigenBE.Tipo = oContactoDestinoBE.Tipo;
                             oCntOrigenBE.Foto = EasyNetLiveChat.FotoContacto(UsuarioBE.NroDocumento);
                             oCntOrigenBE.Nombre = UsuarioBE.ApellidosyNombres;

                             var oCntDestinoBE = new NetSuite.LiveChat.ContactBE();
                             oCntDestinoBE = oContactoSendDestinoSeleccionadoBE;
                             //Eatblece parametros de envio
                             oMensajeBE.ContactoFrom = oCntOrigenBE;
                             oMensajeBE.ContactoTo = oCntDestinoBE;
                             //Insertar en la BD
                             oMensajeBE.IdMsg = '0';
                                // oMensajeBE.MessageHTML = e.value;
                                var MensajeContenidoBE = new NetSuite.LiveChat.MensajeContenidoBE();
                                    MensajeContenidoBE.IdMsg = oMensajeBE.IdMsg;
                                    MensajeContenidoBE.IdContenido = 0;
                                    MensajeContenidoBE.Texto = e.value;
                                    MensajeContenidoBE.AllLikes = null;
                             var CollectionMsgContenido = new Array();
                             CollectionMsgContenido.Add(MensajeContenidoBE);
                             oMensajeBE.AllContenidoBE = CollectionMsgContenido;

                             var jSonBE = EasyNetLiveChat.Data.GuardarMensaje(oMensajeBE);
                             oMensajeBE.IdMsg = jSonBE.OutIdMsg;

                             MensajeContenidoBE.IdMsg = oMensajeBE.IdMsg;
                             MensajeContenidoBE.IdContenido = jSonBE.OutIdContenido;
                             //aler();
                             break;
                         case EasyNetLiveChat.Enum.Modalidad.GrupoDestino:
                         default:
                             var oContactFromBE = new NetSuite.LiveChat.ContactBE();
                             oContactFromBE.IdContacto = UsuarioBE.IdContacto;
                             oContactFromBE.IdMiembro = UsuarioBE.IdContacto;
                             oContactFromBE.Foto = EasyNetLiveChat.FotoContacto(UsuarioBE.NroDocumento);
                             oContactFromBE.Nombre = UsuarioBE.ApellidosyNombres;

                             //oContactFromBE.IdMsg = pos;//Este valor debe de ser obtenido desde la BD al crear el regisro de mesajes
                             //Eatblece parametros de envio
                             oMensajeBE.ContactoFrom = oContactFromBE;
                             oMensajeBE.ContactoTo = oContactoDestinoBE;

                                 var MensajeContenidoBE = new NetSuite.LiveChat.MensajeContenidoBE();
                                     MensajeContenidoBE.IdMsg = oMensajeBE.IdMsg;
                                     MensajeContenidoBE.IdContenido = 0;
                                     MensajeContenidoBE.Texto = e.value;
                                     MensajeContenidoBE.AllLikes = null;
                             var CollectionMsgContenido = new Array();
                             CollectionMsgContenido.Add(MensajeContenidoBE);
                             oMensajeBE.AllContenidoBE = CollectionMsgContenido;

                             var jSonBE = EasyNetLiveChat.Data.GuardarMensaje(oMensajeBE);
                             oMensajeBE.IdMsg = jSonBE.OutIdMsg;
                             MensajeContenidoBE.IdMsg = oMensajeBE.IdMsg;
                             MensajeContenidoBE.IdContenido = jSonBE.OutIdContenido;
                             
                             break;
                     }

                     NetSuite.LiveChat.EnviaMensaje(oMensajeBE);

                     //document.querySelector('#'+oMensajeBE.IdMsg).scrollIntoView({ behavior: 'smooth' });
                     location.href = '#' + oMensajeBE.IdMsg;
                   /*  $("#ContentChat").delay(100).animate({
                                scrollTop: $("#ContentChat").scrollTop() + $("#" + oMensajeBE.IdMsg).position().top - $("#ContentChat").position().top
                     }, 2000);
                     */

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
