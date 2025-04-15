using System;
using System.Windows.Forms ;
using Word = Microsoft.Office.Interop.Word     ;
using System.Collections ; 
using VB = Microsoft.VisualBasic  ;
using System.Data ;
using System.Data.OleDb ;
using System.Data.SqlClient ;
using Excel = Microsoft.Office.Interop.Excel;
using EAHLibs;


namespace PGESCOM
{
	/// <summary>
	/// Summary description for FichWord.
	/// </summary>
	public class FichWord
	{
        private static Lib1 Tools = new Lib1();
		private bool newP=false;
		private QuoteV2  In_QFrm;
        private QuoteV4 In_QFrm4;
		private	Word.Application app=new Word.Application();
		private object Omiss=System.Reflection.Missing.Value ;
		private object start=0;
		private object end=0;
		private FichWord_Config In_FC ;
		private object EOP=Word.WdBreakType.wdPageBreak ;
		private const int WT_1Col=120;     //100;
		private const int WT_2Col=  360;   //365;
		private const int NBOption=100, VQ_Lines=1000, VQ_Cols=6;
		private int O=0,debRev=-1,finRev=-1,debTerm=-1,finTerm=-1;
        private string[,] arr_options = new string[NBOption, 8], arr_VQ = new string[VQ_Lines, VQ_Cols], arr_terms=new string [20,4];
		public FichWord(QuoteV2   x_Qfrm ,FichWord_Config x_FWConfig )
		{
			In_QFrm = x_Qfrm; 	
   	    
			//MessageBox.Show( "QID= " + In_QFrm.tQuoteID.Text ); 
			In_FC= x_FWConfig;
		
            
		}
        public FichWord(QuoteV4 x_Qfrm, FichWord_Config x_FWConfig)
        {
            In_QFrm4 = x_Qfrm;

            //MessageBox.Show( "QID= " + In_QFrm.tQuoteID.Text ); 
            In_FC = x_FWConfig;


        }



		public bool Wexport()
		{
			//	string Tfn=Application.StartupPath+   @"\QuoteEnglish.doc";
			//    string Ofn=Application.StartupPath+   @"\Q" +In_QFrm.tQuoteID.Text +".doc";
			string Tfn=Application.StartupPath, PTCfn = "";
			string stRev= In_QFrm.lCurSoln.Text.Substring(2,In_QFrm.lCurSoln.Text.Length - 2) + "-";  
			//    string Ofn=  @"H:\Sales\PSM_Quotes" +   @"\Q" +In_QFrm.tQuoteID.Text +stRev + In_QFrm.lCpnyName.Text + ".doc";
			string Ofn=  @MainMDI.WQfiles +  @"\Q" +In_QFrm.tQuoteID.Text +stRev + In_QFrm.lCpnyName.Text.Replace("/"," ").Replace(".", "").Replace("'", "_") + ".doc";

            switch (MainMDI.Lang)
            {
                case 0:
                    Tfn += @"\QuoteEnglish.doc";
                    PTCfn = Application.StartupPath + @"\PTCC.doc"; 
                    break;
                case 1:
                    Tfn += @"\QuoteFrench.doc";
                    PTCfn = "";
                    break;
                case 2:
                    Tfn += @"\QuoteItalian.doc";
                    PTCfn = "";
                    break;

                default:
                    Tfn += @"\QuoteEnglish.doc";
                    PTCfn = Application.StartupPath + @"\PTCC.doc";
                    break;
            }

            
           // Tfn += (MainMDI.Lang ==0) ?  @"\QuoteEnglish.doc" : @"\QuoteFrench.doc";
			//     In_QFrm.lblWait.Text =   "Wait, exporting To:" + Ofn; 
			//	In_QFrm.grpPB.Refresh();
			OpenWF(Tfn ,Ofn) ;
			In_QFrm.pbPrintQt.Value =100; 
			int nbLines= (In_QFrm.chkPrintALL.Checked ) ? In_QFrm.lvQITEMS.Items.Count : In_QFrm.lvQITEMS.CheckedItems.Count;
       //     int nbLines = In_QFrm.lvQITEMS.Items.Count;
			if ( In_FC.chkComptxt.Checked )  Page_CompRep();
			In_QFrm.pbPrintQt.Value +=100;
			Print_Rev();
			In_QFrm.pbPrintQt.Value +=600;
			Page_Terms();

            //       if (PTCfn != "") add_PTCfile(PTCfn);

            if (PTCfn != "") NSRT_PTCfile(PTCfn);

            In_QFrm.pbPrintQt.Value +=100;
			Fermer_App(Ofn); 
			In_QFrm.pbPrintQt.Value = 1000;
			In_QFrm.lblWait.Text =   " WordFile Completed " ; // + Ofn; 
			In_QFrm.lOFName.Text = Ofn ; 
			In_QFrm.button5.Visible =true; 
			In_QFrm.button6.Visible =true; 
			In_QFrm.grpPB.Refresh();

       //     if (PTCfn != "") mergeF1doc_F2doc(Application.StartupPath + @"\toto.doc", PTCfn);

			return true;
		}


        void add_PTCfile(string ptcfn)
        {

            //insert new page break:  Word.WdBreakType.wdPageBreak
            var application = new Word.Application();
            var originalDocument = application.Documents.Open(ptcfn);

            originalDocument.ActiveWindow.Selection.WholeStory();
            var originalText = originalDocument.ActiveWindow.Selection;

            Object MissV1 = Type.Missing;
            Object MissV2 = Type.Missing;
            Word.Range Rng = app.ActiveDocument.Content;
            object direc = Word.WdCollapseDirection.wdCollapseEnd;
            Rng.Collapse(ref direc);
            Rng.Text = Word.WdBreakType.wdPageBreak + originalText.Text;


            //newDocument.SaveAs(@"C:\whateverelse.docx");

            //originalDocument.Close(false);
            //newDocument.Close();

            //application.Quit();

            //Marshal.ReleaseComObject(application);
        }

        void NSRT_PTCfile(string ptcfn)
        {

          
            Object objBreak = Word.WdBreakType.wdPageBreak;
            WPmsg(" " + " \n", 'B', true, true);

            // Word.Range Rngpage = app.ActiveDocument.Content; //  .Range(ref start, ref end);
            //object direc = Word.WdCollapseDirection.wdCollapseEnd;
            // Rngpage.Collapse(ref direc);
            // Rngpage.InsertBreak(ref objBreak);

            Word.Application oWord = new Word.Application();
            oWord.Visible = false;

            Word.Document oDoc2 = oWord.Documents.Open(ptcfn);
            Word.Range oRange = oDoc2.Content;
            oRange.Copy();

          
            Word.Range Rng = app.ActiveDocument.Content;
            //direc = Word.WdCollapseDirection.wdCollapseEnd;
            //Rng.Collapse(ref direc);
            //                  //Rng.InsertAfter(Word.WdBreakType.wdPageBreak.ToString ());


            Rng = app.ActiveDocument.Content;
            object direc = Word.WdCollapseDirection.wdCollapseEnd;
            Rng.Collapse(ref direc);

            Rng.PasteSpecial(DataType: Word.WdPasteOptions.wdKeepSourceFormatting);
            oDoc2.Close();
        }

        void mergeF1doc_F2doc(string F1doc, string F2doc)
        {

            

            object missing = System.Reflection.Missing.Value;

            // Create an object of application class

            Word.Application WordApp = new Word.Application();
            

            // add a document in the Application

           Word.Document adoc = WordApp.Documents.Add(ref missing, ref missing, ref missing, ref missing);

            // declare variables for setting the position within the document

            object start = 0;

            object end = 0;

            // create a range object which starts at 0

           Word.Range rng = adoc.Range(ref start, ref missing);

            // insert a file

            rng.InsertFile(F1doc, ref missing, ref missing, ref missing, ref missing);

            // now make start to point to the end of the content of the first document

            start = WordApp.ActiveDocument.Content.End-1;

            // create another range object with the new value for start

            Word.Range rng1 = adoc.Range(ref start, ref missing);

            // insert the another document

            rng1.InsertFile(F2doc, ref missing, ref missing, ref missing, ref missing);

            //// now make start to point to the end of the content of the first document

            start = WordApp.ActiveDocument.Content.End-1;

            //// make the word appliction visible

            WordApp.Visible = true;



        }



		private void Insert_page(int nPage)
		{
			//Word.Paragraph Opara;

			//Word.Range Rng= app.ActiveDocument.Range(ref start,ref end );
			
			//		Rng.InsertBefore("HHHHHHHHHHH..");
			//		Rng.Font.Size =16;
			
		}
			
