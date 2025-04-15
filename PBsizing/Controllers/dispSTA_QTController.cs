using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBsizing.Models;

namespace PBsizing.Controllers
{
    public class dispSTA_QTController : Controller
    {
        //
        // GET: /dispSTA_QT/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Dispsta_QT()
        {

            System.Threading.Thread.Sleep(2000);
            var Steps = new  List<PSM_WB_STQuote>();
      //      Orig_PSM_FDBEntities1 mydb = new Orig_PSM_FDBEntities1();
            using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
            {
                string UN = HttpContext.Session["usr"].ToString();

                Steps = dc.PSM_WB_STQuote.Where(a => a.usr == UN).ToList();

            }
            //  RedirectToAction("DispSTEPS", "DispSteps");
            //  Response.AddHeader("Refresh", "1");


            return View(Steps);

        }
    }
}
