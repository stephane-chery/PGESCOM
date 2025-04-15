using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EAHLibs;
using System.Data.SqlClient;
using PBsizing.Models;

namespace PBsizing.Controllers
{
    public class ALLUPSController : Controller
    {
        //
        // GET: /ALLUPS/
        private Charger_UPS CHRGR_UPS;
        private Component_UPS Cpt_UPS;
        private List<string> CBn_LIST = new List<string> { "147", "226", "359", "350", "351", "352", "353", "354", "358" };
  //    private List<string> CBn_LIST = new List<string> { "CB1", "CB2", "CBi1", "CB3", "CB4", "CB5", "CB6", "CB7", "CB8" };
        string mess_err = "";
        private Lib1 Tools = new Lib1();
        UPS_config curr_UPS;
        int L = 0;

        List<V_configo_det_QT_UPS> curr_quote_lst = new List<V_configo_det_QT_UPS>();


        List<OneFrml> Frmls_list = new List<OneFrml>();
        class OneFrml
        {
            public string cptnm { get; set; }
            public string frmlNm { get; set; }
            public string frmlval { get; set; }
            public string f_msg { get; set; }
        }

        List<OneCPT> CPTfrml_list = new List<OneCPT>();
        class OneCPT
        {
            public string cptnm { get; set; }
            public string vcb { get; set; }
            public string icb { get; set; }
            public string ka { get; set; }
            public string f_msg { get; set; }
        }

        List<msgrec> msgLst = new List<msgrec>();
        class msgrec
        {
            public string msg { get; set; }
            public string recnb { get; set; }


        }


        List<cptFound> CPT_List = new List<cptFound>();
        class cptFound

        {
            public string CPTID { get; set; }
            public string refcpt { get; set; }
            public string desc { get; set; }
            public string qty { get; set; }
            public string uprice { get; set; }
            public string cat1Nm { get; set; }
            public string cat1 { get; set; }
            public string cat2Nm { get; set; }
            public string cat2 { get; set; }
            public string cat3Nm { get; set; }
            public string cat3 { get; set; }
            public string cat4Nm { get; set; }
            public string cat4 { get; set; }

            public string cptref { get; set; }
            public string catSRCH1 { get; set; }
            public string catSRCH2 { get; set; }
            public string catSRCH3 { get; set; }
            public string catSRCH4 { get; set; }

        }

        public class UPS_config
        {

            public long AvailId { get; set; }
            public string lUPSREF_Text { get; set; }
            public string p850x_Text { get; set; }
            public string phsout_Text { get; set; }
            public string kva_Text { get; set; }
            public string outV_Text { get; set; }
            public string DCbus_Text { get; set; }
            public string phsin_Text { get; set; }
            public string inV_Text { get; set; }
            public string phsbps1_Text { get; set; }
            public string bpsVin1_Text { get; set; }
            public string phsbps2_Text { get; set; }
            public string bpsVin2_Text { get; set; }
            public string Cbatt_Text { get; set; }
            public string PF_Text { get; set; }
            public string timeChrg_Text { get; set; }
            public string FLT_Text { get; set; }
            public string EQLZ_Text { get; set; }
            public string vdcMin_Text { get; set; }
            public string vdcMax_Text { get; set; }
            public string Frqin { get; set; }
            public string Frqout { get; set; }
            public string CBnkaAC { get; set; }

            public string idci { get; set; }
            public string ah { get; set; }
            public string std { get; set; }




            public string msgerror { get; set; }

        }



        List<chargerUPS_cpt> lvDefOption_Items = new List<chargerUPS_cpt>(), frmt_defoptions = new List<chargerUPS_cpt>();
        List<chargerUPS_cpt> upsCPT_list = new List<chargerUPS_cpt>();
        class chargerUPS_cpt
        {
            public string mycpt { get; set; }
            public string refcpt { get; set; }
            public string desc { get; set; }
            public string qty { get; set; }
            public string uprice { get; set; }
            public string ext { get; set; }
            public string dlvdate { get; set; }
            public string cat1Nm { get; set; }
            public string cat1 { get; set; }
            public string cat2Nm { get; set; }
            public string cat2 { get; set; }
            public string cat3Nm { get; set; }
            public string cat3 { get; set; }
            public string cat4Nm { get; set; }
            public string cat4 { get; set; }
            public string cptref { get; set; }
            public string cptpartnb { get; set; }
            public string msg_1 { get; set; }
            public string msg_2 { get; set; }
            public string msg_3 { get; set; }
            public string msg_4 { get; set; }
            public string msg_6 { get; set; }
            public string msg_5 { get; set; }
            public string msgerror { get; set; }
        }








        public ActionResult Index()
        {
            //   return View();
            return View("~/Views/Shared/logon.cshtml");
        }

