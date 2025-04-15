using System;
using System.Windows.Forms ;
using OutL = Microsoft.Office.Interop.Outlook     ;
using System.Collections ; 
using VB = Microsoft.VisualBasic  ;
using System.Data ;
using System.Data.OleDb ;
using System.Data.SqlClient ;
using EAHLibs;


namespace PGESCOM
{
	/// <summary>
	/// Summary description for FichWord.
	/// </summary>
	public class FichOutlook
	{
        
		
        private string In_email;
	//	private	OutL.Application app=new  OutL.ApplicationClass();
		public FichOutlook(string x_email )
		{
		   In_email = x_email; 	
   	    
			//MessageBox.Show( "QID= " + In_QFrm.tQuoteID.Text ); 
			
		
            
		}



	

	}
}
