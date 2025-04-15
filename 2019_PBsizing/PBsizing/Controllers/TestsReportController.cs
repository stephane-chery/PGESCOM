using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using PBsizing.Models;
using System.Data.Sql;
using System.Data.SqlClient;


namespace PBsizing.Controllers
{
    public class TestsReportController : Controller
    {

        Orig_PSM_FDBEntities2 mydb = new Orig_PSM_FDBEntities2();


        List<Alarm> allALRMlist = new List<Alarm>();
        List<Alarm> allALRMlist_report = new List<Alarm>();

        List<EQUALIZE> allEQLZlist = new List<EQUALIZE>();
        List<EQUALIZE> allEQLZlist_report = new List<EQUALIZE>();

        List<Alarm> allALRMlist_prj = new List<Alarm>();

        List<CMD> CMDlist = new List<CMD>();
        List<TR_info> TR_List_irevid = new List<TR_info>();
        List<Rev_info> Rev_List = new List<Rev_info>();

        List<ERROR_Setting> errors_list = new List<ERROR_Setting>();


        string stSWTCH = "Switch1|swf1=0|swr1=00|swl1=00|swt1=0005|SWLG1=checked|SWPR1=checked|SWCR1=checked|SWDA1=unchecked%%Switch2|swf2=0|swr2=00|swl2=00|swt2=0005|SWLG2=checked|SWPR2=checked|SWCR2=checked|SWDA2=unchecked%%Switch3|swf3=0|swr3=00|swl3=00|swt3=0005|SWLG3=checked|SWPR3=checked|SWCR3=checked|SWDA3=unchecked%%Switch4|swf4=0|swr4=00|swl4=00|swt4=0005|SWLG4=checked|SWPR4=checked|SWCR4=checked|SWDA4=unchecked%%Switch5|swf5=0|swr5=00|swl5=00|swt5=0005|SWLG5=checked|SWPR5=checked|SWCR5=checked|SWDA5=unchecked%%Switch6|swf6=0|swr6=00|swl6=00|swt6=0005|SWLG6=checked|SWPR6=checked|SWCR6=checked|SWDA6=unchecked%%Switch7|swf7=0|swr7=00|swl7=00|swt7=0005|SWLG7=checked|SWPR7=checked|SWCR7=checked|SWDA7=unchecked%%Switch8|swf8=0|swr8=00|swl8=00|swt8=0005|SWLG8=checked|SWPR8=checked|SWCR8=checked|SWDA8=unchecked%%Message1|swmg1=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%Message2|swmg2=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%Message3|swmg3=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%Message4|swmg4=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%Message5|swmg5=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%Message6|swmg6=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%Message7|swmg7=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%Message8|swmg8=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%";

        //
        // GET: /TestsReport/
        public class Alarm_old
        {
            public string Alarm_Name { get; set; }
            public string AV { get; set; }
            public string AVtxt = "Adjustements";
            public string ADF   { get; set; }
            public string ADFtxt = "Diff.";
            public string AD   { get; set; }
            public string ADtxt = "Delay";
            public string AR { get; set; }
            public string ARtxt = "Relay";
            public string AL { get; set; }
            public string ALtxt = "Led";
            public string AML { get; set; }
            public string AMLtxt = "Msg Latch";
            public string ARL { get; set; }
            public string ARLtxt = "Relay Latch";
            public string ALG { get; set; }
            public string ALGtxt = "Logic";
            public string APR { get; set; }
            public string APRtxt = "Priority";
            public string ACR { get; set; }
            public string ACRtxt = "Common";
            public string AEN { get; set; }
            public string AENtxt = "Enabled";

            
        }
        public class ERROR_Setting
        {
                        public string err_no { get; set; }
            public string err_msg { get; set; }


        }
        public class Rev_info
        {
            public string irrev { get; set; }
            public string rev_name{ get; set; }
            public string MyProperty { get; set; }


        }

        public class TR_info
        {
            public int TRid { get; set; }
            public string TR_Name { get; set; }
            public string CFG_Name { get; set; }

        }


        public class CMD
        {
            public string Float { get; set; }
            public string iFLT { get; set; }
            public string Equalize { get; set; }
            public string VEQ { get; set; }
            public string EQEN { get; set; }



        }
        public class EQUALIZE
        {
            public string Equalize_Name { get; set; }
            public string AV { get; set; }
            public string dura { get; set; }
            public string delay { get; set; }
            public string Enabled { get; set; }
     


        }

   

        public class Alarm
        {
            public string Alarm_Name { get; set; }
            public string AV { get; set; }
     //       public string AVtxt = "Adjustements";
            public string ADF { get; set; }
    //        public string ADFtxt = "Diff.";
            public string AD { get; set; }
  //          public string ADtxt = "Delay";
            public string AR { get; set; }
  //          public string ARtxt = "Relay";
            public string AL { get; set; }
       //     public string ALtxt = "Led";
            public string AML { get; set; }
        //    public string AMLtxt = "Msg Latch";
            public string ARL { get; set; }
      //      public string ARLtxt = "Relay Latch";
            public string ALG { get; set; }
       //     public string ALGtxt = "Logic";
            public string APR { get; set; }
       //     public string APRtxt = "Priority";
            public string ACR { get; set; }
      //      public string ACRtxt = "Common";
            public string ASD { get; set; }
     //      public string ACRtxt = "ShutDown";
            public string AEN { get; set; }
      //      public string AENtxt = "Enabled";


        }
        class Charger
        {

