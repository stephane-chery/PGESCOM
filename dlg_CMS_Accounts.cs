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
    public partial class dlg_CMS_Accounts : Form
    {
        private char in_CMS_USR = 'S';
        private EAHLibs.Lib1 Tools=new Lib1 ();
        string in_SA_id = "", in_SAName = "";
        


        public dlg_CMS_Accounts(char x_CMS_USR, string x_SA_name, string x_SA_id)// ComboBox x_cbSales)//,Hashtable  x_HT_Agencies)
        {
            InitializeComponent();
            in_CMS_USR  = x_CMS_USR ;
            in_SA_id = x_SA_id;
            in_SAName = x_SA_name;


     //       if (cbSA.Items.Count > 0) cbSA.SelectedIndex = 0;


            /*
             * copy combobox to combobox
            for (int i =0; i < x_cbSales.Items.Count; i++)      
            {
                System.Web.UI.WebControls.ListItem itm = (System.Web.UI.WebControls.ListItem)x_cbSales.Items[i];
                cbSA.Items.Add(itm);
            }
             * */
        }

        private void fill_cbSales()
        {
            cbSA.Visible = true;
            string stSql = "";
            System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
            switch (in_CMS_USR)
            {
                case 'C':
                case 'S':
                    stSql = "SELECT First_Name +' ' + Last_Name as FLName ,SA_ID FROM PSM_SALES_AGENTS where status ='1' order by SA desc, FLName";
                    MainMDI.fill_Any_CB(cbSA, stSql, false, MainMDI.VIDE);
           
                     break;
                case 'V':
                    stSql = "SELECT First_Name +' ' + Last_Name as FLName ,SA_ID FROM PSM_SALES_AGENTS where  status ='1' and  Sale_MGR=" + in_SA_id + "   order by FLName";
                    MainMDI.fill_Any_CB(cbSA, stSql, false, MainMDI.VIDE);
                    MainMDI.add_CB_itm(cbSA, in_SAName, in_SA_id);
                    break;
                case 'A':
                    MainMDI.add_CB_itm(cbSA, in_SAName, in_SA_id);
                    cbSA.Visible = false; 
       
                    break;
                default:
                    MessageBox.Show("Error,  CMS_USR invalid.....=" + in_CMS_USR.ToString());
                    break;
            }

            cbSA.SelectedIndex = 0; 
        }
        

        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void ed_lvITM_DoubleClick(object sender, EventArgs e)
        {
            if (ed_lvITM.SelectedItems.Count == 1)
            {
                int _ndx = ed_lvITM.SelectedItems[0].Index;
                if (ed_lvITM.Items[_ndx].SubItems[6].Text == "P")
                {

                    Pay_CMS();
                    tcmntPAy.Text = ed_lvITM.Items[_ndx].SubItems[5].Text;
                    lpayid.Text = ed_lvITM.Items[_ndx].SubItems[0].Text;
                    tpay_Amnt.Text = ed_lvITM.Items[_ndx].SubItems[3].Text;
                    dpPaydate.Text = ed_lvITM.Items[_ndx].SubItems[1].Text;
                }

            }
        }


        private void dlg_CMS_Accounts_Load(object sender, EventArgs e)
        {

            grpITM.Height = 40;
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
            fill_cbSales();
            NewItm.Visible = (MainMDI.User.ToLower() == "ede");
            btn_Payer.Visible = (in_CMS_USR == 'S' || in_CMS_USR == 'C');


        }

        private void fill_Balances()
        {


            string stSql = "SELECT * from dbo.PSM_M_SA_Accounts where SA_LID=" + lSA_ID.Text + " order by  [Trs_Date], samvt_LID";
       
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            double dd=0;
            while (Oreadr.Read())
            {

                ListViewItem lv = ed_lvITM.Items.Add(Oreadr["samvt_LID"].ToString());
                  
                    lv.SubItems.Add(MainMDI.frmt_date(Oreadr["Trs_Date"].ToString()));
                    lv.SubItems.Add(Oreadr["trs_Desc"].ToString());
                    lv.SubItems.Add(Oreadr["Trs_Amnt"].ToString());
                    lv.SubItems.Add(Oreadr["Solde"].ToString());
                    lv.SubItems.Add(Oreadr["Cmnt"].ToString());
                    lv.SubItems.Add(Oreadr["Trs"].ToString());
                    lv.BackColor = (Oreadr["Trs"].ToString() == "N" || Oreadr["Trs"].ToString() == "P") ? Color.Lavender  : Color.WhiteSmoke;
                    dd = Tools.Conv_Dbl(Oreadr["Solde"].ToString());
            }
            txRef_sold.Text = dd.ToString();
            OConn.Close();

        }

        private void NewItm_Click(object sender, EventArgs e)
        {
            grpITM.Height =162;
            grpBal.Visible = true;
            grpPay.Visible = false;
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbSA_SelectedIndexChanged(object sender, EventArgs e)
        {
            lSA_ID.Text = MainMDI.get_CBX_value(cbSA , cbSA.SelectedIndex);
            lcbSA.Text = cbSA.Text;
            fill_Balances();
            tpay_Amnt.Clear();
        }

        private void Disp_acct_Click(object sender, EventArgs e)
        {
            fill_Balances();
            grpITM.Height = 49;

        }

        private void Pay_CMS()
        {
            grpITM.Height = 162;
            grpBal.Visible = false;
            grpPay.Visible = true;
            ini_Pay();
        }
        private void  ini_Pay()
        {
            lpayid.Text = "";
            tpay_Amnt.Clear();
            tcmntPAy.Clear();
            dpPaydate.Text = DateTime.Now.ToShortDateString(); 
        }
        private void Payer_Click(object sender, EventArgs e)
        {
            Pay_CMS();

        }



        private void picSavBAL_Click(object sender, EventArgs e)
        {
            if (MainMDI.Find_One_Field("select Solde from PSM_M_SA_Accounts where SA_LID=" +lSA_ID.Text   + " order by samvt_LID desc") == MainMDI.VIDE)
            {
                MainMDI.save_Trs_cmsACCT(lSA_ID.Text , "", "I", "CMS / P0000",Tools.Conv_Dbl (  tBAL_amnt.Text).ToString (), "Init New Balance...");
            }
            else MessageBox.Show("Error,  Balance already exists ......(init Sales/Agencies Accounts)");
            fill_Balances();
        }

        private void picSavPAY_Click(object sender, EventArgs e)
        {
            if (lpayid.Text == "")
            {
                if (Tools.Conv_Dbl(txRef_sold.Text) >= Tools.Conv_Dbl(tpay_Amnt.Text) && Tools.Conv_Dbl(tpay_Amnt.Text) > 0) MainMDI.save_Trs_cmsACCT(lSA_ID.Text, dpPaydate.Value.ToShortDateString(), "P", "PAY / P0000", Tools.Conv_Dbl(tpay_Amnt.Text).ToString(), tcmntPAy.Text);
                else MessageBox.Show("Error Amount:    Cannot pay more than balance OR invalid Amount......!!!");

            }
            else
            {
                MainMDI.Exec_SQL_JFS("Update PSM_M_SA_Accounts set [Trs_Date]=" + MainMDI.SSV_date (dpPaydate.Value.ToShortDateString ()) + ", [Cmnt]='" + tcmntPAy.Text + "' where samvt_LID=" + lpayid.Text, "Update Cmnt paid CMS....");
            }
            ini_Pay();
            fill_Balances();
        }

        private void tBAL_amnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyDBL (e.KeyChar); 
        }

        private void tpay_Amnt_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyDBL(e.KeyChar);
        }

        private void ed_lvITM_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void ed_lvITM_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }
