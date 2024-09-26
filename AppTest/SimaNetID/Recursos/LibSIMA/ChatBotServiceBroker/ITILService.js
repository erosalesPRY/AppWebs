NetSuite.LiveChat.LinkService = function () {
    var urlPag = Page.Request.ApplicationPath + "/GestionReportes/UsuarioCompartido.aspx";
    var oColletionParams = new SIMA.ParamCollections();
    var oParam = new SIMA.Param("IdObj", 8);
    oColletionParams.Add(oParam);
    var oLoadConfig = {
        UrlPage: urlPag,
        ColletionParams: oColletionParams,
        //fnTemplate:function () {},
        fnOnComplete: function () {
            //alert('Completado');
        }
    };

    NetSuite.Manager.Broker.Persiana.Open(oLoadConfig);
}