         public   List<Alarm> AlarmsList = new List<Alarm>();
        

            public void Fill_AlarmsList(string Alarms_cgi)
         {




         }



        }

        public ActionResult Index()
        {
           return View();
        }


        string find_RID_RRev(long irrev)
        {
            // var Curr_Rev = mydb.PSM_R_Rev.Where(x => x.IRRevID == 4444).Single();
            var Curr_Rev = mydb.PSM_R_Rev.Where(x => x.IRRevID == irrev).FirstOrDefault();

            if (Curr_Rev != null) return Curr_Rev.RID + "  /  " + Curr_Rev.RRev_Name;
            else return "??????";
        }


        public ActionResult Edit_TRid(string myTRid )
        {

            if (HttpContext.Session["usr"] == null || HttpContext.Session["usr"].ToString() == "")  // || HttpContext.Session["TR"] == null)
                return View("~/Views/Shared/logon.cshtml");
            else
            {
                HttpContext.Session["irrev"] = "8149";
                HttpContext.Session["usr"] = "ede";
                HttpContext.Session["opera"] = "t";
                string usr = "", irrev = "", Opera = "";

                if (HttpContext.Session["usr"] != null) usr = HttpContext.Session["usr"].ToString();
                if (HttpContext.Session["irrev"] != null) irrev = HttpContext.Session["irrev"].ToString();
                if (HttpContext.Session["opera"] != null) Opera = HttpContext.Session["opera"].ToString();
                //return new EmptyResult();


                ViewBag.IRREV = irrev;


                if (irrev != "")
                {

                    Int64 L_irrev = Convert.ToInt64(irrev);
                    ViewBag.mylist = mydb.PSM_R_TRInfo.Where(x => x.tr_iRRevID == L_irrev).ToList();// new SelectList(mydb.PSM_R_TRInfo.ToList(), "tr_LID", "tr_TRName");  
                    ViewBag.RID = find_RID_RRev(L_irrev);
                }


                if (usr != "" && irrev != "" && Opera != "")  //&& MainMDI.ALWD_USR(usr, "OR_TR"))
                {
                    switch (Opera)
                    {
                        case "t":
                            //  return View("~/Views/TestsReport/TestsReport.cshtml");
                            return View("~/Views/TestsReport/TR_List.cshtml");
                            break;
                        //case "a":
                        //    return View("~/Views/Home/Index.cshtml");
                        //    break;

                        //case "b":
                        //    return View();
                        //    break;
                        //case "s":
                        //    return View();
                        //    break;

                        default:
                            return View("~/Views/Home/ERROR_NOSIZING.cshtml");
                    }
                }
                else return View("~/Views/Home/ERROR_NOSIZING.cshtml");
            }
            // return View();
        }


        public ActionResult TestsReport()
        {

            if (HttpContext.Session["usr"] == null || HttpContext.Session["usr"].ToString () == "")  // || HttpContext.Session["TR"] == null)
                return View("~/Views/Shared/logon.cshtml");
            else
            {
                HttpContext.Session["irrev"] = "8149";
                HttpContext.Session["usr"] = "ede";
                HttpContext.Session["opera"] = "t";
                string usr = "", irrev = "", Opera = "";

                if (HttpContext.Session["usr"] != null) usr = HttpContext.Session["usr"].ToString();
                if (HttpContext.Session["irrev"] != null) irrev = HttpContext.Session["irrev"].ToString();
                if (HttpContext.Session["opera"] != null) Opera = HttpContext.Session["opera"].ToString();
                //return new EmptyResult();


                ViewBag.IRREV = irrev;


                if (irrev != "")
                {

                    Int64 L_irrev = Convert.ToInt64(irrev);
                    ViewBag.mylist = mydb.PSM_R_TRInfo.Where(x => x.tr_iRRevID == L_irrev).ToList();// new SelectList(mydb.PSM_R_TRInfo.ToList(), "tr_LID", "tr_TRName");  
                    ViewBag.RID = find_RID_RRev(L_irrev);
                }


                if (usr != "" && irrev != "" && Opera != "" )  //&& MainMDI.ALWD_USR(usr, "OR_TR"))
                {
                    switch (Opera)
                    {
                        case "t":
                          //  return View("~/Views/TestsReport/TestsReport.cshtml");
                            return View("~/Views/TestsReport/TR_List.cshtml");
                            break;
                        //case "a":
                        //    return View("~/Views/Home/Index.cshtml");
                        //    break;

                        //case "b":
                        //    return View();
                        //    break;
                        //case "s":
                        //    return View();
                        //    break;

                        default:
                            return View("~/Views/Home/ERROR_NOSIZING.cshtml");
                    }
                }
                else return View("~/Views/Home/ERROR_NOSIZING.cshtml");
            }
           // return View();
        }