		private void OpenWF(string TfName,string OfName)
		{
		
			//	Word.Application app=new Word.ApplicationClass();
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
			Object openAndRepair  = Type.Missing;
			Object documentDirection = Type.Missing;
			Object noEncodingDialog = Type.Missing;
			Object xmlTRsfrm = Type.Missing;
			app.Documents.Open(ref filename,ref confirmConversions, ref readOnly, ref addToRecentFiles,	ref passwordDocument, ref passwordTemplate, ref revert,ref writePasswordDocument, ref writePasswordTemplate,ref format, ref encoding, ref visible, ref openConflictDocument,ref openAndRepair , ref documentDirection,ref xmlTRsfrm); //, ref noEncodingDialog);
			Word.Options options = app.Options;

			options.BackgroundSave = true;
			options.Overtype = true;
			options.UpdateFieldsAtPrint = true;
			options.PrintHiddenText = true;
			options.PrintFieldCodes = true;
	     
			Word.Document doc = app.ActiveDocument; 
			Word.Range rng = doc.Range(ref start,ref end); //= Wbmk.Range;
			object i=1;
            string dr = (In_QFrm.lPrfx.Text == MainMDI.VIDE) ? "" : In_QFrm.lPrfx.Text;
			for (int j=1;j <doc.Bookmarks.Count+1;j++)
			{
				
				i=j;
				string Bkname=doc.Bookmarks.get_Item(ref i).Name ;
				Word.Bookmark Wbmk= doc.Bookmarks.get_Item(ref i);
				rng= Wbmk.Range;
				switch (Bkname)
				{
					case "Fax":	 
						//	rng.InsertAfter(In_QFrm.lFax.Text); 
						rng.InsertAfter(In_QFrm.lConFax.Text); 
						rng.Select();
						break;
					case "contactName":	 
						rng.InsertAfter(dr +"  " +In_QFrm.cbContacts.Text  ); 
						rng.Select();
						break;
					case "CompanyName":	 
						rng.InsertAfter(In_QFrm.lCpnyName.Text   ); 
						rng.Select();
						break;
					case "Phone":	 
						//	rng.InsertAfter(In_QFrm.lPhone.Text  ); 
						rng.InsertAfter(In_QFrm.lConTel.Text  ); 
						rng.Select();
						break;
					case "Ext":	 
						//	string ext= (In_QFrm.lConExt.Text=="") ? "" : ", Ext:" + In_QFrm.lConExt.Text;
						string ext= (In_QFrm.lConExt.Text=="") ? "" : ", " + MainMDI.arr_EFSdict[37,MainMDI.Lang ] + ": "    + In_QFrm.lConExt.Text;
						rng.InsertAfter(ext ); 
						rng.Select();
						break;
					case "ProjName":	 
						rng.InsertAfter(In_QFrm.tProjNAME.Text  ); 
						rng.Select();
						break;
					case "WQID":	 
						rng.InsertAfter(In_QFrm.tQuoteID.Text +"-"+ In_QFrm.lCurSoln.Text.Substring(3,In_QFrm.lCurSoln.Text.Length -3)   ); 
						rng.Select();
						break;
					case "submitxt":
						string fultxt=(In_FC.checkBox1.Checked) ? In_FC.tsubmit.Text :   "" ; 
						fultxt +=(In_FC.checkBox2.Checked) ? "\n" + In_FC.tothers.Text  :   "" ; 
					//	rng.InsertAfter( fultxt +   "\n" ); 
						rng.InsertAfter( fultxt ); 
						rng.Select();
						break;
                    case "Rectif_TXT":
                        string fultxt_rectif = (In_FC.checkBox3.Checked) ? In_FC.tRectif_TXT.Text : "";
                        rng.InsertAfter(fultxt_rectif );
                        rng.Select();
                        break;

					case "EmpExt":	
						string tt= (In_QFrm.lEExt.Text=="") ? "" : MainMDI.arr_EFSdict[37,MainMDI.Lang ] + ": "    + In_QFrm.lEExt.Text;
						rng.InsertAfter(tt ); 
						rng.Select();
						break;
					case "EmplName":	 
						rng.InsertAfter(In_QFrm.cbEmploy.Text); // + " " + In_QFrm.lEmpSFX.Text  ); 
						rng.Select();
						break;
					case "DateNow":	 
						//rng.InsertAfter(In_QFrm.tOpendate.Text); 
						//rng.InsertAfter(In_FC.tCQRdate.Value.ToShortDateString()); 
						rng.InsertAfter(In_FC.tCQRdate.Text); 
						rng.Select();
						break;
						//	case "PageNb":	 
						//		rng.InsertAfter("4"); 
						//		rng.Select();
						//		break;
					case "DearContactNm":
                     
						rng.InsertAfter(dr +" " + In_QFrm.lConName.Text ); 
						rng.Select();
						break;
						//	case "prfx1":	 
						//		rng.InsertAfter(In_QFrm.lPrfx.Text +" " ); 
						//		rng.Select();
						//		break;
					case "email":	 
						rng.InsertAfter(In_QFrm.lemail.Text  ); 
						rng.Select();
						break;
					case "endEmpName":	 
						rng.InsertAfter(In_QFrm.cbEmploy.Text + " " + In_QFrm.lEmpSFX.Text   ); 
						rng.Select();
						break;
				}
                
			}
		}


		private void Page_CompRep()
		{


			//Rng.InsertBreak(ref EOP ); 
			//      WPmsg("Compliance Report: \n",'B',true);
			
			//	Word.Range  Rng = app.ActiveDocument.Content; //  .Range(ref start, ref end);
			//	object direc = Word.WdCollapseDirection.wdCollapseEnd  ;
			//	Rng.Collapse(ref direc);
			//	Rng.InsertBreak(ref EOP ); 

			//    WPmsg("Compliance Report: \n",'B',true);
			string msg=MainMDI.arr_EFSdict[34,MainMDI.Lang];	
			WPmsg(msg+" \n",'B',true,true);
			WPmsg(In_FC.tCompl.Text + "\n" ,'n',false,false);

	
			
		}
		private void Page_Prices()
		{


			//Rng.InsertBreak(ref EOP ); 
			//WPmsg("Prices: \n",'B',true);

			
			//		Word.Range  Rng = app.ActiveDocument.Content; //  .Range(ref start, ref end);
			//		object direc = Word.WdCollapseDirection.wdCollapseEnd  ;
			//		Rng.Collapse(ref direc);
			//		Rng.InsertBreak(ref EOP ); 

			
		}


        /*
		private void Page_Terms_OLD()
		{
			//		Word.Range  Rng = app.ActiveDocument.Content; //  .Range(ref start, ref end);
			//		object direc = Word.WdCollapseDirection.wdCollapseEnd  ;
			//		Rng.Collapse(ref direc);
			//		Rng.InsertBreak(ref EOP ); 
			
			WPmsg(MainMDI.arr_EFSdict[31,MainMDI.Lang] + "\n",'P',true);
			//essageBox.Show("Col1= " + In_FWConfig.lvPTC.Items[0].SubItems[1].Text ); 
			int nbItem=In_FC.lvPTC.Items.Count ; 
			for (int i=0;i<nbItem  ;i++)
			{
				if (In_FC.lvPTC.Items[i].Checked )
				{
					if (i==0) WPrint2PTCold('N',In_FC.lvPTC.Items[i].SubItems[0].Text ,In_FC.lvPTC.Items[i].SubItems[1].Text,288,288);
					else
					{
						if (newP)  
						{
							WPrint2PTCold('N',In_FC.lvPTC.Items[i].SubItems[0].Text ,In_FC.lvPTC.Items[i].SubItems[1].Text,288,288);
							newP =false;
						}
						else	WPrint2PTCold('C',In_FC.lvPTC.Items[i].SubItems[0].Text ,In_FC.lvPTC.Items[i].SubItems[1].Text,288,288);
			                
					}
				}

				//		Word.Range  Rng = app.ActiveDocument.Content; //  .Range(ref start, ref end);
				//		object direc = Word.WdCollapseDirection.wdCollapseEnd  ;
				//		Rng.Collapse(ref direc);
				//		Rng.InsertBreak(ref EOP ); 
		
			}
		}
		
private void Page_TermsOLD()
		{
			string msg=MainMDI.arr_EFSdict[31,MainMDI.Lang];	
			WPmsg(msg+" \n",'B',true);
			//	WPmsg(msg + \n ,'B',false);
			int nbItem=In_FC.lvPTC.Items.Count ; 
			for (int i=0;i<nbItem  ;i++)
			{ 
				if (In_FC.lvPTC.Items[i].Checked )
				{
					if (i==0) WPrint2PTC('N',In_FC.lvPTC.Items[i].SubItems[0].Text ,In_FC.lvPTC.Items[i].SubItems[1].Text,In_FC.lvPTC.Items[i].SubItems[2].Text,288,144,144);
					else
					{  			
						if (newP)  
						{
							WPrint2PTC('N',In_FC.lvPTC.Items[i].SubItems[0].Text ,In_FC.lvPTC.Items[i].SubItems[1].Text,In_FC.lvPTC.Items[i].SubItems[2].Text,288,144,144);
							newP =false;
						}
						else	WPrint2PTC('C',In_FC.lvPTC.Items[i].SubItems[0].Text ,In_FC.lvPTC.Items[i].SubItems[1].Text,In_FC.lvPTC.Items[i].SubItems[2].Text,288,144,144);
					}       
			
				}	
			}
		
		}
	


*/

   
        private void Page_Terms()
        {

            for (int t = 0; t < 20; t++) for (int j = 0; j < 4;j++ ) arr_terms[t, j] = "";
            int TT = 0;
            string msg = MainMDI.arr_EFSdict[31, MainMDI.Lang];
            WPmsg(msg + " \n", 'B', true, true);
            //	WPmsg(msg + \n ,'B',false);
            int nbItem = In_FC.lvPTC.Items.Count;
            int subNdx = (In_FC.chkAGP.Checked) ? 4 : 1;
            for (int i = 0; i < nbItem; i++)
            {
                if (In_FC.lvPTC.Items[i].Checked)
                {
                    if (In_FC.chk_VQ.Checked && In_FC.lvPTC.Items[i].SubItems[subNdx + 2].Text==" ")
                    {
                        arr_terms[TT, 0] = In_FC.lvPTC.Items[i].SubItems[0].Text;
                        arr_terms[TT, 1] = In_FC.lvPTC.Items[i].SubItems[subNdx].Text;
                        arr_terms[TT, 2] = In_FC.lvPTC.Items[i].SubItems[subNdx + 1].Text;
                        arr_terms[TT++, 3] = In_FC.lvPTC.Items[i].SubItems[subNdx + 2].Text;
                    }

                    if (i == 0) WPrint4PTC('N', In_FC.lvPTC.Items[i].SubItems[0].Text, In_FC.lvPTC.Items[i].SubItems[subNdx].Text, In_FC.lvPTC.Items[i].SubItems[subNdx + 1].Text, In_FC.lvPTC.Items[i].SubItems[subNdx + 2].Text, 288, 144, 144);
                    else
                    {
                        if (newP)
                        {
                            WPrint4PTC('N', In_FC.lvPTC.Items[i].SubItems[0].Text, In_FC.lvPTC.Items[i].SubItems[subNdx].Text, In_FC.lvPTC.Items[i].SubItems[subNdx + 1].Text, In_FC.lvPTC.Items[subNdx + 2].SubItems[subNdx + 2].Text, 288, 144, 144);
                            newP = false;
                        }
                        else WPrint4PTC('C', In_FC.lvPTC.Items[i].SubItems[0].Text, In_FC.lvPTC.Items[i].SubItems[subNdx].Text, In_FC.lvPTC.Items[i].SubItems[subNdx + 1].Text, In_FC.lvPTC.Items[i].SubItems[subNdx + 2].Text, 288, 144, 144);
                    }

                }
            }
            if (In_FC.chk_VQ.Checked) arr_terms[TT++, 0] = "~~||";
        }
		private void Page_Terms_good()
		{
			string msg=MainMDI.arr_EFSdict[31,MainMDI.Lang];	
			WPmsg(msg+" \n",'B',true,true);
			//	WPmsg(msg + \n ,'B',false);
			int nbItem=In_FC.lvPTC.Items.Count ; 
			int subNdx = (In_FC.chkAGP.Checked ) ? 4 :1; 	
			for (int i=0;i<nbItem  ;i++)
			{ 
				if (In_FC.lvPTC.Items[i].Checked )
				{

					if (i==0) WPrint4PTC('N',In_FC.lvPTC.Items[i].SubItems[0].Text ,In_FC.lvPTC.Items[i].SubItems[subNdx].Text,In_FC.lvPTC.Items[i].SubItems[subNdx+1].Text,In_FC.lvPTC.Items[i].SubItems[subNdx+2].Text,288,144,144);
					else
					{  			
						if (newP)  
						{
							WPrint4PTC('N',In_FC.lvPTC.Items[i].SubItems[0].Text ,In_FC.lvPTC.Items[i].SubItems[subNdx].Text,In_FC.lvPTC.Items[i].SubItems[subNdx+1].Text,In_FC.lvPTC.Items[subNdx+2].SubItems[subNdx+2].Text,288,144,144);
							newP =false;
						}
						else	WPrint4PTC('C',In_FC.lvPTC.Items[i].SubItems[0].Text ,In_FC.lvPTC.Items[i].SubItems[subNdx].Text,In_FC.lvPTC.Items[i].SubItems[subNdx+1].Text,In_FC.lvPTC.Items[i].SubItems[subNdx+2].Text,288,144,144);
					}       
			
				}	
			}
		
		}

