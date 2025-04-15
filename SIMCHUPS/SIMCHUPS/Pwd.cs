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
    public partial class Pwd : Form
    {


        string stin = "", settingPWD = "1";//settingPWD = "123213";//
        public Pwd()
        {
            InitializeComponent();
        }

        private void btnTools_Click(object sender, EventArgs e)
        {
            lstat.Text = "C";  //cancel
        }

        private void bpoint_Click(object sender, EventArgs e)
        {
            keyin(".");
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
        private void b1_Click(object sender, EventArgs e)
        {
            keyin("1");
            
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void btnfloat_Click(object sender, EventArgs e)
        {

        }

        private void btnEqua_Click(object sender, EventArgs e)
        {

        }

        private void btnRET_Click(object sender, EventArgs e)
        {
            lstat.Text = "C";
            this.Hide();
        }

        private void b4_Click(object sender, EventArgs e)
        {
            keyin("4");
        }

        private void b7_Click(object sender, EventArgs e)
        {
            keyin("7");
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void b8_Click(object sender, EventArgs e)
        {
            keyin("8");
        }

        private void b5_Click(object sender, EventArgs e)
        {
            keyin("5");
        }

        private void b2_Click(object sender, EventArgs e)
        {
            keyin("2");
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void b9_Click(object sender, EventArgs e)
        {
            keyin("9");
        }

        private void b6_Click(object sender, EventArgs e)
        {
            keyin("6");
        }

        private void b3_Click(object sender, EventArgs e)
        {
            keyin("3");
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            //if ( btnPWD.Text ==settingPWD )
            //{
            //    frmMenusetting myFrm = new frmMenusetting();
            //    this.Hide();
            //    myFrm.ShowDialog();
            //    this.Visible = true;


            //}
            if (btnPWD.Text == settingPWD)
            {
                lstat.Text = "YES";
                this.Hide();
            }
 
        }

        private void bDEL_Click(object sender, EventArgs e)
        {
            keyin("DEL");
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void frmSetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
            btnfloat.Text = MainM.OV_value();
            btnEqua.Text = MainM.OA_value();

            btnPWD.Text = "Enter Password ?";

        }

        private void b0_Click(object sender, EventArgs e)
        {
            keyin("0");
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            Confirm myCFRM = new Confirm("Setting");
            myCFRM.ShowDialog();
            if (myCFRM.lstat.Text == "Q")
            {
                lstat.Text = "Q";
               myCFRM.Close();
                this.Hide();
            }
        }
    }
}