        public ActionResult TestsReport_OLD()
        {
            HttpContext.Session["irrev"] = "8149";
            HttpContext.Session["usr"] = "ede";
            HttpContext.Session["opera"] = "t";
            string usr = "", irrev = "", Opera = "";

            if (HttpContext.Session["usr"] != null) usr = HttpContext.Session["usr"].ToString();
            if (HttpContext.Session["irrev"] != null) irrev = HttpContext.Session["irrev"].ToString();
            if (HttpContext.Session["opera"] != null) Opera = HttpContext.Session["opera"].ToString();
            //return new EmptyResult();


            ViewBag.IRREV = irrev;


            if (irrev != "")
            {

                Int64 L_irrev = Convert.ToInt64(irrev);
                ViewBag.mylist = mydb.PSM_R_TRInfo.Where(x => x.tr_iRRevID == L_irrev).ToList();// new SelectList(mydb.PSM_R_TRInfo.ToList(), "tr_LID", "tr_TRName");  
                ViewBag.RID = find_RID_RRev(L_irrev);
            }


            if (usr != "" && irrev != "" && Opera != "" && MainMDI.ALWD_USR(usr, "OR_TR"))
            {
                switch (Opera)
                {
                    case "t":
                        return View("~/Views/TestsReport/TestsReport.cshtml");
                        break;
                    //case "a":
                    //    return View("~/Views/Home/Index.cshtml");
                    //    break;

                    //case "b":
                    //    return View();
                    //    break;
                    //case "s":
                    //    return View();
                    //    break;

                    default:
                        return View("~/Views/Home/ERROR_NOSIZING.cshtml");
                }
            }
            else return View("~/Views/Home/ERROR_NOSIZING.cshtml");
            // return View();
        }
        CMD deco_CMD_Line(string Line)
        {
            CMD myCMD = new CMD();
            string[] Avv = Line.Split('|');
            for (int i = 0; i < Avv.Length; i++)
            {
                string stRes = "NA";
                if (Avv[i].IndexOf("/") > -1)
                {
                    string[] tt = Avv[i].Split('/');
                    string[] tt2 = tt[0].Split('=');
                    stRes = tt2[1];
                    tt2 = tt[1].Split('=');
                    stRes += " / " + tt2[1];

                }
                else
                {
                    if (Avv[i].IndexOf("=") < 0) stRes = Avv[i];
                    else
                    {
                        string[] nm_val = Avv[i].Split('=');
                        stRes = nm_val[1];
                    }
                }

                switch (i)
                {
                    case 0:
                       myCMD.Float = stRes;
                        break;
                    case 1:
                        myCMD.iFLT= stRes;
                        break;
                    case 2:
                       myCMD.Equalize = stRes;
                        break;
                    case 3:
                        myCMD.VEQ= stRes;
                        break;
                    case 4:
                        myCMD.EQEN = stRes;
                        break;

                }
            }

            return myCMD;
        }
      EQUALIZE deco_EQLZ_Line(string Line)
        {
            EQUALIZE myEQLZ = new EQUALIZE();
            string[] Avv = Line.Split('|');
            for (int i = 0; i < Avv.Length; i++)
            {
                string stRes = "NA";
                if (Avv[i].IndexOf("/") > -1)
                {
                    string[] tt = Avv[i].Split('/');
                    string[] tt2 = tt[0].Split('=');
                    stRes = tt2[1];
                    tt2 = tt[1].Split('=');
                    stRes += " / " + tt2[1];

                }
                else
                {
                    if (Avv[i].IndexOf("=") < 0) stRes = Avv[i];
                    else
                    {
                        string[] nm_val = Avv[i].Split('=');
                        stRes = nm_val[1];
                    }
                }

                switch (i)
                {
                    case 0:
                        myEQLZ.Equalize_Name = stRes;
                        break;
                    case 1:
                        myEQLZ.AV = stRes;
                        break;
                    case 2:
                        myEQLZ.dura = stRes;
                        break;
                    case 3:
                        myEQLZ.delay = stRes;
                        break;
                    case 4:
                        myEQLZ.Enabled = stRes;
                        break;

                }
            }

            return myEQLZ;
        }

