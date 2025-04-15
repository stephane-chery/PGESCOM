using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using PBsizing.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Web.Helpers;
using System.IO;


namespace PBsizing.Controllers
{



    public class DispStepsController : Controller
    {
        [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]


        //
        // GET: /DispSteps/

        public ActionResult Index()
        {
            return View();
        }



        public ActionResult DispSTEPS()
        {

            System.Threading.Thread.Sleep(2000);
            var Steps = new List<CalCab_All>();

            using (BatListEntities2 dc = new BatListEntities2())
            {
                string UN =  HttpContext.Session ["usr"].ToString();
               
                Steps = dc.CalCab_All.Where(a=> a.UserName==UN).ToList();

            }
            //  RedirectToAction("DispSTEPS", "DispSteps");
            //  Response.AddHeader("Refresh", "1");


            return View(Steps);

        }

        public FileStreamResult Steps_GenPDF()
        {

              string UN =  HttpContext.Session ["usr"].ToString();
            var Steps = new List<CalCab_All>();
            using (BatListEntities2 dc = new BatListEntities2())
            {
                Steps = dc.CalCab_All.Where(a=> a.UserName==UN).ToList();
            }

            WebGrid stpGrid = new WebGrid(source: Steps, canPage: false, canSort: false);
            string gridHTML = stpGrid.GetHtml(
                   columns: stpGrid.Columns(
     stpGrid.Column(columnName: "cabn", header: "CABINET"),
     stpGrid.Column(columnName: "hc", header: "Height"),
     stpGrid.Column(columnName: "lc", header: "Width"),
     stpGrid.Column(columnName: "pc", header: "Depth"),
     stpGrid.Column(columnName: "h1", header: "H1"),
     stpGrid.Column(columnName: "n11", header: "N11"),
     stpGrid.Column(columnName: "n21", header: "N21"),
     stpGrid.Column(columnName: "nt11", header: "Steps#"),
     stpGrid.Column(columnName: "nbt1", header: "Batt/stp"),
     stpGrid.Column(columnName: "nb1", header: "Batt/Tier"),
     stpGrid.Column(columnName: "nt12", header: "Steps#"),
     stpGrid.Column(columnName: "nbt2", header: "Batt/stp"),
     stpGrid.Column(columnName: "nb2", header: "Batt/Tier"),
     stpGrid.Column(columnName: "NBtot", header: "Batt Total "),
     stpGrid.Column(columnName: "n12", header: "Area")
     )).ToString();

            string exportData = String.Format("<html><head>{0}</head><body>{1}</body></html>", "<style>table, th, td {border: 1px solid black;border-collapse: collapse;} th, td { padding: 5px;}</style>", gridHTML);

            var bytes = System.Text.Encoding.UTF8.GetBytes(exportData);
            using (var input = new MemoryStream(bytes))
            {
                var output = new MemoryStream();
                var document = new iTextSharp.text.Document(PageSize.A4,20,20, 50, 50);
                document.SetPageSize(iTextSharp.text.PageSize.A4.Rotate()); //move to landscape format
                var writer = PdfWriter.GetInstance(document, output);
                writer.CloseStream = false;
                document.Open();
                var xmlWorker = iTextSharp.tool.xml.XMLWorkerHelper.GetInstance();
                xmlWorker.ParseXHtml(writer, document, input, System.Text.Encoding.UTF8);
                document.Close();
                output.Position = 0;
                return new FileStreamResult(output, "application/pdf");
            }
        }






    }
       
}
