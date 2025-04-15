using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace PGESCOM
{
    public partial class Order_TR_SPT : Form
    {
        public Order_TR_SPT()
        {
            InitializeComponent();
        }

        private void NewST_Click(object sender, EventArgs e)
        {
            ListViewItem lvI =lv_tests.Items.Add (" ")  ;
            for (int i = 1; i < lv_tests.Columns.Count; i++) lvI.SubItems.Add("-----");
            lvI.SubItems[5].Text  = "";
            lvI.ImageIndex = 9;
           
            for (int i = 1; i < lv_tests.Columns.Count; i++)  lv_tests.AddEditableCell(-1, i);
        }

        private void _exit_Click(object sender, EventArgs e)
        {
            lSave.Text = "N";
            this.Hide();
        }
        private bool tsts_OK()
        {
            lv_tests.Focus(); 
            bool res=true;
            for (int t=0;t<lv_tests.Items.Count ;t++)
                for (int s=1;s<4 ;s++)
                    if (lv_tests.Items[t].SubItems[s].Text == "-----" || lv_tests.Items[t].SubItems[s].Text == "")
                    {
                        res = false;
                        s = lv_tests.Columns.Count;
                        t = lv_tests.Items.Count;
                        MessageBox.Show("sorry test(s) added are invalid..."); 
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
            
        }

        private void del_Click(object sender, EventArgs e)
        {
            if (lv_tests.SelectedItems.Count == 1)
            {
                lv_tests.Items[lv_tests.SelectedItems[0].Index].Remove();

            }
            else MessageBox.Show("Select line test...."); 
        }




    }
}