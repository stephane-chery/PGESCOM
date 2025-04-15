using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using EAHLibs;

namespace PGESCOM
{
    public partial class CMS_Re_stat : Form
    {

        public static EAHLibs.Lib1 Tools = new Lib1();
        int ndx = -1, oldNdx =-1;
          string Outside_CMS="u_SalCommissionsPrimax";
     //   string Outside_CMS = "u_SalCommissionsPrimax_TST";
          public CMS_Re_stat()
        {
            InitializeComponent();
        }

        private void btnimport_Click(object sender, EventArgs e)
        {


        }



       

        void fill_cbSales()
        {
            cbSalestt.Items.Clear();
            string stSql = "SELECT distinct SalSalesperson.Salesperson +'  ' + SalSalesperson.Name,SalSalesperson.Salesperson  FROM SalSalesperson WHERE (( (Left([Salesperson],1))='S' Or (Left([Salesperson],1))='H')) order by Salesperson";
            MainMDI.fill_CB_SYSP(cbSalestt, stSql, false, "ALL");

        }

       

  
        //private void btnProc_Click(object sender, EventArgs e)
        //{
        //    Fix_ERRORS();
        //}

        //void Fix_ERRORS()
        //{
        //    if (MainMDI.Confirm("Want fix Errors ?"))
        //    {
        //        int TRScount = 0;
        //        for (int i = 0; i < lv_After.Items.Count; i++)
        //        {
        //            if (lv_After.Items[i].BackColor == Color.LightSalmon)
        //            {
        //                string stSql = "update u_SalCommissionsPrimax set [Salesperson]='" + lv_After.Items[i].SubItems[10].Text + "' ,[CommissionAmt1]=" + lv_After.Items[i].SubItems[9].Text + " where LID=" + lv_After.Items[i].SubItems[0].Text;
        //                //   MainMDI.Exec_SQL_JFS_SYSPRO(stSql,"Modfi CMS Outside Sales...PGC.."); 
        //                TRScount++;
        //            }
        //        }
        //        string msg = (TRScount < 2) ? " Record modified...." : " Records modified....";
        //        MessageBox.Show(TRScount.ToString() + msg);
        //    }
        //}

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLook_Click(object sender, EventArgs e)
        {
          
        }


