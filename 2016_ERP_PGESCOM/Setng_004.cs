using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel ;
using EAHLibs;
using System.IO;
using System.Threading;


namespace PGESCOM
{
    public partial class Setng_004 : Form
    {
        Excel.Application m_objXL = null;
        private const int arr_BIG_Rows = 2000, arr_BIG_Cols = 39;
        private EAHLibs.Lib1 Tools=new Lib1 ();
        private int CompntSEL = -1,lCurSolNDX=-1,  lCurSPCNDX =-1, lCurALSNDX = -1;
        string ALSadded = "",lCurSoln ="",	lCurSPCn = "",	lCurALSn ="";
        private Hashtable HT_CPT_cat = new Hashtable(), HT_IDC = new Hashtable(), HT_CPT = new Hashtable();//, HT_IDC_TOT = new Hashtable();
        string[,] arr_BIGtoXL = new string[arr_BIG_Rows, arr_BIG_Cols], arr_MECtoXL01 = new string[arr_BIG_Rows, arr_BIG_Cols],arr_MECtoXL03 = new string[arr_BIG_Rows, arr_BIG_Cols],
            arr_BIGtoXL_SUM = new string[arr_BIG_Rows, arr_BIG_Cols],
            arr_BIGtoXL_Chargers = new string[arr_BIG_Rows, arr_BIG_Cols],
            arr_BIG_01 = new string[arr_BIG_Rows, arr_BIG_Cols],
            arr_BIG_03 = new string[arr_BIG_Rows, arr_BIG_Cols],
            arr_TOXL = new string[10,4];
        private int Row_Big = 0,ccount = 1,Mec_Row=0;
        string[] arr_IdcTOT = new string[arr_BIG_Cols], arr_IdcPRCT = new string[arr_BIG_Cols], arr_IdcBIGtot = new string[arr_BIG_Cols], arr_IDC = new string[50], arr_TOT_others = new string[arr_BIG_Cols] ;
        const string xlFNM = @"\Sam_PricingTemp.xls", xlFNMout = @"\Sam_Pricing.xls";
        string G_Base_CHRG = "",G_PHS="1";
        string G_BASE_TOT = "0",msgOK = "Prices Calculated succesfully for:  ",phss="";
        bool endProc = false,startProc=false;
        Thread Tcompute = null;

        public Setng_004()
        {
            InitializeComponent();



            Fill_HT_IDC();
        //    init_arr_Big();
            fill_arrBIG_XX("1", ref arr_BIG_01);
            fill_arrBIG_XX("3", ref arr_BIG_03);

            fill_arrMEC_XX("1", ref arr_MECtoXL01);
            fill_arrMEC_XX("3", ref arr_MECtoXL03);

            G_PHS = "1";
            this.Text += " (" + MainMDI.currDB + ")";
            fill_arr_TOXL();
        }




        private void init_arr_Big(ref string[,] _arrbig)
        {
            for (int i = 0; i < arr_BIG_Rows; i++)
                for (int j = 0; j < arr_BIG_Cols; j++)
                    _arrbig[i, j] = "~"; 
        }

        private void arr_Mode_Summary(string[,] _arrbig)
        {
            int s = 0;
            for (int i = 0; i < arr_BIG_Rows; i++)
                if (_arrbig[i, 0].IndexOf("   [") == -1)
                {
                    for (int j = 0; j < arr_BIG_Cols; j++) arr_BIGtoXL_SUM[s, j] = _arrbig[i, j];
                    s++;
                }
        }



        private void arr_Mode_Details(string[,] _arrbig)
        {
            int s = 0;
            for (int i = 0; i < arr_BIG_Rows; i++)
                                                         //  if (_arrbig[i, 0].IndexOf("   [") == -1)
                {
                    for (int j = 0; j < arr_BIG_Cols; j++) arr_BIGtoXL [s, j] = _arrbig[i, j];
                    s++;
                }
        }

        private void arr_Mode_ChargerOnlyOLDok(string[,] _arrbig)
        {
            int s = 0;
            for (int i = 0; i < arr_BIG_Rows; i++)
                if (_arrbig[i, arr_BIG_Cols - 1] != "C")
                {
                  //  string st = _arrbig[i, 0];
                  //  if (st[0] != '%' && st.IndexOf("OLD-") == -1) chrgr = _arrbig[i, 0];
                    for (int j = 0; j < arr_BIG_Cols; j++) arr_BIGtoXL_Chargers[s, j] = _arrbig[i, j];
                    s++;
                }
        }
        private void fill_arr_TOXL()
        {

            string stSql = "SELECT * from COMPNT_PL_TOXL ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int i=0;
            while (Oreadr.Read())
            {
                arr_TOXL[i, 0] = Oreadr["Line_txt"].ToString();
                arr_TOXL[i, 1] = Oreadr["toXL"].ToString();
                arr_TOXL[i, 2] = Oreadr["OLD"].ToString();
                arr_TOXL[i++, 3] = Oreadr["Prct"].ToString();
 

            }
            OConn.Close();
        }


        bool isTOXL(string st0, string _chrgr)
        {
            int SeekFld = 0;
            if (_chrgr == " " || st0 == "") return false;
            else
            {
                if (st0 == "%") SeekFld = 3;
                else
                {
                    if (st0.IndexOf("OLD-") != -1) SeekFld = 2;
                    else SeekFld = 1;
                }
            }
            for (int i = 0; i < 10; i++)
                if (arr_TOXL[i, 0] == _chrgr) return arr_TOXL[i, SeekFld] == "1";
            return false;

              
        }

        
        private void init_ARRBIG(string[,] ARRBIG )
        {
            for (int r = 0; r < arr_BIG_Rows; r++) for (int c = 0; c < arr_BIG_Cols; c++) ARRBIG[r, c] = "";
        }

        private void arr_Mode_ChargerOnly(string[,] _arrbig)
        {
            int s = 0; string chrgr = " ";
            
            init_arr_Big(ref arr_BIGtoXL_Chargers);

            for (int i = 0; i < arr_BIG_Rows; i++)
                if (_arrbig[i, arr_BIG_Cols-1] != "C")
                {
                    string st = _arrbig[i, 0];
                    if ( st[0] != '%' && st.IndexOf ("OLD-")==-1 ) chrgr = _arrbig[i, 0];
                    if (!chkTOXL.Checked  ||  _arrbig[i, arr_BIG_Cols - 1] == "L" || _arrbig[i, arr_BIG_Cols - 1] == " " || isTOXL(st, chrgr))
                    {
                        for (int j = 0; j < arr_BIG_Cols; j++)
                            arr_BIGtoXL_Chargers[s, j] = _arrbig[i, j];
                        s++;
                    }
                }
        }


        private void init_arr_idcTOT()
        {

            for (int i = 0; i < arr_BIG_Cols ; i++)
            {
                arr_IdcTOT[i] ="0";
                arr_IdcPRCT[i] = "0";
                arr_IdcBIGtot[i] = "0";
            }
        }


        private void fill_cbFromTO(string _phs)
        {
          if (cbFrom.Items.Count >0)    cbFrom.Items.Clear();
          if (cbTO.Items.Count > 0) cbTO.Items.Clear();
         
            string stSql = "SELECT Avail_ID,charger + '-' + '" + _phs + "' + '-' + [vdc] + '-' + idc as CHRG_REF " +
                           "  FROM TBLAVAIL" + _phs + " where charger='P4500' order by cast (vdc as float) , cast (idc as float)";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
       
            while (Oreadr.Read())
            {
               MainMDI.add_CB_itm(cbFrom, Oreadr["CHRG_REF"].ToString(), Oreadr["Avail_ID"].ToString());
               MainMDI.add_CB_itm(cbTO , Oreadr["CHRG_REF"].ToString(), Oreadr["Avail_ID"].ToString());

            }
            cbFrom.SelectedIndex = 0;
            cbTO.SelectedIndex = 0; 
            OConn.Close();
        }

        private void fill_arrMEC_XX(string _phs, ref string[,] arrXX)
        {

            int r = 0;
            for (r = 0; r < arr_BIG_Rows; r++) for (int c = 0; c < arr_BIG_Cols; c++) arrXX[r, c] = "~";

            string stSql = "select * from  TBLTOXL0" + _phs + "MEC_SIM ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            r = 0;
            while (Oreadr.Read())
            {
                for (int c = 0; c < arr_BIG_Cols; c++) arrXX[r, c] = Oreadr[c].ToString();
                r++;
            }

            OConn.Close();
        }


        private void fill_arrBIG_XX(string _phs, ref string[,] arrXX)
        {

            int r = 0;
            for (r = 0; r < arr_BIG_Rows; r++) for (int c = 0; c < arr_BIG_Cols; c++) arrXX[r, c] = "~";

            string stSql = "select * from  TBLTOXL0" + _phs + "_SIM ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            r=0;
            while (Oreadr.Read())
            {
                for (int c = 0; c < arr_BIG_Cols; c++) arrXX[r, c] = Oreadr[c].ToString();
                r++;
            }
            
            OConn.Close();
        }

        private void fill_cbCpts()
        {
            cbCpts.Items.Clear();

            string stSql = "select distinct Component_ID, COMPONENT_REF, CatName1,CatName2,CatName3  from COMPNT_LIST inner join link_COMPNT_AVAIL on Compnt_ID=COMPNT_LIST.Component_ID      order by COMPONENT_REF ";
              
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            MainMDI.add_CB_itm(cbCpts,"ALL","0");
            while (Oreadr.Read())
            {
               // if (cbCpts.Items.Count == 0) MainMDI.add_CB_itm(cbCpts, "ALL","0");
               // else 
                MainMDI.add_CB_itm(cbCpts, Oreadr["COMPONENT_REF"].ToString(), Oreadr["Component_ID"].ToString());
                HT_CPT_cat.Add(Oreadr["COMPONENT_REF"].ToString() + "_CAT1", Oreadr["CatName1"].ToString());
                HT_CPT_cat.Add(Oreadr["COMPONENT_REF"].ToString() + "_CAT2", Oreadr["CatName2"].ToString());
                HT_CPT_cat.Add(Oreadr["COMPONENT_REF"].ToString() + "_CAT3", Oreadr["CatName3"].ToString());
            }
            cbCpts.SelectedIndex = 0;
            OConn.Close();
        }


