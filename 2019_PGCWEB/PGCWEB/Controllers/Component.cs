using System;
using System.Web;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
//using System.Windows.Forms;
using System.Data;
using System.Data.OleDb ;
using System.Web.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient ;
using EAHLibs;
namespace PGCWEB
{
	/// <summary>
	/// Summary description for Component.
	/// </summary>
	public class Component
	{  
//		static const int NB_FRML=200;
//		static const int NB_MODELS=100;
//		static  const int NB_FRML_Flds=5;
//		static  const int NB_MODELS_Flds=12;
//		static  const int IMAX_ARR_REALV = 80;
//
//		static  const string VIDE="n/a";
//		static const int NB_DECI_LOCAL=2;
		private Lib1 Tools = new Lib1();
		
//
//		static  long ISave=0;
//		static string[,] arr_FRML  = new string[NB_FRML,NB_FRML_Flds];
//		static string[] arr_CAL_FRML  = new string[NB_FRML];
//		static string[,] arr_CModels = new string[NB_MODELS,NB_MODELS_Flds];
  
		
        public string G_PRICE,Sell_PRICE;
		public string CAP1=Charger.VIDE  ;
		public string CAP2=Charger.VIDE ;
		public string CAP3=Charger.VIDE ;
		public string CAP4=Charger.VIDE ;
		public string CAP5=Charger.VIDE ;
		public string CAP6=Charger.VIDE ;
		public string CAP7=Charger.VIDE ;
		public string Real_QTY;
        public string G_Desc;
		private string C;
		private string REAL_C;
        private string P;
		private string V;
		private string I;
		private long AvailId;
	//	private string MainMDI.M_stCon;
        private string In_VcsTblName;
        string MainMDI_stMsgXP = "";
        public Component()
		{
			C = Charger.C  ;
			REAL_C=Charger.Real_C ; 
			P=Charger.P ;
			V=Charger.V ;
			I=Charger.I  ;
			AvailId=Charger.AvailId  ;
			In_VcsTblName=Charger.In_VcsTblName  ;
            G_PRICE =Charger.VIDE;
            Sell_PRICE = Charger.VIDE;
   
			G_Desc  =Charger.VIDE;


        //   System.Web.HttpContext.Session[]


        }
	
		public Component(string x_Chrgr, string x_phs,string x_Vdc,string x_Idc, long x_Avail_id)
		{
			//
			// TODO: Add constructor logic here
			//
			C = x_Chrgr;
			P=x_phs;
			V=x_Vdc;
			I=x_Idc ;
			AvailId=x_Avail_id ;
			In_VcsTblName=Charger.In_VcsTblName  ;
		//	MessageBox.Show ("Tbl= " + In_VcsTblName ); 
	//		Load_arr_FRML();
	//		Load_arr_CModel();
		


		}

        public void Cal_Induc(string _filter, string _phs, string _VDC, string _IDC, ref string Ind_C, ref string Inductance, ref string Ind_Qty, ref string Capa, ref string Capa_V, ref string Capa_Qty, ref string Resist_ohm, ref string pwrW, ref string Resist_Qty)
        {

                Ind_C  = MainMDI.VIDE  ;
                Inductance  = MainMDI.VIDE;
                Ind_Qty   = MainMDI.VIDE;
                Capa  = MainMDI.VIDE;
                Capa_Qty   = MainMDI.VIDE;
                Resist_Qty = MainMDI.VIDE;
                Capa_V = MainMDI.VIDE;
                Resist_ohm  = MainMDI.VIDE;
                pwrW = MainMDI.VIDE;
                Resist_Qty = MainMDI.VIDE;

            string stSql = "SELECT * FROM PSM_C_13_Inductance   where Filter='" + _filter + 
                           "'   and  PHASE='" + _phs + "'  and  VDC='" + _VDC + "'   and  IDC='" + _IDC  + "'";
                
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                Ind_C  = Oreadr["Inductor_current"].ToString();
                Inductance  = Oreadr["Inductance"].ToString();
                Ind_Qty   = Oreadr["Inductor_ Qty"].ToString();
                Capa  = Oreadr["Capacitor"].ToString();
                Capa_Qty   = Oreadr["Capacitor_qty"].ToString();
                Resist_Qty = Capa_Qty ;
                Capa_V = Oreadr["Capacitor_voltage"].ToString();
       
            }
            OConn.Close();

            stSql ="SELECT Resitance_ohm ,Power_W FROM PSM_C_13_Bleeding_resistors  where Charger_voltage_V='" + _VDC + "'";
            MainMDI.Find_2_Field (stSql ,ref Resist_ohm ,ref pwrW );
 
          }

		public string Cal_VCS(long frml_ID, string FRML_NAME) 
		{	
            string Res="0";
			string stSql = (frml_ID == 0) ? "select * from " + In_VcsTblName + "  where VCS_NAME='" + FRML_NAME + "' and (PHS='2' OR PHS='" + P + "')" : "select * from " + In_VcsTblName+ " where VCS_ID=" + frml_ID + " and (PHS='2' OR  PHS='" + P + "')";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			if (Oreadr.HasRows)
			{
				while (Oreadr.Read ()) 	Res= Deco_Frml(Oreadr["VCS_name"].ToString());
			    //tstVar=Convert.ToDouble(Res); 
			}
			else
			{
				MainMDI_stMsgXP="ERROR in CAL_VCS.....Many or No VCS_ID=" + frml_ID+ " FNMA=" + FRML_NAME ;
				Res= "0";
			}
			OConn.Close (); 
			return Res;
		}



   private string Deco_Frml(string frml)
   {

	    string Deco_Frml_Res="";
       
		string  tableName="", var="",var2="", VarValue="";//,argType="";
	   string[] Cols=new string[6]{"","","","","",""};
		string[] Crit=new string[6]{"","","","","",""};
        string argType = "";
		int i = 0;
    	int OPos = 0,ipos=0;
		string amnt1 = "";
		string Total = "";
		string oper = "";
	   
	   //added on 11/08/04
        string Res=find_Cal_FRML(frml);
	    if (Res !="" ) return Res; 
	   // end added 

		long currFrml = find_FRML(0, frml);
		if (currFrml != -1)
		{
		 string st = Charger.arr_FRML[currFrml,4];
	  //   MessageBox.Show ("FRML." + currFrml + " Car=" + Charger.arr_FRML[currFrml,2]);
		 switch (Charger.arr_FRML[currFrml,2])
		 {                  
		  case "S":
		   while (st.Substring(OPos, 1) != ";")
     	   { ipos =  st.IndexOf(" ",OPos);
			 var = st.Substring(OPos, ipos - OPos);
			   if (var != " " )
			   {
				 if (OPos == 0)   tableName = var;
				 else
				 {
					 var2 = var.Substring(1, var.Length  - 1);
					 if (var2.Substring(0, 1) == "$")
					 {
						 var2 = var2.Substring(1, var2.Length - 1);
						 argType = "A";
					 }
					 else argType  = "N";
					 if (!deco_Var(var2, ref VarValue)) VarValue = Deco_Frml(var2);
					 Cols[i] = VarValue;
					 Crit[i] = var.Substring(0, 1);
					 i++;
				 }
			   }
			   OPos = ipos + 1;
		   }
		   Deco_Frml_Res = searchTBL6_RST( tableName, Cols, Crit);
		   if (Deco_Frml_Res.Substring(0, 1) == "!") Deco_Frml_Res = Deco_Frml(Deco_Frml_Res.Substring( 1, Deco_Frml_Res.Length - 1));
		   if (isVide(Deco_Frml_Res))
			MainMDI_stMsgXP="ERROR In seeking Values in table= " + tableName + "\n" + Cols[1] + " " + Cols[2] + " " + Cols[3] + " " + Cols[4] + " " + Cols[5];
		   else
		   { Charger.arr_CAL_FRML[Charger.ISave] = frml + "||" + Deco_Frml_Res;
			 Charger.ISave++;
		   }
		   break;
		  case "C":
		  while (st.Substring(OPos, 1) != ";")
		  { 
		   	ipos =  st.IndexOf(" ",OPos);
	       	var = st.Substring(OPos, ipos - OPos);
		   	if (var !=" ")
			{ if (var.Length > 1)
			  { if (!deco_Var(var, ref VarValue))    VarValue = Deco_Frml(var);
		    	if (Total == "")   Total = VarValue;
			  	else	           amnt1 = VarValue;
			  }	
			  else oper = var;
			  if (oper != "" && amnt1 != "" && Total != "")
			  {
                Total = calul_Amnt(Total, oper, amnt1);
		   	  	amnt1 = "";
		   	  }
		   	}
		   	OPos = ipos+1; //Opos=opos+1;
		  }
		  Deco_Frml_Res= Total;
		  Charger.arr_CAL_FRML[Charger.ISave] = frml + "||" + Deco_Frml_Res;
		  Charger.ISave++;
		  break;
	    }
	}
	else  MainMDI_stMsgXP="FRML does not Exist..." + frml;
    return Deco_Frml_Res;
}

