using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Office.Core;
using PBsizing.Models;




namespace PBsizing.Controllers
{
    public class HomeController : Controller
    {
        string mykey = "agen";
        Orig_PSM_FDBEntities2 mydb = new Orig_PSM_FDBEntities2();
  
        private string XTRCT_UserNameOLD(string STin)
        {
            int ipos = STin.IndexOf("?"), fpos = STin.IndexOf("=");
            if (ipos > -1 && fpos > -1 && ipos < fpos)
                return STin.Substring(ipos+1, fpos - ipos-1);
            else    return "";
            
        }
        private bool XTRCT_paraQRY(string STin, ref string u, ref string r, ref string o)
        {
            u = ""; r = ""; o = "";
            
            int ipos = STin.IndexOf("?"), fpos = STin.IndexOf("=");
            if (ipos > -1 && fpos > -1 && ipos < fpos)
            {

                string[] para = new string[4] { "", "", "" ,""};
                para = STin.Split(new char[] { '?', '&' });

                if (para[1] != "")
                {
                    string[] inf = para[1].Split('='); u = inf[1];
                    if (para[2] != "") inf = para[2].Split('='); o = inf[1];
                    //   inf = para[3].Split('='); r = inf[1];
                    // return true;
                    return (u != "" && o != "");
                }
                else return false;
            }

            else return false;

        }

         string find_RID_RRev(long irrev)
        {
           // var Curr_Rev = mydb.PSM_R_Rev.Where(x => x.IRRevID == 4444).Single();
            var Curr_Rev = mydb.PSM_R_Rev.Where(x => x.IRRevID == irrev).FirstOrDefault();

            if (Curr_Rev != null)  return Curr_Rev.RID + "  /  " + Curr_Rev.RRev_Name;
            else return "??????";
        }
        public string ognid(string PS_)
        {

            if (PS_ != "")
            {
                //    lpsEnc.Text = StringCipher.Encrypt(tPass.Text, mykey);
                //    DBpwd = StringCipher.Decrypt(DBpwd, mykey);

                try
                {
                    string rt = MainMDI.StringCipher.Decrypt(PS_, mykey);
                    return rt;
                }
                catch (Exception ex)
                {

                    return "????";// + ex.Message;
                }
            }
            else return "????";

        }

        void fill_userINFO(string usr)
        {
            if (HttpContext.Session["salesP"] == null)
            {
                switch (usr)
                {
                  
                    case "amvoinescu":
                        HttpContext.Session["salesP"] = "ALL";
                        HttpContext.Session["salesPname"] = "ALL";
                        break;
                    case "bcimon":
                        HttpContext.Session["salesP"] = "S03";
                        HttpContext.Session["salesPname"] = "Benoit Cimon";
                        break;
                    case "ylavoie":
                    case "ede":
                        HttpContext.Session["salesP"] = "S05";
                        HttpContext.Session["salesPname"] = "Yves Lavoie";
                        break;
                    case "mmaturi":
                        HttpContext.Session["salesP"] = "S08";
                        HttpContext.Session["salesPname"] = "Maria Ester Maturi";
                        break;
                    default:
                        HttpContext.Session["salesP"] = "";
                        HttpContext.Session["salesPname"] = "";
                        break;
                }
            }


        }

        public JsonResult donga_agnod(string usrnm, string usrpwd)
        {

            //   string res = MainMDI.Find_One_Field("select userid from cedule_Usetup where usrname='" + usrnm + "'  and usrpwd='" + usrpwd + "' and actif=1 ");
            //   string res = MainMDI.Find_One_Field("select mdul from cedule_Usetup where usrname='" + usrnm + "'  and usrpwd='" + usrpwd + "' and actif=1 ");


            string mdul = MainMDI.VIDE, cpny = MainMDI.VIDE;
            MainMDI.Find_2_Field("select mdul,cpnyID from cedule_Usetup where usrname='" + usrnm + "'  and usrpwd='" + usrpwd + "' and actif=1 ",ref mdul, ref cpny);

            if (mdul != MainMDI.VIDE && cpny != MainMDI.VIDE)
            {
               HttpContext.Session["usr"] = usrnm;
                HttpContext.Session["mdul"] = mdul;
                HttpContext.Session["cpny"] = cpny;
                return Json(new { code = 1 }, JsonRequestBehavior.AllowGet);
            }
            else return Json(new { code = 0 }, JsonRequestBehavior.AllowGet);

            //    HttpContext.Session["usrid"] = res;

            //    //    string in_CFID = (MainMDI.myCFID.ToString() == "0") ? GivmeNewCF() : MainMDI.myCFID.ToString();
            //    //MainMDI.usr = usrnm; 
            //    //MainMDI.UserID = res;
            //    string FNLN = "", cpny = "";
            //    MainMDI.Find_2_Field("select FnmLnm,[SP_cpny_Name] from configo_Usetup inner join [dbo].[configo_Usetup_cpny] on configo_Usetup.[cpnyID]=configo_Usetup_cpny.cpny_lid  where userid=" + res, ref FNLN, ref cpny);
            //    HttpContext.Session["usrFnmLnm"] = FNLN + " / " + cpny;
            //    //     HttpContext.Current.Session["usrFnmLnm"] = null;

            //    int _UserID = (HttpContext.Session["usrid"] == null) ? 0 : Int32.Parse(HttpContext.Session["usrid"].ToString());

            //    string cfid = "";// : HttpContext.Session["cfid"].ToString();
            ////    if ((HttpContext.Session["cfid"] == null)) createNewCF();
            //    cfid = HttpContext.Session["cfid"].ToString();
            //    string errlst = (cfid != "") ? "" : "ERROR CFID...... / ";

            //    // if (!MainMDI.Creat_TempTbls(_UserID)) ViewBag.error = "ERROR temp Files......";
            //    if (!MainMDI.Creat_TempTbls(Int32.Parse(cfid))) ViewBag.error = errlst + ".....ERROR temp Files......";

            //    string tt = HttpContext.Session["usr"].ToString();
        }


