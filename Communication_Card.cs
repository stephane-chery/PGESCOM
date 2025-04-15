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
    public partial class Communication_Card : Form
    {
        private Lib1 Tools = new Lib1();

        private ListViewItem lastItemChecked;

        public bool save = false;

        private double price;

        private int address;

        public Communication_Card()
        {
            InitializeComponent();
            RemplirListView_CommunicationCard();
            Remplir_cbProtocol();
            Remplir_cbBaudRate();
            Remplir_cbParity();
        }

        private void mnuItem_delete_Click(object sender, EventArgs e)
        {
            SupprimerCommunicationCard();
            RemplirListView_CommunicationCard();
        }

        private void pictureBox_new_Click(object sender, EventArgs e)
        {
            listView_communicationCards.Enabled = false;
            grpBox_communicationCard.Visible = true;
            grpBox_button.Visible = false;
            btn_save.Visible = true;
            btn_update.Visible = false;

            Remplir_cbProtocol();
            Remplir_cbBaudRate();
            Remplir_cbParity();
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

        private void pictureBox_addProtocol_Click(object sender, EventArgs e)
        {
            /*
            string answer = Microsoft.VisualBasic.Interaction.InputBox("Add a new protocol : ", "Add Protocol", "");
            if (answer != "")
            {
                AjouterProtocol(answer);
                Remplir_cbProtocol();
            }
            */

            AjouterProtocol();
            Remplir_cbProtocol();
        }

        private void cbBox_protocol_SelectedIndexChanged(object sender, EventArgs e)
        {
            ChangerPrix();
        }

        private void pictureBox_addBaudRate_Click(object sender, EventArgs e)
        {
            string answer = Microsoft.VisualBasic.Interaction.InputBox("Add a new protocol : ", "Add BaudRate", "");
            if (answer != "")
            {
                AjouterBaudRate(answer);
                Remplir_cbBaudRate();
            }
        }

        private void pictureBox_addParity_Click(object sender, EventArgs e)
        {
            string answer = Microsoft.VisualBasic.Interaction.InputBox("Add a new parity : ", "Add Parity", "");
            if (answer != "")
            {
                AjouterParity(answer);
                Remplir_cbParity();
            }
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            AjouterCommunicationCard();
            RemplirListView_CommunicationCard();
        }

        private void btn_cancelAddOrUpdate_Click(object sender, EventArgs e)
        {
            ViderInformation();

            listView_communicationCards.Enabled = true;

            grpBox_button.Visible = true;
            grpBox_communicationCard.Visible = false;
        }

        private void listView_communicationCards_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            lastItemChecked = listView_communicationCards.Items[e.Index];
        }

        private void listView_communicationCards_DoubleClick(object sender, EventArgs e)
        {
            listView_communicationCards.Enabled = false;
            grpBox_button.Visible = false;
            grpBox_communicationCard.Visible = true;
            btn_save.Visible = false;
            btn_update.Visible = true;

            AfficherListView_CommunicationCardInformations();
        }

        private void btn_update_Click(object sender, EventArgs e)
        {
            ModifierListView_CommunicationCard();
        }

        private void RemplirListView_CommunicationCard()
        {
            string stSQL = "SELECT [pgm_communicationCard].communicationCard_Description, [pgm_communicationCard_protocol].protocol_Price, " +
                "[pgm_communicationCard].communicationCard_Address, [pgm_communicationCard].communicationCard_Protocol, " + 
                "[pgm_communicationCard].communicationCard_BaudRate, [pgm_communicationCard].communicationCard_Parity " + 
                "FROM [pgm_communicationCard] INNER JOIN [pgm_communicationCard_protocol] ON [pgm_communicationCard].communicationCard_Protocol = [pgm_communicationCard_protocol].protocol_No " +
                "INNER JOIN [pgm_communicationCard_baudRate] ON [pgm_communicationCard].communicationCard_BaudRate = [pgm_communicationCard_baudRate].baudRate_Item " +
                "INNER JOIN [pgm_communicationCard_parity] ON [pgm_communicationCard].communicationCard_parity = [pgm_communicationCard_parity].parity_No";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            listView_communicationCards.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem listViewItem = listView_communicationCards.Items.Add("");
                listViewItem.UseItemStyleForSubItems = false;
                for (int i = 0; i < Oreadr.FieldCount; i++) listViewItem.SubItems.Add(Oreadr[i].ToString());
            }
            Oconn.Close();
        }

        private void Remplir_cbProtocol()
        {
            cbBox_protocol.Items.Clear();
            string stSQL = "SELECT [pgm_communicationCard_protocol].* FROM [pgm_communicationCard_protocol]";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
                cbBox_protocol.Items.Add(Oreadr["protocol_No"].ToString() + " - " + Oreadr["protocol_Description"].ToString());
            Oconn.Close();
        }

        private void Remplir_cbBaudRate()
        {
            List<int> list = new List<int>();
            cbBox_baudRate.Items.Clear();
            string stSQL = "SELECT [pgm_communicationCard_baudRate].* FROM [pgm_communicationCard_baudRate]";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
                list.Add(Convert.ToInt32(Oreadr["baudRate_Item"].ToString()));
            Oconn.Close();

            list.Sort();
            for (int i = 0; i < list.Count; i++) cbBox_baudRate.Items.Add(list[i]);
        }

        private void Remplir_cbParity()
        {
            cbBox_parity.Items.Clear();
            string stSQL = "SELECT [pgm_communicationCard_parity].* FROM [pgm_communicationCard_parity]";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read()) 
                cbBox_parity.Items.Add(Oreadr["parity_No"].ToString() + " - " + Oreadr["parity_Description"].ToString());
            Oconn.Close();
        }

        private void SupprimerCommunicationCard()
        {
            for (int i = listView_communicationCards.SelectedItems.Count - 1; i > -1; i--)
            {
                int id = VerifierCommunicationCard(listView_communicationCards.SelectedItems[i].SubItems[1].Text,
                    Tools.Conv_Dbl(listView_communicationCards.SelectedItems[i].SubItems[2].Text),
                    Convert.ToInt32(listView_communicationCards.SelectedItems[i].SubItems[3].Text),
                    Convert.ToInt32(listView_communicationCards.SelectedItems[i].SubItems[4].Text),
                    Convert.ToInt32(listView_communicationCards.SelectedItems[i].SubItems[5].Text),
                    Convert.ToInt32(listView_communicationCards.SelectedItems[i].SubItems[6].Text));
                if (id != 0)
                {
                    string stSQL = "DELETE FROM [pgm_communicationCard] WHERE [pgm_communicationCard].communicationCard_Id=" + id;
                    MainMDI.ExecSql(stSQL);
                }
            }
        }

        private int VerifierCommunicationCard(string communicationCard_description, double protocol_price, 
                                                int communicationCard_address, int communicationCard_protocol, int communicationCard_baudRate,
                                                int communicationCard_parity)
        {
            int id = 0;
            string stSQL = "SELECT [pgm_communicationCard].* FROM [pgm_communicationCard]";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                if ((Oreadr["communicationCard_Description"].ToString() == communicationCard_description) &&
                    (VerifierProtocolPrice(protocol_price, communicationCard_protocol)) &&
                    (Convert.ToInt32(Oreadr["communicationCard_Address"].ToString()) == communicationCard_address) &&
                    (Convert.ToInt32(Oreadr["communicationCard_Protocol"].ToString()) == communicationCard_protocol) &&
                    (Convert.ToInt32(Oreadr["communicationCard_BaudRate"].ToString()) == communicationCard_baudRate) &&
                    (Convert.ToInt32(Oreadr["communicationCard_Parity"].ToString()) == communicationCard_parity))
                    id = Convert.ToInt32(Oreadr["communicationCard_Id"].ToString());
            }
            Oconn.Close();

            return id;
        }

        private bool VerifierProtocolPrice(double protocol_price, int protocol_No)
        {
            bool verifier = false;
            string stSQL = "SELECT [pgm_communicationCard_protocol].* FROM [pgm_communicationCard_protocol]";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                if ((Tools.Conv_Dbl(Oreadr["protocol_Price"].ToString()) == protocol_price) && 
                    (Convert.ToInt32(Oreadr["protocol_No"].ToString()) == protocol_No))
                    verifier = true;
            }
            Oconn.Close();

            return verifier;
        }

        private void ChangerPrix()
        {
            string protocol = cbBox_protocol.Text.Substring(cbBox_protocol.Text.Contains("- ") ? 
                cbBox_protocol.Text.IndexOf("-") + 2 : cbBox_protocol.Text.IndexOf("-") + 1);
            int protocolNo = Convert.ToInt32(cbBox_protocol.Text.Substring(0, RechercherComboBox(0, cbBox_protocol.Text)));

            string stSQL = "SELECT [pgm_communicationCard_protocol].* FROM [pgm_communicationCard_protocol] " +
                "WHERE protocol_No = " + protocolNo + " AND protocol_Description = '" + protocol + "'";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSQL;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
                txtBox_price.Text = Oreadr["protocol_Price"].ToString();
            Oconn.Close();
        }

        private void ViderInformation()
        {
            txtBox_description.Clear();
            txtBox_price.Clear();
            txtBox_address.Clear();

            cbBox_protocol.Items.Clear();
            cbBox_baudRate.Items.Clear();
            cbBox_parity.Items.Clear();
        }

        private void AjouterProtocol() //(string protocol)
        {
            //string protocolNo = answer.Substring(0, RechercherComboBox(0, answer));
            //string protocol = answer.Substring(answer.Contains("- ") ? answer.IndexOf("-") + 2 : answer.IndexOf("-") + 1);

            string cbBox_protocol_text = cbBox_protocol.Items[cbBox_protocol.Items.Count - 1].ToString();
            int protocolNo = Convert.ToInt32(cbBox_protocol_text.Substring(0, RechercherComboBox(0, cbBox_protocol_text))) + 1;

            /*
            string stSQL = "INSERT INTO [pgm_communicationCard_protocol] ([pgm_communicationCard_protocol].protocol_No, " + 
                "[pgm_communicationCard_protocol].protocol_Description) VALUES (" + 
                protocolNo + ", '" + 
                protocol + "')";
            MainMDI.ExecSql(stSQL);
            */

            Add_Protocol add_Protocol = new Add_Protocol(protocolNo);
            add_Protocol.ShowDialog();
        }

        private int RechercherComboBox(int count, string answer)
        {
            for (int i = 0; i < answer.Length; i++)
            {
                if ((answer[i] >= '0') && (answer[i] <= '9')) count++;
                if (answer[i] == '-') break;
            }
            return count;
        }

        private void AjouterBaudRate(string baudRate)
        {
            string stSQL = "INSERT INTO [pgm_communicationCard_baudRate] ([pgm_communicationCard_baudRate].baudRate_Item) VALUES (" + 
                baudRate + ")";
            MainMDI.ExecSql(stSQL);
        }

        private void AjouterParity(string parity)
        {
            //string parityNo = parity.Substring(0, RechercherComboBox(0, parity));
            //string parity = parity.Substring(parity.Contains("- ") ? parity.IndexOf("-") + 2 : parity.IndexOf("-") + 1);

            string cbBox_parity_text = cbBox_parity.Items[cbBox_parity.Items.Count - 1].ToString();
            int parityNo = Convert.ToInt32(cbBox_parity_text.Substring(0, RechercherComboBox(0, cbBox_parity_text))) + 1;

            string stSQL = "INSERT INTO [pgm_communicationCard_parity] ([pgm_communicationCard_parity].parity_No, " +
                "[pgm_communicationCard_parity].parity_Description) VALUES (" +
                parityNo + ", '" +
                parity + "')";
            MainMDI.ExecSql(stSQL);
        }

        private void AjouterCommunicationCard()
        {
            address = ((txtBox_address.Text != "") && (txtBox_address.Text.All(char.IsDigit))) ? Convert.ToInt32(txtBox_address.Text) : 0;

            string protocolNo = (cbBox_protocol.Text != "") ? cbBox_protocol.Text.Substring(0, cbBox_protocol.Text.Contains(" -") 
                    ? cbBox_protocol.Text.IndexOf("-") - 1 : 
                    cbBox_protocol.Text.IndexOf("-")) : 
                "0";
            string baudRateItem = (cbBox_baudRate.Text != "") ? cbBox_baudRate.Text : "0";
            string parityNo = (cbBox_parity.Text != "") ? cbBox_parity.Text.Substring(0, cbBox_parity.Text.Contains(" -") 
                    ? cbBox_parity.Text.IndexOf("-") - 1 :
                    cbBox_parity.Text.IndexOf("-")) : 
                "0";

            string stSQL = "INSERT INTO [pgm_communicationCard] ([pgm_communicationCard].communicationCard_Description, " + 
                "[pgm_communicationCard].communicationCard_Address, [pgm_communicationCard].communicationCard_Protocol, " +
                "[pgm_communicationCard].communicationCard_BaudRate, [pgm_communicationCard].communicationCard_Parity) VALUES ('" +
                txtBox_description.Text + "', " +
                address + ", " +
                protocolNo + ", " +
                baudRateItem + ", " + 
                parityNo + ")";
            MainMDI.ExecSql(stSQL);
        }

        private void AfficherListView_CommunicationCardInformations()
        {
            txtBox_description.Text = listView_communicationCards.SelectedItems[0].SubItems[1].Text;
            txtBox_price.Text = listView_communicationCards.SelectedItems[0].SubItems[2].Text;
            txtBox_address.Text = listView_communicationCards.SelectedItems[0].SubItems[3].Text;

            Remplir_cbProtocol();
            Remplir_cbBaudRate();
            Remplir_cbParity();

            cbBox_protocol.Text = Afficher_cbProtocolInformations(listView_communicationCards.SelectedItems[0].SubItems[4].Text);
            cbBox_baudRate.Text = Afficher_cbBaudRateInformations(listView_communicationCards.SelectedItems[0].SubItems[5].Text);
            cbBox_parity.Text = Afficher_cbParityInformations(listView_communicationCards.SelectedItems[0].SubItems[6].Text);
        }

        private string Afficher_cbProtocolInformations(string element)
        {
            for (int i = 0; i < cbBox_protocol.Items.Count; i++)
            {
                string indice = cbBox_protocol.Items[i].ToString().Substring(0, cbBox_protocol.Items[i].ToString().Contains(" -") ? 
                    cbBox_protocol.Items[i].ToString().IndexOf("-") - 1 : cbBox_protocol.Items[i].ToString().IndexOf("-"));
                if (indice == element) return cbBox_protocol.Items[i].ToString();
                if (element == "") return cbBox_protocol.Items[0].ToString();
            }
            return "";
        }

        private string Afficher_cbBaudRateInformations(string element)
        {
            for (int i = 0; i < cbBox_baudRate.Items.Count; i++)
            {
                if (element == cbBox_baudRate.Items[i].ToString()) return element;
                if (element == "") return cbBox_baudRate.Items[4].ToString();
            }
            return "";
        }

        private string Afficher_cbParityInformations(string element)
        {
            for (int i = 0; i < cbBox_parity.Items.Count; i++)
            {
                string indice = cbBox_parity.Items[i].ToString().Substring(0, cbBox_parity.Items[i].ToString().Contains(" -") ?
                    cbBox_parity.Items[i].ToString().IndexOf("-") - 1 : cbBox_parity.Items[i].ToString().IndexOf("-"));
                if (indice == element) return cbBox_parity.Items[i].ToString();
                if (element == "") return cbBox_parity.Items[0].ToString();
            }
            return "";
        }

        private void ModifierListView_CommunicationCard()
        {
            listView_communicationCards.SelectedItems[0].SubItems[1].Text = txtBox_description.Text;
            listView_communicationCards.SelectedItems[0].SubItems[2].Text = txtBox_price.Text;
            listView_communicationCards.SelectedItems[0].SubItems[3].Text = txtBox_address.Text;
            listView_communicationCards.SelectedItems[0].SubItems[4].Text = cbBox_protocol.Text.Substring(0, cbBox_protocol.Text.Contains(" -") ? 
                cbBox_protocol.Text.IndexOf("-") - 1 : cbBox_protocol.Text.IndexOf("-"));
            listView_communicationCards.SelectedItems[0].SubItems[5].Text = cbBox_baudRate.Text;
            listView_communicationCards.SelectedItems[0].SubItems[6].Text = cbBox_parity.Text.Substring(0, cbBox_parity.Text.Contains(" -") ? 
                cbBox_parity.Text.IndexOf("-") - 1 : cbBox_parity.Text.IndexOf("-"));
        }
    }
}