        Alarm deco_ALRM_Line(string Line)
        {
            Alarm myALRM = new Alarm();
            string[] Avv = Line.Split('|');
           for (int i=0;i<Avv.Length ;i++)
            {
               string stRes = "NA";
               if (Avv[i].IndexOf("/") > -1)
               {
                   string[] tt = Avv[i].Split('/');
                   string[] tt2 =tt[0].Split('=');
                   stRes = tt2[1];
                            tt2 = tt[1].Split('=');
                            stRes +=" / " + tt2[1];
                
               }
               else
               {
                   if (Avv[i].IndexOf("=") < 0) stRes = Avv[i];
                   else
                   {
                       string[] nm_val = Avv[i].Split('=');
                       stRes = nm_val[1];
                   }
               }

               switch (i)
               {
                   case 0:
                       myALRM.Alarm_Name = stRes;
                       break;
                   case 1:
                       myALRM.ADF = stRes;
                       break;
                   case 2:
                       myALRM.AV = stRes;
                       break;
                   case 3:
                       myALRM.AD = stRes;
                       break;
                   case 4:
                       myALRM.AR = stRes;
                       break;
                   case 5:
                       myALRM.AL = stRes;
                       break;
                   case 6:
                       myALRM.AML = stRes;
                       break;
                   case 7:
                       myALRM.ARL = stRes;
                       break;
                   case 8:
                       myALRM.ALG = stRes;
                       break;
                   case 9:
                       myALRM.APR = stRes;
                       break;
                   case 10:
                       myALRM.ACR = stRes;
                       break;
                   case 11:
                       myALRM.ASD = stRes;   //     ASDtxt = "ShutDown";
                     break;
    
                   case 12:
                       myALRM.AEN = stRes;
                       break;
               }
            }

            return myALRM;
        }
        void deco_Page(string Orig_page,string code)
        {

            string page = Orig_page.Replace("<form>", "");
            int pos = page.IndexOf("%%", 0);

            switch (code)
            {
                case "ALRM":
                    while (pos > -1)
                    {
                        string alrm = page.Substring(0, pos);

                        allALRMlist.Add(deco_ALRM_Line(alrm));

                        //page = page.Substring(pos + 2, page.Length - pos - 3);
                        page = page.Substring(pos + 2, page.Length - pos - 2);
                        pos = page.IndexOf("%%", 0);


                    }
                    break;
                case "EQLZ":
                    while (pos > -1)
                    {
                        string eqlz = page.Substring(0, pos);

                        allEQLZlist.Add(deco_EQLZ_Line(eqlz));

                        //page = page.Substring(pos + 2, page.Length - pos - 3);
                        page = page.Substring(pos + 2, page.Length - pos - 2);
                        pos = page.IndexOf("%%", 0);


                    }
                    break;
                case "CMD":
                case "CMDD":
                    while (pos > -1)
                    {
                        string cmd = page.Substring(0, pos);

                      CMDlist.Add(deco_CMD_Line(cmd));
                      
                        //page = page.Substring(pos + 2, page.Length - pos - 3);
                        page = page.Substring(pos + 2, page.Length - pos - 2);
                        pos = page.IndexOf("%%", 0);


                    }
                    break;
            }

        }

        public void Save_this_ALRM(string TRid ,string Alarm_Name ,string adj ,string diff,string delay ,string  relay , string  led ,string  msglatch ,string   relaylatch , string logic,string  priority,string common, string shut_down ,string enabled)
        {

           int? myTRid=Int32.Parse(TRid);
           mydb.WTR_Save_Alarms(myTRid, Alarm_Name , adj , diff, delay ,  relay ,  led ,  msglatch , relaylatch , logic,  priority, common, shut_down , enabled);

        }

        public void Save_this_EQLZ(string TRid, string EQ_type, string Equalize_Name, string adj, string dura, string delay, string enabled)
        {

            int? myTRid = Int32.Parse(TRid);
            mydb.WTR_Save_equalize(myTRid, EQ_type, Equalize_Name, adj, dura, delay, enabled);

        }


        void Save_allALARMS(List<Alarm> myallALRMlist)
        {


            ERROR_Setting myERR = new ERROR_Setting();

            string myTRid = HttpContext.Session["trid"].ToString();
            long? ltrid=Convert.ToInt64(myTRid);

        //    mydb.WTR_Alarms.Where(a => a.TRid.Value==myTRid).dele    dc.W_infoSNDcharger.Where(a =>a.TRlid.Value == l_trid).ToList();
//delete all alarms having trid=mytrid
            mydb.WTR_Alarms.Where(a => a.TRid == ltrid).ToList().ForEach(p =>mydb.WTR_Alarms.Remove(p));
            foreach (Alarm myAL in myallALRMlist)
            {
                try
                {

                    Save_this_ALRM(myTRid, myAL.Alarm_Name, myAL.AV, myAL.ADF, myAL.AD, myAL.AR, myAL.AL, myAL.AML, myAL.ARL, myAL.ALG, myAL.APR, myAL.ACR, myAL.ASD, myAL.AEN);
                }
                catch (Exception e)
                {
                   
                       myERR.err_no="ALRM";
                    myERR.err_msg=e.Message;
                    errors_list.Add(myERR);
                }

            }
            //if (errors_list.Count==0) 
            //{
            //        myERR.err_no="OK";
            //        myERR.err_msg = "????";
            //        errors_list.Add(myERR);

            //}

        }



