using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PBsizing.Models;
using System.Web.Mvc;
using System.Data.Sql;
using EAHLibs;
using System.Data.SqlClient;



namespace PBsizing.Controllers
{
    public class AGCMSController : Controller
    {
        //
        // GET: /AGCMS/
        private static Lib1 Tools = new Lib1();
        string mykey = "agen";
     //   SysproCompanyPEntities1 mySP_db = new SysproCompanyPEntities1();

        class msgrec
        {
            public string msg { get; set; }
            public string recnb { get; set; }


        }

        class INV_NOAG
        {

            public string dateinv { get; set; }
            public string Invoice { get; set; }
            public string Project { get; set; }
            public string Customer { get; set; }
            public string Salesperson2 { get; set; }


        }
        class Agency
        {
            public string codeAG { get; set; }
            public string AGname { get; set; }

        }
        List<msgrec> msgLst = new List<msgrec>();
        List<Agency> AGlist = new List<Agency>();
        List<Agency> SPlist = new  List<Agency>();

        List<V_u_agcmsmvmt> INV_NOAGlist = new List<V_u_agcmsmvmt>();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AgenciesCMS()
        {
            if (HttpContext.Session["usr"] != null)
            {

 
                int MM = 0, YYYY = 0;
                CMS_period_MMYYYY(ref MM, ref YYYY);
                ViewBag.mmyyyy = MainMDI.A00(MM, 2) + "/" + YYYY.ToString();
                // 
                string usr = HttpContext.Session["usr"].ToString();
                ViewBag.userName = usr;
                switch (usr)
                {
                  //  case "ede":
                    case "amvoinescu":
                        fill_AGLIST();
                        ViewBag.aglist = AGlist;
                        fill_SPLIST_SP("ALL");
                        ViewBag.splist = SPlist;
                        return View();
                        break;
                    case "ede":
                    case "bcimon":
                    case "ylavoie":
                    case "mmaturi":
                        HttpContext.Session["salesP"] = "ylavoie";
                        string sp = HttpContext.Session["salesP"].ToString();
                        fill_AGLIST();
                        ViewBag.aglist = AGlist;
                        fill_SPLIST_SP(sp);
                        ViewBag.splist = SPlist;
                        return View("~/Views/AGCMS/INV_bySP.cshtml");
                        break;

                }
            }
            // return View("ERROR_NOSIZING");
            return  View("~/Views/Shared/logon.cshtml");
            //View("~/Views/Home/ERROR_NOSIZING.cshtml");
        }


        bool ValidUser()
        {

            return (HttpContext.Session["usr"] != null && HttpContext.Session["usr"].ToString() != "");
        }

        public JsonResult Impcms()
        {
            if (ValidUser())
            {
                msgrec mymsg = new msgrec();

                // string json = "OK";
                // int month = 1, yyyy = 2019;
                int nbrec = 0;
                mymsg.msg = Import_AG_CMS(ref nbrec);
                mymsg.recnb = nbrec.ToString();
                msgLst.Add(mymsg);
                //     System.Threading.Thread.Sleep(3000);
                // return Json(json, "application/json");
                return Json(msgLst, JsonRequestBehavior.AllowGet);
            }
            else
            {
                RedirectToAction("Login", "AGCMS");
                return Json(null);
            }

        }

        public JsonResult Impcms_mmyyyy(string _mm,string _yyyy)
        {
            msgrec mymsg = new msgrec();

            // string json = "OK";
            // int month = 1, yyyy = 2019;
            int nbrec = 0;
            mymsg.msg = Import_AG_CMS (_mm,_yyyy,ref nbrec);
            mymsg.recnb = nbrec.ToString();
            msgLst.Add(mymsg);
         //   System.Threading.Thread.Sleep(3000);
            // return Json(json, "application/json");
            return Json(msgLst, JsonRequestBehavior.AllowGet);

        }
        public JsonResult sav_newgrp(string _lid,string _grp)
        {
            //    "SELECT pct1,pct2,pct3,pct4  FROM U_ag_tskgrpcof where grp = '" + grp + "'", ref pct1, ref pct2, ref pct3, ref pct4);


            msgrec mymsg = new msgrec();

            MainMDI.Exec_SQL_JFS("update u_agcmsmvmt set [grp]='" + _grp + "' where agcmsLID=" + _lid," modif item grp","CMS_AG");


            decimal price =(decimal) Tools.Conv_Dbl(MainMDI.Find_One_Field("SELECT Price  FROM u_agcmsmvmt where agcmsLID=" + _lid));

            if (price > 0)
            {

                decimal[,] myarr = new decimal[4, 2];
                Cal_cmspct_grp(_grp, price, ref myarr);

                MainMDI.Exec_SQL_JFS("update u_agcmsmvmt set [desti_rt]=" + myarr[0,0] + ", [desti_amnt] = " + myarr[0,1] +

                    ", [inf_rt] = " + myarr[1,0] + ", [inf_amnt] = " + myarr[1,1] +
                    ", [eng_rt] = " + myarr[2, 0] + ", [eng_amnt] = " + myarr[2, 1] +
                    ", [po_rt] = " + myarr[3, 0] + ", [po_amnt] = " + myarr[3, 1] +
                    " where agcmsLID=" + _lid, " modif rates, amnts", "CMS_AG");
                
                mymsg.msg = "Done.";
                mymsg.recnb = "4";
            }

            else
            {
                mymsg.msg = "Not done ...... PRICE is NULL.....";
                mymsg.recnb = "0";
            }
            msgLst.Add(mymsg);
            return Json(msgLst, JsonRequestBehavior.AllowGet);

        }


        public JsonResult sav_newinvolv(string _lid,string _desti, string _inf, string _ing, string _po)
        {
            //    "SELECT pct1,pct2,pct3,pct4  FROM U_ag_tskgrpcof where grp = '" + grp + "'", ref pct1, ref pct2, ref pct3, ref pct4);


            msgrec mymsg = new msgrec();
            string stSql = "";

            if (Tools.Conv_Dbl( _lid) > 0)
            {
                string sttDest = (_desti.Length > 0) ? " [desti_AG] = '" + _desti +"' " : "";
                string sttinf = (_inf.Length > 0) ? " [inf_AG]='" + _inf + "' " : "";
                string stting = (_ing.Length > 0) ? " [eng_AG]='" + _ing + "' " : "";
                string sttpo = (_po.Length > 0) ? " [po_AG]='" + _po + "' " : "";


                string sett = (sttDest != "") ? sttDest : "";

                sett += (sttinf != "" && sett !="") ? "," : "";
                sett += (sttinf != "") ? sttinf : "";

                sett += (stting != "" && sett != "") ? "," : "";
                sett += (stting != "") ? stting : "";

                sett += (sttpo != "" && sett != "") ? "," : "";
                sett += (sttpo != "") ? sttpo : "";



                //   if (sttDest != "" || sttinf != "" || stting != "" || sttpo != "")
                if (sett != "" )
                {
                    MainMDI.Exec_SQL_JFS("update u_agcmsmvmt set " + sett + "  where agcmsLID=" + _lid, " modif Involv.", "CMS_AG");
                    mymsg.msg = "Done.";
                    mymsg.recnb = "4";
                }
                else
                {
                    mymsg.msg = "Involving info is Invalid..... ";
                    mymsg.recnb = "0";
                }
            }
            else
            {
                mymsg.msg = "Not done ...... PRICE is NULL.....";
                mymsg.recnb = "0";
            }
            msgLst.Add(mymsg);
            return Json(msgLst, JsonRequestBehavior.AllowGet);

        }




        void Cal_cms_Newpct(string Price, ref decimal[,] rt_amt)
        {
           // for (int i = 0; i < 4; i++) { rt_amt[i, 0] = 0; rt_amt[i, 1] = 0; }
           decimal pct1 = rt_amt[0, 0], pct2 = rt_amt[1, 0], pct3 = rt_amt[2, 0], pct4 = rt_amt[3, 0];

            decimal deci = 0;
       //     MainMDI.Find_n_Field("SELECT pct1,pct2,pct3,pct4  FROM U_ag_tskgrpcof where grp = '" + grp + "'", ref pct1, ref pct2, ref pct3, ref pct4);

                for (int i = 0; i < 4; i++)
                {
                    deci = 0;
                    switch (i)
                    {
                        case 0:
                            deci = pct1 * decimal.Parse(Price);
                            rt_amt[i, 0] = pct1;
                            break;
                        case 1:
                            deci = pct2 * decimal.Parse(Price);
                            rt_amt[i, 0] = pct2;
                            break;
                        case 2:
                            deci = pct3 * decimal.Parse(Price);
                            rt_amt[i, 0] = pct3;
                            break;
                        case 3:
                            deci = pct4 * decimal.Parse(Price);
                            rt_amt[i, 0] = pct4;
                            break;

                    }
                    decimal ff = deci / 100;

                    rt_amt[i, 1] = deci / 100;

                }
           

        }
        public JsonResult sav_new_rates(string _lid, string _desti, string _inf, string _ing, string _po)
        {
            //    "SELECT pct1,pct2,pct3,pct4  FROM U_ag_tskgrpcof where grp = '" + grp + "'", ref pct1, ref pct2, ref pct3, ref pct4);

            decimal[,] rt_amt = new decimal[4, 2];
            rt_amt[0, 0] =Decimal.Parse( _desti);   rt_amt[0, 1] = 0;
            rt_amt[1, 0] = Decimal.Parse(_inf);     rt_amt[1, 1] = 0;
            rt_amt[2, 0] = Decimal.Parse(_ing);     rt_amt[2, 1] = 0;
            rt_amt[3, 0] = Decimal.Parse(_po);      rt_amt[3, 1] = 0;
            // for (int i = 0; i < 4; i++) { rt_amt[i, 0] = 0; rt_amt[i, 1] = 0; }


            msgrec mymsg = new msgrec();
            string grp = "", price = "0";
            if (Tools.Conv_Dbl(_lid) > 0)
            {
                MainMDI.Find_2_Field("SELECT grp, price  FROM [Orig_PSM_FDB].[dbo].[U_agCMSmvmt] where agcmsLID=" + _lid, ref grp, ref price);
               // MainMDI.Find_One_Field("SELECT grp  FROM [Orig_PSM_FDB].[dbo].[U_agCMSmvmt] where agcmsLID=" + _lid);

                if (grp == "A" || grp == "B" || grp == "C" || grp == "D" || grp == "E" || grp == "F")
                {
                    string rtALL = MainMDI.Find_One_Field("SELECT [pctall]  FROM [Orig_PSM_FDB].[dbo].[U_ag_tskgrpcof] where grp='" + grp + "'");
                    if (Tools.Conv_Dbl(rtALL) > 0)
                    {
                        if ((Tools.Conv_Dbl(_desti) + Tools.Conv_Dbl(_inf) + Tools.Conv_Dbl(_ing) + Tools.Conv_Dbl(_po)) == Tools.Conv_Dbl(rtALL))
                        {
                            Cal_cms_Newpct(price,ref rt_amt);

                            MainMDI.Exec_SQL_JFS("update u_agcmsmvmt set [desti_rt]= " + rt_amt[0,0] + ", [desti_amnt] = " + rt_amt[0,1] +
                                                              " ,         [inf_rt]= " + rt_amt[1, 0] + ", [inf_amnt] = " + rt_amt[1, 1] +
                                                              " ,         [eng_rt] = " + rt_amt[2, 0] + ", [eng_amnt] = " + rt_amt[2, 1] + 
                                                              " ,         [po_rt] = " + rt_amt[3, 0] + ", [po_amnt] = " + rt_amt[3, 1] + 
                                                 "  where agcmsLID=" + _lid, " modif rates....", "CMS_AG sav new rates...");
                            mymsg.msg = "Done.";
                            mymsg.recnb = "4";
                        }
                        else
                        {
                            mymsg.msg = "Errors in New rates.....sum of all rates must be equal to: " + rtALL;
                            mymsg.recnb = "0";
                        }

                    }
                    else
                    {
                        mymsg.msg = "can not find Complete rate.....";
                        mymsg.recnb = "0";
                    }
                }
                else
                {
                    mymsg.msg = "group is invalid....V= "+grp;
                    mymsg.recnb = "0";
                }

            }
            else
            {
                mymsg.msg = "Rec id is invalid....";
                mymsg.recnb = "0";
            }


            msgLst.Add(mymsg);
            return Json(msgLst, JsonRequestBehavior.AllowGet);
        }


