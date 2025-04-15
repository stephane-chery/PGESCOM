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
using System.Management;
using System.Globalization;

namespace PGESCOM
{
    public partial class CMS_Agents : Form
    {
        public static EAHLibs.Lib1 Tools = new Lib1();

        int OLDTVTR_Selndx = -1;
        string curr_X = "";
        string[,] arr_infPGC = new string[20, 2], arr_infSP = new string[20, 2];

        public CMS_Agents()
        {
            InitializeComponent();
        }

        private void btnimport_Click(object sender, EventArgs e)
        {
            //Fill_lvCMS();
            fill_TVInv();
        }

        void Fill_lvCMS(string _inv)
        {
            //string CondAdmin = (MainMDI.User.ToLower() == "shammou") ? " where USRadmin='" + MainMDI.User.ToLower() + "'" : " ";
            //string stSql = (Abr != "VA") ? "SELECT EventLID, Event_Name,EvType  FROM [Orig_PSM_FDB].[dbo].[XCNG_Events] where EvType='" + Abr + "' order by Ev_Start" : " SELECT [Depcode] ,[DepName],'VA'  FROM [Orig_PSM_FDB].[dbo].[XCNG_Departements] ";
            string stSql = " SELECT distinct u_SalCommissionsPrimax.Invoice,CAST( u_SalCommissionsPrimax.FiscalMonth as varchar)  +'-' + cast(u_SalCommissionsPrimax.FiscalYear as varchar) as YYMM, " +
                " u_SalCommissionsPrimax.Customer, u_SalCommissionsPrimax.Project , u_SalCommissionsPrimax.StockCode, u_SalCommissionsPrimax.StockDescription, u_SalCommissionsPrimax.Price,u_SalCommissionsPrimax.ShipQty, u_SalCommissionsPrimax.ExchangeRate,  u_SalCommissionsPrimax.PriceCAD, " +
                " SalSalesperson.Name, u_SalCommissionsPrimax.Salesperson, u_SalCommissionsPrimax.Branch, u_SalCommissionsPrimax.CommissionSales1, u_SalCommissionsPrimax.CommissionAmt1, u_SalCommissionsPrimax.Salesperson2, u_SalCommissionsPrimax.CommissionSales2, u_SalCommissionsPrimax.CommissionAmt2, " +
                " u_SalCommissionsPrimax.UserDef, u_SalCommissionsPrimax.Rate, LEFT(u_SalCommissionsPrimax.Salesperson, 1) AS expr1, ArInvoice.InvoiceBal1,  u_SalCommissionsPrimax.OrderQty, u_SalCommissionsPrimax.DateLastInvPrt, ArInvoice.Customer as CustCode " +
                " FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson" +
                "   INNER JOIN ArInvoice ON u_SalCommissionsPrimax.Invoice = ArInvoice.Invoice AND (u_SalCommissionsPrimax.PriceCAD>0) " +
                " WHERE (SUBSTRING(u_SalCommissionsPrimax.Invoice, 1, 1) <> '7') AND (CAST(u_SalCommissionsPrimax.Invoice AS decimal) = " + 
                Tools.Conv_Dbl(_inv) + ") AND (ArInvoice.InvoiceBal1 = 0) " +
                " ORDER BY u_SalCommissionsPrimax.Invoice"; //, u_SalCommissionsPrimax.FiscalYear, u_SalCommissionsPrimax.FiscalMonth ";
   
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            lvINV_SP.Items.Clear();
            lvINV_PGC.Items.Clear();
            init_arrInfo(ref arr_infSP);
            int II = 0;
            while (Oreadr.Read())
            {
                //string Ifnv = MainMDI.A00(Oreadr[0].ToString(), 6);
                ListViewItem lv = lvINV_SP.Items.Add(Oreadr[0].ToString());
                for (int i = 1; i < 11; i++) lv.SubItems.Add(Oreadr[i].ToString().TrimEnd());

                if (curr_X == "") curr_X = Oreadr["ExchangeRate"].ToString();
                if (arr_infSP[0, 0] == "")
                {
                    arr_infSP[II, 0] = "Address "; 
                    arr_infSP[II++, 1] = "||";

                    stSql = "select RTRIM (ShipAddr1)+' ' +RTRIM ( ShipAddr2)+' ' +RTRIM ( ShipAddr3)+' ' +RTRIM (ShipAddr4) +' ' +RTRIM (ShipAddr5)+' ' +RTRIM (PostalCode) as ADRS from SorMasterRep where SorMasterRep.InvoiceNumber='" + 
                        _inv + "'";
                    string res = MainMDI.Find_One_Field_SYSPRO(stSql);
                    arr_infSP[II, 0] = "     Shipping "; 
                    arr_infSP[II++, 1] = res;

                    stSql = "select RTRIM (SoldToAddr1)+' ' +RTRIM ( SoldToAddr2)+' ' +RTRIM ( SoldToAddr3)+' ' +RTRIM (SoldToAddr4) +' ' +RTRIM (SoldToAddr5)+' ' +RTRIM (ShipPostalCode) from ArCustomer where Customer='" + 
                        Oreadr["CustCode"].ToString() + "'";
                    res = MainMDI.Find_One_Field_SYSPRO(stSql);
                    arr_infSP[II, 0] = "     Billing"; 
                    arr_infSP[II++, 1] = res;

                    //stsql = " " + oreadr["customer"].tostring() + "'";
                    res = MainMDI.VIDE; //MainMDI.find_one_field_syspro(stsql);
                    arr_infSP[II, 0] = "     Quoting "; 
                    arr_infSP[II++, 1] = res;

                    arr_infSP[II, 0] = "Sales Person "; 
                    arr_infSP[II++, 1] = Oreadr["Name"].ToString();
                }
            }
            OConn.Close();
            fill_dgInfoSP();
        }

