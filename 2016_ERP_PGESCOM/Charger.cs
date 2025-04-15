using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb ;
using System.Data.SqlClient ;
using EAHLibs;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for Charger.
	/// </summary>
	public class Charger
	{

		public static readonly  int NB_FRML=200;

		public static readonly  int NB_MODELS=100;
		public static readonly  int NB_FRML_Flds=6;
		public static readonly  int NB_MODELS_Flds=12;
		public static readonly  int IMAX_ARR_REALV = 80;

		public static readonly  string VIDE="n/a";
		public static readonly  int NB_DEC_CAL=10;
		public static readonly  int NB_DEC_AFF=2;
		private Lib1 Tools = new Lib1();

		public static  long ISave=0;
		public static string[,] arr_FRML  = new string[NB_FRML,NB_FRML_Flds];
		public static string[] arr_CAL_FRML  = new string[NB_FRML];
		public static string[,] arr_CModels = new string[NB_MODELS,NB_MODELS_Flds];
		public static string[,] arr_REALV  = new string[IMAX_ARR_REALV,8];
	//	public static string MainMDI.M_stCon;
        public static string In_VcsTblName;
		public static string Real_C;
		public static string C;
		public static string P;
		public static string V;
		public static string I;
		public static string FV ;
        public static long AvailId;
		public static int lblIRealV;
		

      //  public Component[]  Cpt_List=new Component[100] ;   //=new Component(
		
			
		public Charger(long x_AvailID,string x_FV,string x_Chrgr, string x_phs,string x_Vdc,string x_Idc, string x_VAC, string x_VDCMAX)
		{
			//
			// TODO: Add constructor logic here
			//
			Real_C= x_Chrgr;
			C=x_Chrgr.Substring(0,5); //added bcz P4500 are same P4500TT, TT, F 

			P=x_phs;
			V=x_Vdc;
			I=x_Idc ;
			MainMDI.M_stCon = MainMDI.M_stCon  ;
		//	In_VcsTblName= "COMPUTE_VCS" + ((x_FV =="F" && x_Chrgr=="P4500") ? "" : "_" + x_FV + "_" + x_Chrgr);
			In_VcsTblName= "COMPUTE_VCS"; //  + ((x_FV =="F" && x_Chrgr=="P4500") ? "" : "_" + x_FV + "_" + x_Chrgr);
	     	Init_arr_RealV(In_VcsTblName);
		//	AvailId= (x_AvailID !=0) ? x_AvailID : Find_AvailID();
			AvailId= x_AvailID ;
			if (x_AvailID==0) AvailId= Find_AvailID();
        	Load_arr_FRML(In_VcsTblName );
		//	Load_arr_CModel( );
			init_arr_CAL_FRML(Tools.Conv_Dbl(x_VAC) ,Tools.Conv_Dbl(x_VDCMAX) );
	
			//	Cpt_List[0]=new Component(In_VcsTblName,C,P,V,I,AvailId); 
		//	Component  Cpt= new Component(In_VcsTblName,C,P,V,I,AvailId);
		}

		private long Find_AvailID()
		{

			string stSql= "SELECT Avail_ID FROM TBLAVAIL" + P + " WHERE (charger='" + C +"' AND vdc='" + V + "' AND idc='" + I + "')";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ())
			{  
				return Convert.ToInt32 (Oreadr["Avail_ID"].ToString ());
			}
			OConn.Close (); 
			//return 0;
			return -1;
		}

		private bool Load_arr_FRML(string VcsTblName)
		{
		    
			init_arr_Frml();
			string stSql = "select * from " + VcsTblName ;
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			int i=0;
			if (Oreadr.FieldCount != NB_FRML_Flds ) MessageBox.Show ("VCS Table is Empty or Fields# is Invalid....must be= "+NB_FRML_Flds.ToString ());
			while (Oreadr.Read ()) 
			{
				for (int j=0;j<Oreadr.FieldCount;j++) arr_FRML[i,j]=  Oreadr[j].ToString();
				i++;
			}
	        OConn.Close (); 
			return (arr_FRML[0,0] != "") ;  
		}


		private void Init_arr_RealV(string VcsTblName)
		{
			for (int i = 0;i< IMAX_ARR_REALV;i++)
				for (int j = 0;j< 8;j++)  arr_REALV[i, j] = "";
			lblIRealV = 0;
		}
		private void init_arr_Frml()
		{
			for (int i=0;i<NB_FRML  ;i++)
				for (int j=0;j< NB_FRML_Flds ;j++)
					arr_FRML[i,j]="";
		}
		private void init_arr_Models()
		{
			for (int i=0;i<NB_MODELS   ;i++)
				for (int j=0;j<NB_MODELS_Flds ;j++)
					arr_CModels[i,j]="";
		}

		private bool Load_arr_CModel()
		{ 

/*
			init_arr_Models();
			string stSql = "select * from COMPUTE_MODELS ";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			int i=0;
			if (Oreadr.FieldCount != NB_MODELS_Flds ) MessageBox.Show ("Models Table is Empty or Fields# is Invalid....must be= "+NB_MODELS_Flds.ToString ());
			while (Oreadr.Read ()) 
			{
				for (int j=0;j<Oreadr.FieldCount;j++) arr_CModels[i,j]=  Oreadr[j].ToString();
				i++;
			}
	        OConn.Close (); 
			return (arr_CModels[0,0] != "") ;  
	*/
			return true;
		}


		private void init_arr_CAL_FRML(double Vac,double vdcMAX)
		{
			arr_CAL_FRML[0] = VIDE ;
		//	arr_CAL_FRML[0] = "U_CHARGER_R||" + Real_C ;
			arr_CAL_FRML[1] = "U_CHARGER||" + C;
			arr_CAL_FRML[2] = "U_PHASE||" + P;
			arr_CAL_FRML[3] = "U_VDCNOM||" + V;
			arr_CAL_FRML[4] = "U_IDC||" + I;
			ISave = 5;
			if (vdcMAX!=0){ arr_CAL_FRML[ISave ] = "C_VDCMAX||" + vdcMAX;ISave++;}
			if (Vac !=0){ arr_CAL_FRML[ISave] = "C_VAC||" + Vac;ISave++;}
			for (int iI = (int)ISave;iI< NB_FRML;iI++)   arr_CAL_FRML[iI] = "";
		}



