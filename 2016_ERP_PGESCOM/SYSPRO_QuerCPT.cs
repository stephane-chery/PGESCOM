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
    public partial class SYSPRO_QuerCPT : Form
    {

        private Lib1 Tools = new Lib1();
        const int MAXarr =1200;
        const int NBCols = 14;
        string[,] arr_PASS = new string[MAXarr, NBCols];
        private int seelCol = 0;
        private ListViewColumnSorter lvSorter = null;

       Color zero_clr = Color.Salmon, PL_clr = Color.PaleTurquoise, bom_clr = Color.PaleGreen;

        public SYSPRO_QuerCPT()
        {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //if (Tools.Conv_Dbl(tNBcartes.Text) > 0)
            //{
            //    this.Cursor = Cursors.WaitCursor;
            //    init_arrPASS();
            //    Read_PAS();
            //    MoveARR_MDL();

            //    this.Cursor = Cursors.Default;
            //}
        }

        void Copy_CTRLC(string ST_Clip)
        {
            Clipboard.SetText(ST_Clip, TextDataFormat.Text);
        }

        void MoveARR_MDL()
        {
            //ed_lvITM.BeginUpdate();
            //double PLTOT = 0, BMCTOT = 0;
            //ed_lvITM.Items.Clear();
            //double dd=0;
            //for (int i = 0; i < MAXarr; i++)
            //{
            //    if (arr_PASS[i, 0] == "") i = MAXarr;
            //    else
            //    {
            //        bool Listprice = false, BOM = false;
            //        ListViewItem lv = ed_lvITM.Items.Add(arr_PASS[i, 0]);
            //        for (int j = 1; j < NBCols; j++)
            //        {
            //            string st = arr_PASS[i, j];
            //            switch (j)
            //            {
            //                case 8:
            //                    st = (Tools.Conv_Dbl(st) * Tools.Conv_Dbl(tNBcartes.Text)).ToString();
            //                    break;
            //                case 10:
            //                    dd = Tools.Conv_Dbl(arr_PASS[i, 8]) * Tools.Conv_Dbl(tNBcartes.Text) * Tools.Conv_Dbl(arr_PASS[i, 9]);
            //                    st = dd.ToString();
            //                    PLTOT += dd;
            //                    Listprice = (dd == 0);
            //                    break;
            //                case 12:
            //                    dd = Tools.Conv_Dbl(arr_PASS[i, 8]) * Tools.Conv_Dbl(tNBcartes.Text) * Tools.Conv_Dbl(arr_PASS[i, 11]);
            //                    st = dd.ToString();
            //                    BMCTOT += dd;
            //                    BOM = (dd == 0);
            //                    break;
            //            }
            //            lv.SubItems.Add(st);
            //            if (Listprice && BOM) lv.BackColor =zero_clr  ;

            //        }
                    
                    
            //    }
            //}
            //ed_lvITM.EndUpdate();
            //txLPTOT.Text = PLTOT.ToString();
            //txBMCTOT.Text = BMCTOT.ToString();
            //color_edlvitms(9, 10, PL_clr );
            //color_edlvitms(11, 12,bom_clr );
         
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




        private void ColName(int colndx)
        {
            btnseek.Text = "";
            switch (colndx)
            {
                case 0:
                    btnseek.Text = "StockCode";
                    break;
                case 1:
                    btnseek.Text = "Description";
                    break;
                case 2:
                    btnseek.Text = "Long Description";
                    break;
                case 3:
                    btnseek.Text = "Manufac. Part#";
                    break;

                case 5:
                    btnseek.Text = "Supplier";
                    break;

            }

          //  btnseek.Enabled = (seekColNm != "~");//&& tKey.Text.Length>0   );
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
            string stSql = "  SELECT* FROM[SysproCompanyP].[dbo].[InvMaster] where Description  like '%PBE%' OR LongDesc like '%" + tKey.Text + "%'";

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
            //init_arrPASS();
            //int nbChk = 0;
            //for (int i = 0; i < mdl_STK.Items.Count; i++)
            //{
            //    if (mdl_STK.Items[i].Checked)
            //    {
            //        Process_PAS(mdl_STK.Items[i].SubItems[1].Text, mdl_STK.Items[i].SubItems[3].Text);
            //        nbChk++; 
            //    }
          
            //}
            //grpTOT.Visible = (nbChk == 1);  
        }



        void Fill_mdl_STK(string pas)
        {

            //string pas_cond = (pas == "PAS") ? " substring(ParentPart,1,3) = 'PAS' " : " substring(ParentPart,1,3) <>'PAS' ";
            ////string CondAdmin = (MainMDI.User.ToLower() == "shammou") ? " where USRadmin='" + MainMDI.User.ToLower() + "'" : " ";
            ////     string stSql = (Abr != "VA") ? "SELECT EventLID, Event_Name,EvType  FROM [Orig_PSM_FDB].[dbo].[XCNG_Events] where EvType='" + Abr + "' order by Ev_Start" : " SELECT [Depcode] ,[DepName],'VA'  FROM [Orig_PSM_FDB].[dbo].[XCNG_Departements] ";
            //string stSql = " SELECT distinct [ParentPart] FROM v_ComponentListing where " +pas_cond + " order by [ParentPart]";
            //SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            //OConn.Open();
            //SqlCommand Ocmd = OConn.CreateCommand();
            //Ocmd.CommandText = stSql;
            //SqlDataReader Oreadr = Ocmd.ExecuteReader();
            //mdl_STK.Items.Clear();
            //while (Oreadr.Read())
            //{
            //    ListViewItem lv = mdl_STK.Items.Add(" ");
            //    lv.SubItems.Add(Oreadr["ParentPart"].ToString());
            //    lv.SubItems.Add(" ");
            //    lv.SubItems.Add("1");
  
            //}
            //OConn.Close();

        }

       void  refresh_Assemblies(string pas)
        {

            //mdl_STK.BackColor = (pas == "PAS") ? Color.NavajoWhite : Color.LightBlue;
            //lvSorter = new ListViewColumnSorter();
            //this.ed_lvITM.ListViewItemSorter = lvSorter;

            ////       mdl_STK.Modifiable = false;
            //ed_lvITM.Items.Clear();
            //txLPTOT.Clear();
            //txBMCTOT.Clear();
            //tNBcartes.Text = "1";

            //Fill_mdl_STK(pas);
        }

        private void SYSPRO_Queries_Load(object sender, EventArgs e)
        {
            //lvSorter = new ListViewColumnSorter();
            //this.ed_lvITM.ListViewItemSorter = lvSorter; 
            // Fill_mdl_STK();

            tKey.Text = MainMDI.SP_tkey;
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



        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SYSPRO_QuerCPT));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.mnc_CCopy = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stk = new System.Windows.Forms.ToolStripMenuItem();
            this.nara = new System.Windows.Forms.ToolStripMenuItem();
            this.partnb = new System.Windows.Forms.ToolStripMenuItem();
            this.desc = new System.Windows.Forms.ToolStripMenuItem();
            this.PL = new System.Windows.Forms.ToolStripMenuItem();
            this.Bom = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnseek = new System.Windows.Forms.Button();
            this.tKey = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lcol = new System.Windows.Forms.Label();
            this.ed_lvITM = new PGESCOM.ed_LVmodif();
            this.Component = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sh_desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ManuPartNumber = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Alter_key2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Supplr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hold = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox4.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.mnc_CCopy.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tabControl1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1447, 676);
            this.groupBox4.TabIndex = 507;
            this.groupBox4.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1441, 657);
            this.tabControl1.TabIndex = 254;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(1433, 631);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Components Search ";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox2.Controls.Add(this.ed_lvITM);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(3, 3);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1427, 625);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
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
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.lcol);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.btnseek);
            this.groupBox3.Controls.Add(this.tKey);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1421, 78);
            this.groupBox3.TabIndex = 506;
            this.groupBox3.TabStop = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Copperplate Gothic Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(350, 31);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(144, 20);
            this.label1.TabIndex = 497;
            this.label1.Text = "Search by: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnseek
            // 
            this.btnseek.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnseek.CausesValidation = false;
            this.btnseek.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnseek.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnseek.ForeColor = System.Drawing.Color.White;
            this.btnseek.Location = new System.Drawing.Point(494, 29);
            this.btnseek.Name = "btnseek";
            this.btnseek.Size = new System.Drawing.Size(310, 24);
            this.btnseek.TabIndex = 496;
            this.btnseek.Text = "StockCode";
            this.btnseek.UseVisualStyleBackColor = false;
            this.btnseek.Click += new System.EventHandler(this.btnseek_Click);
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.PeachPuff;
            this.tKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.ForeColor = System.Drawing.Color.Black;
            this.tKey.Location = new System.Drawing.Point(93, 29);
            this.tKey.MaxLength = 60;
            this.tKey.Multiline = true;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(251, 24);
            this.tKey.TabIndex = 493;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Copperplate Gothic Bold", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(13, 31);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 20);
            this.label5.TabIndex = 494;
            this.label5.Text = "Text: ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcol
            // 
            this.lcol.AutoSize = true;
            this.lcol.BackColor = System.Drawing.Color.Salmon;
            this.lcol.Location = new System.Drawing.Point(838, 39);
            this.lcol.Name = "lcol";
            this.lcol.Size = new System.Drawing.Size(13, 13);
            this.lcol.TabIndex = 498;
            this.lcol.Text = "0";
            // 
            // ed_lvITM
            // 
            this.ed_lvITM.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvITM.AutoArrange = false;
            this.ed_lvITM.BackColor = System.Drawing.Color.Honeydew;
            this.ed_lvITM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Component,
            this.sh_desc,
            this.LDesc,
            this.ManuPartNumber,
            this.Alter_key2,
            this.Supplr,
            this.hold});
            this.ed_lvITM.ContextMenuStrip = this.mnc_CCopy;
            this.ed_lvITM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_lvITM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvITM.ForeColor = System.Drawing.Color.Black;
            this.ed_lvITM.FullRowSelect = true;
            this.ed_lvITM.GridLines = true;
            this.ed_lvITM.Location = new System.Drawing.Point(3, 94);
            this.ed_lvITM.MultiSelect = false;
            this.ed_lvITM.Name = "ed_lvITM";
            this.ed_lvITM.Size = new System.Drawing.Size(1421, 528);
            this.ed_lvITM.TabIndex = 507;
            this.ed_lvITM.UseCompatibleStateImageBehavior = false;
            this.ed_lvITM.View = System.Windows.Forms.View.Details;
            this.ed_lvITM.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.ed_lvITM_ColumnClick);
            // 
            // Component
            // 
            this.Component.Text = "StockCode";
            this.Component.Width = 244;
            // 
            // sh_desc
            // 
            this.sh_desc.Text = "Description";
            this.sh_desc.Width = 312;
            // 
            // LDesc
            // 
            this.LDesc.Text = "Long Description";
            this.LDesc.Width = 403;
            // 
            // ManuPartNumber
            // 
            this.ManuPartNumber.Text = "Manufac. Part#";
            this.ManuPartNumber.Width = 233;
            // 
            // Alter_key2
            // 
            this.Alter_key2.Text = "Alternate key 2";
            this.Alter_key2.Width = 0;
            // 
            // Supplr
            // 
            this.Supplr.Text = "Supplier";
            this.Supplr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Supplr.Width = 133;
            // 
            // hold
            // 
            this.hold.Text = "";
            this.hold.Width = 0;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Red;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(995, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(180, 17);
            this.label2.TabIndex = 499;
            this.label2.Text = "FULL HOLD";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Yellow;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(995, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(180, 17);
            this.label3.TabIndex = 500;
            this.label3.Text = "PARTIAL HOLD";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // SYSPRO_QuerCPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1447, 676);
            this.Controls.Add(this.groupBox4);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "SYSPRO_QuerCPT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SYSPRO_Queries";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.SYSPRO_Queries_Load);
            this.groupBox4.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.mnc_CCopy.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
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
            //for (int i = 0; i < mdl_STK.Items.Count; i++)
            //    mdl_STK.Items[i].SubItems[3].Text = Tools.Conv_Dbl(tNBcartes.Text).ToString(); ;
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


        private void ed_lvITM_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            ColName(e.Column);
            lcol.Text = e.Column.ToString();
            ////MessageBox.Show (   e.Column.ToString()  );


            //seelCol = e.Column;

            //ListView myListView = (ListView)sender;

            //// Determine if clicked column is already the column that is being sorted.
            //if (e.Column == lvSorter.SortColumn)
            //{
            //    // Reverse the current sort direction for this column.
            //    if (lvSorter.Order == System.Windows.Forms.SortOrder.Ascending)
            //    {
            //        lvSorter.Order = System.Windows.Forms.SortOrder.Descending;
            //    }
            //    else
            //    {
            //        lvSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            //    }
            //}
            //else
            //{
            //    // Set the column number that is to be sorted; default to ascending.
            //    //lvSorter.SortColumn = e.Column; old
            //    //	lvSorter.Order = System.Windows.Forms.SortOrder.Ascending; old

            //    lvSorter.Order = System.Windows.Forms.SortOrder.Ascending;
            //    lvSorter.SortColumn = e.Column;

            //}

            //// Perform the sort with these new sort options.
            //myListView.Sort();
            //lvSorter.SortColumn = 0;
        }
        private void btnseek_Click(object sender, EventArgs e)
        {
            if (tKey.Text.Length > 2)
            {
                string stSql = "";
                this.Cursor = Cursors.WaitCursor;
                ed_lvITM.BeginUpdate();
                ed_lvITM.Items.Clear(); 

                switch (lcol.Text)
                {
                    case "0":
                        stSql= "  SELECT * FROM[SysproCompanyP].[dbo].[InvMaster] where StockCode like '%" + tKey.Text + "%'  order by StockCode ";
                        break;
                    case "1":
                    case "2":
                        stSql = "  SELECT * FROM[SysproCompanyP].[dbo].[InvMaster] where Description  like '%" + tKey.Text + "%' OR LongDesc like '%" + tKey.Text + "%'   order by Description";
                        break;
                    case "3":
                        stSql = "  SELECT * FROM[SysproCompanyP].[dbo].[InvMaster] where  AlternateKey1 like '%" + tKey.Text + "%'   order by AlternateKey1 ";
                        break;
                    case "5":
                        stSql = "  SELECT * FROM[SysproCompanyP].[dbo].[InvMaster] where Supplier like '%" + tKey.Text + "%'   order by Supplier ";
                        break;

                }
                if (stSql!="")      if (!fill_found_Items(stSql)) MessageBox.Show ("Sorry not Found.....");

                

                ed_lvITM.EndUpdate();
                this.Cursor = Cursors.Default;
                MainMDI.SP_tkey= tKey.Text;
            }


        }

        public bool fill_found_Items(string stSql)
        {
            bool found = false;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                Color myCLR = Color.Honeydew, myforCLR = Color.Black ;
                
                //   string dat = Oreadr["Opndate"].ToString().Substring(0, 10);
                ListViewItem lvI = ed_lvITM.Items.Add(Oreadr["StockCode"].ToString());
                lvI.SubItems.Add(Oreadr["Description"].ToString());
       //         lvI.SubItems.Add(Oreadr["LongDesc"].ToString());
                lvI.SubItems.Add(Oreadr["LongDesc"].ToString());
                lvI.SubItems.Add(Oreadr["AlternateKey1"].ToString());
                lvI.SubItems.Add(Oreadr["AlternateKey2"].ToString());
                lvI.SubItems.Add(Oreadr["Supplier"].ToString());
                lvI.SubItems.Add(Oreadr["StockOnHold"].ToString());
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

                lvI.BackColor = myCLR;
                lvI.ForeColor = myforCLR;
                if (!found) found = true;
            }
            OConn.Close();
            return found;

        }




        private void ed_lvITM_ColumnClick_2(object sender, ColumnClickEventArgs e)
        {
            btnseek.Text = ed_lvITM.Columns[e.Column].Text;
            ColName(e.Column);
            seelCol = e.Column;
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
