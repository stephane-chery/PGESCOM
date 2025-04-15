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
    public partial class dlg_SYSP_Agencies_agents : Form
    {
        string ST_Clip = "";
        string Nemail = "", OLDemail = "", NTel = "", OLDTel = "", in_AGCode = "", in_AGNM = "", AGCode = "";
        public string[,] in_arrLabels = new string[4, 2];
        int ndx = -1;
        public bool Save = false;

        public dlg_SYSP_Agencies_agents(string X_AGcode, string x_AGNM)
        {
            InitializeComponent();
            in_AGCode = X_AGcode;
            in_AGNM = x_AGNM;
            fill_Agents();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void fill_Agents()
        {
            //clr_scrn_info();
            //if (cur_LV_ndx > -1) grpITM.Visible = false;
            //cur_LV_ndx = -1;

            string stSql = "SELECT * FROM  SalSalesperson_Agents where Salesperson='" + in_AGCode + "' order by AGentName ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvITM.Items.Add("");
                lv.SubItems.Add(Oreadr["AGCODE"].ToString());
                lv.SubItems.Add(Oreadr["AGentName"].ToString());
                if (Oreadr["email"].ToString().Length > 0) lv.SubItems.Add(Oreadr["email"].ToString()); else lv.SubItems.Add(" ");
                if (Oreadr["TEL"].ToString().Length > 0) lv.SubItems.Add(Oreadr["TEL"].ToString()); else lv.SubItems.Add(" ");
                lv.SubItems.Add("A");
                //lv.BackColor = (Oreadr["status"].ToString() != "1") ? Color.Salmon : Color.WhiteSmoke;
            }
            OConn.Close();
        }

        void fill_arrLabels()
        {
            in_arrLabels[0, 0] = "Agency Name"; in_arrLabels[0, 1] = in_AGNM;
            in_arrLabels[1, 0] = "AGENT Name:"; in_arrLabels[1, 1] = ed_lvITM.Items[ndx].SubItems[2].Text;
            in_arrLabels[2, 0] = "E-mail:"; in_arrLabels[2, 1] = ed_lvITM.Items[ndx].SubItems[3].Text;
            OLDemail = ed_lvITM.Items[ndx].SubItems[3].Text;
            in_arrLabels[3, 0] = "Phone:"; in_arrLabels[3, 1] = ed_lvITM.Items[ndx].SubItems[4].Text;
            OLDTel = ed_lvITM.Items[ndx].SubItems[4].Text;
            tls_Save.Text = "    UPDATE    ";
        }

        void fill_arrLabels_NEWAG()
        {
            in_arrLabels[0, 0] = "Agency Name"; in_arrLabels[0, 1] = in_AGNM;
            in_arrLabels[1, 0] = "AGENT Name:"; in_arrLabels[1, 1] = " ";
            in_arrLabels[2, 0] = "E-mail:"; in_arrLabels[2, 1] = " ";
            in_arrLabels[3, 0] = "Phone:"; in_arrLabels[3, 1] = " ";

            tls_Save.Text = "    SAVE    ";
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
            //fill_Agencies();
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
            if (tls_Save.Text == "    SAVE    ") Save_AG();
            else Update_AGENT();
        }

        void Save_AG()
        {
            string NameAG = (dg_InfoSP.Rows[1].Cells[1].Value == null) ? " " : dg_InfoSP.Rows[1].Cells[1].Value.ToString();
            if (dg_InfoSP.Visible && NameAG != " ")
            {
                string email = (dg_InfoSP.Rows[2].Cells[1].Value == null) ? " " : dg_InfoSP.Rows[2].Cells[1].Value.ToString();
                string Tel = (dg_InfoSP.Rows[3].Cells[1].Value == null) ? " " : dg_InfoSP.Rows[3].Cells[1].Value.ToString();
                MainMDI.Exec_SQL_JFS("INSERT INTO SalSalesperson_Agents ([Salesperson],[AGentName],[TEL],[email]) VALUES ('" + in_AGCode + "', '" + NameAG + "', '" + Tel + "', '" + email + "')", " INSERT Agent email-Tel....");
                fill_Agents();
            }
            dg_InfoSP.Visible = false;
        }

        void Update_AGENT()
        {
            if (ndx != -1)
            {
                string AGLID = ed_lvITM.Items[ndx].SubItems[1].Text;
                string NameAG = (dg_InfoSP.Rows[1].Cells[1].Value == null) ? " " : dg_InfoSP.Rows[1].Cells[1].Value.ToString();
                if (dg_InfoSP.Visible && NameAG != " ")
                {
                    string email = (dg_InfoSP.Rows[2].Cells[1].Value == null) ? " " : dg_InfoSP.Rows[2].Cells[1].Value.ToString();
                    string Tel = (dg_InfoSP.Rows[3].Cells[1].Value == null) ? " " : dg_InfoSP.Rows[3].Cells[1].Value.ToString();
                    MainMDI.Exec_SQL_JFS("UPDATE SalSalesperson_Agents set [AGentName]='" + NameAG + "', [TEL]='" + Tel + "', [email]='" + email + "' where AGCODE='" + AGLID + "'", " Update  Agent email-Tel....");
                    fill_Agents();
                    ndx = -1;
                }
                dg_InfoSP.Visible = false;
            }
        }

        void Delete_AGENT()
        {
            if (ed_lvITM.SelectedItems.Count > -1)
            {
                for (int i = ed_lvITM.SelectedItems.Count - 1; i > -1; i--)
                {
                    int _ndx = ed_lvITM.SelectedItems[i].Index;
                    MainMDI.Exec_SQL_JFS("delete SalSalesperson_Agents where AGCODE='" + ed_lvITM.Items[_ndx].SubItems[1].Text + "'", " delete....  Agent email-Tel....");
                }
                fill_Agents();
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
                dg_InfoSP.Rows[1].Cells[1].ReadOnly = false;
                dg_InfoSP.Rows[2].Cells[1].ReadOnly = false;
                dg_InfoSP.Rows[3].Cells[1].ReadOnly = false;
                for (int i = 0; i < 4; i++) dg_InfoSP.Rows[i].Cells[1].Style.BackColor = Color.PapayaWhip;
            }
        }

        private void ed_lvITM_DoubleClick(object sender, EventArgs e)
        {
            Modifier_AG();
        }

        private void Nsrt_Agent(string Salesperson, string AGentName, string TEL, string email)
        {

        }

        private void newAgent_Click(object sender, EventArgs e)
        {
            fill_arrLabels_NEWAG();
            fill_dgInfoSP();
            dg_InfoSP.Visible = true;
            dg_InfoSP.Rows[1].Cells[1].ReadOnly = false;
            dg_InfoSP.Rows[2].Cells[1].ReadOnly = false;
            dg_InfoSP.Rows[3].Cells[1].ReadOnly = false;
            for (int i = 0; i < 4; i++) dg_InfoSP.Rows[i].Cells[1].Style.BackColor = Color.PapayaWhip;
        }

        private void Del_Agent_Click(object sender, EventArgs e)
        {
            Delete_AGENT();
        }
    }
}