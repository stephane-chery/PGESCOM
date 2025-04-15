using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PBsizing.Models;
using System.Web.Mvc;
using System.Globalization;
using System.Data.Sql;
using EAHLibs;
using System.Data.SqlClient;
using Microsoft.SqlServer.Server;

namespace PBsizing.Controllers
{
    public class CeduleController : Controller
    {
        //
        // GET: /Cedule/
        int nbdays_limt = 3;
        public static Lib1 Tools = new Lib1();
        msgrec mymsg = new msgrec();
        class msgrec
        {
            public string msg { get; set; }
            public string sqlmsg { get; set; }
            public string recnb { get; set; }


        }
        List<msgrec> msgLst = new List<msgrec>();

        class job_prd_prio
        {
            public string prd { get; set; }
            public string prio { get; set; }
        }
        List<job_prd_prio> Joblst = new List<job_prd_prio>();


        class employee
        {
            public string emplid { get; set; }
            public string empName { get; set; }

        }
        List<employee> conc_Lst = new List<employee>();
        List<employee> achinv_Lst = new List<employee>();
        List<employee> mecan_Lst = new List<employee>();
        List<employee> fila_Lst = new List<employee>();
        List<employee> tst_Lst = new List<employee>();
        List<employee> shp_Lst = new List<employee>();
        List<employee> inv_Lst = new List<employee>();
        List<employee> all_Lst = new List<employee>();

        class steps
        {
            public string stpid { get; set; }
            public string stepname { get; set; }

        }
        List<steps> conc_stpLst = new List<steps>();
        List<steps> ach_stpLst = new List<steps>();
        List<steps> meca_stpLst = new List<steps>();
        List<steps> flg_stpLst = new List<steps>();
        List<steps> tst_stpLst = new List<steps>();
        List<steps> shp_stpLst = new List<steps>();
        List<steps> inv_stpLst = new List<steps>();
        List<steps> all_stpLst = new List<steps>();


        class missing_items
        {
            public string JobDescription { get; set; }
            public string StockCode { get; set; }
            public string StockDescription { get; set; }
            public string Warehouse { get; set; }
            public string Outstand { get; set; }
            public string QtyOnHand { get; set; }
            public string Reserved_Other { get; set; }
            public string QtyOnOrder { get; set; }
            public string Avalaible_m { get; set; }

        }


        class Prd_info
        {
            public string customer { get; set; }
            public string pgc_prj { get; set; }
            public string StockCode { get; set; }
            public string JobDD { get; set; }
            public string prd { get; set; }
       

        }
        List<cedulo_jobs_raw> prdlist = new List<cedulo_jobs_raw>();
        List<V_cedulotrs_jobs> trslist = new List<V_cedulotrs_jobs>();
        public ActionResult Index()
        {
            return View();
        }


        //        SELECT prd, JobDD, StockCode, pgc_prj, customer
        //FROM cedule_jobs_raw where CHARINDEX('_S', StockCode) >0


        //public string prj_rev { get; set; }
        //public string StockCode { get; set; }
        //public string JobDD { get; set; }
        //public string prd { get; set; }
        private void fill_prdlist (char dp)
        {

            //  string stSql = "SELECT Salesperson,  Name FROM  dbo.SalSalesperson where SUBSTRING (Salesperson,1,1)='A' and Branch ='" + branch + "1' order by Name ";
            string stSql = "";
           if (dp=='d') stSql = "SELECT  customer, pgc_prj , StockCode,JobDD,prd  ,lid  FROM [Orig_PSM_FDB].[dbo].[cedulo_jobs_raw]  " +
                           " where CHARINDEX('_S',StockCode) >0 and scd01=0  order by JobDD ";
           else stSql = "SELECT  customer, pgc_prj , StockCode,JobDD,prd  ,lid  FROM [Orig_PSM_FDB].[dbo].[cedulo_jobs_raw]  " +
               " where CHARINDEX('_S',StockCode) >0 and scd01=0  order by pgc_prj, StockCode ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                //      Prd_info myprd = new Prd_info();
                cedulo_jobs_raw myprd = new cedulo_jobs_raw();
                myprd.customer = Oreadr[5].ToString()+"-"+ Oreadr[0].ToString();
                myprd.pgc_prj = Oreadr[1].ToString();
                myprd.StockCode = Oreadr[2].ToString();
                myprd.JobDD = Convert.ToDateTime( Oreadr[3].ToString());
                myprd.prd = Oreadr[4].ToString();

                prdlist.Add(myprd);
            }
            OConn.Close();



        }

        public ActionResult Cedulemgr()
        {
            if (HttpContext.Session["usr"] != null)
            {


                //int MM = 0, YYYY = 0;
                //CMS_period_MMYYYY(ref MM, ref YYYY);
             //   ViewBag.mmyyyy = MainMDI.A00(MM, 2) + "/" + YYYY.ToString();
                // 
                string usr = HttpContext.Session["usr"].ToString();
                ViewBag.userName = usr;
                HttpContext.Session["bv_srvr"] = "----";
                //HttpContext.Session["salesP"] = "ylavoie";
                //string sp = HttpContext.Session["salesP"].ToString();
                //fill_AGLIST();
                //ViewBag.aglist = AGlist;
                fill_prdlist('d');
                ViewBag.prdlist = prdlist;
                //List<Fund> fundList = db.Funds.ToList();
                //ViewBag.Funds = fundList;
                //   return View("~/Views/Cedule/menumgr.cshtml");

                // return View("~/Views/Cedule/menumgr.cshtml", prdlist);
                //   return View("~/Views/Cedule/cedmenu.cshtml", prdlist); 
                if (usr == "primax") return RedirectToAction("Disp_Steps", "Cedule");
                else     return View("~/Views/Cedule/cedulemnu.cshtml", prdlist);

            }
            // return View("ERROR_NOSIZING");
            return View("~/Views/Shared/logon.cshtml");
            //View("~/Views/Home/ERROR_NOSIZING.cshtml");
        }


        public ActionResult Cdl_statistics()
        {



            //if (HttpContext.Session["usr"] != null)
            //{
            //    string usr = HttpContext.Session["usr"].ToString();
            //    ViewBag.userName = usr;

            //    fill_prdlist();
            //    ViewBag.prdlist = prdlist;

            //    return View("~/Views/Cedule/cedmenu.cshtml", prdlist);


            //}
            //return View("~/Views/Shared/logon.cshtml");

            ViewBag.errormsg = "................UNDER CONSTRUCTION............";
            return View("~/Views/Shared/Error.cshtml");




        }

        public ActionResult Cdl_addprjold()
        {
            if (HttpContext.Session["usr"] != null)
            {


                //int MM = 0, YYYY = 0;
                //CMS_period_MMYYYY(ref MM, ref YYYY);
                //   ViewBag.mmyyyy = MainMDI.A00(MM, 2) + "/" + YYYY.ToString();
                // 
                string usr = HttpContext.Session["usr"].ToString();
                ViewBag.userName = usr;

                //HttpContext.Session["salesP"] = "ylavoie";
                //string sp = HttpContext.Session["salesP"].ToString();
                //fill_AGLIST();
                //ViewBag.aglist = AGlist;
                fill_prdlist('d');
                ViewBag.prdlist = prdlist;
                //List<Fund> fundList = db.Funds.ToList();
                //ViewBag.Funds = fundList;
                //   return View("~/Views/Cedule/menumgr.cshtml");

                // return View("~/Views/Cedule/menumgr.cshtml", prdlist);
                return View("~/Views/Cedule/addprj.cshtml", prdlist);


            }
            // return View("ERROR_NOSIZING");
            return View("~/Views/Shared/logon.cshtml");
            //View("~/Views/Home/ERROR_NOSIZING.cshtml");
        }


        bool hasAccess(char mdulCode)
        {
            if (HttpContext.Session["mdul"] != null)
            {
                string mdul = HttpContext.Session["mdul"].ToString();
                switch (mdulCode)
                {
                    case 'C':
                        return (mdul[0] == mdulCode);
                        break;
                    case 'M':
                        return (mdul[1] == mdulCode);
                        break;
                    case 'U':
                        return (mdul[2] == mdulCode);
                        break;

                }
          
            }
            return false;

        }
        bool isAdmin_cdl()
        {
            if (HttpContext.Session["cpny"] != null)
            {
                string cpny = HttpContext.Session["cpny"].ToString();
                return (cpny=="99");

            }
            return false;

        }


  



        public ActionResult Cdl_addprj()
        {
            if (HttpContext.Session["usr"] != null)
            {

                string usr = HttpContext.Session["usr"].ToString();
                ViewBag.userName = usr;
                if (hasAccess('C') && isAdmin_cdl() || (usr.ToLower () == "concept" ))
                {
                    fill_prdlist('d');
                    ViewBag.prdlist = prdlist;
                    return View("~/Views/Cedule/addprj.cshtml", prdlist);

                }
                else
                {
                    ViewBag.errormsg = "Access Denied .....";
                    return View("~/Views/Shared/Error.cshtml");
          
                }
            }
          return View("~/Views/Shared/logon.cshtml");
          
        }

        public ActionResult Cdl_impjobs()
        {
            if (HttpContext.Session["usr"] != null)
            {

                string usr = HttpContext.Session["usr"].ToString();
                ViewBag.userName = usr;
                if (hasAccess('C') && isAdmin_cdl())
                {
                   // fill_prdlist('d');
                  //  ViewBag.prdlist = prdlist;
                    return View("~/Views/Cedule/impjobs.cshtml");

                }
                else
                {
                    ViewBag.errormsg = "Access Denied .....";
                    return View("~/Views/Shared/Error.cshtml");

                }
            }
            return View("~/Views/Shared/logon.cshtml");

        }

        public ActionResult Cdl_addprj_p()
        {
            if (HttpContext.Session["usr"] != null)
            {

                string usr = HttpContext.Session["usr"].ToString();
                ViewBag.userName = usr;
                if ((hasAccess('C') && isAdmin_cdl()) || (usr.ToLower() == "concept"))
                {
                    fill_prdlist('p');
                    ViewBag.prdlist = prdlist;
                    return View("~/Views/Cedule/addprj.cshtml", prdlist);

                }
                else
                {
                    ViewBag.errormsg = "Access Denied .....";
                    return View("~/Views/Shared/Error.cshtml");

                }
            }
            return View("~/Views/Shared/logon.cshtml");

        }



        public JsonResult Impcms_mmyyyy(string _mm, string _yyyy)
        {
            msgrec mymsg = new msgrec();

            // string json = "OK";
            // int month = 1, yyyy = 2019;
            int nbrec = 0;
            mymsg.msg = "in impcms.........";//Import_AG_CMS(_mm, _yyyy, ref nbrec);
            mymsg.recnb = nbrec.ToString();
            msgLst.Add(mymsg);
            //   System.Threading.Thread.Sleep(3000);
            // return Json(json, "application/json");
            return Json(msgLst, JsonRequestBehavior.AllowGet);

        }



        //     public JsonResult ImpJobs()
        ///      public ActionResult ImpJobs()
        ///      
        public JsonResult imp_alljobssss()
        {
            //  string st_dt = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime dt = Convert.ToDateTime("9/3/2020 12:00:00 AM");
            //string st_dt = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            HttpContext.Session["bv_srvr"] = "In......ImpJobs...... ";
            if (ValidUser() && (hasAccess('C') && isAdmin_cdl()))
            {
                msgrec mymsg = new msgrec();

                // string json = "OK";
                // int month = 1, yyyy = 2019;
                int nbrec = 0;
                mymsg.msg = Import_newJobs(ref nbrec);
                mymsg.msg = "tstttttt......";
                mymsg.recnb = nbrec.ToString();
                msgLst.Add(mymsg);
            //   ViewBag.errormsg ="msgerr= " + mymsg.msg + "    rec=" + mymsg.recnb;
            //     System.Threading.Thread.Sleep(3000);
            //      return Json(json, "application/json");


        }
            else
            {
              //  ViewBag.errormsg = "Access Denied .....";
                mymsg.msg = "Access Denied .....";//
                mymsg.recnb = "-1";
                msgLst.Add(mymsg);

            }


            //RedirectToAction("Login", "AGCMS");
            //  return View("~/Views/Shared/logon.cshtml");

            return Json(msgLst, JsonRequestBehavior.AllowGet);


        }
        public JsonResult imp_alljobs()
        {
            //  string st_dt = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime dt = Convert.ToDateTime("9/3/2020 12:00:00 AM");
            //string st_dt = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            HttpContext.Session["bv_srvr"] = "In......ImpJobs...... ";
            if (ValidUser() && (hasAccess('C') && isAdmin_cdl()))
            {
                msgrec mymsg = new msgrec();

                // string json = "OK";
                // int month = 1, yyyy = 2019;
                int nbrec = 0;
                mymsg.msg = Import_newJobs(ref nbrec);
                mymsg.msg = "tstttttt......";
                mymsg.recnb = nbrec.ToString();
                msgLst.Add(mymsg);
                //   ViewBag.errormsg ="msgerr= " + mymsg.msg + "    rec=" + mymsg.recnb;
                //     System.Threading.Thread.Sleep(3000);
                //      return Json(json, "application/json");


            }
            else
            {
                //  ViewBag.errormsg = "Access Denied .....";
                mymsg.msg = "Access Denied .....";//
                mymsg.recnb = "-1";
                msgLst.Add(mymsg);

            }


            //RedirectToAction("Login", "AGCMS");
            //  return View("~/Views/Shared/logon.cshtml");

            return Json(msgLst, JsonRequestBehavior.AllowGet);


        }

        public ActionResult Reorder_prjTBLO()
        {
            if (HttpContext.Session["usr"] != null)
            {

                using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
                {
                    trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4).OrderBy(a => a.prio).ToList();

                }

                return View(trslist);
            }

