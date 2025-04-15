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
    public partial class dlg_Vaca_Events : Form
    {
        public dlg_Vaca_Events()
        {
            InitializeComponent();
           // BackColor = Color.Transparent;
        }

        private void NewItm_Click(object sender, EventArgs e)
        {



            grpEntry.Visible = true;
            Clear_Event ();
 //           lvacaID.Text = "";
  //          btnSave.Text = "Save"; 

        }

  

        private void cbDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lCustLID.Text = MainMDI.get_CBX_value(cbCompanyy, cbCompanyy.SelectedIndex);
           // ldepID.Text = MainMDI.get_CBX_value(cbEvType, cbEvType.SelectedIndex);   
           
        }

        private void dlg_Vaca_Conges_Load(object sender, EventArgs e)
        {
       //     cbEvType.Text = cbEvType.Items[0].ToString();
         //   Fill_Events_Holi(cbEvType.Text[0]  );
   

        }

  

        private void picSave_Click(object sender, EventArgs e)
        {

        }

        bool Event_exist(string EvName, string YYYY, string dtDEB, string dtFIN)
        {
            string res = MainMDI.Find_One_Field("Select  EventLID from XCNG_Events where Event_Name='" + EvName.Replace ("'","''") + "' AND [EvType]='" +lEvGrpID.Text    + "' AND [YYYY]=" + YYYY + " AND [Ev_Start]=" + MainMDI.SSV_date(dtDEB) + " AND [Ev_End]=" + MainMDI.SSV_date(dtFIN));
            return (res != MainMDI.VIDE);
        
        }


        bool GrpName_exist(string GrpName)
        {
            string res = MainMDI.Find_One_Field("Select  ET_LID from XCNG_EventGrp where GrpName='" +GrpName +"'");
            return (res != MainMDI.VIDE);

        }
        bool GrpCOLOR_exist(string GrpColor)
        {
            string res = MainMDI.Find_One_Field("Select  ET_LID from XCNG_EventGrp where Grp_COLOR='" + GrpColor + "'");
            return (res != MainMDI.VIDE);

        }

        void Save_Event()
        {
            if ((cbEvType.Text != "" || cbEvType.Text != "") && txEVname.Text.Length > 2)
            {
                if (!Event_exist(txEVname.Text, DateTime.Now.Year.ToString(), dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString()))
                {
                   
                    if (lEventLID.Text == "")
                    {
                        string stSql = " INSERT INTO XCNG_Events ([Event_Name],[YYYY],[Ev_Start], [Ev_End], [EvType] ) " +
                       " VALUES ('" + txEVname.Text.Replace ("'","''") +
                       "', " + DateTime.Now.Year.ToString() +
                       ", " + MainMDI.SSV_date(dateTimePicker1.Value.ToShortDateString()) +
                         ", " + MainMDI.SSV_date(dateTimePicker2.Value.ToShortDateString()) +
                      ", '" + lEvGrpID.Text + "')";

                        MainMDI.Exec_SQL_JFS(stSql, "Events");
                    }
                    else
                    {
                        if (txEVname.Text.Length > 2)
                        {
                            string stSql = " UPDATE XCNG_Events SET [Event_Name]='" + txEVname.Text.Replace("'", "''") + "',  [Ev_Start]=" + MainMDI.SSV_date(dateTimePicker1.Value.ToShortDateString()) +
                                  ", [Ev_End]=" + MainMDI.SSV_date(dateTimePicker2.Value.ToShortDateString()) + " where EventLID=" + lEventLID.Text;
                            MainMDI.Exec_SQL_JFS(stSql, "Events");
                        }
                    }

                    Clear_Event ();
                }
                else MessageBox.Show("Event / Holiday already Exists........."); 
            }
            else MessageBox.Show("Event Name is Invalid ...."); 

        }

        void Save_EventGRP()
        {
            if ((cbEvType.Text != "" || cbEvType.Text != "") && txEVname.Text.Length > 2)
            {
                if (!Event_exist(txEVname.Text, DateTime.Now.Year.ToString(), dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString()))
                {

                    if (lEventLID.Text == "")
                    {
                        string stSql = " INSERT INTO XCNG_Events ([Event_Name],[YYYY],[Ev_Start], [Ev_End], [EvType] ) " +
                       " VALUES ('" + txEVname.Text.Replace("'", "''") +
                       "', " + DateTime.Now.Year.ToString() +
                       ", " + MainMDI.SSV_date(dateTimePicker1.Value.ToShortDateString()) +
                         ", " + MainMDI.SSV_date(dateTimePicker2.Value.ToShortDateString()) +
                      ", '" + lEvGrpID.Text + "')";

                        MainMDI.Exec_SQL_JFS(stSql, "Events");
                    }
                    else
                    {
                        if (txEVname.Text.Length > 2)
                        {
                            string stSql = " UPDATE XCNG_Events SET [Event_Name]='" + txEVname.Text.Replace("'", "''") + "',  [Ev_Start]=" + MainMDI.SSV_date(dateTimePicker1.Value.ToShortDateString()) +
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

        void Save_GRP()
        {
            if (txNgrp.Text != "" && lcolorGRP.BackColor != Color.White ) 
            {

                if (lGRPid.Text == "")
                {

                    if (!GrpName_exist(txNgrp.Text) && !GrpCOLOR_exist(lClrName.Text))
                    {

                        string stSql = " INSERT INTO XCNG_EventGrp ([GrpName],[Grp_COLOR],[status] ) " +
                " VALUES ('" + txNgrp.Text.Replace("'", "''") +
                       "', '" + lClrName.Text + "', 'U')";

                        MainMDI.Exec_SQL_JFS(stSql, "New Events Group ");
                    }
                    else MessageBox.Show("Event Group / Color already Exists.........");
                }
                else
                {

                    if (txNgrp.Text != "")
                    {
                        string stSql = " UPDATE XCNG_EventGrp SET [GrpName]='" + txNgrp.Text.Replace("'", "''") + "',  [Grp_COLOR]='" + lClrName.Text +
                              "'  where ET_LID=" + lGRPid.Text;
                        MainMDI.Exec_SQL_JFS(stSql, "Update Events Group..");
                 
                    }
                    else MessageBox.Show("Group Name is Invalid ....");
          
                }

                    Clear_Grp();
            
            }
            else MessageBox.Show("IVALID:  Group Name / Color  ....");

        }


        private void fill_CBGrps()
        {
          //  cbEvType.Items.Clear();  
            string stsql = " SELECT  [GrpName]  ,[ET_LID] FROM [Orig_PSM_FDB].[dbo].[XCNG_EventGrp] where ET_LID>1 order by GrpName ";
           MainMDI.fill_Any_CB(cbEvType , stsql, true, "Select Group");

        }
 

        void Clear_Event()
        {
            btnSave.Text = "Save";
            cbEvType.Enabled = true;
            txEVname.Clear(); 
            lEventLID.Text = "";

      //      Fill_Events(lEvGrpID.Text);

        }
        void Clear_Grp()
        {
            button1.Text = "Save";
                   
            txNgrp.Clear();
            lcolorGRP.BackColor = Color.White;

            lGRPid.Text = "";
            btnDel.Enabled = true;
            
        }
        private void Fill_ListGrps()
        {


            string stSql = " SELECT *  FROM XCNG_EventGrp  where ET_LID>1 ";


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
           Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            mdl_GrpE.Items.Clear();
       
            while (Oreadr.Read())
            {
                ListViewItem lv = mdl_GrpE.Items.Add(Oreadr["ET_LID"].ToString());
                lv.SubItems.Add(Oreadr["GrpName"].ToString());
                lv.SubItems.Add(" ");
                int ndx=mdl_GrpE.Items.Count -1;
                mdl_GrpE.Items[ndx].UseItemStyleForSubItems = false;

                string strclr = Oreadr["Grp_COLOR"].ToString();
                var ccc = System.Drawing.ColorTranslator.FromHtml(strclr);
                mdl_GrpE.Items[ndx].SubItems[2].BackColor = ccc;
                lv.SubItems.Add(Oreadr["status"].ToString());
                lv.SubItems.Add(Oreadr["Grp_COLOR"].ToString());
        
            }

            OConn.Close();



        }



        private void Fill_Events(string evABR)
        {

         
            string stSql = " SELECT *  FROM [Orig_PSM_FDB].[dbo].[XCNG_Events]  where EvType='" + evABR  + "' and YYYY =" + DateTime.Now.Year.ToString() +" order by Ev_Start ";   


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open(); 
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            string stdate="";
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvITM.Items.Add(Oreadr["EventLID"].ToString());
                lv.SubItems.Add(Oreadr["Event_Name"].ToString());

                 DateTime dt1;
                 stdate = (DateTime.TryParse(Oreadr["Ev_Start"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                 lv.SubItems.Add(stdate );

                 stdate = (DateTime.TryParse(Oreadr["Ev_End"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                 lv.SubItems.Add(stdate);

                 lv.SubItems.Add(Oreadr["EvType"].ToString());

             }

            OConn.Close();



        }

        private void ed_lvITM_DoubleClick(object sender, EventArgs e)
        {
            grpEntry.Visible = true; 
            int ndx= ed_lvITM.SelectedItems[0].Index ;
            lEventLID.Text =ed_lvITM.Items[ndx].SubItems[0].Text ;
            cbEvType.Text = EventColor_Name ('N',  ed_lvITM.Items[ndx].SubItems[4].Text);
            txEVname.Text = ed_lvITM.Items[ndx].SubItems[1].Text; 
            dateTimePicker1.Text = ed_lvITM.Items[ndx].SubItems[2].Text;
            dateTimePicker2.Text = ed_lvITM.Items[ndx].SubItems[3].Text;
            cbEvType.Enabled = false;
            btnSave.Text = "Update";
   
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
                        if (MainMDI.ALWD_USR("GESTP_Events_RW", true))
            {
                if (cbEvType.Text != "Select Group")
                {
                    Save_Event();
                    Fill_Events(lEvGrpID.Text);
                }
                else MessageBox.Show("Event Grou is INVALID....!!!"); 
            }
                //        else MessageBox.Show("ACCESS Denied....!!!!!"); 
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
           // cbEmployees.Enabled = true;
            cbEvType.Enabled = true;
            btnSave.Text = "Save";
            lEventLID.Text = "";
           // grpEntry.Visible = false; 
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
            lEvGrpID.Text = MainMDI.get_CBX_value(cbEvType, cbEvType.SelectedIndex);
            if (lEvGrpID.Text != "0")
            {
                lcolorName.Text = MainMDI.Find_One_Field("select [Grp_COLOR] from [XCNG_EventGrp] where ET_LID=" + lEvGrpID.Text);

                var ccc = System.Drawing.ColorTranslator.FromHtml(lcolorName.Text);
                lcolor.BackColor = ccc;

                Fill_Events(lEvGrpID.Text);
            }
        }

        private void piccopy_Click(object sender, EventArgs e)
        {
            dateTimePicker2.Value = dateTimePicker1.Value;  
        }



        private void Del_itm_Click(object sender, EventArgs e)
        {
            Clear_Event();
            grpEvnt.Visible = true; 
            grpEvnt.BringToFront();
            ed_lvITM.Visible = true; 
            ed_lvITM.BringToFront();
            fill_CBGrps();
            Fill_Events(lEvGrpID.Text);
        }

        private void Del_Event()
        {
            if (ed_lvITM.SelectedItems.Count > 0 && MainMDI.Confirm("Want to delete  ???"))
            {
                for (int i = ed_lvITM.SelectedItems.Count - 1; i > -1; i--) MainMDI.Exec_SQL_JFS("delete XCNG_Events where  EventLID=" + ed_lvITM.Items[ed_lvITM.SelectedItems[i].Index].SubItems[0].Text, "Events");
                Fill_Events(lEvGrpID.Text);
            }

        }

        private void Del_GrpEvent()
        {
            if (mdl_GrpE.SelectedItems.Count > 0 && MainMDI.Confirm(" Want to delete (all linked Events will be deleted ) ???"))
            {
                for (int i = mdl_GrpE.SelectedItems.Count - 1; i > -1; i--)
                {
                    if (mdl_GrpE.Items[mdl_GrpE.SelectedItems[i].Index].SubItems[3].Text=="U")
                    {
                    MainMDI.Exec_SQL_JFS("delete XCNG_EventGrp where  ET_LID=" + mdl_GrpE.Items[mdl_GrpE.SelectedItems[i].Index].SubItems[0].Text, "Grp Events deleted");
                    MainMDI.Exec_SQL_JFS("delete [XCNG_Events] where  EvType=" + mdl_GrpE.Items[mdl_GrpE.SelectedItems[i].Index].SubItems[0].Text, "Events linked to grp delete");
                    }
                    else MessageBox.Show("can not delete This Group.....");
                    }
                    Fill_ListGrps ();
            }

        }


        private void btnSelColor_Click(object sender, EventArgs e)
        {
      //   Color clr= get_Color();

            string clrHex = get_ColorHex();
            var ccc = System.Drawing.ColorTranslator.FromHtml(clrHex);
            lcolorGRP.BackColor = ccc;
            lClrName.Text = clrHex;// ccc.Name; 
           //  lClrName.BackColor = ccc;
             

                        
 
        }



        private string Get_ColorName()
        {
            string clr = MainMDI.VIDE; 
            ColorDialog dlg = new ColorDialog();
            dlg.AllowFullOpen = false;
            if (dlg.ShowDialog() == DialogResult.OK)     clr = dlg.Color.Name;
            
            return clr;
        }
        private string get_ColorHex()
        {
            Color clr = Color.White;
            ColorDialog dlg = new ColorDialog();
            dlg.AllowFullOpen = false;
            if (dlg.ShowDialog() == DialogResult.OK) clr = dlg.Color;

            return ColorTranslator.ToHtml (clr);
        }

        private Color get_Color()
        {

            Color clr = Color.White;
            ColorDialog dlg = new ColorDialog();
            dlg.AllowFullOpen = false;
            if (dlg.ShowDialog() == DialogResult.OK) clr = dlg.Color;

            return clr;

        }


        private void button2_Click(object sender, EventArgs e)
        {
           // grpEvnt.BringToFront();  
        }

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void grpsProj_Click(object sender, EventArgs e)
        {
            Clear_Grp();
            Fill_ListGrps ();
            grpGrpadd.Visible = true;
            grpGrpadd.BringToFront();
            mdl_GrpE.Visible = true;
            mdl_GrpE.BringToFront(); 
     
        }

        private void btnDelEvnt_Click(object sender, EventArgs e)
        {
            
        }

        private void picDelEvnt_Click(object sender, EventArgs e)
        {
           
        }

        private void picDelEvnt_Click_1(object sender, EventArgs e)
        {

           
        }

        private void picDelGRP_Click(object sender, EventArgs e)
        {

                 
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("GESTP_Events_RW", true))
            {
                Save_GRP();

                Fill_ListGrps ();
                btnDel.Enabled = true;
            }
         //   else MessageBox.Show("ACCESS Denied....!!!!!");
        }

        private void mdl_GrpE_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelGrp.Visible = true;
        }

        private void mdl_GrpE_Leave(object sender, EventArgs e)
        {
            btnDelGrp.Visible = false;
        }

        private void ed_lvITM_Leave(object sender, EventArgs e)
        {
            picDelEvnt.Visible = false;
        }
        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDelGrp.Visible = true;
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("GESTP_Events_RW", true))
            {
                Del_GrpEvent();
            }
        }

        private void btnDelGrp_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("GESTP_Events_RW", true))
            {
                Del_Event();
            }
                  
        }

        private void mdl_GrpE_DoubleClick(object sender, EventArgs e)
        {
        
            int ndx = mdl_GrpE.SelectedItems[0].Index;
            lGRPid.Text = mdl_GrpE.Items[ndx].SubItems[0].Text;
            txNgrp.Text = mdl_GrpE.Items[ndx].SubItems[1].Text;
            mdl_GrpE.Items[ndx].UseItemStyleForSubItems = false;
            var ccc = System.Drawing.ColorTranslator.FromHtml(mdl_GrpE.Items[ndx].SubItems[4].Text);
            mdl_GrpE.Items[ndx].SubItems[2].BackColor = ccc;
            lcolorGRP.BackColor = ccc;
            button1.Text = "Update";
            btnDel.Enabled = false;
        }

        private void txNgrp_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
