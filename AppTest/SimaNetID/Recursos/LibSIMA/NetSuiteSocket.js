
//Instancia el objeto 
NetSuite.LiveChat = {};

NetSuite.Manager = {};
NetSuite.Manager.Infinity = {};
NetSuite.Manager.Infinity.User = {};
NetSuite.Manager.Infinity.User.Contectado = false;
NetSuite.Manager.Infinity.InterfaceLoad = false;//Indica si la interface ID del chat esta cargado  y visible

NetSuite.Manager.Broker = {};
NetSuite.Manager.Broker.Persiana = {};
NetSuite.Manager.Broker.Wind = "BrokerWind";
NetSuite.Manager.Broker.WindContent = "BrokerContent";
NetSuite.Manager.Broker.Persiana.Open = function (oLoadConfig) {
    //Oculta la barra de usuarios
    /*jNet.get("LblContact").css("display", "none");
    jNet.get("LstContact").css("display", "none");*/
    oLoadConfig.CtrlName = NetSuite.Manager.Broker.WindContent;
    SIMA.Utilitario.Helper.LoadPageInCtrl(oLoadConfig);
    jNet.get(NetSuite.Manager.Broker.Wind).css("width", "100%").css("left", "0");

}
NetSuite.Manager.Broker.Persiana.Close = function () {
    //muestra la barra de usuarios
    /*jNet.get("LblContact").css("display", "block");
    jNet.get("LstContact").css("display", "block");*/
    jNet.get(NetSuite.Manager.Broker.Wind).css("width", "0%").css("left", "100%");
}


