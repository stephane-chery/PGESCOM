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
    public partial class OR_ToSched_Sel: Form
    {

        string in_scLID="";
        int in_PNL_CAB = 1, in_STD_opt=1;
        public OR_ToSched_Sel(int x_PNL_CAB,int x_STD_opt, string x_sdLID)
        {

           // in_arr_STD_Option  = x_arr_STD ;
            in_PNL_CAB = x_PNL_CAB;
            in_STD_opt = x_STD_opt;
            in_scLID = x_sdLID ;
            InitializeComponent();

        }


        private void Fill_Options()
        {

            string stSql = "SELECT *  FROM [Orig_PSM_FDB].[dbo].[PSM_R_SCD_Aoption]  ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_Options.Items.Clear();

            while (Oreadr.Read())
            {
                ListViewItem lv = ed_Options.Items.Add(" ");
                lv.SubItems.Add(Oreadr["SCHEMAS NO"].ToString());
                lv.SubItems.Add(Oreadr["OPTIONS"].ToString());
                lv.SubItems.Add(Oreadr["DISCRIPTIONS"].ToString());

                string dura = (in_PNL_CAB == 1) ? Oreadr["dura_panel"].ToString() : Oreadr["dura_CAB"].ToString();
                lv.SubItems.Add(dura);

                lv.SubItems.Add(Oreadr["optLID"].ToString());
                lv.SubItems.Add("");
            }

            OConn.Close();

        }

        private void Fill_STD_Chk()
        {

            string stSql = "SELECT *  FROM PSM_R_SCD_Detail_STD  where sc_LID=" + in_scLID  + " and sc_Pnl_Cab=" + in_PNL_CAB;

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
      
            while (Oreadr.Read())
            {
                for (int i = 0; i < mdl_STD.Items.Count; i++)
                {
                    if (mdl_STD.Items[i].SubItems[3].Text == Oreadr["stdLID"].ToString())
                    {
                        mdl_STD.Items[i].Checked = true;
                        mdl_STD.Items[i].SubItems[4].Text = Oreadr["sc_STDlid"].ToString();
                        i = mdl_STD.Items.Count;
                    }
                }


            }

            OConn.Close();

        }

        private void Fill_OPT_Chk()
        {

            string stSql = "SELECT *  FROM PSM_R_SCD_Detail_Options where sc_LID=" + in_scLID  + " and sc_Pnl_Cab=" + in_PNL_CAB;// where sc_Pnl_Cab=" + in_PNL_CAB ;

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                for (int i = 0; i < ed_Options.Items.Count; i++)
                {
                    if (ed_Options.Items[i].SubItems[5].Text == Oreadr["optLID"].ToString())
                    {
                        ed_Options.Items[i].Checked = true;
                        ed_Options.Items[i].SubItems[6].Text = Oreadr["sc_OPTlid"].ToString();  
                        i = ed_Options.Items.Count;
                    }
                }


            }

            OConn.Close();

        }

        void Fill_AWGCPT()
        {

            string stSql = " SELECT     PSM_R_SCD_AWGCPT_STD.stdLID, PSM_R_SCD_AWGCPT_STD.AWGLid, PSM_R_SCD_AWG.AWGName, PSM_R_SCD_AWGCPT_STD.CPTlid, PSM_R_SCD_AWGCPT.CPTName , PSM_R_SCD_AWGCPT_STD.STD_Dura " +
                " FROM         PSM_R_SCD_AWGCPT_STD INNER JOIN   PSM_R_SCD_AWG ON PSM_R_SCD_AWGCPT_STD.AWGLid = PSM_R_SCD_AWG.AWGLid INNER JOIN  PSM_R_SCD_AWGCPT ON PSM_R_SCD_AWGCPT_STD.CPTlid = PSM_R_SCD_AWGCPT.CPTlid " +
                "  where  PSM_R_SCD_AWGCPT_STD.PNL_CAB=" + in_PNL_CAB +
                " Order by PSM_R_SCD_AWGCPT_STD.AWGLid,PSM_R_SCD_AWGCPT_STD.CPTlid ";

                  SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                   OConn.Open();
                   SqlCommand Ocmd = OConn.CreateCommand();
                   Ocmd.CommandText = stSql;
                   SqlDataReader Oreadr = Ocmd.ExecuteReader();
                   mdl_STD.Items.Clear(); 
                   while (Oreadr.Read())
                   {
                       ListViewItem lv = mdl_STD.Items.Add(" ");
                       lv.SubItems.Add(Oreadr["AWGName"].ToString() + " / " + Oreadr["CPTName"].ToString());
                       lv.SubItems.Add(Oreadr["STD_Dura"].ToString());
                       lv.SubItems.Add(Oreadr["stdLID"].ToString());
                       lv.SubItems.Add("");
   
                   }
                  OConn.Close();
             
        }





        private void picSeek_Click(object sender, EventArgs e)
        {

        }

        private void dlg_Vaca_EvSELECT_Load(object sender, EventArgs e)
        {


            mdl_STD.Modifiable = false;
            Fill_AWGCPT();
            Fill_Options();
            if (in_STD_opt == 1)
            {
                grpSTD.BringToFront();
                Fill_STD_Chk();
            }
            else
            {
                ed_Options.BringToFront();
                Fill_OPT_Chk();
            }
        

        }

        private void pic_MoveR_Click(object sender, EventArgs e)
        {

        }

        void Fill_SELECTION_array()
        {

        }


 






    
        private void btnOK_Click(object sender, EventArgs e)
        {

            if (in_STD_opt == 1) Save_STD();
            else Save_OPTION();

            this.Hide();
        }


        void Save_STD()
        {
            string EM = "2";

            string stSql = "";
            for (int i = 0, j = 0; i < mdl_STD.Items.Count; i++)
                if (mdl_STD.Items[i].Checked)
                {
                    if (mdl_STD.Items[i].SubItems[4].Text == "")
                    {
                        stSql = " INSERT INTO PSM_R_SCD_Detail_STD ([sc_LID],[sc_EM],[sc_Pnl_Cab], [stdLID], [dura] ) " +
                      " VALUES (" + in_scLID +
                      ", " + EM +
                      ", " + in_PNL_CAB.ToString() +
                        ", " + mdl_STD.Items[i].SubItems[3].Text +
                        ", " + mdl_STD.Items[i].SubItems[2].Text + ")";
                        MainMDI.Exec_SQL_JFS(stSql, "Insert std/sched");
                    }
                }
                else
                {
                    if (mdl_STD.Items[i].SubItems[4].Text != "")
                    {
                        stSql = " delete PSM_R_SCD_Detail_STD  where [sc_STDlid]=" + mdl_STD.Items[i].SubItems[4].Text;
                        MainMDI.Exec_SQL_JFS(stSql, "delete std/sched");
                    }

                }



        }

        void Save_OPTION()
        {
            string EM = "2";

            string stSql = "";
            for (int i = 0, j = 0; i < ed_Options.Items.Count; i++)
                if (ed_Options.Items[i].Checked)
                {
                    if (ed_Options.Items[i].SubItems[6].Text == "")
                    {
                        stSql = " INSERT INTO PSM_R_SCD_Detail_Options ([sc_LID],[sc_EM],[sc_Pnl_Cab], [optLID], [dura] ) " +
                      " VALUES (" + in_scLID +
                      ", " + EM +
                      ", " + in_PNL_CAB.ToString() +
                        ", " + ed_Options.Items[i].SubItems[5].Text +
                        ", " + ed_Options.Items[i].SubItems[4].Text + ")";
                        MainMDI.Exec_SQL_JFS(stSql, "Insert option/sched");
                    }
                }
                else
                {
                    if (ed_Options.Items[i].SubItems[6].Text != "")
                    {
                        stSql = " delete PSM_R_SCD_Detail_Options  where [sc_OPTlid]=" + ed_Options.Items[i].SubItems[6].Text;
                        MainMDI.Exec_SQL_JFS(stSql, "delete option/sched");
                    }

                }



        }



        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnCancel_Click_1(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void grpSTD_Enter(object sender, EventArgs e)
        {

        }
    }
} 
