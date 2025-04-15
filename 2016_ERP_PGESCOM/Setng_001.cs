using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using EAHLibs;


namespace PGESCOM
{
    public partial class Setng_001 : Form
    {
        private string in_brdLID="";
        private int cur_LV_ndx=-1;
        private char in_cod;
        private EAHLibs.Lib1 Tools=new Lib1 ();
        private string lITMLID = "";


        public Setng_001()
        {
            InitializeComponent();

         //   in_brdLID  = x_brdLID  ;
        //    in_cod  = x_cod ;
            fill_Itms();
            del_BRD.Visible = (MainMDI.User.ToLower() == "ede"); 

        }

        private void fill_Itms()
        {
            clr_scrn_info();
            if (cur_LV_ndx > -1) grpITM.Visible = false;
            cur_LV_ndx = -1;
            string stSql = "select * FROM PSM_CmpnyTYPE where NorO='N'"; 

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvITM.Items.Add(Oreadr["CpnyType_ID"].ToString());
                lv.SubItems.Add(Oreadr["CpnyType"].ToString());
                lv.SubItems.Add(Oreadr["multpl1"].ToString());
                lv.SubItems.Add(Oreadr["multpl1_US"].ToString());
                lv.SubItems.Add(Oreadr["multpl1_EURO"].ToString());
                lv.SubItems.Add(Oreadr["cfDesc"].ToString());
     

            }
            OConn.Close();

        }

        private void NewItm_Click(object sender, EventArgs e)
        {
            cur_LV_ndx = -1;
            clr_scrn_info();
            grpITM.Visible = true;

        }
        private void clr_scrn_info()
        {

            tActv.Clear();
            tCANMult.Text ="1";// .Clear();
            tUSMlt.Text = "1";// .Clear();
            tEurMlt.Text = "1";// .Clear();

            txcmnt.Clear();

            //  tBrdDesc.Clear();



        }
        private bool fields_OK()
        {
            bool res = true;
            if (tActv.Text == "")
            {
                res = false;
                MessageBox.Show("Activity Name is Invalid....");
                tActv.Focus();
            }
            else
            {
                if (Tools.Conv_Dbl(tCANMult.Text) == 0)
                {
                    res = false;
                    MessageBox.Show("Canadian Multiplier is Invalid..");
                    tCANMult.Focus();
                }
                else
                {
                    if (Tools.Conv_Dbl(tUSMlt.Text )== 0)
                    {
                        res = false;
                        MessageBox.Show("US Multiplier is Invalid..");
                        tUSMlt.Focus();
                    }

                    else
                    {
                        if (Tools.Conv_Dbl(tEurMlt.Text) == 0)
                        {
                            res = false;
                            MessageBox.Show("EURO Multiplier is Invalid..");
                            tEurMlt.Focus();
                        }
                    }
                }
            }

            return res;
        }

        private void Sav_Itm_Click(object sender, EventArgs e)
        {
            string stSql = "";
            if (MainMDI.ALWD_USR("ST_CPT", true))
            {

                if (fields_OK())
                {
                
                    if (cur_LV_ndx == -1)
                    {

                        // MainMDI.ExecSql("delete  PSM_Boards where b_RRevDetLID=" + lvCurRev.Items[Selndx].SubItems[4].Text);
                        stSql = "INSERT INTO PSM_CmpnyTYPE ([CpnyType],[multpl1],[cfDesc],[multpl1_US],[multpl1_EURO],[NorO]) VALUES ('" +
                            tActv.Text  + "' , " +
                            tCANMult.Text + " , '" +
                            txcmnt.Text + "' , " +
                            tUSMlt.Text + " , " +
                            tEurMlt.Text + " , 'N')";
                        MainMDI.Exec_SQL_JFS (stSql,"New Activity....");
            
                       
                    }
                    else
                    {

                        stSql = "UPDATE PSM_CmpnyTYPE SET " +
                            " [CpnyType]='" + tActv.Text + "', [multpl1]=" + tCANMult.Text + ", [multpl1_US]=" + tUSMlt.Text   +
                            ", [multpl1_EURO]=" + tEurMlt.Text + ", [cfDesc]='" + txcmnt.Text + "' WHERE CpnyType_ID=" + ed_lvITM.Items[cur_LV_ndx].SubItems[0].Text;
                        MainMDI.Exec_SQL_JFS (stSql,"Update Activity....");
                          
                    }
                    fill_Itms();

                }
                //else MessageBox.Show("Some fields are Empty.....");
            }

        }


        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tCANMult_TextChanged(object sender, EventArgs e)
        {

        }