        void fill_Details_List_Inside()
        {

        //    string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            double TOT = 0;


            //OleDbConnection  OConn = null;
            //OleDbCommand  Ocmd = null;
            //OleDbDataReader Oreadr = null;
            //  OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);


            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

            ////Access
     
            //string stSQL = " SELECT v_H_InsideSales.DateLastInvPrt,  v_H_InsideSales.FiscalYear, v_H_InsideSales.FiscalMonth, v_H_InsideSales.Project, v_H_InsideSales.Customer, v_H_InsideSales.Invoice,        v_H_InsideSales.Price, v_H_InsideSales.ExchangeRate, v_H_InsideSales.PriceCAD, v_H_InsideSales.IntSalesperson, v_H_InsideSales.Salesperson, v_H_InsideSales.IntRate, v_H_InsideSales.Amt, v_H_InsideSales.OrderQty, v_H_InsideSales.ShipQty  " +
            //               " FROM v_H_InsideSales " +
            //               " WHERE   (LOWER([Project]) not like '%cigentec%') AND   v_H_InsideSales.FiscalYear=" + cb_YY.Text + " AND v_H_InsideSales.FiscalMonth=" + MM + " AND v_H_InsideSales.IntSalesperson='" + txSalesName.Text + "'" +
            //               " ORDER BY v_H_InsideSales.Invoice ";


            string stSQL = " SELECT v_H_InsideSales.DateLastInvPrt,  v_H_InsideSales.FiscalYear, v_H_InsideSales.FiscalMonth, v_H_InsideSales.Project, v_H_InsideSales.Customer, v_H_InsideSales.Invoice,        v_H_InsideSales.Price, v_H_InsideSales.ExchangeRate, v_H_InsideSales.PriceCAD, v_H_InsideSales.IntSalesperson, v_H_InsideSales.Salesperson, v_H_InsideSales.IntRate, v_H_InsideSales.Amt, v_H_InsideSales.OrderQty, v_H_InsideSales.ShipQty  " +
                           " FROM v_H_InsideSales " +
                           " WHERE   (LOWER([Project]) not like '%cigentec%') AND (LOWER([Project]) like '%" +txPrj.Text +"%')" +
                           " ORDER BY v_H_InsideSales.Invoice, v_H_InsideSales.Salesperson,v_H_InsideSales.IntSalesperson ";

           // ed_LVallInvoices.SendToBack();
            ed_lvITM.Items.Clear();
            ed_lvITM.BeginUpdate();
            try
            {
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {
                   // 

                    ListViewItem lv = ed_lvITM.Items.Add(""); for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");

                    lv.SubItems[3].Text = Oreadr["Salesperson"].ToString();
                    lv.SubItems[4].Text = Oreadr["IntSalesperson"].ToString();
                    lv.SubItems[5].Text = Oreadr["FiscalMonth"].ToString() + "/" + Oreadr["FiscalYear"].ToString();
                    lv.SubItems[6].Text = MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");
                    lv.SubItems[1].Text = Oreadr["Project"].ToString();

                    lv.SubItems[2].Text = Oreadr["Invoice"].ToString();
                  
                    lv.SubItems[0].Text = Oreadr["Customer"].ToString();

                    decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                    decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                    decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());

                    //     lv.SubItems[4].Text =MainMDI.Curr_FRMT(  Math.Round( UP,2).ToString ());
                    lv.SubItems[7].Text = Math.Round(UP, 2).ToString();

                    lv.SubItems[8].Text = Math.Round(Qty, 2).ToString();
                    lv.SubItems[9].Text = Math.Round(xrt, 2).ToString();

                    decimal Tot = UP * Qty * xrt;
                    double amt = Tools.Conv_Dbl(Oreadr["Amt"].ToString());
                    double Irt = Tools.Conv_Dbl(Oreadr["IntRate"].ToString()) * 100;

                    TOT += amt;


                    //          lv.SubItems[7].Text = MainMDI.Curr_FRMT (  Math.Round(Tot, 2).ToString ());
                    //           lv.SubItems[8].Text = MainMDI.Curr_FRMT(Irt.ToString ());
                    //           lv.SubItems[9].Text = MainMDI.Curr_FRMT(Math.Round(amt, 2).ToString());

                    lv.SubItems[10].Text = Math.Round(Tot, 2).ToString();
                    lv.SubItems[11].Text = Irt.ToString();
                    lv.SubItems[12].Text = Math.Round(amt, 2).ToString();



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
            ed_lvITM.EndUpdate();

        //    txTOT.Text = MainMDI.Curr_FRMT(Math.Round(TOT, 2).ToString());

        }



        void fill_Details_List_Outside_Seek()
        {

         //   string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            double TOT = 0;
            decimal TOTSales = 0;

            //OleDbConnection OConn = null;
            //OleDbCommand Ocmd = null;
            //OleDbDataReader Oreadr = null;
            //  OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);


            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);



            //string stSQL = " SELECT SalSalesperson.Salesperson, SalSalesperson.Name, u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Project, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Currency, " +
            //               "        u_SalCommissionsPrimax.Branch,u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.SalesOrder, u_SalCommissionsPrimax.SalesOrderLine, u_SalCommissionsPrimax.StockCode,         u_SalCommissionsPrimax.StockDescription, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, " +
            //               "        u_SalCommissionsPrimax.BackOrderQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.ExchangeRate, u_SalCommissionsPrimax.PriceCAD, u_SalCommissionsPrimax.ProductClass, u_SalCommissionsPrimax.CommissionSales1, (cast ([CommissionAmt1] AS decimal)) AS CommissionAmt1,  u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2,   " +
            //               "        u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.Salesperson3, u_SalCommissionsPrimax.CommissionSales3, u_SalCommissionsPrimax.CommissionAmt3, u_SalCommissionsPrimax.Salesperson4, u_SalCommissionsPrimax.CommissionSales4, u_SalCommissionsPrimax.Rate, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.Rate  " +
            //               " FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch) AND (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson)  " +
            //               " WHERE (((SalSalesperson.Name)='" + txSalesName.Text + "') AND ((u_SalCommissionsPrimax.FiscalYear)=" + cb_YY.Text + ") AND ((u_SalCommissionsPrimax.FiscalMonth)=" + MM + ") AND ((u_SalCommissionsPrimax.Salesperson)<>'A'))   and (LOWER([Project]) not like '%cigentec%')    " +
            //               " ORDER BY u_SalCommissionsPrimax.Invoice";

            string stSQL = " SELECT SalSalesperson.Salesperson, SalSalesperson.Name, u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Project, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Currency, " +
               "        u_SalCommissionsPrimax.Branch,u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.SalesOrder, u_SalCommissionsPrimax.SalesOrderLine, u_SalCommissionsPrimax.StockCode,         u_SalCommissionsPrimax.StockDescription, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, " +
               "        u_SalCommissionsPrimax.BackOrderQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.ExchangeRate, u_SalCommissionsPrimax.PriceCAD, u_SalCommissionsPrimax.ProductClass, u_SalCommissionsPrimax.CommissionSales1, (cast ([CommissionAmt1] AS decimal)) AS CommissionAmt1,  u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2,   " +
               "        u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.Salesperson3, u_SalCommissionsPrimax.CommissionSales3, u_SalCommissionsPrimax.CommissionAmt3, u_SalCommissionsPrimax.Salesperson4, u_SalCommissionsPrimax.CommissionSales4, u_SalCommissionsPrimax.Rate, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.Rate  " +
               " FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch) AND (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson)  " +
               " WHERE (((u_SalCommissionsPrimax.Salesperson)<>'A'))  AND (LOWER([Project]) not like '%cigentec%')   AND (LOWER([Project]) like '%" + txPrj.Text + "%')" +
               " ORDER BY u_SalCommissionsPrimax.Invoice";




            string stout = "";
            ed_lvITM.Items.Clear();
            try
            {

                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {

                    ListViewItem lv = ed_lvITM.Items.Add(""); for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");


                    lv.SubItems[0].Text = Oreadr["Project"].ToString();
                    lv.SubItems[1].Text = Oreadr["Invoice"].ToString();
                    lv.SubItems[2].Text = MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");
                    lv.SubItems[3].Text = Oreadr["Customer"].ToString();

                    decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                    decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                    decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());

                    // lv.SubItems[4].Text = MainMDI.Curr_FRMT(Math.Round(UP, 2).ToString());
                    lv.SubItems[4].Text = Math.Round(UP, 2).ToString();
                    lv.SubItems[5].Text = Math.Round(Qty, 2).ToString();
                    lv.SubItems[6].Text = Math.Round(xrt, 2).ToString();

                    decimal Tot = UP * Qty * xrt;
                    double amt = Tools.Conv_Dbl(Oreadr["CommissionAmt1"].ToString());
                    double Irt = Tools.Conv_Dbl(Oreadr["Rate"].ToString()) * 100;
                    double diff = 0;


                    lv.SubItems[7].Text = Math.Round(Tot, 2).ToString(); TOTSales += Tot;
                    lv.SubItems[8].Text = "";// MainMDI.Curr_FRMT(Irt.ToString());
                    lv.SubItems[9].Text = Math.Round(amt, 2).ToString();

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
            
        }





        private void Fill_TOT_bySALESName()
        {
            string[,] my_Arr_TOT = new string[cbSalestt.Items.Count, 2];
     //       string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            string stSql = "";

            for (int i = 0, T = 0; i < cbSalestt.Items.Count; i++, T++)
            {


                //switch (lSalesN.Text)
                //{
                //    case "Inside Sales Names":
                //        stSql = " SELECT Sum(v_H_InsideSales.Amt) AS TOT FROM v_H_InsideSales   " +
                //                " WHERE (LOWER([Project]) not like '%cigentec%') AND  v_H_InsideSales.IntSalesperson ='" + cbSales.Items[i].ToString() + "' AND v_H_InsideSales.FiscalYear=" + cb_YY.Text + " AND v_H_InsideSales.FiscalMonth=" + MM;

                //        break;
                //    case "Outside Sales Names":
                //        stSql = " SELECT   sum(CommissionAmt1) AS CommissionAmt1 FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson) AND (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch) " +
                //               " WHERE (LOWER([Project]) not like '%cigentec%') AND  SalSalesperson.Name='" + cbSales.Items[i].ToString() + "' AND u_SalCommissionsPrimax.FiscalYear=" + cb_YY.Text + " AND u_SalCommissionsPrimax.FiscalMonth=" + MM + " AND u_SalCommissionsPrimax.Salesperson<>'A'";



                //        break;
                //}

                stSql = MainMDI.Find_One_Field_SYSPRO(stSql);
                double amt = Tools.Conv_Dbl(stSql);

                my_Arr_TOT[T, 0] = cbSalestt.Items[i].ToString();
                my_Arr_TOT[T, 1] = MainMDI.Curr_FRMT(Math.Round(amt, 2).ToString());

            }

            CMS_TOTALS frm_tot = new CMS_TOTALS(my_Arr_TOT);
            frm_tot.ShowDialog();

        }

        private void lvCMS_DoubleClick(object sender, EventArgs e)
        {
                      
   
            //grpedit.Visible = true;
            //ndx = lvCMS.SelectedItems[0].Index;
            //if (oldNdx > -1) lvCMS.Items[oldNdx].BackColor = Color.PeachPuff;
            //lvCMS.Items[ndx].BackColor = Color.GreenYellow; 
            //txItem.Text = lvCMS.Items[ndx].SubItems[1].Text;
            //txCAD.Text = lvCMS.Items[ndx].SubItems[3].Text;
            //txrate.Text = lvCMS.Items[ndx].SubItems[4].Text;
            //txNewcms.Text = lvCMS.Items[ndx].SubItems[5].Text;
            //txOldcms.Text = lvCMS.Items[ndx].SubItems[5].Text;
            //fill_cbSales();
            //string stSql = "SELECT SalSalesperson.Salesperson +'  ' + SalSalesperson.Name FROM SalSalesperson WHERE [Salesperson]='" + lvCMS.Items[ndx].SubItems[0].Text + "' and SalSalesperson.Branch='" + txBranch.Text + "'";
            //string st = MainMDI.Find_One_Field_SYSPRO(stSql);
            //cbSales.Text = st;
            //oldNdx = ndx;
            //grpSearch.Enabled = false;
        }



        private void lvCMS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txrate_TextChanged(object sender, EventArgs e)
        {
         
        }

    

        private void cbSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            //lSalcode.Text = MainMDI.get_CBX_value(cbSales, cbSales.SelectedIndex);
        }

