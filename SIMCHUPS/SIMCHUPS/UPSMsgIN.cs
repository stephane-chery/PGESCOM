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
   
    public partial class UPSMsgIN : Form
    {
        bool Shift = false;
        string stin = "", settingPWD = "1";


        public UPSMsgIN(string x_title)
        {
            InitializeComponent();
            btnTitle.Text = x_title;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            UPSMain.Wait();
            lmsg.Text = btnPWD.Text;
                lstat.Text = "YES";
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

        void keyin(string nb)
        {
            
            if (nb != "DEL")
            {
                nb = (Shift) ? nb.ToUpper() : nb;
                if (btnPWD.Text == "Enter Password ?") stin = nb;
                else stin += nb;
            }
            else
            {
                if (btnPWD.Text == "Enter Password ?") stin = "";
                else stin = (stin.Length > 1) ? stin.Substring(0, stin.Length - 1) : "";

            }
            btnPWD.Text = stin;

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnDEL_Click(object sender, EventArgs e)
        {
            keyin("DEL");
        }

        private void btndlr_Click(object sender, EventArgs e)
        {
            keyin("$");
        }

        private void btndiz_Click(object sender, EventArgs e)
        {
            keyin("#");
        }

        private void btnstar_Click(object sender, EventArgs e)
        {
            keyin("*");
        }

        private void bpoint_Click(object sender, EventArgs e)
        {
            keyin(".");
        }

        private void UPSpwd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void btna_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btng_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnm_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btns_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btny_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnb_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnh_Click(object sender, EventArgs e)
        {

            keyin((sender as Button).Text);
        }

        private void btnn_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnt_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnz_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnc_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btni_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }


        private void btno_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnu_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnd_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }


        private void btnj_Click(object sender, EventArgs e)
        {
            
            
            keyin((sender as Button).Text);
        }

        private void btnp_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnv_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnspc_Click(object sender, EventArgs e)
        {
            keyin(" ");
        }

        private void btne_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnk_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnq_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnw_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnf_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnl_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnr_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnXX_Click(object sender, EventArgs e)
        {
            keyin((sender as Button).Text);
        }

        private void btnSHIFT_Click(object sender, EventArgs e)
        {
            Shift = !Shift;
        }

        private void b1_Click(object sender, EventArgs e)
        {

            keyin((sender as Button).Text);
        }
    }
}