        string NoCode(string desc)
        {
            int ipos = desc.IndexOf("[");
            if (ipos > -1)
            {
                int ipos2 = desc.IndexOf("]", ipos);
                if ((ipos2 > -1) && (ipos2 - ipos) == 15) return desc.Substring(0, ipos);
            }
            return desc;
        }

        void init_arrInfo(ref string[,] arr)
        {
            for (int i = 0; i < arr.Length / 2; i++) 
            { 
                arr[i, 0] = ""; 
                arr[i, 1] = ""; 
            }
        }

        void Fill_lvINV_PGC(string _Prj, string _Rev)
        {
            double ddAA = 0, ddBB = 0, ddCC = 0, ddDD = 0;
            init_arrInfo(ref arr_infPGC);

            //_Rev = "00RV";
            string CAT = "?ABCD";
            if (_Rev.Length == 4) _Rev = _Rev.Substring(0, 2) + "-(" + _Rev.Substring(2, 2) + ")";
            //string stSql = "SELECT *   FROM [Orig_PSM_FDB].[dbo].[PSM_R_Rev] where RID='" + _Prj + "' and RRev_Name='" + _Rev + "' ";
            string stSql = " SELECT  PSM_R_Rev.IRRevID, PSM_R_Rev.RRev_Name, PSM_R_Rev.RID, PSM_R_Rev.shiped, PSM_R_Rev.AGency, " +
                "PSM_Q_Details.Mult,LTRIM(PSM_Q_Details.[Desc]) as [DESC], PSM_Q_Details.Qty, PSM_Q_Details.Xch_Mult, PSM_Q_Details.Uprice, " +
                "PSM_Q_Details.Ext, PSM_R_Detail.PrimaxSN , PSM_R_Rev.Custm_PO , PSM_R_Rev.cpnyID" +
                " FROM PSM_R_Rev INNER JOIN PSM_R_Detail ON PSM_R_Rev.IRRevID = PSM_R_Detail.IRRev_LID" +
                "   INNER JOIN PSM_Q_Details ON PSM_R_Detail.Qdet_LID = PSM_Q_Details.Detail_LID " +
                " WHERE (PSM_R_Rev.shiped<>'C' ) AND (PSM_R_Rev.shiped<>'D' ) AND (PSM_R_Rev.RID = '" + _Prj + "')" +
                "   AND (PSM_R_Rev.RRev_Name = '" + _Rev + "') AND (PSM_Q_Details.Ext <> 0) ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            //lvINV_PGC.Items.Clear();
            int II = 0;
            while (Oreadr.Read())
            {
                if (arr_infPGC[0, 0] == "")
                {
                    //fill quote adrs in arrSP
                    string _stSql = " SELECT  PSM_Q_IGen.Quot_Req +':   ' +   PSM_COMPANY.M_Adrs " +
                        " FROM PSM_R_Rev INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid" +
                        "   INNER JOIN  PSM_COMPANY ON PSM_Q_IGen.Quot_Req = PSM_COMPANY.Cpny_Name1 " +
                        " WHERE (PSM_R_Rev.shiped <> 'C') AND (PSM_R_Rev.shiped <> 'D') AND (PSM_R_Rev.RID = '" + _Prj + "')" +
                        "   AND (PSM_R_Rev.RRev_Name = '" + _Rev + "')";
                    arr_infSP[3, 1] = MainMDI.Find_One_Field(_stSql);
                    fill_dgInfoSP();

                    arr_infPGC[II, 0] = "CUSTOMER "; 
                    arr_infPGC[II++, 1] = "";

                    arr_infPGC[II, 0] = "Project# "; 
                    arr_infPGC[II++, 1] = Oreadr["RID"].ToString();

                    arr_infPGC[II, 0] = "Revision "; 
                    arr_infPGC[II++, 1] = Oreadr["RRev_Name"].ToString();
                    
                    string _mltpl = "", _act = "", cpnyName = "";
                    stSql = "SELECT   'CAN=' + cast (PSM_CmpnyTYPE.multpl1 as nvarchar) + '  /  US=' +cast (PSM_CmpnyTYPE.multpl1_US as nvarchar)   as t1, PSM_CmpnyTYPE.CpnyType, Cpny_Name1 FROM  PSM_COMPANY INNER JOIN  PSM_CmpnyTYPE ON PSM_COMPANY.CustomerType = PSM_CmpnyTYPE.CpnyType_ID where PSM_COMPANY.Cpny_ID =" + 
                        Oreadr["cpnyID"].ToString();
                    MainMDI.Find_2_Field(stSql, ref _mltpl, ref _act, ref cpnyName);
                    arr_infPGC[0, 1] = cpnyName;
                    arr_infPGC[II, 0] = "Activty, Mltpl. "; 
                    arr_infPGC[II++, 1] = _act + ",  " + _mltpl;
                    //arr_infPGC[II, 0] = "Multipl. "; arr_infPGC[II++, 1] = _mltpl;

                    arr_infPGC[II, 0] = "Customer PO#"; 
                    arr_infPGC[II++, 1] = Oreadr["Custm_PO"].ToString();

                    arr_infPGC[II, 0] = "Agencies"; 
                    arr_infPGC[II++, 1] = "||"; //(Oreadr["AGency"].ToString() == "1") ? "Yes" : "No";
                    string desti = MainMDI.VIDE, inf = MainMDI.VIDE, eng = MainMDI.VIDE, PO = MainMDI.VIDE;

                    if (Oreadr["AGency"].ToString() == "1")
                    {
                        //string[] arrVal= { "", "", "", "", "", "" };
                        //stSql = "SELECT [AG_ALL] ,[AG_Dest] ,[AG_Infl]  ,[AG_Eng]   ,[AG_PO]  FROM [Orig_PSM_FDB].[dbo].[PSM_R_REV_agCMS]   where A_CMS_REVID=" + Oreadr["IRRevID"].ToString();

                        string[] arr_ag = new string[6];
                        string Stsql = "SELECT [AG_ALL] ,[AG_Dest] ,[AG_Infl]  ,[AG_Eng]   ,[AG_PO]  FROM [Orig_PSM_FDB].[dbo].[PSM_R_REV_agCMS]   where A_CMS_REVID=" + 
                            Oreadr["IRRevID"].ToString();
                        string res = MainMDI.Find_arr_Fields(Stsql, arr_ag);
                        if (res != MainMDI.VIDE)
                        {
                            desti = arr_ag[1];
                            inf = arr_ag[2];
                            eng = arr_ag[3];
                            PO = arr_ag[4];
                        }
                    }
                    arr_infPGC[II, 0] = "      Destination"; arr_infPGC[II++, 1] = desti;
                    arr_infPGC[II, 0] = "      Influence"; arr_infPGC[II++, 1] = inf;
                    arr_infPGC[II, 0] = "      Engineering"; arr_infPGC[II++, 1] = eng;
                    arr_infPGC[II, 0] = "      PO"; arr_infPGC[II++, 1] = PO;
                }
                //string Ifnv = MainMDI.A00(Oreadr[0].ToString(), 6);
                ListViewItem lv = lvINV_PGC.Items.Add(Oreadr[0].ToString());
                lv.SubItems.Add(NoCode(Oreadr["Desc"].ToString().TrimEnd())); //itm

                int catNDX = (int)(Tools.Conv_Dbl(Oreadr["Xch_Mult"].ToString()));
                string cat = (catNDX > 0 && catNDX < 5) ? CAT[catNDX].ToString() : "?";
                lv.SubItems.Add(cat); //cat
                lv.SubItems.Add(Oreadr["Mult"].ToString());
                lv.SubItems.Add(Oreadr["Qty"].ToString());
                lv.SubItems.Add(Oreadr["Uprice"].ToString());
                lv.SubItems.Add(Oreadr["Ext"].ToString());
                lv.SubItems.Add(curr_X);

                double ddCAD = Math.Round(Tools.Conv_Dbl(Oreadr["Ext"].ToString()) * Tools.Conv_Dbl(curr_X), 2);
                lv.SubItems.Add(ddCAD.ToString());

                lv.SubItems.Add(Oreadr["PrimaxSN"].ToString());

                //lv.SubItems[8].Text = curr_X;

                switch (catNDX)
                {
                    case 1:
                        ddAA += Tools.Conv_Dbl(lv.SubItems[8].Text);
                        break;
                    case 2:
                        ddBB += Tools.Conv_Dbl(lv.SubItems[8].Text);
                        break;
                    case 3:
                        ddCC += Tools.Conv_Dbl(lv.SubItems[8].Text);
                        break;
                    case 4:
                        ddDD += Tools.Conv_Dbl(lv.SubItems[8].Text);
                        break;
                }
            }
            OConn.Close();

            if (lvINV_PGC.Items.Count > 0)
            {
                arr_infPGC[II, 0] = "Category Total "; 
                arr_infPGC[II++, 1] = "||";

                arr_infPGC[II, 0] = "     A         "; 
                arr_infPGC[II++, 1] = ddAA.ToString();

                arr_infPGC[II, 0] = "     B         "; 
                arr_infPGC[II++, 1] = ddBB.ToString();

                arr_infPGC[II, 0] = "     C         "; 
                arr_infPGC[II++, 1] = ddCC.ToString();

                arr_infPGC[II, 0] = "     D         "; 
                arr_infPGC[II++, 1] = ddDD.ToString();

                //################ fill quote adrs II = 3
                //fill PGC price, Sales price, agents price OVRG
                fill_dgPGC();
            }
            else lERROR.Visible = true;
            //select * from SorMasterRep where SorMasterRep.InvoiceNumber='011250'   shipAdress
            //select * from ArCustomer    Bill to adress
            //
        }

