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
    public partial class Digital_Input : Form
    {
        private Lib1 Tools = new Lib1();

        private ListViewItem lastItemChecked;

        public bool save = false;

        //public string fonction;
        public string message = "", relay = "0", led = "0";

        public double price = 0, time = 0;

        public Digital_Input()
        {
            save = false;

            InitializeComponent();
            RemplirListView_DigitalInput();
            Remplir_cbFonction();
        }

        private void mnuItem_delete_Click(object sender, EventArgs e)
        {
            SupprimerDigitalInput();
            RemplirListView_DigitalInput();
        }

        private void pictureBox_new_Click(object sender, EventArgs e)
        {
            listView_digitalInput.Enabled = false;

            groupBox_ok.Visible = false;
            groupBox_details.Visible = true;

            btn_update.Visible = false;
            btn_save.Visible = true;

            radioBtn_commonDisable.Checked = false;
            radioBtn_commonEnable.Checked = true;
            radioBtn_digitalActifDisable.Checked = true;
            radioBtn_digitalActifEnable.Checked = false;

            Remplir_cbFonction();
        }

        private void pictureBox_newFunction_Click(object sender, EventArgs e)
        {
            string answer = Microsoft.VisualBasic.Interaction.InputBox("Add a new function : ", "Add Function", "");
            if (answer != "")
            {
                AjouterFonction(answer);
                Remplir_cbFonction();
            }
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

        private void btn_save_Click(object sender, EventArgs e)
        {
            AjouterDigitalInput();
            RemplirListView_DigitalInput();
        }

        private void btn_cancelAddOrUpdate_Click(object sender, EventArgs e)
        {
            ViderInformations();

            listView_digitalInput.Enabled = true;

            groupBox_ok.Visible = true;
            groupBox_details.Visible = false;

            Remplir_cbFonction();
        }

        private void listView_digitalInput_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            /*
            if (lastItemChecked != null && lastItemChecked.Checked && lastItemChecked != listView_digitalInput.Items[e.Index])
            {
                lastItemChecked.Checked = false;
            }
            */
            lastItemChecked = listView_digitalInput.Items[e.Index];
        }

        private void listView_digitalInput_DoubleClick(object sender, EventArgs e)
        {
            groupBox_ok.Visible = false;
            groupBox_details.Visible = true;

            listView_digitalInput.Enabled = false;

            btn_save.Visible = false;
            btn_update.Visible = true;

            AfficherInformations();
        }

        private void chkBox_message_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBox_message.Checked) txtBox_message.Enabled = true;
            else
            {
                txtBox_message.Clear();
                txtBox_message.Enabled = false;
                message = "";
            }
        }

        private void chkBox_relay_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBox_relay.Checked) txtBox_relay.Enabled = true;
            else
            {
                txtBox_relay.Clear();
                txtBox_relay.Enabled = false;
                relay = "0";
            }
        }

        private void chkBox_led_CheckedChanged(object sender, EventArgs e)
        {
            if (chkBox_led.Checked) txtBox_led.Enabled = true;
            else
            {
                txtBox_led.Clear();
                txtBox_led.Enabled = false;
                led = "0";
            }
        }

        private void radioBtn_commonEnable_CheckedChanged(object sender, EventArgs e)
        {
            lbl_commonValue.Text = "On";
        }

        private void radioBtn_commonDisable_CheckedChanged(object sender, EventArgs e)
        {
            lbl_commonValue.Text = "Off";
        }

        private void radioBtn_digitalActifEnable_CheckedChanged(object sender, EventArgs e)
        {
            lbl_digitalActifValue.Text = "On";
        }

        private void radioBtn_digitalActifDisable_CheckedChanged(object sender, EventArgs e)
        {
            lbl_digitalActifValue.Text = "Off";
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            ModifierListView_DigitalInput();
        }

        private void RemplirListView_DigitalInput()
        {
            string stSQL = "SELECT [pgm_digitalInput].*, [pgm_digitalInput_function].* " + 
                "FROM ([pgm_digitalInput] INNER JOIN [pgm_digitalInput_function] " +
                "ON [pgm_digitalInput].digitalInput_Function = [pgm_digitalInput_function].function_No)";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            listView_digitalInput.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem listViewItem = listView_digitalInput.Items.Add("");
                listViewItem.UseItemStyleForSubItems = false;
                for (int i = 1; i < Oreadr.FieldCount; i++) listViewItem.SubItems.Add(Oreadr[i].ToString());

                //string function = (Oreadr["digitalInput_Function"].ToString() != "0") ? Oreadr["digitalInput_Function"].ToString() : "";
                //listViewItem.SubItems.Add(function);
                //for (int i = 0; i < 5; i++) listViewItem.SubItems.Add("");
            }
            OConn.Close();
        }

        private void Remplir_cbFonction()
        {
            cbBox_fonction.Items.Clear();
            string stSQL = "SELECT [pgm_digitalInput_function].* FROM [pgm_digitalInput_function]";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
                cbBox_fonction.Items.Add(Oreadr["function_No"].ToString() + " - " + Oreadr["function_Description"].ToString());
            OConn.Close();
        }

        private void ViderInformations()
        {
            txtBox_description.Clear();
            txtBox_message.Clear();
            txtBox_relay.Clear();
            txtBox_led.Clear();
            txtBox_time.Clear();
            txtBox_logic.Clear();
            txtBox_priority.Clear();
            txtBox_price.Clear();

            radioBtn_commonDisable.Checked = false;
            radioBtn_commonEnable.Checked = false;
            radioBtn_digitalActifDisable.Checked = false;
            radioBtn_digitalActifEnable.Checked = false;

            lbl_commonValue.Text = "NA";
            lbl_digitalActifValue.Text = "NA";

            cbBox_fonction.Items.Clear();
        }

        private void SupprimerDigitalInput()
        {
            for (int i = listView_digitalInput.SelectedItems.Count - 1; i > -1; i--)
            {
                int id = VerifierDigitalInput(listView_digitalInput.SelectedItems[i].SubItems[1].Text,
                    Tools.Conv_Dbl(listView_digitalInput.SelectedItems[i].SubItems[2].Text),
                    listView_digitalInput.SelectedItems[i].SubItems[3].Text,
                    Convert.ToInt32(listView_digitalInput.SelectedItems[0].SubItems[4].Text),
                    Convert.ToInt32(listView_digitalInput.SelectedItems[i].SubItems[5].Text),
                    Convert.ToInt32(listView_digitalInput.SelectedItems[i].SubItems[6].Text),
                    Convert.ToInt32(listView_digitalInput.SelectedItems[i].SubItems[7].Text),
                    listView_digitalInput.SelectedItems[i].SubItems[8].Text,
                    listView_digitalInput.SelectedItems[i].SubItems[9].Text,
                    listView_digitalInput.SelectedItems[i].SubItems[10].Text,
                    listView_digitalInput.SelectedItems[i].SubItems[11].Text);
                if (id != 0)
                {
                    string stSQL = "DELETE FROM [pgm_digitalInput] WHERE [pgm_digitalInput].digitalInput_ID=" + id;
                    MainMDI.ExecSql(stSQL);
                }
            }
        }

        private int VerifierDigitalInput(string digitalInput_description, double digitalInput_price, string digitalInput_message, 
                                            int digitalInput_function, int digitalInput_relay, int digitalInput_led,
                                            int digitalInput_time, string digitalInput_logic, string digitalInput_priority, 
                                            string digitalInput_common, string digitalInput_digitalActif)
        {
            int id = 0;
            string stSQL = "SELECT [pgm_digitalInput].* FROM [pgm_digitalInput]";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                if ((Oreadr["digitalInput_description"].ToString() == digitalInput_description) &&
                    (Tools.Conv_Dbl(Oreadr["digitalInput_price"].ToString()) == digitalInput_price) &&
                    (Oreadr["digitalInput_message"].ToString() == digitalInput_message) &&
                    (Convert.ToInt32(Oreadr["digitalInput_function"].ToString()) == digitalInput_function) &&
                    (Convert.ToInt32(Oreadr["digitalInput_relay"].ToString()) == digitalInput_relay) &&
                    (Convert.ToInt32(Oreadr["digitalInput_led"].ToString()) == digitalInput_led) &&
                    (Convert.ToInt32(Oreadr["digitalInput_time"].ToString()) == digitalInput_time) &&
                    (Oreadr["digitalInput_logic"].ToString() == digitalInput_logic) &&
                    (Oreadr["digitalInput_priority"].ToString() == digitalInput_priority) &&
                    (Oreadr["digitalInput_common"].ToString() == digitalInput_common) &&
                    (Oreadr["digitalInput_digitalActif"].ToString() == digitalInput_digitalActif))
                    id =  Convert.ToInt32(Oreadr["digitalInput_ID"].ToString());
            }
            Oconn.Close();

            return id;
        }

        private void AjouterFonction(string function)
        {
            //string functionNo = answer.Substring(0, Rechercher_cbFonction(0, answer));
            //string function = answer.Substring(answer.Contains("- ") ? answer.IndexOf("-") + 2 : answer.IndexOf("-") + 1);

            string cbBox_function_text = cbBox_fonction.Items[cbBox_fonction.Items.Count - 1].ToString();
            int functionNo = Convert.ToInt32(cbBox_function_text.Substring(0, Rechercher_cbFonction(0, cbBox_function_text))) + 1;

            string stSQL = "INSERT INTO [pgm_digitalInput_function] ([pgm_digitalInput_function].function_No, " +
                "[pgm_digitalInput_function].function_Description) VALUES (" +
                functionNo + ", '" +
                function + "')";
            MainMDI.ExecSql(stSQL);
        }

        private int Rechercher_cbFonction(int count, string answer)
        {
            for (int i = 0; i < answer.Length; i++) 
            {
                if ((answer[i] >= '0') && (answer[i] <= '9')) count++;
                if (answer[i] == '-') break;
            }
            return count;
        }

        private void AjouterDigitalInput()
        {
            price = ((txtBox_price.Text != "") && (txtBox_price.Text.All(char.IsDigit))) ? Tools.Conv_Dbl(txtBox_price.Text) : 0;
            if ((txtBox_message.Enabled) && (txtBox_message.Text != "")) message = txtBox_message.Text;
            if ((txtBox_relay.Enabled) && (txtBox_relay.Text != "")) relay = txtBox_relay.Text;
            if ((txtBox_led.Enabled) && (txtBox_led.Text != "")) led = txtBox_led.Text;
            time = ((txtBox_time.Text != "") && (txtBox_time.Text.All(char.IsDigit))) ? Tools.Conv_Dbl(txtBox_time.Text) : 0;

            string functionNo = cbBox_fonction.Text.Substring(0, cbBox_fonction.Text.Contains(" -") ? cbBox_fonction.Text.IndexOf("-") - 1 : 
                cbBox_fonction.Text.IndexOf("-"));

            string stSQL = "INSERT INTO [pgm_digitalInput] ([pgm_digitalInput].digitalInput_Description, [pgm_digitalInput].digitalInput_Price, " +
                "[pgm_digitalInput].digitalInput_Message, [pgm_digitalInput].digitalInput_Function, [pgm_digitalInput].digitalInput_Relay, " +
                "[pgm_digitalInput].digitalInput_Led, [pgm_digitalInput].digitalInput_Time, [pgm_digitalInput].digitalInput_Logic, " +
                "[pgm_digitalInput].digitalInput_Priority, [pgm_digitalInput].digitalInput_Common, [pgm_digitalInput].digitalInput_DigitalActif) VALUES ('"
                + txtBox_description.Text + "', " +
                price + ", '" +
                message + "', " +
                functionNo + ", " +
                relay + ", " +
                led + ", " +
                time + ", '" +
                txtBox_logic.Text + "', '" +
                txtBox_priority.Text + "', '" +
                lbl_commonValue.Text + "', '" +
                lbl_digitalActifValue.Text + "')";
            MainMDI.ExecSql(stSQL);
        }

        private void AfficherInformations()
        {
            txtBox_description.Text = listView_digitalInput.SelectedItems[0].SubItems[1].Text;
            txtBox_price.Text = listView_digitalInput.SelectedItems[0].SubItems[2].Text;
            txtBox_message.Text = listView_digitalInput.SelectedItems[0].SubItems[3].Text;

            Remplir_cbFonction();

            cbBox_fonction.Text = Afficher_cbFonctionInformations(listView_digitalInput.SelectedItems[0].SubItems[4].Text);

            txtBox_relay.Text = listView_digitalInput.SelectedItems[0].SubItems[5].Text;
            txtBox_led.Text = listView_digitalInput.SelectedItems[0].SubItems[6].Text;
            txtBox_time.Text = listView_digitalInput.SelectedItems[0].SubItems[7].Text;
            txtBox_logic.Text = listView_digitalInput.SelectedItems[0].SubItems[8].Text;
            txtBox_priority.Text = listView_digitalInput.SelectedItems[0].SubItems[9].Text;

            //CheckRadioButton(10, listView_digitalInput.SelectedItems[0].SubItems[10].Text);
            if (listView_digitalInput.SelectedItems[0].SubItems[10].Text.ToLower() == "on") radioBtn_commonEnable.Checked = true;
            else if (listView_digitalInput.SelectedItems[0].SubItems[10].Text.ToLower() == "off") radioBtn_commonDisable.Checked = true;

            //CheckRadioButton(11, listView_digitalInput.SelectedItems[0].SubItems[11].Text);
            if (listView_digitalInput.SelectedItems[0].SubItems[11].Text.ToLower() == "on") radioBtn_digitalActifEnable.Checked = true;
            else if (listView_digitalInput.SelectedItems[0].SubItems[11].Text.ToLower() == "off") radioBtn_digitalActifDisable.Checked = true;
        }

        public string Afficher_cbFonctionInformations(string element)
        {
            for (int i = 0; i < cbBox_fonction.Items.Count; i++)
            {
                string indice = cbBox_fonction.Items[i].ToString().Substring(0, cbBox_fonction.Items[i].ToString().Contains(" -") ? 
                    cbBox_fonction.Items[i].ToString().IndexOf("-") - 1 : cbBox_fonction.Items[i].ToString().IndexOf("-"));
                if (indice == element) return cbBox_fonction.Items[i].ToString();
                if (element == "") return cbBox_fonction.Items[0].ToString();
            }
            return "";
        }

        /*
        private string CheckRadioButton(int index, string value)
        {
            string text = "";
            switch (index)
            {
                case 10:
                    if (value == "On" || value == "on")
                    {
                        radioBtn_commonEnable.Checked = true;
                        radioBtn_commonDisable.Checked = false;
                        text = "On";
                    }
                    else
                    {
                        radioBtn_commonEnable.Checked = false;
                        radioBtn_commonDisable.Checked = true;
                        text = "Off";
                    }
                    break;
                case 11:
                    if (value == "On" || value == "on")
                    {
                        radioBtn_digitalActifEnable.Checked = true;
                        radioBtn_digitalActifDisable.Checked = false;
                        text = "On";
                    }
                    else
                    {
                        radioBtn_digitalActifEnable.Checked = false;
                        radioBtn_digitalActifDisable.Checked = true;
                        text = "Off";
                    }
                    break;
            }
            return text;
        }
        */

        private void ModifierListView_DigitalInput()
        {
            listView_digitalInput.SelectedItems[0].SubItems[1].Text = txtBox_description.Text;
            listView_digitalInput.SelectedItems[0].SubItems[2].Text = txtBox_price.Text;
            listView_digitalInput.SelectedItems[0].SubItems[3].Text = txtBox_message.Text;
            listView_digitalInput.SelectedItems[0].SubItems[4].Text = cbBox_fonction.Text.Substring(0, cbBox_fonction.Text.Contains(" -") ? 
                cbBox_fonction.Text.IndexOf("-") - 1 : cbBox_fonction.Text.IndexOf("-"));
            listView_digitalInput.SelectedItems[0].SubItems[5].Text = txtBox_relay.Text;
            listView_digitalInput.SelectedItems[0].SubItems[6].Text = txtBox_led.Text;
            listView_digitalInput.SelectedItems[0].SubItems[7].Text = txtBox_time.Text;
            listView_digitalInput.SelectedItems[0].SubItems[8].Text = txtBox_logic.Text;
            listView_digitalInput.SelectedItems[0].SubItems[9].Text = txtBox_priority.Text;
            listView_digitalInput.SelectedItems[0].SubItems[10].Text = lbl_commonValue.Text;
            listView_digitalInput.SelectedItems[0].SubItems[11].Text = lbl_digitalActifValue.Text;
        }
    }
}
