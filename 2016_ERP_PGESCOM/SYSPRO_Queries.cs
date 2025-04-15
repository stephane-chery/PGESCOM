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
using EAHLibs;

namespace PGESCOM
{
    public partial class SYSPRO_Queries : Form
    {

        private Lib1 Tools = new Lib1();
        const int MAXarr =1200;
        const int NBCols = 15;
        string[,] arr_PASS = new string[MAXarr, NBCols];
        private int seelCol = 0;
        private ListViewColumnSorter lvSorter = null;

       Color zero_clr = Color.Orange, PL_clr = Color.PaleTurquoise, bom_clr = Color.PaleGreen;

        public SYSPRO_Queries()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (Tools.Conv_Dbl( tNBcartes.Text) >0)
            {
                this.Cursor = Cursors.WaitCursor;
                //  init_arrPASS();
                Read_PAS();
                MoveARR_MDL();

                this.Cursor = Cursors.Default;
            }
        }

        void Copy_CTRLC(string ST_Clip)
        {
            Clipboard.SetText(ST_Clip, TextDataFormat.Text);
        }

        void MoveARR_MDL()
        {
            ed_lvITM.BeginUpdate();
            double PLTOT = 0, BMCTOT = 0;
            ed_lvITM.Items.Clear();
            double dd=0;
            for (int i = 0; i < MAXarr; i++)
            {

                if (arr_PASS[i, 0] == "") i = MAXarr;
                else
                {
                    Color myCLR = Color.NavajoWhite, myforCLR = Color.Black;

                    bool Listprice = false, BOM = false;
                    ListViewItem lv = ed_lvITM.Items.Add(arr_PASS[i, 0]);
                    for (int j = 1; j < NBCols; j++)
                    {
                        string st = arr_PASS[i, j];
                        switch (j)
                        {
                            case 8:
                                st = (Tools.Conv_Dbl(st) * Tools.Conv_Dbl(tNBcartes.Text)).ToString();
                                break;
                            case 10:
                                dd = Tools.Conv_Dbl(arr_PASS[i, 8]) * Tools.Conv_Dbl(tNBcartes.Text) * Tools.Conv_Dbl(arr_PASS[i, 9]);
                                st = dd.ToString();
                                PLTOT += dd;
                                Listprice = (dd == 0);
                                break;
                            case 12:
                                dd = Tools.Conv_Dbl(arr_PASS[i, 8]) * Tools.Conv_Dbl(tNBcartes.Text) * Tools.Conv_Dbl(arr_PASS[i, 11]);
                                st = dd.ToString();
                                BMCTOT += dd;
                                BOM = (dd == 0);
                                break;
                            case 14:
                                st = arr_PASS[i,14];
       
                                break;
                        }
                        lv.SubItems.Add(st);
                      

                        if (Listprice && BOM) lv.BackColor = zero_clr;
                     
                        switch (st)
                        {
                            case "F":
                                Color oldclr = lv.BackColor;
                                lv.UseItemStyleForSubItems = false;
                                lv.SubItems[3].BackColor= Color.Red;
                                lv.SubItems[3].ForeColor = Color.White;
                                for (int c = 4; c < lv.SubItems.Count; c++) lv.SubItems[c].BackColor = oldclr;


                                break;
                            case "P":
                   
                                lv.SubItems[3].BackColor = Color.Yellow;
                                lv.SubItems[3].ForeColor = Color.Black;

                                 oldclr = lv.BackColor;
                                lv.UseItemStyleForSubItems = false;
                                lv.SubItems[3].BackColor = Color.Yellow;
                                lv.SubItems[3].ForeColor = Color.Black;
                                for (int c = 4; c < lv.SubItems.Count; c++) lv.SubItems[c].BackColor = oldclr;

                                break;


                        }

                      

                    }
                    
                    
                }
            }
            ed_lvITM.EndUpdate();
            txLPTOT.Text = PLTOT.ToString();
            txBMCTOT.Text = BMCTOT.ToString();
            color_edlvitms(9, 10, PL_clr );
            color_edlvitms(11, 12,bom_clr );
         
        }

        void color_edlvitms(int COL_ndx, int COL_ndx2, Color clr)
        {
            for (int i = 0; i < ed_lvITM.Items.Count; i++)
            {
                if (ed_lvITM.Items[i].BackColor != zero_clr)
                {
                    ed_lvITM.Items[i].UseItemStyleForSubItems = false;
                    for (int j = COL_ndx; j < COL_ndx2 + 1; j++)
                        ed_lvITM.Items[i].SubItems[j].BackColor = clr;
                }
               
 
            }

        }


        void init_arrPASS()
        {
            for (int i = 0; i < MAXarr; i++) for (int j = 0; j < NBCols; j++) arr_PASS[i, j] = ""; 
        }


