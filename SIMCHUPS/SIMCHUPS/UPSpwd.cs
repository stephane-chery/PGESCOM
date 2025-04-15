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
   
    public partial class UPSpwd : Form
    {

        string stin = "", settingPWD = "1";


        public UPSpwd(string x_title)
        {
            InitializeComponent();
            btnTitle.Text = x_title;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            UPSMain.Wait();
            if (btnPWD.Text == settingPWD)
            {
                lstat.Text = "YES";
                this.Hide();
            }
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
            keyin("3");
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            keyin("2");
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            keyin("1");
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            keyin("4");
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            keyin("5");
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            keyin("6");
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            keyin("7");
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            keyin("8");
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            keyin("9");
        }

        private void btn0_Click(object sender, EventArgs e)
        {
            keyin("0");
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

        private void b1_Click(object sender, EventArgs e)
        {

            keyin("4");
        }
    }
}