/*
        private void Reset_flds()
        {
            //  txRev.Text = MainMDI.VIDE;
            lusrID.Text = "0";
            lSAlid.Text = "";
            lcbSA.Text = "0"; 
 
            tFname.Clear();
            tLname.Clear();
            TTExt.Clear();
            tt.Clear();
            cbUsrs.Text = MainMDI.VIDE;
            cbSA.Text = MainMDI.VIDE;

        }

        private void dlg_Sales_Agencies_Load(object sender, EventArgs e)
        {
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);

            fill_cbSales ();
            fill_cbusr ();
            fill_Itms();
            chkall.Visible =(MainMDI.User.ToLower ()=="ede" || MainMDI.User.ToLower ()=="hnasrat");
            if (in_SA == 'A')
            {
                lFName.Text = "Name:";
                lLname.Visible = false;
                tLname.Visible = false;
                lfn.Visible = false;
                tFL.Visible = false; 

            }
            else
            {
                lFName.Text = "First Name:";
                lLname.Visible = true;
                tLname.Visible = true;
                lfn.Visible = true;
                tFL.Visible = true;
            }

        }
        private void aff_ref_grpItm()
        {
            if (in_SA == 'A')
            {
                cbUsrs.Visible = false;
       
                grpAG.Visible = true;
                grpITM.Height = 250;
            }
            else
            {
                cbUsrs.Visible = true;
                grpAG.Visible = false;
                grpITM.Height = 138;
            }
            lcbUsrs.Visible = cbUsrs.Visible;
        }

        private void fill_cbusr()   
        {
          MainMDI.fill_Any_CB(cbUsrs ,"SELECT [user] ,[userID]  FROM PSM_users_New",true,MainMDI.VIDE  );

        }


        private void fill_cbSales()
        {

            string stSql = "SELECT First_Name +' ' + Last_Name as FLName ,SA_ID FROM PSM_SALES_AGENTS where SA='S' and status='1' ";
            MainMDI.fill_Any_CB(cbSA , stSql , true,MainMDI.VIDE  );

        }


        private void fill_Itms()
        {
            //        clr_scrn_info();
            //          if (cur_LV_ndx > -1) grpITM.Visible = false;
            //           cur_LV_ndx = -1;

            string stSql = "SELECT * from PSM_SALES_AGENTS where  SA='" + in_SA + "' order by First_Name, Last_Name";
            ed_lvITM.Columns[6].Text = (in_SA == 'S') ? " PGESCOM usr " : "Sale Name";
            SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            while (Oreadr.Read())
            {
                if (chkall.Checked || (!chkall.Checked && Oreadr["status"].ToString() == "1"))
                {
                    ListViewItem lv = ed_lvITM.Items.Add(Oreadr["SA_ID"].ToString());
                    string FL = (in_SA == 'S') ? Oreadr["First_Name"].ToString() + " " + Oreadr["Last_Name"].ToString() : Oreadr["First_Name"].ToString();
                    lv.SubItems.Add(FL);
                    lv.SubItems.Add(Oreadr["Main_TEL"].ToString());
                    lv.SubItems.Add(Oreadr["Extension"].ToString());
                    lv.SubItems.Add(Oreadr["Cell Number"].ToString());
                    lv.SubItems.Add(Oreadr["Email_Address"].ToString());

                    FL = (in_SA == 'S') ? MainMDI.Find_One_Field("SELECT [user] FROM PSM_users_New where [userID]=" + Oreadr["PGC_login"].ToString()) : MainMDI.Find_One_Field("SELECT First_Name + Last_Name as FLName  FROM PSM_SALES_AGENTS where SA='S' and SA_ID=" + Oreadr["Sale_MGR"].ToString());
                    lv.SubItems.Add(FL);
                    lv.SubItems.Add(Oreadr["cmnt"].ToString());
                    lv.SubItems.Add(Oreadr["status"].ToString());
                    lv.BackColor = (Oreadr["status"].ToString() != "1") ? Color.Salmon : Color.WhiteSmoke;
                }



            }
            OConn.Close();

        }

        private void NewItm_Click(object sender, EventArgs e)
        {
            Reset_flds();
            grpITM.Visible = true;
            aff_ref_grpItm();
   
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ed_lvITM_DoubleClick(object sender, EventArgs e)
        {
            edit_ITM(ed_lvITM.SelectedItems[0].Index);  
        }

        private void edit_ITM(int _ndx)
        {
            lSAlid.Text = ed_lvITM.Items[_ndx].SubItems[0].Text;

            string stSql = "SELECT * from PSM_SALES_AGENTS where  SA='" + in_SA + "' and SA_ID=" + lSAlid.Text   ;

            SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                tFname.Text = Oreadr["First_Name"].ToString();
               tt.Text = Oreadr["Main_TEL"].ToString();
               TTExt.Text =Oreadr["Extension"].ToString();
               tCell.Text =Oreadr["Cell Number"].ToString();
               tEmail.Text =Oreadr["Email_Address"].ToString();
               tcmnt.Text =Oreadr["cmnt"].ToString();
               tFL.Text = Oreadr["FL"].ToString();
               if (in_SA == 'A') 
               {
                   tLname.Text = MainMDI.VIDE;
                   cbUsrs.Text = MainMDI.VIDE;
                   cbSA.Text = MainMDI.Find_One_Field("SELECT First_Name + ' ' + Last_Name as FLName  FROM PSM_SALES_AGENTS where status='1'  and SA='S' and SA_ID=" + Oreadr["Sale_MGR"].ToString());
               }
               else 
               {
                   tLname.Text = Oreadr["Last_Name"].ToString();
                   cbUsrs.Text = MainMDI.Find_One_Field("SELECT [user] FROM PSM_users_New where [userID]=" + Oreadr["PGC_login"].ToString());

               }
                

            }
            OConn.Close();

              grpITM.Visible = true;
              aff_ref_grpItm();
        }

        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Sav_Itm_Click(object sender, EventArgs e)
        {

            Save_ITM();
            fill_Itms();
        }
        private void Save_ITM()
        {



            string st = "", stXP = "";
            string LN = "", _MGR="0",login="0";
            if (data_OK())
            {
                if (in_SA == 'A')
                {
                  
                    _MGR = lcbSA.Text;


                }
                else
                {
                    if (tFL.Text == "") tFL.Text = tFname.Text[0].ToString() + tLname.Text[0].ToString();    
                    LN = tLname.Text;
                    login = lusrID.Text; 

                }
                if (lSAlid.Text == "")
                {

                    st = (in_SA == 'A') ? MainMDI.Find_One_Field("select SA_ID from PSM_SALES_AGENTS where First_Name='" + tFL + "'") : MainMDI.Find_One_Field("select SA_ID from PSM_SALES_AGENTS where First_Name='" + tFL + "' and Last_Name='" + tLname.Text + "'");
                    if (st == MainMDI.VIDE)
                    {

                        st = "INSERT INTO [PSM_SALES_AGENTS] ([SA], [First_Name], [Last_Name], [FL], "+
                            " [Company_ID],[Main_TEL], [Extension], " +
                            " [Home_TEL],[Fax Number], [Cell Number], " +
                            " [Pager_Number],[Email_Address], [sfx], " +
                            " [status],[Sale_MGR], [PGC_login], " +
                            " [cmnt]) VALUES ('" + 
                            in_SA.ToString ()  + "', '" +
                            tFname.Text + "', '" +
                            LN + "', '" +
                            tFL.Text + "', " +
                            " 0, '" +
                            tt.Text + "', '" +
                        TTExt.Text + "', '" +
                        MainMDI.VIDE + "', '" +  //home-tel
                          MainMDI.VIDE + "', '" + //fax
                        tCell.Text + "', '" +
                        "0', '" +                 //n'a pas droit a l'ovrg  (pager#)
                        tEmail.Text + "', '" +
                        "', '" +
                        "1', " + // SA Enabled   '0'=disabled
                        _MGR + ", " +  //sales mgr
                        login + ", '" +
                        tcmnt.Text +"')";
                        MainMDI.Exec_SQL_JFS(st, " insert New " + ((in_SA == 'S') ? " SALE " : " Agency " + "..."));


                    }
                    else MessageBox.Show("This " + ((in_SA=='S') ? " SALE " : " Agency " + " already exists ..........."));
                }
                else
                {
                    st = "UPDATE [PSM_SALES_AGENTS] SET " +
                            "   [First_Name]='" + tFname.Text    + 
                            "', [Last_Name]='" +LN + 
                            "', [Main_TEL]='" +tt.Text   + 
                            "', [Extension]='" +TTExt.Text   + 
                            "', [Cell Number]='" +tCell.Text   + 
                            "', [Email_Address]='" +tEmail.Text   + 
                            "', [Sale_MGR]=" +_MGR + 
                            ", [PGC_login]=" +login + 
                            ", [cmnt]='" + tcmnt.Text + "' WHERE SA_ID=" + lSAlid.Text  ;                                                              
                     MainMDI.Exec_SQL_JFS(st, ("Update " + ((in_SA == 'S') ? " SALE " : " Agency " + "...")));

                }
                Reset_flds();
            }

        }
        private bool data_OK()
        {

            return (in_SA == 'A') ? (tFname.Text != MainMDI.VIDE && tFname.Text != "") : (tFname.Text != MainMDI.VIDE && tFname.Text != "" && tLname.Text != MainMDI.VIDE && tLname.Text != ""); 
      //      if (tFL.Text != MainMDI.VIDE && tFL.Text != "" && tLname.Text != MainMDI.VIDE && tLname.Text != "") return true;
      //      return false;

        }

        private void cbUsrs_SelectedIndexChanged(object sender, EventArgs e)
        {
           lusrID.Text =MainMDI.get_CBX_value (cbUsrs, cbUsrs.SelectedIndex); 
        }

        private void del_itm_Click(object sender, EventArgs e)
        {
            string _sta = (ed_lvITM.Items[ed_lvITM.SelectedItems[0].Index].SubItems[8].Text == "1") ? "2" : "1";
            string st = "UPDATE [PSM_SALES_AGENTS] SET [status]='" + _sta +"' WHERE SA_ID=" +ed_lvITM.Items[ed_lvITM.SelectedItems[0].Index].SubItems[0].Text     ;
            MainMDI.Exec_SQL_JFS(st, ("Disable/Enable " + ((in_SA == 'S') ? " SALE " : " Agency " + "...")));
            fill_Itms();
        }

        private void cbSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            lcbSA.Text = MainMDI.get_CBX_value(cbSA, cbSA.SelectedIndex);    
        }

        private void chkall_CheckedChanged(object sender, EventArgs e)
        {
            fill_Itms();
        }

*/




    }
}