using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;

namespace PGESCOM
{
    public partial class dlg_Vaca_Conges : Form
    {
        char Opera = 'V';

        public dlg_Vaca_Conges()
        {
            InitializeComponent();
        }

        private void NewItm_Click(object sender, EventArgs e)
        {
            Modif_add_CNG();
        }

        void Modif_add_CNG()
        {
            Clear_Conge();
            if (MainMDI.ALWD_USR("GESTP_CNG_RW", false))
            //if (MainMDI.SUPERusr())
            {
                chk_Valid.Checked = true;
                Disp_pnls('N');
            }
            else
            {
                string _Nameemp = "", _codEmp = "", _depcd = "", _depnm = "";
                MainMDI.Find_2_Field("SELECT [EmpID]    ,[Empl_Name], XCNG_Employees.[Depcode] , [DepName] FROM XCNG_Employees  inner join  [XCNG_Departements] on XCNG_Employees.[Depcode]= XCNG_Departements.[Depcode] where [PGC_usrNM]='" + MainMDI.User + "'", ref _codEmp, ref _Nameemp, ref _depcd, ref _depnm);
                if (_codEmp != MainMDI.VIDE)
                {
                    ldepID.Text = _depcd; ldepNM.Text = _depnm; cbDep.Text = _depnm;
                    //cbDep_SelectedIndexChanged(sender, e);
                    lempID.Text = _codEmp; lEmpNM.Text = _Nameemp; cbEmployees.Text = _Nameemp;
                    lEmpNM.Visible = true; ldepNM.Visible = true;
                    //Fill_Conges(ldepID.Text);

                    Fill_Conges(ldepID.Text, MainMDI.User.ToLower());
                    chk_Valid.Checked = true;
                    Disp_pnls('N');
                }
                else MessageBox.Show("Sorry you cannot modify your vacation ....pls Contact Administrator.....");
            }
            //lvacaID.Text = "";
            //btnSave.Text = "Save";
        }

        void Disp_pnls(char ND)
        {
            if (ND == 'N')
            {
                pnlNew.Visible = true;
                grpEntry.Height = pnlNew.Height + 20;
                //ed_lvITM.Items.Clear();
                pnlDisp.Visible = false;
            }
            else
            {
                pnlDisp.Visible = true;
                grpEntry.Height = pnlDisp.Height + 20;
                pnlNew.Visible = false;
                Fill_Conges(ldepDispID.Text);
            }
        }

        private void fill_Dep()
        {
            string conddep = (MainMDI.User.ToLower() == "shammou") ? " where USRadmin='shammou'": " ";
            string stsql = " SELECT  [DepName]  ,[Depcode] FROM [Orig_PSM_FDB].[dbo].[XCNG_Departements]   " + conddep + " order by DepName ";
            MainMDI.fill_Any_CB(cbDep, stsql, true, "Select Departement");

            MainMDI.fill_Any_CB(cbDepDisp, stsql, true, "Select Departement");
        }

        private void fill_Dep(string codDep)
        {
            string stsql = " SELECT  [DepName]  ,[Depcode] FROM [Orig_PSM_FDB].[dbo].[XCNG_Departements]  where Depcode= " + codDep;
            MainMDI.fill_Any_CB(cbDep, stsql, true, "Select Departement");

            MainMDI.fill_Any_CB(cbDepDisp, stsql, true, "Select Departement");
        }

        private void fill_emp()
        {
            string stsql = " SELECT  [Empl_Name]  ,[EmpID] FROM [Orig_PSM_FDB].[dbo].[XCNG_Employees] where Depcode=" + ldepID.Text + " order by Empl_Name ";
            MainMDI.fill_Any_CB(cbEmployees, stsql, true, "Select Employee");
        }

        private void cbDep_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lCustLID.Text = MainMDI.get_CBX_value(cbCompanyy, cbCompanyy.SelectedIndex);
            ldepID.Text = MainMDI.get_CBX_value(cbDep, cbDep.SelectedIndex);
            if (ldepID.Text != "")
            {
                fill_emp();
                if (btnSave.Text != "Update") Fill_Conges(ldepID.Text);
            }
        }

