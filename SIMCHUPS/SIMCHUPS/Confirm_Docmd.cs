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
    public partial class Confirm_Docmd : Form
    {



        string in_ACStatus_Title = "", in_CMDTitle = "", in_Title = "";
        public Confirm_Docmd( string x_Title,string x_ACStatus_Title,string x_CMDTitle)
        {
            InitializeComponent();
            in_ACStatus_Title = x_ACStatus_Title;
            in_CMDTitle = x_CMDTitle;
            in_Title =x_Title;
           // in_OldValue = x_OldValue;
           // in_NewValue = x_NewValue;
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
            lstat.Text = "C";
            this.Hide();
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
            Confirm myCFRM = new Confirm("Setting");
            myCFRM.ShowDialog();
            if (myCFRM.lstat.Text == "Q")
            {
                lstat.Text = "Q";
                myCFRM.Close();
                this.Hide();
            }
        }

        private void btnYES_Click(object sender, EventArgs e)
        {
            lstat.Text = "Y";
            this.Hide();
        }

        private void btnNO_Click(object sender, EventArgs e)
        {
            lstat.Text = "N";
            this.Hide();
        }

        private void Confirm_Docmd_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void Confirm_Docmd_Load(object sender, EventArgs e)
        {
            btnfloat.Text = MainM.OV_value();
            btnEqua.Text = MainM.OA_value();

            // btn_ActV.Text = MainM.FloatV;
            btn_title.Text = in_Title;
            btnNV_title.Text = in_ACStatus_Title ;
           btnPWD.Text = in_CMDTitle;

            //btn_oldV.Text = in_OldValue;
            //btnNewV.Text = in_NewValue;
        }

        private void Confirm_value_Load(object sender, EventArgs e)
        {


            
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void btn_ActV_Click(object sender, EventArgs e)
        {

        }
        
    }
}
