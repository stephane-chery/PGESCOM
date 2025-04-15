using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
using EAHLibs;


namespace PGESCOM
{
    public partial class CMS_invLIST : Form
    {
        private string in_brdLID="";
        private int cur_LV_ndx=-1;
        private char in_cod;
        public static EAHLibs.Lib1 Tools=new Lib1 ();
        private string lITMLID = "";
        const int  mvtL_MAX=1000,mvtC_MAX=5 ;//, Max_Flds_Vals = 200;
        string[,] arr_MVT = new string [mvtC_MAX ,mvtC_MAX ];
        Color CLR_CMSregular = Color.WhiteSmoke  , CLR_CMSOvrg = Color.PaleGreen,
               CLR_CMSNDC = Color.Yellow ,CLR_CMSBad = Color.Salmon; //Color.GreenYellow;
        const int NBSalesMAX = 80;
        string SES_LID = "0",Date_UPto="", DateSess="";
        char CMS_USR = 'N';  //A: accounts     V:CMS validation      C: CMS calculation
        string  Curr_saleFLName="", Curr_SaleID="";
        public static string Curr_YYYY="";
        Hashtable HT_Agencies = new Hashtable();
       public static  Hashtable HT_CML_Sales = new Hashtable();
        string[,] G_arr_Flds = new string[MainMDI.Max_Flds_Vals, 2];
        string[,] G_arr_Vals = new string[MainMDI.Max_Flds_Vals, 2];

        void init_mvtARR()
        {
            for (int i=0;i<mvtL_MAX ;i++) for (int j=0;j<mvtC_MAX ;j++) arr_MVT [i,j]="";
        }

        public CMS_invLIST()
        {


            InitializeComponent();
            lCMSregular.BackColor = CLR_CMSregular;
            lCMSBad.BackColor = CLR_CMSBad;
            lCMSOvrg.BackColor = CLR_CMSOvrg; 
     
  
  

        }