	private long find_FRML(long Vcs_ID , string VCS_name)
	{
		bool found=false;
		long find_FRML_Res=-1;
		int i = 0;
		if (Charger.arr_FRML[0,0] !="" )
		{ 
		 while (i <Charger.NB_FRML && !found && Charger.arr_FRML[i,1] != "")
		 {
			 if (Charger.arr_FRML[i,1] == P || Charger.arr_FRML[i,1] == "2")
			 {
				 if (VCS_name == "*" ) {  if (Charger.arr_FRML[i,0] == Vcs_ID.ToString() ) found = true;}
				 else  if (Charger.arr_FRML[i,3]== VCS_name) found = true;
			 }
		    find_FRML_Res= i++;
	     }
		}
      if (found) return find_FRML_Res;
	  else return -1; 
    }

	  
private bool deco_Var(string var , ref string VarValue) 
{ 
	bool found =false;
	string st="";
    bool deco_Var_Res = true;
	
	
	switch (var.Substring(0, 1))
	{
		case "F":
			VarValue = seekCF(var.Substring ( 2, var.Length  - 2));
			found = true;
			break;
		case "X":
			 VarValue =REAL_C ;
			found = true;
			break;
		case "V":
			VarValue = var.Substring(1, var.Length  - 2);
			found = true;
			break;
		case "$":
			//VarValue = Mid(var, 2, Len(var) - 2);
			VarValue = var.Substring(1, var.Length  - 2);
			VarValue = cleanSt(VarValue);
			found = true;
			break;
		case "Q":
			st = Deco_Frml(var.Substring( 1, var.Length  - 2));
			if (st== "")
			{
				VarValue = "******";
				deco_Var_Res= false;
			}
			else 
			{
				deco_Var_Res = true;
				VarValue = "0";
				if ( Tools.Conv_Dbl(st) > 0) VarValue = Math.Sqrt(Tools.Conv_Dbl(st)).ToString ();
			}
			break;
		case "H":
			st = Deco_Frml(var.Substring( 1, var.Length  - 2));
			if (st == "")
			{
			  VarValue = "******";
			  deco_Var_Res = false;
			}
			else
			{
			  deco_Var_Res = true;
			  VarValue = "0";
			  if (Tools.Conv_Dbl(st) > 0) VarValue = HRND(st);
			}	
			break;
		case "R":
			st = findRealV(var.Substring( 1, 1), var.Substring(3, var.Length  - 3));
			if (st == "0")
			{
				Cal_chrg_CostADO(Convert.ToInt32(st.Substring (3, st.Length - 3)), st.Substring(0, 2),"","");
			 // Cal_chrg_CostADO(Convert.ToInt32( var.Substring ( 4,var.Length  - 3)), var.Substring ( 0, 1));
			  st = findRealV(var.Substring ( 1, 1),var.Substring ( 3, var.Length  - 3));
			}
			VarValue = (st == "0") ?  "******" : st;
			deco_Var_Res = (st !="0") ? true : false;
			break;
		default:
			st = find_Cal_FRML(var);
			if (st == "")
			{
				VarValue = "******";
				deco_Var_Res = false;
			}
			else
			{
				deco_Var_Res = true;
				VarValue = st;
			}
			break;
	}
	return deco_Var_Res;
  }

	private string searchTBL6_RST(string tblName, string[] catN,string[] Cn)
    {

		string searchTBL6_RST_Res = Charger.VIDE;
	    string whr1 = "";
    	string ord1 = "";
		for (int i = 0;i<6;i++)
		{
			if (Cn[i] != "")
			{
				// 'st = IIf(i = 1, " Where ", " AND ")
				string st = " AND ";
				if (Cn[i] == "=") 
				{
					whr1 += st + " ([COL" + (i+1) + "]='" + catN[i] + "') ";
					ord1 +=  (i == 0) ? " ORDER BY [COL" + (i+1) + "]" : " ,[COL" + (i+1) + "]";
				}
				else
				{
					whr1 += st + " (" + catN[i] + seekOper(Cn[i]) + " cast([COL" + (i+1) + "] AS float)) ";
					ord1 +=  (i == 0) ? " ORDER BY cast([COL" + (i+1) + "] AS float) " : " , cast([COL" + (i+1) + "] AS float) ";
				}
			}
			else i = 7;
		}
			//	'   afferror ("debut in SeekTBL6Rsssssssttt =" & tblname & ": " & Timer)
			//	 'If Not fin Then affMsg ("Category #1 is Empty....")
	    	// ' If Mid(searchTBL6, 1, 1) = "!" Then searchTBL6 = Deco_Frml(p, Mid(searchTBL6, 2, Len(searchTBL6) - 1))

		string   stSql = "SELECT " + System.Web.HttpContext.Current.Session["t_SeekTBL6"].ToString() + ".* FROM " +System.Web.HttpContext.Current.Session["t_SeekTBL6"].ToString() + " WHERE ((TABLE_NAME='" + tblName + "')" + whr1 + ")" + ord1;
		SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
		OConn.Open ();
		SqlCommand Ocmd = OConn.CreateCommand();
		Ocmd.CommandText = stSql ;
		SqlDataReader Oreadr = Ocmd.ExecuteReader();
 		bool fin = false;
		while (Oreadr.Read () && !fin)
		{
			searchTBL6_RST_Res=Oreadr["value1"].ToString() ;
		    fin = true;
		}
		OConn.Close (); 
		return searchTBL6_RST_Res ;
	}

		private bool isVide(string st)
		{  
	      //  return ((st == "0") || (st == ""));
            return (st == "");

		}





		private string calul_Amnt(string amnt1, string oper, string amnt2)
		{
			//	  On Error GoTo cal_Err
			  string calul_Amnt_Res = "0";
            int nbaff=0;
			  double mnt1=0,mnt2=0;
			  if (amnt1==Charger.VIDE ||   amnt2==Charger.VIDE) return "0";
			if (oper != "&" ) 
			{
				mnt1=Tools.Conv_Dbl(amnt1);
				if (oper == "%" ) nbaff=Int32.Parse (amnt2); // amnt1 % amnt2 ==> arrondi au decimal =amnt2
                else mnt2=Tools.Conv_Dbl(amnt2);
			}
     
				switch ( oper)
				{
					case "*":
						calul_Amnt_Res = Convert.ToString(Math.Round(mnt1 * mnt2,Charger.NB_DEC_CAL ));
						break;
					case "-":
						calul_Amnt_Res  = Convert.ToString(Math.Round(mnt1 - mnt2,Charger.NB_DEC_CAL ));
						break;
					case "/":
						if (mnt2 > 0) calul_Amnt_Res  = Convert.ToString(Math.Round(mnt1 / mnt2, Charger.NB_DEC_CAL ));
						else calul_Amnt_Res  = "0";
						break;
					case "+":
						calul_Amnt_Res  = Convert.ToString(  Math.Round(mnt1 + mnt2, Charger.NB_DEC_CAL )  );
						break;
					case "&":
						calul_Amnt_Res = amnt1 + amnt2;
						break;
					case "#": 
						calul_Amnt_Res = MainMDI.Ceil(amnt1,amnt2).ToString() ;
						break;
                    case "%":
                        calul_Amnt_Res = Convert.ToString(Math.Round(mnt1,nbaff ));
                        break;
					default:
                        MainMDI_stMsgXP = "Operator is Invalid.....=" + oper;
						break;
				} 
			return calul_Amnt_Res;
		}

		public string  seekCF(string Coef)
		{

			string  seekCF_Res = "0";
			string  stSql = "SELECT Configo_TABLES_CONTENT.COL1, Configo_TABLES_CONTENT.VALUE1 FROM TABLES_LIST INNER JOIN Configo_TABLES_CONTENT ON TABLES_LIST.TABLE_ID = Configo_TABLES_CONTENT.TABLE_ID " +
				" WHERE (((Configo_TABLES_CONTENT.COL1)='" + Coef + "') AND ((TABLES_LIST.TABLE_NAME)='COEFICIENTS'))";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			bool fin = false;
			while (Oreadr.Read () && !fin)
			{
				seekCF_Res =Oreadr[1].ToString() ;
				fin = true;
			}
			OConn.Close (); 
			return seekCF_Res; 
		}

		private string cleanSt(string st)
		{
			bool okClean = false;
			int j = 0;
		    string cc=""; 
			string cleanSt_Res ="";
			while (!okClean && j < st.Length )
			{
				int i = st.IndexOf("$",j);
				if (i > -1)
				{
					if (st.Substring(i + 1, 1) == "$")
					{
						cc = "$";
						j++;
					}
					else cc = " ";
					cleanSt_Res = cleanSt_Res  + cc + st.Substring( j + 1, 1);
				}
				else
				{ 
					okClean = true;
					cleanSt_Res  = cleanSt_Res + st.Substring ( j + 1, st.Length  - (j+1));
				}
				j++;
			}
			return cleanSt_Res; 
		}

		private string find_Cal_FRMLOLD(string st)
		{  
			string find_Cal_FRML_Res = "";
			int ipos=0;
			int deb = 5;
			if (st.Substring ( 0, 1) == "U" )  deb = 1;
			for (int i = deb;i<Charger.NB_FRML;i++)
			{
				if (Charger.arr_CAL_FRML[i] != "")	 ipos = Charger.arr_CAL_FRML[i].IndexOf("||",0);
				if (Charger.arr_CAL_FRML[i].Substring(0, ipos - 1) == st)
				{
					find_Cal_FRML_Res  = Charger.arr_CAL_FRML[i].Substring ( ipos + 2, Charger.arr_CAL_FRML[i].Length  - 1 - ipos);
					i = Charger.NB_FRML;
				}
				else i =Charger.NB_FRML;
			}
			return find_Cal_FRML_Res;
		}


		private string find_Cal_FRML(string st)
		{  
		
			int i = 1;
			while (Charger.arr_CAL_FRML[i] != "" && i<Charger.NB_FRML)
			{ 
				int ipos = Charger.arr_CAL_FRML[i].IndexOf("||",0);
				if (Charger.arr_CAL_FRML[i].Substring(0, ipos) == st)
				{
					
					return Charger.arr_CAL_FRML[i].Substring ( ipos + 2, Charger.arr_CAL_FRML[i].Length - (ipos+2));
				}
				i++;
			}
			return "";
		}

		
		private string HRND(string st) 
		{	
			return Convert.ToString(Math.Round(Tools.Conv_Dbl(st)))  ;
		}
		
