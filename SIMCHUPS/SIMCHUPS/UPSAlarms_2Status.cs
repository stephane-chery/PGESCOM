﻿using System;
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
   
    public partial class UPSAlarms_2Status : Form
    {

        string stin = "", settingPWD = "1", in_Title = "------", in_val = "", in_Enter = "", 
            in_etat1 = "", in_etat2 = "",in_Curr_stat="", in_unit = "";



        public UPSAlarms_2Status(string x_Title, string x_etat1,string x_etat2,string x_Curr_stat,string x_Enter)
        {
            InitializeComponent();
            in_Title = x_Title;
            btnTitle.Text = in_Title;
            in_etat1 = x_etat1;
            in_etat2 = x_etat2;
            in_Curr_stat = x_Curr_stat;
            in_Enter = x_Enter;

            //in_val = x_val;
            //in_unit = x_unit;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            UPSMain.Wait();
            string nval = (btnTXT.Text != "Enter Value") ? btnTXT.Text : in_val;
            lNewV.Text = nval;
           UPSConfirm_Val  myfrm = new UPSConfirm_Val(in_Title, in_val, nval);
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
                if (btnTXT.Text == "?") stin = nb;
                else stin += nb;
            }
            else
            {
                if (btnTXT.Text == "?") stin = "";
                else stin = (stin.Length > 1) ? stin.Substring(0, stin.Length - 1) : "";

            }
            btnTXT.Text = stin;

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

  

        void alum_Stat12(bool _stat1, bool _stat2)
        {
          
            btn_ST1_ON.Visible = _stat1;
            btn_ST1_OFF.Visible = !_stat1;

            btn_ST2_ON.Visible = _stat2;
            btn_ST2_OFF.Visible = !_stat2;

            if (btn_ST1_ON.Visible) lnewSTAT.Text = in_etat1;
            if (btn_ST2_ON.Visible) lnewSTAT.Text = in_etat2;
            

        }
        void alum_Stat(bool ONon, bool Onoff, bool OFFon, bool OFFoff)
        {
            //btnon_ON.Visible = ONon;
            //btnon_OFF.Visible = Onoff;
            //btnoff_ON.Visible = OFFon;
            //btnoff_OFF.Visible = OFFoff;

            //if (btnoff_ON.Visible) lnewSTAT.Text = "(OFF)";
            //if (btnon_ON.Visible) lnewSTAT.Text = "(ON)";

        }
        private void btnon_OFF_Click(object sender, EventArgs e)
        {
           // bool stat = btnon_OFF.Visible;
           // alum_Stat(true);
        }

        private void btn_ST1_OFF_Click(object sender, EventArgs e)
        {
            alum_Stat12(true, false);
        }

        private void btn_ST2_OFF_Click(object sender, EventArgs e)
        {
            alum_Stat12(false,true);
        }

        private void btn_ST2_ON_Click(object sender, EventArgs e)
        {
            alum_Stat12(true, false);
        }

        private void btnon_ON_Click(object sender, EventArgs e)
        {
            alum_Stat12(false, true);
        }

        private void UPSAlarms_2Status_Load(object sender, EventArgs e)
        {
            btnTXT.Text = in_Enter;
            lstat1.Text = in_etat1;
            lstat2.Text = in_etat2;
            btn_AStat.Text = in_Curr_stat;
            alum_Stat12((in_Curr_stat == in_etat1), (in_Curr_stat == in_etat2));

            //  alum_Stat(true, false, false, true);

            //btnTXT.Text = (in_etat == "(ON)") ? "Disable " + in_Title : "Enable " + in_Title;
            //btn_AStat.Text = (in_etat == "(ON)") ? "ON" : "OFF";
            //if (in_etat == "")
            //{
            //    btn_ST1_ON.Visible = false;
            //    btn_ST1_OFF.Visible = false;
            //    lstat1.Visible = false;

            //}
        }

        private void btnoff_OFF_Click(object sender, EventArgs e)
        {
            //alum_Stat(false);
        }

        private void btnoff_ON_Click(object sender, EventArgs e)
        {
           // alum_Stat(true);
        }

        private void UPSAlarms_ONOFF_Load(object sender, EventArgs e)
        {
   

          //  btn_AStat.Text = in_val + in_unit; ;
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
