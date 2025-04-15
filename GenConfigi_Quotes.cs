using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using EAHLibs;

namespace PGESCOM
{
    public partial class GenConfigi_Quotes : Form
    {
        private static Lib1 Tools = new Lib1();

        public GenConfigi_Quotes()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //if (txuser.Text.Length > 4) txpwd.Text = GenNewPWD();
            //else MessageBox.Show("User Name must be more than 4 characters.....");
        }

        //string GenNewPWD()
        //{
            //const int MAXIMUM_PASSWORD_ATTEMPTS = 10000;
            //bool includeLowercase = true;
            //bool includeUppercase = true;
            //bool includeNumeric = true;
            //bool includeSpecial = false;
            //int lengthOfPassword = 8;

            ////Genpwd myPWD = new Genpwd();

            //Genpwd myGenpwd = new Genpwd(includeLowercase, includeUppercase, includeNumeric, includeSpecial, lengthOfPassword);

            //string password;

            //if (!myGenpwd.IsValidLength())
            //{
                //password = myGenpwd.LengthErrorMessage();
            //}
            //else
            //{
                //int passwordAttempts = 0;

                //do
                //{
                    //password = Genpwd.PasswordGenerator.GeneratePassword(myGenpwd);

                    //passwordAttempts++;
                //}
                //while (passwordAttempts < MAXIMUM_PASSWORD_ATTEMPTS && !Genpwd.PasswordGenerator.PasswordIsValid(myGenpwd, password));
                //password = Genpwd.PasswordGenerator.PasswordIsValid(myGenpwd, password) ? password : "sorry pwd problem.....try...";
            //}
            //return password;
        //}

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        //private void picXL_Click(object sender, EventArgs e)
        //{

        //}

        //private void piclook_Click(object sender, EventArgs e)
        //{

        //}

        //private void fill_Companies()
        //{
            //string stsql = " SELECT distinct  [SP_cpny_Name]  ,[cpny_lid] FROM configo_Usetup_cpny  ";
            //MainMDI.fill_Any_CB(cbcompanies, stsql, true, "ALL Companies");
        //}

        //private void GenConfigipwd_Load(object sender, EventArgs e)
        //{
            //fill_Companies();
        //}

        //private void cbcompanies_SelectedIndexChanged(object sender, EventArgs e)
        //{
            //if (cbcompanies.Text == "ALL Companies")
            //{
                //lcompID.Text = "0";
                //txcompNM.Text = " Please select a company .........";
                //lcustomerSP.Text = MainMDI.VIDE;
            //}
            //else
            //{
                //lcompID.Text = MainMDI.get_CBX_value(cbcompanies, cbcompanies.SelectedIndex);
                //txcompNM.Text = cbcompanies.Text;
                //lcustomerSP.Text = MainMDI.Find_One_Field("select [customersp] from [dbo].[configo_Usetup_cpny] where [cpny_lid]=" + lcompID.Text);
                //txsyscode.Text = lcustomerSP.Text;
            //}
            //Fill_users(lcompID.Text);
        //}

        //private void exitt_Click(object sender, EventArgs e)
        //{
            //this.Hide();
        //}

        //private void pictureBox1_Click_1(object sender, EventArgs e)
        //{
            //if (txpwd.Text.Length > 4 && txuser.Text.Length > 4)
            //Clipboard.SetText("user: " + txuser.Text + "    password: " + txpwd.Text, TextDataFormat.Text);
        //}

        //private void NewItm_Click(object sender, EventArgs e)
        //{
            //if (cbcompanies.Text != "ALL Companies")
            //{
                //pan_new.Visible = true;
                //clear_ALL();
            //}
            //else MessageBox.Show("Please select a company..........");
        //}

        //void clear_ALL()
        //{
            //usrLID.Text = "";
            //txfullNM.Clear();
            //txuser.Clear();
            //txpwd.Text = "";
        //}

        //private void picsave_Click(object sender, EventArgs e)
        //{
            //if (lcompID.Text != "0")
            //{
                //Save_infoUser();
                //Fill_users(lcompID.Text);
                //clear_ALL();
            //}
            //else MessageBox.Show("Please select a company..........");
        //}

