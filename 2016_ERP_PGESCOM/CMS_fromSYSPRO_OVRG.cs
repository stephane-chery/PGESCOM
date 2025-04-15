using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq ;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using EAHLibs;

namespace PGESCOM
{
    public partial class CMS_fromSYSPRO_OVRG : Form
    {
        int NBREC = 0, curr_ndx = -1, ModifYes = 284, ModifNo = 173;
        string Iqid = "", CpnyName ="", QNB ="";
        	private Lib1 Tools = new Lib1();
        public CMS_fromSYSPRO_OVRG()
        {
            InitializeComponent();


           
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string Stsql = "  SELECT DISTINCT dbo_v_OverageCommissions.Project FROM dbo_v_OverageCommissions  , dbo_v_OverageCommissions.DateLastInvPrt" +
                          "  WHERE (((dbo_v_OverageCommissions.Project) Not In (select distinct RID from HK_Overage_Sales ))) ORDER BY dbo_v_OverageCommissions.Project";
      



            //cacul total
            Stsql =" SELECT DISTINCT dbo_v_OverageCommissions.* FROM dbo_v_OverageCommissions WHERE (((dbo_v_OverageCommissions.Project)='4573') AND ((dbo_v_OverageCommissions.DateLastInvPrt)=#12/16/2011#)) ";


        }

        private void Get_PRJ_Ovrg(string RID, string DateSP)
        {
            OleDbConnection OConn = null;
            OleDbCommand Ocmd = null;
            OleDbDataReader Oreadr = null;
            string[] arr_HK =new string[22];
            DateSP = DateSP.Substring(0, 10); 

        //    string stSql = " SELECT DISTINCT dbo_v_OverageCommissions.* FROM dbo_v_OverageCommissions WHERE (((dbo_v_OverageCommissions.Project)='" + RID + "') AND ((dbo_v_OverageCommissions.DateLastInvPrt)=#" + DateSP + "#))  ORDER BY dbo_v_OverageCommissions.SalesOrderLine  ";
            string stSql = " SELECT DISTINCT dbo_v_OverageCommissions.* FROM dbo_v_OverageCommissions WHERE (((dbo_v_OverageCommissions.Project)='" + RID + "') AND ((CDATE(dbo_v_OverageCommissions.DateLastInvPrt))='" + DateSP + "'))  ORDER BY dbo_v_OverageCommissions.SalesOrderLine  ";
           
           
            try
            {
                OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                txSQL.Text = stSql; 

                Oreadr = Ocmd.ExecuteReader();
                string Old_Sol = "", New_Sol="";
                while (Oreadr.Read())
                {
                    New_Sol = Oreadr [9].ToString ();
                    if (Old_Sol != New_Sol)
                    {
                        if (Old_Sol != "") add_Ovrg(arr_HK);

                        arr_HK[0] = Oreadr[1].ToString(); //[MM_fscl]
                        arr_HK[1] = Oreadr[2].ToString();//,[YY_fscl]

                        string res = MainMDI.Find_One_Field(" SELECT PSM_Q_IGen.Quote_ID FROM PSM_R_Rev INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid WHERE  PSM_R_Rev.RID =" + Oreadr[6].ToString());
                        if (res == MainMDI.VIDE) res = "0000";//?????"MessageBox.Show ("ERROR Quote# for PRJ#:" + Oreadr[6].ToString());  
                        arr_HK[2] = res;//   ,[QuoteID]

                        arr_HK[3] = Oreadr[0].ToString();//,[DateLastInvPrt]
                        arr_HK[4] = Oreadr[6].ToString();//,[RID]
                        arr_HK[5] = Oreadr[3].ToString();//,[CustomerID]
                        arr_HK[6] = Oreadr[7].ToString();// ,[InvID]
                        arr_HK[7] = Oreadr[5].ToString();//,[Currncy]
                        arr_HK[8] = Oreadr[8].ToString();//,[SO]
                        arr_HK[9] = Oreadr[9].ToString();//,[SOLine]
                        arr_HK[10] = Oreadr[10].ToString();//,[STKCode]
                        arr_HK[11] = Oreadr[15].ToString();//,[UserDef]
                        arr_HK[12] = Oreadr[16].ToString();//,[Salesperson]
                        arr_HK[13] = Oreadr[17].ToString();//,[IntSalesperson]
                        arr_HK[14] = Oreadr[12].ToString();//,[Old_Overage]
                        arr_HK[15] = Oreadr[13].ToString();// ,[Old_Overage_CAD]
                        arr_HK[16] = Math.Round(Tools.Conv_Dbl(Oreadr[13].ToString()) / 2, 2).ToString();// [PRIMAX_OLD]

                    }

                    switch (Oreadr [18].ToString ().TrimEnd ())
                    {
                        case "Mona Dimassi":
                            arr_HK [17]=Oreadr [20].ToString ();
                            break;
                        case "Claude Fouche":
                            arr_HK [18]=Oreadr [20].ToString ();
                            break;
                        case "Yves Lavoie":
                            arr_HK [20]=Oreadr [20].ToString ();
                            break;
                        case "Benoit Cimon":
                            arr_HK [19]=Oreadr [20].ToString ();
                            break;
                        case "Steven Monk":
                            arr_HK [21]=Oreadr [20].ToString ();
                            break;
                    }

                   Old_Sol = New_Sol;
  
                }
                add_Ovrg(arr_HK);
                //    cbSales.Text = cbSales.Items[0].ToString();
                //  cbSales.Text = PGCUsr_SalesName(MainMDI.User.ToLower ());
            }


            catch (Exception ex)
            {
                MessageBox.Show("Get_PRJ_ORG " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSql);
            }


            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }




        }