        private void dlg_Vaca_Conges_Load(object sender, EventArgs e)
        {
            fill_Dep();
            cbDep.Text = cbDep.Items[0].ToString();
            cbDepDisp.Text = cbDepDisp.Items[0].ToString();
            Disp_pnls('D');
            //btnCancel.Visible = (MainMDI.ALWD_USR("GESTP_CNG_RW", false));
            //cbDep.Text = cbDep.Items[0].ToString();
            //Fill_Conges(ldepID.Text);
        }

        private void cbEmployees_SelectedIndexChanged(object sender, EventArgs e)
        {
            lempID.Text = MainMDI.get_CBX_value(cbEmployees, cbEmployees.SelectedIndex);
            lEmail.Text = MainMDI.Find_One_Field("select  Email from XCNG_Employees where EmpID=" + lempID.Text);
            //Fill_Conges(ldepID.Text);
        }

        private void picSave_Click(object sender, EventArgs e)
        {

        }

        bool Conge_exist(string empID, string YYYY, string dtDEB, string dtFIN)
        {
            string res = MainMDI.Find_One_Field("Select  VacaLID from XCNG_Emp_Vacations where EmpID=" + empID + " AND [YYYY]=" + YYYY + " AND [dateDeb]=" + MainMDI.SSV_date(dtDEB) + " AND [dateFin]=" + MainMDI.SSV_date(dtFIN));
            return (res != MainMDI.VIDE);
        }

        void Save_Conge()
        {
            if (cbDep.Text != "Select Departement" && cbEmployees.Text != "Select Employee")
            {
                int valid = (chk_Valid.Checked) ? 1 : 0;

                if (lvacaID.Text == "")
                {
                    if (!Conge_exist(lempID.Text, DateTime.Now.Year.ToString(), dateTimePicker1.Value.ToShortDateString(), dateTimePicker2.Value.ToShortDateString()))
                    {
                        string stSql = " INSERT INTO XCNG_Emp_Vacations ([EmpID],[YYYY],[dateDeb], [dateFin], [valid] ) " +
                            " VALUES (" + lempID.Text +
                            ", " + DateTime.Now.Year.ToString() +
                            ", " + MainMDI.SSV_date(dateTimePicker1.Value.ToShortDateString()) +
                            ", " + MainMDI.SSV_date(dateTimePicker2.Value.ToShortDateString()) +
                            ", " + valid.ToString() + ")";

                        MainMDI.Exec_SQL_JFS(stSql, "New Vacation");
                    }
                    else MessageBox.Show("Vacation already Exists.........");
                }
                else
                {
                    //stSql = "UPDATE " + Bord_TNM + " SET " + " [brd_SN]='" + tBrdSN.Text + "', [brd_Ver]='" + tBver.Text + "', [firmwr_Ver]='" + tSver.Text + "',[b_connTo]='" + cbtConTo.Text + "' WHERE R_BrdLID=" + ed_lvBRD.Items[cur_LV_ndx].SubItems[0].Text;

                    string stSql = " UPDATE XCNG_Emp_Vacations SET [dateDeb]=" + MainMDI.SSV_date(dateTimePicker1.Value.ToShortDateString()) +
                        ", [dateFin]=" + MainMDI.SSV_date(dateTimePicker2.Value.ToShortDateString()) + ", [valid]=" + valid.ToString() +
                        " where VacaLID=" + lvacaID.Text;
                    MainMDI.Exec_SQL_JFS(stSql, "Update Vacation");
                }
                Clear_Conge();
            }
            else MessageBox.Show("Departement / Employee Name is Invalid ....");
        }

