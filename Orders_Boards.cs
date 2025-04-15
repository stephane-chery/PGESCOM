using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using EAHLibs;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace PGESCOM
{
    public partial class Orders_Boards : Form
    {
        private string in_iRREVlid = "", in_sys_SN = "", in_DetLID = "";
        private int cur_LV_ndx = -1;
        private char opera = 'N';

        public Orders_Boards(string x_DetLID, string x_sys_SN)
        {
            InitializeComponent();

            in_DetLID = x_DetLID;
            in_sys_SN = x_sys_SN;
            btnNR.Visible = MainMDI.ALWD_USR("OR_SR3", false);
            tBrdSN.ReadOnly = (MainMDI.User.ToLower() != "ede");
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

        private void fill_lotInfo(string _lotLID)
        {
            string stSql = "select * from psm_R_Boards_lot where  l_lotlid=" + _lotLID;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                tbomv.Text = Oreadr["l_BOM_Rev"].ToString();
                tpcbdat.Text = Oreadr["l_Pcb_date"].ToString();
                txassdat.Text = Oreadr["l_assembly_date"].ToString();
                tbV.Text = Oreadr["l_brd_ver"].ToString();
            }
            OConn.Close();
        }

        private void fill_Lots(string _bcode)
        {
            cbLots.Items.Clear();
            //string stSql = "SELECT l_lotLID, l_Recep_date, l_lotPOnb   from PSM_R_Boards_lot WHERE l_brd_Code=" + _bcode + " ORDER BY l_Recep_date ";
            string stSql = "SELECT l_lotLID, l_BOM_Rev, l_Pcb_date,l_assembly_date   from PSM_R_Boards_lot WHERE l_brd_Code=" + _bcode + " ORDER BY l_Recep_date ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            add_CB_itm(cbLots, "SELECT", "0");
            while (Oreadr.Read())
            {
                //DateTime dt = Oreadr["l_Recep_date"].ToString();
                //System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                //li.Text = MainMDI.Eng_date(Oreadr["l_Recep_date"].ToString(), "/") + "-" + Oreadr["l_lotPOnb"].ToString();
                //li.Value = Oreadr["l_lotLID"].ToString();
                //cbLots.Items.Add(li);
                add_CB_itm(cbLots, Oreadr["l_BOM_Rev"].ToString() + " / " + Oreadr["l_Pcb_date"].ToString() + " / " + Oreadr["l_assembly_date"].ToString(), Oreadr["l_lotLID"].ToString());
            }
            //cbSerItems.BringToFront();
            OConn.Close();
        }

        private void clr_LotInfo()
        {
            tpcbdat.Clear();
            txassdat.Clear();
            tbomv.Clear();
            tbV.Clear();
        }

        private void clr_brd_info()
        {
            tBrdDesc.Clear(); CB_brd.Text = "SELECT";
            tBrdSN.Clear(); lsnn.Text = "";
            tPV.Clear(); cbTPV.Text = "SELECT";
            lbcod.Clear();
            tConTo.Clear();
            lRev_curr.Text = "";
            tmanual.Clear();
            cbtConTo.Text = "SELECT";
            cbMode.Text = "SELECT";
            cbLots.Text = "SELECT";
            //clr_LotInfo();
            cbLots.Text = "SELECT";

            //dpassdat.Text = System.DateTime.Now.ToShortDateString();
            //dpPCBdat.Text = System.DateTime.Now.ToShortDateString();
        }

        private void Newbrd_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_TR", true))
            {
                clr_brd_info();
                opera = 'N';
                grpBrdSN.Visible = true;
                CB_brd.Visible = true;
                cbTPV.Visible = true;
                cbtConTo.Visible = true;
                cbLots.Visible = true;
                cur_LV_ndx = -1;
                btnNR.Text = "Rev++";
                trevNN.Visible = false;
                if (CB_brd.Items.Count < 1) fill_cbBrd();
                btnNewSNb.Enabled = true;
                btnDetails.Enabled = true;
                tBrdSN.ReadOnly = (MainMDI.User.ToLower() != "ede");
            }
        }

        private void CB_brd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CB_brd_SelectedValueChanged(object sender, EventArgs e)
        {
            if (CB_brd.Text != "SELECT") Seek_BrdName();
        }

        private void Seek_BrdName()
        {
            System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
            itm = (System.Web.UI.WebControls.ListItem)CB_brd.Items[CB_brd.SelectedIndex];
            lbcod.Text = itm.Value;
            L_SNcoding.Text = MainMDI.Find_One_Field("select sn_coding from psm_C_Boards_list where brd_Code=" + lbcod.Text);
            if (L_SNcoding.Text == MainMDI.VIDE)
            {
                MessageBox.Show("Sorry, You can not create SN for this Board because: SN coding is Invalid  ...call you Admin.");
                btnNewSNb.Visible = false;
                tBrdSN.Text = "";
            }
            else
            {
                tBrdDesc.Text = CB_brd.Text;
                if (tBrdDesc.Text != "PC22_OLD" && tBrdDesc.Text != "PC21")
                {
                    fill_Lots(lbcod.Text);
                    cbLots.Text = cbLots.Items[0].ToString();
                    cbMode.Text = cbMode.Items[0].ToString();
                    cbtConTo.Text = cbtConTo.Items[0].ToString();
                    fill_cbBrd_softVer(lbcod.Text);
                    lstatus.Text = "N";
                    //tBrdSN.ReadOnly = true;
                    tBrdSN.ReadOnly = (MainMDI.User.ToLower() != "ede");
                }
                else
                {
                    fill_Lots(lbcod.Text);
                    string recDat = "", PO = "";
                    int lotLID_CHS = (tBrdDesc.Text == "PC22_OLD") ? 3 : 5; //defined lot for pc21 and pc22_old
                    MainMDI.Find_2_Field("SELECT  l_Recep_date, l_lotPOnb   from PSM_R_Boards_lot WHERE l_lotLID=" + lotLID_CHS, ref recDat, ref PO);
                    if (recDat != MainMDI.VIDE) cbLots.Text = MainMDI.Eng_date(recDat, "/") + "-" + PO;
                    cbMode.Text = "Standard";
                    cbTPV.Visible = false;
                    cbtConTo.Visible = false;
                    CB_brd.Visible = false;
                    cbLots.Visible = false;
                    lstatus.Text = "O";
                    btnNewSNb.Enabled = false;
                    btnDetails.Enabled = false;
                    tBrdSN.ReadOnly = false;
                }
            }
        }

        private void fill_cbBrd_softVer(string _bcode)
        {
            cbTPV.Items.Clear();
            string stSql = "SELECT m_mdlLID, m_Desc_eng  from PSM_C_Boards_Lmdl WHERE type='s' and  m_brd_Code =" + _bcode + " and  m_DISP='D' ORDER BY rnk ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            bool found = false;
            add_CB_itm(cbTPV, "SELECT", "0");
            while (Oreadr.Read())
            {
                //System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                //li.Text = Oreadr["m_Desc_eng"].ToString();
                //li.Value = Oreadr["m_mdlLID"].ToString();
                //cbTPV.Items.Add(li);
                add_CB_itm(cbTPV, Oreadr["m_Desc_eng"].ToString(), Oreadr["m_mdlLID"].ToString());
                if (!found) found = true;
            }
            //cbSerItems.BringToFront();
            OConn.Close();
            if (!found) MessageBox.Show("No Soft Version found for this Board ....please insert new Soft Version or choose another Board....");
            cbTPV.Text = "SELECT";
        }

        private bool fields_OK()
        {
            bool res = true;
            if (tBrdDesc.Text == "")
            {
                res = false;
                MessageBox.Show("Error Board Name....");
                tBrdDesc.Focus();
            }
            else
            {
                if (tBrdSN.Text.Length < 4) //== "00-00")
                {
                    res = false;
                    MessageBox.Show("Error Seril#....");
                    tBrdSN.Focus();
                }
                else
                {
                    if (tPV.Text == "")
                    {
                        res = false;
                        MessageBox.Show("Error Firmware Version....");
                        cbTPV.Focus();
                    }
                    else
                    {
                        if (lcbMode.Text == "")
                        {
                            res = false;
                            MessageBox.Show("Error Board mode ....");
                            cbMode.Focus();
                        }
                        else
                        {
                            if (tConTo.Text == "")
                            {
                                res = false;
                                MessageBox.Show("Error Connected To....");
                                cbtConTo.Focus();
                            }
                            else
                            {
                                if (lcblots.Text == "")
                                {
                                    res = false;
                                    MessageBox.Show("Error Lots#....");
                                    cbLots.Focus();
                                }
                            }
                        }
                    }
                }
            }
            return res;
        }

        private void Sav_BRD_Click(object sender, EventArgs e)
        {
            string stSql = "";
            if (MainMDI.ALWD_USR("OR_SR2", true))
            {
                if (fields_OK() && btnNR.Text != "Save")
                {
                    if (cur_LV_ndx == -1)
                    {
                        //MainMDI.ExecSql("delete  PSM_Boards where b_RRevDetLID=" + lvCurRev.Items[Selndx].SubItems[4].Text);
                        stSql = "INSERT INTO PSM_R_Boards ([b_RRevDetLID],[brd_Code],[b_lotLid],[brd_SN],[brd_Ver],[firmwr_Ver],[b_connTo],[b_Manual],[b_Pcb_date],[b_BOM_Rev],[status],[b_mode],[b_assembly_date]) VALUES (" +
                            in_DetLID + " , " +
                            lbcod.Text + " , " +
                            lotLID.Text + " , '" +
                            tBrdSN.Text + "' , '" +
                            tbV.Text + "' , '" +
                            tPV.Text + "' , '" +
                            tConTo.Text + "' , '" +
                            tmanual.Text + "' , '" +
                            tpcbdat.Text + "' , '" +
                            tbomv.Text + "' , '" +
                            lstatus.Text + "' , '" +
                            lcbMode.Text + "' , '" +
                            txassdat.Text + "')";
                        MainMDI.ExecSql(stSql);
                        btnNewSNb.Enabled = true;

                        MainMDI.Write_JFS(stSql);
                        //fill_Boards(in_DetLID);

                        if (lsnn.Text != "")
                        {
                            MainMDI.flag_QRID('B', 'f', 1, Convert.ToInt32(lsnn.Text));
                            MainMDI.flag_QRID('B', 'u', 0, Convert.ToUInt32(lsnn.Text));
                            lsnn.Text = "";
                        }
                    }
                    else
                    {
                        //"',[status]='O'" +
                        stSql = "UPDATE PSM_R_Boards SET " + " [brd_SN]='" + tBrdSN.Text + "', [b_lotlid]=" + lotLID.Text + ", [brd_Ver]='" + tbV.Text + "', [firmwr_Ver]='" + tPV.Text + "',[b_Pcb_date]='" + tpcbdat.Text + "',[b_mode]='" + lcbMode.Text + "',[b_assembly_date]='" +
                            txassdat.Text + "',[b_BOM_Rev]='" + tbomv.Text + "',[b_Manual]='" + tmanual.Text + "',[b_connTo]='" + tConTo.Text + "' WHERE R_BrdLID=" + ed_lvBRD.Items[cur_LV_ndx].SubItems[0].Text;
                        MainMDI.ExecSql(stSql);
                        MainMDI.Write_JFS(stSql);
                        //fill_Boards(in_DetLID);
                    }
                    fill_Boards(in_DetLID);
                    clr_brd_info();
                    opera = 'N';
                }
                //else MessageBox.Show("Some fields are Empty.....");
            }
            //else MessageBox.Show(MainMDI.User + ": is NOT allowed to perform this option, contact you Admin....! ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void fill_Boards(string _DetLID)
        {
            //clr_brd_info();
            if (cur_LV_ndx > -1) grpBrdSN.Visible = false;
            cur_LV_ndx = -1;
            string stSql = " SELECT PSM_R_Boards.*, PSM_C_Boards_List.Brd_Name FROM PSM_R_Boards INNER JOIN PSM_C_Boards_List ON PSM_R_Boards.brd_Code = PSM_C_Boards_List.brd_Code " +
                " WHERE  PSM_R_Boards.b_RRevDetLID =" + _DetLID;

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
                lv.SubItems.Add(Oreadr["brd_Ver"].ToString());
                lv.SubItems.Add(Oreadr["firmwr_Ver"].ToString());
                lv.SubItems.Add(Oreadr["b_BOM_Rev"].ToString());
                lv.SubItems.Add(Oreadr ["b_PCB_date"].ToString());
                lv.SubItems.Add(Oreadr["b_assembly_date"].ToString());
                lv.SubItems.Add(Oreadr["brd_SN"].ToString());
                lv.SubItems.Add(Oreadr["b_connTo"].ToString());
                lv.SubItems.Add(Oreadr["b_Manual"].ToString());
                lv.SubItems.Add(Oreadr["status"].ToString());
                string stdat = "", stPO = "";
                MainMDI.Find_2_Field("select l_lotPOnb,  l_Recep_date from psm_r_Boards_lot where l_lotlid=" + Oreadr["b_lotLID"].ToString(), ref stPO, ref stdat);
                if (stPO == MainMDI.VIDE)
                {
                    lv.SubItems.Add("n/a");
                    lv.SubItems.Add("0");
                }
                else
                {
                    lv.SubItems.Add(MainMDI.Eng_date(stdat, "/") + "-" + stPO);
                    lv.SubItems.Add(Oreadr["b_lotLID"].ToString());
                }
                lv.SubItems.Add(Oreadr["b_mode"].ToString());
            }
            OConn.Close();
        }

        private void dpPCBdat_ValueChanged(object sender, EventArgs e)
        {
            tpcbdat.Text = dpPCBdat.Value.ToShortDateString();
        }

        private void dpassdat_ValueChanged(object sender, EventArgs e)
        {
            txassdat.Text = dpassdat.Value.ToShortDateString();
        }

        private void Orders_Boards_Load(object sender, EventArgs e)
        {
            this.Text = "Boards for Serial#: " + in_sys_SN;
            fill_Boards(in_DetLID);
            clr_brd_info();
            fill_cbtConTo();
        }

        private void ed_lvBRD_DoubleClick(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_TR", true))
            {
                opera = 'M';
                btnNewSNb.Enabled = false;
                btnDetails.Enabled = false;
                cur_LV_ndx = ed_lvBRD.SelectedItems[0].Index;
                Edit_Board(cur_LV_ndx);
                grpBrdSN.Visible = true;
            }
        }

        //private bool IsInCB_xxx(ComboBox CB_xxx, string
        private void Edit_Board(int lv_ndx)
        {
            clr_brd_info();
            bool sta = (ed_lvBRD.Items[lv_ndx].SubItems[10].Text == "N");
            lotLID.Text = (sta) ? ed_lvBRD.Items[lv_ndx].SubItems[2].Text : "0";
            cbTPV.Visible = sta;
            cbtConTo.Visible = sta;
            CB_brd.Visible = sta;
            cbLots.Visible = sta;

            if (sta)
            {
                grpBrdSN.Visible = true;
                CB_brd.Visible = true;
                cbTPV.Visible = true;
                cbtConTo.Visible = true;
                cbLots.Visible = true;

                if (CB_brd.Items.Count < 1) fill_cbBrd();
                CB_brd.Text = ed_lvBRD.Items[lv_ndx].SubItems[1].Text;
                //if (CB_brd.Text != "") Seek_BrdName();
                if (cbTPV.FindString(ed_lvBRD.Items[lv_ndx].SubItems[3].Text) > 0) cbTPV.Text = ed_lvBRD.Items[lv_ndx].SubItems[3].Text;
                else
                {
                    cbTPV.Visible = false;
                    tPV.Text = ed_lvBRD.Items[lv_ndx].SubItems[3].Text;
                    tPV.ReadOnly = true;
                    btnNR.Visible = false;
                }
                tpcbdat.Text = ed_lvBRD.Items[lv_ndx].SubItems[5].Text;
                txassdat.Text = ed_lvBRD.Items[lv_ndx].SubItems[6].Text;
                cbLots.Text = ed_lvBRD.Items[lv_ndx].SubItems[11].Text;
                lotLID.Text = ed_lvBRD.Items[lv_ndx].SubItems[12].Text;
                cbtConTo.Text = ed_lvBRD.Items[lv_ndx].SubItems[8].Text;
                tbomv.Text = ed_lvBRD.Items[lv_ndx].SubItems[4].Text;
            }
            else
            {
                tPV.Text = ed_lvBRD.Items[lv_ndx].SubItems[3].Text;
                //dpPCBdat.Text = ed_lvBRD.Items[lv_ndx].SubItems[5].Text;
                //dpassdat.Text = ed_lvBRD.Items[lv_ndx].SubItems[6].Text;
                tpcbdat.Text = MainMDI.VIDE;
                txassdat.Text = MainMDI.VIDE;
                lcblots.Text = ed_lvBRD.Items[lv_ndx].SubItems[11].Text;
                lotLID.Text = ed_lvBRD.Items[lv_ndx].SubItems[12].Text;
                tConTo.Text = ed_lvBRD.Items[lv_ndx].SubItems[8].Text;
                tbomv.Text = MainMDI.VIDE;
            }
            tbV.Text = ed_lvBRD.Items[lv_ndx].SubItems[2].Text;

            tBrdSN.Text = ed_lvBRD.Items[lv_ndx].SubItems[7].Text;
            tmanual.Text = ed_lvBRD.Items[lv_ndx].SubItems[9].Text;

            cbMode.Text = giv_mode(ed_lvBRD.Items[lv_ndx].SubItems[13].Text);
            tBrdDesc.Text = ed_lvBRD.Items[lv_ndx].SubItems[1].Text;
        }

        private void ed_lvBRD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txassdat_DoubleClick(object sender, EventArgs e)
        {
            dpassdat.Visible = true;
        }

        private void tpcbdat_DoubleClick(object sender, EventArgs e)
        {
            dpPCBdat.Visible = true;
        }

        private void del_BRD_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_SR2", true))
            {
                if (ed_lvBRD.SelectedItems.Count == 1)
                {
                    cur_LV_ndx = ed_lvBRD.SelectedItems[0].Index;
                    string stSql = "delete PSM_R_Boards where R_BrdLID =" + ed_lvBRD.Items[cur_LV_ndx].SubItems[0].Text;
                    MainMDI.ExecSql(stSql);
                    MainMDI.Exec_SQL_JFS(stSql, "Delete Board info");
                    fill_Boards(in_DetLID);
                    clr_brd_info();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string _DetLID = "";
            string[] ar_T = new string[6];

            string stSql = "select * from PSM_Boards ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            dpassdat.Text = "01/01/1900";
            dpPCBdat.Text = "01/01/1900";
            MessageBox.Show("GO................");

            while (Oreadr.Read())
            {
                clr_brd_info();
                _DetLID = Oreadr["b_RRevDetLID"].ToString();
                get_BoardInfo(Oreadr["brd_Desc"].ToString(), ref ar_T);

                tBrdDesc.Text = ar_T[0];

                lbcod.Text = MainMDI.Find_One_Field("select brd_Code from PSM_C_Boards_List brd_Code where Brd_Name='" + tBrdDesc.Text + "'");
                if (lbcod.Text == MainMDI.VIDE) MainMDI.ExecSql("insert into PSM_C_Boards_List ([Brd_Name],[Brd_desc],[SN_Coding],[Brd_FR_Desc]) " +
                    "VALUES ('" + tBrdDesc.Text + "', 'n/a','A','n/a') "); lbcod.Text = MainMDI.Find_One_Field("select brd_Code from PSM_C_Boards_List brd_Code where Brd_Name='" + tBrdDesc.Text + "'");
                lbcod.Text = MainMDI.Find_One_Field("select brd_Code from PSM_C_Boards_List brd_Code where Brd_Name='" + tBrdDesc.Text + "'");
                if (lbcod.Text == MainMDI.VIDE) MessageBox.Show("ADD board name: " + tBrdDesc.Text);

                tbV.Text = ar_T[1];
                tPV.Text = ar_T[2];
                tConTo.Text = ar_T[3];
                tmanual.Text = ar_T[4];
                tBrdSN.Text = Oreadr["brd_SN"].ToString();
                stSql = "INSERT INTO PSM_R_Boards ([b_RRevDetLID],[brd_Code],[brd_SN],[brd_Ver],[firmwr_Ver],[b_connTo],[b_Manual],[b_Pcb_date],[b_BOM_Rev],[b_assembly_date]) VALUES (" +
                    _DetLID + " , '" +
                    lbcod.Text + "' , '" +
                    tBrdSN.Text + "' , '" +
                    tbV.Text + "' , '" +
                    tPV.Text + "' , '" +
                    tConTo.Text + "' , '" +
                    tmanual.Text + "' , " +
                    MainMDI.SSV_date(tpcbdat.Text) + " , '" +
                    tbomv.Text + "' , " +
                    MainMDI.SSV_date(txassdat.Text) + ")";
                MainMDI.ExecSql(stSql);
            }
            OConn.Close();
            MessageBox.Show("Finishhhhhhhhhhhhhhhhhhhhh");
        }

        private void get_BoardInfo(string tt, ref string[] ar_T)
        {
            //t1 = ""; t2 = ""; t3 = ""; t4 = "";
            //string[] ar_T = new string[4];
            for (int ii = 0; ii < 6; ii++) ar_T[ii] = "";
            int i = 0;
            int ipos = 0;
            while (tt.Length > 0)
            {
                ipos = tt.IndexOf("~~");
                if (ipos > -1)
                {
                    ar_T[i++] = tt.Substring(0, ipos);
                    tt = tt.Substring(ipos + 2, tt.Length - (ipos + 2));
                }
                else
                {
                    ar_T[i++] = tt;
                    tt = "";
                }
            }
        }

        private void cbtConTo_SelectedIndexChanged(object sender, EventArgs e)
        {
            tConTo.Text = (cbtConTo.Text == "SELECT") ? "" : cbtConTo.Text;
        }

        private void cbLots_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbLots.Text != "SELECT")
            {
                System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
                itm = (System.Web.UI.WebControls.ListItem)cbLots.Items[cbLots.SelectedIndex];
                lotLID.Text = itm.Value;
                lcblots.Text = cbLots.Text;
                fill_lotInfo(lotLID.Text);
            }
            else
            {
                lotLID.Text = "0";
                clr_LotInfo();
            }
        }

        private void giv_RevNN(string _Firmwr, ref string debst, ref string vNN)
        {
            int ipos = _Firmwr.IndexOf("-rev");
            if (ipos > -1)
            {
                vNN = _Firmwr.Substring(ipos + 4, _Firmwr.Length - (ipos + 4));
                debst = _Firmwr.Substring(0, ipos + 4);
            }
            else
            {
                vNN = MainMDI.VIDE;
                debst = MainMDI.VIDE;
            }
        }

        private void cbTPV_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTPV.Text != "SELECT")
            {
                System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
                itm = (System.Web.UI.WebControls.ListItem)cbTPV.Items[cbTPV.SelectedIndex];
                lmdlLID.Text = itm.Value;

                tPV.Text = cbTPV.Text;
                string _vnn = "", _debst = "";
                giv_RevNN(tPV.Text, ref _debst, ref _vnn);
                lRev_curr.Text = _vnn;
                ldebRev.Text = _debst;
                trevNN.Text = lRev_curr.Text;
            }
            else tPV.Text = "";
        }

        private void btnNewSNb_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_SR2", true))
            {
                if (L_SNcoding.Text != "")
                {
                    this.Cursor = Cursors.WaitCursor;
                    long Res = fill_SNID_brd();
                    if (Res == 0 || Res == -1) MessageBox.Show("Unable to Generate Serial# for this Board,  please call you Admin. !!!!");
                    else
                    {
                        tBrdSN.Text = L_SNcoding.Text + MainMDI.A00(Res, 4);
                        lsnn.Text = Res.ToString();
                    }
                    this.Cursor = Cursors.Default;
                    btnNewSNb.Enabled = false;
                }
                else MessageBox.Show("Error:   Board-Coding is Invalid.....call your Admin...");
            }
        }

        private int fill_SNID_brd()
        {
            MainMDI.lock_table('B');
            long Sn = MainMDI.Gen_IDFinal('B');
            tBrdSN.Text = "";
            switch (Sn)
            {
                case 0:
                    //MessageBox.Show("Table PSM_S_GenID is Full....");
                    MessageBox.Show("Board Serials IDs must be added, please contact your Administrator ....");
                    break;
                case -1:
                    MessageBox.Show("No available Serial# for Boards, GEN_IDs is empty , please contact your Administrator....");
                    break;
                default:
                    //TPXsn.Text = Sn.ToString();
                    MainMDI.flag_QRID('B', 'u', 1, Sn);
                    break;
            }
            MainMDI.Unlock_table("PSM_B_GenID");
            return Convert.ToInt32(Sn);
        }

        private void NewSN_Click(object sender, EventArgs e)
        {

        }

        private void exiit_Click(object sender, EventArgs e)
        {
            if (lsnn.Text != "" && opera == 'N') MainMDI.flag_QRID('B', 'u', 0, Convert.ToUInt32(lsnn.Text));
            this.Hide();
        }

        private string giv_mode(string st)
        {
            switch (st)
            {
                case "Standard":
                    st = "D";
                    break;
                case "Master":
                    st = "M";
                    break;
                case "Slave":
                    st = "S";
                    break;
                default:
                    st = "?";
                    break;
                case "D":
                    st = "Standard";
                    break;
                case "M":
                    st = "Master";
                    break;
                case "S":
                    st = "Slave";
                    break;
            }
            return st;
        }

        private void cbMode_SelectedIndexChanged(object sender, EventArgs e)
        {
            lcbMode.Text = (cbMode.Text == "SELECT") ? "" : giv_mode(cbMode.Text);
        }

        private void Orders_Boards_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            string lotLID_CHS = "0", PO = "", RecDat = "";
            if (lbcod.Text == "") MessageBox.Show("You have to select a Board Name !");
            else
            {
                Orders_BoardLots frm_brdLot = new Orders_BoardLots('V', lbcod.Text);
                this.Hide();
                frm_brdLot.ShowDialog();
                lotLID_CHS = frm_brdLot.lotLid_CHS.Text;
                
                MainMDI.Find_2_Field("SELECT  l_Recep_date, l_lotPOnb   from PSM_R_Boards_lot WHERE l_lotLID=" + lotLID_CHS, ref RecDat, ref PO);
                if (RecDat != MainMDI.VIDE) cbLots.Text = MainMDI.Eng_date(RecDat, "/") + "-" + PO;
                //else MessageBox.Show("Error in seeking LotLID....call you Admin....!!");
            }
            this.Visible = true;
        }

        private void btnNR_Click(object sender, EventArgs e)
        {
            if (cbTPV.Text != "SELECT") //&& cbTPV.Text != "")
            {
                if (btnNR.Text != "Save")
                {
                    //tPV.BringToFront();
                    trevNN.Visible = true;

                    btnNR.Text = "Save";
                }
                else
                {
                    if (lRev_curr.Text != "")
                    {
                        if (Int32.Parse(trevNN.Text) > Int32.Parse(lRev_curr.Text))
                        {
                            string stSql = "UPDATE PSM_C_Boards_Lmdl SET " + " [m_Desc_eng]='" + ldebRev.Text + trevNN.Text + "' WHERE m_mdlLID=" + lmdlLID.Text;
                            MainMDI.Exec_SQL_JFS(stSql, "update Firmware Rev....");

                            fill_cbBrd_softVer(lbcod.Text);
                            cbTPV.Text = ldebRev.Text + trevNN.Text;
                            trevNN.Visible = false;
                            btnNR.Text = "Rev++";
                        }
                        else MessageBox.Show("Revision # must be >" + lRev_curr.Text);
                    }
                    else MessageBox.Show("Error: PGC cannot calculate Revision # ...call PGC Admin....");
                }
            }
        }

        private void tPV_DoubleClick(object sender, EventArgs e)
        {
            if (tPV.ReadOnly)
            {
                cbTPV.Visible = true;
                tPV.ReadOnly = false;
                btnNR.Visible = true;
            }
        }
    }
}