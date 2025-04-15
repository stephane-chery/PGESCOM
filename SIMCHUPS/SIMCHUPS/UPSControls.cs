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
   
    public partial class UPSControls : Form
    {

        string stin = "", settingPWD = "1", in_title="",title="";
        string[] in_btnTXT = new string[UPSMain.btnTXT_LEN];
        int Ctrlscount = 0;bool edit = false;



        int Ichng = 1;
        public UPSControls(string x_title)
        {
            InitializeComponent();
            in_title = x_title;
           
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

        private void UPSControls_Load(object sender, EventArgs e)
        {

            vScrollBar1.Maximum = 1134;



            //UPSMain.arr_Controls[0, 1] = UPSMain.FloatV + "|V| ";
            //UPSMain.arr_Controls[1, 1] = UPSMain.EqualizeV + "|V|" + ((UPSMain.ChngEQ_FLT) ? "(ON)" : "(OFF)");// UPSMain.EqualizeV + "|V|(OFF)";
            //string[] V_btnTXT = new string[UPSMain.btnTXT_LEN];

            btnTitle.Text = in_title;

            fill_btnTXT();
            fill_LIST();

            Ichng = 1134 / lstControls.Items.Count;
            vScrollBar1.LargeChange = Ichng;
            vScrollBar1.SmallChange = Ichng;

        }
        void fill_btnTXT()
        {

            for (int i = 0; i < UPSMain.btnTXT_LEN; i++) in_btnTXT[i] = "*";
            switch (in_title)
            {
                case "Controls":
                    Ctrlscount = 7;
                    for (int bb = 0; bb < Ctrlscount; bb++) in_btnTXT[bb] = UPSMain.arr_Controls[bb, 0] + "|" + UPSMain.arr_Controls[bb, 1];
                    break;
                case "Transfer Parameters":
                    Ctrlscount = 9;
                    for (int bb = 0; bb < Ctrlscount; bb++) in_btnTXT[bb] = UPSMain.arr_Controls_TP[bb, 0] + "|" + UPSMain.arr_Controls_TP[bb, 1];
                    break;
                case "Transfer Settings":
                    Ctrlscount = 3;
                    for (int bb = 0; bb < Ctrlscount; bb++) in_btnTXT[bb] = UPSMain.arr_Controls_TSet[bb, 0] + "|" + UPSMain.arr_Controls_TSet[bb, 1];
                    break;

            }
           
        }
        void Sel_Control(int ndx)
        {

            //for (int i = 0; i < UPSMain.btnTXT_LEN; i++) in_btnTXT[i] = "*";
            string[] V_btnTXT = new string[UPSMain.btnTXT_LEN];
            if (in_title == "Controls")
            {
                title = "";
                switch (ndx)
                {

                    case 0:
                        V_btnTXT[0] = "Float Voltage|" + UPSMain.FloatV + "|V| ";
                        V_btnTXT[1] = "Float Current Limit|" + UPSMain.Float_CurrLim + "|AMP| ";
                        title = "Float";

                        break;
                    case 1:
                        V_btnTXT[0] = "Equalize Voltage|" + UPSMain.EqualizeV + "|V|" + ((UPSMain.ChngEQ_FLT) ? "(ON)" : "(OFF)");
                        V_btnTXT[1] = "Equalize Current Limit|" + UPSMain.Equalize_CurrLim + "|AMP| ";
                        title = "Equalize";

                        break;
                }
            }
            else
            {
                title = "";
                Edit_Control_values(ndx);
            }


            // for (int bb = 2, v = 0; bb < 12; bb++, v++) V_btnTXT[v] = UPSMain.alarmsPart1[curr_XPTR, bb];
            if (title != "")
            {
                UPSOption2_5_values myfrm = new UPSOption2_5_values("Controls Values", title, V_btnTXT, 2);
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
                    //  btnTXT[0] = UPSMain.alarmsPart1[curr_XPTR, 0] + ":" + deco_Prop(UPSMain.alarmsPart1[curr_XPTR, 1]);
                    //    update_Btns(b);
                    this.Visible = true;
                    ref_List();
                }
            }


        }



        void Edit_Control_values(int selndx)
        {

            string txt, val, unit, stat,frm_lstat="";
            if (in_btnTXT[selndx] != " ")
            {
                deco_Prop_TVUS(in_btnTXT[selndx], out txt, out val, out unit, out stat);

                //   frmAlarms_edit_Val myfrm = new frmAlarms_edit_Val(in_Title, val, unit, stat);
                if (val != "" || unit != "")
                {
                    //  
                    UPSAlarms_edit_Val myfrmEdit = new UPSAlarms_edit_Val(txt, val, unit, stat);
                    this.Hide();
                    myfrmEdit.ShowDialog();
                    frm_lstat = myfrmEdit.lstat.Text;
                    val = myfrmEdit.lNewV.Text;
                    stat = (stat != "") ? myfrmEdit.lnewSTAT.Text : " ";

                    myfrmEdit.Close();

                }
                else
                {
                    UPSAlarms_ONOFF myfrmEdit = new UPSAlarms_ONOFF(txt, stat);
                    this.Hide();
                    myfrmEdit.ShowDialog();
                    frm_lstat = myfrmEdit.lstat.Text;
                    //val = myfrmEdit.lNewV.Text;
                    stat = (stat != "") ? myfrmEdit.lnewSTAT.Text : " ";
                    myfrmEdit.Close();
                }
                if (frm_lstat == "Q")
                {
                    lstat.Text = "Q";
                    this.Hide();
                }
                else
                {
                    if (frm_lstat == "Y")
                    {
                        string res_Updt = txt + "|" + val + "|" + unit + "|" + stat;
                        in_btnTXT[selndx] = res_Updt;
                        Update_Btns(selndx, res_Updt);

                        if (in_title == "Transfer Parameters") UPSMain.arr_Controls_TP[selndx, 1] = val + "|" + unit + "|" + stat;
                        else UPSMain.arr_Controls_TSet[selndx, 1] = val + "|" + unit + "|" + stat;
                    }
                    this.Visible = true;
                }
            }

        }


        void Update_Btns(int _btndx, string propTXT)
        {
            edit = true;
            string Txt, val, Unit, stat;
            deco_Prop_TVUS(propTXT, out Txt, out val, out Unit, out stat);
            lstControls.Items[_btndx] = Txt + ": " + val + Unit + stat + "   ===>";
            edit =false;
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
            UPSMain.Wait();
            //  label1.Text = lstControls.SelectedIndex.ToString();
              if (lstControls.SelectedIndex>-1 && !edit )    vScrollBar1.Value = lstControls.SelectedIndex * Ichng;

          //  Sel_Control(lstControls.SelectedIndex);

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

        private void lstControls_Click(object sender, EventArgs e)
        {
            UPSMain.Wait();
          if (lstControls.SelectedIndex>-1)  Sel_Control(lstControls.SelectedIndex);
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

            for (int _ndx = 0; _ndx < Ctrlscount; _ndx++)
            {
                string Txt, val, Unit, stat;
                deco_Prop_TVUS(in_btnTXT[_ndx], out Txt, out val, out Unit, out stat);

                lstControls.Items.Add(Txt + ": " + val + Unit + stat + "   ===>");
            }

  
        }


    }
}