        //key=Component + Narration
        void Process_PAS(string ParentSTKODE, string in_QTY)
        {

            //    string stSql = " SELECT * FROM v_ComponentListing where ParentPart='" + ParentSTKODE + "' order by Component ";

            //          string stSql = " SELECT v_ComponentListing.* ,   InvMaster.MaterialCost AS BOM_MaterialCost, InvPrice.SellingPrice " +
            //                       " FROM v_ComponentListing INNER JOIN InvMaster ON InvMaster.StockCode = v_ComponentListing.Component INNER JOIN " +
            //                       "      InvPrice ON InvMaster.StockCode = InvPrice.StockCode AND InvMaster.ListPriceCode = InvPrice.PriceCode AND InvMaster.StockCode = InvPrice.StockCode " +
            //                       " WHERE     (v_ComponentListing.ParentPart = '" + ParentSTKODE + "') ORDER BY v_ComponentListing.Component ";
            string stSql = " SELECT    [Line]   ,[ParentPart],[SequenceNum] ,[Component]  ,[Narration] ,[ManuPartNumber]  ,v_ComponentListing.[Description] ,[AppManufacturer],[QtyPer], " +
                         "           InvMaster.MaterialCost AS BOM_MaterialCost, InvPrice.SellingPrice, InvMaster.StockOnHold " +
                      " FROM v_ComponentListing INNER JOIN InvMaster ON InvMaster.StockCode = v_ComponentListing.Component INNER JOIN " +
                      "      InvPrice ON InvMaster.StockCode = InvPrice.StockCode AND InvMaster.ListPriceCode = InvPrice.PriceCode AND InvMaster.StockCode = InvPrice.StockCode " +
                      " WHERE     (v_ComponentListing.ParentPart = '" + ParentSTKODE + "') ORDER BY v_ComponentListing.Component, v_ComponentListing.Narration  ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {

                string cmnt = "", stt ="";
                int ip=Oreadr[4].ToString().IndexOf("//");
                if (ip>-1) stt = Oreadr[4].ToString().Replace("//", "");
                      else stt = Oreadr[4].ToString().Replace(" ", "");
                // Sent_arr(Oreadr["Line"].ToString(), Oreadr["ParentPart"].ToString(), Oreadr["SequenceNum"].ToString(), Oreadr["Component"].ToString(), Oreadr["QtyPer"].ToString(), Oreadr["Narration"].ToString(), Oreadr["ManuPartNumber"].ToString(), Oreadr["Description"].ToString(), Oreadr["AppManufacturer"].ToString());
                for (int i = 0; i < MAXarr; i++)
                {


                    if (arr_PASS[i, 0] == "")
                    {
                        for (int r = 0; r < NBCols; r++)
                        {
                            switch (r)
                            {
                                case 4:
                                    arr_PASS[i, 4] = stt;
                                    break;
                                case 13:
                                    arr_PASS[i, 13] = Oreadr[1].ToString().TrimEnd(' ');
                                    break;
                                case 12:
                                    arr_PASS[i, 12] = "0";
                                    break;
                                case 11:
                                    arr_PASS[i, 14] = Oreadr[r].ToString(); arr_PASS[i, 10] = "0";
                                    break;
                                case 8:
                                    arr_PASS[i, 8] = MainMDI.A00((Tools.Conv_Dbl(Oreadr[r].ToString()) * Tools.Conv_Dbl(in_QTY)).ToString());
                                    //MainMDI.A00( (Tools.Conv_Dbl(Oreadr[r].ToString()) * Tools.Conv_Dbl(in_QTY)).ToString()    );
                                    break;
                                case 10:
                                    arr_PASS[i, 11] = MainMDI.A00(Tools.Conv_Dbl(Oreadr[r].ToString()).ToString());
                                    break;
                                default:
                                    if (r < 11) arr_PASS[i, r] = Oreadr[r].ToString().TrimEnd(' ');// (Oreadr[r].ToString().Length >4 ) ? Oreadr[r].ToString().TrimEnd(' '): Oreadr[r].ToString();
                                    break;
                            }

                        }
                        i = MAXarr;

                    }
                    else
                    {
                        //  if (arr_PASS[i, 3] == Oreadr[3].ToString().TrimEnd() && arr_PASS[i, 5] == Oreadr[5].ToString().TrimEnd())
                        if (arr_PASS[i, 3] == Oreadr[3].ToString().TrimEnd() && arr_PASS[i, 4] == Oreadr[4].ToString().TrimEnd())
                        {
                            arr_PASS[i, 8] = (Tools.Conv_Dbl(Oreadr[8].ToString()) * Tools.Conv_Dbl(in_QTY) + Tools.Conv_Dbl(arr_PASS[i, 8])).ToString();
                            //(Tools.Conv_Dbl(Oreadr[8].ToString()) + Tools.Conv_Dbl(arr_PASS[i, 8])).ToString();
                            arr_PASS[i, 7] = arr_PASS[i, 7] + " / " + Oreadr[7].ToString().TrimEnd(' ');
                            arr_PASS[i, 13] = arr_PASS[i, 13] + " / " + Oreadr[1].ToString().TrimEnd(' ');
                            //       arr_PASS[i, 4] = MainMDI.A00(Tools.Conv_Dbl(arr_PASS[i, 4]).ToString());
                            i = MAXarr;
                        }
                    }
                    // if ( arr_PASS [i,4]!="") arr_PASS[i, 4] = MainMDI.A00(arr_PASS[i, 4]);
                }

            }
            OConn.Close();
        }


        void Process_PAS_OKK(string ParentSTKODE, string in_QTY)
        {

            //    string stSql = " SELECT * FROM v_ComponentListing where ParentPart='" + ParentSTKODE + "' order by Component ";

            //          string stSql = " SELECT v_ComponentListing.* ,   InvMaster.MaterialCost AS BOM_MaterialCost, InvPrice.SellingPrice " +
            //                       " FROM v_ComponentListing INNER JOIN InvMaster ON InvMaster.StockCode = v_ComponentListing.Component INNER JOIN " +
            //                       "      InvPrice ON InvMaster.StockCode = InvPrice.StockCode AND InvMaster.ListPriceCode = InvPrice.PriceCode AND InvMaster.StockCode = InvPrice.StockCode " +
            //                       " WHERE     (v_ComponentListing.ParentPart = '" + ParentSTKODE + "') ORDER BY v_ComponentListing.Component ";
            string stSql = " SELECT    [Line]   ,[ParentPart],[SequenceNum] ,[Component]  ,[Narration] ,[ManuPartNumber]  ,v_ComponentListing.[Description] ,[AppManufacturer],[QtyPer], " +
                         "           InvMaster.MaterialCost AS BOM_MaterialCost, InvPrice.SellingPrice " +
                      " FROM v_ComponentListing INNER JOIN InvMaster ON InvMaster.StockCode = v_ComponentListing.Component INNER JOIN " +
                      "      InvPrice ON InvMaster.StockCode = InvPrice.StockCode AND InvMaster.ListPriceCode = InvPrice.PriceCode AND InvMaster.StockCode = InvPrice.StockCode " +
                      " WHERE     (v_ComponentListing.ParentPart = '" + ParentSTKODE + "') ORDER BY v_ComponentListing.Component, v_ComponentListing.Narration  ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {

                string stt = Oreadr[4].ToString().Replace(" ", "");
                // Sent_arr(Oreadr["Line"].ToString(), Oreadr["ParentPart"].ToString(), Oreadr["SequenceNum"].ToString(), Oreadr["Component"].ToString(), Oreadr["QtyPer"].ToString(), Oreadr["Narration"].ToString(), Oreadr["ManuPartNumber"].ToString(), Oreadr["Description"].ToString(), Oreadr["AppManufacturer"].ToString());
                for (int i = 0; i < MAXarr; i++)
                {


                    if (arr_PASS[i, 0] == "")
                    {
                        for (int r = 0; r < NBCols; r++)
                        {
                            switch (r)
                            {
                                case 4:
                                    arr_PASS[i, 4] = stt;
                                    break;
                                case 13:
                                    arr_PASS[i, 13] = Oreadr[1].ToString().TrimEnd(' ');
                                    break;
                                case 12:
                                    arr_PASS[i, 12] = "0";
                                    break;
                                case 11:
                                    arr_PASS[i, 10] = "0";
                                    break;
                                case 8:
                                    arr_PASS[i, 8] = MainMDI.A00((Tools.Conv_Dbl(Oreadr[r].ToString()) * Tools.Conv_Dbl(in_QTY)).ToString());
                                    //MainMDI.A00( (Tools.Conv_Dbl(Oreadr[r].ToString()) * Tools.Conv_Dbl(in_QTY)).ToString()    );
                                    break;
                                case 10:
                                    arr_PASS[i, 11] = MainMDI.A00(Tools.Conv_Dbl(Oreadr[r].ToString()).ToString());
                                    break;
                                default:
                                    arr_PASS[i, r] = Oreadr[r].ToString().TrimEnd(' ');
                                    break;
                            }

                        }
                        i = MAXarr;

                    }
                    else
                    {
                        //  if (arr_PASS[i, 3] == Oreadr[3].ToString().TrimEnd() && arr_PASS[i, 5] == Oreadr[5].ToString().TrimEnd())
                        if (arr_PASS[i, 3] == Oreadr[3].ToString().TrimEnd() && arr_PASS[i, 4] == Oreadr[4].ToString().TrimEnd())
                        {
                            arr_PASS[i, 8] = (Tools.Conv_Dbl(Oreadr[8].ToString()) * Tools.Conv_Dbl(in_QTY) + Tools.Conv_Dbl(arr_PASS[i, 8])).ToString();
                            //(Tools.Conv_Dbl(Oreadr[8].ToString()) + Tools.Conv_Dbl(arr_PASS[i, 8])).ToString();
                            arr_PASS[i, 7] = arr_PASS[i, 7] + " / " + Oreadr[7].ToString().TrimEnd(' ');
                            arr_PASS[i, 13] = arr_PASS[i, 13] + " / " + Oreadr[1].ToString().TrimEnd(' ');
                            //       arr_PASS[i, 4] = MainMDI.A00(Tools.Conv_Dbl(arr_PASS[i, 4]).ToString());
                            i = MAXarr;
                        }
                    }
                    // if ( arr_PASS [i,4]!="") arr_PASS[i, 4] = MainMDI.A00(arr_PASS[i, 4]);
                }

            }
            OConn.Close();
        }


        //key=Component 
        void Process_PASold_just_cop_code(string ParentSTKODE,string in_QTY)
        {

        //    string stSql = " SELECT * FROM v_ComponentListing where ParentPart='" + ParentSTKODE + "' order by Component ";

  //          string stSql = " SELECT v_ComponentListing.* ,   InvMaster.MaterialCost AS BOM_MaterialCost, InvPrice.SellingPrice " +
  //                       " FROM v_ComponentListing INNER JOIN InvMaster ON InvMaster.StockCode = v_ComponentListing.Component INNER JOIN " +
  //                       "      InvPrice ON InvMaster.StockCode = InvPrice.StockCode AND InvMaster.ListPriceCode = InvPrice.PriceCode AND InvMaster.StockCode = InvPrice.StockCode " +
  //                       " WHERE     (v_ComponentListing.ParentPart = '" + ParentSTKODE + "') ORDER BY v_ComponentListing.Component ";
            string stSql = " SELECT    [Line]   ,[ParentPart],[SequenceNum] ,[Component]  ,[Narration] ,[ManuPartNumber]  ,v_ComponentListing.[Description] ,[AppManufacturer],[QtyPer], " + 
                         "           InvMaster.MaterialCost AS BOM_MaterialCost, InvPrice.SellingPrice " +
                      " FROM v_ComponentListing INNER JOIN InvMaster ON InvMaster.StockCode = v_ComponentListing.Component INNER JOIN " +
                      "      InvPrice ON InvMaster.StockCode = InvPrice.StockCode AND InvMaster.ListPriceCode = InvPrice.PriceCode AND InvMaster.StockCode = InvPrice.StockCode " +
                      " WHERE     (v_ComponentListing.ParentPart = '" + ParentSTKODE + "') ORDER BY v_ComponentListing.Component ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
            while (Oreadr.Read())
            {

                string stt = Oreadr[4].ToString().Replace(" ", "");
               // Sent_arr(Oreadr["Line"].ToString(), Oreadr["ParentPart"].ToString(), Oreadr["SequenceNum"].ToString(), Oreadr["Component"].ToString(), Oreadr["QtyPer"].ToString(), Oreadr["Narration"].ToString(), Oreadr["ManuPartNumber"].ToString(), Oreadr["Description"].ToString(), Oreadr["AppManufacturer"].ToString());
                for (int i = 0; i < MAXarr ; i++)
                {
                   

                    if (arr_PASS[i, 0] == "")
                    {
                        for (int r = 0; r < NBCols; r++)
                        {
                            switch (r)
                            {
                                case 4:
                                    arr_PASS[i, 4] = stt;
                                    break;
                                case 13:
                                    arr_PASS[i, 13] = Oreadr[1].ToString().TrimEnd(' ');
                                    break;
                                case 12:
                                    arr_PASS[i, 12] ="0";
                                    break;
                                case 11:
                                    arr_PASS[i, 10] = "0";
                                    break;
                                case 8:
                                    arr_PASS[i, 8] = MainMDI.A00( (Tools.Conv_Dbl(Oreadr[r].ToString()) * Tools.Conv_Dbl(in_QTY)).ToString()    );
                                    //MainMDI.A00( (Tools.Conv_Dbl(Oreadr[r].ToString()) * Tools.Conv_Dbl(in_QTY)).ToString()    );
                                    break;
                                case 10:
                                    arr_PASS[i, 11] = MainMDI.A00(Tools.Conv_Dbl(Oreadr[r].ToString()).ToString());
                                    break;
                                default:
                                    arr_PASS[i, r] = Oreadr[r].ToString().TrimEnd(' ');
                                    break;
                            }

                                             }
                        i = MAXarr;

                    }
                    else
                    {
                      //  if (arr_PASS[i, 3] == Oreadr[3].ToString().TrimEnd() && arr_PASS[i, 5] == Oreadr[5].ToString().TrimEnd())
                        if (arr_PASS[i, 3] == Oreadr[3].ToString().TrimEnd() )
                        {
                            arr_PASS[i, 8] = (Tools.Conv_Dbl(Oreadr[8].ToString())  * Tools.Conv_Dbl(in_QTY) + Tools.Conv_Dbl(arr_PASS[i, 8])).ToString();
                                //(Tools.Conv_Dbl(Oreadr[8].ToString()) + Tools.Conv_Dbl(arr_PASS[i, 8])).ToString();
                            arr_PASS[i, 7] = arr_PASS[i, 7] + " / " + Oreadr[7].ToString().TrimEnd(' ');
                            arr_PASS[i, 13] = arr_PASS[i, 13] + " / " + Oreadr[1].ToString().TrimEnd(' ');
                            //       arr_PASS[i, 4] = MainMDI.A00(Tools.Conv_Dbl(arr_PASS[i, 4]).ToString());
                            i = MAXarr;
                        }
                    }
                   // if ( arr_PASS [i,4]!="") arr_PASS[i, 4] = MainMDI.A00(arr_PASS[i, 4]);
                }
  
            }
            OConn.Close();
        }

        void Sent_arr(string line, string ParentPart, string SequenceNum, string Component, string QtyPer, string Narration, string ManuPartNumber, string Description, string AppManufacturer)
        {

        }

        void Read_PAS()
        {
            init_arrPASS();
            int nbChk = 0;
            for (int i = 0; i < mdl_STK.Items.Count; i++)
            {
                if (mdl_STK.Items[i].Checked)
                {
                    Process_PAS(mdl_STK.Items[i].SubItems[1].Text, mdl_STK.Items[i].SubItems[3].Text);
                    nbChk++; 
                }
          
            }
            grpTOT.Visible = (nbChk == 1);  
        }



        void Fill_mdl_STK(string pas)
        {

            string pas_cond = (pas == "PAS") ? " substring(ParentPart,1,3) = 'PAS' " : " substring(ParentPart,1,3) <>'PAS' ";
            //string CondAdmin = (MainMDI.User.ToLower() == "shammou") ? " where USRadmin='" + MainMDI.User.ToLower() + "'" : " ";
            //     string stSql = (Abr != "VA") ? "SELECT EventLID, Event_Name,EvType  FROM [Orig_PSM_FDB].[dbo].[XCNG_Events] where EvType='" + Abr + "' order by Ev_Start" : " SELECT [Depcode] ,[DepName],'VA'  FROM [Orig_PSM_FDB].[dbo].[XCNG_Departements] ";
            // string stSql = " SELECT distinct [ParentPart] FROM v_ComponentListing where " +pas_cond + " order by [ParentPart]";
            string stSql = " SELECT DISTINCT v_ComponentListing.ParentPart, InvMaster.StockOnHold from   v_ComponentListing INNER JOIN  InvMaster ON v_ComponentListing.ParentPart = InvMaster.StockCode " +
                           "          WHERE " + pas_cond + " ORDER BY v_ComponentListing.ParentPart ";



            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            mdl_STK.Items.Clear();
            while (Oreadr.Read())
            {
                Color myCLR = Color.NavajoWhite, myforCLR = Color.Black;


                ListViewItem lv = mdl_STK.Items.Add(" ");
                lv.SubItems.Add(Oreadr["ParentPart"].ToString());
                lv.SubItems.Add(" ");
                lv.SubItems.Add("1");

                switch (Oreadr["StockOnHold"].ToString())
                {
                    case "F":
                        myCLR = Color.Red;
                        myforCLR = Color.White;
                        break;
                    case "P":
                        myCLR = Color.Yellow;
                        break;


                }

                lv.BackColor = myCLR;
                lv.ForeColor = myforCLR;

            }
            OConn.Close();

        }

       void  refresh_Assemblies(string pas)
        {

            mdl_STK.BackColor = (pas == "PAS") ? Color.NavajoWhite : Color.LightBlue;
            lvSorter = new ListViewColumnSorter();
            this.ed_lvITM.ListViewItemSorter = lvSorter;

            //       mdl_STK.Modifiable = false;
            ed_lvITM.Items.Clear();
            txLPTOT.Clear();
            txBMCTOT.Clear();
            tNBcartes.Text = "1";

            Fill_mdl_STK(pas);
        }

        private void SYSPRO_Queries_Load(object sender, EventArgs e)
        {
            //lvSorter = new ListViewColumnSorter();
            //this.ed_lvITM.ListViewItemSorter = lvSorter; 
            // Fill_mdl_STK();

            refresh_Assemblies("PAS");
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void ed_lvITM_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void tsb_Excel_Click(object sender, EventArgs e)
        {

            XL_Cpts_Listing();

        }

        private void XL_Cpts_Listing()
        {

            
            object[] objHdrs = new object[NBCols];//  { "Invoice #", "Sale / Agency Name", "Base Amount", "Commission %", "Commission Amount", "Currency", "Xchange rate ", "Commission Amount (CAD)", " cms Type " };

            for (int i = 0; i < NBCols; i++) objHdrs[i] =ed_lvITM.Columns[i].Text;//ed_lvITM.Columns[i+2].Text;


            string Fname = "SYSPRO_CPT_LIST.xlsx";
            string CellFM = "A1", CellTO = "N1";

            object[,] objData = new object[MainMDI.MAX_XLlines_XPRT, NBCols];
            for (int i = 0; i < MainMDI.MAX_XLlines_XPRT; i++)
            {
                if (i < ed_lvITM.Items.Count)
                {

                    for (int j = 0; j < NBCols; j++) objData[i, j] = ed_lvITM.Items[i].SubItems[j].Text;

                }

            }
            XL_EXPORT(Fname, objHdrs, NBCols, CellFM, CellTO, objData);

        }

        private void XL_EXPORT(string FName, object[] objHdrs, int HdrsNB, string CellFM, string CellTO, object[,] objData)
        {

            System.IO.File.Delete(MainMDI.XL_Path + @"\" + FName);// "CMS_CALC.xls");
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
            //  ??? NO  data
            //   MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\" + FName);

            MainMDI.EXEC_FILE("EXCEL.exe", MainMDI.XL_Path + @"\" + FName);
        }

        private void tsb_INVOICE_Click(object sender, EventArgs e)
        {
            //ed_lvITM.Items.Clear();

            //Sort_ARrString_MD();
            //MoveARR_MDL();
            refresh_Assemblies("PAS");

        }

        void Sort_ARrString_MD()
        {
            string[] arrNDX = new string[MAXarr ];

            string[,] arr_PASSTMP = new  string [MAXarr ,NBCols];

            for (int x=0;x<MAXarr ;x++) 
            {
                arrNDX[x] = arr_PASS[x, 0]; 
                for (int y=0;y<NBCols;y++)   arr_PASSTMP [x,y]=arr_PASS [x,y];
            }

            Array.Sort(arrNDX ,StringComparer.InvariantCulture);

            for (int i = 0; i < MAXarr; i++)
            {
                if (arrNDX[i] != "")
                {
                    for (int x = 0; x < MAXarr; x++)
                    {
                        if (arrNDX[i] == arr_PASSTMP[x, 0])
                        {
                            for (int y = 0; y < NBCols; y++) arr_PASS[x, y] = arr_PASSTMP[x, y];
                            for (int y = 0; y < NBCols; y++) arr_PASSTMP[x, y] = "";

                            x = MAXarr;
                        }

                    }
                }
            }
        }

        public void  SortArray(int[,] array)
        {
/*
            string temp = arr_PASS[0,0];

            for (int i = 0; i <MAXarr ; i++)
            {
                for (int j = i + 1; j < MAXarr ; j++)
                {
                    if (arr_PASS[i,0]  > arr_PASS[j,0])
                    {
                        temp = arr_PASS[i, 0]; array[i];

                        array[i] = array[j];

                        array[j] = temp;
                    }
                }
            }

            return array;
*/
        }

        /////////Sorting    ed_lvITM 

        void sort_CPts_list()
        {
            lvSorter.SortColumn = 0;
            lvSorter.Order = System.Windows.Forms.SortOrder.Descending; //first err
            seelCol = 0;
        //    myListView.Sort();
        }

        private void ed_lvITM_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //MessageBox.Show (   e.Column.ToString()  );


            seelCol = e.Column;

            ListView myListView = (ListView)sender;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                //lvSorter.SortColumn = e.Column; old
                //	lvSorter.Order = System.Windows.Forms.SortOrder.Ascending; old

                lvSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                lvSorter.SortColumn = e.Column;
             
            }

            // Perform the sort with these new sort options.
            myListView.Sort();
            lvSorter.SortColumn = 0;
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SYSPRO_Queries));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tlstrip = new System.Windows.Forms.ToolStrip();
            this.tsb_INVOICE = new System.Windows.Forms.ToolStripButton();
            this.tsb_COMMI = new System.Windows.Forms.ToolStripButton();
            this.tsb_Excel = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.exitt = new System.Windows.Forms.ToolStripButton();
            this.tsb_InvList = new System.Windows.Forms.ToolStripButton();
            this.tsb_saleAcct = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mdl_STK = new PGESCOM.Modified_EditListView();
            this.sel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.@__stkd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.lFName = new System.Windows.Forms.Label();
            this.tNBcartes = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ed_lvITM = new PGESCOM.ed_LVmodif();
            this.line = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ParentPart = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SequenceNum = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Component = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Narration = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ManuPartNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AppManufacturer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QtyPer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PriceList = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalPL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BomPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TotalBom = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.WRused = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnc_CCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stk = new System.Windows.Forms.ToolStripMenuItem();
            this.nara = new System.Windows.Forms.ToolStripMenuItem();
            this.partnb = new System.Windows.Forms.ToolStripMenuItem();
            this.desc = new System.Windows.Forms.ToolStripMenuItem();
            this.PL = new System.Windows.Forms.ToolStripMenuItem();
            this.Bom = new System.Windows.Forms.ToolStripMenuItem();
            this.grpTOT = new System.Windows.Forms.GroupBox();
            this.btnfind = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tKey = new System.Windows.Forms.TextBox();
            this.txBMCTOT = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txLPTOT = new System.Windows.Forms.TextBox();
            this.hold = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.tlstrip.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.mnc_CCopy.SuspendLayout();
            this.grpTOT.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.tlstrip);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1447, 78);
            this.groupBox1.TabIndex = 505;
            this.groupBox1.TabStop = false;
            // 
            // tlstrip
            // 
            this.tlstrip.AutoSize = false;
            this.tlstrip.BackColor = System.Drawing.Color.PaleGreen;
            this.tlstrip.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.tlstrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsb_INVOICE,
            this.tsb_COMMI,
            this.tsb_Excel,
            this.toolStripButton1,
            this.exitt,
            this.tsb_InvList,
            this.tsb_saleAcct});
            this.tlstrip.Location = new System.Drawing.Point(3, 16);
            this.tlstrip.Name = "tlstrip";
            this.tlstrip.Size = new System.Drawing.Size(1441, 55);
            this.tlstrip.Stretch = true;
            this.tlstrip.TabIndex = 501;
            // 
            // tsb_INVOICE
            // 
            this.tsb_INVOICE.Image = ((System.Drawing.Image)(resources.GetObject("tsb_INVOICE.Image")));
            this.tsb_INVOICE.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_INVOICE.Name = "tsb_INVOICE";
            this.tsb_INVOICE.Size = new System.Drawing.Size(97, 52);
            this.tsb_INVOICE.Text = "New Assemblies";
            this.tsb_INVOICE.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_INVOICE.Click += new System.EventHandler(this.tsb_INVOICE_Click);
            // 
            // tsb_COMMI
            // 
            this.tsb_COMMI.Image = ((System.Drawing.Image)(resources.GetObject("tsb_COMMI.Image")));
            this.tsb_COMMI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_COMMI.Name = "tsb_COMMI";
            this.tsb_COMMI.Size = new System.Drawing.Size(92, 52);
            this.tsb_COMMI.Text = "Old Assemblies";
            this.tsb_COMMI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_COMMI.Click += new System.EventHandler(this.tsb_COMMI_Click);
            // 
            // tsb_Excel
            // 
            this.tsb_Excel.Image = ((System.Drawing.Image)(resources.GetObject("tsb_Excel.Image")));
            this.tsb_Excel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_Excel.Name = "tsb_Excel";
            this.tsb_Excel.Size = new System.Drawing.Size(73, 52);
            this.tsb_Excel.Text = "Excel Export";
            this.tsb_Excel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_Excel.ToolTipText = "Excel export";
            this.tsb_Excel.Click += new System.EventHandler(this.tsb_Excel_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(85, 52);
            this.toolStripButton1.Text = "Modify Values";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Visible = false;
            // 
            // exitt
            // 
            this.exitt.Image = ((System.Drawing.Image)(resources.GetObject("exitt.Image")));
            this.exitt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitt.Name = "exitt";
            this.exitt.Size = new System.Drawing.Size(47, 52);
            this.exitt.Text = "   Exit   ";
            this.exitt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exitt.ToolTipText = "Exit";
            this.exitt.Click += new System.EventHandler(this.exitt_Click);
            // 
            // tsb_InvList
            // 
            this.tsb_InvList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_InvList.Name = "tsb_InvList";
            this.tsb_InvList.Size = new System.Drawing.Size(71, 52);
            this.tsb_InvList.Text = "Inside Sales";
            this.tsb_InvList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_InvList.Visible = false;
            // 
            // tsb_saleAcct
            // 
            this.tsb_saleAcct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsb_saleAcct.Name = "tsb_saleAcct";
            this.tsb_saleAcct.Size = new System.Drawing.Size(61, 52);
            this.tsb_saleAcct.Text = "Accounts";
            this.tsb_saleAcct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsb_saleAcct.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.mdl_STK);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 78);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(325, 598);
            this.groupBox2.TabIndex = 506;
            this.groupBox2.TabStop = false;
            // 
            // mdl_STK
            // 
            this.mdl_STK.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.mdl_STK.AutoArrange = false;
            this.mdl_STK.BackColor = System.Drawing.Color.LightBlue;
            this.mdl_STK.CheckBoxes = true;
            this.mdl_STK.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sel,
            this.@__stkd,
            this.lid,
            this.qty});
            this.mdl_STK.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdl_STK.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdl_STK.ForeColor = System.Drawing.Color.Black;
            this.mdl_STK.FullRowSelect = true;
            this.mdl_STK.GridLines = true;
            this.mdl_STK.Location = new System.Drawing.Point(3, 104);
            this.mdl_STK.Name = "mdl_STK";
            this.mdl_STK.Size = new System.Drawing.Size(319, 491);
            this.mdl_STK.TabIndex = 469;
            this.mdl_STK.UseCompatibleStateImageBehavior = false;
            this.mdl_STK.View = System.Windows.Forms.View.Details;
            this.mdl_STK.SelectedIndexChanged += new System.EventHandler(this.mdl_STK_SelectedIndexChanged);
            this.mdl_STK.DoubleClick += new System.EventHandler(this.mdl_STK_DoubleClick);
            // 
            // sel
            // 
            this.sel.Text = "OK";
            this.sel.Width = 33;
            // 
            // __stkd
            // 
            this.@__stkd.Text = "__StockCode";
            this.@__stkd.Width = 200;
            // 
            // lid
            // 
            this.lid.Text = "";
            this.lid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lid.Width = 0;
            // 
            // qty
            // 
            this.qty.Text = "QTY";
            this.qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.qty.Width = 54;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.picCIP);
            this.groupBox3.Controls.Add(this.lFName);
            this.groupBox3.Controls.Add(this.tNBcartes);
            this.groupBox3.Controls.Add(this.btnGo);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(319, 88);
            this.groupBox3.TabIndex = 468;
            this.groupBox3.TabStop = false;
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(172, 12);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(46, 28);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 467;
            this.picCIP.TabStop = false;
            this.picCIP.Click += new System.EventHandler(this.picCIP_Click);
            // 
            // lFName
            // 
            this.lFName.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lFName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lFName.Location = new System.Drawing.Point(6, 15);
            this.lFName.Name = "lFName";
            this.lFName.Size = new System.Drawing.Size(103, 20);
            this.lFName.TabIndex = 465;
            this.lFName.Text = "Assemble Qty: ";
            this.lFName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tNBcartes
            // 
            this.tNBcartes.BackColor = System.Drawing.Color.Khaki;
            this.tNBcartes.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tNBcartes.Location = new System.Drawing.Point(112, 12);
            this.tNBcartes.Multiline = true;
            this.tNBcartes.Name = "tNBcartes";
            this.tNBcartes.Size = new System.Drawing.Size(54, 27);
            this.tNBcartes.TabIndex = 464;
            this.tNBcartes.Text = "1";
            this.tNBcartes.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnGo
            // 
            this.btnGo.BackColor = System.Drawing.Color.Green;
            this.btnGo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnGo.ForeColor = System.Drawing.Color.White;
            this.btnGo.Location = new System.Drawing.Point(93, 48);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(220, 34);
            this.btnGo.TabIndex = 466;
            this.btnGo.Text = "GO";
            this.btnGo.UseVisualStyleBackColor = false;
            this.btnGo.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ed_lvITM);
            this.groupBox4.Controls.Add(this.grpTOT);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(325, 78);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1122, 598);
            this.groupBox4.TabIndex = 507;
            this.groupBox4.TabStop = false;
            // 
            // ed_lvITM
            // 
            this.ed_lvITM.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvITM.AutoArrange = false;
            this.ed_lvITM.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ed_lvITM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.line,
            this.ParentPart,
            this.SequenceNum,
            this.Component,
            this.Narration,
            this.ManuPartNumber,
            this.Description,
            this.AppManufacturer,
            this.QtyPer,
            this.PriceList,
            this.TotalPL,
            this.BomPrice,
            this.TotalBom,
            this.WRused,
            this.hold});
            this.ed_lvITM.ContextMenuStrip = this.mnc_CCopy;
            this.ed_lvITM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_lvITM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvITM.ForeColor = System.Drawing.Color.Black;
            this.ed_lvITM.FullRowSelect = true;
            this.ed_lvITM.GridLines = true;
            this.ed_lvITM.Location = new System.Drawing.Point(3, 95);
            this.ed_lvITM.MultiSelect = false;
            this.ed_lvITM.Name = "ed_lvITM";
            this.ed_lvITM.Size = new System.Drawing.Size(1116, 500);
            this.ed_lvITM.TabIndex = 253;
            this.ed_lvITM.UseCompatibleStateImageBehavior = false;
            this.ed_lvITM.View = System.Windows.Forms.View.Details;
            this.ed_lvITM.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ed_lvITM_ColumnClick);
            // 
            // line
            // 
            this.line.Text = "Item #";
            this.line.Width = 52;
            // 
            // ParentPart
            // 
            this.ParentPart.Text = "Parent StockCode";
            this.ParentPart.Width = 0;
            // 
            // SequenceNum
            // 
            this.SequenceNum.Text = "Sequence #";
            this.SequenceNum.Width = 0;
            // 
            // Component
            // 
            this.Component.Text = "StockCode";
            this.Component.Width = 103;
            // 
            // Narration
            // 
            this.Narration.Text = "Narration";
            this.Narration.Width = 80;
            // 
            // ManuPartNumber
            // 
            this.ManuPartNumber.Text = "Manufac. Part#";
            this.ManuPartNumber.Width = 109;
            // 
            // Description
            // 
            this.Description.Text = "Description";
            this.Description.Width = 199;
            // 
            // AppManufacturer
            // 
            this.AppManufacturer.Text = "Manufac. Name";
            this.AppManufacturer.Width = 127;
            // 
            // QtyPer
            // 
            this.QtyPer.Text = "Qty";
            this.QtyPer.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.QtyPer.Width = 56;
            // 
            // PriceList
            // 
            this.PriceList.Text = "Unit $$ (Mat. Cost)";
            this.PriceList.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.PriceList.Width = 107;
            // 
            // TotalPL
            // 
            this.TotalPL.Text = "Total";
            this.TotalPL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalPL.Width = 87;
            // 
            // BomPrice
            // 
            this.BomPrice.Text = "Unit $$ (List Price)";
            this.BomPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.BomPrice.Width = 111;
            // 
            // TotalBom
            // 
            this.TotalBom.Text = "Total";
            this.TotalBom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TotalBom.Width = 80;
            // 
            // WRused
            // 
            this.WRused.Text = "Used In";
            this.WRused.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.WRused.Width = 111;
            // 
            // mnc_CCopy
            // 
            this.mnc_CCopy.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stk,
            this.nara,
            this.partnb,
            this.desc,
            this.PL,
            this.Bom});
            this.mnc_CCopy.Name = "mnc_CCopy";
            this.mnc_CCopy.Size = new System.Drawing.Size(175, 136);
            // 
            // stk
            // 
            this.stk.Name = "stk";
            this.stk.Size = new System.Drawing.Size(174, 22);
            this.stk.Text = "StockCode";
            this.stk.Click += new System.EventHandler(this.stk_Click);
            // 
            // nara
            // 
            this.nara.Name = "nara";
            this.nara.Size = new System.Drawing.Size(174, 22);
            this.nara.Text = "Narration";
            this.nara.Click += new System.EventHandler(this.nara_Click);
            // 
            // partnb
            // 
            this.partnb.Name = "partnb";
            this.partnb.Size = new System.Drawing.Size(174, 22);
            this.partnb.Text = "Manufac. Part #";
            this.partnb.Click += new System.EventHandler(this.partnb_Click);
            // 
            // desc
            // 
            this.desc.Name = "desc";
            this.desc.Size = new System.Drawing.Size(174, 22);
            this.desc.Text = "Description";
            this.desc.Click += new System.EventHandler(this.desc_Click);
            // 
            // PL
            // 
            this.PL.Name = "PL";
            this.PL.Size = new System.Drawing.Size(174, 22);
            this.PL.Text = "List Price";
            this.PL.Click += new System.EventHandler(this.PL_Click);
            // 
            // Bom
            // 
            this.Bom.Name = "Bom";
            this.Bom.Size = new System.Drawing.Size(174, 22);
            this.Bom.Text = "BOM Material Cost";
            this.Bom.Click += new System.EventHandler(this.Bom_Click);
            // 
            // grpTOT
            // 
            this.grpTOT.Controls.Add(this.btnfind);
            this.grpTOT.Controls.Add(this.label2);
            this.grpTOT.Controls.Add(this.tKey);
            this.grpTOT.Controls.Add(this.txBMCTOT);
            this.grpTOT.Controls.Add(this.label4);
            this.grpTOT.Controls.Add(this.label1);
            this.grpTOT.Controls.Add(this.txLPTOT);
            this.grpTOT.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpTOT.Location = new System.Drawing.Point(3, 16);
            this.grpTOT.Name = "grpTOT";
            this.grpTOT.Size = new System.Drawing.Size(1116, 79);
            this.grpTOT.TabIndex = 252;
            this.grpTOT.TabStop = false;
            this.grpTOT.Visible = false;
            // 
            // btnfind
            // 
            this.btnfind.BackColor = System.Drawing.Color.Green;
            this.btnfind.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnfind.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfind.ForeColor = System.Drawing.Color.White;
            this.btnfind.Location = new System.Drawing.Point(289, 65);
            this.btnfind.Name = "btnfind";
            this.btnfind.Size = new System.Drawing.Size(67, 94);
            this.btnfind.TabIndex = 470;
            this.btnfind.Text = "Find";
            this.btnfind.UseVisualStyleBackColor = false;
            this.btnfind.Visible = false;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(6, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(170, 20);
            this.label2.TabIndex = 469;
            this.label2.Text = "BOM Material Cost Total:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.PeachPuff;
            this.tKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.ForeColor = System.Drawing.Color.Black;
            this.tKey.Location = new System.Drawing.Point(126, 68);
            this.tKey.MaxLength = 60;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(157, 20);
            this.tKey.TabIndex = 468;
            this.tKey.Visible = false;
            // 
            // txBMCTOT
            // 
            this.txBMCTOT.BackColor = System.Drawing.Color.PaleGreen;
            this.txBMCTOT.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txBMCTOT.ForeColor = System.Drawing.Color.Black;
            this.txBMCTOT.Location = new System.Drawing.Point(486, 15);
            this.txBMCTOT.Multiline = true;
            this.txBMCTOT.Name = "txBMCTOT";
            this.txBMCTOT.Size = new System.Drawing.Size(142, 30);
            this.txBMCTOT.TabIndex = 468;
            this.txBMCTOT.Text = "1";
            this.txBMCTOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(49, 68);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(77, 94);
            this.label4.TabIndex = 469;
            this.label4.Text = "Keyword:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(383, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 20);
            this.label1.TabIndex = 467;
            this.label1.Text = "List Price Total:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txLPTOT
            // 
            this.txLPTOT.BackColor = System.Drawing.Color.PaleTurquoise;
            this.txLPTOT.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txLPTOT.ForeColor = System.Drawing.Color.Black;
            this.txLPTOT.Location = new System.Drawing.Point(176, 15);
            this.txLPTOT.Multiline = true;
            this.txLPTOT.Name = "txLPTOT";
            this.txLPTOT.Size = new System.Drawing.Size(139, 30);
            this.txLPTOT.TabIndex = 466;
            this.txLPTOT.Text = "1";
            this.txLPTOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hold
            // 
            this.hold.Text = "";
            this.hold.Width = 0;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Orange;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(1241, 49);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(180, 15);
            this.label6.TabIndex = 506;
            this.label6.Text = "QTY = 0";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(1241, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 15);
            this.label3.TabIndex = 505;
            this.label3.Text = "PARTIAL HOLD";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Red;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(1241, 19);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(180, 15);
            this.label5.TabIndex = 504;
            this.label5.Text = "FULL HOLD";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Green;
            this.button1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(6, 48);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 34);
            this.button1.TabIndex = 468;
            this.button1.Text = "Reset";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // SYSPRO_Queries
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 676);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SYSPRO_Queries";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SYSPRO_Queries";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SYSPRO_Queries_Load);
            this.groupBox1.ResumeLayout(false);
            this.tlstrip.ResumeLayout(false);
            this.tlstrip.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.mnc_CCopy.ResumeLayout(false);
            this.grpTOT.ResumeLayout(false);
            this.grpTOT.PerformLayout();
            this.ResumeLayout(false);

        }

        private void mdl_STK_DoubleClick(object sender, EventArgs e)
        {
           // bool st = mdl_STK.SelectedItems[0].Checked;
          //  MessageBox.Show("etat=" + st.ToString()); 
        }

        private void mdl_STK_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void picCIP_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mdl_STK.Items.Count; i++)
                mdl_STK.Items[i].SubItems[3].Text = Tools.Conv_Dbl(tNBcartes.Text).ToString(); ;
        }

        private void stk_Click(object sender, EventArgs e)
        {
            CCopy_info ("stk");
        }


        void CCopy_info(string code)
        {
            if (ed_lvITM.SelectedItems.Count == 1)
            {
                int ndx = ed_lvITM.SelectedItems[0].Index;
                switch (code)
                {
                    case "stk":
                        Copy_CTRLC(ed_lvITM.Items[ndx].SubItems[3].Text);
                        break;
                    case "nara":
                        Copy_CTRLC(ed_lvITM.Items[ndx].SubItems[4].Text);
                        break;
                    case "part":
                        Copy_CTRLC(ed_lvITM.Items[ndx].SubItems[5].Text);
                        break;
                    case "desc":
                        Copy_CTRLC(ed_lvITM.Items[ndx].SubItems[6].Text);
                        break;
                    case "pl":
                        Copy_CTRLC(ed_lvITM.Items[ndx].SubItems[9].Text);
                        break;
                    case "bom":
                        Copy_CTRLC(ed_lvITM.Items[ndx].SubItems[11].Text);
                        break;
                }
            }


        }

        private void nara_Click(object sender, EventArgs e)
        {
            CCopy_info("nara");
        }

        private void partnb_Click(object sender, EventArgs e)
        {
            CCopy_info("part");
        }

        private void desc_Click(object sender, EventArgs e)
        {
            CCopy_info("desc");
        }

        private void PL_Click(object sender, EventArgs e)
        {
            CCopy_info("pl");
        }

        private void Bom_Click(object sender, EventArgs e)
        {
            CCopy_info("bom");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < mdl_STK.Items.Count; i++)
            {
                mdl_STK.Items[i].Checked = false;
                mdl_STK.Items[i].SubItems[3].Text = "1";
            }
        }

        private void ed_lvITM_ColumnClick_1(object sender, ColumnClickEventArgs e)
        {

        }

        private void tsb_COMMI_Click(object sender, EventArgs e)
        {
            refresh_Assemblies("FFF");
        }
     






        /////////Sorting    ed_lvITM 

    }
}