        void Report_ALARMS(   List<Alarm> myallALRMlist_report, bool chked )
        {
            //  string TD1 = "<td>", TD2 = "</td>";   text-align: center;
            string TD1 = "<td style=\"border: 1px solid black;white-space: nowrap; text-align:center \">", TD2 = "</td>";
            string TD1_C = "<td style=\"border: 1px solid black; align=\"center\" valign=\"middle\">";
            string TD1_blk = "<td style\" white-space: nowrap\">";

            string CHKD = "<td style=\"border: 1px solid black;\" align=\"center\" valign=\"middle\"><img src=\"/Images/yes.png\" style=\"width:18%\" /></td>";
            string UNCHKD = "<td style=\"border: 1px solid black;\" align=\"center\" valign=\"middle\"><img src=\"/Images/no.png\" style=\"width:18%\" /></td>'";
            string FS = TD1_C + "<label style=\"border-radius: 30px;background:green;font-size: 12px;font-weight: bold;color:white;border: 1px dashed #fff; border: solid 2px #6E6E6E\">FS</label>" + TD2;//"<td align=\"center\" valign=\"middle\"><img src=\"/Images/fs2.png\" style=\"width:15%\" /></td>'";
            string NFS = TD1_C + "<label style=\"border-radius: 30px;background:gray;font-size: 12px;font-weight: bold;color:white;border: 1px dashed #fff; border: solid 2px #6E6E6E\">NFS</label>" + TD2; ;// "<td align=\"center\" valign=\"middle\"><img src=\"/Images/nfs2.png\" style=\"width:15%\" /></td>'";
            string MIN = TD1_C + "<label style=\"border-radius: 30px;background:green;font-size: 12px;font-weight: bold;color:white;border: 1px dashed #fff; border: solid 2px #6E6E6E\">MAJ</label>" + TD2; ;//"<td align=\"center\" valign=\"middle\"><img src=\"/Images/min2.png\" style=\"width:15%\" /></td>'";
            string MAJ = TD1_C + "<label style=\"border-radius: 30px;background:gray;font-size: 12px;font-weight: bold;color:white;border: 1px dashed #fff; border: solid 2px #6E6E6E\">MIN</label>" + TD2; ;// "<td align=\"center\" valign=\"middle\"><img src=\"/Images/maj2.png\" style=\"width:15%\" /></td>'";

            allALRMlist_report.Clear();
         

            string valchked=(chked) ? "checked" : "1";
            foreach (Alarm myAL in myallALRMlist_report)
            {
                Alarm W_alarm = new Alarm();
                if (myAL.Alarm_Name != "FLT-EQU")
                {
                    W_alarm.Alarm_Name = TD1 + myAL.Alarm_Name + TD2;
                    W_alarm.ADF = TD1 + myAL.ADF + TD2;
                    W_alarm.AV = TD1 + myAL.AV + TD2;
                    W_alarm.AD = TD1 + myAL.AD + TD2;
                    W_alarm.AR = TD1 + myAL.AR + TD2;
                    W_alarm.AL = TD1 + myAL.AL + TD2;

                    W_alarm.AML = (myAL.AML == valchked) ? CHKD : UNCHKD;
                    W_alarm.ARL = (myAL.ARL == valchked) ? CHKD : UNCHKD;

                    W_alarm.ALG = (myAL.ALG == valchked) ? FS : NFS;
                    W_alarm.APR = (myAL.APR == valchked) ? MIN : MAJ;

                    W_alarm.ACR = (myAL.ACR == valchked) ? CHKD : UNCHKD;

                    if (myAL.ASD != "NA")
                    {
                        W_alarm.ASD = (myAL.ASD == valchked) ? CHKD : UNCHKD;
                    }
                    else W_alarm.ASD = TD1 + myAL.ASD+ TD2;  

                    W_alarm.AEN = (myAL.AEN == valchked) ? CHKD : UNCHKD;
                }
                else
                {
                    W_alarm.Alarm_Name = myAL.Alarm_Name ;
                    W_alarm.ADF =  myAL.ADF;
                    W_alarm.AV = myAL.AV;
                    W_alarm.AD = myAL.AD;
                    W_alarm.AR = myAL.AR;
                    W_alarm.AL =  myAL.AL;

                    W_alarm.AML = myAL.AML ;
                    W_alarm.ARL = myAL.ARL ;

                    W_alarm.ALG = myAL.ALG ;
                    W_alarm.APR = myAL.APR;

                    W_alarm.ACR = myAL.ACR ;
                    W_alarm.AEN = myAL.AEN ;

                }
                allALRMlist_report.Add(W_alarm);
            }

         //   allALRMlist_report = myallALRMlist_report;

        }







        public JsonResult tstSendCGI(string c_cgi, string c_ipadrs)
        {
            string json = "OK";
               // Gen_STaQuote(c_dtfrom, c_dtTo);
            string Res_page = "";
            Send_msgTOcharger(c_cgi, c_ipadrs,ref Res_page);
            return Json(Res_page, JsonRequestBehavior.AllowGet);
      //      return Json(json, "application/json");
        }



