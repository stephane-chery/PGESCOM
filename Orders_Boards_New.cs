using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PGESCOM
{
    public partial class Orders_Boards_New : Form
    {
        private string in_iRREVlid = "", in_sys_SN = "", in_TR_ID = "", TR_MANnm = "", Bord_TNM, TRInfoName = "";
        private int cur_LV_ndx = -1;

        public Orders_Boards_New(string x_TR_ID, string x_typ_chrgR)
        {
            InitializeComponent();
            in_TR_ID = x_TR_ID;
            Bord_TNM = (x_typ_chrgR == "R") ? "PSM_R_Boards_RCTFR" : "PSM_R_Boards";
            TR_MANnm = (x_typ_chrgR == "R") ? "TR_MAN_RCTFR" : "TR_MAN";
            TRInfoName = (x_typ_chrgR == "R") ? "PSM_R_TRREC_info" : "PSM_R_TRInfo";
        }

        private void TSmain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void grpBrdSN_Enter(object sender, EventArgs e)
        {

        }

        private void Newbrd_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_TR", true))
            {
                clr_brd_info();
                cur_LV_ndx = -1;

                if (CB_brd.Items.Count < 1) fill_cbBrd();
                grpData.Visible = true;
                CB_brd.Enabled = true;
                pic_BoardSave.BringToFront();

                //tBrdSN.ReadOnly = (MainMDI.User.ToLower() != "ede");
            }
        }

        private void CB_brd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void add_CB_itm(ComboBox _CBany, string TXT, string VAL)
        {
            System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
            li.Text = TXT;
            li.Value = VAL;
            _CBany.Items.Add(li);
        }

        private void fill_cbBrd()
        {
            CB_brd.Items.Clear();
            string stSql = "SELECT brd_Code, Brd_Name  from PSM_C_Boards_List WHERE DISP='D' ORDER BY Brd_Name ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            add_CB_itm(CB_brd, "SELECT", "0");
            while (Oreadr.Read())
            {
                add_CB_itm(CB_brd, Oreadr["Brd_Name"].ToString(), Oreadr["brd_Code"].ToString());
            }
            //cbSerItems.BringToFront();
            CB_brd.Text = "SELECT";
            OConn.Close();
        }

        private void fill_cbtConTo()
        {
            cbtConTo.Items.Clear();
            string stSql = "SELECT CONTO from  PSM_C_Boards_CONTO ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            cbtConTo.Items.Add("SELECT");
            while (Oreadr.Read()) cbtConTo.Items.Add(Oreadr["CONTO"].ToString());

            //cbSerItems.BringToFront();
            cbtConTo.Text = "SELECT";
            OConn.Close();
        }

        private void Orders_Boards_New_Load(object sender, EventArgs e)
        {
            this.Text = "Boards Management...............";
            fill_cbBrd();
            clr_brd_info();
            fill_cbtConTo();

            fill_ALL_Manuals();
            fill_Boards(in_TR_ID);
            get_Manuals(in_TR_ID);
        }

        private void clr_brd_info()
        {
            tBrdDesc.Clear(); CB_brd.Text = "SELECT";
            tBrdSN.Clear(); lsnn.Text = "";
            tBver.Clear();
            tSver.Clear();
            lbcod.Clear();
            tConTo.Clear();
            lRev_curr.Text = "";
            cur_LV_ndx = -1;
            cbtConTo.Text = "SELECT";

            //dpassdat.Text = System.DateTime.Now.ToShortDateString();
            //dpPCBdat.Text = System.DateTime.Now.ToShortDateString();
        }

        private void fill_Boards(string _TR_LID)
        {
            string stSql = "SELECT B.* , C.Brd_Name from  " + Bord_TNM + " B inner join PSM_C_Boards_List C on B.brd_Code = C.brd_Code where B.TR_LID =" + _TR_LID;

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

        private void fill_ALL_Manuals()
        {
            string stSql = "SELECT LID, F2   FROM PSM_C_GConfig where f1_code='" + TR_MANnm + "'";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            mdl_Manuals.Items.Clear();

            while (Oreadr.Read())
            {
                ListViewItem lv = mdl_Manuals.Items.Add(Oreadr["LID"].ToString());
                lv.SubItems.Add(Oreadr["F2"].ToString());
            }
            OConn.Close();
            mdl_sel_man.Modifiable = false;
        }

        private void fill_Customer_Manuals(string _TR_LID)
        {
            string st_manuals = MainMDI.Find_One_Field("select tr_manuals from dbo.PSM_R_TRInfo where TR_LID =" + _TR_LID);
            if (st_manuals != MainMDI.VIDE)
            {
                while (st_manuals.Length > 2)
                {
                    ListViewItem lv = mdl_Manuals.Items.Add(st_manuals);
                    lv.SubItems.Add("");
                }
            }
        }

        private void tbV_TextChanged(object sender, EventArgs e)
        {

        }

        private bool fields_OK()
        {
            bool res = true;
            if (tBrdDesc.Text == "" || tBver.Text == "" || tSver.Text == "")
            {
                res = false;
                MessageBox.Show("Error Board Name / Board Version / Soft. Version..........");
                tBrdDesc.Focus();
            }
            else
            {
                if (tBrdSN.Text.Length < 4) //== "00-00")
                {
                    res = false;
                    MessageBox.Show("Error Serial#....");
                    tBrdSN.Focus();
                }
                else
                {
                    if (tConTo.Text == "")
                    {
                        res = false;
                        MessageBox.Show("Error Connected To....");
                        cbtConTo.Focus();
                    }
                }
            }
            return res;
        }

        private void Sav_BOARD()
        {
            string stSql = "";
            if (MainMDI.ALWD_USR("OR_SR2", true))
            {
                if (fields_OK())
                {
                    if (cur_LV_ndx == -1)
                    {
                        //MainMDI.ExecSql("delete  PSM_Boards where b_RRevDetLID=" + lvCurRev.Items[Selndx].SubItems[4].Text);
                        stSql = "INSERT INTO " + Bord_TNM + " ([b_RRevDetLID],[TR_LID],[brd_Code],[b_lotLid],[brd_SN],[brd_Ver],[firmwr_Ver],[newfirmwr_Ver],[b_connTo]) VALUES (" +
                            "0" + " , " +
                            in_TR_ID + " , " +
                            lbcod.Text + " , " +
                            "0" + " , '" +
                            tBrdSN.Text + "' , '" +
                            tBver.Text + "' , '" +
                            tSver.Text + "' , '" +
                            "*" + "' , '" +
                            cbtConTo.Text + "')";
                        MainMDI.ExecSql(stSql);

                        MainMDI.Write_JFS(stSql);
                        //fill_Boards(in_DetLID);
                    }
                    else
                    {
                        //"',[status]='O'" +
                        stSql = "UPDATE " + Bord_TNM + " SET " + " [brd_SN]='" + tBrdSN.Text + "', [brd_Ver]='" + tBver.Text + "', [firmwr_Ver]='" + tSver.Text + "',[b_connTo]='" + cbtConTo.Text + "' WHERE R_BrdLID=" + ed_lvBRD.Items[cur_LV_ndx].SubItems[0].Text;
                        MainMDI.ExecSql(stSql);
                        MainMDI.Write_JFS(stSql);
                        //fill_Boards(in_DetLID);
                    }
                    fill_Boards(in_TR_ID);
                    clr_brd_info();
                }
                //else MessageBox.Show("Some fields are Empty.....");
            }
            //else MessageBox.Show(MainMDI.User + ": is NOT allowed to perform this option, contact you Admin....! ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void exiit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pic_BoardSave_Click(object sender, EventArgs e)
        {
            Sav_BOARD();
        }

        private void CB_brd_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void seek_brd()
        {
            System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
            itm = (System.Web.UI.WebControls.ListItem)CB_brd.Items[CB_brd.SelectedIndex];
            lbcod.Text = itm.Value;
            tBrdDesc.Text = CB_brd.Text;
        }

        private void CB_brd_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CB_brd.Text != "SELECT") seek_brd(); //;
        }

        private void cbtConTo_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbtConTo_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cbtConTo.Text != "SELECT") tConTo.Text = cbtConTo.Text;
        }

        private void ed_lvBRD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ed_lvBRD_DoubleClick(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_TR", true))
            {
                clr_brd_info();
                cur_LV_ndx = ed_lvBRD.SelectedItems[0].Index;
                Edit_Board(cur_LV_ndx);
                grpData.Visible = true;
                picUpdate.BringToFront();
            }
        }

        private void Edit_Board(int lv_ndx)
        {
            if (CB_brd.Items.Count < 1)
            {
                fill_cbBrd();
                CB_brd.Text = ed_lvBRD.Items[lv_ndx].SubItems[1].Text;
            }
            CB_brd.Text = ed_lvBRD.Items[lv_ndx].SubItems[1].Text; tBrdDesc.Text = CB_brd.Text;
            tBrdSN.Text = ed_lvBRD.Items[lv_ndx].SubItems[2].Text;
            tBver.Text = ed_lvBRD.Items[lv_ndx].SubItems[3].Text;
            tSver.Text = ed_lvBRD.Items[lv_ndx].SubItems[4].Text;
            cbtConTo.Text = ed_lvBRD.Items[lv_ndx].SubItems[5].Text; tConTo.Text = cbtConTo.Text;

            CB_brd.Enabled = false;
        }

        private void picUpdate_Click(object sender, EventArgs e)
        {
            Sav_BOARD();
        }

        private bool itemExiste(string txt)
        {
            ListViewItem myItem = mdl_sel_man.FindItemWithText(txt);
            return (myItem != null);
        }

        private void pic_MoveR_Click(object sender, EventArgs e)
        {
            if (mdl_Manuals.SelectedItems.Count > 0)
            {
                for (int i = 0; i < mdl_Manuals.SelectedItems.Count; i++)
                {
                    if (!itemExiste(mdl_Manuals.SelectedItems[i].SubItems[1].Text))
                    {
                        ListViewItem lv = mdl_sel_man.Items.Add(" ");
                        lv.SubItems.Add(mdl_Manuals.SelectedItems[i].SubItems[1].Text);
                    }
                    else MessageBox.Show("Item already exists....");
                }
            }
        }

        private void picDel_Click(object sender, EventArgs e)
        {
            if (mdl_sel_man.SelectedItems.Count > 0) for (int i = mdl_sel_man.SelectedItems.Count - 1; i > -1; i--) mdl_sel_man.SelectedItems[i].Remove();
        }

        private void get_Manuals(string _TR_LID)
        {
            string st = "";
            mdl_sel_man.Items.Clear();
            string tt = MainMDI.Find_One_Field("select tr_manuals from " + TRInfoName + "  where tr_LID=" + _TR_LID);
            if (tt != MainMDI.VIDE)
            {
                int i = 0;
                int ipos = 0;

                while (tt.Length > 0)
                {
                    ipos = tt.IndexOf("~~");
                    if (ipos > -1)
                    {
                        st = tt.Substring(0, ipos);
                        tt = tt.Substring(ipos + 2, tt.Length - (ipos + 2));
                    }
                    else
                    {
                        st = tt;
                        tt = "";
                    }
                    if (st != "")
                    {
                        ListViewItem lv = mdl_sel_man.Items.Add(" ");
                        lv.SubItems.Add(st);
                    }
                }
            }
        }

        private void picSav_Click(object sender, EventArgs e)
        {
            string stSavMan = "";
            if (mdl_sel_man.Items.Count > 0) for (int i = 0; i < mdl_sel_man.Items.Count; i++) stSavMan += mdl_sel_man.Items[i].SubItems[1].Text + "~~";
            MainMDI.Exec_SQL_JFS("update " + TRInfoName + "  set [tr_manuals]='" + stSavMan + "' where tr_LID=" + in_TR_ID, "TEST REPORT MAJ MANUALS...");
            get_Manuals(in_TR_ID);
        }

        private void del_BRD_Click(object sender, EventArgs e)
        {
            for (int i = ed_lvBRD.SelectedItems.Count - 1; i > -1; i--)
            {
                MainMDI.Exec_SQL_JFS("delete " + Bord_TNM + " where  R_BrdLID=" + ed_lvBRD.SelectedItems[i].SubItems[0].Text, "TEST REPORT deleting boards...");
                ed_lvBRD.SelectedItems[i].Remove();
            }
            fill_Boards(in_TR_ID);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            browse_VerS();
        }

        void browse_VerS()
        {
            //ldocs.Text = "";
            folderBrowserDialog3.SelectedPath = @"I:\Production\Digital_Soft\";
            DialogResult res = folderBrowserDialog3.ShowDialog();
            if (res == DialogResult.OK) tSver.Text = folderBrowserDialog3.SelectedPath;
        }
    }
}