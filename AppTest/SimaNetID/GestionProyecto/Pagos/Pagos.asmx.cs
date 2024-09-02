using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using SIMANET_W22R.srvGestionProyecto;
using System.Data;

namespace SIMANET_W22R.GestionProyecto.Pagos
{
    /// <summary>
    /// Descripción breve de Pagos
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Pagos : System.Web.Services.WebService
    {
        DataTable dt;

        [WebMethod]
        public DataTable Listar_resumen_ose_partida(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            ProyectoSoapClient oPy = new ProyectoSoapClient();
            dt = oPy.Listar_resumen_ose_partida(N_CEO,V_CODDIV,V_CODPRY,V_PERIODO,UserName);
            dt.TableName = "SP_Resumen_Ose_Partida";
            return dt;
        }

        [WebMethod]
        public DataTable Listar_det_gto_mat_pry_ot_partid(string N_CEO, string V_CODDIV, string V_CODPRY, string UserName)
        {
            ProyectoSoapClient oPy = new ProyectoSoapClient();
            dt = oPy.Listar_det_gto_mat_pry_ot_partid( N_CEO,V_CODDIV,V_CODPRY,UserName);
            dt.TableName = "SP_DET_GTO_MAT_PRY_OT_PARTIDA";
            return dt;
        }
        [WebMethod]
        public DataTable Listar_det_gast_pry_ot_oco_ate_acu(string D_AÑO, string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            ProyectoSoapClient oPy = new ProyectoSoapClient();
            dt = oPy.Listar_det_gast_pry_ot_oco_ate_acu(D_AÑO,V_CENTRO_OPERATIVO,V_DIVISION,V_PROYECTO,UserName);
            dt.TableName = "SP_DET_GAST_PRY_OT_OCO_ATE_ACU";
            return dt;
        }

        [WebMethod]
        public DataTable Listar_gastos_proyectos_ot_v3(string N_CEO, string V_CODDIV, string V_CODPRY, string UserName)
        {
            ProyectoSoapClient oPy = new ProyectoSoapClient();
            dt = oPy.Listar_gastos_proyectos_ot_v3(N_CEO,V_CODDIV,V_CODPRY,UserName);
            dt.TableName = "SP_Gastos_Proyectos_OT_v3";
            return dt;
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
    }
}
