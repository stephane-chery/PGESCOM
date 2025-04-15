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
    public partial class dlg_SYSP_Agencies : Form
    {
        string ST_Clip = "";
        string Nemail = "", OLDemail = "", NTel = "", OLDTel = "", AGCode = "";
        public string[,] in_arrLabels = new string[4, 2];
        int ndx = -1;
        public bool Save = false;

        public dlg_SYSP_Agencies()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void fill_Agencies()
        {
            //clr_scrn_info();
            //if (cur_LV_ndx > -1) grpITM.Visible = false;
            //cur_LV_ndx = -1;
            ed_lvITM.Items.Clear();
            if (UCn.Text == "U1" || UCn.Text == "C1")
            {
                string stSql = "SELECT distinct Salesperson,Name , TEL,email FROM  SalSalesperson where SUBSTRING (Salesperson,1,1)='A' and branch='" + UCn.Text + "'      order by Name"; //"'     order by Name";
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {
                    ListViewItem lv = ed_lvITM.Items.Add("");
                    lv.SubItems.Add(Oreadr["Salesperson"].ToString());
                    lv.SubItems.Add(Oreadr["Name"].ToString());
                    if (Oreadr["email"].ToString().Length > 0) lv.SubItems.Add(Oreadr["email"].ToString()); else lv.SubItems.Add(" ");
                    if (Oreadr["TEL"].ToString().Length > 0) lv.SubItems.Add(Oreadr["TEL"].ToString()); else lv.SubItems.Add(" ");

                    lv.SubItems.Add("A");
                    //lv.BackColor = (Oreadr["status"].ToString() != "1") ? Color.Salmon : Color.WhiteSmoke;
                }
                OConn.Close();
            }
        }

        void fill_arrLabels()
        {
            in_arrLabels[0, 0] = "Agency Code"; in_arrLabels[0, 1] = ed_lvITM.Items[ndx].SubItems[1].Text;
            in_arrLabels[1, 0] = "Agency Name:"; in_arrLabels[1, 1] = ed_lvITM.Items[ndx].SubItems[2].Text;
            in_arrLabels[2, 0] = "E-mail:"; in_arrLabels[2, 1] = ed_lvITM.Items[ndx].SubItems[3].Text;
            OLDemail = ed_lvITM.Items[ndx].SubItems[3].Text;
            in_arrLabels[3, 0] = "Phone:"; in_arrLabels[3, 1] = ed_lvITM.Items[ndx].SubItems[4].Text;
            OLDTel = ed_lvITM.Items[ndx].SubItems[4].Text;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            //pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            //this.Refresh();
            //Clipboard.SetText(ST_Clip, TextDataFormat.Text);
            //pictureBox1.BorderStyle = BorderStyle.FixedSingle; this.Refresh();
        }

        void fill_dgInfoSP()
        {
            dg_InfoSP.Rows.Clear();
            for (int i = 0; i < 4; i++) //arr_dgInfo.Length / 2)
            {
                if (in_arrLabels[i, 0] != " ")
                {
                    DataGridViewRow line = new DataGridViewRow();
                    line.CreateCells(dg_InfoSP);
                    line.Cells[0].Value = in_arrLabels[i, 0];
                    line.Cells[1].Value = in_arrLabels[i, 1];
                    dg_InfoSP.Rows.Add(line);

                    //dg_Info.Rows[dg_Info.Rows.Count - 1].ba
                }
                else i = 4;
            }
        }

        private void grpInv_Enter(object sender, EventArgs e)
        {

        }

        private void dlg_addBatt_Load(object sender, EventArgs e)
        {
            UCn.Text = "U1";
            fill_Agencies();
            synALL.Visible = (MainMDI.User.ToLower() == "ede");
            //fill_dgInfoSP();
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
            if (dg_InfoSP.Visible && ndx != -1)
            {
                Nemail = (dg_InfoSP.Rows[2].Cells[1].Value == null) ? " " :dg_InfoSP.Rows[2].Cells[1].Value.ToString();
                NTel = (dg_InfoSP.Rows[3].Cells[1].Value == null) ? " " : dg_InfoSP.Rows[3].Cells[1].Value.ToString();
                AGCode = (dg_InfoSP.Rows[0].Cells[1].Value == null) ? " " : dg_InfoSP.Rows[0].Cells[1].Value.ToString();

                if (OLDemail != Nemail || OLDTel != NTel)
                {
                    MainMDI.Exec_SQL_JFS("Update SalSalesperson set [TEL]='" + NTel + "',  [email]='" + Nemail + "'  where Salesperson='" + AGCode + "'", " Update Agency email-Tel....");
                    fill_Agencies();
                    ed_lvITM.Items[ndx].BackColor = Color.WhiteSmoke;
                    ndx = -1;
                }
                //MessageBox.Show("new email: " + Nemail + "new tel: " + NTel);

                //double uu = MainMDI.Tools.Conv_Dbl(dg_InfoSP.Rows[MainMDI.batt_nbL - 1].Cells[1].Value.ToString());
                //if (uu > 0)
                //{
                    //for (int i = 0; i < MainMDI.batt_nbL; i++) in_arrLabels[i, 1] = (dg_InfoSP.Rows[i].Cells.Count > 1) ? dg_InfoSP.Rows[i].Cells[1].Value.ToString() : " ";
                    //dg_InfoSP.Columns[1].ReadOnly = true;
                    //for (int i = 0; i < MainMDI.batt_nbL; i++) dg_InfoSP.Rows[i].Cells[1].Style.BackColor = Color.AliceBlue;
                    //Save = true;
                //}
                //else MessageBox.Show("Can not save batteries INFO.    since the PRICE is INVALID..........");

                dg_InfoSP.Visible = false;
            }
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void Modifier_AG()
        {
            if (ed_lvITM.SelectedItems.Count == 1)
            {
                ndx = ed_lvITM.SelectedItems[0].Index;
                ed_lvITM.Items[ndx].BackColor = Color.PapayaWhip;
                dg_InfoSP.Visible = true;
                fill_arrLabels();

                fill_dgInfoSP();
                dg_InfoSP.Rows[2].Cells[1].ReadOnly = false;
                dg_InfoSP.Rows[3].Cells[1].ReadOnly = false;
                for (int i = 0; i < 4; i++) dg_InfoSP.Rows[i].Cells[1].Style.BackColor = Color.PapayaWhip;
            }
        }

        private void ed_lvITM_DoubleClick(object sender, EventArgs e)
        {
            Modifier_AG();
        }

        private void Sync_Click(object sender, EventArgs e)
        {
            //Sync_SYSPRO();
            if (MainMDI.User.ToLower() == "ede")
            {
                copy_email_fromOLD_SalesP_TOnew_SalesP();
            }
        }

        void copy_email_fromOLD_SalesP_TOnew_SalesP()
        {
            string stSql = "SELECT  [Branch]   ,[Salesperson]  ,[Name]  ,[email]   FROM SalSalesperson_old where LEN(email)> 0";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string st = "";
            while (Oreadr.Read())
            {
                string stt = "Update SalSalesperson set [email]='" + Oreadr["email"].ToString() + "' where [Branch]='" + Oreadr["Branch"].ToString() + "' AND  [Salesperson]='" + Oreadr["Salesperson"].ToString() +
                    "' AND  [Name]='" + Oreadr["Name"].ToString() + "'";

                MainMDI.Exec_SQL_JFS(stt, "copy email to SalSalesperson");
            }
            MessageBox.Show("emails Update Done...");
        }

        void Sync_SYSPRO()
        {
            string stSql = "SELECT distinct  Salesperson, Name FROM  dbo.SalSalesperson where SUBSTRING (Salesperson,1,1)='A'   and Branch='" + UCn.Text + "'  order by Name ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string st = "";
            while (Oreadr.Read())
            {
                string res = MainMDI.Find_One_Field("select Salesperson from SalSalesperson where Salesperson='" + Oreadr["Salesperson"].ToString() + "'  and branch='" + UCn.Text + "'");
                if (res == MainMDI.VIDE)
                {
                    XSP_NSRT_Agency(UCn.Text, Oreadr["Salesperson"].ToString(), Oreadr["Name"].ToString());
                    st += "Agents: " + UCn.Text + " / " + Oreadr["Salesperson"].ToString() + " / " + Oreadr["Name"].ToString() + "\n";
                }
                else
                {
                    stSql = "update SalSalesperson set [Name]='" + Oreadr["Name"].ToString() + "' where Salesperson='" + Oreadr["Salesperson"].ToString() + "' and branch='" + UCn.Text + "'";
                    MainMDI.Exec_SQL_JFS(stSql, "Update Agency Name........Name");
                }
            }
            MessageBox.Show("SYNC Done of: \n" + st);
        }

        void Sync_ALL_Sales_AG_SYSPRO(string branch)
        {
            //only for Agencies
            //string stSql = "SELECT distinct  Salesperson, Name FROM  dbo.SalSalesperson where SUBSTRING (Salesperson,1,1)='A'   and Branch='" + branch + "'  order by Name ";

            //for all AG and sales
            string stSql = "SELECT distinct  Salesperson, Name FROM  dbo.SalSalesperson where  Branch='" + branch + "'  order by Name ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string st = "";
            while (Oreadr.Read())
            {
                string res = MainMDI.Find_One_Field("select Salesperson from SalSalesperson where Salesperson='" + Oreadr["Salesperson"].ToString() + "'  and branch='" + branch + "'");
                if (res == MainMDI.VIDE)
                {
                    XSP_NSRT_Agency(UCn.Text, Oreadr["Salesperson"].ToString(), Oreadr["Name"].ToString());
                    st += "Agents: " + UCn.Text + " / " + Oreadr["Salesperson"].ToString() + " / " + Oreadr["Name"].ToString() + "\n";
                }
                else
                {
                    stSql = "update SalSalesperson set [Name]='" + Oreadr["Name"].ToString() + "' where Salesperson='" + Oreadr["Salesperson"].ToString() + "' and branch='" + branch + "'";
                    MainMDI.Exec_SQL_JFS(stSql, "Update Agency Name........Name");
                }
            }
            MessageBox.Show("SYNC Done of: \n" + st);
        }

        private void XSP_NSRT_Agency(string Branch, string AG_code, string AG_Name)
        {
            string LID = "";
            string stXP = "";
            try
            {
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = new SqlCommand("NSRT_Agency", OConn);
                Ocmd.CommandType = CommandType.StoredProcedure;

                Ocmd.Parameters.AddWithValue("@Branch", Branch);
                Ocmd.Parameters.AddWithValue("@Salesperson", AG_code);
                Ocmd.Parameters.AddWithValue("@Name", AG_Name);
                SqlDataReader rdr = Ocmd.ExecuteReader();
                while (rdr.Read()) LID = rdr[0].ToString();
                OConn.Close();
                stXP = MainMDI.VIDE;
                MainMDI.Write_JFS("XSP_NSRT_SCD_INFO: " + Ocmd.Parameters.ToString());
            }
            catch (SqlException Oexp)
            {
                stXP = Oexp.Message;
                MessageBox.Show("XSP NSRT_Agency \n" + "Msg= " + stXP);
            }
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
            fill_Agencies();
        }

        private void UCn_SelectedIndexChanged(object sender, EventArgs e)
        {
            fill_Agencies();
        }

        private void synALL_Click(object sender, EventArgs e)
        {
            if (MainMDI.Confirm("want SYNC all Sales / Agencies ????"))
            {
                Sync_ALL_Sales_AG_SYSPRO("U1");
                Sync_ALL_Sales_AG_SYSPRO("C1");
                Sync_ALL_Sales_AG_SYSPRO("E1");
            }
        }
    }
}