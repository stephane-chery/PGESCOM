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
    public partial class dlg_Vaca_EvSELECT : Form
    {

        string[] in_arr_dep = new string[10];
        string[] in_arr_Event = new string[10];
        public dlg_Vaca_EvSELECT(ref string[] x_arr_Dep, ref string[]  x_arr_Event)
        {

            in_arr_dep = x_arr_Dep;
            in_arr_Event = x_arr_Event;
            
            InitializeComponent();


        }


        private void Fill_ListGrps()
        {


            string stSql = " SELECT *  FROM XCNG_EventGrp where ET_LID>1 ";


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_EVTYPE.Items.Clear();

            while (Oreadr.Read())
            {
                ListViewItem lv = ed_EVTYPE.Items.Add(Oreadr["ET_LID"].ToString());
                lv.SubItems.Add(Oreadr["GrpName"].ToString());
             //   lv.SubItems.Add(" ");
            //    int ndx = ed_EVTYPE.Items.Count - 1;
            //    ed_EVTYPE.Items[ndx].UseItemStyleForSubItems = false;

           //     string strclr = Oreadr["Grp_COLOR"].ToString();
           //     var ccc = System.Drawing.ColorTranslator.FromHtml(strclr);
           //     ed_EVTYPE.Items[ndx].SubItems[2].BackColor = ccc;
                lv.SubItems.Add(Oreadr["status"].ToString());
                lv.SubItems.Add(Oreadr["Grp_COLOR"].ToString());

            }

            OConn.Close();

        }




        void Fill_mdl_GrpItems(string Abr)
        {

            string CondAdmin=(MainMDI.User.ToLower ()=="shammou") ? " where USRadmin='" +  MainMDI.User.ToLower () +"'" : " ";
       //     string stSql = (Abr != "VA") ? "SELECT EventLID, Event_Name,EvType  FROM [Orig_PSM_FDB].[dbo].[XCNG_Events] where EvType='" + Abr + "' order by Ev_Start" : " SELECT [Depcode] ,[DepName],'VA'  FROM [Orig_PSM_FDB].[dbo].[XCNG_Departements] ";
            string stSql = (Abr != "VA") ? "SELECT EventLID, Event_Name,EvType  FROM [Orig_PSM_FDB].[dbo].[XCNG_Events] where EvType='" + Abr + "' order by Ev_Start" : " SELECT [Depcode] ,[DepName],'VA'  FROM [Orig_PSM_FDB].[dbo].[XCNG_Departements] " + CondAdmin;     
                  SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                   OConn.Open();
                   SqlCommand Ocmd = OConn.CreateCommand();
                   Ocmd.CommandText = stSql;
                   SqlDataReader Oreadr = Ocmd.ExecuteReader();
                   mdl_EventDep.Items.Clear(); 
                   while (Oreadr.Read())
                   {
                       ListViewItem lv = mdl_EventDep.Items.Add(" ");
                       lv.SubItems.Add(Oreadr[1].ToString());
                       lv.SubItems.Add(Oreadr[0].ToString());
                       lv.SubItems.Add(Oreadr[2].ToString());
                      // lv.Checked = true; 
   
                   }
                  OConn.Close();
             
        }

/*
        void fill_EventTypesOLD()
        {
            const int EvTypesNB=5;
            string[,] arr_EVType = new string[EvTypesNB , 2] { {"Vacations", "VA"}, 
                                                     {"QC Holidays", "HQ"},
                                                     {"US Holidays", "HU"},
                                                     {"Company Shutdown", "CS"},
                                                     {"Others", "OT"}
            };

            ed_EVTYPE.Items.Clear();  
            for (int i = 0; i < EvTypesNB; i++)
            {
                ListViewItem LV = ed_EVTYPE.Items.Add(" ");
                LV.SubItems.Add(arr_EVType[i, 0]);
                LV.SubItems.Add(arr_EVType[i, 1]); 
            }
        }

*/


        private void ed_EVTYPE_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            if (ed_EVTYPE.SelectedItems.Count ==1 )
            {
                mdl_EventDep.Items.Clear(); 
                int ndx = ed_EVTYPE.SelectedItems[0].Index;
                if (ed_EVTYPE.Items[ndx].Checked)
                {
                    Fill_mdl_GrpItems(ed_EVTYPE.Items[ndx].SubItems[2].Text);
                    lABR.Text = ed_EVTYPE.Items[ndx].SubItems[2].Text;
                }

            }
             * */
        }

        private void picSeek_Click(object sender, EventArgs e)
        {

        }

        private void dlg_Vaca_EvSELECT_Load(object sender, EventArgs e)
        {

            mdl_EventDep.Modifiable = false;

            if (MainMDI.User.ToLower() == "shammou")
            {
                ed_EVTYPE.Visible = false;

            }
            Fill_ListGrps();
            Fill_mdl_GrpItems("VA");
            Fill_ARRS();

        }

        private void pic_MoveR_Click(object sender, EventArgs e)
        {

        }

        void Fill_SELECTION_array()
        {

        }


        private void pic_GRPtoList_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < ed_EVTYPE.Items.Count; i++)
            {
                ListViewItem item1 =mdl_Selection.FindItemWithText(ed_EVTYPE.Items[i].SubItems[1].Text);
		        if (ed_EVTYPE.Items[i].Checked && item1 == null )
                {
                    ListViewItem Lv = mdl_Selection.Items.Add(" ");
                    Lv.SubItems.Add(ed_EVTYPE.Items[i].SubItems[1].Text);
                    Lv.SubItems.Add(ed_EVTYPE.Items[i].SubItems[2].Text);
                    Lv.SubItems.Add(ed_EVTYPE.Items[i].SubItems[3].Text);
                }

            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mdl_EventDep.Items.Count; i++)
            {
                ListViewItem item1 = mdl_Selection.FindItemWithText( mdl_EventDep.Items[i].SubItems[1].Text);
                if (mdl_EventDep.Items[i].Checked && item1 == null)
                {
                    ListViewItem Lv = mdl_Selection.Items.Add("");
                    Lv.SubItems.Add(mdl_EventDep.Items[i].SubItems[1].Text);
                    Lv.SubItems.Add(mdl_EventDep.Items[i].SubItems[2].Text);
                    Lv.SubItems.Add(lABR.Text  );
                }

            }
        }

        private void picDel_Click(object sender, EventArgs e)
        {
            if (mdl_Selection.SelectedItems.Count > 0) for (int i = mdl_Selection.SelectedItems.Count - 1; i > -1; i--) mdl_Selection.SelectedItems[i].Remove();
        }


        void Fill_ARRS()
        {
            for (int j = 0 ; j < in_arr_Event.Length ; j++)
            {
                if ( in_arr_Event[j]!="")
                {
                     for (int i = 0 ; i < ed_EVTYPE.Items.Count; i++) if (ed_EVTYPE.Items[i].SubItems[2].Text==in_arr_Event[j] ) ed_EVTYPE.Items[i].Checked =true;
                }
                else j=in_arr_Event.Length ;
            }

            for (int j = 0 ; j < in_arr_dep.Length ; j++)
            {
                if (in_arr_dep[j] != "")
                {
                    for (int i = 0; i < mdl_EventDep.Items.Count; i++) if (mdl_EventDep.Items[i].SubItems[2].Text == in_arr_dep[j]) mdl_EventDep.Items[i].Checked = true;
                }
                else j = in_arr_dep.Length;
            }

        }

        void init_ARRS()
        {
            for (int i = 0; i < in_arr_dep.Length; i++)
            {
                in_arr_dep[i] = "";
                in_arr_Event[i] = "";
            }
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            init_ARRS();

            for (int i = 0,j=0; i < ed_EVTYPE.Items.Count; i++)
                if (ed_EVTYPE.Items[i].Checked) in_arr_Event [j++] = ed_EVTYPE.Items[i].SubItems[0].Text;
            
            for (int i = 0,j=0; i <mdl_EventDep.Items.Count; i++)
                if (mdl_EventDep.Items[i].Checked) in_arr_dep[j++] = mdl_EventDep.Items[i].SubItems[2].Text;

            this.Hide();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
} 
