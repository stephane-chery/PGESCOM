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
   
    public partial class UPSRectifier : Form
    {

        string stin = "", settingPWD = "1";
        

        public UPSRectifier()
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
            UPSMain.Wait();
            UPSMain.arr_Controls[0, 1] = UPSMain.FloatV + "|V| ";
            UPSMain.arr_Controls[1, 1] = UPSMain.EqualizeV + "|V|" + ((UPSMain.ChngEQ_FLT) ? "(ON)" : "(OFF)");// MainM.EqualizeV + "|V|(OFF)";
            //string[] V_btnTXT = new string[MainM.btnTXT_LEN];
            //for (int i = 0; i < MainM.btnTXT_LEN; i++) V_btnTXT[i] = "*";
            ////      for (int bb = 0; bb < 7; bb++) V_btnTXT[bb] = arr_Controls[bb, 0] + ":" + arr_Controls[bb, 1];
            //for (int bb = 0; bb < 7; bb++) V_btnTXT[bb] = MainM.arr_Controls[bb, 0] + "|" + MainM.arr_Controls[bb, 1];

            //if (V_btnTXT[0] != " ")
            //{
                UPSControls myfrm = new UPSControls("Controls");
                this.Hide();
                myfrm.ShowDialog();
                if (myfrm.lstat.Text == "Q")
                {
                    lstat.Text = "Q";
                    myfrm.Close();
                    this.Hide();
                }
               else this.Visible = true;
            //}
        }

        private void UPSRectifier_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void btnALRM_Click(object sender, EventArgs e)
        {
            UPSMain.Wait();
            UPSInv_Alarms myAlarms = new UPSInv_Alarms("Rectifier");
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