        private void find_REV_3TOT(string _irrevID, out double ST, out double PT, out  double GT)
        {

           // if (_irrevID == "2640") _irrevID = _irrevID;
            string stSql = " SELECT  distinct PSM_Q_ALS.ALS_Name,PSM_R_Detail.IRRev_LID, PSM_Q_ALS.Tot * PSM_Q_ALS.AlsQty AS SYS_TOT, PSM_Q_ALS.PxPrice AS PX_TOT,  PSM_Q_ALS.AGPrice AS AG_TOT " +
                           " FROM  PSM_R_Detail INNER JOIN PSM_Q_Details ON PSM_R_Detail.Qdet_LID = PSM_Q_Details.Detail_LID INNER JOIN PSM_Q_ALS ON PSM_Q_Details.ALS_LID = PSM_Q_ALS.ALS_LID " +
                           " WHERE     PSM_R_Detail.IRRev_LID =" + _irrevID + " ORDER BY PSM_R_Detail.IRRev_LID ";
            ST=0;PT=0;GT=0;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);                                        
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                ST  += Tools.Conv_Dbl ( Oreadr["SYS_TOT"].ToString());
                PT += Tools.Conv_Dbl(Oreadr["PX_TOT"].ToString());
                GT += Tools.Conv_Dbl ( Oreadr["AG_TOT"].ToString());

            }
            OConn.Close();

        }



        private void fill_NC()
        {

            int  nbRed = Int32.Parse(lCMSBad.Text), nbNDC = 0;
            string dat = "";

            lfromdat.Text = dpFrom.Value.ToShortDateString();
            string stSql = "SELECT  PSM_R_SBills_NC.* FROM  PSM_R_SBills_NC WHERE InvDate > CONVERT(DATETIME, '" + lfromdat.Text + "', " + MainMDI.C_Style + ") AND (InvDate <= CONVERT(DATETIME, '" + lDateTo.Text + "', " + MainMDI.C_Style + ")) AND  (Amnt <> 0) AND (Com <> 1) AND (Com <> 3) ";
            
            double d1 = 0, d2 = 0, d3 = 0;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvITM.Items.Add(""); for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");

                lv.SubItems[1].Text = Oreadr["IrrevLID"].ToString();
                lv.SubItems[2].Text = Oreadr["ncRID"].ToString();
                lv.SubItems[3].Text = MainMDI.VIDE  ;  //revision
                lv.SubItems[4].Text = "Credit Note";
                lv.SubItems[5].Text = Oreadr["AccInv"].ToString(); //NC #
                lv.SubItems[6].Text = MainMDI.Eng_date(Oreadr["InvDate"].ToString(), "/");
                lv.SubItems[7].Text = MainMDI.Currency_Name('C');
                lv.SubItems[8].Text = Oreadr["Amnt"].ToString();
                lv.SubItems[9].Text = "1";
                lv.SubItems[10].Text = Oreadr["Amnt"].ToString();
                lv.SubItems[11].Text = Oreadr["Territory"].ToString();
                lv.SubItems[12].Text = "No";

          //      d1 = Tools.Conv_Dbl(Oreadr["Amnt"].ToString()); d2 = d1; d3 = d1;
          //      lv.SubItems[17].Text = Oreadr["Amnt"].ToString();// "?????";// Oreadr["SYS_TOT"].ToString();
         //       lv.SubItems[18].Text = Oreadr["Amnt"].ToString(); // Oreadr["PX_TOT"].ToString();
         //       lv.SubItems[19].Text = Oreadr["Amnt"].ToString(); //Oreadr["AG_TOT"].ToString();

                find_REV_3TOT(Oreadr["IrrevLID"].ToString(), out d1, out d2, out d3);
                lv.SubItems[17].Text = d1.ToString();
                lv.SubItems[18].Text = d2.ToString(); 
                lv.SubItems[19].Text = d3.ToString(); 

                lv.BackColor = lv_color(ed_lvITM.Items.Count - 1);
                if (lv.BackColor == CLR_CMSBad) nbRed++;
                else
                {
                    lv.BackColor = CLR_CMSNDC;//Color.GreenYellow;
                    nbNDC++;
                }

            }


            lCMSBad.Text = nbRed.ToString();
            lCMSNDC.Text = nbNDC.ToString();  
            OConn.Close();

        }




        bool isVALID_partial_prj(string _irrevLID, string datMed,string dateFrom)
        {
            string stSql = " SELECT V_Partial_PRJ.IRRevID " + //, PSM_R_SBills.AccInv, PSM_R_SBills.InvoicDat " +
                         " FROM  V_Partial_PRJ INNER JOIN PSM_R_SBills ON V_Partial_PRJ.IRRevID = PSM_R_SBills.b_RRevLID INNER JOIN PSM_R_SLots ON PSM_R_SBills.Bil_LID = PSM_R_SLots.l_invLID " +
                         " WHERE  PSM_R_SLots.ShStatus = 'S' and (PSM_R_SBills.InvoicDat > CONVERT(DATETIME, '" + datMed + "', " + MainMDI.C_Style + ")   OR PSM_R_SBills.InvoicDat <= CONVERT(DATETIME, '" + dateFrom     + "', " + MainMDI.C_Style + ")) and PSM_R_SBills.b_RRevLID=" + _irrevLID;

            stSql = MainMDI.Find_One_Field (stSql );
            return stSql == MainMDI.VIDE;
        

        }



        private void fill_Invoices()
        {
            
            int nbregular = 0, nbbad = 0, nbOvrg = 0;
            string dat = "";
           // string styl = MainMDI.C_Style;
            lfromdat.Text = dpFrom.Value.ToShortDateString();
            string stSql = "SELECT     PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_R_Rev.RRev_Name, PSM_R_SBills.AccInv, PSM_COMPANY.Cpny_Name1, PSM_R_SLots.ShipDat, " +
                           " PSM_R_SBills.Xchng_rate,  PSM_R_SBills.InvoicDat, PSM_R_SBills.BilTOT, ROUND(PSM_R_SBills.Xchng_rate * PSM_R_SBills.BilTOT, 2) AS Bill_CAD_TOT, " +
                            " PSM_C_ComTERITORY.Terito_ABR, PSM_R_Rev.AGency, PSM_SALES_AGENTS.First_Name AS D_agent, PSM_SALES_AGENTS_1.First_Name AS I_agent, PSM_SALES_AGENTS_2.First_Name AS E_agent, PSM_SALES_AGENTS_3.First_Name AS P_agent, PSM_R_Rev.PA , PSM_R_Rev.Custm_PO, PSM_R_RevSys.R_sysName " +
                          " FROM         PSM_SALES_AGENTS INNER JOIN PSM_R_SLots INNER JOIN PSM_R_SBills ON PSM_R_SLots.l_invLID = PSM_R_SBills.Bil_LID INNER JOIN  PSM_R_Rev ON PSM_R_SBills.b_RRevLID = PSM_R_Rev.IRRevID INNER JOIN " +
                            " PSM_R_RevSys ON PSM_R_Rev.IRRevID = PSM_R_RevSys.IRRev_LID INNER JOIN PSM_C_ComTERITORY ON PSM_C_ComTERITORY.Terito_LID = PSM_R_Rev.SI ON PSM_SALES_AGENTS.SA_ID = PSM_R_Rev.AD INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_1 ON PSM_R_Rev.AI = PSM_SALES_AGENTS_1.SA_ID INNER JOIN " +
                           " PSM_SALES_AGENTS AS PSM_SALES_AGENTS_2 ON PSM_R_Rev.AE = PSM_SALES_AGENTS_2.SA_ID INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_3 ON PSM_R_Rev.AP = PSM_SALES_AGENTS_3.SA_ID INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID " +
                          " WHERE     (PSM_R_SLots.ShStatus = 'S') AND (PSM_R_SBills.InvoicDat > CONVERT(DATETIME, '" + lfromdat.Text + "', " + MainMDI.C_Style + ")) AND (PSM_R_SBills.InvoicDat <= CONVERT(DATETIME, '" + lDateTo.Text + "', " + MainMDI.C_Style + ")) AND (PSM_R_SBills.AccInv <> 'WARRANTY')  AND (PSM_R_SBills.BilTOT <> 0) AND (PSM_R_SBills.Com <> 1) AND (PSM_R_SBills.Com <> 3) AND (PSM_R_Rev.shiped = 'S') " +
                          " ORDER BY PSM_R_SBills.AccInv, PSM_R_Rev.IRRevID, PSM_R_Rev.RID,  PSM_R_RevSys.R_sysRnk ";


            double d1 = 0, d2 = 0, d3 = 0;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            //    ed_lvITM.BeginUpdate(); 
            Hashtable HT_IRREV = new Hashtable();
            lbx_invalidPrj.Items.Clear(); 
            while (Oreadr.Read())
            {
                if (isVALID_partial_prj(Oreadr["IRRevID"].ToString(), lDateTo.Text, dpFrom.Text))
                {

                    if (chk_Inv.Checked || (!chk_Inv.Checked && !HT_IRREV.Contains(Oreadr["IRRevID"].ToString())))
                    {
                        //if (ed_lvITM.Items.Count == 0) dpSes.Text = Oreadr["SES_Date"].ToString();   
                        ListViewItem lv = ed_lvITM.Items.Add(""); for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");

                        lv.SubItems[1].Text = Oreadr["IRRevID"].ToString();
                        lv.SubItems[2].Text = Oreadr["RID"].ToString();
                        lv.SubItems[3].Text = Oreadr["RRev_Name"].ToString();
                        lv.SubItems[4].Text = Oreadr["Cpny_Name1"].ToString();
                        lv.SubItems[5].Text = Oreadr["AccInv"].ToString();
                        lv.SubItems[6].Text = MainMDI.Eng_date(Oreadr["InvoicDat"].ToString(), "/");
                        lv.SubItems[7].Text = MainMDI.Currency_Name(Oreadr["PA"].ToString()[0]);
                        lv.SubItems[8].Text = Oreadr["BilTOT"].ToString();
                        lv.SubItems[9].Text = (Oreadr["PA"].ToString()[0]=='C') ? "1" : Oreadr["Xchng_rate"].ToString();
                        lv.SubItems[10].Text = Oreadr["Bill_CAD_TOT"].ToString();
                        lv.SubItems[11].Text = Oreadr["Terito_ABR"].ToString();
                        if (Oreadr["AGency"].ToString() == "1")
                        {
                            lv.SubItems[12].Text = "Yes";
                            lv.SubItems[13].Text = Oreadr["D_agent"].ToString();
                            lv.SubItems[14].Text = Oreadr["I_agent"].ToString();
                            lv.SubItems[15].Text = Oreadr["E_agent"].ToString();
                            lv.SubItems[16].Text = Oreadr["P_agent"].ToString();
                        }
                        else lv.SubItems[12].Text = "No";

                        find_REV_3TOT(Oreadr["IRRevID"].ToString(), out d1, out d2, out d3);
                        lv.SubItems[17].Text = d1.ToString();// "?????";// Oreadr["SYS_TOT"].ToString();
                        lv.SubItems[18].Text = d2.ToString(); // Oreadr["PX_TOT"].ToString();
                        lv.SubItems[19].Text = d3.ToString(); //Oreadr["AG_TOT"].ToString();


                        lv.SubItems[21].Text = Oreadr["Custm_PO"].ToString(); //PO#;
                        lv.SubItems[22].Text = Oreadr["R_sysName"].ToString(); //sysName;


                        lv.BackColor = lv_color(ed_lvITM.Items.Count - 1);
                        if (lv.BackColor == CLR_CMSBad) nbbad++;
                        if (lv.BackColor == CLR_CMSOvrg) nbOvrg++;


                        if (d1 == d2 && d1 == d3 && lv.BackColor == CLR_CMSOvrg && d1.ToString() == lv.SubItems[8].Text)
                        {
                            lv.BackColor = CLR_CMSregular;// Color.GreenYellow;
                            nbOvrg--;
                            nbregular++;
                        }
                        if (!chk_Inv.Checked) HT_IRREV.Add(Oreadr["IRRevID"].ToString(), (ed_lvITM.Items.Count - 1).ToString());

                    }
                }
                else
                {
                    string stAff="P" + Oreadr["RID"].ToString() + " /  I" + Oreadr["AccInv"].ToString();
                    if (lbx_invalidPrj.FindStringExact (stAff ) ==-1) lbx_invalidPrj.Items.Add(stAff );
                }

            }
            // ed_lvITM.EndUpdate();
            lCMSOvrg.Text = nbOvrg.ToString();
            lCMSBad.Text = nbbad.ToString();
            lCMSregular.Text = nbregular.ToString();
            OConn.Close();

        }


        private void fill_InvoicesOLDOK()
        {

            int nbregular = 0, nbbad = 0, nbOvrg = 0;
            string dat = "";
            // string styl = MainMDI.C_Style;
            lfromdat.Text = dpFrom.Value.ToShortDateString();
            string stSql = "SELECT     PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_R_Rev.RRev_Name, PSM_R_SBills.AccInv, PSM_COMPANY.Cpny_Name1, PSM_R_SLots.ShipDat, " +
                           " PSM_R_SBills.Xchng_rate,  PSM_R_SBills.InvoicDat, PSM_R_SBills.BilTOT, ROUND(PSM_R_SBills.Xchng_rate * PSM_R_SBills.BilTOT, 2) AS Bill_CAD_TOT, " +
                            " PSM_C_ComTERITORY.Terito_ABR, PSM_R_Rev.AGency, PSM_SALES_AGENTS.First_Name AS D_agent, PSM_SALES_AGENTS_1.First_Name AS I_agent, PSM_SALES_AGENTS_2.First_Name AS E_agent, PSM_SALES_AGENTS_3.First_Name AS P_agent, PSM_R_Rev.PA " +
                          " FROM         PSM_SALES_AGENTS INNER JOIN PSM_R_SLots INNER JOIN PSM_R_SBills ON PSM_R_SLots.l_invLID = PSM_R_SBills.Bil_LID INNER JOIN  PSM_R_Rev ON PSM_R_SBills.b_RRevLID = PSM_R_Rev.IRRevID INNER JOIN " +
                            " PSM_R_RevSys ON PSM_R_Rev.IRRevID = PSM_R_RevSys.IRRev_LID INNER JOIN PSM_C_ComTERITORY ON PSM_C_ComTERITORY.Terito_LID = PSM_R_Rev.SI ON PSM_SALES_AGENTS.SA_ID = PSM_R_Rev.AD INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_1 ON PSM_R_Rev.AI = PSM_SALES_AGENTS_1.SA_ID INNER JOIN " +
                           " PSM_SALES_AGENTS AS PSM_SALES_AGENTS_2 ON PSM_R_Rev.AE = PSM_SALES_AGENTS_2.SA_ID INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_3 ON PSM_R_Rev.AP = PSM_SALES_AGENTS_3.SA_ID INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID " +
                          " WHERE     (PSM_R_SLots.ShStatus = 'S') AND (PSM_R_SBills.InvoicDat > CONVERT(DATETIME, '" + lfromdat.Text + "', " + MainMDI.C_Style + ")) AND (PSM_R_SBills.InvoicDat <= CONVERT(DATETIME, '" + lDateTo.Text + "', " + MainMDI.C_Style + ")) AND (PSM_R_SBills.AccInv <> 'WARRANTY')  AND (PSM_R_SBills.BilTOT <> 0) AND (PSM_R_SBills.Com <> 1) AND (PSM_R_SBills.Com <> 3) AND (PSM_R_Rev.shiped = 'S') " +
                //              " ORDER BY PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_R_SBills.AccInv, PSM_R_RevSys.R_sysRnk ";
                          " ORDER BY PSM_R_SBills.AccInv, PSM_R_Rev.IRRevID, PSM_R_Rev.RID,  PSM_R_RevSys.R_sysRnk ";

            //          string stSql = "SELECT     PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_R_Rev.RRev_Name, PSM_R_SBills.AccInv, PSM_COMPANY.Cpny_Name1, PSM_R_SLots.ShipDat, " +
            //               " PSM_R_SBills.Xchng_rate,  PSM_R_SBills.InvoicDat, PSM_R_SBills.BilTOT, ROUND(PSM_R_SBills.Xchng_rate * PSM_R_SBills.BilTOT, 2) AS Bill_CAD_TOT, " +
            //               " PSM_C_ComTERITORY.Terito_ABR, PSM_R_Rev.AGency, PSM_SALES_AGENTS.First_Name AS D_agent, PSM_SALES_AGENTS_1.First_Name AS I_agent, PSM_SALES_AGENTS_2.First_Name AS E_agent, PSM_SALES_AGENTS_3.First_Name AS P_agent, PSM_R_Rev.PA ,  PSM_R_Rev.PA, V_Rev_ALLTOTs.PX_TOT, V_Rev_ALLTOTs.AG_TOT " +
            //             " FROM         PSM_SALES_AGENTS INNER JOIN PSM_R_SLots INNER JOIN PSM_R_SBills ON PSM_R_SLots.l_invLID = PSM_R_SBills.Bil_LID INNER JOIN  PSM_R_Rev ON PSM_R_SBills.b_RRevLID = PSM_R_Rev.IRRevID INNER JOIN " +
            //               " PSM_R_RevSys ON PSM_R_Rev.IRRevID = PSM_R_RevSys.IRRev_LID INNER JOIN PSM_C_ComTERITORY ON PSM_C_ComTERITORY.Terito_LID = PSM_R_Rev.SI ON PSM_SALES_AGENTS.SA_ID = PSM_R_Rev.AD INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_1 ON PSM_R_Rev.AI = PSM_SALES_AGENTS_1.SA_ID INNER JOIN " +
            //               " PSM_SALES_AGENTS AS PSM_SALES_AGENTS_2 ON PSM_R_Rev.AE = PSM_SALES_AGENTS_2.SA_ID INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_3 ON PSM_R_Rev.AP = PSM_SALES_AGENTS_3.SA_ID INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID INNER JOIN  V_Rev_ALLTOTs ON PSM_R_Rev.IRRevID = V_Rev_ALLTOTs.IRRev_LID " +
            //             " WHERE     (PSM_R_SLots.ShStatus = 'S') AND (PSM_R_SBills.InvoicDat > CONVERT(DATETIME, '" + lfromdat.Text + "', 103)) AND (PSM_R_SBills.InvoicDat <= CONVERT(DATETIME, '" + lDateTo.Text + "', 103)) AND (PSM_R_SBills.AccInv <> 'WARRANTY')  AND (PSM_R_SBills.BilTOT <> 0) AND (PSM_R_SBills.Com <> 1) AND (PSM_R_Rev.shiped = 'S') " +
            //             " ORDER BY PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_R_SBills.AccInv, PSM_R_RevSys.R_sysRnk ";
            double d1 = 0, d2 = 0, d3 = 0;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvITM.Items.Clear();
            //    ed_lvITM.BeginUpdate(); 
            Hashtable HT_IRREV = new Hashtable();

            while (Oreadr.Read())
            {

                if (chk_Inv.Checked || (!chk_Inv.Checked && !HT_IRREV.Contains(Oreadr["IRRevID"].ToString())))
                {
                    //if (ed_lvITM.Items.Count == 0) dpSes.Text = Oreadr["SES_Date"].ToString();   
                    ListViewItem lv = ed_lvITM.Items.Add(""); for (int c = 1; c < ed_lvITM.Columns.Count; c++) lv.SubItems.Add("");

                    lv.SubItems[1].Text = Oreadr["IRRevID"].ToString();
                    lv.SubItems[2].Text = Oreadr["RID"].ToString();
                    lv.SubItems[3].Text = Oreadr["RRev_Name"].ToString();
                    lv.SubItems[4].Text = Oreadr["Cpny_Name1"].ToString();
                    lv.SubItems[5].Text = Oreadr["AccInv"].ToString();
                    lv.SubItems[6].Text = MainMDI.Eng_date(Oreadr["InvoicDat"].ToString(), "/");
                    lv.SubItems[7].Text = MainMDI.Currency_Name(Oreadr["PA"].ToString()[0]);
                    lv.SubItems[8].Text = Oreadr["BilTOT"].ToString();
                    lv.SubItems[9].Text = Oreadr["Xchng_rate"].ToString();
                    lv.SubItems[10].Text = Oreadr["Bill_CAD_TOT"].ToString();
                    lv.SubItems[11].Text = Oreadr["Terito_ABR"].ToString();
                    if (Oreadr["AGency"].ToString() == "1")
                    {
                        lv.SubItems[12].Text = "Yes";
                        lv.SubItems[13].Text = Oreadr["D_agent"].ToString();
                        lv.SubItems[14].Text = Oreadr["I_agent"].ToString();
                        lv.SubItems[15].Text = Oreadr["E_agent"].ToString();
                        lv.SubItems[16].Text = Oreadr["P_agent"].ToString();
                    }
                    else lv.SubItems[12].Text = "No";

                    find_REV_3TOT(Oreadr["IRRevID"].ToString(), out d1, out d2, out d3);
                    lv.SubItems[17].Text = d1.ToString();// "?????";// Oreadr["SYS_TOT"].ToString();
                    lv.SubItems[18].Text = d2.ToString(); // Oreadr["PX_TOT"].ToString();
                    lv.SubItems[19].Text = d3.ToString(); //Oreadr["AG_TOT"].ToString();


                    lv.BackColor = lv_color(ed_lvITM.Items.Count - 1);
                    if (lv.BackColor == CLR_CMSBad) nbbad++;
                    if (lv.BackColor == CLR_CMSOvrg) nbOvrg++;


                    if (d1 == d2 && d1 == d3 && lv.BackColor == CLR_CMSOvrg && d1.ToString() == lv.SubItems[8].Text)
                    {
                        lv.BackColor = CLR_CMSregular;// Color.GreenYellow;
                        nbOvrg--;
                        nbregular++;
                    }
                    if (!chk_Inv.Checked) HT_IRREV.Add(Oreadr["IRRevID"].ToString(), (ed_lvITM.Items.Count - 1).ToString());

                }


            }
            // ed_lvITM.EndUpdate();
            lCMSOvrg.Text = nbOvrg.ToString();
            lCMSBad.Text = nbbad.ToString();
            lCMSregular.Text = nbregular.ToString();
            OConn.Close();

        }


        private Color lv_color(int _ndx)
        {
            if (ed_lvITM.Items[_ndx].SubItems[11].Text == "No Territory") return CLR_CMSBad ;// Color.Salmon;
            else
            {
                if (ed_lvITM.Items[_ndx].SubItems[12].Text == "0") return CLR_CMSBad;
                else
                {
                    if (ed_lvITM.Items[_ndx].SubItems[12].Text == MainMDI.VIDE || ed_lvITM.Items[_ndx].SubItems[13].Text == MainMDI.VIDE || ed_lvITM.Items[_ndx].SubItems[14].Text == MainMDI.VIDE || ed_lvITM.Items[_ndx].SubItems[15].Text == MainMDI.VIDE || ed_lvITM.Items[_ndx].SubItems[16].Text == MainMDI.VIDE) return CLR_CMSBad;
                }
            }
            return CLR_CMSOvrg  ;
        }
        private void Wait_msg(bool _sta)
        {
         //   picWait.Visible = _sta;
            lwait.Visible = _sta;
            this.Cursor = (_sta) ? Cursors.WaitCursor : Cursors.Default; ;
            grpITM.Refresh();
        }
        private void NewItm_Click(object sender, EventArgs e)
        {


        }

        private void List_Invoices()
        {

    


            disp_grp('I');
           Wait_msg(true);
       //     clr_scrn_info ();
            if (lDateTo.Text != "")
            {
                ed_lvITM.BeginUpdate(); 
                fill_Invoices();
                fill_NC();
                ed_lvITM.EndUpdate();
            }
           // lDateTo.Text = "";
            grpITM.Height = (lbx_invalidPrj.Items.Count >0 ) ? 207 : 73;
            Wait_msg(false);

            fix.Visible = grpInv.Visible;
        }

        private void clr_scrn_info()
        {
            //dpSes.Text = DateTime.Now.ToShortDateString ();
            
        }

        private void Sav_Itm_Click(object sender, EventArgs e)
        {
           
        }

        private void Save_TMPSession()
        {



            string st = "";
            bool newEntry = true, replace = false; ;
            if (ed_lvITM.Items.Count >0)
            {
                if (SES_LID=="" )
                {

                    st = MainMDI.Find_One_Field("select Date_UPto from PSM_M_Sessions where status='T'");
                    if (st != MainMDI.VIDE)
                    {
                        string st1 = MainMDI.Eng_date(dpTO.Value.ToShortDateString(), "/");
                        newEntry = (st1 != st);
                    }
                    if (!newEntry)  replace  =(MainMDI.Confirm ("This date was already saved, want to Replace it: ? " )) ;


                    if (newEntry  || replace )

                    {

                        MainMDI.Exec_SQL_JFS("delete PSM_M_Sessions where [status]='T' ", " CMS....Delete current TMP_session...");
                        MainMDI.Exec_SQL_JFS("delete PSM_M_Tmp_CMS ", " CMS....Delete current TMP_CMS...");
                        st = "INSERT INTO PSM_M_Sessions ([SES_Date], [Done_by], [Date_UPto], [status]) VALUES ("
                            + MainMDI.SSV_date(dpSes.Value.ToShortDateString()) + ", '" + MainMDI.User + "', '" + MainMDI.Eng_date(dpTO.Value.ToShortDateString(), "/") + "', 'T')";
                        MainMDI.Exec_SQL_JFS(st, " CMS....insert New TMP_session...");


                    }
                   // else if (!replace) MessageBox.Show("This Temporary date already exists ......");
                }

         
            }

        }

        private void Save_tmpCMS()
        {

            string stSql="";
            if (ed_lvCMS.Items[0].SubItems [14].Text  == "")
            {
                stSql = "delete PSM_M_Tmp_CMS "; MainMDI.Exec_SQL_JFS(stSql, " CMS....Delete current TMP_CMS...");
                for (int i = 0; i < ed_lvCMS.Items.Count; i++)
                    {
                        stSql = "INSERT INTO PSM_M_Tmp_CMS  ([tmpSes_id],[checked],";
                    string fields = "", val = " ) VALUES (" + SES_LID + ", " + (ed_lvCMS.Items[i].Checked ? "1" : "0") + ", '";
                        for (int j = 1; j < ed_lvCMS.Items[i].SubItems.Count; j++) 
                        {
                            fields += (j == 1) ? " [Fld" + j.ToString() + "]" : ", " +" [Fld" + j.ToString() + "]" ;
                            val += (j == 1) ? ed_lvCMS.Items[i].SubItems[j].Text : "', '" + ed_lvCMS.Items[i].SubItems[j].Text;    
                        }

                        stSql +=fields + val +"')";
                         MainMDI.Exec_SQL_JFS(stSql, " CMS....insert New TMP_session...");
                    }

             }
            else
            {
                for (int i = 0; i < ed_lvCMS.Items.Count; i++)               
                {
                    if ((CMS_USR == 'C' && ed_lvCMS.Items[i].BackColor == Color.WhiteSmoke) || CMS_USR == 'V' || CMS_USR == 'S')
                    {
                        stSql = "UPDATE PSM_M_Tmp_CMS  SET " + " [checked]='" + (ed_lvCMS.Items[i].Checked ? "1" : "0") + "' WHERE tmpID=" + ed_lvCMS.Items[i].SubItems[14].Text;
                        MainMDI.Exec_SQL_JFS(stSql, "Update current TMP_session (status)....");
                    }
                }

            }

           
        }


        private void list_BI_Click(object sender, EventArgs e)
        {


        }






        private void Calc_CMS()
        {
            
            this.Cursor = Cursors.WaitCursor;
            Wait_msg(true);

            ed_lvCMS.BeginUpdate();
            Process_Invoices_Sales();
            Process_Invoices_Agency();
            Process_Invoices_OVERG();
            Process_CreditNotes();
            ed_lvCMS.EndUpdate();
            //calculate credit notes....to see wirh sam HOW
            Wait_msg(false);
            grpCMS.Visible = true;
            grpInv.Dock = (grpCMS.Visible) ? DockStyle.Top : DockStyle.Fill; 
            this.Cursor = Cursors.Default; 


        }


        private void disp_grp(char cod)
        {

            cbSales_old.Enabled =true;
            cbCMS_old.Enabled = true;  
            
            switch (cod)
            {
                case 'C':    //CMS
                    grpCMS.Visible = true;
                    grpITM.Visible = false;
                    grpInv.Visible = false;
                    grpHisto.Visible = false;
                    btn_SaveCms.Visible = true;
                    btnCALC_CMS.Visible = true;
                    btnSndAcct.Visible = true;
                    grpcalc.Visible = true; 


                    break;

                case 'I':  //invoice
                    grpCMS.Visible = false;
                    grpITM.Visible = true;
                    grpInv.Visible = true;


                    break;
                case 'B':  //both
                    grpCMS.Visible = true;
                    grpITM.Visible = true;
                    grpInv.Visible = true;


                    break;
                case 'H':  //both
                    grpCMS.Visible = true;
                    grpITM.Visible = false;
                    grpInv.Visible = false;
                    grpHisto.Visible = true;
                    btn_SaveCms.Visible = false;
                    btnCALC_CMS.Visible = false;
                    btnSndAcct.Visible = false;
                    grpcalc.Visible = false;
                    txRevLID.Visible = (MainMDI.User.ToLower() == "ede");
                 //   picLIDseek.Visible = txRevLID.Visible;
                   // lrv.Visible = txRevLID.Visible;
                    txRevLID.ReadOnly  = (MainMDI.User.ToLower() != "ede");
                    btn_canelCMS.Enabled  = (MainMDI.User.ToLower() == "ede");

                    if (MainMDI.User.ToLower() != "ede" && MainMDI.User.ToLower() != "mmellouli")
                    {
                        string stSql = MainMDI.Find_One_Field("select First_Name + ' ' + Last_Name from PSM_SALES_AGENTS inner join PSM_users_New on PSM_users_New.userID=PSM_SALES_AGENTS.PGC_login where SA='S' and status='1' and [PSM_users_New].[user]='" + MainMDI.User + "'");

                        cbSales_old.Text = stSql;
                        cbCMS_old.Text = "Sales";

                        cbSales_old.Enabled = false;
                        cbCMS_old.Enabled = false;
                    }

                    break;
            }

            grpInv.Dock = (grpCMS.Visible) ? DockStyle.Top : DockStyle.Fill; 
        }

        private void ts_acct_Click(object sender, EventArgs e)
        {



          


        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void dpFrom_ValueChanged(object sender, EventArgs e)
        {
            lfromdat.Text = dpFrom.Value.ToShortDateString();
            //lDateTo.Text = dpTO.Value.ToShortDateString ();
        }

        private void dpTO_ValueChanged(object sender, EventArgs e)
        {
            lDateTo.Text = dpTO.Value.ToShortDateString();
        }

   
       
        private void email_SalesTerrito(string InvNB,string _LRID,string _territo)
        {

          
                MainMDI.Exec_SQL_JFS("delete PSM_InvEmailed where InvNB='" + InvNB + "'", "Delete INvEmailed");

                string stSql = " SELECT  PSM_SALES_AGENTS.Email_Address  FROM  PSM_Q_IGen INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID " +
                               " INNER JOIN PSM_R_Rev ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID INNER JOIN PSM_R_SBills ON PSM_R_Rev.IRRevID = PSM_R_SBills.b_RRevLID " +
                               " WHERE     (PSM_R_Rev.RID = '" + _LRID + "')";
                string email = MainMDI.Find_One_Field(stSql);

                if (email != MainMDI.VIDE && MainMDI.emailIsValid(email))
                {
                    string emailCC = MainMDI.Find_One_Field("select Email from PSM_C_ComTERITORY where Terito_ABR='" + _territo + "'");
                    email += (emailCC != MainMDI.VIDE) ? "; " + emailCC : "";  
                     // email = "hedebbab@primax-e.com"; //just for debugging not for release !!!!!!!!!!
                    string FromAdrs = "PGESCOM_Admin@primax-e.com";
                    string Subject = " Can not process Commisions for this project : [NO Territory OR Invalid agency] ==> Project#: " + _LRID + " / Invoice#: " + InvNB + ")";
                    string Body = "Hi, \n Can not process Commisions for This Project since [NO Territory OR Invalid agency] error was detected : " + _LRID + " / Invoice#: " + InvNB + "...Could you Fix this !!! \n" +
                        "Thank you. \n \n";// +MainMDI.Outlk_CR + MainMDI.Outlk_CR;

                    MainMDI.send_email (FromAdrs, email + ", hedebbab@primax-e.com", Subject, Body);
           //         System.Web.Mail.SmtpMail.SmtpServer = "ntserver.PRIMAX.LOCAL";
           //         System.Web.Mail.SmtpMail.Send(FromAdrs, email + ";hedebbab@primax-e.com", Subject, Body);
          //

                    MainMDI.Exec_SQL_JFS("insert into PSM_InvEmailed ([InvNB],[Emaildate]) values ('" + InvNB + "', " + MainMDI.SSV_date(DateTime.Now.ToShortDateString()) + ")", "update InvEmailed");
                }
                else MainMDI.Write_XadminLog("email does not exist for This Project: " +_LRID , " Order, email_SalesTerrito() ");
    



        }


        private void email_Sales_Agencies(string InvNB, string _LRID)
        {


            MainMDI.Exec_SQL_JFS("delete PSM_InvEmailed where InvNB='" + InvNB + "'", "Delete INvEmailed");

            string stSql = " SELECT  PSM_SALES_AGENTS.Email_Address  FROM  PSM_Q_IGen INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID " +
                           " INNER JOIN PSM_R_Rev ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID INNER JOIN PSM_R_SBills ON PSM_R_Rev.IRRevID = PSM_R_SBills.b_RRevLID " +
                           " WHERE     (PSM_R_Rev.RID = '" + _LRID + "')";
            string email = MainMDI.Find_One_Field(stSql);

            if (email != MainMDI.VIDE && MainMDI.emailIsValid(email))
            {
                // email = "hedebbab@primax-e.com"; //just for debugging not for release !!!!!!!!!!
                string FromAdrs = "PGESCOM_Admin@primax-e.com";
                string Subject = " Can not process Commisions for this project : [NO Territory OR Invalid agency] ==> Project#: " + _LRID + " / Invoice#: " + InvNB + ")";
                string Body = "Hi, \n Can not process Commisions for This Project since [NO Territory OR Invalid agency] error was detected : " + _LRID + " / Invoice#: " + InvNB + "...Could you Fix this !!! \n" +
                    "Thank you. \n \n";// +MainMDI.Outlk_CR + MainMDI.Outlk_CR;
                MainMDI.send_email (FromAdrs, email + ", hedebbab@primax-e.com", Subject, Body);
           //     System.Web.Mail.SmtpMail.SmtpServer = "ntserver.PRIMAX.LOCAL";
           //     System.Web.Mail.SmtpMail.Send(FromAdrs, email + ";hedebbab@primax-e.com", Subject, Body);
                MainMDI.Exec_SQL_JFS("insert into PSM_InvEmailed ([InvNB],[Emaildate]) values ('" + InvNB + "', " + MainMDI.SSV_date(DateTime.Now.ToShortDateString()) + ")", "update InvEmailed");
            }
            else MainMDI.Write_XadminLog("email does not exist for This Project: " + _LRID, " Order, email_SalesTerrito() ");




        }

        private void fix_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            picEMAIL.Visible = true;
  
            MainMDI.Exec_SQL_JFS("delete PSM_InvEmailed ", "Delete INvEmailed");
            for (int i=0;i<ed_lvITM.Items.Count ;i++)
            {
                if (ed_lvITM.Items[i].BackColor == Color.Salmon)
                    Check_Com_Bill(ed_lvITM.Items[i].SubItems[7].Text, ed_lvITM.Items[i].SubItems[5].Text, "", 'S', ed_lvITM.Items[i].SubItems[11].Text, ed_lvITM.Items[i].SubItems[2].Text);
              
                if ( ed_lvITM.Items[i].SubItems[7].Text =="CAD" && Tools.Conv_Dbl (ed_lvITM.Items[i].SubItems[9].Text)!=1 )  MainMDI.Exec_SQL_JFS ("Update  PSM_R_SBills set [Xchng_rate]=1 where AccInv='" + ed_lvITM.Items[i].SubItems[5].Text + "'","update CAD Invoice .....xrate=1.00"); 
            }

            picEMAIL.Visible = false;
            List_Invoices();
            this.Cursor = Cursors.Default;
        }
        private bool Inv_Mailed(string Inv)
        {
            return MainMDI.Find_One_Field("select InvNB from PSM_InvEmailed where InvNB='" + Inv + "' and Emaildate=" + MainMDI.SSV_date(DateTime.Now.ToShortDateString())) != MainMDI.VIDE;
        }

        private void Check_Com_Bill(string currency, string InvNB, string datt, char BillorShp, string Terri, string RID)
        {


            string res = MainMDI.VIDE;
            string stXP = "";
            if (currency != "C")
            {
                if (datt == "") datt = MainMDI.Find_One_Field("select InvoicDat from  dbo.PSM_R_SBills where AccInv='" + InvNB + "'");
                string rate = "";
                rate= MainMDI.Find_One_Field ("SELECT XRate FROM  PSM_R_SBill_XRate WHERE XR_Date <=" + MainMDI.SSV_date(datt) + " ORDER BY XR_Date DESC ");
                if (Tools.Conv_Dbl(rate) > 0) MainMDI.Exec_SQL_JFS("Update PSM_R_SBills set [Xchng_rate]=" + rate + "where AccInv='" + InvNB + "'", " MAJ Xrate /Check_Com_Bill()");
                else MainMDI.Write_XadminLog("Xrate does not exist for Invoice#:" + InvNB,this.Name  );
            }



            //check territory
            if (!Inv_Mailed(InvNB))
                email_SalesTerrito(InvNB,RID,Terri    );



        }

        private void btn_NC_Click(object sender, EventArgs e)
        {
            dlg_NoteCredit dlg_NC = new dlg_NoteCredit();
            dlg_NC.ShowDialog();
            dlg_NC.Dispose();
        }

        private void LV_AddItm(SA_Commiss SA_CMS,char _cmsType)
        {
            if ((!chkZero.Checked && SA_CMS.CMS_Amnt != 0) || (chkZero.Checked)) 
            {
                ListViewItem lv = ed_lvCMS.Items.Add(""); for (int c = 1; c < ed_lvCMS.Columns.Count; c++) lv.SubItems.Add("");

                lv.SubItems[1].Text = SA_CMS.SA_LID;// arr_Sales[ss].Sale_LID;
                lv.SubItems[2].Text = SA_CMS.InvNB;// arr_Sales[ss].InvNB;
                lv.SubItems[3].Text = SA_CMS.Full_Name;// arr_Sales[ss].Full_Name;
                lv.SubItems[4].Text = SA_CMS.Base_Amnt.ToString();// arr_Sales[ss].Base_Amnt.ToString();

                lv.SubItems[5].Text = SA_CMS.CMS_Rate.ToString();//arr_Sales[ss].CMS_Rate.ToString();
                lv.SubItems[6].Text = SA_CMS.CMS_Amnt.ToString()   ;//arr_Sales[ss].CMS_Amnt.ToString();
                
                lv.SubItems[7].Text = SA_CMS.C_Currency ;
                lv.SubItems[8].Text = SA_CMS.C_Xrate.ToString(); 
                lv.SubItems[9].Text = SA_CMS.CAD_AMNT ;

                lv.SubItems[10].Text = _cmsType.ToString ();
                lv.SubItems[11].Text = SA_CMS.Itm_Grp;
                lv.SubItems[12].Text = SA_CMS.REVlid ;

                lv.BackColor = CLR_CMSregular;// Color.GreenYellow;
            }

        }

        private void fill_Cms(string SAname)
        {

           
            ed_lvCMS.BeginUpdate();

            string Cond_fld3="", Cond_Fld11="";
            switch (cbCMStype.Text)
            {
                case "Sales":
                    Cond_Fld11 = " Fld11='SNG'";
                    break;
                case "Sales Overage":
                    Cond_Fld11 = " Fld11='OVS'";
                    break;
                case "Agencies":
                    Cond_Fld11 = " ( Fld11='AGA' OR  Fld11='AGB'  OR  Fld11='AGC'  OR  Fld11='AGD' )";
                    break;
                case "Agencies Overage":
                    Cond_Fld11 = " Fld11='OVA'";
                    break;
            }

            if (SAname != "ALL") Cond_fld3 = " where Fld3='" + cbSales.Text + "' ";
            if (Cond_fld3 == "" && Cond_Fld11 != "") Cond_Fld11  = " Where " + Cond_Fld11 ;
            if (Cond_fld3 != "" && Cond_Fld11 != "") Cond_Fld11  =" AND " + Cond_Fld11;



            string stSql = " SELECT   * from  PSM_M_Tmp_CMS " + Cond_fld3 + Cond_Fld11 + " order by Fld2 "; 

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvCMS.Items.Clear();
            bool Cont=true;
            double dtot = 0;
            while (Oreadr.Read())
            {
                Cont = true;
                if (CMS_USR == 'V' ) Cont = (Curr_saleFLName == Oreadr["Fld3"].ToString() || HT_Agencies.Contains(Oreadr["Fld3"].ToString()));
            
                if (Cont )
                {
                ListViewItem lv = ed_lvCMS.Items.Add(""); for (int c = 1; c < ed_lvCMS.Columns.Count; c++) lv.SubItems.Add("");
                lv.SubItems [13].Text = Oreadr["tmpSes_id"].ToString ();
                lv.SubItems[14].Text = Oreadr["tmpID"].ToString();

                for (int i=1;i<lv.SubItems.Count -2;i++) lv.SubItems [i].Text = Oreadr[i+2].ToString ();
                lv.Checked = (Oreadr["checked"].ToString() == "1");
                dtot += Tools.Conv_Dbl(Oreadr["Fld9"].ToString());
                                //     lv.BackColor = (lv.SubItems[11].Text == "SNG" || lv.SubItems[11].Text == "OVS") ? Color.WhiteSmoke : Color.LightSkyBlue ;
                }
                
    
            }
            OConn.Close();
           // if (ed_lvCMS.Items.Count > 0) 
            ltot.Text = Math.Round(dtot,MainMDI.NB_DEC_AFF  ).ToString ();
            ed_lvCMS.EndUpdate();
            

        }


        private void fill_Cms_TOTALS()
        {


            ed_lvCMS.BeginUpdate();

            string Cond_fld3 = "", Cond_Fld11 = "";
            switch (cbCMStype.Text)
            {
                case "Sales":
                    Cond_Fld11 = " Fld11='SNG'";
                    break;
                case "Sales Overage":
                    Cond_Fld11 = " Fld11='OVS'";
                    break;
                case "Agencies":
                    Cond_Fld11 = " ( Fld11='AGA' OR  Fld11='AGB'  OR  Fld11='AGC'  OR  Fld11='AGD' )";
                    break;
                case "Agencies Overage":
                    Cond_Fld11 = " Fld11='OVA'";
                    break;
            }

         //   if (SAname != "ALL") Cond_fld3 = " where Fld3='" + cbSales.Text + "' ";
            if (Cond_fld3 == "" && Cond_Fld11 != "") Cond_Fld11 = " Where " + Cond_Fld11;
            if (Cond_fld3 != "" && Cond_Fld11 != "") Cond_Fld11 = " AND " + Cond_Fld11;



            string stSql = " SELECT   Fld3, Fld9 from  PSM_M_Tmp_CMS " + Cond_fld3 + Cond_Fld11 + " order by Fld3 ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvCMS.Items.Clear();
            decimal dtot = 0,bigTOT=0;
            string oldNM = "",NewNM="";
            while (Oreadr.Read())
            {
                NewNM = Oreadr["Fld3"].ToString();
                if (NewNM != oldNM && oldNM != "")
                {
                    add_toLV(oldNM, dtot.ToString());
                    bigTOT += dtot;
                    dtot = 0;
                }
                dtot += (decimal)Tools.Conv_Dbl(Oreadr["Fld9"].ToString());
                oldNM = NewNM;

            }
            OConn.Close();
            if (dtot > 0) { add_toLV(oldNM, dtot.ToString()); bigTOT += dtot; }
      
           ltot.Text = Math.Round(bigTOT, MainMDI.NB_DEC_AFF).ToString();
            ed_lvCMS.EndUpdate();


        }

        private void add_toLV(string st3,string _Tot)
        {
            ListViewItem lv = ed_lvCMS.Items.Add(""); for (int c = 1; c < ed_lvCMS.Columns.Count; c++) lv.SubItems.Add("");
            lv.SubItems[3].Text = st3;// Oreadr["Fld3"].ToString();
            lv.SubItems[9].Text = _Tot ;
        }


        private void fill_CmsOLDOK(string SAname)
        {


            ed_lvCMS.BeginUpdate();
            string stSql = (SAname == "ALL") ? " SELECT   * from  PSM_M_Tmp_CMS " : "SELECT   * from  PSM_M_Tmp_CMS where Fld3='" + cbSales.Text + "'";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvCMS.Items.Clear();
            bool Cont = true;
            double dtot = 0;
            while (Oreadr.Read())
            {
                Cont = true;
                if (CMS_USR == 'V') Cont = (Curr_saleFLName == Oreadr["Fld3"].ToString() || HT_Agencies.Contains(Oreadr["Fld3"].ToString()));

                if (Cont)
                {
                    ListViewItem lv = ed_lvCMS.Items.Add(""); for (int c = 1; c < ed_lvCMS.Columns.Count; c++) lv.SubItems.Add("");
                    lv.SubItems[13].Text = Oreadr["tmpSes_id"].ToString();
                    lv.SubItems[14].Text = Oreadr["tmpID"].ToString();

                    for (int i = 1; i < lv.SubItems.Count - 2; i++) lv.SubItems[i].Text = Oreadr[i + 2].ToString();
                    lv.Checked = (Oreadr["checked"].ToString() == "1");
                    dtot += Tools.Conv_Dbl(Oreadr["Fld9"].ToString());
                    lv.BackColor = (lv.SubItems[11].Text == "SNG" || lv.SubItems[11].Text == "OVS") ? Color.WhiteSmoke : Color.LightSkyBlue;
                }


            }
            OConn.Close();
            // if (ed_lvCMS.Items.Count > 0) 
            ltot.Text = dtot.ToString();
            ed_lvCMS.EndUpdate();


        }


        private void fill_Cms_MVT(string _SessLID, string _IrrevLID, string SA_ID)
        {
            string Cond_CMS = "";
            switch (cbCMS_old.Text)
            {
                case "Sales":
                    Cond_CMS = " AND grp='SNG' ";
                    break;
                case "Sales Overage":
                    Cond_CMS = " AND grp='OVS' ";
                    break;
                case "Agencies":
                    Cond_CMS = " AND ( grp='AGA' OR  grp='AGB'  OR  grp='AGC'  OR  grp='AGD' ) ";
                    break;
                case "Agencies Overage":
                    Cond_CMS = " AND grp='OVA' ";
                    break;
            }



            string stSql = (_IrrevLID != "") ? " select * from dbo.PSM_M_MVT_CMS where IRREVLID=" + _IrrevLID : " select * from dbo.PSM_M_MVT_CMS where SES_ID=" + _SessLID ;
            stSql += (SA_ID == "" || SA_ID  == "0") ? "" : " AND SA_LID='" + SA_ID + "'";
            stSql += (Cond_CMS == "" ) ? "" : Cond_CMS ; 
            stSql +=" Order by sMVT_ID ";

            if (_SessLID != "" || _IrrevLID != "")
            {

                ed_lvCMS.BeginUpdate();
               
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                ed_lvCMS.Items.Clear();
                double dtot = 0;
                while (Oreadr.Read())
                {
                         ListViewItem lv = ed_lvCMS.Items.Add("");
                         lv.SubItems.Add(Oreadr["SA_LID"].ToString());
                         lv.SubItems.Add(Oreadr["InvNB"].ToString());
                         lv.SubItems.Add(Oreadr["SA_Name"].ToString());
                         lv.SubItems.Add(Oreadr["Base_Amnt"].ToString());
                         lv.SubItems.Add(Oreadr["CMS_rate"].ToString());
                         lv.SubItems.Add(Oreadr["CMS_Amnt"].ToString());
                         lv.SubItems.Add(Oreadr["Curr"].ToString());
                         lv.SubItems.Add(Oreadr["cXrate"].ToString());
                         lv.SubItems.Add(Oreadr["CAD_AMNT"].ToString());
                         lv.SubItems.Add(Oreadr["MVT_Type"].ToString());
                         lv.SubItems.Add(Oreadr["grp"].ToString());
                         lv.SubItems.Add(Oreadr["IRREVLID"].ToString());
                         lv.SubItems.Add(Oreadr["SES_ID"].ToString());
                         lv.SubItems.Add(Oreadr["sMVT_ID"].ToString());

        

                }
                OConn.Close();
                ed_lvCMS.EndUpdate();
                btn_canelCMS.Enabled = (ed_lvCMS.Items.Count > 0 && MainMDI.User.ToLower() == "ede");
                
            }

        }

        private void fill_CmsOK()
        {

            ed_lvCMS.BeginUpdate();
            string stSql = " SELECT   * from  PSM_M_Tmp_CMS ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvCMS.Items.Clear();
            while (Oreadr.Read())
            {

                ListViewItem lv = ed_lvCMS.Items.Add(""); for (int c = 1; c < ed_lvCMS.Columns.Count; c++) lv.SubItems.Add("");
                lv.SubItems[13].Text = Oreadr["tmpSes_id"].ToString();
                lv.SubItems[14].Text = Oreadr["tmpID"].ToString();

                for (int i = 1; i < lv.SubItems.Count - 2; i++) lv.SubItems[i].Text = Oreadr[i + 2].ToString();
                lv.Checked = (Oreadr["checked"].ToString() == "1");


            }
            OConn.Close();
            ed_lvCMS.EndUpdate();


        }



        private void Process_CreditNote_OLD(string _RevLID, int i)
        {
            Sale_CMS[] arr_Sales = new Sale_CMS[200];
            int S = 0, A = 0;

            
            Invoice NewInv = new Invoice(ed_lvITM.Items[i].SubItems[5].Text, ed_lvITM.Items[i].SubItems[11].Text, ed_lvITM.Items[i].SubItems[1].Text, ed_lvITM.Items[i].SubItems[8].Text, ed_lvITM.Items[i].SubItems[9].Text, ed_lvITM.Items[i].SubItems[7].Text );
            NewInv.Calcul_CMS_Sale(arr_Sales, out S);

            for (int ss = 0; ss < S; ss++)
            {
                LV_AddItm(arr_Sales[ss], 'N');

            }

            



        }

        private void delete_Ovrg(string _ireevLID, string _CNnb, string _Cur_SessID)
        {
            ed_lvCMS.BeginUpdate();
            string stSql = " select * from PSM_M_MVT_CMS where IRREVLID=" + _ireevLID + " and MVT_Type='O' ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
/*
                SA_Commiss _saCMS = new SA_Commiss(Oreadr["SA_LID"].ToString(), Oreadr["SA_Name"].ToString());
                _saCMS.InvNB = _CNnb;
                _saCMS.Base_Amnt = Oreadr["Base_Amnt"].ToString();
                _saCMS.CMS_Rate = Oreadr["CMS_rate"].ToString();
                _saCMS.CMS_Amnt  = Oreadr["Base_Amnt"].ToString();
                _saCMS.CMS_Rate = (Tools.Conv_Dbl ( Oreadr["Base_Amnt"].ToString()) * -1).ToString ();
                _saCMS.C_Currency = Oreadr["Curr"].ToString();
                _saCMS.C_Xrate = Oreadr["cXrate"].ToString();
                _saCMS.CAD_AMNT = (Tools.Conv_Dbl ( Oreadr["CAD_AMNT"].ToString())* -1).ToString ();
                _saCMS.Itm_Grp = Oreadr["grp"].ToString();
                _saCMS.REVlid = Oreadr["IRREVLID"].ToString();


*/

                ListViewItem lv = ed_lvCMS.Items.Add(""); for (int c = 1; c < ed_lvCMS.Columns.Count; c++) lv.SubItems.Add("");
                lv.SubItems[13].Text = Oreadr["tmpSes_id"].ToString();
                lv.SubItems[14].Text = Oreadr["tmpID"].ToString();

                for (int i = 1; i < lv.SubItems.Count - 2; i++) lv.SubItems[i].Text = Oreadr[i + 2].ToString();
                lv.Checked = (Oreadr["checked"].ToString() == "1");


            }
            OConn.Close();
            ed_lvCMS.EndUpdate();


        }

        private void Process_CreditNote_New(string _RevLID, int i)
        {

            MessageBox.Show(" Process_CreditNote_New:  this part is not ready.......");

            /*

            double Sys_TOT = 0, PX_TOT = 0, AG_TOT = 0,PPndc=0, NDC=Tools.Conv_Dbl (ed_lvITM.Items[i].SubItems[8].Text );
            find_REV_3TOT(ed_lvITM.Items[i].SubItems[1].Text, out Sys_TOT, out PX_TOT, out AG_TOT);
            PPndc = AG_TOT  - NDC;

            if (PPndc <= Sys_TOT)
            {
                if (PPndc == Sys_TOT)
                {
                    //delete Ovrg

                   
                }
                else
                {
                    //user must fix the new SYS_TOT
                    // delete comssion 
                    //delete Ovrg
                    //Rcalculate Coms Only (sales/Agencies)  since:  SYS_TOT=NEW_SYS_TOT , PX_TOT=NEW_SYS_TOT, AG_TOT=NEW_SYS_TOT
                }
            }
            else
            {
                if (PPndc <= PX_TOT )
                {
                    //delete Ovrg
                    //Reclaculte OVRG since:  SYS_TOT=SYS_TOT , PX_TOT=PPndc, AG_TOT=PPndc
                }
                else
                {
                    //delete Ovrg
                    //Reclaculte OVRG since:  SYS_TOT=SYS_TOT , PX_TOT=PX, AG_TOT=PPndc

                }



            }
             * */

        }


        private void Process_CreditNotes()
        {

         //   Hashtable HT_Invoices = new Hashtable();
         //   Agency_CMS[] arr_Agency = new Agency_CMS[200];
            int S = 0;
  
            for (int i = 0; i < ed_lvITM.Items.Count; i++)
            {
                if (ed_lvITM.Items[i].BackColor == CLR_CMSNDC)
                {
                    if (MainMDI.Find_One_Field("select * from dbo.PSM_M_MVT_CMS where IRREVLID=" + ed_lvITM.Items[i].SubItems[1].Text) == MainMDI.VIDE)
                    {
                        Process_CreditNote_OLD(ed_lvITM.Items[i].SubItems[1].Text, i);
                    }
                    else
                    {
                        Process_CreditNote_New(ed_lvITM.Items[i].SubItems[1].Text, i);
                    }

                }

            }
        }



        private void Process_Invoices_Sales()
        {

            Hashtable HT_Invoices = new Hashtable();
            Sale_CMS[] arr_Sales = new Sale_CMS[200];
            int S = 0, A = 0;

            //init invoices & sales cumul
            HT_Invoices.Clear();
            HT_CML_Sales.Clear();

            for (int i = 0; i < ed_lvITM.Items.Count; i++)
            {
                if ((ed_lvITM.Items[i].BackColor == CLR_CMSregular || ed_lvITM.Items[i].BackColor == CLR_CMSOvrg) && !(HT_Invoices.Contains(ed_lvITM.Items[i].SubItems[1].Text)))
                {

                    Invoice NewInv = new Invoice(ed_lvITM.Items[i].SubItems[5].Text, ed_lvITM.Items[i].SubItems[11].Text, ed_lvITM.Items[i].SubItems[1].Text, ed_lvITM.Items[i].SubItems[17].Text, ed_lvITM.Items[i].SubItems[9].Text, ed_lvITM.Items[i].SubItems[7].Text);
                    NewInv.Calcul_CMS_Sale(arr_Sales, out S);

                    for (int ss = 0; ss < S; ss++)
                    {
                        LV_AddItm(arr_Sales[ss], 'R');

                    }

                    HT_Invoices.Add(ed_lvITM.Items[i].SubItems[1].Text, i.ToString()); //  HT_Invoices.Add(ed_lvITM.Items[i].SubItems[4].Text, i.ToString());
                    // ed_lvITM.Items[i].BackColor = Color.Gray;

                }

            }
        }



        private void Process_Invoices_Agency()
        {

            Hashtable HT_Invoices = new Hashtable();
            Agency_CMS[]  arr_Agency = new Agency_CMS [200];
            int S = 0;
            HT_Invoices.Clear(); 
            for (int i = 0; i < ed_lvITM.Items.Count; i++)
            {
                if ((ed_lvITM.Items[i].BackColor == CLR_CMSregular || ed_lvITM.Items[i].BackColor == CLR_CMSOvrg ) && !(HT_Invoices.Contains(ed_lvITM.Items[i].SubItems[1].Text)) && ed_lvITM.Items[i].SubItems[12].Text == "Yes")
                {

                    Invoice NewInv = new Invoice(ed_lvITM.Items[i].SubItems[5].Text, ed_lvITM.Items[i].SubItems[11].Text, ed_lvITM.Items[i].SubItems[1].Text, ed_lvITM.Items[i].SubItems[17].Text, ed_lvITM.Items[i].SubItems[9].Text, ed_lvITM.Items[i].SubItems[7].Text);
                    NewInv.Calcul_CMS_AGency (arr_Agency , out S);

                    for (int ss = 0; ss < S; ss++)   LV_AddItm(arr_Agency[ss],'A'); 

                    HT_Invoices.Add(ed_lvITM.Items[i].SubItems[1].Text, i.ToString());
                    // ed_lvITM.Items[i].BackColor = Color.Gray;

                }

            }
        }

        private void Process_Invoices_OVERG()
        {

            Hashtable HT_Invoices = new Hashtable();
            SA_Commiss[]  arr_SA = new SA_Commiss[200];
            int S = 0;
            HT_Invoices.Clear();
            for (int i = 0; i < ed_lvITM.Items.Count; i++)
            {
                if ((ed_lvITM.Items[i].BackColor == CLR_CMSOvrg ) && !(HT_Invoices.Contains(ed_lvITM.Items[i].SubItems[1].Text)) )//&& ed_lvITM.Items[i].SubItems[11].Text == "Yes")
                {

                    Invoice NewInv = new Invoice(ed_lvITM.Items[i].SubItems[5].Text, ed_lvITM.Items[i].SubItems[11].Text, ed_lvITM.Items[i].SubItems[1].Text, ed_lvITM.Items[i].SubItems[17].Text, ed_lvITM.Items[i].SubItems[9].Text, ed_lvITM.Items[i].SubItems[7].Text);
                    NewInv.Calcul_CMS_SAOVRG(ref arr_SA, Tools.Conv_Dbl(ed_lvITM.Items[i].SubItems[17].Text), Tools.Conv_Dbl(ed_lvITM.Items[i].SubItems[18].Text), Tools.Conv_Dbl(ed_lvITM.Items[i].SubItems[19].Text), out S, ed_lvITM.Items[i].SubItems[12].Text);

                    for (int ss = 0; ss < S; ss++) LV_AddItm(arr_SA[ss],'O');

                    HT_Invoices.Add(ed_lvITM.Items[i].SubItems[1].Text, i.ToString());
                    // ed_lvITM.Items[i].BackColor = Color.Gray;

                }

            }
        }


        public class Invoice
        {

            string in_InvNB = "", in_Terri = "", in_iRevID = "", in_Base_AMNT = "",in_xrate="",in_Currency="",in_YYYY="";
            EAHLibs.Lib1 Tools = new Lib1();

            public Invoice(string x_invNB, string x_Terri, string x_iRevID, string x_Base_AMNT,string x_Xrate, string x_Currency) //,string x_YYYY)
            {
                in_InvNB = x_invNB;
                in_iRevID = x_iRevID;
                in_Terri = x_Terri;
                in_Base_AMNT = x_Base_AMNT;
                in_xrate = x_Xrate;
                in_Currency = x_Currency;
               

                
            }


            public void Calcul_CMS_Sale(Sale_CMS[] arr_Sales, out int S)
            {
                if (in_Terri == "No Territory") MessageBox.Show("Error Territory for this Invoice#=" + in_InvNB  );   

                string stSql = " SELECT     PSM_C_CM_comrates.SA_ID, PSM_C_CM_comrates.Terito_LID, PSM_C_CM_comrates.Com_Rate, PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS FLName " +
                               " FROM         PSM_C_CM_comrates INNER JOIN PSM_C_ComTERITORY ON PSM_C_ComTERITORY.Terito_LID = PSM_C_CM_comrates.Terito_LID INNER JOIN PSM_SALES_AGENTS ON PSM_C_CM_comrates.SA_ID = PSM_SALES_AGENTS.SA_ID " +
                               " WHERE     (PSM_C_ComTERITORY.Terito_ABR ='" + in_Terri + "') AND (PSM_C_ComTERITORY.status = '1') and PSM_SALES_AGENTS.status='1' ";

                S=0;
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                string bas_AMNT=in_Base_AMNT;
                while (Oreadr.Read())
                {

                   
                    bool AtteintQuotas =(Tools.Conv_Dbl(Oreadr["Com_Rate"].ToString()) >0 && IsQuotasOK_sale(Oreadr["SA_ID"].ToString(), ref bas_AMNT, in_InvNB ));

                    arr_Sales[S] = new Sale_CMS(Oreadr["SA_ID"].ToString()  ,Oreadr["FLName"].ToString());
                //    double dd =Math.Round (  Tools.Conv_Dbl(in_Base_AMNT) * Tools.Conv_Dbl(in_xrate),MainMDI.NB_DEC_AFF ) ;
                    arr_Sales[S].calcul_CMS(Tools.Conv_Dbl(Oreadr["Com_Rate"].ToString()), Tools.Conv_Dbl(bas_AMNT));

                    arr_Sales[S].C_Xrate = in_xrate;
                    arr_Sales[S].C_Currency = in_Currency;
                    double dcad = (in_xrate == "1") ? arr_Sales[S].CMS_Amnt : Math.Round(Tools.Conv_Dbl(in_xrate) * arr_Sales[S].CMS_Amnt, MainMDI.NB_DEC_AFF);
                    arr_Sales[S].CAD_AMNT =(AtteintQuotas) ? dcad.ToString() : "0";

                    arr_Sales[S].REVlid = in_iRevID;
                    arr_Sales[S].InvNB = in_InvNB;
                    arr_Sales[S].Itm_Grp = "SNG";

                    S++;
                 
                }
                OConn.Close();


            }



            protected void find_Agencies(string _IRREVid,out string[,] arr_AG_info)
            {
            
               string stSql =" SELECT  PSM_R_Rev.AD, PSM_SALES_AGENTS.First_Name AS AG_D, PSM_R_Rev.AI, PSM_SALES_AGENTS_1.First_Name AS AG_IF, PSM_R_Rev.AE, PSM_SALES_AGENTS_2.First_Name AS AG_ING, PSM_R_Rev.AP, PSM_SALES_AGENTS_3.First_Name AS AG_PO " +
                             " FROM    PSM_SALES_AGENTS INNER JOIN PSM_R_Rev ON PSM_SALES_AGENTS.SA_ID = PSM_R_Rev.AD INNER JOIN " +
                                     " PSM_SALES_AGENTS AS PSM_SALES_AGENTS_1 ON PSM_R_Rev.AI = PSM_SALES_AGENTS_1.SA_ID INNER JOIN " +
                                     " PSM_SALES_AGENTS AS PSM_SALES_AGENTS_2 ON PSM_R_Rev.AE = PSM_SALES_AGENTS_2.SA_ID INNER JOIN " +
                                     " PSM_SALES_AGENTS AS PSM_SALES_AGENTS_3 ON PSM_R_Rev.AP = PSM_SALES_AGENTS_3.SA_ID " +
                                     " where IRRevID=" + _IRREVid + " and PSM_SALES_AGENTS.status='1' ";

               arr_AG_info = new string[4, 2];
               for (int c = 0; c < 4; c++) { arr_AG_info[c, 0] = ""; arr_AG_info[c, 1] = ""; }

                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                int j = 0;
                while (Oreadr.Read())
                {
                    for (int i = 0; i < 4; i++)
                    {
                        arr_AG_info[i, 0] = Oreadr[j++].ToString();
                        arr_AG_info[i, 1] = Oreadr[j++].ToString();
                    }
                }
                OConn.Close();
            
            }

            protected string Group_Name(int cod)
            {

                switch (cod)
                {
                    case 1:
                        return "GA"; //"Groupe A";
                        break;
                    case 2:
                        return "GB";
                        break;
                    case 3:
                        return "GC";
                        break;
                    case 4:
                        return "GD";
                        break;
                    

                }
                return "???????";

            }

            public void Calcul_CMS_AGency(Agency_CMS[] arr_Agency, out int S)
            {

                double[] AmntG_XA = new double[4] { 0, 0, 0, 0 };
                string[,] arr_AG_INFO = new string[4, 2];

                find_Agencies(in_iRevID, out arr_AG_INFO);

                for (int a = 0; a < 4; a++)
                    AmntG_XA[a] = Tools.Conv_Dbl(MainMDI.Find_One_Field(" SELECT SUM(PSM_Q_Details.Ext) AS Total FROM  PSM_R_Detail INNER JOIN  PSM_Q_Details ON PSM_R_Detail.Qdet_LID = PSM_Q_Details.Detail_LID " +
                               " WHERE     PSM_Q_Details.Xch_Mult =" + (a + 1).ToString() + " AND PSM_R_Detail.IRRev_LID =" + in_iRevID));

                S = 0;

                for (int i = 0; i < 4; i++)
                {
                    for (int g = 0; g < 4; g++)
                    {
                        arr_Agency[S] = new Agency_CMS(arr_AG_INFO[i, 0], arr_AG_INFO[i, 1]);
                        double Crate = Tools.Conv_Dbl(MainMDI.Find_One_Field(" SELECT Com_Rate from PSM_C_CM_comrates_AG where Terito_LID=" + (i + 1).ToString() + " and Itmgrp_LID=" + (g + 1).ToString()));
                        //   double dd = Math.Round(AmntG_XA[g] * Crate, MainMDI.NB_DEC_AFF);
                        arr_Agency[S].calcul_CMS(Crate, AmntG_XA[g]);
                        arr_Agency[S].CMS_Rate = Crate;
                        arr_Agency[S].Base_Amnt = AmntG_XA[g];

                        arr_Agency[S].C_Xrate = in_xrate;
                        arr_Agency[S].C_Currency = in_Currency;
                        double dcad = (in_xrate == "1") ? arr_Agency[S].CMS_Amnt : Math.Round(Tools.Conv_Dbl(in_xrate) * arr_Agency[S].CMS_Amnt, MainMDI.NB_DEC_AFF);
                        arr_Agency[S].CAD_AMNT = dcad.ToString();

                        arr_Agency [S].REVlid = in_iRevID;
                        arr_Agency[S].InvNB = in_InvNB;
                        arr_Agency[S].Itm_Grp ="A" + Group_Name(g + 1);
                        S++;
                    }
                }
            }



            protected void find_sales_by_Terri(string _IRREVid, ref string[,] arr_Sales_info, ref int Sales_NB)
            {



                string stSql = " SELECT     PSM_C_CM_comrates.SA_ID, PSM_C_CM_comrates.Terito_LID, PSM_C_CM_comrates.Com_Rate, PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS FLName " +
                                " FROM         PSM_C_CM_comrates INNER JOIN PSM_C_ComTERITORY ON PSM_C_ComTERITORY.Terito_LID = PSM_C_CM_comrates.Terito_LID INNER JOIN PSM_SALES_AGENTS ON PSM_C_CM_comrates.SA_ID = PSM_SALES_AGENTS.SA_ID " +
                                " WHERE     PSM_C_ComTERITORY.Terito_ABR ='" + in_Terri + "' AND PSM_C_ComTERITORY.status = '1' and PSM_SALES_AGENTS.status='1'  and PSM_SALES_AGENTS.Pager_Number ='Y' AND PSM_C_CM_comrates.Com_Rate > 0";


                arr_Sales_info = new string[NBSalesMAX, 2];
                for (int c = 0; c < NBSalesMAX; c++) { arr_Sales_info[c, 0] = ""; arr_Sales_info[c, 1] = ""; }

                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                int i = 0, j = 0;
                while (Oreadr.Read())
                {
                   // for (i = 0; i < NBSalesMAX; i++)
               
                        arr_Sales_info[i, 0] = Oreadr["SA_ID"].ToString();
                        arr_Sales_info[i++, 1] = Oreadr["FLName"].ToString();

                 
                 
                }
                Sales_NB = i;
                OConn.Close();


            }

            private void get_Agency_Benef(ref string[,] arr_AG_tmp, string[,] arr_AG_INFO, string code_Benef,ref int AG_NB)
            {
                AG_NB = 0;
                for (int x = 0; x < 4; x++) for (int y = 0; y < 2; y++) arr_AG_tmp[x, y] = ""; 
                if (code_Benef.Length == 4)
                {
                    for (int i = 0; i < 4; i++)
                    {
                        if (code_Benef[i] == '1')
                        {
                            arr_AG_tmp[i, 0] = arr_AG_INFO[i, 0];
                            arr_AG_tmp[i, 1] = arr_AG_INFO[i, 1];
                            AG_NB++;
                        }
                    }
                }
                else MessageBox.Show("Benef code is Invalid......=" + code_Benef);


            }



            public void Calcul_CMS_SAOVRG(ref SA_Commiss[] arr_SA, double _SYS_TOT, double _PX_TOT, double _AG_TOT, out int S,string AG_YN)
            {



                string[,] arr_AG_tmp = new string[4, 2];

                int Sales_NB = 0, AGency_NB = 0;
                string[,] _arr_Sales_NB = new string[NBSalesMAX, 2];
                for (int c = 0; c < NBSalesMAX; c++) { _arr_Sales_NB[c, 0] = ""; _arr_Sales_NB[c, 1] = ""; }


                string[,] arr_AG_INFO = new string[4, 2];
                find_Agencies(in_iRevID, out arr_AG_INFO);

                Hashtable HT_Frmls = new Hashtable();
              
                double d1 = Math.Round (_PX_TOT - _SYS_TOT,MainMDI.NB_DEC_AFF  );
                HT_Frmls.Add("PX-SYS",d1.ToString ());

                d1 = Math.Round(_AG_TOT - _PX_TOT, MainMDI.NB_DEC_AFF);
                HT_Frmls.Add("AG-PX", d1.ToString ());



                S = 0;
                int deb_ndx = -1, Fin_ndx = -1;
                double dd = 0;
                string stSql = (AG_YN == "No") ? "select * from PSM_C_CM_OVERAGE where typ='S' order by typ desc, rnk " : "select * from PSM_C_CM_OVERAGE order by typ desc, rnk ";
                string  opera = "";
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {

                    string st = Oreadr["Source"].ToString().Trim ();
                   string amntST = (st[0] == '!') ? HT_Frmls[st.Substring(1)].ToString() : HT_Frmls[st].ToString();

                    double AMNT = Tools.Conv_Dbl(amntST);
                    switch (Oreadr["desti"].ToString())
                    {

                        case "T":
                            AMNT = Tools.Conv_Dbl(Oreadr["rate"].ToString()) * AMNT;
                            HT_Frmls.Add(Oreadr["OvrgName"].ToString(), AMNT.ToString());
                            opera = "TT";
                            break;
                        case "A":
                            if (Oreadr["rate"].ToString() != "0") AMNT = Tools.Conv_Dbl(Oreadr["rate"].ToString()) * AMNT;
                            if (Oreadr["Benif"].ToString()[0] == '!') get_Agency_Benef(ref arr_AG_tmp, arr_AG_INFO, Oreadr["Benif"].ToString(), ref AGency_NB);
                            opera = (AGency_NB == 0) ? "fin" : "CA";
                            break;

                        case "S":
                            if (Oreadr["rate"].ToString() != "0") AMNT = Tools.Conv_Dbl(Oreadr["rate"].ToString()) * AMNT;
                            if (Oreadr["Benif"].ToString() == "!ALL") find_sales_by_Terri(in_iRevID, ref _arr_Sales_NB, ref Sales_NB);
                            //{ for (int a = 0; a < Sales_NB; a++) for (int b = 0; b < 2; b++) arr_AG_tmp[a, b] = _arr_Sales_NB[a, b]; }
                            if (Oreadr["Benif"].ToString() != "!ALL" && Oreadr["Benif"].ToString() != MainMDI.VIDE) MessageBox.Show("Sales.....Benif code Invalid......=" + Oreadr["Benif"].ToString());
                            opera = (Sales_NB == 0) ? "fin" : "CS";
                            break;
                    }

                    switch (opera)
                    {
                        case "CS":

                            dd = Math.Round(AMNT / Sales_NB, MainMDI.NB_DEC_AFF);
                            for (int l = 0; l < Sales_NB; l++)
                            {
                                arr_SA[S] = new SA_Commiss(_arr_Sales_NB[l, 0], _arr_Sales_NB[l, 1]);

                                arr_SA[S].CMS_Amnt = dd;
                                arr_SA[S].CMS_Rate = Sales_NB;
                                arr_SA[S].Base_Amnt = AMNT;

                                arr_SA[S].C_Xrate = in_xrate ;
                                arr_SA[S].C_Currency = in_Currency;
                                double dcad=(in_xrate=="1") ? dd : Math.Round (Tools.Conv_Dbl (in_xrate) * dd,MainMDI.NB_DEC_AFF );
                                arr_SA[S].CAD_AMNT = dcad.ToString();
                                arr_SA[S].REVlid = in_iRevID;
                                arr_SA[S].InvNB = in_InvNB;
                                arr_SA[S].Itm_Grp = "OVS";

                                S++;
                            }
                            break;
                        case "CA":
                            dd = Math.Round(AMNT / AGency_NB, MainMDI.NB_DEC_AFF);
                            for (int l = 0; l < AGency_NB; l++)
                            {
                                arr_SA[S] = new SA_Commiss(arr_AG_tmp[l, 0], arr_AG_tmp[l, 1]);

                                arr_SA[S].CMS_Amnt = dd;
                                arr_SA[S].CMS_Rate = AGency_NB;
                                arr_SA[S].Base_Amnt = AMNT;

                                arr_SA[S].C_Xrate = in_xrate;
                                arr_SA[S].C_Currency = in_Currency;
                                double dcad = (in_xrate == "1") ? dd : Math.Round(Tools.Conv_Dbl(in_xrate) * dd, MainMDI.NB_DEC_AFF);
                                arr_SA[S].CAD_AMNT = dcad.ToString();
                                arr_SA[S].REVlid= in_iRevID ;
                                arr_SA[S].InvNB = in_InvNB;
                                arr_SA[S].Itm_Grp = "OVA";
                                S++;
                            }

                            break;

                    }
                }
            }


           

        }

      
    

       public class SA_Commiss
        {

           private  string in_SA_LID = "",_InvNB="";
           private string in_Full_Name = "";
           public SA_Commiss(string x_SA_LID, string x_Full_Name)
           {
               in_SA_LID = x_SA_LID;
               in_Full_Name = x_Full_Name;

           }

           public string Full_Name { get { return in_Full_Name; }  private set {} }
            public double CMS_Rate { get;  set; }
            public double Base_Amnt { get;  set; }
            public double CMS_Amnt { get;  set; }
            public string C_Currency { get; set; }
            public string C_Xrate { get; set; }
            public string CAD_AMNT { get; set; }
            public string Itm_Grp{ get; set; }
            public string REVlid { get; set; }
            public string SA_LID
            {
                get { return in_SA_LID ; }
                private set {} 
            }
            public string InvNB
            {
                get { return _InvNB; }
                set { _InvNB = value; }
            }

            
   

            public virtual void calcul_CMS(double _rate, double _Base_amnt)
            {
            }
   

        }


        public class Sale_CMS : SA_Commiss
        {


            public Sale_CMS(string x_Sale_LID, string x_Full_Name) : base (x_Sale_LID, x_Full_Name)
            {

            }

            public override void calcul_CMS(double _rate, double _Base_amnt)
            {
                
                double Dcms = Math.Round((_Base_amnt * _rate) / 100 , MainMDI.NB_DEC_AFF);
                this.CMS_Rate = _rate;
                Base_Amnt = _Base_amnt;
                CMS_Amnt = Dcms; 
                
                


            }

        }

