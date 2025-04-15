using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PBsizing.Models;
using System.Data.Sql;
using System.Data.SqlClient;
using System.Data.Entity.Infrastructure;
using EAHLibs;

namespace PBsizing.Controllers
{
      [OutputCacheAttribute(VaryByParam = "*", Duration = 0, NoStore = true)]

    public class Batt_Cab_DimController : Controller
    {
    


        private BatListEntities2 db = new BatListEntities2();
        private static Lib1 Tools = new Lib1();
        double[] arrRec = new double[20],  arrTiers=new double[8];
 
        string G_BN = "";
          double           G_BC = 0,
                  G_BL = 0,
                  G_BH = 0,
                  G_PB=0,
                  G_CAB_A = 0,
                  G_CAB_B = 0,
                  G_CAB_C = 0,
                  G_CAB_D = 0,
                  G_CAB_HP = 0,
                  G_CAB_HCB = 0,
                  G_CAB_HD1_2 = 0,
                  G_Gage = 0,
                  G_Cust_CAB_HEI = 0,
                  G_Cust_CAB_WIDTH = 0,
                  G_Cust_CAB_Depth = 0;


          public JsonResult Save_Cab_ALLDim(string c_BN, string c_BH, string c_BL,string c_BWD
            , string c_CAB_A, string c_CAB_B, string c_CAB_C, string c_CAB_D, string c_CAB_HP, string c_CAB_HCB,
              string c_CAB_HD1_2, string c_Gage, string c_Cust_CAB_HEI, string c_Cust_CAB_WIDTH, string c_Cust_CAB_Depth)
        {
           

            G_BN=c_BN; //batt name
            G_BL=  Tools.Conv_Dbl(c_BL);
            G_BH = Tools.Conv_Dbl(c_BH);
            G_PB=  Tools.Conv_Dbl(c_BWD);
            G_CAB_A = Tools.Conv_Dbl(c_CAB_A);
            G_CAB_B = Tools.Conv_Dbl(c_CAB_B);
            G_CAB_C = Tools.Conv_Dbl(c_CAB_C);
            G_CAB_D = Tools.Conv_Dbl(c_CAB_D);
            G_CAB_HP = Tools.Conv_Dbl(c_CAB_HP);
            G_CAB_HCB = Tools.Conv_Dbl(c_CAB_HCB);
            G_CAB_HD1_2 = Tools.Conv_Dbl(c_CAB_HD1_2);
            G_Gage = Tools.Conv_Dbl(c_Gage);
            G_Cust_CAB_HEI = Tools.Conv_Dbl(c_Cust_CAB_HEI);
            G_Cust_CAB_WIDTH = Tools.Conv_Dbl(c_Cust_CAB_WIDTH);
            G_Cust_CAB_Depth = Tools.Conv_Dbl(c_Cust_CAB_Depth);


            int inch = 1;
            string myuserNm =  HttpContext.Session ["usr"].ToString(), json = "OK";

            db.Database.ExecuteSqlCommand("delete Cab_Dim where UserName='" + myuserNm + "'");
         //   db.Database.ExecuteSqlCommand("delete Cab_Dim where UserName='" + "ede" + "'");

            db.Save_Cab_Dim(inch, c_BN, decimal.Parse(G_BH.ToString ()), decimal.Parse(G_BL.ToString ()),decimal.Parse( G_PB.ToString ()),decimal.Parse( G_CAB_A.ToString ()),decimal.Parse( G_CAB_B.ToString ())
                ,decimal.Parse( G_CAB_C.ToString ()),decimal.Parse (G_CAB_D.ToString ()), decimal.Parse(G_CAB_HP.ToString ()),decimal.Parse( G_CAB_HCB.ToString ()),decimal.Parse( G_CAB_HD1_2.ToString ()),decimal.Parse( G_Gage.ToString ()), 
                decimal.Parse(G_Cust_CAB_HEI.ToString ()),decimal.Parse( G_Cust_CAB_WIDTH.ToString ()),decimal.Parse( G_Cust_CAB_Depth.ToString ()), myuserNm);


          //  db.Database.ExecuteSqlCommand("delete CalCab_All");

            Calculate_CabsALL();

            return Json(json, "application/json");
        }


