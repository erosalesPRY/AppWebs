
//Instancia el objeto 
NetSuite.LiveChat = {};
Manager.Task.Excecute(function () {       

    NetSuite.LiveChat = new _NetSuite.Chat(SIMA.Utilitario.Helper.Configuracion.Leer("ConfigBase", "NetSuteSocket") + "name = " + UsuarioBE.UserName + " & platform=WebID" + " & formId=" + GlobalEntorno.PageName + " & userDestino=" + UsuarioBE.UserName);
    NetSuite.LiveChat.LinkService = null;//Funcion que permite el enlace de la implementacion LibBroker

    NetSuite.LiveChat.bubble = {};
    NetSuite.LiveChat.bubble.Click = function (e) {
        var BubbleSelected = jNet.get(e);
        //  BubbleSelected.attr("class", "chat-msg-content-Selected");
        BubbleSelected.css("background-color", "red");
    }

    //NetSuite.LiveChat.WindPopupInterface = jNet.get(document.getElementsByName('EasyPopupLiveChat')[0]);
    NetSuite.LiveChat.ContactBE = function (_IdContacto, _Foto, _Nombre, _Tipo, _IdMiembro, _Email) {
        this.IdContacto = _IdContacto;
        this.Foto = _Foto;
        this.Nombre = _Nombre;
        this.Tipo = _Tipo;
        this.IdMiembro = _IdMiembro;
        this.Email = _Email;

    }

    NetSuite.LiveChat.MensajeBE = function (_ContactoFrom, _ContactoTo, _IdMsg, _MessageHTML, _ContenidoBE) {
        this.ContactoFrom = _ContactoFrom;
        this.ContactoTo = _ContactoTo;
        this.IdMsg = _IdMsg;
        this.AllContenidoBE = _ContenidoBE;
        //this.MessageHTML = _MessageHTML;
    }
    NetSuite.LiveChat.MensajeContenidoBE = function (_IdMsg, _IdContenido, _Texto,_AllLikes) {
        this.IdMsg = _IdMsg;
        this.IdContenido = _IdContenido;
        this.Texto = _Texto;
        //this.htmBadgetLike = _htmBadgetLike;
        this.AllLikes = _AllLikes;
    }
    NetSuite.LiveChat.MensajeContenidoLikesBE = function (_IdContenido, _NroLike, _Icono) {
        this.IdContenido = _IdContenido;
        this.NroLikes = _NroLike;
        this.Icono = _Icono;
    }



    NetSuite.LiveChat.ITemplateMessaje = function (oContactoBE, Texto) {
        var strBE = "";
        return '<div class="chat-msg-text" Data="' + strBE.Serialized(oContactoBE) + '" id="' + oContactoBE.IdMsg + '" > ' + Texto + '</div > ';
    }

    /**
     * 
     * template de mensajes
     * 
     */
    NetSuite.LiveChat.ItemplateChatContact = function (_MensajeBE) {
        var oContactoBE = _MensajeBE.ContactoFrom;
        var HtmlMsgContenido = "";
        _MensajeBE.AllContenidoBE.forEach(function (oContenidoBE, i) {
            //HtmlMsgContenido += EasyNetLiveChat.HtmlChatContenido(oContenidoBE);
            HtmlMsgContenido += EasyNetLiveChat.ItemplateChatContenido(oContenidoBE);
            
        });
                var ITContact = '<div class="chat-msg" id="' + "bubble_" + _MensajeBE.IdMsg + '"   >'
                            + '   <div class="chat-msg-profile">'
                            + '      <img class="chat-msg-img" src="' + oContactoBE.Foto + '" alt="" />'
                            + '      <div class="chat-msg-date">Mensaje visto 1.22pm</div>'
                            + '   </div>'
                            + '   <div class="chat-msg-content" id="' + _MensajeBE.IdMsg + '"  >'
                            + HtmlMsgContenido
                            + '   </div>'
                            + '</div> ';
        return ITContact;
    }

        
    NetSuite.LiveChat.ItemplateChatOwner = function (_MensajeBE) {
        var oContactoBE = _MensajeBE.ContactoFrom;
        var HtmlMsgContenido = "";
        _MensajeBE.AllContenidoBE.forEach(function (oContenidoBE, i) {
            // HtmlMsgContenido += EasyNetLiveChat.HtmlChatContenido(oContenidoBE);
            HtmlMsgContenido += EasyNetLiveChat.ItemplateChatContenido(oContenidoBE); 
        });

        var ITContact = ' <div class="chat-msg owner" id="' + "bubble_" + _MensajeBE.IdMsg + '"   >'
                            + '     <div class="chat-msg-profile">'
                            + '          <img class="chat-msg-img" src="' + oContactoBE.Foto + '" alt="" />'
                            + '          <div class="chat-msg-date">Mensaje visto 2.50pm</div>'
                            + '     </div>'
                            + '     <div class="chat-msg-content"   id="' + _MensajeBE.IdMsg + '" >'
                            + HtmlMsgContenido
                            + '     </div>'
                            + '</div>';
            return ITContact;
    }

    EasyNetLiveChat.ItemplateChatContenido = function (oContenidoBE) {
        var cmll = "\"";
        var strBE = "";
        // var htmlLike = EasyNetLiveChat.HtmlChatContenidoLikes(oContenidoBE.AllLikes);
        var htmlLike = EasyNetLiveChat.ItemplateChatContenidoLikes(oContenidoBE.AllLikes);
        strBE = strBE.Serialized(oContenidoBE).Replace(cmll, "'");
        return '         <div class="chat-msg-text"  Data="' + strBE + '"  id="' + oContenidoBE.IdContenido + '" onclick="NetSuite.LiveChat.bubble.Click(this);"   >' + oContenidoBE.Texto + ((htmlLike == undefined) ? "" : htmlLike) + '</div>';
    }
    EasyNetLiveChat.ItemplateChatContenidoLikes = function (AllMensajeContenidoLikes) {
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



    /**
     * 
     * 
     */

    NetSuite.LiveChat.EnviaMensaje = function (oMensajeBE) {
        EasyNetLiveChat.Panel.Body().innerHTML += NetSuite.LiveChat.ItemplateChatOwner(oMensajeBE);
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
   

}, 400, true);

