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
    public partial class Advanced : Form
    {
        private Lib1 Tools = new Lib1();

        public bool save = false;

        public static bool showLimit = false, showRemote = false, showBatteryCompensation = false;

        public static string lbl_showLimit_text, lbl_showRemote_text, lbl_showBatteryCompensation_text, vdc, vdcMax, vdcMin, idcMax, 
            nbrCell;

        public static string lbl_hideLimit_text = "Hide Limit", lbl_hideRemote_text = "Hide Remote", 
            lbl_hideBatteryCompensation = "Hide BattComp";

        public static int height, heightInitialize = 400;

        public double price;

        public static Size sizeLimit, sizeRemote, sizeBatteryCompensation;

        public static Size sizeInitialize = new Size(0, 0);

        public Advanced(string Vdc, string VdcMax, string VdcMin, string IdcMax, string NbrCell)
        {
            InitializeComponent();

            vdc = Vdc;
            vdcMax = VdcMax;
            vdcMin = VdcMin;
            idcMax = IdcMax;
            nbrCell = NbrCell;

            height = this.Height;
            this.Height = heightInitialize;

            sizeLimit = grpBox_limitDetails.Size;
            sizeRemote = grpBox_remoteDetails.Size;
            sizeBatteryCompensation = grpBox_batteryCompensationDetails.Size;
            grpBox_limitDetails.Size = sizeInitialize;
            grpBox_remoteDetails.Size = sizeInitialize;
            grpBox_batteryCompensationDetails.Size = sizeInitialize;

            lbl_showLimit_text = lbl_showLimit.Text;
            lbl_showRemote_text = lbl_showRemote.Text;
            lbl_showBatteryCompensation_text = lbl_showBatteryCompensation.Text;

            AfficherAdvancedInformation();
            RemplirListView_Limit();
            RemplirListView_Remote();
            Remplir_cbFonctionRemote();
            RemplirListView_BatteryCompensation();
            InsererDonnes(vdc, vdcMax, vdcMin, idcMax, nbrCell);
        }

        private void mnuItem_deleteLimit_Click(object sender, EventArgs e)
        {
            SupprimerLimit();
            RemplirListView_Limit();
        }

        private void mnuItem_deleteRemote_Click(object sender, EventArgs e)
        {
            SupprimerRemote();
            RemplirListView_Remote();
        }

        private void mnuItem_deleteBatteryCompensation_Click(object sender, EventArgs e)
        {
            SupprimerBatteryCompensation();
            RemplirListView_BatteryCompensation();
        }

        private void btn_cancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void radioBtn_iacDisplayOn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_iacDisplayValue.Text = "On";
        }

        private void radioBtn_iacDisplayOff_CheckedChanged(object sender, EventArgs e)
        {
            lbl_iacDisplayValue.Text = "Off";
        }

        private void radioBtn_vacDisplayOn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_vacDisplayValue.Text = "On";
        }

        private void radioBtn_vacDisplayOff_CheckedChanged(object sender, EventArgs e)
        {
            lbl_vacDisplayValue.Text = "Off";
        }

        private void radioBtn_ibatDisplayOn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_ibatDisplayValue.Text = "On";
        }

        private void radioBtn_ibatDisplayOff_CheckedChanged(object sender, EventArgs e)
        {
            lbl_ibatDisplayValue.Text = "Off";
        }

        private void radioBtn_ipDisplayOn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_ipDisplayValue.Text = "On";
        }

        private void radioBtn_ipDisplayOff_CheckedChanged(object sender, EventArgs e)
        {
            lbl_ipDisplayValue.Text = "Off";
        }

        private void radioBtn_rectifierOn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_rectifierValue.Text = "On";
        }

        private void radioBtn_rectifierOff_CheckedChanged(object sender, EventArgs e)
        {
            lbl_rectifierValue.Text = "Off";
        }

        private void radioBtn_english_CheckedChanged(object sender, EventArgs e)
        {
            lbl_languageValue.Text = "En";
        }

        private void radioBtn_français_CheckedChanged(object sender, EventArgs e)
        {
            lbl_languageValue.Text = "Fr";
        }

        private void pictureBox_newLimit_Click(object sender, EventArgs e)
        {
            this.Height = height;

            listView_limit.Enabled = false;
            grpBox_button.Visible = false;
            grpBox_limit.Visible = true;
            grpBox_limitDetails.Visible = true;
            btn_updateLimit.Visible = false;
            btn_saveLimit.Visible = true;

            grpBox_limitDetails.Size = sizeLimit;

            ViderGrpBox_LimiteDetails();
        }

        private void pictureBox_showLimit_Click(object sender, EventArgs e)
        {
            if (showLimit)
            {
                showLimit = false;
                this.Height = heightInitialize;
                grpBox_limit.Visible = false;
                lbl_showLimit.Text = lbl_showLimit_text;
            } else
            {
                if (showRemote || showBatteryCompensation)
                {
                    showRemote = false;
                    showBatteryCompensation = false;
                    lbl_showRemote.Text = lbl_showRemote_text;
                    lbl_showBatteryCompensation.Text = lbl_showBatteryCompensation_text;
                    grpBox_remote.Visible = false;
                    grpBox_batteryCompensation.Visible = false;
                }
                showLimit = true;
                this.Height = height;
                grpBox_limit.Visible = true;
                lbl_showLimit.Text = lbl_hideLimit_text;
            }
        }

        private void radioBtn_enableLimitOn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_enableLimitValue.Text = "On";
        }

        private void radioBtn_enableLimitOff_CheckedChanged(object sender, EventArgs e)
        {
            lbl_enableLimitValue.Text = "Off";
        }

        private void btn_saveLimit_Click(object sender, EventArgs e)
        {
            AjouterLimit();
            RemplirListView_Limit();
        }

        private void btn_cancelLimit_Click(object sender, EventArgs e)
        {
            listView_limit.Enabled = true;
            if (!showLimit)
            {
                this.Height = heightInitialize;
                grpBox_limit.Visible = false;
            }
            grpBox_button.Visible = true;
            grpBox_limitDetails.Visible = false;
            btn_updateLimit.Visible = true;
            btn_saveLimit.Visible = false;
            grpBox_limitDetails.Size = sizeInitialize;
        }

        private void pictureBox_newRemote_Click(object sender, EventArgs e)
        {
            this.Height = height;

            listView_remote.Enabled = false;
            grpBox_button.Visible = false;
            grpBox_remote.Visible = true;
            grpBox_remoteDetails.Visible = true;
            btn_updateRemote.Visible = false;
            btn_saveRemote.Visible = true;

            grpBox_remoteDetails.Size = sizeRemote;

            ViderGrpBox_RemoteDetails();
            Remplir_cbFonctionRemote();
        }

        private void pictureBox_showRemote_Click(object sender, EventArgs e)
        {
            if (showRemote)
            {
                showRemote = false;
                this.Height = heightInitialize;
                grpBox_remote.Visible = false;
                lbl_showRemote.Text = lbl_showRemote_text;
            }
            else
            {
                if (showLimit || showBatteryCompensation)
                {
                    showLimit = false;
                    showBatteryCompensation = false;
                    lbl_showLimit.Text = lbl_showLimit_text;
                    lbl_showBatteryCompensation.Text = lbl_showBatteryCompensation_text;
                    grpBox_limit.Visible = false;
                    grpBox_batteryCompensation.Visible = false;
                }
                showRemote = true;
                this.Height = height;
                grpBox_remote.Visible = true;
                lbl_showRemote.Text = lbl_hideRemote_text;
            }
        }

        private void radioBtn_enableRemoteOn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_enableRemoteValue.Text = "On";
        }

        private void radioBtn_enableRemoteOff_CheckedChanged(object sender, EventArgs e)
        {
            lbl_enableRemoteValue.Text = "Off";
        }

        private void btn_saveRemote_Click(object sender, EventArgs e)
        {
            AjouterRemote();
            RemplirListView_Remote();
        }

        private void btn_cancelRemote_Click(object sender, EventArgs e)
        {
            listView_remote.Enabled = true;
            if (!showRemote)
            {
                this.Height = heightInitialize;
                grpBox_remote.Visible = false;
            }
            grpBox_button.Visible = true;
            grpBox_remoteDetails.Visible = false;
            btn_updateRemote.Visible = true;
            btn_saveRemote.Visible = false;
            grpBox_remoteDetails.Size = sizeInitialize;
        }

        private void pictureBox_newBatteryCompensation_Click(object sender, EventArgs e)
        {
            /*
            this.Height = height;

            listView_batteryCompensation.Enabled = false;
            grpBox_button.Visible = false;
            grpBox_batteryCompensation.Visible = true;
            grpBox_batteryCompensationDetails.Visible = true;

            grpBox_batteryCompensationDetails.Size = sizeBatteryCompensation;

            ViderGrpBox_BatteryCompensationDetails();
            */

            AjouterBatteryCompensation();
            RemplirListView_BatteryCompensation();
        }

        private void pictureBox_showBatteryCompensation_Click(object sender, EventArgs e)
        {
            if (showBatteryCompensation)
            {
                showBatteryCompensation = false;
                this.Height = heightInitialize;
                grpBox_batteryCompensation.Visible = false;
                lbl_showBatteryCompensation.Text = lbl_showBatteryCompensation_text;
            }
            else
            {
                if (showLimit || showRemote)
                {
                    showLimit = false;
                    showRemote = false;
                    lbl_showLimit.Text = lbl_showLimit_text;
                    lbl_showRemote.Text = lbl_showRemote_text;
                    grpBox_limit.Visible = false;
                    grpBox_remote.Visible = false;
                }
                showBatteryCompensation = true;
                this.Height = height;
                grpBox_batteryCompensation.Visible = true;
                lbl_showBatteryCompensation.Text = lbl_hideBatteryCompensation;
            }
        }

        private void radioBtn_enableBatteryCompensationOn_CheckedChanged(object sender, EventArgs e)
        {
            lbl_enableBatteryCompensationValue.Text = "On";
        }

        private void radioBtn_enableBatteryCompensationOff_CheckedChanged(object sender, EventArgs e)
        {
            lbl_enableBatteryCompensationValue.Text = "Off";
        }

        private void pictureBox_addFunction_Click(object sender, EventArgs e)
        {
            string answer = Microsoft.VisualBasic.Interaction.InputBox("Add a new function : ", "Add function", "");
            if (answer != "")
            {
                AjouterFonction(answer);
                Remplir_cbFonctionRemote();
            }
        }

        private void btn_cancelBatteryCompensation_Click(object sender, EventArgs e)
        {
            listView_batteryCompensation.Enabled = true;
            if (!showBatteryCompensation)
            {
                this.Height = heightInitialize;
                grpBox_batteryCompensation.Visible = false;
            }
            grpBox_button.Visible = true;
            grpBox_batteryCompensationDetails.Visible = false;
            grpBox_batteryCompensationDetails.Size = sizeInitialize;
        }

        private void listView_limit_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

        }

        private void listView_limit_DoubleClick(object sender, EventArgs e)
        {
            listView_limit.Enabled = false;
            grpBox_button.Visible = false;
            grpBox_limitDetails.Visible = true;
            btn_saveLimit.Visible = false;
            btn_updateLimit.Visible = true;

            grpBox_limitDetails.Size = sizeLimit;

            AfficherListView_LimitInformations();
        }

        private void btn_updateLimit_Click(object sender, EventArgs e)
        {
            ModifierListView_Limit();
        }

        private void listView_remote_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

        }

        private void listView_remote_DoubleClick(object sender, EventArgs e)
        {
            listView_remote.Enabled = false;
            grpBox_button.Visible = false;
            grpBox_remoteDetails.Visible = true;
            btn_saveRemote.Visible = false;
            btn_updateRemote.Visible = true;

            grpBox_remoteDetails.Size = sizeLimit;

            AfficherListView_RemoteInformations();
        }

        private void btn_updateRemote_Click(object sender, EventArgs e)
        {
            ModifierListView_Remote();
        }

        private void listView_batteryCompensation_ItemChecked(object sender, ItemCheckedEventArgs e)
        {

        }

        private void listView_batteryCompensation_DoubleClick(object sender, EventArgs e)
        {
            listView_batteryCompensation.Enabled = false;
            grpBox_button.Visible = false;
            grpBox_batteryCompensationDetails.Visible = true;

            grpBox_batteryCompensationDetails.Size = sizeLimit;

            AfficherList_BatteryCompensation();
        }

        private void btn_updateBatteryCompensation_Click(object sender, EventArgs e)
        {
            ModifierListView_BatteryCompensation();
        }

        private void btn_ok_Click(object sender, EventArgs e)
        {
            save = true;
            this.Hide();
        }

        private void AfficherAdvancedInformation()
        {
            txtBox_softStart.Text = "8";
            //txtBox_vnominal.Text = "125";
            //txtBox_vmax.Text = "150";
            //txtBox_vmin.Text = "0";
            //txtBox_imax.Text = "150";
            txtBox_d_vfeedback.Text = "85";
            txtBox_rectifyShunt.Text = "150";
            txtBox_batteryShunt.Text = "100";
            txtBox_numberCells.Text = "96";

            radioBtn_iacDisplayOff.Checked = true;
            radioBtn_vacDisplayOff.Checked = true;
            radioBtn_ibatDisplayOff.Checked = true;
            radioBtn_ipDisplayOff.Checked = true;
            radioBtn_rectifierOff.Checked = true;

            txtBox_refreshLCD.Text = "30";

            radioBtn_english.Checked = true;
        }

        private void ViderGrpBox_LimiteDetails()
        {
            txtBox_descriptionLimit.Text = "";
            txtBox_valueLimit.Text = "";
            txtBox_ratioLimit.Text = "";

            radioBtn_enableLimitOn.Checked = false;
            radioBtn_enableLimitOff.Checked = false;

            lbl_enableLimitValue.Text = "NA";
        }

        private void ViderGrpBox_RemoteDetails()
        {
            txtBox_descriptionRemote.Text = "";
            cbBox_functionRemote.Text = "";

            radioBtn_enableRemoteOn.Checked = false;
            radioBtn_enableRemoteOff.Checked = false;

            lbl_enableRemoteValue.Text = "NA";
        }

        private void ViderGrpBox_BatteryCompensationDetails()
        {
            lbl_batteryCompensationValue1.Text = "";
            lbl_batteryCompensationValue2.Text = "";
            lbl_batteryCompensationValue3.Text = "";
            txtBox_descriptionBatteryCompensation.Text = "";
            txtBox_batteryCompensationValue1.Text = "";
            txtBox_batteryCompensationValue2.Text = "";
            txtBox_batteryCompensationValue3.Text = "";

            radioBtn_enableBatteryCompensationOn.Checked = false;
            radioBtn_enableBatteryCompensationOff.Checked = false;

            lbl_enableBatteryCompensationValue.Text = "NA";
        }

        private void RemplirListView_Limit()
        {
            string stSQL = "SELECT [pgm_limit].* FROM [pgm_limit]";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            listView_limit.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem listViewItem = listView_limit.Items.Add("");
                listViewItem.UseItemStyleForSubItems = false;
                for (int i = 1; i < Oreadr.FieldCount; i++) listViewItem.SubItems.Add(Oreadr[i].ToString());
            }
            Oconn.Close();
        }

        private void SupprimerLimit()
        {
            for (int i = listView_limit.SelectedItems.Count - 1; i > -1; i--)
            {
                int id = VerifierLimit(listView_limit.SelectedItems[i]);
                if (id != 0)
                {
                    string stSQL = "DELETE FROM [pgm_limit] WHERE [pgm_limit].limit_Id = " + id;
                    MainMDI.ExecSql(stSQL);
                }
            }
        }

        private int VerifierLimit(ListViewItem listViewItem)
        {
            int id = 0;
            bool verify = false;
            string stSQL = "SELECT [pgm_limit].* FROM [pgm_limit]";
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
                        if ((i == Oreadr.FieldCount - 1) && verify) id = Convert.ToInt32(Oreadr["limit_Id"].ToString());
                    }
                }
            }
            Oconn.Close();

            return id;
        }

        private void AjouterLimit()
        {
            string stSQL = "INSERT INTO [pgm_limit] ([pgm_limit].limit_Description, [pgm_limit].limit_Value, [pgm_limit].limit_Ratio, " + 
                "[pgm_limit].limit_Enable) VALUES ('" + 
                txtBox_descriptionLimit.Text + "', '" + 
                txtBox_valueLimit.Text + "', '" + 
                txtBox_ratioLimit.Text + "', '" + 
                lbl_enableLimitValue.Text + "')";
            MainMDI.ExecSql(stSQL);
        }

        private void AfficherListView_LimitInformations()
        {
            txtBox_descriptionLimit.Text = listView_limit.SelectedItems[0].SubItems[1].Text;
            txtBox_valueLimit.Text = listView_limit.SelectedItems[0].SubItems[2].Text;
            txtBox_ratioLimit.Text = listView_limit.SelectedItems[0].SubItems[3].Text;

            if (listView_limit.SelectedItems[0].SubItems[4].Text.ToLower() == "on") radioBtn_enableLimitOn.Checked = true;
            else if (listView_limit.SelectedItems[0].SubItems[4].Text.ToLower() == "off") radioBtn_enableLimitOff.Checked = true;
        }

        private void ModifierListView_Limit()
        {
            listView_limit.SelectedItems[0].SubItems[1].Text = txtBox_descriptionLimit.Text;
            listView_limit.SelectedItems[0].SubItems[2].Text = txtBox_valueLimit.Text;
            listView_limit.SelectedItems[0].SubItems[3].Text = txtBox_ratioLimit.Text;
            listView_limit.SelectedItems[0].SubItems[4].Text = lbl_enableLimitValue.Text;
        }

        private void RemplirListView_Remote()
        {
            string stSQL = "SELECT [pgm_remote].* FROM [pgm_remote] " +
                "INNER JOIN [pgm_remote_function] ON [pgm_remote].remote_Function = [pgm_remote_function].function_No";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            listView_remote.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem listViewItem = listView_remote.Items.Add("");
                listViewItem.UseItemStyleForSubItems = false;
                for (int i = 1; i < Oreadr.FieldCount; i++) listViewItem.SubItems.Add(Oreadr[i].ToString());
            }
            Oconn.Close();
        }

        private void Remplir_cbFonctionRemote()
        {
            cbBox_functionRemote.Items.Clear();
            string stSQL = "SELECT [pgm_remote_function].* FROM [pgm_remote_function]";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
                cbBox_functionRemote.Items.Add(Oreadr["function_No"].ToString() + " - " + Oreadr["function_Description"].ToString());
            Oconn.Close();
        }

        private void SupprimerRemote()
        {
            for (int i = listView_remote.SelectedItems.Count - 1; i > -1; i--)
            {
                int id = VerifierRemote(listView_remote.SelectedItems[i].SubItems[1].Text, 
                    Tools.Conv_Dbl(listView_remote.SelectedItems[i].SubItems[2].Text), 
                    Convert.ToInt32(listView_remote.SelectedItems[i].SubItems[3].Text), listView_remote.SelectedItems[i].SubItems[4].Text);
                if (id != 0)
                {
                    string stSQl = "DELETE FROM [pgm_remote] WHERE [pgm_remote].remote_Id = " + id;
                    MainMDI.ExecSql(stSQl);
                }
            }
        }

        private int VerifierRemote(string remote_description, double remote_price, int remote_function, string remote_enable)
        {
            int id = 0;
            string stSQL = "SELECT [pgm_remote].* FROM [pgm_remote]";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                if ((Oreadr["remote_Description"].ToString() == remote_description) && 
                    (Tools.Conv_Dbl(Oreadr["remote_Price"].ToString()) == remote_price) &&
                    (Convert.ToInt32(Oreadr["remote_Function"].ToString()) == remote_function) && 
                    (Oreadr["remote_Enable"].ToString() == remote_enable))
                    id = Convert.ToInt32(Oreadr["remote_Id"].ToString());
            }
            Oconn.Close();

            return id;
        }

        private void AjouterFonction(string answer)
        {
            string functionNo = answer.Substring(0, Rechercher_cbFonctionRemote(0, answer));
            string function = answer.Substring(answer.Contains("- ") ? answer.IndexOf("-") + 2 : answer.IndexOf("-") + 1);

            string stSQL = "INSERT INTO [pgm_remote_function] ([pgm_remote_function].function_No, [pgm_remote_function].function_Description) " + 
                "VALUES (" + 
                functionNo + ", '" + 
                function + "')";
            MainMDI.ExecSql(stSQL);
        }

        private int Rechercher_cbFonctionRemote(int count, string answer)
        {
            for (int i = 0; i < answer.Length; i++) 
                if ((answer[i] >= '0') && (answer[i] <= '9')) count++;
            return count;
        }

        private void AjouterRemote()
        {
            price = ((txtBox_priceRemote.Text != "") && (txtBox_priceRemote.Text.All(char.IsDigit))) ? Tools.Conv_Dbl(txtBox_priceRemote.Text) : 0; 
            string functionNo = cbBox_functionRemote.Text.Substring(0, Rechercher_cbFonctionRemote(0, cbBox_functionRemote.Text));

            string stSQL = "INSERT INTO [pgm_remote] ([pgm_remote].remote_Description, [pgm_remote].remote_Price, [pgm_remote].remote_Function, " +
                "[pgm_remote].remote_Enable) VALUES ('" +
                txtBox_descriptionRemote.Text + "', " +
                price + ", " +
                functionNo + ", '" + 
                lbl_enableRemoteValue.Text + "')";
            MainMDI.ExecSql(stSQL);
        }

        private void AfficherListView_RemoteInformations()
        {
            txtBox_descriptionRemote.Text = listView_remote.SelectedItems[0].SubItems[1].Text;
            txtBox_priceRemote.Text = listView_remote.SelectedItems[0].SubItems[2].Text;

            Remplir_cbFonctionRemote();

            cbBox_functionRemote.Text = Afficher_cbFonctionRemoteInformations(listView_remote.SelectedItems[0].SubItems[2].Text);

            if (listView_remote.SelectedItems[0].SubItems[3].Text.ToLower() == "on") radioBtn_enableRemoteOn.Checked = true;
            else if (listView_remote.SelectedItems[0].SubItems[3].Text.ToLower() == "off") radioBtn_enableRemoteOff.Checked = true;
        }

        private string Afficher_cbFonctionRemoteInformations(string element)
        {
            for (int i = 0; i < cbBox_functionRemote.Items.Count; i++)
            {
                string indice = cbBox_functionRemote.Items[i].ToString().Substring(0, Rechercher_cbFonctionRemote(0, cbBox_functionRemote.Items[i].ToString()));
                if (indice == element) return cbBox_functionRemote.Items[i].ToString();
                if (element == "") return cbBox_functionRemote.Items[0].ToString();
            }
            return "";
        }

        private void ModifierListView_Remote()
        {
            listView_remote.SelectedItems[0].SubItems[1].Text = txtBox_descriptionRemote.Text;
            listView_remote.SelectedItems[0].SubItems[2].Text = txtBox_priceRemote.Text;
            listView_remote.SelectedItems[0].SubItems[3].Text = cbBox_functionRemote.Text.Substring(0, Rechercher_cbFonctionRemote(0, cbBox_functionRemote.Text));
            listView_remote.SelectedItems[0].SubItems[4].Text = lbl_enableRemoteValue.Text;
        }

        private void RemplirListView_BatteryCompensation()
        {
            RemplirListView_BatteryCompensation_Colonne();
            RemplirListView_BatteryCompensation_Item();
        }

        private void RemplirListView_BatteryCompensation_Colonne()
        {
            List<string> listeNameColonne = new List<string>();
            string stSQL = "SELECT [pgm_batteryCompensation_columns].* FROM [pgm_batteryCompensation_columns]";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read()) 
                listeNameColonne.Add(Oreadr["batteryCompensation_columns_ColumnName"].ToString());
            Oconn.Close();

            for (int i = 0; i < listeNameColonne.Count; i++) listView_batteryCompensation.Columns[i + 4].Text = listeNameColonne[i];
        }

        private void RemplirListView_BatteryCompensation_Item()
        {
            string stSQL = "SELECT [pgm_batteryCompensation].* FROM [pgm_batteryCompensation]";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            listView_batteryCompensation.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem listViewItem = listView_batteryCompensation.Items.Add("");
                listViewItem.UseItemStyleForSubItems = false;
                for (int i = 1; i < Oreadr.FieldCount; i++) 
                    listViewItem.SubItems.Add((Oreadr[i] == DBNull.Value) ? "NA" : Oreadr[i].ToString());
            }
            Oconn.Close();
        } 

        private void InsererDonnes(string vdc, string vdcMax, string vdcMin, string idcMax, string nbrCell)
        {
            txtBox_vnominal.Text = vdc;
            txtBox_vmax.Text = vdcMax;
            txtBox_vmin.Text = vdcMin;
            txtBox_imax.Text = idcMax;
            txtBox_numberCells.Text = nbrCell;
        }

        private void SupprimerBatteryCompensation()
        {
            for (int i = listView_batteryCompensation.SelectedItems.Count - 1; i > -1; i--)
            {
                int id = VeriferBatteryCompensation(listView_batteryCompensation.SelectedItems[i]);
                if (id != 0)
                {
                    string stSQL = "DELETE FROM [pgm_batteryCompensation] WHERE [pgm_batteryCompensation].batteryCompensation_Id = " + id;
                    MainMDI.ExecSql(stSQL);
                }
            }
        }

        private int VeriferBatteryCompensation(ListViewItem listViewItem)
        {
            int id = 0;
            bool verif = false;
            string stSQL = "SELECT [pgm_batteryCompensation].* FROM [pgm_batteryCompensation]";
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
                        string valeur = (Oreadr[i] == DBNull.Value) ? "NA" : Oreadr[i].ToString();
                        if (valeur == listViewItem.SubItems[i].Text) verif = true;
                        if ((i == Oreadr.FieldCount - 1) && verif) id = Convert.ToInt32(Oreadr["batteryCompensation_Id"].ToString());
                    }
                }
            }
            Oconn.Close();

            return id;
        }

        private void AjouterBatteryCompensation()
        {
            Add_BatteryCompensation add_BatteryCompensation = new Add_BatteryCompensation();
            add_BatteryCompensation.ShowDialog();
        }

        private void AfficherList_BatteryCompensation()
        {
            ViderGrpBox_BatteryCompensationDetails();

            int compteur = 0;

            txtBox_descriptionBatteryCompensation.Text = listView_batteryCompensation.SelectedItems[0].SubItems[1].Text;
            txtBox_batteryCompensationPrice.Text = listView_batteryCompensation.SelectedItems[0].SubItems[2].Text;

            if (listView_batteryCompensation.SelectedItems[0].SubItems[3].Text.ToLower() == "on")
                radioBtn_enableBatteryCompensationOn.Checked = true;
            else if (listView_batteryCompensation.SelectedItems[0].SubItems[3].Text.ToLower() == "off")
                radioBtn_enableBatteryCompensationOff.Checked = true;
            for (int i = 4; i < listView_batteryCompensation.SelectedItems[0].SubItems.Count; i++)
            {
                if (listView_batteryCompensation.SelectedItems[0].SubItems[i].Text != "NA")
                {
                    switch (compteur)
                    {
                        case 0:
                            lbl_batteryCompensationValue1.Text = listView_batteryCompensation.Columns[i].Text;
                            txtBox_batteryCompensationValue1.Text = listView_batteryCompensation.SelectedItems[0].SubItems[i].Text;
                            break;
                        case 1:
                            lbl_batteryCompensationValue2.Text = listView_batteryCompensation.Columns[i].Text;
                            txtBox_batteryCompensationValue2.Text = listView_batteryCompensation.SelectedItems[0].SubItems[i].Text;
                            break;
                        case 2:
                            lbl_batteryCompensationValue3.Visible = true;
                            txtBox_batteryCompensationValue3.Visible = true;
                            lbl_batteryCompensationValue3.Text = listView_batteryCompensation.Columns[i].Text;
                            txtBox_batteryCompensationValue3.Text = listView_batteryCompensation.SelectedItems[0].SubItems[i].Text;
                            break;
                    }
                    compteur++;
                }
            }
            if (compteur < 3)
            {
                lbl_batteryCompensationValue3.Visible = false;
                txtBox_batteryCompensationValue3.Visible = false;
            }
        }

        private void ModifierListView_BatteryCompensation()
        {
            int compteur = 1;
            listView_batteryCompensation.SelectedItems[0].SubItems[compteur++].Text = txtBox_descriptionBatteryCompensation.Text;
            listView_batteryCompensation.SelectedItems[0].SubItems[compteur++].Text = txtBox_batteryCompensationPrice.Text;
            listView_batteryCompensation.SelectedItems[0].SubItems[compteur++].Text = lbl_enableBatteryCompensationValue.Text;
            for (int i = compteur; i < listView_batteryCompensation.SelectedItems[0].SubItems.Count; i++)
            {
                if (listView_batteryCompensation.Columns[i].Text == lbl_batteryCompensationValue1.Text)
                    listView_batteryCompensation.SelectedItems[0].SubItems[i].Text = txtBox_batteryCompensationValue1.Text;
                else if (listView_batteryCompensation.Columns[i].Text == lbl_batteryCompensationValue2.Text)
                    listView_batteryCompensation.SelectedItems[0].SubItems[i].Text = txtBox_batteryCompensationValue2.Text;
                else if (listView_batteryCompensation.Columns[i].Text == lbl_batteryCompensationValue3.Text)
                    listView_batteryCompensation.SelectedItems[0].SubItems[i].Text = txtBox_batteryCompensationValue3.Text;
            }
        }
    }
}
