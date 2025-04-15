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
    public partial class dlg_NoteCredit : Form
    {
        private string in_brdLID="";
        private int cur_LV_ndx=-1;
        private char in_cod;
        private EAHLibs.Lib1 Tools=new Lib1 ();
        private string lITMLID = "";


        public dlg_NoteCredit()
        {
            InitializeComponent();
            fill_cbSal_AG("A");

     


        }

        private void fill_cbPrj()
        {
            cbPrj.Items.Clear();

            // string stSql = "SELECT distinct [RID],IRRevID FROM [PSM_R_Rev]";
            string stSql = "SELECT distinct [RID] FROM [PSM_R_Rev] order by RID";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            MainMDI.add_CB_itm(cbPrj,MainMDI.VIDE ,"0");
            while (Oreadr.Read())
            {
                MainMDI.add_CB_itm(cbPrj, Oreadr["RID"].ToString(),"0");
      
            }
            cbPrj.SelectedIndex = 0;
            OConn.Close();
        }


        private void fill_cbRev()
        {
            if (cbPrj.Text != MainMDI.VIDE)
            {

                cbRev.Items.Clear();

                string stSql = "SELECT [RRev_Name], IRRevID FROM [PSM_R_Rev] where RID='" + cbPrj.Text + "'  and shiped<>'D' and shiped<>'C' ";

                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                MainMDI.add_CB_itm(cbRev , MainMDI.VIDE, "0");
                while (Oreadr.Read())
                {
                    MainMDI.add_CB_itm(cbRev, Oreadr["RRev_Name"].ToString(), Oreadr["IRRevID"].ToString());

                }
              //  cbRev.SelectedIndex = 0;
                OConn.Close();
            }
            cbRev.Text = MainMDI.VIDE;  
        }


        private void fill_cbTerri()
        {
            cbTerri.Items.Clear();

            string stSql = "SELECT [Terito_ABR],[Terito_LID]  FROM [PSM_C_ComTERITORY]";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                MainMDI.add_CB_itm(cbTerri, Oreadr["Terito_ABR"].ToString(), Oreadr["Terito_LID"].ToString());

            }
            cbTerri.Text ="No Territory";// .SelectedIndex = 0;
            OConn.Close();
        }
        private bool data_OK()
        {

            if (cbPrj.Text != MainMDI.VIDE && cbRev.Text != MainMDI.VIDE && cbTerri.Text != MainMDI.VIDE)
            {
                if (NCinv.Text != "" && Tools.Conv_Dbl(NCamount.Text) != 0 && NCdate.Text != "") return true;
                else MessageBox.Show (" Invoice # OR Amount OR date is Invalid ");
            }
            else MessageBox.Show ("One or more fields are Invalid...");
            return false;

        }

        private void Save_NC()
        {
      
            

            string st = "", stXP = "";

            if (data_OK())
            {
                if (Tools.Conv_Dbl(NCamount.Text) > 0) NCamount.Text = (Tools.Conv_Dbl(NCamount.Text) * -1).ToString (); 
                if (lNCid.Text == "")
                {

                    st = MainMDI.Find_One_Field("select NC_lid from PSM_R_SBills_NC where AccInv='" + NCinv.Text + "'");
                    if (st == MainMDI.VIDE)
                    {
                        st = "INSERT INTO [PSM_R_SBills_NC] ([ncRID], [AccInv], [Amnt], [InvDate], [IrrevLID],[cmnt], [Territory], [COM]) VALUES ('" + cbPrj.Text + "', '" + NCinv.Text + "', " + NCamount.Text + ", " + MainMDI.SSV_date(NCdate.Text) + ", '" + Lrrevlid.Text + "', '" + txcmnt.Text + "', '" + cbTerri.Text + "', '0')";
                        MainMDI.Exec_SQL_JFS(st, " insert New Credit-note...");
                    

                    }
                    else MessageBox.Show("This [Note de crédit] already exists ...........");
                }
                else
                {
                    st = "UPDATE PSM_R_SBills_NC  SET " +
     " [ncRID]='" + cbPrj.Text + "', [AccInv]='" + NCinv.Text + "', [IrrevLID]=" + Lrrevlid.Text + ", [Amnt]=" + NCamount.Text + ", [InvDate]=" + MainMDI.SSV_date(dpNCdate.Text) + ", [cmnt]='" + txcmnt.Text + "' WHERE NC_lid=" + lNCid.Text ;
                    MainMDI.Exec_SQL_JFS(st, "Update Xchange Rate....");

                }
                Reset_flds();
            }
      
        }

        private void Reset_flds()
        {
         //  txRev.Text = MainMDI.VIDE;
           NCamount.Text = "";
            NCinv.Text = "";
            NCdate.Text = dpNCdate.Value.ToShortDateString();  
            txcmnt.Text = "";
            cbTerri.Text  = MainMDI.VIDE;
            cbRev.Text = MainMDI.VIDE;
            lNCid.Text = "";
            cbPrj.Text = MainMDI.VIDE;
 
        }

        private void fill_Itms()
        {
    //        clr_scrn_info();
  //          if (cur_LV_ndx > -1) grpITM.Visible = false;
 //           cur_LV_ndx = -1;
            string condST=(chk_allCN.Checked ) ? "" : "where COM ='0' ";
            string stSql = (chk_allCN.Checked) ? "SELECT *, PSM_R_Rev.RRev_Name FROM [PSM_R_SBills_NC] inner join PSM_R_Rev on PSM_R_Rev.IRRevID= PSM_R_SBills_NC.IrrevLID   order by AccInv desc  " : "SELECT * FROM [PSM_R_SBills_NC] inner join PSM_R_Rev on PSM_R_Rev.IRRevID= PSM_R_SBills_NC.IrrevLID " + condST + "   order by AccInv desc ";  

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvITM.Items.Add(Oreadr["NC_lid"].ToString());
              //  DateTime dt=
                lv.SubItems.Add(MainMDI.frmt_date(Oreadr["InvDate"].ToString())); //string da = MainMDI.frmt_date(dat);
                lv.SubItems.Add(Oreadr["ncRID"].ToString());
                lv.SubItems.Add(Oreadr["RRev_Name"].ToString());
                lv.SubItems.Add(Oreadr["AccInv"].ToString());
                lv.SubItems.Add(Oreadr["Amnt"].ToString());

                lv.SubItems.Add(Oreadr["Territory"].ToString());
                lv.SubItems.Add(Oreadr["cmnt"].ToString());
                lv.SubItems.Add(Oreadr["IRRevID"].ToString());
     

            }
            OConn.Close();

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





        private void Setng_001_Load(object sender, EventArgs e)
        {

        }

        private void grpITM_Enter(object sender, EventArgs e)
        {

        }

        void refresh_cbxx()
        {
            cbRev.Visible = optRev.Checked;
            cbTerri.Visible = optTerri.Checked; 
        }
        private void optRev_CheckedChanged(object sender, EventArgs e)
        {
            refresh_cbxx();
        }

        private void optTerri_CheckedChanged(object sender, EventArgs e)
        {
            refresh_cbxx();
        }

        private void cbPrj_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_cbRev();
        }

        private void fill_cbSal_AG(string SA)
        {
            string stSql = "select First_Name FROM PSM_SALES_AGENTS where SA='" + SA + "' and status='1'";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                stSql = Oreadr[0].ToString();// no last name for agency.....  // +" " + Oreadr[1].ToString();
                if (SA == "S")
                {

              //      //	cbEmploy.Items.Add( stSql  );  //employee
               //     cbIPmgr.Items.Add(stSql);   // Project Mangr
               //     cbSe.Items.Add(stSql);
              //      cbSi.Items.Add(stSql);
              //      cbSo.Items.Add(stSql);
             //       cbSp.Items.Add(stSql);
             //       cbSS.Items.Add(stSql);
                }
                else
                {
                    cbAD.Items.Add(stSql);
                    cbAE.Items.Add(stSql);
                    cbAP.Items.Add(stSql);
                    cbAI.Items.Add(stSql);
                //    cbAS.Items.Add(stSql);

                }
            }
            OConn.Close();

        }

        private void ref_Terri()
        {

        }
        void Load_terri_Ag()
        {

            if (Lrrevlid.Text != "0")
            {
                string stSql = "  SELECT DISTINCT PSM_R_Rev.RID, PSM_R_Rev.AGency, PSM_C_ComTERITORY.Terito_ABR, PSM_SALES_AGENTS.First_Name AS AG_desti, PSM_SALES_AGENTS_1.First_Name AS AG_Influe, PSM_SALES_AGENTS_2.First_Name AS AG_Eng, PSM_SALES_AGENTS_3.First_Name AS AG_PO " +
                             "  FROM  PSM_R_Rev INNER JOIN PSM_C_ComTERITORY ON PSM_R_Rev.SI = PSM_C_ComTERITORY.Terito_LID INNER JOIN PSM_SALES_AGENTS ON PSM_R_Rev.AD = PSM_SALES_AGENTS.SA_ID INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_1 ON PSM_R_Rev.AI = PSM_SALES_AGENTS_1.SA_ID INNER JOIN " +
                             "  PSM_SALES_AGENTS AS PSM_SALES_AGENTS_2 ON PSM_R_Rev.AE = PSM_SALES_AGENTS_2.SA_ID INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_3 ON PSM_R_Rev.AP = PSM_SALES_AGENTS_3.SA_ID " +
                             "  WHERE     PSM_R_Rev.IRRevID =" + Lrrevlid.Text;
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {

                    cbTerri.Text = Oreadr["Terito_ABR"].ToString();
                    if (Oreadr["AGency"].ToString() == "0") optNOAG.Checked = true;
                    else
                    {
                        optAGOK.Checked = true;
                        cbAD.Text = Oreadr["AG_desti"].ToString();
                        cbAE.Text = Oreadr["AG_Influe"].ToString();
                        cbAI.Text = Oreadr["AG_Eng"].ToString();
                        cbAP.Text = Oreadr["AG_PO"].ToString();
                    }


                }
                OConn.Close();
            }
            else
            {
                cbTerri.Text = MainMDI.VIDE;
                optNOAG.Checked = true;
            }


        }
        private void cbRev_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
            itm = (System.Web.UI.WebControls.ListItem)cbRev.Items[cbRev.SelectedIndex];
            Lrrevlid.Text = itm.Value;
            Load_terri_Ag ();
            
        }

        private void dpNCdate_ValueChanged(object sender, EventArgs e)
        {
            NCdate.Text = dpNCdate.Value.ToShortDateString();  
        }

        private void dlg_NoteCredit_Load(object sender, EventArgs e)
        {
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
            
            fill_cbPrj();
            fill_cbTerri();
            dpNCdate.Text = DateTime.Now.ToShortDateString();  
            fill_Itms();
        }

        private void Sav_Itm_Click(object sender, EventArgs e)
        {
         
            Save_NC();
            fill_Itms();
        }

        private void NewItm_Click(object sender, EventArgs e)
        {
            Reset_flds();
            grpNC.Visible = true;
            Sav_Itm.Enabled = true;
        }

        private void edit_NC(int _ndx)
        {

            cbPrj.Text = ed_lvITM.Items[_ndx].SubItems[2].Text;  //RID
            NCinv.Text = ed_lvITM.Items[_ndx].SubItems[4].Text; //NC#
            dpNCdate.Text = ed_lvITM.Items[_ndx].SubItems[1].Text; //"datenc"
            NCamount.Text = ed_lvITM.Items[_ndx].SubItems[5].Text;// Convert.ToString(Tools.Conv_Dbl(ed_lvITM.Items[_ndx].SubItems[5].Text) * -1.0); //"amnt"
            txcmnt.Text = ed_lvITM.Items[_ndx].SubItems[7].Text ;//"ccmnt"
            cbRev.Text = ed_lvITM.Items[_ndx].SubItems[3].Text; //"Rev"
            lNCid.Text = ed_lvITM.Items[_ndx].SubItems[0].Text; //ncid
            if (Lrrevlid.Text != ed_lvITM.Items[_ndx].SubItems[8].Text) //"v_irevid"
            {
                MessageBox.Show("Error RREVid <> lirrevid ....");
                Sav_Itm.Enabled = false;
            }

            grpNC.Visible = true; 
        }
        private void ed_lvITM_DoubleClick(object sender, EventArgs e)
        {
            edit_NC(ed_lvITM.SelectedItems[0].Index);
        }

        private void cbTerri_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void optNOAG_CheckedChanged(object sender, EventArgs e)
        {
            gbxAgent.Visible = false;
        }

        private void optAGOK_CheckedChanged(object sender, EventArgs e)
        {
            gbxAgent.Visible = true;
        }

        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void del_itm_Click(object sender, EventArgs e)
        {
            if (ed_lvITM.SelectedItems.Count == 1 && !grpNC.Visible)
            {
                if (MainMDI.Confirm("Want delete this Credit note ? "))
                {
                    MainMDI.Exec_SQL_JFS("delete PSM_R_SBills_NC where NC_lid=" + ed_lvITM.Items[ed_lvITM.SelectedItems[0].Index].SubItems[0].Text + " and COM='0'"   , " delete Credit Note....");
                    fill_Itms();
                }
            }
             
       
            
        }

        private void picRefrev_Click(object sender, EventArgs e)
        {

        }




   





    }
}