		private string findRealV(string ndx, string cpt_id)
		{
	
			string findRealV_Res = "0";
			for (int i = 0;i<Charger.IMAX_ARR_REALV;i++)
			{
				if (Charger.arr_REALV[i, 0] == "")    i = Charger.IMAX_ARR_REALV;
				else
				{ 
					if (Charger.arr_REALV[i, 0] == cpt_id)
					{												  
						findRealV_Res = Charger.arr_REALV[i, Convert.ToInt32(ndx)];
						i = Charger.IMAX_ARR_REALV;
					}
				}
			}
		    return 	findRealV_Res ;
		}


		private string seekOper(string st )
		{
			string 	seekOper_Res = "*";
			switch (st)
			{
				case "(":
				case "|":
					seekOper_Res  = "<=";
					break;
				case ")":
					seekOper_Res  = ">=";
					break;
				case "<":
				case  "=":
				case ">":
					seekOper_Res  = st;
					break;
			}
			return seekOper_Res ;
		}
		public void Disp_FRMLS()
		{
			string stOut="";
			for (int i=0;i<Charger.NB_FRML  ;i++)
			{
					stOut = stOut + "\n";
				for (int j=0;j<5;j++)
					stOut=stOut + " / " + Charger.arr_FRML[i,j].ToString() ;
				if ((i % 20) == 0) 
				{
                    MainMDI_stMsgXP = stOut; 
					stOut = "" ;
				}
	  	    
			}
		}
		public void Disp_CMODELS()
		{
			string stOut="";
			for (int i=0;i<Charger.NB_MODELS  ;i++)
			{
					stOut = stOut + "\n";
				for (int j=0;j<Charger.NB_MODELS_Flds;j++)
					stOut=stOut + " / " + Charger.arr_CModels[i,j].ToString() ;
				if ((i % 20) == 0) 
				{
                    MainMDI_stMsgXP = stOut; 
					stOut = "" ;
				}
	  	    
			}
		}