        private void Print_RevOLDOK()
        {
            //		string stSql="SELECT PSM_Q_SOL.I_Quoteid, PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name, PSM_Q_ALS.ALS_Name, PSM_Q_Details.* " + 
            //                         " FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
            //                         " WHERE (((PSM_Q_SOL.I_Quoteid)=" + IQID + ") AND ((PSM_Q_SOL.Sol_Name)=" + SolName + ")) " +
            //						 " ORDER BY PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";

            init_arr_options();
            WPmsg(" \n", 'B', false, true);
            string IQID = In_QFrm.lCurrIQID.Text;
            string SolName = In_QFrm.lCurSoln.Text;
            string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* " +
                " FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " WHERE (PSM_Q_IGen.i_Quoteid=" + IQID + " and PSM_Q_SOL.Sol_Name='" + SolName + "') ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";

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
                //alsAdded=false;
                if (Oreadr["Desc"].ToString()[0] != '_')
                {
                    if (Nsol == "") Nsol = Oreadr["Sol_Name"].ToString();
                    Nspc = Oreadr["SPC_Name"].ToString();
                    Nals = Oreadr["ALS_Name"].ToString();
                    if (Ospc != Nspc)
                    {
                        bool et = (Ospc == "") ? false : true;
                        if (Nspc[0] != '!') WPmsg(Nspc + ":", 'B', true, et);  //WPmsg(Nspc+ "\n",'B',et);
                        Ospc = Nspc;
                        tbl = 'N';
                    }
                    if (Oals != Nals)
                    {

                        //	string qt =(Oreadr["AlsQty"].ToString()!="1") ?  Oreadr["AlsQty"].ToString()+" x " : ":";
                        //	if (Nals[0]!='!')  WPmsg("\n" + qt + Nals  + " " ,'b',false,false);
                        string qt = (Oreadr["AlsQty"].ToString() != "1") ? " QTY=" + Oreadr["AlsQty"].ToString() + ": " : ": ";
                        if (Nals[0] != '!') WPmsg("\n" + Nals + " ", 'b', false, false);
                        //	else  WPmsg(" " ,'b',false);
                        Oals = Nals;
                        WPmsg(MainMDI.arr_EFSdict[36, MainMDI.Lang] + "    " + qt, 'r', false, false);
                        tbl = 'N';
                    }
                    //debut detail
                    string qty = (Oreadr["Qty"].ToString() != "0" && Oreadr["Qty"].ToString() != " " && Oreadr["Qty"].ToString() != "") ? Oreadr["Qty"].ToString() + " x " : "";

                    //if (Oreadr["Xch_Mult"].ToString()=="1" )
                    //{


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
                                //,Oreadr["Desc"].ToString().Substring(iPos+2,Oreadr["Desc"].ToString().Length - iPos-2));
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
                    //else O =-1;
                }
            }
            if (O >= 1)
            {
                WPmsg(arr_options[0, 1].ToString(), 'b', false, false);
                //WPrint2Col('C',arr_options[0,1].ToString ()," ");
                tbl = 'N';
                for (int t = 1; t < O; t++) { WPrint2Col(tbl, " ", arr_options[t, 1].ToString(), WT_1Col, WT_2Col); tbl = 'C'; }
            }
        }



        string del_PXcode(string myline)
        {
            int pos = myline.IndexOf("[");
            if (pos > -1)
            {
                int pos2 = myline.IndexOf("]", pos);
                if (pos2 > -1)
                {
                    string cod = myline.Substring(pos, pos2 - pos + 1);
                    return myline.Replace(cod, "");
                }
            }

            return myline;

        }
        private void init_arr_options()
		{
			for (int i=0;i<NBOption;i++)
				for (int j=0;j<8;j++)
					arr_options[i,j]="";
			O=1;
		   
		}



		private void Print_Rev()
		{

            bool H_Printed=false;
			//		string stSql="SELECT PSM_Q_SOL.I_Quoteid, PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name, PSM_Q_ALS.ALS_Name, PSM_Q_Details.* " + 
			//                         " FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
			//                         " WHERE (((PSM_Q_SOL.I_Quoteid)=" + IQID + ") AND ((PSM_Q_SOL.Sol_Name)=" + SolName + ")) " +
			//						 " ORDER BY PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
		
			init_arr_options();
			WPmsg(" \n",'B',false,true);
			string IQID=In_QFrm.lCurrIQID.Text  ;
			string SolName=In_QFrm.lCurSoln.Text ; 
			string stSql="SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* " +
				" FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
				" WHERE (PSM_Q_IGen.i_Quoteid=" + IQID   + " and PSM_Q_SOL.Sol_Name='" + SolName   + "') ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
			
			app.ActiveDocument.Content.Font.Name ="Arial";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			string Nsol="",Ospc="",Nspc="",Nals="",Oals="";
			char tbl='C';
			while (Oreadr.Read ())
			{
                //alsAdded=false;


                string oldLine = Oreadr["Desc"].ToString();
               string Desc = del_PXcode(Oreadr["Desc"].ToString());

                if (Desc[0] !='_')
				{
					if (Nsol=="")  Nsol= Oreadr["Sol_Name"].ToString();
					Nspc=Oreadr["SPC_Name"].ToString();
					Nals=Oreadr["ALS_Name"].ToString();
					if (Ospc != Nspc) 
					{ 
                        bool et=(Ospc=="") ? false:true;
						if (Nspc[0]!='!') WPmsg(Nspc+ ":",'B',true,et);  //WPmsg(Nspc+ "\n",'B',et);
						Ospc = Nspc;
						tbl='N';
					} 
					if (Oals != Nals )
					{

					//	string qt =(Oreadr["AlsQty"].ToString()!="1") ?  Oreadr["AlsQty"].ToString()+" x " : ":";
					//	if (Nals[0]!='!')  WPmsg("\n" + qt + Nals  + " " ,'b',false,false);
						string qt =(Oreadr["AlsQty"].ToString()!="1") ?  " QTY=" + Oreadr["AlsQty"].ToString() +": " : ": ";
						if (Nals[0]!='!')  WPmsg("\n" + Nals +" " ,'b',false,false);
						//	else  WPmsg(" " ,'b',false);
						Oals=Nals ;
						WPmsg(MainMDI.arr_EFSdict[36,MainMDI.Lang ]   + "    "+ qt,'r',false,false);
						tbl='N';
                        H_Printed = false;
					}
					//debut detail
					string qty=( Oreadr["Qty"].ToString() != "0" && Oreadr["Qty"].ToString() != " " && Oreadr["Qty"].ToString() != "") ? Oreadr["Qty"].ToString() +" x " : "";
                  

                    //P4600 Hidden Item
                    string H_itemP4600TXT= (MainMDI.Lang == 0) ? @"PC23 c/w touch screen, P4600 overlay and cabinet door cutout" : "PC23 incluant écran tactil, membrane et ouverture dans la porte";
                    bool H_itemP4600 = (Desc == H_itemP4600TXT);
                    if (H_itemP4600) H_Printed = true;
                   //  H_Printed = H_itemP4600;
                    //P4600 Hidden Item
                    
                    
                    if (Oreadr["Q_tec_Val"].ToString()!="C_HIDE" || H_itemP4600)
					{
					

						if (Oreadr["Aff_ID"].ToString() ==" " || H_itemP4600)
						{
							int iPos=Desc.IndexOf("= ",0) ;

							if (iPos>0)	WPrint2Col(tbl, qty + Desc.Substring(0,iPos)+": ",Desc.Substring(iPos+2,Desc.Length - iPos-2),WT_1Col,WT_2Col);
							else WPrint2Col(tbl," ",qty + Desc,WT_1Col,WT_2Col);
							tbl='C';
						}
						else  

						{ 
							if (Oreadr["Aff_ID"].ToString() == ".")
							{
								int iPos=Desc.IndexOf("= ",0) ;
								if (iPos>0)
								{
									arr_options[0,0]=Oreadr["Aff_ID"].ToString(); 
									arr_options[0,1]= qty + Desc.Substring(0,iPos)+": ";
									//,Oreadr["Desc"].ToString().Substring(iPos+2,Oreadr["Desc"].ToString().Length - iPos-2));
								}
								else
								{
									arr_options[O,0]=Oreadr["Aff_ID"].ToString(); 
									arr_options[O,1]=qty + Desc; 
									arr_options[O,2]=Oreadr["Qty"].ToString(); 
									arr_options[O,3]=Oreadr["Xch_Mult"].ToString(); 
									arr_options[O,4]=Oreadr["Uprice"].ToString(); 
									arr_options[O,5]=Oreadr["LeadTime"].ToString(); 
									O++;
								}
					  
							}
							else
							{
                                string newID = Oreadr["Aff_ID"].ToString();
                            //    if (H_Printed) newID = (Tools.Conv_Dbl(newID) - 1).ToString();// (Tools.Conv_Dbl(Oreadr["Aff_ID"].ToString()) - 1).ToString();


								WPmsg("\n" + newID+ ") " + qty + Desc + ": \n" ,'b',false,false);
								tbl='N';
							}
						}
					}
					//else O =-1;
				}
			}
			if (O>=1)
			{
				WPmsg(arr_options[0,1].ToString () ,'b',false,false);
				//WPrint2Col('C',arr_options[0,1].ToString ()," ");
				tbl='N';
				for (int t=1;t<O;t++) {WPrint2Col(tbl," ",arr_options[t,1].ToString (),WT_1Col,WT_2Col);tbl='C';}
			}
		}
	/*	
		private void Print_RevOLD()
		{
			//		string stSql="SELECT PSM_Q_SOL.I_Quoteid, PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name, PSM_Q_ALS.ALS_Name, PSM_Q_Details.* " + 
			//                         " FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
			//                         " WHERE (((PSM_Q_SOL.I_Quoteid)=" + IQID + ") AND ((PSM_Q_SOL.Sol_Name)=" + SolName + ")) " +
			//						 " ORDER BY PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
		
			init_arr_options();
			WPmsg(" \n",'B',true);
			string IQID=In_QFrm.lCurrIQID.Text  ;
			string SolName=In_QFrm.lCurSoln.Text ; 
			string stSql="SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* " +
				" FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
				" WHERE (PSM_Q_IGen.i_Quoteid=" + IQID   + " and PSM_Q_SOL.Sol_Name='" + SolName   + "') ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
			
			app.ActiveDocument.Content.Font.Name ="Arial";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			string Nsol="",Ospc="",Nspc="",Nals="",Oals="";
			char tbl='C';
			while (Oreadr.Read ())
			{
				//alsAdded=false;
				if (Nsol=="")  Nsol= Oreadr["Sol_Name"].ToString();
				Nspc=Oreadr["SPC_Name"].ToString();
				Nals=Oreadr["ALS_Name"].ToString();
				if (Ospc != Nspc) 
				{ 
					if (Nspc[0]!='!') WPmsg(Nspc+ "\n",'B',false);
					Ospc = Nspc;
					tbl='N';
				} 
				if (Oals != Nals )
				{
					if (Nals[0]!='!')  WPmsg("\n" + Nals +" " ,'b',false);
					//	else  WPmsg(" " ,'b',false);
					Oals=Nals ;
					WPmsg(MainMDI.arr_EFSdict[36,MainMDI.Lang ]   + ": \n",'r',false);
					tbl='N';
				}
				//debut detail
				string qty=( Oreadr["Qty"].ToString() != "0" && Oreadr["Qty"].ToString() != " " && Oreadr["Qty"].ToString() != "") ? Oreadr["Qty"].ToString() +" x " : "";

				if (Oreadr["Xch_Mult"].ToString()=="1")
				{
					

					if (Oreadr["Aff_ID"].ToString() ==" ")
					{
						int iPos=Oreadr["Desc"].ToString().IndexOf("= ",0) ;

						if (iPos>0)	WPrint2Col(tbl, qty + Oreadr["Desc"].ToString().Substring(0,iPos)+": ",Oreadr["Desc"].ToString().Substring(iPos+2,Oreadr["Desc"].ToString().Length - iPos-2),WT_1Col,WT_2Col);
						else WPrint2Col(tbl," ",qty + Oreadr["Desc"].ToString(),WT_1Col,WT_2Col);
						tbl='C';
					}
					else 
					{ 
						if (Oreadr["Aff_ID"].ToString() == ".")
						{
							int iPos=Oreadr["Desc"].ToString().IndexOf("= ",0) ;
							if (iPos>0)
							{
								arr_options[0,0]=Oreadr["Aff_ID"].ToString(); 
								arr_options[0,1]= qty + Oreadr["Desc"].ToString().Substring(0,iPos)+": ";
								//,Oreadr["Desc"].ToString().Substring(iPos+2,Oreadr["Desc"].ToString().Length - iPos-2));
							}
							else
							{
								arr_options[O,0]=Oreadr["Aff_ID"].ToString(); 
								arr_options[O,1]=qty + Oreadr["Desc"].ToString(); 
								arr_options[O,2]=Oreadr["Qty"].ToString(); 
								arr_options[O,3]=Oreadr["Xch_Mult"].ToString(); 
								arr_options[O,4]=Oreadr["Uprice"].ToString(); 
								arr_options[O,5]=Oreadr["LeadTime"].ToString(); 
								O++;
							}
					  
						}
						else
						{
							WPmsg("\n" +Oreadr["Aff_ID"].ToString() + ") " + qty + Oreadr["Desc"].ToString() + ": \n" ,'b',false);
							tbl='N';
						}
					}
				}
				else O =-1;
			}
			if (O>=1)
			{
				WPmsg(arr_options[0,1].ToString () ,'b',false);
				//WPrint2Col('C',arr_options[0,1].ToString ()," ");
				tbl='N';
				for (int t=1;t<O;t++) {WPrint2Col(tbl," ",arr_options[t,1].ToString (),WT_1Col,WT_2Col);tbl='C';}
			}
		}
	*/
	

