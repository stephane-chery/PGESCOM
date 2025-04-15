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
    public class DispTiersController : Controller
    {
         [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
        //
        // GET: /DispTiers/

        public ActionResult Index()
        {
            return View();
        }

         public ActionResult DispTiers()
         {

             System.Threading.Thread.Sleep(2000);
             var Tiers = new List<CalTiers_All>();

             using (BatListEntities2 dc = new BatListEntities2())
             {
                 string UN =  HttpContext.Session ["usr"].ToString();
                 Tiers = dc.CalTiers_All.Where(a => a.UserName == UN).ToList();

             }

             return View(Tiers);

         }


         public FileStreamResult Tiers_GenPDF()
         {

             string UN =  HttpContext.Session ["usr"].ToString();
             var Tiers = new List<CalTiers_All>();
             using (BatListEntities2 dc = new BatListEntities2())
             {
                 Tiers = dc.CalTiers_All.Where(a => a.UserName == UN).ToList();
             }

             WebGrid TIERSgrid = new WebGrid(source: Tiers, canPage: false, canSort: false);
             string gridHTML = TIERSgrid.GetHtml(
                    columns: TIERSgrid.Columns(
    TIERSgrid.Column(columnName: "cabn", header: "CABINET"),
    TIERSgrid.Column(columnName: "hc", header: "Height"),
    TIERSgrid.Column(columnName: "lc", header: "Width"),
    TIERSgrid.Column(columnName: "pc", header: "Depth"),
    TIERSgrid.Column(columnName: "nt", header: "TIERS#"),
    TIERSgrid.Column(columnName: "nbt", header: "BATT.# / Tier"),
    TIERSgrid.Column(columnName: "nb", header: "TOTAL BATT."),
    TIERSgrid.Column(columnName: "surface", header: "AREA")

      )).ToString();

             string exportData = String.Format("<html><head>{0}</head><body>{1}</body></html>", "<style>table, th, td {border: 1px solid black;border-collapse: collapse;} th, td { padding: 5px;}</style>", gridHTML);

             var bytes = System.Text.Encoding.UTF8.GetBytes(exportData);
             using (var input = new MemoryStream(bytes))
             {
                 var output = new MemoryStream();
                 var document = new iTextSharp.text.Document(PageSize.A4, 20, 20, 50, 50);
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
