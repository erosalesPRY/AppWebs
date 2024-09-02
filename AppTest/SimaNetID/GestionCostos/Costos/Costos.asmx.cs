using SIMANET_W22R.srvGestionCostos;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace SIMANET_W22R.GestionCostos.Costos
{
    /// <summary>
    /// Descripción breve de Costos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Costos : System.Web.Services.WebService
    {
        DataTable dt;

        [WebMethod]
        public DataTable Listar_costo_prod_linea_neg_resu(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_LINEA_NEGOCIO, string UserName)
        {
            CostosSoapClient oC = new CostosSoapClient();
            dt = oC.Listar_costo_prod_linea_neg_resu(D_AÑO,D_MES,V_CENTRO_OPERATIVO,V_LINEA_NEGOCIO,UserName);
            dt.TableName = "SP_COSTO_PROD_LINEA_NEG_RESU";
            return dt;
        }
        
        [WebMethod]
        public DataTable Listar_costo_prod_linea_neg_det(string V_CENTRO_OPERATIVO, string V_LINEA_NEGOCIO,string D_AÑO, string D_MES, string UserName)
        {
            CostosSoapClient oC = new CostosSoapClient();
            dt = oC.Listar_costo_prod_linea_neg_det(D_AÑO,D_MES,V_CENTRO_OPERATIVO,V_LINEA_NEGOCIO,UserName);
            dt.TableName = "SP_Costo_Prod_Linea_Neg_Det";
            return dt;
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
    }
}
