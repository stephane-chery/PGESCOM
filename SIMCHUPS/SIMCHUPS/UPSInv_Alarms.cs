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
   
    public partial class UPSInv_Alarms : Form
    {

        string stin = "", settingPWD = "1", in_title="Controls";
        string[] in_btnTXT = new string[UPSMain.btnTXT_LEN];
        int Optcount = 24,edit=0,nbOPT=12;

        string[] V_btnTXT = new string[UPSMain.btnTXT_LEN];

        int Ichng = 1;
        public UPSInv_Alarms(string x_title)
        {
            InitializeComponent();
            in_title = x_title;
            btnTitle.Text = in_title;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            lstat.Text = "N";
            this.Hide();
         
        }

        private void btnX_Click(object sender, EventArgs e)
        {
            
        }

        private void btnRET_Click(object sender, EventArgs e)
        {
            lstat.Text = "C";
            this.Hide();
        }

  

    

      
       
        private void btnX_Click_1(object sender, EventArgs e)
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

        private void btnYes_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            if (e.OldValue == e.NewValue)
            {

                int ndx = lstControls.SelectedIndex;
            }
            else
            {
                if (e.OldValue > e.NewValue)
                {
                    //  selectBTN_UP();
                    if (lstControls.SelectedIndex ==0) lstControls.SelectedIndex = 0;
                    else lstControls.SelectedIndex--;

                }
                else
                {
                    // selectBTN_DOWN();
                    if ((lstControls.SelectedIndex + 1) == lstControls.Items.Count) lstControls.SelectedIndex = lstControls.Items.Count - 1;
                    else lstControls.SelectedIndex++;
                }

            }
           // label2.Text = e.NewValue.ToString(); 
        }

        string deco_Prop(string stPro)
        {
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
                else msg = " " + st;
                if (res == "????") { i = 4; res = ""; }
                if (msg != " " && i < 4) res += msg;

            }


            return res;
        }
        void Sel_Control(int _ndx)
        {

            string title = "";
            for (int i = 0; i < UPSMain.btnTXT_LEN; i++) V_btnTXT[i] = "*";
            switch (in_title)
            {
                case "Rectifier":
                    nbOPT = 12;
                    for (int bb = 2, v = 0; bb < nbOPT; bb++, v++) V_btnTXT[v] = UPSMain.RECT_alarms[_ndx, bb];
                    title = UPSMain.RECT_alarms[_ndx, 0];
                    break;
                case "Inverter":
                    nbOPT = 12;
                    for (int bb = 2, v = 0; bb < nbOPT; bb++, v++) V_btnTXT[v] = UPSMain.INV_alarms[_ndx, bb];
                    title=UPSMain.INV_alarms[_ndx, 0];
                    break;
                case "Inverter Digital Input":
                    nbOPT = 11;
                    for (int bb = 2, v = 0; bb < nbOPT; bb++, v++) V_btnTXT[v] = UPSMain.Inv_DigiInp[_ndx, bb];
                    title = UPSMain.Inv_DigiInp[_ndx, 0];
                    break;

            }

     
            if (V_btnTXT[0] != " ")
            {
                UPSInv_Alarms_val myfrm = new UPSInv_Alarms_val(title, V_btnTXT,_ndx,in_title);
                this.Hide();
                myfrm.ShowDialog();
                if (myfrm.lstat.Text == "Q")
                {
                    lstat.Text = "Q";
                    this.Hide();
                }
                else
                {
                   // btnTXT[0] = MainM.alarmsPart1[curr_XPTR, 0] + ":" + deco_Prop(MainM.alarmsPart1[curr_XPTR, 1]);
                  if (myfrm.res_Updt!="????" && in_title != "Inverter Digital Input") Update_Btns(_ndx,myfrm.res_Updt );
                    this.Visible = true;
                }
                myfrm.Close();
            }

        }

        void Update_Btns(int _btndx, string propTXT)
        {
            string Txt, val, Unit, stat;
            deco_Prop_TVUS(propTXT, out Txt, out val, out Unit, out stat);
            edit = 1;
            lstControls.Items[_btndx] = Txt + ":  " + val + Unit + stat + "   ===>";
            edit = 0;

        }


        void ref_List()
        {
            UPSMain.arr_Controls[0, 1] = UPSMain.FloatV + "|V| ";
            UPSMain.arr_Controls[1, 1] = UPSMain.EqualizeV + "|V|" + ((UPSMain.ChngEQ_FLT) ? "(ON)" : "(OFF)");// UPSMain.EqualizeV + "|V|(OFF)";
            for (int i = 0; i < UPSMain.btnTXT_LEN; i++) in_btnTXT[i] = "*";
            for (int bb = 0; bb < 7; bb++) in_btnTXT[bb] = UPSMain.arr_Controls[bb, 0] + "|" + UPSMain.arr_Controls[bb, 1];
            fill_LIST();
        }
        private void lstControls_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  label1.Text = lstControls.SelectedIndex.ToString();
         if (lstControls.SelectedIndex > -1 &&  edit ==0)   vScrollBar1.Value = lstControls.SelectedIndex * Ichng;

         //   Sel_Control(lstControls.SelectedIndex);

        }

        private void pictureBox8_Click(object sender, EventArgs e)
        {

        }

        private void btnstar_Click(object sender, EventArgs e)
        {

        }

        private void UPSControls_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
        }

        private void UPSAlarms_Inv_Load(object sender, EventArgs e)
        {
            vScrollBar1.Maximum = 1134;



            //UPSMain.arr_Controls[0, 1] = UPSMain.FloatV + "|V| ";
            //UPSMain.arr_Controls[1, 1] = UPSMain.EqualizeV + "|V|" + ((UPSMain.ChngEQ_FLT) ? "(ON)" : "(OFF)");// UPSMain.EqualizeV + "|V|(OFF)";
            //string[] V_btnTXT = new string[UPSMain.btnTXT_LEN];



            for (int i = 0; i < UPSMain.btnTXT_LEN; i++) in_btnTXT[i] = "*";

            switch (in_title)
            {


                case "Inverter":
                    Optcount = 24;
                    for (int bb = 0; bb < Optcount; bb++) in_btnTXT[bb] = UPSMain.INV_alarms[bb, 0] + ":  " + deco_Prop(UPSMain.INV_alarms[bb, 1]);

                    break;
                case "Rectifier":
                    Optcount = 35;
                    for (int bb = 0; bb < Optcount; bb++) in_btnTXT[bb] = UPSMain.RECT_alarms[bb, 0] + ":  " + deco_Prop(UPSMain.RECT_alarms[bb, 1]);

                    break;
                case "Inverter Digital Input":
                    Optcount = 15;
                    for (int bb = 0; bb < Optcount; bb++) in_btnTXT[bb] = UPSMain.Inv_DigiInp[bb, 0] + ":  " + deco_Prop(UPSMain.Inv_DigiInp[bb, 1]);

                    break;

            }

     
            fill_LIST();

            Ichng = 1134 / lstControls.Items.Count;
            vScrollBar1.LargeChange = Ichng;
            vScrollBar1.SmallChange = Ichng;
        }

        private void lstControls_Click(object sender, EventArgs e)
        {
            UPSMain.Wait();
         if (lstControls.SelectedIndex>-1)   Sel_Control(lstControls.SelectedIndex);
        }

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

        void fill_LIST()
        {
            lstControls.Items.Clear();

            for (int _ndx = 0; _ndx < Optcount; _ndx++)
            {
                //   string Txt, val, Unit, stat;
                //  deco_Prop_TVUS(in_btnTXT[_ndx], out Txt, out val, out Unit, out stat);

                lstControls.Items.Add(in_btnTXT[_ndx] + "   ===>");
            }


        }
        void fill_LISTold()
        {

            for (int i = 0; i < UPSMain.btnTXT_LEN; i++) in_btnTXT[i] = "*";

            switch (in_title)
            {

                case "Inverter":
                    Optcount = 24;
                    for (int bb = 0; bb < Optcount; bb++) in_btnTXT[bb] = UPSMain.INV_alarms[bb, 0] + ":" + deco_Prop(UPSMain.INV_alarms[bb, 1]);

                    break;
                case "Rectifier":
                    Optcount = 35;
                    for (int bb = 0; bb < Optcount; bb++) in_btnTXT[bb] = UPSMain.RECT_alarms[bb, 0] + ":" + deco_Prop(UPSMain.RECT_alarms[bb, 1]);

                    break;
                case "Transfer Parameters":
                    Optcount = 9;
                    for (int bb = 0; bb < Optcount; bb++) in_btnTXT[bb] = UPSMain.RECT_alarms[bb, 0] + ":" + deco_Prop(UPSMain.RECT_alarms[bb, 1]);

                    break;


            }

            lstControls.Items.Clear();  

            for (int _ndx = 0; _ndx < Optcount; _ndx++)
            {
                lstControls.Items.Add(in_btnTXT[_ndx] +"   ===>");
            }

  
        }


    }
}