        private void lvCMS_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            cancel_Edit();
        }

        void cancel_Edit()
        {

     
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            SavLine();
        
        }

        void SavLine()
        {
            //Update_Modif(ndx, txrate.Text, lSalcode.Text);
            //cancel_Edit();

        }


        void Update_Modif(int u_ndx, string cmsRate, string _SalesCode)
        {

            //double dd = Tools.Conv_Dbl(lvCMS.Items[u_ndx].SubItems[3].Text) * Tools.Conv_Dbl(cmsRate) / 100.0d;

            //    string stSql = "update   " + Outside_CMS + "  set [Salesperson]='" + _SalesCode + "',  [CommissionSales1]=" + cmsRate + " , [CommissionAmt1]=" + dd.ToString() + " where  LID=" + lvCMS.Items[u_ndx].SubItems[6].Text;
            //    MainMDI.Exec_SQL_JFS_SYSPRO(stSql, " CMS Repair....");


        }

        private void btnapply_Click(object sender, EventArgs e)
        {
            //maj_ALL_Invoice();
        }

        void maj_ALL_Invoice()
        {

            //for (int i = 0; i < lvCMS.Items.Count; i++)   Update_Modif(i, txrate.Text, lSalcode.Text);
            //cancel_Edit();

        }

        private void CMS_Re_stat_Load(object sender, EventArgs e)
        {
            fill_CBMMYY();
            fill_CBsales();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            fill_Details_List_Inside();
        }

        private void btnSave_Click_1(object sender, EventArgs e)
        {
            fill_Details_List_Outside();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsbSearch_Click(object sender, EventArgs e)
        {

        }

        private void btnSave_Click_2(object sender, EventArgs e)
        {

        }

        //void fill_ALLInvoices_IO()
        //{

        //    string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
        //    double TOT = 0;
        //    decimal TOTSales = 0;


        //    ////Access
        //    //OleDbConnection OConn = null;
        //    //OleDbCommand Ocmd = null;
        //    //OleDbDataReader Oreadr = null;
        //    //  OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);


        //    SqlConnection OConn = null;
        //    SqlCommand Ocmd = null;
        //    SqlDataReader Oreadr = null;
        //    OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);



        //    //string stSQL = "select distinct dbo_u_SalCommissionsPrimax.DateLastInvPrt, dbo_u_SalCommissionsPrimax.FiscalYear, dbo_u_SalCommissionsPrimax.FiscalMonth, dbo_u_SalCommissionsPrimax.Customer, dbo_u_SalCommissionsPrimax.Invoice, dbo_u_SalCommissionsPrimax.Project, dbo_u_SalCommissionsPrimax.Branch, dbo_u_SalCommissionsPrimax.ExchangeRate,dbo_u_SalCommissionsPrimax.OrderQty, dbo_u_SalCommissionsPrimax.ShipQty, dbo_u_SalCommissionsPrimax.Price, dbo_u_SalCommissionsPrimax.PriceCAD, dbo_SalSalesperson.Name, dbo_u_SalCommissionsPrimax.Salesperson, dbo_u_SalCommissionsPrimax.CommissionSales1, dbo_u_SalCommissionsPrimax.CommissionAmt1, dbo_u_SalCommissionsPrimax.Salesperson2, dbo_u_SalCommissionsPrimax.CommissionSales2, dbo_u_SalCommissionsPrimax.CommissionAmt2, dbo_u_SalCommissionsPrimax.UserDef, dbo_u_SalCommissionsPrimax.Rate, Left([dbo_u_SalCommissionsPrimax.Salesperson],1) AS Expr1" +
        //    //               " FROM dbo_u_SalCommissionsPrimax INNER JOIN dbo_SalSalesperson ON dbo_u_SalCommissionsPrimax.Salesperson = dbo_SalSalesperson.Salesperson " +
        //    //                " WHERE (((dbo_u_SalCommissionsPrimax.FiscalYear)=" + cb_YY.Text + ") AND ((dbo_u_SalCommissionsPrimax.FiscalMonth)=" + MM + ") AND ((Left([dbo_u_SalCommissionsPrimax.Salesperson],1))<>'A')) " +
        //    //                " ORDER BY dbo_u_SalCommissionsPrimax.FiscalYear, dbo_u_SalCommissionsPrimax.FiscalMonth, dbo_u_SalCommissionsPrimax.Customer, dbo_u_SalCommissionsPrimax.Invoice, dbo_u_SalCommissionsPrimax.Salesperson";

        //    string stSQL = " Select distinct u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.Project, u_SalCommissionsPrimax.Branch, u_SalCommissionsPrimax.ExchangeRate,u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.PriceCAD,  SalSalesperson.Name, u_SalCommissionsPrimax.Salesperson, u_SalCommissionsPrimax.CommissionSales1, u_SalCommissionsPrimax.CommissionAmt1, u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2, u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.UserDef, u_SalCommissionsPrimax.Rate, Left(u_SalCommissionsPrimax.Salesperson,1) AS Expr1 " +
        //                   " FROM u_SalCommissionsPrimax INNER JOIN  SalSalesperson ON u_SalCommissionsPrimax.Salesperson =  SalSalesperson.Salesperson  " +
        //                    " WHERE (((u_SalCommissionsPrimax.FiscalYear)=" + cb_YY.Text + ") AND ((u_SalCommissionsPrimax.FiscalMonth)=" + MM + ") AND ((Left(u_SalCommissionsPrimax.Salesperson,1))<>'A') and (LOWER([Project]) not like '%cigentec%')) " +
        //                   " ORDER BY u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.Salesperson ";


        //    string stout = "";
        //    ed_lvITM.SendToBack();
        //    ed_LVallInvoices.Items.Clear();
        //    try
        //    {

        //        OConn.Open();
        //        Ocmd = OConn.CreateCommand();
        //        Ocmd.CommandText = stSQL;
        //        Oreadr = Ocmd.ExecuteReader();

        //        while (Oreadr.Read())
        //        {

        //            string cust_SPcode = Oreadr["Customer"].ToString(), slsP = "", ag = "";
        //            int pos = cust_SPcode.IndexOf("-");
        //            if (pos > 6) cust_SPcode = cust_SPcode.Substring(0, pos - 1);
        //            string stt = "  SELECT distinct  ISNULL( SalSalesperson.Name,'????') as slsp , ISNULL( SalSalesperson_1.Name,'????') AS ag " +
        //                         "  FROM            v_PGCustomerXRef INNER JOIN SalSalesperson ON v_PGCustomerXRef.Branch = SalSalesperson.Branch AND v_PGCustomerXRef.Salesperson = SalSalesperson.Salesperson LEFT OUTER JOIN " +
        //                         "                  SalSalesperson AS SalSalesperson_1 ON v_PGCustomerXRef.Salesperson1 = SalSalesperson_1.Salesperson WHERE v_PGCustomerXRef.Customer='" + cust_SPcode + "'";

        //            MainMDI.Find_2_Field_PSA(stt, ref slsP, ref ag, "S");

        //            bool disp = (!chk_Agnc.Checked);
        //            if (chk_Agnc.Checked && ag !="????") disp = true;

        //            if (disp)
        //            {
        //                ListViewItem lv = ed_LVallInvoices.Items.Add(""); for (int c = 1; c < ed_LVallInvoices.Columns.Count; c++) lv.SubItems.Add("");

        //                lv.SubItems[0].Text = MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");
        //                lv.SubItems[1].Text = Oreadr["Project"].ToString();
        //                lv.SubItems[2].Text = Oreadr["Invoice"].ToString();
        //                lv.SubItems[3].Text = Oreadr["Customer"].ToString();

        //                decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
        //                decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
        //                decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());

        //                //      lv.SubItems[4].Text = MainMDI.Curr_FRMT(Math.Round(UP, 2).ToString());
        //                lv.SubItems[4].Text = MainMDI.Curr_FRMT(Math.Round(UP, 2).ToString(), true);

        //                lv.SubItems[5].Text = Math.Round(Qty, 2).ToString();
        //                lv.SubItems[6].Text = Math.Round(xrt, 2).ToString();

        //                decimal Tot = (decimal)Tools.Conv_Dbl(Oreadr["PriceCAD"].ToString());


        //                lv.SubItems[7].Text = MainMDI.Curr_FRMT(Math.Round(Tot, 2).ToString(), true);
        //                lv.SubItems[8].Text = Oreadr["Name"].ToString();
        //                lv.SubItems[9].Text = "'" + cb_MM.Text + " " + cb_YY.Text;
        //                lv.SubItems[10].Text = Oreadr["Salesperson"].ToString();



        //                lv.SubItems[11].Text = slsP;// get_Curr_SP(Oreadr["Customer"].ToString());
        //                lv.SubItems[12].Text = ag;



        //                if (lv.SubItems[11].Text != lv.SubItems[8].Text)
        //                {
        //                    lv.BackColor = Color.Orange;
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show("fill_ALLInvoices_OUT-->ERROR= " + ex.Message + "\n   EX#= " + ex.Source);
        //    }


        //    finally
        //    {
        //        OConn.Close();
        //        if (Oreadr != null) Oreadr.Close();
        //    }

        //    //   txTOT.Text = MainMDI.Curr_FRMT(Math.Round(TOT, 2).ToString());
        //    //   lTOTperMM.Text = TOTSales.ToString();
        //}

        private void Invlst_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
           
         //   fill_ALLInvoices_IO();
  
            this.Cursor = Cursors.Default;
        }

