using SIMANET_W22R.srvGestionProduccion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.PeerToPeer;
using System.Security.Cryptography;
using System.Web;
using System.Web.Services;

namespace SIMANET_W22R.GestionProduccion.Mob
{
    /// <summary>
    /// Descripción breve de ManoObra
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class ManoObra : System.Web.Services.WebService
    {

        DataTable dt;

        [WebMethod]
        public DataTable Vacaciones(string D_PERIODO, string V_CO, string V_ROL, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_vacaciones(D_PERIODO, V_CO, V_ROL, UserName);
            //dt.TableName = "PKG_ACTIVO_FIJO.SP_BIENES_TOMA_INVENTARIO;1";
            dt.TableName = "SP_Vacaciones";
            return dt;
        }
        [WebMethod]
        public DataTable NovedadesPlanilla(string N_CEO, string V_CODUNS, string V_PERIODO, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_novedades_paus(N_CEO, V_CODUNS, V_PERIODO, UserName);
            //dt.TableName = "PKG_ACTIVO_FIJO.SP_BIENES_TOMA_INVENTARIO;1";
            dt.TableName = "SP_Novedades_pAus";
            return dt;
        }
        [WebMethod]
        public DataTable MobxFecha(string D_FECHAFIN, string D_FECHAINI, string N_CEO, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_mob_x_fecha(D_FECHAFIN, D_FECHAINI, N_CEO, UserName);
                //dt.TableName = "PKG_ACTIVO_FIJO.SP_BIENES_TOMA_INVENTARIO;1";
            dt.TableName = "SP_Mob_X_Fecha";
                return dt;
            }
        //SP_Lista_Saldo_MO
        [WebMethod]
        public DataTable ListaSaldoMo(string N_CEO, string V_CATVCRV, string V_CODDIV, string V_CODPROY, string V_NROOTS, string UserName)
        {
            ProduccionSoapClient oPD = new ProduccionSoapClient();
            dt = oPD.Listar_lista_saldo_mo(N_CEO, V_CATVCRV, V_CODDIV, V_CODPROY, V_NROOTS, UserName);
                //dt.TableName = "PKG_ACTIVO_FIJO.SP_BIENES_TOMA_INVENTARIO;1";
            dt.TableName = "SP_Lista_Saldo_MO";
                return dt;
            }
        [WebMethod]
        public string HelloWorld()
        {
                return "Hola a todos";
        }
    }
}
