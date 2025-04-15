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
    public partial class UPS_maker : Form
    {
        public UPS_maker()
        {
            InitializeComponent();
        }

        private void opbattK_CheckedChanged(object sender, EventArgs e)
        {
            pnlBCap.Visible = opbattK.Checked;
            pnl_kw.Visible = !opbattK.Checked;

   
   
           
        }

        private void opbattU_CheckedChanged(object sender, EventArgs e)
        {
            pnlBCap.Enabled = !opbattU.Checked;
            pnl_kw.Enabled = opbattU.Checked;
            //if (opbattU.Checked)
            //{
            //    grp0.Enabled = false;
            //    pnl_kw.Enabled = true;
            //}
            //else
            //{
            //    grp0.Enabled = true;
            //    pnl_kw.Enabled = false;
            //}
        }

        private void txKVA_TextChanged(object sender, EventArgs e)
        {
          //  txPOut.Text =ToolStrip.
        }

        private void UPS_maker_Load(object sender, EventArgs e)
        {
            cbmodels.SelectedIndex = 0;
            cbphs.SelectedIndex = 0;
            cbVacout.SelectedIndex = 0;
            cbvdc.SelectedIndex = 0;
        }
    }
}
