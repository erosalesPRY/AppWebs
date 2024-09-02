using SIMANET_W22R.srvGestionProduccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.PeerToPeer;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;

namespace SIMANET_W22R.GestionProduccion.Valorizacion
{
    /// <summary>
    /// Descripción breve de Valorizacion
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Valorizacion : System.Web.Services.WebService
    {

        DataTable dt;
        [WebMethod]
        public DataTable EstActividad01(string N_CEO, string V_CODDIV, string V_NROVAL, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_est_actividad_01(N_CEO, V_CODDIV, V_NROVAL, UserName);
            dt.TableName = "SP_Est_Actividad_01";
            return dt;
        }
        [WebMethod]
        public DataTable ListaOtsSe01(string V_ANIO, string V_OPCION, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_lista_ots_se_01(V_ANIO, V_OPCION, UserName);
            dt.TableName = "SP_lista_ots_se_01";
            return dt;
        }
        [WebMethod]
        public DataTable Valorizacionr01(string D_FECHAFIN, string D_FECHAINI, string V_CO, string V_DIVISION, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_valorizacionr01(D_FECHAFIN, D_FECHAINI, V_CO, V_DIVISION, UserName);
            dt.TableName = "SP_valorizacionR01";
                return dt;
        }
        [WebMethod]
        public DataTable Valorizacionrproy(string V_CO, string V_DIVISION, string V_OT, string V_PROYECTO, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_valorizacionrproy(V_CO, V_DIVISION, V_OT, V_PROYECTO, UserName);
            dt.TableName = "SP_valorizacionRProy";
                return dt;
        }

        [WebMethod]
        public DataTable Valorizacionrproy02(string D_FECHAFIN, string D_FECHAINI, string V_CO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_valorizacionrproy_02(D_FECHAFIN, D_FECHAINI, V_CO, V_DIVISION, V_PROYECTO, UserName);
            dt.TableName = "SP_valorizacionRProy_02";
                return dt;
        }
 
        [WebMethod]
        public DataTable Valorizacionrunidad(string N_CEO, string V_CODCLI, string V_CODDIV, string V_CODUND, string V_PERIODO, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_valorizacionrunidad(N_CEO, V_CODCLI, V_CODDIV, V_CODUND, V_PERIODO, UserName);
            dt.TableName = "SP_ValorizacionRUnidad";
                return dt;
        }
        [WebMethod]
        public DataTable ValorizacionR(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string V_CODDIV, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_valorizacionr( D_FECHAFIN,D_FECHAINI,N_CEO,V_CODDIV,UserName);
            dt.TableName = "SP_ValorizacionR";
            return dt;
        }
        [WebMethod]
        public DataTable ValorizacionRxAN(string N_CEO, string V_CODDIV, string V_PAAMM, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_valorizacionrxan(N_CEO,V_CODDIV,V_PAAMM,UserName);
            dt.TableName = "SP_ValorizacionRxAN";
            return dt;
        }
        [WebMethod]
        public DataTable Valorizacionrproy01(string V_CO, string V_DIVISION, string V_PROYECTO, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_valorizacionrproy01(V_CO, V_DIVISION, V_PROYECTO, UserName);
            dt.TableName = "SP_valorizacionRProy01";
            return dt;
        }
        [WebMethod]
        public DataTable Listar_est_actividad(string N_CEO, string V_CODDIV, string V_NROVAL, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_est_actividad(N_CEO, V_CODDIV, V_NROVAL, UserName);
            dt.TableName = " SP_Est_Actividad";
            return dt;
        }
        [WebMethod]
        public string HelloWorld()
        {
             return "Hola a todos";
        }
    }
}