        private void tCANMult_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyDBL(e.KeyChar);
        }

        private void tUSMlt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyDBL(e.KeyChar);
        }

        private void tEurMlt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyDBL(e.KeyChar);
        }


        private void ed_lvITM_DoubleClick(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("ST_CPT", true))
            {
                cur_LV_ndx = ed_lvITM.SelectedItems[0].Index;
                Edit_ITM(cur_LV_ndx);
                grpITM.Visible = true;

            }


        }

        private void Edit_ITM(int lv_ndx)
        {

            //     tBrdDesc.Text = ed_lvBRD.Items[lv_ndx].SubItems[1].Text; CB_brd.Visible = false;
           // lITMLID = ed_lvITM.Items[lv_ndx].SubItems[0].Text;
            tActv.Text = ed_lvITM.Items[lv_ndx].SubItems[1].Text;
            tCANMult.Text = ed_lvITM.Items[lv_ndx].SubItems[2].Text;
            tUSMlt.Text = ed_lvITM.Items[lv_ndx].SubItems[3].Text;
            tEurMlt.Text = ed_lvITM.Items[lv_ndx].SubItems[4].Text;
            txcmnt.Text = ed_lvITM.Items[lv_ndx].SubItems[5].Text;

        }

        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void del_BRD_Click(object sender, EventArgs e)
        {
            if ( ed_lvITM.SelectedItems.Count ==1 &&  MainMDI.Confirm ("Want to delete this Activity ?"))
            {
                int _ndx = ed_lvITM.SelectedItems[0].Index;
            string stSql = "UPDATE PSM_CmpnyTYPE SET [NorO]='O' WHERE CpnyType_ID=" + ed_lvITM.Items[_ndx].SubItems[0].Text;
            MainMDI.Exec_SQL_JFS(stSql, "Disable Activity....");
            fill_Itms();
            }
        }

        private void Setng_001_Load(object sender, EventArgs e)
        {
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!"; 
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
        }


        /*
        private void fill_cbBrd()
        {
         //   CB_brd.Items.Clear();
            string stSql = "SELECT brd_Code, Brd_Name  from PSM_C_Boards_List WHERE DISP='D' ORDER BY brd_Code ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                li.Text = Oreadr["Brd_Name"].ToString();
                li.Value = Oreadr["brd_Code"].ToString();
               // CB_brd.Items.Add(li);
            }
            //	cbSerItems.BringToFront ();
            OConn.Close();
        }
        private bool fill_cbBrd_models(string _bcode)
        {
          //  cbmodel.Items.Clear();
            string stSql = "SELECT m_mdlLID, m_Desc_eng  from PSM_C_Boards_Lmdl WHERE type='m' and  m_brd_Code =" + _bcode + " and  m_DISP='D' ORDER BY rnk ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            bool found = false;
            while (Oreadr.Read())
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                li.Text = Oreadr["m_Desc_eng"].ToString();
                li.Value = Oreadr["m_mdlLID"].ToString();
         //       cbmodel.Items.Add(li);
                if (!found) found = true;
            }
            //	cbSerItems.BringToFront ();
            OConn.Close();
            if (!found) MessageBox.Show("No Model found for this Board ....please insert new models or choose another Board....");
            return found;
        }
        private void clr_brd_info()
        {

            tActv.Clear();
            tCANMult.Clear(); 

            txcmnt.Clear();

          //  tBrdDesc.Clear();
          


        }

        private void Newbrd_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_TR", true))
            {
                clr_brd_info();
                grpBrdSN.Visible = true;
             //   CB_brd.Visible = true;
            //    dpRecpdat.BringToFront(); 
                cur_LV_ndx = -1;
            //    tbomv.Visible = false;
            //    tbV.Visible = false;
           //     CB_brd.BringToFront(); 

                //if (CB_brd.Items.Count < 1) ;
            }

        }




        private void CB_brd_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CB_brd_SelectedValueChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
            itm = (System.Web.UI.WebControls.ListItem)CB_brd.Items[CB_brd.SelectedIndex];
            lbcod.Text = itm.Value;
            tActv.Text = CB_brd.Text;
        //    tBrdDesc.BringToFront();
            if (tActv.Text != "PC22_OLD" && tActv.Text != "PC21")
            {
                if (fill_cbBrd_models(lbcod.Text)) fill_Boards_lots(lbcod.Text);
                else clr_brd_info();
            }
            else
            {
                MessageBox.Show("Access Denied....");
                cbmodel.Items.Clear(); 
                clr_brd_info();
            }
  

            


        }
        private bool fields_OK()
        {
            bool res = true;
            if (tActv.Text == "")
            {
                res = false;
                MessageBox.Show("Error Board Name....");
                tActv.Focus();
            }
            else
            {
                if (msk_assdat.Text.IndexOf("_") >-1)   // == "00-00")
                {
                    res = false;
                    MessageBox.Show("Error assembly date....");
                    msk_assdat.Focus();
                }
                else
                {
                    if (msk_BomRev.Text == "0.0")
                    {
                        res = false;
                        MessageBox.Show("Error BOM Revision....");
                        msk_BomRev.Focus();
                    }
                    else
                    {
                        if (msk_pcbdat.Text.IndexOf("_") >-1) //   == "00-00")
                        {
                            res = false;
                            MessageBox.Show("Error PCB Date....");
                            msk_pcbdat.Focus();
                        }
                        else
                        {
                            if (txLotQty.Text == "")
                            {
                                res = false;
                                MessageBox.Show("Error Qty....");
                                txLotQty.Focus();
                            }
                            else
                            {
                                if (txLotPO.Text == "")
                                {
                                    res = false;
                                    MessageBox.Show("Error PO#....");
                                    txLotPO.Focus();
                                }
                                else
                                {
                                    if (cbmodel.Text == "")
                                    {
                                        res = false;
                                        MessageBox.Show("Error Model....");
                                        cbmodel.Focus();
                                    }
                                }
                            }
                        }
                    }

                }
            }


            return res ;
        }
        private void Sav_BRD_Click(object sender, EventArgs e)
        {
            string stSql = "";
            if (MainMDI.ALWD_USR("OR_SR2", true))
            {

                if (fields_OK())
                {
                    txLotQty.Text = "0";
                    if (cur_LV_ndx == -1)
                    {

                        // MainMDI.ExecSql("delete  PSM_Boards where b_RRevDetLID=" + lvCurRev.Items[Selndx].SubItems[4].Text);
                        stSql = "INSERT INTO PSM_R_Boards_lot ([l_recep_date],[l_lotPOnb],[l_qty],[l_brd_Code],[l_brd_Ver],[l_usr],[l_Pcb_date],[l_BOM_Rev],[l_cmnt],[l_assembly_date]) VALUES (" +
                            MainMDI.SSV_date(txR_date.Text) + " , '" +
                            txLotPO.Text   + "' , '" +
                            txLotQty.Text  + "' , '" +
                               lbcod.Text + "' , '" +
                               tbV.Text + "' , '" +
                               MainMDI.User + "' , '" +
                               msk_pcbdat.Text + "' , '" +
                               tbomv.Text + "' , '" +
                               txcmnt.Text + "' , '" +
                               msk_assdat.Text + "')";
                        MainMDI.ExecSql(stSql);
                        MainMDI.Write_JFS(stSql);
                        fill_Boards_lots(lbcod.Text  );
                    }
                    else
                    {
                        
                        stSql = "UPDATE PSM_R_Boards_lot SET " + " [l_recep_date]=" + MainMDI.SSV_date(txR_date.Text) + ", [l_lotPOnb]='" + txLotPO.Text + "', [l_qty]='" + txLotQty.Text + "', [l_brd_Ver]='" + tbV.Text + "', [l_usr]='" + MainMDI.User + "',[l_Pcb_date]='" + msk_pcbdat.Text + "',[l_assembly_date]='" +
                                msk_assdat.Text + "',[l_BOM_Rev]='" + tbomv.Text + "',[l_cmnt]='" + txcmnt.Text + "' WHERE l_lotLID=" + ed_lvBRD.Items[cur_LV_ndx].SubItems[0].Text;
                        MainMDI.ExecSql(stSql);
                        MainMDI.Write_JFS(stSql);
                        fill_Boards_lots(lbcod.Text);
                    }

                }
                //else MessageBox.Show("Some fields are Empty.....");
            }
     //       else MessageBox.Show(MainMDI.User + ": is NOT allowed to perform this option, contact you Admin....! ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            
        }


        private void fill_Boards_lots(string _lbcod)
        {
           clr_brd_info();
           if (cur_LV_ndx >-1)  grpBrdSN.Visible = false; 
            cur_LV_ndx =-1;
            string stSql = " SELECT PSM_R_Boards_lot.*, PSM_C_Boards_List.SN_Coding FROM PSM_R_Boards_lot INNER JOIN PSM_C_Boards_List ON PSM_R_Boards_lot.l_brd_Code = PSM_C_Boards_List.brd_Code " +
                           " WHERE PSM_C_Boards_List.disp = 'D' and PSM_C_Boards_List.brd_code=" + _lbcod; 
                    
            
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                ed_lvBRD.Items.Clear();
                while (Oreadr.Read())
                {
                    ListViewItem lv = ed_lvBRD.Items.Add(Oreadr["l_lotLID"].ToString());
                    DateTime dt = DateTime.Parse (  Oreadr["l_Recep_date"].ToString()); 
                    lv.SubItems.Add(dt.ToShortDateString ());
                    lv.SubItems.Add(Oreadr["l_lotPOnb"].ToString());
                    lv.SubItems.Add(Oreadr["l_brd_Ver"].ToString());
                    lv.SubItems.Add(Oreadr["l_BOM_Rev"].ToString());
                    lv.SubItems.Add(Oreadr["l_PCB_date"].ToString());
                    lv.SubItems.Add(Oreadr["l_assembly_date"].ToString());
                    lv.SubItems.Add(Oreadr["l_QTY"].ToString());
                    lv.SubItems.Add(Oreadr["l_cmnt"].ToString());

                }
                OConn.Close();
          
        }

        private void dpPCBdat_ValueChanged(object sender, EventArgs e)
        {
           // tpcbdat.Text = dpPCBdat.Value.ToShortDateString(); 
        }

        private void dpassdat_ValueChanged(object sender, EventArgs e)
        {
          //txassdat.Text =  dpassdat.Value.ToShortDateString(); 
        }

        private void Orders_Boards_Load(object sender, EventArgs e)
        {
           // this.Text = "Boards for Serial#: " + in_sys_SN;
            string _bcod = (in_cod == 'C') ? _bcod = lbcod.Text : in_brdLID;
            fill_Boards_lots(_bcod );
        }

        private void ed_lvBRD_DoubleClick(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_TR", true))
            {
                cur_LV_ndx = ed_lvBRD.SelectedItems[0].Index;
                if (in_cod == 'C')
                {

                    tActv.BringToFront();
                    Edit_Board(cur_LV_ndx);
                    grpBrdSN.Visible = true;

                }
                else
                {
                    lotLid_CHS.Text  = ed_lvBRD.Items[cur_LV_ndx].SubItems[0].Text;
                    this.Hide ();
                }
            }


        }

        private void Edit_Board(int lv_ndx)
        {

           //     tBrdDesc.Text = ed_lvBRD.Items[lv_ndx].SubItems[1].Text; CB_brd.Visible = false;
            lLotsLID.Text = ed_lvBRD.Items[lv_ndx].SubItems[0].Text; 
            dpRecpdat.Text = ed_lvBRD.Items[lv_ndx].SubItems[1].Text;
            txLotPO.Text = ed_lvBRD.Items[lv_ndx].SubItems[2].Text; 


            tbomv.Text = ed_lvBRD.Items[lv_ndx].SubItems[4].Text;
            int ipos = tbomv.Text.IndexOf("-Rev.");
            if (ipos > -1)
            {
                cbmodel.Text = tbomv.Text.Substring(0, ipos );
                msk_BomRev.Text = tbomv.Text.Substring(ipos + 5, tbomv.Text.Length - ipos - 5);
            }
            else MessageBox.Show("Error ROM Revision......please call your admin....");

            tbV.Text = ed_lvBRD.Items[lv_ndx].SubItems[3].Text;
            ipos = tbV.Text.IndexOf("-");
            if (ipos >-1)
            {

                 msk_grb_ver.Text = tbV.Text.Substring (4,ipos-4);
                dp_grbDate.Text = tbV.Text.Substring (ipos+7,2)  + "/" + tbV.Text.Substring (ipos+5,2)  +"/" + tbV.Text.Substring (ipos+1,4);  
            }
            else MessageBox.Show("Error Gerber Version......please call your admin....");

 
            
            msk_pcbdat.Text = ed_lvBRD.Items[lv_ndx].SubItems[5].Text;
            msk_assdat.Text = ed_lvBRD.Items[lv_ndx].SubItems[6].Text;
            txLotQty.Text = ed_lvBRD.Items[lv_ndx].SubItems[7].Text; 

            tbV.Visible =false;
            tbomv.Visible =false;
      

        }


        private void ed_lvBRD_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txassdat_DoubleClick(object sender, EventArgs e)
        {
           // dpassdat.Visible = true;
        }

        private void tpcbdat_DoubleClick(object sender, EventArgs e)
        {
          //  dpPCBdat.Visible = true;
        }

        private void del_BRD_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_SR2", true))
            {
                if (ed_lvBRD.SelectedItems.Count ==1)
                {
                    cur_LV_ndx = ed_lvBRD.SelectedItems[0].Index;
                    if (MainMDI.Find_One_Field("SELECT  R_BrdLID FROM PSM_R_Boards WHERE b_lotLID =" + ed_lvBRD.Items[cur_LV_ndx].SubItems[0].Text) == MainMDI.VIDE)
                    {
                        
                        string stSql = "delete PSM_R_Boards_lot where l_lotLID =" + ed_lvBRD.Items[cur_LV_ndx].SubItems[0].Text;
                        MainMDI.ExecSql(stSql);
                        MainMDI.Exec_SQL_JFS(stSql, "Delete Board_lot info");
                        fill_Boards_lots(lbcod.Text);
                    }
                    else MessageBox.Show("Sorry you can not delete this batch....(many boards Exist)"); 

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
         //   dpassdat.Text = "01/01/1900";
       //     dpPCBdat.Text = "01/01/1900";
            MessageBox.Show("GO................"); 

            while (Oreadr.Read())
            {
                clr_brd_info();
                _DetLID = Oreadr["b_RRevDetLID"].ToString();
                get_BoardInfo(Oreadr["brd_Desc"].ToString(), ref ar_T);

                tActv.Text = ar_T[0];
 

                lbcod.Text = MainMDI.Find_One_Field("select brd_Code from PSM_C_Boards_List brd_Code where Brd_Name='" + tActv.Text + "'");
                if (lbcod.Text == MainMDI.VIDE) MainMDI.ExecSql("insert into PSM_C_Boards_List ([Brd_Name],[Brd_desc],[SN_Coding],[Brd_FR_Desc]) " +
                           "VALUES ('" + tActv.Text + "', 'n/a','A','n/a') "); lbcod.Text = MainMDI.Find_One_Field("select brd_Code from PSM_C_Boards_List brd_Code where Brd_Name='" + tActv.Text + "'");
                lbcod.Text = MainMDI.Find_One_Field("select brd_Code from PSM_C_Boards_List brd_Code where Brd_Name='" + tActv.Text + "'");
                if (lbcod.Text == MainMDI.VIDE) MessageBox.Show("ADD board name: " + tActv.Text);

                tbV.Text = ar_T[1];
           //     tPV.Text = ar_T[2];
         //       tConTo.Text = ar_T[3];
          //      tmanual.Text = ar_T[4];
         //       tBrdSN.Text = Oreadr["brd_SN"].ToString();
                stSql = "INSERT INTO PSM_R_Boards ([b_RRevDetLID],[brd_Code],[brd_SN],[brd_Ver],[firmwr_Ver],[b_connTo],[b_Manual],[b_Pcb_date],[b_BOM_Rev],[b_assembly_date]) VALUES (" +
   _DetLID + " , '" +
   lbcod.Text + "' , '" +
  // tBrdSN.Text + "' , '" +
   tbV.Text + "' , '" +
 //  tPV.Text + "' , '" +
//   tConTo.Text + "' , '" +
//   tmanual.Text + "' , " +
 //  MainMDI.SSV_date(tpcbdat.Text) + " , '" +
   tbomv.Text + "' , " +
 //  MainMDI.SSV_date(txassdat.Text) + ")";
                MainMDI.ExecSql(stSql);   
            }
            OConn.Close();
            MessageBox.Show("Finishhhhhhhhhhhhhhhhhhhhh"); 

        }


        private void get_BoardInfo(string tt, ref string[] ar_T)
        {
            //	t1="";t2="";t3="";t4="";
            //	string[] ar_T=new string[4];
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

        private void dpRecpdat_ValueChanged(object sender, EventArgs e)
        {
            txR_date.Text  =dpRecpdat.Value.ToShortDateString();
        }


        private void msk_grb_ver_MaskChanged(object sender, EventArgs e)
        {
            //maj_tbv();
        }
        private void maj_tbv()
        {
            if (ldp_grbDate.Text == "") ldp_grbDate.Text = dp_grbDate.Value.ToShortDateString();    
            tbV.Text = grbr_lver.Text + msk_grb_ver.Text + "-" + MainMDI.Eng_date(ldp_grbDate.Text,"");
        }
        private void maj_RomV()
        {
            tbomv.Text = cbmodel.Text + "-" + lbomRev.Text + msk_BomRev.Text;  
         }
        private void dp_grbDate_ValueChanged(object sender, EventArgs e)
        {
            ldp_grbDate.Text = dp_grbDate.Value.ToShortDateString();
        }

        private void ldp_grbDate_TextChanged(object sender, EventArgs e)
        {
            maj_tbv();
        }

        private void msk_grb_ver_TextChanged(object sender, EventArgs e)
        {
            maj_tbv();
        }

        private void cbmodel_SelectedIndexChanged(object sender, EventArgs e)
        {
            maj_RomV();

            System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
            itm = (System.Web.UI.WebControls.ListItem)cbmodel.Items[cbmodel.SelectedIndex];
            lmodelLID.Text   = itm.Value;
            //tBrdDesc.Text = CB_brd.Text;
            //tBrdDesc.BringToFront();

        }
         * */

 

        /*
         *    private void btnNewSNb_Click(object sender, EventArgs e)
     {

         if (lItem.Text != "")
         {
             if (MainMDI.ALWD_USR("OR_SR1", true))
             {
                 this.Cursor = Cursors.WaitCursor;
                 long Res = fill_SNID();
                 if (Res == 0 || Res == -1) MessageBox.Show("Unable to Generate Serial#,  please call you Admin. !!!!");
                 else
                 {
                     TPXsn.Text = "S" + Res.ToString();
                     //		MainMDI.flag_QRID('S','f',true,Convert.ToInt32(Res.ToString())) ;
                     //		MainMDI.flag_QRID('S','u',true,Convert.ToInt32(Res.ToString())) ;

                     btnNewID.Visible = false;
                     arr_SNcr[SNi++] = Res.ToString();


                 }
                 this.Cursor = Cursors.Default;
                 btn_Newsn.Enabled = false;
                 toolBar1.Buttons[3].Enabled = false;
             }
         }
             
     }

         * 
         * 
         * 
         * */







    }
}