		private void WPrint2Col(char cod,string c1, string c2,int in_WT_1Col,int in_WT_2Col)
		{
			
			int j=1;
			Word.Table TQdet;
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range  Rng = app.ActiveDocument.Content;
			object direc = Word.WdCollapseDirection.wdCollapseEnd  ;
			Rng.Collapse(ref direc);
			switch (cod)
			{
				case 'N':
					TQdet = Rng.Tables.Add(Rng,1,2 ,ref MissV1,ref MissV2);
					break;
				default:
					TQdet= app.ActiveDocument.Tables[ app.ActiveDocument.Tables.Count ];
					TQdet.Rows.Add(ref MissV1);
					j=TQdet.Rows.Count; 
					break;
			}
			if (c2=="") c2=" ";   //hi
			if (c2[0] != ' ')  c2 =  c2 ;
			//	if (c2[0] != ' ')  c2 = "• " + c2 ;
			//	TQdet.Cell(j,1).Range.Text = "   " + c1 ;
			TQdet.Cell(j,1).Range.Text = c1 ;
			TQdet.Cell(j,2).Range.Text = c2  ;
			TQdet.Cell(j,1).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft    ;
			TQdet.Cell(j,2).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft    ;
			//    TQdet.Cell(j,1).Width= WT_1Col; 
			//	TQdet.Cell(j,2).Width= WT_2Col ;
			//		MessageBox.Show("1W= " + TQdet.Cell(j,1).Width + "    2W= " + TQdet.Cell(j,2).Width);  
			TQdet.Columns[1].Width =in_WT_1Col;
			TQdet.Columns[2].Width =in_WT_2Col;
			

 
			//  .Range(ref start, ref end);
			//		Rng.InsertBreak(ref EOP ); 
			//		Rng.InsertAfter("Comprising: \n");
			//			Rng.Font.Size =8;
			//	int nbL=In_QFrm.lvQITEMS.Items.Count ;
			//			Word.Table TQdet = Rng.Tables.Add(Rng,nbL,2 ,ref MissV1,ref MissV2);
			//			int j=1;



		}
		private void WPrint2PTCOLD(char cod,string c1, string c2,int in_WT_1Col,int in_WT_2Col)
		{
			
			int j=1;
			Word.Table TQdet;
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range  Rng = app.ActiveDocument.Content;
			object direc = Word.WdCollapseDirection.wdCollapseEnd  ;
			Rng.Collapse(ref direc);
			switch (cod)
			{
				case 'N':
					TQdet = Rng.Tables.Add(Rng,1,2 ,ref MissV1,ref MissV2);
					newP=false;
					break;
				default:
					TQdet= app.ActiveDocument.Tables[ app.ActiveDocument.Tables.Count ];
					TQdet.Rows.Add(ref MissV1);
					j=TQdet.Rows.Count; 
					break;
			}
			
			if (c2[0] == '.')  c2 = "• " + c2.Substring(1,c2.Length -1) ;
			if (c2[0] == '!')  {c2 = " ";c1 = " ";}
			TQdet.Cell(j,1).Range.Text = "   " + c1 ;
			//TQdet.Cell(j,2).Row.Alignment = Word.WdRowAlignment.wdAlignRowRight;
			TQdet.Cell(j,2).Range.Text = c2  ;
			Word.Cell cell1 =TQdet.Cell(j,2); 
			if (c2.IndexOf("$")>-1 || c2.IndexOf("EURO")>-1) cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
			else  cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft ;

			//	Word.Range tt= TQdet.Cell(j,2).Column.Select();
			//	tt.Rows.Alignment = Word.WdRowAlignment.wdAlignRowLeft    ;
			

			//	if (c2.IndexOf("$")>-1 || c2.IndexOf("EURO")>-1) TQdet.Cell(j,2).Row.Alignment = Word.WdRowAlignment.wdAlignRowRight ;
			//	else TQdet.Cell(j,2).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft    ;

			//		if (c2.IndexOf("$")>-1 || c2.IndexOf("EURO")>-1) TQdet.Cell(j,2).Row.Alignment = Word.WdRowAlignment.wdAlignRowRight ;
			//	else TQdet.Cell(j,2).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft    ;

			//    TQdet.Cell(j,1).Width= WT_1Col; 
			//	TQdet.Cell(j,2).Width= WT_2Col ;
			//		MessageBox.Show("1W= " + TQdet.Cell(j,1).Width + "    2W= " + TQdet.Cell(j,2).Width);  
		
			
			//		TQdet.Columns[1].Width =in_WT_1Col;
			//		TQdet.Columns[2].Width =in_WT_2Col;
			

 
			//  .Range(ref start, ref end);
			//		Rng.InsertBreak(ref EOP ); 
			//		Rng.InsertAfter("Comprising: \n");
			//			Rng.Font.Size =8;
			//	int nbL=In_QFrm.lvQITEMS.Items.Count ;
			//			Word.Table TQdet = Rng.Tables.Add(Rng,nbL,2 ,ref MissV1,ref MissV2);
			//			int j=1;



		}

    
        private void WPrint2PTC(char cod,string c1, string c2, string c3,int in_WT_1Col,int in_WT_2Col,int in_WT_3Col)
		{
			
			int j=1;
			Word.Table TQdet;
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range  Rng = app.ActiveDocument.Content;
			object direc = Word.WdCollapseDirection.wdCollapseEnd  ;
			Rng.Collapse(ref direc);
			switch (cod)
			{
				case 'N':
					TQdet = Rng.Tables.Add(Rng,1,3 ,ref MissV1,ref MissV2);
					newP=false;
					break;
				default:
					TQdet= app.ActiveDocument.Tables[ app.ActiveDocument.Tables.Count ];
					TQdet.Rows.Add(ref MissV1);
					j=TQdet.Rows.Count; 
					break;
			}
			
			if (c2[0] == '.')  c2 = "• " + c2.Substring(1,c2.Length -1) ;
			if (c2[0] == '!')  {c2 = " ";c1 = " ";c3=" ";}
			TQdet.Cell(j,1).Range.Text = c1;  //"   " + c1 ;
			TQdet.Cell(j,2).Range.Text = c2  ;
			Word.Cell cell1 =TQdet.Cell(j,2); 

			if (c3!=" ") cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
			else  cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft ;
			
			TQdet.Cell(j,3).Range.Text = c3  ;
			cell1 =TQdet.Cell(j,3); 
			cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight ;
			TQdet.Columns[1].Width =290;
			TQdet.Columns[2].Width =130;
			TQdet.Columns[3].Width =100;
			if (c2.IndexOf("Price/Each") >-1) 
			{
				TQdet.Cell(j,3).Range.Font.Bold =1;
				TQdet.Cell(j,2).Range.Font.Bold =1;
				TQdet.Cell(j,2).Range.Font.Underline= Word.WdUnderline.wdUnderlineSingle;
				TQdet.Cell(j,3).Range.Font.Underline= Word.WdUnderline.wdUnderlineSingle;
			}
			else
			{
				TQdet.Cell(j,3).Range.Font.Bold =0;
				TQdet.Cell(j,2).Range.Font.Bold =0;
				TQdet.Cell(j,2).Range.Font.Underline= Word.WdUnderline.wdUnderlineNone ;
				TQdet.Cell(j,3).Range.Font.Underline= Word.WdUnderline.wdUnderlineNone;
			}
		}