        public JsonResult Get_n_save_chargerset(string c_opc, string c_ipadrs)
        {
            string c_cgi = "????";
            switch (c_opc)
            {
                case "ALRM":
                    c_cgi = "pgscom/alarmes.cgi";
                    break;
                case "EQLZ":
                    c_cgi = "pgscom/equalize.cgi";
                    break;
                case "CMD":
                case "CMDD":
                    c_cgi = "pgscom/Commands.cgi";
                    break;


            }
            string json = "OK";
            string Res_page = "";

            if (c_cgi != "????")
            {
                Send_msgTOcharger(c_cgi, c_ipadrs, ref Res_page);
                // Exception:\nUnable to connect to the remote server")
                if (Res_page.IndexOf("ERROR:") == -1)
                {
                    //  deco_Response(c_opc, Res_page);
                    switch (c_opc)
                    {
                        case "ALRM":
                            deco_Page(Res_page, c_opc);
                            Save_allALARMS(allALRMlist);
                            return Json(errors_list, JsonRequestBehavior.AllowGet);
                            break;
                        case "EQLZ":
                            deco_Page(Res_page, c_opc);
                            //     Report_EQULIZE(allEQLZlist, true);

                            return Json(allALRMlist_report, JsonRequestBehavior.AllowGet);
                            break;
                        case "CMD":
                        case "CMDD":
                            CMDlist.Clear();
                            deco_Page(Res_page, c_opc);
                            if (c_opc == "CMDD") CMDlist[0].Float = "OK";
                            return Json(CMDlist, JsonRequestBehavior.AllowGet);
                            break;

                    }
                }

            }
            else Res_page = "Invalid Operation...................!!!!!!";

            //ERROR process
            switch (c_opc)
            {
                case "ALRM":
                case "EQLZ":

                    Alarm AL_ERROR = new Alarm();
                    AL_ERROR.Alarm_Name = Res_page;  //"ERROR connecting Charger OR Invalid Operation. ......!!!!!";
                    allALRMlist_report.Add(AL_ERROR);
                    return Json(allALRMlist_report, JsonRequestBehavior.AllowGet);
                    break;
                case "CMD":
                case "CMDD":
                    CMD cmdErr = new CMD();
                    cmdErr.Float = "KO";
                    cmdErr.Equalize = Res_page;
                    CMDlist.Add(cmdErr);
                    return Json(CMDlist, JsonRequestBehavior.AllowGet);
                    break;

            }

            return Json(allALRMlist_report, JsonRequestBehavior.AllowGet);

            //  return Json(Res_page, JsonRequestBehavior.AllowGet);
            //      return Json(json, "application/json");
        }

        public JsonResult Get_CHRGR_Alarms(string c_opc, string c_ipadrs)
        {
            string c_cgi = "????";
            switch (c_opc)
            {
                case "ALRM":
                    c_cgi = "pgscom/alarmes.cgi";
                    break;
                case "EQLZ":
                    c_cgi = "pgscom/equalize.cgi";
                    break;
                case "CMD":
                case "CMDD":
                    c_cgi = "pgscom/Commands.cgi";
                    break;


            }
            string json = "OK";
            string Res_page = "";
 
            if (c_cgi != "????")

            {
                Send_msgTOcharger(c_cgi, c_ipadrs, ref Res_page);
                // Exception:\nUnable to connect to the remote server")
                if (Res_page.IndexOf("ERROR:") == -1)
                {
                  //  deco_Response(c_opc, Res_page);
                    switch (c_opc)
                    {
                        case "ALRM":
                            deco_Page(Res_page, c_opc);
                            Report_ALARMS(allALRMlist, true);
                            return Json(allALRMlist_report, JsonRequestBehavior.AllowGet);
                            break;
                        case "EQLZ":
                            deco_Page(Res_page, c_opc);
                            //     Report_EQULIZE(allEQLZlist, true);

                            return Json(allALRMlist_report, JsonRequestBehavior.AllowGet);
                            break;
                        case "CMD":
                        case "CMDD":
                            CMDlist.Clear();
                            deco_Page(Res_page, c_opc);
                            if (c_opc == "CMDD") CMDlist[0].Float = "OK";
                            return Json(CMDlist, JsonRequestBehavior.AllowGet);
                            break;

                    }
                }
                
            }
            else Res_page = "Invalid Operation...................!!!!!!";

            //ERROR process
            switch (c_opc)
            {
                case "ALRM":
                case "EQLZ":

                    Alarm AL_ERROR = new Alarm();
                    AL_ERROR.Alarm_Name = Res_page;  //"ERROR connecting Charger OR Invalid Operation. ......!!!!!";
                    allALRMlist_report.Add(AL_ERROR);
                    return Json(allALRMlist_report, JsonRequestBehavior.AllowGet);
                    break;
                case "CMD":
                case "CMDD":
                    CMD cmdErr = new CMD();
                   cmdErr.Float = "KO";
                   cmdErr.Equalize = Res_page;
                   CMDlist.Add(cmdErr);
                    return Json(CMDlist, JsonRequestBehavior.AllowGet);
                    break;

            }

            return Json(allALRMlist_report, JsonRequestBehavior.AllowGet);

          //  return Json(Res_page, JsonRequestBehavior.AllowGet);
            //      return Json(json, "application/json");
        }

        public JsonResult revlst_rid(string c_rid)
        {

    
       //     Int64 L_rid = Convert.ToInt64(c_rid);
            fill_REV_LIST(c_rid);
            return Json(Rev_List, JsonRequestBehavior.AllowGet);

          
        }

        private void fill_REV_LIST(string myRID)
        {

      
            string stSql = " SELECT [IRRevID],[RRev_Name],[RID]   FROM PSM_R_Rev where RID = "+myRID + " and shiped<>'C' and shiped<>'D' ";


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                Rev_info myAG = new Rev_info();
                myAG.irrev = Oreadr[0].ToString();
                myAG.rev_name = Oreadr[1].ToString();
               Rev_List.Add(myAG);
            }
            OConn.Close();

        }


