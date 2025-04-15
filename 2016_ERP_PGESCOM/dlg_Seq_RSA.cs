using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PGESCOM
{
    public partial class dlg_Seq_RSA : Form
    {
        string ST_Clip = "",in_RSA="",in_LID="0";
        string Nemail ="",OLDemail ="", NTel = "", OLDTel = "", AGCode="";
        public string[,] in_arrLabels = new string[4 , 2];
        int ndx = -1;
      public bool Save = false;
        public dlg_Seq_RSA(string x_RSA, string x_LID)
        {
            InitializeComponent();
            in_RSA = x_RSA;
            in_LID = x_LID;
          

        }



        private void button1_Click(object sender, EventArgs e)
        {
         
            
        }



        private void fill_ed_lvITM()
        {
           
            ed_lvITM.Items.Clear();
            string stSql = "";
            switch (in_RSA )
            {

                case "R":
                   stSql ="SELECT  [Sol_LID],[Sol_Name],[Rnk]  FROM [Orig_PSM_FDB].[dbo].[PSM_Q_SOL] where [I_Quoteid]=" + in_LID + " Order by [Rnk] ";
                   ed_lvITM.Columns[2].Text = "Revision Name";
                    break;
                case "S":
                    stSql = "SELECT  [SPC_LID]  ,[SPC_Name] ,[Rnk]   FROM [Orig_PSM_FDB].[dbo].[PSM_Q_SPCS] where [Sol_LID]=" + in_LID + " Order by [Rnk] ";;
                    ed_lvITM.Columns[2].Text = "Alternative Name";
                    break;
                case "A":
                    stSql = "SELECT  [ALS_LID] ,[ALS_Name],[Rnk]   FROM [Orig_PSM_FDB].[dbo].[PSM_Q_ALS] where [SPC_LID]=" + in_LID + " Order by [Rnk] ";;
                    ed_lvITM.Columns[2].Text = "System Name";
                    break;
                default:
                    stSql = "*";
                    break;

            }
            if (stSql != "*")
            {
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {

                    ListViewItem lv = ed_lvITM.Items.Add(Oreadr[0].ToString());
                    lv.SubItems.Add(Oreadr[2].ToString());
                    lv.SubItems.Add(Oreadr[1].ToString());

                }
                OConn.Close();
            }

        }
 


   




        //void fill_dgInfoSP()
        //{

        //    dg_InfoSP.Rows.Clear();
        //    for (int i = 0; i < 4; i++)  // arr_dgInfo.Length / 2)
        //    {
        //        if (in_arrLabels[i, 0] != " ")
        //        {
        //            DataGridViewRow line = new DataGridViewRow();
        //            line.CreateCells(dg_InfoSP);
        //            line.Cells[0].Value = in_arrLabels[i, 0];
        //            line.Cells[1].Value = in_arrLabels[i, 1];
        //            dg_InfoSP.Rows.Add(line);
                  
        //            //  dg_Info.Rows[dg_Info.Rows.Count -1 ].ba
        //        }
        //        else i = 4;
        //    }

        //}

        private void grpInv_Enter(object sender, EventArgs e)
        {

        }

        private void dlg_addBatt_Load(object sender, EventArgs e)
        {

       
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void Disp_Sales_Click(object sender, EventArgs e)
        {

        }

        private void tls_Save_Click(object sender, EventArgs e)
        {
            Save_AG();
        }
        
        
        void Save_AG()
        {
            lSave.Text = "N";
            for (int i=0;i<ed_lvITM.Items.Count ;i++ )
            {
                string stSql = "*";
                switch (in_RSA)
                {

                    case "R":
                        stSql = "update PSM_Q_SOL set [Rnk]=" + ed_lvITM.Items[i].SubItems[1].Text + " where [Sol_LID]=" + ed_lvITM.Items[i].SubItems[0].Text;
                       
                        break;
                    case "S":
                        //stSql = "SELECT    ,[SPC_Name] ,[Rnk]   FROM [Orig_PSM_FDB].[dbo].[] where [Sol_LID]=" + in_LID;
                        stSql = "update PSM_Q_SPCS set [Rnk]=" + ed_lvITM.Items[i].SubItems[1].Text + " where [SPC_LID]=" + ed_lvITM.Items[i].SubItems[0].Text;
                        break;
                    case "A":
                        //stSql = "SELECT   ,[ALS_Name],[Rnk]   FROM [Orig_PSM_FDB].[dbo].[PSM_Q_ALS] where [SPC_LID]=" + in_LID;
                        stSql = "update PSM_Q_ALS set [Rnk]=" + ed_lvITM.Items[i].SubItems[1].Text + " where [ALS_LID]=" + ed_lvITM.Items[i].SubItems[0].Text;
                        break;
                    default:
                        stSql = "*";
                        break;

                }
                if (stSql != "*")
                {
                   // MainMDI.Exec_SQL_JFS("Update SalSalesperson set [TEL]='" + NTel + "',  [email]='" + Nemail + "'  where Salesperson='" + AGCode + "'", " Update Agency email-Tel....");
                    MainMDI.Exec_SQL_JFS(stSql, "Organize RSA.....");
                    lSave.Text = "Y";
                //    ed_lvITM.Items[ndx].BackColor = Color.WhiteSmoke;
                    ndx = -1;

                }

                //    MessageBox.Show("new email: " + Nemail + "new tel: " + NTel);

                // double uu = MainMDI.Tools.Conv_Dbl(dg_InfoSP.Rows[MainMDI.batt_nbL - 1].Cells[1].Value.ToString());
                //if (uu > 0)
                //{
                //    for (int i = 0; i < MainMDI.batt_nbL; i++) in_arrLabels[i, 1] = (dg_InfoSP.Rows[i].Cells.Count > 1) ? dg_InfoSP.Rows[i].Cells[1].Value.ToString() : " ";
                //    dg_InfoSP.Columns[1].ReadOnly = true;
                //    for (int i = 0; i < MainMDI.batt_nbL; i++) dg_InfoSP.Rows[i].Cells[1].Style.BackColor = Color.AliceBlue;
                //    Save = true;
                //}
                //else MessageBox.Show("Can not save batteries INFO.    since the PRICE is INVALID..........");

              //  dg_InfoSP.Visible = false;
            }
            fill_ed_lvITM();

            MessageBox.Show("Saving Done..............");
        }
        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        //void Modifier_AG()
        //{

        //    if (ed_lvITM.SelectedItems.Count == 1)
        //    {

        //        ndx = ed_lvITM.SelectedItems[0].Index;
        //        ed_lvITM.Items[ndx].BackColor = Color.PapayaWhip;
        //        dg_InfoSP.Visible = true;
        //        fill_arrLabels();

        //        fill_dgInfoSP();
        //        dg_InfoSP.Rows[2].Cells[1].ReadOnly = false;
        //        dg_InfoSP.Rows[3].Cells[1].ReadOnly = false;
        //        for (int i = 0; i < 4; i++) dg_InfoSP.Rows[i].Cells[1].Style.BackColor = Color.PapayaWhip;
        //    }
        //}
        private void ed_lvITM_DoubleClick(object sender, EventArgs e)
        {
            //Modifier_AG();
        }

        private void Sync_Click(object sender, EventArgs e)
        {
            //Sync_SYSPRO();
        }


      
      

              private void tls_new_Click(object sender, EventArgs e)
              {
                  modif_AGents();
              }

        void modif_AGents()
              {


                  if (ed_lvITM.SelectedItems.Count == 1)
                  {
                      ndx = ed_lvITM.SelectedItems[0].Index;
                      dlg_SYSP_Agencies_agents frm = new dlg_SYSP_Agencies_agents(ed_lvITM.Items[ndx].SubItems[1].Text, ed_lvITM.Items[ndx].SubItems[2].Text);
                   
                      frm.ShowDialog();
                     

                  }
              }

        private void CUn_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void CUn_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void UCn_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void UCn_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }



        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void dlg_Seq_RSA_Load(object sender, EventArgs e)
        {
            fill_ed_lvITM();
        }

        private void btnDown_Click(object sender, EventArgs e)
        {
            GoDown();
        }

        private void btnUP_Click(object sender, EventArgs e)
        {
            GoUP();
        }
        

        void swapLines(int x,int x0)
        {

            string tmp_lid = ed_lvITM.Items[x].SubItems[0].Text;
            string tmp_rnk = ed_lvITM.Items[x].SubItems[1].Text;
            string tmp_nm = ed_lvITM.Items[x].SubItems[2].Text;

            ed_lvITM.Items[x].SubItems[0].Text = ed_lvITM.Items[x0].SubItems[0].Text;
            ed_lvITM.Items[x].SubItems[1].Text = x.ToString ();// ed_lvITM.Items[x0].SubItems[1].Text;
            ed_lvITM.Items[x].SubItems[2].Text = ed_lvITM.Items[x0].SubItems[2].Text;

            ed_lvITM.Items[x0].SubItems[0].Text=  tmp_lid ;
            ed_lvITM.Items[x0].SubItems[1].Text = x0.ToString(); //tmp_rnk;
            ed_lvITM.Items[x0].SubItems[2].Text=  tmp_nm ;

            ed_lvITM.Items[x].Selected =false;
            ed_lvITM.Items[x0].Selected = true;

        }
        void GoUP()
        {
            
            if (ed_lvITM.SelectedItems.Count ==1 )
            {
                ndx = ed_lvITM.SelectedItems[0].Index;
                if (ndx>0)
                {
                    swapLines(ndx, ndx - 1);

                }

            }


        }

        void GoDown()
        {
            if (ed_lvITM.SelectedItems.Count == 1)
            {
                ndx = ed_lvITM.SelectedItems[0].Index;
                if (ndx < ed_lvITM.Items.Count-1 )
                {
                    swapLines(ndx, ndx + 1);

                }

            }




        }

        private void dlg_Seq_RSA_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }
    }
}
