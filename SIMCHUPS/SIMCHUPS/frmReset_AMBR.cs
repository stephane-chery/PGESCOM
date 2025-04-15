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
    public partial class frmReset_AMBR : Form
    {


        string stin = "",  settingPWD="123213", in_msgWait="";
        public frmReset_AMBR(string x_title,string x_msgWait)
        {
            InitializeComponent();
            btntitle.Text = x_title;
            in_msgWait = x_msgWait;
        }

        private void btnTools_Click(object sender, EventArgs e)
        {

        }

        private void bpoint_Click(object sender, EventArgs e)
        {
           
        }


        private void b1_Click(object sender, EventArgs e)
        {
           
            
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
            // nothing
        }

        private void b4_Click(object sender, EventArgs e)
        {
            
        }

        private void b7_Click(object sender, EventArgs e)
        {
           
        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void b8_Click(object sender, EventArgs e)
        {
           
        }

        private void b5_Click(object sender, EventArgs e)
        {
           
        }

        private void b2_Click(object sender, EventArgs e)
        {
            
        }

        private void button11_Click(object sender, EventArgs e)
        {

        }

        private void b9_Click(object sender, EventArgs e)
        {
          
        }

        private void b6_Click(object sender, EventArgs e)
        {
       
        }

        private void b3_Click(object sender, EventArgs e)
        {
         
        }

        private void bOK_Click(object sender, EventArgs e)
        {
            if ( btnPWD.Text ==settingPWD )
            {
                frmMenusetting myFrm = new frmMenusetting();
                this.Hide();
                myFrm.ShowDialog();
                this.Visible = true;


            }
 
        }

        private void bDEL_Click(object sender, EventArgs e)
        {
           
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void b0_Click(object sender, EventArgs e)
        {
          
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            //Confirm myCFRM = new Confirm();
            //if ( myCFRM.lstat.Text =="Y")
            //{
            //   lstat.Text = "Q";
            //   this.Hide();
            //}

            // nothing
        }

        private void btnYES_Click(object sender, EventArgs e)
        {
            if (in_msgWait != "")
                  {
                btnfloat.Text = "";
                btnEqua.Text = "";


                btnPWD.Visible = false;
                btnNO.Visible = false;
                btnYES.Visible = false;

                btnWait.Text = in_msgWait;
                btnWait.Visible = true;

                this.Refresh();
                System.Threading.Thread.Sleep(1500);

            }
            lstat.Text = "Q";
            this.Hide();
        }

        private void btnNO_Click(object sender, EventArgs e)
        {
            lstat.Text = "N";
            this.Hide();
        }

        private void Confirm_FormClosing(object sender, FormClosingEventArgs e)
        {
             e.Cancel = true;
        }

        private void Confirm_Load(object sender, EventArgs e)
        {
            btnfloat.Text = MainM.OV_value();
            btnEqua.Text = MainM.OA_value();


        }
        
    }
}