NetSuite.Manager.Infinity.WorkingFrame = function () {
    NetSuite.LiveChat = new _NetSuite.Chat(SIMA.Utilitario.Helper.Configuracion.Leer("ConfigBase", "NetSuteSocket") + "platform=WebID" + "&App=SIMANetSuiteWeb&name=" + UsuarioBE.UserName + "&CodPer=" + UsuarioBE.CodPersonal + "&IdContac=" + UsuarioBE.IdContacto);
    NetSuite.LiveChat.LinkService = null;//Funcion que permite el enlace de la implementacion LibBroker

   

    NetSuite.LiveChat.bubble = {};
    NetSuite.LiveChat.bubble.Style = {};

    NetSuite.LiveChat.bubble.Style.Father = "chat-msg";
    NetSuite.LiveChat.bubble.Style.FatherOwner = "chat-msg owner";
    NetSuite.LiveChat.bubble.Style.FatherOwnerSelect = ".owner .chat-msg-text-Select";

    NetSuite.LiveChat.bubble.Style.MsgText = "chat-msg-text";
    NetSuite.LiveChat.bubble.Style.MsgTextSelect = "chat-msg-text-Select";

    NetSuite.LiveChat.bubble.SelectBE = function (_Id, _Class, _IdChild, _ChildClass) {
        this.Id = _Id;
        this.Class = _Class;
        this.IdChild = _IdChild;
        this.ChildClass = _ChildClass;
    };
    var obubbleSelectBE = new NetSuite.LiveChat.bubble.SelectBE();

    NetSuite.LiveChat.bubble.Click = function (e) {
        var htmlBubble = jNet.get(e);
        var htmlChatMsg = jNet.get(htmlBubble.parentNode.parentNode);

        if (obubbleSelectBE.IdChild == undefined) {
            obubbleSelectBE.Id = htmlChatMsg.attr("id");
            obubbleSelectBE.Class = htmlChatMsg.attr("class");
            //Hijo
            obubbleSelectBE.IdChild = htmlBubble.attr("id");
            obubbleSelectBE.ChildClass = htmlBubble.attr("class");
            //Establecer el estilo de seleccion
            htmlBubble.attr("class", NetSuite.LiveChat.bubble.Style.MsgTextSelect);
        }
        else if (obubbleSelectBE.IdChild != htmlBubble.attr("id")) {
            var HtmlChatMsgOld = jNet.get(obubbleSelectBE.Id);
            HtmlChatMsgOld.attr("class", obubbleSelectBE.Class);
            var HtmlChildChatMsgOld = jNet.get(obubbleSelectBE.IdChild);
            HtmlChildChatMsgOld.attr("class", obubbleSelectBE.ChildClass);

            //Nueva seleccion
            obubbleSelectBE.Id = htmlChatMsg.attr("id");
            obubbleSelectBE.Class = htmlChatMsg.attr("class");
            //Hijo
            obubbleSelectBE.IdChild = htmlBubble.attr("id");
            obubbleSelectBE.ChildClass = htmlBubble.attr("class");
            //Establecer el estilo de seleccion
            htmlBubble.attr("class", NetSuite.LiveChat.bubble.Style.MsgTextSelect);
        }

        //ale();
    }

    //NetSuite.LiveChat.WindPopupInterface = jNet.get(document.getElementsByName('EasyPopupLiveChat')[0]);
    NetSuite.LiveChat.PaqueteBE = function (_IdContactoFrom, _IdCOntactoTo, _IdMiembro,_Foto, _IdMsg) {
        this.IdContactoFrom = _IdContactoFrom;
        this.IdContactoTo = _IdCOntactoTo;
        this.IdMiembro = _IdMiembro;
        this.Foto = _Foto;
        this.IdMsg = _IdMsg;
    }
    NetSuite.LiveChat.ContactBE = function (_IdContacto, _Foto, _Nombre, _Tipo, _IdMiembro, _Email, _CodPersonal, _IdEstado, _ColorEstado) {
        this.IdContacto = _IdContacto;
        this.Foto = _Foto;
        this.Nombre = _Nombre;
        this.Tipo = _Tipo;
        this.IdMiembro = _IdMiembro;
        this.Email = _Email;
        this.CodPersonal = _CodPersonal;
        this.IdEstado = _IdEstado;
        this.ColorEstado = _ColorEstado

    }

    NetSuite.LiveChat.MensajeBE = function (_ContactoFrom, _ContactoTo, _IdMsg, _MessageHTML, _ContenidoBE) {
        this.ContactoFrom = _ContactoFrom;
        this.ContactoTo = _ContactoTo;
        this.IdMsg = _IdMsg;
        this.AllContenidoBE = _ContenidoBE;
    }
    NetSuite.LiveChat.MensajeContenidoBE = function (_IdMsg, _IdContenido, _Texto, _AllLikes) {
        this.IdMsg = _IdMsg;
        this.IdContenido = _IdContenido;
        this.Texto = _Texto;
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
        var strEntity = "";
        EasyNetLiveChat.Panel.Body().innerHTML += NetSuite.LiveChat.ItemplateChatOwner(oMensajeBE);
        var oPaqueteBE = new NetSuite.LiveChat.PaqueteBE();
        oPaqueteBE.IdContactoFrom = oMensajeBE.ContactoFrom.IdContacto;
        oPaqueteBE.IdMiembro = oMensajeBE.ContactoFrom.IdMiembro;
        oPaqueteBE.IdContactoTo = oMensajeBE.ContactoTo.IdContacto;
        oPaqueteBE.IdMsg = oMensajeBE.IdMsg;

        NetSuite.LiveChat.send("PaqueteBE|"+ strEntity.toString().Serialized(oPaqueteBE));
    }

    NetSuite.LiveChat.onopen = function () {
        NetSuite.Manager.Infinity.User.Contectado = true;

        var StatusUsu = jNet.get(document.getElementsByClassName('status-circle')[0]);
        StatusUsu.css('background-color', 'green');
        StatusUsu.clear();
        //Actualiza el estado del contacto
        NetSuite.LiveChat.Data.UpDEstadoContacto(UsuarioBE.CodPersonal, 1);
        //Icono creado en el header para el control EasyNavigatorBarIconBE
       // jNet.get(document.getElementsByName('_Infinity')[0]).css("display", "none");//Icono en las opciones del usuario 
    };

    NetSuite.LiveChat.onmessage = function (evt) {
        if (NetSuite.Manager.Infinity.InterfaceLoad == true) {
            var ObjectResult = evt.data.split('|');
            //alert();
            switch (ObjectResult[0]) {
                case "chatPaqueteBE"://Adicional que confirma que se ha conectado
                    //en el evento OPen se debe implementar el aviso a los demas contactos que esta conectado
                    alert("Alguien se conecto");

                    break;
                case "PaqueteBE":
                    var oPaqueteBE = ObjectResult[1].toString().SerializedToObject();

                    if (((oPaqueteBE.IdContactoTo == UsuarioBE.IdContacto) && (oPaqueteBE.IdContactoFrom == oContactoDestinoBE.IdContacto)) && (oPaqueteBE.IdContactoFrom != UsuarioBE.IdContacto)) {
                       
                        EasyNetLiveChat.Data.LstMiembroGrupoSeleccionado(oPaqueteBE.IdContactoFrom).Rows.forEach(function (oDataRow, i) {
                            //Verificar si los usuarios estan conectados
                            var oContactBE = new NetSuite.LiveChat.ContactBE();
                            oContactBE.Foto = EasyNetLiveChat.FotoContacto(oDataRow.NRODOCUMENTO);
                            oContactBE.IdContacto = oDataRow.ID_CONTACT;
                            oContactBE.IdMiembro = oDataRow.ID_MIEMBRO;
                            oContactBE.Nombre = oDataRow.APELLIDOSYNOMBRES;

                            //if ((oContactBE.IdMiembro == oPaqueteBE.IdMiembro) ||(oContactBE.IdMiembro != oPaqueteBE.IdMiembro)) {
                             if (oContactBE.IdMiembro == oPaqueteBE.IdMiembro) {
                                var oMensajeBE = new NetSuite.LiveChat.MensajeBE();
                                oMensajeBE.ContactoFrom = oContactBE;
                                oMensajeBE.IdMsg = oPaqueteBE.IdMsg;
                                oMensajeBE.AllContenidoBE = EasyNetLiveChat.Data.ListaHistorialChatContenido(oPaqueteBE.IdMsg);

                                EasyNetLiveChat.Panel.Body().innerHTML += NetSuite.LiveChat.ItemplateChatContact(oMensajeBE);
                            }
                        });
                    }
                    else if ((oPaqueteBE.IdContactoTo == oContactoDestinoBE.IdContacto) && (oPaqueteBE.IdContactoFrom == oContactoSendDestinoSeleccionadoBE.IdContacto)) {
                        var oContactBE = new NetSuite.LiveChat.ContactBE();
                        oContactBE.Foto = oContactoSendDestinoSeleccionadoBE.Foto;
                        oContactBE.IdContacto = oContactoSendDestinoSeleccionadoBE.IdContacto;
                        oContactBE.IdMiembro = oContactoSendDestinoSeleccionadoBE.IdContacto;
                        oContactBE.Nombre = oContactoSendDestinoSeleccionadoBE.Nombre;

                        var oMensajeBE = new NetSuite.LiveChat.MensajeBE();
                        oMensajeBE.ContactoFrom = oContactBE;
                        oMensajeBE.IdMsg = oPaqueteBE.IdMsg;
                        oMensajeBE.AllContenidoBE = EasyNetLiveChat.Data.ListaHistorialChatContenido(oPaqueteBE.IdMsg);

                        EasyNetLiveChat.Panel.Body().innerHTML += NetSuite.LiveChat.ItemplateChatContact(oMensajeBE);
                    }
                    else if ((oPaqueteBE.IdContactoFrom == oContactoDestinoBE.IdContacto)) {//and contactoto del paquete sea igual al contacto destino seleccionado
                        
                        if ((oPaqueteBE.IdContactoTo == oContactoSendDestinoSeleccionadoBE.IdContacto) && (EasyNetLiveChat.IdMiembroGrupoSeleccionado != oPaqueteBE.IdMiembro)) {//si estoy en el grupo saber a quien se envia y que no muestre el mensaje al miembro del grupo que evia
                            //Buscar El contacto del grupo que envio
                            var oContactBE = new NetSuite.LiveChat.ContactBE();
                            //Buscar de los miembros del grupo quien envio el mensaje
                            EasyNetLiveChat.Data.LstMiembroGrupoSeleccionado(oPaqueteBE.IdContactoFrom).Select("ID_MIEMBRO", "=", oPaqueteBE.IdMiembro).forEach(function (oDataContactSend, x) {
                                oContactBE.Foto = EasyNetLiveChat.FotoContacto(oDataContactSend.NRODOCUMENTO);
                                oContactBE.IdContacto = oDataContactSend.ID_CONTACT;
                                oContactBE.IdMiembro = oDataContactSend.ID_MIEMBRO;
                                oContactBE.Nombre = oDataContactSend.APELLIDOSYNOMBRES;
                            });

                            var oMensajeBE = new NetSuite.LiveChat.MensajeBE();
                            oMensajeBE.ContactoFrom = oContactBE;
                            oMensajeBE.IdMsg = oPaqueteBE.IdMsg;
                            oMensajeBE.AllContenidoBE = EasyNetLiveChat.Data.ListaHistorialChatContenido(oPaqueteBE.IdMsg);

                            EasyNetLiveChat.Panel.Body().innerHTML += NetSuite.LiveChat.ItemplateChatOwner(oMensajeBE);
                        }


                    }

                          
                 break;
                case "chatCloseContact":
                    alert('Alguien salio del chat');
                    break;
            }
        }

    }


    NetSuite.LiveChat.ImgLatencia = function () {
        return jNet.create('img').attr("width", "30px")
                                .attr("height", "30px")
                                .attr("src", "../../Recursos/img/Infinity.gif");
    }
    NetSuite.LiveChat.onclose = function () {
        NetSuite.Manager.Infinity.User.Contectado = false;

        var StatusUsu = jNet.get(document.getElementsByClassName('status-circle')[0]);
        StatusUsu.css('background-color', 'transparent');
        StatusUsu.css('border', '2px solid transparent');
        StatusUsu.clear();
        StatusUsu.insert(NetSuite.LiveChat.ImgLatencia());
        NetSuite.LiveChat.Data.UpDEstadoContacto(UsuarioBE.CodPersonal, 2);//Close Listener o servicio NetSuiteSockry
        //jNet.get(document.getElementsByName('_Infinity')[0]).css("display", "block");
        //activa la latencia para verificar si el serviciios se volvio a levantar
        NetSuite.Manager.Infinity.CircleConeccion();
    };



    /*
     * tratamiento con datos
     * @returns
     */

    NetSuite.LiveChat.Data = {};
    NetSuite.LiveChat.Data.UpDEstadoContacto = function (CodPersonal, IdEstado) {
        var oEasyDataInterConect = new EasyDataInterConect();
        oEasyDataInterConect.MetododeConexion = ModoInterConect.WebServiceExterno;
        oEasyDataInterConect.UrlWebService = ConnectedService.PathNetCore + "HelpDesk/ChatBot/IChatBotManager.asmx";
        oEasyDataInterConect.Metodo = "ActualizaEstadoContacto";

        var oParamCollections = new SIMA.ParamCollections();
        var oParam = new SIMA.Param("CodPersonal", CodPersonal);
        oParamCollections.Add(oParam);
        oParam = new SIMA.Param("IdEstado", IdEstado, TipodeDato.Int);
        oParamCollections.Add(oParam);
        oParam = new SIMA.Param("UserName", UsuarioBE.UserName);
        oParamCollections.Add(oParam);

        oEasyDataInterConect.ParamsCollection = oParamCollections;

        var oEasyDataResult = new EasyDataResult(oEasyDataInterConect);
        oEasyDataResult.sendData();
    }





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
            , Width: '500px'
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
}

//Se utiliza para activar la conecion con NetSuiteSocket y activar los servicios del chat en linea
NetSuite.Manager.Infinity.CircleConeccion = function () {
    Manager.Task.Excecute(function () {
        NetSuite.Manager.Infinity.WorkingFrame();
        /*if (NetSuite.Manager.Infinity.User.Contectado == false) {
            NetSuite.Manager.Infinity.CircleConeccion();
        }*/
    }, 400, true);


}

NetSuite.Manager.Infinity.CircleConeccion();
