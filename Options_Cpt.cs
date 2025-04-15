using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using EAHLibs;

namespace PGESCOM
{
    public partial class Options_Cpt : Form
    {
        string in_cpt_NM = "", in_MAN_NM = "", in_FAM_NM = "";
        string lcbOptGrp = "", r_tOptCmnt = "", r_tERef = "", r_tFRef = "", r_type = "";
        private Lib1 Tools = new Lib1();

        public Options_Cpt(string x_cpt_NM, string x_MAN_NM, string x_FAM_NM)
        {
            InitializeComponent();
            in_cpt_NM = x_cpt_NM;
            in_MAN_NM = x_MAN_NM; in_FAM_NM = x_FAM_NM;
            fill_cbCPTs();
            cbCpts.Text = (in_cpt_NM == "") ? cbCpts.Items[0].ToString(): in_cpt_NM;
            if (cbManuf.Items.Count > 0) cbManuf.Text = (in_MAN_NM == "") ? cbManuf.Items[0].ToString() : in_MAN_NM;
            if (cbPFamily.Items.Count > 0) cbPFamily.Text = (in_FAM_NM == "") ? cbPFamily.Items[0].ToString() : in_FAM_NM;
        }

        private void fill_cbCPTs()
        {
            string stSql = "select * FROM [COMPNT_LIST] order by Component_Name";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            cbCpts.Items.Clear();
            while (Oreadr.Read())
            {
                cbCpts.Items.Add(MainMDI.optDesc(0, Oreadr["Component_Name"].ToString()) + "         (" + Oreadr["COMPONENT_REF"].ToString() + ")");
            }
            OConn.Close();
        }

        private void btnSavCpts(object sender, System.EventArgs e)
        {
            if (MainMDI.ALWD_USR("CPT_SV", true))
            {
                update_Compnt_List();
            }
        }

        private void update_Compnt_List()
        {
            if (r_type != ltype.Text || r_tERef != tERef.Text || r_tFRef != tFRef.Text || r_tOptCmnt != tOptCmnt.Text)
            {
                string descEF = (tFRef.Text != "") ? tERef.Text + " ~ " + tFRef.Text : tERef.Text;

                try
                {
                    string stSql = "UPDATE COMPNT_LIST SET " +
                        " [Compnt_Type]='" + ltype.Text +
                        "', [Component_Name]='" + descEF.Replace("'", "''") +
                        "', [Ref_cmnt]='" + tOptCmnt.Text.Replace("'", "''") +
                        "'  WHERE [Component_ID]=" + lcptLID.Text;
                    MainMDI.ExecSql(stSql);
                    MainMDI.Write_JFS(stSql);
                    r_type = ltype.Text;
                    //btnSavOpt.Enabled = false;
                    //btnCancelOpt.Enabled = false; 
                }
                catch (SqlException Oexp)
                {
                    MessageBox.Show("Error occurs When Updating Component Type ...= " + Oexp.Message);
                }

            }
        }

        private void Sav_BRD_Click(object sender, EventArgs e)
        {
            update_Compnt_List();
        }

        private void NewCPT_Click(object sender, EventArgs e)
        {
            tCptName.BackColor = Color.Lavender;
            tCptName.ReadOnly = false;
        }

