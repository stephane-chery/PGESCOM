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
    public partial class OR_Sched_Vacations_Z : Form
    {
        const int PeridLEN=63;
        string[] arr_CAL_dates = new string[PeridLEN];
       const  int MAXcellW = 40, SSW=8;
        public OR_Sched_Vacations_Z()
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
                //     string MMnm=dateTimePicker1.Value.Month  .ToString ();

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
           // cellW = Int32.Parse(nbW.Text);
                        if (cbDep.Text != "Select Departement")
                        {
                            lvPeriodCal.BeginUpdate();
                            lvPeriodCal.Items.Clear();
                            ed_LVmodif1.Items.Clear(); 
                            Disp_Period();
                            Disp_Vaca();
                            lvPeriodCal.EndUpdate();
                            lvPeriodCal.Visible = true;
                            ed_LVmodif1.Visible = true; 
                        }
                        else MessageBox.Show("Departement is INVALID............");


            /*
                                    for (int i = 1; i < lvPeriodCal.Columns.Count; i++)
                                    {
                                        lvPeriodCal.Columns[i].Width = Int32.Parse(nbW.Text);
                                        lvPeriodCal.Columns[i].Text = "";
                                    }

                                    */
        }




        void Disp_DAtes()
        {
         
 
   
               
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
                    //     string MMMM = Thread.CurrentThread.CurrentCulture.DateTimeFormat.MonthNames[dt1.Month - 1] + " " + dt1.Day.ToString();
                    string dayName = dt1.DayOfWeek.ToString();
                    //       string MMMM = (dayName[0] == 'S') ? " (" + dayName[0].ToString() + ")" : dt1.ToString("MMMM") + " " + dt1.Day.ToString() + " (" + dayName[0].ToString() + ")";
                    //       string MMMM = (dayName[0] == 'S') ? dayName[0].ToString() : String.Format ("{0:ddd, dd-mm-yyyy}",dt1)  ;
                    //   int Cellw = MMMM.Length * 7;
                    //   lvPeriodCal.Columns[nDay].Text = MMMM;
                    string MMMM = (dayName[0] == 'S') ? String.Format("{0:ddd}", dt1) : String.Format("{0:ddd, dd-MMM}", dt1);
                    lvPeriodCal.Columns[nDay].Text = MMMM;
                    int Cellw = (dayName[0] == 'S') ? 36 : MMMM.Length * 7;
                    lvPeriodCal.Columns[nDay++].Width = Cellw; //55;
                    
                    dt1 = dt1.AddDays(1);
                }
            }
     
        }

        void Disp_Period()
        {
            //bool process=false;
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
                 //   string MMMM = (dayName[0] == 'S') ? String.Format("{0:ddd}", dt1) : String.Format("{0:ddd, dd-MMM}", dt1);
                    string MMMM = String.Format("{0:dd/MM}", dt1);
                    lvPeriodCal.Columns[nDay].Text = MMMM;
               //     int Cellw = cellW;// 40;// (dayName[0] == 'S') ? 36 : MMMM.Length * 7;
                    int Cellw = (dayName[0] == 'S') ? 10 :MAXcellW ;
                    lvPeriodCal.Columns[nDay++].Width = Cellw; //55;
                    lvI.SubItems.Add(dayName[0].ToString ());
                    dt1 = dt1.AddDays(1);
                    lvI.BackColor = Color.Beige;
                }
            }

        }

        void Disp_Vaca()
        {
            string CondDep = (cbDep.Text == "ALL") ? "" : "AND (XCNG_Employees.Depcode =" + ldepID.Text + ")"; 
       //   string stSql = " SELECT  XCNG_Employees.Empl_Name,  XCNG_Emp_Vacations.EmpID, XCNG_Emp_Vacations.YYYY, XCNG_Emp_Vacations.dateDeb, XCNG_Emp_Vacations.dateFin FROM  XCNG_Emp_Vacations INNER JOIN XCNG_Employees ON XCNG_Emp_Vacations.EmpID = XCNG_Employees.EmpID " +
                 //           " where  [dateDeb] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " OR [dateFin] <=" +MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) ;

          string stSql = " SELECT  XCNG_Employees.Empl_Name,  XCNG_Emp_Vacations.EmpID, XCNG_Emp_Vacations.YYYY, XCNG_Emp_Vacations.dateDeb, XCNG_Emp_Vacations.dateFin FROM  XCNG_Emp_Vacations INNER JOIN XCNG_Employees ON XCNG_Emp_Vacations.EmpID = XCNG_Employees.EmpID " +
                    " where  ([dateDeb] >=" + MainMDI.SSV_date(DTP_From.Value.ToShortDateString()) + " OR [dateFin] <=" + MainMDI.SSV_date(DTP_To.Value.ToShortDateString()) + ")" + CondDep;
   
             
            
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int d = 0;
            while (Oreadr.Read())
            {
                DateTime dt1,dt2;
                DateTime.TryParse(Oreadr["dateDeb"].ToString(), out dt1);
                DateTime.TryParse(Oreadr["dateFin"].ToString(), out dt2);

                if (d == 0) {
                    ListViewItem lvI3 = ed_LVmodif1.Items.Add(" ");
                    lvI3.SubItems.Add(" ");
                    lvI3.SubItems.Add(" ");
                    lvI3.BackColor = Color.Beige;
                    d++; }

                ListViewItem lvII = ed_LVmodif1.Items.Add(Oreadr["Empl_Name"].ToString()); 
                             lvII.SubItems.Add ( dt1.ToShortDateString());
                             lvII.SubItems.Add ( dt2.ToShortDateString());

                ListViewItem lvI = lvPeriodCal.Items.Add(" ");
                for (int i = 1; i < lvPeriodCal.Columns.Count; i++)
                {
                    if (lvPeriodCal.Columns[i].Text !="")
                  {
                    lvI.SubItems.Add(" ");
                    int II = lvI.SubItems.Count -1;
                  //  if (lvPeriodCal.Columns[II].Text[0] == 'S')
                    if (lvPeriodCal.Items [0].SubItems[II].Text[0] == 'S')
                    {
                        lvI.UseItemStyleForSubItems = false;
                        lvI.SubItems[II].BackColor = Color.Beige; ;// Color.Wheat;//LightCyan;
                        lvPeriodCal.Columns[II].Width = SSW ;
                    }
                  }
                  else i=lvPeriodCal.Columns.Count ;  
                }
                int debNdx = 0;
                while (dt1 <= dt2)
                {
                    int ndx = Find_DateinARR(dt1.ToShortDateString());
                    if (ndx != -1)
                    {
                      //  if (lvPeriodCal.Columns[ndx].Text[0] != 'S')
                        if (lvPeriodCal.Items[0].SubItems[ndx].Text[0] != 'S')
                        {
                            lvPeriodCal.Items[lvPeriodCal.Items.Count - 1].UseItemStyleForSubItems = false;
                            lvPeriodCal.Items[lvPeriodCal.Items.Count - 1].SubItems[ndx].BackColor = Color.Red;
                            debNdx = ndx;
                        }
                    }
                  dt1=  dt1.AddDays(1);
                }
          
            }
              OConn.Close();

        }

        int Find_DateinARR(int debNdx,string stDate)
        {

            for (int j = debNdx+1 ; j < PeridLEN; j++)
                if (arr_CAL_dates[j]==stDate )   return j;
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
            dlg_Vaca_Conges myfrm = new dlg_Vaca_Conges();
            myfrm.ShowDialog();
            myfrm.Close(); 
        }
        private void fill_Dep()
        {

            string stsql = " SELECT  [DepName]  ,[Depcode] FROM [Orig_PSM_FDB].[dbo].[XCNG_Departements] order by DepName ";
            MainMDI.fill_Any_CB(cbDep, stsql, true, "ALL");

        }
        private void OR_Sched_Vacations_Load(object sender, EventArgs e)
        {
            fill_Dep();
            for (int i=1;i<lvPeriodCal.Columns.Count ;i++) lvPeriodCal.Columns[i].TextAlign =HorizontalAlignment.Center ; 
        }

        private void cbDep_SelectedIndexChanged(object sender, EventArgs e)
        {
    
            ldepID.Text = MainMDI.get_CBX_value(cbDep, cbDep.SelectedIndex);
          
        }

        private void fndP_Click(object sender, EventArgs e)
        {
            

        }

        private void vacaSched_Click(object sender, EventArgs e)
        {
            grpSChed.Visible = true;
        }

        private void EvHolidays_Click(object sender, EventArgs e)
        {
            dlg_Vaca_Events myFrm = new dlg_Vaca_Events();
            myFrm.ShowDialog();
            myFrm.Close(); 
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void lvPeriodCal_SelectedIndexChanged(object sender, EventArgs e)
        {

        }



        /*
               private void button1_Click(object sender, EventArgs e)
               {
                    genaer date de string date
                   DateTime dt1;
                   if (DateTime.TryParse("26/03/2019", out dt1))
                   {
                       dateTimePicker1.Value = dt1.Date;
                       label1.Text = dateTimePicker1.Value.DayOfWeek.ToString()+" " + dateTimePicker1.Value.Day.ToString() + "/" + dateTimePicker1.Value.Month.ToString() + "/" + dateTimePicker1.Value.Year.ToString();
                       textBox1.Text = dt1.DayOfWeek.ToString() + " " + dt1.Day.ToString() + "/" + dt1.Month.ToString() + "/" + dt1.Year.ToString(); 
          
                   }
         
  
               }


               private void init_CHnn()
               {
                   //  MessageBox.Show("debut= " + DateTime.Now.ToString ());   
                   string stSql = "SELECT *  FROM PSM_R_SCD_ITasks ORDER BY ti_xlrnk ";
                   SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
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
                           lvAllProjects.Columns[ti++].Width = Int32.Parse(Oreadr["ti_xllen"].ToString());  //must be var

                       }
                       else MessageBox.Show("col hdrs limit....");

                   }
                   for (int i = ti; ti < 21; ti++)
                       if (lvAllProjects.Columns[ti].Text == "") lvAllProjects.Columns[ti++].Width = 0;
                   OConn.Close();
                   //   MessageBox.Show("debut= " + DateTime.Now.ToString ()); 

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
                    *     * */
    }
}
