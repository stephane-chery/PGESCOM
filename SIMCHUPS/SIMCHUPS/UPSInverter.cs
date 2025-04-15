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
   
    public partial class UPSInverter : Form
    {

        string stin = "", settingPWD = "1";
        

        public UPSInverter()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            lstat.Text = "N";
            this.Hide();
          
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            UPSConfirm myCFRM = new UPSConfirm();
            myCFRM.ShowDialog();
            if (myCFRM.lstat.Text == "Q")
            {
                lstat.Text = "Q";
                myCFRM.Close();
                this.Hide();
            }
        }

        private void btnRET_Click(object sender, EventArgs e)
        {
           // UPSMain.Wait();
            lstat.Text = "C";
            this.Hide();
        }

  

    

      

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btncntrls_Click(object sender, EventArgs e)
        {
     
            //}
        }

        private void UPSRectifier_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void btnAlrms_Click(object sender, EventArgs e)
        {
           UPSMain.Wait();
            UPSInv_Alarms myAlarms = new UPSInv_Alarms("Inverter");
            this.Hide();
            myAlarms.ShowDialog();
            if (myAlarms.lstat.Text == "Q")
            {
                myAlarms.Close();
                lstat.Text = "Q";
                this.Hide();
            }
            else this.Visible = true;
        }

        private void btnDigi_Click(object sender, EventArgs e)
        {
            UPSMain.Wait();
            UPSInv_Alarms myAlarms = new UPSInv_Alarms("Inverter Digital Input");
            this.Hide();
            myAlarms.ShowDialog();
            if (myAlarms.lstat.Text == "Q")
            {
                myAlarms.Close();
                lstat.Text = "Q";
                this.Hide();
            }
            else this.Visible = true;
        }

        private void btnstar_Click(object sender, EventArgs e)
        {

        }

   

        
    }
}