            public JsonResult Savinvnoag(string _inv,string _newag)
        {
            //    "SELECT pct1,pct2,pct3,pct4  FROM U_ag_tskgrpcof where grp = '" + grp + "'", ref pct1, ref pct2, ref pct3, ref pct4);

            msgrec mymsg = new msgrec();
            mymsg.msg = "";
            mymsg.recnb = "1";

            string ag = _newag.Substring(0, 3);
            if (ag[0]=='A')
            { 
           
                  MainMDI.Exec_SQL_JFS_SYSPRO("update  u_SalCommissionsPrimax set [Salesperson2]='" +ag + "' where Invoice='" + _inv + "'", " fix empty invoice...", "CMS_AG");
                mymsg.msg = "Done.";
                mymsg.recnb = "1";
              if (  Import_INV(_inv,_newag) !="")
                {
                    mymsg.msg = "Error Invoice import.....";
                    mymsg.recnb = "0";
                }
            }

            else
            {
                mymsg.msg = "Error Agency.....";
                mymsg.recnb = "0";
            }
            msgLst.Add(mymsg);
            return Json(msgLst, JsonRequestBehavior.AllowGet);

        }





        void CMS_period_MMYYYY(ref int month,ref int Year)
        {

            month = -1;  Year = -1;
            string MM = "", YYYY = "";
            MainMDI.Find_2_Field("SELECT [F2] ,[F3]  FROM [Orig_PSM_FDB].[dbo].[PSM_C_GConfig] where F1_code='CMS_MMYY'", ref MM, ref YYYY);
            if (MM != MainMDI.VIDE)
            {

                MM = MM.Substring(0, 2);
                if (Tools.Conv_Dbl(MM) == 12)
                {
                   month = 1;
                    Year = Int32.Parse(YYYY);
                 }
                else
                {
                    month = Int32.Parse(MM) + 1;
                    Year = Int32.Parse(YYYY) - 1;
                }
              
            }

        }


        private void cbSales_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            //txSalesName.Text = cbSales.Text;
            ////    lSalesCode.Text = MainMDI.Find_One_Field_ACCESS("SELECT dbo_SalSalesperson.Salesperson FROM dbo_SalSalesperson WHERE dbo_SalSalesperson.Name='" + txSalesName.Text + "' AND dbo_SalSalesperson.Branch='C1'");


            //lSalesCode.Text = MainMDI.Find_One_Field_SYSPRO("SELECT SalSalesperson.Salesperson FROM SalSalesperson WHERE SalSalesperson.Name='" + txSalesName.Text + "' AND SalSalesperson.Branch='C1'");


        }

        void fill_CBMMYY()
        {
            //string MM = "", YY = "";
            //MainMDI.Find_2_Field("SELECT [F2] ,[F3]  FROM [Orig_PSM_FDB].[dbo].[PSM_C_GConfig] where F1_code='CMS_MMYY'", ref MM, ref YY);
            //if (MM != MainMDI.VIDE)
            //{
            //    cb_MM.Text = MM;
            //    cb_YY.Text = YY;
            //}
        }



       void Cal_cmspct_grp(string grp,decimal Price,ref  decimal[,] rt_amt )
        {
            for (int i = 0; i < 4; i++) { rt_amt[i, 0] = 0; rt_amt[i, 1] = 0; }
            string pct1 = "", pct2 = "", pct3 = "", pct4 = "";
            decimal deci = 0;
            MainMDI.Find_n_Field("SELECT pct1,pct2,pct3,pct4  FROM U_ag_tskgrpcof where grp = '" + grp +"'" ,ref pct1,ref pct2,ref pct3,ref pct4);
            if (pct1 != MainMDI.VIDE)
            {
                for (int i = 0; i < 4; i++)
                {
                    deci = 0;
                    switch (i)
                    {
                        case 0:
                            deci = decimal.Parse(pct1) * Price;
                            rt_amt[i, 0] = decimal.Parse(pct1);
                            break;
                        case 1:
                            deci = decimal.Parse(pct2) * Price;
                            rt_amt[i, 0] = decimal.Parse(pct2);
                            break;
                        case 2:
                            deci = decimal.Parse(pct3) * Price;
                            rt_amt[i, 0] = decimal.Parse(pct3);
                            break;
                        case 3:
                            deci = decimal.Parse(pct4) * Price;
                            rt_amt[i, 0] = decimal.Parse(pct4);
                            break;

                    }
                    decimal ff = deci / 100;

                    rt_amt[i, 1] = deci / 100;

                }
            }
            
        }

        string pct_grp(string grp,string _tsk)
        {
            string res=MainMDI.Find_One_Field("SELECT pct  FROM U_ag_tskgrpcof where tskid =" +_tsk + " and grp = '" + grp +"'");
            return Tools.Conv_Dbl(res).ToString ();
        }

        string pct_grp_old(string grp)
        {



            string pct = "0";
            switch (grp.TrimEnd())
            {
                case "A":
                    pct = "10";
                    break;
                case "B":
                    pct = "5";
                    break;
                case "C":
                    pct = "7";
                    break;
                case "D":
                    pct = "12";
                    break;
                case "E":
                    pct = "3";
                    break;
                case "F":
                    pct = "1.5";
                    break;

            }

            return pct;

        }

