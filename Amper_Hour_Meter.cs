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
    public partial class Amper_Hour_Meter : Form
    {
        public bool save = false;

        public Amper_Hour_Meter()
        {
            InitializeComponent();
            AfficherDefaultAmperHourParameters();
            RemplirListView_BatteryAndContinuityTest();
        }

        private void mnuItem_delete_Click(object sender, EventArgs e)
        {
            SupprimerBatteryContinuityTest();
            RemplirListView_BatteryAndContinuityTest();
        }

        private void pictureBox_new_Click(object sender, EventArgs e)
        {
            listView_batteryAndContinuityTest.Enabled = false;

            grpBox_batteryAndContinuityTest.Visible = true;
            grpBox_button.Visible = false;

            btn_save.Visible = true;
            btn_update.Visible = false;
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            save = true;
            this.Hide();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioBtn_autoCeffOn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_autoCeffValue.Text = "On";
        }

        private void radioBtn_autoCeffOff_CheckedChanged(object sender, EventArgs e)
        {
            lbl_autoCeffValue.Text = "Off";
        }

        private void radioBtn_enableOn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_enableValue.Text = "On";
        }

        private void radioBtn_enableOff_CheckedChanged(object sender, EventArgs e)
        {
            lbl_enableValue.Text = "Off";
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            AjouterBatteryContinuityTest();
            RemplirListView_BatteryAndContinuityTest();
        }

        private void btn_cancelAddOrUpdate_Click(object sender, EventArgs e)
        {
            ViderInformations();

            listView_batteryAndContinuityTest.Enabled = true;

            grpBox_button.Visible = true;
            grpBox_batteryAndContinuityTest.Visible = false;
        }

        private void listView_batteryAndContinuityTest_DoubleClick(object sender, EventArgs e)
        {
            listView_batteryAndContinuityTest.Enabled = false;

            grpBox_button.Visible = false;
            grpBox_batteryAndContinuityTest.Visible = true;

            btn_save.Visible = false;
            btn_update.Visible = true;

            AfficherBatteryAndContinuityTestInformations();
        }

        private void radioBtn_commonOn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_commonValue.Text = "On";
        }

        private void radioBtn_commonOff_CheckedChanged(object sender, EventArgs e)
        {
            lbl_commonValue.Text = "Off";
        }

        private void radioBtn_learningOn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_learningValue.Text = "On";
        }

        private void radioBtn_learningOff_CheckedChanged(object sender, EventArgs e)
        {
            lbl_learningValue.Text = "Off";
        }

        private void radioBtn_enableOn_batteryAndContinuityTest_CheckedChanged(object sender, EventArgs e)
        {
            lbl_enableBatteryAndContinuityTestValue.Text = "On";
        }

        private void radioBtn_enableOff_batteryAndContinuityTest_CheckedChanged(object sender, EventArgs e)
        {
            lbl_enableBatteryAndContinuityTestValue.Text = "Off";
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            ModifierListView_BatteryAndContinuityTest();
        }

        private void AfficherDefaultAmperHourParameters()
        {
            txtBox_batteryCapacity.Text = "200";
            txtBox_vcharge.Text = "136";
            txtBox_icharge.Text = "5";
            txtBox_tcharge.Text = "30";
            txtBox_peukert.Text = "1,25";
            txtBox_ceff.Text = "85";
            txtBox_iilter.Text = "0,1";
            txtBox_c_n.Text = "20";

            radioBtn_autoCeffOn.Checked = true;
            radioBtn_enableOff.Checked = true;
        }

        private void RemplirListView_BatteryAndContinuityTest()
        {
            string stSQL = "SELECT [pgm_batteryContinuityTest].* FROM [pgm_batteryContinuityTest]";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            listView_batteryAndContinuityTest.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem listViewItem = listView_batteryAndContinuityTest.Items.Add("");
                listViewItem.UseItemStyleForSubItems = false;
                for (int i = 1; i < Oreadr.FieldCount; i++) listViewItem.SubItems.Add(Oreadr[i].ToString());
            }
            Oconn.Close();
        }

        private void SupprimerBatteryContinuityTest()
        {
            for (int i = listView_batteryAndContinuityTest.SelectedItems.Count - 1; i > -1; i--)
            {
                int id = VerifierBatteryContinuityTest(listView_batteryAndContinuityTest.SelectedItems[i]);
                if (id != 0)
                {
                    string stSQL = "DELETE FROM [pgm_batteryContinuityTest] WHERE [pgm_batteryContinuityTest].batteryContinuityTest_ID=" + id;
                    MainMDI.ExecSql(stSQL);
                }
            }
        }

        private int VerifierBatteryContinuityTest(ListViewItem listViewItem)
        {
            int id = 0;
            bool verify = false;
            string stSQL = "SELECT [pgm_batteryContinuityTest].* FROM [pgm_batteryContinuityTest]";
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
                        if ((i == Oreadr.FieldCount - 1) && verify) id = Convert.ToInt32(Oreadr["batteryContinuityTest_ID"].ToString());
                    }
                }
            }
            Oconn.Close();

            return id;
        }

        private void AjouterBatteryContinuityTest()
        {
            string stSQL = "INSERT INTO [pgm_batteryContinuityTest] ([pgm_batteryContinuityTest].batteryContinuityTest_Description, " +
                "[pgm_batteryContinuityTest].batteryContinuityTest_Mode, [pgm_batteryContinuityTest].batteryContinuityTest_Vsecurity, " +
                "[pgm_batteryContinuityTest].batteryContinuityTest_AH_Range, [pgm_batteryContinuityTest].batteryContinuityTest_dAH_Range, " +
                "[pgm_batteryContinuityTest].batteryContinuityTest_Vtest, [pgm_batteryContinuityTest].batteryContinuityTest_Itest, " +
                "[pgm_batteryContinuityTest].batteryContinuityTest_Time, [pgm_batteryContinuityTest].batteryContinuityTest_Delay, " +
                "[pgm_batteryContinuityTest].batteryContinuityTest_Cycle, [pgm_batteryContinuityTest].batteryContinuityTest_EqTime, " +
                "[pgm_batteryContinuityTest].batteryContinuityTest_TestRelay, [pgm_batteryContinuityTest].batteryContinuityTest_DefaultRelay, " +
                "[pgm_batteryContinuityTest].batteryContinuityTest_DefaultLed, [pgm_batteryContinuityTest].batteryContinuityTest_Logic, " +
                "[pgm_batteryContinuityTest].batteryContinuityTest_Common, [pgm_batteryContinuityTest].batteryContinuityTest_Priority, " +
                "[pgm_batteryContinuityTest].batteryContinuityTest_Learning, [pgm_batteryContinuityTest].batteryContinuityTest_Enable) " + 
                "VALUES ('" +
                txtBox_description.Text + "', '" +
                txtBox_mode.Text + "', '" +
                txtBox_vsecurity.Text + "', '" +
                txtBox_amperHourRange.Text + "', '" +
                txtBox_d_amperHourRange.Text + "', '" +
                txtBox_vtest.Text + "', '" +
                txtBox_itest.Text + "', '" +
                txtBox_time.Text + "', '" +
                txtBox_delay.Text + "', '" +
                txtBox_cycle.Text + "', '" +
                txtBox_equalizerTime.Text + "', '" +
                txtBox_testRelay.Text + "', '" +
                txtBox_defaultRelay.Text + "', '" +
                txtBox_defaultLed.Text + "', '" +
                txtBox_logic.Text + "', '" +
                lbl_commonValue.Text + "', '" +
                txtBox_priority.Text + "', '" +
                lbl_learningValue.Text + "', '" +
                lbl_enableBatteryAndContinuityTestValue.Text + "')";
            MainMDI.ExecSql(stSQL);
        }

        private void ViderInformations()
        {
            txtBox_description.Clear();
            txtBox_mode.Clear();
            txtBox_vsecurity.Clear();
            txtBox_amperHourRange.Clear();
            txtBox_d_amperHourRange.Clear();
            txtBox_vtest.Clear();
            txtBox_itest.Clear();
            txtBox_time.Clear();
            txtBox_delay.Clear();
            txtBox_cycle.Clear();
            txtBox_equalizerTime.Clear();
            txtBox_testRelay.Clear();
            txtBox_defaultRelay.Clear();
            txtBox_defaultLed.Clear();
            txtBox_logic.Clear();
            txtBox_priority.Clear();

            radioBtn_commonOn.Checked = false;
            radioBtn_commonOff.Checked = false;
            radioBtn_learningOn.Checked = false;
            radioBtn_learningOff.Checked = false;
            radioBtn_enableOn_batteryAndContinuityTest.Checked = false;
            radioBtn_enableOff_batteryAndContinuityTest.Checked = false;

            lbl_commonValue.Text = "na";
            lbl_learningValue.Text = "na";
            lbl_enableBatteryAndContinuityTestValue.Text = "na";
        }

        private void AfficherBatteryAndContinuityTestInformations()
        {
            txtBox_description.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[1].Text;
            txtBox_mode.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[2].Text;
            txtBox_vsecurity.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[3].Text;
            txtBox_amperHourRange.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[4].Text;
            txtBox_d_amperHourRange.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[5].Text;
            txtBox_vtest.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[6].Text;
            txtBox_itest.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[7].Text;
            txtBox_time.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[8].Text;
            txtBox_delay.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[9].Text;
            txtBox_cycle.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[10].Text;
            txtBox_equalizerTime.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[11].Text;
            txtBox_testRelay.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[12].Text;
            txtBox_defaultRelay.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[13].Text;
            txtBox_defaultLed.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[14].Text;
            txtBox_logic.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[15].Text;

            if (listView_batteryAndContinuityTest.SelectedItems[0].SubItems[16].Text.ToLower() == "on") radioBtn_commonOn.Checked = true;
            else if (listView_batteryAndContinuityTest.SelectedItems[0].SubItems[16].Text.ToLower() == "off") radioBtn_commonOff.Checked = true;

            txtBox_priority.Text = listView_batteryAndContinuityTest.SelectedItems[0].SubItems[17].Text;

            if (listView_batteryAndContinuityTest.SelectedItems[0].SubItems[18].Text.ToLower() == "on") radioBtn_learningOn.Checked = true;
            else if (listView_batteryAndContinuityTest.SelectedItems[0].SubItems[18].Text.ToLower() == "off") radioBtn_learningOff.Checked = true;

            if (listView_batteryAndContinuityTest.SelectedItems[0].SubItems[19].Text.ToLower() == "on")
                radioBtn_enableOn_batteryAndContinuityTest.Checked = true;
            else if (listView_batteryAndContinuityTest.SelectedItems[0].SubItems[19].Text.ToLower() == "off")
                radioBtn_enableOff_batteryAndContinuityTest.Checked = true;
        }

        private void ModifierListView_BatteryAndContinuityTest()
        {
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[1].Text = txtBox_description.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[2].Text = txtBox_mode.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[3].Text = txtBox_vsecurity.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[4].Text = txtBox_amperHourRange.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[5].Text = txtBox_d_amperHourRange.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[6].Text = txtBox_vtest.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[7].Text = txtBox_itest.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[8].Text = txtBox_time.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[9].Text = txtBox_delay.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[10].Text = txtBox_cycle.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[11].Text = txtBox_equalizerTime.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[12].Text = txtBox_testRelay.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[13].Text = txtBox_defaultRelay.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[14].Text = txtBox_defaultLed.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[15].Text = txtBox_logic.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[16].Text = lbl_commonValue.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[17].Text = txtBox_priority.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[18].Text = lbl_learningValue.Text;
            listView_batteryAndContinuityTest.SelectedItems[0].SubItems[19].Text = lbl_enableBatteryAndContinuityTestValue.Text;
        }
    }
}
