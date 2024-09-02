////using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIMANET_W22R.ManodeObra
{
    public partial class ReportePLL : PaginaBase
    {/*
        protected void Page_Load(object sender, EventArgs e)
        {

            string sNombreRPT = "Planilla";
            // convertirmos las variables de session que contiene los datatable para el reporte en objetos datatable
            DataTable dtPlanillas = new DataTable();
            dtPlanillas = (DataTable)Session["Planillas"];

            DataTable cab_dt = new DataTable();
            cab_dt = (DataTable)Session["Cab_Planillas"];

            DataTable dtFirmas = new DataTable();
            dtFirmas = (DataTable)Session["firmas"];

            // configuracion del reporte 
            rpvPlanilla.Reset();  // limpiamos el reportview
            rpvPlanilla.ProcessingMode = ProcessingMode.Local;
            rpvPlanilla.LocalReport.ReportPath = Server.MapPath("..//Reportes//ReportePlanillas.rdlc"); //asocia el objeto reportview con su reporte creado rdlc
            rpvPlanilla.LocalReport.EnableExternalImages = true;
            rpvPlanilla.LocalReport.EnableHyperlinks = true;
            rpvPlanilla.LocalReport.DataSources.Clear();

            // coloca el origen de datos de los datos del reporte
            // Se comenta para cambio de nombre EVS 20230419
            // INI
            //ReportDataSource rdcReportSourceCabecera = new ReportDataSource();
            //rdcReportSourceCabecera.Name = "dtsPlanilla";

            //rdcReportSourceCabecera.Value = dt;
            //rpvPlanilla.LocalReport.DataSources.Add(rdcReportSourceCabecera);
            // FIN

            ReportDataSource rdcReportSourceCabecera = new ReportDataSource();
            rdcReportSourceCabecera.Name = "dtsCabPlanilla";
            rdcReportSourceCabecera.Value = cab_dt;
            rpvPlanilla.LocalReport.DataSources.Add(rdcReportSourceCabecera);

            ReportDataSource rdcReportSourceCuerpo = new ReportDataSource();
            rdcReportSourceCuerpo.Name = "dtsPlanilla";
            rdcReportSourceCuerpo.Value = dtPlanillas;
            rpvPlanilla.LocalReport.DataSources.Add(rdcReportSourceCuerpo);

            ReportDataSource rdcReportSourceFirmas = new ReportDataSource();
            rdcReportSourceFirmas.Name = "dtsFirmas";
            rdcReportSourceFirmas.Value = dtFirmas;
            rpvPlanilla.LocalReport.DataSources.Add(rdcReportSourceFirmas);

            rpvPlanilla.ExportContentDisposition = ContentDisposition.AlwaysInline;
            rpvPlanilla.LocalReport.Refresh();

            //---- bloque de generacion de PDF -----

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = rpvPlanilla.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            //------------------------
            // sNombreRPT
            //------------------------
            try
            {
                if (cab_dt.Rows.Count > 0)
                {
                    sNombreRPT = "Pll_" + cab_dt.Rows[0]["fec_tbj"].ToString() + "_" + cab_dt.Rows[0]["cod_tll"].ToString() + "_" + cab_dt.Rows[0]["mod_tbj"].ToString();

                }
            }
            catch (Exception ex)
            {
                StackTrace stack = new StackTrace();
                string NombreMetodo = stack.GetFrame(1).GetMethod().Name + "/" + stack.GetFrame(0).GetMethod().Name;
                this.LanzarException(NombreMetodo, ex);
            }


            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename= " + sNombreRPT + ".pdf"); // nombre de reporte
            Response.OutputStream.Write(bytes, 0, bytes.Length); // create the file  
            Response.Flush(); // send it to the client to download  
            Response.End();
        }
        */
    }
}