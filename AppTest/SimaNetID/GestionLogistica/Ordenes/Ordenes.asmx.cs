using iTextSharp.text.pdf.codec.wmf;
using SIMANET_W22R.srvGestionLogistica;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.PeerToPeer;
using System.Web;
using System.Web.Services;
using static EasyControlWeb.EasyUtilitario.Enumerados.MessageBox;

namespace SIMANET_W22R.GestionLogistica.Ordenes
{
    /// <summary>
    /// Descripción breve de Ordenes
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Para permitir que se llame a este servicio web desde un script, usando ASP.NET AJAX, quite la marca de comentario de la línea siguiente. 
    // [System.Web.Script.Services.ScriptService]
    public class Ordenes : System.Web.Services.WebService
    {
        DataTable dt;

        [WebMethod]
        public DataTable OrdenesCompraEmitidasContraloria(string Centro_Operativo, string Procedencia, string Tipo, string Estado, string Fecha_Inicial, string Fecha_Final, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_OcoEmiContral(Centro_Operativo, Procedencia, Tipo, Estado, Fecha_Inicial, Fecha_Final,
                UserName);
            dt.TableName = "SP_OcoEmiContral";

            return dt;
        }

        [WebMethod]
        public DataTable OrdenesCompraPorReposicion(string DESTINO_COMPRA, string FECHA_MOVIMIENTO_INICIO, string FECHA_MOVIMIENTO_TERMINO, string MATERIAL_FINAL,
            string MATERIAL_INICIAL, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_ordcompraporrepo(DESTINO_COMPRA, FECHA_MOVIMIENTO_INICIO, FECHA_MOVIMIENTO_TERMINO, MATERIAL_FINAL, MATERIAL_INICIAL, UserName);
            dt.TableName = "SP_OrdCompraPorRepo";

            return dt;
        }

        [WebMethod]
        public DataTable OrdenesServicioLondon(string Fecha_Emision_Inicio, string Fecha_Emision_Termino,
            string Procedencia, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_OrdServicioLond(Fecha_Emision_Inicio, Fecha_Emision_Termino, Procedencia, UserName);
            dt.TableName = "SP_OrdServicioLond";

            return dt;
        }

        [WebMethod]
        public DataTable OrdenesCompraPeriodoVFechaEntrega(string Centro_Operativo, string Procedencia, string Fecha_Inicio, string Fecha_Termino, 
            string Clase_Material, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_OrdenComP_VFechaEntre(Centro_Operativo, Procedencia, Fecha_Inicio, Fecha_Termino, Clase_Material, UserName);
            dt.TableName = "SP_OrdenComP_VFechaEntre";

            return dt;
        }

        [WebMethod]
        public DataTable ModificacionFEntregaOcoOse(string Centro_Operativo, string Tipo_Orden, string Procedencia, string Numero_Orden, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_ModiFEntreOcoOse(Centro_Operativo, Tipo_Orden, Procedencia, Numero_Orden, UserName);
            dt.TableName = "SP_ModiFEntreOcoOse";

            return dt;
        }

        [WebMethod]
        public DataTable OcoEmiLogistica(string Centro_Operativo, string Procedencia, string Tipo, string Estado, string Fecha_Emision_Inicial,
            string Fecha_Emision_Final, string Cotizador, string UserName)
        {
            Tipo = Tipo.Replace("-1", "");
            Estado = Estado.Replace("-1", "");

            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_OcoEmiLogi(Centro_Operativo, Procedencia, Tipo, Estado, Fecha_Emision_Inicial, Fecha_Emision_Final, Cotizador, UserName);
            dt.TableName = "SP_OcoEmiLogi";

            return dt;
        }

        [WebMethod]
        public DataTable AVANCE_OSE_VALJDE(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_AVANCE_OSE_VALJDE(D_FECHAINI, D_FECHAFIN, UserName);
            dt.TableName = "AVANCE_OSE_VALJDE";

            return dt;
        }

        [WebMethod]
        public DataTable ALMAC_OCO_VALJDE(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_ALMAC_OCO_VALJDE(D_FECHAINI, D_FECHAFIN, UserName);
            dt.TableName = "ALMAC_OCO_VALJDE";

            return dt;
        }

        [WebMethod]
        public DataTable AtencionesServiciosCC(string N_CEO, string V_CODCCO, string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_AtencionesServiciosCC(N_CEO, V_CODCCO, D_FECHAINI, D_FECHAFIN, UserName);
            dt.TableName = "SP_AtencionesServiciosCC";

            return dt;
        }

        [WebMethod]
        public DataTable REQUERIMIENTO_OCO_VALJDE(string Fecha_Emision, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_REQUERIMIENTO_OCO_VALJDE(Fecha_Emision, UserName);
            dt.TableName = "SP_REQUERIMIENTO_OCO_VALJDE";

            return dt;
        }

        [WebMethod]
        public DataTable OrdenesCompraOGC(string Centro_Operativo, string Procedencia, string año_de_Orden, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_OCO_OGC(Centro_Operativo, Procedencia, año_de_Orden, UserName);
            dt.TableName = "SP_OCO_OGC";

            return dt;
        }

        [WebMethod]
        public DataTable OrdenesServicioOGC(string Centro_Operativo, string año_de_Orden, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_OSE_OGC(Centro_Operativo, año_de_Orden, UserName);
            dt.TableName = "SP_OSE_OGC";

            return dt;
        }

        [WebMethod]
        public DataTable OrdenesServicioOtsxDiv(string V_Centro_Operativo, string V_división, string D_Fecha_Emision_OSE_Inicio, 
            string D_Fecha_Emision_OSE_Termino, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_LOG_OSE_OTS_RN(V_Centro_Operativo,  V_división, D_Fecha_Emision_OSE_Inicio, D_Fecha_Emision_OSE_Termino, UserName);
            dt.TableName = "SP_LOG_OSE_OTS_RN";

            return dt;
        }

