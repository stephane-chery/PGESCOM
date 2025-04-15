using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel; 

namespace PGESCOM
{


        public class Order_TR_XLPrint
        {
            private bool newP = false;
            public Order In_RDR;
            bool SamePg = false;
            public string[,] arr_PGC_IO = new string[100, 5];
            public string[,] arr_PGC_ALRMs = new string[100,17];

            Excel.Application m_objXL;
            Excel.Workbook m_objbook;
            Excel._Worksheet m_objSheet,m_objSheet2;




            public Order_TR_XLPrint(Order x_RDR)
            {
                In_RDR = x_RDR;

            }


            private void fill_arr_PGC_IO()
            {
                for (int i = 1; i < 100; i++) for (int j = 0; j < 5; j++) arr_PGC_IO[i, j] = "";

                arr_PGC_IO[0, 0] = In_RDR.LRID.Text + "   S/N: " + In_RDR.TRLsn.Text;
                arr_PGC_IO[0, 1] = In_RDR.lCpnyName.Text;
                string st = (In_RDR.tcust_Model.Text != MainMDI.VIDE && In_RDR.tcust_Model.Text.Length > 2) ? In_RDR.tcust_Model.Text + " (" + In_RDR.PX_Model.Text + ") " : In_RDR.PX_Model.Text;
                arr_PGC_IO[0, 2] = st;

                //lvIOTest
                for (int i = 0; i < In_RDR.lvIOTest.Items.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                        arr_PGC_IO[i+1, j] = In_RDR.lvIOTest.Items[i].SubItems[j].Text;
                }

            
                // lvLTest
                int II = In_RDR.lvIOTest.Items.Count + 1;
                for (int i = 0; i < In_RDR.lvLTest.Items.Count; i++)
                {
                    for (int j = 0; j < 5; j++)
                        arr_PGC_IO[II, j] = In_RDR.lvLTest.Items[i].SubItems[j].Text;
                    II++;
                }

            }


            //if (cod!='N') st=(!chk) ? "□" : "√";

            private void fill_arr_PGC_ALRMs()
            {
                for (int i =0; i < 100; i++) for (int j = 0; j < 17; j++) arr_PGC_ALRMs[i, j] = "";

                arr_PGC_ALRMs[0, 0] = In_RDR.LRID.Text + "   S/N: " + In_RDR.TRLsn.Text;
                arr_PGC_ALRMs[0, 1] = In_RDR.lCpnyName.Text;
                string st = (In_RDR.tcust_Model.Text != MainMDI.VIDE && In_RDR.tcust_Model.Text.Length > 2) ? In_RDR.tcust_Model.Text + " (" + In_RDR.PX_Model.Text + ") " : In_RDR.PX_Model.Text;
                arr_PGC_ALRMs[0, 2] = st;

                //footer col=6+++
                
                arr_PGC_ALRMs[0, 6] = In_RDR.tTRuser.Text;
                arr_PGC_ALRMs[0, 7] = "'" + In_RDR.lTRdate.Text;// +" ";
                arr_PGC_ALRMs[0, 8] = In_RDR.TRcmnt.Text;
  


                for (int i = 0; i < In_RDR.MLV_EqAlrm.Items.Count; i++)
                {
                    arr_PGC_ALRMs[i+1, 0] = "12";
                    arr_PGC_ALRMs[i+1, 1] = In_RDR.MLV_EqAlrm.Items[i].SubItems[1].Text;
                    arr_PGC_ALRMs[i+1, 2] = In_RDR.MLV_EqAlrm.Items[i].SubItems[16].Text;
                    for (int j = 3; j < 17; j++) arr_PGC_ALRMs[i+1, j] = In_RDR.MLV_EqAlrm.Items[i].SubItems[j - 1].Text;
                }

            }