/*
		private void Cal_AllCpt_41_Charger ()
		{
			
			t1.Text = System.DateTime.Now.Second.ToString (); 
			this.Cursor = Cursors.WaitCursor;  

			string stSql = "select * from COMPNT_LIST where Compnt_Type='E' or Compnt_Type='D'  order by Component_ID";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			int debut=0;
			lvDefOption.Items.Clear ();
			while (Oreadr.Read ())
			{
				if (debut==0) 
				{
					CHRGR  =new Charger(MainMDI.M_stCon ,lFV.Text , cbPxx.Text ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text,tVac.Text,tVdcMax.Text );
					debut=1;
				}
				Cpt=new Component();
				Cpt.CPT_COST(Convert.ToInt32(Oreadr["Component_ID"].ToString()));
				//	MessageBox.Show (Oreadr["COMPONENT_REF"].ToString()); 
				if (Cpt.G_PRICE != Charger.VIDE )
				{
					ListViewItem lvI= lvDefOption.Items.Add( Oreadr["COMPONENT_REF"].ToString());
					//CHRGR.Cpt_List[0]=Cpt;
					lvI.SubItems.Add(Cpt.G_Desc.ToString()  ); 
					lvI.SubItems.Add( "$ " + Cpt.G_PRICE.ToString()); 
					lvI.SubItems.Add( "4"); 
					lvI.SubItems.Add(Oreadr["CatName1"].ToString()+"=" + Cpt.CAP1.ToString()); 
					if (Oreadr["CatName2"].ToString()!=Charger.VIDE )  lvI.SubItems.Add( Oreadr["CatName2"].ToString()+"=" +Cpt.CAP2.ToString()); 
					if (Oreadr["CatName3"].ToString()!=Charger.VIDE ) lvI.SubItems.Add( Oreadr["CatName3"].ToString()+"=" +Cpt.CAP3.ToString()); 
				}
			}
			OConn.Close (); 
			this.Cursor = Cursors.Default ; 
			t2.Text = System.DateTime.Now.Second.ToString (); 
		
		}
		*/

	}
}