/*
       public class Agency_CMS : SA_Commiss
       {

          string in_AGLID = "";
           public Agency(string x_AG_LID)
           {
               in_AGLID = x_AG_LID;

         }

            
       }
 * */

       public class Agency_CMS: SA_Commiss
       {


           public Agency_CMS(string x_AGency_LID, string x_Full_Name)
               : base(x_AGency_LID, x_Full_Name)
           {

           }

           public override void calcul_CMS(double _rate, double _Base_amnt)
           {

               double Dcms = Math.Round((_Base_amnt * _rate) / 100, MainMDI.NB_DEC_AFF);
               this.CMS_Rate = _rate;
               Base_Amnt = _Base_amnt;
               CMS_Amnt = Dcms;

           }

       }

       private void ed_lvITM_DoubleClick(object sender, EventArgs e)
       {
           if (ed_lvITM.SelectedItems.Count == 1)
           {
               string lird = "", rvname = "";
               MainMDI.Find_2_Field("SELECT IRRevID, RRev_Name FROM PSM_R_Rev WHERE RID =" + ed_lvITM.SelectedItems[0].SubItems[2].Text, ref lird, ref rvname);

               if (lird != MainMDI.VIDE)
               {
                   lird = ed_lvITM.SelectedItems[0].SubItems[2].Text;
                   // lird = lvProj.SelectedItems[0].SubItems[12].Text;
                   MainMDI.Use_QRID(1, 'R', lird);
                   Order child_Ord = new Order(lird, rvname);
                   this.Hide();
                   child_Ord.ShowDialog();

                   this.Visible = true;

                   MainMDI.Use_QRID(0, 'R', lird);
                   child_Ord.Close();
                   child_Ord.Dispose();

               }

           }
       }

       private void find_CMSUSR()
       {
           CMS_USR ='?';
            if (MainMDI.ALWD_USR("C_CMS", false)) CMS_USR ='C';
            if (MainMDI.ALWD_USR("A_CMS", false)) CMS_USR ='A';
            if (MainMDI.ALWD_USR("V_CMS",false)) CMS_USR ='V';
   //         if (MainMDI.ALWD_USR("M_CMS", false)) CMS_USR = 'M';
            if (MainMDI.profile == 'S') CMS_USR = 'S';

       }


        private void fill_HTAgencies()
        {
            if (Curr_SaleID != MainMDI.VIDE)
            {
                string stSql = " SELECT distinct  First_Name, Sale_MGR, SA_ID " +
                               " FROM   PSM_SALES_AGENTS WHERE     SA = 'A' AND status = '1' AND Sale_MGR =" + Curr_SaleID;

                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())     HT_Agencies.Add ( Oreadr[0].ToString ().Trim(),  Oreadr[1].ToString ());
                OConn.Close();
                

            }
            

        }



       private void CMS_invLIST_Load(object sender, EventArgs e)
       {

           if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
           picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
           
           grpInv.Dock = (grpCMS.Visible) ? DockStyle.Top : DockStyle.Fill;
           
          MainMDI.Find_2_Field("select SES_ID, Date_UPto , SES_Date from PSM_M_Sessions where status='T'",ref SES_LID, ref Date_UPto, ref DateSess  );
          dpTO.Text = (SES_LID != MainMDI.VIDE) ? Date_UPto : DateTime.Now.ToShortDateString();
          dpSes.Text  = (DateSess  != MainMDI.VIDE) ? DateSess  : DateTime.Now.ToShortDateString();
          if (SES_LID != MainMDI.VIDE) List_Invoices();
          find_CMSUSR();
          Enable_Disable_Disp();
          string stSql = "select SA_ID, First_Name + ' ' + Last_Name from PSM_SALES_AGENTS inner join PSM_users_New on PSM_users_New.userID=PSM_SALES_AGENTS.PGC_login where SA='S' and status='1' and [PSM_users_New].[user]='" + MainMDI.User + "'";
          MainMDI.Find_2_Field(stSql,ref Curr_SaleID,ref Curr_saleFLName);
          fill_HTAgencies();
          if ((Curr_SaleID == MainMDI.VIDE || Curr_SaleID == MainMDI.VIDE) && MainMDI.User.ToLower() != "ede" && MainMDI.User.ToLower() != "hnasrat" && CMS_USR !='C')
          {
              grpITM.Enabled = false;
              grpInv.Visible = false; 
              MessageBox.Show("Invalid User.........Exit and check with your Admin.....!!!!!");
             // for (int i = 0; i < 7; i++) dp.Items[i].Visible = false;
              this.Hide();
          }
          fill_cbSales();
          cbCMStype.Text = "ALL";
          cbCMS_old.Text = "ALL";

          xl.Visible = true;// (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "mmellouli");
          

       }



       private void Enable_Disable_Disp()
       {
           for (int i=0;i<dp.Items.Count -1  ;i++) dp.Items[i].Visible =false;
           lDateTo.BringToFront();
           btnCALC_CMS.Visible = false;
           btn_SaveCms.Visible = false;
           picInvlist.Visible = false;
           chk_Inv.Visible = false;
           chkZero.Visible = false;
           grpBySA.Visible = false;
           btnSndAcct.Visible = false;
           tsb_saleAcct.Visible = true;
           btnSvSess.Visible = false;
            cbSales.Visible = true;


            tsb_oldMVT.Visible = true;
         
           switch (CMS_USR)
           {
               case 'C':
                   NewSess.Visible = true;
                //   btn_Sav.Visible = true;
                   tsb_InvList.Visible = true;
                   fix.Visible = true;
                   ts_CMS.Visible = true;
                   btn_NC.Visible = true;
                   btnSvSess.Visible = true;
                  
                   picInvlist.Visible = true;
                   btnCALC_CMS.Visible = true;
                   btn_SaveCms.Visible = true;
                   chk_Inv.Visible = true;
                   chkZero.Visible = true;
                   grpBySA.Visible = true;
                   btnSndAcct.Visible = true;
                   tsb_oldMVT.Visible = true;
                 
                   
                   break;
               case 'S':
                   for (int i = 0; i < dp.Items.Count ; i++) dp.Items[i].Visible = true;
                   tsb_SAles_gest.Visible = MainMDI.User.ToLower() == "ede";
                   tsb_AG_gest.Visible = MainMDI.User.ToLower() == "ede";

                   btnSvSess.Visible = true;
                   btnCALC_CMS.Visible = true;
                   btn_SaveCms.Visible = true;
                   picInvlist.Visible = true;
                   chk_Inv.Visible = true;
                   chkZero.Visible = true;
                   picInvlist.Visible = true;
                   grpBySA.Visible = true;
                   btnSndAcct.Visible = true;
             
                   break;
               case 'V':
                   ts_CMS.Visible = true;
                   tsb_InvList.Visible = true;
                   btn_SaveCms.Visible = true; 
                   break;
               case 'M':
                   ts_CMS.Visible = true;
                   tsb_InvList.Visible = true;
                   btn_SaveCms.Visible = true;
                   break;

               case 'A':
                   ts_CMS.Visible = true;
                   cbSales.Text = Curr_saleFLName;
                   cbSales.Visible = false;
                   fill_Cms(cbSales.Text);
                   lSelTOT.Text = "";
              //     btn_SaveCms.Visible = true; 
                   break;

           }
           tsb_InvList.Visible = true;
           btnclear.Visible = btnSndAcct.Visible;
        //  xl.Visible = grpCMS.Visible;
         //  fix.Visible = grpInv.Visible;
       }


       private void SA_Manage(char sa)
       {
           dlg_Sales_Agencies SA_gest = new dlg_Sales_Agencies(sa);
           SA_gest.ShowDialog();
           SA_gest.Dispose();
       }
       private void tsb_SAles_gest_Click(object sender, EventArgs e)
       {
           SA_Manage('S');
       }

       private void tsb_AG_gest_Click(object sender, EventArgs e)
       {
           SA_Manage('A');
       }

       private void btnCALC_CMS_Click(object sender, EventArgs e)
       {
           string count = MainMDI.Find_One_Field("select tmpID from PSM_M_Tmp_CMS");

           HT_CML_Sales.Clear();  //init cumul sales
           Curr_YYYY = dpTO.Value.Year.ToString();
           
           if (ed_lvITM.Items.Count > 0 && count == MainMDI.VIDE)
           {
               ed_lvCMS.Items.Clear();
               //  MainMDI.Exec_SQL_JFS("delete PSM_M_Tmp_CMS ", " CMS....Delete current TMP_CMS...(recalculating...)");
               Calc_CMS();
               btnSndAcct.Enabled = false;
           }
           else if (count != MainMDI.VIDE) MessageBox.Show("Sorry,  Current calculations must be sent to Accounts ........");  
       }


      public static bool IsQuotasOK_saleOLD(string _SA_LID, string bas_Amnt ,string BilNO)
       {


           double quotas =Tools.Conv_Dbl (  MainMDI.Find_One_Field("select quotas from PSM_SALES_AGENTS where SA_ID=" + _SA_LID));
           double dd = 0;
           string amnt = "0";
           if (HT_CML_Sales.Contains (_SA_LID))
           {
               amnt = HT_CML_Sales[_SA_LID].ToString();
               dd = Convert.ToDouble(amnt) + Convert.ToDouble(bas_Amnt);
               HT_CML_Sales[_SA_LID] = dd.ToString();



           }

           else
           {

               string stSql = " SELECT     SUM(PSM_M_MVT_CMS.Base_Amnt) AS year_Tot,PSM_SALES_AGENTS.quotas " +
                              " FROM  PSM_M_MVT_CMS INNER JOIN PSM_M_Sessions ON PSM_M_Sessions.SES_ID = PSM_M_MVT_CMS.SES_ID INNER JOIN  PSM_SALES_AGENTS ON PSM_M_MVT_CMS.SA_LID = PSM_SALES_AGENTS.SA_ID " +
                              " GROUP BY SUBSTRING(PSM_M_Sessions.Date_UPto, 1, 4), PSM_M_MVT_CMS.SA_LID, PSM_SALES_AGENTS.quotas " +
                              " HAVING      (PSM_M_MVT_CMS.SA_LID =" + _SA_LID + ") AND (SUBSTRING(PSM_M_Sessions.Date_UPto, 1, 4) = '" +Curr_YYYY  + "')";

              
               dd =  Tools.Conv_Dbl(MainMDI.Find_One_Field(stSql )) + Convert.ToDouble(bas_Amnt);
               HT_CML_Sales.Add (_SA_LID,dd.ToString());


           }

           return (dd > quotas);


       }

      public static bool IsQuotasOK_sale(string _SA_LID,ref  string bas_Amnt, string BilNO)
      {

          bool res = false;
          double quotas = Tools.Conv_Dbl(MainMDI.Find_One_Field("select quotas from PSM_SALES_AGENTS where SA_ID=" + _SA_LID));
          double dd = 0, CML_Sales = 0, AMnt=Tools.Conv_Dbl(bas_Amnt);


        
          if (!HT_CML_Sales.Contains(_SA_LID))
          {

              string stSql = " SELECT     SUM(PSM_M_MVT_CMS.Base_Amnt) AS year_Tot,PSM_SALES_AGENTS.quotas " +
                             " FROM  PSM_M_MVT_CMS INNER JOIN PSM_M_Sessions ON PSM_M_Sessions.SES_ID = PSM_M_MVT_CMS.SES_ID INNER JOIN  PSM_SALES_AGENTS ON PSM_M_MVT_CMS.SA_LID = PSM_SALES_AGENTS.SA_ID " +
                             " GROUP BY SUBSTRING(PSM_M_Sessions.Date_UPto, 1, 4), PSM_M_MVT_CMS.SA_LID, PSM_SALES_AGENTS.quotas " +
                             " HAVING      (PSM_M_MVT_CMS.SA_LID =" + _SA_LID + ") AND (SUBSTRING(PSM_M_Sessions.Date_UPto, 1, 4) = '" + Curr_YYYY + "')";


              dd = Tools.Conv_Dbl(MainMDI.Find_One_Field(stSql));
              HT_CML_Sales.Add(_SA_LID, dd.ToString());


          }

          CML_Sales = Tools.Conv_Dbl(HT_CML_Sales[_SA_LID].ToString());

          if (CML_Sales >= quotas) res = true;
          else if ((CML_Sales + AMnt ) > quotas ) { res= true; bas_Amnt = (quotas - (CML_Sales + AMnt )).ToString ();}

       
          HT_CML_Sales[_SA_LID] = (CML_Sales  + AMnt).ToString();

          if (_SA_LID == "17") dd = dd;

          return res;


      }


       private void fill_cbSales()
       {

           string stSql = "SELECT SA_Name, SA_LID from V_SA_in_TMP_CMS ORDER BY SA DESC, SA_Name";
           string stSql_OLD = "select First_Name + ' ' + Last_Name as FL,SA_ID from PSM_SALES_AGENTS where status='1' ORDER BY SA DESC, FL ";

           MainMDI.fill_Any_CB(cbSales, stSql, true,"ALL");
           MainMDI.fill_Any_CB(cbSales_old ,stSql_OLD , true, "ALL");

       }
       private void btn_SaveCms_Click(object sender, EventArgs e)
       {
           this.Cursor = Cursors.WaitCursor;
           Save_tmpCMS();
           btnSndAcct.Enabled = true;
        //   fill_Cms("ALL");
           fill_Cms(lsale.Text  );
           fill_cbSales();
           grpBySA.Visible = ed_lvCMS.Items.Count > 0;
           this.Cursor = Cursors.Default;
       }

        private void SaveSess()
        {
            Wait_msg(true);
            SES_LID = "";
            Save_TMPSession ();
       //     ed_lvITM.Items.Clear();  
            string st=MainMDI.Find_One_Field("select SES_ID from PSM_M_Sessions where status='T'");
            SES_LID = (st!=MainMDI.VIDE ) ? st : "" ;
            Wait_msg(false);
        }

        private void dp_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {
            
        }
        private void get_Table_Flds_MSoft(string TablName, ref string[,] _arr_Flds)
        {


            string stSql = " SELECT * from " + TablName;
            int f = 0;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            DataTable OschemaTable;
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();      //myReader = cmd.ExecuteReader(CommandBehavior.KeyInfo);
            OschemaTable = Oreadr.GetSchemaTable();
            foreach (DataRow _DRw in OschemaTable.Rows)
            {
                    foreach (DataColumn _DCol in OschemaTable.Columns)
                      {
                         MessageBox.Show(_DCol.ColumnName + "  type=" + _DCol.DataType.ToString() + " property=" + _DRw[_DCol].ToString());
                     }
            }
            Oreadr.Close();
            OConn.Close();


        }
       




        private void send_TOAcct()
        {
            bool Cont = true;

            int _NBflds = 0;
            //for sales checking
    //        for (int i = 0; i < ed_lvCMS.Items.Count && (Cont); i++) if (!ed_lvCMS.Items[i].Checked) Cont = false;
                                          //for (int i = 0; i < Max_Flds_Vals; i++) for (int j = 0; j < Max_Flds_Vals; j++) in_arr_Vals[i, 1] = "0";
            if (Cont)
            {
                string oldInv="";
                for (int i = 0; i < ed_lvCMS.Items.Count; i++)
                {
                    RW_data my_RWdata = new RW_data("PSM_M_MVT_CMS");
                    my_RWdata.init_Arrs(ref G_arr_Vals ); 
                   my_RWdata.get_Table_Flds (ref G_arr_Flds , ref _NBflds );
                    G_arr_Vals [0, 0] = "";
                    G_arr_Vals[1, 0] = ed_lvCMS.Items[i].SubItems[13].Text; //SES_ID
                    G_arr_Vals[2, 0] = ed_lvCMS.Items[i].SubItems[12].Text; //Irrevlid
                    G_arr_Vals[3, 0] = ed_lvCMS.Items[i].SubItems[2].Text; //INV#
                    G_arr_Vals[4, 0] = ed_lvCMS.Items[i].SubItems[1].Text;  //SAlid
                    G_arr_Vals[5, 0] = ed_lvCMS.Items[i].SubItems[3].Text;  //SA name
                    G_arr_Vals[6, 0] = ed_lvCMS.Items[i].SubItems[4].Text;  //BA amnt
                    G_arr_Vals[7, 0] = ed_lvCMS.Items[i].SubItems[5].Text;  //cms rate
                    G_arr_Vals[8, 0] = ed_lvCMS.Items[i].SubItems[6].Text;  //CMS amnt
                    G_arr_Vals[9, 0] = ed_lvCMS.Items[i].SubItems[7].Text;  //currency
                    G_arr_Vals[10, 0] = ed_lvCMS.Items[i].SubItems[8].Text;  //X rate
                    G_arr_Vals[11, 0] = ed_lvCMS.Items[i].SubItems[9].Text;  //CAD amnt
                    G_arr_Vals[12, 0] = ed_lvCMS.Items[i].SubItems[10].Text;  //mvt_type
                    G_arr_Vals[13, 0] = ed_lvCMS.Items[i].SubItems[11].Text;  //grp
            
                    string _RID=MainMDI.Find_One_Field("select RID from  PSM_R_Rev where IRRevID=" + ed_lvCMS.Items[i].SubItems[12].Text) ;
                   my_RWdata.Insert_data(G_arr_Flds , G_arr_Vals ,_NBflds );
        // to check.....&&&&&&&&&&   
                   if (oldInv != ed_lvCMS.Items[i].SubItems[12].Text) Maj_Comm_Inv(ed_lvCMS.Items[i].SubItems[12].Text, ed_lvCMS.Items[i].SubItems[2].Text,"1");
                   MainMDI.save_Trs_cmsACCT (ed_lvCMS.Items[i].SubItems[1].Text,dpTO.Value.ToShortDateString ()  , "C","CMS / P"+_RID  , ed_lvCMS.Items[i].SubItems[9].Text, "");
                }
                MainMDI.Exec_SQL_JFS("delete PSM_M_Tmp_CMS ", " CMS....Delete current TMP_CMS...(send to accounts...)");
                MainMDI.Exec_SQL_JFS("Update  PSM_M_Sessions set [status]='C' where SES_ID=" + SES_LID, " CMS close session ");

            }
            else MessageBox.Show("All calculations must be validated (checked OK) .......");

        }

        private void Cancel_TOAcct()
        {
            bool Cont = true;

            int _NBflds = 0;
          //  for (int i = 0; i < ed_lvCMS.Items.Count && (Cont); i++) if (!ed_lvCMS.Items[i].Checked) Cont = false;
            //for (int i = 0; i < Max_Flds_Vals; i++) for (int j = 0; j < Max_Flds_Vals; j++) in_arr_Vals[i, 1] = "0";
                string oldInv = "";
                for (int i = 0; i < ed_lvCMS.Items.Count; i++)
                {
                    RW_data my_RWdata = new RW_data("PSM_M_MVT_CMS");
                    my_RWdata.init_Arrs(ref G_arr_Vals);
                    my_RWdata.get_Table_Flds(ref G_arr_Flds, ref _NBflds);
                
                    double d_amnt = (-1) * Tools.Conv_Dbl(ed_lvCMS.Items[i].SubItems[6].Text);  //(d_amnt >= 0) ? d_amnt : (-1) * d_amnt;
                    double cad_d_amnt = (-1) * Tools.Conv_Dbl(ed_lvCMS.Items[i].SubItems[9].Text); 
                  
                    G_arr_Vals[0, 0] = "";
                    G_arr_Vals[1, 0] = ed_lvCMS.Items[i].SubItems[13].Text; //SES_ID
                    G_arr_Vals[2, 0] = ed_lvCMS.Items[i].SubItems[12].Text; //Irrevlid
                    G_arr_Vals[3, 0] = ed_lvCMS.Items[i].SubItems[2].Text; //INV#
                    G_arr_Vals[4, 0] = ed_lvCMS.Items[i].SubItems[1].Text;  //SAlid
                    G_arr_Vals[5, 0] = ed_lvCMS.Items[i].SubItems[3].Text;  //SA name
                    G_arr_Vals[6, 0] = ed_lvCMS.Items[i].SubItems[4].Text;  //BA amnt
                    G_arr_Vals[7, 0] = ed_lvCMS.Items[i].SubItems[5].Text;  //cms rate
                    G_arr_Vals[8, 0] = d_amnt.ToString();// ed_lvCMS.Items[i].SubItems[6].Text;  //CMS amnt
                    G_arr_Vals[9, 0] = ed_lvCMS.Items[i].SubItems[7].Text;  //currency
                    G_arr_Vals[10, 0] = ed_lvCMS.Items[i].SubItems[8].Text;  //X rate
                    G_arr_Vals[11, 0] = cad_d_amnt.ToString(); // ed_lvCMS.Items[i].SubItems[9].Text;  //CAD amnt
                    G_arr_Vals[12, 0] = ed_lvCMS.Items[i].SubItems[10].Text;  //mvt_type
                    G_arr_Vals[13, 0] = ed_lvCMS.Items[i].SubItems[11].Text;  //grp

                    string _RID = MainMDI.Find_One_Field("select RID from  PSM_R_Rev where IRRevID=" + ed_lvCMS.Items[i].SubItems[12].Text);
                    my_RWdata.Insert_data(G_arr_Flds, G_arr_Vals, _NBflds);
     
                    if (oldInv != ed_lvCMS.Items[i].SubItems[12].Text) Maj_Comm_Inv(ed_lvCMS.Items[i].SubItems[12].Text, ed_lvCMS.Items[i].SubItems[2].Text,"0");
                    MainMDI.save_Trs_cmsACCT(ed_lvCMS.Items[i].SubItems[1].Text, "", "D", "CMS Cancel / P" + _RID, ed_lvCMS.Items[i].SubItems[9].Text, ""); //delete /cancel cms
                }
              //  MainMDI.Exec_SQL_JFS("delete PSM_M_Tmp_CMS ", " CMS....Delete current TMP_CMS...(send to accounts...)");
             //   MainMDI.Exec_SQL_JFS("Update  PSM_M_Sessions set [status]='C' where SES_ID=" + SES_LID, " CMS close session ");


        }



        private void Maj_Comm_InvOKold(string _RRevlid, string InvNB)
        {
            if (MainMDI.Find_One_Field ("select  Bil_LID from PSM_R_SBills where AccInv='" + InvNB +"'")!=MainMDI.VIDE )
                MainMDI.Exec_SQL_JFS("update PSM_R_SBills set [Com]='1' where b_RRevLID=" + _RRevlid , "CMS update com(ed) bills..."); 
            else  MainMDI.Exec_SQL_JFS("update PSM_R_SBills_NC set [COM]='1' where AccInv='" + InvNB +"'" , "CMS update com(ed) Credit notes..");       
        }
        private void Maj_Comm_Inv(string _RRevlid, string InvNB,string cod)
        {
     
            string msg = (cod == "0") ? " (CMS cancel) " : " (CMS Add) ";
            if (MainMDI.Find_One_Field("select  Bil_LID from PSM_R_SBills where AccInv='" + InvNB + "'") != MainMDI.VIDE)
                MainMDI.Exec_SQL_JFS("update PSM_R_SBills set [Com]='" + cod + "' where b_RRevLID=" + _RRevlid, "CMS update com(ed) bills..."+msg);
            else MainMDI.Exec_SQL_JFS("update PSM_R_SBills_NC set [COM]='" + cod + "' where AccInv='" + InvNB + "'", "CMS update com(ed) Credit notes.."+msg);
        }
        private void btnSndAcct_Click(object sender, EventArgs e)
        {
            if (MainMDI.Confirm("Want to Send Calculations to Accounts ? "))
            {
                cbSales.Text = "ALL";
                cbCMStype.Text = "ALL";
                fill_Cms("ALL");
                
                this.Cursor = Cursors.WaitCursor;

                send_TOAcct();// ############# a retester apres avoir init des bills com = 0     envir=TU

                fill_Cms("ALL");

                this.Cursor = Cursors.Default;
            }
        }
