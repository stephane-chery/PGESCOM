using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace PGESCOM
{
    public partial class GenConfigipwd : Form
    {
        public GenConfigipwd()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (txuser.Text.Length > 4) txpwd.Text = GenNewPWD();
            else MessageBox.Show("User Name must be more than 4 characters.....");


        }

        string GenNewPWD()
        {

            const int MAXIMUM_PASSWORD_ATTEMPTS = 10000;
            bool includeLowercase = true;
            bool includeUppercase = true;
            bool includeNumeric = true;
            bool includeSpecial = false;
            int lengthOfPassword = 8;


      //      Genpwd myPWD = new Genpwd();

            Genpwd myGenpwd = new Genpwd(includeLowercase, includeUppercase, includeNumeric, includeSpecial, lengthOfPassword);

            string password;

            if (!myGenpwd.IsValidLength())

            {

                password = myGenpwd.LengthErrorMessage();

            }

            else

            {

                int passwordAttempts = 0;

                do

                {

                    password = Genpwd.PasswordGenerator.GeneratePassword(myGenpwd);

                    passwordAttempts++;

                }

                while (passwordAttempts < MAXIMUM_PASSWORD_ATTEMPTS && !Genpwd.PasswordGenerator.PasswordIsValid(myGenpwd, password));



                password = Genpwd.PasswordGenerator.PasswordIsValid(myGenpwd, password) ? password : "sorry pwd problem.....try...";

            }



          return password;

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void Fill_users(string compID)
        {
            //(Depnb == "Select Departement")
            //   string CondDep = (Depnb == "0" && pnlDisp.Visible) ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            //string CondDep = (Depnb == "0") ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            //string CondPGCusr = (pgcUsr == "") ? "" : "AND (XCNG_Employees.PGC_usrNM ='" + pgcUsr + "')";
            string whr = (compID == "0") ? "" : " Where cpnyID=" + compID;


            string stSql = "SELECT  * from  configo_Usetup inner join [dbo].[configo_Usetup_cpny] on [cpny_lid]=[cpnyID]  " + whr;


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            string stdate = "";
            while (Oreadr.Read())
            {

                ListViewItem lv = ed_lvITM.Items.Add(Oreadr["lid"].ToString());
                lv.SubItems.Add(Oreadr["SP_cpny_Name"].ToString());
                lv.SubItems.Add(Oreadr["cpnyID"].ToString());

                //DateTime dt1;
                //stdate = (DateTime.TryParse(Oreadr["dateDeb"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                //lv.SubItems.Add(stdate);

                //stdate = (DateTime.TryParse(Oreadr["dateFin"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                //lv.SubItems.Add(stdate);

                lv.SubItems.Add(Oreadr["usrname"].ToString());
                lv.SubItems.Add(Oreadr["usrpwd"].ToString());


            }

            OConn.Close();

        }

        private void picXL_Click(object sender, EventArgs e)
        {

        }

        private void piclook_Click(object sender, EventArgs e)
        {

        }


        private void fill_Companies()
        {

            string stsql = " SELECT distinct  [SP_cpny_Name]  ,[cpny_lid] FROM configo_Usetup_cpny  ";
            MainMDI.fill_Any_CB(cbcompanies, stsql, true, "ALL Companies");

            
        }

        private void GenConfigipwd_Load(object sender, EventArgs e)
        {
            fill_Companies();
        }

        private void cbcompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbcompanies.Text == "ALL Companies")
            {
                lcompID.Text = "0";
                txcompNM.Text = " Please select a company .........";
                lcustomerSP.Text = MainMDI.VIDE;
            }
            else
            {
                lcompID.Text =  MainMDI.get_CBX_value(cbcompanies, cbcompanies.SelectedIndex);
                txcompNM.Text = cbcompanies.Text;
                lcustomerSP.Text = MainMDI.Find_One_Field("select [customersp] from [dbo].[configo_Usetup_cpny] where [cpny_lid]=" + lcompID.Text);
                txsyscode.Text = lcustomerSP.Text;
            }
            
          Fill_users(lcompID.Text);
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            if (txpwd.Text.Length>4 && txuser.Text.Length > 4)
            Clipboard.SetText("user: "+txuser.Text + "    password: " +txpwd.Text, TextDataFormat.Text);
        }

        private void NewItm_Click(object sender, EventArgs e)
        {
            if (cbcompanies.Text != "ALL Companies")
            {


                pan_new.Visible = true;
                clear_ALL();
            }
            else MessageBox.Show("Please select a company..........");
        }

        void clear_ALL()
        {
            usrLID.Text = "";
            txfullNM.Clear();
            txuser.Clear();
            txpwd.Text = "";
        }
        private void picsave_Click(object sender, EventArgs e)
        {
            if (lcompID.Text != "0")
            {
                Save_infoUser();
                Fill_users(lcompID.Text);
                clear_ALL();


            }
            else MessageBox.Show("Please select a company..........");
        }

        string lastuser_id()
        {

           string res= MainMDI.Find_One_Field("select max(userid) from configo_Usetup");
            if (res == MainMDI.VIDE) return "100";
            else return res;

        }
        void Save_infoUser()
        {

            int web_userID = Int32.Parse(lastuser_id()) + 1;
            if (txfullNM.Text != "" && txuser.Text != "" && txpwd.Text != "")
             
            {

                if (usrLID.Text == "")

                {
                    if (!User_exist(txuser.Text, lcompID.Text))
                    {

                        string stSql = " INSERT INTO configo_Usetup ([customersp] ,[userid] ,[usrname] ,[usrpwd] ,[multipl_chrgr] ,[multipl_acc]  ,[acc_phs1] ,[acc_phs3], " +
                                                                   " [savpwd] ,[FnmLnm] ,[actif] ,[cpnyID]) "+
                                                                   " VALUES ('" +lcustomerSP.Text +
                       "', '" + web_userID.ToString() +
                       "', '" +txuser.Text +
                       "', '" + txpwd.Text +
                       "', " + "1" +
                       ", " + "1" +
                       ", " + "1" +
                       ", " + "1" +
                       ", " + "1" +
                       ", '" + txfullNM.Text +
                       "', " + "1" +
                       ", " + lcompID.Text + ")";

                        MainMDI.Exec_SQL_JFS(stSql, "new Configo. user....");
                    }
                    else MessageBox.Show("User already Exists.........");
                }

                else
                {
                    //stSql = "UPDATE " + Bord_TNM + " SET " + " [brd_SN]='" + tBrdSN.Text + "', [brd_Ver]='" + tBver.Text + "', [firmwr_Ver]='" + tSver.Text + "',[b_connTo]='" + cbtConTo.Text + "' WHERE R_BrdLID=" + ed_lvBRD.Items[cur_LV_ndx].SubItems[0].Text;

                    //string stSql = " UPDATE XCNG_Emp_Vacations SET [dateDeb]=" + MainMDI.SSV_date(dateTimePicker1.Value.ToShortDateString()) +
                    //      ", [dateFin]=" + MainMDI.SSV_date(dateTimePicker2.Value.ToShortDateString()) + ", [valid]=" + valid.ToString() +
                    //      " where VacaLID=" + lvacaID.Text;
                    //MainMDI.Exec_SQL_JFS(stSql, "Update Vacation");
                    MessageBox.Show("Sorry, you must update this user..............man....");
                }

               

            }
            else MessageBox.Show("Sorry, empty fields...company, user name,...");  

        }


        bool User_exist(string user,string cpnyID)
        {
            string res = MainMDI.Find_One_Field("Select  lid from configo_Usetup where usrname='" + user+"'");
            return (res != MainMDI.VIDE);

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            txNewPWD.Visible = true;
            txNewPWD.Text = txpwd.Text;
        }

        private void txNewPWD_TextChanged(object sender, EventArgs e)
        {
            txpwd.Text = txNewPWD.Text;
        }
    }

}
