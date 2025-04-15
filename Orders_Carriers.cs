using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using EAHLibs;

namespace PGESCOM
{
    public partial class Orders_Carriers : Form
    {
        private string in_brdLID = "";
        private int cur_LV_ndx = -1;
        private char in_cod;
        private EAHLibs.Lib1 Tools = new Lib1();
        private string lITMLID = "";

        public Orders_Carriers()
        {
            InitializeComponent();

            //in_brdLID = x_brdLID;
            //in_cod = x_cod;

            fill_Itms();
            //ed_lvITM.AddEditableCell(-1, 2); //lvAllProjects.AddEditableCell(-1, jj)
            //ed_lvITM.AddEditableCell(-1, 3);
        }

        private void fill_Itms()
        {
            clr_scrn_info();
            //if (cur_LV_ndx > -1) grpITM.Visible = false;
            cur_LV_ndx = -1;
            string stSql = "select * from PSM_Carriers where c_Name <> '" + MainMDI.VIDE + "'";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvITM.Items.Add(Oreadr["Carrier_LID"].ToString());
                lv.SubItems.Add(Oreadr["c_Name"].ToString());
                lv.SubItems.Add(Oreadr["c_Tel"].ToString());
                lv.SubItems.Add(Oreadr["c_AcctNB"].ToString());
                lv.SubItems.Add(Oreadr["c_Details"].ToString());
            }
            OConn.Close();
        }

        private void NewItm_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_SHP", true))
            {
                editLV();
                cur_LV_ndx = -1;
                ListViewItem lv = ed_lvITM.Items.Add("");
                lv.SubItems.Add("------");
                lv.SubItems.Add(MainMDI.VIDE);
                lv.SubItems.Add(MainMDI.VIDE);
                lv.SubItems.Add(MainMDI.VIDE);
                lv.BackColor = Color.Lavender;
            }
        }

        private void clr_scrn_info()
        {

        }

        private bool fields_OK(int ndx)
        {
            bool res = true;
            if (ed_lvITM.Items[ndx].SubItems[0].Text == "")
            {
                if (ed_lvITM.Items[ndx].SubItems[1].Text == "------")
                {
                    res = false;
                    MessageBox.Show("Carrier Name is Invalid....line=" + Convert.ToString(ndx + 1));
                }
                else
                {
                    if (MainMDI.Find_One_Field("select  Carrier_LID from PSM_Carriers where c_Name = '" + ed_lvITM.Items[ndx].SubItems[1].Text + "'") != MainMDI.VIDE)
                    {
                        res = false;
                        MessageBox.Show("Carrier Already exists.....");
                    }
                }
            }
            return res;
        }

        /*
        private bool fields_OK()
        {
            bool res = true;
            if (txR_date.Text == "")
            {
                res = false;
                MessageBox.Show("Date is Invalid....");
                txR_date.Focus();
            }
            else
            {
                if (Tools.Conv_Dbl(tXrate.Text) == 0)
                {
                    res = false;
                    MessageBox.Show("Xchange Rate is Invalid..");
                    tXrate.Focus();
                }
            }
            return res;
        }
        * */

        private bool dateExist(string dt)
        {
            for (int i = 0; i < ed_lvITM.Items.Count; i++)
                if (ed_lvITM.Items[i].SubItems[1].Text == dt) return true;
            return false;
        }

        private void Sav_Itm_Click(object sender, EventArgs e)
        {
            string stSql = "";
            if (MainMDI.ALWD_USR("OR_SHP", true))
            {
                for (int i = 0; i < ed_lvITM.Items.Count; i++)
                {
                    if (fields_OK(i))
                    {
                        if (ed_lvITM.Items[i].SubItems[0].Text == "")
                        {
                            stSql = "insert into PSM_Carriers ([c_Name], [c_Tel], [c_AcctNB], [c_Details]) Values ('"
                                + ed_lvITM.Items[i].SubItems[1].Text.Replace("'", "''") + "', '" +
                                ed_lvITM.Items[i].SubItems[2].Text + "', '" +
                                ed_lvITM.Items[i].SubItems[3].Text + "', '" +
                                ed_lvITM.Items[i].SubItems[4].Text + "')";
                            MainMDI.Exec_SQL_JFS(stSql, " Inser New carrier....Order");
                        }
                        else
                        {
                            //" [XR_Date]=" + MainMDI.SSV_date(txR_date.Text) +
                            stSql = "UPDATE PSM_Carriers  SET " +
                                " [c_Name]='" + ed_lvITM.Items[i].SubItems[1].Text +
                                "', [c_Tel]='" + ed_lvITM.Items[i].SubItems[2].Text +
                                "', [c_AcctNB]='" + ed_lvITM.Items[i].SubItems[3].Text +
                                "', [c_Details]='" + ed_lvITM.Items[i].SubItems[4].Text +
                                "' WHERE Carrier_LID=" + ed_lvITM.Items[i].SubItems[0].Text;
                            MainMDI.Exec_SQL_JFS(stSql, "Update PSM_Carriers....");
                        }
                    }
                }
            }
            fill_Itms();
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ed_lvITM_DoubleClick(object sender, EventArgs e)
        {
            //No date change : delete and insert new date
            /*
            if (MainMDI.ALWD_USR("ST_ACT", true))
            {
                cur_LV_ndx = ed_lvITM.SelectedItems[0].Index;
                Edit_ITM(cur_LV_ndx);
            }
            */
        }

        private void Edit_ITM(int lv_ndx)
        {

        }

        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dpdate_ValueChanged(object sender, EventArgs e)
        {
            //txR_date.Text = dpdate.Value.ToShortDateString();
        }

        private void tXrate_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = Tools.OnlyDBL(e.KeyChar);
            if (e.KeyChar == 13) tXrate_MouseLeave(sender, e);
        }

        private void txR_date_TextChanged(object sender, EventArgs e)
        {

        }

        private void txR_date_DoubleClick(object sender, EventArgs e)
        {
            //dpdate.BringToFront();
        }

        private void tXrate_TextChanged(object sender, EventArgs e)
        {
            MessageBox.Show("Hiiiiiiiiiiiiiiiiii");
        }

        private void picNew_Click(object sender, EventArgs e)
        {

        }

        private void tXrate_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void tXrate_MouseLeave(object sender, EventArgs e)
        {
            MessageBox.Show("Hooooooooooooooo");
        }

        private void del_BRD_Click(object sender, EventArgs e)
        {
            int ndx = ed_lvITM.SelectedItems[0].Index;
            if (MainMDI.Confirm("want to delete this rate ?"))
            {
                MainMDI.Exec_SQL_JFS("delete  PSM_R_SBill_XRate where XR_LID=" + ed_lvITM.Items[ndx].SubItems[0].Text, " delete Xchange rate..");
                fill_Itms();
            }
        }

        private void Setng_002_Load(object sender, EventArgs e)
        {
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
        }

        private void editLV()
        {
            if (MainMDI.ALWD_USR("OR_SHP", true)) for (int i = 1; i < 5; i++) ed_lvITM.AddEditableCell(-1, i);
        }

        private void Modif_Click(object sender, EventArgs e)
        {
            editLV();
        }
    }
}