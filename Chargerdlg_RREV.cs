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
	/// Summary description for Chargerdlg.
	/// </summary>
	public class Chargerdlg_RREV : System.Windows.Forms.Form
	{
		private Charger CHRGR;
		private Component Cpt;
		private Lib1 Tools = new Lib1();
		private string In_User; 
		private string In_TV; 
		private string In_BigTV; 
		private int L, ndxCxx = 0;
		private int lselI;
		public  string[] dlg_arr_CAL_FRML = new string[Charger.NB_FRML];
		public  string[,] ar_chrgr_info = new string[20, 12];
		private int dlg_arr_frml_NDX = 0;
		private const int xxCount = 20;
		private string[,] arC_xxx = new string[xxCount, 3];
		public string lOth_TV = "";

		private bool val_Chrg_Done = false;
		private bool val_Alrm_Done = false;

		private bool In_code;
	    //private string MainMDI._connectionString;
		private System.Windows.Forms.ColumnHeader Desc;
		private System.Windows.Forms.ColumnHeader UPrice;
		private System.Windows.Forms.ColumnHeader DlvDate;
		private System.Windows.Forms.ColumnHeader RefCpt;
		private System.Windows.Forms.ColumnHeader cat1;
		private System.Windows.Forms.ColumnHeader cat2;
		private System.Windows.Forms.ColumnHeader cat3;
		public System.Windows.Forms.ListView lvDefOption;
		private System.Windows.Forms.Label lCost;
		private System.Windows.Forms.GroupBox gbxCalc;
		private System.Windows.Forms.Label lcptName;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label lNcelCoef;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.RadioButton optAuto;
		private System.Windows.Forms.ComboBox cbXXX;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.ComboBox cbIdc;
		private System.Windows.Forms.Label label2;
		public System.Windows.Forms.ComboBox cbVdc;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.ComboBox cbPhs;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.ComboBox cbPxx;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lNBC_NI;
		private System.Windows.Forms.Label lNBC_LA;
		private System.Windows.Forms.Label lvpcE_NI;
		private System.Windows.Forms.Label lvpcF_NI;
		private System.Windows.Forms.Label lvpcE_LA;
		private System.Windows.Forms.Label lvpcF_LA;
		private System.Windows.Forms.Label lFLT_EQ_SEC;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label14;
		public System.Windows.Forms.TextBox tVEQL;
		private System.Windows.Forms.Label label17;
		public System.Windows.Forms.TextBox tVFLOAT;
		private System.Windows.Forms.Label Uchng;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.TextBox tIdcMax;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TextBox tIdcMin;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.TextBox tVdcMax;
		private System.Windows.Forms.Label label25;
		private System.Windows.Forms.TextBox tvdcMin;
		private System.Windows.Forms.Label label8;
		public System.Windows.Forms.TextBox tVac;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox tvpcEq;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tvpcF;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.TextBox tCellN;
		private System.Windows.Forms.Label lVcellMin_NI;
		private System.Windows.Forms.Label lVcellMin_LA;
		private System.Windows.Forms.Label t1;
		private System.Windows.Forms.Label t2;
		private System.Windows.Forms.Label oldvdcMAX;
		private System.Windows.Forms.Label oldMin_EQFLT;
		private System.Windows.Forms.Label oldVdc;
		private System.Windows.Forms.ColumnHeader Qty;
		public System.Windows.Forms.Label lSave;
		private System.Windows.Forms.ColumnHeader Ext;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label lFV;
		private System.Windows.Forms.RadioButton optVar;
		private System.Windows.Forms.RadioButton optFx;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label lNA;
		private System.Windows.Forms.RadioButton optLA;
		private System.Windows.Forms.RadioButton optNi;
		internal System.Windows.Forms.Button btnSProfile;
		private System.Windows.Forms.ContextMenu EdDelRenMnu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.ColumnHeader shw;
		internal System.Windows.Forms.Button btnLprofile;
		private System.Windows.Forms.Label lRiple;
		private System.Windows.Forms.Label lChrgREF;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.Label lhrtz;
		private System.Windows.Forms.RadioButton opt50;
		private System.Windows.Forms.RadioButton opt60;
		private System.Windows.Forms.RadioButton opt400;
		private System.Windows.Forms.Label lmin;
		private System.Windows.Forms.Label lxxx;
		private System.Windows.Forms.ColumnHeader cptRef;
		private System.Windows.Forms.Label lFTTT;
		private System.Windows.Forms.Label lDescc;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.LinkLabel LnkValidate;
		private System.Windows.Forms.GroupBox groupBox10;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.TextBox tExt;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TextBox tdesc;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.TextBox tLT;
		private System.Windows.Forms.Button ChngCancel;
		private System.Windows.Forms.Button btnOKchng;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.TextBox tUprice;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox tqty;
		private System.Windows.Forms.GroupBox grp1;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox tRef;
		private System.Windows.Forms.PictureBox pictureBox8;
		private System.Windows.Forms.ColumnHeader cptPartnb;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label ll;
		private System.Windows.Forms.TextBox minLT;
		private System.Windows.Forms.TextBox MaxLT;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tPxxQty;
		private System.Windows.Forms.Label tLTime;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.Label lhrtZMRK;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		public System.Windows.Forms.ComboBox cbIdctmp;
		private System.Windows.Forms.RadioButton optVrla;
		private System.Windows.Forms.TextBox tVDC;
		private System.Windows.Forms.TextBox TIDC;
		private System.Windows.Forms.TextBox tPxx;
		private System.Windows.Forms.TextBox tPhs;
		private System.Windows.Forms.GroupBox grpVals_tmp;
		internal System.Windows.Forms.Button btnMovestd;
		private System.Windows.Forms.Label lstdVDCMAXoo;
		private System.Windows.Forms.Label lstdVDCMINoo;
		private System.Windows.Forms.Label lUsr_tvpcEq;
		private System.Windows.Forms.Label lUsr_tvpcF;
		private System.Windows.Forms.Label lstdvdcMin;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label lstdvdcMax;
		private System.Windows.Forms.Label lstdVAC;
		private System.Windows.Forms.Label lstdCellN;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label31;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.TextBox lIprim;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.GroupBox groupBox13;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.TextBox lW2;
		private System.Windows.Forms.TextBox lW3;
		private System.Windows.Forms.TextBox lW1;
		private System.Windows.Forms.TextBox lTB45;
		private System.Windows.Forms.TextBox lF1;
		private System.Windows.Forms.TextBox lTB123;
		private System.Windows.Forms.TextBox lISH;
		private System.Windows.Forms.TextBox lD1;
		private System.Windows.Forms.TextBox lARM;
		private System.Windows.Forms.TextBox lCB2;
		private System.Windows.Forms.TextBox lT1;
		private System.Windows.Forms.TextBox lCB1;
		private System.Windows.Forms.TextBox lVSEC;
		private System.Windows.Forms.TextBox lKVA;
		private System.Windows.Forms.TextBox lVSECLN;
		private System.Windows.Forms.TextBox lVSECLL;
		private System.Windows.Forms.TextBox lISEC;
		private System.Windows.Forms.ColumnHeader TV;
		private System.Windows.Forms.ColumnHeader TVV;
		private System.Windows.Forms.ColumnHeader frml;
		public System.Windows.Forms.ListView LvTV;
		public System.Windows.Forms.Label lALRM;
		internal System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox tSig;
		private System.Windows.Forms.ComboBox cbVCS;
		private System.Windows.Forms.Label label10;
		internal System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox tdbl;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.GroupBox groupBox11;
		public System.Windows.Forms.LinkLabel lnkAlarm;
		public System.Windows.Forms.TextBox tModif_CH;
		public System.Windows.Forms.ListView lvOTI;
		private System.Windows.Forms.ColumnHeader inc;
		private System.Windows.Forms.ColumnHeader OTI_LID;
		private System.Windows.Forms.ColumnHeader Pref;
		private System.Windows.Forms.ColumnHeader Fname;
		private System.Windows.Forms.ColumnHeader Otis_Link1;
		private System.Windows.Forms.ColumnHeader Otis_Link2;
		private System.Windows.Forms.ColumnHeader Otis_Link3;
		private System.Windows.Forms.ColumnHeader Otis_Link4;
		public System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label lmdel;
		private System.Windows.Forms.ColumnHeader rien;
		public System.Windows.Forms.TextBox tModif_CHNew;
		private System.Windows.Forms.GroupBox groupBox14;
		public System.Windows.Forms.ListView lvCoef;
		private System.Windows.Forms.ColumnHeader CoefN;
		private System.Windows.Forms.ColumnHeader V;
        private LinkLabel linkFRMLS;
        private GroupBox groupBox7;
        private GroupBox groupBox15;
		//private System.Windows.Forms.Label lselI;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Chargerdlg_RREV(bool X_code, string x_TV, string x_BigTV, string x_nbL)
		{
			//
			//Required for Windows Form Designer support
			//
			
			InitializeComponent();
			t1.Text = DateTime.Now.Second.ToString() + " Init";
			In_code = X_code;
			//MainMDI._connectionString = MainMDI._connectionString;
			In_User = MainMDI.User; 
			In_TV = x_TV;
			In_BigTV = x_BigTV;
			fill_All_cb("cvi");
			fill_cbVCS();
			//t2.Text = DateTime.Now.Second.ToString() + " Init";
			L = 0; //defautl english
			minLT.Text = "04"; MaxLT.Text = "06"; 
			tLTime.Text = minLT.Text + "-" + MaxLT.Text; 
			load_Prof(); 
			load_OTI_LIST();
			btnOK.Visible = In_code;
			tPxx.Visible = In_code;
			tPhs.Visible = In_code;
			tVDC.Visible = In_code;
			TIDC.Visible = In_code;
            cbIdc.Visible =! In_code;
			cbVdc.Visible =! In_code;
			cbPxx.Visible =! In_code;
			cbPhs.Visible =! In_code;
			//
			//TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if(disposing)
				if(components != null) components.Dispose();
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chargerdlg_RREV));
            System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();
            this.gbxCalc = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lFTTT = new System.Windows.Forms.Label();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.label54 = new System.Windows.Forms.Label();
            this.lW2 = new System.Windows.Forms.TextBox();
            this.label55 = new System.Windows.Forms.Label();
            this.lW3 = new System.Windows.Forms.TextBox();
            this.lW1 = new System.Windows.Forms.TextBox();
            this.label50 = new System.Windows.Forms.Label();
            this.label51 = new System.Windows.Forms.Label();
            this.lTB45 = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.lF1 = new System.Windows.Forms.TextBox();
            this.lTB123 = new System.Windows.Forms.TextBox();
            this.lISH = new System.Windows.Forms.TextBox();
            this.label45 = new System.Windows.Forms.Label();
            this.lD1 = new System.Windows.Forms.TextBox();
            this.lARM = new System.Windows.Forms.TextBox();
            this.label46 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.lCB2 = new System.Windows.Forms.TextBox();
            this.label49 = new System.Windows.Forms.Label();
            this.lT1 = new System.Windows.Forms.TextBox();
            this.lCB1 = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.lVSEC = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.lKVA = new System.Windows.Forms.TextBox();
            this.lIprim = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.lVSECLN = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.lVSECLL = new System.Windows.Forms.TextBox();
            this.lISEC = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpVals_tmp = new System.Windows.Forms.GroupBox();
            this.lstdVAC = new System.Windows.Forms.Label();
            this.lstdCellN = new System.Windows.Forms.Label();
            this.btnMovestd = new System.Windows.Forms.Button();
            this.lstdVDCMAXoo = new System.Windows.Forms.Label();
            this.lstdVDCMINoo = new System.Windows.Forms.Label();
            this.lUsr_tvpcEq = new System.Windows.Forms.Label();
            this.lUsr_tvpcF = new System.Windows.Forms.Label();
            this.lstdvdcMax = new System.Windows.Forms.Label();
            this.lstdvdcMin = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.linkFRMLS = new System.Windows.Forms.LinkLabel();
            this.lvOTI = new System.Windows.Forms.ListView();
            this.inc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OTI_LID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Pref = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Fname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Otis_Link1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Otis_Link2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Otis_Link3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Otis_Link4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EdDelRenMnu = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.btnLprofile = new System.Windows.Forms.Button();
            this.btnSProfile = new System.Windows.Forms.Button();
            this.oldMin_EQFLT = new System.Windows.Forms.Label();
            this.oldvdcMAX = new System.Windows.Forms.Label();
            this.oldVdc = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tVEQL = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tVFLOAT = new System.Windows.Forms.TextBox();
            this.Uchng = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.tIdcMax = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.tIdcMin = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tVdcMax = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.tvdcMin = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tVac = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tvpcEq = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.tvpcF = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tCellN = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lVcellMin_LA = new System.Windows.Forms.Label();
            this.lVcellMin_NI = new System.Windows.Forms.Label();
            this.lFLT_EQ_SEC = new System.Windows.Forms.Label();
            this.lvpcE_LA = new System.Windows.Forms.Label();
            this.lvpcF_LA = new System.Windows.Forms.Label();
            this.lvpcE_NI = new System.Windows.Forms.Label();
            this.lvpcF_NI = new System.Windows.Forms.Label();
            this.lNBC_LA = new System.Windows.Forms.Label();
            this.lNBC_NI = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tPxxQty = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tLTime = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.MaxLT = new System.Windows.Forms.TextBox();
            this.ll = new System.Windows.Forms.Label();
            this.minLT = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lhrtZMRK = new System.Windows.Forms.Label();
            this.opt400 = new System.Windows.Forms.RadioButton();
            this.lhrtz = new System.Windows.Forms.Label();
            this.opt50 = new System.Windows.Forms.RadioButton();
            this.opt60 = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.optVrla = new System.Windows.Forms.RadioButton();
            this.lNA = new System.Windows.Forms.Label();
            this.optLA = new System.Windows.Forms.RadioButton();
            this.optNi = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lFV = new System.Windows.Forms.Label();
            this.optVar = new System.Windows.Forms.RadioButton();
            this.optFx = new System.Windows.Forms.RadioButton();
            this.optAuto = new System.Windows.Forms.RadioButton();
            this.lmin = new System.Windows.Forms.Label();
            this.lxxx = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.cbIdctmp = new System.Windows.Forms.ComboBox();
            this.cbXXX = new System.Windows.Forms.ComboBox();
            this.tVDC = new System.Windows.Forms.TextBox();
            this.tPhs = new System.Windows.Forms.TextBox();
            this.cbVdc = new System.Windows.Forms.ComboBox();
            this.tPxx = new System.Windows.Forms.TextBox();
            this.cbPxx = new System.Windows.Forms.ComboBox();
            this.cbPhs = new System.Windows.Forms.ComboBox();
            this.TIDC = new System.Windows.Forms.TextBox();
            this.cbIdc = new System.Windows.Forms.ComboBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lnkAlarm = new System.Windows.Forms.LinkLabel();
            this.LnkValidate = new System.Windows.Forms.LinkLabel();
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.lvCoef = new System.Windows.Forms.ListView();
            this.CoefN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.V = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox13 = new System.Windows.Forms.GroupBox();
            this.LvTV = new System.Windows.Forms.ListView();
            this.rien = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TVV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.frml = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tModif_CH = new System.Windows.Forms.TextBox();
            this.lvDefOption = new System.Windows.Forms.ListView();
            this.shw = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RefCpt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ext = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DlvDate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cat1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cat2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cat3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cptRef = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cptPartnb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.tModif_CHNew = new System.Windows.Forms.TextBox();
            this.lmdel = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.cbVCS = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.tSig = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.tdbl = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.lALRM = new System.Windows.Forms.Label();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tRef = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.tExt = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.tdesc = new System.Windows.Forms.TextBox();
            this.label43 = new System.Windows.Forms.Label();
            this.tLT = new System.Windows.Forms.TextBox();
            this.ChngCancel = new System.Windows.Forms.Button();
            this.btnOKchng = new System.Windows.Forms.Button();
            this.label42 = new System.Windows.Forms.Label();
            this.tUprice = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tqty = new System.Windows.Forms.TextBox();
            this.lDescc = new System.Windows.Forms.Label();
            this.lRiple = new System.Windows.Forms.Label();
            this.lSave = new System.Windows.Forms.Label();
            this.t1 = new System.Windows.Forms.Label();
            this.t2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lNcelCoef = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lcptName = new System.Windows.Forms.Label();
            this.lCost = new System.Windows.Forms.Label();
            this.lChrgREF = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.groupBox15 = new System.Windows.Forms.GroupBox();
            this.gbxCalc.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpVals_tmp.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.groupBox14.SuspendLayout();
            this.groupBox13.SuspendLayout();
            this.grp1.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.groupBox7.SuspendLayout();
            this.groupBox15.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbxCalc
            // 
            this.gbxCalc.Controls.Add(this.btnOK);
            this.gbxCalc.Controls.Add(this.btnCancel);
            this.gbxCalc.Controls.Add(this.lFTTT);
            this.gbxCalc.Controls.Add(this.groupBox12);
            this.gbxCalc.Controls.Add(this.pictureBox1);
            this.gbxCalc.Controls.Add(this.grpVals_tmp);
            this.gbxCalc.Controls.Add(this.groupBox4);
            this.gbxCalc.Controls.Add(this.groupBox3);
            this.gbxCalc.Controls.Add(this.groupBox2);
            this.gbxCalc.Controls.Add(this.pictureBox2);
            this.gbxCalc.Controls.Add(this.lnkAlarm);
            this.gbxCalc.Controls.Add(this.LnkValidate);
            this.gbxCalc.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxCalc.Location = new System.Drawing.Point(0, 0);
            this.gbxCalc.Name = "gbxCalc";
            this.gbxCalc.Size = new System.Drawing.Size(1460, 164);
            this.gbxCalc.TabIndex = 78;
            this.gbxCalc.TabStop = false;
            this.gbxCalc.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.PowderBlue;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(1372, 57);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 36);
            this.btnOK.TabIndex = 286;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancel.Location = new System.Drawing.Point(1475, 57);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(108, 36);
            this.btnCancel.TabIndex = 287;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // lFTTT
            // 
            this.lFTTT.BackColor = System.Drawing.Color.Lime;
            this.lFTTT.ForeColor = System.Drawing.Color.Black;
            this.lFTTT.Location = new System.Drawing.Point(353, 115);
            this.lFTTT.Name = "lFTTT";
            this.lFTTT.Size = new System.Drawing.Size(38, 19);
            this.lFTTT.TabIndex = 204;
            this.lFTTT.Visible = false;
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.label33);
            this.groupBox12.Controls.Add(this.label27);
            this.groupBox12.Controls.Add(this.label53);
            this.groupBox12.Controls.Add(this.label54);
            this.groupBox12.Controls.Add(this.lW2);
            this.groupBox12.Controls.Add(this.label55);
            this.groupBox12.Controls.Add(this.lW3);
            this.groupBox12.Controls.Add(this.lW1);
            this.groupBox12.Controls.Add(this.label50);
            this.groupBox12.Controls.Add(this.label51);
            this.groupBox12.Controls.Add(this.lTB45);
            this.groupBox12.Controls.Add(this.label52);
            this.groupBox12.Controls.Add(this.lF1);
            this.groupBox12.Controls.Add(this.lTB123);
            this.groupBox12.Controls.Add(this.lISH);
            this.groupBox12.Controls.Add(this.label45);
            this.groupBox12.Controls.Add(this.lD1);
            this.groupBox12.Controls.Add(this.lARM);
            this.groupBox12.Controls.Add(this.label46);
            this.groupBox12.Controls.Add(this.label47);
            this.groupBox12.Controls.Add(this.lCB2);
            this.groupBox12.Controls.Add(this.label49);
            this.groupBox12.Controls.Add(this.lT1);
            this.groupBox12.Controls.Add(this.lCB1);
            this.groupBox12.Controls.Add(this.label37);
            this.groupBox12.Controls.Add(this.label38);
            this.groupBox12.Controls.Add(this.lVSEC);
            this.groupBox12.Controls.Add(this.label39);
            this.groupBox12.Controls.Add(this.lKVA);
            this.groupBox12.Controls.Add(this.lIprim);
            this.groupBox12.Controls.Add(this.label31);
            this.groupBox12.Controls.Add(this.label36);
            this.groupBox12.Controls.Add(this.lVSECLN);
            this.groupBox12.Controls.Add(this.label32);
            this.groupBox12.Controls.Add(this.lVSECLL);
            this.groupBox12.Controls.Add(this.lISEC);
            this.groupBox12.Location = new System.Drawing.Point(546, 359);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(173, 115);
            this.groupBox12.TabIndex = 161;
            this.groupBox12.TabStop = false;
            // 
            // label33
            // 
            this.label33.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label33.Location = new System.Drawing.Point(202, 159);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(48, 19);
            this.label33.TabIndex = 259;
            this.label33.Text = "ISH:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.Location = new System.Drawing.Point(202, 136);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(48, 19);
            this.label27.TabIndex = 258;
            this.label27.Text = "F1:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label53
            // 
            this.label53.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.Location = new System.Drawing.Point(336, 67);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(48, 18);
            this.label53.TabIndex = 257;
            this.label53.Text = " W3:";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label54
            // 
            this.label54.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.Location = new System.Drawing.Point(346, 44);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(38, 18);
            this.label54.TabIndex = 256;
            this.label54.Text = "W2:";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lW2
            // 
            this.lW2.BackColor = System.Drawing.Color.AliceBlue;
            this.lW2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lW2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lW2.ForeColor = System.Drawing.Color.Red;
            this.lW2.Location = new System.Drawing.Point(384, 42);
            this.lW2.Name = "lW2";
            this.lW2.Size = new System.Drawing.Size(192, 23);
            this.lW2.TabIndex = 255;
            this.lW2.Text = "0";
            // 
            // label55
            // 
            this.label55.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.Location = new System.Drawing.Point(346, 21);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(38, 18);
            this.label55.TabIndex = 254;
            this.label55.Text = "W1:";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lW3
            // 
            this.lW3.BackColor = System.Drawing.Color.AliceBlue;
            this.lW3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lW3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lW3.ForeColor = System.Drawing.Color.Red;
            this.lW3.Location = new System.Drawing.Point(384, 65);
            this.lW3.Name = "lW3";
            this.lW3.Size = new System.Drawing.Size(192, 23);
            this.lW3.TabIndex = 253;
            this.lW3.Text = "0";
            // 
            // lW1
            // 
            this.lW1.BackColor = System.Drawing.Color.AliceBlue;
            this.lW1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lW1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lW1.ForeColor = System.Drawing.Color.Red;
            this.lW1.Location = new System.Drawing.Point(384, 18);
            this.lW1.Name = "lW1";
            this.lW1.Size = new System.Drawing.Size(192, 23);
            this.lW1.TabIndex = 252;
            this.lW1.Text = "0";
            // 
            // label50
            // 
            this.label50.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.Location = new System.Drawing.Point(202, 111);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(48, 18);
            this.label50.TabIndex = 251;
            this.label50.Text = "ARM:";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label51
            // 
            this.label51.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.Location = new System.Drawing.Point(192, 90);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(58, 18);
            this.label51.TabIndex = 250;
            this.label51.Text = "TB4,5:";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lTB45
            // 
            this.lTB45.BackColor = System.Drawing.Color.AliceBlue;
            this.lTB45.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lTB45.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTB45.ForeColor = System.Drawing.Color.Red;
            this.lTB45.Location = new System.Drawing.Point(250, 88);
            this.lTB45.Name = "lTB45";
            this.lTB45.Size = new System.Drawing.Size(86, 23);
            this.lTB45.TabIndex = 249;
            this.lTB45.Text = "0";
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.Location = new System.Drawing.Point(182, 67);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(68, 18);
            this.label52.TabIndex = 248;
            this.label52.Text = "TB123:";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lF1
            // 
            this.lF1.BackColor = System.Drawing.Color.AliceBlue;
            this.lF1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lF1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lF1.ForeColor = System.Drawing.Color.Red;
            this.lF1.Location = new System.Drawing.Point(250, 134);
            this.lF1.Name = "lF1";
            this.lF1.Size = new System.Drawing.Size(86, 23);
            this.lF1.TabIndex = 247;
            this.lF1.Text = "0";
            // 
            // lTB123
            // 
            this.lTB123.BackColor = System.Drawing.Color.AliceBlue;
            this.lTB123.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lTB123.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTB123.ForeColor = System.Drawing.Color.Red;
            this.lTB123.Location = new System.Drawing.Point(250, 65);
            this.lTB123.Name = "lTB123";
            this.lTB123.Size = new System.Drawing.Size(86, 23);
            this.lTB123.TabIndex = 246;
            this.lTB123.Text = "0";
            // 
            // lISH
            // 
            this.lISH.BackColor = System.Drawing.Color.AliceBlue;
            this.lISH.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lISH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lISH.ForeColor = System.Drawing.Color.Red;
            this.lISH.Location = new System.Drawing.Point(250, 157);
            this.lISH.Name = "lISH";
            this.lISH.Size = new System.Drawing.Size(86, 23);
            this.lISH.TabIndex = 243;
            this.lISH.Text = "0";
            // 
            // label45
            // 
            this.label45.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label45.Location = new System.Drawing.Point(346, 90);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(38, 18);
            this.label45.TabIndex = 242;
            this.label45.Text = "D1:";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lD1
            // 
            this.lD1.BackColor = System.Drawing.Color.AliceBlue;
            this.lD1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lD1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lD1.ForeColor = System.Drawing.Color.Red;
            this.lD1.Location = new System.Drawing.Point(384, 88);
            this.lD1.Name = "lD1";
            this.lD1.Size = new System.Drawing.Size(86, 23);
            this.lD1.TabIndex = 241;
            this.lD1.Text = "0";
            // 
            // lARM
            // 
            this.lARM.BackColor = System.Drawing.Color.AliceBlue;
            this.lARM.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lARM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lARM.ForeColor = System.Drawing.Color.Red;
            this.lARM.Location = new System.Drawing.Point(250, 111);
            this.lARM.Name = "lARM";
            this.lARM.Size = new System.Drawing.Size(86, 23);
            this.lARM.TabIndex = 240;
            this.lARM.Text = "0";
            // 
            // label46
            // 
            this.label46.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label46.ForeColor = System.Drawing.Color.Blue;
            this.label46.Location = new System.Drawing.Point(38, 113);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(39, 19);
            this.label46.TabIndex = 239;
            this.label46.Text = "T1:";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label47
            // 
            this.label47.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label47.Location = new System.Drawing.Point(202, 44);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(48, 18);
            this.label47.TabIndex = 238;
            this.label47.Text = "CB2:";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lCB2
            // 
            this.lCB2.BackColor = System.Drawing.Color.AliceBlue;
            this.lCB2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lCB2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCB2.ForeColor = System.Drawing.Color.Red;
            this.lCB2.Location = new System.Drawing.Point(250, 42);
            this.lCB2.Name = "lCB2";
            this.lCB2.Size = new System.Drawing.Size(86, 23);
            this.lCB2.TabIndex = 237;
            this.lCB2.Text = "0";
            // 
            // label49
            // 
            this.label49.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label49.Location = new System.Drawing.Point(202, 21);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(48, 18);
            this.label49.TabIndex = 236;
            this.label49.Text = "CB1:";
            this.label49.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lT1
            // 
            this.lT1.BackColor = System.Drawing.Color.AliceBlue;
            this.lT1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lT1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lT1.ForeColor = System.Drawing.Color.Red;
            this.lT1.Location = new System.Drawing.Point(77, 111);
            this.lT1.Name = "lT1";
            this.lT1.Size = new System.Drawing.Size(86, 23);
            this.lT1.TabIndex = 235;
            this.lT1.Text = "0";
            // 
            // lCB1
            // 
            this.lCB1.BackColor = System.Drawing.Color.AliceBlue;
            this.lCB1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lCB1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCB1.ForeColor = System.Drawing.Color.Red;
            this.lCB1.Location = new System.Drawing.Point(250, 18);
            this.lCB1.Name = "lCB1";
            this.lCB1.Size = new System.Drawing.Size(86, 23);
            this.lCB1.TabIndex = 234;
            this.lCB1.Text = "0";
            // 
            // label37
            // 
            this.label37.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.Color.Blue;
            this.label37.Location = new System.Drawing.Point(19, 67);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(58, 18);
            this.label37.TabIndex = 233;
            this.label37.Text = "VSEC:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.Color.Blue;
            this.label38.Location = new System.Drawing.Point(10, 90);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(67, 18);
            this.label38.TabIndex = 232;
            this.label38.Text = "KVA:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lVSEC
            // 
            this.lVSEC.BackColor = System.Drawing.Color.AliceBlue;
            this.lVSEC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lVSEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVSEC.ForeColor = System.Drawing.Color.Red;
            this.lVSEC.Location = new System.Drawing.Point(77, 65);
            this.lVSEC.Name = "lVSEC";
            this.lVSEC.Size = new System.Drawing.Size(86, 23);
            this.lVSEC.TabIndex = 231;
            this.lVSEC.Text = "0";
            // 
            // label39
            // 
            this.label39.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.Color.Blue;
            this.label39.Location = new System.Drawing.Point(10, 44);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(67, 18);
            this.label39.TabIndex = 230;
            this.label39.Text = "IPRIM:";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lKVA
            // 
            this.lKVA.BackColor = System.Drawing.Color.AliceBlue;
            this.lKVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lKVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lKVA.ForeColor = System.Drawing.Color.Red;
            this.lKVA.Location = new System.Drawing.Point(77, 88);
            this.lKVA.Name = "lKVA";
            this.lKVA.Size = new System.Drawing.Size(86, 23);
            this.lKVA.TabIndex = 229;
            this.lKVA.Text = "0";
            // 
            // lIprim
            // 
            this.lIprim.BackColor = System.Drawing.Color.AliceBlue;
            this.lIprim.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lIprim.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lIprim.ForeColor = System.Drawing.Color.Red;
            this.lIprim.Location = new System.Drawing.Point(77, 42);
            this.lIprim.Name = "lIprim";
            this.lIprim.Size = new System.Drawing.Size(86, 23);
            this.lIprim.TabIndex = 228;
            this.lIprim.Text = "0";
            // 
            // label31
            // 
            this.label31.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.Location = new System.Drawing.Point(10, 159);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(67, 19);
            this.label31.TabIndex = 227;
            this.label31.Text = "VSECLL:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.Location = new System.Drawing.Point(10, 136);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(67, 19);
            this.label36.TabIndex = 222;
            this.label36.Text = "VSECLN:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lVSECLN
            // 
            this.lVSECLN.BackColor = System.Drawing.Color.AliceBlue;
            this.lVSECLN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lVSECLN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVSECLN.ForeColor = System.Drawing.Color.Red;
            this.lVSECLN.Location = new System.Drawing.Point(77, 134);
            this.lVSECLN.Name = "lVSECLN";
            this.lVSECLN.Size = new System.Drawing.Size(86, 23);
            this.lVSECLN.TabIndex = 221;
            this.lVSECLN.Text = "0";
            // 
            // label32
            // 
            this.label32.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.Blue;
            this.label32.Location = new System.Drawing.Point(10, 21);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(67, 18);
            this.label32.TabIndex = 218;
            this.label32.Text = "ISEC:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lVSECLL
            // 
            this.lVSECLL.BackColor = System.Drawing.Color.AliceBlue;
            this.lVSECLL.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lVSECLL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVSECLL.ForeColor = System.Drawing.Color.Red;
            this.lVSECLL.Location = new System.Drawing.Point(77, 157);
            this.lVSECLL.Name = "lVSECLL";
            this.lVSECLL.Size = new System.Drawing.Size(86, 23);
            this.lVSECLL.TabIndex = 217;
            this.lVSECLL.Text = "0";
            // 
            // lISEC
            // 
            this.lISEC.BackColor = System.Drawing.Color.AliceBlue;
            this.lISEC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lISEC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lISEC.ForeColor = System.Drawing.Color.Red;
            this.lISEC.Location = new System.Drawing.Point(77, 18);
            this.lISEC.Name = "lISEC";
            this.lISEC.Size = new System.Drawing.Size(86, 23);
            this.lISEC.TabIndex = 216;
            this.lISEC.Text = "0";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(1057, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(114, 86);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 177;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // grpVals_tmp
            // 
            this.grpVals_tmp.Controls.Add(this.lstdVAC);
            this.grpVals_tmp.Controls.Add(this.lstdCellN);
            this.grpVals_tmp.Controls.Add(this.btnMovestd);
            this.grpVals_tmp.Controls.Add(this.lstdVDCMAXoo);
            this.grpVals_tmp.Controls.Add(this.lstdVDCMINoo);
            this.grpVals_tmp.Controls.Add(this.lUsr_tvpcEq);
            this.grpVals_tmp.Controls.Add(this.lUsr_tvpcF);
            this.grpVals_tmp.Controls.Add(this.lstdvdcMax);
            this.grpVals_tmp.Controls.Add(this.lstdvdcMin);
            this.grpVals_tmp.Controls.Add(this.label26);
            this.grpVals_tmp.Controls.Add(this.label23);
            this.grpVals_tmp.Controls.Add(this.label13);
            this.grpVals_tmp.Controls.Add(this.label21);
            this.grpVals_tmp.Location = new System.Drawing.Point(751, 423);
            this.grpVals_tmp.Name = "grpVals_tmp";
            this.grpVals_tmp.Size = new System.Drawing.Size(154, 54);
            this.grpVals_tmp.TabIndex = 216;
            this.grpVals_tmp.TabStop = false;
            this.grpVals_tmp.Text = "PRIMAX Standards";
            this.grpVals_tmp.Visible = false;
            // 
            // lstdVAC
            // 
            this.lstdVAC.BackColor = System.Drawing.SystemColors.Control;
            this.lstdVAC.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lstdVAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstdVAC.ForeColor = System.Drawing.Color.Black;
            this.lstdVAC.Location = new System.Drawing.Point(175, 44);
            this.lstdVAC.Name = "lstdVAC";
            this.lstdVAC.Size = new System.Drawing.Size(31, 18);
            this.lstdVAC.TabIndex = 188;
            this.lstdVAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstdCellN
            // 
            this.lstdCellN.BackColor = System.Drawing.Color.Lime;
            this.lstdCellN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lstdCellN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstdCellN.ForeColor = System.Drawing.Color.Black;
            this.lstdCellN.Location = new System.Drawing.Point(67, 18);
            this.lstdCellN.Name = "lstdCellN";
            this.lstdCellN.Size = new System.Drawing.Size(47, 21);
            this.lstdCellN.TabIndex = 187;
            this.lstdCellN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnMovestd
            // 
            this.btnMovestd.BackColor = System.Drawing.Color.LightSteelBlue;
            this.btnMovestd.ForeColor = System.Drawing.Color.Red;
            this.btnMovestd.Location = new System.Drawing.Point(67, 97);
            this.btnMovestd.Name = "btnMovestd";
            this.btnMovestd.Size = new System.Drawing.Size(84, 23);
            this.btnMovestd.TabIndex = 196;
            this.btnMovestd.Text = "LOAD";
            this.btnMovestd.UseVisualStyleBackColor = false;
            this.btnMovestd.Visible = false;
            // 
            // lstdVDCMAXoo
            // 
            this.lstdVDCMAXoo.BackColor = System.Drawing.Color.Chocolate;
            this.lstdVDCMAXoo.ForeColor = System.Drawing.Color.Black;
            this.lstdVDCMAXoo.Location = new System.Drawing.Point(365, 65);
            this.lstdVDCMAXoo.Name = "lstdVDCMAXoo";
            this.lstdVDCMAXoo.Size = new System.Drawing.Size(19, 18);
            this.lstdVDCMAXoo.TabIndex = 195;
            this.lstdVDCMAXoo.Visible = false;
            // 
            // lstdVDCMINoo
            // 
            this.lstdVDCMINoo.BackColor = System.Drawing.Color.Chocolate;
            this.lstdVDCMINoo.ForeColor = System.Drawing.Color.Black;
            this.lstdVDCMINoo.Location = new System.Drawing.Point(365, 46);
            this.lstdVDCMINoo.Name = "lstdVDCMINoo";
            this.lstdVDCMINoo.Size = new System.Drawing.Size(24, 19);
            this.lstdVDCMINoo.TabIndex = 194;
            this.lstdVDCMINoo.Visible = false;
            // 
            // lUsr_tvpcEq
            // 
            this.lUsr_tvpcEq.BackColor = System.Drawing.Color.Chocolate;
            this.lUsr_tvpcEq.ForeColor = System.Drawing.Color.Black;
            this.lUsr_tvpcEq.Location = new System.Drawing.Point(384, 18);
            this.lUsr_tvpcEq.Name = "lUsr_tvpcEq";
            this.lUsr_tvpcEq.Size = new System.Drawing.Size(10, 19);
            this.lUsr_tvpcEq.TabIndex = 193;
            this.lUsr_tvpcEq.Visible = false;
            // 
            // lUsr_tvpcF
            // 
            this.lUsr_tvpcF.BackColor = System.Drawing.Color.Chocolate;
            this.lUsr_tvpcF.ForeColor = System.Drawing.Color.Black;
            this.lUsr_tvpcF.Location = new System.Drawing.Point(365, 18);
            this.lUsr_tvpcF.Name = "lUsr_tvpcF";
            this.lUsr_tvpcF.Size = new System.Drawing.Size(9, 19);
            this.lUsr_tvpcF.TabIndex = 192;
            this.lUsr_tvpcF.Visible = false;
            // 
            // lstdvdcMax
            // 
            this.lstdvdcMax.BackColor = System.Drawing.SystemColors.Control;
            this.lstdvdcMax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lstdvdcMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstdvdcMax.ForeColor = System.Drawing.Color.Black;
            this.lstdvdcMax.Location = new System.Drawing.Point(109, 148);
            this.lstdvdcMax.Name = "lstdvdcMax";
            this.lstdvdcMax.Size = new System.Drawing.Size(25, 18);
            this.lstdvdcMax.TabIndex = 189;
            this.lstdvdcMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstdvdcMin
            // 
            this.lstdvdcMin.BackColor = System.Drawing.SystemColors.Control;
            this.lstdvdcMin.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lstdvdcMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstdvdcMin.ForeColor = System.Drawing.Color.Black;
            this.lstdvdcMin.Location = new System.Drawing.Point(67, 55);
            this.lstdvdcMin.Name = "lstdvdcMin";
            this.lstdvdcMin.Size = new System.Drawing.Size(67, 19);
            this.lstdvdcMin.TabIndex = 191;
            this.lstdvdcMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(0, 55);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(67, 19);
            this.label26.TabIndex = 190;
            this.label26.Text = "Vdc Min:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(0, 74);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(67, 18);
            this.label23.TabIndex = 186;
            this.label23.Text = "Vdc Max:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(10, 37);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(48, 18);
            this.label13.TabIndex = 185;
            this.label13.Text = "VAC:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(10, 18);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(57, 19);
            this.label21.TabIndex = 184;
            this.label21.Text = "Cell #:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.linkFRMLS);
            this.groupBox4.Controls.Add(this.lvOTI);
            this.groupBox4.Controls.Add(this.btnLprofile);
            this.groupBox4.Controls.Add(this.btnSProfile);
            this.groupBox4.Controls.Add(this.oldMin_EQFLT);
            this.groupBox4.Controls.Add(this.oldvdcMAX);
            this.groupBox4.Controls.Add(this.oldVdc);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.tVEQL);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.tVFLOAT);
            this.groupBox4.Controls.Add(this.Uchng);
            this.groupBox4.Controls.Add(this.label19);
            this.groupBox4.Controls.Add(this.tIdcMax);
            this.groupBox4.Controls.Add(this.label20);
            this.groupBox4.Controls.Add(this.tIdcMin);
            this.groupBox4.Controls.Add(this.label24);
            this.groupBox4.Controls.Add(this.tVdcMax);
            this.groupBox4.Controls.Add(this.label25);
            this.groupBox4.Controls.Add(this.tvdcMin);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.tVac);
            this.groupBox4.Controls.Add(this.label9);
            this.groupBox4.Controls.Add(this.tvpcEq);
            this.groupBox4.Controls.Add(this.label11);
            this.groupBox4.Controls.Add(this.tvpcF);
            this.groupBox4.Controls.Add(this.label7);
            this.groupBox4.Controls.Add(this.tCellN);
            this.groupBox4.Location = new System.Drawing.Point(448, 9);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(422, 147);
            this.groupBox4.TabIndex = 141;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Calculated Values";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // linkFRMLS
            // 
            this.linkFRMLS.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkFRMLS.Location = new System.Drawing.Point(187, 273);
            this.linkFRMLS.Name = "linkFRMLS";
            this.linkFRMLS.Size = new System.Drawing.Size(82, 19);
            this.linkFRMLS.TabIndex = 288;
            this.linkFRMLS.TabStop = true;
            this.linkFRMLS.Text = "Frmls.....";
            this.linkFRMLS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.linkFRMLS.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkFRMLS_LinkClicked);
            // 
            // lvOTI
            // 
            this.lvOTI.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvOTI.CheckBoxes = true;
            this.lvOTI.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.inc,
            this.OTI_LID,
            this.Pref,
            this.Fname,
            this.Otis_Link1,
            this.Otis_Link2,
            this.Otis_Link3,
            this.Otis_Link4});
            this.lvOTI.ContextMenu = this.EdDelRenMnu;
            this.lvOTI.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvOTI.FullRowSelect = true;
            this.lvOTI.GridLines = true;
            this.lvOTI.HideSelection = false;
            this.lvOTI.Location = new System.Drawing.Point(10, 148);
            this.lvOTI.Name = "lvOTI";
            this.lvOTI.Size = new System.Drawing.Size(175, 175);
            this.lvOTI.TabIndex = 217;
            this.lvOTI.UseCompatibleStateImageBehavior = false;
            this.lvOTI.View = System.Windows.Forms.View.Details;
            this.lvOTI.Visible = false;
            // 
            // inc
            // 
            this.inc.Text = "Included  Options ";
            this.inc.Width = 124;
            // 
            // OTI_LID
            // 
            this.OTI_LID.Text = "";
            this.OTI_LID.Width = 0;
            // 
            // Pref
            // 
            this.Pref.Text = "";
            this.Pref.Width = 0;
            // 
            // Fname
            // 
            this.Fname.Text = "";
            this.Fname.Width = 0;
            // 
            // Otis_Link1
            // 
            this.Otis_Link1.Text = "";
            this.Otis_Link1.Width = 0;
            // 
            // Otis_Link2
            // 
            this.Otis_Link2.Text = "";
            this.Otis_Link2.Width = 0;
            // 
            // Otis_Link3
            // 
            this.Otis_Link3.Text = "";
            this.Otis_Link3.Width = 0;
            // 
            // Otis_Link4
            // 
            this.Otis_Link4.Text = "";
            this.Otis_Link4.Width = 0;
            // 
            // EdDelRenMnu
            // 
            this.EdDelRenMnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Component from list";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "Delete ";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click_2);
            // 
            // btnLprofile
            // 
            this.btnLprofile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLprofile.Location = new System.Drawing.Point(355, 18);
            this.btnLprofile.Name = "btnLprofile";
            this.btnLprofile.Size = new System.Drawing.Size(58, 10);
            this.btnLprofile.TabIndex = 200;
            this.btnLprofile.Text = "Load Profile";
            this.btnLprofile.Visible = false;
            this.btnLprofile.Click += new System.EventHandler(this.btnLprofile_Click);
            // 
            // btnSProfile
            // 
            this.btnSProfile.Enabled = false;
            this.btnSProfile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSProfile.Location = new System.Drawing.Point(355, 37);
            this.btnSProfile.Name = "btnSProfile";
            this.btnSProfile.Size = new System.Drawing.Size(58, 9);
            this.btnSProfile.TabIndex = 199;
            this.btnSProfile.Text = "Save as default profile";
            this.btnSProfile.Visible = false;
            this.btnSProfile.Click += new System.EventHandler(this.btnSProfile_Click);
            // 
            // oldMin_EQFLT
            // 
            this.oldMin_EQFLT.BackColor = System.Drawing.Color.Chocolate;
            this.oldMin_EQFLT.ForeColor = System.Drawing.Color.Black;
            this.oldMin_EQFLT.Location = new System.Drawing.Point(154, 258);
            this.oldMin_EQFLT.Name = "oldMin_EQFLT";
            this.oldMin_EQFLT.Size = new System.Drawing.Size(19, 19);
            this.oldMin_EQFLT.TabIndex = 198;
            this.oldMin_EQFLT.Visible = false;
            // 
            // oldvdcMAX
            // 
            this.oldvdcMAX.BackColor = System.Drawing.Color.Chocolate;
            this.oldvdcMAX.ForeColor = System.Drawing.Color.Black;
            this.oldvdcMAX.Location = new System.Drawing.Point(144, 240);
            this.oldvdcMAX.Name = "oldvdcMAX";
            this.oldvdcMAX.Size = new System.Drawing.Size(19, 18);
            this.oldvdcMAX.TabIndex = 197;
            this.oldvdcMAX.Visible = false;
            // 
            // oldVdc
            // 
            this.oldVdc.BackColor = System.Drawing.Color.Chocolate;
            this.oldVdc.ForeColor = System.Drawing.Color.Black;
            this.oldVdc.Location = new System.Drawing.Point(144, 286);
            this.oldVdc.Name = "oldVdc";
            this.oldVdc.Size = new System.Drawing.Size(29, 19);
            this.oldVdc.TabIndex = 196;
            this.oldVdc.Visible = false;
            this.oldVdc.Click += new System.EventHandler(this.oldVdc_Click);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(192, 67);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(67, 18);
            this.label14.TabIndex = 162;
            this.label14.Text = "VEqual";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tVEQL
            // 
            this.tVEQL.BackColor = System.Drawing.SystemColors.Control;
            this.tVEQL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tVEQL.ForeColor = System.Drawing.Color.Red;
            this.tVEQL.Location = new System.Drawing.Point(259, 65);
            this.tVEQL.Name = "tVEQL";
            this.tVEQL.ReadOnly = true;
            this.tVEQL.Size = new System.Drawing.Size(87, 23);
            this.tVEQL.TabIndex = 161;
            this.tVEQL.Text = "0.00";
            this.tVEQL.TextChanged += new System.EventHandler(this.tVEQL_TextChanged);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(192, 44);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(67, 18);
            this.label17.TabIndex = 160;
            this.label17.Text = "VFloat";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tVFLOAT
            // 
            this.tVFLOAT.BackColor = System.Drawing.SystemColors.Control;
            this.tVFLOAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tVFLOAT.ForeColor = System.Drawing.Color.Red;
            this.tVFLOAT.Location = new System.Drawing.Point(259, 42);
            this.tVFLOAT.Name = "tVFLOAT";
            this.tVFLOAT.ReadOnly = true;
            this.tVFLOAT.Size = new System.Drawing.Size(87, 23);
            this.tVFLOAT.TabIndex = 159;
            this.tVFLOAT.Text = "0.00";
            // 
            // Uchng
            // 
            this.Uchng.BackColor = System.Drawing.Color.Lime;
            this.Uchng.ForeColor = System.Drawing.Color.Black;
            this.Uchng.Location = new System.Drawing.Point(202, 0);
            this.Uchng.Name = "Uchng";
            this.Uchng.Size = new System.Drawing.Size(19, 18);
            this.Uchng.TabIndex = 158;
            this.Uchng.Text = "N";
            this.Uchng.Visible = false;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.Location = new System.Drawing.Point(182, 113);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(77, 19);
            this.label19.TabIndex = 157;
            this.label19.Text = "IDC Max";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tIdcMax
            // 
            this.tIdcMax.BackColor = System.Drawing.SystemColors.Control;
            this.tIdcMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIdcMax.ForeColor = System.Drawing.Color.Red;
            this.tIdcMax.Location = new System.Drawing.Point(259, 111);
            this.tIdcMax.Name = "tIdcMax";
            this.tIdcMax.ReadOnly = true;
            this.tIdcMax.Size = new System.Drawing.Size(87, 23);
            this.tIdcMax.TabIndex = 156;
            this.tIdcMax.Text = "0.00";
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.Location = new System.Drawing.Point(192, 90);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(67, 18);
            this.label20.TabIndex = 155;
            this.label20.Text = "IDC Min:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tIdcMin
            // 
            this.tIdcMin.BackColor = System.Drawing.SystemColors.Control;
            this.tIdcMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIdcMin.ForeColor = System.Drawing.Color.Red;
            this.tIdcMin.Location = new System.Drawing.Point(259, 88);
            this.tIdcMin.Name = "tIdcMin";
            this.tIdcMin.ReadOnly = true;
            this.tIdcMin.Size = new System.Drawing.Size(87, 23);
            this.tIdcMin.TabIndex = 154;
            this.tIdcMin.Text = "0.00";
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Blue;
            this.label24.Location = new System.Drawing.Point(10, 113);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(86, 19);
            this.label24.TabIndex = 153;
            this.label24.Text = "VDC Max";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tVdcMax
            // 
            this.tVdcMax.BackColor = System.Drawing.SystemColors.Control;
            this.tVdcMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tVdcMax.ForeColor = System.Drawing.Color.Red;
            this.tVdcMax.Location = new System.Drawing.Point(96, 111);
            this.tVdcMax.Name = "tVdcMax";
            this.tVdcMax.ReadOnly = true;
            this.tVdcMax.Size = new System.Drawing.Size(86, 23);
            this.tVdcMax.TabIndex = 152;
            this.tVdcMax.Text = "0.00";
            this.tVdcMax.TextChanged += new System.EventHandler(this.tVdcMax_TextChanged_1);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.Location = new System.Drawing.Point(10, 90);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(86, 18);
            this.label25.TabIndex = 151;
            this.label25.Text = "VDC Min";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tvdcMin
            // 
            this.tvdcMin.BackColor = System.Drawing.SystemColors.Control;
            this.tvdcMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvdcMin.ForeColor = System.Drawing.Color.Red;
            this.tvdcMin.Location = new System.Drawing.Point(96, 88);
            this.tvdcMin.Name = "tvdcMin";
            this.tvdcMin.ReadOnly = true;
            this.tvdcMin.Size = new System.Drawing.Size(86, 23);
            this.tvdcMin.TabIndex = 150;
            this.tvdcMin.Text = "0.00";
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Blue;
            this.label8.Location = new System.Drawing.Point(202, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 18);
            this.label8.TabIndex = 149;
            this.label8.Text = "VAC";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tVac
            // 
            this.tVac.BackColor = System.Drawing.SystemColors.Control;
            this.tVac.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tVac.ForeColor = System.Drawing.Color.Red;
            this.tVac.Location = new System.Drawing.Point(259, 18);
            this.tVac.Name = "tVac";
            this.tVac.ReadOnly = true;
            this.tVac.Size = new System.Drawing.Size(87, 23);
            this.tVac.TabIndex = 148;
            this.tVac.Text = "0.00";
            this.tVac.TextChanged += new System.EventHandler(this.tVac_TextChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(10, 67);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(86, 18);
            this.label9.TabIndex = 147;
            this.label9.Text = "VPC EqLz";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tvpcEq
            // 
            this.tvpcEq.BackColor = System.Drawing.Color.White;
            this.tvpcEq.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvpcEq.ForeColor = System.Drawing.Color.Red;
            this.tvpcEq.Location = new System.Drawing.Point(96, 65);
            this.tvpcEq.Name = "tvpcEq";
            this.tvpcEq.Size = new System.Drawing.Size(86, 23);
            this.tvpcEq.TabIndex = 146;
            this.tvpcEq.Text = "0.00";
            this.tvpcEq.TextChanged += new System.EventHandler(this.tvpcEq_TextChanged);
            this.tvpcEq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tvpcEq_KeyPress);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(10, 44);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 18);
            this.label11.TabIndex = 145;
            this.label11.Text = "VPC Float";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tvpcF
            // 
            this.tvpcF.BackColor = System.Drawing.Color.White;
            this.tvpcF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvpcF.ForeColor = System.Drawing.Color.Red;
            this.tvpcF.Location = new System.Drawing.Point(96, 42);
            this.tvpcF.Name = "tvpcF";
            this.tvpcF.Size = new System.Drawing.Size(86, 23);
            this.tvpcF.TabIndex = 144;
            this.tvpcF.Text = "0.00";
            this.tvpcF.TextChanged += new System.EventHandler(this.tvpcF_TextChanged);
            this.tvpcF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tvpcF_KeyPress);
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(38, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 18);
            this.label7.TabIndex = 143;
            this.label7.Text = "Cell #";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tCellN
            // 
            this.tCellN.BackColor = System.Drawing.Color.White;
            this.tCellN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCellN.ForeColor = System.Drawing.Color.Red;
            this.tCellN.Location = new System.Drawing.Point(96, 18);
            this.tCellN.Name = "tCellN";
            this.tCellN.Size = new System.Drawing.Size(86, 23);
            this.tCellN.TabIndex = 142;
            this.tCellN.Text = "0.00";
            this.tCellN.TextChanged += new System.EventHandler(this.tCellN_TextChanged);
            this.tCellN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tCellN_KeyPress);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lVcellMin_LA);
            this.groupBox3.Controls.Add(this.lVcellMin_NI);
            this.groupBox3.Controls.Add(this.lFLT_EQ_SEC);
            this.groupBox3.Controls.Add(this.lvpcE_LA);
            this.groupBox3.Controls.Add(this.lvpcF_LA);
            this.groupBox3.Controls.Add(this.lvpcE_NI);
            this.groupBox3.Controls.Add(this.lvpcF_NI);
            this.groupBox3.Controls.Add(this.lNBC_LA);
            this.groupBox3.Controls.Add(this.lNBC_NI);
            this.groupBox3.Location = new System.Drawing.Point(450, 301);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(58, 157);
            this.groupBox3.TabIndex = 140;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "coefs";
            this.groupBox3.Visible = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // lVcellMin_LA
            // 
            this.lVcellMin_LA.BackColor = System.Drawing.Color.Chocolate;
            this.lVcellMin_LA.ForeColor = System.Drawing.Color.Black;
            this.lVcellMin_LA.Location = new System.Drawing.Point(38, 120);
            this.lVcellMin_LA.Name = "lVcellMin_LA";
            this.lVcellMin_LA.Size = new System.Drawing.Size(10, 18);
            this.lVcellMin_LA.TabIndex = 148;
            // 
            // lVcellMin_NI
            // 
            this.lVcellMin_NI.BackColor = System.Drawing.Color.Chocolate;
            this.lVcellMin_NI.ForeColor = System.Drawing.Color.Black;
            this.lVcellMin_NI.Location = new System.Drawing.Point(19, 120);
            this.lVcellMin_NI.Name = "lVcellMin_NI";
            this.lVcellMin_NI.Size = new System.Drawing.Size(10, 18);
            this.lVcellMin_NI.TabIndex = 147;
            // 
            // lFLT_EQ_SEC
            // 
            this.lFLT_EQ_SEC.BackColor = System.Drawing.Color.Chocolate;
            this.lFLT_EQ_SEC.ForeColor = System.Drawing.Color.Black;
            this.lFLT_EQ_SEC.Location = new System.Drawing.Point(19, 92);
            this.lFLT_EQ_SEC.Name = "lFLT_EQ_SEC";
            this.lFLT_EQ_SEC.Size = new System.Drawing.Size(19, 19);
            this.lFLT_EQ_SEC.TabIndex = 146;
            // 
            // lvpcE_LA
            // 
            this.lvpcE_LA.BackColor = System.Drawing.Color.Chocolate;
            this.lvpcE_LA.ForeColor = System.Drawing.Color.Black;
            this.lvpcE_LA.Location = new System.Drawing.Point(38, 74);
            this.lvpcE_LA.Name = "lvpcE_LA";
            this.lvpcE_LA.Size = new System.Drawing.Size(10, 18);
            this.lvpcE_LA.TabIndex = 145;
            // 
            // lvpcF_LA
            // 
            this.lvpcF_LA.BackColor = System.Drawing.Color.Chocolate;
            this.lvpcF_LA.ForeColor = System.Drawing.Color.Black;
            this.lvpcF_LA.Location = new System.Drawing.Point(10, 74);
            this.lvpcF_LA.Name = "lvpcF_LA";
            this.lvpcF_LA.Size = new System.Drawing.Size(9, 18);
            this.lvpcF_LA.TabIndex = 144;
            // 
            // lvpcE_NI
            // 
            this.lvpcE_NI.BackColor = System.Drawing.Color.Chocolate;
            this.lvpcE_NI.ForeColor = System.Drawing.Color.Black;
            this.lvpcE_NI.Location = new System.Drawing.Point(48, 46);
            this.lvpcE_NI.Name = "lvpcE_NI";
            this.lvpcE_NI.Size = new System.Drawing.Size(29, 19);
            this.lvpcE_NI.TabIndex = 143;
            // 
            // lvpcF_NI
            // 
            this.lvpcF_NI.BackColor = System.Drawing.Color.Chocolate;
            this.lvpcF_NI.ForeColor = System.Drawing.Color.Black;
            this.lvpcF_NI.Location = new System.Drawing.Point(10, 46);
            this.lvpcF_NI.Name = "lvpcF_NI";
            this.lvpcF_NI.Size = new System.Drawing.Size(28, 19);
            this.lvpcF_NI.TabIndex = 142;
            // 
            // lNBC_LA
            // 
            this.lNBC_LA.BackColor = System.Drawing.Color.Chocolate;
            this.lNBC_LA.ForeColor = System.Drawing.Color.Black;
            this.lNBC_LA.Location = new System.Drawing.Point(48, 18);
            this.lNBC_LA.Name = "lNBC_LA";
            this.lNBC_LA.Size = new System.Drawing.Size(29, 19);
            this.lNBC_LA.TabIndex = 141;
            // 
            // lNBC_NI
            // 
            this.lNBC_NI.BackColor = System.Drawing.Color.Chocolate;
            this.lNBC_NI.ForeColor = System.Drawing.Color.Black;
            this.lNBC_NI.Location = new System.Drawing.Point(10, 18);
            this.lNBC_NI.Name = "lNBC_NI";
            this.lNBC_NI.Size = new System.Drawing.Size(28, 19);
            this.lNBC_NI.TabIndex = 140;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.groupBox9);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.groupBox8);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.optAuto);
            this.groupBox2.Controls.Add(this.lmin);
            this.groupBox2.Controls.Add(this.lxxx);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.cbIdctmp);
            this.groupBox2.Controls.Add(this.cbXXX);
            this.groupBox2.Controls.Add(this.tVDC);
            this.groupBox2.Controls.Add(this.tPhs);
            this.groupBox2.Controls.Add(this.cbVdc);
            this.groupBox2.Controls.Add(this.tPxx);
            this.groupBox2.Controls.Add(this.cbPxx);
            this.groupBox2.Controls.Add(this.cbPhs);
            this.groupBox2.Controls.Add(this.TIDC);
            this.groupBox2.Controls.Add(this.cbIdc);
            this.groupBox2.Location = new System.Drawing.Point(10, 9);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(430, 91);
            this.groupBox2.TabIndex = 138;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Charger Model";
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter_1);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.tPxxQty);
            this.groupBox9.Enabled = false;
            this.groupBox9.Location = new System.Drawing.Point(122, 165);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(144, 37);
            this.groupBox9.TabIndex = 209;
            this.groupBox9.TabStop = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkRed;
            this.label12.Location = new System.Drawing.Point(10, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 19);
            this.label12.TabIndex = 191;
            this.label12.Text = "QTY:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tPxxQty
            // 
            this.tPxxQty.BackColor = System.Drawing.SystemColors.Control;
            this.tPxxQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPxxQty.Location = new System.Drawing.Point(58, 8);
            this.tPxxQty.MaxLength = 2;
            this.tPxxQty.Name = "tPxxQty";
            this.tPxxQty.ReadOnly = true;
            this.tPxxQty.Size = new System.Drawing.Size(76, 26);
            this.tPxxQty.TabIndex = 190;
            this.tPxxQty.Text = "1";
            this.tPxxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tLTime);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.MaxLT);
            this.groupBox1.Controls.Add(this.ll);
            this.groupBox1.Controls.Add(this.minLT);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(122, 110);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(144, 50);
            this.groupBox1.TabIndex = 207;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lead Time:";
            // 
            // tLTime
            // 
            this.tLTime.BackColor = System.Drawing.Color.Lime;
            this.tLTime.ForeColor = System.Drawing.Color.Black;
            this.tLTime.Location = new System.Drawing.Point(48, 9);
            this.tLTime.Name = "tLTime";
            this.tLTime.Size = new System.Drawing.Size(67, 19);
            this.tLTime.TabIndex = 196;
            this.tLTime.Visible = false;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DarkRed;
            this.label16.Location = new System.Drawing.Point(67, 25);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(39, 19);
            this.label16.TabIndex = 195;
            this.label16.Text = "Max";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MaxLT
            // 
            this.MaxLT.BackColor = System.Drawing.Color.Lavender;
            this.MaxLT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxLT.Location = new System.Drawing.Point(106, 21);
            this.MaxLT.MaxLength = 2;
            this.MaxLT.Name = "MaxLT";
            this.MaxLT.Size = new System.Drawing.Size(28, 26);
            this.MaxLT.TabIndex = 194;
            this.MaxLT.Tag = "";
            this.MaxLT.Text = "06";
            this.MaxLT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.MaxLT.TextChanged += new System.EventHandler(this.MaxLT_TextChanged);
            // 
            // ll
            // 
            this.ll.BackColor = System.Drawing.Color.Transparent;
            this.ll.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ll.ForeColor = System.Drawing.Color.DarkRed;
            this.ll.Location = new System.Drawing.Point(0, 25);
            this.ll.Name = "ll";
            this.ll.Size = new System.Drawing.Size(38, 19);
            this.ll.TabIndex = 193;
            this.ll.Text = "Min";
            this.ll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // minLT
            // 
            this.minLT.BackColor = System.Drawing.Color.Lavender;
            this.minLT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minLT.Location = new System.Drawing.Point(38, 21);
            this.minLT.MaxLength = 2;
            this.minLT.Name = "minLT";
            this.minLT.Size = new System.Drawing.Size(29, 26);
            this.minLT.TabIndex = 192;
            this.minLT.Tag = "";
            this.minLT.Text = "04";
            this.minLT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minLT.TextChanged += new System.EventHandler(this.minLT_TextChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lhrtZMRK);
            this.groupBox8.Controls.Add(this.opt400);
            this.groupBox8.Controls.Add(this.lhrtz);
            this.groupBox8.Controls.Add(this.opt50);
            this.groupBox8.Controls.Add(this.opt60);
            this.groupBox8.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox8.Location = new System.Drawing.Point(266, 156);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(154, 46);
            this.groupBox8.TabIndex = 202;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "HertZ";
            // 
            // lhrtZMRK
            // 
            this.lhrtZMRK.BackColor = System.Drawing.Color.Lime;
            this.lhrtZMRK.ForeColor = System.Drawing.Color.Black;
            this.lhrtZMRK.Location = new System.Drawing.Point(96, 0);
            this.lhrtZMRK.Name = "lhrtZMRK";
            this.lhrtZMRK.Size = new System.Drawing.Size(58, 18);
            this.lhrtZMRK.TabIndex = 122;
            this.lhrtZMRK.Text = "1";
            this.lhrtZMRK.Visible = false;
            // 
            // opt400
            // 
            this.opt400.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.opt400.ForeColor = System.Drawing.SystemColors.ControlText;
            this.opt400.Location = new System.Drawing.Point(103, 18);
            this.opt400.Name = "opt400";
            this.opt400.Size = new System.Drawing.Size(48, 19);
            this.opt400.TabIndex = 121;
            this.opt400.Text = "400";
            this.opt400.CheckedChanged += new System.EventHandler(this.opt400_CheckedChanged);
            // 
            // lhrtz
            // 
            this.lhrtz.BackColor = System.Drawing.Color.Lime;
            this.lhrtz.ForeColor = System.Drawing.Color.Black;
            this.lhrtz.Location = new System.Drawing.Point(38, 28);
            this.lhrtz.Name = "lhrtz";
            this.lhrtz.Size = new System.Drawing.Size(20, 18);
            this.lhrtz.TabIndex = 120;
            this.lhrtz.Text = "60";
            this.lhrtz.Visible = false;
            // 
            // opt50
            // 
            this.opt50.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.opt50.ForeColor = System.Drawing.SystemColors.ControlText;
            this.opt50.Location = new System.Drawing.Point(56, 18);
            this.opt50.Name = "opt50";
            this.opt50.Size = new System.Drawing.Size(39, 19);
            this.opt50.TabIndex = 118;
            this.opt50.Text = "50";
            this.opt50.CheckedChanged += new System.EventHandler(this.opt50_CheckedChanged);
            // 
            // opt60
            // 
            this.opt60.Checked = true;
            this.opt60.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.opt60.ForeColor = System.Drawing.SystemColors.ControlText;
            this.opt60.Location = new System.Drawing.Point(8, 18);
            this.opt60.Name = "opt60";
            this.opt60.Size = new System.Drawing.Size(39, 19);
            this.opt60.TabIndex = 117;
            this.opt60.TabStop = true;
            this.opt60.Text = "60";
            this.opt60.CheckedChanged += new System.EventHandler(this.opt60_CheckedChanged);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.optVrla);
            this.groupBox5.Controls.Add(this.lNA);
            this.groupBox5.Controls.Add(this.optLA);
            this.groupBox5.Controls.Add(this.optNi);
            this.groupBox5.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox5.Location = new System.Drawing.Point(17, 110);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(105, 92);
            this.groupBox5.TabIndex = 201;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Batteries";
            // 
            // optVrla
            // 
            this.optVrla.BackColor = System.Drawing.SystemColors.Control;
            this.optVrla.Checked = true;
            this.optVrla.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optVrla.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optVrla.Location = new System.Drawing.Point(10, 65);
            this.optVrla.Name = "optVrla";
            this.optVrla.Size = new System.Drawing.Size(67, 20);
            this.optVrla.TabIndex = 122;
            this.optVrla.TabStop = true;
            this.optVrla.Text = "VRLA";
            this.optVrla.UseVisualStyleBackColor = false;
            this.optVrla.CheckedChanged += new System.EventHandler(this.optVrla_CheckedChanged);
            // 
            // lNA
            // 
            this.lNA.BackColor = System.Drawing.Color.Lime;
            this.lNA.ForeColor = System.Drawing.Color.Black;
            this.lNA.Location = new System.Drawing.Point(86, 55);
            this.lNA.Name = "lNA";
            this.lNA.Size = new System.Drawing.Size(20, 19);
            this.lNA.TabIndex = 121;
            this.lNA.Text = "N";
            this.lNA.Visible = false;
            // 
            // optLA
            // 
            this.optLA.BackColor = System.Drawing.SystemColors.Control;
            this.optLA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optLA.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optLA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optLA.Location = new System.Drawing.Point(10, 18);
            this.optLA.Name = "optLA";
            this.optLA.Size = new System.Drawing.Size(86, 19);
            this.optLA.TabIndex = 118;
            this.optLA.Text = "Lead  Acid";
            this.optLA.UseVisualStyleBackColor = false;
            this.optLA.CheckedChanged += new System.EventHandler(this.optLA_CheckedChanged);
            // 
            // optNi
            // 
            this.optNi.BackColor = System.Drawing.SystemColors.Control;
            this.optNi.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optNi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optNi.Location = new System.Drawing.Point(10, 42);
            this.optNi.Name = "optNi";
            this.optNi.Size = new System.Drawing.Size(67, 20);
            this.optNi.TabIndex = 117;
            this.optNi.Text = "Ni-Cad";
            this.optNi.UseVisualStyleBackColor = false;
            this.optNi.CheckedChanged += new System.EventHandler(this.optNi_CheckedChanged);
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lFV);
            this.groupBox6.Controls.Add(this.optVar);
            this.groupBox6.Controls.Add(this.optFx);
            this.groupBox6.ForeColor = System.Drawing.Color.Maroon;
            this.groupBox6.Location = new System.Drawing.Point(266, 110);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(154, 46);
            this.groupBox6.TabIndex = 200;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Charger type";
            // 
            // lFV
            // 
            this.lFV.BackColor = System.Drawing.Color.Lime;
            this.lFV.ForeColor = System.Drawing.Color.Black;
            this.lFV.Location = new System.Drawing.Point(67, 18);
            this.lFV.Name = "lFV";
            this.lFV.Size = new System.Drawing.Size(19, 19);
            this.lFV.TabIndex = 120;
            this.lFV.Text = "F";
            this.lFV.Visible = false;
            // 
            // optVar
            // 
            this.optVar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optVar.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optVar.Location = new System.Drawing.Point(67, 18);
            this.optVar.Name = "optVar";
            this.optVar.Size = new System.Drawing.Size(77, 21);
            this.optVar.TabIndex = 118;
            this.optVar.Text = "Variable";
            this.optVar.CheckedChanged += new System.EventHandler(this.optVar_CheckedChanged);
            // 
            // optFx
            // 
            this.optFx.Checked = true;
            this.optFx.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optFx.ForeColor = System.Drawing.SystemColors.ControlText;
            this.optFx.Location = new System.Drawing.Point(10, 18);
            this.optFx.Name = "optFx";
            this.optFx.Size = new System.Drawing.Size(57, 19);
            this.optFx.TabIndex = 117;
            this.optFx.TabStop = true;
            this.optFx.Text = "Fixed";
            this.optFx.CheckedChanged += new System.EventHandler(this.optFx_CheckedChanged);
            // 
            // optAuto
            // 
            this.optAuto.Checked = true;
            this.optAuto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optAuto.Location = new System.Drawing.Point(247, 137);
            this.optAuto.Name = "optAuto";
            this.optAuto.Size = new System.Drawing.Size(48, 19);
            this.optAuto.TabIndex = 168;
            this.optAuto.TabStop = true;
            this.optAuto.Text = "Automatic";
            this.optAuto.Visible = false;
            // 
            // lmin
            // 
            this.lmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmin.ForeColor = System.Drawing.Color.Black;
            this.lmin.Location = new System.Drawing.Point(334, 47);
            this.lmin.Name = "lmin";
            this.lmin.Size = new System.Drawing.Size(9, 23);
            this.lmin.TabIndex = 167;
            this.lmin.Text = "-";
            this.lmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lmin.Visible = false;
            // 
            // lxxx
            // 
            this.lxxx.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lxxx.Location = new System.Drawing.Point(343, 29);
            this.lxxx.Name = "lxxx";
            this.lxxx.Size = new System.Drawing.Size(67, 18);
            this.lxxx.TabIndex = 166;
            this.lxxx.Text = "XXX";
            this.lxxx.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lxxx.Visible = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(257, 47);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(9, 23);
            this.label6.TabIndex = 164;
            this.label6.Text = "-";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(180, 47);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(10, 23);
            this.label5.TabIndex = 163;
            this.label5.Text = "-";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(122, 47);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(10, 23);
            this.label4.TabIndex = 162;
            this.label4.Text = "-";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(266, 20);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 27);
            this.label3.TabIndex = 161;
            this.label3.Text = "IDC";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(199, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 18);
            this.label2.TabIndex = 159;
            this.label2.Text = "VDC";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(132, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 18);
            this.label1.TabIndex = 157;
            this.label1.Text = "PHS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(36, 29);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(84, 18);
            this.label22.TabIndex = 155;
            this.label22.Text = "PXXXX";
            this.label22.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cbIdctmp
            // 
            this.cbIdctmp.BackColor = System.Drawing.Color.Blue;
            this.cbIdctmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdctmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIdctmp.ForeColor = System.Drawing.Color.White;
            this.cbIdctmp.ItemHeight = 20;
            this.cbIdctmp.Items.AddRange(new object[] {
            "6",
            "12"});
            this.cbIdctmp.Location = new System.Drawing.Point(343, 20);
            this.cbIdctmp.Name = "cbIdctmp";
            this.cbIdctmp.Size = new System.Drawing.Size(67, 28);
            this.cbIdctmp.TabIndex = 210;
            this.cbIdctmp.Visible = false;
            this.cbIdctmp.SelectedIndexChanged += new System.EventHandler(this.cbIdctmp_SelectedIndexChanged);
            // 
            // cbXXX
            // 
            this.cbXXX.BackColor = System.Drawing.Color.Lavender;
            this.cbXXX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbXXX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbXXX.ItemHeight = 20;
            this.cbXXX.Items.AddRange(new object[] {
            "A",
            "WK",
            "D",
            "2P",
            "SS"});
            this.cbXXX.Location = new System.Drawing.Point(343, 47);
            this.cbXXX.Name = "cbXXX";
            this.cbXXX.Size = new System.Drawing.Size(67, 28);
            this.cbXXX.TabIndex = 165;
            this.cbXXX.Visible = false;
            this.cbXXX.SelectedIndexChanged += new System.EventHandler(this.cbXXX_SelectedIndexChanged_1);
            // 
            // tVDC
            // 
            this.tVDC.BackColor = System.Drawing.Color.Cornsilk;
            this.tVDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tVDC.ForeColor = System.Drawing.Color.Black;
            this.tVDC.Location = new System.Drawing.Point(190, 47);
            this.tVDC.MaxLength = 2;
            this.tVDC.Name = "tVDC";
            this.tVDC.ReadOnly = true;
            this.tVDC.Size = new System.Drawing.Size(67, 26);
            this.tVDC.TabIndex = 211;
            this.tVDC.Text = "1";
            this.tVDC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tPhs
            // 
            this.tPhs.BackColor = System.Drawing.Color.Cornsilk;
            this.tPhs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPhs.ForeColor = System.Drawing.Color.Black;
            this.tPhs.Location = new System.Drawing.Point(132, 47);
            this.tPhs.MaxLength = 2;
            this.tPhs.Name = "tPhs";
            this.tPhs.ReadOnly = true;
            this.tPhs.Size = new System.Drawing.Size(50, 26);
            this.tPhs.TabIndex = 214;
            this.tPhs.Text = "1";
            this.tPhs.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbVdc
            // 
            this.cbVdc.BackColor = System.Drawing.Color.Lavender;
            this.cbVdc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVdc.ItemHeight = 20;
            this.cbVdc.Location = new System.Drawing.Point(190, 46);
            this.cbVdc.MaxDropDownItems = 20;
            this.cbVdc.Name = "cbVdc";
            this.cbVdc.Size = new System.Drawing.Size(67, 28);
            this.cbVdc.TabIndex = 158;
            this.cbVdc.Visible = false;
            this.cbVdc.SelectedIndexChanged += new System.EventHandler(this.cbVdc_SelectedValueChanged);
            this.cbVdc.SelectionChangeCommitted += new System.EventHandler(this.cbVdc_SelectionChangeCommitted);
            this.cbVdc.SelectedValueChanged += new System.EventHandler(this.cbVdc_SelectedValueChanged_1);
            this.cbVdc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbVdc_KeyUp);
            // 
            // tPxx
            // 
            this.tPxx.BackColor = System.Drawing.Color.Cornsilk;
            this.tPxx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPxx.ForeColor = System.Drawing.Color.Black;
            this.tPxx.Location = new System.Drawing.Point(7, 47);
            this.tPxx.MaxLength = 2;
            this.tPxx.Name = "tPxx";
            this.tPxx.ReadOnly = true;
            this.tPxx.Size = new System.Drawing.Size(115, 26);
            this.tPxx.TabIndex = 213;
            this.tPxx.Text = "1";
            this.tPxx.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbPxx
            // 
            this.cbPxx.BackColor = System.Drawing.Color.Lavender;
            this.cbPxx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPxx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPxx.ItemHeight = 20;
            this.cbPxx.Location = new System.Drawing.Point(7, 46);
            this.cbPxx.Name = "cbPxx";
            this.cbPxx.Size = new System.Drawing.Size(115, 28);
            this.cbPxx.TabIndex = 154;
            this.cbPxx.Visible = false;
            this.cbPxx.SelectedIndexChanged += new System.EventHandler(this.cbPxx_SelectedIndexChanged);
            this.cbPxx.SelectedValueChanged += new System.EventHandler(this.cbPxx_SelectedValueChanged);
            // 
            // cbPhs
            // 
            this.cbPhs.BackColor = System.Drawing.Color.Lavender;
            this.cbPhs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPhs.ItemHeight = 20;
            this.cbPhs.Items.AddRange(new object[] {
            "1",
            "3"});
            this.cbPhs.Location = new System.Drawing.Point(132, 46);
            this.cbPhs.Name = "cbPhs";
            this.cbPhs.Size = new System.Drawing.Size(48, 28);
            this.cbPhs.TabIndex = 156;
            this.cbPhs.Visible = false;
            this.cbPhs.SelectedIndexChanged += new System.EventHandler(this.cbPhs_SelectedIndexChanged);
            this.cbPhs.SelectedValueChanged += new System.EventHandler(this.cbPhs_SelectedValueChanged_1);
            // 
            // TIDC
            // 
            this.TIDC.BackColor = System.Drawing.Color.Cornsilk;
            this.TIDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TIDC.ForeColor = System.Drawing.Color.Black;
            this.TIDC.Location = new System.Drawing.Point(266, 47);
            this.TIDC.MaxLength = 2;
            this.TIDC.Name = "TIDC";
            this.TIDC.ReadOnly = true;
            this.TIDC.Size = new System.Drawing.Size(68, 26);
            this.TIDC.TabIndex = 212;
            this.TIDC.Text = "1";
            this.TIDC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbIdc
            // 
            this.cbIdc.BackColor = System.Drawing.Color.Lavender;
            this.cbIdc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIdc.ItemHeight = 20;
            this.cbIdc.Location = new System.Drawing.Point(266, 46);
            this.cbIdc.Name = "cbIdc";
            this.cbIdc.Size = new System.Drawing.Size(68, 28);
            this.cbIdc.TabIndex = 160;
            this.cbIdc.Visible = false;
            this.cbIdc.SelectedIndexChanged += new System.EventHandler(this.cbIdc_SelectedValueChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(992, 100);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(58, 47);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 179;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Tag = "";
            this.pictureBox2.Visible = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.DragOver += new System.Windows.Forms.DragEventHandler(this.pictureBox2_DragOver);
            this.pictureBox2.MouseHover += new System.EventHandler(this.pictureBox2_MouseHover);
            // 
            // lnkAlarm
            // 
            this.lnkAlarm.Enabled = false;
            this.lnkAlarm.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAlarm.Location = new System.Drawing.Point(890, 105);
            this.lnkAlarm.Name = "lnkAlarm";
            this.lnkAlarm.Size = new System.Drawing.Size(106, 37);
            this.lnkAlarm.TabIndex = 178;
            this.lnkAlarm.TabStop = true;
            this.lnkAlarm.Text = "ALARMS";
            this.lnkAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkAlarm.Visible = false;
            this.lnkAlarm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAlarm_LinkClicked);
            // 
            // LnkValidate
            // 
            this.LnkValidate.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkValidate.Location = new System.Drawing.Point(893, 58);
            this.LnkValidate.Name = "LnkValidate";
            this.LnkValidate.Size = new System.Drawing.Size(175, 37);
            this.LnkValidate.TabIndex = 176;
            this.LnkValidate.TabStop = true;
            this.LnkValidate.Text = "Recalculation";
            this.LnkValidate.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.LnkValidate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkValidate_LinkClicked);
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.lvCoef);
            this.groupBox14.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox14.Location = new System.Drawing.Point(3, 18);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(286, 449);
            this.groupBox14.TabIndex = 163;
            this.groupBox14.TabStop = false;
            // 
            // lvCoef
            // 
            this.lvCoef.BackColor = System.Drawing.Color.Azure;
            this.lvCoef.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CoefN,
            this.V});
            this.lvCoef.ContextMenu = this.EdDelRenMnu;
            this.lvCoef.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCoef.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvCoef.FullRowSelect = true;
            this.lvCoef.GridLines = true;
            this.lvCoef.HideSelection = false;
            this.lvCoef.Location = new System.Drawing.Point(3, 18);
            this.lvCoef.Name = "lvCoef";
            this.lvCoef.Size = new System.Drawing.Size(280, 428);
            this.lvCoef.TabIndex = 104;
            this.lvCoef.UseCompatibleStateImageBehavior = false;
            this.lvCoef.View = System.Windows.Forms.View.Details;
            // 
            // CoefN
            // 
            this.CoefN.Text = "Coeficient";
            this.CoefN.Width = 96;
            // 
            // V
            // 
            this.V.Text = "Value";
            this.V.Width = 112;
            // 
            // groupBox13
            // 
            this.groupBox13.Controls.Add(this.LvTV);
            this.groupBox13.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox13.ForeColor = System.Drawing.Color.Red;
            this.groupBox13.Location = new System.Drawing.Point(289, 18);
            this.groupBox13.Name = "groupBox13";
            this.groupBox13.Size = new System.Drawing.Size(522, 449);
            this.groupBox13.TabIndex = 162;
            this.groupBox13.TabStop = false;
            // 
            // LvTV
            // 
            this.LvTV.BackColor = System.Drawing.Color.OldLace;
            this.LvTV.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.rien,
            this.TV,
            this.TVV,
            this.frml});
            this.LvTV.ContextMenu = this.EdDelRenMnu;
            this.LvTV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LvTV.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LvTV.ForeColor = System.Drawing.Color.Blue;
            this.LvTV.FullRowSelect = true;
            this.LvTV.GridLines = true;
            this.LvTV.HideSelection = false;
            this.LvTV.Location = new System.Drawing.Point(3, 18);
            this.LvTV.Name = "LvTV";
            this.LvTV.Size = new System.Drawing.Size(516, 428);
            this.LvTV.TabIndex = 104;
            this.LvTV.UseCompatibleStateImageBehavior = false;
            this.LvTV.View = System.Windows.Forms.View.Details;
            this.LvTV.SelectedIndexChanged += new System.EventHandler(this.LvTV_SelectedIndexChanged);
            // 
            // rien
            // 
            this.rien.Text = "";
            this.rien.Width = 0;
            // 
            // TV
            // 
            this.TV.Text = ((string)(configurationAppSettings.GetValue("TV.Text", typeof(string))));
            this.TV.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TV.Width = 122;
            // 
            // TVV
            // 
            this.TVV.Text = "Value";
            this.TVV.Width = 292;
            // 
            // frml
            // 
            this.frml.Text = "Formulas";
            this.frml.Width = 0;
            // 
            // tModif_CH
            // 
            this.tModif_CH.BackColor = System.Drawing.Color.Gainsboro;
            this.tModif_CH.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tModif_CH.Location = new System.Drawing.Point(19, 9);
            this.tModif_CH.MaxLength = 0;
            this.tModif_CH.Name = "tModif_CH";
            this.tModif_CH.ReadOnly = true;
            this.tModif_CH.Size = new System.Drawing.Size(1719, 26);
            this.tModif_CH.TabIndex = 288;
            // 
            // lvDefOption
            // 
            this.lvDefOption.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvDefOption.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.shw,
            this.RefCpt,
            this.Desc,
            this.Qty,
            this.UPrice,
            this.Ext,
            this.DlvDate,
            this.cat1,
            this.cat2,
            this.cat3,
            this.cptRef,
            this.cptPartnb});
            this.lvDefOption.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvDefOption.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvDefOption.FullRowSelect = true;
            this.lvDefOption.GridLines = true;
            this.lvDefOption.HideSelection = false;
            this.lvDefOption.Location = new System.Drawing.Point(3, 18);
            this.lvDefOption.Name = "lvDefOption";
            this.lvDefOption.Size = new System.Drawing.Size(1434, 449);
            this.lvDefOption.TabIndex = 102;
            this.lvDefOption.UseCompatibleStateImageBehavior = false;
            this.lvDefOption.View = System.Windows.Forms.View.Details;
            this.lvDefOption.SelectedIndexChanged += new System.EventHandler(this.lvDefOption_SelectedIndexChanged);
            this.lvDefOption.DoubleClick += new System.EventHandler(this.lvDefOption_DoubleClick);
            // 
            // shw
            // 
            this.shw.Text = "Show";
            this.shw.Width = 0;
            // 
            // RefCpt
            // 
            this.RefCpt.Text = "Option Ref";
            this.RefCpt.Width = 0;
            // 
            // Desc
            // 
            this.Desc.Text = "Description";
            this.Desc.Width = 741;
            // 
            // Qty
            // 
            this.Qty.Text = "Qty";
            this.Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Qty.Width = 0;
            // 
            // UPrice
            // 
            this.UPrice.Text = "U.Price";
            this.UPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UPrice.Width = 0;
            // 
            // Ext
            // 
            this.Ext.Text = "Extension";
            this.Ext.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Ext.Width = 0;
            // 
            // DlvDate
            // 
            this.DlvDate.Text = "L.Time";
            this.DlvDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DlvDate.Width = 0;
            // 
            // cat1
            // 
            this.cat1.Text = "Cat #1";
            this.cat1.Width = 0;
            // 
            // cat2
            // 
            this.cat2.Text = "Cat #2";
            this.cat2.Width = 0;
            // 
            // cat3
            // 
            this.cat3.Text = "Cat #3";
            this.cat3.Width = 0;
            // 
            // cptRef
            // 
            this.cptRef.Text = "";
            this.cptRef.Width = 100;
            // 
            // cptPartnb
            // 
            this.cptPartnb.Text = "";
            this.cptPartnb.Width = 100;
            // 
            // grp1
            // 
            this.grp1.Controls.Add(this.tModif_CHNew);
            this.grp1.Controls.Add(this.tModif_CH);
            this.grp1.Controls.Add(this.lmdel);
            this.grp1.Controls.Add(this.groupBox11);
            this.grp1.Controls.Add(this.lALRM);
            this.grp1.Controls.Add(this.linkLabel1);
            this.grp1.Controls.Add(this.groupBox10);
            this.grp1.Controls.Add(this.lDescc);
            this.grp1.Controls.Add(this.lRiple);
            this.grp1.Controls.Add(this.lSave);
            this.grp1.Controls.Add(this.t1);
            this.grp1.Controls.Add(this.t2);
            this.grp1.Controls.Add(this.button2);
            this.grp1.Controls.Add(this.lNcelCoef);
            this.grp1.Controls.Add(this.label18);
            this.grp1.Controls.Add(this.lcptName);
            this.grp1.Controls.Add(this.lCost);
            this.grp1.Controls.Add(this.lChrgREF);
            this.grp1.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp1.Location = new System.Drawing.Point(0, 164);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(1460, 66);
            this.grp1.TabIndex = 103;
            this.grp1.TabStop = false;
            this.grp1.Visible = false;
            this.grp1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // tModif_CHNew
            // 
            this.tModif_CHNew.BackColor = System.Drawing.Color.Lavender;
            this.tModif_CHNew.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tModif_CHNew.Location = new System.Drawing.Point(19, 35);
            this.tModif_CHNew.MaxLength = 0;
            this.tModif_CHNew.Name = "tModif_CHNew";
            this.tModif_CHNew.Size = new System.Drawing.Size(1719, 26);
            this.tModif_CHNew.TabIndex = 296;
            this.tModif_CHNew.TextChanged += new System.EventHandler(this.tModif_CHNew_TextChanged);
            // 
            // lmdel
            // 
            this.lmdel.BackColor = System.Drawing.Color.Lime;
            this.lmdel.ForeColor = System.Drawing.Color.Black;
            this.lmdel.Location = new System.Drawing.Point(346, 9);
            this.lmdel.Name = "lmdel";
            this.lmdel.Size = new System.Drawing.Size(57, 28);
            this.lmdel.TabIndex = 288;
            this.lmdel.Visible = false;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.cbVCS);
            this.groupBox11.Controls.Add(this.button3);
            this.groupBox11.Controls.Add(this.tSig);
            this.groupBox11.Controls.Add(this.label10);
            this.groupBox11.Controls.Add(this.button1);
            this.groupBox11.Controls.Add(this.tdbl);
            this.groupBox11.Controls.Add(this.label30);
            this.groupBox11.Controls.Add(this.label29);
            this.groupBox11.Location = new System.Drawing.Point(19, 65);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(999, 55);
            this.groupBox11.TabIndex = 295;
            this.groupBox11.TabStop = false;
            this.groupBox11.Text = "groupBox11";
            // 
            // cbVCS
            // 
            this.cbVCS.BackColor = System.Drawing.Color.Lavender;
            this.cbVCS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVCS.ItemHeight = 20;
            this.cbVCS.Location = new System.Drawing.Point(86, 9);
            this.cbVCS.Name = "cbVCS";
            this.cbVCS.Size = new System.Drawing.Size(135, 28);
            this.cbVCS.TabIndex = 134;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(691, 9);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(48, 28);
            this.button3.TabIndex = 291;
            this.button3.Text = "===>";
            this.button3.Click += new System.EventHandler(this.button3_Click_2);
            // 
            // tSig
            // 
            this.tSig.BackColor = System.Drawing.Color.Lavender;
            this.tSig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSig.Location = new System.Drawing.Point(605, 9);
            this.tSig.Name = "tSig";
            this.tSig.Size = new System.Drawing.Size(77, 23);
            this.tSig.TabIndex = 290;
            this.tSig.TextChanged += new System.EventHandler(this.value_TextChanged);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.White;
            this.label10.Location = new System.Drawing.Point(269, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(230, 37);
            this.label10.TabIndex = 130;
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(221, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 26);
            this.button1.TabIndex = 129;
            this.button1.Text = "===>";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // tdbl
            // 
            this.tdbl.BackColor = System.Drawing.Color.Lavender;
            this.tdbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tdbl.Location = new System.Drawing.Point(528, 9);
            this.tdbl.Name = "tdbl";
            this.tdbl.Size = new System.Drawing.Size(77, 23);
            this.tdbl.TabIndex = 289;
            this.tdbl.TextChanged += new System.EventHandler(this.tdbl_TextChanged);
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.OliveDrab;
            this.label30.Location = new System.Drawing.Point(874, 9);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(115, 28);
            this.label30.TabIndex = 293;
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.OliveDrab;
            this.label29.Location = new System.Drawing.Point(749, 9);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(115, 28);
            this.label29.TabIndex = 292;
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lALRM
            // 
            this.lALRM.BackColor = System.Drawing.Color.Lime;
            this.lALRM.ForeColor = System.Drawing.Color.Black;
            this.lALRM.Location = new System.Drawing.Point(432, 9);
            this.lALRM.Name = "lALRM";
            this.lALRM.Size = new System.Drawing.Size(19, 19);
            this.lALRM.TabIndex = 288;
            this.lALRM.Text = "N";
            this.lALRM.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(605, 32);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(86, 19);
            this.linkLabel1.TabIndex = 181;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Eq/Alarms";
            this.linkLabel1.Visible = false;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.pictureBox8);
            this.groupBox10.Controls.Add(this.label15);
            this.groupBox10.Controls.Add(this.tRef);
            this.groupBox10.Controls.Add(this.label48);
            this.groupBox10.Controls.Add(this.tExt);
            this.groupBox10.Controls.Add(this.label44);
            this.groupBox10.Controls.Add(this.tdesc);
            this.groupBox10.Controls.Add(this.label43);
            this.groupBox10.Controls.Add(this.tLT);
            this.groupBox10.Controls.Add(this.ChngCancel);
            this.groupBox10.Controls.Add(this.btnOKchng);
            this.groupBox10.Controls.Add(this.label42);
            this.groupBox10.Controls.Add(this.tUprice);
            this.groupBox10.Controls.Add(this.label28);
            this.groupBox10.Controls.Add(this.tqty);
            this.groupBox10.Location = new System.Drawing.Point(19, 120);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(999, 65);
            this.groupBox10.TabIndex = 180;
            this.groupBox10.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(10, 37);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(76, 21);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 36;
            this.pictureBox8.TabStop = false;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(115, 18);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(67, 17);
            this.label15.TabIndex = 35;
            this.label15.Text = "Ref.";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tRef
            // 
            this.tRef.BackColor = System.Drawing.Color.Red;
            this.tRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tRef.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tRef.Location = new System.Drawing.Point(86, 37);
            this.tRef.Name = "tRef";
            this.tRef.Size = new System.Drawing.Size(116, 22);
            this.tRef.TabIndex = 34;
            this.tRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(730, 18);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(76, 18);
            this.label48.TabIndex = 33;
            this.label48.Text = "Extension";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tExt
            // 
            this.tExt.BackColor = System.Drawing.Color.Red;
            this.tExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tExt.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tExt.Location = new System.Drawing.Point(710, 37);
            this.tExt.Name = "tExt";
            this.tExt.ReadOnly = true;
            this.tExt.Size = new System.Drawing.Size(116, 22);
            this.tExt.TabIndex = 32;
            this.tExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(307, 18);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(99, 17);
            this.label44.TabIndex = 29;
            this.label44.Text = "Description";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tdesc
            // 
            this.tdesc.BackColor = System.Drawing.Color.Red;
            this.tdesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tdesc.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tdesc.Location = new System.Drawing.Point(202, 37);
            this.tdesc.Name = "tdesc";
            this.tdesc.Size = new System.Drawing.Size(374, 22);
            this.tdesc.TabIndex = 28;
            this.tdesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.SystemColors.Control;
            this.label43.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label43.Location = new System.Drawing.Point(826, 18);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(48, 18);
            this.label43.TabIndex = 27;
            this.label43.Text = "Ld Time";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tLT
            // 
            this.tLT.BackColor = System.Drawing.Color.Red;
            this.tLT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tLT.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tLT.Location = new System.Drawing.Point(826, 37);
            this.tLT.Name = "tLT";
            this.tLT.Size = new System.Drawing.Size(61, 22);
            this.tLT.TabIndex = 26;
            this.tLT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChngCancel
            // 
            this.ChngCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ChngCancel.Location = new System.Drawing.Point(893, 37);
            this.ChngCancel.Name = "ChngCancel";
            this.ChngCancel.Size = new System.Drawing.Size(57, 23);
            this.ChngCancel.TabIndex = 25;
            this.ChngCancel.Text = "&Cancel";
            this.ChngCancel.Click += new System.EventHandler(this.ChngCancel_Click);
            // 
            // btnOKchng
            // 
            this.btnOKchng.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOKchng.Location = new System.Drawing.Point(893, 9);
            this.btnOKchng.Name = "btnOKchng";
            this.btnOKchng.Size = new System.Drawing.Size(57, 23);
            this.btnOKchng.TabIndex = 24;
            this.btnOKchng.Text = "&Save";
            this.btnOKchng.Click += new System.EventHandler(this.btnOKchng_Click);
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(643, 18);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(69, 18);
            this.label42.TabIndex = 22;
            this.label42.Text = "Unit Price";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tUprice
            // 
            this.tUprice.BackColor = System.Drawing.Color.Red;
            this.tUprice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tUprice.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tUprice.Location = new System.Drawing.Point(643, 37);
            this.tUprice.Name = "tUprice";
            this.tUprice.Size = new System.Drawing.Size(67, 22);
            this.tUprice.TabIndex = 20;
            this.tUprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tUprice.TextChanged += new System.EventHandler(this.tUprice_TextChanged);
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(586, 18);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(36, 18);
            this.label28.TabIndex = 19;
            this.label28.Text = "Qty";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tqty
            // 
            this.tqty.BackColor = System.Drawing.Color.Red;
            this.tqty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tqty.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tqty.Location = new System.Drawing.Point(576, 37);
            this.tqty.Name = "tqty";
            this.tqty.Size = new System.Drawing.Size(67, 22);
            this.tqty.TabIndex = 17;
            this.tqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tqty.TextChanged += new System.EventHandler(this.tqty_TextChanged);
            // 
            // lDescc
            // 
            this.lDescc.BackColor = System.Drawing.SystemColors.Control;
            this.lDescc.ForeColor = System.Drawing.Color.Brown;
            this.lDescc.Location = new System.Drawing.Point(989, 18);
            this.lDescc.Name = "lDescc";
            this.lDescc.Size = new System.Drawing.Size(96, 28);
            this.lDescc.TabIndex = 174;
            this.lDescc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lDescc.Visible = false;
            // 
            // lRiple
            // 
            this.lRiple.BackColor = System.Drawing.Color.LawnGreen;
            this.lRiple.Location = new System.Drawing.Point(730, 9);
            this.lRiple.Name = "lRiple";
            this.lRiple.Size = new System.Drawing.Size(57, 19);
            this.lRiple.TabIndex = 160;
            this.lRiple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lRiple.Visible = false;
            // 
            // lSave
            // 
            this.lSave.BackColor = System.Drawing.Color.Lime;
            this.lSave.ForeColor = System.Drawing.Color.Black;
            this.lSave.Location = new System.Drawing.Point(797, 9);
            this.lSave.Name = "lSave";
            this.lSave.Size = new System.Drawing.Size(19, 19);
            this.lSave.TabIndex = 159;
            this.lSave.Text = "N";
            this.lSave.Visible = false;
            // 
            // t1
            // 
            this.t1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.t1.Location = new System.Drawing.Point(240, 46);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(29, 19);
            this.t1.TabIndex = 139;
            this.t1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.t1.Visible = false;
            // 
            // t2
            // 
            this.t2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.t2.Location = new System.Drawing.Point(202, 9);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(28, 37);
            this.t2.TabIndex = 138;
            this.t2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.t2.Visible = false;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(710, 46);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(48, 19);
            this.button2.TabIndex = 137;
            this.button2.Text = "ALL";
            this.button2.Visible = false;
            // 
            // lNcelCoef
            // 
            this.lNcelCoef.BackColor = System.Drawing.Color.LemonChiffon;
            this.lNcelCoef.ForeColor = System.Drawing.Color.Black;
            this.lNcelCoef.Location = new System.Drawing.Point(144, 46);
            this.lNcelCoef.Name = "lNcelCoef";
            this.lNcelCoef.Size = new System.Drawing.Size(29, 19);
            this.lNcelCoef.TabIndex = 136;
            this.lNcelCoef.Text = "2";
            this.lNcelCoef.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lNcelCoef.Visible = false;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(422, -28);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(68, 28);
            this.label18.TabIndex = 135;
            this.label18.Text = "TECHNICAL VALUES:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lcptName
            // 
            this.lcptName.Location = new System.Drawing.Point(845, 18);
            this.lcptName.Name = "lcptName";
            this.lcptName.Size = new System.Drawing.Size(38, 28);
            this.lcptName.TabIndex = 128;
            this.lcptName.Text = "$$$$";
            this.lcptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lcptName.Visible = false;
            // 
            // lCost
            // 
            this.lCost.Location = new System.Drawing.Point(845, 37);
            this.lCost.Name = "lCost";
            this.lCost.Size = new System.Drawing.Size(38, 28);
            this.lCost.TabIndex = 125;
            this.lCost.Text = "$$$$";
            this.lCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lCost.Visible = false;
            // 
            // lChrgREF
            // 
            this.lChrgREF.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lChrgREF.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lChrgREF.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lChrgREF.ForeColor = System.Drawing.Color.Red;
            this.lChrgREF.Location = new System.Drawing.Point(1056, 28);
            this.lChrgREF.Name = "lChrgREF";
            this.lChrgREF.Size = new System.Drawing.Size(77, 27);
            this.lChrgREF.TabIndex = 171;
            this.lChrgREF.Text = "P4500TT-1-1000-1000";
            this.lChrgREF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lChrgREF.Visible = false;
            this.lChrgREF.DoubleClick += new System.EventHandler(this.lChrgREF_DoubleClick);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lvDefOption);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox7.Location = new System.Drawing.Point(0, 230);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1440, 470);
            this.groupBox7.TabIndex = 164;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Charger Info.";
            // 
            // groupBox15
            // 
            this.groupBox15.Controls.Add(this.groupBox13);
            this.groupBox15.Controls.Add(this.groupBox14);
            this.groupBox15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox15.Location = new System.Drawing.Point(1440, 230);
            this.groupBox15.Name = "groupBox15";
            this.groupBox15.Size = new System.Drawing.Size(20, 470);
            this.groupBox15.TabIndex = 165;
            this.groupBox15.TabStop = false;
            this.groupBox15.Text = "Tech, Values";
            // 
            // Chargerdlg_RREV
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(1460, 700);
            this.Controls.Add(this.groupBox15);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.grp1);
            this.Controls.Add(this.gbxCalc);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chargerdlg_RREV";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Technical Simulation";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Chargerdlg_Load);
            this.Resize += new System.EventHandler(this.Chargerdlg_Resize);
            this.gbxCalc.ResumeLayout(false);
            this.groupBox12.ResumeLayout(false);
            this.groupBox12.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpVals_tmp.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.groupBox14.ResumeLayout(false);
            this.groupBox13.ResumeLayout(false);
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.groupBox7.ResumeLayout(false);
            this.groupBox15.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			lSave.Text = "N"; 
			this.Hide();
		}

		private void Chargerdlg_Load(object sender, System.EventArgs e)
		{
			if (MainMDI.currDB == "XTT") this.Text = "XXXXXXXXXXXXXXXXXXTT"; 
			tCellN.Focus();
			if (!In_code) validate_CHRG();

			//cbIdc.Text = "125";
			//cbPhs.Text = "1";
			//cbPxx.Text = "P4500";
			//cbVdc.Text = "125"; 
			//MessageBox.Show ("Cont.."); 
		}

		private void load_OTI_LIST()
		{
			string stSql = "SELECT * FROM PSM_LIST_OTIS ";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				ListViewItem Lv = lvOTI.Items.Add(Oreadr["Otis_Desc"].ToString());
				Lv.SubItems.Add(Oreadr["Otis_LID"].ToString());
				Lv.SubItems.Add(Oreadr["Otis_Px_Ref"].ToString());
				Lv.SubItems.Add(Oreadr["Otis_C_name"].ToString());
				Lv.SubItems.Add(Oreadr["Otis_Link1"].ToString());
				Lv.SubItems.Add(Oreadr["Otis_Link2"].ToString());
				Lv.SubItems.Add(Oreadr["Otis_Link3"].ToString());
				Lv.SubItems.Add(Oreadr["Otis_Link4"].ToString());
				if (In_TV.IndexOf(Oreadr["Otis_C_name"].ToString() + "||") != -1)
					Lv.Checked = (In_TV.IndexOf(Oreadr["Otis_C_name"].ToString() + "||n/a") == -1);
			}
            OConn.Close();
		}

		private void fill_cbVCS()
		{
			string stSql = "SELECT * from COMPUTE_VCS ";
           
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
				cbVCS.Items.Add(Oreadr["VCS_NAME"].ToString()); 
			OConn.Close();
		}

		private void fill_All_cb(string s_cb)
		{
			for (int i = 0; i < s_cb.Length; i++)
			{
				string stSql = "SELECT TABLES_CONTENT.VALUE1" +
                    " FROM TABLES_CONTENT INNER " +
					" JOIN TABLES_LIST ON TABLES_CONTENT.TABLE_ID = TABLES_LIST.TABLE_ID " +
					" WHERE (((TABLES_LIST.TABLE_NAME)='";
            
				switch (s_cb[i]) 
				{
					case 'c':
						stSql = stSql + "CHARGERS')) ORDER BY TABLES_CONTENT.TABLE_Line_id";
						cbPxx.Items.Clear(); 
						break;
					case 'v':  
						stSql = stSql + "VDCnominal')) ORDER BY cast(TABLES_CONTENT.VALUE1 AS float) ";
						cbVdc.Items.Clear(); 
						break;
					case 'i':  
						stSql = stSql + "IDC')) ORDER BY TABLES_CONTENT.TABLE_Line_id";
						cbIdc.Items.Clear(); 
						break;
				}
				SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
				OConn.Open();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();
				while (Oreadr.Read())
				{
					switch (s_cb[i]) 
					{
						case 'c':
							if (Oreadr["VALUE1"].ToString().Substring(0, 5) != "P4000") cbPxx.Items.Add(Oreadr["VALUE1"].ToString()); 
							break;
						case 'v':  
							cbVdc.Items.Add(Oreadr["VALUE1"].ToString()); 
							break;
						case 'i':  
							cbIdc.Items.Add(Oreadr["VALUE1"].ToString()); 
							break;
					}
				}
				OConn.Close(); 
			}
		}

		private void Maj_VDCMax()
		{
			if (tCellN.Text != "" && Uchng.Text == "Y")
			{
				Maj_TV(); 
				double vcellMin = (optNi.Checked) ? Tools.Conv_Dbl(lVcellMin_NI.Text) : Tools.Conv_Dbl(lVcellMin_LA.Text);
				double cfVcellMax = (optNi.Checked) ? Tools.Conv_Dbl(lNBC_NI.Text) : Tools.Conv_Dbl(lNBC_LA.Text);
				double Max_FLTEQ = Tools.Conv_Dbl(lFLT_EQ_SEC.Text) * Math.Max(Tools.Conv_Dbl(tVEQL.Text), Tools.Conv_Dbl(tVFLOAT.Text)); 
				tVdcMax.Text = Convert.ToString(Math.Round(Math.Max(Tools.Conv_Dbl(tCellN.Text) * cfVcellMax, Max_FLTEQ), 2)); 
				tvdcMin.Text = Convert.ToString(vcellMin * Tools.Conv_Dbl(tCellN.Text));
			}
		}

		private void Cal_MaxVdc(char c)
		{
			if (c == 'V')
			{
				if (lvpcE_LA.Text == "") 
				{ 
					lNBC_NI.Text = Cpt.seekCF("VcellMax-NI");
					lNBC_LA.Text = Cpt.seekCF("VcellMax-LA");
					lVcellMin_NI.Text = Cpt.seekCF("VcellMin-NI");
					lVcellMin_LA.Text = Cpt.seekCF("VcellMin-LA");
					lvpcE_LA.Text = Cpt.seekCF("VPCEQ-LA");
					lvpcF_LA.Text = Cpt.seekCF("VPCFLT-LA");
					lvpcE_NI.Text = Cpt.seekCF("VPCEQ-NI");
					lvpcF_NI.Text = Cpt.seekCF("VPCFLT-NI");
					lFLT_EQ_SEC.Text = Cpt.seekCF("FLT-EQ_SEC");
				}
				lIprim.Text = Std_VCS(cbPhs.Text, Charger.AvailId, "C_IPRIM");
				lstdvdcMin.Text = Std_VCS(cbPhs.Text, Charger.AvailId, "C_VDCMIN"); //Cpt.Cal_VCS(0, "C_VDCMIN");
				lstdvdcMax.Text = Std_VCS(cbPhs.Text, Charger.AvailId, "C_VDCMAX"); //Cpt.Cal_VCS(0, "C_VDCMAX");
				lstdVAC.Text = Std_VCS(cbPhs.Text, Charger.AvailId, "C_VAC"); //Cpt.Cal_VCS(0, "C_VAC");
				lRiple.Text = Cpt.Cal_VCS(0, "C_RIPLE");
				if (tCellN.Text == "" || Uchng.Text == "N")
				{
					tVdcMax.Text = lstdvdcMax.Text;
					tvdcMin.Text = lstdvdcMin.Text;
					tVac.Text = lstdVAC.Text; 
				}
				Maj_NBCELL();
			}
		}

		private void Maj_NBCELL()
		{
			string dd = (optLA.Checked || optVrla.Checked) ? Cpt.Cal_VCS(0, "C_NBCELL-LA") : Cpt.Cal_VCS(0, "C_NBCELL-NI");
			//string dd = (optLA.Checked) ? Std_VCS(cbPhs.Text, Charger.AvailId, "C_NBCELL-LA") : Std_VCS(cbPhs.Text, Charger.AvailId, "C_NBCELL-NI");
			lstdCellN.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(dd), 0));
			if (tCellN.Text == "" || Uchng.Text == "N") tCellN.Text = lstdCellN.Text;
		}
	
		private void Vdc_Advice(string st)
		{ 
			double vMax = Tools.Conv_Dbl(lstdvdcMax.Text), vMin = Tools.Conv_Dbl(tvdcMin.Text), vCal = Tools.Conv_Dbl(st);
			if (vCal > vMax) MessageBox.Show("Please Choose Nest Charger...");
			else if (vCal >= vMin && vCal <= vMax) tVdcMax.Text = lstdvdcMax.Text;
		}

		private void Maj_VPC(char c)
		{
			if (optNi.Checked) 
			{
				lNcelCoef.Text = lNBC_NI.Text;
				tvpcEq.Text =  lvpcE_NI.Text;
				tvpcF.Text =  lvpcF_NI.Text;
			}
			else
			{
				if (optLA.Checked)  
				{
					lNcelCoef.Text = lNBC_LA.Text;
					tvpcEq.Text = lvpcE_LA.Text;
					tvpcF.Text = lvpcF_LA.Text;
				}
				else //VRLA ?????
				{
					lNcelCoef.Text = lNBC_LA.Text;
					tvpcF.Text = lvpcF_LA.Text; 
					tvpcEq.Text = lvpcF_LA.Text;
				}
			}
			Maj_TV();
		}
	
		/*
		private void FindVDCIDC(string p, string c, long Avail_ID, out string vdc, out string idc)
		{
			string stSql= " SELECT vdc,idc FROM TBLAVAIL " + p + " WHERE (Avail_ID)=" + Avail_ID + "))";

			SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{  
				vdc = Oreadr["vdc"].ToString();
				idc = Oreadr["idc"].ToString();
				break;
			}
			OConn.Close();
		}
		*/

		private void Maj_TV()
		{
			if (tCellN.Text != "" && tvpcEq.Text != "" && tvpcF.Text != "") //&& Uchng.Text == "N")
			{
				tVEQL.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tvpcEq.Text) * Tools.Conv_Dbl(tCellN.Text), 2)); 
				tVFLOAT.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tvpcF.Text) * Tools.Conv_Dbl(tCellN.Text), 2)); 
			}
		}

		private void buil_chrg_Ref()
		{
			//Uchng.Text = "N";
			//lChrgREF.Text = cbPxx.Text + "-" + cbPhs.Text + "-" + cbVdc.Text + "-" + cbIdc.Text;
			lChrgREF.Text = cbPxx.Text + "-" + cbPhs.Text + "-" + cbVdc.Text + "-" + cbIdc.Text;
			if (cbPxx.Text != "" && cbPhs.Text != "" && cbVdc.Text != "" && cbIdc.Text != "") 
			{
				//this.Cursor = Cursors.WaitCursor;  
				NewChrg();
				Cal_MaxVdc('V');
				Maj_VPC('D');
				//Sav_Usr_Val();
				//fill_Def_options();
			}
		}

		private void cbPxx_SelectedValueChanged(object sender, System.EventArgs e)
		{
			if (cbPxx.Text.Substring(0, 5) == "P4500") buil_chrg_Ref();
			bool tt = (cbPxx.Text.Substring(0, 5) == "P5500");
			lmin.Visible = tt;
			lxxx.Visible = tt;
			cbXXX.Visible = tt;
		}
		private void Maj_VDC(char c)
		{
			if (c == 'V') buil_chrg_Ref();
		}

		private void cbPhs_SelectedValueChanged(object sender, System.EventArgs e)
		{
			buil_chrg_Ref();
		}

		private void cbVdc_SelectedValueChanged(object sender, System.EventArgs e)
		{
			tVDC.Text = cbVdc.Text;
			Maj_VDC('V');
		}

		private void EquiV_IDC(string I)
		{
			switch (I)
			{
				case "6":
					cbIdc.Text = "10";
					break;
				case "12":
					cbIdc.Text = "15";
					break;
				default:
					cbIdc.Text = I;
					break;
			}
		}

		private void cbIdc_SelectedValueChanged(object sender, System.EventArgs e)
		{
			TIDC.Text = cbIdc.Text;
			Maj_IDC('I');
		}

		private void Ref_Chrg_Info()
		{
			//if (lChrgREF.Text != "")
		}

		private void Maj_IDC(char c)
		{
			if (c == 'I') buil_chrg_Ref();
			//if (optCalc.Checked) 
			//{
			tIdcMin.Text ="0";
			tIdcMax.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(cbIdc.Text) * 120 /100, Charger.NB_DEC_AFF)); 
			//}
		}

		private void button1_Clickooo(object sender, System.EventArgs e)
		{ 
			/*if (lchrgOKz.Text != "OK")
			{
				CHRGR = new Charger(MainMDI._connectionString, lFV.Text, cbPxx.Text, cbPhs.Text, cbVdc.Text, cbIdc.Text);
				Cpt = new Component();
				lchrgOKz.Text = "OK";
			}
			label10.Text = Cpt.Cal_VCS(0, cbVCS.Text).ToString();
			*/
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			CHRGR = new Charger(0, lFV.Text, cbPxx.Text, cbPhs.Text, cbVdc.Text, cbIdc.Text, "0", "0");
			Cpt = new Component();
			//CHRGR.Cpt_List[0] = Cpt;
			//lchrgOKz.Text = "OK";
			label10.Text = Cpt.Cal_VCS(0, cbVCS.Text).ToString();
			//MessageBox.Show("TSTVAr= " + CHRGR.Cpt_List[0].G_PRICE);  
		}

		private void groupBox2_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void cbVCS_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void label18_Click(object sender, System.EventArgs e)
		{
		
		}

		private char Valid_Charger()
		{
			double dMin = Tools.Conv_Dbl(lstdvdcMin.Text);
			double dMin_FL_EQ = Math.Min(Tools.Conv_Dbl(tVFLOAT.Text),Tools.Conv_Dbl(tVEQL.Text));
			double dMaxCal = Tools.Conv_Dbl(tVdcMax.Text);
			double dMax = Tools.Conv_Dbl(lstdvdcMax.Text);
			if (dMaxCal > dMax) return 'H';
			else if (dMin_FL_EQ < dMin) return 'L';
			return 'R';
		}
	
		private long Cal_Valid_Charger(char c, double m_vdcMAX, double m_vdcMin, ref string V, string I)
		{
			string stSql = "";
			V = "";
			if (c == 'H') stSql = "SELECT BGF_VCS13.*, TBLAVAIL1.charger, TBLAVAIL1.vdc, TBLAVAIL1.idc" +
                    " FROM BGF_VCS13 INNER JOIN TBLAVAIL1 ON BGF_VCS13.Avail_ID = TBLAVAIL1.Avail_ID " +
					" WHERE (((BGF_VCS13.VCS_NAME)='C_VDCMAX') AND (TBLAVAIL1.idc='" + I + "')" +
                    "        AND ((cast([BGF_VCS13].[Value] AS float))>=" + m_vdcMAX + " )) AND ((BGF_VCS13.phs)='" + Charger.P + "')" +
					" ORDER BY cast([BGF_VCS13].[Value] AS float)";

			else stSql = "SELECT BGF_VCS13.*, TBLAVAIL1.charger, TBLAVAIL1.vdc, TBLAVAIL1.idc " +
					" FROM BGF_VCS13 INNER JOIN TBLAVAIL1 ON BGF_VCS13.Avail_ID = TBLAVAIL1.Avail_ID " +
					" WHERE (((BGF_VCS13.VCS_NAME)='C_VDCMIN') AND (TBLAVAIL1.idc='" + I + "')" +
                    "        AND ((cast([BGF_VCS13].[Value] AS float))<=" + m_vdcMin + ")) AND ((BGF_VCS13.phs)='" + Charger.P + "') " +
					" ORDER BY cast([BGF_VCS13].[Value] AS float) DESC";

			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{  
				V = Oreadr["vdc"].ToString();
				return Convert.ToInt32(Oreadr["Avail_ID"].ToString());
			}
			OConn.Close(); 
			return 0;
		}

		private string Std_VCS(string p, long Avail_ID, string VCS_NAME)
		{
			string stSql = "SELECT * FROM BGF_VCS13 WHERE (Avail_ID= " + Avail_ID + " AND phs='" + Charger.P + "' AND VCS_NAME='" + VCS_NAME + 
                "')";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
				return Oreadr["value"].ToString();
			OConn.Close(); 
			return Charger.VIDE;
		}
	
		private string find_CHARGER_COST(string PXX, string PHS, string VDC, string IDC)
		{
			string stSql = " SELECT TBLTOXL0" + PHS + ".* FROM TBLTOXL0" + PHS + " WHERE (TBLTOXL0" + PHS + ".COMPONENT='" + PXX + 
                "_LIST') AND (TBLTOXL0" + PHS + ".REF_CHRG='" + PXX + "_LIST-" + VDC + "')";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read()) 
                return Oreadr[IDC].ToString();
            OConn.Close();
			return Charger.VIDE;
		}

		private string find_CHARGER_COSTOKK(string PXX, string PHS, string VDC, string IDC)
		{
			string stSql = " SELECT TBLTOXL0" + PHS + ".* FROM TBLTOXL0" + PHS + " WHERE (TBLTOXL0" + PHS + ".COMPONENT='" + PXX + 
                "_LIST') AND (TBLTOXL0" + PHS + ".REF_CHRG='" + PXX + "_LIST-" + VDC + "')";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read()) 
                return Oreadr[IDC].ToString();
            OConn.Close();
			return Charger.VIDE;
		}

		private void btnCost_Click(object sender, System.EventArgs e)
		{
			string msg1 = "", msg = "";
			bool chng = true;
			oldVdc.Text = cbVdc.Text;  
			string v = "";
			double MN_EQFLT = Math.Min(Tools.Conv_Dbl(tVEQL.Text), Tools.Conv_Dbl(tVFLOAT.Text));
			char c = Valid_Charger();
			if (c == 'L' || c == 'H') 
			{   
				msg1 = (c == 'L') ? "You may choose a Lower Charger Model....!!!!" : "You may choose a Higher Charger Model....!!!!";
				DialogResult dr = MessageBox.Show(msg1, "Bad Charger Model", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.Yes)
				{ 
					long AVID = Cal_Valid_Charger(c, Tools.Conv_Dbl(tVdcMax.Text), MN_EQFLT, ref v, cbIdc.Text);
					if (v != "") 
					{
						string VX = Std_VCS(cbPhs.Text, AVID, "C_VDCMAX");  
						string VN = Std_VCS(cbPhs.Text, AVID, "C_VDCMIN");  
						if (c == 'L' && Tools.Conv_Dbl(tVdcMax.Text) > Tools.Conv_Dbl(VX)) 
						{
							chng = false; 
							msg = " Can not Move to Low " + v + "V !!! its VDCMAX is Low...." + "\n" + 
                                " The actual Model seems be ideal even its VdcMin is too Low..."; 
						}
						if (c == 'H' && MN_EQFLT < Tools.Conv_Dbl(VN)) msg = "Min(EQL,FLT) is too Low..."; 
						if (chng) cbVdc.Text = v;
						if (msg != "") MessageBox.Show(msg);
					}
					else MessageBox.Show("Please Consult Engineering.... !!!");
				}
			}
			if (tVdcMax.Text != lstdvdcMax.Text || tVac.Text != lstdVAC.Text) fill_Def_options(tVdcMax.Text, tVac.Text);
			else fill_Def_optionsww();
			btnCancel.Enabled = lvDefOption.Items.Count > 0; 
			btnOK.Enabled = btnCancel.Enabled; 
			//btnAlarm.Enabled = true; 
		    //lnkAlarm.Enabled = true;
		    //pictureBox2.Enabled = true;
		}

		private void fill_Def_optionsww()
		{
			//t1.Text = System.DateTime.Now.Second.ToString(); 
			this.Cursor = Cursors.WaitCursor;  

			string stSql = "select * from COMPNT_LIST where Compnt_Type='E' or Compnt_Type='D'  order by Component_ID";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			lvDefOption.Items.Clear();
			while (Oreadr.Read()) 
                find_CPT_Cost(Oreadr["Component_ID"].ToString(), Oreadr["COMPONENT_REF"].ToString(), Oreadr["Component_Name"].ToString(), 
                    Oreadr["CatName1"].ToString(), Oreadr["CatName2"].ToString(), Oreadr["CatName3"].ToString());
			if (lvDefOption.Items.Count != 0) add_Modif_STDFeat();
			Oreadr.Close();
			OConn.Close(); 
			this.Cursor = Cursors.Default; 
			//t2.Text = System.DateTime.Now.Second.ToString(); 
		}

		private void fill_Def_options(string m_vdcMax, string m_Vac)
		{
			t1.Text = System.DateTime.Now.Second.ToString(); 
			this.Cursor = Cursors.WaitCursor;

			string stSql = "select * from COMPNT_LIST where Compnt_Type='E' or Compnt_Type='D'  order by Component_ID";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			int debut = 0;
			
			//lvDefOption.Items.Clear();
			while (Oreadr.Read())
			{
				if (debut == 0) 
				{
					//CHRGR = new Charger(0, lFV.Text, cbPxx.Text, cbPhs.Text, cbVdc.Text, cbIdc.Text, tVac.Text, tVdcMax.Text);
					CHRGR = new Charger(0, lFV.Text, cbPxx.Text.Substring(0, 5), cbPhs.Text, cbVdc.Text, cbIdc.Text, tVac.Text, tVdcMax.Text);
					debut = 1;
				}
				Cpt = new Component();
				 
				string tt = Cpt.Cal_chrg_CostADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()), "C"); 
				lIprim.Text = Cpt.Cal_VCS(0, "C_IPRIM");
				lhrtZMRK.Text = Cpt.Cal_VCS(0, "C_HRTZ" + lhrtz.Text);
		
				if (tt == MainMDI.VIDE) MessageBox.Show("This default option: " + Oreadr["COMPONENT_REF"].ToString() + 
                    " was not found  !!!!"); 
				else
				{
					if (ndxCxx == 0) addchRef();
					if (Cpt.G_PRICE != Charger.VIDE)
					{
						//ListViewItem lvI = lvDefOption.Items.Add("");
						//lvI.Checked = true; 
						//string stt = (MainMDI.Lang == 0) ? Cpt.CAP4.ToString() + ", " + Cpt.CAP5.ToString() + ", " + Cpt.CAP6.ToString() : Cpt.CAP7.ToString() + ", " + Cpt.CAP8.ToString() + ", " + Cpt.CAP9.ToString(); 

						//string stt = Cpt.CAP4.ToString() + ", " + Cpt.CAP5.ToString() + ", " + Cpt.CAP6.ToString();
						//lvI.SubItems.Add(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()));
						//lvI.SubItems.Add(Cpt.G_Desc.ToString()); 
						string stt = MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()) + "=";
						stt += (Cpt.CAP4 == MainMDI.VIDE) ? "" : " " + Cpt.CAP4;
						stt += (Cpt.CAP5 == MainMDI.VIDE) ? "" : " " + Cpt.CAP5;
						stt += (Cpt.CAP6 == MainMDI.VIDE) ? "" : " " + Cpt.CAP6;
						stt += (Cpt.CAP7 == MainMDI.VIDE) ? "" : " " + Cpt.CAP7;
						//stt += (Oreadr["CAP4fr"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAP4fr"].ToString();
						//stt += (Oreadr["CAP5fr"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAP5fr"].ToString();
						//stt += (Oreadr["CAP6fr"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAP6fr"].ToString();
						//stt += (Oreadr["CAP7fr"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAP7fr"].ToString();
					
						arC_xxx[ndxCxx, 0] = stt;
						arC_xxx[ndxCxx++, 1] = Oreadr["COMPONENT_REF"].ToString();
					    //lvI.SubItems.Add(stt); //+ " -->" + Oreadr["Component_Name"].ToString());
						//lvI.SubItems.Add(tPxxQty.Text); 
						///lvI.SubItems.Add("0"); //lvI.SubItems.Add("$ " + Cpt.G_PRICE.ToString()); 
						//lvI.SubItems.Add("0"); 
						//lvI.SubItems.Add(tLTime.Text); 
						//lvI.SubItems.Add(Oreadr["CatName1"].ToString() + "=" + Cpt.CAP1.ToString()); 
						//if(Oreadr["CatName2"].ToString() != Charger.VIDE) lvI.SubItems.Add(Oreadr["CatName2"].ToString() + "=" + Cpt.CAP2.ToString()); 
						//else lvI.SubItems.Add(""); 
						//if(Oreadr["CatName3"].ToString() != Charger.VIDE) lvI.SubItems.Add(Oreadr["CatName3"].ToString() + "=" + Cpt.CAP3.ToString()); 
						//else lvI.SubItems.Add(""); 
					 	//lvI.SubItems.Add(Oreadr["COMPONENT_REF"].ToString()); 
					    //lvI.SubItems.Add(Oreadr["Component_Name"].ToString());
						//lvI.SubItems.Add(Cpt.G_Desc);
					    //if (valSTD_changed()) lvI.SubItems[0].ForeColor = Color.Red;
						//lvI.Checked = true;
						//Uncheck by default TB123/TB45 requested by Sam on: 13-12-2005
					    //if (Oreadr["COMPONENT_REF"].ToString().IndexOf("TB-") != -1 || Oreadr["COMPONENT_REF"].ToString().IndexOf("EN1") != -1) lvI.Checked = false;
						//
					}
				}
			}
			//lIprim.Text = Cpt.Cal_VCS(0, "C_IPRIM");
			
			if (lvDefOption.Items.Count != 0) add_Modif_STDFeat();
			OConn.Close(); 
			this.Cursor = Cursors.Default; 
			//t2.Text = System.DateTime.Now.Second.ToString(); 
		}

		/// <summary>
		/// 
		/// </summary>
		/// 
		private string find_EDrw_BOM(string Pxxx, string P, string V, string I)
		{
		  	string stSql = "SELECT     DRW_DESC, BOM_DESC" +
                " FROM   PSM_DRAW_BOM_Chargers " +
                " WHERE     Pxxxx = '" + Pxxx + "' AND phs = '" + P + "' AND " + V + " >= VdcFrom AND " + V + " <= VdcTo" +
                "        AND " + I + " >= IdcFrom AND " + I + " <= IdcTo ";
    		SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			stSql = "~~";
			while (Oreadr.Read())	
				stSql = Oreadr["DRW_DESC"].ToString() + "~~" + Oreadr["BOM_DESC"].ToString();
			Oreadr.Close();
			OConn.Close(); 
			return stSql;
		}

		private void Maj_LV()
		{
			for (int x = 0; x < xxCount; x++)
			{
				if (arC_xxx[x, 0] == "" && arC_xxx[x, 1] == "" && arC_xxx[x, 2] == "") x = xxCount;
				else
				{
					for (int v = 0; v < lvDefOption.Items.Count; v++)
					{
						if (arC_xxx[x, 0] != "") 
						{
							if (lvDefOption.Items[v].SubItems[10].Text == arC_xxx[x, 1]) 
							{
								lvDefOption.Items[v].SubItems[2].Text = arC_xxx[x, 0];
								lvDefOption.Items[v].BackColor = MainMDI.CLR_C_Chng; //Color.Thistle;
								val_Chrg_Done = true;
							}
						}
						else 
						{
							if (lvDefOption.Items[v].SubItems[11].Text.IndexOf(arC_xxx[x, 1]) != -1) 
							{
								lvDefOption.Items[v].SubItems[11].Text = arC_xxx[x, 2];
								lvDefOption.Items[v].BackColor = MainMDI.CLR_C_Chng; //Color.Thistle;
								val_Chrg_Done = true;
							}
						}
					}
				}
			}
		}

		private void addchRef()
		{
			string Desc= MainMDI.arr_EFSdict[10, L] + " " + lChrgREF.Text; //lvI.BackColor = Color.Salmon; 
			//lvI.SubItems.Add(" ");
			string Qty = "1"; 
			string cost = find_CHARGER_COST(cbPxx.Text, cbPhs.Text, cbVdc.Text, cbIdc.Text); 
		    cost = Convert.ToString(Math.Round(Tools.Conv_Dbl(cost) * Tools.Conv_Dbl(lhrtZMRK.Text), 0));   
			//rlvI.SubItems.Add(cost); 
			string r_ext = Convert.ToString(Math.Round(Tools.Conv_Dbl(tPxxQty.Text) * Tools.Conv_Dbl(cost), Charger.NB_DEC_AFF)); 
			string r_ltime = tLTime.Text; 
		    string r_EDBOM = find_EDrw_BOM(cbPxx.Text, cbPhs.Text, cbVdc.Text, cbIdc.Text);
			string r_TV = "   ";
      
		    //Desc = MainMDI.arr_EFSdict[12, L] + "=" + tVac.Text + " " + MainMDI.arr_EFSdict[13, L] + " +/- 10%, " + cbPhs.Text + " Phase, " + lhrtz.Text + " Hertz, " + Math.Round(Tools.Conv_Dbl(lIprim.Text), 0) + " A"; //12 = Input 13 = Volts 
            Desc = MainMDI.arr_EFSdict[12, L] + "=" + tVac.Text + " " + MainMDI.arr_EFSdict[13, L] + " +10/-12%, " + cbPhs.Text + " Phase, " + 
                lhrtz.Text + " Hertz, " + Math.Round(Tools.Conv_Dbl(lIprim.Text), 0) + " A"; //12 = Input 13 = Volts 
	  
            arC_xxx[ndxCxx, 0] = Desc;
			arC_xxx[ndxCxx++, 1] = "C_IV";
			//Maj_LV(Desc, "", "C_IV");

			Desc = MainMDI.arr_EFSdict[14, L] + "=" + cbVdc.Text + " " + MainMDI.arr_EFSdict[15, L] + " " + MainMDI.arr_EFSdict[32, L] + ":" + 
                "     Min " + MainMDI.arr_EFSdict[15, L] + ": " + tvdcMin.Text + "     Max " + MainMDI.arr_EFSdict[15, L] + ": " + 
                tVdcMax.Text; //14 = Output Voltage 15 = Vdc
			arC_xxx[ndxCxx, 0] = Desc;
			arC_xxx[ndxCxx++, 1] = "C_OV";
			//Maj_LV(Desc, "", "C_OV");

			Desc = MainMDI.arr_EFSdict[16, L] + "=" + cbIdc.Text + " " + MainMDI.arr_EFSdict[17, L] + " " + MainMDI.arr_EFSdict[32, L] + ":" + 
                "     Min " + MainMDI.arr_EFSdict[33, L] + ": " + tIdcMin.Text +  "     Max " + MainMDI.arr_EFSdict[33, L] + ": " + 
                tIdcMax.Text;
			arC_xxx[ndxCxx, 0] = Desc;
			arC_xxx[ndxCxx++, 1] = "C_OC";
			//Maj_LV(Desc, "", "C_OC");
		}

		private void endLV(ListViewItem lvI, int coln)
		{
			for (int i = coln; i < 12; i++) lvI.SubItems.Add(""); 
		}

		/*
		private void add_LVO(byte deb, string OpRef, string Desc, string UP, string Ext, string LT, string cat1, string cat2, string cat3)
		{
			ListViewItem lvI = lvDefOption.Items.Add("");
			if (deb == 0 || deb == 2) 
			{				
				if (deb == 0) lvI.BackColor = Color.Salmon;
				if (deb == 2) lvI.BackColor = Color.LightYellow;  
				lvI.SubItems.Add(OpRef);
			}
			else lvI.SubItems.Add(" "); //must be space
			if (ext != "" && tXRATE.Text != "") ext = Convert.ToString(Math.Round(Tools.Conv_Dbl(ext.Substring(1, ext.Length - 1)) * Tools.Conv_Dbl(tCust_Mult.Text) * Tools.Conv_Dbl(tXRATE.Text), MainMDI.NB_DEC_AFF)); else ext = "";
			lvI.SubItems.Add(Desc);  
			lvI.SubItems.Add(Qt);
			if (ext != "") lvI.SubItems.Add(MainMDI.A00(mult)); else lvI.SubItems.Add("");  
			lvI.SubItems.Add(MainMDI.A00(up));
			//if (up != "" && Qt != "") ext = Convert.ToString(Math.Round(Tools.Conv_Dbl(up) * Tools.Conv_Dbl(Qt) * Tools.Conv_Dbl(tXRATE.Text), MainMDI.NB_DEC_AFF));  
			if (ext != "") lvI.SubItems.Add(tXRATE.Text); else lvI.SubItems.Add("");
			lvI.SubItems.Add(MainMDI.A00(ext)); if (ext == "0") lvI.SubItems[lvI.SubItems.Count - 1].BackColor = Color.DarkTurquoise;
			lvI.SubItems.Add(LT);
			lvI.SubItems.Add(""); 
		}
		*/

		private void dlg_arr_frml_fill()
		{
			for (int i = 0; i < Charger.NB_FRML; i++)
			{
				if (Charger.arr_CAL_FRML[i] == "") 
                { 
                    dlg_arr_frml_NDX = i; 
                    break; 
                }
				else dlg_arr_CAL_FRML[i] = Charger.arr_CAL_FRML[i];
			}
		}

		private void dlg_arr_frml_Ovals()
		{
			dlg_arr_CAL_FRML[dlg_arr_frml_NDX++] = "Float||" + tVFLOAT.Text;
			dlg_arr_CAL_FRML[dlg_arr_frml_NDX++] = "Eq||" + tVEQL.Text;
			dlg_arr_CAL_FRML[dlg_arr_frml_NDX++] = "RPL||" + lRiple.Text;
			dlg_arr_CAL_FRML[dlg_arr_frml_NDX++] = "FHZ||" + lhrtz.Text;

			//add 280606
			for (int i = 0; i < lvOTI.Items.Count; i++) 
			{
				for (int j = 4; j < 7; j++)
				{
					if (lvOTI.Items[i].SubItems[j].Text != MainMDI.VIDE)
					{
						string cpT = (lvOTI.Items[i].Checked) ? 
                            cal_CPT(-1, lvOTI.Items[i].SubItems[j].Text.Substring(2, lvOTI.Items[i].SubItems[j].Text.Length - 2)) : 
                            MainMDI.VIDE; 
						dlg_arr_CAL_FRML[dlg_arr_frml_NDX++] = lvOTI.Items[i].SubItems[j].Text + "||" + cpT;
					}
				}
			}
			//add 280606
		}

		private void add_Modif_STDFeat()
		{
			//AddTec_Values("", "Cell#: " + tCellN.Text + ", VAC:" + tVac.Text + ", Float: " + tVFLOAT.Text + ", Equalize: " + tVEQL.Text, true); 
			dlg_arr_frml_fill();
			arC_xxx[ndxCxx, 0] = "VAC:" + tVac.Text + ", Float: " + tVFLOAT.Text + ", Equalize: " + tVEQL.Text;
			arC_xxx[ndxCxx++, 1] = "C_VFE"; 
			
			arC_xxx[ndxCxx, 0] = MainMDI.arr_EFSdict[19, L] + " " + lRiple.Text + " " + MainMDI.arr_EFSdict[20, L];
			arC_xxx[ndxCxx++, 1] = "C_RPL";	
		
			dlg_arr_frml_Ovals();
		}
		
	    /*	
		private void fill_stdFeat()
		{
			string stSql = "select * from PSM_STDFEATURES where ItemCode='C' order by rnk";
			SqlConnection OConn2 = new SqlConnection(MainMDI._connectionString);
			OConn2.Open();
			SqlCommand Ocmd2 = OConn2.CreateCommand();
			Ocmd2.CommandText = stSql;
			SqlDataReader Oreadr2 = Ocmd2.ExecuteReader();
			while (Oreadr2.Read()) AddTec_Values(Oreadr2["std"].ToString(), true); 
		}
	    */

		private void find_CPT_Cost(string Cpt_ID, string Cpt_Ref, string EFRef, string cat1, string cat2, string cat3)
		{
			//find CPT cost in XL file ..
			string stSql = "SELECT BGF_COST13.*" +
                " FROM BGF_COST13 " +
				" WHERE (((BGF_COST13.phs)='" + Charger.P + "') AND ((BGF_COST13.Avail_ID)=" + Charger.AvailId + ")" +
                " AND ((BGF_COST13.Compnt_ID)=" + Cpt_ID + "))" +
                " ORDER BY BGF_COST13.Compnt_ID";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			string[] ar_VV = new string[12];
			while (Oreadr.Read())
			{
				if (lvDefOption.Items.Count == 0) addchRef();
		        for (int y = 0; y < 12; y++) ar_VV[y] = ""; 
				int i = 1;
				if (Oreadr["Cost"].ToString() != Charger.VIDE)
				{
					ar_VV[i++] = MainMDI.optDesc(MainMDI.Lang, EFRef);
    				string stt = "";
					stt += (Oreadr["CAP4"].ToString() == MainMDI.VIDE) ? "" : " " + Oreadr["CAP4"].ToString();
					stt += (Oreadr["CAP5"].ToString() == MainMDI.VIDE) ? "" : " " + Oreadr["CAP5"].ToString();
					stt += (Oreadr["CAP6"].ToString() == MainMDI.VIDE) ? "" : " " + Oreadr["CAP6"].ToString();
					stt += (Oreadr["CAP7"].ToString() == MainMDI.VIDE) ? "" : " " + Oreadr["CAP7"].ToString();
					ar_VV[i++] = stt;   
					ar_VV[i++] = tPxxQty.Text; 
					ar_VV[i++] = "0";  
					ar_VV[i++] = "0"; 
					ar_VV[i++] = tLTime.Text; 
					ar_VV[i++] = cat1 + "=" + Oreadr["CAP1"].ToString(); 
					if (cat2 != Charger.VIDE) ar_VV[i++] = cat2 + "=" + Oreadr["CAP2"].ToString(); 
					if (cat3 != Charger.VIDE) ar_VV[i++] = cat3 + "=" + Oreadr["CAP3"].ToString(); 
					ar_VV[i++] = Cpt_Ref; 
					ar_VV[i++] = Cpt.G_Desc; 
					maj_lvDefOption(ar_VV[2], ar_VV[10], ar_VV[11]);
				}
			}
			OConn.Close();
		}

		private void maj_lvDefOption(string desc, string r_cptREF, string TV)
		{
           for (int q = 0; q < lvDefOption.Items.Count; q++)
			   if (lvDefOption.Items[q].SubItems[10].Text == r_cptREF) 
			   {
				   lvDefOption.Items[q].SubItems[2].Text = desc;  
				   lvDefOption.Items[q].SubItems[10].Text = r_cptREF;  
				   lvDefOption.Items[q].SubItems[11].Text = TV;  
			   }
		}
		
		private void AddTec_Values(string st0, string st, bool SHW)
		{
			ListViewItem lvI = lvDefOption.Items.Add("");
			lvI.Checked = SHW;
			lvI.SubItems.Add(st0); 
			lvI.SubItems.Add(st); 
			for (int j = 0; j < 7; j++)
			{
				lvI.SubItems.Add(""); 
				lvI.SubItems.Add(""); 
				lvI.SubItems.Add(""); 
				lvI.SubItems.Add(""); 
				lvI.SubItems.Add(" "); 
				lvI.SubItems.Add(" "); 
				lvI.SubItems.Add(" "); 
			}
		}

		/*
		private void fill_Def_optionsOLD(string m_vdcMax, string m_Vac)
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
					CHRGR = new Charger(0, lFV.Text, cbPxx.Text, cbPhs.Text, cbVdc.Text, cbIdc.Text, tVac.Text, tVdcMax.Text);
					debut = 1;
				}
				Cpt = new Component();
				//Cpt.CPT_COST(Convert.ToInt32(Oreadr["Component_ID"].ToString()));
				Cpt.Cal_chrg_CostADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()), "C"); 
				//MessageBox.Show(Oreadr["COMPONENT_REF"].ToString()); 
				if (Cpt.G_PRICE != Charger.VIDE)
				{
					ListViewItem lvI = lvDefOption.Items.Add(Oreadr["COMPONENT_REF"].ToString());
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
			//t2.Text = System.DateTime.Now.Second.ToString(); 
		}
		*/

		private void NewChrg()
		{
		    CHRGR = new Charger(0, lFV.Text, cbPxx.Text, cbPhs.Text, cbVdc.Text, cbIdc.Text, "0", "0");
		    Cpt = new Component();
			//lOldRef.Text = lChrgREF.Text;		
		}

		private void tCellN_TextChanged(object sender, System.EventArgs e)
		{
			//Cal_MaxVdc('C');
			Maj_VDCMax();
		}

		private void optFx_CheckedChanged(object sender, System.EventArgs e)
		{
			lFV.Text = "F";
			tvdcMin.Text = lstdvdcMin.Text;
		}

		private void optNi_CheckedChanged(object sender, System.EventArgs e)
		{
			Maj_VPC('V');
			Maj_NBCELL(); 
		}

		private void optLA_CheckedChanged(object sender, System.EventArgs e)
		{
	    	Maj_VPC('V');
			Maj_NBCELL();
		}

		private void cbXXX_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tvpcF_TextChanged(object sender, System.EventArgs e)
		{
			if (Tools.IsNumeric(tvpcF.Text)) Maj_VDCMax(); 
		}

		private void tCellN_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
	    	e.Handled = Tools.OnlyInt(e.KeyChar);
            Uchng.Text = "Y";
		}

		private void tVac_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		    //Uchng.Text = "Y";
		}

		private void tvpcF_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		    e.Handled = Tools.OnlyDBL(e.KeyChar);
			Uchng.Text = "Y";
		}

		private void tvdcMin_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tvdcMin_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tIdcMin_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		    e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tIdcMax_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		    e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tVdcMax_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tVdcMax_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			 e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tvpcEq_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
			Uchng.Text = "Y";
		}

		private void tvpcEq_TextChanged(object sender, System.EventArgs e)
		{
		    Maj_VDCMax();
		}

		private void optAuto_CheckedChanged(object sender, System.EventArgs e)
		{
			//gbxCalc.Enabled = optCalc.Checked;
		}

		private void optCalc_CheckedChanged(object sender, System.EventArgs e)
		{
			Maj_VDC('N');
			Maj_IDC('N'); 
			//gbxCalc.Enabled = optCalc.Checked;
		}

		private void optVar_CheckedChanged(object sender, System.EventArgs e)
		{
			lFV.Text = "V";
			tvdcMin.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tVdcMax.Text) * 0.1, 2)); 
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void cbXXX_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
		
		}

		private void cbPhs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			tPhs.Text = cbPhs.Text;
		}

		private void cbPhs_SelectedValueChanged_1(object sender, System.EventArgs e)
		{
            buil_chrg_Ref();		
		}

		private void cbPxx_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			tPxx.Text = cbPxx.Text; 
			lFTTT.Text = cbPxx.Text.Substring(5, cbPxx.Text.Length - 5);
			if (cbPxx.Text.Substring(0, 5) == "P4500") buil_chrg_Ref();
			bool tt = (cbPxx.Text.Substring(0, 5) == "P5500");
			lmin.Visible = tt;
			lxxx.Visible = tt;
			cbXXX.Visible = tt;
		}

		private void groupBox3_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void tVac_TextChanged(object sender, System.EventArgs e)
		{
			//Cal_MaxVdc('V');
		}

		private void tVdcMax_TextChanged_1(object sender, System.EventArgs e)
		{
		
		}

		private void cbVdc_SelectedValueChanged_1(object sender, System.EventArgs e)
		{
			
		}

		private void cbVdc_SelectionChangeCommitted(object sender, System.EventArgs e)
		{
			
		}

		private void cbVdc_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
		{
		
		}

		private void lV_TextChanged(object sender, System.EventArgs e)
		{
		    Maj_VDC('V');
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			tCellN.Text = ""; 
            Uchng.Text = "N"; 

			cbVdc_SelectedValueChanged(sender, e);  
		}

		private void oldVdc_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnOK_Clickold(object sender, System.EventArgs e)
		{
			//if (lALRM.Text == "Y")
			//{
			if (val_Alrm_Done) //(val_Chrg_Done && val_Alrm_Done) ||
			{
				lSave.Text = "Y"; 
				this.Hide();
			}
			else 
			{
				if (MainMDI.Confirm("You must validate Alarms, continue with Alarms validation ? ")) //, "ERROR Alarms validation", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);   
					Add_ALARMS(tModif_CHNew.Text);
				else btnCancel_Click(sender, e);
			}
			//}
			//else MessageBox.Show("This Charger is NOT VALIDATED , You must choose defaults alarms ......(click on ALARMS link) !!!");
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (!val_Alrm_Done) //(val_Chrg_Done && val_Alrm_Done) ||
				if (MainMDI.Confirm("You must validate Alarms, continue with Alarms validation ? ")) //, "ERROR Alarms validation", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);   
			        Add_ALARMS (tModif_CHNew.Text);
     		lSave.Text = "Y"; 
			this.Hide();
			//}
		    //else MessageBox.Show("This Charger is NOT VALIDATED , You must choose defaults alarms ......(click on ALARMS link) !!!");
		}

		private void lstdCellN_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lNA_Click(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox2_Enter_1(object sender, System.EventArgs e)
		{
		
		}

		private void lvDefOption_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void tPxxQty_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		    e.Handled = Tools.OnlyInt(e.KeyChar);
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
		    pick_option('C'); 
		}

		private void pick_option(char c)
		{
            string stt = "";
			if (c == 'D') 
                for (int r = lvDefOption.SelectedItems.Count - 1; r > -1; r--) lvDefOption.SelectedItems[r].Remove();    
			else
			{
				if (lvDefOption.SelectedItems[0].SubItems[10].Text != "" && lvDefOption.SelectedItems[0].SubItems[1].Text != "Charger") 
				{
					Options frmOpt = new Options(c, lvDefOption.SelectedItems[0].SubItems[10].Text, 'N');
					this.Hide();
					frmOpt.ShowDialog();
					this.Visible = true;
					if (frmOpt.lConsopt.Text == "Y")
					{
						if (MainMDI.Lang == 1 && frmOpt.tCat4fr.Text != MainMDI.VIDE) 
						{
							stt = frmOpt.tCat4fr.Text;
							stt += (frmOpt.tCat5fr.Text != MainMDI.VIDE && frmOpt.chk5.Checked) ? frmOpt.tCat5fr.Text : "";
							stt += (frmOpt.tCat6fr.Text != MainMDI.VIDE && frmOpt.chk6.Checked) ? frmOpt.tCat6fr.Text : "";
						}
						else
						{
							stt = frmOpt.tCat4.Text;
							stt += (frmOpt.tCat5.Text != MainMDI.VIDE && frmOpt.chk5.Checked) ? frmOpt.tCat5.Text : "";
							stt += (frmOpt.tCat6.Text != MainMDI.VIDE && frmOpt.chk6.Checked) ? frmOpt.tCat6.Text : "";
						}
						lvDefOption.SelectedItems[0].SubItems[2].Text = stt;
						//lvDefOption.SelectedItems[0].SubItems[2].Text = (MainMDI.Lang == 0) ? frmOpt.tCat4.Text + ", " + frmOpt.tCat5.Text + ", " + frmOpt.tCat6.Text : frmOpt.tCat4fr.Text + ", " + frmOpt.tCat5fr.Text + ", " + frmOpt.tCat6fr.Text; 
						lvDefOption.SelectedItems[0].SubItems[3].Text = frmOpt.tOptqty.Text; 
						lvDefOption.SelectedItems[0].SubItems[4].Text = frmOpt.tUPrice.Text; 
						lvDefOption.SelectedItems[0].SubItems[5].Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * 
                            Tools.Conv_Dbl(lvDefOption.SelectedItems[0].SubItems[3].Text), Charger.NB_DEC_AFF)); 
						lvDefOption.SelectedItems[0].SubItems[6].Text = frmOpt.tDlvDelay.Text;
						for(int j = 7; j < lvDefOption.SelectedItems[0].SubItems.Count - 1; j++) 
                            if (j != 10) lvDefOption.SelectedItems[0].SubItems[j].Text = "";
					}
					frmOpt.Dispose(); 
				}
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
		  
		}

		private void btnSProfile_Click(object sender, System.EventArgs e)
		{
			string stSql = "DELETE * FROM U_CCPROFILES WHERE (((U_CCPROFILES.USR)='" + In_User + "'))";
 			MainMDI.ExecSql(stSql); 
			stSql = "INSERT INTO U_CCPROFILES ([USR],[CellNB],[vpcF],[vpcEQ],[PXXX],[phs],[vdc],[idc],[xxx],[VAC]) " +
				" VALUES ('" + 
                In_User + "', " + 
                tCellN.Text + ", " + 
                tvpcF.Text + ", '" + 
				tvpcEq.Text + "', '" + 
                cbPxx.Text + "', '" + 
                cbPhs.Text + "', '" + 
                cbVdc.Text + "', '" + 
                cbIdc.Text + "', '" + 
                cbXXX.Text + "', '" + 
                tVac.Text + "')";
			MainMDI.ExecSql(stSql); 
		}

		private void btnLprofile_Click(object sender, System.EventArgs e)
		{
            load_Prof(); 
		}

		private  void load_TV(string r_inTV)
		{
			tModif_CH.Text = In_TV;
			tModif_CHNew.Text = r_inTV;
			TestEQA TEA = new TestEQA(In_TV);
			string stSql = "select * from PSM_LIST_TV where disp<>'0' and (phs='2' OR phs='" + tPhs.Text + "') order by TVLID";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql; 
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			LvTV.Items.Clear();   
			while (Oreadr.Read()) 
			{ 
				string st = TEA.look_Req_Value(Oreadr["C_Name"].ToString(), r_inTV, 'C');
				if (st != "???" && st != "0") 
				{
					ListViewItem lvI = LvTV.Items.Add("");
					lvI.SubItems.Add(Oreadr["TVName_disp"].ToString());
					double dd = Tools.Conv_Dbl(st);
					if (dd > 0) st = Convert.ToString(Math.Round(dd, MainMDI.NB_DEC_AFF));  
					lvI.SubItems.Add(st);
					lvI.SubItems.Add(Oreadr["HOWTO"].ToString());
					lvI.UseItemStyleForSubItems = false; 
					lvI.SubItems[3].ForeColor = Color.Black; 
					lvI.SubItems[1].ForeColor = Color.Black; 
				}
			}
            OConn.Close();
		}

		private  void load_Coef()
		{
			string stSql = "SELECT dbo.TABLES_CONTENT.COL1 AS Name, dbo.TABLES_CONTENT.VALUE1 AS Coef_Value , disp" +
                " FROM         dbo.TABLES_LIST INNER JOIN dbo.TABLES_CONTENT ON dbo.TABLES_LIST.TABLE_ID = dbo.TABLES_CONTENT.TABLE_ID " +
                " WHERE     (dbo.TABLES_LIST.TABLE_NAME = 'coeficients') AND (dbo.TABLES_CONTENT.disp = '1')";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql; 
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read()) 
			{ 
				ListViewItem lvI = lvCoef.Items.Add(Oreadr["Name"].ToString());
				lvI.SubItems.Add(Oreadr["Coef_Value"].ToString());
			    //if (Oreadr["disp"].ToString() == "1") 
			    //{

			    //}
			}
            OConn.Close();
		}

		private void load_Prof()
		{
			load_Coef();
			TestEQA TEA = new TestEQA(In_TV);
	        cbPxx.Text = TEA.look_Req_Value("U_CHARGER", In_TV, 'C');
		    cbPhs.Text = TEA.look_Req_Value("U_PHASE", In_TV, 'C');  
			cbVdc.Text = TEA.look_Req_Value("U_VDCNOM", In_TV, 'C'); //TEA.look_Tests_VCS("U_VDCNOM"); 
			cbIdc.Text = TEA.look_Req_Value("U_IDC", In_TV, 'C'); //TEA.look_Tests_VCS("U_IDC"); 
			tVac.Text = TEA.look_Req_Value("C_VAC", In_TV, 'C'); //TEA.look_Tests_VCS("C_VAC");
			lmdel.Text = TEA.look_Req_Value("C_MODEL", In_TV, 'C');
			load_TV(In_TV); 
		    //lISEC.Text = TEA.look_Req_Value("C_ISEC", In_TV, 'C');
		    //lVSEC.Text = TEA.look_Req_Value("C_VSEC", In_TV, 'C');
		    //lKVA.Text = TEA.look_Req_Value("C_PKVA", In_TV, 'C');
		}

		private void ExecSqla(string stSql)
		{
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			Ocmd.ExecuteNonQuery();
			OConn.Close();
		}

		private void lvDefOption_DoubleClick(object sender, System.EventArgs e)
		{
	        /*		
	        //if (lvDefOption.SelectedItems[0].SubItems[1].Text == "Charger") lvDefOption.SelectedItems[0].Checked = true;
	        lvDefOption.SelectedItems[0].BackColor = Color.BlueViolet;  
			lselI = lvDefOption.SelectedItems[0].Index;
			lvDefOption.SelectedItems[0].Checked = true;
			tRef.Text = lvDefOption.SelectedItems[0].SubItems[1].Text;
			tdesc.Text = lvDefOption.SelectedItems[0].SubItems[2].Text;
			tqty.Text = lvDefOption.SelectedItems[0].SubItems[3].Text;
			tUprice.Text = lvDefOption.SelectedItems[0].SubItems[4].Text;
			tExt.Text = lvDefOption.SelectedItems[0].SubItems[5].Text; 
            tLT.Text = lvDefOption.SelectedItems[0].SubItems[6].Text;
            grp1.Height = 120;
	        */
		}

		private void menuItem2_Click_1(object sender, System.EventArgs e)
		{
		    //pick_option('N'); 
		}

		private void opt60_CheckedChanged(object sender, System.EventArgs e)
		{
			lhrtz.Text = "60";
		}

		private void opt50_CheckedChanged(object sender, System.EventArgs e)
		{
			lhrtz.Text = "50";
		}

		private void opt400_CheckedChanged(object sender, System.EventArgs e)
		{
			lhrtz.Text = "400";
		}

		private void Chargerdlg_Resize(object sender, System.EventArgs e)
		{
		    //lvDefOption.Height = this.Height - 500; //248; 544
		    //lvDefOption.Columns[2].Width = this.Width - 670;

	        //btnCancel.Left = grp1.Width - 104;
		    //btnOK.Left = grp1.Width - 224;
		    //btnCancel.Top = this.Height - 64;
		    //btnOK.Top = this.Height - 64;
		    //btnCancel.Left = this.Width - 96;
		    //btnOK.Left = this.Width - 184;
		}

		private bool valSTD_changed()
		{
			return (lstdCellN.Text != tCellN.Text || lstdVAC.Text != tVac.Text || lstdvdcMin.Text != tvdcMin.Text || 
                lstdvdcMax.Text != tVdcMax.Text);
			//MessageBox.Show("Please Check the calculated components PRICES, since standard values were changed !!!");
		}

		private void tVEQL_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void button3_Click_1(object sender, System.EventArgs e)
		{
		
		}

		private void dlg_Arr_frml_Disp()
		{
			string stout = "";
			for (int i = 0; i < Charger.NB_FRML; i++)
			{
				if (dlg_arr_CAL_FRML[i] == "") break;
				else stout += dlg_arr_CAL_FRML[i] + "\n";
			}
			MessageBox.Show(stout); 
		}

		private void arCxx_Disp()
		{
			string stout = "";
			for (int i = 0; i < xxCount; i++) stout += arC_xxx[i, 0] + "---" + arC_xxx[i, 1] + "---" + arC_xxx[i, 2] + "\n";
			MessageBox.Show(stout); 
		}

		private void validate_CHRG()
		{
			//init arrays
			val_Alrm_Done = false;
			for (int x = 0; x < xxCount; x++) 
                for (int j = 0; j < 3; j++) arC_xxx[x, j] = ""; 
			for (int i = 0; i < Charger.NB_FRML; i++) dlg_arr_CAL_FRML[i] = ""; 
			ndxCxx = 0;
			if (Validate_Charger())
			{
				//if (valSTD_changed() &&  In_code) MessageBox.Show("Check PRICES on RED lines , since standard values were changed  !!!");
			    string lFrml = ""; 
				for (int y = 0; y < Charger.NB_FRML; y++)
				{
					if (dlg_arr_CAL_FRML[y] != "") lFrml += " " + dlg_arr_CAL_FRML[y];  
					else break;
				}
				lFrml += " C_MODEL||" + lmdel.Text; 
				fill_OTV();  
				lFrml += " " + lOth_TV; 
				arC_xxx[ndxCxx, 2] = lFrml;
				arC_xxx[ndxCxx++, 1] = "C_MODEL||" + lmdel.Text;
		        //arCxx_Disp();
				Maj_LV();
				load_TV(lFrml); 
				tModif_CHNew.Text = lFrml;
			}
		}

		private void LnkValidate_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
            validate_CHRG();
            RE_Add_ALARMS_OFF(tModif_CHNew.Text);
		}

		private bool dlg_Arr_frml_Exist(string C_name)
		{
			string stout = "";
			for (int i = 0; i < Charger.NB_FRML; i++)
			{
				if (dlg_arr_CAL_FRML[i] == "") return false;
				else return (dlg_arr_CAL_FRML[i].IndexOf(C_name + "||") > -1);   
			}
			return false;
		}

		private  string fill_TV_LIST()
		{
			string stSql = "select * from PSM_LIST_TV where disp='1' and (phs='2' OR phs='" + cbPhs.Text + "') order by TVLID";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql; 
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			string stRes = "";
			string st = "";
			while (Oreadr.Read()) 
			{ 
				string C_NAME = Oreadr["C_Name"].ToString().Substring(2, Oreadr["C_Name"].ToString().Length - 2);
				if (!dlg_Arr_frml_Exist(C_NAME)) 
				{
					if (Oreadr["TV_typ"].ToString() == "C")  
					{
						st = cal_CPT(-1, C_NAME);
						stRes += (st == MainMDI.VIDE) ? "" : " " + Oreadr["C_Name"].ToString() + "||" + st; 
					}
					else 
					{
						st = cal_VCS(Oreadr["C_Name"].ToString());
						stRes += (st == MainMDI.VIDE) ? "" : " " + Oreadr["C_Name"].ToString() + "||" + st; 
					}
				}
			}
            OConn.Close();
			return stRes;
		}

		private void fill_OTV()  
		{
			lOth_TV = "C_CLN||" + tCellN.Text; //cell#
			if (optVrla.Checked) lOth_TV += " C_TBT||V"; //Batteries Vrla, Nicd, Leadacid
			else if (optNi.Checked) lOth_TV += " C_TBT||N"; 
			else if (optLA.Checked) lOth_TV += " C_TBT||L"; 
			lOth_TV += " C_VF||" + ((optFx.Checked) ? "F" : "V"); //charger Fx / Var
			lOth_TV += " C_FC||" + tvpcF.Text; //Float coef     
			lOth_TV += " C_EC||" + tvpcEq.Text; //Eqlz coef  
			lOth_TV += " " + fill_TV_LIST(); //Save ALL TVs described in PSM_LIST_TV
		}

		private bool Validate_Charger()
		{
			string msg1 = "", msg = "";
			bool chng = true;
			oldVdc.Text = cbVdc.Text;  
			string v = "";
			double MN_EQFLT = Math.Min(Tools.Conv_Dbl(tVEQL.Text), Tools.Conv_Dbl(tVFLOAT.Text));
			char c = Valid_Charger();

			if (c == 'L' || c == 'H') 
			{ 
				if (In_code)  
				{
					DialogResult dr = MessageBox.Show("Sorry, You can not change CHARGER to Lower/Higher Model... !!", "Bad Charger Model", 
                        MessageBoxButtons.OK, MessageBoxIcon.Stop);
				}
				chng = true;
				/*  
				msg1 = (c == 'L') ? "You may choose a Lower Charger Model....!!!!" : "You may choose a Higher Charger Model....!!!!";
				DialogResult dr = MessageBox.Show(msg1, "Bad Charger Model", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
				if (dr == DialogResult.Yes)
				{ 
					long AVID = Cal_Valid_Charger(c, Tools.Conv_Dbl(tVdcMax.Text), MN_EQFLT, ref v, cbIdc.Text);
					if (v != "") 
					{
						string VX = Std_VCS(cbPhs.Text, AVID, "C_VDCMAX"); 
						string VN = Std_VCS(cbPhs.Text, AVID, "C_VDCMIN");  
						if (c == 'L' && Tools.Conv_Dbl(tVdcMax.Text) > Tools.Conv_Dbl(VX)) 
						{
							chng = false; 
							msg = " Can not Move to Low " + v + "V !!! its VDCMAX is Low...." + "\n" + " The actual Model seems be ideal even its VdcMin is too Low..."; 
						}
						if (c == 'H' && MN_EQFLT < Tools.Conv_Dbl(VN)) msg = "Min(EQL,FLT) is too Low..."; 
						if (chng) cbVdc.Text = v;
						if (msg != "") MessageBox.Show(msg);
					}
					else MessageBox.Show("Please Consult Engineering.... !!!");
				}
			   */
			}
			if (chng)
			{
				fill_Def_options(tVdcMax.Text, tVac.Text); //Recalculate all CPT 
				btnCancel.Enabled = lvDefOption.Items.Count > 0; 
				btnOK.Enabled = btnCancel.Enabled; 
			    //lnkAlarm.Enabled = true;
			}
			return chng;
		    //pictureBox2.Enabled = true;
		}

		private void lnkAlarm_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
		    Add_ALARMS(tModif_CHNew.Text);
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
			validate_CHRG();
		}

		private void pictureBox2_Click(object sender, System.EventArgs e)
		{
			 Add_ALARMS(tModif_CHNew.Text);
		}

		private void rm_curr_ALRMs()
		{
			for (int r = lvDefOption.Items.Count - 1; r > -1; r--)
				if (lvDefOption.Items[r].SubItems[10].Text == "ALEQ_") lvDefOption.Items[r].Remove();
		}

		private void Add_AlarmsOLD()
		{
	        /*
	        Alarms ALRM = new Alarms(this);
			ALRM.ShowDialog();
			if (ALRM.lSave.Text == "Y") 
			{   
				rm_curr_ALRMs();
				for (int i = 0; i < ALRM.lvAlrmPL.Items.Count; i++)
				{
					if (ALRM.lvAlrmPL.Items[i].Checked)
					{
						ListViewItem lvI = lvDefOption.Items.Add("");
						lvI.SubItems.Add("");
						lvI.SubItems.Add(ALRM.lvAlrmPL.Items[i].SubItems[1].Text);
						lvI.Checked = true; 
					    //lvI.SubItems.Add("");
					    //lvI.SubItems.Add(""); 
						if (ALRM.lvAlrmPL.Items[i].SubItems[2].Text == "0" || ALRM.lvAlrmPL.Items[i].SubItems[2].Text == "") 
						{
							lvI.SubItems.Add(""); 
							lvI.SubItems.Add("");
							lvI.SubItems.Add(""); 
						}
						else 
						{
							lvI.SubItems.Add("1"); 
							lvI.SubItems.Add(ALRM.lvAlrmPL.Items[i].SubItems[2].Text);
							lvI.SubItems.Add(ALRM.lvAlrmPL.Items[i].SubItems[2].Text); //lvI.SubItems.Add("$ " + Cpt.G_PRICE.ToString()); 
						}
						lvI.SubItems.Add(""); 
						lvI.SubItems.Add(""); 
						lvI.SubItems.Add(ALRM.lvAlrmPL.Items[i].SubItems[9].Text); 
						lvI.SubItems.Add(""); 
						lvI.SubItems.Add("ALRM"); 
						lvI.SubItems.Add(""); 
						
						//lvI.SubItems.Add(""); 
					}
				}
			}
			*/
		}

		private void btnOKchng_Click(object sender, System.EventArgs e)
		{
			if (lselI != -1)
			{
				lvDefOption.Items[lselI].SubItems[1].Text = tRef.Text;
				lvDefOption.Items[lselI].SubItems[2].Text = tdesc.Text;
				lvDefOption.Items[lselI].SubItems[3].Text = tqty.Text;
				lvDefOption.Items[lselI].SubItems[4].Text = tUprice.Text;
				lvDefOption.Items[lselI].SubItems[5].Text = tExt.Text; 
				lvDefOption.Items[lselI].SubItems[6].Text = tLT.Text;
				grp1.Height = 56; 
				lvDefOption.Items[lselI].BackColor = Color.WhiteSmoke;  
			}
		}

		private void ChngCancel_Click(object sender, System.EventArgs e)
		{
			lvDefOption.Items[lselI].BackColor = Color.WhiteSmoke;  
			grp1.Height = 56;
		}

		private void tqty_TextChanged(object sender, System.EventArgs e)
		{
			cal_SellExt();
		}
	
		private void cal_SellExt()
		{
		    //if (tXchng.Text == "") tXchng.Text = tXRATE.Text;
			if (tUprice.Text != "" && tqty.Text != "") 
                tExt.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tUprice.Text) * Tools.Conv_Dbl(tqty.Text), MainMDI.NB_DEC_AFF));  
		}

		private void tUprice_TextChanged(object sender, System.EventArgs e)
		{
			cal_SellExt();
		}

		private void minLT_TextChanged(object sender, System.EventArgs e)
		{
			maj_LT();
		}

		private void maj_LT()
		{   
			int mLT = (minLT.Text == "") ? 0 : Convert.ToInt32(minLT.Text);
			int xLT = (MaxLT.Text == "") ? 0 : Convert.ToInt32(MaxLT.Text);
			if (mLT < xLT) tLTime.Text = MainMDI.A00(mLT, 2) + "-" + MainMDI.A00(xLT, 2);  
			else MessageBox.Show("Min LeadTime must < MAX LeadTime !!!"); 
		}

		private void MaxLT_TextChanged(object sender, System.EventArgs e)
		{
			maj_LT();
		}

		private void menuItem2_Click_2(object sender, System.EventArgs e)
		{
			pick_option('D');
		}

		/*
		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			string lFrml = "";
			for (int y = 0; y < Charger.NB_FRML; y++)
			{
				if (dlg_arr_CAL_FRML[y] != "") 
					lFrml += " " + dlg_arr_CAL_FRML[y];  
				else break;
			}
			Alarms_EQ_Oth AlrmEQ = new Alarms_EQ_Oth(lFrml, true);
			AlrmEQ.ShowDialog();
			if (AlrmEQ.lSave.Text == "Y") 
			{   
				//rm_curr_ALRMs();
				for (int i = 0; i < AlrmEQ.lvAlrmPL.Items.Count; i++)
				{
					if (AlrmEQ.lvAlrmPL.Items[i].Checked)
					{
						ListViewItem lvI = lvDefOption.Items.Add("");
						lvI.SubItems.Add("");
						lvI.SubItems.Add(AlrmEQ.lvAlrmPL.Items[i].SubItems[1].Text);
						lvI.Checked = true; 
						//lvI.SubItems.Add("");
						//lvI.SubItems.Add(""); 
						if (AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text == "0" || AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text == "") 
						{
							lvI.SubItems.Add(""); 
							lvI.SubItems.Add("");
							lvI.SubItems.Add(""); 
						}
						else 
						{
							lvI.SubItems.Add("1"); 
							lvI.SubItems.Add(AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text);
							lvI.SubItems.Add(AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text); //lvI.SubItems.Add("$ " + Cpt.G_PRICE.ToString()); 
						}
						lvI.SubItems.Add(""); 
						lvI.SubItems.Add(""); 
						lvI.SubItems.Add(""); //lvI.SubItems.Add(AlrmEQ.lvAlrmPL.Items[i].SubItems[9].Text); 
						lvI.SubItems.Add(""); 
						lvI.SubItems.Add("ALRM"); 
						lvI.SubItems.Add(AlrmEQ.lvAlrmPL.Items[i].SubItems[3].Text); 
						
						//lvI.SubItems.Add(""); 
					}
				}
			}
			AlrmEQ.Close();
			AlrmEQ.Dispose(); 
		}
		*/

		private string get_ALRMID(string st)
		{
            int ipos = st.IndexOf("~~");
            if (ipos != -1) return st.Substring(ipos + 2, st.Length - (ipos + 2));
		    else return MainMDI.VIDE; 
		}

		private void Chng_ALL_ALRM(Alarms_EQ_Oth AlrmEQ)
		{
			for (int i = 0; i < lvDefOption.Items.Count; i++)
			{
				if (lvDefOption.Items[i].SubItems[10].Text.IndexOf("ALEQ_") != -1) 
				{
					string alrm_ID = get_ALRMID(lvDefOption.Items[i].SubItems[10].Text);
					if (alrm_ID != MainMDI.VIDE && alrm_ID.IndexOf("A_XTRN") == -1) 
					{
						for (int x = 0; x < AlrmEQ.lvAlrmPL.Items.Count; x++)
						{
							if (AlrmEQ.lvAlrmPL.Items[x].SubItems[10].Text == alrm_ID)
							{
								AlrmEQ.lvAlrmPL.Items[x].SubItems[10].Text = lvDefOption.Items[i].SubItems[10].Text;
								AlrmEQ.lvAlrmPL.Items[x].Checked = true;
							}
						}
					}
				}
			}
		}

		private void Chng_SEL_ALRM(Alarms_EQ_Oth AlrmEQ)
		{
			for (int i = 0; i < lvDefOption.SelectedItems.Count; i++)
			{
				if (lvDefOption.SelectedItems[i].SubItems[10].Text.IndexOf("ALEQ_") != -1) 
				{
					string alrm_ID = get_ALRMID(lvDefOption.SelectedItems[i].SubItems[10].Text);
					if (alrm_ID != MainMDI.VIDE && alrm_ID.IndexOf("A_XTRN") == -1) 
					{
						for (int x = 0; x < AlrmEQ.lvAlrmPL.Items.Count; x++)
						{
							if (AlrmEQ.lvAlrmPL.Items[x].SubItems[10].Text == alrm_ID)
							{
								AlrmEQ.lvAlrmPL.Items[x].SubItems[10].Text = lvDefOption.SelectedItems[i].SubItems[10].Text;
								AlrmEQ.lvAlrmPL.Items[x].Checked = true;
							}
						}
					}
				}
			}
		}

		private void return_ALRM(int i)
		{

		}		 
	
		void Add_ALARMS(string lFrml)
		{
			Alarms_EQ_Oth AlrmEQ = new Alarms_EQ_Oth(lFrml, false, 'M');
            if (lvDefOption.SelectedItems.Count == 0) Chng_ALL_ALRM(AlrmEQ);
			else Chng_SEL_ALRM(AlrmEQ);
			AlrmEQ.ShowDialog();

			if (AlrmEQ.lSave.Text == "Y") 
			{   
				lALRM.Text = "Y";
			
				//rm_curr_ALRMs();
				for (int i = 0; i < AlrmEQ.lvAlrmPL.Items.Count; i++)
				{
					if (AlrmEQ.lvAlrmPL.Items[i].Checked)
					{
						for (int def = 0; def < lvDefOption.Items.Count; def++)
						{
							if (lvDefOption.Items[def].SubItems[10].Text == AlrmEQ.lvAlrmPL.Items[i].SubItems[10].Text)
							{
								lvDefOption.Items[def].SubItems[2].Text = AlrmEQ.lvAlrmPL.Items[i].SubItems[1].Text;
								lvDefOption.Items[def].SubItems[10].Text = AlrmEQ.lvAlrmPL.Items[i].SubItems[10].Text;
								lvDefOption.Items[def].SubItems[11].Text = AlrmEQ.lvAlrmPL.Items[i].SubItems[3].Text;
								lvDefOption.Items[def].BackColor = MainMDI.CLR_A_Chng;
								val_Alrm_Done = true;
								def = lvDefOption.Items.Count;
							}
						}
					}
				}
			}
			AlrmEQ.Close();
			AlrmEQ.Dispose(); 
			tCellN.Focus();
		}

        void RE_Add_ALARMS_OFF(string lFrml)
        {
            Alarms_EQ_Oth AlrmEQ = new Alarms_EQ_Oth(lFrml, false, 'M');
            Chng_ALL_ALRM(AlrmEQ);

            //no aff of ALARM
            //AlrmEQ.ShowDialog();
            AlrmEQ.lSave.Text = "Y";
            if (AlrmEQ.lSave.Text == "Y")
            {
                lALRM.Text = "Y";

                //rm_curr_ALRMs();
                for (int i = 0; i < AlrmEQ.lvAlrmPL.Items.Count; i++)
                {
                    if (AlrmEQ.lvAlrmPL.Items[i].Checked)
                    {
                        for (int def = 0; def < lvDefOption.Items.Count; def++)
                        {
                            if (lvDefOption.Items[def].SubItems[10].Text == AlrmEQ.lvAlrmPL.Items[i].SubItems[10].Text)
                            {
                                lvDefOption.Items[def].SubItems[2].Text = AlrmEQ.lvAlrmPL.Items[i].SubItems[1].Text;
                                lvDefOption.Items[def].SubItems[10].Text = AlrmEQ.lvAlrmPL.Items[i].SubItems[10].Text;
                                lvDefOption.Items[def].SubItems[11].Text = AlrmEQ.lvAlrmPL.Items[i].SubItems[3].Text;
                                lvDefOption.Items[def].BackColor = MainMDI.CLR_A_Chng;
                                val_Alrm_Done = true;
                                def = lvDefOption.Items.Count;
                            }
                        }
                    }
                }
            }
            AlrmEQ.Close();
            AlrmEQ.Dispose();
            tCellN.Focus();
        }

		private void label3_Click(object sender, System.EventArgs e)
		{
			label3.BorderStyle = BorderStyle.Fixed3D;   
			cbIdc.Visible = false;
			label3.BorderStyle = BorderStyle.FixedSingle; 
		}

		private void cbIdctmp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			EquiV_IDC(cbIdctmp.Text);
		}

		private void optVrla_CheckedChanged(object sender, System.EventArgs e)
		{
			Maj_VPC('V');
			Maj_NBCELL(); 
		}

		private void lChrgREF_DoubleClick(object sender, System.EventArgs e)
		{
			grp1.Height = (grp1.Height == 56) ? 192 : 56;
		}

		private void button3_Click_2(object sender, System.EventArgs e)
		{
		    //label29.Text = Convert.ToString(Math.Round(0.25 + Convert.ToDouble(tdbl.Text), 2)) + " || " + Convert.ToString(Math.Round(Convert.ToDouble(tdbl.Text) - 0.25, 2));
		    //label30.Text = Math.Ceiling(0.25 + Convert.ToDouble(tdbl.Text)).ToString() + " || " + Math.Ceiling(-0.25 + Convert.ToDouble(tdbl.Text)).ToString(); 
		    label29.Text = MainMDI.Ceil(tdbl.Text, tSig.Text).ToString();
		}

		private void value_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tdbl_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void pictureBox2_DragOver(object sender, System.Windows.Forms.DragEventArgs e)
		{
			
		}

		private void pictureBox2_MouseHover(object sender, System.EventArgs e)
		{
			linkLabel1.Text = "this is ALARM !!";
		}

		private void pictureBox2_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			linkLabel1.Text = "move.....this is ALARM !!";
		}

		private string cal_VCS(string NME)
		{
			CHRGR = new Charger(-1, lFV.Text, cbPxx.Text, cbPhs.Text, cbVdc.Text, cbIdc.Text, tVac.Text, tVdcMax.Text);
			Cpt = new Component();
			return Cpt.Cal_VCS(0, NME).ToString();
		}

		private string cal_CPT(long lcptID, string cptName)
		{
			string st = "";
			if (lcptID == -1) 
			{
				st = MainMDI.Find_One_Field("select Component_ID from COMPNT_LIST where COMPONENT_REF='" + cptName + "'"); 
				lcptID = (st != MainMDI.VIDE) ? Convert.ToInt32(st) : -1;
			}
			if (lcptID != -1) 
			{
				CHRGR = new Charger(-1, lFV.Text, cbPxx.Text, cbPhs.Text, cbVdc.Text, cbIdc.Text, tVac.Text, tVdcMax.Text);
				Cpt = new Component();
				Cpt.CPT_COST(lcptID);  
				st = (Cpt.G_Desc.IndexOf("~~") < 1) ? MainMDI.VIDE : Cpt.G_Desc.Substring(0, Cpt.G_Desc.IndexOf("~~"));  
				return st; //+ " || " + Cpt.CAP2 + " || " + Cpt.CAP3 + " || " + Cpt.CAP4 + " || " + Cpt.CAP5 + " || " + Cpt.CAP6 + " || " + Cpt.CAP7 + " || " + Cpt.G_Desc  + " || " + Cpt.G_PRICE;
			}
			return MainMDI.VIDE;
		}

		private string  cal_CPTOLLD(long lcptID, string cptName)
		{
			if (lcptID == -1) 
			{
				string st = MainMDI.Find_One_Field("select Component_ID from COMPNT_LIST where COMPONENT_REF='" + cptName + "'"); 
				lcptID = (st != MainMDI.VIDE) ? Convert.ToInt32(st) : -1;
			}
			if (lcptID != -1) 
			{
				CHRGR = new Charger(-1, lFV.Text, cbPxx.Text, cbPhs.Text, cbVdc.Text, cbIdc.Text, tVac.Text, tVdcMax.Text);
				Cpt = new Component();
				Cpt.CPT_COST(lcptID);  
				return Cpt.CAP1;
			}
			return MainMDI.VIDE;
		}

		private void LvTV_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lvCoef_DoubleClick(object sender, System.EventArgs e)
		{
			grp1.Visible =! grp1.Visible;
			tModif_CH.Width = grp1.Width - 28;
			tModif_CHNew.Width = tModif_CH.Width;
		}

		private void lvCoef_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tModif_CHNew_TextChanged(object sender, System.EventArgs e)
		{
			//MessageBox.Show("L=" + tModif_CHNew.Width.ToString());     
		}

		private void groupBox4_Enter(object sender, System.EventArgs e)
		{
		
		}

        private void linkFRMLS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        /*
        private void linkFRMLS_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            XPORT_FRMLS_CHRG();
        }

        private void fill_Def_options(string m_vdcMax, string m_Vac)
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

            while (Oreadr.Read())
            {
                if (debut == 0)
                {
                    CHRGR = new Charger(0, lFV.Text, cbPxx.Text.Substring(0, 5), cbPhs.Text, cbVdc.Text, cbIdc.Text, tVac.Text, tVdcMax.Text);
                    debut = 1;
                }
                Cpt = new Component();

                string tt = Cpt.Cal_chrg_CostADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()), "C");
                lIprim.Text = Cpt.Cal_VCS(0, "C_IPRIM");
                lhrtZMRK.Text = Cpt.Cal_VCS(0, "C_HRTZ" + lhrtz.Text);

                if (tt == MainMDI.VIDE) MessageBox.Show("This default option: " + Oreadr["COMPONENT_REF"].ToString() + " was not found  !!!!");
                else
                {
                    if (ndxCxx == 0) addchRef();
                    if (Cpt.G_PRICE != Charger.VIDE)
                    {
                        //ListViewItem lvI = lvDefOption.Items.Add("");
                        //lvI.Checked = true; 
                        //string stt = (MainMDI.Lang == 0) ? Cpt.CAP4.ToString() + ", " + Cpt.CAP5.ToString() + ", " + Cpt.CAP6.ToString() : Cpt.CAP7.ToString() + ", " + Cpt.CAP8.ToString() + ", " + Cpt.CAP9.ToString(); 

                        //string stt = Cpt.CAP4.ToString() + ", " + Cpt.CAP5.ToString() + ", " + Cpt.CAP6.ToString();
                        //lvI.SubItems.Add(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()));
                        //lvI.SubItems.Add(Cpt.G_Desc.ToString()); 
                        string stt = MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()) + "=";
                        stt += (Cpt.CAP4 == MainMDI.VIDE) ? "" : " " + Cpt.CAP4;
                        stt += (Cpt.CAP5 == MainMDI.VIDE) ? "" : " " + Cpt.CAP5;
                        stt += (Cpt.CAP6 == MainMDI.VIDE) ? "" : " " + Cpt.CAP6;
                        stt += (Cpt.CAP7 == MainMDI.VIDE) ? "" : " " + Cpt.CAP7;
                        //stt += (Oreadr["CAP4fr"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAP4fr"].ToString();
                        //stt += (Oreadr["CAP5fr"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAP5fr"].ToString();
                        //stt += (Oreadr["CAP6fr"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAP6fr"].ToString();
                        //stt += (Oreadr["CAP7fr"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAP7fr"].ToString();

                        arC_xxx[ndxCxx, 0] = stt;
                        arC_xxx[ndxCxx++, 1] = Oreadr["COMPONENT_REF"].ToString();
                        //lvI.SubItems.Add(stt); //+ " -->" + Oreadr["Component_Name"].ToString());
                        //lvI.SubItems.Add(tPxxQty.Text); 
                        ///lvI.SubItems.Add("0"); //lvI.SubItems.Add("$ " + Cpt.G_PRICE.ToString()); 
                        //lvI.SubItems.Add("0"); 
                        //lvI.SubItems.Add(tLTime.Text); 
                        //lvI.SubItems.Add(Oreadr["CatName1"].ToString() + "=" + Cpt.CAP1.ToString()); 
                        //if (Oreadr["CatName2"].ToString() != Charger.VIDE) lvI.SubItems.Add(Oreadr["CatName2"].ToString() + "=" + Cpt.CAP2.ToString()); 
                        //else lvI.SubItems.Add(""); 
                        //if (Oreadr["CatName3"].ToString() != Charger.VIDE) lvI.SubItems.Add(Oreadr["CatName3"].ToString() + "=" + Cpt.CAP3.ToString()); 
                        //else lvI.SubItems.Add(""); 
                        //lvI.SubItems.Add(Oreadr["COMPONENT_REF"].ToString()); 
                        //lvI.SubItems.Add(Oreadr["Component_Name"].ToString());
                        //lvI.SubItems.Add(Cpt.G_Desc);
                        //if (valSTD_changed()) lvI.SubItems[0].ForeColor = Color.Red;
                        //lvI.Checked = true;
                        //Uncheck by default TB123/TB45 requested by Sam on: 13-12-2005
                        //if (Oreadr["COMPONENT_REF"].ToString().IndexOf("TB-") != -1 || Oreadr["COMPONENT_REF"].ToString().IndexOf("EN1") != -1) lvI.Checked = false;
                        //
                    }
                }
            }
            //lIprim.Text = Cpt.Cal_VCS(0, "C_IPRIM");

            if (lvDefOption.Items.Count != 0) add_Modif_STDFeat();
            OConn.Close();
            this.Cursor = Cursors.Default;
            //t2.Text = System.DateTime.Now.Second.ToString(); 
        }

        private void XPORT_FRMLS_CHRG()
        {
            //init arrays
            val_Alrm_Done = false;
            for (int x = 0; x < xxCount; x++) for (int j = 0; j < 3; j++) arC_xxx[x, j] = "";
            for (int i = 0; i < Charger.NB_FRML; i++) dlg_arr_CAL_FRML[i] = "";
            ndxCxx = 0;
            if (Validate_Charger())
            {
                if (valSTD_changed() && In_code) MessageBox.Show("Check PRICES on RED lines , since standard values were changed  !!!");
                string lFrml = "";
                for (int y = 0; y < Charger.NB_FRML; y++)
                {
                    if (dlg_arr_CAL_FRML[y] != "")
                        lFrml += " " + dlg_arr_CAL_FRML[y];
                    else break;
                }
                lFrml += " C_MODEL||" + lmdel.Text;
                fill_OTV();
                lFrml += " " + lOth_TV;
                arC_xxx[ndxCxx, 2] = lFrml;
                arC_xxx[ndxCxx++, 1] = "C_MODEL||" + lmdel.Text;
                //arCxx_Disp();
                Maj_LV();
                load_TV(lFrml);
                tModif_CHNew.Text = lFrml;
            }
        }
        */
	}
}