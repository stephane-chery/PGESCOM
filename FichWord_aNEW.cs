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
	public class FichWord_aNEW
	{
		private bool newP = false;
		private Quote_NEW In_QFrm;
		private Word.Application app = new Word.Application();
		private object Omiss = System.Reflection.Missing.Value;
		private object start = 0;
		private object end = 0;
		private FichWord_Config In_FC;
		private object EOP = Word.WdBreakType.wdPageBreak;
		private const int WT_1Col = 120; //100;
		private const int WT_2Col = 360; //365;
		private const int NBOption = 100;
		private int O = 0;
		private string[,] arr_options = new string[NBOption, 8];

		public FichWord_aNEW(Quote_NEW x_Qfrm, FichWord_Config x_FWConfig)
		{
			In_QFrm = x_Qfrm;

			//MessageBox.Show("QID= " + In_QFrm.tQuoteID.Text);
			In_FC = x_FWConfig;
		}

		public bool Wexport()
		{
			//string Tfn = Application.StartupPath + @"\QuoteEnglish.doc";
			//string Ofn = Application.StartupPath + @"\Q" + In_QFrm.tQuoteID.Text + ".doc";
			string Tfn = Application.StartupPath;
			string stRev = In_QFrm.lCurSoln.Text.Substring(2, In_QFrm.lCurSoln.Text.Length - 2) + "-";
			//string Ofn = @"H:\Sales\PSM_Quotes" + @"\Q" + In_QFrm.tQuoteID.Text + stRev + In_QFrm.lCpnyName.Text + ".doc";
			string Ofn = @MainMDI.WQfiles + @"\Q" + In_QFrm.tQuoteID.Text + stRev + In_QFrm.lCpnyName.Text.Replace("/", " ") + ".doc";
			Tfn += (MainMDI.Lang == 0) ? @"\QuoteEnglish.doc" : @"\QuoteFrench.doc";
			//In_QFrm.lblWait.Text = "Wait, exporting To:" + Ofn;
			//In_QFrm.grpPB.Refresh();
			OpenWF(Tfn, Ofn);
			In_QFrm.pbPrintQt.Value = 100;
			int nbLines= (In_QFrm.chkPrintALL.Checked) ? In_QFrm.lvQITEMS.Items.Count : In_QFrm.lvQITEMS.CheckedItems.Count;
			//int nbLines = In_QFrm.lvQITEMS.Items.Count;
			if (In_FC.chkComptxt.Checked) Page_CompRep();
			In_QFrm.pbPrintQt.Value += 100;
			Print_Rev();
			In_QFrm.pbPrintQt.Value += 600;
			Page_Terms();
			In_QFrm.pbPrintQt.Value += 100;
			Fermer_App(Ofn);
			In_QFrm.pbPrintQt.Value = 1000;
			In_QFrm.lblWait.Text = " WordFile Completed "; //+ Ofn;
			In_QFrm.lOFName.Text = Ofn;
			In_QFrm.button5.Visible = true;
			In_QFrm.button6.Visible = true;
			In_QFrm.grpPB.Refresh();

			return true;
		}

		private void Insert_page(int nPage)
		{
			//Word.Paragraph Opara;

			//Word.Range Rng = app.ActiveDocument.Range(ref start, ref end);
			
			//Rng.InsertBefore("HHHHHHHHHHH..");
			//Rng.Font.Size = 16;
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
			options.PrintFieldCodes = true;

			Word.Document doc = app.ActiveDocument;
			Word.Range rng = doc.Range(ref start, ref end); //= Wbmk.Range;
			object i = 1;
			for (int j = 1; j < doc.Bookmarks.Count + 1; j++)
			{
				i = j;
				string Bkname = doc.Bookmarks.get_Item(ref i).Name;
				Word.Bookmark Wbmk = doc.Bookmarks.get_Item(ref i);
				rng = Wbmk.Range;
				switch (Bkname)
				{
					case "Fax":	 
						//rng.InsertAfter(In_QFrm.lFax.Text);
						rng.InsertAfter(In_QFrm.lConFax.Text);
						rng.Select();
						break;
					case "contactName":	 
						rng.InsertAfter(In_QFrm.lPrfx.Text + "  " + In_QFrm.cbContacts.Text);
						rng.Select();
						break;
					case "CompanyName":	 
						rng.InsertAfter(In_QFrm.lCpnyName.Text);
						rng.Select();
						break;
					case "Phone":	 
						//rng.InsertAfter(In_QFrm.lPhone.Text);
						rng.InsertAfter(In_QFrm.lConTel.Text);
						rng.Select();
						break;
					case "Ext":	 
						//string ext = (In_QFrm.lConExt.Text == "") ? "" : ", Ext:" + In_QFrm.lConExt.Text;
						string ext = (In_QFrm.lConExt.Text == "") ? "" : ", " + MainMDI.arr_EFSdict[37, MainMDI.Lang] + ": " + 
							In_QFrm.lConExt.Text;
						rng.InsertAfter(ext);
						rng.Select();
						break;
					case "ProjName":	 
						rng.InsertAfter(In_QFrm.tProjNAME.Text);
						rng.Select();
						break;
					case "WQID":	 
						rng.InsertAfter(In_QFrm.tQuoteID.Text + "-" + In_QFrm.lCurSoln.Text.Substring(3, In_QFrm.lCurSoln.Text.Length - 3));
						rng.Select();
						break;
					case "submitxt":
						string fultxt = (In_FC.checkBox1.Checked) ? In_FC.tsubmit.Text : "";
						fultxt += (In_FC.checkBox2.Checked) ? "\n" + In_FC.tothers.Text : "";
						//rng.InsertAfter(fultxt + "\n");
						rng.InsertAfter(fultxt);
						rng.Select();
						break;
					case "EmpExt":	
						string tt = (In_QFrm.lEExt.Text == "") ? "" : MainMDI.arr_EFSdict[37, MainMDI.Lang] + ": " + In_QFrm.lEExt.Text;
						rng.InsertAfter(tt);
						rng.Select();
						break;
					case "EmplName":	 
						rng.InsertAfter(In_QFrm.cbEmploy.Text); //+ " " + In_QFrm.lEmpSFX.Text);
						rng.Select();
						break;
					case "DateNow":	 
						rng.InsertAfter(In_QFrm.tOpendate.Text);
                        //rng.InsertAfter(In_FC.tCQRdate.value.ToShortDateString());
                        rng.InsertAfter(In_FC.tCQRdate.Text);
						rng.Select();
						break;
					//case "PageNb":	 
						//rng.InsertAfter("4");
						//rng.Select();
						//break;
					case "DearContactNm":	 
						rng.InsertAfter(In_QFrm.lPrfx.Text + " " + In_QFrm.lConName.Text + ", ");
						rng.Select();
						break;
					//case "prfx1":	 
						//rng.InsertAfter(In_QFrm.lPrfx.Text + " ");
						//rng.Select();
						//break;
					case "email":	 
						rng.InsertAfter(In_QFrm.lemail.Text);
						rng.Select();
						break;
					case "endEmpName":	 
						rng.InsertAfter(In_QFrm.cbEmploy.Text + " " + In_QFrm.lEmpSFX.Text);
						rng.Select();
						break;
				}
			}
		}

		private void Page_CompRep()
		{
			//Rng.InsertBreak(ref EOP);
			//WPmsg("Compliance Report: \n", 'B', true);
			
			//Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			//object direc = Word.WdCollapseDirection.wdCollapseEnd;
			//Rng.Collapse(ref direc);
			//Rng.InsertBreak(ref EOP);

			//WPmsg("Compliance Report: \n", 'B', true);
			string msg = MainMDI.arr_EFSdict[34, MainMDI.Lang];	
			WPmsg(msg + " \n", 'B', true, true);
			WPmsg(In_FC.tCompl.Text + "\n", 'n', false, false);
		}

		private void Page_Prices()
		{
			//Rng.InsertBreak(ref EOP);
			//WPmsg("Prices: \n", 'B', true);

			//Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			//object direc = Word.WdCollapseDirection.wdCollapseEnd;
			//Rng.Collapse(ref direc);
			//Rng.InsertBreak(ref EOP);
		}

		/*
		private void Page_Terms_OLD()
		{
			//Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			//object direc = Word.WdCollapseDirection.wdCollapseEnd;
			//Rng.Collapse(ref direc);
			//Rng.InsertBreak(ref EOP);
			
			WPmsg(MainMDI.arr_EFSdict[31, MainMDI.Lang] + "\n", 'P', true);
			//MessageBox.Show("Col1= " + In_FWConfig.lvPTC.Items[0].SubItems[1].Text);
			int nbItem = In_FC.lvPTC.Items.Count;
			for (int i = 0; i < nbItem; i++)
			{
				if (In_FC.lvPTC.Items[i].Checked)
				{
					if (i == 0) WPrint2PTCold('N', In_FC.lvPTC.Items[i].SubItems[0].Text, In_FC.lvPTC.Items[i].SubItems[1].Text, 288, 288);
					else
					{
						if (newP)
						{
							WPrint2PTCold('N', In_FC.lvPTC.Items[i].SubItems[0].Text, In_FC.lvPTC.Items[i].SubItems[1].Text, 288, 288);
							newP = false;
						}
						else WPrint2PTCold('C', In_FC.lvPTC.Items[i].SubItems[0].Text, In_FC.lvPTC.Items[i].SubItems[1].Text, 288, 288);
					}
				}
				//Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
				//object direc = Word.WdCollapseDirection.wdCollapseEnd;
				//Rng.Collapse(ref direc);
				//Rng.InsertBreak(ref EOP);
			}
		}
		
		private void Page_TermsOLD()
		{
			string msg = MainMDI.arr_EFSdict[31, MainMDI.Lang];	
			WPmsg(msg + " \n", 'B', true);
			//WPmsg(msg + \n, 'B', false);
			int nbItem = In_FC.lvPTC.Items.Count;
			for (int i = 0; i < nbItem; i++)
			{ 
				if (In_FC.lvPTC.Items[i].Checked)
				{
					if (i == 0) WPrint2PTC('N', In_FC.lvPTC.Items[i].SubItems[0].Text, In_FC.lvPTC.Items[i].SubItems[1].Text, In_FC.lvPTC.Items[i].SubItems[2].Text, 288, 144, 144);
					else
					{
						if (newP)
						{
							WPrint2PTC('N', In_FC.lvPTC.Items[i].SubItems[0].Text, In_FC.lvPTC.Items[i].SubItems[1].Text, In_FC.lvPTC.Items[i].SubItems[2].Text, 288, 144, 144);
							newP = false;
						}
						else WPrint2PTC('C', In_FC.lvPTC.Items[i].SubItems[0].Text, In_FC.lvPTC.Items[i].SubItems[1].Text, In_FC.lvPTC.Items[i].SubItems[2].Text, 288, 144, 144);
					}
				}	
			}
		}
		*/

		private void Page_Terms()
		{
			string msg = MainMDI.arr_EFSdict[31, MainMDI.Lang];	
			WPmsg(msg + " \n", 'B', true, true);
			//WPmsg(msg + \n, 'B', false);
			int nbItem = In_FC.lvPTC.Items.Count;
			int subNdx = (In_FC.chkAGP.Checked) ? 4 : 1;
			for (int i = 0; i < nbItem; i++)
			{ 
				if (In_FC.lvPTC.Items[i].Checked)
				{
					if (i == 0) WPrint4PTC('N', In_FC.lvPTC.Items[i].SubItems[0].Text, In_FC.lvPTC.Items[i].SubItems[subNdx].Text, 
						In_FC.lvPTC.Items[i].SubItems[subNdx + 1].Text, In_FC.lvPTC.Items[i].SubItems[subNdx + 2].Text, 288, 144, 144);
					else
					{
						if (newP)
						{
							WPrint4PTC('N', In_FC.lvPTC.Items[i].SubItems[0].Text, In_FC.lvPTC.Items[i].SubItems[subNdx].Text, 
								In_FC.lvPTC.Items[i].SubItems[subNdx + 1].Text, In_FC.lvPTC.Items[subNdx + 2].SubItems[subNdx + 2].Text, 288, 
								144, 144);
							newP = false;
						}
						else WPrint4PTC('C', In_FC.lvPTC.Items[i].SubItems[0].Text, In_FC.lvPTC.Items[i].SubItems[subNdx].Text, 
							In_FC.lvPTC.Items[i].SubItems[subNdx + 1].Text, In_FC.lvPTC.Items[i].SubItems[subNdx + 2].Text, 288, 144, 144);
					}
				}	
			}
		}

		private void init_arr_options()
		{
			for (int i = 0; i < NBOption; i++)
				for (int j = 0; j < 8; j++) arr_options[i, j] = "";
			O = 1;
		}

		private void Print_Rev()
		{
			//string stSql = "SELECT PSM_Q_SOL.I_Quoteid, PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name, PSM_Q_ALS.ALS_Name, PSM_Q_Details.* " + 
				//" FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
				//" WHERE (((PSM_Q_SOL.I_Quoteid)=" + IQID + ") AND ((PSM_Q_SOL.Sol_Name)=" + SolName + ")) " +
				//" ORDER BY PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
		
			init_arr_options();
			WPmsg(" \n", 'B', false, true);
			string IQID = In_QFrm.lCurrIQID.Text;
			string SolName = In_QFrm.lCurSoln.Text;
			string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* " +
				" FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid)" +
				"        INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID)" +
				"        INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
				" WHERE (PSM_Q_IGen.i_Quoteid=" + IQID + " and PSM_Q_SOL.Sol_Name='" + SolName + "')" +
				" ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
			
			app.ActiveDocument.Content.Font.Name = "Arial";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
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
						bool et = (Ospc == "") ? false : true;
						if (Nspc[0] != '!') WPmsg(Nspc + ":", 'B', true, et); //WPmsg(Nspc + "\n", 'B', et);
						Ospc = Nspc;
						tbl = 'N';
					} 
					if (Oals != Nals)
					{
						//string qt = (Oreadr["AlsQty"].ToString() != "1") ? Oreadr["AlsQty"].ToString() + " x " : ":";
						//if (Nals[0] != '!') WPmsg("\n" + qt + Nals + " ", 'b', false, false);
						string qt = (Oreadr["AlsQty"].ToString() != "1") ? " QTY=" + Oreadr["AlsQty"].ToString() + ": " : ": ";
						if (Nals[0] != '!') WPmsg("\n" + Nals + " ", 'b', false, false);
						//else WPmsg(" ", 'b', false);
						Oals = Nals;
						WPmsg(MainMDI.arr_EFSdict[36, MainMDI.Lang] + "    " + qt, 'r', false, false);
						tbl = 'N';
					}
					//debut detail
					string qty = (Oreadr["Qty"].ToString() != "0" && Oreadr["Qty"].ToString() != " " && Oreadr["Qty"].ToString() != "") ? 
						Oreadr["Qty"].ToString() + " x " : "";

					//if (Oreadr["Xch_Mult"].ToString() == "1")
					//{

					if (Oreadr["Aff_ID"].ToString() == " ")
					{
						int iPos = Oreadr["Desc"].ToString().IndexOf("= ", 0);

						if (iPos > 0) WPrint2Col(tbl, qty + Oreadr["Desc"].ToString().Substring(0, iPos) + ": ", 
							Oreadr["Desc"].ToString().Substring(iPos + 2, Oreadr["Desc"].ToString().Length - iPos - 2), WT_1Col, WT_2Col);
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
								//,Oreadr["Desc"].ToString().Substring(iPos + 2, Oreadr["Desc"].ToString().Length - iPos - 2));
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
							WPmsg("\n" + Oreadr["Aff_ID"].ToString() + ") " + qty + Oreadr["Desc"].ToString() + ": \n", 'b', false, false);
							tbl = 'N';
						}
					}
					//}
					//else O = -1;
				}
			}
			if (O >= 1)
			{
				WPmsg(arr_options[0, 1].ToString(), 'b', false, false);
				//WPrint2Col('C', arr_options[0, 1].ToString(), " ");
				tbl = 'N';
				for (int t = 1; t < O; t++) 
				{ 
					WPrint2Col(tbl, " ", arr_options[t, 1].ToString(), WT_1Col, WT_2Col); 
					tbl = 'C'; 
				}
			}
			OConn.Close();
		}

		/*	
		private void Print_RevOLD()
		{
			//string stSql = "SELECT PSM_Q_SOL.I_Quoteid, PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name, PSM_Q_ALS.ALS_Name, PSM_Q_Details.* " + 
				//" FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
				//" WHERE (((PSM_Q_SOL.I_Quoteid)=" + IQID + ") AND ((PSM_Q_SOL.Sol_Name)=" + SolName + ")) " +
				//" ORDER BY PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
		
			init_arr_options();
			WPmsg(" \n", 'B', true);
			string IQID = In_QFrm.lCurrIQID.Text;
			string SolName = In_QFrm.lCurSoln.Text;
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
								//,Oreadr["Desc"].ToString().Substring(iPos + 2, Oreadr["Desc"].ToString().Length - iPos - 2));
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
			if (O >= 1)
			{
				WPmsg(arr_options[0, 1].ToString(), 'b', false);
				//WPrint2Col('C', arr_options[0, 1].ToString(), " ");
				tbl = 'N';
				for (int t = 1; t < O; t++) { WPrint2Col(tbl, " ", arr_options[t, 1].ToString(), WT_1Col, WT_2Col); tbl = 'C'; }
			}
		}
		*/

		private void WPrint2Col(char cod, string c1, string c2, int in_WT_1Col, int in_WT_2Col)
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
					TQdet = Rng.Tables.Add(Rng, 1, 2, ref MissV1, ref MissV2);
					break;
				default:
					TQdet = app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count];
					TQdet.Rows.Add(ref MissV1);
					j = TQdet.Rows.Count;
					break;
			}
			if (c2 == "") c2 = " "; //hi
			if (c2[0] != ' ') c2 = c2;
			//if (c2[0] != ' ') c2 = "• " + c2;
			//TQdet.Cell(j, 1).Range.Text = "   " + c1;
			TQdet.Cell(j, 1).Range.Text = c1;
			TQdet.Cell(j, 2).Range.Text = c2;
			TQdet.Cell(j, 1).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft;
			TQdet.Cell(j, 2).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft;
			//TQdet.Cell(j, 1).Width = WT_1Col;
			//TQdet.Cell(j, 2).Width = WT_2Col;
			//MessageBox.Show("1W= " + TQdet.Cell(j, 1).Width + "    2W= " + TQdet.Cell(j, 2).Width);
			TQdet.Columns[1].Width = in_WT_1Col;
			TQdet.Columns[2].Width = in_WT_2Col;

			//.Range(ref start, ref end);
			//Rng.InsertBreak(ref EOP);
			//Rng.InsertAfter("Comprising: \n");
			//Rng.Font.Size = 8;
			//int nbL = In_QFrm.lvQITEMS.Items.Count;
			//Word.Table TQdet = Rng.Tables.Add(Rng, nbL, 2, ref MissV1, ref MissV2);
			//int j = 1;
		}

		private void WPrint2PTCOLD(char cod, string c1, string c2, int in_WT_1Col, int in_WT_2Col)
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
					TQdet = Rng.Tables.Add(Rng, 1, 2, ref MissV1, ref MissV2);
					newP = false;
					break;
				default:
					TQdet= app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count];
					TQdet.Rows.Add(ref MissV1);
					j = TQdet.Rows.Count;
					break;
			}
			if (c2[0] == '.') c2 = "• " + c2.Substring(1, c2.Length - 1);
			if (c2[0] == '!') 
			{ 
				c2 = " "; 
				c1 = " "; 
			}
			TQdet.Cell(j, 1).Range.Text = "   " + c1;
			//TQdet.Cell(j, 2).Row.Alignment = Word.WdRowAlignment.wdAlignRowRight;
			TQdet.Cell(j, 2).Range.Text = c2;
			Word.Cell cell1 = TQdet.Cell(j, 2);
			if (c2.IndexOf("$") > -1 || c2.IndexOf("EURO") > -1) 
				cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
			else cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;

			//Word.Range tt = TQdet.Cell(j,2).Column.Select();
			//tt.Rows.Alignment = Word.WdRowAlignment.wdAlignRowLeft;

			//if (c2.IndexOf("$") > -1 || c2.IndexOf("EURO") > -1) TQdet.Cell(j, 2).Row.Alignment = Word.WdRowAlignment.wdAlignRowRight;
			//else TQdet.Cell(j, 2).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft;

			//if (c2.IndexOf("$") > -1 || c2.IndexOf("EURO") > -1) TQdet.Cell(j, 2).Row.Alignment = Word.WdRowAlignment.wdAlignRowRight;
			//else TQdet.Cell(j, 2).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft;

			//TQdet.Cell(j, 1).Width = WT_1Col;
			//TQdet.Cell(j, 2).Width = WT_2Col;
			//MessageBox.Show("1W= " + TQdet.Cell(j, 1).Width + "    2W= " + TQdet.Cell(j, 2).Width);

			//TQdet.Columns[1].Width = in_WT_1Col;
			//TQdet.Columns[2].Width = in_WT_2Col;

			//.Range(ref start, ref end);
			//Rng.InsertBreak(ref EOP);
			//Rng.InsertAfter("Comprising: \n");
			//Rng.Font.Size = 8;
			//int nbL=In_QFrm.lvQITEMS.Items.Count;
			//Word.Table TQdet = Rng.Tables.Add(Rng, nbL, 2, ref MissV1, ref MissV2);
			//int j = 1;
		}

		private void WPrint2PTC(char cod, string c1, string c2, string c3, int in_WT_1Col, int in_WT_2Col, int in_WT_3Col)
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
					TQdet = Rng.Tables.Add(Rng, 1, 3, ref MissV1, ref MissV2);
					newP = false;
					break;
				default:
					TQdet = app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count];
					TQdet.Rows.Add(ref MissV1);
					j = TQdet.Rows.Count;
					break;
			}
			if (c2[0] == '.') c2 = "• " + c2.Substring(1, c2.Length - 1);
			if (c2[0] == '!') 
			{ 
				c2 = " "; 
				c1 = " "; 
				c3 = " "; 
			}
			TQdet.Cell(j, 1).Range.Text = c1; //"   " + c1;
			TQdet.Cell(j, 2).Range.Text = c2;
			Word.Cell cell1 = TQdet.Cell(j, 2);

			if (c3 != " ") cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
			else cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
			
			TQdet.Cell(j, 3).Range.Text = c3;
			cell1 = TQdet.Cell(j, 3);
			cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
			TQdet.Columns[1].Width = 290;
			TQdet.Columns[2].Width = 130;
			TQdet.Columns[3].Width = 100;
			if (c2.IndexOf("Price/Each") > -1)
			{
				TQdet.Cell(j, 3).Range.Font.Bold = 1;
				TQdet.Cell(j, 2).Range.Font.Bold = 1;
				TQdet.Cell(j, 2).Range.Font.Underline= Word.WdUnderline.wdUnderlineSingle;
				TQdet.Cell(j, 3).Range.Font.Underline= Word.WdUnderline.wdUnderlineSingle;
			}
			else
			{
				TQdet.Cell(j, 3).Range.Font.Bold = 0;
				TQdet.Cell(j, 2).Range.Font.Bold = 0;
				TQdet.Cell(j, 2).Range.Font.Underline= Word.WdUnderline.wdUnderlineNone;
				TQdet.Cell(j, 3).Range.Font.Underline= Word.WdUnderline.wdUnderlineNone;
			}
		}

		private void WPrint4PTC(char cod, string c1, string c2, string c3, string c4, int in_WT_1Col, int in_WT_2Col, int in_WT_3Col)
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
					TQdet = Rng.Tables.Add(Rng, 1, 4, ref MissV1, ref MissV2);
					newP = false;
					break;
				default:
					TQdet = app.ActiveDocument.Tables[app.ActiveDocument.Tables.Count];
					TQdet.Rows.Add(ref MissV1);
					j = TQdet.Rows.Count;
					break;
			}
			if (c2[0] == '.') c2 = "• " + c2.Substring(1, c2.Length - 1);
			if (c2[0] == '!') 
			{ 
				c2 = " "; 
				c1 = " "; 
				c3 = " "; 
			}
			TQdet.Cell(j, 1).Range.Text = c1; //"   " + c1;
			TQdet.Cell(j, 2).Range.Text = c2;
			Word.Cell cell1 = TQdet.Cell(j, 2);
			if (c4 != " " && c4 != "!") cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
			else
			{
				cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft;
				c3 = " ";
				c4 = " ";
			}
			TQdet.Cell(j, 3).Range.Text = c3;
			cell1 = TQdet.Cell(j, 3);
			cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter;
	
			TQdet.Cell(j, 4).Range.Text = c4;
			cell1 = TQdet.Cell(j, 4);
			cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
			//cols width
			TQdet.Columns[1].Width = 200;
			TQdet.Columns[2].Width = 130;
			TQdet.Columns[3].Width = 60;
			TQdet.Columns[4].Width = 100;
			if (c2.IndexOf("Price/Each") > -1)
			{
				TQdet.Cell(j, 2).Range.Font.Bold = 1;
				TQdet.Cell(j, 3).Range.Font.Bold = 1;
				TQdet.Cell(j, 4).Range.Font.Bold = 1;
				TQdet.Cell(j, 2).Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
				TQdet.Cell(j, 3).Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
				TQdet.Cell(j, 4).Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
			}
			else
			{
				TQdet.Cell(j, 2).Range.Font.Bold = 0;
				TQdet.Cell(j, 3).Range.Font.Bold = 0;
				TQdet.Cell(j, 4).Range.Font.Bold = 0;
				
				TQdet.Cell(j, 2).Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;
				TQdet.Cell(j, 3).Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;
				TQdet.Cell(j, 4).Range.Font.Underline = Word.WdUnderline.wdUnderlineNone;
			}
		}

		private void WPmsgbad(string msg, char f, bool Npage)
		{
			Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			if (Npage)
			{
				Rng.Collapse(ref direc);
				Rng.InsertBreak(ref EOP);
				Rng.Collapse(ref direc);
				Rng.Text = " ";
				newP = true;
			}
			Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Text = msg;
			if (f == 'B' || f == 'P') Rng.Font.Size = 14;
			if (f == 'b' || f == 'B' || f == 'P') Rng.Font.Bold = 1;
			if (f == 'P') Rng.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
		}

		private void WPmsg(string msg, char f, bool ndrlN, bool Npage)
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
			if (f == 'B') Rng.Font.Size = 14;
			if (f == 'b' || f == 'B') Rng.Font.Bold = 1;
			if (ndrlN) Rng.Font.Underline = Word.WdUnderline.wdUnderlineSingle;
			else Rng.Font.Underline = Word.WdUnderline.wdUnderlineNone;
		}

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

				if (In_QFrm.lvQITEMS.Items[i].SubItems[2].Text[0] != '_' && 
					(In_QFrm.lvQITEMS.Items[i].Checked || In_QFrm.chkPrintALL.Checked))
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
					string qty = In_QFrm.lvQITEMS.Items[i].SubItems[3].Text + " x ";
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
			app.ActiveDocument.SaveAs(ref fn, ref ff, ref lc, ref pwd, ref atr, ref wpwd, ref ron, ref embd, ref svN, ref svF, ref svLett, 
				ref enc, ref inLin, ref Asub, ref Linend, ref addmrk);
			object sv = Type.Missing;
			object of = Type.Missing;
			object rd = Type.Missing;
			app.ActiveDocument.Close(ref sv, ref of, ref rd);
			app.Quit(ref sv, ref of, ref rd);
		}

		/*
		private void Page_Prices_ALS_sum()
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range Rng = app.ActiveDocument.Content; //.Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd;
			Rng.Collapse(ref direc);
			Rng.InsertBreak(ref EOP);
			
			Rng.InsertAfter(": \n");
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
					TQdet.Cell(j, 1).Width = 20;
					TQdet.Cell(j, 1).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft;
	
					TQdet.Cell(j, 2).Width = 450; TQdet.Cell(j, 2).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft;
					TQdet.Cell(j, 2).Width = 450;
					//TQdet.Cell(j, 2).Width;
					j++;
				}
			}
			TQdet.Select();
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

		//string st = "PRIMAX TECHNOLOGIE INC.";
		//object deb = 0;
		//object fin = 0;
		//Word.Range rng = doc.Range(ref deb, ref fin);
			 
		//rng.Text = st;
		//rng.Select();
		//rng.Font.Name = "ARIAL BLACK";
		//rng.Font.Italic = 1;
		//rng.Font.Size = 14;

		//doc.Save();
		//Example
		//This example inserts a continuous section break immediately preceding the selection.
		//Selection.InsertBreak Type: = wdSectionBreakContinuous
		//This example inserts a page break immediately following the second paragraph in the active document.

		//Set myRange = ActiveDocument.Paragraphs(2).Range
		//With myRange
		//.Collapse Direction:=wdCollapseEnd
		//.InsertBreak Type:=wdPageBreak
		//End With
	}
}