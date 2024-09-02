using CrystalDecisions.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SIMANET_W22R.Test
{
    public partial class TestReportToPDF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                DataSet ds = new DataSet();
                DataTable dt = new DataTable();
                dt.TableName = "TestRPD;1";
                dt.Columns.Add("Codigo", Type.GetType("System.String"));
                dt.Columns.Add("Nombre", Type.GetType("System.String"));

                DataRow dr = dt.NewRow();
                dr["Codigo"] = "20";
                dr["Nombre"] = "Rosales";
                ds.Tables.Add(dt);




                CrystalDecisions.CrystalReports.Engine.ReportDocument _rpt = new CrystalDecisions.CrystalReports.Engine.ReportDocument();
                _rpt.Load("C:\\AppWebs\\AppTest\\Reportes\\Test\\Demo.rpt");
                _rpt.SetDataSource(ds);



                DiskFileDestinationOptions crDiskFileDestinationOptions = new DiskFileDestinationOptions();
                crDiskFileDestinationOptions.DiskFileName = "C:\\AppWebs\\AppTest\\Archivos\\HomeRptGen\\erosales\\textRpt.pdf";
                CrystalDecisions.Shared.ExportOptions crExportOptions = _rpt.ExportOptions;
                crExportOptions.DestinationOptions = crDiskFileDestinationOptions;
                crExportOptions.ExportDestinationType = ExportDestinationType.DiskFile;
                crExportOptions.ExportFormatType = ExportFormatType.PortableDocFormat;
                _rpt.Export();
            }
            catch(Exception ex) {

                Label1.Text= ex.ToString();
            }
        }
    }
}