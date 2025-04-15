using System;
using System.Windows.Forms;
using System.Threading;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using EAHLibs;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for Charger_UPSCOST_P850i.
	/// </summary>
	public class Charger_UPSCOST_P850U
	{
		private Charger_UPS CHRGR_UPS;
		private Component_UPS Cpt_UPS;
		private Lib1 Tools = new Lib1();
		string[] arr_VDC=new string[100];
		string[] arr_IDC=new string[100];
		string G_Base_CHRG = "";
		string G_BASE_TOT = "0";
		long XL_Fldcount = 0;

		private char in_Phs = '*';
		private UPS_maker in_frm_UPS_maker;
		ManualResetEvent in_Stop;
		ManualResetEvent in_Stopped;

		public Charger_UPSCOST_P850U(ManualResetEvent x_Stop, ManualResetEvent x_Stopped, UPS_maker x_frm_UPS_maker)
		{
			//
			//TODO: Add constructor logic here
			//
			in_Phs= x_frm_UPS_maker.curr_PHS;
			in_Stop = x_Stop;
			in_Stopped = x_Stopped;
			in_frm_UPS_maker = x_frm_UPS_maker;
		}

		public Charger_UPSCOST_P850U(UPS_maker x_frm_UPS_maker)
		{
			in_frm_UPS_maker = x_frm_UPS_maker;
		}

		private void fill_VDC_IDC(char c)
		{
			int i = 0;
			string VDC_IDC = (c == 'V') ? "VDCNOMINAL" : "IDC";
			string stSql = "SELECT     CAST(TABLES_CONTENT.VALUE1 AS Int) AS VDCIDC " +
				" FROM         TABLES_CONTENT INNER JOIN TABLES_LIST ON TABLES_CONTENT.TABLE_ID = TABLES_LIST.TABLE_ID " +
				" WHERE     (TABLES_LIST.TABLE_NAME = '" + VDC_IDC + "') " +
				" ORDER BY CAST(TABLES_CONTENT.VALUE1 AS Int) ";

			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			
			for (i = 0; i < 100; i++)
            {
				if (c == 'V') arr_VDC[i++] = ""; 
				else arr_IDC[i++] = "";
            }
			i = 0;
			int ic = 1;
			while (Oreadr.Read())
            {
				if (c == 'V') arr_VDC[i++] = Oreadr[0].ToString(); 
				else arr_IDC[ic++] = Oreadr[0].ToString();
			}
			OConn.Close();
		}

		public void XL_ALL_CHRGR13()
		{
			XL_ALL();
		}

		public void Cal_ONEUPS_ONECPT_priceList(string p850x, string phsout, string kva, string outV, string DCbus, string phsin, string inV, 
			string phsbps, string bpsIN, string Cbatt, string perfFactr, string timeChrg, string FLT, string EQLZ, string vdcmin, 
			string vdcmax)
		{
			//CHARGER_ONEUPS_ONECOST(Oreadr["UPS"].ToString(), Oreadr["PHSout"].ToString(), Oreadr["OP_KVA"].ToString(), Oreadr["ACoutputV"].ToString(), Oreadr["DCBus"].ToString(), Oreadr["PHSin"].ToString(), Oreadr["ACinputV"].ToString(), Oreadr["PHSbps"].ToString(), Oreadr["BpsinputV"].ToString(), "0", "0.8", "8");
			//string st = Oreadr["UPS"].ToString() + "-" + Oreadr["PHSout"].ToString() + "-" + Oreadr["OP_KVA"].ToString() + "-" + Oreadr["ACoutputV"].ToString() + "    (Cost)";

			CHARGER_ONEUPS_ONECOST(p850x, phsout, kva, outV, DCbus, phsin, inV, phsbps, bpsIN, Cbatt, perfFactr, timeChrg, FLT, EQLZ, vdcmin, 
				vdcmax);
		}

		public string Cal_ONEUPS_ONECPT_FRMULAS(string p850x, string phsout, string kva, string outV, string DCbus, string phsin, string inV, 
			string phsbps, string bpsIN, string Cbatt, string perfFactr, string timeChrg, string cptid, string vcsname, string FLT, 
			string EQLZ, string vdcmin, string vdcmax)
		{
			string res = CHARGER_ONEUPS_ONEVCS(p850x, phsout, kva, outV, DCbus, phsin, inV, phsbps, bpsIN, Cbatt, perfFactr, timeChrg, cptid, 
				vcsname, FLT, EQLZ, vdcmin, vdcmax);
			return res;
		}

		//v1 = Cal_VCS(Convert.ToInt32(Oreadr["VCS1"].ToString()), "*");
		private string CHARGER_ONEUPS_ONEVCS(string UPS, string PHSout, string OP_KVA, string ACoutputV, string DCBus, string PHSin, 
			string ACinputV, string PHSbps, string BpsinputV, string Cbatt, string PF, string tcharge, string CPTid, string VCS, string FLT, 
			string EQLZ, string vdcmin, string vdcmax)
		{
			string P = "1", res = "";
			CHRGR_UPS = new Charger_UPS(6805, UPS, PHSout, OP_KVA, ACoutputV, DCBus, PHSin, ACinputV, PHSbps, BpsinputV, Cbatt, PF, tcharge, 
				FLT, EQLZ, vdcmin, vdcmax);

			//find phs in COMPNT_LIST_UPS
			string phs_read = MainMDI.Find_One_Field("select PHS from COMPNT_LIST_UPS where Component_ID=" + CPTid);
			if (phs_read != MainMDI.VIDE)
			{
				P = find_CPT_PHS(phs_read, PHSout, PHSin, PHSbps);
				//ONEUPS_ONECPT_ONECOST(Convert.ToInt32(CPTid), Charger_UPS.AvailId, P, 'D');
				Cpt_UPS = new Component_UPS(P);
				res = Cpt_UPS.Cal_VCS(0, VCS);
			}
			else MessageBox.Show("ERROR PHS / CPT..............");
			return res;
		}

		private void CHARGER_ONEUPS_ONECOST(string UPS, string PHSout, string OP_KVA, string ACoutputV, string DCBus, string PHSin, 
			string ACinputV, string PHSbps, string BpsinputV, string Cbatt, string PF, string tcharge, string FLT, string EQLZ, string vdcmin, 
			string vdcmax)
		{
			//fill CHARGERS_COST0

			string stSql = "select * from COMPNT_LIST_UPS where actif=1 and Compnt_Type <>'S'  order by Calc_rnk";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			CHRGR_UPS = new Charger_UPS(6805, UPS, PHSout, OP_KVA, ACoutputV, DCBus, PHSin, ACinputV, PHSbps, BpsinputV, Cbatt, PF, tcharge, 
				FLT, EQLZ, vdcmin, vdcmax);

			while (Oreadr.Read())
			{
				string P = find_CPT_PHS(Oreadr["PHS"].ToString(), PHSout, PHSin, PHSbps);
				ONEUPS_ONECPT_ONECOST(Convert.ToInt32(Oreadr["Component_ID"].ToString()), Charger_UPS.AvailId, P, 'D');
			}
			OConn.Close();
			//tBigTot.Text = CH_COST.ToString();

			fill_ALLValues();
		}

		void fill_ALLValues()
		{
			for (int i = 0; i < Charger_UPS.NB_FRML; i++)
			{
				if (Charger_UPS.arr_CAL_FRML[i] != "")
				{
					string st = "", val = "";
					int pos = Charger_UPS.arr_CAL_FRML[i].IndexOf("||");
					if (pos > 0)
					{
						st = Charger_UPS.arr_CAL_FRML[i].Substring(0, pos);
						val= Charger_UPS.arr_CAL_FRML[i].Substring(pos + 2, Charger_UPS.arr_CAL_FRML[i].Length - pos - 2);
					}
					ListViewItem lvI = in_frm_UPS_maker.lv_TV.Items.Add(st);
					lvI.SubItems.Add(val);
				}
				else i = Charger_UPS.NB_FRML;
			}
		}

		public void Cal_ALL_UPS_COST13_DRCT()
		{
			//fill CHARGERS_COST0

			//string stSql = "SELECT Avail_ID FROM TBLAVAIL13_UPS  WHERE (UPS='" + in_UPSmodel + "' AND PHSout='" + in_phs_out + "' AND OP_KVA='" + in_KVA + "' AND ACoutputV='" + in_ACout + "' AND DCBus='" + in_DCbus + "' AND PHSin='" + in_phs_in + "' AND ACinputV='" + in_Acinput + "' AND PHSbps='" + in_phs_bps + "' AND BpsinputV='" + in_bps_input + "')";

			string stSql = " SELECT  * FROM  TBLAVAIL13_UPS WHERE     (UPS = 'P850U') "; //ORDER BY charger, CAST(vdc AS float), CAST(idc AS float)";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			MainMDI.ExecSql("delete CHARGERS_UPS_COST13 ");
			while (Oreadr.Read())
			{
				CHARGER_UPS_COST(Oreadr["UPS"].ToString(), Oreadr["PHSout"].ToString(), Oreadr["OP_KVA"].ToString(), 
					Oreadr["ACoutputV"].ToString(), Oreadr["DCBus"].ToString(), Oreadr["PHSin"].ToString(), Oreadr["ACinputV"].ToString(), 
					Oreadr["PHSbps"].ToString(), Oreadr["BpsinputV"].ToString(), "0", "0.8", "8", "136.20", "139.80", "91.8", "144");
				string st = Oreadr["UPS"].ToString() + "-" + Oreadr["PHSout"].ToString() + "-" + Oreadr["OP_KVA"].ToString() + "-" + 
					Oreadr["ACoutputV"].ToString() + "    (Cost)";
			}
			OConn.Close();
		}

		public void Cal_ALL_UPS_COST13()
		{
			//fill CHARGERS_COST0

			//string stSql = "SELECT Avail_ID FROM TBLAVAIL13_UPS  WHERE (UPS='" + in_UPSmodel + "' AND PHSout='" + in_phs_out + "' AND OP_KVA='" + in_KVA + "' AND ACoutputV='" + in_ACout + "' AND DCBus='" + in_DCbus + "' AND PHSin='" + in_phs_in + "' AND ACinputV='" + in_Acinput + "' AND PHSbps='" + in_phs_bps + "' AND BpsinputV='" + in_bps_input + "')";

			string stSql = " SELECT  * FROM  TBLAVAIL13_UPS WHERE     (UPS = 'P850U') "; //ORDER BY charger, CAST(vdc AS float), CAST(idc AS float)";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			MainMDI.ExecSql("delete CHARGERS_UPS_COST13 ");
			while (Oreadr.Read())
			{
				CHARGER_UPS_COST(Oreadr["UPS"].ToString(), Oreadr["PHSout"].ToString(), Oreadr["OP_KVA"].ToString(), 
					Oreadr["ACoutputV"].ToString(), Oreadr["DCBus"].ToString(), Oreadr["PHSin"].ToString(), Oreadr["ACinputV"].ToString(), 
					Oreadr["PHSbps"].ToString(), Oreadr["BpsinputV"].ToString(), "0", "0.8", "8", "136.20", "139.80", "91.8", "144");
				string st = Oreadr["UPS"].ToString() + "-" + Oreadr["PHSout"].ToString() + "-" + Oreadr["OP_KVA"].ToString() + "-" + 
					Oreadr["ACoutputV"].ToString() + "    (Cost)";
				Thread.Sleep(100);
				in_frm_UPS_maker.Invoke(in_frm_UPS_maker.m_RepTrace, new object[] { st });
				if (in_Stop.WaitOne(0, true))
				{
					in_Stopped.Set();
					return;
				}
			}
			OConn.Close();
			string msg = "Cost Calculation completed ...";
			in_frm_UPS_maker.Invoke(in_frm_UPS_maker.m_endTHR, new Object[] { msg });

			//XL_ALL_CHRGR13();
		}

		//UPS etape#1
		private void CHARGER_UPS_COST(string UPS, string PHSout, string OP_KVA, string ACoutputV, string DCBus, string PHSin, string ACinputV, 
			string PHSbps, string BpsinputV, string Cbatt, string PF, string tcharge, string FLT, string EQLZ, string vdcmin, string vdcmax)
		{
			//fill CHARGERS_COST0

			string stSql = "select * from COMPNT_LIST_UPS where actif=1 and Compnt_Type <>'S'  order by Component_ID";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			CHRGR_UPS = new Charger_UPS(0, UPS, PHSout, OP_KVA, ACoutputV, DCBus, PHSin, ACinputV, PHSbps, BpsinputV, Cbatt, PF, tcharge, FLT, 
				EQLZ, vdcmin, vdcmax);

			while (Oreadr.Read())
			{
				string P = find_CPT_PHS(Oreadr["PHS"].ToString(), PHSout, PHSin, PHSbps);
				CPT_UPS_COST(Convert.ToInt32(Oreadr["Component_ID"].ToString()), Charger_UPS.AvailId, P, 'D');
			}
			OConn.Close();
			//tBigTot.Text = CH_COST.ToString();
		}

		string find_CPT_PHS(string Frml, string PHSout, string PHSin, string PHSbps)
		{
			switch (Frml)
			{
				case "U_PHS_out":
					return PHSout;
					break;
				case "U_PHS_in":
					return PHSin;
					break;
				case "U_PHSbps":
					return PHSbps;
					break;
				default:
					return "0";
					break;
			}
		}

		private void ONEUPS_ONECPT_ONECOST(long dccompnt, long availID, string P, char Cd)
		//private void ONEUPS_ONECPT_ONECOST(long dccompnt, char Cd)
		{
			//fill CHARGERS_COST0

			string stSql = "SELECT TBLAVAIL13_UPS.*, COMPNT_LIST_UPS.*, link_COMPNT_AVAIL_UPS.* " +
				" FROM (TBLAVAIL13_UPS INNER JOIN link_COMPNT_AVAIL_UPS ON TBLAVAIL13_UPS.AVAILID = link_COMPNT_AVAIL_UPS.Avail_ID)" +
				" INNER JOIN COMPNT_LIST_UPS ON link_COMPNT_AVAIL_UPS.Compnt_ID = COMPNT_LIST_UPS.Component_ID " +
				" Where (link_COMPNT_AVAIL_UPS.Avail_ID = " + availID + ") and (link_COMPNT_AVAIL_UPS.Compnt_ID = " + dccompnt + ")" +
				" ORDER BY TBLAVAIL13_UPS.Avail_ID, COMPNT_LIST_UPS.Component_ID";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();

			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();

			if (Oreadr.HasRows)
			{
				while (Oreadr.Read())
				{
					Cpt_UPS = new Component_UPS(P);

					Cpt_UPS.Cal_chrg_CostADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()), "C");
					if (Cpt_UPS.G_PRICE != Charger.VIDE)
					{
						if (Cpt_UPS.CAP1 == MainMDI.VIDE) Cpt_UPS.CAP1 = "0";
						if (Cpt_UPS.CAP2 == MainMDI.VIDE) Cpt_UPS.CAP2 = "0";
						if (Cpt_UPS.CAP3 == MainMDI.VIDE) Cpt_UPS.CAP3 = "0";
						if (Cpt_UPS.CAP4 == MainMDI.VIDE) Cpt_UPS.CAP3 = "0";

						ListViewItem lvI = in_frm_UPS_maker.lvQuotes.Items.Add(Oreadr["COMPONENT_REF"].ToString());
						lvI.SubItems.Add(Oreadr["CatName1"].ToString());
						lvI.SubItems.Add(Cpt_UPS.CAP1);
						lvI.SubItems.Add(Oreadr["CatName2"].ToString());
						lvI.SubItems.Add(Cpt_UPS.CAP2);
						lvI.SubItems.Add(Oreadr["CatName3"].ToString());
						lvI.SubItems.Add(Cpt_UPS.CAP3);
						lvI.SubItems.Add(Oreadr["CatName4"].ToString());
						lvI.SubItems.Add(Cpt_UPS.CAP4);
						lvI.SubItems.Add(Cpt_UPS.Real_QTY);
						lvI.SubItems.Add(""); //MainMDI.Curr_FRMT(Cpt_UPS.G_PRICE));
						//in_frm_UPS_maker.CH_COST += Tools.Conv_Dbl(Cpt_UPS.G_PRICE);
						//else
						//{
							//string c1 = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt_UPS.CAP1;
							//string c2 = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt_UPS.CAP2;
							//string c3 = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt_UPS.CAP3;
							//string c4 = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt_UPS.CAP4;
							//stSql = "INSERT INTO CHARGERS_UPS_COST13 ([Avail_ID],[Compnt_ID],[Cap1],[Cap2], " +
								//" [Cap3],[Cap4],[Real_QTY],[COST],[cost_type]) VALUES ('" +
								//Oreadr["Avail_id"].ToString() + "', '" +
								//Oreadr["Component_ID"].ToString() + "', '" +
								//c1 + "', '" + c2 + "', '" + c3 + "', '" + c4 + "', '" +
								//Cpt_UPS.Real_QTY + "', '" + Cpt_UPS.G_PRICE + "', '" +
								//Oreadr["Compnt_Type"].ToString() + "')";
							//MainMDI.ExecSql(stSql);
						//}
					}
				}
			}
			else
			{
				////MessageBox.Show("No Component is Available....(Availability)...cpt=" + dccompnt);
				//Cpt_UPS.G_Desc = Charger.VIDE;
				//Cpt_UPS.G_PRICE = Charger.VIDE;
			}
			OConn.Close();
		}

		private void CPT_UPS_COST(long dccompnt, long availID, string P, char Cd)
		{
			//fill CHARGERS_COST0

			string stSql = "SELECT TBLAVAIL13_UPS.*, COMPNT_LIST_UPS.*, link_COMPNT_AVAIL_UPS.* " +
				" FROM (TBLAVAIL13_UPS INNER JOIN link_COMPNT_AVAIL_UPS ON TBLAVAIL13_UPS.AVAILID = link_COMPNT_AVAIL_UPS.Avail_ID)" +
				" INNER JOIN COMPNT_LIST_UPS ON link_COMPNT_AVAIL_UPS.Compnt_ID = COMPNT_LIST_UPS.Component_ID " +
				" Where (link_COMPNT_AVAIL_UPS.Avail_ID = " + availID + ") and (link_COMPNT_AVAIL_UPS.Compnt_ID = " + dccompnt + ")" +
				" ORDER BY TBLAVAIL13_UPS.Avail_ID, COMPNT_LIST_UPS.Component_ID";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			
			if (Oreadr.HasRows)
			{
				while (Oreadr.Read())
				{
					Cpt_UPS = new Component_UPS(P);

					Cpt_UPS.Cal_chrg_CostADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()), "C");
					if (Cpt_UPS.G_PRICE != Charger.VIDE)
					{
						if (Cpt_UPS.CAP1 == MainMDI.VIDE) Cpt_UPS.CAP1 = "0";
						if (Cpt_UPS.CAP2 == MainMDI.VIDE) Cpt_UPS.CAP2 = "0";
						if (Cpt_UPS.CAP3 == MainMDI.VIDE) Cpt_UPS.CAP3 = "0";
						if (Cpt_UPS.CAP4 == MainMDI.VIDE) Cpt_UPS.CAP3 = "0";

						if (Cd == 'D')
						{
							ListViewItem lvI = in_frm_UPS_maker.lvQuotes.Items.Add(Oreadr["COMPONENT_REF"].ToString());
							lvI.SubItems.Add(Oreadr["CatName1"].ToString());
							lvI.SubItems.Add(Cpt_UPS.CAP1);
							lvI.SubItems.Add(Oreadr["CatName2"].ToString());
							lvI.SubItems.Add(Cpt_UPS.CAP2);
							lvI.SubItems.Add(Oreadr["CatName3"].ToString());
							lvI.SubItems.Add(Cpt_UPS.CAP3);
							lvI.SubItems.Add(Oreadr["CatName4"].ToString());
							lvI.SubItems.Add(Cpt_UPS.CAP4);
							lvI.SubItems.Add(Cpt_UPS.Real_QTY);
							lvI.SubItems.Add(MainMDI.Curr_FRMT(Cpt_UPS.G_PRICE));
							in_frm_UPS_maker.CH_COST += Tools.Conv_Dbl(Cpt_UPS.G_PRICE);
						}
						else 
						{
							string c1 = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt_UPS.CAP1;
							string c2 = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt_UPS.CAP2;
							string c3 = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt_UPS.CAP3;
							string c4 = (Oreadr["Compnt_Type"].ToString() == "%") ? "0" : Cpt_UPS.CAP4;
							stSql = "INSERT INTO CHARGERS_UPS_COST13 ([Avail_ID],[Compnt_ID],[Cap1],[Cap2], " +
								" [Cap3],[Cap4],[Real_QTY],[COST],[cost_type]) VALUES ('" +
								Oreadr["Avail_id"].ToString() + "', '" +
								Oreadr["Component_ID"].ToString() + "', '" +
								c1 + "', '" + c2 + "', '" + c3 + "', '" + c4 + "', '" +
								Cpt_UPS.Real_QTY + "', '" + Cpt_UPS.G_PRICE + "', '" +
								Oreadr["Compnt_Type"].ToString() + "')";
							MainMDI.ExecSql(stSql);
						}
					}
				}
			}
			else
			{
				//MessageBox.Show("No Component is Available....(Availability)...cpt=" + dccompnt);
				Cpt_UPS.G_Desc = Charger.VIDE;
				Cpt_UPS.G_PRICE = Charger.VIDE;
			}
			OConn.Close();
		}

		//private void writeTBXL()
		private void writeTBXL(string CAP_REF, string p, string val, char cRec)
		{
			string stSql = "", dval = "";
			double prct = 0;
			string REF_CHRG = CAP_REF;
			string st_Flds = "INSERT INTO SIM_TBLTOXL0" + p + "([COMPONENT],[REF_CHRG],[cRec]";
			string st_val = ")	VALUES ('" + CAP_REF + "', '" + CAP_REF + "', '" + cRec;
			string st_last = "')";
			//long XL_Fldcount = MainMDI.Find_Flds_Count("select * from TBLTOXL0" + p);
			for (int i = 1; i <= XL_Fldcount - 4; i++)
			{
				st_Flds += ", [" + arr_IDC[i] + "] ";
				st_val += "', ' ";
			}
			stSql = st_Flds + st_val + st_last;
			MainMDI.ExecSql(stSql);
		}

		private void writeTBXL(string CAP_REF, string[] arr_val, string opera, string p, string c, string v, ref string[] arr_TOT_GEN, 
			string cRec)
		{
			string stSql = "", dval = "";
			double prct = 0;
			string REF_CHRG = c + "-" + v; //(cRec == "C" || cRec == "V") ? c + "-" + v : CAP_REF + "-" + v; //REF_CHRG
			string st_Flds = "INSERT INTO SIM_TBLTOXL0" + p + "([COMPONENT],[REF_CHRG],[cRec]";
			string st_val =") VALUES ('" + CAP_REF + "', '" + REF_CHRG + "', '" + cRec;
			string st_last = "')";
			//long XL_Fldcount = MainMDI.Find_Flds_Count("select * from SIM_TBLTOXL0" + p);
			for (int i = 1; i <= XL_Fldcount - 4; i++)
			{
				if (opera[0] == '%')
				{
					if (arr_val[i] != "" && arr_val[i] != MainMDI.VIDE)
					{
						//' prct = SeekPrct(CAP_REF, v, rstTBLXL(i).Name)
						string rstPrctV = MainMDI.Find_One_Field("SELECT CHARGERS_COST0" + p + ".COST, CHARGERS_COST0" + p + ".cost_type " +
							" FROM (CHARGERS_COST0" + p + " INNER JOIN TBLAVAIL" + p + " ON CHARGERS_COST0" + p + ".Avail_ID = TBLAVAIL" + p + ".Avail_ID)" +
							" INNER JOIN COMPNT_LIST ON CHARGERS_COST0" + p + ".Compnt_ID = COMPNT_LIST.Component_ID " +
							" WHERE (((COMPNT_LIST.COMPONENT_REF)='" + CAP_REF + "') AND ((TBLAVAIL" + p + ".charger)='" + c + "')" +
							" AND (vdc='" + v + "') AND ((TBLAVAIL" + p + ".idc)='" + arr_IDC[i] + "')" +
							" AND ((CHARGERS_COST0" + p + ".cost_type)='%') AND ((COMPNT_LIST.nbc3Cat)='B')) " +
							" ORDER BY COMPNT_LIST.COMPONENT_REF ");
						prct = 0;
						if (arr_val[i] == null) arr_val[i]="0";
						if (arr_TOT_GEN[i] == "0") arr_TOT_GEN[i] = arr_val[i];
						prct = Math.Round(Tools.Conv_Dbl(arr_val[i]) * Tools.Conv_Dbl(rstPrctV) / 100, 0);
						arr_TOT_GEN[i] = Convert.ToString(Math.Round(Tools.Conv_Dbl(arr_TOT_GEN[i]) + prct, 0));
						dval = prct.ToString();
					}
					else dval = MainMDI.VIDE;
				}
				else 
				{
					if (opera[0] == '1') dval = arr_IDC[i];
					else dval = arr_val[i];
				}
				st_Flds += ", [" + arr_IDC[i] + "] ";
				st_val += "', '" + dval;
			}
			stSql = st_Flds + st_val + st_last;
			MainMDI.ExecSql(stSql);
		}

		public string seekCF(string Coef)
		{
			string seekCF_Res = "0";
			string stSql = "SELECT TABLES_CONTENT.COL1, TABLES_CONTENT.VALUE1" +
				" FROM TABLES_LIST INNER JOIN TABLES_CONTENT ON TABLES_LIST.TABLE_ID = TABLES_CONTENT.TABLE_ID " +
				" WHERE (((TABLES_CONTENT.COL1)='" + Coef + "') AND ((TABLES_LIST.TABLE_NAME)='COEFICIENTS'))";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			bool fin = false;
			while (Oreadr.Read() && !fin)
			{
				seekCF_Res = Oreadr[1].ToString();
				fin = true;
			}
			OConn.Close();
			return seekCF_Res;
		}

		private bool deco_var_price(ref string var, ref string VarValue, string p, string vdc, string idc, string Base_Charger)
		{
			int ipos = 0, i = 0;
			bool found = false;
			string st = "", MF = "", prct = "";
			string stSql = "";

			bool deco_V = false;
			switch (var[0])
			{
				case 'F':
					VarValue = seekCF(var.Substring(2, var.Length - 2));
					deco_V = true;
					break;
				case 'V':
					VarValue = var.Substring(2, var.Length - 2);
					deco_V = true;
					break;
				case 'P':
					if (var == G_Base_CHRG)
					{
						VarValue = G_BASE_TOT;
						deco_V = true;
						if (VarValue == "0") VarValue = MainMDI.VIDE;
					}
					else
					{
						//var = seek_FRML_PRICE(p, var);
						var = MainMDI.Find_One_Field(" Select CONTENT from COMPUTE_VCS where VCS_TYPE='P' and VCS_NAME='" + var + 
							"' and (PHS='2' OR PHS='" + p + "')");
						VarValue = "*******";
						//deco_V = (var!=MainMDI.VIDE);
					}
					break;
				case 'M':
					//MessageBox.Show("ERROR MF...");
					MF = var.Substring(2, var.Length - 2);
					stSql = "SELECT COMPNT_LIST.Value_Type" +
						" FROM (CHARGERS_COST0" + p + " INNER JOIN TBLAVAIL" + p + " ON CHARGERS_COST0" + p + ".Avail_ID = TBLAVAIL" + p + ".Avail_ID)" +
						" INNER JOIN COMPNT_LIST ON CHARGERS_COST0" + p + ".Compnt_ID = COMPNT_LIST.Component_ID " +
						" WHERE (((COMPNT_LIST.COMPONENT_REF)='" + MF + "') AND ((TBLAVAIL" + p + ".charger)='" + Base_Charger + "')" +
						" AND ([vdc]='" + vdc + "') AND ((TBLAVAIL" + p + ".idc)='" + idc + "') AND ((CHARGERS_COST0" + p + ".cost_type)='%')" +
						" AND ((COMPNT_LIST.nbc3Cat)='A')) " +
						" ORDER BY COMPNT_LIST.COMPONENT_REF ";
					VarValue = MainMDI.Find_One_Field(stSql);
					VarValue = (VarValue == MainMDI.VIDE) ? "1" : VarValue;
					deco_V = true;
					break;
				case 'R':
					//VarValue = seek_CPT_price(p, vdc, idc, CLng(Mid(var, 4, Len(var) - 3)))
					stSql = (" SELECT CHARGERS_COST0" + p + ".COST, CHARGERS_COST0" + p + ".cost_type " +
						" FROM CHARGERS_COST0" + p + " INNER JOIN TBLAVAIL" + p + " ON CHARGERS_COST0" + p + ".Avail_ID = TBLAVAIL" + p + ".Avail_ID " +
						" WHERE (((CHARGERS_COST0" + p + ".Compnt_ID)=" + var.Substring(3, var.Length - 3) + ") AND ((TBLAVAIL" + p + ".idc)='" + idc + "') AND ((TBLAVAIL" + p + ".vdc)='" + vdc + "'))");
					VarValue = MainMDI.Find_One_Field(stSql);
					deco_V = (VarValue != MainMDI.VIDE);
					break;
				default:
					MessageBox.Show("DECO VAR is Invalid...=" + var);
					break;
			}
			return deco_V;
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
				case "#": 
					calul_Amnt_Res = MainMDI.Ceil(amnt1, amnt2).ToString();
					break;
				default:
					MessageBox.Show("Operator is Invalid.....=" + oper);
					break;
			} 
			return calul_Amnt_Res;
		}
																		
		private string Deco_Frml_Price(string p, string frml, string vdc, string idc, string Base_Charger)
		{
			int i = 0;
			int ipos = 0;
			int OPos = 0;
			bool fin = false;
			string amnt1 = "", st = frml, VarValue = "";
			string Total = "", var ="";
			string oper = "";
			string Deco = "0", period = "", chrg_VDC = "";
			switch (frml[0])
			{
				case 'P':
					while (st.Substring(OPos, 1) != ";")
					{ 
						ipos = st.IndexOf(" ", OPos);
						var = st.Substring(OPos, ipos - OPos);
						if (var != " ")
						{
							if (var.Length > 1)
							{
								if (!deco_var_price(ref var, ref VarValue, p, vdc, idc, Base_Charger)) 
									VarValue = Deco_Frml_Price(p, var, vdc, idc, Base_Charger);
								if (VarValue != MainMDI.VIDE && VarValue != "")
										if (Total == "") Total = VarValue;
										else amnt1 = VarValue;
									else
									{
										Deco = MainMDI.VIDE;
										ipos = frml.IndexOf(";");
										Total = "";
									}
							}
							else oper = var;
							if (oper != "" && amnt1 != "" && Total != "")
							{
								Total = calul_Amnt(Total, oper, amnt1);
								amnt1 = "";
							}
						}
						OPos = (ipos + 1 == st.Length) ? ipos: ipos + 1;
						//OPos = ipos;
					}
					if (Deco != MainMDI.VIDE && Deco != "") Deco = Convert.ToString(Math.Round(Tools.Conv_Dbl(Total), 0));
					break;
				case 'O':
					Deco = MainMDI.VIDE;
					if (frml.Length > 10)
					{
						period = frml.Substring(3, 4);
						chrg_VDC = frml.Substring(8, frml.Length - 9) + "-" + vdc;
						Deco = find_OLD_Price(p, period, chrg_VDC, idc);
					}
					break;
			}
			return Deco;
		}

		private string find_OLD_Price(string p, string period, string chrg_VDC, string idc)
		{
			int ic = 0;
			string found = "";
			string stSql = "SELECT ARCH_COST13.* From ARCH_COST13 WHERE (((ARCH_COST13.phs)='" + p + "') AND ((ARCH_COST13.ChargerVDC)='" + 
				chrg_VDC + "') AND ((ARCH_COST13.period)='" + period + "'))";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			int XL_ARCH_Fldcount = MainMDI.Find_Flds_Count("select * from ARCH_COST13");
			while (Oreadr.Read())
			{
				for (ic = 3; ic < XL_ARCH_Fldcount; ic++)
                {
					if (arr_IDC[ic] == idc)
					{
						found = Oreadr[ic].ToString();
						ic = XL_ARCH_Fldcount + 1;
					}
				}
			}
			OConn.Close();
			return found;
		}

		private void Other_CHARGERS(string p, string Base_Charger, string vdc, string[] arr_Tot, string ch, string v)
		{
			int pos = -1, ic = 0, pbadd = 0;
			string[] arr_TOT_others = new string[50];
			string stout = "", stt = "", period = "", chrg_VDC = "";
			G_Base_CHRG = "P_" + Base_Charger;
			string stSql = "select * from COMPUTE_VCS where (VCS_TYPE='P') and (PHS='2' OR PHS='" + p + "') order by VCS_ID";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();

			//MainMDI.ExecSql("delete CHARGERS_COST0" + PHS);
			
			while (Oreadr.Read())
			{
				ic = 0;
				for (ic = 0; ic < 50; ic++) arr_TOT_others[ic] = "";
				for (ic = 1; ic <= XL_Fldcount - 4; ic++)
				{
					G_BASE_TOT = arr_Tot[ic];
					switch (Oreadr["VCS_TYPE"].ToString())
					{
						case "P":
							arr_TOT_others[ic] = Deco_Frml_Price(p, Oreadr["Content"].ToString(), vdc, arr_IDC[ic], Base_Charger);
							break;
						case "O":
							if (Oreadr["Content"].ToString().Length > 1) period = Oreadr["Content"].ToString().Substring(2, 4);
							else 
							{
								MessageBox.Show(" ERROR OLD Price Period (MMYY)");
								period = "9999";
							}
							//If IsNumeric(period)
							pos = Oreadr["VCS_name"].ToString().IndexOf("-");
							chrg_VDC = Oreadr["VCS_name"].ToString().Substring(3, pos - 3) + "-" + vdc;
							arr_TOT_others[ic] = find_OLD_Price(p, period, chrg_VDC, arr_IDC[ic]);
							break;
						default:
							MessageBox.Show("Error In Pricing Formulas............." + Oreadr["Content"].ToString());
							break;
							//'arr_TOT_others(ic) = find_OLDCOST(p, Mid(adoSeek.Recordset!Content, 1, Len(adoSeek.Recordset!Content) - 2), vdc, rstTBLXL(ic).Name)
					}
					if (arr_TOT_others[ic] != "" && arr_TOT_others[ic] != "")
						arr_TOT_others[ic] = Convert.ToString(Math.Round(Tools.Conv_Dbl(arr_TOT_others[ic]), MainMDI.NB_DEC_AFF));
					//' stout = stout & vbCrLf & "vdc= " & vdc & "  IDC=" & rstTBLXL(ic).Name & " = " & arr_TOT_others(ic)
				}
				stt = Oreadr["VCS_name"].ToString().Substring(2, Oreadr["VCS_name"].ToString().Length - 2);
				writeTBXL(stt, arr_TOT_others, "*", p, ch, vdc, ref arr_TOT_others, "T");
			}
			OConn.Close();
		}

		private void write_PRCT(string CHRG, string[] arr_Tot, string p, string VDC, string[] arr_TOT_GEN)
		{
			string stSql = " SELECT COMPNT_LIST.COMPONENT_REF" +
				" FROM (CHARGERS_COST0" + p + " INNER JOIN TBLAVAIL" + p + " ON CHARGERS_COST0" + p + ".Avail_ID = TBLAVAIL" + p + ".Avail_ID)" +
				" INNER JOIN COMPNT_LIST ON CHARGERS_COST0" + p + ".Compnt_ID = COMPNT_LIST.Component_ID " + 
				" WHERE (((TBLAVAIL" + p + ".charger)='" + CHRG + "') AND ((COMPNT_LIST.nbc3Cat)='B') AND ([vdc]='" + VDC + "') AND ((CHARGERS_COST0" + p + ".cost_type)='%')) " +
				" GROUP BY COMPNT_LIST.COMPONENT_REF ORDER BY COMPNT_LIST.COMPONENT_REF ";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
				writeTBXL(Oreadr[0].ToString(), arr_Tot, "%", p, CHRG, VDC, ref arr_TOT_GEN, "C");
			OConn.Close();
		}
	
		private void XL_ALL()
		{
			//MainMDI.ExecSql("delete SIM_TBLTOXL13_UPS");
			//XL_Fldcount = MainMDI.Find_Flds_Count("select * from SIM_TBLTOXL13_UPS");
			//fill_VDC_IDC('V');
			//fill_VDC_IDC('I');
			//string idc = "", st = "", capname = "", catName = "", OLDcapname = "", OLDcatName = "", prct = "", oldref = "", oldType = "", prctName = "", newREF = "", stout = "";
			//int ic = 5, nbvdc = 0, ipA = 0, ipB = 0;
			//bool rec_Empty = true, debutVDC = false;
			//string[] arr_cost = new string[50];
			//string[] arr_Tot = new string[50];
			//string[] arr_TOT_GEN = new string[50];
			//string[] arr_cap = new string[50];
			//string[,] arr_PrctA = new string[50, 2];
			//string[,] arr_PrctB = new string[50, 2];

			//string CHRG = MainMDI.Find_One_Field("SELECT  TBLAVAIL13_UPS.UPS FROM link_COMPNT_AVAIL_UPS INNER JOIN TBLAVAIL13_UPS ON link_COMPNT_AVAIL_UPS.Avail_ID = TBLAVAIL13_UPS.Avail_ID " +
				//"  GROUP BY TBLAVAIL13_UPS.UPS ORDER BY TBLAVAIL13_UPS.UPS ");

			//string stSql = "SELECT     CAST(TABLES_CONTENT.COL1 AS Int) AS VDC " +
				//" FROM         TABLES_CONTENT INNER JOIN TABLES_LIST ON TABLES_CONTENT.TABLE_ID = TABLES_LIST.TABLE_ID " +
				//" WHERE     (TABLES_LIST.TABLE_NAME = 'VDCMax') " +
				//" ORDER BY CAST(TABLES_CONTENT.COL1 AS Int) ";

			//SqlConnection rstVDC_OConn = new SqlConnection(MainMDI._connectionString);
			//rstVDC_OConn.Open();
			//SqlCommand rstVDC_Ocmd = rstVDC_OConn.CreateCommand();
			//rstVDC_Ocmd.CommandText = stSql;
			//SqlDataReader rstVDC_Oreadr = rstVDC_Ocmd.ExecuteReader();
			//while (rstVDC_Oreadr.Read())
			//{
				//for (int i = 0; i < 50; i++) { arr_TOT_GEN[i] = "0"; arr_Tot[i] = "0"; arr_cost[i] = "0"; }
				////CPT_COST(Convert.ToInt32(Oreadr["Component_ID"].ToString()), Charger.AvailId, PHS, 'F');
				//stSql = "SELECT TBLAVAIL" + P + ".charger, CAST(TBLAVAIL" + P + ".vdc AS Int) AS v, COMPNT_LIST.COMPONENT_REF, CAST(TBLAVAIL" + P + ".idc AS Int) AS I, CHARGERS_COST0" + P + ".COST, " +
					//"        CHARGERS_COST0" + P + ".Cap1, CHARGERS_COST0" + P + ".Cap2, CHARGERS_COST0" + P + ".Cap3, CHARGERS_COST0" + P + ".Real_QTY, CHARGERS_COST0" + P + ".cost_type, " +
					//"        COMPNT_LIST.CatName" + P + ", COMPNT_LIST.CatName2, COMPNT_LIST.CatName3, COMPUTE_MODELS.PrintCatn " +
					//"  FROM  CHARGERS_COST0" + P + " INNER JOIN  TBLAVAIL" + P + " ON CHARGERS_COST0" + P + ".Avail_ID = TBLAVAIL" + P + ".Avail_ID INNER JOIN " +
					//"        COMPNT_LIST ON CHARGERS_COST0" + P + ".Compnt_ID = COMPNT_LIST.Component_ID INNER JOIN COMPUTE_MODELS ON CAST(COMPNT_LIST.Value_Type AS float) = COMPUTE_MODELS.CM_ID " +
					//"  WHERE (TBLAVAIL" + P + ".charger = '" + CHRG + "') AND (CHARGERS_COST0" + P + ".cost_type = 'C' OR CHARGERS_COST0" + P + ".cost_type = 'E') AND (CAST(TBLAVAIL" + P + ".vdc AS Int) =" + rstVDC_Oreadr[0] + ") " +
					//"  ORDER BY TBLAVAIL" + P + ".charger, CAST(TBLAVAIL" + P + ".vdc AS Int), COMPNT_LIST.COMPONENT_REF, CAST(TBLAVAIL" + P + ".idc AS Int) ";
				//SqlConnection rstCost_OConn = new SqlConnection(MainMDI._connectionString);
				//rstCost_OConn.Open();
				//SqlCommand rstCost_Ocmd = rstCost_OConn.CreateCommand();
				//rstCost_Ocmd.CommandText = stSql;
				//SqlDataReader rstCost_Oreadr = rstCost_Ocmd.ExecuteReader();
				//oldref = "";
				//oldType = "";
				//debutVDC = true;
				//rec_Empty = true;
				//catName = ""; capname = "";
				//OLDcatName = ""; OLDcapname = "";
				//while (rstCost_Oreadr.Read())
				//{
					//if (rstCost_Oreadr["cost_type"].ToString() != "%")
					//{
						//newREF = rstCost_Oreadr["COMPONENT_REF"].ToString();
						//if (oldref != "" && oldref != newREF && oldType != "%" && oldType != "") //|| debutVDC)
						//{
							//if (debutVDC) writeTBXL(CHRG + "-" + P + "-" + rstVDC_Oreadr[0].ToString(), arr_Tot, "1", P, CHRG, rstVDC_Oreadr[0].ToString(), ref arr_TOT_GEN, "L");
							//writeTBXL(OLDcatName, arr_cost, "*", P, CHRG, rstVDC_Oreadr[0].ToString(), ref arr_TOT_GEN, "C");
							////If chkCV Then Call writeTBXL(capname, arr_cap, "*", p, rstCHRG(0), rstVDC(0), arr_TOT_GEN, "C")
							//if (OLDcapname != MainMDI.VIDE) writeTBXL(OLDcapname, arr_cap, "*", P, CHRG, rstVDC_Oreadr[0].ToString(), ref arr_TOT_GEN, "V"); //print catname and value
							//debutVDC = false;
							//for (ic = 0; ic < 50; ic++) {arr_cost[ic] = "0"; arr_cap[ic] = "0"; }
						//}
						//catName = rstCost_Oreadr["COMPONENT_REF"].ToString();
						//capname = rstCost_Oreadr[9 + Convert.ToInt32(rstCost_Oreadr["printCatn"].ToString())].ToString();
						//for (ic = 1; ic <= XL_Fldcount - 4; ic++) //last change
						//{
							//if (rstCost_Oreadr["I"].ToString() == arr_IDC[ic])
							//{
								//arr_cost[ic] = rstCost_Oreadr["cost"].ToString();
								//if (rstCost_Oreadr["cost"].ToString() != MainMDI.VIDE && arr_Tot[ic] != "")
								//{
									//arr_Tot[ic] = Convert.ToString(Math.Round(Tools.Conv_Dbl(arr_Tot[ic]) + Tools.Conv_Dbl(rstCost_Oreadr["cost"].ToString()), MainMDI.NB_DEC_AFF));
									////if (ic == 0) stout += CHRG + "-" + P + "-" + rstVDC_Oreadr[0].ToString() + "  " + rstCost_Oreadr["COMPONENT_REF"].ToString() + "  " + arr_Tot[ic] + "  c=" + rstCost_Oreadr["cost"].ToString() + "\n";
								//}
								//arr_cap[ic] = rstCost_Oreadr[4 + Convert.ToInt32(rstCost_Oreadr["printCatn"].ToString())].ToString();
								//ic = (int) XL_Fldcount;
								//rec_Empty = false;
							//}
						//}
					//}
					//oldref = rstCost_Oreadr["COMPONENT_REF"].ToString();
					//oldType = rstCost_Oreadr["cost_type"].ToString();
					//OLDcapname = capname;
					//OLDcatName = catName;
					//st = CHRG + "-" + P + "-" + rstVDC_Oreadr[0].ToString() + "    (Xl)"; //+ "  " + rstCost_Oreadr["COMPONENT_REF"].ToString();
					////if (rstCost_Oreadr["COMPONENT_REF"].ToString() == "W4") MessageBox.Show("Hiiiiiiiiiiiiiii");
				//}	
				//if (!rec_Empty) write_PRCT(CHRG, arr_Tot, P, rstVDC_Oreadr[0].ToString(), arr_TOT_GEN);
				//writeTBXL(CHRG, arr_Tot, "*", P, CHRG, rstVDC_Oreadr[0].ToString(), ref arr_TOT_GEN, "T");
				//Other_CHARGERS(P, CHRG, rstVDC_Oreadr[0].ToString(), arr_TOT_GEN, CHRG, rstVDC_Oreadr[0].ToString());
				//writeTBXL(" ", P, " ", 'L');
				//rec_Empty = true;
				
				//Thread.Sleep(100);
				//in_frm_UPS_maker.Invoke(in_frm_UPS_maker.m_RepTrace, new object[] { st });
				//if (in_Stop.WaitOne(0, true))
				//{
					//in_Stopped.Set();
					//return;
				//}
			//}
			//string msg = "Calculation completed...(CC/CX)";
			//in_frm_UPS_maker.Invoke(in_frm_UPS_maker.m_endTHR, new Object[] { msg });
		}

		private void XL_ALLBak(string P)
		{
			MainMDI.ExecSql("delete SIM_TBLTOXL0" + P);
			XL_Fldcount = MainMDI.Find_Flds_Count("select * from SIM_TBLTOXL0" + P);
			//fill_VDC_IDC('V');
			//fill_VDC_IDC('I');
			string idc = "", st = "", capname = "", catName = "", OLDcapname = "", OLDcatName = "", prct = "", oldref = "", oldType = "", 
				prctName = "", newREF = "", stout = "";
			int ic = 5, nbvdc = 0, ipA = 0, ipB = 0;
			bool rec_Empty = true,debutVDC=false;
			string[] arr_cost = new string[50];
			string[] arr_Tot = new string[50];
			string[] arr_TOT_GEN = new string[50];
			string[] arr_cap = new string[50];
			string[,] arr_PrctA = new string[50, 2];
			string[,] arr_PrctB = new string[50, 2];

			string CHRG = MainMDI.Find_One_Field("SELECT  TBLAVAIL" + P + ".charger" +
				" FROM link_COMPNT_AVAIL INNER JOIN TBLAVAIL" + P + " ON link_COMPNT_AVAIL.Avail_ID = TBLAVAIL" + P + ".Avail_ID " +
				" GROUP BY TBLAVAIL" + P + ".charger ORDER BY TBLAVAIL" + P + ".charger ");

			string stSql = "SELECT     CAST(TABLES_CONTENT.COL1 AS Int) AS VDC " +
				" FROM         TABLES_CONTENT INNER JOIN TABLES_LIST ON TABLES_CONTENT.TABLE_ID = TABLES_LIST.TABLE_ID " +
				" WHERE     (TABLES_LIST.TABLE_NAME = 'VDCMax') " +
				" ORDER BY CAST(TABLES_CONTENT.COL1 AS Int) ";

			SqlConnection rstVDC_OConn = new SqlConnection(MainMDI.M_stCon);
			rstVDC_OConn.Open();
			SqlCommand rstVDC_Ocmd = rstVDC_OConn.CreateCommand();
			rstVDC_Ocmd.CommandText = stSql;
			SqlDataReader rstVDC_Oreadr = rstVDC_Ocmd.ExecuteReader();
			while (rstVDC_Oreadr.Read())
			{
				for (int i = 0; i < 50; i++) 
				{ 
					arr_TOT_GEN[i] = "0"; 
					arr_Tot[i] = "0"; 
					arr_cost[i] = "0"; 
				}
				//CPT_COST(Convert.ToInt32(Oreadr["Component_ID"].ToString()), Charger.AvailId, PHS, 'F');
				stSql = "SELECT TBLAVAIL" + P + ".charger, CAST(TBLAVAIL" + P + ".vdc AS Int) AS v, COMPNT_LIST.COMPONENT_REF, CAST(TBLAVAIL" + P + ".idc AS Int) AS I, CHARGERS_COST0" + P + ".COST, " +
					"        CHARGERS_COST0" + P + ".Cap1, CHARGERS_COST0" + P + ".Cap2, CHARGERS_COST0" + P + ".Cap3, CHARGERS_COST0" + P + ".Real_QTY, CHARGERS_COST0" + P + ".cost_type, " +
					"        COMPNT_LIST.CatName" + P + ", COMPNT_LIST.CatName2, COMPNT_LIST.CatName3, COMPUTE_MODELS.PrintCatn " +
					"  FROM  CHARGERS_COST0" + P + " INNER JOIN  TBLAVAIL" + P + " ON CHARGERS_COST0" + P + ".Avail_ID = TBLAVAIL" + P + ".Avail_ID INNER JOIN " +
					"        COMPNT_LIST ON CHARGERS_COST0" + P + ".Compnt_ID = COMPNT_LIST.Component_ID INNER JOIN COMPUTE_MODELS ON CAST(COMPNT_LIST.Value_Type AS Int) = COMPUTE_MODELS.CM_ID " +
					"  WHERE (TBLAVAIL" + P + ".charger = '" + CHRG + "') AND (CHARGERS_COST0" + P + ".cost_type = 'C' OR CHARGERS_COST0" + P + ".cost_type = 'E') AND (CAST(TBLAVAIL" + P + ".vdc AS Int) =" + rstVDC_Oreadr[0] + ") " +
					"  ORDER BY TBLAVAIL" + P + ".charger, CAST(TBLAVAIL" + P + ".vdc AS Int), COMPNT_LIST.COMPONENT_REF, CAST(TBLAVAIL" + P + ".idc AS Int) ";
				SqlConnection rstCost_OConn = new SqlConnection(MainMDI.M_stCon);
				rstCost_OConn.Open();
				SqlCommand rstCost_Ocmd = rstCost_OConn.CreateCommand();
				rstCost_Ocmd.CommandText = stSql;
				SqlDataReader rstCost_Oreadr = rstCost_Ocmd.ExecuteReader();
				oldref = "";
				oldType = "";
				debutVDC = true;
				rec_Empty = true;
				catName = ""; capname = "";
				OLDcatName = ""; OLDcapname = "";
				while (rstCost_Oreadr.Read())
				{
					if (rstCost_Oreadr["cost_type"].ToString() != "%")
					{
						catName = rstCost_Oreadr["COMPONENT_REF"].ToString();
						capname = rstCost_Oreadr[9 + Convert.ToInt32(rstCost_Oreadr["printCatn"].ToString())].ToString();
						for (ic = 1; ic <= XL_Fldcount - 4; ic++) //last change
						{
							if (rstCost_Oreadr["I"].ToString() == arr_IDC[ic])
							{
								arr_cost[ic] = rstCost_Oreadr["cost"].ToString();
								if (rstCost_Oreadr["cost"].ToString() != MainMDI.VIDE && arr_Tot[ic] != "")
								{
									arr_Tot[ic] = Convert.ToString(Math.Round(Tools.Conv_Dbl(arr_Tot[ic]) + 
										Tools.Conv_Dbl(rstCost_Oreadr["cost"].ToString()), MainMDI.NB_DEC_AFF));
									//if (ic == 0) stout += CHRG + "-" + P + "-" + rstVDC_Oreadr[0].ToString() + "  " + rstCost_Oreadr["COMPONENT_REF"].ToString() + "  " + arr_Tot[ic] + "  c=" + rstCost_Oreadr["cost"].ToString() + "\n";
								}
								arr_cap[ic] = rstCost_Oreadr[4 + Convert.ToInt32(rstCost_Oreadr["printCatn"].ToString())].ToString();
								ic = (int) XL_Fldcount;
								rec_Empty = false;
							}
						}
					}
					newREF = rstCost_Oreadr["COMPONENT_REF"].ToString();
					if (oldref != "" && oldref != newREF && oldType != "%" && oldType != "") //|| debutVDC)
					{
						if (debutVDC) writeTBXL(CHRG + "-" + P + "-" + rstVDC_Oreadr[0].ToString(), arr_Tot, "1", P, CHRG, 
							rstVDC_Oreadr[0].ToString(), ref arr_TOT_GEN, "L");
						writeTBXL(OLDcatName, arr_cost, "*", P, CHRG, rstVDC_Oreadr[0].ToString(), ref arr_TOT_GEN, "C");
						//If chkCV Then Call writeTBXL(capname, arr_cap, "*", p, rstCHRG(0), rstVDC(0), arr_TOT_GEN, "C")
						if (OLDcapname != MainMDI.VIDE) writeTBXL(OLDcapname, arr_cap, "*", P, CHRG, rstVDC_Oreadr[0].ToString(), 
							ref arr_TOT_GEN, "V"); //print catname and value
						debutVDC = false;
						for (ic = 0; ic < 50; ic++) 
						{ 
							arr_cost[ic] = "0"; 
							arr_cap[ic] = "0"; 
						}
					}
					oldref = rstCost_Oreadr["COMPONENT_REF"].ToString();
					oldType = rstCost_Oreadr["cost_type"].ToString();
					OLDcapname = capname;
					OLDcatName = catName;
					st = CHRG + "-" + P + "-" + rstVDC_Oreadr[0].ToString(); //+ "  " + rstCost_Oreadr["COMPONENT_REF"].ToString();
					//if (rstCost_Oreadr["COMPONENT_REF"].ToString() == "W4") MessageBox.Show("Hiiiiiiiiiiiiiii");
				}
				if (!rec_Empty) write_PRCT(CHRG, arr_Tot, P, rstVDC_Oreadr[0].ToString(), arr_TOT_GEN);
				writeTBXL(CHRG, arr_Tot, "*", P, CHRG, rstVDC_Oreadr[0].ToString(), ref arr_TOT_GEN, "T");
				Other_CHARGERS(P, CHRG, rstVDC_Oreadr[0].ToString(), arr_TOT_GEN, CHRG, rstVDC_Oreadr[0].ToString());
				writeTBXL(" ", P, " ", 'L');
				rec_Empty = true;
				
				Thread.Sleep(100);
				in_frm_UPS_maker.Invoke(in_frm_UPS_maker.m_RepTrace, new object[] { st });
				if (in_Stop.WaitOne(0, true))
				{
					in_Stopped.Set();
					return;
				}
			}
			rstVDC_OConn.Close();
			string msg = "Cost Calculation completed ...";
			in_frm_UPS_maker.Invoke(in_frm_UPS_maker.m_endTHR, new Object[] { msg });
		}
	}
}