          void Calculate_ONE_Cab(string CabNM, string HC, string LC, string PC)
          {
              string usrNM =  HttpContext.Session ["usr"].ToString();


              if (Tools.Conv_Dbl(HC) == 0 || Tools.Conv_Dbl(LC) == 0 || Tools.Conv_Dbl(PC) == 0)
              {
                  for (int y = 0; y < 18; y++) arrRec[y] = 0;
                  for (int y = 0; y < 8; y++) arrTiers[y] = 0;
              }
              else
              {
                  double N11_Recall = 0; bool Stoped = false;
                  arrRec[0] = Tools.Conv_Dbl(CabNM);
                  arrRec[1] = Tools.Conv_Dbl(HC);
                  arrRec[2] = Tools.Conv_Dbl(LC);
                  arrRec[3] = Tools.Conv_Dbl(PC);

                  arrRec[4] = (double)Convert.ToInt32(Tools.Conv_Dbl(HC) - G_CAB_HCB - G_CAB_HP); //H1


                  arrRec[5] = (double)(Int32)( 
                                               ( arrRec[4] - G_BH - G_CAB_HD1_2) / G_CAB_D 
                                             ); //N11


                  arrRec[6] = (double)(Int32)((Tools.Conv_Dbl(PC) - G_CAB_C) / (G_PB + G_Gage * 6)); //N21
                  arrRec[7] = Math.Min(arrRec[5], arrRec[6]); //NT11
                  arrRec[8] = (double)(Int32)((Tools.Conv_Dbl(LC) - G_CAB_B) / (G_BL + G_CAB_A)); //NBT1 
                  //arrRec[9] = (double)(Int32)(arrRec[7] * arrRec[8]); //NB1
                  arrRec[9] = Math.Round(arrRec[7] * arrRec[8]); //NB1
                  if (arrRec[5] <= arrRec[6])
                  {
                      for (int t = 11; t < 17; t++) arrRec[t] = 0;
                      Stoped = true;

                  }
                  else N11_Recall = (double)(Int32)(((arrRec[4] - 2 * G_BH - 2 * G_CAB_HD1_2) / G_CAB_D) + 2);



                  arrRec[10] = 0; //NoSTP

                  //Second Step
                  arrRec[11] = 0;
                  double CABH = Tools.Conv_Dbl(HC);
                  double CABW = Tools.Conv_Dbl(LC);
                  double CABD = Tools.Conv_Dbl(PC);
                  //AREA
                  arrRec[12] = Math.Round((2 * CABH * CABW) + (2 * CABH * CABD) + (2 * CABW * CABD), 0);
                  arrRec[13] = 0;

                  if (!Stoped)
                  {
                      //NT12

                      arrRec[14] = (double)(Int32)(N11_Recall - arrRec[6]);
                      //NBT2
                      arrRec[15] = (double)(Int32)(arrRec[8]);
                      //NB2
                      if (arrRec[14] > arrRec[6]) arrRec[14] = (double)(Int32)(arrRec[6]);
                      arrRec[16] = (double)(Int32)(arrRec[8] * arrRec[14]);
                      if (arrRec[14] <= 0)
                      {
                          for (int g = 11; g < 17; g++)
                              if (g != 12) arrRec[g] = 0;  //avoid overwriting AREA value g=12
                          Stoped = true;
                      }
                  }

                  //NBTOT
                  arrRec[17] = (double)(Int32)(arrRec[16] + arrRec[9]);

                  //Tiers Calculation
                  arrRec[0] = Tools.Conv_Dbl(CabNM);
                  arrTiers[1] = CABH;// Tools.Conv_Dbl(HC);
                  arrTiers[2] = CABW;// Tools.Conv_Dbl(LC);
                  arrTiers[3] = CABD;// Tools.Conv_Dbl(PC);
                  //NT
                  double t2 = G_BH + G_CAB_HD1_2;
                  arrTiers[4] = (double)(Int32)((arrTiers[1] - G_CAB_HCB - G_CAB_HP) / t2);
                  //NBT
                  t2 = (double)(Int32)((arrTiers[3] - 1.5) / (G_PB + 0.2)); //Bat_Int
                  arrTiers[5] = (double)(Int32)(t2 * (double)(Int32)((arrTiers[2] - 1) / (G_BL + 0.2)));
                  //NB
                  arrTiers[6] = (double)(Int32)(arrTiers[4] * arrTiers[5]);
                  arrTiers[7] = (double)(Int32)(arrRec[12]);
              }
              db.Save_CalCabALL(CabNM, HC, LC, PC, arrRec[4].ToString(), arrRec[5].ToString(), arrRec[6].ToString(), arrRec[7].ToString(),
                                arrRec[8].ToString(), arrRec[9].ToString(), Convert.ToByte(arrRec[10]), arrRec[11].ToString(), arrRec[12].ToString(), arrRec[13].ToString(), arrRec[14].ToString(), arrRec[15].ToString(), arrRec[16].ToString(), arrRec[17].ToString(), usrNM);
              db.Save_CalTiers_ALL(CabNM, HC, LC, PC, arrTiers[4].ToString(), arrTiers[5].ToString(), arrTiers[6].ToString(), arrTiers[7].ToString(), usrNM);

          }

