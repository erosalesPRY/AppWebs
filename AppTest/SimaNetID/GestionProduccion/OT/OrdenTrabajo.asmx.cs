using SIMANET_W22R.srvGestionProduccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.PeerToPeer;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;
using System.Diagnostics;
using EasyControlWeb;

namespace SIMANET_W22R.GestionProduccion.OT
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
        string s_Ambiente = EasyUtilitario.Helper.Configuracion.Leer("Seguridad", "Ambiente");

        [WebMethod]
        public DataTable DetalleGastoPryOtSinFac(string CENTRO_OPERATIVO, string DIVISION, string PROYECTO, string sAnio, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_detg_pry_ot_sinfact(CENTRO_OPERATIVO, DIVISION, PROYECTO, sAnio, UserName);
            dt.TableName = "SP_DetG_PRY_OT_SINFACT";
            return dt;
        }
        [WebMethod]
        public DataTable DetalleGastoPryOtFac(string N_CEO, string V_CODDIV, string V_CODPRY, string V_PERIODO, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_detalle_gasto_pry_ot_fac(N_CEO, V_CODDIV, V_CODPRY, V_PERIODO, UserName);
            dt.TableName = "SP_Detalle_Gasto_Pry_OT_Fac";
            return dt;
        }
        [WebMethod]
        public DataTable ListaOtsDq(string N_CEO, string V_CODDIV, string D_FECHAINI,string D_FECHAFIN, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_lista_ots_dq(D_FECHAFIN, D_FECHAINI, N_CEO, V_CODDIV, UserName);
            dt.TableName = "SP_Lista_Ots_Dq";
                return dt;
        }
        [WebMethod]
        public DataTable CabeceraOt(string N_CEO, string V_CODDIV, string V_NROOTS, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_cabecera_ot(N_CEO, V_CODDIV, V_NROOTS, UserName);
            dt.TableName = "SP_Cabecera_Ot";
                return dt;
        }
        [WebMethod]
        public DataTable ActividadOt(string N_CEO, string V_CODDIV, string V_NROOTS, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_actividad_ot(N_CEO, V_CODDIV, V_NROOTS, UserName);
            dt.TableName = "SP_Actividad_OT";
                return dt;
        }
        [WebMethod]
        public DataTable EstadoOt(string N_CEO, string V_CODDIV, string D_FECHAINI,string D_FECHAFIN ,  string V_CODSTD, string V_NROOTS, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_lista_estado_ot(D_FECHAFIN, D_FECHAINI, N_CEO, V_CODDIV, V_CODSTD, V_NROOTS, UserName);
            dt.TableName = "SP_Lista_Estado_Ot";
                return dt;
        }
        [WebMethod]
        public DataTable DetalleGastoPryOtFacsu(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_det_gasto_pry_ot_facsu(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
            dt.TableName = "SP_DET_GASTO_PRY_OT_FACSU";
                return dt;
        }
        [WebMethod]
        public DataTable ActividadesJg(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string N_OPCION, string V_CODDIV, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_actividades_jg(D_FECHAFIN, D_FECHAINI, N_CEO, N_OPCION, V_CODDIV, UserName);
            dt.TableName = "SP_Actividades_Jg";
                return dt;
        }
        [WebMethod]
        public DataTable ActividadesJg2(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string N_OPCION, string V_CODDIV, string V_CODTLLR, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_actividades_jg2(D_FECHAFIN, D_FECHAINI, N_CEO, N_OPCION, V_CODDIV, V_CODTLLR, UserName);
            dt.TableName = "SP_Actividades_Jg2";
                return dt;
        }
        [WebMethod]
        public DataTable GastoOtsx(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string V_CODPROY, string V_NROOTS, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_gasto_otsx(D_FECHAFIN, D_FECHAINI, N_CEO, V_CODDIV, V_CODPROY, V_NROOTS, UserName);
            dt.TableName = "SP_Gasto_OtsX";
                return dt;
        }
        [WebMethod]
        public DataTable ActividadOtProy(string N_CEO, string V_CODDIV, string V_CODPRY, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_actividad_ot_proy(N_CEO, V_CODDIV, V_CODPRY, UserName);
            dt.TableName = "SP_Actividad_OT_PROY";
                return dt;
        }
        [WebMethod]
        public DataTable ActaConfSolmn(string V_CODUND, string V_NROOTS, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_acta_conf_solmn(V_CODUND, V_NROOTS, UserName);
            dt.TableName = "SP_Acta_Conf_SolMn";
                return dt;
        }
        [WebMethod]
        public DataTable ActaConfInfGen(string V_CODUND, string V_NROOTS, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_acta_conf_inf_gen(V_CODUND, V_NROOTS, UserName);
            dt.TableName = "SP_Acta_Conf_Inf_Gen";
                return dt;
        }
        [WebMethod]
        public DataTable DetalleOtsRecursos(string N_CEO, string V_CATVCRV, string V_CODDIV, string V_NROOTS, string V_TIPRCS, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_detalle_ots_recursos(N_CEO, V_CATVCRV, V_CODDIV, V_NROOTS, V_TIPRCS, UserName);
            dt.TableName = "SP_Detalle_Ots_Recursos";
                return dt;
        }
        [WebMethod]
        public DataTable DetalleGastoPryOTsinFactsu(string V_CENTRO_OPERATIVO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_det_gasto_pry_ot_sin_factsu(V_CENTRO_OPERATIVO, V_DIVISION, V_PROYECTO, UserName);
            dt.TableName = "SP_DET_GASTO_PRY_OT_SIN_FACTSU";
            return dt;
        }
        [WebMethod]
        public DataTable DetalleOtsRecursosPry(string N_CEO, string V_CODATV, string V_CODDIV, string V_CODPROY, string V_NROOTS, string V_TIPRCS, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_detalle_ots_recursos_pryc(N_CEO, V_CODATV, V_CODDIV, V_CODPROY, V_NROOTS, V_TIPRCS, UserName);
            dt.TableName = "SP_Detalle_Ots_Recursos_Pryct";
            return dt;
        }
        [WebMethod]
        public DataTable Listar_acta_conf(string V_CODUND, string V_NROOTS, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_acta_conf(V_CODUND, V_NROOTS, UserName);
            dt.TableName = "SP_Acta_Conf";
            return dt;
        }

        /*
        [WebMethod]
        public DataTable DetalleOtsRecursos(string N_CEO, string V_CODATV, string V_CODDIV, string V_CODPROY, string V_NROOTS, string V_TIPRCS, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_detalle_ots_recursos_pryc(N_CEO, V_CODATV, V_CODDIV, V_CODPROY, V_NROOTS, V_TIPRCS, UserName);
            dt.TableName = "SP_Detalle_Ots_Recursos_Pryct";
                return dt;
        }
        */
        [WebMethod]
        public string HelloWorld()
        {
                return "Hola a todos";
        }
    }
}
