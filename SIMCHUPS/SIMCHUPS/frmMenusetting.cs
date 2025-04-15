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
    public partial class frmMenusetting : Form
    {

        string in_OV = "136.2V", in_OA = "20.1A", in_Title = "Setting";

        public frmMenusetting()
        {
            InitializeComponent();
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

        private void btnAlarms_Click(object sender, EventArgs e)
        {
            frmAlarms myAlarms = new frmAlarms ();
            this.Hide();
            myAlarms.ShowDialog();
            if (myAlarms.lstat.Text == "Q")
            {
                myAlarms.Close();
                lstat.Text = "Q";
                this.Hide();
            }
            else  this.Visible = true;
        }

        private void btnAlarms_OLD_Click(object sender, EventArgs e)
        {
            frmAlarmsOL myAlarms = new frmAlarmsOL();
            this.Hide();
            myAlarms.ShowDialog();
            if (myAlarms.lstat.Text == "Q")
            {
                myAlarms.Close();
                lstat.Text = "Q";
                this.Hide();
            }
            else this.Visible = true;
        }
        private void Others_ALRM()
        {
            frmAlarms myAlarms = new frmAlarms();
            this.Hide();
            myAlarms.ShowDialog();
            if (myAlarms.lstat.Text == "Q")
            {
                myAlarms.Close();
                lstat.Text = "Q";
                this.Hide();
            }
            else this.Visible = true;
        }
        private void btnCtrl_Click(object sender, EventArgs e)
        {
          MainM.arr_Controls[0, 1] = MainM.FloatV + "|V| ";
          MainM.arr_Controls[1, 1] = MainM.EqualizeV + "|V|" + ((MainM.ChngEQ_FLT) ? "(ON)" : "(OFF)");// MainM.EqualizeV + "|V|(OFF)";
            string[] V_btnTXT = new string[MainM.btnTXT_LEN];
            for (int i = 0; i < MainM.btnTXT_LEN; i++) V_btnTXT[i] = "*";
      //      for (int bb = 0; bb < 7; bb++) V_btnTXT[bb] = arr_Controls[bb, 0] + ":" + arr_Controls[bb, 1];
            for (int bb = 0; bb < 7; bb++) V_btnTXT[bb] = MainM.arr_Controls[bb, 0] +"|"+ MainM.arr_Controls[bb, 1];

            if (V_btnTXT[0] != " ")
            {
                frmControls myfrm = new frmControls ("Controls", V_btnTXT);
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
                    
                    this.Visible = true;
                }
            }

            btnfloat.Text = MainM.OV_value();
            btnEqua.Text = MainM.OA_value();
        }

        private void frmMenusetting_Load(object sender, EventArgs e)
        {
            btnfloat.Text = MainM.OV_value();
            btnEqua.Text = MainM.OA_value();
            button1.Text = in_Title;


        }
    }
}
