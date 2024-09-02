using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using SIMANET_W22R.srvGestionTesoreria;

namespace SIMANET_W22R.GestionTesoreria.Cobros
{
    /// <summary>
    /// Descripción breve de Cobros
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Cobros : System.Web.Services.WebService
    {
        DataTable dt;

        [WebMethod]
        public DataTable Listar_ingresos_contabilizados(string D_FECHA_DESDE, string D_FECHA_HASTA, string V_CENTRO_OPERATIVO, string V_CONCEPTO, string V_DESDE, string V_EMPRESA_DESDE, string V_EMPRESA_HASTA, string V_HASTA, string V_MONEDA, string UserName)
        {
            TesoreriaSoapClient ts = new TesoreriaSoapClient();
            dt = ts.Listar_ingresos_contabilizados(D_FECHA_DESDE,D_FECHA_HASTA,V_CENTRO_OPERATIVO,V_CONCEPTO,V_DESDE,V_EMPRESA_DESDE,V_EMPRESA_HASTA,V_HASTA,V_MONEDA,UserName);
            dt.TableName = "SP_Ingresos_Contabilizados";
            return dt;
        }
        
        [WebMethod]
        public DataTable Listar_ventas_x_orden_trabajo(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_NUMERO_OT, string UserName)
        {
            TesoreriaSoapClient ts = new TesoreriaSoapClient();
            dt = ts.Listar_ventas_x_orden_trabajo(V_CENTRO_OPERATIVO,V_DIVISION,V_NUMERO_OT,UserName);
            dt.TableName = "SP_Ventas_X_Orden_Trabajo";
            return dt;
        }
        
        [WebMethod]
        public DataTable Listar_folios_pendientes_o7(string D_AÑO, string D_MES, string UserName)
        {
            TesoreriaSoapClient ts = new TesoreriaSoapClient();
            dt = ts.Listar_folios_pendientes_o7(D_AÑO,D_MES,UserName);
            dt.TableName = "SP_Folios_Pendientes_O7";
            return dt;
        }
        [WebMethod]
        public DataTable Listar_fact_cobrar_sector_privado(string UserName)
        {
            TesoreriaSoapClient ts = new TesoreriaSoapClient();
            dt = ts.Listar_fact_cobrar_sector_privado(UserName);
            dt.TableName = "SP_Fact_Cobrar_Sector_Privado";
            return dt;
        }
        
        [WebMethod]
        public DataTable Listar_fact_cobrar_sector_marina(string UserName)
        {
            TesoreriaSoapClient ts = new TesoreriaSoapClient();
            dt = ts.Listar_fact_cobrar_sector_marina(UserName);
            dt.TableName = "SP_Fact_Cobrar_Sector_Marina";
            return dt;
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
    }
}
