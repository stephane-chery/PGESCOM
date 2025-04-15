using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PGESCOM
{
    public partial class dlg_add_P850UI : Form
    {
        string ST_Clip = "";

        public string[,] in_arrUPS = new string[MainMDI.UPS_nbL, 2];
        public bool Save = false;

        public dlg_add_P850UI()
        {
            InitializeComponent();

            fill_arrUPS();
        }

        public dlg_add_P850UI (string[] x_arr_UPS)
        {
            fill_arrUPS();

            for (int i = 0; i < MainMDI.UPS_nbL; i++) in_arrUPS[i, 1] = x_arr_UPS[i];
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        void fill_arrUPS()
        {
            for (int i = 0; i < MainMDI.UPS_nbL; i++) in_arrUPS[i, 1] = " ";

            in_arrUPS[0, 0] = "UPS P850u"; in_arrUPS[0, 1] = "UPS P850U-1-15-120-125";
            in_arrUPS[1, 0] = "Output power";
            in_arrUPS[2, 0] = "Charging power";
            in_arrUPS[3, 0] = "Nominal input voltage";
            in_arrUPS[4, 0] = "Nominal bypass voltage";
            in_arrUPS[5, 0] = "Nominal output voltage";
            in_arrUPS[6, 0] = "Nominal DC bus voltage";
            in_arrUPS[7, 0] = "Grid Input CB (AC)";
            in_arrUPS[8, 0] = "Bypass Input CB (AC)";
            in_arrUPS[9, 0] = "Charger Output CB (DC)";
            in_arrUPS[10, 0] = "Battery CB (DC)";
            in_arrUPS[11, 0] = "Inverter Input CB (DC)";
            in_arrUPS[12, 0] = "Load Output CB (AC)";
            in_arrUPS[13, 0] = "Cabinet Model#";
            in_arrUPS[14, 0] = "Cabinet Dimensions";
            in_arrUPS[15, 0] = "Protection";
            in_arrUPS[16, 0] = "Price";
            in_arrUPS[17, 0] = " "; in_arrUPS[18, 0] = " "; in_arrUPS[19, 0] = " ";
        }

        void fill_arrINV()
        {
            for (int i = 0; i < MainMDI.UPS_nbL; i++) in_arrUPS[i, 1] = " ";
            in_arrUPS[0, 0] = "INVERTER P850i";
            in_arrUPS[1, 0] = "Output power";
            in_arrUPS[2, 0] = "Nominal bypass voltage";
            in_arrUPS[3, 0] = "Nominal output voltage";
            in_arrUPS[4, 0] = "Nominal DC bus voltage";
            in_arrUPS[5, 0] = "Bypass Input CB (AC)";
            in_arrUPS[6, 0] = "Battery CB (DC)";
            in_arrUPS[7, 0] = "Load Output CB (AC)";
            in_arrUPS[8, 0] = "Cabinet Model#";
            in_arrUPS[9, 0] = "Cabinet Dimensions";
            in_arrUPS[10, 0] = "Protection";

            for (int r = 11; r < 20; r++)
            {
                in_arrUPS[r, 0] = " ";
                in_arrUPS[r, 1] = " ";
            }
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
            for (int i = 0; i < in_arrUPS.Length / 2; i++) //arr_dgInfo.Length / 2)
            {
                if (in_arrUPS[i, 0] != " ")
                {
                    DataGridViewRow line = new DataGridViewRow();
                    line.CreateCells(dg_InfoSP);
                    line.Cells[0].Value = in_arrUPS[i, 0];
                    line.Cells[1].Value = in_arrUPS[i, 1];
                    dg_InfoSP.Rows.Add(line);

                    //dg_Info.Rows[dg_Info.Rows.Count - 1].ba
                }
                else i = in_arrUPS.Length / 2;
            }
        }

        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grpInv_Enter(object sender, EventArgs e)
        {

        }

        private void dlg_addUPS_Load(object sender, EventArgs e)
        {
            fill_dgInfoSP();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void Disp_Sales_Click(object sender, EventArgs e)
        {
            dg_InfoSP.Columns[1].ReadOnly = false;
            for (int i = 0; i < dg_InfoSP.Rows.Count; i++) dg_InfoSP.Rows[i].Cells[1].Style.BackColor = Color.PapayaWhip;
        }

        private void tls_Save_Click(object sender, EventArgs e)
        {
            double uu = MainMDI.Tools.Conv_Dbl(dg_InfoSP.Rows[MainMDI.UPS_nbL - 1].Cells[1].Value.ToString());
            if (uu > 0)
            {
                for (int i = 0; i < MainMDI.UPS_nbL; i++) in_arrUPS[i, 1] = (dg_InfoSP.Rows[i].Cells.Count > 1) ? dg_InfoSP.Rows[i].Cells[1].Value.ToString() : " ";
                dg_InfoSP.Columns[1].ReadOnly = true;
                for (int i = 0; i < MainMDI.UPS_nbL; i++) dg_InfoSP.Rows[i].Cells[1].Style.BackColor = Color.AliceBlue;
                Save = true;
            }
            else MessageBox.Show("Can not save This System INFO,  since the PRICE is INVALID..........");
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dlg_add_P850UI_Load(object sender, EventArgs e)
        {
            //dg_InfoSP.AllowUserToResizeColumns = false;
            fill_dgInfoSP();
        }
    }
}