        public ActionResult Index_OLD()
        {

    
            string usr = "", irrev = "", Opera = "";
            if (Request.Url.Query.Length == 0 && HttpContext.Session["usr"] != null) usr = HttpContext.Session["usr"].ToString();
            else
            {
                HttpContext.Session["usr"] = null;
                if (Request.Url.Query == "?moaadicms" || Request.Url.Query == "?moaaditr")
                {
                    if (Request.Url.Query == "?moaadicms")
                    {
                        HttpContext.Session["usr"] = "ede";
                        usr = "ede";
                        Opera = "c";
                        HttpContext.Session["irrev"] = "";
                    }
                    if (Request.Url.Query == "?moaaditr")
                    {
                        HttpContext.Session["usr"] = "ede";
                        usr = "ede";
                        Opera = "t";
                        HttpContext.Session["irrev"] = "8149";
                    }
                }
                else
                {
                    if (HttpContext.Session["usr"] == null || HttpContext.Session["usr"].ToString() == "")
                    {

                        string para = (Request.Url.Query.Length > 2) ? ognid(Request.Url.Query.Substring(1, Request.Url.Query.Length - 1)) : ognid(Request.Url.Query);//.Replace("||", "/"));
                                                                                                                                                                      //para = para.Replace("||", "/");
                        if (para != "????")
                        {
                            if (XTRCT_paraQRY("?" + para, ref usr, ref irrev, ref Opera))
                            {
                                HttpContext.Session["usr"] = usr;
                                HttpContext.Session["irrev"] = irrev;
                                HttpContext.Session["opera"] = Opera;
                            }
                        }

                    }
                    else
                    {
                        usr = HttpContext.Session["usr"].ToString();
                        irrev = HttpContext.Session["irrev"].ToString();
                        Opera = HttpContext.Session["opera"].ToString();
                    }
                }
            }

            if (Opera == "" || usr == "") return View("~/Views/Shared/logon.cshtml"); // return View("~/Views/Home/ERROR_NOSIZING.cshtml");
            else
            {

                if (irrev != "")
                {
                    ViewBag.IRREV = irrev;
                    Int64 L_irrev = Convert.ToInt64(irrev);
                    ViewBag.mylist = mydb.PSM_R_TRInfo.Where(x => x.tr_iRRevID == L_irrev).ToList();// new SelectList(mydb.PSM_R_TRInfo.ToList(), "tr_LID", "tr_TRName");  
                    ViewBag.RID = find_RID_RRev(L_irrev);
                }


                ViewBag.userName = usr;
                if (Opera == "c")
                {
                    switch (usr)
                    {
                        case "ede":
                        case "bcimon":
                        case "ylavoie":
                        case "mmaturi":
                        case "amvoinescu":

                            fill_userINFO(usr);

                            //return View("~/Views/TestsReport/TestsReport.cshtml");
                            return View("~/Views/Home/carousel.cshtml");
                            break;

                        default:
                            return View("~/Views/Shared/logon.cshtml");
                            // return View("~/Views/Home/ERROR_NOSIZING.cshtml");
                    }
                }
                else
                {
                    if (Opera == "t") return View("~/Views/TestsReport/TestsReport.cshtml");
                    else return View("~/Views/Shared/logon.cshtml");
                    //return View("~/Views/Home/ERROR_NOSIZING.cshtml");
                }
            }

        }



