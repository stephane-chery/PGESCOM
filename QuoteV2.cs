using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using EAHLibs;
using System.Diagnostics;
using System.IO;
using System.Collections;
using System.Drawing.Printing;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Text.RegularExpressions;	
using Outlook = Microsoft.Office.Interop.Outlook;

namespace PGESCOM
{
    public partial class QuoteV2 : Form
    {
        char TV_RSA = 'V';
        //public string lCurSoln.Text = "", lCurINDX_Text = "", lcurSol_Status.Text = "", lOFName.Text = "", lCurALSn.Text = "", lCurSolNDX.Text = "";
        //public string lCurSoln.Text = ""; //lCurINDX_Text = "", lcurSol_Status.Text = "", lOFName.Text = "", lCurALSn.Text = "", lCurSolNDX.Text = "";
        int LENDesc = 475;
        //string disp_solID_Text = "", disp_altID_Text = "", disp_alsID_Text = "";
        private static Lib1 Tools = new Lib1();
        public bool BCONV = false;
        private bool Imprt = false;
        private char in_opera = '*';
        private int ItemCount = 0;
        private string OldLabel = "", Curr_SQLMLTP = " CAN_MLTP ", STDMultp_US = "", STDMultp_CAN = "", STDMultp_EURO = "";
        private int OptionCount = 0, oldsysNDX = -1, oldspcNDX = -1, oldsolNDX = -1;
        private bool Quote_loaded = false;
        private bool Tosave = false, loading = false;
        private bool Opt_added = false;
        private bool Chkable = true;
        private bool btnUnchk = false;
        private string curR_sol = "";
        private bool isDellAll = false;
        public long x_QID = -1;
        public string x_CpnyName = "*";
        public char x_opera = '*';
        private int LstNdx = -1, TABndx = 0;
        private int ndxfound = 0;
        private int ndxSelect = -1;
        private string Imp_SolID = "";
        private string Imp_IQID = "";
        private string Imp_cpnyID = "";
        Color BNS_color = Color.GreenYellow;

        //private string[,] arr_clpB = new string[MainMDI.MAX_Quote_lines, 13]; //12 subitem + 1 for Techvalue
        private string[] arr_Tech_values = new string[MainMDI.MAX_Quote_lines];
        string[] arr_Sql = new string[2000];

        private const int lim0 = 4, lim1 = 9, lim2 = 19;

        public QuoteV2(long x_QID, string x_CpnyName, char x_opera)
		{
            //
            //Required for Windows Form Designer support
            //         
            InitializeComponent();
			//tvSol.CheckBoxes = true;
            //MainMDI._connectionString = MainMDI._connectionString;
			in_opera = x_opera;
			lCurr_opera.Text = x_opera.ToString();
			fill_cbCompany();
			fill_cbSal_AG("S");
            fill_cbTerrito();
			fill_cbSal_AG("A");
            fill_Activities();

            fill_cb_S99();

            cbstatReason.Text = cbstatReason.Items[0].ToString();
            cbstatQuote.Text = cbstatQuote.Items[0].ToString();
            cbstage.Text = cbstage.Items[0].ToString();

            //
            if (lCurr_opera.Text == "N")
            {
                cbActivities.BringToFront();
                import.Visible = true;
                import.Enabled = true;
            }
			fill_cb_Inco();
			fill_cb_Terms();
			fill_cb_Via();
		   	CHSPrt();
			if (x_QID == 0)
			{ 
				//init_Curr_ALS();
				//if (fill_QID() == 0 || fill_QID() == -1) this.Close();
				//else lCurr_opera.Text = "N";
				btnNewID.Visible = true;
				cbCompanyy.Enabled = true;
				lCpnyName.Visible = false;
				tQuoteID.Focus();
			}
			else	
			{
				if (in_opera=='C')
				{
					tvSol.CheckBoxes = true;
					groupBox8.Enabled = false;
			        //groupBox4.Enabled = false;
					groupBox3.Enabled = false;
					grpTOTA.Visible = true;
					tALSnb.ReadOnly = true;
					tPxPrice.ReadOnly = true;
					tAGprice.ReadOnly = true;
					grpChng.Visible = false;
					lvQITEMS.Columns[0].Text = "Order";
					lvQITEMS.Columns[0].Width = 0; //0 = Hide Item check
					lvQITEMS.Columns[2].Width = lvQITEMS.Columns[2].Width - 39;
				
			        //for (int i = 0; i < toolBar1.Buttons.Count; i++) toolBar1.Buttons[i].Enabled = false;
                    for (int i = 0; i < toolBar1.Items.Count; i++) toolBar1.Items[i].Enabled = false;
					grpOrder.Visible =true;
				    //tabControl1.TabPages[1].Show();
				}
				btnNewID.Visible = false;
			    //tOpendate.Visible = false;
				cbCompanyy.Visible = false;
				lCpnyName.Visible = true;
 				tQuoteID.Text = x_QID.ToString();
				if (!fill_Qot(x_QID, x_CpnyName)) this.Hide();
				else lCurr_opera.Text = "E";
			}
			btnSeek.Visible = (lCurr_opera.Text == "N");
			tKey.Visible = (lCurr_opera.Text == "N");
            lkey.Visible = (lCurr_opera.Text == "N");
            btn_find_code.Visible = (lCurr_opera.Text == "N");
	        //toolBar1.Buttons[1].Visible = (lCurr_opera.Text == "N");
			btnIn.Visible = (lCurr_opera.Text == "N");
			if (lCurr_opera.Text == "N")
			{
				cbTerms.Text = "TBA";
				cbIncoTerm.Text = "EXW";
				cbShipVia.Text = MainMDI.VIDE;
                //fill_cb_AG_SYSPRO(1);
                //fill_cb_AG_SYSPRO(2);
			}
		    //lxtt.Visible = MainMDI.currDB == "XTT";
            lCname.Visible = (MainMDI.User.ToLower() == "ede");
            lcpnyID.Visible = (MainMDI.User.ToLower() == "ede");
            lPGRname.Visible = (MainMDI.User.ToLower() == "ede");
            button16.Visible = (MainMDI.User.ToLower() == "ede");
            bREV.Visible = (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "cfouche");
            bSYS.Visible = (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "cfouche");
            bALT.Visible = (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "cfouche");
            btnFlow.Visible = (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "hnasrat");
		}

        private void lnkCmnt_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            tComnt.Visible = true;
            btnComnt.Visible = true;
        }

        private void cbContacts_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //string stSql = "SELECT Contact_ID FROM PSM_Contacts WHERE ([PSM_Contacts]![First_ Name] & ' ' & [PSM_Contacts]![Last_Name])='" + cbContacts.Text + "' ";
            //lContact_ID.Text = MainMDI.Find_One_Field(stSql);
            //lContact_ID.Text = MainMDI.Find_One_Field(stSql);
            //if (lContact_ID.Text == MainMDI.VIDE) lContact_ID.Text = "0";

            string[] arr_Val = new string[8] { "", "", "", "", "", "", "", "" };
            string stSql = "SELECT PSM_Contacts.Contact_ID, PSM_Prefix.Prefix, PSM_Contacts.[First_Name], PSM_Contacts.Last_Name, PSM_Contacts.JOBTitle, Extension,Main_TEL,PSM_Contacts.[Fax Number] " +
                " FROM PSM_Contacts INNER JOIN PSM_Prefix ON PSM_Contacts.Prefix_ID = PSM_Prefix.[Prefix ID]  " +
                " WHERE ([PSM_Contacts].[First_Name] + ' ' + [PSM_Contacts].[Last_Name])='" + cbContacts.Text.Replace("'", "''") + "' and JOBTitle<>'~~' and Company_ID=" + lcpnyID.Text;

            if (MainMDI.Find_arr_Fields(stSql, arr_Val) == MainMDI.VIDE) lContact_ID.Text = "0";
            else
            {
                lContact_ID.Text = arr_Val[0]; lCname.Text = lContact_ID.Text;
                lPrfx.Text = arr_Val[1];
                lConName.Text = arr_Val[3]; lContacts.Text = lConName.Text;

                lSFX.Text = arr_Val[4];
                lConExt.Text = arr_Val[5];
                lConTel.Text = arr_Val[6];
                lPhone.Text = arr_Val[6];
                lConFax.Text = arr_Val[7];
            }
        }

        private void majContact()
        {
            string[] arr_Val = new string[6] { "", "", "", "", "", "" };
            string stSql = "SELECT PSM_Contacts.Contact_ID, PSM_Prefix.Prefix, PSM_Contacts.[First_Name], PSM_Contacts.Last_Name, PSM_Contacts.JOBTitle, Extension " +
                " FROM PSM_Contacts INNER JOIN PSM_Prefix ON PSM_Contacts.Prefix_ID = PSM_Prefix.[Prefix ID]  WHERE ([PSM_Contacts].[First_Name] + ' ' + [PSM_Contacts].[Last_Name])='" + cbContacts.Text.Replace("'", "''") + "' ";

            if (MainMDI.Find_arr_Fields(stSql, arr_Val) == MainMDI.VIDE) lContact_ID.Text = "0";
            else
            {
                lContact_ID.Text = arr_Val[0];
                lPrfx.Text = arr_Val[1];
                lConName.Text = arr_Val[3];
                lSFX.Text = arr_Val[4];
                lConExt.Text = arr_Val[5];
            }
        }

        private void cbTerms_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void cbShipVia_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void cbIncoTerm_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void btnImpChrgPrices_Click(object sender, System.EventArgs e)
        {
            //label28.Text = System.DateTime.Now.Minute.ToString() + "-" + System.DateTime.Now.Second.ToString();
            del_Charger_Price_Fast();
            Import_ChPrices();
            //label29.Text = System.DateTime.Now.Minute.ToString() + "-" + System.DateTime.Now.Second.ToString();
            //MessageBox.Show("Import Completed.....");
        }

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void button1_Click_1(object sender, System.EventArgs e)
        {
            Chargerdlg frmchdlg = new Chargerdlg('0', MainMDI.M_stCon, 'N');
            frmchdlg.Show();
        }

        private void import_OldQInfo(string r_IQID)
        {
            string stSql = "SELECT PSM_Q_IGen.Quote_ID, PSM_Q_IGen.ProjectName, PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS Emp, PSM_SALES_AGENTS_1.First_Name + ' ' + PSM_SALES_AGENTS_1.Last_Name AS IPMGR, PSM_Q_IGen.curr, PSM_Q_IGen.Lang,SP_AG2_id " +
                " FROM (PSM_Q_IGen INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_1 ON PSM_Q_IGen.IPmgr = PSM_SALES_AGENTS_1.SA_ID WHERE (((PSM_Q_IGen.i_Quoteid)=" + r_IQID + "))";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                tProjNAME.Text = Oreadr["ProjectName"].ToString();
                if (tQuoteID.Text == "") tQuoteID.Text = Oreadr["Quote_ID"].ToString();
                cbEmploy.Text = Oreadr["Emp"].ToString();

                cbIPmgr.Text = Oreadr["IPMGR"].ToString();
                switch (Oreadr["Lang"].ToString())
                {
                    case "B":
                        cbLang.Text = "Italian";
                        break;
                    case "F":
                        cbLang.Text = "French";
                        break;
                    case "E":
                        cbLang.Text = "English";
                        break;
                }
                opCan.Checked = (Oreadr["curr"].ToString() == "C");
                opUS.Checked = (Oreadr["curr"].ToString() == "U");
                opEuro.Checked = (Oreadr["curr"].ToString() == "E");
            }
            OConn.Close();
        }

        private void cpy_Sol(string OldQid, string NewQid, string OldSlid)
        {
            string stSql = "SELECT * from PSM_Q_SOL WHERE I_Quoteid=" + OldQid + " and Sol_LID=" + OldSlid;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                stSql = "INSERT INTO PSM_Q_SOL ([I_Quoteid],[Sol_Name],[img], [Rnk]," +
                    " [user],[date_Rev] ) VALUES ('" +
                    NewQid + "', '" +
                    //Oreadr["Sol_Name"].ToString() + "', '" +
                    Oreadr["Sol_Name"].ToString().Substring(0, 2) + "-00" + "', '" +
                    Oreadr["img"].ToString() + "', '" + Oreadr["Rnk"].ToString() + "', '" + MainMDI.User + "', " + MainMDI.SSV_date(System.DateTime.Now.ToShortDateString()) + ")";
                MainMDI.ExecSql(stSql);
                MainMDI.Write_JFS(stSql);
                //stSql = MainMDI.Find_One_Field("select Sol_LID from PSM_Q_SOL where I_Quoteid=" + NewQid + " AND Sol_Name='" + Oreadr["Sol_Name"].ToString() + "' and Rnk=" + Oreadr["Rnk"].ToString());
                stSql = MainMDI.Find_One_Field("select Sol_LID from PSM_Q_SOL where I_Quoteid=" + NewQid + " AND Sol_Name='" + Oreadr["Sol_Name"].ToString().Substring(0, 2) + "-00" + "' and Rnk=" + Oreadr["Rnk"].ToString());
                if (stSql != MainMDI.VIDE) Cpy_SPEC(OldSlid, stSql);
                else MessageBox.Show("Error Occurs while Saving imported Revision...contact your Admin !!!" + MainMDI.stXP);
            }
        }

        private void Cpy_SPEC(string OldSlid, string NewSlid)
        {
            //string stSql = MainMDI.Find_One_Field("select SPC_LID from PSM_Q_SPCS where Sol_LID=" + SID.ToString() + " AND SPC_Name='" + spc_name + "' and Rnk=" + Rnk);

            string stSql = "select * from PSM_Q_SPCS where Sol_LID=" + OldSlid;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                stSql = "INSERT INTO PSM_Q_SPCS ([Sol_LID],[SPC_Name], " +
                    " [Rnk] ) VALUES ('" +
                    NewSlid + "', '" +
                    Oreadr["SPC_Name"].ToString().Replace("'", "''") + "', '" +
                    Oreadr["Rnk"].ToString() + "')";
                MainMDI.ExecSql(stSql);
                MainMDI.Write_JFS(stSql);
                stSql = MainMDI.Find_One_Field("select SPC_LID from PSM_Q_SPCS where Sol_LID=" + NewSlid + " AND SPC_Name='" + Oreadr["SPC_Name"].ToString().Replace("'", "''") + "' and Rnk=" + Oreadr["Rnk"].ToString());
                if (stSql != MainMDI.VIDE) Cpy_ALS(Oreadr["SPC_LID"].ToString(), stSql);
                else MessageBox.Show("Error Occurs while Saving Imported SPEC...contact your Admin !!!" + MainMDI.stXP);
            }
        }

        private void Cpy_ALS(string OldSpcId, string NewSpcId)
        {
            string stSql = "select * from PSM_Q_ALS where SPC_LID=" + OldSpcId;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                string myals = (Oreadr["ALS_Name"].ToString().Length > 0) ? Oreadr["ALS_Name"].ToString().Replace("'", "''") : "Toto";
                stSql = "INSERT INTO PSM_Q_ALS ([SPC_LID],[ALS_Name],[Tot], [PxPrice],[AGPrice],[AlsQty]," +
                    " [Rnk] ) VALUES (" +
                    NewSpcId + ", '" +
                    myals + "', " +
                    Oreadr["Tot"].ToString() + ", " +
                    Oreadr["PxPrice"].ToString() + ", " +
                    Oreadr["AGPrice"].ToString() + ", " +
                    Oreadr["AlsQty"].ToString() + ", " +
                    Oreadr["Rnk"].ToString() + ")";
                MainMDI.ExecSql(stSql);
                MainMDI.Write_JFS("Cpy_ALS:  " + stSql);
                stSql = MainMDI.Find_One_Field("select ALS_LID from PSM_Q_ALS where SPC_LID=" + NewSpcId + " AND ALS_Name='" + Oreadr["ALS_Name"].ToString().Replace("'", "''") + "' and Rnk=" + Oreadr["Rnk"].ToString());
                if (stSql != MainMDI.VIDE) Cpy_Details(Oreadr["ALS_LID"].ToString(), stSql);
                else MessageBox.Show("Error Occurs while Saving Imported ALIAS...contact your Admin !!!" + MainMDI.stXP);
            }
        }

        private void Cpy_ALSOLD(string OldSpcId, string NewSpcId)
        {
            string stSql = "select * from PSM_Q_ALS where SPC_LID=" + OldSpcId;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                stSql = "INSERT INTO PSM_Q_ALS ([SPC_LID],[ALS_Name],[Tot], " +
                    " [Rnk] ) VALUES (" +
                    NewSpcId + ", '" +
                    Oreadr["ALS_Name"].ToString().Replace("'", "''") + "', " +
                    Oreadr["Tot"].ToString() + ", '" +
                    Oreadr["Rnk"].ToString() + "')";
                MainMDI.ExecSql(stSql);
                MainMDI.Write_JFS(stSql);
                stSql = MainMDI.Find_One_Field("select ALS_LID from PSM_Q_ALS where SPC_LID=" + NewSpcId + " AND ALS_Name='" + Oreadr["ALS_Name"].ToString().Replace("'", "''") + "' and Rnk=" + Oreadr["Rnk"].ToString());
                if (stSql != MainMDI.VIDE) Cpy_Details(Oreadr["ALS_LID"].ToString(), stSql);
                else MessageBox.Show("Error Occurs while Saving Imported ALIAS...contact your Admin !!!" + MainMDI.stXP);
            }
        }

        private void Cpy_Details(string OldAlsId, string NewAlsId)
        {
            string stSql = "select * from PSM_Q_Details where ALS_LID=" + OldAlsId;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                //double ddUP = (lvQITEMS.Items[i].SubItems[5].Text == "") ? 0 : Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[5].Text);
                //int LA = (lvQITEMS.Items[i].SubItems[8].Text == "") ? 0 : Convert.ToInt32(lvQITEMS.Items[i].SubItems[8].Text);
                stSql = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " +
                    " [Desc],[Qty],[Xch_Mult],[Uprice], [Mult],[Ext],[LeadTime],[Rnk],[PN],[Q_tec_Val]) VALUES ('" +
                    NewAlsId + "', '" +
                    Oreadr["Aff_ID"].ToString() + "', '" +
                    Oreadr["Desc"].ToString().Replace("'", "''") + "', '" +
                    Oreadr["Qty"].ToString() + "', '" +
                    Oreadr["Xch_Mult"].ToString() + "', '" +
                    Oreadr["Uprice"].ToString() + "', '" +
                    Oreadr["Mult"].ToString() + "', '" +
                    Oreadr["Ext"].ToString() + "', '" +
                    Oreadr["LeadTime"].ToString() + "', '" +
                    Oreadr["Rnk"].ToString() + "', '" +
                    Oreadr["PN"].ToString() + "', '" +
                    Oreadr["Q_tec_Val"].ToString() + "')";
                MainMDI.ExecSql(stSql);
                MainMDI.Write_JFS(stSql);
            }
        }

        private void add_ALRM_EQ(string CH_FRML)
        {
            Alarms_EQ_Oth AlrmEQ = new Alarms_EQ_Oth(CH_FRML, false, 'N');
            AlrmEQ.ShowDialog();
            if (AlrmEQ.lSave.Text == "Y")
            {
                for (int i = 0; i < AlrmEQ.lvAlrmPL.Items.Count; i++)
                {
                    if (AlrmEQ.lvAlrmPL.Items[i].Checked)
                    {
                        ItemCount++;
                        add_LVO(1, 0, ItemCount.ToString(), AlrmEQ.lvAlrmPL.Items[i].SubItems[1].Text, "1", tCust_Mult.Text, AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)), "04-06", "ALEQ_???", AlrmEQ.lvAlrmPL.Items[i].SubItems[3].Text, "A");
                    }
                }
                Ref_ALSTOT('A');
            }
            AlrmEQ.Close();
            AlrmEQ.Dispose();
        }

        private bool btnOK(int btn)
        {
            bool res = true;
            switch (btn)
            {
                case 3:
                case 14:
                case 7:
                case 8:
                case 17:
                case 19:
                case 20:
                case 21:
                case 16:
                    res = MainMDI.ALWD_USR("QT_SV", true); //Quotes: Saving, Delete, duplication and Word print.
                    break;
            }
            return res;
        }

        private void Tollsbar_CLicK(int btn)
        {
            if (in_opera != 'V')
            {
                this.Cursor = Cursors.WaitCursor;

                //int btn = toolBar1.Buttons.IndexOf(e.Button);
                if (btnOK(btn))
                {
                    //MessageBox.Show(toolBar1.Buttons.IndexOf(e.Button).ToString());

                    if (btn == 1)
                    {
                        //QimportRxx imp = new QimportRxx();
                        //imp.ShowDialog();
                        //Qimport_Xcompanies imp = new Qimport_Xcompanies();
                        //imp.ShowDialog();
                        //Qimport_duplicat koko = new Qimport_duplicat();
                        //koko.ShowDialog();

                        /*
                        if (imp.lsave.Text == "Y")
                        {
                            import_OldQInfo(imp.lIQID.Text);
                            Imp_SolID = imp.lSolid.Text;
                            Imp_IQID = imp.lIQID.Text;
                            Imp_cpnyID = imp.lcpnyID.Text;
                            gbxSol.Enabled = false;
                            MainMDI.Write_JFS("imported IQID=" + imp.lIQID.Text + " TO " + tQuoteID.Text + " date: " + System.DateTime.Now);
                            //Imprt = true;
                        }
                        else Imp_SolID = "";
                        */
                    }
                    if (btn == 3) //|| btn == 20)
                    {
                        bool fin = true;
                        if (btn == 20)
                        {
                            SAVE_CHANGE_ALS();
                            if (lCurrIQID.Text != "" && tQuoteID.Text != "") if (tQuoteID.Text != "") MainMDI.flag_QRID('Q', 'u', 0, Convert.ToUInt32(tQuoteID.Text));
                                else fin = MainMDI.Confirm("This Quote is not Saved yet ... Quit anyway ? ");
                            if (fin) this.Hide();
                        }
                        else
                        {
                            if (tQuoteID.Text != "")
                            {
                                string stId = MainMDI.Find_One_Field("select I_Quoteid from PSM_Q_IGen where Quote_ID=" + tQuoteID.Text + " AND CPNY_ID=" + lcpnyID.Text);
                                //if (Imp_cpnyID != lcpnyID.Text && stId == MainMDI.VIDE)
                                if (stId == MainMDI.VIDE || in_opera == 'E')
                                {
                                    if (Save_Q_IGen())
                                    {
                                        lQstatus.Text = lCancel.Text.Substring(0, 1);
                                        //if (Imp_SolID == "")
                                        MainMDI.flag_QRID('Q', 'f', 1, Convert.ToInt32(tQuoteID.Text));
                                        if (Imp_SolID != "") cpy_Sol(Imp_IQID, lCurrIQID.Text, Imp_SolID);
                                        lQsave.Text = "Y";
                                        if (!gbxSol.Enabled) Imprt = true;
                                    }
                                    txcb_Territo.BringToFront();
                                }
                                else
                                {
                                    if (tQuoteID.ReadOnly) MessageBox.Show("This Quote already exists for this Company..... !!!");
                                    else MessageBox.Show("Sorry, this Quote ID is already Taken,  try others IDs !!!!");
                                }
                            }
                            else { MessageBox.Show("Quote ID is empty...."); tQuoteID.Focus(); }
                        }
                    }
                    else
                    {
                        if ((btn == 21) || (lCurrIQID.Text != "0" && tQuoteID.Text != "" && (lcurSol_Status.Text != "C" || btn == 7 || btn == 4)))
                        {
                            switch (btn)
                            {
                                case 0:
                                    if (lCurrIQID.Text != "0")
                                    {
                                        if (lCancel.Visible) lQstatus.Text = "N";
                                        else lQstatus.Text = "C";
                                    }
                                    break;
                                case 4:
                                    Sol_Rep_SPP('V');
                                    //lCurrNAME.Text = (tQuoteID.Text + "S#" + tvSol.Nodes.Count.ToString());
                                    //tvSol.Nodes.Add(lCurrNAME.Text);
                                    //tvSol.Nodes[tvSol.Nodes.Count - 1].ImageIndex = 2;
                                    //tvSol.Nodes[tvSol.Nodes.Count - 1].SelectedImageIndex = 2;
                                    //tvSol.Nodes[tvSol.Nodes.Count - 1].BeginEdit();
                                    break;
                                case 5:
                                    if (lTVSel.Text == "Y")
                                    {
                                        //MessageBox.Show("Sel= " + tvSol.SelectedNode.IsSelected); Convert.ToString(tvSol.Nodes.Count + 1))
                                        //lCurrNAME.Text = "Alt#" + tvSol.SelectedNode.Nodes.Count.ToString();
                                        lCurrNAME.Text = "Alt#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
                                        if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = "Alt#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
                                        tvSol.SelectedNode.Nodes.Add(lCurrNAME.Text);
                                        tvSol.SelectedNode.Expand();
                                        tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].SelectedImageIndex = 1;
                                        tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].ImageIndex = 1;
                                        //tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].BeginEdit();
                                    }
                                    break;
                                case 6:
                                    if (lTVSel.Text == "Y")
                                    {
                                        //MessageBox.Show("Sel= " + tvSol.SelectedNode.Nodes.Count.ToString());

                                        //lCurrNAME.Text = "Alias#" + tvSol.SelectedNode.Nodes.Count.ToString();
                                        //if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = "Alias#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
                                        //lCurrNAME.Text = MainMDI.arr_EFSdict[38, MainMDI.Lang] + "#" + tvSol.SelectedNode.Nodes.Count.ToString();
                                        lCurrNAME.Text = "New_" + MainMDI.arr_EFSdict[38, MainMDI.Lang] + "#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
                                        if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = MainMDI.arr_EFSdict[38, MainMDI.Lang] + "#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
                                        tvSol.SelectedNode.Nodes.Add(lCurrNAME.Text);
                                        tvSol.SelectedNode.Expand();
                                        tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].SelectedImageIndex = 0;
                                        tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].ImageIndex = 0;
                                        chk_savOVRG.Checked = false;
                                        //tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].BeginEdit();
                                    }
                                    break;
                                case 7:
                                    if (lTVSel.Text == "Y")
                                    {
                                        switch (tvSol.SelectedNode.ImageIndex)
                                        {
                                            case 2:
                                            case 4:
                                            case 5:
                                                Duplica_Sol();
                                                break;
                                            case 1:
                                                if (lcurSol_Status.Text != "C") Duplica_SPC();
                                                break;
                                            case 0:
                                            case 3:
                                                if (lcurSol_Status.Text != "C") Duplica_ALS();
                                                break;
                                        }
                                    }
                                    break;
                                case 8:
                                    if (lTVSel.Text == "Y")
                                    {
                                        DialogResult dr = MessageBox.Show("Do You want to DELETE : " + tvSol.SelectedNode.Text, "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (dr == DialogResult.Yes) del_Node();
                                    }
                                    break;
                                //case 9: //New Charger
                                    //Add_Charger();
                                    //Tosave = true;
                                    //break;
                                case 10: //add Pre-Sized Battery
                                    //Add_CBR('B');

                                    //Add_BATT();

                                    //Tosave = true;
                                    break;
                                case 11: //add Pre-Sized Cabinet
                                    Add_CBR('C');
                                    Tosave = true;
                                    break;
                                case 12: //add Pre-Sized Rack
                                    //PbsInfo pbsIR = new PbsInfo('R', "44");
                                    //pbsIR.ShowDialog();
                                    Add_CBR('R');
                                    Tosave = true;
                                    break;
                                case 13: //New OPTION
                                    Add_option();
                                    Tosave = true;
                                    break;
                                case 14: //New NL_ITEM_OPTION
                                    Add_NLItemOption_NEW();
                                    Tosave = true;
                                    break;
                                case 15: //add alarms
                                    if (lvQITEMS.SelectedItems.Count > 0 && lvQITEMS.SelectedItems[0].SubItems[12].Text.IndexOf("n/a U_CHARGER||") > -1)
                                    {
                                        add_ALRM_EQ(lvQITEMS.SelectedItems[0].SubItems[12].Text);
                                        Tosave = true;
                                    }
                                    else MessageBox.Show("Sorry, You have to select a charger Item....");
                                    break;
                                case 16: //Save Current ALS
                                    if (lQsave.Text == "Y")
                                    {
                                        if (lcurSol_Status.Text != "C" && lvQITEMS.Items.Count > 0)
                                        {
                                            Save_Q_ALL_Details();
                                            //format display 0.00
                                            AlsTOT.ReadOnly = true;
                                            AlsTOT.Text = MainMDI.A00(Tools.Conv_Dbl(AlsTOT.Text).ToString());
                                            AlsTOT.ReadOnly = false;
                                            AlterTOT.Text = MainMDI.Curr_FRMT(MainMDI.SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
                                            tAGprice.Text = MainMDI.A00(Tools.Conv_Dbl(tAGprice.Text).ToString());
                                            //Maj_AlsTOT();
                                        }
                                        else MessageBox.Show("if you want to Empty this ALIAS use DELETE button !!!!");
                                    }
                                    else MessageBox.Show("You have to save Quote-Info FIRST !!!");
                                    //toolBar1.Buttons[16].Pushed = false;
                                    break;
                                case 17: //Del Current Als
                                    if (lvQITEMS.SelectedItems.Count > 0)
                                    {
                                        //if (lvQITEMS.SelectedItems[0].SubItems[1].Text != " ")
                                        if (MainMDI.Confirm("WANT TO DELETE ITEM / OPTION: " + lvQITEMS.SelectedItems[0].SubItems[2].Text + " ?  "))
                                        {
                                            if (lvQITEMS.SelectedItems[0].SubItems[1].Text == ".") Opt_added = false;
                                            del_Als_IO(lvQITEMS.SelectedItems[0].Index);
                                        }
                                    }
                                    else if (MainMDI.Confirm("WANT TO DELETE : " + tvSol.SelectedNode.Text + " ?  ")) del_Als(lCurSoln.Text, lCurSPCn.Text, lCurALSn.Text);
                                    Ref_ALSTOT('D');
                                    break;
                                case 18: //PBsizing
                                    try
                                    {
                                        System.Diagnostics.Process.Start(MainMDI.PBSPath + @"\PBSIZING.exe");
                                    }
                                    catch (System.Exception Oexp)
                                    {
                                        MessageBox.Show("Cannot Find PBSIZING.EXE at path: " + MainMDI.PBSPath + " System-msg: " + Oexp.Message);
                                    }
                                    break;
                                case 19: //Print
                                    //added for SYSPRO : testing existance of AG1, AG2
                                    //if ((groupBox12.Enabled) && (cbAG1.Text == MainMDI.VIDE || cbAG1.Text == "") && MainMDI.Confirm("Missing Agents......Fix Agent Name ? "))
                                        //cbAG1.Text = cbAG1.Text;
                                    if (4 > 6) cbAG1.Text = cbAG1.Text;
                                    else
                                    {
                                        string solId = MainMDI.Find_One_Field("select  Sol_LID from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'");
                                        FichWord_Config FC = new FichWord_Config(lCurrIQID.Text, solId, cbTerms.Text, lHiDelv.Text, lcurDol.Text, "");
                                        FC.ShowDialog();
                                        this.Refresh();

                                        if (FC.NXT)
                                        {
                                            pbPrintQt.Value = 0;
                                            lblWait.Text = "Please Wait,   exporting Quote to Word ...";
                                            grpPB.Visible = true;
                                            grpPB.Refresh();
                                            FichWord FW = new FichWord(this, FC);
                                            FW.Wexport();
                                            //if (FC.chk_VQ.Checked) FW.QuoteTO_XLfile();
                                            if (FC.chk_VQ.Checked) FW.QT_Send_ALL_QuoteTO_XL();
                                            if (FC.chkSendAG.Checked) email_AGENCIES(FC);
                                        }
                                    }
                                    break;
                                case 21: //add hidden item
                                    th_nb.Text = (ItemCount + 1).ToString();
                                    th_SYS.Text = AlsTOT_orig.Text;
                                    pnl_Hidden.Visible = true;
                                    Enable_ALL(false);
                                    break;
                                //case 21: //Exit
                                    //picExit_Click(sender, e);
                                    //break;
                            }
                        }
                        else
                        {
                            if (lcurSol_Status.Text == "C") MessageBox.Show("This Revission is Protected (Bleu=Converted to Order !!!!)");
                            if (lCurrIQID.Text == "0" && tQuoteID.Text == "") MessageBox.Show("You have To Save 'Quote Info' First !.....");
                        }
                    }
                    //else { if (lcurSol_Status.Text == "C") MessageBox.Show("This Revission is Protected (Bleu=Converted to Order !!!!)"); }
                    this.Cursor = Cursors.Default;
                }
                //else 
                //{
                    //if (btn == 20) this.Hide();
                    //else MessageBox.Show(MainMDI.User + ": is NOT allowed to perform this option, contact you Admin....! ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop); //MessageBox.Show(msg, "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //}
                if (Imprt) exit_Quote();
                this.Cursor = Cursors.Default;
            }
            else MessageBox.Show("Only Viewing Allowed ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop); //MessageBox.Show(msg, "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            /*
            if (in_opera != 'V')
            {
                this.Cursor = Cursors.WaitCursor;

                int btn = toolBar1.Buttons.IndexOf(e.Button);
                if (btnOK(btn))
                {
                    //MessageBox.Show(toolBar1.Buttons.IndexOf(e.Button).ToString());

                    if (btn == 1)
                    {
                        QimportRxx imp = new QimportRxx();
                        imp.ShowDialog();
                        if (imp.lsave.Text == "Y")
                        {
                            import_OldQInfo(imp.lIQID.Text);
                            Imp_SolID = imp.lSolid.Text;
                            Imp_IQID = imp.lIQID.Text;
                            Imp_cpnyID = imp.lcpnyID.Text;
                            gbxSol.Enabled = false;
                            MainMDI.Write_JFS("imported IQID=" + imp.lIQID.Text + " TO " + tQuoteID.Text + " date: " + System.DateTime.Now);
                            //Imprt = true;
                        }
                        else Imp_SolID = "";
                    }
                    if (btn == 3) //|| btn == 20)
                    {
                        bool fin = true;
                        if (btn == 20)
                        {
                            SAVE_CHANGE_ALS();
                            if (lCurrIQID.Text != "" && tQuoteID.Text != "") if (tQuoteID.Text != "") MainMDI.flag_QRID('Q', 'u', 0, Convert.ToUInt32(tQuoteID.Text));
                                else fin = MainMDI.Confirm("This Quote is not Saved yet ... Quit anyway ? ");
                            if (fin) this.Hide();
                        }
                        else
                        {
                            if (tQuoteID.Text != "")
                            {
                                string stId = MainMDI.Find_One_Field("select I_Quoteid from PSM_Q_IGen where Quote_ID=" + tQuoteID.Text + " AND CPNY_ID=" + lcpnyID.Text);
                                //if (Imp_cpnyID != lcpnyID.Text && stId == MainMDI.VIDE)
                                if (stId == MainMDI.VIDE || in_opera == 'E')
                                {
                                    if (Save_Q_IGen())
                                    {
                                        lQstatus.Text = lCancel.Text.Substring(0, 1);
                                        //if (Imp_SolID == "")
                                        MainMDI.flag_QRID('Q', 'f', 1, Convert.ToInt32(tQuoteID.Text));
                                        if (Imp_SolID != "") cpy_Sol(Imp_IQID, lCurrIQID.Text, Imp_SolID);
                                        lQsave.Text = "Y";
                                        if (!gbxSol.Enabled) Imprt = true;
                                    }
                                    txcb_Territo.BringToFront();
                                }
                                else
                                {
                                    if (tQuoteID.ReadOnly) MessageBox.Show("This Quote already exists for this Company..... !!!");
                                    else MessageBox.Show("Sorry, this Quote ID is already Taken,  try others IDs !!!!");
                                }
                            }
                            else { MessageBox.Show("Quote ID is empty...."); tQuoteID.Focus(); }
                        }
                    }
                    else
                    {
                        if ((btn == 21) || (lCurrIQID.Text != "0" && tQuoteID.Text != "" && (lcurSol_Status.Text != "C" || btn == 7 || btn == 4)))
                        {
                            switch (btn)
                            {
                                case 0:
                                    if (lCurrIQID.Text != "0")
                                    {
                                        if (lCancel.Visible) lQstatus.Text = "N";
                                        else lQstatus.Text = "C";
                                    }
                                    break;
                                case 4:
                                    Sol_Rep_SPP('V');
                                    //lCurrNAME.Text = (tQuoteID.Text + "S#" + tvSol.Nodes.Count.ToString());
                                    //tvSol.Nodes.Add(lCurrNAME.Text);
                                    //tvSol.Nodes[tvSol.Nodes.Count - 1].ImageIndex = 2;
                                    //tvSol.Nodes[tvSol.Nodes.Count - 1].SelectedImageIndex = 2;
                                    //tvSol.Nodes[tvSol.Nodes.Count - 1].BeginEdit();
                                    break;
                                case 5:
                                    if (lTVSel.Text == "Y")
                                    {
                                        //MessageBox.Show("Sel= " + tvSol.SelectedNode.IsSelected); Convert.ToString(tvSol.Nodes.Count + 1))
                                        //lCurrNAME.Text = "Alt#" + tvSol.SelectedNode.Nodes.Count.ToString();
                                        lCurrNAME.Text = "Alt#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
                                        if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = "Alt#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
                                        tvSol.SelectedNode.Nodes.Add(lCurrNAME.Text);
                                        tvSol.SelectedNode.Expand();
                                        tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].SelectedImageIndex = 1;
                                        tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].ImageIndex = 1;
                                        //tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].BeginEdit();
                                    }
                                    break;
                                case 6:
                                    if (lTVSel.Text == "Y")
                                    {
                                        //MessageBox.Show("Sel= " + tvSol.SelectedNode.Nodes.Count.ToString());

                                        //lCurrNAME.Text = "Alias#" + tvSol.SelectedNode.Nodes.Count.ToString();
                                        //if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = "Alias#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
                                        //lCurrNAME.Text = MainMDI.arr_EFSdict[38, MainMDI.Lang] + "#" + tvSol.SelectedNode.Nodes.Count.ToString();
                                        lCurrNAME.Text = MainMDI.arr_EFSdict[38, MainMDI.Lang] + "#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
                                        if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = MainMDI.arr_EFSdict[38, MainMDI.Lang] + "#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
                                        tvSol.SelectedNode.Nodes.Add(lCurrNAME.Text);
                                        tvSol.SelectedNode.Expand();
                                        tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].SelectedImageIndex = 0;
                                        tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].ImageIndex = 0;
                                        chk_savOVRG.Checked = false;
                                        //tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].BeginEdit();
                                    }
                                    break;
                                case 7:
                                    if (lTVSel.Text == "Y")
                                    {
                                        switch (tvSol.SelectedNode.ImageIndex)
                                        {
                                            case 2:
                                            case 4:
                                            case 5:
                                                Duplica_Sol();
                                                break;
                                            case 1:
                                                if (lcurSol_Status.Text != "C") Duplica_SPC();
                                                break;
                                            case 0:
                                            case 3:
                                                if (lcurSol_Status.Text != "C") Duplica_ALS();
                                                break;
                                        }
                                    }
                                    break;
                                case 8:
                                    if (lTVSel.Text == "Y")
                                    {
                                        DialogResult dr = MessageBox.Show("Do You want to DELETE : " + tvSol.SelectedNode.Text, "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (dr == DialogResult.Yes) del_Node();
                                    }
                                    break;
                                //case 9: //New Charger
                                    //Add_Charger();
                                    //Tosave = true;
                                    //break;
                                case 10: //add Pre-Sized Battery
                                    Add_CBR('B');
                                    Tosave = true;
                                    break;
                                case 11: //add Pre-Sized Cabinet
                                    Add_CBR('C');
                                    Tosave = true;
                                    break;
                                case 12: //add Pre-Sized Rack
                                    //PbsInfo pbsIR = new PbsInfo('R', "44");
                                    //pbsIR.ShowDialog();
                                    Add_CBR('R');
                                    Tosave = true;
                                    break;
                                case 13: //New OPTION
                                    Add_option();
                                    Tosave = true;
                                    break;
                                case 14: //New NL_ITEM_OPTION
                                    Add_NLItemOption();
                                    Tosave = true;
                                    break;
                                case 15: //add alarms
                                    if (lvQITEMS.SelectedItems.Count > 0 && lvQITEMS.SelectedItems[0].SubItems[12].Text.IndexOf("n/a U_CHARGER||") > -1)
                                    {
                                        add_ALRM_EQ(lvQITEMS.SelectedItems[0].SubItems[12].Text);
                                        Tosave = true;
                                    }
                                    break;
                                case 16: //Save Current ALS
                                    if (lQsave.Text == "Y")
                                    {
                                        if (lcurSol_Status.Text != "C" && lvQITEMS.Items.Count > 0)
                                        {
                                            Save_Q_ALL_Details();
                                            //format display 0.00
                                            AlsTOT.ReadOnly = true;
                                            AlsTOT.Text = MainMDI.A00(Tools.Conv_Dbl(AlsTOT.Text).ToString());
                                            AlsTOT.ReadOnly = false;
                                            AlterTOT.Text = MainMDI.Curr_FRMT(MainMDI.SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
                                            tAGprice.Text = MainMDI.A00(Tools.Conv_Dbl(tAGprice.Text).ToString());
                                            //Maj_AlsTOT();
                                        }
                                        else MessageBox.Show("if you want to Empty this ALIAS use DELETE button !!!!");
                                    }
                                    else MessageBox.Show("You have to save Quote-Info FIRST !!!");
                                    toolBar1.Buttons[16].Pushed = false;
                                    break;
                                case 17: //Del Current Als
                                    if (lvQITEMS.SelectedItems.Count > 0)
                                    {
                                        //if (lvQITEMS.SelectedItems[0].SubItems[1].Text != " ")
                                        if (MainMDI.Confirm("WANT TO DELETE ITEM / OPTION: " + lvQITEMS.SelectedItems[0].SubItems[2].Text + " ?  "))
                                        {
                                            if (lvQITEMS.SelectedItems[0].SubItems[1].Text == ".") Opt_added = false;
                                            del_Als_IO(lvQITEMS.SelectedItems[0].Index);
                                        }
                                    }
                                    else if (MainMDI.Confirm("WANT TO DELETE : " + tvSol.SelectedNode.Text + " ?  ")) del_Als(lCurSoln.Text, lCurSPCn.Text, lCurALSn.Text);
                                    Ref_ALSTOT('D');
                                    break;
                                case 18: //PBsizing
                                    try
                                    {
                                        System.Diagnostics.Process.Start(MainMDI.PBSPath + @"\PBSIZING.exe");
                                    }
                                    catch (System.Exception Oexp)
                                    {
                                        MessageBox.Show("Cannot Find PBSIZING.EXE at path: " + MainMDI.PBSPath + " System-msg: " + Oexp.Message);
                                    }
                                    break;
                                case 19: //Print
                                    //added for SYSPRO : testing existance of AG1, AG2
                                    //if ((groupBox12.Enabled) && (cbAG1.Text == MainMDI.VIDE || cbAG1.Text == "") && MainMDI.Confirm("Missing Agents......Fix Agent Name ? "))
                                        //cbAG1.Text = cbAG1.Text;
                                    if (4 > 6) cbAG1.Text = cbAG1.Text;
                                    else
                                    {
                                        string solId = MainMDI.Find_One_Field("select  Sol_LID from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'");
                                        FichWord_Config FC = new FichWord_Config(lCurrIQID.Text, solId, cbTerms.Text, lHiDelv.Text, lcurDol.Text, "");
                                        FC.ShowDialog();
                                        this.Refresh();
                                        if (FC.NXT)
                                        {
                                            pbPrintQt.Value = 0;
                                            lblWait.Text = "Please Wait,   exporting Quote to Word ...";
                                            grpPB.Visible = true;
                                            grpPB.Refresh();
                                            FichWord FW = new FichWord(this, FC);
                                            FW.Wexport();
                                        }
                                    }
                                    break;
                                case 20: //add hidden item
                                    th_nb.Text = (ItemCount + 1).ToString();
                                    th_SYS.Text = AlsTOT_orig.Text;
                                    pnl_Hidden.Visible = true;
                                    Enable_ALL(false);
                                    break;
                                case 21: //Exit
                                    picExit_Click(sender, e);
                                    break;
                            }
                        }
                        else
                        {
                            if (lcurSol_Status.Text == "C") MessageBox.Show("This Revission is Protected (Bleu=Converted to Order !!!!)");
                            if (lCurrIQID.Text == "0" && tQuoteID.Text == "") MessageBox.Show("You have To Save 'Quote Info' First !.....");
                        }
                    }
                    //else { if (lcurSol_Status.Text == "C") MessageBox.Show("This Revission is Protected (Bleu=Converted to Order !!!!)"); }
                    this.Cursor = Cursors.Default;
                }
                //else 
                //{
                    //if (btn == 20) this.Hide();
                    //else MessageBox.Show(MainMDI.User + ": is NOT allowed to perform this option, contact you Admin....! ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop); //MessageBox.Show(msg, "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //}
                if (Imprt) picExit_Click(sender, e);
                this.Cursor = Cursors.Default;
            }
            else MessageBox.Show("Only Viewing Allowed ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop); //MessageBox.Show(msg, "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            */
        }

        private bool Rev_Converted(string iqid, string revName)
        {
            string res = MainMDI.Find_One_Field("select status_Rev from PSM_Q_SOL where I_Quoteid=" + iqid + " and Sol_Name='" + revName.Replace("'", "''") + "'");
            return (res == "C");
        }

        private void Sol_Rep_SPP(char s)
        {
            int nb = 0, t;

            switch (s)
            {
                case 'V':
                    t = REV_Nb("RV") + 1;
                    lCurrNAME.Text = "RV-" + MainMDI.A00(t, 2);
                    //if (REv_Exist(lCurrNAME.Text)) lCurrNAME.Text = "RV-" + (t + 1);
                    nb = 2;
                    break;
                case 'S':
                    t = REV_Nb("SP") + 1;
                    lCurrNAME.Text = "SP-" + MainMDI.A00(t, 2);
                    //if (REv_Exist(lCurrNAME.Text)) lCurrNAME.Text = "SP-" + (t + 1);
                    nb = 4;
                    break;
                case 'R':
                    t = REV_Nb("SV") + 1;
                    lCurrNAME.Text = "SV-" + MainMDI.A00(t, 2);
                    //if (REv_Exist(lCurrNAME.Text)) lCurrNAME.Text = "SV-" + (t + 1);
                    nb = 5;
                    break;
            }
            //lCurrNAME.Text = (tQuoteID.Text + "S#" + tvSol.Nodes.Count.ToString());
            tvSol.Nodes.Add(lCurrNAME.Text);
            tvSol.Nodes[tvSol.Nodes.Count - 1].ImageIndex = nb;
            tvSol.Nodes[tvSol.Nodes.Count - 1].SelectedImageIndex = nb;
            //tvSol.Nodes[tvSol.Nodes.Count - 1].BeginEdit();
        }

        private void Sol_Rep_SPPOLD(char s)
        {
            int nb = 0;

            switch (s)
            {
                case 'V':
                    //lCurrNAME.Text = (tQuoteID.Text + "Version #" + tvSol.Nodes.Count.ToString());
                    lCurrNAME.Text = "RV-" + tvSol.Nodes.Count.ToString();
                    if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = "RV-" + tvSol.Nodes.Count.ToString() + Convert.ToString(tvSol.Nodes.Count + 1);
                    nb = 2;
                    break;
                case 'S':
                    lCurrNAME.Text = "SP-" + tvSol.Nodes.Count.ToString();
                    if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = "SP-" + tvSol.Nodes.Count.ToString() + Convert.ToString(tvSol.Nodes.Count + 1);
                    nb = 4;
                    break;
                case 'R':
                    lCurrNAME.Text = tQuoteID.Text + "SV-" + tvSol.Nodes.Count.ToString();
                    if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = tQuoteID.Text + "SV-" + Convert.ToString(tvSol.Nodes.Count + 1);
                    nb = 5;
                    break;
            }
            //lCurrNAME.Text = (tQuoteID.Text + "S#" + tvSol.Nodes.Count.ToString());
            tvSol.Nodes.Add(lCurrNAME.Text);
            tvSol.Nodes[tvSol.Nodes.Count - 1].ImageIndex = nb;
            tvSol.Nodes[tvSol.Nodes.Count - 1].SelectedImageIndex = nb;
            //tvSol.Nodes[tvSol.Nodes.Count - 1].BeginEdit();
        }

        private void groupBox6_Enter(object sender, System.EventArgs e)
        {

        }

        private void lvComment_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void btn2_Click(object sender, System.EventArgs e)
        {
            Fill_BigFile13 fillbgf = new Fill_BigFile13();
            fillbgf.ShowDialog();
        }

        public bool IsDoubleNumber(string strNumber)
        {
            Regex objNotNumberPattern = new Regex("[^0-9.-]");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
            Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
            String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
            String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
            Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

            return !objNotNumberPattern.IsMatch(strNumber) &&
                !objTwoDotPattern.IsMatch(strNumber) &&
                !objTwoMinusPattern.IsMatch(strNumber) &&
                objNumberPattern.IsMatch(strNumber);
        }

        private bool isNumber(string strNumber)
        {
            Regex objNotPositivePattern = new Regex("[^0-9.]");
            Regex objPositivePattern = new Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
            Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");

            return !objNotPositivePattern.IsMatch(strNumber) &&
                objPositivePattern.IsMatch(strNumber) &&
                !objTwoDotPattern.IsMatch(strNumber);
        }

        private void button2_Click(object sender, System.EventArgs e)
        {
            ////MainMDI.Lang = 0;
            //string solId = Find_One_Field("select  Sol_LID from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text + "'");
            //FichWord_Config FC = new FichWord_Config(lCurrIQID.Text, solId, cbTerms.Text, lHiDelv.Text);
            //FC.ShowDialog();
            //if (FC.NXT) { FichWord kiki = new FichWord(this, FC); }

            ////Add_NLItemOption();
            MessageBox.Show("Res=" + Tools.IsNumeric("14525 455").ToString());
            //if (MainMDI.User == "Admin")
            //{
                //Chargerdlg_RREV frmchdlgrev = new Chargerdlg_RREV('0', lvQITEMS.Items[lvQITEMS.SelectedItems[0].Index].SubItems[12].Text, MainMDI.VIDE, lvQITEMS.Items[lvQITEMS.SelectedItems[0].Index].SubItems[9].Text);
                ////this.Hide();
                //frmchdlgrev.ShowDialog();
                //if (frmchdlgrev.lSave.Text == "Y") MessageBox.Show("SaveeeeeeeeeeeeeeeeeeeeeeeeeeeD");
            //}
        }

        private void lvQITEMS_ItemCheckOLD(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {
            //if (e.Index == 0) lvQITEMS.Items[2].Checked = true;
            if (in_opera == 'C')
            {
                if (!lvQITEMS.Items[e.Index].Checked)
                {
                    if (in_opera == 'C' && lvQITEMS.Items[e.Index].SubItems[7].Text != "")
                        if (seek_LvOrder(lvQITEMS.Items[e.Index].SubItems[11].Text, 'c') == -1) add_LVR("      " + lvQITEMS.Items[e.Index].SubItems[2].Text, lCurSolNDX.Text, lCurSPCNDX.Text, lCurALSNDX.Text, lvQITEMS.Items[e.Index].SubItems[11].Text, e.Index.ToString(), lCurSPCn.Text + "/" + lCurALSn.Text, lvQITEMS.Items[e.Index].SubItems[7].Text);
                }
                else seek_LvOrder(lvQITEMS.Items[e.Index].SubItems[11].Text, 'r');
            }
            //else lvQITEMS.Items[e.Index].Checked = !lvQITEMS.Items[e.Index].Checked;
            //else lvQITEMS_DoubleClick(sender, e);
        }

        private void lvQITEMS_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {
            /*
            to disable checking items in many alias when converting a Quote
            if (in_opera == 'C')
            {
                if (!lvQITEMS.Items[e.Index].Checked)
                {
                    if (in_opera == 'C' && lvQITEMS.Items[e.Index].SubItems[1].Text != "")
                        if (seek_LvOrder(lvQITEMS.Items[e.Index].SubItems[11].Text, 'c') == -1) add_LVR("      " + lvQITEMS.Items[e.Index].SubItems[2].Text, lCurSolNDX.Text, lCurSPCNDX.Text, lCurALSNDX.Text, lvQITEMS.Items[e.Index].SubItems[11].Text, e.Index.ToString(), lCurSPCn.Text + "/" + lCurALSn.Text, lvQITEMS.Items[e.Index].SubItems[7].Text);
                }
                else seek_LvOrder(lvQITEMS.Items[e.Index].SubItems[11].Text, 'r');
            }
            */
        }

        private int seek_LvOrder(string st, char c)
        {
            if (st != "" && !isDellAll)
            {
                for (int i = 0; i < lvOrder.Items.Count; i++)
                    if (lvOrder.Items[i].SubItems[4].Text == st)
                    {
                        if (c == 'r') lvOrder.Items[i].Remove();
                        else return i;
                    }
            }
            return -1;
        }

        private void cbCompanyy_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            picSPcode.Visible = false;
            picALRM_mltp.Visible = false;
            picOutSales.Visible = false;
            toolBar1.Enabled = true;
            lAdrs.Text = "";
            lPhone.Text = ""; lFax.Text = "";
            lContact_ID.Text = "";
            lCpnyName.Text = cbCompanyy.Text;
            string BLcmnt = "", InBL = "", usr = "";
            MainMDI.Find_2_Field("select BLack_List,  BL_Cmnt, BL_usr  from PSM_COMPANY Where Cpny_Name1='" + cbCompanyy.Text.Replace("'", "''") + "'", ref InBL, ref BLcmnt, ref usr);

            if (lCurr_opera.Text != "N" || InBL == "0")
            {
                fill_Company_Info(cbCompanyy.Text, '*');
                fill_cb_Contacts(Convert.ToInt32(lcpnyID.Text));
                //Q_sysPcode.Text = MainMDI.Find_One_Field("select Syspro_Code from PSM_COMPANY where     =" + lcpnyID.Text);
                if (lCurr_opera.Text == "N")
                {
                    cbCQA.Text = cbCompanyy.Text;
                    cbCPA.Text = cbCompanyy.Text;
                    cbCSA.Text = cbCompanyy.Text;
                    cbCIA.Text = cbCompanyy.Text;
                }
            }
            else
            {
                if (toolBar1.Enabled)
                {
                    MessageBox.Show("Sorry, This Company is in BLACK LIST ...You have to contact Admin....\n Why? : " + BLcmnt + "\n Added in Black-List by: " + usr, "BLACK LIST", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    toolBar1.Enabled = false;
                }
            }
            //if (QReq.Text == "") QReq.Text = cbCompanyy.Text;
            if (lCurr_opera.Text == "N")
            {
                lREQ.Text = lcpnyID.Text;
                QReq.Text = cbCompanyy.Text;
            }
        }

        private void statusBar1_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
        {

        }

        /*
        ToolStripButton toolBar1_Buttons(int ndx)
        {
            ToolStripButton my_btn = null;
            switch (ndx)
            {
                case 0:
                    my_btn = Cancel;
                    break;
            }
            return my_btn;
        }
        */

        int toolbar1_btName_ndx(string Name)
        {
            int ndx = -1;

            for (int t = 0; t < toolBar1.Items.Count; t++)
                if (toolBar1.Items[t].Text == Name)
                {
                    ndx = t;
                    t = toolBar1.Items.Count;
                }
            return ndx;
        }

        private void undisp_Totals()
        {
            tls_SYS_tot.Text = "";
            tls_Revdate.Text = "";
            tls_lRevTOT.Text = "";
            tls_ALT_tot.Text = "";
        }

        private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            orga_RSA(0);
            this.Refresh();

            TABndx = tabControl1.SelectedIndex;

            switch_ToolBar(tabControl1.SelectedIndex);
            if (tabControl1.SelectedIndex == 1)
            {
                SAVE_CHANGE_ALS();
                toolBar1.Items[19].Visible = (!Tosave);
                xpndd.Visible = true;
                if (lCurr_opera.Text == "E" || lCurr_opera.Text == "N")
                {
                    if (!Quote_loaded)
                    {
                        this.WindowState = FormWindowState.Maximized;
                        tvSol.Nodes.Clear();
                        fill_Sol();
                        toolBar1.Items[19].Visible = true;
                        if (tvSol.Nodes.Count == 0) AlS_Wizard();
                    }
                }
            }
            else
            {
                if (tabControl1.SelectedIndex == 0) undisp_Totals();
                else
                {
                    fill_cbAGent_SYSPRO(Q_sysPcod.Text[Q_sysPcod.Text.Length - 1].ToString());
                    if (optAGOKII.Checked) fill_Quot_agents();
                    else gbxAgent.Enabled = false;
                }
            }
            toolBar1.Items[19].Visible = (tabControl1.SelectedIndex == 1);
        }

        private void fill_cbAGent_SYSPRO(string branch)
        {
            if (branch == "C" || branch == "U")
            {
                string stSql = "SELECT   Name FROM  dbo.SalSalesperson where SUBSTRING (Salesperson,1,1)='A' and Branch ='" + branch + "1' order by Name ";
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    stSql = Oreadr[0].ToString(); //no last name for agency..... //+ " " + Oreadr[1].ToString();
                    cbADII.Items.Add(stSql);
                    cbaeII.Items.Add(stSql);
                    cbAPII.Items.Add(stSql);
                    cbaiII.Items.Add(stSql);
                    //cbAS.Items.Add(stSql);
                }
                OConn.Close();
                cbADII.Items.Add(MainMDI.VIDE);
                cbaeII.Items.Add(MainMDI.VIDE);
                cbAPII.Items.Add(MainMDI.VIDE);
                cbaiII.Items.Add(MainMDI.VIDE);
            }
            else MessageBox.Show("Invalid Branch....No Agents loaded... ");
        }

        private void switch_ToolBar(int c)
        {
            if (in_opera != 'C')
            {
                for (int i = 0; i < toolBar1.Items.Count - 1; i++) toolBar1.Items[i].Visible = false;
                toolBar1.Items[23].Visible = true;
                switch (c)
                {
                    case 0:
                        //toolBar1.Items[0].Visible = true;
                        //toolBar1.Items[1].Visible = true;
                        //toolBar1.Items[2].Visible = true;
                        toolBar1.Items[3].Visible = true;
                        //toolBar1.Items[22].Visible = true;
                        break;
                    case 1:
                        switchRSA();
                        toolBar1.Items[22].Visible = true;
                        break;
                }
            }
        }

        void switchRSA()
        {
            switch (TV_RSA)
            {
                case 'R':
                    toolBar1.Items[4].Visible = true;
                    toolBar1.Items[5].Visible = true;
                    toolBar1.Items[7].Visible = true;
                    toolBar1.Items[20].Visible = true;
                    break;
                case 'S':
                    toolBar1.Items[6].Visible = true;
                    toolBar1.Items[7].Visible = true;
                    toolBar1.Items[8].Visible = true;
                    toolBar1.Items[20].Visible = true;
                    break;
                case 'A':
                    toolBar1.Items[9].Visible = true;
                    toolBar1.Items[10].Visible = true;
                    //toolBar1.Items[11].Visible = true;
                    //toolBar1.Items[12].Visible = true;
                    toolBar1.Items[13].Visible = true;
                    toolBar1.Items[14].Visible = true;
                    toolBar1.Items[15].Visible = true;
                    toolBar1.Items[16].Visible = true;
                    toolBar1.Items[17].Visible = true;
                    toolBar1.Items[18].Visible = true;
                    toolBar1.Items[19].Visible = true;
                    toolBar1.Items[21].Visible = true;
                    break;
            }
        }

        private void switch_ToolBarOLD(int c)
        {
            if (in_opera != 'C')
            {
                for (int i = 0; i < toolBar1.Items.Count - 1; i++)
                {
                    switch (c)
                    {
                        case 0:
                            toolBar1.Items[i].Visible = false; //(i < lim0);
                            toolBar1.Items[20].Visible = true;
                            toolBar1.Items[3].Visible = true;
                            break;
                        case 1:
                            toolBar1.Items[i].Visible = (i < lim1 && i >= lim0);
                            toolBar1.Items[20].Visible = true;
                            break;
                        case 2:
                            toolBar1.Items[i].Visible = false;
                            toolBar1.Items[20].Visible = true;
                            break;
                        case 9:
                            toolBar1.Items[i].Visible = (i < lim2 && i >= lim1);

                            //toolBar1.Items[19].Visible = true;
                            break;
                    }
                    //toolBar1.Buttons[18].Visible = true;
                    //toolBar1.Buttons[19].Visible = true; //Exit Button
                }
                //(i < 4) toolBar1.Buttons[i].Visible = (tabControl1.SelectedIndex == 0);
                //else if (i < 8) toolBar1.Buttons[i].Visible = ((tabControl1.SelectedIndex == 1 && tvSol.SelectedNode = null));
                    //else toolBar1.Buttons[i].Visible = (tabControl1.SelectedIndex == c);
                //
            }
        }

        private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {

        }

        private void tQuoteID_TextChanged(object sender, System.EventArgs e)
        {
            AffQNB.Text = tQuoteID.Text; //+ "-" + tRev.Text;
        }

        private void tvSol_Leave(object sender, System.EventArgs e)
        {
            lTVSel.Text = "N";
        }

        private void tvSol_Click(object sender, System.EventArgs e)
        {
            //.SelectedNode.FullPath.ToString());
            //switch (nbOcc("\\", tvSol.SelectedNode.FullPath.ToString()))
            lTVSel.Text = "Y";
            if (tvSol.SelectedNode != null) if (tvSol.SelectedNode.ImageIndex == 0 || tvSol.SelectedNode.ImageIndex == 3) tvSol.SelectedNode.SelectedImageIndex = 0;
        }


        
        private void cbEmploy_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //lEmp_ID.Text = MainMDI.Find_One_Field("select SA_ID from PSM_SALES_AGENTS where First_Name='" + cbEmploy.Text + "'");
            //if (lEmp_ID.Text == MainMDI.VIDE) lEmp_ID.Text = "";

            string[] arr_Val = new string[6] { "", "", "", "", "", "" };
            string stSql = "select SA_ID ,Extension,sfx,Email_Address from PSM_SALES_AGENTS where (First_Name + ' ' + Last_Name) ='" + cbEmploy.Text.Replace("'", "''") + "'";
            if (MainMDI.Find_arr_Fields(stSql, arr_Val) == MainMDI.VIDE) lEmp_ID.Text = "0";
            else
            {
                lEmp_ID.Text = arr_Val[0];
                lEExt.Text = arr_Val[1];
                lEmpSFX.Text = arr_Val[2];
                lemail.Text = arr_Val[3];
                
            }
        }
        
        private void cbLang_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            lLang.Text = cbLang.Text[0].ToString();
            maj_lang();

            //picFr.Visible = (cbLang.Text[0] == 'f' || cbLang.Text[0] == 'F');
            //picEng.Visible = (cbLang.Text[0] == 'E' || cbLang.Text[0] == 'e' || cbLang.Text[0] == 'b' || cbLang.Text[0] == 'B');
            //if (cbLang.Text[0] == 'E' || cbLang.Text[0] == 'B') MainMDI.Lang = 0;
            //if (cbLang.Text[0] == 'F') MainMDI.Lang = 1;
            //if (cbLang.Text[0] == 'I') MainMDI.Lang = 2; //3
        }

        void maj_lang()
        {
            picFr.Visible = false;
            picEng.Visible = false;
            picItaly.Visible = false;

            switch (cbLang.Text[0])
            {
                case 'F':
                    picFr.Visible = true;
                    MainMDI.Lang = 1;
                    break;
                case 'E':
                    picEng.Visible = true;
                    MainMDI.Lang = 0;
                    break;
                case 'I':
                    picItaly.Visible = true;
                    MainMDI.Lang = 2;
                    break;
            }
        }

        void orga_RSA(int cod)
        {
            //btnXL.Enabled = false;
            if (cod != 0)
            {
                if ((TV_RSA == 'R')) { bREV.Enabled = true; bALT.Enabled = true; bSYS.Enabled = false; btnXL.Enabled = true; btnFlow.Enabled = true; }
                if ((TV_RSA == 'S')) { bREV.Enabled = false; bALT.Enabled = false; bSYS.Enabled = true; btnFlow.Enabled = false; }
                if ((TV_RSA == 'A')) { bREV.Enabled = false; bALT.Enabled = false; bSYS.Enabled = false; btnFlow.Enabled = false; }
            }
            else { bREV.Enabled = false; bALT.Enabled = false; bSYS.Enabled = false; btnFlow.Enabled = false; }
        }

        private void tvSol_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            disp_solID.Text = ""; disp_altID.Text = ""; disp_alsID.Text = "";
            Tosave = false;
            string[] res = new string[] { "", "", "" };
            lTVSel.Text = "Y";
            //MessageBox.Show("path= " + tvSol.SelectedNode.FirstNode.Index.ToString());
            MainMDI.Deco_path(tvSol.SelectedNode.FullPath.ToString(), ref res);
            lCurSoln.Text = res[0];
            lCurSPCn.Text = res[1];
            lCurALSn.Text = res[2];

            AlsTOT_orig.Text = "";
            tAGprice.Text = "";
            tPxPrice.Text = "";
            AlsTOT.Clear();
            tALSnb.Text = "1";
            lrevDATE.Visible = true;
            string st1 = "", st2 = "";
            //lcurrImg.Text = "0";
            lvQITEMS.Items.Clear();

            switch (tvSol.SelectedNode.ImageIndex)
            {
                case 1: //Spec
                //case 4:
                    TV_RSA = 'S';
                    orga_RSA(1);
                    panel_Toto.Visible = false;
 
                    toolBar1.Items[4].Enabled = false;
                    printALS.Visible = false;
                    toolBar1.Items[5].Enabled = false;
                    toolBar1.Items[6].Enabled = true;
                    delSelected.Enabled = true;
                    lCurSolNDX.Text = tvSol.SelectedNode.Parent.Index.ToString();
                    lCurSPCNDX.Text = tvSol.SelectedNode.Index.ToString();
                    switch_ToolBar(1);
                    AlsTOT_orig.Text = "";
                    tAGprice.Text = "";
                    tPxPrice.Text = "";
                    tALSnb.Text = "";
                    AlterTOT.Text = MainMDI.Curr_FRMT(MainMDI.SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
                    //lcurSol_Status.Text = MainMDI.Find_One_Field("select status_Rev from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'");
                    MainMDI.Find_2_Field("select status_Rev ,date_Rev from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'", ref st1, ref st2);
                    lcurSol_Status.Text = st1; lrevDATE.Text = "Rev. Date: " + MainMDI.Eng_date(st2, "/");
                    //lcurSol_Status.Text = st1; lrevDATE.Text = "Rev. Date (yyyy/mm/dd): " + MainMDI.Eng_date(st2, "/");
                    break;
                case 0: //Alias / system
                case 3:
                    //Color oldCLR = Color.WhiteSmoke;
                    TV_RSA = 'A';

                    orga_RSA(1);

                    if (oldsysNDX != -1)
                    {
                        if (oldsysNDX < tvSol.Nodes[oldsolNDX].Nodes[oldspcNDX].Nodes.Count) tvSol.Nodes[oldsolNDX].Nodes[oldspcNDX].Nodes[oldsysNDX].BackColor = Color.WhiteSmoke;
                    }
                    tvSol.SelectedNode.BackColor = Color.PaleGreen;
                    panel_Toto.Visible = true;
                    switch_ToolBar(1);
                    tvSol.SelectedNode.SelectedImageIndex = 3;

                    delSelected.Enabled = false;

                    AlsTOT_orig.Text = "";
                    tAGprice.Text = "";
                    tPxPrice.Text = "";
                    tALSnb.Text = "1";
                    chk_savOVRG.Checked = false;
                    if (lCurALSn.Text != MainMDI.VIDE && lCurALSn.Text != "")
                    {
                        lCurSolNDX.Text = tvSol.SelectedNode.Parent.Parent.Index.ToString();
                    }
                    else lCurSolNDX.Text = tvSol.SelectedNode.Parent.Index.ToString();
                    lCurSPCNDX.Text = tvSol.SelectedNode.Parent.Index.ToString();
                    lCurALSNDX.Text = tvSol.SelectedNode.Index.ToString();
                    if (res[2] == "")
                    {
                        lCurALSn.Text = res[1];
                        lCurSPCn.Text = MainMDI.VIDE;
                        lCurSPCNDX.Text = tvSol.SelectedNode.Index.ToString();
                    }
                    OldAlsTot.Text = "";
                    if (Tools.Conv_Dbl(lCurrIQID.Text) > 0)
                    {
                        fill_details();

                        Ref_ALSTOT('S');
                        OldAlsTot.Text = AlsTOT_orig.Text;
                        printALS.Visible = true;
                        AlterTOT.Text = MainMDI.Curr_FRMT(MainMDI.SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
                        //lcurSol_Status.Text = MainMDI.Find_One_Field("select status_Rev from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'");

                        MainMDI.Find_2_Field("select status_Rev ,date_Rev from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'", ref st1, ref st2);
                        lcurSol_Status.Text = st1; lrevDATE.Text = "Rev. Date: " + MainMDI.Eng_date(st2, "/");
                    }
                    oldsysNDX = tvSol.SelectedNode.Index;
                    oldspcNDX = tvSol.SelectedNode.Parent.Index;
                    oldsolNDX = tvSol.SelectedNode.Parent.Parent.Index;
                    //lALSnb.Visible = true;
                    //tALSnb.Visible = true;

                    //AlterTOT.Text = A00(SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
                    break;
                case 2: //Solution
                case 5:
                case 4:
                    panel_Toto.Visible = false;
                    TV_RSA = 'R';

                    orga_RSA(1);

                    lrevDATE.Visible = true;
                    switch_ToolBar(1);
                    printALS.Visible = false;
                    toolBar1.Items[4].Enabled = true;
                    toolBar1.Items[5].Enabled = true;
                    toolBar1.Items[6].Enabled = false; //disable ADD-ALIAS
                    toolBar1.Items[7].Enabled = true;
                    lCurSolNDX.Text = tvSol.SelectedNode.Index.ToString();
                    //tALSnb.Text = "1";
                    AlsTOT_orig.Text = "";
                    tAGprice.Text = "";
                    tPxPrice.Text = "";
                    tALSnb.Text = "";
                    AlterTOT.Text = "";
                    delSelected.Enabled = false;
                    if (in_opera == 'C') for (int r = lvOrder.Items.Count - 1; r > -1; r--) delLvOrderALL(r);
                    //lcurSol_Status.Text = MainMDI.Find_One_Field("select status_Rev from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'");
                    //string st1 = "", st2 = "";
                    MainMDI.Find_2_Field("select status_Rev ,date_Rev from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'", ref st1, ref st2);

                    lcurSol_Status.Text = st1; lrevDATE.Text = "Rev. Date: " + MainMDI.Eng_date(st2, "/");
                    break;
            }
            lRevTOT.Text = MainMDI.Curr_FRMT(MainMDI.QREV_TOT(lCurrIQID.Text, lCurSoln.Text));
            xpndd.Visible = true;
            this.Cursor = Cursors.Default;
        }

        private void gbxTabs_Enter(object sender, System.EventArgs e)
        {

        }

        private void TGen_Click(object sender, System.EventArgs e)
        {

        }

        //BEGIN Prog. Methodes 

        private void del_Node()
        {
            switch (tvSol.SelectedNode.ImageIndex)
            {
                case 1: //Spec
                    del_Spc(lCurSoln.Text, lCurSPCn.Text);
                    break;
                case 0: //Alias
                case 3:
                    if (lCurSPCn.Text == MainMDI.VIDE) del_Spc(lCurSoln.Text, lCurSPCn.Text);
                    else del_Als(lCurSoln.Text, lCurSPCn.Text, lCurALSn.Text);
                    break;
                case 2: //Solution
                case 5:
                case 4:
                    del_Sol(tvSol.SelectedNode.Text);
                    break;
            }
        }

        //#########

        private void del_Spc(string sName, string pName)
        {
            string stSql = "SELECT PSM_Q_SPCS.SPC_LID FROM PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID " +
                " WHERE PSM_Q_SOL.Sol_Name='" + sName.Replace("'", "''") + "' AND PSM_Q_SPCS.SPC_Name='" + pName.Replace("'", "''") + "' AND PSM_Q_SOL.I_Quoteid=" + lCurrIQID.Text;
            string st = MainMDI.Find_One_Field(stSql);

            if (st != MainMDI.VIDE)
            {
                MainMDI.ExecSql("delete PSM_Q_SPCS where SPC_LID=" + st);
                MainMDI.Write_JFS("delete AlternA: " + sName + "/" + pName + "...Q#" + tQuoteID.Text + "------SQL=" + stSql);
                tvSol.SelectedNode.Remove();
            }
        }

        bool canDEL_SPC(string alsid)
        {
            string spclid = MainMDI.Find_One_Field("select [SPC_LID] from [dbo].[PSM_Q_ALS] where [ALS_LID]=" + alsid);
            if (spclid != MainMDI.VIDE)
            {
                string nbALS = MainMDI.Find_One_Field("select count(*) from PSM_Q_ALS where SPC_LID=" + spclid);
                return (Tools.Conv_Dbl(nbALS) > 1);
            }
            return false;
        }

        private void del_Als(string sName, string pName, string aName)
        {
            //string stSql = "SELECT PSM_Q_ALS.ALS_LID FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                //" WHERE (((PSM_Q_SOL.Sol_Name)='" + sName + "') AND ((PSM_Q_SPCS.SPC_Name)='" + pName + "') AND ((PSM_Q_ALS.ALS_Name)='" + aName + "'))";
            string stSql = "SELECT PSM_Q_ALS.ALS_LID FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " WHERE PSM_Q_SOL.Sol_Name='" + sName.Replace("'", "''") + "' AND PSM_Q_SPCS.SPC_Name='" + pName.Replace("'", "''") + "' AND PSM_Q_ALS.ALS_Name='" + aName.Replace("'", "''") + "' AND PSM_Q_SOL.I_Quoteid=" + lCurrIQID.Text;
            string st = MainMDI.Find_One_Field(stSql);

            if (st != MainMDI.VIDE)
            {
                if (canDEL_SPC(st))
                {
                    stSql = "delete PSM_Q_ALS where ALS_LID=" + st;
                    string stSqlDetail = "delete PSM_Q_Details where ALS_LID=" + st;
                    MainMDI.ExecSql(stSql);
                    MainMDI.Exec_SQL_JFS(stSqlDetail, "del_Als:  " + stSqlDetail); //delete all details because no Diagram for Qoutes
                    tvSol.SelectedNode.Remove();
                    Reo_ALS();
                    MainMDI.Write_JFS("Alias: " + sName + "/" + pName + "/" + aName + "...Q#" + tQuoteID.Text + "------SQL=" + stSql);
                }
                else MessageBox.Show("Sorry you cannot delete This SYSTEM.....try deleting its parent-alternative....");
            }
            //AlterTOT.Text = A00(SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
        }

        private void Reo_ALS()
        {
            int Solndx = Convert.ToInt32(lCurSolNDX.Text);
            int SpcNdx = Convert.ToInt32(lCurSPCNDX.Text);
            string SpcLid = MainMDI.Find_One_Field(" SELECT PSM_Q_ALS.SPC_LID " +
                " FROM PSM_Q_ALS INNER JOIN PSM_Q_SPCS ON PSM_Q_ALS.SPC_LID = PSM_Q_SPCS.SPC_LID INNER JOIN PSM_Q_SOL ON PSM_Q_SPCS.Sol_LID = PSM_Q_SOL.Sol_LID " +
                " WHERE PSM_Q_SPCS.SPC_Name ='" + lCurSPCn.Text + "' AND PSM_Q_SOL.I_Quoteid =" + lCurrIQID.Text + " AND PSM_Q_SOL.Sol_Name ='" + lCurSoln.Text + "'");
            if (SpcLid != MainMDI.VIDE)
            {
                for (int i = 0; i < tvSol.Nodes[Solndx].Nodes[SpcNdx].Nodes.Count; i++)
                {
                    string alsNm = tvSol.Nodes[Solndx].Nodes[SpcNdx].Nodes[i].Text;
                    string myals = (alsNm.Length > 0) ? alsNm : "Toto#" + i.ToString();
                    string stSql = " UPDATE PSM_Q_ALS  SET [Rnk]='" + i + "' WHERE SPC_LID=" + SpcLid + " and ALS_Name='" + myals + "'";
                    MainMDI.Exec_SQL_JFS(stSql, "Reo_ALS:  " + stSql);
                }
            }
        }

        private void del_Sol(string sName)
        {
            string stSql = "delete PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + sName.Replace("'", "''") + "'";
            MainMDI.ExecSql(stSql);
            tvSol.SelectedNode.Remove();
            MainMDI.Write_JFS("delete Revision: " + sName + "...Q#" + tQuoteID.Text + "------SQL=" + stSql.Replace("'", "-"));
        }

        private void fill_SolOLD()
        {
            string stSql = "SELECT PSM_Q_IGen.Quote_ID, PSM_Q_SOL.Sol_Name,PSM_Q_SOL.img, PSM_Q_SPCS.SPC_Name, PSM_Q_ALS.ALS_Name , PSM_Q_SOL.Rnk AS s, PSM_Q_SPCS.Rnk AS p, PSM_Q_ALS.Rnk AS a " +
                " FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) " +
                " INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " WHERE (((PSM_Q_IGen.i_Quoteid)=" + lCurrIQID.Text + ")) ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string Osol = "", Nsol = "", Ospc = "", Nspc = "", Nals = "";
            int s = -1, p = -1;
            while (Oreadr.Read())
            {
                Nsol = Oreadr["Sol_Name"].ToString();
                Nspc = Oreadr["SPC_Name"].ToString();
                Nals = Oreadr["ALS_Name"].ToString();
                if (Osol != Nsol)
                {
                    p = -1;
                    s++; addNode_Sol(Nsol, Oreadr["img"].ToString(), "N");
                    p++; addNode_Spc(Nspc, s, p, Nals);
                    //addNode_Als(Nals, s, p);
                    Osol = Nsol; Ospc = Nspc;
                }
                else
                {
                    if (Ospc != Nspc)
                    {
                        p++;
                        addNode_Spc(Nspc, s, p, Nals);
                        Ospc = Nspc;
                    }
                    else addNode_Als(Nals, s, p);
                }
            }
            Quote_loaded = true;
            tvSol.Select();
        }

        private void fill_Sol()
        {
            //string stSql = "SELECT PSM_Q_IGen.Quote_ID, PSM_Q_SOL.Sol_Name,PSM_Q_SOL.img,PSM_Q_SOL.status_Rev, PSM_Q_SPCS.SPC_Name, PSM_Q_ALS.ALS_Name , PSM_Q_SOL.Rnk AS s, PSM_Q_SPCS.Rnk AS p, PSM_Q_ALS.Rnk AS a " +
                //" FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) " +
                //" INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                //" WHERE (((PSM_Q_IGen.i_Quoteid)=" + lCurrIQID.Text + ")) ORDER BY PSM_Q_SOL.Rnk,PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk ";

            string stSql = "SELECT PSM_Q_IGen.Quote_ID, PSM_Q_SOL.Sol_Name,PSM_Q_SOL.img,PSM_Q_SOL.status_Rev, PSM_Q_SPCS.SPC_Name, PSM_Q_ALS.ALS_Name , PSM_Q_SOL.Rnk AS s, PSM_Q_SPCS.Rnk AS p, PSM_Q_ALS.Rnk AS a " +
                " FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) " +
                " INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " WHERE (((PSM_Q_IGen.i_Quoteid)=" + lCurrIQID.Text + ")) ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string Osol = "", Nsol = "", Ospc = "", Nspc = "", Nals = "", N_SpcRnk = "", O_SpcRnk = "";
            int s = -1, p = -1;
            while (Oreadr.Read())
            {
                Nsol = Oreadr["Sol_Name"].ToString();
                Nspc = Oreadr["SPC_Name"].ToString();
                Nals = Oreadr["ALS_Name"].ToString();
                N_SpcRnk = Oreadr["p"].ToString();
                if (Osol != Nsol)
                {
                    p = -1;
                    s++; addNode_Sol(Nsol, Oreadr["img"].ToString(), Oreadr["status_Rev"].ToString());

                    p++; addNode_Spc(Nspc, s, p, Nals);
                    //addNode_Als(Nals, s, p);
                    Osol = Nsol;
                    Ospc = Nspc;
                    O_SpcRnk = N_SpcRnk;
                }
                else
                {
                    if (Ospc == Nspc && N_SpcRnk == O_SpcRnk) addNode_Als(Nals, s, p);
                    else
                    {
                        //addNode_Als(Nals, s, p);
                        p++;
                        addNode_Spc(Nspc, s, p, Nals);
                        Ospc = Nspc;
                        O_SpcRnk = N_SpcRnk;
                    }
                }
            }
            Quote_loaded = true;
            tvSol.Select();
        }

        private void addNode_Sol(string sName, string img, string Sol_stat)
        {
            int imgI = (img == "") ? 2 : Convert.ToInt32(img);
            tvSol.Nodes.Add(sName);
            tvSol.Nodes[tvSol.Nodes.Count - 1].ImageIndex = imgI;
            tvSol.Nodes[tvSol.Nodes.Count - 1].SelectedImageIndex = imgI;
            if (Sol_stat == "C") tvSol.Nodes[tvSol.Nodes.Count - 1].ForeColor = Color.Blue;
        }

        private void addNode_Spc(string spcName, int s, int p, string aName)
        {
            if (spcName == MainMDI.VIDE) addNode_SPCNA(aName, s);
            else
            {
                tvSol.Nodes[s].Nodes.Add(spcName);
                tvSol.Nodes[s].Expand();
                tvSol.Nodes[s].Nodes[tvSol.Nodes[s].Nodes.Count - 1].SelectedImageIndex = 1;
                tvSol.Nodes[s].Nodes[tvSol.Nodes[s].Nodes.Count - 1].ImageIndex = 1;
                addNode_Als(aName, s, p);
            }
        }

        private void addNode_Als(string alsName, int s, int p)
        {
            tvSol.Nodes[s].Nodes[p].Nodes.Add(alsName);
            tvSol.Nodes[s].Expand();
            tvSol.Nodes[s].Nodes[p].Nodes[tvSol.Nodes[s].Nodes[p].Nodes.Count - 1].SelectedImageIndex = 0;
            tvSol.Nodes[s].Nodes[p].Nodes[tvSol.Nodes[s].Nodes[p].Nodes.Count - 1].ImageIndex = 0;
        }

        private void addNode_SPCNA(string alsName, int s)
        {
            tvSol.Nodes[s].Nodes.Add(alsName);
            tvSol.Nodes[s].Nodes[tvSol.Nodes[s].Nodes.Count - 1].SelectedImageIndex = 0;
            tvSol.Nodes[s].Nodes[tvSol.Nodes[s].Nodes.Count - 1].ImageIndex = 0;
        }

        private void fill_LVQITEM()
        {
            //lvQITEMS.Clear();
            //for (int i = 0; i < MainMDI.MAX_ALS_Lines; i++)
            //{
                //ListViewItem lvI = lvQITEMS.Items.Add("");
                //if (curr_ALS[i, 0] != "")
                //{
                    //for (int j = 1; j < MainMDI.MAX_ALS_COLs; j++)
                        //lvI.SubItems.Add(curr_ALS[i, j]);
                //}
                //else break;
            //}
        }

        private void init_Curr_ALS()
        {
            //als_NDX = 0;
            //for (int i = 0; i < MainMDI.MAX_ALS_Lines; i++)
                //for (int j = 0; j < MainMDI.MAX_ALS_COLs; j++)
                    //curr_ALS[i, j] = "";
        }

        private int nbOcc(string c, string st)
        {
            int nb = 0;
            for (int i = 0; i < st.Length; i++) if (st[i] == c[0]) nb++;
            return nb;
        }

        private void fill_cb_ContactsNew(long cpnyID)
        {
            string stSql = (cpnyID == 0) ? "select * FROM PSM_Contacts " : "select * FROM PSM_Contacts  where  Company_ID=" + cpnyID + "";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            cbContacts.Items.Clear();
            cbCPmgr.Items.Clear();
            while (Oreadr.Read())
            {
                cbContacts.Items.Add(Oreadr["First_Name"].ToString() + " " + Oreadr["Last_Name"].ToString());
                cbCPmgr.Items.Add(Oreadr["First_Name"].ToString() + " " + Oreadr["Last_Name"].ToString());
            }
            if (cbContacts.Items.Count > 0)
            {
                cbContacts.Text = cbContacts.Items[0].ToString();
                cbCPmgr.Text = cbContacts.Items[0].ToString();
            }
            OConn.Close();
        }

        private void fill_cb_Contacts(long cpnyID)
        {
            //string stSql = "select * FROM PSM_Contacts  where  Company_ID=" + cpnyID + "";
            string stSql = (in_opera == 'N') ? "select * FROM PSM_Contacts  where  Company_ID=" + cpnyID + "and JOBTitle<>'~~' Order by First_Name" : "select * FROM PSM_Contacts  where  Company_ID=" + cpnyID + "  Order by First_Name";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            cbContacts.Items.Clear();
            cbCPmgr.Items.Clear();
            while (Oreadr.Read())
            {
                cbContacts.Items.Add(Oreadr["First_Name"].ToString() + " " + Oreadr["Last_Name"].ToString());
                cbCPmgr.Items.Add(Oreadr["First_Name"].ToString() + " " + Oreadr["Last_Name"].ToString());
            }
            if (cbContacts.Items.Count > 0)
            {
                cbContacts.Text = cbContacts.Items[0].ToString();
                cbCPmgr.Text = cbContacts.Items[0].ToString();
            }
            OConn.Close();
        }

        private void fill_cb_Terms()
        {
            string stSql = "select Descr FROM PSM_Terms";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            cbTerms.Items.Clear();
            while (Oreadr.Read()) cbTerms.Items.Add(Oreadr[0].ToString());
            OConn.Close();
        }

        private void fill_cb_Via()
        {
            string stSql = "select ShipEng FROM PSM_ShipMeth";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            cbShipVia.Items.Clear();
            while (Oreadr.Read()) cbShipVia.Items.Add(Oreadr[0].ToString());
            OConn.Close();
        }

        private void fill_cb_Inco()
        {
            string stSql = "select IT_DESC FROM PSM_IncoTerm";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            cbIncoTerm.Items.Clear();
            while (Oreadr.Read()) cbIncoTerm.Items.Add(Oreadr[0].ToString());
            OConn.Close();
        }

        private void save_Adrs(char c_adrs)
        {
            string stSql = "";
            switch (c_adrs)
            {
                case 'Q':
                    stSql = "UPDATE PSM_Company SET [Q_Adrs]='" + lQA.Text + "' WHERE Cpny_ID=" + lcpnyID.Text;
                    break;
                case 'S':
                    stSql = "UPDATE PSM_Company SET [S_Adrs]='" + lSA.Text + "' WHERE Cpny_ID=" + lcpnyID.Text;
                    break;
                case 'I':
                    stSql = "UPDATE PSM_Company SET [I_Adrs]='" + lIA.Text + "' WHERE Cpny_ID=" + lcpnyID.Text;
                    break;
                case 'P':
                    stSql = "UPDATE PSM_Company SET [P_Adrs]='" + lPA.Text + "' WHERE Cpny_ID=" + lcpnyID.Text;
                    break;
            }
            MainMDI.ExecSql(stSql);
        }

        private void fill_NewMLTP(string _CAN, string _US, string _EURO)
        {
            STDMultp_CAN = _CAN;
            STDMultp_US = _US;
            STDMultp_EURO = _EURO;
            //get default Mltp based on activity 
            if (opCan.Checked)
                STDMultp.Text = STDMultp_CAN;
            else
            {
                if (opEuro.Checked) STDMultp.Text = STDMultp_EURO;
                else STDMultp.Text = STDMultp_US;
            }
        }

        private void check_Activity()
        {
            if (lActivty.Text.ToLower() == "no activity")
            {
                string stil = (picALRM_mltp.Visible == true) ? " still " : "";
                picALRM_mltp.Visible = true;
                //#########
                //MessageBox.Show(" Customer ACTIVITY is " + stil + " Invalid \n press on 'Change Activity' button to correct it...");
            }
            else picALRM_mltp.Visible = false;
        }

        private void Ref_GetActivy_MLTPL()
        {
            string stSql = " SELECT     PSM_CmpnyTYPE.* FROM   PSM_COMPANY INNER JOIN  PSM_CmpnyTYPE ON PSM_COMPANY.CustomerType = PSM_CmpnyTYPE.CpnyType_ID " +
                " where Cpny_ID=" + lcpnyID.Text;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                if (lActivty.Text != Oreadr["CpnyType"].ToString())
                {
                    lActivty.Text = Oreadr["CpnyType"].ToString();
                    fill_NewMLTP(Oreadr["multpl1"].ToString(), Oreadr["multpl1_US"].ToString(), Oreadr["multpl1_EURO"].ToString());

                    //gets current MLTP if exists else it gets default One
                    string _st = MainMDI.Find_One_Field("select " + Curr_SQLMLTP + " from PSM_Cmpny_CurrMLTP where Cpny_ID=" + lcpnyID.Text);
                    if (_st != MainMDI.VIDE)
                    {
                        tCust_Mult.Text = _st;
                    }
                    else tCust_Mult.Text = STDMultp.Text;
                }
            }
            OConn.Close();
        }

        private void fill_Company_Info(string cpnyName, char adrs)
        {
            bool msg_err = false;
            string stSql = "SELECT PSM_Company.*, PSM_CmpnyTYPE.multpl1, PSM_CmpnyTYPE.multpl1_US,PSM_CmpnyTYPE.multpl1_EURO,  PSM_CmpnyTYPE.CpnyType FROM PSM_Company INNER JOIN PSM_CmpnyTYPE ON PSM_Company.CustomerType = PSM_CmpnyTYPE.CpnyType_ID where  Cpny_Name1='" + cpnyName.Replace("'", "''") + "'";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                if (adrs == '*')
                {
                    lcpnyID.Text = Oreadr["Cpny_ID"].ToString();
                    Q_sysPcod.Text = Oreadr["Syspro_Code"].ToString();
                    if (Oreadr["Syspro_Code"].ToString() == "0")
                    {
                        //MessageBox.Show("COMPANY NOT FOUND IN SYSPRO...........must be created in sysPro !!!!", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        picSPcode.Visible = true;
                    }
                    //Imp_cpnyID = Oreadr["Cpny_ID"].ToString();
                    //disp XTRN Sale Name, Code
                    lSP_Name.ForeColor = Color.Black;
                    lSP_Name.Text = MainMDI.Find_One_Field_SYSPRO("select distinct  dbo.v_PGSalesperson.Salesperson +'  ' +dbo.v_PGSalesperson.Name from dbo.v_PGCustomerXRef inner join dbo.v_PGSalesperson on dbo.v_PGSalesperson.Salesperson=dbo.v_PGCustomerXRef.Salesperson where Customer='" + Q_sysPcod.Text + "'");
                    lSalesName.Text = lSP_Name.Text;

                    //22062017

                    string sysPcurr = MainMDI.Find_One_Field_SYSPRO("SELECT [Currency]  FROM [SysproCompanyP].[dbo].[v_PGCustomerXRef] where Customer='" + Q_sysPcod.Text + "'");
                    btnSP_Currncy.Text = sysPcurr;
                    alrm_SPcurrncy.Visible = (Q_sysPcod.Text[Q_sysPcod.Text.Length - 1] == 'U' && sysPcurr == "CAD");
                    if (alrm_SPcurrncy.Visible) MessageBox.Show("This quote cannot be saved because of Currency ERROR (US Customers must have USD not CAD... ");
                    //22062017

                    //07112016
                    string salP = lSP_Name.Text.Substring(0, 3);
                    string SalPemail = MainMDI.VIDE, SalPCell = MainMDI.VIDE;
                    MainMDI.Find_2_Field("select  Email_Address, [Cell Number] from PSM_SALES_AGENTS where SP_CODE ='" + salP + "'", ref SalPemail, ref SalPCell);
                    lOutSaleCell.Text = SalPCell;
                    lOutSaleemail.Text = SalPemail;
                    //07112016

                    //28052018
                    lagentcode.Text = Oreadr["Agent"].ToString();
                    string st = MainMDI.Find_One_Field_SYSPRO("select Name  from SalSalesperson where Salesperson='" + lagentcode.Text + "'");
                    lagent.Text = (st == MainMDI.VIDE) ? "??????" : st;
                    //28052018

                    lExtSid.Text = MainMDI.Find_One_Field_SYSPRO("select dbo.v_PGCustomerXRef.Salesperson from dbo.v_PGCustomerXRef where Customer='" + Q_sysPcod.Text + "'");
                    if ((!msg_err) && (lExtSid.Text == "H03" || lExtSid.Text == MainMDI.VIDE))
                    {
                        //MessageBox.Show("You may check:  EXTERNAL SALE NAME for this Customer in SYSPRO before Saving Quote....(SYSPRO) ", "EXTERNAL SALE NAME", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        msg_err = true;
                        picOutSales.Visible = true;
                        lSP_Name.ForeColor = Color.Red;
                    }
                    //lSP_Name.ForeColor = (lExtSid.Text == "H03" || lExtSid.Text == MainMDI.VIDE) ? Color.Red : Color.Black;
                    lExlam.Visible = (lExtSid.Text == "H03" || lExtSid.Text == MainMDI.VIDE);

                    //

                    lAdrs.Text = "\t\n " +Oreadr["M_Adrs"].ToString(); //+ ", " + Oreadr["City"].ToString() + ", " + Oreadr["Province_State"].ToString() + ", " + Oreadr["Country_Name"].ToString();
                    lActivty.Text = Oreadr["CpnyType"].ToString();
                    fill_NewMLTP(Oreadr["multpl1"].ToString(), Oreadr["multpl1_US"].ToString(), Oreadr["multpl1_EURO"].ToString());

                    //gets current MLTP if exists else it gets default One
                    string _st = MainMDI.Find_One_Field("select " + Curr_SQLMLTP + " from PSM_Cmpny_CurrMLTP where Cpny_ID=" + lcpnyID.Text);
                    if (_st != MainMDI.VIDE)
                    {
                        tCust_Mult.Text = _st;
                    }
                    else tCust_Mult.Text = STDMultp.Text;

                    check_Activity();

                    lFax.Text = Oreadr["Fax"].ToString();
                    string stt = MainMDI.Find_One_Field("select Descr from PSM_Terms where InTermId=" + Oreadr["TermID"].ToString());
                    if (stt != MainMDI.VIDE) cbTerms.Text = stt;
                    st = MainMDI.Find_One_Field("select ShipEng from PSM_ShipMeth where ship_ID=" + Oreadr["ShipVia_ID"].ToString());
                    if (st != MainMDI.VIDE) cbShipVia.Text = st;
                    st = MainMDI.Find_One_Field("select IT_DESC from PSM_IncoTerm where IT_ID=" + Oreadr["IncoTerm_ID"].ToString());
                    if (st != MainMDI.VIDE) cbTerms.Text = st;
                    cbCurr.Text = Oreadr["Currency"].ToString();
                }
                else
                {
                    switch (adrs)
                    {
                        case 'Q':
                            lQA.Text = (Oreadr["Q_Adrs"].ToString().Length < 4) ? Oreadr["M_Adrs"].ToString() : Oreadr["Q_Adrs"].ToString().Replace("\r\n", " ");
                            break;
                        case 'S':
                            //lSA.Text = Oreadr["S_Adrs"].ToString();
                            lSA.Text = (Oreadr["S_Adrs"].ToString().Length < 4) ? Oreadr["M_Adrs"].ToString() : Oreadr["S_Adrs"].ToString().Replace("\r\n", " ");
                            break;
                        case 'I':
                            //lIA.Text = Oreadr["I_Adrs"].ToString();
                            lIA.Text = (Oreadr["I_Adrs"].ToString().Length < 4) ? Oreadr["M_Adrs"].ToString() : Oreadr["I_Adrs"].ToString().Replace("\r\n", " ");
                            break;
                        case 'P':
                            //lPA.Text = Oreadr["P_Adrs"].ToString();
                            lPA.Text = (Oreadr["P_Adrs"].ToString().Length < 4) ? Oreadr["M_Adrs"].ToString() : Oreadr["P_Adrs"].ToString().Replace("\r\n", " ");
                            break;
                    }
                }
            }
            OConn.Close();

            fill_cb_AG_SYSPRO(1); fill_cb_AG_SYSPRO(2);
            cbAG1.Text = cbAG1.Items[0].ToString();
            cbAG2.Text = cbAG2.Items[0].ToString();
        }

        private void fill_details()
        {
            loading = true;
            disp_solID.Text = ""; disp_altID.Text = ""; disp_alsID.Text = "";
            OptionCount = 0;
            ItemCount = 0;
            Opt_added = false;
            string stSql = "SELECT PSM_Q_Details.*, PSM_Q_SOL.I_Quoteid, PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name, PSM_Q_ALS.ALS_Name, PSM_Q_ALS.PxPrice,PSM_Q_ALS.AGPrice ,PSM_Q_ALS.AlsQty,PSM_Q_ALS.SV_Ovrg, PSM_Q_SOL.Sol_LID, PSM_Q_SPCS.SPC_LID " +
                " FROM ((PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID) INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID " +
                " WHERE (PSM_Q_SOL.I_Quoteid=" + lCurrIQID.Text + " AND PSM_Q_SOL.Sol_Name='" + lCurSoln.Text + "' AND PSM_Q_SPCS.SPC_Name='" + lCurSPCn.Text.Replace("'", "''") + "' AND PSM_Q_ALS.ALS_Name='" + lCurALSn.Text.Replace("'", "''") +
                "') ORDER BY PSM_Q_Details.Rnk";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            //added 14/06/07
            AlsTOT_orig.Text = "";
            tAGprice.Text = "";
            tPxPrice.Text = "";
            tALSnb.Text = "1";
            AlsTOT.Clear();
            //added 14/06/07

            //tsslTXT.Text = DateTime.Now.ToShortTimeString();
            lvQITEMS.BeginUpdate();
            while (Oreadr.Read())
            {
                if (disp_alsID.Text == "")
                {
                    disp_alsID.Text = Oreadr["ALS_LID"].ToString();
                    disp_altID.Text = Oreadr["SPC_LID"].ToString();
                    disp_solID.Text = Oreadr["Sol_LID"].ToString();
                }
                if (Tools.Conv_Dbl(tPxPrice.Text) == 0 && Oreadr["PxPrice"].ToString() != "0")
                {
                    tPxPrice.Text = MainMDI.A00(Oreadr["PxPrice"].ToString());
                    tAGprice.Text = MainMDI.A00(Oreadr["AGPrice"].ToString());
                    tALSnb.Text = Oreadr["AlsQty"].ToString();
                    AlsTOT.Text = MainMDI.A00(Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["PxPrice"].ToString()) / Tools.Conv_Dbl(Oreadr["AlsQty"].ToString()), MainMDI.NB_DEC_AFF)));
                    chk_savOVRG.Checked = (Oreadr["SV_Ovrg"].ToString() == "True");
                }
                //if (Oreadr["Desc"].ToString() == MainMDI.arr_EFSdict[21, 0] + "=  " || Oreadr["Desc"].ToString() == MainMDI.arr_EFSdict[21, 1] + "=  ") Opt_added = true;
                ListViewItem lvI = lvQITEMS.Items.Add("");
                //if (in_opera != 'C') lvI.Checked = (Oreadr["Xch_Mult"].ToString() == "1");
                lvI.Checked = true;
                lvI.SubItems.Add(Oreadr["Aff_ID"].ToString());
                if (Oreadr["Aff_ID"].ToString() != ".")
                {
                    if (Oreadr["Aff_ID"].ToString() != " ")
                    {
                        lvI.BackColor = Color.Salmon; ItemCount = Convert.ToInt32(Oreadr["Aff_ID"].ToString());
                        if (Oreadr["Q_tec_Val"].ToString().Length > 6)
                            if (Oreadr["Q_tec_Val"].ToString().Substring(0, 5) == "BNS||") lvI.BackColor = BNS_color;
                    }
                }
                else
                {
                    if (Oreadr["Desc"].ToString().IndexOf("= ", 0) != -1) { lvI.BackColor = Color.LightYellow; Opt_added = true; }
                    else OptionCount++;
                }
                lvI.SubItems.Add(Oreadr["Desc"].ToString());
                if (Oreadr["Qty"].ToString() != "0") lvI.SubItems.Add(Oreadr["Qty"].ToString());
                else lvI.SubItems.Add("");
                if (Oreadr["Mult"].ToString() != "0") lvI.SubItems.Add(MainMDI.A00(Oreadr["Mult"].ToString()));
                else lvI.SubItems.Add("");
                if (Oreadr["Uprice"].ToString() != "0") lvI.SubItems.Add(MainMDI.A00(Oreadr["Uprice"].ToString()));
                else lvI.SubItems.Add("");
                //if (Oreadr["Xch_Mult"].ToString() != "0") lvI.SubItems.Add(MainMDI.A00(Oreadr["Xch_Mult"].ToString())); else lvI.SubItems.Add("");
                if (Oreadr["Ext"].ToString() != "0")
                {
                    //int _ndxgrp = Int32.Parse(Oreadr["Xch_Mult"].ToString());
                    int _ndxgrp = (int)Tools.Conv_Dbl(Oreadr["Xch_Mult"].ToString()); //Xch_Mult saves item_group
                    string grp = (_ndxgrp > 0) ? CB_Group.Items[_ndxgrp - 1].ToString() : "A";
                    lvI.SubItems.Add(grp);
                    lvI.SubItems.Add(MainMDI.A00(Oreadr["Ext"].ToString()));
                }
                else { lvI.SubItems.Add(""); lvI.SubItems.Add(""); }
                //if (Oreadr["Uprice"].ToString() != "0" && Oreadr["Qty"].ToString() != "0" && Oreadr["Xch_Mult"].ToString() != "0")
                //{
                    //lvI.SubItems.Add(MainMDI.A00(Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["Qty"].ToString()) * Tools.Conv_Dbl(Oreadr["Uprice"].ToString()) * Tools.Conv_Dbl(tCust_Mult.Text) * Tools.Conv_Dbl(Oreadr["Xch_Mult"].ToString()), Charger.NB_DEC_AFF))));
                    //P_AlsTot(stSql);
                //}
                //else lvI.SubItems.Add("");
                if (Oreadr["LeadTime"].ToString() != "0") lvI.SubItems.Add(Oreadr["LeadTime"].ToString());
                else lvI.SubItems.Add("");
                lvI.SubItems.Add(""); //for nbDef
                lvI.SubItems.Add(Oreadr["PN"].ToString()); //for PN
                if (in_opera == 'C') lvI.SubItems.Add(Oreadr["Detail_LID"].ToString());
                else lvI.SubItems.Add("");
                lvI.SubItems.Add(Oreadr["Q_tec_Val"].ToString());
            }
            tXRATE.Text = "";
            lvQITEMS.EndUpdate();
            loading = false;

            //tsslTXT.Text += "     " + DateTime.Now.ToShortTimeString();
        }

        private bool fill_Qot(long Qid, string CpnyName)
        {
            //string stSql = "SELECT PSM_Q_IGen.*, PSM_Company.Cpny_Name1, PSM_SALES_AGENTS_8.First_Name & ' ' & PSM_SALES_AGENTS_8.Last_Name AS employ, PSM_Terms.Descr, PSM_IncoTerm.IT_DESC, PSM_ShipMeth.ShipEng, PSM_Contacts.[First_Name], PSM_Contacts.[Last_Name], PSM_SALES_AGENTS.First_Name & ' ' & PSM_SALES_AGENTS.Last_Name AS SI_nm, PSM_SALES_AGENTS_2.First_Name & ' ' & PSM_SALES_AGENTS_2.Last_Name AS SO_nm, PSM_SALES_AGENTS_1.First_Name & ' ' & PSM_SALES_AGENTS_1.Last_Name AS SE_nm, PSM_SALES_AGENTS_3.First_Name & ' ' & PSM_SALES_AGENTS_3.Last_Name AS SP_nm, PSM_SALES_AGENTS_4.First_Name & ' ' & PSM_SALES_AGENTS_4.Last_Name as AD_nm, PSM_SALES_AGENTS_5.First_Name & ' ' & PSM_SALES_AGENTS_5.Last_Name as AI_nm, PSM_SALES_AGENTS_6.First_Name & ' ' & PSM_SALES_AGENTS_6.Last_Name AS AE_nm, PSM_SALES_AGENTS_7.First_Name & ' ' & PSM_SALES_AGENTS_7.Last_Name AS AP_nm " +
                //" FROM (((((((((((((PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID) INNER JOIN PSM_Contacts ON PSM_Q_IGen.Contact_ID = PSM_Contacts.Contact_ID) INNER JOIN PSM_Terms ON PSM_Q_IGen.Term_ID = PSM_Terms.InTermId) INNER JOIN PSM_ShipMeth ON PSM_Q_IGen.Via_ID = PSM_ShipMeth.ship_ID) INNER JOIN PSM_IncoTerm ON PSM_Q_IGen.IncoTerm_ID = PSM_IncoTerm.IT_ID) INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.SI = PSM_SALES_AGENTS.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_2 ON PSM_Q_IGen.SO = PSM_SALES_AGENTS_2.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_1 ON PSM_Q_IGen.SE = PSM_SALES_AGENTS_1.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_3 ON PSM_Q_IGen.SP = PSM_SALES_AGENTS_3.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_4 ON PSM_Q_IGen.AD = PSM_SALES_AGENTS_4.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_5 ON PSM_Q_IGen.AI = PSM_SALES_AGENTS_5.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_6 ON PSM_Q_IGen.AE = PSM_SALES_AGENTS_6.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_7 ON PSM_Q_IGen.AP = PSM_SALES_AGENTS_7.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_8 ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS_8.SA_ID " +
                //" WHERE (((PSM_Q_IGen.Quote_ID)=" + Qid + ") and ((PSM_Company.Cpny_Name1)='" + CpnyName + "') ) ORDER BY PSM_Q_IGen.Quote_ID, PSM_Q_IGen.CPNY_ID ";
            string stSql = "SELECT PSM_Q_IGen.*, PSM_Company.Cpny_Name1, PSM_SALES_AGENTS_8.First_Name + ' ' + PSM_SALES_AGENTS_8.Last_Name AS employ, PSM_Terms.Descr, PSM_IncoTerm.IT_DESC, PSM_ShipMeth.ShipEng, PSM_Contacts.First_Name, PSM_Contacts.Last_Name, PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS SI_nm, PSM_SALES_AGENTS_2.First_Name + ' ' + PSM_SALES_AGENTS_2.Last_Name AS SO_nm, PSM_SALES_AGENTS_1.First_Name + ' ' + PSM_SALES_AGENTS_1.Last_Name AS SE_nm, PSM_SALES_AGENTS_3.First_Name + ' ' + PSM_SALES_AGENTS_3.Last_Name AS SP_nm, PSM_SALES_AGENTS_4.First_Name AS AD_nm, PSM_SALES_AGENTS_5.First_Name AS AI_nm, PSM_SALES_AGENTS_6.First_Name AS AE_nm, PSM_SALES_AGENTS_7.First_Name AS AP_nm, [PSM_SALES_AGENTS_9].[First_Name] + ' ' + [PSM_SALES_AGENTS_9].[Last_Name] AS IPM, PSM_Contacts_1.First_Name + ' ' + PSM_Contacts_1.Last_Name AS CPM" +
                " FROM (((((((((((((((PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID) INNER JOIN PSM_Contacts ON PSM_Q_IGen.Contact_ID = PSM_Contacts.Contact_ID) INNER JOIN PSM_Terms ON PSM_Q_IGen.Term_ID = PSM_Terms.InTermId) INNER JOIN PSM_ShipMeth ON PSM_Q_IGen.Via_ID = PSM_ShipMeth.ship_ID) INNER JOIN PSM_IncoTerm ON PSM_Q_IGen.IncoTerm_ID = PSM_IncoTerm.IT_ID) INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.SI = PSM_SALES_AGENTS.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_2 ON PSM_Q_IGen.SO = PSM_SALES_AGENTS_2.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_1 ON PSM_Q_IGen.SE = PSM_SALES_AGENTS_1.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_3 ON PSM_Q_IGen.SP = PSM_SALES_AGENTS_3.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_4 ON PSM_Q_IGen.AD = PSM_SALES_AGENTS_4.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_5 ON PSM_Q_IGen.AI = PSM_SALES_AGENTS_5.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_6 ON PSM_Q_IGen.AE = PSM_SALES_AGENTS_6.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_7 ON PSM_Q_IGen.AP = PSM_SALES_AGENTS_7.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_8 ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS_8.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_9 ON PSM_Q_IGen.IPmgr = PSM_SALES_AGENTS_9.SA_ID) INNER JOIN PSM_Contacts AS PSM_Contacts_1 ON PSM_Q_IGen.CPmgr = PSM_Contacts_1.Contact_ID " +
                " WHERE (((PSM_Company.Cpny_Name1)='" + CpnyName.Replace("'", "''") + "') AND ((PSM_Q_IGen.Quote_ID)=" + Qid + ")) ORDER BY PSM_Q_IGen.Quote_ID, PSM_Q_IGen.CPNY_ID";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                //cbTerms.Enabled = false;
                tQuoteID.Text = Qid.ToString();
                lCurrIQID.Text = Oreadr["i_Quoteid"].ToString(); lQuoteID.Text = lCurrIQID.Text;
                tProjNAME.Text = Oreadr["ProjectName"].ToString();
                lQstatus.Text = Oreadr["del"].ToString();
                opCan.Checked = (Oreadr["curr"].ToString() == "C"); //("opCan_CheckedChanged");
                opUS.Checked = (Oreadr["curr"].ToString() == "U");
                opEuro.Checked = (Oreadr["curr"].ToString() == "E");
                USD_CAD_EURO();
                cbCompanyy.Text = CpnyName;
                lCpnyName.Text = CpnyName;
                btnCHNGCmpny.Visible = true;

                cbEmploy.Text = Oreadr["employ"].ToString();
                tOpendate.Text = Oreadr["Opndate"].ToString();
                lQDopen.Text = tOpendate.Value.ToShortDateString();
                tOpendate.Visible = false;
                lQDopen.Visible = true;

                cbContacts.Text = Oreadr["First_Name"].ToString() + " " + Oreadr["Last_Name"].ToString();
                lContacts.Text = Oreadr["First_Name"].ToString() + " " + Oreadr["Last_Name"].ToString();
                cbContacts.Visible = false;
                lContacts.Visible = true;
                btnchngCN.Visible = true;

                cbCPmgr.Text = Oreadr["CPM"].ToString();
                lcbCPmgr.Text = Oreadr["CPM"].ToString();
                lcbCPmgr.Visible = true;
                btnchngCP.Visible = true;
                cbCPmgr.Visible = false;

                cbIPmgr.Text = Oreadr["IPM"].ToString();
                cbActivities.Text = Oreadr["PrjActivty"].ToString();

                QReq.Text = (Oreadr["Quot_Req"].ToString().Length == 0) ? " " : Oreadr["Quot_Req"].ToString();

                if (QReq.Text[0] == '|')
                {
                    fill_dgFrom_QT();
                    QReq.Visible = false;
                }
                else
                {
                    QReq.Visible = true;
                    fill_dgCpnyQT_Vide();
                }
                chk_CCP.Checked = (Oreadr["CtoPrimax"].ToString() == "1");

                //Extrn sales

                //lcbS99.Text = Oreadr["SP_AG2_id"].ToString();
                //if (lcbS99.Text != MainMDI.VIDE) cbS99.Text = MainMDI.Find_One_Field_SYSPRO("SELECT distinct  [Name]   FROM [SysproCompanyP].[dbo].[v_PGSalesperson]   where Salesperson ='" + lcbS99.Text + "'");

                //

                //tCust_Mult.Text = Oreadr["Cust_Mult"].ToString();
                cbTerms.Text = Oreadr["Descr"].ToString();

                cbShipVia.Text = Oreadr["ShipEng"].ToString();
                cbIncoTerm.Text = Oreadr["IT_DESC"].ToString();

                //cbSi.Text = Oreadr["SI_nm"].ToString();
                int ndx_teri = Int32.Parse(Oreadr["SI"].ToString());
                cb_Territo.Text = MainMDI.Find_One_Field("select Terito_ABR from PSM_C_ComTERITORY where Terito_LID=" + ndx_teri);
                //hide on 25082009
                ////if (ndx_teri >= cb_Territo.Items.Count) //ndx_teri = 0;
                    ////cb_Territo.Text = MainMDI.Find_One_Field("select Terito_ABR from PSM_C_ComTERITORY where Terito_LID=" + ndx_teri);
                ////else cb_Territo.SelectedIndex = ndx_teri;
                //hide on 25082009
                //MessageBox.Show("/" + Oreadr["SI_nm"].ToString() + "/" + "    cb= " + cbSi.Text);
                cbSo.Text = Oreadr["SO_nm"].ToString();
                cbSe.Text = Oreadr["SE_nm"].ToString();
                cbSp.Text = Oreadr["SP_nm"].ToString();
                cbSS.Text = Oreadr["SS"].ToString();
                cbAI.Text = Oreadr["AI_nm"].ToString();
                cbAE.Text = Oreadr["AE_nm"].ToString();
                cbAP.Text = Oreadr["AP_nm"].ToString();
                cbADD.Text = Oreadr["AD_nm"].ToString();

                //syspro agents

                cbAG1.Text = Oreadr["SP_AG1"].ToString();
                lAG1CD.Text = Oreadr["SP_AG1_id"].ToString();
                cbAG2.Text = Oreadr["SP_AG2"].ToString();
                lAG1CD.Text = Oreadr["SP_AG2_id"].ToString();

                //syspro agents

                cbAS.Text = Oreadr["AS"].ToString();
                //if (Oreadr["AG_YN"].ToString() == "1") optAGOK.Checked = true;
                //else optNOAG.Checked = true;

                //new Agents use 20052015

                if (Oreadr["agency"].ToString() == "1")
                {
                    optAGOKII.Checked = true;
                    fill_Quot_agents();
                }
                else if ((Oreadr["agency"].ToString() == "0")) optNOAGII.Checked = true;
                else optUNDEF.Checked = true;
                //new Agents use 20052015

                switch (Oreadr["Lang"].ToString())
                {
                    case "I":
                        cbLang.Text = "Italian";
                        break;
                    case "F":
                        cbLang.Text = "French";
                        break;
                    case "E":
                        cbLang.Text = "English";
                        break;
                }
                //cbLang.Visible = false;
                //Lang.Text = cbLang.Text;
                //Lang.Visible = true;
                lQA.Text = Oreadr["QA"].ToString().Replace("\r\n", " ");
                lSA.Text = Oreadr["SA"].ToString().Replace("\r\n", " ");
                lPA.Text = Oreadr["PA"].ToString().Replace("\r\n", " ");
                lIA.Text = Oreadr["IA"].ToString().Replace("\r\n", " ");
                tGCmnt.Text = Oreadr["Cmnt"].ToString();
                lQsave.Text = "Y";

                if (Oreadr["endCustomer"].ToString() != "")
                {
                    endCustomer.Text = Oreadr["endCustomer"].ToString();
                    EAU.Text = Oreadr["EAU"].ToString();
                    cbstage.Text = Oreadr["stage"].ToString();
                    sucRate.Text = Oreadr["sucRate"].ToString();
                    projdd.Text = Oreadr["projecteddt"].ToString();
                    string stt = "select";
                    if (Oreadr["statQuote"].ToString() == "0") stt = "Won";
                    if (Oreadr["statQuote"].ToString() == "1") stt = "Lost";
                    cbstatQuote.Text = stt;
                    cbstatReason.Text = Oreadr["statReason"].ToString();
                }
                //lCurr_opera.Text = "E"; //E:edit N:add 
                return true;
            }
            MessageBox.Show("This Quote Does not Exist.. !!! ");
            return false;
        }

        private void fill_cbSal_AG(string SA)
        {
            string stAND = "";
            stAND = (lCurr_opera.Text == "N") ? " AND status=1 " : "";
            string stSql = "select First_Name, Last_Name FROM PSM_SALES_AGENTS where SA='" + SA + "' " + stAND + " AND status='1' order by First_Name"; //: "select First_Name, Last_Name FROM PSM_SALES_AGENTS where SA='" + SA + "'";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                if (SA == "S")
                {
                    stSql = Oreadr[0].ToString() + " " + Oreadr[1].ToString();
                    cbEmploy.Items.Add(stSql); //employee
                    cbIPmgr.Items.Add(stSql); //Project Mangr
                    cbSe.Items.Add(stSql);
                    cbSi.Items.Add(stSql);
                    cbSo.Items.Add(stSql);
                    cbSp.Items.Add(stSql);
                    cbSS.Items.Add(stSql);
                }
                else
                {
                    stSql = Oreadr[0].ToString(); //+ " " + Oreadr[1].ToString();
                    cbADD.Items.Add(stSql);
                    cbAE.Items.Add(stSql);
                    cbAP.Items.Add(stSql);
                    cbAI.Items.Add(stSql);
                    cbAS.Items.Add(stSql);
                }
            }
            OConn.Close();
        }

        private void fill_cb_AG_SYSPRO(int cbNo)
        {
            string brnch = MainMDI.Find_One_Field_SYSPRO("SELECT [Branch]  FROM [SysproCompanyP].[dbo].[v_PGCustomerXRef]  where Customer='" + Q_sysPcod.Text + "'");
            if (cbNo == 1) { cbAG1.Items.Clear(); cbAG1.Items.Add(MainMDI.VIDE); }
            if (cbNo == 2) { cbAG2.Items.Clear(); cbAG2.Items.Add(MainMDI.VIDE); }

            string stSql = "SELECT [Name] FROM [v_PGSalesperson]   where [Branch]='" + brnch + "' and substring([Salesperson],1,1)='A'  order by [Name]";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                if (cbNo == 1) cbAG1.Items.Add(Oreadr[0].ToString());
                if (cbNo == 2) cbAG2.Items.Add(Oreadr[0].ToString());
            }
            OConn.Close();
        }

        private void fill_cbCompany()
        {
            string stSql = "select Cpny_Name1 FROM PSM_Company order by Cpny_Name1";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            //int nb = 0;
            while (Oreadr.Read())
            {
                cbCompanyy.Items.Add(Oreadr["Cpny_Name1"].ToString());
                cbCQA.Items.Add(Oreadr["Cpny_Name1"].ToString());
                cbCSA.Items.Add(Oreadr["Cpny_Name1"].ToString());
                cbCIA.Items.Add(Oreadr["Cpny_Name1"].ToString());
                cbCPA.Items.Add(Oreadr["Cpny_Name1"].ToString());
                //nb++;
            }
            OConn.Close();
            //MessageBox.Show("NB company= " + nb.ToString());
        }

        private bool Import_ChPrices()
        {
            //string stout = "";
            string stsql = "SELECT TBLTOXL01.COMPONENT, TBLTOXL01.[5], TBLTOXL01.[10], TBLTOXL01.[15], TBLTOXL01.[20], TBLTOXL01.[25], TBLTOXL01.[30], TBLTOXL01.[35], TBLTOXL01.[40], TBLTOXL01.[50], TBLTOXL01.[60], TBLTOXL01.[70], TBLTOXL01.[75], TBLTOXL01.[80], TBLTOXL01.[100], TBLTOXL01.[125], TBLTOXL01.[150], TBLTOXL01.[175], TBLTOXL01.[200], TBLTOXL01.[225], TBLTOXL01.[250], TBLTOXL01.[275], TBLTOXL01.[300], TBLTOXL01.[325], TBLTOXL01.[350], TBLTOXL01.[375], TBLTOXL01.[400], TBLTOXL01.[500], TBLTOXL01.[600], TBLTOXL01.[750], TBLTOXL01.[800], TBLTOXL01.[900], TBLTOXL01.[1000], TBLTOXL01.REF_CHRG FROM TBLTOXL01 WHERE (TBLTOXL01.cRec)='T'";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            SqlCommandBuilder OBld = new SqlCommandBuilder();
            SqlDataAdapter OAdpXL = new SqlDataAdapter(stsql, OConn);
            SqlDataAdapter OAdpPrice = new SqlDataAdapter("select * from PSM_Charger_price", OConn);

            string tblNameXL = "TBLTOXL01";
            string tblNamePrice = "PSM_Charger_price";
            DataSet DsXL = new DataSet(tblNameXL);
            DataSet DsPrice = new DataSet(tblNamePrice);
            OAdpXL.Fill(DsXL, tblNameXL);
            OAdpPrice.Fill(DsPrice, tblNamePrice);

            SqlCommandBuilder OBuild = new SqlCommandBuilder(OAdpPrice);
            for (int i = 0; i < DsXL.Tables[0].Rows.Count; i++)
            {
                for (int j = 1; j < DsXL.Tables[0].Columns.Count - 1; j++)
                {
                    //MessageBox.Show("Charger_Name= " + DsXL.Tables[tblNameXL].Rows[i]["REF_CHRG"].ToString() + "  I=" + i + " Col= " + DsXL.Tables[tblNameXL].Columns[j].ColumnName);
                    DataRow lPrice = DsPrice.Tables[tblNamePrice].NewRow();
                    lPrice["Charger_Name"] = DsXL.Tables[tblNameXL].Rows[i]["REF_CHRG"].ToString();
                    lPrice["AMP"] = DsXL.Tables[tblNameXL].Columns[j].ColumnName;
                    lPrice["Price"] = DsXL.Tables[tblNameXL].Rows[i][j].ToString();
                    lPrice["DLV_Date"] = "4";
                    DsPrice.Tables[tblNamePrice].Rows.Add(lPrice);
                }
            }
            OAdpPrice.Update(DsPrice, tblNamePrice);
            OConn.Close();
            return true;
        }

        private bool del_Charger_Price()
        {
            //string stsql = "SELECT TBLTOXL01.COMPONENT, TBLTOXL01.[5], TBLTOXL01.[10], TBLTOXL01.[15], TBLTOXL01.[20], TBLTOXL01.[25], TBLTOXL01.[30], TBLTOXL01.[35], TBLTOXL01.[40], TBLTOXL01.[50], TBLTOXL01.[60], TBLTOXL01.[70], TBLTOXL01.[75], TBLTOXL01.[80], TBLTOXL01.[100], TBLTOXL01.[125], TBLTOXL01.[150], TBLTOXL01.[175], TBLTOXL01.[200], TBLTOXL01.[225], TBLTOXL01.[250], TBLTOXL01.[275], TBLTOXL01.[300], TBLTOXL01.[325], TBLTOXL01.[350], TBLTOXL01.[375], TBLTOXL01.[400], TBLTOXL01.[500], TBLTOXL01.[600], TBLTOXL01.[750], TBLTOXL01.[800], TBLTOXL01.[900], TBLTOXL01.[1000], TBLTOXL01.REF_CHRG FROM TBLTOXL01 WHERE (TBLTOXL01.cRec)='T'";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            SqlCommandBuilder OBld = new SqlCommandBuilder();
            //SqlDataAdapter OAdpXL = new SqlDataAdapter(stsql, OConn);
            SqlDataAdapter OAdpPrice = new SqlDataAdapter("delete PSM_Charger_price", OConn);
            string tblNamePrice = "PSM_Charger_price";
            DataSet DsPrice = new DataSet(tblNamePrice);
            OAdpPrice.Fill(DsPrice, tblNamePrice);
            SqlCommandBuilder OBuild = new SqlCommandBuilder(OAdpPrice);
            //debut delete
            OConn.Close();
            return (DsPrice.Tables.Count == 0);
        }

        private bool del_Charger_Price_Fast()
        {
            //string stsql = "SELECT TBLTOXL01.COMPONENT, TBLTOXL01.[5], TBLTOXL01.[10], TBLTOXL01.[15], TBLTOXL01.[20], TBLTOXL01.[25], TBLTOXL01.[30], TBLTOXL01.[35], TBLTOXL01.[40], TBLTOXL01.[50], TBLTOXL01.[60], TBLTOXL01.[70], TBLTOXL01.[75], TBLTOXL01.[80], TBLTOXL01.[100], TBLTOXL01.[125], TBLTOXL01.[150], TBLTOXL01.[175], TBLTOXL01.[200], TBLTOXL01.[225], TBLTOXL01.[250], TBLTOXL01.[275], TBLTOXL01.[300], TBLTOXL01.[325], TBLTOXL01.[350], TBLTOXL01.[375], TBLTOXL01.[400], TBLTOXL01.[500], TBLTOXL01.[600], TBLTOXL01.[750], TBLTOXL01.[800], TBLTOXL01.[900], TBLTOXL01.[1000], TBLTOXL01.REF_CHRG FROM TBLTOXL01 WHERE (TBLTOXL01.cRec)='T'";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = "delete PSM_Charger_price";
            Object CountRes = Ocmd.ExecuteScalar();
            OConn.Close();
            //MessageBox.Show("Deleted = " + CountRes.ToString());

            return true;
        }

        private void btnAQ_Click(object sender, System.EventArgs e)
        {

        }

        private void QuoteXAdrs(char c_adrs, string adrs)
        {
            //if ((adrs.IndexOf(", ") == 4)
            dlgAdrs dAdrs = new dlgAdrs(adrs);
            //dAdrs.chkSave.Visible = true;
            dAdrs.ShowDialog();
            if (dAdrs.tStreet.Text != "")
            {
                switch (c_adrs)
                {
                    case 'Q':
                        lQA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text + "," + dAdrs.tZip.Text + "," + dAdrs.cbCountry.Text;
                        break;
                    case 'S':
                        lSA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text + "," + dAdrs.tZip.Text + "," + dAdrs.cbCountry.Text;
                        break;
                    case 'I':
                        lIA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text + "," + dAdrs.tZip.Text + "," + dAdrs.cbCountry.Text;
                        break;
                    case 'P':
                        lPA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text + "," + dAdrs.tZip.Text + "," + dAdrs.cbCountry.Text;
                        break;
                }
            }
        }

        private void pictureBox1_Click(object sender, System.EventArgs e)
        {
            MessageBox.Show("Hiiiiiiiiiiiiiii");
        }

        private bool Entry_OK(ref int ALRM)
        {
            if (lSP_Name.Text[0] == 'I')
            {
                MessageBox.Show("ERROR:    Outside Sales is INVALID........ "); ALRM = 1;
                return false;
            }
            if (picALRM_mltp.Visible || picOutSales.Visible || picSPcode.Visible || alrm_SPcurrncy.Visible)
            {
                MessageBox.Show("Cannot save this quote since some Alarms are RED !!!!!!   "); ALRM = 1;
                return false;
            }
            return (tQuoteID.Text != "" && lEmp_ID.Text != "" && lEmp_ID.Text != "0" && lContact_ID.Text != "" && lContact_ID.Text != "0" && lLang.Text != "" && lcpnyID.Text != "" && lcpnyID.Text != "0");
        }

        private bool Valid_Curr()
        {
            bool res = true;

            if (Tools.Conv_Dbl(tQuoteID.Text) > 15995)
            {
                if (Q_sysPcod.Text.Length < 3) res = false;
                switch (Q_sysPcod.Text[Q_sysPcod.Text.Length - 1])
                {
                    case 'U':
                        res = (lcurDol.Text == "USD");
                        break;
                    case 'E':
                        res = (lcurDol.Text == "EUR");
                        break;
                    case 'C':
                        res = (lcurDol.Text == "CAD");
                        break;
                }
            }
            return res;
        }

        private bool Save_Q_Adrs_Cmnt(long i_QID)
        {
            if (lQA.Text != "" || lIA.Text != "" || lPA.Text != "" || lSA.Text != "" || tGCmnt.Text != "")
            {
                string stSql = "INSERT INTO PSM_Q_ADRS_Cmnt ([I_Quoteid],[Q_Adrs], " +
                    " [P_Adrs],[S_Adrs],[I_Adrs], " +
                    " [Cmnt]) VALUES ('" +
                    i_QID.ToString() + "', '" +
                    lQA.Text.Replace("'", "''") + "', '" +
                    lPA.Text.Replace("'", "''") + "', '" +
                    lSA.Text.Replace("'", "''") + "', '" +
                    lIA.Text.Replace("'", "''") + "', '" +
                    tGCmnt.Text.Replace("'", "''") + "')";
                MainMDI.ExecSql(stSql);
                MainMDI.Write_JFS(stSql);
                //Save_Q_Adrs_Cmnt();
            }
            else
            {
                MessageBox.Show("You missed some Fields....");
                return false;
            }
            return true;
        }

        private bool Save_Q_AG_SYSPRO(long i_QID)
        {
            if (cbAG1.Text != "")
            {
                string stSql = "INSERT INTO PSM_Q_AGsyspro ([Qid],[AG1name], " +
                    " [AG1CD],[AG2name],[AG2CD]) VALUES (" +
                    i_QID.ToString() + ", '" +
                    cbAG1.Text.Replace("'", "''") + "', '" +
                    lPA.Text.Replace("'", "''") + "', '" +
                    lSA.Text.Replace("'", "''") + "', '" +
                    lIA.Text.Replace("'", "''") + "', '" +
                    tGCmnt.Text.Replace("'", "''") + "')";
                MainMDI.ExecSql(stSql);
                MainMDI.Write_JFS(stSql);
            }
            else
            {
                MessageBox.Show("You missed Agents....");
                return false;
            }
            return true;
        }

        private int fill_QID()
        {
            lock_table('Q');
            //long Qid = MainMDI.Gen_ID_tmpQ('Q');
            long Qid = MainMDI.Gen_IDFinal('Q');
            tQuoteID.Text = "";
            switch (Qid)
            {
                case 0:
                    //MessageBox.Show("Table GEN_ID is Full....");
                    MessageBox.Show("Quotes IDs must be added, please contact your Administrator ....");
                    break;
                case -1:
                    //MessageBox.Show("Table GEN_ID is Empty Must be Initialized....");
                    MessageBox.Show("No available Quote#, GEN_IDs is empty , please contact your Administrator....");
                    break;
                default:
                    tQuoteID.Text = Qid.ToString();
                    MainMDI.flag_QRID('Q', 'u', 1, Qid);
                    break;
            }
            Unlock_table("PSM_Q_GenID");
            return Convert.ToInt32(Qid);
        }

        private void button3_Click(object sender, System.EventArgs e)
        {

        }

        private void Save_Q_ALL_Details()
        {
            //if (lvQITEMS.Items[0].SubItems[1].Text == "1")
            //{
                this.Cursor = Cursors.WaitCursor;
                if (lCurrIQID.Text != "0")
                {
                    long SID = Save_SOL(lCurrIQID.Text, lCurSoln.Text, lCurSolNDX.Text, tvSol.Nodes[Convert.ToInt32(lCurSolNDX.Text)].ImageIndex.ToString());
                    if (SID != 0)
                    {
                        long SPCID = Save_SPEC(SID, lCurSPCn.Text, lCurSPCNDX.Text);
                        if (SPCID != 0)
                        {
                            ref_PXAG_Price('V');
                            long ALSID = Save_ALS(SPCID, lCurALSn.Text, lCurALSNDX.Text, AlsTOT_orig.Text, tPxPrice.Text, tAGprice.Text, tALSnb.Text);
                            lcurrALSLID.Text = ALSID.ToString();
                            if (ALSID != 0)
                            {
                                //for (int i = 0; i < MainMDI.MAX_ALS_Lines; i++)
                                MainMDI.ExecSql("delete PSM_Q_Details WHERE PSM_Q_Details.ALS_LID=" + ALSID);
                                for (int i = 0; i < lvQITEMS.Items.Count; i++)
                                {
                                    if (lvQITEMS.Items[i].SubItems[1].Text != "")
                                    {
                                        if (!Save_Details(ALSID, i))
                                        {
                                            MessageBox.Show("Error Occurs while Saving current Details......contact your Admin !!!" + MainMDI.stXP);
                                            break;
                                        }
                                        if (Tosave) Tosave = false;
                                    }
                                    else break;
                                }
                            }
                        }
                    }
                }
                this.Cursor = Cursors.Default;
            //}
            //else MessageBox.Show("Error:  First Item # must be: 1  not: " + lvQITEMS.Items[0].SubItems[1].Text);
        }

        //alter. Total based on first ALS Total

        private string SPEC_TOT_TOT1(string r_IQID, string Sname, string SpecName)
        {
            string stSql = "SELECT Sum(PSM_Q_ALS.Tot) AS SommeDeTot FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " GROUP BY PSM_Q_SOL.I_Quoteid, PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name HAVING (((PSM_Q_SOL.I_Quoteid)=" + r_IQID + ") AND ((PSM_Q_SOL.Sol_Name)='" + Sname + "') AND ((PSM_Q_SPCS.SPC_Name)='" + SpecName.Replace("'", "''") + "'))";
            string res = MainMDI.Find_One_Field(stSql);
            if (res == MainMDI.VIDE) return "0";
            return Convert.ToString(Math.Round(Tools.Conv_Dbl(res), MainMDI.Q_NB_DEC_AFF));
        }

        //alter. Total based on AgentPrice ALS Total

        /*		
        private string SPEC_TOT(string r_IQID, string Sname, string SpecName)
        {
            string stSql = "SELECT Sum(PSM_Q_ALS.AGPrice) AS SommeDeTot FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " GROUP BY PSM_Q_SOL.I_Quoteid, PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name HAVING (((PSM_Q_SOL.I_Quoteid)=" + r_IQID + ") AND ((PSM_Q_SOL.Sol_Name)='" + Sname + "') AND ((PSM_Q_SPCS.SPC_Name)='" + SpecName.Replace("'", "''") + "'))";
            string res = MainMDI.Find_One_Field(stSql);
            if (res == MainMDI.VIDE) return "0";
            return Convert.ToString(Math.Round(Tools.Conv_Dbl(res), MainMDI.Q_NB_DEC_AFF));
        }
        */

        private long Save_SOL(string iQid, string s_name, string Rnk, string img)
        {
            //string stSql = MainMDI.Find_One_Field("select Sol_LID from PSM_Q_SOL where I_Quoteid=" + iQid + " AND Sol_Name='" + s_name + "' and Rnk=" + Rnk);
            string stSql = MainMDI.Find_One_Field("select Sol_LID from PSM_Q_SOL where I_Quoteid=" + iQid + " AND Sol_Name='" + s_name + "'");
            if (stSql != MainMDI.VIDE) return Convert.ToInt32(stSql);
            else
            {
                stSql = "INSERT INTO PSM_Q_SOL ([I_Quoteid],[Sol_Name],[img], [Rnk]," +
                    " [user],[date_Rev] ) VALUES ('" +
                    iQid.ToString() + "', '" +
                    s_name + "', '" +
                    img + "', '" + Rnk + "', '" + MainMDI.User + "', " + MainMDI.SSV_date(System.DateTime.Now.ToShortDateString()) + ")";
                MainMDI.ExecSql(stSql);
                MainMDI.Write_JFS(stSql);
                stSql = MainMDI.Find_One_Field("select Sol_LID from PSM_Q_SOL where I_Quoteid=" + iQid + " AND Sol_Name='" + s_name + "' and Rnk=" + Rnk);
                if (stSql != MainMDI.VIDE) return Convert.ToInt32(stSql);
                else MessageBox.Show("Error Occurs while Saving current Solution...contact your Admin !!!" + MainMDI.stXP);
                return 0;
            }
        }

        private long Save_SPEC(long SID, string spc_name, string Rnk) //, out string msg)
        {
            string stSql = "";
            //string stSql = MainMDI.Find_One_Field("select SPC_LID from PSM_Q_SPCS where Sol_LID=" + SID.ToString() + " AND SPC_Name='" + spc_name + "' and Rnk=" + Rnk);
            if (spc_name == MainMDI.VIDE) stSql = MainMDI.Find_One_Field("select SPC_LID from PSM_Q_SPCS where Sol_LID=" + SID.ToString() + " AND SPC_Name='" + spc_name + "' and Rnk=" + Rnk);
            else stSql = MainMDI.Find_One_Field("select SPC_LID from PSM_Q_SPCS where Sol_LID=" + SID.ToString() + " AND SPC_Name='" + spc_name.Replace("'", "''") + "'");
            if (stSql != MainMDI.VIDE)
            {
                return Convert.ToInt32(stSql);
            }
            else
            {
                stSql = "INSERT INTO PSM_Q_SPCS ([Sol_LID],[SPC_Name], " +
                    " [Rnk] ) VALUES ('" +
                    SID.ToString() + "', '" +
                    spc_name.Replace("'", "''") + "', '" +
                    Rnk + "')";
                MainMDI.ExecSql(stSql);
                MainMDI.Write_JFS(stSql);
                stSql = MainMDI.Find_One_Field("select SPC_LID from PSM_Q_SPCS where Sol_LID=" + SID.ToString() + " AND SPC_Name='" + spc_name.Replace("'", "''") + "' and Rnk=" + Rnk);
                if (stSql != MainMDI.VIDE) return Convert.ToInt32(stSql);
                else MessageBox.Show("Error Occurs while Saving current SPEC...contact your Admin !!!" + MainMDI.stXP);
                return 0;
            }
        }

        private void ref_PXAG_Price(char opera)
        {
            if (opera != 'S') //selection
            {
                bool _conf = false;
                if (Tools.Conv_Dbl(AlsTOT.Text) > Tools.Conv_Dbl(AlsTOT_orig.Text))
                {
                    if (chk_savOVRG.Checked) _conf = false;
                    //else _conf = MainMDI.Confirm("Want to Update Primax Sell Price / Agent Price: ?");
                    //!MainMDI.Confirm("Selling Price is higher than PGESCOM Price , do you want to Save current Selling Price / Agent Price: ?");
                    //removed: 25/11/2008 else _conf = !MainMDI.Confirm("Selling Price is higher than PGESCOM Price , do you want to IMPOSE the NEW Price on all others Prices: ?");
                    else _conf = true;
                }
                else _conf = (Tools.Conv_Dbl(AlsTOT.Text) < Tools.Conv_Dbl(AlsTOT_orig.Text));
                if (_conf)
                {
                    AlsTOT.Text = MainMDI.A00(AlsTOT_orig.Text);
                    tAGprice.Text = MainMDI.A00(tPxPrice.Text);
                }
                if (Tools.Conv_Dbl(tAGprice.Text) < Tools.Conv_Dbl(tPxPrice.Text)) tAGprice.Text = MainMDI.A00(tPxPrice.Text);
            }
        }

        private void ref_PXAG_PriceokOLD(char opera)
        {
            //if (Tools.Conv_Dbl(tAGprice.Text) == 0) ???? 
            if (Tools.Conv_Dbl(AlsTOT.Text) < Tools.Conv_Dbl(AlsTOT_orig.Text))
            {
                AlsTOT.Text = MainMDI.A00(AlsTOT_orig.Text);
                tAGprice.Text = MainMDI.A00(tPxPrice.Text);
            }
            if (Tools.Conv_Dbl(tAGprice.Text) < Tools.Conv_Dbl(tPxPrice.Text)) tAGprice.Text = MainMDI.A00(tPxPrice.Text);
            if (OldAlsTot.Text != AlsTOT_orig.Text && OldAlsTot.Text != "")
            {
                AlsTOT.Text = MainMDI.A00(AlsTOT_orig.Text);
                tAGprice.Text = MainMDI.A00(tPxPrice.Text);
                OldAlsTot.Text = AlsTOT_orig.Text;
            }
            if (Tools.Conv_Dbl(AlsTOT.Text) != Tools.Conv_Dbl(AlsTOT_orig.Text) || Tools.Conv_Dbl(tAGprice.Text) != Tools.Conv_Dbl(tPxPrice.Text))
            {
                //# if (toolBar1.Buttons[16].Pushed)
                if (toolBar1.Items[16].Pressed) //.Checked)
                {
                    if (MainMDI.Confirm("Want to Update Primax Sell Price / Agent Price: ?"))
                    {
                        AlsTOT.Text = MainMDI.A00(AlsTOT_orig.Text);
                        tAGprice.Text = MainMDI.A00(tPxPrice.Text);
                    }
                }
            }
        }

        private void ref_PXAG_Priceooold()
        {
            if (Tools.Conv_Dbl(tPxPrice.Text) < Tools.Conv_Dbl(AlsTOT.Text))
            {
                tPxPrice.Text = MainMDI.A00(AlsTOT.Text);
                tAGprice.Text = MainMDI.A00(tPxPrice.Text);
            }
            if (Tools.Conv_Dbl(tAGprice.Text) < Tools.Conv_Dbl(tPxPrice.Text)) tAGprice.Text = MainMDI.A00(tPxPrice.Text);
            //tPxPrice.Text = MainMDI.A00(tPxPrice.Text);
            //tAGprice.Text = MainMDI.A00(tAGprice.Text);
            if (OldAlsTot.Text != AlsTOT.Text && OldAlsTot.Text != "")
            {
                tPxPrice.Text = MainMDI.A00(AlsTOT.Text);
                tAGprice.Text = MainMDI.A00(tPxPrice.Text);
            }
        }

        private long Save_ALS(long SPCID, string als_Name, string Rnk, string Tot, string PXPrice, string AGPrice, string r_qty)
        {
            //string stSql = MainMDI.Find_One_Field("select ALS_LID from PSM_Q_ALS where SPC_LID=" + SPCID.ToString() + " AND ALS_Name='" + als_Name + "' and Rnk=" + Rnk);

            //ref_PXAG_Price();
            int _ovrg = (chk_savOVRG.Checked) ? 1 : 0;
            string stSql = MainMDI.Find_One_Field("select ALS_LID from PSM_Q_ALS where SPC_LID=" + SPCID.ToString() + " AND ALS_Name='" + als_Name.Replace("'", "''") + "' ");
            if (stSql != MainMDI.VIDE)
            {
                string stt = "UPDATE PSM_Q_ALS SET  [Tot]=" + Tools.Conv_Dbl(Tot) + ", [PxPrice]=" + Tools.Conv_Dbl(PXPrice) + ", [AGPrice]=" + Tools.Conv_Dbl(AGPrice) + ", [AlsQty]=" + Tools.Conv_Dbl(r_qty) + ", [SV_Ovrg]=" + _ovrg.ToString() + " where ALS_LID=" + stSql;
                MainMDI.ExecSql(stt);
                MainMDI.Write_JFS(stt);
                return Convert.ToInt32(stSql);
            }
            else
            {
                string myals = (als_Name.Length > 0) ? als_Name.Replace("'", "''") : "Toto";

                stSql = "INSERT INTO PSM_Q_ALS ([SPC_LID],[ALS_Name],[Tot], " +
                    "[PxPrice],[AGPrice],[AlsQty], [SV_Ovrg], [Rnk] ) VALUES (" +
                    SPCID.ToString() + ", '" +
                    myals + "', " +
                    Tools.Conv_Dbl(Tot) + ", " + Tools.Conv_Dbl(PXPrice) +
                    ", " + Tools.Conv_Dbl(AGPrice) +
                    ", " + Tools.Conv_Dbl(r_qty) +
                    ", " + _ovrg.ToString() +
                    ", '" + Rnk + "')";
                MainMDI.ExecSql(stSql);
                MainMDI.Write_JFS("Save_ALS:  " + stSql);
                stSql = MainMDI.Find_One_Field("select ALS_LID from PSM_Q_ALS where SPC_LID=" + SPCID.ToString() + " AND ALS_Name='" + als_Name.Replace("'", "''") + "' and Rnk=" + Rnk);
                if (stSql != MainMDI.VIDE) return Convert.ToInt32(stSql);
                else MessageBox.Show("Error Occurs while Saving current System...contact your Admin !!!" + MainMDI.stXP);
                return 0;
            }
        }

        private bool Save_Details_Arr(long ALSID, long i)
        {
            //int LA = (curr_ALS[i, 6] == "") ? 0 : Convert.ToInt32(curr_ALS[i, 6]);
            //string stSql = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " + 
                //" [Desc],[Qty],[Mult], [Uprice],[LeadTime],[Rnk] ) VALUES ('" +
                //ALSID + "', '" +
                //curr_ALS[i, 0] + "', '" +
                //curr_ALS[i, 1] + "', '" +
                //Tools.Conv_Dbl(curr_ALS[i, 2]) + "', '" +
                //Tools.Conv_Dbl(curr_ALS[i, 3]) + "', '" +
                //Tools.Conv_Dbl(curr_ALS[i, 4]) + "', '" + //lokij
                //LA.ToString() + "', '" +
                //i.ToString() + "')";
            //return MainMDI.ExecSql(stSql);
            return true;
        }

        private bool Save_Details(long ALSID, int i)
        {
            int _ItmGrp = CB_Group.FindStringExact(lvQITEMS.Items[i].SubItems[6].Text) + 1;
            if (_ItmGrp == -1) _ItmGrp = 1; //group A by default if error
            //!!! 
            //double ddUP = (lvQITEMS.Items[i].SubItems[5].Text.Length < 2) ? 0 : Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[5].Text.Substring(1, lvQITEMS.Items[i].SubItems[5].Text.Length - 1));
            double ddUP = (lvQITEMS.Items[i].SubItems[5].Text == "") ? 0 : Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[5].Text);
            //int LA = (lvQITEMS.Items[i].SubItems[8].Text == "") ? 0 : Convert.ToInt32(lvQITEMS.Items[i].SubItems[8].Text);
            string st_DESC = (lvQITEMS.Items[i].SubItems[2].Text.Length > 0) ? lvQITEMS.Items[i].SubItems[2].Text.Replace("'", "''") : "   ";
            string affid = (i == 0) ? "1" : lvQITEMS.Items[i].SubItems[1].Text;

            string stSql = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " +
                " [Desc],[Qty],[Xch_Mult],[Uprice], [Mult],[Ext],[LeadTime],[Rnk],[PN] ,[Q_tec_Val]) VALUES ('" +
                ALSID + "', '" +
                affid + "', '" +
                st_DESC + "', '" +
                Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[3].Text) + "', '" +
                _ItmGrp.ToString() + "', '" + //Xch_Mult saves item_group 
                ddUP.ToString() + "', '" +
                Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[4].Text) + "', '" +
                Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[7].Text) + "', '" +
                //LA.ToString() + "', '" +
                lvQITEMS.Items[i].SubItems[8].Text + "', '" +
                i.ToString() + "', '" +
                lvQITEMS.Items[i].SubItems[10].Text + "', '" +
                //"" + "')";
            lvQITEMS.Items[i].SubItems[12].Text + "')";
            MainMDI.Write_JFS(stSql);
            return MainMDI.ExecSql(stSql);
        }

        /*
        private bool Save_Detailsold(long ALSID, int i)
        {
            //!!! 
            //double ddUP = (lvQITEMS.Items[i].SubItems[5].Text.Length < 2) ? 0 : Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[5].Text.Substring(1, lvQITEMS.Items[i].SubItems[5].Text.Length - 1));
            double ddUP = (lvQITEMS.Items[i].SubItems[5].Text == "") ? 0 : Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[5].Text);
            //int LA = (lvQITEMS.Items[i].SubItems[8].Text == "") ? 0 : Convert.ToInt32(lvQITEMS.Items[i].SubItems[8].Text);
            string stSql= "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " + 
                " [Desc],[Qty],[Xch_Mult],[Uprice], [Mult],[Ext],[LeadTime],[Rnk],[PN] ) VALUES ('" +
                ALSID + "', '" +
                lvQITEMS.Items[i].SubItems[1].Text + "', '" +
                lvQITEMS.Items[i].SubItems[2].Text.Replace("'", "''") + "', '" +
                Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[3].Text) + "', '" +
                Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[6].Text) + "', '" +
                ddUP.ToString() + "', '" +
                Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[4].Text) + "', '" +
                Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[7].Text) + "', '" +
                //LA.ToString() + "', '" +
                lvQITEMS.Items[i].SubItems[8].Text + "', '" +
                i.ToString() + "', '" +
                lvQITEMS.Items[i].SubItems[10].Text + "')";
            MainMDI.Write_JFS(stSql);
            return MainMDI.ExecSql(stSql);
        }
        */

        /*
        private void Add_optionold()
        {
            Options frmOpt = new Options('A', "*");
            //frmOpt.optFR.Checked = (MainMDI.Lang == 1);
            //frmOpt.optEng.Checked = (MainMDI.Lang == 0);
            this.Hide();
            frmOpt.ShowDialog();
            this.Visible = true;

            if (frmOpt.lConsopt.Text == "Y")
            {
                ItemCount++;
                string stt = (MainMDI.Lang == 0) ? frmOpt.tERef.Text : frmOpt.tFRef.Text;
                string prtNB = (frmOpt.tPx.Text != "") ? frmOpt.tPx.Text + "~~" + frmOpt.tManifac.Text : " " + "~~" + frmOpt.tManifac.Text;
                //add_LVO(1, 0, ItemCount.ToString(), frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)), frmOpt.tDlvDelay.Text, frmOpt.tPx.Text);
                add_LVO(1, 0, ItemCount.ToString(), stt + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)), frmOpt.tDlvDelay.Text, prtNB);

                Opt_added = true;
                Ref_ALSTOT();
            }
            frmOpt.Dispose();
        }
        */

        private void Add_option()
        {
            Options frmOpt = new Options('A', "*", 'N');
            this.Hide();
            frmOpt.ShowDialog();
            this.Visible = true;

            if (frmOpt.lConsopt.Text == "Y")
            {
                ItemCount++;
                string stt = (MainMDI.Lang == 0 || MainMDI.Lang == 2) ? frmOpt.tERef.Text : frmOpt.tFRef.Text;

                //added 23/10/2012 Haissam req.

                stt = "";
                //added 23/10/2012 Haissam req.

                string prtNB = (frmOpt.tPx.Text != "") ? frmOpt.tPx.Text + "~~" + frmOpt.tManifac.Text : " " + "~~" + frmOpt.tManifac.Text;
                //stt = (frmOpt.lFullDesc.Text.ToUpper().IndexOf(stt.ToUpper()) == -1) ? "" : stt + " ";
                add_LVO(1, 0, ItemCount.ToString(), stt + "  " + frmOpt.lFullDesc.Text + " [" + frmOpt.tPX_code.Text + "]", frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)), frmOpt.tDlvDelay.Text, prtNB, "C_TCC||A", "A");
                //add_LVO(1, 0, ItemCount.ToString(), frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)), frmOpt.tDlvDelay.Text, prtNB, "");
                Opt_added = true;
                Ref_ALSTOT('A');
            }
            else
            {
                if (frmOpt.lConsopt.Text == "L")
                {
                    for (int i = 0; i < frmOpt.lvCadi.Items.Count; i++)
                    {
                        ItemCount++;
                        add_LVO(1, 0, ItemCount.ToString(), frmOpt.lvCadi.Items[i].SubItems[0].Text, frmOpt.lvCadi.Items[i].SubItems[1].Text, tCust_Mult.Text, frmOpt.lvCadi.Items[i].SubItems[2].Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.lvCadi.Items[i].SubItems[2].Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)), frmOpt.lvCadi.Items[i].SubItems[4].Text, frmOpt.lvCadi.Items[i].SubItems[3].Text, "C_TCC||A", "A");
                        Opt_added = true;
                    }
                    Ref_ALSTOT('A');
                }
                else if (frmOpt.lConsopt.Text == "B")
                {
                    ItemCount++;
                    add_LVO(1, 0, ItemCount.ToString(), frmOpt.batt_ref.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)), frmOpt.tDlvDelay.Text, " ", "C_TCC||A", "B"); //"1", "1", "9999999", "999999", frmOpt.tDlvDelay.Text, frmOpt.lvCadi.Items[i].SubItems[3].Text, "C_TCC||A", "A");
                    add_LVO(1, 1, "", frmOpt.batt_d4.Text, "", "", "", "", "", "", "", "B"); //"1", "1", "9999999", "999999", frmOpt.tDlvDelay.Text, frmOpt.lvCadi.Items[i].SubItems[3].Text, "C_TCC||A", "A");
                    add_LVO(1, 1, "", frmOpt.batt_d5.Text, "", "", "", "", "", "", "", "B"); //"1", "1", "9999999", "999999", frmOpt.tDlvDelay.Text, frmOpt.lvCadi.Items[i].SubItems[3].Text, "C_TCC||A", "A");
                    add_LVO(1, 1, "", frmOpt.batt_d6.Text, "", "", "", "", "", "", "", "B"); //"1", "1", "9999999", "999999", frmOpt.tDlvDelay.Text, frmOpt.lvCadi.Items[i].SubItems[3].Text, "C_TCC||A", "A");

                    Opt_added = true;

                    Ref_ALSTOT('A');
                }
            }
            frmOpt.Dispose();
        }

        /*
        private void Add_optionoldz()
        {
            Options frmOpt = new Options('A', "*");
            this.Hide();
            frmOpt.ShowDialog();
            this.Visible = true;

            if (frmOpt.lConsopt.Text == "Y")
            {
                //OptionCount++;
                //old add_LVO(3, ".", frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), Charger.NB_DEC_AFF)), frmOpt.tDlvDelay.Text, frmOpt.tPx.Text);
                ItemCount++;
                add_LVO(1, 0, ItemCount.ToString(), frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)), frmOpt.tDlvDelay.Text, frmOpt.tPx.Text);

                //else add_LVO(3, ".", frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), Charger.NB_DEC_AFF)), frmOpt.tDlvDelay.Text);
                Opt_added = true;
                Ref_ALSTOT();
            }
            frmOpt.Dispose();
        }
	
        private void Add_optionNew()
        {
            //string stDesc = "";	
            Options frmOpt = new Options('A', "*");
            frmOpt.ShowDialog();

            if (frmOpt.lConsopt.Text == "Y")
            {
                //for (int i = 0; i < frmOpt.lv
                if (frmOpt.btnOK.Text == "Update")
                { 
                    if (!Opt_added) add_LVO(2, ".", MainMDI.arr_EFSdict[21, MainMDI.Lang] + "=  ", "", "", "", "", "");
                    OptionCount++;
                    add_LVO(3, ".", frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), Charger.NB_DEC_AFF)), frmOpt.tDlvDelay.Text);
                    //else add_LVO(3, ".", frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), Charger.NB_DEC_AFF)), frmOpt.tDlvDelay.Text);
                    Opt_added = true;
                }
                else 
                {
                    for (int i = 0; i < frmOpt.lvOptPricelst.SelectedItems.Count; i++)
                    {
                        if (!Opt_added) add_LVO(2, ".", MainMDI.arr_EFSdict[21, MainMDI.Lang] + "=  ", "", "", "", "", "");
                        OptionCount++;
                        //add_LVO(3, ".", frmOpt.tERef.Text + "  " + stDesc, frmOpt.lvOptPricelst.SelectedItems[i].SubItems[2], tCust_Mult.Text,frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), Charger.NB_DEC_AFF)), frmOpt.tDlvDelay.Text);
                        //else add_LVO(3, ".", frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), Charger.NB_DEC_AFF)), frmOpt.tDlvDelay.Text);
                        Opt_added = true;
                    }
                }
                Ref_ALSTOT();
            }
        }
        */

        private void Add_optionoldnew()
        {
            Options frmOpt = new Options('A', "*", 'N');
            frmOpt.ShowDialog();

            if (frmOpt.lConsopt.Text == "Y")
            {
                ListViewItem lvI = lvQITEMS.Items.Add("");
                lvI.BackColor = Color.LightYellow;
                OptionCount++;
                lvI.SubItems.Add(ItemCount + "." + OptionCount.ToString());
                lvI.SubItems.Add("Option / " + frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text);
                lvI.SubItems.Add(frmOpt.tOptqty.Text);
                lvI.SubItems.Add(tCust_Mult.Text);
                lvI.SubItems.Add(frmOpt.tUPrice.Text);
                lvI.SubItems.Add(Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)));
                lvI.SubItems.Add(frmOpt.tDlvDelay.Text);
                Ref_ALSTOT('A');
            }
        }

        private void Add_BATT()
        {
            dlg_addBatt mydlg = new dlg_addBatt();
            mydlg.ShowDialog();
            if (mydlg.Save)
            {
                ItemCount++;
                string st = Batt_arrTOstr(mydlg.in_arrBatt);
                st = (st == "") ? MainMDI.VIDE : st;
                add_LVO(1, 0, ItemCount.ToString(), mydlg.in_arrBatt[0, 0] + "  " + mydlg.in_arrBatt[0, 1], "1", "1", mydlg.in_arrBatt[MainMDI.batt_nbL - 1, 1], mydlg.in_arrBatt[MainMDI.batt_nbL - 1, 1], " ", " ", st, "C"); //name, price
                for (int j = 1; j < MainMDI.batt_nbL-1; j++)
                {
                    if (mydlg.in_arrBatt[j, 1] != " " && mydlg.in_arrBatt[j, 1] != "") add_LVO(1, 1, "", mydlg.in_arrBatt[j, 0] + "  " + mydlg.in_arrBatt[j, 1], "", "", "", "", "", "", "", "C");
                }
                Tosave = true;
            }
        }

        string Batt_arrTOstr(string[,] arr)
        {
            string rez = "";
            for (int i = 0; i < MainMDI.batt_nbL; i++)
            {
                string rr = (arr[i, 1] == " ") ? MainMDI.VIDE : arr[i, 1];
                rez += i.ToString() + "||" + rr + "~~";
            }
            return rez;
        }

        string Batt_strTOarr(ref string[,] arr, string str)
        {
            string rez = "";
            for (int i = 0; i < MainMDI.batt_nbL; i++)
            {
                string rr = (arr[i, 1] == " ") ? MainMDI.VIDE : arr[i, 1];
                rez = i.ToString() + "||" + rr + " ";
            }
            return rez;
        }

        private void Add_CBR(char cbr)
        {
            string nbCell = "", stIn = "";
            if (lvQITEMS.SelectedItems.Count == 1)
            {
                if (lvQITEMS.SelectedItems[0].SubItems[2].Text.Substring(0, 5) == "Cell#")
                    nbCell = lvQITEMS.SelectedItems[0].SubItems[2].Text.Substring(8, lvQITEMS.SelectedItems[0].SubItems[2].Text.Length - 8);
            }
            PbsInfo pbsI = new PbsInfo(cbr, nbCell);
            pbsI.ShowDialog();
            if (pbsI.SaveOK)
            {
                Tosave = true;
                switch (cbr)
                {
                    case 'C':
                    case 'c':
                        ItemCount++;
                        add_LVO(1, 0, ItemCount.ToString(), "Cabinet " + pbsI.tcModel.Text, pbsI.tcQtyCab.Text, tCust_Mult.Text, pbsI.tcPrice.Text, pbsI.tcextCab.Text, pbsI.tcLT.Text, pbsI.tcModel.Text, "C_TCC||A", "A");
                        div_Dim(pbsI.tcDim.Text, ref stIn);
                        add_LVO(1, 1, "", "Dimensions: " + stIn, "", "", "", "", "", "", "", "A");
                        //add_LVO(1, "", "                   " + stMm, "", "", "", "", "");
                        add_LVO(1, 1, "", "Color: " + pbsI.tccolor.Text, "", "", "", "", "", "", "", "A");
                        if (pbsI.lcetat.Text == "S")
                        {
                            if (pbsI.tc1Tstep.Text != "0") add_LVO(1, 1, "", "First Tier: " + pbsI.tc1Tstep.Text + " step(s)", pbsI.tc1Tstep.Text, tCust_Mult.Text, pbsI.tcstpUP.Text, pbsI.tc1TPrice.Text, pbsI.tcLT.Text, "", "", "A");
                            if (pbsI.tc2Tstep.Text != "0") add_LVO(1, 1, "", "Second Tier: " + pbsI.tc2Tstep.Text + " step(s)", pbsI.tc2Tstep.Text, tCust_Mult.Text, pbsI.tcstpUP.Text, pbsI.tc2TPrice.Text, pbsI.tcLT.Text, "", "", "A");
                        }
                        else { if (pbsI.tc1Tstep.Text != "0") add_LVO(1, 1, "", "Tiers # : " + pbsI.tc1Tstep.Text, pbsI.tc1Tstep.Text, tCust_Mult.Text, pbsI.tcstpUP.Text, pbsI.tc1TPrice.Text, pbsI.tcLT.Text, "", "", "A"); }
                        if (pbsI.chkprint.Checked) add_LVO(1, 1, "", "Cell# :" + pbsI.tcNBCell.Text, "", "", "", "", "", "", "", "A");
                        if (pbsI.tcITExt.Text != "0") add_LVO(1, 1, "", "Inter Tiers ", pbsI.tcITQty.Text, tCust_Mult.Text, pbsI.tcITup.Text, pbsI.tcITExt.Text, "", "", "", "A");
                        if (pbsI.tcBTBExt.Text != "0") add_LVO(1, 1, "", "Battery Terminal Block ", pbsI.tcBTBQty.Text, tCust_Mult.Text, pbsI.tcBTBup.Text, pbsI.tcBTBExt.Text, "", "", "", "A");
                        break;
                    case 'B':
                    case 'b':
                        ItemCount++;
                        double UP = Math.Round(Tools.Conv_Dbl(pbsI.tbExt.Text) / Tools.Conv_Dbl(pbsI.tsysnb.Text), MainMDI.NB_DEC_AFF);
                        double NExt = Math.Round(UP * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.NB_DEC_AFF);
                        add_LVO(1, 0, ItemCount.ToString(), pbsI.tbType.Text, pbsI.tsysnb.Text, tCust_Mult.Text, UP.ToString(), NExt.ToString(), pbsI.tbLT.Text, pbsI.tbName.Text, "C_TCC||C", "C");
                        //add_LVO(0, ItemCount.ToString(), pbsI.tbType.Text + " Battery:  " + pbsI.tbName.Text, pbsI.tbNBcell.Text, tCust_Mult.Text, pbsI.tbPrice.Text, pbsI.tbExt.Text, pbsI.tbLT.Text, pbsI.tbName.Text);
                        //add_LVO(1, 0, ItemCount.ToString(), pbsI.tbType.Text, pbsI.tsysnb.Text, tCust_Mult.Text, pbsI.tbPrice.Text, pbsI.tbExt.Text, pbsI.tbLT.Text, pbsI.tbName.Text);
                        add_LVO(1, 1, "", pbsI.tbNBcell.Text + " Cells/Blocks " + pbsI.tbName.Text, "", "", "", "", "", "", "", "C");
                        add_LVO(1, 1, "", "Capacity: " + pbsI.tbCapa.Text + " Ah", "", "", "", "", "", "", "", "C");
                        //add_LVO(1, "", "Dimensions: " + pbsI.tbDim.Text, "", "", "", "", "");
                        div_Dim(pbsI.tbDim.Text, ref stIn);
                        add_LVO(1, 1, "", "Dimensions: " + stIn, "", "", "", "", "", "", "", "C");
                        //add_LVO(1, "", "            " + stMm, "", "", "", "", "");
                        add_LVO(1, 1, "", "Warranty: " + pbsI.tbWaran.Text, "", "", "", "", "", "", "", "C");
                        if (pbsI.tbRack.Text != "") add_LVO(1, 1, "", "Battery rack: " + pbsI.tbRack.Text, "", "", "", "", "", "", "", "C");
                        if (pbsI.tbICExt.Text != "0") add_LVO(1, 1, "", "Inter Cell ", pbsI.tbICQty.Text, tCust_Mult.Text, pbsI.tbICup.Text, pbsI.tbICExt.Text, "", "", "", "C");
                        if (pbsI.tbELExt.Text != "0") add_LVO(1, 1, "", "End Lugs", pbsI.tbELQty.Text, tCust_Mult.Text, pbsI.tbELup.Text, pbsI.tbELExt.Text, "", "", "", "C");
                        break;
                    case 'R':
                    case 'r':
                        ItemCount++;
                        add_LVO(1, 0, ItemCount.ToString(), pbsI.tbType.Text + " Rack:  " + pbsI.trModel.Text, pbsI.trQty.Text, tCust_Mult.Text, pbsI.trPrice.Text, pbsI.trExt.Text, pbsI.trLT.Text, pbsI.trModel.Text, "C_TCC||C", "C");
                        div_Dim(pbsI.trDim.Text, ref stIn);
                        add_LVO(1, 1, "", "Dimensions: " + stIn, "", "", "", "", "", "", "", "C");
                        //add_LVO(1, "", "            " + stMm, "", "", "", "", "");
                        break;
                }
                Ref_ALSTOT('A');
            }
        }

        private void div_Dim(string st, ref string stIn)
        {
            int pos = st.IndexOf("mm", 0);
            if (pos > -1)
            {
                stIn = " (mm)" + st.Substring(pos + 3, st.Length - pos - 3);
                stIn += "   (inch) " + st.Substring(6, pos - 6);
            }
            else { stIn = " (inch) " + st; }
        }

        private void add_LVO(int ToBePrinted, int deb, string nb, string Desc, string Qt, string mult, string up, string ext, string LT, string stPartnb, string TecVal, string Grp)
        {
            ListViewItem lvI = lvQITEMS.Items.Add(""); //order
            lvI.Checked = (ToBePrinted != 0);
            if (deb == 0 || deb == 2 || deb == 3)
            {
                if (deb == 0) lvI.BackColor = Color.Salmon;
                if (deb == 2) lvI.BackColor = Color.LightYellow;
                lvI.SubItems.Add(nb);
            }
            else lvI.SubItems.Add(" "); ////aff
            if (ext != "" && tXRATE.Text != "" && ext != "0") ext = Convert.ToString(Math.Round(Tools.Conv_Dbl(mult) * Tools.Conv_Dbl(up) * Tools.Conv_Dbl(Qt) * Tools.Conv_Dbl(tXRATE.Text), MainMDI.Q_NB_DEC_AFF)); else ext = "";
            lvI.SubItems.Add(Desc); //item
            lvI.SubItems.Add(Qt); //Qty
            if (ext != "" && ext != "0") lvI.SubItems.Add(MainMDI.A00(mult));
            else lvI.SubItems.Add(""); //Mult
            lvI.SubItems.Add(MainMDI.A00(up)); //Unit Price
            //if (up != "" && Qt != "") ext = Convert.ToString(Math.Round(Tools.Conv_Dbl(up) * Tools.Conv_Dbl(Qt) * Tools.Conv_Dbl(tXRATE.Text), MainMDI.NB_DEC_AFF));
            //if (ext != "" && ext != "0")
            if (ext != "" && ext != "0") lvI.SubItems.Add(Grp); else lvI.SubItems.Add(""); //Xchnge
            lvI.SubItems.Add(MainMDI.A00(ext)); //Extension
            if (ext == "0") lvI.SubItems[lvI.SubItems.Count - 1].BackColor = Color.DarkTurquoise;
            if (ext != "" && ext != "0") lvI.SubItems.Add(LT);
            else lvI.SubItems.Add(""); //LT
            lvI.SubItems.Add(""); //nbDef
            lvI.SubItems.Add(stPartnb); //PartNB
            lvI.SubItems.Add(""); //Det_LID
            lvI.SubItems.Add(TecVal); //Tech. Values
        }

        private void add_LVO_NL(byte deb, string nb, string Desc, string Qt, string mult, string up, string ext, string LT, string stPartnb, string Grp, string tva)
        {
            ListViewItem lvI = lvQITEMS.Items.Add("");
            if (deb == 0 || deb == 2 || deb == 3)
            {
                if (deb == 0) lvI.BackColor = Color.Salmon;
                if (deb == 2) lvI.BackColor = Color.LightYellow;
                if (tva.Length > 6) if (tva.Substring(0, 5) == "BNS||") lvI.BackColor = BNS_color;
                lvI.SubItems.Add(nb);
            }
            else lvI.SubItems.Add(" "); //must be space
            lvI.SubItems.Add(Desc);
            lvI.SubItems.Add(Qt);
            lvI.SubItems.Add(mult); //lvI.SubItems.Add("");
            if (up != "0") lvI.SubItems.Add(up); else lvI.SubItems.Add("");
            lvI.SubItems.Add(Grp);
            lvI.SubItems.Add(MainMDI.A00(ext));
            //if (ext == "0") lvI.SubItems[lvI.SubItems.Count - 1].BackColor = Color.DarkTurquoise;
            if (ext != "" && ext != "0") lvI.SubItems.Add(LT);
            else lvI.SubItems.Add("");
            lvI.SubItems.Add("");
            lvI.SubItems.Add("");
            lvI.SubItems.Add(stPartnb);
            lvI.SubItems.Add(tva);
        }

        private void Add_Rectif()
        {
            P5500 Rectifdlg = new P5500();
            Rectifdlg.ShowDialog();
            if (Rectifdlg.lsave.Text == "Y")
            {
                ItemCount++;
                //string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
                //add_LVO(0, ItemCount.ToString(), frmchdlg.lvDefOption.Items[i].SubItems[2].Text, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text);
                //string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
                add_LVO(1, 0, ItemCount.ToString(), "EDI RECTIFIER " + Rectifdlg.lRecModel.Text, Rectifdlg.tIQty.Text, Rectifdlg.tSMRK.Text, Rectifdlg.tIPU.Text, Rectifdlg.tIExt.Text, Rectifdlg.tILT.Text, "", "", "A");
                if (Rectifdlg.chkEnc.Checked) add_LVO(1, 1, "", Rectifdlg.chkEnc.Text + ": " + Rectifdlg.cbEnc.Text, "", "", "", "", "", "", "", "A");
                if (Rectifdlg.chkInput.Checked) add_LVO(1, 1, "", Rectifdlg.chkInput.Text + ": " + Rectifdlg.cbInput.Text, "", "", "", "", "", "", "", "A");
                if (Rectifdlg.chkheat.Checked) add_LVO(1, 1, "", Rectifdlg.chkheat.Text + ": " + Rectifdlg.cbHeat.Text, "", "", "", "", "", "", "", "A");
                if (Rectifdlg.chkplc.Checked) add_LVO(1, 1, "", Rectifdlg.chkplc.Text + ": " + Rectifdlg.cbPLC.Text, "", "", "", "", "", "", "", "A");
                if (Rectifdlg.chkinternal.Checked) add_LVO(1, 1, "", Rectifdlg.chkinternal.Text + ": " + Rectifdlg.cbInternal.Text, "", "", "", "", "", "", "", "A");
                if (Rectifdlg.chk3PHS.Checked) add_LVO(1, 1, "", Rectifdlg.chk3PHS.Text + ": " + Rectifdlg.cb3PHS.Text, "", "", "", "", "", "", "", "A");
                if (Rectifdlg.chktermalP.Checked) add_LVO(1, 1, "", Rectifdlg.chktermalP.Text + ((Rectifdlg.ttermalP.Text == "STD") ? "" : ": " + Rectifdlg.ttermalP.Text), "", "", "", "", "", "", "", "A");
                if (Rectifdlg.chkApp.Checked) add_LVO(1, 1, "", Rectifdlg.chkApp.Text + ": " + Rectifdlg.tApp.Text, "", "", "", "", "", "", "", "A");
                Ref_ALSTOT('A');
            }
        }

        private void Add_SWMD_P600()
        {
            P600_SwitchMD Rectifdlg = new P600_SwitchMD();
            Rectifdlg.ShowDialog();
            if (Rectifdlg.lsave.Text == "Y")
            {
                ItemCount++;
                //string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
                //add_LVO(0, ItemCount.ToString(), frmchdlg.lvDefOption.Items[i].SubItems[2].Text, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text);
                //string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
                add_LVO(1, 0, ItemCount.ToString(),MainMDI.arr_EFSdict[49, MainMDI.Lang] + " " + Rectifdlg.lmodel.Text, Rectifdlg.tIQty.Text, Rectifdlg.tSMRK.Text, Rectifdlg.tIPU.Text, Rectifdlg.tIExt.Text, Rectifdlg.tILT.Text, ""," C_MODEL||" + Rectifdlg.lmodel.Text, "A");

                string Line1 = "Input Current: " + Rectifdlg.txInputC.Text + ", " + "Enclosure: " + Rectifdlg.txEnc.Text + ", " + "Modules#: " + Rectifdlg.txModnb.Text + ", " + "Subrack: " + Rectifdlg.txSubRK.Text;

                add_LVO(1, 1, "", Line1, "", "", "", "", "", "", "", "A");

                //if (Rectifdlg.chkInput.Checked) add_LVO(1, 1, "", Rectifdlg.chkInput.Text + ": " + Rectifdlg.cbInput.Text, "", "", "", "", "", "", "", "A");
                Ref_ALSTOT('A');
            }
        }

        private void Add_SWMD_P600_FP()
        {
            P600_SwitchMD_FP Rectifdlg = new P600_SwitchMD_FP();
            Rectifdlg.ShowDialog();
            if (Rectifdlg.lsave.Text == "Y")
            {
                ItemCount++;
                //string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
                //add_LVO(0, ItemCount.ToString(), frmchdlg.lvDefOption.Items[i].SubItems[2].Text, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text);
                //string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
                add_LVO(1, 0, ItemCount.ToString(), MainMDI.arr_EFSdict[49, MainMDI.Lang] + " " + Rectifdlg.lmodel.Text, Rectifdlg.tIQty.Text, Rectifdlg.tSMRK.Text, Rectifdlg.tIPU.Text, Rectifdlg.tIExt.Text, Rectifdlg.tILT.Text, "", " C_MODEL||" + Rectifdlg.lmodel.Text, "A");

                string Line1 = Rectifdlg.txf1.Text + ", " + Rectifdlg.txf2.Text + ", " + Rectifdlg.txf3.Text;

                add_LVO(1, 1, "", Line1, "", "", "", "", "", "", "", "A");

                Line1 = Rectifdlg.txf4.Text;

                add_LVO(1, 1, "", Line1, "", "", "", "", "", "", "", "A");

                //if (Rectifdlg.chkInput.Checked) add_LVO(1, 1, "", Rectifdlg.chkInput.Text + ": " + Rectifdlg.cbInput.Text, "", "", "", "", "", "", "", "A");
                Ref_ALSTOT('A');
            }
        }

        private void Add_SWMD_P600_EZ()
        {
            P600_SwitchMD_EZ Rectifdlg = new P600_SwitchMD_EZ();
            //this.Hide();
            Rectifdlg.ShowDialog();
            //this.Visible = true;
            if (Rectifdlg.lsave.Text == "Y")
            {
                ItemCount++;
                //string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
                //add_LVO(0, ItemCount.ToString(), frmchdlg.lvDefOption.Items[i].SubItems[2].Text, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text);
                //string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
                add_LVO(1, 0, ItemCount.ToString(), MainMDI.arr_EFSdict[49, MainMDI.Lang] + " " + Rectifdlg.lmodel.Text, Rectifdlg.tIQty.Text, Rectifdlg.tSMRK.Text, Rectifdlg.tIPU.Text, Rectifdlg.tIExt.Text, Rectifdlg.tILT.Text, "", " C_MODEL||" + Rectifdlg.lmodel.Text, "A");

                string Line1 = Rectifdlg.txf1.Text;

                add_LVO(1, 1, "", Line1, "", "", "", "", "", "", "", "A");

                //Line1 = Rectifdlg.txf4.Text;
                //add_LVO(1, 1, "", Line1, "", "", "", "", "", "", "", "A");
                add_LVO(1, 1, "", Rectifdlg.txf2.Text, "", "", "", "", "", "", "", "");
                add_LVO(1, 1, "", Rectifdlg.txf3.Text, "", "", "", "", "", "", "", "");

                //+ ", " + Rectifdlg.txf2.Text + ", " + Rectifdlg.txf3.Text;

                //if (Rectifdlg.chkInput.Checked) add_LVO(1, 1, "", Rectifdlg.chkInput.Text + ": " + Rectifdlg.cbInput.Text, "", "", "", "", "", "", "", "A");
                Ref_ALSTOT('A');
            }
        }

        /*		
        private void Add_ChargerOLD()
        {
            Chargerdlg frmchdlg = new Chargerdlg('0', MainMDI._connectionString);
            this.Hide();
            frmchdlg.ShowDialog();
            this.Visible = true;
            if (frmchdlg.lSave.Text == "Y")
            {
                for (int i = 0; i < frmchdlg.lvDefOption.Items.Count; i++)
                {
                    if (i == 0)
                    {
                        ItemCount++;
                        string lFrml = "";
                        for (int y = 0; y < Charger.NB_FRML; y++)
                        {
                            if (frmchdlg.dlg_arr_CAL_FRML[y] != "")
                                lFrml += " " + frmchdlg.dlg_arr_CAL_FRML[y];
                            else break;
                        }
                        add_LVO(1, 0, ItemCount.ToString(), frmchdlg.lvDefOption.Items[i].SubItems[1].Text, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text, frmchdlg.lvDefOption.Items[i].SubItems[11].Text, lFrml);
                        //arr_Tech_values[lvQITEMS.Items.Count - 1] = lFrml;
                    }
                    else
                    {
                        if (frmchdlg.lvDefOption.Items[i].Checked)
                        {
                            //added on 07/12/05
                            string r_TecV = "";
                            if (frmchdlg.lvDefOption.Items[i].SubItems[8].Text != "")
                            {
                                if (frmchdlg.lvDefOption.Items[i].SubItems[10].Text == "ALRM")
                                    r_TecV = frmchdlg.lvDefOption.Items[i].SubItems[11].Text;
                            }
                            //added on 07/12/05
                            string st = frmchdlg.lvDefOption.Items[i].SubItems[1].Text == "" ? frmchdlg.lvDefOption.Items[i].SubItems[2].Text : frmchdlg.lvDefOption.Items[i].SubItems[1].Text + "= " + frmchdlg.lvDefOption.Items[i].SubItems[2].Text;
                            if (frmchdlg.lvDefOption.Items[i].SubItems[4].Text != "0")
                                add_LVO(1, 1, "", st, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text, frmchdlg.lvDefOption.Items[i].SubItems[11].Text, r_TecV);
                            else add_LVO(1, 1, "", st, "", "", "", "", "", frmchdlg.lvDefOption.Items[i].SubItems[11].Text, r_TecV);
                            if (frmchdlg.lvDefOption.Items[i].ForeColor == Color.Red) lvQITEMS.Items[lvQITEMS.Items.Count - 1].ForeColor = Color.Red;
                        }
                    }
                }
                Ref_ALSTOT();
            }
            frmchdlg.Dispose();
        }
        */

        private void Add_P5500()
        {
            Chargerdlg_P5500 frmchdlgP5500 = new Chargerdlg_P5500('0', MainMDI.M_stCon);
            this.Hide();
            frmchdlgP5500.ShowDialog();
            this.Visible = true;
            if (frmchdlgP5500.lSave.Text == "Y")
            {
                for (int i = 0; i < frmchdlgP5500.lvDefOption.Items.Count; i++)
                {
                    if (i == 0)
                    {
                        ItemCount++;
                        string lFrml = "";
                        string model = frmchdlgP5500.lvDefOption.Items[i].SubItems[1].Text;
                        //int ipos = model.IndexOf("charger") + 8;
                        string st = MainMDI.arr_EFSdict[39, MainMDI.Lang];
                        int ipos = model.IndexOf(st) + st.Length + 1;
                        model = model.Substring(ipos, model.Length - ipos);
                        for (int y = 0; y < Charger.NB_FRML; y++)
                        {
                            if (frmchdlgP5500.dlg_arr_CAL_FRML[y] != "")
                                lFrml += " " + frmchdlgP5500.dlg_arr_CAL_FRML[y];
                            else break;
                        }
                        lFrml += " C_MODEL||" + model + " C_TCC||A";
                        //here add TV value to TEC_Val
                        lFrml += " " + frmchdlgP5500.lOth_TV;
                        add_LVO(1, 0, ItemCount.ToString(), frmchdlgP5500.lvDefOption.Items[i].SubItems[1].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[4].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[5].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[6].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[11].Text, lFrml, "A");
                        //arr_Tech_values[lvQITEMS.Items.Count - 1] = lFrml;
                    }
                    else
                    {
                        if (frmchdlgP5500.lvDefOption.Items[i].Checked)
                        {
                            string r_TecV = frmchdlgP5500.lvDefOption.Items[i].SubItems[11].Text;
                            //added on 07/12/05
                            //string r_TecV = "";
                            //if (frmchdlg.lvDefOption.Items[i].SubItems[8].Text != "")
                            //{
                                //if (frmchdlg.lvDefOption.Items[i].SubItems[10].Text == "ALRM")
                                    //r_TecV = frmchdlg.lvDefOption.Items[i].SubItems[11].Text;
                            //
                            //
                            //}
                            //added on 07/12/05
                            string st = frmchdlgP5500.lvDefOption.Items[i].SubItems[1].Text == "" ? frmchdlgP5500.lvDefOption.Items[i].SubItems[2].Text : frmchdlgP5500.lvDefOption.Items[i].SubItems[1].Text + "= " + frmchdlgP5500.lvDefOption.Items[i].SubItems[2].Text;
                            if (frmchdlgP5500.lvDefOption.Items[i].SubItems[4].Text != "0")
                                add_LVO(1, 1, "", st, frmchdlgP5500.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[4].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[5].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[6].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[10].Text, r_TecV, "A");
                            else add_LVO(1, 1, "", st, "", "", "", "", "", frmchdlgP5500.lvDefOption.Items[i].SubItems[10].Text, r_TecV, "A");
                            if (frmchdlgP5500.lvDefOption.Items[i].ForeColor == Color.Red) lvQITEMS.Items[lvQITEMS.Items.Count - 1].ForeColor = Color.Red;
                        }
                    }
                }
                Ref_ALSTOT('A');
            }
            frmchdlgP5500.Dispose();
        }

        void add_itemHidden_ITcharger()
        {
            string _desc = (MainMDI.Lang == 0) ? @"PC23 c/w touch screen, P4600 overlay and cabinet door cutout" : "PC23 incluant écran tactil, membrane et ouverture dans la porte";
            add_LVO(1, 0, ItemCount.ToString(), _desc, "1", "1", "250", "250", "", "", "C_HIDE", "A");
            //ItemCount++;
            //Ref_ALSTOT('A');
        }

        private void Add_Charger(char tst)
        {
            string B_model = "";
            Chargerdlg frmchdlg = new Chargerdlg('0', MainMDI.M_stCon,tst);
            this.Hide();
            frmchdlg.ShowDialog();
            this.Visible = true;
            int ndxChrg = -1;
            if (frmchdlg.lSave.Text == "Y")
            {
                for (int i = 0; i < frmchdlg.lvDefOption.Items.Count; i++)
                {
                    if (i == 0)
                    {
                        ItemCount++;
                        string lFrml = "";
                        string model = frmchdlg.lvDefOption.Items[i].SubItems[1].Text;
                        //int ipos = model.IndexOf("charger") + 8;
                        string st = MainMDI.arr_EFSdict[39, MainMDI.Lang];
                        int ipos = model.IndexOf(st) + st.Length + 1;
                        model = model.Substring(ipos, model.Length - ipos);
                        for (int y = 0; y < Charger.NB_FRML; y++)
                        {
                            if (frmchdlg.dlg_arr_CAL_FRML[y] != "")
                                lFrml += " " + frmchdlg.dlg_arr_CAL_FRML[y];
                            else break;
                        }
                        B_model = model;
                        lFrml += " C_MODEL||" + model + " C_TCC||A";
                        //here add TV value to TEC_Val
                        lFrml += " " + frmchdlg.lOth_TV;
                        add_LVO(1, 0, ItemCount.ToString(), frmchdlg.lvDefOption.Items[i].SubItems[1].Text, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text, frmchdlg.lvDefOption.Items[i].SubItems[11].Text, lFrml, "A");
                        //arr_Tech_values[lvQITEMS.Items.Count - 1] = lFrml;
                        //30052014 ede

                        ndxChrg = lvQITEMS.Items.Count - 1;
                    }
                    else
                    {
                        if (frmchdlg.lvDefOption.Items[i].Checked)
                        {
                            string r_TecV = frmchdlg.lvDefOption.Items[i].SubItems[11].Text;
                            //added on 07/12/05
                            //string r_TecV = "";
                            //if (frmchdlg.lvDefOption.Items[i].SubItems[8].Text != "")
                            //{
                                //if (frmchdlg.lvDefOption.Items[i].SubItems[10].Text == "ALRM")
                                    //r_TecV = frmchdlg.lvDefOption.Items[i].SubItems[11].Text;
                            //
                            //
                            //}
                            //added on 07/12/05
                            string st = frmchdlg.lvDefOption.Items[i].SubItems[1].Text == "" ? frmchdlg.lvDefOption.Items[i].SubItems[2].Text : frmchdlg.lvDefOption.Items[i].SubItems[1].Text + "= " + frmchdlg.lvDefOption.Items[i].SubItems[2].Text;
                            if (frmchdlg.lvDefOption.Items[i].SubItems[4].Text != "0")
                                add_LVO(1, 1, "", st, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text, frmchdlg.lvDefOption.Items[i].SubItems[10].Text, r_TecV, "A");
                            else add_LVO(1, 1, "", st, "", "", "", "", "", frmchdlg.lvDefOption.Items[i].SubItems[10].Text, r_TecV, "A");
                            if (frmchdlg.lvDefOption.Items[i].ForeColor == Color.Red) lvQITEMS.Items[lvQITEMS.Items.Count - 1].ForeColor = Color.Red;
                        }
                    }
                }
                if (tst != 'T')
                {
                    if (B_model.IndexOf("P4600") > -1)
                    {
                        //ItemCount++;
                        //add_itemHidden_ITcharger();
                        string _desc = (MainMDI.Lang == 0) ? @"PC23 c/w touch screen, P4600 overlay and cabinet door cutout" : "PC23 incluant écran tactil, membrane et ouverture dans la porte";
                        add_LVO(1, 1, "", _desc, "", "", "", "", "", "", "", "A");
                        double ddEXT = Tools.Conv_Dbl(lvQITEMS.Items[ndxChrg].SubItems[7].Text) + ((Tools.Conv_Dbl(lvQITEMS.Items[ndxChrg].SubItems[3].Text) * 250d));
                        double ddPU = ddEXT / Tools.Conv_Dbl(lvQITEMS.Items[ndxChrg].SubItems[4].Text);
                        lvQITEMS.Items[ndxChrg].SubItems[7].Text = Math.Round(ddEXT, 2).ToString();
                        lvQITEMS.Items[ndxChrg].SubItems[5].Text = Math.Round(ddPU, 2).ToString();
                    }
                }
                Ref_ALSTOT('A');
            }
            frmchdlg.Dispose();
        }

        /*
        private void Add_Chargerold()
        {
            Chargerdlg frmchdlg = new Chargerdlg('0', MainMDI._connectionString);
            frmchdlg.ShowDialog();
            if (frmchdlg.lSave.Text == "Y")
            {
                for (int i = 0; i < frmchdlg.lvDefOption.Items.Count; i++)
                {
                    if (i == 0)
                    {
                        ItemCount++;
                        //string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
                        //add_LVO(0, ItemCount.ToString(), frmchdlg.lvDefOption.Items[i].SubItems[2].Text, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text);
                        //string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
                        add_LVO(1, 0, ItemCount.ToString(), frmchdlg.lvDefOption.Items[i].SubItems[1].Text, "", "", "", "", "", "");
                    }
                    else
                    {
                        if (frmchdlg.lvDefOption.Items[i].Checked)
                        {
                            string st = frmchdlg.lvDefOption.Items[i].SubItems[1].Text == "" ? frmchdlg.lvDefOption.Items[i].SubItems[2].Text : frmchdlg.lvDefOption.Items[i].SubItems[1].Text + "= " + frmchdlg.lvDefOption.Items[i].SubItems[2].Text;
                            if (frmchdlg.lvDefOption.Items[i].SubItems[4].Text != "0")
                                add_LVO(1, 1, "", st, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text, frmchdlg.lvDefOption.Items[i].SubItems[7].Text);
                            else add_LVO(1, 1, "", st, "", "", "", "", "", "");
                        }
                    }
                }
                Ref_ALSTOT();
            }
        }

        private void Add_ChargerOLD2()
        {
            Chargerdlg frmchdlg = new Chargerdlg('0', MainMDI._connectionString);
            frmchdlg.ShowDialog();
            if (frmchdlg.lSave.Text == "Y")
            {
                for (int i = 0; i < frmchdlg.lvDefOption.Items.Count; i++)
                {
                    if (frmchdlg.lvDefOption.Items[i].Checked)
                    {
                        ListViewItem lvI = lvQITEMS.Items.Add(""); // 
                        if (i == 0)
                        { 
                            lvI.BackColor = Color.Salmon;
                            ItemCount++;
                            lvI.SubItems.Add(ItemCount.ToString()); //1
                        }
                        else lvI.SubItems.Add(" ");
                        string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
                        lvI.SubItems.Add(st + frmchdlg.lvDefOption.Items[i].SubItems[2].Text); //2
                        lvI.SubItems.Add(frmchdlg.lvDefOption.Items[i].SubItems[3].Text); //3
                        if (frmchdlg.lvDefOption.Items[i].SubItems[4].Text == "" || frmchdlg.lvDefOption.Items[i].SubItems[4].Text == "0")
                        {
                            lvI.SubItems.Add(""); //4
                            lvI.SubItems.Add(""); //5
                            lvI.SubItems.Add(""); //6
                            lvI.SubItems.Add(""); //7
                        }
                        else
                        {
                            if (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") lvI.SubItems.Add(tCust_Mult.Text);
                            else lvI.SubItems.Add("");
                            lvI.SubItems.Add(frmchdlg.lvDefOption.Items[i].SubItems[4].Text); //curr_ALS[als_NDX, 4] = frmchdlg.lvDefOption.Items[i].SubItems[4].Text;
                            lvI.SubItems.Add(frmchdlg.lvDefOption.Items[i].SubItems[5].Text); //curr_ALS[als_NDX, 5] = frmchdlg.lvDefOption.Items[i].SubItems[5].Text;
                            lvI.SubItems.Add(frmchdlg.lvDefOption.Items[i].SubItems[6].Text); //curr_ALS[als_NDX, 6] = frmchdlg.lvDefOption.Items[i].SubItems[6].Text;
                        }
                    }
                    //lvQITEMS.Refresh();
                }
            }
        }

        private bool labelExistold(string st)
        {
            int nb = (tvSol.SelectedNode.ImageIndex == 2) ? tvSol.Nodes.Count : tvSol.SelectedNode.Parent.Nodes.Count;
            for (int i = 0; i < nb; i++)
            { 
                string lbl = (tvSol.SelectedNode.ImageIndex == 2) ? tvSol.Nodes[i].Text : tvSol.SelectedNode.Parent.Nodes[i].Text;
                if (st == lbl) return true;
            }
            return false;
        }
        */

        private bool LBL_Exist(string st)
        {
            switch (tvSol.SelectedNode.ImageIndex)
            {
                case 0:
                case 1:
                    for (int i = 0; i < tvSol.SelectedNode.Parent.Nodes.Count; i++)
                        if (st == tvSol.SelectedNode.Parent.Nodes[i].Text) return true;
                    break;
                case 2:
                    for (int i = 0; i < tvSol.Nodes.Count; i++)
                        if (st == tvSol.Nodes[i].Text) return true;
                    break;
            }
            return false;
        }

        private int REV_Nb(string revSt)
        {
            int nb = -1;
            for (int i = 0; i < tvSol.Nodes.Count; i++)
            {
                if (tvSol.Nodes[i].Text.Substring(0, 2) == revSt)
                {
                    int tt = Convert.ToInt32(tvSol.Nodes[i].Text.Substring(3, tvSol.Nodes[i].Text.Length - 3));
                    if (tt > nb) nb = tt;
                }
            }
            return nb;
        }

        private bool REv_Exist(string st)
        {
            if (tvSol.Nodes.Count > 0)
            {
                for (int i = 0; i < tvSol.Nodes.Count; i++)
                    if (st == tvSol.Nodes[i].Text) return true;
            }
            return false;
        }

        private bool LBL_Exist_Newa(string st)
        {
            if (lTVSel.Text == "Y" && tvSol.Nodes.Count > 0)
            {
                for (int i = 0; i < tvSol.SelectedNode.Nodes.Count; i++)
                    if (st == tvSol.SelectedNode.Nodes[i].Text) return true;
            }
            return false;
        }

        private void Add_NLItemOption_NEW()
        {
            //NL_Item_Option frmNLIO = new NL_Item_Option(tQuoteID.Text);
            //string keyinfo = MainMDI.A00(lQuoteID.Text, 8) + " / " + cbCompanyy + " / " + MainMDI.A00(tQuoteID.Text, 8) + " / " + lCurSoln.Text + "/" + lCurSPCn.Text + "/" + lCurALSn.Text;
            string keyinfo = MainMDI.A00(tQuoteID.Text, 8) + " / " + cbCompanyy.Text + " / " + lCurSoln.Text + "/" + lCurSPCn.Text + "/" + lCurALSn.Text;
            NL_Item_Option_NEW_2 frmNLIO = new NL_Item_Option_NEW_2(tQuoteID.Text, keyinfo);
            //NL_Item_Option_NEW frmNLIO = new NL_Item_Option_NEW(tQuoteID.Text, keyinfo);
            this.Hide();
            frmNLIO.ShowDialog();
            this.Visible = true;
            if (frmNLIO.SaveOK)
            {
                ItemCount++;
                string st = (frmNLIO.tIModel.Text == "") ? frmNLIO.tIName.Text : frmNLIO.tIName.Text + " / " + frmNLIO.tIModel.Text;
                //add_LVO(0, ItemCount.ToString(), st, frmNLIO.tIQty.Text, tCust_Mult.Text, frmNLIO.tIPU.Text, frmNLIO.tIExt.Text, frmNLIO.tILT.Text);
                //if (frmNLIO.opt_NOmult.Checked) add_LVO_NL(0, ItemCount.ToString(), st, frmNLIO.tIQty.Text, frmNLIO.tSMRK.Text, frmNLIO.tIPU.Text, frmNLIO.tIExt.Text, frmNLIO.tILT.Text, frmNLIO.tIModel.Text, "C", frmNLIO.lsavALLinfo.Text);
                //else add_LVO_NL(0, ItemCount.ToString(), st, frmNLIO.cal_qty.Text, frmNLIO.cal_multipl.Text, frmNLIO.cal_pu.Text, frmNLIO.cal_ext.Text, frmNLIO.tILT.Text, frmNLIO.tIModel.Text, "C", frmNLIO.lsavALLinfo.Text);
                add_LVO_NL(0, ItemCount.ToString(), st, frmNLIO.cal_qty.Text, frmNLIO.cal_multipl.Text, frmNLIO.cal_pu.Text, frmNLIO.cal_ext.Text, frmNLIO.tILT.Text, frmNLIO.tIModel.Text, "C", frmNLIO.lsavALLinfo.Text);

                if (frmNLIO.tIdim.Text != "") add_LVO(1, 1, "", frmNLIO.tIdim.Text, "", "", "", "", "", "", "", "C");
                if (frmNLIO.tIf1.Text != "") add_LVO(1, 1, "", frmNLIO.tIf1.Text, "", "", "", "", "", "", "", "C");
                if (frmNLIO.tIf2.Text != "") add_LVO(1, 1, "", frmNLIO.tIf2.Text, "", "", "", "", "", "", "", "C");
                if (frmNLIO.tIotherF.Text != "")
                {
                    st = frmNLIO.tIotherF.Text;
                    //if (frmNLIO.lIotherF.Text != "") add_LVO(1, "", frmNLIO.lIotherF.Text, "", "", "", "", "");
                    while (st.Length > 0)
                    {
                        int ipos = st.IndexOf('\n', 0);
                        if (ipos == -1)
                        {
                            add_LVO(1, 1, "", "          " + st, "", "", "", "", "", "", "", "C");
                            break;
                        }
                        else
                        {
                            add_LVO(1, 1, "", "          " + st.Substring(0, ipos - 1), "", "", "", "", "", "", "", "C");
                            st = st.Substring(ipos + 1, st.Length - ipos - 1);
                        }
                    }
                }
                Ref_ALSTOT('A');
            }
        }

        private void Add_Service()
        {
            //NL_Item_Option frmNLIO = new NL_Item_Option(tQuoteID.Text);
            //string keyinfo = MainMDI.A00(lQuoteID.Text, 8) + " / " + cbCompanyy + " / " + MainMDI.A00(tQuoteID.Text, 8) + " / " + lCurSoln.Text + "/" + lCurSPCn.Text + "/" + lCurALSn.Text;
            //string keyinfo = MainMDI.A00(tQuoteID.Text, 8) + " / " + cbCompanyy.Text + " / " + lCurSoln.Text + "/" + lCurSPCn.Text + "/" + lCurALSn.Text;

            Q_service frmNLIO = new Q_service();
            //this.Hide();
            frmNLIO.ShowDialog();
            this.Visible = true;
            if (frmNLIO.SaveOK)
            {
                if (frmNLIO.chk_th.Checked) add_LVO_NL(0, ItemCount.ToString(), frmNLIO.txitem_th.Text, "1", "1", frmNLIO.txC39_th.Text, frmNLIO.txC39_th.Text, "", "", "A", "");
                if (frmNLIO.chk_ts.Checked) add_LVO_NL(0, ItemCount.ToString(), frmNLIO.txitem_ts.Text, "1", "1", frmNLIO.txC39_ts.Text, frmNLIO.txC39_ts.Text, "", "", "A", "");
                Ref_ALSTOT('A');
            }
        }

        private void Add_NLItemOption_OLD()
        {
            //NL_Item_Option frmNLIO = new NL_Item_Option(tQuoteID.Text);
            NL_Item_Option frmNLIO = new NL_Item_Option(tQuoteID.Text);
            this.Hide();
            frmNLIO.ShowDialog();
            this.Visible = true;
            if (frmNLIO.SaveOK)
            {
                ItemCount++;
                string st = (frmNLIO.tIModel.Text == "") ? frmNLIO.tIName.Text : frmNLIO.tIName.Text + " / " + frmNLIO.tIModel.Text;
                //add_LVO(0, ItemCount.ToString(), st, frmNLIO.tIQty.Text, tCust_Mult.Text, frmNLIO.tIPU.Text, frmNLIO.tIExt.Text, frmNLIO.tILT.Text);
                add_LVO_NL(0, ItemCount.ToString(), st, frmNLIO.tIQty.Text, frmNLIO.tSMRK.Text, frmNLIO.tIPU.Text, frmNLIO.tIExt.Text, frmNLIO.tILT.Text, frmNLIO.tIModel.Text, "C", "  ");
                if (frmNLIO.tIdim.Text != "") add_LVO(1, 1, "", "Dimensions= " + frmNLIO.tIdim.Text, "", "", "", "", "", "", "", "C");
                if (frmNLIO.tIf1.Text != "") add_LVO(1, 1, "", frmNLIO.lif1.Text + "=  " + frmNLIO.tIf1.Text, "", "", "", "", "", "", "", "C");
                if (frmNLIO.tIf2.Text != "") add_LVO(1, 1, "", frmNLIO.lif2.Text + "=  " + frmNLIO.tIf2.Text, "", "", "", "", "", "", "", "C");
                if (frmNLIO.tIotherF.Text != "")
                {
                    st = frmNLIO.tIotherF.Text;
                    //if (frmNLIO.lIotherF.Text != "") add_LVO(1, "", frmNLIO.lIotherF.Text, "", "", "", "", "");
                    while (st.Length > 0)
                    {
                        int ipos = st.IndexOf('\n', 0);
                        if (ipos == -1)
                        {
                            add_LVO(1, 1, "", "          " + st, "", "", "", "", "", "", "", "C");
                            break;
                        }
                        else
                        {
                            add_LVO(1, 1, "", "          " + st.Substring(0, ipos - 1), "", "", "", "", "", "", "", "C");
                            st = st.Substring(ipos + 1, st.Length - ipos - 1);
                        }
                    }
                }
                Ref_ALSTOT('A');
            }
        }

        private void dup_Alias()
        {
            //MessageBox.Show("Alias= " + tvSol.SelectedNode.Text);
            //string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* " +
                //" FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                //" WHERE (((PSM_Q_IGen.i_Quoteid)=62)) ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
        }

        private void Duplica_Sol()
        {
            bool alsAdded = false;
            int nbSol = 1, nbSpc = 1, nbAls = 1;
            long r_Spcid = 0, r_SolId = 0, r_alsId = 0;
            ini_arrSql();
            int S = 0;
            string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.*, PSM_Q_SPCS.Rnk AS SPCS_Rnk, PSM_Q_ALS.Rnk AS ALS_Rnk, PSM_Q_Details.Rnk AS Details_Rnk " +
                " FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " WHERE (PSM_Q_IGen.i_Quoteid=" + lCurrIQID.Text + " and PSM_Q_SOL.Sol_Name='" + lCurSoln.Text + "') ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string Osol = "", Nsol = "", Ospc = "", Nspc = "", Nals = "", Oals = "";
            while (Oreadr.Read())
            {
                //alsAdded = false;

                if (Nsol == "")
                {
                    int t = REV_Nb(lCurSoln.Text.Substring(0, 2)) + 1;
                    Nsol = lCurSoln.Text.Substring(0, 2) + "-" + MainMDI.A00(t, 2);
                    //Nsol = "Copy_" + Oreadr["Sol_Name"].ToString();
                }
                Nspc = Oreadr["SPC_Name"].ToString();
                Nals = Oreadr["ALS_Name"].ToString();
                if (Osol != Nsol)
                {
                    nbSol = tvSol.Nodes.Count;
                    //Nsol = "Copy" + nbSol + "_" + Oreadr["Sol_Name"].ToString();
                    r_SolId = Save_SOL(lCurrIQID.Text, Nsol, nbSol.ToString(), Oreadr["img"].ToString());
                    //addNode_Sol(Nsol, Oreadr["img"].ToString(), Oreadr["status_Rev"].ToString());
                    addNode_Sol(Nsol, Oreadr["img"].ToString(), "N");
                    Osol = Nsol;
                }
                if (Ospc != Nspc)
                {
                    if (tvSol.Nodes[nbSol].Nodes.Count == 0)
                    {
                        nbSpc = 0;
                        nbAls = 0;
                    }
                    else
                    {
                        nbSpc = tvSol.Nodes[nbSol].Nodes.Count;
                        nbAls = tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count;
                    }
                    //r_Spcid = Save_SPEC(r_SolId, Nspc.ToString(), nbSpc.ToString());
                    r_Spcid = Save_SPEC(r_SolId, Nspc, Oreadr["SPCS_Rnk"].ToString());
                    addNode_Spc(Nspc, nbSol, nbSpc, Nals); //alsAdded = true;
                    //Ospc = Nspc;
                }
                if (Oals != Nals || Ospc != Nspc) //|| alsAdded)
                {
                    //r_alsId = Save_ALS(r_Spcid, Nals, nbAls.ToString(), Oreadr["tot"].ToString());
                    r_alsId = Save_ALS(r_Spcid, Nals, Oreadr["ALS_Rnk"].ToString(), Oreadr["Tot"].ToString(), Oreadr["PxPrice"].ToString(), Oreadr["AGPrice"].ToString(), Oreadr["AlsQty"].ToString());
                    //if (!alsAdded)
                    if (!AlsNodeAdded(Nals, nbSol, nbSpc))
                    {
                        addNode_Als(Nals, nbSol, nbSpc);
                        nbAls = (nbSpc == 0) ? 0 : tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count;
                    }
                    //Oals = Nals;
                }
                Ospc = Nspc;
                Oals = Nals;

                double ddUP = (Oreadr["Uprice"].ToString() == "") ? 0 : Tools.Conv_Dbl(Oreadr["Uprice"].ToString());
                string LA = (Oreadr["LeadTime"].ToString() == "") ? "04-06" : Oreadr["LeadTime"].ToString();
                string stSql2 = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " +
                    " [Desc],[Qty],[Xch_Mult], [Uprice],[Mult],[Ext],[LeadTime],[PN],[Q_tec_Val], [Rnk] ) VALUES ('" +
                    r_alsId.ToString() + "', '" +
                    Oreadr["Aff_ID"].ToString() + "', '" +
                    Oreadr["Desc"].ToString().Replace("'", "''") + "', '" +
                    Oreadr["Qty"] + "', '" +
                    Oreadr["Xch_Mult"] + "', '" +
                    Oreadr["Uprice"] + "', '" +
                    Oreadr["Mult"] + "', '" +
                    Oreadr["Ext"] + "', '" +
                    Oreadr["LeadTime"] + "', '" +
                    Oreadr["PN"] + "', '" +
                    Oreadr["Q_tec_Val"] + "', '" +
                    Oreadr["Details_Rnk"].ToString() + "')";
                //MainMDI.Write_JFS(stSql);
                //if (!MainMDI.ExecSql(stSql2)) MessageBox.Show("Error Details Duplication....");
                arr_Sql[S++] = stSql2;
                //MainMDI.Write_JFS(stSql);
                //if (!MainMDI.ExecSql_Big(stSql2)) MessageBox.Show("Error Details Duplication....");
            }
            Oreadr.Close();
            OConn.Close();
            for (int i = 0; i < S; i++)
            {
                MainMDI.Write_JFS(arr_Sql[i]);
                if (!MainMDI.ExecSql(arr_Sql[i]))
                {
                    MessageBox.Show("Error Details Duplication....");
                    i = S;
                }
            }
            tvSol.Select();
        }

        /*
        double ddUP = (Oreadr["Uprice"].ToString().Length < 2) ? 0 : Tools.Conv_Dbl(Oreadr["Uprice"].ToString());
        int LA = (Oreadr["LeadTime"].ToString() == "") ? 0 : Convert.ToInt32(Oreadr["LeadTime"].ToString());
        string stSql2 = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " + 
            " [Desc],[Qty],[Xch_Mult], [Uprice],[Mult],[Ext],[LeadTime],[PN], [Rnk] ) VALUES ('" +
            r_alsId.ToString() + "', '" +
            Oreadr["Aff_ID"].ToString() + "', '" +
            Oreadr["Desc"].ToString().Replace("'", "''") + "', '" +
            Tools.Conv_Dbl(Oreadr["Qty"].ToString()) + "', '" +
            Tools.Conv_Dbl(Oreadr["Xch_Mult"].ToString()) + "', '" +
            ddUP.ToString() + "', '" +
            Tools.Conv_Dbl(Oreadr["Mult"].ToString()) + "', '" +
            Tools.Conv_Dbl(Oreadr["Ext"].ToString()) + "', '" +
            LA.ToString() + "', '" +
            Oreadr["PSM_Q_Details.Rnk"].ToString() + "')";
        */

        private void ini_arrSql()
        {
            for (int i = 0; i < arr_Sql.Length; i++) arr_Sql[i] = "";
        }

        private void Duplica_SPC()
        {
            ini_arrSql(); int S = 0;

            int nbSol = 1, nbSpc = 1, nbAls = 1;
            long r_Spcid = 0, r_SolId = 0, r_alsId = 0;
            string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* ,PSM_Q_ALS.Rnk as A_Rnk, PSM_Q_SOL.Sol_LID AS SOL_ID, PSM_Q_ALS.Rnk AS ALS_Rnk, PSM_Q_Details.Rnk AS Details_Rnk " +
                " FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " WHERE (PSM_Q_IGen.i_Quoteid=" + lCurrIQID.Text + " and PSM_Q_SOL.Sol_Name='" + lCurSoln.Text + "' and PSM_Q_SPCS.SPC_Name='" + lCurSPCn.Text.Replace("'", "''") + "') ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            //Ocmd.CommandTimeout = 1000;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string Nsol = "", Ospc = "", Nspc = "", Nals = "", Oals = "";
            nbSol = Convert.ToInt32(lCurSolNDX.Text);
            //r_SolId = Save_SOL(lCurrIQID.Text, Nsol, nbSol.ToString(), Oreadr["img"].ToString());

            //r_SolId = Convert.ToInt32(lC urrIQID.Text);
            while (Oreadr.Read())
            {
                if (r_SolId == 0) r_SolId = Convert.ToInt32(Oreadr["SOL_ID"].ToString());
                Nsol = Oreadr["Sol_Name"].ToString();
                //if (r_SolId == 0) r_SolId = Save_SOL(lCurrIQID.Text, Nsol, nbSol.ToString(), Oreadr["img"].ToString());
                if (Nspc == "") Nspc = "Copy_" + Oreadr["SPC_Name"].ToString();
                Nals = Oreadr["ALS_Name"].ToString();
                if (Ospc != Nspc)
                {
                    if (tvSol.Nodes[nbSol].Nodes.Count == 0)
                    {
                        nbSpc = 0;
                        nbAls = 0;
                    }
                    else
                    {
                        nbSpc = tvSol.Nodes[nbSol].Nodes.Count;
                        //nbAls = tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count;
                        nbAls = tvSol.Nodes[Convert.ToInt32(lCurSolNDX.Text)].Nodes[Convert.ToInt32(lCurSPCNDX.Text)].Nodes.Count;
                        //if (nbAls > 0) nbAls--;
                    }
                    if (nbAls > 0) nbAls -= 1;
                    Nspc = "Copy" + nbSpc + "_" + Oreadr["SPC_Name"].ToString();
                    r_Spcid = Save_SPEC(r_SolId, Nspc.ToString(), nbSpc.ToString());
                    addNode_Spc(Nspc, nbSol, nbSpc, Nals); //alsAdded = true;
                    nbAls++;
                    Ospc = Nspc;
                }
                //if (Oals != Nals || alsAdded)
                if (Oals != Nals) //&& !alsAdded)
                {
                    //r_alsId = Save_ALS(r_Spcid, Nals, nbAls.ToString(), Oreadr["tot"].ToString());
                    r_alsId = Save_ALS(r_Spcid, Nals, Oreadr["ALS_Rnk"].ToString(), Oreadr["Tot"].ToString(), Oreadr["PxPrice"].ToString(), Oreadr["AGPrice"].ToString(), Oreadr["AlsQty"].ToString());
                    //if (!alsAdded)
                    if (!AlsNodeAdded(Nals, nbSol, nbSpc))
                    {
                        addNode_Als(Nals, nbSol, nbSpc);

                        nbAls = (nbSpc == 0) ? 0 : tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count;
                    }
                    Oals = Nals;
                }
                double ddUP = (Oreadr["Uprice"].ToString() == "") ? 0 : Tools.Conv_Dbl(Oreadr["Uprice"].ToString());
                string LA = (Oreadr["LeadTime"].ToString() == "") ? "04-06" : Oreadr["LeadTime"].ToString();
                string stSql2 = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " +
                    " [Desc],[Qty],[Xch_Mult], [Uprice],[Mult],[Ext],[LeadTime],[PN],[Q_tec_Val], [Rnk] ) VALUES ('" +
                    r_alsId.ToString() + "', '" +
                    Oreadr["Aff_ID"].ToString() + "', '" +
                    Oreadr["Desc"].ToString().Replace("'", "''") + "', '" +
                    Oreadr["Qty"] + "', '" +
                    Oreadr["Xch_Mult"] + "', '" +
                    Oreadr["Uprice"] + "', '" +
                    Oreadr["Mult"] + "', '" +
                    Oreadr["Ext"] + "', '" +
                    Oreadr["LeadTime"] + "', '" +
                    Oreadr["PN"] + "', '" +
                    Oreadr["Q_tec_Val"] + "', '" +
                    Oreadr["Details_Rnk"].ToString() + "')";
                arr_Sql[S++] = stSql2;
                //MainMDI.Write_JFS(stSql);
                //if (!MainMDI.ExecSql_Big(stSql2)) MessageBox.Show("Error Details Duplication....");
            }
            Oreadr.Close();
            OConn.Close();
            for (int i = 0; i < S; i++)
            {
                MainMDI.Write_JFS(arr_Sql[i]);
                if (!MainMDI.ExecSql(arr_Sql[i]))
                {
                    MessageBox.Show("Error Details Duplication....");
                    i = S;
                }
            }
            tvSol.Select();
        }

        private bool AlsNodeAdded(string AlsNme, int nbSol, int nbSpc)
        {
            for (int i = 0; i < tvSol.Nodes[nbSol].Nodes[tvSol.Nodes[nbSol].Nodes.Count - 1].Nodes.Count; i++)
                if (tvSol.Nodes[nbSol].Nodes[tvSol.Nodes[nbSol].Nodes.Count - 1].Nodes[i].Text == AlsNme) return true;
            return false;
        }

        private void Duplica_ALS()
        {
            bool alsAdded = false;
            int nbSol = 1, nbSpc = 1, nbAls = 1;
            long r_Spcid = 0, r_SolId = 0, r_alsId = 0;
            string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* " +
                " FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " WHERE (PSM_Q_IGen.i_Quoteid=" + lCurrIQID.Text + " and PSM_Q_SOL.Sol_Name='" + lCurSoln.Text + "' and PSM_Q_SPCS.SPC_Name='" + lCurSPCn.Text.Replace("'", "''") + "') ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string Nsol = "", Ospc = "", Nspc = "", Nals = "", Oals = "";
            nbSol = Convert.ToInt32(lCurSolNDX.Text);
            //r_SolId=Save_SOL(lCurrIQID.Text, Nsol, nbSol.ToString(), Oreadr["img"].ToString());

            while (Oreadr.Read())
            {
                alsAdded = false;
                Nsol = Oreadr["Sol_Name"].ToString();
                if (r_SolId == 0) r_SolId = Save_SOL(lCurrIQID.Text, Nsol, nbSol.ToString(), Oreadr["img"].ToString());
                if (Nspc == "") Nspc = "Copy_" + Oreadr["SPC_Name"].ToString();
                Nals = Oreadr["ALS_Name"].ToString();
                if (Ospc != Nspc)
                {
                    if (tvSol.Nodes[nbSol].Nodes.Count == 0)
                    {
                        nbSpc = 0;
                        nbAls = 0;
                    }
                    else
                    {
                        nbSpc = tvSol.Nodes[nbSol].Nodes.Count;
                        //nbAls = tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count;
                        nbAls = tvSol.Nodes[Convert.ToInt32(lCurSolNDX.Text)].Nodes[Convert.ToInt32(lCurSPCNDX.Text)].Nodes.Count;
                        if (nbAls > 0) nbAls--;
                    }
                    Nspc = "Copy" + nbSpc + "_" + Oreadr["SPC_Name"].ToString();
                    r_Spcid = Save_SPEC(r_SolId, Nspc.ToString(), nbSpc.ToString());
                    addNode_Spc(Nspc, nbSol, nbSpc, Nals); alsAdded = true;
                    Ospc = Nspc;
                }
                if (Oals != Nals || alsAdded)
                {
                    //r_alsId = Save_ALS(r_Spcid, Nals, nbAls.ToString(), Oreadr["tot"].ToString());
                    r_alsId = Save_ALS(r_Spcid, Nals, Oreadr["PSM_Q_ALS.Rnk"].ToString(), Oreadr["Tot"].ToString(), Oreadr["PxPrice"].ToString(), Oreadr["AGPrice"].ToString(), Oreadr["AlsQty"].ToString());
                    if (!alsAdded)
                    {
                        addNode_Als(Nals, nbSol, nbSpc);
                        nbAls = (nbSpc == 0) ? 0 : tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count;
                    }
                    Oals = Nals;
                }
                //double ddUP = (Oreadr["Uprice"].ToString().Length < 2) ? 0 : Tools.Conv_Dbl(Oreadr["Uprice"].ToString());
                double ddUP = (Oreadr["Uprice"].ToString() == "") ? 0 : Tools.Conv_Dbl(Oreadr["Uprice"].ToString());
                //int LA = (Oreadr["LeadTime"].ToString() == "") ? 0 : Convert.ToInt32(Oreadr["LeadTime"].ToString());
                string LA = (Oreadr["LeadTime"].ToString() == "") ? "04-06" : Oreadr["LeadTime"].ToString();
                string stSql2 = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " +
                    " [Desc],[Qty],[Mult], [Uprice],[LeadTime],[Rnk] ) VALUES ('" +
                    r_alsId.ToString() + "', '" +
                    Oreadr["Aff_ID"].ToString() + "', '" +
                    Oreadr["Desc"].ToString().Replace("'", "''") + "', '" +
                    Tools.Conv_Dbl(Oreadr["Qty"].ToString()) + "', '" +
                    Tools.Conv_Dbl(Oreadr["Xch_Mult"].ToString()) + "', '" +
                    ddUP.ToString() + "', '" +
                    LA.ToString() + "', '" +
                    Oreadr["PSM_Q_Details.Rnk"].ToString() + "')";
                MainMDI.Write_JFS(stSql);
                if (!MainMDI.ExecSql(stSql2)) MessageBox.Show("Error Details Duplication....");
            }
            tvSol.Select();
        }

        private void Save_LBL(string NewLBL, string OldLbl)
        {
            //???
            if (lCurrIQID.Text != "0")
            {
                switch (tvSol.SelectedNode.ImageIndex)
                {
                    case 1: //Spec
                        lCurSPCn.Text = NewLBL;
                        string st = MainMDI.Find_One_Field("SELECT PSM_Q_SPCS.SPC_LID FROM PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID " +
                            " WHERE PSM_Q_SOL.Sol_Name='" + lCurSoln.Text + "' AND PSM_Q_SPCS.SPC_Name='" + OldLbl.Replace("'", "''") + "' and PSM_Q_SOL.I_Quoteid=" + lCurrIQID.Text);
                        if (st != MainMDI.VIDE) MainMDI.ExecSql("UPDATE PSM_Q_SPCS SET [SPC_Name]='" + NewLBL.Replace("'", "''") + "' where SPC_LID=" + st);
                        break;
                    case 0: //Alias
                    case 3:
                        //if (lCurSPCn.Text == MainMDI.VIDE) del_Spc(lCurSoln.Text, lCurSPCn.Text);
                        lCurALSn.Text = NewLBL;
                        string stSql = "SELECT PSM_Q_ALS.ALS_LID FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                            " WHERE PSM_Q_SOL.Sol_Name='" + lCurSoln.Text + "' AND PSM_Q_SPCS.SPC_Name='" + lCurSPCn.Text.Replace("'", "''") + "' AND PSM_Q_ALS.ALS_Name='" + OldLbl.Replace("'", "''") + "' and PSM_Q_SOL.I_Quoteid=" + lCurrIQID.Text;
                        stSql = MainMDI.Find_One_Field(stSql);

                        if (stSql != MainMDI.VIDE)
                        {
                            string myals = (NewLBL.Length > 0) ? NewLBL.Replace("'", "''") : "Toto";

                            stSql = "UPDATE PSM_Q_ALS SET  [ALS_Name]='" + myals + "' where ALS_LID=" + stSql;
                            MainMDI.Exec_SQL_JFS(stSql, "Save_LBL:  " + stSql);
                        }
                        //lCurALSn.Text = NewLBL;
                        break;
                    case 2: //Solution
                    case 5:
                    case 4:
                        //excluded
                        //lCurSoln.Text = NewLBL;
                        //MainMDI.ExecSql("UPDATE PSM_Q_SOL SET [Sol_Name]='" + NewLBL  + "' where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + tvSol.SelectedNode.Text + "'");
                        break;
                }
                OldLabel = "";
            }
        }

        private void Save_LBLold(string NewLBL, string OldLbl)
        {
            //???
            if (lCurrIQID.Text != "0")
            {
                switch (tvSol.SelectedNode.ImageIndex)
                {
                    case 1: //Spec
                        lCurSPCn.Text = NewLBL;
                        string st = MainMDI.Find_One_Field("SELECT PSM_Q_SPCS.SPC_LID FROM PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID " +
                            " WHERE (((PSM_Q_SOL.Sol_Name)='" + lCurSoln.Text + "') AND ((PSM_Q_SPCS.SPC_Name)='" + OldLbl.Replace("'", "''") + "'))");
                        if (st != MainMDI.VIDE) MainMDI.ExecSql("UPDATE PSM_Q_SPCS SET [SPC_Name]='" + NewLBL.Replace("'", "''") + "' where SPC_LID=" + st);
                        break;
                    case 0: //Alias
                    case 3:
                        //if (lCurSPCn.Text == MainMDI.VIDE) del_Spc(lCurSoln.Text, lCurSPCn.Text);
                        lCurALSn.Text = NewLBL;
                        string stSql = "SELECT PSM_Q_ALS.ALS_LID FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                            " WHERE (((PSM_Q_SOL.Sol_Name)='" + lCurSoln.Text + "') AND ((PSM_Q_SPCS.SPC_Name)='" + lCurSPCn.Text.Replace("'", "''") + "') AND ((PSM_Q_ALS.ALS_Name)='" + OldLbl.Replace("'", "''") + "'))";
                        stSql = MainMDI.Find_One_Field(stSql);
                        if (stSql != MainMDI.VIDE)
                        {
                            string myals = (NewLBL.Length > 0) ? NewLBL.Replace("'", "''") : "Toto";
                            MainMDI.ExecSql("UPDATE PSM_Q_ALS SET  [ALS_Name]='" + myals + "' where ALS_LID=" + stSql);
                        }
                        //lCurALSn.Text = NewLBL;
                        break;
                    case 2: //Solution
                    case 5:
                    case 4:
                        lCurSoln.Text = NewLBL;
                        MainMDI.ExecSql("UPDATE PSM_Q_SOL SET [Sol_Name]='" + NewLBL + "' where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + tvSol.SelectedNode.Text + "'");
                        break;
                }
                OldLabel = "";
            }
        }

        //END Prog. Methodes 

        private void cbSi_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void cbSe_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void cbSp_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void tvSol_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
        {
            if (e.Label != null)
            {
                //if (e.Label.IndexOf("\\", 0) > -1 || e.Label == "" || labelExist(e.Label))
                if (e.Label.IndexOf("\\", 0) > -1 || e.Label.Length < 2 || LBL_Exist(e.Label) || e.Label.IndexOf(" ") > -1)
                {
                    MessageBox.Show("INVALID new name    (Empty name, '\\' and spaces are not allowed .....    OR this Name already Exists !!!  ");
                    e.CancelEdit = true;
                }
                else if (OldLabel != "" && e.Label != OldLabel) Save_LBL(e.Label, OldLabel);
            }
        }

        private void lvQITEMS_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, System.EventArgs e)
        {

        }

        private void lvQITEMS_DoubleClick(object sender, System.EventArgs e)
        {
            //lvQITEMS.SelectedItems[0].Remove();
            //if (lvQITEMS.SelectedItems[0].SubItems[7].Text != "")
            //{
            if (lcurSol_Status.Text != "C" || MainMDI.User == "ede")
            {
                //picDwn.Visible = false;
                //picUp.Visible = false;
                if (MainMDI.User == "ede") tTV.Visible = true;
                lmodel.Visible = tTV.Visible;
                if (in_opera != 'C')
                {
                    //tdesc.Enabled = (!(lvQITEMS.SelectedItems[0].SubItems[10].Text == "ALRM" && lvQITEMS.SelectedItems[0].SubItems[12].Text != "" || lvQITEMS.SelectedItems[0].SubItems[10].Text != ""));			
                    //tdesc.Enabled = ((lvQITEMS.SelectedItems[0].SubItems[12].Text == "" && lvQITEMS.SelectedItems[0].SubItems[10].Text == ""));			
                    ndxSelect = lvQITEMS.SelectedItems[0].Index;
                    tqty.Text = lvQITEMS.SelectedItems[0].SubItems[3].Text;
                    tNB.Text = lvQITEMS.SelectedItems[0].SubItems[1].Text;
                    tmult.Text = lvQITEMS.SelectedItems[0].SubItems[4].Text;

                    tUprice.Text = (lvQITEMS.SelectedItems[0].SubItems[5].Text == "") ? "0" : lvQITEMS.SelectedItems[0].SubItems[5].Text;
                    tXchng.Text = "1"; //lvQITEMS.SelectedItems[0].SubItems[6].Text; group
                    tExt.Text = lvQITEMS.SelectedItems[0].SubItems[7].Text;

                    lmult_old.Text = tmult.Text;
                    lAmntOLD.Text = tExt.Text;

                    tSaleExt.Text = tExt.Text;
                    tAGExt.Text = tExt.Text;

                    tLT.Text = lvQITEMS.SelectedItems[0].SubItems[8].Text;
                    if (tLT.Text.Length < 5) tLT.Text = "04-06";
                    minLT.Text = tLT.Text.Substring(0, 2);
                    MaxLT.Text = tLT.Text.Substring(3, 2);
                    tdesc.Text = lvQITEMS.SelectedItems[0].SubItems[2].Text;
                    TOALS.Text = AlsTOT_orig.Text;
                    tTV.Text = lvQITEMS.SelectedItems[0].SubItems[12].Text;
                    //03062014
                    int ipos = tTV.Text.IndexOf("C_MODEL");
                    if (ipos > 0)
                    {
                        int ipos2 = tTV.Text.IndexOf(" ", ipos);
                        if (ipos2 > -1) lmodel.Text = tTV.Text.Substring(ipos, ipos2 - ipos).Replace("|", "=");
                        else lmodel.Text = tTV.Text.Substring(ipos, tTV.Text.Length - ipos - 1).Replace("|", "=");
                    }
                    else lmodel.Text = "";
                    //03062014

                    lALSmAmnt.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(AlsTOT_orig.Text) - Tools.Conv_Dbl(tExt.Text), MainMDI.Q_NB_DEC_AFF));
                    CB_Group.Text = lvQITEMS.SelectedItems[0].SubItems[6].Text; //group 
                    if (tqty.Text != "" || tmult.Text != "" || tUprice.Text != "")
                    {
                        lvQITEMS.SelectedItems[0].Checked = !lvQITEMS.SelectedItems[0].Checked;
                        grpChng.Visible = true;
                        grpCmnt.Visible = !grpChng.Visible;
                        tqty.Focus();
                        //tmrChng.Enabled = true;
                    }
                    else
                    {
                        tqty.Text = "";
                        tmult.Text = "";
                        tUprice.Text = "";
                    }
                    //tNB.Visible = (tNB.Text != "" && tNB.Text != " ");
                    //lnb.Visible = (tNB.Text != "" && tNB.Text != " ");
                    chkTBP.Checked = lvQITEMS.SelectedItems[0].Checked;
                    //lvQITEMS.Enabled = false;
                    //tvSol.Enabled = false;
                    Enable_ALL(false);
                    lvQITEMS.SelectedItems[0].BackColor = Color.Aqua;
                }
            }
            else MessageBox.Show("This Revision cannot be Modified !!!");
        }

        private void modif_All_Items()
        {
            if (lcurSol_Status.Text != "C")
            {
                if (in_opera != 'C')
                {
                    tAqty.Text = MainMDI.VIDE;
                    tAmult.Text = MainMDI.VIDE;
                    tAup.Text = MainMDI.VIDE;
                    cbCategory.Text = MainMDI.VIDE;
                    //lALT.Text = "04-06";
                    //minLT.Text = lALT.Text.Substring(0, 2);
                    //MaxLT.Text = lALT.Text.Substring(3, 2);
                    Enable_ALL(false);
                    grpAmodif.Visible = true;
                }
            }
            else MessageBox.Show("No item of this Revision can be Modified !!!");
        }

        /*
		private void lvQITEMS_DoubleClickOLD(object sender, System.EventArgs e)
		{
			//lvQITEMS.SelectedItems[0].Remove();
			if (lvQITEMS.SelectedItems[0].SubItems[7].Text != "" && lvQITEMS.SelectedItems[0].SubItems[12].Text == "")
			{
				tqty.Text = lvQITEMS.SelectedItems[0].SubItems[3].Text;
				tmult.Text = lvQITEMS.SelectedItems[0].SubItems[4].Text;
				tUprice.Text = (lvQITEMS.SelectedItems[0].SubItems[5].Text == "") ? "0" : lvQITEMS.SelectedItems[0].SubItems[5].Text;
				tXchng.Text = lvQITEMS.SelectedItems[0].SubItems[6].Text;
				tExt.Text = lvQITEMS.SelectedItems[0].SubItems[7].Text;
				tLT.Text = lvQITEMS.SelectedItems[0].SubItems[8].Text;
				tdesc.Text = lvQITEMS.SelectedItems[0].SubItems[2].Text;
				if (tqty.Text != "" || tmult.Text != "" || tUprice.Text != "")
				{
					lvQITEMS.SelectedItems[0].Checked = !lvQITEMS.SelectedItems[0].Checked;
					grpChng.Visible = true;
					grpCmnt.Visible = !grpChng.Visible;
					tqty.Focus();
					tmrChng.Enabled =true;
				}
				else
				{
					tqty.Text = "";
					tmult.Text = "";
					tUprice.Text = "";
				}
			}
		}
        */

        private void groupBox3_Enter(object sender, System.EventArgs e)
        {

        }

        private void cbSS_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void cbCQA_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void cbCPA_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void cbCSA_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void cbCIA_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void btnAP_Click(object sender, System.EventArgs e)
        {

        }

        private void btnAS_Click(object sender, System.EventArgs e)
        {

        }

        private void btnAI_Click(object sender, System.EventArgs e)
        {

        }

        private void btnNewID_Click(object sender, System.EventArgs e)
        {
            //MessageBox.Show(Imp_IQID);
            if (MainMDI.ALWD_USR("QT_SV", true))
            {
                if (tQuoteID.Text == "")
                {
                    if (MainMDI.Find_One_Field("select NewQ from PSM_SYSETUP ") == "1")
                    {
                        gifCounter.Visible = true;
                        this.Refresh();
                        init_Curr_ALS();
                        long Res = fill_QID();
                        if (Res == 0 || Res == -1) this.Close();
                        else lCurr_opera.Text = "N";
                        gifCounter.Visible = false;
                    }
                    else MessageBox.Show("New Quotes are impossible");
                }
            }
        }

        private void mnuRepair_Click(object sender, System.EventArgs e)
        {

        }

        private void Rev_Click(object sender, System.EventArgs e)
        {
            if (MainMDI.profile != 'R') Sol_Rep_SPP('V');
        }

        private void RevMnu_Popup(object sender, System.EventArgs e)
        {

        }

        private void lvQITEMS_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //picDwn.Visible = true;
            //picUp.Visible = true;
            MNoCut.Enabled = (lvQITEMS.SelectedItems.Count > 0);
            mnOcopy.Enabled = (lvQITEMS.SelectedItems.Count > 0);
            MNocopyTxt.Enabled = (lvQITEMS.SelectedItems.Count > 0);
        }

        //if (lvQITEMS.SelectedItems[0].SubItems[7].Text != "")
        //{

        private void btnOKchng_Click(object sender, System.EventArgs e)
        {
            bool conti_ok = true;
            if (!tmult.ReadOnly && tmult.Text == "1")
            {
                conti_ok = false;
                MessageBox.Show("multiplier ERROR....must be:     multiplier >1   OR  multiplier <1    ");
            }
            if (conti_ok)
            {
                string msg = "";
                if (lcurSol_Status.Text != "C") //never update converted quote because details are deleted and created !!!
                {
                    if (tNB.Text == " " || Tools.Conv_Dbl(tNB.Text) > 0)
                    {
                        tExt.ReadOnly = true;
                        tExt.Text = Tools.Conv_Dbl(tExt.Text).ToString();

                        //added 10/08/2015

                        //if (tmult.Text < lmult_old.Text);
                        if (Tools.Conv_Dbl(tExt.Text) < Tools.Conv_Dbl(lAmntOLD.Text))
                        {
                            if (MainMDI.Confirm("Want change Item Category since Price has been mofifed ?"))
                            {
                                if (CB_Group.Text == "A") { CB_Group.Text = "B"; msg = " FROM 'A' to 'B' "; }
                                if (CB_Group.Text == "C") { CB_Group.Text = "D"; msg = " FROM 'C' to 'D' "; }
                                if (msg.Length > 1) MessageBox.Show("Item Category has been changed: " + msg);
                            }
                        }
                        //added 10/08/2015

                        if (maj_LT())
                        {
                            //if ((tExt.Text != "0" && tExt.Text != "") || lvQITEMS.Items[ndxSelect].SubItems[7].Text == "")
                            //{
                                //if (Tools.Conv_Dbl(lvQITEMS.Items[ndxSelect].SubItems[7].Text) != 0)
                                    if (Tools.Conv_Dbl(tExt.Text) != 0)
                                    {
                                        //if (CB_Group.Text == "") CB_Group.Text = "A";
                                        lvQITEMS.Items[ndxSelect].SubItems[3].Text = tqty.Text;
                                        lvQITEMS.Items[ndxSelect].SubItems[6].Text = (CB_Group.Text == "") ? "A" : CB_Group.Text; //tXchng.Text;
                                        lvQITEMS.Items[ndxSelect].SubItems[4].Text = tmult.Text;
                                    }
                                    else
                                    {
                                        lvQITEMS.Items[ndxSelect].SubItems[3].Text = (tqty.Text != "") ? tqty.Text : "0";
                                        lvQITEMS.Items[ndxSelect].SubItems[6].Text = "A"; //CB_Group.Text;
                                        lvQITEMS.Items[ndxSelect].SubItems[4].Text = "0";
                                    }
                                if (tNB.Visible) lvQITEMS.Items[ndxSelect].SubItems[1].Text = (tNB.Text == "") ? " " : tNB.Text;
                                //added to avoid blank DESC
                                lvQITEMS.Items[ndxSelect].SubItems[2].Text = (tdesc.Text.Length > 0) ? tdesc.Text : "   ";
                                if (tUprice.Text != "0") lvQITEMS.Items[ndxSelect].SubItems[5].Text = tUprice.Text;
                                lvQITEMS.Items[ndxSelect].SubItems[7].Text = MainMDI.A00(tExt.Text);
                                if (tExt.Text != "") lvQITEMS.Items[ndxSelect].SubItems[8].Text = tLT.Text;
                                else lvQITEMS.Items[ndxSelect].SubItems[8].Text = "";
                                lvQITEMS.Items[ndxSelect].Checked = chkTBP.Checked;
                                Tosave = true;
                                if (lvQITEMS.Items[ndxSelect].ForeColor == Color.Red && tExt.Text != "0" && tExt.Text != " " && tExt.Text != "") lvQITEMS.Items[ndxSelect].ForeColor = Color.Black;
                                Ref_ALSTOT('A'); //????
                                ChngCancel_Click(sender, e);
                                Enable_ALL(true);
                                //lvQITEMS.Enabled = true;
                                //tvSol.Enabled = true;
                            //}
                            //else MessageBox.Show("Sell Price is Invalid (Extension) !!!!!");
                        }
                        lvQITEMS.SelectedItems[0].BackColor = (tNB.Text == "" || tNB.Text == " ") ? Color.WhiteSmoke : Color.Salmon;
                    }
                    else MessageBox.Show("ERROR in ITEM #: only Numeric values !!!! ......");
                }
                else MessageBox.Show("Save Denied....(converted Rev.)....");
            }
        }

        /*
        private void btnOKchng_ClickOld(object sender, System.EventArgs e)
        {
            if (maj_LT())
            {
                if ((tExt.Text != "0" && tExt.Text != "") || lvQITEMS.SelectedItems[0].SubItems[7].Text == "")
                {
                    if (lvQITEMS.SelectedItems[0].SubItems[7].Text != "")
                    {
                        lvQITEMS.SelectedItems[0].SubItems[3].Text = tqty.Text;
                        lvQITEMS.SelectedItems[0].SubItems[6].Text = tXchng.Text;
                        lvQITEMS.SelectedItems[0].SubItems[4].Text = tmult.Text;
                    }
                    lvQITEMS.SelectedItems[0].SubItems[2].Text = tdesc.Text;
                    if (tUprice.Text != "0") lvQITEMS.SelectedItems[0].SubItems[5].Text = tUprice.Text;
                    lvQITEMS.SelectedItems[0].SubItems[7].Text = tExt.Text;
                    if (tExt.Text != "") lvQITEMS.SelectedItems[0].SubItems[8].Text = tLT.Text;
                    else lvQITEMS.SelectedItems[0].SubItems[8].Text = "";
                    Tosave = true;
                    Ref_ALSTOT('A');
                    ChngCancel_Click(sender, e);
                }
                else MessageBox.Show("Sell Price is Invalid (Extension) !!!!!");
            }
        }

        private void btnOKchng_Clickold(object sender, System.EventArgs e)
        {
            if (tExt.Text != "0" && tExt.Text != "")
            {
                lvQITEMS.SelectedItems[0].SubItems[3].Text = tqty.Text;
                lvQITEMS.SelectedItems[0].SubItems[2].Text = tdesc.Text;
                lvQITEMS.SelectedItems[0].SubItems[4].Text = tmult.Text;
                lvQITEMS.SelectedItems[0].SubItems[5].Text = tUprice.Text;
                lvQITEMS.SelectedItems[0].SubItems[6].Text = tXchng.Text;
                lvQITEMS.SelectedItems[0].SubItems[7].Text = tExt.Text;
                lvQITEMS.SelectedItems[0].SubItems[8].Text = tLT.Text;
                Tosave = true;
                Ref_ALSTOT('A');
                ChngCancel_Click(sender, e);
            }
            else MessageBox.Show ("Sell Price is Invalid (Extension) !!!!!");
        }
        */

        private void ChngCancel_Click(object sender, System.EventArgs e)
        {
            grpChng.Visible = false;
            tqty.Text = "";
            tmult.Text = "";
            tUprice.Text = "";
            grpCmnt.Visible = !grpChng.Visible;
            Enable_ALL(true);
            lvQITEMS.SelectedItems[0].BackColor = (tNB.Text == "" || tNB.Text == " ") ? Color.WhiteSmoke : Color.Salmon;
        }

        private void tmrChng_Tick(object sender, System.EventArgs e)
        {

        }

        private void cbSi_SelectedIndexChanged_1(object sender, System.EventArgs e)
        {

        }

        private void groupBox8_Enter(object sender, System.EventArgs e)
        {

        }

        private void tvSol_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            SAVE_CHANGE_ALS();
        }

        private void SAVE_CHANGE_ALS()
        {
            if (MainMDI.PermT_user("QS"))
            {
                if (Tosave)
                {
                    DialogResult dr = MessageBox.Show("Save Changes ? : ", "Saving....", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dr == DialogResult.Yes)
                    {
                        Save_Q_ALL_Details();
                        //Maj_AlsTOT();
                    }
                    Tosave = false;
                }
            }
        }

        private void Maj_AlsTOT()
        {
            if (lcurrALSLID.Text != "0")
            {
                MainMDI.ExecSql("UPDATE PSM_Q_ALS SET [Tot]='" + AlsTOT_orig.Text + "' where ALS_LID=" + lcurrALSLID.Text);
                //AlterTOT.Text = MainMDI.A00(MainMDI.SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
                AlterTOT.Text = MainMDI.Curr_FRMT(MainMDI.SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
            }
        }

        private void menuItem4_Click(object sender, System.EventArgs e)
        {
            Add_option();
        }

        private void menuItem5_Click(object sender, System.EventArgs e)
        {
            Add_CBR('C');
        }

        private void menuItem2_Click(object sender, System.EventArgs e)
        {
            Add_CBR('B');
        }

        private void menuItem7_Click(object sender, System.EventArgs e)
        {
            Add_CBR('R');
        }

        private void lvQITEMS_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            //MessageBox.Show("ITEMW: " + lvQITEMS.Width + " thiW= " + this.Width + "\n" + "   ITMH= " + lvQITEMS.Height + "ThisH= " + this.Height);

            //MessageBox.Show("grpTab H: " + gbxSol.Height + " thiH= " + this.Height + "\n" + "   ITMH= " + lvQITEMS.Height + "ThisH= " + this.Height);
            //tvSol.CheckBoxes = true;
            //tvSol.RecreatingHandle = true;
            //grpOrder.Height = this.Height - 202;
            //tvSol.Refresh();
        }

        private void gbxSol_Enter(object sender, System.EventArgs e)
        {

        }

        private void lvQITEMS_SelectedIndexChanged_2(object sender, System.EventArgs e)
        {

        }

        private void menuItem8_Click(object sender, System.EventArgs e)
        {
            Add_CBR('c');
        }

        private void tvSol_BeforeLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
        {
            OldLabel = e.Node.Text;
            if (e.Node.ImageIndex == 2 || lcurSol_Status.Text == "C") e.CancelEdit = true;
            //MessageBox.Show("Lbl= " + e.Label + " nod= " + OldLabel);
        }

        private void lvQITEMS_ColumnClick_1(object sender, System.Windows.Forms.ColumnClickEventArgs e)
        {
            //lvQITEMS.Columns[0].Width = 35;
        }

        private void btnImpChrgPrices_Click_1(object sender, System.EventArgs e)
        {

        }

        private void tmult_TextChanged(object sender, System.EventArgs e)
        {
            //Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(lMLTPLY.Text), Charger.NB_DEC_AFF)))
            cal_SellExt();
        }

        private void cal_SellExt()
        {
            if (tXchng.Text == "") tXchng.Text = tXRATE.Text;
            if (tUprice.Text != "" && tqty.Text != "" && tmult.Text != "") tExt.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tmult.Text) * Tools.Conv_Dbl(tUprice.Text) * Tools.Conv_Dbl(tqty.Text) * Tools.Conv_Dbl(tXchng.Text), MainMDI.Q_NB_DEC_AFF));
        }
        private void tqty_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyDBL(e.KeyChar);
        }

        private void tmult_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyDBL(e.KeyChar);
        }

        private void tUprice_TextChanged(object sender, System.EventArgs e)
        {
            cal_SellExt();
        }

        private void tUprice_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = (Tools.OnlyDBL(e.KeyChar) || e.KeyChar == 45); //for Sign
        }

        private void tXchng_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyDBL(e.KeyChar);
        }

        private void tLT_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyDBL(e.KeyChar);
        }

        private void tXRATE_TextChanged(object sender, System.EventArgs e)
        {
            if (tXRATE.Text == "") tXRATE.Text = MainMDI.A00("1");
        }

        private void tqty_TextChanged(object sender, System.EventArgs e)
        {
            cal_SellExt();
        }

        private void tXRATE_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyDBL(e.KeyChar);
        }

        private void tXchng_TextChanged(object sender, System.EventArgs e)
        {
            cal_SellExt();
        }

        private void tCust_Mult_TextChanged(object sender, System.EventArgs e)
        {
            //loM.Visible = STDMultp.Text != tCust_Mult.Text;
            //STDMultp.Visible = STDMultp.Text != tCust_Mult.Text;
        }

        private void STDMultp_TextChanged(object sender, System.EventArgs e)
        {
            //loM.Visible = STDMultp.Text != tCust_Mult.Text;
            //STDMultp.Visible = STDMultp.Text != tCust_Mult.Text;
        }

        private void btnApply_Click(object sender, System.EventArgs e)
        {
            btnApply.Text = (btnApply.Text == "CAN $") ? "US $" : "CAN $";
            ////apply USD Xrate to All Quote Items
            //double dtot = 0;
            //for (int i = 0; i < lvQITEMS.Items.Count; i++)
            //{				
                //if (lvQITEMS.Items[i].SubItems[3].Text != "" && lvQITEMS.Items[i].SubItems[4].Text != "" && lvQITEMS.Items[i].SubItems[5].Text != "")
                //{
                    //lvQITEMS.Items[i].SubItems[6].Text = tXRATE.Text;
                    //double dext = Math.Round(Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[3].Text) * Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[4].Text) * Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[5].Text) * Tools.Conv_Dbl(tXRATE.Text), MainMDI.NB_DEC_AFF);
                    //lvQITEMS.Items[i].SubItems[7].Text = Convert.ToString(dext);
                    //dtot += dext;
                //}
            //}
            //AlsTOT.Text = Convert.ToString(dtot);
        }

        private void P_AlsTot(string mt)
        {
            if (mt != "" && AlsTOT.Text != "") AlsTOT.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(mt) + Tools.Conv_Dbl(AlsTOT.Text), MainMDI.Q_NB_DEC_AFF));
        }

        private void M_AlsTot(string mt)
        {
            if (mt != "" && AlsTOT.Text != "") AlsTOT.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(AlsTOT.Text) - Tools.Conv_Dbl(mt), MainMDI.Q_NB_DEC_AFF));
        }

        private void Ref_ALSTOTOLD()
        {
            double dtot = 0;
            for (int i = 0; i < lvQITEMS.Items.Count; i++)
            {
                //if (lvQITEMS.Items[i].SubItems.Count == 9)
                if (lvQITEMS.Items[i].SubItems[7].Text != "") dtot = dtot + Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[7].Text);
            }
            lALSTOT.Text = lCurALSn.Text + ": ";
            AlsTOT.Text = Convert.ToString(Math.Round(dtot, MainMDI.Q_NB_DEC_AFF));
        }

        private void btnM_Click(object sender, System.EventArgs e)
        {
            tvSol.Width -= 40;
        }

        private void fill_NbDef()
        {
            /*
            int nbI = 0;
            int nb = 1;
            int Lin = 0;
            for (int i = 0; i < lvQITEMS.Items.Count; i++)
            {
                if (lvQITEMS.Items[i].SubItems[1].Text == "") nb++;
                else
                {
                    arr_nbDef[lin, 0] = i;
                    arr_nbDef[lin, 1] = nb;
                    nb = 0;
                    lin = i;
                }
            */
        }

        private void apply_OGA()
        {
            if (lvQITEMS.Items.Count > 0)
            {
                int nb = 0;
                int lin = 0;
                double dtot = 0;
                for (int i = 0; i < lvQITEMS.Items.Count; i++)
                {
                    if (lvQITEMS.Items[i].SubItems[7].Text != "") dtot = dtot + Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[7].Text);
                    if (lvQITEMS.Items[i].SubItems[1].Text == " " || (lvQITEMS.Items[i].SubItems[1].Text == "." && lvQITEMS.Items[i].BackColor == Color.WhiteSmoke)) nb++; //item # is always == " " not ""
                    else
                    {
                        if (i > 0) //&& lvQITEMS.Items[i].BackColor ==)
                        {
                            lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
                            lin = i; //if (i == lvQITEMS.Items.Count - 1) lvQITEMS.Items[lin].SubItems[9].Text = "0";
                            nb = 0;
                            if (Tools.Conv_Dbl(lvQITEMS.Items[lin].SubItems[8].Text) > Tools.Conv_Dbl(lHiDelv.Text)) lHiDelv.Text = lvQITEMS.Items[lin].SubItems[8].Text;
                        }
                    }
                }
                lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
                lALSTOT.Text = lCurALSn.Text + ": "; //" TOTAL :";
                //lALSnb.Text = lCurALSn.Text + " #:";
                AlsTOT.Text = MainMDI.A00(Convert.ToString(Math.Round(dtot, MainMDI.Q_NB_DEC_AFF)));
                lAlterTOT.Text = lCurSPCn.Text; //+ " TOTAL :";
                //string tt = SPEC_TOT(lcur
                //if (OldAlsTot.Text != "")
                //{
                    //double res_ALt_Bal = Tools.Conv_Dbl(AlterTOT.Text) + dtot - Tools.Conv_Dbl(OldAlsTot.Text);
                    //AlterTOT.Text = A00(Convert.ToString(Math.Round(res_ALt_Bal, MainMDI.NB_DEC_AFF)));
                //}
            }
            ref_PXAG_Price('O');
            MNoPaste.Enabled = (MainMDI.arr_clpB[0, 1] != "~");
            menuItem9.Enabled = MNoPaste.Enabled;
        }

        private void Ref_ALSTOT(char _op)
        {
            lHiDelv.Text = "4";
            if (lvQITEMS.Items.Count > 0)
            {
                int nb = 0;
                int lin = 0;
                double dtot = 0;
                for (int i = 0; i < lvQITEMS.Items.Count; i++)
                {
                    if (lvQITEMS.Items[i].SubItems[7].Text != "") dtot = dtot + Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[7].Text);
                    if (lvQITEMS.Items[i].SubItems[1].Text == " " || (lvQITEMS.Items[i].SubItems[1].Text == "." && lvQITEMS.Items[i].BackColor == Color.WhiteSmoke)) nb++; //item # is always == " " not ""
                    else
                    {
                        if (i > 0) //&& lvQITEMS.Items[i].BackColor ==)
                        {
                            lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
                            lin = i; //if (i == lvQITEMS.Items.Count - 1) lvQITEMS.Items[lin].SubItems[9].Text = "0";
                            nb = 0;
                            if (Tools.Conv_Dbl(lvQITEMS.Items[lin].SubItems[8].Text) > Tools.Conv_Dbl(lHiDelv.Text)) lHiDelv.Text = lvQITEMS.Items[lin].SubItems[8].Text;
                        }
                    }
                }
                lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
                lALSTOT.Text = lCurALSn.Text + ": "; //" TOTAL :";
                //lALSnb.Text = lCurALSn.Text + " #:";
                AlsTOT_orig.Text = MainMDI.A00(Convert.ToString(Math.Round(dtot, MainMDI.Q_NB_DEC_AFF)));
                lAlterTOT.Text = lCurSPCn.Text; //+ " TOTAL :";
            }
            ref_PXAG_Price(_op);
            MNoPaste.Enabled = (MainMDI.arr_clpB[0, 1] != "~");
            menuItem9.Enabled = MNoPaste.Enabled;
        }

        /*
        private void Ref_ALSTOT_OK()
        {
            lHiDelv.Text = "4";
            if (lvQITEMS.Items.Count > 0)
            {
                int nb = 0;
                int lin = 0;
                double dtot = 0;
                for (int i = 0; i < lvQITEMS.Items.Count; i++)
                {
                    if (lvQITEMS.Items[i].SubItems[7].Text != "") dtot = dtot + Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[7].Text);
                    if (lvQITEMS.Items[i].SubItems[1].Text == " " || (lvQITEMS.Items[i].SubItems[1].Text == "." && lvQITEMS.Items[i].BackColor == Color.WhiteSmoke)) nb++; //item # is always == " " not ""
                    else
                    {
                        if (i > 0) //&& lvQITEMS.Items[i].BackColor ==)
                        { 
                            lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
                            lin = i; //if (i == lvQITEMS.Items.Count - 1) lvQITEMS.Items[lin].SubItems[9].Text = "0";
                            nb = 0;
                            if (Tools.Conv_Dbl(lvQITEMS.Items[lin].SubItems[8].Text) > Tools.Conv_Dbl(lHiDelv.Text)) lHiDelv.Text = lvQITEMS.Items[lin].SubItems[8].Text;
                        }
                    }
                }
                lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
                lALSTOT.Text = lCurALSn.Text + ": "; //" TOTAL :";
                //lALSnb.Text = lCurALSn.Text + " #:";
                AlsTOT_orig.Text = MainMDI.A00(Convert.ToString(Math.Round(dtot, MainMDI.Q_NB_DEC_AFF)));
                lAlterTOT.Text = lCurSPCn.Text; //+ " TOTAL :";
                //string tt = SPEC_TOT(lcur
                //if (OldAlsTot.Text != "")
                //{
                    //double res_ALt_Bal = Tools.Conv_Dbl(AlterTOT.Text) + dtot - Tools.Conv_Dbl(OldAlsTot.Text);
                    //AlterTOT.Text = A00(Convert.ToString(Math.Round(res_ALt_Bal, MainMDI.NB_DEC_AFF)));
                //}
            }
            //if (Tools.Conv_Dbl(tPxPrice.Text) < Tools.Conv_Dbl(AlsTOT.Text)) tPxPrice.Text = AlsTOT.Text;
            //if (Tools.Conv_Dbl(tAGprice.Text) < Tools.Conv_Dbl(tPxPrice.Text)) tAGprice.Text = tPxPrice.Text;
            //tPxPrice.Text = MainMDI.A00(tPxPrice.Text);
            //tAGprice.Text = MainMDI.A00(tAGprice.Text);

            ref_PXAG_Price();
            MNoPaste.Enabled = (MainMDI.arr_clpB[0, 1] != "~");
            menuItem9.Enabled = MNoPaste.Enabled;
        }
        */

        private void maj_Rank_ALS()
        {
            /*
            if (lvQITEMS.Items.Count > 0)
            {
                int nb = 1;
                int lin = 0;
                double dtot = 0;
			
                for (int i = 0; i < lvQITEMS.Items.Count; i++)
                {
                    if (lvQITEMS.Items[i].SubItems[1].Text != " ")
                    {
                        if (lvQITEMS.Items[i].SubItems[1].Text.IndexOf(".", 0) == -1 
                            nb++; //item # is always == " " not ""
                    else
                    {
                        if (i > 0)
                        { 
                            lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
                            lin = i; //if (i == lvQITEMS.Items.Count - 1) lvQITEMS.Items[lin].SubItems[9].Text = "0";
                            nb = 0;
                        }
                    }
                }
                lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
                lALSTOT.Text = lCurALSn.Text + " TOTAL :";
                AlsTOT.Text = Convert.ToString(Math.Round(dtot, MainMDI.NB_DEC_AFF));
            }
            */
        }

        //Del from LV and Save current image with current Ranks !!!!
        private void del_Als_IO(int ndx)
        {
            int ndell = 0;
            int nbDef = (lvQITEMS.Items[ndx].SubItems[9].Text == "") ? 0 : Convert.ToInt32(lvQITEMS.Items[ndx].SubItems[9].Text);
            for (int j = ndx + nbDef; j >= ndx; j--)
            {
                if (lvQITEMS.Items[j].BackColor == Color.Salmon) ItemCount--;
                lvQITEMS.Items[j].Remove();
                ndell++;
            }
            Ref_ALSTOT('D');
            if (lvQITEMS.Items.Count == 0) del_Als(lCurSoln.Text, lCurSPCn.Text, lCurALSn.Text);
            else if (ndell > 0)
            {
                Save_Q_ALL_Details();
                Maj_AlsTOT();
                //AlterTOT.Text = A00(SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
            }
        }

        private void del_Als_IOold(int ndx)
        {
            //MessageBox.Show(lvQITEMS.SelectedItems[0].Index.ToString());
            //for (int j = lvQITEMS.SelectedItems.Count - 1; j > -1; j--)
            //{
                //string st = MainMDI.Find_One_Field("SELECT  PSM_Q_Details.Detail_LID " + 
                    //" FROM PSM_Q_IGen INNER JOIN ((PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID) ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid " +
                    //" WHERE PSM_Q_ALS.ALS_Name='" + lCurALSn.Text + "' AND PSM_Q_Details.Desc='" + lvQITEMS.SelectedItems[j].SubItems[2].Text + "' AND PSM_Q_Details.Rnk=" + j);
                //MainMDI.ExecSql("delete * FROM PSM_Q_Details WHERE Detail_LID=" + st);
                //lvQITEMS.SelectedItems[j].Remove();

            int ndell = 0;
            int nbDef = (lvQITEMS.Items[ndx].SubItems[9].Text == "") ? 0 : Convert.ToInt32(lvQITEMS.Items[ndx].SubItems[9].Text);
            for (int j = ndx + nbDef; j >= ndx; j--)
            {
                string st = MainMDI.Find_One_Field("SELECT  PSM_Q_Details.Detail_LID " +
                    " FROM PSM_Q_IGen INNER JOIN ((PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID) ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid " +
                    " WHERE PSM_Q_ALS.ALS_Name='" + lCurALSn.Text.Replace("'", "''") + "' AND PSM_Q_Details.[Desc]='" + lvQITEMS.Items[j].SubItems[2].Text + "' AND PSM_Q_Details.Rnk =" + (j + ndell));
                if (st != MainMDI.VIDE)
                {
                    MainMDI.ExecSql("delete   PSM_Q_Details WHERE Detail_LID=" + st);
                    lvQITEMS.Items[j].Remove(); ndell++;
                }
                else MessageBox.Show(" Line not found !!! or BAD SQL: ");
            }
        }

        /*
        private void Duplica_All_Sol(long NewIQID, long Orig_IQID)
        {
            bool alsAdded = false;
            int nbSol = 1, nbSpc = 1, nbAls = 1;
            long r_Spcid = 0, r_SolId = 0, r_alsId = 0;
            string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* " +
                " FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " WHERE (PSM_Q_IGen.i_Quoteid=" + Orig_IQID + "') ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
			
            SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string Osol = "", Nsol = "", Ospc = "", Nspc = "", Nals = "", Oals = "";
            while (Oreadr.Read())
            {
                alsAdded = false;
                if (Nsol == "") Nsol = Oreadr["Sol_Name"].ToString();
                Nspc = Oreadr["SPC_Name"].ToString();
                Nals = Oreadr["ALS_Name"].ToString();
                if (Osol != Nsol)	
                { 
                    //nbSol = tvSol.Nodes.Count;
                    Nsol = Oreadr["Sol_Name"].ToString();
                    r_SolId = Save_SOL(NewIQID, Nsol, nbSol.ToString(), Oreadr["img"].ToString());
                    //addNode_Sol(Nsol, Oreadr["img"].ToString());
                    Osol = Nsol;
                }
                if (Ospc != Nspc)
                { 
                    if (tvSol.Nodes[nbSol].Nodes.Count == 0) //
                    {
                        nbSpc = 0;
                        nbAls = 0;
                    }
                    else
                    {
                        nbSpc = tvSol.Nodes[nbSol].Nodes.Count; //
                        nbAls = tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count; //
                    }
                    r_Spcid = Save_SPEC(r_SolId, Nspc.ToString(), nbSpc.ToString());
                    //addNode_Spc(Nspc, nbSol, nbSpc, Nals);
                    alsAdded = true;
                    Ospc = Nspc;
                }
                if (Oals != Nals || alsAdded)
                { 	
                    r_alsId = Save_ALS(r_Spcid, Nals, nbAls.ToString());
                    if (!alsAdded)
                    {	
                        //addNode_Als(Nals, nbSol, nbSpc);
                        nbAls = (nbSpc == 0) ? 0 : tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count;
                    } 
                    Oals = Nals;
                }
                double ddUP = (Oreadr["Uprice"].ToString().Length < 2) ? 0 : Tools.Conv_Dbl(Oreadr["Uprice"].ToString());
                int LA = (Oreadr["LeadTime"].ToString() == "") ? 0 : Convert.ToInt32(Oreadr["LeadTime"].ToString());
                string stSql2 = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " + 
                    " [Desc],[Qty],[Mult], [Uprice],[LeadTime],[Rnk] ) VALUES ('" +
                    r_alsId.ToString() + "', '" +
                    Oreadr["Aff_ID"].ToString() + "', '" +
                    Oreadr["Desc"].ToString() + "', '" +
                    Tools.Conv_Dbl(Oreadr["Qty"].ToString()) + "', '" +
                    Tools.Conv_Dbl(Oreadr["Xch_Mult"].ToString()) + "', '" +
                    ddUP.ToString() + "', '" +
                    LA.ToString() + "', '" +
                    Oreadr["PSM_Q_Details.Rnk"].ToString() + "')";
                if (!MainMDI.ExecSql(stSql2)) MessageBox.Show("Error Details Duplication....");
            }
            tvSol.Select();
        }

        private bool Save_Dup_IGen()
        {
            string stSql = "INSERT INTO PSM_Q_IGen ([Quote_ID],[CPNY_ID],[Employ_ID], " + 
                " [ProjectName],[Opndate],[Clsdate],[Contact_ID],[Cust_Mult],  " + 
                " [Term_ID],[Via_ID],[IncoTerm_ID], " + 
                " [SI],[SO],[SE],[SP],[SS], " + 
                " [AD],[AI],[AE],[AP],[AS], " + 
                " [QA],[SA],[PA],[IA] , " + 
                " [Lang]," +
                " [DEL]," +
                " [Cmnt]) VALUES ('" +
                tQuoteID.Text + "', '" +
                lcpnyID.Text + "', '" +
                lEmp_ID.Text + "', '" +
                tProjNAME.Text + "', '" +
                tOpendate.Text + "', '" +
                "11/11/11" + "', '" +
                lContact_ID.Text + "', '" +
                tCust_Mult.Text + "', '" +
                lTerm_ID.Text + "', '" +
                lVia_ID.Text + "', '" +
                lIncoT_ID.Text + "', '" +
                lSi.Text + "', '" +
                lSO.Text + "', '" +
                lSE.Text + "', '" +
                lSP.Text + "', '" +
                lSS.Text + "', '" +
                lAD.Text + "', '" +
                lAI.Text + "', '" +
                lAE.Text + "', '" +
                lAP.Text + "', '" +
                lAS.Text + "', '" +
                lQA.Text + "', '" +
                lSA.Text + "', '" +
                lPA.Text + "', '" +
                lIA.Text + "', '" +
                lLang.Text + "', '" +
                "N" + "', '" +
                tGCmnt.Text + "')";
            t1 = MainMDI.ExecSql(stSql);
            string stId = MainMDI.Find_One_Field("select I_Quoteid from PSM_Q_IGen where Quote_ID=" + tQuoteID.Text + " AND CPNY_ID=" + lcpnyID.Text);
            //MessageBox.Show("ID= " + MainMDI.stXP + "     foundID= " + stId);
            if (stId != MainMDI.VIDE) lCurrIQID.Text = stId;
        }
        */

        private void AlS_Wizard()
        {
            tvSol.Nodes.Add("RV-" + MainMDI.A00(0, 2));
            tvSol.Nodes[0].ImageIndex = 2;
            tvSol.Nodes[0].SelectedImageIndex = 2;
            tvSol.Nodes[0].Nodes.Add("!Alt#1");
            tvSol.Nodes[0].Nodes[0].SelectedImageIndex = 1;
            tvSol.Nodes[0].Nodes[0].ImageIndex = 1;

            //tvSol.Nodes[0].Nodes[0].Nodes.Add("!Alias#0");	
            tvSol.Nodes[0].Nodes[0].Nodes.Add(MainMDI.arr_EFSdict[38, MainMDI.Lang] + "#1"); //to use system | systéme instead of alias

            tvSol.Nodes[0].Nodes[0].Nodes[0].SelectedImageIndex = 0;
            tvSol.Nodes[0].Nodes[0].Nodes[0].ImageIndex = 0;
        }

        private void grpChng_Enter(object sender, System.EventArgs e)
        {

        }

        private void button4_Click(object sender, System.EventArgs e)
        {

        }

        private void groupBox5_Enter(object sender, System.EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void label51_Click(object sender, System.EventArgs e)
        {

        }

        private void Quote_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (in_opera != 'C') e.Cancel = true;
            //MessageBox.Show("cancel= " + e.Cancel);
        }

        private void button5_Click(object sender, System.EventArgs e)
        {
            if (tQuoteID.Text != "") MainMDI.flag_QRID('Q', 'u', 0, Convert.ToUInt32(tQuoteID.Text));
            this.Hide();
        }

        private void toolBar1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            //MessageBox.Show(e.Button.ToString());
            //toolBar1.Buttons[18].ImageIndex = 27;
        }

        private void toolBar1_MouseLeave(object sender, System.EventArgs e)
        {
            //toolBar1.Buttons[18].ImageIndex = 28;
        }

        private void btnImpChrgPrices_Click_2(object sender, System.EventArgs e)
        {

        }

        private void button5_Click_1(object sender, System.EventArgs e)
        {
            button5.Visible = false;
            button6.Visible = false;
            grpPB.Visible = false;
        }

        private void button6_Click(object sender, System.EventArgs e)
        {
            button5_Click_1(sender, e);
            MainMDI.OpenKnownFile(lOFName.Text);
        }

        private void lPhone_Click(object sender, System.EventArgs e)
        {

        }

        private void cbAI_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void cbAE_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void cbAP_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void cbADD_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void tvSol_DoubleClick(object sender, System.EventArgs e)
        {
            //tvSol.SelectedNode.BackColor = Color.YellowGreen;
        }

        private void tvSol_BeforeCheck(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
        {
            //MessageBox.Show("el= " + e.Node.Text + "  et= " + e.Node.Checked);
            Chkable = true;
            if (e.Node.Checked && !btnUnchk) { e.Cancel = true; Chkable = false; }
        }

        private void fill_cbTerrito()
        {
            cb_Territo.Items.Clear();
            string stSql = "select Terito_ABR , Terito_LID from PSM_C_ComTERITORY order by Rnk ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                MainMDI.add_CB_itm(cb_Territo, Oreadr[0].ToString(), Oreadr[1].ToString());
            }
            //cbSerItems.BringToFront();
            cb_Territo.SelectedIndex = 0;
            OConn.Close();
        }

        private void tvSol_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
        {
            //MessageBox.Show("AFTER.....el= " + e.Node.Text + "  et= " + e.Node.Checked);
            if (e.Node.Checked && Chkable)
            {
                switch (e.Node.ImageIndex)
                {
                    case 2:
                    case 4:
                    case 5:
                        //lRimgNdx.Text = e.Node.ImageIndex = e.Node.ImageIndex;
                        if (curR_sol == "") curR_sol = e.Node.Text;
                        if (e.Node.Checked && e.Node.Text == curR_sol)
                        {
                            add_LVR(e.Node.Text, e.Node.Index.ToString(), "", "", "", "", "", "");
                            for (int i = 0; i < e.Node.Nodes.Count; i++)
                                e.Node.Nodes[i].Checked = true;
                        }
                        else
                        {
                            for (int r = lvOrder.Items.Count - 1; r > -1; r--) delLvOrderALL(r);
                            btnUnchk = true; e.Node.Checked = false; btnUnchk = false;
                            curR_sol = "";
                            e.Node.Checked = true;
                        }
                        break;
                    case 1:
                        if (curR_sol == "") curR_sol = e.Node.Parent.Text;
                        if (e.Node.Checked && e.Node.Parent.Text == curR_sol)
                        {
                            //if (e.Node.Parent.Index.ToString() != curR_sol) for (int r = lvOrder.Items.Count - 1; r > -1; r--) delLvOrderALL(r);
                            add_LVR("  " + e.Node.Text, e.Node.Parent.Index.ToString(), e.Node.Index.ToString(), "", "", "", "", "");
                            for (int i = 0; i < e.Node.Nodes.Count; i++)
                                e.Node.Nodes[i].Checked = true;
                        }
                        else { btnUnchk = true; e.Node.Checked = false; btnUnchk = false; }
                        break;
                    case 0:
                    case 3:
                        if (curR_sol == "") curR_sol = e.Node.Parent.Parent.Text;
                        if (e.Node.Checked && e.Node.Parent.Parent.Text == curR_sol)
                        {
                            //if (e.Node.Parent.Parent.Index.ToString() != curR_sol) for (int r = lvOrder.Items.Count - 1; r > -1; r--) delLvOrderALL(r);
                            //string TotALS = ????
                            add_LVR("    " + e.Node.Text, e.Node.Parent.Parent.Index.ToString(), e.Node.Parent.Index.ToString(), e.Node.Index.ToString(), "", "", "", "");
                        }
                        else { btnUnchk = true; e.Node.Checked = false; btnUnchk = false; }
                        break;
                }
            }
        }

        private bool IsOrdered(string Iname, string SolN, string AlsN, string DetLID)
        {
            return true;
        }

        private void add_LVR(string DescR, string SolNm, string SpcNm, string ALSNm, string DetailID, string ndx, string r_AA, string r_ext)
        {
            ListViewItem lvI = lvOrder.Items.Add(DescR);
            lvI.SubItems.Add(SolNm);
            curR_sol = tvSol.Nodes[Convert.ToInt32(SolNm)].Text;
            lRimgNdx.Text = tvSol.Nodes[Convert.ToInt32(SolNm)].ImageIndex.ToString();
            lRSoln.Text = tvSol.Nodes[Convert.ToInt32(SolNm)].Text;
            lvI.SubItems.Add(SpcNm);
            lvI.SubItems.Add(ALSNm);
            lvI.SubItems.Add(DetailID);
            lvI.SubItems.Add(ndx);
            lvI.SubItems.Add(r_AA);
            lvI.SubItems.Add(r_ext);
        }

        private void add_LVROLD(string DescR, string SolNm, string SpcNm, string ALSNm, string DetailID, string ndx)
        {
            ListViewItem lvI = lvOrder.Items.Add(DescR);
            lvI.SubItems.Add(SolNm);
            lvI.SubItems.Add(SpcNm);
            lvI.SubItems.Add(ALSNm);
            lvI.SubItems.Add(DetailID);
            lvI.SubItems.Add(ndx);
        }

        private void gbxSol_Enter_1(object sender, System.EventArgs e)
        {

        }

        private void cbIPmgr_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            string[] arr_Val = new string[6] { "", "", "", "", "", "" };
            string stSql = "select SA_ID ,Extension,sfx from PSM_SALES_AGENTS where (First_Name + ' ' + Last_Name) ='" + cbIPmgr.Text + "'";
            lIpmgr.Text = MainMDI.Find_One_Field(stSql);
            if (lIpmgr.Text == MainMDI.VIDE) lIpmgr.Text = "0";
        }

        private void cbCPmgr_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            //string[] arr_Val = new string[6]{ "", "", "", "", "", "" };
            string stSql = "SELECT PSM_Contacts.Contact_ID, PSM_Prefix.Prefix, PSM_Contacts.[First_Name], PSM_Contacts.Last_Name, PSM_Contacts.JOBTitle, Extension " +
                " FROM PSM_Contacts INNER JOIN PSM_Prefix ON PSM_Contacts.Prefix_ID = PSM_Prefix.[Prefix ID]  WHERE ([PSM_Contacts].[First_Name] + ' ' + [PSM_Contacts].[Last_Name])='" + cbCPmgr.Text.Replace("'", "''") + "' ";
            lCpmgr.Text = MainMDI.Find_One_Field(stSql); lPGRname.Text = lCpmgr.Text;
            if (lCpmgr.Text == MainMDI.VIDE) lCpmgr.Text = "0";
        }

        private void lvOrder_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void btnInsert_Click(object sender, System.EventArgs e)
        {

        }

        private void btnDel_Click(object sender, System.EventArgs e)
        {
            for (int r = lvOrder.SelectedItems.Count - 1; r > -1; r--) delLvOrderALL(lvOrder.SelectedItems[r].Index);
        }

        private void delLvOrder(int Rndx)
        {
            btnUnchk = true;
            if (lvOrder.SelectedItems.Count > 0)
            {
                if (lvOrder.SelectedItems[Rndx].SubItems[5].Text != "")
                {
                    int ndx = Convert.ToInt32(lvOrder.SelectedItems[Rndx].SubItems[5].Text);
                    lvQITEMS.Items[ndx].Checked = false;
                    lvOrder.Items[lvOrder.SelectedItems[Rndx].Index].Remove();
                }
                else
                {
                    int AI = (lvOrder.SelectedItems[Rndx].SubItems[3].Text != "") ? Convert.ToInt32(lvOrder.SelectedItems[Rndx].SubItems[3].Text) : -1;
                    int PI = (lvOrder.SelectedItems[Rndx].SubItems[2].Text != "") ? Convert.ToInt32(lvOrder.SelectedItems[Rndx].SubItems[2].Text) : -1;
                    int SI = (lvOrder.SelectedItems[Rndx].SubItems[1].Text != "") ? Convert.ToInt32(lvOrder.SelectedItems[Rndx].SubItems[1].Text) : -1;
                    if (AI != -1) tvSol.Nodes[SI].Nodes[PI].Nodes[AI].Checked = false;
                    else
                    {
                        if (PI != -1) tvSol.Nodes[SI].Nodes[PI].Checked = false;
                        else if (SI != -1) tvSol.Nodes[SI].Checked = false;
                    }
                }
                lvOrder.SelectedItems[Rndx].Remove();
            }
            btnUnchk = false;
        }

        private void delLvOrderALL(int Rndx)
        {
            btnUnchk = true;
            if (lvOrder.Items.Count > 0)
            {
                if (lvOrder.Items[Rndx].SubItems[5].Text != "")
                {
                    int ndx = Convert.ToInt32(lvOrder.Items[Rndx].SubItems[5].Text);
                    lvQITEMS.Items[ndx].Checked = false;
                    //lvOrder.Items[lvOrder.Items[Rndx].Index].Remove();
                    //lvOrder.Items[Rndx].Remove();
                }
                else
                {
                    int AI = (lvOrder.Items[Rndx].SubItems[3].Text != "") ? Convert.ToInt32(lvOrder.Items[Rndx].SubItems[3].Text) : -1;
                    int PI = (lvOrder.Items[Rndx].SubItems[2].Text != "") ? Convert.ToInt32(lvOrder.Items[Rndx].SubItems[2].Text) : -1;
                    int SI = (lvOrder.Items[Rndx].SubItems[1].Text != "") ? Convert.ToInt32(lvOrder.Items[Rndx].SubItems[1].Text) : -1;
                    if (AI != -1) tvSol.Nodes[SI].Nodes[PI].Nodes[AI].Checked = false;
                    else
                    {
                        if (PI != -1) tvSol.Nodes[SI].Nodes[PI].Checked = false;
                        else if (SI != -1) tvSol.Nodes[SI].Checked = false;
                    }
                    lvOrder.Items[Rndx].Remove();
                }
                //lvOrder.Items[Rndx].Remove();
            }
            btnUnchk = false;
        }

        private void btnClear_Click(object sender, System.EventArgs e)
        {

        }

        private void btnsSaveOrd_Click(object sender, System.EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            string stSql = MainMDI.Find_One_Field("select Sol_LID from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " AND Sol_Name='" + lRSoln.Text + "'");
            isDellAll = true;
            if (stSql != MainMDI.VIDE)
            {
                //MainMDI.ExecSql("delete * from pgm_Det_OL");
                MainMDI.ExecSql("delete " + MainMDI.t_Det_OL);
                MainMDI.ExecSql("INSERT INTO " + MainMDI.t_Det_OL + " ([detailLID],[AA_orig],[rank],[Det_Qty],[Als_Qty],[brkdwn]) VALUES ('" +
                    lRimgNdx.Text + "~" + lCurrIQID.Text + "~" + stSql + "', '','0','0','0','0')"); //Header 
                for (int r = 0; r < lvOrder.Items.Count; r++)
                {
                    if (Tools.Conv_Dbl(lvOrder.Items[r].SubItems[4].Text) != 0)
                        Nsrt_Det_OL(lvOrder.Items[r].SubItems[7].Text, lvOrder.Items[r].SubItems[6].Text, lvOrder.Items[r].SubItems[4].Text, lvOrder.Items[r].SubItems[5].Text);
                    //MainMDI.ExecSql("INSERT INTO pgm_Det_OL ([detailLID]) VALUES (" + lvOrder.Items[r].SubItems[4].Text + "')");
                    else if (lvOrder.Items[r].SubItems[3].Text != "") save_DetLID(lCurrIQID.Text, lvOrder.Items[r].SubItems[1].Text, lvOrder.Items[r].SubItems[2].Text, lvOrder.Items[r].SubItems[3].Text, r);
                }
                Order child_Ord = new Order("*", "*");
                this.Hide();
                child_Ord.ShowDialog();
                string Conv_RRevID = child_Ord.lOKConv.Text;
                string NewProjID = child_Ord.LRID.Text; 
                if (Conv_RRevID != "") BCONV = child_Ord.BCOnv;
                this.Visible = true;
                for (int r = lvOrder.Items.Count - 1; r > -1; r--) delLvOrderALL(r);
                if (lvOrder.Items.Count > 0) lvOrder.Items.Clear();
                isDellAll = false;
                //child_Ord.Dispose();
            }
            else MessageBox.Show("This Quote Revision is not Saved Yet  !!!");
            this.Cursor = Cursors.Default;
            if (BCONV) this.Hide();
        }

        private void save_DetLID(string iQID, string solN, string SpcN, string AlsN, int r)
        {
            int AI = (AlsN != "") ? Convert.ToInt32(AlsN) : -1;
            int PI = (SpcN != "") ? Convert.ToInt32(SpcN) : -1;
            int SI = (solN != "") ? Convert.ToInt32(solN) : -1;

            string stSql = " SELECT PSM_Q_Details.* ,PSM_Q_SPCS.SPC_Name + '/' + PSM_Q_ALS.ALS_Name AS AA_orig " +
                " FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " WHERE ((PSM_Q_IGen.i_Quoteid)=" + iQID + ") AND ((PSM_Q_SOL.Sol_Name)='" + tvSol.Nodes[SI].Text + "')"; //+ "') AND ((PSM_Q_SPCS.SPC_Name)='" + SpcNm + "') AND ((PSM_Q_ALS.ALS_Name)='" + AlsNm + "')) ";
            if (AI != -1) stSql += " AND ((PSM_Q_SPCS.SPC_Name)='" + tvSol.Nodes[SI].Nodes[PI].Text.Replace("'", "''") + "') AND ((PSM_Q_ALS.ALS_Name)='" + tvSol.Nodes[SI].Nodes[PI].Nodes[AI].Text.Replace("'", "''") + "') ";
            if (PI != -1) stSql += " AND ((PSM_Q_SPCS.SPC_Name)='" + tvSol.Nodes[SI].Nodes[PI].Text.Replace("'", "''") + "')";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                if (!(Tools.Conv_Dbl(Oreadr["Ext"].ToString()) == 0 && Oreadr["Aff_ID"].ToString() == ".")) Nsrt_Det_OL(Oreadr["Ext"].ToString(), Oreadr["AA_orig"].ToString(), Oreadr["Detail_LID"].ToString(), r.ToString());
            }
        }

        private void Nsrt_Det_OL(string ext, string r_AA, string r_det_LID, string r)
        {
            string AA = (ext == "") ? "" : r_AA;
            MainMDI.ExecSql("INSERT INTO " + MainMDI.t_Det_OL + " ([detailLID],[AA_orig],[rank]) VALUES (" + r_det_LID + ", '" + AA + "', " + r + ")");
        }

        private void button7_Click(object sender, System.EventArgs e)
        {

        }

        private bool maj_LT()
        {
            if (minLT.Text.Length == 1) minLT.Text = "0" + minLT.Text;
            if (MaxLT.Text.Length == 1) MaxLT.Text = "0" + MaxLT.Text;
            if (tExt.Text != "" && tExt.Text != " ")
            {
                int mLT = (minLT.Text == "") ? 0 : Convert.ToInt32(minLT.Text);
                int xLT = (MaxLT.Text == "") ? 0 : Convert.ToInt32(MaxLT.Text);
                if (mLT < xLT) tLT.Text = MainMDI.A00(mLT, 2) + "-" + MainMDI.A00(xLT, 2);
                else
                {
                    MessageBox.Show("Min LeadTime must < MAX LeadTime !!!");
                    return false;
                }
            }
            else tXchng.Text = "1";
            return true;
        }

        private void MaxLT_TextChanged(object sender, System.EventArgs e)
        {
            //maj_LT();
        }

        private void minLT_TextChanged(object sender, System.EventArgs e)
        {
            //maj_LT();
        }

        private void MaxLT_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyInt(e.KeyChar);
        }

        private void minLT_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyInt(e.KeyChar);
        }

        private void Lang_Click(object sender, System.EventArgs e)
        {

        }

        //Main functions....

        public static long oldGen_ID(char tNm)
        {
            long ResID = 0;
            string tblNm = "PSM_" + tNm + "_GenID";
            //string Res = MainMDI.Find_One_Field("select " + tNm + "ID from " + tblNm + " where not flaged and not InUse ORDER BY PSM_Q_GenID.QID");
            string Res = MainMDI.Find_One_Field("select " + tNm + "ID from " + tblNm + " where not flaged and not InUse order by  " + tNm + "ID ");
            if (Res == MainMDI.VIDE)
            {
                string lastID = MainMDI.Find_One_Field(" select " + tNm + "ID from " + tblNm + " order by  " + tNm + "ID DESC");
                if (lastID != MainMDI.VIDE)
                {
                    if (New100_QRID(tNm, lastID)) ResID = Convert.ToInt32(lastID);
                    else ResID = 0; //means PSM_Q_GenID is Full or cannot Write In.
                }
                else ResID = -1; //means PSM_Q_GenID is Empty & must be Init.
            }
            else ResID = Convert.ToInt32(Res);
            return ResID;
        }

        public static bool lock_table(char tNm)
        {
            bool Res = true;
            string tableNM = "PSM_" + tNm + "_GenID";
            while (true)
            {
                string st = MainMDI.Find_One_Field(" select TableName from PSM_LOCKED_TABLES where TableName='" + tableNM + "'");
                if (st == MainMDI.VIDE)
                {
                    Res = MainMDI.ExecSql(" INSERT INTO PSM_LOCKED_TABLES ([TableName]) VALUES ('" + tableNM + "')");
                    break;
                }
                else
                {
                    DialogResult dr = MessageBox.Show("Can not Generate New ID  Table is Locked by another User, please try later or contact your Admin...", "Generating New ID", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
                    if (dr == DialogResult.Cancel)
                    {
                        Res = false;
                        break;
                    }
                }
            }
            return Res;
        }

        public static bool New100_QRID(char c, string IdFrom)
        {
            long debId = Convert.ToInt32(IdFrom);
            try
            {
                string tblNm = "PSM_" + c + "_GenID";
                string s_LastId = MainMDI.Find_One_Field("select " + c + "ID from " + tblNm + " ORDER BY " + c + "ID DESC");
                if (s_LastId == MainMDI.VIDE) s_LastId = "0";
                long LastID = Convert.ToInt32(s_LastId);
                if (LastID < debId) for (long i = LastID; i < debId - 1; i++) MainMDI.ExecSql("INSERT INTO " + tblNm + " ([flaged],[inuse]) VALUES (TRUE,FALSE)");
                for (long i = 0; i < 100; i++) MainMDI.ExecSql("INSERT INTO " + tblNm + " ([flaged],[inuse]) VALUES (FALSE,FALSE)");
                return true;
            }
            catch (OleDbException Oexp)
            {
                MainMDI.stXP = Oexp.Message;
                return false;
            }
        }

        public static bool New100_QRIDOLD(char c, string st)
        {
            long debQid = Convert.ToInt32(st);
            try
            {
                string tblNm = (c == 'Q') ? "PSM_Q_GenID" : "PSM_R_GenID";
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                long limt = (debQid <= MainMDI.MAX_QID - 99) ? debQid + 100 : (MainMDI.MAX_QID + 1);
                for (long i = debQid; i < limt; i++)
                {
                    Ocmd.CommandText = "INSERT INTO" + tblNm + " ([" + c + "ID],[flaged]) VALUES ('" + i.ToString() + "',FALSE)";
                    Ocmd.ExecuteNonQuery();
                }
                OConn.Close();
                return true;
            }
            catch (OleDbException Oexp)
            {
                MainMDI.stXP = Oexp.Message;
                return false;
            }
        }

        public static bool Unlock_table(string tableNM)
        {
            return MainMDI.ExecSql("delete PSM_LOCKED_TABLES where TableName='" + tableNM + "'");
        }

        /*
        public static string Find_One_Field(string stSql)
        {
            //string stSql = "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

            //tst
            stSql.Replace("'", "''");
            //tst

            try
            {
                OConn = new SqlConnection(MainMDI._connectionString);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read()) return Oreadr[0].ToString();
                return MainMDI.VIDE;
            }
            catch(Exception ex)
            {
                MessageBox.Show("FOF-ERROR= " + ex.Message);
                return MainMDI.VIDE;
            }
            finally
            {
                OConn.Close();
                Oreadr.Close();
            }
        }

        public static bool Confirm(string msg)
        {
            DialogResult dr = MessageBox.Show(msg, "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            return (dr == DialogResult.Yes);
        }
		
        public static string Find_arr_Fields(string stSql, string[] vals)
        {
            //string stSql = "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
            //tst
            stSql.Replace("'", "''");
            //tst

            SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                for (int i = 0; i < Oreadr.FieldCount; i++) vals[i] = Oreadr[i].ToString();
                return Oreadr[0].ToString();
            }
            OConn.Close();
            return MainMDI.VIDE;
        }

        public static string A00(string st)
        {
            if (st == "0") return ".00";
            double dd = Tools.Conv_Dbl(st);
            if (dd != 0)
            {
                int ipos = st.IndexOf(".", 0);
                if (ipos == -1) st = st + ".00";
                else
                {
                    string st1 = st.Substring(0, ipos);
                    string st2 = st.Substring(ipos, st.Length - ipos);
                    for (int j = st2.Length; j < 3; j++) st2 += "0";
                    return st1 + st2;
                }
            }
            return st;
        }

        public static string A00(int ii, int Lnt)
        { 
            //if (st == "0") return "00";
            string st = ii.ToString();
            for (int j = st.Length; j < Lnt; j++)
                st = "0" + st;
            return st;
        }

        public static bool flag_QRID(char tNm, char c, bool etat, long ID)
        {
            //flag flaged ==> flag('f', true, xxx)
            //Unflag flaged ==> flag('f', false, xxx)
            //flag InUse ==> flag('u', true, xxx)
            //uflag InUse ==> flag('u', false, xxx)
            string stflag = (c == 'f') ? "[flaged]=" + etat.ToString() : "[InUse]=" + etat.ToString();
            string stSql = "UPDATE " + "PSM_" + tNm + "_GenID" + " SET " + stflag + " WHERE " + tNm + "ID=" + ID.ToString();
            return MainMDI.ExecSql(stSql);
        }

        public static bool flag_QRIDOLD(char tNm, char c, bool etat, long ID)
        {
            //flag flaged ==> flag('f', true, xxx)
            //Unflag flaged ==> flag('f', false, xxx)
            //flag InUse ==> flag('u', true, xxx)
            //uflag InUse ==> flag('u', false, xxx)
            string tblNm = (tNm == 'Q') ? "PSM_Q_GenID" : "PSM_R_GenID";
            string stflag = (c == 'f') ? "[flaged]=" + etat.ToString() : "[InUse]=" + etat.ToString();
            string stSql = "UPDATE " + tblNm + " SET " + stflag + " WHERE " + tNm + "ID=" + ID.ToString();
            return MainMDI.ExecSql(stSql);
        }

        public static bool ExecSql(string stSql)
        {
            //tst
            //stSql.Replace("'", "''");
            //tst
            try
            {
                SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.ExecuteNonQuery();
                OConn.Close();
                MainMDI.stXP = MainMDI.VIDE;
                return true;
            }
            catch (OleDbException Oexp)
            {
                MainMDI.stXP = Oexp.Message;
                MessageBox.Show("STSQL= " + stSql + "\n" + "Msg= " + MainMDI.stXP);
                return false;
            }
        }
        */
        private void lQstatus_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, System.EventArgs e)
        {
            Ges_Cont_Sal_Ag gCSA = new Ges_Cont_Sal_Ag('C');
            gCSA.ShowDialog();
        }

        private void opUS_CheckedChanged(object sender, System.EventArgs e)
        {
            USD_CAD_EURO();
        }

        void USD_CAD_EURO()
        {
            if (opUS.Checked)
            {
                lcurDol.Text = "USD";
                Curr_SQLMLTP = " US_MLTP ";
                picUSD.BringToFront();
            }
            else if (opCan.Checked)
            {
                lcurDol.Text = "CAD";
                Curr_SQLMLTP = " CAN_MLTP ";
                picCAD.BringToFront();
            }
            else
            {
                lcurDol.Text = "EUR";
                Curr_SQLMLTP = " EURO_MLTP ";
                picEURO.BringToFront();
            }
        }

        private void groupBox9_Enter(object sender, System.EventArgs e)
        {

        }

        private void opUS_CheckedChanged_1(object sender, System.EventArgs e)
        {

        }

        private void opEuro_CheckedChanged(object sender, System.EventArgs e)
        {
            USD_CAD_EURO();
        }

        private void lCancel_Click(object sender, System.EventArgs e)
        {

        }

        private void btn_FND_Code_Click(object sender, EventArgs e)
        {
            string CpnyNm = MainMDI.Find_One_Field("select Cpny_Name1 from PSM_COMPANY where Syspro_Code='" + tKey.Text.ToUpper() + "'");

            if (CpnyNm == MainMDI.VIDE)
                MessageBox.Show("NOT FOUND..........!!!!");
            else
            {
                cbCompanyy.Text = CpnyNm;
            }
        }

        private void picSeek_Click(object sender, System.EventArgs e)
        {

        }

        private void CHSPrt()
        {
            PrintDocument prtdoc = new PrintDocument();
            string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
            foreach (String strPrinter in PrinterSettings.InstalledPrinters)
            {
                cbprinters.Items.Add(strPrinter);
                if (strPrinter == strDefaultPrinter)
                {
                    cbprinters.SelectedIndex = cbprinters.Items.IndexOf(strPrinter);
                }
            }
        }

        private void printLabel_Click(object sender, System.EventArgs e)
        {
            if (lCpnyName.Text != "" && tQuoteID.Text != "")
            {
                this.Cursor = Cursors.WaitCursor;

                //printDialog1.ShowDialog();
                string prtNmeOLD = printDialog1.PrinterSettings.PrinterName;
                string prtNme = MainMDI.DYMOName;
                Print_label ll = new Print_label('L', tQuoteID.Text, lCpnyName.Text, "", prtNme, null, null);
                ll.Wexport();
                this.Cursor = Cursors.Default;
            }
        }

        private void btnchngCN_Click(object sender, System.EventArgs e)
        {
            cbContacts.Visible = true;
            lContacts.Visible = false;
            btnchngCN.Visible = false;
            btnchngCN.Visible = false;
        }

        private void btnchngCP_Click(object sender, System.EventArgs e)
        {
            cbCPmgr.Visible = true;
            lcbCPmgr.Visible = false;
            btnchngCP.Visible = false;
            btnchngCP.Visible = false;
        }

        private void btnCHNGCmpny_Click(object sender, System.EventArgs e)
        {
            cbCompanyy.Visible = true;
            lCpnyName.Visible = false;
            btnCHNGCmpny.Visible = false;
            btnSeek.Visible = true;
            tKey.Visible = true;
            lkey.Visible = tKey.Visible;
            btn_find_code.Visible = true;
        }

        private void lCpnyName_Click(object sender, System.EventArgs e)
        {

        }

        private void groupBox4_Enter(object sender, System.EventArgs e)
        {

        }

        private void tKey_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
        {
            cbprinters.Visible = true;
        }

        private void cbprinters_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void MNoCut_Click(object sender, System.EventArgs e)
        {
            //vider_arr_clpB(); //MainMDI.arr_clpB[i, j] = "~";
            CutCopy('D');
        }

        private void CutCopy(char c)
        {
            vider_arr_clpB();
            int i = -1;
            for (i = 0; i < lvQITEMS.SelectedItems.Count; i++)
            {
                for (int j = 0; j < lvQITEMS.Items[i].SubItems.Count; j++)
                {
                    MainMDI.arr_clpB[i, j] = lvQITEMS.SelectedItems[i].SubItems[j].Text;

                    if (c == 'T') //c == 'D' for cut must copy tech values
                    {
                        if (j == 12) MainMDI.arr_clpB[i, j] = "";
                        arr_Tech_values[lvQITEMS.SelectedItems[i].Index] = "";
                    }
                }
            }
            LstNdx = i;
            if (c == 'D') while (lvQITEMS.SelectedItems.Count > 0) lvQITEMS.Items[lvQITEMS.SelectedItems[0].Index].Remove();
            //aff();
            MNoPaste.Enabled = true;
            menuItem9.Enabled = true;
            //+ 240806
            Ref_ALSTOT('C');
        }

        private void CutCopyOKOLD(char c)
        {
            MNoPaste.Enabled = true;

            vider_arr_clpB();
            int i = -1;
            for (i = 0; i < lvQITEMS.SelectedItems.Count; i++)
            {
                //for (int j = 0; j < lvQITEMS.Columns.Count; j++)
                for (int j = 0; j < lvQITEMS.Items[i].SubItems.Count; j++)
                    MainMDI.arr_clpB[i, j] = lvQITEMS.SelectedItems[i].SubItems[j].Text;
                //arr_clpB[i, j] = arr_Tech_values[lvQITEMS.SelectedItems[i].Index];
                if (c == 'D' || c == 'T') arr_Tech_values[lvQITEMS.SelectedItems[i].Index] = "";
            }
            LstNdx = i;
            if (c == 'D') while (lvQITEMS.SelectedItems.Count > 0) lvQITEMS.Items[lvQITEMS.SelectedItems[0].Index].Remove();
            //aff();
            MNoPaste.Enabled = true;
            menuItem9.Enabled = true;
            //+ 240806
            Ref_ALSTOT('C');
        }

        private void MNoPaste_Click(object sender, System.EventArgs e)
        {
            if (lvQITEMS.SelectedItems.Count > 0) paste(lvQITEMS.SelectedItems[0].Index);
            else paste(0);
        }

        private void menuItem9_Click(object sender, System.EventArgs e)
        {
            if (lvQITEMS.SelectedItems.Count > 0) paste(lvQITEMS.SelectedItems[0].Index + 1);
            else paste(0);
        }

        private void paste(int InsertNdx)
        {
            int K = (LstNdx == -1) ? -1 : LstNdx - 1;
            for (int i = InsertNdx; i < lvQITEMS.Items.Count; i++)
            {
                K++;
                for (int j = 0; j < lvQITEMS.Items[i].SubItems.Count; j++)
                    MainMDI.arr_clpB[K, j] = lvQITEMS.Items[i].SubItems[j].Text;
                //LstNdx++;
            }
            //aff();
            while (lvQITEMS.Items.Count > InsertNdx) lvQITEMS.Items[lvQITEMS.Items.Count - 1].Remove();
            for (int i = 0; i < MainMDI.MAX_Quote_lines; i++)
            {
                if (MainMDI.arr_clpB[i, 0] == "~") i = MainMDI.MAX_Quote_lines;
                else
                {
                    ListViewItem lv = lvQITEMS.Items.Add(MainMDI.arr_clpB[i, 0]);
                    if (MainMDI.arr_clpB[i, 1] != " ") lv.BackColor = Color.Salmon;
                    int k = 1;
                    //while (k < 13 && arr_clpB[i, k] != "~")
                    while (k < 13)
                        lv.SubItems.Add(MainMDI.arr_clpB[i, k++]);
                }
            }
            //vider_arr_clpB(); MainMDI.arr_clpB[i, j] = "~";
            //MNoPaste.Enabled = false;
            MNoCut.Enabled = true;
            menuItem9.Enabled = false;
            Tosave = true;
            Ref_ALSTOT('C');
        }

        private void vider_arr_clpB()
        {
            for (int i = 0; i < MainMDI.MAX_Quote_lines; i++)
                for (int j = 0; j < 12; j++)
                    MainMDI.arr_clpB[i, j] = "~";
            LstNdx = 0;
        }

        private void aff()
        {
            string st = "";
            for (int i = 0; i < 10; i++)
            {
                st += "\n";
                for (int k = 0; k < 12; k++) st += "/" + MainMDI.arr_clpB[i, k++];
            }
            MessageBox.Show("arr=   " + st);
        }

        private void mnOcopy_Click(object sender, System.EventArgs e)
        {
            //vider_arr_clpB(); //MainMDI.arr_clpB[i, j] = "~";
            CutCopy('C');
        }

        private void menuItem10_Click(object sender, System.EventArgs e)
        {

        }

        private void menuItem13_Click(object sender, EventArgs e)
        {

        }

        private void menuItem12_Click(object sender, System.EventArgs e)
        {

        }

        private void tOpendate_ValueChanged(object sender, System.EventArgs e)
        {
            lQDopen.Text = tOpendate.Value.ToShortDateString();
        }

        private void btnIn_Click(object sender, System.EventArgs e)
        {
            btnNewID.Visible = false;
            tQuoteID.ReadOnly = false;
        }

        private void tALSnb_TextChanged(object sender, System.EventArgs e)
        {
            tPxPrice.Text = RndCAL(AlsTOT.Text, '*', tALSnb.Text);
            if (!loading && !chk_savOVRG.Checked) tAGprice.Text = tPxPrice.Text;
            //AlsBigTOT.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tALSnb.Text) * Tools.Conv_Dbl(AlsTOT.Text), MainMDI.Q_NB_DEC_AFF));
            //AlsBigTOT.Text = RndCAL(AlsTOT.Text, tALSnb.Text);
            //AlsTOT.Text = RndCAL(AlsTOT_orig.Text, tALSnb.Text);
            //string dd = RndCAL(AlsTOT.Text, tALSnb.Text);
            //if (Tools.Conv_Dbl(tPxPrice.Text) < Tools.Conv_Dbl(dd))
        }

        void check_OVRG()
        {
            if (!loading && !chk_savOVRG.Checked) tAGprice.Text = tPxPrice.Text;
        }

        private string RndCAL(string st, char op, string st2)
        {
            string res = "0.00";
            switch (op)
            {
                case '*':
                    res = MainMDI.A00(Convert.ToString(Math.Round(Tools.Conv_Dbl(st) * Tools.Conv_Dbl(st2), MainMDI.Q_NB_DEC_AFF)));
                    break;
                case '/':
                    res = MainMDI.A00(Convert.ToString(Math.Round(Tools.Conv_Dbl(st) / Tools.Conv_Dbl(st2), MainMDI.Q_NB_DEC_AFF)));
                    break;
            }
            return (res == "0.00") ? "" : res;
        }

        private void tExt_TextChanged(object sender, System.EventArgs e)
        {
            TOALS.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(lALSmAmnt.Text) + Tools.Conv_Dbl(tExt.Text), MainMDI.Q_NB_DEC_AFF));
        }

        private void tExt_DoubleClick(object sender, System.EventArgs e)
        {
            tExt.ReadOnly = false;
        }

        private void lQDopen_Click(object sender, System.EventArgs e)
        {
            //tOpendate.Visible = true;
            //lQDopen.Visible = false;
        }

        private void printQSum()
        {
            this.Cursor = Cursors.WaitCursor;
            if (lvQITEMS.Items.Count > 0)
            {
                //printDialog1.ShowDialog();
                //string prtNmeOLD = printDialog1.PrinterSettings.PrinterName;
                string prtNme = MainMDI.DYMOName;
                Print_label ll = new Print_label('Q', "*", "*", "*", prtNme, null, this);
                ll.Wexport();
                MainMDI.OpenKnownFile(lOFName.Text);
            }
            this.Cursor = Cursors.Default;
        }

        private void printALS_Click(object sender, System.EventArgs e)
        {
            printQSum();
        }

        private void tNB_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyInt(e.KeyChar);
        }

        void exit_Quote()
        {
            bool fin = true;
            if (in_opera != 'V' && MainMDI.ALWD_USR("QT_SV", false))
            {
                SAVE_CHANGE_ALS();
                if (lCurrIQID.Text != "" && tQuoteID.Text != "")
                {
                    if (tQuoteID.Text != "") MainMDI.flag_QRID('Q', 'u', 0, Convert.ToUInt32(tQuoteID.Text));
                    else fin = MainMDI.Confirm("This Quote is not Saved yet ... Quit anyway ? ");
                }
            }
            if (fin) this.Hide();
        }

        private void picExit_Click(object sender, System.EventArgs e)
        {
            exit_Quote();
        }

        private void pictureBox9_Click(object sender, System.EventArgs e)
        {

        }

        private void tPxPrice_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }

        private void tAGprice_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = (Tools.OnlyDBL(e.KeyChar) || e.KeyChar == 45);
        }

        private void button8_Click(object sender, System.EventArgs e)
        {
            //MessageBox.Show(tGCmnt.Text + " Double=" + IsDoubleNumber(tGCmnt.Text).ToString());
            MainMDI.send_email("hedebbab@primax-e.com", "edebbab@gmail.com", "Automatic e-mail  test..", "Automatic e-mail  test..");
            MessageBox.Show("send done");
        }

        private void mnuModif_Click(object sender, System.EventArgs e)
        {
            modif_All_Items();
        }

        private void Enable_ALL(bool stat)
        {
            lvQITEMS.Enabled = stat;
            tvSol.Enabled = stat;
            grpTOTA.Enabled = stat;
        }

        private void btnAsave_Click(object sender, System.EventArgs e)
        {
            bool conti_ok = true;
            if (!tAmult.ReadOnly && tAmult.Text == "1")
            {
                conti_ok = false;
                MessageBox.Show("multiplier ERROR....must be:     multiplier >1   OR  multiplier <1    ");
            }
            if (conti_ok)
            {
                string r_Xchng = "1";
                if (tAmult.Text != MainMDI.VIDE || tAqty.Text != MainMDI.VIDE || tAup.Text != MainMDI.VIDE || cbCategory.Text != MainMDI.VIDE)
                {
                    for (int s = 0; s < lvQITEMS.SelectedItems.Count; s++)
                    {
                        if (Tools.Conv_Dbl(lvQITEMS.SelectedItems[s].SubItems[7].Text) > 0)
                        {
                            if (cbCategory.Text != MainMDI.VIDE)
                            {
                                lvQITEMS.SelectedItems[s].SubItems[6].Text = cbCategory.Text[6].ToString();
                            }
                            if (tAqty.Text != MainMDI.VIDE) lvQITEMS.SelectedItems[s].SubItems[3].Text = tAqty.Text;
                            if (tAup.Text != MainMDI.VIDE) lvQITEMS.SelectedItems[s].SubItems[5].Text = tAup.Text;
                            if (tAmult.Text != MainMDI.VIDE) lvQITEMS.SelectedItems[s].SubItems[4].Text = tAmult.Text;
                            lvQITEMS.SelectedItems[s].SubItems[7].Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(lvQITEMS.SelectedItems[s].SubItems[4].Text) * Tools.Conv_Dbl(lvQITEMS.SelectedItems[s].SubItems[5].Text) * Tools.Conv_Dbl(lvQITEMS.SelectedItems[s].SubItems[3].Text) * Tools.Conv_Dbl(r_Xchng), MainMDI.Q_NB_DEC_AFF));
                            Tosave = true;
                        }
                    }
                    Ref_ALSTOT('C'); //????
                }
                Enable_ALL(true);
                grpAmodif.Visible = false;
            }
        }

        private void btnAcancel_Click(object sender, System.EventArgs e)
        {
            Enable_ALL(true);
            grpAmodif.Visible = false;
        }

        private void AlsTOT_orig_TextChanged(object sender, System.EventArgs e)
        {
            //if (OldAlsTot.Text != AlsTOT_orig.Text && OldAlsTot.Text != "") AlsTOT.Text = AlsTOT_orig.Text;
        }

        private void AlsTOT_TextChanged(object sender, System.EventArgs e)
        {
            if (!AlsTOT.ReadOnly)
            {
                //string dd = RndCAL(AlsTOT.Text, '*', tALSnb.Text);
                //tPxPrice.Text = (OldAlsTot.Text != "") ? dd : RndCAL(tPxPrice.Text, '/', tALSnb.Text);
                tPxPrice.Text = RndCAL(AlsTOT.Text, '*', tALSnb.Text);
                if (!loading && !chk_savOVRG.Checked) tAGprice.Text = tPxPrice.Text;
            }
            //ref_PXAG_Price();
            //OldAlsTot.Text = AlsTOT.Text;
        }

        private void AlsTOT_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            e.Handled = (Tools.OnlyDBL(e.KeyChar) || e.KeyChar == 45);
        }

        private void tvSol_Resize(object sender, System.EventArgs e)
        {
            //lvQITEMS.Width = 578 - tvSol.Width;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            tAGprice.Text = tPxPrice.Text;
        }

        private void picbadRevSta_Click(object sender, EventArgs e)
        {
            tAGprice.Text = tPxPrice.Text;
            picbadRevSta.Visible = false; //(tAGprice.Text != tPxPrice.Text);
        }

        private void tAGprice_TextChanged(object sender, EventArgs e)
        {
            picbadRevSta.Visible = (tAGprice.Text != tPxPrice.Text);
        }

        private void tPxPrice_TextChanged(object sender, EventArgs e)
        {
            picbadRevSta.Visible = (tAGprice.Text != tPxPrice.Text);
        }

        private void lAlterTOT_Click(object sender, EventArgs e)
        {

        }

        private void Quote_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private long XSP_NSRT_CurrentMLTP(string _Cpny_ID, string _CAN_MLTP, string _US_MLTP, string _EURO_MLTP)
        {
            string LID = "-1";
            string stXP = "";
            try
            {
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = new SqlCommand("NSRT_CpnyCurrMLTP", OConn);
                Ocmd.CommandType = CommandType.StoredProcedure;

                Ocmd.Parameters.AddWithValue("@Cpny_ID", _Cpny_ID);
                Ocmd.Parameters.AddWithValue("@CAN_MLTP", _CAN_MLTP);
                Ocmd.Parameters.AddWithValue("@US_MLTP", _US_MLTP);
                Ocmd.Parameters.AddWithValue("@EURO_MLTP", _EURO_MLTP);
                //LID = Ocmd.exe;
                SqlDataReader rdr = Ocmd.ExecuteReader();
                while (rdr.Read()) LID = rdr[0].ToString();
                OConn.Close();
                stXP = MainMDI.VIDE;
                return Int64.Parse(LID);
            }
            catch (SqlException Oexp)
            {
                stXP = Oexp.Message;
                MessageBox.Show("NSRT_CpnyCurrMLTP \n" + "Msg= " + stXP);
                return -1;
            }
        }

        private void btnSavMLTP_Click(object sender, EventArgs e)
        {
            string res = MainMDI.Find_One_Field("select mltp_LID from PSM_Cmpny_CurrMLTP where Cpny_ID=" + lcpnyID.Text);
            if (res == MainMDI.VIDE)
            {
                long _lid = _lid = XSP_NSRT_CurrentMLTP(lcpnyID.Text, STDMultp_CAN, STDMultp_US, STDMultp_EURO);
                MainMDI.Write_JFS(" New Current multiplyer for Company=" + lCpnyName.Text.Replace("'", "''"));
            }
            MainMDI.Exec_SQL_JFS("update PSM_Cmpny_CurrMLTP set [" + Curr_SQLMLTP.Trim() + "] = " + tCust_Mult.Text + " where Cpny_ID=" + lcpnyID.Text, " Change Current multiplyer for Company=" + lCpnyName.Text.Replace("'", "''"));
        }

        private void btnChangMLTP_Click(object sender, EventArgs e)
        {
            string _stUS = "", _stCAN = "", _stEURO = "";
            if (MainMDI.profile != 'R')
            {
                this.Cursor = Cursors.WaitCursor;
                Company frmComapny = new Company(lCpnyName.Text, 'M', Q_sysPcod.Text);
                frmComapny.ShowDialog();
                MainMDI.Find_2_Field("SELECT multpl1, multpl1_US,multpl1_EURO FROM PSM_COMPANY inner join  PSM_CmpnyTYPE on PSM_COMPANY.CustomerType= PSM_CmpnyTYPE.CpnyType_ID where Cpny_ID=" + lcpnyID.Text, ref _stCAN, ref _stUS, ref _stEURO);
                //fill_NewMLTP(_stCAN, _stUS, _stEURO);
                Ref_GetActivy_MLTPL();

                check_Activity();

                this.Cursor = Cursors.Default;
            }
            else MessageBox.Show("ACCESS DENIED... ", MainMDI.User, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            tCust_Mult.Text = STDMultp.Text;
        }

        private void cb_Territo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txcb_Territo_DoubleClick(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {

        }

        private void paste_emptyNL(int InsertNdx)
        {
            int K = (LstNdx == -1) ? -1 : LstNdx - 1;
            for (int i = InsertNdx; i < lvQITEMS.Items.Count; i++)
            {
                K++;
                for (int j = 0; j < lvQITEMS.Items[i].SubItems.Count; j++)
                    MainMDI.arr_clpB[K, j] = lvQITEMS.Items[i].SubItems[j].Text;
                //LstNdx++;
            }
            //aff();
            while (lvQITEMS.Items.Count > InsertNdx) lvQITEMS.Items[lvQITEMS.Items.Count - 1].Remove();
            for (int i = 0; i < MainMDI.MAX_Quote_lines; i++)
            {
                if (MainMDI.arr_clpB[i, 0] == "~") i = MainMDI.MAX_Quote_lines;
                else
                {
                    ListViewItem lv = lvQITEMS.Items.Add(MainMDI.arr_clpB[i, 0]);
                    if (MainMDI.arr_clpB[i, 1] != " ") lv.BackColor = Color.Salmon;
                    int k = 1;
                    //while (k < 13 && arr_clpB[i, k] != "~")
                    while (k < 13)
                        lv.SubItems.Add(MainMDI.arr_clpB[i, k++]);
                }
            }
            //vider_arr_clpB(); MainMDI.arr_clpB[i, j] = "~";
            //MNoPaste.Enabled = false;
            MNoCut.Enabled = true;
            menuItem9.Enabled = false;
            Tosave = true;
            Ref_ALSTOT('C');
        }

        private void menuItem16_Click(object sender, EventArgs e)
        {
            CutCopy('T');

            //if (lcurSol_Status.Text != "C")
            //{
                //if (lvQITEMS.Items.Count > 0)
                //{
                    //copyEmptyL(0);
                    //if (lvQITEMS.SelectedItems.Count > 0) paste(lvQITEMS.SelectedItems[0].Index + 1);
                    //else paste(0);
                //}
            //}
            //else MessageBox.Show("No item of this Revision can be Modified !!!");
        }

        private void copyEmptyL(int _ndx)
        {
            vider_arr_clpB();
            int i = _ndx;
            for (int j = 0; j < lvQITEMS.Items[i].SubItems.Count; j++)
                if (j == 1 || j == 12) MainMDI.arr_clpB[i, j] = "";
                else MainMDI.arr_clpB[i, j] = "00";
            LstNdx = i;
            //+ 240806
            //Ref_ALSTOT('C');
        }

        private void button12_Click(object sender, EventArgs e)
        {
            pnl_Hidden.Visible = false;
            Enable_ALL(true);
        }

        private void button13_Click(object sender, EventArgs e)
        {
            if (Tools.Conv_Dbl(th_EXT.Text) != 0 && th_desc.Text != "")
            {
                Enable_ALL(true);
                add_LVO(1, 0, th_nb.Text, th_desc.Text, "1", "1", th_EXT.Text, th_EXT.Text, "", "", "C_HIDE", "A");
                ItemCount++;
                pnl_Hidden.Visible = false;

                //Opt_added = true;
                Ref_ALSTOT('A');
            }
            else MessageBox.Show("Sorry extension is null....");
        }

        private void txprct_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (Tools.OnlyDBL(e.KeyChar) || e.KeyChar == 45); //for Sign
        }

        private void th_EXT_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = (Tools.OnlyDBL(e.KeyChar) || e.KeyChar == 45); //for Sign
        }

        private void txprct_TextChanged(object sender, EventArgs e)
        {
            th_EXT.Text = Math.Round(((Tools.Conv_Dbl(txprct.Text) * Tools.Conv_Dbl(th_SYS.Text)) / 100), MainMDI.NB_DEC_AFF).ToString();
        }

        private void button14_Click(object sender, EventArgs e)
        {

        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void cbAG1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbAG2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {
            lCname.Text = MainMDI.Find_One_Field("SELECT PSM_Contacts.Contact_ID FROM PSM_Contacts WHERE ([PSM_Contacts].[First_Name] + ' ' + [PSM_Contacts].[Last_Name])='" + cbContacts.Text.Replace("'", "''") + "' and Company_ID=" + lcpnyID.Text);

            lPGRname.Text = MainMDI.Find_One_Field("SELECT PSM_Contacts.Contact_ID FROM PSM_Contacts WHERE ([PSM_Contacts].[First_Name] + ' ' + [PSM_Contacts].[Last_Name])='" + cbCPmgr.Text.Replace("'", "''") + "' and Company_ID=" + lcpnyID.Text);
        }

        private void fill_cb_S99()
        {
            string stSql = "SELECT distinct  [Name],[Salesperson]        FROM [SysproCompanyP].[dbo].[v_PGSalesperson]   where SUBSTRING (Salesperson,1,1) in ('S','H')   order by Salesperson ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read()) MainMDI.add_CB_itm(cbS99, Oreadr[0].ToString(), Oreadr[1].ToString());

            OConn.Close();
        }

        void fill_Activities()
        {
            MainMDI.fill_Any_CB(cbActivities, "select  CpnyType,CpnyType_ID FROM PSM_CmpnyTYPE where NorO='N' order by CpnyType_ID ", false, "");
            /*
            //string stSql = "select  CpnyType FROM PSM_CmpnyTYPE ORDER BY multpl1 ";
            string stSql = "select  CpnyType FROM PSM_CmpnyTYPE ";
            SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            lbxCtype.Items.Clear();
            //lbxCtype.Items.Add("NEW");
            while (Oreadr.Read())
            {
                lbxCtype.Items.Add(Oreadr[0].ToString());
            }
            OConn.Close();
            */
        }

        private void cbS99_SelectedIndexChanged(object sender, EventArgs e)
        {
            lcbS99.Text = MainMDI.get_CBX_value(cbS99, cbS99.SelectedIndex);
        }

        private void btnSeek_Click(object sender, EventArgs e)
        {
            bool FOUND = false;
            if (ndxfound > cbCompanyy.Items.Count) ndxfound = 0;
            for (int i = ndxfound; i < cbCompanyy.Items.Count; i++)
            {
                //if (cbCompany.Items[i].ToString().ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1)
                    //int ln = (tKey.Text.Length < cbCompany.Items[i].ToString().Length) ? tKey.Text.Length : cbCompany.Items[i].ToString().Length;
                //if (cbCompany.Items[i].ToString().Substring(0, ln).ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1)
                //	
                if (cbCompanyy.Items[i].ToString().ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1)
                {
                    cbCompanyy.SelectedIndex = i;
                    ndxfound = i + 1;
                    i = cbCompanyy.Items.Count;
                    cbCompanyy_SelectedIndexChanged(sender, e); //cbOptGrp_SelectedValueChanged(sender, e);
                    //if (ndxfound < cbOptGrp.Items.Count) button1.Text = "Next";
                    FOUND = true;
                }
            }
            if (!FOUND)
            {
                ndxfound = 0;
                button1.Text = "Search";
                MessageBox.Show("KeyWord not Found !!!!");
            }
        }

        private void btn_find_code_Click(object sender, EventArgs e)
        {
            string CpnyNm = MainMDI.Find_One_Field("select Cpny_Name1 from PSM_COMPANY where Syspro_Code='" + tKey.Text.ToUpper() + "'");

            if (CpnyNm == MainMDI.VIDE)
                MessageBox.Show("NOT FOUND..........!!!!");
            else
            {
                cbCompanyy.Text = CpnyNm;
            }
        }

        private void AddSpec_Click(object sender, EventArgs e)
        {
            //lTLSndx.Text = toolbar1_btName_ndx(sender.ToString()).ToString();
            if (MainMDI.ALWD_USR("QT_SV", true)) Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void Cancel_Click(object sender, EventArgs e)
        {
            //int btn = toolbar1_btName_ndx(sender.ToString());
            //MessageBox.Show("sender=" + sender.ToString() + "    btn=" + btn.ToString());

            Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
        }

        //***************************************************************

        void Import_Quotes()
        {
            if (MainMDI.PermT_user("QS"))
            {
                QimportRxx imp = new QimportRxx();
                imp.ShowDialog();
                if (imp.lsave.Text == "Y")
                {
                    import_OldQInfo(imp.lIQID.Text);
                    Imp_SolID = imp.lSolid.Text;
                    Imp_IQID = imp.lIQID.Text;
                    Imp_cpnyID = imp.lcpnyID.Text;
                    gbxSol.Enabled = false;
                    MainMDI.Write_JFS("imported IQID=" + imp.lIQID.Text + " TO " + tQuoteID.Text + " date: " + System.DateTime.Now);
                    //Imprt = true;
                }
                else Imp_SolID = "";
            }
        }

        //**********************************************************

        private void import_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true))
            {
                Import_Quotes();
                //int btn = toolbar1_btName_ndx(sender.ToString());
                //MessageBox.Show("sender=" + sender.ToString() + "    btn=" + btn.ToString());
                Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
            }
        }

        private void DelQ_Click(object sender, EventArgs e)
        {
            //import.Checked = false;
            //MessageBox.Show("sender=" + sender.ToString() + "    e=" + e.ToString() + "   checked=" + import.Checked.ToString());
            Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
        }

        private void gbxSol_Enter_2(object sender, EventArgs e)
        {

        }

        private static void DirectoryCopy(string sourceDirName, string destDirName, bool copySubDirs)
        {
            //Get the subdirectories for the specified directory.
            DirectoryInfo dir = new DirectoryInfo(sourceDirName);

            if (!dir.Exists)
            {
                throw new DirectoryNotFoundException(
                    "Source directory does not exist or could not be found: "
                    + sourceDirName);
            }
            DirectoryInfo[] dirs = dir.GetDirectories();
            //If the destination directory doesn't exist, create it.
            if (!Directory.Exists(destDirName))
            {
                Directory.CreateDirectory(destDirName);
            }
            //Get the files in the directory and copy them to the new location.
            FileInfo[] files = dir.GetFiles();
            foreach (FileInfo file in files)
            {
                string temppath = Path.Combine(destDirName, file.Name);
                file.CopyTo(temppath, false);
            }
            //If copying subdirectories, copy them and their contents to new location.
            if (copySubDirs)
            {
                foreach (DirectoryInfo subdir in dirs)
                {
                    string temppath = Path.Combine(destDirName, subdir.Name);
                    DirectoryCopy(subdir.FullName, temppath, copySubDirs);
                }
            }
        }

        void fill_dgCpnyQT_Vide()
        {
            string[] cols = new string[6]{ "Company Name ", "Adress ", "Phone ", "Fax ","Contact ","Project MGR" };
            dg_CpnyQT.Rows.Clear();
            for (int i = 0; i < cols.Length; i++) //arr_dgInfo.Length / 2)
            {
                DataGridViewRow line = new DataGridViewRow();
                line.CreateCells(dg_CpnyQT);
                line.Cells[0].Value = cols[i];
                line.Cells[1].Value = "-";
                //line.Cells[0].Style.Alignment = 

                dg_CpnyQT.Rows.Add(line);

                //dg_Info.Rows[dg_Info.Rows.Count - 1].ba
            }
        }

        void fill_dgCpnyQT()
        {
            string[] cols = new string[6] { "Company Name ", "Adress ", "Phone ", "Fax ", "Contact ", "Project MGR" };
            string[] Vals = new string[6];
            Vals[0] = cbCompanyy.Text;
            Vals[1] = lAdrs.Text;
            Vals[2] = lPhone.Text;
            Vals[3] = lFax.Text;
            Vals[4] = cbContacts.Text;
            Vals[5] = cbCPmgr.Text;

            dg_CpnyQT.Rows.Clear();
            for (int i = 0; i < cols.Length; i++) //arr_dgInfo.Length / 2)
            {
                DataGridViewRow line = new DataGridViewRow();
                line.CreateCells(dg_CpnyQT);
                line.Cells[0].Value = cols[i];
                line.Cells[1].Value = Vals[i];
                dg_CpnyQT.Rows.Add(line);
            }
            lREQ.Text = lcpnyID.Text;
            //QReq.Text = "|C_NM|" + cbCompanyy.Text + "|C_AD|" + lAdrs.Text + "|C_PHN|" + lPhone.Text + "|C_FX|" + lFax.Text + "|C_CT|" + cbContacts.Text + "|C_mg|" + cbCPmgr.Text;
            QReq.Text = "|" + cbCompanyy.Text + "|" + lAdrs.Text + "|" + lPhone.Text + "|" + lFax.Text + "|" + cbContacts.Text + "|" + cbCPmgr.Text;
        }

        string get_Cvar(string Cvar)
        {
            string rez = "?";
            int ipos1 = QReq.Text.IndexOf("|" + Cvar);
            if (ipos1 > -1)
            {
                int ipos2 = QReq.Text.IndexOf("|", ipos1 + 4);
                if (ipos2 > -1) rez = QReq.Text.Substring(ipos2 - ipos1 + 4);
            }
            return rez;
        }

        void fill_dgFrom_QT()
        {
            string[] cols = new string[6] { "Company Name ", "Adress ", "Phone ", "Fax ", "Contact ", "Project MGR" };
            string[] Vals = QReq.Text.Split('|');
            //Vals[0] = get_Cvar("C_NM");
            //Vals[1] = get_Cvar("C_AD");
            //Vals[2] = get_Cvar("C_FN");
            //Vals[3] = get_Cvar("C_FX");
            //Vals[4] = get_Cvar("C_CT");
            //Vals[5] = get_Cvar("C_MG");

            dg_CpnyQT.Rows.Clear();
            for (int i = 0; i < cols.Length; i++) //arr_dgInfo.Length / 2)
            {
                DataGridViewRow line = new DataGridViewRow();
                line.CreateCells(dg_CpnyQT);
                line.Cells[0].Value = cols[i];
                line.Cells[1].Value = Vals[i + 1];
                dg_CpnyQT.Rows.Add(line);
            }
        }

        private void QuoteV2_Load(object sender, EventArgs e)
        {
            //Tosave = false;

            //in_opera = x_opera;
            //if (x_opera != '*')
            //{
                //init_Qte();
                //Quote_Resize(sender, e);
            //}
            //Quote_Resize(sender, e);
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
            TABndx = 0;
            if (in_opera == 'C') tabControl1.SelectedIndex = 1;
            MNoPaste.Enabled = (MainMDI.arr_clpB[0, 1] != "~");
            menuItem9.Enabled = MNoPaste.Enabled;

            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);

            if (MainMDI.User.ToLower() == "ede")
            {
                disp_alsID.Visible = true;
                disp_altID.Visible = true;
                disp_solID.Visible = true;
                lQuoteID.Visible = true;
            }
            //sdfasdadad//insert piccip and above statement
            //ajouter les prix des new prices line sans code dans xl de sam
            //MessageBox.Show("2: " + lvQITEMS.Columns[2].Width.ToString() + " lv Len: " + lvQITEMS.Width.ToString());
            Size_desc();
            lrevDATE.Text = "";
            lRevTOT.Text = "";
            lAlterTOT.Text = "";
            undisp_Totals();

            //pnl_suivi.Visible = (lCurrIQID.Text != "0" && lCurrIQID.Text != "");
            switch_ToolBar(0);
            //fill_dgCpnyQT_Vide();
        }

        void Size_desc()
        {
            lvQITEMS.Columns[2].Width = lvQITEMS.Width - LENDesc;
            gbxSol.Height = tabControl1.Height - 84; //grpTOTA.Height - 32;
        }

        private void QuoteV2_Resize(object sender, EventArgs e)
        {
            Size_desc();
        }

        /*
        private void ButtonClick_toolBar1_(int btn)
        {
            if (in_opera != 'V')
            {
                this.Cursor = Cursors.WaitCursor;

                //btn = toolBar1.Buttons.IndexOf(e.Button);
                if (btnOK(btn))
                {
                    //MessageBox.Show(toolBar1.Buttons.IndexOf(e.Button).ToString());

                    if (btn == 1)
                    {
                        QimportRxx imp = new QimportRxx();
                        imp.ShowDialog();
                        if (imp.lsave.Text == "Y")
                        {
                            import_OldQInfo(imp.lIQID.Text);
                            Imp_SolID = imp.lSolid.Text;
                            Imp_IQID = imp.lIQID.Text;
                            Imp_cpnyID = imp.lcpnyID.Text;
                            gbxSol.Enabled = false;
                            MainMDI.Write_JFS("imported IQID=" + imp.lIQID.Text + " TO " + tQuoteID.Text + " date: " + System.DateTime.Now);
                            //Imprt = true;
                        }
                        else Imp_SolID = "";
                    }
                    if (btn == 3) //|| btn == 20)
                    {
                        bool fin = true;
                        if (btn == 20)
                        {
                            SAVE_CHANGE_ALS();
                            if (lCurrIQID.Text != "" && tQuoteID.Text != "") if (tQuoteID.Text != "") MainMDI.flag_QRID('Q', 'u', 0, Convert.ToUInt32(tQuoteID.Text));
                                else fin = MainMDI.Confirm("This Quote is not Saved yet ... Quit anyway ? ");
                            if (fin) this.Hide();
                        }
                        else
                        {
                            if (tQuoteID.Text != "")
                            {
                                string stId = MainMDI.Find_One_Field("select I_Quoteid from PSM_Q_IGen where Quote_ID=" + tQuoteID.Text + " AND CPNY_ID=" + lcpnyID.Text);
                                //if (Imp_cpnyID != lcpnyID.Text && stId == MainMDI.VIDE)
                                if (stId == MainMDI.VIDE || in_opera == 'E')
                                {
                                    if (Save_Q_IGen())
                                    {
                                        lQstatus.Text = lCancel.Text.Substring(0, 1);
                                        //if (Imp_SolID == "")
                                        MainMDI.flag_QRID('Q', 'f', 1, Convert.ToInt32(tQuoteID.Text));
                                        if (Imp_SolID != "") cpy_Sol(Imp_IQID, lCurrIQID.Text, Imp_SolID);
                                        lQsave.Text = "Y";
                                        if (!gbxSol.Enabled) Imprt = true;
                                    }
                                    txcb_Territo.BringToFront();
                                }
                                else
                                {
                                    if (tQuoteID.ReadOnly) MessageBox.Show("This Quote already exists for this Company..... !!!");
                                    else MessageBox.Show("Sorry, this Quote ID is already Taken,  try others IDs !!!!");
                                }
                            }
                            else { MessageBox.Show("Quote ID is empty...."); tQuoteID.Focus(); }
                        }
                    }
                    else
                    {
                        if ((btn == 21) || (lCurrIQID.Text != "0" && tQuoteID.Text != "" && (lcurSol_Status.Text != "C" || btn == 7 || btn == 4)))
                        {
                            switch (btn)
                            {
                                case 0:
                                    if (lCurrIQID.Text != "0")
                                    {
                                        if (lCancel.Visible) lQstatus.Text = "N";
                                        else lQstatus.Text = "C";
                                    }
                                    break;
                                case 4:
                                    Sol_Rep_SPP('V');
                                    //lCurrNAME.Text = (tQuoteID.Text + "S#" + tvSol.Nodes.Count.ToString());
                                    //tvSol.Nodes.Add(lCurrNAME.Text);
                                    //tvSol.Nodes[tvSol.Nodes.Count - 1].ImageIndex = 2;
                                    //tvSol.Nodes[tvSol.Nodes.Count - 1].SelectedImageIndex = 2;
                                    //tvSol.Nodes[tvSol.Nodes.Count - 1].BeginEdit();
                                    break;
                                case 5:
                                    if (lTVSel.Text == "Y")
                                    {
                                        //MessageBox.Show("Sel= " + tvSol.SelectedNode.IsSelected); Convert.ToString(tvSol.Nodes.Count + 1))
                                        //lCurrNAME.Text = "Alt#" + tvSol.SelectedNode.Nodes.Count.ToString();
                                        lCurrNAME.Text = "Alt#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
                                        if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = "Alt#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
                                        tvSol.SelectedNode.Nodes.Add(lCurrNAME.Text);
                                        tvSol.SelectedNode.Expand();
                                        tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].SelectedImageIndex = 1;
                                        tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].ImageIndex = 1;
                                        //tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].BeginEdit();
                                    }
                                    break;
                                case 6:
                                    if (lTVSel.Text == "Y")
                                    {
                                        //MessageBox.Show("Sel= " + tvSol.SelectedNode.Nodes.Count.ToString());

                                        //lCurrNAME.Text = "Alias#" + tvSol.SelectedNode.Nodes.Count.ToString();
                                        //if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = "Alias#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
                                        //lCurrNAME.Text = MainMDI.arr_EFSdict[38, MainMDI.Lang] + "#" + tvSol.SelectedNode.Nodes.Count.ToString();
                                        lCurrNAME.Text = MainMDI.arr_EFSdict[38, MainMDI.Lang] + "#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
                                        if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = MainMDI.arr_EFSdict[38, MainMDI.Lang] + "#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
                                        tvSol.SelectedNode.Nodes.Add(lCurrNAME.Text);
                                        tvSol.SelectedNode.Expand();
                                        tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].SelectedImageIndex = 0;
                                        tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].ImageIndex = 0;
                                        chk_savOVRG.Checked = false;
                                        //tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].BeginEdit();
                                    }
                                    break;
                                case 7:
                                    if (lTVSel.Text == "Y")
                                    {
                                        switch (tvSol.SelectedNode.ImageIndex)
                                        {
                                            case 2:
                                            case 4:
                                            case 5:
                                                Duplica_Sol();
                                                break;
                                            case 1:
                                                if (lcurSol_Status.Text != "C") Duplica_SPC();
                                                break;
                                            case 0:
                                            case 3:
                                                if (lcurSol_Status.Text != "C") Duplica_ALS();
                                                break;
                                        }
                                    }
                                    break;
                                case 8:
                                    if (lTVSel.Text == "Y")
                                    {
                                        DialogResult dr = MessageBox.Show("Do You want to DELETE : " + tvSol.SelectedNode.Text, "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                                        if (dr == DialogResult.Yes) del_Node();
                                    }
                                    break;
                                //case 9: //New Charger
                                    //Add_Charger();
                                    //Tosave = true;
                                    //break;
                                case 10: //add Pre-Sized Battery
                                    Add_CBR('B');
                                    Tosave = true;
                                    break;
                                case 11: //add Pre-Sized Cabinet
                                    Add_CBR('C');
                                    Tosave = true;
                                    break;
                                case 12: //add Pre-Sized Rack
                                    //PbsInfo pbsIR = new PbsInfo('R', "44");
                                    //pbsIR.ShowDialog();
                                    Add_CBR('R');
                                    Tosave = true;
                                    break;
                                case 13: //New OPTION
                                    Add_option();
                                    Tosave = true;
                                    break;
                                case 14: //New NL_ITEM_OPTION
                                    Add_NLItemOption();
                                    Tosave = true;
                                    break;
                                case 15: //add alarms
                                    if (lvQITEMS.SelectedItems.Count > 0 && lvQITEMS.SelectedItems[0].SubItems[12].Text.IndexOf("n/a U_CHARGER||") > -1)
                                    {
                                        add_ALRM_EQ(lvQITEMS.SelectedItems[0].SubItems[12].Text);
                                        Tosave = true;
                                    }
                                    break;
                                case 16: //Save Current ALS
                                    if (lQsave.Text == "Y")
                                    {
                                        if (lcurSol_Status.Text != "C" && lvQITEMS.Items.Count > 0)
                                        {
                                            Save_Q_ALL_Details();
                                            //format display 0.00
                                            AlsTOT.ReadOnly = true;
                                            AlsTOT.Text = MainMDI.A00(Tools.Conv_Dbl(AlsTOT.Text).ToString());
                                            AlsTOT.ReadOnly = false;
                                            AlterTOT.Text = MainMDI.Curr_FRMT(MainMDI.SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
                                            tAGprice.Text = MainMDI.A00(Tools.Conv_Dbl(tAGprice.Text).ToString());
                                            //Maj_AlsTOT();
                                        }
                                        else MessageBox.Show("if you want to Empty this ALIAS use DELETE button !!!!");
                                    }
                                    else MessageBox.Show("You have to save Quote-Info FIRST !!!");
                                    //#toolBar1.Buttons[16].Pushed = false;
                                    break;
                                case 17: //Del Current Als
                                    if (lvQITEMS.SelectedItems.Count > 0)
                                    {
                                        //if (lvQITEMS.SelectedItems[0].SubItems[1].Text != " ")
                                        if (MainMDI.Confirm("WANT TO DELETE ITEM / OPTION: " + lvQITEMS.SelectedItems[0].SubItems[2].Text + " ?  "))
                                        {
                                            if (lvQITEMS.SelectedItems[0].SubItems[1].Text == ".") Opt_added = false;
                                            del_Als_IO(lvQITEMS.SelectedItems[0].Index);
                                        }
                                    }
                                    else if (MainMDI.Confirm("WANT TO DELETE : " + tvSol.SelectedNode.Text + " ?  ")) del_Als(lCurSoln.Text, lCurSPCn.Text, lCurALSn.Text);
                                    Ref_ALSTOT('D');
                                    break;
                                case 18: //PBsizing
                                    try
                                    {
                                        System.Diagnostics.Process.Start(MainMDI.PBSPath + @"\PBSIZING.exe");
                                    }
                                    catch (System.Exception Oexp)
                                    {
                                        MessageBox.Show("Cannot Find PBSIZING.EXE at path: " + MainMDI.PBSPath + " System-msg: " + Oexp.Message);
                                    }
                                    break;
                                case 19: //Print
                                    //added for SYSPRO : testing existance of AG1, AG2
                                    //if ((groupBox12.Enabled) && (cbAG1.Text == MainMDI.VIDE || cbAG1.Text == "") && MainMDI.Confirm("Missing Agents......Fix Agent Name ? "))
                                        //cbAG1.Text = cbAG1.Text;
                                    if (4 > 6) cbAG1.Text = cbAG1.Text;
                                    else
                                    {
                                        string solId = MainMDI.Find_One_Field("select  Sol_LID from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'");
                                        FichWord_Config FC = new FichWord_Config(lCurrIQID.Text, solId, cbTerms.Text, lHiDelv.Text, lcurDol.Text, "");
                                        FC.ShowDialog();
                                        this.Refresh();
                                        if (FC.NXT)
                                        {
                                            pbPrintQt.Value = 0;
                                            lblWait.Text = "Please Wait,   exporting Quote to Word ...";
                                            grpPB.Visible = true;
                                            grpPB.Refresh();
                                            FichWord FW = new FichWord(this, FC);
                                            FW.Wexport();
                                        }
                                    }
                                    break;
                                case 20: //add hidden item
                                    th_nb.Text = (ItemCount + 1).ToString();
                                    th_SYS.Text = AlsTOT_orig.Text;
                                    pnl_Hidden.Visible = true;
                                    Enable_ALL(false);
                                    break;
                                case 21: //Exit
                                    //# picExit_Click(sender, e);
                                    break;
                            }
                        }
                        else
                        {
                            if (lcurSol_Status.Text == "C") MessageBox.Show("This Revission is Protected (Bleu=Converted to Order !!!!)");
                            if (lCurrIQID.Text == "0" && tQuoteID.Text == "") MessageBox.Show("You have To Save 'Quote Info' First !.....");
                        }
                    }
                    //else { if (lcurSol_Status.Text == "C") MessageBox.Show("This Revission is Protected (Bleu=Converted to Order !!!!)"); }
                    this.Cursor = Cursors.Default;
                }
                //else 
                //{
                    //if (btn == 20) this.Hide();
                    //else MessageBox.Show(MainMDI.User + ": is NOT allowed to perform this option, contact you Admin....! ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop); //MessageBox.Show(msg, "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                //}
                if (Imprt) exit_Quote();
                this.Cursor = Cursors.Default;
            }
            else MessageBox.Show("Only Viewing Allowed ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop); //MessageBox.Show(msg, "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }
        */

        void Tabs_modified()
        {
            //if (tabControl1.SelectedTab.Text == "Solutions")
            //{
            switch_ToolBar(tabControl1.SelectedIndex);
            if (tabControl1.SelectedIndex == 1)
            {
                SAVE_CHANGE_ALS();
                //switch_ToolBar(tabControl1.SelectedIndex);
                AffQNB.Visible = (tabControl1.SelectedIndex != 0);
                lQNB.Visible = AffQNB.Visible;
                toolBar1.Items[19].Visible = (!Tosave);
                if (lCurr_opera.Text == "E" || lCurr_opera.Text == "N")
                {
                    if (!Quote_loaded)
                    {
                        this.WindowState = FormWindowState.Maximized;
                        tvSol.Nodes.Clear();
                        fill_Sol();
                        toolBar1.Items[19].Visible = true;
                        if (tvSol.Nodes.Count == 0) AlS_Wizard();
                        //tvSol.Scrollable = true;
                        //tvSol.Refresh();
                    }
                }
            }
            toolBar1.Items[19].Visible = (tabControl1.SelectedIndex == 1);
        }

        private void opCan_CheckedChanged(object sender, EventArgs e)
        {
            USD_CAD_EURO();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            /*
            bool fin = true;
            if (in_opera != 'V' && MainMDI.ALWD_USR("QT_SV", false))
            {
                SAVE_CHANGE_ALS();
                if (lCurrIQID.Text != "" && tQuoteID.Text != "")
                {
                    if (tQuoteID.Text != "") MainMDI.flag_QRID('Q', 'u', 0, Convert.ToUInt32(tQuoteID.Text));
                    else fin = MainMDI.Confirm("This Quote is not Saved yet ... Quit anyway ? ");
                }
            }
            if (fin) this.Hide();
            */
            exit_Quote();
        }

        private void lvQITEMS_ColumnClick_2(object sender, ColumnClickEventArgs e)
        {
            //MessageBox.Show("2: " + lvQITEMS.Columns[2].Width.ToString() + " lv Len: " + lvQITEMS.Width.ToString());

            //MessageBox.Show("tab: " + tabControl1.Height.ToString() + " grp panel: " + grpTOTA.Height.ToString() + " grp SOL: " + gbxSol.Height.ToString());
        }

        private void splitter1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            Size_desc();
        }

        private void lrevDATE_TextChanged(object sender, EventArgs e)
        {
            tls_Revdate.Text = lrevDATE.Text;
        }

        private void lRevTOT_TextChanged(object sender, EventArgs e)
        {
            tls_lRevTOT.Text = (lRevTOT.Text != "") ? "Revision: " + lRevTOT.Text : "";
        }

        private void lrevDATE_Click(object sender, EventArgs e)
        {

        }

        private void lRevTOT_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void AlterTOT_TextChanged(object sender, EventArgs e)
        {
            tls_ALT_tot.Text = (AlterTOT.Text != "") ? "Alternative: " + AlterTOT.Text : "";
        }

        private void AlsTOT_orig_TextChanged_1(object sender, EventArgs e)
        {
            tls_SYS_tot.Text = (AlsTOT_orig.Text != "") ? "System: " + AlsTOT_orig.Text : "";
        }

        private void pbPrintQt_Click(object sender, EventArgs e)
        {

        }

        private void SaveQ_Click(object sender, EventArgs e)
        {
            if (lCurr_opera.Text != "V") Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
        }

        private void AddSol_Click(object sender, EventArgs e)
        {

        }

        private void AddAls_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true)) Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
        }

        private void duplicaa_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true)) Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
        }

        private void delALS_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true))
            {
                switch (MainMDI.User.ToLower())
                {
                    case "cfouche":
                    case "avalencia":
                    case "blombard":
                    case "bcimon":
                    case "mdimassi":
                    case "mbyad":
                    case "ede":
                    case "hnasrat":
                        Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
                        break;
                    default:
                        MessageBox.Show("sorry, you are not Allowed to Delete.......contact the admin....");
                        break;
                }
            }
        }

        private void delSelected_Click(object sender, EventArgs e)
        {
            //Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
            //MessageBox.Show("Not implemented YET......!!!!!!");
            //switch (TV_RSA)
            //{
                //case 'R':
                    //if (MainMDI.Confirm("You Want to DELETE this REVISION ?????"))
                    //{

                    //}
                    //break;
                //case 'S':
                    //if (MainMDI.Confirm("You Want to DELETE this ALTERNATIVE ?????"))
                    //{

                    //}
                    //break;
            //}
            switch (MainMDI.User.ToLower())
            {
                case "cfouche":
                case "avalencia":
                case "bcimon":
                case "mdimassi":
                case "ede":
                case "hnasrat":
                    string stsql = " SELECT   SPC_LID FROM   PSM_Q_SPCS INNER JOIN  PSM_Q_SOL ON PSM_Q_SPCS.Sol_LID = PSM_Q_SOL.Sol_LID " +
                        " WHERE         (PSM_Q_SOL.I_Quoteid =" + lCurrIQID.Text + ") and (PSM_Q_SPCS.SPC_Name = '" + lCurSPCn.Text + "') and Sol_Name='" + lCurSoln.Text + "'";
                    string id = MainMDI.Find_One_Field(stsql);
                    if (id != MainMDI.VIDE)
                    {
                        if (MainMDI.Confirm("You Want to delete this Alternative ????")) MainMDI.Exec_SQL_JFS("delete PSM_Q_SPCS where  SPC_LID=" + id, "delete alternative / delete SPC....");
                        MessageBox.Show("Alternative is Deleted................PGESCOM will leave this Quote...");
                        exit_Quote();
                    }
                    else MessageBox.Show("Cannot Delete this Alternative....please contact the admin....");
                    break;
                default:
                    MessageBox.Show("sorry, you are not Allowed to Delete.......contact the admin....");
                    break;
            }
            //MessageBox.Show("lCurSPCn=" + lCurSPCn.Text + "   NDX=" + lCurSPCNDX.Text + "  idid=" + lCurrIQID.Text + "   sol=" + lCurSoln.Text);
        }

        private void AddChrg_Click(object sender, EventArgs e)
        {
            //Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
        }

        private void addbat_Click(object sender, EventArgs e)
        {
            //Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
            if (MainMDI.ALWD_USR("QT_SV", true)) Add_BATT();
        }

        private void AddCab_Click(object sender, EventArgs e)
        {
            //Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
        }

        private void AddRack_Click(object sender, EventArgs e)
        {
            //Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
        }

        private void AddOption_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true)) Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
        }

        private void NLIO_Click(object sender, EventArgs e)
        {
            //Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));

            Add_NLItemOption_NEW();
            Tosave = true;

            //MessageBox.Show("This module is under construction, please use XL file: Multiplier schedule....");
        }

        private void AddALRM_Click(object sender, EventArgs e)
        {
            Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
        }

        private void SaveAls_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true)) Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
        }

        //private void delALS_Click(object sender, EventArgs e)
        //{
            //if (MainMDI.ALWD_USR("QT_SV", true))
            //{
                //switch (MainMDI.User.ToLower())
                //{
                    //case "cfouche":
                    //case "blombard":
                    //case "bcimon":
                    //case "mdimassi":
                    //case "ede":
                    //case "hnasrat":
                        //Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
                        //break;
                    //default:
                        //MessageBox.Show()
            //}
        //}

        private void pbs_Click(object sender, EventArgs e)
        {
            //Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
            ////PBS
            //string pbs = "http://erpserver:2552/?" + MainMDI.User.ToLower() + "=";
            //System.Diagnostics.Process.Start(pbs);

            Add_Service();
            Tosave = true;
        }

        private void Print_Click(object sender, EventArgs e)
        {
            //Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
            if (MainMDI.ALWD_USR("QT_SV", true)) Print_Quote_REVnn();
        }

        private void Exit_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true)) Tollsbar_CLicK(toolbar1_btName_ndx(sender.ToString()));
        }

        private void p4600P4500ChargerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true))
            {
                if (lCurrIQID.Text != "0" && tQuoteID.Text != "" && lcurSol_Status.Text != "C" && MainMDI.profile != 'R')
                {
                    Add_Charger('N');
                    //Add_Charger('T');
                    Tosave = true;
                }
            }
        }

        private void p5500EDIRectifierToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true))
            {
                if (lCurrIQID.Text != "0" && tQuoteID.Text != "" && lcurSol_Status.Text != "C" && MainMDI.profile != 'R')
                {
                    Add_Rectif();
                    Tosave = true;
                }
            }
        }

        private void p5500ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainMDI.User.ToLower() == "ede")
            {
                if (lCurrIQID.Text != "0" && tQuoteID.Text != "" && lcurSol_Status.Text != "C" && MainMDI.profile != 'R')
                {
                    Add_P5500();
                    Tosave = true;
                }
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true)) Sol_Rep_SPP('S');
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true)) Sol_Rep_SPP('R');
        }

        private void cbActivities_SelectedIndexChanged(object sender, EventArgs e)
        {
            txcbActivities.Text = cbActivities.Text;
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            cbActivities.BringToFront();
        }

        private void MNocopyTxt_Click(object sender, EventArgs e)
        {
            CutCopy('T');
        }

        //Agents / CMS module
        private void picSavAgents_Click(object sender, EventArgs e)
        {
            //if (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "mrouleau" || MainMDI.User.ToLower() == "mdimassi" || MainMDI.User.ToLower() == "bmustapha")

            if (MainMDI.ALWD_USR("M_AG_CMS", true))
            {
                if (Save_CMS_Agent()) MessageBox.Show("    Save Done....... ");
            }
            //else MessageBox.Show(" Acces ##############Agents List is Invalid ....");
        }

        void fill_Quot_agents()
        {
            string[] arr_ag = new string[5];
            string Stsql = "SELECT [A_CMSLID]  ,[AG_Dest]  ,[AG_Infl]   ,[AG_Eng]   ,[AG_PO] FROM [Orig_PSM_FDB].[dbo].[PSM_R_REV_agCMS] where A_CMS_IQID=" + lCurrIQID.Text;
            string res = MainMDI.Find_arr_Fields(Stsql, arr_ag);
            if (res == MainMDI.VIDE)
            {
                lcms_ag.Text = "";
                lDesti.Text = "";
                lInflu.Text = "";
                lEng.Text = "";
                lPO.Text = "";
                cbADII.BringToFront();
                cbaiII.BringToFront();
                cbaeII.BringToFront();
                cbAPII.BringToFront();
            }
            else
            {
                lcms_ag.Text = arr_ag[0];
                lDesti.Text = arr_ag[1];
                lInflu.Text = arr_ag[2];
                lEng.Text = arr_ag[3];
                lPO.Text = arr_ag[4];
                lcms_ag.BringToFront();
                lDesti.BringToFront();
                lInflu.BringToFront();
                lEng.BringToFront();
                lPO.BringToFront();
            }
        }

        bool Save_CMS_Agent()
        {
            if (optAGOKII.Checked)
            {
                if (lDesti.Text != "" && lInflu.Text != "" && lEng.Text != "" && lPO.Text != "" && (lDesti.Text != MainMDI.VIDE || lInflu.Text != MainMDI.VIDE || lEng.Text != MainMDI.VIDE || lPO.Text != MainMDI.VIDE))
                {
                    string All = (lDesti.Text != MainMDI.VIDE && lDesti.Text == lInflu.Text && lInflu.Text == lEng.Text && lEng.Text == lPO.Text) ? lDesti.Text : MainMDI.VIDE;
                    if (lcms_ag.Text == "")
                    {
                        string stSql = " INSERT INTO PSM_R_REV_agCMS ([A_CMS_IQID],[AG_ALL],[AG_Dest],[AG_Infl], [AG_Eng], [AG_PO] ) " +
                            " VALUES ('" + lCurrIQID.Text +
                            "', '" + All +
                            "', '" + lDesti.Text +
                            "', '" + lInflu.Text +
                            "', '" + lEng.Text +
                            "', '" + lPO.Text + "')";

                        MainMDI.Exec_SQL_JFS(stSql, "CMS_Agents  (quote)");
                        MainMDI.Exec_SQL_JFS("update  PSM_Q_IGen set [AGency]='1' where i_Quoteid=" + lCurrIQID.Text, " Agents added..(quote).");
                        return true;
                    }
                    else
                    {
                        //stSql = "UPDATE " + Bord_TNM + " SET " + " [brd_SN]='" + tBrdSN.Text + "', [brd_Ver]='" + tBver.Text + "', [firmwr_Ver]='" + tSver.Text + "',[b_connTo]='" + cbtConTo.Text + "' WHERE R_BrdLID=" + ed_lvBRD.Items[cur_LV_ndx].SubItems[0].Text;

                        string stSql = " UPDATE PSM_R_REV_agCMS SET [AG_Dest]='" + lDesti.Text +
                            "', [AG_Infl]='" + lInflu.Text +
                            "', [AG_ALL]='" + All +
                            "', [AG_Eng]='" + lEng.Text +
                            "', [AG_PO]='" + lPO.Text + "' where A_CMSLID=" + lcms_ag.Text;
                        MainMDI.Exec_SQL_JFS(stSql, " Agents Modifies (quote)");
                        return true;
                    }
                }
                else MessageBox.Show(" Agents List is Invalid ....");
            }
            else
            {
                string stat = (optUNDEF.Checked) ? "2" : "0";

                MainMDI.Exec_SQL_JFS("update PSM_Q_IGen set [AGency]='" + stat + "' where i_Quoteid=" + lCurrIQID.Text, " No Agents... (quote)");
                MainMDI.Exec_SQL_JFS("delete   PSM_R_REV_agCMS  where A_CMS_IQID=" + lCurrIQID.Text, " NO Agents / Undefined  (quote)");
                return true;
            }
            return false;
        }

        private void cbADII_SelectedIndexChanged(object sender, EventArgs e)
        {
            lDesti.Text = cbADII.Text;
        }

        private void modif_AG_Click(object sender, EventArgs e)
        {
            cbADII.Text = lDesti.Text;
            cbaiII.Text = lInflu.Text;
            cbaeII.Text = lEng.Text;
            cbAPII.Text = lPO.Text;

            cbADII.BringToFront();
            cbaiII.BringToFront();
            cbaeII.BringToFront();
            cbAPII.BringToFront();
        }

        private void optUNDEF_CheckedChanged(object sender, EventArgs e)
        {
            LADII.Text = "0";
            lAIII.Text = "0";
            lAEII.Text = "0";
            lAPII.Text = "0";
            gbxAgent.Enabled = false;
        }

        private void picdup_Click(object sender, EventArgs e)
        {

        }

        private void optNOAGII_CheckedChanged(object sender, EventArgs e)
        {
            LADII.Text = "0";
            lAIII.Text = "0";
            lAEII.Text = "0";
            lAPII.Text = "0";
            gbxAgent.Enabled = false;
        }

        private void cbaeII_SelectedIndexChanged(object sender, EventArgs e)
        {
            lEng.Text = cbaeII.Text;
        }

        private void cbaiII_SelectedIndexChanged(object sender, EventArgs e)
        {
            lInflu.Text = cbaiII.Text;
        }

        private void cbAPII_SelectedIndexChanged(object sender, EventArgs e)
        {
            lPO.Text = cbAPII.Text;
        }

        private void optAGOKII_CheckedChanged(object sender, EventArgs e)
        {
              gbxAgent.Enabled = true;
        }

        private void btnALL_Click(object sender, EventArgs e)
        {
            if (cbADII.Text != "")
            {
                cbaeII.Text = cbADII.Text;
                cbaiII.Text = cbADII.Text;
                cbAPII.Text = cbADII.Text;
            }
        }

        private void nEWRevisionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true)) Sol_Rep_SPP('V');
        }

        private void printALSS_Click(object sender, EventArgs e)
        {
            printQSum();
        }

        private void picNum_Click(object sender, EventArgs e)
        {
            Renum_SYS();
        }

        void Renum_SYS()
        {
            int nm = 1;
            for (int i = 0; i < lvQITEMS.Items.Count; i++)
            {
                if (lvQITEMS.Items[i].SubItems[1].Text != " ")
                {
                    lvQITEMS.Items[i].SubItems[1].Text = (nm++).ToString();
                }
            }
        }

        private void picNum_MouseHover(object sender, EventArgs e)
        {
            lrenum.Visible = true;
        }

        private void picNum_DragLeave(object sender, EventArgs e)
        {
            //lrenum.Visible = false;
        }

        private void picNum_DragOver(object sender, DragEventArgs e)
        {
            //lrenum.Visible = true;
        }

        private void picNum_MouseLeave(object sender, EventArgs e)
        {
            lrenum.Visible = false;
        }

        void XPNDTV_SOL()
        {
            for (int n = 0; n < tvSol.Nodes.Count; n++)
            {
                tvSol.Nodes[n].Expand();
                for (int m = 0; m < tvSol.Nodes[n].Nodes.Count; m++) tvSol.Nodes[n].Nodes[m].Expand();
            }
        }

        void CLPSTV_SOL()
        {
            for (int n = 0; n < tvSol.Nodes.Count; n++) tvSol.Nodes[n].Collapse();
        }

        void XPND_CLPS_TV()
        {
            if ((xpndd.Text == "Expand all"))
            {
                XPNDTV_SOL();
                xpndd.Text = "Collapse all";
            }
            else
            {
                CLPSTV_SOL();
                xpndd.Text = "Expand all";
            }
        }

        private void xpndd_Click(object sender, EventArgs e)
        {
            XPND_CLPS_TV();
            //if (MainMDI.User == "ede")
            //{
                //string solId = MainMDI.Find_One_Field("select  Sol_LID from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'");
                //FichWord_Config FC = new FichWord_Config(lCurrIQID.Text, solId, cbTerms.Text, lHiDelv.Text, lcurDol.Text, "");
                //FC.ShowDialog();
                //this.Refresh();
                //if (FC.NXT)
                //{
                    //pbPrintQt.Value = 0;
                    //lblWait.Text = "Please Wait,   exporting Quote to Word ...";
                    //grpPB.Visible = true;
                    //grpPB.Refresh();
                    //FichWord FW = new FichWord(this, FC);
                    ////FW.Wexport();
                    //FW.QuoteTO_XLfile();
                //}
            //}
        }

        void TVsol_Refresh()
        {
            lvQITEMS.Items.Clear();
            tvSol.Nodes.Clear();
            fill_Sol();
            toolBar1.Items[19].Visible = true;
            XPNDTV_SOL();
        }

        private void picOutSales_Click(object sender, EventArgs e)
        {

        }

        private void button17_Click(object sender, EventArgs e)
        {
            //email_AGENCIES();
        }

        //must be added to quotIII 
        private bool Save_Q_IGen()
        {
            bool t1 = false;
            int Alrms = 0;
            string loindate = "01/01/2020";
            if (Entry_OK(ref Alrms))
            {
                if (Valid_Curr())
                {
                    if (lCpmgr.Text == "0") lCpmgr.Text = lContact_ID.Text;
                    string Ctoprimax = (chk_CCP.Checked) ? "1" : "0";
                    if (QReq.Text == "") QReq.Text = cbCompanyy.Text + " (" + Q_sysPcod.Text + ")";
                    if (cbActivities.Text == "") cbActivities.Text = lActivty.Text;
                    if (tProjNAME.Text == "") tProjNAME.Text = tQuoteID.Text + "-" + cbCompanyy.Text.Substring(0, 3);
                    if (lCurr_opera.Text == "N")
                    {
                        string stSql = "INSERT INTO PSM_Q_IGen ([Quote_ID],[CPNY_ID],[Employ_ID], " +
                            " [ProjectName],[Opndate],[Clsdate],[Contact_ID],[Cust_Mult],  " +
                            " [Term_ID],[Via_ID],[IncoTerm_ID], " +
                            " [SI],[SO],[SE],[SP],[SS], " +
                            " [AD],[AI],[AE],[AP],[AS],[AG_YN], " +
                            " [QA],[SA],[PA],[IA] , " +
                            " [Lang]," +
                            " [DEL]," + " [IPmgr]," + " [CPmgr]," + " [curr]," +
                            " [Cmnt],[SP_AG1], [SP_AG1_id],[SP_AG2],[PrjActivty],[Quot_Req],[CtoPrimax],[Qtype], [SP_AG2_id]) VALUES ('" +
                            tQuoteID.Text + "', '" +
                            lcpnyID.Text + "', '" +
                            lEmp_ID.Text + "', '" +
                            tProjNAME.Text.Replace("'", "''") + "', " +
                            MainMDI.SSV_date(tOpendate.Text) + ", " +
                            MainMDI.SSV_date(loindate) + ", '" +
                            lContact_ID.Text + "', '" +
                            tCust_Mult.Text + "', '" +
                            lTerm_ID.Text + "', '" +
                            lVia_ID.Text + "', '" +
                            lIncoT_ID.Text + "', '" +
                            lSi.Text + "', '" +
                            lSO.Text + "', '" +
                            lSE.Text + "', '" +
                            lSP.Text + "', '" +
                            cbSS.Text + "', '" +
                            lAD.Text + "', '" +
                            lAI.Text + "', '" +
                            lAE.Text + "', '" +
                            lAP.Text + "', '" +
                            cbAS.Text + "', '" +
                            lAG_YN.Text + "', '" +
                            lQA.Text.Replace("'", "''") + "', '" +
                            lSA.Text.Replace("'", "''") + "', '" +
                            lPA.Text.Replace("'", "''") + "', '" +
                            lIA.Text.Replace("'", "''") + "', '" +
                            lLang.Text + "', '" +
                            lQstatus.Text + "', '" + lIpmgr.Text + "', '" + lCpmgr.Text + "', '" + lcurDol.Text.Substring(0, 1) + "', '" +
                            tGCmnt.Text + "', '" +
                            cbAG1.Text.Replace("'", "''") + "', '" +
                            lAG1CD.Text.Replace("'", "''") + "', '" +
                            cbAG2.Text.Replace("'", "''") + "', '" +
                            txcbActivities.Text + "', '" +
                            QReq.Text.Replace("'","''") + "', '" +
                            Ctoprimax + "', '" +
                            "2" + "', '" + //type of quote 2:old 3:new fashion
                            lExtSid.Text + "')"; //lAG2CD.Text.Replace("'", "''") + "')";
                        t1 = MainMDI.ExecSql(stSql);
                        MainMDI.Write_JFS(stSql);
                        lSave.Text = "S";
                        lCurr_opera.Text = "E";
                        in_opera = 'E';
                        string stId = MainMDI.Find_One_Field("select I_Quoteid from PSM_Q_IGen where Quote_ID=" + tQuoteID.Text + " AND CPNY_ID=" + lcpnyID.Text);
                        //MessageBox.Show("ID= " + MainMDI.stXP + "     foundID= " + stId);
                        //modify Quote III
                        if (stId != MainMDI.VIDE) { lCurrIQID.Text = stId; lQuoteID.Text = lCurrIQID.Text; } //modify Quote III
                        //modify Quote III
                        else MessageBox.Show("Error Occurs while Saving this Quote...contact your Admin !!!" + MainMDI.stXP);
                    }
                    else
                    {
                        //Update
                        //lSS.Text = (cbSS.Text == "") ? "0" : cbSS.Text;
                        //lAS.Text = (cbAS.Text == "") ? "0" : cbAS.Text;
                        string stSql = "UPDATE PSM_Q_IGen SET " +
                            " [Quote_ID]=" + tQuoteID.Text + ", " +
                            " [CPNY_ID]=" + lcpnyID.Text + ", " +
                            " [Employ_ID]=" + lEmp_ID.Text + ", " +
                            " [ProjectName]='" + tProjNAME.Text.Replace("'", "''") + "', " +
                            " [Opndate]=" + MainMDI.SSV_date(tOpendate.Value.ToShortDateString()) + ", " +
                            " [Clsdate]=" + MainMDI.SSV_date(loindate) + ", " + //must use r_clsdate when filling LVQUOTES
                            " [Contact_ID]=" + lContact_ID.Text + ", " +
                            " [Term_ID]=" + lTerm_ID.Text + ", " +
                            " [Via_ID]=" + lVia_ID.Text + ", " +
                            " [IncoTerm_ID]=" + lIncoT_ID.Text + ", " +
                            " [SI]=" + lSi.Text + ", " +
                            " [SO]=" + lSO.Text + ", " +
                            " [SE]=" + lSE.Text + ", " +
                            " [SP]=" + lSP.Text + ", " +
                            " [SS]='" + cbSS.Text + "', " +
                            " [AD]=" + lAD.Text + ", " +
                            " [AI]=" + lAI.Text + ", " +
                            " [AE]=" + lAE.Text + ", " +
                            " [AP]=" + lAP.Text + ", " +
                            " [AS]='" + cbAS.Text + "', " +
                            " [AG_YN]='" + lAG_YN.Text + "', " +
                            " [QA]='" + lQA.Text.Replace("'", "''") + "', " +
                            " [SA]='" + lSA.Text.Replace("'", "''") + "', " +
                            " [PA]='" + lPA.Text.Replace("'", "''") + "', " +
                            " [IA]='" + lIA.Text.Replace("'", "''") + "', " +
                            " [Lang]='" + lLang.Text + "', " +
                            " [DEL]='" + lQstatus.Text + "', " +
                            " [IPmgr]='" + lIpmgr.Text + "', " +
                            " [CPmgr]='" + lCpmgr.Text + "', " +
                            " [curr]='" + lcurDol.Text.Substring(0, 1) + "', " +
                            " [SP_AG1]='" + cbAG1.Text.Replace("'", "''") + "', " +
                            " [SP_AG1_id]='" + lAG1CD.Text.Replace("'", "''") + "', " +
                            " [SP_AG2]='" + cbAG2.Text.Replace("'", "''") + "', " +
                            " [SP_AG2_id]='" + lExtSid.Text + "', " +
                            " [PrjActivty]='" + txcbActivities.Text + "', " +
                            " [Quot_Req]='" + QReq.Text.Replace("'", "''") + "', " +
                            " [CtoPrimax]='" + Ctoprimax + "', " +
                            " [Cmnt]='" + tGCmnt.Text.Replace("'", "''") + "' " +
                            " WHERE [i_Quoteid]=" + lCurrIQID.Text;
                        t1 = MainMDI.ExecSql(stSql);
                        MainMDI.Write_JFS(stSql);
                        lSave.Text = "U";
                        //" [SP_AG2_id]='" + lAG2CD.Text.Replace("'", "''") + "', " +
                    }
                }
                else
                {
                    MessageBox.Show("Sorry, can not Save: Currency does not match with SYSPRO CODE   (U,E,C)....");
                    return false;
                }
            }
            else
            {
                if (Alrms == 0) MessageBox.Show("You missed some Fields....");
                return false;
            }
            return t1;
        }

        void Print_Quote_REVnn()
        {
            string solId = MainMDI.Find_One_Field("select  Sol_LID from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'");
            FichWord_Config FC = new FichWord_Config(lCurrIQID.Text, solId, cbTerms.Text, lHiDelv.Text, lcurDol.Text, "");
            FC.ShowDialog();
            this.Refresh();
            if (FC.NXT)
            {
                pbPrintQt.Value = 0;
                lblWait.Text = "Please Wait,   exporting Quote to Word ...";
                grpPB.Visible = true;
                grpPB.Refresh();
                FichWord FW = new FichWord(this, FC);
                FW.Wexport();
                //if (FC.chk_VQ.Checked) FW.QuoteTO_XLfile();
                if (FC.chk_VQ.Checked) FW.QT_Send_ALL_QuoteTO_XL();
                if (FC.chkSendAG.Checked) email_AGENCIES(FC);
                //else MainMDI.send_email("pgescom@primax-e.com", "hedebbab@primax-e.com", "Agents email", " email Not SENT to AGENT\n Q#:" + AffQNB.Text + "\n inside Sales:" + cbEmploy.Text + "\n User:" + MainMDI.User);
            }
        }

        void email_AGENCIES(FichWord_Config FC)
        {
            string G_TXT = "Primax has sent the following proposal: \n", CC = "",
            //_subject = "PRIMAX Quotation";
            _subject = "Quote#: " + AffQNB.Text;
            double TOTAG = 0;
            string TXT = "\n" + "Quote#: " + AffQNB.Text + " " + lCurSoln.Text;
            TXT += "\n" + "Project Name: " + tProjNAME.Text;
            TXT += "\n" + "Customer: " + cbCompanyy.Text;
            TXT += "\n" + "Contact Name: " + cbContacts.Text;
            TXT += "\n" + "Phone #: " + lPhone.Text;

            TXT += "\n\nInside sale: " + cbEmploy.Text + "\nTel: +514-459-9990 ex.:" + lEExt.Text + "\nEmail: " + lemail.Text;
            string OutSal = (lSP_Name.Text.Length > 4) ? lSP_Name.Text.Substring(4) : lSP_Name.Text;
            TXT += "\n\n" + "Outside sale: " + OutSal + "\nCell#: " + lOutSaleCell.Text + "\nEmail: " + lOutSaleemail.Text;
            CC = lOutSaleemail.Text;
            string SavTXT = TXT.Replace("\n", "~~");
            TXT += "\n\n" + "Quote consists of: ";
            int cnt = 1;
            for (int i = 0; i < FC.lvPTC.Items.Count; i++)
            {
                if (FC.lvPTC.Items[i].SubItems[7].Text == "S")
                {
                    TXT += "\n" + (cnt++).ToString() + " - " + FC.lvPTC.Items[i + 1].SubItems[0].Text.TrimStart(); //+ "  $" + FC.lvPTC.Items[i].SubItems[6].Text.TrimStart();
                    TOTAG += Tools.Conv_Dbl(FC.lvPTC.Items[i].SubItems[6].Text.TrimStart().Replace(" ", ""));
                }
            }
            //string TOT = "0"; //FC.lvPTC.Items[i].SubItems[6].Text.TrimStart();
            TXT += "\n" + "TOTAL: " + "$" + TOTAG.ToString();
            TXT += "\n\n\n\n" + "Best regards";
            MainMDI.Exec_SQL_JFS("update  [PSM_Q_IGen] set [AGmail]='" + SavTXT + " date='" + DateTime.Now.ToShortDateString() + "'  where i_Quoteid=" + lCurrIQID.Text, " save TXT AGency Mail....");
            if (MainMDI.emailIsValid(CC)) Outlook_email(FC.lAG_email.Text, CC, _subject, TXT);
            else MessageBox.Show("Sorry, Message was not sent to Agency because Outside sale has NO E-MAIL.......");
        }

        void find_Sys_RevNN(string Ilrev, string[] Sys)
        {

        }

        void Outlook_email(string TO, string CC, string Subject, string txt)
        {
            try
            {
                List<string> lstAllRecipients = new List<string>();
                //Below is hardcoded - can be replaced with db data
                lstAllRecipients.Add(TO);
                //lstAllRecipients.Add("chandan.kumarpanda@testmail.com");

                Outlook.Application outlookApp = new Outlook.Application();
                Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.Inspector oInspector = oMailItem.GetInspector;
                //Thread.Sleep(10000);

                //Recipient
                Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;
                foreach (String recipient in lstAllRecipients)
                {
                    Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient);
                    oRecip.Resolve();
                }
                //Add CC
                Outlook.Recipient oCCRecip = oRecips.Add(CC);
                oCCRecip.Type = (int)Outlook.OlMailRecipientType.olCC;
                oCCRecip.Resolve();

                //Add Subject
                oMailItem.Subject = Subject;
                oMailItem.Body = txt;

                //body, bcc etc...

                //Display the mailbox
                oMailItem.Display(true);
            }
            catch (Exception objEx)
            {
               MessageBox.Show("Outlook ERROR: " + objEx.ToString());
            }
        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tatt_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click(object sender, EventArgs e)
        {

        }

        private void button19_Click(object sender, EventArgs e)
        {

        }

        private void bREV_Click(object sender, EventArgs e)
        {
            //TVsol_Refresh();
            dlg_Seq_RSA myfrm = new dlg_Seq_RSA("R", lQuoteID.Text);
            myfrm.ShowDialog();
            if (myfrm.lSave.Text == "Y")
            {
                MessageBox.Show("PGESCOM will leave this Quote...");
                exit_Quote();
            }
        }

        private void picCIP_Click(object sender, EventArgs e)
        {

        }

        private void QuotesList_Click(object sender, EventArgs e)
        {
 
        }

        private void pastSystemToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void toolBar1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            //lTLSndx.Text = toolbar1_btName_ndx(sender.ToString()).ToString();
        }

        private void Configo_Click(object sender, EventArgs e)
        {
            GoConfigo();
        }

        private void btn_rst_Click(object sender, EventArgs e)
        {
            tAqty.Text = MainMDI.VIDE;
            tAmult.Text = MainMDI.VIDE;
            tAup.Text = MainMDI.VIDE;
            cbCategory.Text = MainMDI.VIDE;
        }

        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void p600SwitchModeFlexPowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true))
            {
                if (lCurrIQID.Text != "0" && tQuoteID.Text != "" && lcurSol_Status.Text != "C" && MainMDI.profile != 'R')
                {
                    Add_SWMD_P600_FP();
                    Tosave = true;
                }
            }
        }

        private void tmult_DoubleClick(object sender, EventArgs e)
        {
            tmult.ReadOnly = false;
        }

        private void tAmult_DoubleClick(object sender, EventArgs e)
        {
            tAmult.ReadOnly = false;
        }

        private void picALRM_mltp_Click(object sender, EventArgs e)
        {

        }

        private void p600SwitchMode_EZ_SWAP_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true))
            {
                if (lCurrIQID.Text != "0" && tQuoteID.Text != "" && lcurSol_Status.Text != "C" && MainMDI.profile != 'R')
                {
                    Add_SWMD_P600_EZ();
                    Tosave = true;
                }
            }
        }

        private void PicQT_cpny_Click(object sender, EventArgs e)
        {
            if (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "mbyad" || MainMDI.User.ToLower() == "mrouleau" || MainMDI.User.ToLower() == "vbalan")
            {
                fill_dgCpnyQT();
                QReq.Visible = false;
            }
            else MessageBox.Show("Sorry, ACCESS DENIED !!!!!!!! ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop); //MessageBox.Show(msg, "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
        }

        private void menuItem11_Click(object sender, EventArgs e)
        {

        }

        private void tls_PL_Click(object sender, EventArgs e)
        {
            if (MainMDI.User.ToLower() == "hnasrat" || MainMDI.User.ToLower() == "mbyad" || MainMDI.User.ToLower() == "ede")
            {
                if (MainMDI.ALWD_USR("QT_SV", true))
                {
                    if (lCurrIQID.Text != "0" && tQuoteID.Text != "" && lcurSol_Status.Text != "C" && MainMDI.profile != 'R')
                    {
                        Add_Charger('T');
                        Tosave = true;
                    }
                }
            }
            else MessageBox.Show("Access Denied....");
        }

        private void bSYS_Click(object sender, EventArgs e)
        {
            string lcurSOLid = MainMDI.Find_One_Field("select Sol_LID from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'");
            if (lcurSOLid != MainMDI.VIDE)
            {
                string lcurSPCid = MainMDI.Find_One_Field("SELECT  [SPC_LID]  FROM [Orig_PSM_FDB].[dbo].[PSM_Q_SPCS] where Sol_LID=" + lcurSOLid + " and SPC_Name='" + lCurSPCn.Text.Replace("'", "''") + "'");
                if (lcurSPCid != MainMDI.VIDE)
                {
                    dlg_Seq_RSA myfrm = new dlg_Seq_RSA("A", lcurSPCid);
                    myfrm.ShowDialog();
                    if (myfrm.lSave.Text == "Y")
                    {
                        MessageBox.Show("PGESCOM will leave this Quote...");
                        exit_Quote();
                    }
                }
            }
        }

        private void bALT_Click(object sender, EventArgs e)
        {
            string lcurSOLid = MainMDI.Find_One_Field("select Sol_LID from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'");
            if (lcurSOLid != MainMDI.VIDE)
            {
                dlg_Seq_RSA myfrm = new dlg_Seq_RSA("S", lcurSOLid);
                myfrm.ShowDialog();
                if (myfrm.lSave.Text == "Y")
                {
                    MessageBox.Show("PGESCOM will leave this Quote...");
                    exit_Quote();
                }
            }
        }

        private void AddChrgDD_Click(object sender, EventArgs e)
        {

        }

        private void btnXL_Click(object sender, EventArgs e)
        {
            //string solId = MainMDI.Find_One_Field("select  Sol_LID from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'");
            //FichWord_Config FC = new FichWord_Config(lCurrIQID.Text, solId, cbTerms.Text, lHiDelv.Text, lcurDol.Text, "");
            //FichWord FW = new FichWord(this, FC);
            //FW.QT_Send_ALL_QuoteTO_XL();

            //LstNdx = 22;
            //if (LstNdx >= 17)
            //{
                //toolBar1.Items[LstNdx++].Visible = true;
                //toolBar1.Refresh();
            //}
            //else LstNdx = 17;
        }

        private void btnFlow_Click(object sender, EventArgs e)
        {

        }

        private void p600SwitchModeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true))
            {
                if (lCurrIQID.Text != "0" && tQuoteID.Text != "" && lcurSol_Status.Text != "C" && MainMDI.profile != 'R')
                {
                    Add_SWMD_P600();
                    Tosave = true;
                }
            }
        }

        private void chk_savOVRG_CheckedChanged(object sender, EventArgs e)
        {
            check_OVRG();
        }

        private void picsave_suivi_Click(object sender, EventArgs e)
        {
            if (endCustomer.Text != "" && EAU.Text != "")
            {
                string stat = "2";
                if (cbstatQuote.Text == "Won") stat = "1";
                if (cbstatQuote.Text == "Lost") stat = "0";
                string stSql = "UPDATE [dbo].[PSM_Q_IGen]    SET " +
                    "[endCustomer] ='" + endCustomer.Text +
                    "' ,[EAU] ='" + EAU.Text +
                    "' ,[sucRate] = '" + sucRate.Text +
                    "' ,[stage] = '" + cbstage.Text +
                    "' ,[projecteddt] = " + MainMDI.SSV_date(dtpproj.Text) +
                    "  , [statQuote] = '" + stat +
                    "' ,[statReason] = '" + cbstatReason.Text + "' WHERE i_Quoteid=" + lCurrIQID.Text;
                MainMDI.Exec_SQL_JFS(stSql, " update quote_suivi");
            }
            else MessageBox.Show("fill empty fields...... !!!!");
        }

        void GoConfigo()
        {
            GenConfigi_Quotes myFRM = new GenConfigi_Quotes();
            myFRM.ShowDialog();
            if (myFRM.lCopy.Text == "Y")
            {
                MNoPaste.Enabled = true;
                menuItem9.Enabled = true;
            }
        }

        private void picSPcode_Click(object sender, EventArgs e)
        {

        }

        private void button18_Click_1(object sender, EventArgs e)
        {
            //if (MainMDI.User.ToLower() == "ede")
            //{
                //Chargerdlg_RREV frmchdlgrev = new Chargerdlg_RREV('0', lvQITEMS.Items[lvQITEMS.SelectedItems[0].Index].SubItems[12].Text, MainMDI.VIDE, lvQITEMS.Items[lvQITEMS.SelectedItems[0].Index].SubItems[9].Text);
                ////this.Hide();
                //frmchdlgrev.ShowDialog();
                ////if (frmchdlgrev.lSave.Text == "Y") MessageBox.Show("SaveeeeeeeeeeeeeeeeeeeeeeeeeeeD");
            //}
        }

        //Configo Quote
        //SELECT configo_Quotes.C_Qlid, configo_Quotes.QID, configo_Quotes.Customer, configo_Quotes.C_date, configo_Quotes.cust_ref, configo_Quotes.prjName, configo_Quotes.userid, Configo_Quotes_details.detID,
        //Configo_Quotes_details.Qlid, Configo_Quotes_details.affID, Configo_Quotes_details.optref, Configo_Quotes_details.Itemdesc, Configo_Quotes_details.qty, Configo_Quotes_details.mult, Configo_Quotes_details.uprice,
        //Configo_Quotes_details.xchng, Configo_Quotes_details.ext, Configo_Quotes_details.leadtime, Configo_Quotes_details.rnk, Configo_Quotes_details.pn, Configo_Quotes_details.tecval, Configo_Quotes_details.itmgrp,
        //Configo_Quotes_details.sext, Configo_Quotes_details.aext, Configo_Quotes_details.itmid
        //FROM            configo_Quotes INNER JOIN Configo_Quotes_details ON configo_Quotes.C_Qlid = Configo_Quotes_details.Qlid
        //WHERE        (configo_Quotes.QID = 1056)
        //ORDER BY configo_Quotes.QID
    }
}