        [WebMethod]
        public DataTable OrdenesServicioCC(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_OrdenesServicioCC(D_FECHAINI, D_FECHAFIN, UserName);
            dt.TableName = "SP_OrdenesServicioCC";

            return dt;
        }

        [WebMethod]
        public DataTable OrdenesCompraCC(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_OrdenesCompraCC(D_FECHAINI, D_FECHAFIN, UserName);
            dt.TableName = "SP_OrdenesCompraCC";

            return dt;
        }

        [WebMethod]
        public DataTable OrdenesComSerOtContraloria(string Centro_Operativo, string DIVISION, string ORDEN_DE_TRABAJO, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_ORDENCOM_SER_OT_CONTRALORIA(Centro_Operativo, DIVISION, ORDEN_DE_TRABAJO, UserName);
            dt.TableName = "SP_ORDENCOM_SER_OT_CONTRALORIA";

            return dt;
        }

        [WebMethod]
        public DataTable OrdenesEntregaFacPrv(string FECHA_INICIAL, string FECHA_FINAL, string TIPO_DE_ORDEN, string PROCEDENCIA, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_Ordenes_Entrega_FacPrv(FECHA_INICIAL, FECHA_FINAL, TIPO_DE_ORDEN, PROCEDENCIA, UserName);
            dt.TableName = "SP_Ordenes_Entrega_FacPrv";

            return dt;
        }

        [WebMethod]
        public DataTable EgresoDirectoOCO(string D_FECHAINI, string D_FECHAFIN, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_Egresos_Directos_OCO(D_FECHAINI, D_FECHAFIN, UserName);
            dt.TableName = "SP_Egresos_Directos_OCO";

            return dt;
        }

        [WebMethod]
        public DataTable OrdenesComSerOt(string Centro_Operativo, string DIVISION, string ORDEN_DE_TRABAJO, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_ORDENES_COM_SER_OT(Centro_Operativo, DIVISION, ORDEN_DE_TRABAJO, UserName);
            dt.TableName = "SP_ORDENES_COM_SER_OT";

            return dt;
        }

        [WebMethod]
        public DataTable DiferenciaCambiarioOrdSrv(string Centro_Operativo, string división, string Proyecto, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_DIF_CMB_PRY_OSE(Centro_Operativo, división, Proyecto, UserName);
            dt.TableName = "SP_DIF_CMB_PRY_OSE";

            return dt;
        }

        [WebMethod]
        public DataTable DiferenciaCambiarioOrdSrvTotal(string Centro_Operativo, string división, string Proyecto, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_DIF_CMB_PRY_OSE_MNT_AVA(Centro_Operativo, división, Proyecto, UserName);
            dt.TableName = "SP_DIF_CMB_PRY_OSE_MNT_AVA";

            return dt;
        }

        [WebMethod]
        public DataTable DiferenciaCambiarioOrdenesCompra(string Centro_Operativo, string división, string Proyecto, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_DIF_CMB_PRY_EGR_DIR_SIN_OT(Centro_Operativo, división, Proyecto, UserName);
            dt.TableName = "SP_DIF_CMB_PRY_EGR_DIR_SIN_OT";

            return dt;
        }

        [WebMethod]
        public DataTable OseAvance_FacPrv(string FECHA_EMISION_INICIAL, string FECHA_EMISION_FINAL, string NMRO_OSE, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_OseAvance(FECHA_EMISION_INICIAL, FECHA_EMISION_FINAL, NMRO_OSE, UserName);
            dt.TableName = "SP_OseAvance";

            return dt;
        }

        [WebMethod]
        public DataTable DiferenciaCambiarioOrdenesCompraSinOtR69B(string Centro_Operativo, string división, string Proyecto, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_DIF_CMB_PRY_OCO_PCI(Centro_Operativo, división, Proyecto, UserName);
            dt.TableName = "SP_DIF_CMB_PRY_OCO_PCI";

            return dt;
        }

        [WebMethod]
        public DataTable DiferenciaCambiarioOrdenesCompraSinOt(string Centro_Operativo, string división, string Proyecto, string NroOrden, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_DIF_CMB_PRY_OCO_SIN_OT(Centro_Operativo, división, Proyecto, NroOrden, UserName);
            dt.TableName = "SP_DIF_CMB_PRY_OCO_SIN_OT";

            return dt;
        }

        [WebMethod]
        public DataTable DiferencialCambiarioEgresosDirectosSinOt(string Centro_Operativo, string división, string Proyecto, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_DIF_CMB_PRY_EGR_DIR(Centro_Operativo, división, Proyecto, UserName);
            dt.TableName = "SP_DIF_CMB_PRY_EGR_DIR";

            return dt;
        }

        [WebMethod]
        public DataTable ALM_OCO_ATE_RSV(string D_INICIO_ALMACENAMIENTO, string D_FINAL_ALMACENAMIENTO, string V_DESTINO_COMPRA,
            string V_Filtro_PRY_AUS, string V_PRY_AUS, string UserName)
        {
            logisticaSoapClient oLg = new logisticaSoapClient();
            dt = oLg.Listar_ALM_OCO_ATE_RSV(D_INICIO_ALMACENAMIENTO, D_FINAL_ALMACENAMIENTO, V_DESTINO_COMPRA, V_Filtro_PRY_AUS, V_PRY_AUS, UserName);
            dt.TableName = "SP_ALM_OCO_ATE_RSV";

            return dt;
        }
    }
}
