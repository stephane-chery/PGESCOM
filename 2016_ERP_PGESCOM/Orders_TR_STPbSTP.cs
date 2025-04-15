using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PGESCOM
{
    public partial class Orders_TR_STPbSTP : Form
    {
        string in_lTRLID,in_PxxSnn,in_mdl;
        string[,] in_arr_ALEQ = new string[100, 40];
        public Orders_TR_STPbSTP(string x_LTRID, string[,] x_arr, string x_pxxSN,string x_mdl)
        {
            InitializeComponent();
            in_lTRLID = x_LTRID;
            in_arr_ALEQ = x_arr;
            in_mdl = x_mdl;
            in_PxxSnn = x_pxxSN;
        }
/*
        private void NewST_Click(object sender, EventArgs e)
        {
            ListViewItem lvI =lv_tests.Items.Add (" ")  ;
            for (int i = 1; i < lv_tests.Columns.Count; i++) lvI.SubItems.Add("-----");
            lvI.SubItems[5].Text  = "";
            lvI.ImageIndex = 9;
           
            for (int i = 1; i < lv_tests.Columns.Count; i++)  lv_tests.AddEditableCell(-1, i);
        }

 * */

        private void _exit_Click(object sender, EventArgs e)
        {
           // lSave.Text = "N";
            this.Hide();
        }



  
        private void sav_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (MainMDI.ALWD_USR("OR_TR", true))
            {
                SaveAllMLV();
                Load_ALL_Values();
            }
            else MessageBox.Show("This User:" + MainMDI.User + "    is NOT allowed to perform this option, contact you Admin....! ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop);
               
                this.Cursor = Cursors.Default;
        }



        private void SaveAllMLV()
        {
            //IMP lv
            if (MLV_Amp.Visible)
            {
                for (int i = 0; i < MLV_Amp.Items.Count; i++)
                {
                    Save_SBS_MLV_Details(MLV_Amp.Items[i].SubItems[0].Text, MLV_Amp.Items[i].SubItems[3].Text, MLV_Amp.Items[i].SubItems[2].Text);
                    // if (TosaveTR) TosaveTR = false;
                }
            }

            //Contrls lv
            for (int i = 0; i < MLV_cntrl.Items.Count; i++)
            {                                                                                                            
                Save_SBS_MLV_Details(MLV_cntrl.Items[i].SubItems[0].Text,  MLV_cntrl.Items[i].SubItems[3].Text, MLV_cntrl.Items[i].SubItems[2].Text);
                // if (TosaveTR) TosaveTR = false;
            }


            //lvl2 lv
            for (int i = 0; i < MLV_lvl2.Items.Count; i++)
            {                                                                                                           
                Save_SBS_MLV_Details(MLV_lvl2.Items[i].SubItems[0].Text, MLV_lvl2.Items[i].SubItems[3].Text, MLV_lvl2.Items[i].SubItems[2].Text);
                // if (TosaveTR) TosaveTR = false;
            }

            if (MLV_DInput.Visible)
            {
                for (int i = 0; i < MLV_DInput.Items.Count; i++)
                {
                    Save_SBS_MLV_Details(MLV_DInput.Items[i].SubItems[0].Text, MLV_DInput.Items[i].SubItems[3].Text, MLV_DInput.Items[i].SubItems[2].Text);
                    // if (TosaveTR) TosaveTR = false;
                }
            }

        }


        private void Save_SBS_MLV_Details(string _trSBS_id, string SBSid, string TechVAL)
        {

            if (TechVAL != "")
            {
                string stSql = "";
                if (_trSBS_id == "")
                    stSql = "INSERT INTO PSM_R_TR_SBSDetails ([tstRepID]  ,[SBS_ID]  ,[ValTec])  VALUES ('" +
                       in_lTRLID + "', '" + SBSid + "', '" + TechVAL.Replace("'", "''") + "')";
                else stSql = "UPDATE PSM_R_TR_SBSDetails  SET " +
                         " [ValTec] ='" + TechVAL.Replace("'", "''") + "'  WHERE [trSBS_id]=" + _trSBS_id;

                MainMDI.Exec_SQL_JFS(stSql, "SBS rpt...");
            }


        }



        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lv_tests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewST_Click(object sender, EventArgs e)
        {
            Fill_ALL('N');

               
        }

        void Fill_ALL(char NL)
        {
            if (MLV_lvl2.Items.Count == 0 && MLV_cntrl.Items.Count == 0)
            {
                lmodel.Text =  in_mdl;
                lPnbSn.Text = in_PxxSnn;
                ldate.Text = System.DateTime.Now.Day.ToString() + "/" + System.DateTime.Now.Month.ToString() + "/" + System.DateTime.Now.Year.ToString();
                fill_Amp();
                fill_CNTRL();
                fill_Lvl2();
                fill_DigInputs();
                fill_ALARMS();
                fill_Boards(in_lTRLID);
            }
            else if (NL=='N') MessageBox.Show("ALL Lists must be Empty before creating new StepByStep............ "); 
        }
        private void fill_Boards(string _TR_LID)
        {

            string stSql = "SELECT B.* , C.Brd_Name from PSM_R_Boards B inner join PSM_C_Boards_List C on B.brd_Code = C.brd_Code where B.TR_LID =" + _TR_LID;


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvBRD.Items.Clear();

            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvBRD.Items.Add(Oreadr["R_BrdLID"].ToString());

                lv.SubItems.Add(Oreadr["Brd_Name"].ToString());
                lv.SubItems.Add(Oreadr["Brd_SN"].ToString());
                lv.SubItems.Add(Oreadr["brd_Ver"].ToString());
                string st = (Oreadr["firmwr_Ver"].ToString() == "*") ? Oreadr["Newfirmwr_Ver"].ToString() : Oreadr["firmwr_Ver"].ToString();
                lv.SubItems.Add(st);
                lv.SubItems.Add(Oreadr["b_connTo"].ToString());

            }

            OConn.Close();

        }

        private void mlv_Alarmsss_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mlv_Alarms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void modified_EditListView2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Orders_TR_STPbSTP_Load(object sender, EventArgs e)
        {
            chkAMP.Checked = false;
            chkDigInp.Checked = false;

            Fill_ALL('O');
            
            Load_ALL_Values();
            ltstLID.Text = in_lTRLID;
        }

    

        void Ventl_Values_TBL(string tbl,string cod,string LID,string val)
        {

            switch (tbl)
            {
                case "1":
                    for (int i = 0; i < MLV_Amp.Items.Count; i++)
                        if (MLV_Amp.Items[i].SubItems[3].Text == cod)
                        {
                            MLV_Amp.Items[i].SubItems[0].Text = LID;
                            MLV_Amp.Items[i].SubItems[2].Text = val;
                            if (!chkAMP.Checked) chkAMP.Checked = true;
                            i = MLV_Amp.Items.Count;
                        }

                    break;
                case "2":
                    for (int i = 0; i < MLV_cntrl.Items.Count; i++)
                        if (MLV_cntrl.Items[i].SubItems[3].Text == cod)
                        {
                            MLV_cntrl.Items[i].SubItems[0].Text = LID;
                            MLV_cntrl.Items[i].SubItems[2].Text = val;
                  
                            i = MLV_cntrl.Items.Count;
                        }

                    break;
                case "3":
                    for (int i = 0; i < MLV_lvl2.Items.Count; i++)
                        if (MLV_lvl2.Items[i].SubItems[3].Text == cod)
                        {
                            MLV_lvl2.Items[i].SubItems[0].Text = LID;
                            MLV_lvl2.Items[i].SubItems[2].Text = val;
                            i = MLV_lvl2.Items.Count;
                        }

                    break;
                case "4":
                    for (int i = 0; i < MLV_DInput.Items.Count; i++)
                    {
                        if (MLV_DInput.Items[i].SubItems[3].Text == cod)
                        {
                            MLV_DInput.Items[i].SubItems[0].Text = LID;
                            MLV_DInput.Items[i].SubItems[2].Text = val;
                            if (!chkDigInp.Checked) chkDigInp.Checked = true;
                            i = MLV_DInput.Items.Count;
                        }
                    }

                    break;
            }

        }


        private void Load_ALL_Values()
        {

            string stSql = " SELECT  PSM_R_TR_SBSDetails.trSBS_id, PSM_R_TR_SBSDetails.tstRepID, PSM_R_TR_SBSDetails.SBS_ID, PSM_R_TR_SBSDetails.ValTec, PSM_R_TR_SBS.sbs_Name, PSM_R_TR_SBS.gril_cod,  PSM_R_TR_SBS.PGC_Eqv, PSM_R_TR_SBS.Gril_Rnk " +
                           " FROM    PSM_R_TR_SBSDetails INNER JOIN  PSM_R_TR_SBS ON PSM_R_TR_SBSDetails.SBS_ID = PSM_R_TR_SBS.SBS_ID " +
                           " where PSM_R_TR_SBSDetails.tstRepID=" + in_lTRLID + " order  by PSM_R_TR_SBS.gril_cod";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
         
            while (Oreadr.Read())
            {

                Ventl_Values_TBL(Oreadr["gril_cod"].ToString(), Oreadr["SBS_ID"].ToString(), Oreadr["trSBS_id"].ToString(), Oreadr["ValTec"].ToString());
   

            }
            OConn.Close();
          

        }
        private void Load_Amp()
        {

            string stSql = "SELECT *   FROM [Orig_PSM_FDB].[dbo].[PSM_R_TR_SBS] where gril_cod=1 order by Gril_Rnk ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            MLV_Amp.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem lv = MLV_Amp.Items.Add("");
                lv.SubItems.Add(Oreadr["sbs_Name"].ToString());
                lv.SubItems.Add(""); 
                lv.SubItems.Add(Oreadr["SBS_ID"].ToString());

                lv.UseItemStyleForSubItems = false;
                lv.SubItems[2].BackColor = Color.PaleGreen;

            }
            OConn.Close();
            MLV_Amp.AddEditableCell(-1, 2);

        }

        private void fill_Amp()
        {

            string stSql = "SELECT *   FROM [Orig_PSM_FDB].[dbo].[PSM_R_TR_SBS] where gril_cod=1 order by Gril_Rnk ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            MLV_Amp.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem lv = MLV_Amp.Items.Add("");
                lv.SubItems.Add(Oreadr["sbs_Name"].ToString());
                lv.SubItems.Add("");
                lv.SubItems.Add(Oreadr["SBS_ID"].ToString());

                lv.UseItemStyleForSubItems = false;
                lv.SubItems[2].BackColor = Color.PaleGreen;

            }
            OConn.Close();
            MLV_Amp.AddEditableCell(-1, 2);

        }
        private void fill_CNTRL()
        {

            //		string stSql = "SELECT COMPNT_PRICE_LIST.* FROM (COMPNT_LIST INNER JOIN COMPNT_MANUFAC_FAMILY ON COMPNT_LIST.Component_ID = COMPNT_MANUFAC_FAMILY.Compnt_ID) INNER JOIN COMPNT_PRICE_LIST ON COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID = COMPNT_PRICE_LIST.compnt_man_Fam_ID " + 
            //			" WHERE (((COMPNT_LIST.COMPONENT_REF)='ALRM') AND ((COMPNT_PRICE_LIST.PRICE)=0)) ORDER BY COMPNT_LIST.COMPONENT_REF";
            string stSql = "SELECT *   FROM [Orig_PSM_FDB].[dbo].[PSM_R_TR_SBS] where gril_cod=2 order by Gril_Rnk "; //PRICE";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            MLV_cntrl.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem lv = MLV_cntrl.Items.Add("");
                lv.SubItems.Add(Oreadr["sbs_Name"].ToString());
                lv.SubItems.Add("");
                lv.SubItems.Add(Oreadr["SBS_ID"].ToString());

                lv.UseItemStyleForSubItems = false;
                lv.SubItems[2].BackColor = Color.PaleGreen;
            }
            OConn.Close();
           MLV_cntrl.AddEditableCell(-1, 2);

        }

        private void fill_Lvl2()
        {


            string stSql = "SELECT *   FROM [Orig_PSM_FDB].[dbo].[PSM_R_TR_SBS] where gril_cod=3 order by Gril_Rnk "; 

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            MLV_lvl2.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem lv = MLV_lvl2.Items.Add("");
                lv.SubItems.Add(Oreadr["sbs_Name"].ToString());
                lv.SubItems.Add("");
                lv.SubItems.Add(Oreadr["SBS_ID"].ToString());

                lv.UseItemStyleForSubItems = false;
                lv.SubItems[2].BackColor = Color.PaleGreen ;
            }
            OConn.Close();
            MLV_lvl2.AddEditableCell(-1, 2);

        }

        //MLV_DInput
        private void fill_DigInputs()
        {


            string stSql = "SELECT *   FROM [Orig_PSM_FDB].[dbo].[PSM_R_TR_SBS] where gril_cod=4 order by Gril_Rnk "; 

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            MLV_DInput.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem lv = MLV_DInput.Items.Add("");
                lv.SubItems.Add(Oreadr["sbs_Name"].ToString());
                lv.SubItems.Add("");
                lv.SubItems.Add(Oreadr["SBS_ID"].ToString());

                lv.UseItemStyleForSubItems = false;
                lv.SubItems[2].BackColor = Color.PaleGreen;
            }
            OConn.Close();
            MLV_DInput.AddEditableCell(-1, 2);

        }

        private void fill_ALARMS()
        {

            MLV_ALRM.Items.Clear();
            for (int i = 0; i < 100;i++ )
            {
                if (in_arr_ALEQ[i, 1] != "")
                {
                    ListViewItem lv = MLV_ALRM.Items.Add("");
                    lv.SubItems.Add(in_arr_ALEQ[i, 1]);
                    for (int j = 2; j < 19;j+=2)
                    {
                        string st = (in_arr_ALEQ[i, j + 1] != "") ? in_arr_ALEQ[i, j + 1] : in_arr_ALEQ[i, j];
                      //  MessageBox.Show(st+"i="+i.ToString()+"  j="+j.ToString());
                        lv.SubItems.Add(st);
                        lv.UseItemStyleForSubItems = false;
                        lv.SubItems[lv.SubItems.Count -1].BackColor = Color.PaleGreen;
                    }
                }
                else i = 100;
          

                //lv.UseItemStyleForSubItems = false;
                //lv.SubItems[2].BackColor = Color.PaleGreen;

            }

            //make editable all columns
         //   for (int n = 2; n < 11;n++ )  MLV_ALRM.AddEditableCell(-1, n);
            //make editable  column 2
           // MLV_ALRM.AddEditableCell(-1, 2);

        }


        private void MLV_lvl2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ed_lvBRD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void chkAMP_CheckedChanged(object sender, EventArgs e)
        {
         //   MLV_Amp.Visible = chkAMP.Checked;
           grpAmp.Visible = chkAMP.Checked;
           updt_txt();
            
        }

        void updt_txt()
        {
            tabControl1.TabPages[1].Text = " Controls - Level 2 ";
            if (chkAMP.Checked) tabControl1.TabPages[1].Text = " Amper Hour -" + tabControl1.TabPages[1].Text;
            if (chkDigInp.Checked) tabControl1.TabPages[1].Text = tabControl1.TabPages[1].Text + "- Digital Inputs ";
        }
        private void chkDigInp_CheckedChanged(object sender, EventArgs e)
        {
            grpDigInp.Visible = chkDigInp.Checked;
            updt_txt();
        }

        private void del_Click(object sender, EventArgs e)
        {
            pnl_disp.Visible = !pnl_disp.Visible;
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {
             
        }

    }
}