		private void WPrint4PTC(char cod,string c1, string c2, string c3,string c4,int in_WT_1Col,int in_WT_2Col,int in_WT_3Col)
		{
			
			int j=1;
			Word.Table TQdet;
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range  Rng = app.ActiveDocument.Content;
			object direc = Word.WdCollapseDirection.wdCollapseEnd  ;
			Rng.Collapse(ref direc);
			switch (cod)
			{
				case 'N':
					TQdet = Rng.Tables.Add(Rng,1,4 ,ref MissV1,ref MissV2);
					newP=false;
					break;
				default:
					TQdet= app.ActiveDocument.Tables[ app.ActiveDocument.Tables.Count ];
					TQdet.Rows.Add(ref MissV1);
					j=TQdet.Rows.Count; 
					break;
			}
			
			if (c2[0] == '.')  c2 = "• " + c2.Substring(1,c2.Length -1) ;
			if (c2[0] == '!')  {c2 = " ";c1 = " ";c3=" ";}
			TQdet.Cell(j,1).Range.Text = c1;  //"   " + c1 ;
			TQdet.Cell(j,2).Range.Text = c2  ;
			Word.Cell cell1 =TQdet.Cell(j,2); 
			if (c4!=" " && c4!="!" ) cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight;
			else
			{
				cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphLeft ;
				c3=" ";
				c4=" ";
			}

			TQdet.Cell(j,3).Range.Text = c3  ;  
			cell1 =TQdet.Cell(j,3); 
			cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphCenter ;
	
			TQdet.Cell(j,4).Range.Text = c4  ;
			cell1 =TQdet.Cell(j,4); 
			cell1.Range.ParagraphFormat.Alignment = Word.WdParagraphAlignment.wdAlignParagraphRight ;
			//cols width
			TQdet.Columns[1].Width =200;
			TQdet.Columns[2].Width =130;
			TQdet.Columns[3].Width =60;
			TQdet.Columns[4].Width =100;
			if (c2.IndexOf("Price/Each") >-1) 
			{
				TQdet.Cell(j,2).Range.Font.Bold =1;
				TQdet.Cell(j,3).Range.Font.Bold =1;
				TQdet.Cell(j,4).Range.Font.Bold =1;
				TQdet.Cell(j,2).Range.Font.Underline= Word.WdUnderline.wdUnderlineSingle;
				TQdet.Cell(j,3).Range.Font.Underline= Word.WdUnderline.wdUnderlineSingle;
				TQdet.Cell(j,4).Range.Font.Underline= Word.WdUnderline.wdUnderlineSingle;
			}
			else
			{
				TQdet.Cell(j,2).Range.Font.Bold =0;
				TQdet.Cell(j,3).Range.Font.Bold =0;
				TQdet.Cell(j,4).Range.Font.Bold =0;
				
				TQdet.Cell(j,2).Range.Font.Underline= Word.WdUnderline.wdUnderlineNone ;
				TQdet.Cell(j,3).Range.Font.Underline= Word.WdUnderline.wdUnderlineNone;
				TQdet.Cell(j,4).Range.Font.Underline= Word.WdUnderline.wdUnderlineNone;
			}
		}

		private void WPmsgbad(string msg,char f,bool Npage)
		{
			Word.Range  Rng = app.ActiveDocument.Content; //  .Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd  ;
			if (Npage)
			{
				Rng.Collapse(ref direc);
				Rng.InsertBreak(ref EOP ); 
				Rng.Collapse(ref direc);
				Rng.Text = " ";
				newP=true;
			}
			Rng = app.ActiveDocument.Content; //  .Range(ref start, ref end);
			direc = Word.WdCollapseDirection.wdCollapseEnd  ;
			Rng.Text = msg;
			if (f=='B' || f=='P' ) Rng.Font.Size =14;
			if (f=='b' || f=='B' || f=='P') Rng.Font.Bold =1;
			if (f=='P') Rng.Font.Underline =Word.WdUnderline.wdUnderlineSingle ;
	

		}

		private void WPmsg(string msg,char f,bool ndrlN,bool Npage)
		{
			Word.Range  Rng = app.ActiveDocument.Content; //  .Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd  ;
			Rng.Collapse(ref direc);
			if (Npage) {Rng.InsertBreak(ref EOP ); newP=true;}
			Rng.Text =msg;
			if (f=='B') Rng.Font.Size =14;
			if (f=='b' || f=='B') Rng.Font.Bold =1;
			if (ndrlN) Rng.Font.Underline =Word.WdUnderline.wdUnderlineSingle ;
			else Rng.Font.Underline =Word.WdUnderline.wdUnderlineNone  ;
	
		}

		private void Page_Q_Details(int nbL)
		{

			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range  Rng = app.ActiveDocument.Content; //  .Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd  ;
			Rng.Collapse(ref direc);
			Rng.InsertBreak(ref EOP ); 
			
			Rng.InsertAfter(MainMDI.arr_EFSdict[36,MainMDI.Lang ]    + ": \n");
			Rng.Font.Size =8;
			//	int nbL=In_QFrm.lvQITEMS.Items.Count ;
			Word.Table TQdet = Rng.Tables.Add(Rng,nbL,2 ,ref MissV1,ref MissV2);
			int j=1;

			for (int i=0;i<In_QFrm.lvQITEMS.Items.Count;i++)
			{   
				//MessageBox.Show("2=" + TQdet.Cell(j,2).Width);
                
				if (In_QFrm.lvQITEMS.Items[i].SubItems[2].Text[0]!='_' && (In_QFrm.lvQITEMS.Items[i].Checked || In_QFrm.chkPrintALL.Checked)   ) 
				{
					//MessageBox.Show(In_QFrm.lvQITEMS.Items[i].SubItems[0].Text+ "\n" + In_QFrm.lvQITEMS.Items[i].SubItems[0].Text);
					string st0=(In_QFrm.lvQITEMS.Items[i].SubItems[1].Text =="") ? " " : In_QFrm.lvQITEMS.Items[i].SubItems[1].Text ;
					string st1=(In_QFrm.lvQITEMS.Items[i].SubItems[2].Text =="") ? " " : In_QFrm.lvQITEMS.Items[i].SubItems[2].Text ;				
					if (st0!=" ")
					{ 
						TQdet.Cell(j,1).Range.Font.Bold=1; TQdet.Cell(j,1).Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle  ;  
						TQdet.Cell(j,2).Range.Font.Bold=1;TQdet.Cell(j,2).Range.Font.Underline =Word.WdUnderline.wdUnderlineSingle;   
					}
					else st1 = "   " + st1;
					string qty=In_QFrm.lvQITEMS.Items[i].SubItems[3].Text +" x ";
					TQdet.Cell(j,1).Range.Text = qty + st0 ;
					TQdet.Cell(j,2).Range.Text =st1  ;
					//		TQdet.Cell(j,1).Width=WT_1Col ;
					TQdet.Cell(j,1).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft    ;
					//		TQdet.Cell(j,2).Width=WT_2Col ;
					TQdet.Cell(j,2).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft    ;
					//	TQdet.Cell(j,2).Width=450 ;
					//TQdet.Cell(j,2).Width   ;
					j++;
				}
			}
			TQdet.Select();
  
			
			//  int nbL=In_QFrm.lvQITEMS.Items.Count ;
			//	for (int i=0;i<nbL;i++) if (In_QFrm.lvQITEMS.Items[i].Checked ) printLine_W(i);
		
		}