        //string lastuser_id()
        //{
            //string res= MainMDI.Find_One_Field("select max(userid) from configo_Usetup");
            //if (res == MainMDI.VIDE) return "100";
            //else return res;
        //}

        //void Save_infoUser()
        //{
            //int web_userID = Int32.Parse(lastuser_id()) + 1;
            //if (txfullNM.Text != "" && txuser.Text != "" && txpwd.Text != "")
            //{
                //if (usrLID.Text == "")
                //{
                    //if (!User_exist(txuser.Text, lcompID.Text))
                    //{
                        //string stSql = " INSERT INTO configo_Usetup ([customersp] ,[userid] ,[usrname] ,[usrpwd] ,[multipl_chrgr] ,[multipl_acc]  ,[acc_phs1] ,[acc_phs3], " +
                            //" [savpwd] ,[FnmLnm] ,[actif] ,[cpnyID]) " +
                            //" VALUES ('" +lcustomerSP.Text +
                            //"', '" + web_userID.ToString() +
                            //"', '" + txuser.Text +
                            //"', '" + txpwd.Text +
                            //"', " + "1" +
                            //", " + "1" +
                            //", " + "1" +
                            //", " + "1" +
                            //", " + "1" +
                            //", '" + txfullNM.Text +
                            //"', " + "1" +
                            //", " + lcompID.Text + ")";

                        //MainMDI.Exec_SQL_JFS(stSql, "new Configo. user....");
                    //}
                    //else MessageBox.Show("User already Exists.........");
                //}
                //else
                //{
                    ////stSql = "UPDATE " + Bord_TNM + " SET " + " [brd_SN]='" + tBrdSN.Text + "', [brd_Ver]='" + tBver.Text + "', [firmwr_Ver]='" + tSver.Text + "',[b_connTo]='" + cbtConTo.Text + "' WHERE R_BrdLID=" + ed_lvBRD.Items[cur_LV_ndx].SubItems[0].Text;

                    ////string stSql = " UPDATE XCNG_Emp_Vacations SET [dateDeb]=" + MainMDI.SSV_date(dateTimePicker1.Value.ToShortDateString()) +
                        ////", [dateFin]=" + MainMDI.SSV_date(dateTimePicker2.Value.ToShortDateString()) + ", [valid]=" + valid.ToString() +
                        ////" where VacaLID=" + lvacaID.Text;
                    ////MainMDI.Exec_SQL_JFS(stSql, "Update Vacation");
                    //MessageBox.Show("Sorry, you must update this user..............man....");
                //}
            //}
            //else MessageBox.Show("Sorry, empty fields...company, user name,...");
        //}

        //bool User_exist(string user, string cpnyID)
        //{
            //string res = MainMDI.Find_One_Field("Select  lid from configo_Usetup where usrname='" + user + "'");
            //return (res != MainMDI.VIDE);
        //}

        //private void pictureBox2_Click(object sender, EventArgs e)
        //{
            //txNewPWD.Visible = true;
            //txNewPWD.Text = txpwd.Text;
        //}

        //private void txNewPWD_TextChanged(object sender, EventArgs e)
        //{
            //txpwd.Text = txNewPWD.Text;
        //}

        private void picsrch_Click(object sender, EventArgs e)
        {
            //if (Tools.Conv_Dbl(txQTnb.Text) > 0) Fill_Quote(txQTnb.Text);
            if (ed_lvQTE.Visible) Fill_ALLQuote(lcompID.Text);
            else Fill_ALL_Configs(lcompID.Text);
        }

