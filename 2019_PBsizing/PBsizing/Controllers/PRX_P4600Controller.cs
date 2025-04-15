using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EAHLibs;
using PBsizing.Controllers;

using System.Data.SqlClient;
using PBsizing;

namespace PBsizing.Controllers
{
    public class PRX_P4600Controller : Controller
    {
        //
        // GET: /PRX_P4600/


        public string lOth_TV = "";

        public string[] dlg_arr_CAL_FRML = new string[Charger.NB_FRML];
        private int dlg_arr_frml_NDX = 0;
        private int L;
        //   private string[,] lvDefOption_Items = new string[100, 12];

        int[] IDClist = new int[32] { 5, 10, 15, 20, 25, 30, 35, 40, 50, 60, 70, 75, 80, 100, 125, 150, 175, 200, 225, 250, 275, 300, 325, 350, 375, 400, 500, 600, 750, 800, 900, 1000 };


        List<Alarm> allALRMlist = new List<Alarm>();
        List<Alarm> allALRMlist_report = new List<Alarm>();
        List<Alarm> allALRMlist_prj = new List<Alarm>();

        List<chargerItem> lvDefOption_Items = new List<chargerItem>(), frmt_defoptions = new List<chargerItem>();


        List<charger_config> lst_chconfigs = new List<charger_config>();
        Charger CHRGR;
        Component Cpt;
        charger_config curr_charger;
        string stSWTCH = "Switch1|swf1=0|swr1=00|swl1=00|swt1=0005|SWLG1=checked|SWPR1=checked|SWCR1=checked|SWDA1=unchecked%%Switch2|swf2=0|swr2=00|swl2=00|swt2=0005|SWLG2=checked|SWPR2=checked|SWCR2=checked|SWDA2=unchecked%%Switch3|swf3=0|swr3=00|swl3=00|swt3=0005|SWLG3=checked|SWPR3=checked|SWCR3=checked|SWDA3=unchecked%%Switch4|swf4=0|swr4=00|swl4=00|swt4=0005|SWLG4=checked|SWPR4=checked|SWCR4=checked|SWDA4=unchecked%%Switch5|swf5=0|swr5=00|swl5=00|swt5=0005|SWLG5=checked|SWPR5=checked|SWCR5=checked|SWDA5=unchecked%%Switch6|swf6=0|swr6=00|swl6=00|swt6=0005|SWLG6=checked|SWPR6=checked|SWCR6=checked|SWDA6=unchecked%%Switch7|swf7=0|swr7=00|swl7=00|swt7=0005|SWLG7=checked|SWPR7=checked|SWCR7=checked|SWDA7=unchecked%%Switch8|swf8=0|swr8=00|swl8=00|swt8=0005|SWLG8=checked|SWPR8=checked|SWCR8=checked|SWDA8=unchecked%%Message1|swmg1=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%Message2|swmg2=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%Message3|swmg3=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%Message4|swmg4=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%Message5|swmg5=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%Message6|swmg6=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%Message7|swmg7=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%Message8|swmg8=nullÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿÿ%%";
        public static Lib1 Tools = new Lib1();
        chargerItem ItemMSGs = new chargerItem();



        class chargerItem
        {
            public string refcpt { get; set; }
            public string desc { get; set; }
            public string qty { get; set; }
            public string uprice { get; set; }
            public string ext { get; set; }
            public string dlvdate { get; set; }
            public string cat1 { get; set; }
            public string cat2 { get; set; }
            public string cat3 { get; set; }
            public string cptref { get; set; }
            public string cptpartnb { get; set; }
            public string msg_IDC { get; set; }
            public string msgModel_hl { get; set; }
            public string msg_eqflt { get; set; }
            public string msg_eng { get; set; }
            public string msg_converter { get; set; }
            public string msg_opt_nfnd { get; set; }
            public string msgerror { get; set; }
        }

        //
        // GET: /TestsReport/
        public string lChrgREF_Text { get; set; }
        public string lhrtZMRK_Text { get; set; }
        public string cbPxx_Text { get; set; }
        public string cbPhs_Text { get; set; }
        public string cbVdc_Text { get; set; }
        public string cbIdc_Text { get; set; }
        public string txcbPxx_Text { get; set; }
        public string lFV_Text { get; set; }
        public string lvpcE_LA_Text { get; set; }
        public string lNBC_NI_Text { get; set; }
        public string lNBC_LA_Text { get; set; }
        public string lVcellMin_NI_Text { get; set; }
        public string lVcellMin_LA_Text { get; set; }
        public string lvpcF_LA_Text { get; set; }
        public string lvpcE_NI_Text { get; set; }
        public string lvpcF_NI_Text { get; set; }
        public string lFLT_EQ_SEC_Text { get; set; }
        public string lIprim_Text { get; set; }
        public string lstdvdcMin_Text { get; set; }
        public string lstdvdcMax_Text { get; set; }
        public string lstdVAC_Text { get; set; }
        public string lRiple_Text { get; set; }
        public string kaac_Text { get; set; }
        public string kadc_Text { get; set; }
        public string lVSECLN_Text { get; set; }
        public string lVSECLL_Text { get; set; }
        public string lIsh_Text { get; set; }
        public string lW2_Text { get; set; }

        public string tCellN_Text { get; set; }

        public string tVdcMax_Text { get; set; }
        public string tvdcMin_Text { get; set; }
        public string tVac_Text { get; set; }
        public string typ_Batt { get; set; }
        public string lstdCellN_Text { get; set; }
        public string tvpcEq_Text { get; set; }
        public string tvpcF_Text { get; set; }
        public string tVEQL_Text { get; set; }
        public string tVFLOAT_Text { get; set; }
        public string lNcelCoef_Text { get; set; }
        public string lhrtz_Text { get; set; }
        public string tIdcMin_Text { get; set; }
        public string tIdcMax_Text { get; set; }

        public int cof_FLT_chngd { get; set; } //1:chnged  0:not
        public int cof_EQL_chngd { get; set; }
        public int nbcell_chngd { get; set; }

        public string oldVdc_Text { get; set; }

        public class charger_config
        {
            public string lChrgREF_Text { get; set; }
            public string cbPxx_Text { get; set; }
            public string cbPhs_Text { get; set; }
            public string cbVdc_Text { get; set; }
            public string cbIdc_Text { get; set; }
            public string txcbPxx_Text { get; set; }
            public string lFV_Text { get; set; }
            public string lvpcE_LA_Text { get; set; }
            public string lNBC_NI_Text { get; set; }
            public string lNBC_LA_Text { get; set; }
            public string lVcellMin_NI_Text { get; set; }
            public string lVcellMin_LA_Text { get; set; }
            public string lvpcF_LA_Text { get; set; }
            public string lvpcE_NI_Text { get; set; }
            public string lvpcF_NI_Text { get; set; }
            public string lFLT_EQ_SEC_Text { get; set; }
            public string lIprim_Text { get; set; }
            public string lstdvdcMin_Text { get; set; }
            public string lstdvdcMax_Text { get; set; }
            public string lstdVAC_Text { get; set; }
            public string lRiple_Text { get; set; }

            public string lVSECLN_Text { get; set; }
            public string lVSECLL_Text { get; set; }
            public string lIsh_Text { get; set; }
            public string lW2_Text { get; set; }

            public string tCellN_Text { get; set; }

            public string tVdcMax_Text { get; set; }
            public string tvdcMin_Text { get; set; }
            public string tVac_Text { get; set; }
            public string typ_Batt { get; set; }
            public string lstdCellN_Text { get; set; }
            public string tvpcEq_Text { get; set; }
            public string tvpcF_Text { get; set; }
            public string tVEQL_Text { get; set; }
            public string tVFLOAT_Text { get; set; }
            public string lNcelCoef_Text { get; set; }
            public string lhrtz_Text { get; set; }
            public string tIdcMin_Text { get; set; }
            public string tIdcMax_Text { get; set; }

            public int vdc_chngd { get; set; } //1:chnged  0:not
            public int idc_chngd { get; set; }
            public int nbcell_chngd { get; set; }
            public string msgerror { get; set; }

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
            public string AEN { get; set; }
            //      public string AENtxt = "Enabled";


        }
        class Charger_old
        {

            public List<Alarm> AlarmsList = new List<Alarm>();

            public void Fill_AlarmsList(string Alarms_cgi)
            {




            }



        }