		private void Print_ALS_Detail(int nbL)
		{

			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range  Rng = app.ActiveDocument.Content; //  .Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd  ;
			Rng.Collapse(ref direc);
			Rng.InsertBreak(ref EOP ); 
			
			Rng.InsertAfter(MainMDI.arr_EFSdict[36,MainMDI.Lang ]   + ": \n");
			Rng.Font.Size =8;
			//	int nbL=In_QFrm.lvQITEMS.Items.Count ;
			Word.Table TQdet = Rng.Tables.Add(Rng,nbL,2 ,ref MissV1,ref MissV2);
			int j=1;

			for (int i=0;i<In_QFrm.lvQITEMS.Items.Count;i++)
			{   
				//MessageBox.Show("2=" + TQdet.Cell(j,2).Width);
                
				if (In_QFrm.lvQITEMS.Items[i].Checked || In_QFrm.chkPrintALL.Checked   ) 
				{
					//MessageBox.Show(In_QFrm.lvQITEMS.Items[i].SubItems[0].Text+ "\n" + In_QFrm.lvQITEMS.Items[i].SubItems[0].Text);
					string st0=(In_QFrm.lvQITEMS.Items[i].SubItems[1].Text =="") ? " " : In_QFrm.lvQITEMS.Items[i].SubItems[1].Text ;
					string st1=(In_QFrm.lvQITEMS.Items[i].SubItems[2].Text =="") ? " " : In_QFrm.lvQITEMS.Items[i].SubItems[2].Text ;				
					if (st0!=" ")
					{ 
						TQdet.Cell(j,1).Range.Font.Bold=1; TQdet.Cell(j,1).Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle  ;  
						TQdet.Cell(j,2).Range.Font.Bold=1;TQdet.Cell(j,2).Range.Font.Underline =Word.WdUnderline.wdUnderlineSingle;   
					}
					else st1 = "   " + st1;
					TQdet.Cell(j,1).Range.Text = st0 ;
					TQdet.Cell(j,2).Range.Text =st1  ;
					//	TQdet.Cell(j,1).Width= WT_1Col ;
					TQdet.Cell(j,1).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft    ;
	
					//	TQdet.Cell(j,2).Width=WT_2Col ;
					TQdet.Cell(j,2).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft    ;
					//TQdet.Cell(j,2).Width=450 ;
					//TQdet.Cell(j,2).Width   ;
					j++;
				}
			}
			TQdet.Select();
  
			
			//  int nbL=In_QFrm.lvQITEMS.Items.Count ;
			//	for (int i=0;i<nbL;i++) if (In_QFrm.lvQITEMS.Items[i].Checked ) printLine_W(i);
			

		}

		private void Fermer_App(string OfName)
		{
			object fn=OfName.Replace(".doc","").Replace("'","_") ;
			object ff=Type.Missing;
			object lc=Type.Missing;
			object pwd=Type.Missing;
			object atr=Type.Missing;
			object wpwd=Type.Missing;
			object ron=Type.Missing;
			object embd=Type.Missing;
			object svN=Type.Missing;
			object svF=Type.Missing;
			object svLett=Type.Missing;
			object enc=Type.Missing;
			object inLin=Type.Missing;
			object Asub=Type.Missing;
			object Linend=Type.Missing;
			object addmrk=Type.Missing;
			app.ActiveDocument.SaveAs(ref fn,ref ff,ref lc,ref pwd,ref atr,ref wpwd,ref ron,ref embd ,ref svN,ref svF,ref svLett,ref enc,ref inLin ,ref Asub,ref Linend,ref addmrk );   
			object sv=Type.Missing ;
			object of=Type.Missing ;
			object rd=Type.Missing ;
			app.ActiveDocument.Close(ref sv,ref of,ref rd);
			app.Quit(ref sv,ref of,ref rd);

		}


		/*
		private void Page_Prices_ALS_sum()
		{
			Object MissV1 = Type.Missing;
			Object MissV2 = Type.Missing;
			Word.Range  Rng = app.ActiveDocument.Content; //  .Range(ref start, ref end);
			object direc = Word.WdCollapseDirection.wdCollapseEnd  ;
			Rng.Collapse(ref direc);
			Rng.InsertBreak(ref EOP ); 
			
			Rng.InsertAfter(": \n");
			Rng.Font.Size =8;
			//	int nbL=In_QFrm.lvQITEMS.Items.Count ;
			Word.Table TQdet = Rng.Tables.Add(Rng,nbL,2 ,ref MissV1,ref MissV2);
			int j=1;

			for (int i=0;i<In_QFrm.lvQITEMS.Items.Count;i++)
			{   
				//MessageBox.Show("2=" + TQdet.Cell(j,2).Width);
                
				if (In_QFrm.lvQITEMS.Items[i].Checked || In_QFrm.chkPrintALL.Checked   ) 
				{
					//MessageBox.Show(In_QFrm.lvQITEMS.Items[i].SubItems[0].Text+ "\n" + In_QFrm.lvQITEMS.Items[i].SubItems[0].Text);
					string st0=(In_QFrm.lvQITEMS.Items[i].SubItems[1].Text =="") ? " " : In_QFrm.lvQITEMS.Items[i].SubItems[1].Text ;
					string st1=(In_QFrm.lvQITEMS.Items[i].SubItems[2].Text =="") ? " " : In_QFrm.lvQITEMS.Items[i].SubItems[2].Text ;				
					if (st0!=" ")
					{ 
						TQdet.Cell(j,1).Range.Font.Bold=1; TQdet.Cell(j,1).Range.Font.Underline = Word.WdUnderline.wdUnderlineSingle  ;  
						TQdet.Cell(j,2).Range.Font.Bold=1;TQdet.Cell(j,2).Range.Font.Underline =Word.WdUnderline.wdUnderlineSingle;   
					}
					else st1 = "   " + st1;
					TQdet.Cell(j,1).Range.Text = st0 ;
					TQdet.Cell(j,2).Range.Text =st1  ;
					TQdet.Cell(j,1).Width=20 ;
					TQdet.Cell(j,1).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft    ;
	
					TQdet.Cell(j,2).Width=450 ;TQdet.Cell(j,2).Row.Alignment = Word.WdRowAlignment.wdAlignRowLeft    ;
					TQdet.Cell(j,2).Width=450 ;
					//TQdet.Cell(j,2).Width   ;
					j++;
				}
			}
			TQdet.Select();



		}
         * 
         * 
    

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
            app.ActiveDocument.SaveAs(ref fn, ref ff, ref lc, ref pwd, ref atr, ref wpwd, ref ron, ref embd, ref svN, ref svF, ref svLett, ref enc, ref inLin, ref Asub, ref Linend, ref addmrk);
            object sv = Type.Missing;
            object of = Type.Missing;
            object rd = Type.Missing;
            app.ActiveDocument.Close(ref sv, ref of, ref rd);
            app.Quit(ref sv, ref of, ref rd);
        }

/*******************************************
 * ventilation de la Revision dans Excel 
 * *****************************************************/
        private void QT_XL_QuotVentil()
        {


            object[] objHdrs = { "Alternative Name", "System Name", "Item Description", "QTY", "Unit Price", "Amount" };

            //// for (int i = 0; i < NBCols; i++) objHdrs[i] = ed_LVallInvoices.Columns[i].Text;//ed_lvITM.Columns[i+2].Text;

            int LL = 0;
            string Fname = "Vent_Quote.xlsx";
            string CellFM = "A3", CellTO = "F3";

            object[,] objData = new object[MainMDI.MAX_XLlines_XPRT, VQ_Cols];
            for (int i = 0; i < MainMDI.MAX_XLlines_XPRT; i++)
            {
                if (arr_VQ[i, 0] != "~~||")
                {
                    for (int j = 0; j < VQ_Cols; j++) objData[i, j] = arr_VQ[i, j];

                }
                else { LL = i; i = MainMDI.MAX_XLlines_XPRT; }

            }
            XL_EXPORT_Image (Fname, objHdrs, VQ_Cols, CellFM, CellTO, objData);

        }
       int QT_fill_XL_Header()
        {
            int LL = 0;
           
            for (int i = 0; i < VQ_Lines; i++) for (int j = 0; j < VQ_Cols; j++) arr_VQ[i, j] = "";
            arr_VQ[LL++, 0] = "PRIMAX TECHNOLOGIES INC.";
            arr_VQ[LL++, 0] = "65 Hymus Blvd., Pointe-Claire, Québec, Canada, H9R 1E2";
            arr_VQ[LL++, 0] = "Tel: 514-459-9990, Fax: 514-459-9991";

            LL++;
            arr_VQ[LL, 0] = "TO: " + In_QFrm.cbContacts.Text; 
            arr_VQ[LL++,3 ] = "Quote#: " + In_QFrm.tQuoteID.Text +"-"+ In_QFrm.lCurSoln.Text.Substring(3,In_QFrm.lCurSoln.Text.Length -3);
            arr_VQ[LL++, 0] = "COMPANY: " + In_QFrm.lCpnyName.Text;
            arr_VQ[LL, 0] = "FROM: " + In_QFrm.cbEmploy.Text;
            arr_VQ[LL++, 3] = "YOUR REF: " + In_QFrm.tProjNAME.Text;
            arr_VQ[LL, 0] = "TEL: " + In_QFrm.lConTel.Text;
            arr_VQ[LL++, 3] = "DATE: " + In_FC.tCQRdate.Text;
            arr_VQ[LL++, 0] = "FAX: " + In_QFrm.lConFax.Text;
            LL=11;
            arr_VQ[LL, 0] = "Alternative Name";
           arr_VQ[LL, 1] = "System Name";
           arr_VQ[LL, 2] = "Item Description";
           arr_VQ[LL, 3] ="QTY";
           arr_VQ[LL, 4] ="Unit Price";
           arr_VQ[LL++,5] = "Amount";
            return LL;

        }
       int QT_fill_XL_Footer(int LL)
       {


           arr_VQ[LL, 0] = ""; arr_VQ[LL++, 0] = ""; arr_VQ[LL++, 0] = "";

           arr_VQ[LL++, 0] = "Prices, Terms and Conditions: ";
           debTerm = LL;

           //arr_VQ[LL, 0] ="  ";
           //arr_VQ[LL, 1] = "Price/Each USD";
           //arr_VQ[LL, 2] = " QTY ";
           //arr_VQ[LL++, 3] = "Total USD";

           for (int t = 0; t < 20;t++ )
           {
               if (arr_terms[t, 0] != "~~||")
               {
                   if (arr_terms[t, 3] == " ") 
                   {
                       arr_VQ[LL, 0] = arr_terms[t, 0] + ":   " + arr_terms[t, 1];
                       LL++;
                   }
                   
                
               }
               else t = 20;
           }
           arr_VQ[LL, 0] = "~~||";
           return LL;

       }

        public void QT_Send_ALL_QuoteTO_XL()
        {
            debRev = QT_fill_XL_Header();
            finRev = QT_REVTO_arrXL(debRev);

         finTerm = QT_fill_XL_Footer(finRev );
         QT_XL_QuotVentil();
            
        }

        //new Quote Print using EXCEL file
        public void QT_NEWPRINT_TOXL()
        {
            debRev = QT_fill_XL_Header();
            finRev = QT_REVTO_arrXL(debRev);

            finTerm = QT_fill_XL_Footer(finRev);
            QT_XL_QuotVentil();

        }



