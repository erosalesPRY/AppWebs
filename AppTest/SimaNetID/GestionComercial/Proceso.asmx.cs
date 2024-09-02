using SIMANET_W22R.srvCliente;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SIMANET_W22R.GestionComercial
{
    /// <summary>
    /// Descripción breve de Proceso
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Proceso : System.Web.Services.WebService
    {

        [WebMethod]
        public DataTable BuscarCliente(string RazonSocialCliente,string UserName)
        {
            return (new ClienteSoapClient()).BuscarCliente(RazonSocialCliente, UserName);
        }
    }
}
