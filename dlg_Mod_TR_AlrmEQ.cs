using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PGESCOM
{
    public partial class dlg_Mod_TR_AlrmEQ: Form
    {
        Modified_EditListView in_mdl;
        int in_ndx = -1;

        public dlg_Mod_TR_AlrmEQ(ref Modified_EditListView x_mdl, int x_ndx)
        {
            InitializeComponent();
            in_mdl = x_mdl;
            in_ndx = x_ndx;
        }

        private void NewItm_Click(object sender, EventArgs e)
        {
            grpEntry.Visible = true;
            //Clear_Event();
            //lvacaID.Text = "";
            //btnSave.Text = "Save";
        }

        private void cbDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lCustLID.Text = MainMDI.get_CBX_value(cbCompanyy, cbCompanyy.SelectedIndex);
            //ldepID.Text = MainMDI.get_CBX_value(cbEvType, cbEvType.SelectedIndex);
        }

        private void dlg_Vaca_Conges_Load(object sender, EventArgs e)
        {
            txDesc.Text = in_mdl.Items[in_ndx].SubItems[1].Text;
            txReq.Text = in_mdl.Items[in_ndx].SubItems[2].Text;
            TST_REQ.Text = in_mdl.Items[in_ndx].SubItems[3].Text;

            txRelnb.Text = in_mdl.Items[in_ndx].SubItems[6].Text;
            TSTrlnb.Text = in_mdl.Items[in_ndx].SubItems[7].Text;

            txDelnb.Text = in_mdl.Items[in_ndx].SubItems[16].Text;
            TSTdelnb.Text = in_mdl.Items[in_ndx].SubItems[17].Text;

            txTimeOut.Text = in_mdl.Items[in_ndx].SubItems[8].Text;
            TSTtmo.Text = in_mdl.Items[in_ndx].SubItems[9].Text;

            //txmsgL.Text = in_mdl.Items[in_ndx].SubItems[10].Text;
            cbmsgL.Text = in_mdl.Items[in_ndx].SubItems[10].Text;
            cbTSTmsgL.Text = in_mdl.Items[in_ndx].SubItems[11].Text;

            //txRLL.Text = in_mdl.Items[in_ndx].SubItems[12].Text;
            cbRLL.Text = in_mdl.Items[in_ndx].SubItems[12].Text;
            cbTSTrelayL.Text = in_mdl.Items[in_ndx].SubItems[13].Text;

            //txFailS.Text = in_mdl.Items[in_ndx].SubItems[14].Text;
            cbFailS.Text = in_mdl.Items[in_ndx].SubItems[14].Text;
            cbTSTfailS.Text = in_mdl.Items[in_ndx].SubItems[15].Text;

            //txDelL.Text = in_mdl.Items[in_ndx].SubItems[18].Text;
            cbDelL.Text = in_mdl.Items[in_ndx].SubItems[18].Text;
            cbTSTDL.Text = in_mdl.Items[in_ndx].SubItems[19].Text;

            txCmnt.Text = in_mdl.Items[in_ndx].SubItems[20].Text;
        }

        private void grpEntry_Enter(object sender, EventArgs e)
        {

        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            in_mdl.Items[in_ndx].SubItems[1].Text = txDesc.Text;
            in_mdl.Items[in_ndx].SubItems[2].Text = txReq.Text;
            in_mdl.Items[in_ndx].SubItems[3].Text = TST_REQ.Text;

            in_mdl.Items[in_ndx].SubItems[6].Text = txRelnb.Text;
            in_mdl.Items[in_ndx].SubItems[7].Text = TSTrlnb.Text;

            in_mdl.Items[in_ndx].SubItems[8].Text = txTimeOut.Text;
            in_mdl.Items[in_ndx].SubItems[9].Text = TSTtmo.Text;

            in_mdl.Items[in_ndx].SubItems[10].Text = txmsgL.Text;
            in_mdl.Items[in_ndx].SubItems[11].Text = cbTSTmsgL.Text;

            in_mdl.Items[in_ndx].SubItems[12].Text = txRLL.Text;
            in_mdl.Items[in_ndx].SubItems[13].Text = cbTSTrelayL.Text;

            in_mdl.Items[in_ndx].SubItems[14].Text = txFailS.Text;
            in_mdl.Items[in_ndx].SubItems[15].Text = cbTSTfailS.Text;

            in_mdl.Items[in_ndx].SubItems[16].Text = txDelnb.Text;
            in_mdl.Items[in_ndx].SubItems[17].Text = TSTdelnb.Text;

            in_mdl.Items[in_ndx].SubItems[18].Text = txDelL.Text;
            in_mdl.Items[in_ndx].SubItems[19].Text = cbTSTDL.Text;
            in_mdl.Items[in_ndx].SubItems[20].Text = txCmnt.Text;
            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void cbmsgL_SelectedIndexChanged(object sender, EventArgs e)
        {
            txmsgL.Text = cbmsgL.Text;
        }

        private void cbRLL_SelectedIndexChanged(object sender, EventArgs e)
        {
            txRLL.Text = cbRLL.Text;
        }

        private void cbFailS_SelectedIndexChanged(object sender, EventArgs e)
        {
            txFailS.Text = cbFailS.Text;
        }

        private void cbDelL_SelectedIndexChanged(object sender, EventArgs e)
        {
            txDelL.Text = cbDelL.Text;
        }

        private void txmsgL_DoubleClick(object sender, EventArgs e)
        {
            cbmsgL.BringToFront();
        }

        private void txRLL_DoubleClick(object sender, EventArgs e)
        {
            cbRLL.BringToFront();
        }

        private void txFailS_DoubleClick(object sender, EventArgs e)
        {
            cbFailS.BringToFront();
        }

        private void txDelL_DoubleClick(object sender, EventArgs e)
        {
            cbDelL.BringToFront();
        }

        /*
        private void picSave_Click(object sender, EventArgs e)
        {

        }

        bool Event_exist(string EvName, string YYYY, string dtDEB, string dtFIN)
        {
            string res = MainMDI.Find_One_Field("Select  EventLID from XCNG_Events where Event_Name='" + EvName.Replace("'", "''") + "' AND [EvType]='" + lEvABR.Text + "' AND [YYYY]=" + YYYY + " AND [Ev_Start]=" + MainMDI.SSV_date(dtDEB) + " AND [Ev_End]=" + MainMDI.SSV_date(dtFIN));
            return (res != MainMDI.VIDE);
        }

        void Save_Event()
        {
            if ((cbTSTmsgL.Text != "" || cbTSTmsgL.Text != "") && txReq.Text.Length > 2)
            {
                if (!Event_exist(txReq.Text, DateTime.Now.Year.ToString(), dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString()))
                {
                    if (lEventLID.Text == "")
                    {
                        string stSql = " INSERT INTO XCNG_Events ([Event_Name],[YYYY],[Ev_Start], [Ev_End], [EvType] ) " +
                            " VALUES ('" + txReq.Text.Replace("'", "''") +
                            "', " + DateTime.Now.Year.ToString() +
                            ", " + MainMDI.SSV_date(dateTimePicker1.Value.ToShortDateString()) +
                            ", " + MainMDI.SSV_date(dateTimePicker2.Value.ToShortDateString()) +
                            ", '" + lEvABR.Text + "')";

                        MainMDI.Exec_SQL_JFS(stSql, "Events");
                    }
                    else
                    {
                        if (txReq.Text.Length > 2)
                        {
                            string stSql = " UPDATE XCNG_Events SET [Event_Name]='" + txReq.Text.Replace("'", "''") + "',  [Ev_Start]=" + MainMDI.SSV_date(dateTimePicker1.Value.ToShortDateString()) +
                                ", [Ev_End]=" + MainMDI.SSV_date(dateTimePicker2.Value.ToShortDateString()) + " where EventLID=" + lEventLID.Text;
                            MainMDI.Exec_SQL_JFS(stSql, "Events");
                        }
                    }
                    Clear_Event();
                }
                else MessageBox.Show("Event / Holiday already Exists.........");
            }
            else MessageBox.Show("Event Name is Invalid ....");
        }

        void Clear_Event()
        {
            btnSave.Text = "Save";
            //cbEvType.Text = cbEvType.Items[0].ToString();
            cbTSTmsgL.Enabled = true;
            txReq.Clear();

            lEventLID.Text = "";
        }

        private void Fill_Events_Holi(string evABR)
        {
            string stSql = " SELECT *  FROM [Orig_PSM_FDB].[dbo].[XCNG_Events]  where EvType='" + evABR + "' and YYYY =" + DateTime.Now.Year.ToString() + " order by Ev_Start ";

            SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            string stdate = "";
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvITM.Items.Add(Oreadr["EventLID"].ToString());
                lv.SubItems.Add(Oreadr["Event_Name"].ToString());

                DateTime dt1;
                stdate = (DateTime.TryParse(Oreadr["Ev_Start"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                lv.SubItems.Add(stdate);

                stdate = (DateTime.TryParse(Oreadr["Ev_End"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                lv.SubItems.Add(stdate);

                lv.SubItems.Add(Oreadr["EvType"].ToString());
            }
            OConn.Close();
        }

        private void ed_lvITM_DoubleClick(object sender, EventArgs e)
        {
            grpEntry.Visible = true;
            int ndx = ed_lvITM.SelectedItems[0].Index;
            lEventLID.Text = ed_lvITM.Items[ndx].SubItems[0].Text;
            cbTSTmsgL.Text = EventColor_Name('N', ed_lvITM.Items[ndx].SubItems[4].Text);
            txReq.Text = ed_lvITM.Items[ndx].SubItems[1].Text;
            dateTimePicker1.Text = ed_lvITM.Items[ndx].SubItems[2].Text;
            dateTimePicker2.Text = ed_lvITM.Items[ndx].SubItems[3].Text;
            cbTSTmsgL.Enabled = false;
            btnSave.Text = "Update";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Save_Event();
            Fill_Events_Holi(lEvABR.Text);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //cbEmployees.Enabled = true;
            cbTSTmsgL.Enabled = true;
            grpEntry.Visible = false;
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        string EventColor_Name(char c,string EventName)
        {
            switch (EventName)
            {
                case "HQ":
                case "QC Holidays":
                    if (c == 'C') return Color.Blue.Name;
                    if (c == 'T') return "QC Holidays";
                    if (c == 'A') return "HQ";
                    break;
                case "HU":
                case "US Holidays":
                    if (c == 'C') return Color.Chocolate.Name;
                    if (c == 'T') return "US Holidays";
                    if (c == 'A') return "HU";
                    break;
                case "CS":
                case "Company Shutdown":
                    if (c == 'C') return Color.Red.Name;
                    if (c == 'T') return "Company Shutdown";
                    if (c == 'A') return "CS";
                    break;
                case "OT":
                case "Others":
                    if (c == 'C') return Color.Green.Name;
                    if (c == 'T') return "Others";
                    if (c == 'A') return "OT";
                    break;
            }
            return MainMDI.VIDE;
        }

        private void cbEvType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lEvABR.Text = EventColor_Name('A', cbTSTmsgL.Text);
            lcolorName.Text = EventColor_Name('C', cbTSTmsgL.Text);
            lcolor.BackColor = Color.FromName(lcolorName.Text);

            Fill_Events_Holi(lEvABR.Text);
        }

        private void piccopy_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value;
        }

        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Del_itm_Click(object sender, EventArgs e)
        {
            Del_Event();
        }

        private void Del_Event()
        {
            //delete only on Listview
            //if (ed_lvITM.SelectedItems.Count > 0) for (int i = ed_lvITM.SelectedItems.Count - 1; i > -1; i--) ed_lvITM.SelectedItems[i].Remove();
            if (ed_lvITM.SelectedItems.Count > 0) for (int i = ed_lvITM.SelectedItems.Count - 1; i > -1; i--)
            {
                MainMDI.Exec_SQL_JFS("delete XCNG_Events where  EventLID=" + ed_lvITM.Items[ed_lvITM.SelectedItems[i].Index].SubItems[0].Text, "Events");
                //ed_lvITM.SelectedItems[i].Remove();
            }
            Fill_Events_Holi(lEvABR.Text);
        }
        */
    }
}