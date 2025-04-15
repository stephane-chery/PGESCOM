using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PGESCOM
{
    public partial class dlg_addBatt : Form
    {
        string ST_Clip = "";
       
        public string[,] in_arrBatt = new string[MainMDI.batt_nbL , 2];
      public bool Save = false;
        public dlg_addBatt()
        {
            InitializeComponent();

            fill_arrBatt();

        }

        public dlg_addBatt (string[] x_arr_batt )
        {
            fill_arrBatt();
            for (int i = 0; i < MainMDI.batt_nbL ; i++) in_arrBatt[i, 1] = x_arr_batt[i];

        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            
        }


        void fill_arrBatt()
        {
            in_arrBatt[0, 0] = "Battery Model:";
            in_arrBatt[1, 0] = "Battery capacity:";
            in_arrBatt[2, 0] = "Battery technology:";
            in_arrBatt[3, 0] = "Battery number of cells:";
            in_arrBatt[4, 0] = "Support type:";
            in_arrBatt[5, 0] = "Dimensions: (HxWxD)";
            in_arrBatt[6, 0] = "# of Supports:";
            in_arrBatt[7, 0] = "Seismic rated:";
            in_arrBatt[8, 0] = "Price:";
            for (int i = 0; i < MainMDI.batt_nbL; i++) in_arrBatt[i, 1] = " "; 
        }


   

        private void pictureBox1_Click(object sender, EventArgs e)
        {
      //      pictureBox1.BorderStyle = BorderStyle.Fixed3D;
     //       this.Refresh();
   //         Clipboard.SetText(ST_Clip, TextDataFormat.Text);
   //         pictureBox1.BorderStyle = BorderStyle.FixedSingle; this.Refresh();

           

        }


        void fill_dgInfoSP()
        {

            dg_InfoSP.Rows.Clear();
            for (int i = 0; i < in_arrBatt.Length / 2; i++)  // arr_dgInfo.Length / 2)
            {
                if (in_arrBatt[i, 0] != " ")
                {
                    DataGridViewRow line = new DataGridViewRow();
                    line.CreateCells(dg_InfoSP);
                    line.Cells[0].Value = in_arrBatt[i, 0];
                    line.Cells[1].Value = in_arrBatt[i, 1];
                    dg_InfoSP.Rows.Add(line);
                  
                    //  dg_Info.Rows[dg_Info.Rows.Count -1 ].ba
                }
                else i = in_arrBatt.Length / 2;
            }

        }



        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grpInv_Enter(object sender, EventArgs e)
        {

        }

        private void dlg_addBatt_Load(object sender, EventArgs e)
        {
            fill_dgInfoSP();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            
        }

        private void Disp_Sales_Click(object sender, EventArgs e)
        {
            dg_InfoSP.Columns[1].ReadOnly = false;
            for (int i = 0; i < MainMDI.batt_nbL; i++) dg_InfoSP.Rows[i].Cells[1].Style.BackColor = Color.PapayaWhip; 
        }

        private void tls_Save_Click(object sender, EventArgs e)
        {

            double uu = MainMDI.Tools.Conv_Dbl(dg_InfoSP.Rows[MainMDI.batt_nbL - 1].Cells[1].Value.ToString());
           if (uu > 0)
           {
               for (int i = 0; i < MainMDI.batt_nbL; i++) in_arrBatt[i, 1] = (dg_InfoSP.Rows[i].Cells.Count > 1) ? dg_InfoSP.Rows[i].Cells[1].Value.ToString() : " ";
               dg_InfoSP.Columns[1].ReadOnly = true;
               for (int i = 0; i < MainMDI.batt_nbL; i++) dg_InfoSP.Rows[i].Cells[1].Style.BackColor = Color.AliceBlue;
               Save = true;
           }
           else MessageBox.Show("Can not save batteries INFO.    since the PRICE is INVALID..........");
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
