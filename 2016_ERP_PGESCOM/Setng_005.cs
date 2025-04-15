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
    public partial class Setng_005 : Form
    {
        private string lCurr_Tblid = "0";
        private int lnbCols = 0, sel_Ndx=-1,sel_ndxT=-1;
        private EAHLibs.Lib1 Tools=new Lib1 ();
        private char in_opera='R';


        public Setng_005(char x_opera)
        {
            InitializeComponent();
            in_opera = x_opera;

         //   in_brdLID  = x_brdLID  ;
        //    in_cod  = x_cod ;
     //      ed_lvTables.AddEditableCell (-1,2);//  lvAllProjects.AddEditableCell(-1, jj)
     //      ed_lvTables.AddEditableCell(-1, 3);



            fill_tablesNm();
           txSql.Visible = (MainMDI.User.ToLower() == "ede");

        }





      /**********************************************************************/

        private void fill_tablesNm()
        {

            ed_lvTables.Items.Clear();
            string stSql = " SELECT * From TABLES_LIST Where (TABLE_IMPORTANCE <> 'S') ORDER BY TABLE_NAME";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvTables.Items.Add(Oreadr["TABLE_ID"].ToString());
                lv.SubItems.Add(Oreadr["TABLE_NAME"].ToString());
                lv.SubItems.Add(Oreadr["NBCOL"].ToString());
                lv.SubItems.Add(Oreadr["TABLE_EXT"].ToString());
                lv.SubItems.Add(Oreadr["cmnt"].ToString());
               
            }
            if (ed_lvTables.Items.Count > 0) Sel_Table(0); 
            OConn.Close();
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ed_lvTables_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ed_lvTables_Click(object sender, EventArgs e)
        {
            Sel_Table(ed_lvTables.SelectedItems[0].Index   );
        }

        private void Sel_Table(int ndx_tbl)
        {
            if (ndx_tbl > -1)
            {
                grpDet.Visible = true;
                lCurr_Tblid = ed_lvTables.Items[ndx_tbl].SubItems[0].Text;
                txTNm.Text = ed_lvTables.Items[ndx_tbl].SubItems[1].Text; 
                lnbCols = Int32.Parse (ed_lvTables.Items[ndx_tbl].SubItems[2].Text);
                fill_tables_Detail(lCurr_Tblid);
                lnbCols = Int32.Parse(ed_lvTables.Items[ndx_tbl].SubItems[2].Text);
               Display_Cols ();
            }

        }
        private void Display_Cols()
        {

            for (int i = 1; i < 7; i++) ed_lvDetails.Columns[i].Width = (i < lnbCols) ? 90 : 0;
        }
 
        private void fill_tables_Detail(string Tbl_ID)
        {
            // sqlDS_tables.SelectCommand = "SELECT TABLE_Line_id, TABLE_ID, VALUE1, COL1, COL2, COL3, COL4, COL5, COL6, disp FROM TABLES_CONTENT WHERE TABLE_ID =" + lblCod.Text + " Order by TABLE_Line_id " ;
            string edest = (MainMDI.User.ToLower()=="ede" && chkall.Checked) ? "" : " and disp='1' ";
            ed_lvDetails.Items.Clear();
            string ordST = (txTNm.Text.ToUpper() == "COEFICIENTS") ? " Order by  COL1" : " Order by TABLE_Line_id ";
           //PIV_ARM , PIV_PRICE_ADJST only
            if (Tbl_ID == "37" || Tbl_ID == "49" || Tbl_ID == "50") ordST = " AND (COL1 <> 'n/a')  Order by cast(COL1 as float), cast(COL3 as float), cast(COL2 as float) ";
            string stSql = " SELECT * FROM TABLES_CONTENT WHERE TABLE_ID =" + Tbl_ID  + edest + ordST  ;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql; txSql.Text = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvDetails.Items.Add(Oreadr["TABLE_Line_id"].ToString());
                for (int c=3;c<9;c++) lv.SubItems.Add(Oreadr[c].ToString());
                lv.SubItems.Add(Oreadr["VALUE1"].ToString());
                lv.SubItems.Add(Oreadr["disp"].ToString());
                lv.BackColor = Color.LightGoldenrodYellow; 
               
            }
  
            OConn.Close();
        }
        private void Edit_detail_cols()
        {

            for (int i = 1; i < 9; i++)  if (i < lnbCols) ed_lvDetails.AddEditableCell(-1, i);
            ed_lvDetails.AddEditableCell(-1, 7);
        }
        private void Edit_Tables_cols()
        {

            for (int i = 1; i < 5; i++) if (i < lnbCols) ed_lvDetails.AddEditableCell(-1, i);
            ed_lvDetails.AddEditableCell(-1, 7);
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            ListViewItem lv = ed_lvDetails.Items.Add("");
            for (int i=1;i<8;i++) lv.SubItems.Add(MainMDI.VIDE  );
            lv.SubItems.Add("1");
            lv.BackColor = Color.Lavender;  
            Edit_detail_cols();
            pictureBox1.Enabled = false;


        }
        private bool fields_OK(int ndx)
        {
            for (int i = 1; i < 9; i++) if (ed_lvDetails.Items[ndx].SubItems[i].Text=="") return false;
            return true;
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
         //   
            if ( in_opera =='W') Save_Details();
            else MessageBox.Show("Access Denied"); 
            
         
        }
        private void Save_Details()
        {
            string stSql = "";

                for (int i = 0; i < ed_lvDetails.Items.Count; i++)
                {
                    if (fields_OK(i))
                    {

                        if (ed_lvDetails.Items[i].SubItems[0].Text == "")
                        {
                            stSql = "INSERT INTO TABLES_CONTENT ([TABLE_ID],[COL1],[COL2],[COL3],[COL4],[COL5],[COL6],[Value1],[Disp]) VALUES (" +
                                     lCurr_Tblid + " , '" +
                                    ed_lvDetails.Items[i].SubItems[1].Text + "' , '" +
                                    ed_lvDetails.Items[i].SubItems[2].Text + "' , '" +
                                    ed_lvDetails.Items[i].SubItems[3].Text + "' , '" +
                                    ed_lvDetails.Items[i].SubItems[4].Text + "' , '" +
                                    ed_lvDetails.Items[i].SubItems[5].Text + "' , '" +
                                    ed_lvDetails.Items[i].SubItems[6].Text + "' , '" +
                                    ed_lvDetails.Items[i].SubItems[7].Text + "' , '" +
                                    ed_lvDetails.Items[i].SubItems[8].Text + "')";
                            MainMDI.Exec_SQL_JFS(stSql, "Insert in TABLE_CONTENT....(SETTING)....");
                        }

                        else
                        {
                            //" [XR_Date]=" + MainMDI.SSV_date(txR_date.Text) +
                            stSql = "UPDATE TABLES_CONTENT  SET " +
                                 "   [COL1]='" + ed_lvDetails.Items[i].SubItems[1].Text +
                                 "', [COL2]='" + ed_lvDetails.Items[i].SubItems[2].Text +
                                 "', [COL3]='" + ed_lvDetails.Items[i].SubItems[3].Text +
                                 "', [COL4]='" + ed_lvDetails.Items[i].SubItems[4].Text +
                                 "', [COL5]='" + ed_lvDetails.Items[i].SubItems[5].Text +
                                 "', [COL6]='" + ed_lvDetails.Items[i].SubItems[6].Text +
                                 "', [Value1]='" + ed_lvDetails.Items[i].SubItems[7].Text +
                                 "' WHERE TABLE_Line_id=" + ed_lvDetails.Items[i].SubItems[0].Text;
                            MainMDI.Exec_SQL_JFS(stSql, "Update TABLE_CONTENT....(SETTING)....");

                        }
                       
                    }

                }
                fill_tables_Detail(lCurr_Tblid);
                pictureBox1.Enabled = true;

          
        }
        private bool Fields_TableOK(ref string errMsg)
        {
            errMsg ="";
            int _nbc=(int) Tools.Conv_Dbl (txNBC.Text ); 
            if (txTname.Text.IndexOf ("'")>-1 || txTname.Text.Length <1  ) { errMsg =" Invalid  Table name..."; return false;}
            else if (_nbc <1 || _nbc >6)   { errMsg ="Columns # must be in [1...6] ..."; return false;}
            return true;
        }

        private void Sav_Itm_Click(object sender, EventArgs e)
        {
            if (grpTble.Visible && in_opera =='W')
            {

                string stSql = "";
                if (Fields_TableOK(ref stSql))
                {
                    if (lCurr_Tblid == "")
                    {
                        string NewLID = MainMDI.Find_One_Field("select max(TABLE_ID)+1 from  TABLES_LIST");
                        if (NewLID != MainMDI.VIDE)
                        {
                            stSql = "INSERT INTO TABLES_LIST ([TABLE_ID],[TABLE_NAME],[TABLE_IMPORTANCE],[TABLE_EXT],[NBCOL],[cmnt]) VALUES (" +
                                NewLID + " , '" +    
                                txTname.Text + "' , '" +
                                    " " + "' , '" +
                                    txUnit.Text + "' , '" +
                                    txNBC.Text + "' , '" +
                                    txDesc.Text.Replace("'","''")   + "')";
                            MainMDI.Exec_SQL_JFS(stSql, "Insert in TABLES_LIST....(SETTING)....");
                        }
                        else MessageBox.Show("Sorry can not Insert New table ....(error in [TABLE_ID])"); 
                    }
                    else
                    {
                        //" [XR_Date]=" + MainMDI.SSV_date(txR_date.Text) +
                        stSql = "UPDATE TABLES_LIST  SET " +
                             "   [TABLE_NAME]='" + txTname.Text +
                             "', [TABLE_EXT]='" + txUnit.Text +
                             "', [NBCOL]='" + txNBC.Text +
                             "', [cmnt]='" + txDesc +
                             "' WHERE TABLE_ID=" + lCurr_Tblid;
                        MainMDI.Exec_SQL_JFS(stSql, "Update in TABLES_LIST....(SETTING)....");

                    }
                    fill_tablesNm();
                    check_readOnly(true);
                    grpTble.Visible = false;
                    ed_lvTables.Enabled = true;

                }
                else MessageBox.Show("ERROR......" + stSql);
            }



               
        }

        private void picModif_Click(object sender, EventArgs e)
        {
             Edit_detail_cols();
        }

        private void button10_Click(object sender, EventArgs e)
        {
            fill_tables_Detail(lCurr_Tblid);
           
        }

        private void picDel_Click(object sender, EventArgs e)
        {
            if (ed_lvDetails.SelectedItems.Count > 0 && in_opera =='W')
            {
                for (int i = 0; i < ed_lvDetails.SelectedItems.Count; i++)
                {

                    string stSql = "UPDATE TABLES_CONTENT  SET [DISP]='0' WHERE TABLE_Line_id=" + ed_lvDetails.Items[ed_lvDetails.SelectedItems[i].Index ].SubItems[0].Text;
                    MainMDI.Exec_SQL_JFS(stSql, "Delete(display=0) in TABLE_CONTENT....(SETTING)....");

                }
                fill_tables_Detail(lCurr_Tblid);
            }
            
        }

        private void picAddT_Click(object sender, EventArgs e)
        {
            ListViewItem lv = ed_lvTables.Items.Add("");
            for (int i = 1; i < 5; i++) lv.SubItems.Add(MainMDI.VIDE);
            lv.BackColor = Color.Lavender;
            Edit_detail_cols();
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void check_readOnly(bool stat)
        {
            txTname.ReadOnly = stat;
            txNBC.ReadOnly = stat;
            txUnit.ReadOnly = stat;
         
        }
        private void NewItm_Click(object sender, EventArgs e)
        {
            lCurr_Tblid = "";
            grpTble.Visible = true;
            grpCols.Enabled = false;
            ed_lvTables.Enabled = false;
            check_readOnly(false);




        }

        private void chngT_Click(object sender, EventArgs e)
        {
            if (ed_lvTables.SelectedItems.Count == 1)
            {
                sel_ndxT = ed_lvTables.SelectedItems[0].Index;
                txTname.Text = ed_lvTables.Items[sel_ndxT].SubItems[1].Text;
                txNBC.Text  = ed_lvTables.Items[sel_ndxT].SubItems[2].Text;
                txUnit.Text = ed_lvTables.Items[sel_ndxT].SubItems[3].Text;
                txDesc.Text = ed_lvTables.Items[sel_ndxT].SubItems[4].Text;
                check_readOnly(ed_lvDetails.Items.Count > 0);
                grpTble.Visible = true; 
            }
          //  else MessageBox.Show("Select a Table......");
        }

        private void txPass_TextChanged(object sender, EventArgs e)
        {
            check_readOnly(txPass.Text != "2~~");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fill_tablesNm();
            check_readOnly(true);
            grpTble.Visible = false;
            ed_lvTables.Enabled = true;
        }

        private void txNBC_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyDBL(e.KeyChar);
        }

        private void delT_Click(object sender, EventArgs e)
        {

        }

        private void Setng_005_Load(object sender, EventArgs e)
        {
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
        }

        private void bld_Click(object sender, EventArgs e)
        {
            Fill_BigFile13 fillbgf = new Fill_BigFile13();
            fillbgf.ShowDialog();  
        }

        private void import_Click(object sender, EventArgs e)
        {
           // fill_EN1("1");
           // fill_EN1("3");
          //  fill_CHRG_WEIGHT();
            update_PIV_ARM_fromBACK();
            //####
        }

        private void fill_EN1(string phs)
        {
            string stSql = " select * from EN1_phs" + phs;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {

              //  SELECT * FROM TABLES_CONTENT WHERE TABLE_ID =37 and disp='1'  Order by TABLE_Line_id 
                stSql = "UPDATE TABLES_CONTENT  SET [VALUE1]='" + Oreadr["NewEN1"].ToString() +
                        "' WHERE TABLE_ID =37  AND COL1='" + Oreadr["PHS"].ToString() +
                        "' AND COL2='" + Oreadr["IDC"].ToString() +
                        "' AND COL3='" + Oreadr["VDC"].ToString() +"'";
                MainMDI.Exec_SQL_JFS (stSql ,"Import EN1....2009/nov");

            }

            OConn.Close();
        }

        private void update_PIV_ARM_fromBACK()
        {
            string stSql = " select * from [PIV_ARM-BACK] " ;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {

                //  SELECT * FROM TABLES_CONTENT WHERE TABLE_ID =37 and disp='1'  Order by TABLE_Line_id 
                stSql = "UPDATE TABLES_CONTENT  SET [VALUE1]='" + Oreadr["I_VALUE1"].ToString() +
                        "' WHERE TABLE_ID =37  AND COL1='" + Oreadr["I_COL1"].ToString() +
                        "' AND COL2='" + Oreadr["I_COL2"].ToString() +
                        "' AND COL3='" + Oreadr["I_COL3"].ToString() + "'";
                MainMDI.Exec_SQL_JFS(stSql, "IMPORT PIV_ARM from BACK....2010/Mars");

            }

            OConn.Close();
        }




        private void fill_CHRG_WEIGHT()
        {
            string stSql = " select * from import_chWEIGHT ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                double dd=Tools.Conv_Dbl(Oreadr["weight"].ToString());
                if (dd > 0)
                {
                    stSql = "UPDATE TABLES_CONTENT  SET [VALUE1]='" +Math.Round (dd,0).ToString () +
                            "' WHERE TABLE_ID =50  AND COL1='" + Oreadr["PHS"].ToString() +
                            "' AND COL2='" + Oreadr["IDC"].ToString() +
                            "' AND COL3='" + Oreadr["VDC"].ToString() + "'";
                    MainMDI.Exec_SQL_JFS(stSql, "Import chagers weight....2009/nov");
                }

            }

            OConn.Close();
        }

        private void ed_lvDetails_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
} 