          void Calculate_CabsALL()
          {
              //delete CalTiers_All , delete CalCab_All
              db.Database.ExecuteSqlCommand("delete CalCab_All where UserName='" +  HttpContext.Session ["usr"].ToString() + "'");
              db.Database.ExecuteSqlCommand("delete CalTiers_All where UserName='" +  HttpContext.Session ["usr"].ToString() + "'");


              bool CC = false;string cabcd="0";
              var myCabncstm = db.CABNCSTMs.ToList();
              foreach (CABNCSTM rec in myCabncstm)
              {
                 Calculate_ONE_Cab(rec.cabn, rec.hc, rec.lc, rec.pc);
                 if (!CC) CC = true;
                cabcd = rec.cabcode.ToString();
              }
              if (CC) Calculate_ONE_Cab("CUSTOM", G_Cust_CAB_HEI.ToString(), G_Cust_CAB_WIDTH.ToString(), G_Cust_CAB_Depth.ToString()); 
          }


        //not used

        void fill_allDims(string usrNM)
        {

            DbSqlQuery<Cab_Dim> data = db.Cab_Dim.SqlQuery("select * from Cab.Dim   where UserName=@p0", usrNM);
            foreach (var cust in data)
            {
/*
                G_CAB_A = cust.CAB_A.Value;
                G_CAB_B = cust.CAB_B.Value;
                G_CAB_C = cust.CAB_C.Value;
                G_CAB_D = cust.CAB_D.Value;
                G_CAB_HCB = cust.CAB_HCB.Value;
                G_CAB_HD1_2 = cust.CAB_HD1_2.Value;
                G_CAB_HP = cust.CAB_HP.Value;
                G_Cust_CAB_Depth = cust.Cust_CAB_Depth.Value;
                G_Cust_CAB_HEI = cust.Cust_CAB_HEI.Value;
                G_Cust_CAB_WIDTH = cust.Cust_CAB_WIDTH.Value;
*/

            }

        }


        public void Calc_STEPS()
        {
            fill_allDims( HttpContext.Session ["usr"].ToString());

        }


        public string HelpBAT_Ctr()
        {

             return "<img src=" +'"' + @"/Images/pbsiz_batt.png"    +'"'+" width=" + '"'+"500" +'"'+" height=" + '"' + "500" +'"' + @"/>" ;
  
        }
        public string HelpCAB_Ctr()
        {
             return    "<img src=" + '"' + @"/Images/pbsiz_Cabinet.png" + '"' + " width=" + '"' + "500" + '"' + " height=" + '"' + "500" + '"' + @"/>";

        }

      
        public ActionResult Index()
        {
            System.Threading.Thread.Sleep(1000);
            string UN =  HttpContext.Session ["usr"].ToString();
            return View(db.Cab_Dim.Where(a=> a.UserName==UN).ToList());
        }

        //
        // GET: /Batt_Cab_Dim/Details/5

        public ActionResult Details(long id = 0)
        {
            Cab_Dim cab_dim = db.Cab_Dim.Find(id);
            if (cab_dim == null)
            {
                return HttpNotFound();
            }
            return View(cab_dim);
        }

        //
        // GET: /Batt_Cab_Dim/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Batt_Cab_Dim/Create

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Cab_Dim cab_dim)
        {
            if (ModelState.IsValid)
            {
                db.Cab_Dim.Add(cab_dim);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cab_dim);
        }

        //
        // GET: /Batt_Cab_Dim/Edit/5

        public ActionResult Edit(long id = 0)
        {
            Cab_Dim cab_dim = db.Cab_Dim.Find(id);
            if (cab_dim == null)
            {
                return HttpNotFound();
            }
            return View(cab_dim);
        }

        //
        // POST: /Batt_Cab_Dim/Edit/5

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Cab_Dim cab_dim)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cab_dim).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cab_dim);
        }

        //
        // GET: /Batt_Cab_Dim/Delete/5

        public ActionResult Delete(long id = 0)
        {
            Cab_Dim cab_dim = db.Cab_Dim.Find(id);
            if (cab_dim == null)
            {
                return HttpNotFound();
            }
            return View(cab_dim);
        }

        //
        // POST: /Batt_Cab_Dim/Delete/5

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(long id)
        {
            Cab_Dim cab_dim = db.Cab_Dim.Find(id);
            db.Cab_Dim.Remove(cab_dim);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}