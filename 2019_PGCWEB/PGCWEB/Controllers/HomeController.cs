using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EAHLibs;
using System.Data.Sql;
using System.Data.SqlClient;

namespace PGCWEB.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MainMDI.init_Dict();

            //   HttpContext.Session["usr"]="grimard";  //recuperer usr du module accountcontroller
            //  HttpContext.Session["usrid"] = "105"; 

            //   MainMDI.usr = HttpContext.Session["usr"].ToString();
            //     MainMDI.UserID = HttpContext.Session["usrid"].ToString();
            //  return View();

            string usr = "", pwd = "";
            if (XTRCT_paraQRY(Request.Url.Query, ref usr, ref pwd))
            {
              //  HttpContext.Session["usr"] = usr;
              //  HttpContext.Session["dwp"] = pwd;
              ////  HttpContext.Session["opera"] = Opera;
            }


            if (!Request.Browser.IsMobileDevice)
            {
                if (HttpContext.Session["usr"] == null) return View("~/Views/Shared/logon.cshtml");
                else return View("~/Views/configo/Index.cshtml");
            }
            else
            {
                if (HttpContext.Session["usr"] == null) return View("~/Views/Shared/logon.cshtml");
                else return View("~/Views/configo/Index.cshtml");

            }






      //      if (MainMDI.Creat_TempTbls()) return View("~/Views/Shared/logon.cshtml");
     //       else return View("~/Views/Shared/Error.cshtml");


            //if (MainMDI.Creat_TempTbls()) return View("~/Views/configo/Index.cshtml");
            //else return View("ERROR_NOSIZING");
        }

        public ActionResult Logout()
        {
           HttpContext.Session["usr"] = null;
            HttpContext.Session["usrFnmLnm"] = null;
            HttpContext.Session["cfid"] = null;


           return View("~/Views/Shared/logon.cshtml");

        }

        private bool XTRCT_paraQRY(string STin, ref string u, ref string r)
        {
            int ipos = STin.IndexOf("?"), fpos = STin.IndexOf("=");
            if (ipos > -1 && fpos > -1 && ipos < fpos)
            {

                string[] para = STin.Split(new char[] { '?', '&' });

                if (para[1] != "")
                {
                    string[] inf = para[1].Split('='); u = inf[1];
                    inf = para[2].Split('='); r = inf[1];
                  //  inf = para[3].Split('='); o = inf[1];
                    return true;
                }
                else return false;
            }

            else return false;

        }



        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }


        bool hallbab(string hshst)
        {
           // string t1="gtyuio2546lop5236mjn" ,st2="g781254dfresa21655584236tyvbdat152yzx";
           // int pos1=hshst.IndexOf(t1,0);
           // if (pos1>-1)
           // {
           //     int pos2=hshst.IndexOf(t2);
           //     if (pos2>-1) 
           //     {
                  

           //     }


           // }
           //string res = MainMDI.Find_One_Field("select userid from configo_Usetup where usrname='" + usrnm + "'  and usrpwd='" + usrpwd + "'");
           // if (res == MainMDI.VIDE) return Json(new {code=0);
           // else return Json(new {code=1);
            return false;
        }
        public JsonResult donga_agnod(string usrnm, string usrpwd)
        {

            //   string  su=(Session["usr"]==null) ? "NULL" :Session["usr"].ToString();
            //   string HHsu = (HttpContext.Session["usr"] == null) ? "NULL" : HttpContext.Session["usr"].ToString();
            // string HHsu = HttpContext.Session["usr"].ToString();

            //   if (MainMDI.Creat_TempTbls()) return View("~/Views/Shared/logon.cshtml");
            //    else return View("~/Views/Shared/Error.cshtml");


            string res = MainMDI.Find_One_Field("select userid from configo_Usetup where usrname='" + usrnm + "'  and usrpwd='" + usrpwd + "' and actif=1 ");
            if (res != MainMDI.VIDE)
            {
             //   Session["usr"] = usrnm;

                HttpContext.Session["usr"] = usrnm;
                HttpContext.Session["usrid"] = res;

            //    string in_CFID = (MainMDI.myCFID.ToString() == "0") ? GivmeNewCF() : MainMDI.myCFID.ToString();
                //MainMDI.usr = usrnm; 
                //MainMDI.UserID = res;
                string FNLN = "", cpny = "";
                MainMDI.Find_2_Field("select FnmLnm,[SP_cpny_Name] from configo_Usetup inner join [dbo].[configo_Usetup_cpny] on configo_Usetup.[cpnyID]=configo_Usetup_cpny.cpny_lid  where userid=" + res, ref FNLN, ref cpny);
                HttpContext.Session["usrFnmLnm"] = FNLN + " / " + cpny;
                //     HttpContext.Current.Session["usrFnmLnm"] = null;

                int _UserID = (HttpContext.Session["usrid"] == null)  ? 0 : Int32.Parse(HttpContext.Session["usrid"].ToString());

                string cfid = "";// : HttpContext.Session["cfid"].ToString();
                if ((HttpContext.Session["cfid"] == null))   createNewCF();
                cfid = HttpContext.Session["cfid"].ToString();
                string errlst = (cfid != "") ? "" : "ERROR CFID...... / ";

                // if (!MainMDI.Creat_TempTbls(_UserID)) ViewBag.error = "ERROR temp Files......";
                if (!MainMDI.Creat_TempTbls(Int32.Parse( cfid))) ViewBag.error = errlst+ ".....ERROR temp Files......";

                string tt=HttpContext.Session["usr"].ToString();
                return Json(new { code = 1 }, JsonRequestBehavior.AllowGet);
            }
            else return Json(new { code = 0 }, JsonRequestBehavior.AllowGet);
        }

        //******************************
        //public static string getIPAddress(HttpRequestBase request)
        //{
        //    string szRemoteAddr = request.UserHostAddress;
        //    string szXForwardedFor = request.ServerVariables["X_FORWARDED_FOR"];
        //    string szIP = "";

        //    if (szXForwardedFor == null)
        //    {
        //        szIP = szRemoteAddr;
        //    }
        //    else
        //    {
        //        szIP = szXForwardedFor;
        //        if (szIP.IndexOf(",") > 0)
        //        {
        //            string[] arIPs = szIP.Split(',');

        //            foreach (string item in arIPs)
        //            {
        //                if (!isPrivateIP(item))
        //                {
        //                    return item;
        //                }
        //            }
        //        }
        //    }
        //    return szIP;
        //}

        //private static bool IsPrivateIpAddress(string ipAddress)
        //{
        //    // http://en.wikipedia.org/wiki/Private_network
        //    // Private IP Addresses are: 
        //    //  24-bit block: 10.0.0.0 through 10.255.255.255
        //    //  20-bit block: 172.16.0.0 through 172.31.255.255
        //    //  16-bit block: 192.168.0.0 through 192.168.255.255
        //    //  Link-local addresses: 169.254.0.0 through 169.254.255.255 (http://en.wikipedia.org/wiki/Link-local_address)

        //    var ip = IPAddress.Parse(ipAddress);
        //    var octets = ip.GetAddressBytes();

        //    var is24BitBlock = octets[0] == 10;
        //    if (is24BitBlock) return true; // Return to prevent further processing

        //    var is20BitBlock = octets[0] == 172 && octets[1] >= 16 && octets[1] <= 31;
        //    if (is20BitBlock) return true; // Return to prevent further processing

        //    var is16BitBlock = octets[0] == 192 && octets[1] == 168;
        //    if (is16BitBlock) return true; // Return to prevent further processing

        //    var isLinkLocalAddress = octets[0] == 169 && octets[1] == 254;
        //    return isLinkLocalAddress;
        //}

        //*********************************************


        public static string GetUserIP()
        {
            var ip = (System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null
            && System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != "")
            ? System.Web.HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"]
            : System.Web.HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
            if (ip.Contains(","))
                ip = ip.Split(',').First().Trim();
            return ip;
        }

        void createNewCF()
        {

            // string ipa = Request.UserHostAddress;
            string ipa = System.Web.HttpContext.Current.Request.UserHostAddress;
            string ipa_RMT = Request.ServerVariables["REMOTE_ADDR"];
            string ipa_XFWRD = GetUserIP();// Request.ServerVariables["HTTP_X_FORWARDED_FOR"];    //request.ServerVariables["X_FORWARDED_FOR"];   
            //X_FORWARDED_FOR
            HttpContext.Session["ipa"] = ipa_XFWRD;// ipa_RMT;  // ipa_RMT;// ipa;
            HttpContext.Session["ipa_RMT"] = ipa_RMT;

            string usr = (HttpContext.Session["usr"] == null) ? "" : HttpContext.Session["usr"].ToString();

            string mach_name = ipa_XFWRD;// ipa + " | " + ipa_RMT +" | " +ipa_XFWRD;// ipa_XFWRD;// HttpContext.Session["ipa"].ToString();// System.Environment.MachineName;


            //  MainMDI.usr=h
            //   MainMDI.Exec_SQL_JFS("delete Configo_cf_info where usrname='" + MainMDI.usr + "'", "Configo del old CF..");
            string ddstr = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");     //System.DateTime.Now.Day + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Year;
            string cfname = "cf_" + DateTime.Now.Year.ToString() + MainMDI.A00(DateTime.Now.Month.ToString(), 2) + MainMDI.A00(DateTime.Now.Day.ToString(), 2) + "_" + MainMDI.A00(DateTime.Now.Hour.ToString(), 2) + MainMDI.A00(DateTime.Now.Minute.ToString(), 2);
            string stSql = "INSERT INTO Configo_cf_info ([cfname],[datein],[machNM], [usrname]) VALUES ('" + cfname + "', '" + ddstr + "', '" + mach_name + "', '" + usr + "')";

            MainMDI.Exec_SQL_JFS(stSql, " Configo new CF...", usr);
            string id = MainMDI.Find_One_Field("select cflid from Configo_cf_info where [cfname]='" + cfname + "'");
            // MainMDI.cfid = id;
            HttpContext.Session["cfid"] = (id == MainMDI.VIDE) ? "" : id;

        }


        string GivmeNewCF()
        {

           //// string ip = Request.UserHostAddress;


           // string mach_name = System.Environment.MachineName;


           // //  MainMDI.usr=h
           // //   MainMDI.Exec_SQL_JFS("delete Configo_cf_info where usrname='" + MainMDI.usr + "'", "Configo del old CF..");
           // string ddstr = System.DateTime.Now.Day + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Year;
           // string cfname = "cf_" + DateTime.Now.Year.ToString() + MainMDI.A00(DateTime.Now.Month.ToString(), 2) + MainMDI.A00(DateTime.Now.Day.ToString(), 2) + "_" + MainMDI.A00(DateTime.Now.Hour.ToString(), 2) + MainMDI.A00(DateTime.Now.Minute.ToString(), 2);
           // string stSql = "INSERT INTO Configo_cf_info ([cfname],[datein],[machNM], [usrname]) VALUES ('" + cfname + "', " + MainMDI.SSV_date(ddstr) + ", '" + mach_name + "', '" + MainMDI.usr + "')";

           // MainMDI.Exec_SQL_JFS(stSql, " Configo new CF...");
           // string id = MainMDI.Find_One_Field("select cflid from Configo_cf_info where [cfname]='" + cfname + "'");
           // if (id != MainMDI.VIDE) return id.ToString();
           return "0";
        }




        //       return View("ERROR_NOSIZING");
        //        return View("~/Views/configo/Index.cshtml");



        //  lst_chconfigs.Add(curr_charger);
        //  return Json(lst_chconfigs, JsonRequestBehavior.AllowGet);



        




    }
}