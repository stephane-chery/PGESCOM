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
   
    public partial class UPSInv_Alarms_val : Form
    {

        string stin = "", settingPWD = "1";
        public string res_Updt = "????";
        string[] in_btnTXT = new string[UPSMain.btnTXT_LEN];
        int Optcount = 24, in_NDX = 0,edit=0;
        string in_InvRec = "*";


        int Ichng = 1;

        public UPSInv_Alarms_val(string x_Title, string[] x_btntxt, int x_ndx,string x_IR)
        {
            InitializeComponent();

            btnTitle.Text  = x_Title;

            in_btnTXT = x_btntxt;
            in_NDX = x_ndx ;
            in_InvRec = x_IR;
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

        void edit_msg(string title)
        {
            UPSMsgIN myfrm = new UPSMsgIN(title);
            this.Hide();
            myfrm.ShowDialog();
            if (myfrm.lstat.Text == "Q")
            {
                lstat.Text = "Q";
                myfrm.Close();
                this.Hide();
            }
          else  this.Visible = true;
        }

   



        void Sel_Control(int selndx)
        {
            // if (selndx == 0)   //editer juste la 1er propriete
            //{
            string txt, val, unit, stat, lNewVText = "";


            if (in_btnTXT[selndx] != " ")
            {
                deco_Prop_TVUS(in_btnTXT[selndx], out txt, out val, out unit, out stat);
                switch (txt)
                {
                    case "Message":
                        edit_msg(txt);
                        break;
                    case "Logic":
                        string cur_logic = (val == "Fail Safe") ? "FS" : "NFS";
                        UPSAlarms_2Status myfrm = new UPSAlarms_2Status("Logic", "FS", "NFS", cur_logic, "Logic");
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
                                //string cur_logic = (val == "Fail Safe") ? "FS" : "NFS";
                                val = (myfrm.lnewSTAT.Text == "FS") ? "Fail Safe" : "Not Fail Safe";
                                stat = (stat != "") ? myfrm.lnewSTAT.Text : " ";
                                if (unit == "") unit = " ";
                                res_Updt = txt + "|" + val + "|" + unit + "|" + stat;
                                string res_Updt1 = " |" + val + "|" + unit + "|" + stat;
                                 in_btnTXT[selndx] = res_Updt;

                                 Update_Btns(selndx, res_Updt);

                                UPSMain.Inv_DigiInp[in_NDX, 7] = res_Updt;
                                //UPSMain.Inv_DigiInp[in_NDX, 1] = res_Updt1;
                               

                            }
                            this.Visible = true;
                        }
                        
                        break;

                    case "Alarm Common":
                        string cur_AL = (val == "(ON)") ? "ON" : "OFF";
                        UPSAlarms_2Status myfrm_AL = new UPSAlarms_2Status("Alarm Common", "ON", "OFF", cur_AL, "Disable Alarm Common");
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
                                //string cur_logic = (val == "Fail Safe") ? "FS" : "NFS";
                                val = (myfrm_AL.lnewSTAT.Text == "ON") ? "(ON)" : "(OFF)";
                                stat = (stat != "") ? myfrm_AL.lnewSTAT.Text : " ";
                                if (unit == "") unit = " ";
                                res_Updt = txt + "|" + val + "|" + unit + "|" + stat;
                                string res_Updt1 = " |" + val + "|" + unit + "|" + stat;
                                 in_btnTXT[selndx] = res_Updt;

                                 Update_Btns(selndx, res_Updt);

                                UPSMain.Inv_DigiInp[in_NDX, 8] = res_Updt;
                                //UPSMain.Inv_DigiInp[in_NDX, 1] = res_Updt1;
                            

                            }
                            this.Visible = true;
                        }
                        break;
                    case "Alarm Priority":
                        string cur_AP = (val == "Major") ? "Major" : "Minor";
                        UPSAlarms_2Status myfrm_AP = new UPSAlarms_2Status("Alarm priority", "Major", "Minor", cur_AP, "Alarm priority");
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
                                //string cur_logic = (val == "Fail Safe") ? "FS" : "NFS";
                                val = (myfrm_AP.lnewSTAT.Text == "Major") ? "Major" : "Minor";
                                stat = (stat != "") ? myfrm_AP.lnewSTAT.Text : " ";
                                if (unit == "") unit = " ";
                                res_Updt = txt + "|" + val + "|" + unit + "|" + stat;
                                string res_Updt1 = " |" + val + "|" + unit + "|" + stat;
                                in_btnTXT[selndx] = res_Updt;

                                Update_Btns(selndx, res_Updt);

                                UPSMain.Inv_DigiInp[in_NDX, 9] = res_Updt;
                                //UPSMain.Inv_DigiInp[in_NDX, 1] = res_Updt1;


                            }
                            this.Visible = true;
                        }
                        break;
                    case "DigitalActif":
                        string cur_DA = (val == "(ON)") ? "ON" : "OFF";
                        UPSAlarms_2Status myfrm_DA = new UPSAlarms_2Status("DigitalActif", "ON", "OFF", cur_DA, "Disable DigitalActif");
                        this.Hide();
                        myfrm_DA.ShowDialog();
                        if (myfrm_DA.lstat.Text == "Q")
                        {
                            lstat.Text = "Q";
                            myfrm_DA.Close();
                            this.Hide();
                        }
                        else
                        {
                            if (myfrm_DA.lstat.Text == "Y")
                            {
                                //string cur_logic = (val == "Fail Safe") ? "FS" : "NFS";
                                val = (myfrm_DA.lnewSTAT.Text == "ON") ? "(ON)" : "(OFF)";
                                stat = (stat != "") ? myfrm_DA.lnewSTAT.Text : " ";
                                if (unit == "") unit = " ";
                                res_Updt = txt + "|" + val + "|" + unit + "|" + stat;
                                string res_Updt1 = " |" + val + "|" + unit + "|" + stat;
                                in_btnTXT[selndx] = res_Updt;

                                Update_Btns(selndx, res_Updt);

                                UPSMain.Inv_DigiInp[in_NDX, 10] = res_Updt;
                                //UPSMain.Inv_DigiInp[in_NDX, 1] = res_Updt1;


                            }
                            this.Visible = true;
                        }
                        break;
                    default:
                        UPSAlarms_edit_Val myfrm_def = new UPSAlarms_edit_Val(txt, val, unit, stat);
                        this.Hide();
                        myfrm_def.ShowDialog();
                        if (myfrm_def.lstat.Text == "Q")
                        {
                            lstat.Text = "Q";
                            myfrm_def.Close();
                            this.Hide();
                        }
                        else
                        {
                            if (myfrm_def.lstat.Text == "Y")
                            {
                                val = myfrm_def.lNewV.Text;
                                stat = (stat != "") ? myfrm_def.lnewSTAT.Text : " ";
                                res_Updt = txt + "|" + val + "|" + unit + "|" + stat;
                                string res_Updt1 = " |" + val + "|" + unit + "|" + stat;
                                in_btnTXT[selndx] = res_Updt;

                                Update_Btns(selndx, res_Updt);

                                switch (in_InvRec)
                                {
                                    case "Rectifier":
                                        UPSMain.RECT_alarms[in_NDX, 2] = res_Updt;
                                        UPSMain.RECT_alarms[in_NDX, 1] = res_Updt1;
                                        break;
                                    case "Inverter":
                                        UPSMain.INV_alarms[in_NDX, 2] = res_Updt;
                                        UPSMain.INV_alarms[in_NDX, 1] = res_Updt1;
                                        break;
                                    case "Inverter Digital Input":

                                        switch (txt)
                                        {
                                            case "Function":
                                                UPSMain.Inv_DigiInp[in_NDX, 3] = res_Updt;
                                                break;
                                            case "Relay":
                                                UPSMain.Inv_DigiInp[in_NDX, 4] = res_Updt;
                                                break;
                                            case "Led":
                                                UPSMain.Inv_DigiInp[in_NDX, 5] = res_Updt;
                                                break;
                                            case "Time":
                                                UPSMain.Inv_DigiInp[in_NDX, 6] = res_Updt;
                                                break;

                                            default:
                                                UPSMain.Inv_DigiInp[in_NDX, 2] = res_Updt;
                                                UPSMain.Inv_DigiInp[in_NDX, 1] = res_Updt1;
                                                break;
                                        }
                                        break;
                                }

                            }
                            this.Visible = true;
                          
                        }
                        break;

                }


            }
        }

       

        void Update_Btns(int _btndx, string propTXT)
        {
            string Txt, val, Unit, stat;
            deco_Prop_TVUS(propTXT, out Txt, out val, out Unit, out stat);
            edit = 1;
            lstControls.Items[_btndx] = Txt + ": " + val + Unit + stat + "   ===>";
            edit = 0;

        }

        void Update_Global_arr(string txt, string val, string unit, string stat)
        {

            switch (txt)
            {

                case "Float Voltage":
                    UPSMain.FloatV = val;
                    break;
                case "Float Current Limit":
                    UPSMain.Float_CurrLim = val;
                    break;
                case "Equalize Voltage":
                    UPSMain.EqualizeV = val;
                    UPSMain.ChngEQ_FLT = (stat == "(ON)");
                    break;
                case "Equalize Current Limit":
                    UPSMain.Equalize_CurrLim = val;

                    break;
            }




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
        if (lstControls.SelectedIndex > -1 && edit ==0)    vScrollBar1.Value = lstControls.SelectedIndex * Ichng;

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

        }

        private void UPSInv_Alarms_val_Load(object sender, EventArgs e)
        {
            vScrollBar1.Maximum = 1134;
        //    btnTitle.Text =in_

      //      for (int i = 0; i < UPSMain.btnTXT_LEN; i++) in_btnTXT[i] = "*";


       //     for (int bb = 0; bb < Optcount; bb++) in_btnTXT[bb] = UPSMain.INV_alarms[bb, 0] + ":" + deco_Prop(UPSMain.INV_alarms[bb, 1]);
            fill_LIST();

            Ichng = 1134 / lstControls.Items.Count;
            vScrollBar1.LargeChange = Ichng;
            vScrollBar1.SmallChange = Ichng;
        }

        private void lstControls_Click(object sender, EventArgs e)
        {
            UPSMain.Wait();
            if (in_InvRec == "Rectifier" || in_InvRec == "Inverter" ) { if (lstControls.SelectedIndex == 0) Sel_Control(lstControls.SelectedIndex); }
            else Sel_Control(lstControls.SelectedIndex);
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
                if (in_btnTXT[_ndx] != "*")
                {
                    string Txt, val, Unit, stat;
                    deco_Prop_TVUS(in_btnTXT[_ndx], out Txt, out val, out Unit, out stat);
                    //  btn1.Text = Txt + ": " + val + Unit + stat;
                    lstControls.Items.Add(Txt + ": " + val + Unit + stat + "   ===>");
                }
            }

  
        }


    }
}
