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
    public partial class CMS_Repair_manu : Form
    {
        public static EAHLibs.Lib1 Tools = new Lib1();
        int ndx = -1, oldNdx = -1;
        string Outside_CMS = "u_SalCommissionsPrimax";
        //string Outside_CMS = "u_SalCommissionsPrimax_TST";
        public CMS_Repair_manu()
        {
            InitializeComponent();
        }

        private void btnimport_Click(object sender, EventArgs e)
        {
            Fill_lvCMS();
            fill_Invoices();
            fill_After();
        }

        void init_3tx()
        {
            txCust.Clear();
            txMMYY.Clear();
            txPrj.Clear();
            txBranch.Clear();
            txXrate.Clear();
        }

        void init_Edit_tx()
        {
            txNewcms.Clear();
            txOldcms.Clear();
            txrate.Clear();
            txCAD.Clear();
            //cbSales.Items.Clear();
            txItem.Clear();
        }

        void Fill_lvCMS()
        {
            init_3tx();
            oldNdx = -1; ndx = -1;
            grpSearch.Enabled = true;
            string stSql = "select  Salesperson,cast(FiscalMonth as varchar ) +'/'+ cast( FiscalYear as varchar) as FMMYY , Project, Customer,Branch, StockDescription, Price, ExchangeRate, PriceCAD,CommissionSales1,  CommissionAmt1,   LID from " + Outside_CMS + " where Invoice='" + txINV.Text + "' ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            lvCMS.Items.Clear();
            while (Oreadr.Read())
            {
                if (txCust.Text.Length < 1)
                {
                    txCust.Text = Oreadr[3].ToString();
                    txMMYY.Text = Oreadr[1].ToString();
                    txPrj.Text = Oreadr[2].ToString();
                    txXrate.Text = Oreadr[7].ToString();
                    txBranch.Text = Oreadr[4].ToString();
                }
                ListViewItem lv = lvCMS.Items.Add(Oreadr[0].ToString());

                for (int i = 5; i < 12; i++)
                {
                    if (i != 7) lv.SubItems.Add(Oreadr[i].ToString());
                }
            }
            OConn.Close();
        }

        void fill_cbSales()
        {
            cbSales.Items.Clear();
            string stSql = "SELECT SalSalesperson.Salesperson +'  ' + SalSalesperson.Name,SalSalesperson.Salesperson  FROM SalSalesperson WHERE (((SalSalesperson.Branch)='" + txBranch.Text + "') And ( (Left([Salesperson],1))='S' Or (Left([Salesperson],1))='H')) order by Salesperson";
            MainMDI.fill_CB_SYSP(cbSales, stSql, false, "");
        }

        void fill_Invoices()
        {
            //lvBefore.Items.Clear();
            //string oldInv = "", newInv = "";
            //for (int i = 0; i < lvCMS.Items.Count; i++)
            //{
                //newInv = lvCMS.Items[i].SubItems[0].Text;
                //if (oldInv != newInv)
                //{
                    ////string stSql = "select LID,Invoice,Customer,Price,ShipQty,ExchangeRate,PriceCAD,Salesperson,CommissionSales1,CommissionAmt1 FROM u_SalCommissionsPrimax where Invoice='" + newInv + "'";
                    //string stSql = " SELECT     u_SalCommissionsPrimax.LID, u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Price, " +
                        //"            u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.ExchangeRate, u_SalCommissionsPrimax.PriceCAD,u_SalCommissionsPrimax.Salesperson +' - '+ SalSalesperson.Name as SNme, " +
                        //"            u_SalCommissionsPrimax.CommissionSales1, u_SalCommissionsPrimax.CommissionAmt1,u_SalCommissionsPrimax.Salesperson as SP" +
                        //" FROM         u_SalCommissionsPrimax INNER JOIN SalSalesperson ON u_SalCommissionsPrimax.Branch = SalSalesperson.Branch AND u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson " +
                        //" where Invoice='" + newInv + "'";
                    //SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
                    //OConn.Open();
                    //SqlCommand Ocmd = OConn.CreateCommand();
                    //Ocmd.CommandText = stSql;
                    //SqlDataReader Oreadr = Ocmd.ExecuteReader();

                    //while (Oreadr.Read())
                    //{
                        //ListViewItem lv = lvBefore.Items.Add(Oreadr[0].ToString());
                        //for (int k = 1; k < 10; k++) lv.SubItems.Add(Oreadr[k].ToString().TrimEnd());
                        //lv.SubItems.Add(lvCMS.Items[i].SubItems[3].Text);
                        //lv.SubItems.Add(lvCMS.Items[i].SubItems[5].Text);
                        //lv.SubItems.Add(Oreadr["SP"].ToString());
                    //}
                    //OConn.Close();
                //}
                //oldInv = newInv;
                //lvBefore.Visible = true;
            //}
        }

        void fill_After()
        {
            //lv_After.Items.Clear();

            //for (int i = 0; i < lvBefore.Items.Count; i++)
            //{
                //ListViewItem lv = lv_After.Items.Add(lvBefore.Items[i].SubItems[0].Text);
                //for (int k = 1; k < 11; k++) lv.SubItems.Add(lvBefore.Items[i].SubItems[k].Text);
                //lv.SubItems[10].Text = lvBefore.Items[i].SubItems[11].Text;
                //if (lvBefore.Items[i].SubItems[11].Text != lvBefore.Items[i].SubItems[12].Text)
                //{
                    //lv.SubItems[7].Text = MainMDI.Find_One_Field_SYSPRO("select Salesperson +' - '+ SalSalesperson.Name as SNme from SalSalesperson where Salesperson='" + lvBefore.Items[i].SubItems[11].Text + "'");
                    //double dd = Tools.Conv_Dbl(lv.SubItems[2].Text) * Tools.Conv_Dbl(lv.SubItems[3].Text) * Tools.Conv_Dbl(lv.SubItems[4].Text) * (Tools.Conv_Dbl(lv.SubItems[2].Text) / 100);
                    //lv.SubItems[8].Text = Math.Round(dd, 2).ToString();
                    //lv.BackColor = Color.LightSalmon;
                    //lvBefore.Items[i].BackColor = Color.LightSalmon;
                    //if (!btnLook.Visible) btnLook.Visible = true;
                //}
            //}
        }

        //private void btnProc_Click(object sender, EventArgs e)
        //{
            //Fix_ERRORS();
        //}

        //void Fix_ERRORS()
        //{
            //if (MainMDI.Confirm("Want fix Errors ?"))
            //{
                //int TRScount = 0;
                //for (int i = 0; i < lv_After.Items.Count; i++)
                //{
                    //if (lv_After.Items[i].BackColor == Color.LightSalmon)
                    //{
                        //string stSql = "update u_SalCommissionsPrimax set [Salesperson]='" + lv_After.Items[i].SubItems[10].Text + "' ,[CommissionAmt1]=" + lv_After.Items[i].SubItems[9].Text + " where LID=" + lv_After.Items[i].SubItems[0].Text;
                        ////MainMDI.Exec_SQL_JFS_SYSPRO(stSql, "Modfi CMS Outside Sales...PGC..");
                        //TRScount++;
                    //}
                //}
                //string msg = (TRScount < 2) ? " Record modified...." : " Records modified....";
                //MessageBox.Show(TRScount.ToString() + msg);
            //}
        //}

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnLook_Click(object sender, EventArgs e)
        {
            txINV.Text = MainMDI.A00(txINV.Text,15);
            Fill_lvCMS();
        }

        private void lvCMS_DoubleClick(object sender, EventArgs e)
        {
            grpedit.Visible = true;
            ndx = lvCMS.SelectedItems[0].Index;
            if (oldNdx > -1) lvCMS.Items[oldNdx].BackColor = Color.PeachPuff;
            lvCMS.Items[ndx].BackColor = Color.GreenYellow; 
            txItem.Text = lvCMS.Items[ndx].SubItems[1].Text;
            txCAD.Text = lvCMS.Items[ndx].SubItems[3].Text;
            txrate.Text = lvCMS.Items[ndx].SubItems[4].Text;
            txNewcms.Text = lvCMS.Items[ndx].SubItems[5].Text;
            txOldcms.Text = lvCMS.Items[ndx].SubItems[5].Text;
            fill_cbSales();
            string stSql = "SELECT SalSalesperson.Salesperson +'  ' + SalSalesperson.Name FROM SalSalesperson WHERE [Salesperson]='" + lvCMS.Items[ndx].SubItems[0].Text + "' and SalSalesperson.Branch='" + txBranch.Text + "'";
            string st = MainMDI.Find_One_Field_SYSPRO(stSql);
            cbSales.Text = st;
            oldNdx = ndx;
            grpSearch.Enabled = false;
        }

        private void lvCMS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txrate_TextChanged(object sender, EventArgs e)
        {
            Calc_NewCMS();
        }

        void Calc_NewCMS()
        {
            double dd = Tools.Conv_Dbl(txCAD.Text) * Tools.Conv_Dbl(txrate.Text) / 100.0d;
            if (dd > 0) txNewcms.Text = dd.ToString();
        }

        private void cbSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            lSalcode.Text = MainMDI.get_CBX_value(cbSales, cbSales.SelectedIndex);
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
            //init_3tx();
            init_Edit_tx();
            //if (oldNdx > -1) lvCMS.Items[oldNdx].BackColor = Color.PeachPuff;
            grpedit.Visible = false;
            Fill_lvCMS();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SavLine();
        }

        void SavLine()
        {
            Update_Modif(ndx, txrate.Text, lSalcode.Text);
            cancel_Edit();
        }

        void Update_Modif(int u_ndx, string cmsRate, string _SalesCode)
        {
            double dd = Tools.Conv_Dbl(lvCMS.Items[u_ndx].SubItems[3].Text) * Tools.Conv_Dbl(cmsRate) / 100.0d;

            string stSql = "update   " + Outside_CMS + "  set [Salesperson]='" + _SalesCode + "',  [CommissionSales1]=" + cmsRate + " , [CommissionAmt1]=" + dd.ToString() + " where  LID=" + lvCMS.Items[u_ndx].SubItems[6].Text;
            MainMDI.Exec_SQL_JFS_SYSPRO(stSql, " CMS Repair....");
        }

        private void btnapply_Click(object sender, EventArgs e)
        {
            maj_ALL_Invoice();
        }

        void maj_ALL_Invoice()
        {
            for (int i = 0; i < lvCMS.Items.Count; i++) Update_Modif(i, txrate.Text, lSalcode.Text);
            cancel_Edit();
        }
    }
}