        void Clear_Conge()
        {
            btnSave.Text = "Save";
            //cbDep.Text = cbDep.Items[0].ToString();
            cbEmployees.Text = cbEmployees.Items[0].ToString();
            cbDep.Enabled = true;
            cbEmployees.Enabled = true;
            chk_Valid.Checked = true;
            lEmail.Text = "";
            lvacaID.Text = "";
        }

        private void Fill_Conges(string Depnb)
        {
            //(Depnb == "Select Departement")
            //string CondDep = (Depnb == "0" && pnlDisp.Visible) ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            string CondDep = (Depnb == "0") ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            string stSql = " SELECT  VacaLID,   XCNG_Departements.DepName, XCNG_Employees.Empl_Name, XCNG_Emp_Vacations.dateDeb, XCNG_Emp_Vacations.dateFin, XCNG_Employees.Depcode AS DC,  XCNG_Employees.EmpID AS EI,XCNG_Emp_Vacations.valid " +
                " FROM         XCNG_Departements INNER JOIN  XCNG_Employees ON XCNG_Departements.Depcode = XCNG_Employees.Depcode INNER JOIN XCNG_Emp_Vacations ON XCNG_Employees.EmpID = XCNG_Emp_Vacations.EmpID " +
                " WHERE     XCNG_Emp_Vacations.YYYY =" + DateTime.Now.Year.ToString() + CondDep;

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            string stdate = "";
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvITM.Items.Add(Oreadr["VacaLID"].ToString());
                lv.SubItems.Add(Oreadr["DepName"].ToString());
                lv.SubItems.Add(Oreadr["Empl_Name"].ToString());

                DateTime dt1;
                stdate= (DateTime.TryParse(Oreadr["dateDeb"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                lv.SubItems.Add(stdate);

                stdate = (DateTime.TryParse(Oreadr["dateFin"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                lv.SubItems.Add(stdate);

                lv.SubItems.Add(Oreadr["DC"].ToString());
                lv.SubItems.Add(Oreadr["EI"].ToString());

                string val = (Oreadr["valid"].ToString() == "True") ? "Yes" : "No";
                lv.SubItems.Add(val);
            }
            OConn.Close();
        }

        private void Fill_Conges(string Depnb, string pgcUsr)
        {
            //(Depnb == "Select Departement")
            //string CondDep = (Depnb == "0" && pnlDisp.Visible) ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            string CondDep = (Depnb == "0") ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            string CondPGCusr = (pgcUsr == "") ? "" : "AND (XCNG_Employees.PGC_usrNM ='" + pgcUsr + "')";
            string stSql = " SELECT  VacaLID,   XCNG_Departements.DepName, XCNG_Employees.Empl_Name, XCNG_Emp_Vacations.dateDeb, XCNG_Emp_Vacations.dateFin, XCNG_Employees.Depcode AS DC,  XCNG_Employees.EmpID AS EI,XCNG_Emp_Vacations.valid " +
                " FROM         XCNG_Departements INNER JOIN  XCNG_Employees ON XCNG_Departements.Depcode = XCNG_Employees.Depcode INNER JOIN XCNG_Emp_Vacations ON XCNG_Employees.EmpID = XCNG_Emp_Vacations.EmpID " +
                " WHERE     XCNG_Emp_Vacations.YYYY =" + DateTime.Now.Year.ToString() + CondDep + CondPGCusr;

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            string stdate = "";
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvITM.Items.Add(Oreadr["VacaLID"].ToString());
                lv.SubItems.Add(Oreadr["DepName"].ToString());
                lv.SubItems.Add(Oreadr["Empl_Name"].ToString());

                DateTime dt1;
                stdate = (DateTime.TryParse(Oreadr["dateDeb"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                lv.SubItems.Add(stdate);

                stdate = (DateTime.TryParse(Oreadr["dateFin"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                lv.SubItems.Add(stdate);

                lv.SubItems.Add(Oreadr["DC"].ToString());
                lv.SubItems.Add(Oreadr["EI"].ToString());

                string val = (Oreadr["valid"].ToString() == "True") ? "Yes" : "No";
                lv.SubItems.Add(val);
            }
            OConn.Close();
        }

        private void Fill_Conges_OLD(string Depnb)
        {
            //(Depnb == "Select Departement")
            //string CondDep = (Depnb == "0" && pnlDisp.Visible) ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            string CondDep = (Depnb == "0") ? "" : " AND XCNG_Employees.Depcode =" + Depnb;
            string stSql = " SELECT  VacaLID,   XCNG_Departements.DepName, XCNG_Employees.Empl_Name, XCNG_Emp_Vacations.dateDeb, XCNG_Emp_Vacations.dateFin, XCNG_Employees.Depcode AS DC,  XCNG_Employees.EmpID AS EI,XCNG_Emp_Vacations.valid " +
                " FROM         XCNG_Departements INNER JOIN  XCNG_Employees ON XCNG_Departements.Depcode = XCNG_Employees.Depcode INNER JOIN XCNG_Emp_Vacations ON XCNG_Employees.EmpID = XCNG_Emp_Vacations.EmpID " +
                " WHERE     XCNG_Emp_Vacations.YYYY =" + DateTime.Now.Year.ToString() + CondDep;

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            string stdate = "";
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvITM.Items.Add(Oreadr["VacaLID"].ToString());
                lv.SubItems.Add(Oreadr["DepName"].ToString());
                lv.SubItems.Add(Oreadr["Empl_Name"].ToString());

                DateTime dt1;
                stdate = (DateTime.TryParse(Oreadr["dateDeb"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                lv.SubItems.Add(stdate);

                stdate = (DateTime.TryParse(Oreadr["dateFin"].ToString(), out dt1)) ? dt1.ToShortDateString() : "";
                lv.SubItems.Add(stdate);

                lv.SubItems.Add(Oreadr["DC"].ToString());
                lv.SubItems.Add(Oreadr["EI"].ToString());

                string val = (Oreadr["valid"].ToString() == "True") ? "Yes" : "No";
                lv.SubItems.Add(val);
            }
            OConn.Close();
        }

        private void ed_lvITM_DoubleClick(object sender, EventArgs e)
        {
            if (pnlNew.Visible) edit_Conge();
        }

        void edit_Conge()
        {
            grpEntry.Visible = true;
            btnSave.Text = "Update";
            int ndx = ed_lvITM.SelectedItems[0].Index;
            lvacaID.Text = ed_lvITM.Items[ndx].SubItems[0].Text;
            cbDep.Text = ed_lvITM.Items[ndx].SubItems[1].Text;
            cbEmployees.Text = ed_lvITM.Items[ndx].SubItems[2].Text;
            dateTimePicker1.Text = ed_lvITM.Items[ndx].SubItems[3].Text;
            dateTimePicker2.Text = ed_lvITM.Items[ndx].SubItems[4].Text;
            cbDep.Enabled = false;
            cbEmployees.Enabled = false;
            chk_Valid.Checked = (ed_lvITM.Items[ndx].SubItems[7].Text == "Yes");

            Disp_pnls('N');
            ed_lvITM.Enabled = false;
        }

        void Check_Conges()
        {

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (MainMDI.ALWD_USR("GESTP_CNG_RW", true))
            //{
                Save_Conge();
                ed_lvITM.Enabled = true;
                Check_Conges();
                //Disp_pnls('D');
                Fill_Conges(ldepID.Text);
            //}
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //if (pnlNew.Visible)
            //{
                ////if (ed_lvITM.SelectedItems.Count > 0) if (MainMDI.Confirm("Want to Delete ???")) del_Conge();
                //if (MainMDI.ALWD_USR("GESTP_CNG_RW", true))
                //{
                    //if (ed_lvITM.SelectedItems.Count > 0) if (MainMDI.Confirm("Want to Delete ???")) del_Conge();
                //}
            //}
            if (ed_lvITM.SelectedItems.Count > 0) if (MainMDI.Confirm("Want to Delete ???")) del_Conge();
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Del_itm_Click(object sender, EventArgs e)
        {
            disp_allConges();
        }

        void disp_allConges()
        {
            cbEmployees.Enabled = true;
            cbDep.Enabled = true;
            ed_lvITM.Enabled = true;
            Disp_pnls('D');
        }

        void del_Conge()
        {
            if (ed_lvITM.SelectedItems.Count > 0) for (int i = ed_lvITM.SelectedItems.Count - 1; i > -1; i--)
                    MainMDI.Exec_SQL_JFS("delete XCNG_Emp_Vacations where  VacaLID=" + ed_lvITM.Items[ed_lvITM.SelectedItems[i].Index].SubItems[0].Text, "COngeee");
            Fill_Conges(ldepID.Text);
        }

        private void cbDepDisp_SelectedIndexChanged(object sender, EventArgs e)
        {
            ldepDispID.Text = MainMDI.get_CBX_value(cbDepDisp, cbDepDisp.SelectedIndex);
            Fill_Conges(ldepDispID.Text);
        }

        private void picDisp_Click(object sender, EventArgs e)
        {
            Fill_Conges(ldepDispID.Text);
        }

        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void picXL_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("GESTP_CNG_RW", true)) XL_Conge();
        }

        private void XL_Conge()
        {
            //ed_LVmodif ed_lvData;

            int ColDebut = 1;

            int NBCols = 5;
            object[] objHdrs = new object[NBCols]; //{ "Invoice #", "Sale / Agency Name", "Base Amount", "Commission %", "Commission Amount", "Currency", "Xchange rate ", "Commission Amount (CAD)", " cms Type " };

            for (int i = 0, jdata = ColDebut; i < NBCols; i++, jdata++) objHdrs[i] = ed_lvITM.Columns[jdata].Text; //ed_lvITM.Columns[i + 2].Text;

            string Fname = "Vacations_Details.xlsx";
            string CellFM = "A1", CellTO = "D1";

            object[,] objData = new object[MainMDI.MAX_XLlines_XPRT, NBCols];
            for (int i = 0; i < MainMDI.MAX_XLlines_XPRT; i++)
            {
                if (i < ed_lvITM.Items.Count)
                {
                    for (int j = ColDebut, jdata = 0; j < NBCols; j++, jdata++)
                    {
                        //string st = (jdata > 2) ? ed_lvITM.Items[i].SubItems[j].Text.Replace("/","-") : ed_lvITM.Items[i].SubItems[j].Text;
                        objData[i, jdata] = "'" + ed_lvITM.Items[i].SubItems[j].Text.Replace("/", "-");
                    }
                }
            }
            XL_EXPORT(Fname, objHdrs, NBCols, CellFM, CellTO, objData);
        }

        private void XL_EXPORT(string FName, object[] objHdrs, int HdrsNB, string CellFM, string CellTO, object[,] objData)
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

        private void btnEmail_Click(object sender, EventArgs e)
        {
            if (dateTimePicker2.Value > dateTimePicker1.Value)
            {
                if (lEmail.Text != "" && lEmail.Text.IndexOf("@") > 0)
                {
                    string FRM = (lEmail.Text == MainMDI.VIDE) ? "pgescom@primax-e.com" : lEmail.Text;
                    string sub = cbEmployees.Text + "....Vacances ",
                    bdy = "Bonjour\n Veuillez prendre en note que je serai en vacance du:" + dateTimePicker1.Value.ToShortDateString() + " jusqu'au " + dateTimePicker2.Value.ToShortDateString() + ".\nMerci et bonne journée.";
                    string TO = "Primax_Global@primax-e.com";
                    //string TO = "hedebbab@primax-e.com";

                    MainMDI.send_email(FRM.ToLower(), TO, sub, bdy);
                    MessageBox.Show("Message sent to: " + TO);
                    //Clear_Conge();
                }
            }
            else MessageBox.Show("Dates ERROR ....");
        }

        private void btnQuit_Click(object sender, EventArgs e)
        {
            disp_allConges();
        }
    }
}