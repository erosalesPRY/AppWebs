using SIMANET_W22R.srvGestionLogistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SIMANET_W22R.GestionLogistica.Servicios
{
    /// <summary>
    /// Descripción breve de Servicios
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Servicios : System.Web.Services.WebService
    {
        DataTable dt;
         
        [WebMethod]
        public DataTable Catalogo_Servicios_SR(string CLASE, string UserName)
        {

            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_Catalogo_Servicios_SR(CLASE, UserName);
            dt.TableName = "SP_Catalogo_Servicios_SR";

            return dt;
        }
    }
}
