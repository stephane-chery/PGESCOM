using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using EAHLibs;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PGESCOM
{
    public partial class CF_PrintSetup : Form
    {


        public static string[,] arr_CFsu = new string[MainMDI.MAX_Quote_lines, 4];
        private int LstNdx = -1;

        string in_CFlid = "", in_IrrevLID = "", lsu_LID = "";
        public CF_PrintSetup(string x_IrevLID,string x_CFlid)
        {
            InitializeComponent();
            in_CFlid = x_CFlid;
            in_IrrevLID = x_IrevLID;
            fill_Conf(in_IrrevLID ,in_CFlid );
        }


        private void fill_ConfOLD(string _IrrevLID,string _CFlid )
        {

            lvCurConfig.Items.Clear(); 

            string Col1 = "", Col2 = "", Col3 = "";
                        bool newSetup=(MainMDI.Find_One_Field ("SELECT su_LID FROM PSM_R_CFPSetup where su_CFLID=" + _CFlid) == MainMDI.VIDE ) ;

                        string stSql = (newSetup) ? "select e.ConfigNm, f.d_ItemDesc,f.CfDet_LID,f.d_Rnk from PSM_R_CFinfo e inner join PSM_R_CFDetail f on f.d_CFLID=e.CFLID " +
                                                     " where e.CFLID=" + _CFlid + " and e.c_RRevLID=" + _IrrevLID + " order by f.d_Rnk "
                                                   : " SELECT  e.ConfigNm, f.d_ItemDesc, f.CfDet_LID,f.d_Rnk,g.su_LID,g.Bold FROM  PSM_R_CFDetail AS f INNER JOIN " +
                                                     "  PSM_R_CFPSetup AS g ON f.CfDet_LID = g.su_CFdetLID INNER JOIN  PSM_R_CFinfo AS e ON f.d_CFLID = e.CFLID " +
                                                     "  WHERE  (e.CFLID = " + _CFlid + ") AND (e.c_RRevLID = " + _IrrevLID  + ")  ORDER BY g.su_Rnk ";

                        newSU.Enabled = !newSetup;
                        SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
                        OConn.Open ();
                        SqlCommand Ocmd = OConn.CreateCommand();
                        Ocmd.CommandText = stSql ;
                        SqlDataReader Oreadr = Ocmd.ExecuteReader();
                        while (Oreadr.Read())
                        {

                            if (lvCurConfig.Items.Count == 0)
                            {
                                lConfigName.Text = Oreadr["ConfigNm"].ToString();
                                lsu_LID = (newSetup) ? "" : Oreadr["su_LID"].ToString();
                            }

                            ListViewItem lv = lvCurConfig.Items.Add("");
                            if (!newSetup)
                            {
                                lv.SubItems[0].Text = (Oreadr["Bold"].ToString()=="True" ) ? "1" : "0";
                                lv.SubItems[0].Font = (Oreadr["Bold"].ToString() == "True") ? new Font(lvCurConfig.Font, FontStyle.Bold) : new Font(lvCurConfig.Font, FontStyle.Regular);
                            }
                            else lv.SubItems[0].Text = "0";

                            Col2 = Oreadr["CfDet_LID"].ToString();
                            Col1 = Oreadr["d_ItemDesc"].ToString();
                            Col3 = Oreadr["d_Rnk"].ToString();
                            lv.SubItems.Add(Col1);
                            lv.SubItems.Add(Col2);
                            lv.SubItems.Add(Col3);


                        }
			
                        OConn.Close();
                     //   ref_BOLD();
           

        }

        private void fill_Conf(string _IrrevLID, string _CFlid)
        {

            lvCurConfig.Items.Clear();

            string Col1 = "", Col2 = "", Col3 = "";
            string stSql = "select e.ConfigNm, f.d_ItemDesc,f.CfDet_LID,f.d_Rnk ,f.d_Rnk,f.su_Rnk,f.Bold from PSM_R_CFinfo e inner join PSM_R_CFDetail f on f.d_CFLID=e.CFLID " +
                          " where e.CFLID=" + _CFlid + " and e.c_RRevLID=" + _IrrevLID + " order by f.su_Rnk ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {

                if (lvCurConfig.Items.Count == 0)
                {
                    lConfigName.Text = Oreadr["ConfigNm"].ToString();
                   // lsu_LID = Oreadr["su_LID"].ToString();
                }

                ListViewItem lv = lvCurConfig.Items.Add("");
                if (Oreadr["Bold"].ToString() == "True" || Oreadr["Bold"].ToString() == "False")
                {
                    lv.SubItems[0].Text = (Oreadr["Bold"].ToString() == "True") ? "1" : "0";
                    lv.SubItems[0].Font = (Oreadr["Bold"].ToString() == "True") ? new Font(lvCurConfig.Font, FontStyle.Bold) : new Font(lvCurConfig.Font, FontStyle.Regular);
                    
                }
                else lv.SubItems[0].Text = "0";

                Col2 = Oreadr["CfDet_LID"].ToString();
                Col1 = Oreadr["d_ItemDesc"].ToString();
                Col3 = Oreadr["d_Rnk"].ToString();
                lv.SubItems.Add(Col1);
                lv.SubItems.Add(Col2);
                lv.SubItems.Add(Col3);


            }

            OConn.Close();
            //   ref_BOLD();


        }

        private void lvCH_QTY_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CF_PrintSetup_Load(object sender, EventArgs e)
        {
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
        }

        private void toolStripButton12_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lvCurConfig_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int ndx = e.Index;
         //   lvCurConfig.Items[ndx].BackColor = (!lvCurConfig.Items[ndx].Checked) ? Color.LimeGreen : Color.WhiteSmoke;  

            lvCurConfig.Items[ndx].Font = (!lvCurConfig.Items[ndx].Checked) ? new Font(lvCurConfig.Font, FontStyle.Bold) : new Font(lvCurConfig.Font, FontStyle.Regular );   
        }



        private void vider_arr_CFsu()
        {
            for (int i = 0; i < MainMDI.MAX_Quote_lines; i++)
                for (int j = 0; j < 4; j++)
                    arr_CFsu [i, j] = "~";
            LstNdx = 0;
        }

        private void CutCopy(char c)
        {


            vider_arr_CFsu ();
            int i = -1;
            for (i = 0; i < lvCurConfig.SelectedItems.Count; i++)
                for (int j = 0; j < lvCurConfig.Items[i].SubItems.Count; j++)  arr_CFsu [i, j] = lvCurConfig.SelectedItems[i].SubItems[j].Text;
           
            LstNdx = i;
            if (c == 'D') while (lvCurConfig.SelectedItems.Count > 0) lvCurConfig.Items[lvCurConfig.SelectedItems[0].Index].Remove();
            //	aff();
            _past_B.Enabled = true;
            _Past_A.Enabled = true;

        }

        private void Bold()
        {


            for (int ndx = 0; ndx < lvCurConfig.SelectedItems.Count; ndx++)
            {
                int i = lvCurConfig.SelectedItems[ndx].Index;

                lvCurConfig.Items[i].Font = (lvCurConfig.Items[i].SubItems[0].Text == "0") ? new Font(lvCurConfig.Font, FontStyle.Bold) : new Font(lvCurConfig.Font, FontStyle.Regular);
                lvCurConfig.Items[i].SubItems[0].Text = (lvCurConfig.Items[i].SubItems[0].Text == "0") ? "1" : "0";
            }
        }

        private void aff()
        {
            string st = "";
            for (int i = 0; i < 10; i++)
            {
                st += "\n";
                for (int k = 0; k < 4; k++) st += "/" + arr_CFsu[i, k++];

            }

            MessageBox.Show("arr=   " + st);
        }

        private void _past_B_Click(object sender, EventArgs e)
        {
            if (lvCurConfig.SelectedItems.Count > 0) paste(lvCurConfig.SelectedItems[0].Index);
            else paste(0);
        }

        private void _Past_A_Click(object sender, EventArgs e)
        {
            if (lvCurConfig.SelectedItems.Count > 0) paste(lvCurConfig.SelectedItems[0].Index + 1);
            else paste(0);
        }

        private void paste(int InsertNdx)
        {

            int K = (LstNdx == -1) ? -1 : LstNdx - 1;
            for (int i = InsertNdx; i < lvCurConfig.Items.Count; i++)
            {
                K++;
                for (int j = 0; j < lvCurConfig.Items[i].SubItems.Count; j++)
                    arr_CFsu[K, j] = lvCurConfig.Items[i].SubItems[j].Text;

                //	LstNdx++;
            }
            //	aff();
            while (lvCurConfig.Items.Count > InsertNdx) lvCurConfig.Items[lvCurConfig.Items.Count - 1].Remove();

            for (int i = 0; i < MainMDI.MAX_Quote_lines; i++)
            {
                if (arr_CFsu[i, 0] == "~") i = MainMDI.MAX_Quote_lines;
                else
                {
                    ListViewItem lv = lvCurConfig.Items.Add(arr_CFsu[i, 0]);
                
                    int k = 1;
                    //	while ( k<13   && arr_clpB[i,k]!="~" ) 
                    while (k < 4)  lv.SubItems.Add(arr_CFsu[i, k++]);


                }
            }

            _cut.Enabled = true;
            _Past_A.Enabled = false;
            _past_B.Enabled = false;

            //     Tosave = true;
            ref_BOLD();
      

           }
        void ref_BOLD()
        {
            for (int j = 0; j <lvCurConfig.Items.Count   ; j++)
                lvCurConfig.Items[j].Font = (lvCurConfig.Items[j].SubItems[0].Text == "1") ? new Font(lvCurConfig.Font, FontStyle.Bold) : new Font(lvCurConfig.Font, FontStyle.Regular);

        }

        private void tnBold_Click(object sender, EventArgs e)
        {
            Bold();
        }

        private void _Copy_Click(object sender, EventArgs e)
        {
            CutCopy('C');
        }

        private void _cut_Click(object sender, EventArgs e)
        {
            CutCopy('D');
        }

        private void lvCurConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            _cut.Enabled = (lvCurConfig.SelectedItems.Count > 0);
            _Copy.Enabled = (lvCurConfig.SelectedItems.Count > 0);
           // MNocopyTxt.Enabled = (lvQITEMS.SelectedItems.Count > 0);
        }



        private void Save()
        {


            if (MainMDI.ALWD_USR("OR_CF", true))
            {

                if (MainMDI.PermT_user("RS"))
                {

                    if (lvCurConfig.Items.Count > 0)
                    {
                        for (int i = 0; i < lvCurConfig.Items.Count; i++)
                        {
                            string stSql = "UPDATE PSM_R_CFDetail SET " +
                                                " [su_Rnk]='" + i.ToString() +
                                                "', [Bold]='" + lvCurConfig.Items[i].SubItems[0].Text + "' WHERE CfDet_LID=" + lvCurConfig.Items[i].SubItems[2].Text;
                            MainMDI.Exec_SQL_JFS(stSql, " Update new setup for CF=" + lConfigName.Text);

                        }
                      
                    }
                }
            }

        }




        private void SaveOLD()
        {


            if (MainMDI.ALWD_USR("OR_CF", true))
            {
               
                if (MainMDI.PermT_user("RS"))
                {

                    if (lvCurConfig.Items.Count > 0)
                    {
                        if (lsu_LID == "")
                        {
                            for (int i = 0; i < lvCurConfig.Items.Count; i++)
                            {
                                string stSql = "INSERT INTO PSM_R_CFPSetup ([su_CFLID],[su_CFdetLID],[su_Rnk],[Bold]) VALUES ('" +
                                    in_CFlid + "', '" + lvCurConfig.Items[i].SubItems[2].Text + "', '" + i.ToString()  +
                                    "', '" + lvCurConfig.Items[i].SubItems[0].Text + "')";
                                MainMDI.Exec_SQL_JFS(stSql, " Insert new setup for CF=" + lConfigName.Text);

                            }
                        }
                        else   //Save Changes made in RRev Info
                        {
                            for (int i = 0; i < lvCurConfig.Items.Count; i++)
                            {
                                string stSql = "UPDATE PSM_R_CFPSetup SET " + " [su_Rnk]='" + i.ToString() +
                                            "', [Bold]='" + lvCurConfig.Items[i].SubItems[0].Text + "' WHERE su_CFdetLID=" + lvCurConfig.Items[i].SubItems[2].Text;
                                MainMDI.Exec_SQL_JFS(stSql, " Update new setup for CF=" + lConfigName.Text);

                            }

                        }

                    }
                }
            }
   
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {

        }

        private void SaveSU_Click(object sender, EventArgs e)
        {
            Save();
            fill_Conf(in_IrrevLID, in_CFlid);
        }

        private void newSU_Click(object sender, EventArgs e)
        {
            MainMDI.Exec_SQL_JFS("update PSM_R_CFDetail set [su_Rnk]=[d_Rnk], [Bold]= 0 where d_CFLID=" + in_CFlid, " Init new CF setup....CF=" + lConfigName.Text);
          
            fill_Conf(in_IrrevLID, in_CFlid);

        }



 

   











    }
}
