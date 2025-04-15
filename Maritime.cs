using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace PGESCOM
{
    public partial class Maritime : Form
    {
        bool inc_checked = false;
        char inc_code = 'M';

        public Maritime(bool x_checked, char x_code)
        {
            InitializeComponent();
            inc_checked = x_checked;
            inc_code = x_code;
            RemplirListeDePrixDesMaritimes();
        }

        private void RemplirListeDePrixDesMaritimes()
        {
            string stSql = "SELECT COMPNT_PRICE_LIST.* FROM COMPNT_LIST INNER JOIN COMPNT_MANUFAC_FAMILY ON COMPNT_LIST.Component_ID = COMPNT_MANUFAC_FAMILY.Compnt_ID " +
                "INNER JOIN COMPNT_PRICE_LIST ON COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID = COMPNT_PRICE_LIST.compnt_man_Fam_ID WHERE COMPNT_LIST.COMPONENT_REF='ABS' " +
                "ORDER BY CAT4_VALUE";
            SqlConnection Oconn = new SqlConnection(MainMDI.M_stCon);
            Oconn.Open();
            SqlCommand Ocmd = Oconn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            lstView_Maritime.Items.Clear();
            while (Oreadr.Read())
            {
                AjouterItemsDansLstView_Maritimes(Oreadr["PRICE"].ToString(), Oreadr["CAT1_VALUE"].ToString(), Oreadr["CAT2_VALUE"].ToString(),
                    Oreadr["CAT3_VALUE"].ToString(), Oreadr["CAT4_VALUE"].ToString(), Oreadr["CAT5_VALUE"].ToString(), Oreadr["CAT6_VALUE"].ToString(), Oreadr["LeadTime"].ToString(),
                    Oreadr["PRICE_LINE_ID"].ToString(), Oreadr["PL_Code"].ToString());
                /*if ((MainMDI.Lang == 0) || (MainMDI.Lang == 2)) AjouterItemsDansLstView_Maritimes(Oreadr["PRICE"].ToString(), Oreadr["CAT1_VALUE"].ToString(), Oreadr["CAT2_VALUE"].ToString(),
                Oreadr["CAT3_VALUE"].ToString(), Oreadr["CAT4_VALUE"].ToString(), Oreadr["CAT5_VALUE"].ToString(), Oreadr["CAT6_VALUE"].ToString(), Oreadr["LeadTime"].ToString(),
                    Oreadr["PRICE_LINE_ID"].ToString(), Oreadr["PL_Code"].ToString());*/
                /*else AjouterItemsDansLstView_Maritimes(Oreadr["PRICE"].ToString(), Oreadr["CAT1_VALUE"].ToString(), Oreadr["CAT2_VALUE"].ToString(),
                    Oreadr["CAT3_VALUE"].ToString(), Oreadr["CAT4FR_VALUE"].ToString(), Oreadr["CAT5FR_VALUE"].ToString(), Oreadr["CAT6FR_VALUE"].ToString(), Oreadr["LeadTime"].ToString(),
                    Oreadr["PRICE_LINE_ID"].ToString(), Oreadr["PL_Code"].ToString());*/
            }
            for (int i = 0; i < lstView_Maritime.Items[0].SubItems.Count; i++) lstView_Maritime.Items[0].SubItems[i].BackColor = Color.Khaki;
            Oconn.Close();
        }

        private void AjouterItemsDansLstView_Maritimes(string price, string c1, string c2, string c3, string c4, string c5, string c6, string leadTime, string priceLine_id, string primaxCode)
        {
            ListViewItem listViewItem = lstView_Maritime.Items.Add("");

            string fullDescription = c4;
            if ((c5 != MainMDI.VIDE) && (c5 != "0")) fullDescription += ", " + c5;
            if ((c6 != MainMDI.VIDE) && (c6 != "0")) fullDescription += ", " + c6;

            listViewItem.UseItemStyleForSubItems = false;
            listViewItem.SubItems.Add(fullDescription);
            listViewItem.SubItems.Add(c1);
            listViewItem.SubItems.Add(c2);
            listViewItem.SubItems.Add(c3);
            listViewItem.SubItems.Add(price);
            listViewItem.SubItems.Add(price);
            listViewItem.SubItems.Add(price);
            listViewItem.SubItems.Add(leadTime);
            listViewItem.SubItems.Add(priceLine_id);
            listViewItem.SubItems.Add(primaxCode);
            lstView_Maritime.Items[0].Checked = inc_checked;
            if ((price == "0") && inc_checked)
            {
                listViewItem.UseItemStyleForSubItems = true;
                listViewItem.BackColor = Color.Khaki;
            }

            lstView_Maritime.Items[lstView_Maritime.Items.Count - 1].Checked = ((price == "0") && inc_checked);
        }

        private void lstView_Maritime_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            lstView_Maritime.Columns[3].Width = 200;
        }

        private void btn_ok_Click(object sender, System.EventArgs e)
        {
            lbl_save.Text = "Y";
            this.Hide();
        }

        private void btn_cancel_Click(object sender, System.EventArgs e)
        {
            lbl_save.Text = "N";
            this.Hide();
        }
    }
}
