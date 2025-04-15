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
    public partial class MainM : Form
    {

        public static string[] arr_msg = new string[100];
        public static int msgCNTR = 0, btnTXT_LEN=300;

        string msgRELAY = "", msgAMBR="";
        public static bool debago =false;
        public static string Float_CurrLim = "24", Float_CurrLim_U = "A",
                             FloatV = "136", Float_U="V",
                             Equalize_CurrLim = "25", Equalize_CurrLim_U = "A",
                             EqualizeV = "139", Equalize_U = "V"
                             
                             ;
        public static bool EqualizeON = false, FloatON = true,
                           ChngEQ_FLT=true;
        //   public static bool EqualizeON = true, FloatON = false;


      public static  string[,] arr_Controls = new string[7, 2] {
{"Float","51.1|V| "},
{"Equalize","52.4|V|(ON)"},
{"Start Equalize"," | | "},
{"Stop Equalize"," | | "},
{"Formation","145|V|(OFF)"},
{"LoadingSharing"," | |(OFF)"},
{"BattTempComp","5mV/C/cell| |(OFF)"}};
        public static  string[,] alarmsPart1 = new string[8, 13] {
{"Battery High Volt"," |145|V|(ON)","Value|145|V|(ON)","Differential|98|%| ","Time Delay|75|S| ","Relay|30| | ","Led|6672| | ","Latch Relay| | |(OFF)","Latch Message| | |(ON)","Logic|(Not Fail Safe)| | ","Alarm Common| | |(OFF)","Alarm Priority|Major| | "," | | | "}, 
{"Battery Low Volt"," |108|V|(ON)", "Value|108|V|(ON)","Differential|102|%| ","Time Delay|30|S| ","Relay|3| | ","Led|0| | ","Latch Relay| | |(OFF)","Latch Message| | |(ON)","Logic|(Fail Safe)| | ","Alarm Common| | |(ON)","Alarm Priority|Minor| | "," | | | "},
{"GND-"," |5|(mA)|(ON)",            "Value|5|(mA)|(ON)","Time Delay|30|S| ","Relay|4| | ","Led|0| | ","Latch Relay| | |(OFF)","Latch Message| | |(ON)","Logic|(Fail Safe)| | ","Alarm Common| | |(ON)","Alarm Priority|Minor| | "," | | | "," | | | "},
{"GND+"," |5|(mA)|(ON)",            "Value|5|(mA)|(ON)","Time Delay|30|S| ","Relay|4| | ","Led|0| | ","Latch Relay| | |(ON)","Latch Message| | |(ON)","Logic|(Fail Safe)| | ","Alarm Common| | |(ON)","Alarm Priority|Major| | "," | | | "," | | | "},
{"Rectifier Fail"," | | |(ON)",     "Enable| | |(ON)","Threshold Volt|85|%| ","Threshold Current|5|%| ","Time Delay|30|S| ","Relay|1| | ","Led|0| | ","Latch Relay| | |(OFF)","Latch Message| | |(ON)","Logic|(Fail Safe)| | ","Alarm Common| | |(ON)","Alarm Priority|Major| | "},
{"AC Fail"," | | |(ON)",            "AC Fail| | |(ON)","Time Delay|30|S| ","Relay|6| | ","Led|0| | ","Latch Relay| | |(OFF)","Latch Message| | |(ON)","Logic|(Fail Safe)| | ","Alarm Common| | |(ON)","Alarm Priority|Major| | ","Restart Delay|66|S| "," | | | "},
{"Common Alarm"," |0| | ",          "Relay|6| | ","Led|0| | ","Latch Relay| | |(OFF)","Latch Message| | |(ON)","Logic|(Fail Safe)| | "," | | | "," | | | "," | | | "," | | | "," | | | "," | | | "},
{"Others","Others",                      "Others"," "," "," "," "," "," "," "," "," "," "}
                                                  };
       public static string[,] alarmsPart2 = new string[28, 13] { 
{"Rectifier High Volt"," |147|V|(OFF)",       "Value|147|V|(OFF)","Differential|98|%| ","Time Delay|30|S| ","Relay|0| | ","Led|0| | ","Latch Relay| | |(OFF)","Latch Message| | |(ON)","Logic|(Fail Safe)| | ","Alarm Common| | |(ON)","Alarm Priority|Major| | "," | | | "},
{"Rectifier Low Volt", " |108|V|(OFF)",       "Value|108|V|(OFF)","Differential|102|%| ","Time Delay|10|mn| ","Relay|0| | ","Led|0| | ","Latch Relay| | |(OFF)","Latch Message| | |(ON)","Logic|(Fail Safe)| | ","Alarm Common| | |(ON)","Alarm Priority|Major| | "," | | | "},
{"High Volt Shut Down"," |153|V|(OFF)",       "Value|153|V|(OFF)","Differential|80|%| ","Time Delay|30|S| ","Relay|0| | ","Led|0| | ","Latch Relay| | |(OFF)","Latch Message| | |(ON)","Logic|(Fail Safe)| | ","Alarm Common| | |(ON)","Alarm Priority|Major| | "," | | | "},
{"End of Discharge", " |105|V|(OFF)",         " "," "," "," "," "," "," "," "," "," "," "},
{"High Rectifier Temperature"," |49|C|(OFF)", " "," "," "," "," "," "," "," "," "," "," "},
{"Low Rectifier Temperature"," |30|C|(OFF)",  " "," "," "," "," "," "," "," "," "," "," "},
{"High Battery Temperature"," |30|C|(OFF)",   " "," "," "," "," "," "," "," "," "," "," "},
{"Low Battery Temperature"," |0|C|(OFF)",     " "," "," "," "," "," "," "," "," "," "," "},
{"AC High Volt"," |265|V|(OFF)",              " "," "," "," "," "," "," "," "," "," "," "},
{"AC Low Volt"," |211|V|(OFF)",               " "," "," "," "," "," "," "," "," "," "," "},
{"High Ripple"," |2|%|(OFF)",                 " "," "," "," "," "," "," "," "," "," "," "},
{"Rectifier Low Current"," |23.0|AMP|(OFF)",  " "," "," "," "," "," "," "," "," "," "," "},
{"Rectifier High Current"," |30.0|AMP|(OFF)", " "," "," "," "," "," "," "," "," "," "," "},
{"Battery Low Current"," |3|AMP|(OFF)",       " "," "," "," "," "," "," "," "," "," "," "},
{"Battery High Current"," |41|AMP|(OFF)",     " "," "," "," "," "," "," "," "," "," "," "},
{"Battery High Capacity"," |106|%|(OFF)",     " "," "," "," "," "," "," "," "," "," "," "},
{"Battery Low Capacity"," |0|%|(OFF)",        " "," "," "," "," "," "," "," "," "," "," "},
{"Equalize Alarm"," | | |(ON)",               " "," "," "," "," "," "," "," "," "," "," "},
{"PCOM Disconnect Alarm"," | | |(OFF)",       " "," "," "," "," "," "," "," "," "," "," "},
{"PM Disconnect Alarm"," | | |(OFF)",         " "," "," "," "," "," "," "," "," "," "," "},
{"Probe Disconnect Alarm"," | | |(OFF)",      " "," "," "," "," "," "," "," "," "," "," "},
{"Frequency Alarm"," | | |(OFF)",             " "," "," "," "," "," "," "," "," "," "," "},
{"High Frequency Alarm"," |60.2|Hz|(ON)",     " "," "," "," "," "," "," "," "," "," "," "},
{"Low Frequency Alarm"," |59.5|Hz|(ON)",      " "," "," "," "," "," "," "," "," "," "," "},
{"Batt Imbalance Alarm"," |0.5|V|(OFF)",      " "," "," "," "," "," "," "," "," "," "," "},
{"Battery Discharging"," | | |(ON)",          " "," "," "," "," "," "," "," "," "," "," "},
{"Differential Temperature"," |10|C|(ON)",    " "," "," "," "," "," "," "," "," "," "," "},
{"Buzzer"," | | |(OFF)",                      " "," "," "," "," "," "," "," "," "," "," "},
       };



        public static string[,] alarms_OneList = new string[29, 12] {
{"Battery High Voltage Alarm"," |3|V|(ON)","Value|3|V|(ON)","Differential|3|%| ","Time Delay|75|S| ","Relay|30| | ","Led|6672| | ","Latch Relay| | |(OFF)","Latch Message| | |(ON)","Logic|(Not Fail Safe)| | ","Alarm Common| | |(OFF)","Alarm Priority|Major| | "},
{"Battery Low Voltage Alarm"," |0.4|V|(ON)"," "," "," "," "," "," "," "," "," "," "},
{"Positive Ground Fault Alarm"," |0|(mA)|(ON)",         " "," "," "," "," "," "," "," "," "," "},
{"Negative Ground Fault Alarm"," |8.5|(mA)|(ON)",       " "," "," "," "," "," "," "," "," "," "},
{"AC Fail Alarm"," | | |(ON)",       " "," "," "," "," "," "," "," "," "," "},
{"Rectifier Fail Alarm"," | | |(ON)",              " "," "," "," "," "," "," "," "," "," "},
{"Rectifier High Voltage Alarm *"," |3|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"High Voltage Shutdown Alarm *", " |3|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Rectifier Low Voltage Alarm *"," |3|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"End of Discharge Alarm (2nd Low Volt Level)*", " |3|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Charger High Temperature Alarm *"," |30|C|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Charger Low Temperature Alarm *"," |30|C|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Battery High Temperature Alarm **"," |30|C|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Battery Low Temperature Alarm **"," |30|C|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"AC High Voltage Alarm **"," |3|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"AC Low Voltage Alarm **"," |0|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"High Ripple Alarm *"," |0|%|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Rectifier Low Current Alarm *"," |3|AMP|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Rectifier High Current Alarm *"," |3|AMP|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Battery Low Current Alarm **"," |3|AMP|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Battery High Current Alarm **"," |3|AMP|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Battery High Capacity Alarm **"," |30|%|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Battery Low Capacity Alarm **"," |0|%|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Equalize Alarm *"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"PCOM Alarm **"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"PM Alarm **"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Frequency Alarm *"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Unbalanced Battery Alarm **"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Temperature Probe Alarm **"," |6553|Hz|(ON)"," "," "," "," "," "," "," "," "," "," "}};



        public MainM()
        {
            InitializeComponent();
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            Pwd myPWD = new Pwd();
            this.Hide();
            myPWD.ShowDialog();
            if (myPWD.lstat.Text == "YES")
            {
                frmMenusetting mymenusetting = new frmMenusetting();
                mymenusetting.ShowDialog();
            }
           this.Visible = true;
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        public static string A00(int ii, int Lnt)
        {
            //if (ii==0 ) return "00";
            string st = ii.ToString();
            for (int j = st.Length; j < Lnt; j++)
                st = "0" + st;
            return st;
        }


        private void btnTools_Click(object sender, EventArgs e)
        {
            frmTools myFrm = new frmTools();
            this.Hide();
            myFrm.ShowDialog();
            this.Visible = true;
        }

        public static void init_msg(int from , int to)
        {

            for (int i=from;i<to;i++) arr_msg[i]="";

        }

        private void MainM_VisibleChanged(object sender, EventArgs e)
        {
            btnfloat.Text = MainM.OV_value();
            btnEqua.Text = MainM.OA_value();
        }

        private void btnAMBR_Click(object sender, EventArgs e)
        {
            frmReset_AMBR myPWD = new frmReset_AMBR(btnAMBR.Text, btnAMBR.Text+ "  OK  ");
            this.Hide();
            myPWD.ShowDialog();
            if (myPWD.lstat.Text == "YES")
            {
                frmMenusetting mymenusetting = new frmMenusetting();
                mymenusetting.ShowDialog();
            }
            this.Visible = true;
        }

        public static void fill_msg(string msg)
        {

            for (int i = 0; i < 100; i++)
            {
                if (arr_msg[i] == "")
                {
                    arr_msg[i] = msg;
                    i = 100;
                }
            }

        }


        public static  string calc_val(string frml)
        {
            string rez = "0";
            switch (frml)
            {
                case "VRECTIF":
                    rez = (MainM.FloatON) ? (double.Parse(MainM.FloatV) + 1).ToString() : (double.Parse(MainM.EqualizeV) + 1).ToString();
                    break;
                case "FL_EQ_Div2":
                    rez = (MainM.FloatON) ? (double.Parse(MainM.FloatV) / 2).ToString() : (double.Parse(MainM.EqualizeV) / 2).ToString();
                    break;

            }
            return rez;

        }

        public static string OV_value()
        {
          if (MainM.EqualizeON) return  MainM.EqualizeV + "V" ;
          else return  MainM.FloatV + "V";

        }
     
        
        public static string OA_value()
        {
            if (MainM.EqualizeON) return MainM.Equalize_CurrLim + "A";
            else return MainM.Float_CurrLim + "A";


        }
        private void MainM_Load(object sender, EventArgs e)
        {

                   btnfloat.Text = MainM.OV_value();
                   btnEqua.Text = MainM.OA_value ();

            init_msg(0, 100);

            //fill_msg("AC FAIL   ");
            //fill_msg("Battery Low Volt   ");
            //fill_msg("GND- Fault   ");
            //fill_msg("GND+ Fault   ");


        }

        private void timer_Msg_Tick(object sender, EventArgs e)
        {
            if (arr_msg[msgCNTR] == "") msgCNTR = 0;
            btnMSG.Text = arr_msg[msgCNTR++];
        }

        private void timer_blink_Tick(object sender, EventArgs e)
        {
            //if (btnRelay.ForeColor == System.Drawing.SystemColors.HotTrack)
            //{
            //    btnRelay.ForeColor = Color.White;
            //    btnAMBR.ForeColor = Color.White;
            //}
            //else
            //{
            //    btnRelay.ForeColor = System.Drawing.SystemColors.HotTrack;
            //    btnAMBR.ForeColor = System.Drawing.SystemColors.HotTrack;
            //}

           //if (btnRelay.Text ==""  )
           //{
           //  //  btnRelay.Text = msgRELAY ;
           //  //  btnAMBR.Text = msgAMBR ;
              

           //}
           //else
           //{

           // //   msgRELAY = btnRelay.Text;
           // //   msgAMBR = btnAMBR.Text;
           ////    btnRelay.Text = "";
           ////    btnAMBR.Text = "";

           //}

            if (MainM.EqualizeON)
            {
                if (btnEqua_modif.Text == "") { btnEqua_modif.Text = "Equalize"; btnfloat_modif.Text = "Float"; }
                else btnEqua_modif.Text = "";
            }
            else
            {
                if (btnfloat_modif.Text == "") { btnfloat_modif.Text = "Float"; btnEqua_modif.Text = "Equalize"; }
                else btnfloat_modif.Text = "";
            }
           

        }

        private void btnRelay_Click(object sender, EventArgs e)
        {
            frmReset_AMBR myPWD = new frmReset_AMBR(btnRelay.Text, "");
            this.Hide();
            myPWD.ShowDialog();
            if (myPWD.lstat.Text == "YES")
            {
                frmMenusetting mymenusetting = new frmMenusetting();
                mymenusetting.ShowDialog();
            }
            this.Visible = true;
        }

        private void btnfloat_modif_Click(object sender, EventArgs e)
        {
           if (MainM.ChngEQ_FLT ) Change_equalize_Float();

            //  myFlEq.Close();

            //if (myFlEq.lstat.Text == "Q")
            //{
            //    myFlEq.Close();
            //    this.Hide();
            //}
            //else this.Visible = true;

            //btnfloat.Text = MainM.OV_value();
            //btnEqua.Text = MainM.OA_value();
        }

        private void btnEqua_modif_Click(object sender, EventArgs e)
        {
            if (MainM.ChngEQ_FLT)  Change_equalize_Float();
            //btnfloat.Text = MainM.OV_value();
            //btnEqua.Text = MainM.OA_value();
        }

        void Change_equalize_Float()
        {
            Change_Float_EQ myFlEq = new Change_Float_EQ(MainM.FloatON, MainM.EqualizeON);
            this.Hide();
            myFlEq.ShowDialog();
            this.Visible = true;

        }





    }
}