        private void btnSavOpt_Click_1(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void lcptLID_Click(object sender, EventArgs e)
        {

        }

        private void cbCpts_SelectedIndexChanged(object sender, EventArgs e)
        {
            Sel_CPT();
        }

        private void Sel_CPT()
        {
            lcbOptGrp = deco_desc_Ref(cbCpts.Text);
            tFRef.Clear(); tERef.Clear();
            cbManuf.Items.Clear(); 
            fill_CPTInfo(lcbOptGrp);
            tCptName.Text = cbCpts.Text;
            //loptID_orig.Text = (cpt_price_orig != MainMDI.VIDE) ? MainMDI.Find_One_Field("select Component_ID from COMPNT_LIST where COMPONENT_REF='" + cpt_price_orig + "'") : loptID.Text;
            aff_Manufac(Convert.ToInt32(lcptLID.Text));
            if (cbManuf.Items.Count > 0) cbManuf.Text = cbManuf.Items[0].ToString();
        }

        private void aff_Manufac(int cpt_Lid)
        {
            string stSql = "SELECT COMPNT_MANUFAC.MANUFAC_ID, COMPNT_MANUFAC.MANUFAC_NAME " +
                " FROM COMPNT_MANUFAC_FAMILY INNER JOIN COMPNT_MANUFAC ON " +
                " COMPNT_MANUFAC_FAMILY.Manufac_ID = COMPNT_MANUFAC.MANUFAC_ID GROUP " +
                " BY COMPNT_MANUFAC.MANUFAC_ID, COMPNT_MANUFAC.MANUFAC_NAME, " +
                "COMPNT_MANUFAC_FAMILY.Compnt_ID HAVING (((COMPNT_MANUFAC_FAMILY.Compnt_ID)=" + cpt_Lid + ")) ORDER BY COMPNT_MANUFAC.MANUFAC_NAME";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            cbManuf.Items.Clear();
            while (Oreadr.Read())
            {
                cbManuf.Items.Add(Oreadr["MANUFAC_NAME"].ToString());
            }
            OConn.Close();
        }

        private string deco_desc_Ref(string st)
        {
            int ipos = st.IndexOf("         (", 0);
            if (ipos > -1) return st.Substring(ipos + 10, st.Length - ipos - 11);
            return MainMDI.VIDE;
        }

        private void Aff_CptType(string t)
		{
			chkDef.Enabled = (!("TS".IndexOf(t) > -1));
			chkDef.Enabled = (("CDEF".IndexOf(t) > -1));
			switch (t)
			{
				//a charger_pricing component C changes to D if it becomes 
				//a Charger default option 

				case "E": //default + Primax product (Pricing..)
					chkDef.Checked = true;
					optPrimax.Checked = true;
					break;
				case "D": //default + Buy & Sell product (Pricing..)
					chkDef.Checked = true;
					optBaS.Checked = true;
					break;
					//by Default a component is C: not default && Primax Product
					//so C == S STUV
				case "C": //Not Default + Primax product (Pricing..)
				case "S": //Not Default + Primax product (not Pricing...)
					if (chkDef.Enabled) chkDef.Checked = false;
					optPrimax.Checked = true;
					break;
				case "F": //Not Default + Buy & Sell product (Pricing..)
				case "T": //Not Default + Buy & Sell product (not Pricing...)
					if (chkDef.Enabled) chkDef.Checked = false;
					optBaS.Checked = true;
					break;
			}
		}

        private void fill_CPTInfo(string stref)
        {
            string stSql = "select * FROM [COMPNT_LIST] where (Compnt_Type='S' or Compnt_Type='D' or Compnt_Type='F' or Compnt_Type='C' or Compnt_Type='E' or Compnt_Type='T') and COMPONENT_REF='" + stref + "' order by COMPONENT_REF";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                tERef.Text = MainMDI.optDesc(0, Oreadr["Component_Name"].ToString());
                tFRef.Text = MainMDI.optDesc(1, Oreadr["Component_Name"].ToString());
                tOptCmnt.Text = Oreadr["Ref_cmnt"].ToString();
                r_tOptCmnt = tOptCmnt.Text;
                r_tERef = tERef.Text;
                r_tFRef = tFRef.Text;
                lcptLID.Text = Oreadr["Component_ID"].ToString();
                Aff_CptType(Oreadr["Compnt_Type"].ToString());
                ltype.Text = Oreadr["Compnt_Type"].ToString();
                tSort.Text = Oreadr["Sort_flds"].ToString();
                r_type = ltype.Text;
                tPX_Code.Text = Oreadr["PX_Code"].ToString();

                //lCat1.Text = Oreadr["CatName1"].ToString();
                //lCat2.Text = Oreadr["CatName2"].ToString();
                //lCat3.Text = Oreadr["CatName3"].ToString();

                //lCat1.Enabled = (Oreadr["CatName1"].ToString() != "n/a");
                //lCat2.Enabled = (Oreadr["CatName2"].ToString() != "n/a");
                //lCat3.Enabled = (Oreadr["CatName3"].ToString() != "n/a");

                //init_LCATn();

                //tCat1.Enabled = lCat1.Enabled;
                //tCat2.Enabled = lCat2.Enabled;
                //tCat3.Enabled = lCat3.Enabled;

                //if (loptID.Text != "") fill_lvOpt_priceList(0);		
            }
            OConn.Close();
        }