		public string Cal_chrg_CostADO_NEWone(long compntID, string code,string KAac,string KAdc,ref string[] arr_defRaw)
		{


      //      string KAac = HttpContext.Session["kaac"].ToString(), KAdc = HttpContext.Session["kadc"].ToString();

            string Cal_chrg_CostADO_Res=Charger.VIDE ;
		//	 bool rec_Empty = true;
			 string c1="",c2="",c3="";  // To be Verified..... !!!!!!
			 string val1="", val2="",val3="";
             string prc=Charger.VIDE, stSql="";

            if (AvailId != -1)
            {
               long cptid = (compntID == 226) ? 147 : compntID;
                stSql = "SELECT TBLAVAIL" + P + ".Avail_ID, Configo_COMPNT_LIST.Component_ID,Configo_COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + P + ".charger, TBLAVAIL" + P + ".vdc, TBLAVAIL" + P + ".idc, link_COMPNT_AVAIL.Qty, " +
               " Configo_COMPNT_LIST.CAT1_TABLE_ID, Configo_COMPNT_LIST.CAT2_TABLE_ID, Configo_COMPNT_LIST.CAT3_TABLE_ID, Configo_COMPNT_LIST.Compnt_Type, Configo_COMPNT_LIST.Value_Type, Configo_COMPNT_LIST.nbc3Cat " +
               " FROM (TBLAVAIL" + P + " INNER JOIN link_COMPNT_AVAIL ON TBLAVAIL" + P + ".Avail_ID = link_COMPNT_AVAIL.Avail_ID) INNER JOIN Configo_COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = Configo_COMPNT_LIST.Component_ID " +
               " Where (((link_COMPNT_AVAIL.phs) = '" + P + "') and ((Configo_COMPNT_LIST.Component_ID) = " + cptid + ") and ((TBLAVAIL" + P + ".Avail_ID) = " + AvailId + ")) ORDER BY TBLAVAIL" + P + ".charger,cast(TBLAVAIL" + P + ".vdc AS float),cast(TBLAVAIL" + P + ".idc AS float ), Configo_COMPNT_LIST.Component_ID";
            }
            else stSql = " SELECT  Component_ID, COMPONENT_REF, '" + Charger.C + "' AS charger, '" + Charger.V + "' AS vdc, '" + Charger.I + "' AS idc, 1 AS Qty, CAT1_TABLE_ID, CAT2_TABLE_ID, CAT3_TABLE_ID, Compnt_Type, Value_Type, nbc3Cat, '" + Charger.P + "' AS phs " +
   " FROM  Configo_COMPNT_LIST WHERE Component_ID =" + compntID + " ORDER BY Component_ID";


			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
		//	string old_CHRG_REF = "";
			string D_qty = Charger.VIDE; 
			while (Oreadr.Read ())
			{
				string Qty = "0";
				long cptPrice_id = 0;
			//	rec_Empty = false;
			//	string chrg_ref = Oreadr["charger"] + "-" + P + "-" + Oreadr["vdc"] + "-" + Oreadr["idc"];
				string cc = Oreadr["Compnt_Type"].ToString ();
				switch (cc)
				{
					case "D":
					case "E":
					case "F":
					case "T":
					case "S":
					case "C":
                        
                       
                            deco_CRIT(Oreadr["nbc3Cat"].ToString(), ref c1, ref c2, ref c3);
                            Catn_Val_ado(Convert.ToInt32(AvailId), Convert.ToInt32(Oreadr["Value_Type"].ToString()), P, Oreadr["charger"].ToString(), Oreadr["vdc"].ToString(), Oreadr["idc"].ToString(), ref val1, ref val2, ref val3, ref Qty, ref cptPrice_id);
                            if (val1 == "0")
                            {
                                c1 = "";
                                // MessageBox.Show ("Category #1 value is Empty.......VCS_ID=" + Oreadr["Value_Type"] + " V1=" + val1 + " V2=" + val2 + " V3=" + val3);
                            }
                            if (val2 == "0") c2 = "";
                            if (val3 == "0") c3 = "";
                            if (Qty == "0") D_qty = Oreadr["Qty"].ToString();
                            else if (Qty != Charger.VIDE) D_qty = Tools.Conv_Dbl(Qty).ToString();

                        if (compntID != 147 && compntID != 226)
                        {
                            if (cptPrice_id == 0) prc = seekPriceADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()), Convert.ToInt32(Oreadr["Component_ID"]), val1, val2, val3, c1, c2, c3, code, D_qty);
                            else prc = seekPriceADO(Convert.ToInt32(Oreadr["Component_ID"]), cptPrice_id, val1, val2, val3, c1, c2, c3, code, D_qty);
                        }
                        else
                        {
                            if (compntID == 147)
                            {



                                double ddCustm_KA = Tools.Conv_Dbl(KAac);
                                double dd_DEF_KA = 0, dd_KA = 0;
                                //
                                if (arr_defRaw[0] == "")
                                {
                                   // dd_DEF_KA = 0;
                                    string myDEF_prc = seekPrice_Configo_147(val1, val2, val3, c1, c2, c3, code, D_qty, "", ref dd_DEF_KA);
                                    arr_defRaw[0] = val1;// HttpContext.Session["def_phs"] = val1;
                                    arr_defRaw[1] = val2;// HttpContext.Session["def_vac"] = val2;
                                    arr_defRaw[2] = val3;// HttpContext.Session["def_icb1"] = val3;

                                    arr_defRaw[3] = myDEF_prc;// HttpContext.Session["def_147_price"] = myDEF_prc;
                                    arr_defRaw[4] = dd_DEF_KA.ToString ();//  HttpContext.Session["def_147_ka"] = dd_DEF_KA;
                                }
                                //

                                if (ddCustm_KA > 0)
                                {
                                    // double dd_DEF_KA = 0, dd_KA = 0; 


                                    //string DEF_prc = seekPrice_Configo_147(val1, val2, val3, c1, c2, c3, code, D_qty, "",ref dd_DEF_KA);
                                    prc = seekPrice_Configo_147(val1, val2, val3, c1, c2, c3, code, D_qty, KAac, ref dd_KA);

                                    if (ddCustm_KA <= Tools.Conv_Dbl(arr_defRaw[4]))
                                    {
                                        prc = "0";
                                        G_PRICE = "0";

                                        update_price_REALV(147, prc);

                                    }

                                }
                                else
                                {

                                    prc = seekPrice_Configo_147(val1, val2, val3, c1, c2, c3, code, D_qty, KAac, ref dd_KA);
                                }
                               


                            }
                            else
                            {
                                val1 = "1";
                                val2 = Oreadr["vdc"].ToString();
                                double dd = Tools.Conv_Dbl(Oreadr["idc"].ToString()) * 1.15;
                                val3 = dd.ToString();

                                double ddCustm_KA = Tools.Conv_Dbl(KAdc);
                                double dd_DEF_KA = 0, dd_KA = 0;
                                if (ddCustm_KA > 0)
                                {
                                    string DEF_prc = seekPrice_Configo_226(val1, val2, val3, c1, c2, c3, code, D_qty, "", ref dd_DEF_KA);
                                    prc = seekPrice_Configo_226(val1, val2, val3, c1, c2, c3, code, D_qty, KAdc, ref dd_KA);

                                    if (ddCustm_KA <= dd_DEF_KA)
                                    {
                                        prc = "0";
                                        G_PRICE = "0";

                                        update_price_REALV(226, prc);

                                    }
                                }
                                else  prc = seekPrice_Configo_226(val1, val2, val3, c1, c2, c3, code, D_qty, KAdc, ref dd_KA);
                            }
                        }
                            Real_QTY = D_qty;
                       
                     
                            //prc = seekPrice_XCL(Convert.ToInt32(Oreadr["Component_ID"]), cptPrice_id, val1, val2, val3, c1, c2, c3, code, D_qty);
						break;
					case "Z":
						val1 = Charger.VIDE;
						val2 = Charger.VIDE;
						val3 = Charger.VIDE;
						prc = seekPriceADO(Convert.ToInt32(Oreadr["Component_ID"]), Convert.ToInt32(Oreadr["Component_ID"]), val1, val2, val3, "=", "=", "=", code, D_qty);   //* Conv_Dbl(rstAvail!Qty)
						break;
					case "%":
						G_PRICE =  Convert.ToString( Math.Round(Tools.Conv_Dbl(Oreadr["Value_Type"].ToString ()) * Tools.Conv_Dbl(Oreadr["Qty"].ToString ()), Charger.NB_DEC_AFF ));
						Real_QTY = Oreadr["Qty"].ToString ();
						break;
                    case "$":

                        string st_dollar=Cal_VCS(Int32.Parse(Oreadr["Value_Type"].ToString()),"*");
                        G_PRICE =  Convert.ToString(Math.Round(Tools.Conv_Dbl(st_dollar ) * Tools.Conv_Dbl(Oreadr["Qty"].ToString()), Charger.NB_DEC_AFF));
                        Real_QTY = Oreadr["Qty"].ToString();
                        break;
					default:
                        MainMDI_stMsgXP = "ERROR in Cost Process... bad Compnt_Type=  " + Oreadr["Compnt_Type"];
						prc = "0";
						break;
				}	
			//	old_CHRG_REF = chrg_ref;
				
			}
     	    OConn.Close ();
        //    if (prc == MainMDI.VIDE && compntID==173) prc = prc; 
			//return Cal_chrg_CostADO_Res ;
			return prc;
		}
        //old one
        public string Cal_chrg_CostADO(long compntID, string code, string KAac, string KAdc)
        {


            //      string KAac = HttpContext.Session["kaac"].ToString(), KAdc = HttpContext.Session["kadc"].ToString();

            string Cal_chrg_CostADO_Res = Charger.VIDE;
            //	 bool rec_Empty = true;
            string c1 = "", c2 = "", c3 = "";  // To be Verified..... !!!!!!
            string val1 = "", val2 = "", val3 = "";
            string prc = Charger.VIDE, stSql = "";

            if (AvailId != -1)
            {
                long cptid = (compntID == 226) ? 147 : compntID;
                stSql = "SELECT TBLAVAIL" + P + ".Avail_ID, Configo_COMPNT_LIST.Component_ID,Configo_COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + P + ".charger, TBLAVAIL" + P + ".vdc, TBLAVAIL" + P + ".idc, link_COMPNT_AVAIL.Qty, " +
               " Configo_COMPNT_LIST.CAT1_TABLE_ID, Configo_COMPNT_LIST.CAT2_TABLE_ID, Configo_COMPNT_LIST.CAT3_TABLE_ID, Configo_COMPNT_LIST.Compnt_Type, Configo_COMPNT_LIST.Value_Type, Configo_COMPNT_LIST.nbc3Cat " +
               " FROM (TBLAVAIL" + P + " INNER JOIN link_COMPNT_AVAIL ON TBLAVAIL" + P + ".Avail_ID = link_COMPNT_AVAIL.Avail_ID) INNER JOIN Configo_COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = Configo_COMPNT_LIST.Component_ID " +
               " Where (((link_COMPNT_AVAIL.phs) = '" + P + "') and ((Configo_COMPNT_LIST.Component_ID) = " + cptid + ") and ((TBLAVAIL" + P + ".Avail_ID) = " + AvailId + ")) ORDER BY TBLAVAIL" + P + ".charger,cast(TBLAVAIL" + P + ".vdc AS float),cast(TBLAVAIL" + P + ".idc AS float ), Configo_COMPNT_LIST.Component_ID";
            }
            else stSql = " SELECT  Component_ID, COMPONENT_REF, '" + Charger.C + "' AS charger, '" + Charger.V + "' AS vdc, '" + Charger.I + "' AS idc, 1 AS Qty, CAT1_TABLE_ID, CAT2_TABLE_ID, CAT3_TABLE_ID, Compnt_Type, Value_Type, nbc3Cat, '" + Charger.P + "' AS phs " +
   " FROM  Configo_COMPNT_LIST WHERE Component_ID =" + compntID + " ORDER BY Component_ID";


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            //	string old_CHRG_REF = "";
            string D_qty = Charger.VIDE;
            while (Oreadr.Read())
            {
                string Qty = "0";
                long cptPrice_id = 0;
                //	rec_Empty = false;
                //	string chrg_ref = Oreadr["charger"] + "-" + P + "-" + Oreadr["vdc"] + "-" + Oreadr["idc"];
                string cc = Oreadr["Compnt_Type"].ToString();
                switch (cc)
                {
                    case "D":
                    case "E":
                    case "F":
                    case "T":
                    case "S":
                    case "C":


                        deco_CRIT(Oreadr["nbc3Cat"].ToString(), ref c1, ref c2, ref c3);
                        Catn_Val_ado(Convert.ToInt32(AvailId), Convert.ToInt32(Oreadr["Value_Type"].ToString()), P, Oreadr["charger"].ToString(), Oreadr["vdc"].ToString(), Oreadr["idc"].ToString(), ref val1, ref val2, ref val3, ref Qty, ref cptPrice_id);
                        if (val1 == "0")
                        {
                            c1 = "";
                            // MessageBox.Show ("Category #1 value is Empty.......VCS_ID=" + Oreadr["Value_Type"] + " V1=" + val1 + " V2=" + val2 + " V3=" + val3);
                        }
                        if (val2 == "0") c2 = "";
                        if (val3 == "0") c3 = "";
                        if (Qty == "0") D_qty = Oreadr["Qty"].ToString();
                        else if (Qty != Charger.VIDE) D_qty = Tools.Conv_Dbl(Qty).ToString();

                        if (compntID != 147 && compntID != 226)
                        {
                            if (cptPrice_id == 0) prc = seekPriceADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()), Convert.ToInt32(Oreadr["Component_ID"]), val1, val2, val3, c1, c2, c3, code, D_qty);
                            else prc = seekPriceADO(Convert.ToInt32(Oreadr["Component_ID"]), cptPrice_id, val1, val2, val3, c1, c2, c3, code, D_qty);
                        }
                        else
                        {
                            if (compntID == 147)
                            {



                                double ddCustm_KA = Tools.Conv_Dbl(KAac);
                                double dd_DEF_KA = 0, dd_KA = 0;
                                if (ddCustm_KA > 0)
                                {
                                    // double dd_DEF_KA = 0, dd_KA = 0; 


                                    string DEF_prc = seekPrice_Configo_147(val1, val2, val3, c1, c2, c3, code, D_qty, "", ref dd_DEF_KA);
                                    prc = seekPrice_Configo_147(val1, val2, val3, c1, c2, c3, code, D_qty, KAac, ref dd_KA);

                                    if (ddCustm_KA <= dd_DEF_KA)
                                    {
                                        prc = "0";
                                        G_PRICE = "0";

                                        update_price_REALV(147, prc);

                                    }

                                }
                                else prc = seekPrice_Configo_147(val1, val2, val3, c1, c2, c3, code, D_qty, KAac, ref dd_KA);



                            }
                            else
                            {
                                val1 = "1";
                                val2 = Oreadr["vdc"].ToString();
                                double dd = Tools.Conv_Dbl(Oreadr["idc"].ToString()) * 1.15;
                                val3 = dd.ToString();

                                double ddCustm_KA = Tools.Conv_Dbl(KAdc);
                                double dd_DEF_KA = 0, dd_KA = 0;
                                if (ddCustm_KA > 0)
                                {
                                    string DEF_prc = seekPrice_Configo_226(val1, val2, val3, c1, c2, c3, code, D_qty, "", ref dd_DEF_KA);
                                    prc = seekPrice_Configo_226(val1, val2, val3, c1, c2, c3, code, D_qty, KAdc, ref dd_KA);

                                    if (ddCustm_KA <= dd_DEF_KA)
                                    {
                                        prc = "0";
                                        G_PRICE = "0";

                                        update_price_REALV(226, prc);

                                    }
                                }
                                else prc = seekPrice_Configo_226(val1, val2, val3, c1, c2, c3, code, D_qty, KAdc, ref dd_KA);
                            }
                        }
                        Real_QTY = D_qty;


                        //prc = seekPrice_XCL(Convert.ToInt32(Oreadr["Component_ID"]), cptPrice_id, val1, val2, val3, c1, c2, c3, code, D_qty);
                        break;
                    case "Z":
                        val1 = Charger.VIDE;
                        val2 = Charger.VIDE;
                        val3 = Charger.VIDE;
                        prc = seekPriceADO(Convert.ToInt32(Oreadr["Component_ID"]), Convert.ToInt32(Oreadr["Component_ID"]), val1, val2, val3, "=", "=", "=", code, D_qty);   //* Conv_Dbl(rstAvail!Qty)
                        break;
                    case "%":
                        G_PRICE = Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["Value_Type"].ToString()) * Tools.Conv_Dbl(Oreadr["Qty"].ToString()), Charger.NB_DEC_AFF));
                        Real_QTY = Oreadr["Qty"].ToString();
                        break;
                    case "$":

                        string st_dollar = Cal_VCS(Int32.Parse(Oreadr["Value_Type"].ToString()), "*");
                        G_PRICE = Convert.ToString(Math.Round(Tools.Conv_Dbl(st_dollar) * Tools.Conv_Dbl(Oreadr["Qty"].ToString()), Charger.NB_DEC_AFF));
                        Real_QTY = Oreadr["Qty"].ToString();
                        break;
                    default:
                        MainMDI_stMsgXP = "ERROR in Cost Process... bad Compnt_Type=  " + Oreadr["Compnt_Type"];
                        prc = "0";
                        break;
                }
                //	old_CHRG_REF = chrg_ref;

            }
            OConn.Close();
            //    if (prc == MainMDI.VIDE && compntID==173) prc = prc; 
            //return Cal_chrg_CostADO_Res ;
            return prc;
        }
  //      public void CPT_COST(long dccompnt)
		//{

		//	string stSql="";
  //         if (AvailId !=-1) stSql= "SELECT TBLAVAIL" + P + ".Avail_ID, Configo_COMPNT_LIST.Component_ID,Configo_COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + P + ".charger, TBLAVAIL" + P + ".vdc, TBLAVAIL" + P +  ".idc, link_COMPNT_AVAIL.Qty, " +
  //             " COMPNT_LIST.CAT1_TABLE_ID, Configo_COMPNT_LIST.CAT2_TABLE_ID, Configo_COMPNT_LIST.CAT3_TABLE_ID, Configo_COMPNT_LIST.Compnt_Type, Configo_COMPNT_LIST.Value_Type, Configo_COMPNT_LIST.nbc3Cat " +
  //             " FROM (TBLAVAIL" + P +  " INNER JOIN link_COMPNT_AVAIL ON TBLAVAIL" + P +  ".Avail_ID = link_COMPNT_AVAIL.Avail_ID) INNER JOIN Configo_COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = Configo_COMPNT_LIST.Component_ID " +
  //             " Where (((link_COMPNT_AVAIL.phs) = '" + P +  "') and ((link_COMPNT_AVAIL.Avail_ID) = " + AvailId +  ") and ((link_COMPNT_AVAIL.Compnt_ID) = " + dccompnt + ")) ORDER BY TBLAVAIL" + P +  ".Avail_ID, Configo_COMPNT_LIST.Component_ID" ;
		//   else     	    stSql=" SELECT Component_ID, COMPONENT_REF, CAT1_TABLE_ID, CAT2_TABLE_ID, CAT3_TABLE_ID, Compnt_Type, Value_Type, nbc3Cat " +
  //              " FROM         Configo_COMPNT_LIST WHERE     Component_ID =" +  dccompnt + " ORDER BY Component_ID	";
		//	SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
		//	OConn.Open ();
		//	SqlCommand Ocmd = OConn.CreateCommand();
		//	Ocmd.CommandText = stSql ;
		//	SqlDataReader Oreadr = Ocmd.ExecuteReader();
		//	if (Oreadr.HasRows)
		//	{
		//		while (Oreadr.Read ())
		//		{
		//			Cal_chrg_CostADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()),"C","",""); 
					
		//		}
		//	}
		//	else
		//	{
  //              MainMDI_stMsgXP = "No Component is Available....(Availability)...cpt=" + dccompnt;
		//		G_Desc =Charger.VIDE;
		//	    G_PRICE =Charger.VIDE;
		//	}
  //       OConn.Close (); 

		//}


		private void lCR_TBL6()
		{
/*
	
Dim whr1 As String
Dim ord1 As String
Dim st As String
Dim fin As Boolean
Dim stconn, stSql As String
Dim Conn As New ADODB.Connection
Dim Cmd As New ADODB.Command
Dim rstTBL6 As New ADODB.Recordset


  ExecSqlado_Price ("delete * from pgm_SeekTBL6")
  stconn = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & NomdbPrice & ";Persist Security Info=False;Jet OLEDB:Database Password =" & DBPWD
  Conn.ConnectionString = stconn
  Conn.Open
  stSql = "INSERT INTO pgm_SeekTBL6 ( Col1, col2, col3, col4, col5, col6, VALUE1,TABLE_NAME ) SELECT  IIf(IsNumeric([COL1]),CDbl([COL1]),[COL1]) AS col1, IIf(IsNumeric([COL2]),CDbl([COL2]),[COL2]) AS col2, " & _
             " IIf(IsNumeric([COL3]),CDbl([COL3]),[COL3]) AS col3, IIf(IsNumeric([COL4]),CDbl([COL4]),[COL4]) AS col4,  IIf(IsNumeric([COL5]),CDbl([COL5]),[COL5]) AS col5, IIf(IsNumeric([COL6]),CDbl([COL6]),[COL6]) AS col6, TABLES_CONTENT.VALUE1,TABLES_LIST.TABLE_NAME  " & _
             " FROM TABLES_LIST INNER JOIN TABLES_CONTENT ON TABLES_LIST.TABLE_ID = TABLES_CONTENT.TABLE_ID "
  'MsgBox stSql
  rstTBL6.Open stSql, Conn, adOpenDynamic, adLockOptimistic
'  rstTBL6.Close
  
  
End Function
*/
		}

		private string seekPriceADO(long Orig_compnt_ID, long Price_compnt_ID ,string  cat1V , string cat2V , string cat3V, string c1, string c2 ,string c3,string code, string D_qty )
		{

/*
      if lblIRealV.Caption = 0 Then
       'affMsg ("IRealV is NULL...")
       afferror ("IRealV is NULL...")
       lblIRealV.Caption = 1
  End If
  */


  string seekPriceADO_Res = Charger.VIDE;
  string whr1 = "";
  string whr2 = "";
  string whr3 = "";
  string ord1 = "";
  string ord2 = "";
  string ord3 = "";
  string pref = "0";
 string Desc="";
  CAP1 = cat1V;
  CAP2 = cat2V;
  CAP3 = cat3V;
  string prc = Charger.VIDE;
 // if (c1 == "")  MessageBox.Show("ERoooooooooooooooooooooooooRRR c1 is EMPTY in SeekingPrice....");
			if (cat1V != Charger.VIDE && cat2V !=Charger.VIDE && cat3V != Charger.VIDE && D_qty != Charger.VIDE )
			{
				if (c1 == "=")
				{
					whr1 = " AND ([CAT1_VALUE]='" + cat1V + "') ";
					ord1 = " ORDER BY [CAT1_VALUE] ";
				}
				else
				{
					whr1 = "  AND (" + cat1V + c1 + " cast([CAT1_VALUE] AS float)) ";
					ord1 = " ORDER BY cast([CAT1_VALUE] AS float) ";
				}
				if (c2 != "") 
				{
					if (c2 == "=")
					{
						whr2 = "   AND ([CAT2_VALUE]='" + cat2V + "') ";
						ord2 = " ,[CAT2_VALUE] ";
					}
					else
					{
						whr2 = "  AND (" + cat2V + c2 + " cast([CAT2_VALUE] AS float)) ";
						ord2 = " , cast([CAT2_VALUE] AS float) ";
					}
				}
				if (c3 != "")
				{
					if (c3 == "=")
					{
						whr3 = "   AND ([CAT3_VALUE]='" + cat3V + "') ";
						ord3 = " ,[CAT3_VALUE] ";
					}
					else
					{
						whr3 = "  AND (" + cat3V + c3 + " cast([CAT3_VALUE] AS float)) ";
						ord3 = " , cast([CAT3_VALUE] AS float) ";
					}
				}
   


				string stSql = "SELECT COMPNT_PRICE_LIST.*, COMPNT_MANUFAC_FAMILY.Pref FROM COMPNT_PRICE_LIST INNER JOIN COMPNT_MANUFAC_FAMILY ON COMPNT_PRICE_LIST.compnt_man_Fam_ID = COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID " +
					" Where (((COMPNT_PRICE_LIST.COMPONENT_ID) = " + Price_compnt_ID + ")" + whr1 + whr2 + whr3 + ") " + ord1 + ord2 + ord3;
				SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
				OConn.Open ();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql ;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();
				while (Oreadr.Read ())
				{
					//Desc=Oreadr["Manufac_PARTN"].ToString();
					Desc =Oreadr["Primax_PARTN"].ToString() +"~~" + Oreadr["Manufac_PARTN"].ToString();
					if (pref == "0")
					{
						pref =  Oreadr["pref"].ToString ();
					//	prc = Convert.ToString( Math.Round(Tools.Conv_Dbl(Oreadr["price"].ToString ()) * Tools.Conv_Dbl(D_qty), Charger.NB_DEC_AFF));  //G_Price=Sell_Price
                        prc = Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["Cost_Price"].ToString()) * Tools.Conv_Dbl(D_qty), Charger.NB_DEC_AFF)); //G_Price=COST_Price
						majREALV(Convert.ToInt32(Orig_compnt_ID), Oreadr["Cat1_Value"].ToString (), Oreadr["Cat2_Value"].ToString (), Oreadr["Cat3_Value"].ToString (), Oreadr["Cat4_Value"].ToString (), Oreadr["Cat5_Value"].ToString (), Oreadr["Cat6_Value"].ToString (), prc,Desc );
					}
					else
					{
						if (Convert.ToInt32(pref) > Convert.ToInt32(Oreadr["pref"].ToString()))
						{
							pref = Oreadr["pref"].ToString ();
					//		prc = Convert.ToString (Math.Round( Tools.Conv_Dbl(Oreadr["price"].ToString ()) * Tools.Conv_Dbl(D_qty), Charger.NB_DEC_AFF  )); //G_Price=Sell_Price
                            prc = Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["Cost_Price"].ToString()) * Tools.Conv_Dbl(D_qty), Charger.NB_DEC_AFF)); //G_Price=COST_Price
                            majREALV(Convert.ToInt32(Orig_compnt_ID), Oreadr["Cat1_Value"].ToString (), Oreadr["Cat2_Value"].ToString (), Oreadr["Cat3_Value"].ToString (), Oreadr["Cat4_Value"].ToString (), Oreadr["Cat5_Value"].ToString (), Oreadr["Cat6_Value"].ToString (), prc,Desc);
			
					//		majREALV(Convert.ToInt32 (Orig_compnt_ID), Oreadr["Cat1_Value"], Oreadr["Cat2_Value"], Oreadr["Cat3_Value"], Oreadr["Cat4_Value"], Oreadr["Cat5_Value"], Oreadr["Cat6_Value"], prc);
							//old one....	majREALV(Orig_compnt_ID, rstPricelst!Cat1_Value, rstPricelst!Cat2_Value, rstPricelst!Cat3_Value, rstPricelst!Cat4_Value, rstPricelst!Cat5_Value, rstPricelst!Cat6_Value, prc);
						}         
					}
		
				}
				 OConn.Close (); 
			}
			else
			{
				//MessageBox.Show  ("Price Cat#1 Empty...." + "CPT_ID= " + Orig_compnt_ID + "    cat1=" + cat1V + "  cat2=" + cat2V + "  cat3=" + cat3V + "  QTY=" + D_qty + "/ ");
				majREALV(Orig_compnt_ID, cat1V, cat2V, cat3V, Charger.VIDE, Charger.VIDE, Charger.VIDE, Charger.VIDE,Charger.VIDE);
			}
			if (pref != "0") 
			{
				seekPriceADO_Res = prc;
				if (prc == "0")
				{
				//	MessageBox.Show ("Price Found  is 0.00 this means " + "CPT_ID= " + Orig_compnt_ID + "    cat1=" + cat1V + "  cat2=" + cat2V + "  cat3=" + cat3V + "  QTY=" + D_qty + "/ " );
					majREALV(Orig_compnt_ID, cat1V, cat2V, cat3V, Charger.VIDE, Charger.VIDE, Charger.VIDE, "n/e",Charger.VIDE);
				}
			}
			else majREALV(Orig_compnt_ID, cat1V, cat2V, cat3V, Charger.VIDE, Charger.VIDE, Charger.VIDE, Charger.VIDE,Charger.VIDE);
          
			return seekPriceADO_Res;


        }


        private string seekPrice_Configo_147(string cat1V, string cat2V, string cat3V, string c1, string c2, string c3, string code, string D_qty, string KAac,ref double KAfound)
        {


            string seekPriceADO_Res = Charger.VIDE;
            string whr1 = "", whr2 = "", whr3 = "", whr4 = "", ord1 = "", ord2 = "", ord3 = "", ord4 = "";

            string pref = "0";
            string Desc = "";
            CAP1 = cat1V;
            CAP2 = cat2V;
            CAP3 = cat3V;
            string prc = Charger.VIDE;
            // if (c1 == "")  MessageBox.Show("ERoooooooooooooooooooooooooRRR c1 is EMPTY in SeekingPrice....");
            if (cat1V != Charger.VIDE && cat2V != Charger.VIDE && cat3V != Charger.VIDE && D_qty != Charger.VIDE)
            {
                if (c1 == "=")
                {
                    whr1 = " ([PHASE]='" + cat1V + "') ";
                    ord1 = " ORDER BY [PHASE] ";
                }
                else
                {
                    whr1 = "  AND (" + cat1V + c1 + " cast([PHASE] AS float)) ";
                    ord1 = " ORDER BY [PHASE]  ";
                }
                if (c2 != "")
                {
                    if (c2 == "=")
                    {
                        whr2 = "   AND ([VAC]='" + cat2V + "') ";
                        ord2 = " ,[VAC] ";
                    }
                    else
                    {
                        whr2 = "  AND (" + cat2V + c2 + " cast([VAC] AS float)) ";
                        ord2 = " , [VAC]";
                    }
                }
                if (c3 != "")
                {
                    if (c3 == "=")
                    {
                        whr3 = "   AND ([ICB1]='" + cat3V + "') ";
                        ord3 = " ,[ICB1] ";
                    }
                    else
                    {
                        whr3 = "  AND (" + cat3V + c3 + " cast([ICB1] AS float)) ";
                        ord3 = " , [ICB1] ";
                    }
                }


                string VSCnm = "", KAnm = "";

                    double ddvac = Tools.Conv_Dbl(cat2V);


                    if (ddvac < 240) VSCnm = "[VSC ac 120]";
                    else
                    {
                        if (ddvac < 400) VSCnm = "[VSC ac 240]";
                        else
                        {
                            if (ddvac < 480) VSCnm = "[VSC ac 400]";
                            else
                            {
                                if (ddvac < 600) VSCnm = "[VSC ac 480]";
                                else VSCnm = "[VSC ac 600]";
                            }
                        }
                    }
                KAnm = VSCnm;
                if (Tools.Conv_Dbl(KAac) > 0)
                {
                    if (VSCnm != "")
                    {
                        whr4 = "  AND (" + KAac + " <= " + VSCnm + ") ";
                        ord4 = " , " + VSCnm;
                    }
                }
                else VSCnm = "";

                //string stSql = "SELECT COMPNT_PRICE_LIST.*, COMPNT_MANUFAC_FAMILY.Pref FROM COMPNT_PRICE_LIST INNER JOIN COMPNT_MANUFAC_FAMILY ON COMPNT_PRICE_LIST.compnt_man_Fam_ID = COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID " +
                //    " Where (((COMPNT_PRICE_LIST.COMPONENT_ID) = " + Price_compnt_ID + ")" + whr1 + whr2 + whr3 + ") " + ord1 + ord2 + ord3;


                string stSql = "SELECT *   FROM Configo_CB1xx_CB2xx  where " + whr1 + whr2 + whr3 + whr4 + ord1 + ord2 + ord3 + ord4 + ",Priority  ";
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                bool found = false, fin = false;
                while (Oreadr.Read() && !fin)
                {

                    Desc = Oreadr["Description"].ToString();
                    pref = Oreadr["Priority"].ToString();
                    //   prc = Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["Cost Price"].ToString()) * Tools.Conv_Dbl(D_qty), Charger.NB_DEC_AFF)); //G_Price=COST_Price
                    prc = Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["Sell Price"].ToString()) * Tools.Conv_Dbl(D_qty), Charger.NB_DEC_AFF));

                    string KA = "";
                    if (KAnm != "")
                    {
                        double dd = Tools.Conv_Dbl(Oreadr[KAnm.Replace("[", "").Replace("]", "")].ToString());
                        if (dd > 0) KA = " - " + dd.ToString() + " KA IC";
                        KAfound = dd;
                    }

                    string newDesc = "";
                    newDesc = (KAac == "") ? Oreadr["ICB1"].ToString() + "A - " + cat2V + "V ac" + KA : Oreadr["ICB1"].ToString() + "A - " + cat2V + "V ac - " + Oreadr[VSCnm.Replace("[", "").Replace("]", "")].ToString() + "KA IC";

                    //old
                    // majREALV(147, Oreadr["PHASE"].ToString(), Oreadr["VAC"].ToString(), Oreadr["ICB1"].ToString(),"","","", prc, Desc);

                    majREALV(147, Oreadr["PHASE"].ToString(), Oreadr["VAC"].ToString(), Oreadr["ICB1"].ToString(), "", "", "", prc, newDesc);

                    seekPriceADO_Res = prc;
                    fin = true;
                    found = true;
                }

                if (!found)
                {
                    //case breaker not found in XL 

                    seekPriceADO_Res = "-99999";// Charger.VIDE;

                    //   majREALV(147, cat1V, cat2V, cat3V, Charger.VIDE, Charger.VIDE, Charger.VIDE, "n/e","Special Breaker: please call PRIMAX ");
                    majREALV(147, cat1V, cat2V, cat3V, Charger.VIDE, Charger.VIDE, Charger.VIDE, "-99999", "Breaker NOT FOUND.... please call PRIMAX or change Charger Values.. ");

                }
                OConn.Close();

            }
            else
            {
                //MessageBox.Show  ("Price Cat#1 Empty...." + "CPT_ID= " + Orig_compnt_ID + "    cat1=" + cat1V + "  cat2=" + cat2V + "  cat3=" + cat3V + "  QTY=" + D_qty + "/ ");
                majREALV(147, cat1V, cat2V, cat3V, Charger.VIDE, Charger.VIDE, Charger.VIDE, Charger.VIDE, Charger.VIDE);
            }

            //else majREALV(147, cat1V, cat2V, cat3V, Charger.VIDE, Charger.VIDE, Charger.VIDE, Charger.VIDE,Charger.VIDE);

            return seekPriceADO_Res;



        }


        private string seekPrice_Configo_226(string cat1V, string cat2V, string cat3V, string c1, string c2, string c3, string code, string D_qty, string KAdc, ref double KAfound)
        {


            string seekPriceADO_Res = Charger.VIDE;
            string whr1 = "", whr2 = "", whr3 = "", whr4 = "", ord1 = "", ord2 = "", ord3 = "", ord4 = "";

            string pref = "0";
            string Desc = "";
            CAP1 = cat1V;
            CAP2 = cat2V;
            CAP3 = cat3V;
            string prc = Charger.VIDE;
            // if (c1 == "")  MessageBox.Show("ERoooooooooooooooooooooooooRRR c1 is EMPTY in SeekingPrice....");
            if (cat1V != Charger.VIDE && cat2V != Charger.VIDE && cat3V != Charger.VIDE && D_qty != Charger.VIDE)
            {
                if (c1 == "=")
                {
                    whr1 = " ([PHASE]='" + cat1V + "') ";
                    ord1 = " ORDER BY [PHASE] ";
                }
                else
                {
                    whr1 = "  AND (" + cat1V + c1 + " cast([PHASE] AS float)) ";
                    ord1 = " ORDER BY [PHASE]  ";
                }
                if (c2 != "")
                {
                    if (c2 == "=")
                    {
                        whr2 = "   AND ([VDC]='" + cat2V + "') ";
                        ord2 = " ,[VDC] ";
                    }
                    else
                    {
                        whr2 = "  AND (" + cat2V + c2 + " cast([VDC] AS float)) ";
                        ord2 = " , [VDC]";
                    }
                }
                                            // // ord2 = " , [VDC]";
                if (c3 != "")
                {
                    if (c3 == "=")
                    {
                        whr3 = "   AND ([ICB1]='" + cat3V + "') ";
                        ord3 = " ,[ICB1] ";
                    }
                    else
                    {
                        whr3 = "  AND (" + cat3V + c3 + " cast([ICB1] AS float)) ";
                        ord3 = " , [ICB1] ";
                    }
                }


                string VSCnm = "",KAnm="";

                    double ddVDC = Tools.Conv_Dbl(cat2V);
                   

                    if (ddVDC < 130) VSCnm = "[VSC dc 125]";
                    else
                    {
                        if (ddVDC < 250) VSCnm = "[VSC dc 130]";
                        else
                        {
                                if (ddVDC < 600) VSCnm = "[VSC dc 250]";
                                else VSCnm = "[VSC dc 600]";
                           
                        }
                    }
                KAnm = VSCnm;
                if (Tools.Conv_Dbl(KAdc) > 0)
                {
                    if (VSCnm != "")
                    {
                        whr4 = "  AND (" + KAdc + " <= " + VSCnm + ") ";
                        ord4 = " , " + VSCnm;
                    }
                }
                else VSCnm = "";

                //string stSql = "SELECT COMPNT_PRICE_LIST.*, COMPNT_MANUFAC_FAMILY.Pref FROM COMPNT_PRICE_LIST INNER JOIN COMPNT_MANUFAC_FAMILY ON COMPNT_PRICE_LIST.compnt_man_Fam_ID = COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID " +
                //    " Where (((COMPNT_PRICE_LIST.COMPONENT_ID) = " + Price_compnt_ID + ")" + whr1 + whr2 + whr3 + ") " + ord1 + ord2 + ord3;


                string stSql = "SELECT *   FROM Configo_CB2xx  where " + whr1 + whr2 + whr3 + whr4 + ord1 + ord2 + ord3 + ord4 + ",Priority  ";
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                bool found = false, fin = false;
                while (Oreadr.Read() && !fin)
                {

                    Desc = Oreadr["Description"].ToString();
                    pref = Oreadr["Priority"].ToString();

                 //   prc = Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["Cost Price"].ToString()) * Tools.Conv_Dbl(D_qty), Charger.NB_DEC_AFF)); //G_Price=COST_Price
                    prc = Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["Sell Price"].ToString()) * Tools.Conv_Dbl(D_qty), Charger.NB_DEC_AFF));

                    string KA = "";
                    if (KAnm != "")
                    {
                        double dd = Tools.Conv_Dbl(Oreadr[KAnm.Replace("[", "").Replace("]", "")].ToString());
                        if (dd > 0) KA = " - " + dd.ToString() + " KA IC";
                        KAfound = dd;
                    }
                    //old
                    //    string newDesc=(KAdc=="") ? Oreadr["ICB1"].ToString() + "A - " + cat2V + "V dc" + KA  : Oreadr["ICB1"].ToString() + "A - " + cat2V + "V dc - " + Oreadr[VSCnm.Replace("[","").Replace("]", "")].ToString()  + "KA IC";
                   // dddddddddddddddddddddddd

                    string newDesc = (KAdc == "") ? Oreadr["ICB1"].ToString() + "A - " + Oreadr["VDC"].ToString() + "V dc" + KA : Oreadr["ICB1"].ToString() + "A - " + cat2V + "V dc - " + Oreadr[VSCnm.Replace("[", "").Replace("]", "")].ToString() + "KA IC";


                    //old
                    // majREALV(147, Oreadr["PHASE"].ToString(), Oreadr["VAC"].ToString(), Oreadr["ICB1"].ToString(),"","","", prc, Desc);
                    majREALV(226, Oreadr["PHASE"].ToString(), Oreadr["VDC"].ToString(), Oreadr["ICB1"].ToString(),"","","", prc, newDesc);
                       
                    seekPriceADO_Res = prc;
                    fin = true;
                    found = true;
                }

                if (!found)
                {
                    //case breaker not found in XL 

                    seekPriceADO_Res = "-99999";// Charger.VIDE;

                    //   majREALV(147, cat1V, cat2V, cat3V, Charger.VIDE, Charger.VIDE, Charger.VIDE, "n/e","Special Breaker: please call PRIMAX ");
                    majREALV(226, cat1V, cat2V, cat3V, Charger.VIDE, Charger.VIDE, Charger.VIDE, "-99999", "Breaker NOT FOUND.... please call PRIMAX or change Charger Values.. ");

                }
                OConn.Close();

            }
            else
            {
                //MessageBox.Show  ("Price Cat#1 Empty...." + "CPT_ID= " + Orig_compnt_ID + "    cat1=" + cat1V + "  cat2=" + cat2V + "  cat3=" + cat3V + "  QTY=" + D_qty + "/ ");
                majREALV(226, cat1V, cat2V, cat3V, Charger.VIDE, Charger.VIDE, Charger.VIDE, Charger.VIDE, Charger.VIDE);
            }

            //else majREALV(147, cat1V, cat2V, cat3V, Charger.VIDE, Charger.VIDE, Charger.VIDE, Charger.VIDE,Charger.VIDE);

            return seekPriceADO_Res;



        }

       string VSCacXXX(double ddvac)
        {
            string VSCnm = "";
            if (ddvac < 240) VSCnm = "[VSC dc 125]";
            else
            {
                if (ddvac < 400) VSCnm = "[VSC dc 130]";
                else
                {
                    if (ddvac < 480) VSCnm = "[VSC ac 400]";
                    else
                    {
                        if (ddvac < 600) VSCnm = "[VSC dc 250]";
                        else VSCnm = "[VSC dc 600]";
                    }
                }
            }
            return VSCnm;
        }



		private void majREALV(long cpt_id , string v1, string v2 ,string  v3, string v4 ,string  v5 ,string  v6, string prc ,string Desc)
		{	
          int i=Charger.lblIRealV ;
          Charger.arr_REALV[i, 0] = cpt_id.ToString();
          Charger.arr_REALV[i, 1] = v1; CAP1=v1;CAP2=v2;CAP3=v3;CAP4=v4;CAP5=v5;CAP6=v6;
          Charger.arr_REALV[i, 2] = v2;
          Charger.arr_REALV[i, 3] = v3;
          Charger.arr_REALV[i, 4] = v4;
          Charger.arr_REALV[i, 5] = v5;
          Charger.arr_REALV[i, 6] = v6;
          Charger.arr_REALV[i, 7] = prc;
          G_PRICE = prc;
		  G_Desc=Desc;
          Charger.lblIRealV = ++i;
         
		}


       void update_price_REALV(long cpt_id, string prc)
        {
            for (int ii = 0; ii < Charger.arr_REALV.Length; ii++)
            {
                if (Charger.arr_REALV[ii, 0] == cpt_id.ToString())
                {
                    Charger.arr_REALV[ii, 7] = prc;
                    ii = Charger.arr_REALV.Length + 1;
                }
            }
            
        }


        private void deco_CRIT(string st , ref string c1 ,ref string c2, ref string c3 )
  		{
           c1 = "";
           c2 = "";
           c3 = "";
           c1 = deco_oper(st.Substring(1, 1));
           if (st.Length  >= 4) c2 = deco_oper(st.Substring(3, 1));
           if (st.Length  >= 6) c3 = deco_oper(st.Substring(5, 1));

		}


		private void Catn_Val_ado(long Avail_id , int CM_ID, string phs , string chrg ,string vdc, string idc, ref string v1 , ref string v2 , ref  string v3 , ref string Qty , ref long cptPrice_id)
		{
		   string st;
			v1 = "0";
			v2 = "0";
			v3 = "0";
			Qty = "0";
			bool rec_Empty= true;
			string stSql = "select * from COMPUTE_MODELS where CM_ID=" + CM_ID;
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ())
			{
				rec_Empty = false;
				if (Oreadr["VCS1"].ToString()  != "0")
				{  
					if (Oreadr["TYPcat1"].ToString().Substring(0, 1) == "C")
						v1 = Cal_VCS(Convert.ToInt32(Oreadr["VCS1"].ToString()) , "*");
					else
					{
						st = Oreadr["TYPcat1"].ToString ();
						v1 = findRealV(st.Substring(1, 1),st.Substring( 3, st.Length  - 3) );
						if (v1 == "0") 
						{
						  Cal_chrg_CostADO(Convert.ToInt32(st.Substring (3, st.Length - 3)), st.Substring(0, 2),"","");
						  v1 = findRealV(st.Substring(1, 1), st.Substring (3, st.Length - 3));
						}
					}
				}
				if (Oreadr["VCS2"].ToString()  != "0")
				{
					if (Oreadr["TYPcat2"].ToString().Substring(0, 1) == "C") 
					  v2 = Cal_VCS(Convert.ToInt32(Oreadr["VCS2"].ToString()) , "*");
				    else
					{
					  st = Oreadr["TYPcat2"].ToString ();
					  v2 = findRealV(st.Substring (1, 1),st.Substring(3, st.Length - 3));
					  if (v2 == "0")
					  {
					    Cal_chrg_CostADO(Convert.ToInt32(st.Substring (3, st.Length - 3)), st.Substring(0, 2),"","");
					    v2 = findRealV(st.Substring (1, 1), st.Substring(3, st.Length - 3));
					  }
					}
				}
			    if (Oreadr["VCS3"].ToString () != "0")
				{
			        if (Oreadr["TYPcat3"].ToString().Substring(0, 1) == "C") 
                        v3 = Cal_VCS(Convert.ToInt32(Oreadr["VCS3"].ToString()) , "*");
                    else
					{
						st = Oreadr["TYPcat3"].ToString ();
						v3 = findRealV(st.Substring (1, 1), st.Substring(3, st.Length - 3));
					   // v3 = findRealV(d(st, 2, 1), CLng(Mid(st, 4, Len(st) - 2)))
					    if (v3 == "0") 
					    {
						   Cal_chrg_CostADO(Convert.ToInt32(st.Substring (3, st.Length - 3)), st.Substring(0, 2),"","");
						   v3 =  findRealV(st.Substring (1, 1),st.Substring(3, st.Length - 3));
					   }
					}
			    }
                if (Oreadr["VCS_Qty"].ToString()  != "0")   Qty = Cal_VCS(Convert.ToInt32(Oreadr["VCS_Qty"].ToString()) , "*");
                cptPrice_id = Convert.ToInt32(Oreadr["PRC_Compnt_ID"].ToString()) ;
			}
			OConn.Close ();
            if (rec_Empty) MainMDI_stMsgXP = "ERROR IN Seeking CModels ... Many or NO Model...check...";
       }

		private string deco_oper(string st)
		{
			string tt=Charger.VIDE ; 
			switch (st)
			{
				case "<=":
					tt= "(";
					break;
				case ">=":
					tt= ")";
					break;
				case "(": 
					tt= "<=";
					break;
				case ")":
					tt=  ">=";
					break;
		        default:
					tt=st;
					break;
			}
           return tt;
		}
		private void CR_TBL6()
		{
            //Create TBL6   table is 'pgm_SeekTBL6_empty'
            string errmsg = "";
			MainMDI.ExecSql("delete pgm_SeekTBL6_empty " ,ref errmsg);
			string stSql ="INSERT INTO pgm_SeekTBL6_empty (Col1, col2, col3, col4, col5, col6, VALUE1, TABLE_NAME) " +
				"  SELECT     Configo_TABLES_CONTENT.COL1 AS col1, Configo_TABLES_CONTENT.COL2 AS col2, Configo_TABLES_CONTENT.COL3 AS col3, Configo_TABLES_CONTENT.COL4 AS col4,  " +
				"  Configo_TABLES_CONTENT.COL5 AS col5, Configo_TABLES_CONTENT.COL6 AS col6, Configo_TABLES_CONTENT.VALUE1, TABLES_LIST.TABLE_NAME " +
				" FROM         TABLES_LIST INNER JOIN Configo_TABLES_CONTENT ON TABLES_LIST.TABLE_ID = Configo_TABLES_CONTENT.TABLE_ID " +
				"   ORDER BY TABLES_LIST.TABLE_NAME ";
			MainMDI.ExecSql(stSql, ref errmsg); 
		}

        public string FRML_CostADO(long compntID, string code)
        {

            string Cal_chrg_CostADO_Res = Charger.VIDE;
            //	 bool rec_Empty = true;
            string c1 = "", c2 = "", c3 = "";  // To be Verified..... !!!!!!
            string val1 = "", val2 = "", val3 = "";
            string prc = Charger.VIDE, stSql = "";

            if (AvailId != -1) stSql = "SELECT TBLAVAIL" + P + ".Avail_ID, Configo_COMPNT_LIST.Component_ID,Configo_COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + P + ".charger, TBLAVAIL" + P + ".vdc, TBLAVAIL" + P + ".idc, link_COMPNT_AVAIL.Qty, " +
                 " Configo_COMPNT_LIST.CAT1_TABLE_ID, Configo_COMPNT_LIST.CAT2_TABLE_ID, Configo_COMPNT_LIST.CAT3_TABLE_ID, Configo_COMPNT_LIST.Compnt_Type, Configo_COMPNT_LIST.Value_Type, Configo_COMPNT_LIST.nbc3Cat " +
                 " FROM (TBLAVAIL" + P + " INNER JOIN link_COMPNT_AVAIL ON TBLAVAIL" + P + ".Avail_ID = link_COMPNT_AVAIL.Avail_ID) INNER JOIN Configo_COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = Configo_COMPNT_LIST.Component_ID " +
                 " Where (((link_COMPNT_AVAIL.phs) = '" + P + "') and ((Configo_COMPNT_LIST.Component_ID) = " + compntID + ") and ((TBLAVAIL" + P + ".Avail_ID) = " + AvailId + ")) ORDER BY TBLAVAIL" + P + ".charger,cast(TBLAVAIL" + P + ".vdc AS float),cast(TBLAVAIL" + P + ".idc AS float ), Configo_COMPNT_LIST.Component_ID";
            else stSql = " SELECT  Component_ID, COMPONENT_REF, '" + Charger.C + "' AS charger, '" + Charger.V + "' AS vdc, '" + Charger.I + "' AS idc, 1 AS Qty, CAT1_TABLE_ID, CAT2_TABLE_ID, CAT3_TABLE_ID, Compnt_Type, Value_Type, nbc3Cat, '" + Charger.P + "' AS phs " +
       " FROM  Configo_COMPNT_LIST WHERE Component_ID =" + compntID + " ORDER BY Component_ID";


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            //	string old_CHRG_REF = "";
            string D_qty = Charger.VIDE;
            while (Oreadr.Read())
            {
                string Qty = "0";
                long cptPrice_id = 0;
                //	rec_Empty = false;
                //	string chrg_ref = Oreadr["charger"] + "-" + P + "-" + Oreadr["vdc"] + "-" + Oreadr["idc"];
                string cc = Oreadr["Compnt_Type"].ToString();
                switch (cc)
                {
                    case "D":
                    case "E":
                    case "F":
                    case "T":
                    case "S":
                    case "C":
                        deco_CRIT(Oreadr["nbc3Cat"].ToString(), ref c1, ref c2, ref c3);
                        Catn_Val_ado(Convert.ToInt32(AvailId), Convert.ToInt32(Oreadr["Value_Type"].ToString()), P, Oreadr["charger"].ToString(), Oreadr["vdc"].ToString(), Oreadr["idc"].ToString(), ref val1, ref val2, ref val3, ref Qty, ref cptPrice_id);
                        if (val1 == "0")
                        {
                            c1 = "";
                            // MessageBox.Show ("Category #1 value is Empty.......VCS_ID=" + Oreadr["Value_Type"] + " V1=" + val1 + " V2=" + val2 + " V3=" + val3);
                        }
                        if (val2 == "0") c2 = "";
                        if (val3 == "0") c3 = "";
                        if (Qty == "0") D_qty = Oreadr["Qty"].ToString();
                        else if (Qty != Charger.VIDE) D_qty = Tools.Conv_Dbl(Qty).ToString();
                        if (cptPrice_id == 0) prc = seekPriceADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()), Convert.ToInt32(Oreadr["Component_ID"]), val1, val2, val3, c1, c2, c3, code, D_qty);
                        else prc = seekPriceADO(Convert.ToInt32(Oreadr["Component_ID"]), cptPrice_id, val1, val2, val3, c1, c2, c3, code, D_qty);
                        Real_QTY = D_qty;
                        break;
                    case "Z":
                        val1 = Charger.VIDE;
                        val2 = Charger.VIDE;
                        val3 = Charger.VIDE;
                        prc = seekPriceADO(Convert.ToInt32(Oreadr["Component_ID"]), Convert.ToInt32(Oreadr["Component_ID"]), val1, val2, val3, "=", "=", "=", code, D_qty);   //* Conv_Dbl(rstAvail!Qty)
                        break;
                    case "%":
                        G_PRICE = Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["Value_Type"].ToString()) * Tools.Conv_Dbl(Oreadr["Qty"].ToString()), Charger.NB_DEC_AFF));
                        Real_QTY = Oreadr["Qty"].ToString();
                        break;
                    case "$":

                        string st_dollar = Cal_VCS(Int32.Parse(Oreadr["Value_Type"].ToString()), "*");
                        G_PRICE = Convert.ToString(Math.Round(Tools.Conv_Dbl(st_dollar) * Tools.Conv_Dbl(Oreadr["Qty"].ToString()), Charger.NB_DEC_AFF));
                        Real_QTY = Oreadr["Qty"].ToString();
                        break;
                    default:
                        MainMDI_stMsgXP = "ERROR in Cost Process... bad Compnt_Type=  " + Oreadr["Compnt_Type"];
                        prc = "0";
                        break;
                }
                //	old_CHRG_REF = chrg_ref;

            }
            OConn.Close();
            //    if (prc == MainMDI.VIDE && compntID==173) prc = prc; 
            //return Cal_chrg_CostADO_Res ;
            return prc;
        }
	}
}