            private bool tstFileName()
            {
                string Fname=MainMDI.XL_Path + @"\TR_Temp_PRINTED.xlsx";
                int i=0;
                while (i < 3)
                {
                    bool fin = true;
                    i++;
                    try
                    {
                        System.IO.File.Delete(MainMDI.XL_Path + @"\TR_Temp_PRINTED.xlsx");// "CMS_CALC.xls");
                    }
                    catch (Exception ee)
                    {
                        //MessageBox.Show("msg==" + ee.Message);
                        DialogResult rep = MessageBox.Show("Excel Testing file is currently Opened, msut be closed !!! (" + i.ToString() + ")", "EXCEL TESTING File", MessageBoxButtons.RetryCancel);
                      //  DialogResult rep = MessageBox.Show(ee.Message+ "(" + i.ToString() + ")", "EXCEL TESTING File", MessageBoxButtons.RetryCancel);
                        if (rep == DialogResult.Cancel) return false;
                        fin = false;
                    }
                    if (fin) i = 5;
                }
                
                return (i==5);
            }


            public void XLprocess()
            {


                if (tstFileName())
                {
                    Object m_objOpt = System.Reflection.Missing.Value;
                    m_objXL = new Excel.Application();
                    m_objbook = m_objXL.Workbooks.Open(MainMDI.XL_Path + @"\TR_Temp.xltx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);

                    m_objSheet = (Excel._Worksheet)m_objbook.Sheets.get_Item(1);
                    fill_arr_PGC_IO();
                    IO_PERFO_sheet my_IOSheet = new IO_PERFO_sheet(arr_PGC_IO);
                    my_IOSheet.fill_arr_CFG(1);
                    my_IOSheet.HDR(m_objSheet);
                    my_IOSheet.Detail(m_objSheet);


                    m_objSheet2 = (Excel._Worksheet)m_objbook.Sheets.get_Item(2);
                    ALRM_sheet my_ALRMSheet = new ALRM_sheet(arr_PGC_ALRMs);
                    fill_arr_PGC_ALRMs();
                    my_ALRMSheet.fill_arr_CFG_ALRMS();
                    my_ALRMSheet.HDR(m_objSheet2);
                    my_ALRMSheet.Detail(m_objSheet2);


                    //     m_objSheet2.PageSetup.LeftHeader = "TOTOTO: 2334   SN:2999";




                    m_objbook.SaveAs(MainMDI.XL_Path + @"\TR_Temp_PRINTED.xlsx", m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                    m_objbook.Close(false, m_objOpt, m_objOpt);
                    m_objXL.Quit();
                    //  ??? NO  data
                    MainMDI.EXEC_FILE("EXCEL.EXE", MainMDI.XL_Path + @"\TR_Temp_PRINTED.xlsx");
                }
                else MessageBox.Show("            TEST REPORT PRINT Cancelled..............."); 

            }








           void XL_TST()
            {

                Excel.Application m_objXL;
                Excel.Workbook m_objbook;
                Excel._Worksheet m_objSheet;

                System.IO.File.Delete(MainMDI.XL_Path + @"\TR_Temp_PRINTED.xlsx");// "CMS_CALC.xls");
                Object m_objOpt = System.Reflection.Missing.Value;
                m_objXL = new Excel.Application();
                m_objbook = m_objXL.Workbooks.Open(MainMDI.XL_Path + @"\TR_Temp.xltx", 0, true, 5, "", "", true, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "\t", false, false, 0, true, 1, 0);
                m_objSheet = (Excel._Worksheet)m_objbook.Sheets.get_Item(1);


                m_objSheet.Cells[10, 3] = "120"; m_objSheet.Cells[10, 4] = "122.3"; m_objSheet.Cells[10, 5] = "Bzzzzzzzzzzzzzzzzzz";
                m_objSheet.Cells[11, 3] = ""; m_objSheet.Cells[11, 4] = "38.4"; m_objSheet.Cells[11, 5] = "FFFFFzzzzzzzzzzz";

                m_objSheet = (Excel._Worksheet)m_objbook.Sheets.get_Item(2);
                m_objSheet.Cells[10, 3] = "120"; m_objSheet.Cells[10, 4] = "122.3"; m_objSheet.Cells[10, 5] = "Bzzzzzzzzzzzzzzzzzz";
                m_objSheet.Cells[11, 3] = ""; m_objSheet.Cells[11, 4] = "38.4"; m_objSheet.Cells[11, 5] = "FFFFFzzzzzzzzzzz";

                m_objbook.SaveAs(MainMDI.XL_Path + @"\TR_Temp_PRINTED.xlsx", m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                m_objbook.Close(false, m_objOpt, m_objOpt);
                m_objXL.Quit();
                //  ??? NO  data
                MainMDI.EXEC_FILE("EXCEL.EXE", MainMDI.XL_Path + @"\TR_Temp_PRINTED.xlsx");



            }

        }

    

public class XL_Cell
{

    public string txt { set; get; }
    public int Row { set; get; }
    public int Col { set; get; }

}


public abstract class XL_Sheet
{

    protected string[,] arr_cfg = new string[100, 5];

    protected void write_cells(List<XL_Cell> my_list, Excel._Worksheet my_Sheet)
    {
        foreach (XL_Cell my_cell in my_list)
        {
            my_Sheet.Cells[my_cell.Row, my_cell.Col] = my_cell.txt;
             
                         
        }
    }

    public virtual void HDR(Excel._Worksheet my_Sheet) { }
   
    public virtual void Detail(Excel._Worksheet my_Sheet)
    {
    }
    public virtual void Footer(int footer_row, Excel._Worksheet my_Sheet)
    {
    }

    protected int xtr_ROW(string coord)
    {
        int X = -1;
        int ipos = coord.IndexOf("/");
        if (ipos > -1)
        {
            try
            {
                return Int32.Parse(coord.Substring(0, ipos));
            }
            catch (SystemException SE)
            {
                MessageBox.Show("X: error........S.Exception=" + SE.Message);
            }
        }

        return X;
    }

    protected int xtr_COL(string coord)
    {
        int X = -1;
        int ipos = coord.IndexOf("/");
        if (ipos > -1)
        {
            try
            {
                return Int32.Parse(coord.Substring(ipos + 1, coord.Length - ipos - 1));
            }
            catch (SystemException SE)
            {
                MessageBox.Show("Y: error........S.Exception=" + SE.Message);
            }
        }
        return X;
    }


}

public class IO_PERFO_sheet : XL_Sheet
{
    List<XL_Cell> IO_LIST = new List<XL_Cell>();
    List<XL_Cell> HDR_LST = new List<XL_Cell>();

    public string[,] in_arr_PGC = new string[100, 5];



    public IO_PERFO_sheet(string[,] x_arr_PGC)
    {
        in_arr_PGC = x_arr_PGC;
    }


    public void fill_arr_CFG(int pageNb)
    {

        for (int ii = 1; ii < 100; ii++) for (int j = 0; j < 5; j++) arr_cfg[ii, j] = "";
        string[] arr_vals = new string[6];
        MainMDI.Find_arr_Fields("select HL1,Hl2,HL3,startLine,pageName from PSM_R_TR_SHTlist where shtID=" + pageNb, arr_vals);
        for (int j = 0; j < 5; j++) arr_cfg[0, j] = arr_vals[j]; string ShhetName = arr_vals[5];


        string stSql = " SELECT shtID,TstName_en,R,T,C from PSM_R_TR_SHTdetail where shtID= " + pageNb;
        SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
        OConn.Open();
        SqlCommand Ocmd = OConn.CreateCommand();
        Ocmd.CommandText = stSql;
        SqlDataReader Oreadr = Ocmd.ExecuteReader();
        int i = 1;
        while (Oreadr.Read())
        {
            for (int j = 0; j < 5; j++) arr_cfg[i, j] = Oreadr[j].ToString();
            i++;

        }
        OConn.Close();


    }


    public override void HDR(Excel._Worksheet my_Sheet)
    {

        for (int j = 0; j < 3; j++)
        {
            XL_Cell my_cell = new XL_Cell();
            my_cell.Row = xtr_ROW(arr_cfg[0, j]);
            my_cell.Col = xtr_COL(arr_cfg[0, j]);
            my_cell.txt = in_arr_PGC[0, j];
            HDR_LST.Add(my_cell);
        }
        base.write_cells(HDR_LST, my_Sheet);

    }



    public override void Detail(Excel._Worksheet myW_Sheet)
    {

        int oldRow = -1,s=-1;
        for (int i = 1; i < 100 && in_arr_PGC[i, 1] != ""; i++)
        {
            if (arr_cfg[i, 2] != "")
            {
                for (int j = 2; j < 5; j++)
                {
                    XL_Cell my_cell = new XL_Cell();
                    my_cell.Row = xtr_ROW(arr_cfg[i, j]);
                    my_cell.Col = xtr_COL(arr_cfg[i, j]);
                    my_cell.txt = in_arr_PGC[i, j];
                    IO_LIST.Add(my_cell);
                    oldRow = my_cell.Row;
                    s = oldRow;
                    if (j == 4)   //tstName
                    {
                        XL_Cell my_cell2 = new XL_Cell();
                        my_cell2.Row = my_cell.Row; 
                        my_cell2.Col = 2; 
                        my_cell2.txt = in_arr_PGC[i, 1];
                        IO_LIST.Add(my_cell2);
                    }
                }
            }
            else
            {

                s++;

                for (int j = 0; j < 5; j++)
                {

                    XL_Cell my_cell2 = new XL_Cell();
                    my_cell2.Row = s;
                    switch (j)
                    {
                        case 0:
                            my_cell2.Col = 1;
                            my_cell2.txt = "√";
                            break;
                        case 1:
                            my_cell2.Col = 2;
                            my_cell2.txt = in_arr_PGC[i, j];
                            break;
                        case 2:
                            my_cell2.Col = 3;
                            my_cell2.txt = in_arr_PGC[i, j];
                            break;
                        case 3:
                            my_cell2.Col = 4;
                            my_cell2.txt = in_arr_PGC[i, j];
                            break;
                        case 4:
                            my_cell2.Col = 5;
                            my_cell2.txt = in_arr_PGC[i, j];
                            break;
                    }

                    IO_LIST.Add(my_cell2);
                }
            }

        }
        base.write_cells(IO_LIST, myW_Sheet);

        if (s > oldRow)
        {
            Excel.Range my_rng = myW_Sheet.get_Range(myW_Sheet.Cells[oldRow + 1, 1], myW_Sheet.Cells[s, 5]);
            my_rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            my_rng.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
            my_rng.VerticalAlignment = Excel.XlVAlign.xlVAlignCenter;
            my_rng.WrapText = true;
           // my_rng.MergeCells = true; 
        }

        

    }

}








public class ALRM_sheet : XL_Sheet
{
    List<XL_Cell> ALARM_LIST = new List<XL_Cell>();
    List<XL_Cell> HDR_LST = new List<XL_Cell>();
    List<XL_Cell> Footer_LST = new List<XL_Cell>();

    public string[,] in_arr_PGC = new string[100, 17];



    public ALRM_sheet(string[,] x_arr_PGC)
    {
        in_arr_PGC = x_arr_PGC;
    }


    public void fill_arr_CFG_ALRMS()
    {

        for (int ii = 1; ii < 100; ii++) for (int j = 0; j < 5; j++) arr_cfg[ii, j] = "";
        string[] arr_vals = new string[6];
        MainMDI.Find_arr_Fields("select HL1,Hl2,HL3,startLine,pageName from PSM_R_TR_SHTlist where shtID=2", arr_vals);
        for (int j = 0; j < 5; j++) arr_cfg[0, j] = arr_vals[j]; string ShhetName = arr_vals[5];

        /*
        string stSql = " SELECT shtID,TstName_en,R,T,C from PSM_R_TR_SHTdetail where shtID= " + pageNb;
        SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
        OConn.Open();
        SqlCommand Ocmd = OConn.CreateCommand();
        Ocmd.CommandText = stSql;
        SqlDataReader Oreadr = Ocmd.ExecuteReader();
        int i = 1;
        while (Oreadr.Read())
        {
            for (int j = 0; j < 5; j++) arr_cfg[i, j] = Oreadr[j].ToString();
            i++;

        }
        OConn.Close();
        */

    }


    public override void HDR(Excel._Worksheet my_Sheet)
    {

        for (int j = 0; j < 3; j++)
        {
            XL_Cell my_cell = new XL_Cell();
            my_cell.Row = xtr_ROW(arr_cfg[0, j]);
            my_cell.Col = xtr_COL(arr_cfg[0, j]);
            my_cell.txt = in_arr_PGC[0, j];
            HDR_LST.Add(my_cell);
        }
        base.write_cells(HDR_LST, my_Sheet);

    }


    private void split_Desc(string _desc, string st_splitFrom, ref string[] arr_sub_desc)
    {
        //   string[] arr_sub_desc = new string[10];

       
        int s = 0;
        for (int i = 0; i < arr_sub_desc.Length ; i++) arr_sub_desc[i] = "";
        _desc = _desc.Replace("\n\n", "\n");
        _desc = _desc.Replace("\t", "  ");
        while (_desc.Length > 1)
        {
            int ipos = _desc.IndexOf(st_splitFrom, 0);
            if (ipos > -1)
            {
                arr_sub_desc[s++] = _desc.Substring(0, ipos);
                _desc = _desc.Substring(ipos + 1, _desc.Length - ipos - 1);

            }
            else
            {
                arr_sub_desc[s++] = _desc;
                _desc = "";
            }

        }
   

    }

    public override void Footer(int footer_row, Excel._Worksheet my_Sheet)
    {
        string st = "";
        int MAX_SPLIT_len = 60;
        for (int j = footer_row, pp=6 ; j <footer_row + 3; j++,pp++)
        {
            string[] titles = new string[3] { "TESTED by:", "DATE:", "COMMENTS:" };
            XL_Cell my_cell_T = new XL_Cell();
            my_cell_T.Row = j;
            my_cell_T.Col = 1;
            my_cell_T.txt = titles[pp - 6];
            Footer_LST.Add(my_cell_T);

            XL_Cell my_cell = new XL_Cell();
            my_cell.Row =j;
            my_cell.Col = 2;
            if (in_arr_PGC[0, pp].Length < MAX_SPLIT_len)
            {
                my_cell.txt = in_arr_PGC[0, pp];
                Footer_LST.Add(my_cell);

            }
            else
            {
                string[] my_arr_TXT = new string[30];
                for (int r = 0; r < 30; r++) my_arr_TXT[r] = "";
                string cmnt = in_arr_PGC[0, pp].Replace("\r", "").Replace ("\n\n","\n");
                split_Desc(cmnt, "\n", ref my_arr_TXT);
                            //  my_cell.txt = my_arr_TXT[0];
                            //  Footer_LST.Add(my_cell);

                int s = 0,rrow=j;
                
                while (my_arr_TXT[s] != "")
                {
                    XL_Cell my_cell_22 = new XL_Cell();
                    my_cell_22.Row = rrow ++;
                    my_cell_22.Col = 2;
                    my_cell_22.txt =  my_arr_TXT[s++];
                    Footer_LST.Add(my_cell_22 );
                }
              //  MessageBox.Show("row:" + j + " tilrow:" + rrow);
            }

                 
          
               
           

        }
        base.write_cells(Footer_LST , my_Sheet);

    }


    public override void Detail(Excel._Worksheet myW_Sheet)
    {
        int row = Int32.Parse ( in_arr_PGC[1, 0]);
        for (int i = 1; i < 100 && in_arr_PGC[i, 1] != ""; i++, row++)
        {

            for (int j = 0; j < 17; j++)
            {
                XL_Cell my_cell = new XL_Cell();
                my_cell.Row = row;
                my_cell.Col = j;
                my_cell.txt = (in_arr_PGC[i, j] == "[]") ? " " : in_arr_PGC[i, j];
                switch (j)
                {
                    case 0:
                        my_cell.Col = 1;
                        my_cell.txt = "√";
                        break;
                    case 1:
                        my_cell.Col = 2;
                        break;
                    case 2:
                        my_cell.Col = 17;
                        break;
                }

                ALARM_LIST.Add(my_cell);
            }
            

        }
        base.write_cells(ALARM_LIST , myW_Sheet);
        Excel.Range my_rng = myW_Sheet.get_Range(myW_Sheet.Cells[12, 1], myW_Sheet.Cells[row - 1, 17]);
        my_rng.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
        my_rng.HorizontalAlignment   = Excel.XlHAlign.xlHAlignCenter;

        Excel.Range my_rng_Tsts = myW_Sheet.get_Range(myW_Sheet.Cells[12, 2], myW_Sheet.Cells[row - 1, 2]);
        my_rng_Tsts .HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft ;  

        Footer(row+2, myW_Sheet);
        Excel.Range my_rng_Footer = myW_Sheet.get_Range(myW_Sheet.Cells[row+2, 1], myW_Sheet.Cells[row+5, 1]);
        my_rng_Footer.Font.Bold = true;//   .HorizontalAlignment = Excel.XlHAlign.xlHAlignLeft;

    }

}


}
