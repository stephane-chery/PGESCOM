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
    public partial class Setng_002 : Form
    {
        private string in_brdLID="";
        private int cur_LV_ndx=-1;
        private char in_cod;
        private EAHLibs.Lib1 Tools=new Lib1 ();
        private string lITMLID = "";


        public Setng_002()
        {
            InitializeComponent();

         //   in_brdLID  = x_brdLID  ;
        //    in_cod  = x_cod ;
            cbCurr.Text = "Select Currency";  
            fill_Itms(cbCurr.SelectedIndex+1    );
           ed_lvITM.AddEditableCell (-1,2);//  lvAllProjects.AddEditableCell(-1, jj)
           ed_lvITM.AddEditableCell(-1, 3);

        }


        private void fill_Itms(int _curr)
        {
            clr_scrn_info();
         //   if (cur_LV_ndx > -1) grpITM.Visible = false;
            cur_LV_ndx = -1;
            string stSql = "select * from dbo.PSM_R_SBill_XRate where CurrencyLID=" + _curr + " Order  by [XR_Date]"; 

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvITM.Items.Add(Oreadr["XR_LID"].ToString());
                DateTime dt = DateTime.Parse(Oreadr["XR_Date"].ToString());
                lv.SubItems.Add(dt.ToShortDateString());

                lv.SubItems.Add(Oreadr["XRate"].ToString());
                lv.SubItems.Add(Oreadr["XR_Cmnt"].ToString());

     

            }
            OConn.Close();

        }

        private void NewItm_Click(object sender, EventArgs e)
        {
            cur_LV_ndx = -1;
            clr_scrn_info();
          //  grpITM.Visible = true;

        }
        private void clr_scrn_info()
        {

            dpdate.Text = DateTime.Now.ToShortDateString(); 
          //  tXrate.Clear ();
            txcmnt.Clear();

        }


        private bool fields_OK(int ndx)
        {
            bool res = true;
            if (Tools.Conv_Dbl ( ed_lvITM.Items[ndx].SubItems[2].Text ) ==0)
            {
                res = false;
                MessageBox.Show("Exchange Invalid (line=" + Convert.ToString  (ndx+1) );
                txR_date.Focus();
            }
                    
               
           return res;
        }
   /*          
        private bool fields_OK()
        {
            bool res = true;
            if (txR_date.Text == "")
            {
                res = false;
                MessageBox.Show("Date is Invalid....");
                txR_date.Focus();
            }
            else
            {
                if (Tools.Conv_Dbl(tXrate.Text) == 0)
                {
                    res = false;
                    MessageBox.Show("Xchange Rate is Invalid..");
                    tXrate.Focus();
                }
            }    
               
           return res;
        }
    * */

        private bool dateExist(string dt)
        {

            for (int i=0;i<ed_lvITM.Items.Count ;i++)
                if (ed_lvITM.Items[i].SubItems[1].Text ==dt)   return true;
           return false;
        }


         private long XSP_NSRT_ALL(string SP_Name,string[,] arr_param,int NB_para,string err_Msg)
        {
            string LID = "-1";
            string stXP = "";
            try
            {
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = new SqlCommand(SP_Name , OConn);
                Ocmd.CommandType = CommandType.StoredProcedure;
                int i=0;
               while (i<(NB_para))
               {
                   Ocmd.Parameters.AddWithValue(arr_param[i,0],arr_param[i++,1]); 
               }
                   
                  //  LID = Ocmd.exe;
                SqlDataReader rdr = Ocmd.ExecuteReader();
                while (rdr.Read()) LID = rdr[0].ToString();
                OConn.Close();
                stXP = MainMDI.VIDE;
                return Int64.Parse(LID);
            }
            catch (SqlException Oexp)
            {
                stXP = Oexp.Message;
                MessageBox.Show(err_Msg + " EX. Msg= " + stXP);
                return -1;

            }
        }



        
                        // MainMDI.ExecSql("delete  PSM_Boards where b_RRevDetLID=" + lvCurRev.Items[Selndx].SubItems[4].Text);

                         //   stSql = "INSERT INTO PSM_R_SBill_XRate ([XR_Date],[XRate],[XR_Cmnt]) VALUES (" +
                         //       MainMDI.SSV_date(txR_date.Text) + " , " +
                         //       tXrate.Text + " , '" +
                         //       txcmnt.Text + "' )";
                          //  MainMDI.Exec_SQL_JFS(stSql, "New Xchange Rate....");


        private void Sav_Itm_Click(object sender, EventArgs e)
        {
            string stSql = "";
            if (MainMDI.ALWD_USR("ST_ACT", true) || MainMDI.User.ToLower ()=="mrouleau"  )
            {
                for (int i = 0; i < ed_lvITM.Items.Count; i++)
                {
                    if (fields_OK(i))
                    {

                        if (ed_lvITM.Items[i].SubItems[0].Text == "")
                        {

                            int NB_par = 5;
                            string[,] _arr_param = new string[NB_par, 2];
                            int t = 0;
                            _arr_param[t, 0] = "@CurrencyLID"; _arr_param[t++, 1] = lCurr.Text  ;
                            _arr_param[t, 0] = "@XR_Date"; _arr_param[t++, 1] = ed_lvITM.Items[i].SubItems[1].Text;// MainMDI.SSV_date(ed_lvITM.Items[i].SubItems[1].Text);
                            _arr_param[t, 0] = "@XRate"; _arr_param[t++, 1] = ed_lvITM.Items[i].SubItems[2].Text;
                            _arr_param[t, 0] = "@XR_Cmnt"; _arr_param[t++, 1] = ed_lvITM.Items[i].SubItems[3].Text;
                            _arr_param[t, 0] = "@CSTYLE"; _arr_param[t++, 1] = MainMDI.C_Style; //for date conversion


                            ed_lvITM.Items[i].SubItems[0].Text = XSP_NSRT_ALL("NSRT_XRate", _arr_param, NB_par, "Error NSRT_XRate").ToString();
                            MainMDI.Write_JFS("Insert New Xchange Rate: " + _arr_param[0, 1] + " date=" + _arr_param[1, 1]);
                        }
                        else
                        {
                            //" [XR_Date]=" + MainMDI.SSV_date(txR_date.Text) +
                            stSql = "UPDATE PSM_R_SBill_XRate  SET " +
                                 " [XRate]=" + ed_lvITM.Items[i].SubItems[2].Text + ", [XR_Cmnt]='" + ed_lvITM.Items[i].SubItems[3].Text + "' WHERE XR_LID=" + ed_lvITM.Items[i].SubItems[0].Text;
                            MainMDI.Exec_SQL_JFS(stSql, "Update Xchange Rate....");

                        }
                     

                    }
                }
               
            }
            fill_Itms(cbCurr.SelectedIndex+1);
            txR_date.BringToFront(); 
        }


        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

  

  




        private void ed_lvITM_DoubleClick(object sender, EventArgs e)
        {
            //No date change : delete and insert new date
            /*
            if (MainMDI.ALWD_USR("ST_ACT", true))
            {
                cur_LV_ndx = ed_lvITM.SelectedItems[0].Index;
                Edit_ITM(cur_LV_ndx);
          

            }
            */

        }

        private void Edit_ITM(int lv_ndx)
        {

            //     tBrdDesc.Text = ed_lvBRD.Items[lv_ndx].SubItems[1].Text; CB_brd.Visible = false;
           // lITMLID = ed_lvITM.Items[lv_ndx].SubItems[0].Text;
            dpdate.Text = ed_lvITM.Items[lv_ndx].SubItems[1].Text;
        //    tXrate.Text = ed_lvITM.Items[lv_ndx].SubItems[2].Text;
            txcmnt.Text = ed_lvITM.Items[lv_ndx].SubItems[3].Text;

        }

        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dpdate_ValueChanged(object sender, EventArgs e)
        {
            txR_date.Text = dpdate.Value.ToShortDateString();
        }

        private void tXrate_KeyPress(object sender, KeyPressEventArgs e)
        {
           // e.Handled = Tools.OnlyDBL(e.KeyChar);
            if (e.KeyChar == 13) tXrate_MouseLeave(sender, e);
        }

        private void txR_date_TextChanged(object sender, EventArgs e)
        {

        }

        private void txR_date_DoubleClick(object sender, EventArgs e)
        {
            dpdate.BringToFront();
        }

        private void tXrate_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Hiiiiiiiiiiiiiiiiii"); 
        }

        private void picNew_Click(object sender, EventArgs e)
        {
            cur_LV_ndx = -1;
            if (!dateExist(txR_date.Text) && cbCurr.SelectedIndex >0 )
            {
                ListViewItem lv = ed_lvITM.Items.Add("");
                lv.SubItems.Add(txR_date.Text);
                lv.SubItems.Add("0.0");
                lv.SubItems.Add("  ");
            }
            else MessageBox.Show("Date already Exists, Change Date by double-clicking on Date !!! "); 
        }

        private void tXrate_KeyDown(object sender, KeyEventArgs e)
        {
         
        }

        private void tXrate_MouseLeave(object sender, EventArgs e)
        {
            MessageBox.Show("Hooooooooooooooo"); 
        }

        private void del_BRD_Click(object sender, EventArgs e)
        {
            int ndx=ed_lvITM.SelectedItems[0].Index  ;
            if (MainMDI.Confirm("want to delete this rate ?"))
            {
                MainMDI.Exec_SQL_JFS("delete  PSM_R_SBill_XRate where XR_LID=" + ed_lvITM.Items[ndx].SubItems[0].Text," delete Xchange rate..");
                fill_Itms(cbCurr.SelectedIndex+1);
            }
            
        }

        private void cbCurr_SelectedIndexChanged(object sender, EventArgs e)
        {
            lCurr.Text = Convert.ToString (cbCurr.SelectedIndex+1);
            fill_Itms(cbCurr.SelectedIndex+1);
        }

        private void Setng_002_Load(object sender, EventArgs e)
        {
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!"; 
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
            cbCurr.SelectedIndex = 1; 
        }





    }
}