        //===============================
        string Import_AG_CMS_OLD(ref int nb)
        {


            nb = 0;
            string retrnMsg = "ERROR CMS Period.....";
            int MM = -1, YYYY = -1;
            CMS_period_MMYYYY(ref MM, ref YYYY);

            if (MM > -1 && YYYY > -1)
            {
                double bigTOT = 0;
                decimal TOTSales = 0;



                SqlConnection OConn = null;
                SqlCommand Ocmd = null;
                SqlDataReader Oreadr = null;
                OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

                //[S03],[S05],[S08],

                string stSQL = " SELECT SalSalesperson.Salesperson, SalSalesperson.Name, u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Project, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Currency, " +
                               "        u_SalCommissionsPrimax.Branch,u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.SalesOrder, u_SalCommissionsPrimax.SalesOrderLine, u_SalCommissionsPrimax.StockCode,         u_SalCommissionsPrimax.StockDescription, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, " +
                               "        u_SalCommissionsPrimax.BackOrderQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.ExchangeRate, u_SalCommissionsPrimax.PriceCAD, u_SalCommissionsPrimax.ProductClass, u_SalCommissionsPrimax.CommissionSales1, (cast ([CommissionAmt1] AS decimal)) AS CommissionAmt1,  u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2,   " +
                               "        u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.Salesperson3, u_SalCommissionsPrimax.CommissionSales3, u_SalCommissionsPrimax.CommissionAmt3, u_SalCommissionsPrimax.Salesperson4, u_SalCommissionsPrimax.CommissionSales4, u_SalCommissionsPrimax.Rate, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.Rate  " +
                               " FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch) AND (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson)  " +
                               " WHERE (SalSalesperson.Salesperson in ('S03','S05','S08')) AND (YEAR (u_SalCommissionsPrimax.DateLastInvPrt) = " + YYYY + ") AND (month (u_SalCommissionsPrimax.DateLastInvPrt)= " + MM + ")  and (LOWER([Project]) not like '%cigentec%')    " +
                               " ORDER BY u_SalCommissionsPrimax.Invoice";


                //    string stout = "";
                //   ed_LVallInvoices.SendToBack();
                //  ed_lvITM.Items.Clear();
                try
                {

                    OConn.Open();
                    Ocmd = OConn.CreateCommand();
                    Ocmd.CommandText = stSQL;
                    Oreadr = Ocmd.ExecuteReader();
                    string oldINV = "", newINV = "";
                    while (Oreadr.Read())
                    {


                        if (!OKInvoice(Oreadr["Invoice"].ToString()))
                        {


                            string cust_SPcode = Oreadr["Customer"].ToString(), slsP = "", ag = "";
                            int pos = cust_SPcode.IndexOf("-");
                            if (pos > 6) cust_SPcode = cust_SPcode.Substring(0, pos - 1);
                            //string stt = "  SELECT distinct  ISNULL( SalSalesperson.Name,'????') as slsp , ISNULL( SalSalesperson_1.Name,'????') AS ag " +
                            //             "  FROM            v_PGCustomerXRef INNER JOIN SalSalesperson ON v_PGCustomerXRef.Branch = SalSalesperson.Branch AND v_PGCustomerXRef.Salesperson = SalSalesperson.Salesperson LEFT OUTER JOIN " +
                            //             "                  SalSalesperson AS SalSalesperson_1 ON v_PGCustomerXRef.Salesperson1 = SalSalesperson_1.Salesperson WHERE v_PGCustomerXRef.Customer='" + cust_SPcode + "'";
                            string stt = "  SELECT distinct  ISNULL( SalSalesperson.Name,'????') as slsp , ISNULL( SalSalesperson_1.Salesperson,'????') AS ag, ISNULL( SalSalesperson_1.Name,'????') AS agname  " +
                                         "  FROM            v_PGCustomerXRef INNER JOIN SalSalesperson ON v_PGCustomerXRef.Branch = SalSalesperson.Branch AND v_PGCustomerXRef.Salesperson = SalSalesperson.Salesperson LEFT OUTER JOIN " +
                                         "                  SalSalesperson AS SalSalesperson_1 ON v_PGCustomerXRef.Salesperson1 = SalSalesperson_1.Salesperson WHERE v_PGCustomerXRef.Customer='" + cust_SPcode + "'";

                            string agName = "";
                            MainMDI.Find_2_Field_PSA(stt, ref slsP, ref ag, ref agName, "S");

                            if (ag != "????" && Tools.Conv_Dbl(Oreadr["Price"].ToString()) > 0)
                            {
                                ag = ag + " - " + agName;
                                newINV = Oreadr["Invoice"].ToString();
                                if (oldINV != newINV && oldINV != "") SaveOKinvoice(oldINV);

                                //  ListViewItem lv = ed_lvITM.Items.Add(""); for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");

                                //lv.SubItems[0].Text = Oreadr["Project"].ToString();
                                //lv.SubItems[1].Text = Oreadr["Invoice"].ToString();
                                //lv.SubItems[2].Text = Oreadr["Customer"].ToString();

                                string msgERR = "";
                                string CustPO = MainMDI.Find_One_Field_SYSPRO("select CustomerPoNumber from [dbo].[SorMasterRep]   where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "'", ref msgERR);
                                //lv.SubItems[3].Text = CustPO;// MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");

                                //lv.SubItems[4].Text = ag;
                                //lv.SubItems[5].Text = Oreadr["StockDescription"].ToString();

                                string grpitem = MainMDI.Find_One_Field_SYSPRO("select UserDef from     dbo.SorDetailRep    where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "' and SalesOrderLine='" + Oreadr["SalesOrderLine"].ToString() + "'", ref msgERR);

                                grpitem = (grpitem.TrimEnd() == "") ? "A" : grpitem.TrimEnd();
                                //lv.SubItems[6].Text = grpitem;

                                decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                                decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                                decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());
                                decimal Tot = UP * Qty * xrt;

                                decimal[,] myarr = new decimal[4, 2];
                                Cal_cmspct_grp(grpitem, Tot, ref myarr);

                                //double rate1 = Tools.Conv_Dbl(pct_grp(grpitem,"2")) / 100;
                                //double amt1 = (double)Tot * rate1;



                                //lv.SubItems[7].Text = Math.Round(Tot, 2).ToString(); TOTSales += Tot;
                                ////   lv.SubItems[10].Text = "";// MainMDI.Curr_FRMT(Irt.ToString());
                                //lv.SubItems[9].Text = Math.Round(amt, 2).ToString();

                                //lv.SubItems[8].Text = pct_grp(grpitem) + " %";// "10 %";
                                //                                              //   lv.SubItems[10].Text = find_QT_date(Oreadr["Project"].ToString());

                                //      bigTOT += amt;
                                //stout += amt + "\n";
                                oldINV = newINV;


                                Save_AGmvmt("", Oreadr["Project"].ToString(), Oreadr["Invoice"].ToString(), Oreadr["Customer"].ToString(), CustPO, ag, Oreadr["StockDescription"].ToString(), grpitem,
                                    Tot.ToString(), Oreadr["SalesOrder"].ToString(), Oreadr["SalesOrderLine"].ToString(), Oreadr["DateLastInvPrt"].ToString(), Oreadr["Salesperson"].ToString(),
                                    Oreadr["Name"].ToString(), ag, myarr[0, 0].ToString(), myarr[0, 1].ToString(), ag, myarr[1, 0].ToString(), myarr[1, 1].ToString(), ag, myarr[2, 0].ToString(), myarr[2, 1].ToString(), ag, myarr[3, 0].ToString(), myarr[3, 1].ToString());
                                nb++;
                            }
                        }

                    }
                    if (oldINV != "") SaveOKinvoice(oldINV); //if (oldINV != newINV && oldINV != "")
                    retrnMsg = "IMPORT Done.......";
                }
                catch (Exception ex)
                {
                    return "Failed to import Agencies CMS......";//...ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL;
                }


                finally
                {
                    OConn.Close();
                    if (Oreadr != null) Oreadr.Close();
                }



            }

            return retrnMsg;

        }

        string Import_AG_CMS_OLD(string _mm, string _yyyy, ref int nb)
        {


            nb = 0;
            string retrnMsg = "ERROR CMS Period.....";
            int MM = (int)Tools.Conv_Dbl(_mm), YYYY = (int)Tools.Conv_Dbl(_yyyy);
            //CMS_period_MMYYYY(ref MM, ref YYYY);

            if (MM > -1 && YYYY > -1)
            {
                double bigTOT = 0;
                decimal TOTSales = 0;



                SqlConnection OConn = null;
                SqlCommand Ocmd = null;
                SqlDataReader Oreadr = null;
                OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

                //[S03],[S05],[S08],

                string stSQL = " SELECT SalSalesperson.Salesperson, SalSalesperson.Name, u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Project, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Currency, " +
                               "        u_SalCommissionsPrimax.Branch,u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.SalesOrder, u_SalCommissionsPrimax.SalesOrderLine, u_SalCommissionsPrimax.StockCode,         u_SalCommissionsPrimax.StockDescription, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, " +
                               "        u_SalCommissionsPrimax.BackOrderQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.ExchangeRate, u_SalCommissionsPrimax.PriceCAD, u_SalCommissionsPrimax.ProductClass, u_SalCommissionsPrimax.CommissionSales1, (cast ([CommissionAmt1] AS decimal)) AS CommissionAmt1,  u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2,   " +
                               "        u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.Salesperson3, u_SalCommissionsPrimax.CommissionSales3, u_SalCommissionsPrimax.CommissionAmt3, u_SalCommissionsPrimax.Salesperson4, u_SalCommissionsPrimax.CommissionSales4, u_SalCommissionsPrimax.Rate, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.Rate  " +
                               " FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch) AND (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson)  " +
                               " WHERE (SalSalesperson.Salesperson in ('S03','S05','S08')) AND (YEAR (u_SalCommissionsPrimax.DateLastInvPrt) >= " + YYYY + ") AND (month (u_SalCommissionsPrimax.DateLastInvPrt) >= " + MM + ")  and (LOWER([Project]) not like '%cigentec%')    " +
                               " ORDER BY u_SalCommissionsPrimax.Invoice";


                //    string stout = "";
                //   ed_LVallInvoices.SendToBack();
                //  ed_lvITM.Items.Clear();
                try
                {

                    OConn.Open();
                    Ocmd = OConn.CreateCommand();
                    Ocmd.CommandText = stSQL;
                    Oreadr = Ocmd.ExecuteReader();
                    string oldINV = "", newINV = "";
                    while (Oreadr.Read())
                    {


                        if (!OKInvoice(Oreadr["Invoice"].ToString()))
                        {


                            string cust_SPcode = Oreadr["Customer"].ToString(), slsP = "", ag = "";
                            int pos = cust_SPcode.IndexOf("-");
                            if (pos > 6) cust_SPcode = cust_SPcode.Substring(0, pos - 1);
                            //string stt = "  SELECT distinct  ISNULL( SalSalesperson.Name,'????') as slsp , ISNULL( SalSalesperson_1.Name,'????') AS ag " +
                            //             "  FROM            v_PGCustomerXRef INNER JOIN SalSalesperson ON v_PGCustomerXRef.Branch = SalSalesperson.Branch AND v_PGCustomerXRef.Salesperson = SalSalesperson.Salesperson LEFT OUTER JOIN " +
                            //             "                  SalSalesperson AS SalSalesperson_1 ON v_PGCustomerXRef.Salesperson1 = SalSalesperson_1.Salesperson WHERE v_PGCustomerXRef.Customer='" + cust_SPcode + "'";
                            string stt = "  SELECT distinct  ISNULL( SalSalesperson.Name,'????') as slsp , ISNULL( SalSalesperson_1.Salesperson,'????') AS ag, ISNULL( SalSalesperson_1.Name,'????') AS agname  " +
                                         "  FROM            v_PGCustomerXRef INNER JOIN SalSalesperson ON v_PGCustomerXRef.Branch = SalSalesperson.Branch AND v_PGCustomerXRef.Salesperson = SalSalesperson.Salesperson LEFT OUTER JOIN " +
                                         "                  SalSalesperson AS SalSalesperson_1 ON v_PGCustomerXRef.Salesperson1 = SalSalesperson_1.Salesperson WHERE v_PGCustomerXRef.Customer='" + cust_SPcode + "'";

                            string agName = "";
                            MainMDI.Find_2_Field_PSA(stt, ref slsP, ref ag, ref agName, "S");

                            if (ag != "????" && Tools.Conv_Dbl(Oreadr["Price"].ToString()) > 0)
                            {
                                ag = ag + " - " + agName;
                                newINV = Oreadr["Invoice"].ToString();
                                if (oldINV != newINV && oldINV != "") SaveOKinvoice(oldINV);

                                //  ListViewItem lv = ed_lvITM.Items.Add(""); for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");

                                //lv.SubItems[0].Text = Oreadr["Project"].ToString();
                                //lv.SubItems[1].Text = Oreadr["Invoice"].ToString();
                                //lv.SubItems[2].Text = Oreadr["Customer"].ToString();

                                string msgERR = "";
                                string CustPO = MainMDI.Find_One_Field_SYSPRO("select CustomerPoNumber from [dbo].[SorMasterRep]   where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "'", ref msgERR);
                                //lv.SubItems[3].Text = CustPO;// MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");

                                //lv.SubItems[4].Text = ag;
                                //lv.SubItems[5].Text = Oreadr["StockDescription"].ToString();

                                string grpitem = MainMDI.Find_One_Field_SYSPRO("select UserDef from     dbo.SorDetailRep    where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "' and SalesOrderLine='" + Oreadr["SalesOrderLine"].ToString() + "'", ref msgERR);

                                grpitem = (grpitem.TrimEnd() == "") ? "A" : grpitem.TrimEnd();
                                //lv.SubItems[6].Text = grpitem;

                                decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                                decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                                decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());
                                decimal Tot = UP * Qty * xrt;

                                decimal[,] myarr = new decimal[4, 2];
                                Cal_cmspct_grp(grpitem, Tot, ref myarr);

                                //double rate1 = Tools.Conv_Dbl(pct_grp(grpitem,"2")) / 100;
                                //double amt1 = (double)Tot * rate1;



                                //lv.SubItems[7].Text = Math.Round(Tot, 2).ToString(); TOTSales += Tot;
                                ////   lv.SubItems[10].Text = "";// MainMDI.Curr_FRMT(Irt.ToString());
                                //lv.SubItems[9].Text = Math.Round(amt, 2).ToString();

                                //lv.SubItems[8].Text = pct_grp(grpitem) + " %";// "10 %";
                                //                                              //   lv.SubItems[10].Text = find_QT_date(Oreadr["Project"].ToString());

                                //      bigTOT += amt;
                                //stout += amt + "\n";
                                oldINV = newINV;


                                Save_AGmvmt("", Oreadr["Project"].ToString(), Oreadr["Invoice"].ToString(), Oreadr["Customer"].ToString(), CustPO, ag, Oreadr["StockDescription"].ToString(), grpitem,
                                    Tot.ToString(), Oreadr["SalesOrder"].ToString(), Oreadr["SalesOrderLine"].ToString(), Oreadr["DateLastInvPrt"].ToString(), Oreadr["Salesperson"].ToString(),
                                    Oreadr["Name"].ToString(), ag, myarr[0, 0].ToString(), myarr[0, 1].ToString(), ag, myarr[1, 0].ToString(), myarr[1, 1].ToString(), ag, myarr[2, 0].ToString(), myarr[2, 1].ToString(), ag, myarr[3, 0].ToString(), myarr[3, 1].ToString());
                                nb++;
                            }
                        }

                    }
                    if (oldINV != "") SaveOKinvoice(oldINV); //if (oldINV != newINV && oldINV != "")
                    retrnMsg = "IMPORT Done......";
                }
                catch (Exception ex)
                {
                    return "Failed to import Agencies CMS......";//...ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL;
                }


                finally
                {
                    OConn.Close();
                    if (Oreadr != null) Oreadr.Close();
                }



            }

            return retrnMsg;

        }


        //==================================


        string Import_AG_CMS(ref int nb)
        {


            nb = 0;
            string retrnMsg = "ERROR CMS Period.....";
            int MM = -1, YYYY = -1;
            CMS_period_MMYYYY(ref MM,ref YYYY);

            if (MM > -1 && YYYY > -1)
            {
                double bigTOT = 0;
                decimal TOTSales = 0;


           
                SqlConnection OConn = null;
                SqlCommand Ocmd = null;
                SqlDataReader Oreadr = null;
                OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

                //[S03],[S05],[S08],

                string stSQL = " SELECT SalSalesperson.Salesperson, SalSalesperson.Name, u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Project, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Currency, " +
                               "        u_SalCommissionsPrimax.Branch,u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.SalesOrder, u_SalCommissionsPrimax.SalesOrderLine, u_SalCommissionsPrimax.StockCode,         u_SalCommissionsPrimax.StockDescription, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, " +
                               "        u_SalCommissionsPrimax.BackOrderQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.ExchangeRate, u_SalCommissionsPrimax.PriceCAD, u_SalCommissionsPrimax.ProductClass, u_SalCommissionsPrimax.CommissionSales1, (cast ([CommissionAmt1] AS decimal)) AS CommissionAmt1,  u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2,   " +
                               "        u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.Salesperson3, u_SalCommissionsPrimax.CommissionSales3, u_SalCommissionsPrimax.CommissionAmt3, u_SalCommissionsPrimax.Salesperson4, u_SalCommissionsPrimax.CommissionSales4, u_SalCommissionsPrimax.Rate, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.Rate  " +
                               " FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch) AND (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson)  " +
                               " WHERE (SalSalesperson.Salesperson in ('S03','S05','S08')) AND (YEAR (u_SalCommissionsPrimax.DateLastInvPrt) = " + YYYY + ") AND (month (u_SalCommissionsPrimax.DateLastInvPrt)= " + MM + ")  and (LOWER([Project]) not like '%cigentec%')    " +
                               " ORDER BY u_SalCommissionsPrimax.Invoice";


                //    string stout = "";
                //   ed_LVallInvoices.SendToBack();
                //  ed_lvITM.Items.Clear();
                try
                {

                    OConn.Open();
                    Ocmd = OConn.CreateCommand();
                    Ocmd.CommandText = stSQL;
                    Oreadr = Ocmd.ExecuteReader();
                    string oldINV = "", newINV = "";
                    while (Oreadr.Read())
                    {


                        if (!OKInvoice(Oreadr["Invoice"].ToString()))
                        {


                            string cust_SPcode = Oreadr["Customer"].ToString(), slsP = "", ag = "";
                            int pos = cust_SPcode.IndexOf("-");
                            if (pos > 6) cust_SPcode = cust_SPcode.Substring(0, pos - 1);
                            string stt = "  SELECT distinct  ISNULL( SalSalesperson.Name,'????') as slsp , ISNULL( SalSalesperson_1.Salesperson,'????') AS ag, ISNULL( SalSalesperson_1.Name,'????') AS agname  " +
                                         "  FROM            v_PGCustomerXRef INNER JOIN SalSalesperson ON v_PGCustomerXRef.Branch = SalSalesperson.Branch AND v_PGCustomerXRef.Salesperson = SalSalesperson.Salesperson LEFT OUTER JOIN " +
                                         "                  SalSalesperson AS SalSalesperson_1 ON v_PGCustomerXRef.Salesperson1 = SalSalesperson_1.Salesperson WHERE v_PGCustomerXRef.Customer='" + cust_SPcode + "'";

                            string agName = "";
                            MainMDI.Find_2_Field_PSA(stt, ref slsP, ref ag,ref agName, "S");

                            if (ag != "????" && Tools.Conv_Dbl(Oreadr["Price"].ToString()) > 0)
                            {
                                ag = ag + " - " + agName;
                                newINV = Oreadr["Invoice"].ToString();
                                if (oldINV != newINV && oldINV != "") SaveOKinvoice(oldINV);
                                
                                string msgERR = "";
                                string CustPO = MainMDI.Find_One_Field_SYSPRO("select CustomerPoNumber from [dbo].[SorMasterRep]   where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "'", ref msgERR);
          
                                string grpitem = MainMDI.Find_One_Field_SYSPRO("select UserDef from     dbo.SorDetailRep    where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "' and SalesOrderLine='" + Oreadr["SalesOrderLine"].ToString() + "'", ref msgERR);

                                grpitem = (grpitem.TrimEnd() == "") ? "A" : grpitem.TrimEnd();
                                //lv.SubItems[6].Text = grpitem;

                                decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                                decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                                decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());
                                decimal Tot = UP * Qty * xrt;

                                decimal[,] myarr = new decimal[4, 2];
                                Cal_cmspct_grp(grpitem, Tot, ref myarr);

                                oldINV = newINV;
                              

                                Save_AGmvmt("", Oreadr["Project"].ToString(), Oreadr["Invoice"].ToString(), Oreadr["Customer"].ToString(), CustPO, ag, Oreadr["StockDescription"].ToString(), grpitem,
                                    Tot.ToString(), Oreadr["SalesOrder"].ToString(), Oreadr["SalesOrderLine"].ToString(), Oreadr["DateLastInvPrt"].ToString(), Oreadr["Salesperson"].ToString(),
                                    Oreadr["Name"].ToString(),ag,myarr[0,0].ToString(), myarr[0, 1].ToString(),ag, myarr[1, 0].ToString(), myarr[1, 1].ToString(),ag, myarr[2, 0].ToString(), myarr[2, 1].ToString(),ag, myarr[3, 0].ToString(), myarr[3, 1].ToString());
                                nb++;
                            }
                        }

                    }
                    if (oldINV != "") SaveOKinvoice(oldINV); //if (oldINV != newINV && oldINV != "")
                    retrnMsg = "IMPORT Done.......";
                }
                catch (Exception ex)
                {
                    return "Failed to import Agencies CMS......";//...ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL;
                }


                finally
                {
                    OConn.Close();
                    if (Oreadr != null) Oreadr.Close();
                }

            }

            return retrnMsg;

        }


        string Import_AG_CMS(string _mm, string _yyyy,ref int nb)
        {


            nb = 0;
            string retrnMsg = "ERROR CMS Period.....";
            int MM = (int) Tools.Conv_Dbl(_mm)   , YYYY = (int)Tools.Conv_Dbl(_yyyy);
            //CMS_period_MMYYYY(ref MM, ref YYYY);

            if (MM > -1 && YYYY > -1)
            {
                double bigTOT = 0;
                decimal TOTSales = 0;



                SqlConnection OConn = null;
                SqlCommand Ocmd = null;
                SqlDataReader Oreadr = null;
                OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

                //[S03],[S05],[S08],

                string stSQL = " SELECT SalSalesperson.Salesperson, SalSalesperson.Name, u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Project, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Currency, " +
                               "        u_SalCommissionsPrimax.Branch,u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.SalesOrder, u_SalCommissionsPrimax.SalesOrderLine, u_SalCommissionsPrimax.StockCode,         u_SalCommissionsPrimax.StockDescription, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, " +
                               "        u_SalCommissionsPrimax.BackOrderQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.ExchangeRate, u_SalCommissionsPrimax.PriceCAD, u_SalCommissionsPrimax.ProductClass, u_SalCommissionsPrimax.CommissionSales1, (cast ([CommissionAmt1] AS decimal)) AS CommissionAmt1,  u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2,   " +
                               "        u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.Salesperson3, u_SalCommissionsPrimax.CommissionSales3, u_SalCommissionsPrimax.CommissionAmt3, u_SalCommissionsPrimax.Salesperson4, u_SalCommissionsPrimax.CommissionSales4, u_SalCommissionsPrimax.Rate, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.Rate  " +
                               " FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch) AND (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson)  " +
                               " WHERE (SalSalesperson.Salesperson in ('S03','S05','S08')) AND (YEAR (u_SalCommissionsPrimax.DateLastInvPrt) >= " + YYYY + ") AND (month (u_SalCommissionsPrimax.DateLastInvPrt) >= " + MM + ")  and (LOWER([Project]) not like '%cigentec%')    " +
                               " ORDER BY u_SalCommissionsPrimax.Invoice";


                //    string stout = "";
                //   ed_LVallInvoices.SendToBack();
                //  ed_lvITM.Items.Clear();
                try
                {

                    OConn.Open();
                    Ocmd = OConn.CreateCommand();
                    Ocmd.CommandText = stSQL;
                    Oreadr = Ocmd.ExecuteReader();
                    string oldINV = "", newINV = "";
                    while (Oreadr.Read())
                    {


                        if (!OKInvoice(Oreadr["Invoice"].ToString()))
                        {


                            string cust_SPcode = Oreadr["Customer"].ToString(), slsP = "", ag = "";
                            int pos = cust_SPcode.IndexOf("-");
                            if (pos > 6) cust_SPcode = cust_SPcode.Substring(0, pos - 1);
                            //string stt = "  SELECT distinct  ISNULL( SalSalesperson.Name,'????') as slsp , ISNULL( SalSalesperson_1.Name,'????') AS ag " +
                            //             "  FROM            v_PGCustomerXRef INNER JOIN SalSalesperson ON v_PGCustomerXRef.Branch = SalSalesperson.Branch AND v_PGCustomerXRef.Salesperson = SalSalesperson.Salesperson LEFT OUTER JOIN " +
                            //             "                  SalSalesperson AS SalSalesperson_1 ON v_PGCustomerXRef.Salesperson1 = SalSalesperson_1.Salesperson WHERE v_PGCustomerXRef.Customer='" + cust_SPcode + "'";
                            string stt = "  SELECT distinct  ISNULL( SalSalesperson.Name,'????') as slsp , ISNULL( SalSalesperson_1.Salesperson,'????') AS ag, ISNULL( SalSalesperson_1.Name,'????') AS agname  " +
                                         "  FROM            v_PGCustomerXRef INNER JOIN SalSalesperson ON v_PGCustomerXRef.Branch = SalSalesperson.Branch AND v_PGCustomerXRef.Salesperson = SalSalesperson.Salesperson LEFT OUTER JOIN " +
                                         "                  SalSalesperson AS SalSalesperson_1 ON v_PGCustomerXRef.Salesperson1 = SalSalesperson_1.Salesperson WHERE v_PGCustomerXRef.Customer='" + cust_SPcode + "'";

                            string agName = "";
                            MainMDI.Find_2_Field_PSA(stt, ref slsP, ref ag, ref agName, "S");
                          
                            if (ag != "????" && Tools.Conv_Dbl(Oreadr["Price"].ToString()) > 0)
                            {
                                ag = ag + " - " + agName;
                                newINV = Oreadr["Invoice"].ToString();
                                if (oldINV != newINV && oldINV != "") SaveOKinvoice(oldINV);

                                //  ListViewItem lv = ed_lvITM.Items.Add(""); for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");

                                //lv.SubItems[0].Text = Oreadr["Project"].ToString();
                                //lv.SubItems[1].Text = Oreadr["Invoice"].ToString();
                                //lv.SubItems[2].Text = Oreadr["Customer"].ToString();

                                string msgERR = "";
                                string CustPO = MainMDI.Find_One_Field_SYSPRO("select CustomerPoNumber from [dbo].[SorMasterRep]   where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "'", ref msgERR);
                                //lv.SubItems[3].Text = CustPO;// MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");

                                //lv.SubItems[4].Text = ag;
                                //lv.SubItems[5].Text = Oreadr["StockDescription"].ToString();

                                string grpitem = MainMDI.Find_One_Field_SYSPRO("select UserDef from     dbo.SorDetailRep    where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "' and SalesOrderLine='" + Oreadr["SalesOrderLine"].ToString() + "'", ref msgERR);

                                grpitem = (grpitem.TrimEnd() == "") ? "A" : grpitem.TrimEnd();
                                //lv.SubItems[6].Text = grpitem;

                                decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                                decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                                decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());
                                decimal Tot = UP * Qty * xrt;

                                decimal[,] myarr = new decimal[4, 2];
                                Cal_cmspct_grp(grpitem, Tot, ref myarr);

                                //double rate1 = Tools.Conv_Dbl(pct_grp(grpitem,"2")) / 100;
                                //double amt1 = (double)Tot * rate1;



                                //lv.SubItems[7].Text = Math.Round(Tot, 2).ToString(); TOTSales += Tot;
                                ////   lv.SubItems[10].Text = "";// MainMDI.Curr_FRMT(Irt.ToString());
                                //lv.SubItems[9].Text = Math.Round(amt, 2).ToString();

                                //lv.SubItems[8].Text = pct_grp(grpitem) + " %";// "10 %";
                                //                                              //   lv.SubItems[10].Text = find_QT_date(Oreadr["Project"].ToString());

                                //      bigTOT += amt;
                                //stout += amt + "\n";
                                oldINV = newINV;


                                Save_AGmvmt("", Oreadr["Project"].ToString(), Oreadr["Invoice"].ToString(), Oreadr["Customer"].ToString(), CustPO, ag, Oreadr["StockDescription"].ToString(), grpitem,
                                    Tot.ToString(), Oreadr["SalesOrder"].ToString(), Oreadr["SalesOrderLine"].ToString(), Oreadr["DateLastInvPrt"].ToString(), Oreadr["Salesperson"].ToString(),
                                    Oreadr["Name"].ToString(), ag, myarr[0, 0].ToString(), myarr[0, 1].ToString(), ag, myarr[1, 0].ToString(), myarr[1, 1].ToString(), ag, myarr[2, 0].ToString(), myarr[2, 1].ToString(), ag, myarr[3, 0].ToString(), myarr[3, 1].ToString());
                                nb++;
                            }
                        }

                    }
                    if (oldINV != "") SaveOKinvoice(oldINV); //if (oldINV != newINV && oldINV != "")
                    retrnMsg = "IMPORT Done......";
                }
                catch (Exception ex)
                {
                    return "Failed to import Agencies CMS......";//...ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL;
                }


                finally
                {
                    OConn.Close();
                    if (Oreadr != null) Oreadr.Close();
                }



            }

            return retrnMsg;

        }



        string Import_INV(string _myInv,string agcode)
        {


         
            string retrnMsg = "ERROR CMS Period.....";
            int MM = -1, YYYY = -1;
            CMS_period_MMYYYY(ref MM, ref YYYY);

            if (MM > -1 && YYYY > -1)
            {
                double bigTOT = 0;
                decimal TOTSales = 0;



                SqlConnection OConn = null;
                SqlCommand Ocmd = null;
                SqlDataReader Oreadr = null;
                OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

                //[S03],[S05],[S08],

                string stSQL = "  SELECT SalSalesperson.Salesperson, SalSalesperson.Name, u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Project, " +
                       "  u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Currency, u_SalCommissionsPrimax.Branch, u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.SalesOrder, " +
                       "   u_SalCommissionsPrimax.SalesOrderLine, u_SalCommissionsPrimax.StockCode, u_SalCommissionsPrimax.StockDescription, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, " +
                      "    u_SalCommissionsPrimax.BackOrderQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.ExchangeRate, u_SalCommissionsPrimax.PriceCAD, u_SalCommissionsPrimax.ProductClass, " +
                      "    u_SalCommissionsPrimax.CommissionSales1, CAST(u_SalCommissionsPrimax.CommissionAmt1 AS decimal) AS CommissionAmt1, u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2, " +
                      "    u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.Salesperson3, u_SalCommissionsPrimax.CommissionSales3, u_SalCommissionsPrimax.CommissionAmt3, u_SalCommissionsPrimax.Salesperson4, " +
                      "    u_SalCommissionsPrimax.CommissionSales4, u_SalCommissionsPrimax.Rate, u_SalCommissionsPrimax.OrderQty AS Expr1, u_SalCommissionsPrimax.ShipQty AS Expr2, u_SalCommissionsPrimax.Rate AS Expr3 " +
                      "    FROM            u_SalCommissionsPrimax INNER JOIN  SalSalesperson ON u_SalCommissionsPrimax.Branch = SalSalesperson.Branch AND u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson " +
                      "    WHERE u_SalCommissionsPrimax.Invoice = '" + _myInv + "' ";

                //    string stout = "";
                //   ed_LVallInvoices.SendToBack();
                //  ed_lvITM.Items.Clear();
                try
                {

                    OConn.Open();
                    Ocmd = OConn.CreateCommand();
                    Ocmd.CommandText = stSQL;
                    Oreadr = Ocmd.ExecuteReader();
                    string oldINV = "", newINV = "";
                    while (Oreadr.Read())
                    {


                        if (!OKInvoice(Oreadr["Invoice"].ToString()))
                        {


                            string cust_SPcode = Oreadr["Customer"].ToString(), slsP = "", ag = "";
                            int pos = cust_SPcode.IndexOf("-");
                            if (pos > 6) cust_SPcode = cust_SPcode.Substring(0, pos - 1);


                            //string stt = "  SELECT distinct  ISNULL( SalSalesperson.Name,'????') as slsp , ISNULL( SalSalesperson_1.Salesperson,'????') AS ag, ISNULL( SalSalesperson_1.Name,'????') AS agname  " +
                            //             "  FROM            v_PGCustomerXRef INNER JOIN SalSalesperson ON v_PGCustomerXRef.Branch = SalSalesperson.Branch AND v_PGCustomerXRef.Salesperson = SalSalesperson.Salesperson LEFT OUTER JOIN " +
                            //             "                  SalSalesperson AS SalSalesperson_1 ON v_PGCustomerXRef.Salesperson1 = SalSalesperson_1.Salesperson WHERE v_PGCustomerXRef.Customer='" + cust_SPcode + "'";

                            //string agName = "";
                            //MainMDI.Find_2_Field_PSA(stt, ref slsP, ref ag, ref agName, "S");
                            ag = agcode;
                            if (ag != "????" && Tools.Conv_Dbl(Oreadr["Price"].ToString()) > 0)
                            {
                                //ag = ag + " - " + agName;
                                newINV = Oreadr["Invoice"].ToString();
                                if (oldINV != newINV && oldINV != "") SaveOKinvoice(oldINV);

                                string msgERR = "";
                                string CustPO = MainMDI.Find_One_Field_SYSPRO("select CustomerPoNumber from [dbo].[SorMasterRep]   where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "'", ref msgERR);

                                string grpitem = MainMDI.Find_One_Field_SYSPRO("select UserDef from     dbo.SorDetailRep    where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "' and SalesOrderLine='" + Oreadr["SalesOrderLine"].ToString() + "'", ref msgERR);

                                grpitem = (grpitem.TrimEnd() == "") ? "A" : grpitem.TrimEnd();
                                //lv.SubItems[6].Text = grpitem;

                                decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                                decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                                decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());
                                decimal Tot = UP * Qty * xrt;

                                decimal[,] myarr = new decimal[4, 2];
                                Cal_cmspct_grp(grpitem, Tot, ref myarr);

                                oldINV = newINV;


                                Save_AGmvmt("", Oreadr["Project"].ToString(), Oreadr["Invoice"].ToString(), Oreadr["Customer"].ToString(), CustPO, ag, Oreadr["StockDescription"].ToString(), grpitem,
                                    Tot.ToString(), Oreadr["SalesOrder"].ToString(), Oreadr["SalesOrderLine"].ToString(), Oreadr["DateLastInvPrt"].ToString(), Oreadr["Salesperson"].ToString(),
                                    Oreadr["Name"].ToString(), ag, myarr[0, 0].ToString(), myarr[0, 1].ToString(), ag, myarr[1, 0].ToString(), myarr[1, 1].ToString(), ag, myarr[2, 0].ToString(), myarr[2, 1].ToString(), ag, myarr[3, 0].ToString(), myarr[3, 1].ToString());
                              
                            }
                        }

                    }
                    if (oldINV != "") SaveOKinvoice(oldINV); //if (oldINV != newINV && oldINV != "")
                    retrnMsg = "";
                }
                catch (Exception ex)
                {
                    return "Failed to import Invoice: "+ _myInv +" ..... expt: "+ex.Message;//...ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL;
                }


                finally
                {
                    OConn.Close();
                    if (Oreadr != null) Oreadr.Close();
                }

            }

            return retrnMsg;

        }


        bool OKInvoice(string Invoice)

        {
            return MainMDI.Find_One_Field("select inv_lid from U_agCMSokInvoice where Invoice_OK='" + Invoice + "'") != MainMDI.VIDE;


        }

        void SaveOKinvoice(string inv)
        {
            if (!OKInvoice(inv))
            {
                string stSql = " INSERT INTO U_agCMSokInvoice ([Invoice_OK] ) VALUES ('" + inv + "')";

                MainMDI.Exec_SQL_JFS(stSql, " AgcmsOKinvoice =" + inv + "  ","???");
            }


        }


        string Save_AGmvmt(string _lid, string _rid, string _Inv, string _customR, string _po, string _ag, string _itm, string _grp, string _price, string _SOnbr, string _SOline, string _Inv_Date, string _SP, string _SPName, 
                          string d_AG, string _cmsrate1, string _cmsamnt1, string i_AG, string _cmsrate2, string _cmsamnt2, string e_AG, string _cmsrate3, string _cmsamnt3, string p_AG, string _cmsrate4, string _cmsamnt4)
        {
            string retMsg = "OK";
            string tsk = "all";//tsk: all,des,inf,eng,po
            if (_lid == "")
            {
                string stSql = " INSERT INTO U_agCMSmvmt ([RID],[Invoice],[customerNM], [PO], [agencyNM] , [item] , [Price] , [grp] , [SalesOrdr] , [SO_line], [Inv_date] ," +
                               "            [SP] , [SPname] ,[desti_AG], [desti_rt] , [desti_amnt],[inf_AG], [inf_rt] , [inf_amnt] ,[eng_AG], [eng_rt] , [eng_amnt] , [po_AG],[po_rt] , [po_amnt]   ) " +
               " VALUES ('" + _rid.TrimEnd() +
              "', '" + _Inv +
              "', '" + _customR.Replace("'", "''") +
              "', '" + _po.Replace("'", "''") +
              "', '" + _ag.Replace("'", "''") +
              "', '" + _itm.Replace("'", "''") +
              "', " + _price +
              ", '" + _grp.TrimEnd() +
              "', '" + _SOnbr +
              "', '" + _SOline +
              "', " +MainMDI.SSV_Bigdate(_Inv_Date) +
              ", '" + _SP +
              "', '" + _SPName +
              "', '" + d_AG +
              "', " + _cmsrate1 +
              ", " + _cmsamnt1 +
              ", '" + i_AG +
              "', " + _cmsrate2 +
              ", " + _cmsamnt2 +
              ", '" + i_AG +
              "', " + _cmsrate3 +
              ", " + _cmsamnt3 +
              ", '" + p_AG +
              "', " + _cmsrate4 +
              ", " + _cmsamnt4 +
               ")";

                MainMDI.Exec_SQL_JFS(stSql, "save AG. CMS mvmt......","");
                
            }
            else
            {
                retMsg = "ERROR importing Agencies CMS........bad LID: " + _lid;
                //if (txEVname.Text.Length > 2)
                //{
                //    string stSql = " UPDATE XCNG_Events SET [Event_Name]='" + txEVname.Text.Replace("'", "''") + "',  [Ev_Start]=" + MainMDI.SSV_date(dateTimePicker1.Value.ToShortDateString()) +
                //          ", [Ev_End]=" + MainMDI.SSV_date(dateTimePicker2.Value.ToShortDateString()) + " where EventLID=" + lEventLID.Text;
                //    MainMDI.Exec_SQL_JFS(stSql, "Events");
                //}
            }

            return retMsg;

        }

        
        public JsonResult List_CMS_INV(string SP)
        {
            Orig_PSM_FDBEntities2 myPGCdb = new Orig_PSM_FDBEntities2();
          
            myPGCdb.Configuration.ProxyCreationEnabled = false;
      
            return Json(myPGCdb.V_u_agcmsmvmt.Where(p => p.SP == SP).ToList(), JsonRequestBehavior.AllowGet);


        }

        public JsonResult List_CMS_INV(Int32 MM,Int32 YYYY )
        {
            


           Orig_PSM_FDBEntities2 myPGCdb = new Orig_PSM_FDBEntities2();
            
            myPGCdb.Configuration.ProxyCreationEnabled = false;

            return Json(myPGCdb.V_u_agcmsmvmt.Where(p =>p.MM == MM && p.YYYY==YYYY), JsonRequestBehavior.AllowGet);


        }



        public ActionResult DispINVCMSold(string _SP)
        {

         //   System.Threading.Thread.Sleep(2000);
            var listinvcms = new List<U_agCMSmvmt>();

            using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
            {
                //string UN = HttpContext.Session["usr"].ToString();

             if (_SP == "Select") listinvcms = dc.U_agCMSmvmt.ToList();
             else    listinvcms = dc.U_agCMSmvmt.Where(a => a.SP == _SP).ToList();

            }
            //  RedirectToAction("DispSTEPS", "DispSteps");
            //  Response.AddHeader("Refresh", "1");


            //     return View("../Views/AGCMS/DispINVCMS.cshtml", listinvcms);
            //  return View("~/Views/AGCMS/DispINVCMS.cshtml", listinvcms);
            return View(listinvcms);
        }


        public ActionResult DispINVCMS(string _SP,string _MM,string _YYYY)
        {

            //   System.Threading.Thread.Sleep(2000);
            var listinvcms = new List<V_u_agcmsmvmt>();
            if (_SP.Length > 3) _SP = _SP.Substring(0, 3);
            int myMM = (_MM == null) ? 0 : (Int32)Tools.Conv_Dbl(_MM);
            int myYYYY = (_YYYY == null) ? 0 : (Int32)Tools.Conv_Dbl(_YYYY);

            using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
            {
                //string UN = HttpContext.Session["usr"].ToString();

                if (_SP == "Select" && myMM == 0 && myYYYY == 0) listinvcms = dc.V_u_agcmsmvmt.OrderBy(a => a.Invoice).ToList();
                else
                {
                    if (_SP != "Select" && myMM > 0 && myYYYY > 0) listinvcms = dc.V_u_agcmsmvmt.Where(a => a.SP == _SP && a.MM == myMM && a.YYYY == myYYYY).OrderBy(a => a.Invoice).ToList();
                    else
                    {
                        if (_SP == "Select") { if (myMM > 0 && myYYYY > 0) listinvcms = dc.V_u_agcmsmvmt.Where(a => a.MM == myMM && a.YYYY == myYYYY).OrderBy(a => a.Invoice).ToList(); }
                        else if (_SP != "Select") listinvcms = dc.V_u_agcmsmvmt.Where(a => a.SP == _SP).OrderBy(a => a.Invoice).ToList();
                    }

                }
            }
            //  RedirectToAction("DispSTEPS", "DispSteps");
            //  Response.AddHeader("Refresh", "1");


            //     return View("../Views/AGCMS/DispINVCMS.cshtml", listinvcms);
            //  return View("~/Views/AGCMS/DispINVCMS.cshtml", listinvcms);
            return View(listinvcms);
        }


        public ActionResult DispCMS_lstOLD_lnq(string _AG, string _MM, string _YYYY)
        {



            //   System.Threading.Thread.Sleep(2000);
            var listinvcms_VNTL = new List<V_U_agcmsmvt_VNTL>();

            int myMM = (_MM == null) ? 0 : (Int32)Tools.Conv_Dbl(_MM);
            int myYYYY = (_YYYY == null) ? 0 : (Int32)Tools.Conv_Dbl(_YYYY);
            bool dateok = myMM > 0 && myYYYY > 0;
            if (_AG != "Select" || dateok)
            {
                using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
                {
                    //string UN = HttpContext.Session["usr"].ToString();
                   //   listinvcms_VNTL = dc.V_U_agcmsmvt_VNTL.Where(a => a.vAG == _AG && a.MM == myMM && a.YYYY == myYYYY).ToList();
                    if (_AG != "Select" && dateok) listinvcms_VNTL = dc.V_U_agcmsmvt_VNTL.Where(a => a.vAG == _AG && a.MM == myMM && a.YYYY == myYYYY ).OrderBy(a => a.Invoice).ThenBy(a => a.item).ThenBy(a => a.Ttype).ToList();
                    else if (_AG != "Select") listinvcms_VNTL = dc.V_U_agcmsmvt_VNTL.Where(a => a.vAG == _AG).OrderBy(a => a.Invoice).ThenBy(a => a.item).ThenBy(a => a.Ttype).ToList(); 
                    else listinvcms_VNTL = dc.V_U_agcmsmvt_VNTL.Where(a => a.MM == myMM && a.YYYY == myYYYY).OrderBy(a => a.agencyNM).ThenBy(a => a.Invoice).ThenBy(a => a.item).ThenBy(a => a.Ttype).ToList();

                }
                //  RedirectToAction("DispSTEPS", "DispSteps");
                //  Response.AddHeader("Refresh", "1");


                //     return View("../Views/AGCMS/DispINVCMS.cshtml", listinvcms);
                //  return View("~/Views/AGCMS/DispINVCMS.cshtml", listinvcms);
            }
            return View(listinvcms_VNTL);
        }

        public ActionResult DispCMS_lst(string _AG, string _MM, string _YYYY)
        {
            //   and SP+' - ' + SPname = 'S05 - Yves Lavoie'


            if (ValidUser())
            {
                List<V_U_agcmsmvt_VNTL> mylist_V = new List<V_U_agcmsmvt_VNTL>();
                string retrnMsg = "";
                find_commis_agency(_AG, _MM, _YYYY, ref mylist_V, ref retrnMsg);

                return View(mylist_V);
            }
            else
            {
                RedirectToAction("Login", "AGCMS");
                return Json(null);
            }


        }

        public ActionResult DispCMS_lst_tots(string _AG, string _MM, string _YYYY)
        {
            //   and SP+' - ' + SPname = 'S05 - Yves Lavoie'


            if (ValidUser())
            {
                List<V_U_agcmsmvt_VNTL> mylist_V = new List<V_U_agcmsmvt_VNTL>();
                string retrnMsg = "",mySql="";
                find_commis_agency_tots(_AG, _MM, _YYYY, ref mylist_V, ref retrnMsg);
               // ViewBag.mySql = mySql;
                return View(mylist_V);
            }
            else
            {
                RedirectToAction("Login", "AGCMS");
                return Json(null);
            }


        }


        void find_commis_agency(string _AG, string _MM, string _YYYY, ref List<V_U_agcmsmvt_VNTL> listinvcms_VNTL, ref string retrnMsg)
        {

            string condiSP = "";

            if (HttpContext.Session["salesP"].ToString() != "ALL")
            {
                string spname = HttpContext.Session["salesP"].ToString() + " - " + HttpContext.Session["salesPname"].ToString();
                condiSP = "  and SP+' - ' + SPname = '" + spname + "'";

            }

            if (_AG != "Select")
            {
                string tt = "";
                string agname = MainMDI.Find_One_Field_SYSPRO(" SELECT  Salesperson +' - ' + Name FROM  dbo.SalSalesperson where SUBSTRING(Salesperson, 1, 1) = 'A' and(Branch = 'U1' OR Branch = 'C1') and Salesperson ='" + _AG + "' order by Name ", ref tt);
                if (agname != MainMDI.VIDE) _AG = agname;
            }
            retrnMsg = "";
            //    V_U_agcmsmvt_VNTL myInv_NOAG = new V_U_agcmsmvt_VNTL();
         

            int myMM = (_MM == null) ? 0 : (Int32)Tools.Conv_Dbl(_MM);
            int myYYYY = (_YYYY == null) ? 0 : (Int32)Tools.Conv_Dbl(_YYYY);
            bool dateok = myMM > 0 && myYYYY > 0;
            if (_AG != "Select" || dateok)
            {

                SqlConnection OConn = null;
                SqlCommand Ocmd = null;
                SqlDataReader Oreadr = null;
                OConn = new SqlConnection(MainMDI.M_stCon);


                string StSql = (_AG == "Select") ? " SELECT   agencyNM,Ttype, Invoice,item,grp,vrt, vCMSamnt FROM V_U_agcmsmvt_VNTL WHERE MM = "+_MM + " AND YYYY = " + _YYYY + "  " + condiSP + " order by Invoice, agencyNM, item,SO_line, Ttype  " : " SELECT   agencyNM,Ttype, Invoice,item,grp,vrt, vCMSamnt FROM V_U_agcmsmvt_VNTL WHERE MM = " + _MM + " AND YYYY = " + _YYYY + " and agencyNM = '" + _AG + "'" + condiSP + "  order by Invoice, agencyNM, item,SO_line, Ttype  ";

                try
                {

                    OConn.Open();
                    Ocmd = OConn.CreateCommand();
                    Ocmd.CommandText = StSql;
                    Oreadr = Ocmd.ExecuteReader();
                    while (Oreadr.Read())
                    {
                        V_U_agcmsmvt_VNTL myInv_NOAG = new V_U_agcmsmvt_VNTL();
                        myInv_NOAG.agencyNM = Oreadr["agencyNM"].ToString();
                        myInv_NOAG.Ttype = Oreadr["Ttype"].ToString();
                        myInv_NOAG.Invoice = Oreadr["Invoice"].ToString();
                        myInv_NOAG.item = Oreadr["item"].ToString();
                        myInv_NOAG.grp = Oreadr["grp"].ToString();
                        myInv_NOAG.vRT = Decimal.Parse(Oreadr["vRT"].ToString());
                        myInv_NOAG.vCMSamnt = Decimal.Parse(Oreadr["vCMSamnt"].ToString());

                        listinvcms_VNTL.Add(myInv_NOAG);

                    }

                }
                catch (Exception ex)
                {
                    retrnMsg = "Failed to List Invoices without Agencies......";//...ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL;
                }


                finally
                {
                    OConn.Close();
                    if (Oreadr != null) Oreadr.Close();
                }



            }
            else retrnMsg = "Invalid Month/Year.......";


        }


        void find_commis_agency_tots(string _AG, string _MM, string _YYYY, ref List<V_U_agcmsmvt_VNTL> listinvcms_VNTL, ref string retrnMsg)
        {

            string condiSP = "", errmsg = "";
            string tmpfile = " U_CMS_AG_TOT_" +   HttpContext.Session["usr"].ToString();

            if (HttpContext.Session["salesP"].ToString() != "ALL")
            {
                string spname = HttpContext.Session["salesP"].ToString() + " - " + HttpContext.Session["salesPname"].ToString();
                condiSP = "  and SP+' - ' + SPname = '" + spname + "'";

            }

            if (_AG != "Select")
            {
                string tt = "";
                string agname = MainMDI.Find_One_Field_SYSPRO(" SELECT  Salesperson +' - ' + Name FROM  dbo.SalSalesperson where SUBSTRING(Salesperson, 1, 1) = 'A' and(Branch = 'U1' OR Branch = 'C1') and Salesperson ='" + _AG + "' order by Name ", ref tt);
                if (agname != MainMDI.VIDE) _AG = agname;
            }
            retrnMsg = "";
            //    V_U_agcmsmvt_VNTL myInv_NOAG = new V_U_agcmsmvt_VNTL();


            int myMM = (_MM == null) ? 0 : (Int32)Tools.Conv_Dbl(_MM);
            int myYYYY = (_YYYY == null) ? 0 : (Int32)Tools.Conv_Dbl(_YYYY);
            bool dateok = myMM > 0 && myYYYY > 0;
          
            if (_AG != "Select" || dateok)
            {

                SqlConnection OConn = null;
                SqlCommand Ocmd = null;
                SqlDataReader Oreadr = null;
                OConn = new SqlConnection(MainMDI.M_stCon);

               

             //   string StSql = (_AG == "Select") ? " SELECT   agencyNM,Ttype, Invoice,item,grp,vrt, vCMSamnt FROM V_U_agcmsmvt_VNTL WHERE(MM = 10) AND(YYYY = 2018) " + condiSP + " order by Invoice, agencyNM, item,SO_line, Ttype  " : " SELECT   agencyNM,Ttype, Invoice,item,grp,vrt, vCMSamnt FROM V_U_agcmsmvt_VNTL WHERE(MM = 10) AND(YYYY = 2018) and agencyNM = '" + _AG + "'" + condiSP + "  order by Invoice, agencyNM, item,SO_line, Ttype  ";
                string StSql = (_AG == "Select") ? " SELECT     agencyNM, Invoice, SUM(vCMSamnt) AS totcms FROM V_U_agcmsmvt_VNTL WHERE MM = " + _MM + " AND YYYY = " + _YYYY + "  " + condiSP + " GROUP BY agencyNM, Invoice order by agencyNM,Invoice" : " SELECT     agencyNM, Invoice, SUM(vCMSamnt) AS totcms FROM V_U_agcmsmvt_VNTL WHERE MM = " + _MM + " AND YYYY = " + _YYYY + " and agencyNM = '" + _AG + "'" + condiSP + "  GROUP BY agencyNM, Invoice order by agencyNM,Invoice ";
                string stsql_newTBL = (_AG == "Select") ? " SELECT     agencyNM, Invoice, SUM(vCMSamnt) AS totcms into " + tmpfile + " FROM V_U_agcmsmvt_VNTL WHERE MM = " + _MM + " AND YYYY = " + _YYYY + "  " + condiSP + " GROUP BY agencyNM, Invoice order by agencyNM,Invoice" : " SELECT     agencyNM, Invoice, SUM(vCMSamnt) AS totcms into " + tmpfile + " FROM V_U_agcmsmvt_VNTL WHERE MM = " + _MM + " AND YYYY = " + _YYYY + " and agencyNM = '" + _AG + "'" + condiSP + "  GROUP BY agencyNM, Invoice order by agencyNM,Invoice ";


                MainMDI.ExecSql("drop table " + tmpfile, ref errmsg);
                MainMDI.ExecSql(stsql_newTBL, ref errmsg);


                try
                {

                    OConn.Open();
                    Ocmd = OConn.CreateCommand();
                    Ocmd.CommandText = StSql; 
                    Oreadr = Ocmd.ExecuteReader();
                    while (Oreadr.Read())
                    {
                        V_U_agcmsmvt_VNTL myInv_NOAG = new V_U_agcmsmvt_VNTL();
                        myInv_NOAG.agencyNM = Oreadr["agencyNM"].ToString();
                        myInv_NOAG.Invoice = Oreadr["Invoice"].ToString();
                        myInv_NOAG.vCMSamnt = Decimal.Parse(Oreadr["totcms"].ToString());

                        listinvcms_VNTL.Add(myInv_NOAG);

                    }

                }
                catch (Exception ex)
                {
                    retrnMsg = "Failed to List Invoices without Agencies......";//...ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL;
                }


                finally
                {
                    OConn.Close();
                    if (Oreadr != null) Oreadr.Close();
                }



            }
            else retrnMsg = "Invalid Month/Year.......";


        }
        public ActionResult DispCMS_lst_SUM(string _AG, string _MM, string _YYYY)
        {

            string retrnMsg = "";
            V_U_agcmsmvt_VNTL myInv_NOAG = new V_U_agcmsmvt_VNTL();
            var listinvcms_VNTL = new List<V_U_agcmsmvt_VNTL>();

            int myMM = (_MM == null) ? 0 : (Int32)Tools.Conv_Dbl(_MM);
            int myYYYY = (_YYYY == null) ? 0 : (Int32)Tools.Conv_Dbl(_YYYY);
            bool dateok = myMM > 0 && myYYYY > 0;
            if (_AG != "Select" || dateok)
            {

                    SqlConnection OConn = null;
                    SqlCommand Ocmd = null;
                    SqlDataReader Oreadr = null;
                    OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);


                string StSql = " SELECT   agencyNM,Ttype, Invoice,item,Price,grp,vrt, vCMSamnt FROM V_U_agcmsmvt_VNTL " +
                               "  WHERE(MM = 10) AND(YYYY = 2018) and agencyNM = '" + _AG + "'  order by Invoice,agencyNM,item,Ttype ";

                try
                {

                    OConn.Open();
                    Ocmd = OConn.CreateCommand();
                    Ocmd.CommandText = StSql;
                    Oreadr = Ocmd.ExecuteReader();
                    while (Oreadr.Read())
                    {

                        myInv_NOAG.agencyNM = Oreadr["agencyNM"].ToString();
                        myInv_NOAG.Ttype = Oreadr["Ttype"].ToString();
                        myInv_NOAG.Invoice = Oreadr["Invoice"].ToString();
                        myInv_NOAG.item = Oreadr["item"].ToString();
                        myInv_NOAG.Price= Decimal.Parse(Oreadr["Price"].ToString());
                        myInv_NOAG.grp = Oreadr["grp"].ToString();
                        myInv_NOAG.vRT =Decimal.Parse( Oreadr["vRT"].ToString());
                        myInv_NOAG.vCMSamnt = Decimal.Parse(Oreadr["vCMSamnt"].ToString());

                        listinvcms_VNTL.Add(myInv_NOAG);

                    }

                }
                catch (Exception ex)
                {
                    retrnMsg = "Failed to List Invoices without Agencies......";//...ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL;
                }


                finally
                {
                    OConn.Close();
                    if (Oreadr != null) Oreadr.Close();
                }



                }
                else retrnMsg = "Invalid Month/Year.......";


            return View(listinvcms_VNTL);


        }

        public ActionResult DispCMS_lstbyinv(string _INV)
        {



            //   System.Threading.Thread.Sleep(2000);
            var listinvcms_VNTL = new List<V_U_agcmsmvt_VNTL>();
            if (Tools.Conv_Dbl(_INV) > 1000)
            {
                string stinv = MainMDI.A00(_INV, 15);
                using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
                {
                    //string UN = HttpContext.Session["usr"].ToString();

                    if (Tools.Conv_Dbl(_INV) > 0) listinvcms_VNTL = dc.V_U_agcmsmvt_VNTL.Where(a => a.Invoice == stinv).OrderBy(a => a.item).ThenBy(a => a.Ttype).ToList();


                }
                //  RedirectToAction("DispSTEPS", "DispSteps");
                //  Response.AddHeader("Refresh", "1");


                //     return View("../Views/AGCMS/DispINVCMS.cshtml", listinvcms);
                //  return View("~/Views/AGCMS/DispINVCMS.cshtml", listinvcms);
            }
            return View("~/Views/AGCMS/DispCMS_lst.cshtml", listinvcms_VNTL);
        }


        public ActionResult Edit(long _ID)
        {
          
            U_agCMSmvmt listinvcms = new U_agCMSmvmt();
            fill_AGLIST();
            ViewBag.aglist = AGlist;
            using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
            {
                     listinvcms = (dc.U_agCMSmvmt.Where(a => a.agcmsLID == _ID)).SingleOrDefault();

            }
   
            return View(listinvcms);


        }

        public ActionResult Editold(long _ID)
        {
            var listinvcms = new List<U_agCMSmvmt>();

            using (Orig_PSM_FDBEntities2 dc = new Orig_PSM_FDBEntities2())
            {
                //string UN = HttpContext.Session["usr"].ToString();

                //     listinvcms = dc.U_agCMSmvmt.Where(a => a.agcmsLID == Int64.Parse (_ID)).ToList();
                listinvcms = dc.U_agCMSmvmt.Where(a => a.agcmsLID == _ID).ToList();

            }
            //  RedirectToAction("DispSTEPS", "DispSteps");
            //  Response.AddHeader("Refresh", "1");


            //     return View("../Views/AGCMS/DispINVCMS.cshtml", listinvcms);
            //  return View("~/Views/AGCMS/DispINVCMS.cshtml", listinvcms);
            return View(listinvcms);


        }

        private void fill_AGLIST_SPOLD()
        {

                //  string stSql = "SELECT Salesperson,  Name FROM  dbo.SalSalesperson where SUBSTRING (Salesperson,1,1)='A' and Branch ='" + branch + "1' order by Name ";
                string stSql = " SELECT distinct Salesperson,  Name FROM  dbo.SalSalesperson where SUBSTRING(Salesperson, 1, 1) = 'A' and(Branch = 'U1' OR Branch = 'C1') order by Name ";


                   SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    Agency myAG = new Agency();
                    myAG.codeAG = Oreadr[0].ToString();
                    myAG.AGname = Oreadr[1].ToString();
                    AGlist.Add(myAG);
                 }
                OConn.Close();
   
           
           
        }
        private void fill_AGLIST()
        {

            //  string stSql = "SELECT Salesperson,  Name FROM  dbo.SalSalesperson where SUBSTRING (Salesperson,1,1)='A' and Branch ='" + branch + "1' order by Name ";
            string stSql = " SELECT distinct Salesperson,  Name FROM  dbo.SalSalesperson where SUBSTRING(Salesperson, 1, 1) = 'A' and(Branch = 'U1' OR Branch = 'C1') order by Name ";


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                Agency myAG = new Agency();
                myAG.codeAG = Oreadr[0].ToString() + " - " + Oreadr[1].ToString(); 
                myAG.AGname = Oreadr[0].ToString() + " - " + Oreadr[1].ToString();
                AGlist.Add(myAG);
            }
            OConn.Close();



        }


        private void fill_SPLIST_SP(string SPcode)
        {

            //  string stSql = "SELECT Salesperson,  Name FROM  dbo.SalSalesperson where SUBSTRING (Salesperson,1,1)='A' and Branch ='" + branch + "1' order by Name ";

            string stSql =(SPcode=="ALL") ? " SELECT distinct Salesperson,  Name FROM  dbo.SalSalesperson where SUBSTRING(Salesperson, 1, 1) = 'S' and (Branch = 'U1' OR Branch = 'C1') order by Name " : " SELECT distinct Salesperson,  Name FROM  dbo.SalSalesperson where SUBSTRING(Salesperson, 1, 1) = 'S' and (Branch = 'U1' OR Branch = 'C1') and Salesperson ='" + SPcode + "' order by Name ";
            

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                Agency myAG = new Agency();
                myAG.codeAG = Oreadr[0].ToString() + " - " + Oreadr[1].ToString();
                myAG.AGname = Oreadr[0].ToString() + " - " + Oreadr[1].ToString();
                SPlist.Add(myAG);
            }
            OConn.Close();



        }




        public ActionResult DispINV_NOAG_goodold(string _SP, string _MM, string _YYYY)
        {

            //   System.Threading.Thread.Sleep(2000);
            //  var listinvcms = new List<V_u_agcmsmvmt>();

            int myMM = (_MM == null) ? 0 : (Int32)Tools.Conv_Dbl(_MM);
            int myYYYY = (_YYYY == null) ? 0 : (Int32)Tools.Conv_Dbl(_YYYY);
            fill_AGLIST();
            ViewBag.aglist = AGlist;

            Fix_INV_NOAG(_SP, _MM, _YYYY);

            return View(INV_NOAGlist.ToList());
        }


        public ActionResult dingo(string _pkt)
        {
           
            msgrec mymsg = new msgrec();
            //    lpsEnc.Text = StringCipher.Encrypt(tPass.Text, mykey);
            //    DBpwd = StringCipher.Decrypt(DBpwd, mykey);
            string d_d="????";
            try
            {
                mymsg.msg = MainMDI.StringCipher.Encrypt(_pkt, mykey);
                mymsg.recnb = "1";
            }
            catch (Exception ex)
            {
                mymsg.msg = "????";
                mymsg.recnb = "0";
            }
            msgLst.Add(mymsg);
           // System.Threading.Thread.Sleep(3000);
            return Json(msgLst , JsonRequestBehavior.AllowGet);
        }

        public string ognid (string PS_ )
        {

          //  bool OKtoCRPT = false;
            //    lpsEnc.Text = StringCipher.Encrypt(tPass.Text, mykey);
            //    DBpwd = StringCipher.Decrypt(DBpwd, mykey);
            bool OKtoCRPT = ((PS_.Length % 4) == 0);
            try
            {
               string rt= MainMDI.StringCipher.Decrypt(PS_, mykey);
                return rt;
            }
            catch (Exception ex) {

                return "????"+ex.Message; }
        
        }

        public ActionResult DispINV_NOAG(string _SP)
        {
            _SP = _SP.Replace(" ", "+");// solve error : invalid length for a base-64 char array or string. frombase64string 



            //   System.Threading.Thread.Sleep(2000);
            //  var listinvcms = new List<V_u_agcmsmvmt>();
            string _MM = "", _YYYY = "",salesP="???";
            string pkt = ognid(_SP);
            bool err = false;
            if (pkt.Substring(0,4) != "????")
            {
                int pos = pkt.IndexOf("_MM=");
                if (pos != -1)
                {
                    _MM = pkt.Substring(pos+4, 2);
                    pos = pkt.IndexOf("_YYYY=");
                    if (pos != -1)
                    {
                        _YYYY = pkt.Substring(pos+6, 4);
                        salesP = pkt.Substring(0, 3);
                    }
                    else err = true;
                }
                else err = true;

                if (!err)
                {

                    int myMM = (_MM == null) ? 0 : (Int32)Tools.Conv_Dbl(_MM);
                    int myYYYY = (_YYYY == null) ? 0 : (Int32)Tools.Conv_Dbl(_YYYY);
                    fill_AGLIST();
                    ViewBag.aglist = AGlist;

                    Fix_INV_NOAG(salesP, _MM, _YYYY);
                }
            }

            return View(INV_NOAGlist.ToList());
        }

        string Fix_INV_NOAG(string _Snn, string _mm, string _yyyy)
        {


         //  V_U_agCMSmvmt myInv_NOAG = new U_agCMSmvmt();
        
            string retrnMsg = "ERROR CMS Period.....";
            int MM = -1, YYYY = -1;
            CMS_period_MMYYYY(ref MM, ref YYYY);

            if (MM > -1 && YYYY > -1)
            {

                SqlConnection OConn = null;
                SqlCommand Ocmd = null;
                SqlDataReader Oreadr = null;
                OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

                //[S03],[S05],[S08],

                //string stSQL = " SELECT SalSalesperson.Salesperson, SalSalesperson.Name, u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Project, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Currency, " +
                //               "        u_SalCommissionsPrimax.Branch,u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.SalesOrder, u_SalCommissionsPrimax.SalesOrderLine, u_SalCommissionsPrimax.StockCode,         u_SalCommissionsPrimax.StockDescription, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, " +
                //               "        u_SalCommissionsPrimax.BackOrderQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.ExchangeRate, u_SalCommissionsPrimax.PriceCAD, u_SalCommissionsPrimax.ProductClass, u_SalCommissionsPrimax.CommissionSales1, (cast ([CommissionAmt1] AS decimal)) AS CommissionAmt1,  u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2,   " +
                //               "        u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.Salesperson3, u_SalCommissionsPrimax.CommissionSales3, u_SalCommissionsPrimax.CommissionAmt3, u_SalCommissionsPrimax.Salesperson4, u_SalCommissionsPrimax.CommissionSales4, u_SalCommissionsPrimax.Rate, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.Rate  " +
                //               " FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch) AND (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson)  " +
                //               " WHERE (SalSalesperson.Salesperson in ('S03','S05','S08')) AND (YEAR (u_SalCommissionsPrimax.DateLastInvPrt) = " + YYYY + ") AND (month (u_SalCommissionsPrimax.DateLastInvPrt)= " + MM + ")  and (LOWER([Project]) not like '%cigentec%')    " +
                //               " ORDER BY u_SalCommissionsPrimax.Invoice";

                string StSql = "SELECT distinct  u_SalCommissionsPrimax.DateLastInvPrt,  u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.Project, u_SalCommissionsPrimax.Customer,u_SalCommissionsPrimax.Salesperson2" +
                               "   FROM   u_SalCommissionsPrimax INNER JOIN  SalSalesperson ON u_SalCommissionsPrimax.Branch = SalSalesperson.Branch AND u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson " +
                               " WHERE (SalSalesperson.Salesperson = '" + _Snn + "') AND(YEAR(u_SalCommissionsPrimax.DateLastInvPrt) =" + _yyyy + ") AND(MONTH(u_SalCommissionsPrimax.DateLastInvPrt) = " + _mm + ") AND(LOWER(u_SalCommissionsPrimax.Project)  NOT LIKE '%cigentec%') AND u_SalCommissionsPrimax.Salesperson2 = '' " +
                               " ORDER BY u_SalCommissionsPrimax.Invoice";



                //    string stout = "";
                //   ed_LVallInvoices.SendToBack();
                //  ed_lvITM.Items.Clear();
                try
                {

                    OConn.Open();
                    Ocmd = OConn.CreateCommand();
                    Ocmd.CommandText = StSql;
                    Oreadr = Ocmd.ExecuteReader();
                    while (Oreadr.Read())
                    {
                        V_u_agcmsmvmt myInv_NOAG = new V_u_agcmsmvmt();
                        myInv_NOAG.customerNM = Oreadr["Customer"].ToString();
                        myInv_NOAG.Inv_date = Convert.ToDateTime(Oreadr["DateLastInvPrt"].ToString());
                        myInv_NOAG.RID = Oreadr["Project"].ToString();
                        myInv_NOAG.Invoice = Oreadr["Invoice"].ToString();
                        myInv_NOAG.desti_AG = Oreadr["Salesperson2"].ToString();

                        INV_NOAGlist.Add(myInv_NOAG);

                    }
                    retrnMsg = "IMPORT Done.......";
                }
                catch (Exception ex)
                {
                    return "Failed to List Invoices without Agencies......";//...ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL;
                }


                finally
                {
                    OConn.Close();
                    if (Oreadr != null) Oreadr.Close();
                }



            }
            else retrnMsg = "Invalid Month/Year.......";

            return retrnMsg;

        }



        //EXCEL

        public void XL_CMS_TOT()
        {
            string tmpfile = " U_CMS_AG_TOT_" + HttpContext.Session["usr"].ToString();
            const int  NBCols = 3;
            string[] objHdrs = new string[NBCols] { "Agency Name", "Invoice", "Totals" };
            string[,] objData = new string[MainMDI.MAX_XLlines_XPRT, NBCols];

            for (int u = 0; u < MainMDI.MAX_XLlines_XPRT; u++) objData[u, 0] = "*";



            //string quotnb = HttpContext.Session["quotnb"].ToString(),
            //prj = HttpContext.Session["prjname"].ToString(),
            //cust_ref = HttpContext.Session["cus_ref"].ToString(),
            //userNM = HttpContext.Session["usrFnmLnm"].ToString();


            fill_Objdata(ref objData, NBCols,tmpfile);

            OfficeOpenXml.ExcelPackage mypkg = new OfficeOpenXml.ExcelPackage();
            OfficeOpenXml.ExcelWorksheet myws = mypkg.Workbook.Worksheets.Add("Agencies commissions");

            //myws.Cells["A1"].Value = "Quote #"; myws.Cells["B1"].Value = quotnb;

            //myws.Cells["A2"].Value = "Project Name"; myws.Cells["B2"].Value = prj;

            //myws.Cells["A3"].Value = "Customer Ref."; myws.Cells["B3"].Value = cust_ref;

            //myws.Cells["A4"].Value = "date"; myws.Cells["B4"].Value = string.Format("{0:dd-MMMM-yyyy}", DateTimeOffset.Now);
            //myws.Cells["A5"].Value = "User Name"; myws.Cells["B5"].Value = userNM;


            myws.Cells["A1"].Value = objHdrs[0];
            myws.Cells["B1"].Value = objHdrs[1];
            myws.Cells["C1"].Value = objHdrs[2];
            //myws.Cells["D1"].Value = objHdrs[3];
            //myws.Cells["E1"].Value = objHdrs[4];

            int deb = 2;

            for (int i = 0; i < objData.Length && objData[i, 0] != "*"; i++)
            {
                myws.Cells[string.Format("A{0}", deb)].Value = objData[i, 0];
                myws.Cells[string.Format("B{0}", deb)].Value = objData[i, 1];
                myws.Cells[string.Format("C{0}", deb)].Value = objData[i, 2];
                //myws.Cells[string.Format("D{0}", deb)].Value = objData[i, 3];
                //myws.Cells[string.Format("E{0}", deb)].Value = objData[i, 4];
                deb++;
            }
            myws.Cells["A:AZ"].AutoFitColumns();

            //Response.Clear();
            //Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //Response.AddHeader("content-disposition", "attachment: filename=" + "CMS_Agencies.xls");
            //Response.BinaryWrite(mypkg.GetAsByteArray());
            //Response.End();

            Response.Clear();
            Response.ContentType = "application/vnd.ms-excel";
            Response.AddHeader("content-disposition", "attachment; filename=" + "CMS_Agencies.xls");
            Response.BinaryWrite(mypkg.GetAsByteArray());
            Response.End();

        }


        bool fill_Objdata(ref string[,] objData, int NBCols,string tmptbl)
        {
           // string cfid = HttpContext.Session["cfid"].ToString();
            if (tmptbl != "")
            {

                string stSql = "select * FROM " + tmptbl ;
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                int nb = 0, i = 0;
                 while (Oreadr.Read())
                {
                    for (int j = 0; j < NBCols; j++) objData[i, j] = Oreadr[j].ToString();
                    i++;
                }
                OConn.Close();
                return true;
            }
            return false;

        }




        //EXCEL





    }
}
