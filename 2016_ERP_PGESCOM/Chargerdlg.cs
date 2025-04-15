using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb ;
using System.Data.SqlClient; 
using EAHLibs;
namespace PGESCOM
{
	/// <summary>
	/// Summary description for Chargerdlg.
	/// </summary>
	public class Chargerdlg : System.Windows.Forms.Form
	{
		private Charger CHRGR;
		private Component Cpt;
		private Lib1 Tools = new Lib1();
		private string In_User; 
		public string lOth_TV="";
		private int L;
		private int lselI;
		public  string[] dlg_arr_CAL_FRML  = new string[Charger.NB_FRML];
		private int dlg_arr_frml_NDX=0;

		private char In_code;
	//	private string MainMDI.M_stCon;
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
		internal System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label lNcelCoef;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.ComboBox cbVCS;
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
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Label lUsr_tvpcEq;
		private System.Windows.Forms.Label lUsr_tvpcF;
		private System.Windows.Forms.Label label26;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label oldvdcMAX;
		private System.Windows.Forms.Label oldMin_EQFLT;
		private System.Windows.Forms.Label lstdVDCMAXoo;
		private System.Windows.Forms.Label lstdVDCMINoo;
		private System.Windows.Forms.Label lstdvdcMin;
		private System.Windows.Forms.Label lstdvdcMax;
		private System.Windows.Forms.Label lstdVAC;
		public System.Windows.Forms.Label lstdCellN;
		internal System.Windows.Forms.Button btnMovestd;
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
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.LinkLabel LnkValidate;
		private System.Windows.Forms.LinkLabel lnkAlarm;
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
		public System.Windows.Forms.Label lALRM;
		public System.Windows.Forms.ComboBox cbIdctmp;
		private System.Windows.Forms.RadioButton optVrla;
		private System.Windows.Forms.TextBox tdbl;
		internal System.Windows.Forms.Button button3;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.TextBox tSig;
		private System.Windows.Forms.Label lIsh;
		private System.Windows.Forms.Label lVSECLL;
		private System.Windows.Forms.Label lVSECLN;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.Label lIprim;
		private System.Windows.Forms.Label lW2;
		private System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.ComboBox cbCPTs;
		internal System.Windows.Forms.Button button4;
		private System.Windows.Forms.Label lresCpt;
		private System.Windows.Forms.Label lresVCS;
		private System.Windows.Forms.Label lcptID;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.ColumnHeader OTI_LID;
		private System.Windows.Forms.ColumnHeader Pref;
		private System.Windows.Forms.ColumnHeader Fname;
		private System.Windows.Forms.ColumnHeader inc;
		public System.Windows.Forms.ListView lvOTI;
		private System.Windows.Forms.GroupBox grpOTI;
		private System.Windows.Forms.ColumnHeader Otis_Link1;
		private System.Windows.Forms.ColumnHeader Otis_Link2;
		private System.Windows.Forms.ColumnHeader Otis_Link3;
		private System.Windows.Forms.ColumnHeader Otis_Link4;
        private GroupBox groupBox11;
        private Label label29;
        private TextBox tRPL;
        public Label label31;
        private Button btn_inducta;
        private Button button5;
        private TextBox ttttt1;
        private TextBox tPhs;
        private TextBox tV;
        private TextBox tI;
        private Label label32;
        public ComboBox cbDesign;
        private Label ldesign;
        private Label lsep;
        public ComboBox cbDesign3;
        public ComboBox cbDesign2;
        private Label ldesign3;
        private Label ldesign2;
        private Label lsep3;
        private Label lsep2;
        private Label txcbPxx;
		//	private System.Windows.Forms.Label lselI;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Chargerdlg(char X_code, string X_stcon)
		{
			//
			// Required for Windows Form Designer support
			//

			InitializeComponent();
			t1.Text =DateTime.Now.Second.ToString()+" Init";

            // ---   U    S  M   IT
            ini_cb(1);
            ini_cb(2);
            ini_cb(3);
 
			In_code =X_code;
			MainMDI.M_stCon =X_stcon ;
			In_User = MainMDI.User ; 
			fill_All_cb("cvi");
			fill_cbVCS();
			fill_cbCPTs();
			t2.Text =DateTime.Now.Second.ToString()+" Init";
			L=MainMDI.Lang;
			minLT.Text ="04"; MaxLT.Text ="06"; 
			tLTime.Text = minLT.Text + "-" + MaxLT.Text ; 
			load_Prof(); 
			load_OTI_LIST();
			grp1.Height = 48;
		//	grpOTI.Visible =false;




			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Chargerdlg));
            this.gbxCalc = new System.Windows.Forms.GroupBox();
            this.grpOTI = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
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
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnMovestd = new System.Windows.Forms.Button();
            this.lstdVDCMAXoo = new System.Windows.Forms.Label();
            this.lstdVDCMINoo = new System.Windows.Forms.Label();
            this.lUsr_tvpcEq = new System.Windows.Forms.Label();
            this.lUsr_tvpcF = new System.Windows.Forms.Label();
            this.lstdvdcMin = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.lstdvdcMax = new System.Windows.Forms.Label();
            this.lstdVAC = new System.Windows.Forms.Label();
            this.lstdCellN = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.btnLprofile = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.tPhs = new System.Windows.Forms.TextBox();
            this.tV = new System.Windows.Forms.TextBox();
            this.tI = new System.Windows.Forms.TextBox();
            this.ttttt1 = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.lIprim = new System.Windows.Forms.Label();
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
            this.btnSProfile = new System.Windows.Forms.Button();
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
            this.txcbPxx = new System.Windows.Forms.Label();
            this.ldesign3 = new System.Windows.Forms.Label();
            this.ldesign2 = new System.Windows.Forms.Label();
            this.cbDesign3 = new System.Windows.Forms.ComboBox();
            this.cbDesign2 = new System.Windows.Forms.ComboBox();
            this.label32 = new System.Windows.Forms.Label();
            this.cbDesign = new System.Windows.Forms.ComboBox();
            this.ldesign = new System.Windows.Forms.Label();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.tRPL = new System.Windows.Forms.TextBox();
            this.label31 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tLTime = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.MaxLT = new System.Windows.Forms.TextBox();
            this.ll = new System.Windows.Forms.Label();
            this.minLT = new System.Windows.Forms.TextBox();
            this.lFTTT = new System.Windows.Forms.Label();
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
            this.cbXXX = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPhs = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cbPxx = new System.Windows.Forms.ComboBox();
            this.cbVdc = new System.Windows.Forms.ComboBox();
            this.cbIdctmp = new System.Windows.Forms.ComboBox();
            this.cbIdc = new System.Windows.Forms.ComboBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tPxxQty = new System.Windows.Forms.TextBox();
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
            this.lsep3 = new System.Windows.Forms.Label();
            this.lsep2 = new System.Windows.Forms.Label();
            this.lChrgREF = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.lsep = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lresCpt = new System.Windows.Forms.Label();
            this.button4 = new System.Windows.Forms.Button();
            this.cbCPTs = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.lW2 = new System.Windows.Forms.Label();
            this.lIsh = new System.Windows.Forms.Label();
            this.lVSECLL = new System.Windows.Forms.Label();
            this.lVSECLN = new System.Windows.Forms.Label();
            this.label30 = new System.Windows.Forms.Label();
            this.lcptID = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tSig = new System.Windows.Forms.TextBox();
            this.tdbl = new System.Windows.Forms.TextBox();
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
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lnkAlarm = new System.Windows.Forms.LinkLabel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LnkValidate = new System.Windows.Forms.LinkLabel();
            this.lDescc = new System.Windows.Forms.Label();
            this.lRiple = new System.Windows.Forms.Label();
            this.lSave = new System.Windows.Forms.Label();
            this.t1 = new System.Windows.Forms.Label();
            this.t2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lNcelCoef = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.cbVCS = new System.Windows.Forms.ComboBox();
            this.lresVCS = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.lcptName = new System.Windows.Forms.Label();
            this.lCost = new System.Windows.Forms.Label();
            this.btn_inducta = new System.Windows.Forms.Button();
            this.gbxCalc.SuspendLayout();
            this.grpOTI.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox11.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            this.grp1.SuspendLayout();
            this.groupBox10.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // gbxCalc
            // 
            this.gbxCalc.Controls.Add(this.grpOTI);
            this.gbxCalc.Controls.Add(this.groupBox7);
            this.gbxCalc.Controls.Add(this.btnLprofile);
            this.gbxCalc.Controls.Add(this.groupBox4);
            this.gbxCalc.Controls.Add(this.btnSProfile);
            this.gbxCalc.Controls.Add(this.groupBox3);
            this.gbxCalc.Controls.Add(this.groupBox2);
            this.gbxCalc.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxCalc.Location = new System.Drawing.Point(0, 0);
            this.gbxCalc.Name = "gbxCalc";
            this.gbxCalc.Size = new System.Drawing.Size(993, 170);
            this.gbxCalc.TabIndex = 78;
            this.gbxCalc.TabStop = false;
            this.gbxCalc.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // grpOTI
            // 
            this.grpOTI.Controls.Add(this.button5);
            this.grpOTI.Controls.Add(this.lvOTI);
            this.grpOTI.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOTI.Location = new System.Drawing.Point(833, 8);
            this.grpOTI.Name = "grpOTI";
            this.grpOTI.Size = new System.Drawing.Size(152, 144);
            this.grpOTI.TabIndex = 186;
            this.grpOTI.TabStop = false;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(23, 120);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(121, 24);
            this.button5.TabIndex = 307;
            this.button5.Text = "SYSPRO COST";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
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
            this.lvOTI.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOTI.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvOTI.FullRowSelect = true;
            this.lvOTI.GridLines = true;
            this.lvOTI.Location = new System.Drawing.Point(3, 16);
            this.lvOTI.Name = "lvOTI";
            this.lvOTI.Size = new System.Drawing.Size(146, 125);
            this.lvOTI.TabIndex = 103;
            this.lvOTI.UseCompatibleStateImageBehavior = false;
            this.lvOTI.View = System.Windows.Forms.View.Details;
            // 
            // inc
            // 
            this.inc.Text = " options to Include";
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
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnMovestd);
            this.groupBox7.Controls.Add(this.lstdVDCMAXoo);
            this.groupBox7.Controls.Add(this.lstdVDCMINoo);
            this.groupBox7.Controls.Add(this.lUsr_tvpcEq);
            this.groupBox7.Controls.Add(this.lUsr_tvpcF);
            this.groupBox7.Controls.Add(this.lstdvdcMin);
            this.groupBox7.Controls.Add(this.label26);
            this.groupBox7.Controls.Add(this.lstdvdcMax);
            this.groupBox7.Controls.Add(this.lstdVAC);
            this.groupBox7.Controls.Add(this.lstdCellN);
            this.groupBox7.Controls.Add(this.label23);
            this.groupBox7.Controls.Add(this.label13);
            this.groupBox7.Controls.Add(this.label21);
            this.groupBox7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox7.Location = new System.Drawing.Point(432, 8);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(128, 144);
            this.groupBox7.TabIndex = 184;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "PRIMAX Standards";
            // 
            // btnMovestd
            // 
            this.btnMovestd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnMovestd.Location = new System.Drawing.Point(8, 120);
            this.btnMovestd.Name = "btnMovestd";
            this.btnMovestd.Size = new System.Drawing.Size(112, 20);
            this.btnMovestd.TabIndex = 196;
            this.btnMovestd.Text = "Default Values >>";
            this.btnMovestd.Click += new System.EventHandler(this.button3_Click);
            // 
            // lstdVDCMAXoo
            // 
            this.lstdVDCMAXoo.BackColor = System.Drawing.Color.Chocolate;
            this.lstdVDCMAXoo.ForeColor = System.Drawing.Color.Black;
            this.lstdVDCMAXoo.Location = new System.Drawing.Point(40, 120);
            this.lstdVDCMAXoo.Name = "lstdVDCMAXoo";
            this.lstdVDCMAXoo.Size = new System.Drawing.Size(16, 16);
            this.lstdVDCMAXoo.TabIndex = 195;
            this.lstdVDCMAXoo.Visible = false;
            // 
            // lstdVDCMINoo
            // 
            this.lstdVDCMINoo.BackColor = System.Drawing.Color.Chocolate;
            this.lstdVDCMINoo.ForeColor = System.Drawing.Color.Black;
            this.lstdVDCMINoo.Location = new System.Drawing.Point(8, 120);
            this.lstdVDCMINoo.Name = "lstdVDCMINoo";
            this.lstdVDCMINoo.Size = new System.Drawing.Size(20, 16);
            this.lstdVDCMINoo.TabIndex = 194;
            this.lstdVDCMINoo.Visible = false;
            // 
            // lUsr_tvpcEq
            // 
            this.lUsr_tvpcEq.BackColor = System.Drawing.Color.Chocolate;
            this.lUsr_tvpcEq.ForeColor = System.Drawing.Color.Black;
            this.lUsr_tvpcEq.Location = new System.Drawing.Point(320, 16);
            this.lUsr_tvpcEq.Name = "lUsr_tvpcEq";
            this.lUsr_tvpcEq.Size = new System.Drawing.Size(8, 16);
            this.lUsr_tvpcEq.TabIndex = 193;
            this.lUsr_tvpcEq.Visible = false;
            // 
            // lUsr_tvpcF
            // 
            this.lUsr_tvpcF.BackColor = System.Drawing.Color.Chocolate;
            this.lUsr_tvpcF.ForeColor = System.Drawing.Color.Black;
            this.lUsr_tvpcF.Location = new System.Drawing.Point(304, 16);
            this.lUsr_tvpcF.Name = "lUsr_tvpcF";
            this.lUsr_tvpcF.Size = new System.Drawing.Size(8, 16);
            this.lUsr_tvpcF.TabIndex = 192;
            this.lUsr_tvpcF.Visible = false;
            // 
            // lstdvdcMin
            // 
            this.lstdvdcMin.BackColor = System.Drawing.Color.AliceBlue;
            this.lstdvdcMin.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstdvdcMin.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstdvdcMin.ForeColor = System.Drawing.Color.Black;
            this.lstdvdcMin.Location = new System.Drawing.Point(64, 80);
            this.lstdvdcMin.Name = "lstdvdcMin";
            this.lstdvdcMin.Size = new System.Drawing.Size(56, 16);
            this.lstdvdcMin.TabIndex = 191;
            this.lstdvdcMin.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.Color.Red;
            this.label26.Location = new System.Drawing.Point(8, 80);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(56, 16);
            this.label26.TabIndex = 190;
            this.label26.Text = "Vdc Min:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lstdvdcMax
            // 
            this.lstdvdcMax.BackColor = System.Drawing.Color.AliceBlue;
            this.lstdvdcMax.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstdvdcMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstdvdcMax.ForeColor = System.Drawing.Color.Black;
            this.lstdvdcMax.Location = new System.Drawing.Point(64, 96);
            this.lstdvdcMax.Name = "lstdvdcMax";
            this.lstdvdcMax.Size = new System.Drawing.Size(56, 16);
            this.lstdvdcMax.TabIndex = 189;
            this.lstdvdcMax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstdVAC
            // 
            this.lstdVAC.BackColor = System.Drawing.Color.AliceBlue;
            this.lstdVAC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstdVAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstdVAC.ForeColor = System.Drawing.Color.Black;
            this.lstdVAC.Location = new System.Drawing.Point(64, 48);
            this.lstdVAC.Name = "lstdVAC";
            this.lstdVAC.Size = new System.Drawing.Size(56, 16);
            this.lstdVAC.TabIndex = 188;
            this.lstdVAC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lstdCellN
            // 
            this.lstdCellN.BackColor = System.Drawing.Color.AliceBlue;
            this.lstdCellN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lstdCellN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstdCellN.ForeColor = System.Drawing.Color.Black;
            this.lstdCellN.Location = new System.Drawing.Point(64, 32);
            this.lstdCellN.Name = "lstdCellN";
            this.lstdCellN.Size = new System.Drawing.Size(56, 16);
            this.lstdCellN.TabIndex = 187;
            this.lstdCellN.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lstdCellN.Click += new System.EventHandler(this.lstdCellN_Click);
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Red;
            this.label23.Location = new System.Drawing.Point(8, 96);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(56, 16);
            this.label23.TabIndex = 186;
            this.label23.Text = "Vdc Max:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(32, 48);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(32, 16);
            this.label13.TabIndex = 185;
            this.label13.Text = "VAC";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(24, 32);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(40, 16);
            this.label21.TabIndex = 184;
            this.label21.Text = "Cell #";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnLprofile
            // 
            this.btnLprofile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLprofile.Location = new System.Drawing.Point(64, 151);
            this.btnLprofile.Name = "btnLprofile";
            this.btnLprofile.Size = new System.Drawing.Size(72, 16);
            this.btnLprofile.TabIndex = 200;
            this.btnLprofile.Text = "Load Profile";
            this.btnLprofile.Visible = false;
            this.btnLprofile.Click += new System.EventHandler(this.btnLprofile_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.tPhs);
            this.groupBox4.Controls.Add(this.tV);
            this.groupBox4.Controls.Add(this.tI);
            this.groupBox4.Controls.Add(this.ttttt1);
            this.groupBox4.Controls.Add(this.label27);
            this.groupBox4.Controls.Add(this.lIprim);
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
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.Location = new System.Drawing.Point(566, 8);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(264, 156);
            this.groupBox4.TabIndex = 141;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Calculated Values";
            // 
            // tPhs
            // 
            this.tPhs.BackColor = System.Drawing.Color.Black;
            this.tPhs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPhs.ForeColor = System.Drawing.Color.White;
            this.tPhs.Location = new System.Drawing.Point(6, 132);
            this.tPhs.Name = "tPhs";
            this.tPhs.Size = new System.Drawing.Size(36, 20);
            this.tPhs.TabIndex = 301;
            this.tPhs.Text = "0";
            this.tPhs.Visible = false;
            // 
            // tV
            // 
            this.tV.BackColor = System.Drawing.Color.Black;
            this.tV.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tV.ForeColor = System.Drawing.Color.White;
            this.tV.Location = new System.Drawing.Point(45, 132);
            this.tV.Name = "tV";
            this.tV.Size = new System.Drawing.Size(48, 20);
            this.tV.TabIndex = 300;
            this.tV.Text = "0";
            this.tV.Visible = false;
            // 
            // tI
            // 
            this.tI.BackColor = System.Drawing.Color.Black;
            this.tI.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tI.ForeColor = System.Drawing.Color.White;
            this.tI.Location = new System.Drawing.Point(99, 132);
            this.tI.Name = "tI";
            this.tI.Size = new System.Drawing.Size(48, 20);
            this.tI.TabIndex = 299;
            this.tI.Text = "0";
            this.tI.Visible = false;
            // 
            // ttttt1
            // 
            this.ttttt1.BackColor = System.Drawing.Color.Red;
            this.ttttt1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ttttt1.ForeColor = System.Drawing.Color.White;
            this.ttttt1.Location = new System.Drawing.Point(171, 132);
            this.ttttt1.Name = "ttttt1";
            this.ttttt1.Size = new System.Drawing.Size(88, 20);
            this.ttttt1.TabIndex = 298;
            this.ttttt1.Text = "0";
            this.ttttt1.Visible = false;
            // 
            // label27
            // 
            this.label27.Location = new System.Drawing.Point(128, 8);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(64, 16);
            this.label27.TabIndex = 297;
            this.label27.Text = "Prim. AMP:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lIprim
            // 
            this.lIprim.BackColor = System.Drawing.SystemColors.Control;
            this.lIprim.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lIprim.ForeColor = System.Drawing.Color.Red;
            this.lIprim.Location = new System.Drawing.Point(192, 8);
            this.lIprim.Name = "lIprim";
            this.lIprim.Size = new System.Drawing.Size(64, 16);
            this.lIprim.TabIndex = 296;
            this.lIprim.Text = "0";
            // 
            // oldMin_EQFLT
            // 
            this.oldMin_EQFLT.BackColor = System.Drawing.Color.Chocolate;
            this.oldMin_EQFLT.ForeColor = System.Drawing.Color.Black;
            this.oldMin_EQFLT.Location = new System.Drawing.Point(48, 8);
            this.oldMin_EQFLT.Name = "oldMin_EQFLT";
            this.oldMin_EQFLT.Size = new System.Drawing.Size(16, 16);
            this.oldMin_EQFLT.TabIndex = 198;
            this.oldMin_EQFLT.Visible = false;
            // 
            // oldvdcMAX
            // 
            this.oldvdcMAX.BackColor = System.Drawing.Color.Chocolate;
            this.oldvdcMAX.ForeColor = System.Drawing.Color.Black;
            this.oldvdcMAX.Location = new System.Drawing.Point(8, 16);
            this.oldvdcMAX.Name = "oldvdcMAX";
            this.oldvdcMAX.Size = new System.Drawing.Size(16, 16);
            this.oldvdcMAX.TabIndex = 197;
            this.oldvdcMAX.Visible = false;
            // 
            // oldVdc
            // 
            this.oldVdc.BackColor = System.Drawing.Color.Chocolate;
            this.oldVdc.ForeColor = System.Drawing.Color.Black;
            this.oldVdc.Location = new System.Drawing.Point(80, 13);
            this.oldVdc.Name = "oldVdc";
            this.oldVdc.Size = new System.Drawing.Size(24, 16);
            this.oldVdc.TabIndex = 196;
            this.oldVdc.Visible = false;
            this.oldVdc.Click += new System.EventHandler(this.oldVdc_Click);
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Location = new System.Drawing.Point(136, 73);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(56, 16);
            this.label14.TabIndex = 162;
            this.label14.Text = "VEqual:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tVEQL
            // 
            this.tVEQL.BackColor = System.Drawing.Color.AliceBlue;
            this.tVEQL.Location = new System.Drawing.Point(192, 71);
            this.tVEQL.Name = "tVEQL";
            this.tVEQL.ReadOnly = true;
            this.tVEQL.Size = new System.Drawing.Size(64, 20);
            this.tVEQL.TabIndex = 161;
            this.tVEQL.TextChanged += new System.EventHandler(this.tVEQL_TextChanged);
            this.tVEQL.DoubleClick += new System.EventHandler(this.tVEQL_DoubleClick);
            // 
            // label17
            // 
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.Location = new System.Drawing.Point(136, 53);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 16);
            this.label17.TabIndex = 160;
            this.label17.Text = "VFloat:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tVFLOAT
            // 
            this.tVFLOAT.BackColor = System.Drawing.Color.AliceBlue;
            this.tVFLOAT.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tVFLOAT.Location = new System.Drawing.Point(192, 51);
            this.tVFLOAT.Name = "tVFLOAT";
            this.tVFLOAT.ReadOnly = true;
            this.tVFLOAT.Size = new System.Drawing.Size(64, 20);
            this.tVFLOAT.TabIndex = 159;
            this.tVFLOAT.TextChanged += new System.EventHandler(this.tVFLOAT_TextChanged);
            this.tVFLOAT.DoubleClick += new System.EventHandler(this.tVFLOAT_DoubleClick);
            // 
            // Uchng
            // 
            this.Uchng.BackColor = System.Drawing.Color.Lime;
            this.Uchng.ForeColor = System.Drawing.Color.Black;
            this.Uchng.Location = new System.Drawing.Point(176, 16);
            this.Uchng.Name = "Uchng";
            this.Uchng.Size = new System.Drawing.Size(16, 16);
            this.Uchng.TabIndex = 158;
            this.Uchng.Text = "N";
            this.Uchng.Visible = false;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(136, 113);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(56, 16);
            this.label19.TabIndex = 157;
            this.label19.Text = "Idc Max:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tIdcMax
            // 
            this.tIdcMax.BackColor = System.Drawing.Color.AliceBlue;
            this.tIdcMax.Location = new System.Drawing.Point(192, 111);
            this.tIdcMax.Name = "tIdcMax";
            this.tIdcMax.ReadOnly = true;
            this.tIdcMax.Size = new System.Drawing.Size(64, 20);
            this.tIdcMax.TabIndex = 156;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(144, 93);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 16);
            this.label20.TabIndex = 155;
            this.label20.Text = "Idc Min:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tIdcMin
            // 
            this.tIdcMin.BackColor = System.Drawing.Color.AliceBlue;
            this.tIdcMin.Location = new System.Drawing.Point(192, 91);
            this.tIdcMin.Name = "tIdcMin";
            this.tIdcMin.ReadOnly = true;
            this.tIdcMin.Size = new System.Drawing.Size(64, 20);
            this.tIdcMin.TabIndex = 154;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.Location = new System.Drawing.Point(0, 113);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 16);
            this.label24.TabIndex = 153;
            this.label24.Text = "Vdc Max:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tVdcMax
            // 
            this.tVdcMax.BackColor = System.Drawing.Color.Lavender;
            this.tVdcMax.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tVdcMax.Location = new System.Drawing.Point(64, 111);
            this.tVdcMax.Name = "tVdcMax";
            this.tVdcMax.Size = new System.Drawing.Size(64, 20);
            this.tVdcMax.TabIndex = 152;
            this.tVdcMax.TextChanged += new System.EventHandler(this.tVdcMax_TextChanged_1);
            // 
            // label25
            // 
            this.label25.Location = new System.Drawing.Point(8, 93);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(56, 16);
            this.label25.TabIndex = 151;
            this.label25.Text = "Vdc Min:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tvdcMin
            // 
            this.tvdcMin.BackColor = System.Drawing.Color.AliceBlue;
            this.tvdcMin.Location = new System.Drawing.Point(64, 91);
            this.tvdcMin.Name = "tvdcMin";
            this.tvdcMin.ReadOnly = true;
            this.tvdcMin.Size = new System.Drawing.Size(64, 20);
            this.tvdcMin.TabIndex = 150;
            this.tvdcMin.TextChanged += new System.EventHandler(this.tvdcMin_TextChanged_1);
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(152, 33);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 149;
            this.label8.Text = "VAC";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tVac
            // 
            this.tVac.BackColor = System.Drawing.Color.Lavender;
            this.tVac.Location = new System.Drawing.Point(192, 31);
            this.tVac.Name = "tVac";
            this.tVac.Size = new System.Drawing.Size(64, 20);
            this.tVac.TabIndex = 148;
            this.tVac.TextChanged += new System.EventHandler(this.tVac_TextChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Location = new System.Drawing.Point(0, 73);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 16);
            this.label9.TabIndex = 147;
            this.label9.Text = "Vpc Equal:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tvpcEq
            // 
            this.tvpcEq.BackColor = System.Drawing.Color.Lavender;
            this.tvpcEq.Location = new System.Drawing.Point(64, 71);
            this.tvpcEq.Name = "tvpcEq";
            this.tvpcEq.Size = new System.Drawing.Size(64, 20);
            this.tvpcEq.TabIndex = 146;
            this.tvpcEq.TextChanged += new System.EventHandler(this.tvpcEq_TextChanged);
            this.tvpcEq.DoubleClick += new System.EventHandler(this.tvpcEq_DoubleClick);
            this.tvpcEq.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tvpcEq_KeyPress);
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(8, 53);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 145;
            this.label11.Text = "Vpc Float:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tvpcF
            // 
            this.tvpcF.BackColor = System.Drawing.Color.Lavender;
            this.tvpcF.Location = new System.Drawing.Point(64, 51);
            this.tvpcF.Name = "tvpcF";
            this.tvpcF.Size = new System.Drawing.Size(64, 20);
            this.tvpcF.TabIndex = 144;
            this.tvpcF.TextChanged += new System.EventHandler(this.tvpcF_TextChanged);
            this.tvpcF.DoubleClick += new System.EventHandler(this.tvpcF_DoubleClick);
            this.tvpcF.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tvpcF_KeyPress);
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(16, 33);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 143;
            this.label7.Text = "Cell #:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tCellN
            // 
            this.tCellN.BackColor = System.Drawing.Color.Lavender;
            this.tCellN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCellN.Location = new System.Drawing.Point(64, 31);
            this.tCellN.Name = "tCellN";
            this.tCellN.Size = new System.Drawing.Size(64, 20);
            this.tCellN.TabIndex = 142;
            this.tCellN.TextChanged += new System.EventHandler(this.tCellN_TextChanged);
            this.tCellN.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tCellN_KeyPress);
            // 
            // btnSProfile
            // 
            this.btnSProfile.Enabled = false;
            this.btnSProfile.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSProfile.Location = new System.Drawing.Point(136, 151);
            this.btnSProfile.Name = "btnSProfile";
            this.btnSProfile.Size = new System.Drawing.Size(40, 16);
            this.btnSProfile.TabIndex = 199;
            this.btnSProfile.Text = "Save as default profile";
            this.btnSProfile.Visible = false;
            this.btnSProfile.Click += new System.EventHandler(this.btnSProfile_Click);
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
            this.groupBox3.Location = new System.Drawing.Point(808, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(40, 136);
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
            this.lVcellMin_LA.Location = new System.Drawing.Point(32, 104);
            this.lVcellMin_LA.Name = "lVcellMin_LA";
            this.lVcellMin_LA.Size = new System.Drawing.Size(8, 16);
            this.lVcellMin_LA.TabIndex = 148;
            // 
            // lVcellMin_NI
            // 
            this.lVcellMin_NI.BackColor = System.Drawing.Color.Chocolate;
            this.lVcellMin_NI.ForeColor = System.Drawing.Color.Black;
            this.lVcellMin_NI.Location = new System.Drawing.Point(16, 104);
            this.lVcellMin_NI.Name = "lVcellMin_NI";
            this.lVcellMin_NI.Size = new System.Drawing.Size(8, 16);
            this.lVcellMin_NI.TabIndex = 147;
            // 
            // lFLT_EQ_SEC
            // 
            this.lFLT_EQ_SEC.BackColor = System.Drawing.Color.Chocolate;
            this.lFLT_EQ_SEC.ForeColor = System.Drawing.Color.Black;
            this.lFLT_EQ_SEC.Location = new System.Drawing.Point(16, 80);
            this.lFLT_EQ_SEC.Name = "lFLT_EQ_SEC";
            this.lFLT_EQ_SEC.Size = new System.Drawing.Size(16, 16);
            this.lFLT_EQ_SEC.TabIndex = 146;
            // 
            // lvpcE_LA
            // 
            this.lvpcE_LA.BackColor = System.Drawing.Color.Chocolate;
            this.lvpcE_LA.ForeColor = System.Drawing.Color.Black;
            this.lvpcE_LA.Location = new System.Drawing.Point(32, 64);
            this.lvpcE_LA.Name = "lvpcE_LA";
            this.lvpcE_LA.Size = new System.Drawing.Size(8, 16);
            this.lvpcE_LA.TabIndex = 145;
            // 
            // lvpcF_LA
            // 
            this.lvpcF_LA.BackColor = System.Drawing.Color.Chocolate;
            this.lvpcF_LA.ForeColor = System.Drawing.Color.Black;
            this.lvpcF_LA.Location = new System.Drawing.Point(8, 64);
            this.lvpcF_LA.Name = "lvpcF_LA";
            this.lvpcF_LA.Size = new System.Drawing.Size(8, 16);
            this.lvpcF_LA.TabIndex = 144;
            // 
            // lvpcE_NI
            // 
            this.lvpcE_NI.BackColor = System.Drawing.Color.Chocolate;
            this.lvpcE_NI.ForeColor = System.Drawing.Color.Black;
            this.lvpcE_NI.Location = new System.Drawing.Point(40, 40);
            this.lvpcE_NI.Name = "lvpcE_NI";
            this.lvpcE_NI.Size = new System.Drawing.Size(24, 16);
            this.lvpcE_NI.TabIndex = 143;
            // 
            // lvpcF_NI
            // 
            this.lvpcF_NI.BackColor = System.Drawing.Color.Chocolate;
            this.lvpcF_NI.ForeColor = System.Drawing.Color.Black;
            this.lvpcF_NI.Location = new System.Drawing.Point(8, 40);
            this.lvpcF_NI.Name = "lvpcF_NI";
            this.lvpcF_NI.Size = new System.Drawing.Size(24, 16);
            this.lvpcF_NI.TabIndex = 142;
            // 
            // lNBC_LA
            // 
            this.lNBC_LA.BackColor = System.Drawing.Color.Chocolate;
            this.lNBC_LA.ForeColor = System.Drawing.Color.Black;
            this.lNBC_LA.Location = new System.Drawing.Point(40, 16);
            this.lNBC_LA.Name = "lNBC_LA";
            this.lNBC_LA.Size = new System.Drawing.Size(24, 16);
            this.lNBC_LA.TabIndex = 141;
            // 
            // lNBC_NI
            // 
            this.lNBC_NI.BackColor = System.Drawing.Color.Chocolate;
            this.lNBC_NI.ForeColor = System.Drawing.Color.Black;
            this.lNBC_NI.Location = new System.Drawing.Point(8, 16);
            this.lNBC_NI.Name = "lNBC_NI";
            this.lNBC_NI.Size = new System.Drawing.Size(24, 16);
            this.lNBC_NI.TabIndex = 140;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txcbPxx);
            this.groupBox2.Controls.Add(this.ldesign3);
            this.groupBox2.Controls.Add(this.ldesign2);
            this.groupBox2.Controls.Add(this.cbDesign3);
            this.groupBox2.Controls.Add(this.cbDesign2);
            this.groupBox2.Controls.Add(this.label32);
            this.groupBox2.Controls.Add(this.cbDesign);
            this.groupBox2.Controls.Add(this.ldesign);
            this.groupBox2.Controls.Add(this.groupBox11);
            this.groupBox2.Controls.Add(this.groupBox1);
            this.groupBox2.Controls.Add(this.lFTTT);
            this.groupBox2.Controls.Add(this.groupBox8);
            this.groupBox2.Controls.Add(this.groupBox5);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.optAuto);
            this.groupBox2.Controls.Add(this.lmin);
            this.groupBox2.Controls.Add(this.lxxx);
            this.groupBox2.Controls.Add(this.cbXXX);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.cbPhs);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.cbPxx);
            this.groupBox2.Controls.Add(this.cbVdc);
            this.groupBox2.Controls.Add(this.cbIdctmp);
            this.groupBox2.Controls.Add(this.cbIdc);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.Location = new System.Drawing.Point(8, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(418, 144);
            this.groupBox2.TabIndex = 138;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter_1);
            // 
            // txcbPxx
            // 
            this.txcbPxx.BackColor = System.Drawing.Color.White;
            this.txcbPxx.ForeColor = System.Drawing.Color.Black;
            this.txcbPxx.Location = new System.Drawing.Point(74, 13);
            this.txcbPxx.Name = "txcbPxx";
            this.txcbPxx.Size = new System.Drawing.Size(32, 16);
            this.txcbPxx.TabIndex = 310;
            this.txcbPxx.Visible = false;
            // 
            // ldesign3
            // 
            this.ldesign3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ldesign3.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ldesign3.ForeColor = System.Drawing.Color.Red;
            this.ldesign3.Location = new System.Drawing.Point(387, 59);
            this.ldesign3.Name = "ldesign3";
            this.ldesign3.Size = new System.Drawing.Size(19, 24);
            this.ldesign3.TabIndex = 309;
            this.ldesign3.Text = "U";
            this.ldesign3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ldesign3.Visible = false;
            // 
            // ldesign2
            // 
            this.ldesign2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ldesign2.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ldesign2.ForeColor = System.Drawing.Color.Red;
            this.ldesign2.Location = new System.Drawing.Point(368, 59);
            this.ldesign2.Name = "ldesign2";
            this.ldesign2.Size = new System.Drawing.Size(19, 24);
            this.ldesign2.TabIndex = 308;
            this.ldesign2.Text = "U";
            this.ldesign2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ldesign2.Visible = false;
            // 
            // cbDesign3
            // 
            this.cbDesign3.BackColor = System.Drawing.Color.Lavender;
            this.cbDesign3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDesign3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDesign3.ItemHeight = 16;
            this.cbDesign3.Items.AddRange(new object[] {
            "---",
            "U",
            "S",
            "M"});
            this.cbDesign3.Location = new System.Drawing.Point(374, 32);
            this.cbDesign3.Name = "cbDesign3";
            this.cbDesign3.Size = new System.Drawing.Size(38, 24);
            this.cbDesign3.TabIndex = 215;
            this.cbDesign3.SelectedIndexChanged += new System.EventHandler(this.cbDesign3_SelectedIndexChanged);
            // 
            // cbDesign2
            // 
            this.cbDesign2.BackColor = System.Drawing.Color.Lavender;
            this.cbDesign2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDesign2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDesign2.ItemHeight = 16;
            this.cbDesign2.Items.AddRange(new object[] {
            "---",
            "U",
            "S",
            "M"});
            this.cbDesign2.Location = new System.Drawing.Point(330, 32);
            this.cbDesign2.Name = "cbDesign2";
            this.cbDesign2.Size = new System.Drawing.Size(38, 24);
            this.cbDesign2.TabIndex = 214;
            this.cbDesign2.SelectedIndexChanged += new System.EventHandler(this.cbDesign2_SelectedIndexChanged);
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.SystemColors.Control;
            this.label32.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.ForeColor = System.Drawing.Color.MediumBlue;
            this.label32.Location = new System.Drawing.Point(294, 8);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(118, 24);
            this.label32.TabIndex = 213;
            this.label32.Text = "Design ";
            this.label32.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cbDesign
            // 
            this.cbDesign.BackColor = System.Drawing.Color.Lavender;
            this.cbDesign.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbDesign.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbDesign.ItemHeight = 16;
            this.cbDesign.Items.AddRange(new object[] {
            "---",
            "U",
            "S",
            "M"});
            this.cbDesign.Location = new System.Drawing.Point(286, 32);
            this.cbDesign.Name = "cbDesign";
            this.cbDesign.Size = new System.Drawing.Size(38, 24);
            this.cbDesign.TabIndex = 212;
            this.cbDesign.SelectedIndexChanged += new System.EventHandler(this.cbDesign_SelectedIndexChanged);
            // 
            // ldesign
            // 
            this.ldesign.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ldesign.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ldesign.ForeColor = System.Drawing.Color.Red;
            this.ldesign.Location = new System.Drawing.Point(349, 59);
            this.ldesign.Name = "ldesign";
            this.ldesign.Size = new System.Drawing.Size(19, 24);
            this.ldesign.TabIndex = 307;
            this.ldesign.Text = "U";
            this.ldesign.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ldesign.Visible = false;
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.tRPL);
            this.groupBox11.Controls.Add(this.label31);
            this.groupBox11.Controls.Add(this.label29);
            this.groupBox11.Location = new System.Drawing.Point(96, 96);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(120, 41);
            this.groupBox11.TabIndex = 211;
            this.groupBox11.TabStop = false;
            // 
            // tRPL
            // 
            this.tRPL.BackColor = System.Drawing.SystemColors.Control;
            this.tRPL.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tRPL.Location = new System.Drawing.Point(46, 12);
            this.tRPL.MaxLength = 8;
            this.tRPL.Name = "tRPL";
            this.tRPL.ReadOnly = true;
            this.tRPL.Size = new System.Drawing.Size(68, 20);
            this.tRPL.TabIndex = 190;
            this.tRPL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tRPL.TextChanged += new System.EventHandler(this.tRPL_TextChanged);
            this.tRPL.DoubleClick += new System.EventHandler(this.tRPL_DoubleClick);
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.SystemColors.Control;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.DarkGreen;
            this.label31.Location = new System.Drawing.Point(29, 8);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(12, 10);
            this.label31.TabIndex = 289;
            this.label31.Text = "*";
            this.label31.Visible = false;
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.Color.Transparent;
            this.label29.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.Color.DarkRed;
            this.label29.Location = new System.Drawing.Point(0, 12);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(50, 20);
            this.label29.TabIndex = 191;
            this.label29.Text = "RIPLE:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tLTime);
            this.groupBox1.Controls.Add(this.label16);
            this.groupBox1.Controls.Add(this.MaxLT);
            this.groupBox1.Controls.Add(this.ll);
            this.groupBox1.Controls.Add(this.minLT);
            this.groupBox1.Location = new System.Drawing.Point(96, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(120, 44);
            this.groupBox1.TabIndex = 207;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Lead Time (Weeks)";
            // 
            // tLTime
            // 
            this.tLTime.BackColor = System.Drawing.Color.Lime;
            this.tLTime.ForeColor = System.Drawing.Color.Black;
            this.tLTime.Location = new System.Drawing.Point(2, 8);
            this.tLTime.Name = "tLTime";
            this.tLTime.Size = new System.Drawing.Size(24, 16);
            this.tLTime.TabIndex = 196;
            this.tLTime.Visible = false;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Franklin Gothic Medium", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DarkRed;
            this.label16.Location = new System.Drawing.Point(56, 22);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(32, 16);
            this.label16.TabIndex = 195;
            this.label16.Text = "Max";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MaxLT
            // 
            this.MaxLT.BackColor = System.Drawing.Color.Lavender;
            this.MaxLT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxLT.Location = new System.Drawing.Point(88, 18);
            this.MaxLT.MaxLength = 2;
            this.MaxLT.Name = "MaxLT";
            this.MaxLT.Size = new System.Drawing.Size(24, 22);
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
            this.ll.Location = new System.Drawing.Point(0, 22);
            this.ll.Name = "ll";
            this.ll.Size = new System.Drawing.Size(32, 16);
            this.ll.TabIndex = 193;
            this.ll.Text = "Min";
            this.ll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // minLT
            // 
            this.minLT.BackColor = System.Drawing.Color.Lavender;
            this.minLT.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minLT.Location = new System.Drawing.Point(32, 18);
            this.minLT.MaxLength = 2;
            this.minLT.Name = "minLT";
            this.minLT.Size = new System.Drawing.Size(24, 22);
            this.minLT.TabIndex = 192;
            this.minLT.Tag = "";
            this.minLT.Text = "04";
            this.minLT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minLT.TextChanged += new System.EventHandler(this.minLT_TextChanged);
            // 
            // lFTTT
            // 
            this.lFTTT.BackColor = System.Drawing.Color.Lime;
            this.lFTTT.ForeColor = System.Drawing.Color.Black;
            this.lFTTT.Location = new System.Drawing.Point(139, 10);
            this.lFTTT.Name = "lFTTT";
            this.lFTTT.Size = new System.Drawing.Size(32, 16);
            this.lFTTT.TabIndex = 204;
            this.lFTTT.Visible = false;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lhrtZMRK);
            this.groupBox8.Controls.Add(this.opt400);
            this.groupBox8.Controls.Add(this.lhrtz);
            this.groupBox8.Controls.Add(this.opt50);
            this.groupBox8.Controls.Add(this.opt60);
            this.groupBox8.Location = new System.Drawing.Point(216, 96);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(128, 40);
            this.groupBox8.TabIndex = 202;
            this.groupBox8.TabStop = false;
            this.groupBox8.Text = "HertZ";
            // 
            // lhrtZMRK
            // 
            this.lhrtZMRK.BackColor = System.Drawing.Color.Lime;
            this.lhrtZMRK.ForeColor = System.Drawing.Color.Black;
            this.lhrtZMRK.Location = new System.Drawing.Point(80, 0);
            this.lhrtZMRK.Name = "lhrtZMRK";
            this.lhrtZMRK.Size = new System.Drawing.Size(48, 16);
            this.lhrtZMRK.TabIndex = 122;
            this.lhrtZMRK.Text = "1";
            this.lhrtZMRK.Visible = false;
            // 
            // opt400
            // 
            this.opt400.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.opt400.Location = new System.Drawing.Point(86, 16);
            this.opt400.Name = "opt400";
            this.opt400.Size = new System.Drawing.Size(40, 16);
            this.opt400.TabIndex = 121;
            this.opt400.Text = "400";
            this.opt400.CheckedChanged += new System.EventHandler(this.opt400_CheckedChanged);
            // 
            // lhrtz
            // 
            this.lhrtz.BackColor = System.Drawing.Color.Lime;
            this.lhrtz.ForeColor = System.Drawing.Color.Black;
            this.lhrtz.Location = new System.Drawing.Point(32, 24);
            this.lhrtz.Name = "lhrtz";
            this.lhrtz.Size = new System.Drawing.Size(16, 16);
            this.lhrtz.TabIndex = 120;
            this.lhrtz.Text = "60";
            this.lhrtz.Visible = false;
            // 
            // opt50
            // 
            this.opt50.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.opt50.Location = new System.Drawing.Point(47, 16);
            this.opt50.Name = "opt50";
            this.opt50.Size = new System.Drawing.Size(32, 16);
            this.opt50.TabIndex = 118;
            this.opt50.Text = "50";
            this.opt50.CheckedChanged += new System.EventHandler(this.opt50_CheckedChanged);
            // 
            // opt60
            // 
            this.opt60.Checked = true;
            this.opt60.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.opt60.Location = new System.Drawing.Point(7, 16);
            this.opt60.Name = "opt60";
            this.opt60.Size = new System.Drawing.Size(32, 16);
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
            this.groupBox5.Location = new System.Drawing.Point(8, 56);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(88, 80);
            this.groupBox5.TabIndex = 201;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Batteries";
            // 
            // optVrla
            // 
            this.optVrla.BackColor = System.Drawing.SystemColors.Control;
            this.optVrla.Checked = true;
            this.optVrla.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optVrla.Location = new System.Drawing.Point(8, 56);
            this.optVrla.Name = "optVrla";
            this.optVrla.Size = new System.Drawing.Size(56, 18);
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
            this.lNA.Location = new System.Drawing.Point(72, 48);
            this.lNA.Name = "lNA";
            this.lNA.Size = new System.Drawing.Size(16, 16);
            this.lNA.TabIndex = 121;
            this.lNA.Text = "N";
            this.lNA.Visible = false;
            // 
            // optLA
            // 
            this.optLA.BackColor = System.Drawing.SystemColors.Control;
            this.optLA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optLA.Location = new System.Drawing.Point(8, 16);
            this.optLA.Name = "optLA";
            this.optLA.Size = new System.Drawing.Size(72, 16);
            this.optLA.TabIndex = 118;
            this.optLA.Text = "Lead  Acid";
            this.optLA.UseVisualStyleBackColor = false;
            this.optLA.CheckedChanged += new System.EventHandler(this.optLA_CheckedChanged);
            // 
            // optNi
            // 
            this.optNi.BackColor = System.Drawing.SystemColors.Control;
            this.optNi.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optNi.Location = new System.Drawing.Point(8, 36);
            this.optNi.Name = "optNi";
            this.optNi.Size = new System.Drawing.Size(56, 18);
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
            this.groupBox6.Location = new System.Drawing.Point(216, 56);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(128, 40);
            this.groupBox6.TabIndex = 200;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Charger type";
            // 
            // lFV
            // 
            this.lFV.BackColor = System.Drawing.Color.Lime;
            this.lFV.ForeColor = System.Drawing.Color.Black;
            this.lFV.Location = new System.Drawing.Point(56, 16);
            this.lFV.Name = "lFV";
            this.lFV.Size = new System.Drawing.Size(16, 16);
            this.lFV.TabIndex = 120;
            this.lFV.Text = "F";
            this.lFV.Visible = false;
            // 
            // optVar
            // 
            this.optVar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optVar.Location = new System.Drawing.Point(56, 16);
            this.optVar.Name = "optVar";
            this.optVar.Size = new System.Drawing.Size(64, 18);
            this.optVar.TabIndex = 118;
            this.optVar.Text = "Variable";
            this.optVar.CheckedChanged += new System.EventHandler(this.optVar_CheckedChanged);
            // 
            // optFx
            // 
            this.optFx.Checked = true;
            this.optFx.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optFx.Location = new System.Drawing.Point(8, 16);
            this.optFx.Name = "optFx";
            this.optFx.Size = new System.Drawing.Size(48, 16);
            this.optFx.TabIndex = 117;
            this.optFx.TabStop = true;
            this.optFx.Text = "Fixed";
            this.optFx.CheckedChanged += new System.EventHandler(this.optFx_CheckedChanged);
            // 
            // optAuto
            // 
            this.optAuto.Checked = true;
            this.optAuto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optAuto.Location = new System.Drawing.Point(200, 80);
            this.optAuto.Name = "optAuto";
            this.optAuto.Size = new System.Drawing.Size(40, 16);
            this.optAuto.TabIndex = 168;
            this.optAuto.TabStop = true;
            this.optAuto.Text = "Automatic";
            this.optAuto.Visible = false;
            // 
            // lmin
            // 
            this.lmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmin.ForeColor = System.Drawing.Color.Black;
            this.lmin.Location = new System.Drawing.Point(280, 32);
            this.lmin.Name = "lmin";
            this.lmin.Size = new System.Drawing.Size(8, 20);
            this.lmin.TabIndex = 167;
            this.lmin.Text = "-";
            this.lmin.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lmin.Visible = false;
            // 
            // lxxx
            // 
            this.lxxx.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lxxx.Location = new System.Drawing.Point(348, 88);
            this.lxxx.Name = "lxxx";
            this.lxxx.Size = new System.Drawing.Size(56, 16);
            this.lxxx.TabIndex = 166;
            this.lxxx.Text = "XXX";
            this.lxxx.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.lxxx.Visible = false;
            // 
            // cbXXX
            // 
            this.cbXXX.BackColor = System.Drawing.Color.Lavender;
            this.cbXXX.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbXXX.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbXXX.ItemHeight = 16;
            this.cbXXX.Items.AddRange(new object[] {
            "A",
            "WK",
            "D",
            "2P",
            "SS"});
            this.cbXXX.Location = new System.Drawing.Point(348, 104);
            this.cbXXX.Name = "cbXXX";
            this.cbXXX.Size = new System.Drawing.Size(56, 24);
            this.cbXXX.TabIndex = 165;
            this.cbXXX.Visible = false;
            this.cbXXX.SelectedIndexChanged += new System.EventHandler(this.cbXXX_SelectedIndexChanged_1);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(216, 32);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(8, 20);
            this.label6.TabIndex = 164;
            this.label6.Text = "-";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(152, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(8, 20);
            this.label5.TabIndex = 163;
            this.label5.Text = "-";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(104, 32);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(8, 20);
            this.label4.TabIndex = 162;
            this.label4.Text = "-";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(224, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 24);
            this.label3.TabIndex = 161;
            this.label3.Text = "IDC";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(168, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 159;
            this.label2.Text = "VDC";
            this.label2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(112, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 16);
            this.label1.TabIndex = 157;
            this.label1.Text = "PHS";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cbPhs
            // 
            this.cbPhs.BackColor = System.Drawing.Color.Lavender;
            this.cbPhs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPhs.ItemHeight = 16;
            this.cbPhs.Items.AddRange(new object[] {
            "1",
            "3"});
            this.cbPhs.Location = new System.Drawing.Point(112, 32);
            this.cbPhs.Name = "cbPhs";
            this.cbPhs.Size = new System.Drawing.Size(40, 24);
            this.cbPhs.TabIndex = 156;
            this.cbPhs.SelectedIndexChanged += new System.EventHandler(this.cbPhs_SelectedIndexChanged);
            this.cbPhs.SelectedValueChanged += new System.EventHandler(this.cbPhs_SelectedValueChanged_1);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(8, 16);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 16);
            this.label22.TabIndex = 155;
            this.label22.Text = "PXXXX";
            this.label22.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cbPxx
            // 
            this.cbPxx.BackColor = System.Drawing.Color.Lavender;
            this.cbPxx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPxx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPxx.ItemHeight = 16;
            this.cbPxx.Location = new System.Drawing.Point(8, 32);
            this.cbPxx.Name = "cbPxx";
            this.cbPxx.Size = new System.Drawing.Size(96, 24);
            this.cbPxx.TabIndex = 154;
            this.cbPxx.SelectedIndexChanged += new System.EventHandler(this.cbPxx_SelectedIndexChanged);
            this.cbPxx.SelectedValueChanged += new System.EventHandler(this.cbPxx_SelectedValueChanged);
            // 
            // cbVdc
            // 
            this.cbVdc.BackColor = System.Drawing.Color.Lavender;
            this.cbVdc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVdc.ItemHeight = 16;
            this.cbVdc.Location = new System.Drawing.Point(160, 32);
            this.cbVdc.MaxDropDownItems = 20;
            this.cbVdc.Name = "cbVdc";
            this.cbVdc.Size = new System.Drawing.Size(56, 24);
            this.cbVdc.TabIndex = 158;
            this.cbVdc.SelectedIndexChanged += new System.EventHandler(this.cbVdc_SelectedValueChanged);
            this.cbVdc.SelectionChangeCommitted += new System.EventHandler(this.cbVdc_SelectionChangeCommitted);
            this.cbVdc.SelectedValueChanged += new System.EventHandler(this.cbVdc_SelectedValueChanged_1);
            this.cbVdc.KeyUp += new System.Windows.Forms.KeyEventHandler(this.cbVdc_KeyUp);
            // 
            // cbIdctmp
            // 
            this.cbIdctmp.BackColor = System.Drawing.Color.Blue;
            this.cbIdctmp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdctmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIdctmp.ForeColor = System.Drawing.Color.White;
            this.cbIdctmp.ItemHeight = 16;
            this.cbIdctmp.Items.AddRange(new object[] {
            "6",
            "12"});
            this.cbIdctmp.Location = new System.Drawing.Point(288, 8);
            this.cbIdctmp.Name = "cbIdctmp";
            this.cbIdctmp.Size = new System.Drawing.Size(56, 24);
            this.cbIdctmp.TabIndex = 210;
            this.cbIdctmp.Visible = false;
            this.cbIdctmp.SelectedIndexChanged += new System.EventHandler(this.cbIdctmp_SelectedIndexChanged);
            // 
            // cbIdc
            // 
            this.cbIdc.BackColor = System.Drawing.Color.Lavender;
            this.cbIdc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIdc.ItemHeight = 16;
            this.cbIdc.Location = new System.Drawing.Point(224, 32);
            this.cbIdc.Name = "cbIdc";
            this.cbIdc.Size = new System.Drawing.Size(56, 24);
            this.cbIdc.TabIndex = 160;
            this.cbIdc.SelectedIndexChanged += new System.EventHandler(this.cbIdc_SelectedValueChanged);
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.tPxxQty);
            this.groupBox9.Location = new System.Drawing.Point(294, 10);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(120, 38);
            this.groupBox9.TabIndex = 209;
            this.groupBox9.TabStop = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Franklin Gothic Medium", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.DarkRed;
            this.label12.Location = new System.Drawing.Point(6, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(40, 22);
            this.label12.TabIndex = 191;
            this.label12.Text = "QTY:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tPxxQty
            // 
            this.tPxxQty.BackColor = System.Drawing.Color.Lavender;
            this.tPxxQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPxxQty.Location = new System.Drawing.Point(46, 10);
            this.tPxxQty.MaxLength = 2;
            this.tPxxQty.Name = "tPxxQty";
            this.tPxxQty.Size = new System.Drawing.Size(68, 22);
            this.tPxxQty.TabIndex = 190;
            this.tPxxQty.Text = "1";
            this.tPxxQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tPxxQty.TextChanged += new System.EventHandler(this.tPxxQty_TextChanged);
            // 
            // lvDefOption
            // 
            this.lvDefOption.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvDefOption.CheckBoxes = true;
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
            this.lvDefOption.ContextMenu = this.EdDelRenMnu;
            this.lvDefOption.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvDefOption.ForeColor = System.Drawing.SystemColors.WindowText;
            this.lvDefOption.FullRowSelect = true;
            this.lvDefOption.GridLines = true;
            this.lvDefOption.Location = new System.Drawing.Point(0, 386);
            this.lvDefOption.Name = "lvDefOption";
            this.lvDefOption.Size = new System.Drawing.Size(993, 288);
            this.lvDefOption.TabIndex = 102;
            this.lvDefOption.UseCompatibleStateImageBehavior = false;
            this.lvDefOption.View = System.Windows.Forms.View.Details;
            this.lvDefOption.SelectedIndexChanged += new System.EventHandler(this.lvDefOption_SelectedIndexChanged);
            this.lvDefOption.DoubleClick += new System.EventHandler(this.lvDefOption_DoubleClick);
            // 
            // shw
            // 
            this.shw.Text = "Show";
            this.shw.Width = 43;
            // 
            // RefCpt
            // 
            this.RefCpt.Text = "Option Ref";
            this.RefCpt.Width = 281;
            // 
            // Desc
            // 
            this.Desc.Text = "Description";
            this.Desc.Width = 154;
            // 
            // Qty
            // 
            this.Qty.Text = "Qty";
            this.Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Qty.Width = 54;
            // 
            // UPrice
            // 
            this.UPrice.Text = "U.Price";
            this.UPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UPrice.Width = 75;
            // 
            // Ext
            // 
            this.Ext.Text = "Extension";
            this.Ext.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Ext.Width = 84;
            // 
            // DlvDate
            // 
            this.DlvDate.Text = "L.Time";
            this.DlvDate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DlvDate.Width = 71;
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
            this.cptRef.Width = 0;
            // 
            // cptPartnb
            // 
            this.cptPartnb.Text = "";
            this.cptPartnb.Width = 0;
            // 
            // grp1
            // 
            this.grp1.Controls.Add(this.lsep3);
            this.grp1.Controls.Add(this.lsep2);
            this.grp1.Controls.Add(this.lChrgREF);
            this.grp1.Controls.Add(this.btnCancel);
            this.grp1.Controls.Add(this.btnOK);
            this.grp1.Controls.Add(this.lsep);
            this.grp1.Controls.Add(this.groupBox9);
            this.grp1.Controls.Add(this.label10);
            this.grp1.Controls.Add(this.lresCpt);
            this.grp1.Controls.Add(this.button4);
            this.grp1.Controls.Add(this.cbCPTs);
            this.grp1.Controls.Add(this.checkBox1);
            this.grp1.Controls.Add(this.lW2);
            this.grp1.Controls.Add(this.lIsh);
            this.grp1.Controls.Add(this.lVSECLL);
            this.grp1.Controls.Add(this.lVSECLN);
            this.grp1.Controls.Add(this.label30);
            this.grp1.Controls.Add(this.lcptID);
            this.grp1.Controls.Add(this.button3);
            this.grp1.Controls.Add(this.tSig);
            this.grp1.Controls.Add(this.tdbl);
            this.grp1.Controls.Add(this.lALRM);
            this.grp1.Controls.Add(this.linkLabel1);
            this.grp1.Controls.Add(this.groupBox10);
            this.grp1.Controls.Add(this.pictureBox2);
            this.grp1.Controls.Add(this.lnkAlarm);
            this.grp1.Controls.Add(this.pictureBox1);
            this.grp1.Controls.Add(this.LnkValidate);
            this.grp1.Controls.Add(this.lDescc);
            this.grp1.Controls.Add(this.lRiple);
            this.grp1.Controls.Add(this.lSave);
            this.grp1.Controls.Add(this.t1);
            this.grp1.Controls.Add(this.t2);
            this.grp1.Controls.Add(this.button2);
            this.grp1.Controls.Add(this.lNcelCoef);
            this.grp1.Controls.Add(this.label18);
            this.grp1.Controls.Add(this.cbVCS);
            this.grp1.Controls.Add(this.lresVCS);
            this.grp1.Controls.Add(this.button1);
            this.grp1.Controls.Add(this.lcptName);
            this.grp1.Controls.Add(this.lCost);
            this.grp1.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp1.Location = new System.Drawing.Point(0, 170);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(993, 216);
            this.grp1.TabIndex = 103;
            this.grp1.TabStop = false;
            this.grp1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lsep3
            // 
            this.lsep3.BackColor = System.Drawing.Color.Khaki;
            this.lsep3.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsep3.ForeColor = System.Drawing.Color.Red;
            this.lsep3.Location = new System.Drawing.Point(549, 36);
            this.lsep3.Name = "lsep3";
            this.lsep3.Size = new System.Drawing.Size(24, 24);
            this.lsep3.TabIndex = 310;
            this.lsep3.Text = "-";
            this.lsep3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lsep3.Visible = false;
            // 
            // lsep2
            // 
            this.lsep2.BackColor = System.Drawing.Color.Khaki;
            this.lsep2.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsep2.ForeColor = System.Drawing.Color.Red;
            this.lsep2.Location = new System.Drawing.Point(519, 36);
            this.lsep2.Name = "lsep2";
            this.lsep2.Size = new System.Drawing.Size(24, 24);
            this.lsep2.TabIndex = 309;
            this.lsep2.Text = "-";
            this.lsep2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lsep2.Visible = false;
            // 
            // lChrgREF
            // 
            this.lChrgREF.BackColor = System.Drawing.Color.Blue;
            this.lChrgREF.Font = new System.Drawing.Font("Arial Narrow", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lChrgREF.ForeColor = System.Drawing.Color.White;
            this.lChrgREF.Location = new System.Drawing.Point(8, 12);
            this.lChrgREF.Name = "lChrgREF";
            this.lChrgREF.Size = new System.Drawing.Size(275, 41);
            this.lChrgREF.TabIndex = 171;
            this.lChrgREF.Text = "P4500TT-1-600-1000";
            this.lChrgREF.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lChrgREF.Click += new System.EventHandler(this.lChrgREF_Click);
            this.lChrgREF.DoubleClick += new System.EventHandler(this.lChrgREF_DoubleClick);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.PowderBlue;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnCancel.Location = new System.Drawing.Point(885, 17);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 31);
            this.btnCancel.TabIndex = 287;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.PowderBlue;
            this.btnOK.Enabled = false;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(773, 17);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(104, 31);
            this.btnOK.TabIndex = 286;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // lsep
            // 
            this.lsep.BackColor = System.Drawing.Color.Khaki;
            this.lsep.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsep.ForeColor = System.Drawing.Color.Red;
            this.lsep.Location = new System.Drawing.Point(489, 36);
            this.lsep.Name = "lsep";
            this.lsep.Size = new System.Drawing.Size(24, 24);
            this.lsep.TabIndex = 308;
            this.lsep.Text = "-";
            this.lsep.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lsep.Visible = false;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(288, 112);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(256, 14);
            this.label10.TabIndex = 306;
            this.label10.Text = "Results are for standard values";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lresCpt
            // 
            this.lresCpt.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lresCpt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lresCpt.ForeColor = System.Drawing.Color.White;
            this.lresCpt.Location = new System.Drawing.Point(328, 160);
            this.lresCpt.Name = "lresCpt";
            this.lresCpt.Size = new System.Drawing.Size(232, 29);
            this.lresCpt.TabIndex = 305;
            this.lresCpt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.Location = new System.Drawing.Point(280, 163);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 22);
            this.button4.TabIndex = 304;
            this.button4.Text = "===>";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cbCPTs
            // 
            this.cbCPTs.BackColor = System.Drawing.Color.Lavender;
            this.cbCPTs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCPTs.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCPTs.ItemHeight = 16;
            this.cbCPTs.Location = new System.Drawing.Point(16, 162);
            this.cbCPTs.Name = "cbCPTs";
            this.cbCPTs.Size = new System.Drawing.Size(264, 24);
            this.cbCPTs.TabIndex = 303;
            this.cbCPTs.SelectedIndexChanged += new System.EventHandler(this.cbCPTs_SelectedIndexChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.ForeColor = System.Drawing.Color.Blue;
            this.checkBox1.Location = new System.Drawing.Point(814, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(112, 32);
            this.checkBox1.TabIndex = 302;
            this.checkBox1.Text = "Diode (D2)";
            this.checkBox1.Visible = false;
            // 
            // lW2
            // 
            this.lW2.BackColor = System.Drawing.SystemColors.Control;
            this.lW2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lW2.ForeColor = System.Drawing.Color.Red;
            this.lW2.Location = new System.Drawing.Point(736, 120);
            this.lW2.Name = "lW2";
            this.lW2.Size = new System.Drawing.Size(64, 16);
            this.lW2.TabIndex = 299;
            this.lW2.Text = "0";
            this.lW2.Visible = false;
            // 
            // lIsh
            // 
            this.lIsh.BackColor = System.Drawing.SystemColors.Control;
            this.lIsh.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lIsh.ForeColor = System.Drawing.Color.Red;
            this.lIsh.Location = new System.Drawing.Point(736, 136);
            this.lIsh.Name = "lIsh";
            this.lIsh.Size = new System.Drawing.Size(64, 16);
            this.lIsh.TabIndex = 298;
            this.lIsh.Text = "0";
            this.lIsh.Visible = false;
            // 
            // lVSECLL
            // 
            this.lVSECLL.BackColor = System.Drawing.SystemColors.Control;
            this.lVSECLL.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lVSECLL.ForeColor = System.Drawing.Color.Red;
            this.lVSECLL.Location = new System.Drawing.Point(736, 152);
            this.lVSECLL.Name = "lVSECLL";
            this.lVSECLL.Size = new System.Drawing.Size(64, 16);
            this.lVSECLL.TabIndex = 297;
            this.lVSECLL.Text = "0";
            this.lVSECLL.Visible = false;
            // 
            // lVSECLN
            // 
            this.lVSECLN.BackColor = System.Drawing.SystemColors.Control;
            this.lVSECLN.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lVSECLN.ForeColor = System.Drawing.Color.Red;
            this.lVSECLN.Location = new System.Drawing.Point(736, 168);
            this.lVSECLN.Name = "lVSECLN";
            this.lVSECLN.Size = new System.Drawing.Size(64, 16);
            this.lVSECLN.TabIndex = 296;
            this.lVSECLN.Text = "0";
            this.lVSECLN.Visible = false;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.OliveDrab;
            this.label30.Location = new System.Drawing.Point(584, 112);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(96, 24);
            this.label30.TabIndex = 293;
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label30.Visible = false;
            // 
            // lcptID
            // 
            this.lcptID.BackColor = System.Drawing.Color.OliveDrab;
            this.lcptID.Location = new System.Drawing.Point(232, 104);
            this.lcptID.Name = "lcptID";
            this.lcptID.Size = new System.Drawing.Size(32, 24);
            this.lcptID.TabIndex = 292;
            this.lcptID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lcptID.Visible = false;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(600, 136);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 24);
            this.button3.TabIndex = 291;
            this.button3.Text = "===>";
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click_2);
            // 
            // tSig
            // 
            this.tSig.BackColor = System.Drawing.Color.Lavender;
            this.tSig.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSig.Location = new System.Drawing.Point(576, 160);
            this.tSig.Name = "tSig";
            this.tSig.Size = new System.Drawing.Size(64, 20);
            this.tSig.TabIndex = 290;
            this.tSig.Visible = false;
            this.tSig.TextChanged += new System.EventHandler(this.value_TextChanged);
            // 
            // tdbl
            // 
            this.tdbl.BackColor = System.Drawing.Color.Lavender;
            this.tdbl.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tdbl.Location = new System.Drawing.Point(832, 152);
            this.tdbl.Name = "tdbl";
            this.tdbl.Size = new System.Drawing.Size(64, 20);
            this.tdbl.TabIndex = 289;
            this.tdbl.Visible = false;
            this.tdbl.TextChanged += new System.EventHandler(this.tdbl_TextChanged);
            // 
            // lALRM
            // 
            this.lALRM.BackColor = System.Drawing.Color.Lime;
            this.lALRM.ForeColor = System.Drawing.Color.Black;
            this.lALRM.Location = new System.Drawing.Point(437, 12);
            this.lALRM.Name = "lALRM";
            this.lALRM.Size = new System.Drawing.Size(16, 16);
            this.lALRM.TabIndex = 288;
            this.lALRM.Text = "N";
            this.lALRM.Visible = false;
            // 
            // linkLabel1
            // 
            this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.linkLabel1.Location = new System.Drawing.Point(704, 0);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(72, 16);
            this.linkLabel1.TabIndex = 181;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "Eq/Alarms";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
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
            this.groupBox10.Location = new System.Drawing.Point(8, 56);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(800, 56);
            this.groupBox10.TabIndex = 180;
            this.groupBox10.TabStop = false;
            // 
            // pictureBox8
            // 
            this.pictureBox8.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox8.Image")));
            this.pictureBox8.Location = new System.Drawing.Point(8, 32);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(64, 18);
            this.pictureBox8.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox8.TabIndex = 36;
            this.pictureBox8.TabStop = false;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(96, 16);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(56, 14);
            this.label15.TabIndex = 35;
            this.label15.Text = "Ref.";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tRef
            // 
            this.tRef.BackColor = System.Drawing.Color.Red;
            this.tRef.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tRef.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tRef.Location = new System.Drawing.Point(72, 32);
            this.tRef.Name = "tRef";
            this.tRef.Size = new System.Drawing.Size(96, 20);
            this.tRef.TabIndex = 34;
            this.tRef.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label48
            // 
            this.label48.Location = new System.Drawing.Point(608, 16);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(64, 15);
            this.label48.TabIndex = 33;
            this.label48.Text = "Extension";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tExt
            // 
            this.tExt.BackColor = System.Drawing.Color.Red;
            this.tExt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tExt.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tExt.Location = new System.Drawing.Point(592, 32);
            this.tExt.Name = "tExt";
            this.tExt.ReadOnly = true;
            this.tExt.Size = new System.Drawing.Size(96, 20);
            this.tExt.TabIndex = 32;
            this.tExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label44
            // 
            this.label44.Location = new System.Drawing.Point(256, 16);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(82, 14);
            this.label44.TabIndex = 29;
            this.label44.Text = "Description";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tdesc
            // 
            this.tdesc.BackColor = System.Drawing.Color.Red;
            this.tdesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tdesc.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tdesc.Location = new System.Drawing.Point(168, 32);
            this.tdesc.Name = "tdesc";
            this.tdesc.Size = new System.Drawing.Size(312, 20);
            this.tdesc.TabIndex = 28;
            this.tdesc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.SystemColors.Control;
            this.label43.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label43.Location = new System.Drawing.Point(688, 16);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(40, 15);
            this.label43.TabIndex = 27;
            this.label43.Text = "Ld Time";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tLT
            // 
            this.tLT.BackColor = System.Drawing.Color.Red;
            this.tLT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tLT.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tLT.Location = new System.Drawing.Point(688, 32);
            this.tLT.Name = "tLT";
            this.tLT.Size = new System.Drawing.Size(51, 20);
            this.tLT.TabIndex = 26;
            this.tLT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // ChngCancel
            // 
            this.ChngCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ChngCancel.Location = new System.Drawing.Point(744, 32);
            this.ChngCancel.Name = "ChngCancel";
            this.ChngCancel.Size = new System.Drawing.Size(48, 20);
            this.ChngCancel.TabIndex = 25;
            this.ChngCancel.Text = "&Cancel";
            this.ChngCancel.Click += new System.EventHandler(this.ChngCancel_Click);
            // 
            // btnOKchng
            // 
            this.btnOKchng.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOKchng.Location = new System.Drawing.Point(744, 8);
            this.btnOKchng.Name = "btnOKchng";
            this.btnOKchng.Size = new System.Drawing.Size(48, 20);
            this.btnOKchng.TabIndex = 24;
            this.btnOKchng.Text = "&Save";
            this.btnOKchng.Click += new System.EventHandler(this.btnOKchng_Click);
            // 
            // label42
            // 
            this.label42.Location = new System.Drawing.Point(536, 16);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(57, 15);
            this.label42.TabIndex = 22;
            this.label42.Text = "Unit Price";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tUprice
            // 
            this.tUprice.BackColor = System.Drawing.Color.Red;
            this.tUprice.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tUprice.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tUprice.Location = new System.Drawing.Point(536, 32);
            this.tUprice.Name = "tUprice";
            this.tUprice.Size = new System.Drawing.Size(56, 20);
            this.tUprice.TabIndex = 20;
            this.tUprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tUprice.TextChanged += new System.EventHandler(this.tUprice_TextChanged);
            // 
            // label28
            // 
            this.label28.Location = new System.Drawing.Point(488, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(30, 15);
            this.label28.TabIndex = 19;
            this.label28.Text = "Qty";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tqty
            // 
            this.tqty.BackColor = System.Drawing.Color.Red;
            this.tqty.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tqty.ForeColor = System.Drawing.SystemColors.HighlightText;
            this.tqty.Location = new System.Drawing.Point(480, 32);
            this.tqty.Name = "tqty";
            this.tqty.Size = new System.Drawing.Size(56, 20);
            this.tqty.TabIndex = 17;
            this.tqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tqty.TextChanged += new System.EventHandler(this.tqty_TextChanged);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Enabled = false;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(733, 12);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 32);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 179;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lnkAlarm
            // 
            this.lnkAlarm.Enabled = false;
            this.lnkAlarm.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkAlarm.Location = new System.Drawing.Point(653, 14);
            this.lnkAlarm.Name = "lnkAlarm";
            this.lnkAlarm.Size = new System.Drawing.Size(80, 28);
            this.lnkAlarm.TabIndex = 178;
            this.lnkAlarm.TabStop = true;
            this.lnkAlarm.Text = "ALARMS";
            this.lnkAlarm.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkAlarm.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkAlarm_LinkClicked);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(615, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 32);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 177;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // LnkValidate
            // 
            this.LnkValidate.Font = new System.Drawing.Font("Lucida Sans Unicode", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LnkValidate.Location = new System.Drawing.Point(519, 16);
            this.LnkValidate.Name = "LnkValidate";
            this.LnkValidate.Size = new System.Drawing.Size(96, 24);
            this.LnkValidate.TabIndex = 176;
            this.LnkValidate.TabStop = true;
            this.LnkValidate.Text = "VALIDATE";
            this.LnkValidate.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LnkValidate_LinkClicked);
            // 
            // lDescc
            // 
            this.lDescc.BackColor = System.Drawing.SystemColors.Control;
            this.lDescc.ForeColor = System.Drawing.Color.Brown;
            this.lDescc.Location = new System.Drawing.Point(784, 32);
            this.lDescc.Name = "lDescc";
            this.lDescc.Size = new System.Drawing.Size(24, 24);
            this.lDescc.TabIndex = 174;
            this.lDescc.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lDescc.Visible = false;
            // 
            // lRiple
            // 
            this.lRiple.BackColor = System.Drawing.Color.LawnGreen;
            this.lRiple.Location = new System.Drawing.Point(608, 8);
            this.lRiple.Name = "lRiple";
            this.lRiple.Size = new System.Drawing.Size(48, 16);
            this.lRiple.TabIndex = 160;
            this.lRiple.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lRiple.Visible = false;
            // 
            // lSave
            // 
            this.lSave.BackColor = System.Drawing.Color.Lime;
            this.lSave.ForeColor = System.Drawing.Color.Black;
            this.lSave.Location = new System.Drawing.Point(664, 8);
            this.lSave.Name = "lSave";
            this.lSave.Size = new System.Drawing.Size(16, 16);
            this.lSave.TabIndex = 159;
            this.lSave.Text = "N";
            this.lSave.Visible = false;
            // 
            // t1
            // 
            this.t1.BackColor = System.Drawing.SystemColors.ControlDark;
            this.t1.Location = new System.Drawing.Point(456, 10);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(24, 16);
            this.t1.TabIndex = 139;
            this.t1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.t1.Visible = false;
            // 
            // t2
            // 
            this.t2.BackColor = System.Drawing.SystemColors.ControlDark;
            this.t2.Location = new System.Drawing.Point(420, 36);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(24, 16);
            this.t2.TabIndex = 138;
            this.t2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.t2.Visible = false;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Location = new System.Drawing.Point(592, 40);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(40, 16);
            this.button2.TabIndex = 137;
            this.button2.Text = "ALL";
            this.button2.Visible = false;
            // 
            // lNcelCoef
            // 
            this.lNcelCoef.BackColor = System.Drawing.Color.LemonChiffon;
            this.lNcelCoef.ForeColor = System.Drawing.Color.Black;
            this.lNcelCoef.Location = new System.Drawing.Point(472, 26);
            this.lNcelCoef.Name = "lNcelCoef";
            this.lNcelCoef.Size = new System.Drawing.Size(24, 16);
            this.lNcelCoef.TabIndex = 136;
            this.lNcelCoef.Text = "2";
            this.lNcelCoef.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lNcelCoef.Visible = false;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.Location = new System.Drawing.Point(352, -24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(56, 24);
            this.label18.TabIndex = 135;
            this.label18.Text = "TECHNICAL VALUES:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbVCS
            // 
            this.cbVCS.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.cbVCS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVCS.ItemHeight = 16;
            this.cbVCS.Location = new System.Drawing.Point(16, 130);
            this.cbVCS.Name = "cbVCS";
            this.cbVCS.Size = new System.Drawing.Size(264, 24);
            this.cbVCS.TabIndex = 134;
            // 
            // lresVCS
            // 
            this.lresVCS.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lresVCS.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lresVCS.ForeColor = System.Drawing.Color.White;
            this.lresVCS.Location = new System.Drawing.Point(328, 128);
            this.lresVCS.Name = "lresVCS";
            this.lresVCS.Size = new System.Drawing.Size(232, 29);
            this.lresVCS.TabIndex = 130;
            this.lresVCS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(280, 131);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 22);
            this.button1.TabIndex = 129;
            this.button1.Text = "===>";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lcptName
            // 
            this.lcptName.Location = new System.Drawing.Point(704, 16);
            this.lcptName.Name = "lcptName";
            this.lcptName.Size = new System.Drawing.Size(32, 24);
            this.lcptName.TabIndex = 128;
            this.lcptName.Text = "$$$$";
            this.lcptName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lcptName.Visible = false;
            // 
            // lCost
            // 
            this.lCost.Location = new System.Drawing.Point(704, 32);
            this.lCost.Name = "lCost";
            this.lCost.Size = new System.Drawing.Size(32, 24);
            this.lCost.TabIndex = 125;
            this.lCost.Text = "$$$$";
            this.lCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lCost.Visible = false;
            // 
            // btn_inducta
            // 
            this.btn_inducta.Location = new System.Drawing.Point(24, 446);
            this.btn_inducta.Name = "btn_inducta";
            this.btn_inducta.Size = new System.Drawing.Size(872, 23);
            this.btn_inducta.TabIndex = 298;
            this.btn_inducta.Text = "Inductance....";
            this.btn_inducta.UseVisualStyleBackColor = true;
            this.btn_inducta.Click += new System.EventHandler(this.btn_inducta_Click);
            // 
            // Chargerdlg
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(993, 498);
            this.Controls.Add(this.btn_inducta);
            this.Controls.Add(this.lvDefOption);
            this.Controls.Add(this.grp1);
            this.Controls.Add(this.gbxCalc);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Chargerdlg";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chargers / Power Supply";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Chargerdlg_Load);
            this.Resize += new System.EventHandler(this.Chargerdlg_Resize);
            this.gbxCalc.ResumeLayout(false);
            this.grpOTI.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox11.ResumeLayout(false);
            this.groupBox11.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox8.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			lSave.Text ="N"; 
			this.Hide();
		}

		private void Chargerdlg_Load(object sender, System.EventArgs e)
		{
			if (MainMDI.currDB =="XTT") this.Text = "XXXXXXXXXXXXXXXXXXTT"; 
			//	cbIdc.Text ="125";
			//	cbPhs.Text ="1";
			//	cbPxx.Text ="P4500";
			//	cbVdc.Text ="125"; 
			//MessageBox.Show ("Cont.."); 
            btn_inducta.Visible =   (MainMDI.User.ToLower ()=="ede");
		}
		private void fill_cbVCS()
		{

			string stSql="SELECT * from COMPUTE_VCS " ;
           
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ())
			{
				cbVCS.Items.Add( Oreadr["VCS_NAME"].ToString()  ); 
			}
			OConn.Close(); 
		
		}

		private void fill_cbCPTs()
		{

			string stSql="SELECT COMPONENT_REF from COMPNT_LIST " ;
           
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ())
			{
				cbCPTs.Items.Add( Oreadr[0].ToString()  ); 
			}
			OConn.Close(); 
		
		}


		private void fill_All_cb(string s_cb)
		{

			for (int i=0;i<s_cb.Length ;i++)
			{
				string stSql="SELECT TABLES_CONTENT.VALUE1 FROM TABLES_CONTENT INNER " +
					" JOIN TABLES_LIST ON TABLES_CONTENT.TABLE_ID = TABLES_LIST.TABLE_ID " +
					" WHERE (((TABLES_LIST.TABLE_NAME)='" ;
            
				switch (s_cb[i]) 
				{
					case 'c':
						stSql= stSql + "CHARGERS')) ORDER BY TABLES_CONTENT.TABLE_Line_id";
						cbPxx.Items.Clear (); 
						break;
					case 'v':  
						stSql= stSql + "VDCnominal')) ORDER BY cast(TABLES_CONTENT.VALUE1 AS float) ";
						cbVdc.Items.Clear (); 
						break;
					case 'i':  
						stSql= stSql + "IDC')) ORDER BY TABLES_CONTENT.TABLE_Line_id";
						cbIdc.Items.Clear (); 
						break;
				}
				SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
				OConn.Open ();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql ;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();
				while (Oreadr.Read ())
				{
					switch (s_cb[i]) 
					{
						case 'c':
							if (Oreadr["VALUE1"].ToString().Substring(0,5)!= "P4000")  cbPxx.Items.Add( Oreadr["VALUE1"].ToString()  ); 
							break;
						case 'v':  
							cbVdc.Items.Add( Oreadr["VALUE1"].ToString()  ); 
							break;
						case 'i':  
							cbIdc.Items.Add( Oreadr["VALUE1"].ToString()  ); 
							break;
					}
				  
				}
				OConn.Close(); 
			}
		}
		private void Maj_VDCMax()
		{
			if (tCellN.Text !="" && Uchng.Text =="Y" )
			{
				Maj_TV(); 
				double vcellMin = (optNi.Checked ) ?  Tools.Conv_Dbl(lVcellMin_NI.Text) :Tools.Conv_Dbl(lVcellMin_LA.Text);
				double cfVcellMax = (optNi.Checked ) ?  Tools.Conv_Dbl(lNBC_NI.Text) :Tools.Conv_Dbl(lNBC_LA.Text);
				double Max_FLTEQ = Tools.Conv_Dbl(lFLT_EQ_SEC.Text) *    Math.Max( Tools.Conv_Dbl(tVEQL.Text),Tools.Conv_Dbl(tVFLOAT.Text) ); 
				tVdcMax.Text = Convert.ToString ( Math.Round(Math.Max(Tools.Conv_Dbl(tCellN.Text)*cfVcellMax ,Max_FLTEQ),2)); 
				tvdcMin.Text =  Convert.ToString ( vcellMin * Tools.Conv_Dbl(tCellN.Text));
		         
			}
		}

		
		private void Cal_MaxVdc(char c)
		{
			if (c=='V')
			{
				if (lvpcE_LA.Text=="") 
				{ 
					lNBC_NI.Text =  Cpt.seekCF("VcellMax-NI") ;
					lNBC_LA.Text= Cpt.seekCF("VcellMax-LA");
					lVcellMin_NI.Text =  Cpt.seekCF("VcellMin-NI") ;
					lVcellMin_LA.Text= Cpt.seekCF("VcellMin-LA");
					lvpcE_LA.Text = Cpt.seekCF("VPCEQ-LA");
					lvpcF_LA.Text = Cpt.seekCF("VPCFLT-LA");
					lvpcE_NI.Text = Cpt.seekCF("VPCEQ-NI");
					lvpcF_NI.Text = Cpt.seekCF("VPCFLT-NI");
					lFLT_EQ_SEC.Text  = Cpt.seekCF("FLT-EQ_SEC");
				}
				lIprim.Text =MainMDI.Std_VCS (cbPhs.Text , Charger.AvailId  ,"C_IPRIM");
				lstdvdcMin.Text=MainMDI.Std_VCS(cbPhs.Text , Charger.AvailId  ,"C_VDCMIN"); // Cpt.Cal_VCS(0,"C_VDCMIN");
				lstdvdcMax.Text = MainMDI.Std_VCS(cbPhs.Text ,  Charger.AvailId,"C_VDCMAX"); //Cpt.Cal_VCS(0,"C_VDCMAX");
				lstdVAC.Text = MainMDI.Std_VCS(cbPhs.Text ,  Charger.AvailId,"C_VAC"); //Cpt.Cal_VCS(0,"C_VAC");
				lRiple.Text = Cpt.Cal_VCS(0,"C_RIPLE");
			//+ 250506
				lVSECLN.Text = (cbPhs.Text =="3") ?  Cpt.Cal_VCS(0,"C_VSEC") : "0";
				lVSECLL.Text =  (cbPhs.Text =="3") ?  Cpt.Cal_VCS(0,"C_VSECLL") : "0";
				lIsh.Text =  Cpt.Cal_VCS(0,"C_ISH1");
				lW2.Text =  Cpt.Cal_VCS(0,"C_W2");
		    //+ 250506
				if (tCellN.Text =="" || Uchng.Text=="N" )
				{
					tVdcMax.Text=lstdvdcMax.Text;
					tvdcMin.Text = lstdvdcMin.Text;
					tVac.Text = lstdVAC.Text ; 
				}
				Maj_NBCELL();
				
			}
		}		
		private void Maj_NBCELL()
		{
			string dd = (optLA.Checked || optVrla.Checked  ) ?  Cpt.Cal_VCS(0,"C_NBCELL-LA") : Cpt.Cal_VCS(0,"C_NBCELL-NI");
			//	string dd = (optLA.Checked ) ?  Std_VCS(cbPhs.Text , Charger.AvailId ,"C_NBCELL-LA") : Std_VCS(cbPhs.Text , Charger.AvailId ,"C_NBCELL-NI");
			lstdCellN.Text =Convert.ToString(Math.Round(Tools.Conv_Dbl(dd),0));
			if (tCellN.Text =="" || Uchng.Text=="N") tCellN.Text = lstdCellN.Text ;
		}
	
		private void Vdc_Advice(string st)
		{ 
			double vMax=Tools.Conv_Dbl(lstdvdcMax.Text) , vMin=Tools.Conv_Dbl(tvdcMin.Text) ,vCal=Tools.Conv_Dbl(st);
			if (vCal > vMax) MessageBox.Show("Please Choose Nest Charger...");
			else if (vCal >= vMin && vCal<= vMax) tVdcMax.Text  = lstdvdcMax.Text ;
		}

		private void Maj_VPC(char c)
		{
		  
			if (optNi.Checked) 
			{
				lNcelCoef.Text =lNBC_NI.Text  ;
				tvpcEq.Text =  lvpcE_NI.Text  ;
				tvpcF.Text =  lvpcF_NI.Text   ;
				    
			}
			else
			{
				if (optLA.Checked)  
				{
					lNcelCoef.Text =lNBC_LA.Text  ;
					tvpcEq.Text = lvpcE_LA.Text   ;
					tvpcF.Text = lvpcF_LA.Text   ;
				}
				else      //VRLA ?????
				{
					lNcelCoef.Text =lNBC_LA.Text  ;
					tvpcF.Text = lvpcF_LA.Text; 
					tvpcEq.Text = lvpcF_LA.Text ;
				}
			}

			Maj_TV(); 
		   



		}
	
		/*
			private void FindVDCIDC(string p,string c,long Avail_ID,out string vdc,out string idc)
			{
			
					string stSql= " SELECT vdc,idc FROM TBLAVAIL " + p + " WHERE (Avail_ID)=" + Avail_ID + "))";

					SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
					OConn.Open ();
					SqlCommand Ocmd = OConn.CreateCommand();
					Ocmd.CommandText = stSql ;
					SqlDataReader Oreadr = Ocmd.ExecuteReader();
					while (Oreadr.Read ())
					{  
						vdc=Oreadr["vdc"].ToString ();
						idc=Oreadr["idc"].ToString ();
						break;
					}
					OConn.Close (); 
				
			
			}

		*/

		private void Maj_TV()
		{
			if (tCellN.Text !="" && tvpcEq.Text !="" && tvpcF.Text !="" ) //&& Uchng.Text =="N" )
			{
				if (tVEQL.ReadOnly )  tVEQL.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tvpcEq.Text) * Tools.Conv_Dbl(tCellN.Text),2));
                if (tVFLOAT.ReadOnly) tVFLOAT.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tvpcF.Text) * Tools.Conv_Dbl(tCellN.Text), 2)); 
			}
		}
        private void maj_tvpcEq()
        {
            tvpcEq.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tVEQL.Text) / Tools.Conv_Dbl(tCellN.Text),2));
        }
        private void maj_tvpcF()
        {
            tvpcF.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tVFLOAT.Text ) / Tools.Conv_Dbl(tCellN.Text),2));
        }


  
        // before adding Design Info
		private void buil_chrg_Ref_old()
		{
            lChrgREF.Text = cbPxx.Text + "-" + cbPhs.Text + "-" + cbVdc.Text + "-" + cbIdc.Text;
            
			if (cbPxx.Text !="" && cbPhs.Text !="" && cbVdc.Text !="" && cbIdc.Text !="") 
			{
				NewChrg();
				Cal_MaxVdc('V');
				Maj_VPC('D');
			}
			

		}
       
         

        private void buil_chrg_Ref()
        {
            //Uchng.Text ="N";

            
           // lChrgREF.Text = cbPxx.Text + "-" + cbPhs.Text + "-" + cbVdc.Text + "-" + cbIdc.Text;
            lChrgREF.Text = cbPxx.Text + "-" + cbPhs.Text + "-" + cbVdc.Text + "-" + cbIdc.Text + lsep.Text + ldesign.Text + lsep2.Text + ldesign2.Text + lsep3.Text + ldesign3.Text;
         
            if (cbPxx.Text != "" && cbPhs.Text != "" && cbVdc.Text != "" && cbIdc.Text != "")
            {
                //this.Cursor = Cursors.WaitCursor;  
                NewChrg();
                Cal_MaxVdc('V');
                Maj_VPC('D');
                //	Sav_Usr_Val();
                //	fill_Def_options();
                lChrgREF.BackColor = (cbPxx.Text.Substring(0, 5) == "P4600") ? Color.Green : Color.Blue;  
            }


        }

		private void cbPxx_SelectedValueChanged(object sender, System.EventArgs e)
		{
            if (cbPxx.Text.Substring(0, 5) == "P4500" || cbPxx.Text.Substring(0, 5) == "P4600") buil_chrg_Ref();
			bool tt=(cbPxx.Text.Substring(0,5) == "P5500")  ;
			lmin.Visible=tt;
			lxxx.Visible =tt;
			cbXXX.Visible =tt;
		}
		private void Maj_VDC(char c)
		{
			if (c=='V') buil_chrg_Ref();
		}

		private void cbPhs_SelectedValueChanged(object sender, System.EventArgs e)
		{
			buil_chrg_Ref();
		}

		private void cbVdc_SelectedValueChanged(object sender, System.EventArgs e)
		{
			
			Maj_VDC('V');
		}

		private void EquiV_IDC(string I)
		{
			switch (I)
			{
				case "6":
					cbIdc.Text ="10";
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
			
			Maj_IDC('I');
		}
		private void Ref_Chrg_Info()
		{


			//	if (lChrgREF.Text != "")
				
		}
		private void Maj_IDC(char c)
		{
			if (c=='I') buil_chrg_Ref();
			//	if (optCalc.Checked ) 
			//	{
			tIdcMin.Text ="0";
            tIdcMax.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(cbIdc.Text) * 100 / 100, Charger.NB_DEC_AFF));  //coef=1 modified: 01092010
		//	tIdcMax.Text = Convert.ToString(Math.Round (Tools.Conv_Dbl(cbIdc.Text) * 120 /100,Charger.NB_DEC_AFF ));  //coef=1.2
			//	}
		}

		private void button1_Clickooo(object sender, System.EventArgs e)
		{ 
			/*if (lchrgOKz.Text !="OK")
			{
				CHRGR  =new Charger(MainMDI.M_stCon ,lFV.Text , cbPxx.Text ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text);
				Cpt=new Component();
				lchrgOKz.Text ="OK";
			}
			label10.Text = Cpt.Cal_VCS(0,cbVCS.Text  ).ToString ();
			*/
		}
		private void cal_VCS_CPT(char Cpt_Vcs,string NME)
		{
			CHRGR  =new Charger(-1 ,lFV.Text , txcbPxx.Text ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text,tVac.Text ,tVdcMax.Text  );
			Cpt=new Component();
			if (Cpt_Vcs=='V') lresVCS.Text = Cpt.Cal_VCS(0,NME  ).ToString ();
			else
			{
				Cpt.CPT_COST(Convert.ToInt32(lcptID.Text ));  
				lresCpt.Text = Cpt.G_PRICE; 
			}
		
			
			// MessageBox.Show ("TSTVAr= " + CHRGR.Cpt_List[0].G_PRICE);  
		}
		private void button1_Click(object sender, System.EventArgs e)
		{ 
			cal_VCS_CPT('V',cbVCS.Text);
	
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
			double dMin=Tools.Conv_Dbl(lstdvdcMin.Text) ;
			double dMin_FL_EQ= Math.Min(Tools.Conv_Dbl(tVFLOAT.Text),Tools.Conv_Dbl(tVEQL.Text));
			double dMaxCal=Tools.Conv_Dbl(tVdcMax.Text);
			double dMax=Tools.Conv_Dbl(lstdvdcMax.Text);
			if (dMaxCal > dMax)  return 'H';
			else	if (dMin_FL_EQ < dMin  )  return 'L';
			return 'R' ;
		}
	
		private long Cal_Valid_Charger(char c,double m_vdcMAX,double m_vdcMin ,ref string V,string I)
		{
		
			string stSql="";
			V="";
			if (c=='H') stSql="SELECT BGF_VCS13.*, TBLAVAIL1.charger, TBLAVAIL1.vdc, TBLAVAIL1.idc FROM BGF_VCS13 INNER JOIN TBLAVAIL1 ON BGF_VCS13.Avail_ID = TBLAVAIL1.Avail_ID " +
							" WHERE (((BGF_VCS13.VCS_NAME)='C_VDCMAX') AND (TBLAVAIL1.idc='" + I + "') AND ((cast([BGF_VCS13].[Value] AS float))>=" + m_vdcMAX + " )) AND ((BGF_VCS13.phs)='" + Charger.P + "')" +
							" ORDER BY cast([BGF_VCS13].[Value] AS float)";

			else stSql="SELECT BGF_VCS13.*, TBLAVAIL1.charger, TBLAVAIL1.vdc, TBLAVAIL1.idc " +
					 " FROM BGF_VCS13 INNER JOIN TBLAVAIL1 ON BGF_VCS13.Avail_ID = TBLAVAIL1.Avail_ID " +
					 " WHERE (((BGF_VCS13.VCS_NAME)='C_VDCMIN') AND (TBLAVAIL1.idc='" + I + "') AND ((cast([BGF_VCS13].[Value] AS float))<=" + m_vdcMin  + ")) AND ((BGF_VCS13.phs)='" + Charger.P + "') " +
					 " ORDER BY cast([BGF_VCS13].[Value] AS float) DESC" ;

			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ())
			{  
				V=Oreadr["vdc"].ToString ();
				return Convert.ToInt32(Oreadr["Avail_ID"].ToString ())	;
			}
			OConn.Close (); 
			return 0;
		}

        private string find_CHARGER_COST(string _PXX, string _PHS, string _VDC, string _IDC)
        {
            double dd = 0;
            bool loop = false;
          //  _PXX.Replace("4600", "4500");  
            while (dd ==0)
            {
               dd =Tools.Conv_Dbl(find_CHARGER_COST_loop(_PXX, _PHS, _VDC, _IDC));
                if (dd == 0)
                {
                    if (!loop) loop = MainMDI.Confirm("The PRICE for this Charger is Not Available..... Continue to take next IDC ?");
                    if (loop)
                    {
                        int ndx = cbIdc.FindStringExact(_IDC);
                        if (ndx == -1) dd = 9999999;
                        else _IDC = cbIdc.Items[ndx + 1].ToString();
                    }
                    else dd = 9999999;

                }

            }
            
            return dd.ToString(); ;
        }

        private string find_CHARGER_COST_loop(string PXX, string PHS, string VDC, string IDC)
        {
            //            string stSql = " SELECT TBLTOXL0" + PHS + ".* FROM TBLTOXL0" + PHS + " WHERE (TBLTOXL0" + PHS + ".COMPONENT='" + PXX + "_LIST') AND (TBLTOXL0" + PHS + ".REF_CHRG='" + PXX + "_LIST-" + VDC + "' OR TBLTOXL0" + PHS + ".REF_CHRG='" + PXX + "-" + PHS +"-" + VDC + "')";
            string stSql = " SELECT TBLTOXL0" + PHS + ".* FROM TBLTOXL0" + PHS + " WHERE (TBLTOXL0" + PHS + ".COMPONENT='" + PXX + "_LIST') AND (TBLTOXL0" + PHS + ".REF_CHRG='" + PXX + "_LIST-" + VDC + "' OR TBLTOXL0" + PHS + ".REF_CHRG='" + "P4500" + "-" + PHS + "-" + VDC + "')";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read()) return Oreadr[IDC].ToString();
            return Charger.VIDE;


        }








        private string find_CHARGER_COSTOLD_OK(string PXX, string PHS, string VDC, string IDC)
        {
            string stSql = " SELECT TBLTOXL0" + PHS + ".* FROM TBLTOXL0" + PHS + " WHERE (TBLTOXL0" + PHS + ".COMPONENT='" + PXX + "_LIST') AND (TBLTOXL0" + PHS + ".REF_CHRG='" + PXX + "_LIST-" + VDC + "')";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read()) return Oreadr[IDC].ToString();
            return Charger.VIDE;


        }

		private void btnCost_Click(object sender, System.EventArgs e)
		{
			
			string msg1="",msg="";
			bool chng=true;
			oldVdc.Text = cbVdc.Text ;  
			string v="";
			double MN_EQFLT=Math.Min(Tools.Conv_Dbl(tVEQL.Text ), Tools.Conv_Dbl(tVFLOAT.Text  ));
			char c=Valid_Charger();
			if (c=='L' || c=='H') 
			{   
				msg1= (c=='L') ? "You may choose a Lower Charger Model....!!!!" : "You may choose a Higher Charger Model....!!!!";
				DialogResult dr=MessageBox.Show(msg1,"Bad Charger Model",MessageBoxButtons.YesNo,MessageBoxIcon.Question );    ; 
				if (dr == DialogResult.Yes )
				{ 
					long AVID=Cal_Valid_Charger(c,Tools.Conv_Dbl(tVdcMax.Text) ,MN_EQFLT,ref v,cbIdc.Text   );
					if (v!="") 
					{
							string VX=MainMDI.Std_VCS(cbPhs.Text ,  AVID,"C_VDCMAX");  
						string VN=MainMDI.Std_VCS(cbPhs.Text ,  AVID,"C_VDCMIN");  
						if (c=='L' && Tools.Conv_Dbl(tVdcMax.Text) > Tools.Conv_Dbl(VX)) 
						{
							chng=false; 
							msg=" Can not Move to Low " + v +"V !!! its VDCMAX is Low...." + "\n" +" The actual Model seems be ideal even its VdcMin is too Low..."; 
						}
						if (c=='H' && MN_EQFLT < Tools.Conv_Dbl(VN)) msg="Min(EQL,FLT) is too Low..."; 
						if (chng) cbVdc.Text =v;
						if (msg!="") MessageBox.Show (msg );
					}
					else MessageBox.Show ("Please Consult Engineering.... !!!");
				}
			}
			if (tVdcMax.Text !=lstdvdcMax.Text   || tVac.Text != lstdVAC.Text )
				fill_Def_options(tVdcMax.Text ,tVac.Text   );
			else   fill_Def_options();
			btnCancel.Enabled =lvDefOption.Items.Count >0; 
			btnOK.Enabled =btnCancel.Enabled; 
			// btnAlarm.Enabled =true; 
			lnkAlarm.Enabled =true;
			pictureBox2.Enabled =true;
	        
			
		   
		}

		private void fill_Def_options()
		{
			//	 t1.Text = System.DateTime.Now.Second.ToString (); 
			this.Cursor = Cursors.WaitCursor;  

			string stSql = "select * from COMPNT_LIST where Compnt_Type='E' or Compnt_Type='D'  order by Component_ID";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			lvDefOption.Items.Clear ();
			while (Oreadr.Read ())	find_CPT_Cost(Oreadr["Component_ID"].ToString(),Oreadr["COMPONENT_REF"].ToString(),Oreadr["Component_Name"].ToString(),Oreadr["CatName1"].ToString(),Oreadr["CatName2"].ToString(),Oreadr["CatName3"].ToString());
		
			if (lvDefOption.Items.Count !=0)    addSTDFeat();
			Oreadr.Close();
			OConn.Close (); 
			this.Cursor = Cursors.Default ; 
			// t2.Text = System.DateTime.Now.Second.ToString (); 
		}

		private void fill_Def_options(string m_vdcMax,string m_Vac)
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
					//CHRGR  =new Charger(0 ,lFV.Text , txcbPxx.Text ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text,tVac.Text,tVdcMax.Text );
					CHRGR  =new Charger(0 ,lFV.Text , txcbPxx.Text.Substring(0,5)  ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text,tVac.Text,tVdcMax.Text );
					debut=1;
					 
				}
				Cpt=new Component();
				 
				string tt=Cpt.Cal_chrg_CostADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()),"C"); 
				lIprim.Text = Cpt.Cal_VCS(0,"C_IPRIM");
				lhrtZMRK.Text = Cpt.Cal_VCS(0,"C_HRTZ" + lhrtz.Text  );
				
				if (tt==MainMDI.VIDE ) MessageBox.Show("This default option: " + Oreadr["COMPONENT_REF"].ToString() +" was not found  !!!!"); 
				else
				{
					if (lvDefOption.Items.Count==0) addchRef();
					 
					if (Cpt.G_PRICE != Charger.VIDE )
					{
						ListViewItem lvI= lvDefOption.Items.Add( ""  );
						lvI.Checked =true; 
						//	string stt= (MainMDI.Lang ==0) ?  Cpt.CAP4.ToString()+", " +Cpt.CAP5.ToString()+", " +Cpt.CAP6.ToString() : Cpt.CAP7.ToString()+", " +Cpt.CAP8.ToString()+", " +Cpt.CAP9.ToString(); 

						//string stt= Cpt.CAP4.ToString()+ ", " +Cpt.CAP5.ToString()+", " +Cpt.CAP6.ToString();
						lvI.SubItems.Add(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()));
						//lvI.SubItems.Add(Cpt.G_Desc.ToString()); 
						string stt="";
						stt+= (Cpt.CAP4==MainMDI.VIDE ) ? "" : " " + Cpt.CAP4;
						stt+= (Cpt.CAP5 ==MainMDI.VIDE ) ? "" : " " + Cpt.CAP5;
						stt+= (Cpt.CAP6==MainMDI.VIDE ) ? "" :  " " + Cpt.CAP6;
						stt+= (Cpt.CAP7==MainMDI.VIDE ) ? "" : " " +  Cpt.CAP7;
						//	stt+= (Oreadr["CAP4fr"].ToString()==MainMDI.VIDE ) ? "" :  Oreadr["CAP4fr"].ToString();
						//	stt+= (Oreadr["CAP5fr"].ToString()==MainMDI.VIDE ) ? "" :  Oreadr["CAP5fr"].ToString();
						//	stt+= (Oreadr["CAP6fr"].ToString()==MainMDI.VIDE ) ? "" :  Oreadr["CAP6fr"].ToString();
						//	stt+= (Oreadr["CAP7fr"].ToString()==MainMDI.VIDE ) ? "" :  Oreadr["CAP7fr"].ToString();
					
						lvI.SubItems.Add(stt); //  +" -->"+ Oreadr["Component_Name"].ToString());
						lvI.SubItems.Add(tPxxQty.Text); 
						lvI.SubItems.Add( "0");  //lvI.SubItems.Add( "$ " + Cpt.G_PRICE.ToString()); 
						lvI.SubItems.Add("0" ); 
						lvI.SubItems.Add( tLTime.Text); 
						lvI.SubItems.Add(Oreadr["CatName1"].ToString()+"=" + Cpt.CAP1.ToString() ); 
						if (Oreadr["CatName2"].ToString()!=Charger.VIDE )  lvI.SubItems.Add( Oreadr["CatName2"].ToString()+"=" +Cpt.CAP2.ToString()); 
						else lvI.SubItems.Add("" ); 
						if (Oreadr["CatName3"].ToString()!=Charger.VIDE ) lvI.SubItems.Add( Oreadr["CatName3"].ToString()+"=" +Cpt.CAP3.ToString()); 
						else lvI.SubItems.Add("" ); 
						lvI.SubItems.Add(Oreadr["COMPONENT_REF"].ToString()); 
						//	lvI.SubItems.Add(Oreadr["Component_Name"].ToString());
						lvI.SubItems.Add(Cpt.G_Desc );
						if (valSTD_changed()) lvI.SubItems[0].ForeColor = Color.Red ;
                        lvI.Checked = true;
						//Uncheck by default TB123/TB45 requested by Sam on: 13-12-2005
						if (Oreadr["COMPONENT_REF"].ToString().IndexOf("TB-")!=-1 || Oreadr["COMPONENT_REF"].ToString().IndexOf("EN1")!=-1)  lvI.Checked = false;
						//	 
					}
				}
			}
			//	 lIprim.Text = Cpt.Cal_VCS(0,"C_IPRIM");
			
			if (lvDefOption.Items.Count !=0)    addSTDFeat();
			OConn.Close (); 
			this.Cursor = Cursors.Default ; 
			//t2.Text = System.DateTime.Now.Second.ToString (); 
		}

		private void Cal_CPT_noAvailID(string cptID)
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
					//CHRGR  =new Charger(0 ,lFV.Text , cbPxx.Text ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text,tVac.Text,tVdcMax.Text );
					CHRGR  =new Charger(0 ,lFV.Text , txcbPxx.Text.Substring(0,5)  ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text,tVac.Text,tVdcMax.Text );
					debut=1;
					 
				}
				Cpt=new Component();
				 
				string tt=Cpt.Cal_chrg_CostADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()),"C"); 
				lIprim.Text = Cpt.Cal_VCS(0,"C_IPRIM");
				lhrtZMRK.Text = Cpt.Cal_VCS(0,"C_HRTZ" + lhrtz.Text  );
				
				if (tt==MainMDI.VIDE ) MessageBox.Show("This default option: " + Oreadr["COMPONENT_REF"].ToString() +" was not found  !!!!"); 
				else
				{
					if (lvDefOption.Items.Count==0) addchRef();
					 
					if (Cpt.G_PRICE != Charger.VIDE )
					{
						ListViewItem lvI= lvDefOption.Items.Add( ""  );
						lvI.Checked =true; 
						//	string stt= (MainMDI.Lang ==0) ?  Cpt.CAP4.ToString()+", " +Cpt.CAP5.ToString()+", " +Cpt.CAP6.ToString() : Cpt.CAP7.ToString()+", " +Cpt.CAP8.ToString()+", " +Cpt.CAP9.ToString(); 

						//string stt= Cpt.CAP4.ToString()+ ", " +Cpt.CAP5.ToString()+", " +Cpt.CAP6.ToString();
						lvI.SubItems.Add(MainMDI.optDesc(MainMDI.Lang, Oreadr["Component_Name"].ToString()));
						//lvI.SubItems.Add(Cpt.G_Desc.ToString()); 
						string stt="";
						stt+= (Cpt.CAP4==MainMDI.VIDE ) ? "" : " " + Cpt.CAP4;
						stt+= (Cpt.CAP5 ==MainMDI.VIDE ) ? "" : " " + Cpt.CAP5;
						stt+= (Cpt.CAP6==MainMDI.VIDE ) ? "" :  " " + Cpt.CAP6;
						stt+= (Cpt.CAP7==MainMDI.VIDE ) ? "" : " " +  Cpt.CAP7;
						//	stt+= (Oreadr["CAP4fr"].ToString()==MainMDI.VIDE ) ? "" :  Oreadr["CAP4fr"].ToString();
						//	stt+= (Oreadr["CAP5fr"].ToString()==MainMDI.VIDE ) ? "" :  Oreadr["CAP5fr"].ToString();
						//	stt+= (Oreadr["CAP6fr"].ToString()==MainMDI.VIDE ) ? "" :  Oreadr["CAP6fr"].ToString();
						//	stt+= (Oreadr["CAP7fr"].ToString()==MainMDI.VIDE ) ? "" :  Oreadr["CAP7fr"].ToString();
					
						lvI.SubItems.Add(stt); //  +" -->"+ Oreadr["Component_Name"].ToString());
						lvI.SubItems.Add(tPxxQty.Text); 
						lvI.SubItems.Add( "0");  //lvI.SubItems.Add( "$ " + Cpt.G_PRICE.ToString()); 
						lvI.SubItems.Add("0" ); 
						lvI.SubItems.Add( tLTime.Text); 
						lvI.SubItems.Add(Oreadr["CatName1"].ToString()+"=" + Cpt.CAP1.ToString() ); 
						if (Oreadr["CatName2"].ToString()!=Charger.VIDE )  lvI.SubItems.Add( Oreadr["CatName2"].ToString()+"=" +Cpt.CAP2.ToString()); 
						else lvI.SubItems.Add("" ); 
						if (Oreadr["CatName3"].ToString()!=Charger.VIDE ) lvI.SubItems.Add( Oreadr["CatName3"].ToString()+"=" +Cpt.CAP3.ToString()); 
						else lvI.SubItems.Add("" ); 
						lvI.SubItems.Add(Oreadr["COMPONENT_REF"].ToString()); 
						//	lvI.SubItems.Add(Oreadr["Component_Name"].ToString());
						lvI.SubItems.Add(Cpt.G_Desc );
						if (valSTD_changed()) lvI.SubItems[0].ForeColor = Color.Red ;

						//Uncheck by default TB123/TB45 requested by Sam on: 13-12-2005
						  lvI.Checked =(Oreadr["COMPONENT_REF"].ToString().IndexOf("TB-")==-1) ; 
						//	 
					}
				}
			}
			//	 lIprim.Text = Cpt.Cal_VCS(0,"C_IPRIM");
			
			if (lvDefOption.Items.Count !=0)    addSTDFeat();
			OConn.Close (); 
			this.Cursor = Cursors.Default ; 
			//t2.Text = System.DateTime.Now.Second.ToString (); 
		}

		/// <summary>
		/// 
		/// </summary>
		/// 
		private string find_EDrw_BOM(string Pxxx ,string P ,string V ,string I )
		{
		  	string stSql="SELECT     DRW_DESC, BOM_DESC FROM   PSM_DRAW_BOM_Chargers " +
                                   " WHERE     Pxxxx = '" + Pxxx +  "' AND phs = '" + P +  "' AND " + V +  " >= VdcFrom AND " + V +  " <= VdcTo AND " + I +  " >= IdcFrom AND " + I +  " <= IdcTo ";
    		SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			stSql="~~" ;
			while (Oreadr.Read ())	
				stSql= Oreadr["DRW_DESC"].ToString() + "~~" + Oreadr["BOM_DESC"].ToString() ;
			Oreadr.Close();
			OConn.Close (); 
			return stSql;
			

		}

		private void addchRef()
		{
			ListViewItem lvI= lvDefOption.Items.Add( ""  );
			lvI.Checked =true; 
		//	lvI.SubItems.Add( MainMDI.arr_EFSdict[10,L ] ); 	lvI.BackColor  =Color.Salmon  ; 
			lvI.SubItems.Add( MainMDI.arr_EFSdict[10,L ]+" " +lChrgREF.Text  ); 	lvI.BackColor  =Color.Salmon  ; 
			lvI.SubItems.Add( " ");
			lvI.SubItems.Add(tPxxQty.Text ); 
			string cost = find_CHARGER_COST(txcbPxx.Text ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text ); 
		
			cost = Convert.ToString(Math.Round(Tools.Conv_Dbl(cost) * Tools.Conv_Dbl(lhrtZMRK.Text ),0));   
			lvI.SubItems.Add( cost); 
			lvI.SubItems.Add( Convert.ToString(Math.Round(Tools.Conv_Dbl(tPxxQty.Text) * Tools.Conv_Dbl(cost),Charger.NB_DEC_AFF))); 
			lvI.SubItems.Add( tLTime.Text ); 
	        endLV(lvI ,6);
			lvI.SubItems[11].Text = find_EDrw_BOM(txcbPxx.Text ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text );
			

			lvI= lvDefOption.Items.Add( ""  );
			lvI.Checked =true; 
			lvI.SubItems.Add( MainMDI.arr_EFSdict[11,L ]); 
			lvI.SubItems.Add( lChrgREF.Text );
			endLV(lvI ,3);
	      
			lvI= lvDefOption.Items.Add( ""  );
			lvI.Checked =true; 
			lvI.SubItems.Add(MainMDI.arr_EFSdict[12,L ]); //12=Input   13=Volts 
            lvI.SubItems.Add(tVac.Text + " " + MainMDI.arr_EFSdict[13, L] + " +10/-12%, " + cbPhs.Text + " " + MainMDI.arr_EFSdict[43, L] + ", " + lhrtz.Text + " Hertz, " + Math.Round(Tools.Conv_Dbl(lIprim.Text), 0) + " A"); //12=Input   13=Volts 
			endLV(lvI ,3);
			lvI.SubItems[10].Text="C_IV";

			lvI= lvDefOption.Items.Add( ""  );
			lvI.Checked =true; 
			lvI.SubItems.Add(MainMDI.arr_EFSdict[14,L ]);  //14=Output Voltage  15=Vdc  
			lvI.SubItems.Add(cbVdc.Text + " " + MainMDI.arr_EFSdict[15,L ] + " " + MainMDI.arr_EFSdict[32,L ]+ ":"+"     Min " + MainMDI.arr_EFSdict[15,L ]+ ": " + tvdcMin.Text + "     Max " + MainMDI.arr_EFSdict[15,L ]+ ": " + tVdcMax.Text);  //14=Output Voltage  15=Vdc  
			endLV(lvI ,3);
			lvI.SubItems[10].Text="C_OV";

			lvI= lvDefOption.Items.Add( ""  );   //14=Output Current 
			lvI.Checked =true; 
			lvI.SubItems.Add(MainMDI.arr_EFSdict[16,L ])  ;
			lvI.SubItems.Add(cbIdc.Text  + " " + MainMDI.arr_EFSdict[17,L ]+ " " + MainMDI.arr_EFSdict[32,L ]+ ":"+"     Min " + MainMDI.arr_EFSdict[33,L ]+ ": " + tIdcMin.Text  +  "     Max " + MainMDI.arr_EFSdict[33,L ]+ ": " + tIdcMax.Text)  ;
			endLV(lvI ,3);
			lvI.SubItems[10].Text="C_OC";

			//	AddTec_Values("","Min. VDC: " + tvdcMin.Text,true ); 
			//	AddTec_Values("","Max. VDC: " + tVdcMax.Text,true  ); 
			//	AddTec_Values("","Min. IDC: " + tIdcMin.Text,true  ); 
			//	AddTec_Values("","Max. IDC: " + tIdcMax.Text ,true ); 
			//if (Oreadr["CatName2"].ToString()!=Charger.VIDE )  lvI.SubItems.Add( " "); 
			//if (Oreadr["CatName3"].ToString()!=Charger.VIDE ) lvI.SubItems.Add( " "); 
		}
	
		private void endLV(ListViewItem lvI ,int coln)
		{
			for (int i=coln ;i<12;i++ ) lvI.SubItems.Add( ""); 
		}

        

		private void dlg_arr_frml_fill()
		{
			for (int i=0;i<Charger.NB_FRML;i++)
			{
				if (Charger.arr_CAL_FRML[i]=="") {dlg_arr_frml_NDX =i; break;}
				else dlg_arr_CAL_FRML[i]= Charger.arr_CAL_FRML[i];
			}
		}
		private void dlg_arr_frml_Ovals()
		{

			dlg_arr_CAL_FRML[dlg_arr_frml_NDX++]="Float||" + tVFLOAT.Text;
			dlg_arr_CAL_FRML[dlg_arr_frml_NDX++]="Eq||" +  tVEQL.Text ;
			dlg_arr_CAL_FRML[dlg_arr_frml_NDX++]="RPL||" + lRiple.Text;
			dlg_arr_CAL_FRML[dlg_arr_frml_NDX++]="FHZ||" + lhrtz.Text;



 
			//add 280606
			for (int i=0;i<lvOTI.Items.Count ;i++) 
			{
				for (int j=4;j<7;j++)
				{
					if (lvOTI.Items[i].SubItems[j].Text !=MainMDI.VIDE )
					{
						string cpT=(lvOTI.Items[i].Checked ) ? cal_CPT(-1  ,lvOTI.Items[i].SubItems[j].Text.Substring(2,lvOTI.Items[i].SubItems[j].Text.Length -2) ) : MainMDI.VIDE  ; 
						dlg_arr_CAL_FRML[dlg_arr_frml_NDX++] = lvOTI.Items[i].SubItems[j].Text + "||" + cpT ;
					}
				}
				
			}
            //add 280606
	

			
		}
		private void addSTDFeat()
		{

			//AddTec_Values("","Cell#: " + tCellN.Text + ", VAC:" + tVac.Text +", Float: " + tVFLOAT.Text + ", Equalize: " + tVEQL.Text  ,true ); 
			dlg_arr_frml_fill();
			AddTec_Values("","VAC:" + tVac.Text +", Float: " + tVFLOAT.Text + ", Equalize: " + tVEQL.Text  ,true,"C_VFE" );
            if (!tRPL.ReadOnly && tRPL.Text !=""  ) lRiple.Text = tRPL.Text;
            else tRPL.Text=lRiple.Text ;
            tRPL.ReadOnly = true;
         //   AddTec_Values("",MainMDI.arr_EFSdict[19,L ] + " " + lRiple.Text + " " +  MainMDI.arr_EFSdict[20,L ],true,"C_RPL" );
            AddTec_Values("", MainMDI.arr_EFSdict[19, L] + " " + lRiple.Text , true, "C_RPL");
			dlg_arr_frml_Ovals();
			//dlg_Arr_frml_Disp(); 
			string stSql = "select * from PSM_ALLSTD where ItemCode='C' order by rnk";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ; 
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
	//		AddTec_Values("",MainMDI.arr_EFSdict[18,L ]+"=   " ,true,"D_" ); 
			while (Oreadr.Read ()) 
			{ 
				if ( Oreadr[L+2].ToString()!="" && Oreadr["disp"].ToString() =="1") AddTec_Values("",Oreadr[L+2].ToString() ,true,"D_" ); 
			}
	
			
		}
		
	/*	
		private void fill_stdFeat()
		{
			string stSql = "select * from PSM_STDFEATURES where ItemCode='C' order by rnk";
			SqlConnection OConn2  = new SqlConnection(MainMDI.M_stCon  );
			OConn2.Open ();
			SqlCommand Ocmd2 = OConn2.CreateCommand();
			Ocmd2.CommandText = stSql ;
			SqlDataReader Oreadr2 = Ocmd2.ExecuteReader();
			while (Oreadr2.Read ())	AddTec_Values(Oreadr2["std"].ToString() ,true ); 
		}

	*/

		private void find_CPT_Cost(string Cpt_ID,string Cpt_Ref,string EFRef,string cat1,string cat2,string cat3)
		{
                // find CPT cost in XL file ..
			string stSql = "SELECT BGF_COST13.* FROM BGF_COST13 " +
				" WHERE (((BGF_COST13.phs)='" + Charger.P +  "') " +
				" AND ((BGF_COST13.Avail_ID)=" + Charger.AvailId +  ") " +
				" AND ((BGF_COST13.Compnt_ID)=" + Cpt_ID  + ")) ORDER BY BGF_COST13.Compnt_ID";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ())
			{
			   if (lvDefOption.Items.Count==0)  addchRef();
				
		
				if (Oreadr["Cost"].ToString() != Charger.VIDE )
				{
					ListViewItem lvI= lvDefOption.Items.Add( ""  );
					lvI.Checked =true; 
					lvI.SubItems.Add(MainMDI.optDesc(MainMDI.Lang, EFRef) );
				//	lDescc.Text = Oreadr["desc"].ToString();
                    string stt="";
					stt+= (Oreadr["CAP4"].ToString()==MainMDI.VIDE ) ? "" :  " " + Oreadr["CAP4"].ToString();
					stt+= (Oreadr["CAP5"].ToString()==MainMDI.VIDE ) ? "" : " " +  Oreadr["CAP5"].ToString();
					stt+= (Oreadr["CAP6"].ToString()==MainMDI.VIDE ) ? "" :  " " + Oreadr["CAP6"].ToString();
					stt+= (Oreadr["CAP7"].ToString()==MainMDI.VIDE ) ? "" :  " " + Oreadr["CAP7"].ToString();
				              	//string stt=Oreadr["CAP4"].ToString() + ", " + Oreadr["CAP5"].ToString()+ ", " + Oreadr["CAP6"].ToString();
					lvI.SubItems.Add(stt); // +" -->"+ Oreadr["desc"].ToString());  
					lvI.SubItems.Add(tPxxQty.Text); 
					lvI.SubItems.Add( "0");   // because it's default option (cost=0) Must seek price in Options List !!!! Oreadr["Cost"].ToString ()); 
					lvI.SubItems.Add("0" ); 
					lvI.SubItems.Add( tLTime.Text); 
					lvI.SubItems.Add(cat1+"=" + Oreadr["CAP1"].ToString() ); 
					if (cat2!=Charger.VIDE )  lvI.SubItems.Add( cat2+"=" +Oreadr["CAP2"].ToString()); 
					else lvI.SubItems.Add(""); 
					if (cat3!=Charger.VIDE ) lvI.SubItems.Add( cat3+"=" +Oreadr["CAP3"].ToString()); 
					else lvI.SubItems.Add(""); 
					lvI.SubItems.Add(Cpt_Ref); 
				//	lvI.SubItems.Add(Oreadr["desc"].ToString());
					lvI.SubItems.Add(Cpt.G_Desc); 
				    
				}
			}
			OConn.Close ();
		}

		private void find_CPT_Costold(string Cpt_ID,string Cpt_Ref,string cat1,string cat2,string cat3)
		{
			// find CPT cost in XL file ..
			string stSql = "SELECT BGF_COST13.* FROM BGF_COST13 " +
				" WHERE (((BGF_COST13.phs)='" + Charger.P +  "') " +
				" AND ((BGF_COST13.Avail_ID)=" + Charger.AvailId +  ") " +
				" AND ((BGF_COST13.Compnt_ID)=" + Cpt_ID  + ")) ORDER BY BGF_COST13.Compnt_ID";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ())
			{
				if (lvDefOption.Items.Count==0) 
				{
					ListViewItem lvI= lvDefOption.Items.Add( ""  );
					//ListViewItem lvI= lvDefOption.Items.Add( "Charger "  );
					lvI.Checked =true; 
					lvI.SubItems.Add( "Charger"  ); 
					lvI.SubItems.Add( lChrgREF.Text  ); 
					lvI.BackColor  =Color.Salmon  ; 
					lvI.SubItems.Add( tPxxQty.Text ); 
					string cost = find_CHARGER_COST(txcbPxx.Text ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text ); 
					lvI.SubItems.Add( cost); 
					// if (cost=="0") MessageBox.Show("This default option was not found  !!!!");
					//MessageBox.Show ("Res= " +  Tools.Conv_Dbl(cost));
					lvI.SubItems.Add( Convert.ToString(Math.Round(Tools.Conv_Dbl(tPxxQty.Text) * Tools.Conv_Dbl(cost),Charger.NB_DEC_AFF))); 
					lvI.SubItems.Add( tLTime.Text ); 
					lvI.SubItems.Add(" " ); 
					if (cat2!=Charger.VIDE )  lvI.SubItems.Add( " "); 
					if (cat3!=Charger.VIDE ) lvI.SubItems.Add( " "); 
				}
				if (Oreadr["Cost"].ToString() != Charger.VIDE )
				{
					//	ListViewItem lvI= lvDefOption.Items.Add( Cpt_Ref );
				
					ListViewItem lvI= lvDefOption.Items.Add( ""  );
					lvI.Checked =true; 
					lvI.SubItems.Add(Cpt_Ref  );
					lvI.SubItems.Add(Oreadr["Desc"].ToString()   ); 
					lvI.SubItems.Add(tPxxQty.Text); 
					lvI.SubItems.Add( "0");   // because it's default option (cost=0) Must seek price in Options List !!!! Oreadr["Cost"].ToString ()); 
					lvI.SubItems.Add("0" ); 
					lvI.SubItems.Add( tLTime.Text); 
					lvI.SubItems.Add(cat1+"=" + Oreadr["CAP1"].ToString() ); 
					if (cat2!=Charger.VIDE )  lvI.SubItems.Add( cat2+"=" +Oreadr["CAP2"].ToString()); 
					if (cat3!=Charger.VIDE ) lvI.SubItems.Add( cat3+"=" +Oreadr["CAP3"].ToString()); 
				}
			}
			OConn.Close ();
		}
	
	
		private void AddTec_Values(string st0,string st,bool SHW,string cptREF)
		{
			ListViewItem lvI= lvDefOption.Items.Add("" );
			lvI.Checked =SHW ;
			lvI.SubItems.Add( st0 ); 
			lvI.SubItems.Add(  st  ); 
			for (int j=0 ;j<9;j++)
			{
				lvI.SubItems.Add(""); 
			}
			if (cptREF !="") lvI.SubItems[10].Text =cptREF ;  

		//		lvI.SubItems.Add( ""); 
		//		lvI.SubItems.Add("" ); 
		//		lvI.SubItems.Add( ""); 
		//		lvI.SubItems.Add(" " ); 
		//		lvI.SubItems.Add( " "); 
		//		lvI.SubItems.Add( " "); 
		//	}
  

		}
		/*
		private void fill_Def_optionsOLD(string m_vdcMax,string m_Vac)
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
					CHRGR  =new Charger(0 ,lFV.Text , cbPxx.Text ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text,tVac.Text,tVdcMax.Text );
					debut=1;
				}
				Cpt=new Component();
				//Cpt.CPT_COST(Convert.ToInt32(Oreadr["Component_ID"].ToString()));
				Cpt.Cal_chrg_CostADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()),"C"); 
				//	MessageBox.Show (Oreadr["COMPONENT_REF"].ToString()); 
				if (Cpt.G_PRICE != Charger.VIDE )
				{
					ListViewItem lvI= lvDefOption.Items.Add( Oreadr["COMPONENT_REF"].ToString());
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
			//t2.Text = System.DateTime.Now.Second.ToString (); 
		}

		*/

		private void NewChrg()
		{
		   CHRGR  =new Charger(0 ,lFV.Text , txcbPxx.Text ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text,"0","0");
		   Cpt = new Component();
			// lOldRef.Text = lChrgREF.Text ;		
		}

		private void tCellN_TextChanged(object sender, System.EventArgs e)
		{
			//Cal_MaxVdc('C');
			Maj_VDCMax();
		}

		private void optFx_CheckedChanged(object sender, System.EventArgs e)
		{
			lFV.Text ="F";
			tvdcMin.Text =lstdvdcMin.Text ; 

		}

		private void optNi_CheckedChanged(object sender, System.EventArgs e)
		{
			Maj_VPC('V');
			Maj_NBCELL(); 
		}

		private void optLA_CheckedChanged(object sender, System.EventArgs e)
		{
	    	Maj_VPC('V');
			Maj_NBCELL ();
		}

		private void cbXXX_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tvpcF_TextChanged(object sender, System.EventArgs e)
		{
           
			if (Tools.IsNumeric(tvpcF.Text )) Maj_VDCMax(); 
		}

		private void tCellN_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
	    	e.Handled =Tools.OnlyInt(e.KeyChar );
            Uchng.Text ="Y";
		}

		private void tVac_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled =Tools.OnlyDBL(e.KeyChar );
		//	Uchng.Text ="Y";
		}

		private void tvpcF_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		  e.Handled =Tools.OnlyDBL(e.KeyChar );
			Uchng.Text ="Y";
		}

		private void tvdcMin_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tvdcMin_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled =Tools.OnlyDBL(e.KeyChar );
		}

		private void tIdcMin_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		  e.Handled =Tools.OnlyDBL(e.KeyChar );
		}

		private void tIdcMax_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		  e.Handled =Tools.OnlyDBL(e.KeyChar );
		}

		private void tVdcMax_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tVdcMax_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			 e.Handled =Tools.OnlyDBL(e.KeyChar );
		}

		private void tvpcEq_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled =Tools.OnlyDBL(e.KeyChar );
			Uchng.Text ="Y";
		}

		private void tvpcEq_TextChanged(object sender, System.EventArgs e)
		{
		  Maj_VDCMax ();
		
		}



		private void optAuto_CheckedChanged(object sender, System.EventArgs e)
		{
		
			//gbxCalc.Enabled =optCalc.Checked ;
		}

		private void optCalc_CheckedChanged(object sender, System.EventArgs e)
		{
			
		
			Maj_VDC('N');
			Maj_IDC('N'); 
			//gbxCalc.Enabled =optCalc.Checked ;
		}

		private void optVar_CheckedChanged(object sender, System.EventArgs e)
		{
			lFV.Text ="V";
			tvdcMin.Text =Convert.ToString(Math.Round(Tools.Conv_Dbl(tVdcMax.Text )* 0.1,2))   ; 
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void cbXXX_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
		
		}

		private void cbPhs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void cbPhs_SelectedValueChanged_1(object sender, System.EventArgs e)
		{
            buil_chrg_Ref();		
		}


        private void selCHRGR()
        {
            //        if (cbPxx.Text.Substring(0, 5) == "P4600")
            //        {
            //             MessageBox.Show("Charger ERROR.....P4600xxxx is not Ready Yet......");
            //             cbPxx.Text = "P4500";
            //         }

            //         else
            //          {
            lFTTT.Text = cbPxx.Text.Substring(5, cbPxx.Text.Length - 5);
            string mdl = cbPxx.Text.Substring(0, 5);
            if (mdl == "P4500" || mdl == "P4600")
            {
                buil_chrg_Ref();
                txcbPxx.Text = cbPxx.Text.Replace("4600", "4500");
            }
            bool tt = (cbPxx.Text.Substring(0, 5) == "P5500");
            lmin.Visible = tt;
            lxxx.Visible = tt;
            cbXXX.Visible = tt;
            //       }
        }

        private void selCHRGR_OLD()
        {
                    if (cbPxx.Text.Substring(0, 5) == "P4600")
                    {
                         MessageBox.Show("Charger ERROR.....P4600xxxx is not Ready Yet......");
                         cbPxx.Text = "P4500";
                     }

                     else
                      {
            lFTTT.Text = cbPxx.Text.Substring(5, cbPxx.Text.Length - 5);
            string mdl = cbPxx.Text.Substring(0, 5);
            if (mdl == "P4500" || mdl == "P4600")
            {
                buil_chrg_Ref();
                txcbPxx.Text = cbPxx.Text.Replace("4600", "4500");
            }
            bool tt = (cbPxx.Text.Substring(0, 5) == "P5500");
            lmin.Visible = tt;
            lxxx.Visible = tt;
            cbXXX.Visible = tt;
                  }
        }


		private void cbPxx_SelectedIndexChanged(object sender, System.EventArgs e)
		{

           selCHRGR();
         //   selCHRGR_OLD();
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
			tCellN.Text ="";Uchng.Text ="N"; 
			cbVdc_SelectedValueChanged(sender,e);  
		}

		private void oldVdc_Click(object sender, System.EventArgs e)
		{
		
		}

	

		private void btnOK_Click(object sender, System.EventArgs e)
		{
		//	if (lALRM.Text =="Y")
		//	{
			    
				lSave.Text ="Y"; 
				this.Hide();
		//	}
		//	else MessageBox.Show("This Charger is NOT VALIDATED , You must choose defaults alarms ......(click on ALARMS link) !!!"); 
			
			   
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
		   e.Handled =Tools.OnlyInt(e.KeyChar );
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
		   pick_option('C'); 
		} 
		private void pick_option(char c)
		{
            string stt="";
			if (c=='D')	for (int r=lvDefOption.SelectedItems.Count-1;r>-1 ;r--) lvDefOption.SelectedItems[r].Remove();    
			else
			{
				if (lvDefOption.SelectedItems[0].SubItems[10].Text!="" && lvDefOption.SelectedItems[0].SubItems[1].Text!="Charger") 
				{
					Options   frmOpt = new Options(c,lvDefOption.SelectedItems[0].SubItems[10].Text);
					this.Hide();
					frmOpt.ShowDialog();
					this.Visible =true;
					if (frmOpt.lConsopt.Text =="Y")
					{
						if (MainMDI.Lang ==1 &&  frmOpt.tCat4fr.Text != MainMDI.VIDE ) 
						{
							stt=frmOpt.tCat4fr.Text ;
							stt+= (frmOpt.tCat5fr.Text != MainMDI.VIDE && frmOpt.chk5.Checked   ) ? frmOpt.tCat5fr.Text  : "";
							stt+= (frmOpt.tCat6fr.Text != MainMDI.VIDE && frmOpt.chk6.Checked   ) ? frmOpt.tCat6fr.Text  : "";
						}
						else
						{
							stt=frmOpt.tCat4.Text ;
							stt+= (frmOpt.tCat5.Text != MainMDI.VIDE && frmOpt.chk5.Checked   ) ? frmOpt.tCat5.Text  : "";
							stt+= (frmOpt.tCat6.Text != MainMDI.VIDE && frmOpt.chk6.Checked   ) ? frmOpt.tCat6.Text  : "";
						}
						lvDefOption.SelectedItems[0].SubItems[2].Text=stt;
						//			lvDefOption.SelectedItems[0].SubItems[2].Text=(MainMDI.Lang ==0) ?  frmOpt.tCat4.Text  + ", " + frmOpt.tCat5.Text  + ", " + frmOpt.tCat6.Text  : frmOpt.tCat4fr.Text  + ", " + frmOpt.tCat5fr.Text  + ", " + frmOpt.tCat6fr.Text  ; 
						lvDefOption.SelectedItems[0].SubItems[3].Text= frmOpt.tOptqty.Text   ; 
						lvDefOption.SelectedItems[0].SubItems[4].Text= frmOpt.tUPrice.Text   ; 
						lvDefOption.SelectedItems[0].SubItems[5].Text= Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(lvDefOption.SelectedItems[0].SubItems[3].Text),Charger.NB_DEC_AFF)) ; 
						lvDefOption.SelectedItems[0].SubItems[6].Text=frmOpt.tDlvDelay.Text ;
						for(int j=7;j< lvDefOption.SelectedItems[0].SubItems.Count-1;j++)
						{
							if (j!= 10 ) lvDefOption.SelectedItems[0].SubItems[j].Text ="";
					
						}
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
			string stSql	= "DELETE * FROM U_CCPROFILES WHERE (((U_CCPROFILES.USR)='" + In_User + "'))";
 			ExecSql(stSql); 
			stSql	= "INSERT INTO U_CCPROFILES ([USR],[CellNB],[vpcF],[vpcEQ],[PXXX],[phs],[vdc],[idc],[xxx],[VAC]) " +
				" VALUES ('" + In_User    + "', " + tCellN.Text   + ", " + tvpcF.Text + ", '" + 
				tvpcEq.Text   + "', '" + cbPxx.Text + "', '" + cbPhs.Text   + "', '" +cbVdc.Text   + "', '" + cbIdc.Text   + "', '" + cbXXX.Text   + "', '" + tVac.Text  +"')" ;
			ExecSql(stSql); 
		}

		private void btnLprofile_Click(object sender, System.EventArgs e)
		{
		
             load_Prof(); 
		}
		private void load_OTI_LIST()
		{
			string stSql = "SELECT * FROM PSM_LIST_OTIS "  ;
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ())
			{ 
 
				ListViewItem Lv=lvOTI.Items.Add(Oreadr["Otis_Desc"].ToString());
				Lv.SubItems.Add( Oreadr["Otis_LID"].ToString());
				Lv.SubItems.Add( Oreadr["Otis_Px_Ref"].ToString());
				Lv.SubItems.Add( Oreadr["Otis_C_name"].ToString());
				Lv.SubItems.Add(Oreadr["Otis_Link1"].ToString());
				Lv.SubItems.Add(Oreadr["Otis_Link2"].ToString());
				Lv.SubItems.Add(Oreadr["Otis_Link3"].ToString());
				Lv.SubItems.Add(Oreadr["Otis_Link4"].ToString());
			 
			}
		}
		private void load_Prof()
		{
			string stSql = "SELECT * FROM U_CCPROFILES where USR='" + In_User + "'"  ;
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ())
			{  
				
				Uchng.Text ="Y";
		//		tvpcF.Text =Oreadr["vpcF"].ToString();
		//		tvpcEq.Text =Oreadr["vpcEQ"].ToString();
		//		tVac.Text =Oreadr["VAC"].ToString();
				cbPxx.Text =  Oreadr["PXXX"].ToString() ;
				cbPhs.Text =  Oreadr["PHS"].ToString() ;
				cbVdc.Text =  Oreadr["vdc"].ToString() ;
				cbIdc.Text =  Oreadr["idc"].ToString() ;
				cbXXX.Text =  Oreadr["XXX"].ToString() ;
				tCellN.Text=Oreadr["CellNB"].ToString() ;
				stSql="";
				 
			}
			if (stSql !="") 
			{
				cbPxx.Text = "P4500" ;
				cbPhs.Text = "1" ;
				cbVdc.Text =  "125" ;
				cbIdc.Text =  "125" ;
			}
			Maj_VDCMax();

		}
		private void ExecSql( string stSql)
		{
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon   );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			Ocmd.ExecuteNonQuery()  ;
			OConn.Close();
		}

		private void lvDefOption_DoubleClick(object sender, System.EventArgs e)
		{
			//if ( lvDefOption.SelectedItems[0].SubItems[1].Text=="Charger" ) lvDefOption.SelectedItems[0].Checked =true;
	        lvDefOption.SelectedItems[0].BackColor=Color.BlueViolet   ;  
			lselI = lvDefOption.SelectedItems[0].Index ;
			lvDefOption.SelectedItems[0].Checked =true;
			tRef.Text = lvDefOption.SelectedItems[0].SubItems[1].Text ;
			tdesc.Text = lvDefOption.SelectedItems[0].SubItems[2].Text ;
			tqty.Text = lvDefOption.SelectedItems[0].SubItems[3].Text ;
			tUprice.Text = lvDefOption.SelectedItems[0].SubItems[4].Text ;
			tExt.Text = lvDefOption.SelectedItems[0].SubItems[5].Text ; 
            tLT.Text = lvDefOption.SelectedItems[0].SubItems[6].Text ;
            grp1.Height =120;
		}

		private void menuItem2_Click_1(object sender, System.EventArgs e)
		{
		   //pick_option('N'); 
		}

		private void opt60_CheckedChanged(object sender, System.EventArgs e)
		{
			lhrtz.Text ="60";
		}

		private void opt50_CheckedChanged(object sender, System.EventArgs e)
		{
			lhrtz.Text ="50";
		}

		private void opt400_CheckedChanged(object sender, System.EventArgs e)
		{
			lhrtz.Text ="400";
		}

		private void Chargerdlg_Resize(object sender, System.EventArgs e)
		{
			lvDefOption.Height = this.Height - 248;
			lvDefOption.Columns[2].Width = this.Width - 670;

			btnCancel.Left = grp1.Width - 104;
			btnOK.Left = grp1.Width - 224;
		//	btnCancel.Top = this.Height - 64;
		//	btnOK.Top  = this.Height - 64;
		//	btnCancel.Left = this.Width  - 96;
		//	btnOK.Left  = this.Width  - 184;
			
		}
		private bool valSTD_changed()
		{
			return (lstdCellN.Text != tCellN.Text || lstdVAC.Text != tVac.Text || lstdvdcMin.Text != tvdcMin.Text  || lstdvdcMax.Text != tVdcMax.Text ) ;
			//	          MessageBox.Show("Please Check the calculated components PRICES, since standard values were changed !!!");
		}

		private void tVEQL_TextChanged(object sender, System.EventArgs e)
		{
            maj_tvpcEq();
		}

		private void button3_Click_1(object sender, System.EventArgs e)
		{
		
		}

		private void dlg_Arr_frml_Disp()
		{
			string stout="";
			for (int i=0;i<Charger.NB_FRML;i++)
			{
				if (dlg_arr_CAL_FRML[i]=="") break;
				else stout += dlg_arr_CAL_FRML[i] + "\n";
			}
			MessageBox.Show(stout); 
		}
		private bool dlg_Arr_frml_Exist(string C_name)
		{
			string stout="";
			for (int i=0;i<Charger.NB_FRML;i++)
			{
				if (dlg_arr_CAL_FRML[i]=="") return false;
				else return (dlg_arr_CAL_FRML[i].IndexOf(C_name+"||")>-1);   
			}
			return false;
		}


		private  string fill_TV_LIST()
		{
			
			string stSql = "select * from PSM_LIST_TV where disp='1' and (phs='2' OR phs='" + cbPhs.Text + "') order by TVLID";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ; 
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			string stRes="";
			string st="";
			while (Oreadr.Read ()) 
			{ 
				string C_NAME=Oreadr["C_Name"].ToString().Substring(2,Oreadr["C_Name"].ToString().Length-2 );
				if (dlg_Arr_frml_Exist(C_NAME)) 
				{
					if (Oreadr["TV_typ"].ToString()=="C")  
					{
						st= cal_CPT(-1,C_NAME);
						stRes += (st==MainMDI.VIDE ) ? "" : " " + Oreadr["C_Name"].ToString() +"||" + st; 
					}
					else 
					{
						st = cal_VCS(Oreadr["C_Name"].ToString());
						stRes += (st==MainMDI.VIDE ) ? "" : " " + Oreadr["C_Name"].ToString() +"||" + st; 
					}
				}
			}
			return stRes ;
		}


		private void fill_OTV()  
		{
            
			lOth_TV = "C_CLN||" + tCellN.Text ;   //cell#
			if (optVrla.Checked ) lOth_TV += " C_TBT||V" ;  //Batteries  Vrla,Nicd,Leadacid
			else if (optNi.Checked ) lOth_TV += " C_TBT||N" ; 
			     else if (optLA.Checked ) lOth_TV += " C_TBT||L" ; 
			lOth_TV += " C_VF||" + ((optFx.Checked) ? "F" : "V")  ;  //charger Fx / Var
           	lOth_TV += " C_FC||" + tvpcF.Text ;                      // Float coef     
			lOth_TV += " C_EC||" + tvpcEq.Text ;    // Eqlz coef  
            if (ldesign.Text != "")
            {
                lOth_TV += " C_DEZ||" + ldesign.Text; // design  
                lOth_TV += " C_DEZ_MDL||" +lChrgREF.Text +lsep.Text + ldesign.Text;
            }
         	lOth_TV += " " + fill_TV_LIST();   //Save ALL TVs described in PSM_LIST_TV
           
			
			
			
			//	lOth_TV += " C_VSECLN||" + lVSECLN.Text ; 
		//	lOth_TV += " C_VSECLL||" + lVSECLL.Text ; 
		//	lOth_TV += " C_W2||"   ; 
         //   MessageBox.Show(Math.Sqrt(3)).ToString ());  

		}

		private void validate_CHRG()
		{
			lOth_TV ="";
            txcbPxx.Text = cbPxx.Text.Replace("4600", "4500");
			for (int i=0;i<Charger.NB_FRML;i++) dlg_arr_CAL_FRML[i]= ""; 
			Validate_Charger();

			//	dlg_Arr_frml_Disp();
			if (valSTD_changed())    MessageBox.Show("Check PRICES on RED lines , since standard values were changed  !!!");
			fill_OTV();   
		}
		private void LnkValidate_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
               validate_CHRG();
		}
		private void Validate_Charger()
		{
			string msg1="",msg="";
			bool chng=true;
			oldVdc.Text = cbVdc.Text ;  
			string v="";
			double MN_EQFLT=Math.Min(Tools.Conv_Dbl(tVEQL.Text ), Tools.Conv_Dbl(tVFLOAT.Text  ));
			char c=Valid_Charger();
			if (c=='L' || c=='H') 
			{   
				msg1= (c=='L') ? "You may choose a Lower Charger Model....!!!!" : "You may choose a Higher Charger Model....!!!!";
				DialogResult dr=MessageBox.Show(msg1,"Bad Charger Model",MessageBoxButtons.YesNo,MessageBoxIcon.Question );    ; 
				if (dr == DialogResult.Yes )
				{ 
					long AVID=Cal_Valid_Charger(c,Tools.Conv_Dbl(tVdcMax.Text) ,MN_EQFLT,ref v,cbIdc.Text   );
					if (v!="") 
					{
						string VX=MainMDI.Std_VCS(cbPhs.Text ,  AVID,"C_VDCMAX"); 
					
						string VN=MainMDI.Std_VCS(cbPhs.Text ,  AVID,"C_VDCMIN");  
						if (c=='L' && Tools.Conv_Dbl(tVdcMax.Text) > Tools.Conv_Dbl(VX)) 
						{
							chng=false; 
							msg=" Can not Move to Low " + v +"V !!! its VDCMAX is Low...." + "\n" +" The actual Model seems be ideal even its VdcMin is too Low..."; 
						}
						if (c=='H' && MN_EQFLT < Tools.Conv_Dbl(VN)) msg="Min(EQL,FLT) is too Low..."; 
						if (chng) cbVdc.Text =v;
						if (msg!="") MessageBox.Show (msg );
					}
					else MessageBox.Show ("Please Consult Engineering.... !!!");
				}

			}
	//		if (tVdcMax.Text !=lstdvdcMax.Text   || tVac.Text != lstdVAC.Text )  //seekPrice in XLfiles generated by Pricing
	//			fill_Def_options(tVdcMax.Text ,tVac.Text   );
	//		else   fill_Def_options();

            //added: 26112014  req. by Byad
            if (Tools.Conv_Dbl(cbVdc.Text) > 250) MessageBox.Show("All alarms will be disabled \n Please check if DC/DC converter is needed for this application ", "WARNING",MessageBoxButtons.OK ,MessageBoxIcon.Stop   ); 

        
		fill_Def_options(tVdcMax.Text ,tVac.Text   );  // Recalculate all CPT 

			btnCancel.Enabled =lvDefOption.Items.Count >0; 
			btnOK.Enabled =btnCancel.Enabled; 
			lnkAlarm.Enabled =true;
			pictureBox2.Enabled =true;
	        
			
		}

		private void lnkAlarm_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
		   Add_ALARMS ();
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
			validate_CHRG();
		}

		private void pictureBox2_Click(object sender, System.EventArgs e)
		{
			 Add_ALARMS ();
			
		}
		private void rm_curr_ALRMs()
		{
			for (int r=lvDefOption.Items.Count-1;r>-1 ;r--)
				if (lvDefOption.Items[r].SubItems[10].Text.IndexOf("ALEQ_") !=-1) lvDefOption.Items[r].Remove() ;
		}
		
		/*
		private void Add_AlarmsOLD()
		{
			
			Alarms ALRM = new Alarms(this);
			ALRM.ShowDialog();
			if (ALRM.lSave.Text  =="Y") 
			{   
				rm_curr_ALRMs();
				for (int i=0;i<ALRM.lvAlrmPL.Items.Count ;i++)
				{
					if (ALRM.lvAlrmPL.Items[i].Checked )
					{
						ListViewItem lvI = lvDefOption.Items.Add("");
						lvI.SubItems.Add("");
						lvI.SubItems.Add(ALRM.lvAlrmPL.Items[i].SubItems[1].Text);
						lvI.Checked =true; 
					//	lvI.SubItems.Add("");
					//	lvI.SubItems.Add(""); 
						if (ALRM.lvAlrmPL.Items[i].SubItems[2].Text=="0" || ALRM.lvAlrmPL.Items[i].SubItems[2].Text=="") 
						{
							lvI.SubItems.Add(""); 
							lvI.SubItems.Add("");
							lvI.SubItems.Add(""); 
						}
						else 
						{
							lvI.SubItems.Add("1"); 
							lvI.SubItems.Add(ALRM.lvAlrmPL.Items[i].SubItems[2].Text);
							lvI.SubItems.Add(ALRM.lvAlrmPL.Items[i].SubItems[2].Text);  //lvI.SubItems.Add( "$ " + Cpt.G_PRICE.ToString()); 
						}
						lvI.SubItems.Add("" ); 
						lvI.SubItems.Add(""); 
						lvI.SubItems.Add(ALRM.lvAlrmPL.Items[i].SubItems[9].Text); 
						lvI.SubItems.Add("" ); 
						lvI.SubItems.Add("ALRM"); 
						lvI.SubItems.Add("" ); 
						
						//	  lvI.SubItems.Add(""); 
					}
	
				}

				}
		}
		*/

		private void btnOKchng_Click(object sender, System.EventArgs e)
		{
			if (lselI!=-1)
			{
				lvDefOption.Items[lselI].SubItems[1].Text = tRef.Text  ;
				lvDefOption.Items[lselI].SubItems[2].Text= tdesc.Text ;
				lvDefOption.Items[lselI].SubItems[3].Text =tqty.Text  ;
				lvDefOption.Items[lselI].SubItems[4].Text =tUprice.Text ;
				lvDefOption.Items[lselI].SubItems[5].Text=tExt.Text  ; 
				lvDefOption.Items[lselI].SubItems[6].Text=tLT.Text  ;
				grp1.Height=56; 
				lvDefOption.Items[lselI].BackColor=Color.WhiteSmoke   ;  
			}
		}

		private void ChngCancel_Click(object sender, System.EventArgs e)
		{
			lvDefOption.Items[lselI].BackColor=Color.WhiteSmoke   ;  
			grp1.Height=56; 

		}

		private void tqty_TextChanged(object sender, System.EventArgs e)
		{
			cal_SellExt();
		
		}
	

		private void cal_SellExt()
		{
		//	if (tXchng.Text =="") tXchng.Text = tXRATE.Text ;
			if (tUprice.Text != "" && tqty.Text != "" )  tExt.Text = Convert.ToString(Math.Round (Tools.Conv_Dbl(tUprice.Text ) *  Tools.Conv_Dbl(tqty.Text ) ,MainMDI.NB_DEC_AFF ));  
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
			int mLT=(minLT.Text=="") ? 0: Convert.ToInt32(minLT.Text);
			int xLT=(MaxLT.Text=="") ? 0: Convert.ToInt32(MaxLT.Text);
			if ( mLT< xLT) tLTime.Text = MainMDI.A00(mLT,2) +"-" + MainMDI.A00(xLT,2);  
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

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			string lFrml="";
			for (int y=0;y<Charger.NB_FRML ;y++)
			{
				if (dlg_arr_CAL_FRML[y]!="" ) 
					lFrml+= " " +dlg_arr_CAL_FRML[y] ;  
				else break;
			}
			Alarms_EQ_Oth  AlrmEQ = new Alarms_EQ_Oth(lFrml,true ,'N');
			AlrmEQ.ShowDialog();
			if (AlrmEQ.lSave.Text  =="Y") 
			{   
				rm_curr_ALRMs();
				for (int i=0;i<AlrmEQ.lvAlrmPL.Items.Count ;i++)
				{
					if (AlrmEQ.lvAlrmPL.Items[i].Checked )
					{
						ListViewItem lvI = lvDefOption.Items.Add("");
						lvI.SubItems.Add("");
						lvI.SubItems.Add(AlrmEQ.lvAlrmPL.Items[i].SubItems[1].Text);
						lvI.Checked =true; 
						//	lvI.SubItems.Add("");
						//	lvI.SubItems.Add(""); 
						if (AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text=="0" || AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text=="") 
						{
							lvI.SubItems.Add(""); 
							lvI.SubItems.Add("");
							lvI.SubItems.Add(""); 
						}
						else 
						{
							lvI.SubItems.Add("1"); 
							lvI.SubItems.Add(AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text);
							lvI.SubItems.Add(AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text);  //lvI.SubItems.Add( "$ " + Cpt.G_PRICE.ToString()); 
						}
						lvI.SubItems.Add("" ); 
						lvI.SubItems.Add(""); 
						lvI.SubItems.Add("");  //    lvI.SubItems.Add(AlrmEQ.lvAlrmPL.Items[i].SubItems[9].Text); 
						lvI.SubItems.Add("" ); 
						lvI.SubItems.Add("ALRM"); 
						lvI.SubItems.Add(AlrmEQ.lvAlrmPL.Items[i].SubItems[3].Text ); 
						
						//	  lvI.SubItems.Add(""); 
					}
	
				}

			}
			AlrmEQ.Close();
			AlrmEQ.Dispose(); 
		}
		void Add_ALARMS()
		{
			string lFrml="";
			int AlrmNB=0;
			for (int y=0;y<Charger.NB_FRML ;y++)
			{
				if (dlg_arr_CAL_FRML[y]!="" ) 
					lFrml+= " " +dlg_arr_CAL_FRML[y] ;  
				else break;
			}
			Alarms_EQ_Oth  AlrmEQ = new Alarms_EQ_Oth(lFrml,true,'N' );
			AlrmEQ.ShowDialog();
			if (AlrmEQ.lSave.Text  =="Y") 
			{   
				lALRM.Text ="Y";
				rm_curr_ALRMs();
				for (int i=0;i<AlrmEQ.lvAlrmPL.Items.Count ;i++)
				{
					if (AlrmEQ.lvAlrmPL.Items[i].Checked )
					{
						ListViewItem lvI = lvDefOption.Items.Add("");
						lvI.SubItems.Add("");
						lvI.SubItems.Add(AlrmEQ.lvAlrmPL.Items[i].SubItems[1].Text);
						lvI.Checked =true; 
						//	lvI.SubItems.Add("");
						//	lvI.SubItems.Add(""); 
						if (AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text=="0" || AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text=="") 
						{
							lvI.SubItems.Add(""); 
							lvI.SubItems.Add("");
							lvI.SubItems.Add(""); 
						}
						else 
						{
							lvI.SubItems.Add("1"); 
							lvI.SubItems.Add(AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text);
							lvI.SubItems.Add(AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text);  //lvI.SubItems.Add( "$ " + Cpt.G_PRICE.ToString()); 
						}
						lvI.SubItems.Add("" ); 
						lvI.SubItems.Add(""); 
						lvI.SubItems.Add("");  //    lvI.SubItems.Add(AlrmEQ.lvAlrmPL.Items[i].SubItems[9].Text); 
						lvI.SubItems.Add("" ); 
				//		lvI.SubItems.Add("ALRM"+Convert.ToInt32(AlrmNB++)); 
						lvI.SubItems.Add("ALEQ_"+Convert.ToInt32(AlrmNB++)+"~~"+AlrmEQ.lvAlrmPL.Items[i].SubItems[10].Text); 
						lvI.SubItems.Add(AlrmEQ.lvAlrmPL.Items[i].SubItems[3].Text ); 
						
						//	  lvI.SubItems.Add(""); 
					}
	
				}

			}
			AlrmEQ.Close();
			AlrmEQ.Dispose(); 
		}

		private void label3_Click(object sender, System.EventArgs e)
		{
		//	label3.BorderStyle= BorderStyle.Fixed3D ;   
		//	cbIdc.Visible =false;
		//	label3.BorderStyle= BorderStyle.FixedSingle ; 
		}

		private void cbIdctmp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			EquiV_IDC(cbIdctmp.Text );
		}

		private void optVrla_CheckedChanged(object sender, System.EventArgs e)
		{
			Maj_VPC('V');
			Maj_NBCELL(); 
		}

		private void lChrgREF_DoubleClick(object sender, System.EventArgs e)
		{
			groupBox10.Visible = !groupBox10.Visible;
			grp1.Height =(grp1.Height==48) ? 192 : 48;
		}

		private void button3_Click_2(object sender, System.EventArgs e)
		{
			

		//	label29.Text = Convert.ToString(Math.Round(0.25  + Convert.ToDouble(tdbl.Text),2)) + " || " +  Convert.ToString(Math.Round( Convert.ToDouble(tdbl.Text)-0.25,2));
		//	label30.Text = Math.Ceiling(0.25  + Convert.ToDouble(tdbl.Text)).ToString() + " || " +  Math.Ceiling( -0.25 + Convert.ToDouble(tdbl.Text)).ToString(); 
		 //   label29.Text=MainMDI.Ceil(tdbl.Text,tSig.Text ).ToString() ;
		}

	

		private void value_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tdbl_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			if (lcptID.Text !=MainMDI.VIDE ) lresCpt.Text =  cal_CPT(Convert.ToInt32(lcptID.Text)  ,"xx");
			else MessageBox.Show("CPT is Invalid......"); 
		}

		private void cbCPTs_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		    lcptID.Text = MainMDI.Find_One_Field("select Component_ID from COMPNT_LIST where COMPONENT_REF='" + cbCPTs.Text +"'");  
		}

		private void lChrgREF_Click(object sender, System.EventArgs e)
		{
		
		}
		private string cal_VCS(string NME)
		{
			CHRGR  = new Charger(-1 ,lFV.Text , txcbPxx.Text ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text,tVac.Text ,tVdcMax.Text  );
			Cpt=new Component();
			return  Cpt.Cal_VCS(0,NME  ).ToString ();
			
		}
		private string cal_CPT(long lcptID,string cptName )
		{
			string st="";
			if (lcptID==-1) 
			{
				st= MainMDI.Find_One_Field("select Component_ID from COMPNT_LIST where COMPONENT_REF='" + cptName  +"'"); 
				lcptID =  (st!=MainMDI.VIDE ) ? Convert.ToInt32(st) : -1;
			}
			if (lcptID !=-1) 
			{
				CHRGR  =new Charger(-1 ,lFV.Text , txcbPxx.Text ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text,tVac.Text ,tVdcMax.Text  );
				Cpt=new Component();
				Cpt.CPT_COST(lcptID);  
				st=(Cpt.G_Desc.IndexOf("~~") <1) ? MainMDI.VIDE : Cpt.G_Desc.Substring(0,Cpt.G_Desc.IndexOf("~~"));  
				return  st ; //+ " || " + Cpt.CAP2 + " || " + Cpt.CAP3 + " || " + Cpt.CAP4 + " || " + Cpt.CAP5 + " || " + Cpt.CAP6 + " || " + Cpt.CAP7 + " || " + Cpt.G_Desc  + " || " + Cpt.G_PRICE  ;
			}
			return MainMDI.VIDE ;
		
		
		}

        private void tPxxQty_TextChanged(object sender, EventArgs e)
        {

        }

        private void tRPL_TextChanged(object sender, EventArgs e)
        {

        }

        private void tRPL_DoubleClick(object sender, EventArgs e)
        {
            tRPL.ReadOnly = false;
            tRPL.BackColor = Color.Yellow ;
        }

        private void Enbl_fltCF(bool stat)
        {
            tVFLOAT.ReadOnly = stat;
            tVFLOAT.BackColor = (tVFLOAT.ReadOnly) ? MainMDI.Clr_Readonly : MainMDI.Clr_ReadonlyNO;
            tvpcF.ReadOnly = !stat;
            tvpcF.BackColor = (tvpcF.ReadOnly) ? MainMDI.Clr_Readonly : MainMDI.Clr_ReadonlyNO;
        }
        private void Enbl_eqlCF(bool stat)
        {
            tVEQL.ReadOnly = stat;
            tVEQL.BackColor = (tVFLOAT.ReadOnly) ? MainMDI.Clr_Readonly : MainMDI.Clr_ReadonlyNO;
            tvpcEq.ReadOnly = !stat;
            tvpcEq.BackColor = (tvpcF.ReadOnly) ? MainMDI.Clr_Readonly : MainMDI.Clr_ReadonlyNO;
        }
        private void tVFLOAT_DoubleClick(object sender, EventArgs e)
        {
            Enbl_fltCF(false);
        }

        private void tVEQL_DoubleClick(object sender, EventArgs e)
        {
            Enbl_eqlCF(false);
        }

        private void tVFLOAT_TextChanged(object sender, EventArgs e)
        {
            maj_tvpcF();
        }

        private void tvpcF_DoubleClick(object sender, EventArgs e)
        {
            Enbl_fltCF(true);
        }

        private void tvpcEq_DoubleClick(object sender, EventArgs e)
        {
            Enbl_eqlCF(true);
        }

 


        private void btn_inducta_Click(object sender, EventArgs e)
        {
               string Ind_C  = MainMDI.VIDE  ;
                string Inductance  = MainMDI.VIDE;
                string Ind_Qty   = MainMDI.VIDE;
                string Capa  = MainMDI.VIDE;
                string Capa_Qty   = MainMDI.VIDE;
                string Resist_Qty = MainMDI.VIDE;
                string Capa_V = MainMDI.VIDE;
                string Resist_ohm  = MainMDI.VIDE;
                string pwrW = MainMDI.VIDE;
          string filtr=(txcbPxx.Text.Length <=5) ? "nf" : txcbPxx.Text.Substring(5,txcbPxx.Text.Length - 5) ;
   
            Component Cpt = new Component();
            Cpt.Cal_Induc(filtr, cbPhs.Text, cbVdc.Text, cbIdc.Text, ref Ind_C, ref Inductance, ref Ind_Qty, ref Capa, ref Capa_V, ref Capa_Qty, ref Resist_ohm, ref pwrW, ref Resist_Qty);
            btn_inducta.Text = "INDc=" + Ind_C + " IND=" +Inductance +" INDqty=" + Ind_Qty + " Capa=" + Capa + "  CapaV=" + Capa_V + " CapaQty=" +Capa_Qty + " RsistOHM=" + Resist_ohm + " pwrW=" +pwrW + " RsistQty=" +Resist_Qty;

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (MainMDI.User == "ede") Send_TBLTOXL13_TO_SYSPRO(); 
        }


        private void NSRT_REC_TBLTOXL13_SYSPRO(string stkcode,string prc)
        {

            string stSql = "INSERT INTO TBLTOXL13_SYSPRO ([StkCode],[Pricing]) " +
				" VALUES ('" + stkcode  + "', " + prc + ")";
			MainMDI.Exec_SQL_JFS(stSql,"TBLTOXL13 SYSPRO");


        }

        private string find_CHARGER_COST_syspro(string PXX, string PHS, string VDC, string IDC)
        {

            string res = Charger.VIDE;

            string stSql = " SELECT [" + IDC + "] FROM TBLTOXL0" + PHS + " WHERE (TBLTOXL0" + PHS + ".COMPONENT='" + PXX + "_LIST') AND (TBLTOXL0" + PHS + ".REF_CHRG='" + PXX + "_LIST-" + VDC + "' OR TBLTOXL0" + PHS + ".REF_CHRG='" + "P4500" + "-" + PHS + "-" + VDC + "')";

            return res = MainMDI.Find_One_Field(stSql);


        }

        private void Send_TBLTOXL13_TO_SYSPRO()
        {
            int NB = 0;
            for (int p = 1; p < 4; p += 2)
            {
                for (int v=0;v<cbVdc.Items.Count ;v++  )
                {

                   for (int i=0;i<cbIdc.Items.Count ;i++  )
                   {
                    
                     string PXXXX="P4500";
                     string Cost=  find_CHARGER_COST_syspro (PXXXX , p.ToString(), cbVdc.Items[v].ToString(), cbIdc.Items[i].ToString());
                     if (Cost == MainMDI.VIDE || Cost == "c/f") Cost = "0";
                     NSRT_REC_TBLTOXL13_SYSPRO(PXXXX + "-" + p.ToString() + "-" + cbVdc.Items[v].ToString() + "-" + cbIdc.Items[i].ToString(),Cost );


                     PXXXX = "P4500T";
                     Cost = find_CHARGER_COST_syspro(PXXXX, p.ToString(), cbVdc.Items[v].ToString(), cbIdc.Items[i].ToString());
                     if (Cost == MainMDI.VIDE || Cost == "c/f") Cost = "0";
                     NSRT_REC_TBLTOXL13_SYSPRO(PXXXX + "-" + p.ToString() + "-" + cbVdc.Items[v].ToString() + "-" + cbIdc.Items[i].ToString(), Cost);


                     PXXXX = "P4500TT";
                     Cost = find_CHARGER_COST_syspro(PXXXX, p.ToString(), cbVdc.Items[v].ToString(), cbIdc.Items[i].ToString());
                     if (Cost == MainMDI.VIDE || Cost == "c/f") Cost = "0";
                     NSRT_REC_TBLTOXL13_SYSPRO(PXXXX + "-" + p.ToString() + "-" + cbVdc.Items[v].ToString() + "-" + cbIdc.Items[i].ToString(), Cost);


                     PXXXX = "P4500F";
                     Cost = find_CHARGER_COST_syspro(PXXXX, p.ToString(), cbVdc.Items[v].ToString(), cbIdc.Items[i].ToString());
                     if (Cost == MainMDI.VIDE || Cost == "c/f") Cost = "0";
                     NSRT_REC_TBLTOXL13_SYSPRO(PXXXX + "-" + p.ToString() + "-" + cbVdc.Items[v].ToString() + "-" + cbIdc.Items[i].ToString(), Cost);

                     NB++;
                     ttttt1.Text = NB.ToString();
                     tPhs.Text = p.ToString(); tV.Text = cbVdc.Items[v].ToString(); tI.Text = cbIdc.Items[i].ToString();
                     this.Refresh();

                   }



                }


            }



        }

        private void cbDesign_SelectedIndexChangedOOOOOOOOOOOOLD(object sender, EventArgs e)
        {

            if (cbDesign.Text == "---")
            {
                ldesign.Text = "";
                lsep.Text = "";

            }
            else
            {
                ldesign.Text = cbDesign.Text[0].ToString();
                lsep.Text = "-";
            }
            buil_chrg_Ref();
        }

     //   void cleanCB(ComboBox myCB,string itm)

        void ini_cb(int no)
        {
            switch (no)
            {
                case 1:
                    cbDesign.Text = cbDesign.Items[0].ToString();
                    ldesign.Text = "";
                    lsep.Text = "";
                    break;
                case 2:
                    cbDesign2.Text = cbDesign2.Items[0].ToString();
                    ldesign2.Text = "";
                    lsep2.Text = "";
                    break;
                case 3:
                    cbDesign3.Text = cbDesign3.Items[0].ToString();
                    ldesign3.Text = "";
                    lsep3.Text = "";
                    break;
            }
        }


        void fill_cb(ComboBox myCB)
        {
            myCB.Items.Clear();  
            myCB.Items.AddRange(new object[] {
            "---",
            "U",
            "S",
            "M"});
        }
             

        private void cbDesign_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cbDesign.Text == "---") 
            {
                ldesign.Text = "";
                lsep.Text = "";

            }
            else
            {
                ldesign.Text = cbDesign.Text;
                lsep.Text = "-";

                fill_cb(cbDesign2); cbDesign2.Items.RemoveAt(cbDesign.SelectedIndex);
                fill_cb(cbDesign3); cbDesign3.Items.RemoveAt(cbDesign.SelectedIndex);

                cbDesign2.Text = cbDesign2.Items[0].ToString();
                cbDesign3.Text = cbDesign3.Items[0].ToString();
              
            }
           buil_chrg_Ref();
        }

        private void cbDesign2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDesign2.Text == "---")
            {
                ldesign2.Text = "";
                lsep2.Text = "";

            }
            else
            {
                ldesign2.Text = cbDesign2.Text;
                lsep2.Text = "-";

                cbDesign3.Items.Clear();
                for (int i = 0; i < cbDesign2.Items.Count; i++) cbDesign3.Items.Add(cbDesign2.Items[i]);    
  
                cbDesign3.Items.RemoveAt(cbDesign2.SelectedIndex);

                cbDesign3.Text = cbDesign3.Items[0].ToString();

            }
            buil_chrg_Ref();
        }

        private void cbDesign3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbDesign3.Text == "---")
            {
                ldesign3.Text = "";
                lsep3.Text = "";

            }
            else
            {
                ldesign3.Text = cbDesign3.Text;
                lsep3.Text = "-";
     
            }
            buil_chrg_Ref();
        }

        private void tvdcMin_TextChanged_1(object sender, EventArgs e)
        {

        }


























    }
}
