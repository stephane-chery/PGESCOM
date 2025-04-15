using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PGESCOM
{
    public partial class CMS_TOTALS : Form
    {
        string ST_Clip = "";
        public CMS_TOTALS(string[,] arr_TOT)
        {
            InitializeComponent();

            fill_LST(arr_TOT);

        }

        private void CMS_TOTALS_Load(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
         
            
        }

        private void fill_LST(string[,] arr)
        {


            ST_Clip = "";
            for (int i=0;i<arr.Length / 2 ;i++)
            {
                ListViewItem lv = ed_lvITM.Items.Add(arr[i, 0]); 
                lv.SubItems.Add(arr[i,1]);
                ST_Clip += arr[i, 0] + "= " + arr[i, 1] + "\r\n";

            }


        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            pictureBox1.BorderStyle = BorderStyle.Fixed3D;
            this.Refresh();
            Clipboard.SetText(ST_Clip, TextDataFormat.Text);
            pictureBox1.BorderStyle = BorderStyle.FixedSingle; this.Refresh();
        }

        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
