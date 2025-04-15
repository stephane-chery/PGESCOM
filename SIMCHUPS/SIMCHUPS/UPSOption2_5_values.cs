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
   
    public partial class UPSOption2_5_values : Form
    {

        string stin = "", settingPWD = "1", title="Controls";
        string[] in_btnTXT = new string[UPSMain.btnTXT_LEN];
        int Ctrlscount = 0,edit=0;

        string in_FormTitle = "", in_Title = "------";
        int cntr = 1, curr_Selbtn = 0, curr_TXTndx = -1, OLD_Scroll = -1, NEW_Scroll = -1, Ichng = 0, curr_XPTR = 0, in_Alrms_II = -1, in_nbOpt = 0, in_codCTRL = 0,
            txtPTRb1 = -1, txtPTRb2 = -1, txtPTRb3 = -1, txtPTRb4 = -1, txtPTRb5 = -1;

        private void lstControls_Click(object sender, EventArgs e)
        {
            UPSMain.Wait();
          if (lstControls.SelectedIndex>-1)  Edit_Control_values(lstControls.SelectedIndex);
        }

        private void UPSOption2_5_values_Load(object sender, EventArgs e)
        {
            vScrollBar1.Maximum = 1134;

            fill_LIST();
            edit = 0;
            Ichng = 1134 / lstControls.Items.Count;
            vScrollBar1.LargeChange = Ichng;
            vScrollBar1.SmallChange = Ichng;
        }


        //   int Ichng = 1;
        public UPSOption2_5_values(string x_formTitle, string x_Title, string[] x_btntxt, int x_nbOpt)
        {
            InitializeComponent();
            in_FormTitle = x_formTitle;
            in_Title = x_Title;
            in_btnTXT = x_btntxt;
            Ctrlscount = x_nbOpt;
            this.Text = x_formTitle;
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






        }

        void Edit_Control_values(int selndx)
        {

            string txt, val, unit, stat;
            if (in_btnTXT[selndx] != " ")
            {
                deco_Prop_TVUS(in_btnTXT[selndx], out txt, out val, out unit, out stat);

                //   frmAlarms_edit_Val myfrm = new frmAlarms_edit_Val(in_Title, val, unit, stat);
                UPSAlarms_edit_Val myfrm = new UPSAlarms_edit_Val(txt , val, unit, stat);
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

                        Update_Btns(selndx, res_Updt);

                        //update global array
                        Update_Global_arr(txt, val, unit, stat);
                        

                      //   UPSMain.alarmsPart1[in_Alrms_II, 2 + curr_XPTR] = res_Updt;
                        //   UPSMain.alarmsPart1[in_Alrms_II, 1 + curr_XPTR] = " |" + val + "|" + unit + "|" + stat;
                    }
                    this.Visible = true;
                }
               
            }

        }


        void Update_Btns(int _btndx, string propTXT)
        {
            edit = 1;
            string Txt, val, Unit, stat;
            deco_Prop_TVUS(propTXT, out Txt, out val, out Unit, out stat);
            lstControls.Items[_btndx ] = Txt + ": " + val + Unit + stat + "   ===>";
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

        private void lstControls_SelectedIndexChanged(object sender, EventArgs e)
        {
            //  label1.Text = lstControls.SelectedIndex.ToString();
            //if (opera == 0)
            //{
            //if (opera == 0)    vScrollBar1.Value = lstControls.SelectedIndex * Ichng;
            // Edit_Control_values(lstControls.SelectedIndex);
            // }

            if (lstControls.SelectedIndex > -1 && edit == 0)    vScrollBar1.Value = lstControls.SelectedIndex * Ichng;

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
                if (in_btnTXT[_ndx] != "*")
                {
                    deco_Prop_TVUS(in_btnTXT[_ndx], out Txt, out val, out Unit, out stat);

                    lstControls.Items.Add(Txt + ": " + val + Unit + stat + "   ===>");
                }
                else _ndx = Ctrlscount;
            }

  
        }


    }
}