        private bool XTRCT_paraQRY(string STin, ref string u, ref string stkey)
        {
            u = ""; stkey = "";

            int ipos = STin.IndexOf("?"), fpos = STin.IndexOf("=");
            if (ipos > -1 && fpos > -1 && ipos < fpos)
            {

                string[] para = new string[2] { "", "" };
                para = STin.Split(new char[] { '?', '&' });

                if (para[1] != "")
                {
                    string[] inf = para[1].Split('='); u = inf[1];
                    if (para[2] != "") inf = para[2].Split('='); stkey = inf[1];
                    //   inf = para[3].Split('='); r = inf[1];
                    // return true;
                    return (u != "" && stkey != "");
                }
                else return false;
            }

            else return false;

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
        public ActionResult P850U()
        {


            string para = "", usr = "", stkey = "", qtid = "";

            if (hasAccess('U'))
            {

                if (HttpContext.Session["usr"] != null && HttpContext.Session["stkey"] != null)
                {


                    //int MM = 0, YYYY = 0;
                    //CMS_period_MMYYYY(ref MM, ref YYYY);
                    //ViewBag.mmyyyy = MainMDI.A00(MM, 2) + "/" + YYYY.ToString();
                    // 
                    usr = HttpContext.Session["usr"].ToString();
                    stkey = HttpContext.Session["stkey"].ToString();
                    ViewBag.userName = usr;
                    return View("~/Views/ALLUPS/UPS-schema.cshtml");
                    // return View("~/Views/ALLUPS/newView.cshtml");



                    //switch (usr)
                    //{
                    //    //  case "ede":    
                    //    case "ede":
                    //        //    string sp = HttpContext.Session["salesP"].ToString();
                    //        //fill_AGLIST();
                    //        //ViewBag.aglist = AGlist;
                    //        //fill_SPLIST_SP(sp);
                    //        //ViewBag.splist = SPlist;
                    //        //   return View("~/Views/ALLUPS/P850U.cshtml");
                    //        return View("~/Views/ALLUPS/newView.cshtml");
                    //        break;

                    //}
                }
                else
                {

                    para = Request.Url.Query;
                    if (XTRCT_paraQRY(para, ref usr, ref stkey))
                    {
                        HttpContext.Session["usr"] = usr;
                        HttpContext.Session["stkey"] = stkey;
                        int ipos = stkey.IndexOf("_");
                        qtid = (ipos > 3) ? stkey.Substring(0, ipos) : "";

                        HttpContext.Session["qt"] = qtid;
                        // HttpContext.Session["opera"] = Opera;
                        if (usr != "" && stkey != "" && qtid != "")
                            return View("~/Views/ALLUPS/UPS-schema.cshtml");
                        //return View("~/Views/ALLUPS/newView.cshtml");
                        else
                        {

                            ViewBag.errormsg = "ACCES DENIED.....error keys access....";
                            return View("~/Views/Shared/Error.cshtml");
                            
                        }
                    }
                    else
                    {
                        ViewBag.errormsg = "ACCES DENIED.....error keys access....";
                        return View("~/Views/Shared/Error.cshtml");
                    }

                }




                // return View("ERROR_NOSIZING");
                return View("~/Views/Shared/logon.cshtml");
                //View("~/Views/Home/ERROR_NOSIZING.cshtml");
            }

            else return View("~/Views/Shared/Error.cshtml");
        }


        void Fill_curr_UPS(string UPS, string PHSout, string OP_KVA, string ACoutputV, string DCBus, string PHSin, string ACinputV, string PHSbps1, string BpsinputV1, string PHSbps2, string BpsinputV2, string Cbatt, string PF, string timeChrg, string FLT, string EQLZ, string vdcmin, string vdcmax, string frqin, string frqout, string cbnkaac)
        {

            curr_UPS.AvailId = 6805;
            //     curr_UPS.p850x_Text = UPS + "-" + PHSout + "-" + OP_KVA + "-" + ACoutputV + "-" + DCBus;
            //     if (PHSbps == "1" || PHSbps == "3") curr_UPS.p850x_Text += "-" + PHSbps + "-" + BpsinputV;
            curr_UPS.p850x_Text = UPS;
            curr_UPS.phsout_Text = PHSout;
            curr_UPS.kva_Text = OP_KVA;
            curr_UPS.outV_Text = ACoutputV;
            curr_UPS.DCbus_Text = DCBus;
            curr_UPS.phsin_Text = PHSin;
            curr_UPS.inV_Text = ACinputV;
            curr_UPS.phsbps1_Text = PHSbps1;
            curr_UPS.bpsVin1_Text = BpsinputV1;
            curr_UPS.phsbps2_Text = PHSbps2;
            curr_UPS.bpsVin2_Text = BpsinputV2;
            curr_UPS.Cbatt_Text = Cbatt;
            curr_UPS.PF_Text = OP_KVA;
            curr_UPS.timeChrg_Text = OP_KVA;
            curr_UPS.FLT_Text = FLT;
            curr_UPS.EQLZ_Text = EQLZ;
            curr_UPS.vdcMin_Text = vdcmin;
            curr_UPS.vdcMax_Text = vdcmax;
            curr_UPS.Frqin = frqin;
            curr_UPS.Frqout = frqout;
            curr_UPS.CBnkaAC = cbnkaac;
            curr_UPS.msgerror = "";

        }

        void vider_http()
        {

            //def Raw

            //HttpContext.Session["def_147_vac"] = "";
            //HttpContext.Session["def_147_icb1"] = "";
            //HttpContext.Session["def_147_phs"] = "";
            //HttpContext.Session["def_147_price"] = "";
            //HttpContext.Session["def_147_ka"] = "";

            //HttpContext.Session["def_226_vac"] = "";
            //HttpContext.Session["def_226_icb1"] = "";
            //HttpContext.Session["def_226_phs"] = "";
            //HttpContext.Session["def_226_price"] = "";
            //HttpContext.Session["def_226_ka"] = "";

            foreach (string st in CBn_LIST)
            {

                string defphs = "def_" + st + "_phs", defvac = "def_" + st + "_vac", deficb1 = "def_" + st + "_icb1",
                             defprice = "def_" + st + "_price", defka = "def_" + st + "_ka";

                HttpContext.Session[defphs] = "";
                HttpContext.Session[defvac] = "";
                HttpContext.Session[deficb1] = "";

                HttpContext.Session[defprice] = "";
                HttpContext.Session[defka] = "";
            }
        }

        private string CHARGER_ONEUPS_ONEVCS(string CPTid, string VCS)
        {
            string P = "1", res = "";
            CHRGR_UPS = new Charger_UPS(6805, curr_UPS.p850x_Text, curr_UPS.phsout_Text, curr_UPS.kva_Text, curr_UPS.outV_Text, curr_UPS.DCbus_Text, curr_UPS.phsin_Text,
                curr_UPS.inV_Text, curr_UPS.phsbps1_Text, curr_UPS.bpsVin1_Text, curr_UPS.phsbps2_Text, curr_UPS.bpsVin2_Text, curr_UPS.Cbatt_Text, curr_UPS.PF_Text, curr_UPS.timeChrg_Text, curr_UPS.FLT_Text,
                curr_UPS.EQLZ_Text, curr_UPS.vdcMin_Text, curr_UPS.vdcMax_Text, curr_UPS.Frqin, curr_UPS.Frqout, curr_UPS.CBnkaAC, curr_UPS.idci, curr_UPS.ah, curr_UPS.std);

            //find phs in COMPNT_LIST_UPS
            string phs_read = MainMDI.Find_One_Field("select PHS from COMPNT_LIST_UPS where Component_ID=" + CPTid);
            if (phs_read != MainMDI.VIDE)
            {
                //ONEUPS_ONECPT_ONECOST(Convert.ToInt32(CPTid), Charger_UPS.AvailId, P, 'D');
                Cpt_UPS = new Component_UPS(P);
                res = Cpt_UPS.Cal_VCS(0, VCS);
            }
            else mess_err = "ERROR PHS / CPT..............";
            return res;
        }

        string find_CPT_PHS(string Frml, string PHSout, string PHSin, string PHSbps1, string PHSbps2)
        {
            switch (Frml)
            {
                case "U_PHS_out":
                    return PHSout;
                    break;
                case "U_PHS_in":
                    return PHSin;
                    break;
                case "U_PHSbps1":
                    return PHSbps1;
                    break;
                case "U_PHSbps2":
                    return PHSbps2;
                    break;
                default:
                    return "1";
                    break;
            }
        }



        void fill_VCSvalues()
        {

            Frmls_list = new List<OneFrml>();

            for (int i = 0; i < Charger_UPS.NB_FRML; i++)
            {
                if (Charger_UPS.arr_CAL_FRML[i] != "")
                {
                    OneFrml myfrml = new OneFrml();

                    string st = "", val = "", msg = "";
                    int pos = Charger_UPS.arr_CAL_FRML[i].IndexOf("||");
                    if (pos > 0)
                    {
                        st = Charger_UPS.arr_CAL_FRML[i].Substring(0, pos);
                        val = Charger_UPS.arr_CAL_FRML[i].Substring(pos + 2, Charger_UPS.arr_CAL_FRML[i].Length - pos - 2);
                    }

                    myfrml.cptnm = "999";
                    myfrml.frmlNm = st;
                    myfrml.frmlval = val;
                    myfrml.f_msg = msg;
                    Frmls_list.Add(myfrml);

                }
                else i = Charger_UPS.NB_FRML;

            }



        }


        bool Frmt_ALLValues()
        {
            bool config_OK = true;
            string TD1_ERR = "<td style=\"border: 1px solid black;white-space: nowrap;background-color:RED ;color:white \">", TD2_ERR = "</td>";

            string TD1 = "<td style=\"border: 1px solid black;white-space: nowrap; \">", TD2 = "</td>";
            string TD1_C = "<td style=\"border: 1px solid black; align=\"center\" valign=\"middle\">";
            string TD1_blk = "<td style\" white-space: nowrap\">";

            string CHKD = "<td style=\"border: 1px solid black;\" align=\"center\" valign=\"middle\"><img src=\"/Images/yes.png\" style=\"width:18%\" /></td>";
            string UNCHKD = "<td style=\"border: 1px solid black;\" align=\"center\" valign=\"middle\"><img src=\"/Images/no.png\" style=\"width:18%\" /></td>'";
            string FS = TD1_C + "<label style=\"border-radius: 30px;background:green;font-size: 12px;font-weight: bold;color:white;border: 1px dashed #fff; border: solid 2px #6E6E6E\">FS</label>" + TD2;//"<td align=\"center\" valign=\"middle\"><img src=\"/Images/fs2.png\" style=\"width:15%\" /></td>'";
            string NFS = TD1_C + "<label style=\"border-radius: 30px;background:gray;font-size: 12px;font-weight: bold;color:white;border: 1px dashed #fff; border: solid 2px #6E6E6E\">NFS</label>" + TD2; ;// "<td align=\"center\" valign=\"middle\"><img src=\"/Images/nfs2.png\" style=\"width:15%\" /></td>'";
            string MIN = TD1_C + "<label style=\"border-radius: 30px;background:green;font-size: 12px;font-weight: bold;color:white;border: 1px dashed #fff; border: solid 2px #6E6E6E\">MAJ</label>" + TD2; ;//"<td align=\"center\" valign=\"middle\"><img src=\"/Images/min2.png\" style=\"width:15%\" /></td>'";
            string MAJ = TD1_C + "<label style=\"border-radius: 30px;background:gray;font-size: 12px;font-weight: bold;color:white;border: 1px dashed #fff; border: solid 2px #6E6E6E\">MIN</label>" + TD2; ;// "<td align=\"center\" valign=\"middle\"><img src=\"/Images/maj2.png\" style=\"width:15%\" /></td>'";




            Frmls_list = new List<OneFrml>();

            for (int i = 0; i < Charger_UPS.NB_FRML; i++)
            {
                if (Charger_UPS.arr_CAL_FRML[i] != "")
                {
                    OneFrml myfrml = new OneFrml();

                    string st = "", val = "", msg = "";
                    int pos = Charger_UPS.arr_CAL_FRML[i].IndexOf("||");
                    if (pos > 0)
                    {
                        st = Charger_UPS.arr_CAL_FRML[i].Substring(0, pos);
                        val = Charger_UPS.arr_CAL_FRML[i].Substring(pos + 2, Charger_UPS.arr_CAL_FRML[i].Length - pos - 2);


                        myfrml.frmlNm = TD1 + st + TD2;
                        myfrml.frmlval = TD1 + val + TD2;
                        myfrml.f_msg = TD1 + msg + TD2;


                        Frmls_list.Add(myfrml);
                    }

                }
                else i = Charger_UPS.NB_FRML;

            }

    
            foreach (cptFound myCPT in CPT_List)
            {
                OneFrml myfrml = new OneFrml();

            
                myfrml.frmlNm = TD1 + myCPT.cptref + "_V" + TD2;
                myfrml.frmlval = TD1 + myCPT.cat1 + TD2;
                myfrml.f_msg = TD1 + myCPT.desc+ TD2;
                Frmls_list.Add(myfrml);

                myfrml = new OneFrml();
                myfrml.frmlNm = TD1 + myCPT.cptref + "_I" + TD2;
                myfrml.frmlval = TD1 + myCPT.cat2 + TD2;
                myfrml.f_msg = TD1 + myCPT.desc + TD2;
                Frmls_list.Add(myfrml);

                myfrml = new OneFrml();
                myfrml.frmlNm = TD1 + myCPT.cptref + "_KA" + TD2;
                myfrml.frmlval = TD1 + myCPT.cat3 + TD2;
                myfrml.f_msg = TD1 + myCPT.desc + TD2;
                Frmls_list.Add(myfrml);

            }

            return config_OK;


        }

 

        void fill_CPTvalues()
        {

            Frmls_list = new List<OneFrml>();

            foreach (cptFound myCPT in CPT_List)
            {
                OneFrml myfrml = new OneFrml();

                myfrml.cptnm = myCPT.cptref;
                myfrml.frmlNm = "VCB";
                myfrml.frmlval = myCPT.cat2;
                myfrml.f_msg = "";
                Frmls_list.Add(myfrml);

                myfrml.cptnm = myCPT.cptref;
                myfrml.frmlNm = "ICB";
                myfrml.frmlval = myCPT.cat3;
                myfrml.f_msg = "";
                Frmls_list.Add(myfrml);

                myfrml.cptnm = myCPT.cptref;
                myfrml.frmlNm = "KA";
                myfrml.frmlval = myCPT.cat4;
                myfrml.f_msg = "";
                Frmls_list.Add(myfrml);

            }


        }
    

        private void ONEUPS_ONECPT_ONECOST(long dccompnt, long availID, string P, char Cd)
        //	private void ONEUPS_ONECPT_ONECOST(long dccompnt, char Cd)
        {
            //fill CHARGERS_COST0


            string stSql = "SELECT TBLAVAIL13_UPS.*, COMPNT_LIST_UPS.*, link_COMPNT_AVAIL_UPS.* " +
                " FROM (TBLAVAIL13_UPS INNER JOIN link_COMPNT_AVAIL_UPS ON TBLAVAIL13_UPS.AVAILID = link_COMPNT_AVAIL_UPS.Avail_ID) INNER JOIN COMPNT_LIST_UPS ON link_COMPNT_AVAIL_UPS.Compnt_ID = COMPNT_LIST_UPS.Component_ID " +
                " Where (link_COMPNT_AVAIL_UPS.Avail_ID = " + availID + ") and (link_COMPNT_AVAIL_UPS.Compnt_ID = " + dccompnt + ") ORDER BY TBLAVAIL13_UPS.Avail_ID, COMPNT_LIST_UPS.Component_ID";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();


            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            upsCPT_list = new List<chargerUPS_cpt>();
            if (Oreadr.HasRows)
            {

                while (Oreadr.Read())
                {
                    Cpt_UPS = new Component_UPS(P);
                    chargerUPS_cpt myCpt = new chargerUPS_cpt();

                    Cpt_UPS.Cal_chrg_CostADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()), "C");
                    if (Cpt_UPS.G_PRICE != Charger_UPS.VIDE)
                    {
                        if (Cpt_UPS.CAP1 == MainMDI.VIDE) Cpt_UPS.CAP1 = "0";
                        if (Cpt_UPS.CAP2 == MainMDI.VIDE) Cpt_UPS.CAP2 = "0";
                        if (Cpt_UPS.CAP3 == MainMDI.VIDE) Cpt_UPS.CAP3 = "0";
                        if (Cpt_UPS.CAP4 == MainMDI.VIDE) Cpt_UPS.CAP3 = "0";

                        //       ListViewItem lvI = in_frm_UPS_maker.lvQuotes.Items.Add(Oreadr["COMPONENT_REF"].ToString());
                        myCpt.cat1Nm = Oreadr["CatName1"].ToString();
                        myCpt.cat1 = Cpt_UPS.CAP1;

                        myCpt.cat2Nm = Oreadr["CatName2"].ToString();
                        myCpt.cat2 = Cpt_UPS.CAP2;

                        myCpt.cat3Nm = Oreadr["CatName3"].ToString();
                        myCpt.cat3 = Cpt_UPS.CAP3;

                        myCpt.cat4Nm = Oreadr["CatName4"].ToString();
                        myCpt.cat4 = Cpt_UPS.CAP4;

                        myCpt.qty = Cpt_UPS.Real_QTY;
                        myCpt.uprice = "";

                        upsCPT_list.Add(myCpt);


                    }

                }
            }
            else
            {
                ////MessageBox.Show ("No Component is Available....(Availability)...cpt="+dccompnt);
                //Cpt_UPS.G_Desc = Charger.VIDE;
                //Cpt_UPS.G_PRICE = Charger.VIDE;
            }
            OConn.Close();


        }




        //private void addSTDFeat()
        //{

