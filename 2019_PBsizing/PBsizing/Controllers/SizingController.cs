using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBsizing.Models;




namespace PBsizing.Controllers
{
      [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]
    public class SizingController : Controller
    {
      


        // GET: /Sizing/
        BatListEntities2 mydb = new BatListEntities2();
    

        public ActionResult Sizing()
        {
            if (HttpContext.Session["usr"] == null || HttpContext.Session["TR"] == null)
                return View("~/Views/Shared/logon.cshtml");
            else
            {

                /*       ViewBag.batype = new SelectList(mydb.BATTYPEs, "CBT", "Desc","Select");
                       ViewBag.manifac = new SelectList(mydb.MANIFACs, "ManID", "MARQUE", "Select");
                       ViewBag.grpbat = new SelectList(mydb.GRPBATs, "CGB", "DESC", "Select");
                       ViewBag.batteries = new SelectList(mydb.BATTERIEs, "CBA", "DESC", "Select");
                 * */
                ViewBag.batype = mydb.BATTYPEs.ToList();
                //      ViewBag.manifac = mydb.MANIFACs.ToList ();// .Where(x=> x.CMA==999).ToList(); //send empty query
                ViewBag.manifac = mydb.v_MANUFAC.ToList();// .Where(x=> x.CMA==999).ToList(); //send empty query
                                                          //        ViewBag.grpbat = mydb.GRPBATs.ToList();
                ViewBag.batteries = mydb.BATTERIEs.ToList();//  .Where (x=> x.CBA==9999).ToList();

                ViewBag.BattVal = mydb.Battery_Values.ToList();
                var toto = mydb.Battery_Values;

                ViewBag.tst = mydb.BATTERIEs.ToList();

                //   ViewData["tst"] = new SelectList(mydb.BATTERIEs.ToList(), "CBA", "DESC");
                //ViewData["tst"] = mydb.BATTERIEs.ToList(); 

                string Opera = "";

                HttpContext.Session["opera"] = "s"; HttpContext.Session["usr"] = "ede"; Opera = "s";

                if (HttpContext.Session["opera"] == null || HttpContext.Session["usr"].ToString() == "") Opera = "*";
                else Opera = HttpContext.Session["opera"].ToString();
                if (Opera == "s") return View(mydb);
                else return View("~/Views/Home/ERROR_NOSIZING.cshtml");
            }
 
        }


        private IList<spManufac_CBT_Result > GetManifac(int _CBT)
        {
            // stored Proc.  spManufac_CBT(_CBT) must be created on SQL DB
            return mydb.spManufac_CBT(_CBT).ToList(); 
        }
        private IList<spBatteries_CBT_CMA_Result> GetBatList(int _CBT, int _CMA)
        {
            return mydb.spBatteries_CBT_CMA (_CBT,_CMA).ToList();
        }

        private IList<spBattery_CBA_Result> GETBattery(int _CBA)
        {
            return mydb.spBattery_CBA(_CBA).ToList ();
        }

        public JsonResult LoadManifac_cbt(string _CBT)
        {

            var ManifacList = this.GetManifac(Convert.ToInt32(_CBT));
            var ManifacData = ManifacList.Select(m => new SelectListItem() { Text = m.MARQUE, Value = m.ManID.ToString() });
            return Json(ManifacData.ToList (), JsonRequestBehavior.AllowGet); 

        }

        public JsonResult LoadBat_cbt_cma(string _CBT, string _CMA)
        {

            var batList = this.GetBatList(Convert.ToInt32(_CBT), Convert.ToInt32(_CMA));
            var ManifacData = batList.Select (m => new SelectListItem() { Text = m.BatName, Value = m.CBA.ToString() });
            return Json(ManifacData.ToList(), JsonRequestBehavior.AllowGet);

        }

        public JsonResult Save_Cab_Dim(string c_BN, string c_BH, string c_BL, string c_BWD)
        {
            int inch=1;
            string myuserNm =  HttpContext.Session ["usr"].ToString(), json = "OK";

           decimal CAB_A=0.2M ,
                   CAB_B=1.25M ,
                   CAB_C=2M ,
                   CAB_D=7.02M ,
                   CAB_HP=3M,
                   CAB_HCB=22M ,
                   CAB_HD1_2=10 ,
                   Gage=0.08M  ,
                   Cust_CAB_HEI=0 ,
                   Cust_CAB_WIDTH=0 ,
                   Cust_CAB_Depth=0;
           mydb.Database.ExecuteSqlCommand("delete Cab_Dim where UserName='" + myuserNm + "'");
           mydb.Save_Cab_Dim(inch, c_BN ,decimal.Parse (c_BH), decimal.Parse (c_BL),decimal.Parse ( c_BWD), CAB_A, CAB_B,CAB_C, CAB_D, CAB_HP, CAB_HCB, CAB_HD1_2, Gage, Cust_CAB_HEI, Cust_CAB_WIDTH, Cust_CAB_Depth, myuserNm);
           return Json(json , "application/json" );
        }

        public JsonResult LoadBattery_CBA(string _CBA)
        {
           // var BatList = this.GETBattery(Convert.ToInt32(_CBA));
            //
            List<BATTERIE> LstBat = new List<BATTERIE>();
            Int16 cbaint=Convert.ToInt16(_CBA);
            LstBat = mydb.BATTERIEs.Where(a => a.CBA ==cbaint ).ToList(); 
            var DataBat = LstBat;
            return Json(DataBat, JsonRequestBehavior.AllowGet);
        }

        public PartialViewResult Ref_BatValues()
        {
          ViewBag.BattVal = mydb.Battery_Values.ToList();
            var model = mydb.Battery_Values.ToList();
            return PartialView("wg_DutyCycle",model);
        }
    }
}
