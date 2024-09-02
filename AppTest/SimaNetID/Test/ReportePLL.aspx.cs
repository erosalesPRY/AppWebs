////using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIMANET_W22R.Test
{
    public partial class ReportePLL : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {/*
            DataTable dt = new DataTable();
            dt = (DataTable)Session["Planillas"];

            rpvPlanilla.Reset();
            rpvPlanilla.ProcessingMode = ProcessingMode.Local;
            rpvPlanilla.LocalReport.ReportPath = Server.MapPath("..//Reportes//ReportePlanillas.rdlc");
            rpvPlanilla.LocalReport.EnableExternalImages = true;
            rpvPlanilla.LocalReport.EnableHyperlinks = true;
            rpvPlanilla.LocalReport.DataSources.Clear();

            ReportDataSource rdcReportSourceCabecera = new ReportDataSource();
            rdcReportSourceCabecera.Name = "dtsPlanilla";

            rdcReportSourceCabecera.Value = dt;
            rpvPlanilla.LocalReport.DataSources.Add(rdcReportSourceCabecera);

            rpvPlanilla.ExportContentDisposition = ContentDisposition.AlwaysInline;
            rpvPlanilla.LocalReport.Refresh();

            Warning[] warnings;
            string[] streamids;
            string mimeType;
            string encoding;
            string filenameExtension;

            byte[] bytes = rpvPlanilla.LocalReport.Render("PDF", null, out mimeType, out encoding, out filenameExtension, out streamids, out warnings);

            Response.Buffer = true;
            Response.Clear();
            Response.ContentType = mimeType;
            Response.AddHeader("content-disposition", "attachment; filename= filename.pdf");
            Response.OutputStream.Write(bytes, 0, bytes.Length); // create the file  
            Response.Flush(); // send it to the client to download  
            Response.End();
            */
        }
    }
}