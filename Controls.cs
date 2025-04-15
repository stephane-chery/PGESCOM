using EAHLibs;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PGESCOM
{
    public partial class Controls : Form
    {
        private Lib1 Tools = new Lib1();

        private ListViewItem lastItemChecked;

        public bool save = false;

        private string vfloat, vequal, idc;

        public Controls(string Vfloat, string Vequal, string Idc)
        {
            vfloat = Vfloat + " V";
            vequal = Vequal + " V";
            idc = Idc + " A";

            InitializeComponent();
            RemplirListView_Controls();
            InsererDonnees(vfloat, vequal, idc);
        }

        private void mnuItem_delete_Click(object sender, EventArgs e)
        {
            SupprimerControls();
            RemplirListView_Controls();
            InsererDonnees(vfloat, vequal, idc);
        }

        private void pictureBox_new_Click(object sender, EventArgs e)
        {
            listView_controls.Enabled = false;
            grpBox_controls.Visible = true;
            grpBox_button.Visible = false;
            btn_save.Visible = true;
            btn_update.Visible = false;
            //radioBtn_enableOn.Checked = false;
            //radioBtn_enableOff.Checked = false;
            lbl_enableValue.Text = "NA";
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            if (lastItemChecked != null && lastItemChecked.Checked)
            {
                save = true;
                this.Hide();
            }
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioBtn_enableOn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_enableValue.Text = "On";
        }

        private void radioBtn_enableOff_CheckedChanged(object sender, EventArgs e)
        {
            lbl_enableValue.Text = "Off";
        }

        private void listView_controls_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            lastItemChecked = listView_controls.Items[e.Index];
            if (e.NewValue == CheckState.Checked) listView_controls.Items[e.Index].BackColor = Color.Khaki;
            else listView_controls.Items[e.Index].BackColor = Color.WhiteSmoke;
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            AjouterControls();
            RemplirListView_Controls();
        }

        private void btn_cancelAddOrUpdate_Click(object sender, EventArgs e)
        {
            listView_controls.Enabled = true;
            grpBox_button.Visible = true;
            grpBox_controls.Visible = false;

            ViderInformations();
        }

        private void listView_controls_DoubleClick(object sender, EventArgs e)
        {
            if (VerifierItem())
            {
                listView_controls.Enabled = false;

                grpBox_controls.Visible = true;
                grpBox_button.Visible = false;

                btn_update.Visible = true;
                btn_save.Visible = false;

                AfficherControlInformations();
            }
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            ModifierListView_Controls();
        }

        private void RemplirListView_Controls()
        {
            string stSQL = "SELECT [pgm_controls].* FROM [pgm_controls]";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            listView_controls.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem listViewItem = listView_controls.Items.Add("");
                if (Cocher(Convert.ToInt32(Oreadr["controls_Id"].ToString())))
                {
                    listViewItem.Checked = true;
                    listViewItem.BackColor = Color.Khaki;
                }
                //listViewItem.UseItemStyleForSubItems = false;

                for (int i = 1; i < Oreadr.FieldCount; i++) listViewItem.SubItems.Add(Oreadr[i].ToString());
            }
            Oconn.Close();
        }

        private bool Cocher(int id)
        {
            if ((id == 1) || (id == 2) || (id == 3)) return true;
            return false;
        }

        private void InsererDonnees(string vfloat, string vequal, string idc)
        {
            listView_controls.Items[0].SubItems[2].Text = vfloat;
            listView_controls.Items[0].SubItems[3].Text = idc;
            listView_controls.Items[1].SubItems[2].Text = vequal;
            listView_controls.Items[1].SubItems[3].Text = idc;
        }

        private void SupprimerControls()
        {
            for (int i = listView_controls.SelectedItems.Count - 1; i > -1; i--)
            {
                int id = VerifierControls(listView_controls.SelectedItems[i]);
                if (id != 0)
                {
                    string stSQL = "DELETE FROM [pgm_controls] WHERE [pgm_controls].controls_Id = " + id;
                    MainMDI.ExecSql(stSQL);
                }
            }
        }

        private int VerifierControls(ListViewItem listViewItem)
        {
            bool verify = false;
            int id = 0;
            string stSQL = "SELECT [pgm_controls].* FROM [pgm_controls]";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                for (int i = 0; i < Oreadr.FieldCount; i++)
                {
                    if (i != 0)
                    {
                        if (Oreadr[i].ToString() == listViewItem.SubItems[i].Text) verify = true;
                        if ((i == Oreadr.FieldCount - 1) && verify) id = Convert.ToInt32(Oreadr["controls_Id"].ToString());
                    }
                }
            }
            Oconn.Close();

            return id;
        }

        private void AjouterControls()
        {
            string stSQL = "INSERT INTO [pgm_controls] ([pgm_controls].controls_Description, [pgm_controls].controls_Adjust1, " + 
                "[pgm_controls].controls_Adjust2, [pgm_controls].controls_Delay, [pgm_controls].controls_EqualizeDuration, " + 
                "[pgm_controls].controls_Enable) VALUES ('" + 
                txtBox_description.Text + "', '" + 
                txtBox_adjust1.Text + "', '" + 
                txtBox_adjust2.Text + "', '" + 
                txtBox_delay.Text + "', '" + 
                txtBox_equalizeDuration.Text + "', '" + 
                lbl_enableValue.Text + "')";
            MainMDI.ExecSql(stSQL);
        }

        private void ViderInformations()
        {
            txtBox_description.Text = "";
            txtBox_adjust1.Text = "";
            txtBox_adjust2.Text = "";
            txtBox_delay.Text = "";
            txtBox_equalizeDuration.Text = "";

            radioBtn_enableOn.Checked = false;
            radioBtn_enableOff.Checked = false;

            lbl_enableValue.Text = "NA";
        }

        private void AfficherControlInformations()
        {
            txtBox_description.Text = listView_controls.SelectedItems[0].SubItems[1].Text;
            txtBox_adjust1.Text = listView_controls.SelectedItems[0].SubItems[2].Text;
            txtBox_adjust2.Text = listView_controls.SelectedItems[0].SubItems[3].Text;
            txtBox_delay.Text = listView_controls.SelectedItems[0].SubItems[4].Text;
            txtBox_equalizeDuration.Text = listView_controls.SelectedItems[0].SubItems[5].Text;

            if (listView_controls.SelectedItems[0].SubItems[6].Text.ToLower() == "on") radioBtn_enableOn.Checked = true;
            else if (listView_controls.SelectedItems[0].SubItems[6].Text.ToLower() == "off") radioBtn_enableOff.Checked = true;
        }

        private bool VerifierItem()
        {
            if (listView_controls.SelectedItems.Count == 0) return false;
            if (listView_controls.SelectedItems[listView_controls.SelectedItems.Count - 1].Checked) return true;
            return false;
        }

        private void ModifierListView_Controls()
        {
            listView_controls.SelectedItems[0].SubItems[1].Text = txtBox_description.Text;
            listView_controls.SelectedItems[0].SubItems[2].Text = txtBox_adjust1.Text;
            listView_controls.SelectedItems[0].SubItems[3].Text = txtBox_adjust2.Text;
            listView_controls.SelectedItems[0].SubItems[4].Text = txtBox_delay.Text;
            listView_controls.SelectedItems[0].SubItems[5].Text = txtBox_equalizeDuration.Text;
            listView_controls.SelectedItems[0].SubItems[6].Text = lbl_enableValue.Text;
        }
    }
}