       int QT_REVTO_arrXL_tst(int LL)
        {
            double d_ALSQTY = 0;
            int CC = 0;



          //  for (int i = 0; i < VQ_Lines; i++) for (int j = 0; j < VQ_Cols; j++) arr_VQ[i, j] = "";
            string IQID = In_QFrm.lCurrIQID.Text;
            string SolName = In_QFrm.lCurSoln.Text;
            string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* " +
                " FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " WHERE (PSM_Q_IGen.i_Quoteid=" + IQID + " and PSM_Q_SOL.Sol_Name='" + SolName + "') ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string Nsol = "", Ospc = "", Nspc = "", Nals = "", Oals = "";
            char tbl = 'C';
            double ALSTOT = 0, SPCTOT = 0;
            
            while (Oreadr.Read())
            {
                //alsAdded=false;
                if (Oreadr["Desc"].ToString()[0] != '_')
                {
                    if (Nsol == "") Nsol = Oreadr["Sol_Name"].ToString();
                    Nspc = Oreadr["SPC_Name"].ToString();
                    Nals = Oreadr["ALS_Name"].ToString();
                    if (Ospc != Nspc)
                    {
                        ////08122016
                        //if (Oals != Nals)
                        //{
                        //    if (Oals != "")
                        //    {
                        //        arr_VQ[LL, 1] = "TOTAL " + Oals;
                        //        arr_VQ[LL++, 5] = ALSTOT.ToString();

                        //    }
                        //    // string qt = (Oreadr["AlsQty"].ToString() != "1") ? " QTY=" + Oreadr["AlsQty"].ToString() + ": " : ": ";
                        //    d_ALSQTY = Tools.Conv_Dbl(Oreadr["AlsQty"].ToString());
                        //    arr_VQ[LL++, 1] = Nals;// +" " + qt;
                        //    Oals = Nals;
                        //    ALSTOT = 0;

                        //}
                        ////08122016


                        if (Ospc != "")
                        {
                            arr_VQ[LL, 0] = "TOTAL " + Ospc;
                            arr_VQ[LL++, 5] = SPCTOT.ToString();

                        }
                        bool et = (Ospc == "") ? false : true;
                        arr_VQ[LL++, 0] = Nspc;  //alter Name
                        Ospc = Nspc;
                        tbl = 'N';
                    }
                    if (Oals != Nals)
                    {
                        if (Oals != "")
                        {
                            arr_VQ[LL, 1] = "TOTAL " + Oals;
                            arr_VQ[LL++, 5] = ALSTOT.ToString();

                        }
                        // string qt = (Oreadr["AlsQty"].ToString() != "1") ? " QTY=" + Oreadr["AlsQty"].ToString() + ": " : ": ";
                        d_ALSQTY = Tools.Conv_Dbl(Oreadr["AlsQty"].ToString());
                        arr_VQ[LL++, 1] = Nals;// +" " + qt;
                        Oals = Nals;
                        ALSTOT = 0;

                    }
                    //debut detail
                    // string qty = (Oreadr["Qty"].ToString() != "0" && Oreadr["Qty"].ToString() != " " && Oreadr["Qty"].ToString() != "") ? Oreadr["Qty"].ToString() + " x " : "";

                    string sep = (Oreadr["Aff_ID"].ToString() == " ") ? "    " : Oreadr["Aff_ID"].ToString() + "- ";
                    //  string H_itemP4600TXT = (MainMDI.Lang == 0) ? @"PC23 c/w touch screen, P4600 overlay and cabinet door cutout" : "PC23 incluant écran tactil, membrane et ouverture dans la porte";
                    // bool H_itemP4600 = (Oreadr["Desc"].ToString() == H_itemP4600TXT);
                    arr_VQ[LL, 2] = sep + NoCode(Oreadr["Desc"].ToString());
               //     double d_itemqty = d_ALSQTY * Tools.Conv_Dbl(Oreadr["Qty"].ToString());  // use ALS qty
                    double d_itemqty = Tools.Conv_Dbl(Oreadr["Qty"].ToString());
                    arr_VQ[LL, 3] = (d_itemqty != 0) ? d_itemqty.ToString() : " ";
                    double dd_UP = Tools.Conv_Dbl(Oreadr["Mult"].ToString()) * Tools.Conv_Dbl(Oreadr["Uprice"].ToString());
                    arr_VQ[LL, 4] = (dd_UP != 0) ? dd_UP.ToString() : " ";
                    double dd_Ext = dd_UP * d_itemqty;
                    ALSTOT += dd_Ext;
                    SPCTOT += dd_Ext;
                    arr_VQ[LL++, 5] = (dd_Ext != 0) ? dd_Ext.ToString() : " ";// Oreadr["Ext"].ToString();

                }

            }
            if (ALSTOT != 0)
            {
                arr_VQ[LL, 1] = "TOTAL " + Nals;
                arr_VQ[LL++, 5] = ALSTOT.ToString();
            }
            if (SPCTOT != 0)
            {
                arr_VQ[LL, 0] = "TOTAL " + Nspc;
                arr_VQ[LL++, 5] = SPCTOT.ToString();
            }

            arr_VQ[LL, 0] = "~~||";
            return LL;

        }

