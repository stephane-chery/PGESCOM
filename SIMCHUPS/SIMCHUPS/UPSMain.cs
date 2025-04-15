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
    public partial class UPSMain : Form
    {

        public static string[,] arr_Controls = new string[7, 2] {
{"Float","51.1|V| "},
{"Equalize","52.4|V|(ON)"},
{"Start Equalize"," | | "},
{"Stop Equalize"," | | "},
{"Formation","145|V|(OFF)"},
{"Load Sharing"," | |(OFF)"},
{"Temperature Compensation","1.3m V/C/cell| |(OFF)"}};


        public static string[,] INV_alarms = new string[24, 12] {
{"Battery High Volt"," |147|V|(OFF)","Value|145|V|(ON)","Differential|98|%| ","Time Delay|75|S| ","Relay|30| | ","Led|6672| | ","Latch Relay| | |(OFF)","Latch Message| | |(ON)","Logic|(Not Fail Safe)| | ","Alarm Common| | |(OFF)","Alarm Priority|Major| | "},
{"Battery Low Vol"," |108|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Bypass AC High Volt"," |260|(V)|(OFF)",         " "," "," "," "," "," "," "," "," "," "},
{"Bypass AC Low Volt"," |26|(V)|(ON)",       " "," "," "," "," "," "," "," "," "," "},
{"Inverter AC High Volt"," |260|V|(OFF)",       " "," "," "," "," "," "," "," "," "," "},
{"Inverter AC Low Volt"," |140|V|(OFF)",              " "," "," "," "," "," "," "," "," "," "},
{"Output AC High Volt "," |260|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Output AC Low Volt", " |140|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"High AC Output Current"," |260|AMP|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"High Temperature 1", " |30|C|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Low Temperature 1"," |0|C|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"High Temperature 2"," |30|C|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Low Temperature 2"," |0|C|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"High Temperature 3"," |30|C|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Low Temperature 3"," |0|C|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Desaturation Alarm"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Synchronization Alarm"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Failure Transfer Alarm"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Load On Bypass Alarm"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Load On Inverter Alarm"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Load On Manual Bypass Alarm"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Inverter Off Alarm"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Bypass Off Alarm"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Common Alarm"," |7| | "," "," "," "," "," "," "," "," "," "," "}};


        public static string[,] RECT_alarms = new string[35, 12] {
{"Battery High Volt"," |145|V|(ON)","Value|145|V|(ON)","Differential|98|%| ","Time Delay|75|S| ","Relay|30| | ","Led|6672| | ","Latch Relay| | |(OFF)","Latch Message| | |(ON)","Logic|(Not Fail Safe)| | ","Alarm Common| | |(OFF)","Alarm Priority|Major| | "},
{"Battery Low Volt"," |108|V|(ON)"," "," "," "," "," "," "," "," "," "," "},
{"GND-"," |5|(mA)|(ON)",         " "," "," "," "," "," "," "," "," "," "},
{"GND+"," |5|(mA)|(ON)",       " "," "," "," "," "," "," "," "," "," "},
{"Rectifier Fail"," | | |(ON)",       " "," "," "," "," "," "," "," "," "," "},
{"AC Fail"," | | |(ON)",              " "," "," "," "," "," "," "," "," "," "},
{"Common Alarm"," |18| | ",              " "," "," "," "," "," "," "," "," "," "},
{"Rectifier High Volt"," |147|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Rectifier Low Volt", " |108.8|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"High Volt Shut Down"," |153.5|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"End of Discharge", " |105|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"High Rectifier Temperature"," |49|C|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Low Rectifier Temperature"," |30|C|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"High Battery Temperature"," |30|C|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Low Battery Temperature"," |0|C|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"AC High Volt"," |265|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"AC Low Volt"," |211|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"High Ripple"," |2|%|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Rectifier Low Current"," |23.0|AMP|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Rectifier High Current"," |30.0|AMP|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Battery Low Current"," |3|AMP|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Battery High Current"," |41|AMP|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Battery High Capacity"," |106|%|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Battery Low Capacity"," |20|%|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Equalize Alarm"," | | |(ON)"," "," "," "," "," "," "," "," "," "," "},
{"PCOM Disconnect Alarm"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"PM Disconnect Alarm"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Probe Disconnect Alarm"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Frequency Alarm"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"High Frequency Alarm"," |60.2|Hz|(ON)"," "," "," "," "," "," "," "," "," "," "},
{"Low Frequency Alarm"," |59.5|Hz|(ON)"," "," "," "," "," "," "," "," "," "," "},
{"Batt Imbalance Alarm"," |0.5|V|(OFF)"," "," "," "," "," "," "," "," "," "," "},
{"Battery Discharging"," | | |(ON)"," "," "," "," "," "," "," "," "," "," "},
{"Differential Temperature"," |10|C|(ON)"," "," "," "," "," "," "," "," "," "," "},
{"Buzzer"," | | |(OFF)"," "," "," "," "," "," "," "," "," "," "}};


        public static string[,] Inv_DigiInp = new string[15, 11] {
{"Digital Inputs 1"," | | | ","Message| | | ","Function|1| | ","Relay|1| | ","Led|0| | ","Time|0| | ","Logic|(Not Fail Safe)| | ","Alarm Common|(ON)| | ","Alarm Priority|Major| | ","DigitalActif|(ON)| | "},
{"Digital Inputs 2"," | | | "," "," "," "," "," "," "," "," "," "},
{"Digital Inputs 3"," | | | "," "," "," "," "," "," "," "," "," "},
{"Digital Inputs 4"," | | | "," "," "," "," "," "," "," "," "," "},
{"Digital Inputs 5"," | | | "," "," "," "," "," "," "," "," "," "},
{"Digital Inputs 6"," | | | "," "," "," "," "," "," "," "," "," "},
{"Digital Inputs 7"," | | | ", " "," "," "," "," "," "," "," "," "},
{"Digital Inputs 8"," | | | "," "," "," "," "," "," "," "," "," "},
{"Digital Inputs 9"," | | | "," "," "," "," "," "," "," "," "," "},
{"Digital Inputs 10"," | | | "," "," "," "," "," "," "," "," "," "},
{"Digital Inputs 11"," | | | "," "," "," "," "," "," "," "," "," "},
{"Digital Inputs 12"," | | | "," "," "," "," "," "," "," "," "," "},
{"Digital Inputs 13"," | | | "," "," "," "," "," "," "," "," "," "},
{"Digital Inputs 14"," | | | "," "," "," "," "," "," "," "," "," "},
{"Digital Inputs 15"," | | | "," "," "," "," "," "," "," "," "," "} };



        public static string[,] arr_Controls_TP = new string[9, 2] {
{"Ilim Transfer","48|AMP| "},
{"Percentage overcurrent 1","125|%| "},
{"Percentage overcurrent 2","150|%| "},
{"Desaturation Percentage","260|%| "},
{"Transfer Time over current 1","10|min| "},
{"Transfer Time over current 2","60|S| "},
{"Low Rectifier Voltage","105|V| "},
{"Percentage High Output Voltage","120|%| "},
{"Percentage Low Output Voltage","80|%| "}};

        public static string[,] arr_Controls_TSet = new string[3, 2] {
{"Off Line Operation"," | |(OFF)"},
{"Inverter Operation"," | |(OFF)"},
{"Automatic Operation"," | |(ON)"}};

        public static string Float_CurrLim = "24", Float_CurrLim_U = "A",
                     FloatV = "136", Float_U = "V",
                     Equalize_CurrLim = "25", Equalize_CurrLim_U = "A",
                     EqualizeV = "139", Equalize_U = "V"

                     ;

        private void picSTS_Click(object sender, EventArgs e)
        {
            Wait();

            //UPSpwd myPWD = new UPSpwd("TRANSFER Setting");
            //this.Hide();
            //myPWD.ShowDialog();
            //if (myPWD.lstat.Text == "YES")
            //{
            UPS_STS mymenusetting = new UPS_STS();
            this.Hide();
            mymenusetting.ShowDialog();
            //}
            this.Visible = true;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UPSMsgIN mymenusetting = new UPSMsgIN("tst");

            mymenusetting.ShowDialog();
        }

        public static void Wait()
        {
            System.Threading.Thread.Sleep(500);
        }
        private void picInverter_Click(object sender, EventArgs e)
        {
            Wait();
            UPSpwd myPWD = new UPSpwd("INVERTER");
            this.Hide();
            myPWD.ShowDialog();
            if (myPWD.lstat.Text == "YES")
            {
                UPSInverter mymenusetting = new UPSInverter();
                mymenusetting.ShowDialog();
            }
            this.Visible = true;
        }

        public static bool EqualizeON = false, FloatON = true,
                           ChngEQ_FLT = true;

        public static int  btnTXT_LEN=300;



        public UPSMain()
        {
            InitializeComponent();
        }

        private void UPSMain_Load(object sender, EventArgs e)
        {

        }

        private void picRectifier_Click(object sender, EventArgs e)
        {
           Wait();
            UPSpwd myPWD = new UPSpwd("RECTIFIER");
            this.Hide();
            myPWD.ShowDialog();
            if (myPWD.lstat.Text == "YES")
            {
               UPSRectifier  mymenusetting = new UPSRectifier();
                mymenusetting.ShowDialog();
            }
            this.Visible = true;
        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }
    }
}