        string get_Curr_SP(string cust_SPcode)
        {
            int pos = cust_SPcode.IndexOf("-");
            if (pos > 6) cust_SPcode = cust_SPcode.Substring(0, pos - 1);
            //  return (MainMDI.Find_One_Field_SYSPRO("SELECT Salesperson   FROM [SysproCompanyP].[dbo].[v_PGCustomerXRef] where Customer='" + cust_SPcode + "'"));
            // string stt = "SELECT  SalSalesperson.Name FROM  v_PGCustomerXRef INNER JOIN  SalSalesperson ON v_PGCustomerXRef.Branch = SalSalesperson.Branch AND v_PGCustomerXRef.Salesperson = SalSalesperson.Salesperson WHERE v_PGCustomerXRef.Customer= '" + cust_SPcode + "'";
            string stt = "  SELECT distinct    SalSalesperson.Name,  SalSalesperson_1.Name AS agency " +
                         "  FROM            v_PGCustomerXRef INNER JOIN SalSalesperson ON v_PGCustomerXRef.Branch = SalSalesperson.Branch AND v_PGCustomerXRef.Salesperson = SalSalesperson.Salesperson INNER JOIN " +
                         "                  SalSalesperson AS SalSalesperson_1 ON v_PGCustomerXRef.Salesperson1 = SalSalesperson_1.Salesperson WHERE(v_PGCustomerXRef.Customer='" + cust_SPcode + "'";

            return (MainMDI.Find_One_Field_SYSPRO(stt));

        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        void fill_CBsales()
        {

            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

     
            string stSql = (lSalesN.Text == "Inside Sales Names") ? " SELECT [Salesperson] + ' - ' + [Name] AS Expr1 FROM SalSalesperson WHERE SalSalesperson.Branch='C1' And SUBSTRING([Salesperson],1,1)='I' order by Expr1"
    : " SELECT DISTINCT SalSalesperson.Name, SalSalesperson.Salesperson  FROM SalSalesperson  WHERE SUBSTRING(SalSalesperson.Salesperson,1,1)='S' and Salesperson not in('S00','S01','S02','S06','S07')   ORDER BY SalSalesperson.Name ";

            cbSalestt.Items.Clear();
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
                    cbSales.Items.Add(Oreadr[0].ToString());
                }
          
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

        void fill_Details_List_Outside()
        {

            string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            double bigTOT = 0;
            decimal TOTSales = 0;

            //OleDbConnection OConn = null;
            //OleDbCommand Ocmd = null;
            //OleDbDataReader Oreadr = null;
            //  OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);


            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

        



            //string stSQL = " SELECT dbo_SalSalesperson.Salesperson, dbo_SalSalesperson.Name, dbo_u_SalCommissionsPrimax.DateLastInvPrt, dbo_u_SalCommissionsPrimax.FiscalYear, dbo_u_SalCommissionsPrimax.FiscalMonth, dbo_u_SalCommissionsPrimax.Project, dbo_u_SalCommissionsPrimax.Customer, dbo_u_SalCommissionsPrimax.Currency, dbo_u_SalCommissionsPrimax.Branch, dbo_u_SalCommissionsPrimax.Invoice, dbo_u_SalCommissionsPrimax.SalesOrder, dbo_u_SalCommissionsPrimax.SalesOrderLine, dbo_u_SalCommissionsPrimax.StockCode, " +
            //               "        dbo_u_SalCommissionsPrimax.StockDescription, dbo_u_SalCommissionsPrimax.OrderQty, dbo_u_SalCommissionsPrimax.ShipQty, dbo_u_SalCommissionsPrimax.BackOrderQty, dbo_u_SalCommissionsPrimax.Price, dbo_u_SalCommissionsPrimax.ExchangeRate, dbo_u_SalCommissionsPrimax.PriceCAD, dbo_u_SalCommissionsPrimax.ProductClass, dbo_u_SalCommissionsPrimax.CommissionSales1, CDbl([CommissionAmt1]) AS 1CommissionAmt1, dbo_u_SalCommissionsPrimax.Salesperson2, dbo_u_SalCommissionsPrimax.CommissionSales2, " +
            //               "        dbo_u_SalCommissionsPrimax.CommissionAmt2, dbo_u_SalCommissionsPrimax.Salesperson3, dbo_u_SalCommissionsPrimax.CommissionSales3, dbo_u_SalCommissionsPrimax.CommissionAmt3, dbo_u_SalCommissionsPrimax.Salesperson4, dbo_u_SalCommissionsPrimax.CommissionSales4, dbo_u_SalCommissionsPrimax.Rate, dbo_u_SalCommissionsPrimax.OrderQty, dbo_u_SalCommissionsPrimax.ShipQty, dbo_u_SalCommissionsPrimax.Rate  " +
            //               " FROM dbo_u_SalCommissionsPrimax INNER JOIN dbo_SalSalesperson ON (dbo_u_SalCommissionsPrimax.Branch = dbo_SalSalesperson.Branch) AND (dbo_u_SalCommissionsPrimax.Salesperson = dbo_SalSalesperson.Salesperson) " +
            //               " WHERE (((dbo_SalSalesperson.Name)='" + txSalesName.Text + "') AND ((dbo_u_SalCommissionsPrimax.FiscalYear)=" + cb_YY.Text + ") AND ((dbo_u_SalCommissionsPrimax.FiscalMonth)=" + MM + ") AND ((dbo_u_SalCommissionsPrimax.Salesperson)<>'A')) " +
            //               " ORDER BY dbo_u_SalCommissionsPrimax.Invoice";


            string stSQL = " SELECT SalSalesperson.Salesperson, SalSalesperson.Name, u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Project, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Currency, " +
                           "        u_SalCommissionsPrimax.Branch,u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.SalesOrder, u_SalCommissionsPrimax.SalesOrderLine, u_SalCommissionsPrimax.StockCode,         u_SalCommissionsPrimax.StockDescription, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, " +
                           "        u_SalCommissionsPrimax.BackOrderQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.ExchangeRate, u_SalCommissionsPrimax.PriceCAD, u_SalCommissionsPrimax.ProductClass, u_SalCommissionsPrimax.CommissionSales1, (cast ([CommissionAmt1] AS decimal)) AS CommissionAmt1,  u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2,   " +
                           "        u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.Salesperson3, u_SalCommissionsPrimax.CommissionSales3, u_SalCommissionsPrimax.CommissionAmt3, u_SalCommissionsPrimax.Salesperson4, u_SalCommissionsPrimax.CommissionSales4, u_SalCommissionsPrimax.Rate, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.Rate  " +
                           " FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch) AND (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson)  " +
                           " WHERE (((SalSalesperson.Name)='" + cbSales.Text + "') AND ((u_SalCommissionsPrimax.FiscalYear)=" + cb_YY.Text + ") AND ((u_SalCommissionsPrimax.FiscalMonth)=" + MM + ") AND ((u_SalCommissionsPrimax.Salesperson)<>'A'))   and (LOWER([Project]) not like '%cigentec%')    " +
                           " ORDER BY u_SalCommissionsPrimax.Invoice";


            string stout = "";
         //   ed_LVallInvoices.SendToBack();
            ed_lvITM.Items.Clear();
            try
            {

                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {

                    string cust_SPcode = Oreadr["Customer"].ToString(), slsP = "", ag = "";
                    int pos = cust_SPcode.IndexOf("-");
                    if (pos > 6) cust_SPcode = cust_SPcode.Substring(0, pos - 1);
                    string stt = "  SELECT distinct  ISNULL( SalSalesperson.Name,'????') as slsp , ISNULL( SalSalesperson_1.Name,'????') AS ag " +
                                 "  FROM            v_PGCustomerXRef INNER JOIN SalSalesperson ON v_PGCustomerXRef.Branch = SalSalesperson.Branch AND v_PGCustomerXRef.Salesperson = SalSalesperson.Salesperson LEFT OUTER JOIN " +
                                 "                  SalSalesperson AS SalSalesperson_1 ON v_PGCustomerXRef.Salesperson1 = SalSalesperson_1.Salesperson WHERE v_PGCustomerXRef.Customer='" + cust_SPcode + "'";

                    MainMDI.Find_2_Field_PSA(stt, ref slsP, ref ag, "S");


                    if (ag != "????" && Tools.Conv_Dbl(Oreadr["Price"].ToString()) >0)
                    {


                        ListViewItem lv = ed_lvITM.Items.Add(""); for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");

                     
                        lv.SubItems[0].Text = Oreadr["Project"].ToString();
                        lv.SubItems[1].Text = Oreadr["Invoice"].ToString();
                        lv.SubItems[2].Text = Oreadr["Customer"].ToString();

                        string CustPO = MainMDI.Find_One_Field_SYSPRO("select CustomerPoNumber from [dbo].[SorMasterRep]   where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "'");
                        lv.SubItems[3].Text = CustPO;// MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");

                        lv.SubItems[4].Text = ag;
                        lv.SubItems[5].Text = Oreadr["StockDescription"].ToString();

                        string grpitem = MainMDI.Find_One_Field_SYSPRO("select UserDef from     dbo.SorDetailRep    where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "' and SalesOrderLine='" + Oreadr["SalesOrderLine"].ToString() + "'");
                        lv.SubItems[6].Text = grpitem;


                        decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                        decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                        decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());

                        decimal Tot = UP * Qty * xrt;
                        double rate = Tools.Conv_Dbl(pct_grp(grpitem)) / 100;
                        double amt = (double)Tot * rate ;//Tools.Conv_Dbl(Oreadr["CommissionAmt1"].ToString());
                        double Irt = 0.10;// Tools.Conv_Dbl(Oreadr["Rate"].ToString()) * 100;
                        double diff = 0;
          
                        lv.SubItems[7].Text = Math.Round(Tot, 2).ToString(); TOTSales += Tot;
                     //   lv.SubItems[10].Text = "";// MainMDI.Curr_FRMT(Irt.ToString());
                        lv.SubItems[9].Text =  Math.Round(amt, 2).ToString();

                        lv.SubItems[8].Text = pct_grp(grpitem)+" %";// "10 %";
                        //   lv.SubItems[10].Text = find_QT_date(Oreadr["Project"].ToString());

                        bigTOT += amt;
                        stout += amt + "\n";

                       // Save_AGmvmt("", Oreadr["Project"].ToString(), Oreadr["Invoice"].ToString(), Oreadr["Customer"].ToString(), CustPO, ag, Oreadr["StockDescription"].ToString(), grpitem, Tot.ToString (), rate.ToString (), amt.ToString (), Oreadr["SalesOrder"].ToString(), Oreadr["SalesOrderLine"].ToString());
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
            //    MessageBox.Show(stout); 
            //OutDD = TOT;
            //txTOT.Text = MainMDI.Curr_FRMT(Math.Round(TOT, 2).ToString());
            //lTOTperMM.Text = TOTSales.ToString();

            //if (lInsideS.Text != "") { fill_CMS_Out_INside(); groupBox2.Visible = true; }
        }


        bool OKInvoice(string Invoice)
        {
            return MainMDI.Find_One_Field("select inv_lid from U_agCMSokInvoice where Invoice_OK='" + Invoice + "'")!=MainMDI.VIDE;


        }

        void SaveOKinvoice(string inv)
        {
            if (!OKInvoice(inv))
            {
                string stSql = " INSERT INTO U_agCMSokInvoice ([Invoice_OK] ) VALUES ('" + inv + "')";

                MainMDI.Exec_SQL_JFS(stSql, " AgcmsOKinvoice =" + inv + "  ");
            }
   

        }


        void Save_AGmvmt(string _lid,string _rid,string _Inv,string _customR,string _po, string _ag,string _itm,string _grp,string _price, string _cmsrate,string _cmsamnt,string _SOnbr,string _SOline)
        {

            if (_lid == "")
            {
                string stSql = " INSERT INTO U_agCMSmvmt ([RID],[Invoice],[customerNM], [PO], [agencyNM] , [item] , [Price] , [grp] , [cmsRate] , [cmsAMNT] , [SalesOrdr] , [SO_line] ) " +
               " VALUES ('" + _rid.TrimEnd() +
              "', '" + _Inv +
              "', '" + _customR.Replace("'", "''") +
              "', '" + _po.Replace("'", "''") +
              "', '" + _ag.Replace("'", "''") +
              "', '" + _itm.Replace("'", "''") +
              "', " + _price +
              ", '" + _grp.TrimEnd() +
          
              "', " + _cmsrate +
              ", " + _cmsamnt +
              ", '" + _SOnbr +
              "', " + _SOline + ")";

                MainMDI.Exec_SQL_JFS(stSql, "save AG. CMS mvmt......");
            }
            else
            {
                MessageBox.Show("ERROR importing Agencies CMS........bad LID: " + _lid);
                //if (txEVname.Text.Length > 2)
                //{
                //    string stSql = " UPDATE XCNG_Events SET [Event_Name]='" + txEVname.Text.Replace("'", "''") + "',  [Ev_Start]=" + MainMDI.SSV_date(dateTimePicker1.Value.ToShortDateString()) +
                //          ", [Ev_End]=" + MainMDI.SSV_date(dateTimePicker2.Value.ToShortDateString()) + " where EventLID=" + lEventLID.Text;
                //    MainMDI.Exec_SQL_JFS(stSql, "Events");
                //}
            }

               
               
        }


        void Import_AG_CMS( int MM,int YYYY)
        {

            
            double bigTOT = 0;
            decimal TOTSales = 0;



            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);

            //[S03],[S05],[S08],

            string stSQL = " SELECT SalSalesperson.Salesperson, SalSalesperson.Name, u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Project, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Currency, " +
                           "        u_SalCommissionsPrimax.Branch,u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.SalesOrder, u_SalCommissionsPrimax.SalesOrderLine, u_SalCommissionsPrimax.StockCode,         u_SalCommissionsPrimax.StockDescription, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, " +
                           "        u_SalCommissionsPrimax.BackOrderQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.ExchangeRate, u_SalCommissionsPrimax.PriceCAD, u_SalCommissionsPrimax.ProductClass, u_SalCommissionsPrimax.CommissionSales1, (cast ([CommissionAmt1] AS decimal)) AS CommissionAmt1,  u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2,   " +
                           "        u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.Salesperson3, u_SalCommissionsPrimax.CommissionSales3, u_SalCommissionsPrimax.CommissionAmt3, u_SalCommissionsPrimax.Salesperson4, u_SalCommissionsPrimax.CommissionSales4, u_SalCommissionsPrimax.Rate, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.Rate  " +
                           " FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch) AND (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson)  " +
                           " WHERE (SalSalesperson.Salesperson in ('S03','S05','S08')) AND (YEAR (u_SalCommissionsPrimax.DateLastInvPrt) = "+ YYYY + ") AND (month (u_SalCommissionsPrimax.DateLastInvPrt)= " + MM + ")  and (LOWER([Project]) not like '%cigentec%')    " +
                           " ORDER BY u_SalCommissionsPrimax.Invoice";


        //    string stout = "";
            //   ed_LVallInvoices.SendToBack();
          //  ed_lvITM.Items.Clear();
            try
            {

                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();
                string oldINV = "", newINV = "";
                while (Oreadr.Read())
                {
                              
              
                    if (!OKInvoice(Oreadr["Invoice"].ToString()))
                    {


                        string cust_SPcode = Oreadr["Customer"].ToString(), slsP = "", ag = "";
                        int pos = cust_SPcode.IndexOf("-");
                        if (pos > 6) cust_SPcode = cust_SPcode.Substring(0, pos - 1);
                        string stt = "  SELECT distinct  ISNULL( SalSalesperson.Name,'????') as slsp , ISNULL( SalSalesperson_1.Name,'????') AS ag " +
                                     "  FROM            v_PGCustomerXRef INNER JOIN SalSalesperson ON v_PGCustomerXRef.Branch = SalSalesperson.Branch AND v_PGCustomerXRef.Salesperson = SalSalesperson.Salesperson LEFT OUTER JOIN " +
                                     "                  SalSalesperson AS SalSalesperson_1 ON v_PGCustomerXRef.Salesperson1 = SalSalesperson_1.Salesperson WHERE v_PGCustomerXRef.Customer='" + cust_SPcode + "'";

                        MainMDI.Find_2_Field_PSA(stt, ref slsP, ref ag, "S");


                        if (ag != "????" && Tools.Conv_Dbl(Oreadr["Price"].ToString()) > 0)
                        {
                            newINV = Oreadr["Invoice"].ToString();
                            if (oldINV != newINV && oldINV != "") SaveOKinvoice(oldINV);

                          //  ListViewItem lv = ed_lvITM.Items.Add(""); for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");
                          
                            //lv.SubItems[0].Text = Oreadr["Project"].ToString();
                            //lv.SubItems[1].Text = Oreadr["Invoice"].ToString();
                            //lv.SubItems[2].Text = Oreadr["Customer"].ToString();


                            string CustPO = MainMDI.Find_One_Field_SYSPRO("select CustomerPoNumber from [dbo].[SorMasterRep]   where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "'");
                            //lv.SubItems[3].Text = CustPO;// MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");

                            //lv.SubItems[4].Text = ag;
                            //lv.SubItems[5].Text = Oreadr["StockDescription"].ToString();

                            string grpitem = MainMDI.Find_One_Field_SYSPRO("select UserDef from     dbo.SorDetailRep    where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "' and SalesOrderLine='" + Oreadr["SalesOrderLine"].ToString() + "'");
                           
                            grpitem = (grpitem.TrimEnd() == "") ? "A" : grpitem.TrimEnd();
                            //lv.SubItems[6].Text = grpitem;

                            decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                            decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                            decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());
                            decimal Tot = UP * Qty * xrt;
                            double rate = Tools.Conv_Dbl(pct_grp(grpitem)) / 100;
                            double amt = (double)Tot * rate;//Tools.Conv_Dbl(Oreadr["CommissionAmt1"].ToString());
                            //double Irt = 0.10;// Tools.Conv_Dbl(Oreadr["Rate"].ToString()) * 100;
                            //double diff = 0;


                            //lv.SubItems[7].Text = Math.Round(Tot, 2).ToString(); TOTSales += Tot;
                            ////   lv.SubItems[10].Text = "";// MainMDI.Curr_FRMT(Irt.ToString());
                            //lv.SubItems[9].Text = Math.Round(amt, 2).ToString();

                            //lv.SubItems[8].Text = pct_grp(grpitem) + " %";// "10 %";
                            //                                              //   lv.SubItems[10].Text = find_QT_date(Oreadr["Project"].ToString());

                            bigTOT += amt;
                            //stout += amt + "\n";
                            oldINV = newINV;


                            Save_AGmvmt("", Oreadr["Project"].ToString(), Oreadr["Invoice"].ToString(), Oreadr["Customer"].ToString(), CustPO, ag, Oreadr["StockDescription"].ToString(), grpitem, Tot.ToString(), rate.ToString(), amt.ToString(), Oreadr["SalesOrder"].ToString(), Oreadr["SalesOrderLine"].ToString());
                        }
                    }

                }
                if (oldINV != "") SaveOKinvoice(oldINV); //if (oldINV != newINV && oldINV != "")
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to import Agencies CMS.........ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL);
            }


            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }


            MessageBox.Show("Import Done ............");


        }

        void Import_AG_CMS_OLD(int MM, int YYYY)
        {


            double bigTOT = 0;
            decimal TOTSales = 0;



            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);



            string stSQL = " SELECT SalSalesperson.Salesperson, SalSalesperson.Name, u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Project, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Currency, " +
                           "        u_SalCommissionsPrimax.Branch,u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.SalesOrder, u_SalCommissionsPrimax.SalesOrderLine, u_SalCommissionsPrimax.StockCode,         u_SalCommissionsPrimax.StockDescription, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, " +
                           "        u_SalCommissionsPrimax.BackOrderQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.ExchangeRate, u_SalCommissionsPrimax.PriceCAD, u_SalCommissionsPrimax.ProductClass, u_SalCommissionsPrimax.CommissionSales1, (cast ([CommissionAmt1] AS decimal)) AS CommissionAmt1,  u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2,   " +
                           "        u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.Salesperson3, u_SalCommissionsPrimax.CommissionSales3, u_SalCommissionsPrimax.CommissionAmt3, u_SalCommissionsPrimax.Salesperson4, u_SalCommissionsPrimax.CommissionSales4, u_SalCommissionsPrimax.Rate, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.Rate  " +
                           " FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch) AND (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson)  " +
                           " WHERE (SalSalesperson.Salesperson in ('S03','S05','S08')) AND (YEAR (u_SalCommissionsPrimax.DateLastInvPrt) = " + YYYY + ") AND (month (u_SalCommissionsPrimax.DateLastInvPrt)= " + MM + ")  and (LOWER([Project]) not like '%cigentec%')    " +
                           " ORDER BY u_SalCommissionsPrimax.Invoice";


            string stout = "";
            //   ed_LVallInvoices.SendToBack();
            ed_lvITM.Items.Clear();
            try
            {

                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();
                string oldINV = "", newINV = "";
                while (Oreadr.Read())
                {



                    if (!OKInvoice(Oreadr["Invoice"].ToString()))
                    {


                        string cust_SPcode = Oreadr["Customer"].ToString(), slsP = "", ag = "";
                        int pos = cust_SPcode.IndexOf("-");
                        if (pos > 6) cust_SPcode = cust_SPcode.Substring(0, pos - 1);
                        string stt = "  SELECT distinct  ISNULL( SalSalesperson.Name,'????') as slsp , ISNULL( SalSalesperson_1.Name,'????') AS ag " +
                                     "  FROM            v_PGCustomerXRef INNER JOIN SalSalesperson ON v_PGCustomerXRef.Branch = SalSalesperson.Branch AND v_PGCustomerXRef.Salesperson = SalSalesperson.Salesperson LEFT OUTER JOIN " +
                                     "                  SalSalesperson AS SalSalesperson_1 ON v_PGCustomerXRef.Salesperson1 = SalSalesperson_1.Salesperson WHERE v_PGCustomerXRef.Customer='" + cust_SPcode + "'";

                        MainMDI.Find_2_Field_PSA(stt, ref slsP, ref ag, "S");


                        if (ag != "????" && Tools.Conv_Dbl(Oreadr["Price"].ToString()) > 0)
                        {
                            newINV = Oreadr["Invoice"].ToString();
                            if (oldINV != newINV && oldINV != "") SaveOKinvoice(oldINV);

                            ListViewItem lv = ed_lvITM.Items.Add(""); for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");


                            lv.SubItems[0].Text = Oreadr["Project"].ToString();
                            lv.SubItems[1].Text = Oreadr["Invoice"].ToString();
                            lv.SubItems[2].Text = Oreadr["Customer"].ToString();

                            string CustPO = MainMDI.Find_One_Field_SYSPRO("select CustomerPoNumber from [dbo].[SorMasterRep]   where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "'");
                            lv.SubItems[3].Text = CustPO;// MainMDI.Eng_date(Oreadr["DateLastInvPrt"].ToString(), "/");

                            lv.SubItems[4].Text = ag;
                            lv.SubItems[5].Text = Oreadr["StockDescription"].ToString();

                            string grpitem = MainMDI.Find_One_Field_SYSPRO("select UserDef from     dbo.SorDetailRep    where SalesOrder='" + Oreadr["SalesOrder"].ToString() + "' and SalesOrderLine='" + Oreadr["SalesOrderLine"].ToString() + "'");

                            grpitem = (grpitem.TrimEnd() == "") ? "A" : grpitem.TrimEnd();
                            lv.SubItems[6].Text = grpitem;

                            decimal UP = (decimal)Tools.Conv_Dbl(Oreadr["Price"].ToString());
                            decimal Qty = (decimal)Tools.Conv_Dbl(Oreadr["ShipQty"].ToString());
                            decimal xrt = (decimal)Tools.Conv_Dbl(Oreadr["ExchangeRate"].ToString());
                            decimal Tot = UP * Qty * xrt;
                            double rate = Tools.Conv_Dbl(pct_grp(grpitem)) / 100;
                            double amt = (double)Tot * rate;//Tools.Conv_Dbl(Oreadr["CommissionAmt1"].ToString());
                            //double Irt = 0.10;// Tools.Conv_Dbl(Oreadr["Rate"].ToString()) * 100;
                            //double diff = 0;


                            lv.SubItems[7].Text = Math.Round(Tot, 2).ToString(); TOTSales += Tot;
                            //   lv.SubItems[10].Text = "";// MainMDI.Curr_FRMT(Irt.ToString());
                            lv.SubItems[9].Text = Math.Round(amt, 2).ToString();

                            lv.SubItems[8].Text = pct_grp(grpitem) + " %";// "10 %";
                                                                          //   lv.SubItems[10].Text = find_QT_date(Oreadr["Project"].ToString());

                            bigTOT += amt;
                            stout += amt + "\n";
                            oldINV = newINV;


                            Save_AGmvmt("", Oreadr["Project"].ToString(), Oreadr["Invoice"].ToString(), Oreadr["Customer"].ToString(), CustPO, ag, Oreadr["StockDescription"].ToString(), grpitem, Tot.ToString(), rate.ToString(), amt.ToString(), Oreadr["SalesOrder"].ToString(), Oreadr["SalesOrderLine"].ToString());
                        }
                    }

                }
                if (oldINV != "") SaveOKinvoice(oldINV); //if (oldINV != newINV && oldINV != "")
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to import Agencies CMS.........ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL);
            }


            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }





        }


        string pct_grp(string grp)
        {
            string pct = "0";
            switch (grp.TrimEnd())
            {
                case "A":
                    pct = "10";
                    break;
                case "B":
                    pct = "5";
                    break;
                case "C":
                    pct = "7";
                    break;
                case "D":
                    pct = "12";
                    break;
                case "E":
                    pct = "3";
                    break;
                case "F":
                    pct = "1.5";
                    break;

            }

            return pct;

        }

        private void cmslst_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            fill_Details_List_Outside();
            this.Cursor = Cursors.Default;

        }