        //########################

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Valid_P4600()
        {


            string para = "", usr = "", opera = "", qtnb = "", pgcid = "";

            if (HttpContext.Session["usr"] != null && HttpContext.Session["usr"].ToString() == "ede")
            {
                HttpContext.Session["usr"] = "ede";
                HttpContext.Session["qtnb"] = "23544"; ;
                HttpContext.Session["pgcid"] = "123";
                HttpContext.Session["opera"] = "pgc";

                //   ViewBag.userName = usr + "/QT" + qtnb;
                ViewBag.Qnb = "Q#" + HttpContext.Session["qtnb"].ToString ();
                return View();
            }
            else
            {


                if (HttpContext.Session["usr"] != null && HttpContext.Session["opera"] != null && HttpContext.Session["qtnb"] != null)
                {


                    //int MM = 0, YYYY = 0;
                    //CMS_period_MMYYYY(ref MM, ref YYYY);
                    //ViewBag.mmyyyy = MainMDI.A00(MM, 2) + "/" + YYYY.ToString();
                    // 
                    usr = HttpContext.Session["usr"].ToString();
                    opera = HttpContext.Session["opera"].ToString();
                    qtnb = HttpContext.Session["qtnb"].ToString();
                    pgcid = HttpContext.Session["pgcid"].ToString();
                    if (opera != "" && qtnb != "" && pgcid != "")
                    {


                        //      ViewBag.userName = usr + "/QT" + qtnb;
                        ViewBag.Qnb = "Q#" + qtnb;
                        return View();
                    }
                    else
                    {
                        ViewBag.errormsg = "ACCES DENIED.....error keys access....";
                        return View("~/Views/Shared/Error.cshtml");
                    }

                    //   return View("~/Views/ALLUPS/UPS-schema.cshtml");

                }
                else
                {
                    para = Request.Url.Query;
                    if (XTRCT_paraQRY(para, ref usr, ref opera, ref qtnb, ref pgcid))
                    {
                        HttpContext.Session["usr"] = usr;
                        HttpContext.Session["qtnb"] = qtnb;
                        HttpContext.Session["pgcid"] = pgcid;
                        HttpContext.Session["opera"] = opera;


                        ViewBag.Qnb = "Q#" + HttpContext.Session["qtnb"].ToString();
                        return View();

                    }
                    else
                    {
                        ViewBag.errormsg = "ACCES DENIED.....error keys access....";
                        return View("~/Views/Shared/Error.cshtml");
                    }

                    // return View("ERROR_NOSIZING");
                    //  return View("~/Views/Shared/logon.cshtml");
                    //View("~/Views/Home/ERROR_NOSIZING.cshtml");
                }
            }


            //else return View("~/Views/Shared/Error.cshtml");


            //return View();

        }

        private bool XTRCT_paraQRY(string STin, ref string u, ref string op, ref string qtnb, ref string cfid)
        {
            u = ""; op = ""; qtnb = ""; cfid = "";
            bool ok = false;
            int fpos = STin.IndexOf("=");
            if (STin[0] == '?' && fpos > -1)
            {

                string[] para = new string[4] { "", "", "", "" };

                para = STin.Split('&');
                for (int i = 0; i < 4; i++)
                {
                    switch (i)
                    {
                        case 0:
                            string[] inf = para[i].Split('=');
                            u = inf[1];
                            break;
                        case 1:
                            inf = para[i].Split('=');
                            op = inf[1];
                            break;
                        case 2:
                            inf = para[i].Split('=');
                            qtnb = inf[1];
                            break;
                        case 3:
                            inf = para[i].Split('=');
                            cfid = inf[1];
                            break;

                    }
                }
                if (u != "" && op == "pgc" && qtnb != "" && cfid != "") ok = true;
            }
            else ok = false;
            return ok;

        }




    private void Validate_Charger_CTRL()
        {
            string msg1 = "", msg = "";
            bool chng = true;
            oldVdc_Text = cbVdc_Text;
            string v = "";
            double MN_EQFLT = Math.Min(Tools.Conv_Dbl(tVEQL_Text), Tools.Conv_Dbl(tVFLOAT_Text));
            char c = Valid_Charger();
            if (c == 'L' || c == 'H')
            {
                msg1 = (c == 'L') ? "You may choose a Lower Charger Model....!!!!" : "You may choose a Higher Charger Model....!!!!";
                ItemMSGs.msgModel_hl = msg1;
                //DialogResult dr = MessageBox.Show(msg1, "Bad Charger Model", MessageBoxButtons.YesNo, MessageBoxIcon.Question); ;
                //if (dr == DialogResult.Yes)

                if (true)
                {
                    long AVID = Cal_Valid_Charger(c, Tools.Conv_Dbl(tVdcMax_Text), MN_EQFLT, ref v, cbIdc_Text);
                    if (v != "")
                    {
                        string VX = MainMDI.Std_VCS(cbPhs_Text, AVID, "C_VDCMAX");

                        string VN = MainMDI.Std_VCS(cbPhs_Text, AVID, "C_VDCMIN");
                        if (c == 'L' && Tools.Conv_Dbl(tVdcMax_Text) > Tools.Conv_Dbl(VX))
                        {
                            chng = false;
                            msg = " Can not Move to Low " + v + "V !!! its VDCMAX is Low...." + "\n" + " The actual Model seems be ideal even its VdcMin is too Low...";
                        }
                        if (c == 'H' && MN_EQFLT < Tools.Conv_Dbl(VN)) msg = "Min(EQL,FLT) is too Low...";
                        if (chng) cbVdc_Text = v;
                        if (msg != "") ItemMSGs.msg_eqflt = msg;
                    }
                    else ItemMSGs.msg_eng = "Please Consult Engineering.... !!!";
                }

            }
            //		if (tVdcMax.Text !=lstdvdcMax.Text   || tVac.Text != lstdVAC.Text )  //seekPrice in XLfiles generated by Pricing
            //			fill_Def_options(tVdcMax.Text ,tVac.Text   );
            //		else   fill_Def_options();

            //added: 26112014  req. by Byad
            if (Tools.Conv_Dbl(cbVdc_Text) > 250) ItemMSGs.msg_converter = "All alarms will be disabled \n Please check if DC/DC converter is needed for this application ";


            fill_Def_options(tVdcMax_Text, tVac_Text);  // Recalculate all CPT 

            //btnCancel.Enabled = lvDefOption.Items.Count > 0;
            //btnOK.Enabled = btnCancel.Enabled;
            //lnkAlarm.Enabled = true;
            //pictureBox2.Enabled = true;


        }
        private void fill_Def_options(string m_vdcMax, string m_Vac)
        {
            //   t1.Text = System.DateTime.Now.Second.ToString();
            //   this.Cursor = Cursors.WaitCursor;

            if (MainMDI.arr_EFSdict[0, 0] == null) MainMDI.init_Dict();
            string KAac = HttpContext.Session["kaac"].ToString(), KAdc = HttpContext.Session["kadc"].ToString();

            //old
            // string stSql = "select * from Configo_COMPNT_LIST where Compnt_Type='E' or Compnt_Type='D'  order by Component_ID";
            //new
            string stSql = "select * from Configo_COMPNT_LIST where Compnt_Type='E' or Compnt_Type='D'   order by component_ref ";


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int debut = 0;
            //  lvDefOption.Items.Clear();
            //    for (int i = 0; i < 200; i++) for (int j = 0; j < 12; j++) lvDefOption_Items[i, j] = "";
            lvDefOption_Items.Clear();
            while (Oreadr.Read())
            {
                if (debut == 0)
                {
                    //CHRGR  =new Charger(0 ,lFV.Text , txcbPxx.Text ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text,tVac.Text,tVdcMax.Text );
                    CHRGR = new Charger(0, lFV_Text, txcbPxx_Text.Substring(0, 5), cbPhs_Text, cbVdc_Text, cbIdc_Text, tVac_Text, tVdcMax_Text);
                    debut = 1;

                }
                Cpt = new Component();  //CB2==> E ~ Configo_COMPNT_LIST    (S=disabled)

                string tt =  Cpt.Cal_chrg_CostADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()), "C", KAac, KAdc);
                lIprim_Text = Cpt.Cal_VCS(0, "C_IPRIM");
                lhrtZMRK_Text = Cpt.Cal_VCS(0, "C_HRTZ" + lhrtz_Text);

                if (tt == MainMDI.VIDE)
                    ItemMSGs.msg_opt_nfnd = (ItemMSGs.msg_opt_nfnd == "") ? "This default option: " + "\n" + Oreadr["COMPONENT_REF"].ToString() + " was not found " : "\n" + Oreadr["COMPONENT_REF"].ToString() + " was not found ";
                else
                {

                    if (lvDefOption_Items.Count == 0) addchRef();

                    if (Cpt.G_PRICE != Charger.VIDE)
                    {


                        string stt = "";
                        stt += (Cpt.CAP4 == MainMDI.VIDE) ? "" : " " + Cpt.CAP4;
                        stt += (Cpt.CAP5 == MainMDI.VIDE) ? "" : " " + Cpt.CAP5;
                        stt += (Cpt.CAP6 == MainMDI.VIDE) ? "" : " " + Cpt.CAP6;
                        stt += (Cpt.CAP7 == MainMDI.VIDE) ? "" : " " + Cpt.CAP7;

                        string cat1 = Oreadr["CatName1"].ToString() + "=" + Cpt.CAP1.ToString();
                        string cat2 = (Oreadr["CatName2"].ToString() != Charger.VIDE) ? Oreadr["CatName2"].ToString() + "=" + Cpt.CAP2.ToString() : "";
                        string cat3 = (Oreadr["CatName3"].ToString() != Charger.VIDE) ? Oreadr["CatName3"].ToString() + "=" + Cpt.CAP3.ToString() : "";

                        if (Oreadr["Component_ID"].ToString() != "147" && Oreadr["Component_ID"].ToString() != "226") fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), stt, "", "", "", "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), Cpt.G_Desc);
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

                                    HttpContext.Session["def_147_price"] = Cpt.G_PRICE;
                                    HttpContext.Session["def_147_ka"] = "";
                                }

                                //added 14082019
                                double def_price = Tools.Conv_Dbl(HttpContext.Session["def_147_price"].ToString());
                                double currPrice = Tools.Conv_Dbl(Cpt.G_PRICE);


