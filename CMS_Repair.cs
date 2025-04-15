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
    public partial class CMS_Repair : Form
    {
        public static EAHLibs.Lib1 Tools = new Lib1();

        public CMS_Repair()
        {
            InitializeComponent();
        }

        private void btnimport_Click(object sender, EventArgs e)
        {
            Fill_lvCMS();
            fill_Invoices();
            fill_After();
        }

        void Fill_lvCMS()
        {
            //string CondAdmin = (MainMDI.User.ToLower() == "shammou") ? " where USRadmin='" + MainMDI.User.ToLower() + "'" : " ";
            //string stSql = (Abr != "VA") ? "SELECT EventLID, Event_Name,EvType  FROM [Orig_PSM_FDB].[dbo].[XCNG_Events] where EvType='" + Abr + "' order by Ev_Start" : " SELECT [Depcode] ,[DepName],'VA'  FROM [Orig_PSM_FDB].[dbo].[XCNG_Departements] ";
            string stSql = " SELECT * from  U_OutCMS_Repair order by Invoice";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon); //_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            lvCMS.Items.Clear();
            while (Oreadr.Read())
            {
                string Inv = MainMDI.A00(Oreadr[0].ToString(), 6);
                ListViewItem lv = lvCMS.Items.Add(Inv);
                for (int i = 1; i < 7; i++) lv.SubItems.Add(Oreadr[i].ToString().TrimEnd());
            }
            OConn.Close();
        }

        void fill_Invoices()
        {
            lvBefore.Items.Clear();
            string oldInv = "", newInv = "";
            for (int i = 0; i < lvCMS.Items.Count; i++)
            {
                newInv = lvCMS.Items[i].SubItems[0].Text;
                if (oldInv != newInv)
                {
                    //string stSql = "select LID,Invoice,Customer,Price,ShipQty,ExchangeRate,PriceCAD,Salesperson,CommissionSales1,CommissionAmt1 FROM u_SalCommissionsPrimax where Invoice='" + newInv + "'";
                    string stSql = " SELECT     u_SalCommissionsPrimax.LID, u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Price, " +
                        "            u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.ExchangeRate, u_SalCommissionsPrimax.PriceCAD,u_SalCommissionsPrimax.Salesperson +' - '+ SalSalesperson.Name as SNme, " +
                        "            u_SalCommissionsPrimax.CommissionSales1, u_SalCommissionsPrimax.CommissionAmt1,u_SalCommissionsPrimax.Salesperson as SP" +
                        " FROM         u_SalCommissionsPrimax INNER JOIN SalSalesperson ON u_SalCommissionsPrimax.Branch = SalSalesperson.Branch AND u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson " +
                        " where Invoice='" + newInv + "'";
                    SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
                    OConn.Open();
                    SqlCommand Ocmd = OConn.CreateCommand();
                    Ocmd.CommandText = stSql;
                    SqlDataReader Oreadr = Ocmd.ExecuteReader();

                    while (Oreadr.Read())
                    {
                        ListViewItem lv = lvBefore.Items.Add(Oreadr[0].ToString());
                        for (int k = 1; k < 10; k++) lv.SubItems.Add(Oreadr[k].ToString().TrimEnd());
                        lv.SubItems.Add(lvCMS.Items[i].SubItems[3].Text);
                        lv.SubItems.Add(lvCMS.Items[i].SubItems[5].Text);
                        lv.SubItems.Add(Oreadr["SP"].ToString());
                    }
                    OConn.Close();
                }
                oldInv = newInv;
                lvBefore.Visible = true;
            }
        }

        void fill_After()
        {
            lv_After.Items.Clear();

            for (int i = 0; i < lvBefore.Items.Count; i++)
            {
                ListViewItem lv = lv_After.Items.Add(lvBefore.Items[i].SubItems[0].Text);
                for (int k = 1; k < 11; k++) lv.SubItems.Add(lvBefore.Items[i].SubItems[k].Text);
                lv.SubItems[10].Text = lvBefore.Items[i].SubItems[11].Text;
                if (lvBefore.Items[i].SubItems[11].Text != lvBefore.Items[i].SubItems[12].Text)
                {
                    lv.SubItems[7].Text = MainMDI.Find_One_Field_SYSPRO("select Salesperson +' - '+ SalSalesperson.Name as SNme from SalSalesperson where Salesperson='" + lvBefore.Items[i].SubItems[11].Text + "'");
                    double dd = Tools.Conv_Dbl(lv.SubItems[2].Text) * Tools.Conv_Dbl(lv.SubItems[3].Text) * Tools.Conv_Dbl(lv.SubItems[4].Text) * (Tools.Conv_Dbl(lv.SubItems[2].Text) / 100);
                    lv.SubItems[8].Text = Math.Round(dd, 2).ToString();
                    lv.BackColor = Color.LightSalmon;
                    lvBefore.Items[i].BackColor = Color.LightSalmon;
                    if (!btnProc.Visible) btnProc.Visible = true;
                }
            }
        }

        private void btnProc_Click(object sender, EventArgs e)
        {
            Fix_ERRORS();
        }

        void Fix_ERRORS()
        {
            if (MainMDI.Confirm("Want fix Errors ?"))
            {
                int TRScount = 0;
                for (int i = 0; i < lv_After.Items.Count; i++)
                {
                    if (lv_After.Items[i].BackColor == Color.LightSalmon)
                    {
                        string stSql = "update u_SalCommissionsPrimax set [Salesperson]='" + lv_After.Items[i].SubItems[10].Text + "' ,[CommissionAmt1]=" + lv_After.Items[i].SubItems[9].Text + " where LID=" + lv_After.Items[i].SubItems[0].Text;
                        //MainMDI.Exec_SQL_JFS_SYSPRO(stSql, "Modfi CMS Outside Sales...PGC..");
                        TRScount++;
                    }
                }
                string msg = (TRScount < 2) ? " Record modified...." : " Records modified....";
                MessageBox.Show(TRScount.ToString() + msg);
            }
        }
    }
}