using System;
using System.Windows.Forms;
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
	public class Order_TRPrint_FINAL
	{
		private bool newP = false;
		private Order In_RDR;
		bool SamePg = false;
		Word.Table TQdet10;
		private	Word.Application app = new Word.Application();
		private object Omiss = System.Reflection.Missing.Value;
		private object start = 0;
		private object end = 0;
		private object EOP = Word.WdBreakType.wdPageBreak;
		private const int WT_1Col = 120; //100;
		private const int WT_2Col = 360; //365;
		private const int NBOption = 20;
		private int Oldpg = 0, NEWpg = 0;
		private int O = 0;
		private string[,] arr_options = new string[NBOption, 8];
		string Tfn = ""; //Application.StartupPath;
		string Ofn = ""; //Tfn + @"\PrintedTstR.doc";

		public Order_TRPrint_FINAL(Order x_RDR)
		{
			In_RDR = x_RDR;
		}

		public bool TRexport()
		{
			//string kk = DateTime.Now.ToShortTimeString();
			Tfn = Application.StartupPath;
			Ofn = Tfn + @"\PrintedTstR.doc";
			Tfn += @"\N_TstReport.doc";
			OpenWF(Tfn, Ofn);
			Print_Head_Info_New();
			Print_IO_tst(); //MessageBox.Show("Print_IO_tst");

			//MessageBox.Show("fin IOtst debut=" + DateTime.Now.ToLongTimeString() + "   fin= " + kk);
			//kk = DateTime.Now.ToLongTimeString();
			In_RDR.pbPrintTR.Value += 100;
			In_RDR.Refresh();
			Print_Perf_tst(); //MessageBox.Show("Print_Perf_tst");
			In_RDR.pbPrintTR.Value += 100; In_RDR.Refresh();
			SamePg = false;
			//MessageBox.Show("fin Print_Perf_tst debut=" + DateTime.Now.ToLongTimeString() + "   fin= " + kk);
			//kk = DateTime.Now.ToLongTimeString();
			Print2L_EQ_AL_OT(); //MessageBox.Show("Print2L_EQ_AL_OT");
			if (In_RDR.chk_printcklst.Checked) Print_CHKLst();
			//print boards and manuals
			newP = true;
			Print_all_Boards_();
			Print_Manuals();
			Print_MI();
			//print boards and manuals
			Print_Botm_Info();
			Fermer_App(Ofn);
			//MessageBox.Show("fin Print2L_EQ_AL_OT debut=" + DateTime.Now.ToLongTimeString() + "   fin= " + kk);
			try
			{
				MainMDI.EXEC_FILE("WINWORD.EXE", Ofn);
				//System.Diagnostics.Process.Start(Ofn);
			}
			catch (System.Exception Oexp)
			{
				MessageBox.Show("Cannot execute: " + Ofn + "    System-msg: " + Oexp.Message);
			}
			return true;
		}

		public bool TRexport_EMPTY(string _Path)
		{
			Tfn = System.Environment.CurrentDirectory;
			string Fname = "TR_" + In_RDR.LRID.Text + "_" + In_RDR.TRLsn.Text;
			//Ofn = Tfn + @"\PrintedTstR.doc";
			Ofn = _Path + @"\" + Fname + ".doc";
			Tfn += @"\N_TstReport.doc";
			OpenWF(Tfn, Ofn);
			Print_Head_Info_New_EMPTY();
			Print_IO_tst_EMPTY();

			In_RDR.pbPrintTR.Value += 100;
			In_RDR.Refresh();
			Print_Perf_tst_EMPTY();
			In_RDR.pbPrintTR.Value += 100; In_RDR.Refresh();
			SamePg = false;

			Print2L_EQ_AL_OT_EMPTY();
			//if (In_RDR.chk_printcklst.Checked) Print_CHKLst();
			Print_Botm_Info();
			Fermer_App_EMPTY(Ofn);

			In_RDR.panel1.Visible = false;
			MessageBox.Show("Test Report: '" + Ofn + "' successfully Saved ...");

			//Open Word File
			/*
			try
			{
				System.Diagnostics.Process.Start(Ofn);
			}
			catch (System.Exception Oexp)
			{
				MessageBox.Show("Cannot execute: " + Ofn + "    System-msg: " + Oexp.Message);
			}
			**/
			return true;
		}

		public bool TRexport_NOpbPrintTR()
		{
			//string kk = DateTime.Now.ToShortTimeString();
			Tfn = System.Environment.CurrentDirectory;
			Ofn = Tfn + @"\PrintedTstR.doc";
			Tfn += @"\N_TstReport.doc";
			OpenWF(Tfn, Ofn);
			Print_Head_Info_New();
			Print_IO_tst(); //MessageBox.Show("Print_IO_tst");

			//MessageBox.Show("fin IOtst debut=" + DateTime.Now.ToLongTimeString() + "   fin= " + kk);
			//kk = DateTime.Now.ToLongTimeString();
				//In_RDR.pbPrintTR.Value += 100;
				//In_RDR.Refresh();
			Print_Perf_tst(); //MessageBox.Show("Print_Perf_tst");
				//In_RDR.pbPrintTR.Value += 100; In_RDR.Refresh();
			SamePg = false;
			//MessageBox.Show("fin Print_Perf_tst debut=" + DateTime.Now.ToLongTimeString() + "   fin= " + kk);
			//kk = DateTime.Now.ToLongTimeString();
			Print2L_EQ_AL_OT(); //MessageBox.Show("Print2L_EQ_AL_OT");
			if (In_RDR.chk_printcklst.Checked) Print_CHKLst();
			Print_Botm_Info();
			Fermer_App(Ofn);
			//MessageBox.Show("fin Print2L_EQ_AL_OT debut=" + DateTime.Now.ToLongTimeString() + "   fin= " + kk);
			try
			{
				System.Diagnostics.Process.Start(Ofn);
			}
			catch (System.Exception Oexp)
			{
				MessageBox.Show("Cannot execute: " + Ofn + "    System-msg: " + Oexp.Message);
			}
			return true;
		}

		private void OpenWF(string TfName, string OfName)
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
			app.Documents.Open(ref filename, ref confirmConversions, ref readOnly, ref addToRecentFiles, ref passwordDocument, 
				ref passwordTemplate, ref revert, ref writePasswordDocument, ref writePasswordTemplate, ref format, ref encoding, ref visible, 
				ref openConflictDocument, ref openAndRepair, ref documentDirection, ref xmlTRsfrm); //, ref noEncodingDialog);
			Word.Options options = app.Options;

			options.BackgroundSave = true;
			options.Overtype = true;
			options.UpdateFieldsAtPrint = true;
			options.PrintHiddenText = true;
			options.PrintFieldCodes = false; //when true it does not print Page# 

			Word.Document doc = app.ActiveDocument;
			Word.Range rng = doc.Range(ref start, ref end); //= Wbmk.Range;

			object i = 1;
			string st_cpny = "", shpto = "", st = "", stt = "";
			for (int j = 1; j < doc.Bookmarks.Count + 1; j++)
			{
				i = j;
				string Bkname = doc.Bookmarks.get_Item(ref i).Name;
				Word.Bookmark Wbmk = doc.Bookmarks.get_Item(ref i);
				rng = Wbmk.Range;
				switch (Bkname)
				{
					case "hdr1":
						stt = "Project#: " + In_RDR.LRID.Text;
						rng.InsertAfter(stt);
						rng.Font.Bold = 1;
						rng.Font.Size = 12;
						rng.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
						rng.Select();
						break;
					case "hdr2":
						stt = "S/N: " + In_RDR.TRLsn.Text;
						rng.InsertAfter(stt);
						rng.Font.Bold = 1;
						rng.Font.Size = 12;
						rng.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
						rng.Select();
						break;
				}
			}
		}

		private void Print_Head_Info_New()
		{
			WPmsg("\nCustomer: ", 'b', false);
			WPmsg(In_RDR.lCpnyName.Text, 'n', false);

			string st = (In_RDR.tcust_Model.Text != MainMDI.VIDE && In_RDR.tcust_Model.Text.Length > 2) ? 
				In_RDR.tcust_Model.Text + " (" + In_RDR.PX_Model.Text + ") " : In_RDR.PX_Model.Text;
			WPmsg("\nModel: ", 'b', false); 
			WPmsg(st, 'n', false);
			//WPmsg("     S/N: ", 'b', false); WPmsg(In_RDR.TRLsn.Text + "   ", 'n', false);
			if (In_RDR.lbrdNm.Text != "" && In_RDR.lbrdNm.Text != MainMDI.VIDE)
			{
				WPmsg("\nBoard :", 'b', false); 
				WPmsg(In_RDR.lbrdNm.Text, 'n', false);

				WPmsg("    Serial# :", 'b', false); 
				WPmsg(In_RDR.lBsn.Text, 'n', false);

				WPmsg("    BoarVer: ", 'b', false); 
				WPmsg(In_RDR.lbrdVer.Text, 'n', false);

				WPmsg("    Soft Ver: ", 'b', false); 
				WPmsg(In_RDR.lbrdSoftV.Text, 'n', false);

				WPmsg("    Connected to: ", 'b', false); 
				WPmsg(In_RDR.lConTO.Text, 'n', false);

				WPmsg("    Manual: ", 'b', false); 
				WPmsg(In_RDR.Lman.Text, 'n', false);
			}
			WPmsg("\n\n", 'n', false);
			//ll
		}

		private void Print_Head_Info_New_EMPTY()
		{
			WPmsg("\nCustomer: ", 'b', false); 
			WPmsg(In_RDR.lCpnyName.Text, 'n', false);

			string st = (In_RDR.tcust_Model.Text != MainMDI.VIDE && In_RDR.tcust_Model.Text.Length > 2) ? 
				In_RDR.tcust_Model.Text + " (" + In_RDR.PX_Model.Text + ") " : In_RDR.PX_Model.Text;
			WPmsg("\nModel: ", 'b', false); 
			WPmsg(st, 'n', false);
			//WPmsg("     S/N: ", 'b', false); WPmsg(In_RDR.TRLsn.Text + "   ", 'n', false);
			if (In_RDR.lbrdNm.Text != "" && In_RDR.lbrdNm.Text != MainMDI.VIDE)
			{
				WPmsg("\nBoard :", 'b', false); 
				WPmsg(In_RDR.lbrdNm.Text, 'n', false);

				WPmsg("    Serial# :", 'b', false); 
				WPmsg(In_RDR.lBsn.Text, 'n', false);

				WPmsg("    BoarVer: ", 'b', false); 
				WPmsg(In_RDR.lbrdVer.Text, 'n', false);

				WPmsg("    Soft Ver: ", 'b', false); 
				WPmsg(In_RDR.lbrdSoftV.Text, 'n', false);

				WPmsg("    Connected to: ", 'b', false); 
				WPmsg(In_RDR.lConTO.Text, 'n', false);

				WPmsg("    Manual: ", 'b', false); 
				WPmsg(In_RDR.Lman.Text, 'n', false);
			}
			WPmsg("\n\n", 'n', false);
			//ll
		}

		private void Print_Head_Info()
		{
			WPmsg("\nProject# :", 'b', false); 
			WPmsg(In_RDR.LRID.Text, 'n', false);

			WPmsg("\nCustomer: ", 'b', false); 
			WPmsg(In_RDR.lCpnyName.Text, 'n', false);
			string st = (In_RDR.tcust_Model.Text != MainMDI.VIDE && In_RDR.tcust_Model.Text.Length > 2) ? 
				In_RDR.tcust_Model.Text + " (" + In_RDR.PX_Model.Text + ") " : In_RDR.PX_Model.Text;
			WPmsg("\nModel: ", 'b', false); 
			WPmsg(st, 'n', false);

			WPmsg("     S/N: ", 'b', false); 
			WPmsg(In_RDR.TRLsn.Text + "   ", 'n', false);
			if (In_RDR.lbrdNm.Text != "" && In_RDR.lbrdNm.Text != MainMDI.VIDE)
			{
				WPmsg("\nBoard :", 'b', false); 
				WPmsg(In_RDR.lbrdNm.Text, 'n', false);

				WPmsg("    Serial# :", 'b', false); 
				WPmsg(In_RDR.lBsn.Text, 'n', false);

				WPmsg("    BoarVer: ", 'b', false); 
				WPmsg(In_RDR.lbrdVer.Text, 'n', false);

				WPmsg("    Soft Ver: ", 'b', false); 
				WPmsg(In_RDR.lbrdSoftV.Text, 'n', false);

				WPmsg("    Connected to: ", 'b', false); 
				WPmsg(In_RDR.lConTO.Text, 'n', false);

				WPmsg("    Manual: ", 'b', false); 
				WPmsg(In_RDR.Lman.Text, 'n', false);
			}
			WPmsg("\n\n", 'n', false);
			//ll
		}

		private void Print_IO_tst()
		{
			int nbItem = In_RDR.lvIOTest.Items.Count;
			for (int i = 0; i < nbItem; i++)
			{ 
				//if (In_FC.lvPTC.Items[i].Checked)
				
				if (i == 0)
				{
					WPmsg("\n", 'b', false);
					//WPmsg("\n", 'b', false);
					WPmsg("INPUT-OUTPUT", 'b', false);
					WPrint5Cols('N', true, "Test Name", " Required ", " Tested ", " Comments ");
					WPrint5Cols('C', (In_RDR.lvIOTest.Items[i].ImageIndex == 8), In_RDR.lvIOTest.Items[i].SubItems[1].Text, 
						In_RDR.lvIOTest.Items[i].SubItems[2].Text, In_RDR.lvIOTest.Items[i].SubItems[3].Text, 
						In_RDR.lvIOTest.Items[i].SubItems[4].Text);
				}
				else
				{
					if (newP)
					{
						WPrint5Cols('N', (In_RDR.lvIOTest.Items[i].ImageIndex == 8), In_RDR.lvIOTest.Items[i].SubItems[1].Text, 
							In_RDR.lvIOTest.Items[i].SubItems[2].Text, In_RDR.lvIOTest.Items[i].SubItems[3].Text, 
							In_RDR.lvIOTest.Items[i].SubItems[4].Text);
						newP = false;
					}
					else WPrint5Cols('C', (In_RDR.lvIOTest.Items[i].ImageIndex == 8), In_RDR.lvIOTest.Items[i].SubItems[1].Text, 
						In_RDR.lvIOTest.Items[i].SubItems[2].Text, In_RDR.lvIOTest.Items[i].SubItems[3].Text, 
						In_RDR.lvIOTest.Items[i].SubItems[4].Text);
				}	
			}
		}

		private void Print_IO_tst_EMPTY()
		{
			int nbItem = In_RDR.lvIOTest.Items.Count;
			for (int i = 0; i < nbItem; i++)
			{
				//if (In_FC.lvPTC.Items[i].Checked)

				if (i == 0)
				{
					WPmsg("\n", 'b', false);
					//WPmsg("\n", 'b', false);
					WPmsg("INPUT-OUTPUT", 'b', false);
					WPrint5Cols('N', true, "Test Name", " Required ", " Tested ", " Comments ");
					WPrint5Cols('C', (In_RDR.lvIOTest.Items[i].ImageIndex == 8), In_RDR.lvIOTest.Items[i].SubItems[1].Text, 
						In_RDR.lvIOTest.Items[i].SubItems[2].Text, In_RDR.lvIOTest.Items[i].SubItems[3].Text, 
						In_RDR.lvIOTest.Items[i].SubItems[4].Text);
				}
				else
				{
					if (newP)
					{
						WPrint5Cols('N', (In_RDR.lvIOTest.Items[i].ImageIndex == 8), In_RDR.lvIOTest.Items[i].SubItems[1].Text, 
							In_RDR.lvIOTest.Items[i].SubItems[2].Text, In_RDR.lvIOTest.Items[i].SubItems[3].Text, 
							In_RDR.lvIOTest.Items[i].SubItems[4].Text);
						newP = false;
					}
					else WPrint5Cols('C', (In_RDR.lvIOTest.Items[i].ImageIndex == 8), In_RDR.lvIOTest.Items[i].SubItems[1].Text, 
						In_RDR.lvIOTest.Items[i].SubItems[2].Text, In_RDR.lvIOTest.Items[i].SubItems[3].Text, 
						In_RDR.lvIOTest.Items[i].SubItems[4].Text);
				}
			}
		}

		private void Print_Perf_tst()
		{
			int nbItem = In_RDR.lvLTest.Items.Count;
			for (int i = 0; i < nbItem; i++)
			{		
				if (i == 0)
				{
					WPmsg("\n", 'b', false);
					WPmsg("PERFORMANCE", 'b', false);
					WPrint5Cols('N', true, "Test Name", " Required ", " Tested ", " Comments ");
					WPrint5Cols('C', (In_RDR.lvLTest.Items[i].ImageIndex == 8), In_RDR.lvLTest.Items[i].SubItems[1].Text, 
						In_RDR.lvLTest.Items[i].SubItems[2].Text, In_RDR.lvLTest.Items[i].SubItems[3].Text, 
						In_RDR.lvLTest.Items[i].SubItems[4].Text);
				}
				else
				{
					if (newP)
					{
						WPrint5Cols('N', (In_RDR.lvLTest.Items[i].ImageIndex == 8), In_RDR.lvLTest.Items[i].SubItems[1].Text, 
							In_RDR.lvLTest.Items[i].SubItems[2].Text, In_RDR.lvLTest.Items[i].SubItems[3].Text, 
							In_RDR.lvLTest.Items[i].SubItems[4].Text);
						newP = false;
					}
					else WPrint5Cols('C', (In_RDR.lvLTest.Items[i].ImageIndex == 8), In_RDR.lvLTest.Items[i].SubItems[1].Text, 
						In_RDR.lvLTest.Items[i].SubItems[2].Text, In_RDR.lvLTest.Items[i].SubItems[3].Text, 
						In_RDR.lvLTest.Items[i].SubItems[4].Text);
				}
			}
		}

		private void Print_Perf_tst_EMPTY()
		{
			int nbItem = In_RDR.lvLTest.Items.Count;
			for (int i = 0; i < nbItem; i++)
			{
				if (i == 0)
				{
					WPmsg("\n", 'b', false);
					WPmsg("PERFORMANCE", 'b', false);
					WPrint5Cols('N', true, "Test Name", " Required ", " Tested ", " Comments ");
					WPrint5Cols('C', (In_RDR.lvLTest.Items[i].ImageIndex == 8), In_RDR.lvLTest.Items[i].SubItems[1].Text, 
						In_RDR.lvLTest.Items[i].SubItems[2].Text, In_RDR.lvLTest.Items[i].SubItems[3].Text, 
						In_RDR.lvLTest.Items[i].SubItems[4].Text);
				}
				else
				{
					if (newP)
					{
						WPrint5Cols('N', (In_RDR.lvLTest.Items[i].ImageIndex == 8), In_RDR.lvLTest.Items[i].SubItems[1].Text, 
							In_RDR.lvLTest.Items[i].SubItems[2].Text, In_RDR.lvLTest.Items[i].SubItems[3].Text, 
							In_RDR.lvLTest.Items[i].SubItems[4].Text);
						newP = false;
					}
					else WPrint5Cols('C', (In_RDR.lvLTest.Items[i].ImageIndex == 8), In_RDR.lvLTest.Items[i].SubItems[1].Text, 
						In_RDR.lvLTest.Items[i].SubItems[2].Text, In_RDR.lvLTest.Items[i].SubItems[3].Text, 
						In_RDR.lvLTest.Items[i].SubItems[4].Text);
				}
			}
		}

		private void TQDET10_CR()
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content;
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			TQdet10 = Rng.Tables.Add(Rng, 1, 12, ref MissV1, ref MissV2);
			//TQdet.Range.Font.Size = 8;
			//TQdet.Range.Font.Name = "Verdana";

			Object style = "Table Grid 8";
			TQdet10.set_Style(ref style);
			TQdet10.ApplyStyleFirstColumn = false;
			TQdet10.ApplyStyleLastColumn = false;
			TQdet10.ApplyStyleLastRow = false;
			TQdet10.Columns[1].Width = 25; //25;
			TQdet10.Columns[2].Width = 240; //250;
			TQdet10.Columns[3].Width = 48; //50;
			TQdet10.Columns[4].Width = 40;
			TQdet10.Columns[5].Width = 35; //35;
			TQdet10.Columns[6].Width = 36; //45;
			TQdet10.Columns[7].Width = 35;
			TQdet10.Columns[8].Width = 40;
			TQdet10.Columns[9].Width = 30;
			TQdet10.Columns[10].Width = 30; //30;
			TQdet10.Columns[11].Width = 40;
			TQdet10.Columns[12].Width = 120; //150;
		}

		private void TBL_LST_CR(int NBCol)
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content;
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			TQdet10 = Rng.Tables.Add(Rng, 1, NBCol, ref MissV1, ref MissV2);
			//TQdet.Range.Font.Size = 8;
			//TQdet.Range.Font.Name = "Verdana";

			Object style = "Table Grid 8";
			TQdet10.set_Style(ref style);
			TQdet10.ApplyStyleFirstColumn = false;
			TQdet10.ApplyStyleLastColumn = false;
			TQdet10.ApplyStyleLastRow = false;
			if (NBCol == 12)
			{
				TQdet10.Columns[1].Width = 25;
				TQdet10.Columns[2].Width = 250;
				TQdet10.Columns[3].Width = 50;
				TQdet10.Columns[4].Width = 40;
				TQdet10.Columns[5].Width = 35;
				TQdet10.Columns[6].Width = 45;
				TQdet10.Columns[7].Width = 35;
				TQdet10.Columns[8].Width = 40;
				TQdet10.Columns[9].Width = 30;
				TQdet10.Columns[10].Width = 150;
			}
			else
			{
				TQdet10.Columns[1].Width = 25;
				TQdet10.Columns[2].Width = 500; //675;
			}
		}

		private void TBL_ChkLST_CR()
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content;
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			TQdet10 = Rng.Tables.Add(Rng, 1, 10, ref MissV1, ref MissV2);
			//TQdet.Range.Font.Size = 8;
			//TQdet.Range.Font.Name = "Verdana";

			Object style = "Table Grid 8";
			TQdet10.set_Style(ref style);
			TQdet10.ApplyStyleFirstColumn = false;
			TQdet10.ApplyStyleLastColumn = false;
			TQdet10.ApplyStyleLastRow = false;
			TQdet10.Columns[1].Width = 25;
			TQdet10.Columns[2].Width = 250;
			TQdet10.Columns[3].Width = 50;
			TQdet10.Columns[4].Width = 40;
			TQdet10.Columns[5].Width = 35;
			TQdet10.Columns[6].Width = 45;
			TQdet10.Columns[7].Width = 35;
			TQdet10.Columns[8].Width = 40;
			TQdet10.Columns[9].Width = 30;
			TQdet10.Columns[10].Width = 150;
		}

		private void Print2L_EQ_AL_OT_08042015()
		{
			/*
			int nbItem = In_RDR.MLV_EqAlrm.Items.Count;
			int vv = (nbItem > 0) ? Convert.ToInt32(Math.Round((600.00 / nbItem), 0)) : 0;

			for (int i = 0; i < nbItem; i++)
			{
				if (i == 0)
				{
					WPmsg("\n", 'b', true);
					WPmsg("EQUALIZE / ALARMS ", 'b', false);
					TQDET10_CR();
					SamePg = true;
					//WPrint10Cols('N', true, "Description (Symbol) ", "Adjust", "Delay", "Relay #", "TimeOut", "Msg Latch", "Relay Latch", "Fail Safe", " Comments ");
					 WPrint10Cols('N', true, "Description (Symbol) ", "Adjust", "Time", "Relay #", "TimeOut", "Msg Latch", "Relay Latch", "Fail Safe", " Comments ");

					//Print_HTBL10(true);
				}
				//print Requested values 
				WPrint10Cols('R', (In_RDR.MLV_EqAlrm.Items[i].ImageIndex == 8), In_RDR.MLV_EqAlrm.Items[i].SubItems[1].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[2].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[4].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[6].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[8].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[10].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[12].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[14].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[16].Text);
				//print Tested values 
				In_RDR.Refresh();
				In_RDR.panel1.Refresh();
				In_RDR.pictureBox3.Refresh();
				WPrint10Cols('T', (In_RDR.MLV_EqAlrm.Items[i].ImageIndex == 8), In_RDR.MLV_EqAlrm.Items[i].SubItems[1].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[3].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[5].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[7].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[9].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[11].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[13].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[15].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[16].Text);
				if (In_RDR.pbPrintTR.Value < 800) In_RDR.pbPrintTR.Value += (In_RDR.pbPrintTR.Value + vv < 800) ? vv : 800 - In_RDR.pbPrintTR.Value;
				In_RDR.Refresh();
				In_RDR.panel1.Refresh();
				In_RDR.pictureBox3.Refresh();
			}
			if (In_RDR.pbPrintTR.Value < 800) In_RDR.pbPrintTR.Value = 800;
			*/
		}

		private void Print2L_EQ_AL_OT()
		{
			int nbItem = In_RDR.MLV_EqAlrm.Items.Count;
			int vv = (nbItem > 0) ? Convert.ToInt32(Math.Round((600.00 / nbItem), 0)) : 0;

			for (int i = 0; i < nbItem; i++)
			{ 
				if (i == 0)
				{
					WPmsg("\n", 'b', true);
					WPmsg("EQUALIZE / ALARMS ", 'b', false);
					TQDET10_CR();
					SamePg = true;
					//WPrint10Cols('N', true, "Description (Symbol) ", "Adjust", "Delay", "Relay #", "Time Out", "Msg Latch", "Relay Latch", "Fail Safe", " Comments ");
					WPrint10Cols('N', true, "Description (Symbol) ", "Adjust", "Time", "Relay #", "Time Out", "Msg Latch", "Relay Latch", 
						"Fail Safe", "DEL #", "Del Latch", " Comments ");
	
					//Print_HTBL10(true);
				}
				//print Requested values 
				WPrint10Cols('R', (In_RDR.MLV_EqAlrm.Items[i].ImageIndex == 8), In_RDR.MLV_EqAlrm.Items[i].SubItems[1].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[2].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[4].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[6].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[8].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[10].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[12].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[14].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[16].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[18].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[20].Text);
				//print Tested values 
				In_RDR.Refresh();
				In_RDR.panel1.Refresh();
				In_RDR.pictureBox3.Refresh();
				WPrint10Cols('T', (In_RDR.MLV_EqAlrm.Items[i].ImageIndex == 8), In_RDR.MLV_EqAlrm.Items[i].SubItems[1].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[3].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[5].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[7].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[9].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[11].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[13].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[15].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[16].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[18].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[20].Text);
				if (In_RDR.pbPrintTR.Value < 800) 
					In_RDR.pbPrintTR.Value += (In_RDR.pbPrintTR.Value + vv < 800) ? vv : 800 - In_RDR.pbPrintTR.Value;
				In_RDR.Refresh();
				In_RDR.panel1.Refresh();
				In_RDR.pictureBox3.Refresh();
			}
			if (In_RDR.pbPrintTR.Value < 800) In_RDR.pbPrintTR.Value = 800;
		}

        private void Print2L_EQ_AL_OT_EMPTY()
        {
            int nbItem = In_RDR.MLV_EqAlrm.Items.Count;
            int vv = (nbItem > 0) ? Convert.ToInt32(Math.Round((600.00 / nbItem), 0)) : 0;

            for (int i = 0; i < nbItem; i++)
            {
                if (i == 0)
                {
                    WPmsg("\n", 'b', true);
                    WPmsg("EQUALIZE / ALARMS ", 'b', false);
                    TQDET10_CR();
                    SamePg = true;
                    WPrint10Cols('N', true, "Description (Symbol) ", "Adjust", "Delay", "Relay #", "Time Out", "Msg Latch", "Relay Latch", 
						"Fail Safe", "DEL #", "Del Latch", " Comments ");

                    //Print_HTBL10(true);
                }
                //print Requested values 
                WPrint10Cols('R', (In_RDR.MLV_EqAlrm.Items[i].ImageIndex == 8), In_RDR.MLV_EqAlrm.Items[i].SubItems[1].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[2].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[4].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[6].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[8].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[10].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[12].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[14].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[16].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[18].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[20].Text);
                //print Tested values 
                In_RDR.Refresh();
                In_RDR.panel1.Refresh();
                In_RDR.pictureBox3.Refresh();
                WPrint10Cols('T', (In_RDR.MLV_EqAlrm.Items[i].ImageIndex == 8), In_RDR.MLV_EqAlrm.Items[i].SubItems[1].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[3].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[5].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[7].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[9].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[11].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[13].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[15].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[16].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[18].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[20].Text);
                if (In_RDR.pbPrintTR.Value < 800) 
					In_RDR.pbPrintTR.Value += (In_RDR.pbPrintTR.Value + vv < 800) ? vv : 800 - In_RDR.pbPrintTR.Value;
                In_RDR.Refresh();
                In_RDR.panel1.Refresh();
                In_RDR.pictureBox3.Refresh();
            }
            if (In_RDR.pbPrintTR.Value < 800) In_RDR.pbPrintTR.Value = 800;
        }

        private void Print_all_Boards_()
        {
            int nbItem = In_RDR.mdl_brds.Items.Count; //####### mdl_brdsold must bCommandBehavior mdl_brds
            for (int i = 0; i < nbItem; i++)
            {
                //if (In_FC.lvPTC.Items[i].Checked)

                if (i == 0)
                {
                    WPmsg("\n", 'b', false);
                    //WPmsg("\n", 'b', false);
                    WPmsg("BOARDS LIST ", 'b', true);
                    WPrint6Cols('N', true, " Board Name ", " SN ", " Board Ver. ", " SOFT Ver. ", " Connected To ");
                    WPrint6Cols('C', true, In_RDR.mdl_brds.Items[i].SubItems[1].Text, In_RDR.mdl_brds.Items[i].SubItems[2].Text, 
						In_RDR.mdl_brds.Items[i].SubItems[3].Text, In_RDR.mdl_brds.Items[i].SubItems[4].Text, 
						In_RDR.mdl_brds.Items[i].SubItems[5].Text);
                }
                else
                {
                    if (newP)
                    {
                        WPrint6Cols('N', true, In_RDR.mdl_brds.Items[i].SubItems[1].Text, In_RDR.mdl_brds.Items[i].SubItems[2].Text, 
							In_RDR.mdl_brds.Items[i].SubItems[3].Text, In_RDR.mdl_brds.Items[i].SubItems[4].Text, 
							In_RDR.mdl_brds.Items[i].SubItems[5].Text);
						//WPrint5Cols('N', (In_RDR.lvIOTest.Items[i].ImageIndex == 8), In_RDR.lvIOTest.Items[i].SubItems[1].Text, In_RDR.lvIOTest.Items[i].SubItems[2].Text, In_RDR.lvIOTest.Items[i].SubItems[3].Text, In_RDR.lvIOTest.Items[i].SubItems[4].Text);
                        newP = false;
                    }
                    else WPrint6Cols('C', true, In_RDR.mdl_brds.Items[i].SubItems[1].Text, In_RDR.mdl_brds.Items[i].SubItems[2].Text, 
						In_RDR.mdl_brds.Items[i].SubItems[3].Text, In_RDR.mdl_brds.Items[i].SubItems[4].Text, 
						In_RDR.mdl_brds.Items[i].SubItems[5].Text);
                }
            }
        }

        private void WPrint6Cols(char cod, bool chk, string c2, string c3, string c4, string c5, string c6)
        {
            int j = 1;
            Word.Table TQdet;
            Object MissV1 = Type.Missing;
            Object MissV2 = Type.Missing;
            Word.Range Rng = app.ActiveDocument.Content;
            object direc = Word.WdCollapseDirection.wdCollapseEnd;
            Rng.Collapse(ref direc);
            //hakim
            switch (cod)
            {
                case 'N':
                    TQdet = Rng.Tables.Add(Rng, 1, 6, ref MissV1, ref MissV2);
                    //TQdet.Range.Font.Size = 8;
                    //TQdet.Range.Font.Name = "Verdana";

                    Object style = "Table Grid 8";
                    TQdet.set_Style(ref style);
                    TQdet.ApplyStyleFirstColumn = false;
                    TQdet.ApplyStyleLastColumn = false;
                    TQdet.ApplyStyleLastRow = false;
                    newP = false;
                    break;
                default:
                    TQdet = app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count];
                    TQdet.Rows.Add(ref MissV1);
                    j = TQdet.Rows.Count;
                    break;
            }
            string st = " Tested ";
            if (cod != 'N') st = (!chk) ? "□" : "√";
            TQdet.Cell(j, 1).Range.Text = st; //"   " + c1;
            TQdet.Cell(j, 2).Range.Text = c2;
            TQdet.Cell(j, 3).Range.Text = c3; //"   " + c1;
            TQdet.Cell(j, 4).Range.Text = c4;
            TQdet.Cell(j, 5).Range.Text = c5;
            TQdet.Cell(j, 6).Range.Text = c6;
            TQdet.Columns[1].Width = 42;
			//TQdet.Columns[2].Width = 200;
			//TQdet.Columns[3].Width = 80;
			//TQdet.Columns[4].Width = 80;
			//TQdet.Columns[5].Width = 250;
            int bld = 0;
            int SZ = 8;
            if (c2.IndexOf("Board Name") > -1) bld = 1; //SZ = 10;

            for (int l = 1; l < 7; l++)
            {
                TQdet.Cell(j, l).Range.Font.Bold = bld;
                TQdet.Cell(j, l).Range.Font.Name = "Microsoft Sans Serif";
                TQdet.Cell(j, l).Range.Font.Size = SZ;
                TQdet.Cell(j, l).Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;
				//if (l == 1 || l == 3 || l == 4)
				TQdet.Cell(j, l).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }
        }

        private void Print_Manuals()
        {
            int nbItem = In_RDR.mdl_sel_man.Items.Count;
            //int vv = (nbItem > 0) ? Convert.ToInt32(Math.Round((200.00 / nbItem), 0)) : 0;
           
            for (int i = 0; i < nbItem; i++)
            {
                if (i == 0)
                {
                    if (!SamePg)
                    {
                        WPmsg("\n", 'b', true);
                        WPmsg(" MANUALS LIST ", 'b', false);
                    }
                    else WPmsg("\nMANUALS  LIST ", 'b', false);
                    TBL_LST_CR(2);
                    WPrint2Cols('N', true, "Manual Name");
                }
				WPrint2Cols('C', true, In_RDR.mdl_sel_man.Items[i].SubItems[1].Text);
				//if (In_RDR.pbPrintTR.Value < 1000) In_RDR.pbPrintTR.Value += (In_RDR.pbPrintTR.Value + vv < 1000) ? vv : 1000 - In_RDR.pbPrintTR.Value;
                In_RDR.Refresh();
                In_RDR.panel1.Refresh();
                In_RDR.pictureBox3.Refresh();
            }
        }

        private void Print_MI()
        {
            int nbItem = In_RDR.mdlSELMI.Items.Count;
            //int vv = (nbItem > 0) ? Convert.ToInt32(Math.Round((200.00 / nbItem), 0)) : 0;

            for (int i = 0; i < nbItem; i++)
            {
                if (i == 0)
                {
                    if (!SamePg)
                    {
                        WPmsg("\n", 'b', true);
                        WPmsg(" Tested with Instruments ", 'b', false);
                    }
                    else WPmsg("\nTested with Instruments ", 'b', false);
                    TBL_LST_CR(2);
                    WPrint2Cols('N', true, "Instrument Name / SN ");
                }
                WPrint2Cols('C', true, In_RDR.mdlSELMI.Items[i].SubItems[1].Text);
                //if (In_RDR.pbPrintTR.Value < 1000) In_RDR.pbPrintTR.Value += (In_RDR.pbPrintTR.Value + vv < 1000) ? vv : 1000 - In_RDR.pbPrintTR.Value;
                In_RDR.Refresh();
                In_RDR.panel1.Refresh();
                In_RDR.pictureBox3.Refresh();
            }
        }

		private void Print_CHKLst()
		{
			int nbItem = In_RDR.MLV_ChkList.Items.Count;
			int vv = (nbItem > 0) ? Convert.ToInt32(Math.Round((200.00 / nbItem), 0)) : 0;
			
			for (int i = 0; i < nbItem; i++)
			{ 
				if (i == 0)
				{
					if (!SamePg)
					{
						WPmsg("\n", 'b', true);
						WPmsg("Check List ", 'b', false);
					}
					else WPmsg("\nItems Check List ", 'b', false);
					TBL_LST_CR(2);
					WP_ChkLST_Cols('N', true, "Item Description");
				}
				WP_ChkLST_Cols('D', (In_RDR.MLV_ChkList.Items[i].ImageIndex == 8), In_RDR.MLV_ChkList.Items[i].SubItems[1].Text);
				if (In_RDR.pbPrintTR.Value < 1000) 
					In_RDR.pbPrintTR.Value += (In_RDR.pbPrintTR.Value + vv < 1000) ? vv : 1000 - In_RDR.pbPrintTR.Value;
				In_RDR.Refresh();
				In_RDR.panel1.Refresh();
				In_RDR.pictureBox3.Refresh();
			}
			if (In_RDR.pbPrintTR.Value < 1000) In_RDR.pbPrintTR.Value = 1000;
		}

		private void WPrint10Cols(char cod, bool chk, string Desc, string DV, string DY, string RY, string TO, string ML, string RL, 
			string FS, string DN, string DL, string Cmnt)
		{
			Object MissV1 = Type.Missing;
			string[] ar_st = new string[13];
			if (cod != 'N') TQdet10.Rows.Add(ref MissV1);
			int j = TQdet10.Rows.Count;
			if (NewPage())
			{
				//MessageBox.Show("desc=    " + Desc);
				//WPrint10Cols('L', true, "Description (Symbol) ", "Adjust", "Delay", "Relay #", "TimeOut", "Msg Latch", "Relay Latch", "Fail Safe", " Comments ");
				Oldpg = NEWpg;
			}
			string st = "OK"; //"Tested";
			if (cod == 'R' || cod == 'N' || cod == 'L')
			{
				ar_st[1] = (cod == 'N') ? "OK" : "  ";
				ar_st[2] = Desc; //TQdet.Columns[2].Width = 100;
				ar_st[3] = (DV == "[]") ? " " : DV; //== "[]   ' ????
				ar_st[4] = (DY == "[]") ? " " : DY;
				ar_st[5] = (RY == "[]") ? " " : RY;
				ar_st[6] = (TO == "[]") ? " " : TO;
				ar_st[7] = ML;
				ar_st[8] = RL;
				ar_st[9] = FS;
				ar_st[10] = DN;
				ar_st[11] = DL;
				ar_st[12] = (cod == 'N') ? Cmnt : "";
			}
			else
			{
				ar_st[1] = (!chk) ? "□" : "√";
				ar_st[2] = Desc + " Testing "; //TQdet.Columns[2].Width = 100;
				ar_st[3] = (DV == "[]" || !chk) ? " " : DV; //== "[]   ' ????
				ar_st[4] = (DY == "[]" || !chk) ? " " : DY;
				ar_st[5] = (RY == "[]" || !chk) ? " " : RY;
				ar_st[6] = (TO == "[]" || !chk) ? " " : TO;
				ar_st[7] = (!chk) ? " " : ML;
				ar_st[8] = (!chk) ? " " : RL;
				ar_st[9] = (!chk) ? " " : FS;
				ar_st[10] = (!chk) ? " " : DN;
				ar_st[11] = (!chk) ? " " : DL;
				ar_st[12] = Cmnt;
			}
			for (int r = 1; r < 13; r++)
			{
				int bld = 0;
				int SZ = 8;
				TQdet10.Cell(j, r).Range.Text = ar_st[r];
				if (ar_st[2].IndexOf("DESC /") > -1) bld = 1;
				if (cod == 'R') TQdet10.Cell(j, r).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
				if (cod == 'T') TQdet10.Cell(j, r).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorWhite;
				TQdet10.Cell(j, r).Range.Font.Bold = bld;
				TQdet10.Cell(j, r).Range.Font.Name = "Microsoft Sans Serif";
				TQdet10.Cell(j, r).Range.Font.Size = SZ;
				TQdet10.Cell(j, r).Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;
				if (r == 2) TQdet10.Cell(j, r).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft; //.wdAlignParagraphCenter;
				else TQdet10.Cell(j, r).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
			}
		}

        /*
        private void WPrint666Cols(char cod, bool chk, string Desc, string SN, string Brd_ver, string Soft_ver, string CONto)
        {
            Object MissV1 = Type.Missing;
            string[] ar_st = new string[11];
            if (cod != 'N') TQdet10.Rows.Add(ref MissV1);
            int j = TQdet10.Rows.Count;
            if (NewPage())
            {
                //MessageBox.Show("desc=    " + Desc);
                //WPrint10Cols('L', true, "Description (Symbol) ", "Adjust", "Delay", "Relay #", "TimeOut", "Msg Latch", "Relay Latch", "Fail Safe", " Comments ");
                Oldpg = NEWpg;
            }
            string st = "OK"; //"Tested";
            if (cod == 'R' || cod == 'N' || cod == 'L')
            {
                ar_st[1] = (cod == 'N') ? "OK" : "  ";
                ar_st[2] = Desc; //TQdet.Columns[2].Width = 100;
                ar_st[3] = (DV == "[]") ? " " : DV; //== "[]   ' ????
                ar_st[4] = (DY == "[]") ? " " : DY;
                ar_st[5] = (RY == "[]") ? " " : RY;
                ar_st[6] = (TO == "[]") ? " " : TO;
                ar_st[7] = ML;
                ar_st[8] = RL;
                ar_st[9] = FS;
                ar_st[10] = (cod == 'N') ? Cmnt : "";
            }
            else
            {
                ar_st[1] = (!chk) ? "□" : "√";
                ar_st[2] = Desc + " Testing "; //TQdet.Columns[2].Width = 100;
                ar_st[3] = (DV == "[]" || !chk) ? " " : DV; //== "[]   ' ????
                ar_st[4] = (DY == "[]" || !chk) ? " " : DY;
                ar_st[5] = (RY == "[]" || !chk) ? " " : RY;
                ar_st[6] = (TO == "[]" || !chk) ? " " : TO;
                ar_st[7] = (!chk) ? " " : ML;
                ar_st[8] = (!chk) ? " " : RL;
                ar_st[9] = (!chk) ? " " : FS;
                ar_st[10] = Cmnt;
            }
            for (int r = 1; r < 11; r++)
            {
                int bld = 0;
                int SZ = 8;
                TQdet10.Cell(j, r).Range.Text = ar_st[r];
                if (ar_st[2].IndexOf("DESC /") > -1) bld = 1;
                if (cod == 'R') TQdet10.Cell(j, r).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                if (cod == 'T') TQdet10.Cell(j, r).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorWhite;
                TQdet10.Cell(j, r).Range.Font.Bold = bld;
                TQdet10.Cell(j, r).Range.Font.Name = "Microsoft Sans Serif";
                TQdet10.Cell(j, r).Range.Font.Size = SZ;
                TQdet10.Cell(j, r).Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;
                if (r == 2) TQdet10.Cell(j, r).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft; //.wdAlignParagraphCenter;
                else TQdet10.Cell(j, r).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }
        }
        */

        private void WPrint2Cols(char cod, bool chk, string Desc)
        {
            Object MissV1 = Type.Missing;
            string[] ar_st = new string[11];
            if (cod != 'N') TQdet10.Rows.Add(ref MissV1);
            int j = TQdet10.Rows.Count;
            if (NewPage())
            {
                //MessageBox.Show("desc=    " + Desc);
                //WPrint10Cols('L', true, "Description (Symbol) ", "Adjust", "Delay", "Relay #", "TimeOut", "Msg Latch", "Relay Latch", "Fail Safe", " Comments ");
                Oldpg = NEWpg;
            }
            string st = "OK";
            if (cod == 'N') ar_st[1] = "OK";
            else ar_st[1] = (!chk) ? "□" : "√";
            ar_st[2] = Desc;
            int bld = 0;
            int SZ = 8;
            for (int r = 1; r < 3; r++)
            {
                TQdet10.Cell(j, r).Range.Text = ar_st[r];
                //if (ar_st[2].IndexOf("DESC /") > -1) bld = 1;
                //if (cod == 'R') TQdet10.Cell(j, r).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
                TQdet10.Cell(j, r).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorWhite;
                TQdet10.Cell(j, r).Range.Font.Bold = bld;
                TQdet10.Cell(j, r).Range.Font.Name = "Microsoft Sans Serif";
                TQdet10.Cell(j, r).Range.Font.Size = SZ;
                TQdet10.Cell(j, r).Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;
                if (r == 2) TQdet10.Cell(j, r).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft; //.wdAlignParagraphCenter;
                else TQdet10.Cell(j, r).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
            }
        }

		private void WP_ChkLST_Cols(char cod, bool chk, string Desc)
		{
			Object MissV1 = Type.Missing;
			string[] ar_st = new string[11];
			if (cod != 'N') TQdet10.Rows.Add(ref MissV1);
			int j = TQdet10.Rows.Count;
			if (NewPage())
			{
				//MessageBox.Show("desc=    " + Desc);
				//WPrint10Cols('L', true, "Description (Symbol) ", "Adjust", "Delay", "Relay #", "TimeOut", "Msg Latch", "Relay Latch", "Fail Safe", " Comments ");
				Oldpg = NEWpg;
			}
			string st = "OK";
			if (cod == 'N')	ar_st[1] = "OK";
			else ar_st[1] = (!chk) ? "□" : "√";
			ar_st[2] = Desc;
			int bld = 0;
			int SZ = 8;
			for (int r = 1; r < 3; r++)
			{
				TQdet10.Cell(j, r).Range.Text = ar_st[r];
				//if (ar_st[2].IndexOf("DESC /") > -1) bld = 1;
				//if (cod == 'R') TQdet10.Cell(j, r).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
				TQdet10.Cell(j, r).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorWhite;
				TQdet10.Cell(j, r).Range.Font.Bold = bld;
				TQdet10.Cell(j, r).Range.Font.Name = "Microsoft Sans Serif";
				TQdet10.Cell(j, r).Range.Font.Size = SZ;
				TQdet10.Cell(j, r).Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;
				if (r == 2) TQdet10.Cell(j, r).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft; //.wdAlignParagraphCenter;
				else TQdet10.Cell(j, r).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
			}
		}		

		private void Print_Botm_Info()
		{
			WPmsg("\n", 'n', false);

			WPmsg("\nComments: ", 'b', false); 
			WPmsg(In_RDR.TRcmnt.Text, 'n', false);

			WPmsg("\n\nTested by: ", 'b', false); 
			WPmsg(In_RDR.tTRuser.Text, 'n', false);

			WPmsg("\nDate: ", 'b', false); 
			WPmsg(In_RDR.lTRdate.Text, 'n', false);
			//WPmsg("\n\n", 'n', false);
			//
		}

		private void Fermer_App(string OfName)
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
			try
			{
				app.ActiveDocument.SaveAs(ref fn, ref ff, ref lc, ref pwd, ref atr, ref wpwd, ref ron, ref embd, ref svN, ref svF, ref svLett, 
					ref enc, ref inLin, ref Asub, ref Linend, ref addmrk);
				object sv = Type.Missing;
				object of = Type.Missing;
				object rd = Type.Missing;
				app.ActiveDocument.Close(ref sv, ref of, ref rd);
				app.Quit(ref sv, ref of, ref rd);
			}
			catch (System.Exception Oexp)
			{
				MessageBox.Show("Cannot Open Word file: " + Ofn + "    System-msg: " + Oexp.Message);
			}
		}

        private void Fermer_App_EMPTY(string OfName)
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
            try
            {
                app.ActiveDocument.SaveAs(ref fn, ref ff, ref lc, ref pwd, ref atr, ref wpwd, ref ron, ref embd, ref svN, ref svF, ref svLett, 
					ref enc, ref inLin, ref Asub, ref Linend, ref addmrk);
                object sv = Type.Missing;
                object of = Type.Missing;
                object rd = Type.Missing;
                app.ActiveDocument.Close(ref sv, ref of, ref rd);
                app.Quit(ref sv, ref of, ref rd);
            }
            catch (System.Exception Oexp)
            {
                MessageBox.Show("Cannot Save/Close Word file: " + Ofn + "    System-msg: " + Oexp.Message);
            }
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
			app.ActiveDocument.SaveAs(ref fn, ref ff, ref lc, ref pwd, ref atr, ref wpwd, ref ron, ref embd, ref svN, ref svF, ref svLett, 
				ref enc, ref inLin, ref Asub, ref Linend, ref addmrk);
		}

		internal void PrintOutDoc()
		{ 
			object myTrue = true;
			object myFalse = false;
			object missingValue = Type.Missing;
			object range = Word.WdPrintOutRange.wdPrintAllDocument; //.wdPrintCurrentPage;
			object items = Word.WdPrintOutItem.wdPrintDocumentContent;
			object copies = "1";
			object pages = "14";
			object pageType = Word.WdPrintOutPages.wdPrintAllPages;

			//MessageBox.Show("Prt= " + app.ActivePrinter);
			//PrintDialog pd = new PrintDialog();

			string OldPrn= app.ActivePrinter;
			//if (in_docType == 'L') app.ActivePrinter = in_prtNme; //change PRTName if printing LABEL

			//printLABELS
			Save_Doc();
			app.ActiveDocument.PrintOut(ref myTrue, ref myFalse, ref range, ref missingValue, ref missingValue, ref missingValue, ref items, 
				ref copies, ref pages, ref pageType, ref myFalse, ref myTrue, ref missingValue, ref myFalse, ref missingValue, 
				ref missingValue, ref missingValue, ref missingValue);

			object doNotSaveChanges = Word.WdSaveOptions.wdDoNotSaveChanges;
			app.ActiveDocument.Close(ref doNotSaveChanges, ref missingValue, ref missingValue);
			app.ActivePrinter = OldPrn;
			app.Quit(ref doNotSaveChanges, ref missingValue, ref missingValue);
		}

		private void Insert_page(int nPage)
		{
			//Word.Paragraph Opara;

			//Word.Range Rng = app.ActiveDocument.Range(ref start, ref end);
			
			//Rng.InsertBefore("HHHHHHHHHHH..");
			//Rng.Font.Size = 16;
		}

		private void Print_HTBL10(bool pg)
		{
			WPmsg("\n", 'b', pg);
			WPmsg("EQUALIZE / ALARMS ", 'b', false);
			WPrint10Cols('N', true, "Description (Symbol) ", "Adjust", "Delay", "Relay #", "Time Out", "Msg Latch", "Relay Latch", 
				"Fail Safe", "DEL #", "DEL Latch", " Comments ");
		}

		private bool NewPage()
		{
			Object MissV1 = Type.Missing;
			Word.WdStatistic stat = Word.WdStatistic.wdStatisticPages;
			NEWpg = app.ActiveDocument.ComputeStatistics(stat, ref MissV1);
			if (Oldpg == 0) Oldpg = NEWpg;
			return (NEWpg > Oldpg);
		}

		private void Print_EQ_AL_OT()
		{
			int nbItem = In_RDR.MLV_EqAlrm.Items.Count;
			for (int i = 0; i < nbItem; i++)
			{ 
				char Op = 'C';				
				if (i == 0)
				{
					WPmsg("\n", 'b', true);
					WPmsg("EQUALIZE / ALARMS ", 'b', false);
					WPrint17Cols('N', true, "Desc / Symbol", "Adjust", "TST", "Delay", "TST", "Relay#", "TST", "TM Out", "TST", "Msg LCH", 
						"TST", "Relay LCH", "TST", "Fail SF", "TST", " Comments ");
					//WPrint17Cols('C', (In_RDR.lvLTest.Items[i].ImageIndex == 8), In_RDR.lvLTest.Items[i].SubItems[1].Text, In_RDR.lvLTest.Items[i].SubItems[2].Text, In_RDR.lvLTest.Items[i].SubItems[3].Text, In_RDR.lvLTest.Items[i].SubItems[4].Text);
				}
				else if (newP) 
				{ 
					Op = 'N'; 
					newP = false; 
				}
				WPrint17Cols(Op, (In_RDR.MLV_EqAlrm.Items[i].ImageIndex == 8), In_RDR.MLV_EqAlrm.Items[i].SubItems[1].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[2].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[3].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[4].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[5].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[6].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[7].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[8].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[9].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[10].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[11].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[12].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[13].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[14].Text, In_RDR.MLV_EqAlrm.Items[i].SubItems[15].Text, 
					In_RDR.MLV_EqAlrm.Items[i].SubItems[16].Text);
			}
		}			
					
		private void WPrint17Cols(char cod, bool chk, string Desc, string DV, string tDV, string DY, string tDY, string RY, string tRY, 
			string TO, string tTO, string ML, string tML, string RL, string tRL, string FS, string tFS, string Cmnt)
		{
			int j = 1;
			Word.Table TQdet;
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content;
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);

			switch (cod)
			{
				case 'N':
					TQdet = Rng.Tables.Add(Rng, 1, 16, ref MissV1, ref MissV2);
					//TQdet.Range.Font.Size = 8;
					//TQdet.Range.Font.Name = "Verdana";

					Object style = "Table Grid 8";
					TQdet.set_Style(ref style);
					TQdet.ApplyStyleFirstColumn = false;
					TQdet.ApplyStyleLastColumn = false;
					TQdet.ApplyStyleLastRow = false;
					newP = false;
					break;
				default:
					TQdet = app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count];
					TQdet.Rows.Add(ref MissV1);
					j = TQdet.Rows.Count;
					break;
			}
			//object styleName = "Table Grid 8";
			//ThisDocument.Tables[1].Range.Font.Size = 8;
			//MessageBox.Show("brdr: " + TQdet.Columns[0].Borders.OutsideLineStyle.ToString());
			//string st = " Tested ";
			string st = "Tested";
			if (cod != 'N') st = (!chk) ? "□" : "√";
			TQdet.Cell(j, 1).Range.Text = st; //"   " + c1;
			TQdet.Cell(j, 2).Range.Text = Desc; TQdet.Columns[2].Width = 100;
			//if (DY == "[] ") MessageBox.Show("Hiii");
			TQdet.Cell(j, 3).Range.Text = (DV == "[] ") ? " " : DV;
			TQdet.Cell(j, 4).Range.Text = (tDV == "[]" || !chk) ? " " : tDV; //"   " + c1;
			TQdet.Cell(j, 5).Range.Text = (DY == "[] ") ? " " : DY;
			TQdet.Cell(j, 6).Range.Text = (tDY == "[]" || !chk) ? " " : tDY;
			TQdet.Cell(j, 7).Range.Text = (RY == "[] ") ? " " : RY;
			TQdet.Cell(j, 8).Range.Text = (tRY == "[]" || !chk) ? " " : tRY;
			TQdet.Cell(j, 9).Range.Text = (TO == "[] ") ? " " : TO;
			TQdet.Cell(j, 10).Range.Text = (tTO == "[]" || !chk) ? " " : tTO;
			TQdet.Cell(j, 11).Range.Text = ML;
			TQdet.Cell(j, 12).Range.Text = (!chk) ? " " : tML;
			TQdet.Cell(j, 13).Range.Text = RL;
			TQdet.Cell(j, 14).Range.Text = (!chk) ? " " : tRL;
			TQdet.Cell(j, 15).Range.Text = FS;
			TQdet.Cell(j, 16).Range.Text = (!chk) ? " " : tFS; //TQdet.Columns[16].Width = 20;
			//TQdet.Columns[17].Width = 0; //TQdet.Cell(j, 17).Range.Text = "";
			//Cmnt;

			//TQdet.Columns[1].Width = 53;
			//TQdet.Columns[2].Width = 200;
			//TQdet.Columns[3].Width = 80;
			//TQdet.Columns[4].Width = 80;
			//TQdet.Columns[5].Width = 250;
			int bld = 0;
			int SZ = 8;
			if (Desc.IndexOf("DESC /") > -1) bld = 1; //SZ = 10;

			for (int l = 1; l < 17; l++)
			{
				TQdet.Cell(j, l).Range.Font.Bold = bld;
				TQdet.Cell(j, l).Range.Font.Name = "Microsoft Sans Serif";
				TQdet.Cell(j, l).Range.Font.Size = SZ;
				TQdet.Cell(j, l).Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;
				if (l == 2) TQdet.Cell(j, l).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft; //.wdAlignParagraphCenter;
				else TQdet.Cell(j, l).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;

				//TQdet.Cell(j, l).Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
			}
			//TQdet.Cell(j, 3).Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;
		}

		private void WPrint5Cols(char cod, bool chk, string c2, string c3, string c4, string c5)
		{
			int j = 1;
			Word.Table TQdet;
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content;
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			//hakim
			switch (cod)
			{
				case 'N':
					TQdet = Rng.Tables.Add(Rng, 1, 5, ref MissV1, ref MissV2);
					//TQdet.Range.Font.Size = 8;
					//TQdet.Range.Font.Name = "Verdana";

					Object style = "Table Grid 8";
					TQdet.set_Style(ref style);
					TQdet.ApplyStyleFirstColumn = false;
					TQdet.ApplyStyleLastColumn = false;
					TQdet.ApplyStyleLastRow = false;
					newP = false;
					break;
				default:
					TQdet = app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count];
					TQdet.Rows.Add(ref MissV1);
					j = TQdet.Rows.Count;
					break;
			}
			string st = " Tested ";
			if (cod != 'N') st = (!chk) ? "□" : "√";
			TQdet.Cell(j, 1).Range.Text = st; //"   " + c1;
			TQdet.Cell(j, 2).Range.Text = c2;
			TQdet.Cell(j, 3).Range.Text = c3; //"   " + c1;
			TQdet.Cell(j, 4).Range.Text = (!chk) ? " " : c4;
			if (cod == 'C') TQdet.Cell(j, 4).Range.Shading.BackgroundPatternColor = Word.WdColor.wdColorGray25;
			TQdet.Cell(j, 5).Range.Text = c5;
			TQdet.Columns[1].Width = 53;
			TQdet.Columns[2].Width = 200;
			TQdet.Columns[3].Width = 80;
			TQdet.Columns[4].Width = 80;
			TQdet.Columns[5].Width = 250;
			int bld = 0;
			int SZ = 8;
			if (c2.IndexOf("Test Name") > -1) bld = 1; //SZ = 10;

			for (int l = 1; l < 6; l++)
			{
				TQdet.Cell(j, l).Range.Font.Bold = bld;
				TQdet.Cell(j, l).Range.Font.Name = "Microsoft Sans Serif";
				TQdet.Cell(j, l).Range.Font.Size = SZ;
				TQdet.Cell(j, l).Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;
				if (l == 1 || l == 3 || l == 4) 
					TQdet.Cell(j, l).Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
			}
		}

		/*
		private void Print_IO_tst_LV()
		{
			//string stSql = "SELECT PSM_Q_SOL.I_Quoteid, PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name, PSM_Q_ALS.ALS_Name, PSM_Q_Details.* " + 
				//" FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
				//" WHERE (((PSM_Q_SOL.I_Quoteid)=" + IQID + ") AND ((PSM_Q_SOL.Sol_Name)=" + SolName + ")) " +
				//" ORDER BY PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";

			WPmsg(" \n", 'B', true);
			string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* " +
				" FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
				" WHERE (PSM_Q_IGen.i_Quoteid=" + IQID + " and PSM_Q_SOL.Sol_Name='" + SolName + "') ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
			
			app.ActiveDocument.Content.Font.Name = "Arial";
			SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			string Nsol = "", Ospc = "", Nspc = "", Nals = "", Oals = "";
			char tbl = 'C';
			while (Oreadr.Read())
			{
				//alsAdded = false;
				if (Oreadr["Desc"].ToString()[0] != '_')
				{
					if (Nsol == "") Nsol = Oreadr["Sol_Name"].ToString();
					Nspc = Oreadr["SPC_Name"].ToString();
					Nals = Oreadr["ALS_Name"].ToString();
					if (Ospc != Nspc) 
					{ 
						if (Nspc[0] != '!') WPmsg(Nspc + "\n", 'B', false);
						Ospc = Nspc;
						tbl = 'N';
					} 
					if (Oals != Nals)
					{
						if (Nals[0] != '!') WPmsg("\n" + Nals + " ", 'b', false);
						//else WPmsg(" ", 'b', false);
						Oals = Nals;
						WPmsg(MainMDI.arr_EFSdict[36, MainMDI.Lang] + ": \n", 'r', false);
						tbl = 'N';
					}
					//debut detail
					string qty = (Oreadr["Qty"].ToString() != "0" && Oreadr["Qty"].ToString() != " " && Oreadr["Qty"].ToString() != "") ? Oreadr["Qty"].ToString() + " x " : "";

					if (Oreadr["Xch_Mult"].ToString() == "1")
					{
						if (Oreadr["Aff_ID"].ToString() == " ")
						{
							int iPos = Oreadr["Desc"].ToString().IndexOf("= ", 0);

							if (iPos > 0) WPrint2Col(tbl, qty + Oreadr["Desc"].ToString().Substring(0, iPos) + ": ", Oreadr["Desc"].ToString().Substring(iPos + 2, Oreadr["Desc"].ToString().Length - iPos - 2), WT_1Col, WT_2Col);
							else WPrint2Col(tbl, " ", qty + Oreadr["Desc"].ToString(), WT_1Col, WT_2Col);
							tbl = 'C';
						}
						else 
						{ 
							if (Oreadr["Aff_ID"].ToString() == ".")
							{
								int iPos = Oreadr["Desc"].ToString().IndexOf("= ", 0);
								if (iPos > 0)
								{
									arr_options[0, 0] = Oreadr["Aff_ID"].ToString();
									arr_options[0, 1] = qty + Oreadr["Desc"].ToString().Substring(0, iPos) + ": ";
									//, Oreadr["Desc"].ToString().Substring(iPos + 2, Oreadr["Desc"].ToString().Length - iPos - 2));
								}
								else
								{
									arr_options[O, 0] = Oreadr["Aff_ID"].ToString();
									arr_options[O, 1] = qty + Oreadr["Desc"].ToString();
									arr_options[O, 2] = Oreadr["Qty"].ToString();
									arr_options[O, 3] = Oreadr["Xch_Mult"].ToString();
									arr_options[O, 4] = Oreadr["Uprice"].ToString();
									arr_options[O, 5] = Oreadr["LeadTime"].ToString();
									O++;
								}
							}
							else
							{
								WPmsg("\n" + Oreadr["Aff_ID"].ToString() + ") " + qty + Oreadr["Desc"].ToString() + ": \n", 'b', false);
								tbl = 'N';
							}
						}
					}
					else O = -1;
				}
			}
			if (O >= 1)
			{
				WPmsg(arr_options[0, 1].ToString(), 'b', false);
				//WPrint2Col('C', arr_options[0, 1].ToString(), " ");
				tbl = 'N';
				for (int t = 1; t < O; t++) { WPrint2Col(tbl, " ", arr_options[t, 1].ToString(), WT_1Col, WT_2Col); tbl = 'C'; }
			}
		}
		*/

		private void WPmsg(string msg, char bold, bool Npage)
		{
			Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			if (Npage) 
			{ 
				Rng.InsertBreak(ref EOP); 
				newP = true; 
			}
			Rng.Text = msg;
			int SZ = 8;
			int bld = 0;
			if (bold == 'B') SZ = 10;
			if (bold == 'b' || bold == 'B') bld = 1;
			Rng.Font.Name = "Microsoft Sans Serif";
			Rng.Font.Size = SZ;
			Rng.Font.Bold = bld;
			Rng.Font.Underline = Word.WdUnderline.wdUnderlineNone;
			//if (f == 'P') Rng.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
		}

		/*
		private void Page_Q_Details(int nbL)
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			Rng.InsertBreak(ref EOP);
			
			Rng.InsertAfter(MainMDI.arr_EFSdict[36, MainMDI.Lang] + ": \n");
			Rng.Font.Size = 8;
			//int nbL = In_QFrm.lvQITEMS.Items.Count;
			Word.Table TQdet = Rng.Tables.Add(Rng, nbL, 2, ref MissV1, ref MissV2);
			int j = 1;

			for (int i = 0; i < In_QFrm.lvQITEMS.Items.Count; i++)
			{
				//MessageBox.Show("2=" + TQdet.Cell(j, 2).Width);

				if (In_QFrm.lvQITEMS.Items[i].SubItems[2].Text[0] != '_' && (In_QFrm.lvQITEMS.Items[i].Checked || In_QFrm.chkPrintALL.Checked))
				{
					//MessageBox.Show(In_QFrm.lvQITEMS.Items[i].SubItems[0].Text + "\n" + In_QFrm.lvQITEMS.Items[i].SubItems[0].Text);
					string st0 = (In_QFrm.lvQITEMS.Items[i].SubItems[1].Text == "") ? " " : In_QFrm.lvQITEMS.Items[i].SubItems[1].Text;
					string st1 = (In_QFrm.lvQITEMS.Items[i].SubItems[2].Text == "") ? " " : In_QFrm.lvQITEMS.Items[i].SubItems[2].Text;				
					if (st0 != " ")
					{ 
						TQdet.Cell(j, 1).Range.Font.Bold = 1; TQdet.Cell(j, 1).Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
						TQdet.Cell(j, 2).Range.Font.Bold = 1; TQdet.Cell(j, 2).Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
					}
					else st1 = "   " + st1;
					string qty=In_QFrm.lvQITEMS.Items[i].SubItems[3].Text + " x ";
					TQdet.Cell(j, 1).Range.Text = qty + st0;
					TQdet.Cell(j, 2).Range.Text = st1;
					//TQdet.Cell(j, 1).Width = WT_1Col;
					TQdet.Cell(j, 1).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft;
					//TQdet.Cell(j, 2).Width = WT_2Col;
					TQdet.Cell(j, 2).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft;
					//TQdet.Cell(j, 2).Width = 450;
					//TQdet.Cell(j, 2).Width;
					j++;
				}
			}
			TQdet.Select();

			//int nbL = In_QFrm.lvQITEMS.Items.Count;
			//for (int i = 0; i < nbL; i++) if (In_QFrm.lvQITEMS.Items[i].Checked) printLine_W(i);
		}

		private void Print_ALS_Detail(int nbL)
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			Rng.InsertBreak(ref EOP);
			
			Rng.InsertAfter(MainMDI.arr_EFSdict[36, MainMDI.Lang] + ": \n");
			Rng.Font.Size = 8;
			//int nbL = In_QFrm.lvQITEMS.Items.Count;
			Word.Table TQdet = Rng.Tables.Add(Rng, nbL, 2, ref MissV1, ref MissV2);
			int j = 1;

			for (int i = 0; i < In_QFrm.lvQITEMS.Items.Count; i++)
			{
				//MessageBox.Show("2=" + TQdet.Cell(j, 2).Width);

				if (In_QFrm.lvQITEMS.Items[i].Checked || In_QFrm.chkPrintALL.Checked)
				{
					//MessageBox.Show(In_QFrm.lvQITEMS.Items[i].SubItems[0].Text + "\n" + In_QFrm.lvQITEMS.Items[i].SubItems[0].Text);
					string st0 = (In_QFrm.lvQITEMS.Items[i].SubItems[1].Text == "") ? " " : In_QFrm.lvQITEMS.Items[i].SubItems[1].Text;
					string st1 = (In_QFrm.lvQITEMS.Items[i].SubItems[2].Text == "") ? " " : In_QFrm.lvQITEMS.Items[i].SubItems[2].Text;				
					if (st0 != " ")
					{ 
						TQdet.Cell(j, 1).Range.Font.Bold = 1; TQdet.Cell(j, 1).Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
						TQdet.Cell(j, 2).Range.Font.Bold = 1; TQdet.Cell(j, 2).Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
					}
					else st1 = "   " + st1;
					TQdet.Cell(j, 1).Range.Text = st0;
					TQdet.Cell(j, 2).Range.Text = st1;
					//TQdet.Cell(j, 1).Width = WT_1Col;
					TQdet.Cell(j, 1).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft;
	
					//TQdet.Cell(j, 2).Width = WT_2Col;
					TQdet.Cell(j, 2).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft;
					//TQdet.Cell(j, 2).Width = 450;
					//TQdet.Cell(j, 2).Width;
					j++;
				}
			}
			TQdet.Select();

			//int nbL = In_QFrm.lvQITEMS.Items.Count;
			//for (int i = 0; i < nbL; i++) if (In_QFrm.lvQITEMS.Items[i].Checked) printLine_W(i);
		}
		*/

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
			app.ActiveDocument.SaveAs(ref fn, ref ff, ref lc, ref pwd, ref atr, ref wpwd, ref ron, ref embd, ref svN, ref svF, ref svLett, 
				ref enc, ref inLin, ref Asub, ref Linend, ref addmrk);
			object sv = Type.Missing;
			object of = Type.Missing;
			object rd = Type.Missing;
			app.ActiveDocument.Close(ref sv, ref of, ref rd);
			app.Quit(ref sv, ref of, ref rd);
		}
	}
}