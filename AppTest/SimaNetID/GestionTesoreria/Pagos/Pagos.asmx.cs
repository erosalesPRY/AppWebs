using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using SIMANET_W22R.srvGestionTesoreria;

namespace SIMANET_W22R.GestionTesoreria.Pagos
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
        public DataTable Listar_cheques_giradosxprove_res(string D_AÑO, string D_MES, string V_CENTRO_OPERATIVO, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            TesoreriaSoapClient ts = new TesoreriaSoapClient();
            dt = ts.Listar_cheques_giradosxprove_res(D_AÑO, D_MES, V_CENTRO_OPERATIVO, V_RELACION_DESDE, V_RELACION_HASTA, UserName);
            dt.TableName = "SP_Cheques_GiradosxProve_Res";
            return dt;
        }
        [WebMethod]
        public DataTable Listar_cheques_giradosxprove_det(string V_CENTRO_OPERATIVO, string D_FECHA_HASTA, string D_FECHA_DESDE, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            TesoreriaSoapClient ts = new TesoreriaSoapClient();
            dt = ts.Listar_cheques_giradosxprove_det( D_FECHA_DESDE,D_FECHA_HASTA,V_CENTRO_OPERATIVO,V_RELACION_DESDE,V_RELACION_HASTA,UserName);
            dt.TableName = "SP_Cheques_GiradosxProve_Det";
            return dt;
        }
        [WebMethod]
        public DataTable Listar_cheques_emitidos_resumen(string D_AÑO, string V_CENTRO_OPERATIVO, string UserName)
        {
            TesoreriaSoapClient ts = new TesoreriaSoapClient();
            dt = ts.Listar_cheques_emitidos_resumen(D_AÑO,V_CENTRO_OPERATIVO,UserName);
            dt.TableName = "SP_Cheques_Emitidos_Resumen";
            return dt;
        }
        [WebMethod]
        public DataTable Listar_cheques_por_observacion(string V_CENTRO_OPERATIVO, string D_FECHA_DESDE, string D_FECHA_HASTA, string V_OBSERVACION, string UserName)
        {
            TesoreriaSoapClient ts = new TesoreriaSoapClient();
            dt = ts.Listar_cheques_por_observacion(D_FECHA_DESDE,D_FECHA_HASTA,V_CENTRO_OPERATIVO,V_OBSERVACION,UserName);
            dt.TableName = "SP_Cheques_por_Observacion";
            return dt;
        }
        [WebMethod]
        public DataTable Listar_cheque_giradoxnum(string V_CENTRO_OPERATIVO, string V_CHEQUE_NUMERO, string UserName)
        {
            TesoreriaSoapClient ts = new TesoreriaSoapClient();
            dt = ts.Listar_cheque_giradoxnum(V_CENTRO_OPERATIVO,V_CHEQUE_NUMERO,UserName);
            dt.TableName = "SP_Cheque_GiradoxNum";
            return dt;
        }
        
        [WebMethod]
        public DataTable Listar_lote_de_detrac_por_doc(string V_CENTRO_OPERATIVO, string V_NUMERO_DE_LOTE, string UserName)
        {
            TesoreriaSoapClient ts = new TesoreriaSoapClient();
            dt = ts.Listar_lote_de_detrac_por_doc( V_CENTRO_OPERATIVO,V_NUMERO_DE_LOTE,UserName);
            dt.TableName = "SP_Lote_de_Detrac_por_Doc";
            return dt;
        }
        [WebMethod]
        public DataTable Listar_fact_pagar_pendientes(string V_RECURSO, string V_RUC, string V_PROYECTO, string UserName)
        {
            TesoreriaSoapClient ts = new TesoreriaSoapClient();
            dt = ts.Listar_fact_pagar_pendientes(V_RECURSO,V_RUC,V_PROYECTO,UserName);
            dt.TableName = "SP_Fact_Pagar_Pendientes";
            return dt;
        }
        [WebMethod]
        public DataTable Listar_fact_por_pagar_doc(string D_AÑO, string D_MES, string V_RELACION_DESDE, string V_RELACION_HASTA, string UserName)
        {
            TesoreriaSoapClient ts = new TesoreriaSoapClient();
            dt = ts.Listar_fact_por_pagar_doc(D_AÑO,D_MES,V_RELACION_DESDE,V_RELACION_HASTA,UserName);
            dt.TableName = "SP_Fact_por_Pagar_Doc";
            return dt;
        }
        
        [WebMethod]
        public DataTable Listar_facturas_por_pagar_total(string UserName)
        {
            TesoreriaSoapClient ts = new TesoreriaSoapClient();
            dt = ts.Listar_facturas_por_pagar_total(UserName);
            dt.TableName = "SP_Facturas_por_Pagar_Total";
            return dt;
        }
        [WebMethod]
        public string HelloWorld()
        {
            return "Hola a todos";
        }
    }
}