                                if (Cpt.G_PRICE == "-99999") fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt.G_Desc, "", "", "", "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
                                else
                                {

                                    if (Tools.Conv_Dbl(KAac) > 0 || currPrice > def_price) fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt.G_Desc, "1", Cpt.G_PRICE, Cpt.G_PRICE, "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
                                    else fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt.G_Desc, "", "", "", "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
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

                                    HttpContext.Session["def_226_price"] = Cpt.G_PRICE;
                                    HttpContext.Session["def_226_ka"] = "";
                                }
                                double def_price = Tools.Conv_Dbl(HttpContext.Session["def_226_price"].ToString());
                                double currPrice = Tools.Conv_Dbl(Cpt.G_PRICE);

                                if (Cpt.G_PRICE == "-99999") fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt.G_Desc, "", "", "", "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
                                else
                                {

                                    if (Tools.Conv_Dbl(KAdc) > 0 || currPrice > def_price) fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt.G_Desc, "1", Cpt.G_PRICE, Cpt.G_PRICE, "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
                                    else fill_newItem(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()), Cpt.G_Desc, "", "", "", "", cat1, cat2, cat3, Oreadr["COMPONENT_REF"].ToString(), "");
                                }

                            }
                        }
                    }

                }
            }
            //	 lIprim.Text = Cpt.Cal_VCS(0,"C_IPRIM");

            if (lvDefOption_Items.Count != 0) addSTDFeat();
            OConn.Close();
            //     this.Cursor = Cursors.Default;
            //t2.Text = System.DateTime.Now.Second.ToString (); 
        }

        private bool valSTD_changed()
        {
            return (lstdCellN_Text != tCellN_Text || lstdVAC_Text != tVac_Text || lstdvdcMin_Text != tvdcMin_Text || lstdvdcMax_Text != tVdcMax_Text);
            //	          MessageBox.Show("Please Check the calculated components PRICES, since standard values were changed !!!");
        }
        private char Valid_Charger()
        {
            double dMin = Tools.Conv_Dbl(lstdvdcMin_Text);
            double dMin_FL_EQ = Math.Min(Tools.Conv_Dbl(tVFLOAT_Text), Tools.Conv_Dbl(tVEQL_Text));
            double dMaxCal = Tools.Conv_Dbl(tVdcMax_Text);
            double dMax = Tools.Conv_Dbl(lstdvdcMax_Text);
            if (dMaxCal > dMax) return 'H';
            else if (dMin_FL_EQ < dMin) return 'L';
            return 'R';
        }
        private long Cal_Valid_Charger(char c, double m_vdcMAX, double m_vdcMin, ref string V, string I)
        {

            string stSql = "";
            V = "";
            if (c == 'H') stSql = "SELECT BGF_VCS13.*, TBLAVAIL1.charger, TBLAVAIL1.vdc, TBLAVAIL1.idc FROM BGF_VCS13 INNER JOIN TBLAVAIL1 ON BGF_VCS13.Avail_ID = TBLAVAIL1.Avail_ID " +
                              " WHERE (((BGF_VCS13.VCS_NAME)='C_VDCMAX') AND (TBLAVAIL1.idc='" + I + "') AND ((cast([BGF_VCS13].[Value] AS float))>=" + m_vdcMAX + " )) AND ((BGF_VCS13.phs)='" + Charger.P + "')" +
                              " ORDER BY cast([BGF_VCS13].[Value] AS float)";

            else stSql = "SELECT BGF_VCS13.*, TBLAVAIL1.charger, TBLAVAIL1.vdc, TBLAVAIL1.idc " +
                     " FROM BGF_VCS13 INNER JOIN TBLAVAIL1 ON BGF_VCS13.Avail_ID = TBLAVAIL1.Avail_ID " +
                     " WHERE (((BGF_VCS13.VCS_NAME)='C_VDCMIN') AND (TBLAVAIL1.idc='" + I + "') AND ((cast([BGF_VCS13].[Value] AS float))<=" + m_vdcMin + ")) AND ((BGF_VCS13.phs)='" + Charger.P + "') " +
                     " ORDER BY cast([BGF_VCS13].[Value] AS float) DESC";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                V = Oreadr["vdc"].ToString();
                return Convert.ToInt32(Oreadr["Avail_ID"].ToString());
            }
            OConn.Close();
            return 0;
        }




        private void dlg_arr_frml_fill()
        {
            for (int i = 0; i < Charger.NB_FRML; i++)
            {
                if (Charger.arr_CAL_FRML[i] == "") { dlg_arr_frml_NDX = i; break; }
                else dlg_arr_CAL_FRML[i] = Charger.arr_CAL_FRML[i];
            }
        }
        private void dlg_arr_frml_Ovals()
        {

            dlg_arr_CAL_FRML[dlg_arr_frml_NDX++] = "Float||" + tVFLOAT_Text;
            dlg_arr_CAL_FRML[dlg_arr_frml_NDX++] = "Eq||" + tVEQL_Text;
            dlg_arr_CAL_FRML[dlg_arr_frml_NDX++] = "RPL||" + lRiple_Text;
            dlg_arr_CAL_FRML[dlg_arr_frml_NDX++] = "FHZ||" + lhrtz_Text;




            ////add 280606
            //for (int i = 0; i < lvOTI.Items.Count; i++)
            //{
            //    for (int j = 4; j < 7; j++)
            //    {
            //        if (lvOTI.Items[i].SubItems[j].Text != MainMDI.VIDE)
            //        {
            //            string cpT = (lvOTI.Items[i].Checked) ? cal_CPT(-1, lvOTI.Items[i].SubItems[j].Text.Substring(2, lvOTI.Items[i].SubItems[j].Text.Length - 2)) : MainMDI.VIDE;
            //            dlg_arr_CAL_FRML[dlg_arr_frml_NDX++] = lvOTI.Items[i].SubItems[j].Text + "||" + cpT;
            //        }
            //    }

            //}
            ////add 280606



        }



        private void AddTec_Values(string st0, string st, bool SHW, string cptREF)
        {


            fill_newItem(st0, st, "", "", "", "", "", "", "", cptREF, "");



        }
        private void addSTDFeat()
        {

            //AddTec_Values("","Cell#: " + tCellN.Text + ", VAC:" + tVac.Text +", Float: " + tVFLOAT.Text + ", Equalize: " + tVEQL.Text  ,true ); 
            dlg_arr_frml_fill();
            AddTec_Values("", "VAC:" + tVac_Text + ", Float: " + tVFLOAT_Text + ", Equalize: " + tVEQL_Text, true, "C_VFE");
            //if (!tRPL.ReadOnly && tRPL_Text != "") lRiple_Text = tRPL_Text;
            //else tRPL_Text = lRiple_Text;
            //tRPL.ReadOnly = true;
            //   AddTec_Values("",MainMDI.arr_EFSdict[19,L ] + " " + lRiple.Text + " " +  MainMDI.arr_EFSdict[20,L ],true,"C_RPL" );
            AddTec_Values("", MainMDI.arr_EFSdict[19, L] + " " + lRiple_Text, true, "C_RPL");
            dlg_arr_frml_Ovals();
            //dlg_Arr_frml_Disp(); 
            string stSql = "select * from PSM_ALLSTD where ItemCode='C' order by rnk";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            //		AddTec_Values("",MainMDI.arr_EFSdict[18,L ]+"=   " ,true,"D_" ); 
            while (Oreadr.Read())
            {
                if (Oreadr[L + 2].ToString() != "" && Oreadr["disp"].ToString() == "1") AddTec_Values("", Oreadr[L + 2].ToString(), true, "D_");
            }


        }

        int cbidc_find(string _idc)
        {

            for (int i = 0; i < IDClist.Length; i++)
                if (IDClist[i].ToString() == _idc) return i;
            return -1;
        }
        private string find_CHARGER_COST_PGESCOM_way(string _PXX, string _PHS, string _VDC, string _IDC)
        {
            double dd = 0;
            bool loop = false;
            //  _PXX.Replace("4600", "4500");  
            while (dd == 0)
            {
                dd = Tools.Conv_Dbl(find_CHARGER_COST_loop(_PXX, _PHS, _VDC, _IDC));
                if (dd == 0)
                {
                    if (!loop)
                    {
                        loop = true;
                        ItemMSGs.msg_IDC = "The PRICE for this Charger is Not Available, so Continue with the Next IDC..... ";
                    }
                    if (loop)
                    {
                        int ndx = cbidc_find(_IDC);
                        if (ndx == -1) dd = 9999999;
                        else _IDC = IDClist[ndx + 1].ToString();
                    }
                    else dd = 9999999;

                }

            }

            return dd.ToString(); ;
        }
        private string find_CHARGER_COST(string _PXX, string _PHS, string _VDC, string _IDC)
        {
            //            string stSql = " SELECT TBLTOXL0" + PHS + ".* FROM TBLTOXL0" + PHS + " WHERE (TBLTOXL0" + PHS + ".COMPONENT='" + PXX + "_LIST') AND (TBLTOXL0" + PHS + ".REF_CHRG='" + PXX + "_LIST-" + VDC + "' OR TBLTOXL0" + PHS + ".REF_CHRG='" + PXX + "-" + PHS +"-" + VDC + "')";
            string stSql = " SELECT * FROM configo_TBLTOXL13 WHERE (configo_TBLTOXL13.REF_CHRG='" + _PXX + "-" + _PHS + "-" + _VDC + "')";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                double dd = Tools.Conv_Dbl(Oreadr[_IDC].ToString());
                return Math.Round(dd, 0).ToString();
            }

            return Charger.VIDE;


        }

        private string find_CHARGER_COST_loop(string PXX, string PHS, string VDC, string IDC)
        {
            //            string stSql = " SELECT TBLTOXL0" + PHS + ".* FROM TBLTOXL0" + PHS + " WHERE (TBLTOXL0" + PHS + ".COMPONENT='" + PXX + "_LIST') AND (TBLTOXL0" + PHS + ".REF_CHRG='" + PXX + "_LIST-" + VDC + "' OR TBLTOXL0" + PHS + ".REF_CHRG='" + PXX + "-" + PHS +"-" + VDC + "')";
            string stSql = " SELECT TBLTOXL0" + PHS + ".* FROM TBLTOXL0" + PHS + " WHERE (TBLTOXL0" + PHS + ".COMPONENT='" + PXX + "_LIST') AND (TBLTOXL0" + PHS + ".REF_CHRG='" + PXX + "_LIST-" + VDC + "' OR TBLTOXL0" + PHS + ".REF_CHRG='" + "P4500" + "-" + PHS + "-" + VDC + "')";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read()) return Oreadr[IDC].ToString();
            return Charger.VIDE;


        }



        void fill_newItem(string refcpt, string desc, string qty, string uprice, string ext, string dlvdate, string cat1, string cat2, string cat3, string cptref, string cptpartnb)
        {

            chargerItem myitem = new chargerItem();

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
        private void addchRef()
        {

            //chargerItem myitem = new chargerItem();
            string cost = find_CHARGER_COST(txcbPxx_Text, cbPhs_Text, cbVdc_Text, cbIdc_Text);
            string ext = Convert.ToString(Math.Round(Tools.Conv_Dbl("1") * Tools.Conv_Dbl(cost), Charger.NB_DEC_AFF));
            fill_newItem(MainMDI.arr_EFSdict[10, L] + " " + lChrgREF_Text.Replace("P4500", "P4600"), " ", "1", cost, ext, "04-06", "", "", "", "", "");

            fill_newItem(MainMDI.arr_EFSdict[11, L], lChrgREF_Text.Replace("P4500", "P4600"), "", "", "", "", "", "", "", "", "");

            //skiped BOM
            //lvI.SubItems[11].Text = find_EDrw_BOM(txcbPxx.Text, cbPhs.Text, cbVdc.Text, cbIdc.Text);

            string dsc = tVac_Text + " " + MainMDI.arr_EFSdict[13, L] + " +10/-12%, " + cbPhs_Text + " " + MainMDI.arr_EFSdict[43, L] + ", " + lhrtz_Text + " Hertz, " + Math.Round(Tools.Conv_Dbl(lIprim_Text), 0) + " A";
            fill_newItem(MainMDI.arr_EFSdict[12, L], dsc, "", "", "", "", "", "", "", "C_IV", "");



            dsc = cbVdc_Text + " " + MainMDI.arr_EFSdict[15, L] + " " + MainMDI.arr_EFSdict[32, L] + ":" + "     Min " + MainMDI.arr_EFSdict[15, L] + ": " + tvdcMin_Text + "     Max " + MainMDI.arr_EFSdict[15, L] + ": " + tVdcMax_Text;
            fill_newItem(MainMDI.arr_EFSdict[14, L], dsc, "", "", "", "", "", "", "", "C_OV", "");


            dsc = cbIdc_Text + " " + MainMDI.arr_EFSdict[17, L] + " " + MainMDI.arr_EFSdict[32, L] + ":" + "     Min " + MainMDI.arr_EFSdict[33, L] + ": " + tIdcMin_Text + "     Max " + MainMDI.arr_EFSdict[33, L] + ": " + tIdcMax_Text;
            fill_newItem(MainMDI.arr_EFSdict[16, L], dsc, "", "", "", "", "", "", "", "C_OC", "");

        }

        bool frmt_ChargerItems()
        {
            //  string TD1 = "<td>", TD2 = "</td>";
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

            frmt_defoptions.Clear();
            int i = 0;

            foreach (chargerItem myCH in lvDefOption_Items)
            {
                chargerItem frmtcharger = new chargerItem();


                frmtcharger.refcpt = TD1 + myCH.refcpt + TD2;

                frmtcharger.desc = (myCH.desc.IndexOf("please call PRIMAX") > -1) ? TD1_ERR + myCH.desc + TD2_ERR : TD1 + myCH.desc + TD2;
                if (myCH.desc.IndexOf("please call PRIMAX") > -1)
                {
                    config_OK = false;
                    frmtcharger.msgerror = "2";
                }
                else frmtcharger.msgerror = "";
                frmtcharger.qty = TD1_C + myCH.qty + TD2;
                frmtcharger.uprice = TD1_C + myCH.uprice + TD2;
                frmtcharger.ext = TD1_C + myCH.ext + TD2;
                frmtcharger.dlvdate = TD1_C + myCH.dlvdate + TD2;

                frmt_defoptions.Add(frmtcharger);

            }

            return config_OK;

        }


        void viderCF(string cfid)
        {


            //   MainMDI.Exec_SQL_JFS("delete Configo_cf_info where cflid=" + cfid, " Configo delete cf ..", HttpContext.Session["usr"].ToString());
            MainMDI.Exec_SQL_JFS("delete Configo_cf_details where confID=" + cfid, " Configo delete cf details..", HttpContext.Session["usr"].ToString());


        }
        void Save_ChargerItems(string confID,string frml_tv)
        {
          //  bool saved = false;
            string usr = HttpContext.Session["usr"].ToString();

            MainMDI.Exec_SQL_JFS("delete Configo_cf_details where confID=" + confID, " Configo delete cf details..", usr);

            int iaffid = 1, rnk = 1;
            foreach (chargerItem myCH in lvDefOption_Items)
            {
                string TVA = (iaffid == 1) ? frml_tv : "";
                //saved = true;
                chargerItem frmtcharger = new chargerItem();
                string staffid = (myCH.ext == "") ? " " : iaffid++.ToString();
                string st_optref = myCH.refcpt.Replace("'", "''");
                string st_DESC = myCH.desc.Replace("'", "''");
                string stSql = "INSERT INTO Configo_cf_details ([confID],[affID], [optref], " +
                    " [Itemdesc],[qty],[mult],[uprice], [xchng],[ext],[leadtime],[rnk],[pn] ,[tecVal],[itmgrp],[sext],[aext],[itmid]) VALUES ('" +
                    confID + "', '" +
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
          TVA  + "', '" +  //tecval
            "A" + "', " +  //itmgrp
              "0" + ", " +  //sext
                "0" + ", " +  //aext
                  "0" + ")";   //itmid

                MainMDI.Exec_SQL_JFS(stSql, " Configo insert cf deails", usr);



            }
       //     if (saved) sav_TVA(cfid,TVA)

        }





        public JsonResult validate_charger(string pxx, string phs, string vdc, string idc, string VF, string battt, string lhrtz, string lriple,
                                     string cellnb, string vac, string cof_flt, string cof_eql, string txeql, string txflt, string vdcmin, string idcmin, string vdcmax, string idcmax,
                                     string kaac, string kadc)
        {


            string msgerror = "";
            curr_charger = new charger_config();
            if (Tools.Conv_Dbl(cellnb) == 0) msgerror = "Cell # is Invalid...";
            if (Tools.Conv_Dbl(vac) == 0) msgerror = "VAC  # is Invalid...";
            if (Tools.Conv_Dbl(cof_flt) == 0) msgerror = "Vpc Float is Invalid...";
            if (Tools.Conv_Dbl(cof_eql) == 0) msgerror = " Vpc Equalize  # is Invalid...";

            //fill new vars    
            cbPxx_Text = pxx;
            cbPhs_Text = phs;
            cbVdc_Text = vdc;
            cbIdc_Text = idc;
            lFV_Text = VF;
            typ_Batt = battt;
            lRiple_Text = @"<2% @ batteries/NEMA PE5";// lriple;

            lhrtz_Text = lhrtz;

            tCellN_Text = cellnb;
            tvpcF_Text = cof_flt;
            tvpcEq_Text = cof_eql;
            tvdcMin_Text = vdcmin;
            tVdcMax_Text = vdcmax;
            tVac_Text = vac;
            tVFLOAT_Text = txflt;
            tVEQL_Text = txeql;
            tIdcMin_Text = idcmax;
            tIdcMax_Text = vdcmax;
            kaac_Text = kaac;
            kadc_Text = kadc;

            HttpContext.Session["kaac"] = kaac;
            HttpContext.Session["kadc"] = kadc;

            //restore and if changed do something


            restoreFromhttp();

            lChrgREF_Text = cbPxx_Text + "-" + cbPhs_Text + "-" + cbVdc_Text + "-" + cbIdc_Text;
            // MainMDI.KAac = "14";
            Validate_Charger_CTRL();

            fill_OTV();
            string tt = lOth_TV;
            string TVA = fill_TVA();

            bool config_OK = frmt_ChargerItems();
            //   saveINhttp();

            //   fill_curr_Charger();
            //                lst_chconfigs.Add(curr_charger);
            string cfid = (HttpContext.Session["cfid"] == null) ? "" : HttpContext.Session["cfid"].ToString();
            if (cfid != "") Save_ChargerItems(cfid,TVA);
            else msgerror = "Can not save this config";
            if (!config_OK) msgerror = "2";
            return Json(frmt_defoptions, JsonRequestBehavior.AllowGet);


        }

        string fill_TVA()
        {
            string lFrml = "";
            string model = lvDefOption_Items[0].refcpt;
            //	int ipos= model.IndexOf("charger")+8;
            string st = MainMDI.arr_EFSdict[39, MainMDI.Lang];
            int ipos = model.IndexOf(st) + st.Length + 1;
            if (ipos > -1) model = model.Substring(ipos, model.Length - ipos);
            else model = "????";
            for (int y = 0; y < Charger.NB_FRML; y++)
            {
                if (dlg_arr_CAL_FRML[y] != "" && dlg_arr_CAL_FRML[y] !=null)
                    lFrml += " " + dlg_arr_CAL_FRML[y];
                else y= Charger.NB_FRML;
            }
         //   B_model = model;
            lFrml += " C_MODEL||" + model + " C_TCC||A";
            // here add TV value to TEC_Val
            lFrml += " " + lOth_TV;
          //  add_LVO(1, 0, ItemCount.ToString(), frmchdlg.lvDefOption.Items[i].SubItems[1].Text, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text, frmchdlg.lvDefOption.Items[i].SubItems[11].Text, lFrml, "A");
            // arr_Tech_values[lvQITEMS.Items.Count -1]=lFrml; 
            //30052014 ede

            return lFrml;
        }



        public JsonResult refresh_vals(string pxx, string phs, string vdc, string idc, string VF, string battt, string lhrtz, string lriple,
                                       string cellnb, string vac, string cof_flt, string cof_eql, string txeql, string txflt, string vdcmin, string idcmin, string vdcmax, string idcmax)
        {

            string msgerror = "";
            curr_charger = new charger_config();
            if (Tools.Conv_Dbl(cellnb) == 0) msgerror = "Cell # is Invalid...";
            if (Tools.Conv_Dbl(vac) == 0) msgerror = "VAC  # is Invalid...";
            if (Tools.Conv_Dbl(cof_flt) == 0) msgerror = "Vpc Float is Invalid...";
            if (Tools.Conv_Dbl(cof_eql) == 0) msgerror = " Vpc Equalize  # is Invalid...";

            if (msgerror == "")
            {


                //fill new vars    
                cbPxx_Text = pxx;
                cbPhs_Text = phs;
                cbVdc_Text = vdc;
                cbIdc_Text = idc;
                lFV_Text = VF;
                typ_Batt = battt;
                lRiple_Text = lriple;
                lhrtz_Text = lhrtz;

                tCellN_Text = cellnb;
                tvpcF_Text = cof_flt;
                tvpcEq_Text = cof_eql;
                tvdcMin_Text = vdcmin;
                tVdcMax_Text = vdcmax;
                tVac_Text = vac;
                tVFLOAT_Text = txflt;
                tVEQL_Text = txeql;
                tIdcMin_Text = idcmax;
                tIdcMax_Text = vdcmax;

                //restore and if changed do something

                restoreFromhttp();


                Maj_VDCMax();  //if nbcell or cofE or cofF changed

                saveINhttp();
                fill_curr_Charger();

                lst_chconfigs.Add(curr_charger);
                return Json(lst_chconfigs, JsonRequestBehavior.AllowGet);
            }
            else
            {
                fill_curr_Charger_ERROR(msgerror);
                lst_chconfigs.Add(curr_charger);
                return Json(lst_chconfigs, JsonRequestBehavior.AllowGet);
            }

        }

  





        public JsonResult valida_ch_info(string pxx, string phs, string vdc, string idc, string VF, string battt, string lhrtz, string lriple)
        {
            curr_charger = new charger_config();

            if (HttpContext.Session["usr"] == null)
            {
                fill_Wrong_Charger();
                lst_chconfigs.Add(curr_charger);
                return Json(lst_chconfigs, JsonRequestBehavior.AllowGet);
            }
            else
            {

                string cfid = (HttpContext.Session["cfid"] == null) ? "" : HttpContext.Session["cfid"].ToString();
                if (cfid == "") createNewCF_cfgo2();//usr_pgc
                cfid = (HttpContext.Session["cfid"] == null) ? "" : HttpContext.Session["cfid"].ToString();
                if (cfid == MainMDI.VIDE) cfid = "";
                else if (!MainMDI.Creat_TempTbls(Int32.Parse(cfid))) ViewBag.error = ".....ERROR temp Files......";

                init_AllValues();

                cbPxx_Text = pxx;
                cbPhs_Text = phs;
                cbVdc_Text = vdc;
                cbIdc_Text = idc;
                lFV_Text = VF;
                typ_Batt = battt;
                lRiple_Text = lriple;
                lhrtz_Text = lhrtz;

                tCellN_Text = "";
                tvpcF_Text = "";
                tvpcEq_Text = "";
                tvdcMin_Text = "";
                tVdcMax_Text = "";
                tVac_Text = "";
                tVFLOAT_Text = "";
                tVEQL_Text = "";
                tIdcMin_Text = "";
                tIdcMax_Text = "";

                vider_http();
                selCHRGR();

                if (lFV_Text == "F") tvdcMin_Text = lstdvdcMin_Text;
                else tvdcMin_Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tVdcMax_Text) * 0.1, 2));


                Maj_VDC('V');
                Maj_IDC('I');
                saveINhttp();



                viderCF(HttpContext.Session["cfid"].ToString());
                fill_curr_Charger();
                lst_chconfigs.Add(curr_charger);

                return Json(lst_chconfigs, JsonRequestBehavior.AllowGet);
            }

        }

        string updateFromhttp(string key, string val)
        {
            string res = val;
            if (HttpContext.Session[key] == null) HttpContext.Session[key] = val;
            res = HttpContext.Session[key].ToString();
            return res;

        }

        void restoreFromhttp()
        {
            //######     checked this

            //            if (HttpContext.Session["usr"] != null )   usr = HttpContext.Session["usr"].ToString();
            //             if (HttpContext.Session["irrev"] != null )   irrev = HttpContext.Session["irrev"].ToString();
            //             if (HttpContext.Session["opera"] != null )   Opera = HttpContext.Session["opera"].ToString();


            //    HttpContext.Session["cbPxx"] = cbPxx_Text;
            //    HttpContext.Session["cbPhs"] = cbPhs_Text;
            //    HttpContext.Session["cbVdc"] = cbVdc_Text;
            //     HttpContext.Session["cbIdc"] = cbIdc_Text;


            HttpContext.Session["lChrgREF"] = lChrgREF_Text;
            txcbPxx_Text = HttpContext.Session["txcbPxx"].ToString();
            // lFV_Text =HttpContext.Session["lFV"].ToString();
            lNBC_NI_Text = HttpContext.Session["lNBC_NI"].ToString();
            lNBC_LA_Text = HttpContext.Session["lNBC_LA"].ToString();
            lVcellMin_NI_Text = HttpContext.Session["lVcellMin_NI"].ToString();
            lVcellMin_LA_Text = HttpContext.Session["lVcellMin_LA"].ToString();
            lvpcF_LA_Text = HttpContext.Session["lvpcF_LA"].ToString();
            lvpcE_NI_Text = HttpContext.Session["lvpcE_NI"].ToString();
            lvpcF_NI_Text = HttpContext.Session["lvpcF_NI"].ToString();
            lFLT_EQ_SEC_Text = HttpContext.Session["lFLT_EQ_SEC"].ToString();
            lIprim_Text = HttpContext.Session["lIprim"].ToString();
            lstdvdcMin_Text = HttpContext.Session["lstdvdcMin"].ToString();
            lstdvdcMax_Text = HttpContext.Session["lstdvdcMax"].ToString();
            lstdVAC_Text = HttpContext.Session["lstdVAC"].ToString();
            lRiple_Text = HttpContext.Session["lRiple"].ToString();
            lVSECLN_Text = HttpContext.Session["lVSECLN"].ToString();
            lVSECLL_Text = HttpContext.Session["lVSECLL"].ToString();
            lIsh_Text = HttpContext.Session["lIsh"].ToString();
            lW2_Text = HttpContext.Session["lW2"].ToString();


            nbcell_chngd = (HttpContext.Session["tCellN"].ToString() != tCellN_Text) ? 1 : 0;
            HttpContext.Session["tCellN"] = tCellN_Text;

            cof_EQL_chngd = (tvpcEq_Text != HttpContext.Session["tvpcEq"].ToString()) ? 1 : 0;
            HttpContext.Session["tvpcEq"] = tvpcEq_Text;

            cof_FLT_chngd = (tvpcF_Text != HttpContext.Session["tvpcF"].ToString()) ? 1 : 0;
            HttpContext.Session["tvpcF"] = tvpcF_Text;



            tVdcMax_Text = HttpContext.Session["tVdcMax"].ToString();
            tvdcMin_Text = HttpContext.Session["tvdcMin_"].ToString();
            HttpContext.Session["tVac"] = tVac_Text;
            typ_Batt = HttpContext.Session["typ_Batt"].ToString();
            lstdCellN_Text = HttpContext.Session["lstdCellN_"].ToString();
            //tVEQL_Text = HttpContext.Session["tVEQL"].ToString();
            //tVFLOAT_Text = HttpContext.Session["tVFLOAT"].ToString();
            lNcelCoef_Text = HttpContext.Session["lNcelCoef"].ToString();
            lhrtz_Text = HttpContext.Session["lhrtz"].ToString();
            tIdcMin_Text = HttpContext.Session["tIdcMin"].ToString();
            tIdcMax_Text = HttpContext.Session["tIdcMax"].ToString();
            //public int vdc_chngd { get; set; } //1:chnged  0:not
            //public int idc_chngd { get; set; }
            //public int nbcell_chngd { get; set; }

        }




        void vider_http()
        {

            HttpContext.Session["lChrgREF"] = "";
            HttpContext.Session["cbPxx"] = "";
            HttpContext.Session["cbPhs"] = "";
            HttpContext.Session["cbVdc"] = "";
            HttpContext.Session["cbIdc"] = "";
            HttpContext.Session["txcbPxx"] = "";

            HttpContext.Session["lFV"] = "";

            HttpContext.Session["lvpcE_LA"] = "";

            HttpContext.Session["lNBC_NI"] = "";

            HttpContext.Session["lNBC_LA"] = "";

            HttpContext.Session["lVcellMin_NI"] = "";

            HttpContext.Session["lVcellMin_LA"] = "";

            HttpContext.Session["lvpcF_LA"] = "";

            HttpContext.Session["lvpcE_NI"] = "";

            HttpContext.Session["lvpcF_NI"] = "";

            HttpContext.Session["lFLT_EQ_SEC"] = "";

            HttpContext.Session["lIprim"] = "";

            HttpContext.Session["lstdvdcMin"] = "";

            HttpContext.Session["lstdvdcMax"] = "";

            HttpContext.Session["lstdVAC"] = "";

            HttpContext.Session["lRiple"] = "";


            HttpContext.Session["lVSECLN"] = "";

            HttpContext.Session["lVSECLL"] = "";

            HttpContext.Session["lIsh"] = "";

            HttpContext.Session["lW2"] = "";


            HttpContext.Session["tCellN"] = "";


            HttpContext.Session["tVdcMax"] = "";

            HttpContext.Session["tvdcMin_"] = "";

            HttpContext.Session["tVac"] = "";

            HttpContext.Session["typ_Batt"] = "";

            HttpContext.Session["lstdCellN_"] = "";

            HttpContext.Session["tvpcEq"] = "";

            HttpContext.Session["tvpcF"] = "";

            HttpContext.Session["tVEQL"] = "";

            HttpContext.Session["tVFLOAT"] = "";

            HttpContext.Session["lNcelCoef"] = "";

            HttpContext.Session["lhrtz"] = "";

            HttpContext.Session["tIdcMin"] = "";

            HttpContext.Session["tIdcMax"] = "";

            //def Raw
            HttpContext.Session["def_147_vac"] = "";
            HttpContext.Session["def_147_icb1"] = "";
            HttpContext.Session["def_147_phs"] = "";
            HttpContext.Session["def_147_price"] = "";
            HttpContext.Session["def_147_ka"] = "";

            HttpContext.Session["def_226_vac"] = "";
            HttpContext.Session["def_226_icb1"] = "";
            HttpContext.Session["def_226_phs"] = "";
            HttpContext.Session["def_226_price"] = "";
            HttpContext.Session["def_226_ka"] = "";
        }

        void saveINhttp()
        {

            string usr = "", irrev = "", Opera = "";
            //            if (HttpContext.Session["usr"] != null )   usr = HttpContext.Session["usr"].ToString();
            //             if (HttpContext.Session["irrev"] != null )   irrev = HttpContext.Session["irrev"].ToString();
            //             if (HttpContext.Session["opera"] != null )   Opera = HttpContext.Session["opera"].ToString();




            HttpContext.Session["lChrgREF"] = lChrgREF_Text;
            HttpContext.Session["cbPxx"] = cbPxx_Text;
            HttpContext.Session["cbPhs"] = cbPhs_Text;
            HttpContext.Session["cbVdc"] = cbVdc_Text;
            HttpContext.Session["cbIdc"] = cbIdc_Text;
            HttpContext.Session["txcbPxx"] = txcbPxx_Text;

            HttpContext.Session["lFV"] = lFV_Text;

            HttpContext.Session["lvpcE_LA"] = lvpcE_LA_Text;

            HttpContext.Session["lNBC_NI"] = lNBC_NI_Text;

            HttpContext.Session["lNBC_LA"] = lNBC_LA_Text;

            HttpContext.Session["lVcellMin_NI"] = lVcellMin_NI_Text;

            HttpContext.Session["lVcellMin_LA"] = lVcellMin_LA_Text;

            HttpContext.Session["lvpcF_LA"] = lvpcF_LA_Text;

            HttpContext.Session["lvpcE_NI"] = lvpcE_NI_Text;

            HttpContext.Session["lvpcF_NI"] = lvpcF_NI_Text;

            HttpContext.Session["lFLT_EQ_SEC"] = lFLT_EQ_SEC_Text;

            HttpContext.Session["lIprim"] = lIprim_Text;

            HttpContext.Session["lstdvdcMin"] = lstdvdcMin_Text;

            HttpContext.Session["lstdvdcMax"] = lstdvdcMax_Text;

            HttpContext.Session["lstdVAC"] = lstdVAC_Text;

            HttpContext.Session["lRiple"] = lRiple_Text;


            HttpContext.Session["lVSECLN"] = lVSECLN_Text;

            HttpContext.Session["lVSECLL"] = lVSECLL_Text;

            HttpContext.Session["lIsh"] = lIsh_Text;

            HttpContext.Session["lW2"] = lW2_Text;


            HttpContext.Session["tCellN"] = tCellN_Text;


            HttpContext.Session["tVdcMax"] = tVdcMax_Text;

            HttpContext.Session["tvdcMin_"] = tvdcMin_Text;

            HttpContext.Session["tVac"] = tVac_Text;

            HttpContext.Session["typ_Batt"] = typ_Batt;

            HttpContext.Session["lstdCellN_"] = lstdCellN_Text;

            HttpContext.Session["tvpcEq"] = tvpcEq_Text;

            HttpContext.Session["tvpcF"] = tvpcF_Text;

            HttpContext.Session["tVEQL"] = tVEQL_Text;

            HttpContext.Session["tVFLOAT"] = tVFLOAT_Text;

            HttpContext.Session["lNcelCoef"] = lNcelCoef_Text;

            HttpContext.Session["lhrtz"] = lhrtz_Text;

            HttpContext.Session["tIdcMin"] = tIdcMin_Text;

            HttpContext.Session["tIdcMax"] = tIdcMax_Text;




            //public int vdc_chngd { get; set; } //1:chnged  0:not
            //public int idc_chngd { get; set; }
            //public int nbcell_chngd { get; set; }

        }
        void fill_curr_Charger_ERROR(string msg)
        {

            curr_charger.msgerror = msg;


        }

        void fill_curr_Charger()
        {
            curr_charger.msgerror = "";
            curr_charger.cbPxx_Text = cbPxx_Text;
            curr_charger.cbPhs_Text = cbPhs_Text;
            curr_charger.cbVdc_Text = cbVdc_Text;
            curr_charger.cbIdc_Text = cbIdc_Text;
            curr_charger.lFV_Text = lFV_Text;
            curr_charger.typ_Batt = typ_Batt;
            curr_charger.lRiple_Text = lRiple_Text;
            curr_charger.lhrtz_Text = lhrtz_Text;

            curr_charger.tCellN_Text = tCellN_Text;
            curr_charger.tvpcF_Text = tvpcF_Text;
            curr_charger.tvpcEq_Text = tvpcEq_Text;
            curr_charger.tvdcMin_Text = tvdcMin_Text;
            curr_charger.tVdcMax_Text = tVdcMax_Text;
            curr_charger.tVac_Text = tVac_Text;
            curr_charger.tVFLOAT_Text = tVFLOAT_Text;
            curr_charger.tVEQL_Text = tVEQL_Text;
            curr_charger.tIdcMin_Text = tIdcMin_Text;
            curr_charger.tIdcMax_Text = tIdcMax_Text;
            //  curr_charger.msgerror = "***" + MainMDI.cfid + "****" + "***https**" + HttpContext.Session["cfid"].ToString() + "***https**" + "\nsql_ex=" + MainMDI.stMsgXP;

            double ddvpcE = Tools.Conv_Dbl(tvpcEq_Text), ddvpcf = Tools.Conv_Dbl(tvpcF_Text);
            double F_E_Cells = Math.Max(ddvpcE, ddvpcf) * Tools.Conv_Dbl(tCellN_Text);
            if (F_E_Cells > Tools.Conv_Dbl(tVdcMax_Text)) curr_charger.msgerror = "Output voltage exceeded the charger standard maximum dc voltage. Please reduce your number of cells or the float/equalize voltage. If not possible, consult factory";


        }

        void fill_Wrong_Charger()
        {
            curr_charger.msgerror = "USER NAME is Wrong ...please logout and try.....";
        }

        void init_AllValues()
        {
            lChrgREF_Text = "";
            cbPxx_Text = "";
            cbPhs_Text = "";
            cbVdc_Text = "";
            cbIdc_Text = "";
            txcbPxx_Text = "";
            lFV_Text = "";
            lvpcE_LA_Text = "";
            lNBC_NI_Text = "";
            lNBC_LA_Text = "";
            lVcellMin_NI_Text = "";
            lVcellMin_LA_Text = "";
            lvpcF_LA_Text = "";
            lvpcE_NI_Text = "";
            lvpcF_NI_Text = "";
            lFLT_EQ_SEC_Text = "";
            lIprim_Text = "";
            lstdvdcMin_Text = "";
            lstdvdcMax_Text = "";
            lstdVAC_Text = "";
            lRiple_Text = "";
            lVSECLN_Text = "";
            lVSECLL_Text = "";
            lIsh_Text = "";
            lW2_Text = "";
            tCellN_Text = "";
            tVdcMax_Text = "";
            tvdcMin_Text = "";
            tVac_Text = "";
            typ_Batt = "";
            lstdCellN_Text = "";
            tvpcEq_Text = "";
            tvpcF_Text = "";
            tVEQL_Text = "";
            tVFLOAT_Text = "";
            lNcelCoef_Text = "";
            lhrtz_Text = "";
            tIdcMin_Text = "";
            tIdcMax_Text = "";
            cof_FLT_chngd = 0;
            cof_EQL_chngd = 0;
            nbcell_chngd = 0;

        }



        private void Maj_IDC(char c)
        {
            if (c == 'I') buil_chrg_Ref();
            tIdcMin_Text = "0";
            tIdcMax_Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(cbIdc_Text) * 100 / 100, Charger.NB_DEC_AFF));  //coef=1 modified: 01092010

        }
        private void Maj_VPC(char c)
        {
            // string dd = (typ_Batt =="LA"|| typ_Batt =="VRLA") ? Cpt.Cal_VCS(0, "C_NBCELL-LA") :  Cpt.Cal_VCS(0, "C_NBCELL-NI");
            if (typ_Batt == "NI-CAD")
            {
                lNcelCoef_Text = lNBC_NI_Text;
                tvpcEq_Text = lvpcE_NI_Text;
                tvpcF_Text = lvpcF_NI_Text;

            }
            else
            {
                if (typ_Batt == "LA")
                {
                    lNcelCoef_Text = lNBC_LA_Text;
                    tvpcEq_Text = lvpcE_LA_Text;
                    tvpcF_Text = lvpcF_LA_Text;
                }
                else      //VRLA ?????
                {
                    lNcelCoef_Text = lNBC_LA_Text;
                    tvpcF_Text = lvpcF_LA_Text;
                    tvpcEq_Text = lvpcF_LA_Text;
                }
            }

            Maj_TV();
            Maj_VDCMax();



        }


        private void Maj_NBCELL()
        {


            string dd = (typ_Batt == "LA" || typ_Batt == "VRLA") ? Cpt.Cal_VCS(0, "C_NBCELL-LA") : Cpt.Cal_VCS(0, "C_NBCELL-NI");

            //	string dd = (optLA.Checked ) ?  Std_VCS(cbPhs.Text , Charger.AvailId ,"C_NBCELL-LA") : Std_VCS(cbPhs.Text , Charger.AvailId ,"C_NBCELL-NI");
            lstdCellN_Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(dd), 0));
            if (tCellN_Text == "") tCellN_Text = lstdCellN_Text; //din
        }
        private void Cal_MaxVdc(char c)
        {
            if (c == 'V')
            {
                if (lvpcE_LA_Text == "")
                {
                    lNBC_NI_Text = Cpt.seekCF("VcellMax-NI");
                    lNBC_LA_Text = Cpt.seekCF("VcellMax-LA");
                    lVcellMin_NI_Text = Cpt.seekCF("VcellMin-NI");
                    lVcellMin_LA_Text = Cpt.seekCF("VcellMin-LA");
                    lvpcE_LA_Text = Cpt.seekCF("VPCEQ-LA");
                    lvpcF_LA_Text = Cpt.seekCF("VPCFLT-LA");
                    lvpcE_NI_Text = Cpt.seekCF("VPCEQ-NI");
                    lvpcF_NI_Text = Cpt.seekCF("VPCFLT-NI");
                    lFLT_EQ_SEC_Text = Cpt.seekCF("FLT-EQ_SEC");
                }
                lIprim_Text = MainMDI.Std_VCS(cbPhs_Text, Charger.AvailId, "C_IPRIM");
                lstdvdcMin_Text = MainMDI.Std_VCS(cbPhs_Text, Charger.AvailId, "C_VDCMIN"); // Cpt.Cal_VCS(0,"C_VDCMIN");
                lstdvdcMax_Text = MainMDI.Std_VCS(cbPhs_Text, Charger.AvailId, "C_VDCMAX"); //Cpt.Cal_VCS(0,"C_VDCMAX");
                lstdVAC_Text = MainMDI.Std_VCS(cbPhs_Text, Charger.AvailId, "C_VAC"); //Cpt.Cal_VCS(0,"C_VAC");
                lRiple_Text = Cpt.Cal_VCS(0, "C_RIPLE");
                //+ 250506
                lVSECLN_Text = (cbPhs_Text == "3") ? Cpt.Cal_VCS(0, "C_VSEC") : "0";
                lVSECLL_Text = (cbPhs_Text == "3") ? Cpt.Cal_VCS(0, "C_VSECLL") : "0";
                lIsh_Text = Cpt.Cal_VCS(0, "C_ISH1");
                lW2_Text = Cpt.Cal_VCS(0, "C_W2");
                //+ 250506
                if (tCellN_Text == "" || nbcell_chngd == 1)
                {
                    tVdcMax_Text = lstdvdcMax_Text;
                    tvdcMin_Text = lstdvdcMin_Text;
                    tVac_Text = lstdVAC_Text;
                }
                Maj_NBCELL();

            }
        }

        private void selCHRGR()
        {
            //        if (cbPxx.Text.Substring(0, 5) == "P4600")
            //        {
            //             MessageBox.Show("Charger ERROR.....P4600xxxx is not Ready Yet......");
            //             cbPxx.Text = "P4500";
            //         }

            //         else
            //          {
            string lFTTT_Text = cbPxx_Text.Substring(5, cbPxx_Text.Length - 5);
            string mdl = cbPxx_Text.Substring(0, 5);
            if (mdl == "P4500" || mdl == "P4600")
            {
                txcbPxx_Text = cbPxx_Text.Replace("4600", "4500");
                buil_chrg_Ref();

            }
            //bool tt = (cbPxx_Text.Substring(0, 5) == "P5500");
            //lmin.Visible = tt;
            //lxxx.Visible = tt;
            //cbXXX.Visible = tt;
            //       }
        }
        private void Maj_TV()
        {
            //PGESCOM way
            //if (tCellN_Text != "" && tvpcEq_Text != "" && tvpcF_Text != "") //&& Uchng.Text =="N" )
            //{
            //    if (tVEQL.ReadOnly) tVEQL.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tvpcEq.Text) * Tools.Conv_Dbl(tCellN.Text), 2));
            //    if (tVFLOAT.ReadOnly) tVFLOAT.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tvpcF.Text) * Tools.Conv_Dbl(tCellN.Text), 2));
            //}

            if (tCellN_Text != "" && tvpcEq_Text != "" && tvpcF_Text != "") //&& Uchng.Text =="N" )
            {
                tVEQL_Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tvpcEq_Text) * Tools.Conv_Dbl(tCellN_Text), 2));
                tVFLOAT_Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tvpcF_Text) * Tools.Conv_Dbl(tCellN_Text), 2));
            }
        }




        private void Maj_VDCMax()
        {
            if (tCellN_Text != "" && (cof_EQL_chngd == 1 || cof_FLT_chngd == 1 || nbcell_chngd == 1))
            {
                Maj_TV();
                double vcellMin = (typ_Batt == "NI-CAD") ? Tools.Conv_Dbl(lVcellMin_NI_Text) : Tools.Conv_Dbl(lVcellMin_LA_Text);
                double cfVcellMax = (typ_Batt == "NI-CAD") ? Tools.Conv_Dbl(lNBC_NI_Text) : Tools.Conv_Dbl(lNBC_LA_Text);
                double Max_FLTEQ = Tools.Conv_Dbl(lFLT_EQ_SEC_Text) * Math.Max(Tools.Conv_Dbl(tVEQL_Text), Tools.Conv_Dbl(tVFLOAT_Text));
                tVdcMax_Text = Convert.ToString(Math.Round(Math.Max(Tools.Conv_Dbl(tCellN_Text) * cfVcellMax, Max_FLTEQ), 2));
                tvdcMin_Text = Convert.ToString(vcellMin * Tools.Conv_Dbl(tCellN_Text));

            }
        }


        private void Maj_VDC(char c)
        {
            if (c == 'V') buil_chrg_Ref();
        }

        private void buil_chrg_Ref()
        {
            //Uchng.Text ="N";


            // lChrgREF.Text = cbPxx.Text + "-" + cbPhs.Text + "-" + cbVdc.Text + "-" + cbIdc.Text;
            lChrgREF_Text = cbPxx_Text + "-" + cbPhs_Text + "-" + cbVdc_Text + "-" + cbIdc_Text;// +"-" + ldesign.Text + "-" + ldesign2.Text + "-" + ldesign3.Text;

            if (cbPxx_Text != "" && cbPhs_Text != "" && cbVdc_Text != "" && cbIdc_Text != "")
            {
                //this.Cursor = Cursors.WaitCursor;  
                NewChrg();
                Cal_MaxVdc('V');
                Maj_VPC('D');
                //	Sav_Usr_Val();
                //	fill_Def_options();
                //   lChrgREF.BackColor = (cbPxx.Text.Substring(0, 5) == "P4600") ? Color.Green : Color.Blue;
            }


        }

        private void NewChrg()
        {
            CHRGR = new Charger(0, lFV_Text, txcbPxx_Text, cbPhs_Text, cbVdc_Text, cbIdc_Text, "0", "0");
            Cpt = new Component();
            // lOldRef.Text = lChrgREF.Text ;		
        }


        void createNewCF_cfgo2OLDDDD()
        {

            string ip = Request.UserHostAddress;
            string usr = (HttpContext.Session["usr"] == null) ? "" : HttpContext.Session["usr"].ToString();

            string mach_name = System.Environment.MachineName;
         //   HttpContext.Session["qtnb"]
           string qtnb = (HttpContext.Session["qtnb"] == null) ? "????" : HttpContext.Session["qtnb"].ToString();

            //  MainMDI.usr=h
            //   MainMDI.Exec_SQL_JFS("delete Configo_cf_info where usrname='" + MainMDI.usr + "'", "Configo del old CF..");
            string ddstr = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");     //System.DateTime.Now.Day + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Year;
            string cfname = "cf_" + DateTime.Now.Year.ToString() + MainMDI.A00(DateTime.Now.Month.ToString(), 2) + MainMDI.A00(DateTime.Now.Day.ToString(), 2) + "_" + MainMDI.A00(DateTime.Now.Hour.ToString(), 2) + MainMDI.A00(DateTime.Now.Minute.ToString(), 2);
            string stSql = "INSERT INTO Configo_cf_info ([cfname],[datein],[machNM], [usrname]) VALUES ('" + cfname + "', '" + ddstr + "', '" + mach_name + "', '" + usr + "_pgc_" +qtnb+ "')";

            MainMDI.Exec_SQL_JFS(stSql, " Configo new CF...", usr);
            string id = MainMDI.Find_One_Field("select cflid from Configo_cf_info where [cfname]='" + cfname + "'");
            // MainMDI.cfid = id;
            HttpContext.Session["cfid"] = (id == MainMDI.VIDE) ? "" : id;

        }

        void createNewCF_cfgo2()
        {

            string ip = Request.UserHostAddress;
            string usr = (HttpContext.Session["usr"] == null) ? "" : HttpContext.Session["usr"].ToString();
            string pgcid = (HttpContext.Session["pgcid"] == null) ? "" : HttpContext.Session["pgcid"].ToString();
            string mach_name = System.Environment.MachineName;
            //   HttpContext.Session["qtnb"]
            string qtnb = (HttpContext.Session["qtnb"] == null) ? "????" : HttpContext.Session["qtnb"].ToString();

            //  MainMDI.usr=h
            //   MainMDI.Exec_SQL_JFS("delete Configo_cf_info where usrname='" + MainMDI.usr + "'", "Configo del old CF..");
            string ddstr = System.DateTime.Now.ToString("yyyy/MM/dd HH:mm:ss");     //System.DateTime.Now.Day + "/" + System.DateTime.Now.Month + "/" + System.DateTime.Now.Year;
            string cfname = pgcid;// "cf_" + DateTime.Now.Year.ToString() + MainMDI.A00(DateTime.Now.Month.ToString(), 2) + MainMDI.A00(DateTime.Now.Day.ToString(), 2) + "_" + MainMDI.A00(DateTime.Now.Hour.ToString(), 2) + MainMDI.A00(DateTime.Now.Minute.ToString(), 2);
            string stSql = "INSERT INTO Configo_cf_info ([cfname],[datein],[machNM], [usrname]) VALUES ('" + cfname + "', '" + ddstr + "', '" + mach_name + "', '" + usr + "_pgc_" + qtnb + "')";

            MainMDI.Exec_SQL_JFS(stSql, " Configo new CF...", usr);
            string id = MainMDI.Find_One_Field("select cflid from Configo_cf_info where [cfname]='" + cfname + "'");
            // MainMDI.cfid = id;
            HttpContext.Session["cfid"] = (id == MainMDI.VIDE) ? "" : id;

        }

        //created in PGCWEB
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

        void  pgcweb_createNewCF()
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



        private string dlg_Arr_frml_Disp()
        {
            string stout = "";
            for (int i = 0; i < Charger.NB_FRML; i++)
            {
                if (dlg_arr_CAL_FRML[i] == "") break;
                else stout += dlg_arr_CAL_FRML[i] + "\n";
            }
          return stout;
        }
        private bool dlg_Arr_frml_Exist(string C_name)
        {
            string stout = "";
            for (int i = 0; i < Charger.NB_FRML; i++)
            {
                if (dlg_arr_CAL_FRML[i] == "") return false;
                else return (dlg_arr_CAL_FRML[i].IndexOf(C_name + "||") > -1);
            }
            return false;
        }
        private string fill_TV_LIST()
        {

            string stSql = "select * from PSM_LIST_TV where disp='1' and (phs='2' OR phs='" + cbPhs_Text + "') order by TVLID";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string stRes = "";
            string st = "";
            while (Oreadr.Read())
            {
                string C_NAME = Oreadr["C_Name"].ToString().Substring(2, Oreadr["C_Name"].ToString().Length - 2);
                if (dlg_Arr_frml_Exist(C_NAME))
                {
                    if (Oreadr["TV_typ"].ToString() == "C")
                    {
                        //a RE-Verifier
                        //  st = cal_CPT(-1, C_NAME);
                        st = MainMDI.VIDE;

                        stRes += (st == MainMDI.VIDE) ? "" : " " + Oreadr["C_Name"].ToString() + "||" + st;
                    }
                    else
                    {
                        st = cal_VCS(Oreadr["C_Name"].ToString());
                        stRes += (st == MainMDI.VIDE) ? "" : " " + Oreadr["C_Name"].ToString() + "||" + st;
                    }
                }
            }
            return stRes;
        }

        private void fill_OTV()
        {

            lOth_TV = "C_CLN||" + tCellN_Text;   //cell#
            //must add batt type,F/V ,design      in configo2
            //if (  optVrla.Checked) lOth_TV += " C_TBT||V";  //Batteries  Vrla,Nicd,Leadacid
            //else if (optNi.Checked) lOth_TV += " C_TBT||N";
            //else if (optLA.Checked) lOth_TV += " C_TBT||L";
           // lOth_TV += " C_VF||" + ((optFx.Checked) ? "F" : "V");  //charger Fx / Var
            lOth_TV += " C_FC||" + tvpcF_Text;                      // Float coef     
            lOth_TV += " C_EC||" + tvpcEq_Text;    // Eqlz coef  
            //if (ldesign.Text != "")
            //{
            //    lOth_TV += " C_DEZ||" + ldesign.Text; // design  
            //    lOth_TV += " C_DEZ_MDL||" + lChrgREF.Text + lsep.Text + ldesign.Text;
            //}
            lOth_TV += " " + fill_TV_LIST();   //Save ALL TVs described in PSM_LIST_TV




            //	lOth_TV += " C_VSECLN||" + lVSECLN.Text ; 
            //	lOth_TV += " C_VSECLL||" + lVSECLL.Text ; 
            //	lOth_TV += " C_W2||"   ; 
            //   MessageBox.Show(Math.Sqrt(3)).ToString ());  

        }

        private string cal_VCS(string NME)
        {
            CHRGR = new Charger(-1, lFV_Text, txcbPxx_Text, cbPhs_Text, cbVdc_Text, cbIdc_Text, tVac_Text, tVdcMax_Text);
            Cpt = new Component();
            return Cpt.Cal_VCS(0, NME).ToString();

        }
        private string cal_CPT(long lcptID, string cptName)
        {
            //string st = "";
            //if (lcptID == -1)
            //{
            //    st = MainMDI.Find_One_Field("select Component_ID from COMPNT_LIST where COMPONENT_REF='" + cptName + "'");
            //    lcptID = (st != MainMDI.VIDE) ? Convert.ToInt32(st) : -1;
            //}
            //if (lcptID != -1)
            //{
            //    CHRGR = new Charger(-1, lFV_Text, txcbPxx_Text, cbPhs_Text, cbVdc_Text, cbIdc_Text, tVac_Text, tVdcMax_Text);
            //    Cpt = new Component();
            //    Cpt.CPT_COST(lcptID);
            //    st = (Cpt.G_Desc.IndexOf("~~") < 1) ? MainMDI.VIDE : Cpt.G_Desc.Substring(0, Cpt.G_Desc.IndexOf("~~"));
            //    return st; //+ " || " + Cpt.CAP2 + " || " + Cpt.CAP3 + " || " + Cpt.CAP4 + " || " + Cpt.CAP5 + " || " + Cpt.CAP6 + " || " + Cpt.CAP7 + " || " + Cpt.G_Desc  + " || " + Cpt.G_PRICE  ;
            //}
            return MainMDI.VIDE;


        }






    }
}
