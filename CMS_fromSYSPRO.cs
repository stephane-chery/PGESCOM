using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using EAHLibs;
using Org.BouncyCastle.Ocsp;

namespace PGESCOM
{
    public partial class CMS_fromSYSPRO : Form
    {
        public static EAHLibs.Lib1 Tools = new Lib1();
        const int LimY = 8, LimX = 500;
        string mykey = "agen";
        string[,] arr_Quotas = new string[LimX, LimY];
        double Quotas = 0, OutDD = 0;
        int ndx_INV = -1, old_ndx_INV = -1, ndx_CMS = -1, old_ndx_CMS = -1;
        string Yves_SalesPerson = "I06 - Yves Lavoie (Inside)", 
            HouseACNT_MESA = "MES001U - MESA Technical Associates, Inc",
            NSD_Sales = "I09 - Maria Ester Maturi (Inside)";

        public CMS_fromSYSPRO()
        {
            InitializeComponent();
        }

        void fill_CBsales()
        {
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

            //string stSql = (lSalesN.Text == "Inside Sales Names") ? "SELECT [HK_CMS_SALESin].[Expr1] FROM HK_CMS_SALESin ORDER BY [Expr1]" :
                //" SELECT DISTINCT dbo_SalSalesperson.Name, dbo_SalSalesperson.Salesperson " +
                //" FROM dbo_u_SalCommissionsPrimax INNER JOIN dbo_SalSalesperson ON (dbo_u_SalCommissionsPrimax.Salesperson = dbo_SalSalesperson.Salesperson) AND (dbo_u_SalCommissionsPrimax.Branch = dbo_SalSalesperson.Branch) " +
                //" WHERE (((Left([dbo_SalSalesperson]![Salesperson],1))='S' Or (Left([dbo_SalSalesperson]![Salesperson],1))='H')) " +
                //" ORDER BY dbo_SalSalesperson.Name";

            //string stSql = (lSalesN.Text == "Inside Sales Names") ? " SELECT [Salesperson] + ' - ' + [Name] AS Expr1 FROM SalSalesperson WHERE SalSalesperson.Branch='C1' And SUBSTRING([Salesperson],1,1)='I' order by Expr1"
                //: " SELECT DISTINCT SalSalesperson.Name, SalSalesperson.Salesperson  FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson) " +
                //" AND (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch)  " +
                //" WHERE SUBSTRING(SalSalesperson.Salesperson,1,1)='S'   ORDER BY SalSalesperson.Name ";

            string stSql = (lSalesN.Text == "Inside Sales Names") ? " SELECT [Salesperson] + ' - ' + [Name] AS Expr1 FROM SalSalesperson WHERE SalSalesperson.Branch='C1' And SUBSTRING([Salesperson],1,1)='I' order by Expr1"
                : " SELECT DISTINCT SalSalesperson.Name, SalSalesperson.Salesperson  FROM SalSalesperson  WHERE SUBSTRING(SalSalesperson.Salesperson,1,1)='S' and Salesperson not in('S00','S01','S02','S06','S07')   ORDER BY SalSalesperson.Name ";

            string toto = "";
            cbSales.Items.Clear();
            try
            {
                //OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);
                OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    toto = Oreadr[0].ToString();
                    cbSales.Items.Add(Oreadr[0].ToString());
                }
                //cbSales.Text = cbSales.Items[0].ToString();
                //cbSales.Text = PGCUsr_SalesName(MainMDI.User.ToLower());
            }
            catch (Exception ex)
            {
                MessageBox.Show("fill_cbSales_CMS_ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSql);
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
        }

        private void disp_finding(string IO, string _salNm, string InsindeSales)
        {
            lInsideS.Text = InsindeSales;
            object sender = null; EventArgs e = null;

            lSalesN.Text = (IO == "O") ? "Outside Sales Names" : "Inside Sales Names";
            grpSales.Visible = true;
            fill_CBsales();
            cbSales.Text = _salNm.TrimEnd();
            cbSales_SelectedIndexChanged(sender, e);
            //cb_MM.Text = cb_MM.Items[0].ToString();
            //cb_YY.Text = cb_YY.Items[0].ToString();
        }

        private void PGCUsr_SalesName(string PGC_usr)
        {
            lInsideS.Text = "";
            button2.Visible = false;
            email.Visible = false;
            switch (PGC_usr)
            {
                case "bcimon":
                    disp_finding("O", "Benoit Cimon                  ", "I07 - Benoit Cimon (Inside)                ");
                    break;
                case "ylavoie":
                    disp_finding("O", "Yves Lavoie                   ", "I06 - Yves Lavoie (Inside)                 ");
                    break;
                case "mloyer":
                    disp_finding("O", "Mario Loyer                   ", "");
                    break;
                case "blombard":
                    disp_finding("I", "I08 - Benoit Lombard                ", "");
                    break;
                case "mbyad":
                    disp_finding("I", "I02 - Mustapha Byad                 ", "");
                    break;
                case "smonk_bzzzz":
                    disp_finding("O", "Steven Monk                   ", "");
                    break;
                case "mmaturi":
                    //disp_finding("O", "Maria Ester Maturi                   ", "");
                    disp_finding("O", "Maria Ester Maturi                   ", "I09 - Maria Ester Maturi (Inside)          "); //"I09 - Maria Ester Maturi (Inside)                ");
                    break;
                case "cfouche":
                    disp_finding("I", "I03 - Claude Fouche                 ", "");
                    //txSalesName.Text = "I03 - Claude Fouche";
                    break;
                case "mdimassi":
                    disp_finding("I", "I01 - Mona Dimassi                  ", "");
                    break;
                case "mrouleau":
                    disp_finding("I", "I04 - Margaret Rouleau              ", "");
                    break;
                case "ede":
                case "hnasrat":
                case "ddarai":
                case "mmellouli":
                case "amvoinescu":
                    tsb_InsideS.Visible = true;
                    tsb_OutsideS.Visible = true;
                    cbSales.Visible = true;
                    grpSales.Visible = false;
                    button2.Visible = true;
                    email.Visible = true;

                    cb_MM.BringToFront();
                    cb_YY.BringToFront();
                    break;
                default:
                    //MessageBox.Show("USER Name ERROR .....Contact Admin......!!!!");
                    break;
            }
        }

        private void PGCUsr_SalesNameOLD(string PGC_usr)
        {
            lInsideS.Text = "";
            button2.Visible = false;
            email.Visible = false;
            switch (PGC_usr)
            {
                case "bcimon":
                    disp_finding("O", "Benoit Cimon                  ".TrimEnd(), "I07 - Benoit Cimon (Inside)                ".TrimEnd());
                    break;
                case "ylavoie":
                    disp_finding("O", "Yves Lavoie                   ".TrimEnd(), "I06 - Yves Lavoie (Inside)                 ".TrimEnd());
                    break;
                case "blombard":
                    disp_finding("I", "I08 - Benoit Lombard                ".TrimEnd(), "");
                    break;
                case "mbyad":
                    disp_finding("I", "I02 - Mustapha Byad                 ".TrimEnd(), "");
                    break;
                case "smonk":
                    disp_finding("O", "Steven Monk                   ".TrimEnd(), "");
                    break;
                case "cfouche":
                    disp_finding("I", "I03 - Claude Fouche                 ".TrimEnd(), "");
                    //txSalesName.Text = "I03 - Claude Fouche";
                    break;
                case "mdimassi":
                    disp_finding("I", "I01 - Mona Dimassi                  ".TrimEnd(), "");
                    break;
                case "mrouleau":
                    disp_finding("I", "I04 - Margaret Rouleau              ".TrimEnd(), "");
                    break;
                case "ede":
                case "hnasrat":
                case "ddarai":
                case "mmellouli":
                    tsb_InsideS.Visible = true;
                    tsb_OutsideS.Visible = true;
                    cbSales.Visible = true;
                    grpSales.Visible = false;
                    button2.Visible = true;
                    email.Visible = true;

                    cb_MM.BringToFront();
                    cb_YY.BringToFront();
                    break;
                default:
                    MessageBox.Show("USER Name ERROR .....Contact Admin......!!!!");
                    break;
            }
        }

        private void picDetailList_Click(object sender, EventArgs e)
        {

        }

        //sql dans SYSPRO

        //SELECT v_H_InsideSales.DateLastInvPrt,
        //v_H_InsideSales.FiscalYear, 
        //v_H_InsideSales.FiscalMonth, 
        //v_H_InsideSales.Project,
        //v_H_InsideSales.Customer, 
        //v_H_InsideSales.Invoice, v_H_InsideSales.Price, 
        //v_H_InsideSales.ExchangeRate, v_H_InsideSales.PriceCAD,
        //v_H_InsideSales.IntSalesperson, v_H_InsideSales.Salesperson, v_H_InsideSales.IntRate,
        //v_H_InsideSales.Amt, v_H_InsideSales.OrderQty, v_H_InsideSales.ShipQty
        //FROM v_H_InsideSales 
        //WHERE v_H_InsideSales.FiscalYear=2016 AND v_H_InsideSales.FiscalMonth=11 AND v_H_InsideSales.IntSalesperson='I01 - Mona Dimassi                  ' 
        //ORDER BY v_H_InsideSales.Invoice

        //sql dans SYSPRO

        private void Fill_TOT_bySALESName()
        {
            string[,] my_Arr_TOT = new string[cbSales.Items.Count, 2];
            string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            string stSql = "";

            for (int i = 0, T = 0; i < cbSales.Items.Count; i++, T++)
            {
                switch (lSalesN.Text)
                {
                    case "Inside Sales Names":
                        string InsideSP = (cbSales.Items[i].ToString().Length > 30) ? cbSales.Items[i].ToString().Substring(0, 30) : cbSales.Items[i].ToString();
                        //if (cbSales.Items[i].ToString() == Yves_SalesPerson) //NSD_Sales)
                            //stSql = " SELECT Sum(v_H_InsideSales.Amt) AS TOT FROM v_H_InsideSales   " +
                                //" WHERE (LOWER([Project]) not like '%cigentec%') AND  v_H_InsideSales.IntSalesperson ='" + Yves_SalesPerson + "' AND v_H_InsideSales.FiscalYear=" + cb_YY.Text + " AND v_H_InsideSales.FiscalMonth=" + MM + " AND ([Customer]='" + HouseACNT_MESA + "')";
                        //else
                            stSql = " SELECT Sum(v_H_InsideSales.Amt) AS TOT FROM v_H_InsideSales   " +
                                " WHERE (LOWER([Project]) not like '%cigentec%') AND  v_H_InsideSales.IntSalesperson ='" + InsideSP + "' AND v_H_InsideSales.FiscalYear=" + cb_YY.Text + " AND v_H_InsideSales.FiscalMonth=" + MM;
                        break;
                    case "Outside Sales Names":
                        stSql = " SELECT   sum(CommissionAmt1) AS CommissionAmt1 FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson) AND (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch) " +
                            " WHERE (LOWER([Project]) not like '%cigentec%') AND  SalSalesperson.Name='" + cbSales.Items[i].ToString() + "' AND u_SalCommissionsPrimax.FiscalYear=" + cb_YY.Text + " AND u_SalCommissionsPrimax.FiscalMonth=" + MM + " AND u_SalCommissionsPrimax.Salesperson<>'A'";
                        break;
                }
                stSql = MainMDI.Find_One_Field_SYSPRO(stSql);
                double amt = Tools.Conv_Dbl(stSql);

                my_Arr_TOT[T, 0] = cbSales.Items[i].ToString();
                my_Arr_TOT[T, 1] = MainMDI.Curr_FRMT(Math.Round(amt, 2).ToString());
            }
            CMS_TOTALS frm_tot = new CMS_TOTALS(my_Arr_TOT);
            frm_tot.ShowDialog();
        }

        void fill_Details_List_Inside()
        {
            string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            double TOT = 0;

            //OleDbConnection OConn = null;
            //OleDbCommand Ocmd = null;
            //OleDbDataReader Oreadr = null;
            //OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);

            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

            ////Access
            //string stSQL = " SELECT InsideSales.DateLastInvPrt, InsideSales.FiscalYear, InsideSales.FiscalMonth, InsideSales.Project, InsideSales.Customer, InsideSales.Invoice, " +
                //"       InsideSales.Price, InsideSales.ExchangeRate, InsideSales.PriceCAD, InsideSales.IntSalesperson, InsideSales.Salesperson, InsideSales.IntRate, InsideSales.Amt, InsideSales.OrderQty, InsideSales.ShipQty " +
                //" FROM InsideSales WHERE InsideSales.FiscalYear=" + cb_YY.Text + " AND InsideSales.FiscalMonth=" + MM + " AND InsideSales.IntSalesperson='" + txSalesName.Text + "'" +
                //" ORDER BY InsideSales.Invoice";

            string stSQL = "";
            //if (cbSales.Text == NSD_Sales)
                //stSQL = " SELECT v_H_InsideSales.DateLastInvPrt,  v_H_InsideSales.FiscalYear, v_H_InsideSales.FiscalMonth, v_H_InsideSales.Project, v_H_InsideSales.Customer, v_H_InsideSales.Invoice,        v_H_InsideSales.Price, v_H_InsideSales.ExchangeRate, v_H_InsideSales.PriceCAD, v_H_InsideSales.IntSalesperson, v_H_InsideSales.Salesperson, v_H_InsideSales.IntRate, v_H_InsideSales.Amt, v_H_InsideSales.OrderQty, v_H_InsideSales.ShipQty  " +
                    //" FROM v_H_InsideSales " +
                    //" WHERE   (LOWER([Project]) not like '%cigentec%') AND   v_H_InsideSales.FiscalYear=" + cb_YY.Text + " AND v_H_InsideSales.FiscalMonth=" + MM + " AND v_H_InsideSales.IntSalesperson='" + Yves_SalesPerson + "' AND Customer='" + HouseACNT_MESA + "'" +
                    //" ORDER BY v_H_InsideSales.Invoice ";
            //
            //string InsideSP = txSalesName.Text.Substring(0, 30);
            string InsideSP = (txSalesName.Text.Length > 30) ? txSalesName.Text.Substring(0, 30) : txSalesName.Text;
            stSQL = " SELECT v_H_InsideSales.DateLastInvPrt,  v_H_InsideSales.FiscalYear, v_H_InsideSales.FiscalMonth, v_H_InsideSales.Project, v_H_InsideSales.Customer, v_H_InsideSales.Invoice,        v_H_InsideSales.Price, v_H_InsideSales.ExchangeRate, v_H_InsideSales.PriceCAD, v_H_InsideSales.IntSalesperson, v_H_InsideSales.Salesperson, v_H_InsideSales.IntRate, v_H_InsideSales.Amt, v_H_InsideSales.OrderQty, v_H_InsideSales.ShipQty  " +
                " FROM v_H_InsideSales " +
                " WHERE   (LOWER([Project]) not like '%cigentec%') AND   v_H_InsideSales.FiscalYear=" + cb_YY.Text + " AND v_H_InsideSales.FiscalMonth=" + MM + " AND v_H_InsideSales.IntSalesperson='" + InsideSP + "'" +
                " ORDER BY v_H_InsideSales.Invoice ";

            ed_LVallInvoices.SendToBack();
            ed_lvITM.Items.Clear();
            try
            {
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {
                    ListViewItem lv = ed_lvITM.Items.Add(""); 
                    for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");

                    lv.SubItems[0].Text = Oreadr["Project"].ToString();
                    lv.SubItems[1].Text = Oreadr["Invoice"].ToString();
                    lv.SubItems[2].Text = MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");
                    lv.SubItems[3].Text = Oreadr["Customer"].ToString();

                    decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                    decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                    decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());

                    //lv.SubItems[4].Text = MainMDI.Curr_FRMT(Math.Round(UP,2).ToString());
                    lv.SubItems[4].Text = Math.Round(UP, 2).ToString();

                    lv.SubItems[5].Text = Math.Round(Qty, 2).ToString();
                    lv.SubItems[6].Text = Math.Round(xrt, 2).ToString();

                    decimal Tot = UP * Qty * xrt;
                    double amt = Tools.Conv_Dbl(Oreadr["Amt"].ToString());
                    double Irt = Tools.Conv_Dbl(Oreadr["IntRate"].ToString()) * 100;

                    TOT += amt;

                    //lv.SubItems[7].Text = MainMDI.Curr_FRMT(Math.Round(Tot, 2).ToString());
                    //lv.SubItems[8].Text = MainMDI.Curr_FRMT(Irt.ToString());
                    //lv.SubItems[9].Text = MainMDI.Curr_FRMT(Math.Round(amt, 2).ToString());

                    lv.SubItems[7].Text = Math.Round(Tot, 2).ToString();
                    lv.SubItems[8].Text = Irt.ToString();
                    lv.SubItems[9].Text = Math.Round(amt, 2).ToString();

                    //lv.SubItems[10].Text = find_QT_date(Oreadr["Project"].ToString());
                    lv.SubItems[10].Text = find_Insid_Sales(Oreadr["Project"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("fill_Details_CMS_ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL);
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
            txTOT.Text = MainMDI.Curr_FRMT(Math.Round(TOT, 2).ToString());
        }

        void fill_Details_List_OUT_IN()
        {
            string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            double TOT = 0;

            //OleDbConnection OConn = null;
            //OleDbCommand Ocmd = null;
            //OleDbDataReader Oreadr = null;
            //OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);

            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

            ////Access
            //string stSQL = " SELECT InsideSales.DateLastInvPrt, InsideSales.FiscalYear, InsideSales.FiscalMonth, InsideSales.Project, InsideSales.Customer, InsideSales.Invoice, " +
            //"       InsideSales.Price, InsideSales.ExchangeRate, InsideSales.PriceCAD, InsideSales.IntSalesperson, InsideSales.Salesperson, InsideSales.IntRate, InsideSales.Amt, InsideSales.OrderQty, InsideSales.ShipQty " +
            //" FROM InsideSales WHERE InsideSales.FiscalYear=" + cb_YY.Text + " AND InsideSales.FiscalMonth=" + MM + " AND InsideSales.IntSalesperson='" + txSalesName.Text + "'" +
            //" ORDER BY InsideSales.Invoice";

            string stSQL = "";
            if (cbSales.Text == NSD_Sales)
                stSQL = " SELECT v_H_InsideSales.DateLastInvPrt,  v_H_InsideSales.FiscalYear, v_H_InsideSales.FiscalMonth, v_H_InsideSales.Project, v_H_InsideSales.Customer, v_H_InsideSales.Invoice,        v_H_InsideSales.Price, v_H_InsideSales.ExchangeRate, v_H_InsideSales.PriceCAD, v_H_InsideSales.IntSalesperson, v_H_InsideSales.Salesperson, v_H_InsideSales.IntRate, v_H_InsideSales.Amt, v_H_InsideSales.OrderQty, v_H_InsideSales.ShipQty  " +
                    " FROM v_H_InsideSales " +
                    " WHERE   (LOWER([Project]) not like '%cigentec%') AND   v_H_InsideSales.FiscalYear=" + cb_YY.Text + " AND v_H_InsideSales.FiscalMonth=" + MM + " AND v_H_InsideSales.IntSalesperson='" + Yves_SalesPerson + "' AND Customer='" + HouseACNT_MESA + "'" +
                    " ORDER BY v_H_InsideSales.Invoice ";
            else
                stSQL = " SELECT v_H_InsideSales.DateLastInvPrt,  v_H_InsideSales.FiscalYear, v_H_InsideSales.FiscalMonth, v_H_InsideSales.Project, v_H_InsideSales.Customer, v_H_InsideSales.Invoice,        v_H_InsideSales.Price, v_H_InsideSales.ExchangeRate, v_H_InsideSales.PriceCAD, v_H_InsideSales.IntSalesperson, v_H_InsideSales.Salesperson, v_H_InsideSales.IntRate, v_H_InsideSales.Amt, v_H_InsideSales.OrderQty, v_H_InsideSales.ShipQty  " +
                    " FROM v_H_InsideSales " +
                    " WHERE   (LOWER([Project]) not like '%cigentec%') AND   v_H_InsideSales.FiscalYear=" + cb_YY.Text + " AND v_H_InsideSales.FiscalMonth=" + MM + " AND v_H_InsideSales.IntSalesperson='" + txSalesName.Text + "'" +
                    " ORDER BY v_H_InsideSales.Invoice ";

            ed_LVallInvoices.SendToBack();
            ed_lvITM.Items.Clear();
            try
            {
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {
                    ListViewItem lv = ed_lvITM.Items.Add(""); 
                    for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");

                    lv.SubItems[0].Text = Oreadr["Project"].ToString();
                    lv.SubItems[1].Text = Oreadr["Invoice"].ToString();
                    lv.SubItems[2].Text = MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");
                    lv.SubItems[3].Text = Oreadr["Customer"].ToString();

                    decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                    decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                    decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());

                    //lv.SubItems[4].Text = MainMDI.Curr_FRMT(Math.Round(UP, 2).ToString());
                    lv.SubItems[4].Text = Math.Round(UP, 2).ToString();

                    lv.SubItems[5].Text = Math.Round(Qty, 2).ToString();
                    lv.SubItems[6].Text = Math.Round(xrt, 2).ToString();

                    decimal Tot = UP * Qty * xrt;
                    double amt = Tools.Conv_Dbl(Oreadr["Amt"].ToString());
                    double Irt = Tools.Conv_Dbl(Oreadr["IntRate"].ToString()) * 100;

                    TOT += amt;

                    //lv.SubItems[7].Text = MainMDI.Curr_FRMT(Math.Round(Tot, 2).ToString());
                    //lv.SubItems[8].Text = MainMDI.Curr_FRMT(Irt.ToString());
                    //lv.SubItems[9].Text = MainMDI.Curr_FRMT(Math.Round(amt, 2).ToString());

                    lv.SubItems[7].Text = Math.Round(Tot, 2).ToString();
                    lv.SubItems[8].Text = Irt.ToString();
                    lv.SubItems[9].Text = Math.Round(amt, 2).ToString();

                    lv.SubItems[10].Text = find_QT_date(Oreadr["Project"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("fill_Details_CMS_ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL);
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
            txTOT.Text = MainMDI.Curr_FRMT(Math.Round(TOT, 2).ToString());
        }

        //10012019 using: SalSal_terri_IN
        void fill_Details_List_Inside_NEW()
        {
            string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            double TOT = 0;
            bool process = false;
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

            string stSQL = " SELECT v_H_InsideSales.DateLastInvPrt,  v_H_InsideSales.FiscalYear, v_H_InsideSales.FiscalMonth, v_H_InsideSales.Project, v_H_InsideSales.Customer, v_H_InsideSales.Invoice,        v_H_InsideSales.Price, v_H_InsideSales.ExchangeRate, v_H_InsideSales.PriceCAD, v_H_InsideSales.IntSalesperson, v_H_InsideSales.Salesperson, v_H_InsideSales.IntRate, v_H_InsideSales.Amt, v_H_InsideSales.OrderQty, v_H_InsideSales.ShipQty  " +
                " FROM v_H_InsideSales " +
                " WHERE   (LOWER([Project]) not like '%cigentec%') AND   v_H_InsideSales.FiscalYear=" + cb_YY.Text + " AND v_H_InsideSales.FiscalMonth=" + MM + " AND v_H_InsideSales.IntSalesperson='" + txSalesName.Text + "'" +
                " ORDER BY v_H_InsideSales.Invoice ";

            ed_LVallInvoices.SendToBack();
            ed_lvITM.Items.Clear();
            try
            {
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();

                //intsalesperson not in the list 
                string stt = "select Customer_SPcode from SalSal_OSI_Y where Salesperson='" + txSalesName.Text + "'";
                bool pass = (MainMDI.Find_One_Field(stt) == MainMDI.VIDE);

                while (Oreadr.Read())
                {
                    if (!pass)
                    {
                        //intsalesperson is in the list 
                        string custRES = MainMDI.Find_One_Field("select Customer_SPcode from SalSal_OSI_Y where Salesperson='" + 
                            Oreadr["IntSaleperson"].ToString() + "' and Terri='" + Oreadr["Saleperson"].ToString() + "'");
                        process = (custRES != MainMDI.VIDE);
                    }
                    else process = true;
                    if (process)
                    {
                        ListViewItem lv = ed_lvITM.Items.Add(""); 
                        for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");

                        lv.SubItems[0].Text = Oreadr["Project"].ToString();
                        lv.SubItems[1].Text = Oreadr["Invoice"].ToString();
                        lv.SubItems[2].Text = MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");
                        lv.SubItems[3].Text = Oreadr["Customer"].ToString();

                        decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                        decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                        decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());

                        lv.SubItems[4].Text = Math.Round(UP, 2).ToString();
                        lv.SubItems[5].Text = Math.Round(Qty, 2).ToString();
                        lv.SubItems[6].Text = Math.Round(xrt, 2).ToString();

                        decimal Tot = UP * Qty * xrt;
                        double amt = Tools.Conv_Dbl(Oreadr["Amt"].ToString());
                        double Irt = Tools.Conv_Dbl(Oreadr["IntRate"].ToString()) * 100;
                        TOT += amt;

                        lv.SubItems[7].Text = Math.Round(Tot, 2).ToString();
                        lv.SubItems[8].Text = Irt.ToString();
                        lv.SubItems[9].Text = Math.Round(amt, 2).ToString();
                        lv.SubItems[10].Text = find_QT_date(Oreadr["Project"].ToString());
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("fill_Details_CMS_ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL);
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
            txTOT.Text = MainMDI.Curr_FRMT(Math.Round(TOT, 2).ToString());
        }

        void Check_Quota_Access()
        {
            string stSql = " SELECT dbo_SalCommissionSalesThreshold.Threshold" +
                " FROM dbo_SalCommissionSalesThreshold " +
                " WHERE (((dbo_SalCommissionSalesThreshold.ExtSalesperson)='" + lSalesCode.Text + "')" +
                " AND ((dbo_SalCommissionSalesThreshold.Active)=True))";
            Quotas = Tools.Conv_Dbl(MainMDI.Find_One_Field_ACCESS(stSql));

            stSql = " SELECT dbo_SalCommissionDefaultRates.Rate" +
                " FROM dbo_SalCommissionDefaultRates" +
                " WHERE (((dbo_SalCommissionDefaultRates.RateCode)='X'))";
            lRate.Text = MainMDI.Find_One_Field_ACCESS(stSql);

            if (Quotas > 0) Load_ventesAn(txSalesName.Text, Int32.Parse(cb_YY.Text));
        }

        void Check_Quota()
        {
            string stSql = " SELECT SalCommissionSalesThreshold.Threshold" +
                " FROM SalCommissionSalesThreshold " +
                " WHERE (((SalCommissionSalesThreshold.ExtSalesperson)='" + lSalesCode.Text + "')" +
                "        AND ((SalCommissionSalesThreshold.Active)=1))";
            Quotas = Tools.Conv_Dbl(MainMDI.Find_One_Field_SYSPRO(stSql));

            stSql = " SELECT SalCommissionDefaultRates.Rate" +
                " FROM SalCommissionDefaultRates" +
                " WHERE (((SalCommissionDefaultRates.RateCode)='X'))";
            lRate.Text = MainMDI.Find_One_Field_SYSPRO(stSql);

            if (Quotas > 0) Load_ventesAn(txSalesName.Text, Int32.Parse(cb_YY.Text));
        }

        //sql syspro

        //SELECT SalSalesperson.Salesperson, 
        //SalSalesperson.Name,
        //u_SalCommissionsPrimax.DateLastInvPrt, 
        //u_SalCommissionsPrimax.FiscalYear, 
        //u_SalCommissionsPrimax.FiscalMonth,
        //u_SalCommissionsPrimax.Project,
        //u_SalCommissionsPrimax.Customer, 
        //u_SalCommissionsPrimax.Currency,
        //u_SalCommissionsPrimax.Branch, 
        //u_SalCommissionsPrimax.Invoice, 
        //u_SalCommissionsPrimax.SalesOrder,
        //u_SalCommissionsPrimax.SalesOrderLine,
        //u_SalCommissionsPrimax.StockCode,
        //u_SalCommissionsPrimax.StockDescription, 
        //u_SalCommissionsPrimax.OrderQty, 
        //u_SalCommissionsPrimax.ShipQty, 
        //u_SalCommissionsPrimax.BackOrderQty, 
        //u_SalCommissionsPrimax.Price, 
        //u_SalCommissionsPrimax.ExchangeRate,
        //u_SalCommissionsPrimax.PriceCAD, 
        //u_SalCommissionsPrimax.ProductClass, 
        //u_SalCommissionsPrimax.CommissionSales1, 
        //(cast ([CommissionAmt1] AS decimal)) AS CommissionAmt1,
        //u_SalCommissionsPrimax.Salesperson2, 
        //u_SalCommissionsPrimax.CommissionSales2,
        //u_SalCommissionsPrimax.CommissionAmt2, 
        //u_SalCommissionsPrimax.Salesperson3, 
        //u_SalCommissionsPrimax.CommissionSales3, 
        //u_SalCommissionsPrimax.CommissionAmt3, 
        //u_SalCommissionsPrimax.Salesperson4,
        //u_SalCommissionsPrimax.CommissionSales4,
        //u_SalCommissionsPrimax.Rate, 
        //u_SalCommissionsPrimax.OrderQty, 
        //u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.Rate
        //FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch) AND (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson)
        //WHERE (((SalSalesperson.Name)='Yves Lavoie                   ') AND ((u_SalCommissionsPrimax.Salesperson)<>'A')) 
        //ORDER BY Project

        //sql syspro

        void fill_CMS_OUTIN()
        {
            string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            double TOT_in = 0;

            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

            string stSQL = " SELECT v_H_InsideSales.DateLastInvPrt,  v_H_InsideSales.FiscalYear, v_H_InsideSales.FiscalMonth, v_H_InsideSales.Project, v_H_InsideSales.Customer, v_H_InsideSales.Invoice,        v_H_InsideSales.Price, v_H_InsideSales.ExchangeRate, v_H_InsideSales.PriceCAD, v_H_InsideSales.IntSalesperson, v_H_InsideSales.Salesperson, v_H_InsideSales.IntRate, v_H_InsideSales.Amt, v_H_InsideSales.OrderQty, v_H_InsideSales.ShipQty  " +
                " FROM v_H_InsideSales " +
                " WHERE   (LOWER([Project]) not like '%cigentec%') AND   v_H_InsideSales.FiscalYear=" + cb_YY.Text + " AND v_H_InsideSales.FiscalMonth=" + MM + " AND v_H_InsideSales.IntSalesperson='" + lInsideS.Text + "'" +
                " ORDER BY v_H_InsideSales.Invoice ";

            ed_LVallInvoices.SendToBack();
            ed_lvITM.Items.Clear();
            try
            {
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {
                    ListViewItem lv = ed_lvITM.Items.Add(""); 
                    for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");

                    lv.SubItems[0].Text = Oreadr["Project"].ToString();
                    lv.SubItems[1].Text = Oreadr["Invoice"].ToString();
                    lv.SubItems[2].Text = MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");
                    lv.SubItems[3].Text = Oreadr["Customer"].ToString();

                    decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                    decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                    decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());

                    //lv.SubItems[4].Text = MainMDI.Curr_FRMT(Math.Round(UP, 2).ToString());
                    lv.SubItems[4].Text = Math.Round(UP, 2).ToString();

                    lv.SubItems[5].Text = Math.Round(Qty, 2).ToString();
                    lv.SubItems[6].Text = Math.Round(xrt, 2).ToString();

                    decimal Tot = UP * Qty * xrt;
                    double amt = Tools.Conv_Dbl(Oreadr["Amt"].ToString());
                    double Irt = Tools.Conv_Dbl(Oreadr["IntRate"].ToString()) * 100;

                    TOT_in += amt;

                    //lv.SubItems[7].Text = MainMDI.Curr_FRMT(Math.Round(Tot, 2).ToString());
                    //lv.SubItems[8].Text = MainMDI.Curr_FRMT(Irt.ToString());
                    //lv.SubItems[9].Text = MainMDI.Curr_FRMT(Math.Round(amt, 2).ToString());

                    lv.SubItems[7].Text = Math.Round(Tot, 2).ToString();
                    lv.SubItems[8].Text = Irt.ToString();
                    lv.SubItems[9].Text = Math.Round(amt, 2).ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("fill_Details_CMS_ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL);
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
            txTOT.Text = MainMDI.Curr_FRMT(Math.Round(TOT_in, 2).ToString() + Tools.Conv_Dbl(txTOT.Text));
        }

        void fill_CMS_Out_INside()
        {
            string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            double TOT_in = 0;
            decimal TOTSales_in = 0;

            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

            Check_Quota();

            string InsideSP = (lInsideS.Text.Length > 30) ? lInsideS.Text.Substring(0, 30) : lInsideS.Text;

            string stSQL = " SELECT v_H_InsideSales.DateLastInvPrt,  v_H_InsideSales.FiscalYear, v_H_InsideSales.FiscalMonth, v_H_InsideSales.Project, v_H_InsideSales.Customer, v_H_InsideSales.Invoice,        v_H_InsideSales.Price, v_H_InsideSales.ExchangeRate, v_H_InsideSales.PriceCAD, v_H_InsideSales.IntSalesperson, v_H_InsideSales.Salesperson, v_H_InsideSales.IntRate, v_H_InsideSales.Amt, v_H_InsideSales.OrderQty, v_H_InsideSales.ShipQty  " +
                " FROM v_H_InsideSales " +
                " WHERE   (LOWER([Project]) not like '%cigentec%') AND   v_H_InsideSales.FiscalYear=" + cb_YY.Text + " AND v_H_InsideSales.FiscalMonth=" + MM + " AND v_H_InsideSales.IntSalesperson='" + InsideSP + "'" +
                " ORDER BY v_H_InsideSales.Invoice ";

            string stout = "";

            try
            {
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {
                    ListViewItem lv = ed_lvITM.Items.Add(""); 
                    for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");

                    lv.SubItems[0].Text = Oreadr["Project"].ToString();
                    lv.SubItems[1].Text = Oreadr["Invoice"].ToString();
                    lv.SubItems[2].Text = MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");
                    lv.SubItems[3].Text = Oreadr["Customer"].ToString();

                    decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                    decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                    decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());

                    //lv.SubItems[4].Text = MainMDI.Curr_FRMT(Math.Round(UP, 2).ToString());
                    lv.SubItems[4].Text = Math.Round(UP, 2).ToString();
                    lv.SubItems[5].Text = Math.Round(Qty, 2).ToString();
                    lv.SubItems[6].Text = Math.Round(xrt, 2).ToString();

                    decimal Tot = UP * Qty * xrt;
                    double amt = Tools.Conv_Dbl(Oreadr["Amt"].ToString());
                    double Irt = Tools.Conv_Dbl(Oreadr["IntRate"].ToString()) * 100;
                    double diff = 0;

                    if (Quotas > 0)
                    {
                        if (!isThresholdOK(txSalesName.Text, Oreadr["DateLastInvPrt"].ToString(), MM, Oreadr["Invoice"].ToString(), 
                            Oreadr["SalesOrderLine"].ToString(), ref diff)) amt = 0;
                        else if (diff > 0) amt = diff * Tools.Conv_Dbl(lRate.Text);
                    }
                    //lv.SubItems[7].Text = MainMDI.Curr_FRMT(Math.Round(Tot, 2).ToString()); TOTSales += Tot;
                    //lv.SubItems[8].Text = ""; //MainMDI.Curr_FRMT(Irt.ToString());
                    //lv.SubItems[9].Text = MainMDI.Curr_FRMT(Math.Round(amt, 2).ToString());

                    lv.SubItems[7].Text = Math.Round(Tot, 2).ToString(); TOTSales_in += Tot;
                    lv.SubItems[8].Text = ""; //MainMDI.Curr_FRMT(Irt.ToString());
                    lv.SubItems[9].Text = Math.Round(amt, 2).ToString();

                    TOT_in += amt;
                    stout += amt + "\n";
                    lv.ForeColor = Color.Blue;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("fill_CMS_Out_INside--> ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL);
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
            double dd = Math.Round(TOT_in + OutDD, 2);
            txTOT.Text = MainMDI.Curr_FRMT(dd.ToString());
          
            //lTOTperMM.Text = TOTSales_in.ToString();
        }

        string find_QT_date(string _project)
        {
            int pos = _project.IndexOf("_");
            string dat = "?????", rid = "";
            if (pos > -1) rid = _project.Substring(0, pos);
            if (Tools.Conv_Dbl(rid) > 100) 
                dat = MainMDI.Find_One_Field("SELECT PSM_Q_IGen.Opndate" +
                    " FROM PSM_R_Rev INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid	" +
                    " where RID=" + rid);
            if (dat != MainMDI.VIDE && dat.Length > 10) return dat.Substring(0, 10);
            else return "?????";
        }

        string find_Insid_Sales(string _project)
        {
            int pos = _project.IndexOf("_");
            string dat = "?????", rid = "";
            if (pos > -1) rid = _project.Substring(0, pos);
            if (Tools.Conv_Dbl(rid) > 100)
                dat = MainMDI.Find_One_Field("  SELECT PSM_SALES_AGENTS.First_Name + ' ' +PSM_SALES_AGENTS.Last_Name " +
                " FROM   PSM_R_Rev INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid" +
                "        INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID" +
                " where RID=" + rid);
            if (dat != MainMDI.VIDE) return dat;
            else return "?????";
        }

        void fill_Details_List_Outside()
        {
            string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            double TOT = 0;
            decimal TOTSales = 0;

            //OleDbConnection OConn = null;
            //OleDbCommand Ocmd = null;
            //OleDbDataReader Oreadr = null;
            //OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);

            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

            Check_Quota();

            //string stSQL = " SELECT dbo_SalSalesperson.Salesperson, dbo_SalSalesperson.Name, dbo_u_SalCommissionsPrimax.DateLastInvPrt, dbo_u_SalCommissionsPrimax.FiscalYear, dbo_u_SalCommissionsPrimax.FiscalMonth, dbo_u_SalCommissionsPrimax.Project, dbo_u_SalCommissionsPrimax.Customer, dbo_u_SalCommissionsPrimax.Currency, dbo_u_SalCommissionsPrimax.Branch, dbo_u_SalCommissionsPrimax.Invoice, dbo_u_SalCommissionsPrimax.SalesOrder, dbo_u_SalCommissionsPrimax.SalesOrderLine, dbo_u_SalCommissionsPrimax.StockCode, " +
                //"        dbo_u_SalCommissionsPrimax.StockDescription, dbo_u_SalCommissionsPrimax.OrderQty, dbo_u_SalCommissionsPrimax.ShipQty, dbo_u_SalCommissionsPrimax.BackOrderQty, dbo_u_SalCommissionsPrimax.Price, dbo_u_SalCommissionsPrimax.ExchangeRate, dbo_u_SalCommissionsPrimax.PriceCAD, dbo_u_SalCommissionsPrimax.ProductClass, dbo_u_SalCommissionsPrimax.CommissionSales1, CDbl([CommissionAmt1]) AS 1CommissionAmt1, dbo_u_SalCommissionsPrimax.Salesperson2, dbo_u_SalCommissionsPrimax.CommissionSales2, " +
                //"        dbo_u_SalCommissionsPrimax.CommissionAmt2, dbo_u_SalCommissionsPrimax.Salesperson3, dbo_u_SalCommissionsPrimax.CommissionSales3, dbo_u_SalCommissionsPrimax.CommissionAmt3, dbo_u_SalCommissionsPrimax.Salesperson4, dbo_u_SalCommissionsPrimax.CommissionSales4, dbo_u_SalCommissionsPrimax.Rate, dbo_u_SalCommissionsPrimax.OrderQty, dbo_u_SalCommissionsPrimax.ShipQty, dbo_u_SalCommissionsPrimax.Rate  " +
                //" FROM dbo_u_SalCommissionsPrimax INNER JOIN dbo_SalSalesperson ON (dbo_u_SalCommissionsPrimax.Branch = dbo_SalSalesperson.Branch) AND (dbo_u_SalCommissionsPrimax.Salesperson = dbo_SalSalesperson.Salesperson) " +
                //" WHERE (((dbo_SalSalesperson.Name)='" + txSalesName.Text + "') AND ((dbo_u_SalCommissionsPrimax.FiscalYear)=" + cb_YY.Text + ") AND ((dbo_u_SalCommissionsPrimax.FiscalMonth)=" + MM + ") AND ((dbo_u_SalCommissionsPrimax.Salesperson)<>'A')) " +
                //" ORDER BY dbo_u_SalCommissionsPrimax.Invoice";

            string stSQL = " SELECT SalSalesperson.Salesperson, SalSalesperson.Name, u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Project, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Currency, " +
                "        u_SalCommissionsPrimax.Branch,u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.SalesOrder, u_SalCommissionsPrimax.SalesOrderLine, u_SalCommissionsPrimax.StockCode,         u_SalCommissionsPrimax.StockDescription, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, " +
                "        u_SalCommissionsPrimax.BackOrderQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.ExchangeRate, u_SalCommissionsPrimax.PriceCAD, u_SalCommissionsPrimax.ProductClass, u_SalCommissionsPrimax.CommissionSales1, (cast ([CommissionAmt1] AS decimal)) AS CommissionAmt1,  u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2,   " +
                "        u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.Salesperson3, u_SalCommissionsPrimax.CommissionSales3, u_SalCommissionsPrimax.CommissionAmt3, u_SalCommissionsPrimax.Salesperson4, u_SalCommissionsPrimax.CommissionSales4, u_SalCommissionsPrimax.Rate, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.Rate  " +
                " FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch) AND (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson)  " +
                " WHERE (((SalSalesperson.Name)='" + txSalesName.Text + "') AND ((u_SalCommissionsPrimax.FiscalYear)=" + cb_YY.Text + ") AND ((u_SalCommissionsPrimax.FiscalMonth)=" + MM + ") AND ((u_SalCommissionsPrimax.Salesperson)<>'A'))   and (LOWER([Project]) not like '%cigentec%')    " +
                " ORDER BY u_SalCommissionsPrimax.Invoice";

            string stout = "";
            ed_LVallInvoices.SendToBack();
            ed_lvITM.Items.Clear();
            try
            {
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {
                    ListViewItem lv = ed_lvITM.Items.Add(""); 
                    for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");

                    lv.SubItems[0].Text = Oreadr["Project"].ToString();
                    lv.SubItems[1].Text = Oreadr["Invoice"].ToString();
                    lv.SubItems[2].Text = MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");
                    lv.SubItems[3].Text = Oreadr["Customer"].ToString();

                    decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                    decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                    decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());

                    //lv.SubItems[4].Text = MainMDI.Curr_FRMT(Math.Round(UP, 2).ToString());
                    lv.SubItems[4].Text = Math.Round(UP, 2).ToString();
                    lv.SubItems[5].Text = Math.Round(Qty, 2).ToString();
                    lv.SubItems[6].Text = Math.Round(xrt, 2).ToString();

                    decimal Tot = UP * Qty * xrt;
                    double amt = Tools.Conv_Dbl(Oreadr["CommissionAmt1"].ToString());
                    double Irt = Tools.Conv_Dbl(Oreadr["Rate"].ToString()) * 100;
                    double diff = 0;

                    if (Quotas > 0)
                    {
                        if (!isThresholdOK(txSalesName.Text, Oreadr["DateLastInvPrt"].ToString(), MM, Oreadr["Invoice"].ToString(), 
                            Oreadr["SalesOrderLine"].ToString(), ref diff)) amt = 0;
                        else if (diff > 0) amt = diff * Tools.Conv_Dbl(lRate.Text);
                    }
                    //lv.SubItems[7].Text = MainMDI.Curr_FRMT(Math.Round(Tot, 2).ToString()); TOTSales += Tot;
                    //lv.SubItems[8].Text = ""; //MainMDI.Curr_FRMT(Irt.ToString());
                    //lv.SubItems[9].Text = MainMDI.Curr_FRMT(Math.Round(amt, 2).ToString());

                    lv.SubItems[7].Text = Math.Round(Tot, 2).ToString(); TOTSales += Tot;
                    lv.SubItems[8].Text = "1.00"; //MainMDI.Curr_FRMT(Irt.ToString()); //Oreadr["Rate"].ToString(); //""; //MainMDI.Curr_FRMT(Irt.ToString());
                    lv.SubItems[9].Text = Math.Round(amt, 2).ToString();
                    lv.SubItems[10].Text = find_QT_date(Oreadr["Project"].ToString());

                    TOT += amt;
                    stout += amt + "\n";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("fill_Details_CMS_ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL);
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
            //MessageBox.Show(stout);
            OutDD = TOT;
            txTOT.Text = MainMDI.Curr_FRMT(Math.Round(TOT, 2).ToString());
            lTOTperMM.Text = TOTSales.ToString();

            if (lInsideS.Text != "") 
            { 
                fill_CMS_Out_INside(); 
                groupBox2.Visible = true; 
            }
        }

        bool isThresholdOK(string _SalesName, string _InvDate, string _MM, string _Invoice, string _SOL, ref double diff)
        {
            bool res = true;
            int i = 0;

            if (Quotas != 0) 
            {
                for (i = 0; i < LimX; i++)
                {
                    if (arr_Quotas[i, 0] == _SalesName && arr_Quotas[i, 1] == _InvDate && arr_Quotas[i, 2] == _MM && 
                        arr_Quotas[i, 3] == _Invoice && arr_Quotas[i, 4] == _SOL)
                    {
                        if (Tools.Conv_Dbl(arr_Quotas[i, LimY - 1]) <= Quotas) res = false;
                        else
                        {
                            diff = (Tools.Conv_Dbl(arr_Quotas[i, LimY - 1]) - Quotas);
                            if (diff >= Tools.Conv_Dbl(arr_Quotas[i, LimY - 2])) diff = 0;
                        }
                        i = LimX;
                    }
                }
            }
            return res;
        }

        void Load_ventesAn(string _SalesName, int _YY)
        {
            int i = 0;
            double TOT = 0;

            //OleDbConnection OConn = null;
            //OleDbCommand Ocmd = null;
            //OleDbDataReader Oreadr = null;
            //OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);

            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

            string stSQL = " SELECT SalSalesperson.Name, u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.SalesOrderLine, u_SalCommissionsPrimax.ShipQty, [PriceCAD]*[ShipQty] AS TOTAL " +
                " FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch) AND (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson) " +
                " WHERE (((SalSalesperson.Name)='" + _SalesName + "') AND ((u_SalCommissionsPrimax.FiscalYear)=" + cb_YY.Text + ") AND ((u_SalCommissionsPrimax.Salesperson)<>'A')) " +
                " ORDER BY u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Invoice ";

            //string stSQL = " SELECT dbo_SalSalesperson.Salesperson, dbo_SalSalesperson.Name, dbo_u_SalCommissionsPrimax.DateLastInvPrt, dbo_u_SalCommissionsPrimax.FiscalYear, dbo_u_SalCommissionsPrimax.FiscalMonth, dbo_u_SalCommissionsPrimax.Invoice, " +
                //"       dbo_u_SalCommissionsPrimax.SalesOrderLine, dbo_u_SalCommissionsPrimax.ShipQty, dbo_u_SalCommissionsPrimax.PriceCAD, [PriceCAD]*[ShipQty] AS TOTAL, dbo_u_SalCommissionsPrimax.CommissionSales1, CDbl([CommissionAmt1]) AS 1CommissionAmt1 " +
                //" FROM dbo_u_SalCommissionsPrimax INNER JOIN dbo_SalSalesperson ON (dbo_u_SalCommissionsPrimax.Branch = dbo_SalSalesperson.Branch) AND (dbo_u_SalCommissionsPrimax.Salesperson = dbo_SalSalesperson.Salesperson) " +
                //" WHERE (((dbo_SalSalesperson.Name)='" + _SalesName + "') AND ((dbo_u_SalCommissionsPrimax.FiscalYear)=" + cb_YY.Text + ") AND ((dbo_u_SalCommissionsPrimax.Salesperson)<>'A')) " +
                //" ORDER BY dbo_u_SalCommissionsPrimax.FiscalMonth, dbo_u_SalCommissionsPrimax.Invoice ";
            try
            {
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();

                double OldAmnt = 0, Amnt = 0;

                while (Oreadr.Read() && i < LimX)
                {
                    for (int j = 0; j < LimY - 1; j++) arr_Quotas[i, j] = Oreadr[j].ToString();
                    Amnt = Tools.Conv_Dbl(arr_Quotas[i, LimY - 2]) + OldAmnt;

                    arr_Quotas[i, LimY - 1] = Amnt.ToString();
                    OldAmnt = Amnt;
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load_ventesAn_CMS_ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL + " III=" + 
                    i.ToString());
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
        }

        void Load_ventesAn_Access(string _SalesName, int _YY)
        {
            int i = 0;
            double TOT = 0;

            OleDbConnection OConn = null;
            OleDbCommand Ocmd = null;
            OleDbDataReader Oreadr = null;

            string stSQL = " SELECT dbo_SalSalesperson.Name, dbo_u_SalCommissionsPrimax.DateLastInvPrt, dbo_u_SalCommissionsPrimax.FiscalMonth, dbo_u_SalCommissionsPrimax.Invoice, dbo_u_SalCommissionsPrimax.SalesOrderLine, dbo_u_SalCommissionsPrimax.ShipQty, [PriceCAD]*[ShipQty] AS TOTAL " +
                " FROM dbo_u_SalCommissionsPrimax INNER JOIN dbo_SalSalesperson ON (dbo_u_SalCommissionsPrimax.Branch = dbo_SalSalesperson.Branch) AND (dbo_u_SalCommissionsPrimax.Salesperson = dbo_SalSalesperson.Salesperson) " +
                " WHERE (((dbo_SalSalesperson.Name)='" + _SalesName + "') AND ((dbo_u_SalCommissionsPrimax.FiscalYear)=" + cb_YY.Text + ") AND ((dbo_u_SalCommissionsPrimax.Salesperson)<>'A')) " +
                " ORDER BY dbo_u_SalCommissionsPrimax.FiscalMonth, dbo_u_SalCommissionsPrimax.Invoice ";

            //string stSQL = " SELECT dbo_SalSalesperson.Salesperson, dbo_SalSalesperson.Name, dbo_u_SalCommissionsPrimax.DateLastInvPrt, dbo_u_SalCommissionsPrimax.FiscalYear, dbo_u_SalCommissionsPrimax.FiscalMonth, dbo_u_SalCommissionsPrimax.Invoice, " +
                //"       dbo_u_SalCommissionsPrimax.SalesOrderLine, dbo_u_SalCommissionsPrimax.ShipQty, dbo_u_SalCommissionsPrimax.PriceCAD, [PriceCAD]*[ShipQty] AS TOTAL, dbo_u_SalCommissionsPrimax.CommissionSales1, CDbl([CommissionAmt1]) AS 1CommissionAmt1 " +
                //" FROM dbo_u_SalCommissionsPrimax INNER JOIN dbo_SalSalesperson ON (dbo_u_SalCommissionsPrimax.Branch = dbo_SalSalesperson.Branch) AND (dbo_u_SalCommissionsPrimax.Salesperson = dbo_SalSalesperson.Salesperson) " +
                //" WHERE (((dbo_SalSalesperson.Name)='" + _SalesName + "') AND ((dbo_u_SalCommissionsPrimax.FiscalYear)=" + cb_YY.Text + ") AND ((dbo_u_SalCommissionsPrimax.Salesperson)<>'A')) " +
                //" ORDER BY dbo_u_SalCommissionsPrimax.FiscalMonth, dbo_u_SalCommissionsPrimax.Invoice ";
            try
            {
                OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);
                //OConn = new OleDbConnection(MainMDI.M_stCon_PL_SYSPRO);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();

                double OldAmnt = 0, Amnt = 0;

                while (Oreadr.Read() && i < LimX)
                {
                    for (int j = 0; j < LimY - 1; j++) arr_Quotas[i, j] = Oreadr[j].ToString();
                    Amnt = Tools.Conv_Dbl(arr_Quotas[i, LimY - 2]) + OldAmnt;

                    arr_Quotas[i, LimY - 1] = Amnt.ToString();
                    OldAmnt = Amnt;
                    i++;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Load_ventesAn_CMS_ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL + " III=" + 
                    i.ToString());
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.ShowDialog();
            if (folderBrowserDialog1.SelectedPath != "")
            {
                axDBpath.Text = folderBrowserDialog1.SelectedPath;
                MainMDI.M_stCon_CMS_ACCS_ACE = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + axDBpath.Text + 
                    @"\PrimaxCommissions.accdb;";
            }
        }

        private void CMS_fromSYSPRO_Load(object sender, EventArgs e)
        {
            axDBpath.Text = @"\\Erpserver\syspro61\Commissions";
            //axDBpath.ReadOnly = true;
            //MainMDI.M_stCon_CMS_ACCS_ACE = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + axDBpath.Text + @"\PrimaxCommissions.accdb;";
            MainMDI.M_stCon_CMS_ACCS_ACE = "";
            fill_CBMMYY();

            //Visibility
            cb_MM.SendToBack();
            cb_YY.SendToBack();
            //groupBox2.Visible = (MainMDI.User.ToLower() == "ede");
            lTOTperMM.Visible = (MainMDI.User.ToLower() == "ede");
            lRate.Visible = (MainMDI.User.ToLower() == "ede");
            tlsRepair.Visible = (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "amvoinescu" || 
                MainMDI.User.ToLower() == "mmellouli");
            lSalesCode.Visible = (MainMDI.User.ToLower() == "ede");
            if (MainMDI.User.ToLower() != "ede") ed_LVallInvoices.Columns[11].Width = 0;
            tsb_ChngRates.Visible = (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "hnasrat");
            PGCUsr_SalesName(MainMDI.User.ToLower());
        }

        void fill_CBMMYY() 
        {
            string MM = "", YY = "";
            MainMDI.Find_2_Field("SELECT [F2] ,[F3]  FROM [Orig_PSM_FDB].[dbo].[PSM_C_GConfig] where F1_code='CMS_MMYY'", ref MM, ref YY);
            if (MM != MainMDI.VIDE)
            {
                cb_MM.Text = MM;
                cb_YY.Text = YY;
            }
        }

        private void tsb_InsideS_Click(object sender, EventArgs e)
        {
            disp_infoSales(true);

            lSalesN.Text = "Inside Sales Names";
            grpSales.Visible = true;
            fill_CBsales();
            cbSales.Text = cbSales.Items[0].ToString();
            //cb_MM.Text = cb_MM.Items[0].ToString();
            //cb_YY.Text = cb_YY.Items[0].ToString();
        }

        private void tsb_OutsideS_Click(object sender, EventArgs e)
        {
            disp_infoSales(true);

            lSalesN.Text = "Outside Sales Names";
            grpSales.Visible = true;
            fill_CBsales();
            cbSales.Text = cbSales.Items[0].ToString();
            //cb_MM.Text = cb_MM.Items[0].ToString();
            //cb_YY.Text = cb_YY.Items[0].ToString();
        }

        private void cbSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            txSalesName.Text = cbSales.Text;
            //lSalesCode.Text = MainMDI.Find_One_Field_ACCESS("SELECT dbo_SalSalesperson.Salesperson FROM dbo_SalSalesperson WHERE dbo_SalSalesperson.Name='" + txSalesName.Text + "' AND dbo_SalSalesperson.Branch='C1'");

            lSalesCode.Text = MainMDI.Find_One_Field_SYSPRO("SELECT SalSalesperson.Salesperson FROM SalSalesperson WHERE SalSalesperson.Name='" + 
                txSalesName.Text + "' AND SalSalesperson.Branch='C1'");
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void xl_Click(object sender, EventArgs e)
        {
            if (MainMDI.IsControlAtFront(ed_lvITM) && ed_lvITM.Items.Count > 0) XL_CMS();
            if (MainMDI.IsControlAtFront(ed_LVallInvoices) && ed_LVallInvoices.Items.Count > 0) XL_INvoices();
        }

        private void XL_CMS()
        {
            int NBCols = 11;
            object[] objHdrs = new object[NBCols]; //{ "Invoice #", "Sale / Agency Name", "Base Amount", "Commission %", "Commission Amount", "Currency", "Xchange rate ", "Commission Amount (CAD)", " cms Type " };

            for (int i = 0; i < NBCols; i++) objHdrs[i] = ed_lvITM.Columns[i].Text; //ed_lvITM.Columns[i + 2].Text;

            string Fname = "CMS_Details.xlsx";
            string CellFM = "A1", CellTO = "K1";

            object[,] objData = new object[MainMDI.MAX_XLlines_XPRT, NBCols];
            for (int i = 0; i < MainMDI.MAX_XLlines_XPRT; i++)
            {
                if (i < ed_lvITM.Items.Count)
                    for (int j = 0; j < NBCols; j++) objData[i, j] = ed_lvITM.Items[i].SubItems[j].Text;
            }
            XL_EXPORT(Fname, objHdrs, NBCols, CellFM, CellTO, objData);
        }

        private void XL_INvoices()
        {
            int NBCols = 13;
            object[] objHdrs = new object[NBCols]; //{ "Invoice #", "Sale / Agency Name", "Base Amount", "Commission %", "Commission Amount", "Currency", "Xchange rate ", "Commission Amount (CAD)", " cms Type " };

            for (int i = 0; i < NBCols; i++) objHdrs[i] = ed_LVallInvoices.Columns[i].Text; //ed_lvITM.Columns[i + 2].Text;

            string Fname = "INVOICES_LIST.xlsx";
            string CellFM = "A1", CellTO = "M1";

            object[,] objData = new object[MainMDI.MAX_XLlines_XPRT, NBCols];
            for (int i = 0; i < MainMDI.MAX_XLlines_XPRT; i++)
            {
                if (i < ed_LVallInvoices.Items.Count) 
                    for (int j = 0; j < NBCols; j++) objData[i, j] = ed_LVallInvoices.Items[i].SubItems[j].Text;
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

            m_objBook.SaveAs(MainMDI.XL_Path + @"\" + FName, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, 
                Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();
            //??? NO data
            //MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\" + FName);

            MainMDI.EXEC_FILE("EXCEL.exe", MainMDI.XL_Path + @"\" + FName);
        }

        //import inside sales button
        private void button2_Click(object sender, EventArgs e)
        {
            if (MainMDI.User.ToLower() != "amvoinescu") Update_CMS();
        }

        void Update_CMS()
        {
            if (MainMDI.Confirm("Want Update commissions ?"))
            {
                try
                {
                    this.Cursor = Cursors.WaitCursor;

                    using (var conn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO))
                    using (
                        var command = new SqlCommand("SysproCompanyP.dbo.sp_UPDATE_Commissions", conn) { CommandType = CommandType.StoredProcedure }
                        ) { conn.Open(); command.ExecuteNonQuery(); conn.Close(); }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR while Importing CMS from SYSPRO:  " + ex.Message + "\n   EX#= " + ex.Source);
                }
                this.Cursor = Cursors.Default;
            }
        }

        private void btn_TOT_Click(object sender, EventArgs e)
        {
            if (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "mmellouli" || MainMDI.User.ToLower() == "hnasrat" || 
                MainMDI.User.ToLower() == "ddarai") Fill_TOT_bySALESName();
        }

        private void Fill_TOT_bySALESName_Access()
        {
            string[,] my_Arr_TOT = new string[cbSales.Items.Count, 2];
            string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            string stSql = "";

            for (int i = 0, T = 0; i < cbSales.Items.Count; i++, T++)
            {
                switch (lSalesN.Text)
                {
                    case "Inside Sales Names":
                        stSql = " SELECT Sum(InsideSales.Amt) AS TOT FROM InsideSales   " +
                            " WHERE InsideSales.IntSalesperson ='" + cbSales.Items[i].ToString() + "' AND InsideSales.FiscalYear=" + 
                            cb_YY.Text + " AND InsideSales.FiscalMonth=" + MM;
                        break;
                    case "Outside Sales Names":
                        stSql = " SELECT   sum(CommissionAmt1) AS 1CommissionAmt1 FROM dbo_u_SalCommissionsPrimax INNER JOIN dbo_SalSalesperson ON (dbo_u_SalCommissionsPrimax.Salesperson = dbo_SalSalesperson.Salesperson) AND (dbo_u_SalCommissionsPrimax.Branch = dbo_SalSalesperson.Branch) " +
                            " WHERE dbo_SalSalesperson.Name='" + cbSales.Items[i].ToString() + 
                            "' AND dbo_u_SalCommissionsPrimax.FiscalYear=" + cb_YY.Text + " AND dbo_u_SalCommissionsPrimax.FiscalMonth=" + MM +
                            " AND dbo_u_SalCommissionsPrimax.Salesperson<>'A'";
                        break;
                }
                stSql = MainMDI.Find_One_Field_ACCESS(stSql);
                double amt = Tools.Conv_Dbl(stSql);
 
                my_Arr_TOT[T, 0] = cbSales.Items[i].ToString();
                my_Arr_TOT[T, 1] = MainMDI.Curr_FRMT(Math.Round(amt, 2).ToString());
            }
            CMS_TOTALS frm_tot = new CMS_TOTALS(my_Arr_TOT);
            frm_tot.ShowDialog();
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //if (MainMDI.User.ToLower() == "ede"); //|| MainMDI.User.ToLower() == "cfouche" || MainMDI.User.ToLower() == "hnasrat")
            //{
                //CMS_fromSYSPRO_OVRG frm_Ovrg = new CMS_fromSYSPRO_OVRG();
                //this.Hide();
                //frm_Ovrg.ShowDialog();
                //this.Visible = true;
            //}
        }

        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void disp_infoSales(bool st)
        {
            lSalesN.Visible = st;
            cbSales.Visible = st;
            btn_TOT.Visible = st;
            txTOT.Visible = st;
            label4.Visible = st;
        }

        private void tsb_InvList_Click(object sender, EventArgs e)
        {
            //picDetailList.SendToBack();
            //grpSales.Visible = true;

            //disp_infoSales(false);
 
            //txSalesName.Text = "ALL Invoices ";
            ////cb_MM.Text = cb_MM.Items[0].ToString();
            ////cb_YY.Text = cb_YY.Items[0].ToString();
            if (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "hnasrat" || MainMDI.User.ToLower() == "ylavoie" || 
                MainMDI.User.ToLower() == "amvoinescu")
            {
                CMS_Agents myfrm = new CMS_Agents();
                myfrm.ShowDialog();
            }
        }

        void fill_ALLInvoices_IN()
        {
            string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            double TOT = 0;
            decimal TOTSales = 0;

            //OleDbConnection OConn = null;
            //OleDbCommand Ocmd = null;
            //OleDbDataReader Oreadr = null;
            //OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);


            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

            ////Access
            //string stSQL = " SELECT DISTINCT dbo_u_SalCommissionsInsideSales.DateLastInvPrt, dbo_u_SalCommissionsInsideSales.FiscalYear, dbo_u_SalCommissionsInsideSales.FiscalMonth, dbo_u_SalCommissionsInsideSales.Customer, dbo_u_SalCommissionsInsideSales.Project, dbo_u_SalCommissionsInsideSales.Invoice, dbo_u_SalCommissionsInsideSales.StockDescription, dbo_u_SalCommissionsInsideSales.ShipQty, dbo_u_SalCommissionsInsideSales.Price, dbo_u_SalCommissionsInsideSales.ExchangeRate, dbo_u_SalCommissionsInsideSales.PriceCAD, dbo_u_SalCommissionsInsideSales.Salesperson " +
                //" FROM dbo_u_SalCommissionsInsideSales " +
                //" WHERE (((dbo_u_SalCommissionsInsideSales.FiscalYear)=" + cb_YY.Text + ") AND ((dbo_u_SalCommissionsInsideSales.FiscalMonth)=" + MM + ")) " +
                //" ORDER BY dbo_u_SalCommissionsInsideSales.FiscalYear, dbo_u_SalCommissionsInsideSales.FiscalMonth, dbo_u_SalCommissionsInsideSales.Customer, dbo_u_SalCommissionsInsideSales.Project, dbo_u_SalCommissionsInsideSales.Invoice, dbo_u_SalCommissionsInsideSales.Salesperson";

            //string stSQL = " SELECT DISTINCT u_SalCommissionsInsideSales.DateLastInvPrt, u_SalCommissionsInsideSales.FiscalYear, u_SalCommissionsInsideSales.FiscalMonth, u_SalCommissionsInsideSales.Customer, u_SalCommissionsInsideSales.Project, u_SalCommissionsInsideSales.Invoice, u_SalCommissionsInsideSales.StockDescription, u_SalCommissionsInsideSales.ShipQty, u_SalCommissionsInsideSales.Price, u_SalCommissionsInsideSales.ExchangeRate, u_SalCommissionsInsideSales.PriceCAD, u_SalCommissionsInsideSales.Salesperson " +
                //" FROM u_SalCommissionsInsideSales  " +
                //" WHERE (((u_SalCommissionsInsideSales.FiscalYear)=" + cb_YY.Text + ") AND ((u_SalCommissionsInsideSales.FiscalMonth)=" + MM + ")  AND (LOWER([Project]) not like '%cigentec%')) " +
                //" ORDER BY u_SalCommissionsInsideSales.FiscalYear, u_SalCommissionsInsideSales.FiscalMonth, u_SalCommissionsInsideSales.Customer, u_SalCommissionsInsideSales.Project, u_SalCommissionsInsideSales.Invoice, u_SalCommissionsInsideSales.Salesperson ";

            string stSQL = " SELECT u_SalCommissionsInsideSales.DateLastInvPrt, u_SalCommissionsInsideSales.FiscalYear, u_SalCommissionsInsideSales.FiscalMonth, u_SalCommissionsInsideSales.Customer, u_SalCommissionsInsideSales.Project, u_SalCommissionsInsideSales.Invoice, u_SalCommissionsInsideSales.StockDescription, u_SalCommissionsInsideSales.ShipQty, u_SalCommissionsInsideSales.Price, u_SalCommissionsInsideSales.ExchangeRate, u_SalCommissionsInsideSales.PriceCAD, u_SalCommissionsInsideSales.Salesperson " +
                " FROM u_SalCommissionsInsideSales  " +
                " WHERE (((u_SalCommissionsInsideSales.FiscalYear)=" + cb_YY.Text + ") AND ((u_SalCommissionsInsideSales.FiscalMonth)=" + MM + 
                ")  AND (LOWER([Project]) not like '%cigentec%')) " +
                " ORDER BY u_SalCommissionsInsideSales.FiscalYear, u_SalCommissionsInsideSales.FiscalMonth, u_SalCommissionsInsideSales.Customer, u_SalCommissionsInsideSales.Project, u_SalCommissionsInsideSales.Invoice, u_SalCommissionsInsideSales.Salesperson ";

            string stout = "";
            ed_lvITM.SendToBack();
            ed_LVallInvoices.Items.Clear();
            try
            {
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();
                ed_LVallInvoices.Columns[11].Width = 0;
                ed_LVallInvoices.Columns[12].Width = 0;
                while (Oreadr.Read())
                {
                    ListViewItem lv = ed_LVallInvoices.Items.Add(""); 
                    for (int c = 1; c < ed_LVallInvoices.Columns.Count; c++) lv.SubItems.Add("");

                    lv.SubItems[0].Text = MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");
                    lv.SubItems[1].Text = Oreadr["Project"].ToString();
                    lv.SubItems[2].Text = Oreadr["Invoice"].ToString();
                    lv.SubItems[3].Text = Oreadr["Customer"].ToString();

                    decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                    decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                    decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());

                    lv.SubItems[4].Text = MainMDI.Curr_FRMT(Math.Round(UP, 2).ToString());
                    lv.SubItems[5].Text = Math.Round(Qty, 2).ToString();
                    lv.SubItems[6].Text = Math.Round(xrt, 2).ToString();

                    decimal Tot = (decimal)Tools.Conv_Dbl(Oreadr["PriceCAD"].ToString());

                    lv.SubItems[7].Text = MainMDI.Curr_FRMT(Math.Round(Tot, 2).ToString());
                    lv.SubItems[8].Text = Oreadr["Salesperson"].ToString();
                    lv.SubItems[9].Text = "'" + cb_MM.Text + " " + cb_YY.Text;
                    lv.SubItems[10].Text = Oreadr["Salesperson"].ToString();

                    //lv.SubItems[11].Text = get_Curr_SP(Oreadr["Customer"].ToString());
                    ////if (lv.SubItems[11].Text != lv.SubItems[8].Text)
                    ////{
                        ////lv.BackColor = Color.Orange;
                    ////}
                    //string agname = get_Curr_agency(Oreadr["Salesperson2"].ToString());
                    //lv.SubItems[12].Text = (agname == MainMDI.VIDE) ? " " : agname;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("fill_ALLInvoices_IN-->ERROR= " + ex.Message + "\n   EX#= " + ex.Source);
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
            //txTOT.Text = MainMDI.Curr_FRMT(Math.Round(TOT, 2).ToString());
            //lTOTperMM.Text = TOTSales.ToString();
        }

        void fill_ALLInvoices_OUT()
        {
            string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            double TOT = 0;
            decimal TOTSales = 0;

            ////Access
            //OleDbConnection OConn = null;
            //OleDbCommand Ocmd = null;
            //OleDbDataReader Oreadr = null;
            //OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);

            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

            //string stSQL = " Select distinct u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.Project, u_SalCommissionsPrimax.Branch, u_SalCommissionsPrimax.ExchangeRate,u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.PriceCAD,  SalSalesperson.Name, u_SalCommissionsPrimax.Salesperson, u_SalCommissionsPrimax.CommissionSales1, u_SalCommissionsPrimax.CommissionAmt1, u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2, u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.UserDef, u_SalCommissionsPrimax.Rate, Left(u_SalCommissionsPrimax.Salesperson,1) AS Expr1 " +
                //" FROM u_SalCommissionsPrimax INNER JOIN  SalSalesperson ON u_SalCommissionsPrimax.Salesperson =  SalSalesperson.Salesperson  " +
                //" WHERE (((u_SalCommissionsPrimax.FiscalYear)=" + cb_YY.Text + ") AND ((u_SalCommissionsPrimax.FiscalMonth)=" + MM + ") AND ((Left(u_SalCommissionsPrimax.Salesperson,1))<>'A') and (LOWER([Project]) not like '%cigentec%')) " +
                //" ORDER BY u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.Salesperson ";

            string stSQL = " Select u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.Project, u_SalCommissionsPrimax.Branch, u_SalCommissionsPrimax.ExchangeRate,u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.PriceCAD,  SalSalesperson.Name, u_SalCommissionsPrimax.Salesperson, u_SalCommissionsPrimax.CommissionSales1, u_SalCommissionsPrimax.CommissionAmt1, u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2, u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.UserDef, u_SalCommissionsPrimax.Rate, Left(u_SalCommissionsPrimax.Salesperson,1) AS Expr1 " +
                " FROM u_SalCommissionsPrimax INNER JOIN  SalSalesperson ON u_SalCommissionsPrimax.Salesperson =  SalSalesperson.Salesperson  " +
                " WHERE (((u_SalCommissionsPrimax.FiscalYear)=" + cb_YY.Text + ") AND ((u_SalCommissionsPrimax.FiscalMonth)=" + MM + ")" +
                "   AND ((Left(u_SalCommissionsPrimax.Salesperson,1))<>'A') and (LOWER([Project]) not like '%cigentec%')) " +
                " ORDER BY u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.Salesperson ";

            string stout = "";
            ed_lvITM.SendToBack();
            ed_LVallInvoices.Items.Clear();
            try
            {
                ed_LVallInvoices.Columns[11].Width = 150;
                ed_LVallInvoices.Columns[12].Width = 250;
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {
                    ListViewItem lv = ed_LVallInvoices.Items.Add(""); 
                    for (int c = 1; c < ed_LVallInvoices.Columns.Count; c++) lv.SubItems.Add("");

                    lv.SubItems[0].Text = MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");
                    lv.SubItems[1].Text = Oreadr["Project"].ToString();
                    lv.SubItems[2].Text = Oreadr["Invoice"].ToString();
                    lv.SubItems[3].Text = Oreadr["Customer"].ToString();

                    decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                    decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                    decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());

                    //lv.SubItems[4].Text = MainMDI.Curr_FRMT(Math.Round(UP, 2).ToString());
                    lv.SubItems[4].Text = MainMDI.Curr_FRMT(Math.Round(UP, 2).ToString(), true);

                    lv.SubItems[5].Text = Math.Round(Qty, 2).ToString();
                    lv.SubItems[6].Text = Math.Round(xrt, 2).ToString();

                    decimal Tot = (decimal)Tools.Conv_Dbl(Oreadr["PriceCAD"].ToString());

                    lv.SubItems[7].Text = MainMDI.Curr_FRMT(Math.Round(Tot, 2).ToString(), true);
                    lv.SubItems[8].Text = Oreadr["Name"].ToString();
                    lv.SubItems[9].Text = "'" + cb_MM.Text + " " + cb_YY.Text;
                    lv.SubItems[10].Text = Oreadr["Salesperson"].ToString();

                    lv.SubItems[11].Text = get_Curr_SP(Oreadr["Customer"].ToString());
                    if (lv.SubItems[11].Text != lv.SubItems[8].Text) lv.BackColor = Color.Orange;

                    string agname = get_Curr_agency(Oreadr["Salesperson2"].ToString());
                    lv.SubItems[12].Text = (agname == MainMDI.VIDE) ? " " : agname;
                    if (lv.SubItems[12].Text != " ") lv.BackColor = Color.LightGreen;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("fill_ALLInvoices_OUT-->ERROR= " + ex.Message + "\n   EX#= " + ex.Source);
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
            //txTOT.Text = MainMDI.Curr_FRMT(Math.Round(TOT, 2).ToString());
            //lTOTperMM.Text = TOTSales.ToString();
        }

        string get_Curr_SP(string cust_SPcode)
        {
            int pos = cust_SPcode.IndexOf("-");
            if (pos > 6) cust_SPcode = cust_SPcode.Substring(0, pos - 1);
            //return (MainMDI.Find_One_Field_SYSPRO("SELECT Salesperson   FROM [SysproCompanyP].[dbo].[v_PGCustomerXRef] where Customer='" + cust_SPcode + "'"));
            string stt = "SELECT  SalSalesperson.Name FROM  v_PGCustomerXRef INNER JOIN  SalSalesperson ON v_PGCustomerXRef.Branch = SalSalesperson.Branch AND v_PGCustomerXRef.Salesperson = SalSalesperson.Salesperson WHERE v_PGCustomerXRef.Customer= '" + 
                cust_SPcode + "'";
            return (MainMDI.Find_One_Field_SYSPRO(stt));
        }

        string get_Curr_agency(string AG)
        {
            string stt = "SELECT distinct Salesperson + ' - ' + Name FROM  dbo.SalSalesperson where Salesperson ='" + AG + 
                "' and(Branch = 'U1' OR Branch = 'C1') ";
            return (MainMDI.Find_One_Field_SYSPRO(stt));
        }

        //void fill_ALLInvoices_IN_OLD()
        //{
            //string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            //double TOT = 0;
            //decimal TOTSales = 0;

            ////OleDbConnection OConn = null;
            ////OleDbCommand Ocmd = null;
            ////OleDbDataReader Oreadr = null;
            ////OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);

            //SqlConnection OConn = null;
            //SqlCommand Ocmd = null;
            //SqlDataReader Oreadr = null;
            //OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

            //////Access
            ////string stSQL = " SELECT DISTINCT dbo_u_SalCommissionsInsideSales.DateLastInvPrt, dbo_u_SalCommissionsInsideSales.FiscalYear, dbo_u_SalCommissionsInsideSales.FiscalMonth, dbo_u_SalCommissionsInsideSales.Customer, dbo_u_SalCommissionsInsideSales.Project, dbo_u_SalCommissionsInsideSales.Invoice, dbo_u_SalCommissionsInsideSales.StockDescription, dbo_u_SalCommissionsInsideSales.ShipQty, dbo_u_SalCommissionsInsideSales.Price, dbo_u_SalCommissionsInsideSales.ExchangeRate, dbo_u_SalCommissionsInsideSales.PriceCAD, dbo_u_SalCommissionsInsideSales.Salesperson " +
                ////" FROM dbo_u_SalCommissionsInsideSales " +
                ////" WHERE (((dbo_u_SalCommissionsInsideSales.FiscalYear)=" + cb_YY.Text + ") AND ((dbo_u_SalCommissionsInsideSales.FiscalMonth)=" + MM + ")) " +
                ////" ORDER BY dbo_u_SalCommissionsInsideSales.FiscalYear, dbo_u_SalCommissionsInsideSales.FiscalMonth, dbo_u_SalCommissionsInsideSales.Customer, dbo_u_SalCommissionsInsideSales.Project, dbo_u_SalCommissionsInsideSales.Invoice, dbo_u_SalCommissionsInsideSales.Salesperson";

            //string stSQL = " SELECT DISTINCT u_SalCommissionsInsideSales.DateLastInvPrt, u_SalCommissionsInsideSales.FiscalYear, u_SalCommissionsInsideSales.FiscalMonth, u_SalCommissionsInsideSales.Customer, u_SalCommissionsInsideSales.Project, u_SalCommissionsInsideSales.Invoice, u_SalCommissionsInsideSales.StockDescription, u_SalCommissionsInsideSales.ShipQty, u_SalCommissionsInsideSales.Price, u_SalCommissionsInsideSales.ExchangeRate, u_SalCommissionsInsideSales.PriceCAD, u_SalCommissionsInsideSales.Salesperson " +
                //" FROM u_SalCommissionsInsideSales  " +
                //" WHERE (((u_SalCommissionsInsideSales.FiscalYear)=" + cb_YY.Text + ") AND ((u_SalCommissionsInsideSales.FiscalMonth)=" + MM + ")  AND (LOWER([Project]) not like '%cigentec%')) " + 
                //" ORDER BY u_SalCommissionsInsideSales.FiscalYear, u_SalCommissionsInsideSales.FiscalMonth, u_SalCommissionsInsideSales.Customer, u_SalCommissionsInsideSales.Project, u_SalCommissionsInsideSales.Invoice, u_SalCommissionsInsideSales.Salesperson ";

            //string stout = "";
            //ed_lvITM.SendToBack();
            //ed_LVallInvoices.Items.Clear();
            //try
            //{
                //OConn.Open();
                //Ocmd = OConn.CreateCommand();
                //Ocmd.CommandText = stSQL;
                //Oreadr = Ocmd.ExecuteReader();

                //while (Oreadr.Read())
                //{
                    //ListViewItem lv = ed_LVallInvoices.Items.Add(""); for (int c = 1; c < ed_LVallInvoices.Columns.Count; c++) lv.SubItems.Add("");

                    //lv.SubItems[0].Text = MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");
                    //lv.SubItems[1].Text = Oreadr["Project"].ToString();
                    //lv.SubItems[2].Text = Oreadr["Invoice"].ToString();
                    //lv.SubItems[3].Text = Oreadr["Customer"].ToString();

                    //decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                    //decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                    //decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());

                    //lv.SubItems[4].Text = MainMDI.Curr_FRMT(Math.Round(UP, 2).ToString());
                    //lv.SubItems[5].Text = Math.Round(Qty, 2).ToString();
                    //lv.SubItems[6].Text = Math.Round(xrt, 2).ToString();

                    //decimal Tot = (decimal)Tools.Conv_Dbl(Oreadr["PriceCAD"].ToString());

                    //lv.SubItems[7].Text = MainMDI.Curr_FRMT(Math.Round(Tot, 2).ToString());
                    //lv.SubItems[8].Text = Oreadr["Salesperson"].ToString();
                    //lv.SubItems[9].Text = "'" + cb_MM.Text + " " + cb_YY.Text;
                    //lv.SubItems[10].Text = Oreadr["Salesperson"].ToString();
                //}
            //}
            //catch (Exception ex)
            //{
                //MessageBox.Show("fill_ALLInvoices_IN-->ERROR= " + ex.Message + "\n   EX#= " + ex.Source);
            //}

            //finally
            //{
                //OConn.Close();
                //if (Oreadr != null) Oreadr.Close();
            //}
            ////txTOT.Text = MainMDI.Curr_FRMT(Math.Round(TOT, 2).ToString());
            ////lTOTperMM.Text = TOTSales.ToString();
        //}

        private void picALLINVOICEs_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        void Send_email()
        {
            if (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "mmellouli" || MainMDI.User.ToLower() == "hnasrat")
            {
                string sbj = "Les commissions du " + cb_MM.Text + "-" + cb_YY.Text;
                string msg = "Bonjour,\n  " + sbj + " ont étés importées de SYSPRO. \n Veuillez vérifier l’état des territoires de chaque facture dans :  INVOICE LISTE (PGESCOM). \n " +
                    "Si vous voulez faire une correction envoyez le fichier EXCEL corrigé à Mohamed pour procéder à la distribution. \n Merci ";
                string TO = MainMDI.Find_One_Field("SELECT [F2] +[F3] +[F4] as mto FROM [Orig_PSM_FDB].[dbo].[PSM_C_GConfig]  where [F1_Code]='cms_to'");

                if (TO != MainMDI.VIDE)
                {
                    //string CC = "mmellouli@primaxpower.com ,cfouche@primaxpower.com ,mrouleau@primaxpower.com ,mdimassi@primaxpower.com "; //hedebbab@primax-e.com
                    string CC = "mohamed.mellouli@trystar.com ,Claude.fouche@trystar.com ,margaret.rouleau@trystar.com, mona.dimassi@trystar.com";
                    MainMDI.send_email("PGESCOM@primax-e.com", TO, sbj, msg);

                    MainMDI.Exec_SQL_JFS(" update PSM_C_GConfig set [f2]='" + cb_MM.Text + "', [f3]='" + cb_YY.Text + 
                        "'  where F1_code='CMS_MMYY' ", "CMS Calc. - Accounting");
                    MessageBox.Show("Msg was sent !!!!");
                }
                else MessageBox.Show("Recipients list is empty.......call Admin....");
            }
            //else MessageBox.Show("Access denied.......");
        }

        private void tsb_ChngRates_Click(object sender, EventArgs e)
        {
            if (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "hnasrat")
            {
                CMS_fromSYSPRO_Rates frm_chngrate = new CMS_fromSYSPRO_Rates('S');
                this.Hide();
                frm_chngrate.ShowDialog();
                this.Visible = true;
            }
        }

        private void tlsRepair_Click(object sender, EventArgs e)
        {
            //CMS_Repair myfrm = new CMS_Repair();
            //myfrm.ShowDialog();

            if (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "amvoinescu" || MainMDI.User.ToLower() == "mmellouli")
            {
                CMS_Repair_manu myfrm = new CMS_Repair_manu();
                myfrm.ShowDialog();
            }
        }

        private void cb_MM_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lmm.Text = cb_MM.Text;
            ed_LVallInvoices.Items.Clear();
            ed_lvITM.Items.Clear();
        }

        private void cb_YY_SelectedIndexChanged(object sender, EventArgs e)
        {
            Lyy.Text = cb_YY.Text;
            ed_LVallInvoices.Items.Clear();
            ed_lvITM.Items.Clear();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void email_Click(object sender, EventArgs e)
        {
            Send_email();
        }

        private void Invlst_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            groupBox2.Visible = false;

            btnMesa.Visible = false;
            txMesa.Visible = false;

            ndx_INV = -1;
            old_ndx_INV = -1;

            switch (lSalesN.Text)
            {
                case "Inside Sales Names":
                    fill_ALLInvoices_IN();
                    break;
                case "Outside Sales Names":
                    //Load_ventesAn(txSalesName.Text, Int32.Parse(cb_YY.Text));
                    fill_ALLInvoices_OUT();
                    break;
            }
            this.Cursor = Cursors.Default;
        }

        private void cmslst_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            groupBox2.Visible = false;
            txMesa.Clear();
            //btnMesa.Visible = true;
            //txMesa.Visible = true;

            ndx_CMS = -1;
            old_ndx_CMS = -1;
            switch (lSalesN.Text)
            {
                case "Inside Sales Names":
                    fill_Details_List_Inside();
                    //fill_Details_List_Inside_NEW();
                    break;
                case "Outside Sales Names":
                    //Load_ventesAn(txSalesName.Text, Int32.Parse(cb_YY.Text));
                    fill_Details_List_Outside();
                    break;
            }
            this.Cursor = Cursors.Default;

            /*

           if (MainMDI.M_stCon_CMS_ACCS_ACE != "")
            {
                string stSQL = " SELECT TotalRunningSales" +
                    " FROM dbo_v_u_SalesCommissionThresholdMonthly " +
                    " WHERE (((dbo_v_u_SalesCommissionThresholdMonthly.Year)=2013) AND ((dbo_v_u_SalesCommissionThresholdMonthly.TrnMonth)=5) AND ((dbo_v_u_SalesCommissionThresholdMonthly.Salesperson)='S03')) " +
                    " ORDER BY dbo_v_u_SalesCommissionThresholdMonthly.Year, dbo_v_u_SalesCommissionThresholdMonthly.TrnMonth";

                string stSQL = " SELECT InsideSales.DateLastInvPrt, InsideSales.FiscalYear, InsideSales.FiscalMonth, InsideSales.Project, InsideSales.Customer, InsideSales.Invoice, " +
                    "       InsideSales.Price, InsideSales.ExchangeRate, InsideSales.PriceCAD, InsideSales.IntSalesperson, InsideSales.Salesperson, InsideSales.IntRate, InsideSales.Amt, InsideSales.OrderQty, InsideSales.ShipQty " +
                    " FROM InsideSales WHERE InsideSales.FiscalYear=" + "2013" + " AND InsideSales.FiscalMonth=" + "5" + " AND InsideSales.IntSalesperson='" + "I02 - Mustapha Byad" + "'" +
                    " ORDER BY InsideSales.Invoice";

                MessageBox.Show(MainMDI.Find_One_Field_ACCESS(stSQL));
            }
            * 
            * */
        }

        private void picfind_Click(object sender, EventArgs e)
        {
            if (MainMDI.IsControlAtFront(ed_LVallInvoices) && ed_LVallInvoices.Items.Count > 0) 
            {
                reset_backcolor('I');
                find_item_INVLST();
            }
            if (MainMDI.IsControlAtFront(ed_lvITM) && ed_lvITM.Items.Count > 0)
            {
                reset_backcolor('C');
                find_item_CMSLST();
            }
            //find_item_CMSLST();
        }

        void find_item_INVLST()
        {
            if (optINV.Checked) Seek_INV(2);
            if (optCUST.Checked) Seek_INV(3);
            if (optPRJ.Checked) Seek_INV(1);
        }

        void find_item_CMSLST()
        {
            if (optINV.Checked) Seek_CMS(1);
            if (optCUST.Checked) Seek_CMS(3);
            if (optPRJ.Checked) Seek_CMS(0);
        }

        private void tKey_TextChanged(object sender, EventArgs e)
        {
            if (ndx_INV > -1) old_ndx_INV = ndx_INV;
            ndx_INV = -1;

            if (ndx_CMS > -1) old_ndx_CMS = ndx_CMS;
            ndx_CMS = -1;
        }

        private void btnMesa_Click(object sender, EventArgs e)
        {
            txMesa.Text = Seek_CMS_TOT_MESA("MES001U");
        }

        private string Seek_CMS_TOT_MESA(string SP_Customer)
        {
            double TOT_CMS = 0;
            for (int i = 0; i < ed_lvITM.Items.Count; i++) 
                if (ed_lvITM.Items[i].SubItems[3].Text.Substring(0, 7) == SP_Customer) 
                    TOT_CMS += Tools.Conv_Dbl(ed_lvITM.Items[i].SubItems[9].Text);
            return TOT_CMS.ToString();
        }

        private void Seek_CMS(int seekCol)
        {
            bool found = false;

            if (tKey.Text != "")
            {
                for (int i = ndx_CMS + 1; i < ed_lvITM.Items.Count; i++)
                {
                    int itemndx = ed_lvITM.Items[i].SubItems[seekCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper(), 0);

                    if ((itemndx > -1))
                    {
                        ed_lvITM.Items[i].BackColor = Color.Yellow;
                        ed_lvITM.Items[i].Selected = true;
                        ed_lvITM.Items[i].EnsureVisible();
                        ndx_CMS = i;
                        old_ndx_CMS = i;
                        i = ed_lvITM.Items.Count + 1;
                        found = true;
                    }
                }
            }
            if (!found) 
            { 
                MessageBox.Show("Sorry, Not Found !!!..."); 
                ndx_CMS = -1; 
            }
        }

        private void Seek_INV(int seekCol)
        {
            bool found = false;

            if (tKey.Text != "")
            {
                for (int i = ndx_INV + 1; i < ed_LVallInvoices.Items.Count; i++)
                {
                    int itemndx = ed_LVallInvoices.Items[i].SubItems[seekCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper(), 0);

                    if ((itemndx > -1))
                    {
                        ed_LVallInvoices.Items[i].BackColor = Color.Yellow;
                        ed_LVallInvoices.Items[i].Selected = true;
                        ed_LVallInvoices.Items[i].EnsureVisible();
                        ndx_INV = i;
                        old_ndx_INV = i;
                        i = ed_LVallInvoices.Items.Count + 1;
                        found = true;
                    }
                }
            }
            if (!found)
            { 
                MessageBox.Show("Sorry, Not Found !!!..."); 
                ndx_INV = -1; 
            }
        }

        void reset_backcolor(char IC)
        {
            if (IC == 'I') 
                if (old_ndx_INV > -1) ed_LVallInvoices.Items[old_ndx_INV].BackColor = Color.Honeydew;

            if (IC == 'C') 
                if (old_ndx_CMS > -1) ed_lvITM.Items[old_ndx_CMS].BackColor = Color.Wheat;
        }

        private void Lmm_DoubleClick(object sender, EventArgs e)
        {
            cb_MM.BringToFront();
            cb_YY.BringToFront();
        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {
            //if (MainMDI.User.ToLower() == "ede") //|| MainMDI.User.ToLower() == "amvoinescu")
            //{
                //CMS_Re_stat myfrm = new CMS_Re_stat();
                //this.Hide();
                //myfrm.ShowDialog();
                //this.Visible = true;
            //}
            //string pbs = "http://erpserver:2552/?usr=" + MainMDI.User.ToLower();
            string _pkt = "usr=" + MainMDI.User.ToLower() + "&opera=C";
            string para = MainMDI.StringCipher.Encrypt(_pkt, mykey);

            //string pbs = "http://localhost:30988/?usr=" + MainMDI.User.ToLower();
            string pbs = "http://localhost:30988/?" + para;
            System.Diagnostics.Process.Start(pbs);
        }
    }
}