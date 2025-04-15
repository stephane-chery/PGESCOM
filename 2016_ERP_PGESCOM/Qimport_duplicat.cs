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
    public partial class Qimport_duplicat : Form
    {

        int ndxfound = 0;
        string in_QID = "", in_iqID = "";

        public Qimport_duplicat(string x_QID , string x_iqID)
        {
            InitializeComponent();
           in_QID  = x_QID;
           in_iqID = x_iqID;
           LIQID.Text = in_iqID;  
        }

  
/*
        void fill_Quote(string _qNB)
        {
            // string res = MainMDI.Find_One_Field( );
            string stSql = "SELECT  [i_Quoteid],[Quote_ID], Cpny_Name1  FROM [Orig_PSM_FDB].[dbo].[PSM_Q_IGen] inner join dbo.PSM_COMPANY on  PSM_Q_IGen.CPNY_ID=PSM_COMPANY.CPNY_ID   where [Quote_ID]=" + _qNB;


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvQuotes.Items.Clear();

            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvQuotes.Items.Add(Oreadr["i_Quoteid"].ToString());
                lv.SubItems.Add(Oreadr["Quote_ID"].ToString());
                lv.SubItems.Add(Oreadr["Quote_ID"].ToString());
            }

            OConn.Close();
        }
        */

        private void picSeek_Click(object sender, EventArgs e)
        {
       
        }

        private void grpBrd_Enter(object sender, EventArgs e)
        {

        }

        private void btnSeek_Click(object sender, EventArgs e)
        {
            bool FOUND = false;
            if (ndxfound > cbCompanyy.Items.Count) ndxfound = 0;

            for (int i = ndxfound; i < cbCompanyy.Items.Count; i++)
            {
                //if (cbCompany.Items[i].ToString().ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1) 
                //	int ln= (tKey.Text.Length < cbCompany.Items[i].ToString().Length ) ?   tKey.Text.Length :  cbCompany.Items[i].ToString().Length;
                //	if (cbCompany.Items[i].ToString().Substring(0,ln).ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1) 
                //	
                if (cbCompanyy.Items[i].ToString().ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1)
                {
                    cbCompanyy.SelectedIndex = i;
                    ndxfound = i + 1;
                    i = cbCompanyy.Items.Count;
                    cbCompanyy_SelectedIndexChanged(sender, e);// cbOptGrp_SelectedValueChanged(sender,e);
                    //if (ndxfound <cbOptGrp.Items.Count) button1.Text ="Next"; 
                    FOUND = true;
                }
            }
            if (!FOUND)
            {
                ndxfound = 0;
         //       button1.Text = "Search";
                MessageBox.Show("KeyWord not Found !!!!");
            }

        }


        private void btn_find_code_Click(object sender, EventArgs e)
        {
            string CpnyNm = "", lid = "";
            MainMDI.Find_2_Field("select Cpny_Name1,Cpny_ID from PSM_COMPANY where Syspro_Code='" + tKey.Text.ToUpper() + "'", ref CpnyNm, ref lid);

            if (CpnyNm == MainMDI.VIDE)
                MessageBox.Show("NOT FOUND..........!!!!");
            else
            {
                cbCompanyy.Text =  CpnyNm+ " (" + tKey.Text.ToUpper() +")"                ;
            }

        }

        private void fill_cbCompany()
        {
            string stSql = "select distinct Cpny_Name1+ ' (' + Syspro_Code +')' as CPName ,Cpny_ID FROM PSM_Company inner join dbo.PSM_Contacts on Cpny_ID=Company_ID where [Syspro_Code]<>'0' order by CPName";
            // string stSql = "select Cpny_Name1,Cpny_ID FROM PSM_Company order by Cpny_Name1"
            MainMDI.fill_Any_CB(cbCompanyy, stSql , true, "SELECT Customer");
 

        }

        private void Qimport_duplicat_Load(object sender, EventArgs e)
        {
            Qnb.Text = in_QID;
            fill_cbCompany();
            tKey.Focus();
        }

        private void cbCompanyy_SelectedIndexChanged(object sender, EventArgs e)
        {
            lCustLID.Text =MainMDI.get_CBX_value (cbCompanyy , cbCompanyy.SelectedIndex); 
        }


        bool CustomerINlist(string myCustLID)
        {
            for (int i=0;i<mdl_customers.Items.Count;i++)
                 if (myCustLID ==mdl_customers.Items[i].SubItems[0].Text ) return true;
            return false;
        }
        private void pic_MoveR_Click(object sender, EventArgs e)
        {
            if (!CustomerINlist(lCustLID.Text  )) 
            {
               ListViewItem lv = mdl_customers.Items.Add(lCustLID.Text   );
                lv.SubItems.Add(cbCompanyy.Text  );
            }
            else MessageBox.Show ("Customer already exists in List......"); 
        }

        private void btnDuplica_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor; 
            bool done = false;
            for (int i = 0; i < mdl_customers.Items.Count; i++)
            {
                long newIQID = Save_IGEN(in_iqID, mdl_customers.Items[i].SubItems[0].Text);
                if (newIQID != -1)
                {
                    SAVEALL_SOLs(in_iqID, newIQID.ToString());
                    done = true;
                }
                else MessageBox.Show("sorry, duplication errors......... (call admin)...... ");
            }
            this.Cursor = Cursors.Default ; 
            if (done) MessageBox.Show("Duplication Done ........");

        }



        private void picDel_Click(object sender, EventArgs e)
        {
                 if (mdl_customers.SelectedItems.Count > 0) for (int i = mdl_customers.SelectedItems.Count - 1; i > -1; i--) mdl_customers.SelectedItems[i].Remove();
        }

        long Save_IGEN(string iQid, string newCpnyID)
        {

            long IQID = -1;
            string cpnyContactID = MainMDI.Find_One_Field("select Contact_ID FROM PSM_Contacts  where  Company_ID=" + newCpnyID + "  Order by First_Name");
            if (cpnyContactID != MainMDI.VIDE)
            {
                if (MainMDI.Find_One_Field("select i_Quoteid from PSM_Q_IGen where  Quote_ID=" + Qnb.Text + " and CPNY_ID=" + newCpnyID) == MainMDI.VIDE)
                {
                    string contactID = cpnyContactID;
                    using (var conn = new SqlConnection(MainMDI.M_stCon))
                    {
                        string stSql = " INSERT INTO  PSM_Q_IGen  ([Quote_ID]  ,[Employ_ID] ,[ProjectName]  ,[Opndate]  ,[Clsdate]  ,[Cust_Mult] ,[Term_ID]  ,[Via_ID]  ,[IncoTerm_ID] ,[SI] " +
                                                               " ,[SO] ,[SE]  ,[SP]  ,[SS] ,[AD] ,[AI]  ,[AE]  ,[AP]  ,[AS] ,[Lang] ,[QA] ,[PA] ,[SA] ,[IA]  ,[del]  ,[IPmgr] " +
                                                               "  ,[curr]  ,[Cmnt]  ,[AG_YN] ,[SP_AG1] ,[SP_AG1_id]  ,[SP_AG2] ,[SP_AG2_id]  ,[CPNY_ID] ,[Contact_ID] ,[CPmgr] )  " +
                                     " SELECT  [Quote_ID]      ,[Employ_ID]      ,[ProjectName]      ,[Opndate]      ,[Clsdate]      ,[Cust_Mult]      ,[Term_ID]      ,[Via_ID]      ,[IncoTerm_ID]      ,[SI] " +
                                     "         ,[SO]      ,[SE]      ,[SP]      ,[SS]      ,[AD]      ,[AI]      ,[AE]      ,[AP]      ,[AS]      ,[Lang]      ,[QA]      ,[PA]      ,[SA]      ,[IA]      ,[del]      ,[IPmgr] " +
                                     "         ,[curr]      ,[Cmnt]      ,[AG_YN]      ,[SP_AG1]      ,[SP_AG1_id]      ,[SP_AG2]      ,[SP_AG2_id]   , " + newCpnyID + "  , " + cpnyContactID + "  , " + cpnyContactID +
                                     " FROM PSM_Q_IGen where i_Quoteid=" + iQid;
                        using (var InsertCMD = new SqlCommand(stSql, conn))
                        {
                            conn.Open();
                            InsertCMD.ExecuteScalar();
                            // InsertCMD.ExecuteNonQuery(); 

                        }
                    }
                    string newIqid = MainMDI.Find_One_Field("select i_Quoteid from PSM_Q_IGen where  Quote_ID=" + Qnb.Text + " and CPNY_ID=" + newCpnyID);
                    if (newIqid != MainMDI.VIDE) return Convert.ToInt64(newIqid);
                }
            }
            
         return IQID ;
        }

        long Save_IGENBaaaaaddd(string Qid, string newCpnyID)
        {
            long newID;
            long IQID = -1;
            if (MainMDI.Find_One_Field("select i_Quoteid from PSM_Q_IGen where  Quote_ID=" + Qid + " and CPNY_ID=" + newCpnyID) == MainMDI.VIDE)
            {
                string cpnyContactID = MainMDI.Find_One_Field("select Contact_ID FROM PSM_Contacts  where  Company_ID=" + newCpnyID + "  Order by First_Name");
                string contactID = cpnyContactID;

                using (var conn = new SqlConnection(MainMDI.M_stCon))
                {
                    string stSql = " INSERT INTO  PSM_Q_IGen  ([Quote_ID]  ,[Employ_ID] ,[ProjectName]  ,[Opndate]  ,[Clsdate]  ,[Cust_Mult] ,[Term_ID]  ,[Via_ID]  ,[IncoTerm_ID] ,[SI] " +
                                                           " ,[SO] ,[SE]  ,[SP]  ,[SS] ,[AD] ,[AI]  ,[AE]  ,[AP]  ,[AS] ,[Lang] ,[QA] ,[PA] ,[SA] ,[IA]  ,[del]  ,[IPmgr] " +
                                                           "  ,[curr]  ,[Cmnt]  ,[AG_YN] ,[SP_AG1] ,[SP_AG1_id]  ,[SP_AG2] ,[SP_AG2_id]  ,[CPNY_ID] ,[Contact_ID] ,[CPmgr] )  OUTPUT Inserted.i_Quoteid " +

                                 " SELECT  [Quote_ID]      ,[Employ_ID]      ,[ProjectName]      ,[Opndate]      ,[Clsdate]      ,[Cust_Mult]      ,[Term_ID]      ,[Via_ID]      ,[IncoTerm_ID]      ,[SI] " +
                                 "         ,[SO]      ,[SE]      ,[SP]      ,[SS]      ,[AD]      ,[AI]      ,[AE]      ,[AP]      ,[AS]      ,[Lang]      ,[QA]      ,[PA]      ,[SA]      ,[IA]      ,[del]      ,[IPmgr] " +
                                 "         ,[curr]      ,[Cmnt]      ,[AG_YN]      ,[SP_AG1]      ,[SP_AG1_id]      ,[SP_AG2]      ,[SP_AG2_id]   , @newCpnyID , @cpnyContactID  , @cpMgr " +
                                 " FROM PSM_Q_IGen where i_Quoteid=" + Qid + " ;SELECT @@Identity ";//SELECT CAST(scope_identity() AS INT
                    using ( var InsertCMD = new SqlCommand (stSql ,conn))
                    {
                        InsertCMD.Parameters.Add("@newCpnyID", newCpnyID);
                        InsertCMD.Parameters.Add("@cpnyContactID", cpnyContactID);
                        InsertCMD.Parameters.Add("@cpMgr", cpnyContactID);
                        conn.Open();
                     newID =(int) InsertCMD.ExecuteScalar(); 

                    }

                }

            }
            return IQID;
        }



        private void SAVEALL_SOLs(string Old_IQid, string New_IQid)
        {
            string stSql = "SELECT * from PSM_Q_SOL WHERE I_Quoteid=" + Old_IQid ;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            long NewSOLid = -1;
            while (Oreadr.Read())
            {
                using (var conn = new SqlConnection(MainMDI.M_stCon))
                {
                    stSql = " INSERT INTO PSM_Q_SOL ([I_Quoteid],[Sol_Name],[img], [Rnk], [user],[date_Rev],[status_Rev] ) " +
           " VALUES ('" + New_IQid +
           "', '" + Oreadr["Sol_Name"].ToString() +
           "', '" + Oreadr["img"].ToString() +
           "', '" + Oreadr["Rnk"].ToString() +
            "', '" + Oreadr["user"].ToString() +
            "', " +MainMDI.SSV_date(Oreadr["date_Rev"].ToString()) +
           ", '" + Oreadr["status_Rev"].ToString() + "'); SELECT CAST(scope_identity() AS INT)";
                    using (var InsertCMD = new SqlCommand(stSql, conn))
                    {
                        conn.Open();
                        NewSOLid = (int)InsertCMD.ExecuteScalar();

                    }

                }

                if (NewSOLid != -1) SAVEALL_SPEC(Oreadr["Sol_LID"].ToString(), NewSOLid.ToString ());
            }

        }


        private void SAVEALL_SPEC(string OldSlid, string NewSlid)
        {

            string stSql = "select * from PSM_Q_SPCS where Sol_LID=" + OldSlid;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                long NewSPCLid = -1;
                using (var conn = new SqlConnection(MainMDI.M_stCon))
                {
                    stSql = "INSERT INTO PSM_Q_SPCS ([Sol_LID],[SPC_Name], " +
                            " [Rnk] ) VALUES ('" +
                            NewSlid + "', '" +
                            Oreadr["SPC_Name"].ToString().Replace("'", "''") + "', '" +
                            Oreadr["Rnk"].ToString() + "'); SELECT CAST(scope_identity() AS INT)";
                    using (var InsertCMD = new SqlCommand(stSql, conn))
                    {
                        conn.Open();
                        NewSPCLid = (int)InsertCMD.ExecuteScalar();

                    }

                }
                if (NewSPCLid != -1) SAVEALL_ALS(Oreadr["SPC_LID"].ToString(), NewSPCLid.ToString());

            }

        }
       

        private void SAVEALL_ALS(string OldSpcId, string NewSpcId)
        {
            string stSql = "select * from PSM_Q_ALS where SPC_LID=" + OldSpcId;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {

                long NewALSLid = -1;
                using (var conn = new SqlConnection(MainMDI.M_stCon))
                {
                    stSql = "INSERT INTO PSM_Q_ALS ([SPC_LID],[ALS_Name],[Tot], [PxPrice],[AGPrice],[AlsQty]," +
                        " [Rnk] ) VALUES (" +
                        NewSpcId + ", '" +
                        Oreadr["ALS_Name"].ToString().Replace("'", "''") + "', " +
                        Oreadr["Tot"].ToString() + ", " +
                        Oreadr["PxPrice"].ToString() + ", " +
                        Oreadr["AGPrice"].ToString() + ", " +
                        Oreadr["AlsQty"].ToString() + ", " +
                        Oreadr["Rnk"].ToString() + "); SELECT CAST(scope_identity() AS INT)";
                    using (var InsertCMD = new SqlCommand(stSql, conn))
                    {
                        conn.Open();
                        NewALSLid = (int)InsertCMD.ExecuteScalar();

                    }

                }
                if (NewALSLid != -1) SAVEALL_Details(Oreadr["ALS_LID"].ToString(), NewALSLid.ToString());
            }
        }

        private void SAVEALL_Details(string OldAlsId, string NewAlsId)
        {
            string stSql = "select * from PSM_Q_Details where ALS_LID=" + OldAlsId;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {

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
                MainMDI.Exec_SQL_JFS  (stSql,"SAVEALL_Details.." );
               
            }

        }

        private void Qnb_TextChanged(object sender, EventArgs e)
        {

        }


/*
        long execSQL_INSERT_Identity(string stSql)
        {
            using (var con = new SqlConnection(MainMDI.M_stCon  ))
            {
                long ID = -1;
                var cmd = stSql + " ; SELECT CAST(scope_identity() AS BIGINT)";
                using (var insertCommand = new SqlCommand(cmd, con))
                {

                }

            }
        }
 * */

    }
}