        private void cbManuf_SelectedIndexChanged(object sender, EventArgs e)
        {
            affManuf(cbManuf.Text);
            txManufac.Text = cbManuf.Text;
            tM_code.Text = MainMDI.Find_One_Field("select M_code from COMPNT_MANUFAC where MANUFAC_ID=" + lMANLid.Text);

            if (cbPFamily.Items.Count > 0)
            {
                cbPFamily.Text = cbPFamily.Items[0].ToString();
            }
        }

        private void affManuf(string manufCB)
        {
            string stSql = "SELECT COMPNT_MANUFAC.MANUFAC_ID FROM COMPNT_MANUFAC " +
                " where COMPNT_MANUFAC.MANUFAC_NAME= '" + manufCB + "' ";

            lMANLid.Text = MainMDI.Find_One_Field(stSql); 
            //MessageBox.Show(stSql);
            if (lMANLid.Text != "n/a") fill_cbFam(Convert.ToInt32(lcptLID.Text), Convert.ToInt32(lMANLid.Text));
            else MessageBox.Show("Invalid Manufac Name.....");
        }

        private void fill_cbFam(int optID, int ManufacID)
        {
            //string stSql=" SELECT COMPNT_MANUFAC_FAMILY.*, COMPNT_MANUFAC_FAMILY.Manufac_ID, COMPNT_MANUFAC_FAMILY.Compnt_ID " +
                //" From COMPNT_MANUFAC_FAMILY Where (((COMPNT_MANUFAC_FAMILY.Manufac_ID) =" + ManufacID + ") And ((COMPNT_MANUFAC_FAMILY.Compnt_ID) =" + optID + "))";

            string stSql = " SELECT   [Desc], Pref From COMPNT_MANUFAC_FAMILY " +
                " Where COMPNT_MANUFAC_FAMILY.Manufac_ID =" + ManufacID + " And COMPNT_MANUFAC_FAMILY.Compnt_ID =" + optID + " ORDER BY Pref ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            cbPFamily.Items.Clear();
            while (Oreadr.Read())
            {
                cbPFamily.Items.Add(Oreadr["Desc"].ToString());
            }
            OConn.Close();
        }

        private void cbPFamily_SelectedIndexChanged(object sender, EventArgs e)
        {
            string stSql = " SELECT COMPNT_MANUFAC_FAMILY.* From COMPNT_MANUFAC_FAMILY Where [Desc] ='" + cbPFamily.Text + "' and Compnt_ID=" + lcptLID.Text + " and Manufac_ID=" + lMANLid.Text;

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                lfamLID.Text = Oreadr["Compnt_Man_FAM_ID"].ToString();
                txpriority.Text = Oreadr["Pref"].ToString();
                tCostFac.Text = Oreadr["Cost_factor"].ToString();
                tSellFac.Text = Oreadr["Sell_factor"].ToString();
                tF_code.Text = Oreadr["F_Code"].ToString();
                txFamily.Text = cbPFamily.Text;

                //tCostFac.ReadOnly = true; btnFixCost.Text = "Change";
                //tPriority.ReadOnly = true; btnPref.Text = "Change";
            }
            OConn.Close();
            //lvOptPricelst.Items.Clear();
        }