        void Import_ALLnew_Ovrgoldd()
        {

            OleDbConnection OConn = null;
            OleDbCommand Ocmd = null;
            OleDbDataReader Oreadr = null;

            //       string stSql = (lSalesN.Text == "Inside Sales Names") ? "SELECT [HK_CMS_SALESin].[Expr1] FROM HK_CMS_SALESin ORDER BY [Expr1]" : " SELECT DISTINCT dbo_SalSalesperson.Name, dbo_SalSalesperson.Salesperson " +
            //                                                                                                                                         " FROM dbo_u_SalCommissionsPrimax INNER JOIN dbo_SalSalesperson ON (dbo_u_SalCommissionsPrimax.Salesperson = dbo_SalSalesperson.Salesperson) AND (dbo_u_SalCommissionsPrimax.Branch = dbo_SalSalesperson.Branch) " +
            //                                                                                                                                          " WHERE (((Left([dbo_SalSalesperson]![Salesperson],1))='S' Or (Left([dbo_SalSalesperson]![Salesperson],1))='H')) " +
            string stSql= "  SELECT DISTINCT v_OverageCommissions.Project, v_OverageCommissions.DateLastInvPrt FROM v_OverageCommissions  " +
                          "  WHERE (((v_OverageCommissions.Project) Not In (select distinct RID from HK_Overage_Sales ))) ORDER BY v_OverageCommissions.Project, v_OverageCommissions.DateLastInvPrt";
      
           
            try
            {
                OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {

                    RID.Text = Oreadr[0].ToString() + " / " + Oreadr[1].ToString();
                    RID.Refresh();
           //         if (MainMDI.Find_One_Field("select  Lid from HK_Overage_Sales where RID=" + Oreadr[0].ToString() + " and CDATE(DateLastInvPrt)= '" + Oreadr[1].ToString().Substring(0, 10) + "' ") == MainMDI.VIDE)
                    if (MainMDI.Find_One_Field("select  Lid from HK_Overages_Sales where RID=" + Oreadr[0].ToString() + " and DateLastInvPrt= CONVERT(DATETIME,'" + Oreadr[1].ToString() + "',103) ") == MainMDI.VIDE)
                    {

                       Get_PRJ_Ovrg  ( Oreadr[0].ToString() ,Oreadr[1].ToString());

                    }





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


        void Import_ALLnew_Ovrg()
        {

            OleDbConnection OConn = null;
            OleDbCommand Ocmd = null;
            OleDbDataReader Oreadr = null;

            //       string stSql = (lSalesN.Text == "Inside Sales Names") ? "SELECT [HK_CMS_SALESin].[Expr1] FROM HK_CMS_SALESin ORDER BY [Expr1]" : " SELECT DISTINCT dbo_SalSalesperson.Name, dbo_SalSalesperson.Salesperson " +
            //                                                                                                                                         " FROM dbo_u_SalCommissionsPrimax INNER JOIN dbo_SalSalesperson ON (dbo_u_SalCommissionsPrimax.Salesperson = dbo_SalSalesperson.Salesperson) AND (dbo_u_SalCommissionsPrimax.Branch = dbo_SalSalesperson.Branch) " +
            //                                                                                                                                          " WHERE (((Left([dbo_SalSalesperson]![Salesperson],1))='S' Or (Left([dbo_SalSalesperson]![Salesperson],1))='H')) " +
            string stSql = "  SELECT DISTINCT dbo_v_OverageCommissions.Project, dbo_v_OverageCommissions.DateLastInvPrt FROM dbo_v_OverageCommissions  " +
                          "  WHERE (((dbo_v_OverageCommissions.Project) Not In (select distinct RID from HK_Overage_Sales ))) ORDER BY dbo_v_OverageCommissions.Project, dbo_v_OverageCommissions.DateLastInvPrt";


            try
            {
                OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {

                    RID.Text = Oreadr[0].ToString() + " / " + Oreadr[1].ToString();
                    RID.Refresh();
                    //         if (MainMDI.Find_One_Field("select  Lid from HK_Overage_Sales where RID=" + Oreadr[0].ToString() + " and CDATE(DateLastInvPrt)= '" + Oreadr[1].ToString().Substring(0, 10) + "' ") == MainMDI.VIDE)
                    if (MainMDI.Find_One_Field("select  Lid from HK_Overages_Sales where RID=" + Oreadr[0].ToString() + " and DateLastInvPrt= CONVERT(DATETIME,'" + Oreadr[1].ToString() + "',103) ") == MainMDI.VIDE)
                    {

                        Get_PRJ_Ovrg(Oreadr[0].ToString(), Oreadr[1].ToString());

                    }





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

        /*
        void fill_CBsales()
        {

            OleDbConnection OConn = null;
            OleDbCommand Ocmd = null;
            OleDbDataReader Oreadr = null;

     //       string stSql = (lSalesN.Text == "Inside Sales Names") ? "SELECT [HK_CMS_SALESin].[Expr1] FROM HK_CMS_SALESin ORDER BY [Expr1]" : " SELECT DISTINCT dbo_SalSalesperson.Name, dbo_SalSalesperson.Salesperson " +
    //                                                                                                                                         " FROM dbo_u_SalCommissionsPrimax INNER JOIN dbo_SalSalesperson ON (dbo_u_SalCommissionsPrimax.Salesperson = dbo_SalSalesperson.Salesperson) AND (dbo_u_SalCommissionsPrimax.Branch = dbo_SalSalesperson.Branch) " +
   //                                                                                                                                          " WHERE (((Left([dbo_SalSalesperson]![Salesperson],1))='S' Or (Left([dbo_SalSalesperson]![Salesperson],1))='H')) " +
        string stSql ="SELECT [HK_CMS_SALESin].[Expr1] FROM HK_CMS_SALESin ORDER BY [Expr1]";


            cbSales.Items.Clear();
            try
            {
                OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    cbSales.Items.Add(Oreadr[0].ToString());
                }
                //    cbSales.Text = cbSales.Items[0].ToString();
                //  cbSales.Text = PGCUsr_SalesName(MainMDI.User.ToLower ());
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

         * 
         * 
         */
          
         
        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CMS_fromSYSPRO_OVRG_Load(object sender, EventArgs e)
        {
            cb_MM.Text = cb_MM.Items[0].ToString();
            cb_YY.Text = cb_YY.Items[0].ToString();

            grpModify.Visible = false;
          //  grpSales.Height = ModifNo ;


        }

        private void picDetailList_Click(object sender, EventArgs e)
        {
            fill_Overages_YYMM();
        }

        void fill_Overages_YYMM()
        {

            string MM = (cb_MM.Text[1] == ' ') ? cb_MM.Text.Substring(0, 1) : cb_MM.Text.Substring(0, 2);
            double TOT = 0;
            decimal TOTSales = 0;
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;



            string stSQL = "select * from dbo.HK_Overages_Sales where YY_fscl =" + cb_YY.Text + " and MM_fscl=" + MM ;
            tmonk.Text = "0";
            tMona.Text = "0";
            tyves.Text = "0";
            tFouche.Text = "0";
            tCimon.Text = "0"; 
 
                
            ed_lvITM.Items.Clear();
            try
            {
                OConn =  new SqlConnection (MainMDI.M_stCon);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSQL;
                Oreadr = Ocmd.ExecuteReader();
                double amt=0;
                while (Oreadr.Read())
                {

                    ListViewItem lv = ed_lvITM.Items.Add(Oreadr[0].ToString());
                    for (int c = 1; c < ed_lvITM.Columns.Count; c++)
                    {
                        string st = Oreadr[c].ToString();

                        switch (c)
                        {
                            case 22:
                                st = (Tools.Conv_Dbl(Oreadr[c].ToString()) == 0) ? Oreadr[c - 1].ToString() : Oreadr[c].ToString();
                                tMona.Text = Math.Round(Tools.Conv_Dbl(st) + Tools.Conv_Dbl(tMona.Text), 2).ToString ();
                            //    this.Refresh();
                                break;
                            case 24:
                                st = (Tools.Conv_Dbl(Oreadr[c].ToString()) == 0) ? Oreadr[c - 1].ToString() : Oreadr[c].ToString();
                                tFouche.Text = Math.Round(Tools.Conv_Dbl(st) + Tools.Conv_Dbl(tFouche.Text), 2).ToString();
                            //    this.Refresh();
                                break;
                            case 26:
                                st = (Tools.Conv_Dbl(Oreadr[c].ToString()) == 0) ? Oreadr[c - 1].ToString() : Oreadr[c].ToString();
                                tCimon.Text = Math.Round(Tools.Conv_Dbl(st) + Tools.Conv_Dbl(tCimon.Text), 2).ToString();
                            //    this.Refresh();
                                break;
                            case 28:
                                st = (Tools.Conv_Dbl(Oreadr[c].ToString()) == 0) ? Oreadr[c - 1].ToString() : Oreadr[c].ToString();
                                tyves.Text = Math.Round(Tools.Conv_Dbl(st) + Tools.Conv_Dbl(tyves.Text), 2).ToString();
                            //    this.Refresh();
                                break;
                            case 30:
                                st = (Tools.Conv_Dbl(Oreadr[c].ToString()) == 0) ? Oreadr[c - 1].ToString() : Oreadr[c].ToString();
                                tmonk.Text = Math.Round(Tools.Conv_Dbl(st) + Tools.Conv_Dbl(tmonk.Text), 2).ToString();
                           //     this.Refresh();
                                break;
                            case 4:
                                st = MainMDI.Eng_date(Oreadr[c].ToString(), "/");
                                break;
                            case 6:
                                //st = MainMDI.Find_One_Field("select Cpny_Name1 from dbo.PSM_COMPANY where Syspro_Code='" + Oreadr[c].ToString() + "'") + "  (" + Oreadr[c].ToString() + ")";
                                st = MainMDI.Find_One_Field("select Cpny_Name1 from dbo.PSM_COMPANY where Syspro_Code='" + Oreadr[c].ToString() + "'");

                                break;
                        }

                        lv.SubItems.Add(st);
                        if (c == 31) FB_item(ed_lvITM.Items.Count - 1, c, 'f', Color.Red);
                        if (c == 15) FB_item(ed_lvITM.Items.Count - 1, c, 'b', Color.Lime );
                        if (c == 17) FB_item(ed_lvITM.Items.Count - 1, c, 'b', Color.Lime); 

                       // {
                     //       lv.UseItemStyleForSubItems = false;
                     //       lv.SubItems[31].ForeColor = Color.Red;
                    //    }
                       
                    }
   
            //        double amt = Tools.Conv_Dbl(Oreadr["1CommissionAmt1"].ToString());
            //        double Irt = Tools.Conv_Dbl(Oreadr["Rate"].ToString()) * 100;
   



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("fill_Overage ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSQL);
            }


            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }

            this.Refresh();
           
        }


        private void FB_item(int x,int y, char fb,Color c)
        {

           ed_lvITM.Items[x].UseItemStyleForSubItems = false;
           if (fb=='f')  ed_lvITM.Items[x].SubItems[y].ForeColor = c;
           else  ed_lvITM.Items[x].SubItems[y].BackColor = c;

        }


        private void button2_Click_1(object sender, EventArgs e)
        {
            
          //  add_Ovrg();


 
          

        }

        private void add_Ovrg(string[] arr_HK )
        {

            try
            {

                using (var myDB = new DC_PGCdbDataContext())
                {
                    var newOvrg = new HK_Overages_Sale()
                    {
                       YY_fscl = Int32.Parse(arr_HK[0]) 
                        ,
                       MM_fscl = Int32.Parse(arr_HK[1])
                        ,
                        QuoteID = Int32.Parse(arr_HK[2])
                        ,
                        DateLastInvPrt = Convert.ToDateTime("#" + arr_HK[3] + "#")
                        ,
                        RID = Int32.Parse(arr_HK[4])
                        ,
                        CustomerID = arr_HK[5]
                        ,
                        InvID = arr_HK[6]
                        ,
                        Currncy = arr_HK[7]
                        ,
                        SO = arr_HK[8]
                        ,
                        SOLine = Int32.Parse(arr_HK[9])
                        ,
                        STKCode = arr_HK[10]
                        ,
                        UserDef = arr_HK[11]
                        ,
                        Salesperson = arr_HK[12]
                        ,
                        IntSalesperson = arr_HK[13]
                        ,
                        Old_Overage = Math.Round(Convert.ToDecimal(arr_HK[14]), 2)
                        ,
                        Old_Overage_CAD = Math.Round(Convert.ToDecimal(arr_HK[15]), 2)
                        ,
                        New_Overage = 0
                        ,
                        New_Overage_CAD = 0
                        ,
                        PRIMAX_OLD = Math.Round(Convert.ToDecimal(arr_HK[16]), 2)
                        ,
                        PRIMAX = 0
                        ,
                        Mona_Dimassi_OLD = Math.Round(Convert.ToDecimal(arr_HK[17]), 2)
                        ,
                        Mona_Dimassi = 0
                        ,
                        Claude_Fouche_OLD = Math.Round(Convert.ToDecimal(arr_HK[18]), 2)
                        ,
                        Claude_Fouche = 0
                        ,
                        Benoit_Cimon_OLD = Math.Round(Convert.ToDecimal(arr_HK[19]), 2)
                        ,
                        Benoit_Cimon = 0
                        ,
                        Yves_Lavoie_OLD = Math.Round(Convert.ToDecimal(arr_HK[20]), 2)
                        ,
                        Yves_Lavoie = 0
                        ,
                        Steven_Monk_OLD = Math.Round(Convert.ToDecimal(arr_HK[21]), 2)
                        ,
                        Steven_Monk = 0
                        ,
                        Cmnt = ""
                        ,
                        Xrate = (Convert.ToDecimal(arr_HK[14])==0)? 0 : Math.Round(Convert.ToDecimal(arr_HK[15]) / Convert.ToDecimal(arr_HK[14]), 8) 

                    };

                    myDB.HK_Overages_Sales.InsertOnSubmit(newOvrg);
                    myDB.SubmitChanges();
                }
            }
          
            catch (Exception ex)
            {
                MessageBox.Show("Get_PRJ_ORG " + ex.Message + "   er#= " + ex.Source);
            }



          
            //   var addFromDb = myDB.HK_Overages_Sales.SingleOrDefault (a=> a.MM_fscl == 6);
             //   if (addFromDb == null ) MessageBox.Show ("INSERT Faileeeeeeeeeeddd...");
            //    else MessageBox.Show ("INSERT is OOOOOOOOOOOOOOOkkkkkk...");



            NBREC++;
           
        }


        private void Update_Ovrg()
        {


                using (var myDB = new DC_PGCdbDataContext())
                {
                    var qry =  from ovrg in myDB.HK_Overages_Sales 
                               where ovrg.LID== Convert.ToInt32 (  ed_lvITM.Items[curr_ndx ].SubItems[0].Text)
                               select ovrg ;
                    foreach (HK_Overages_Sale ovrg in qry )
                    {
                        ovrg.New_Overage = Convert.ToDecimal (  ed_lvITM.Items[curr_ndx ].SubItems[17].Text);
                        ovrg.New_Overage_CAD  = Convert.ToDecimal (  ed_lvITM.Items[curr_ndx ].SubItems[18].Text);
                        ovrg.PRIMAX  = Convert.ToDecimal (  ed_lvITM.Items[curr_ndx ].SubItems[20].Text);
                        ovrg.Mona_Dimassi  = Convert.ToDecimal (  ed_lvITM.Items[curr_ndx ].SubItems[22].Text);
                        ovrg.Claude_Fouche  = Convert.ToDecimal (  ed_lvITM.Items[curr_ndx ].SubItems[24].Text);
                        ovrg.Benoit_Cimon = Convert.ToDecimal (  ed_lvITM.Items[curr_ndx ].SubItems[26].Text);
                        ovrg.Yves_Lavoie   = Convert.ToDecimal (  ed_lvITM.Items[curr_ndx ].SubItems[28].Text);
                        ovrg.Steven_Monk   = Convert.ToDecimal (  ed_lvITM.Items[curr_ndx ].SubItems[30].Text);
                        ovrg.Cmnt   = ed_lvITM.Items[curr_ndx ].SubItems[31].Text;
                    }

                     
                    try 
                    {
                        myDB.SubmitChanges (); 
                    }
                    catch (Exception ex)
                    {
                         MessageBox.Show("Update_Ovrg " + ex.Message + "   er#= " + ex.Source);

                    }
                }



        }

        private void Update_Comments()
        {


            using (var myDB = new DC_PGCdbDataContext())
            {
                var qry = from ovrg in myDB.HK_Overages_Sales
                          where ovrg.LID == Convert.ToInt32(ed_lvITM.Items[curr_ndx].SubItems[0].Text)
                          select ovrg;
                foreach (HK_Overages_Sale ovrg in qry) ovrg.Cmnt = txCmnt.Text;   //ed_lvITM.Items[curr_ndx].SubItems[31].Text;

                try
                {
                    myDB.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Update_Ovrg " + ex.Message + "   er#= " + ex.Source);

                }
            }



        }




        private void importNR()
        {
            if (MainMDI.User.ToLower () =="mmellouli" || MainMDI.User.ToLower () =="hnasrat" || MainMDI.User.ToLower () =="ede")
            {

            NBREC = 0; txSQL.Text = "";
            RID.Text = "";
            Import_ALLnew_Ovrg();
            txSQL.Text = "NBREC=" + NBREC.ToString();

            }
        }

        private void grpSales_Enter(object sender, EventArgs e)
        {

        }

        private void ed_lvITM_DoubleClick(object sender, EventArgs e)
        {
           // modify_values();

        }


        private void modify_values()
        {

            curr_ndx = ed_lvITM.SelectedItems[0].Index;

            tQP.Text = "Q" + ed_lvITM.Items[curr_ndx].SubItems[3].Text + " / P" + ed_lvITM.Items[curr_ndx].SubItems[5].Text;
            tInv.Text = ed_lvITM.Items[curr_ndx].SubItems[7].Text;
            tOld.Text = ed_lvITM.Items[curr_ndx].SubItems[15].Text;
            tNew.Text = ed_lvITM.Items[curr_ndx].SubItems[17].Text;
            tCustomer.Text = ed_lvITM.Items[curr_ndx].SubItems[6].Text;
            tItem.Text = ed_lvITM.Items[curr_ndx].SubItems[11].Text;
            txCmnt.Text = ed_lvITM.Items[curr_ndx].SubItems[31].Text;

        //    grpSales.Height = ModifYes ;
            grp1.Enabled = false;
            grpInv.Enabled = false;
            grpModify.Visible = true;
        }

        private void btn_Save_Click(object sender, EventArgs e)
        {

        }


        void maj_NewOVRG()
        {

            double NewOvrg_CAD = Tools.Conv_Dbl(ed_lvITM.Items[curr_ndx].SubItems[32].Text) * Tools.Conv_Dbl(tNew.Text);
            double prx = NewOvrg_CAD / 2;

            double part = Math.Round(prx / 3, 2);

            for (int i = 22; i < 31; i += 2)
                if (Tools.Conv_Dbl(ed_lvITM.Items[curr_ndx].SubItems[i - 1].Text) > 0) ed_lvITM.Items[curr_ndx].SubItems[i].Text = part.ToString();

            ed_lvITM.Items[curr_ndx].SubItems[17].Text = tNew.Text;
            ed_lvITM.Items[curr_ndx].SubItems[18].Text = Math.Round(NewOvrg_CAD, 2).ToString();
            ed_lvITM.Items[curr_ndx].SubItems[20].Text = Math.Round(prx, 2).ToString();


            Update_Ovrg();

        }





        private void btn_Cancel_Click(object sender, EventArgs e)
        {
         //   grpSales.Height = ModifNo ;
            grp1.Enabled = true;
            grpInv.Enabled = true;
            grpModify.Visible = false;
        }

        private void pic_SavOvrg_Click(object sender, EventArgs e)
        {
            double dd = Tools.Conv_Dbl(tNew.Text);

            if (dd > 0 && dd != Tools.Conv_Dbl(tOld.Text))
            {
                maj_NewOVRG();

            }

            ed_lvITM.Refresh();
         //   grpSales.Height = ModifNo;

            grp1.Enabled = true; grpInv.Enabled = true;
            grpModify.Visible = false;
        }

        private void pic_SavCmnt_Click(object sender, EventArgs e)
        {
            ed_lvITM.Items[curr_ndx].SubItems[31].Text = txCmnt.Text; FB_item(curr_ndx , 31, 'f', Color.Red); 
            Update_Comments();
            ed_lvITM.Refresh(); 
       //     grpSales.Height = ModifNo ;

            grp1.Enabled = true; grpInv.Enabled = true;
            grpModify.Visible = false;
        }

        private void modif_Click(object sender, EventArgs e)
        {
            modify_values();
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void tsb_InsideS_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;  
            importNR();

            this.Cursor = Cursors.Default ;  
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ed_lvITM.SelectedItems.Count ==1)     modify_values();
        }

        private void tsb_OutsideS_Click(object sender, EventArgs e)
        {
           if (ed_lvITM.SelectedItems.Count ==1)   edit_Quote();
        }


        private void edit_Quote()
        {

              curr_ndx = ed_lvITM.SelectedItems[0].Index;
              CpnyName = ed_lvITM.Items[curr_ndx].SubItems[6].Text;
              QNB = ed_lvITM.Items[curr_ndx].SubItems[3].Text;//, Iqid = "",
            string stSql= "SELECT     PSM_Q_IGen.i_Quoteid FROM    PSM_Q_IGen INNER JOIN  PSM_COMPANY ON PSM_Q_IGen.CPNY_ID = PSM_COMPANY.Cpny_ID " +
                       "           WHERE     (PSM_COMPANY.Cpny_Name1 = '" + CpnyName + "') AND (PSM_Q_IGen.Quote_ID = " + ed_lvITM.Items[curr_ndx].SubItems[3].Text + ") ORDER BY PSM_Q_IGen.i_Quoteid DESC; ";


            Iqid= MainMDI.Find_One_Field (stSql);

            if (Iqid != MainMDI.VIDE)
            {
                if (MainMDI.User == "ede")
                {
                    MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where [user]='ede'");
                    MainMDI.Use_QRID(-1, 'Q', "ede");
                }

                string usr = MainMDI.is_QR_Used('Q',Iqid );
                if (usr == MainMDI.VIDE || MainMDI.User == "ede")
                {
                   // Thread my_TRD = new Thread(new ThreadStart(TRD_editQuote));

                    MainMDI.Use_QRID(1, 'Q', Iqid);
                    Quote child4 = new Quote(Convert.ToInt32(QNB), CpnyName, 'E');
                    this.Hide();
                    child4.ShowDialog();

                   
                    MainMDI.Use_QRID(0, 'Q', Iqid);
                     this.Visible = true;
                }
                else MessageBox.Show("Sorry, This Quote is opened by: " + usr);
            }
            else MessageBox.Show("Sorry, This Quote is INVALID....");
        }


        private void TRD_editQuote()
        {
            MainMDI.Use_QRID(1, 'Q', Iqid);
            Quote child4 = new Quote(Convert.ToInt32(QNB), CpnyName, 'E');
            // this.Hide();
           // child4.ShowDialog();
           // Application.Run(child4); 
           // child4.ShowInTaskbar = true; 
            child4.Show();
            //   this.Visible = true;
            MainMDI.Use_QRID(0, 'Q', Iqid);


        }

        private void TRD_editQuotetessssssssssssssttt()
        {
            
            Quote child4 = new Quote(Convert.ToInt32(QNB), CpnyName, 'E');
            child4.Show();

    //        Quote child5 = new Quote(Convert.ToInt32(QNB), CpnyName, 'E');
       //     child5.Show();



        }

        private void op_Order_Click(object sender, EventArgs e)
        {
            if (ed_lvITM.SelectedItems.Count == 1) edit_Order();

        }



        private void edit_Order()
        {
            
            string IRID="",Rev="",RID=ed_lvITM.SelectedItems[0].SubItems[5].Text ,
                   Stsql="SELECT  [IRRevID]   ,[RRev_Name] FROM [Orig_PSM_FDB].[dbo].[PSM_R_Rev] where RID='" + RID +"'";

            MainMDI.Find_2_Field(Stsql ,ref IRID ,ref Rev );


                string usr = MainMDI.is_QR_Used('R', IRID); //chek if project is opened open project even opened one
                //    string usr=MainMDI.VIDE ; //open project even opened one

                if (usr == MainMDI.VIDE || MainMDI.User == "ede")
                {

                    MainMDI.Use_QRID(1, 'R', IRID);
                    Order child_Ord = new Order(RID, Rev);
                    this.Hide();
                    child_Ord.ShowDialog();

                    MainMDI.Use_QRID(0, 'R', IRID);
                    this.Visible = true;
                    child_Ord.Close(); child_Ord.Dispose();


                }
                else MessageBox.Show("Sorry, This PROJECT is opened by: " + usr);
            }
             
   
             
    }
}
