using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PGESCOM
{
    public partial class OR_Sched_Vacations : Form
    {
        const int PeridLEN = 63;
        string[] arr_CAL_dates = new string[PeridLEN];
        const int MAXcellW = 40, SSW = 2;
        string[] arr_dep = new string[20], arr_Events = new string[20];
        string[] arrColors = new string[45] { "Black",
            "Blue",
            "BlueViolet",
            "Brown",
            "CadetBlue",
            "Chocolate",
            "Coral",
            "CornflowerBlue",
            "Crimson",
            "DarkBlue",
            "DarkCyan",
            "DarkGoldenrod",
            "DarkGreen",
            "DarkMagenta",
            "DarkOliveGreen",
            "DarkOrange",
            "DarkOrchid",
            "DarkRed",
            "DarkSalmon",
            "DarkSeaGreen",
            "DarkSlateBlue",
            "DarkSlateGray",
            "DarkTurquoise",
            "DarkViolet",
            "DeepPink",
            "DodgerBlue",
            "Firebrick",
            "ForestGreen",
            "Goldenrod",
            "Green",
            "Indigo",
            "Khaki",
            "Maroon",
            "MediumBlue",
            "Navy",
            "Olive",
            "OliveDrab",
            "Orange",
            "OrangeRed",
            "Purple",
            "Red",
            "RoyalBlue",
            "SaddleBrown",
            "SandyBrown",
            "SeaGreen"
        };

        public OR_Sched_Vacations()
        {
            InitializeComponent();
        }

        private void _exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        void CreateCLNDR()
        {
            /*
            bool fin = false;
            string stOut = "";
            dateTimePicker1.Value = new DateTime(2016, 1, 1);
            do
            {
                string MM = dateTimePicker1.Value.Month.ToString();
                //string MMnm=dateTimePicker1.Value.Month.ToString();

                string DD = dateTimePicker1.Value.Day.ToString();
                string DDnm = dateTimePicker1.Value.DayOfWeek.ToString();
                stOut += "/f/n" + DDnm + "   " + MM + "  2016";
                if (MM == "12" && DD == "31") fin = true;
                dateTimePicker1.Value = dateTimePicker1.Value.AddDays(1);
            } while (!fin);
            textBox1.Text = stOut;
            * */
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            /*
            if (cbDep.Text != "Select Departement")
            {
                lvPeriodCal.BeginUpdate();
                lvPeriodCal.Items.Clear();
                ed_LVmodif1.Items.Clear();
                Disp_Period();
                Disp_Vaca();
                Disp_Holidays();
                lvPeriodCal.EndUpdate();
                lvPeriodCal.Visible = true;
                ed_LVmodif1.Visible = true;
            }
            else MessageBox.Show("Departement is INVALID............");

            */
            Disp_Schedule();
        }

        void Disp_Schedule()
        {
            lvPeriodCal.BeginUpdate();
            lvPeriodCal.Items.Clear();
            ed_LVmodif1.Items.Clear();
            string nbdays = Disp_Period();

            if (arr_CAL_dates[1] != "")
            {
                if (optALL.Checked)
                {
                    Disp_Vaca("ALL");
                    Disp_Events("ALL");
                    lvPeriodCal.EndUpdate();
                    lvPeriodCal.Visible = true;
                    ed_LVmodif1.Visible = true;
                }
                else
                {
                    for (int i = 0; i < arr_dep.Length; i++)
                    {
                        if (arr_dep[i] != "") Disp_Vaca(arr_dep[i]);
                        else i = arr_dep.Length;
                    }
                    for (int e = 0; e < arr_Events.Length; e++)
                    {
                        if (arr_Events[e] != "") Disp_Events(arr_Events[e]);
                        else e = arr_Events.Length;
                    }
                    lvPeriodCal.EndUpdate();
                    lvPeriodCal.Visible = true;
                    ed_LVmodif1.Visible = true;
                }
            }
            else MessageBox.Show(" INVALID Period (" + nbdays + ")   ..... must be from 7 to 60 DAYS  !!!");
        }

        void clear_LVCalendar()
        {
            for (int i = 1; i < lvPeriodCal.Columns.Count; i++)
            {
                lvPeriodCal.Columns[i].Text = "";
                lvPeriodCal.Columns[i].Width = 0;
            }
        }

        void Disp_Periodoldddd()
        {
            clear_LVCalendar();
            for (int r = 1; r < PeridLEN; r++) arr_CAL_dates[r] = "";
            TimeSpan tS = DTP_To.Value.Subtract(DTP_From.Value);

            if (tS.TotalDays <= PeridLEN && tS.TotalDays > 7)
            {
                DateTime dt1 = DTP_From.Value;
                int nDay = 1;
                while (dt1 <= DTP_To.Value)
                {
                    arr_CAL_dates[nDay] = dt1.ToShortDateString();
                    //string MMMM = Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames[dt1.Month - 1] + " " + dt1.Day.ToString();
                    string dayName = dt1.DayOfWeek.ToString();
                    //string MMMM = (dayName[0] == 'S') ? " (" + dayName[0].ToString() + ")" : dt1.ToString("MMMM") + " " + dt1.Day.ToString() + " (" + dayName[0].ToString() + ")";
                    //string MMMM = (dayName[0] == 'S') ? dayName[0].ToString() : String.Format("{0:ddd, dd-mm-yyyy}", dt1);
                    //int Cellw = MMMM.Length * 7;
                    //lvPeriodCal.Columns[nDay].Text = MMMM;
                    string MMMM = (dayName[0] == 'S') ? String.Format("{0:ddd}", dt1) : String.Format("{0:ddd, dd-MMM}", dt1);
                    lvPeriodCal.Columns[nDay].Text = MMMM;
                    int Cellw = (dayName[0] == 'S') ? 36 : MMMM.Length * 7;
                    lvPeriodCal.Columns[nDay++].Width = Cellw; //55;

                    dt1 = dt1.AddDays(1);
                }
            }
        }

        string Disp_Period()
        {
            //bool process = false;
            clear_LVCalendar();
            for (int r = 1; r < PeridLEN; r++) arr_CAL_dates[r] = "";
            TimeSpan tS = DTP_To.Value.Subtract(DTP_From.Value);

            ListViewItem lvI = lvPeriodCal.Items.Add(" ");

            if (tS.TotalDays <= PeridLEN && tS.TotalDays > 7)
            {
                DateTime dt1 = DTP_From.Value;
                int nDay = 1;
                while (dt1 <= DTP_To.Value)
                {
                    arr_CAL_dates[nDay] = dt1.ToShortDateString();
                    string dayName = dt1.DayOfWeek.ToString();
                    //string MMMM = (dayName[0] == 'S') ? String.Format("{0:ddd}", dt1) : String.Format("{0:ddd, dd-MMM}", dt1);
                    string MMMM = String.Format("{0:dd/MM}", dt1);
                    lvPeriodCal.Columns[nDay].Text = MMMM;
                    int Cellw = MAXcellW; //(dayName[0] == 'S') ? 36 : MMMM.Length * 7;
                    lvPeriodCal.Columns[nDay++].Width = Cellw; //55;
                    lvI.SubItems.Add(dayName[0].ToString());
                    dt1 = dt1.AddDays(1);
                    lvI.BackColor = Color.Beige;
                }
            }
            return Convert.ToInt32(tS.TotalDays).ToString();
        }

        void Disp_VacaOLD()
        {
            string CondDep = (cbDep.Text == "ALL") ? "" : "AND (XCNG_Employees.Depcode =" + ldepID.Text + ")";
            //string stSql = " SELECT  XCNG_Employees.Empl_Name,  XCNG_Emp_Vacations.EmpID, XCNG_Emp_Vacations.YYYY, XCNG_Emp_Vacations.dateDeb, XCNG_Emp_Vacations.dateFin FROM  XCNG_Emp_Vacations INNER JOIN XCNG_Employees ON XCNG_Emp_Vacations.EmpID = XCNG_Employees.EmpID " +
                 //" where  [dateDeb] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " OR [dateFin] <=" +MainMDI.SSV_date(DTP_To.Value.ToShortDateString());

            //string stSql = " SELECT  XCNG_Employees.Empl_Name,  XCNG_Emp_Vacations.EmpID, XCNG_Emp_Vacations.YYYY, XCNG_Emp_Vacations.dateDeb, XCNG_Emp_Vacations.dateFin FROM  XCNG_Emp_Vacations INNER JOIN XCNG_Employees ON XCNG_Emp_Vacations.EmpID = XCNG_Employees.EmpID " +
                //" where  ([dateDeb] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " OR [dateFin] <=" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + ") " + CondDep + "  and [YYYY]=" + DateTime.Now.Year.ToString() + " order by [dateDeb] ";

            string stSql = " SELECT  XCNG_Employees.Empl_Name,  XCNG_Emp_Vacations.EmpID, XCNG_Emp_Vacations.YYYY, XCNG_Emp_Vacations.dateDeb, XCNG_Emp_Vacations.dateFin FROM  XCNG_Emp_Vacations INNER JOIN XCNG_Employees ON XCNG_Emp_Vacations.EmpID = XCNG_Employees.EmpID " +
                " where  ([dateDeb] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " AND [dateFin] <=" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + ") " +
                "    OR    ([dateDeb] <" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " AND [dateFin] <=" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + " AND [dateFin] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + ") " +
                "    OR    ([dateDeb] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " AND [dateFin] >" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + " AND [dateDeb] <=" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + ") " +
                CondDep + "  and [YYYY]=" + DateTime.Now.Year.ToString() + " order by [Empl_Name], [dateDeb] ";

            string rez = MainMDI.Find_One_Field("SELECT  Grp_COLOR from XCNG_EventGrp where Abrv='VA'");
            Color curr_CLR = (rez == MainMDI.VIDE) ? Color.FromName("Maroon") : Color.FromName(rez);

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int d = 0;
            while (Oreadr.Read())
            {
                DateTime dt1, dt2;
                DateTime.TryParse(Oreadr["dateDeb"].ToString(), out dt1);
                DateTime.TryParse(Oreadr["dateFin"].ToString(), out dt2);

                //if (d == 0) {
                if (ed_LVmodif1.Items.Count == 0)
                {
                    ListViewItem lvI3 = ed_LVmodif1.Items.Add(" ");
                    lvI3.SubItems.Add(" ");
                    lvI3.SubItems.Add(" ");
                    lvI3.BackColor = Color.Beige;
                    d++;
                }
                ListViewItem lvII = ed_LVmodif1.Items.Add(Oreadr["Empl_Name"].ToString());
                lvII.SubItems.Add(dt1.ToShortDateString());
                lvII.SubItems.Add(dt2.ToShortDateString());
                //lvII.BackColor = Color.Red;
                lvII.ForeColor = curr_CLR; //Color.Red; //Color.White;

                ListViewItem lvI = lvPeriodCal.Items.Add(" ");
                for (int i = 1; i < lvPeriodCal.Columns.Count; i++)
                {
                    if (lvPeriodCal.Columns[i].Text != "")
                    {
                        lvI.SubItems.Add(" ");
                        int II = lvI.SubItems.Count -1;
                        //if (lvPeriodCal.Columns[II].Text[0] == 'S')
                        if (lvPeriodCal.Items [0].SubItems[II].Text[0] == 'S')
                        {
                            lvI.UseItemStyleForSubItems = false;
                            lvI.SubItems[II].BackColor = Color.Beige; //Color.Wheat; //LightCyan;
                            lvPeriodCal.Columns[II].Width = SSW; //Sat, Sun 
                        }
                    }
                    else i = lvPeriodCal.Columns.Count;
                }
                int debNdx = 0;
                while (dt1 <= dt2)
                {
                    int ndx = Find_DateinARR(dt1.ToShortDateString());
                    if (ndx != -1)
                    {
                        //if (lvPeriodCal.Columns[ndx].Text[0] != 'S')
                        if (lvPeriodCal.Items[0].SubItems[ndx].Text[0] != 'S')
                        {
                            lvPeriodCal.Items[lvPeriodCal.Items.Count - 1].UseItemStyleForSubItems = false;
                            lvPeriodCal.Items[lvPeriodCal.Items.Count - 1].SubItems[ndx].BackColor = curr_CLR; //Color.Red;
                            debNdx = ndx;
                        }
                    }
                    dt1 = dt1.AddDays(1);
                }
            }
            OConn.Close();
        }

        void Disp_Vaca(string DepLID)
        {
            string CondDep = (DepLID == "ALL") ? "" : "AND (XCNG_Employees.Depcode =" + DepLID + ")";
            string stSql = " SELECT  XCNG_Employees.Depcode, XCNG_Employees.Empl_Name,  XCNG_Emp_Vacations.EmpID, XCNG_Emp_Vacations.YYYY, XCNG_Emp_Vacations.dateDeb, XCNG_Emp_Vacations.dateFin FROM  XCNG_Emp_Vacations INNER JOIN XCNG_Employees ON XCNG_Emp_Vacations.EmpID = XCNG_Employees.EmpID " +
                " where  (([dateDeb] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " AND [dateFin] <=" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + ") " +
                "    OR    ([dateDeb] <" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " AND [dateFin] <=" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + " AND [dateFin] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + ") " +
                "    OR    ([dateDeb] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " AND [dateFin] >" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + " AND [dateDeb] <=" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + ")) " +
                CondDep + "  and [YYYY]=" + DateTime.Now.Year.ToString() + " order by [Empl_Name], [dateDeb] ";

            string rez = MainMDI.Find_One_Field("SELECT  Grp_COLOR from XCNG_EventGrp where Abrv='VA'");
            Color curr_CLR = (rez == MainMDI.VIDE) ? Color.FromName("Maroon") : Color.FromName(rez);

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int d = 0;
            while (Oreadr.Read())
            {
                DateTime dt1, dt2;
                DateTime.TryParse(Oreadr["dateDeb"].ToString(), out dt1);
                DateTime.TryParse(Oreadr["dateFin"].ToString(), out dt2);

                //if (d == 0) {
                if (ed_LVmodif1.Items.Count == 0)
                {
                    ListViewItem lvI3 = ed_LVmodif1.Items.Add(" ");
                    lvI3.SubItems.Add(" ");
                    lvI3.SubItems.Add(" ");
                    lvI3.BackColor = Color.Beige;
                    d++;
                }
                ListViewItem lvII = ed_LVmodif1.Items.Add(Oreadr["Empl_Name"].ToString());
                lvII.SubItems.Add(dt1.ToShortDateString());
                lvII.SubItems.Add(dt2.ToShortDateString());
                //lvII.BackColor = Color.Red;
                lvII.ForeColor = curr_CLR; //Color.Red; //Color.White;

                ListViewItem lvI = lvPeriodCal.Items.Add(" ");
                for (int i = 1; i < lvPeriodCal.Columns.Count; i++)
                {
                    if (lvPeriodCal.Columns[i].Text != "")
                    {
                        lvI.SubItems.Add(" ");
                        int II = lvI.SubItems.Count - 1;
                        //if (lvPeriodCal.Columns[II].Text[0] == 'S')
                        if (lvPeriodCal.Items[0].SubItems[II].Text[0] == 'S')
                        {
                            lvI.UseItemStyleForSubItems = false;
                            lvI.SubItems[II].BackColor = Color.Beige; //Color.Wheat; //LightCyan;
                            lvPeriodCal.Columns[II].Width = SSW; //Sat, Sun 
                        }
                    }
                    else i = lvPeriodCal.Columns.Count;
                }
                int debNdx = 0;
                while (dt1 <= dt2)
                {
                    int ndx = Find_DateinARR(dt1.ToShortDateString());
                    if (ndx != -1)
                    {
                        //if (lvPeriodCal.Columns[ndx].Text[0] != 'S')
                        if (lvPeriodCal.Items[0].SubItems[ndx].Text[0] != 'S')
                        {
                            lvPeriodCal.Items[lvPeriodCal.Items.Count - 1].UseItemStyleForSubItems = false;
                            lvPeriodCal.Items[lvPeriodCal.Items.Count - 1].SubItems[ndx].BackColor = curr_CLR; //Color.Red;
                            debNdx = ndx;
                        }
                    }
                    dt1 = dt1.AddDays(1);
                }
            }
            OConn.Close();
        }

        Color GiveMeColor()
        {
            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            Color randomColor = Color.FromKnownColor(randomColorName);
            return randomColor;
        }

        void Disp_HolidaysOLDDDDDD()
        {
            //string CondDep = (cbDep.Text == "ALL") ? "" : "AND (XCNG_Employees.Depcode =" + ldepID.Text + ")";
            //string stSql = " SELECT  XCNG_Employees.Empl_Name,  XCNG_Emp_Vacations.EmpID, XCNG_Emp_Vacations.YYYY, XCNG_Emp_Vacations.dateDeb, XCNG_Emp_Vacations.dateFin FROM  XCNG_Emp_Vacations INNER JOIN XCNG_Employees ON XCNG_Emp_Vacations.EmpID = XCNG_Employees.EmpID " +
                //" where  [dateDeb] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " OR [dateFin] <=" +MainMDI.SSV_date(DTP_To.Value.ToShortDateString());

            //string stSql = " SELECT  * FROM  XCNG_Events where  ([Ev_Start] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " OR [Ev_End] <=" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + ") and [YYYY]=" + DateTime.Now.Year.ToString() + " order by [Ev_Start] ";

            string stSql = "SELECT  * FROM  XCNG_Events " +
                " where  ([Ev_Start] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " AND [Ev_End] <=" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + ") " +
                "    OR    ([Ev_Start] <" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " AND [Ev_End] <=" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + " AND [Ev_End] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + ") " +
                "    OR    ([Ev_Start] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " AND [Ev_End] >" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + " AND [Ev_Start] <=" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + ") " +
                "  and [YYYY]=" + DateTime.Now.Year.ToString() + " order by [Event_Name], [Ev_Start] ";

            int CC1 = 0;

            //Color red = Color.FromArgb(255, 0, 0);
            //Color green = Color.FromArgb(0, 255, 0);
            //Color blue = Color.FromArgb(0, 0, 255);

            //Color.FromArgb(100, 150, 75);

            //Color Curr_clr = Color.FromName("SlateBlue");

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int d = 0;
            while (Oreadr.Read())
            {
                //Color Curr_clr = Color.FromArgb(CC1, CC2, CC3);
                //CC1 += 10; CC2 += 50; CC3 += 20;
                //Color Curr_clr = Color.FromName(arrColors[CC1++]);
                string rez = MainMDI.Find_One_Field("SELECT  Grp_COLOR from XCNG_EventGrp where Abrv='" + Oreadr["EvType"].ToString() + "'");
                Color Curr_clr = (rez == MainMDI.VIDE) ? Color.FromName("Orange") : Color.FromName(rez);

                DateTime dt1, dt2;
                DateTime.TryParse(Oreadr["Ev_Start"].ToString(), out dt1);
                DateTime.TryParse(Oreadr["Ev_End"].ToString(), out dt2);

                if (ed_LVmodif1.Items.Count == 0)
                {
                    ListViewItem lvI3 = ed_LVmodif1.Items.Add(" ");
                    lvI3.SubItems.Add(" ");
                    lvI3.SubItems.Add(" ");
                    lvI3.BackColor = Color.Beige;
                }
                ListViewItem lvII = ed_LVmodif1.Items.Add(Oreadr["Event_Name"].ToString());
                lvII.SubItems.Add(dt1.ToShortDateString());
                lvII.SubItems.Add(dt2.ToShortDateString());
                //lvII.BackColor = Color.Blue;
                lvII.ForeColor = Curr_clr; //Color.White;

                ListViewItem lvI = lvPeriodCal.Items.Add(" ");
                for (int i = 1; i < lvPeriodCal.Columns.Count; i++)
                {
                    if (lvPeriodCal.Columns[i].Text != "")
                    {
                        lvI.SubItems.Add(" ");
                        int II = lvI.SubItems.Count - 1;
                        //if (lvPeriodCal.Columns[II].Text[0] == 'S')
                        if (lvPeriodCal.Items[0].SubItems[II].Text[0] == 'S')
                        {
                            lvI.UseItemStyleForSubItems = false;
                            lvI.SubItems[II].BackColor = Color.Beige; //Color.Wheat; //LightCyan;
                            if (lvPeriodCal.Columns[II].Width != SSW) lvPeriodCal.Columns[II].Width = SSW; //Sat, Sun 
                        }
                    }
                    else i = lvPeriodCal.Columns.Count;
                }
                int debNdx = 0;
                while (dt1 <= dt2)
                {
                    int ndx = Find_DateinARR(dt1.ToShortDateString());
                    if (ndx != -1)
                    {
                        //if (lvPeriodCal.Columns[ndx].Text[0] != 'S')
                        if (lvPeriodCal.Items[0].SubItems[ndx].Text[0] != 'S')
                        {
                            lvPeriodCal.Items[lvPeriodCal.Items.Count - 1].UseItemStyleForSubItems = false;
                            lvPeriodCal.Items[lvPeriodCal.Items.Count - 1].SubItems[ndx].BackColor = Curr_clr; //Color.Blue;
                            debNdx = ndx;
                        }
                    }
                    dt1 = dt1.AddDays(1);
                }
            }
            OConn.Close();
        }

        void Disp_Events(string EventName)
        {
            string CondEvnt = (EventName == "ALL") ? "" : " (EvType ='" + EventName + "') AND ";
              
            string stSql = "SELECT  * FROM  XCNG_Events " +
                " where " + CondEvnt + " ([Ev_Start] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " AND [Ev_End] <=" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + ") " +
                "    OR    ([Ev_Start] <" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " AND [Ev_End] <=" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + " AND [Ev_End] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + ") " +
                "    OR    ([Ev_Start] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " AND [Ev_End] >" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + " AND [Ev_Start] <=" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + ") " +
                "  and [YYYY]=" + DateTime.Now.Year.ToString() + " order by [Event_Name], [Ev_Start] ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int d = 0;
            while (Oreadr.Read())
            {
                string rez = MainMDI.Find_One_Field("SELECT  Grp_COLOR from XCNG_EventGrp where ET_LID='" + Oreadr["EvType"].ToString() + "'");
                Color Curr_clr = (rez == MainMDI.VIDE) ? Color.FromName("Orange") : Color.FromName(rez);

                DateTime dt1, dt2;
                DateTime.TryParse(Oreadr["Ev_Start"].ToString(), out dt1);
                DateTime.TryParse(Oreadr["Ev_End"].ToString(), out dt2);

                if (ed_LVmodif1.Items.Count == 0)
                {
                    ListViewItem lvI3 = ed_LVmodif1.Items.Add(" ");
                    lvI3.SubItems.Add(" ");
                    lvI3.SubItems.Add(" ");
                    lvI3.BackColor = Color.Beige;
                }
                ListViewItem lvII = ed_LVmodif1.Items.Add(Oreadr["Event_Name"].ToString());
                lvII.SubItems.Add(dt1.ToShortDateString());
                lvII.SubItems.Add(dt2.ToShortDateString());
                //lvII.BackColor = Color.Blue;
                lvII.ForeColor = Curr_clr; //Color.White;

                ListViewItem lvI = lvPeriodCal.Items.Add(" ");
                for (int i = 1; i < lvPeriodCal.Columns.Count; i++)
                {
                    if (lvPeriodCal.Columns[i].Text != "")
                    {
                        lvI.SubItems.Add(" ");
                        int II = lvI.SubItems.Count - 1;
                        //if (lvPeriodCal.Columns[II].Text[0] == 'S')
                        if (lvPeriodCal.Items[0].SubItems[II].Text[0] == 'S')
                        {
                            lvI.UseItemStyleForSubItems = false;
                            lvI.SubItems[II].BackColor = Color.Beige; //Color.Wheat; //LightCyan;
                            if (lvPeriodCal.Columns[II].Width != SSW) lvPeriodCal.Columns[II].Width = SSW; //Sat, Sun 
                        }
                    }
                    else i = lvPeriodCal.Columns.Count;
                }
                int debNdx = 0;
                while (dt1 <= dt2)
                {
                    int ndx = Find_DateinARR(dt1.ToShortDateString());
                    if (ndx != -1)
                    {
                        //if (lvPeriodCal.Columns[ndx].Text[0] != 'S')
                        if (lvPeriodCal.Items[0].SubItems[ndx].Text[0] != 'S')
                        {
                            lvPeriodCal.Items[lvPeriodCal.Items.Count - 1].UseItemStyleForSubItems = false;
                            lvPeriodCal.Items[lvPeriodCal.Items.Count - 1].SubItems[ndx].BackColor = Curr_clr; //Color.Blue;
                            debNdx = ndx;
                        }
                    }
                    dt1 = dt1.AddDays(1);
                }
            }
            OConn.Close();
        }

        int Find_DateinARR(int debNdx, string stDate)
        {
            for (int j = debNdx + 1; j < PeridLEN; j++)
                if (arr_CAL_dates[j] == stDate) return j;
            return -1;
        }

        int Find_DateinARR(string stDate)
        {
            for (int j = 1; j < PeridLEN; j++)
                if (arr_CAL_dates[j] == stDate) return j;
            return -1;
        }

        private void lvPeriodCal_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            MessageBox.Show("W= " + lvPeriodCal.Columns[e.Column].Width.ToString());
        }

        private void inPRO_Click(object sender, EventArgs e)
        {
            dlg_Vaca_Emp emp = new dlg_Vaca_Emp();
            emp.ShowDialog();
            emp.Close();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            //if (MainMDI.ALWD_USR("GESTP_CNG_R", true))
            //{
                groupBox1.Visible = false;
                grpSChed.Visible = false;
                dlg_Vaca_Conges myfrm = new dlg_Vaca_Conges();
                myfrm.ShowDialog();
                myfrm.Close();
            //}
        }

        private void fill_Dep()
        {
            string stsql = " SELECT  [DepName]  ,[Depcode] FROM [Orig_PSM_FDB].[dbo].[XCNG_Departements] order by DepName ";
            MainMDI.fill_Any_CB(cbDep, stsql, true, "ALL");
        }

        void init_ARRS()
        {
            for (int i = 0; i < arr_dep.Length; i++)
            {
                arr_dep[i] = "";
                arr_Events[i] = "";
            }
        }

        private void OR_Sched_Vacations_Load(object sender, EventArgs e)
        {
            init_ARRS();
            //fill_Dep();
            for (int i = 1; i < lvPeriodCal.Columns.Count; i++) lvPeriodCal.Columns[i].TextAlign = HorizontalAlignment.Center;
        }

        private void cbDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            ldepID.Text = MainMDI.get_CBX_value(cbDep, cbDep.SelectedIndex);
        }

        private void fndP_Click(object sender, EventArgs e)
        {

        }

        void fill_Depart()
        {

        }

        private void vacaSched_Click(object sender, EventArgs e)
        {
            DTP_From.Text = DateTime.Now.ToShortDateString();
            DTP_To.Text = DateTime.Now.ToShortDateString();
            if (MainMDI.ALWD_USR("GESTP_SCHD", true))
            {
                grpSChed.Enabled = true;
                optALL.Checked = true;
                if (MainMDI.User.ToLower() == "shammou")
                {
                    fill_Dep();

                    optSEL.Checked = true;
                    btnSEL.Visible = true;
                    optALL.Visible = false;
                }
                grpSChed.Visible = true;
            }
            //else MessageBox.Show("ACCESS Denied....!!!!!");
        }

        private void EvHolidays_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("GESTP_Events_R", true))
            {
                groupBox1.Visible = false;
                grpSChed.Visible = false;
                dlg_Vaca_Events myFrm = new dlg_Vaca_Events();
                myFrm.ShowDialog();
                myFrm.Close();
            }
        }

        private void new_Sched_Click(object sender, EventArgs e)
        {
            //OR_Sched_Vacations_Z myfrm = new OR_Sched_Vacations_Z();
            //myfrm./ShowDialog();

            groupBox1.Visible = true;
            grpSChed.Visible = true;
            optALL.Checked = true;
            DateTime dt1 = DateTime.Now;
            dt1 = dt1.AddDays(60);
            DTP_To.Text = dt1.ToShortDateString();
            grpSChed.Enabled = false;
            Disp_Schedule();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        void selEV()
        {
            //init_ARRS();
            dlg_Vaca_EvSELECT myfrm = new dlg_Vaca_EvSELECT(ref arr_dep, ref arr_Events);
            myfrm.ShowDialog();

            myfrm.Close();
        }

        private void btnSEL_Click(object sender, EventArgs e)
        {
            selEV();
        }

        private void optALL_CheckedChanged(object sender, EventArgs e)
        {
            btnSEL.Enabled = optSEL.Checked;
        }

        private void optSEL_CheckedChanged(object sender, EventArgs e)
        {
            btnSEL.Enabled = optSEL.Checked;
        }

        private void Ev_View_Click(object sender, EventArgs e)
        {
            dlg_Vaca_Events_View myView = new dlg_Vaca_Events_View();
            myView.ShowDialog();
        }

        /*
        private void button1_Click(object sender, EventArgs e)
        {
            genaer date de string date
            DateTime dt1;
            if (DateTime.TryParse("26/03/2019", out dt1))
            {
                dateTimePicker1.Value = dt1.Date;
                label1.Text = dateTimePicker1.Value.DayOfWeek.ToString() + " " + dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Year.ToString();
                textBox1.Text = dt1.DayOfWeek.ToString() + " " + dt1.Day.ToString() + "/" + dt1.Month.ToString() + "/" + dt1.Year.ToString();
            }
        }

        private void init_CHnn()
        {
            //MessageBox.Show("debut= " + DateTime.Now.ToString());
            string stSql = "SELECT *  FROM PSM_R_SCD_ITasks ORDER BY ti_xlrnk ";
            SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int ti = 0;
            while (Oreadr.Read())
            {
                if (ti < 21)
                {
                    lvAllProjects.Columns[ti].Text = Oreadr["ti_Desc"].ToString();
                    lvAllProjects.Columns[ti++].Width = Int32.Parse(Oreadr["ti_xllen"].ToString()); //must be var
                }
                else MessageBox.Show("col hdrs limit....");
            }
            for (int i = ti; ti < 21; ti++)
                if (lvAllProjects.Columns[ti].Text == "") lvAllProjects.Columns[ti++].Width = 0;
            OConn.Close();
            //MessageBox.Show("debut= " + DateTime.Now.ToString());
        }

        private void NLine_lvAll()
        {
            ListViewItem lvI = lvAllProjects.Items.Add("");
            for (int i = 1; i < lvAllProjects.Columns.Count; i++)
                lvI.SubItems.Add("");
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
        * 
        * 
        * 
        * 
        * * */
    }
}