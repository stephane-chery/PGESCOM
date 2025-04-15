using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using Excel = Microsoft.Office.Interop.Excel;
//using DTS;
using EAHLibs;

namespace PGESCOM
{

    public partial class CMS_xlBills : Form
    {


        private Excel.Application ExcelObj = null;
        Object m_objOpt = System.Reflection.Missing.Value;
        string[,] Array_bills=new string[MainMDI.MAX_xlBills_RWS  ,MainMDI.MAX_xlBills_COL  ] ; 

        public CMS_xlBills()
        {
            InitializeComponent();
            ExcelObj = new Excel.Application();

            if (ExcelObj == null)
            {
                MessageBox.Show("ERROR: EXCEL couldn't be started!");
                System.Windows.Forms.Application.Exit();
            }
        }


        string[] ConvertToStringArray(System.Array values)
        {

            string[] theArray = new string[values.Length];
            for (int i = 1; i <= values.Length; i++)
            {
                if (values.GetValue(1, i) == null)
                    theArray[i - 1] = "";
                else
                    theArray[i - 1] = (string)values.GetValue(1, i).ToString();
            }

            return theArray;

        }
 

        bool sav_xlLine_Toarray(System.Array values,int _row)
        {
            
            for (int i = 1; i <= values.Length; i++)
            {
                if (values.GetValue(1, i) == null)
                   Array_bills[_row ,i - 1] = "";
                else
                   Array_bills[_row, i - 1] = (string)values.GetValue(1, i).ToString();
            }

            return true;
        }

        private void import_XLbills_arr()
        {
            this.openFileDialog1.FileName = "*.xls";
            if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(openFileDialog1.FileName, m_objOpt, true, m_objOpt,
                   m_objOpt, m_objOpt, true, m_objOpt, m_objOpt, m_objOpt, m_objOpt,
                   m_objOpt, m_objOpt, m_objOpt, m_objOpt);

                // get the collection of sheets in the workbook
                Excel.Sheets sheets = theWorkbook.Worksheets;

                // get the first and only worksheet from the collection 
                // of worksheets
                Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
                int nbRows = worksheet.UsedRange.EntireRow.Count;
                for (int s = 0; s < MainMDI.MAX_xlBills_RWS; s++)
                    for (int t = 0; t < MainMDI.MAX_xlBills_COL; t++)
                        Array_bills[s, t] = "";
 
                for (int i = 1; i < nbRows; i++)
                {
                    Excel.Range range = worksheet.get_Range("A" + i.ToString(), "O" + i.ToString());
                    System.Array myvalues = (System.Array)range.Cells.Value2;
                   sav_xlLine_Toarray(myvalues,i);

                  //  strArray_bills[i-1,] = ConvertToStringArray(myvalues);
                  
                }
            }
        }
         private void  import_XLbills()
         {
             this.openFileDialog1.FileName = "*.xls";
             if (this.openFileDialog1.ShowDialog() == DialogResult.OK)
             {
                 Excel.Workbook theWorkbook = ExcelObj.Workbooks.Open(openFileDialog1.FileName, m_objOpt, true, m_objOpt,
                    m_objOpt, m_objOpt, true, m_objOpt, m_objOpt, m_objOpt, m_objOpt,
                    m_objOpt, m_objOpt, m_objOpt, m_objOpt);

                 // get the collection of sheets in the workbook
                 Excel.Sheets sheets = theWorkbook.Worksheets;

                 // get the first and only worksheet from the collection 
                 // of worksheets
                 Excel.Worksheet worksheet = (Excel.Worksheet)sheets.get_Item(1);
                 int nbRows = worksheet.UsedRange.EntireRow.Count;
               //  MessageBox.Show("NB=" + nbRows.ToString());
                 for (int i = 1; i <= nbRows; i++)
                 {
                     Excel.Range range = worksheet.get_Range("A" + i.ToString(), "O" + i.ToString());
                     System.Array myvalues = (System.Array)range.Cells.Value2;
                     string[] strArray = ConvertToStringArray(myvalues);
                     ed_lvXL.Items.Add(new ListViewItem(strArray));
                 }
             }
         }
        private void Newbrd_Click(object sender, EventArgs e)
        {
           // import_XLbills();
            import_XLbills_arr();
        }

        private void exiit_Click(object sender, EventArgs e)
        {
            this.Hide(); 
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            
        }
    }
}