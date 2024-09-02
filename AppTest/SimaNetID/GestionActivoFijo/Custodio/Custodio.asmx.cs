using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SIMANET_W22R.srvLog_ActivoFijo;
using System.Data;

namespace SIMANET_W22R.GestionActivoFijo.Custodio
{
    /// <summary>
    /// Descripción breve de Custodio
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Custodio : System.Web.Services.WebService
    {
        DataTable dt;

        [WebMethod]
        public DataTable Listar_inventario_activosxcustod(string COD_EMPE, string COD_ROL, string TIPOACTV, string UserName)
        {
            ActivoFijoSoapClient oC = new ActivoFijoSoapClient();
            dt = oC.Listar_inventario_activosxcustod(COD_EMPE,COD_ROL,TIPOACTV,UserName);
            dt.TableName = "SP_Inventario_ActivosxCustodio";
            return dt;
        }

        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
    }
}
