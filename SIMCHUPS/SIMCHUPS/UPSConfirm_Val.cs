using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIMCHUPS
{
   
    public partial class UPSConfirm_Val : Form
    {

        string stin = "", settingPWD = "1";
        string in_OV = "", in_OA = "", in_Title = "", in_OldValue = "", in_NewValue = "";
        public UPSConfirm_Val(string x_Title, string x_OldValue, string x_NewValue)
        {
            InitializeComponent();
            //in_OV = x_OV;
            // in_OA = x_OA;
            in_Title = x_Title;
            in_OldValue = x_OldValue;
            in_NewValue = x_NewValue;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            lstat.Text = "N";
            this.Hide();
        }

        private void btnX_Click(object sender, EventArgs e)
        {

        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            UPSMain.Wait();
            lstat.Text = "N";
            this.Hide();
        }

        private void UPSConfirm_Val_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void UPSConfirm_Val_Load(object sender, EventArgs e)
        {
            // btn_ActV.Text = MainM.FloatV;
            btn_title.Text = in_Title;
            if (in_OldValue != "")
            {
                btn_ActV.Text = in_OldValue;
                btnNewV.Text = in_NewValue;
            }
            else
            {
                btnLCV.Text = "";
                btnLOV.Text = "";
                btn_ActV.Text = "";
                btnNewV.Text = "";
            }

        }

        private void btnRET_Click(object sender, EventArgs e)
        {
            //lstat.Text = "C";
            //this.Hide();
        }

  

    

      
       
        private void btnX_Click_1(object sender, EventArgs e)
        {

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            UPSMain.Wait();
            lstat.Text = "Y";
            this.Hide();
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void btnstar_Click(object sender, EventArgs e)
        {

        }

   

        
    }
}