        void FindQTnb(string qtnb)
        {
            this.Cursor = Cursors.WaitCursor;

            string stSql = " SELECT configo_Quotes.C_Qlid, configo_Quotes.QID, configo_Quotes.Customer, configo_Quotes.C_date, configo_Quotes.cust_ref, configo_Quotes.prjName, configo_Quotes.userid, " +
                "        configo_Usetup_cpny.SP_cpny_Name,  configo_Usetup.customersp, configo_Usetup.FnmLnm " +
                " FROM     configo_Quotes INNER JOIN configo_Usetup ON configo_Quotes.userid = configo_Usetup.userid INNER JOIN  configo_Usetup_cpny ON configo_Usetup.cpnyID = configo_Usetup_cpny.cpny_lid " +
                " WHERE configo_Quotes.QID = " + qtnb + " ORDER BY configo_Quotes.C_date, configo_Quotes.QID";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            string stdate = ""; bool found = false;
            ed_lvQTE.Items.Clear();
            ed_lvITM.Items.Clear();

            ed_lvCong.BeginUpdate();
            while (Oreadr.Read())
            {
                //ListViewItem lv = ed_lvITM.Items.Add(" ");
                //lv.SubItems.Add(Oreadr["affID"].ToString());
                //lv.SubItems.Add(Oreadr["Itemdesc"].ToString());
                //lv.SubItems.Add(Oreadr["qty"].ToString());
                //lv.SubItems.Add(" ");
                //lv.SubItems.Add(Oreadr["uprice"].ToString());
                //lv.SubItems.Add(" ");
                //lv.SubItems.Add(Oreadr["ext"].ToString());
                //lv.SubItems.Add(" "); lv.SubItems.Add(" "); lv.SubItems.Add(" "); lv.SubItems.Add(" ");
                //lv.SubItems.Add(" "); //techval
                ListViewItem lv = ed_lvQTE.Items.Add(Oreadr["C_Qlid"].ToString());
                DateTime dt1;
                stdate = (DateTime.TryParse(Oreadr["C_date"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                lv.SubItems.Add(stdate);
                lv.SubItems.Add(Oreadr["QID"].ToString());

                lv.SubItems.Add(Oreadr["prjName"].ToString());
                lv.SubItems.Add(Oreadr["cust_ref"].ToString());

                lv.SubItems.Add(Oreadr["FnmLnm"].ToString());
                lv.SubItems.Add(Oreadr["SP_cpny_Name"].ToString());

                double tt = Total_Quote(Oreadr["QID"].ToString()); //Oreadr["C_Qlid"].ToString());
                lv.SubItems.Add(tt.ToString());
                found = true;
            }
            if (!found) MessageBox.Show("Quote #  NOT FOUND....... !!!!");
            OConn.Close();
            ed_lvCong.EndUpdate();
            this.Cursor = Cursors.Default;
        }

        private void Fill_Config(string CFid)
        {
            //(Depnb == "Select Departement")
            //string CondDep = (Depnb == "0" && pnlDisp.Visible) ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            //string CondDep = (Depnb == "0") ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            //string CondPGCusr = (pgcUsr == "") ? "" : "AND (XCNG_Employees.PGC_usrNM ='" + pgcUsr + "')";
            //string whr = (compID == "0") ? "" : " Where cpnyID=" + compID;

            string stSql = " SELECT    Configo_cf_details.affID, Configo_cf_details.Itemdesc, Configo_cf_details.optref, Configo_cf_details.qty, Configo_cf_details.uprice, Configo_cf_details.ext " +
                " FROM Configo_cf_info INNER JOIN   Configo_cf_details ON Configo_cf_info.cflid = Configo_cf_details.confID " +
                "  WHERE Configo_cf_info.cflid = " + CFid + "  ORDER BY detID";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            string stdate = "";
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvITM.Items.Add(" ");
                lv.SubItems.Add(Oreadr["affID"].ToString());
                string st = "";

                if (Oreadr["optref"].ToString().Length > 0 && Oreadr["Itemdesc"].ToString().Length > 1)
                    st = Oreadr["optref"].ToString() + "=" + Oreadr["Itemdesc"].ToString();
                else 
                {
                    if (Oreadr["optref"].ToString().Length > 1) st = Oreadr["optref"].ToString();
                    else st = Oreadr["Itemdesc"].ToString();
                }
                lv.SubItems.Add(st);
                lv.SubItems.Add(Oreadr["qty"].ToString());
                lv.SubItems.Add(" ");
                lv.SubItems.Add(Oreadr["uprice"].ToString());
                lv.SubItems.Add(" ");
                lv.SubItems.Add(Oreadr["ext"].ToString());
                lv.SubItems.Add(" "); lv.SubItems.Add(" "); lv.SubItems.Add(" "); lv.SubItems.Add(" ");
                lv.SubItems.Add(" "); //techval
            }
            OConn.Close();
        }

        private void Fill_Quote(string qtnb, ref double TOT)
        {
            //(Depnb == "Select Departement")
            //string CondDep = (Depnb == "0" && pnlDisp.Visible) ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            //string CondDep = (Depnb == "0") ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            //string CondPGCusr = (pgcUsr == "") ? "" : "AND (XCNG_Employees.PGC_usrNM ='" + pgcUsr + "')";
            //string whr = (compID == "0") ? "" : " Where cpnyID=" + compID;

            string stSql = " SELECT configo_Quotes.C_Qlid, configo_Quotes.QID, configo_Quotes.Customer, configo_Quotes.C_date, configo_Quotes.cust_ref, configo_Quotes.prjName, configo_Quotes.userid, Configo_Quotes_details.detID, " +
                "  Configo_Quotes_details.Qlid, Configo_Quotes_details.affID, Configo_Quotes_details.optref, Configo_Quotes_details.Itemdesc, Configo_Quotes_details.qty, Configo_Quotes_details.mult, Configo_Quotes_details.uprice," +
                "  Configo_Quotes_details.xchng, Configo_Quotes_details.ext, Configo_Quotes_details.leadtime, Configo_Quotes_details.rnk, Configo_Quotes_details.pn, Configo_Quotes_details.tecval, Configo_Quotes_details.itmgrp," +
                "  Configo_Quotes_details.sext, Configo_Quotes_details.aext, Configo_Quotes_details.itmid " +
                "  FROM            configo_Quotes INNER JOIN Configo_Quotes_details ON configo_Quotes.C_Qlid = Configo_Quotes_details.Qlid " +
                "  WHERE configo_Quotes.QID = " + qtnb + "  ORDER BY configo_Quotes.QID ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            string stdate = "";
            TOT = 0;
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvITM.Items.Add(" ");
                lv.SubItems.Add(Oreadr["affID"].ToString());
                lv.SubItems.Add(Oreadr["Itemdesc"].ToString());
                lv.SubItems.Add(Oreadr["qty"].ToString());
                lv.SubItems.Add(" ");
                lv.SubItems.Add(Oreadr["uprice"].ToString());
                lv.SubItems.Add(" ");
                lv.SubItems.Add(Oreadr["ext"].ToString());TOT += Tools.Conv_Dbl(Oreadr["ext"].ToString());

                lv.SubItems.Add(" "); //techval

                //DateTime dt1;
                //stdate = (DateTime.TryParse(Oreadr["dateDeb"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                //lv.SubItems.Add(stdate);

                //stdate = (DateTime.TryParse(Oreadr["dateFin"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                //lv.SubItems.Add(stdate);
            }
            OConn.Close();
        }

        double Total_Quote(string qtnb)
        {
            if (Tools.Conv_Dbl(qtnb) == 0) return 0;

            string stSql = " SELECT SUM(Configo_Quotes_details.ext) AS tq FROM configo_Quotes " +
                "                   INNER JOIN     Configo_Quotes_details ON configo_Quotes.C_Qlid = Configo_Quotes_details.Qlid " +
                "            WHERE configo_Quotes.QID =" + qtnb;

            string res = MainMDI.Find_One_Field(stSql);
            return Tools.Conv_Dbl(res);
        }

        private void Fill_ALLQuote(string cpnyLID)
        {
             this.Cursor = Cursors.WaitCursor;

            //(Depnb == "Select Departement")
            //string CondDep = (Depnb == "0" && pnlDisp.Visible) ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            //string CondDep = (Depnb == "0") ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            //string CondPGCusr = (pgcUsr == "") ? "" : "AND (XCNG_Employees.PGC_usrNM ='" + pgcUsr + "')";
            //string whr = (cpnyLID == "0") ? "" : " Where cpny_lid=" + cpnyLID;
            //string whr2 = (bydate) ? "  configo_Quotes.C_date >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND configo_Quotes.C_date <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) : "";
            //if (whr != "") whr = (whr2 == "") ? whr : whr + " AND " + whr2;
            //else whr = (whr2 == "") ? "" : " Where " + whr2; //" where " + whr2;

            string whr = (cpnyLID == "0") ? "" : " AND cpny_lid=" + cpnyLID;
            string whr2 = " WHERE configo_Quotes.C_date >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND configo_Quotes.C_date <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString());

            //if (whr != "") whr = (whr2 == "") ? whr : whr + " AND " + whr2;
            //else whr = (whr2 == "") ? "" : " Where " + whr2; //" where " + whr2;

            string stSql = "SELECT  configo_Quotes.C_Qlid, configo_Quotes.QID, configo_Quotes.Customer, configo_Quotes.C_date, configo_Quotes.cust_ref, configo_Quotes.prjName, configo_Quotes.userid, configo_Usetup_cpny.SP_cpny_Name, configo_Usetup.customersp, configo_Usetup.FnmLnm " +
                " FROM   configo_Quotes INNER JOIN   configo_Usetup ON configo_Quotes.userid = configo_Usetup.userid INNER JOIN  configo_Usetup_cpny ON configo_Usetup.cpnyID = configo_Usetup_cpny.cpny_lid " + whr2 + whr +
                " order by C_date,QID ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvQTE.Items.Clear();
            string stdate = "";
            ed_lvQTE.BeginUpdate();
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvQTE.Items.Add(Oreadr["C_Qlid"].ToString());
                DateTime dt1;
                stdate = (DateTime.TryParse(Oreadr["C_date"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                lv.SubItems.Add(stdate);
                lv.SubItems.Add(Oreadr["QID"].ToString());

                lv.SubItems.Add(Oreadr["prjName"].ToString());
                lv.SubItems.Add(Oreadr["cust_ref"].ToString());

                lv.SubItems.Add(Oreadr["FnmLnm"].ToString());
                lv.SubItems.Add(Oreadr["SP_cpny_Name"].ToString());

                double tt = Total_Quote(Oreadr["QID"].ToString()); //Oreadr["C_Qlid"].ToString());
                lv.SubItems.Add(tt.ToString());
                //lv.SubItems.Add("");
            }
            OConn.Close();
            ed_lvQTE.EndUpdate();
            this.Cursor = Cursors.Default;
        }

        private void Fill_ALL_Configs(string cpnyLID)
        {
            this.Cursor = Cursors.WaitCursor;

            //(Depnb == "Select Departement")
            //string CondDep = (Depnb == "0" && pnlDisp.Visible) ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            //string CondDep = (Depnb == "0") ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            //string CondPGCusr = (pgcUsr == "") ? "" : "AND (XCNG_Employees.PGC_usrNM ='" + pgcUsr + "')";

            string whr = (cpnyLID == "0") ? "" : " AND cpny_lid=" + cpnyLID;
            string ord = (cpnyLID == "0") ? " order by datein, Configo_cf_info.usrname, configo_Usetup_cpny.SP_cpny_Name" : "  order by  datein  ,configo_Usetup_cpny.SP_cpny_Name, Configo_cf_info.usrname";

            //string stSql = " SELECT   Configo_cf_info.cflid, Configo_cf_info.cfname, Configo_cf_info.datein, Configo_cf_info.usrname, Configo_cf_info.machNM, configo_Usetup_cpny.SP_cpny_Name ,  CONVERT(VARCHAR(10), Configo_cf_info.datein, 102) as dd " +
                //" FROM Configo_cf_info INNER JOIN configo_Usetup ON Configo_cf_info.usrname = configo_Usetup.usrname INNER JOIN configo_Usetup_cpny ON configo_Usetup.cpnyID = configo_Usetup_cpny.cpny_lid " +
                //"  " + whr + ord;

            string stSql = " SELECT        Configo_cf_info.cflid AS CFIDD, Configo_cf_info.cfname, Configo_cf_info.datein, Configo_cf_info.usrname, Configo_cf_info.machNM, COUNT(Configo_cf_details.detID) AS nbDet, configo_Usetup_cpny.SP_cpny_Name ,CONVERT(VARCHAR(10), Configo_cf_info.datein, 102) as dd " +
                " FROM Configo_cf_info INNER JOIN Configo_cf_details ON Configo_cf_info.cflid = Configo_cf_details.confID INNER JOIN " +
                "      configo_Usetup ON Configo_cf_info.usrname = configo_Usetup.usrname INNER JOIN configo_Usetup_cpny ON configo_Usetup.cpnyID = configo_Usetup_cpny.cpny_lid " +
                "Where Configo_cf_info.usrname <> 'ede' AND Configo_cf_info.datein >= " + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND Configo_cf_info.datein <= " + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) +
                whr +
                " GROUP BY configo_Usetup_cpny.SP_cpny_Name, Configo_cf_info.cflid, Configo_cf_info.cfname, Configo_cf_info.datein, Configo_cf_info.usrname, Configo_cf_info.machNM " +
                ord;

            //" order by datein, Configo_cf_info.usrname, configo_Usetup_cpny.SP_cpny_Name";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvCong.Items.Clear();
            string stdate = "";
            double nbconf = 0, nbdays = 0;
            string olddd = "", newdd = "";
            ed_lvCong.BeginUpdate();
            while (Oreadr.Read())
            {
                if (Tools.Conv_Dbl(Oreadr["nbDet"].ToString()) > 2)
                {
                    newdd = Oreadr["dd"].ToString();
                    if (olddd != newdd)
                    {
                        olddd = newdd;
                        nbdays++;
                    }
                    DateTime dt1;
                    stdate = (DateTime.TryParse(Oreadr["datein"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                    ListViewItem lv = ed_lvCong.Items.Add(stdate);
                    //lv.SubItems.Add();
                    lv.SubItems.Add(Oreadr["CFIDD"].ToString());
                    lv.SubItems.Add(Oreadr["usrname"].ToString());
                    lv.SubItems.Add(Oreadr["SP_cpny_Name"].ToString());
                    nbconf++;
                }
            }
            if (nbconf > 0 && nbdays > 0) txavrg.Text = Math.Round((nbconf / nbdays), 0).ToString(); //+ "  ===> " + nbconf.ToString() + " / " + nbdays.ToString();
            OConn.Close();
            ed_lvCong.EndUpdate();
            this.Cursor = Cursors.Default;
        }

        bool isConfig(string _cfid)
        {
            string nbdet = MainMDI.Find_One_Field("SELECT count(detID)  FROM [Orig_PSM_FDB].[dbo].[Configo_cf_details] where   [confID]=" + _cfid);

            return (Tools.Conv_Dbl(nbdet) > 2);
        }

        private void GenConfigi_Quotes_Load(object sender, EventArgs e)
        {
            fill_Companies();

            vis_ConfigLst();
            cbcompanies.Text = "ALL Companies";
            select_cpny();
        }

        private void ed_lvQTE_SelectedIndexChanged(object sender, EventArgs e)
        {
            select_Quote();
        }

        void select_Quote()
        {
            double tot = 0;
            if (ed_lvQTE.SelectedItems.Count > 0)
            {
                int ndx = ed_lvQTE.SelectedItems[0].Index;

                if (Tools.Conv_Dbl(ed_lvQTE.Items[ndx].SubItems[2].Text) > 0)
                {
                    Fill_Quote(ed_lvQTE.Items[ndx].SubItems[2].Text, ref tot);
                    //ed_lvQTE.Items[ndx].SubItems[7].Text = tot.ToString();
                }
            }
        }

        void select_Config()
        {
            if (ed_lvCong.SelectedItems.Count > 0)
            {
                int ndx = ed_lvCong.SelectedItems[0].Index;

                if (Tools.Conv_Dbl(ed_lvCong.Items[ndx].SubItems[1].Text) > 0) Fill_Config(ed_lvCong.Items[ndx].SubItems[1].Text);
            }
        }

        private void ed_lvQTE_Click(object sender, EventArgs e)
        {
            //select_Quote();
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void fill_Companies()
        {
            string stsql = " SELECT distinct  [SP_cpny_Name]  ,[cpny_lid] FROM configo_Usetup_cpny  ";
            MainMDI.fill_Any_CB(cbcompanies, stsql, true, "ALL Companies");
        }

        private void cbcompanies_SelectedIndexChanged(object sender, EventArgs e)
        {
            select_cpny();
        }

        void select_cpny()
        {
            if (cbcompanies.Text == "ALL Companies")
            {
                lcompID.Text = "0";
            }
            else
            {
                lcompID.Text = MainMDI.get_CBX_value(cbcompanies, cbcompanies.SelectedIndex);
                //txcompNM.Text = cbcompanies.Text;
                //lcustomerSP.Text = MainMDI.Find_One_Field("select [customersp] from [dbo].[configo_Usetup_cpny] where [cpny_lid]=" + lcompID.Text);
                //txsyscode.Text = lcustomerSP.Text;
            }
            if (ed_lvQTE.Visible) Fill_ALLQuote(lcompID.Text);
            else Fill_ALL_Configs(lcompID.Text);
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        void Fill_Copy()
        {
            lCopy.Text = "N";
            if (ed_lvITM.Items.Count > 0)
            {
                vider_arr_clpB();

                for (int i = 0; i < ed_lvITM.Items.Count; i++)
                {
                    for (int j = 0; j < ed_lvITM.Items[i].SubItems.Count; j++)
                    {
                        MainMDI.arr_clpB[i, j] = ed_lvITM.Items[i].SubItems[j].Text;
                    }
                }
                lCopy.Text = "Y";
                MessageBox.Show("Copy is Done........");
            }
            else MessageBox.Show("Sorry Items List is Empty........");
        }

        private void vider_arr_clpB()
        {
            for (int i = 0; i < MainMDI.MAX_Quote_lines; i++)
                for (int j = 0; j < 1; j++)
                    MainMDI.arr_clpB[i, j] = "~";
            //LstNdx = 0;
        }

        private void ItemsCC_Click(object sender, EventArgs e)
        {
            Fill_Copy();
        }

        private void picsrch_Click_1(object sender, EventArgs e)
        {
            //int i = find_QTnb();
            //if (i > -1)
            //{
                //ed_lvITM.SelectedIndices =
                //ed_lvITM.Select();
            //}
        }

        int find_QTnb()
        {
            for (int i = 0; i < ed_lvQTE.Items.Count; i++) if (ed_lvQTE.Items[i].SubItems[1].Text == txQTnb.Text) return i;
            return -1;
        }

        void vis_ConfigLst()
        {
            //lqt.Visible = false;
            //txQTnb.Visible = false;
            ed_lvQTE.Visible = false;
            ItemsCC.Visible = false;
            ed_lvITM.Items.Clear();
            grpLst.Text = "Configurations List";
            //label1.Visible = true;
            //txavrg.Visible = true;
            ed_lvCong.Visible = true;
        }

        void vis_QuotesLst()
        {
            //lqt.Visible = true;
            //txQTnb.Visible = true;
            ed_lvQTE.Visible = true;
            ItemsCC.Visible = true;
            ed_lvITM.Items.Clear();
            grpLst.Text = "Quotes List";
            //label1.Visible = false;
            //txavrg.Visible = false;
            ed_lvCong.Visible = false;
        }

        private void tls_config_Click(object sender, EventArgs e)
        {
            panQTnb.Visible = false;

            vis_ConfigLst();
            ed_lvCong.Items.Clear();
            ed_lvITM.Items.Clear();
            select_cpny();
        }

        private void tls_quotes_Click(object sender, EventArgs e)
        {
            if (panQTnb.Visible) ed_lvQTE.Items.Clear();

            panQTnb.Visible = false;
            vis_QuotesLst();
            ed_lvQTE.Items.Clear();
            ed_lvITM.Items.Clear();
            select_cpny();
        }

        private void grpLst_Enter(object sender, EventArgs e)
        {

        }

        private void ed_lvCong_Click(object sender, EventArgs e)
        {
            //select_Config();
        }

        private void ed_lvCong_SelectedIndexChanged(object sender, EventArgs e)
        {
            select_Config();
        }

        private void tlsXL_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;

            if (ed_lvQTE.Visible) sendXL_Quotes();
            else sendXL_configs();

            this.Cursor = Cursors.Default;
        }

        private void sendXL_configs()
        {
            int NBCols = 4;
            object[] objHdrs = new object[NBCols]; //{ "Invoice #", "Sale / Agency Name", "Base Amount", "Commission %", "Commission Amount", "Currency", "Xchange rate ", "Commission Amount (CAD)", " cms Type " };

            for (int i = 0; i < NBCols; i++) objHdrs[i] = ed_lvCong.Columns[i].Text; //ed_lvITM.Columns[i + 2].Text;

            string Fname = "Configo_configs.xlsx";
            string CellFM = "A1", CellTO = "D1";

            object[,] objData = new object[MainMDI.MAX_XLlines_XPRT, NBCols];
            for (int i = 0; i < MainMDI.MAX_XLlines_XPRT; i++)
            {
                if (i < ed_lvCong.Items.Count)
                {
                    for (int j = 0; j < NBCols; j++) objData[i, j] = ed_lvCong.Items[i].SubItems[j].Text;
                }
            }
            XL_EXPORT(Fname, objHdrs, NBCols, CellFM, CellTO, objData);
        }

        private void sendXL_Quotes()
        {
            int NBCols = 7;
            object[] objHdrs = new object[NBCols]; //{ "Invoice #", "Sale / Agency Name", "Base Amount", "Commission %", "Commission Amount", "Currency", "Xchange rate ", "Commission Amount (CAD)", " cms Type " };

            for (int i = 0; i < NBCols; i++) objHdrs[i] = ed_lvQTE.Columns[i + 1].Text; //ed_lvITM.Columns[i + 2].Text;

            string Fname = "Configo_Quotes.xlsx";
            string CellFM = "A1", CellTO = "G1";

            object[,] objData = new object[MainMDI.MAX_XLlines_XPRT, NBCols];
            for (int i = 0; i < MainMDI.MAX_XLlines_XPRT; i++)
            {
                if (i < ed_lvQTE.Items.Count)
                {
                    for (int j = 0; j < NBCols; j++) objData[i, j] = ed_lvQTE.Items[i].SubItems[j + 1].Text;
                }
            }
            XL_EXPORT(Fname, objHdrs, NBCols, CellFM, CellTO, objData);
        }

        private void XL_EXPORT(string FName, object[] objHdrs, int HdrsNB, string CellFM, string CellTO, object[,] objData)
        {
            try
            {
                System.IO.File.Delete(MainMDI.XL_Path + @"\" + FName); //"CMS_CALC.xls");
                Object m_objOpt = System.Reflection.Missing.Value;
                Excel.Application m_objXL = new Excel.Application();
                Excel.Workbooks m_objbooks = m_objXL.Workbooks;
                Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);
                Excel.Sheets m_objSheets = m_objBook.Worksheets;
                Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

                Excel.Range m_objRng = m_objSheet.get_Range(CellFM, CellTO);
                m_objRng.Value2 = objHdrs;
                Excel.Font m_objFont = m_objRng.Font;
                m_objFont.Bold = true;

                m_objRng = m_objSheet.get_Range("A2", m_objOpt);
                m_objRng = m_objRng.get_Resize(MainMDI.MAX_XLlines_XPRT, HdrsNB);
                m_objRng.Value2 = objData;

                m_objBook.SaveAs(MainMDI.XL_Path + @"\" + FName, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                m_objBook.Close(false, m_objOpt, m_objOpt);
                m_objXL.Quit();
                //??? NO data
                //MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\" + FName);

                MainMDI.EXEC_FILE("EXCEL.exe", MainMDI.XL_Path + @"\" + FName);
            }
            catch (Exception objEx)
            {
                MessageBox.Show("ERROR: CLOSE YOUR XL FILE and TRY..................\n" + objEx.ToString());
            }
        }

        private void tlsqtnb_Click(object sender, EventArgs e)
        {
            vis_QuotesLst();
            panQTnb.Visible = true;
            ed_lvQTE.Visible = true;
            ed_lvQTE.Items.Clear();
        }

        private void picQTnb_Click(object sender, EventArgs e)
        {
            if (Tools.Conv_Dbl(txQTnb.Text) > 1000) FindQTnb(txQTnb.Text);
            else MessageBox.Show("wrong Quote #  (must be > 1000) !!!!");
        }

        private void Users_Click(object sender, EventArgs e)
        {
            GenConfigipwd myfrm = new GenConfigipwd();
            this.Hide();
            myfrm.ShowDialog();
            this.Visible = true;
        }
    }
}