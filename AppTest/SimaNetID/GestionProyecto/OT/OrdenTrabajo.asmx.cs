using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SIMANET_W22R.srvGestionProyecto;
using System.Data;

namespace SIMANET_W22R.GestionProyecto.OT
{
    /// <summary>
    /// Descripción breve de OrdenTrabajo
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class OrdenTrabajo : System.Web.Services.WebService
    {
        DataTable dt;

        [WebMethod]
        public DataTable Listar_detg_pry_ot_sinfact(string CENTRO_OPERATIVO, string DIVISION, string PROYECTO,string sAnio, string UserName)
        {
            ProyectoSoapClient oPy = new ProyectoSoapClient();
            dt = oPy.Listar_detg_pry_ot_sinfact(CENTRO_OPERATIVO,DIVISION,PROYECTO, sAnio, UserName);
            dt.TableName = "SP_DETG_PRY_OT_SINFACT";
            return dt;
        }
       
    }
}
