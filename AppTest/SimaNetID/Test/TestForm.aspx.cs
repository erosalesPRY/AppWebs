using EasyControlWeb.Form.Controls;
using iTextSharp.text.pdf.parser;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using iTextSharp.text;
using iTextSharp.text.pdf;




namespace SIMANET_W22R.Test
{
    public partial class TestForm :PaginaBase
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Page.ClientScript.RegisterHiddenField("vCode", "eddy");
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            /* List<EasyListItem> olstItems =  this.EasyListAutocompletar1.GetCollection();
             foreach (EasyListItem item in olstItems) {
                 string ss = item.Text;
             }*/

            ExportPDFToExcel("C:\\AppWebs\\AppTest\\Archivos\\HomeRptGen\\erosales\\RI-PROGRAMA DE DESARROLLO PRODUCTIVO AGRARIO RURAL2024-1.pdf");




        }

       
            private void ExportPDFToExcel(string NombreArchivo)
        {


            StringBuilder Texto = new StringBuilder();
            PdfReader pdfReader = new PdfReader(NombreArchivo);

            /*for (int página = 1; página <= pdfReader.NumberOfPages; página++)
            {
                ITextExtractionStrategy Estrategia = new LocationTextExtractionStrategy();
                string currentText = PdfTextExtractor.GetTextFromPage(pdfReader, página, Estrategia);
                currentText = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.UTF8.GetBytes(currentText)));
                Texto.Append(currentText);
                pdfReader.Close();
            }*/

            StringBuilder sb = new StringBuilder();
            try
            {
                iTextSharp.text.pdf.PdfReader reader = new iTextSharp.text.pdf.PdfReader(NombreArchivo);
              
                for (int i = 1; i < reader.NumberOfPages; i++)
                {
                    string currentText = Encoding.UTF8.GetString(Encoding.Convert(Encoding.Default, Encoding.UTF8, Encoding.UTF8.GetBytes(iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(reader, i))));
                    //sb.Append(iTextSharp.text.pdf.parser.PdfTextExtractor.GetTextFromPage(reader, i));
                    sb.Append(currentText);
                }
                reader.Close();

            }
            catch (Exception ex)
            {

            }




            Response.Clear();
             Response.Buffer = true;
             Response.AddHeader("disposición de contenido", "adjunto; nombre de archivo = ReciboExport.xls");
             Response.Charset= "";
             Response.ContentType = "aplicación/vnd.ms-excel";
             Response.Write(sb);
             Response.Flush();
             Response.End();
        }
        void demo(){
           
              
                  
               
          
        }
    }
}