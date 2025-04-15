using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using EAHLibs;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for TestEQA.
	/// </summary>
	public class TestEQA
	{
		private string in_Chrgr_TV = "";
		private Lib1 Tools = new Lib1();

		public TestEQA(string x_Chrgr_TV)
		{
			in_Chrgr_TV = x_Chrgr_TV;
			//in_Test_TV = x_Test_TV;
			//
			//TODO: Add constructor logic here
			//
		}

		public string look_Tests_VCS(string Vcs)
		{
			return (Vcs == MainMDI.VIDE) ? MainMDI.VIDE : 
				MainMDI.Find_One_Field("select CONTENT  from COMPUTE_VCS where VCS_TYPE='T' AND VCS_NAME='" + Vcs + "'");
		}

		public string look_Req_Value(string frml, string Flist, char c) //'A' means Flist is Alrm frml ... 'C' means Flist is Charger frml
		{
			//'A' means Flist is Alrm frml ... 'C' means Flist is Charger frml 
			//added 260506
			//if (c == 'C') frml += "||";
			//added 260506
			if (Flist == ";" || Flist == "~") return "free";
			else
			{
				string U_Flist = Flist.ToUpper();
				string sepFrml = "~";
				if (c == 'C')
				{
					if (frml[0] == '!') frml=frml.Substring(1, frml.Length - 1);
					sepFrml = " ";
					//added 260506
					//frml += "||";
					//added 260506
				}
				string U_frml = frml.ToUpper();
			
				//string Flist = lvQITEMS.Items[Convert.ToInt32(litmID.Text)].SubItems[15].Text;
				//string tt = Flist.ToUpper();
				if (frml[0] == '#') return Deco_Frml(frml.Substring(1, frml.Length - 1));
				else
				{
					int ipos = U_Flist.IndexOf(U_frml + "||");
					if (ipos != -1)
					{
						int ipos2 = Flist.IndexOf(sepFrml, ipos);
						if (ipos2 == -1) ipos2 = (Flist[Flist.Length - 1] == ';') ? Flist.Length - 2 : Flist.Length;
						string stF = Flist.Substring(ipos + frml.Length + 2, ipos2 - (ipos + frml.Length + 2));
						//string stF = Flist.Substring(ipos + frml.Length, ipos2 - (ipos + frml.Length));
						if (stF == "") return "???";
						if (stF[0] != '!') return stF;
						else return Deco_Frml(stF); //??? !FLOAT * V3.25V^V; a revoir //.Substring(1, stF.Length - 1));
					}
				}
				return "???";
			}
		}

		private string calul_Amnt(string amnt1, string oper, string amnt2)
		{
			//On Error GoTo cal_Err
			string calul_Amnt_Res = "0";
			double mnt1 = 0, mnt2 = 0;
			if (amnt1 == Charger.VIDE || amnt2 == Charger.VIDE) return "0";
			if (oper != "&")
			{
				mnt1 = Tools.Conv_Dbl(amnt1);
				mnt2 = Tools.Conv_Dbl(amnt2);
			}
			switch (oper)
			{
				case "*":
					calul_Amnt_Res = Convert.ToString(Math.Round(mnt1 * mnt2, Charger.NB_DEC_CAL));
					break;
				case "-":
					calul_Amnt_Res = Convert.ToString(Math.Round(mnt1 - mnt2, Charger.NB_DEC_CAL));
					break;
				case "/":
					if (mnt2 > 0) calul_Amnt_Res = Convert.ToString(Math.Round(mnt1 / mnt2, Charger.NB_DEC_CAL));
					else calul_Amnt_Res = "0";
					break;
				case "+":
					calul_Amnt_Res = Convert.ToString(Math.Round(mnt1 + mnt2, Charger.NB_DEC_CAL));
					break;
				case "&":
					calul_Amnt_Res = amnt1 + amnt2;
					break;
				default:
					MessageBox.Show("Operator is Invalid.....=" + oper);
					break;
			} 
			return calul_Amnt_Res;
		}

		private bool deco_Var(string var, ref string VarValue)
		{ 
			bool found = false;
			string st = "";
			//bool deco_Var_Res = true;

			switch (var.Substring(0, 1))
			{
				case "V":
					VarValue = var.Substring(1, var.Length - 2);
					found = true;
					break;
				case "$":
					VarValue = var.Substring(1, var.Length - 2);
					//VarValue = cleanSt(VarValue);
					found = true;
					break;
				case "!":
					VarValue = look_Req_Value(var.Substring(1, var.Length - 1), in_Chrgr_TV, 'C');
					found = true;
					break;
				default:
					found = true;
					VarValue = st;
					break;
			}
			return found;
		}

		private string Deco_Frml(string frml)
		{
			string var = "", VarValue = ""; //, argType = "";
			int OPos = 0, ipos = 0;
			string amnt1 = "";
			string Total = "";
			string oper = "", UN = "";
			//new
			ipos = frml.IndexOf("^");
			if (ipos != -1)
			{
				UN = frml.Substring(ipos + 1, frml.Length - ipos - 1);
				frml = frml.Substring(0, ipos);
			}
			//new
			string st = frml + ";";

			while (st.Substring(OPos, 1) != ";")
			{ 
				ipos = st.IndexOf(" ", OPos);
				if (ipos == -1) ipos = frml.Length;
				var = st.Substring(OPos, ipos - OPos);
				if (var != " ")
				{
					if (var.Length > 1)
					{
						if (!deco_Var(var, ref VarValue)) VarValue = var;
						if (Total == "") Total = VarValue;
						else amnt1 = VarValue;
					}	
					else oper = var;
					if (oper != "" && amnt1 != "" && Total != "")
					{
						Total = calul_Amnt(Total, oper, amnt1);
						amnt1 = "";
					}
				}
				//if (ipos == frml.Length) ipos--;
				OPos = (ipos >= frml.Length) ? ipos : ipos + 1; //Opos = opos + 1;
			}
			//Deco_Frml_Res = Total;
			Total = (UN == "") ? Total : Total + "^" + UN;
			return Total;
		}

		public string boolToCartt(string st, char typ, ref string UN)
		{
			//typ = T text typ = B bool checked or Not

			int ipos = st.IndexOf("^");
			if (ipos != -1)
			{
				UN = st.Substring(ipos + 1, st.Length - ipos -1);
				st = st.Substring(0, ipos);
			}
			else UN = "";
			string res = "";
			switch (st)
			{
				case "E":
				case "ON":
					res = "Y";
					break;
				case "D":
				case "OFF":
					res = "N";
					break;
			}
			if (typ == 'T' && st != MainMDI.VIDE && st != "???") res = st;
			return res;
		}

		public string boolToCar(string st, char typ, ref string UN, char F)
		{
			//typ = T text typ = B bool checked or Not F = Full--->Yes or No f = else just 'Y' or 'N'
		
			if (st == "free") return "~";
			int ipos = st.IndexOf("^");
			if (ipos != -1)
			{
				UN = st.Substring(ipos + 1, st.Length - ipos - 1);
				st = st.Substring(0, ipos);
			}
			else UN = "";
			string res = "";
			switch (st)
			{
				case "E":
				case "ON":
					res = (F == 'F') ? "Yes" : "Y";
					break;
				case "D":
				case "OFF":
					//res = "N";
					res = (F == 'F') ? "No" : "N";
					break;
			}
			if (typ == 'T' && st != MainMDI.VIDE && st != "???") res = st; //&& st != "~"
			return res;
		}

		public string CarToBool(string st, string UN)
		{
			//typ = T text typ = B bool checked or Not

			string res = "";
			char typ = 'T';
			switch (st)
			{
				case "Y":
					res = "E";
					typ = 'B';
					break;
				case "N":
					res = "D";
					typ = 'B';
					break;
			}
			if (typ == 'T' && st != MainMDI.VIDE && st != " " && st != "???") res = st;
			if (UN != "" && res != "") res += "^" + UN;
			return res;
		}

		public static string CarToBool(string st, string UN, char F)
		{
			//typ = T text typ = B bool checked or Not
			//UN = "";
			string res = "";
			char typ = 'T';
			UN = ""; //ede 2011
			switch (st)
			{
				case "Y":
				case "Yes":
					res = "E";
					typ = 'B';
					break;
				case "N":
				case "No":
					res = "D";
					typ = 'B';
					break;
			}
			if (typ == 'T' && st != MainMDI.VIDE && st != " " && st != "???") res = st;
			if (UN != "" && res != "") res += "^" + UN;
			return res;
		}
	}
}