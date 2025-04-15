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
    public partial class frmAlarms_values : Form
    {
        string  in_OA = "?????A", in_Title = "------";
        int in_TA12 =1, cntr = 1, curr_Selbtn = 0, curr_TXTndx = -1, OLD_Scroll = -1, NEW_Scroll = -1, Ichng=0,curr_XPTR=0,in_Alrms_II=-1,
            txtPTRb1=-1,txtPTRb2=-1,txtPTRb3=-1,txtPTRb4=-1,txtPTRb5=-1,Curr_curr=0;

        public string res_Updt = "????";
        string[] in_btnTXT = new string[MainM.btnTXT_LEN];
        bool updated = false;
      

 
        public frmAlarms_values(int x_TA12,string x_OA,string x_Title ,string[] x_btntxt,int x_Alrms_II)
        {
            InitializeComponent();
            in_TA12 = x_TA12; ;
            //in_OA= x_OA;
            in_Title = x_Title;
            in_btnTXT = x_btntxt;
            in_Alrms_II = x_Alrms_II;
        }

        private void frmMenusetting_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void btnRET_Click(object sender, EventArgs e)
        {
            lstat.Text = "C";  //cancel
            this.Hide();
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
          //  lstat.Text = "Q";  //cancel
         //   this.Hide();
        }

        void deco_Prop_TVUS(string stPro,out string Txt,out string val, out string Unit,out string stat)
        {
            Txt=""; val=""; Unit=""; stat="";
            string res = "", st = stPro;// "Battery High Volt"," |3|V|(ON)",
            int ipos = -1;
            for (int i = 0; i < 4; i++)
            {
                string msg = "";
                if (i < 3)
                {
                    ipos = st.IndexOf("|");
                    if (ipos > -1)
                    {
                        msg = st.Substring(0, ipos);
                        st = st.Substring(ipos + 1);

                    }
                    else res = "????";
                }
                else msg = st;
                if (res == "????")
                {
                    i = 4; res = "";
                }
                else
                {
                    if (msg == " ") msg = "";
                    switch (i)
                    {
                          
                        case 0:
                            Txt = msg ;//+":  ";
                            break;
                        case 1:
                            val = msg;
                            break;
                        case 2:
                            Unit = msg;
                            break;
                        case 3:
                            stat = (msg == "") ? "" : " "+ msg;
                            break;
                    }
                }
                //if (msg != " " && i < 4) res += msg;

            }


          
        }

        void fill_Btns( int _ndx)
        {
            string Txt, val, Unit,stat;
            deco_Prop_TVUS(in_btnTXT[_ndx],out Txt,out val,out Unit,out stat);
            btn1.Text = Txt + ": " + val + Unit + stat;
            txtPTRb1 = _ndx++;

            deco_Prop_TVUS(in_btnTXT[_ndx], out Txt, out val, out Unit, out stat);
            btn2.Text = Txt + ": " + val + Unit + stat;
            txtPTRb2 = _ndx++;

            deco_Prop_TVUS(in_btnTXT[_ndx], out Txt, out val, out Unit, out stat);
            btn3.Text = Txt + ": " + val + Unit + stat;
            txtPTRb3 = _ndx++;

            deco_Prop_TVUS(in_btnTXT[_ndx], out Txt, out val, out Unit, out stat);
            btn4.Text = Txt + ": " + val + Unit + stat;
            txtPTRb4 = _ndx++;

            deco_Prop_TVUS(in_btnTXT[_ndx], out Txt, out val, out Unit, out stat);
            btn5.Text = Txt + ": " + val + Unit + stat;
            txtPTRb5 = _ndx;
            
            curr_TXTndx = _ndx;
           // Curr_curr = _ndx;
            curr_Selbtn =1;
            Select_btn(1);
            ltxt.Text = curr_TXTndx.ToString();
            lbtn.Text = curr_Selbtn.ToString();

        }

        void Update_Btns(int _btndx,string propTXT)
        {
            string Txt, val, Unit, stat;
            deco_Prop_TVUS(propTXT, out Txt, out val, out Unit, out stat);

            switch (_btndx )
            {

                case 1:
                    btn1.Text = Txt + ": " + val + Unit + stat;
                    break;
                case 2:
                    btn2.Text = Txt + ": " + val + Unit + stat;
                    break;
                case 3:
                    btn3.Text = Txt + ": " + val + Unit + stat;
                    break;
                case 4:
                    btn4.Text = Txt + ": " + val + Unit + stat;
                    break;
                case 5:
                    btn5.Text = Txt + ": " + val + Unit + stat;
                    break;

            }
        }

       

       
//==============================
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

            if (e.OldValue == e.NewValue)
            {
                if (curr_Selbtn == -1)
                {
                    curr_Selbtn = 1;
                    Select_btn(1);
                }
            }
            else
            {
                if (e.OldValue > e.NewValue)
                {
                    selectBTN_UP();

                }
                else
                {
                    selectBTN_DOWN();
                }

            }

            ltxt.Text = curr_TXTndx.ToString();
            lbtn.Text = curr_Selbtn.ToString();
        }

        void load_newTXT()
        {
            string Txt, val, Unit, stat;

            if (curr_Selbtn == 1)
            {
                if (curr_TXTndx > 0)
                {
                    btn5.Text = btn4.Text;
                    txtPTRb5 = txtPTRb4;

                    btn4.Text = btn3.Text;
                    txtPTRb4 = txtPTRb3;

                    btn3.Text = btn2.Text;
                    txtPTRb3 = txtPTRb2;

                    btn2.Text = btn1.Text;
                    txtPTRb2 = txtPTRb1;

                    curr_TXTndx--;

                    deco_Prop_TVUS(in_btnTXT[curr_TXTndx], out Txt, out val, out Unit, out stat);
                    btn1.Text = Txt + ": " + val + Unit + stat;

                   

                    txtPTRb1 = curr_TXTndx;
                    Curr_curr = curr_TXTndx;

                    //Select_btn(1);
                }
             //   Select_btn(1);
            }
            else
            {
                //   if (btnTXT[curr_TXTndx + 1] != "*")
                if (updated)
                {
                    curr_TXTndx++;
                    updated = false;
                }
                if (in_btnTXT[curr_TXTndx] != "*")
                {
                    btn1.Text = btn2.Text;
                    txtPTRb1 = txtPTRb2;

                    btn2.Text = btn3.Text;
                    txtPTRb2 = txtPTRb3;

                    btn3.Text = btn4.Text;
                    txtPTRb3 = txtPTRb4;

                    btn4.Text = btn5.Text;
                    txtPTRb4 = txtPTRb5;

                   // curr_TXTndx++;
                    deco_Prop_TVUS(in_btnTXT[curr_TXTndx], out Txt, out val, out Unit, out stat);
                    btn5.Text = Txt + ": " + val + Unit + stat;
                    Curr_curr = curr_TXTndx;
                    txtPTRb5 = curr_TXTndx++;
                }
               // Select_btn(5);


            }

        }

        void selectBTN_UP()
        {
            if (curr_Selbtn == 1) load_newTXT();
            else
            {
                curr_Selbtn--;
                if (curr_TXTndx > 1)
                {
                    curr_TXTndx--;

                }
                Select_btn(curr_Selbtn);
            }

        }
        void selectBTN_DOWN()
        {
            if (curr_Selbtn == 5) load_newTXT();
            else
            {
                curr_Selbtn++;
                Select_btn(curr_Selbtn);
                //   if (curr_TXTndx >4) curr_TXTndx++;
                if (in_btnTXT[curr_TXTndx + 1] != "*") curr_TXTndx++;
            }

        }

        void clr_btnsnn()
        {


            btn1.BackColor = System.Drawing.SystemColors.HotTrack;
            btn1.ForeColor = Color.White;

            btn2.BackColor = System.Drawing.SystemColors.HotTrack;
            btn2.ForeColor = Color.White;

            btn3.BackColor = System.Drawing.SystemColors.HotTrack;
            btn3.ForeColor = Color.White;

            btn4.BackColor = System.Drawing.SystemColors.HotTrack;
            btn4.ForeColor = Color.White;

            btn5.BackColor = System.Drawing.SystemColors.HotTrack;
            btn5.ForeColor = Color.White;


        }

        void Select_btn(int b)
        {
            clr_btnsnn();
            switch (b)
            {
                case 4:
                    btn4.BackColor = Color.White;
                    btn4.ForeColor = Color.Black;
                    curr_TXTndx = txtPTRb4;

                    break;
                case 1:
                    btn1.BackColor = Color.White;
                    btn1.ForeColor = Color.Black;
                    curr_TXTndx = txtPTRb1;
                    break;
                case 2:
                    btn2.BackColor = Color.White;
                    btn2.ForeColor = Color.Black;
                    curr_TXTndx = txtPTRb2;
                    break;
                case 3:
                    btn3.BackColor = Color.White;
                    btn3.ForeColor = Color.Black;
                    curr_TXTndx = txtPTRb3;
                    break;
                case 5:
                    btn5.BackColor = Color.White;
                    btn5.ForeColor = Color.Black;
                    curr_TXTndx = txtPTRb5;
                    break;
                default:
                    ltxt.BackColor = Color.Red;
                    ltxt.Text = b.ToString();

                    break;

            }
            if (b > 0 && b < 6)
            {
                curr_Selbtn = b;
                curr_XPTR = curr_TXTndx;
            }

            ltxt.Text = curr_TXTndx.ToString();
            lbtn.Text = curr_Selbtn.ToString();


        }