            else
            {
                ViewBag.errormsg = "Access Denied .....";
                return View("~/Views/Shared/Error.cshtml");

            }
        
     

        }



        public JsonResult dlydjobs()
        {

        //    HttpContext.Session["bv_srvr"] = "In......ImpJobs...... ";
            if (ValidUser() && (hasAccess('C') && isAdmin_cdl()))
            {
                msgrec mymsg = new msgrec();
                int nbrec = 0;
                mymsg.msg = Chk_delaydedJobs(ref nbrec);
                mymsg.msg = "tstttttt......";
                mymsg.recnb = nbrec.ToString();
                msgLst.Add(mymsg);

            }
            else
            {
         
                mymsg.msg = "Access Denied .....";//
                mymsg.recnb = "-1";
                msgLst.Add(mymsg);

            }

            return Json(msgLst, JsonRequestBehavior.AllowGet);


        }

        bool ValidUser()
        {

            return (HttpContext.Session["usr"] != null && HttpContext.Session["usr"].ToString() != "");
        }



        string Import_newJobs(ref int nb)
        {


            string retrnMsg = "";
            nb = 0;
          //  string lastprd =MainMDI.Find_One_Field( "select top (1) prd from [dbo].[cedulo_jobs_raw] order by prd desc");

            string lastprd = "PRD10788";
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

            //[S03],[S05],[S08],

            string stSQL = "SELECT WipMaster.Job, WipMaster.JobDeliveryDate, WipMaster.Complete, WipMaster.StockCode, WipMaster.JobDescription, ArCustomer.Name AS custo, DateJobLstUpd " +
                           " FROM WipMaster AS WipMaster INNER JOIN  ArCustomer AS ArCustomer ON WipMaster.Customer = ArCustomer.Customer " +
                           " WHERE (WipMaster.Complete <> 'Y') AND(Job > '" + lastprd + "') order by JobDeliveryDate";




            //    string stout = "";
            //   ed_LVallInvoices.SendToBack();
            //  ed_lvITM.Items.Clear();
            try
            {

                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();
        
                while (Oreadr.Read())
                {
                    string rrr = MainMDI.Find_One_Field("SELECT [lid] from cedulo_jobs_raw where prd='" + Oreadr["Job"].ToString() + "'");
                    if (rrr == MainMDI.VIDE)
                    {
                         string res=  Save_Jobsraw(Oreadr["Job"].ToString(), Oreadr["JobDeliveryDate"].ToString(), Oreadr["StockCode"].ToString(), Oreadr["JobDescription"].ToString(), Oreadr["custo"].ToString(), Oreadr["DateJobLstUpd"].ToString());
                      //  string res = "bzzzzzzzzz";
                        if (res == "" || res == "n/a") nb++;
                        else
                        {
                            retrnMsg = res;
                            break;
                        }

                    }
                }


                // recs="+nb.ToString ();
            }
            catch (Exception ex)
            {
                return "Failed to import New Jobsraw......"+ex.Message;//...ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL;
            }


            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }



            return retrnMsg;

        }

        void fill_arrStps(ref string[] arr_steps)
        {
            for (int i = 0; i < 14; i++) arr_steps[i] = "";
            int nb = 0;
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon);

            string stSQL = " SELECT [abr]  FROM [Orig_PSM_FDB].[dbo].[cedulo_Steps]";

            OConn.Open();
            Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSQL;
            Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                //Save_Jobsraw(Oreadr["Job"].ToString(), Oreadr["JobDeliveryDate"].ToString(), Oreadr["StockCode"].ToString(), Oreadr["JobDescription"].ToString(), Oreadr["custo"].ToString(), Oreadr["DateJobLstUpd"].ToString());
                arr_steps[nb++] = Oreadr[0].ToString();
            }
            OConn.Close();

        }

        void setDelayedJob(string trslid, string stp)
        {

            string errmsg = "";
            string myusr = HttpContext.Session["usr"].ToString();
            string  stsql = " update cedulo_trs set [cur_" + stp + "]=3 where trslid=" + trslid;
            MainMDI.Exec_SQL_JFS(stsql, "setdelayed Jobs...", myusr, ref errmsg);
            mymsg.sqlmsg += "||" + errmsg;

        }
        int   chkLongEncoursStep(string stp)
        {


            if (stp.Length < 2) return 0;
            int nb = 0;
       
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon);
            stp = stp.TrimEnd();

            string stSQL = " SELECT cedulo_trs.trslid,cedulo_jobs_raw.pgc_prj,cedulo_trs.cur_" + stp + ", cedulo_trs.dts_" + stp + ", cedulo_trs.dte_" + stp + ", CAST(GETDATE() AS datetime) AS today, DATEDIFF(DAY, cedulo_trs.dts_" + stp + ", CAST(GETDATE() AS Date)) AS duration " +
                           " FROM cedulo_jobs_raw INNER JOIN cedulo_trs ON cedulo_jobs_raw.lid = cedulo_trs.joblid " +
                           " WHERE cedulo_trs.cur_" + stp + " = 2 AND CAST(DATEDIFF(DAY, cedulo_trs.dts_" + stp + ", CAST(GETDATE() AS Date)) AS int) >" + nbdays_limt + " ORDER BY cedulo_jobs_raw.pgc_prj"; 
             
            OConn.Open();
            Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSQL;
            Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
         
                setDelayedJob(Oreadr[0].ToString(),stp);
                nb++;
                
            }
            OConn.Close();


            return nb;

        }

        int chkLongInWaitStep(string stp)
        {
            if (stp.Length < 2) return 0;
            int nb = 0;
            stp = stp.TrimEnd();

            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon);

            string stSQL = "SELECT cedulo_trs_states.joblid,cedulo_jobs_raw.pgc_prj, cedulo_trs_states.dts_" + stp + ", cedulo_trs_states.dte_" + stp + ", CAST(GETDATE() AS datetime) AS today, DATEDIFF(DAY, cedulo_trs_states.dts_" + stp + ", CAST(GETDATE() AS Date)) AS duration " +
                           "FROM cedulo_jobs_raw INNER JOIN cedulo_trs_states ON cedulo_jobs_raw.lid = cedulo_trs_states.joblid " +
                           " WHERE cedulo_trs_states.dts_" + stp + " > CONVERT(DATE, '1900-01-01 00:00:00', 102) AND cedulo_trs_states.dte_" + stp + " = CONVERT(DATE, '1900-01-01 00:00:00', 102) AND CAST(DATEDIFF(DAY, cedulo_trs_states.dts_" + stp + ", CAST(GETDATE() AS Date)) AS int) >" + nbdays_limt +
                           " ORDER BY cedulo_jobs_raw.pgc_prj";

            OConn.Open();
            Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSQL;
            Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {

                setDelayedJob(Oreadr[0].ToString(), stp);
                nb++;

            }
            OConn.Close();


            return nb;

        }

        string Chk_delaydedJobs(ref int nb)
        {



            string[] arr_steps = new string[14];
            fill_arrStps(ref arr_steps);
            int ns_done = 0;

            for (int i=0;i<14;i++)
            {
                if (arr_steps[i].Length > 1)
                {
                    ns_done += chkLongEncoursStep(arr_steps[i]);
                  //  chkLongInWaitStep(arr_steps[i]);
                }
            }

            nb = ns_done;
           string retrnMsg = "";

            return retrnMsg;

        }





        string Save_Jobsraw(string prd, string _jobdd, string StockCode, string pgc_prj ,string customer,string DateJobLstUpd)
    {
        string retMsg = "";

            DateTime dt = Convert.ToDateTime(_jobdd);
            string st_jobdd= dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            dt = Convert.ToDateTime(DateJobLstUpd);
            string st_DateJobLstUpd = dt.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);

            string usr = HttpContext.Session["usr"].ToString();
            string tsk = "all";//tsk: all,des,inf,eng,po

            //string st_dt = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            //DateTime dt=

            if (prd != "")
            {
                string stSql = " INSERT INTO cedulo_jobs_raw ([prd],[JobDD],[StockCode], [pgc_prj],[DateJobLstUpd], [scd01] , [customer]  ) " +
               " VALUES ('" + prd +
              "', " + MainMDI.SSV_Bigdate(st_jobdd) +
              ", '" + StockCode +
              "', '" + pgc_prj +
              "', " + MainMDI.SSV_Bigdate(st_DateJobLstUpd) +
              ", " + "0" +
              ", '" + customer.Replace("'", "''") + "')";

                MainMDI.Exec_SQL_JFS(stSql, "save New Jobsraw......",usr,ref retMsg);

            }
            else
            {
                retMsg = "ERROR importing New Jobsraw........empty PRD:" + prd + ":";

            }

        return retMsg;

    }

        /*
            public ActionResult  cedule_prj(string c_al_list)
                {

                    //   int nbrelays = Regex.Matches(c_al_list, "9999").Count;
                    if (c_al_list[0] == ',') c_al_list = c_al_list.Substring(1, c_al_list.Length - 1);
                    string Line = c_al_list,err_stout="";
                    string c_err = "OK";
                    string usr = HttpContext.Session["usr"].ToString();
                    string[] Avv = Line.Split(',');
                    string st_dt = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
                    for (int i = 0; i < Avv.Length; i++)
                    {
                        string[] tt = Avv[i].Split('-');
                        string lid = tt[0];
                        string errmsg = "";
                        if (Tools.Conv_Dbl(lid) > 0)
                        {
                            string st = MainMDI.Find_One_Field("SELECT  prio   FROM [Orig_PSM_FDB].[dbo].[cedulo_trs] where cur_inv < 4 order by prio desc");
                            string newprio = (Tools.Conv_Dbl(st) + 1).ToString();

                            MainMDI.Exec_SQL_JFS("update cedulo_jobs_raw set [scd01]=1 ,[dtentry]=" + MainMDI.SSV_Bigdate(st_dt) + " where lid=" + lid, " send PRD to cedule...", usr, ref errmsg);
                            if (errmsg.Length > 0) err_stout += "\n" + errmsg;



                            string stSql = " INSERT INTO cedulo_trs   ([joblid]," +
                                " [dts_ce] ,[dte_ce] ,[cur_ce]  ," +
                                "[dts_cm]  ,[dte_cm] ,[cur_cm] "+
                                ",[dts_af] ,[dte_af] ,[cur_af] " +
                                " ,[dts_ach] ,[dte_ach] ,[cur_ach]  " +
                                " ,[dts_rtp] ,[dte_rtp]  ,[cur_rtp] " +
                                " ,[dts_mp]  ,[dte_mp]  ,[cur_mp] " +
                                " ,[dts_fp]  ,[dte_fp]   ,[cur_fp] " +
                                ",[dts_mc]   ,[dte_mc]  ,[cur_mc] " +
                                "  ,[dts_fc] ,[dte_fc] ,[cur_fc] " +
                                "  ,[dts_tst]     ,[dte_tst]    ,[cur_tst] " +
                                "    ,[dts_if]  ,[dte_if]     ,[cur_if] " +
                                "    ,[dts_shp]   ,[dte_shp]  ,[cur_shp] " +
                           "    ,[prio]   ,[delayed012] " +
                                "    ,[dts_inv]   ,[dte_inv]  ,[cur_inv]) " +
                                " VALUES  ("    + lid +
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") + //CE
                                                            //  ", " + MainMDI.SSV_Bigdate(DateTime.Now.ToShortDateString()) +  
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                                ", " + "1" +
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //CM
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                                ", " + "0" +
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //AF
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                                ", " + "0" +
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //ach
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                                ", " + "0" +
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //RTP
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                                ", " + "0" +
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //MP
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                                ", " + "0" +
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //FP
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                                ", " + "0" +
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //MC
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                                ", " + "0" +
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //FC
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                                ", " + "0" +
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //TST
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                                ", " + "0" +
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //IF
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                                ", " + "0" +
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //SHP
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                                ", " + "0" +
                                ", " + newprio +
                                ", " + "0" +
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //INV
                                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                                ", " + "0" +")";


                            MainMDI.Exec_SQL_JFS(stSql, "save New Job TRS......", "");


                            WRT_4stat(lid);




                        }
                    }

                    string json = "OK";

                    //   return Json(json, "application/json");

                    return Json(new { success = true, responseText = "OK" }, JsonRequestBehavior.AllowGet);

                }
         */

    





        public ActionResult  cedule_prj(string c_al_list)
        {

            //   int nbrelays = Regex.Matches(c_al_list, "9999").Count;
            if (c_al_list[0] == ',') c_al_list = c_al_list.Substring(1, c_al_list.Length - 1);
            string Line = c_al_list,err_stout="";
            string c_err = "OK";
            string usr = HttpContext.Session["usr"].ToString();
            string[] Avv = Line.Split(',');
            string st_dt = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
            for (int i = 0; i < Avv.Length; i++)
            {
                string[] tt = Avv[i].Split('-');
                string lid = tt[0];
                string errmsg = "";
                if (Tools.Conv_Dbl(lid) > 0)
                {
                    string st = MainMDI.Find_One_Field("SELECT  prio   FROM [Orig_PSM_FDB].[dbo].[cedulo_trs] where cur_inv < 4 order by prio desc");
                    string newprio = (Tools.Conv_Dbl(st) + 1).ToString();

                    MainMDI.Exec_SQL_JFS("update cedulo_jobs_raw set [scd01]=1 ,[dtentry]=" + MainMDI.SSV_Bigdate(st_dt) + " where lid=" + lid, " send PRD to cedule...", usr, ref errmsg);
                    if (errmsg.Length > 0) err_stout += "\n" + errmsg;

 

                    string stSql = " INSERT INTO cedulo_trs   ([joblid]," +
                        " [dts_ce] ,[dte_ce] ,[cur_ce]  ," +
                        "[dts_cm]  ,[dte_cm] ,[cur_cm] "+
                        ",[dts_af] ,[dte_af] ,[cur_af] " +
                        " ,[dts_ach] ,[dte_ach] ,[cur_ach]  " +
                        " ,[dts_rtp] ,[dte_rtp]  ,[cur_rtp] " +
                        " ,[dts_mp]  ,[dte_mp]  ,[cur_mp] " +
                        " ,[dts_fp]  ,[dte_fp]   ,[cur_fp] " +
                        ",[dts_mc]   ,[dte_mc]  ,[cur_mc] " +
                        "  ,[dts_fc] ,[dte_fc] ,[cur_fc] " +
                        "  ,[dts_tst]     ,[dte_tst]    ,[cur_tst] " +
                        "    ,[dts_if]  ,[dte_if]     ,[cur_if] " +
                        "    ,[dts_shp]   ,[dte_shp]  ,[cur_shp] " +
                   "    ,[prio]   ,[delayed012] " +
                        "    ,[dts_inv]   ,[dte_inv]  ,[cur_inv]" +
                        ",[resp_ce], [resp_cm] ,[resp_af]  ,[resp_ach] ,[resp_rtp]  ,[resp_mp]  ,[resp_fp] ,[resp_mc] ,[resp_fc] ,[resp_tst] ,[resp_if] ,[resp_shp] ,[resp_inv]) " +
                        " VALUES  ("    + lid +
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") + //CE
                                                    //  ", " + MainMDI.SSV_Bigdate(DateTime.Now.ToShortDateString()) +  
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                        ", " + "0" +
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //CM
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                        ", " + "0" +
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //AF
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                        ", " + "1" +
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //ach
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                        ", " + "0" +
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //RTP
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                        ", " + "0" +
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //MP
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                        ", " + "0" +
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //FP
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                        ", " + "0" +
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //MC
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                        ", " + "0" +
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //FC
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                        ", " + "0" +
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //TST
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                        ", " + "0" +
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //IF
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                        ", " + "0" +
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //SHP
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                        ", " + "0" +
                        ", " + newprio +
                        ", " + "0" +
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //INV
                        ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                        ", " + "0" + 
                        ", " + "0" + ", " + "0" + ", " + "0" + ", " + "0" + ", " + "0" + ", " + "0" + ", " + "0" + ", " + "0" + ", " + "0" + ", " + "0"+ ", " + "0"+ ", " + "0" +
                       ", " + "0" +  ")";


                    MainMDI.Exec_SQL_JFS(stSql, "save New Job TRS......", "");


                    WRT_4stat(lid);




                }
            }

            string json = "OK";

            //   return Json(json, "application/json");

            return Json(new { success = true, responseText = "OK" }, JsonRequestBehavior.AllowGet);

        }

        bool WRT_4stat(string joblid)

        {
            string stat = "1";//wait
            string st_dt = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);

            string stSql = " INSERT INTO cedulo_trs_states   ([joblid],[statid]," +
                " [dts_ce] ,[dte_ce]   ," +
                "[dts_cm]  ,[dte_cm]  " +
                ",[dts_af] ,[dte_af]  " +
                " ,[dts_ach] ,[dte_ach]   " +
                " ,[dts_rtp] ,[dte_rtp]   " +
                " ,[dts_mp]  ,[dte_mp]   " +
                " ,[dts_fp]  ,[dte_fp]   " +
                " ,[dts_mc]   ,[dte_mc]   " +
                " ,[dts_fc] ,[dte_fc]  " +
                " ,[dts_tst]     ,[dte_tst]     " +
                " ,[dts_if]  ,[dte_if]     " +
                " ,[dts_shp]   ,[dte_shp]  " +
                " ,[dts_inv]   ,[dte_inv]  ) " +
                " VALUES  (" + joblid + ", " + stat +
                ", " + MainMDI.SSV_Bigdate("01-01-1900") + //CE
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                ", " + MainMDI.SSV_Bigdate("01-01-1900") + //CM
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                ", " + MainMDI.SSV_Bigdate(st_dt) +    //AF  first in wait
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //ach
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //RTP
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //MP
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //FP
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //MC
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //FC
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //TST
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //IF
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //SHP
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +
                ", " + MainMDI.SSV_Bigdate("01-01-1900") +   //INV
                ", " + MainMDI.SSV_Bigdate("01-01-1900") + ")";


            MainMDI.Exec_SQL_JFS(stSql, "save New Stats ......", "");

            return true;
        }



        public ActionResult import_trs(string toto)
        {


            string c_err = "OK";
            toto = "toto";

            string json = "OK";

            //   return Json(json, "application/json");

            return Json(new { success = true, responseText = toto }, JsonRequestBehavior.AllowGet);

        }

        public ActionResult prio_jobs(string myArr,string mdl_arr)
        {
            string[,] newPrio = new string[400, 3], oldprio=new string[400, 2];
            string errmsg = "";
            for (int p=0;p<400;p++) { 
                
                newPrio[p, 0] = ""; newPrio[p, 1] = ""; newPrio[p, 2] = "";
                oldprio[p, 0] = ""; oldprio[p, 1] = "";
            }

            //   int nbrelays = Regex.Matches(c_al_list, "9999").Count;
            if (myArr[0] == ',') myArr = myArr.Substring(1, myArr.Length - 1);
            string Line = myArr, err_stout = "";
            string c_err = "OK";
            string usr = HttpContext.Session["usr"].ToString();
            string[] Avv = Line.Split(',');
       //     string st_dt = DateTime.Now.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture);
            for (int i = 0; i < Avv.Length; i++)
            {
                string[] row = Avv[i].Split('|');
                newPrio[i, 0] = row[0].Replace(" ", "");
                newPrio[i, 1] = row[1].Replace(" ", "");

            }

            if (mdl_arr[0] == ',') mdl_arr = mdl_arr.Substring(1, myArr.Length - 1);
            Line = mdl_arr;
            Avv = Line.Split(',');
            for (int i = 0; i < Avv.Length; i++)
            {
                string[] row = Avv[i].Split('|');
                oldprio[i, 0] = row[0];
                oldprio[i, 1] = row[1];

            }

            for (int i=0;i<400;i++)
            {
                if (newPrio[i, 0] != "")
                {
                    if (newPrio[i, 0] != oldprio[i, 0] && oldprio[i, 0] != "")
                    {
                //        newPrio[i, 1] = oldprio[i, 1];

                        newPrio[i, 2] = oldprio[i, 1]; 
                    }
                   
                }
                else i = 400;


            }

            for (int i = 0; i < 400; i++)
            {
                if (newPrio[i, 0] != "")
                {
                    if (newPrio[i, 2] != "")
                    {
                        string stSql = "Update cedulo_trs  set [prio]='" + newPrio[i, 2] + "' where joblid=" + newPrio[i, 1];
                        MainMDI.Exec_SQL_JFS(stSql, "cedule chng Prio...",usr,ref errmsg);
                    }

                }
                else i = 400;


            }



            string json =(errmsg=="") ? "OK" : errmsg;

            //   return Json(json, "application/json");

            return Json(new { success = true, responseText = json }, JsonRequestBehavior.AllowGet);

        }


        public ActionResult Disp_Steps_old()
        {

            //   System.Threading.Thread.Sleep(2000);


            using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
            {
                //string UN = HttpContext.Session["usr"].ToString();
                trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4).OrderBy(a => a.prio).ToList();

                //if (_SP == "Select" && myMM == 0 && myYYYY == 0) listinvcms = dc.V_u_agcmsmvmt.OrderBy(a => a.Invoice).ToList();
                //else
                //{
                //    if (_SP != "Select" && myMM > 0 && myYYYY > 0) listinvcms = dc.V_u_agcmsmvmt.Where(a => a.SP == _SP && a.MM == myMM && a.YYYY == myYYYY).OrderBy(a => a.Invoice).ToList();
                //    else
                //    {
                //        if (_SP == "Select") { if (myMM > 0 && myYYYY > 0) listinvcms = dc.V_u_agcmsmvmt.Where(a => a.MM == myMM && a.YYYY == myYYYY).OrderBy(a => a.Invoice).ToList(); }
                //        else if (_SP != "Select") listinvcms = dc.V_u_agcmsmvmt.Where(a => a.SP == _SP).OrderBy(a => a.Invoice).ToList();
                //    }

                //}
            }
            //  RedirectToAction("DispSTEPS", "DispSteps");
            //  Response.AddHeader("Refresh", "1");


            //     return View("../Views/AGCMS/DispINVCMS.cshtml", listinvcms);
            //  return View("~/Views/AGCMS/DispINVCMS.cshtml", listinvcms);
            return View(trslist);
        }




        public ActionResult Mecan_xprs_lotsokddddd()
        {
            if (HttpContext.Session["usr"] != null)
            {

                string usr = HttpContext.Session["usr"].ToString();
                ViewBag.userName = usr;
                if (hasAccess('C') && isAdmin_cdl() || (usr.ToLower() == "concept"))
                {
                    fill_prdlist('d');
                    ViewBag.prdlist = prdlist;
                    return View("~/Views/Cedule/addprj.cshtml", prdlist);

                }
                else
                {
                    ViewBag.errormsg = "Access Denied .....";
                    return View("~/Views/Shared/Error.cshtml");

                }
            }
            return View("~/Views/Shared/logon.cshtml");

        }

        public ActionResult xprs_Disp_Steps(string rdr)
        {

            //string orderby= "a => a.pgc_prj"
            string usr = HttpContext.Session["usr"].ToString();
            if (usr != "mmmmmm")
            {
                fill_stepsList();

                string stSql = "SELECT  cedulo_Deps.v_name FROM  cedule_Usetup INNER JOIN  cedulo_Deps ON cedule_Usetup.cpnyID = cedulo_Deps.depcode  where[usrname] = '" + usr + "'";
                string v_name = MainMDI.Find_One_Field(stSql);

                using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
                {
                    //string UN = HttpContext.Session["usr"].ToString();
                    switch (v_name)
                    {
                        case "Disp_Steps_Conc":
                            fill_EmpLists(1); ViewBag.conc_Lst = conc_Lst;
                            ViewBag.conc_stpLst = conc_stpLst;

                            trslist = (rdr=="D") ? dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && (a.cur_ce < 4 || a.cur_cm < 4) && a.cur_af > 0).OrderBy(a => a.prio).ToList()
                                                 : dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && (a.cur_ce < 4 || a.cur_cm < 4) && a.cur_af > 0).OrderBy(a => a.pgc_prj).ToList();

                            break;
                        case "Disp_Steps_Achinv":
                            fill_EmpLists(2); ViewBag.achinv_Lst = achinv_Lst;
                            ViewBag.ach_stpLst = ach_stpLst;

                          //  trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_rtp < 4 && a.cur_ach > 0).OrderBy(a => a.prio).ToList();
                            trslist = (rdr == "D") ? dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_rtp < 4 && a.cur_ach > 0).OrderBy(a => a.prio).ToList()
                                                   : dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_rtp < 4 && a.cur_ach > 0).OrderBy(a => a.pgc_prj).ToList();


                            break;
                        case "Disp_Steps_Mecan":
                            fill_EmpLists(3); ViewBag.mecan_Lst = mecan_Lst;
                            ViewBag.meca_stpLst = meca_stpLst;

                        //    trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && (a.cur_mp < 4 || a.cur_mc < 4) && a.cur_mp > 0).OrderBy(a => a.prio).ToList();
                            trslist = (rdr == "D") ? dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && (a.cur_mp < 4 || a.cur_mc < 4) && a.cur_mp > 0).OrderBy(a => a.prio).ToList()
                                                   : dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && (a.cur_mp < 4 || a.cur_mc < 4) && a.cur_mp > 0).OrderBy(a => a.pgc_prj).ToList();


                            break;
                        case "Disp_Steps_Fila":
                            fill_EmpLists(4); ViewBag.fila_Lst = fila_Lst;
                            ViewBag.flg_stpLst = flg_stpLst;

                      //      trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && (a.cur_fp < 4 || a.cur_fc < 4) && a.cur_fp > 0).OrderBy(a => a.prio).ToList();
                            trslist = (rdr == "D") ? trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && (a.cur_fp < 4 || a.cur_fc < 4) && a.cur_fp > 0).OrderBy(a => a.prio).ToList()
                                                   : trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && (a.cur_fp < 4 || a.cur_fc < 4) && a.cur_fp > 0).OrderBy(a => a.pgc_prj).ToList();



                            break;
                        case "Disp_Steps_Tst":
                            fill_EmpLists(5); ViewBag.tst_Lst = tst_Lst;
                            ViewBag.tst_stpLst = tst_stpLst;

                        //    trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_if < 4 && a.cur_tst > 0).OrderBy(a => a.prio).ToList();
                            trslist = (rdr == "D") ? dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_if < 4 && a.cur_tst > 0).OrderBy(a => a.prio).ToList()
                                                   : trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_if < 4 && a.cur_tst > 0).OrderBy(a => a.pgc_prj).ToList();




                            break;
                        case "Disp_Steps_Shp":
                            fill_EmpLists(6); ViewBag.shp_Lst = shp_Lst;
                            ViewBag.shp_stpLst = shp_stpLst;

                        //    trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_shp < 4 && a.cur_shp > 0).OrderBy(a => a.prio).ToList();
                            trslist = (rdr == "D") ? dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_shp < 4 && a.cur_shp > 0).OrderBy(a => a.prio).ToList()
                                                   : trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_shp < 4 && a.cur_shp > 0).OrderBy(a => a.pgc_prj).ToList();

                            break;
                        case "Disp_Steps_Inv":
                            fill_EmpLists(8); ViewBag.inv_Lst = inv_Lst;
                            ViewBag.inv_stpLst = inv_stpLst;

                       //     trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_inv > 0).OrderBy(a => a.prio).ToList();
                            trslist = (rdr == "D") ? dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_inv > 0).OrderBy(a => a.prio).ToList()
                                                   : trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_inv > 0).OrderBy(a => a.pgc_prj).ToList();

                            break;
                        case "Disp_Steps":
                            // trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4).OrderBy(a => a.prio).ToList();
                            fill_EmpLists(99); ViewBag.all_Lst = all_Lst;
                            ViewBag.all_stpLst = all_stpLst;
                            trslist = (rdr == "D") ? dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4).OrderBy(a => a.prio).ToList()
                                                   : trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4).OrderBy(a => a.pgc_prj).ToList();
                       //     return View("~/Views/Cedule/" + v_name + ".cshtml", trslist);
                            break;
                        default:
                            trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv == 44).OrderBy(a => a.prio).ToList();
                            break;
                    }

                    //trslist = dc.V_cedulotrs_jobs.Where(a=> a.cur_inv< 4) .OrderBy(a => a.prio).ToList();

                }

                if (trslist.Count > 0)
                {
                    if (v_name != MainMDI.VIDE)
                    {
                        return View("~/Views/Cedule/" + v_name + "_xprs.cshtml", trslist);

                    }
                    else
                    {
                        ViewBag.errormsg = "ACCESS Denied.....";
                        return View("~/Views/Shared/Error.cshtml");
                    }
                }
                else
                {
                    ViewBag.errormsg = "SYSTEMS List is Empty..........";
                    return View("~/Views/Shared/Error.cshtml");
                }

            }
            else
            {
                ViewBag.errormsg = ".....Under Construction.....";
                return View("~/Views/Shared/Error.cshtml");
            }

            //return View(trslist);
        }



        public ActionResult Disp_Steps()
        {
            string usr = HttpContext.Session["usr"].ToString();
            string stSql = "SELECT  cedulo_Deps.v_name FROM  cedule_Usetup INNER JOIN  cedulo_Deps ON cedule_Usetup.cpnyID = cedulo_Deps.depcode  where[usrname] = '" + usr + "'";
            string v_name = MainMDI.Find_One_Field(stSql);

            using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
            {
                //string UN = HttpContext.Session["usr"].ToString();
switch (v_name)
                {
                    case "Disp_Steps_Conc":
                        trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && (a.cur_ce < 4  || a.cur_cm < 4 ) && a.cur_af > 0 ).OrderBy(a => a.prio).ToList();
                        break;
                    case "Disp_Steps_Achinv":
                        trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_rtp < 4 && a.cur_ach > 0).OrderBy(a => a.prio).ToList();
                        break;
                    case "Disp_Steps_Mecan":
                        trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && (a.cur_mp < 4 || a.cur_mc < 4) && a.cur_mp > 0 ).OrderBy(a => a.prio).ToList();
                        break;
                    case "Disp_Steps_Fila":
                        trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && (a.cur_fp < 4 || a.cur_fc < 4) && a.cur_fp > 0 ).OrderBy(a => a.prio).ToList();
                        break;
                    case "Disp_Steps_Tst":
                        trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_if < 4 && a.cur_tst > 0 ).OrderBy(a => a.prio).ToList();
                        break;
                    case "Disp_Steps_Shp":
                        trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_shp < 4 && a.cur_shp > 0).OrderBy(a => a.prio).ToList();
                        break;
                    case "Disp_Steps_Inv":
                        trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_inv > 0).OrderBy(a => a.prio).ToList();
                        break;
                    case "Disp_Steps":
                        trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4).OrderBy(a => a.prio).ToList();
                        break;
                    default:
                        trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv == 44).OrderBy(a => a.prio).ToList();
                        break;
                }

                //trslist = dc.V_cedulotrs_jobs.Where(a=> a.cur_inv< 4) .OrderBy(a => a.prio).ToList();
   
            }



           if (v_name !=MainMDI.VIDE  )
            {
                return View("~/Views/Cedule/" + v_name + ".cshtml", trslist);
 
            }   
            else
            {
                ViewBag.errormsg = "ACCESS Denied.....";
                return View("~/Views/Shared/Error.cshtml");
            }

            //return View(trslist);
        }

        

      //public ActionResult Disp_Steps_prj_xprs()
      //  {


      //      using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
      //      {
      //          //string UN = HttpContext.Session["usr"].ToString();
      //          trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4).OrderBy(a => a.pgc_prj).ToList();

      //      }

      //      string usr = HttpContext.Session["usr"].ToString();
      //      string stSql = "SELECT  cedulo_Deps.v_name FROM  cedule_Usetup INNER JOIN  cedulo_Deps ON cedule_Usetup.cpnyID = cedulo_Deps.depcode  where[usrname] = '" + usr + "'";
      //      string v_name = MainMDI.Find_One_Field(stSql);

      //      if (v_name != MainMDI.VIDE)
      //      {
      //          return View("~/Views/Cedule/" + v_name + "_xprs.cshtml", trslist);

      //      }
      //      else
      //      {
      //          ViewBag.errormsg = "ACCESS Denied.....";
      //          return View("~/Views/Shared/Error.cshtml");
      //      }

      //      //return View(trslist);
      //  }

        public ActionResult Disp_Steps_prj()
        {


            using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
            {
                //string UN = HttpContext.Session["usr"].ToString();
                trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4).OrderBy(a => a.pgc_prj).ToList();

            }

            string usr = HttpContext.Session["usr"].ToString();
            string stSql = "SELECT  cedulo_Deps.v_name FROM  cedule_Usetup INNER JOIN  cedulo_Deps ON cedule_Usetup.cpnyID = cedulo_Deps.depcode  where[usrname] = '" + usr + "'";
            string v_name = MainMDI.Find_One_Field(stSql);

            if (v_name != MainMDI.VIDE)
            {
                return View("~/Views/Cedule/" + v_name + ".cshtml", trslist);

            }
            else
            {
                ViewBag.errormsg = "ACCESS Denied.....";
                return View("~/Views/Shared/Error.cshtml");
            }

            //return View(trslist);
        }


        public ActionResult Disp_Steps_p(string prjnb)
        {

            //   System.Threading.Thread.Sleep(2000);


            using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
            {
                //string UN = HttpContext.Session["usr"].ToString();
                trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4).Where(a => a.pgc_prj.Contains(prjnb)).OrderBy(a => a.prio).ToList();

            }
            string usr = HttpContext.Session["usr"].ToString();
            string stSql = "SELECT  cedulo_Deps.v_name FROM  cedule_Usetup INNER JOIN  cedulo_Deps ON cedule_Usetup.cpnyID = cedulo_Deps.depcode  where[usrname] = '" + usr + "'";
            string v_name = MainMDI.Find_One_Field(stSql);

            if (v_name != MainMDI.VIDE)
            {
                return View("~/Views/Cedule/" + v_name + ".cshtml", trslist);

            }
            else
            {
                ViewBag.errormsg = "ACCESS Denied.....";
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        public ActionResult xprs_Disp_Steps_poldddd(string prjnb)
        {

            //   System.Threading.Thread.Sleep(2000);


            using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
            {
                //string UN = HttpContext.Session["usr"].ToString();
                trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4).Where(a => a.pgc_prj.Contains(prjnb)).OrderBy(a => a.prio).ToList();

            }
            string usr = HttpContext.Session["usr"].ToString();
            string stSql = "SELECT  cedulo_Deps.v_name FROM  cedule_Usetup INNER JOIN  cedulo_Deps ON cedule_Usetup.cpnyID = cedulo_Deps.depcode  where[usrname] = '" + usr + "'";
            string v_name = MainMDI.Find_One_Field(stSql);

            if (v_name != MainMDI.VIDE)
            {
                return View("~/Views/Cedule/" + v_name + "_xprs.cshtml", trslist);

            }
            else
            {
                ViewBag.errormsg = "ACCESS Denied.....";
                return View("~/Views/Shared/Error.cshtml");
            }
        }

        public ActionResult xprs_Disp_Steps_p(string prjnb)
        {


            string usr = HttpContext.Session["usr"].ToString();
            if (usr != "mmmmmm")
            {
                fill_stepsList();

                string stSql = "SELECT  cedulo_Deps.v_name FROM  cedule_Usetup INNER JOIN  cedulo_Deps ON cedule_Usetup.cpnyID = cedulo_Deps.depcode  where[usrname] = '" + usr + "'";
                string v_name = MainMDI.Find_One_Field(stSql);

                using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
                {
                    //string UN = HttpContext.Session["usr"].ToString();
                    switch (v_name)
                    {
                        case "Disp_Steps_Conc":
                            fill_EmpLists(1); ViewBag.conc_Lst = conc_Lst;
                            ViewBag.conc_stpLst = conc_stpLst;

                            trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && (a.cur_ce < 4 || a.cur_cm < 4) && a.cur_af > 0).Where(a => a.pgc_prj.Contains(prjnb)).OrderBy(a => a.prio).ToList();

                            break;
                        case "Disp_Steps_Achinv":
                            fill_EmpLists(2); ViewBag.achinv_Lst = achinv_Lst;
                            ViewBag.ach_stpLst = ach_stpLst;

                            trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_rtp < 4 && a.cur_ach > 0).Where(a => a.pgc_prj.Contains(prjnb)).OrderBy(a => a.prio).ToList();
                            break;
                        case "Disp_Steps_Mecan":
                            fill_EmpLists(3); ViewBag.mecan_Lst = mecan_Lst;
                            ViewBag.meca_stpLst = meca_stpLst;

                            trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && (a.cur_mp < 4 || a.cur_mc < 4) && a.cur_mp > 0).Where(a => a.pgc_prj.Contains(prjnb)).OrderBy(a => a.prio).ToList();
                            break;
                        case "Disp_Steps_Fila":
                            fill_EmpLists(4); ViewBag.fila_Lst = fila_Lst;
                            ViewBag.flg_stpLst = flg_stpLst;

                            trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && (a.cur_fp < 4 || a.cur_fc < 4) && a.cur_fp > 0).Where(a => a.pgc_prj.Contains(prjnb)).OrderBy(a => a.prio).ToList();
                            break;
                        case "Disp_Steps_Tst":
                            fill_EmpLists(5); ViewBag.tst_Lst = tst_Lst;
                            ViewBag.tst_stpLst = tst_stpLst;

                            trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_if < 4 && a.cur_tst > 0).Where(a => a.pgc_prj.Contains(prjnb)).OrderBy(a => a.prio).ToList();
                            break;
                        case "Disp_Steps_Shp":
                            fill_EmpLists(6); ViewBag.shp_Lst = shp_Lst;
                            ViewBag.shp_stpLst = shp_stpLst;

                            trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_shp < 4 && a.cur_shp > 0).Where(a => a.pgc_prj.Contains(prjnb)).OrderBy(a => a.prio).ToList();
                            break;
                        case "Disp_Steps_Inv":
                            fill_EmpLists(8); ViewBag.inv_Lst = inv_Lst;
                            ViewBag.inv_stpLst = inv_stpLst;

                            trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4 && a.cur_inv > 0).Where(a => a.pgc_prj.Contains(prjnb)).OrderBy(a => a.prio).ToList();
                            break;
                        case "Disp_Steps":
                            trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4).Where(a => a.pgc_prj.Contains(prjnb)).OrderBy(a => a.prio).ToList();
                            return View("~/Views/Cedule/" + v_name + ".cshtml", trslist);
                            break;
                        default:
                            trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv == 44).OrderBy(a => a.prio).ToList();
                            break;
                    }

                    //trslist = dc.V_cedulotrs_jobs.Where(a=> a.cur_inv< 4) .OrderBy(a => a.prio).ToList();

                }

                if (trslist.Count > 0)
                {
                    if (v_name != MainMDI.VIDE)
                    {
                        return View("~/Views/Cedule/" + v_name + "_xprs.cshtml", trslist);

                    }
                    else
                    {
                        ViewBag.errormsg = "ACCESS Denied.....";
                        return View("~/Views/Shared/Error.cshtml");
                    }
                }
                else
                {
                    ViewBag.errormsg = "SYSTEMS List is Empty..........";
                    return View("~/Views/Shared/Error.cshtml");
                }

            }
            else
            {
                ViewBag.errormsg = ".....Under Construction.....";
                return View("~/Views/Shared/Error.cshtml");
            }

            //return View(trslist);
        }






        /// <summary>
        /// //////////////////////////
        /// </summary>
        /// <returns></returns>
        public ActionResult Disp_Steps_conc()
        {

            //   System.Threading.Thread.Sleep(2000);


            using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
            {
                //string UN = HttpContext.Session["usr"].ToString();
                trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4).OrderBy(a => a.prio).ToList();

                //if (_SP == "Select" && myMM == 0 && myYYYY == 0) listinvcms = dc.V_u_agcmsmvmt.OrderBy(a => a.Invoice).ToList();
                //else
                //{
                //    if (_SP != "Select" && myMM > 0 && myYYYY > 0) listinvcms = dc.V_u_agcmsmvmt.Where(a => a.SP == _SP && a.MM == myMM && a.YYYY == myYYYY).OrderBy(a => a.Invoice).ToList();
                //    else
                //    {
                //        if (_SP == "Select") { if (myMM > 0 && myYYYY > 0) listinvcms = dc.V_u_agcmsmvmt.Where(a => a.MM == myMM && a.YYYY == myYYYY).OrderBy(a => a.Invoice).ToList(); }
                //        else if (_SP != "Select") listinvcms = dc.V_u_agcmsmvmt.Where(a => a.SP == _SP).OrderBy(a => a.Invoice).ToList();
                //    }

                //}
            }
            //  RedirectToAction("DispSTEPS", "DispSteps");
            //  Response.AddHeader("Refresh", "1");


            //     return View("../Views/AGCMS/DispINVCMS.cshtml", listinvcms);
            //  return View("~/Views/AGCMS/DispINVCMS.cshtml", listinvcms);
            return View("~/Views/Cedule/Disp_Steps_Conc.cshtml", trslist);
        }


        public ActionResult Disp_Steps_poldddd(string prjnb)
        {

            //   System.Threading.Thread.Sleep(2000);


            using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
            {
                //string UN = HttpContext.Session["usr"].ToString();
                trslist = dc.V_cedulotrs_jobs.Where(a => a.cur_inv < 4).Where(a=> a.pgc_prj.Contains(prjnb)).OrderBy(a => a.prio).ToList();
    
            }
            //  RedirectToAction("DispSTEPS", "DispSteps");
            //  Response.AddHeader("Refresh", "1");


            //     return View("../Views/AGCMS/DispINVCMS.cshtml", listinvcms);
            //  return View("~/Views/AGCMS/DispINVCMS.cshtml", listinvcms);
            //  return View(trslist);
            return View("~/Views/Cedule/Disp_Steps.cshtml", trslist);
        }

        public ActionResult Editold(long _ID)
        {

            V_cedule_trs_job trs_job = new V_cedule_trs_job();
                using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
            {

                trs_job = dc.V_cedule_trs_job.Where(a => a.trslid == _ID).SingleOrDefault();//.ToList();//     .SingleOrDefault();

            }

            return View(trs_job);
             

        }


        private bool fill_EmpLists(int depcode)
        {


            string myusr = HttpContext.Session["usr"].ToString();

            string stSql = " SELECT  emplid, empName, usrname FROM cedulo_employees where deplid=" + depcode + " order by emplid";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                employee Emp = new employee();
               Emp.emplid = Oreadr[0].ToString() ;
               Emp.empName =  Oreadr[1].ToString().TrimEnd();
                switch(depcode)
                {
                    case 1:
                        conc_Lst.Add(Emp);
                        break;
                    case 2:
                        achinv_Lst.Add(Emp);
                        break;
                    case 3:
                       mecan_Lst.Add(Emp);
                        break;
                    case 4:
                       fila_Lst.Add(Emp);
                        break;
                    case 5:
                       tst_Lst.Add(Emp);
                        break;
                    case 6:
                       shp_Lst.Add(Emp);
                        break;
                    case 8:
                       inv_Lst.Add(Emp);
                        break;
                    case 99:
                        //if (myusr== "eknasrat" && Emp.empName== "Élie") all_Lst.Add(Emp);
                        //if (myusr == "shammou" && Emp.empName == "Smail") all_Lst.Add(Emp);
                        //if (myusr == "ede" && Emp.empName == "ede") all_Lst.Add(Emp);

                        if (myusr == Oreadr[2].ToString().TrimEnd()) all_Lst.Add(Emp);

                        //Emp.empName = Oreadr[2].ToString().TrimEnd();
                        //all_Lst.Add(Emp);
                        break;
                    default:
                        return false;

                }

            }
            OConn.Close();

            return true;

        }


        private void fill_stepsList()
        {

            string stSql = "   SELECT  abr, stpname FROM cedulo_Steps order by stpcode";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                steps mystep = new steps();
                mystep.stpid = Oreadr[0].ToString().TrimEnd();
                mystep.stepname = Oreadr[1].ToString().TrimEnd();

                all_stpLst.Add(mystep);
                switch (mystep.stpid)
                {
                    case "af":
                    case "ce":
                    case "cm":
                        conc_stpLst.Add(mystep);
                        break;
                    case "ach":
                    case "rtp":
                        ach_stpLst.Add(mystep);
                        break;
                    case "mp":
                    case "mc":
                        meca_stpLst.Add(mystep);
                        break;
                    case "fp":
                    case "fc":
                        flg_stpLst.Add(mystep);
                        break;
                    case "tst":
                    case "if":
                        tst_stpLst.Add(mystep);
                        break;
                    case "shp":
                        shp_stpLst.Add(mystep);
                        break;
                    case "inv":
                        inv_stpLst.Add(mystep);
                        break;

                }
            }
            OConn.Close();
        }

            public ActionResult Edit(long _ID)
        {


            fill_EmpLists(1); ViewBag.conclst = conc_Lst;
            fill_EmpLists(2); ViewBag.achinvlst = achinv_Lst;
            fill_EmpLists(3); ViewBag.mecanlst = mecan_Lst;
            fill_EmpLists(4); ViewBag.filalst = fila_Lst;
            fill_EmpLists(5); ViewBag.tstlst = tst_Lst;
            fill_EmpLists(6); ViewBag.shplst = shp_Lst;
            fill_EmpLists(8); ViewBag.invlst = inv_Lst;


            string cpny = HttpContext.Session["cpny"].ToString();
            string lstmdls = MainMDI.Find_One_Field("select DoStps from cedulo_Deps where depcode=" + cpny);
            if (lstmdls != MainMDI.VIDE)
            {
                //check user departement and set viewbag.ce=0 not allowd  viewbag.ce=1 allowd

                ViewBag.ce = (lstmdls.IndexOf("ce-") > -1) ? 1 : 0;
                ViewBag.cm = (lstmdls.IndexOf("cm-") > -1) ? 1 : 0;
                ViewBag.af = (lstmdls.IndexOf("af-") > -1) ? 1 : 0;
                ViewBag.ach = (lstmdls.IndexOf("ach-") > -1) ? 1 : 0;
                ViewBag.rtp = (lstmdls.IndexOf("rtp-") > -1) ? 1 : 0;
                ViewBag.mp = (lstmdls.IndexOf("mp-") > -1) ? 1 : 0;
                ViewBag.fp = (lstmdls.IndexOf("fp-") > -1) ? 1 : 0;
                ViewBag.mc = (lstmdls.IndexOf("mc-") > -1) ? 1 : 0;
                ViewBag.fc = (lstmdls.IndexOf("fc-") > -1) ? 1 : 0;
                ViewBag.tst = (lstmdls.IndexOf("tst-") > -1) ? 1 : 0;
                ViewBag.iif = (lstmdls.IndexOf("if-") > -1) ? 1 : 0;
                ViewBag.shp = (lstmdls.IndexOf("shp-") > -1) ? 1 : 0;
                ViewBag.inv = (lstmdls.IndexOf("inv-") > -1) ? 1 : 0;


                ViewBag.sel = "Select Status";
                ViewBag.inwait = "En attente";
                ViewBag.inpro = "En cours";
                ViewBag.delay = "En retard";
                ViewBag.Done = "Terminé";
                ViewBag.mb = "En cours-Terminé";

                //ViewBag.sel = "Select";
                //ViewBag.inwait = "In Wait";
                //ViewBag.inpro = "In Process";
                //ViewBag.delay = "Delayed";
                //ViewBag.Done = "Finished";
                //ViewBag.mb = "In Process-Finished";

                V_cedulotrs_jobs trs_job = new V_cedulotrs_jobs();
                using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
                {

                    trs_job = dc.V_cedulotrs_jobs.Where(a => a.trslid == _ID).SingleOrDefault();//.ToList();//     .SingleOrDefault();
                    ViewBag.dtjob = trs_job.JobDD.ToString().Substring(0, 10);
                }

                return View(trs_job);
            }
            else
            {
                ViewBag.errormsg = "modules are Empty.....";
                return View("~/Views/Shared/Error.cshtml");
            }

        }

        // bool Validate_STPsoooooold(string _trslid, string _cbst_ce, string _cbst_cm, string _cbst_af, string _cbst_ach, string _cbst_rtp,
        //    string _cbst_mp, string _cbst_fp, string _cbst_mc, string _cbst_fc, string _cbst_tst, string _cbst_if, string _cbst_shp, string _cbst_inv,
        //    string _emp_ce, string _emp_cm, string _emp_af, string _emp_ach, string _emp_rtp,
        //    string _emp_mp, string _emp_fp, string _emp_mc, string _emp_fc, string _emp_tst, string _emp_if, string _emp_shp, string _emp_inv,
        //    ref msgrec mymsg)
        //{


        //    string myusr = HttpContext.Session["usr"].ToString();

        //    mymsg = new msgrec();
        //    mymsg.msg = "";
        //    mymsg.recnb = "0";
        //    string  curr_stat = "";
        //    long mytrslid = Int64.Parse(_trslid);
        //    using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
        //    {
        //        trslist = dc.V_cedulotrs_jobs.Where(a => a.trslid == mytrslid && a.cur_inv < 4).OrderBy(a => a.prio).ToList();
        //    }



        //    string emp_err_msg = "";


        //    //====================AF
        //    string cur_af = trslist[0].cur_af.ToString();
        //    if (cur_af == "2" || _cbst_af == "2") update_emp(myusr, _emp_af, "af", _trslid, ref emp_err_msg);

        //    //   if (_cbst_af != "0" && cur_af != "4" && cur_cm == "4" )
        //    // if (_cbst_af != "0" && cur_af != "4" && cur_cm == "4" && cur_ce == "4")
        //    if (_cbst_af != "0" && cur_af != "4")
        //    {
        //        if (check_Status(cur_af, _cbst_af))

        //        {
        //            maj_trs_stp_stat(_trslid, "af", _cbst_af, _emp_af);
        //            mymsg.msg = "";
        //            mymsg.recnb = "0";
        //        }
        //        else
        //        {
        //            mymsg.msg = "Invalid Status for this STEP ..... ";
        //            mymsg.recnb = "af";
        //        }
        //    }



        //    //====================CE
        //    string cur_ce = trslist[0].cur_ce.ToString();
        //    if (cur_ce == "2" || _cbst_ce == "2") update_emp(myusr, _emp_ce, "ce", _trslid, ref emp_err_msg);
        //    // if (_cbst_ce != "0" && cur_ce != "4") //current pas termine
        //    if (_cbst_ce != "0" && cur_ce != "4")
        //    {
        //        if (_cbst_ce == "Select" || check_Status(cur_ce, _cbst_ce)  )

        //        {
        //          if (_cbst_ce != "Select")  maj_trs_stp_stat(_trslid, "ce", _cbst_ce,_emp_ce);
        //            mymsg.msg = "";
        //            mymsg.recnb = "0";
        //        }
        //        else
        //        {
        //            mymsg.msg = "Invalid Status for this STEP ..... ";
        //            mymsg.recnb = "ce";
        //            return false;
        //        }
        //    }



        //    //====================CM
        //    string cur_cm = trslist[0].cur_cm.ToString();
        //    if (cur_cm == "2" || _cbst_cm == "2") update_emp(myusr, _emp_cm, "cm", _trslid, ref emp_err_msg);
        //  //  if (_cbst_cm != "0" && cur_cm != "4" && cur_ce == "4" ) //current !termine and 'ce' termine
        //  if (_cbst_cm != "0" && cur_cm != "4"  ) 
        //    {

        //        if (check_Status(cur_cm, _cbst_cm))

        //        {
        //            maj_trs_stp_stat(_trslid, "cm", _cbst_cm, _emp_cm);
        //            mymsg.msg = "";
        //            mymsg.recnb = "0";
        //        }
        //        else
        //        {
        //            mymsg.msg = "Invalid Status for this STEP ..... ";
        //            mymsg.recnb = "cm";
        //            return false;
        //        }
        //    }




        //    //====================ACH
        //    string cur_ach = trslist[0].cur_ach.ToString();

        //    if (cur_ach == "2" || _cbst_ach == "2") update_emp(myusr, _emp_ach, "ach", _trslid, ref emp_err_msg);
        //    if (_cbst_ach != "0" && cur_ach != "4" && cur_af == "4" ) //current !termine and 'ce' termine
        //    {
        //        if (check_Status(cur_ach, _cbst_ach))
        //        {
        //            maj_trs_stp_stat(_trslid, "ach", _cbst_ach, _emp_ach);
        //            mymsg.msg = "";
        //            mymsg.recnb = "0";
        //        }
        //        else
        //        {
        //            mymsg.msg = "Invalid Status for this STEP ..... ";
        //            mymsg.recnb = "ach";
        //        }
        //    }



        //    //====================rtp
        //    string cur_rtp = trslist[0].cur_rtp.ToString();

        //    if (cur_rtp == "2" || _cbst_rtp == "2") update_emp(myusr, _emp_rtp, "rtp", _trslid, ref emp_err_msg);
        //    if (_cbst_rtp != "0" && cur_rtp != "4" && cur_ach == "4") //current !termine and 'ce' termine
        //    {
        //        if (check_Status(cur_rtp, _cbst_rtp))
        //        {
        //            maj_trs_stp_stat(_trslid, "rtp", _cbst_rtp, _emp_rtp);
        //            mymsg.msg = "";
        //            mymsg.recnb = "0";
        //        }
        //        else
        //        {
        //            mymsg.msg = "Invalid Status for this STEP ..... ";
        //            mymsg.recnb = "rtp";
        //        }
        //    }



        //    //====================mp
        //    string cur_mp = trslist[0].cur_mp.ToString();

        //    if (cur_mp == "2" || _cbst_mp == "2") update_emp(myusr, _emp_mp, "mp", _trslid, ref emp_err_msg);
        //    if (_cbst_mp != "0" && cur_mp != "4" && cur_rtp == "4") //current !termine and 'ce' termine
        //    {
        //        if (check_Status(cur_mp, _cbst_mp))
        //        {
        //            maj_trs_stp_stat(_trslid, "mp", _cbst_mp, _emp_mp);
        //            mymsg.msg = "";
        //            mymsg.recnb = "0";
        //        }
        //        else
        //        {
        //            mymsg.msg = "Invalid Status for this STEP ..... ";
        //            mymsg.recnb = "mp";
        //        }
        //    }



        //    //====================fp 
        //    string cur_fp = trslist[0].cur_fp.ToString();

        //    if (cur_fp == "2" || _cbst_fp == "2") update_emp(myusr, _emp_fp, "fp", _trslid, ref emp_err_msg);
        //    if (_cbst_fp != "0" && cur_fp != "4" && cur_mp == "4") //current !termine and 'ce' termine
        //    {
        //        if (check_Status(cur_fp, _cbst_fp))
        //        {
        //            maj_trs_stp_stat(_trslid, "fp", _cbst_fp, _emp_fp);
        //            mymsg.msg = "";
        //            mymsg.recnb = "0";
        //        }
        //        else
        //        {
        //            mymsg.msg = "Invalid Status for this STEP ..... ";
        //            mymsg.recnb = "fp";
        //        }
        //    }



        //    //====================MC 
        //    string cur_mc = trslist[0].cur_mc.ToString();

        //    if (cur_mc == "2" || _cbst_mc == "2") update_emp(myusr, _emp_mc, "mc", _trslid, ref emp_err_msg);
        //    if (_cbst_mc != "0" && cur_mc != "4" && cur_fp == "4") //current !termine and 'ce' termine
        //    {
        //        if (check_Status(cur_mc, _cbst_mc))
        //        {
        //            maj_trs_stp_stat(_trslid, "mc", _cbst_mc, _emp_mc);
        //            mymsg.msg = "";
        //            mymsg.recnb = "0";
        //        }
        //        else
        //        {
        //            mymsg.msg = "Invalid Status for this STEP ..... ";
        //            mymsg.recnb = "mc";
        //        }
        //    }




        //    //====================FC 
        //    string cur_fc = trslist[0].cur_fc.ToString();

        //    if (cur_fc == "2" || _cbst_fc == "2") update_emp(myusr, _emp_fc, "fc", _trslid, ref emp_err_msg);
        //    if (_cbst_fc != "0" && cur_fc != "4" && cur_mc == "4") //current !termine and 'ce' termine
        //    {
        //        if (check_Status(cur_fc, _cbst_fc))
        //        {
        //            maj_trs_stp_stat(_trslid, "fc", _cbst_fc, _emp_fc);
        //            mymsg.msg = "";
        //            mymsg.recnb = "0";
        //        }
        //        else
        //        {
        //            mymsg.msg = "Invalid Status for this STEP ..... ";
        //            mymsg.recnb = "fc";
        //        }
        //    }




        //    //====================TST
        //    string cur_tst = trslist[0].cur_tst.ToString();

        //    if (cur_tst == "2" || _cbst_tst == "2") update_emp(myusr, _emp_tst, "tst", _trslid, ref emp_err_msg);
        //    if (_cbst_tst != "0" && cur_tst != "4" && cur_fc == "4") //current !termine and 'ce' termine
        //    {
        //        if (check_Status(cur_tst, _cbst_tst))
        //        {
        //            maj_trs_stp_stat(_trslid, "tst", _cbst_tst, _emp_tst);
        //            mymsg.msg = "";
        //            mymsg.recnb = "0";
        //        }
        //        else
        //        {
        //            mymsg.msg = "Invalid Status for this STEP ..... ";
        //            mymsg.recnb = "tst";
        //        }
        //    }



        //    //====================if
        //    string cur_if = trslist[0].cur_if.ToString();

        //    if (cur_if == "2" || _cbst_if == "2") update_emp(myusr, _emp_if, "if", _trslid, ref emp_err_msg);
        //    if (_cbst_if != "0" && cur_if != "4" && cur_tst == "4") //current !termine and 'ce' termine
        //    {
        //        if (check_Status(cur_if, _cbst_if))
        //        {
        //            maj_trs_stp_stat(_trslid, "if", _cbst_if, _emp_if);
        //            mymsg.msg = "";
        //            mymsg.recnb = "0";
        //        }
        //        else
        //        {
        //            mymsg.msg = "Invalid Status for this STEP ..... ";
        //            mymsg.recnb = "if";
        //        }
        //    }



        //    //====================shp
        //    string cur_shp = trslist[0].cur_shp.ToString();
        //    if (cur_shp == "2" || _cbst_shp == "2") update_emp(myusr, _emp_shp, "shp", _trslid, ref emp_err_msg);
        //    if (_cbst_shp != "0" && cur_shp != "4" && cur_if == "4") //current !termine and 'ce' termine
        //    {
        //        if (check_Status(cur_shp, _cbst_shp))
        //        {
        //            maj_trs_stp_stat(_trslid, "shp", _cbst_shp, _emp_shp);
        //            mymsg.msg = "";
        //            mymsg.recnb = "0";
        //        }
        //        else
        //        {
        //            mymsg.msg = "Invalid Status for this STEP ..... ";
        //            mymsg.recnb = "shp";
        //        }
        //    }



        //    //====================inv
        //    string cur_inv = trslist[0].cur_inv.ToString();

        //    if (cur_inv == "2" || _cbst_inv == "2") update_emp(myusr, _emp_inv, "inv", _trslid, ref emp_err_msg);
        //    if (_cbst_inv != "0" && cur_inv != "4" && cur_shp == "4") //current !termine and 'ce' termine
        //    {
        //        if (check_Status(cur_inv, _cbst_inv))
        //        {
        //            maj_trs_stp_stat(_trslid, "inv", _cbst_inv, _emp_inv);
        //            mymsg.msg = "";
        //            mymsg.recnb = "0";
        //        }
        //        else
        //        {
        //            mymsg.msg = "Invalid Status for this STEP ..... ";
        //            mymsg.recnb = "inv";
        //        }
        //    }



        //    ////emp
        //    //if (Tools.Conv_Dbl(myemp) > 0)
        //    //{
        //    //    stsql = " update cedulo_trs set [resp_" + stp + "]=" + myemp + " where trslid=" + trslid;

        //    //    //        MainMDI.Exec_SQL_JFS(stsql," set inwait curr_"+stp,usr, ref errmsg);
        //    //    MainMDI.ExecSql(stsql, ref errmsg);
        //    //    mymsg.sqlmsg += "||" + errmsg;


        //    //}


        //    return (mymsg.recnb == "0");

        //}
        //########
        


        bool IsDone(string stp)
        {
            return (stp == "4" || stp == "5");
        }
        
        //##
        bool Validate_STPs(string _trslid, string _cbst_ce, string _cbst_cm, string _cbst_af, string _cbst_ach, string _cbst_rtp,
        string _cbst_mp, string _cbst_fp, string _cbst_mc, string _cbst_fc, string _cbst_tst, string _cbst_if, string _cbst_shp, string _cbst_inv,
        string _emp_ce, string _emp_cm, string _emp_af, string _emp_ach, string _emp_rtp,
        string _emp_mp, string _emp_fp, string _emp_mc, string _emp_fc, string _emp_tst, string _emp_if, string _emp_shp, string _emp_inv,
        ref msgrec mymsg)
        {


            string myusr = HttpContext.Session["usr"].ToString();

            mymsg = new msgrec();
            mymsg.msg = "";
            mymsg.recnb = "0";
            string curr_stat = "";
            long mytrslid = Int64.Parse(_trslid);
            using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
            {
                trslist = dc.V_cedulotrs_jobs.Where(a => a.trslid == mytrslid && a.cur_inv < 4).OrderBy(a => a.prio).ToList();
            }



            string emp_err_msg = "";


            //====================AF
            string cur_af = trslist[0].cur_af.ToString();
            if (cur_af == "2" || _cbst_af == "2") update_emp(myusr, _emp_af, "af", _trslid, ref emp_err_msg);

            if (cur_af != "4")
            {
                if (_cbst_af == "0" || _cbst_af == "Select")
                {
                    mymsg.msg = "No Status for Customer Approbation ..... ";
                    mymsg.recnb = "af";
                    return false;
                }

                else
                {
                    if (check_Status(cur_af, _cbst_af))

                    {
                        maj_trs_stp_stat(_trslid, "af", _cbst_af, _emp_af);
                        mymsg.msg = "";
                        mymsg.recnb = "0";
                    }
                    else
                    {
                        mymsg.msg = "Invalid Status for this STEP ..... ";
                        mymsg.recnb = "af";
                    }
                    return (mymsg.recnb == "0");
                }

            }

            //====================CE
            string cur_ce = trslist[0].cur_ce.ToString();
            if (cur_ce == "2" || _cbst_ce == "2") update_emp(myusr, _emp_ce, "ce", _trslid, ref emp_err_msg);
            if (cur_ce != "4")
            {
                if (_cbst_ce == "0" || _cbst_ce == "Select")
                    //return false;
                    _cbst_ce = _cbst_ce;
                else
                {
                    if (check_Status(cur_ce, _cbst_ce))

                    {
                        maj_trs_stp_stat(_trslid, "ce", _cbst_ce, _emp_ce);
                        mymsg.msg = "";
                        mymsg.recnb = "0";

                        string errmsg2 = "";
                        string cur_cmtmp = trslist[0].cur_cm.ToString();
                        // if ((_cbst_ce == "4" || _cbst_ce == "5") && cur_cmtmp == "4") if (!NextSTEP(_trslid, "ce", ref errmsg2)) mymsg.sqlmsg += "----nxtStp err=" + errmsg2;
                        if (IsDone(_cbst_ce)  && cur_cmtmp == "4") if (!NextSTEP(_trslid, "ce", ref errmsg2)) mymsg.sqlmsg += "----nxtStp err=" + errmsg2;
                    }
                    else
                    {
                        mymsg.msg = "Invalid Status for this STEP ..... ";
                        mymsg.recnb = "ce";
                    }
                    return (mymsg.recnb == "0");
                }

            }


            //====================CM
            string cur_cm = trslist[0].cur_cm.ToString();
            if (cur_cm == "2" || _cbst_cm == "2") update_emp(myusr, _emp_cm, "cm", _trslid, ref emp_err_msg);
            if (cur_cm != "4")
            {
                if (_cbst_cm == "0" || _cbst_cm == "Select")
                    return false;
                else
                {
                    if (check_Status(cur_cm, _cbst_cm))

                    {
                        maj_trs_stp_stat(_trslid, "cm", _cbst_cm, _emp_cm);
                        mymsg.msg = "";
                        mymsg.recnb = "0";
                        string errmsg2 = "";
                        //if (_cbst_cm == "4" && cur_ce == "4") if (!NextSTEP(_trslid, "cm", ref errmsg2)) mymsg.sqlmsg += "----nxtStp err=" + errmsg2;
                        if (IsDone(_cbst_cm) && cur_ce == "4") if (!NextSTEP(_trslid, "cm", ref errmsg2)) mymsg.sqlmsg += "----nxtStp err=" + errmsg2;
                    }
                    else
                    {
                        mymsg.msg = "Invalid Status for this STEP ..... ";
                        mymsg.recnb = "cm";
                    }
                    return (mymsg.recnb == "0");
                }

            }
            else if (cur_ce != "4")
            {
                mymsg.msg = "Conception Electrique is not Terminated........... ";
                mymsg.recnb = "cm";
                return false;
            }


            //====================ACH
            string cur_ach = trslist[0].cur_ach.ToString();
            if (cur_ach == "2" || _cbst_ach == "2") update_emp(myusr, _emp_ach, "ach", _trslid, ref emp_err_msg);

            //if (_cbst_ach != "0" && cur_ach != "4" && cur_af == "4") //current !termine and 'ce' termine
            //{
            //    if (check_Status(cur_ach, _cbst_ach))
            //    {
            //        maj_trs_stp_stat(_trslid, "ach", _cbst_ach, _emp_ach);
            //        mymsg.msg = "";
            //        mymsg.recnb = "0";
            //    }
            //    else
            //    {
            //        mymsg.msg = "Invalid Status for this STEP ..... ";
            //        mymsg.recnb = "ach";
            //    }
            //}

            if (cur_ach != "4")
            {
                if (_cbst_ach == "0" || _cbst_ach == "Select")
                {
                    mymsg.msg = "No Status for ACHAT ..... ";
                    mymsg.recnb = "ach";
                    return false;
                }

                else
                {
                    if (check_Status(cur_ach, _cbst_ach))
                    {
                        maj_trs_stp_stat(_trslid, "ach", _cbst_ach, _emp_ach);
                        mymsg.msg = "";
                        mymsg.recnb = "0";
                    }
                    else
                    {
                        mymsg.msg = "Invalid Status for this STEP ..... ";
                        mymsg.recnb = "ach";
                    }
                    return (mymsg.recnb == "0");
                }

            }



            //====================rtp
            string cur_rtp = trslist[0].cur_rtp.ToString();

            if (cur_rtp == "2" || _cbst_rtp == "2") update_emp(myusr, _emp_rtp, "rtp", _trslid, ref emp_err_msg);

            //if (_cbst_rtp != "0" && cur_rtp != "4" && cur_ach == "4") //current !termine and 'ce' termine
            //{
            //if (check_Status(cur_rtp, _cbst_rtp))
            //{
            //    maj_trs_stp_stat(_trslid, "rtp", _cbst_rtp, _emp_rtp);
            //    mymsg.msg = "";
            //    mymsg.recnb = "0";
            //}
            //else
            //{
            //    mymsg.msg = "Invalid Status for this STEP ..... ";
            //    mymsg.recnb = "rtp";
            //}
            //}

            if (cur_rtp != "4")
            {
                if (_cbst_rtp == "0" || _cbst_rtp == "Select")
                {
                    mymsg.msg = "No Status for Pret/Production ..... ";
                    mymsg.recnb = "rtp";
                    return false;
                }

                else
                {
                    if (check_Status(cur_rtp, _cbst_rtp))
                    {
                        maj_trs_stp_stat(_trslid, "rtp", _cbst_rtp, _emp_rtp);
                        mymsg.msg = "";
                        mymsg.recnb = "0";
                    }
                    else
                    {
                        mymsg.msg = "Invalid Status for this STEP ..... ";
                        mymsg.recnb = "rtp";
                    }
                    return (mymsg.recnb == "0");
                }

            }


            //====================mp
            string cur_mp = trslist[0].cur_mp.ToString();

            if (cur_mp == "2" || _cbst_mp == "2") update_emp(myusr, _emp_mp, "mp", _trslid, ref emp_err_msg);

            //if (_cbst_mp != "0" && cur_mp != "4" && cur_rtp == "4") //current !termine and 'ce' termine
            //{
            //    if (check_Status(cur_mp, _cbst_mp))
            //    {
            //        maj_trs_stp_stat(_trslid, "mp", _cbst_mp, _emp_mp);
            //        mymsg.msg = "";
            //        mymsg.recnb = "0";
            //    }
            //    else
            //    {
            //        mymsg.msg = "Invalid Status for this STEP ..... ";
            //        mymsg.recnb = "mp";
            //    }
            //}

            if (cur_mp != "4")
            {
                if (_cbst_mp == "0" || _cbst_mp == "Select")
                {
                    //mymsg.msg = "No Status for Mecan plaq..... ";
                    //mymsg.recnb = "mp";
                    //return false;
                    _cbst_mp = _cbst_mp;
                }

                else
                {
                    if (check_Status(cur_mp, _cbst_mp))
                    {
                        maj_trs_stp_stat(_trslid, "mp", _cbst_mp, _emp_mp);
                        mymsg.msg = "";
                        mymsg.recnb = "0";
                        string errmsg2 = "";
                        //if (_cbst_mp == "4" ) if (!NextSTEP(_trslid, "mp", ref errmsg2)) mymsg.sqlmsg += "----nxtStp err=" + errmsg2;
                        if (IsDone (_cbst_mp)) if (!NextSTEP(_trslid, "mp", ref errmsg2)) mymsg.sqlmsg += "----nxtStp err=" + errmsg2;
                    }
                    else
                    {
                        mymsg.msg = "Invalid Status for this STEP ..... ";
                        mymsg.recnb = "mp";
                    }
                    return (mymsg.recnb == "0");
                }

            }


            //====================fp 
            string cur_fp = trslist[0].cur_fp.ToString();

            if (cur_fp == "2" || _cbst_fp == "2") update_emp(myusr, _emp_fp, "fp", _trslid, ref emp_err_msg);

            //if (_cbst_fp != "0" && cur_fp != "4" && cur_mp == "4") //current !termine and 'ce' termine
            //{
            //    if (check_Status(cur_fp, _cbst_fp))
            //    {
            //        maj_trs_stp_stat(_trslid, "fp", _cbst_fp, _emp_fp);
            //        mymsg.msg = "";
            //        mymsg.recnb = "0";
            //    }
            //    else
            //    {
            //        mymsg.msg = "Invalid Status for this STEP ..... ";
            //        mymsg.recnb = "fp";
            //    }
            //}

            if (cur_fp != "4")
            {
                if (_cbst_fp == "0" || _cbst_fp == "Select")
                {
                    //mymsg.msg = "No Status for fp..... ";
                    //mymsg.recnb = "fp";
                    //return false;
                    _cbst_fp = _cbst_fp;
                }

                else
                {
                    if (check_Status(cur_fp, _cbst_fp))
                    {
                        maj_trs_stp_stat(_trslid, "fp", _cbst_fp, _emp_fp);
                        mymsg.msg = "";
                        mymsg.recnb = "0";

                        string errmsg2 = "";
                        string cur_mctmp = trslist[0].cur_mc.ToString();
                        string cur_fctmp = trslist[0].cur_fc.ToString();
                        //if (_cbst_fp == "4" && cur_mctmp == "4" && cur_fctmp == "4") if (!NextSTEP(_trslid, "fp", ref errmsg2)) mymsg.sqlmsg += "----nxtStp err=" + errmsg2;
                     
                        // fp does nothing
                        // if (IsDone (_cbst_fp) && cur_mctmp == "4" && cur_fctmp == "4") if (!NextSTEP(_trslid, "fp", ref errmsg2)) mymsg.sqlmsg += "----nxtStp err=" + errmsg2;
                    }
                    else
                    {
                        mymsg.msg = "Invalid Status for this STEP ..... ";
                        mymsg.recnb = "fp";
                    }
                    return (mymsg.recnb == "0");
                }

            }




            //====================MC 
            string cur_mc = trslist[0].cur_mc.ToString();

            if (cur_mc == "2" || _cbst_mc == "2") update_emp(myusr, _emp_mc, "mc", _trslid, ref emp_err_msg);

            //if (_cbst_mc != "0" && cur_mc != "4" && cur_fp == "4") //current !termine and 'ce' termine
            //{
            //    if (check_Status(cur_mc, _cbst_mc))
            //    {
            //        maj_trs_stp_stat(_trslid, "mc", _cbst_mc, _emp_mc);
            //        mymsg.msg = "";
            //        mymsg.recnb = "0";
            //    }
            //    else
            //    {
            //        mymsg.msg = "Invalid Status for this STEP ..... ";
            //        mymsg.recnb = "mc";
            //    }
            //}

            if (cur_mc != "4")
            {
                if (_cbst_mc == "0" || _cbst_mc == "Select")
                {
                    //mymsg.msg = "No Status for mc..... ";
                    //mymsg.recnb = "mc";
                    //return false;
                    _cbst_mc = _cbst_mc;
                }
                else
                {
                    string cur_fptmp = trslist[0].cur_fp.ToString();
                    bool fpdone = true;
                    if (_cbst_mc == "4" && Tools.Conv_Dbl(cur_fptmp) < 4) fpdone = false;
                    if (check_Status(cur_mc, _cbst_mc) && fpdone)
                    {
                        maj_trs_stp_stat(_trslid, "mc", _cbst_mc, _emp_mc);
                        mymsg.msg = "";
                        mymsg.recnb = "0";

                        string errmsg2 = "";
                      //  string cur_fptmp = trslist[0].cur_fp.ToString();
                        string cur_fctmp = trslist[0].cur_fc.ToString();
                        //if (_cbst_mc == "4" && cur_fptmp == "4" && cur_fctmp == "4") if (!NextSTEP(_trslid, "mc", ref errmsg2)) mymsg.sqlmsg += "----nxtStp err=" + errmsg2;
                       // if (IsDone(_cbst_mc) && cur_fptmp == "4" && cur_fctmp == "4") if (!NextSTEP(_trslid, "mc", ref errmsg2)) mymsg.sqlmsg += "----nxtStp err=" + errmsg2;

                        if (IsDone(_cbst_mc) && cur_fptmp == "4" ) if (!NextSTEP(_trslid, "mc", ref errmsg2)) mymsg.sqlmsg += "----nxtStp err=" + errmsg2;
                    }
                    else
                    {
                        mymsg.msg = "Invalid Status for this STEP ..... ";
                        mymsg.recnb = "mc";
                    }
                    return (mymsg.recnb == "0");
                }

            }


            //====================FC 
            string cur_fc = trslist[0].cur_fc.ToString();
            if (cur_fc == "2" || _cbst_fc == "2") update_emp(myusr, _emp_fc, "fc", _trslid, ref emp_err_msg);

            //if (_cbst_fc != "0" && cur_fc != "4" && cur_mc == "4") //current !termine and 'ce' termine
            //{
            //    if (check_Status(cur_fc, _cbst_fc))
            //    {
            //        maj_trs_stp_stat(_trslid, "fc", _cbst_fc, _emp_fc);
            //        mymsg.msg = "";
            //        mymsg.recnb = "0";
            //    }
            //    else
            //    {
            //        mymsg.msg = "Invalid Status for this STEP ..... ";
            //        mymsg.recnb = "fc";
            //    }
            //}

            if (cur_fc != "4")
            {
                if (_cbst_fc == "0" || _cbst_fc == "Select")
                {
                    mymsg.msg = "No Status for fc..... ";
                    mymsg.recnb = "fc";
                    return false;
                }
                else
                {
                        if (check_Status(cur_fc, _cbst_fc))
                        {
                            maj_trs_stp_stat(_trslid, "fc", _cbst_fc, _emp_fc);
                            mymsg.msg = "";
                            mymsg.recnb = "0";

                            string errmsg2 = "";
                            string cur_fptmp = trslist[0].cur_fp.ToString();
                            string cur_mctmp = trslist[0].cur_mc.ToString();
                            //if (_cbst_fc == "4" && cur_fptmp == "4" && cur_mctmp == "4") if (!NextSTEP(_trslid, "fc", ref errmsg2)) mymsg.sqlmsg += "----nxtStp err=" + errmsg2
                            if (IsDone(_cbst_fc) && cur_fptmp == "4" && cur_mctmp == "4") if (!NextSTEP(_trslid, "fc", ref errmsg2)) mymsg.sqlmsg += "----nxtStp err=" + errmsg2; ;
                        }
                        else
                        {
                            mymsg.msg = "Invalid Status for this STEP ..... ";
                            mymsg.recnb = "fc";
                        }
                        return (mymsg.recnb == "0");
                    }
                  
              
            }


            //====================TST
            string cur_tst = trslist[0].cur_tst.ToString();

            if (cur_tst == "2" || _cbst_tst == "2") update_emp(myusr, _emp_tst, "tst", _trslid, ref emp_err_msg);

            //if (_cbst_tst != "0" && cur_tst != "4" && cur_fc == "4") //current !termine and 'ce' termine
            //{
            //    if (check_Status(cur_tst, _cbst_tst))
            //    {
            //        maj_trs_stp_stat(_trslid, "tst", _cbst_tst, _emp_tst);
            //        mymsg.msg = "";
            //        mymsg.recnb = "0";
            //    }
            //    else
            //    {
            //        mymsg.msg = "Invalid Status for this STEP ..... ";
            //        mymsg.recnb = "tst";
            //    }
            //}

            if (cur_tst != "4")
            {
                if (_cbst_tst == "0" || _cbst_tst == "Select")
                {
                    mymsg.msg = "No Status for tst..... ";
                    mymsg.recnb = "tst";
                    return false;
                }
                else
                {
                    if (check_Status(cur_tst, _cbst_tst))
                    {
                        maj_trs_stp_stat(_trslid, "tst", _cbst_tst, _emp_tst);
                        mymsg.msg = "";
                        mymsg.recnb = "0";
                    }
                    else
                    {
                        mymsg.msg = "Invalid Status for this STEP ..... ";
                        mymsg.recnb = "tst";
                    }
                    return (mymsg.recnb == "0");
                }

            }

            //====================if
            string cur_if = trslist[0].cur_if.ToString();

            if (cur_if == "2" || _cbst_if == "2") update_emp(myusr, _emp_if, "if", _trslid, ref emp_err_msg);

            //if (_cbst_if != "0" && cur_if != "4" && cur_tst == "4") //current !termine and 'ce' termine
            //{
            //    if (check_Status(cur_if, _cbst_if))
            //    {
            //        maj_trs_stp_stat(_trslid, "if", _cbst_if, _emp_if);
            //        mymsg.msg = "";
            //        mymsg.recnb = "0";
            //    }
            //    else
            //    {
            //        mymsg.msg = "Invalid Status for this STEP ..... ";
            //        mymsg.recnb = "if";
            //    }
            //}

            if (cur_if != "4")
            {
                if (_cbst_if == "0" || _cbst_if == "Select")
                {
                    mymsg.msg = "No Status for if..... ";
                    mymsg.recnb = "if";
                    return false;
                }
                else
                {
                    if (check_Status(cur_if, _cbst_if))
                    {
                        maj_trs_stp_stat(_trslid, "if", _cbst_if, _emp_if);
                        mymsg.msg = "";
                        mymsg.recnb = "0";
                    }
                    else
                    {
                        mymsg.msg = "Invalid Status for this STEP ..... ";
                        mymsg.recnb = "if";
                    }
                    return (mymsg.recnb == "0");
                }

            }


            //====================shp
            string cur_shp = trslist[0].cur_shp.ToString();
            if (cur_shp == "2" || _cbst_shp == "2") update_emp(myusr, _emp_shp, "shp", _trslid, ref emp_err_msg);

            //if (_cbst_shp != "0" && cur_shp != "4" && cur_if == "4") //current !termine and 'ce' termine
            //{
            //    if (check_Status(cur_shp, _cbst_shp))
            //    {
            //        maj_trs_stp_stat(_trslid, "shp", _cbst_shp, _emp_shp);
            //        mymsg.msg = "";
            //        mymsg.recnb = "0";
            //    }
            //    else
            //    {
            //        mymsg.msg = "Invalid Status for this STEP ..... ";
            //        mymsg.recnb = "shp";
            //    }
            //}

            if (cur_shp != "4")
            {
                if (_cbst_shp == "0" || _cbst_shp == "Select")
                {
                    mymsg.msg = "No Status for shp..... ";
                    mymsg.recnb = "shp";
                    return false;
                }
                else
                {
                    if (check_Status(cur_shp, _cbst_shp))
                    {
                        maj_trs_stp_stat(_trslid, "shp", _cbst_shp, _emp_shp);
                        mymsg.msg = "";
                        mymsg.recnb = "0";
                    }
                    else
                    {
                        mymsg.msg = "Invalid Status for this STEP ..... ";
                        mymsg.recnb = "shp";
                    }
                    return (mymsg.recnb == "0");
                }

            }

            //====================inv
            string cur_inv = trslist[0].cur_inv.ToString();

            if (cur_inv == "2" || _cbst_inv == "2") update_emp(myusr, _emp_inv, "inv", _trslid, ref emp_err_msg);

            //if (_cbst_inv != "0" && cur_inv != "4" && cur_shp == "4") //current !termine and 'ce' termine
            //{
            //    if (check_Status(cur_inv, _cbst_inv))
            //    {
            //        maj_trs_stp_stat(_trslid, "inv", _cbst_inv, _emp_inv);
            //        mymsg.msg = "";
            //        mymsg.recnb = "0";
            //    }
            //    else
            //    {
            //        mymsg.msg = "Invalid Status for this STEP ..... ";
            //        mymsg.recnb = "inv";
            //    }
            //}

            if (cur_inv != "4")
            {
                if (_cbst_inv == "0" || _cbst_inv == "Select")
                {
                    mymsg.msg = "No Status for inv..... ";
                    mymsg.recnb = "inv";
                    return false;
                }
                else
                {
                    if (check_Status(cur_inv, _cbst_inv))
                    {
                        maj_trs_stp_stat(_trslid, "inv", _cbst_inv, _emp_inv);
                        mymsg.msg = "";
                        mymsg.recnb = "0";
                    }
                    else
                    {
                        mymsg.msg = "Invalid Status for this STEP ..... ";
                        mymsg.recnb = "inv";
                    }
                    return (mymsg.recnb == "0");
                }

            }

            ////emp
            //if (Tools.Conv_Dbl(myemp) > 0)
            //{
            //    stsql = " update cedulo_trs set [resp_" + stp + "]=" + myemp + " where trslid=" + trslid;

            //    //        MainMDI.Exec_SQL_JFS(stsql," set inwait curr_"+stp,usr, ref errmsg);
            //    MainMDI.ExecSql(stsql, ref errmsg);
            //    mymsg.sqlmsg += "||" + errmsg;


            //}


            return (mymsg.recnb == "0");

        }

        void update_emp(string _usr,string myemp,string stp,string trslid,ref string errmsg)
        {
            
            if (Tools.Conv_Dbl(myemp) > 0)
            {

                string stsql = " update cedulo_trs set [resp_" + stp + "]=" + myemp + " where trslid=" + trslid;

                //        MainMDI.Exec_SQL_JFS(stsql," set inwait curr_"+stp,usr, ref errmsg);
               // MainMDI.ExecSql(stsql, ref errmsg);
                MainMDI.Exec_SQL_JFS(stsql, "chng respo.", _usr, ref errmsg);
             //   mymsg.sqlmsg += "||" + errmsg;


            }


        }


        public ActionResult xprs_savstp(string c_al_list, string stp, string stat, string empid)
        {

            //   int nbrelays = Regex.Matches(c_al_list, "9999").Count;
            if (c_al_list[0] == ',') c_al_list = c_al_list.Substring(1, c_al_list.Length - 1);
            string Line = c_al_list, err_stout = "";
            string c_err = "OK";
            string usr = HttpContext.Session["usr"].ToString();
            string[] Avv = Line.Split(',');

            string _cbst_ce = (stp == "ce") ? stat : "Select", _cbst_cm = (stp == "cm") ? stat : "Select",
                 _cbst_af = (stp == "af") ? stat : "Select", _cbst_ach = (stp == "ach") ? stat : "Select",
                 _cbst_rtp = (stp == "rtp") ? stat : "Select", _cbst_mp = (stp == "mp") ? stat : "Select",
                 _cbst_fp = (stp == "fp") ? stat : "Select", _cbst_mc = (stp == "mc") ? stat : "Select",
                 _cbst_fc = (stp == "fc") ? stat : "Select", _cbst_tst = (stp == "tst") ? stat : "Select",
            _cbst_if = (stp == "if") ? stat : "Select", _cbst_shp = (stp == "shp") ? stat : "Select", _cbst_inv = (stp == "inv") ? stat : "Select",
            _emp_ce = (stp == "ce") ? empid : "0", _emp_cm = (stp == "cm") ? empid : "0", _emp_af = (stp == "af") ? empid : "0",
            _emp_ach = (stp == "ach") ? empid : "0", _emp_rtp = (stp == "rtp") ? empid : "0", _emp_mp = (stp == "mp") ? empid : "0",
            _emp_fp = (stp == "fp") ? empid : "0", _emp_mc = (stp == "mc") ? empid : "0", _emp_fc = (stp == "fc") ? empid : "0",
            _emp_tst = (stp == "tst") ? empid : "0", _emp_if = (stp == "if") ? empid : "0", _emp_shp = (stp == "shp") ? empid : "0",
            _emp_inv = (stp == "inv") ? empid : "0";

            string resp = "";
            mymsg = new msgrec();
            mymsg.msg = "";
            mymsg.recnb = "0";
            for (int i = 0; i < Avv.Length; i++)
            {
                //string[] tt = Avv[i].Split('-');
                //string lid = tt[0];
                string _trslid = Avv[i];
                  
                if (Tools.Conv_Dbl(_trslid) > 0)
                {
                    HttpContext.Session["errsql"] = "";

                    Validate_STPs(_trslid, _cbst_ce, _cbst_cm, _cbst_af, _cbst_ach, _cbst_rtp,
                                         _cbst_mp, _cbst_fp, _cbst_mc, _cbst_fc, _cbst_tst, _cbst_if, _cbst_shp, _cbst_inv,
                                         _emp_ce, _emp_cm, _emp_af, _emp_ach, _emp_rtp, _emp_mp, _emp_fp, _emp_mc, _emp_fc, _emp_tst, _emp_if, _emp_shp, _emp_inv,
                                         ref mymsg);
                     if (mymsg.msg.Length>0)    resp += "\n " +mymsg.msg+"-  ID= "+ _trslid;
                }
              //  else resp += "|| Invalid trslid ...... call your admin.....";
            }

            //   return Json(new { success = true, responseText = resp }, JsonRequestBehavior.AllowGet);
            return Json( resp , JsonRequestBehavior.AllowGet);
        }

        public JsonResult sav_Newstat(string _trslid, string _cbst_ce, string _cbst_cm, string _cbst_af, string _cbst_ach, string _cbst_rtp, 
            string _cbst_mp, string _cbst_fp, string _cbst_mc, string _cbst_fc, string _cbst_tst, string _cbst_if, string _cbst_shp, string _cbst_inv,
            string _emp_ce, string _emp_cm, string _emp_af, string _emp_ach, string _emp_rtp,
            string _emp_mp, string _emp_fp, string _emp_mc, string _emp_fc, string _emp_tst, string _emp_if, string _emp_shp, string _emp_inv )
        {
            //    "SELECT pct1,pct2,pct3,pct4  FROM U_ag_tskgrpcof where grp = '" + grp + "'", ref pct1, ref pct2, ref pct3, ref pct4);

            HttpContext.Session["errsql"] = "";
        

            mymsg.msg = "";
            mymsg.sqlmsg = "5s5";
            mymsg.recnb = "0";
            string resp = "";
            if (Tools.Conv_Dbl(_trslid) > 0)
            {
              if (Validate_STPs( _trslid,  _cbst_ce,  _cbst_cm,  _cbst_af,  _cbst_ach,  _cbst_rtp,
                                 _cbst_mp,  _cbst_fp,  _cbst_mc,  _cbst_fc,  _cbst_tst,  _cbst_if,  _cbst_shp,  _cbst_inv,
                                 _emp_ce, _emp_cm, _emp_af, _emp_ach, _emp_rtp,_emp_mp,_emp_fp, _emp_mc,_emp_fc, _emp_tst,_emp_if,_emp_shp,_emp_inv,
                                 ref mymsg))
                  resp="OK";

            }
            else
            {
                mymsg.msg = "Invalid trslid ...... call your admin.....";
                mymsg.recnb = "99";
            }
            msgLst.Add(mymsg);
            return Json(msgLst, JsonRequestBehavior.AllowGet);

        }

        bool check_Statusolddddddd(string curr_st, string newst)
        {
            if (HttpContext.Session["usr"].ToString () != "shammouuuuuu")  // if (HttpContext.Session["usr"].ToString () != "shammou")
            {
                if (curr_st == "0" && newst == "1") return true;
                if (curr_st == "1" && newst == "2") return true;
                if (curr_st == "2" && (newst == "3" || newst == "4")) return true;
                //   if (curr_st == "3" && ((newst == "4") || newst == "2")) return true;
                if (curr_st == "3" && (newst == "2")) return true;
              
            }
            else
            {
                if (curr_st == "0" && (newst == "1" || newst == "4")) return true;
                if (curr_st == "1" && (newst == "2" || newst == "4")) return true;
                if (curr_st == "2" && (newst == "3" || newst == "4")) return true;
                //   if (curr_st == "3" && ((newst == "4") || newst == "2")) return true;
                if (curr_st == "3" && (newst == "2" || newst == "4")) return true;
            }
            return false;
        }
        bool check_Status(string curr_st, string newst)
        {

            if (curr_st == "1" && newst == "5") return true;
            if (curr_st == "0" && newst == "1") return true;
                if (curr_st == "1" && newst == "2") return true;
                if (curr_st == "2" && (newst == "3" || newst == "4")) return true;
                //   if (curr_st == "3" && ((newst == "4") || newst == "2")) return true;
                if (curr_st == "3" && (newst == "2")) return true;
    
            return false;
        }

        bool check_Status_para(string curr_st, string newst)
        {

            if (newst == "Select") return true;
            if (curr_st == "0" && newst == "1") return true;
            if (curr_st == "1" && newst == "2") return true;
            if (curr_st == "2" && (newst == "3" || newst == "4")) return true;
            if (curr_st == "3" && (newst == "2")) return true;

            return false;
        }



        bool maj_trs_stp_stat(string trslid, string stp, string stat,string myemp)
        {
            string stsql = "", errmsg = "";
           string errmsg_st = "";
            string myusr = HttpContext.Session["usr"].ToString();
            // string st_dt = string.Format(DateTime.Now.ToString(), "ddmmyyyy");//   .ToShortDateString();
            string st_dt = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
         //   mymsg.sqlmsg += "||date 103= " + st_dt;
            switch (stat)
            {
                case "1":
                    stsql = " update cedulo_trs set [cur_" + stp + "]=1 where trslid=" + trslid;

                    //        MainMDI.Exec_SQL_JFS(stsql," set inwait curr_"+stp,usr, ref errmsg);
                    //   MainMDI.ExecSql(stsql, ref errmsg);
                    MainMDI.Exec_SQL_JFS(stsql, "maj_trs_stp_stat...", myusr,ref errmsg);
                    mymsg.sqlmsg += "||" + errmsg;

                    //emp
                    if (Tools.Conv_Dbl(myemp) > 0)
                    {
                        stsql = " update cedulo_trs set [resp_" + stp + "]=" + myemp + " where trslid=" + trslid;

                        //        MainMDI.Exec_SQL_JFS(stsql," set inwait curr_"+stp,usr, ref errmsg);
                      //  MainMDI.ExecSql(stsql, ref errmsg);
                        MainMDI.Exec_SQL_JFS(stsql, "maj_trs_stp_stat...", myusr, ref errmsg);
                        mymsg.sqlmsg += "||" + errmsg;


                    }
                        //update cedulo_trs_states
                        stsql = sql_trs_states('S', "1", stp, trslid);
                    if (stsql != MainMDI.VIDE)
                    {
                        //  MainMDI.ExecSql(stsql, ref errmsg);
                        MainMDI.Exec_SQL_JFS(stsql, "maj_trs_stp_stat...", myusr, ref errmsg);
                        //MainMDI.Exec_SQL_JFS(stsql, "", usr, ref errmsg);
                        mymsg.sqlmsg += "||" + errmsg;
                    }
                    else mymsg.sqlmsg += "||" + " error write start cedulo_trs_states..1..";

                    //return (errmsg == "");
                    break;
                case "2":
                    string dt = MainMDI.Find_One_Field("SELECT dts_" + stp + " FROM [Orig_PSM_FDB].[dbo].[cedulo_trs] where  dts_" + stp + " > CONVERT(DATETIME, '1900-01-01 00:00:00', 102) and   trslid=" + trslid);
                    if (dt == MainMDI.VIDE )
                                 stsql = " update cedulo_trs set [cur_" + stp + "]=2,[dts_" + stp + "]=" + MainMDI.SSV_Bigdate(st_dt) + " where trslid=" + trslid;
                 
                  else  stsql = " update cedulo_trs set [cur_" + stp + "]=2  where trslid=" + trslid;

                    //    MainMDI.ExecSql(stsql, ref errmsg);
                    MainMDI.Exec_SQL_JFS(stsql, "maj_trs_stp_stat...", myusr, ref errmsg);
                    mymsg.sqlmsg += "||" + errmsg;

                    //emp
                    if (Tools.Conv_Dbl(myemp) > 0)
                    {
                        stsql = " update cedulo_trs set [resp_" + stp + "]=" + myemp + " where trslid=" + trslid;

                        //        MainMDI.Exec_SQL_JFS(stsql," set inwait curr_"+stp,usr, ref errmsg);
                        //    MainMDI.ExecSql(stsql, ref errmsg);
                        MainMDI.Exec_SQL_JFS(stsql, "maj_trs_stp_stat...", myusr, ref errmsg);
                        mymsg.sqlmsg += "||" + errmsg;


                    }


                    //update cedulo_trs_states
                    stsql = sql_trs_states('E', "1", stp, trslid);
                    if (stsql!=MainMDI.VIDE  )
                    {
                        // MainMDI.ExecSql(stsql, ref errmsg);
                        MainMDI.Exec_SQL_JFS(stsql, "maj_trs_stp_stat...", myusr, ref errmsg);
                        //MainMDI.Exec_SQL_JFS(stsql, "", usr, ref errmsg);
                        mymsg.sqlmsg += "||" + errmsg;
                    }
                    else mymsg.sqlmsg += "||" + " error write End cedulo_trs_states..1..";

                    break;
                case "3":
                    stsql = " update cedulo_trs set [cur_" + stp + "]=3,[delayed012]=1 where trslid=" + trslid;
                    //      stsql = " update cedulo_trs set [delayed012]=1 where trslid=" + trslid;
                    //   MainMDI.ExecSql(stsql, ref errmsg);
                    MainMDI.Exec_SQL_JFS(stsql, "maj_trs_stp_stat...", myusr, ref errmsg);
                    mymsg.sqlmsg += "||" + errmsg;

                    ////emp
                    //if (Tools.Conv_Dbl(myemp) > 0)
                    //{
                    //    stsql = " update cedulo_trs set [resp_" + stp + "]=" + myemp + " where trslid=" + trslid;

                    //    //        MainMDI.Exec_SQL_JFS(stsql," set inwait curr_"+stp,usr, ref errmsg);
                    //    MainMDI.ExecSql(stsql, ref errmsg);
                    //    mymsg.sqlmsg += "||" + errmsg;


                    //}
                   
                    break;
                case "4":

                    stsql = " update cedulo_trs set [cur_" + stp + "]=4,[dte_" + stp + "]=" + MainMDI.SSV_Bigdate(st_dt) + " where trslid=" + trslid;
                    //     MainMDI.ExecSql(stsql, ref errmsg);
                    MainMDI.Exec_SQL_JFS(stsql, "maj_trs_stp_stat...", myusr, ref errmsg);
                    mymsg.sqlmsg += "||" + errmsg;
                    if (errmsg.Length < stsql.Length)
                    {
                        string errmsg2 = "";
                        //update next step as 1....en attente
                        //if (stp != "ce" && stp != "cm" && stp != "mp" && stp != "fp" && stp != "mc" && stp != "fc")
                        if (stp == "af" || stp == "ach" || stp == "rtp" || stp == "tst" || stp == "if" || stp == "shp" || stp == "inv")
                        {
                            if (!NextSTEP(trslid, stp, ref errmsg2)) mymsg.sqlmsg += "----nxtStp err=" + errmsg2;
                            else mymsg.sqlmsg += "----" + errmsg2;
                        }
                      
                    }
                    else return false;
                    break;
                case "5":
                    //2
                    dt = MainMDI.Find_One_Field("SELECT dts_" + stp + " FROM [Orig_PSM_FDB].[dbo].[cedulo_trs] where  dts_" + stp + " > CONVERT(DATETIME, '1900-01-01 00:00:00', 102) and   trslid=" + trslid);
                    if (dt == MainMDI.VIDE)
                        stsql = " update cedulo_trs set [cur_" + stp + "]=2,[dts_" + stp + "]=" + MainMDI.SSV_Bigdate(st_dt) + " where trslid=" + trslid;

                    else stsql = " update cedulo_trs set [cur_" + stp + "]=2  where trslid=" + trslid;

                    //   MainMDI.ExecSql(stsql, ref errmsg);
                    MainMDI.Exec_SQL_JFS(stsql, "maj_trs_stp_stat...", myusr, ref errmsg);
                    mymsg.sqlmsg += "||" + errmsg;

                    //emp
                    if (Tools.Conv_Dbl(myemp) > 0)
                    {
                        stsql = " update cedulo_trs set [resp_" + stp + "]=" + myemp + " where trslid=" + trslid;

                        //        MainMDI.Exec_SQL_JFS(stsql," set inwait curr_"+stp,usr, ref errmsg);
                        //    MainMDI.ExecSql(stsql, ref errmsg);
                        MainMDI.Exec_SQL_JFS(stsql, "maj_trs_stp_stat...", myusr, ref errmsg);
                        mymsg.sqlmsg += "||" + errmsg;


                    }


                    //update cedulo_trs_states
                    stsql = sql_trs_states('E', "1", stp, trslid);
                    if (stsql != MainMDI.VIDE)
                    {
                        MainMDI.ExecSql(stsql, ref errmsg);
                        //MainMDI.Exec_SQL_JFS(stsql, "", usr, ref errmsg);
                        mymsg.sqlmsg += "||" + errmsg;
                    }
                    else mymsg.sqlmsg += "||" + " error write End cedulo_trs_states..1..";


                    //4
                    stsql = " update cedulo_trs set [cur_" + stp + "]=4,[dte_" + stp + "]=" + MainMDI.SSV_Bigdate(st_dt) + " where trslid=" + trslid;
                    //  MainMDI.ExecSql(stsql, ref errmsg);
                    MainMDI.Exec_SQL_JFS(stsql, "maj_trs_stp_stat...", myusr, ref errmsg);
                    mymsg.sqlmsg += "||" + errmsg;
                    if (errmsg.Length < stsql.Length)
                    {
                        string errmsg2 = "";
                        if (stp == "af" || stp == "ach" || stp == "rtp" || stp == "tst" || stp == "if" || stp == "shp" || stp == "inv")
                        {
                            if (!NextSTEP(trslid, stp, ref errmsg2)) mymsg.sqlmsg += "----nxtStp err=" + errmsg2;
                            else mymsg.sqlmsg += "----" + errmsg2;
                        }

                    }
                    else return false;
                    break;

            }

            return true;

        }

      string sql_trs_states(char SE,string stat , string stp,string _trslid)
        {
            string stsql = MainMDI.VIDE;

            string joblid = MainMDI.Find_One_Field("SELECT [joblid] FROM [Orig_PSM_FDB].[dbo].[cedulo_trs] where trslid="+_trslid );
            if (Tools.Conv_Dbl(joblid) > 0)
            {
                string st_dt = DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss", CultureInfo.InvariantCulture);
               

                switch (SE)
                {
                    case 'E':
                    case 'e':
                        stsql = " update cedulo_trs_states set [dte_" + stp + "]=" + MainMDI.SSV_Bigdate(st_dt) + " , [statid]=" + stat + "  where joblid=" + joblid;

                        break;
                    case 'S':
                    case 's':
                        stsql = " update cedulo_trs_states set [dts_" + stp + "]=" + MainMDI.SSV_Bigdate(st_dt) + " , [statid]=" + stat + "  where joblid=" + joblid;

                        break;

                }
               
            }
            return stsql;

        }
        

        bool NextSTEP(string trslid,string cur_stp, ref string errmsg)
        {
            string nxtstp = "", nxtstp2="", nxtstp3 = "";
            errmsg="";
            switch (cur_stp)
            {
                case "af":
                    nxtstp = "ce";
                    nxtstp2 = "cm";
                    break;
                case "ce":
                    nxtstp = "ach";
                    break;
                case "cm":
                    nxtstp = "ach";
                    break;

                case "ach":
                    nxtstp = "rtp";
                    break;
                case "rtp":
                    nxtstp = "mp";
                    nxtstp2 = "mc";
                   // nxtstp3 = "fc";
                    break;
                case "mp":
                    nxtstp = "fp";
                    break;
                case "fp":
                    nxtstp = "tst";
                    break;
                case "mc":
                    nxtstp = "fc";
                    break;
                case "fc":
                    nxtstp = "tst";
                    break;
                case "tst":
                    nxtstp = "if";
                    break;
                case "if":
                    nxtstp = "shp";
                    break;
                case "shp":
                    nxtstp = "inv";
                    break;

            }
            if (nxtstp != "")
            {
                update_Nxt(trslid, nxtstp, ref errmsg);
                mymsg.sqlmsg += "|| " + errmsg;
                if (nxtstp2 !="")
                {
                    update_Nxt(trslid, nxtstp2, ref errmsg);
                    mymsg.sqlmsg += "|| " + errmsg;
                }
                if (nxtstp3 != "")
                {
                    update_Nxt(trslid, nxtstp3, ref errmsg);
                    mymsg.sqlmsg += "|| " + errmsg;
                }
                return true;
             
            }

            return false;
        }

        bool update_Nxt(string trslid,string nxtstp, ref string _errmsg)
        {

            string myusr = HttpContext.Session["usr"].ToString();
            string errmsg2 = "";
            string st_exist = MainMDI.Find_One_Field("select trslid from cedulo_trs  where cur_" + nxtstp + "= 0 and trslid=" + trslid);
            if (st_exist != MainMDI.VIDE)
            {
                string stsql = " update cedulo_trs set [cur_" + nxtstp + "]=1 where trslid=" + trslid;
                //   MainMDI.ExecSql(stsql, ref _errmsg);
                MainMDI.Exec_SQL_JFS(stsql, "update_Nxt...", myusr, ref errmsg2);
                //update cedulo_trs_states
                stsql = sql_trs_states('S', "1", nxtstp, trslid);
                if (stsql != MainMDI.VIDE)
                {
                    // MainMDI.ExecSql(stsql, ref errmsg2);
                    MainMDI.Exec_SQL_JFS(stsql, "update_Nxt...", myusr, ref errmsg2);
                    //MainMDI.Exec_SQL_JFS(stsql, "", usr, ref errmsg);
                    _errmsg += "||" + errmsg2;
                }
                else _errmsg += "||" + " error write start cedulo_trs_states..1..";

            }
            else _errmsg = "|| " + " cannot update next step as: en attente.....";

            return true;
        }

        public JsonResult showmissing(string _trslid, string _jdesc)
        {
            //    "SELECT pct1,pct2,pct3,pct4  FROM U_ag_tskgrpcof where grp = '" + grp + "'", ref pct1, ref pct2, ref pct3, ref pct4);



            string stSql = " SELECT  v_MissingItems.JobDescription, v_MissingItems.StockCode, v_MissingItems.StockDescription, v_MissingItems.Outstand, " +
                                   "v_MissingItems.Avalaible_m, v_MissingItems.QtyOnOrder, v_MissingItems.Reserved_Other, InvMaster.StockOnHold " +
                           " FROM            v_MissingItems AS v_MissingItems INNER JOIN  InvMaster AS InvMaster ON v_MissingItems.StockCode = InvMaster.StockCode " +
                           " where Upper(JobDescription) = '" +_jdesc +"'";


            msgrec mymsg = new msgrec();
            mymsg.msg = "";
            mymsg.recnb = "0";
            string resp = "";
            if (Tools.Conv_Dbl(_trslid) > 0)
            {
              

            }
            else
            {
                mymsg.msg = "Invalid trslid ...... call your admin.....";
                mymsg.recnb = "99";
            }


            msgLst.Add(mymsg);
            return Json(msgLst, JsonRequestBehavior.AllowGet);

        }




    }
}