        private void cbSales_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            txSalesName.Text = cbSales.Text;
            //    lSalesCode.Text = MainMDI.Find_One_Field_ACCESS("SELECT dbo_SalSalesperson.Salesperson FROM dbo_SalSalesperson WHERE dbo_SalSalesperson.Name='" + txSalesName.Text + "' AND dbo_SalSalesperson.Branch='C1'");


            lSalesCode.Text = MainMDI.Find_One_Field_SYSPRO("SELECT SalSalesperson.Salesperson FROM SalSalesperson WHERE SalSalesperson.Name='" + txSalesName.Text + "' AND SalSalesperson.Branch='C1'");


        }

        private void tls_AG_CMS_import_Click(object sender, EventArgs e)
        {
            Import_allAGCMS();
 
        }

        void Import_allAGCMS()
        {
            this.Cursor = Cursors.WaitCursor;
            if (CMS_period_MMYYYY())
            {


                int mm = Int32.Parse(cb_month.Text.Substring(0, 2));
                int YYYY = Int32.Parse(cbYYYY.Text);
                Import_AG_CMS(mm, YYYY);
            }
            else MessageBox.Show("ERROR:  can not import Agencies CMS.... no period !!!!!");

            this.Cursor = Cursors.Default;

        }



        bool fill_CBMMYY()
        {
            
            string MM = "", YY = "";
            MainMDI.Find_2_Field("SELECT [F2] ,[F3]  FROM [Orig_PSM_FDB].[dbo].[PSM_C_GConfig] where F1_code='CMS_MMYY'", ref MM, ref YY);
            if (MM != MainMDI.VIDE)
            {
                cb_MM.Text = MM;
                cb_YY.Text = YY;
                return true;
            }
            return false;

        }

        private void button3_Click(object sender, EventArgs e)
        {
         // MessageBox.Show ("MMYYYY =" +  CMS_period_MMYYYY());
        }

       bool CMS_period_MMYYYY()
        {
            string MM = "", YYYY = "";
           MainMDI.Find_2_Field("SELECT [F2] ,[F3]  FROM [Orig_PSM_FDB].[dbo].[PSM_C_GConfig] where F1_code='CMS_MMYY'", ref MM, ref YYYY);
            if (MM != MainMDI.VIDE)
            {
                cb_MM.Text = MM;
                cb_YY.Text = YYYY;
                MM = MM.Substring(0, 2);
                if (Tools.Conv_Dbl(MM) == 12)
                {
                    cb_month.Text = "01";
                    cbYYYY.Text = YYYY;// (Tools.Conv_Dbl(YYYY) ).ToString();
                                       //dpFrom.Value = DateTime.ParseExact("01/01/20" + YY, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                                       //dpTo.Value = DateTime.ParseExact("31/01/20" + YY, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                }
                else
                {

                    double m = Tools.Conv_Dbl(MM) + 1;

                    cb_month.Text = MainMDI.A00(m.ToString(), 2);

                    double a = Tools.Conv_Dbl(YYYY) - 1;
                    cbYYYY.Text = YYYY;//= a.ToString();

                }
                return true;
            }
          return false;
           
        }



















        //SQL for inside Sales
        //SELECT        IntSalesperson, FiscalYear, FiscalMonth, Project, Invoice, Price, Amt
        //FROM            v_H_InsideSales
        //WHERE        (LOWER(Project) NOT LIKE '%cigentec%') AND (LOWER(Project) LIKE '%6107%' OR LOWER(Project) LIKE '%6157%' OR LOWER(Project) LIKE '%6161%')
        //ORDER BY IntSalesperson, Invoice, FiscalYear, FiscalMonth

        //SELECT        IntSalesperson, cast( FiscalYear as varchar) +'/'+ cast( FiscalMonth as varchar) + '/01' as dd, Project, Invoice, Price, Amt
        //FROM            v_H_InsideSales
        //WHERE        (LOWER(Project) NOT LIKE '%cigentec%') AND (LOWER(Project) LIKE '%6107%' OR
        //                         LOWER(Project) LIKE '%6157%' OR
        //                         LOWER(Project) LIKE '%6161%') AND (CONVERT(smalldatetime,cast( FiscalYear as varchar) +'/'+ cast( FiscalMonth as varchar) + '/01',103) < CONVERT(smalldatetime, '2018/07/01', 103))
        //ORDER BY IntSalesperson, Invoice, FiscalYear, FiscalMonth






        //SQL for outside Sales

        //SELECT        SalSalesperson.Salesperson, SalSalesperson.Name, u_SalCommissionsPrimax.DateLastInvPrt, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth, u_SalCommissionsPrimax.Project, 
        //                         u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Currency, u_SalCommissionsPrimax.Branch, u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.SalesOrder, 
        //                         u_SalCommissionsPrimax.SalesOrderLine, u_SalCommissionsPrimax.StockCode, u_SalCommissionsPrimax.StockDescription, u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.ShipQty, 
        //                         u_SalCommissionsPrimax.BackOrderQty, u_SalCommissionsPrimax.Price, u_SalCommissionsPrimax.ExchangeRate, u_SalCommissionsPrimax.PriceCAD, u_SalCommissionsPrimax.ProductClass, 
        //                         u_SalCommissionsPrimax.CommissionSales1, CAST(u_SalCommissionsPrimax.CommissionAmt1 AS decimal) AS CommissionAmt1, u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2, 
        //                         u_SalCommissionsPrimax.CommissionAmt2, u_SalCommissionsPrimax.Salesperson3, u_SalCommissionsPrimax.CommissionSales3, u_SalCommissionsPrimax.CommissionAmt3, u_SalCommissionsPrimax.Salesperson4, 
        //                         u_SalCommissionsPrimax.CommissionSales4, u_SalCommissionsPrimax.Rate, u_SalCommissionsPrimax.OrderQty AS Expr1, u_SalCommissionsPrimax.ShipQty AS Expr2, u_SalCommissionsPrimax.Rate AS Expr3
        //FROM            u_SalCommissionsPrimax INNER JOIN
        //                         SalSalesperson ON u_SalCommissionsPrimax.Branch = SalSalesperson.Branch AND u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson
        //WHERE        (u_SalCommissionsPrimax.Salesperson <> 'A') AND (LOWER(u_SalCommissionsPrimax.Project) NOT LIKE '%cigentec%') AND (LOWER(Project) LIKE '%6107%' OR LOWER(Project) LIKE '%6157%' OR LOWER(Project) LIKE '%6161%')
        //ORDER BY u_SalCommissionsPrimax.Invoice , FiscalYear, FiscalMonth

    }
}