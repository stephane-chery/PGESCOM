using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Threading;
using EAHLibs;
using System.Xml;
using Word = Microsoft.Office.Interop.Word;

namespace PGESCOM
{
    class PrintinWord 
    {
        string in_TempWord = "", Ofn = "";
        GroupBox in_grp_ICP;
        char in_docType = 'P';
        bool debut = true;
        private Word.Application app = new Word.Application();
        private object start = 0;
        private object end = 0;
        DataGridView dataGridView1;

        public PrintinWord(string x_TempWord, string x_PrtWord, char x_docType, GroupBox x_grp_ICP, DataGridView x_DGV)
        {
            in_grp_ICP = x_grp_ICP;
            in_TempWord = x_TempWord;
            Ofn = x_PrtWord;
            dataGridView1 = x_DGV;
        }

        public void PrintOutDoc()
        {
            object myTrue = true;
            object myFalse = false;
            object missingValue = Type.Missing;
            object range = Word.WdPrintOutRange.wdPrintAllDocument; //.wdPrintCurrentPage;
            object items = Word.WdPrintOutItem.wdPrintDocumentContent;
            object copies = "1";
            object pages = "1";
            object pageType = Word.WdPrintOutPages.wdPrintAllPages;

            object fn = Ofn;
            object ff = Type.Missing;
            object lc = Type.Missing;
            object pwd = Type.Missing;
            object atr = Type.Missing;
            object wpwd = Type.Missing;
            object ron = Type.Missing;
            object embd = Type.Missing;
            object svN = Type.Missing;
            object svF = Type.Missing;
            object svLett = Type.Missing;
            object enc = Type.Missing;
            object inLin = Type.Missing;
            object Asub = Type.Missing;
            object Linend = Type.Missing;
            object addmrk = Type.Missing;
            app.ActiveDocument.SaveAs(ref fn, ref ff, ref lc, ref pwd, ref atr, ref wpwd, ref ron, ref embd, ref svN, ref svF, ref svLett, ref enc, ref inLin, ref Asub, ref Linend, ref addmrk);

            //Save_Doc();
            object doNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
            app.ActiveDocument.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
            app.Quit();
        }

        private void Save_Doc()
        {
            object fn = Ofn;
            object ff = Type.Missing;
            object lc = Type.Missing;
            object pwd = Type.Missing;
            object atr = Type.Missing;
            object wpwd = Type.Missing;
            object ron = Type.Missing;
            object embd = Type.Missing;
            object svN = Type.Missing;
            object svF = Type.Missing;
            object svLett = Type.Missing;
            object enc = Type.Missing;
            object inLin = Type.Missing;
            object Asub = Type.Missing;
            object Linend = Type.Missing;
            object addmrk = Type.Missing;
            app.ActiveDocument.SaveAs(ref fn, ref ff, ref lc, ref pwd, ref atr, ref wpwd, ref ron, ref embd, ref svN, ref svF, ref svLett, ref enc, ref inLin, ref Asub, ref Linend, ref addmrk);
        }

        public void Page_PSLIP_Details()
        {
            char BorF = in_docType;
            Object MissV1 = Type.Missing;
            Object MissV2 = Type.Missing;
            Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
            object direc = Word.WdCollapseDirection.wdCollapseEnd;
            Rng.Collapse(ref direc);
            Rng.Font.Size = 8;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                string line = dataGridView1[0, i].Value.ToString();
                Print_Det(BorF, line, dataGridView1[1, i].Value.ToString(), dataGridView1[2, i].Value.ToString(), dataGridView1[3, i].Value.ToString(), dataGridView1[4, i].Value.ToString());
            }
        }

        private void Print_Det(char BorF, string line, string c1, string c2, string c3, string c4)
        {
            Word.Table TQdet;
            Object MissV1 = Type.Missing;
            Object MissV2 = Type.Missing;
            Word.Range Rng = app.ActiveDocument.Content;
            object direc = Word.WdCollapseDirection.wdCollapseEnd;
            Rng.Collapse(ref direc);
            int j = 0;
            if (BorF == 'P')
            {
                TQdet = app.ActiveDocument.Tables[4];
                //if (TQdet.Rows.Count != 2) TQdet.Rows.Add(ref MissV1);
                if (!debut) TQdet.Rows.Add(ref MissV1);
                else debut = false;
                j = TQdet.Rows.Count;
                //string st = (nb > 0) ? nb.ToString() + ". " : "";
                TQdet.Cell(j, 1).Range.Text = (line == "0" ? " " : line); //+ c1; TQdet.Cell(j, 1).Range.Font.Size = 9; TQdet.Cell(j, 1).Range.Font.Bold = 0; TQdet.Cell(j, 1).Range.Font.Underline = 0;
                TQdet.Cell(j, 2).Range.Text = c1; TQdet.Cell(j, 1).Range.Font.Size = 9; TQdet.Cell(j, 1).Range.Font.Bold = 0; TQdet.Cell(j, 1).Range.Font.Underline = 0;
                TQdet.Cell(j, 3).Range.Text = c2; TQdet.Cell(j, 2).Range.Font.Size = 9; TQdet.Cell(j, 2).Range.Font.Bold = 0; TQdet.Cell(j, 2).Range.Font.Underline = 0;
                TQdet.Cell(j, 4).Range.Text = c3; TQdet.Cell(j, 4).Range.Font.Size = 9; TQdet.Cell(j, 4).Range.Font.Bold = 0; TQdet.Cell(j, 4).Range.Font.Underline = 0;
                TQdet.Cell(j, 5).Range.Text = c4; TQdet.Cell(j, 5).Range.Font.Size = 9; TQdet.Cell(j, 5).Range.Font.Bold = 0; TQdet.Cell(j, 5).Range.Font.Underline = 0;
            }
        }

