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
	/// Summary description for Charger.
	/// </summary>
	public class Charger_UPS
	{
		public static readonly int NB_FRML = 200;

		public static readonly int NB_MODELS = 100;
		public static readonly int NB_FRML_Flds = 6;
		public static readonly int NB_MODELS_Flds = 12;
		public static readonly int IMAX_ARR_REALV = 80;

		public static readonly string VIDE = "n/a";
		public static readonly int NB_DEC_CAL = 10;
		public static readonly int NB_DEC_AFF = 2;
		private Lib1 Tools = new Lib1();

		public static long ISave = 0;
		public static string[,] arr_FRML = new string[NB_FRML, NB_FRML_Flds];
		public static string[] arr_CAL_FRML = new string[NB_FRML];
		public static string[,] arr_CModels = new string[NB_MODELS, NB_MODELS_Flds];
		public static string[,] arr_REALV = new string[IMAX_ARR_REALV, 8];
		//public static string MainMDI._connectionString;
		public static string In_VcsTblName = "COMPUTE_VCS_UPS";
		public static string Real_C;
		public static string C;
		public static string P_in, P_out, P_bps;

		public string in_UPSmodel, in_phs_out, in_KVA, in_ACout, in_DCbus, in_phs_in, in_Acinput, in_phs_bps, in_bps_input, in_Cbatt, in_PF, 
			in_tcharg, in_FLT, in_EQLZ, in_vdcmin, in_vdcmax;

		public static string KVA;
		public static string ACout;
		public static string DCinput;
		public static long AvailId;
		public static int lblIRealV;
		
		//public Component[] Cpt_List=new Component[100]; //= new Component(
		
		public Charger_UPS(long x_AvailID, string x_UPSmodel, string x_phs_out, string x_KVA, string x_ACout, string x_DCbus, string x_phs_in, 
			string x_Acinput, string x_phs_bps, string x_bps_input, string x_Cbatt, string x_PF, string x_tcharg, string x_FLT, string x_EQLZ, 
			string x_vdcmin, string x_vdcmax)
		{
			//
			//TODO: Add constructor logic here
			//
			Real_C = x_UPSmodel;
			C = x_UPSmodel.Substring(0, 5); //added bcz P4500 are same P4500TT, TT, F 

			in_UPSmodel = x_UPSmodel;
			in_phs_out = x_phs_out;
			in_KVA = x_KVA;
			in_ACout = x_ACout;
			in_DCbus = x_DCbus;
			in_phs_in = x_phs_in;
			in_Acinput = x_Acinput;
			in_phs_bps = x_phs_bps;
			in_bps_input = x_bps_input;
			in_Cbatt = x_Cbatt;
			in_PF = x_PF;
			in_tcharg = x_tcharg;
			in_FLT = x_FLT;
			in_EQLZ = x_EQLZ;
			in_vdcmin = x_vdcmin;
			in_vdcmax = x_vdcmax;

			//MainMDI._connectionString = MainMDI._connectionString;

			In_VcsTblName = "COMPUTE_VCS_UPS"; //+ ((x_FV == "F" && x_Chrgr == "P4500") ? "" : "_" + x_FV + "_" + x_Chrgr);
		 	Init_arr_RealV(In_VcsTblName);
			//AvailId = (x_AvailID != 0) ? x_AvailID : Find_AvailID();
			AvailId = x_AvailID;
			if (x_AvailID == 0) AvailId = Find_AvailID();
			Load_arr_FRML(In_VcsTblName);
			//Load_arr_CModel();
			init_arr_CAL_FRML();
	
			//Cpt_List[0] = new Component(In_VcsTblName, C, P, V, I, AvailId);
			//Component Cpt = new Component(In_VcsTblName, C, P, V, I, AvailId);
		}

		private long Find_AvailID()
		{
			string stSql = "SELECT AVAILID FROM TBLAVAIL13_UPS  WHERE (UPS='" + in_UPSmodel + "' AND PHSout='" + in_phs_out + 
				"' AND OP_KVA='" + in_KVA + "' AND ACoutputV='" + in_ACout + "' AND DCBus='" + in_DCbus + "' AND PHSin='" + in_phs_in + 
				"' AND ACinputV='" + in_Acinput + "' AND PHSbps='" + in_phs_bps + "' AND BpsinputV='" + in_bps_input + "')";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
				return Convert.ToInt32(Oreadr["AVAILID"].ToString());
			OConn.Close();
			//return 0;
			return -1;
		}

		private bool Load_arr_FRML(string VcsTblName)
		{
			init_arr_Frml();
			string stSql = "select * from " + VcsTblName + " order by VCS_ID";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			int i = 0;
			if (Oreadr.FieldCount != NB_FRML_Flds) MessageBox.Show("VCS Table is Empty or Fields# is Invalid....must be= " + 
				NB_FRML_Flds.ToString());
			while (Oreadr.Read())
			{
				for (int j = 0; j < Oreadr.FieldCount; j++) arr_FRML[i, j] = Oreadr[j].ToString();
				if (Oreadr[0].ToString() == "218") arr_FRML[i, 4] = (in_Cbatt != "0") ? "C_T1_capa ;" : "C_T1_15pct ;"; //+ dd.ToString();
				i++;
			}
			OConn.Close();
			return (arr_FRML[0, 0] != "");
		}

		private void Init_arr_RealV(string VcsTblName)
		{
			for (int i = 0; i < IMAX_ARR_REALV; i++)
				for (int j = 0; j < 8; j++) arr_REALV[i, j] = "";
			lblIRealV = 0;
		}

		private void init_arr_Frml()
		{
			for (int i = 0; i < NB_FRML; i++)
				for (int j = 0; j < NB_FRML_Flds; j++) arr_FRML[i, j] = "";
		}

		private void init_arr_Models()
		{
			for (int i = 0; i < NB_MODELS; i++)
				for (int j = 0; j < NB_MODELS_Flds; j++) arr_CModels[i, j] = "";
		}

		private bool Load_arr_CModel()
		{
			/*
			init_arr_Models();
			string stSql = "select * from COMPUTE_MODELS ";
			SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			int i = 0;
			if (Oreadr.FieldCount != NB_MODELS_Flds) MessageBox.Show("Models Table is Empty or Fields# is Invalid....must be= " + NB_MODELS_Flds.ToString());
			while (Oreadr.Read())
			{
				for (int j = 0; j < Oreadr.FieldCount; j++) arr_CModels[i, j] = Oreadr[j].ToString();
				i++;
			}
			OConn.Close();
			return (arr_CModels[0, 0] != "");
			*/
			return true;
		}

		private void init_arr_CAL_FRML()
		{
			//in_UPSmodel = x_UPSmodel;
			//in_phs_out = in_phs_out;
			//in_KVA = x_KVA;
			//in_ACout = x_ACout;
			//in_DCbus = x_DCbus;
			//in_phs_in = x_phs_in;
			//in_Acinput = x_Acinput;
			//in_phs_bps = x_phs_bps;
			//in_bps_input = x_bps_input;

			arr_CAL_FRML[0] = VIDE;
			arr_CAL_FRML[1] = "U_UPS||" + in_UPSmodel;
			arr_CAL_FRML[2] = "U_PHS_out||" + in_phs_out;
			arr_CAL_FRML[3] = "U_OPKVA||" + in_KVA;
			arr_CAL_FRML[4] = "U_ACout||" + in_ACout;
			arr_CAL_FRML[5] = "U_DCbus||" + in_DCbus;
			arr_CAL_FRML[6] = "U_PHS_in||" + in_phs_in;

			arr_CAL_FRML[7] = "U_ACinput||" + in_Acinput;
			arr_CAL_FRML[8] = "U_PHSbps||" + in_phs_bps;
			arr_CAL_FRML[9] = "U_BPSinput||" + in_bps_input;

			arr_CAL_FRML[10] = "U_Cbat||" + in_Cbatt;
			arr_CAL_FRML[11] = "U_PF||" + in_PF;
			arr_CAL_FRML[12] = "U_Tcharg||" + in_tcharg;
			arr_CAL_FRML[13] = "U_RectEff||" + "0.9";
			arr_CAL_FRML[14] = "U_BattEff||" + "1.1";
			arr_CAL_FRML[15] = "U_Fsecurity||" + "1.3";
			arr_CAL_FRML[16] = (in_phs_out == "3") ? "U_Pi_1_3||1.35047" : "U_Pi_1_3||0.900316"; //+ "‭0.900316‬";
			arr_CAL_FRML[17] = "U_CB1_KA||" + "0";
			arr_CAL_FRML[18] = "U_Vfloat||" + in_FLT;
			arr_CAL_FRML[19] = "U_Veqlz||" + in_EQLZ;
			arr_CAL_FRML[20] = "U_VDCmin||" + in_vdcmin;
			arr_CAL_FRML[21] = "U_VDCmax||" + in_vdcmax;

			//double dd = (2 / Math.PI) * Math.Sqrt(2);
			//if (in_phs_out == "3") dd = (3 / Math.PI) * Math.Sqrt(2);
			//arr_CAL_FRML[15] = "U_Pi_1_3||" + dd.ToString();

			//if (in_Cbatt != "0")
			//{
				////T1 avec battery capa
				//arr_CAL_FRML[16] = "C_T1||C_T1_capa ;"; //+ dd.ToString();
			//}
			//else
			//{
				////T1 avec 15% du Sload
				//arr_CAL_FRML[16] = "C_T1||C_T1_15pct ;"; //+ dd.ToString();
			//}
			ISave = 22;

			//if (vdcMAX != 0){ arr_CAL_FRML[ISave] = "C_VDCMAX||" + vdcMAX; ISave++; }
			//if (Vac != 0){ arr_CAL_FRML[ISave] = "C_VAC||" + Vac; ISave++; }

			for (int iI = (int) ISave; iI < NB_FRML; iI++) arr_CAL_FRML[iI] = "";
		}

		/*
		private void Cal_AllCpt_41_Charger()
		{
			t1.Text = System.DateTime.Now.Second.ToString();
			this.Cursor = Cursors.WaitCursor;

			string stSql = "select * from COMPNT_LIST where Compnt_Type='E' or Compnt_Type='D'  order by Component_ID";
			SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			int debut = 0;
			lvDefOption.Items.Clear();
			while (Oreadr.Read())
			{
				if (debut == 0)
				{
					CHRGR = new Charger(MainMDI._connectionString, lFV.Text, cbPxx.Text, cbPhs.Text, cbVdc.Text, cbIdc.Text, tVac.Text, tVdcMax.Text);
					debut = 1;
				}
				Cpt = new Component();
				Cpt.CPT_COST(Convert.ToInt32(Oreadr["Component_ID"].ToString()));
				//MessageBox.Show(Oreadr["COMPONENT_REF"].ToString());
				if (Cpt.G_PRICE != Charger.VIDE)
				{
					ListViewItem lvI = lvDefOption.Items.Add(Oreadr["COMPONENT_REF"].ToString());
					//CHRGR.Cpt_List[0] = Cpt;
					lvI.SubItems.Add(Cpt.G_Desc.ToString());
					lvI.SubItems.Add("$ " + Cpt.G_PRICE.ToString());
					lvI.SubItems.Add("4");
					lvI.SubItems.Add(Oreadr["CatName1"].ToString() + "=" + Cpt.CAP1.ToString());
					if (Oreadr["CatName2"].ToString() != Charger.VIDE) lvI.SubItems.Add(Oreadr["CatName2"].ToString() + "=" + Cpt.CAP2.ToString());
					if (Oreadr["CatName3"].ToString() != Charger.VIDE) lvI.SubItems.Add(Oreadr["CatName3"].ToString() + "=" + Cpt.CAP3.ToString());
				}
			}
			OConn.Close();
			this.Cursor = Cursors.Default;
			t2.Text = System.DateTime.Now.Second.ToString();
		}
		*/
	}
}