//        ===============================================





    

        private void frmAlarms_Load(object sender, EventArgs e)
        {
           


        }

        private void vScrollBar1_ValueChanged(object sender, EventArgs e)
        {
            
            //if (vScrollBar1.Value > OLD_Scroll)
            //{

            //    //      curr_Selbtn = 
            //   
            //    Select_btn(curr_Selbtn);

            //    OLD_Scroll = vScrollBar1.Value;
            //}

         //   ltxt.Text = vScrollBar1.Value.ToString();

        }

        private void btn1_Click(object sender, EventArgs e)
        {
           // nnnnnnnnnn
            cliQBtn(1);

        }

        private void btn2_Click(object sender, EventArgs e)
        {
            cliQBtn(2);

        }

        private void btn3_Click(object sender, EventArgs e)
        {
            cliQBtn(3);

        }

        private void btn4_Click(object sender, EventArgs e)
        {
            cliQBtn(4);
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            cliQBtn(5);

        }
      
        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }




        void cliQBtn(int b)
        {
            updated = false;
            if (curr_Selbtn == -1) Select_btn(b);
            else Select_btn(curr_Selbtn);
            int selndx = curr_XPTR;
            string txt, val, unit, stat;
            if (in_btnTXT[selndx] != " ")
            {
                deco_Prop_TVUS(in_btnTXT[selndx], out txt, out val, out unit, out stat);
                switch (txt)
                {
                    case "Logic":

                      //  UPSAlarms_2Status myfrm = new UPSAlarms_2Status("Logic", "Fail Safe", "Not Fail Safe", txt, "Logic");
                
                        string cur_logic = (val == "(Fail Safe)") ? "FS" : "NFS";
                        //   UPSAlarms_2Status myfrm = new UPSAlarms_2Status("Logic", "FS", "NFS", cur_logic, "Logic");
                        frmAlarms_edit_OnOff myfrm_L = new frmAlarms_edit_OnOff(in_Title, "FS", "NFS", cur_logic, txt);
                        this.Hide();
                        myfrm_L.ShowDialog();
                        if (myfrm_L.lstat.Text == "Q")
                        {
                            lstat.Text = "Q";
                            myfrm_L.Close();
                            this.Hide();
                        }
                        else
                        {
                            if (myfrm_L.lstat.Text == "Y")
                            {
                                //string cur_logic = (val == "Fail Safe") ? "FS" : "NFS";
                                val = (myfrm_L.lnewSTAT.Text == "FS") ? "(Fail Safe)" : "(Not Fail Safe)";
                                stat = (stat != "") ? myfrm_L.lnewSTAT.Text : " ";
                                if (unit == "") unit = " ";
                                res_Updt = txt + "|" + val + "|" + unit + "|" + stat;
                                string res_Updt1 = " |" + val + "|" + unit + "|" + stat;
                                in_btnTXT[selndx] = res_Updt;

                               // Update_Btns(selndx, res_Updt);
                                Update_Btns(curr_Selbtn, res_Updt);


                               // MainM.alarmsPart1[in_Alrms_II, 2 + Curr_curr] = res_Updt;
                             if (in_TA12==1)    MainM.alarmsPart1[in_Alrms_II, 2 + curr_XPTR] = res_Updt;
                                                  MainM.alarmsPart2[in_Alrms_II, 2 + curr_XPTR] = res_Updt;
                                updated = true;



                            }
                            this.Visible = true;
                        }

                        break;
                    case "Latch Message":
                    case "Latch Relay":
                    case "Alarm Common":
                    case "Enable":
                    case "AC Fail":
                        stat = stat.Replace(" ", "");
                        string cur_AL = (stat == "(ON)") ? "ON" : "OFF";
                        string stDISENA = (cur_AL == "ON") ? "Disable " : "Enable ";
                        frmAlarms_edit_OnOff myfrm_AL = new frmAlarms_edit_OnOff(in_Title, "ON", "OFF", cur_AL, stDISENA + txt);
                        this.Hide();
                        myfrm_AL.ShowDialog();
                        if (myfrm_AL.lstat.Text == "Q")
                        {
                            lstat.Text = "Q";
                            myfrm_AL.Close();
                            this.Hide();
                        }
                        else
                        {
                            if (myfrm_AL.lstat.Text == "Y")
                            {
                                stat = (myfrm_AL.lnewSTAT.Text == "ON") ? "(ON)" : "(OFF)";
                                val = " ";
                             //   stat = (stat != "") ? myfrm_AL.lnewSTAT.Text : " ";
                                if (unit == "") unit = " ";
                                res_Updt = txt + "|" + val + "|" + unit + "|" + stat;
                                string res_Updt1 = " |" + val + "|" + unit + "|" + stat;
                                in_btnTXT[selndx] = res_Updt;

                                //  Update_Btns(selndx, res_Updt);
                                Update_Btns(curr_Selbtn, res_Updt);


                                if (in_TA12 == 1) MainM.alarmsPart1[in_Alrms_II, 2 + curr_XPTR] = res_Updt;
                                else MainM.alarmsPart2[in_Alrms_II, 2 + curr_XPTR] = res_Updt;
                                updated = true;
                                //   MainM.alarmsPart1[in_Alrms_II, 2 + curr_TXTndx] = res_Updt;
                                // MainM.alarmsPart1[in_Alrms_II, 2 + Curr_curr] = res_Updt;


                            }
                            this.Visible = true;
                        }
                        break;
                    case "Alarm Priority":
                        string cur_AP = (val == "Major") ? "Major" : "Minor";
                     //   UPSAlarms_2Status myfrm_AP = new UPSAlarms_2Status("Alarm priority", "Major", "Minor", cur_AP, "Alarm priority");
                        frmAlarms_edit_OnOff myfrm_AP = new frmAlarms_edit_OnOff(in_Title, "Major", "Minor", cur_AP, txt);
                        this.Hide();
                        myfrm_AP.ShowDialog();
                        if (myfrm_AP.lstat.Text == "Q")
                        {
                            lstat.Text = "Q";
                            myfrm_AP.Close();
                            this.Hide();
                        }
                        else
                        {
                            if (myfrm_AP.lstat.Text == "Y")
                            {

                                val = (myfrm_AP.lnewSTAT.Text == "Major") ? "Major" : "Minor";
                                stat = (stat != "") ? myfrm_AP.lnewSTAT.Text : " ";
                                if (unit == "") unit = " ";
                                res_Updt = txt + "|" + val + "|" + unit + "|" + stat;
                                string res_Updt1 = " |" + val + "|" + unit + "|" + stat;
                                in_btnTXT[selndx] = res_Updt;

                                Update_Btns(curr_Selbtn, res_Updt);

                                // MainM.alarmsPart1[in_Alrms_II, 2 + Curr_curr] = res_Updt;
                                if (in_TA12 == 1) MainM.alarmsPart1[in_Alrms_II, 2 + curr_XPTR] = res_Updt;
                                else MainM.alarmsPart2[in_Alrms_II, 2 + curr_XPTR] = res_Updt;
                                updated = true;



                            }
                            this.Visible = true;
                        }
                        break;
                    default:
                        frmAlarms_edit_Val myfrm = new frmAlarms_edit_Val(in_Title, txt, val, unit, stat);
                        this.Hide();
                        myfrm.ShowDialog();
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
                                val = myfrm.lNewV.Text;
                                stat = (stat != "") ? myfrm.lnewSTAT.Text : " ";
                                string res_Updt = txt + "|" + val + "|" + unit + "|" + stat;
                                in_btnTXT[selndx] = res_Updt;

                                Update_Btns(curr_Selbtn, res_Updt);

                                //   MainM.alarmsPart1[in_Alrms_II, 2 + Curr_curr] = res_Updt;
                                if (in_TA12 == 1)
                                {
                                    MainM.alarmsPart1[in_Alrms_II, 2 + curr_XPTR] = res_Updt;
                                    if (curr_XPTR == 0) MainM.alarmsPart1[in_Alrms_II, 1 + curr_XPTR] = " |" + val + "|" + unit + "|" + stat;
                                }
                                else
                                {
                                    MainM.alarmsPart2[in_Alrms_II, 2 + curr_XPTR] = res_Updt;
                                    if (curr_XPTR == 0) MainM.alarmsPart2[in_Alrms_II, 1 + curr_XPTR] = " |" + val + "|" + unit + "|" + stat;
                                }
                                updated = true;

                                
                            }
                            this.Visible = true;
                        }
                        break;
                }
            }

        }



       
        void cliQBtn_OKold(int b)
        {
            //if (curr_Selbtn == -1)
            //{
            //    Select_btn(b);
            // //   SET_curr_XPTR()
            //}
            //else Select_btn(curr_Selbtn);
            //MessageBox.Show("alarm= " + in_btnTXT[curr_XPTR] + "       ===curPTR:" + curr_XPTR.ToString()); 

            if (curr_Selbtn == -1)
            {
                Select_btn(b);
                //   SET_curr_XPTR()
            }
            else Select_btn(curr_Selbtn);
            //    MessageBox.Show("alarm= " + btnTXT[ curr_XPTR]  + "       ===curPTR:" + curr_XPTR.ToString()); 

            int selndx = curr_XPTR;

            //if (selndx == 0)   //editer juste la 1er propriete
            //{
            string txt, val, unit, stat;
            if (in_btnTXT[selndx] != " ")
            {
                deco_Prop_TVUS(in_btnTXT[selndx], out txt, out val, out unit, out stat);

                frmAlarms_edit_Val myfrm = new frmAlarms_edit_Val(in_Title,txt, val, unit, stat);
                this.Hide();
                myfrm.ShowDialog();
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
                        val = myfrm.lNewV.Text;
                        stat = (stat != "") ? myfrm.lnewSTAT.Text : " ";
                        string res_Updt = txt + "|" + val + "|" + unit + "|" + stat;
                        in_btnTXT[selndx] = res_Updt;

                        Update_Btns(curr_Selbtn, res_Updt);

                        //update global array
                        MainM.alarmsPart1[in_Alrms_II, 2 + curr_XPTR] = res_Updt;
                        MainM.alarmsPart1[in_Alrms_II, 1 + curr_XPTR] = " |" + val + "|" + unit + "|" + stat;
                    }
                    this.Visible = true;
                }
            }

            // }



        }
        private void button4_Click(object sender, EventArgs e)
        {
            Select_btn(1);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Select_btn(2);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            cliQBtn(1);
        }

        private void ENTR1_Click(object sender, EventArgs e)
        {

            cliQBtn(1);
        }

        private void ENTR2_Click(object sender, EventArgs e)
        {
            cliQBtn(2);
        }

        private void ENTR3_Click(object sender, EventArgs e)
        {
            cliQBtn(3);
        }

        private void ENTR4_Click(object sender, EventArgs e)
        {
            cliQBtn(4);
        }

        private void ENTR5_Click(object sender, EventArgs e)
        {
            cliQBtn(5);
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnTitle_Click(object sender, EventArgs e)
        {

        }

        private void frmAlarms_values_Load(object sender, EventArgs e)
        {

            btnfloat.Text = MainM.OV_value();
            btnEqua.Text = MainM.OA_value();

            vScrollBar1.Maximum = 1134;

            fill_Btns(0);
            //curr_TXTndx = 0;
            //    Ichng = 1008 / alarmsPart1.Length-3;
            Ichng = 1008 / 8;

            vScrollBar1.LargeChange = Ichng;
            vScrollBar1.SmallChange = Ichng;

            lbtn.Visible = MainM.debago;
            ltxt.Visible = MainM.debago;

            btnTitle.Text =in_Title;
            //btnfloat.Text = in_OV;
            //btnEqua.Text = in_OA;

            
        }



       




    }
}