        public void OpenWF()
        {
            //Word.Application app = new Word.ApplicationClass();
            Object filename = in_TempWord;
            Object confirmConversions = Type.Missing;
            Object readOnly = Type.Missing;
            Object addToRecentFiles = Type.Missing;
            Object passwordDocument = Type.Missing;
            Object passwordTemplate = Type.Missing;
            Object revert = Type.Missing;
            Object writePasswordDocument = Type.Missing;
            Object writePasswordTemplate = Type.Missing;
            Object format = Type.Missing;
            Object encoding = Type.Missing;
            Object visible = Type.Missing;
            Object openConflictDocument = Type.Missing;
            Object openAndRepair = Type.Missing;
            Object documentDirection = Type.Missing;
            Object noEncodingDialog = Type.Missing;
            Object xmlTRsfrm = Type.Missing;
            app.Documents.Open(ref filename, ref confirmConversions, ref readOnly, ref addToRecentFiles, ref passwordDocument, ref passwordTemplate, ref revert, ref writePasswordDocument, ref writePasswordTemplate, ref format, ref encoding, ref visible, ref openConflictDocument, ref openAndRepair, ref documentDirection, ref xmlTRsfrm); //, ref noEncodingDialog);
            Word.Options options = app.Options;

            //options.BackgroundSave = true;
            //options.Overtype = true;
            //options.UpdateFieldsAtPrint = true;
            //options.PrintHiddenText = true;
            //options.PrintFieldCodes = true;

            Word.Document doc = app.ActiveDocument;
            Word.Range rng = doc.Range(ref start, ref end); //= Wbmk.Range;
            object i = 1;
            string shpto = "", st = "";

            switch (in_docType)
            {
                case 'P':
                    for (int j = 1; j < doc.Bookmarks.Count + 1; j++)
                    {
                        i = j;
                        string Bkname = doc.Bookmarks.get_Item(ref i).Name;
                        Word.Bookmark Wbmk = doc.Bookmarks.get_Item(ref i);
                        rng = Wbmk.Range;
                        switch (Bkname)
                        {
                            case "invNB": //Invoice
                                st =in_grp_ICP.Controls["DocTypeNum1"].Text;
                                rng.InsertAfter(st);
                                rng.Select();
                                break;
                            case "datinv": //date
                                st = in_grp_ICP.Controls["ShipDate2"].Text;
                                rng.InsertAfter(st);
                                rng.Select();
                                break;
                            case "CustNB": //customer code
                                st = in_grp_ICP.Controls["CustomerCode1"].Text;
                                rng.InsertAfter(st);
                                rng.Select();
                                break;
                            case "CustPO": //CustPO
                                st = in_grp_ICP.Controls["CustomerPurchOrder2"].Text;
                                rng.InsertAfter(st);
                                rng.Select();
                                break;
                            case "taxid": //txid
                                st = in_grp_ICP.Controls["taxid_vide"].Text;
                                rng.InsertAfter(st);
                                rng.Select();
                                break;
                            case "S_Contnm": //contact name
                                string nm = in_grp_ICP.Controls["Contact1"].Text;
                                rng.InsertAfter(nm);
                                rng.Select();
                                break;
                            case "S_Conttel": //contact TEL
                                string tel = in_grp_ICP.Controls["Telephone1"].Text;
                                rng.InsertAfter(tel); //
                                rng.Select();
                                break;
                            case "BillTo": //BILLTo
                                string bilTo = in_grp_ICP.Controls["Text52"].Text.Replace("\n\n", "\n");
                                rng.InsertAfter(bilTo);
                                rng.Select();
                                break;
                            case "ShipTo": //ShipTo
                                shpto = in_grp_ICP.Controls["Text28"].Text.Replace("\n\n", "\n");
                                rng.InsertAfter(shpto);
                                rng.Select();
                                break;
                            case "Terms": //terms
                                st = in_grp_ICP.Controls["InvoiceTerms1"].Text;
                                rng.InsertAfter(st);
                                rng.Select();
                                break;
                            case "incoTrm": //incoTerm
                                st = in_grp_ICP.Controls["CustomFieldOne1"].Text;
                                rng.InsertAfter(st);
                                rng.Select();
                                break;
                            case "Via": //via
                                st = in_grp_ICP.Controls["ShipInstructions1"].Text;
                                rng.InsertAfter(st);
                                rng.Select();
                                break;
                            case "cuRR": //curr
                                st = in_grp_ICP.Controls["Text56"].Text;
                                st = st.Substring(11, st.Length - 11);
                                rng.InsertAfter(st);
                                rng.Select();
                                break;
                            case "pxRef": //Ref
                                string pxref = in_grp_ICP.Controls["Text55"].Text.Substring(15, in_grp_ICP.Controls["Text55"].Text.Length - 15);
                                rng.InsertAfter(pxref);
                                rng.Select();
                                break;
                        }
                    }
                    break;
            }
        }
    }
}