        bool RevHasAgencies(string _Prj_Rev)
        {
            string _prj = "", _Rev = "";
            getPRJ_REV(_Prj_Rev, ref _prj, ref _Rev);
            if (_Rev.Length == 4) _Rev = _Rev.Substring(0, 2) + "-(" + _Rev.Substring(2, 2) + ")";
            //string stSql = "SELECT *   FROM [Orig_PSM_FDB].[dbo].[PSM_R_Rev] where RID='" + _Prj + "' and RRev_Name='" + _Rev + "' ";
            string stSql = "SELECT [AGency]  FROM [Orig_PSM_FDB].[dbo].[PSM_R_Rev] WHERE    (PSM_R_Rev.shiped<>'C' ) AND (PSM_R_Rev.shiped<>'D' ) and (PSM_R_Rev.RID = '" + 
                _prj + "') AND (PSM_R_Rev.RRev_Name = '" + _Rev + "') ";
            string res = MainMDI.Find_One_Field(stSql);
            return res == "1";
        }

        //########

        //SELECT DISTINCT u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.Project,SorMaster.OrderDate
        //FROM            u_SalCommissionsPrimax INNER JOIN
        //                         SorMaster ON u_SalCommissionsPrimax.SalesOrder = SorMaster.SalesOrder
        //WHERE        (SUBSTRING(u_SalCommissionsPrimax.Invoice, 1, 1) <> '7') AND (LOWER(u_SalCommissionsPrimax.Project) <> 'cigentec') AND 
        //                         (u_SalCommissionsPrimax.PriceCAD > 0) AND (SorMaster.OrderDate > CONVERT(smalldatetime, '05/01/2016', 103))
        //ORDER BY  u_SalCommissionsPrimax.Invoice

