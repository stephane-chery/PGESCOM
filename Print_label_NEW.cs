using System;
using System.Windows.Forms;
using System.Drawing;
using Word = Microsoft.Office.Interop.Word;
using System.Collections;
using VB = Microsoft.VisualBasic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using EAHLibs;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for FichWord.
	/// </summary>
	public class Print_label_NEW
	{
		private static Lib1 Tools = new Lib1();
		private string in_lbl1 = "", in_lbl2 = "", in_lbl3 = "";
		private	Word.Application app = new Word.Application();
		private object Omiss = System.Reflection.Missing.Value;
		private object start = 0;
		private object end = 0;
		private string in_prtNme = "";
		private char in_docType = 'L';
		private Order In_ORFrm;
		private Quote_NEW In_QFrm;
		private string Tfn = "";
		private string Ofn = "";
		private double g_subtot = 0, g_FRT = 0, taxT0 = 0, bigtot0 = 0;

		private object EOP = Word.WdBreakType.wdPageBreak;
		private const int WT_1Col = 120; //100;
		private const int WT_2Col = 360; //365;
		private const int NBOption = 20;
		private int O = 0;
		private string[,] arr_options = new string[NBOption, 8];

		public Print_label_NEW(char x_doctype, string x_lbl1, string x_lbl2, string x_lbl3, string x_prtNme, Order x_ORFrm, Quote_NEW x_QFrm)
		{
			In_ORFrm = x_ORFrm;
			In_QFrm = x_QFrm;
			in_docType = x_doctype;
			in_lbl1 = x_lbl1;
			in_lbl2 = x_lbl2;
			in_lbl3 = x_lbl3;
			in_prtNme = x_prtNme;
			if (in_docType == 'S' || in_docType == 'R' || in_docType == 'O' || in_docType == 'T') In_ORFrm.TPDVisible = In_ORFrm.TPDVisible;
		}

		/*
		public bool DirectPrint()
		{
			var label = DYMO.Label.Framework.Label.Open("PRIMAX_PNSN.label");
			label.SetObjectText("PNB_SN",in_lbl1);
			label.SetObjectText("item", in_lbl2);
			label.SetObjectText("company", in_lbl3);
			label.Print(MainMDI.DYMOName);
			return true;
		}
		* 
		* */

		public bool Wexport()
		{
			//string Tfn = Application.StartupPath + @"\QuoteEnglish.doc";
			//string Ofn = Application.StartupPath + @"\Q" + In_QFrm.tQuoteID.Text + ".doc";
			Tfn = Application.StartupPath;
			Ofn = Tfn;
			//string stRev = In_QFrm.lCurSoln.Text.Substring(2, In_QFrm.lCurSoln.Text.Length - 2) + "-";
			//string Ofn = @"H:\Sales\PSM_Quotes" + @"\Q" +In_QFrm.tQuoteID.Text + stRev + In_QFrm.lCpnyName.Text + ".doc";
	 
			switch (in_docType)
			{
				case 'L': //print labels
					Tfn += @"\Qlabel.doc";
					//Ofn += @"\PrintedLBL.doc"; //MainMDI.OpenKnownFile("PrintedLBL.doc");
					OpenWF(Tfn);
					PrintOutDocLABEL();
					//MessageBox.Show("Continue !!!!! pls.......");
					break;
				case 'S':
					Tfn += @"\projSumm.doc";
					Ofn += @"\PrintedSUM.doc";
					OpenWF(Tfn);
					Page_OR_Details();
					PrintOutDoc();
					break;
				case 'B':
					Tfn += @"\projSumm.doc";
					Ofn += @"\PrintedSUM.doc";
					OpenWF(Tfn);
					Page_BILs_Details(in_docType);
					PrintOutDoc();
					break;
				case 'F': //commercial invoice
					Tfn += @"\invoice.doc";
					Ofn += @"\PrintedINV.doc";
					OpenWF(Tfn);
					Page_BILs_Details(in_docType);
					PrintOutDoc();
					break;
				case 'P': //packing Slip
					Tfn += @"\Pknslip.doc";
					Ofn += @"\PrintedPknSlp.doc";
					OpenWF(Tfn);
					Page_PSLIP_Details(in_docType);
					PrintOutDoc();
					break;
				case 'R': //Test Report
					Tfn += @"\TstReport.doc";
					Ofn += @"\PrintedTR.doc";
					OpenWF(Tfn);
					Page_OR_Details();
					PrintOutDoc();
					break;
				case 'Q':
					Tfn += @"\QuoteSumm.doc";
					Ofn += @"\PrintedAlsSUM.doc";
					OpenWF(Tfn);
					Page_Quote_Details();
					PrintOutDoc();
					break;
				case 'O':
					Tfn += @"\OneLD.doc";
					Ofn += @"\PrinteOneLD.doc";
					OpenWF(Tfn);
					Page_ONELD_Details();
					PrintOutDoc();
					break;
				case 'T':
					Tfn += @"\ShipSumm.doc";
					Ofn += @"\PrintedSHIPSUM.doc";
					OpenWF(Tfn);
					Page_SH_Details();
					PrintOutDoc();
					break;
			}
			return true;
		}

		private void Insert_page(int nPage)
		{
			//Word.Paragraph Opara;

			//Word.Range Rng = app.ActiveDocument.Range(ref start, ref end);
			
			//Rng.InsertBefore("HHHHHHHHHHH..");
			//Rng.Font.Size = 16;
		}
			
		private string Frmt_Adrs_NL(string adrs)
		{
			return adrs.Replace(",", "\n");
		}

		private void OpenWF(string TfName)
		{
			//Word.Application app = new Word.ApplicationClass();
			Object filename = TfName;
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
			string st_cpny = "", shpto = "", st = "";
 
			switch (in_docType)
			{
				case 'L': 
					for (int j = 1; j < doc.Bookmarks.Count + 1; j++)
					{
						i = j;
						string Bkname = doc.Bookmarks.get_Item(ref i).Name;
						Word.Bookmark Wbmk = doc.Bookmarks.get_Item(ref i);
						rng = Wbmk.Range;
						switch (Bkname)
						{
							case "lbl1":	
								string stt = in_lbl1.PadLeft(20, ' ');
								rng.InsertAfter(stt);
								rng.Font.Bold = 1;
								rng.Font.Size = 20;
								rng.Select();
								break;
							case "lbl2":
								if (in_lbl2.Length < 41) in_lbl2 = in_lbl2.PadLeft(40, ' ');
								rng.InsertAfter(in_lbl2);
								if (in_lbl2.Length > 41) rng.Font.Size = 9;
								rng.Select();
								break;
							case "lbl3":	
								if (in_lbl3.Length < 41) in_lbl3 = in_lbl3.PadLeft(40, ' ');
								rng.InsertAfter(in_lbl3);
								if (in_lbl3.Length > 41) rng.Font.Size = 9;
								rng.Select();
								break;
						}
					}
					break;
				case 'S': 
				case 'F': 
				case 'B': 
				case 'P': 
					for (int j = 1; j < doc.Bookmarks.Count + 1; j++)
					{
						i = j;
						string Bkname = doc.Bookmarks.get_Item(ref i).Name;
						Word.Bookmark Wbmk = doc.Bookmarks.get_Item(ref i);
						rng = Wbmk.Range;
						switch (Bkname)
						{
							case "Qid":	 
								rng.InsertAfter(In_ORFrm.lQID.Text + " / " + In_ORFrm.lSolNB.Text);
								rng.Select();
								break;
							case "contact":	 
								rng.InsertAfter(In_ORFrm.lcontactNm.Text);
								rng.Select();
								break;
							case "cpnyName":	 
								rng.InsertAfter(In_ORFrm.lCpnyName.Text);
								rng.Select();
								break;
							case "projName":	 
								rng.InsertAfter(In_ORFrm.lprojectNm.Text);
								rng.Select();
								break;
							case "projNb":	 
								rng.InsertAfter("P" + In_ORFrm.LRID.Text + "-" + In_ORFrm.lcurRRevNm.Text);
								rng.Select();
								break;
							case "cuRR":	 
								rng.InsertAfter(In_ORFrm.lcurDol.Text);
								rng.Select();
								break;
							case "subtot0":	 
								rng.InsertAfter(MainMDI.A00(In_ORFrm.tbilTOT.Text));
								rng.Select();
								break;
							case "freight":	 
								rng.InsertAfter(MainMDI.A00(In_ORFrm.tFreight.Text));
								rng.Select();
								break;
							case "taxT0":	 
								rng.InsertAfter(MainMDI.A00(In_ORFrm.tot_tax.Text));
								rng.Select();
								break;
							case "bigtot0":	 
								rng.InsertAfter(MainMDI.A00(In_ORFrm.tot_TPS_TVQ_Oth.Text));
								rng.Select();
								break;
							case "pxRef":	
								string pxref = (in_docType == 'F') ? In_ORFrm.tpxRef.Text : In_ORFrm.ts_pxref.Text;
								rng.InsertAfter(pxref); //In_ORFrm.LRID.Text + "-" + In_ORFrm.lcurRRevNm.Text.Replace("(", "").Replace(")", ""));
								rng.Select();
								break;
							case "dateEntR":	 
								rng.InsertAfter(In_ORFrm.lrrevDate.Text);
								rng.Select();
								break;
							case "invNB":
								st = (in_docType == 'F') ? In_ORFrm.tAccInv.Text : In_ORFrm.lINVnbr.Text;
								rng.InsertAfter(st);
								rng.Select();
								break;
							case "datinv":	 
								st = (in_docType == 'F') ? In_ORFrm.tInvDat.Text : In_ORFrm.tDateShip.Text;
								rng.InsertAfter(st);
								rng.Select();
								break;
							case "CustNB":	 
								st = (in_docType == 'F') ? In_ORFrm.tAccCust.Text : In_ORFrm.tAccCust_S.Text;
								rng.InsertAfter(st);
								rng.Select();
								break;
							case "dlvdate":	 
								string stt = (In_ORFrm.TPDVisible) ? In_ORFrm.TPD.Text : In_ORFrm.tDlvDate.Text;
								rng.InsertAfter(stt);
								rng.Select();
								break;
							case "CustPO":	 
								st = (in_docType == 'F') ? In_ORFrm.tlPONb.Text : In_ORFrm.tlPONb_S.Text;
								rng.InsertAfter(st); //In_ORFrm.tCustPO.Text);
								rng.Select();
								break;
							case "taxid":	 
								st = (in_docType == 'F') ? In_ORFrm.ttaxID.Text : In_ORFrm.shp_taxID.Text;
								rng.InsertAfter(st);
								rng.Select();
								break;
							case "S_Contnm":	 
								//scpny = (In_ORFrm.lSA_cpny.Text == MainMDI.UNKNWN_CPNY) ? "--" : In_ORFrm.lSA_cpny.Text;
								//string SHPTO = (In_ORFrm.tBil_ShipTo.Text == "") ? "--" : In_ORFrm.tBil_ShipTo.Text;
								string nm = (in_docType == 'B') ? In_ORFrm.lS_Contnm.Text : In_ORFrm.tCont_Nm.Text;
								rng.InsertAfter(nm); //In_ORFrm.lSA.Text); //"n/a");
								rng.Select();
								break;
							case "S_Conttel":	 
								//scpny = (In_ORFrm.lSA_cpny.Text == MainMDI.UNKNWN_CPNY) ? "--" : In_ORFrm.lSA_cpny.Text;
								//string SHPTO = (In_ORFrm.tBil_ShipTo.Text == "") ? "--" : In_ORFrm.tBil_ShipTo.Text;
								string tel = (in_docType == 'B') ? In_ORFrm.lS_ContTel.Text : In_ORFrm.tcont_tel.Text;
								rng.InsertAfter(tel); //In_ORFrm.lSA.Text); //"n/a");
								rng.Select();
								break;
							case "ShipTo": //tLot_ShipTo
								st_cpny = (in_docType == 'F') ? In_ORFrm.tbil_ShipTo_cpny.Text : In_ORFrm.tLot_ShipTo_cpny.Text;
								shpto = (in_docType == 'F') ? Frmt_Adrs_NL(In_ORFrm.tBil_ShipTo.Text) : In_ORFrm.tLot_ShipTo.Text;
								st_cpny = (st_cpny == MainMDI.UNKNWN_CPNY) ? "--" : st_cpny;
 								rng.InsertAfter(st_cpny + "\n" + shpto); //In_ORFrm.lSA.Text); //"n/a");
								rng.Select();
								break;
							case "BillTo":	
								st_cpny = (in_docType == 'F') ? In_ORFrm.tLot_SoldTo_Cpny.Text : In_ORFrm.tLot_Bilto_Cpny.Text;
								shpto = (in_docType == 'F') ? Frmt_Adrs_NL(In_ORFrm.tLot_SoldTo.Text) : In_ORFrm.tLot_Bilto.Text;
								st_cpny = (st_cpny == MainMDI.UNKNWN_CPNY) ? "--" : st_cpny;
 							 	rng.InsertAfter(st_cpny + "\n" + shpto);
								rng.Select();
								break;
							case "Terms":	 
								st = (in_docType == 'F') ? In_ORFrm.cbLot_Terms.Text : In_ORFrm.cbLot_Terms_S.Text;
								rng.InsertAfter(st);
								rng.Select();
								break;
							case "incoTrm":	 
								st = (in_docType == 'F') ? In_ORFrm.cbLot_IncoTerms.Text : In_ORFrm.cbLot_IncoTerms_S.Text;
								rng.InsertAfter(st);
								rng.Select();
								break;
							case "Via":	 
								st = (in_docType == 'F') ? In_ORFrm.cbLot_Via.Text : In_ORFrm.cbLot_Via_S.Text;
								rng.InsertAfter(st);
								rng.Select();
								break;
							case "s_cmnt":
								st = (in_docType == 'F') ? "" : In_ORFrm.tLot_comnt.Text;
								rng.InsertAfter(st);
								rng.Select();
								break;
							case "cmnt":	
								st = (in_docType == 'F') ? In_ORFrm.cbLot_Via.Text : In_ORFrm.cbLot_Via_S.Text;
								rng.InsertAfter("\n" + In_ORFrm.tRRevCmnt.Text);
								rng.Select();
								break;
							case "s_Broker":
								st = (in_docType == 'F') ? In_ORFrm.tcusBrok.Text :"";
								rng.InsertAfter(st);
								rng.Select();
								break;
							case "Weight":
								st = (in_docType == 'F') ? In_ORFrm.txWEIGHT.Text : "";
								rng.InsertAfter(st);
								rng.Select();
								break;
							case "s_HS":
								st = (in_docType == 'F') ? In_ORFrm.txHS.Text : "";
								rng.InsertAfter(st);
								rng.Select();
								break;
						}
					}
					break;
				case 'O': 
					for (int j = 1; j < doc.Bookmarks.Count + 1; j++)
					{
						i = j;
						string Bkname = doc.Bookmarks.get_Item(ref i).Name;
						Word.Bookmark Wbmk = doc.Bookmarks.get_Item(ref i);
						rng = Wbmk.Range;
						switch (Bkname)
						{
							case "QID":	 
								rng.InsertAfter(In_ORFrm.lQID.Text + " / " + In_ORFrm.lSolNB.Text);
								//+ "-" + In_ORFrm.lcurRRevNm.Text);
								rng.Select();
								break;
							case "contact":	 
								rng.InsertAfter(In_ORFrm.lcontactNm.Text);
								rng.Select();
								break;
							case "cpnyName":	 
								rng.InsertAfter(In_ORFrm.lCpnyName.Text);
								rng.Select();
								break;
							case "SN":	 
								//rng.InsertAfter(In_ORFrm.lprojectNm.Text);
								rng.InsertAfter(In_ORFrm.lSn.Text);
								rng.Select();
								break;
							case "ProjID":	 
								//rng.InsertAfter("P" + In_ORFrm.LRID.Text + "-" + In_ORFrm.lcurRRevNm.Text);
								rng.InsertAfter("P" + In_ORFrm.LRID.Text);
								rng.Select();
								break;
								//case "cuRR":	 
								//rng.InsertAfter(In_ORFrm.lcurDol.Text);
								//rng.Select();
								//break;
							case "dateEntR":	 
								rng.InsertAfter(In_ORFrm.lCFdatE.Text);
								rng.Select();
								break;
							case "dlvdate":	 
								//MessageBox.Show("car: " +);
								//string stt = (In_ORFrm.RRev_Status.Text[0] == 'F') ? In_ORFrm.TPD.Text : In_ORFrm.tDlvDate.Text;
								//string stt = (In_ORFrm.RRev_Status.Text[0] == 'F') ? In_ORFrm.TPD.Text : In_ORFrm.ldpCFdlvr.Text;
								string appvd = MainMDI.Find_One_Field("SELECT Aprvd FROM  PSM_R_Detail WHERE PrimaxSN ='" + In_ORFrm.lSn.Text + "'");
								string stt = "";
								if (appvd == MainMDI.VIDE && In_ORFrm.lSn.Text.IndexOf("NSP") == -1) stt = "Error Date ????";
								else stt = (appvd == "0") ? In_ORFrm.TPD.Text : In_ORFrm.ldpCFdlvr.Text;
								 
								rng.InsertAfter(stt);
								rng.Select();
								break;
							case "CustPO":	 
								rng.InsertAfter(In_ORFrm.tCustPO.Text);
								rng.Select();
								break;
						}
					}
					break;
				case 'Q': 
					for (int j = 1; j < doc.Bookmarks.Count + 1; j++)
					{
						i = j;
						string Bkname = doc.Bookmarks.get_Item(ref i).Name;
						Word.Bookmark Wbmk = doc.Bookmarks.get_Item(ref i);
						rng = Wbmk.Range;
						switch (Bkname)
						{
							case "QID":	 
								rng.InsertAfter(In_QFrm.tQuoteID.Text);
								//+ "-" + In_ORFrm.lcurRRevNm.Text);
								rng.Select();
								break;
							case "REV":	 
								rng.InsertAfter(In_QFrm.lCurSoln.Text);
								rng.Select();
								break;
							case "cpnyName":	 
								rng.InsertAfter(In_QFrm.lCpnyName.Text);
								rng.Select();
								break;
							case "alias":	 
								//rng.InsertAfter("P" + In_ORFrm.LRID.Text + "-" + In_ORFrm.lcurRRevNm.Text);
								rng.InsertAfter(In_QFrm.lCurALSn.Text);
								rng.Select();
								break;
						}
					}
					break;
			}
		}

		//ShowPageSettings - let's us change the page settings...

		internal void PrintOutDocLABEL()
		{ 
			object myTrue = true;
			object myFalse = false;
			object missingValue = Type.Missing;
			object range = Word.WdPrintOutRange.wdPrintAllDocument; //.wdPrintCurrentPage;
			object items = Word.WdPrintOutItem.wdPrintDocumentContent;
			object copies = "1";
			object pages = "1";
			object pageType = Word.WdPrintOutPages.wdPrintAllPages;

			string OldPrn = app.ActivePrinter;
			app.ActivePrinter = in_prtNme; //change PRTName if printing LABEL
			 
			//Save_Doc();
			//In_QFrm.lOFName.Text = Ofn;
			//printLABELS
			app.ActiveDocument.PrintOut(ref myTrue, ref myFalse, ref range, 
				ref missingValue, ref missingValue, ref missingValue, 
				ref items, ref copies, ref pages, ref pageType, ref myFalse,
				ref myTrue, ref missingValue, ref myFalse, ref missingValue, 
				ref missingValue, ref missingValue, ref missingValue);
			InfoBoard ll = new InfoBoard("Label is under Print.....wait !....", 3);
			//ll.pic.visible = false;
			ll.ShowDialog();
			object doNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;

			app.ActiveDocument.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
			app.ActivePrinter = OldPrn;
			app.Quit(ref doNotSaveChanges, ref missingValue, ref missingValue);
		}
	
		internal void PrintOutDoc()
		{ 
			object myTrue = true;
			object myFalse = false;
			object missingValue = Type.Missing;
			object range = Word.WdPrintOutRange.wdPrintAllDocument; //.wdPrintCurrentPage;
			object items = Word.WdPrintOutItem.wdPrintDocumentContent;
			object copies = "1";
			object pages = "1";
			object pageType = Word.WdPrintOutPages.wdPrintAllPages;

			//MessageBox.Show("Prt= " + app.ActivePrinter);
			//PrintDialog pd = new PrintDialog();

			string OldPrn = app.ActivePrinter;
			if (in_docType == 'L') app.ActivePrinter = in_prtNme; //change PRTName if printing LABEL
			 
			Save_Doc();
			if (in_docType != 'Q') In_ORFrm.lOFName.Text = Ofn;
			else In_QFrm.lOFName.Text = Ofn;
			//printLABELS
			if (in_docType == 'L')
			{
				app.ActiveDocument.PrintOut(ref myTrue, ref myFalse, ref range, 
					ref missingValue, ref missingValue, ref missingValue, 
					ref items, ref copies, ref pages, ref pageType, ref myFalse,
					ref myTrue, ref missingValue, ref myFalse, ref missingValue, 
					ref missingValue, ref missingValue, ref missingValue);
			}
			object doNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
			app.ActiveDocument.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
			app.ActivePrinter = OldPrn;
			app.Quit(ref doNotSaveChanges, ref missingValue, ref missingValue);
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

		private void Fermer_AppOLD(string OfName)
		{
			object fn = OfName;
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
			object k1 = Type.Missing;
			object k2 = Type.Missing;
			//app.ActiveDocument.PrintOut(); //ref fn, ref ff, ref lc, ref pwd, ref atr, ref wpwd, ref ron, ref embd, ref svN, ref svF, ref svLett, ref enc, ref inLin, ref Asub, ref Linend, ref addmrk, ref k1, ref k2);
			object sv = Type.Missing;
			object of = Type.Missing;
			object rd = Type.Missing;

			app.ActiveDocument.Close(ref sv, ref of, ref rd);
			app.Quit(ref sv, ref of, ref rd);
		}

		private void NeWF()
		{
			Word.Application app = new Word.Application();
			object template = Type.Missing;
			object newtemplate = Type.Missing;
			object DocType = Type.Missing;
			object visible = Type.Missing;
			app.Documents.Add(ref template, ref newtemplate, ref DocType, ref visible);

			Word.Document doc = app.ActiveDocument;
			string st = "PRIMAX TECHNOLOGIE INC.";
			object deb = 0;
			object fin = 0;
			Word.Range rng = doc.Range(ref deb, ref fin);
			 
			rng.Text = st;
			rng.Select();
			rng.Font.Name = "ARIAL BLACK";
			rng.Font.Italic = 1;
			rng.Font.Size = 14;
			rng.Select();

			//doc.Save();
			object fn = @"c:\diode.doc";
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
			object sv = Type.Missing;
			object of = Type.Missing;
			object rd = Type.Missing;
			app.ActiveDocument.Close(ref sv, ref of, ref rd);
			app.Quit(ref sv, ref of, ref rd);
		}

		private void Print_Det_Config(bool chk, string itm, string dwg)
		{
			Word.Table TQdet;
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content;
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);

			TQdet = app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count - 1];
			TQdet.Rows.Add(ref MissV1);
			int j = TQdet.Rows.Count;
			//string st = (nb > 0) ? nb.ToString() + ". " : "";
			string st = (!chk) ? "□" : "√";
			TQdet.Cell(j, 1).Range.Text = st; TQdet.Cell(j, 1).Range.Font.Size = 9; TQdet.Cell(j, 1).Range.Font.Bold = 0; TQdet.Cell(j, 1).Range.Font.Underline = 0;
			TQdet.Cell(j, 2).Range.Text = st; TQdet.Cell(j, 2).Range.Font.Size = 9; TQdet.Cell(j, 2).Range.Font.Bold = 0; TQdet.Cell(j, 2).Range.Font.Underline = 0;
			TQdet.Cell(j, 3).Range.Text = st; TQdet.Cell(j, 3).Range.Font.Size = 9; TQdet.Cell(j, 3).Range.Font.Bold = 0; TQdet.Cell(j, 3).Range.Font.Underline = 0;

			TQdet.Cell(j, 4).Range.Text = itm; TQdet.Cell(j, 4).Range.Font.Size = 9; TQdet.Cell(j, 4).Range.Font.Bold = 0; TQdet.Cell(j, 4).Range.Font.Underline = 0;
			TQdet.Cell(j, 5).Range.Text = dwg; TQdet.Cell(j, 5).Range.Font.Size = 9; TQdet.Cell(j, 5).Range.Font.Bold = 0; TQdet.Cell(j, 5).Range.Font.Underline = 0;
			//TQdet.Cell(j, 4).Range.Text = c3; TQdet.Cell(j, 4).Range.Font.Size = 9; TQdet.Cell(j, 4).Range.Font.Bold = 0; TQdet.Cell(j, 4).Range.Font.Underline = 0;
			//TQdet.Cell(j, 5).Range.Text = c4; TQdet.Cell(j, 5).Range.Font.Size = 9; TQdet.Cell(j, 5).Range.Font.Bold = 0; TQdet.Cell(j, 5).Range.Font.Underline = 0;
		}

		private void Print_Det_ConfigOK_160807(bool chk, string itm, string dwg)
		{
			Word.Table TQdet;
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content;
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);

			TQdet = app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count];
			TQdet.Rows.Add(ref MissV1);
			int j = TQdet.Rows.Count;
			//string st = (nb > 0) ? nb.ToString() + ". " : "";
			string st = (!chk) ? "□" : "√";
			TQdet.Cell(j, 1).Range.Text = st; TQdet.Cell(j, 1).Range.Font.Size = 9; TQdet.Cell(j, 1).Range.Font.Bold = 0; TQdet.Cell(j, 1).Range.Font.Underline = 0;
			TQdet.Cell(j, 2).Range.Text = itm; TQdet.Cell(j, 2).Range.Font.Size = 9; TQdet.Cell(j, 2).Range.Font.Bold = 0; TQdet.Cell(j, 2).Range.Font.Underline = 0;
			TQdet.Cell(j, 3).Range.Text = dwg; TQdet.Cell(j, 3).Range.Font.Size = 9; TQdet.Cell(j, 3).Range.Font.Bold = 0; TQdet.Cell(j, 3).Range.Font.Underline = 0;
			//TQdet.Cell(j, 4).Range.Text = c3; TQdet.Cell(j, 4).Range.Font.Size = 9; TQdet.Cell(j, 4).Range.Font.Bold = 0; TQdet.Cell(j, 4).Range.Font.Underline = 0;
			//TQdet.Cell(j, 5).Range.Text = c4; TQdet.Cell(j, 5).Range.Font.Size = 9; TQdet.Cell(j, 5).Range.Font.Bold = 0; TQdet.Cell(j, 5).Range.Font.Underline = 0;
		}

		private void Print_Det_QAlias(bool chk, string affID, string itm, string Qty, string Ext)
		{
			Word.Table TQdet;
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content;
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);

			TQdet = app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count];
			TQdet.Rows.Add(ref MissV1);
			int j = TQdet.Rows.Count;

			TQdet.Cell(j, 1).Range.Text = affID; TQdet.Cell(j, 1).Range.Font.Size = 9; TQdet.Cell(j, 1).Range.Font.Bold = 0; TQdet.Cell(j, 1).Range.Font.Underline = 0;
			TQdet.Cell(j, 2).Range.Text = itm; TQdet.Cell(j, 2).Range.Font.Size = 9; TQdet.Cell(j, 2).Range.Font.Bold = 0; TQdet.Cell(j, 2).Range.Font.Underline = 0;
			TQdet.Cell(j, 3).Range.Text = Qty; TQdet.Cell(j, 3).Range.Font.Size = 9; TQdet.Cell(j, 3).Range.Font.Bold = 0; TQdet.Cell(j, 3).Range.Font.Underline = 0;
			TQdet.Cell(j, 4).Range.Text = Ext; TQdet.Cell(j, 4).Range.Font.Size = 9; TQdet.Cell(j, 4).Range.Font.Bold = 0; TQdet.Cell(j, 4).Range.Font.Underline = 0;
			//TQdet.Cell(j, 5).Range.Text = c4; TQdet.Cell(j, 5).Range.Font.Size = 9; TQdet.Cell(j, 5).Range.Font.Bold = 0; TQdet.Cell(j, 5).Range.Font.Underline = 0;
		}

		private void Print_Det_SummOLD(int nb, string c1, string c2, string c3, string c4, string QtyBO)
		{
			Word.Table TQdet;
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content;
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);

			TQdet = app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count];
			TQdet.Rows.Add(ref MissV1);
			int j = TQdet.Rows.Count;
			//string st = (nb > 0) ? nb.ToString() + ". " : "";
			string st = "";
			TQdet.Cell(j, 1).Range.Text = st + c1; TQdet.Cell(j, 1).Range.Font.Size = 9; TQdet.Cell(j, 1).Range.Font.Bold = 0; TQdet.Cell(j, 1).Range.Font.Underline = 0;
			TQdet.Cell(j, 2).Range.Text = c2; TQdet.Cell(j, 2).Range.Font.Size = 9; TQdet.Cell(j, 2).Range.Font.Bold = 0; TQdet.Cell(j, 2).Range.Font.Underline = 0;
			TQdet.Cell(j, 3).Range.Text = QtyBO; TQdet.Cell(j, 3).Range.Font.Size = 9; TQdet.Cell(j, 3).Range.Font.Bold = 0; TQdet.Cell(j, 3).Range.Font.Underline = 0;
			TQdet.Cell(j, 4).Range.Text = c3; TQdet.Cell(j, 4).Range.Font.Size = 9; TQdet.Cell(j, 4).Range.Font.Bold = 0; TQdet.Cell(j, 4).Range.Font.Underline = 0;
			TQdet.Cell(j, 5).Range.Text = c4; TQdet.Cell(j, 5).Range.Font.Size = 9; TQdet.Cell(j, 5).Range.Font.Bold = 0; TQdet.Cell(j, 5).Range.Font.Underline = 0;
		}

		private void Print_Det_Summ(char BorF, string line, string c1, string c2, string c3, string c4, string QtyBO)
		{
			Word.Table TQdet;
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content;
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			if (BorF != 'F' && BorF != 'P')
			{
				TQdet = app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count];
				TQdet.Rows.Add(ref MissV1);
				int j = TQdet.Rows.Count;
				//string st = (nb > 0) ? nb.ToString() + ". " : "";
				string st = "";
				TQdet.Cell(j, 1).Range.Text = st + c1; TQdet.Cell(j, 1).Range.Font.Size = 9; TQdet.Cell(j, 1).Range.Font.Bold = 0; TQdet.Cell(j, 1).Range.Font.Underline = 0;
				TQdet.Cell(j, 2).Range.Text = c2; TQdet.Cell(j, 2).Range.Font.Size = 9; TQdet.Cell(j, 2).Range.Font.Bold = 0; TQdet.Cell(j, 2).Range.Font.Underline = 0;
				TQdet.Cell(j, 3).Range.Text = QtyBO; TQdet.Cell(j, 3).Range.Font.Size = 9; TQdet.Cell(j, 3).Range.Font.Bold = 0; TQdet.Cell(j, 3).Range.Font.Underline = 0;
				TQdet.Cell(j, 4).Range.Text = c3; TQdet.Cell(j, 4).Range.Font.Size = 9; TQdet.Cell(j, 4).Range.Font.Bold = 0; TQdet.Cell(j, 4).Range.Font.Underline = 0;
				TQdet.Cell(j, 5).Range.Text = c4; TQdet.Cell(j, 5).Range.Font.Size = 9; TQdet.Cell(j, 5).Range.Font.Bold = 0; TQdet.Cell(j, 5).Range.Font.Underline = 0;
			}
			else 
			{
				TQdet = app.ActiveDocument.Tables[4];
				TQdet.Rows.Add(ref MissV1);
				int j = TQdet.Rows.Count;
				//string st = (nb > 0) ? nb.ToString() + ". " : "";
				TQdet.Cell(j, 1).Range.Text = (line == "0" ? " " : line); //+ c1; TQdet.Cell(j, 1).Range.Font.Size = 9; TQdet.Cell(j, 1).Range.Font.Bold = 0; TQdet.Cell(j, 1).Range.Font.Underline = 0;
				TQdet.Cell(j, 2).Range.Text = c1; TQdet.Cell(j, 1).Range.Font.Size = 9; TQdet.Cell(j, 1).Range.Font.Bold = 0; TQdet.Cell(j, 1).Range.Font.Underline = 0;
				TQdet.Cell(j, 3).Range.Text = c2; TQdet.Cell(j, 2).Range.Font.Size = 9; TQdet.Cell(j, 2).Range.Font.Bold = 0; TQdet.Cell(j, 2).Range.Font.Underline = 0;
				//TQdet.Cell(j, 3).Range.Text = QtyBO; TQdet.Cell(j, 3).Range.Font.Size = 9; TQdet.Cell(j, 3).Range.Font.Bold = 0; TQdet.Cell(j, 3).Range.Font.Underline = 0;
				if (BorF == 'F')
				{
					TQdet.Cell(j, 4).Range.Text = c3; TQdet.Cell(j, 4).Range.Font.Size = 9; TQdet.Cell(j, 4).Range.Font.Bold = 0; TQdet.Cell(j, 4).Range.Font.Underline = 0;
					TQdet.Cell(j, 5).Range.Text = c4; TQdet.Cell(j, 5).Range.Font.Size = 9; TQdet.Cell(j, 5).Range.Font.Bold = 0; TQdet.Cell(j, 5).Range.Font.Underline = 0;
				}
			}
		}

		/*
		private void Print_Det_AcctBill(string line, string c1, string c2, string c3, string c4, string QtyBO) //'F'
		{
			Word.Table TQdet;
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content;
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);

			TQdet = app.ActiveDocument.Tables[4];
			TQdet.Rows.Add(ref MissV1);
			int j = TQdet.Rows.Count;
			//string st = (nb > 0) ? nb.ToString() + ". " : "";
			string st = "";
			TQdet.Cell(j, 1).Range.Text = line; //+ c1; TQdet.Cell(j, 1).Range.Font.Size = 9; TQdet.Cell(j, 1).Range.Font.Bold = 0; TQdet.Cell(j, 1).Range.Font.Underline = 0;
			TQdet.Cell(j, 2).Range.Text = TQdet.Cell(j, 1).Range.Font.Size = 9; TQdet.Cell(j, 1).Range.Font.Bold = 0; TQdet.Cell(j, 1).Range.Font.Underline = 0;
			TQdet.Cell(j, 3).Range.Text = c2; TQdet.Cell(j, 2).Range.Font.Size = 9; TQdet.Cell(j, 2).Range.Font.Bold = 0; TQdet.Cell(j, 2).Range.Font.Underline = 0;
			//TQdet.Cell(j, 3).Range.Text = QtyBO; TQdet.Cell(j, 3).Range.Font.Size = 9; TQdet.Cell(j, 3).Range.Font.Bold = 0; TQdet.Cell(j, 3).Range.Font.Underline = 0;
			TQdet.Cell(j, 4).Range.Text = c3; TQdet.Cell(j, 4).Range.Font.Size = 9; TQdet.Cell(j, 4).Range.Font.Bold = 0; TQdet.Cell(j, 4).Range.Font.Underline = 0;
			TQdet.Cell(j, 5).Range.Text = c4; TQdet.Cell(j, 5).Range.Font.Size = 9; TQdet.Cell(j, 5).Range.Font.Bold = 0; TQdet.Cell(j, 5).Range.Font.Underline = 0;
		}

		private void Page_OR_DetailsOLD()
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			Rng.Font.Size = 8;
			bool BO = false;
			string m2Desc = "";
			double m3Qty = 0, m7Ext = 0, m5UP = 0;
			string oldaff = "1", NewAff = "1";
			double QtyBO = 0;

			if (In_ORFrm.checkBox1.Checked)
			{
				for (int i = 0; i < In_ORFrm.lvQITEMS.Items.Count; i++)
				{
					//if (In_ORFrm.checkBox1.Checked)
					NewAff = In_ORFrm.lvQITEMS.Items[i].SubItems[1].Text;
					if (NewAff == oldaff && NewAff != " ")
					{
						if (!In_ORFrm.checkBox1.Checked)
						{
							if (!In_ORFrm.lvQITEMS.Items[i].Checked)
							{
								QtyBO += Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text);
								BO = true;
							}
						}
						m2Desc = In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text;
									
						m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text);
						m3Qty += Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text);
						m7Ext = (m5UP > 0) ? Math.Round(m5UP * m3Qty, MainMDI.Q_NB_DEC_AFF) : Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text);
					}
					else 
					{
						if (!BO) Print_Det_Summ(0, m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
						m2Desc = In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text;
						m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text);
						m3Qty = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text);
						m7Ext = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text);
						BO = false;
					}
					oldaff = NewAff;

					//if (Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "" && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != " " && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "0"))
						//Print_Det_Summ(i + 1, In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text, In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text, MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text), MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text));
				}
				Print_Det_Summ(0, m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
				Print_Det_Summ(0, "                   TOTAL", " ", " ", MainMDI.A00(In_ORFrm.LocTot.Text), " ");
			}
			else
			{
				for (int i = 0; i < In_ORFrm.lvQITEMS.SelectedItems.Count; i++)
				{
					NewAff = In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[1].Text;
					if (NewAff == oldaff && NewAff != " ")
					{
						m2Desc = In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[2].Text;
						m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[5].Text);
						m3Qty += Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[3].Text);
						m7Ext = (m5UP > 0) ? Math.Round(m5UP * m3Qty, MainMDI.Q_NB_DEC_AFF) : Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[7].Text);
					}
					else 
					{
						if (!BO) Print_Det_Summ(0, m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
						m2Desc = In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[2].Text;
						m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[5].Text);
						m3Qty = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[3].Text);
						m7Ext = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[7].Text);
						BO = false;
					}
					oldaff = NewAff;

					//if (Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "" && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != " " && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "0"))
						//Print_Det_Summ(i + 1, In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text, In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text, MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text), MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text));
				}
				Print_Det_Summ(0, m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
				Print_Det_Summ(0, "                   TOTAL", " ", " ", MainMDI.A00(In_ORFrm.LocTot.Text), " ");
			}
		}
		*/

		private void Page_OR_Details()
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			Rng.Font.Size = 8;
			bool BO = false;
			string m2Desc = "";
			double m3Qty = 0, m7Ext = 0, m5UP = 0;
			string oldaff = "1", NewAff = "1";
			double QtyBO = 0;

			if (In_ORFrm.checkBox1.Checked)
			{
				for (int i = 0; i < In_ORFrm.lvQITEMS.Items.Count; i++)
				{
					//if (In_ORFrm.checkBox1.Checked)
					NewAff = In_ORFrm.lvQITEMS.Items[i].SubItems[1].Text;
					if (NewAff == oldaff && NewAff != " ")
					{
						if (!In_ORFrm.checkBox1.Checked)
						{
							if (!In_ORFrm.lvQITEMS.Items[i].Checked)
							{
								QtyBO += Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text);
								BO = true;
							}
						}
						m2Desc = In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text;
									
						m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text);
						m3Qty += Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text);
						m7Ext = (m5UP > 0) ? Math.Round(m5UP * m3Qty, MainMDI.Q_NB_DEC_AFF) : Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text);
					}
					else 
					{
						if (!BO) Print_Det_Summ('B', "0", m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
						m2Desc = In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text;
						m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text);
						m3Qty = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text);
						m7Ext = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text);
						BO = false;
					}
					oldaff = NewAff;

					//if (Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "" && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != " " && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "0"))
						//Print_Det_Summ(i + 1, In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text, In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text, MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text), MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text));
				}
				Print_Det_Summ('B', "0", m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
				Print_Det_Summ('B', "0", "                   TOTAL", " ", " ", MainMDI.A00(In_ORFrm.LocTot.Text), " ");
			}
			else
			{
				for (int i = 0; i < In_ORFrm.lvQITEMS.SelectedItems.Count; i++)
				{
					NewAff = In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[1].Text;
					if (NewAff == oldaff && NewAff != " ")
					{
						m2Desc = In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[2].Text;
						m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[5].Text);
						m3Qty += Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[3].Text);
						m7Ext = (m5UP > 0) ? Math.Round(m5UP * m3Qty, MainMDI.Q_NB_DEC_AFF) : Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[7].Text);
					}
					else 
					{
						if (!BO) Print_Det_Summ('B', "0", m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
						m2Desc = In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[2].Text;
						m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[5].Text);
						m3Qty = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[3].Text);
						m7Ext = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[7].Text);
						BO = false;
					}
					oldaff = NewAff;

					//if (Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "" && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != " " && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "0"))
						//Print_Det_Summ(i + 1, In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text, In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text, MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text), MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text));
				}
				Print_Det_Summ('B', "0", m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
				Print_Det_Summ('B', "0", "                   TOTAL", " ", " ", MainMDI.A00(In_ORFrm.LocTot.Text), " ");
			}
		}

		private void Page_PSLIP_Details(char BorF)
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			Rng.Font.Size = 8;
			for (int i = 0; i < In_ORFrm.lvCurLot.Items.Count; i++)
			{
				string line = (In_ORFrm.lvCurLot.Items[i].SubItems[0].Text != "0") ? In_ORFrm.lvCurLot.Items[i].SubItems[0].Text : " ";
				Print_Det_Summ(BorF, line, In_ORFrm.lvCurLot.Items[i].SubItems[1].Text, In_ORFrm.lvCurLot.Items[i].SubItems[3].Text, " ", " ", " ");
			}
		}

		private void Page_BILs_Details(char BorF)
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			Rng.Font.Size = 8;
			bool BO = false;
			string m2Desc = "";
			double m3Qty = 0, m7Ext = 0, m5UP = 0, Btot = 0;
			int daff = 1;
			double QtyBO = 0;
			//@@@@@@

			//select all Invoices 
			//string stSql = " SELECT PSM_R_SBills.BilNm AS Expr1, PSM_R_SBillsDetail.*, PSM_R_SBills.Bil_LID AS Expr2 " +
				//" FROM PSM_R_SBills INNER JOIN PSM_R_SBillsDetail ON PSM_R_SBills.Bil_LID = PSM_R_SBillsDetail.b_BilLID " +
				//" WHERE     (PSM_R_SBills.b_RRevLID = " + In_ORFrm.lIRRevID.Text + ") AND (PSM_R_SBillsDetail.b_d_affID <> 0) " +
				//" ORDER BY PSM_R_SBills.b_Rnk, PSM_R_SBillsDetail.b_d_Rnk ";

			string stSql = " SELECT PSM_R_SBills.BilNm AS Expr1, PSM_R_SBillsDetail.*, PSM_R_SBills.Bil_LID AS Expr2 " +
				" FROM PSM_R_SBills INNER JOIN PSM_R_SBillsDetail ON PSM_R_SBills.Bil_LID = PSM_R_SBillsDetail.b_BilLID " +
				" WHERE     (PSM_R_SBills.b_RRevLID = " + In_ORFrm.lIRRevID.Text + ") AND (PSM_R_SBillsDetail.b_d_affID <> 0) AND (PSM_R_SBills.BilNm = '" + In_ORFrm.lcurBilNm.Text + "') " +
				" ORDER BY PSM_R_SBills.b_Rnk, PSM_R_SBillsDetail.b_d_Rnk ";

			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			bool filled = false;

			while (Oreadr.Read())
			{
				string line = " ";
				if ((BorF == 'F') && Oreadr["b_d_affID"].ToString() != "0") line = Oreadr["b_d_affID"].ToString();
				m2Desc = (BorF == 'F') ? Oreadr["b_d_ItemDesc"].ToString() : Convert.ToString(daff++) + "- " + Oreadr["b_d_ItemDesc"].ToString();
				m3Qty = Tools.Conv_Dbl(Oreadr["b_d_SQty"].ToString());
				m7Ext = Tools.Conv_Dbl(Oreadr["b_d_Tot"].ToString());
				Btot += m7Ext;
				m5UP = (m3Qty == 0) ? 0 : Math.Round(m7Ext / m3Qty, MainMDI.NB_DEC_AFF);
				Print_Det_Summ(BorF, line, m2Desc, m3Qty.ToString(), m5UP.ToString(), MainMDI.A00(m7Ext.ToString()), " ");
			}
			//if (Tools.Conv_Dbl(In_ORFrm.tFreight.Text) > 0) Print_Det_Summ(0, "Freight ", " ", " ", MainMDI.A00(In_ORFrm.tFreight.Text), " ");
			//Print_Det_Summ(0, m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
			if (BorF != 'F' && BorF != 'P')
			{
				string TF = "", TB = "";
				stSql = " SELECT SUM(FReight) AS totFrt, SUM(BilTOT) AS TotBT FROM  PSM_R_SBills " +
					" WHERE b_RRevLID = " + In_ORFrm.lIRRevID.Text + " GROUP BY Bil_LID, b_Rnk  ORDER BY b_Rnk";
				MainMDI.Find_2_Field(stSql, ref TF, ref TB);
				double d_TF = Tools.Conv_Dbl(TF);
				double NewTot = Tools.Conv_Dbl(TB) + d_TF;
				//if (Tools.Conv_Dbl(TF) > 0) Print_Det_Summ(0, "Freight ", " ", " ", MainMDI.A00(TF), " ");
				Print_Det_Summ(BorF, "0", "Freight ", " ", " ", MainMDI.A00(d_TF.ToString()), " ");
				Print_Det_Summ(BorF, "0", "                   TOTAL", " ", " ", MainMDI.A00(NewTot.ToString()), " ");
			}
		}
		
		private void Page_SH_Details()
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			Rng.Font.Size = 8;
			bool BO = false;
			string m2Desc = "";
			double m3Qty = 0, m7Ext = 0, m5UP = 0;
			string oldaff = "1", NewAff = "1";
			double QtyBO = 0;

			if (In_ORFrm.checkBox1.Checked)
			{
				for (int i = 0; i < In_ORFrm.lvQITEMS.Items.Count; i++)
				{
					//if (In_ORFrm.checkBox1.Checked)
					NewAff = In_ORFrm.lvQITEMS.Items[i].SubItems[1].Text;
					if (NewAff == oldaff && NewAff != " ")
					{
						if (!In_ORFrm.checkBox1.Checked)
						{
							if (!In_ORFrm.lvQITEMS.Items[i].Checked)
							{
								QtyBO += Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text);
								BO = true;
							}
						}
						m2Desc = In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text;
									
						m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text);
						m3Qty += Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text);
						m7Ext = (m5UP > 0) ? Math.Round(m5UP * m3Qty, MainMDI.Q_NB_DEC_AFF) : Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text);
					}
					else 
					{
						if (!BO) Print_Det_Summ('B', "0", m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
						m2Desc = In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text;
						m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text);
						m3Qty = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text);
						m7Ext = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text);
						BO = false;
					}
					oldaff = NewAff;

					//if (Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "" && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != " " && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "0"))
						//Print_Det_Summ(i + 1, In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text, In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text, MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text), MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text));
				}
				Print_Det_Summ('B', "0", m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
				Print_Det_Summ('B', "0", "                   TOTAL", " ", " ", MainMDI.A00(In_ORFrm.LocTot.Text), " ");
			}
			else
			{
				for (int i = 0; i < In_ORFrm.lvQITEMS.SelectedItems.Count; i++)
				{
					NewAff = In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[1].Text;
					if (NewAff == oldaff && NewAff != " ")
					{
						m2Desc = In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[2].Text;
						m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[5].Text);
						m3Qty += Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[3].Text);
						m7Ext = (m5UP > 0) ? Math.Round(m5UP * m3Qty, MainMDI.Q_NB_DEC_AFF) : Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[7].Text);
					}
					else 
					{
						if (!BO) Print_Det_Summ('B', "0", m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
						m2Desc = In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[2].Text;
						m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[5].Text);
						m3Qty = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[3].Text);
						m7Ext = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.SelectedItems[i].SubItems[7].Text);
						BO = false;
					}
					oldaff = NewAff;

					//if (Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "" && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != " " && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "0"))
						//Print_Det_Summ(i + 1, In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text, In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text, MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text), MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text));
				}
				Print_Det_Summ('B', "0", m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
				Print_Det_Summ('B', "0", "                   TOTAL", " ", " ", MainMDI.A00(In_ORFrm.LocTot.Text), " ");
			}
		}

		/*
		private void Page_OR_DetailsOLDN()
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			Rng.Font.Size = 8;
			bool BO = false;
			string m2Desc = "";
			double m3Qty = 0, m7Ext = 0, m5UP = 0;
			string oldaff = "1", NewAff = "1";
			double QtyBO = 0;

			for (int i = 0; i < In_ORFrm.lvQITEMS.Items.Count; i++)
			{
				//if (In_ORFrm.checkBox1.Checked)
				NewAff = In_ORFrm.lvQITEMS.Items[i].SubItems[1].Text;
				if (NewAff == oldaff && NewAff != " ")
				{
					if (!In_ORFrm.checkBox1.Checked)
					{
						if (!In_ORFrm.lvQITEMS.Items[i].Checked)
						{
							QtyBO += Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text);
							BO = true;
						}
					}
					m2Desc = In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text;
									
					m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text);
					m3Qty += Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text);
					m7Ext = (m5UP > 0) ? Math.Round(m5UP * m3Qty, MainMDI.Q_NB_DEC_AFF) : Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text);
				}
				else 
				{
					if (!BO) Print_Det_Summ(0, m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
					m2Desc = In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text;
					m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text);
					m3Qty = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text);
					m7Ext = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text);
					BO = false;
				}
				oldaff = NewAff;

				//if (Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "" && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != " " && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "0"))
					//Print_Det_Summ(i + 1, In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text, In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text, MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text), MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text));
			}
			Print_Det_Summ(0, m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
			Print_Det_Summ(0, "                   TOTAL", " ", " ", MainMDI.A00(In_ORFrm.LocTot.Text), " ");
		}
		
		private void Page_QT_Details()
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			Rng.Font.Size = 8;
			bool BO = false;
			string m2Desc = "";
			double m3Qty = 0, m7Ext = 0, m5UP = 0;
			string oldaff = "1", NewAff = "1";
			double QtyBO = 0;

			for (int i = 0; i < In_ORFrm.lvQITEMS.Items.Count; i++)
			{
				//if (In_ORFrm.checkBox1.Checked)
				{
					m2Desc = In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text;
									
					m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text);
					m3Qty += Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text);
					m7Ext = (m5UP > 0) ? Math.Round(m5UP * m3Qty, MainMDI.Q_NB_DEC_AFF) : Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text);
				}
				else 
				{
					if (!BO) Print_Det_Summ(0, m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
					m2Desc = In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text;
					m5UP = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text);
					m3Qty = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text);
					m7Ext = Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text);
					BO = false;
				}
				oldaff = NewAff;

				//if (Tools.Conv_Dbl(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "" && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != " " && In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text != "0"))
					//Print_Det_Summ(i + 1, In_ORFrm.lvQITEMS.Items[i].SubItems[2].Text, In_ORFrm.lvQITEMS.Items[i].SubItems[3].Text, MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[5].Text), MainMDI.A00(In_ORFrm.lvQITEMS.Items[i].SubItems[7].Text));
			}
			Print_Det_Summ(0, m2Desc, m3Qty.ToString(), MainMDI.A00(m5UP.ToString()), MainMDI.A00(m7Ext.ToString()), QtyBO.ToString());
			Print_Det_Summ(0, "                   TOTAL", " ", " ", MainMDI.A00(In_ORFrm.LocTot.Text), " ");
		}
		*/

		private void Page_ONELD_Details()
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			Rng.Font.Size = 8;
			bool BO = false;
			string m2Desc = "";
			double m3Qty = 0, m7Ext = 0, m5UP = 0;
			string oldaff = "1", NewAff = "1";
			double QtyBO = 0;

			for (int i = 0; i < In_ORFrm.lvCurConfig.Items.Count; i++)
			{
				//if (In_ORFrm.checkBox1.Checked)

				if (In_ORFrm.lvCurConfig.Items[i].Checked) Print_Det_Config(false, In_ORFrm.lvCurConfig.Items[i].SubItems[1].Text, In_ORFrm.lvCurConfig.Items[i].SubItems[2].Text);
			}
		}

		private void Page_Quote_Details()
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			Rng.Font.Size = 8;
			bool BO = false;
			string m2Desc = "";
			double m3Qty = 0, m7Ext = 0, m5UP = 0;
			string oldaff = "1", NewAff = "1";
			double QtyBO = 0;

			for (int i = 0; i < In_QFrm.lvQITEMS.Items.Count; i++)
			{
				//if (In_ORFrm.checkBox1.Checked)

				Print_Det_QAlias(false, In_QFrm.lvQITEMS.Items[i].SubItems[1].Text, In_QFrm.lvQITEMS.Items[i].SubItems[2].Text, In_QFrm.lvQITEMS.Items[i].SubItems[3].Text, In_QFrm.lvQITEMS.Items[i].SubItems[7].Text);
				if ((i + 1) == In_QFrm.lvQITEMS.Items.Count) Print_Det_QAlias(false, " ", " ", "Total", In_QFrm.tPxPrice.Text);
			}
		}

		//crystal report
		private void CR_ONELD_Details()
		{
			/*
			case "QID":	 
				rng.InsertAfter(In_ORFrm.lQID.Text + " / " + In_ORFrm.lSolNB.Text);
				//+ "-" + In_ORFrm.lcurRRevNm.Text);
				rng.Select();
				break;
			case "contact":	 
				rng.InsertAfter(In_ORFrm.lcontactNm.Text);
				rng.Select();
				break;
			case "cpnyName":	 
				rng.InsertAfter(In_ORFrm.lCpnyName.Text);
				rng.Select();
				break;
			case "SN":	 
				//rng.InsertAfter(In_ORFrm.lprojectNm.Text);
				rng.InsertAfter(In_ORFrm.lSn.Text);
				rng.Select();
				break;
			case "ProjID":	 
				//rng.InsertAfter("P" + In_ORFrm.LRID.Text + "-" + In_ORFrm.lcurRRevNm.Text);
				rng.InsertAfter("P" + In_ORFrm.LRID.Text);
				rng.Select();
				break;
				//case "cuRR":	 
				//rng.InsertAfter(In_ORFrm.lcurDol.Text);
				//rng.Select();
				//break;
			case "dateEntR":	 
				rng.InsertAfter(In_ORFrm.lCFdatE.Text);
				rng.Select();
				break;
			case "dlvdate":	 
				//MessageBox.Show("car: " +);
				//string stt = (In_ORFrm.RRev_Status.Text[0] == 'F') ? In_ORFrm.TPD.Text : In_ORFrm.tDlvDate.Text;
				//string stt = (In_ORFrm.RRev_Status.Text[0] == 'F') ? In_ORFrm.TPD.Text : In_ORFrm.ldpCFdlvr.Text;
				string appvd = MainMDI.Find_One_Field("SELECT Aprvd FROM  PSM_R_Detail WHERE PrimaxSN ='" + In_ORFrm.lSn.Text + "'");
				string stt = (appvd == "0") ? In_ORFrm.TPD.Text : In_ORFrm.ldpCFdlvr.Text;
				if (appvd == MainMDI.VIDE) stt = "Error Date ????";
				rng.InsertAfter(stt);
				rng.Select();
				break;
			case "CustPO":	 
				rng.InsertAfter(In_ORFrm.tCustPO.Text);
				rng.Select();

			for (int i = 0; i < In_ORFrm.lvCurConfig.Items.Count; i++)
			{
				if (In_ORFrm.lvCurConfig.Items[i].Checked) Print_Det_Config(false, In_ORFrm.lvCurConfig.Items[i].SubItems[1].Text, In_ORFrm.lvCurConfig.Items[i].SubItems[2].Text);
			}
			* 
			*/
		}
	}
}