        //    //AddTec_Values("","Cell#: " + tCellN.Text + ", VAC:" + tVac.Text +", Float: " + tVFLOAT.Text + ", Equalize: " + tVEQL.Text  ,true ); 
        //    dlg_arr_frml_fill();
        //    AddTec_Values("", "VAC:" + tVac_Text + ", Float: " + tVFLOAT_Text + ", Equalize: " + tVEQL_Text, true, "C_VFE");
        //    //if (!tRPL.ReadOnly && tRPL_Text != "") lRiple_Text = tRPL_Text;
        //    //else tRPL_Text = lRiple_Text;
        //    //tRPL.ReadOnly = true;
        //    //   AddTec_Values("",MainMDI.arr_EFSdict[19,L ] + " " + lRiple.Text + " " +  MainMDI.arr_EFSdict[20,L ],true,"C_RPL" );
        //    AddTec_Values("", MainMDI.arr_EFSdict[19, L] + " " + lRiple_Text, true, "C_RPL");
        //    dlg_arr_frml_Ovals();
        //    //dlg_Arr_frml_Disp(); 
        //    string stSql = "select * from PSM_ALLSTD where ItemCode='C' order by rnk";
        //    SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
        //    OConn.Open();
        //    SqlCommand Ocmd = OConn.CreateCommand();
        //    Ocmd.CommandText = stSql;
        //    SqlDataReader Oreadr = Ocmd.ExecuteReader();
        //    //		AddTec_Values("",MainMDI.arr_EFSdict[18,L ]+"=   " ,true,"D_" ); 
        //    while (Oreadr.Read())
        //    {
        //        if (Oreadr[L + 2].ToString() != "" && Oreadr["disp"].ToString() == "1") AddTec_Values("", Oreadr[L + 2].ToString(), true, "D_");
        //    }


        //}


        string seekUPSprice(string p850x, string phsout, string kva, string outV, string DCbus, string phsin, string inV)
        {


            p850x = "P850U";

            string res = "0", f_outV = "", f_DCbus = "", f_inV = "", f_prc = "";

            string stSql = " SELECT outVltg,DCbus,inVltg,Price FROM PSM_UPS_Prices " +
                         " where[UPS_mdl] = '" + p850x + "' and[PHSout] = '" + phsout + "' and KVA_OP = '" + kva + "' and PHSin = '" + phsin + "'";

            MainMDI.Find_2_Field(stSql, ref f_outV, ref f_DCbus, ref f_inV, ref f_prc);
            if (f_outV != MainMDI.VIDE && f_DCbus != MainMDI.VIDE && f_inV != MainMDI.VIDE && f_prc != MainMDI.VIDE)
            {
                //  MessageBox.Show("OutV= " + f_outV + "  dcbus= " + f_DCbus + "  InV= " + f_inV + "  Price= " + f_prc);

                if (f_outV[0] == '!' && f_DCbus[0] == '!' && f_inV[0] == '!')
                {
                    if (Find_vV(f_outV.Substring(1, f_outV.Length - 1), outV) &&
                        Find_vV(f_DCbus.Substring(1, f_DCbus.Length - 1), DCbus) &&
                        Find_vV(f_inV.Substring(1, f_inV.Length - 1), inV)) res = f_prc;
                    else res = "0";
                }
                else res = "0";
            }

            return res;


        }



        bool Find_vV(string Vtable, string _val)
        {
            string stSql = " SELECT  PSM_UPS_Vdetails.Vvlid FROM PSM_UPS_Vdetails INNER JOIN  PSM_UPS_Vtables ON PSM_UPS_Vdetails.V_id = PSM_UPS_Vtables.V_id " +
                          " WHERE PSM_UPS_Vtables.Vname = '" + Vtable + "'  AND PSM_UPS_Vdetails.value = '" + _val + "'";
            return (MainMDI.Find_One_Field(stSql) != MainMDI.VIDE);
        }


        public JsonResult validate_upststttt(string ups, string PHSout, string OP_KVA, string ACoutputV, string DCBus, string PHSin, string ACinputV, string PHSbps,
                                       string BpsinputV, string Cbatt, string timeChrg, string PF, string FLT, string EQLZ, string vdcmin, string vdcmax,
                                      string frq, string cbnkaac)

        {
            string upstst = ups;
            string cb1 = cbnkaac;


            return Json(frmt_defoptions, JsonRequestBehavior.AllowGet);


        }



        public JsonResult calc_upsvalues(string op, string ups, string PHSout, string OP_KVA, string ACoutputV, string DCBus, string PHSin, string ACinputV,
            string PHSbps1, string BpsinputV1, string PHSbps2, string BpsinputV2, string Cbatt, string timeChrg, string PF, string FLT, string EQLZ, string vdcmin, string vdcmax,
                                 string frqin, string frqout, string cbnkaac, string idci, string ah, string std)

        {
            //fill CHARGERS_COST0

            lvDefOption_Items.Clear();
            CPT_List.Clear();


            vider_http();
            L = 0;
            curr_UPS = new UPS_config();

            Fill_curr_UPS(ups, PHSout, OP_KVA, ACoutputV, DCBus, PHSin, ACinputV, PHSbps1, BpsinputV1, PHSbps2, BpsinputV2, Cbatt, PF, timeChrg, FLT, EQLZ, vdcmin, vdcmax, frqin, frqout, cbnkaac);

            CHRGR_UPS = new Charger_UPS(6805, ups, PHSout, OP_KVA, ACoutputV, DCBus, PHSin, ACinputV, PHSbps1, BpsinputV1, PHSbps2, BpsinputV2, Cbatt, PF, timeChrg, FLT, EQLZ, vdcmin,
                vdcmax, frqin, frqout, cbnkaac, idci, ah, std);



            msgrec mymsg = new msgrec();

            string stSql = "select * from COMPNT_LIST_UPS where actif=1 and Compnt_Type <>'S'  order by Calc_rnk";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            if (MainMDI.arr_EFSdict[0, 0] == null) MainMDI.init_Dict();
            string msgerr = "Invalid Cpt= ", KAac = "0", KAdc = "0";
            while (Oreadr.Read())
            {
                findCBnka(Oreadr["Component_ID"].ToString(), CHRGR_UPS.in_CBnkaAC, ref KAac, ref KAdc);
                if (CBn_LIST.Contains(Oreadr["Component_ID"].ToString()) && KAac != "-1" && KAdc != "-1")
                {
                    string P = find_CPT_PHS(Oreadr["PHS"].ToString(), PHSout, PHSin, PHSbps1, PHSbps2);
                    findCPT_UPS(Convert.ToInt32(Oreadr["Component_ID"].ToString()), curr_UPS.AvailId, P, 'D');
                }
                else msgerr += Oreadr["Component_ID"].ToString() + " / " + Oreadr["COMPONENT_REF"].ToString() + "--Invalid";
            }
  
            //quoting
            //if (CPT_List.Count > 0) fill_lvDefOptions();
            //Save_ChargerItems();

            Frmtno_ALLValues();


            return Json(Frmls_list, JsonRequestBehavior.AllowGet);
        }

        bool Frmtno_ALLValues()
        {
            bool config_OK = true;
            Frmls_list.Clear();

            Frmls_list = new List<OneFrml>();

            for (int i = 0; i < Charger_UPS.NB_FRML; i++)
            {
                if (Charger_UPS.arr_CAL_FRML[i] != "")
                {
                    OneFrml myfrml = new OneFrml();

                    string st = "", val = "", msg = "";
                    int pos = Charger_UPS.arr_CAL_FRML[i].IndexOf("||");
                    if (pos > 0)
                    {
                        st = Charger_UPS.arr_CAL_FRML[i].Substring(0, pos);
                        val = Charger_UPS.arr_CAL_FRML[i].Substring(pos + 2, Charger_UPS.arr_CAL_FRML[i].Length - pos - 2);

                        myfrml.cptnm = "99999";
                        myfrml.frmlNm = st;
                        myfrml.frmlval = (Tools.Conv_Dbl(val) > 0) ? Math.Round(Tools.Conv_Dbl(val), 2).ToString() : val;
                        myfrml.f_msg = msg;


                        Frmls_list.Add(myfrml);
                    }

                }
                else i = Charger_UPS.NB_FRML;

            }


            foreach (cptFound myCPT in CPT_List)
            {
                OneFrml myfrml = new OneFrml();

                myfrml.cptnm = myCPT.cptref;
                myfrml.frmlNm = "v";
                myfrml.frmlval = myCPT.cat2;
                myfrml.f_msg = myCPT.desc;
                Frmls_list.Add(myfrml);

                myfrml = new OneFrml();
                myfrml.cptnm = myCPT.cptref;
                myfrml.frmlNm = "i";
                myfrml.frmlval = myCPT.cat3;
                myfrml.f_msg = myCPT.desc;
                Frmls_list.Add(myfrml);

                myfrml = new OneFrml();
                myfrml.cptnm = myCPT.cptref;
                myfrml.frmlNm = "k";
                myfrml.frmlval = myCPT.cat4;
                myfrml.f_msg = myCPT.desc;
                Frmls_list.Add(myfrml);

            }

            return config_OK;


        }


        public ActionResult quoting_ups()
        {

            string errmsg = "";

            //  V_U_agCMSmvmt myInv_NOAG = new U_agCMSmvmt();
            curr_quote_lst.Clear();
            string usr = HttpContext.Session["usr"].ToString();
            string keyid = HttpContext.Session["stkey"].ToString();
            string pgc_qt = HttpContext.Session["qt"].ToString();

            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon);

            string StSql = "SELECT [affID] ,[optref] ,[Itemdesc],[qty],[mult],[uprice] ,[xchng]  ,[ext]   ,[leadtime]  FROM [Orig_PSM_FDB].[dbo].[Configo_Quotes_details_UPS] " +
                           "       where[keyid] = '" + keyid + "' order by[detID] ";