        //#############
        private void fill_TVInv()
        {
            tvINV.Nodes.Clear();
            this.Cursor = Cursors.WaitCursor;
            string cond = "";
            txInv.Text = (txInv.Text.Length < MainMDI.SYSPRO_INV_len) ? MainMDI.A00(txInv.Text, MainMDI.SYSPRO_INV_len) : txInv.Text;

            //string cond = (opINV.Checked) ? " CAST(u_SalCommissionsPrimax.Invoice AS decimal) > " + Tools.Conv_Dbl(txInv.Text) : " ArInvoice.InvoiceDate >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND ArInvoice.InvoiceDate <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString());
            if (pnlPRJ.Visible) cond = (txPrj.Text != "") ? "(u_SalCommissionsPrimax.Project LIKE '%" + txPrj.Text + "%') " : "";
            else
            {
                if (pnlINV.Visible) cond = (txInv.Text != "" && txInv.Text != "000000000000000") ? 
                        " u_SalCommissionsPrimax.Invoice='" + txInv.Text + "'" : 
                        " ArInvoice.InvoiceDate >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND ArInvoice.InvoiceDate <=" + 
                        MainMDI.SSV_date(dpTo.Value.ToShortDateString());
                else if (pnlDate.Visible) cond = " ArInvoice.InvoiceDate >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + 
                        "  AND ArInvoice.InvoiceDate <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString());
            }
            if (cond == "") MessageBox.Show("ERROR ,  Conditions are NULL..............");
            else
            {
                string stSql = " SELECT distinct u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.Project" +
                    " FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson" +
                    "   INNER JOIN ArInvoice ON u_SalCommissionsPrimax.Invoice = ArInvoice.Invoice AND (u_SalCommissionsPrimax.PriceCAD>0) " +
                    " WHERE (SUBSTRING(u_SalCommissionsPrimax.Invoice, 1, 1) <> '7') AND (" + cond + ") AND (ArInvoice.InvoiceBal1 = 0)" +
                    "   and (lower([Project])<>'cigentec') AND (SUBSTRING([Project],len([Project])-1,2)='RV')" +
                    " ORDER BY u_SalCommissionsPrimax.Invoice ";

                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    string lin = Oreadr["Invoice"].ToString().TrimEnd() + " / " + Oreadr["Project"].ToString().TrimEnd();
                    //tvINV.Nodes.Add(Oreadr["Invoice"].ToString() + " / " + Oreadr["Project"].ToString());
                    tvINV.Nodes.Add(lin);
                    if (!RevHasAgencies(lin)) tvINV.Nodes[tvINV.Nodes.Count - 1].ForeColor = Color.Black;
                }
                OConn.Close();
                this.Cursor = Cursors.Default;
            }
        }

