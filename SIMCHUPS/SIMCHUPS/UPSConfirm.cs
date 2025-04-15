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
   
    public partial class UPSConfirm : Form
    {

        string stin = "", settingPWD = "1";


        public UPSConfirm()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            UPSMain.Wait();
            lstat.Text = "N";
            this.Hide();
        }

        private void btnX_Click(object sender, EventArgs e)
        {

        }

        private void btnRET_Click(object sender, EventArgs e)
        {

        }

  

    

      
       
        private void btnX_Click_1(object sender, EventArgs e)
        {

        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            UPSMain.Wait();
            lstat.Text = "Q";
            this.Hide();
        }

        private void btnstar_Click(object sender, EventArgs e)
        {

        }

   

        
    }
}
