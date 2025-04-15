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
    public partial class Change_Float_EQ : Form
    {


  
        bool in_FLT = false, in_EQ=false;
        string in_Title = "Tools";
        public Change_Float_EQ(bool x_FLT, bool x_EQ)
        {
            InitializeComponent();
            in_EQ  = x_EQ;
            in_FLT = x_FLT;
            

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
            Confirm myCFRM = new Confirm("Tools");
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

        }

        private void btnNO_Click(object sender, EventArgs e)
        {
            lstat.Text = "N";
            this.Hide();
        }

        private void Confirm_FormClosing(object sender, FormClosingEventArgs e)
        {
             
        }

        private void Confirm_value_Load(object sender, EventArgs e)
        {




        }

        private void Change_Float_EQ_Load(object sender, EventArgs e)
        {
            btnfloat.Text = MainM.OV_value();
            btnEqua.Text = MainM.OA_value();

            // btn_ActV.Text = MainM.FloatV;
            btn_title.Text = in_Title;
            lstat.Text = "N";
            btn_ActMod.Text = (in_EQ) ? "Equalize" : "Float";
            alum_Stat(in_FLT,in_EQ);
        }

        private void Change_Float_EQ_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }


        void alum_Stat(bool FLTon, bool EQon)
        {
            btnFLT_ON.Visible = FLTon;
            btnFLT_OFF.Visible = !FLTon;
            btnEQ_ON.Visible = EQon;
            btnEQ_OFF.Visible = !EQon;

          lEQ.Text = (btnEQ_ON.Visible) ? "ON" : "OFF";
          lFLT.Text = (btnFLT_ON.Visible) ? "ON" : "OFF";

      //    btn_ActMod.Text = (in_EQ) ? " Equalize" : "Float";

        }

        private void btnFLT_ON_Click(object sender, EventArgs e)
        {
            alum_Stat(false,true);
        }

        private void btnFLT_OFF_Click(object sender, EventArgs e)
        {
            alum_Stat(true,false);
        }

        private void btnEQ_ON_Click(object sender, EventArgs e)
        {
            alum_Stat(true,false);
        }

        private void btnEQ_OFF_Click(object sender, EventArgs e)
        {
            alum_Stat(false,true);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            string oldmode=(in_EQ) ? "Equalize" : "Float",
                   newMode=(lEQ.Text =="ON") ? "Equalize" : "Float";
            

            Confirm_Mode myfrm = new Confirm_Mode("Tools","Actual Mode:",oldmode,"Next Mode:",newMode);
            this.Hide();
            myfrm.ShowDialog();
            this.Visible = true;
            if (myfrm.lstat.Text == "Q")
            {
                lstat.Text = "Q";
                myfrm.Close();
                this.Hide();
            }
            else
            {
                if (myfrm.lstat.Text == "Y")
                {
                    lstat.Text = "Y";
                    MainM.EqualizeON =(lEQ.Text =="ON");
                    MainM.FloatON = (lFLT.Text =="ON" );
                    if (MainM.FloatON == MainM.EqualizeON) MessageBox.Show("ERROR...........");
                }
                myfrm.Close();
                this.Hide();

            }

            
        }





    }
}