        private void newMan_Click(object sender, EventArgs e)
        {
            if (lcptLID.Text != "")
            {
                txManufac.Clear();
                cbManuf.Visible = false;
                ManMdify.Enabled = false;
                txManufac.Visible = true;
                grpCPT.Enabled = false;
                grpFam.Enabled = false;
                lMANLid.Text = ""; 
                string tcod = MainMDI.Find_One_Field("select max (M_code)+1 from dbo.COMPNT_MANUFAC ");
                tM_code.Text = (tcod != MainMDI.VIDE) ? MainMDI.A00(tcod, 2) : MainMDI.VIDE;
            }
            else MessageBox.Show("Sorry, No Component is Selected....");
        }

        private void savMan_Click(object sender, EventArgs e)
        {
            if (txManufac.Visible && tM_code.Text != MainMDI.VIDE)
            {
                if (lMANLid.Text == "")
                {
                    if (cbManuf.FindStringExact(txManufac.Text) == -1)
                    {
                        string manID = MainMDI.Find_One_Field("select MANUFAC_ID from COMPNT_MANUFAC where MANUFAC_NAME ='" + txManufac.Text + "'");
                        //if (MainMDI.Find_One_Field("select MANUFAC_ID from COMPNT_MANUFAC where MANUFAC_NAME ='" + txManufac.Text + "'") == MainMDI.VIDE)
                        if (manID == MainMDI.VIDE)
                        {
                            string stSql = "insert into COMPNT_MANUFAC ([MANUFAC_NAME], [MANUFAC_ADRS], [MANUFAC_TEL], [MANUFAC_FAX], [M_code]) Values ('"
                                + txManufac.Text.Replace("'", "''") + "', '" +
                                MainMDI.VIDE + "', '" +
                                MainMDI.VIDE + "', '" +
                                MainMDI.VIDE + "', '" +
                                tM_code.Text + "')";

                            MainMDI.Exec_SQL_JFS(stSql, " update Manufac...options..");
                            manID = MainMDI.Find_One_Field("select MANUFAC_ID from COMPNT_MANUFAC where MANUFAC_NAME ='" + txManufac.Text + "'");
                        }
                        if (manID != MainMDI.VIDE)
                        {
                            string tcod = MainMDI.Find_One_Field("select max (F_code)+1 from COMPNT_MANUFAC_FAMILY");
                            tcod = (tcod != MainMDI.VIDE) ? MainMDI.A00(tcod, 2) : "99";
                            Save_family(manID, lcptLID.Text, "NEWFAMILY", "99", "1", "1", tcod);
                            MessageBox.Show("a New Family called: 'NEWFAMILY' was created for this new manufacturer.....");
                        }
                        else MessageBox.Show("Sorry, can not create new Family for this New manufacturer...");
                    }
                }
                else
                {
                    string stSql = "UPDATE COMPNT_MANUFAC SET [MANUFAC_NAME]='" + txManufac.Text.Replace("'", "''") + "'  WHERE [MANUFAC_ID]=" + lMANLid.Text;
                    MainMDI.Exec_SQL_JFS(stSql, " update Manufac...options..");
                }
                aff_Manufac(Convert.ToInt32(lcptLID.Text));
                cbManuf.Text = cbManuf.Items[0].ToString();
                cbManuf.Visible = true;
                txManufac.Visible = false;
                grpCPT.Enabled = true;
                grpFam.Enabled = true;
                ManMdify.Enabled = true;
            }
            else MessageBox.Show("Error Data ,  check Manufacturer name or MAN_Code...");
        }

        private void Newfam_Click(object sender, EventArgs e)
        {
            if (lcptLID.Text != "" && lMANLid.Text != "")
            {
                cbPFamily.Visible = false;
                txFamily.Visible = true;
                famModi.Enabled = false;
                txFamily.Clear();
                lfamLID.Text = "";
                txpriority.Clear();
                tSellFac.Clear();
                tCostFac.Clear();
                grpCPT.Enabled = false;
                grpMan.Enabled = false;
                string tcod = MainMDI.Find_One_Field("select max (F_code)+1 from COMPNT_MANUFAC_FAMILY");
                tF_code.Text = (tcod != MainMDI.VIDE) ? MainMDI.A00(tcod, 2) : MainMDI.VIDE; //errrrorr '17.00' must be '17' check A00
            }
        }

