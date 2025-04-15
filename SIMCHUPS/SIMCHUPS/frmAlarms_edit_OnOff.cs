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
    public partial class frmAlarms_edit_OnOff : Form
    {
        string in_OA = "?????A", in_Title = "------", in_val = "", in_Enter = "Enter ", in_etat = "", in_Curr_stat="", in_unit="",
            in_etat2="",in_etat1 = "";
        bool in_ONOFF=false;

        string stin = "", settingPWD = "1";//settingPWD = "123213";//


        public frmAlarms_edit_OnOff(string x_Title, string x_etat1, string x_etat2, string x_Curr_stat, string x_Enter)
        {
            InitializeComponent();
            in_Title = x_Title;
        //    btnTitle.Text = in_Title;
            in_etat1 = x_etat1;
            in_etat2 = x_etat2;
            in_Curr_stat = x_Curr_stat;
            in_Enter = x_Enter;
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

            string nval = (btnPWD.Text != "Enter Value") ? btnPWD.Text : in_val;
            lNewV.Text = nval;
                Confirm_value myfrm = new Confirm_value ( in_Title,in_Curr_stat, lnewSTAT.Text);
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
                        myfrm.Close();
                        this.Hide();
                    }

                }
            
 
        }





        private void bDEL_Click(object sender, EventArgs e)
        {
            keyin("DEL");
        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void frmSetting_Load(object sender, EventArgs e)
        {
          //  btnPWD.Text = "Enter Password ?";

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

        private void frmAlarms_edit_OnOff_Load(object sender, EventArgs e)
        {
            btnfloat.Text = MainM.OV_value();
            btnEqua.Text = MainM.OA_value();



            btnTxt.Text = in_Title;
             btnPWD.Text=   in_Enter;
            lstat1.Text = in_etat1;
            lstat2.Text = in_etat2;
            btn_AStat.Text = in_Curr_stat;
            alum_Stat12((in_Curr_stat == in_etat1), (in_Curr_stat == in_etat2));
        }

        private void frmAlarms_edit_OnOff_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        void alum_Stat(bool ONon,bool Onoff,bool OFFon,bool OFFoff)
        {
            btnon_ON.Visible = ONon;
            btnon_OFF.Visible = Onoff;
            btnoff_ON.Visible  = OFFon;
            btnoff_OFF.Visible = OFFoff;

            if (btnoff_ON.Visible) lnewSTAT.Text = "(OFF)";
            if (btnon_ON.Visible) lnewSTAT.Text = "(ON)";

        }
        void alum_Stat(bool ONon, bool OFFon)
        {
            btnon_ON.Visible = ONon;
            btnon_OFF.Visible = !OFFon;
            btnoff_ON.Visible = OFFon;
            btnoff_OFF.Visible = !ONon;

            if (btnoff_ON.Visible) lnewSTAT.Text = "(OFF)";
            if (btnon_ON.Visible) lnewSTAT.Text = "(ON)";

        }
        private void frmAlarms_edit_Val_Load(object sender, EventArgs e)
        {


            //bool tt = (in_etat != "");
            //btnon_OFF.Visible = tt;
            //btnon_ON.Visible = tt;

            //btnoff_ON.Visible = tt;
            //btnoff_OFF.Visible = tt;

            //button3.Visible = tt;
            //button4.Visible = tt; 



        }

        void alum_Stat12(bool _stat1, bool _stat2)
        {

            btnon_ON.Visible = _stat1;
            btnon_OFF.Visible = !_stat1;

            btnoff_ON.Visible = _stat2;
            btnoff_OFF.Visible = !_stat2;

            if (btnon_ON.Visible) lnewSTAT.Text = in_etat1;
            if (btnoff_ON.Visible) lnewSTAT.Text = in_etat2;


        }

        private void btnon_OFF_Click(object sender, EventArgs e)
        {
           // bool stat=btnon_OFF.Visible ;
            alum_Stat12(true, false);
        }

  

        private void btnon_ON_Click(object sender, EventArgs e)
        {
            alum_Stat12(false, true);
        }

        private void btnoff_OFF_Click(object sender, EventArgs e)
        {
            alum_Stat12(false, true);
        }

        private void btnoff_ON_Click(object sender, EventArgs e)
        {
            alum_Stat12(true, false);
        }



    }
}
