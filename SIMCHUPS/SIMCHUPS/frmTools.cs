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
    public partial class frmTools : Form
    {
        string in_Title = "Tools";
        
        int Partn = 0, curr_Selbtn = 0, curr_TXTndx = -1, OLD_Scroll = -1, NEW_Scroll = -1, Ichng=0,curr_XPTR=0,
            txtPTRb1=-1,txtPTRb2=-1,txtPTRb3=-1,txtPTRb4=-1,txtPTRb5=-1;
        //{"Battery High Volt"," 3V (ON)","Value: 3V (ON)","Differential: 3%","Time Delay: 75S ","Relay: 30","Led: 6672","Latch Relay: (OFF)","Latch Message: (ON)","Logic: (Not Fail Safe)","Alarm Common: (OFF)","Alarm Priority: Major"},    
        string[,] Tools = new string[12, 19] {
{"Reading"," | | | ","Frequency|15|HZ| ","Vrectifier|!VRECTIF|V| ","Vgndn|!FL_EQ_Div2|V| ","Vgndp|!FL_EQ_Div2|V| ","Remaining Time Equalize|460|mn| ","Elaps Time Equalize|20|mn| ","Board Temperature|30|C| ",
                     "Batt Temperature|27|C| ","ThirdProbe Temp|25|C| ","Vtest|110|V| ","Itest|27.4|AMP| ","Test Time|60|mn| ","Vtest Continuity|110|V| ","Test Time Continuity|120|S| ",
                     "Itest Continuity|27.4|AMP| ","AH Test|18|%| ","Capacity used test|27|AH| "}, 
{"Events Log"," | | | "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
{"Reset Events"," | | | ",         " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
{"Reset Test Events"," | | | ",       " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
{"Relay Test"," | | | ",              " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
{"LED Test"," | | | ",              " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
{"LCD Power Save"," | | | ",              " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
{"Battery Service Manual Test"," | | | ",              " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
{"Battery Continuity Test Manual"," | | | ",              " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
{"Amper Hour Sync"," | | | ",              " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
{"Formation"," | | | ",              " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
{"Language"," | | | ",              " "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "," "},
                                                  };
        string[] Events = new string[12];
        //!VRECTIF if (FLT) float+1
        //         else Equalize+1

        string[] btnTXT = new string[MainM.btnTXT_LEN];




        public frmTools()
        {
            InitializeComponent();
            //btnfloat.Text = in_OV;
            //btnEqua.Text = in_OA;
            btnTitle.Text = in_Title;
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

        void fill_Alarms(int part)
        {
            for (int i = 0; i < MainM.btnTXT_LEN; i++) btnTXT[i] = "*";
            if (part == 1) for (int ii = 0; ii < 12; ii++) btnTXT[ii] = Tools[ii, 0] + ":"+deco_Prop (Tools[ii, 1]);
            else
            {
               // for (int t = 0; t < 28; t++) btnTXT[t] = alarmsPart2[t, 0] + ":" + deco_Prop ( alarmsPart2[t, 1]);

            }
           
        }

        string HHMNSS()
        {
            return MainM.A00 (DateTime.Now.Hour,2) + ":" + MainM.A00 (DateTime.Now.Minute,2) + ":" + MainM.A00 (DateTime.Now.Second,2);

        }
        void fill_Event()
        {
            string YYMM = DateTime.Now.Year.ToString().Substring (2,2) +":"+ MainM.A00 (DateTime.Now.Month,2);
           // string HHMNSS = DateTime.Now.Hour.ToString() + ":" + DateTime.Now.Minute.ToString() + ":" + DateTime.Now.Second.ToString();//   .Year.ToString() + DateTime.Now.Month.ToString();

            Events[0] = "Event" + MainM.A00(1, 3) + ":E20:"+YYMM +":" +HHMNSS() ;
            Events[1] = "Event" + MainM.A00(2, 3) + ":E12:" + YYMM + ":" + HHMNSS();
            Events[2] = "Event" + MainM.A00(3, 3) + ":E19:" + YYMM + ":" + HHMNSS();
            Events[3] = "Event" + MainM.A00(4, 3) + ":E03:" + YYMM + ":" + HHMNSS();
            Events[4] = "Event" + MainM.A00(5, 3) + ":E21:" + YYMM + ":" + HHMNSS();

            for (int j=5;j<10;j++) Events [j]="Event" + MainM.A00(j+1, 3) + ":E00:" + "00:00:00:00:00";

            Events[10] = "Event"  +"---" + ":E00:" + "00:00:00:00:00";
            Events[11] = "Event" + MainM.A00(250, 3)   + ":E00:" + "00:00:00:00:00";


        //    for (int i = 0; i < MainM.btnTXT_LEN; i++) btnTXT[i] = "*";
  

        }

        void Reset_Events()
        {
            for (int j = 0; j <12; j++) Events[j] = "Event" + MainM.A00(j + 1, 3) + ":E00:" + "00:00:00:00:00";
            Events[10] = "Event" + "---" + ":E00:" + "00:00:00:00:00";
            Events[11] = "Event" + MainM.A00(250, 3) + ":E00:" + "00:00:00:00:00";

        }


        string deco_Prop(string stPro)
        {
            string res = "", st=stPro;// "Battery High Volt"," |3|V|(ON)",
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
                else msg = " " +st;
                if (res == "????") { i = 4; res = ""; }
                if (msg != " " && i<4) res += msg;
                
            }


            return res; 
        }



        void fill_Btns( int _ndx)
        {
         
            btn1.Text = btnTXT[_ndx]; txtPTRb1 = _ndx++;
            btn2.Text = btnTXT[_ndx]; txtPTRb2 = _ndx++;
            btn3.Text = btnTXT[_ndx]; txtPTRb3 = _ndx++;
            btn4.Text = btnTXT[_ndx]; txtPTRb4 = _ndx++;
            btn5.Text = btnTXT[_ndx]; txtPTRb5 = _ndx;
            curr_TXTndx = _ndx;
            curr_Selbtn =1;
            Select_btn(1);
            ltxt.Text = curr_TXTndx.ToString();
            lbtn.Text = curr_Selbtn.ToString();

        }  



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
                if (e.OldValue >e.NewValue )
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
            if (curr_Selbtn  ==1)
            {
                if (curr_TXTndx >0)
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
                    btn1.Text = btnTXT[curr_TXTndx];
                    txtPTRb1 = curr_TXTndx;
                    //Select_btn(1);
                }
                Select_btn(1);
            }
            else
            {
             //   if (btnTXT[curr_TXTndx + 1] != "*")
                if (btnTXT[curr_TXTndx + 1] != "*")
                {
                    btn1.Text = btn2.Text;
                    txtPTRb1 = txtPTRb2;

                    btn2.Text = btn3.Text;
                    txtPTRb2 = txtPTRb3;

                    btn3.Text = btn4.Text;
                    txtPTRb3 = txtPTRb4;

                    btn4.Text = btn5.Text;
                    txtPTRb4 = txtPTRb5;

                    curr_TXTndx++;
                    btn5.Text = btnTXT[curr_TXTndx]; 
                    txtPTRb5 = curr_TXTndx;
                }
                Select_btn(5);


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
                if (btnTXT[curr_TXTndx + 1] != "*") curr_TXTndx++;
            }

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
                default :
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

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        void cliQBtn(int b)
        {
            if (curr_Selbtn == -1)
            {
                Select_btn(b);
             //   SET_curr_XPTR()
            }
            else Select_btn(curr_Selbtn);
       
            string[] V_btnTXT = new string[MainM.btnTXT_LEN];
            switch (curr_XPTR)
            {
                case 0:

                    for (int i = 0; i < MainM.btnTXT_LEN; i++) V_btnTXT[i] = "*";
                    for (int bb = 2, v = 0; bb < 19; bb++, v++) V_btnTXT[v] = Tools[curr_XPTR, bb];
                    if (V_btnTXT[0] != " ")
                    {
                        frmTools_values myfrm0 = new frmTools_values(Tools[curr_XPTR, 0], V_btnTXT, 19 - 2, 0);
                        this.Hide();
                        myfrm0.ShowDialog();
                        if (myfrm0.lstat.Text == "Q")
                        {
                            lstat.Text = "Q";
                            myfrm0.Close();
                            this.Hide();
                        }
                        else this.Visible = true;
                    }
                    break;
                case 1:

                    for (int i = 0; i < MainM.btnTXT_LEN; i++) V_btnTXT[i] = "*";
                    for (int v = 0; v < 12; v++) V_btnTXT[v] = Events[v];
                    if (V_btnTXT[0] != " ")
                    {
                        frmTools_values myfrm1 = new frmTools_values(Tools[curr_XPTR, 0], V_btnTXT, 12, 1);  //0: detailed values      1:values List
                        this.Hide();
                        myfrm1.ShowDialog();
                        if (myfrm1.lstat.Text == "Q")
                        {
                            lstat.Text = "Q";
                            myfrm1.Close();
                            this.Hide();
                        }
                        else this.Visible = true;
                    }
                    break;
                case 2:

                    Confirm_Docmd myfrm2 = new Confirm_Docmd("Reset Events", "Actual Status:", "Reset Events");  //0: detailed values      1:values List
                    this.Hide();
                    myfrm2.ShowDialog();
                    if (myfrm2.lstat.Text == "Q")
                    {
                        lstat.Text = "Q";
                        myfrm2.Close();
                        this.Hide();
                    }
                    else
                    {
                        if (myfrm2.lstat.Text == "Y")
                        {
                            Confirm_Mode myfrm = new Confirm_Mode("Reset Events", "", "", "", "");
                            this.Hide();
                            myfrm.ShowDialog();
                            if (myfrm.lstat.Text == "Y")
                            {
                                lstat.Text = "Y";
                                Reset_Events();

                            }
                            myfrm.Close();
                        }
                        else lstat.Text = "N";

                        this.Visible = true;
                    }

                    break;
            }

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

        private void frmTools_Load(object sender, EventArgs e)
        {

            btnfloat.Text = MainM.OV_value();
            btnEqua.Text = MainM.OA_value();

            vScrollBar1.Maximum = 1134;

            fill_Alarms(1);
            fill_Event();
            fill_Btns(0);
            Ichng = 1008 / 12;

            vScrollBar1.LargeChange = Ichng;
            vScrollBar1.SmallChange = Ichng;

            lbtn.Visible = MainM.debago;
            ltxt.Visible = MainM.debago;
        }



       




    }
}