        private void ManModify_Click(object sender, EventArgs e)
        {
            cbManuf.Visible = false;
            txManufac.Visible = true;
            grpCPT.Enabled = false;
            grpFam.Enabled = false; 
        }

        private void Save_family(string _lMANLid, string _lcptLID, string _txFamily, string _txpriority, string _tSellFac, string _tCostFac, string _tF_code)
        {
            string stSql = "insert into COMPNT_MANUFAC_FAMILY ([Manufac_ID], [Compnt_ID], [Desc], [Pref], [Cost_factor], [Sell_factor], [F_Code]) Values ("
                + _lMANLid + ", " +
                _lcptLID + ", '" +
                _txFamily.Replace("'", "''") + "', " +
                _txpriority + ", " +
                _tSellFac + ", " +
                _tCostFac + ", '" +
                _tF_code + "')";

            MainMDI.Exec_SQL_JFS(stSql, " Insert New family...options..");
        }

        private void savFam_Click(object sender, EventArgs e)
        {
            if (tM_code.Text != MainMDI.VIDE && txFamily.Text != "" && Tools.Conv_Dbl(tSellFac.Text) > 0 && Tools.Conv_Dbl(tCostFac.Text) > 0 && Tools.Conv_Dbl(txpriority.Text) > 0)
            {
                if (lfamLID.Text == "")
                {
                    Save_family(lMANLid.Text, lcptLID.Text, txFamily.Text, txpriority.Text, tSellFac.Text, tCostFac.Text, tF_code.Text);
                }
                else
                {
                    string stSql = "UPDATE COMPNT_MANUFAC_FAMILY SET " +
                        " [Desc]='" + txFamily.Text.Replace("'", "''") +
                        "', [Pref]=" + txpriority.Text +
                        ", [Cost_factor]=" + tCostFac.Text +
                        ", [Sell_factor]=" + tSellFac.Text + "  WHERE Compnt_Man_FAM_ID=" + lfamLID.Text;
                    MainMDI.Exec_SQL_JFS(stSql, " update Family...options..");
                }
                //aff_Manufac(Convert.ToInt32(lcptLID.Text));
                //cbManuf.Text = cbManuf.Items[0].ToString();

                fill_cbFam(Convert.ToInt32(lcptLID.Text), Convert.ToInt32(lMANLid.Text));
                cbPFamily.Text = txFamily.Text;
                cbPFamily.Visible = true;
                txFamily.Visible = false;
                grpCPT.Enabled = true;
                grpMan.Enabled = true;
                famModi.Enabled = true;
            }
            else MessageBox.Show("Data error , please Priority, cost factor, sell factor, Family Name or Fam_CODE ..."); 

            grpCPT.Enabled = true;
            grpMan.Enabled = true;
        }

        private void toolStripButton16_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void txpriority_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyInt(e.KeyChar);
        }

        private void tCostFac_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyDBL(e.KeyChar);
        }

        private void tSellFac_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyDBL(e.KeyChar);
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            update_Compnt_List();
            tERef.ReadOnly = true;
            tFRef.ReadOnly = true;
            tERef.BackColor = Color.AliceBlue;
            tFRef.BackColor = Color.AliceBlue; 
        }

        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            tERef.ReadOnly = false;
            tFRef.ReadOnly = false;
            tERef.BackColor = Color.Lavender;
            tFRef.BackColor = Color.Lavender;
        }

        private void tFcode_TextChanged(object sender, EventArgs e)
        {

        }

        private void famModi_Click(object sender, EventArgs e)
        {
            cbPFamily.Visible = false;
            txFamily.Visible = true; 
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}