        private void import_NewPrices_CPTxx(string tableNM)
        {


            string stSql = "select * FROM " + tableNM;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon );
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                string msg = "";
                string cnt = MainMDI.Find_One_Field("select count (PRICE_LINE_ID) from dbo.COMPNT_PRICE_LIST where PL_Code='" + Oreadr["Code"].ToString() + "'");
                if (cnt == "1")
                {
                    stSql = " UPDATE  COMPNT_PRICE_LIST SET PRICE ='" + Math.Round( Tools.Conv_Dbl (  Oreadr["Price"].ToString()),MainMDI.NB_DEC_AFF )  + "' WHERE PL_Code ='" + Oreadr["Code"].ToString() + "'";
                    MainMDI.ExecSql(stSql);
                }
                else msg = (cnt == MainMDI.VIDE) ? msg = "this code=" + Oreadr["Code"].ToString() + " Invalid...." : "this code=" + Oreadr["Code"].ToString() + " many line have it (double)....";
                if (msg != "") MessageBox.Show(msg);


            }
            OConn.Close();

        }

        private void import_OldFuses()
        {


            string stSql = "select * FROM  Import_fuses";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                string msg = "";
                string cnt = MainMDI.Find_One_Field("select count (PRICE_LINE_ID) from dbo.COMPNT_PRICE_LIST where PL_Code='" + Oreadr["Code"].ToString() + "'");
                if (cnt == "1")
                {
                    if (Oreadr["Code"].ToString() != "n/a")
                    {
                        stSql = " UPDATE  COMPNT_PRICE_LIST SET Cost_Price ='" + Math.Round(Tools.Conv_Dbl(Oreadr["Cost_Price"].ToString()), MainMDI.NB_DEC_AFF) + "', CAT3_VALUE ='" + Math.Round(Tools.Conv_Dbl(Oreadr["IFA"].ToString()), MainMDI.NB_DEC_AFF) + "' WHERE PL_Code ='" + Oreadr["Code"].ToString() + "'";
                        MainMDI.ExecSql(stSql);
                        lcodes.Items.Add(Oreadr["Code"].ToString());
                    }
   
                }
                else msg = (cnt == MainMDI.VIDE) ? msg = "this code=" + Oreadr["Code"].ToString() + " Invalid...." : "this code=" + Oreadr["Code"].ToString() + " many line have it (double)....NB= "+cnt ;
                if (msg != "") MessageBox.Show(msg);


            }
            OConn.Close();

        }


        private void Fill_HT_IDC()
        {


            string stSql = "  SELECT Value1 FROM TABLES_CONTENT INNER JOIN TABLES_LIST ON TABLES_CONTENT.TABLE_ID = TABLES_LIST.TABLE_ID Where (((TABLES_LIST.table_Name) = 'IDC')) ORDER BY cast (Value1 as int)";
            HT_IDC.Clear();  
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int ndx = 1;
            for (int u = 0; u < 50; u++) arr_IDC[u] = "";
            while (Oreadr.Read()) 
            {
                HT_IDC.Add(Oreadr["Value1"].ToString(),ndx.ToString ()) ;
                cbIDC.Items.Add (Oreadr["Value1"].ToString());
                arr_IDC[ndx - 1] = Oreadr["Value1"].ToString();
                ndx++;
            }
            OConn.Close();
        }

        private void fill_cbVCS(string _phs)
        {
            cbVCS.Items.Clear();

            string stSql = "SELECT  VCS_ID,VCS_NAME  from  COMPUTE_VCS where VCS_NAME<>'n/a' and (PHS='2' or PHS='" + _phs + "') order by VCS_NAME "; 

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read()) MainMDI.add_CB_itm(cbVCS, Oreadr["VCS_NAME"].ToString(), Oreadr["VCS_ID"].ToString());

            OConn.Close();
        }

        private void btnFROM_Click(object sender, EventArgs e)
        {
            cbFrom.BringToFront(); 
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        private void chng_PHS()
        {
            fill_cbFromTO(G_PHS  );
            fill_cbVCS(G_PHS);
        }
        private void btnPHS_Click(object sender, EventArgs e)
        {

            btnPHS.Text = (btnPHS.Text == "1") ? "3" : "1";
            G_PHS = btnPHS.Text;
            chng_PHS();
        }

        private void btnTO_Click(object sender, EventArgs e)
        {
            cbTO.BringToFront(); 
        }

        private void Setng_004_Load(object sender, EventArgs e)
        {
           // btnPHS.Text = "1";
            fill_cbFromTO(G_PHS );
            fill_cbCpts();
            fill_cbVCS(G_PHS );
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!"; 
        }

        private void cbCpts_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
            itm = (System.Web.UI.WebControls.ListItem)cbCpts.Items[cbCpts.SelectedIndex];
            lcptID.Text = itm.Value;
            lcptDesc.Text = MainMDI.Find_One_Field("select Component_Name from dbo.COMPNT_LIST where Component_ID=" + lcptID.Text);
            btnCost.Text = (cbCpts.Text.ToLower() == "all") ? "All Cost" :"CPT Cost"  ; 
        }

        private void picNew_Click(object sender, EventArgs e)
        {
            if ( cbFrom.Text !="" )cbTO.Text = cbFrom.Text; 
        }


   
        private bool deco_chrg(string CHREF,ref string vdc, ref string idc)
        {
            int ipos=CHREF.IndexOf ("-",6);
            if (ipos > -1)
            {
                CHREF = CHREF.Substring(ipos+1, CHREF.Length - ipos -1);
                ipos = CHREF.IndexOf("-");
                if (ipos > -1)
                {
                    vdc = CHREF.Substring(0, ipos);
                    idc = CHREF.Substring(ipos + 1, CHREF.Length - 1 - ipos);
                    return true;
                }
            }
            return false;

        }


        private void btnCost_Click(object sender, EventArgs e)
        {
            //      ed_lvcost.BringToFront(); 
            //      if (cbCpts.Text == "ALL") cal_COST_chrg_LVCOST(cbFrom.SelectedIndex ,cbTO.SelectedIndex ,1,cbCpts.Items.Count -1);
            //      else cal_COST_chrg_LVCOST(cbFrom.SelectedIndex, cbTO.SelectedIndex,cbCpts.SelectedIndex ,cbCpts.SelectedIndex  ); 
            string Curr_CHREF = "", Curr_AvailID = "", _Vdc = "", _Idc = "";

            if (btnCost.Text.ToLower() == "all cost") Compute_SelectedPHS();
            else
            {
                if (cbFrom.SelectedIndex != -1)
                {
                    System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
                    itm = (System.Web.UI.WebControls.ListItem)cbFrom.Items[cbFrom.SelectedIndex];
                    Curr_AvailID = itm.Value;
                    Curr_CHREF = itm.Text;
                    if (deco_chrg(Curr_CHREF, ref _Vdc, ref _Idc) && lcptDesc.Text.Length > 0) Compute_OneCPT("P4500", btnPHS.Text, _Vdc, _Idc, "0", "0", lcptID.Text, cbCpts.Text );
                    else MessageBox.Show("ERooooooooor:  VDC / IDC......or....Invalid CPT !!!");
                }
                else MessageBox.Show("Please Select a Component !!!"); 
            }
            
        }


        private void add_lvCost(string[] stNN )
        {
            ListViewItem lv = ed_lvcost.Items.Add(stNN[0]);
            for (int i=1;i<12;i++)  lv.SubItems.Add(stNN[i]);
            if (stNN[10]=="0.00") lv.ForeColor = Color.Red;
            if (stNN[1].IndexOf ("TOTAL") >-1) lv.BackColor  = Color.GreenYellow ; 
 
        }

        private void add_lvBIG(string [,] _arrbig)
        {
            ed_LVBIG.Items.Clear();
            ed_LVBIG.BeginUpdate ();
            for (int i = 0; i < arr_BIG_Rows; i++)
            {
                if (_arrbig [i, 0] != "~" )
                {
                    if (_arrbig[i, 0].IndexOf("[n/a]") == -1)
                    {
                        ListViewItem lv = ed_LVBIG.Items.Add(_arrbig[i, 0]);
                        for (int j = 1; j < arr_BIG_Cols; j++)                         
                            lv.SubItems.Add((_arrbig[i, j] == "~" || _arrbig[i, j] == MainMDI.VIDE) ? "" : _arrbig[i, j]);

                        if (_arrbig[i, arr_BIG_Cols-1] == "L") lv.BackColor = Color.GreenYellow;
                    }
                }
                else i = arr_BIG_Rows;
            }
            ed_LVBIG.EndUpdate (); 

        }


        private void cal_COST_chrg_LVCOST(int Cfrom,int Cto,int Tfrom, int Tto)
        {

            t1.Text = System.DateTime.Now.ToShortTimeString();
            t2.Text = "";
            string _errmsg="";
            if (Cto <Cfrom ) _errmsg ="Charger selection is INVALID.....";
            if (Tto < Tfrom ) _errmsg ="Component selection is INVALID.....";
            string _Pxx = "P4500", _phs =G_PHS , _Vdc = "", _Idc = "", _Vac = "", _VdcMax = "",Curr_CHREF,_lcptID="",Curr_CPTNM="";
            Component Cpt = null;
            Charger CHRGR = null;
            int Ccount = 1;
            double Chrg_Tot = 0;
            ed_lvcost.Items.Clear();
            ed_lvcost.BeginUpdate();
            string[] arr_VV = new string[12];
            if (_errmsg.Length ==0)
            {

                for (int c = Cfrom; c < Cto + 1; c++)
                {

                    Chrg_Tot = 0;
                    Curr_CHREF = cbFrom.Items[c].ToString();
                    if (!deco_chrg(Curr_CHREF, ref _Vdc, ref _Idc)) MessageBox.Show("ERooooooooor:  VDC / IDC"); 
                    CHRGR = new Charger(0, "F", _Pxx, _phs, _Vdc, _Idc, _Vac, _VdcMax);
                    for (int t = Tfrom; t < Tto+1; t++)
                    {
                        Cpt = new Component();
                        System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
                        itm = (System.Web.UI.WebControls.ListItem)cbCpts.Items[t];
                        _lcptID = itm.Value;
                        Curr_CPTNM = itm.Text;
                        string tt = Cpt.Cal_chrg_CostADO(Convert.ToInt32(_lcptID), "C");
                       
                       arr_VV[0]=("");
                        arr_VV[1]=Curr_CHREF;
                        arr_VV[2] = Curr_CPTNM;
                        arr_VV[3] = HT_CPT_cat[Curr_CPTNM + "_CAT1"].ToString();
                        arr_VV[4] =Cpt.CAP1;
                        arr_VV[5] =HT_CPT_cat[Curr_CPTNM + "_CAT2"].ToString();
                        arr_VV[6] =Cpt.CAP2;
                        arr_VV[7] =HT_CPT_cat[Curr_CPTNM + "_CAT3"].ToString();
                        arr_VV[8] =Cpt.CAP3;
                        arr_VV[9] =Cpt.Real_QTY;
                        arr_VV[10] =MainMDI.A00(Tools.Conv_Dbl(Cpt.G_PRICE).ToString());
                       if (cbCpts.Text =="ALL")  Chrg_Tot += Tools.Conv_Dbl(Cpt.G_PRICE);
                        arr_VV[11] =Cpt.G_PRICE;
                        add_lvCost(arr_VV);
                        /*
                        ListViewItem lv = ed_lvcost.Items.Add("");
                        lv.SubItems.Add(Curr_CHREF);
                        lv.SubItems.Add(Curr_CPTNM);
                        lv.SubItems.Add(HT_CPT_cat[Curr_CPTNM + "_CAT1"].ToString());
                        lv.SubItems.Add(Cpt.CAP1);
                        lv.SubItems.Add(HT_CPT_cat[Curr_CPTNM + "_CAT2"].ToString());
                        lv.SubItems.Add(Cpt.CAP2);
                        lv.SubItems.Add(HT_CPT_cat[Curr_CPTNM + "_CAT3"].ToString());
                        lv.SubItems.Add(Cpt.CAP3);
                        lv.SubItems.Add(Cpt.Real_QTY);
                        lv.SubItems.Add(MainMDI.A00 (Tools.Conv_Dbl(Cpt.G_PRICE).ToString ()));
                        Chrg_Tot += Tools.Conv_Dbl(Cpt.G_PRICE);
                        lv.SubItems.Add(Cpt.G_PRICE);
                        if (Tools.Conv_Dbl(Cpt.G_PRICE) == 0) lv.BackColor = Color.Salmon;
                         * */ 

                        //     lIprim.Text = Cpt.Cal_VCS(0, "C_IPRIM");
                        //      lhrtZMRK.Text = Cpt.Cal_VCS(0, "C_HRTZ" + lhrtz.Text);

                    }
                    if (Chrg_Tot > 0)
                    {

                        
                        for (int y = 0; y < 12; y++) arr_VV[y] = "";
                        arr_VV[1] =Curr_CHREF + "  TOTAL";
                        arr_VV[10] = Chrg_Tot.ToString();
                        add_lvCost(arr_VV);
                    }
                    tCount.Text = Ccount.ToString(); tCount.Refresh();
                    Ccount++;
                    this.Refresh(); 
                }
                ed_lvcost.EndUpdate(); 
            }
            else MessageBox.Show (_errmsg );

            t2.Text = System.DateTime.Now.ToShortTimeString();
        }

        private void cbVCS_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

 


 


        private void price_all_cpt_1CHRG(string p, string Curr_CHREF, string Avail_id)
        {

            string stSql = "SELECT TBLAVAIL" + p + ".Avail_ID, COMPNT_LIST.Component_ID,COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + p + ".charger, TBLAVAIL" + p + ".vdc, TBLAVAIL" + p + ".idc, link_COMPNT_AVAIL.Qty, COMPNT_LIST.CAT1_TABLE_ID, COMPNT_LIST.CAT2_TABLE_ID, COMPNT_LIST.CAT3_TABLE_ID, COMPNT_LIST.Compnt_Type, COMPNT_LIST.Value_Type, COMPNT_LIST.nbc3Cat " +
                         " FROM (TBLAVAIL" + p + " INNER JOIN link_COMPNT_AVAIL ON TBLAVAIL" + p + ".Avail_ID = link_COMPNT_AVAIL.Avail_ID) INNER JOIN COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = COMPNT_LIST.Component_ID " +
                         " Where (((link_COMPNT_AVAIL.phs) = '" + p + "') and ((link_COMPNT_AVAIL.Avail_ID) = " + Avail_id + ")) ORDER BY TBLAVAIL" + p + ".Avail_ID, COMPNT_LIST.Component_ID";

            string _Pxx = "P4500", _phs = p , _Vdc = "", _Idc = "", _Vac = "", _VdcMax = "",_lcptID = "", Curr_CPTNM = "";
            Component Cpt = null;
            Charger CHRGR = null;
            int Ccount = 1;
            double Chrg_Tot = 0;
            string[] arr_VV = new string[12];
            if (!deco_chrg(Curr_CHREF, ref _Vdc, ref _Idc)) MessageBox.Show("ERooooooooor:  VDC / IDC");
            CHRGR = new Charger(0, "F", _Pxx, _phs, _Vdc, _Idc, _Vac, _VdcMax);

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {

                Cpt = new Component();
                _lcptID = Oreadr["Component_ID"].ToString();
                Curr_CPTNM = Oreadr["COMPONENT_REF"].ToString();
                string tt = Cpt.Cal_chrg_CostADO(Convert.ToInt32(_lcptID), "C");

                arr_VV[0] = Avail_id;
                arr_VV[1] = _lcptID;

                arr_VV[2] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.CAP1;
                arr_VV[3] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.CAP2;
                arr_VV[4] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.CAP3;
                arr_VV[5] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.Real_QTY;
                arr_VV[6] = Tools.Conv_Dbl(Cpt.G_PRICE).ToString(); //MainMDI.A00(Tools.Conv_Dbl(Cpt.G_PRICE).ToString());
                arr_VV[7] = Oreadr["Compnt_Type"].ToString();
                stSql = "INSERT INTO CHARGERS_COST0" + p + " ([Avail_ID],[Compnt_ID],[Cap1],[Cap2],[Cap3],[Real_QTY],[COST],[cost_type]) VALUES (" +
                    arr_VV[0] + " , " +
                    arr_VV[1] + " , '" +
                    arr_VV[2] + "' , '" +
                    arr_VV[3] + "' , '" +
                    arr_VV[4] + "' , '" +
                    arr_VV[5] + "' , '" +
                    arr_VV[6] + "' , '" +
                    arr_VV[7] + "')";
                MainMDI.ExecSql(stSql);
            }


        }


        private void disp_1_3_Phase(string _phs)
        {
         //   t1.Text = DateTime.Now.ToShortTimeString();
    //        btnPHS.Text = _phs.ToString();
   //         chng_PHS();
   //         init_arr_Big();
   //         init_arr_idcTOT();
   //         HT_CPT.Clear();
  //          AllChargers_AllPhase(btnPHS.Text, 0, cbFrom.Items.Count - 1);
  //          arr_Big_Summary();
   //         add_lvBIG(arr_BIGtoXL);

           // t2.Text = DateTime.Now.ToShortTimeString();
        }
        private void NewItm_Click(object sender, EventArgs e)
        {

        
        }
        private void do_Totals(string PXX_VDC)
        {
            arr_IdcTOT[0] = "Components Total"; arr_IdcPRCT[0] = "AUTRES 5%";  arr_IdcBIGtot[0] = "P4500";
            arr_IdcTOT[arr_BIG_Cols - 2] = PXX_VDC; arr_IdcPRCT[arr_BIG_Cols - 2] = PXX_VDC; arr_IdcBIGtot[arr_BIG_Cols-2] = PXX_VDC;
            arr_IdcTOT[arr_BIG_Cols - 1] = "T"; arr_IdcPRCT[arr_BIG_Cols - 1] = "T"; arr_IdcBIGtot[arr_BIG_Cols-1] = "T";

            for (int i = 1; i < arr_BIG_Cols - 2; i++)
            {
                if (arr_IdcPRCT[i] != "0")
                {
                    if (arr_IdcTOT[i] == "-1")
                    {
                       // double prct = Math.Round((Tools.Conv_Dbl(arr_IdcPRCT[i]) * Tools.Conv_Dbl(arr_IdcTOT[i])) / 100, MainMDI.NB_DEC_AFF);
                        arr_IdcBIGtot[i] = "c/f";
                        arr_IdcPRCT[i] = "c/f";
                    }
                    else
                    {
                        double prct = Math.Round((Tools.Conv_Dbl(arr_IdcPRCT[i]) * Tools.Conv_Dbl(arr_IdcTOT[i])) / 100, MainMDI.NB_DEC_AFF);
                        arr_IdcBIGtot[i] = MainMDI.A00(Convert.ToString(Math.Round(Tools.Conv_Dbl(arr_IdcTOT[i]) + prct, MainMDI.NB_DEC_AFF)));
                        arr_IdcPRCT[i] = MainMDI.A00(prct.ToString());
                    }
                }
            }

            for (int c = 0; c < arr_BIG_Cols; c++)
            {
                if (c > 0 && c < arr_BIG_Cols-2)
                {
                    arr_BIGtoXL[Row_Big, c] = (arr_IdcTOT[c] == "c/f" || arr_IdcTOT[c] == "-1") ? "c/f" : MainMDI.A00(arr_IdcTOT[c]);
                    arr_BIGtoXL[Row_Big + 1, c] = (arr_IdcPRCT[c] == "c/f" || arr_IdcPRCT[c] == "-1") ? "c/f" : MainMDI.A00(arr_IdcPRCT[c]);
                    arr_BIGtoXL[Row_Big + 2, c] = (arr_IdcBIGtot[c] == "c/f" || arr_IdcBIGtot[c] == "-1") ? "c/f" : MainMDI.A00(arr_IdcBIGtot[c]);
                }
                else
                {
                    arr_BIGtoXL[Row_Big, c] =arr_IdcTOT[c];
                    arr_BIGtoXL[Row_Big + 1, c] =arr_IdcPRCT[c];
                    arr_BIGtoXL[Row_Big + 2, c] = arr_IdcBIGtot[c];
                }

            }
            Row_Big += 3;
        }


        private bool VDC_Disabled(string _p,string _vdc)
        {
            return MainMDI.Find_One_Field("select disa_LID from PSM_DISA_VDC_IDC where typ='V' and PHS='" + _p + "' and VDC_IDC_value='" + _vdc + "'")!=MainMDI.VIDE  ; 
        }
        private bool IDC_Disabled(string _p, string _idc)
        {
            return MainMDI.Find_One_Field("select disa_LID from PSM_DISA_VDC_IDC where typ='I' and PHS='" + _p + "' and VDC_IDC_value='" + _idc + "'") != MainMDI.VIDE;
        }


        private void Create_MECTOXL_13(string _phs, string[,] arr_MECtoXL)
        {



            MainMDI.Exec_SQL_JFS("delete  TBLTOXL0" + _phs + "MEC_SIM ", " delete TBLTOXL0" + _phs + "MEC_SIM for Pricing....");
            string stSql = "", stV = "";
            for (int r = 0; r < arr_BIG_Rows; r++)
            {
                if (arr_MECtoXL[r, 0] != "~")
                {
                    stSql = "INSERT INTO TBLTOXL0" + _phs + "MEC_SIM ([COMPONENT]";
                    stV = ") VALUES ('";
                    for (int c = 0; c < arr_BIG_Cols; c++)
                    {

                        if (c < arr_BIG_Cols - 3) stSql += ",[" + arr_IDC[c].ToString() + "]";
                        else
                        {
                            if (c == (arr_BIG_Cols - 3)) stSql += ",[REF_CHRG]";
                            if (c == (arr_BIG_Cols - 2)) stSql += ",[cRec]";
                        }
                        if (c < (arr_BIG_Cols - 1)) stV += arr_MECtoXL[r, c].ToString() + "' , '";
                        else stV += arr_MECtoXL[r, c].ToString() + "')";

                    }
                    stSql += stV;
                }
                else
                {
                    r = arr_BIG_Rows;
                    stSql = "";
                }
               //for debug  if (stSql == "") stSql = stSql;
                if (stSql != "") MainMDI.ExecSql(stSql);
            }
        }

        private void Mechanical13()
        {

            for (int p = 1; p < 4; p += 2)
            {
                G_PHS = p.ToString();
                chng_PHS();

                if (p == 1)
                {
                    init_arr_Big(ref arr_MECtoXL01);
                    AllChargers_MEC(p.ToString(), ref arr_MECtoXL01, 0, cbFrom.Items.Count - 1);
                    Create_MECTOXL_13(p.ToString(), arr_MECtoXL01);
                }
               if (p == 3)
               {
                   init_arr_Big(ref arr_MECtoXL03);
                   AllChargers_MEC(p.ToString(), ref arr_MECtoXL03, 0, cbFrom.Items.Count - 1);
                   Create_MECTOXL_13(p.ToString(), arr_MECtoXL03);
               }
               

            }
        }

        private void AllChargers_MEC(string p,ref string[,] MECtoXL,int ndx_deb, int ndx_fin)
        {
            string Curr_CHREF = "", Curr_AvailID = "",_Vdc="",_Idc="",Ovdc="";

               // MainMDI.Exec_SQL_JFS("Delete CHARGERS_COST0" + p, " delete charger_COSTx for Pricing...");
                ccount = 1;
                Mec_Row  = 0;
              //  init_row_MEC(p,ref MECtoXL , Mec_Row++, "MB", " ");
                for (int c_ndx = ndx_deb; c_ndx < ndx_fin  ; c_ndx++)
                {
                  
                    System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
                    itm = (System.Web.UI.WebControls.ListItem)cbFrom.Items[c_ndx];
                    Curr_AvailID = itm.Value;
                    Curr_CHREF = itm.Text;
                    if (!deco_chrg(Curr_CHREF, ref _Vdc, ref _Idc)) MessageBox.Show("ERooooooooor:  VDC / IDC");
                    if (!VDC_Disabled(p, _Vdc))
                    {
                        if (Ovdc != _Vdc)
                        {

                            //HT_CPT.Clear();
                            if (Ovdc != "")
                            {
                                //do_Totals("P4500-" + p + "-" + Ovdc);
                                //do_Other_CHARGERS(p.ToString(), "P4500", Ovdc, arr_IdcBIGtot);
                                Mec_Row += 5;
                                init_row_MEC(p, ref MECtoXL, Mec_Row++, "MB", " ");
                            }
                            init_row_MEC(p, ref MECtoXL, Mec_Row++, "ML", "P4500-" + p + "-" + _Vdc);
                            //init_arr_idcTOT();

                        }
                        MECtoXL_EN1(p.ToString(), _Vdc, _Idc, Curr_AvailID);
                        //     tCount.Text = ccount.ToString();// tCount.Refresh();
                        ccount++;
                        //  this.Refresh();
                        Ovdc = _Vdc;
                    }
        
                }
          //      if (ccount > 1)
          //      {
          //          string vv = (VDC_Disabled(p, _Vdc)) ? Ovdc : _Vdc;
         //           do_Totals("P4500-" + p + "-" + vv);
          //          do_Other_CHARGERS(p.ToString(), "P4500", vv, arr_IdcBIGtot);
          //      }


        }


      private void MECtoXL_EN1(string _phs, string _Vdc, string _Idc, string Avail_id)
        {

            string stSql1 = "SELECT TBLAVAIL" + _phs + ".Avail_ID, COMPNT_LIST.Component_ID,COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + _phs + ".charger, TBLAVAIL" + _phs + ".vdc, TBLAVAIL" + _phs + ".idc, link_COMPNT_AVAIL.Qty, COMPNT_LIST.CAT1_TABLE_ID, COMPNT_LIST.CAT2_TABLE_ID, COMPNT_LIST.CAT3_TABLE_ID, COMPNT_LIST.Compnt_Type, COMPNT_LIST.Value_Type, COMPNT_LIST.nbc3Cat " +
                         " FROM (TBLAVAIL" + _phs + " INNER JOIN link_COMPNT_AVAIL ON TBLAVAIL" + _phs + ".Avail_ID = link_COMPNT_AVAIL.Avail_ID) INNER JOIN COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = COMPNT_LIST.Component_ID " +
                         " Where link_COMPNT_AVAIL.phs = '" + _phs + "' and link_COMPNT_AVAIL.Avail_ID = " + Avail_id + " and COMPNT_LIST.Component_ID='200' ORDER BY TBLAVAIL" + _phs + ".Avail_ID ";

            string _Pxx = "P4500", _Vac = "", _VdcMax = "", _lcptID = "200", Curr_CPTNM = "EN1", PXX_P_VDC = "P4500-" + _phs + "-" + _Vdc,
                            EN1 = MainMDI.VIDE,
                            WEIT = MainMDI.VIDE,
                            WEITkg = MainMDI.VIDE,
                            KW = MainMDI.VIDE,
                            BTU = MainMDI.VIDE;

            Component Cpt = null;
            Charger CHRGR = null;

            CHRGR = new Charger(0, "F", _Pxx, _phs, _Vdc, _Idc, _Vac, _VdcMax);

            int ndx_IDC = Int32.Parse(HT_IDC[_Idc].ToString());
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql1;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
           
            while (Oreadr.Read())
            {
                    string Row_type = "C";
                    Cpt = new Component();
         
                    EN1 = Cpt.Cal_VCS (0,"C_ARM");

                    WEIT = Cpt.Cal_VCS (0,"C_CHRG_WEIT");
                    if (WEIT != MainMDI.VIDE && WEIT != "0")
                    {
                        WEIT = Math.Round(double.Parse (WEIT), 0).ToString();

                        WEITkg = Cpt.Cal_VCS(0, "C_CHRG_WEITkg00");
                        if (WEITkg != MainMDI.VIDE) WEITkg = Math.Round(double.Parse (WEITkg), 0).ToString();

                        KW = Cpt.Cal_VCS(0, "C_KW");
                        if (KW != MainMDI.VIDE) KW = Math.Round(double.Parse (KW), 2).ToString();

                        BTU = Cpt.Cal_VCS(0, "C_BTU");
                        if (BTU != MainMDI.VIDE) BTU = Math.Round(double.Parse (BTU), 0).ToString();
                    }

 
                        //added on 30/04/2009
                       // if (IDC_Disabled(_phs, _Idc)) Cpt.G_PRICE = MainMDI.VIDE;
                      //added on 30/04/2009


               if (_phs =="1")     ToMEC_XL(ref arr_MECtoXL01 , ndx_IDC, PXX_P_VDC, Row_type,"EN1" ,EN1,"weight",WEIT ,"weight kg" ,WEITkg ,"KW",KW,"BTU",BTU);
               if (_phs == "3") ToMEC_XL(ref arr_MECtoXL03, ndx_IDC, PXX_P_VDC, Row_type, "EN1", EN1, "weight", WEIT, "weight kg", WEITkg, "KW", KW, "BTU", BTU);

     
/*
           
            
                arr_VV[0] = Oreadr["Avail_ID"].ToString();
                arr_VV[1] = _lcptID;
                arr_VV[2] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.CAP1;
                arr_VV[3] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.CAP2;
                arr_VV[4] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.CAP3;
                arr_VV[5] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.Real_QTY;
                arr_VV[6] = (Oreadr["Compnt_Type"].ToString() == "%") ? Oreadr["Value_Type"].ToString():Tools.Conv_Dbl(Cpt.G_PRICE).ToString(); //MainMDI.A00(Tools.Conv_Dbl(Cpt.G_PRICE).ToString());
                arr_VV[7] = Oreadr["Compnt_Type"].ToString();
                stSql2 = "INSERT INTO CHARGERS_COST0" + _phs + " ([Avail_ID],[Compnt_ID],[Cap1],[Cap2],[Cap3],[Real_QTY],[COST],[cost_type]) VALUES (" +
                    arr_VV[0] + " , "   +
                    arr_VV[1] + " , '"  +
                    arr_VV[2] + "' , '" +
                    arr_VV[3] + "' , '" +
                    arr_VV[4] + "' , '" +
                    arr_VV[5] + "' , '" +
                    arr_VV[6] + "' , '" +
                    arr_VV[7] + "')";
                MainMDI.ExecSql(stSql2);
                */
            }
           // arr_IdcTOT[ndx_IDC] = Idc_TOT.ToString ();
 
        }


          private void ToMEC_XL(ref string[,] arr_MECtoXL,  int _ndx_IDC, string _pxxVDC, string _typ,string titl1, string _EN1, string titl2,string _WEIT, string titl3,string _WEITkg, string titl4,string _KW, string titl5,string _BTU)
        {
            int _cptNDX = Mec_Row; 


            if (arr_MECtoXL[_cptNDX, 0] == "~")
            {
                arr_MECtoXL[_cptNDX , 0] = titl1;
                arr_MECtoXL[_cptNDX , arr_BIG_Cols-2] = _pxxVDC;
                arr_MECtoXL[_cptNDX , arr_BIG_Cols-1] = _typ;

            }
            arr_MECtoXL[_cptNDX , _ndx_IDC] = _EN1 ;


            if (arr_MECtoXL[_cptNDX + 1, 0] == "~")
            {
                arr_MECtoXL[_cptNDX+1, 0] = titl2 ;
                arr_MECtoXL[_cptNDX + 1, arr_BIG_Cols - 2] = _pxxVDC;
                arr_MECtoXL[_cptNDX + 1, arr_BIG_Cols - 1] = _typ;
            }
            arr_MECtoXL[_cptNDX+1, _ndx_IDC] =_WEIT  ;


              if (arr_MECtoXL[_cptNDX+2, 0] == "~")
            {
                arr_MECtoXL[_cptNDX+2, 0] = titl3 ;
                arr_MECtoXL[_cptNDX + 2, arr_BIG_Cols - 2] = _pxxVDC;
                arr_MECtoXL[_cptNDX + 2, arr_BIG_Cols - 1] = _typ;
            }
             arr_MECtoXL[_cptNDX+2, _ndx_IDC] = _WEITkg  ;

            if (arr_MECtoXL[_cptNDX+3, 0] == "~")
            {
                arr_MECtoXL[_cptNDX + 3, 0] = titl4;
                arr_MECtoXL[_cptNDX + 3, arr_BIG_Cols - 2] = _pxxVDC;
                arr_MECtoXL[_cptNDX + 3, arr_BIG_Cols - 1] = _typ;
            }
             arr_MECtoXL[_cptNDX+3, _ndx_IDC] = _KW  ;

            if (arr_MECtoXL[_cptNDX+4, 0] == "~")
            {
                arr_MECtoXL[_cptNDX + 4, 0] = titl5;
                arr_MECtoXL[_cptNDX + 4, arr_BIG_Cols - 2] = _pxxVDC;
                arr_MECtoXL[_cptNDX + 4, arr_BIG_Cols - 1] = _typ;
            }
            arr_MECtoXL[_cptNDX + 4, _ndx_IDC] = _BTU;

           
            
          }




        private void AllChargers_AllPhase(string p,int ndx_deb, int ndx_fin)
        {
            string Curr_CHREF = "", Curr_AvailID = "",_Vdc="",_Idc="",Ovdc="";

                MainMDI.Exec_SQL_JFS("Delete CHARGERS_COST0" + p, " delete charger_COSTx for Pricing...");
                ccount = 1;
                Row_Big = 0;
                for (int c_ndx = ndx_deb; c_ndx < ndx_fin  ; c_ndx++)
                {
                  
                    System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
                    itm = (System.Web.UI.WebControls.ListItem)cbFrom.Items[c_ndx];
                    Curr_AvailID = itm.Value;
                    Curr_CHREF = itm.Text;
                    if (!deco_chrg(Curr_CHREF, ref _Vdc, ref _Idc)) MessageBox.Show("ERooooooooor:  VDC / IDC");
                    if (!VDC_Disabled(p, _Vdc))
                    {
                        if (Ovdc != _Vdc)
                        {

                            HT_CPT.Clear();
                            if (Ovdc != "")
                            {
                                do_Totals("P4500-" + p + "-" + Ovdc);
                                do_Other_CHARGERS(p.ToString(), "P4500", Ovdc, arr_IdcBIGtot);
                                init_row_BIG(Row_Big++, "B", " ");
                            }
                            init_row_BIG(Row_Big++, "L", "P4500-" + p + "-" + _Vdc);
                            init_arr_idcTOT();

                        }
                        Price_BIGtoXL_ALLCPT(p.ToString(), _Vdc, _Idc, Curr_AvailID);
                        //     tCount.Text = ccount.ToString();// tCount.Refresh();
                        ccount++;
                        //  this.Refresh();
                        Ovdc = _Vdc;
                    }
        
                }
                if (ccount > 1)
                {
                    string vv = (VDC_Disabled(p, _Vdc)) ? Ovdc : _Vdc;
                    do_Totals("P4500-" + p + "-" + vv);
                    do_Other_CHARGERS(p.ToString(), "P4500", vv, arr_IdcBIGtot);
                }

     //           if (!VDC_Disabled(p, _Vdc))
     //           {
      //              do_Totals("P4500-" + p + "-" + _Vdc);
      //              do_Other_CHARGERS(p.ToString(), "P4500", _Vdc, arr_IdcBIGtot);
      //          }

        }
        private void init_row_MEC(string _phs,ref string[,] arr_MECtoXL,  int _row, string opera, string Pxx)
        {
            switch (opera)
            {
                case "B":
                    for (int c = 0; c < arr_BIG_Cols; c++) arr_BIGtoXL[_row, c] = " ";
                    break;
                case "L":
                    arr_BIGtoXL[_row, 0] = Pxx;
                    arr_BIGtoXL[_row, arr_BIG_Cols - 2] = Pxx;
                    arr_BIGtoXL[_row, arr_BIG_Cols - 1] = opera;
                    for (int c = 1; c < arr_BIG_Cols - 2; c++) arr_BIGtoXL[_row, c] = cbIDC.Items[c - 1].ToString();
                    break;
                case "MB":
                    for (int c = 0; c < arr_BIG_Cols; c++) arr_MECtoXL[_row, c] = " ";
                    break;
                case "ML":
                    arr_MECtoXL[_row, 0] = Pxx;
                    arr_MECtoXL[_row, arr_BIG_Cols - 2] = Pxx;
                    arr_MECtoXL[_row, arr_BIG_Cols - 1] = "L";// opera;
                    for (int c = 1; c < arr_BIG_Cols - 2; c++) arr_MECtoXL[_row, c] = cbIDC.Items[c - 1].ToString();
                    break;

            }
        }



        private void init_row_BIG(int _row, string opera,string Pxx)
        {
            switch (opera)
            {
                case "B":
                    for (int c = 0; c < arr_BIG_Cols; c++) arr_BIGtoXL[_row, c] = " ";
                    break;
                case "L":
                    arr_BIGtoXL[_row, 0] = Pxx;
                    arr_BIGtoXL[_row, arr_BIG_Cols-2] = Pxx;
                    arr_BIGtoXL[_row, arr_BIG_Cols-1] = opera;
                    for (int c = 1; c < arr_BIG_Cols - 2; c++) arr_BIGtoXL[_row, c] = cbIDC.Items[c-1].ToString();   
                    break;
                    /*
               case "MB":
                    for (int c = 0; c < arr_BIG_Cols; c++) arr_MECtoXL [_row, c] = " ";
                    break;
               case "ML":
                    arr_MECtoXL [_row, 0] = Pxx;
                    arr_MECtoXL[_row, arr_BIG_Cols-2] = Pxx;
                    arr_MECtoXL[_row, arr_BIG_Cols - 1] = "L";// opera;
                    for (int c = 1; c < arr_BIG_Cols - 2; c++) arr_MECtoXL[_row, c] = cbIDC.Items[c-1].ToString();   
                    break;
                     * */

            }
        }




        private void ToBIGXL(int _ndx_IDC,string _cptNM, string _prc,string _pxxVDC, string _typ, string _cat1, string _cap1, string _cat2, string _cap2, string _cat3, string _cap3)
        {
             int _cptNDX=-1;

            if (HT_CPT.Contains (_cptNM ))   _cptNDX=Int32.Parse( HT_CPT[_cptNM].ToString ());
            else 
            {
                HT_CPT.Add(_cptNM ,Row_Big.ToString ());
                _cptNDX = Row_Big ;
                Row_Big += 4;
            }

            if (arr_BIGtoXL[_cptNDX, 0] == "~")
            {
                arr_BIGtoXL[_cptNDX, 0] = _cptNM ;
                arr_BIGtoXL[_cptNDX, arr_BIG_Cols-2] = _pxxVDC;
                arr_BIGtoXL[_cptNDX, arr_BIG_Cols-1] = _typ;

            }
            if (_prc != MainMDI.VIDE) arr_BIGtoXL[_cptNDX, _ndx_IDC] = MainMDI.A00(Tools.Conv_Dbl(_prc).ToString());
            else arr_BIGtoXL[_cptNDX, _ndx_IDC] = "c/f";


            if (arr_BIGtoXL[_cptNDX+1, 0] == "~")
            {
                arr_BIGtoXL[_cptNDX+1, 0] = "   [" + _cat1  + "]";
                arr_BIGtoXL[_cptNDX + 1, arr_BIG_Cols-2] = _pxxVDC;
                arr_BIGtoXL[_cptNDX + 1, arr_BIG_Cols-1] = _typ;

            }
            arr_BIGtoXL[_cptNDX + 1, _ndx_IDC] = _cap1;


            if (arr_BIGtoXL[_cptNDX + 2, 0] == "~")
            {
                arr_BIGtoXL[_cptNDX+2, 0] = "   [" + _cat2 + "]";
                arr_BIGtoXL[_cptNDX + 2, arr_BIG_Cols - 2] = _pxxVDC;
                arr_BIGtoXL[_cptNDX + 2, arr_BIG_Cols - 1] = _typ;
            }
            arr_BIGtoXL[_cptNDX+2, _ndx_IDC] = _cap2 ;


              if (arr_BIGtoXL[_cptNDX+3, 0] == "~")
            {
                arr_BIGtoXL[_cptNDX+3, 0] = "   [" + _cat3 + "]";
                arr_BIGtoXL[_cptNDX + 3, arr_BIG_Cols - 2] = _pxxVDC;
                arr_BIGtoXL[_cptNDX + 3, arr_BIG_Cols - 1] = _typ;
            }
             arr_BIGtoXL[_cptNDX+3, _ndx_IDC] = _cap3 ;
            

            
        }

        private void Compute_OneCPT(string _Pxx, string _Phs, string _Vdc, string _Idc, string _Vac, string _VdcMax, string _lcptID, string Curr_CPTNM)
        {

            txCPTresult.Text = "";
            Component Cpt = null;
            Charger CHRGR = null;

            CHRGR = new Charger(0, "F", _Pxx, _Phs, _Vdc, _Idc, _Vac, _VdcMax);

            Cpt = new Component();
           
            string tt = Cpt.Cal_chrg_CostADO(Convert.ToInt32(_lcptID), "C");
        
            string    CatNM1 = HT_CPT_cat[Curr_CPTNM + "_CAT1"].ToString();
            string CatNM2 = HT_CPT_cat[Curr_CPTNM + "_CAT2"].ToString();
            string CatNM3 = HT_CPT_cat[Curr_CPTNM + "_CAT3"].ToString();
           txCPTresult.Text = Curr_CPTNM + " Cost is= " + Cpt.G_PRICE + " categories: " + CatNM1 + "= " + Cpt.CAP1 + ",  " + CatNM2 + "= " + Cpt.CAP2 + ",  " + CatNM3 + "= " + Cpt.CAP3;
             
        }




        private void Price_BIGtoXL_ALLCPT(string _phs, string _Vdc, string _Idc, string Avail_id)
        {
            double Idc_TOT=0;
            string stSql1 = "SELECT TBLAVAIL" + _phs + ".Avail_ID, COMPNT_LIST.Component_ID,COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + _phs + ".charger, TBLAVAIL" + _phs + ".vdc, TBLAVAIL" + _phs + ".idc, link_COMPNT_AVAIL.Qty, COMPNT_LIST.CAT1_TABLE_ID, COMPNT_LIST.CAT2_TABLE_ID, COMPNT_LIST.CAT3_TABLE_ID, COMPNT_LIST.Compnt_Type, COMPNT_LIST.Value_Type, COMPNT_LIST.nbc3Cat " +
                         " FROM (TBLAVAIL" + _phs + " INNER JOIN link_COMPNT_AVAIL ON TBLAVAIL" + _phs + ".Avail_ID = link_COMPNT_AVAIL.Avail_ID) INNER JOIN COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = COMPNT_LIST.Component_ID " +
                         " Where (((link_COMPNT_AVAIL.phs) = '" + _phs + "') and ((link_COMPNT_AVAIL.Avail_ID) = " + Avail_id + ")) ORDER BY TBLAVAIL" + _phs + ".Avail_ID, COMPNT_LIST.Component_ID";

            string _Pxx = "P4500", _Vac = "", _VdcMax = "", _lcptID = "", Curr_CPTNM = "", PXX_P_VDC = "P4500-" + _phs + "-" + _Vdc, CatNM1 = MainMDI.VIDE, CatNM2 = MainMDI.VIDE, CatNM3 = MainMDI.VIDE;
            Component Cpt = null;
            Charger CHRGR = null;

            CHRGR = new Charger(0, "F", _Pxx, _phs, _Vdc, _Idc, _Vac, _VdcMax);

            int ndx_IDC = Int32.Parse(HT_IDC[_Idc].ToString());
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql1;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int Curr_LN = Row_Big;
            string stSql2 = "";

            //    init_row_BIG(0, "L", PXX_P_VDC);
            string[] arr_VV = new string[12];
            while (Oreadr.Read())
            {
  

                    //   if (Oreadr["COMPONENT_REF"].ToString().IndexOf("MD1-SCR") > -1 ) _lcptID = _lcptID;
                    string Row_type = "C";
                    Cpt = new Component();
                    _lcptID = Oreadr["Component_ID"].ToString();
                   // for debuging CPT cost 
                    if (_lcptID == "238") _lcptID = _lcptID;
                    Curr_CPTNM = Oreadr["COMPONENT_REF"].ToString();
                    string tt = Cpt.Cal_chrg_CostADO(Convert.ToInt32(_lcptID), "C");
                    if (Oreadr["Compnt_Type"].ToString() != "%" && Oreadr["COMPONENT_REF"].ToString() != MainMDI.VIDE)
                    {
                        CatNM1 = HT_CPT_cat[Curr_CPTNM + "_CAT1"].ToString();
                        CatNM2 = HT_CPT_cat[Curr_CPTNM + "_CAT2"].ToString();
                        CatNM3 = HT_CPT_cat[Curr_CPTNM + "_CAT3"].ToString();

                        //added on 30/04/2009
                        if (IDC_Disabled(_phs, _Idc)) Cpt.G_PRICE = MainMDI.VIDE;
                        //added on 30/04/2009

                        ToBIGXL(ndx_IDC, Curr_CPTNM, Cpt.G_PRICE, PXX_P_VDC, Row_type, CatNM1, Cpt.CAP1, CatNM2, Cpt.CAP2, CatNM3, Cpt.CAP3);
                   
                        if (Cpt.G_PRICE != MainMDI.VIDE && Idc_TOT != -1) Idc_TOT += Tools.Conv_Dbl(Cpt.G_PRICE);
                        else Idc_TOT = -1;

                    }
                    else if (Oreadr["nbc3Cat"].ToString() == "B") arr_IdcPRCT[ndx_IDC] = Oreadr["Value_Type"].ToString();
         
            
                arr_VV[0] = Oreadr["Avail_ID"].ToString();
                arr_VV[1] = _lcptID;
                arr_VV[2] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.CAP1;
                arr_VV[3] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.CAP2;
                arr_VV[4] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.CAP3;
                arr_VV[5] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.Real_QTY;
                arr_VV[6] = (Oreadr["Compnt_Type"].ToString() == "%") ? Oreadr["Value_Type"].ToString():Tools.Conv_Dbl(Cpt.G_PRICE).ToString(); //MainMDI.A00(Tools.Conv_Dbl(Cpt.G_PRICE).ToString());
                arr_VV[7] = Oreadr["Compnt_Type"].ToString();
                stSql2 = "INSERT INTO CHARGERS_COST0" + _phs + " ([Avail_ID],[Compnt_ID],[Cap1],[Cap2],[Cap3],[Real_QTY],[COST],[cost_type]) VALUES (" +
                    arr_VV[0] + " , "   +
                    arr_VV[1] + " , '"  +
                    arr_VV[2] + "' , '" +
                    arr_VV[3] + "' , '" +
                    arr_VV[4] + "' , '" +
                    arr_VV[5] + "' , '" +
                    arr_VV[6] + "' , '" +
                    arr_VV[7] + "')";
                MainMDI.ExecSql(stSql2);
            }
            arr_IdcTOT[ndx_IDC] = Idc_TOT.ToString ();
 
        }



        private void Price_BIGtoXL_ALLCPT_OK_OLD(string _phs, string _Vdc, string _Idc, string Avail_id)
        {
            double Idc_TOT = 0;
            string stSql = "SELECT TBLAVAIL" + _phs + ".Avail_ID, COMPNT_LIST.Component_ID,COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + _phs + ".charger, TBLAVAIL" + _phs + ".vdc, TBLAVAIL" + _phs + ".idc, link_COMPNT_AVAIL.Qty, COMPNT_LIST.CAT1_TABLE_ID, COMPNT_LIST.CAT2_TABLE_ID, COMPNT_LIST.CAT3_TABLE_ID, COMPNT_LIST.Compnt_Type, COMPNT_LIST.Value_Type, COMPNT_LIST.nbc3Cat " +
                         " FROM (TBLAVAIL" + _phs + " INNER JOIN link_COMPNT_AVAIL ON TBLAVAIL" + _phs + ".Avail_ID = link_COMPNT_AVAIL.Avail_ID) INNER JOIN COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = COMPNT_LIST.Component_ID " +
                         " Where (((link_COMPNT_AVAIL.phs) = '" + _phs + "') and ((link_COMPNT_AVAIL.Avail_ID) = " + Avail_id + ")) ORDER BY TBLAVAIL" + _phs + ".Avail_ID, COMPNT_LIST.Component_ID";

            string _Pxx = "P4500", _Vac = "", _VdcMax = "", _lcptID = "", Curr_CPTNM = "", PXX_P_VDC = "P4500-" + _phs + "-" + _Vdc, CatNM1 = MainMDI.VIDE, CatNM2 = MainMDI.VIDE, CatNM3 = MainMDI.VIDE;
            Component Cpt = null;
            Charger CHRGR = null;

            CHRGR = new Charger(0, "F", _Pxx, _phs, _Vdc, _Idc, _Vac, _VdcMax);

            int ndx_IDC = Int32.Parse(HT_IDC[_Idc].ToString());
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int Curr_LN = Row_Big;

            //    init_row_BIG(0, "L", PXX_P_VDC);
            string[] arr_VV = new string[12];
            while (Oreadr.Read())
            {


                //   if (Oreadr["COMPONENT_REF"].ToString().IndexOf("MD1-SCR") > -1 ) _lcptID = _lcptID;
                string Row_type = "C";
                Cpt = new Component();
                _lcptID = Oreadr["Component_ID"].ToString();
                Curr_CPTNM = Oreadr["COMPONENT_REF"].ToString();
                string tt = Cpt.Cal_chrg_CostADO(Convert.ToInt32(_lcptID), "C");
                if (Oreadr["Compnt_Type"].ToString() != "%" && Oreadr["COMPONENT_REF"].ToString() != MainMDI.VIDE)
                {
                    CatNM1 = HT_CPT_cat[Curr_CPTNM + "_CAT1"].ToString();
                    CatNM2 = HT_CPT_cat[Curr_CPTNM + "_CAT2"].ToString();
                    CatNM3 = HT_CPT_cat[Curr_CPTNM + "_CAT3"].ToString();

                    ToBIGXL(ndx_IDC, Curr_CPTNM, Cpt.G_PRICE, PXX_P_VDC, Row_type, CatNM1, Cpt.CAP1, CatNM2, Cpt.CAP2, CatNM3, Cpt.CAP3);

                    Idc_TOT += Tools.Conv_Dbl(Cpt.G_PRICE);

                }
                else if (Oreadr["nbc3Cat"].ToString() == "B") arr_IdcPRCT[ndx_IDC] = Oreadr["Value_Type"].ToString();


                arr_VV[0] = Oreadr["Avail_ID"].ToString();
                arr_VV[1] = _lcptID;
                arr_VV[2] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.CAP1;
                arr_VV[3] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.CAP2;
                arr_VV[4] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.CAP3;
                arr_VV[5] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.Real_QTY;
                arr_VV[6] = (Oreadr["Compnt_Type"].ToString() == "%") ? Oreadr["Value_Type"].ToString() : Tools.Conv_Dbl(Cpt.G_PRICE).ToString(); //MainMDI.A00(Tools.Conv_Dbl(Cpt.G_PRICE).ToString());
                arr_VV[7] = Oreadr["Compnt_Type"].ToString();
                stSql = "INSERT INTO CHARGERS_COST0" + _phs + " ([Avail_ID],[Compnt_ID],[Cap1],[Cap2],[Cap3],[Real_QTY],[COST],[cost_type]) VALUES (" +
                    arr_VV[0] + " , " +
                    arr_VV[1] + " , '" +
                    arr_VV[2] + "' , '" +
                    arr_VV[3] + "' , '" +
                    arr_VV[4] + "' , '" +
                    arr_VV[5] + "' , '" +
                    arr_VV[6] + "' , '" +
                    arr_VV[7] + "')";
                MainMDI.ExecSql(stSql);
            }
            arr_IdcTOT[ndx_IDC] = Idc_TOT.ToString();

        }



        private void button2_Click(object sender, EventArgs e)
        {
            //cbCpts.Text = "CB1";
            Disp_Formulas();
        }
        private void Disp_Formulas()
        {
            string _errmsg="";
            if (cbCpts.Text == "ALL" || cbCpts.Text == "")  _errmsg = " a Component ";
            if (cbFrom.Text == "ALL" || cbFrom.Text == "") _errmsg = " a Charger FROM ";
            if (cbVCS.Text == "ALL" || cbFrom.Text == "") _errmsg = " a Formulas ";
            if (_errmsg != "") MessageBox.Show("Please select" + _errmsg);
            else
            {
                grpResult.Visible = true;
             //   System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
             //   itm = (System.Web.UI.WebControls.ListItem)cbVCS.Items[cbVCS  ];
             //   string vcs_LID= itm.Value;
                lfrml.Text = cbVCS.Text ;
                lch.Text = cbFrom.Text; 
                string _vdc = "", _Idc = "", _Vac = "", _VdcMax = "";
                string Curr_CHREF = cbFrom.Items[cbFrom.SelectedIndex].ToString();
                if (!deco_chrg(Curr_CHREF, ref _vdc , ref _Idc)) MessageBox.Show("ERooooooooor:  VDC / IDC");
               Charger  CHRGR = new Charger(0, "F","P4500",G_PHS   , _vdc , _Idc, _Vac, _VdcMax);
               Component Cpt = new Component();
           //    tResult.Text = Cpt.Cal_VCS(Int32.Parse(vcs_LID), cbVCS.Text);  
               tResult.Text = Cpt.Cal_VCS(0, cbVCS.Text); 
            }
        }


 
        private void button1_Click(object sender, EventArgs e)
        {
            add_lvBIG(arr_BIGtoXL_SUM );
        }

        private void button3_Click(object sender, EventArgs e)
        {
            add_lvBIG(arr_BIGtoXL);
        }




        private void SendtoXL_13()
        {

          //  const string xlFNM = @"\Sam_PricingTemp.xls", xlFNMout = @"\Sam_Pricing.xls";

            if (m_objXL == null) m_objXL = new Excel.Application();
            string XLname = MainMDI.XL_Path + xlFNMout ;

            File.Delete(XLname );
            File.Copy(MainMDI.XL_Path + xlFNM, XLname);

            bool xldone = false;
            int p = 1;
            for (p = 1; p < 4; p += 2)
            {

                string[,] _arrBig = (p == 1) ? arr_BIG_01 : arr_BIG_03;
                string[,] arr_MECtoXL = (p == 1) ? arr_MECtoXL01 : arr_MECtoXL03;

                if (_arrBig[0, 0] != "~")
                {
                    xldone = true;
                    switch (lopt.Text)
                    {
                        case "D":
                            arr_Mode_Details(_arrBig);
                            Write_XL_priceList(p.ToString(), arr_BIGtoXL, XLname);
                            Write_XL_MECanical(p.ToString(), arr_MECtoXL, XLname);
                          
                            break;
                        case "S":
                            arr_Mode_Summary(_arrBig);
                            Write_XL_priceList(p.ToString(), arr_BIGtoXL_SUM, XLname);
                            Write_XL_MECanical(p.ToString(), arr_MECtoXL, XLname);
                            break;
                        case "C":
                            arr_Mode_ChargerOnly(_arrBig);
                            Write_XL_priceList(p.ToString(), arr_BIGtoXL_Chargers, XLname);
                            Write_XL_MECanical(p.ToString(), arr_MECtoXL, XLname);
                            break;
                    }
                }
                else MessageBox.Show("Sorry , No pricing is available....(Press Button [Calculate Pricing ( 1 & 3 PHASE)] and Retry)");
            }

            m_objXL.Quit(); 
             
           if (xldone ) MainMDI.OpenKnownFile(MainMDI.XL_Path + xlFNMout); //MainMDI.XL_Path + xlFNM;
        }


        private void Compute_13()
        {
          //  timer1.Enabled = true;
          //  string msgOK = "Prices Calculated succesfully for:  ",phss="";
            int p = 1;
            init_arr_Big(ref arr_BIG_01);
            init_arr_Big(ref arr_BIG_03);

                      
            
            bool p1 = false, p3 = false;
            for (p = 1; p < 4; p += 2)
            {
               // btnPHS.Text = p.ToString();
                G_PHS = p.ToString();
                chng_PHS();
                init_arr_Big(ref arr_BIGtoXL ); //init_arr_Big(arr_BIG_03); init_arr_Big(arr_BIG_01);
                init_arr_idcTOT();
                HT_CPT.Clear();
                AllChargers_AllPhase(p.ToString(), 0, cbFrom.Items.Count - 1);
                Create_TBLTOXL_13 (p.ToString());
                if (p == 1) p1 = true; 
                if (p == 3) p3= true;
         
 
            }

            if (p1) { fill_arrBIG_XX("1", ref arr_BIG_01); phss += " [1 Phase] "; }
            if (p3) { fill_arrBIG_XX("3", ref arr_BIG_03); phss  += ",  [3 Phase] "; }
            endProc = true;
            if (phss.Length == 0) msgOK = "Sorry Calculations Failed....";

            

          //  MessageBox.Show(msgOK + phss);
          
        }




        private void Compute_SelectedPHS()
        {
            //  timer1.Enabled = true;
            //  string msgOK = "Prices Calculated succesfully for:  ",phss="";
            bool p1 = false, p3 = false;
          if (btnPHS.Text =="1")   init_arr_Big(ref arr_BIG_01);
          if (btnPHS.Text == "3") init_arr_Big(ref arr_BIG_03);

            int p = Int32.Parse (btnPHS.Text ) ;
                // btnPHS.Text = p.ToString();
                G_PHS = p.ToString();
                chng_PHS();
                init_arr_Big(ref arr_BIGtoXL); //init_arr_Big(arr_BIG_03); init_arr_Big(arr_BIG_01);
                init_arr_idcTOT();
                HT_CPT.Clear();
                AllChargers_AllPhase(p.ToString(), cbFrom.SelectedIndex  , cbTO.SelectedIndex+1 );
                Create_TBLTOXL_13(p.ToString());
                if (p == 1) p1 = true;
                if (p == 3) p3 = true;

            if (p1) { fill_arrBIG_XX("1", ref arr_BIG_01); phss += " [1 Phase] "; }
            if (p3) { fill_arrBIG_XX("3", ref arr_BIG_03); phss += ",  [3 Phase] "; }
            endProc = true;
            if (phss.Length == 0) msgOK = "Sorry Calculations Failed....";
            //  MessageBox.Show(msgOK + phss);

        }
     
        private void Create_TBLTOXL_13(string _phs)
        {

        

            MainMDI.Exec_SQL_JFS("delete  TBLTOXL0" + _phs + "_SIM ", " delete TBLTOXL0" + _phs + "_SIM for Pricing....");
            string stSql = "", stV = "";
            for (int r = 0; r < arr_BIG_Rows; r++)
            {
                if (arr_BIGtoXL[r, 0] != "~")
                {
                    stSql = "INSERT INTO TBLTOXL0" + _phs + "_SIM ([COMPONENT]";
                    stV = ") VALUES ('";
                    for (int c = 0; c < arr_BIG_Cols; c++)
                    {

                        if (c < arr_BIG_Cols -3) stSql += ",[" + arr_IDC[c].ToString() + "]";
                        else
                        {
                            if (c == (arr_BIG_Cols -3)) stSql += ",[REF_CHRG]";
                            if (c == (arr_BIG_Cols - 2)) stSql += ",[cRec]";
                        }
                        if (c < (arr_BIG_Cols - 1)) stV += arr_BIGtoXL[r, c].ToString() + "' , '";
                        else stV += arr_BIGtoXL[r, c].ToString() + "')";

                    }
                    stSql += stV;
                }
                else 
                {
                    r = arr_BIG_Rows;
                    stSql = "";
                }
               //for debug  if (stSql == "") stSql = stSql;
                if (stSql != "") MainMDI.ExecSql(stSql);
            }
        }

        private void Write_XL_MECanical(string _phs, string[,] _arrBIGxl, string XLname)
        {


            Object m_objOpt = System.Reflection.Missing.Value;

            Excel.Workbook m_objBook = m_objXL.Workbooks.Open(XLname, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            Excel.Sheets m_objSheets = m_objBook.Worksheets;

            Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.Add(m_objOpt, m_objOpt, m_objOpt, m_objOpt);//  .get_Item(1);
            string CelFrom = "A1", CelTo = "AK1";

            Excel.Range m_objRng = m_objSheet.get_Range(CelFrom, CelTo);
            string[] objHdrs = new string[arr_BIG_Cols - 2];// { "Description", cat1NM, cat2NM, cat3NM, "Sell Price", "Primax Code" };

            m_objRng.Value2 = objHdrs;
            Excel.Font m_objFont = m_objRng.Font;
            m_objFont.Bold = true;
            object[,] objData = new object[arr_BIG_Rows, arr_BIG_Cols - 2];
            for (int i = 0; i < arr_BIG_Rows; i++)
            {
                if (_arrBIGxl[i, 0] != "")
                    for (int j = 0; j < arr_BIG_Cols - 2; j++) objData[i, j] = (_arrBIGxl[i, j] != "~") ? _arrBIGxl[i, j] : "";   //(_arrBIGxl[i, 0] != "") ? Idata[i, j] : "";
                else i = arr_BIG_Rows;
            }

            m_objRng = m_objSheet.get_Range("A2", m_objOpt);
            m_objRng = m_objRng.get_Resize(arr_BIG_Rows, arr_BIG_Cols - 2);
            m_objRng.Value2 = objData;
            m_objSheet.Name = _phs + " mechanical ";

            int WSNb = m_objBook.Worksheets.Count;
            m_objSheet.Move(m_objOpt, m_objBook.Worksheets[WSNb]);
            if (m_objBook.Worksheets.Count > 4)
            {
                Excel.Worksheet ws = (Excel.Worksheet)m_objBook.Worksheets[1];
                if (ws.Name == "Sheet1") ws.Delete();
                //         ((Excel.Worksheet)this.Application.ActiveWorkbook.Sheets[1]).Select(missing);
                // &&  m_objBook.Worksheets[1]=="Sheet1")  m_objBook.Worksheets
            }

            //     m_objBook.SaveAs(XLname, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            // if (_phs =="1")      m_objBook.SaveAs(MainMDI.XL_Path + xlFNMout , m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Save();

            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();



        }

        private void Write_XL_priceList(string _phs, string[,] _arrBIGxl ,string XLname)
        {


                Object m_objOpt = System.Reflection.Missing.Value;

                Excel.Workbook m_objBook = m_objXL.Workbooks.Open(XLname, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                Excel.Sheets m_objSheets = m_objBook.Worksheets;

                Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.Add(m_objOpt, m_objOpt, m_objOpt, m_objOpt);//  .get_Item(1);
                string CelFrom = "A1", CelTo = "AK1";

                Excel.Range m_objRng = m_objSheet.get_Range(CelFrom, CelTo);
                string[] objHdrs = new string[arr_BIG_Cols-2 ];// { "Description", cat1NM, cat2NM, cat3NM, "Sell Price", "Primax Code" };
                
                m_objRng.Value2 = objHdrs;
                Excel.Font m_objFont = m_objRng.Font;
                m_objFont.Bold = true;
                object[,] objData = new object[arr_BIG_Rows ,arr_BIG_Cols-2 ];
                for (int i = 0; i < arr_BIG_Rows; i++)
                {
                    if (_arrBIGxl[i, 0] != "")
                        for (int j = 0; j < arr_BIG_Cols - 2; j++) objData[i, j] = (_arrBIGxl[i, j] != "~" ) ?_arrBIGxl[i, j]:"";   //(_arrBIGxl[i, 0] != "") ? Idata[i, j] : "";
                    else i = arr_BIG_Rows;
                }

                m_objRng = m_objSheet.get_Range("A2", m_objOpt);
                m_objRng = m_objRng.get_Resize(arr_BIG_Rows , arr_BIG_Cols -2);
                m_objRng.Value2 = objData;
                m_objSheet.Name =_phs + " PHASE "; 

                int WSNb = m_objBook.Worksheets.Count;
                m_objSheet.Move(m_objOpt, m_objBook.Worksheets[WSNb]);
                if (m_objBook.Worksheets.Count > 2)
                {
                    Excel.Worksheet ws = (Excel.Worksheet)m_objBook.Worksheets[1];
                    if (ws.Name == "Sheet1") ws.Delete();
                    //         ((Excel.Worksheet)this.Application.ActiveWorkbook.Sheets[1]).Select(missing);
                    // &&  m_objBook.Worksheets[1]=="Sheet1")  m_objBook.Worksheets
                }

           //     m_objBook.SaveAs(XLname, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
         // if (_phs =="1")      m_objBook.SaveAs(MainMDI.XL_Path + xlFNMout , m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
          m_objBook.Save();  
  
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();
     
         

        }

        private void Write_XL_priceListOLDok(string _phs, string[,] _arrBIGxl, string XLname)
        {


            Object m_objOpt = System.Reflection.Missing.Value;
            // Excel.Application  m_objXL = new Excel.Application();


            Excel.Workbook m_objBook = m_objXL.Workbooks.Open(XLname, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            Excel.Sheets m_objSheets = m_objBook.Worksheets;


            Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.Add(m_objOpt, m_objOpt, m_objOpt, m_objOpt);//  .get_Item(1);
            string CelFrom = "A1", CelTo = "AK1";

            //	write_XL(Oreadr["Component_Name"].ToString (),CelFromTo ,objHdrs,Idata); 


            //     Excel._Worksheet ws = ((Excel._Worksheet) m_objSheets.get_Item( 
            //   MessageBox.Show (icount.ToString ()); 
            Excel.Range m_objRng = m_objSheet.get_Range(CelFrom, CelTo);
            string[] objHdrs = new string[arr_BIG_Cols - 2];// { "Description", cat1NM, cat2NM, cat3NM, "Sell Price", "Primax Code" };

            m_objRng.Value2 = objHdrs;
            Excel.Font m_objFont = m_objRng.Font;
            m_objFont.Bold = true;
            object[,] objData = new object[arr_BIG_Rows, arr_BIG_Cols - 2];
            for (int i = 0; i < arr_BIG_Rows; i++)
            {
                if (_arrBIGxl[i, 0] != "")
                    for (int j = 0; j < arr_BIG_Cols - 2; j++) objData[i, j] = (_arrBIGxl[i, j] != "~") ? _arrBIGxl[i, j] : "";   //(_arrBIGxl[i, 0] != "") ? Idata[i, j] : "";
                else i = arr_BIG_Rows;
            }

            m_objRng = m_objSheet.get_Range("A2", m_objOpt);
            m_objRng = m_objRng.get_Resize(arr_BIG_Rows, arr_BIG_Cols - 2);
            m_objRng.Value2 = objData;
            m_objSheet.Name = _phs + " PHASE ";

            int WSNb = m_objBook.Worksheets.Count;
            m_objSheet.Move(m_objOpt, m_objBook.Worksheets[WSNb]);
            if (m_objBook.Worksheets.Count > 2)
            {
                Excel.Worksheet ws = (Excel.Worksheet)m_objBook.Worksheets[1];
                if (ws.Name == "Sheet1") ws.Delete();
                //         ((Excel.Worksheet)this.Application.ActiveWorkbook.Sheets[1]).Select(missing);
                // &&  m_objBook.Worksheets[1]=="Sheet1")  m_objBook.Worksheets
            }

            //     m_objBook.SaveAs(XLname, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            // if (_phs =="1")      m_objBook.SaveAs(MainMDI.XL_Path + xlFNMout , m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Save();

            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();



        }


        private void exl_Click(object sender, EventArgs e)
        {
            SendtoXL_13 ();
        }

        private void btn_arch_Click(object sender, EventArgs e)
        {
            grpSim.Visible = false;
            grpITM.Height = 153;//63
            grp_period.Visible = true;
            dpPdat.Text = DateTime.Now.ToShortDateString();  

        }
        private void archPrices()
        {
            string msgOK = "Prices Archived succesfully for PHASE:  ",phss="";
            if (txPrd.Text.Length == 4)
            {
               string res=MainMDI.Find_One_Field("select * from ARCH_COST13 where period='" + txPrd.Text + "'") ;
               
                if (res == MainMDI.VIDE || MainMDI.Confirm ("Archive already exist for this Period= " + txPrd.Text + "  want to overwrite ?"))
                {
                    MainMDI.Exec_SQL_JFS ("delete ARCH_COST13 where period='" + txPrd.Text + "'"," delete all archived prices for a period");
                    for (int p=1;p<4;p+=2)
                    {

                        string stSql = " insert INTO ARCH_COST13  SELECT '" + txPrd.Text + "' AS period, '" + p.ToString() + "' AS phs, REF_CHRG, [5], [10], [15], [20], [25], [30], [35], [40], [50], [60], [70], [75], [80], [100], [125], [150], [175], [200], [225], [250], [275], [300], [325], [350], [375], [400], [500], [600], [750], [800], [900], [1000], [1250], [1500], [2000], [2500] " +
                            " FROM  TBLTOXL0"+ p.ToString() + " WHERE cRec = 'T'";
                      MainMDI .Exec_SQL_JFS (stSql," insert new archived Prices for a period.....");
                      phss += "[" + p.ToString() + "] "; 

                    }
                }
               //lse MessageBox.Show("Sorry Archived prices already exist for this Period= " + txPrd.Text);
            }
            else MessageBox.Show("Sorry Period is Invalid, please choose a valid archive period.....(double-click on period and change new date)");
            if (phss.Length > 0) MessageBox.Show(msgOK  + phss); 
        }

        private void button4_Click(object sender, EventArgs e)
        {

            archPrices();

           // grpSim.Visible = true;
            grp_period.Visible = false;
          
        }

        private void button5_Click(object sender, EventArgs e)
        {
         
            grp_period.Visible = false;
        }

        private void dpPdat_ValueChanged(object sender, EventArgs e)
        {
            txPrd.Text = dpPdat.Value.Year.ToString().Substring (2,2) +MainMDI.A00 ( dpPdat.Value.Month.ToString(),2);
            dpPdat.Visible = false;
            txPrd.Visible = true;
        }

        private void txPrd_DoubleClick(object sender, EventArgs e)
        {
           // dpPdat.Visible = true;
         //   txPrd.Visible = false;
        }



        //****************************************************
        //****************************************************

        private string calul_Amnt(string amnt1, string oper, string amnt2)
        {
            //	  On Error GoTo cal_Err
            string calul_Amnt_Res = "0";
            double mnt1 = 0, mnt2 = 0;
            if (amnt1 == Charger.VIDE || amnt2 == Charger.VIDE) return "0";
            if (oper != "&")
            {
                mnt1 = Tools.Conv_Dbl(amnt1);
                mnt2 = Tools.Conv_Dbl(amnt2);
            }
            switch (oper)
            {
                case "*":
                    calul_Amnt_Res = Convert.ToString(Math.Round(mnt1 * mnt2, Charger.NB_DEC_CAL));
                    break;
                case "-":
                    calul_Amnt_Res = Convert.ToString(Math.Round(mnt1 - mnt2, Charger.NB_DEC_CAL));
                    break;
                case "/":
                    if (mnt2 > 0) calul_Amnt_Res = Convert.ToString(Math.Round(mnt1 / mnt2, Charger.NB_DEC_CAL));
                    else calul_Amnt_Res = "0";
                    break;
                case "+":
                    calul_Amnt_Res = Convert.ToString(Math.Round(mnt1 + mnt2, Charger.NB_DEC_CAL));
                    break;
                case "&":
                    calul_Amnt_Res = amnt1 + amnt2;
                    break;
                case "#":
                    calul_Amnt_Res = MainMDI.Ceil(amnt1, amnt2).ToString();
                    break;
                default:
                    MessageBox.Show("Operator is Invalid.....=" + oper);
                    break;
            }
            return calul_Amnt_Res;
        }

        public string seekCF(string Coef)
        {



            string seekCF_Res = "0";
            string stSql = "SELECT TABLES_CONTENT.COL1, TABLES_CONTENT.VALUE1 FROM TABLES_LIST INNER JOIN TABLES_CONTENT ON TABLES_LIST.TABLE_ID = TABLES_CONTENT.TABLE_ID " +
                " WHERE (((TABLES_CONTENT.COL1)='" + Coef + "') AND ((TABLES_LIST.TABLE_NAME)='COEFICIENTS'))";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            bool fin = false;
            while (Oreadr.Read() && !fin)
            {
                seekCF_Res = Oreadr[1].ToString();
                fin = true;
            }
            OConn.Close();
            return seekCF_Res;
        }
        private bool deco_var_price(ref string var, ref string VarValue, string p, string vdc, string idc, string Base_Charger)
        {
            int ipos = 0, i = 0;
            bool found = false;
            string st = "", MF = "", prct = "";
            string stSql = "";


            bool deco_V = false;
            switch (var[0])
            {
                case 'F':
                    VarValue = seekCF(var.Substring(2, var.Length - 2));
                    deco_V = true;
                    break;
                case 'V':
                    VarValue = var.Substring(1, var.Length - 2);
                    deco_V = true;
                    break;
                case 'P':
                    if (var == G_Base_CHRG)
                    {
                        VarValue = G_BASE_TOT;
                        deco_V = true;
                        if (VarValue == "0") VarValue = MainMDI.VIDE;
                    }
                    else
                    {
                        //var = seek_FRML_PRICE(p, var);
                        var = MainMDI.Find_One_Field(" Select CONTENT from COMPUTE_VCS where VCS_TYPE='P' and VCS_NAME='" + var + "' and (PHS='2' OR PHS='" + p + "')");
                        VarValue = "*******";
                        //deco_V = (var!=MainMDI.VIDE ) ;
                    }
                    break;
                case 'M':
                    //	MessageBox.Show("ERROR MF..."); 
                    MF = var.Substring(2, var.Length - 2);
                    stSql = "SELECT COMPNT_LIST.Value_Type" +
                        " FROM (CHARGERS_COST0" + p + " INNER JOIN TBLAVAIL" + p + " ON CHARGERS_COST0" + p + ".Avail_ID = TBLAVAIL" + p + ".Avail_ID) INNER JOIN COMPNT_LIST ON CHARGERS_COST0" + p + ".Compnt_ID = COMPNT_LIST.Component_ID " +
                        " WHERE (((COMPNT_LIST.COMPONENT_REF)='" + MF + "') AND ((TBLAVAIL" + p + ".charger)='" + Base_Charger + "') AND ([vdc]='" + vdc + "') AND ((TBLAVAIL" + p + ".idc)='" + idc + "') AND ((CHARGERS_COST0" + p + ".cost_type)='%') AND ((COMPNT_LIST.nbc3Cat)='A')) " +
                        " ORDER BY COMPNT_LIST.COMPONENT_REF ";
                    VarValue = MainMDI.Find_One_Field(stSql);
                    VarValue = (VarValue == MainMDI.VIDE) ? "1" : VarValue;
                    deco_V = true;
                    break;
                case 'R':
                    //VarValue = seek_CPT_price(p, vdc, idc, CLng(Mid(var, 4, Len(var) - 3)))
                    stSql = (" SELECT CHARGERS_COST0" + p + ".COST, CHARGERS_COST0" + p + ".cost_type " +
                       " FROM CHARGERS_COST0" + p + " INNER JOIN TBLAVAIL" + p + " ON CHARGERS_COST0" + p + ".Avail_ID = TBLAVAIL" + p + ".Avail_ID " +
                       " WHERE (((CHARGERS_COST0" + p + ".Compnt_ID)=" + var.Substring(3, var.Length - 3) + ") AND ((TBLAVAIL" + p + ".idc)='" + idc + "') AND ((TBLAVAIL" + p + ".vdc)='" + vdc + "'))");
                    VarValue = MainMDI.Find_One_Field(stSql);
                    deco_V = (VarValue != MainMDI.VIDE);
                    break;
                default:
                    MessageBox.Show("DECO VAR is Invalid...=" + var);
                    break;
            }
            return deco_V;
        }



        private string Deco_Frml_Price(string p, string frml, string vdc, string idc, string Base_Charger)
        {


            int i = 0;
            int ipos = 0;
            int OPos = 0;
            bool fin = false;
            string amnt1 = "", st = frml, VarValue = "";
            string Total = "", var = "";
            string oper = "";
            string Deco = "0", period = "", chrg_VDC = "";
            switch (frml[0])
            {
                case 'P':
                    while (st[OPos] != ';' && var !="//")
                    {
                        ipos = st.IndexOf(" ", OPos);
                        var = st.Substring(OPos, ipos - OPos);
                        if (var != " " && var != "//")
                        {
                            if (var.Length > 1)
                            {
                                if (!deco_var_price(ref var, ref VarValue, p, vdc, idc, Base_Charger)) VarValue = Deco_Frml_Price(p, var, vdc, idc, Base_Charger);
                                if (VarValue != MainMDI.VIDE && VarValue != "")
                                    if (Total == "") Total = VarValue;
                                    else amnt1 = VarValue;
                                else
                                {
                                    Deco = MainMDI.VIDE;
                                    ipos = frml.IndexOf(";");
                                    Total = "";
                                }
                            }
                            else oper = var;
                            if (oper != "" && amnt1 != "" && Total != "")
                            {
                                Total = calul_Amnt(Total, oper, amnt1);
                                amnt1 = "";
                            }


                        }
                        OPos = (ipos + 1 == st.Length) ? ipos : ipos + 1;
                        //OPos = ipos ;
                    }
                    if (Deco != MainMDI.VIDE && Deco != "") Deco = Convert.ToString(Math.Round(Tools.Conv_Dbl(Total), 0));
                    break;
                case 'O':
                    Deco = MainMDI.VIDE;
                    if (frml.Length > 10)
                    {
                        period = frml.Substring(2, 4);
                        chrg_VDC = frml.Substring(7, frml.Length - 9) + "-" + vdc;
                        Deco = find_OLD_Price(p, period, chrg_VDC, idc); 
                    }
                    break;
            }

            return Deco;
        }


        private string find_OLD_Price(string p, string period, string chrg_VDC, string idc)
        {
            string found = "";
            if (idc != "")
            {
               
                if (idc == "125") idc = idc;
                string stSql = "SELECT [" + idc + "]  From ARCH_COST13 WHERE (((ARCH_COST13.phs)='" + p + "') AND (ARCH_COST13.ChargerVDC)='" + chrg_VDC + "') ORDER BY period DESC ";
                found = MainMDI.Find_One_Field(stSql);
            }
            else return "";
          return (found ==MainMDI.VIDE) ? "" : found   ;
        }

        private string find_OLD_PriceOLDOK(string p, string period, string chrg_VDC, string idc)
        {

            int ic = 0;
            string found = "";
            //   string stSql = "SELECT ARCH_COST13.* From ARCH_COST13 WHERE (((ARCH_COST13.phs)='" + p + "') AND ((ARCH_COST13.ChargerVDC)='" + chrg_VDC + "') AND ((ARCH_COST13.period)='" + period + "'))";
            //     string stSql = "SELECT ARCH_COST13.* From ARCH_COST13 WHERE (((ARCH_COST13.phs)='" + p + "') AND (ARCH_COST13.ChargerVDC)='" + chrg_VDC + "') ORDER BY period DESC ";
            string stSql = "SELECT [" + idc + "]  From ARCH_COST13 WHERE (((ARCH_COST13.phs)='" + p + "') AND (ARCH_COST13.ChargerVDC)='" + chrg_VDC + "') ORDER BY period DESC ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int XL_ARCH_Fldcount = MainMDI.Find_Flds_Count("select * from ARCH_COST13");
            while (Oreadr.Read())
            {
                for (ic = 1; ic < arr_BIG_Cols - 2; ic++)
                    if (arr_IDC[ic] == idc)
                    {
                        found = Oreadr[ic].ToString();
                        ic = XL_ARCH_Fldcount + 1;
                    }
            }

            return found;
        }


        private void do_Other_CHARGERS(string p, string Base_Charger, string vdc, string[] arr_Tot)
        {

            int pos = -1, ic = 0, pbadd = 0;
            string[] arr_TOT_others = new string[arr_BIG_Cols];
            string stout = "", stt = "", period = "", chrg_VDC = "";
            G_Base_CHRG = "P_" + Base_Charger;
         //   string stSql = "select * from COMPUTE_VCS where (VCS_TYPE='P') and (PHS='2' OR PHS='" + p + "') order by VCS_ID";
            string stSql = "select * from COMPUTE_VCS where (VCS_TYPE='P') and (PHS='2' OR PHS='" + p + "') order by rnk ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            //MainMDI.ExecSql("delete CHARGERS_COST0"+PHS );

            while (Oreadr.Read())
            {
                ic = 0;

                for (ic = 0; ic < arr_BIG_Cols; ic++) arr_TOT_others[ic] = "";

                
                switch (Oreadr["VCS_TYPE"].ToString())
                {
                    case "P":
                        for (ic = 1; ic < arr_BIG_Cols - 2; ic++)
                        {
                            if (arr_Tot[ic] != "c/f" && arr_Tot[ic] != "-1")
                            {
                                G_BASE_TOT = arr_Tot[ic];
                                arr_TOT_others[ic] = Deco_Frml_Price(p, Oreadr["Content"].ToString(), vdc, arr_IDC[ic - 1], Base_Charger);
                                if (arr_TOT_others[ic] != "" && arr_TOT_others[ic] != "")
                                    arr_TOT_others[ic] = MainMDI.A00(Convert.ToString(Math.Round(Tools.Conv_Dbl(arr_TOT_others[ic]), MainMDI.NB_DEC_AFF)));
                            }
                            else arr_TOT_others[ic] = "c/f";
                        }
                        break;
                    case "O":
                        for (ic = 1; ic <= arr_BIG_Cols - 2; ic++)
                        {
                            if (arr_Tot[ic] != "c/f" && arr_Tot[ic] != "-1")
                            {
                                if (Oreadr["Content"].ToString().Length > 1) period = Oreadr["Content"].ToString().Substring(2, 4);
                                else
                                {
                                    MessageBox.Show(" ERROR OLD Price Period (MMYY)");
                                    period = "9999";
                                }
                                //If IsNumeric(period)
                                pos = Oreadr["VCS_name"].ToString().IndexOf("-");
                                chrg_VDC = Oreadr["VCS_name"].ToString().Substring(3, pos - 3) + "-" + vdc;
                                arr_TOT_others[ic] = find_OLD_Price(p, period, chrg_VDC, arr_IDC[ic]);
                            }
                            else arr_TOT_others[ic] = "c/f";
                        }
                        break;
                    default:
                        MessageBox.Show("Error In Pricing Formulas............." + Oreadr["Content"].ToString());
                        break;
                    // 'arr_TOT_others(ic) = find_OLDCOST(p, Mid(adoSeek.Recordset!Content, 1, Len(adoSeek.Recordset!Content) - 2), vdc, rstTBLXL(ic).Name)
                }

                // ' stout = stout & vbCrLf & "vdc= " & vdc & "  IDC=" & rstTBLXL(ic).Name & " = " & arr_TOT_others(ic)

                stt = Oreadr["VCS_name"].ToString().Substring(2, Oreadr["VCS_name"].ToString().Length - 2);
                //#### this is old
                arr_TOT_others[0] = stt; arr_TOT_others[arr_BIG_Cols - 2] = "P4500-" + p + "-" + vdc; arr_TOT_others[arr_BIG_Cols - 1] = "T";
            //    arr_TOT_others[0] = stt; arr_TOT_others[arr_BIG_Cols - 2] = Base_Charger + "-" + vdc; arr_TOT_others[arr_BIG_Cols - 1] = "T";
        //        for (int c = 0; c < arr_BIG_Cols; c++) arr_BIGtoXL[Row_Big, c] = (c > 0 && c < (arr_BIG_Cols - 2)) ? MainMDI.A00(arr_TOT_others[c]) : arr_TOT_others[c];
              
                for (int c = 0; c < arr_BIG_Cols; c++)
                {
                    if (c > 0 && c < (arr_BIG_Cols - 2))
                    {
                        if (arr_TOT_others[c] == "-1" || arr_TOT_others[c] == "c/f") arr_BIGtoXL[Row_Big, c] = "c/f";
                        else arr_BIGtoXL[Row_Big, c] = (Tools.Conv_Dbl(arr_TOT_others[c]) > 0) ? MainMDI.A00(arr_TOT_others[c]) : arr_TOT_others[c];
                    }
                    else arr_BIGtoXL[Row_Big, c] = arr_TOT_others[c];
                }
        
                Row_Big++;
              

                //   writeTBXL(stt, arr_TOT_others, "*", p, ch, vdc, ref arr_TOT_others, "T");
            }

        }


        private void do_Other_CHARGERSbaaaaadd(string p, string Base_Charger, string vdc, string[] arr_Tot)
        {

            int pos = -1, ic = 0, pbadd = 0;
            string[] arr_TOT_others = new string[arr_BIG_Cols];
            string stout = "", stt = "", period = "", chrg_VDC = "";
            G_Base_CHRG = "P_" + Base_Charger;
            string stSql = "select * from COMPUTE_VCS where (VCS_TYPE='P') and (PHS='2' OR PHS='" + p + "') order by VCS_ID";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            //MainMDI.ExecSql("delete CHARGERS_COST0"+PHS );

            while (Oreadr.Read())
            {
                ic = 0;

                for (ic = 0; ic < arr_BIG_Cols; ic++) arr_TOT_others[ic] = "";


                for (ic = 1; ic <= arr_BIG_Cols - 2; ic++)
                {
                    G_BASE_TOT = arr_Tot[ic];
                    switch (Oreadr["VCS_TYPE"].ToString())
                    {
                        case "P":
                            arr_TOT_others[ic] = Deco_Frml_Price(p, Oreadr["Content"].ToString(), vdc, arr_IDC[ic - 1], Base_Charger);
                            break;
                        case "O":
                            if (Oreadr["Content"].ToString().Length > 1)
                                period = Oreadr["Content"].ToString().Substring(2, 4);

                            else
                            {
                                MessageBox.Show(" ERROR OLD Price Period (MMYY)");
                                period = "9999";
                            }
                            //If IsNumeric(period)
                            pos = Oreadr["VCS_name"].ToString().IndexOf("-");
                            chrg_VDC = Oreadr["VCS_name"].ToString().Substring(3, pos - 3) + "-" + vdc;
                            arr_TOT_others[ic] = find_OLD_Price(p, period, chrg_VDC, arr_IDC[ic]);
                            break;
                        default:
                            MessageBox.Show("Error In Pricing Formulas............." + Oreadr["Content"].ToString());
                            break;
                        // 'arr_TOT_others(ic) = find_OLDCOST(p, Mid(adoSeek.Recordset!Content, 1, Len(adoSeek.Recordset!Content) - 2), vdc, rstTBLXL(ic).Name)
                    }
                    if (arr_TOT_others[ic] != "" && arr_TOT_others[ic] != "")
                        arr_TOT_others[ic] = Convert.ToString(Math.Round(Tools.Conv_Dbl(arr_TOT_others[ic]), MainMDI.NB_DEC_AFF));
                    // ' stout = stout & vbCrLf & "vdc= " & vdc & "  IDC=" & rstTBLXL(ic).Name & " = " & arr_TOT_others(ic)
                }

                stt = Oreadr["VCS_name"].ToString().Substring(2, Oreadr["VCS_name"].ToString().Length - 2);
                arr_TOT_others[0] = stt; arr_TOT_others[arr_BIG_Cols - 2] = "P4500-" + p + "-" + vdc; arr_TOT_others[arr_BIG_Cols - 1] = "T";
                for (int c = 0; c < arr_BIG_Cols; c++) arr_BIGtoXL[Row_Big, c] = arr_TOT_others[c];
                Row_Big++;

                //   writeTBXL(stt, arr_TOT_others, "*", p, ch, vdc, ref arr_TOT_others, "T");
            }

        }

        private void tlsss_Click(object sender, EventArgs e)
        {
            bool sta = grpSim.Visible;

            grpSim.Visible = !sta;
            grp_period.Visible = sta; 
            grpITM.Height = 153;
            btn_1phs.Enabled = sta;
          //  grpITM.Height = 63;
        }

        private void pHASEToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btn_1phs_Click(object sender, EventArgs e)
        {
            //    ed_LVBIG.Items.Clear();
            //     linProc.Visible = true;
            //     tCount.Visible = true;
            //     linProc.Text = "Chargers in Process (1 PHS)";
            //     disp_1_3_Phase("1");
            if (MainMDI.Confirm("You Want to recalculate Chargers?"))
            {
                grpSim.Visible = false;
                grp_period.Visible = false;
                grpwait.Visible = true;
                TSmain.Enabled = false;
                grpLVtools.Enabled = false;
                btnPHS.Enabled = false;

                endProc = false;
                ccount = 1;


                Tcompute = new Thread(new ThreadStart(Compute_13));
                Tcompute.Start();
                while (!endProc)
                {
                    tCount.Text = ccount.ToString();
                    tCount.Refresh();
                    linProc.Text = "In Process (" + G_PHS + "-PHS chargers)";
                    //    this.Refresh();
                    Application.DoEvents();

                }


                grpwait.Visible = false;
                TSmain.Enabled = true;
                grpLVtools.Enabled = true;
                btnPHS.Enabled = true;


                Application.DoEvents();
         

            }
            G_PHS = "1";
            //      Thread Twait = new Thread(new  ThreadStart(wait_msg)); //      Twait.Start();



            Mechanical13();
            MessageBox.Show(msgOK + phss);
        }
      

        private void display_PricingList(string[,] _arrBig )
        {
            if (_arrBig[0, 0] != "~")
            {
                switch (lopt.Text)
                {
                    case "D":
                        arr_Mode_Details(_arrBig);
                        add_lvBIG(arr_BIGtoXL);
                        break;
                    case "S":
                        arr_Mode_Summary(_arrBig);
                        add_lvBIG(arr_BIGtoXL_SUM);
                        break;
                    case "C":
                        arr_Mode_ChargerOnly(_arrBig);
                        add_lvBIG(arr_BIGtoXL_Chargers);
                        break;
                }
            }
            else MessageBox.Show ("Sorry , No pricing is available....(Press Button [Calculate Pricing ( 1 & 3 PHASE)] and Retry)"); 
   



        }
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
        //    ed_LVBIG.Items.Clear();
       //     linProc.Visible = true;
        //    tCount.Visible = true;
        //    linProc.Text = "Chargers in Process (3 PHS)";
        //    disp_1_3_Phase("3");
                   //    fill_arrBIG_XX(btnPHS.Text, ref arr_BIG_03);

            if (G_PHS  == "1") display_PricingList(arr_BIG_01);
            else display_PricingList(arr_BIG_03);
     
        }

        private void txPrd_TextChanged(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void optDetail_CheckedChanged(object sender, EventArgs e)
        {
            lopt.Text = "D";
        }

        private void optSum_CheckedChanged(object sender, EventArgs e)
        {
            lopt.Text = "S";
        }

        private void optCharger_CheckedChanged(object sender, EventArgs e)
        {
            lopt.Text = "C";
        }

        private void timer1_Tickuuuu(object sender, EventArgs e)
        {
  
                if (!endProc)
                {
                    tCount.Text = ccount.ToString();
                    tCount.Refresh();
                    this.Refresh();
                }
 
           
        
        }

        private void btnimport_cpt_Click(object sender, EventArgs e)
        {
            
            //import_NewPrices_CPTxx("import_T1");
            import_OldFuses();
        }

        private void cbCpts_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void tabls_Click(object sender, EventArgs e)
        {
            char opera = (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "hnasrat") ? 'W' : 'R';
            Setng_005 set_PGC_Tables = new Setng_005(opera);
            set_PGC_Tables.Show();
        }

        private void cpts_Click(object sender, EventArgs e)
        {
            Admin_Cpts();
        }
        private void Admin_Cpts()
        {
            Options_Admin child3 = new Options_Admin('M', "*"); child3.Show();
          //  this.Hide();
     
           // this.Visible = true;
        }

        private void picradar_DoubleClick(object sender, EventArgs e)
        {
            if (MainMDI.Confirm("Want to stop ?"))
            {
                Tcompute.Abort();
                grpwait.Visible = false;
                TSmain.Enabled = true;
                grpLVtools.Enabled = true;
                btnPHS.Enabled = true;
                Application.DoEvents();
            }

        }

        private void picradar_Click(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Mechanical13();
        }

        private void do_Mecanical13()
        {
            this.Cursor = Cursors.WaitCursor; 
            grpwait.Visible = true;
            linProc.Text = " Mecanical in Process...."; 
            this.Refresh();
            Mechanical13();
            grpwait.Visible = false;
            this.Cursor = Cursors.Default;
            linProc.Text = "In Process"; 
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            do_Mecanical13();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            FRMLS_SelectedPHS();
        }

        private void FRMLS_SelectedPHS()
        {
            //  timer1.Enabled = true;
            //  string msgOK = "Prices Calculated succesfully for:  ",phss="";
            bool p1 = false, p3 = false;
            if (btnPHS.Text == "1") init_arr_Big(ref arr_BIG_01);
            if (btnPHS.Text == "3") init_arr_Big(ref arr_BIG_03);

            int p = Int32.Parse(btnPHS.Text);
            // btnPHS.Text = p.ToString();
            G_PHS = p.ToString();
            chng_PHS();
            init_arr_Big(ref arr_BIGtoXL); //init_arr_Big(arr_BIG_03); init_arr_Big(arr_BIG_01);
            init_arr_idcTOT();
            HT_CPT.Clear();
            AllChargers_AllPhase(p.ToString(), cbFrom.SelectedIndex, cbTO.SelectedIndex + 1);
            Create_TBLTOXL_13(p.ToString());
            if (p == 1) p1 = true;
            if (p == 3) p3 = true;

            if (p1) { fill_arrBIG_XX("1", ref arr_BIG_01); phss += " [1 Phase] "; }
            if (p3) { fill_arrBIG_XX("3", ref arr_BIG_03); phss += ",  [3 Phase] "; }
            endProc = true;
            if (phss.Length == 0) msgOK = "Sorry Calculations Failed....";
            //  MessageBox.Show(msgOK + phss);

        }



        private void FRML_ALLCPT(string _phs, string _Vdc, string _Idc, string Avail_id)
        {
            double Idc_TOT = 0;
            string stSql1 = "SELECT TBLAVAIL" + _phs + ".Avail_ID, COMPNT_LIST.Component_ID,COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + _phs + ".charger, TBLAVAIL" + _phs + ".vdc, TBLAVAIL" + _phs + ".idc, link_COMPNT_AVAIL.Qty, COMPNT_LIST.CAT1_TABLE_ID, COMPNT_LIST.CAT2_TABLE_ID, COMPNT_LIST.CAT3_TABLE_ID, COMPNT_LIST.Compnt_Type, COMPNT_LIST.Value_Type, COMPNT_LIST.nbc3Cat " +
                         " FROM (TBLAVAIL" + _phs + " INNER JOIN link_COMPNT_AVAIL ON TBLAVAIL" + _phs + ".Avail_ID = link_COMPNT_AVAIL.Avail_ID) INNER JOIN COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = COMPNT_LIST.Component_ID " +
                         " Where (((link_COMPNT_AVAIL.phs) = '" + _phs + "') and ((link_COMPNT_AVAIL.Avail_ID) = " + Avail_id + ")) ORDER BY TBLAVAIL" + _phs + ".Avail_ID, COMPNT_LIST.Component_ID";

            string _Pxx = "P4500", _Vac = "", _VdcMax = "", _lcptID = "", Curr_CPTNM = "", PXX_P_VDC = "P4500-" + _phs + "-" + _Vdc, CatNM1 = MainMDI.VIDE, CatNM2 = MainMDI.VIDE, CatNM3 = MainMDI.VIDE;
            Component Cpt = null;
            Charger CHRGR = null;

            CHRGR = new Charger(0, "F", _Pxx, _phs, _Vdc, _Idc, _Vac, _VdcMax);

            int ndx_IDC = Int32.Parse(HT_IDC[_Idc].ToString());
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql1;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int Curr_LN = Row_Big;
            string stSql2 = "";


            string[] arr_VV = new string[12];
            while (Oreadr.Read())
            {

                string Row_type = "C";
                Cpt = new Component();
                _lcptID = Oreadr["Component_ID"].ToString();
                Curr_CPTNM = Oreadr["COMPONENT_REF"].ToString();
                string tt = Cpt.Cal_chrg_CostADO(Convert.ToInt32(_lcptID), "C");

                if (Oreadr["Compnt_Type"].ToString() != "%" && Oreadr["COMPONENT_REF"].ToString() != MainMDI.VIDE)
                {
                    CatNM1 = HT_CPT_cat[Curr_CPTNM + "_CAT1"].ToString();
                    CatNM2 = HT_CPT_cat[Curr_CPTNM + "_CAT2"].ToString();
                    CatNM3 = HT_CPT_cat[Curr_CPTNM + "_CAT3"].ToString();

                    //added on 30/04/2009
                    if (IDC_Disabled(_phs, _Idc)) Cpt.G_PRICE = MainMDI.VIDE;
                    //added on 30/04/2009

                    ToBIGXL(ndx_IDC, Curr_CPTNM, Cpt.G_PRICE, PXX_P_VDC, Row_type, CatNM1, Cpt.CAP1, CatNM2, Cpt.CAP2, CatNM3, Cpt.CAP3);

                    if (Cpt.G_PRICE != MainMDI.VIDE && Idc_TOT != -1) Idc_TOT += Tools.Conv_Dbl(Cpt.G_PRICE);
                    else Idc_TOT = -1;

                }
                else if (Oreadr["nbc3Cat"].ToString() == "B") arr_IdcPRCT[ndx_IDC] = Oreadr["Value_Type"].ToString();


                arr_VV[0] = Oreadr["Avail_ID"].ToString();
                arr_VV[1] = _lcptID;
                arr_VV[2] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.CAP1;
                arr_VV[3] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.CAP2;
                arr_VV[4] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.CAP3;
                arr_VV[5] = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt.Real_QTY;
                arr_VV[6] = (Oreadr["Compnt_Type"].ToString() == "%") ? Oreadr["Value_Type"].ToString() : Tools.Conv_Dbl(Cpt.G_PRICE).ToString(); //MainMDI.A00(Tools.Conv_Dbl(Cpt.G_PRICE).ToString());
                arr_VV[7] = Oreadr["Compnt_Type"].ToString();
                stSql2 = "INSERT INTO CHARGERS_COST0" + _phs + " ([Avail_ID],[Compnt_ID],[Cap1],[Cap2],[Cap3],[Real_QTY],[COST],[cost_type]) VALUES (" +
                    arr_VV[0] + " , " +
                    arr_VV[1] + " , '" +
                    arr_VV[2] + "' , '" +
                    arr_VV[3] + "' , '" +
                    arr_VV[4] + "' , '" +
                    arr_VV[5] + "' , '" +
                    arr_VV[6] + "' , '" +
                    arr_VV[7] + "')";
                MainMDI.ExecSql(stSql2);
            }
            arr_IdcTOT[ndx_IDC] = Idc_TOT.ToString();

        }
















        }
}