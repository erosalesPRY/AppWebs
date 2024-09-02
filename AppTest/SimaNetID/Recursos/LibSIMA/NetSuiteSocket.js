
//Instancia el objeto 
NetSuite.LiveChat = {};
Manager.Task.Excecute(function () {       

    NetSuite.LiveChat = new _NetSuite.Chat(SIMA.Utilitario.Helper.Configuracion.Leer("ConfigBase", "NetSuteSocket") + "name = " + UsuarioBE.UserName + " & platform=WebID" + " & formId=" + GlobalEntorno.PageName + " & userDestino=" + UsuarioBE.UserName);
    NetSuite.LiveChat.LinkService = null;//Funcion que permite el enlace de la implementacion LibBroker
    NetSuite.LiveChat.ContactBE = function (_Id, _Foto, _ApellidosYnombres, _IdMsg, _MessageHTML) {
        this.Id = _Id;
        this.Foto = _Foto;
        this.ApellidosYnombres = _ApellidosYnombres;
        this.IdMsg = _IdMsg;
        this.MessageHTML = _MessageHTML;
    }


    NetSuite.LiveChat.ITemplateMessaje = function (oContactoBE, Texto) {
        var strBE = "";
        return '<div class="chat-msg-text" Data="' + strBE.Serialized(oContactoBE) + '" id="' + oContactoBE.Id + '" > ' + Texto + '</div > ';
    }

    NetSuite.LiveChat.ItemplateChatContact = function (_oContactBE) {
            var ITContact = '<div class="chat-msg" >'
                + '   <div class="chat-msg-profile">'
                + '      <img class="chat-msg-img" src="' + _oContactBE.Foto + '" alt="" />'
                + '      <div class="chat-msg-date">Mensaje visto 1.22pm</div>'
                + '   </div>'
                + '   <div class="chat-msg-content" id=" ' + _oContactBE.IdMsg + '">'
                + _oContactBE.MessageHTML
                + '   </div>'
                + '</div> ';
            return ITContact;
        }

        
    NetSuite.LiveChat.ItemplateChatOwner = function (_oContactBE) {
            var ITContact = ' <div class="chat-msg owner" >'
                + '     <div class="chat-msg-profile">'
                + '          <img class="chat-msg-img" src="' + _oContactBE.Foto + '" alt="" />'
                + '          <div class="chat-msg-date">Mensaje visto 2.50pm</div>'
                + '     </div>'
                + '     <div class="chat-msg-content" id="' + _oContactBE.IdMsg + '">'
                + _oContactBE.MessageHTML
                + '     </div>'
                + '</div>';
            return ITContact;
    }

    NetSuite.LiveChat.EnviaMensaje = function (oContactSendBE) {
        var oContentChat = jNet.get('ContentChat');
        oContentChat.innerHTML += NetSuite.LiveChat.ItemplateChatOwner(oContactSendBE);
    }

    NetSuite.LiveChat.onopen = function () {
        var StatusUsu = jNet.get(document.getElementsByClassName('status-circle')[0]);
        StatusUsu.css('background-color', 'green');
        // " + Pagina + @".Chat.close();
    };

    NetSuite.LiveChat.onclose = function () {
        var StatusUsu = jNet.get(document.getElementsByClassName('status-circle')[0]);
        StatusUsu.css('background-color', 'red');
    };



    NetSuite.LiveChat.TemplateChat = function () {
        var MsgTemplate = '<div   style="width:100%;height:600px;">'
                        + ' </div>';

        var urlPag = Page.Request.ApplicationPath + "/General/ChatBox/EasyNetLiveChat.aspx";
            var oColletionParams = new SIMA.ParamCollections();
            var oParam = new SIMA.Param(Default.KEYIDGENERAL, 0);
            oColletionParams.Add(oParam);

            var oLoadConfig = {
                CtrlName: 'ContentChat',
                UrlPage: urlPag,
                ColletionParams: oColletionParams,
            };
            SIMA.Utilitario.Helper.LoadPageInCtrl(oLoadConfig);

        urlPag = Page.Request.ApplicationPath + "/General/ChatBox/EasyNetLiveChatFind.aspx"; 
        var oLoadConfig = {
            CtrlName: 'Buscar',
            UrlPage: urlPag,
            ColletionParams: oColletionParams,
        };
        SIMA.Utilitario.Helper.LoadPageInCtrl(oLoadConfig);


        return MsgTemplate;
    }
    NetSuite.LiveChat.Show = function (oContent) {

        var ConfigMsgb = {
            Titulo: 'Chat' 
            ,Width: '500px'
            , Descripcion: NetSuite.LiveChat.TemplateChat()
            , Icono: 'fa fa-paper-plane'
            , EventHandle: function (btn) {
                if (btn == 'OK') {
                }
            }
        };
        var oMsg = new SIMA.MessageBox(ConfigMsgb);
        oMsg.confirm();
    }

   

    NetSuite.LiveChat.Enum = {};
    NetSuite.LiveChat.Enum.Estado = {
                                    Conectado: "1"
                                    , NoConectado: "2"
                                    , SendMsg: "3"
    };


    //Ejecutar
   

}, 500, true);

