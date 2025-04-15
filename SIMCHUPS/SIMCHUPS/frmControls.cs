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
    public partial class frmControls : Form
    {
        string in_OV = "?????V", in_OA = "?????A", in_Title = "------";
        int cntr = 1, curr_Selbtn = 0, curr_TXTndx = -1, OLD_Scroll = -1, NEW_Scroll = -1, Ichng=0,curr_XPTR=0,
            txtPTRb1=-1,txtPTRb2=-1,txtPTRb3=-1,txtPTRb4=-1,txtPTRb5=-1;


        string[] in_btnTXT = new string[MainM.btnTXT_LEN];




        public frmControls(string x_Title, string[] x_btntxt)
        {
            InitializeComponent();

            btnTitle.Text = x_Title;
            in_btnTXT = x_btntxt;
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


        void fill_Btns(int _ndx)
        {
            string Txt, val, Unit, stat;
            deco_Prop_TVUS(in_btnTXT[_ndx], out Txt, out val, out Unit, out stat);
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
            curr_Selbtn = 1;
            Select_btn(1);
            ltxt.Text = curr_TXTndx.ToString();
            lbtn.Text = curr_Selbtn.ToString();

        }

        //void fill_Btns( int _ndx)
        //{
         
        //    btn1.Text = in_btnTXT[_ndx]; txtPTRb1 = _ndx++;
        //    btn2.Text = in_btnTXT[_ndx]; txtPTRb2 = _ndx++;
        //    btn3.Text = in_btnTXT[_ndx]; txtPTRb3 = _ndx++;
        //    btn4.Text = in_btnTXT[_ndx]; txtPTRb4 = _ndx++;
        //    btn5.Text = in_btnTXT[_ndx]; txtPTRb5 = _ndx;
        //    curr_TXTndx = _ndx;
        //    curr_Selbtn =1;
        //    Select_btn(1);
        //    ltxt.Text = curr_TXTndx.ToString();
        //    lbtn.Text = curr_Selbtn.ToString();

        //}

        void deco_Prop_TVUS(string stPro, out string Txt, out string val, out string Unit, out string stat)
        {
            Txt = ""; val = ""; Unit = ""; stat = "";
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
                            Txt = msg;//+":  ";
                            break;
                        case 1:
                            val = msg;
                            break;
                        case 2:
                            Unit = msg;
                            break;
                        case 3:
                            stat = (msg == "") ? "" : " " + msg;
                            break;
                    }
                }
                //if (msg != " " && i < 4) res += msg;

            }



        }


        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
           //    int Line=  vScrollBar1.Value *   

         //   label1.Text = vScrollBar1.Value.ToString();
         //   MessageBox.Show("sssssss");
            //if (curr_Selbtn==-1)
            //{
            //    curr_Selbtn = 1;
            //    Select_btn(1);
            //}
         //   MessageBox.Show("old=" + e.OldValue.ToString ()+"   new=" + e.NewValue.ToString ()  ); 

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

                    //Select_btn(1);
                }
                //   Select_btn(1);
            }
            else
            {
                //   if (btnTXT[curr_TXTndx + 1] != "*")
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
                    txtPTRb5 = curr_TXTndx++;
                }
                // Select_btn(5);


            }

        }
        void load_newTXT_OLD()
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
                    btn1.Text = in_btnTXT [curr_TXTndx];
                    txtPTRb1 = curr_TXTndx;
                    //Select_btn(1);
                }
                Select_btn(1);
            }
            else
            {
             //   if (btnTXT[curr_TXTndx + 1] != "*")
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
                    btn5.Text = in_btnTXT[curr_TXTndx++]; 
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

        private void frmControls_Load(object sender, EventArgs e)
        {
            //1008 / 7=144  ===>max=1008+144=1152
            vScrollBar1.Maximum = 1152;// 1134;

            fill_Btns(0);

            //    Ichng = 1008 / alarmsPart1.Length-3;
            Ichng = 1008 / 7;

            vScrollBar1.LargeChange = Ichng;
            vScrollBar1.SmallChange = Ichng;

            lbtn.Visible = MainM.debago;
            ltxt.Visible = MainM.debago;

            btnfloat.Text = MainM.OV_value();
            btnEqua.Text = MainM.OA_value();
        }

        void ref_List()
        {
            MainM.arr_Controls[0, 1] = MainM.FloatV + "|V| ";
            MainM.arr_Controls[1, 1] = MainM.EqualizeV + "|V|" + ((MainM.ChngEQ_FLT) ? "(ON)" : "(OFF)");// MainM.EqualizeV + "|V|(OFF)";
            for (int i = 0; i < MainM.btnTXT_LEN; i++) in_btnTXT[i] = "*";
            for (int bb = 0; bb < 7; bb++) in_btnTXT[bb] = MainM.arr_Controls[bb, 0] + "|" + MainM.arr_Controls[bb, 1];
            fill_Btns(0);
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
            string[] V_btnTXT = new string[MainM.btnTXT_LEN];
            string title = "";
            if (curr_Selbtn == -1)
            {
                Select_btn(b);
                //   SET_curr_XPTR()
            }
            else Select_btn(curr_Selbtn);
            //    MessageBox.Show("alarm= " + btnTXT[ curr_XPTR]  + "       ===curPTR:" + curr_XPTR.ToString()); 
                //string[] V_btnTXT = new string[50];
                for (int i = 0; i < MainM.btnTXT_LEN; i++) V_btnTXT[i] = "*";

            switch (b)
            {

                case 1:
                    V_btnTXT[0] = "Float Voltage|" + MainM.FloatV + "|V| ";
                    V_btnTXT[1] = "Float Current Limit|" + MainM.Float_CurrLim + "|AMP| ";
                    title = "Float";

                    break;
                case 2:
                    V_btnTXT[0] = "Equalize Voltage|" + MainM.EqualizeV + "|V|"+((MainM.ChngEQ_FLT) ? "(ON)" : "(OFF)" ) ;
                    V_btnTXT[1] = "Equalize Current Limit|" + MainM.Equalize_CurrLim + "|AMP| ";
                    title = "Equalize";

                    break;
            }


                    // for (int bb = 2, v = 0; bb < 12; bb++, v++) V_btnTXT[v] = MainM.alarmsPart1[curr_XPTR, bb];
                    if (title != "")
                {
                    frmOption2_5_values  myfrm = new frmOption2_5_values("Controls Values",title , V_btnTXT,2);
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
                      //  btnTXT[0] = MainM.alarmsPart1[curr_XPTR, 0] + ":" + deco_Prop(MainM.alarmsPart1[curr_XPTR, 1]);
                    //    update_Btns(b);
                        this.Visible = true;
                    ref_List();
                    }
                }


            btnfloat.Text = MainM.OV_value();
            btnEqua.Text = MainM.OA_value();

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



       




    }
}
