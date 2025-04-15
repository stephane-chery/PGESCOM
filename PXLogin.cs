using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace PGESCOM
{
    public partial class PXLogin : Form
    {

        string in_Usr = "";
        int nbR = 0;

        public PXLogin(string x_Usr)
        {
            in_Usr = x_Usr;
     
            InitializeComponent();
        }

        private void PXLogin_Load(object sender, EventArgs e)
        {
            txUser.Text = in_Usr;
            //txUser.ReadOnly = true;
            nbR = 0;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (txPass.Text.Length > 0)
            {
                string msg = "";
                if (MainMDI.USR_PWD_WINSERVER(txUser.Text, txPass.Text, ref msg))
                {
                    lYN.Text = "Y";
                    this.Hide();
                }
                else
                {
                    lYN.Text = "N";
                    MessageBox.Show("Wrong password .....!!!");
                    txPass.Focus();
                }
                if (nbR++ >= 2 && lYN.Text == "N") this.Hide(); 
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

    }
}