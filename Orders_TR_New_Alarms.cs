using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PGESCOM
{
    public partial class Orders_TR_New_Alarms : Form
    {
        public Orders_TR_New_Alarms()
        {
            InitializeComponent();
        }

        /*
        private void NewST_Click(object sender, EventArgs e)
        {
            ListViewItem lvI = lv_tests.Items.Add(" ");
            for (int i = 1; i < lv_tests.Columns.Count; i++) lvI.SubItems.Add("-----");
            lvI.SubItems[5].Text = "";
            lvI.ImageIndex = 9;

            for (int i = 1; i < lv_tests.Columns.Count; i++) lv_tests.AddEditableCell(-1, i);
        }
        */

        private void _exit_Click(object sender, EventArgs e)
        {
            lSave.Text = "N";
            this.Hide();
        }

        private bool tsts_OK()
        {
            mlv_Alarms.Focus();
            bool res = false;
            for (int t = 0; t < mlv_Alarms.Items.Count; t++)
            {
                if (mlv_Alarms.Items[t].SubItems[1].Text == "-----" && mlv_Alarms.Items[t].SubItems[1].Text == "")
                    return false;
                else
                    for (int s = 2; s < 16; s++)
                        if (mlv_Alarms.Items[t].SubItems[s].Text != "-----" && mlv_Alarms.Items[t].SubItems[s].Text != "")
                        {
                            res = true;
                            s = mlv_Alarms.Columns.Count;
                            t = mlv_Alarms.Items.Count;
                        }
            }
            return res;
        }

        private void sav_Click(object sender, EventArgs e)
        {
            if (tsts_OK())
            {
                lSave.Text = "Y";
                this.Hide();
            }
            else MessageBox.Show("sorry some added alarms are invalid..!!!.");
        }

        private void toolStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void lv_tests_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void NewST_Click(object sender, EventArgs e)
        {
            ListViewItem lvI = mlv_Alarms.Items.Add(" ");
            for (int i = 1; i < mlv_Alarms.Columns.Count; i++) lvI.SubItems.Add("");
            lvI.SubItems[mlv_Alarms.Columns.Count-1].Text = "";
            lvI.SubItems[1].Text = "---------";
            lvI.ImageIndex = 9;

            for (int i = 1; i < mlv_Alarms.Columns.Count; i++) mlv_Alarms.AddEditableCell(-1, i);
        }

        private void del_Click(object sender, EventArgs e)
        {
            if (mlv_Alarms.SelectedItems.Count == 1)
            {
                mlv_Alarms.Items[mlv_Alarms.SelectedItems[0].Index].Remove();
            }
            else MessageBox.Show("please, Select Alarm...");
        }

        private void mlv_Alarmsss_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void mlv_Alarms_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}