        public ActionResult Index_12082020()
        {


            //    return View("~/Views/Shared/logon.cshtml");

            // && HttpContext.Session["usr"] != null) usr = HttpContext.Session["usr"].ToString();

            string usr = "", irrev="", Opera = "";


            if (HttpContext.Session["usr"] != null && HttpContext.Session["usr"].ToString() != "")
            {
                usr = HttpContext.Session["usr"].ToString();
                //  irrev = HttpContext.Session["irrev"].ToString();
                // Opera = HttpContext.Session["opera"].ToString();
            }
            else
            {
                if (Request.Url.Query.Length > 0)
                {
                    if (Request.Url.Query == "?moaadicms" || Request.Url.Query == "?moaaditr")
                    {
                        if (Request.Url.Query == "?moaadiups")
                        {
                            HttpContext.Session["usr"] = "ede";
                            usr = "ede";
                            Opera = "u";
                            HttpContext.Session["irrev"] = "";
                        }

                        if (Request.Url.Query == "?moaadicms")
                        {
                            HttpContext.Session["usr"] = "ede";
                            usr = "ede";
                            Opera = "c";
                            HttpContext.Session["irrev"] = "";
                        }
                        if (Request.Url.Query == "?moaaditr")
                        {
                            HttpContext.Session["usr"] = "ede";
                            usr = "ede";
                            Opera = "t";
                            HttpContext.Session["irrev"] = "8149";
                        }
                    }
                    else
                    {
                        string para = (Request.Url.Query.Length > 2) ? ognid(Request.Url.Query.Substring(1, Request.Url.Query.Length - 1)) : ognid(Request.Url.Query);//.Replace("||", "/"));
                                                                                                                                                                      //para = para.Replace("||", "/");
                        if (para != "????")
                        {
                            if (XTRCT_paraQRY("?" + para, ref usr, ref irrev, ref Opera))
                            {
                                HttpContext.Session["usr"] = usr;
                                //HttpContext.Session["irrev"] = irrev;
                                HttpContext.Session["opera"] = Opera;
                            }
                        }
                    }

                }
            }
 

            if (usr == "") return View("~/Views/Shared/logon.cshtml"); // return View("~/Views/Home/ERROR_NOSIZING.cshtml");
            else
            {

                if (irrev != "")
                {
                    ViewBag.IRREV = irrev;
                    Int64 L_irrev = Convert.ToInt64(irrev);
                    ViewBag.mylist = mydb.PSM_R_TRInfo.Where(x => x.tr_iRRevID == L_irrev).ToList();// new SelectList(mydb.PSM_R_TRInfo.ToList(), "tr_LID", "tr_TRName");  
                    ViewBag.RID = find_RID_RRev(L_irrev);
                }


                ViewBag.userName = usr;
                if (Opera == "c")
                {
                    switch (usr)
                    {
                        case "ede":
                        case "bcimon":
                        case "ylavoie":
                        case "mmaturi":
                        case "amvoinescu":

                            fill_userINFO(usr);

                            //return View("~/Views/TestsReport/TestsReport.cshtml");
                            return View("~/Views/Home/carousel.cshtml");
                            break;

                        default:
                            return View("~/Views/Home/carousel.cshtml");
                            //return View("~/Views/Shared/logon.cshtml");
                            // return View("~/Views/Home/ERROR_NOSIZING.cshtml");
                            break;
                    }
                }
                else
                {
                    return View("~/Views/Home/carousel.cshtml");
                    //if (Opera == "t") return View("~/Views/TestsReport/TestsReport.cshtml");
                    //else return View("~/Views/Shared/logon.cshtml");
                    ////return View("~/Views/Home/ERROR_NOSIZING.cshtml");
                }
            }

        }

        public ActionResult Index()
        {


            //    return View("~/Views/Shared/logon.cshtml");

            // && HttpContext.Session["usr"] != null) usr = HttpContext.Session["usr"].ToString();

            string usr = "", mdul = "", cpny= "";


            if (HttpContext.Session["usr"] != null && HttpContext.Session["usr"].ToString() != "")
            {
                usr = HttpContext.Session["usr"].ToString();
                mdul = HttpContext.Session["mdul"].ToString();
                cpny = HttpContext.Session["cpny"].ToString();
            }

            if (usr == "") return View("~/Views/Shared/logon.cshtml"); // return View("~/Views/Home/ERROR_NOSIZING.cshtml");
            else
            {

                ViewBag.userName = usr;
                ViewBag.cpny = cpny;

                switch (mdul.TrimEnd())
                {
                    case "CMU":
                        //fill_userINFO(usr);
                        //return View("~/Views/TestsReport/TestsReport.cshtml");
                        return View("~/Views/Home/carousel.cshtml");
                        break;
                    case "C--":
                        //fill_userINFO(usr);
                        //return View("~/Views/TestsReport/TestsReport.cshtml");

                        //    return View("~/Views/Cedule/cedmenu.cshtml");
                        return View("~/Views/Cedule/cedulemnu.cshtml");
                        break;
                    case "CCC":
                        //fill_userINFO(usr);
                        //return View("~/Views/TestsReport/TestsReport.cshtml");

                        //    return View("~/Views/Cedule/cedmenu.cshtml");
                        //  return View("~/Views/Cedule/cedulemnu.cshtml");

                        return RedirectToAction("Disp_Steps", "Cedule");
                        break;

                    default:
                        //  return View("~/Views/Home/carousel.cshtml");
                        ViewBag.userName = usr+" ---> error module: "+ mdul ;
                        return View("~/Views/Shared/logon.cshtml");
                        // return View("~/Views/Home/ERROR_NOSIZING.cshtml");
                        break;
                }
            }
        }

     


        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult carousel()
        {
            return View();
        }


        public ActionResult Logout()
        {
            HttpContext.Session["usr"] = null;
            HttpContext.Session["usrFnmLnm"] = null;
            HttpContext.Session["cfid"] = null;


            return View("~/Views/Shared/logon.cshtml");

        }

    }
}