/*
        public class RW_data
        {
           

            string in_Tblname = "";

            public RW_data(string x_TblName) //string[,] x_arr_Flds, string[] x_arr_Vals)
            {
                in_Tblname = x_TblName;
            }

            public void Insert_data(string[,] x_arr_Flds, string[,] x_arr_Vals, int ItmsNB)
            {


                string fields = "", val = " ) VALUES (", stSql = "INSERT INTO " + in_Tblname + " ("; ;
                for (int i = 1; i < ItmsNB; i++)   //x_arr_flds[0]==LID     ..........x_arr_Flds[i,0][0]....1=update  0=no / x_arr_Flds[i,0][1]....1=add "'"  0=no
                {
                    fields += (i == 1) ? " [" + x_arr_Flds[i, 0] + "]" : ", " + " [" + x_arr_Flds[i, 0] + "]";
                    string _VVV = (x_arr_Flds[i, 1] == "0") ? x_arr_Vals[i,0] : "'" + x_arr_Vals[i,0] + "'";
                    val += (i == 1) ? _VVV : ", " + _VVV;

                }
                stSql += fields + val + ")";
                MainMDI.Exec_SQL_JFS(stSql, "INSERT..." + in_Tblname);
            }

            public void Update_data(string[,] x_arr_Flds, string[,] x_arr_Vals, int ItmsNB)
            {


                string fields = "", stSql = "UPDATE " + in_Tblname + " SET ";
                for (int i = 1; i < ItmsNB; i++)   //x_arr_flds[0]==LID     ..........x_arr_Flds[i,0][0]....1=update  0=no / x_arr_Flds[i,0][1]....1=add "'"  0=no
                {
                    if (x_arr_Flds[i, 0][0] == '1')
                    {
                        fields = "[" + x_arr_Flds[i, 0] + "]=";
                        string _VVV = (x_arr_Vals[i, 1] == "0") ? x_arr_Vals[i,0] : "'" + x_arr_Vals[i,0] + "'";
                        stSql += (i == 1) ? fields + _VVV : ", " + fields + _VVV;

                    }

                }
                stSql += ") where " + x_arr_Flds[0, 0] + " = " + x_arr_Vals[0,0];
                MainMDI.Exec_SQL_JFS(stSql, "UPDATE..." + in_Tblname);

            }
            private string use_appostrof(string _typ)
            {
                string res = "3";
                switch (_typ)
                {
                    case "bigint":
                    case "int":
                    case "float":
                    case "smalldatetime":
                        res = "0";
                        break;
                    case "nvarchar":
                    case "varchar":
                    case "nchar":
                        res = "1";
                        break;
                }
                if (res == "3") MessageBox.Show("Error......type=" + _typ + "  Invalid in use_appostrof.....");
                return res;



            }

            public void get_Table_Flds( ref string[,] _arr_Flds, ref  int _NBfld)
            {


                string stSql = " SELECT COLUMN_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_NAME ='" + in_Tblname  + "'";
                int f = 0;
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                int i = 0;
                while (Oreadr.Read())
                {
                    _arr_Flds[i, 0] = Oreadr["COLUMN_NAME"].ToString();
                    _arr_Flds[i++, 1] = use_appostrof(Oreadr["DATA_TYPE"].ToString());
                }
                Oreadr.Close();
                OConn.Close();
                _NBfld = i;


            }
            public void init_Arrs(ref string[,] _arr_Vals )
            {
                for (int i = 0; i < Max_Flds_Vals; i++) 
                    for (int j = 0; j < Max_Flds_Vals; j++) _arr_Vals[i, 1] = "0";
            }
        }
*/


        private void btn_Sav_Click(object sender, EventArgs e)
        {
            if (ed_lvITM.Visible )  SaveSess();
        }

        private void btn_SaveSess_Click(object sender, EventArgs e)
        {

        }

        private void tsb_InvList_Click(object sender, EventArgs e)
        {
            List_Invoices();
            
        }

        private void picInvlist_Click(object sender, EventArgs e)
        {
            List_Invoices();
        }

        private void dpSes_ValueChanged(object sender, EventArgs e)
        {
            ldpSes.Text = dpSes.Text;  
        }

        private void ts_CMS_Click(object sender, EventArgs e)
        {
           

            fill_Cms("ALL");
          // if (cbSales.Items.Count <1) 
            fill_cbSales();   
            disp_grp('C' );
            Enable_Disable_Disp();
            
           grpBySA.Visible = ed_lvCMS.Items.Count > 0;

           fix.Visible = grpInv.Visible;
        }

        private void NewSess_Click(object sender, EventArgs e)
        {
            disp_grp('I');
            ed_lvITM.Items.Clear();
            dpSes.Text = DateTime.Now.ToShortDateString();
            dpTO.BringToFront();
            dpFrom.Enabled = MainMDI.User.ToLower() == "ede";  
            // List_Invoices();
        }

        private void cbSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            lsale.Text = cbSales.Text;
           btn_SUM.Enabled  = (lsale.Text.ToUpper() == "ALL"); 
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

            xl.Visible = true;// (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "mmellouli");


            fill_Cms(cbSales.Text);
            lSelTOT.Text = ""; 
        }

        private void tsb_saleAcct_Click(object sender, EventArgs e)
        {
         /*   
            ComboBox _CB = new ComboBox();
            for (int i = 1; i < cbSales.Items.Count; i++)
            {
                System.Web.UI.WebControls.ListItem itm = (System.Web.UI.WebControls.ListItem)cbSales.Items[i];
                switch (CMS_USR)
                {
                    case 'C':
                    case 'S':
                        if (itm.Text.ToLower() != "all") _CB.Items.Add(itm);
                        break;
                    case 'V':
                        if (Curr_saleFLName == itm.Text || HT_Agencies.Contains(itm.Text)) _CB.Items.Add(itm);
                        break;
                    case 'A':
                        if (Curr_saleFLName == itm.Text) _CB.Items.Add(itm);
                        break;
                }
            }
*/
            dlg_CMS_Accounts dlg_ACC = new dlg_CMS_Accounts(CMS_USR,Curr_saleFLName ,Curr_SaleID );
            dlg_ACC.ShowDialog();
 
        }

        private void btnSvSess_Click(object sender, EventArgs e)
        {

       
            if (ed_lvITM.Visible && ed_lvITM.Items.Count > 0)
            {
                SaveSess();
                if (MainMDI.Confirm("Want to send E-mail to ALL SALES ? "))
                  //  Send_email_ALL_SALES(" FROM: " + MainMDI.Eng_date(dpFrom.Value.ToShortDateString(), "/") + " TO: " + MainMDI.Eng_date(dpTO.Value.ToShortDateString(), "/"));
                       Send_email_ALL_SALES(MainMDI.Eng_date(dpTO.Value.ToShortDateString(), "/"));
            }
        }


        private void Send_email_ALL_SALES(string period)
        {




            string stSql = " select First_Name + ' ' + Last_Name as FLName, Email_Address from dbo.PSM_SALES_AGENTS where SA='S' and [Fax Number]='C' and Email_Address<>'n/a' ";


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();   
            ed_lvCMS.Items.Clear();

            while (Oreadr.Read())
            {
                string FLName = Oreadr["FLName"].ToString();
                string email = Oreadr["Email_Address"].ToString();
                if (email != MainMDI.VIDE && MainMDI.emailIsValid(email))
                {

                    string FromAdrs = "PGESCOM_Admin@primax-e.com";
                    string Subject = "Commissions of period: " + period +" will be proccessed soon ....." ;
                    string Body = "Hi, \n Commissions for period: " + period + " will be proccessed soon , Please could check Invoices and projects listed in PGESCOM Commissions menu \n" +
                        "Thank you. \n \n";// +MainMDI.Outlk_CR + MainMDI.Outlk_CR;

                   MainMDI.send_email (FromAdrs, email + ", hedebbab@primax-e.com", Subject, Body);
                  //    MainMDI.send_email (FromAdrs, "hedebbab@primax-e.com", Subject, Body); //send only to admin for testing

                    MainMDI.Write_JFS("Save session......email sent to sale : " + FLName);
                }
                else MainMDI.Write_XadminLog("email is invalid for This Sale: " + FLName, " Commissions, save session, send email... ");


            }

            OConn.Close();
            
            
        }


        private void chk_all_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < ed_lvCMS.Items.Count; i++)
                ed_lvCMS.Items[i].Checked = chk_all.Checked;   
        }

        private void fill_Sess()
        {

            string stSql = "SELECT Date_UPto, SES_ID from PSM_M_Sessions where status='C' ORDER BY Date_UPto";
            MainMDI.fill_Any_CB(cbSess , stSql,true, " ");

        }
        
        private void tsb_oldMVT_Click(object sender, EventArgs e)
        {
            ed_lvCMS.Items.Clear();
            btn_canelCMS.Enabled = false; 
            fill_Sess();
            disp_grp('H');
            grpBySA.Visible = ed_lvCMS.Items.Count > 0;
        }

        private void cbSess_SelectedIndexChanged(object sender, EventArgs e)
        {
           lSessLID.Text = MainMDI.get_CBX_value(cbSess, cbSess.SelectedIndex);
   //         fill_Cms_MVT(lSessLID.Text, "");
    //       btn_canelCMS.Enabled = ed_lvCMS.Items.Count > 0;

        }


        private void picLIDseek_Click(object sender, EventArgs e)
        {
            if (cbSess.Text.Length > 4)
            {

                xl.Visible = true;// (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "mmellouli");

                string res = (txINV.Text == "") ? "" : MainMDI.Find_One_Field("select IRRevID from PSM_R_Rev inner join PSM_R_SBills on b_RRevLID=IRRevID where AccInv='" + txINV.Text + "'");
                txRevLID.Text = (res != MainMDI.VIDE) ? res : "";
                fill_Cms_MVT(lSessLID.Text, txRevLID.Text, lsaID.Text);
                string YYYY = cbSess.Text.Substring(0, 4); ;
                lSalesTOT.Text = YearSalesTOT_OLDSESSION(YYYY);
            }
            
          //  btn_canelCMS.Enabled = (ed_lvCMS.Items.Count > 0 && MainMDI.User.ToLower() == "ede");

        }




        private string YearSalesTOT_OLDSESSION(string _YYYY)
        {

           
            string stSql = " SELECT     SUM(PSM_M_MVT_CMS.Base_Amnt) AS year_Tot,PSM_SALES_AGENTS.quotas " +
               " FROM  PSM_M_MVT_CMS INNER JOIN PSM_M_Sessions ON PSM_M_Sessions.SES_ID = PSM_M_MVT_CMS.SES_ID INNER JOIN  PSM_SALES_AGENTS ON PSM_M_MVT_CMS.SA_LID = PSM_SALES_AGENTS.SA_ID " +
               " GROUP BY SUBSTRING(PSM_M_Sessions.Date_UPto, 1, 4), PSM_M_MVT_CMS.SA_LID, PSM_SALES_AGENTS.quotas " +
               " HAVING      (PSM_M_MVT_CMS.SA_LID =" +lsaID.Text  + ") AND (SUBSTRING(PSM_M_Sessions.Date_UPto, 1, 4) = '" + _YYYY + "')";

            return MainMDI.Find_One_Field (stSql ) ;
        }



        private void btn_canelCMS_Click(object sender, EventArgs e)
        {
            if (MainMDI.Confirm ("Want to Cancel Commissions ?"))
            {
           this.Cursor = Cursors.WaitCursor;

            Cancel_TOAcct ();// ############# a retester apres avoir init des bills com = 0     envir=TU

            fill_Cms_MVT(lSessLID.Text, txRevLID.Text, lsaID.Text);  //fill_Cms_MVT("", txRevLID.Text);

            this.Cursor = Cursors.Default;
            }
        }

        private void picSel_Click(object sender, EventArgs e)
        {
            if (ed_lvCMS.SelectedItems.Count > 0)
            {
                double dd = 0;
                for (int i = 0; i < ed_lvCMS.SelectedItems.Count; i++)
                {
                    dd += Tools.Conv_Dbl(ed_lvCMS.Items[ed_lvCMS.SelectedItems[i].Index ].SubItems [9].Text   );
                }
                lSelTOT.Text = dd.ToString(); 
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            if (MainMDI.Confirm("Want to DELETE Temporary Calculations ? "))
            {
               string  stSql = "delete PSM_M_Tmp_CMS "; MainMDI.Exec_SQL_JFS(stSql, " CMS....Delete current TMP_CMS...");
                fill_Cms("ALL");
            }
        }



        private void write_XL_CMS()
        {
/*
            System.IO.File.Delete(MainMDI.XL_Path + @"\CMS_CALC.xls");
            Object m_objOpt = System.Reflection.Missing.Value;
            Excel.Application m_objXL = new Excel.Application();
            Excel.Workbooks m_objbooks = m_objXL.Workbooks;
            Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);
            Excel.Sheets m_objSheets = m_objBook.Worksheets;
            Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

            object[] objHdrs = { "Invoice #", "Sale / Agency Name", "Base Amount", "Commission %", "Commission Amount", "Currency", "Xchange rate ", "Commission Amount (CAD)" };
            Excel.Range m_objRng = m_objSheet.get_Range("A1", "H1");
            m_objRng.Value2 = objHdrs;
            Excel.Font m_objFont = m_objRng.Font;
            m_objFont.Bold = true;

            object[,] objData = new object[MainMDI.MAX_XLlines_XPRT, 8];
            for (int i = 0; i < MainMDI.MAX_XLlines_XPRT; i++)
            {

                for (int j = 0; j < 8; j++)
                {
                    if (i < ed_lvCMS.Items.Count) objData[i, j] = (j != 7) ? "'" + lvProj.Items[i].SubItems[j].Text : "'" + lvProj.Items[i].SubItems[8].Text;
                }
            }

            m_objRng = m_objSheet.get_Range("A2", m_objOpt);
            m_objRng = m_objRng.get_Resize(MainMDI.MAX_XLlines_XPRT, 8);
            m_objRng.Value2 = objData;

            m_objBook.SaveAs(MainMDI.XL_Path + @"\XL_stat.xls", m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();
            //  ??? NO  data
            MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\CMS_CALC.xls");

   */    
        }

        private string CMS_TYPE(string ABR)
        {
            string res="???";
            switch (ABR)
            {
                case "SNG":
                    res = "Sales";
                    break;
                case "OVS":
                    res = "Sales Overage";
                    break;
                case "AGA":
                case "AGB":
                case "AGC":
                case "AGD":
                    res = "Agencies";
                    break;
                case "OVA":
                    res = "Agencies Overage";
                    break;
            }
            return res;
        }

        private void xl_Click(object sender, EventArgs e)
        {
            if (grpCMS.Visible) XL_Commiss();
            else XL_INVoices();
        }

        private void XL_INVoices()
        {
           
            int NBCols = 20;
            object[] objHdrs = new object[NBCols ];//  { "Invoice #", "Sale / Agency Name", "Base Amount", "Commission %", "Commission Amount", "Currency", "Xchange rate ", "Commission Amount (CAD)", " cms Type " };
          
           for (int i=0,j=2;i<NBCols-2;i++,j++)  objHdrs[i] =ed_lvITM.Columns[j].Text ;//ed_lvITM.Columns[i+2].Text;
           objHdrs[18] = ed_lvITM.Columns[21].Text;
           objHdrs[19] = ed_lvITM.Columns[22].Text;



            string Fname = "CMS_INVOICES.xlsx";
            string CellFM = "A1", CellTO = "T1";

            object[,] objData = new object[MainMDI.MAX_XLlines_XPRT, NBCols ];
            for (int i = 0; i < MainMDI.MAX_XLlines_XPRT; i++)
            {
                if (i < ed_lvITM.Items.Count)
                {
                    for (int j = 0, t = 2; j < NBCols; j++, t++) objData[i, j] = ed_lvITM.Items[i].SubItems[t].Text;

                }

            }
            XL_EXPORT(Fname, objHdrs, NBCols, CellFM, CellTO, objData);
            
        }



        private void XL_Commiss()
        {
            object[] objHdrs = { "Invoice #", "Sale / Agency Name", "Base Amount", "Commission %", "Commission Amount", "Currency", "Xchange rate ", "Commission Amount (CAD)", " cms Type " };
            string Fname = "CMS_CALC.xlsx";
            string CellFM = "A1", CellTO = "I1";
            object[,] objData = new object[MainMDI.MAX_XLlines_XPRT, 9];
            for (int i = 0; i < MainMDI.MAX_XLlines_XPRT; i++)
            {
                if (i < ed_lvCMS.Items.Count)
                {
                    objData[i, 0] = ed_lvCMS.Items[i].SubItems[2].Text;
                    objData[i, 1] = ed_lvCMS.Items[i].SubItems[3].Text;
                    objData[i, 2] = ed_lvCMS.Items[i].SubItems[4].Text;
                    objData[i, 3] = ed_lvCMS.Items[i].SubItems[5].Text;
                    objData[i, 4] = ed_lvCMS.Items[i].SubItems[6].Text;
                    objData[i, 5] = ed_lvCMS.Items[i].SubItems[7].Text;
                    objData[i, 6] = ed_lvCMS.Items[i].SubItems[8].Text;
                    objData[i, 7] = ed_lvCMS.Items[i].SubItems[9].Text;
                    objData[i, 8] = CMS_TYPE(ed_lvCMS.Items[i].SubItems[11].Text);
                }

            }
            XL_EXPORT(Fname, objHdrs, 9, CellFM, CellTO, objData);
        }



        private void XL_EXPORT(string FName, object[] objHdrs,int HdrsNB, string CellFM, string CellTO,  object[,] objData)
        {

            System.IO.File.Delete(MainMDI.XL_Path + @"\" +  FName);// "CMS_CALC.xls");
            Object m_objOpt = System.Reflection.Missing.Value;
            Excel.Application m_objXL = new Excel.Application();
            Excel.Workbooks m_objbooks = m_objXL.Workbooks;
            Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);
            Excel.Sheets m_objSheets = m_objBook.Worksheets;
            Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

           
            Excel.Range m_objRng = m_objSheet.get_Range(CellFM ,CellTO ); 
            m_objRng.Value2 = objHdrs;
            Excel.Font m_objFont = m_objRng.Font;
            m_objFont.Bold = true;

            m_objRng = m_objSheet.get_Range("A2", m_objOpt);
            m_objRng = m_objRng.get_Resize(MainMDI.MAX_XLlines_XPRT, HdrsNB );
            m_objRng.Value2 = objData;

            m_objBook.SaveAs(MainMDI.XL_Path + @"\" + FName, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();
            //  ??? NO  data
            MainMDI.OpenKnownFile(MainMDI.XL_Path +  @"\" + FName);


        }

        private void btnINVprj_Click(object sender, EventArgs e)
        {
            lbx_invalidPrj.Visible = !lbx_invalidPrj.Visible;
            grpITM.Height = (lbx_invalidPrj.Visible ) ? 207 : 73;

        }

        private void cbSales_old_SelectedIndexChanged(object sender, EventArgs e)
        {
             lsaID.Text = MainMDI.get_CBX_value(cbSales_old , cbSales_old.SelectedIndex);
             btn_SUM_old.Enabled = (cbSales_old.Text.ToUpper() == "ALL");
             lSalesTOT.Text   = (cbSales_old.Text.ToUpper() == "ALL") ?  MainMDI.VIDE : ""   ; 

        }

        private void cbCMStype_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_SUM_Click(object sender, EventArgs e)
        {
            fill_Cms_TOTALS();
        }

        private void btn_SUM_old_Click(object sender, EventArgs e)
        {
            fill_Cms_TOTALS_OLD(cbSess.Text  );
        }

        private void fill_Cms_TOTALS_OLD(string _datSess)
        {

           // _datSess= MainMDI.Eng_MMJJYYYY_date(_datSess,"/");
            string Cond_sess="",Cond_grp = "";;
            if (_datSess.Length == 10) Cond_sess = "  WHERE PSM_M_Sessions.Date_UPto = '" +_datSess + "'";

            ed_lvCMS.BeginUpdate();

            switch (cbCMS_old.Text)
            {
                case "Sales":
                    Cond_grp  = " grp='SNG'";
                    break;
                case "Sales Overage":
                    Cond_grp  = " grp='OVS'";
                    break;
                case "Agencies":
                    Cond_grp  = " ( grp='AGA' OR  grp='AGB'  OR  grp='AGC'  OR  grp='AGD' )";
                    break;
                case "Agencies Overage":
                    Cond_grp  = " grp='OVA'";
                    break;
            }

        
            if (Cond_sess == "" && Cond_grp  != "") Cond_grp  = " Where " + Cond_grp;
            if (Cond_sess != "" && Cond_grp  != "") Cond_grp  = " AND " + Cond_grp;



            string stSql = " select SA_Name, CAD_AMNT from PSM_M_MVT_CMS inner join PSM_M_Sessions on PSM_M_MVT_CMS.SES_ID=PSM_M_Sessions.SES_ID " + Cond_sess + Cond_grp  + " order by SA_Name ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();   // CONVERT(DATETIME, '31/08/2009',103)
            ed_lvCMS.Items.Clear();
            decimal dtot = 0, bigTOT = 0;
            string oldNM = "", NewNM = "";
            while (Oreadr.Read())
            {
                LV_Aff_AMNT(Oreadr["SA_Name"].ToString(), Oreadr["CAD_AMNT"].ToString());
            }

             OConn.Close();
       
            ed_lvCMS.EndUpdate();


        }

        private void LV_Aff_AMNT(string _Name, string _Amnt)
        {
            bool found=false;
            if (ed_lvCMS.Items.Count == 0) add_toLV(_Name, _Amnt);
            else
            {
                for (int i = 0; i < ed_lvCMS.Items.Count; i++)
                {
                    if (ed_lvCMS.Items[i].SubItems[3].Text == _Name)
                    {

                        ed_lvCMS.Items[i].SubItems[9].Text = Math.Round(Tools.Conv_Dbl(ed_lvCMS.Items[i].SubItems[9].Text) + Tools.Conv_Dbl(_Amnt), MainMDI.NB_DEC_AFF).ToString();
                        i = ed_lvCMS.Items.Count;
                        found=true;
                    }
                   
                }
               if (!found ) add_toLV(_Name, _Amnt);
            }


        }

        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

    }
}