       int QT_REVTO_arrXL(int LL)
       {
           double d_ALSQTY = 0;
           int CC = 0;



           //  for (int i = 0; i < VQ_Lines; i++) for (int j = 0; j < VQ_Cols; j++) arr_VQ[i, j] = "";
           string IQID = In_QFrm.lCurrIQID.Text;
           string SolName = In_QFrm.lCurSoln.Text;
           string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* " +
               " FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
               " WHERE (PSM_Q_IGen.i_Quoteid=" + IQID + " and PSM_Q_SOL.Sol_Name='" + SolName + "') ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";


           SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
           OConn.Open();
           SqlCommand Ocmd = OConn.CreateCommand();
           Ocmd.CommandText = stSql;
           SqlDataReader Oreadr = Ocmd.ExecuteReader();
           string Nsol = "", Ospc = "", Nspc = "", Nals = "", Oals = "";
           char tbl = 'C';
           double ALSTOT = 0, SPCTOT = 0;
           string oldALS = "", oldALStot = "",oldALSqty="";
           while (Oreadr.Read())
           {
               //alsAdded=false;
               if (Oreadr["Desc"].ToString()[0] != '_')
               {
                   if (Nsol == "") Nsol = Oreadr["Sol_Name"].ToString();
                   Nspc = Oreadr["SPC_Name"].ToString();
                   Nals = Oreadr["ALS_Name"].ToString();


                   if (Ospc != Nspc)
                   {
                       if (Ospc != "")
                       {
                           if (Oals != "")
                           {
                               arr_VQ[LL, 1] = "TOTAL " + oldALS;
                               arr_VQ[LL++, 5] = oldALStot;
                               Oals = "";
                               ALSTOT = 0;
                           }


                           arr_VQ[LL, 0] = "TOTAL " + Ospc;
                           arr_VQ[LL++, 5] = SPCTOT.ToString();

                       }
                       bool et = (Ospc == "") ? false : true;
                       arr_VQ[LL++, 0] = Nspc;  //alter Name
                       Ospc = Nspc;
                       tbl = 'N';
                   }
                   if (Oals != Nals)
                   {
                       if (Oals != "")
                       {
                           arr_VQ[LL, 1] = "TOTAL " + Oals;
                           arr_VQ[LL++, 5] = ALSTOT.ToString();


                       }
                       // string qt = (Oreadr["AlsQty"].ToString() != "1") ? " QTY=" + Oreadr["AlsQty"].ToString() + ": " : ": ";
                       d_ALSQTY = Tools.Conv_Dbl(Oreadr["AlsQty"].ToString());
                       arr_VQ[LL++, 1] = Nals;// +" " + qt;
                       Oals = Nals;
                       ALSTOT = 0;

                   }
                   oldALS = Oreadr["ALS_Name"].ToString();
                   oldALStot = Oreadr["Tot"].ToString();
                   oldALSqty = Oreadr["AlsQty"].ToString();

                   //debut detail
                   // string qty = (Oreadr["Qty"].ToString() != "0" && Oreadr["Qty"].ToString() != " " && Oreadr["Qty"].ToString() != "") ? Oreadr["Qty"].ToString() + " x " : "";

                   string sep = (Oreadr["Aff_ID"].ToString() == " ") ? "    " : Oreadr["Aff_ID"].ToString() + "- ";
                   //  string H_itemP4600TXT = (MainMDI.Lang == 0) ? @"PC23 c/w touch screen, P4600 overlay and cabinet door cutout" : "PC23 incluant écran tactil, membrane et ouverture dans la porte";
                   // bool H_itemP4600 = (Oreadr["Desc"].ToString() == H_itemP4600TXT);
                   arr_VQ[LL, 2] = sep + NoCode(Oreadr["Desc"].ToString());
                   //     double d_itemqty = d_ALSQTY * Tools.Conv_Dbl(Oreadr["Qty"].ToString());  // use ALS qty
                   double d_itemqty = Tools.Conv_Dbl(Oreadr["Qty"].ToString());
                   arr_VQ[LL, 3] = (d_itemqty != 0) ? d_itemqty.ToString() : " ";
                   double dd_UP = Tools.Conv_Dbl(Oreadr["Mult"].ToString()) * Tools.Conv_Dbl(Oreadr["Uprice"].ToString());
                   arr_VQ[LL, 4] = (dd_UP != 0) ? dd_UP.ToString() : " ";
                   double dd_Ext = dd_UP * d_itemqty;
                   ALSTOT += dd_Ext;
                   SPCTOT += dd_Ext;
                   arr_VQ[LL++, 5] = (dd_Ext != 0) ? dd_Ext.ToString() : " ";// Oreadr["Ext"].ToString();

               }

           }
           if (ALSTOT != 0)
           {
               arr_VQ[LL, 1] = "TOTAL " + Nals;
               arr_VQ[LL++, 5] = ALSTOT.ToString();
           }
           if (SPCTOT != 0)
           {
               arr_VQ[LL, 0] = "TOTAL " + Nspc;
               arr_VQ[LL++, 5] = SPCTOT.ToString();
           }

           arr_VQ[LL, 0] = "~~||";
           return LL;

       }
        private void XL_EXPORT_Image(string FName, object[] objHdrs, int HdrsNB, string CellFM, string CellTO, object[,] objData)
        {

            System.IO.File.Delete(MainMDI.XL_Path + @"\" + FName);// "CMS_CALC.xls");
            Object m_objOpt = System.Reflection.Missing.Value;
            Excel.Application m_objXL = new Excel.Application();
            Excel.Workbooks m_objbooks = m_objXL.Workbooks;
            Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);
            Excel.Sheets m_objSheets = m_objBook.Worksheets;
            Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

            m_objSheet.Shapes.AddPicture(MainMDI.XL_Path + "\\primax.JPG", Microsoft.Office.Core.MsoTriState.msoFalse, Microsoft.Office.Core.MsoTriState.msoCTrue,10,10,200,40); 

         //   Excel.Range m_objRng = m_objSheet.get_Range(CellFM, CellTO);


            Excel.Range m_objRng = m_objSheet.get_Range("A5", m_objOpt);
            m_objRng = m_objRng.get_Resize(MainMDI.MAX_XLlines_XPRT, HdrsNB);
            m_objRng.Value2 = objData;
            int L_hdr = 16;//= 11 + 5;
            m_objRng = m_objSheet.get_Range("A" + L_hdr.ToString(), "F" + L_hdr.ToString());
               //m_objRng.Value2 = objHdrs;
               Excel.Font m_objFont = m_objRng.Font;
               m_objFont.Bold = true;

               m_objRng = m_objSheet.get_Range("A5:A5" , m_objOpt);  //cel5-cel7
               m_objRng.Font.Size = 16;
               m_objRng.Font.Bold = true;

               m_objRng = m_objSheet.get_Range("A6:A7", m_objOpt);  
               m_objRng.Font.Bold = true;

               m_objRng = m_objSheet.get_Range("A9:D13", m_objOpt);  
               m_objRng.Font.Bold = true;

            //terms
               m_objRng = m_objSheet.get_Range("A" + (debTerm + 4).ToString() + ":A" + (debTerm + 4).ToString(), m_objOpt);
               m_objRng.Font.Size = 16;
               m_objRng.Font.Bold = true;

               m_objRng = m_objSheet.get_Range("A" + (debTerm + 5).ToString() + ":A" + (finTerm  + 5).ToString(), m_objOpt);
               m_objRng.Font.Bold = true;

            m_objRng = m_objSheet.get_Range("A:B", m_objOpt);
            m_objRng.EntireColumn.ColumnWidth = 20;

            m_objRng = m_objSheet.get_Range("D:D", m_objOpt);
            m_objRng.EntireColumn.ColumnWidth = 5;

            m_objRng = m_objSheet.get_Range("E:F", m_objOpt);
            m_objRng.EntireColumn.ColumnWidth = 15;

            m_objRng = m_objSheet.get_Range("C:C", m_objOpt);
            m_objRng.EntireColumn.ColumnWidth = 80;
            m_objRng.EntireColumn.WrapText = true;
       //     string rr=
            m_objRng = m_objSheet.get_Range("A" +L_hdr.ToString () + ":F"+(finRev +5).ToString() , m_objOpt);
            m_objRng.Borders.Weight = Excel.XlBorderWeight.xlThin;

          //  m_objRng = m_objSheet.get_Range("A" + L_hdr.ToString() + ":F" + (finRev + 5).ToString(), m_objOpt);
          //  m_objRng.Borders.Weight = Excel.XlBorderWeight.xlThin;


            m_objBook.SaveAs(MainMDI.XL_Path + @"\" + FName, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();

            MainMDI.EXEC_FILE("EXCEL.exe", MainMDI.XL_Path + @"\" + FName);
        }




        public void QuoteTO_XLfile()
        {
            REVTO_arrXL();
            XL_QuotVentil();
        }



       void REVTO_arrXL()
        {
            double d_ALSQTY = 0;
            int LL=0, CC=0;



            for (int i = 0; i < VQ_Lines; i++) for (int j = 0; j < VQ_Cols; j++) arr_VQ[i, j] = "";
            string IQID = In_QFrm.lCurrIQID.Text;
            string SolName = In_QFrm.lCurSoln.Text;
            string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* " +
                " FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " WHERE (PSM_Q_IGen.i_Quoteid=" + IQID + " and PSM_Q_SOL.Sol_Name='" + SolName + "') ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";

     
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string Nsol = "", Ospc = "", Nspc = "", Nals = "", Oals = "";
            char tbl = 'C';
            double ALSTOT = 0,SPCTOT=0;

            while (Oreadr.Read())
            {
                //alsAdded=false;
                if (Oreadr["Desc"].ToString()[0] != '_')
                {
                    if (Nsol == "") Nsol = Oreadr["Sol_Name"].ToString();
                    Nspc = Oreadr["SPC_Name"].ToString();
                    Nals = Oreadr["ALS_Name"].ToString();
                    if (Ospc != Nspc)
                    {
                        if (Ospc != "")
                        {
                            arr_VQ[LL, 0] = "TOTAL " + Ospc;
                            arr_VQ[LL++, 5] = SPCTOT.ToString();

                        }
                        bool et = (Ospc == "") ? false : true;
                        arr_VQ[LL++, 0] = Nspc;  //alter Name
                        Ospc = Nspc;
                        tbl = 'N';
                    }
                    if (Oals != Nals)
                    {
                        if (Oals != "")
                        {
                            arr_VQ[LL, 1] = "TOTAL " + Oals;
                            arr_VQ[LL++, 5] = ALSTOT.ToString();

                        }
                        // string qt = (Oreadr["AlsQty"].ToString() != "1") ? " QTY=" + Oreadr["AlsQty"].ToString() + ": " : ": ";
                        d_ALSQTY = Tools.Conv_Dbl(Oreadr["AlsQty"].ToString());
                        arr_VQ[LL++, 1] = Nals;// +" " + qt;
                        Oals = Nals;
                        ALSTOT = 0;

                    }
                    //debut detail
                    // string qty = (Oreadr["Qty"].ToString() != "0" && Oreadr["Qty"].ToString() != " " && Oreadr["Qty"].ToString() != "") ? Oreadr["Qty"].ToString() + " x " : "";

                    string sep = (Oreadr["Aff_ID"].ToString() == " ") ? "    " : Oreadr["Aff_ID"].ToString() + "- ";
                    //  string H_itemP4600TXT = (MainMDI.Lang == 0) ? @"PC23 c/w touch screen, P4600 overlay and cabinet door cutout" : "PC23 incluant écran tactil, membrane et ouverture dans la porte";
                    // bool H_itemP4600 = (Oreadr["Desc"].ToString() == H_itemP4600TXT);
                    arr_VQ[LL, 2] = sep + NoCode(Oreadr["Desc"].ToString());
                    double d_itemqty = d_ALSQTY * Tools.Conv_Dbl(Oreadr["Qty"].ToString());
                    arr_VQ[LL, 3] = (d_itemqty != 0) ? d_itemqty.ToString() : " ";
                    double dd_UP = Tools.Conv_Dbl(Oreadr["Mult"].ToString()) * Tools.Conv_Dbl(Oreadr["Uprice"].ToString());
                    arr_VQ[LL, 4] = (dd_UP != 0) ? dd_UP.ToString() : " ";
                    double dd_Ext = dd_UP * d_itemqty;
                    ALSTOT += dd_Ext;
                    SPCTOT += dd_Ext;
                    arr_VQ[LL++, 5] = (dd_Ext != 0) ? dd_Ext.ToString() : " ";// Oreadr["Ext"].ToString();

                }
                    
            }
            if (ALSTOT  != 0)
            {
                arr_VQ[LL, 1] = "TOTAL " + Nals;
                arr_VQ[LL++, 5] = ALSTOT.ToString();
            }
            if (SPCTOT != 0)
            {
                arr_VQ[LL, 0] = "TOTAL " + Nspc;
                arr_VQ[LL++, 5] = SPCTOT.ToString();
            }

            arr_VQ[LL, 0] = "~~||";
 
        }

	string NoCode(string desc)
       {

           int ipos = desc.IndexOf("[");
          if (ipos>-1) 
          {
              int ipos2 = desc.IndexOf("]", ipos);
              if ((ipos2 >-1) && (ipos2 -ipos) ==15)    return desc.Substring(0,ipos );
          
          }
          return desc;
 

       }


        private void XL_QuotVentil()
        {
            

            object[] objHdrs = { "Alternative Name", "System Name", "Item Description", "QTY", "Unit Price", "Amount" };

           //// for (int i = 0; i < NBCols; i++) objHdrs[i] = ed_LVallInvoices.Columns[i].Text;//ed_lvITM.Columns[i+2].Text;


            string Fname = "Vent_Quote.xlsx";
            string CellFM = "A1", CellTO = "F1";

            object[,] objData = new object[MainMDI.MAX_XLlines_XPRT,VQ_Cols ];
            for (int i = 0; i < MainMDI.MAX_XLlines_XPRT; i++)
            {
                if (arr_VQ[i, 0] != "~~||")
                {
                    for (int j = 0; j < VQ_Cols; j++) objData[i, j] =arr_VQ[i,j];

                }
                else i = MainMDI.MAX_XLlines_XPRT;

            }
            XL_EXPORT(Fname, objHdrs, VQ_Cols, CellFM, CellTO, objData);

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
            //modif

            m_objRng = m_objSheet.get_Range("A:B", m_objOpt);
            m_objRng.EntireColumn.AutoFit();
            m_objRng = m_objSheet.get_Range("D:F", m_objOpt);
            m_objRng.EntireColumn.AutoFit();

            m_objRng = m_objSheet.get_Range("C:C", m_objOpt);
            m_objRng.EntireColumn.ColumnWidth =80;
          //  m_objRng.EntireColumn.AutoFit(); long de ligne au max
            m_objRng.EntireColumn.WrapText = true;

            m_objRng = m_objSheet.get_Range("A:F", m_objOpt);
            m_objRng.Borders.Weight = Excel.XlBorderWeight.xlThin;

//      mettre background Color des totaux



            //  m_objRng.EntireColumn.AutoFit(); long de ligne au max
           // m_objRng.EntireColumn.WrapText = true;


            //modif
            m_objBook.SaveAs(MainMDI.XL_Path + @"\" + FName, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();
            //  ??? NO  data
            //   MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\" + FName);

            MainMDI.EXEC_FILE("EXCEL.exe", MainMDI.XL_Path + @"\" + FName);
        }



	}
}