        public JsonResult trlst_revid(string c_revid)
        {


          //  Int64 L_rid = Convert.ToInt64(c_revid);
            fill_TR_LIST(c_revid);
            return Json(Rev_List, JsonRequestBehavior.AllowGet);


        }

        private void fill_TR_LIST(string myIrrev)
        {


            string stSql = " SELECT [IRRevID],[RRev_Name],[RID]   FROM PSM_R_Rev where RID = " + myIrrev + " and shiped<>'C' and shiped<>'D' ";


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                Rev_info myAG = new Rev_info();
                myAG.irrev = Oreadr[0].ToString();
                myAG.rev_name = Oreadr[1].ToString();
                Rev_List.Add(myAG);
            }
            OConn.Close();

        }



        public void Load_WprjInfo(string _TRID)
        {

            //    var Steps = new List<W_infoSNDcharger>();
            allALRMlist_prj.Clear();
            using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
            {

                Int64 l_trid = Convert.ToInt64(_TRID);
         
                var mylist = dc.W_infoSNDcharger.Where(a =>a.TRlid.Value == l_trid).ToList();
                int i = 0;
                foreach (W_infoSNDcharger rec in mylist)
                {
                    Alarm myAL = new Alarm();
                        myAL.Alarm_Name = rec.Alarm_Name;
                        myAL.AV = rec.adjustment;
                        myAL.ADF = rec.Diffirential;
                        myAL.AD = rec.Delay;
                        myAL.AR = rec.Relay;
                        myAL.AL = rec.Led;
                        myAL.AML = rec.Msg_latch.ToString();
                        myAL.ARL = rec.Relay_latch.ToString();

                        myAL.ALG = rec.Logic.ToString();
                        myAL.APR = rec.Priority.ToString();

                        myAL.ACR = rec.Common.ToString();
                        myAL.AEN = rec.Enabled.ToString();

                    allALRMlist_prj.Add(myAL);
                }
            }

        }


  
        public JsonResult Get_prj_Alarms(string c_TRid)
        {

            HttpContext.Session["trid"] = c_TRid;
            allALRMlist_prj.Clear();
            Load_WprjInfo(c_TRid);
            Report_ALARMS(allALRMlist_prj, false);
            return Json(allALRMlist_report, JsonRequestBehavior.AllowGet);

        }


        void Send_msgTOcharger(string cgiTXT, string IPADRS,ref string _page)
        {

            // http://192.168.1.191/setting/resetala.cgi?B1=1&B1=1&BP1=Reset

            //http://192.168.1.191/setting/time.cgi?k1=11&k2=11&k3=11&k4=11&k5=11&KP1=Apply


            if (IPADRS.Length > 6)
            {
                string err = "", URLsent = "";
                Charger45xxx myCHRG = new Charger45xxx(IPADRS, "S5688");
                string page = myCHRG.Send_Charger(cgiTXT, ref err, ref URLsent);
                ViewBag.txsentURL = URLsent;
                if (err == "")    _page= page;
                else _page= "ERROR: " + err;

            }
            else _page = "ERROR: This IP Adress is Invalid.......";

        }

     
        static class brain
        {
            public static string Vide = "n/a";
            public static string std_charger_Events_list = @"std_CHEV.dat";
            public static string[] arr_EventsNames = new string[100];
            public static string EventLog_p1 = "status/event1_XL.cgi";
            public static string EventLog_p2 = "status/event2_XL.cgi";
            public static string EventLog_p3 = "status/event3_XL.cgi";
            public static string EventLog_p4 = "status/event4_XL.cgi";
            public static string EventLog_p5 = "status/event5_XL.cgi";
            public static string Charger_List = @"CHRGR_LST.dat";
            public static string cookiesFile = @"cookies.dat";
            public static string[,] arr_Events250 = new string[251, 3];

            public static bool OnlyINT(char c)
            {
                if ((int)c != 8 && ((int)c < 48 || (int)c > 57)) return true;
                return false;
            }

            public static string A00(string ii, int Lnt)
            {
                //if (ii==0 ) return "00";
                string st = ii;
                for (int j = st.Length; j < Lnt; j++)
                    st = "0" + st;
                return st;
            }
        }

        class Charger45xxx
        {

            string in_IPA = "", in_SN = ""; int arr250_ndx = 0;
            public int[,] arrEvents_int = new int[251, 6];
            private string UserControl = "admin", pwd = "primax";

            public Charger45xxx(string x_IPA, string x_SN)
            {
                in_IPA = x_IPA;
                in_SN = x_SN;

            }




            private string Connect_Charger(string ipA, string cgiName,ref string ERR)
            {
                string _excep = "";
                string URL = @"http://" + in_IPA + @"/" + cgiName;
                string _page = GetPage(URL, ref _excep);

                if (_excep == null) return _page;
                else ERR="ERROR: " + _excep;

                return "n/a";

            }


            private string GetPage(string url, ref string _Excep)
            {
                _Excep = null;
                WebResponse response = null;
                Stream stream = null;
                StreamReader reader = null;

                try
                {
                    HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
                    request.Credentials = new NetworkCredential("admin", "primax");
                    response = request.GetResponse();

                    stream = response.GetResponseStream();

                    if (!response.ContentType.ToLower().StartsWith("text/"))
                        return null;

                    string buffer = "", line;

                    reader = new StreamReader(stream);

                    while ((line = reader.ReadLine()) != null)
                    {
                        buffer += line + "\r\n";
                    }

                    return buffer;
                }
                catch (WebException _ex)
                {
                    _Excep = "WEB Exception:\n" + _ex.Message;
                    //  MessageBox.Show ( + _ex);
                    return null;
                }
                catch (IOException _ioex)
                {
                    _Excep = "IOException:\n" + _ioex.Message;
                    return null;
                }
                finally
                {
                    if (reader != null)
                        reader.Close();

                    if (stream != null)
                        stream.Close();

                    if (response != null)
                        response.Close();
                }
            }



            int find_EventNDX(string eventName)
            {
                for (int i = 1; i < brain.arr_EventsNames.Length; i++)
                    if (eventName == brain.arr_EventsNames[i]) return i;
                return 0;
            }

            void split_page(string page, string Line_Sep)
            {


                page = page.Replace(Line_Sep, "~");
                string[] arr_st = page.Split('~');
                for (int i = 0; i < arr_st.Length - 1; i++)
                {

                    int EV_MM = 0, EV_DD = 0, EV_YY = 0, EV_HH = 0, EV_MN = 0;

                    string[] cur_line = arr_st[i].Split('|');
                    if (cur_line[1].TrimEnd().Length > 0)
                    {
                        brain.arr_Events250[arr250_ndx, 0] = cur_line[1];
                        brain.arr_Events250[arr250_ndx, 1] = cur_line[2];
                        brain.arr_Events250[arr250_ndx, 2] = cur_line[3];



                        string EV_NB = cur_line[0];
                        string EV_name = cur_line[1].TrimEnd();
                        if (cur_line[2] != "-00-00")
                        {
                            string[] stdate = cur_line[2].Split('-');
                            EV_MM = Convert.ToDateTime(stdate[0].Trim() + " 01, 1900").Month;
                            EV_DD = Int32.Parse(stdate[1]);
                            EV_YY = Int32.Parse(stdate[2]);
                        }
                        if (cur_line[3] != "0:00")
                        {
                            string[] stTime = cur_line[3].Split(':');
                            EV_HH = Int32.Parse(stTime[0]);
                            EV_MN = Int32.Parse(stTime[1]);

                        }
                        int EV_ndx = find_EventNDX(EV_name);
                        EV_ndx = (EV_ndx == 0) ? 999 : EV_ndx;
                        if (EV_ndx == 999) EV_ndx = EV_ndx;
                        arrEvents_int[arr250_ndx, 0] = EV_ndx;
                        arrEvents_int[arr250_ndx, 1] = EV_MM;
                        arrEvents_int[arr250_ndx, 2] = EV_DD;
                        arrEvents_int[arr250_ndx, 3] = EV_YY;
                        arrEvents_int[arr250_ndx, 4] = EV_HH;
                        arrEvents_int[arr250_ndx, 5] = EV_MN;
                        arr250_ndx++;
                    }
                }

            }




            public bool Read_EventLogs(string[,] _arrEvL)
            {
                arr250_ndx = 1;
                for (int g = 0; g < 251; g++) for (int j = 0; j < 3; j++) brain.arr_Events250[g, j] = "";
                for (int g = 0; g < 251; g++) for (int j = 0; j < 6; j++) arrEvents_int[g, j] = 0;

                string ERR = "";
                string req = Connect_Charger(in_IPA, brain.EventLog_p1,ref ERR);
                if (req != brain.Vide)
                {
                    req = req.Replace("\r\n", ""); req = req.Replace("<form>", ""); req = req.Replace("</form>", "");

                    split_page(req, "%%");

                }
                return (req != brain.Vide);
            }

            private bool Send_CGI(string st_CGI)
            {
                string ERR = "";
                string req = Connect_Charger(in_IPA, st_CGI,ref ERR);
             //   if (req != brain.Vide) MessageBox.Show("");
                return (req != brain.Vide);

            }

            public string Send_Charger(string cgiName, ref string err, ref string URLsent)
            {
                string _excep = "";
                err = "";
                // string URL = @"http://admin:primax@" + in_IPA + @"/" + cgiName;
                string URL = @"http://" + in_IPA + @"/" + cgiName;
                //       string URL = cgiName;
                URLsent = URL;
                string _page = GetPage(URL, ref _excep);

                if (_excep == null) return _page;
                else err = _excep;
                //MessageBox.Show("ERROR: " + _excep);

                return "n/a";

            }

            string Send_ChargerIPA(string IPA, string cgiName, ref string err)
            {
                string _excep = "";
                err = "";
                string URL = @"http://" + IPA + @"/" + cgiName;
                string _page = GetPage(URL, ref _excep);

                if (_excep == null) return _page;
                else err = _excep;
                //MessageBox.Show("ERROR: " + _excep);

                return "n/a";

            }

        }


    }
}