        //099999 / 5677_01RV pos = 6 pos2 = 13 len = 18

        private void fill_TVInv_OLDOK()
        {
            tvINV.Nodes.Clear();
            this.Cursor = Cursors.WaitCursor;
            //string cond = (opINV.Checked) ? " CAST(u_SalCommissionsPrimax.Invoice AS decimal) > " + Tools.Conv_Dbl(txInv.Text) : " ArInvoice.InvoiceDate >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND ArInvoice.InvoiceDate <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString());
            string cond = (txInv.Text != "") ? 
                " u_SalCommissionsPrimax.Invoice='" + txInv.Text + "'" : 
                " ArInvoice.InvoiceDate >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND ArInvoice.InvoiceDate <=" + 
                MainMDI.SSV_date(dpTo.Value.ToShortDateString());

            string stSql = " SELECT distinct u_SalCommissionsPrimax.Invoice, u_SalCommissionsPrimax.Project" +
                " FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson" +
                "   INNER JOIN ArInvoice ON u_SalCommissionsPrimax.Invoice = ArInvoice.Invoice AND (u_SalCommissionsPrimax.PriceCAD>0)" +
                " WHERE (SUBSTRING(u_SalCommissionsPrimax.Invoice, 1, 1) <> '7') AND (" + cond + ")" +
                " AND (ArInvoice.InvoiceBal1 = 0) and (lower([Project])<>'cigentec') AND (SUBSTRING([Project],len([Project])-1,2)='RV')" +
                " ORDER BY u_SalCommissionsPrimax.Invoice ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                string lin = Oreadr["Invoice"].ToString().TrimEnd() + " / " + Oreadr["Project"].ToString().TrimEnd();
                //tvINV.Nodes.Add(Oreadr["Invoice"].ToString() + " / " + Oreadr["Project"].ToString());
                tvINV.Nodes.Add(lin);
                if (!RevHasAgencies(lin)) tvINV.Nodes[tvINV.Nodes.Count - 1].ForeColor = Color.Black;
            }
            OConn.Close();
            this.Cursor = Cursors.Default;
        }

        void getPRJ_REV(string INV_PRJ, ref string _Prj, ref string _Rev)
        {
            _Prj = ""; _Rev = "";
            int pos = INV_PRJ.IndexOf(" / ");
            if (pos != -1)
            {
                int pos2 = INV_PRJ.IndexOf("_", pos + 3);
                if (pos2 != -1)
                {
                    _Prj = INV_PRJ.Substring(pos + 3, pos2 - pos - 3);
                    //_Rev = INV_PRJ.Substring(pos2 + 1, INV_PRJ.Length - pos2 - 1);
                    _Rev = INV_PRJ.Substring(pos2 + 1, 4);
                }
                else _Prj = INV_PRJ.Substring(pos + 3, 4);
            }
            //_Rev = "00RV";
        }

        private void lvCMS_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //MessageBox.Show(lvINV_SP.Columns[e.Column].Width.ToString());
        }

        private void tvINV_AfterSelect(object sender, TreeViewEventArgs e)
        {
            Select_TVR();
        }

        void clearALL()
        {
            dg_InfoSP.Rows.Clear();
            dg_Info.Rows.Clear();
            lvINV_SP.Items.Clear();
            lvINV_PGC.Items.Clear();
        }

        private void Select_TVR()
        {
            lERROR.Visible = false;
            dg_Info.Rows.Clear();
            curr_X = "";
            lcurTRndx.Text = tvINV.SelectedNode.Index.ToString();
            tvINV.SelectedNode.BackColor = Color.Yellow;
            if (OLDTVTR_Selndx != -1 && OLDTVTR_Selndx < tvINV.Nodes.Count) tvINV.Nodes[OLDTVTR_Selndx].BackColor = Color.AliceBlue;
            lcurNm.Text = tvINV.SelectedNode.Text;
            TRndxDel.Text = tvINV.SelectedNode.Index.ToString();
            string prj = "", Rev = "";
            getPRJ_REV(lcurNm.Text, ref prj, ref Rev);

            Fill_lvCMS(lcurNm.Text.Substring(0, 16));

            if (Tools.Conv_Dbl(prj) > 1000 && Rev != "") Fill_lvINV_PGC(prj, Rev);
            OLDTVTR_Selndx = (lcurNm.Text == "") ? -1 : Convert.ToInt32(lcurTRndx.Text);
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //arr_infos[0, 0] = "Customer PO#"; arr_infos[0, 1] = "";
            //arr_infos[1, 0] = "A Category"; arr_infos[1, 1] = "";
            //arr_infos[2, 0] = "B   ...   "; arr_infos[2, 1] = "";
            //arr_infos[3, 0] = "C   ...   "; arr_infos[3, 1] = "";
            //arr_infos[4, 0] = "D   ...   "; arr_infos[4, 1] = "";
            //fill_dgInfo();
        }

        void fill_dgPGC()
        {
            dg_Info.Rows.Clear();
            for (int i = 0; i < arr_infPGC.Length / 2; i++) //arr_dgInfo.Length / 2)
            {
                if (arr_infPGC[i, 1] != "")
                {
                    DataGridViewRow line = new DataGridViewRow();
                    line.CreateCells(dg_Info);
                    line.Cells[0].Value = arr_infPGC[i, 0];
                    if (arr_infPGC[i, 1] == "||")
                    {
                        line.Cells[1].Value = " ";
                        line.DefaultCellStyle.BackColor = Color.Green;
                        line.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        line.Cells[1].Value = arr_infPGC[i, 1];
                        if (i == 0) line.DefaultCellStyle.BackColor = Color.Moccasin;
                        line.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    dg_Info.Rows.Add(line);
                    //dg_Info.Rows[dg_Info.Rows.Count - 1].ba
                }
                else i = arr_infPGC.Length / 2;
            }
        }

        void fill_dgInfoSP()
        {
            dg_InfoSP.Rows.Clear();
            for (int i = 0; i < arr_infSP.Length / 2; i++) //arr_dgInfo.Length / 2)
            {
                if (arr_infSP[i, 1] != "")
                {
                    DataGridViewRow line = new DataGridViewRow();
                    line.CreateCells(dg_InfoSP);
                    line.Cells[0].Value = arr_infSP[i, 0];
                    if (arr_infSP[i, 1] == "||")
                    {
                        line.Cells[1].Value = " ";
                        line.DefaultCellStyle.BackColor = Color.Green;
                        line.DefaultCellStyle.ForeColor = Color.White;
                    }
                    else
                    {
                        line.Cells[1].Value = arr_infSP[i, 1];
                        if (i == 0) line.DefaultCellStyle.BackColor = Color.Moccasin;
                        line.DefaultCellStyle.ForeColor = Color.Black;
                    }
                    dg_InfoSP.Rows.Add(line);
                    //dg_Info.Rows[dg_Info.Rows.Count - 1].ba
                }
                else i = arr_infSP.Length / 2;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(InfoMAchine());
        }

        string InfoMAchine()
        {
            string stout = "";
            try
            {
                ManagementObjectSearcher searcher = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_Processor");

                foreach (ManagementObject queryObj in searcher.Get())
                {
                    stout += "Win32_Processor instance" + " \n";
                    stout += "Architecture: " + queryObj["Architecture"] + " \n";
                    stout += "Caption: " + queryObj["Caption"] + " \n";
                    stout += "Family: " + queryObj["Family"] + " \n";
                    stout += "ProcessorId: " + queryObj["ProcessorId"] + " \n";
                }
                stout += "============================\n";

                ManagementObjectSearcher disk = new ManagementObjectSearcher("root\\CIMV2", "SELECT * FROM Win32_LogicalDisk");

                //foreach (ManagementObject mo in disk.Get())
                foreach (ManagementObject mo in disk.Get()) stout += mo.ToString() + "\n";
            }
            catch (ManagementException e)
            {
                MessageBox.Show("An error occurred while querying for WMI data: " + e.Message);
            }
            return stout;
        }

        private void lERROR_Click(object sender, EventArgs e)
        {

        }

        private void lvINV_PGC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void grpSrch_Enter(object sender, EventArgs e)
        {

        }

        private void picListALL_Click(object sender, EventArgs e)
        {
            clearALL();
            fill_TVInv();
            if (tvINV.Nodes.Count > 0) tvINV.SelectedNode = tvINV.Nodes[0];
        }

        private void dg_Info_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void lvINV_SP_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void opINV_CheckedChanged(object sender, EventArgs e)
        {
            pnlDate.Visible = false;
            pnlINV.Visible = true;
            pnlPRJ.Visible = false;
            pnlAG.Visible = false;
        }

        private void optDat_CheckedChanged(object sender, EventArgs e)
        {
            pnlDate.Visible = true;
            pnlINV.Visible = false;
            pnlPRJ.Visible = false;
            pnlAG.Visible = false;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void CMS_Agents_Load(object sender, EventArgs e)
        {
            fill_cbAGent_SYSPRO("C");
        }

        private void fill_cbAGent_SYSPRO(string branch)
        {
            string stSql = "SELECT   Name FROM  dbo.SalSalesperson where SUBSTRING (Salesperson,1,1)='A' and Branch ='" + branch + 
                "1' order by Name ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                stSql = Oreadr[0].ToString(); //no last name for agency..... //+ " " + Oreadr[1].ToString();
                cbAD.Items.Add(stSql);
            }
            OConn.Close();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            pnlDate.Visible = false;
            pnlINV.Visible = false;
            pnlPRJ.Visible = false;
            pnlAG.Visible = true;
        }

        private void cbchoix_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cbchoix.Text)
            {
                case "Invoice #":
                    pnlDate.Visible = false;
                    pnlINV.Visible = true;
                    pnlPRJ.Visible = false;
                    pnlAG.Visible = false;
                    break;
                case "Invoice Date":
                    pnlDate.Visible = true;
                    pnlINV.Visible = false;
                    pnlPRJ.Visible = false;
                    pnlAG.Visible = false;
                    break;
                case "Project #":
                    pnlDate.Visible = false;
                    pnlINV.Visible = false;
                    pnlPRJ.Visible = true;
                    pnlAG.Visible = false;
                    break;
                case "Agency Name":
                    pnlDate.Visible = false;
                    pnlINV.Visible = false;
                    pnlPRJ.Visible = false;
                    pnlAG.Visible = true;
                    break;
                case "Current CMS period":
                    pnlDate.Visible = true;
                    pnlINV.Visible = false;
                    pnlPRJ.Visible = false;
                    pnlAG.Visible = false;
                    fill_DP_FROM_TO();
                    break;
            }
        }

        void fill_DP_FROM_TO()
        {
            string MM = "", YY = "";
            MainMDI.Find_2_Field("SELECT [F2] ,[F3]  FROM [Orig_PSM_FDB].[dbo].[PSM_C_GConfig] where F1_code='CMS_MMYY'", ref MM, ref YY);
            if (MM != MainMDI.VIDE)
            {
                MM = MM.Substring(0, 2);
                if (Tools.Conv_Dbl(MM) == 12)
                {
                    dpFrom.Value = DateTime.ParseExact("01/01/20" + YY, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                    dpTo.Value = DateTime.ParseExact("31/01/20" + YY, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
                else
                {
                    double m = Tools.Conv_Dbl(MM) + 1;
                    MM = MainMDI.A00(m.ToString(), 2);

                    double a = Tools.Conv_Dbl(YY) - 1;
                    YY = a.ToString();

                    //MM = MainMDI.A00(m.ToString());

                    string dat = "01/" + MM + "/" + YY;

                    dpFrom.Value = DateTime.ParseExact(dat, "dd/MM/yyyy", CultureInfo.InvariantCulture);

                    dat = "31/" + MM + "/" + YY;
                    dpTo.Value = DateTime.ParseExact(dat, "dd/MM/yyyy", CultureInfo.InvariantCulture);
                }
            }
        }

        //void fill_Invoices()
        //{
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
        //}

        //void fill_After()
        //{
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
                    //if (!btnProc.Visible) btnProc.Visible = true;
                //}
            //}
        //}

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
    }
}