            try
            {

                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = StSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    V_configo_det_QT_UPS myqte = new V_configo_det_QT_UPS();

                    myqte.affID = Oreadr["affID"].ToString();
                    myqte.optref = Oreadr["optref"].ToString();
                    myqte.Itemdesc = Oreadr["Itemdesc"].ToString();
                    myqte.qty = decimal.Parse(Oreadr["qty"].ToString());
                    myqte.mult = decimal.Parse(Oreadr["mult"].ToString());
                    myqte.uprice = decimal.Parse(Oreadr["uprice"].ToString());
                    myqte.xchng = decimal.Parse(Oreadr["xchng"].ToString());
                    myqte.ext = decimal.Parse(Oreadr["ext"].ToString());
                    myqte.leadtime = Oreadr["leadtime"].ToString();

                    curr_quote_lst.Add(myqte);


                }
            }

            catch (Exception ex)
            {
                errmsg = "Failed to List this quote......";//...ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL;
            }


            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }



            return View(curr_quote_lst.ToList());

        }


        void Save_ChargerItems()
        {

            string usr = HttpContext.Session["usr"].ToString();
            string keyid = HttpContext.Session["stkey"].ToString();
            string pgc_qt = HttpContext.Session["qt"].ToString();

            MainMDI.Exec_SQL_JFS("delete Configo_Quotes_details_UPS where keyid='" + keyid, "' Configo delete cf details..", usr);

            int iaffid = 1, rnk = 1;
            foreach (chargerUPS_cpt myCH in lvDefOption_Items)
            {
                //  chargerItem frmtcharger = new chargerItem();
                string staffid = (myCH.ext == "") ? " " : iaffid++.ToString();
                string st_optref = myCH.refcpt.Replace("'", "''");
                string st_DESC = (st_optref.Length > 0) ? st_optref + ": " + myCH.desc.Replace("'", "''") : myCH.desc.Replace("'", "''");
                string stSql = "INSERT INTO Configo_Quotes_details_UPS ([keyid],[affID], [optref], " +
                    " [Itemdesc],[qty],[mult],[uprice], [xchng],[ext],[leadtime],[rnk],[pn] ,[tecVal],[itmgrp],[sext],[aext],[itmid],[usr],[pgc_qt]) VALUES ('" +
                    keyid + "', '" +
                    staffid + "', '" +
                   st_optref + "', '" +
                    st_DESC + "', " +
                   Tools.Conv_Dbl(myCH.qty).ToString() + ", " +
                     "1" + ", " +
                    Tools.Conv_Dbl(myCH.uprice).ToString() + ", " +
                       "1" + ", " +
                     Tools.Conv_Dbl(myCH.ext).ToString() + ", '" +
                     myCH.dlvdate + "', " +
                           rnk++.ToString() + ", '" +
        " " + "', '" +  //pn
          " " + "', '" +  //tecval
            "A" + "', " +  //itmgrp
              "0" + ", " +  //sext
                "0" + ", " +  //aext
                  "0" + ", '" +   //itmid
                         usr + "', " +   //usr
                pgc_qt + ")";   //qt

                MainMDI.Exec_SQL_JFS(stSql, " Configo insert cf deails", usr);



            }
        }

        private void fill_lvDefOptions()
        {
            lvDefOption_Items.Clear();


            string cost = seekUPSprice(CHRGR_UPS.in_UPSmodel, CHRGR_UPS.in_phs_out, CHRGR_UPS.in_KVA, CHRGR_UPS.in_ACout, CHRGR_UPS.in_DCbus, CHRGR_UPS.in_phs_in, CHRGR_UPS.in_Acinput);

            string ext = Convert.ToString(Math.Round(Tools.Conv_Dbl("1") * Tools.Conv_Dbl(cost), 2));
            fill_newItem(MainMDI.arr_EFSdict[52, L] + " " + CHRGR_UPS.in_UPSmodel, " ", "1", cost, ext, "04-06", "", "", "", "", "");

            fill_newItem(MainMDI.arr_EFSdict[11, L], CHRGR_UPS.in_UPSmodel, "", "", "", "", "", "", "", "", "");

            //  Frmls_list = new List<OneFrml>();
            //    OneFrml  myfrml = Frmls_list.Find(item => item.frmlNm == "ICB1");

            string v_ICB1 = getval_FRMLS("C_ICB1");

            string st53 = CHRGR_UPS.in_Acinput + "V +/-10%, " + CHRGR_UPS.in_phs_out + "ph, " + v_ICB1 + "A , " + CHRGR_UPS.in_freqout + "HZ";
            fill_newItem(MainMDI.arr_EFSdict[53, L], st53, "", "", "", "", "", "", "", "", "");

            string v_PLOAD = getval_FRMLS("U_PLOAD"), v_Ioutups = getval_FRMLS("C_ICB05");
            string st54 = CHRGR_UPS.in_ACout + "V, " + CHRGR_UPS.in_KVA + "kVA-" + v_PLOAD + "kW at " + CHRGR_UPS.in_PF + ", " + CHRGR_UPS.in_phs_out + "ph, " + v_Ioutups + "A , " + CHRGR_UPS.in_freqout + "HZ";
            fill_newItem(MainMDI.arr_EFSdict[54, L], st54, "", "", "", "", "", "", "", "", "");

            string v_ICB4 = getval_FRMLS("ICB4"); 
            string st55 = (CHRGR_UPS.in_bps_input1 != "0") ? CHRGR_UPS.in_bps_input1 + "V +/-10%, " + CHRGR_UPS.in_phs_out + "ph, " + CHRGR_UPS.in_freqout + "HZ, " + v_ICB4 + "A " : "N/A";
            fill_newItem(MainMDI.arr_EFSdict[55, L], st55, "", "", "", "", "", "", "", "", "");

            string v_Ilim_rectifier = getval_FRMLS("C_IDCC");
            string st56 = CHRGR_UPS.in_DCbus + "Vdc, " + v_Ilim_rectifier + "A ";
            fill_newItem(MainMDI.arr_EFSdict[56, L], st56, "", "", "", "", "", "", "", "", "");

            string v_Ibattcharg = "U_STD";
            string st57 = v_Ibattcharg + "A ";
            fill_newItem(MainMDI.arr_EFSdict[57, L], st57, "", "", "", "", "", "", "", "", "");

            string v_Idci = "U_IDCI";
            string st58 = CHRGR_UPS.in_DCbus + "Vdc, " + v_Idci + "A ";
            fill_newItem(MainMDI.arr_EFSdict[58, L], st58, "", "", "", "", "", "", "", "", "");

            //string v_Ilim_rectifier = "????";
            string st59 = CHRGR_UPS.in_DCbus + "Vdc, " + v_Ilim_rectifier + "A ";
            fill_newItem(MainMDI.arr_EFSdict[59, L], st59, "", "", "", "", "", "", "", "", "");



            //CPTs


            string refcpt = "", dsc = "????", amnt = "0";//,v_ICB1="?????";
            getval_CPT("147", ref refcpt, ref dsc, ref amnt);

            string st60 = v_ICB1 + "A, " + dsc; //desc of CB1 found in breaker list configo
            fill_newItem(MainMDI.arr_EFSdict[60, L], dsc, "", "", "", "", "", "", "", "", "");

            //string cpt_CB6_feat = "????";
            //string st61 = v_ICB5 + "A, " + cpt_CB6_feat; //desc of CB1 found in breaker list configo
            //fill_newItem(MainMDI.arr_EFSdict[61, L], st61, "", "", "", "", "", "", "", "", "");

            refcpt = ""; dsc = "????"; amnt = "0";
            getval_CPT("147", ref refcpt, ref dsc, ref amnt);

            string cpt_CB3_feat = "????", v_ICB3 = "?????";
            string st62 = v_ICB3 + "A, " + cpt_CB3_feat; //desc of CB1 found in breaker list configo
            fill_newItem(MainMDI.arr_EFSdict[62, L], st62, "", "", "", "", "", "", "", "", "");

            string cpt_CB2_feat = "????";
            string st63 = v_Ilim_rectifier + "A, " + cpt_CB2_feat; //desc of CB1 found in breaker list configo
            fill_newItem(MainMDI.arr_EFSdict[63, L], st63, "", "", "", "", "", "", "", "", "");

            //string cpt_CB8_feat = "????", v_Iinvinpt = "?????"; 
            //string st64 = v_Iinvinpt + "A, " + cpt_CB8_feat; //desc of CB1 found in breaker list configo
            //fill_newItem(MainMDI.arr_EFSdict[64, L], st64, "", "", "", "", "", "", "", "", "");

            //string cpt_CB9_feat = "????" ;
            //string st65 = v_Idci + "A, " + cpt_CB9_feat; //desc of CB1 found in breaker list configo
            //fill_newItem(MainMDI.arr_EFSdict[65, L], st65, "", "", "", "", "", "", "", "", "");

            string cpt_CB5_feat = "????";
            string st66 = v_Ioutups + "A, " + cpt_CB5_feat; //desc of CB1 found in breaker list configo
            fill_newItem(MainMDI.arr_EFSdict[66, L], st66, "", "", "", "", "", "", "", "", "");

            //string cpt_CB7_feat = "????";
            //string st67 = v_Ioutups + "A, " + cpt_CB7_feat; //desc of CB1 found in breaker list configo
            //fill_newItem(MainMDI.arr_EFSdict[67, L], st67, "", "", "", "", "", "", "", "", "");

            string cpt_CB4_feat = "????", v_ICB44 = "?????";
            string st68 = v_ICB4 + "A, " + cpt_CB4_feat; //desc of CB1 found in breaker list configo
            fill_newItem(MainMDI.arr_EFSdict[68, L], st68, "", "", "", "", "", "", "", "", "");

            string cpt_EN1_feat = "????";
            fill_newItem("CABINET ", cpt_EN1_feat, "", "", "", "", "", "", "", "", "");

        }





        //public JsonResult calc_upsvalues2222(string ups, string PHSout, string OP_KVA, string ACoutputV, string DCBus, string PHSin, string ACinputV, string PHSbps,
        //                             string BpsinputV, string Cbatt, string timeChrg, string PF, string FLT, string EQLZ, string vdcmin, string vdcmax,
        //                            string frq, string cbnkaac, string idci, string ah, string std)

        //{
        //    //fill CHARGERS_COST0

        //    curr_UPS = new UPS_config();

        //    Fill_curr_UPS(ups, PHSout, OP_KVA, ACoutputV, DCBus, PHSin, ACinputV, PHSbps, BpsinputV, Cbatt, PF, timeChrg, FLT, EQLZ, vdcmin, vdcmax, frq, cbnkaac);

        //    CHRGR_UPS = new Charger_UPS(6805, ups, PHSout, OP_KVA, ACoutputV, DCBus, PHSin, ACinputV, PHSbps, BpsinputV, Cbatt, PF, timeChrg, FLT, EQLZ, vdcmin, vdcmax, frq, cbnkaac, idci, ah, std);


        //    string stSql = "select * from COMPNT_LIST_UPS where actif=1 and Compnt_Type <>'S'  order by Calc_rnk";
        //    SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
        //    OConn.Open();
        //    SqlCommand Ocmd = OConn.CreateCommand();
        //    Ocmd.CommandText = stSql;
        //    SqlDataReader Oreadr = Ocmd.ExecuteReader();

        //    while (Oreadr.Read())
        //    {
        //        string P = find_CPT_PHS(Oreadr["PHS"].ToString(), PHSout, PHSin, PHSbps);
        //        ONEUPS_ONECPT_ONECOST(Convert.ToInt32(Oreadr["Component_ID"].ToString()), curr_UPS.AvailId, P, 'D');

        //    }

        //    return Json(Frmls_list, JsonRequestBehavior.AllowGet);

        //}



        //       private void CHARGER_ONEUPS_ONECOST(string UPS, string PHSout, string OP_KVA, string ACoutputV, string DCBus, string PHSin, string ACinputV, string PHSbps, string BpsinputV, string Cbatt, string PF, string tcharge)
        //public JsonResult validate_ups(string ups, string PHSout, string OP_KVA, string ACoutputV, string DCBus, string PHSin, string ACinputV, string PHSbps,
        //                               string BpsinputV, string Cbatt, string timeChrg, string PF, string FLT, string EQLZ, string vdcmin, string vdcmax,
        //                              string frq, string cbnkaac, string idci, string ah, string std)

        //{
        //    //fill CHARGERS_COST0

        //    curr_UPS = new UPS_config();

        //    Fill_curr_UPS(ups, PHSout, OP_KVA, ACoutputV, DCBus, PHSin, ACinputV, PHSbps, BpsinputV, Cbatt, PF, timeChrg, FLT, EQLZ, vdcmin, vdcmax, frq, cbnkaac);

        //    CHRGR_UPS = new Charger_UPS(6805, ups, PHSout, OP_KVA, ACoutputV, DCBus, PHSin, ACinputV, PHSbps, BpsinputV, Cbatt, PF, timeChrg, FLT, EQLZ, vdcmin, vdcmax, frq, cbnkaac, idci, ah, std);


        //    string stSql = "select * from COMPNT_LIST_UPS where actif=1 and Compnt_Type <>'S'  order by Calc_rnk";
        //    SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
        //    OConn.Open();
        //    SqlCommand Ocmd = OConn.CreateCommand();
        //    Ocmd.CommandText = stSql;
        //    SqlDataReader Oreadr = Ocmd.ExecuteReader();

        //    while (Oreadr.Read())
        //    {
        //        string P = find_CPT_PHS(Oreadr["PHS"].ToString(), PHSout, PHSin, PHSbps);
        //        ONEUPS_ONECPT_ONECOST(Convert.ToInt32(Oreadr["Component_ID"].ToString()), curr_UPS.AvailId, P, 'D');

        //    }
        //    //	tBigTot.Text = CH_COST.ToString();

        //    //fill_ALLValues();
        //    Frmt_ALLValues();
        //    //     frmt_CPTs();

        //    //string cfid = (HttpContext.Session["cfid"] == null) ? "" : HttpContext.Session["cfid"].ToString();
        //    //if (cfid != "") Save_ChargerItems(cfid);
        //    //else msgerror = "Can not save this config";
        //    //if (!config_OK) msgerror = "2";


        //    //  return Json(frmt_defoptions, JsonRequestBehavior.AllowGet);
        //    return Json(Frmls_list, JsonRequestBehavior.AllowGet);

        //}




        public string find_Value(string frml, string Flist)
        {
            if (Flist == ";" || Flist == "~~") return "???";
            {
                string U_Flist = Flist.ToUpper();
                string sepFrml = "~~";
                string U_frml = frml.ToUpper();
                string stF = "???";
                int ipos = U_Flist.IndexOf(U_frml + "||");
                if (ipos != -1)
                {
                    int ipos2 = Flist.IndexOf(sepFrml, ipos);
                    if (ipos2 == -1)
                    {
                        ipos2 = (Flist[Flist.Length - 1] == ';') ? Flist.Length - 2 : Flist.Length;
                        stF = Flist.Substring(ipos + frml.Length + 2, ipos2 - (ipos + frml.Length + 1));
                    }
                 else  stF = Flist.Substring(ipos + frml.Length + 2, ipos2 - (ipos + frml.Length + 2));
                    //			string stF=Flist.Substring(ipos+frml.Length ,ipos2-(ipos +frml.Length ) ); 
                    if (stF == "") stF = "???";

                }

                return stF;
            }
        }


        public JsonResult UPS_QT(string ups, string PHSout, string OP_KVA, string ACoutputV, string DCBus, string PHSin, string ACinputV, string PHSbps,
                                     string BpsinputV, string Cbatt, string timeChrg, string PF, string FLT, string EQLZ, string vdcmin, string vdcmax,
                                    string frq, string cbnkaac, string idci, string ah, string std)

        {
            //fill CHARGERS_COST0
     //       lvDefOption_Items.Clear();
     //       vider_http();
     //       L = 0;
     //       curr_UPS = new UPS_config();

     //       Fill_curr_UPS(ups, PHSout, OP_KVA, ACoutputV, DCBus, PHSin, ACinputV, PHSbps, BpsinputV, Cbatt, PF, timeChrg, FLT, EQLZ, vdcmin, vdcmax, frq, cbnkaac);

     //       CHRGR_UPS = new Charger_UPS(6805, ups, PHSout, OP_KVA, ACoutputV, DCBus, PHSin, ACinputV, PHSbps, BpsinputV, Cbatt, PF, timeChrg, FLT, EQLZ, vdcmin,
     //           vdcmax, frq, cbnkaac, idci, ah, std);



     //       msgrec mymsg = new msgrec();

     //       string stSql = "select * from COMPNT_LIST_UPS where actif=1 and Compnt_Type <>'S'  order by Calc_rnk";
     //       SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
     //       OConn.Open();
     //       SqlCommand Ocmd = OConn.CreateCommand();
     //       Ocmd.CommandText = stSql;
     //       SqlDataReader Oreadr = Ocmd.ExecuteReader();
     //       if (MainMDI.arr_EFSdict[0, 0] == null) MainMDI.init_Dict();
     //       string msgerr = "Invalid Cpt= ";
     //       while (Oreadr.Read())
     //       {
     //           if (CBn_LIST.Contains(Oreadr["Component_ID"].ToString()))
     //           {
     //               string P = find_CPT_PHS(Oreadr["PHS"].ToString(), PHSout, PHSin, PHSbps);
     //               findCPT_UPS(Convert.ToInt32(Oreadr["Component_ID"].ToString()), curr_UPS.AvailId, P, 'D');
     //           }
     //           else msgerr += Oreadr["Component_ID"].ToString() + "--Invalid";
     //       }

     ////       fill_ALLValues();
     //       if (CPT_List.Count > 0) fill_lvDefOptions();
     //       Save_ChargerItems();
     //       //   msgerr= fill_curr_quote_lst();

     //       //    return View(curr_quote_lst.ToList());


     //       mymsg.msg = msgerr;
     //       mymsg.recnb = lvDefOption_Items.Count.ToString ();
     //      msgLst.Add(mymsg);

             return Json(msgLst, JsonRequestBehavior.AllowGet);

        }


      
        //public ActionResult Dispquote(string _AG, string _MM, string _YYYY)
        //{
        //    //   and SP+' - ' + SPname = 'S05 - Yves Lavoie'


        //    if (ValidUser())
        //    {
        //        List<V_U_agcmsmvt_VNTL> mylist_V = new List<V_U_agcmsmvt_VNTL>();
        //        string retrnMsg = "";
        //        find_commis_agency(_AG, _MM, _YYYY, ref mylist_V, ref retrnMsg);

        //        return View(mylist_V);
        //    }
        //    else
        //    {
        //        RedirectToAction("Login", "AGCMS");
        //        return Json(null);
        //    }


        //}
    




        //public ActionResult Dispquote(string _AG, string _MM, string _YYYY)
        //{
        //    //   and SP+' - ' + SPname = 'S05 - Yves Lavoie'


        //    if (ValidUser())
        //    {
        //        List<V_U_agcmsmvt_VNTL> mylist_V = new List<V_U_agcmsmvt_VNTL>();
        //        string retrnMsg = "";
        //        find_commis_agency(_AG, _MM, _YYYY, ref mylist_V, ref retrnMsg);

        //        return View(mylist_V);
        //    }
        //    else
        //    {
        //        RedirectToAction("Login", "AGCMS");
        //        return Json(null);
        //    }


        //}

        void findCBnka(string cpld, string cbnkaac, ref string AC, ref string DC)
        {

            AC = "0"; DC = "0";
            //   CB2_ka = find_Value("CB2", cbnkaac),
            //      CB3_ka = find_Value("CB3", cbnkaac),
            //      CB4_ka = find_Value("CB4", cbnkaac), 
            //      CB5_ka = find_Value("CB5", cbnkaac),
            //CB6_ka = find_Value("CB6", cbnkaac),    
            //CB7_ka = find_Value("CB7", cbnkaac),
            //CB8_ka = find_Value("CB8", cbnkaac),
            //CB9_ka = find_Value("CB9", cbnkaac);
            switch (cpld)
            {
                //KA DC
                case "226":
                    DC = find_Value("CB2", cbnkaac);
                    break;
                case "350":
                    DC = find_Value("CB3", cbnkaac);
                    break;
                case "359":
                    AC = find_Value("CBi1", cbnkaac);
                    break;
                //KA AC
                case "147":
                    AC = find_Value("CB1", cbnkaac);
                    break;
                case "351":
                    AC = find_Value("CB4", cbnkaac);
                    break;
                case "352":
                    AC = find_Value("CB5", cbnkaac);
                    break;
                case "353":
                    AC = find_Value("CB6", cbnkaac);
                    break;
                case "354":
                    AC = find_Value("CB7", cbnkaac);
                    break;
                case "358":
                    AC = find_Value("CB8", cbnkaac);
                    break;



            }


        }
        //in findcpt-ups insert statements of fill_Def_options(
        private void findCPT_UPS_good(long dccompnt, long availID, string P, char Cd)
        //	private void ONEUPS_ONECPT_ONECOST(long dccompnt, char Cd)
        {
            //fill CHARGERS_COST0


            string stSql = "SELECT TBLAVAIL13_UPS.*, COMPNT_LIST_UPS.*, link_COMPNT_AVAIL_UPS.* " +
                " FROM (TBLAVAIL13_UPS INNER JOIN link_COMPNT_AVAIL_UPS ON TBLAVAIL13_UPS.AVAILID = link_COMPNT_AVAIL_UPS.Avail_ID) INNER JOIN COMPNT_LIST_UPS ON link_COMPNT_AVAIL_UPS.Compnt_ID = COMPNT_LIST_UPS.Component_ID " +
                " Where (link_COMPNT_AVAIL_UPS.Avail_ID = " + availID + ") and (link_COMPNT_AVAIL_UPS.Compnt_ID = " + dccompnt + ") ORDER BY TBLAVAIL13_UPS.Avail_ID, COMPNT_LIST_UPS.Component_ID";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();


            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            upsCPT_list = new List<chargerUPS_cpt>();
            while (Oreadr.Read())
            {

                string KAac = "0";
                string KAdc = "0";

                findCBnka(Oreadr["Component_ID"].ToString(), CHRGR_UPS.in_CBnkaAC, ref KAac, ref KAdc);

                chargerUPS_cpt myCpt = new chargerUPS_cpt();
                Cpt_UPS = new Component_UPS(P);
                string tt = Cpt_UPS.Cal_chrg_CostADO_Configo(Convert.ToInt32(Oreadr["Component_ID"].ToString()), "C", KAac, KAdc);
                if (tt == MainMDI.VIDE)
                   myCpt.msg_1 = Oreadr["COMPONENT_REF"].ToString() + " was not found ";
                else
                {

                   // if (lvDefOption_Items.Count == 0) addchRef();

                    if (Cpt_UPS.G_PRICE !=MainMDI.VIDE)
                    {


                        string stt = "";
                        stt += (Cpt_UPS.CAP4 == MainMDI.VIDE) ? "" : " " + Cpt_UPS.CAP4;
                        stt += (Cpt_UPS.CAP5 == MainMDI.VIDE) ? "" : " " + Cpt_UPS.CAP5;
                        stt += (Cpt_UPS.CAP6 == MainMDI.VIDE) ? "" : " " + Cpt_UPS.CAP6;
                        stt += (Cpt_UPS.CAP7 == MainMDI.VIDE) ? "" : " " + Cpt_UPS.CAP7;

                        string cat1 = Oreadr["CatName1"].ToString() + "=" + Cpt_UPS.CAP1.ToString();
                        string cat2 = (Oreadr["CatName2"].ToString() != MainMDI.VIDE) ? Oreadr["CatName2"].ToString() + "=" + Cpt_UPS.CAP2.ToString() : "";
                        string cat3 = (Oreadr["CatName3"].ToString() != MainMDI.VIDE) ? Oreadr["CatName3"].ToString() + "=" + Cpt_UPS.CAP3.ToString() : "";
                        string cat4 = (Oreadr["CatName4"].ToString() != MainMDI.VIDE) ? Oreadr["CatName4"].ToString() + "=" + Cpt_UPS.CAP4.ToString() : "";

                        if (Oreadr["Component_ID"].ToString() != "147" && Oreadr["Component_ID"].ToString() != "226") 
                            fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), stt, "", "", "", "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), Cpt_UPS.G_Desc);
                        else
                        {
                            //breaker with KA

                            if (Oreadr["Component_ID"].ToString() == "147")
                            {

                                //added 14082019  fill raw charger
                                if (HttpContext.Session["def_147_phs"].ToString() == "")
                                {
                                    HttpContext.Session["def_147_phs"] = cat1;
                                    HttpContext.Session["def_147_vac"] = cat2;
                                    HttpContext.Session["def_147_icb1"] = cat3;

                                    HttpContext.Session["def_147_price"] = Cpt_UPS.G_PRICE;
                                    HttpContext.Session["def_147_ka"] = "";
                                }

                                //added 14082019
                                double def_price = Tools.Conv_Dbl(HttpContext.Session["def_147_price"].ToString());
                                double currPrice = Tools.Conv_Dbl(Cpt_UPS.G_PRICE);


                                if (Cpt_UPS.G_PRICE == "-99999") fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt_UPS.G_Desc, "", "", "", "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
                                else
                                {

                                    if (Tools.Conv_Dbl(KAac) > 0 || currPrice > def_price) fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt_UPS.G_Desc, "1", Cpt_UPS.G_PRICE, Cpt_UPS.G_PRICE, "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
                                    else fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt_UPS.G_Desc, "", "", "", "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
                                }
                                ////Uncheck by default TB123/TB45 requested by Sam on: 13-12-2005
                                //if (Oreadr["COMPONENT_REF"].ToString().IndexOf("TB-") != -1 || Oreadr["COMPONENT_REF"].ToString().IndexOf("EN1") != -1) lvI.Checked = false;
                                ////
                                ///
                            }
                            else
                            {
                                if (HttpContext.Session["def_226_phs"].ToString() == "")
                                {
                                    HttpContext.Session["def_226_phs"] = cat1;
                                    HttpContext.Session["def_226_vac"] = cat2;
                                    HttpContext.Session["def_147_icb1"] = cat3;

                                    HttpContext.Session["def_226_price"] = Cpt_UPS.G_PRICE;
                                    HttpContext.Session["def_226_ka"] = "";
                                }
                                double def_price = Tools.Conv_Dbl(HttpContext.Session["def_226_price"].ToString());
                                double currPrice = Tools.Conv_Dbl(Cpt_UPS.G_PRICE);

                                if (Cpt_UPS.G_PRICE == "-99999") fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt_UPS.G_Desc, "", "", "", "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
                                else
                                {

                                    if (Tools.Conv_Dbl(KAdc) > 0 || currPrice > def_price) fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt_UPS.G_Desc, "1", Cpt_UPS.G_PRICE, Cpt_UPS.G_PRICE, "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
                                    else fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt_UPS.G_Desc, "", "", "", "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
                                }

                            }
                        }


                    }
                    lvDefOption_Items.Add(myCpt);
                }

            }
    //        if (lvDefOption_Items.Count != 0) addSTDFeat();
            OConn.Close();
        }


        bool isDC_KA(string refcpt)
        {
            switch (refcpt)
            {
                case "CB2":
                case "CBi1":
                case "CB3":
                    return true;
                    break;
                default:
                    return false;
            }

        }
        private void findCPT_UPS(long dccompnt, long availID, string P, char Cd)
        //	private void ONEUPS_ONECPT_ONECOST(long dccompnt, char Cd)
        {
            //fill CHARGERS_COST0
            string KAac = "0";
             string KAdc = "0";

            string stSql = "SELECT TBLAVAIL13_UPS.*, COMPNT_LIST_UPS.*, link_COMPNT_AVAIL_UPS.* " +
                " FROM (TBLAVAIL13_UPS INNER JOIN link_COMPNT_AVAIL_UPS ON TBLAVAIL13_UPS.AVAILID = link_COMPNT_AVAIL_UPS.Avail_ID) INNER JOIN COMPNT_LIST_UPS ON link_COMPNT_AVAIL_UPS.Compnt_ID = COMPNT_LIST_UPS.Component_ID " +
                " Where (link_COMPNT_AVAIL_UPS.Avail_ID = " + availID + ") and (link_COMPNT_AVAIL_UPS.Compnt_ID = " + dccompnt + ") ORDER BY TBLAVAIL13_UPS.Avail_ID, COMPNT_LIST_UPS.Component_ID";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();


            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            upsCPT_list = new List<chargerUPS_cpt>();
            while (Oreadr.Read())
            {
                findCBnka(Oreadr["Component_ID"].ToString(), CHRGR_UPS.in_CBnkaAC,ref KAac,ref KAdc);


                chargerUPS_cpt myCpt = new chargerUPS_cpt();
                Cpt_UPS = new Component_UPS(P);
                string tt = Cpt_UPS.Cal_chrg_CostADO_Configo(Convert.ToInt32(Oreadr["Component_ID"].ToString()), "C", KAac, KAdc);
                if (tt == MainMDI.VIDE)
                    myCpt.msg_1 = Oreadr["COMPONENT_REF"].ToString() + " was not found ";
                else
                {

                    // if (lvDefOption_Items.Count == 0) addchRef();

                    if (Cpt_UPS.G_PRICE != MainMDI.VIDE)
                    {


                        string stt = "";
                        //stt += (Cpt_UPS.CAP4 == MainMDI.VIDE) ? "" : " " + Cpt_UPS.CAP4;
                        //stt += (Cpt_UPS.CAP5 == MainMDI.VIDE) ? "" : " " + Cpt_UPS.CAP5;
                        //stt += (Cpt_UPS.CAP6 == MainMDI.VIDE) ? "" : " " + Cpt_UPS.CAP6;
                        //stt += (Cpt_UPS.CAP7 == MainMDI.VIDE) ? "" : " " + Cpt_UPS.CAP7;

                        //string cat1 =  Cpt_UPS.CAP1.ToString();
                        //string cat2 = (Oreadr["CatName2"].ToString() != MainMDI.VIDE) ? Cpt_UPS.CAP2.ToString() : "";
                        //string cat3 = (Oreadr["CatName3"].ToString() != MainMDI.VIDE) ?  Cpt_UPS.CAP3.ToString() : "";

                        //string cat4 = KAac;
                        //if (isDC_KA(Oreadr["COMPONENT_REF"].ToString())) cat4 = KAdc;

                        //string nam1 = Oreadr["CatName1"].ToString() ;
                        //string nam2 = (Oreadr["CatName2"].ToString() != MainMDI.VIDE) ? Oreadr["CatName2"].ToString() : "";
                        //string nam3 = (Oreadr["CatName3"].ToString() != MainMDI.VIDE) ? Oreadr["CatName3"].ToString()  : "";
                        //string nam4 = "kA"; // (Oreadr["CatName4"].ToString() != MainMDI.VIDE) ? Oreadr["CatName4"].ToString()  : "";



                        string cat1 =  Cpt_UPS.CAP1.ToString();
                        string cat2 = (Oreadr["CatName2"].ToString() != MainMDI.VIDE) ? Cpt_UPS.CAP2.ToString() : "";
                        string cat3 = (Oreadr["CatName3"].ToString() != MainMDI.VIDE) ?  Cpt_UPS.CAP3.ToString() : "";

                        string cat4 = Cpt_UPS.CAP4;//vdc srch
                        string cat5 = Cpt_UPS.CAP5;//icbxx srch
                        string kaSRCH= Cpt_UPS.CAP6;//ka srch
                        string kafnd = Cpt_UPS.CAP7;//ka fnd

                        string nam1 = Oreadr["CatName1"].ToString() ;
                        string nam2 = (Oreadr["CatName2"].ToString() != MainMDI.VIDE) ? Oreadr["CatName2"].ToString() : "";
                        string nam3 = (Oreadr["CatName3"].ToString() != MainMDI.VIDE) ? Oreadr["CatName3"].ToString()  : "";
                        string nam4 = "kA"; // (Oreadr["CatName4"].ToString() != MainMDI.VIDE) ? Oreadr["CatName4"].ToString()  : "";

                        if (CBn_LIST.Contains(Oreadr["Component_ID"].ToString()))
                        {
    
                            string defphs = "def_" + Oreadr["Component_ID"].ToString() + "_phs",
                                   defvac = "def_" + Oreadr["Component_ID"].ToString() + "_vac",
                                   deficb1 = "def_" + Oreadr["Component_ID"].ToString() + "_icb1",
                            defprice = "def_" + Oreadr["Component_ID"].ToString() + "_price",
                            defka = "def_" + Oreadr["Component_ID"].ToString() + "_ka";
                            if (HttpContext.Session[defphs].ToString() == "")
                            {
                                HttpContext.Session[defphs] = cat1;
                                HttpContext.Session[defvac] = cat2;
                                HttpContext.Session[deficb1] = cat3;

                                HttpContext.Session[defprice] = Cpt_UPS.G_PRICE;
                                HttpContext.Session[defka] = "";
                            }
   
                            double def_price = Tools.Conv_Dbl(HttpContext.Session[defprice].ToString());
                            double currPrice = Tools.Conv_Dbl(Cpt_UPS.G_PRICE);


                            if (Cpt_UPS.G_PRICE == "-99999") fill_CPT(Oreadr["Component_ID"].ToString(), MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt_UPS.G_Desc, "", "", cat1, cat2, cat3,kaSRCH, Oreadr["COMPONENT_REF"].ToString(),nam1,nam2,nam3,nam4, cat4, cat5, kafnd);
                            else
                            {

                                if (Tools.Conv_Dbl(KAac) > 0 || currPrice > def_price) fill_CPT(Oreadr["Component_ID"].ToString(), MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt_UPS.G_Desc, "1", Cpt_UPS.G_PRICE, cat1, cat2, cat3, kaSRCH, Oreadr["COMPONENT_REF"].ToString(), nam1, nam2, nam3, nam4, cat4, cat5, kafnd);
                                else fill_CPT(Oreadr["Component_ID"].ToString(), MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt_UPS.G_Desc, "", "", cat1, cat2, cat3, kaSRCH, Oreadr["COMPONENT_REF"].ToString(), nam1, nam2, nam3, nam4, cat4, cat5, kafnd);
                            }
                    
                        }
                     }
           
                }

            }
  
            OConn.Close();
        }
        void fill_newItem(string refcpt, string desc, string qty, string uprice, string ext, string dlvdate, string cat1, string cat2, string cat3, string cptref, string cptpartnb)
        {

            chargerUPS_cpt myitem = new chargerUPS_cpt();

            myitem.refcpt = refcpt;// MainMDI.arr_EFSdict[10, L] + " " + lChrgREF_Text;
            myitem.desc = desc;

            myitem.qty = (uprice == "0") ? "" : qty;//tPxxQty_Text
            myitem.uprice = (uprice == "0") ? "" : uprice;
            myitem.ext = (uprice == "0") ? "" : ext;
            myitem.dlvdate = (uprice == "0") ? "" : dlvdate;
            myitem.cat1 = cat1;
            myitem.cat2 = cat2;
            myitem.cat3 = cat3;
            myitem.cptref = cptref;
            myitem.cptpartnb = cptpartnb;
            myitem.msgerror = "";
            //string cost = find_CHARGER_COST(txcbPxx_Text, cbPhs_Text, cbVdc_Text, cbIdc_Text);

            //cost = Convert.ToString(Math.Round(Tools.Conv_Dbl(cost) * Tools.Conv_Dbl(lhrtZMRK_Text), 0));
            //myitem.uprice = cost;
            ////myitem.ext = Convert.ToString(Math.Round(Tools.Conv_Dbl(tPxxQty.Text) * Tools.Conv_Dbl(cost), Charger.NB_DEC_AFF));
            //myitem.ext = Convert.ToString(Math.Round(Tools.Conv_Dbl("1") * Tools.Conv_Dbl(cost), Charger.NB_DEC_AFF));
            //myitem.dlvdate = "04-06";
            lvDefOption_Items.Add(myitem);

        }


        void fill_CPT(string cptID,string refcpt, string desc, string qty, string uprice, string cat1, string cat2, string cat3, string cat4, string cptref, string nam1, string nam2, string nam3, string nam4,string fnd1, string fnd2, string fnd3)
        {

            cptFound myitem = new cptFound();
            myitem.CPTID = cptID;
            myitem.refcpt = refcpt;// MainMDI.arr_EFSdict[10, L] + " " + lChrgREF_Text;
            myitem.desc = desc;

            myitem.qty = qty;//tPxxQty_Text
            myitem.uprice = uprice;
            myitem.cat1 = cat1;
            myitem.cat2 = cat2;
            myitem.cat3 = cat3;
            myitem.cat4 = fnd3;//fnd ka 
                               

            myitem.cat1Nm = nam1;
            myitem.cat2Nm = nam2;
            myitem.cat3Nm = nam3;
            myitem.cat4Nm = nam4;

            myitem.catSRCH1 = fnd1;//search V 
            myitem.catSRCH2 = fnd2;//search I 
            myitem.catSRCH3 = cat4;//search ka 

            myitem.cptref = cptref;

            //  myitem.msgerror = "";
            //string cost = find_CHARGER_COST(txcbPxx_Text, cbPhs_Text, cbVdc_Text, cbIdc_Text);

            //cost = Convert.ToString(Math.Round(Tools.Conv_Dbl(cost) * Tools.Conv_Dbl(lhrtZMRK_Text), 0));
            //myitem.uprice = cost;
            ////myitem.ext = Convert.ToString(Math.Round(Tools.Conv_Dbl(tPxxQty.Text) * Tools.Conv_Dbl(cost), Charger.NB_DEC_AFF));
            //myitem.ext = Convert.ToString(Math.Round(Tools.Conv_Dbl("1") * Tools.Conv_Dbl(cost), Charger.NB_DEC_AFF));
            //myitem.dlvdate = "04-06";
            CPT_List.Add(myitem);
       

        }

        string getval_FRMLS(string fnme)
        {
            OneFrml myfrml = Frmls_list.Find(item => (item.frmlNm == fnme) && ( item.cptnm == "99999"));
            string valfrml=(myfrml == null) ? " ???? " : myfrml.frmlval;
            return valfrml;

        }
        void getval_CPT(string cptID,ref string refCPT, ref string stt,ref string PRC)
        {
            cptFound mycpt = new cptFound();
            mycpt = CPT_List.Find(item => item.CPTID == cptID);
            stt = (mycpt == null) ? "????????? " : mycpt.desc ;
            stt = (mycpt == null) ? "????????? " : mycpt.refcpt;
            stt = (mycpt == null) ? "0" : mycpt.uprice;
            
        }
      
        private void addchRef()
        {

            //chargerItem myitem = new chargerItem();
            string cost = seekUPSprice(CHRGR_UPS.in_UPSmodel, CHRGR_UPS.in_phs_out, CHRGR_UPS.in_KVA, CHRGR_UPS.in_ACout, CHRGR_UPS.in_DCbus, CHRGR_UPS.in_phs_in, CHRGR_UPS.in_Acinput);

            string ext = Convert.ToString(Math.Round(Tools.Conv_Dbl("1") * Tools.Conv_Dbl(cost), 2));
            fill_newItem(MainMDI.arr_EFSdict[51, L] + " " + CHRGR_UPS.in_UPSmodel, " ", "1", cost, ext, "04-06", "", "", "", "", "");

            fill_newItem(MainMDI.arr_EFSdict[11, L], CHRGR_UPS.in_UPSmodel, "", "", "", "", "", "", "", "", "");
         

            ////skiped BOM
            ////lvI.SubItems[11].Text = find_EDrw_BOM(txcbPxx.Text, cbPhs.Text, cbVdc.Text, cbIdc.Text);

            //string dsc = tVac_Text + " " + MainMDI.arr_EFSdict[13, L] + " +10/-12%, " + cbPhs_Text + " " + MainMDI.arr_EFSdict[43, L] + ", " + lhrtz_Text + " Hertz, " + Math.Round(Tools.Conv_Dbl(lIprim_Text), 0) + " A";
            //fill_newItem(MainMDI.arr_EFSdict[12, L], dsc, "", "", "", "", "", "", "", "C_IV", "");



            //dsc = cbVdc_Text + " " + MainMDI.arr_EFSdict[15, L] + " " + MainMDI.arr_EFSdict[32, L] + ":" + "     Min " + MainMDI.arr_EFSdict[15, L] + ": " + tvdcMin_Text + "     Max " + MainMDI.arr_EFSdict[15, L] + ": " + tVdcMax_Text;
            //fill_newItem(MainMDI.arr_EFSdict[14, L], dsc, "", "", "", "", "", "", "", "C_OV", "");


            //dsc = cbIdc_Text + " " + MainMDI.arr_EFSdict[17, L] + " " + MainMDI.arr_EFSdict[32, L] + ":" + "     Min " + MainMDI.arr_EFSdict[33, L] + ": " + tIdcMin_Text + "     Max " + MainMDI.arr_EFSdict[33, L] + ": " + tIdcMax_Text;
            //fill_newItem(MainMDI.arr_EFSdict[16, L], dsc, "", "", "", "", "", "", "", "C_OC", "");

        }




        private void AddTec_Values(string st0, string st, bool SHW, string cptREF)
        {


            fill_newItem(st0, st, "", "", "", "", "", "", "", cptREF, "");
        }






     










        //private void fill_Def_options()
        //{
        //    //   t1.Text = System.DateTime.Now.Second.ToString();
        //    //   this.Cursor = Cursors.WaitCursor;

        //    if (MainMDI.arr_EFSdict[0, 0] == null) MainMDI.init_Dict();
        //    string KAac = HttpContext.Session["kaac"].ToString(), KAdc = HttpContext.Session["kadc"].ToString();

        //    //old
        //    // string stSql = "select * from Configo_COMPNT_LIST where Compnt_Type='E' or Compnt_Type='D'  order by Component_ID";
        //    //new
        //    string stSql = "select * from Configo_COMPNT_LIST where Compnt_Type='E' or Compnt_Type='D'   order by component_ref ";


        //    SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
        //    OConn.Open();
        //    SqlCommand Ocmd = OConn.CreateCommand();
        //    Ocmd.CommandText = stSql;
        //    SqlDataReader Oreadr = Ocmd.ExecuteReader();
        //    int debut = 0;
        //    //  lvDefOption.Items.Clear();
        //    //    for (int i = 0; i < 200; i++) for (int j = 0; j < 12; j++) lvDefOption_Items[i, j] = "";
        //    lvDefOption_Items.Clear();
        //    while (Oreadr.Read())
        //    {
        //        if (debut == 0)
        //        {
        //            //CHRGR  =new Charger(0 ,lFV.Text , txcbPxx.Text ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text,tVac.Text,tVdcMax.Text );
        //            CHRGR = new Charger(0, lFV_Text, txcbPxx_Text.Substring(0, 5), cbPhs_Text, cbVdc_Text, cbIdc_Text, tVac_Text, tVdcMax_Text);
        //            debut = 1;

        //        }
        //        Cpt_UPS = new Component_UPS(;  //CB2==> E ~ Configo_COMPNT_LIST    (S=disabled)

        //        string tt = Cpt.Cal_chrg_CostADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()), "C", KAac, KAdc);
        //        lIprim_Text = Cpt.Cal_VCS(0, "C_IPRIM");
        //        lhrtZMRK_Text = Cpt.Cal_VCS(0, "C_HRTZ" + lhrtz_Text);

        //        if (tt == MainMDI.VIDE)
        //            ItemMSGs.msg_opt_nfnd = (ItemMSGs.msg_opt_nfnd == "") ? "This default option: " + "\n" + Oreadr["COMPONENT_REF"].ToString() + " was not found " : "\n" + Oreadr["COMPONENT_REF"].ToString() + " was not found ";
        //        else
        //        {

        //            if (lvDefOption_Items.Count == 0) addchRef();

        //            if (Cpt.G_PRICE != Charger.VIDE)
        //            {


        //                string stt = "";
        //                stt += (Cpt.CAP4 == MainMDI.VIDE) ? "" : " " + Cpt.CAP4;
        //                stt += (Cpt.CAP5 == MainMDI.VIDE) ? "" : " " + Cpt.CAP5;
        //                stt += (Cpt.CAP6 == MainMDI.VIDE) ? "" : " " + Cpt.CAP6;
        //                stt += (Cpt.CAP7 == MainMDI.VIDE) ? "" : " " + Cpt.CAP7;

        //                string cat1 = Oreadr["CatName1"].ToString() + "=" + Cpt.CAP1.ToString();
        //                string cat2 = (Oreadr["CatName2"].ToString() != Charger.VIDE) ? Oreadr["CatName2"].ToString() + "=" + Cpt.CAP2.ToString() : "";
        //                string cat3 = (Oreadr["CatName3"].ToString() != Charger.VIDE) ? Oreadr["CatName3"].ToString() + "=" + Cpt.CAP3.ToString() : "";

        //                if (Oreadr["Component_ID"].ToString() != "147" && Oreadr["Component_ID"].ToString() != "226") fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), stt, "", "", "", "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), Cpt.G_Desc);
        //                else
        //                {
        //                    //breaker with KA

        //                    if (Oreadr["Component_ID"].ToString() == "147")
        //                    {

        //                        //added 14082019  fill raw charger
        //                        if (HttpContext.Session["def_147_phs"].ToString() == "")
        //                        {
        //                            HttpContext.Session["def_147_phs"] = cat1;
        //                            HttpContext.Session["def_147_vac"] = cat2;
        //                            HttpContext.Session["def_147_icb1"] = cat3;

        //                            HttpContext.Session["def_147_price"] = Cpt.G_PRICE;
        //                            HttpContext.Session["def_147_ka"] = "";
        //                        }

        //                        //added 14082019
        //                        double def_price = Tools.Conv_Dbl(HttpContext.Session["def_147_price"].ToString());
        //                        double currPrice = Tools.Conv_Dbl(Cpt.G_PRICE);


        //                        if (Cpt.G_PRICE == "-99999") fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt.G_Desc, "", "", "", "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
        //                        else
        //                        {

        //                            if (Tools.Conv_Dbl(KAac) > 0 || currPrice > def_price) fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt.G_Desc, "1", Cpt.G_PRICE, Cpt.G_PRICE, "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
        //                            else fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt.G_Desc, "", "", "", "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
        //                        }
        //                        ////Uncheck by default TB123/TB45 requested by Sam on: 13-12-2005
        //                        //if (Oreadr["COMPONENT_REF"].ToString().IndexOf("TB-") != -1 || Oreadr["COMPONENT_REF"].ToString().IndexOf("EN1") != -1) lvI.Checked = false;
        //                        ////
        //                        ///
        //                    }
        //                    else
        //                    {
        //                        if (HttpContext.Session["def_226_phs"].ToString() == "")
        //                        {
        //                            HttpContext.Session["def_226_phs"] = cat1;
        //                            HttpContext.Session["def_226_vac"] = cat2;
        //                            HttpContext.Session["def_147_icb1"] = cat3;

        //                            HttpContext.Session["def_226_price"] = Cpt.G_PRICE;
        //                            HttpContext.Session["def_226_ka"] = "";
        //                        }
        //                        double def_price = Tools.Conv_Dbl(HttpContext.Session["def_226_price"].ToString());
        //                        double currPrice = Tools.Conv_Dbl(Cpt.G_PRICE);

        //                        if (Cpt.G_PRICE == "-99999") fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt.G_Desc, "", "", "", "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
        //                        else
        //                        {

        //                            if (Tools.Conv_Dbl(KAdc) > 0 || currPrice > def_price) fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt.G_Desc, "1", Cpt.G_PRICE, Cpt.G_PRICE, "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
        //                            else fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt.G_Desc, "", "", "", "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
        //                        }

        //                    }
        //                }
        //            }

        //        }
        //    }
        //    //	 lIprim.Text = Cpt.Cal_VCS(0,"C_IPRIM");

        //    if (lvDefOption_Items.Count != 0) addSTDFeat();
        //    OConn.Close();
        //    //     this.Cursor = Cursors.Default;
        //    //t2.Text = System.DateTime.Now.Second.ToString (); 
        //}





        //private void dlg_arr_frml_fill()
        //{
        //    for (int i = 0; i < Charger.NB_FRML; i++)
        //    {
        //        if (Charger.arr_CAL_FRML[i] == "") { dlg_arr_frml_NDX = i; break; }
        //        else dlg_arr_CAL_FRML[i] = Charger.arr_CAL_FRML[i];
        //    }
        //}


        //bool frmt_CPTs()
        //{
        //    //  string TD1 = "<td>", TD2 = "</td>";
        //    bool config_OK = true;
        //    string TD1_ERR = "<td style=\"border: 1px solid black;white-space: nowrap;background-color:RED ;color:white \">", TD2_ERR = "</td>";

        //    string TD1 = "<td style=\"border: 1px solid black;white-space: nowrap; \">", TD2 = "</td>";
        //    string TD1_C = "<td style=\"border: 1px solid black; align=\"center\" valign=\"middle\">";
        //    string TD1_blk = "<td style\" white-space: nowrap\">";

        //    string CHKD = "<td style=\"border: 1px solid black;\" align=\"center\" valign=\"middle\"><img src=\"/Images/yes.png\" style=\"width:18%\" /></td>";
        //    string UNCHKD = "<td style=\"border: 1px solid black;\" align=\"center\" valign=\"middle\"><img src=\"/Images/no.png\" style=\"width:18%\" /></td>'";
        //    string FS = TD1_C + "<label style=\"border-radius: 30px;background:green;font-size: 12px;font-weight: bold;color:white;border: 1px dashed #fff; border: solid 2px #6E6E6E\">FS</label>" + TD2;//"<td align=\"center\" valign=\"middle\"><img src=\"/Images/fs2.png\" style=\"width:15%\" /></td>'";
        //    string NFS = TD1_C + "<label style=\"border-radius: 30px;background:gray;font-size: 12px;font-weight: bold;color:white;border: 1px dashed #fff; border: solid 2px #6E6E6E\">NFS</label>" + TD2; ;// "<td align=\"center\" valign=\"middle\"><img src=\"/Images/nfs2.png\" style=\"width:15%\" /></td>'";
        //    string MIN = TD1_C + "<label style=\"border-radius: 30px;background:green;font-size: 12px;font-weight: bold;color:white;border: 1px dashed #fff; border: solid 2px #6E6E6E\">MAJ</label>" + TD2; ;//"<td align=\"center\" valign=\"middle\"><img src=\"/Images/min2.png\" style=\"width:15%\" /></td>'";
        //    string MAJ = TD1_C + "<label style=\"border-radius: 30px;background:gray;font-size: 12px;font-weight: bold;color:white;border: 1px dashed #fff; border: solid 2px #6E6E6E\">MIN</label>" + TD2; ;// "<td align=\"center\" valign=\"middle\"><img src=\"/Images/maj2.png\" style=\"width:15%\" /></td>'";

        //    frmt_defoptions.Clear();
        //    int i = 0;

        //    foreach (chargerItem myCH in lvDefOption_Items)
        //    {
        //        chargerItem frmtcharger = new chargerItem();


        //        frmtcharger.refcpt = TD1 + myCH.refcpt + TD2;

        //        frmtcharger.desc = (myCH.desc.IndexOf("please call PRIMAX") > -1) ? TD1_ERR + myCH.desc + TD2_ERR : TD1 + myCH.desc + TD2;
        //        if (myCH.desc.IndexOf("please call PRIMAX") > -1)
        //        {
        //            config_OK = false;
        //            frmtcharger.msgerror = "2";
        //        }
        //        else frmtcharger.msgerror = "";
        //        frmtcharger.qty = TD1_C + myCH.qty + TD2;
        //        frmtcharger.uprice = TD1_C + myCH.uprice + TD2;
        //        frmtcharger.ext = TD1_C + myCH.ext + TD2;
        //        frmtcharger.dlvdate = TD1_C + myCH.dlvdate + TD2;

        //        frmt_defoptions.Add(frmtcharger);

        //    }

        //    return config_OK;

        //}



        //PGCWEB
        //public JsonResult validate_ups(string p850x, string phsout, string kva, string outV, string DCbus, string phsin, string inV, string phsbps, string bpsIN, string Cbatt, string perfFactr, string timeChrg, string cptid, string vcsname, string FLT, string EQLZ, string vdcmin, string vdcmax, string CBn_ka)

        //{


        //    string msgerror = "";
        //    curr_charger_UPS = new chargerUPS_config();


        //    //fill new vars    
        //    cbPxx_Text = pxx;
        //    cbPhs_Text = phs;
        //    cbVdc_Text = vdc;
        //    cbIdc_Text = idc;
        //    lFV_Text = VF;
        //    typ_Batt = battt;
        //    lRiple_Text = @"<2% @ batteries/NEMA PE5";// lriple;

        //    lhrtz_Text = lhrtz;

        //    tCellN_Text = cellnb;
        //    tvpcF_Text = cof_flt;
        //    tvpcEq_Text = cof_eql;
        //    tvdcMin_Text = vdcmin;
        //    tVdcMax_Text = vdcmax;
        //    tVac_Text = vac;
        //    tVFLOAT_Text = txflt;
        //    tVEQL_Text = txeql;
        //    tIdcMin_Text = idcmax;
        //    tIdcMax_Text = vdcmax;
        //    kaac_Text = kaac;
        //    kadc_Text = kadc;

        //    HttpContext.Session["kaac"] = kaac;
        //    HttpContext.Session["kadc"] = kadc;

        //    //restore and if changed do something


        //    restoreFromhttp();

        //    lChrgREF_Text = cbPxx_Text + "-" + cbPhs_Text + "-" + cbVdc_Text + "-" + cbIdc_Text;
        //    // MainMDI.KAac = "14";
        //    Validate_Charger_CTRL();

        //    bool config_OK = frmt_ChargerItems();
        //    //   saveINhttp();

        //    //   fill_curr_Charger();
        //    //                lst_chconfigs.Add(curr_charger);
        //    string cfid = (HttpContext.Session["cfid"] == null) ? "" : HttpContext.Session["cfid"].ToString();
        //    if (cfid != "") Save_ChargerItems(cfid);
        //    else msgerror = "Can not save this config";
        //    if (!config_OK) msgerror = "2";
        //    return Json(frmt_defoptions, JsonRequestBehavior.AllowGet);


        //}

        //private void Validate_Charger_CTRL()
        //{
        //    string msg1 = "", msg = "";
        //    bool chng = true;
        //    oldVdc_Text = cbVdc_Text;
        //    string v = "";
        //    double MN_EQFLT = Math.Min(Tools.Conv_Dbl(tVEQL_Text), Tools.Conv_Dbl(tVFLOAT_Text));
        //    char c = Valid_Charger();
        //    if (c == 'L' || c == 'H')
        //    {
        //        msg1 = (c == 'L') ? "You may choose a Lower Charger Model....!!!!" : "You may choose a Higher Charger Model....!!!!";
        //        ItemMSGs.msgModel_hl = msg1;
        //        //DialogResult dr = MessageBox.Show(msg1, "Bad Charger Model", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
        //        //if (dr == DialogResult.Yes)

        //        if (true)
        //        {
        //            long AVID = Cal_Valid_Charger(c, Tools.Conv_Dbl(tVdcMax_Text), MN_EQFLT, ref v, cbIdc_Text);
        //            if (v != "")
        //            {
        //                string VX = MainMDI.Std_VCS(cbPhs_Text, AVID, "C_VDCMAX");

        //                string VN = MainMDI.Std_VCS(cbPhs_Text, AVID, "C_VDCMIN");
        //                if (c == 'L' && Tools.Conv_Dbl(tVdcMax_Text) > Tools.Conv_Dbl(VX))
        //                {
        //                    chng = false;
        //                    msg = " Can not Move to Low " + v + "V !!! its VDCMAX is Low...." + "\n" + " The actual Model seems be ideal even its VdcMin is too Low...";
        //                }
        //                if (c == 'H' && MN_EQFLT < Tools.Conv_Dbl(VN)) msg = "Min(EQL,FLT) is too Low...";
        //                if (chng) cbVdc_Text = v;
        //                if (msg != "") ItemMSGs.msg_eqflt = msg;
        //            }
        //            else ItemMSGs.msg_eng = "Please Consult Engineering.... !!!";
        //        }

        //    }
        //    //		if (tVdcMax.Text !=lstdvdcMax.Text   || tVac.Text != lstdVAC.Text )  //seekPrice in XLfiles generated by Pricing
        //    //			fill_Def_options(tVdcMax.Text ,tVac.Text   );
        //    //		else   fill_Def_options();

        //    //added: 26112014  req. by Byad
        //    if (Tools.Conv_Dbl(cbVdc_Text) > 250) ItemMSGs.msg_converter = "All alarms will be disabled \n Please check if DC/DC converter is needed for this application ";


        //    fill_Def_options(tVdcMax_Text, tVac_Text);  // Recalculate all CPT 

        //    //btnCancel.Enabled = lvDefOption.Items.Count > 0;
        //    //btnOK.Enabled = btnCancel.Enabled;
        //    //lnkAlarm.Enabled = true;
        //    //pictureBox2.Enabled = true;


        //}





        //}





        //}
        //void fill_newItem(string refcpt, string desc, string qty, string uprice, string ext, string dlvdate, string cat1, string cat2, string cat3, string cptref, string cptpartnb)
        //{

        //    chargerItem myitem = new chargerItem();

        //    myitem.refcpt = refcpt;// MainMDI.arr_EFSdict[10, L] + " " + lChrgREF_Text;
        //    myitem.desc = desc;

        //    myitem.qty = (uprice == "0") ? "" : qty;//tPxxQty_Text
        //    myitem.uprice = (uprice == "0") ? "" : uprice;
        //    myitem.ext = (uprice == "0") ? "" : ext;
        //    myitem.dlvdate = (uprice == "0") ? "" : dlvdate;
        //    myitem.cat1 = cat1;
        //    myitem.cat2 = cat2;
        //    myitem.cat3 = cat3;
        //    myitem.cptref = cptref;
        //    myitem.cptpartnb = cptpartnb;
        //    myitem.msgerror = "";
        //    //string cost = find_CHARGER_COST(txcbPxx_Text, cbPhs_Text, cbVdc_Text, cbIdc_Text);

        //    //cost = Convert.ToString(Math.Round(Tools.Conv_Dbl(cost) * Tools.Conv_Dbl(lhrtZMRK_Text), 0));
        //    //myitem.uprice = cost;
        //    ////myitem.ext = Convert.ToString(Math.Round(Tools.Conv_Dbl(tPxxQty.Text) * Tools.Conv_Dbl(cost), Charger.NB_DEC_AFF));
        //    //myitem.ext = Convert.ToString(Math.Round(Tools.Conv_Dbl("1") * Tools.Conv_Dbl(cost), Charger.NB_DEC_AFF));
        //    //myitem.dlvdate = "04-06";
        //    lvDefOption_Items.Add(myitem);

        //}



        //PGCWEB ################################


    }
}
