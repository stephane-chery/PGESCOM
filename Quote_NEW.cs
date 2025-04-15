using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Drawing.Printing;
using System.Data.OleDb;
using System.Data.SqlClient;
using EAHLibs;
using System.Text.RegularExpressions;	

namespace PGESCOM
{
	/// <summary>
	/// Summary description for Quote.
	/// </summary>
	public class Quote_NEW : System.Windows.Forms.Form
	{
        private static Lib1 Tools = new Lib1();
		public bool BCONV = false;
		private bool Imprt = false;
		private char in_opera = '*';
		private int ItemCount = 0;
        private string OldLabel = "", Curr_SQLMLTP = " CAN_MLTP ", STDMultp_US = "", STDMultp_CAN = "", STDMultp_EURO = "";
		private int OptionCount = 0; //, als_NDX = 0;
		private bool Quote_loaded = false;
		private bool Tosave = false;
		private bool Opt_added = false;
		private bool Chkable = true;
		private bool btnUnchk = false;
		private string curR_sol = "";
		private bool isDellAll = false;
        public long x_QID = -1;
		public string x_CpnyName = "*";
		public char x_opera = '*';
		private int LstNdx = -1;
		private int ndxfound = 0;
		private int ndxSelect = -1;
		private string Imp_SolID = "";
		private string Imp_IQID = "";
		private string Imp_cpnyID = "";
		//private string[,] arr_clpB = new string[MainMDI.MAX_Quote_lines, 13]; //12 subitem + 1 for Techvalue
		private string[] arr_Tech_values = new string[MainMDI.MAX_Quote_lines];
        string[] arr_Sql = new string[2000];

        //private int[] arr_nbDef[100, 2];
			 
	    //private string[,] curr_ALS = new string[MainMDI.MAX_ALS_Lines, MainMDI.MAX_ALS_COLs];
	    //private Lib1 Tools = new Lib1();
       	private string[,] A_CHRG = new string[30, 10];
        private const int lim0 = 4, lim1 = 9, lim2 = 19;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.ContextMenu SolCMnu;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage TGen;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.GroupBox groupBox8;
		public System.Windows.Forms.ComboBox cbIncoTerm;
		private System.Windows.Forms.Label label25;
		public System.Windows.Forms.ComboBox cbCurr;
		private System.Windows.Forms.Label label30;
		public System.Windows.Forms.ComboBox cbShipVia;
		private System.Windows.Forms.Label label26;
		public System.Windows.Forms.ComboBox cbTerms;
		private System.Windows.Forms.Label label31;
		public System.Windows.Forms.Label lIA;
		public System.Windows.Forms.Label lQA;
		public System.Windows.Forms.Label lSA;
		public System.Windows.Forms.Label lPA;
		private System.Windows.Forms.Button btnAI;
		private System.Windows.Forms.Button btnAQ;
		private System.Windows.Forms.Button btnAP;
		private System.Windows.Forms.Button btnAS;
		private System.Windows.Forms.Label label32;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lcpnyID;
		public System.Windows.Forms.Label lFax;
		public System.Windows.Forms.Label lPhone;
		public System.Windows.Forms.Label lAdrs;
		private System.Windows.Forms.Label label41;
		private System.Windows.Forms.Label label36;
		private System.Windows.Forms.Label label39;
		private System.Windows.Forms.Label label38;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.ComboBox cbCompany;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.GroupBox gbxSol;
		private System.Windows.Forms.TreeView tvSol;
		private System.Windows.Forms.TextBox AffQNB;
		public System.Windows.Forms.TextBox tQuoteID;
		private System.Windows.Forms.GroupBox gbxTabs;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.ToolBarButton AddSol;
		private System.Windows.Forms.ToolBarButton AddSpec;
		private System.Windows.Forms.ToolBarButton AddAls;
		public System.Windows.Forms.ComboBox cbContacts;
		private System.Windows.Forms.ToolBar toolBar1;
		public System.Windows.Forms.ComboBox cbLang;
		public System.Windows.Forms.ComboBox cbEmploy;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.ComboBox cbAP;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.ComboBox cbAI;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label24;
		private System.Windows.Forms.Label lOpera;
		private System.Windows.Forms.Label lSolCount;
		private System.Windows.Forms.ToolBarButton AddChrg;
		private System.Windows.Forms.ToolBarButton AddCab;
		private System.Windows.Forms.ToolBarButton AddRack;
		private System.Windows.Forms.ToolBarButton AddOption;
		private System.Windows.Forms.ToolBarButton SaveAls;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox4;
		private System.Windows.Forms.PictureBox pictureBox5;
		private System.Windows.Forms.TextBox tRAP;
		private System.Windows.Forms.TextBox tRAE;
		private System.Windows.Forms.TextBox tRAI;
		private System.Windows.Forms.TextBox tRAD;
		private System.Windows.Forms.ComboBox cbAE;
		public System.Windows.Forms.TextBox tProjNAME;
		private System.Windows.Forms.Label lEmp_ID;
		private System.Windows.Forms.Label lContact_ID;
		private System.Windows.Forms.Label lLang;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label lCurr;
		private System.Windows.Forms.Label lTerm_ID;
		private System.Windows.Forms.Label lVia_ID;
		private System.Windows.Forms.Label lIncoT_ID;
		public System.Windows.Forms.DateTimePicker tOpendate;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.ComboBox cbAS;
		private System.Windows.Forms.Label lAP;
		private System.Windows.Forms.Label lAE;
		private System.Windows.Forms.Label lAI;
		private System.Windows.Forms.Label lAD;
		private System.Windows.Forms.Label lAS;
		private System.Windows.Forms.GroupBox g5;
		private System.Windows.Forms.Label lTVSel;
		private System.Windows.Forms.Label lCurSPCn;
		private System.Windows.Forms.Label lCurrNAME;
		private System.Windows.Forms.ToolBarButton delALS;
		private System.Windows.Forms.ToolBarButton DelQ;
		private System.Windows.Forms.ToolBarButton SaveQ;
		private System.Windows.Forms.ToolBarButton delSelected;
		private System.Windows.Forms.Label lQNB;
		private System.Windows.Forms.Label lCurrPATH;
		private System.Windows.Forms.Label lCurSPCNDX;
		private System.Windows.Forms.Label lCurALSNDX;
		private System.Windows.Forms.Label lQsave;
		private System.Windows.Forms.Label lALSSave;
		private System.Windows.Forms.Label lCurr_opera;
		private System.Windows.Forms.ComboBox cbCQA;
		private System.Windows.Forms.ComboBox cbCPA;
		private System.Windows.Forms.ComboBox cbCSA;
		private System.Windows.Forms.Label label27;
		private System.Windows.Forms.TextBox tGCmnt;
		private System.Windows.Forms.Button btnNewID;
		private System.Windows.Forms.PictureBox gifCounter;
		private System.Windows.Forms.MenuItem mnuSPare;
		private System.Windows.Forms.MenuItem mnuRepair;
		private System.Windows.Forms.ContextMenu RevMnu;
		private System.Windows.Forms.ToolBarButton duplicaa;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label lSS;
		private System.Windows.Forms.Label lSP;
		private System.Windows.Forms.Label lSE;
		private System.Windows.Forms.Label lSO;
		private System.Windows.Forms.Label lSi;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.ComboBox cbSS;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.PictureBox pictureBox6;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.TextBox tRSP;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.TextBox tRSE;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.TextBox tRSO;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.TextBox tRSI;
		private System.Windows.Forms.ComboBox cbSp;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.ComboBox cbSe;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.ComboBox cbSo;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.ComboBox cbSi;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label lcurrImg;
		private System.Windows.Forms.Timer tmrChng;
		private System.Windows.Forms.ComboBox cbCIA;
		private System.Windows.Forms.ToolBarButton pbs;
		private System.Windows.Forms.ContextMenu CabMnu;
		private System.Windows.Forms.ToolBarButton addbat;
		private System.Windows.Forms.ContextMenu BatMnu;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.ContextMenu RackMnu;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem7;
		public System.Windows.Forms.ListView lvQITEMS;
		private System.Windows.Forms.ColumnHeader order;
		private System.Windows.Forms.ColumnHeader lineNB;
		private System.Windows.Forms.ColumnHeader DESC;
		private System.Windows.Forms.ColumnHeader Qty;
		private System.Windows.Forms.ColumnHeader Multpl;
		private System.Windows.Forms.ColumnHeader Uprice;
		private System.Windows.Forms.ColumnHeader Ext;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.ToolBarButton NLIO;
		private System.Windows.Forms.ColumnHeader LTime;
		private System.Windows.Forms.ColumnHeader itmGrp;
		private System.Windows.Forms.Label label50;
		private System.Windows.Forms.TextBox tCust_Mult;
		private System.Windows.Forms.Label lMLTPLYwwww;
		private System.Windows.Forms.TextBox STDMultp;
		private System.Windows.Forms.Label loM;
		private System.Windows.Forms.Button btnM;
		private System.Windows.Forms.ColumnHeader nbdef;
		public System.Windows.Forms.Label lCpnyName;
		public System.Windows.Forms.Label lPrfx;
		public System.Windows.Forms.Label lSFX;
		public System.Windows.Forms.Label lEExt;
		public System.Windows.Forms.Label lConName;
		public System.Windows.Forms.Label lConExt;
		public System.Windows.Forms.Label lEmpSFX;
		public System.Windows.Forms.CheckBox chkPrintALL;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.ToolBarButton Exit;
		public System.Windows.Forms.Label lContacts;
		private System.Windows.Forms.ToolBarButton Print;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label lcurrALSLID;
		private System.Windows.Forms.Label OldAlsTot;
		private System.Windows.Forms.Label OldSpecTot;
		private System.Windows.Forms.TextBox tXRATE;
		private System.Windows.Forms.Label lAlterTOT;
		private System.Windows.Forms.TextBox AlterTOT;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.Label lQID;
		private System.Windows.Forms.GroupBox grpCmnt;
		private System.Windows.Forms.Button btnComnt;
		private System.Windows.Forms.TextBox tComnt;
		private System.Windows.Forms.LinkLabel lnkCmnt;
		private System.Windows.Forms.ListView lvComment;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.TextBox tDebQID;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.Button btn2;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button btnImpChrgPrices;
		private System.Windows.Forms.PictureBox picEng;
		private System.Windows.Forms.PictureBox picFr;
		private System.Windows.Forms.Label lHiDelv;
		public System.Windows.Forms.Label lQDopen;
		public System.Windows.Forms.Label Lang;
		private System.Windows.Forms.ComboBox cbADD;
		private System.Windows.Forms.ColumnHeader PartNB;
		private System.Windows.Forms.GroupBox grpOrder;
		public System.Windows.Forms.ListView lvOrder;
		private System.Windows.Forms.ColumnHeader orderline;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.Button btnsSaveOrd;
		private System.Windows.Forms.Label label47;
		private System.Windows.Forms.TextBox tXchng;
		private System.Windows.Forms.PictureBox pictureBox7;
		private System.Windows.Forms.Label label45;
		private System.Windows.Forms.Label label46;
		public System.Windows.Forms.ComboBox cbCPmgr;
		public System.Windows.Forms.ComboBox cbIPmgr;
		private System.Windows.Forms.Label lIpmgr;
		private System.Windows.Forms.Label lCpmgr;
		private System.Windows.Forms.ColumnHeader sol;
		private System.Windows.Forms.ColumnHeader spc;
		private System.Windows.Forms.ColumnHeader Als;
		private System.Windows.Forms.ColumnHeader Detail_LID;
		private System.Windows.Forms.ColumnHeader Det_LID;
		private System.Windows.Forms.ColumnHeader lvndx;
		private System.Windows.Forms.Button btnDel;
		private System.Windows.Forms.ColumnHeader AA;
		private System.Windows.Forms.ColumnHeader Extt;
		private System.Windows.Forms.TabPage Revisions;
		private System.Windows.Forms.Label label49;
		private System.Windows.Forms.Label lRimgNdx;
		private System.Windows.Forms.Label lRSoln;
		private System.Windows.Forms.Label lLocTot;
		private System.Windows.Forms.TextBox LocTot;
		private System.Windows.Forms.Label lAgTot;
		private System.Windows.Forms.TextBox AgTot;
		private System.Windows.Forms.ToolBarButton Cancel;
		private System.Windows.Forms.PictureBox pictureBox8;
		private System.Windows.Forms.Label lQstatus;
		private System.Windows.Forms.Button btnApply;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.Label lcurDol;
		private System.Windows.Forms.RadioButton opEuro;
		private System.Windows.Forms.RadioButton opUS;
		private System.Windows.Forms.RadioButton opCan;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label53;
		private System.Windows.Forms.Label label54;
		private System.Windows.Forms.Label label55;
		private System.Windows.Forms.Label label56;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.Button button7;
		public System.Windows.Forms.TextBox tKey;
		private System.Windows.Forms.PictureBox picSeek;
		private System.Windows.Forms.ToolBarButton import;
		private System.Windows.Forms.PictureBox printLabel;
		private System.Windows.Forms.PrintDialog printDialog1;
		private System.Drawing.Printing.PrintDocument printDocument1;
		public System.Windows.Forms.Label lcbCPmgr;
		private System.Windows.Forms.Button btnchngCN;
		private System.Windows.Forms.Button btnchngCP;
		private System.Windows.Forms.Button btnCHNGCmpny;
		public System.Windows.Forms.Label lSave;
		private System.Windows.Forms.ComboBox cbprinters;
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.ContextMenu CMlvQitem;
		private System.Windows.Forms.MenuItem MNoCut;
		private System.Windows.Forms.MenuItem MNoPaste;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem mnOcopy;
		public System.Windows.Forms.Label lCurALSn;
		public System.Windows.Forms.Label lemail;
		private System.Windows.Forms.ContextMenu CHRECmnu;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem12;
		public System.Windows.Forms.Label lConTel;
		public System.Windows.Forms.Label lConFax;
		private System.Windows.Forms.Button btnIn;
		public System.Windows.Forms.Label lCurSoln;
		private System.Windows.Forms.Label lCurSolNDX;
		private System.Windows.Forms.Label lcurSol_Status;
		private System.Windows.Forms.TextBox tALSnb;
		private System.Windows.Forms.Label label59;
		private System.Windows.Forms.Label label60;
		private System.Windows.Forms.PictureBox printALS;
		private System.Windows.Forms.PictureBox picExit;
		private System.Windows.Forms.ColumnHeader TecVal;
		private System.Windows.Forms.PictureBox pictureBox9;
		private System.Windows.Forms.ToolBarButton AddALRM;
		public System.Windows.Forms.Label lOFName;
		public System.Windows.Forms.GroupBox grpPBs;
		public System.Windows.Forms.Panel grpPB;
		public System.Windows.Forms.Button button6;
		public System.Windows.Forms.Button button5;
		public System.Windows.Forms.Label lblWait;
		public System.Windows.Forms.ProgressBar pbPrintQt;
		public System.Windows.Forms.Label lCurrIQID;
		private System.Windows.Forms.Label lCancel;
		private System.Windows.Forms.GroupBox grpChng1;
		private System.Windows.Forms.Panel grpChng;
		private System.Windows.Forms.Label label58;
		private System.Windows.Forms.CheckBox chkTBP;
		private System.Windows.Forms.Label lnb;
		private System.Windows.Forms.TextBox tNB;
		private System.Windows.Forms.Label label44;
		private System.Windows.Forms.TextBox tdesc;
		private System.Windows.Forms.Label label28;
		private System.Windows.Forms.TextBox tqty;
		private System.Windows.Forms.Label label43;
		private System.Windows.Forms.Label label48;
		private System.Windows.Forms.TextBox tExt;
		private System.Windows.Forms.Label label42;
		private System.Windows.Forms.TextBox tUprice;
		private System.Windows.Forms.Label label29;
		private System.Windows.Forms.TextBox tmult;
		private System.Windows.Forms.Label label51;
		private System.Windows.Forms.TextBox MaxLT;
		private System.Windows.Forms.TextBox minLT;
		private System.Windows.Forms.Button ChngCancel;
		private System.Windows.Forms.Button btnOKchng;
		private System.Windows.Forms.Label tLT;
		private System.Windows.Forms.Label label61;
		private System.Windows.Forms.TextBox TOALS;
		private System.Windows.Forms.Label lALSmAmnt;
		private System.Windows.Forms.TextBox tTV;
		private System.Windows.Forms.Label label62;
		private System.Windows.Forms.Label label63;
		public System.Windows.Forms.TextBox tAGprice;
		public System.Windows.Forms.TextBox tPxPrice;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.CheckBox chkApply;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.MenuItem mnuModif;
		private System.Windows.Forms.Label label66;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label69;
		private System.Windows.Forms.Label label70;
		private System.Windows.Forms.Label label73;
		private System.Windows.Forms.TextBox tAMaxLT;
		private System.Windows.Forms.TextBox tAminLT;
		private System.Windows.Forms.Button btnAcancel;
		private System.Windows.Forms.Button btnAsave;
		private System.Windows.Forms.TextBox tAup;
		private System.Windows.Forms.TextBox tAmult;
		private System.Windows.Forms.TextBox tAqty;
		private System.Windows.Forms.Panel grpAmodif;
		private System.Windows.Forms.Label lALT;
		private System.Windows.Forms.Button button9;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.TextBox AlsTOT_orig;
		private System.Windows.Forms.Label lAuP;
		public System.Windows.Forms.TextBox AlsTOT;
		private System.Windows.Forms.Label lALSTOT;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.ImageList Fst_IL32;
		private System.Windows.Forms.ImageList imageList16;
        private System.Windows.Forms.ImageList imageList1;
        private PictureBox pictureBox10;
        public PictureBox picbadRevSta;
        private Label lRevTOT;
        private Label label64;
        public PictureBox pictureBox11;
        private CheckBox chk_savOVRG;
        private Button btnSavMLTP;
        private Button btnChangMLTP;
        private PictureBox pictureBox12;
        private Label label65;
        public ComboBox CB_Group;
        private GroupBox groupBox10;
        private TextBox txcb_Territo;
        private Label label68;
        private Label label71;
        private Label label72;
        private Label label74;
        private Label label75;
        private Label label76;
        private Label label78;
        private Label label79;
        private Label label80;
        private Label label81;
        private ComboBox cb_Territo;
        private Label label85;
        private GroupBox groupBox11;
        public Label lActivty;
        private Label label82;
        private PictureBox pictureBox13;
        private MenuItem menuItem13;
        private MenuItem MNocopyTxt;
        public PictureBox picCIP;
        private Label label77;
        private TextBox tSaleExt;
        private TextBox tAGExt;
        private Label label83;
        private Label label84;
        private ColumnHeader S_Ext;
        private ColumnHeader A_Ext;
		//private System.Windows.Forms.Label lItemCount;
		private System.ComponentModel.IContainer components;

	    //public Quote()
	    //{
            //InitializeComponent();
	        //fill_cbCompany();
	        //fill_cbSal_AG("S");
	        //fill_cbSal_AG("A");
	        //
	        //fill_cb_Inco();
	        //fill_cb_Terms();
	        //fill_cb_Via();
	        //
	    //}

        public Quote_NEW(long x_QID, string x_CpnyName, char x_opera)
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();
			//tvSol.CheckBoxes = true;
            //MainMDI._connectionString = MainMDI._connectionString;
			in_opera = x_opera;
			lCurr_opera.Text = x_opera.ToString();
			fill_cbCompany();
			fill_cbSal_AG("S");
            fill_cbTerrito();
			fill_cbSal_AG("A");
			fill_cb_Inco();
			fill_cb_Terms();
			fill_cb_Via();
		   	CHSPrt();
			if (x_QID == 0)
			{
				//init_Curr_ALS();
				//if (fill_QID() == 0 || fill_QID() == -1) this.Close();
				//else lCurr_opera.Text = "N";
				btnNewID.Visible = true;
				cbCompany.Enabled = true;
				lCpnyName.Visible = false;
				tQuoteID.Focus();
			}
			else	
			{
				if (in_opera == 'C')
				{
					tvSol.CheckBoxes = true;
					groupBox8.Enabled = false;
					groupBox4.Enabled = false;
					groupBox3.Enabled = false;
					groupBox5.Visible = true;
					tALSnb.ReadOnly = true;
					tPxPrice.ReadOnly = true;
					tAGprice.ReadOnly = true;
					grpChng.Visible = false;
					lvQITEMS.Columns[0].Text = "Order";
					lvQITEMS.Columns[0].Width = 0; //0 = Hide Item check
					lvQITEMS.Columns[2].Width = lvQITEMS.Columns[2].Width - 39;
				
					for (int i = 0; i < toolBar1.Buttons.Count; i++) toolBar1.Buttons[i].Enabled = false;
					grpOrder.Visible = true;
				    //tabControl1.TabPages[1].Show();
				}
				btnNewID.Visible = false;
			    //tOpendate.Visible = false;
				cbCompany.Visible = false;
				lCpnyName.Visible = true;
 				tQuoteID.Text = x_QID.ToString();
				if (!fill_Qot(x_QID, x_CpnyName)) this.Hide();
				else lCurr_opera.Text = "E";
			}
			picSeek.Visible = (lCurr_opera.Text == "N");
			tKey.Visible = (lCurr_opera.Text == "N");
	        //toolBar1.Buttons[1].Visible = (lCurr_opera.Text == "N");
			btnIn.Visible = (lCurr_opera.Text == "N");
			if (lCurr_opera.Text == "N")
			{
				cbTerms.Text = "TBA";
				cbIncoTerm.Text = "EXW";
				cbShipVia.Text = MainMDI.VIDE;
			}
		    //lxtt.Visible = MainMDI.currDB == "XTT";
		    //if (MainMDI.User.ToLower() == "Admin") button2.Visible = true;
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if(disposing)
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quote_NEW));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.Cancel = new System.Windows.Forms.ToolBarButton();
            this.import = new System.Windows.Forms.ToolBarButton();
            this.DelQ = new System.Windows.Forms.ToolBarButton();
            this.SaveQ = new System.Windows.Forms.ToolBarButton();
            this.AddSol = new System.Windows.Forms.ToolBarButton();
            this.SolCMnu = new System.Windows.Forms.ContextMenu();
            this.mnuSPare = new System.Windows.Forms.MenuItem();
            this.mnuRepair = new System.Windows.Forms.MenuItem();
            this.AddSpec = new System.Windows.Forms.ToolBarButton();
            this.AddAls = new System.Windows.Forms.ToolBarButton();
            this.duplicaa = new System.Windows.Forms.ToolBarButton();
            this.delSelected = new System.Windows.Forms.ToolBarButton();
            this.AddChrg = new System.Windows.Forms.ToolBarButton();
            this.CHRECmnu = new System.Windows.Forms.ContextMenu();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem12 = new System.Windows.Forms.MenuItem();
            this.menuItem13 = new System.Windows.Forms.MenuItem();
            this.addbat = new System.Windows.Forms.ToolBarButton();
            this.BatMnu = new System.Windows.Forms.ContextMenu();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.AddCab = new System.Windows.Forms.ToolBarButton();
            this.CabMnu = new System.Windows.Forms.ContextMenu();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.menuItem5 = new System.Windows.Forms.MenuItem();
            this.menuItem8 = new System.Windows.Forms.MenuItem();
            this.AddRack = new System.Windows.Forms.ToolBarButton();
            this.RackMnu = new System.Windows.Forms.ContextMenu();
            this.menuItem6 = new System.Windows.Forms.MenuItem();
            this.menuItem7 = new System.Windows.Forms.MenuItem();
            this.AddOption = new System.Windows.Forms.ToolBarButton();
            this.NLIO = new System.Windows.Forms.ToolBarButton();
            this.AddALRM = new System.Windows.Forms.ToolBarButton();
            this.SaveAls = new System.Windows.Forms.ToolBarButton();
            this.delALS = new System.Windows.Forms.ToolBarButton();
            this.pbs = new System.Windows.Forms.ToolBarButton();
            this.Print = new System.Windows.Forms.ToolBarButton();
            this.Exit = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.RevMnu = new System.Windows.Forms.ContextMenu();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem11 = new System.Windows.Forms.MenuItem();
            this.gbxTabs = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.TGen = new System.Windows.Forms.TabPage();
            this.linkLabel1 = new System.Windows.Forms.LinkLabel();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label68 = new System.Windows.Forms.Label();
            this.label71 = new System.Windows.Forms.Label();
            this.label72 = new System.Windows.Forms.Label();
            this.label74 = new System.Windows.Forms.Label();
            this.label75 = new System.Windows.Forms.Label();
            this.label76 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.label79 = new System.Windows.Forms.Label();
            this.label80 = new System.Windows.Forms.Label();
            this.label81 = new System.Windows.Forms.Label();
            this.label85 = new System.Windows.Forms.Label();
            this.txcb_Territo = new System.Windows.Forms.TextBox();
            this.cb_Territo = new System.Windows.Forms.ComboBox();
            this.button8 = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cbADD = new System.Windows.Forms.ComboBox();
            this.cbAS = new System.Windows.Forms.ComboBox();
            this.cbAP = new System.Windows.Forms.ComboBox();
            this.cbAE = new System.Windows.Forms.ComboBox();
            this.cbAI = new System.Windows.Forms.ComboBox();
            this.pictureBox13 = new System.Windows.Forms.PictureBox();
            this.lAS = new System.Windows.Forms.Label();
            this.lAP = new System.Windows.Forms.Label();
            this.lAE = new System.Windows.Forms.Label();
            this.lAI = new System.Windows.Forms.Label();
            this.lAD = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lOpera = new System.Windows.Forms.Label();
            this.lSolCount = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.tRAP = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tRAE = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.tRAI = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tRAD = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lSS = new System.Windows.Forms.Label();
            this.lSP = new System.Windows.Forms.Label();
            this.lSE = new System.Windows.Forms.Label();
            this.lSO = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.cbSS = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tRSP = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tRSE = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tRSO = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tRSI = new System.Windows.Forms.TextBox();
            this.cbSp = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cbSe = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cbSo = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.cbSi = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.lSi = new System.Windows.Forms.Label();
            this.tGCmnt = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.pictureBox9 = new System.Windows.Forms.PictureBox();
            this.lSave = new System.Windows.Forms.Label();
            this.lQstatus = new System.Windows.Forms.Label();
            this.pictureBox8 = new System.Windows.Forms.PictureBox();
            this.lLocTot = new System.Windows.Forms.Label();
            this.LocTot = new System.Windows.Forms.TextBox();
            this.lAgTot = new System.Windows.Forms.Label();
            this.AgTot = new System.Windows.Forms.TextBox();
            this.cbCIA = new System.Windows.Forms.ComboBox();
            this.cbCSA = new System.Windows.Forms.ComboBox();
            this.cbCPA = new System.Windows.Forms.ComboBox();
            this.cbCQA = new System.Windows.Forms.ComboBox();
            this.lIncoT_ID = new System.Windows.Forms.Label();
            this.lCurr = new System.Windows.Forms.Label();
            this.lVia_ID = new System.Windows.Forms.Label();
            this.lTerm_ID = new System.Windows.Forms.Label();
            this.cbIncoTerm = new System.Windows.Forms.ComboBox();
            this.label25 = new System.Windows.Forms.Label();
            this.cbCurr = new System.Windows.Forms.ComboBox();
            this.label30 = new System.Windows.Forms.Label();
            this.cbShipVia = new System.Windows.Forms.ComboBox();
            this.label26 = new System.Windows.Forms.Label();
            this.cbTerms = new System.Windows.Forms.ComboBox();
            this.label31 = new System.Windows.Forms.Label();
            this.lIA = new System.Windows.Forms.Label();
            this.lQA = new System.Windows.Forms.Label();
            this.lSA = new System.Windows.Forms.Label();
            this.lPA = new System.Windows.Forms.Label();
            this.btnAI = new System.Windows.Forms.Button();
            this.btnAQ = new System.Windows.Forms.Button();
            this.btnAP = new System.Windows.Forms.Button();
            this.btnAS = new System.Windows.Forms.Button();
            this.label32 = new System.Windows.Forms.Label();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.pictureBox12 = new System.Windows.Forms.PictureBox();
            this.lActivty = new System.Windows.Forms.Label();
            this.btnChangMLTP = new System.Windows.Forms.Button();
            this.label82 = new System.Windows.Forms.Label();
            this.btnSavMLTP = new System.Windows.Forms.Button();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.lSFX = new System.Windows.Forms.Label();
            this.lCurrIQID = new System.Windows.Forms.Label();
            this.lConFax = new System.Windows.Forms.Label();
            this.lemail = new System.Windows.Forms.Label();
            this.lConTel = new System.Windows.Forms.Label();
            this.lConExt = new System.Windows.Forms.Label();
            this.lConName = new System.Windows.Forms.Label();
            this.lPrfx = new System.Windows.Forms.Label();
            this.lCpmgr = new System.Windows.Forms.Label();
            this.lContact_ID = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.lEmpSFX = new System.Windows.Forms.Label();
            this.lLang = new System.Windows.Forms.Label();
            this.lEExt = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.label60 = new System.Windows.Forms.Label();
            this.btnIn = new System.Windows.Forms.Button();
            this.btnCHNGCmpny = new System.Windows.Forms.Button();
            this.btnchngCP = new System.Windows.Forms.Button();
            this.btnchngCN = new System.Windows.Forms.Button();
            this.printLabel = new System.Windows.Forms.PictureBox();
            this.picSeek = new System.Windows.Forms.PictureBox();
            this.tKey = new System.Windows.Forms.TextBox();
            this.label57 = new System.Windows.Forms.Label();
            this.label56 = new System.Windows.Forms.Label();
            this.loM = new System.Windows.Forms.Label();
            this.label55 = new System.Windows.Forms.Label();
            this.STDMultp = new System.Windows.Forms.TextBox();
            this.label54 = new System.Windows.Forms.Label();
            this.label50 = new System.Windows.Forms.Label();
            this.label53 = new System.Windows.Forms.Label();
            this.tCust_Mult = new System.Windows.Forms.TextBox();
            this.label52 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.opEuro = new System.Windows.Forms.RadioButton();
            this.opUS = new System.Windows.Forms.RadioButton();
            this.opCan = new System.Windows.Forms.RadioButton();
            this.lIpmgr = new System.Windows.Forms.Label();
            this.label46 = new System.Windows.Forms.Label();
            this.cbIPmgr = new System.Windows.Forms.ComboBox();
            this.label45 = new System.Windows.Forms.Label();
            this.lHiDelv = new System.Windows.Forms.Label();
            this.btnNewID = new System.Windows.Forms.Button();
            this.lEmp_ID = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.lcpnyID = new System.Windows.Forms.Label();
            this.lFax = new System.Windows.Forms.Label();
            this.lPhone = new System.Windows.Forms.Label();
            this.lAdrs = new System.Windows.Forms.Label();
            this.label41 = new System.Windows.Forms.Label();
            this.label36 = new System.Windows.Forms.Label();
            this.label39 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.cbEmploy = new System.Windows.Forms.ComboBox();
            this.label37 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tProjNAME = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.tQuoteID = new System.Windows.Forms.TextBox();
            this.gifCounter = new System.Windows.Forms.PictureBox();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.lCpnyName = new System.Windows.Forms.Label();
            this.cbLang = new System.Windows.Forms.ComboBox();
            this.Lang = new System.Windows.Forms.Label();
            this.lQDopen = new System.Windows.Forms.Label();
            this.tOpendate = new System.Windows.Forms.DateTimePicker();
            this.cbCPmgr = new System.Windows.Forms.ComboBox();
            this.lcbCPmgr = new System.Windows.Forms.Label();
            this.cbContacts = new System.Windows.Forms.ComboBox();
            this.lContacts = new System.Windows.Forms.Label();
            this.cbprinters = new System.Windows.Forms.ComboBox();
            this.Revisions = new System.Windows.Forms.TabPage();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lALSTOT = new System.Windows.Forms.Label();
            this.lAuP = new System.Windows.Forms.Label();
            this.chk_savOVRG = new System.Windows.Forms.CheckBox();
            this.label64 = new System.Windows.Forms.Label();
            this.lRevTOT = new System.Windows.Forms.Label();
            this.picbadRevSta = new System.Windows.Forms.PictureBox();
            this.pictureBox10 = new System.Windows.Forms.PictureBox();
            this.printALS = new System.Windows.Forms.PictureBox();
            this.AlterTOT = new System.Windows.Forms.TextBox();
            this.AlsTOT_orig = new System.Windows.Forms.TextBox();
            this.lAlterTOT = new System.Windows.Forms.Label();
            this.tAGprice = new System.Windows.Forms.TextBox();
            this.label63 = new System.Windows.Forms.Label();
            this.tPxPrice = new System.Windows.Forms.TextBox();
            this.label62 = new System.Windows.Forms.Label();
            this.AlsTOT = new System.Windows.Forms.TextBox();
            this.label59 = new System.Windows.Forms.Label();
            this.tALSnb = new System.Windows.Forms.TextBox();
            this.lcurrALSLID = new System.Windows.Forms.Label();
            this.OldAlsTot = new System.Windows.Forms.Label();
            this.gbxSol = new System.Windows.Forms.GroupBox();
            this.grpChng = new System.Windows.Forms.Panel();
            this.label84 = new System.Windows.Forms.Label();
            this.tAGExt = new System.Windows.Forms.TextBox();
            this.label83 = new System.Windows.Forms.Label();
            this.label77 = new System.Windows.Forms.Label();
            this.tSaleExt = new System.Windows.Forms.TextBox();
            this.CB_Group = new System.Windows.Forms.ComboBox();
            this.label65 = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.chkApply = new System.Windows.Forms.CheckBox();
            this.tTV = new System.Windows.Forms.TextBox();
            this.lALSmAmnt = new System.Windows.Forms.Label();
            this.label61 = new System.Windows.Forms.Label();
            this.TOALS = new System.Windows.Forms.TextBox();
            this.label51 = new System.Windows.Forms.Label();
            this.MaxLT = new System.Windows.Forms.TextBox();
            this.minLT = new System.Windows.Forms.TextBox();
            this.ChngCancel = new System.Windows.Forms.Button();
            this.btnOKchng = new System.Windows.Forms.Button();
            this.label43 = new System.Windows.Forms.Label();
            this.label48 = new System.Windows.Forms.Label();
            this.tExt = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.tUprice = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.tmult = new System.Windows.Forms.TextBox();
            this.label58 = new System.Windows.Forms.Label();
            this.chkTBP = new System.Windows.Forms.CheckBox();
            this.lnb = new System.Windows.Forms.Label();
            this.tNB = new System.Windows.Forms.TextBox();
            this.label44 = new System.Windows.Forms.Label();
            this.tdesc = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tqty = new System.Windows.Forms.TextBox();
            this.grpAmodif = new System.Windows.Forms.Panel();
            this.button9 = new System.Windows.Forms.Button();
            this.lALT = new System.Windows.Forms.Label();
            this.label66 = new System.Windows.Forms.Label();
            this.tAMaxLT = new System.Windows.Forms.TextBox();
            this.tAminLT = new System.Windows.Forms.TextBox();
            this.btnAcancel = new System.Windows.Forms.Button();
            this.btnAsave = new System.Windows.Forms.Button();
            this.label67 = new System.Windows.Forms.Label();
            this.label69 = new System.Windows.Forms.Label();
            this.tAup = new System.Windows.Forms.TextBox();
            this.label70 = new System.Windows.Forms.Label();
            this.tAmult = new System.Windows.Forms.TextBox();
            this.label73 = new System.Windows.Forms.Label();
            this.tAqty = new System.Windows.Forms.TextBox();
            this.grpPB = new System.Windows.Forms.Panel();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.lblWait = new System.Windows.Forms.Label();
            this.pbPrintQt = new System.Windows.Forms.ProgressBar();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.g5 = new System.Windows.Forms.GroupBox();
            this.lcurrImg = new System.Windows.Forms.Label();
            this.lCurr_opera = new System.Windows.Forms.Label();
            this.lALSSave = new System.Windows.Forms.Label();
            this.lQsave = new System.Windows.Forms.Label();
            this.lCurALSNDX = new System.Windows.Forms.Label();
            this.lCurSPCNDX = new System.Windows.Forms.Label();
            this.lCurrPATH = new System.Windows.Forms.Label();
            this.lMLTPLYwwww = new System.Windows.Forms.Label();
            this.lCurrNAME = new System.Windows.Forms.Label();
            this.lCurSPCn = new System.Windows.Forms.Label();
            this.lTVSel = new System.Windows.Forms.Label();
            this.grpOrder = new System.Windows.Forms.GroupBox();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.lRSoln = new System.Windows.Forms.Label();
            this.lRimgNdx = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnsSaveOrd = new System.Windows.Forms.Button();
            this.lvOrder = new System.Windows.Forms.ListView();
            this.orderline = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sol = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.spc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Als = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Detail_LID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvndx = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Extt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpPBs = new System.Windows.Forms.GroupBox();
            this.btnM = new System.Windows.Forms.Button();
            this.lvQITEMS = new System.Windows.Forms.ListView();
            this.order = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lineNB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DESC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Multpl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Uprice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itmGrp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ext = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nbdef = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PartNB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Det_LID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TecVal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.S_Ext = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.A_Ext = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CMlvQitem = new System.Windows.Forms.ContextMenu();
            this.MNoCut = new System.Windows.Forms.MenuItem();
            this.mnOcopy = new System.Windows.Forms.MenuItem();
            this.MNocopyTxt = new System.Windows.Forms.MenuItem();
            this.menuItem15 = new System.Windows.Forms.MenuItem();
            this.MNoPaste = new System.Windows.Forms.MenuItem();
            this.menuItem9 = new System.Windows.Forms.MenuItem();
            this.menuItem14 = new System.Windows.Forms.MenuItem();
            this.mnuModif = new System.Windows.Forms.MenuItem();
            this.tvSol = new System.Windows.Forms.TreeView();
            this.imageList16 = new System.Windows.Forms.ImageList(this.components);
            this.grpChng1 = new System.Windows.Forms.GroupBox();
            this.tLT = new System.Windows.Forms.Label();
            this.label49 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.tXchng = new System.Windows.Forms.TextBox();
            this.tXRATE = new System.Windows.Forms.TextBox();
            this.OldSpecTot = new System.Windows.Forms.Label();
            this.pictureBox7 = new System.Windows.Forms.PictureBox();
            this.AffQNB = new System.Windows.Forms.TextBox();
            this.lQNB = new System.Windows.Forms.Label();
            this.tmrChng = new System.Windows.Forms.Timer(this.components);
            this.chkPrintALL = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lQID = new System.Windows.Forms.Label();
            this.grpCmnt = new System.Windows.Forms.GroupBox();
            this.btnComnt = new System.Windows.Forms.Button();
            this.tComnt = new System.Windows.Forms.TextBox();
            this.lnkCmnt = new System.Windows.Forms.LinkLabel();
            this.lvComment = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tDebQID = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnImpChrgPrices = new System.Windows.Forms.Button();
            this.btnApply = new System.Windows.Forms.Button();
            this.lcurDol = new System.Windows.Forms.Label();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.lCurALSn = new System.Windows.Forms.Label();
            this.lCurSoln = new System.Windows.Forms.Label();
            this.lCurSolNDX = new System.Windows.Forms.Label();
            this.lcurSol_Status = new System.Windows.Forms.Label();
            this.lOFName = new System.Windows.Forms.Label();
            this.lCancel = new System.Windows.Forms.Label();
            this.Fst_IL32 = new System.Windows.Forms.ImageList(this.components);
            this.picExit = new System.Windows.Forms.PictureBox();
            this.picEng = new System.Windows.Forms.PictureBox();
            this.picFr = new System.Windows.Forms.PictureBox();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.gbxTabs.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.TGen.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.groupBox8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).BeginInit();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printLabel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gifCounter)).BeginInit();
            this.Revisions.SuspendLayout();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbadRevSta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.printALS)).BeginInit();
            this.gbxSol.SuspendLayout();
            this.grpChng.SuspendLayout();
            this.grpAmodif.SuspendLayout();
            this.grpPB.SuspendLayout();
            this.g5.SuspendLayout();
            this.grpOrder.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.grpChng1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.grpCmnt.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEng)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFr)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.Cancel,
            this.import,
            this.DelQ,
            this.SaveQ,
            this.AddSol,
            this.AddSpec,
            this.AddAls,
            this.duplicaa,
            this.delSelected,
            this.AddChrg,
            this.addbat,
            this.AddCab,
            this.AddRack,
            this.AddOption,
            this.NLIO,
            this.AddALRM,
            this.SaveAls,
            this.delALS,
            this.pbs,
            this.Print,
            this.Exit});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(990, 66);
            this.toolBar1.TabIndex = 30;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // Cancel
            // 
            this.Cancel.ImageIndex = 34;
            this.Cancel.Name = "Cancel";
            this.Cancel.Text = "(Un)Cancel ";
            // 
            // import
            // 
            this.import.ImageIndex = 40;
            this.import.Name = "import";
            this.import.Text = "Import Quote";
            this.import.ToolTipText = "Duplicate Quote To an other Company";
            // 
            // DelQ
            // 
            this.DelQ.Enabled = false;
            this.DelQ.ImageIndex = 13;
            this.DelQ.Name = "DelQ";
            this.DelQ.Text = "Delete";
            this.DelQ.ToolTipText = "Delete Quote";
            // 
            // SaveQ
            // 
            this.SaveQ.ImageIndex = 38;
            this.SaveQ.Name = "SaveQ";
            this.SaveQ.Text = "Save";
            this.SaveQ.ToolTipText = "Save Quote";
            // 
            // AddSol
            // 
            this.AddSol.DropDownMenu = this.SolCMnu;
            this.AddSol.ImageIndex = 15;
            this.AddSol.Name = "AddSol";
            this.AddSol.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.AddSol.Text = "New Revision";
            this.AddSol.ToolTipText = "Revision / Service / Spare Parts";
            this.AddSol.Visible = false;
            // 
            // SolCMnu
            // 
            this.SolCMnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.mnuSPare,
            this.mnuRepair});
            // 
            // mnuSPare
            // 
            this.mnuSPare.Index = 0;
            this.mnuSPare.Text = "Spare Parts (SP)";
            this.mnuSPare.Click += new System.EventHandler(this.mnuSPare_Click);
            // 
            // mnuRepair
            // 
            this.mnuRepair.Index = 1;
            this.mnuRepair.Text = "Service / Warranty (VS)";
            this.mnuRepair.Click += new System.EventHandler(this.mnuRepair_Click);
            // 
            // AddSpec
            // 
            this.AddSpec.Enabled = false;
            this.AddSpec.ImageIndex = 16;
            this.AddSpec.Name = "AddSpec";
            this.AddSpec.Text = "New Alternative";
            this.AddSpec.ToolTipText = "Add Alternative";
            this.AddSpec.Visible = false;
            // 
            // AddAls
            // 
            this.AddAls.ImageIndex = 17;
            this.AddAls.Name = "AddAls";
            this.AddAls.Text = "New System";
            this.AddAls.ToolTipText = "Add System";
            this.AddAls.Visible = false;
            // 
            // duplicaa
            // 
            this.duplicaa.ImageIndex = 22;
            this.duplicaa.Name = "duplicaa";
            this.duplicaa.Text = "Duplicate";
            this.duplicaa.ToolTipText = "Duplicate";
            this.duplicaa.Visible = false;
            // 
            // delSelected
            // 
            this.delSelected.ImageIndex = 13;
            this.delSelected.Name = "delSelected";
            this.delSelected.Text = "Delete";
            this.delSelected.ToolTipText = "Delete Current Selection";
            this.delSelected.Visible = false;
            // 
            // AddChrg
            // 
            this.AddChrg.DropDownMenu = this.CHRECmnu;
            this.AddChrg.ImageIndex = 1;
            this.AddChrg.Name = "AddChrg";
            this.AddChrg.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.AddChrg.Text = "Charger/Rectifier";
            this.AddChrg.ToolTipText = "Add Charger";
            this.AddChrg.Visible = false;
            // 
            // CHRECmnu
            // 
            this.CHRECmnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem10,
            this.menuItem12,
            this.menuItem13});
            this.CHRECmnu.Popup += new System.EventHandler(this.CHRECmnu_Popup);
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 0;
            this.menuItem10.Text = "P4500 Charger";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem12
            // 
            this.menuItem12.Index = 1;
            this.menuItem12.Text = "P5500 EDI (Rectifier)";
            this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
            // 
            // menuItem13
            // 
            this.menuItem13.Index = 2;
            this.menuItem13.Text = "P5500";
            this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
            // 
            // addbat
            // 
            this.addbat.DropDownMenu = this.BatMnu;
            this.addbat.ImageIndex = 23;
            this.addbat.Name = "addbat";
            this.addbat.Text = "PBS Battery";
            this.addbat.ToolTipText = "Add Pre-Sized Battery";
            this.addbat.Visible = false;
            // 
            // BatMnu
            // 
            this.BatMnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem1,
            this.menuItem2});
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 0;
            this.menuItem1.Text = "Standard";
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 1;
            this.menuItem2.Text = "SIZED Battery";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // AddCab
            // 
            this.AddCab.DropDownMenu = this.CabMnu;
            this.AddCab.ImageIndex = 2;
            this.AddCab.Name = "AddCab";
            this.AddCab.Text = "PBS Cabinet";
            this.AddCab.ToolTipText = "Add Pre-Sized Cabinet";
            this.AddCab.Visible = false;
            // 
            // CabMnu
            // 
            this.CabMnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem4,
            this.menuItem5,
            this.menuItem8});
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 0;
            this.menuItem4.Text = "Standard";
            // 
            // menuItem5
            // 
            this.menuItem5.Index = 1;
            this.menuItem5.Text = "Sized Cabinet";
            this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
            // 
            // menuItem8
            // 
            this.menuItem8.Index = 2;
            this.menuItem8.Text = "Cabinet Entry";
            this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
            // 
            // AddRack
            // 
            this.AddRack.DropDownMenu = this.RackMnu;
            this.AddRack.ImageIndex = 3;
            this.AddRack.Name = "AddRack";
            this.AddRack.Text = "PBS Rack";
            this.AddRack.ToolTipText = "Add Pre-Sized Rack";
            this.AddRack.Visible = false;
            // 
            // RackMnu
            // 
            this.RackMnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem6,
            this.menuItem7});
            // 
            // menuItem6
            // 
            this.menuItem6.Index = 0;
            this.menuItem6.Text = "Standard";
            // 
            // menuItem7
            // 
            this.menuItem7.Index = 1;
            this.menuItem7.Text = "SIZED Rack";
            this.menuItem7.Click += new System.EventHandler(this.menuItem7_Click);
            // 
            // AddOption
            // 
            this.AddOption.ImageIndex = 6;
            this.AddOption.Name = "AddOption";
            this.AddOption.Text = "Component";
            this.AddOption.ToolTipText = "add option";
            this.AddOption.Visible = false;
            // 
            // NLIO
            // 
            this.NLIO.ImageIndex = 26;
            this.NLIO.Name = "NLIO";
            this.NLIO.Text = "Buy/Resell";
            this.NLIO.ToolTipText = "BUY &&& RESELL";
            this.NLIO.Visible = false;
            // 
            // AddALRM
            // 
            this.AddALRM.ImageIndex = 33;
            this.AddALRM.Name = "AddALRM";
            this.AddALRM.Text = "Alarms";
            this.AddALRM.ToolTipText = "Equalize/Alarms";
            this.AddALRM.Visible = false;
            // 
            // SaveAls
            // 
            this.SaveAls.ImageIndex = 38;
            this.SaveAls.Name = "SaveAls";
            this.SaveAls.Text = "Save";
            this.SaveAls.ToolTipText = "Save Selected Alias";
            this.SaveAls.Visible = false;
            // 
            // delALS
            // 
            this.delALS.ImageIndex = 13;
            this.delALS.Name = "delALS";
            this.delALS.Text = "Delete";
            this.delALS.ToolTipText = "Delete Alias";
            this.delALS.Visible = false;
            // 
            // pbs
            // 
            this.pbs.ImageIndex = 12;
            this.pbs.Name = "pbs";
            this.pbs.Text = "PBS";
            this.pbs.ToolTipText = "Battery Sizing";
            this.pbs.Visible = false;
            // 
            // Print
            // 
            this.Print.ImageIndex = 30;
            this.Print.Name = "Print";
            this.Print.Text = "Word";
            this.Print.ToolTipText = "Export To Word";
            this.Print.Visible = false;
            // 
            // Exit
            // 
            this.Exit.ImageIndex = 29;
            this.Exit.Name = "Exit";
            this.Exit.Text = "EXIT";
            this.Exit.ToolTipText = "Exit";
            this.Exit.Visible = false;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            this.imageList1.Images.SetKeyName(1, "");
            this.imageList1.Images.SetKeyName(2, "");
            this.imageList1.Images.SetKeyName(3, "");
            this.imageList1.Images.SetKeyName(4, "");
            this.imageList1.Images.SetKeyName(5, "");
            this.imageList1.Images.SetKeyName(6, "");
            this.imageList1.Images.SetKeyName(7, "");
            this.imageList1.Images.SetKeyName(8, "");
            this.imageList1.Images.SetKeyName(9, "");
            this.imageList1.Images.SetKeyName(10, "");
            this.imageList1.Images.SetKeyName(11, "");
            this.imageList1.Images.SetKeyName(12, "");
            this.imageList1.Images.SetKeyName(13, "");
            this.imageList1.Images.SetKeyName(14, "");
            this.imageList1.Images.SetKeyName(15, "");
            this.imageList1.Images.SetKeyName(16, "");
            this.imageList1.Images.SetKeyName(17, "");
            this.imageList1.Images.SetKeyName(18, "");
            this.imageList1.Images.SetKeyName(19, "");
            this.imageList1.Images.SetKeyName(20, "");
            this.imageList1.Images.SetKeyName(21, "");
            this.imageList1.Images.SetKeyName(22, "");
            this.imageList1.Images.SetKeyName(23, "");
            this.imageList1.Images.SetKeyName(24, "");
            this.imageList1.Images.SetKeyName(25, "");
            this.imageList1.Images.SetKeyName(26, "");
            this.imageList1.Images.SetKeyName(27, "");
            this.imageList1.Images.SetKeyName(28, "");
            this.imageList1.Images.SetKeyName(29, "");
            this.imageList1.Images.SetKeyName(30, "");
            this.imageList1.Images.SetKeyName(31, "");
            this.imageList1.Images.SetKeyName(32, "");
            this.imageList1.Images.SetKeyName(33, "");
            this.imageList1.Images.SetKeyName(34, "");
            this.imageList1.Images.SetKeyName(35, "");
            this.imageList1.Images.SetKeyName(36, "");
            this.imageList1.Images.SetKeyName(37, "");
            this.imageList1.Images.SetKeyName(38, "");
            this.imageList1.Images.SetKeyName(39, "");
            this.imageList1.Images.SetKeyName(40, "");
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(440, 0);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 24);
            this.button2.TabIndex = 31;
            this.button2.Text = "WordFile";
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RevMnu
            // 
            this.RevMnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3,
            this.menuItem11});
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.Text = "Duplicate";
            // 
            // menuItem11
            // 
            this.menuItem11.Index = 1;
            this.menuItem11.Text = "Delete";
            // 
            // gbxTabs
            // 
            this.gbxTabs.Controls.Add(this.tabControl1);
            this.gbxTabs.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxTabs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxTabs.Location = new System.Drawing.Point(0, 66);
            this.gbxTabs.Name = "gbxTabs";
            this.gbxTabs.Size = new System.Drawing.Size(990, 550);
            this.gbxTabs.TabIndex = 40;
            this.gbxTabs.TabStop = false;
            this.gbxTabs.Enter += new System.EventHandler(this.gbxTabs_Enter);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.TGen);
            this.tabControl1.Controls.Add(this.Revisions);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(984, 528);
            this.tabControl1.TabIndex = 33;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // TGen
            // 
            this.TGen.BackColor = System.Drawing.SystemColors.Control;
            this.TGen.Controls.Add(this.linkLabel1);
            this.TGen.Controls.Add(this.groupBox3);
            this.TGen.Controls.Add(this.groupBox8);
            this.TGen.Controls.Add(this.groupBox4);
            this.TGen.Controls.Add(this.cbprinters);
            this.TGen.Location = new System.Drawing.Point(4, 22);
            this.TGen.Name = "TGen";
            this.TGen.Size = new System.Drawing.Size(976, 502);
            this.TGen.TabIndex = 0;
            this.TGen.Text = "Quote Info.";
            this.TGen.Click += new System.EventHandler(this.TGen_Click);
            // 
            // linkLabel1
            // 
            this.linkLabel1.Location = new System.Drawing.Point(7, 467);
            this.linkLabel1.Name = "linkLabel1";
            this.linkLabel1.Size = new System.Drawing.Size(275, 16);
            this.linkLabel1.TabIndex = 166;
            this.linkLabel1.TabStop = true;
            this.linkLabel1.Text = "linkLabel1";
            this.linkLabel1.Visible = false;
            this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox10);
            this.groupBox3.Controls.Add(this.button8);
            this.groupBox3.Controls.Add(this.groupBox2);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Controls.Add(this.label27);
            this.groupBox3.Controls.Add(this.lSi);
            this.groupBox3.Controls.Add(this.tGCmnt);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox3.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox3.Location = new System.Drawing.Point(0, 363);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(976, 146);
            this.groupBox3.TabIndex = 51;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Commissions";
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter_1);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label68);
            this.groupBox10.Controls.Add(this.label71);
            this.groupBox10.Controls.Add(this.label72);
            this.groupBox10.Controls.Add(this.label74);
            this.groupBox10.Controls.Add(this.label75);
            this.groupBox10.Controls.Add(this.label76);
            this.groupBox10.Controls.Add(this.label78);
            this.groupBox10.Controls.Add(this.label79);
            this.groupBox10.Controls.Add(this.label80);
            this.groupBox10.Controls.Add(this.label81);
            this.groupBox10.Controls.Add(this.label85);
            this.groupBox10.Controls.Add(this.txcb_Territo);
            this.groupBox10.Controls.Add(this.cb_Territo);
            this.groupBox10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox10.Location = new System.Drawing.Point(16, 19);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(229, 47);
            this.groupBox10.TabIndex = 163;
            this.groupBox10.TabStop = false;
            this.groupBox10.Text = "Sales ";
            // 
            // label68
            // 
            this.label68.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label68.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label68.Location = new System.Drawing.Point(312, 104);
            this.label68.Name = "label68";
            this.label68.Size = new System.Drawing.Size(16, 16);
            this.label68.TabIndex = 91;
            this.label68.Visible = false;
            // 
            // label71
            // 
            this.label71.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label71.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label71.Location = new System.Drawing.Point(312, 80);
            this.label71.Name = "label71";
            this.label71.Size = new System.Drawing.Size(16, 16);
            this.label71.TabIndex = 90;
            this.label71.Text = "0";
            this.label71.Visible = false;
            // 
            // label72
            // 
            this.label72.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label72.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label72.Location = new System.Drawing.Point(312, 56);
            this.label72.Name = "label72";
            this.label72.Size = new System.Drawing.Size(16, 16);
            this.label72.TabIndex = 89;
            this.label72.Text = "0";
            this.label72.Visible = false;
            // 
            // label74
            // 
            this.label74.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label74.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label74.Location = new System.Drawing.Point(312, 32);
            this.label74.Name = "label74";
            this.label74.Size = new System.Drawing.Size(16, 16);
            this.label74.TabIndex = 88;
            this.label74.Text = "0";
            this.label74.Visible = false;
            // 
            // label75
            // 
            this.label75.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label75.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label75.Location = new System.Drawing.Point(312, 8);
            this.label75.Name = "label75";
            this.label75.Size = new System.Drawing.Size(16, 16);
            this.label75.TabIndex = 87;
            this.label75.Text = "0";
            this.label75.Visible = false;
            // 
            // label76
            // 
            this.label76.BackColor = System.Drawing.Color.Transparent;
            this.label76.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label76.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label76.Location = new System.Drawing.Point(296, 104);
            this.label76.Name = "label76";
            this.label76.Size = new System.Drawing.Size(14, 16);
            this.label76.TabIndex = 86;
            this.label76.Text = "%";
            this.label76.Visible = false;
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.Color.Transparent;
            this.label78.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label78.Location = new System.Drawing.Point(296, 80);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(14, 16);
            this.label78.TabIndex = 78;
            this.label78.Text = "%";
            this.label78.Visible = false;
            // 
            // label79
            // 
            this.label79.BackColor = System.Drawing.Color.Transparent;
            this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label79.Location = new System.Drawing.Point(296, 56);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(14, 16);
            this.label79.TabIndex = 76;
            this.label79.Text = "%";
            this.label79.Visible = false;
            // 
            // label80
            // 
            this.label80.BackColor = System.Drawing.Color.Transparent;
            this.label80.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label80.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label80.Location = new System.Drawing.Point(296, 32);
            this.label80.Name = "label80";
            this.label80.Size = new System.Drawing.Size(14, 16);
            this.label80.TabIndex = 74;
            this.label80.Text = "%";
            this.label80.Visible = false;
            // 
            // label81
            // 
            this.label81.BackColor = System.Drawing.Color.Transparent;
            this.label81.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label81.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label81.Location = new System.Drawing.Point(296, 8);
            this.label81.Name = "label81";
            this.label81.Size = new System.Drawing.Size(14, 16);
            this.label81.TabIndex = 72;
            this.label81.Text = "%";
            this.label81.Visible = false;
            // 
            // label85
            // 
            this.label85.BackColor = System.Drawing.SystemColors.Control;
            this.label85.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label85.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label85.Location = new System.Drawing.Point(3, 18);
            this.label85.Name = "label85";
            this.label85.Size = new System.Drawing.Size(53, 16);
            this.label85.TabIndex = 62;
            this.label85.Text = "Territory:";
            this.label85.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txcb_Territo
            // 
            this.txcb_Territo.BackColor = System.Drawing.Color.AliceBlue;
            this.txcb_Territo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txcb_Territo.Location = new System.Drawing.Point(59, 16);
            this.txcb_Territo.MaxLength = 5;
            this.txcb_Territo.Name = "txcb_Territo";
            this.txcb_Territo.ReadOnly = true;
            this.txcb_Territo.Size = new System.Drawing.Size(163, 20);
            this.txcb_Territo.TabIndex = 92;
            this.txcb_Territo.Visible = false;
            this.txcb_Territo.TextChanged += new System.EventHandler(this.txcb_Territo_TextChanged);
            this.txcb_Territo.DoubleClick += new System.EventHandler(this.txcb_Territo_DoubleClick);
            // 
            // cb_Territo
            // 
            this.cb_Territo.BackColor = System.Drawing.Color.Lavender;
            this.cb_Territo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Territo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cb_Territo.Location = new System.Drawing.Point(59, 16);
            this.cb_Territo.Name = "cb_Territo";
            this.cb_Territo.Size = new System.Drawing.Size(163, 21);
            this.cb_Territo.TabIndex = 63;
            this.cb_Territo.SelectedIndexChanged += new System.EventHandler(this.cb_Territo_SelectedIndexChanged);
            // 
            // button8
            // 
            this.button8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button8.Location = new System.Drawing.Point(874, 3);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(96, 24);
            this.button8.TabIndex = 162;
            this.button8.Text = "REGEX";
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.cbADD);
            this.groupBox2.Controls.Add(this.cbAS);
            this.groupBox2.Controls.Add(this.cbAP);
            this.groupBox2.Controls.Add(this.cbAE);
            this.groupBox2.Controls.Add(this.cbAI);
            this.groupBox2.Controls.Add(this.pictureBox13);
            this.groupBox2.Controls.Add(this.lAS);
            this.groupBox2.Controls.Add(this.lAP);
            this.groupBox2.Controls.Add(this.lAE);
            this.groupBox2.Controls.Add(this.lAI);
            this.groupBox2.Controls.Add(this.lAD);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.textBox2);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.lOpera);
            this.groupBox2.Controls.Add(this.lSolCount);
            this.groupBox2.Controls.Add(this.label16);
            this.groupBox2.Controls.Add(this.tRAP);
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.tRAE);
            this.groupBox2.Controls.Add(this.label18);
            this.groupBox2.Controls.Add(this.tRAI);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.tRAD);
            this.groupBox2.Controls.Add(this.label21);
            this.groupBox2.Controls.Add(this.label22);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.label24);
            this.groupBox2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox2.Location = new System.Drawing.Point(257, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(386, 122);
            this.groupBox2.TabIndex = 62;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Agents";
            // 
            // cbADD
            // 
            this.cbADD.BackColor = System.Drawing.Color.Lavender;
            this.cbADD.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbADD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbADD.Location = new System.Drawing.Point(112, 8);
            this.cbADD.Name = "cbADD";
            this.cbADD.Size = new System.Drawing.Size(249, 21);
            this.cbADD.TabIndex = 96;
            this.cbADD.SelectedIndexChanged += new System.EventHandler(this.cbADD_SelectedIndexChanged);
            // 
            // cbAS
            // 
            this.cbAS.BackColor = System.Drawing.Color.Lavender;
            this.cbAS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbAS.Location = new System.Drawing.Point(112, 92);
            this.cbAS.Name = "cbAS";
            this.cbAS.Size = new System.Drawing.Size(249, 21);
            this.cbAS.TabIndex = 88;
            this.cbAS.Visible = false;
            // 
            // cbAP
            // 
            this.cbAP.BackColor = System.Drawing.Color.Lavender;
            this.cbAP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbAP.Location = new System.Drawing.Point(112, 71);
            this.cbAP.Name = "cbAP";
            this.cbAP.Size = new System.Drawing.Size(249, 21);
            this.cbAP.TabIndex = 68;
            this.cbAP.SelectedIndexChanged += new System.EventHandler(this.cbAP_SelectedIndexChanged);
            // 
            // cbAE
            // 
            this.cbAE.BackColor = System.Drawing.Color.Lavender;
            this.cbAE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbAE.Location = new System.Drawing.Point(112, 50);
            this.cbAE.Name = "cbAE";
            this.cbAE.Size = new System.Drawing.Size(249, 21);
            this.cbAE.TabIndex = 66;
            this.cbAE.SelectedIndexChanged += new System.EventHandler(this.cbAE_SelectedIndexChanged);
            // 
            // cbAI
            // 
            this.cbAI.BackColor = System.Drawing.Color.Lavender;
            this.cbAI.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbAI.Location = new System.Drawing.Point(112, 29);
            this.cbAI.Name = "cbAI";
            this.cbAI.Size = new System.Drawing.Size(249, 21);
            this.cbAI.TabIndex = 64;
            this.cbAI.SelectedIndexChanged += new System.EventHandler(this.cbAI_SelectedIndexChanged);
            // 
            // pictureBox13
            // 
            this.pictureBox13.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox13.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox13.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox13.Image")));
            this.pictureBox13.Location = new System.Drawing.Point(361, 6);
            this.pictureBox13.Name = "pictureBox13";
            this.pictureBox13.Size = new System.Drawing.Size(24, 24);
            this.pictureBox13.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox13.TabIndex = 164;
            this.pictureBox13.TabStop = false;
            this.pictureBox13.Click += new System.EventHandler(this.pictureBox13_Click);
            // 
            // lAS
            // 
            this.lAS.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lAS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lAS.Location = new System.Drawing.Point(336, 96);
            this.lAS.Name = "lAS";
            this.lAS.Size = new System.Drawing.Size(16, 16);
            this.lAS.TabIndex = 95;
            this.lAS.Visible = false;
            // 
            // lAP
            // 
            this.lAP.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lAP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lAP.Location = new System.Drawing.Point(336, 80);
            this.lAP.Name = "lAP";
            this.lAP.Size = new System.Drawing.Size(16, 16);
            this.lAP.TabIndex = 94;
            this.lAP.Text = "0";
            this.lAP.Visible = false;
            // 
            // lAE
            // 
            this.lAE.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lAE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lAE.Location = new System.Drawing.Point(336, 56);
            this.lAE.Name = "lAE";
            this.lAE.Size = new System.Drawing.Size(16, 16);
            this.lAE.TabIndex = 93;
            this.lAE.Text = "0";
            // 
            // lAI
            // 
            this.lAI.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lAI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lAI.Location = new System.Drawing.Point(336, 32);
            this.lAI.Name = "lAI";
            this.lAI.Size = new System.Drawing.Size(16, 16);
            this.lAI.TabIndex = 92;
            this.lAI.Text = "0";
            // 
            // lAD
            // 
            this.lAD.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lAD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lAD.Location = new System.Drawing.Point(336, 8);
            this.lAD.Name = "lAD";
            this.lAD.Size = new System.Drawing.Size(16, 16);
            this.lAD.TabIndex = 91;
            this.lAD.Text = "0";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(312, 104);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(14, 16);
            this.label10.TabIndex = 90;
            this.label10.Text = "%";
            this.label10.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Lavender;
            this.textBox2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox2.Location = new System.Drawing.Point(272, 96);
            this.textBox2.MaxLength = 5;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(40, 20);
            this.textBox2.TabIndex = 89;
            this.textBox2.Visible = false;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Transparent;
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(40, 92);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(72, 21);
            this.label20.TabIndex = 87;
            this.label20.Text = "Special:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label20.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 20);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 82;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // lOpera
            // 
            this.lOpera.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lOpera.Location = new System.Drawing.Point(8, 96);
            this.lOpera.Name = "lOpera";
            this.lOpera.Size = new System.Drawing.Size(16, 16);
            this.lOpera.TabIndex = 81;
            this.lOpera.Text = "N";
            this.lOpera.Visible = false;
            // 
            // lSolCount
            // 
            this.lSolCount.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lSolCount.Location = new System.Drawing.Point(8, 80);
            this.lSolCount.Name = "lSolCount";
            this.lSolCount.Size = new System.Drawing.Size(24, 16);
            this.lSolCount.TabIndex = 80;
            this.lSolCount.Text = "0";
            this.lSolCount.Visible = false;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(312, 80);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(14, 16);
            this.label16.TabIndex = 77;
            this.label16.Text = "%";
            this.label16.Visible = false;
            // 
            // tRAP
            // 
            this.tRAP.BackColor = System.Drawing.Color.Lavender;
            this.tRAP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tRAP.Location = new System.Drawing.Point(272, 71);
            this.tRAP.MaxLength = 5;
            this.tRAP.Name = "tRAP";
            this.tRAP.Size = new System.Drawing.Size(40, 20);
            this.tRAP.TabIndex = 76;
            this.tRAP.Visible = false;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(312, 56);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(16, 16);
            this.label17.TabIndex = 75;
            this.label17.Text = "%";
            this.label17.Visible = false;
            // 
            // tRAE
            // 
            this.tRAE.BackColor = System.Drawing.Color.Lavender;
            this.tRAE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tRAE.Location = new System.Drawing.Point(272, 50);
            this.tRAE.MaxLength = 5;
            this.tRAE.Name = "tRAE";
            this.tRAE.Size = new System.Drawing.Size(40, 20);
            this.tRAE.TabIndex = 74;
            this.tRAE.Visible = false;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Transparent;
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(312, 32);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(14, 16);
            this.label18.TabIndex = 73;
            this.label18.Text = "%";
            this.label18.Visible = false;
            // 
            // tRAI
            // 
            this.tRAI.BackColor = System.Drawing.Color.Lavender;
            this.tRAI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tRAI.Location = new System.Drawing.Point(272, 29);
            this.tRAI.MaxLength = 5;
            this.tRAI.Name = "tRAI";
            this.tRAI.Size = new System.Drawing.Size(40, 20);
            this.tRAI.TabIndex = 72;
            this.tRAI.Visible = false;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Transparent;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(312, 8);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(14, 16);
            this.label19.TabIndex = 71;
            this.label19.Text = "%";
            this.label19.Visible = false;
            // 
            // tRAD
            // 
            this.tRAD.BackColor = System.Drawing.Color.Lavender;
            this.tRAD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tRAD.Location = new System.Drawing.Point(272, 8);
            this.tRAD.MaxLength = 5;
            this.tRAD.Name = "tRAD";
            this.tRAD.Size = new System.Drawing.Size(40, 20);
            this.tRAD.TabIndex = 70;
            this.tRAD.Visible = false;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(40, 71);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(72, 21);
            this.label21.TabIndex = 67;
            this.label21.Text = "PO:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Transparent;
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(40, 50);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 21);
            this.label22.TabIndex = 65;
            this.label22.Text = "Engineering:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.Color.Transparent;
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(40, 29);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(72, 21);
            this.label23.TabIndex = 63;
            this.label23.Text = "Influence:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Transparent;
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(48, 8);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(64, 21);
            this.label24.TabIndex = 61;
            this.label24.Text = "Destination:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.lSS);
            this.groupBox1.Controls.Add(this.lSP);
            this.groupBox1.Controls.Add(this.lSE);
            this.groupBox1.Controls.Add(this.lSO);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.cbSS);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.pictureBox6);
            this.groupBox1.Controls.Add(this.label14);
            this.groupBox1.Controls.Add(this.tRSP);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.tRSE);
            this.groupBox1.Controls.Add(this.label13);
            this.groupBox1.Controls.Add(this.tRSO);
            this.groupBox1.Controls.Add(this.label12);
            this.groupBox1.Controls.Add(this.tRSI);
            this.groupBox1.Controls.Add(this.cbSp);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.cbSe);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.cbSo);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.cbSi);
            this.groupBox1.Controls.Add(this.label11);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox1.Location = new System.Drawing.Point(8, 108);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(153, 30);
            this.groupBox1.TabIndex = 66;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sales ";
            this.groupBox1.Visible = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(256, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 24);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 92;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // lSS
            // 
            this.lSS.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lSS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lSS.Location = new System.Drawing.Point(312, 104);
            this.lSS.Name = "lSS";
            this.lSS.Size = new System.Drawing.Size(16, 16);
            this.lSS.TabIndex = 91;
            this.lSS.Visible = false;
            // 
            // lSP
            // 
            this.lSP.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lSP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lSP.Location = new System.Drawing.Point(312, 80);
            this.lSP.Name = "lSP";
            this.lSP.Size = new System.Drawing.Size(16, 16);
            this.lSP.TabIndex = 90;
            this.lSP.Text = "0";
            this.lSP.Visible = false;
            // 
            // lSE
            // 
            this.lSE.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lSE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lSE.Location = new System.Drawing.Point(312, 56);
            this.lSE.Name = "lSE";
            this.lSE.Size = new System.Drawing.Size(16, 16);
            this.lSE.TabIndex = 89;
            this.lSE.Text = "0";
            this.lSE.Visible = false;
            // 
            // lSO
            // 
            this.lSO.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lSO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lSO.Location = new System.Drawing.Point(312, 32);
            this.lSO.Name = "lSO";
            this.lSO.Size = new System.Drawing.Size(16, 16);
            this.lSO.TabIndex = 88;
            this.lSO.Text = "0";
            this.lSO.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(296, 104);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(14, 16);
            this.label1.TabIndex = 86;
            this.label1.Text = "%";
            this.label1.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.Lavender;
            this.textBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.textBox1.Location = new System.Drawing.Point(256, 96);
            this.textBox1.MaxLength = 5;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(40, 20);
            this.textBox1.TabIndex = 85;
            this.textBox1.Visible = false;
            // 
            // cbSS
            // 
            this.cbSS.BackColor = System.Drawing.Color.Lavender;
            this.cbSS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSS.Location = new System.Drawing.Point(96, 96);
            this.cbSS.Name = "cbSS";
            this.cbSS.Size = new System.Drawing.Size(160, 21);
            this.cbSS.TabIndex = 84;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(48, 96);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(48, 21);
            this.label5.TabIndex = 83;
            this.label5.Text = "Special:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(8, 16);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(24, 24);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 82;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Visible = false;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Transparent;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(296, 80);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(14, 16);
            this.label14.TabIndex = 78;
            this.label14.Text = "%";
            this.label14.Visible = false;
            // 
            // tRSP
            // 
            this.tRSP.BackColor = System.Drawing.Color.Lavender;
            this.tRSP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tRSP.Location = new System.Drawing.Point(256, 71);
            this.tRSP.MaxLength = 5;
            this.tRSP.Name = "tRSP";
            this.tRSP.Size = new System.Drawing.Size(40, 20);
            this.tRSP.TabIndex = 77;
            this.tRSP.Visible = false;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Transparent;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(296, 56);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(14, 16);
            this.label15.TabIndex = 76;
            this.label15.Text = "%";
            this.label15.Visible = false;
            // 
            // tRSE
            // 
            this.tRSE.BackColor = System.Drawing.Color.Lavender;
            this.tRSE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tRSE.Location = new System.Drawing.Point(256, 50);
            this.tRSE.MaxLength = 5;
            this.tRSE.Name = "tRSE";
            this.tRSE.Size = new System.Drawing.Size(40, 20);
            this.tRSE.TabIndex = 75;
            this.tRSE.Visible = false;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(296, 32);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(14, 16);
            this.label13.TabIndex = 74;
            this.label13.Text = "%";
            this.label13.Visible = false;
            // 
            // tRSO
            // 
            this.tRSO.BackColor = System.Drawing.Color.Lavender;
            this.tRSO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tRSO.Location = new System.Drawing.Point(256, 29);
            this.tRSO.MaxLength = 5;
            this.tRSO.Name = "tRSO";
            this.tRSO.Size = new System.Drawing.Size(40, 20);
            this.tRSO.TabIndex = 73;
            this.tRSO.Visible = false;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.Transparent;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(296, 8);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(14, 16);
            this.label12.TabIndex = 72;
            this.label12.Text = "%";
            this.label12.Visible = false;
            // 
            // tRSI
            // 
            this.tRSI.BackColor = System.Drawing.Color.Lavender;
            this.tRSI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tRSI.Location = new System.Drawing.Point(256, 8);
            this.tRSI.MaxLength = 5;
            this.tRSI.Name = "tRSI";
            this.tRSI.Size = new System.Drawing.Size(40, 20);
            this.tRSI.TabIndex = 71;
            this.tRSI.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tRSI.Visible = false;
            // 
            // cbSp
            // 
            this.cbSp.BackColor = System.Drawing.Color.Lavender;
            this.cbSp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSp.Location = new System.Drawing.Point(96, 71);
            this.cbSp.Name = "cbSp";
            this.cbSp.Size = new System.Drawing.Size(160, 21);
            this.cbSp.TabIndex = 69;
            this.cbSp.SelectedIndexChanged += new System.EventHandler(this.cbSp_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(24, 71);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 21);
            this.label8.TabIndex = 68;
            this.label8.Text = "PO:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSe
            // 
            this.cbSe.BackColor = System.Drawing.Color.Lavender;
            this.cbSe.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSe.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSe.Location = new System.Drawing.Point(96, 50);
            this.cbSe.Name = "cbSe";
            this.cbSe.Size = new System.Drawing.Size(160, 21);
            this.cbSe.TabIndex = 67;
            this.cbSe.SelectedIndexChanged += new System.EventHandler(this.cbSe_SelectedIndexChanged);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(32, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 14);
            this.label9.TabIndex = 66;
            this.label9.Text = "Engineering:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbSo
            // 
            this.cbSo.BackColor = System.Drawing.Color.Lavender;
            this.cbSo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSo.Location = new System.Drawing.Point(96, 29);
            this.cbSo.Name = "cbSo";
            this.cbSo.Size = new System.Drawing.Size(160, 21);
            this.cbSo.TabIndex = 65;
            this.cbSo.SelectedIndexChanged += new System.EventHandler(this.cbSo_SelectedIndexChanged);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(24, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(72, 14);
            this.label7.TabIndex = 64;
            this.label7.Text = "Outside:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSi
            // 
            this.cbSi.BackColor = System.Drawing.Color.Lavender;
            this.cbSi.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSi.Location = new System.Drawing.Point(96, 8);
            this.cbSi.Name = "cbSi";
            this.cbSi.Size = new System.Drawing.Size(160, 21);
            this.cbSi.TabIndex = 63;
            this.cbSi.SelectedIndexChanged += new System.EventHandler(this.cbSi_SelectedIndexChanged);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(64, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(32, 16);
            this.label11.TabIndex = 62;
            this.label11.Text = "Inside:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(649, 7);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(56, 16);
            this.label27.TabIndex = 65;
            this.label27.Text = "Comment:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lSi
            // 
            this.lSi.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lSi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lSi.Location = new System.Drawing.Point(101, -1);
            this.lSi.Name = "lSi";
            this.lSi.Size = new System.Drawing.Size(26, 25);
            this.lSi.TabIndex = 87;
            this.lSi.Text = "0";
            this.lSi.Visible = false;
            // 
            // tGCmnt
            // 
            this.tGCmnt.BackColor = System.Drawing.Color.Lavender;
            this.tGCmnt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tGCmnt.Location = new System.Drawing.Point(649, 24);
            this.tGCmnt.MaxLength = 199;
            this.tGCmnt.Multiline = true;
            this.tGCmnt.Name = "tGCmnt";
            this.tGCmnt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tGCmnt.Size = new System.Drawing.Size(311, 112);
            this.tGCmnt.TabIndex = 64;
            this.tGCmnt.TextChanged += new System.EventHandler(this.tGCmnt_TextChanged);
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.pictureBox9);
            this.groupBox8.Controls.Add(this.lSave);
            this.groupBox8.Controls.Add(this.lQstatus);
            this.groupBox8.Controls.Add(this.pictureBox8);
            this.groupBox8.Controls.Add(this.lLocTot);
            this.groupBox8.Controls.Add(this.LocTot);
            this.groupBox8.Controls.Add(this.lAgTot);
            this.groupBox8.Controls.Add(this.AgTot);
            this.groupBox8.Controls.Add(this.cbCIA);
            this.groupBox8.Controls.Add(this.cbCSA);
            this.groupBox8.Controls.Add(this.cbCPA);
            this.groupBox8.Controls.Add(this.cbCQA);
            this.groupBox8.Controls.Add(this.lIncoT_ID);
            this.groupBox8.Controls.Add(this.lCurr);
            this.groupBox8.Controls.Add(this.lVia_ID);
            this.groupBox8.Controls.Add(this.lTerm_ID);
            this.groupBox8.Controls.Add(this.cbIncoTerm);
            this.groupBox8.Controls.Add(this.label25);
            this.groupBox8.Controls.Add(this.cbCurr);
            this.groupBox8.Controls.Add(this.label30);
            this.groupBox8.Controls.Add(this.cbShipVia);
            this.groupBox8.Controls.Add(this.label26);
            this.groupBox8.Controls.Add(this.cbTerms);
            this.groupBox8.Controls.Add(this.label31);
            this.groupBox8.Controls.Add(this.lIA);
            this.groupBox8.Controls.Add(this.lQA);
            this.groupBox8.Controls.Add(this.lSA);
            this.groupBox8.Controls.Add(this.lPA);
            this.groupBox8.Controls.Add(this.btnAI);
            this.groupBox8.Controls.Add(this.btnAQ);
            this.groupBox8.Controls.Add(this.btnAP);
            this.groupBox8.Controls.Add(this.btnAS);
            this.groupBox8.Controls.Add(this.label32);
            this.groupBox8.Controls.Add(this.label33);
            this.groupBox8.Controls.Add(this.label34);
            this.groupBox8.Controls.Add(this.label35);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox8.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox8.Location = new System.Drawing.Point(0, 202);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(976, 161);
            this.groupBox8.TabIndex = 50;
            this.groupBox8.TabStop = false;
            this.groupBox8.Enter += new System.EventHandler(this.groupBox8_Enter_1);
            // 
            // pictureBox9
            // 
            this.pictureBox9.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox9.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox9.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox9.Image")));
            this.pictureBox9.Location = new System.Drawing.Point(872, 14);
            this.pictureBox9.Name = "pictureBox9";
            this.pictureBox9.Size = new System.Drawing.Size(24, 24);
            this.pictureBox9.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox9.TabIndex = 107;
            this.pictureBox9.TabStop = false;
            this.pictureBox9.Click += new System.EventHandler(this.pictureBox9_Click);
            // 
            // lSave
            // 
            this.lSave.BackColor = System.Drawing.Color.ForestGreen;
            this.lSave.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lSave.Location = new System.Drawing.Point(936, 16);
            this.lSave.Name = "lSave";
            this.lSave.Size = new System.Drawing.Size(24, 16);
            this.lSave.TabIndex = 106;
            this.lSave.Text = "N";
            this.lSave.Visible = false;
            // 
            // lQstatus
            // 
            this.lQstatus.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lQstatus.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lQstatus.Location = new System.Drawing.Point(936, 48);
            this.lQstatus.Name = "lQstatus";
            this.lQstatus.Size = new System.Drawing.Size(24, 16);
            this.lQstatus.TabIndex = 105;
            this.lQstatus.Text = "N";
            this.lQstatus.Visible = false;
            this.lQstatus.TextChanged += new System.EventHandler(this.lQstatus_TextChanged);
            // 
            // pictureBox8
            // 
            this.pictureBox8.Location = new System.Drawing.Point(920, 72);
            this.pictureBox8.Name = "pictureBox8";
            this.pictureBox8.Size = new System.Drawing.Size(40, 16);
            this.pictureBox8.TabIndex = 102;
            this.pictureBox8.TabStop = false;
            // 
            // lLocTot
            // 
            this.lLocTot.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLocTot.ForeColor = System.Drawing.Color.Blue;
            this.lLocTot.Location = new System.Drawing.Point(893, 119);
            this.lLocTot.Name = "lLocTot";
            this.lLocTot.Size = new System.Drawing.Size(40, 16);
            this.lLocTot.TabIndex = 101;
            this.lLocTot.Text = "Local Total:";
            this.lLocTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lLocTot.Visible = false;
            // 
            // LocTot
            // 
            this.LocTot.BackColor = System.Drawing.Color.Lavender;
            this.LocTot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.LocTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LocTot.ForeColor = System.Drawing.Color.MediumBlue;
            this.LocTot.Location = new System.Drawing.Point(939, 112);
            this.LocTot.Name = "LocTot";
            this.LocTot.Size = new System.Drawing.Size(29, 22);
            this.LocTot.TabIndex = 100;
            this.LocTot.Text = "0";
            this.LocTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LocTot.Visible = false;
            // 
            // lAgTot
            // 
            this.lAgTot.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAgTot.ForeColor = System.Drawing.Color.Blue;
            this.lAgTot.Location = new System.Drawing.Point(893, 135);
            this.lAgTot.Name = "lAgTot";
            this.lAgTot.Size = new System.Drawing.Size(40, 16);
            this.lAgTot.TabIndex = 99;
            this.lAgTot.Text = "Agent Total:";
            this.lAgTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lAgTot.Visible = false;
            // 
            // AgTot
            // 
            this.AgTot.BackColor = System.Drawing.Color.Lavender;
            this.AgTot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AgTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AgTot.ForeColor = System.Drawing.Color.MediumBlue;
            this.AgTot.Location = new System.Drawing.Point(939, 136);
            this.AgTot.Name = "AgTot";
            this.AgTot.Size = new System.Drawing.Size(29, 22);
            this.AgTot.TabIndex = 98;
            this.AgTot.Text = "0";
            this.AgTot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AgTot.Visible = false;
            // 
            // cbCIA
            // 
            this.cbCIA.BackColor = System.Drawing.Color.Lavender;
            this.cbCIA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCIA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCIA.Location = new System.Drawing.Point(584, 88);
            this.cbCIA.Name = "cbCIA";
            this.cbCIA.Size = new System.Drawing.Size(288, 21);
            this.cbCIA.TabIndex = 93;
            this.cbCIA.SelectedIndexChanged += new System.EventHandler(this.cbCIA_SelectedIndexChanged);
            // 
            // cbCSA
            // 
            this.cbCSA.BackColor = System.Drawing.Color.Lavender;
            this.cbCSA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCSA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCSA.Location = new System.Drawing.Point(584, 64);
            this.cbCSA.Name = "cbCSA";
            this.cbCSA.Size = new System.Drawing.Size(288, 21);
            this.cbCSA.TabIndex = 92;
            this.cbCSA.SelectedIndexChanged += new System.EventHandler(this.cbCSA_SelectedIndexChanged);
            // 
            // cbCPA
            // 
            this.cbCPA.BackColor = System.Drawing.Color.Lavender;
            this.cbCPA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCPA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCPA.Location = new System.Drawing.Point(584, 40);
            this.cbCPA.Name = "cbCPA";
            this.cbCPA.Size = new System.Drawing.Size(288, 21);
            this.cbCPA.TabIndex = 91;
            this.cbCPA.SelectedIndexChanged += new System.EventHandler(this.cbCPA_SelectedIndexChanged);
            // 
            // cbCQA
            // 
            this.cbCQA.BackColor = System.Drawing.Color.Lavender;
            this.cbCQA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCQA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCQA.Location = new System.Drawing.Point(584, 16);
            this.cbCQA.Name = "cbCQA";
            this.cbCQA.Size = new System.Drawing.Size(288, 21);
            this.cbCQA.TabIndex = 90;
            this.cbCQA.SelectedIndexChanged += new System.EventHandler(this.cbCQA_SelectedIndexChanged);
            // 
            // lIncoT_ID
            // 
            this.lIncoT_ID.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lIncoT_ID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lIncoT_ID.Location = new System.Drawing.Point(288, 136);
            this.lIncoT_ID.Name = "lIncoT_ID";
            this.lIncoT_ID.Size = new System.Drawing.Size(16, 16);
            this.lIncoT_ID.TabIndex = 89;
            this.lIncoT_ID.Text = "0";
            this.lIncoT_ID.Visible = false;
            // 
            // lCurr
            // 
            this.lCurr.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lCurr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lCurr.Location = new System.Drawing.Point(288, 112);
            this.lCurr.Name = "lCurr";
            this.lCurr.Size = new System.Drawing.Size(16, 16);
            this.lCurr.TabIndex = 88;
            this.lCurr.Text = "0";
            this.lCurr.Visible = false;
            // 
            // lVia_ID
            // 
            this.lVia_ID.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lVia_ID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lVia_ID.Location = new System.Drawing.Point(264, 136);
            this.lVia_ID.Name = "lVia_ID";
            this.lVia_ID.Size = new System.Drawing.Size(16, 16);
            this.lVia_ID.TabIndex = 87;
            this.lVia_ID.Text = "0";
            this.lVia_ID.Visible = false;
            // 
            // lTerm_ID
            // 
            this.lTerm_ID.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lTerm_ID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lTerm_ID.Location = new System.Drawing.Point(264, 112);
            this.lTerm_ID.Name = "lTerm_ID";
            this.lTerm_ID.Size = new System.Drawing.Size(16, 16);
            this.lTerm_ID.TabIndex = 86;
            this.lTerm_ID.Text = "0";
            this.lTerm_ID.Visible = false;
            // 
            // cbIncoTerm
            // 
            this.cbIncoTerm.BackColor = System.Drawing.Color.Lavender;
            this.cbIncoTerm.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIncoTerm.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbIncoTerm.Location = new System.Drawing.Point(344, 136);
            this.cbIncoTerm.Name = "cbIncoTerm";
            this.cbIncoTerm.Size = new System.Drawing.Size(176, 21);
            this.cbIncoTerm.TabIndex = 60;
            this.cbIncoTerm.SelectedIndexChanged += new System.EventHandler(this.cbIncoTerm_SelectedIndexChanged);
            // 
            // label25
            // 
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(280, 136);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(64, 20);
            this.label25.TabIndex = 59;
            this.label25.Text = "IncoTerm:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbCurr
            // 
            this.cbCurr.BackColor = System.Drawing.Color.Lavender;
            this.cbCurr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCurr.Items.AddRange(new object[] {
            "USD",
            "CAD",
            "EURO"});
            this.cbCurr.Location = new System.Drawing.Point(344, 112);
            this.cbCurr.Name = "cbCurr";
            this.cbCurr.Size = new System.Drawing.Size(176, 21);
            this.cbCurr.TabIndex = 58;
            this.cbCurr.Visible = false;
            this.cbCurr.SelectedIndexChanged += new System.EventHandler(this.cbCurr_SelectedIndexChanged);
            // 
            // label30
            // 
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(280, 112);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(64, 20);
            this.label30.TabIndex = 57;
            this.label30.Text = "Currency:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label30.Visible = false;
            // 
            // cbShipVia
            // 
            this.cbShipVia.BackColor = System.Drawing.Color.Lavender;
            this.cbShipVia.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbShipVia.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbShipVia.Location = new System.Drawing.Point(80, 136);
            this.cbShipVia.Name = "cbShipVia";
            this.cbShipVia.Size = new System.Drawing.Size(176, 21);
            this.cbShipVia.TabIndex = 56;
            this.cbShipVia.SelectedIndexChanged += new System.EventHandler(this.cbShipVia_SelectedIndexChanged);
            // 
            // label26
            // 
            this.label26.BackColor = System.Drawing.Color.Transparent;
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(0, 136);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(80, 20);
            this.label26.TabIndex = 55;
            this.label26.Text = "Delivery terms:";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbTerms
            // 
            this.cbTerms.BackColor = System.Drawing.Color.Lavender;
            this.cbTerms.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTerms.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbTerms.Location = new System.Drawing.Point(80, 112);
            this.cbTerms.Name = "cbTerms";
            this.cbTerms.Size = new System.Drawing.Size(176, 21);
            this.cbTerms.TabIndex = 54;
            this.cbTerms.SelectedIndexChanged += new System.EventHandler(this.cbTerms_SelectedIndexChanged);
            // 
            // label31
            // 
            this.label31.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label31.Location = new System.Drawing.Point(16, 112);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(56, 20);
            this.label31.TabIndex = 53;
            this.label31.Text = "Terms:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lIA
            // 
            this.lIA.BackColor = System.Drawing.Color.AliceBlue;
            this.lIA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lIA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lIA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lIA.Location = new System.Drawing.Point(80, 88);
            this.lIA.Name = "lIA";
            this.lIA.Size = new System.Drawing.Size(480, 20);
            this.lIA.TabIndex = 52;
            // 
            // lQA
            // 
            this.lQA.BackColor = System.Drawing.Color.AliceBlue;
            this.lQA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lQA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lQA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lQA.Location = new System.Drawing.Point(80, 16);
            this.lQA.Name = "lQA";
            this.lQA.Size = new System.Drawing.Size(480, 20);
            this.lQA.TabIndex = 51;
            // 
            // lSA
            // 
            this.lSA.BackColor = System.Drawing.Color.AliceBlue;
            this.lSA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lSA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lSA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lSA.Location = new System.Drawing.Point(80, 64);
            this.lSA.Name = "lSA";
            this.lSA.Size = new System.Drawing.Size(480, 20);
            this.lSA.TabIndex = 50;
            this.lSA.Click += new System.EventHandler(this.lSA_Click);
            // 
            // lPA
            // 
            this.lPA.BackColor = System.Drawing.Color.AliceBlue;
            this.lPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lPA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lPA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lPA.Location = new System.Drawing.Point(80, 40);
            this.lPA.Name = "lPA";
            this.lPA.Size = new System.Drawing.Size(480, 20);
            this.lPA.TabIndex = 49;
            // 
            // btnAI
            // 
            this.btnAI.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAI.Location = new System.Drawing.Point(560, 88);
            this.btnAI.Name = "btnAI";
            this.btnAI.Size = new System.Drawing.Size(24, 20);
            this.btnAI.TabIndex = 48;
            this.btnAI.Text = "...";
            this.btnAI.Click += new System.EventHandler(this.btnAI_Click);
            // 
            // btnAQ
            // 
            this.btnAQ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAQ.Location = new System.Drawing.Point(560, 16);
            this.btnAQ.Name = "btnAQ";
            this.btnAQ.Size = new System.Drawing.Size(24, 20);
            this.btnAQ.TabIndex = 47;
            this.btnAQ.Text = "...";
            this.btnAQ.Click += new System.EventHandler(this.btnAQ_Click);
            // 
            // btnAP
            // 
            this.btnAP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAP.Location = new System.Drawing.Point(560, 40);
            this.btnAP.Name = "btnAP";
            this.btnAP.Size = new System.Drawing.Size(24, 20);
            this.btnAP.TabIndex = 46;
            this.btnAP.Text = "...";
            this.btnAP.Click += new System.EventHandler(this.btnAP_Click);
            // 
            // btnAS
            // 
            this.btnAS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAS.Location = new System.Drawing.Point(560, 64);
            this.btnAS.Name = "btnAS";
            this.btnAS.Size = new System.Drawing.Size(24, 20);
            this.btnAS.TabIndex = 45;
            this.btnAS.Text = "...";
            this.btnAS.Click += new System.EventHandler(this.btnAS_Click);
            // 
            // label32
            // 
            this.label32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label32.Location = new System.Drawing.Point(8, 88);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(64, 20);
            this.label32.TabIndex = 15;
            this.label32.Text = "Invoice:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label33
            // 
            this.label33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label33.Location = new System.Drawing.Point(8, 64);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(64, 20);
            this.label33.TabIndex = 13;
            this.label33.Text = "Ship:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label34
            // 
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(8, 40);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(64, 20);
            this.label34.TabIndex = 11;
            this.label34.Text = "Purchase:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label35
            // 
            this.label35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label35.Location = new System.Drawing.Point(8, 16);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(64, 20);
            this.label35.TabIndex = 9;
            this.label35.Text = "Quotation:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox4.Controls.Add(this.pictureBox12);
            this.groupBox4.Controls.Add(this.lActivty);
            this.groupBox4.Controls.Add(this.btnChangMLTP);
            this.groupBox4.Controls.Add(this.label82);
            this.groupBox4.Controls.Add(this.btnSavMLTP);
            this.groupBox4.Controls.Add(this.groupBox11);
            this.groupBox4.Controls.Add(this.label60);
            this.groupBox4.Controls.Add(this.btnIn);
            this.groupBox4.Controls.Add(this.btnCHNGCmpny);
            this.groupBox4.Controls.Add(this.btnchngCP);
            this.groupBox4.Controls.Add(this.btnchngCN);
            this.groupBox4.Controls.Add(this.printLabel);
            this.groupBox4.Controls.Add(this.picSeek);
            this.groupBox4.Controls.Add(this.tKey);
            this.groupBox4.Controls.Add(this.label57);
            this.groupBox4.Controls.Add(this.label56);
            this.groupBox4.Controls.Add(this.loM);
            this.groupBox4.Controls.Add(this.label55);
            this.groupBox4.Controls.Add(this.STDMultp);
            this.groupBox4.Controls.Add(this.label54);
            this.groupBox4.Controls.Add(this.label50);
            this.groupBox4.Controls.Add(this.label53);
            this.groupBox4.Controls.Add(this.tCust_Mult);
            this.groupBox4.Controls.Add(this.label52);
            this.groupBox4.Controls.Add(this.groupBox9);
            this.groupBox4.Controls.Add(this.lIpmgr);
            this.groupBox4.Controls.Add(this.label46);
            this.groupBox4.Controls.Add(this.cbIPmgr);
            this.groupBox4.Controls.Add(this.label45);
            this.groupBox4.Controls.Add(this.lHiDelv);
            this.groupBox4.Controls.Add(this.btnNewID);
            this.groupBox4.Controls.Add(this.lEmp_ID);
            this.groupBox4.Controls.Add(this.pictureBox4);
            this.groupBox4.Controls.Add(this.lcpnyID);
            this.groupBox4.Controls.Add(this.lFax);
            this.groupBox4.Controls.Add(this.lPhone);
            this.groupBox4.Controls.Add(this.lAdrs);
            this.groupBox4.Controls.Add(this.label41);
            this.groupBox4.Controls.Add(this.label36);
            this.groupBox4.Controls.Add(this.label39);
            this.groupBox4.Controls.Add(this.label38);
            this.groupBox4.Controls.Add(this.cbEmploy);
            this.groupBox4.Controls.Add(this.label37);
            this.groupBox4.Controls.Add(this.label4);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.label3);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.tProjNAME);
            this.groupBox4.Controls.Add(this.label40);
            this.groupBox4.Controls.Add(this.tQuoteID);
            this.groupBox4.Controls.Add(this.gifCounter);
            this.groupBox4.Controls.Add(this.cbCompany);
            this.groupBox4.Controls.Add(this.lCpnyName);
            this.groupBox4.Controls.Add(this.cbLang);
            this.groupBox4.Controls.Add(this.Lang);
            this.groupBox4.Controls.Add(this.lQDopen);
            this.groupBox4.Controls.Add(this.tOpendate);
            this.groupBox4.Controls.Add(this.cbCPmgr);
            this.groupBox4.Controls.Add(this.lcbCPmgr);
            this.groupBox4.Controls.Add(this.cbContacts);
            this.groupBox4.Controls.Add(this.lContacts);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox4.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox4.Location = new System.Drawing.Point(0, 0);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(976, 202);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "General";
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // pictureBox12
            // 
            this.pictureBox12.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox12.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox12.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox12.Image")));
            this.pictureBox12.Location = new System.Drawing.Point(257, 166);
            this.pictureBox12.Name = "pictureBox12";
            this.pictureBox12.Size = new System.Drawing.Size(39, 24);
            this.pictureBox12.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox12.TabIndex = 110;
            this.pictureBox12.TabStop = false;
            this.pictureBox12.Click += new System.EventHandler(this.pictureBox12_Click);
            // 
            // lActivty
            // 
            this.lActivty.BackColor = System.Drawing.Color.AliceBlue;
            this.lActivty.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lActivty.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lActivty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lActivty.Location = new System.Drawing.Point(400, 146);
            this.lActivty.Name = "lActivty";
            this.lActivty.Size = new System.Drawing.Size(248, 20);
            this.lActivty.TabIndex = 172;
            this.lActivty.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnChangMLTP
            // 
            this.btnChangMLTP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnChangMLTP.Location = new System.Drawing.Point(649, 145);
            this.btnChangMLTP.Name = "btnChangMLTP";
            this.btnChangMLTP.Size = new System.Drawing.Size(136, 23);
            this.btnChangMLTP.TabIndex = 109;
            this.btnChangMLTP.Text = "Change Activity";
            this.btnChangMLTP.Click += new System.EventHandler(this.btnChangMLTP_Click);
            // 
            // label82
            // 
            this.label82.BackColor = System.Drawing.SystemColors.Control;
            this.label82.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label82.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label82.Location = new System.Drawing.Point(352, 148);
            this.label82.Name = "label82";
            this.label82.Size = new System.Drawing.Size(48, 16);
            this.label82.TabIndex = 171;
            this.label82.Text = "Activity:";
            this.label82.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSavMLTP
            // 
            this.btnSavMLTP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSavMLTP.Location = new System.Drawing.Point(456, 168);
            this.btnSavMLTP.Name = "btnSavMLTP";
            this.btnSavMLTP.Size = new System.Drawing.Size(121, 23);
            this.btnSavMLTP.TabIndex = 108;
            this.btnSavMLTP.Text = "Save for future Quote";
            this.btnSavMLTP.Click += new System.EventHandler(this.btnSavMLTP_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.lSFX);
            this.groupBox11.Controls.Add(this.lCurrIQID);
            this.groupBox11.Controls.Add(this.lConFax);
            this.groupBox11.Controls.Add(this.lemail);
            this.groupBox11.Controls.Add(this.lConTel);
            this.groupBox11.Controls.Add(this.lConExt);
            this.groupBox11.Controls.Add(this.lConName);
            this.groupBox11.Controls.Add(this.lPrfx);
            this.groupBox11.Controls.Add(this.lCpmgr);
            this.groupBox11.Controls.Add(this.lContact_ID);
            this.groupBox11.Controls.Add(this.button7);
            this.groupBox11.Controls.Add(this.lEmpSFX);
            this.groupBox11.Controls.Add(this.lLang);
            this.groupBox11.Controls.Add(this.lEExt);
            this.groupBox11.Controls.Add(this.pictureBox3);
            this.groupBox11.Controls.Add(this.pictureBox5);
            this.groupBox11.Location = new System.Drawing.Point(834, 52);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(134, 36);
            this.groupBox11.TabIndex = 170;
            this.groupBox11.TabStop = false;
            this.groupBox11.Visible = false;
            // 
            // lSFX
            // 
            this.lSFX.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lSFX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lSFX.Location = new System.Drawing.Point(18, 16);
            this.lSFX.Name = "lSFX";
            this.lSFX.Size = new System.Drawing.Size(16, 16);
            this.lSFX.TabIndex = 90;
            this.lSFX.Visible = false;
            // 
            // lCurrIQID
            // 
            this.lCurrIQID.BackColor = System.Drawing.Color.Salmon;
            this.lCurrIQID.Location = new System.Drawing.Point(92, 16);
            this.lCurrIQID.Name = "lCurrIQID";
            this.lCurrIQID.Size = new System.Drawing.Size(24, 16);
            this.lCurrIQID.TabIndex = 169;
            this.lCurrIQID.Text = "0";
            this.lCurrIQID.Visible = false;
            // 
            // lConFax
            // 
            this.lConFax.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lConFax.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lConFax.Location = new System.Drawing.Point(40, 16);
            this.lConFax.Name = "lConFax";
            this.lConFax.Size = new System.Drawing.Size(16, 16);
            this.lConFax.TabIndex = 166;
            this.lConFax.Visible = false;
            // 
            // lemail
            // 
            this.lemail.BackColor = System.Drawing.Color.ForestGreen;
            this.lemail.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lemail.Location = new System.Drawing.Point(278, 14);
            this.lemail.Name = "lemail";
            this.lemail.Size = new System.Drawing.Size(16, 16);
            this.lemail.TabIndex = 164;
            this.lemail.Visible = false;
            // 
            // lConTel
            // 
            this.lConTel.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lConTel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lConTel.Location = new System.Drawing.Point(62, 16);
            this.lConTel.Name = "lConTel";
            this.lConTel.Size = new System.Drawing.Size(24, 16);
            this.lConTel.TabIndex = 165;
            this.lConTel.Visible = false;
            // 
            // lConExt
            // 
            this.lConExt.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lConExt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lConExt.Location = new System.Drawing.Point(122, 16);
            this.lConExt.Name = "lConExt";
            this.lConExt.Size = new System.Drawing.Size(24, 16);
            this.lConExt.TabIndex = 93;
            this.lConExt.Visible = false;
            // 
            // lConName
            // 
            this.lConName.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lConName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lConName.Location = new System.Drawing.Point(152, 16);
            this.lConName.Name = "lConName";
            this.lConName.Size = new System.Drawing.Size(24, 16);
            this.lConName.TabIndex = 92;
            this.lConName.Visible = false;
            // 
            // lPrfx
            // 
            this.lPrfx.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lPrfx.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lPrfx.Location = new System.Drawing.Point(183, 16);
            this.lPrfx.Name = "lPrfx";
            this.lPrfx.Size = new System.Drawing.Size(16, 16);
            this.lPrfx.TabIndex = 89;
            this.lPrfx.Visible = false;
            // 
            // lCpmgr
            // 
            this.lCpmgr.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lCpmgr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lCpmgr.Location = new System.Drawing.Point(205, 16);
            this.lCpmgr.Name = "lCpmgr";
            this.lCpmgr.Size = new System.Drawing.Size(24, 16);
            this.lCpmgr.TabIndex = 104;
            this.lCpmgr.Text = "0";
            this.lCpmgr.Visible = false;
            // 
            // lContact_ID
            // 
            this.lContact_ID.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lContact_ID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lContact_ID.Location = new System.Drawing.Point(235, 16);
            this.lContact_ID.Name = "lContact_ID";
            this.lContact_ID.Size = new System.Drawing.Size(16, 16);
            this.lContact_ID.TabIndex = 84;
            this.lContact_ID.Text = "0";
            this.lContact_ID.Visible = false;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(263, 10);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(16, 20);
            this.button7.TabIndex = 157;
            this.button7.Text = "Search";
            this.button7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button7.Visible = false;
            // 
            // lEmpSFX
            // 
            this.lEmpSFX.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lEmpSFX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lEmpSFX.Location = new System.Drawing.Point(300, 16);
            this.lEmpSFX.Name = "lEmpSFX";
            this.lEmpSFX.Size = new System.Drawing.Size(14, 16);
            this.lEmpSFX.TabIndex = 94;
            this.lEmpSFX.Visible = false;
            // 
            // lLang
            // 
            this.lLang.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lLang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lLang.Location = new System.Drawing.Point(320, 14);
            this.lLang.Name = "lLang";
            this.lLang.Size = new System.Drawing.Size(16, 16);
            this.lLang.TabIndex = 85;
            this.lLang.Visible = false;
            // 
            // lEExt
            // 
            this.lEExt.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lEExt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lEExt.Location = new System.Drawing.Point(342, 16);
            this.lEExt.Name = "lEExt";
            this.lEExt.Size = new System.Drawing.Size(32, 16);
            this.lEExt.TabIndex = 91;
            this.lEExt.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(133, 9);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(24, 24);
            this.pictureBox3.TabIndex = 80;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(405, 10);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(16, 16);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 82;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Visible = false;
            // 
            // label60
            // 
            this.label60.BackColor = System.Drawing.Color.Transparent;
            this.label60.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label60.ForeColor = System.Drawing.Color.Red;
            this.label60.Location = new System.Drawing.Point(320, 82);
            this.label60.Name = "label60";
            this.label60.Size = new System.Drawing.Size(8, 16);
            this.label60.TabIndex = 168;
            this.label60.Text = "*";
            this.label60.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnIn
            // 
            this.btnIn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnIn.Location = new System.Drawing.Point(272, 36);
            this.btnIn.Name = "btnIn";
            this.btnIn.Size = new System.Drawing.Size(24, 20);
            this.btnIn.TabIndex = 167;
            this.btnIn.Text = "...";
            this.btnIn.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnIn.Click += new System.EventHandler(this.btnIn_Click);
            // 
            // btnCHNGCmpny
            // 
            this.btnCHNGCmpny.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCHNGCmpny.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCHNGCmpny.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnCHNGCmpny.Location = new System.Drawing.Point(656, 16);
            this.btnCHNGCmpny.Name = "btnCHNGCmpny";
            this.btnCHNGCmpny.Size = new System.Drawing.Size(24, 20);
            this.btnCHNGCmpny.TabIndex = 163;
            this.btnCHNGCmpny.Text = "...";
            this.btnCHNGCmpny.Visible = false;
            this.btnCHNGCmpny.Click += new System.EventHandler(this.btnCHNGCmpny_Click);
            // 
            // btnchngCP
            // 
            this.btnchngCP.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnchngCP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnchngCP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnchngCP.Location = new System.Drawing.Point(648, 126);
            this.btnchngCP.Name = "btnchngCP";
            this.btnchngCP.Size = new System.Drawing.Size(24, 20);
            this.btnchngCP.TabIndex = 162;
            this.btnchngCP.Text = "...";
            this.btnchngCP.Click += new System.EventHandler(this.btnchngCP_Click);
            // 
            // btnchngCN
            // 
            this.btnchngCN.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnchngCN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnchngCN.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnchngCN.Location = new System.Drawing.Point(648, 89);
            this.btnchngCN.Name = "btnchngCN";
            this.btnchngCN.Size = new System.Drawing.Size(24, 20);
            this.btnchngCN.TabIndex = 161;
            this.btnchngCN.Text = "...";
            this.btnchngCN.Click += new System.EventHandler(this.btnchngCN_Click);
            // 
            // printLabel
            // 
            this.printLabel.BackColor = System.Drawing.Color.Transparent;
            this.printLabel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printLabel.Image = ((System.Drawing.Image)(resources.GetObject("printLabel.Image")));
            this.printLabel.Location = new System.Drawing.Point(296, 32);
            this.printLabel.Name = "printLabel";
            this.printLabel.Size = new System.Drawing.Size(40, 40);
            this.printLabel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.printLabel.TabIndex = 159;
            this.printLabel.TabStop = false;
            this.printLabel.Click += new System.EventHandler(this.printLabel_Click);
            // 
            // picSeek
            // 
            this.picSeek.BackColor = System.Drawing.Color.Transparent;
            this.picSeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSeek.Image = ((System.Drawing.Image)(resources.GetObject("picSeek.Image")));
            this.picSeek.Location = new System.Drawing.Point(688, 14);
            this.picSeek.Name = "picSeek";
            this.picSeek.Size = new System.Drawing.Size(32, 24);
            this.picSeek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSeek.TabIndex = 158;
            this.picSeek.TabStop = false;
            this.picSeek.Visible = false;
            this.picSeek.Click += new System.EventHandler(this.picSeek_Click);
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.DarkSalmon;
            this.tKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.ForeColor = System.Drawing.Color.Blue;
            this.tKey.Location = new System.Drawing.Point(728, 16);
            this.tKey.MaxLength = 60;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(240, 20);
            this.tKey.TabIndex = 156;
            this.tKey.Visible = false;
            this.tKey.TextChanged += new System.EventHandler(this.tKey_TextChanged);
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.SystemColors.Control;
            this.label57.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label57.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label57.Location = new System.Drawing.Point(22, 131);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(64, 16);
            this.label57.TabIndex = 112;
            this.label57.Text = "Currency:";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label56
            // 
            this.label56.BackColor = System.Drawing.Color.Transparent;
            this.label56.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label56.ForeColor = System.Drawing.Color.Red;
            this.label56.Location = new System.Drawing.Point(312, 16);
            this.label56.Name = "label56";
            this.label56.Size = new System.Drawing.Size(8, 16);
            this.label56.TabIndex = 111;
            this.label56.Text = "*";
            this.label56.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // loM
            // 
            this.loM.BackColor = System.Drawing.SystemColors.Control;
            this.loM.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.loM.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.loM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.loM.Location = new System.Drawing.Point(787, 147);
            this.loM.Name = "loM";
            this.loM.Size = new System.Drawing.Size(107, 19);
            this.loM.TabIndex = 97;
            this.loM.Text = "Activity Multiplier:";
            this.loM.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label55
            // 
            this.label55.BackColor = System.Drawing.Color.Transparent;
            this.label55.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label55.ForeColor = System.Drawing.Color.Red;
            this.label55.Location = new System.Drawing.Point(8, 16);
            this.label55.Name = "label55";
            this.label55.Size = new System.Drawing.Size(8, 16);
            this.label55.TabIndex = 110;
            this.label55.Text = "*";
            this.label55.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // STDMultp
            // 
            this.STDMultp.BackColor = System.Drawing.Color.AliceBlue;
            this.STDMultp.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.STDMultp.ForeColor = System.Drawing.Color.Sienna;
            this.STDMultp.Location = new System.Drawing.Point(894, 143);
            this.STDMultp.MaxLength = 5;
            this.STDMultp.Name = "STDMultp";
            this.STDMultp.ReadOnly = true;
            this.STDMultp.Size = new System.Drawing.Size(56, 26);
            this.STDMultp.TabIndex = 96;
            this.STDMultp.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.STDMultp.TextChanged += new System.EventHandler(this.STDMultp_TextChanged);
            // 
            // label54
            // 
            this.label54.BackColor = System.Drawing.Color.Transparent;
            this.label54.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label54.ForeColor = System.Drawing.Color.Red;
            this.label54.Location = new System.Drawing.Point(8, 40);
            this.label54.Name = "label54";
            this.label54.Size = new System.Drawing.Size(8, 16);
            this.label54.TabIndex = 109;
            this.label54.Text = "*";
            this.label54.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label50
            // 
            this.label50.BackColor = System.Drawing.SystemColors.Control;
            this.label50.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label50.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label50.ForeColor = System.Drawing.Color.Blue;
            this.label50.Location = new System.Drawing.Point(298, 169);
            this.label50.Name = "label50";
            this.label50.Size = new System.Drawing.Size(102, 16);
            this.label50.TabIndex = 94;
            this.label50.Text = "Current Multiplier:";
            this.label50.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label53
            // 
            this.label53.BackColor = System.Drawing.Color.Transparent;
            this.label53.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label53.ForeColor = System.Drawing.Color.Red;
            this.label53.Location = new System.Drawing.Point(19, 56);
            this.label53.Name = "label53";
            this.label53.Size = new System.Drawing.Size(16, 16);
            this.label53.TabIndex = 108;
            this.label53.Text = "*";
            this.label53.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tCust_Mult
            // 
            this.tCust_Mult.BackColor = System.Drawing.Color.Lavender;
            this.tCust_Mult.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tCust_Mult.ForeColor = System.Drawing.Color.Sienna;
            this.tCust_Mult.Location = new System.Drawing.Point(400, 166);
            this.tCust_Mult.MaxLength = 5;
            this.tCust_Mult.Name = "tCust_Mult";
            this.tCust_Mult.Size = new System.Drawing.Size(56, 26);
            this.tCust_Mult.TabIndex = 95;
            this.tCust_Mult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tCust_Mult.WordWrap = false;
            this.tCust_Mult.TextChanged += new System.EventHandler(this.tCust_Mult_TextChanged);
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.Red;
            this.label52.Location = new System.Drawing.Point(16, 80);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(19, 12);
            this.label52.TabIndex = 107;
            this.label52.Text = "*";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.opEuro);
            this.groupBox9.Controls.Add(this.opUS);
            this.groupBox9.Controls.Add(this.opCan);
            this.groupBox9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.ForeColor = System.Drawing.Color.Red;
            this.groupBox9.Location = new System.Drawing.Point(88, 118);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(208, 32);
            this.groupBox9.TabIndex = 106;
            this.groupBox9.TabStop = false;
            this.groupBox9.Enter += new System.EventHandler(this.groupBox9_Enter);
            // 
            // opEuro
            // 
            this.opEuro.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opEuro.ForeColor = System.Drawing.Color.DarkRed;
            this.opEuro.Location = new System.Drawing.Point(136, 10);
            this.opEuro.Name = "opEuro";
            this.opEuro.Size = new System.Drawing.Size(64, 16);
            this.opEuro.TabIndex = 108;
            this.opEuro.Text = "EURO";
            this.opEuro.CheckedChanged += new System.EventHandler(this.opEuro_CheckedChanged);
            // 
            // opUS
            // 
            this.opUS.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opUS.ForeColor = System.Drawing.Color.DarkRed;
            this.opUS.Location = new System.Drawing.Point(80, 10);
            this.opUS.Name = "opUS";
            this.opUS.Size = new System.Drawing.Size(56, 16);
            this.opUS.TabIndex = 107;
            this.opUS.Text = "USD";
            this.opUS.CheckedChanged += new System.EventHandler(this.opUS_CheckedChanged_1);
            // 
            // opCan
            // 
            this.opCan.Checked = true;
            this.opCan.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opCan.ForeColor = System.Drawing.Color.DarkRed;
            this.opCan.Location = new System.Drawing.Point(8, 10);
            this.opCan.Name = "opCan";
            this.opCan.Size = new System.Drawing.Size(64, 16);
            this.opCan.TabIndex = 106;
            this.opCan.TabStop = true;
            this.opCan.Text = "CAD";
            this.opCan.CheckedChanged += new System.EventHandler(this.opUS_CheckedChanged);
            // 
            // lIpmgr
            // 
            this.lIpmgr.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lIpmgr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lIpmgr.Location = new System.Drawing.Point(208, 80);
            this.lIpmgr.Name = "lIpmgr";
            this.lIpmgr.Size = new System.Drawing.Size(16, 16);
            this.lIpmgr.TabIndex = 103;
            this.lIpmgr.Text = "0";
            this.lIpmgr.Visible = false;
            // 
            // label46
            // 
            this.label46.BackColor = System.Drawing.SystemColors.Control;
            this.label46.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label46.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label46.Location = new System.Drawing.Point(16, 99);
            this.label46.Name = "label46";
            this.label46.Size = new System.Drawing.Size(72, 16);
            this.label46.TabIndex = 102;
            this.label46.Text = "Inside P. Mgr:";
            this.label46.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbIPmgr
            // 
            this.cbIPmgr.BackColor = System.Drawing.Color.Lavender;
            this.cbIPmgr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIPmgr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbIPmgr.Location = new System.Drawing.Point(88, 97);
            this.cbIPmgr.Name = "cbIPmgr";
            this.cbIPmgr.Size = new System.Drawing.Size(208, 21);
            this.cbIPmgr.TabIndex = 101;
            this.cbIPmgr.SelectedIndexChanged += new System.EventHandler(this.cbIPmgr_SelectedIndexChanged);
            // 
            // label45
            // 
            this.label45.BackColor = System.Drawing.SystemColors.Control;
            this.label45.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label45.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label45.Location = new System.Drawing.Point(312, 127);
            this.label45.Name = "label45";
            this.label45.Size = new System.Drawing.Size(88, 17);
            this.label45.TabIndex = 100;
            this.label45.Text = "Customer P.  Mgr:";
            this.label45.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lHiDelv
            // 
            this.lHiDelv.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lHiDelv.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lHiDelv.Location = new System.Drawing.Point(240, 88);
            this.lHiDelv.Name = "lHiDelv";
            this.lHiDelv.Size = new System.Drawing.Size(48, 24);
            this.lHiDelv.TabIndex = 96;
            this.lHiDelv.Visible = false;
            // 
            // btnNewID
            // 
            this.btnNewID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNewID.Location = new System.Drawing.Point(224, 36);
            this.btnNewID.Name = "btnNewID";
            this.btnNewID.Size = new System.Drawing.Size(40, 20);
            this.btnNewID.TabIndex = 87;
            this.btnNewID.Text = "New";
            this.btnNewID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNewID.Click += new System.EventHandler(this.btnNewID_Click);
            // 
            // lEmp_ID
            // 
            this.lEmp_ID.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lEmp_ID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lEmp_ID.Location = new System.Drawing.Point(312, 56);
            this.lEmp_ID.Name = "lEmp_ID";
            this.lEmp_ID.Size = new System.Drawing.Size(16, 16);
            this.lEmp_ID.TabIndex = 83;
            this.lEmp_ID.Text = "0";
            this.lEmp_ID.Visible = false;
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(296, 68);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(16, 16);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 81;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Visible = false;
            // 
            // lcpnyID
            // 
            this.lcpnyID.BackColor = System.Drawing.Color.SeaGreen;
            this.lcpnyID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lcpnyID.Location = new System.Drawing.Point(656, 8);
            this.lcpnyID.Name = "lcpnyID";
            this.lcpnyID.Size = new System.Drawing.Size(64, 16);
            this.lcpnyID.TabIndex = 57;
            this.lcpnyID.Text = "0";
            this.lcpnyID.Visible = false;
            // 
            // lFax
            // 
            this.lFax.BackColor = System.Drawing.Color.AliceBlue;
            this.lFax.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lFax.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lFax.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lFax.Image = ((System.Drawing.Image)(resources.GetObject("lFax.Image")));
            this.lFax.Location = new System.Drawing.Point(400, 68);
            this.lFax.Name = "lFax";
            this.lFax.Size = new System.Drawing.Size(392, 20);
            this.lFax.TabIndex = 48;
            this.lFax.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lPhone
            // 
            this.lPhone.BackColor = System.Drawing.Color.AliceBlue;
            this.lPhone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lPhone.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lPhone.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lPhone.Location = new System.Drawing.Point(400, 109);
            this.lPhone.Name = "lPhone";
            this.lPhone.Size = new System.Drawing.Size(248, 16);
            this.lPhone.TabIndex = 47;
            this.lPhone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lPhone.Click += new System.EventHandler(this.lPhone_Click);
            // 
            // lAdrs
            // 
            this.lAdrs.BackColor = System.Drawing.Color.AliceBlue;
            this.lAdrs.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lAdrs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lAdrs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lAdrs.Location = new System.Drawing.Point(400, 37);
            this.lAdrs.Name = "lAdrs";
            this.lAdrs.Size = new System.Drawing.Size(392, 31);
            this.lAdrs.TabIndex = 46;
            this.lAdrs.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label41
            // 
            this.label41.BackColor = System.Drawing.SystemColors.Control;
            this.label41.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label41.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label41.Location = new System.Drawing.Point(355, 70);
            this.label41.Name = "label41";
            this.label41.Size = new System.Drawing.Size(45, 16);
            this.label41.TabIndex = 45;
            this.label41.Text = "Fax:";
            this.label41.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.SystemColors.Control;
            this.label36.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label36.Location = new System.Drawing.Point(336, 44);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(64, 16);
            this.label36.TabIndex = 41;
            this.label36.Text = "Adress:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label39
            // 
            this.label39.BackColor = System.Drawing.SystemColors.Control;
            this.label39.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label39.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label39.Location = new System.Drawing.Point(27, 79);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(60, 16);
            this.label39.TabIndex = 39;
            this.label39.Text = "Language:";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.SystemColors.Control;
            this.label38.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label38.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label38.Location = new System.Drawing.Point(315, 90);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(85, 16);
            this.label38.TabIndex = 37;
            this.label38.Text = "Contact Name:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbEmploy
            // 
            this.cbEmploy.BackColor = System.Drawing.Color.Lavender;
            this.cbEmploy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmploy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbEmploy.Location = new System.Drawing.Point(88, 56);
            this.cbEmploy.Name = "cbEmploy";
            this.cbEmploy.Size = new System.Drawing.Size(208, 21);
            this.cbEmploy.TabIndex = 35;
            this.cbEmploy.SelectedIndexChanged += new System.EventHandler(this.cbEmploy_SelectedIndexChanged);
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.SystemColors.Control;
            this.label37.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label37.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label37.Location = new System.Drawing.Point(24, 58);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(64, 16);
            this.label37.TabIndex = 34;
            this.label37.Text = "Employee:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(13, 155);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(72, 16);
            this.label4.TabIndex = 27;
            this.label4.Text = "Quote Date:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(320, 18);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(80, 16);
            this.label6.TabIndex = 25;
            this.label6.Text = "Company Name:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(16, 34);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 24);
            this.label3.TabIndex = 19;
            this.label3.Text = "Quote #:";
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(15, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Project Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tProjNAME
            // 
            this.tProjNAME.BackColor = System.Drawing.Color.Lavender;
            this.tProjNAME.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tProjNAME.Location = new System.Drawing.Point(88, 16);
            this.tProjNAME.MaxLength = 49;
            this.tProjNAME.Name = "tProjNAME";
            this.tProjNAME.Size = new System.Drawing.Size(208, 20);
            this.tProjNAME.TabIndex = 16;
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.SystemColors.Control;
            this.label40.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label40.Location = new System.Drawing.Point(352, 109);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(48, 16);
            this.label40.TabIndex = 43;
            this.label40.Text = "Phone:";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tQuoteID
            // 
            this.tQuoteID.BackColor = System.Drawing.SystemColors.Control;
            this.tQuoteID.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tQuoteID.ForeColor = System.Drawing.Color.Red;
            this.tQuoteID.Location = new System.Drawing.Point(88, 36);
            this.tQuoteID.MaxLength = 8;
            this.tQuoteID.Name = "tQuoteID";
            this.tQuoteID.ReadOnly = true;
            this.tQuoteID.Size = new System.Drawing.Size(136, 26);
            this.tQuoteID.TabIndex = 24;
            this.tQuoteID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tQuoteID.TextChanged += new System.EventHandler(this.tQuoteID_TextChanged);
            // 
            // gifCounter
            // 
            this.gifCounter.BackColor = System.Drawing.Color.Transparent;
            this.gifCounter.Cursor = System.Windows.Forms.Cursors.Hand;
            this.gifCounter.Image = ((System.Drawing.Image)(resources.GetObject("gifCounter.Image")));
            this.gifCounter.Location = new System.Drawing.Point(88, 36);
            this.gifCounter.Name = "gifCounter";
            this.gifCounter.Size = new System.Drawing.Size(136, 20);
            this.gifCounter.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gifCounter.TabIndex = 86;
            this.gifCounter.TabStop = false;
            this.gifCounter.Visible = false;
            // 
            // cbCompany
            // 
            this.cbCompany.BackColor = System.Drawing.Color.Lavender;
            this.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompany.ForeColor = System.Drawing.Color.OrangeRed;
            this.cbCompany.Location = new System.Drawing.Point(400, 16);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(256, 21);
            this.cbCompany.TabIndex = 31;
            this.cbCompany.SelectedIndexChanged += new System.EventHandler(this.cbCompany_SelectedIndexChanged);
            // 
            // lCpnyName
            // 
            this.lCpnyName.BackColor = System.Drawing.SystemColors.Control;
            this.lCpnyName.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lCpnyName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lCpnyName.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCpnyName.ForeColor = System.Drawing.Color.OrangeRed;
            this.lCpnyName.Location = new System.Drawing.Point(400, 16);
            this.lCpnyName.Name = "lCpnyName";
            this.lCpnyName.Size = new System.Drawing.Size(256, 21);
            this.lCpnyName.TabIndex = 88;
            this.lCpnyName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lCpnyName.Click += new System.EventHandler(this.lCpnyName_Click);
            // 
            // cbLang
            // 
            this.cbLang.BackColor = System.Drawing.Color.Lavender;
            this.cbLang.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLang.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbLang.Items.AddRange(new object[] {
            "French",
            "English",
            "Billingual"});
            this.cbLang.Location = new System.Drawing.Point(88, 77);
            this.cbLang.Name = "cbLang";
            this.cbLang.Size = new System.Drawing.Size(112, 21);
            this.cbLang.TabIndex = 38;
            this.cbLang.SelectedIndexChanged += new System.EventHandler(this.cbLang_SelectedIndexChanged);
            // 
            // Lang
            // 
            this.Lang.BackColor = System.Drawing.SystemColors.Control;
            this.Lang.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Lang.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.Lang.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Lang.ForeColor = System.Drawing.Color.OrangeRed;
            this.Lang.Location = new System.Drawing.Point(88, 77);
            this.Lang.Name = "Lang";
            this.Lang.Size = new System.Drawing.Size(96, 20);
            this.Lang.TabIndex = 98;
            this.Lang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Lang.Visible = false;
            this.Lang.Click += new System.EventHandler(this.Lang_Click);
            // 
            // lQDopen
            // 
            this.lQDopen.BackColor = System.Drawing.SystemColors.Control;
            this.lQDopen.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lQDopen.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lQDopen.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lQDopen.ForeColor = System.Drawing.Color.OrangeRed;
            this.lQDopen.Location = new System.Drawing.Point(88, 153);
            this.lQDopen.Name = "lQDopen";
            this.lQDopen.Size = new System.Drawing.Size(88, 20);
            this.lQDopen.TabIndex = 97;
            this.lQDopen.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lQDopen.Click += new System.EventHandler(this.lQDopen_Click);
            // 
            // tOpendate
            // 
            this.tOpendate.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.tOpendate.CalendarTitleBackColor = System.Drawing.Color.Lavender;
            this.tOpendate.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.tOpendate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tOpendate.Location = new System.Drawing.Point(88, 153);
            this.tOpendate.Name = "tOpendate";
            this.tOpendate.Size = new System.Drawing.Size(88, 20);
            this.tOpendate.TabIndex = 32;
            this.tOpendate.ValueChanged += new System.EventHandler(this.tOpendate_ValueChanged);
            // 
            // cbCPmgr
            // 
            this.cbCPmgr.BackColor = System.Drawing.Color.Lavender;
            this.cbCPmgr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCPmgr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCPmgr.Location = new System.Drawing.Point(400, 125);
            this.cbCPmgr.Name = "cbCPmgr";
            this.cbCPmgr.Size = new System.Drawing.Size(248, 21);
            this.cbCPmgr.TabIndex = 99;
            this.cbCPmgr.SelectedIndexChanged += new System.EventHandler(this.cbCPmgr_SelectedIndexChanged);
            // 
            // lcbCPmgr
            // 
            this.lcbCPmgr.BackColor = System.Drawing.Color.AliceBlue;
            this.lcbCPmgr.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lcbCPmgr.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lcbCPmgr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcbCPmgr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lcbCPmgr.Location = new System.Drawing.Point(400, 126);
            this.lcbCPmgr.Name = "lcbCPmgr";
            this.lcbCPmgr.Size = new System.Drawing.Size(248, 21);
            this.lcbCPmgr.TabIndex = 160;
            this.lcbCPmgr.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lcbCPmgr.Visible = false;
            // 
            // cbContacts
            // 
            this.cbContacts.BackColor = System.Drawing.Color.Lavender;
            this.cbContacts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContacts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbContacts.Location = new System.Drawing.Point(400, 88);
            this.cbContacts.Name = "cbContacts";
            this.cbContacts.Size = new System.Drawing.Size(248, 21);
            this.cbContacts.TabIndex = 36;
            this.cbContacts.SelectedIndexChanged += new System.EventHandler(this.cbContacts_SelectedIndexChanged);
            // 
            // lContacts
            // 
            this.lContacts.BackColor = System.Drawing.Color.AliceBlue;
            this.lContacts.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lContacts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lContacts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lContacts.ForeColor = System.Drawing.Color.OrangeRed;
            this.lContacts.Location = new System.Drawing.Point(400, 89);
            this.lContacts.Name = "lContacts";
            this.lContacts.Size = new System.Drawing.Size(248, 21);
            this.lContacts.TabIndex = 95;
            this.lContacts.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lContacts.Visible = false;
            // 
            // cbprinters
            // 
            this.cbprinters.BackColor = System.Drawing.Color.Lavender;
            this.cbprinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbprinters.ForeColor = System.Drawing.Color.ForestGreen;
            this.cbprinters.Location = new System.Drawing.Point(297, 466);
            this.cbprinters.Name = "cbprinters";
            this.cbprinters.Size = new System.Drawing.Size(256, 21);
            this.cbprinters.TabIndex = 165;
            this.cbprinters.Visible = false;
            this.cbprinters.SelectedIndexChanged += new System.EventHandler(this.cbprinters_SelectedIndexChanged);
            // 
            // Revisions
            // 
            this.Revisions.Controls.Add(this.groupBox5);
            this.Revisions.Controls.Add(this.gbxSol);
            this.Revisions.Location = new System.Drawing.Point(4, 22);
            this.Revisions.Name = "Revisions";
            this.Revisions.Size = new System.Drawing.Size(607, 502);
            this.Revisions.TabIndex = 3;
            this.Revisions.Text = "Revisions";
            this.Revisions.Visible = false;
            // 
            // groupBox5
            // 
            this.groupBox5.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox5.Controls.Add(this.lALSTOT);
            this.groupBox5.Controls.Add(this.lAuP);
            this.groupBox5.Controls.Add(this.chk_savOVRG);
            this.groupBox5.Controls.Add(this.label64);
            this.groupBox5.Controls.Add(this.lRevTOT);
            this.groupBox5.Controls.Add(this.picbadRevSta);
            this.groupBox5.Controls.Add(this.pictureBox10);
            this.groupBox5.Controls.Add(this.printALS);
            this.groupBox5.Controls.Add(this.AlterTOT);
            this.groupBox5.Controls.Add(this.AlsTOT_orig);
            this.groupBox5.Controls.Add(this.lAlterTOT);
            this.groupBox5.Controls.Add(this.tAGprice);
            this.groupBox5.Controls.Add(this.label63);
            this.groupBox5.Controls.Add(this.tPxPrice);
            this.groupBox5.Controls.Add(this.label62);
            this.groupBox5.Controls.Add(this.AlsTOT);
            this.groupBox5.Controls.Add(this.label59);
            this.groupBox5.Controls.Add(this.tALSnb);
            this.groupBox5.Controls.Add(this.lcurrALSLID);
            this.groupBox5.Controls.Add(this.OldAlsTot);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox5.Location = new System.Drawing.Point(0, 433);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(607, 69);
            this.groupBox5.TabIndex = 66;
            this.groupBox5.TabStop = false;
            // 
            // lALSTOT
            // 
            this.lALSTOT.BackColor = System.Drawing.SystemColors.Control;
            this.lALSTOT.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lALSTOT.ForeColor = System.Drawing.Color.DarkRed;
            this.lALSTOT.Location = new System.Drawing.Point(8, 8);
            this.lALSTOT.Name = "lALSTOT";
            this.lALSTOT.Size = new System.Drawing.Size(208, 20);
            this.lALSTOT.TabIndex = 97;
            this.lALSTOT.Text = "System ST:";
            this.lALSTOT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lAuP
            // 
            this.lAuP.BackColor = System.Drawing.SystemColors.Control;
            this.lAuP.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.lAuP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lAuP.Location = new System.Drawing.Point(56, 28);
            this.lAuP.Name = "lAuP";
            this.lAuP.Size = new System.Drawing.Size(160, 20);
            this.lAuP.TabIndex = 107;
            this.lAuP.Text = "Sale ST:";
            this.lAuP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chk_savOVRG
            // 
            this.chk_savOVRG.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_savOVRG.Location = new System.Drawing.Point(60, 48);
            this.chk_savOVRG.Name = "chk_savOVRG";
            this.chk_savOVRG.Size = new System.Drawing.Size(110, 15);
            this.chk_savOVRG.TabIndex = 215;
            this.chk_savOVRG.Text = "Save OVERAGE";
            this.chk_savOVRG.UseVisualStyleBackColor = true;
            // 
            // label64
            // 
            this.label64.BackColor = System.Drawing.SystemColors.Control;
            this.label64.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label64.ForeColor = System.Drawing.Color.DarkRed;
            this.label64.Location = new System.Drawing.Point(765, 34);
            this.label64.Name = "label64";
            this.label64.Size = new System.Drawing.Size(69, 20);
            this.label64.TabIndex = 214;
            this.label64.Text = "Rev.";
            this.label64.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lRevTOT
            // 
            this.lRevTOT.BackColor = System.Drawing.Color.PapayaWhip;
            this.lRevTOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lRevTOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lRevTOT.ForeColor = System.Drawing.Color.Black;
            this.lRevTOT.Location = new System.Drawing.Point(837, 33);
            this.lRevTOT.Name = "lRevTOT";
            this.lRevTOT.Size = new System.Drawing.Size(136, 23);
            this.lRevTOT.TabIndex = 213;
            this.lRevTOT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picbadRevSta
            // 
            this.picbadRevSta.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picbadRevSta.Image = ((System.Drawing.Image)(resources.GetObject("picbadRevSta.Image")));
            this.picbadRevSta.Location = new System.Drawing.Point(734, 19);
            this.picbadRevSta.Name = "picbadRevSta";
            this.picbadRevSta.Size = new System.Drawing.Size(25, 26);
            this.picbadRevSta.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picbadRevSta.TabIndex = 212;
            this.picbadRevSta.TabStop = false;
            this.picbadRevSta.Visible = false;
            this.picbadRevSta.Click += new System.EventHandler(this.picbadRevSta_Click);
            // 
            // pictureBox10
            // 
            this.pictureBox10.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox10.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox10.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox10.Image")));
            this.pictureBox10.Location = new System.Drawing.Point(381, 8);
            this.pictureBox10.Name = "pictureBox10";
            this.pictureBox10.Size = new System.Drawing.Size(26, 21);
            this.pictureBox10.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox10.TabIndex = 187;
            this.pictureBox10.TabStop = false;
            this.pictureBox10.Visible = false;
            this.pictureBox10.Click += new System.EventHandler(this.pictureBox10_Click);
            // 
            // printALS
            // 
            this.printALS.AccessibleDescription = "Cut Serial#";
            this.printALS.BackColor = System.Drawing.Color.Transparent;
            this.printALS.Cursor = System.Windows.Forms.Cursors.Hand;
            this.printALS.Image = ((System.Drawing.Image)(resources.GetObject("printALS.Image")));
            this.printALS.Location = new System.Drawing.Point(6, 28);
            this.printALS.Name = "printALS";
            this.printALS.Size = new System.Drawing.Size(32, 23);
            this.printALS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.printALS.TabIndex = 180;
            this.printALS.TabStop = false;
            this.printALS.Visible = false;
            this.printALS.Click += new System.EventHandler(this.printALS_Click);
            // 
            // AlterTOT
            // 
            this.AlterTOT.BackColor = System.Drawing.Color.PapayaWhip;
            this.AlterTOT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.AlterTOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlterTOT.ForeColor = System.Drawing.Color.Black;
            this.AlterTOT.Location = new System.Drawing.Point(837, 10);
            this.AlterTOT.Multiline = true;
            this.AlterTOT.Name = "AlterTOT";
            this.AlterTOT.ReadOnly = true;
            this.AlterTOT.Size = new System.Drawing.Size(136, 23);
            this.AlterTOT.TabIndex = 98;
            this.AlterTOT.Text = "0";
            this.AlterTOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // AlsTOT_orig
            // 
            this.AlsTOT_orig.BackColor = System.Drawing.SystemColors.Control;
            this.AlsTOT_orig.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlsTOT_orig.ForeColor = System.Drawing.Color.Blue;
            this.AlsTOT_orig.Location = new System.Drawing.Point(216, 10);
            this.AlsTOT_orig.Multiline = true;
            this.AlsTOT_orig.Name = "AlsTOT_orig";
            this.AlsTOT_orig.ReadOnly = true;
            this.AlsTOT_orig.Size = new System.Drawing.Size(128, 23);
            this.AlsTOT_orig.TabIndex = 96;
            this.AlsTOT_orig.Text = "0";
            this.AlsTOT_orig.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AlsTOT_orig.TextChanged += new System.EventHandler(this.AlsTOT_orig_TextChanged);
            // 
            // lAlterTOT
            // 
            this.lAlterTOT.BackColor = System.Drawing.SystemColors.Control;
            this.lAlterTOT.Font = new System.Drawing.Font("Arial Black", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAlterTOT.ForeColor = System.Drawing.Color.DarkRed;
            this.lAlterTOT.Location = new System.Drawing.Point(765, 11);
            this.lAlterTOT.Name = "lAlterTOT";
            this.lAlterTOT.Size = new System.Drawing.Size(69, 20);
            this.lAlterTOT.TabIndex = 99;
            this.lAlterTOT.Text = "Alter.";
            this.lAlterTOT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lAlterTOT.Click += new System.EventHandler(this.lAlterTOT_Click);
            // 
            // tAGprice
            // 
            this.tAGprice.BackColor = System.Drawing.Color.Lavender;
            this.tAGprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAGprice.ForeColor = System.Drawing.Color.Blue;
            this.tAGprice.Location = new System.Drawing.Point(600, 10);
            this.tAGprice.Multiline = true;
            this.tAGprice.Name = "tAGprice";
            this.tAGprice.Size = new System.Drawing.Size(128, 23);
            this.tAGprice.TabIndex = 186;
            this.tAGprice.Text = "0";
            this.tAGprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tAGprice.TextChanged += new System.EventHandler(this.tAGprice_TextChanged);
            this.tAGprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tAGprice_KeyPress);
            // 
            // label63
            // 
            this.label63.BackColor = System.Drawing.SystemColors.Control;
            this.label63.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label63.ForeColor = System.Drawing.Color.Blue;
            this.label63.Location = new System.Drawing.Point(512, 11);
            this.label63.Name = "label63";
            this.label63.Size = new System.Drawing.Size(88, 20);
            this.label63.TabIndex = 185;
            this.label63.Text = "Agency ST:";
            this.label63.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tPxPrice
            // 
            this.tPxPrice.BackColor = System.Drawing.SystemColors.Control;
            this.tPxPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPxPrice.ForeColor = System.Drawing.Color.Blue;
            this.tPxPrice.Location = new System.Drawing.Point(600, 33);
            this.tPxPrice.Multiline = true;
            this.tPxPrice.Name = "tPxPrice";
            this.tPxPrice.ReadOnly = true;
            this.tPxPrice.Size = new System.Drawing.Size(128, 23);
            this.tPxPrice.TabIndex = 184;
            this.tPxPrice.Text = "0";
            this.tPxPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tPxPrice.TextChanged += new System.EventHandler(this.tPxPrice_TextChanged);
            this.tPxPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tPxPrice_KeyPress);
            // 
            // label62
            // 
            this.label62.BackColor = System.Drawing.SystemColors.Control;
            this.label62.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label62.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label62.Location = new System.Drawing.Point(512, 34);
            this.label62.Name = "label62";
            this.label62.Size = new System.Drawing.Size(88, 20);
            this.label62.TabIndex = 183;
            this.label62.Text = "Primax ST:";
            this.label62.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // AlsTOT
            // 
            this.AlsTOT.BackColor = System.Drawing.Color.Lavender;
            this.AlsTOT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AlsTOT.ForeColor = System.Drawing.Color.Blue;
            this.AlsTOT.Location = new System.Drawing.Point(216, 33);
            this.AlsTOT.Multiline = true;
            this.AlsTOT.Name = "AlsTOT";
            this.AlsTOT.Size = new System.Drawing.Size(128, 23);
            this.AlsTOT.TabIndex = 108;
            this.AlsTOT.Text = "0";
            this.AlsTOT.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AlsTOT.TextChanged += new System.EventHandler(this.AlsTOT_TextChanged);
            this.AlsTOT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.AlsTOT_KeyPress);
            // 
            // label59
            // 
            this.label59.BackColor = System.Drawing.SystemColors.Control;
            this.label59.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.label59.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label59.Location = new System.Drawing.Point(360, 34);
            this.label59.Name = "label59";
            this.label59.Size = new System.Drawing.Size(96, 20);
            this.label59.TabIndex = 109;
            this.label59.Text = "System Qty:";
            this.label59.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tALSnb
            // 
            this.tALSnb.BackColor = System.Drawing.Color.Lavender;
            this.tALSnb.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tALSnb.ForeColor = System.Drawing.Color.DarkRed;
            this.tALSnb.Location = new System.Drawing.Point(456, 32);
            this.tALSnb.MaxLength = 3;
            this.tALSnb.Name = "tALSnb";
            this.tALSnb.Size = new System.Drawing.Size(48, 24);
            this.tALSnb.TabIndex = 106;
            this.tALSnb.Text = "1";
            this.tALSnb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tALSnb.TextChanged += new System.EventHandler(this.tALSnb_TextChanged);
            // 
            // lcurrALSLID
            // 
            this.lcurrALSLID.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lcurrALSLID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lcurrALSLID.Location = new System.Drawing.Point(320, 48);
            this.lcurrALSLID.Name = "lcurrALSLID";
            this.lcurrALSLID.Size = new System.Drawing.Size(32, 16);
            this.lcurrALSLID.TabIndex = 104;
            this.lcurrALSLID.Visible = false;
            // 
            // OldAlsTot
            // 
            this.OldAlsTot.BackColor = System.Drawing.Color.Yellow;
            this.OldAlsTot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OldAlsTot.Location = new System.Drawing.Point(184, 48);
            this.OldAlsTot.Name = "OldAlsTot";
            this.OldAlsTot.Size = new System.Drawing.Size(144, 16);
            this.OldAlsTot.TabIndex = 103;
            this.OldAlsTot.Visible = false;
            // 
            // gbxSol
            // 
            this.gbxSol.Controls.Add(this.grpChng);
            this.gbxSol.Controls.Add(this.grpAmodif);
            this.gbxSol.Controls.Add(this.grpPB);
            this.gbxSol.Controls.Add(this.splitter1);
            this.gbxSol.Controls.Add(this.g5);
            this.gbxSol.Controls.Add(this.grpOrder);
            this.gbxSol.Controls.Add(this.grpPBs);
            this.gbxSol.Controls.Add(this.btnM);
            this.gbxSol.Controls.Add(this.lvQITEMS);
            this.gbxSol.Controls.Add(this.tvSol);
            this.gbxSol.Dock = System.Windows.Forms.DockStyle.Top;
            this.gbxSol.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.gbxSol.Location = new System.Drawing.Point(0, 0);
            this.gbxSol.Name = "gbxSol";
            this.gbxSol.Size = new System.Drawing.Size(607, 411);
            this.gbxSol.TabIndex = 21;
            this.gbxSol.TabStop = false;
            this.gbxSol.Enter += new System.EventHandler(this.gbxSol_Enter_1);
            // 
            // grpChng
            // 
            this.grpChng.BackColor = System.Drawing.Color.PaleGreen;
            this.grpChng.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpChng.Controls.Add(this.label84);
            this.grpChng.Controls.Add(this.tAGExt);
            this.grpChng.Controls.Add(this.label83);
            this.grpChng.Controls.Add(this.label77);
            this.grpChng.Controls.Add(this.tSaleExt);
            this.grpChng.Controls.Add(this.CB_Group);
            this.grpChng.Controls.Add(this.label65);
            this.grpChng.Controls.Add(this.button10);
            this.grpChng.Controls.Add(this.chkApply);
            this.grpChng.Controls.Add(this.tTV);
            this.grpChng.Controls.Add(this.lALSmAmnt);
            this.grpChng.Controls.Add(this.label61);
            this.grpChng.Controls.Add(this.TOALS);
            this.grpChng.Controls.Add(this.label51);
            this.grpChng.Controls.Add(this.MaxLT);
            this.grpChng.Controls.Add(this.minLT);
            this.grpChng.Controls.Add(this.ChngCancel);
            this.grpChng.Controls.Add(this.btnOKchng);
            this.grpChng.Controls.Add(this.label43);
            this.grpChng.Controls.Add(this.label48);
            this.grpChng.Controls.Add(this.tExt);
            this.grpChng.Controls.Add(this.label42);
            this.grpChng.Controls.Add(this.tUprice);
            this.grpChng.Controls.Add(this.label29);
            this.grpChng.Controls.Add(this.tmult);
            this.grpChng.Controls.Add(this.label58);
            this.grpChng.Controls.Add(this.chkTBP);
            this.grpChng.Controls.Add(this.lnb);
            this.grpChng.Controls.Add(this.tNB);
            this.grpChng.Controls.Add(this.label44);
            this.grpChng.Controls.Add(this.tdesc);
            this.grpChng.Controls.Add(this.label28);
            this.grpChng.Controls.Add(this.tqty);
            this.grpChng.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpChng.ForeColor = System.Drawing.Color.Blue;
            this.grpChng.Location = new System.Drawing.Point(363, 40);
            this.grpChng.Name = "grpChng";
            this.grpChng.Size = new System.Drawing.Size(541, 322);
            this.grpChng.TabIndex = 104;
            this.grpChng.Visible = false;
            // 
            // label84
            // 
            this.label84.BackColor = System.Drawing.Color.Yellow;
            this.label84.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.ForeColor = System.Drawing.Color.Black;
            this.label84.Location = new System.Drawing.Point(3, 157);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(344, 17);
            this.label84.TabIndex = 336;
            this.label84.Text = "Extensions:";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tAGExt
            // 
            this.tAGExt.BackColor = System.Drawing.Color.Lavender;
            this.tAGExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAGExt.ForeColor = System.Drawing.Color.DarkRed;
            this.tAGExt.Location = new System.Drawing.Point(237, 194);
            this.tAGExt.Name = "tAGExt";
            this.tAGExt.ReadOnly = true;
            this.tAGExt.Size = new System.Drawing.Size(110, 24);
            this.tAGExt.TabIndex = 335;
            this.tAGExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label83
            // 
            this.label83.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label83.ForeColor = System.Drawing.Color.Maroon;
            this.label83.Location = new System.Drawing.Point(237, 178);
            this.label83.Name = "label83";
            this.label83.Size = new System.Drawing.Size(110, 17);
            this.label83.TabIndex = 334;
            this.label83.Text = "Agencies";
            this.label83.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label77
            // 
            this.label77.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label77.ForeColor = System.Drawing.Color.Maroon;
            this.label77.Location = new System.Drawing.Point(130, 177);
            this.label77.Name = "label77";
            this.label77.Size = new System.Drawing.Size(91, 17);
            this.label77.TabIndex = 333;
            this.label77.Text = "Sales";
            this.label77.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tSaleExt
            // 
            this.tSaleExt.BackColor = System.Drawing.Color.Lavender;
            this.tSaleExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSaleExt.ForeColor = System.Drawing.Color.DarkRed;
            this.tSaleExt.Location = new System.Drawing.Point(127, 194);
            this.tSaleExt.Name = "tSaleExt";
            this.tSaleExt.ReadOnly = true;
            this.tSaleExt.Size = new System.Drawing.Size(110, 24);
            this.tSaleExt.TabIndex = 332;
            this.tSaleExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // CB_Group
            // 
            this.CB_Group.BackColor = System.Drawing.Color.Lavender;
            this.CB_Group.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Group.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CB_Group.Items.AddRange(new object[] {
            "A",
            "B",
            "C",
            "D"});
            this.CB_Group.Location = new System.Drawing.Point(285, 100);
            this.CB_Group.Name = "CB_Group";
            this.CB_Group.Size = new System.Drawing.Size(64, 23);
            this.CB_Group.TabIndex = 331;
            // 
            // label65
            // 
            this.label65.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label65.Location = new System.Drawing.Point(196, 104);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(89, 15);
            this.label65.TabIndex = 156;
            this.label65.Text = "Item Group:";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.SystemColors.Control;
            this.button10.Dock = System.Windows.Forms.DockStyle.Top;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.ForeColor = System.Drawing.Color.Black;
            this.button10.Location = new System.Drawing.Point(0, 0);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(539, 30);
            this.button10.TabIndex = 154;
            this.button10.Text = "Item Details";
            this.button10.UseVisualStyleBackColor = false;
            // 
            // chkApply
            // 
            this.chkApply.Font = new System.Drawing.Font("Times New Roman", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkApply.ForeColor = System.Drawing.Color.Black;
            this.chkApply.Location = new System.Drawing.Point(198, 129);
            this.chkApply.Name = "chkApply";
            this.chkApply.Size = new System.Drawing.Size(182, 21);
            this.chkApply.TabIndex = 151;
            this.chkApply.Text = "Apply on global alias ";
            this.chkApply.Visible = false;
            // 
            // tTV
            // 
            this.tTV.BackColor = System.Drawing.Color.White;
            this.tTV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tTV.ForeColor = System.Drawing.Color.DarkGreen;
            this.tTV.Location = new System.Drawing.Point(8, 296);
            this.tTV.Name = "tTV";
            this.tTV.ReadOnly = true;
            this.tTV.Size = new System.Drawing.Size(525, 21);
            this.tTV.TabIndex = 150;
            this.tTV.Visible = false;
            // 
            // lALSmAmnt
            // 
            this.lALSmAmnt.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lALSmAmnt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lALSmAmnt.Location = new System.Drawing.Point(470, 171);
            this.lALSmAmnt.Name = "lALSmAmnt";
            this.lALSmAmnt.Size = new System.Drawing.Size(15, 16);
            this.lALSmAmnt.TabIndex = 149;
            this.lALSmAmnt.Visible = false;
            // 
            // label61
            // 
            this.label61.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label61.ForeColor = System.Drawing.Color.Black;
            this.label61.Location = new System.Drawing.Point(219, 270);
            this.label61.Name = "label61";
            this.label61.Size = new System.Drawing.Size(163, 24);
            this.label61.TabIndex = 148;
            this.label61.Text = "System Total:";
            this.label61.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TOALS
            // 
            this.TOALS.BackColor = System.Drawing.Color.AliceBlue;
            this.TOALS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TOALS.ForeColor = System.Drawing.Color.DarkBlue;
            this.TOALS.Location = new System.Drawing.Point(385, 270);
            this.TOALS.Name = "TOALS";
            this.TOALS.ReadOnly = true;
            this.TOALS.Size = new System.Drawing.Size(148, 24);
            this.TOALS.TabIndex = 147;
            // 
            // label51
            // 
            this.label51.BackColor = System.Drawing.Color.PaleGreen;
            this.label51.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label51.ForeColor = System.Drawing.Color.Blue;
            this.label51.Location = new System.Drawing.Point(312, 76);
            this.label51.Name = "label51";
            this.label51.Size = new System.Drawing.Size(10, 24);
            this.label51.TabIndex = 146;
            this.label51.Text = "---";
            this.label51.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MaxLT
            // 
            this.MaxLT.BackColor = System.Drawing.Color.Lavender;
            this.MaxLT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaxLT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MaxLT.Location = new System.Drawing.Point(322, 76);
            this.MaxLT.Name = "MaxLT";
            this.MaxLT.Size = new System.Drawing.Size(27, 24);
            this.MaxLT.TabIndex = 145;
            this.MaxLT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // minLT
            // 
            this.minLT.BackColor = System.Drawing.Color.Lavender;
            this.minLT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.minLT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.minLT.Location = new System.Drawing.Point(285, 76);
            this.minLT.Name = "minLT";
            this.minLT.Size = new System.Drawing.Size(27, 24);
            this.minLT.TabIndex = 144;
            this.minLT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.minLT.TextChanged += new System.EventHandler(this.minLT_TextChanged);
            // 
            // ChngCancel
            // 
            this.ChngCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ChngCancel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ChngCancel.Location = new System.Drawing.Point(409, 129);
            this.ChngCancel.Name = "ChngCancel";
            this.ChngCancel.Size = new System.Drawing.Size(118, 24);
            this.ChngCancel.TabIndex = 143;
            this.ChngCancel.Text = "&Cancel";
            this.ChngCancel.Click += new System.EventHandler(this.ChngCancel_Click);
            // 
            // btnOKchng
            // 
            this.btnOKchng.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOKchng.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOKchng.Location = new System.Drawing.Point(408, 94);
            this.btnOKchng.Name = "btnOKchng";
            this.btnOKchng.Size = new System.Drawing.Size(118, 24);
            this.btnOKchng.TabIndex = 142;
            this.btnOKchng.Text = "&Save";
            this.btnOKchng.Click += new System.EventHandler(this.btnOKchng_Click);
            // 
            // label43
            // 
            this.label43.BackColor = System.Drawing.Color.PaleGreen;
            this.label43.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label43.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label43.Location = new System.Drawing.Point(212, 80);
            this.label43.Name = "label43";
            this.label43.Size = new System.Drawing.Size(73, 17);
            this.label43.TabIndex = 139;
            this.label43.Text = "Lead Time:";
            this.label43.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label48
            // 
            this.label48.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label48.Location = new System.Drawing.Point(8, 177);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(119, 17);
            this.label48.TabIndex = 141;
            this.label48.Text = "System";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tExt
            // 
            this.tExt.BackColor = System.Drawing.Color.Lavender;
            this.tExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tExt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tExt.Location = new System.Drawing.Point(17, 194);
            this.tExt.Name = "tExt";
            this.tExt.ReadOnly = true;
            this.tExt.Size = new System.Drawing.Size(110, 24);
            this.tExt.TabIndex = 140;
            this.tExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tExt.TextChanged += new System.EventHandler(this.tExt_TextChanged);
            this.tExt.DoubleClick += new System.EventHandler(this.tExt_DoubleClick);
            // 
            // label42
            // 
            this.label42.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label42.Location = new System.Drawing.Point(3, 80);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(82, 17);
            this.label42.TabIndex = 138;
            this.label42.Text = "Unit Price:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tUprice
            // 
            this.tUprice.BackColor = System.Drawing.Color.Lavender;
            this.tUprice.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tUprice.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tUprice.Location = new System.Drawing.Point(85, 76);
            this.tUprice.Name = "tUprice";
            this.tUprice.Size = new System.Drawing.Size(110, 24);
            this.tUprice.TabIndex = 136;
            this.tUprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tUprice.TextChanged += new System.EventHandler(this.tUprice_TextChanged);
            this.tUprice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tUprice_KeyPress);
            // 
            // label29
            // 
            this.label29.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label29.Location = new System.Drawing.Point(20, 128);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(65, 17);
            this.label29.TabIndex = 137;
            this.label29.Text = "Multiplier:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmult
            // 
            this.tmult.BackColor = System.Drawing.Color.Lavender;
            this.tmult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmult.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tmult.Location = new System.Drawing.Point(85, 124);
            this.tmult.Name = "tmult";
            this.tmult.Size = new System.Drawing.Size(110, 24);
            this.tmult.TabIndex = 135;
            this.tmult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tmult.TextChanged += new System.EventHandler(this.tmult_TextChanged);
            // 
            // label58
            // 
            this.label58.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label58.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label58.Location = new System.Drawing.Point(232, 33);
            this.label58.Name = "label58";
            this.label58.Size = new System.Drawing.Size(32, 15);
            this.label58.TabIndex = 134;
            this.label58.Text = "Print";
            this.label58.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label58.Visible = false;
            // 
            // chkTBP
            // 
            this.chkTBP.Checked = true;
            this.chkTBP.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTBP.Location = new System.Drawing.Point(217, 34);
            this.chkTBP.Name = "chkTBP";
            this.chkTBP.Size = new System.Drawing.Size(16, 16);
            this.chkTBP.TabIndex = 133;
            this.chkTBP.Visible = false;
            // 
            // lnb
            // 
            this.lnb.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lnb.Location = new System.Drawing.Point(30, 36);
            this.lnb.Name = "lnb";
            this.lnb.Size = new System.Drawing.Size(55, 15);
            this.lnb.TabIndex = 132;
            this.lnb.Text = "Item #:";
            this.lnb.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tNB
            // 
            this.tNB.BackColor = System.Drawing.Color.Lavender;
            this.tNB.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tNB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tNB.Location = new System.Drawing.Point(85, 31);
            this.tNB.Name = "tNB";
            this.tNB.Size = new System.Drawing.Size(32, 24);
            this.tNB.TabIndex = 131;
            // 
            // label44
            // 
            this.label44.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label44.Location = new System.Drawing.Point(3, 58);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(82, 14);
            this.label44.TabIndex = 130;
            this.label44.Text = "Description:";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tdesc
            // 
            this.tdesc.BackColor = System.Drawing.Color.Lavender;
            this.tdesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tdesc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tdesc.Location = new System.Drawing.Point(85, 55);
            this.tdesc.Name = "tdesc";
            this.tdesc.Size = new System.Drawing.Size(449, 21);
            this.tdesc.TabIndex = 129;
            // 
            // label28
            // 
            this.label28.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label28.Location = new System.Drawing.Point(53, 105);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(32, 15);
            this.label28.TabIndex = 128;
            this.label28.Text = "Qty:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tqty
            // 
            this.tqty.BackColor = System.Drawing.Color.Lavender;
            this.tqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tqty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tqty.Location = new System.Drawing.Point(85, 100);
            this.tqty.Name = "tqty";
            this.tqty.Size = new System.Drawing.Size(110, 24);
            this.tqty.TabIndex = 127;
            this.tqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tqty.TextChanged += new System.EventHandler(this.tqty_TextChanged);
            // 
            // grpAmodif
            // 
            this.grpAmodif.BackColor = System.Drawing.Color.Tan;
            this.grpAmodif.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.grpAmodif.Controls.Add(this.button9);
            this.grpAmodif.Controls.Add(this.lALT);
            this.grpAmodif.Controls.Add(this.label66);
            this.grpAmodif.Controls.Add(this.tAMaxLT);
            this.grpAmodif.Controls.Add(this.tAminLT);
            this.grpAmodif.Controls.Add(this.btnAcancel);
            this.grpAmodif.Controls.Add(this.btnAsave);
            this.grpAmodif.Controls.Add(this.label67);
            this.grpAmodif.Controls.Add(this.label69);
            this.grpAmodif.Controls.Add(this.tAup);
            this.grpAmodif.Controls.Add(this.label70);
            this.grpAmodif.Controls.Add(this.tAmult);
            this.grpAmodif.Controls.Add(this.label73);
            this.grpAmodif.Controls.Add(this.tAqty);
            this.grpAmodif.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpAmodif.ForeColor = System.Drawing.Color.Blue;
            this.grpAmodif.Location = new System.Drawing.Point(255, 130);
            this.grpAmodif.Name = "grpAmodif";
            this.grpAmodif.Size = new System.Drawing.Size(370, 135);
            this.grpAmodif.TabIndex = 105;
            this.grpAmodif.Visible = false;
            // 
            // button9
            // 
            this.button9.BackColor = System.Drawing.Color.Blue;
            this.button9.Dock = System.Windows.Forms.DockStyle.Top;
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.White;
            this.button9.Location = new System.Drawing.Point(0, 0);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(366, 24);
            this.button9.TabIndex = 153;
            this.button9.Text = "Alias Modify";
            this.button9.UseVisualStyleBackColor = false;
            // 
            // lALT
            // 
            this.lALT.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lALT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lALT.Location = new System.Drawing.Point(368, 24);
            this.lALT.Name = "lALT";
            this.lALT.Size = new System.Drawing.Size(15, 16);
            this.lALT.TabIndex = 152;
            this.lALT.Visible = false;
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.Color.Tan;
            this.label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label66.Location = new System.Drawing.Point(99, 116);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(8, 17);
            this.label66.TabIndex = 146;
            this.label66.Text = "-";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label66.Visible = false;
            // 
            // tAMaxLT
            // 
            this.tAMaxLT.BackColor = System.Drawing.Color.Lavender;
            this.tAMaxLT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAMaxLT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tAMaxLT.Location = new System.Drawing.Point(107, 112);
            this.tAMaxLT.Name = "tAMaxLT";
            this.tAMaxLT.Size = new System.Drawing.Size(27, 24);
            this.tAMaxLT.TabIndex = 145;
            this.tAMaxLT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tAMaxLT.Visible = false;
            // 
            // tAminLT
            // 
            this.tAminLT.BackColor = System.Drawing.Color.Lavender;
            this.tAminLT.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAminLT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tAminLT.Location = new System.Drawing.Point(72, 112);
            this.tAminLT.Name = "tAminLT";
            this.tAminLT.Size = new System.Drawing.Size(27, 24);
            this.tAminLT.TabIndex = 144;
            this.tAminLT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tAminLT.Visible = false;
            // 
            // btnAcancel
            // 
            this.btnAcancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAcancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAcancel.Location = new System.Drawing.Point(208, 104);
            this.btnAcancel.Name = "btnAcancel";
            this.btnAcancel.Size = new System.Drawing.Size(152, 24);
            this.btnAcancel.TabIndex = 143;
            this.btnAcancel.Text = "Cancel";
            this.btnAcancel.Click += new System.EventHandler(this.btnAcancel_Click);
            // 
            // btnAsave
            // 
            this.btnAsave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAsave.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAsave.Location = new System.Drawing.Point(208, 72);
            this.btnAsave.Name = "btnAsave";
            this.btnAsave.Size = new System.Drawing.Size(152, 24);
            this.btnAsave.TabIndex = 142;
            this.btnAsave.Text = "Apply";
            this.btnAsave.Click += new System.EventHandler(this.btnAsave_Click);
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.Color.Tan;
            this.label67.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label67.ForeColor = System.Drawing.Color.Black;
            this.label67.Location = new System.Drawing.Point(0, 116);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(72, 17);
            this.label67.TabIndex = 139;
            this.label67.Text = "Lead Time";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label67.Visible = false;
            // 
            // label69
            // 
            this.label69.BackColor = System.Drawing.Color.Tan;
            this.label69.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label69.ForeColor = System.Drawing.Color.Black;
            this.label69.Location = new System.Drawing.Point(8, 68);
            this.label69.Name = "label69";
            this.label69.Size = new System.Drawing.Size(64, 17);
            this.label69.TabIndex = 138;
            this.label69.Text = "Unit Price:";
            this.label69.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tAup
            // 
            this.tAup.BackColor = System.Drawing.Color.Lavender;
            this.tAup.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAup.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tAup.Location = new System.Drawing.Point(72, 64);
            this.tAup.Name = "tAup";
            this.tAup.Size = new System.Drawing.Size(104, 24);
            this.tAup.TabIndex = 136;
            this.tAup.Text = "n/a";
            this.tAup.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label70
            // 
            this.label70.BackColor = System.Drawing.Color.Tan;
            this.label70.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label70.ForeColor = System.Drawing.Color.Black;
            this.label70.Location = new System.Drawing.Point(7, 92);
            this.label70.Name = "label70";
            this.label70.Size = new System.Drawing.Size(65, 17);
            this.label70.TabIndex = 137;
            this.label70.Text = "Multiplier:";
            this.label70.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tAmult
            // 
            this.tAmult.BackColor = System.Drawing.Color.Lavender;
            this.tAmult.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAmult.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tAmult.Location = new System.Drawing.Point(72, 88);
            this.tAmult.Name = "tAmult";
            this.tAmult.Size = new System.Drawing.Size(104, 24);
            this.tAmult.TabIndex = 135;
            this.tAmult.Text = "n/a";
            this.tAmult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label73
            // 
            this.label73.BackColor = System.Drawing.Color.Tan;
            this.label73.Font = new System.Drawing.Font("Times New Roman", 9.75F, System.Drawing.FontStyle.Bold);
            this.label73.ForeColor = System.Drawing.Color.Black;
            this.label73.Location = new System.Drawing.Point(40, 45);
            this.label73.Name = "label73";
            this.label73.Size = new System.Drawing.Size(32, 15);
            this.label73.TabIndex = 128;
            this.label73.Text = "Qty";
            this.label73.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tAqty
            // 
            this.tAqty.BackColor = System.Drawing.Color.Lavender;
            this.tAqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tAqty.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tAqty.Location = new System.Drawing.Point(72, 40);
            this.tAqty.Name = "tAqty";
            this.tAqty.Size = new System.Drawing.Size(104, 24);
            this.tAqty.TabIndex = 127;
            this.tAqty.Text = "n/a";
            this.tAqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // grpPB
            // 
            this.grpPB.BackColor = System.Drawing.Color.DarkKhaki;
            this.grpPB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grpPB.Controls.Add(this.button6);
            this.grpPB.Controls.Add(this.button5);
            this.grpPB.Controls.Add(this.lblWait);
            this.grpPB.Controls.Add(this.pbPrintQt);
            this.grpPB.Location = new System.Drawing.Point(230, 86);
            this.grpPB.Name = "grpPB";
            this.grpPB.Size = new System.Drawing.Size(669, 104);
            this.grpPB.TabIndex = 103;
            this.grpPB.Visible = false;
            // 
            // button6
            // 
            this.button6.BackColor = System.Drawing.Color.Lavender;
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button6.ForeColor = System.Drawing.Color.Black;
            this.button6.Location = new System.Drawing.Point(230, 70);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(123, 25);
            this.button6.TabIndex = 7;
            this.button6.Text = "Open Word File";
            this.button6.UseVisualStyleBackColor = false;
            this.button6.Visible = false;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.BackColor = System.Drawing.Color.Lavender;
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(363, 69);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(120, 25);
            this.button5.TabIndex = 6;
            this.button5.Text = "Close";
            this.button5.UseVisualStyleBackColor = false;
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // lblWait
            // 
            this.lblWait.Font = new System.Drawing.Font("Monotype Corsiva", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))));
            this.lblWait.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblWait.Location = new System.Drawing.Point(13, 15);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(646, 19);
            this.lblWait.TabIndex = 5;
            this.lblWait.Text = "Please Wait,   exporting Quote to Word ...";
            this.lblWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbPrintQt
            // 
            this.pbPrintQt.Location = new System.Drawing.Point(7, 36);
            this.pbPrintQt.Maximum = 1000;
            this.pbPrintQt.Name = "pbPrintQt";
            this.pbPrintQt.Size = new System.Drawing.Size(653, 26);
            this.pbPrintQt.TabIndex = 4;
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(223, 16);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(5, 392);
            this.splitter1.TabIndex = 106;
            this.splitter1.TabStop = false;
            this.splitter1.Visible = false;
            // 
            // g5
            // 
            this.g5.Controls.Add(this.lcurrImg);
            this.g5.Controls.Add(this.lCurr_opera);
            this.g5.Controls.Add(this.lALSSave);
            this.g5.Controls.Add(this.lQsave);
            this.g5.Controls.Add(this.lCurALSNDX);
            this.g5.Controls.Add(this.lCurSPCNDX);
            this.g5.Controls.Add(this.lCurrPATH);
            this.g5.Controls.Add(this.lMLTPLYwwww);
            this.g5.Controls.Add(this.lCurrNAME);
            this.g5.Controls.Add(this.lCurSPCn);
            this.g5.Controls.Add(this.lTVSel);
            this.g5.Location = new System.Drawing.Point(904, 21);
            this.g5.Name = "g5";
            this.g5.Size = new System.Drawing.Size(85, 234);
            this.g5.TabIndex = 12;
            this.g5.TabStop = false;
            this.g5.Visible = false;
            // 
            // lcurrImg
            // 
            this.lcurrImg.BackColor = System.Drawing.SystemColors.Info;
            this.lcurrImg.Location = new System.Drawing.Point(38, 202);
            this.lcurrImg.Name = "lcurrImg";
            this.lcurrImg.Size = new System.Drawing.Size(15, 24);
            this.lcurrImg.TabIndex = 75;
            // 
            // lCurr_opera
            // 
            this.lCurr_opera.BackColor = System.Drawing.SystemColors.Info;
            this.lCurr_opera.Location = new System.Drawing.Point(5, 199);
            this.lCurr_opera.Name = "lCurr_opera";
            this.lCurr_opera.Size = new System.Drawing.Size(15, 24);
            this.lCurr_opera.TabIndex = 74;
            // 
            // lALSSave
            // 
            this.lALSSave.BackColor = System.Drawing.SystemColors.Info;
            this.lALSSave.Location = new System.Drawing.Point(55, 172);
            this.lALSSave.Name = "lALSSave";
            this.lALSSave.Size = new System.Drawing.Size(15, 24);
            this.lALSSave.TabIndex = 73;
            this.lALSSave.Text = "N";
            // 
            // lQsave
            // 
            this.lQsave.BackColor = System.Drawing.SystemColors.Info;
            this.lQsave.Location = new System.Drawing.Point(34, 172);
            this.lQsave.Name = "lQsave";
            this.lQsave.Size = new System.Drawing.Size(15, 24);
            this.lQsave.TabIndex = 72;
            this.lQsave.Text = "N";
            // 
            // lCurALSNDX
            // 
            this.lCurALSNDX.BackColor = System.Drawing.SystemColors.Info;
            this.lCurALSNDX.Location = new System.Drawing.Point(84, 67);
            this.lCurALSNDX.Name = "lCurALSNDX";
            this.lCurALSNDX.Size = new System.Drawing.Size(16, 16);
            this.lCurALSNDX.TabIndex = 71;
            this.lCurALSNDX.Text = "0";
            // 
            // lCurSPCNDX
            // 
            this.lCurSPCNDX.BackColor = System.Drawing.SystemColors.Info;
            this.lCurSPCNDX.Location = new System.Drawing.Point(82, 49);
            this.lCurSPCNDX.Name = "lCurSPCNDX";
            this.lCurSPCNDX.Size = new System.Drawing.Size(16, 16);
            this.lCurSPCNDX.TabIndex = 70;
            this.lCurSPCNDX.Text = "0";
            // 
            // lCurrPATH
            // 
            this.lCurrPATH.BackColor = System.Drawing.SystemColors.Info;
            this.lCurrPATH.Location = new System.Drawing.Point(9, 93);
            this.lCurrPATH.Name = "lCurrPATH";
            this.lCurrPATH.Size = new System.Drawing.Size(20, 16);
            this.lCurrPATH.TabIndex = 68;
            // 
            // lMLTPLYwwww
            // 
            this.lMLTPLYwwww.BackColor = System.Drawing.SystemColors.Info;
            this.lMLTPLYwwww.Location = new System.Drawing.Point(11, 134);
            this.lMLTPLYwwww.Name = "lMLTPLYwwww";
            this.lMLTPLYwwww.Size = new System.Drawing.Size(26, 16);
            this.lMLTPLYwwww.TabIndex = 67;
            this.lMLTPLYwwww.Text = "1.87";
            // 
            // lCurrNAME
            // 
            this.lCurrNAME.BackColor = System.Drawing.SystemColors.Info;
            this.lCurrNAME.Location = new System.Drawing.Point(9, 111);
            this.lCurrNAME.Name = "lCurrNAME";
            this.lCurrNAME.Size = new System.Drawing.Size(20, 16);
            this.lCurrNAME.TabIndex = 65;
            // 
            // lCurSPCn
            // 
            this.lCurSPCn.BackColor = System.Drawing.SystemColors.Info;
            this.lCurSPCn.Location = new System.Drawing.Point(6, 49);
            this.lCurSPCn.Name = "lCurSPCn";
            this.lCurSPCn.Size = new System.Drawing.Size(71, 16);
            this.lCurSPCn.TabIndex = 64;
            // 
            // lTVSel
            // 
            this.lTVSel.BackColor = System.Drawing.SystemColors.Info;
            this.lTVSel.Location = new System.Drawing.Point(6, 170);
            this.lTVSel.Name = "lTVSel";
            this.lTVSel.Size = new System.Drawing.Size(15, 24);
            this.lTVSel.TabIndex = 61;
            this.lTVSel.Text = "N";
            // 
            // grpOrder
            // 
            this.grpOrder.Controls.Add(this.groupBox7);
            this.grpOrder.Controls.Add(this.lvOrder);
            this.grpOrder.Location = new System.Drawing.Point(588, 0);
            this.grpOrder.Name = "grpOrder";
            this.grpOrder.Size = new System.Drawing.Size(305, 414);
            this.grpOrder.TabIndex = 102;
            this.grpOrder.TabStop = false;
            this.grpOrder.Visible = false;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.pictureBox11);
            this.groupBox7.Controls.Add(this.lRSoln);
            this.groupBox7.Controls.Add(this.lRimgNdx);
            this.groupBox7.Controls.Add(this.btnDel);
            this.groupBox7.Controls.Add(this.btnsSaveOrd);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox7.Location = new System.Drawing.Point(3, 368);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(299, 40);
            this.groupBox7.TabIndex = 111;
            this.groupBox7.TabStop = false;
            // 
            // pictureBox11
            // 
            this.pictureBox11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
            this.pictureBox11.Location = new System.Drawing.Point(249, 8);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(44, 25);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 213;
            this.pictureBox11.TabStop = false;
            // 
            // lRSoln
            // 
            this.lRSoln.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lRSoln.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lRSoln.Location = new System.Drawing.Point(142, 12);
            this.lRSoln.Name = "lRSoln";
            this.lRSoln.Size = new System.Drawing.Size(15, 16);
            this.lRSoln.TabIndex = 122;
            this.lRSoln.Visible = false;
            // 
            // lRimgNdx
            // 
            this.lRimgNdx.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lRimgNdx.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lRimgNdx.Location = new System.Drawing.Point(120, 8);
            this.lRimgNdx.Name = "lRimgNdx";
            this.lRimgNdx.Size = new System.Drawing.Size(15, 16);
            this.lRimgNdx.TabIndex = 121;
            this.lRimgNdx.Visible = false;
            // 
            // btnDel
            // 
            this.btnDel.BackColor = System.Drawing.SystemColors.Control;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Location = new System.Drawing.Point(8, 8);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(57, 24);
            this.btnDel.TabIndex = 120;
            this.btnDel.Text = "Delete";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnsSaveOrd
            // 
            this.btnsSaveOrd.BackColor = System.Drawing.SystemColors.Control;
            this.btnsSaveOrd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnsSaveOrd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsSaveOrd.Location = new System.Drawing.Point(71, 8);
            this.btnsSaveOrd.Name = "btnsSaveOrd";
            this.btnsSaveOrd.Size = new System.Drawing.Size(172, 24);
            this.btnsSaveOrd.TabIndex = 116;
            this.btnsSaveOrd.Text = "Save && Continue Converting";
            this.btnsSaveOrd.UseVisualStyleBackColor = false;
            this.btnsSaveOrd.Click += new System.EventHandler(this.btnsSaveOrd_Click);
            // 
            // lvOrder
            // 
            this.lvOrder.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvOrder.AutoArrange = false;
            this.lvOrder.BackColor = System.Drawing.Color.DarkKhaki;
            this.lvOrder.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.orderline,
            this.sol,
            this.spc,
            this.Als,
            this.Detail_LID,
            this.lvndx,
            this.AA,
            this.Extt});
            this.lvOrder.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvOrder.ForeColor = System.Drawing.Color.Blue;
            this.lvOrder.FullRowSelect = true;
            this.lvOrder.GridLines = true;
            this.lvOrder.HideSelection = false;
            this.lvOrder.Location = new System.Drawing.Point(3, 16);
            this.lvOrder.Name = "lvOrder";
            this.lvOrder.Size = new System.Drawing.Size(299, 352);
            this.lvOrder.TabIndex = 110;
            this.lvOrder.UseCompatibleStateImageBehavior = false;
            this.lvOrder.View = System.Windows.Forms.View.Details;
            this.lvOrder.SelectedIndexChanged += new System.EventHandler(this.lvOrder_SelectedIndexChanged);
            // 
            // orderline
            // 
            this.orderline.Text = "Ordered";
            this.orderline.Width = 267;
            // 
            // sol
            // 
            this.sol.Text = "";
            this.sol.Width = 0;
            // 
            // spc
            // 
            this.spc.Text = "";
            this.spc.Width = 0;
            // 
            // Als
            // 
            this.Als.Text = "";
            this.Als.Width = 0;
            // 
            // Detail_LID
            // 
            this.Detail_LID.Text = "";
            this.Detail_LID.Width = 0;
            // 
            // lvndx
            // 
            this.lvndx.Text = "";
            this.lvndx.Width = 0;
            // 
            // AA
            // 
            this.AA.Text = "";
            this.AA.Width = 0;
            // 
            // Extt
            // 
            this.Extt.Text = "";
            this.Extt.Width = 0;
            // 
            // grpPBs
            // 
            this.grpPBs.BackColor = System.Drawing.Color.DarkKhaki;
            this.grpPBs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpPBs.Location = new System.Drawing.Point(252, 293);
            this.grpPBs.Name = "grpPBs";
            this.grpPBs.Size = new System.Drawing.Size(86, 54);
            this.grpPBs.TabIndex = 18;
            this.grpPBs.TabStop = false;
            this.grpPBs.Visible = false;
            // 
            // btnM
            // 
            this.btnM.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnM.Location = new System.Drawing.Point(3, 7);
            this.btnM.Name = "btnM";
            this.btnM.Size = new System.Drawing.Size(18, 10);
            this.btnM.TabIndex = 17;
            this.btnM.Text = "-";
            this.btnM.Visible = false;
            this.btnM.Click += new System.EventHandler(this.btnM_Click);
            // 
            // lvQITEMS
            // 
            this.lvQITEMS.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvQITEMS.AutoArrange = false;
            this.lvQITEMS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvQITEMS.CheckBoxes = true;
            this.lvQITEMS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.order,
            this.lineNB,
            this.DESC,
            this.Qty,
            this.Multpl,
            this.Uprice,
            this.itmGrp,
            this.Ext,
            this.LTime,
            this.nbdef,
            this.PartNB,
            this.Det_LID,
            this.TecVal,
            this.S_Ext,
            this.A_Ext});
            this.lvQITEMS.ContextMenu = this.CMlvQitem;
            this.lvQITEMS.FullRowSelect = true;
            this.lvQITEMS.GridLines = true;
            this.lvQITEMS.HideSelection = false;
            this.lvQITEMS.Location = new System.Drawing.Point(226, 18);
            this.lvQITEMS.Name = "lvQITEMS";
            this.lvQITEMS.Size = new System.Drawing.Size(357, 394);
            this.lvQITEMS.TabIndex = 16;
            this.lvQITEMS.UseCompatibleStateImageBehavior = false;
            this.lvQITEMS.View = System.Windows.Forms.View.Details;
            this.lvQITEMS.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvQITEMS_ColumnClick);
            this.lvQITEMS.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvQITEMS_ItemCheck);
            this.lvQITEMS.SelectedIndexChanged += new System.EventHandler(this.lvQITEMS_SelectedIndexChanged);
            this.lvQITEMS.DoubleClick += new System.EventHandler(this.lvQITEMS_DoubleClick);
            // 
            // order
            // 
            this.order.Text = "Print";
            this.order.Width = 0;
            // 
            // lineNB
            // 
            this.lineNB.Text = " #";
            this.lineNB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lineNB.Width = 55;
            // 
            // DESC
            // 
            this.DESC.Text = "Item";
            this.DESC.Width = 170;
            // 
            // Qty
            // 
            this.Qty.Text = "Qty";
            this.Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Multpl
            // 
            this.Multpl.Text = "Multiplier";
            this.Multpl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Multpl.Width = 55;
            // 
            // Uprice
            // 
            this.Uprice.Text = "Unit Price";
            this.Uprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Uprice.Width = 67;
            // 
            // itmGrp
            // 
            this.itmGrp.Text = "Group";
            this.itmGrp.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Ext
            // 
            this.Ext.Text = "Extension";
            this.Ext.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Ext.Width = 93;
            // 
            // LTime
            // 
            this.LTime.Text = "Lead Time";
            this.LTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LTime.Width = 64;
            // 
            // nbdef
            // 
            this.nbdef.Text = "";
            this.nbdef.Width = 0;
            // 
            // PartNB
            // 
            this.PartNB.Text = "";
            this.PartNB.Width = 0;
            // 
            // Det_LID
            // 
            this.Det_LID.Text = "D";
            this.Det_LID.Width = 0;
            // 
            // TecVal
            // 
            this.TecVal.Text = "Tech Values";
            this.TecVal.Width = 0;
            // 
            // S_Ext
            // 
            this.S_Ext.Text = "Sale Extension";
            // 
            // A_Ext
            // 
            this.A_Ext.Text = "Agency Extension";
            // 
            // CMlvQitem
            // 
            this.CMlvQitem.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.MNoCut,
            this.mnOcopy,
            this.MNocopyTxt,
            this.menuItem15,
            this.MNoPaste,
            this.menuItem9,
            this.menuItem14,
            this.mnuModif});
            this.CMlvQitem.Popup += new System.EventHandler(this.CMlvQitem_Popup);
            // 
            // MNoCut
            // 
            this.MNoCut.Enabled = false;
            this.MNoCut.Index = 0;
            this.MNoCut.Text = "Cut";
            this.MNoCut.Click += new System.EventHandler(this.MNoCut_Click);
            // 
            // mnOcopy
            // 
            this.mnOcopy.Enabled = false;
            this.mnOcopy.Index = 1;
            this.mnOcopy.Text = "Copy";
            this.mnOcopy.Click += new System.EventHandler(this.mnOcopy_Click);
            // 
            // MNocopyTxt
            // 
            this.MNocopyTxt.Enabled = false;
            this.MNocopyTxt.Index = 2;
            this.MNocopyTxt.Text = "Copy as TEXT";
            this.MNocopyTxt.Click += new System.EventHandler(this.menuItem16_Click);
            // 
            // menuItem15
            // 
            this.menuItem15.Index = 3;
            this.menuItem15.Text = "-";
            // 
            // MNoPaste
            // 
            this.MNoPaste.Enabled = false;
            this.MNoPaste.Index = 4;
            this.MNoPaste.Text = "Paste Before";
            this.MNoPaste.Click += new System.EventHandler(this.MNoPaste_Click);
            // 
            // menuItem9
            // 
            this.menuItem9.Enabled = false;
            this.menuItem9.Index = 5;
            this.menuItem9.Text = "Paste After";
            this.menuItem9.Click += new System.EventHandler(this.menuItem9_Click);
            // 
            // menuItem14
            // 
            this.menuItem14.Index = 6;
            this.menuItem14.Text = "-";
            // 
            // mnuModif
            // 
            this.mnuModif.Index = 7;
            this.mnuModif.Text = "Modify";
            this.mnuModif.Click += new System.EventHandler(this.mnuModif_Click);
            // 
            // tvSol
            // 
            this.tvSol.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tvSol.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvSol.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvSol.ForeColor = System.Drawing.Color.DarkRed;
            this.tvSol.FullRowSelect = true;
            this.tvSol.ImageIndex = 0;
            this.tvSol.ImageList = this.imageList16;
            this.tvSol.LabelEdit = true;
            this.tvSol.Location = new System.Drawing.Point(3, 16);
            this.tvSol.Name = "tvSol";
            this.tvSol.SelectedImageIndex = 0;
            this.tvSol.Size = new System.Drawing.Size(220, 392);
            this.tvSol.TabIndex = 10;
            this.tvSol.BeforeLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvSol_BeforeLabelEdit);
            this.tvSol.AfterLabelEdit += new System.Windows.Forms.NodeLabelEditEventHandler(this.tvSol_AfterLabelEdit);
            this.tvSol.BeforeCheck += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvSol_BeforeCheck);
            this.tvSol.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvSol_AfterCheck);
            this.tvSol.BeforeSelect += new System.Windows.Forms.TreeViewCancelEventHandler(this.tvSol_BeforeSelect);
            this.tvSol.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvSol_AfterSelect);
            this.tvSol.Click += new System.EventHandler(this.tvSol_Click);
            this.tvSol.Leave += new System.EventHandler(this.tvSol_Leave);
            this.tvSol.Resize += new System.EventHandler(this.tvSol_Resize);
            // 
            // imageList16
            // 
            this.imageList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList16.ImageStream")));
            this.imageList16.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList16.Images.SetKeyName(0, "");
            this.imageList16.Images.SetKeyName(1, "");
            this.imageList16.Images.SetKeyName(2, "");
            this.imageList16.Images.SetKeyName(3, "");
            this.imageList16.Images.SetKeyName(4, "");
            this.imageList16.Images.SetKeyName(5, "");
            this.imageList16.Images.SetKeyName(6, "");
            this.imageList16.Images.SetKeyName(7, "");
            // 
            // grpChng1
            // 
            this.grpChng1.BackColor = System.Drawing.Color.DarkRed;
            this.grpChng1.Controls.Add(this.tLT);
            this.grpChng1.Controls.Add(this.label49);
            this.grpChng1.Controls.Add(this.label47);
            this.grpChng1.Controls.Add(this.tXchng);
            this.grpChng1.Controls.Add(this.tXRATE);
            this.grpChng1.Controls.Add(this.OldSpecTot);
            this.grpChng1.Controls.Add(this.pictureBox7);
            this.grpChng1.Location = new System.Drawing.Point(440, 616);
            this.grpChng1.Name = "grpChng1";
            this.grpChng1.Size = new System.Drawing.Size(504, 64);
            this.grpChng1.TabIndex = 105;
            this.grpChng1.TabStop = false;
            this.grpChng1.Visible = false;
            // 
            // tLT
            // 
            this.tLT.BackColor = System.Drawing.Color.CornflowerBlue;
            this.tLT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tLT.Location = new System.Drawing.Point(864, 16);
            this.tLT.Name = "tLT";
            this.tLT.Size = new System.Drawing.Size(15, 16);
            this.tLT.TabIndex = 123;
            this.tLT.Visible = false;
            // 
            // label49
            // 
            this.label49.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label49.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label49.Location = new System.Drawing.Point(856, 24);
            this.label49.Name = "label49";
            this.label49.Size = new System.Drawing.Size(16, 16);
            this.label49.TabIndex = 84;
            this.label49.Visible = false;
            // 
            // label47
            // 
            this.label47.Location = new System.Drawing.Point(904, 16);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(48, 17);
            this.label47.TabIndex = 31;
            this.label47.Text = "Xchng";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label47.Visible = false;
            // 
            // tXchng
            // 
            this.tXchng.BackColor = System.Drawing.Color.White;
            this.tXchng.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tXchng.ForeColor = System.Drawing.Color.Red;
            this.tXchng.Location = new System.Drawing.Point(896, 24);
            this.tXchng.Name = "tXchng";
            this.tXchng.ReadOnly = true;
            this.tXchng.Size = new System.Drawing.Size(56, 20);
            this.tXchng.TabIndex = 30;
            this.tXchng.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tXchng.Visible = false;
            this.tXchng.TextChanged += new System.EventHandler(this.tXchng_TextChanged);
            // 
            // tXRATE
            // 
            this.tXRATE.BackColor = System.Drawing.Color.Olive;
            this.tXRATE.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tXRATE.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tXRATE.ForeColor = System.Drawing.Color.White;
            this.tXRATE.Location = new System.Drawing.Point(248, 0);
            this.tXRATE.MaxLength = 5;
            this.tXRATE.Name = "tXRATE";
            this.tXRATE.Size = new System.Drawing.Size(16, 20);
            this.tXRATE.TabIndex = 100;
            this.tXRATE.Text = "1.00";
            this.tXRATE.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tXRATE.Visible = false;
            this.tXRATE.TextChanged += new System.EventHandler(this.tXRATE_TextChanged);
            // 
            // OldSpecTot
            // 
            this.OldSpecTot.BackColor = System.Drawing.Color.CornflowerBlue;
            this.OldSpecTot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.OldSpecTot.Location = new System.Drawing.Point(760, 16);
            this.OldSpecTot.Name = "OldSpecTot";
            this.OldSpecTot.Size = new System.Drawing.Size(32, 16);
            this.OldSpecTot.TabIndex = 102;
            this.OldSpecTot.Visible = false;
            // 
            // pictureBox7
            // 
            this.pictureBox7.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox7.Image")));
            this.pictureBox7.Location = new System.Drawing.Point(8, 23);
            this.pictureBox7.Name = "pictureBox7";
            this.pictureBox7.Size = new System.Drawing.Size(64, 18);
            this.pictureBox7.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox7.TabIndex = 23;
            this.pictureBox7.TabStop = false;
            // 
            // AffQNB
            // 
            this.AffQNB.BackColor = System.Drawing.SystemColors.Control;
            this.AffQNB.Font = new System.Drawing.Font("Courier New", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.AffQNB.ForeColor = System.Drawing.Color.Maroon;
            this.AffQNB.Location = new System.Drawing.Point(768, 8);
            this.AffQNB.MaxLength = 0;
            this.AffQNB.Name = "AffQNB";
            this.AffQNB.ReadOnly = true;
            this.AffQNB.Size = new System.Drawing.Size(136, 29);
            this.AffQNB.TabIndex = 41;
            this.AffQNB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lQNB
            // 
            this.lQNB.BackColor = System.Drawing.SystemColors.Control;
            this.lQNB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lQNB.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lQNB.ForeColor = System.Drawing.Color.Blue;
            this.lQNB.Location = new System.Drawing.Point(696, 10);
            this.lQNB.Name = "lQNB";
            this.lQNB.Size = new System.Drawing.Size(72, 24);
            this.lQNB.TabIndex = 42;
            this.lQNB.Text = "Quote #:";
            // 
            // tmrChng
            // 
            this.tmrChng.Interval = 120000;
            this.tmrChng.Tick += new System.EventHandler(this.tmrChng_Tick);
            // 
            // chkPrintALL
            // 
            this.chkPrintALL.Checked = true;
            this.chkPrintALL.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkPrintALL.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkPrintALL.Location = new System.Drawing.Point(368, 32);
            this.chkPrintALL.Name = "chkPrintALL";
            this.chkPrintALL.Size = new System.Drawing.Size(64, 16);
            this.chkPrintALL.TabIndex = 43;
            this.chkPrintALL.Text = "PRINT ALL LIST";
            this.chkPrintALL.Visible = false;
            this.chkPrintALL.CheckedChanged += new System.EventHandler(this.chkPrintALL_CheckedChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(912, 32);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(48, 24);
            this.button4.TabIndex = 44;
            this.button4.Text = "PRINT";
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.DarkSalmon;
            this.groupBox6.Controls.Add(this.lQID);
            this.groupBox6.Controls.Add(this.grpCmnt);
            this.groupBox6.Controls.Add(this.tDebQID);
            this.groupBox6.Controls.Add(this.button3);
            this.groupBox6.Controls.Add(this.btn2);
            this.groupBox6.Controls.Add(this.button1);
            this.groupBox6.Controls.Add(this.btnImpChrgPrices);
            this.groupBox6.Location = new System.Drawing.Point(16, 616);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(840, 120);
            this.groupBox6.TabIndex = 45;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "groupBox6";
            this.groupBox6.Visible = false;
            // 
            // lQID
            // 
            this.lQID.BackColor = System.Drawing.SystemColors.Control;
            this.lQID.ForeColor = System.Drawing.Color.Blue;
            this.lQID.Location = new System.Drawing.Point(272, 76);
            this.lQID.Name = "lQID";
            this.lQID.Size = new System.Drawing.Size(96, 24);
            this.lQID.TabIndex = 81;
            this.lQID.Text = "0";
            this.lQID.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpCmnt
            // 
            this.grpCmnt.Controls.Add(this.btnComnt);
            this.grpCmnt.Controls.Add(this.tComnt);
            this.grpCmnt.Controls.Add(this.lnkCmnt);
            this.grpCmnt.Controls.Add(this.lvComment);
            this.grpCmnt.Location = new System.Drawing.Point(408, 44);
            this.grpCmnt.Name = "grpCmnt";
            this.grpCmnt.Size = new System.Drawing.Size(432, 72);
            this.grpCmnt.TabIndex = 80;
            this.grpCmnt.TabStop = false;
            // 
            // btnComnt
            // 
            this.btnComnt.Image = ((System.Drawing.Image)(resources.GetObject("btnComnt.Image")));
            this.btnComnt.Location = new System.Drawing.Point(784, 8);
            this.btnComnt.Name = "btnComnt";
            this.btnComnt.Size = new System.Drawing.Size(40, 20);
            this.btnComnt.TabIndex = 56;
            this.btnComnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnComnt.Visible = false;
            // 
            // tComnt
            // 
            this.tComnt.Location = new System.Drawing.Point(80, 8);
            this.tComnt.Multiline = true;
            this.tComnt.Name = "tComnt";
            this.tComnt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tComnt.Size = new System.Drawing.Size(704, 20);
            this.tComnt.TabIndex = 55;
            this.tComnt.Visible = false;
            // 
            // lnkCmnt
            // 
            this.lnkCmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCmnt.Location = new System.Drawing.Point(16, 8);
            this.lnkCmnt.Name = "lnkCmnt";
            this.lnkCmnt.Size = new System.Drawing.Size(64, 16);
            this.lnkCmnt.TabIndex = 54;
            this.lnkCmnt.TabStop = true;
            this.lnkCmnt.Text = "Comments:";
            this.lnkCmnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lnkCmnt.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // lvComment
            // 
            this.lvComment.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvComment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.lvComment.GridLines = true;
            this.lvComment.HideSelection = false;
            this.lvComment.Location = new System.Drawing.Point(8, 32);
            this.lvComment.Name = "lvComment";
            this.lvComment.Size = new System.Drawing.Size(816, 72);
            this.lvComment.TabIndex = 51;
            this.lvComment.UseCompatibleStateImageBehavior = false;
            this.lvComment.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Date";
            this.columnHeader1.Width = 72;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "User";
            this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader2.Width = 80;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "Comments";
            this.columnHeader3.Width = 645;
            // 
            // tDebQID
            // 
            this.tDebQID.BackColor = System.Drawing.Color.MistyRose;
            this.tDebQID.Location = new System.Drawing.Point(136, 76);
            this.tDebQID.Name = "tDebQID";
            this.tDebQID.Size = new System.Drawing.Size(136, 20);
            this.tDebQID.TabIndex = 79;
            this.tDebQID.Text = "12345678";
            this.tDebQID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(16, 64);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 24);
            this.button3.TabIndex = 78;
            this.button3.Text = "fill PSM_Q_GenID";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btn2
            // 
            this.btn2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn2.Location = new System.Drawing.Point(144, 108);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(134, 24);
            this.btn2.TabIndex = 77;
            this.btn2.Text = "Fill Big files";
            this.btn2.Click += new System.EventHandler(this.btn2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(168, 44);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 24);
            this.button1.TabIndex = 76;
            this.button1.Text = "Choose Chargers";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnImpChrgPrices
            // 
            this.btnImpChrgPrices.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnImpChrgPrices.Location = new System.Drawing.Point(16, 24);
            this.btnImpChrgPrices.Name = "btnImpChrgPrices";
            this.btnImpChrgPrices.Size = new System.Drawing.Size(136, 24);
            this.btnImpChrgPrices.TabIndex = 75;
            this.btnImpChrgPrices.Text = "Chargers Prices";
            this.btnImpChrgPrices.Click += new System.EventHandler(this.btnImpChrgPrices_Click);
            // 
            // btnApply
            // 
            this.btnApply.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnApply.ForeColor = System.Drawing.Color.Red;
            this.btnApply.Location = new System.Drawing.Point(640, 32);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(96, 20);
            this.btnApply.TabIndex = 102;
            this.btnApply.Text = "ALS duplication";
            this.btnApply.Visible = false;
            // 
            // lcurDol
            // 
            this.lcurDol.BackColor = System.Drawing.SystemColors.Control;
            this.lcurDol.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lcurDol.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcurDol.ForeColor = System.Drawing.Color.DarkGreen;
            this.lcurDol.Location = new System.Drawing.Point(792, 37);
            this.lcurDol.Name = "lcurDol";
            this.lcurDol.Size = new System.Drawing.Size(112, 24);
            this.lcurDol.TabIndex = 103;
            this.lcurDol.Text = "CAD";
            this.lcurDol.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // printDialog1
            // 
            this.printDialog1.Document = this.printDocument1;
            // 
            // lCurALSn
            // 
            this.lCurALSn.BackColor = System.Drawing.SystemColors.Info;
            this.lCurALSn.Location = new System.Drawing.Point(288, 24);
            this.lCurALSn.Name = "lCurALSn";
            this.lCurALSn.Size = new System.Drawing.Size(24, 16);
            this.lCurALSn.TabIndex = 105;
            this.lCurALSn.Visible = false;
            this.lCurALSn.Click += new System.EventHandler(this.lCurALSn_Click);
            // 
            // lCurSoln
            // 
            this.lCurSoln.BackColor = System.Drawing.SystemColors.Info;
            this.lCurSoln.Location = new System.Drawing.Point(568, 8);
            this.lCurSoln.Name = "lCurSoln";
            this.lCurSoln.Size = new System.Drawing.Size(88, 16);
            this.lCurSoln.TabIndex = 106;
            this.lCurSoln.Visible = false;
            // 
            // lCurSolNDX
            // 
            this.lCurSolNDX.BackColor = System.Drawing.SystemColors.Info;
            this.lCurSolNDX.Location = new System.Drawing.Point(544, 32);
            this.lCurSolNDX.Name = "lCurSolNDX";
            this.lCurSolNDX.Size = new System.Drawing.Size(40, 16);
            this.lCurSolNDX.TabIndex = 103;
            this.lCurSolNDX.Text = "0";
            this.lCurSolNDX.Visible = false;
            // 
            // lcurSol_Status
            // 
            this.lcurSol_Status.BackColor = System.Drawing.SystemColors.Info;
            this.lcurSol_Status.Location = new System.Drawing.Point(424, 40);
            this.lcurSol_Status.Name = "lcurSol_Status";
            this.lcurSol_Status.Size = new System.Drawing.Size(32, 16);
            this.lcurSol_Status.TabIndex = 107;
            this.lcurSol_Status.Text = "N";
            this.lcurSol_Status.Visible = false;
            // 
            // lOFName
            // 
            this.lOFName.BackColor = System.Drawing.SystemColors.Info;
            this.lOFName.Location = new System.Drawing.Point(256, 32);
            this.lOFName.Name = "lOFName";
            this.lOFName.Size = new System.Drawing.Size(24, 16);
            this.lOFName.TabIndex = 199;
            this.lOFName.Visible = false;
            this.lOFName.Click += new System.EventHandler(this.lOFName_Click);
            // 
            // lCancel
            // 
            this.lCancel.BackColor = System.Drawing.SystemColors.Control;
            this.lCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCancel.ForeColor = System.Drawing.Color.Red;
            this.lCancel.Location = new System.Drawing.Point(496, 16);
            this.lCancel.Name = "lCancel";
            this.lCancel.Size = new System.Drawing.Size(184, 40);
            this.lCancel.TabIndex = 200;
            this.lCancel.Text = "NORMAL";
            this.lCancel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lCancel.Visible = false;
            // 
            // Fst_IL32
            // 
            this.Fst_IL32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Fst_IL32.ImageStream")));
            this.Fst_IL32.TransparentColor = System.Drawing.Color.Transparent;
            this.Fst_IL32.Images.SetKeyName(0, "");
            this.Fst_IL32.Images.SetKeyName(1, "");
            this.Fst_IL32.Images.SetKeyName(2, "");
            this.Fst_IL32.Images.SetKeyName(3, "");
            this.Fst_IL32.Images.SetKeyName(4, "");
            this.Fst_IL32.Images.SetKeyName(5, "");
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.Image = ((System.Drawing.Image)(resources.GetObject("picExit.Image")));
            this.picExit.Location = new System.Drawing.Point(952, 8);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(40, 40);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 198;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // picEng
            // 
            this.picEng.BackColor = System.Drawing.SystemColors.Control;
            this.picEng.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.picEng.Image = ((System.Drawing.Image)(resources.GetObject("picEng.Image")));
            this.picEng.Location = new System.Drawing.Point(768, 41);
            this.picEng.Name = "picEng";
            this.picEng.Size = new System.Drawing.Size(24, 16);
            this.picEng.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEng.TabIndex = 98;
            this.picEng.TabStop = false;
            // 
            // picFr
            // 
            this.picFr.BackColor = System.Drawing.Color.Transparent;
            this.picFr.Cursor = System.Windows.Forms.Cursors.Default;
            this.picFr.Image = ((System.Drawing.Image)(resources.GetObject("picFr.Image")));
            this.picFr.Location = new System.Drawing.Point(768, 41);
            this.picFr.Name = "picFr";
            this.picFr.Size = new System.Drawing.Size(24, 16);
            this.picFr.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFr.TabIndex = 99;
            this.picFr.TabStop = false;
            this.picFr.Visible = false;
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(892, 4);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(48, 44);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 264;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // Quote_NEW
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(990, 608);
            this.Controls.Add(this.picCIP);
            this.Controls.Add(this.grpChng1);
            this.Controls.Add(this.lCancel);
            this.Controls.Add(this.lOFName);
            this.Controls.Add(this.lQNB);
            this.Controls.Add(this.AffQNB);
            this.Controls.Add(this.picExit);
            this.Controls.Add(this.lcurSol_Status);
            this.Controls.Add(this.lCurSolNDX);
            this.Controls.Add(this.lCurSoln);
            this.Controls.Add(this.lCurALSn);
            this.Controls.Add(this.lcurDol);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.groupBox6);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.chkPrintALL);
            this.Controls.Add(this.gbxTabs);
            this.Controls.Add(this.picEng);
            this.Controls.Add(this.picFr);
            this.Controls.Add(this.toolBar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Quote_NEW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "QUOTE";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.Quote_Closing);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Quote_FormClosing);
            this.Load += new System.EventHandler(this.Quote_Load);
            this.Resize += new System.EventHandler(this.Quote_Resize);
            this.gbxTabs.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.TGen.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox13)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.groupBox8.ResumeLayout(false);
            this.groupBox8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox9)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox8)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox12)).EndInit();
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printLabel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).EndInit();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gifCounter)).EndInit();
            this.Revisions.ResumeLayout(false);
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picbadRevSta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox10)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.printALS)).EndInit();
            this.gbxSol.ResumeLayout(false);
            this.grpChng.ResumeLayout(false);
            this.grpChng.PerformLayout();
            this.grpAmodif.ResumeLayout(false);
            this.grpAmodif.PerformLayout();
            this.grpPB.ResumeLayout(false);
            this.g5.ResumeLayout(false);
            this.grpOrder.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.grpChng1.ResumeLayout(false);
            this.grpChng1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox7)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.grpCmnt.ResumeLayout(false);
            this.grpCmnt.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEng)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picFr)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void Quote_Load(object sender, System.EventArgs e)
		{
		    //Tosave = false;
		    //in_opera = x_opera;
		    //if (x_opera != '*')
		    //{
		        //init_Qte();
		        //Quote_Resize(sender, e);
		    //}
			Quote_Resize(sender, e);
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
			if (in_opera == 'C') tabControl1.SelectedIndex = 1;
			MNoPaste.Enabled = (MainMDI.arr_clpB[0, 1] != "~");
			menuItem9.Enabled = MNoPaste.Enabled;

            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
            //sdfasdadad//insert piccip and above statement
            //ajouter les prix des new prices line sans code dans xl de sam
		}

		private void init_arr_Tech_values()
		{
			for (int i = 0; i < MainMDI.MAX_Quote_lines; i++) arr_Tech_values[i] = "";
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
	        button1_Click_1(sender, e);
		}

		public void init_Qte()
		{
			in_opera = x_opera;
			if (x_QID == 0)
			{
				//init_Curr_ALS();
				//if (fill_QID() == 0 || fill_QID() == -1) this.Close();
				//else lCurr_opera.Text = "N";
				btnNewID.Visible = true;
				cbCompany.Enabled = true;
				lCpnyName.Visible = false;
				tQuoteID.Focus();
			}
			else	
			{
				if (in_opera == 'C')
				{
					tvSol.CheckBoxes = true;
					groupBox8.Enabled = false;
					groupBox4.Enabled = false;
					groupBox3.Enabled = false;
					groupBox5.Visible = false;
					grpChng.Visible = false;
					lvQITEMS.Columns[0].Text = "Order";
					lvQITEMS.Columns[0].Width = 39;
					lvQITEMS.Columns[2].Width = lvQITEMS.Columns[2].Width - 39;
					toolBar1.Visible = false;
					grpOrder.Visible = true;
				}
				else
				{
					tvSol.CheckBoxes = false;
					groupBox8.Enabled = true;
					groupBox4.Enabled = true;
					groupBox3.Enabled = true;
					groupBox5.Visible = true;
				    //grpChng.Visible = true;
					lvQITEMS.Columns[0].Text = "Order";
					lvQITEMS.Columns[0].Width = 0;
					lvQITEMS.Columns[2].Width = lvQITEMS.Columns[2].Width + 39;
					toolBar1.Visible = true;
					grpOrder.Visible = false;
				}
				btnNewID.Visible = false;
				cbCompany.Visible = false;
				lCpnyName.Visible = true;
				tQuoteID.Text = x_QID.ToString();
				if (!fill_Qot(x_QID, x_CpnyName)) this.Close();
				else lCurr_opera.Text = "E";
			}
		}

		private void lnkCmnt_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			tComnt.Visible = true;
			btnComnt.Visible = true;
		}
		
		private void cbContacts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		    //string stSql = "SELECT Contact_ID FROM PSM_Contacts WHERE ([PSM_Contacts]![First_ Name] & ' ' & [PSM_Contacts]![Last_Name])='" + cbContacts.Text + "' ";
		    //lContact_ID.Text = MainMDI.Find_One_Field(stSql);
			//lContact_ID.Text = MainMDI.Find_One_Field(stSql);
		    //if (lContact_ID.Text == MainMDI.VIDE) lContact_ID.Text = "0";

			string[] arr_Val = new string[8]{ "", "", "", "", "", "", "", "" };
			string stSql = "SELECT PSM_Contacts.Contact_ID, PSM_Prefix.Prefix, PSM_Contacts.[First_Name], PSM_Contacts.Last_Name, PSM_Contacts.JOBTitle, Extension,Main_TEL,PSM_Contacts.[Fax Number] " +
                " FROM PSM_Contacts INNER JOIN PSM_Prefix ON PSM_Contacts.Prefix_ID = PSM_Prefix.[Prefix ID]  " +
				" WHERE ([PSM_Contacts].[First_Name] + ' ' + [PSM_Contacts].[Last_Name])='" + cbContacts.Text.Replace("'", "''") + "' and JOBTitle<>'~~' and Company_ID=" + lcpnyID.Text;
			
			if (MainMDI.Find_arr_Fields(stSql, arr_Val) == MainMDI.VIDE) lContact_ID.Text = "0";
			else 
			{
				lContact_ID.Text = arr_Val[0];
				lPrfx.Text = arr_Val[1];
				lConName.Text = arr_Val[3];
				lSFX.Text = arr_Val[4];
				lConExt.Text = arr_Val[5];
				lConTel.Text = arr_Val[6];
				lPhone.Text = arr_Val[6];
				lConFax.Text = arr_Val[7];
			}
		}

		private void majContact()
		{
			string[] arr_Val = new string[6]{ "", "", "", "", "", "" };
			string stSql = "SELECT PSM_Contacts.Contact_ID, PSM_Prefix.Prefix, PSM_Contacts.[First_Name], PSM_Contacts.Last_Name, PSM_Contacts.JOBTitle, Extension " +
				" FROM PSM_Contacts INNER JOIN PSM_Prefix ON PSM_Contacts.Prefix_ID = PSM_Prefix.[Prefix ID]  WHERE ([PSM_Contacts].[First_Name] + ' ' + [PSM_Contacts].[Last_Name])='" + cbContacts.Text.Replace("'", "''") + "' ";
			
			if (MainMDI.Find_arr_Fields(stSql, arr_Val) == MainMDI.VIDE) lContact_ID.Text = "0";
			else 
			{
				lContact_ID.Text = arr_Val[0];
				lPrfx.Text = arr_Val[1];
				lConName.Text = arr_Val[3];
				lSFX.Text = arr_Val[4];
				lConExt.Text = arr_Val[5];
			}
		}

		private void cbTerms_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//string stSql = "SELECT Contact_ID FROM PSM_Contacts WHERE ([PSM_Contacts]![First_ Name] & ' ' & [PSM_Contacts]![Last_Name])='" + cbContacts.Text + "' ";
			lTerm_ID.Text = MainMDI.Find_One_Field("select InTermId from PSM_Terms where Descr='" + cbTerms.Text + "' ");
			if (lTerm_ID.Text == MainMDI.VIDE) lTerm_ID.Text = "0";
		}

		private void cbShipVia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lVia_ID.Text = MainMDI.Find_One_Field("select ship_ID from PSM_ShipMeth where ShipEng='" + cbShipVia.Text + "' ");
			if (lTerm_ID.Text == MainMDI.VIDE) lTerm_ID.Text = "0";
		}

		private void cbIncoTerm_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lIncoT_ID.Text = MainMDI.Find_One_Field("select IT_ID from PSM_IncoTerm where IT_DESC='" + cbIncoTerm.Text + "' ");
			if (lIncoT_ID.Text == MainMDI.VIDE) lIncoT_ID.Text = "0";
		}

		private void btnImpChrgPrices_Click(object sender, System.EventArgs e)
		{
			//label28.Text = System.DateTime.Now.Minute.ToString() + "-" + System.DateTime.Now.Second.ToString();
		    del_Charger_Price_Fast();
		    Import_ChPrices();
		    //label29.Text = System.DateTime.Now.Minute.ToString() + "-" + System.DateTime.Now.Second.ToString();
		    //MessageBox.Show("Import Completed.....");
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void button1_Click_1(object sender, System.EventArgs e)
		{
			Chargerdlg frmchdlg = new Chargerdlg('0', MainMDI.M_stCon, 'N');
			frmchdlg.Show();
		}

		private void import_OldQInfo(string r_IQID)
		{
			string stSql = "SELECT PSM_Q_IGen.Quote_ID, PSM_Q_IGen.ProjectName, PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS Emp, PSM_SALES_AGENTS_1.First_Name + ' ' + PSM_SALES_AGENTS_1.Last_Name AS IPMGR, PSM_Q_IGen.curr, PSM_Q_IGen.Lang " +
                " FROM (PSM_Q_IGen INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_1 ON PSM_Q_IGen.IPmgr = PSM_SALES_AGENTS_1.SA_ID WHERE (((PSM_Q_IGen.i_Quoteid)=" + r_IQID + "))";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
                tProjNAME.Text = Oreadr["ProjectName"].ToString();
				if (tQuoteID.Text == "") tQuoteID.Text = Oreadr["Quote_ID"].ToString();
				cbEmploy.Text = Oreadr["Emp"].ToString();
				cbIPmgr.Text = Oreadr["IPMGR"].ToString();
				switch (Oreadr["Lang"].ToString())
				{
					case "B":
						cbLang.Text = "Billingual";
						break;
					case "F":
						cbLang.Text = "French";
						break;
					case "E":
						cbLang.Text = "English";
						break;
				}
				opCan.Checked = (Oreadr["curr"].ToString() == "C");
				opUS.Checked = (Oreadr["curr"].ToString() == "U");
				opEuro.Checked = (Oreadr["curr"].ToString() == "E");
			}
			OConn.Close();
		}

		private void cpy_Sol(string OldQid, string NewQid, string OldSlid)
		{
			string stSql = "SELECT * from PSM_Q_SOL WHERE I_Quoteid=" + OldQid + " and Sol_LID=" + OldSlid;
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				stSql = "INSERT INTO PSM_Q_SOL ([I_Quoteid],[Sol_Name],[img], [Rnk]," + 
					" [user],[date_Rev] ) VALUES ('" +
					NewQid + "', '" +
				    //Oreadr["Sol_Name"].ToString() + "', '" +
					Oreadr["Sol_Name"].ToString().Substring(0, 2) + "-00" + "', '" +
					Oreadr["img"].ToString() + "', '" + Oreadr["Rnk"].ToString() + "', '" + MainMDI.User + "', " + MainMDI.SSV_date(System.DateTime.Now.ToShortDateString()) + ")";
				MainMDI.ExecSql(stSql);
				MainMDI.Write_JFS(stSql);
		        //stSql = MainMDI.Find_One_Field("select Sol_LID from PSM_Q_SOL where I_Quoteid=" + NewQid + " AND Sol_Name='" + Oreadr["Sol_Name"].ToString() + "' and Rnk=" + Oreadr["Rnk"].ToString());
		        stSql = MainMDI.Find_One_Field("select Sol_LID from PSM_Q_SOL where I_Quoteid=" + NewQid + " AND Sol_Name='" + Oreadr["Sol_Name"].ToString().Substring(0, 2) + "-00" + "' and Rnk=" + Oreadr["Rnk"].ToString());
				if (stSql != MainMDI.VIDE) Cpy_SPEC(OldSlid, stSql);
				else MessageBox.Show("Error Occurs while Saving imported Revision...contact your Admin !!!" + MainMDI.stXP);
			}
		}

		private void Cpy_SPEC(string OldSlid, string NewSlid)
		{
			//string stSql = MainMDI.Find_One_Field("select SPC_LID from PSM_Q_SPCS where Sol_LID=" + SID.ToString() + " AND SPC_Name='" + spc_name + "' and Rnk=" + Rnk);

			string stSql = "select * from PSM_Q_SPCS where Sol_LID=" + OldSlid;
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				stSql = "INSERT INTO PSM_Q_SPCS ([Sol_LID],[SPC_Name], " + 
					" [Rnk] ) VALUES ('" +
					NewSlid + "', '" +
					Oreadr["SPC_Name"].ToString().Replace("'", "''") + "', '" +
					Oreadr["Rnk"].ToString() + "')";
				MainMDI.ExecSql(stSql);
				MainMDI.Write_JFS(stSql);
				stSql = MainMDI.Find_One_Field("select SPC_LID from PSM_Q_SPCS where Sol_LID=" + NewSlid + " AND SPC_Name='" + Oreadr["SPC_Name"].ToString().Replace("'", "''") + "' and Rnk=" + Oreadr["Rnk"].ToString());
				if (stSql != MainMDI.VIDE) Cpy_ALS(Oreadr["SPC_LID"].ToString(), stSql);
				else MessageBox.Show("Error Occurs while Saving Imported SPEC...contact your Admin !!!" + MainMDI.stXP);
			}
		}

		private void Cpy_ALS(string OldSpcId, string NewSpcId)
		{
			string stSql = "select * from PSM_Q_ALS where SPC_LID=" + OldSpcId;
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				stSql = "INSERT INTO PSM_Q_ALS ([SPC_LID],[ALS_Name],[Tot], [PxPrice],[AGPrice],[AlsQty]," + 
					" [Rnk] ) VALUES (" +
					NewSpcId + ", '" +
					Oreadr["ALS_Name"].ToString().Replace("'", "''") + "', " +
					Oreadr["Tot"].ToString() + ", " +
					Oreadr["PxPrice"].ToString() + ", " +
					Oreadr["AGPrice"].ToString() + ", " +
					Oreadr["AlsQty"].ToString() + ", " +
					Oreadr["Rnk"].ToString() + ")";
				MainMDI.ExecSql(stSql);
				MainMDI.Write_JFS(stSql);
				stSql = MainMDI.Find_One_Field("select ALS_LID from PSM_Q_ALS where SPC_LID=" + NewSpcId + " AND ALS_Name='" + Oreadr["ALS_Name"].ToString().Replace("'", "''") + "' and Rnk=" + Oreadr["Rnk"].ToString());
				if (stSql != MainMDI.VIDE) Cpy_Details(Oreadr["ALS_LID"].ToString(), stSql);
				else MessageBox.Show("Error Occurs while Saving Imported ALIAS...contact your Admin !!!" + MainMDI.stXP);
			}	
		}

		private void Cpy_ALSOLD(string OldSpcId, string NewSpcId)
		{
			string stSql = "select * from PSM_Q_ALS where SPC_LID=" + OldSpcId;
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				 stSql = "INSERT INTO PSM_Q_ALS ([SPC_LID],[ALS_Name],[Tot], " + 
					" [Rnk] ) VALUES (" +
					NewSpcId + ", '" +
					Oreadr["ALS_Name"].ToString().Replace("'", "''") + "', " +
					Oreadr["Tot"].ToString() + ", '" +
					Oreadr["Rnk"].ToString() + "')";
				MainMDI.ExecSql(stSql);
				MainMDI.Write_JFS(stSql);
				stSql = MainMDI.Find_One_Field("select ALS_LID from PSM_Q_ALS where SPC_LID=" + NewSpcId + " AND ALS_Name='" + Oreadr["ALS_Name"].ToString().Replace("'", "''") + "' and Rnk=" + Oreadr["Rnk"].ToString());
				if (stSql != MainMDI.VIDE) Cpy_Details(Oreadr["ALS_LID"].ToString(), stSql);
				else MessageBox.Show("Error Occurs while Saving Imported ALIAS...contact your Admin !!!" + MainMDI.stXP);
			}	
		}

		private void Cpy_Details(string OldAlsId, string NewAlsId)
		{
			string stSql = "select * from PSM_Q_Details where ALS_LID=" + OldAlsId;
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				//double ddUP = (lvQITEMS.Items[i].SubItems[5].Text == "") ? 0 : Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[5].Text);
				//int LA = (lvQITEMS.Items[i].SubItems[8].Text == "") ? 0 : Convert.ToInt32(lvQITEMS.Items[i].SubItems[8].Text);
				 stSql = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " + 
					" [Desc],[Qty],[Xch_Mult],[Uprice], [Mult],[Ext],[LeadTime],[Rnk],[PN],[Q_tec_Val]) VALUES ('" +
					NewAlsId + "', '" +
					Oreadr["Aff_ID"].ToString() + "', '" +
					Oreadr["Desc"].ToString().Replace("'", "''") + "', '" +
					Oreadr["Qty"].ToString() + "', '" +
					Oreadr["Xch_Mult"].ToString() + "', '" +
					Oreadr["Uprice"].ToString() + "', '" +
					Oreadr["Mult"].ToString() + "', '" +
					Oreadr["Ext"].ToString() + "', '" +
					Oreadr["LeadTime"].ToString() + "', '" +
					Oreadr["Rnk"].ToString() + "', '" +
					Oreadr["PN"].ToString() + "', '" +
					Oreadr["Q_tec_Val"].ToString() + "')";
				MainMDI.ExecSql(stSql);
				MainMDI.Write_JFS(stSql);
			}
		}

		private void add_ALRM_EQ(string CH_FRML)
		{
			Alarms_EQ_Oth AlrmEQ = new Alarms_EQ_Oth(CH_FRML, false, 'N');
			AlrmEQ.ShowDialog();
			if (AlrmEQ.lSave.Text == "Y")
			{
				for (int i = 0; i < AlrmEQ.lvAlrmPL.Items.Count; i++)
				{
					if (AlrmEQ.lvAlrmPL.Items[i].Checked)
					{
						ItemCount++;
						add_LVO(1, 0, ItemCount.ToString(), AlrmEQ.lvAlrmPL.Items[i].SubItems[1].Text, "1", tCust_Mult.Text, AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(AlrmEQ.lvAlrmPL.Items[i].SubItems[2].Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)), "04-06", "ALEQ_???", AlrmEQ.lvAlrmPL.Items[i].SubItems[3].Text, "A");
					}
				}
				Ref_ALSTOT('A');
			}
			AlrmEQ.Close();
			AlrmEQ.Dispose();
		}

		private bool btnOK(int btn)
		{
			bool res = true;
			switch (btn)
			{
				case 3:
				case 14:
				case 7:
				case 8:
				case 17:
				case 19:
				case 16:
					res = MainMDI.ALWD_USR("QT_SV", true); //Quotes: Saving, Delete, duplication and Word print.
					break;
			}
			return res;
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			if (in_opera != 'V')
			{
				this.Cursor = Cursors.WaitCursor;

				int btn = toolBar1.Buttons.IndexOf(e.Button);
				if (btnOK(btn))
				{
					//MessageBox.Show(toolBar1.Buttons.IndexOf(e.Button).ToString());
				
					if (btn == 1)
					{
						QimportRxx imp = new QimportRxx();
						imp.ShowDialog();
						if (imp.lsave.Text == "Y")
						{
							import_OldQInfo(imp.lIQID.Text);
							Imp_SolID = imp.lSolid.Text;
							Imp_IQID = imp.lIQID.Text;
							Imp_cpnyID = imp.lcpnyID.Text;
							gbxSol.Enabled = false;
							MainMDI.Write_JFS("imported IQID=" + imp.lIQID.Text + " TO " + tQuoteID.Text + " date: " + System.DateTime.Now);
							//Imprt = true;
						}
						else Imp_SolID = "";
					}
					if (btn == 3 || btn == 20)
					{
						bool fin = true;
						if (btn == 20)
						{
							SAVE_CHANGE_ALS();
							if (lCurrIQID.Text != "" && tQuoteID.Text != "") if (tQuoteID.Text != "") MainMDI.flag_QRID('Q', 'u', 0, Convert.ToUInt32(tQuoteID.Text));
								else fin = MainMDI.Confirm("This Quote is not Saved yet ... Quit anyway ? ");
							if (fin) this.Hide();
						}
						else
						{
							if (tQuoteID.Text != "")
							{
								string stId = MainMDI.Find_One_Field("select I_Quoteid from PSM_Q_IGen where Quote_ID=" + tQuoteID.Text + " AND CPNY_ID=" + lcpnyID.Text);
								    //if (Imp_cpnyID != lcpnyID.Text && stId == MainMDI.VIDE)
								if (stId == MainMDI.VIDE || in_opera == 'E')
								{
									if (Save_Q_IGen())
									{
										lQstatus.Text = lCancel.Text.Substring(0, 1);
										//if (Imp_SolID == "")
										MainMDI.flag_QRID('Q', 'f', 1, Convert.ToInt32(tQuoteID.Text));
										if (Imp_SolID != "") cpy_Sol(Imp_IQID, lCurrIQID.Text, Imp_SolID);
										lQsave.Text = "Y";
										if (!gbxSol.Enabled) Imprt = true;
									}
                                    txcb_Territo.BringToFront();
								}
								else 
								{
									if (tQuoteID.ReadOnly) MessageBox.Show("This Quote already exists for this Company..... !!!");
									else MessageBox.Show("Sorry, this Quote ID is already Taken,  try others IDs !!!!");
								}
							}
							else { MessageBox.Show("Quote ID is empty...."); tQuoteID.Focus(); }
						}
					}
					else
					{
						if (lCurrIQID.Text != "0" && tQuoteID.Text != "" && (lcurSol_Status.Text != "C" || btn == 7|| btn == 4))
						{
							switch (btn)
							{
								case 0:
									if (lCurrIQID.Text != "0")
									{
										if (lCancel.Visible) lQstatus.Text = "N";
										else lQstatus.Text = "C";
									}
									break;
								case 4:
									Sol_Rep_SPP('V');
									//lCurrNAME.Text = (tQuoteID.Text + "S#" + tvSol.Nodes.Count.ToString());
									//tvSol.Nodes.Add(lCurrNAME.Text);
									//tvSol.Nodes[tvSol.Nodes.Count - 1].ImageIndex = 2;
									//tvSol.Nodes[tvSol.Nodes.Count - 1].SelectedImageIndex = 2;
									//tvSol.Nodes[tvSol.Nodes.Count - 1].BeginEdit();
									break;
								case 5:
									if (lTVSel.Text == "Y")
									{
										//MessageBox.Show("Sel= " + tvSol.SelectedNode.IsSelected); Convert.ToString(tvSol.Nodes.Count + 1))
									    //lCurrNAME.Text = "Alt#" + tvSol.SelectedNode.Nodes.Count.ToString();
										lCurrNAME.Text = "Alt#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
										if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = "Alt#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
										tvSol.SelectedNode.Nodes.Add(lCurrNAME.Text);
										tvSol.SelectedNode.Expand();
										tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].SelectedImageIndex = 1;
										tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].ImageIndex = 1;
										//tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].BeginEdit();
									}
									break;
								case 6:
									if (lTVSel.Text == "Y")
									{
										//MessageBox.Show("Sel= " + tvSol.SelectedNode.Nodes.Count.ToString());

										//lCurrNAME.Text = "Alias#" + tvSol.SelectedNode.Nodes.Count.ToString();
										//if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = "Alias#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
										//lCurrNAME.Text = MainMDI.arr_EFSdict[38, MainMDI.Lang] + "#" + tvSol.SelectedNode.Nodes.Count.ToString();
										lCurrNAME.Text = MainMDI.arr_EFSdict[38, MainMDI.Lang] + "#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
										if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = MainMDI.arr_EFSdict[38, MainMDI.Lang] + "#" + Convert.ToString(tvSol.SelectedNode.Nodes.Count + 1);
										tvSol.SelectedNode.Nodes.Add(lCurrNAME.Text);
										tvSol.SelectedNode.Expand();
										tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].SelectedImageIndex = 0;
										tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].ImageIndex = 0;
                                        chk_savOVRG.Checked = false;
										//tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].BeginEdit();
									}
									break;
								case 7:
									if (lTVSel.Text == "Y")
									{
										switch (tvSol.SelectedNode.ImageIndex)
										{
											case 2:
											case 4:
											case 5:
												Duplica_Sol();
												break;
											case 1:
												if (lcurSol_Status.Text != "C") Duplica_SPC();
												break;
											case 0:
											case 3:
												if (lcurSol_Status.Text != "C") Duplica_ALS();
												break;
										}
									}
									break;
								case 8:
									if (lTVSel.Text == "Y")
									{
										DialogResult dr = MessageBox.Show("Do You want to DELETE : " + tvSol.SelectedNode.Text, "Delete Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
										if (dr == DialogResult.Yes) del_Node();
									}
									break;
								//case 9: //New Charger
									//Add_Charger();
									//Tosave = true;
									//break;
								case 10: //add Pre-Sized Battery
									Add_CBR('B');
									Tosave = true;
									break;
								case 11: //add Pre-Sized Cabinet
									Add_CBR('C');
									Tosave = true;
									break;
								case 12: //add Pre-Sized Rack
									//PbsInfo pbsIR = new PbsInfo('R', "44");
									//pbsIR.ShowDialog();
									Add_CBR('R');
									Tosave = true;
									break;
								case 13: //New OPTION
									Add_option();
									Tosave = true;
									break;
								case 14: //New NL_ITEM_OPTION
									Add_NLItemOption();
									Tosave = true;
									break;
								case 15: //add alarms
									if (lvQITEMS.SelectedItems.Count > 0 && lvQITEMS.SelectedItems[0].SubItems[12].Text.IndexOf("n/a U_CHARGER||") > -1)
									{
										add_ALRM_EQ(lvQITEMS.SelectedItems[0].SubItems[12].Text);
										Tosave = true;
									}
									break;
								case 16: //Save Current ALS
									if (lQsave.Text == "Y")
									{
										if (lcurSol_Status.Text != "C" && lvQITEMS.Items.Count > 0)
										{
											Save_Q_ALL_Details();
											//format display 0.00
											AlsTOT.ReadOnly = true;
											AlsTOT.Text = MainMDI.A00(Tools.Conv_Dbl(AlsTOT.Text).ToString());
											AlsTOT.ReadOnly = false;
                                	        AlterTOT.Text = MainMDI.Curr_FRMT(MainMDI.SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
											tAGprice.Text = MainMDI.A00(Tools.Conv_Dbl(tAGprice.Text).ToString());
											//Maj_AlsTOT();
										}
										else MessageBox.Show("if you want to Empty this ALIAS use DELETE button !!!!");
									}
									else MessageBox.Show("You have to save Quote-Info FIRST !!!");
									toolBar1.Buttons[16].Pushed = false;
									break;
								case 17: //Del Current Als
									if (lvQITEMS.SelectedItems.Count > 0)
									{
										//if (lvQITEMS.SelectedItems[0].SubItems[1].Text != " ")
										if (MainMDI.Confirm("WANT TO DELETE ITEM / OPTION: " + lvQITEMS.SelectedItems[0].SubItems[2].Text + " ?  "))
										{
											if (lvQITEMS.SelectedItems[0].SubItems[1].Text == ".") Opt_added = false;
											del_Als_IO(lvQITEMS.SelectedItems[0].Index);
										}
									}
									else if (MainMDI.Confirm("WANT TO DELETE : " + tvSol.SelectedNode.Text + " ?  ")) del_Als(lCurSoln.Text, lCurSPCn.Text, lCurALSn.Text);
									Ref_ALSTOT('D');
									break;
								case 18: //PBsizing
									try
									{
										System.Diagnostics.Process.Start(MainMDI.PBSPath + @"\PBSIZING.exe");
									}
									catch (System.Exception Oexp)
									{
										MessageBox.Show("Cannot Find PBSIZING.EXE at path: " + MainMDI.PBSPath + " System-msg: " + Oexp.Message);
									}
									break;
								case 19: //Print
									string solId = MainMDI.Find_One_Field("select  Sol_LID from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'");
									FichWord_Config FC = new FichWord_Config(lCurrIQID.Text, solId, cbTerms.Text, lHiDelv.Text, lcurDol.Text, "");
									FC.ShowDialog();
									this.Refresh();
									if (FC.NXT)
									{
										pbPrintQt.Value = 0;
										lblWait.Text = "Please Wait,   exporting Quote to Word ...";
										grpPB.Visible = true;
										grpPB.Refresh();
										FichWord_aNEW FW = new FichWord_aNEW(this, FC);
										FW.Wexport();
									}
									break;
							}
						}
						else
						{
							if (lcurSol_Status.Text == "C") MessageBox.Show("This Revission is Protected (Bleu=Converted to Order !!!!)");
							if (lCurrIQID.Text == "0" && tQuoteID.Text == "") MessageBox.Show("You have To Save 'Quote Info' First !.....");
						}
					}
					//else { if (lcurSol_Status.Text == "C") MessageBox.Show("This Revission is Protected (Bleu=Converted to Order !!!!)"); }
					this.Cursor = Cursors.Default;
				}
			    //else 
			    //{
			        //if (btn == 20) this.Hide();
			        //else MessageBox.Show(MainMDI.User + ": is NOT allowed to perform this option, contact you Admin....! ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop); //MessageBox.Show(msg, "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			    //}
				if (Imprt) picExit_Click(sender, e);
				this.Cursor = Cursors.Default;
			}
			else MessageBox.Show("Only Viewing Allowed ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop); //MessageBox.Show(msg, "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
		}

		private bool Rev_Converted(string iqid, string revName)
		{
			string res = MainMDI.Find_One_Field("select status_Rev from PSM_Q_SOL where I_Quoteid=" + iqid + " and Sol_Name='" + revName.Replace("'", "''") + "'");
			return (res == "C");
		}

		private void Sol_Rep_SPP(char s)
		{
			int nb = 0, t;
			
			switch (s)
			{
				case 'V':
                    t = REV_Nb("RV") + 1;
					lCurrNAME.Text = "RV-" + MainMDI.A00(t, 2);
				    //if (REv_Exist(lCurrNAME.Text)) lCurrNAME.Text = "RV-" + (t + 1);
					nb = 2;
					break;
				case 'S':
					t = REV_Nb("SP") + 1;
					lCurrNAME.Text = "SP-" + MainMDI.A00(t, 2);
				    //if (REv_Exist(lCurrNAME.Text)) lCurrNAME.Text = "SP-" + (t + 1);
					nb = 4;
					break;
				case 'R':
					t = REV_Nb("SV") + 1;
					lCurrNAME.Text = "SV-" + MainMDI.A00(t, 2);
                    //if (REv_Exist(lCurrNAME.Text)) lCurrNAME.Text = "SV-" + (t + 1);
					nb = 5;
					break;
			}
			//lCurrNAME.Text = (tQuoteID.Text + "S#" + tvSol.Nodes.Count.ToString());
			tvSol.Nodes.Add(lCurrNAME.Text);
			tvSol.Nodes[tvSol.Nodes.Count - 1].ImageIndex = nb;
            tvSol.Nodes[tvSol.Nodes.Count - 1].SelectedImageIndex = nb;
		    //tvSol.Nodes[tvSol.Nodes.Count - 1].BeginEdit();
		}

		private void Sol_Rep_SPPOLD(char s)
		{
			int nb = 0;
			
			switch (s)
			{
				case 'V':
					//lCurrNAME.Text = (tQuoteID.Text + "Version #" + tvSol.Nodes.Count.ToString());
					lCurrNAME.Text = "RV-" + tvSol.Nodes.Count.ToString();
					if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = "RV-" + tvSol.Nodes.Count.ToString() + Convert.ToString(tvSol.Nodes.Count + 1);
					nb = 2;
					break;
				case 'S':
					lCurrNAME.Text = "SP-" + tvSol.Nodes.Count.ToString();
					if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = "SP-" + tvSol.Nodes.Count.ToString() + Convert.ToString(tvSol.Nodes.Count + 1);
					nb = 4;
					break;
				case 'R':
					lCurrNAME.Text = tQuoteID.Text + "SV-" + tvSol.Nodes.Count.ToString();
					if (LBL_Exist_Newa(lCurrNAME.Text)) lCurrNAME.Text = tQuoteID.Text + "SV-" + Convert.ToString(tvSol.Nodes.Count + 1);
					nb = 5;
					break;
			}
			//lCurrNAME.Text = (tQuoteID.Text + "S#" + tvSol.Nodes.Count.ToString());
			tvSol.Nodes.Add(lCurrNAME.Text);
			tvSol.Nodes[tvSol.Nodes.Count - 1].ImageIndex = nb;
			tvSol.Nodes[tvSol.Nodes.Count - 1].SelectedImageIndex = nb;
			//tvSol.Nodes[tvSol.Nodes.Count - 1].BeginEdit();
		}
		private void groupBox6_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void lvComment_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btn2_Click(object sender, System.EventArgs e)
		{
			Fill_BigFile13 fillbgf = new Fill_BigFile13();
			fillbgf.ShowDialog();
		}

		public bool IsDoubleNumber(string strNumber)
		{
			Regex objNotNumberPattern = new Regex("[^0-9.-]");
			Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
			Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
			String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
			String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
			Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

			return !objNotNumberPattern.IsMatch(strNumber) &&
				!objTwoDotPattern.IsMatch(strNumber) &&
				!objTwoMinusPattern.IsMatch(strNumber) &&
				objNumberPattern.IsMatch(strNumber);
		}

		private bool isNumber(string strNumber)
		{
			Regex objNotPositivePattern = new Regex("[^0-9.]");
			Regex objPositivePattern = new Regex("^[.][0-9]+$|[0-9]*[.]*[0-9]+$");
			Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");

			return !objNotPositivePattern.IsMatch(strNumber) &&
				objPositivePattern.IsMatch(strNumber) &&
				!objTwoDotPattern.IsMatch(strNumber);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
	        ////MainMDI.Lang = 0;
	        //string solId = Find_One_Field("select  Sol_LID from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text + "'");
	        //FichWord_Config FC = new FichWord_Config(lCurrIQID.Text, solId, cbTerms.Text, lHiDelv.Text);
	        //FC.ShowDialog();
	        //if (FC.NXT) { FichWord kiki = new FichWord(this, FC); }
	        ////Add_NLItemOption();
		    MessageBox.Show("Res=" + Tools.IsNumeric("14525 455").ToString());
		    //if (MainMDI.User == "Admin")
		    //{
		        //Chargerdlg_RREV frmchdlgrev = new Chargerdlg_RREV('0', lvQITEMS.Items[lvQITEMS.SelectedItems[0].Index].SubItems[12].Text, MainMDI.VIDE, lvQITEMS.Items[lvQITEMS.SelectedItems[0].Index].SubItems[9].Text);
		        ////this.Hide();
		        //frmchdlgrev.ShowDialog();
		        //if (frmchdlgrev.lSave.Text == "Y") MessageBox.Show("SaveeeeeeeeeeeeeeeeeeeeeeeeeeeD");
		    //}
		}

		private void lvQITEMS_ItemCheckOLD(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			//if (e.Index == 0) lvQITEMS.Items[2].Checked = true;
			if (in_opera == 'C')
			{
				if (!lvQITEMS.Items[e.Index].Checked)
				{
					if (in_opera == 'C' && lvQITEMS.Items[e.Index].SubItems[7].Text != "")
						if (seek_LvOrder(lvQITEMS.Items[e.Index].SubItems[11].Text, 'c') == -1) add_LVR("      " + lvQITEMS.Items[e.Index].SubItems[2].Text, lCurSolNDX.Text, lCurSPCNDX.Text, lCurALSNDX.Text, lvQITEMS.Items[e.Index].SubItems[11].Text, e.Index.ToString(), lCurSPCn.Text + "/" + lCurALSn.Text, lvQITEMS.Items[e.Index].SubItems[7].Text);
				}
				else seek_LvOrder(lvQITEMS.Items[e.Index].SubItems[11].Text, 'r');
			}
			//else lvQITEMS.Items[e.Index].Checked = !lvQITEMS.Items[e.Index].Checked;
			//else lvQITEMS_DoubleClick(sender, e);
		}

		private void lvQITEMS_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
		    /*
		    to disable checking items in many alias when converting a Quote
			if (in_opera == 'C')
			{
				if (!lvQITEMS.Items[e.Index].Checked)
				{
					if (in_opera == 'C' && lvQITEMS.Items[e.Index].SubItems[1].Text != "")
						if (seek_LvOrder(lvQITEMS.Items[e.Index].SubItems[11].Text, 'c') == -1) add_LVR("      " + lvQITEMS.Items[e.Index].SubItems[2].Text, lCurSolNDX.Text, lCurSPCNDX.Text, lCurALSNDX.Text, lvQITEMS.Items[e.Index].SubItems[11].Text, e.Index.ToString(), lCurSPCn.Text + "/" + lCurALSn.Text, lvQITEMS.Items[e.Index].SubItems[7].Text);
				}
				else seek_LvOrder(lvQITEMS.Items[e.Index ].SubItems[11].Text, 'r');
			}
            */
		}

		private int seek_LvOrder(string st, char c)
		{
			if (st != "" && !isDellAll)
			{
				for (int i = 0; i < lvOrder.Items.Count; i++)
					if (lvOrder.Items[i].SubItems[4].Text == st)
					{
						if (c == 'r') lvOrder.Items[i].Remove();
						else return i;
					}
			}
			return -1;
		}

		private void Quote_Resize(object sender, System.EventArgs e)
		{
		    tabControl1.Width = this.Width - 24;
		    //this.width = 872 not 920

		    //AlsTOT.Left = this.Width - 168;
		    //AlsBigTOT.Left = this.Width - 168;

		    //lALSBigTOT.Left = this.Width - 240;
		    //AlterTOT.Left = this.Width - 168;
		    //lAlterTOT.Left = this.Width - 696;
		    //LocTot.Left = this.Width - 536;
		    //lLocTot.Left = LocTot.Left - 456;
		    //AgTot.Left = this.Width - 536;
		    //lAgTot.Left = this.Width - 672; //456

		    lvComment.Width = this.Width - 48;
		    //statusBar1.Panels[0].Width = this.Width - 238;
			gbxTabs.Width = this.Width - 16;
			AffQNB.Left = this.Width - 232; //152;
			picFr.Left = this.Width - 232; //152;
			lcurDol.Left = this.Width - 208;
			picEng.Left = this.Width - 232; //152;

			lQNB.Left = this.Width - 304; //224;

		    gbxTabs.Height = this.Height - 92; //50;
		    tabControl1.Height = this.Height - 112; //96;
		    gbxSol.Height = this.Height - 200;

		    tvSol.Height = this.Height - 238; //210;
		    lvQITEMS.Height = this.Height - 238; //210;
			if (in_opera == 'C')
			{
				splitter1.Visible = false;
				lvQITEMS.Width = this.Width - 530;
				grpOrder.Left = this.Width - 336;
				grpOrder.Height = this.Height - 195;
				lvOrder.Height = this.Height - 255;
			}
			else lvQITEMS.Width = this.Width - 245; //220
		    lvQITEMS.Columns[2].Width = this.Width - 725;
            grpCmnt.Height = this.Height - 470;
		    lvComment.Height = grpCmnt.Height -38;

			picExit.Left = this.Width - 48;
            AlterTOT.Left = groupBox5.Width - 139; //176;
            lRevTOT.Left = AlterTOT.Left;
            lAlterTOT.Left = groupBox5.Width - 211; //235;
            label64.Left = lAlterTOT.Left;

            //AlsTOT.Left = this.Width - 220;
	        //lALSTOT.Left = this.Width - 374;

		    //if listopt's size changes 
		    //MessageBox.Show("W this= " + this.Width + "  W= " + tabControl1.Width);
		    //MessageBox.Show("H this= " + this.Height + "  H= " + tabControl1.Height);
		}

		private void cbCompany_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            toolBar1.Enabled = true;
			lAdrs.Text = "";
			lPhone.Text = ""; lFax.Text = "";
			lContact_ID.Text = "";
			lCpnyName.Text = cbCompany.Text;
            string BLcmnt = "", InBL = "", usr = "";
            MainMDI.Find_2_Field("select BLack_List,  BL_Cmnt, BL_usr  from PSM_COMPANY Where Cpny_Name1='" + cbCompany.Text + "'", ref InBL, ref BLcmnt, ref usr);
            if (lCurr_opera.Text != "N" || InBL == "0")
            {
                fill_Company_Info(cbCompany.Text, '*');
                fill_cb_Contacts(Convert.ToInt32(lcpnyID.Text));
                if (lCurr_opera.Text == "N")
                {
                    cbCQA.Text = cbCompany.Text;
                    cbCPA.Text = cbCompany.Text;
                    cbCSA.Text = cbCompany.Text;
                    cbCIA.Text = cbCompany.Text;
                }
            }
            else
            {
                if (toolBar1.Enabled)
                {
                    MessageBox.Show("Sorry, This Company is in BLACK LIST ...You have to contact Admin....\n Why? : " + BLcmnt + "\n Added in Black-List by: " + usr, "BLACK LIST", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                   toolBar1.Enabled = false;
                }
            }
		}

		private void statusBar1_PanelClick(object sender, System.Windows.Forms.StatusBarPanelClickEventArgs e)
		{
		
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		    //if (tabControl1.SelectedTab.Text == "Solutions")
		    //{
			switch_ToolBar(tabControl1.SelectedIndex);
			if (tabControl1.SelectedIndex == 1)
			{
				SAVE_CHANGE_ALS();
			    //switch_ToolBar(tabControl1.SelectedIndex);
				AffQNB.Visible = (tabControl1.SelectedIndex != 0);
				lQNB.Visible = AffQNB.Visible;
				toolBar1.Buttons[19].Visible= (!Tosave);
				if (lCurr_opera.Text == "E" || lCurr_opera.Text == "N")
				{
					if (!Quote_loaded)
					{
						this.WindowState = FormWindowState.Maximized;
						tvSol.Nodes.Clear();
						fill_Sol();
						toolBar1.Buttons[19].Visible = true;
						if (tvSol.Nodes.Count == 0) AlS_Wizard();
					}
				}
			}
			toolBar1.Buttons[19].Visible = (tabControl1.SelectedIndex == 1);
		}

		private void switch_ToolBar(int c)
		{
			if (in_opera != 'C')
			{
				for (int i = 0; i < toolBar1.Buttons.Count; i++)
				{
					switch (c)
					{
						case 0:
							toolBar1.Buttons[i].Visible = (i < lim0);
							break;
						case 1:
							toolBar1.Buttons[i].Visible = (i < lim1 && i >= lim0);
							toolBar1.Buttons[19].Visible = true;
							break;
						case 9:
							toolBar1.Buttons[i].Visible = (i < lim2 && i >= lim1);
							break;
					}
					//toolBar1.Buttons[18].Visible = true;
					//toolBar1.Buttons[19].Visible = true; //Exit Button
				}
				//(i < 4) toolBar1.Buttons[i].Visible = (tabControl1.SelectedIndex == 0);
				//else if (i < 8) toolBar1.Buttons[i].Visible = ((tabControl1.SelectedIndex == 1 && tvSol.SelectedNode = null));
				    //else toolBar1.Buttons[i].Visible = (tabControl1.SelectedIndex == c);
				//
			}
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{

		}

		private void tQuoteID_TextChanged(object sender, System.EventArgs e)
		{
			AffQNB.Text = tQuoteID.Text; //+ "-" + tRev.Text;
		}

		private void tvSol_Leave(object sender, System.EventArgs e)
		{
			lTVSel.Text = "N";
		}

		private void tvSol_Click(object sender, System.EventArgs e)
		{
			//.SelectedNode.FullPath.ToString());
			//switch (nbOcc("\\", tvSol.SelectedNode.FullPath.ToString()))
			lTVSel.Text = "Y";
			if (tvSol.SelectedNode != null) if (tvSol.SelectedNode.ImageIndex == 0 || tvSol.SelectedNode.ImageIndex == 3) tvSol.SelectedNode.SelectedImageIndex = 0;
		}

		private void cbEmploy_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		    //lEmp_ID.Text = MainMDI.Find_One_Field("select SA_ID from PSM_SALES_AGENTS where First_Name='" + cbEmploy.Text + "'");
		    //if (lEmp_ID.Text == MainMDI.VIDE) lEmp_ID.Text = "";

			string[] arr_Val = new string[6]{ "", "", "", "", "", "" };
			string stSql = "select SA_ID ,Extension,sfx,Email_Address from PSM_SALES_AGENTS where (First_Name + ' ' + Last_Name) ='" + cbEmploy.Text.Replace("'", "''") + "'";
			if (MainMDI.Find_arr_Fields(stSql, arr_Val) == MainMDI.VIDE) lEmp_ID.Text = "0";
			else 
			{
				lEmp_ID.Text = arr_Val[0];
				lEExt.Text = arr_Val[1];
				lEmpSFX.Text = arr_Val[2];
				lemail.Text = arr_Val[3];
			}
		}

		private void cbLang_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lLang.Text = cbLang.Text[0].ToString();
			picFr.Visible = (cbLang.Text[0] == 'f' || cbLang.Text[0] == 'F');
			picEng.Visible = (cbLang.Text[0] == 'E' || cbLang.Text[0] == 'e' || cbLang.Text[0] == 'b' || cbLang.Text[0] == 'B');
			if (cbLang.Text[0] == 'E' || cbLang.Text[0] == 'B') MainMDI.Lang = 0;
			if (cbLang.Text[0] == 'F') MainMDI.Lang = 1;
			if (cbLang.Text[0] == 'S') MainMDI.Lang = 3;
		}

		private void tvSol_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
	        Tosave = false;
			string[] res = new string[]{ "", "", "" };
			lTVSel.Text = "Y";
		    //MessageBox.Show("path= " + tvSol.SelectedNode.FirstNode.Index.ToString());
			MainMDI.Deco_path(tvSol.SelectedNode.FullPath.ToString(), ref res);
			lCurSoln.Text = res[0];
			lCurSPCn.Text = res[1];
			lCurALSn.Text = res[2];

            AlsTOT_orig.Text = "";
            tAGprice.Text = "";
            tPxPrice.Text = "";
            AlsTOT.Clear();
            tALSnb.Text = "1";

			//lcurrImg.Text = "0";
			lvQITEMS.Items.Clear();
			switch (tvSol.SelectedNode.ImageIndex)
			{
				case 1: //Spec
				//case 4:
					toolBar1.Buttons[4].Enabled = false;
					printALS.Visible = false;
					toolBar1.Buttons[5].Enabled = false;
					toolBar1.Buttons[6].Enabled = true;
					lCurSolNDX.Text = tvSol.SelectedNode.Parent.Index.ToString();
					lCurSPCNDX.Text = tvSol.SelectedNode.Index.ToString();
					switch_ToolBar(1);
					AlsTOT_orig.Text = "";
					tAGprice.Text = "";
					tPxPrice.Text = "";
					tALSnb.Text = "";
                    AlterTOT.Text = MainMDI.Curr_FRMT(MainMDI.SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
					lcurSol_Status.Text = MainMDI.Find_One_Field("select status_Rev from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'");
					break;
				case 0: //Alias / system
				case 3:
					switch_ToolBar(9);
					tvSol.SelectedNode.SelectedImageIndex = 3;
					AlsTOT_orig.Text = "";
					tAGprice.Text = "";
					tPxPrice.Text = "";
					tALSnb.Text = "1";
                    chk_savOVRG.Checked = false;
					if (lCurALSn.Text != MainMDI.VIDE && lCurALSn.Text != "")
					{
						lCurSolNDX.Text = tvSol.SelectedNode.Parent.Parent.Index.ToString();
					}
					else lCurSolNDX.Text = tvSol.SelectedNode.Parent.Index.ToString();
					lCurSPCNDX.Text = tvSol.SelectedNode.Parent.Index.ToString();
                    lCurALSNDX.Text = tvSol.SelectedNode.Index.ToString();
					if (res[2] == "")
					{
						lCurALSn.Text = res[1];
						lCurSPCn.Text = MainMDI.VIDE;
						lCurSPCNDX.Text = tvSol.SelectedNode.Index.ToString();
					}
					OldAlsTot.Text = "";
					fill_details();
						
					Ref_ALSTOT('S');
					OldAlsTot.Text = AlsTOT_orig.Text;
					printALS.Visible = true;
                    AlterTOT.Text = MainMDI.Curr_FRMT(MainMDI.SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
					lcurSol_Status.Text = MainMDI.Find_One_Field("select status_Rev from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'");
					//lALSnb.Visible = true;
					//tALSnb.Visible = true;

                    //AlterTOT.Text = A00(SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
					break;
				case 2: //Solution
				case 5:
                case 4:
					switch_ToolBar(1);
					printALS.Visible = false;
					toolBar1.Buttons[4].Enabled = true;
					toolBar1.Buttons[5].Enabled = true;
					toolBar1.Buttons[6].Enabled = false; //disable ADD-ALIAS
					toolBar1.Buttons[7].Enabled = true;
					lCurSolNDX.Text = tvSol.SelectedNode.Index.ToString();
					//tALSnb.Text = "1";
					AlsTOT_orig.Text = "";
					tAGprice.Text = "";
					tPxPrice.Text = "";
					tALSnb.Text = "";
					AlterTOT.Text = "";
					if (in_opera == 'C') for (int r = lvOrder.Items.Count - 1; r > -1; r--) delLvOrderALL(r);
					lcurSol_Status.Text = MainMDI.Find_One_Field("select status_Rev from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text.Replace("'", "''") + "'");
					break;
			}
            lRevTOT.Text = MainMDI.Curr_FRMT(MainMDI.QREV_TOT(lCurrIQID.Text, lCurSoln.Text));
		}

		private void gbxTabs_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void TGen_Click(object sender, System.EventArgs e)
		{
		
		}

	    //BEGIN Prog. Methodes 

		private void del_Node()
		{
			switch (tvSol.SelectedNode.ImageIndex)
			{
				case 1: //Spec
			        del_Spc(lCurSoln.Text, lCurSPCn.Text);
					break;
				case 0: //Alias
				case 3:
                    if (lCurSPCn.Text == MainMDI.VIDE) del_Spc(lCurSoln.Text, lCurSPCn.Text);
                    else del_Als(lCurSoln.Text, lCurSPCn.Text, lCurALSn.Text);
					break;
				case 2: //Solution
				case 5:
				case 4:
	                del_Sol(tvSol.SelectedNode.Text);
		     		break;
			}
		}

		private void del_Spc(string sName, string pName)
		{
			string stSql = "SELECT PSM_Q_SPCS.SPC_LID FROM PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID " +
                " WHERE PSM_Q_SOL.Sol_Name='" + sName.Replace("'", "''") + "' AND PSM_Q_SPCS.SPC_Name='" + pName.Replace("'", "''") + "' AND PSM_Q_SOL.I_Quoteid=" + lCurrIQID.Text;
			string st = MainMDI.Find_One_Field(stSql);
			
			if (st != MainMDI.VIDE)
			{
				MainMDI.ExecSql("delete PSM_Q_SPCS where SPC_LID=" + st);
				MainMDI.Write_JFS("delete AlternA: " + sName + "/" + pName + "...Q#" + tQuoteID.Text + "------SQL=" + stSql);
				tvSol.SelectedNode.Remove();
			}
		}

		private void del_Als(string sName, string pName, string aName)
		{
            //string stSql = "SELECT PSM_Q_ALS.ALS_LID FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                //" WHERE (((PSM_Q_SOL.Sol_Name)='" + sName + "') AND ((PSM_Q_SPCS.SPC_Name)='" + pName + "') AND ((PSM_Q_ALS.ALS_Name)='" + aName + "'))";
			string stSql = "SELECT PSM_Q_ALS.ALS_LID FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
			    " WHERE PSM_Q_SOL.Sol_Name='" + sName.Replace("'", "''") + "' AND PSM_Q_SPCS.SPC_Name='" + pName.Replace("'", "''") + "' AND PSM_Q_ALS.ALS_Name='" + aName.Replace("'", "''") + "' AND PSM_Q_SOL.I_Quoteid=" + lCurrIQID.Text;
			string st = MainMDI.Find_One_Field(stSql);

			if (st != MainMDI.VIDE)
			{
				stSql = "delete PSM_Q_ALS where ALS_LID=" + st;
				string stSqlDetail = "delete PSM_Q_Details where ALS_LID=" + st;
				MainMDI.ExecSql(stSql);
                MainMDI.ExecSql(stSqlDetail); //delete all details because no Diagram for Qoutes
				tvSol.SelectedNode.Remove();
				Reo_ALS();
				MainMDI.Write_JFS("Alias: " + sName + "/" + pName + "/" + aName + "...Q#" + tQuoteID.Text + "------SQL=" + stSql);
			}
			//AlterTOT.Text = A00(SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
		}

		private void Reo_ALS()
		{
			int Solndx = Convert.ToInt32(lCurSolNDX.Text);
			int SpcNdx = Convert.ToInt32(lCurSPCNDX.Text);
			string SpcLid = MainMDI.Find_One_Field(" SELECT PSM_Q_ALS.SPC_LID " + 
				" FROM PSM_Q_ALS INNER JOIN PSM_Q_SPCS ON PSM_Q_ALS.SPC_LID = PSM_Q_SPCS.SPC_LID INNER JOIN PSM_Q_SOL ON PSM_Q_SPCS.Sol_LID = PSM_Q_SOL.Sol_LID " +
				" WHERE PSM_Q_SPCS.SPC_Name ='" + lCurSPCn.Text + "' AND PSM_Q_SOL.I_Quoteid =" + lCurrIQID.Text + " AND PSM_Q_SOL.Sol_Name ='" + lCurSoln.Text + "'");
			if (SpcLid != MainMDI.VIDE)
			{
				for (int i = 0; i < tvSol.Nodes[Solndx].Nodes[SpcNdx].Nodes.Count; i++)
				{
					string alsNm = tvSol.Nodes[Solndx].Nodes[SpcNdx].Nodes[i].Text;
					MainMDI.ExecSql(" UPDATE PSM_Q_ALS  SET [Rnk]='" + i + "' WHERE SPC_LID=" + SpcLid + " and ALS_Name='" + alsNm + "'");
				}
			}
		}

		private void del_Sol(string sName)
		{
			string stSql = "delete PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + sName.Replace("'", "''") + "'";
 			MainMDI.ExecSql(stSql);
			tvSol.SelectedNode.Remove();
			MainMDI.Write_JFS("delete Revision: " + sName + "...Q#" + tQuoteID.Text + "------SQL=" + stSql.Replace("'", "-"));
		}

		private void fill_SolOLD()
		{
			string stSql = "SELECT PSM_Q_IGen.Quote_ID, PSM_Q_SOL.Sol_Name,PSM_Q_SOL.img, PSM_Q_SPCS.SPC_Name, PSM_Q_ALS.ALS_Name , PSM_Q_SOL.Rnk AS s, PSM_Q_SPCS.Rnk AS p, PSM_Q_ALS.Rnk AS a " +
                " FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) " + 
				" INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " + 
				" WHERE (((PSM_Q_IGen.i_Quoteid)=" + lCurrIQID.Text + ")) ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk ";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			string Osol = "", Nsol = "", Ospc = "", Nspc = "", Nals = "";
			int s = -1, p = -1;
			while (Oreadr.Read())
			{
				Nsol = Oreadr["Sol_Name"].ToString();
				Nspc = Oreadr["SPC_Name"].ToString();
				Nals = Oreadr["ALS_Name"].ToString();
				if (Osol != Nsol)	
				{
					p = -1;
					s++; addNode_Sol(Nsol, Oreadr["img"].ToString(), "N");
					p++; addNode_Spc(Nspc, s, p, Nals);
				    //addNode_Als(Nals, s, p);
					Osol = Nsol; Ospc = Nspc;
				}
				else
				{
					if (Ospc != Nspc)
					{
						p++;
						addNode_Spc(Nspc, s, p, Nals);
						Ospc = Nspc;
					}
					else addNode_Als(Nals, s, p);
				}
			}	
			Quote_loaded = true;
			tvSol.Select();
		}

		private void fill_Sol()
		{
	        //string stSql = "SELECT PSM_Q_IGen.Quote_ID, PSM_Q_SOL.Sol_Name,PSM_Q_SOL.img, PSM_Q_SPCS.SPC_Name, PSM_Q_ALS.ALS_Name , PSM_Q_SOL.Rnk AS s, PSM_Q_SPCS.Rnk AS p, PSM_Q_ALS.Rnk AS a " +
	            //" FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) " + 
	            //" INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " + 
	            //" WHERE (((PSM_Q_IGen.i_Quoteid)=" + lCurrIQID.Text + ")) ORDER BY PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk ";
                //

		    string stSql = "SELECT PSM_Q_IGen.Quote_ID, PSM_Q_SOL.Sol_Name,PSM_Q_SOL.img,PSM_Q_SOL.status_Rev, PSM_Q_SPCS.SPC_Name, PSM_Q_ALS.ALS_Name , PSM_Q_SOL.Rnk AS s, PSM_Q_SPCS.Rnk AS p, PSM_Q_ALS.Rnk AS a " +
				" FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) " + 
				" INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " + 
				" WHERE (((PSM_Q_IGen.i_Quoteid)=" + lCurrIQID.Text + ")) ORDER BY PSM_Q_SOL.Rnk,PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk ";

			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			string Osol = "", Nsol = "", Ospc = "", Nspc = "", Nals = "", N_SpcRnk = "", O_SpcRnk = "";
			int s = -1, p = -1;
			while (Oreadr.Read())
			{
				Nsol = Oreadr["Sol_Name"].ToString();
				Nspc = Oreadr["SPC_Name"].ToString();
				Nals = Oreadr["ALS_Name"].ToString();
				N_SpcRnk = Oreadr["p"].ToString();
				if (Osol != Nsol)	
				{
					p = -1;
					s++; addNode_Sol(Nsol, Oreadr["img"].ToString(), Oreadr["status_Rev"].ToString());
					
					p++; addNode_Spc(Nspc, s, p, Nals);
					//addNode_Als(Nals, s, p);
					Osol = Nsol;
					Ospc = Nspc;
					O_SpcRnk = N_SpcRnk;
				}
				else
				{
					if (Ospc == Nspc && N_SpcRnk == O_SpcRnk) addNode_Als(Nals, s, p);
					else
					{
					    //addNode_Als(Nals, s, p);
						p++;
						addNode_Spc(Nspc, s, p, Nals);
						Ospc = Nspc;
						O_SpcRnk = N_SpcRnk;
					}
				}
			}	
			Quote_loaded = true;
			tvSol.Select();
		}

		private void addNode_Sol(string sName, string img, string Sol_stat)
		{
            int imgI = (img == "") ? 2 : Convert.ToInt32(img);
			tvSol.Nodes.Add(sName);
			tvSol.Nodes[tvSol.Nodes.Count - 1].ImageIndex = imgI;
            tvSol.Nodes[tvSol.Nodes.Count - 1].SelectedImageIndex = imgI;
			if (Sol_stat == "C") tvSol.Nodes[tvSol.Nodes.Count - 1].ForeColor = Color.Blue;
		}

		private void addNode_Spc(string spcName, int s, int p, string aName)
		{
			if (spcName == MainMDI.VIDE) addNode_SPCNA(aName, s);
			else
			{
				tvSol.Nodes[s].Nodes.Add(spcName);
				tvSol.Nodes[s].Expand();
				tvSol.Nodes[s].Nodes[tvSol.Nodes[s].Nodes.Count - 1].SelectedImageIndex = 1;
				tvSol.Nodes[s].Nodes[tvSol.Nodes[s].Nodes.Count - 1].ImageIndex = 1;
				addNode_Als(aName, s, p);
			}
		}

		private void addNode_Als(string alsName, int s, int p)
		{
			tvSol.Nodes[s].Nodes[p].Nodes.Add(alsName);
			tvSol.Nodes[s].Expand();
			tvSol.Nodes[s].Nodes[p].Nodes[tvSol.Nodes[s].Nodes[p].Nodes.Count - 1].SelectedImageIndex = 0;
			tvSol.Nodes[s].Nodes[p].Nodes[tvSol.Nodes[s].Nodes[p].Nodes.Count - 1].ImageIndex = 0;
		}

		private void addNode_SPCNA(string alsName, int s)
		{
			tvSol.Nodes[s].Nodes.Add(alsName);
			tvSol.Nodes[s].Nodes[tvSol.Nodes[s].Nodes.Count - 1].SelectedImageIndex = 0;
			tvSol.Nodes[s].Nodes[tvSol.Nodes[s].Nodes.Count - 1].ImageIndex = 0;
		}

		private void fill_LVQITEM()
		{
		    //lvQITEMS.Clear();
		    //for (int i = 0; i < MainMDI.MAX_ALS_Lines; i++)
		    //{
		        //ListViewItem lvI = lvQITEMS.Items.Add("");
		        //if (curr_ALS[i, 0] != "")
		        //{
		            //for (int j = 1; j < MainMDI.MAX_ALS_COLs; j++)
		                //lvI.SubItems.Add(curr_ALS[i, j]);
		        //}
		        //else break;
		    //}
		}

		private void init_Curr_ALS()
		{
		    //als_NDX = 0;
		    //for (int i = 0; i < MainMDI.MAX_ALS_Lines; i++)
		        //for (int j = 0; j < MainMDI.MAX_ALS_COLs; j++)
		            //curr_ALS[i, j] = "";
 		}

		private int nbOcc(string c, string st)
		{
			int nb = 0;
			for (int i = 0; i < st.Length; i++) if(st[i] == c[0]) nb++;
			return nb;
		}

		private void fill_cb_ContactsNew(long cpnyID)
		{
			string stSql = (cpnyID == 0) ? "select * FROM PSM_Contacts " : "select * FROM PSM_Contacts  where  Company_ID=" + cpnyID + "";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			cbContacts.Items.Clear();
			cbCPmgr.Items.Clear();
			while (Oreadr.Read())
			{
				cbContacts.Items.Add(Oreadr["First_Name"].ToString() + " " + Oreadr["Last_Name"].ToString());
				cbCPmgr.Items.Add(Oreadr["First_Name"].ToString() + " " + Oreadr["Last_Name"].ToString());
			}
			if (cbContacts.Items.Count > 0)
			{
				cbContacts.Text = cbContacts.Items[0].ToString();
				cbCPmgr.Text = cbContacts.Items[0].ToString();
			}
			OConn.Close();
		}

		private void fill_cb_Contacts(long cpnyID)
		{
			//string stSql = "select * FROM PSM_Contacts  where  Company_ID=" + cpnyID + "";
			string stSql = (in_opera == 'N') ? "select * FROM PSM_Contacts  where  Company_ID=" + cpnyID + "and JOBTitle<>'~~' Order by First_Name" : "select * FROM PSM_Contacts  where  Company_ID=" + cpnyID + "  Order by First_Name";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			cbContacts.Items.Clear();
			cbCPmgr.Items.Clear();
			while (Oreadr.Read())
			{
				cbContacts.Items.Add(Oreadr["First_Name"].ToString() + " " + Oreadr["Last_Name"].ToString());
				cbCPmgr.Items.Add(Oreadr["First_Name"].ToString() + " " + Oreadr["Last_Name"].ToString());
			}
			if (cbContacts.Items.Count > 0)
			{
				cbContacts.Text = cbContacts.Items[0].ToString();
				cbCPmgr.Text = cbContacts.Items[0].ToString();
			}
			OConn.Close();
		}

		private void fill_cb_Terms()
		{
			string stSql = "select Descr FROM PSM_Terms";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			cbTerms.Items.Clear();
			while (Oreadr.Read()) cbTerms.Items.Add(Oreadr[0].ToString());
			OConn.Close();
		}

		private void fill_cb_Via()
		{
			string stSql = "select ShipEng FROM PSM_ShipMeth";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			cbShipVia.Items.Clear();
			while (Oreadr.Read()) cbShipVia.Items.Add(Oreadr[0].ToString());
			OConn.Close();
		}

		private void fill_cb_Inco()
		{
			string stSql = "select IT_DESC FROM PSM_IncoTerm";
   		    SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			cbIncoTerm.Items.Clear();
			while (Oreadr.Read()) cbIncoTerm.Items.Add(Oreadr[0].ToString());
			OConn.Close();
		}

		private void save_Adrs(char c_adrs)
		{
			string stSql = "";
			switch (c_adrs)
			{
		    	case 'Q':
					stSql = "UPDATE PSM_Company SET [Q_Adrs]='" + lQA.Text + "' WHERE Cpny_ID=" + lcpnyID.Text;
					break;
				case 'S':
					stSql = "UPDATE PSM_Company SET [S_Adrs]='" + lSA.Text + "' WHERE Cpny_ID=" + lcpnyID.Text;
					break;
				case 'I':
					stSql = "UPDATE PSM_Company SET [I_Adrs]='" + lIA.Text + "' WHERE Cpny_ID=" + lcpnyID.Text;
					break;
				case 'P':
					stSql = "UPDATE PSM_Company SET [P_Adrs]='" + lPA.Text + "' WHERE Cpny_ID=" + lcpnyID.Text;
					break;
			}
			MainMDI.ExecSql(stSql);
		}

        private void fill_NewMLTP(string _CAN, string _US, string _EURO)
        {
            STDMultp_CAN = _CAN;
            STDMultp_US = _US;
            STDMultp_EURO = _EURO;
            //get default Mltp based on activity 
            if (opCan.Checked)
                STDMultp.Text = STDMultp_CAN;
            else
            {
                if (opEuro.Checked) STDMultp.Text = STDMultp_EURO;
                else STDMultp.Text = STDMultp_US;
            }
        }

		private void fill_Company_Info(string cpnyName, char adrs)
		{
            string stSql = "SELECT PSM_Company.*, PSM_CmpnyTYPE.multpl1, PSM_CmpnyTYPE.multpl1_US,PSM_CmpnyTYPE.multpl1_EURO,  PSM_CmpnyTYPE.CpnyType FROM PSM_Company INNER JOIN PSM_CmpnyTYPE ON PSM_Company.CustomerType = PSM_CmpnyTYPE.CpnyType_ID where  Cpny_Name1='" + cpnyName.Replace("'", "''") + "'";
        	SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				if (adrs == '*')
				{
					lcpnyID.Text = Oreadr["Cpny_ID"].ToString();
				    //Imp_cpnyID = Oreadr["Cpny_ID"].ToString();
					lAdrs.Text = Oreadr["M_Adrs"].ToString(); //+ ", " + Oreadr["City"].ToString() + ", " + Oreadr["Province_State"].ToString() + ", " + Oreadr["Country_Name"].ToString();
                    lActivty.Text = Oreadr["CpnyType"].ToString();
                    fill_NewMLTP(Oreadr["multpl1"].ToString(), Oreadr["multpl1_US"].ToString(), Oreadr["multpl1_EURO"].ToString());

                    //gets current MLTP if exists else it gets default One
                    string _st = MainMDI.Find_One_Field("select " + Curr_SQLMLTP + " from PSM_Cmpny_CurrMLTP where Cpny_ID=" + lcpnyID.Text);
                    if (_st != MainMDI.VIDE)
                    {
                        tCust_Mult.Text = _st;
                    }
                    else tCust_Mult.Text = STDMultp.Text;
                    lFax.Text = Oreadr["Fax"].ToString();
					string st = MainMDI.Find_One_Field("select Descr from PSM_Terms where InTermId=" + Oreadr["TermID"].ToString());
					if (st != MainMDI.VIDE) cbTerms.Text = st;
					st = MainMDI.Find_One_Field("select ShipEng from PSM_ShipMeth where ship_ID=" + Oreadr["ShipVia_ID"].ToString());
					if (st != MainMDI.VIDE) cbShipVia.Text = st;
					st = MainMDI.Find_One_Field("select IT_DESC from PSM_IncoTerm where IT_ID=" + Oreadr["IncoTerm_ID"].ToString());
					if (st != MainMDI.VIDE) cbTerms.Text = st;
					cbCurr.Text = Oreadr["Currency"].ToString();
				}
				else
				{
					switch (adrs)
					{
						case 'Q':
						    lQA.Text = (Oreadr["Q_Adrs"].ToString().Length < 4) ? Oreadr["M_Adrs"].ToString() : Oreadr["Q_Adrs"].ToString().Replace("\r\n", " ");
							break;
						case 'S':
							//lSA.Text = Oreadr["S_Adrs"].ToString();
							lSA.Text = (Oreadr["S_Adrs"].ToString().Length < 4) ? Oreadr["M_Adrs"].ToString() : Oreadr["S_Adrs"].ToString().Replace("\r\n", " ");
							break;
						case 'I':
							//lIA.Text = Oreadr["I_Adrs"].ToString();
							lIA.Text = (Oreadr["I_Adrs"].ToString().Length < 4) ? Oreadr["M_Adrs"].ToString() : Oreadr["I_Adrs"].ToString().Replace("\r\n", " ");
							break;
						case 'P':
							//lPA.Text = Oreadr["P_Adrs"].ToString();
							lPA.Text = (Oreadr["P_Adrs"].ToString().Length < 4) ? Oreadr["M_Adrs"].ToString() : Oreadr["P_Adrs"].ToString().Replace("\r\n", " ");
							break;
					}
				}
			}
			OConn.Close();
		}

		private void fill_details()
		{
			OptionCount = 0;
			ItemCount = 0;
			Opt_added = false;
            string stSql = "SELECT PSM_Q_Details.*, PSM_Q_SOL.I_Quoteid, PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name, PSM_Q_ALS.ALS_Name, PSM_Q_ALS.PxPrice,PSM_Q_ALS.AGPrice ,PSM_Q_ALS.AlsQty,PSM_Q_ALS.SV_Ovrg " +
				" FROM ((PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID) INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID " +
				" WHERE (PSM_Q_SOL.I_Quoteid=" + lCurrIQID.Text + " AND PSM_Q_SOL.Sol_Name='" + lCurSoln.Text + "' AND PSM_Q_SPCS.SPC_Name='" + lCurSPCn.Text.Replace("'", "''") + "' AND PSM_Q_ALS.ALS_Name='" + lCurALSn.Text.Replace("'", "''") +
				"') ORDER BY PSM_Q_Details.Rnk";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
            //added 14/06/07
            AlsTOT_orig.Text = "";
            tAGprice.Text = "";
            tPxPrice.Text = "";
            tALSnb.Text = "1";
            AlsTOT.Clear();
            //added 14/06/07

            lvQITEMS.BeginUpdate();
			while (Oreadr.Read())
			{
				if (Tools.Conv_Dbl(tPxPrice.Text) == 0 && Oreadr["PxPrice"].ToString() != "0")
				{
					tPxPrice.Text = MainMDI.A00(Oreadr["PxPrice"].ToString());
					tAGprice.Text = MainMDI.A00(Oreadr["AGPrice"].ToString());
					tALSnb.Text = Oreadr["AlsQty"].ToString();
					AlsTOT.Text = MainMDI.A00(Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["PxPrice"].ToString()) / Tools.Conv_Dbl(Oreadr["AlsQty"].ToString()), MainMDI.NB_DEC_AFF)));
                    chk_savOVRG.Checked = (Oreadr["SV_Ovrg"].ToString() == "True");
				}
			    //if (Oreadr["Desc"].ToString() == MainMDI.arr_EFSdict[21, 0] + "=  " || Oreadr["Desc"].ToString() == MainMDI.arr_EFSdict[21, 1] + "=  ") Opt_added = true;
				ListViewItem lvI = lvQITEMS.Items.Add("");
				//if (in_opera != 'C') lvI.Checked = (Oreadr["Xch_Mult"].ToString() == "1");
                lvI.Checked = true;
				lvI.SubItems.Add(Oreadr["Aff_ID"].ToString());
				if (Oreadr["Aff_ID"].ToString() != ".")
				{
					if (Oreadr["Aff_ID"].ToString()!= " ") { lvI.BackColor = Color.Salmon; ItemCount = Convert.ToInt32(Oreadr["Aff_ID"].ToString()); }
				}
				else	
				{
					if (Oreadr["Desc"].ToString().IndexOf("= ", 0) != -1) { lvI.BackColor = Color.LightYellow; Opt_added = true; }
					else OptionCount++;
				}
				lvI.SubItems.Add(Oreadr["Desc"].ToString());
				if (Oreadr["Qty"].ToString() != "0") lvI.SubItems.Add(Oreadr["Qty"].ToString());
				else lvI.SubItems.Add("");
				if (Oreadr["Mult"].ToString() != "0") lvI.SubItems.Add(MainMDI.A00(Oreadr["Mult"].ToString()));
                else lvI.SubItems.Add("");
				if (Oreadr["Uprice"].ToString() != "0") lvI.SubItems.Add(MainMDI.A00(Oreadr["Uprice"].ToString()));
				else lvI.SubItems.Add("");
		        //if (Oreadr["Xch_Mult"].ToString() != "0") lvI.SubItems.Add(MainMDI.A00(Oreadr["Xch_Mult"].ToString())); else lvI.SubItems.Add("");
				if (Oreadr["Ext"].ToString() != "0")
				{
                    //int _ndxgrp = Int32.Parse(Oreadr["Xch_Mult"].ToString());
                    int _ndxgrp = (int)Tools.Conv_Dbl(Oreadr["Xch_Mult"].ToString()); //Xch_Mult saves item_group
                    string grp = (_ndxgrp > 0) ? CB_Group.Items[_ndxgrp - 1].ToString() : "A";
					lvI.SubItems.Add(grp);
					lvI.SubItems.Add(MainMDI.A00(Oreadr["Ext"].ToString()));
				}
				else { lvI.SubItems.Add(""); lvI.SubItems.Add(""); }
			    //if (Oreadr["Uprice"].ToString() != "0" && Oreadr["Qty"].ToString() != "0" && Oreadr["Xch_Mult"].ToString() != "0")
			    //{
			        //lvI.SubItems.Add(MainMDI.A00(Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["Qty"].ToString()) * Tools.Conv_Dbl(Oreadr["Uprice"].ToString()) * Tools.Conv_Dbl(tCust_Mult.Text) * Tools.Conv_Dbl(Oreadr["Xch_Mult"].ToString()), Charger.NB_DEC_AFF))));
			        //P_AlsTot(stSql);
			    //}
			    //else lvI.SubItems.Add("");
				if (Oreadr["LeadTime"].ToString() != "0") lvI.SubItems.Add(Oreadr["LeadTime"].ToString());
				else lvI.SubItems.Add("");
				lvI.SubItems.Add(""); //for nbDef
				lvI.SubItems.Add(Oreadr["PN"].ToString()); //for PN
				if (in_opera == 'C') lvI.SubItems.Add(Oreadr["Detail_LID"].ToString());
				else lvI.SubItems.Add("");
				lvI.SubItems.Add(Oreadr["Q_tec_Val"].ToString());
			} 
			tXRATE.Text = "";
            lvQITEMS.EndUpdate();
		}

		private bool fill_Qot(long Qid, string CpnyName)
		{
            //string stSql = "SELECT PSM_Q_IGen.*, PSM_Company.Cpny_Name1, PSM_SALES_AGENTS_8.First_Name & ' ' & PSM_SALES_AGENTS_8.Last_Name AS employ, PSM_Terms.Descr, PSM_IncoTerm.IT_DESC, PSM_ShipMeth.ShipEng, PSM_Contacts.[First_Name], PSM_Contacts.[Last_Name], PSM_SALES_AGENTS.First_Name & ' ' & PSM_SALES_AGENTS.Last_Name AS SI_nm, PSM_SALES_AGENTS_2.First_Name & ' ' & PSM_SALES_AGENTS_2.Last_Name AS SO_nm, PSM_SALES_AGENTS_1.First_Name & ' ' & PSM_SALES_AGENTS_1.Last_Name AS SE_nm, PSM_SALES_AGENTS_3.First_Name & ' ' & PSM_SALES_AGENTS_3.Last_Name AS SP_nm, PSM_SALES_AGENTS_4.First_Name & ' ' & PSM_SALES_AGENTS_4.Last_Name as AD_nm, PSM_SALES_AGENTS_5.First_Name & ' ' & PSM_SALES_AGENTS_5.Last_Name as AI_nm, PSM_SALES_AGENTS_6.First_Name & ' ' & PSM_SALES_AGENTS_6.Last_Name AS AE_nm, PSM_SALES_AGENTS_7.First_Name & ' ' & PSM_SALES_AGENTS_7.Last_Name AS AP_nm " +
                //" FROM (((((((((((((PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID) INNER JOIN PSM_Contacts ON PSM_Q_IGen.Contact_ID = PSM_Contacts.Contact_ID) INNER JOIN PSM_Terms ON PSM_Q_IGen.Term_ID = PSM_Terms.InTermId) INNER JOIN PSM_ShipMeth ON PSM_Q_IGen.Via_ID = PSM_ShipMeth.ship_ID) INNER JOIN PSM_IncoTerm ON PSM_Q_IGen.IncoTerm_ID = PSM_IncoTerm.IT_ID) INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.SI = PSM_SALES_AGENTS.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_2 ON PSM_Q_IGen.SO = PSM_SALES_AGENTS_2.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_1 ON PSM_Q_IGen.SE = PSM_SALES_AGENTS_1.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_3 ON PSM_Q_IGen.SP = PSM_SALES_AGENTS_3.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_4 ON PSM_Q_IGen.AD = PSM_SALES_AGENTS_4.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_5 ON PSM_Q_IGen.AI = PSM_SALES_AGENTS_5.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_6 ON PSM_Q_IGen.AE = PSM_SALES_AGENTS_6.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_7 ON PSM_Q_IGen.AP = PSM_SALES_AGENTS_7.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_8 ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS_8.SA_ID " +
                //" WHERE (((PSM_Q_IGen.Quote_ID)=" + Qid + ") and ((PSM_Company.Cpny_Name1)='" + CpnyName + "') ) ORDER BY PSM_Q_IGen.Quote_ID, PSM_Q_IGen.CPNY_ID ";
            string stSql = "SELECT PSM_Q_IGen.*, PSM_Company.Cpny_Name1, PSM_SALES_AGENTS_8.First_Name + ' ' + PSM_SALES_AGENTS_8.Last_Name AS employ, PSM_Terms.Descr, PSM_IncoTerm.IT_DESC, PSM_ShipMeth.ShipEng, PSM_Contacts.First_Name, PSM_Contacts.Last_Name, PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS SI_nm, PSM_SALES_AGENTS_2.First_Name + ' ' + PSM_SALES_AGENTS_2.Last_Name AS SO_nm, PSM_SALES_AGENTS_1.First_Name + ' ' + PSM_SALES_AGENTS_1.Last_Name AS SE_nm, PSM_SALES_AGENTS_3.First_Name + ' ' + PSM_SALES_AGENTS_3.Last_Name AS SP_nm, PSM_SALES_AGENTS_4.First_Name + ' ' + PSM_SALES_AGENTS_4.Last_Name AS AD_nm, PSM_SALES_AGENTS_5.First_Name + ' ' + PSM_SALES_AGENTS_5.Last_Name AS AI_nm, PSM_SALES_AGENTS_6.First_Name + ' ' + PSM_SALES_AGENTS_6.Last_Name AS AE_nm, PSM_SALES_AGENTS_7.First_Name + ' ' + PSM_SALES_AGENTS_7.Last_Name AS AP_nm, [PSM_SALES_AGENTS_9].[First_Name] + ' ' + [PSM_SALES_AGENTS_9].[Last_Name] AS IPM, PSM_Contacts_1.First_Name + ' ' + PSM_Contacts_1.Last_Name AS CPM" +
                " FROM (((((((((((((((PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID) INNER JOIN PSM_Contacts ON PSM_Q_IGen.Contact_ID = PSM_Contacts.Contact_ID) INNER JOIN PSM_Terms ON PSM_Q_IGen.Term_ID = PSM_Terms.InTermId) INNER JOIN PSM_ShipMeth ON PSM_Q_IGen.Via_ID = PSM_ShipMeth.ship_ID) INNER JOIN PSM_IncoTerm ON PSM_Q_IGen.IncoTerm_ID = PSM_IncoTerm.IT_ID) INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.SI = PSM_SALES_AGENTS.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_2 ON PSM_Q_IGen.SO = PSM_SALES_AGENTS_2.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_1 ON PSM_Q_IGen.SE = PSM_SALES_AGENTS_1.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_3 ON PSM_Q_IGen.SP = PSM_SALES_AGENTS_3.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_4 ON PSM_Q_IGen.AD = PSM_SALES_AGENTS_4.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_5 ON PSM_Q_IGen.AI = PSM_SALES_AGENTS_5.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_6 ON PSM_Q_IGen.AE = PSM_SALES_AGENTS_6.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_7 ON PSM_Q_IGen.AP = PSM_SALES_AGENTS_7.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_8 ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS_8.SA_ID) INNER JOIN PSM_SALES_AGENTS AS PSM_SALES_AGENTS_9 ON PSM_Q_IGen.IPmgr = PSM_SALES_AGENTS_9.SA_ID) INNER JOIN PSM_Contacts AS PSM_Contacts_1 ON PSM_Q_IGen.CPmgr = PSM_Contacts_1.Contact_ID " +
                " WHERE (((PSM_Company.Cpny_Name1)='" + CpnyName.Replace("'", "''") + "') AND ((PSM_Q_IGen.Quote_ID)=" + Qid + ")) ORDER BY PSM_Q_IGen.Quote_ID, PSM_Q_IGen.CPNY_ID";

			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				//cbTerms.Enabled = false;
				tQuoteID.Text = Qid.ToString();
				lCurrIQID.Text = Oreadr["i_Quoteid"].ToString();
				tProjNAME.Text = Oreadr["ProjectName"].ToString();
				lQstatus.Text = Oreadr["del"].ToString();
                opCan.Checked = (Oreadr["curr"].ToString() == "C");
                opUS.Checked = (Oreadr["curr"].ToString() == "U");
                opEuro.Checked = (Oreadr["curr"].ToString() == "E");

                cbCompany.Text = CpnyName;
              	lCpnyName.Text = CpnyName;
				btnCHNGCmpny.Visible = true;

				cbEmploy.Text = Oreadr["employ"].ToString();
                tOpendate.Text = Oreadr["Opndate"].ToString();
				lQDopen.Text = tOpendate.Value.ToShortDateString();
				tOpendate.Visible = false;
				lQDopen.Visible = true;

                cbContacts.Text = Oreadr["First_Name"].ToString() + " " + Oreadr["Last_Name"].ToString();
				lContacts.Text = Oreadr["First_Name"].ToString() + " " + Oreadr["Last_Name"].ToString();
				cbContacts.Visible = false;
				lContacts.Visible = true;
				btnchngCN.Visible = true;

               	cbCPmgr.Text = Oreadr["CPM"].ToString();
	            lcbCPmgr.Text = Oreadr["CPM"].ToString();
				lcbCPmgr.Visible = true;
				btnchngCP.Visible = true;
				cbCPmgr.Visible = false;

 				cbIPmgr.Text = Oreadr["IPM"].ToString();
			    //tCust_Mult.Text = Oreadr["Cust_Mult"].ToString();
                cbTerms.Text = Oreadr["Descr"].ToString();

                cbShipVia.Text = Oreadr["ShipEng"].ToString();
				cbIncoTerm.Text = Oreadr["IT_DESC"].ToString();

			    //cbSi.Text = Oreadr["SI_nm"].ToString();
                int ndx_teri = Int32.Parse(Oreadr["SI"].ToString());
                if (ndx_teri >= cb_Territo.Items.Count) ndx_teri = 0;
                cb_Territo.SelectedIndex = ndx_teri;

			    //MessageBox.Show("/" + Oreadr["SI_nm"].ToString() + "/" + "    cb= " + cbSi.Text);
				cbSo.Text = Oreadr["SO_nm"].ToString();
				cbSe.Text = Oreadr["SE_nm"].ToString();
				cbSp.Text = Oreadr["SP_nm"].ToString();
				cbSS.Text = Oreadr["SS"].ToString();
				cbAI.Text = Oreadr["AI_nm"].ToString();
				cbAE.Text = Oreadr["AE_nm"].ToString();
				cbAP.Text = Oreadr["AP_nm"].ToString();
           		cbADD.Text = Oreadr["AD_nm"].ToString();

				cbAS.Text = Oreadr["AS"].ToString();
				switch (Oreadr["Lang"].ToString())
				{
					case "B":
						cbLang.Text = "Billingual";
						break;
					case "F":
						cbLang.Text = "French";
						break;
					case "E":
						cbLang.Text = "English";
						break;
				}
			    //cbLang.Visible = false;
			    //Lang.Text = cbLang.Text;
			    //Lang.Visible = true;
          		lQA.Text = Oreadr["QA"].ToString().Replace("\r\n", " ");
				lSA.Text = Oreadr["SA"].ToString().Replace("\r\n", " ");
				lPA.Text = Oreadr["PA"].ToString().Replace("\r\n", " ");
				lIA.Text = Oreadr["IA"].ToString().Replace("\r\n", " ");
				tGCmnt.Text = Oreadr["Cmnt"].ToString();
				lQsave.Text = "Y";
				 
			    //lCurr_opera.Text = "E"; //E:edit N:add 
				return true;
			}
            MessageBox.Show("This Quote Does not Exist.. !!! ");
			return false;
		}

		private void fill_cbSal_AG(string SA)
		{
			string stAND = "";
			stAND = (lCurr_opera.Text == "N") ? " AND status=1 " : "";
			string stSql ="select First_Name, Last_Name FROM PSM_SALES_AGENTS where SA='" + SA + "' " + stAND + " AND status='1'"; //: "select First_Name, Last_Name FROM PSM_SALES_AGENTS where SA='" + SA + "'";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				stSql = Oreadr[0].ToString() + " " + Oreadr[1].ToString();
				if (SA == "S")
				{
					cbEmploy.Items.Add(stSql); //employee
					cbIPmgr.Items.Add(stSql); //Project Mangr
					cbSe.Items.Add(stSql);
					cbSi.Items.Add(stSql);
					cbSo.Items.Add(stSql);
					cbSp.Items.Add(stSql);
					cbSS.Items.Add(stSql);
				}
				else
				{
					cbADD.Items.Add(stSql);
					cbAE.Items.Add(stSql);
					cbAP.Items.Add(stSql);
					cbAI.Items.Add(stSql);
					cbAS.Items.Add(stSql);
				}
			}
			OConn.Close();
		}

		private void fill_cbCompany()
		{
			string stSql = "select Cpny_Name1 FROM PSM_Company order by Cpny_Name1";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
		    //int nb = 0;
			while (Oreadr.Read())
			{
				cbCompany.Items.Add(Oreadr["Cpny_Name1"].ToString());
				cbCQA.Items.Add(Oreadr["Cpny_Name1"].ToString());
				cbCSA.Items.Add(Oreadr["Cpny_Name1"].ToString());
				cbCIA.Items.Add(Oreadr["Cpny_Name1"].ToString());
				cbCPA.Items.Add(Oreadr["Cpny_Name1"].ToString());
				//nb++;
			}
			OConn.Close();
		    //MessageBox.Show("NB company= " + nb.ToString());
		}

		private bool Import_ChPrices()
		{
			//string stout = "";
			string stsql = "SELECT TBLTOXL01.COMPONENT, TBLTOXL01.[5], TBLTOXL01.[10], TBLTOXL01.[15], TBLTOXL01.[20], TBLTOXL01.[25], TBLTOXL01.[30], TBLTOXL01.[35], TBLTOXL01.[40], TBLTOXL01.[50], TBLTOXL01.[60], TBLTOXL01.[70], TBLTOXL01.[75], TBLTOXL01.[80], TBLTOXL01.[100], TBLTOXL01.[125], TBLTOXL01.[150], TBLTOXL01.[175], TBLTOXL01.[200], TBLTOXL01.[225], TBLTOXL01.[250], TBLTOXL01.[275], TBLTOXL01.[300], TBLTOXL01.[325], TBLTOXL01.[350], TBLTOXL01.[375], TBLTOXL01.[400], TBLTOXL01.[500], TBLTOXL01.[600], TBLTOXL01.[750], TBLTOXL01.[800], TBLTOXL01.[900], TBLTOXL01.[1000], TBLTOXL01.REF_CHRG FROM TBLTOXL01 WHERE (TBLTOXL01.cRec)='T'";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			SqlCommandBuilder OBld = new SqlCommandBuilder();
			SqlDataAdapter OAdpXL = new SqlDataAdapter(stsql, OConn);
			SqlDataAdapter OAdpPrice = new SqlDataAdapter("select * from PSM_Charger_price", OConn);

			string tblNameXL = "TBLTOXL01";
			string tblNamePrice = "PSM_Charger_price";
			DataSet DsXL = new DataSet(tblNameXL);
			DataSet DsPrice = new DataSet(tblNamePrice);
			OAdpXL.Fill(DsXL, tblNameXL);
			OAdpPrice.Fill(DsPrice, tblNamePrice);

			SqlCommandBuilder OBuild = new SqlCommandBuilder(OAdpPrice);
			for (int i = 0; i < DsXL.Tables[0].Rows.Count; i++)
			{
				for (int j = 1; j < DsXL.Tables[0].Columns.Count - 1; j++)
				{
					//MessageBox.Show("Charger_Name= " + DsXL.Tables[tblNameXL].Rows[i]["REF_CHRG"].ToString() + "  I=" + i + " Col= " + DsXL.Tables[tblNameXL].Columns[j].ColumnName);
					DataRow lPrice = DsPrice.Tables[tblNamePrice].NewRow();
					lPrice["Charger_Name"] = DsXL.Tables[tblNameXL].Rows[i]["REF_CHRG"].ToString();
					lPrice["AMP"] = DsXL.Tables[tblNameXL].Columns[j].ColumnName;
					lPrice["Price"] = DsXL.Tables[tblNameXL].Rows[i][j].ToString();
					lPrice["DLV_Date"] = "4";
					DsPrice.Tables[tblNamePrice].Rows.Add(lPrice);
				}
			}
			OAdpPrice.Update(DsPrice, tblNamePrice);
			OConn.Close();
			return true;
		}

		private bool del_Charger_Price()
		{
			//string stsql = "SELECT TBLTOXL01.COMPONENT, TBLTOXL01.[5], TBLTOXL01.[10], TBLTOXL01.[15], TBLTOXL01.[20], TBLTOXL01.[25], TBLTOXL01.[30], TBLTOXL01.[35], TBLTOXL01.[40], TBLTOXL01.[50], TBLTOXL01.[60], TBLTOXL01.[70], TBLTOXL01.[75], TBLTOXL01.[80], TBLTOXL01.[100], TBLTOXL01.[125], TBLTOXL01.[150], TBLTOXL01.[175], TBLTOXL01.[200], TBLTOXL01.[225], TBLTOXL01.[250], TBLTOXL01.[275], TBLTOXL01.[300], TBLTOXL01.[325], TBLTOXL01.[350], TBLTOXL01.[375], TBLTOXL01.[400], TBLTOXL01.[500], TBLTOXL01.[600], TBLTOXL01.[750], TBLTOXL01.[800], TBLTOXL01.[900], TBLTOXL01.[1000], TBLTOXL01.REF_CHRG FROM TBLTOXL01 WHERE (TBLTOXL01.cRec)='T'";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			SqlCommandBuilder OBld = new SqlCommandBuilder();
			//SqlDataAdapter OAdpXL = new SqlDataAdapter(stsql, OConn);
			SqlDataAdapter OAdpPrice = new SqlDataAdapter("delete PSM_Charger_price", OConn);
			string tblNamePrice = "PSM_Charger_price";
			DataSet DsPrice = new DataSet(tblNamePrice);
			OAdpPrice.Fill(DsPrice, tblNamePrice);
			SqlCommandBuilder OBuild = new SqlCommandBuilder(OAdpPrice);
			//debut delete
			OConn.Close();
			return (DsPrice.Tables.Count == 0);
		}

		private bool del_Charger_Price_Fast()
		{
			//string stsql = "SELECT TBLTOXL01.COMPONENT, TBLTOXL01.[5], TBLTOXL01.[10], TBLTOXL01.[15], TBLTOXL01.[20], TBLTOXL01.[25], TBLTOXL01.[30], TBLTOXL01.[35], TBLTOXL01.[40], TBLTOXL01.[50], TBLTOXL01.[60], TBLTOXL01.[70], TBLTOXL01.[75], TBLTOXL01.[80], TBLTOXL01.[100], TBLTOXL01.[125], TBLTOXL01.[150], TBLTOXL01.[175], TBLTOXL01.[200], TBLTOXL01.[225], TBLTOXL01.[250], TBLTOXL01.[275], TBLTOXL01.[300], TBLTOXL01.[325], TBLTOXL01.[350], TBLTOXL01.[375], TBLTOXL01.[400], TBLTOXL01.[500], TBLTOXL01.[600], TBLTOXL01.[750], TBLTOXL01.[800], TBLTOXL01.[900], TBLTOXL01.[1000], TBLTOXL01.REF_CHRG FROM TBLTOXL01 WHERE (TBLTOXL01.cRec)='T'";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = "delete PSM_Charger_price";
			Object CountRes = Ocmd.ExecuteScalar();
			OConn.Close();
			//MessageBox.Show("Deleted = " + CountRes.ToString());

			return true;
		}

		private void btnAQ_Click(object sender, System.EventArgs e)
		{
	        //if (dAdrs.chkSave.Checked) save_Adrs('Q');
			QuoteXAdrs('Q', lQA.Text);
		}

		private void QuoteXAdrs(char c_adrs, string adrs)
		{
			//if ((adrs.IndexOf(", ") == 4)
			dlgAdrs dAdrs = new dlgAdrs(adrs);
		    //dAdrs.chkSave.Visible = true;
			dAdrs.ShowDialog();
			if (dAdrs.tStreet.Text != "")
			{
				switch (c_adrs)
				{
					case 'Q':
						lQA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text + "," + dAdrs.tZip.Text + "," + dAdrs.cbCountry.Text;
						break;
					case 'S':
						lSA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text + "," + dAdrs.tZip.Text + "," + dAdrs.cbCountry.Text;
						break;
					case 'I':
						lIA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text + "," + dAdrs.tZip.Text + "," + dAdrs.cbCountry.Text;
						break;
					case 'P':
						lPA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text + "," + dAdrs.tZip.Text + "," + dAdrs.cbCountry.Text;
						break;
				}
			}
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("Hiiiiiiiiiiiiiii");
		}
		
		private bool Entry_OK()
		{
			return (tQuoteID.Text != "" && lEmp_ID.Text != "" && lEmp_ID.Text != "0" && lContact_ID.Text != "" && lContact_ID.Text != "0" && lLang.Text != "" && lcpnyID.Text != "" && lcpnyID.Text != "0");
		}

		private bool Save_Q_IGen()
		{
			bool t1 = false;

			if (Entry_OK())
			{
				if (tProjNAME.Text == "") tProjNAME.Text = tQuoteID.Text + "-" + cbCompany.Text.Substring(0, 3);
				if (lCurr_opera.Text == "N")
				{
					string stSql = "INSERT INTO PSM_Q_IGen ([Quote_ID],[CPNY_ID],[Employ_ID], " + 
						" [ProjectName],[Opndate],[Clsdate],[Contact_ID],[Cust_Mult],  " + 
						" [Term_ID],[Via_ID],[IncoTerm_ID], " + 
						" [SI],[SO],[SE],[SP],[SS], " + 
						" [AD],[AI],[AE],[AP],[AS], " + 
						" [QA],[SA],[PA],[IA] , " + 
						" [Lang]," +
						" [DEL]," + " [IPmgr]," + " [CPmgr]," + " [curr]," +
						" [Cmnt]) VALUES ('" +
						tQuoteID.Text + "', '" +
						lcpnyID.Text + "', '" +
						lEmp_ID.Text + "', '" +
						tProjNAME.Text.Replace("'", "''") + "', " +
						MainMDI.SSV_date(tOpendate.Text) + ", " +
						MainMDI.SSV_date("01/01/2055") + ", '" +
						lContact_ID.Text + "', '" +
						tCust_Mult.Text + "', '" +
						lTerm_ID.Text + "', '" +
						lVia_ID.Text + "', '" +
						lIncoT_ID.Text + "', '" +
						lSi.Text + "', '" +
						lSO.Text + "', '" +
						lSE.Text + "', '" +
						lSP.Text + "', '" +
						cbSS.Text + "', '" +
						lAD.Text + "', '" +
						lAI.Text + "', '" +
						lAE.Text + "', '" +
						lAP.Text + "', '" +
						cbAS.Text + "', '" +
						lQA.Text.Replace("'", "''") + "', '" +
						lSA.Text.Replace("'", "''") + "', '" +
						lPA.Text.Replace("'", "''") + "', '" +
						lIA.Text.Replace("'", "''") + "', '" +
						lLang.Text + "', '" +
						lQstatus.Text + "', '" + lIpmgr.Text + "', '" + lCpmgr.Text + "', '" + lcurDol.Text.Substring(0, 1) + "', '" +
						tGCmnt.Text + "')";
					t1 = MainMDI.ExecSql(stSql);
					MainMDI.Write_JFS(stSql);
					lSave.Text = "S";
					lCurr_opera.Text = "E";
					in_opera = 'E';
					string stId = MainMDI.Find_One_Field("select I_Quoteid from PSM_Q_IGen where Quote_ID=" + tQuoteID.Text + " AND CPNY_ID=" + lcpnyID.Text);
					//MessageBox.Show("ID= " + MainMDI.stXP + "     foundID= " + stId);
					if (stId != MainMDI.VIDE) lCurrIQID.Text = stId;
					else MessageBox.Show("Error Occurs while Saving this Quote...contact your Admin !!!" + MainMDI.stXP);
				}
				else
				{
                    //Update
				    //lSS.Text = (cbSS.Text == "") ? "0" : cbSS.Text;
				    //lAS.Text = (cbAS.Text == "") ? "0" : cbAS.Text;
					string stSql = "UPDATE PSM_Q_IGen SET " +
						" [Quote_ID]=" + tQuoteID.Text + ", " +
						" [CPNY_ID]=" + lcpnyID.Text + ", " +
						" [Employ_ID]=" + lEmp_ID.Text + ", " +
						" [ProjectName]='" + tProjNAME.Text.Replace("'", "''") + "', " +
						" [Opndate]=" + MainMDI.SSV_date(tOpendate.Value.ToShortDateString()) + ", " +
						" [Clsdate]=" + MainMDI.SSV_date("01/01/2055") + ", " + //must use r_clsdate when filling LVQUOTES
						" [Contact_ID]=" + lContact_ID.Text + ", " +
						" [Term_ID]=" + lTerm_ID.Text + ", " +
						" [Via_ID]=" + lVia_ID.Text + ", " +
						" [IncoTerm_ID]=" + lIncoT_ID.Text + ", " +
						" [SI]=" + lSi.Text + ", " +
						" [SO]=" + lSO.Text + ", " +
						" [SE]=" + lSE.Text + ", " +
						" [SP]=" + lSP.Text + ", " +
						" [SS]='" + cbSS.Text + "', " +
						" [AD]=" + lAD.Text + ", " +
						" [AI]=" + lAI.Text + ", " +
						" [AE]=" + lAE.Text + ", " +
						" [AP]=" + lAP.Text + ", " +
						" [AS]='" + cbAS.Text + "', " +
						" [QA]='" + lQA.Text.Replace("'", "''") + "', " +
						" [SA]='" + lSA.Text.Replace("'", "''") + "', " +
						" [PA]='" + lPA.Text.Replace("'", "''") + "', " +
						" [IA]='" + lIA.Text.Replace("'", "''") + "', " +
						" [Lang]='" + lLang.Text + "', " +
						" [DEL]='" + lQstatus.Text + "', " +
                        " [IPmgr]='" + lIpmgr.Text + "', " +
						" [CPmgr]='" + lCpmgr.Text + "', " +
						" [curr]='" + lcurDol.Text.Substring(0, 1) + "', " +
						" [Cmnt]='" + tGCmnt.Text.Replace("'", "''") + "' " +
						" WHERE [i_Quoteid]=" + lCurrIQID.Text;
     				t1 = MainMDI.ExecSql(stSql);
					MainMDI.Write_JFS(stSql);
					lSave.Text = "U";
				}
			}
			else 
			{
				MessageBox.Show("You missed some Fields....");
				return false;
			}
			return t1;
		}

		private bool Save_Q_Adrs_Cmnt(long i_QID)
		{
			if (lQA.Text != "" || lIA.Text != "" || lPA.Text != "" || lSA.Text != "" || tGCmnt.Text != "") 
			{
				string stSql = "INSERT INTO PSM_Q_ADRS_Cmnt ([I_Quoteid],[Q_Adrs], " + 
					" [P_Adrs],[S_Adrs],[I_Adrs], " + 
					" [Cmnt]) VALUES ('" +
					i_QID.ToString() + "', '" +
					lQA.Text.Replace("'", "''") + "', '" +
					lPA.Text.Replace("'", "''") + "', '" +
					lSA.Text.Replace("'", "''") + "', '" +
					lIA.Text.Replace("'", "''") + "', '" +
					tGCmnt.Text.Replace("'", "''") + "')";
				MainMDI.ExecSql(stSql);
				MainMDI.Write_JFS(stSql);
			    //Save_Q_Adrs_Cmnt();
			}
			else 
			{
				MessageBox.Show("You missed some Fields....");
				return false;
			}
			return true;
		}

		private int fill_QID()
		{
			lock_table('Q');
		    //long Qid = MainMDI.Gen_ID_tmpQ('Q');
			long Qid = MainMDI.Gen_IDFinal('Q');
			tQuoteID.Text = "";
			switch (Qid)
			{
				case 0:
					//MessageBox.Show("Table GEN_ID is Full....");
					MessageBox.Show("Quotes IDs must be added, please contact your Administrator ....");
    				break;
				case -1:
					//MessageBox.Show("Table GEN_ID is Empty Must be Initialized....");
					MessageBox.Show("No available Quote#, GEN_IDs is empty , please contact your Administrator....");
					break;
				default:
					tQuoteID.Text = Qid.ToString();
					MainMDI.flag_QRID('Q', 'u', 1, Qid);
					break;
			}
			Unlock_table("PSM_Q_GenID");
			return Convert.ToInt32(Qid);
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
            MainMDI.ExecSql("DELETE PSM_Q_GenID");
			New100_QRID('Q', tDebQID.Text);
		}

		private void Save_Q_ALL_Details()
		{
			this.Cursor = Cursors.WaitCursor;
			if (lCurrIQID.Text != "0")
			{
				long SID = Save_SOL(lCurrIQID.Text, lCurSoln.Text, lCurSolNDX.Text, tvSol.Nodes[Convert.ToInt32(lCurSolNDX.Text)].ImageIndex.ToString());
				if (SID != 0)
				{
					long SPCID = Save_SPEC(SID, lCurSPCn.Text, lCurSPCNDX.Text);
					if (SPCID != 0)
					{
                        ref_PXAG_Price('V');
						long ALSID = Save_ALS(SPCID, lCurALSn.Text, lCurALSNDX.Text, AlsTOT_orig.Text, tPxPrice.Text, tAGprice.Text, tALSnb.Text);
                        lcurrALSLID.Text = ALSID.ToString();
						if (ALSID != 0)
						{
							//for (int i = 0; i < MainMDI.MAX_ALS_Lines; i++)
                            MainMDI.ExecSql("delete PSM_Q_Details WHERE PSM_Q_Details.ALS_LID=" + ALSID);
						    for (int i = 0; i < lvQITEMS.Items.Count; i++)
							{
							    if (lvQITEMS.Items[i].SubItems[1].Text != "")
							    {
								    if (!Save_Details(ALSID, i))
								    {
									    MessageBox.Show("Error Occurs while Saving current Details......contact your Admin !!!" + MainMDI.stXP);
									    break;
								    }
								    if (Tosave) Tosave = false;
							    }
							    else break;
							}
						}
					}
				}
			}
            this.Cursor = Cursors.Default;
 		}

		//alter. Total based on first ALS Total
		private string SPEC_TOT_TOT1(string r_IQID, string Sname, string SpecName)
		{
			string stSql = "SELECT Sum(PSM_Q_ALS.Tot) AS SommeDeTot FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " GROUP BY PSM_Q_SOL.I_Quoteid, PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name HAVING (((PSM_Q_SOL.I_Quoteid)=" + r_IQID + ") AND ((PSM_Q_SOL.Sol_Name)='" + Sname + "') AND ((PSM_Q_SPCS.SPC_Name)='" + SpecName.Replace("'", "''") + "'))";
            string res = MainMDI.Find_One_Field(stSql);
    	    if (res == MainMDI.VIDE) return "0";
		    return Convert.ToString(Math.Round(Tools.Conv_Dbl(res), MainMDI.Q_NB_DEC_AFF));
		}

        //alter. Total based on AgentPrice ALS Total
        /*		
		private string SPEC_TOT(string r_IQID, string Sname, string SpecName)
		{
			string stSql = "SELECT Sum(PSM_Q_ALS.AGPrice) AS SommeDeTot FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
				" GROUP BY PSM_Q_SOL.I_Quoteid, PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name HAVING (((PSM_Q_SOL.I_Quoteid)=" + r_IQID + ") AND ((PSM_Q_SOL.Sol_Name)='" + Sname + "') AND ((PSM_Q_SPCS.SPC_Name)='" + SpecName.Replace("'", "''") + "'))";
			string res = MainMDI.Find_One_Field(stSql);
			if (res == MainMDI.VIDE) return "0";
			return Convert.ToString(Math.Round(Tools.Conv_Dbl(res), MainMDI.Q_NB_DEC_AFF));
		}
		*/
		
		private long Save_SOL(string iQid, string s_name, string Rnk, string img)
		{
		    //string stSql = MainMDI.Find_One_Field("select Sol_LID from PSM_Q_SOL where I_Quoteid=" + iQid + " AND Sol_Name='" + s_name + "' and Rnk=" + Rnk);
		    string stSql = MainMDI.Find_One_Field("select Sol_LID from PSM_Q_SOL where I_Quoteid=" + iQid + " AND Sol_Name='" + s_name + "'");
			if (stSql != MainMDI.VIDE) return Convert.ToInt32(stSql);
			else 
			{
				stSql = "INSERT INTO PSM_Q_SOL ([I_Quoteid],[Sol_Name],[img], [Rnk]," + 
				    " [user],[date_Rev] ) VALUES ('" +
				    iQid.ToString() + "', '" +
				    s_name + "', '" +
				    img + "', '" + Rnk + "', '" + MainMDI.User + "', " + MainMDI.SSV_date(System.DateTime.Now.ToShortDateString()) + ")";
				MainMDI.ExecSql(stSql);
				MainMDI.Write_JFS(stSql);
				stSql = MainMDI.Find_One_Field("select Sol_LID from PSM_Q_SOL where I_Quoteid=" + iQid + " AND Sol_Name='" + s_name + "' and Rnk=" + Rnk);
				if (stSql != MainMDI.VIDE) return Convert.ToInt32(stSql);
				else MessageBox.Show("Error Occurs while Saving current Solution...contact your Admin !!!" + MainMDI.stXP);
				return 0;
			}
		}

		private long Save_SPEC(long SID, string spc_name, string Rnk) //, out string msg)
		{
			string stSql = "";
		    //string stSql = MainMDI.Find_One_Field("select SPC_LID from PSM_Q_SPCS where Sol_LID=" + SID.ToString() + " AND SPC_Name='" + spc_name + "' and Rnk=" + Rnk);
			if (spc_name == MainMDI.VIDE) stSql = MainMDI.Find_One_Field("select SPC_LID from PSM_Q_SPCS where Sol_LID=" + SID.ToString() + " AND SPC_Name='" + spc_name + "' and Rnk=" + Rnk);
			else stSql = MainMDI.Find_One_Field("select SPC_LID from PSM_Q_SPCS where Sol_LID=" + SID.ToString() + " AND SPC_Name='" + spc_name.Replace("'", "''") + "'");
			if (stSql != MainMDI.VIDE)
			{
				return Convert.ToInt32(stSql);
			}
			else 
			{
				stSql = "INSERT INTO PSM_Q_SPCS ([Sol_LID],[SPC_Name], " + 
					" [Rnk] ) VALUES ('" +
					SID.ToString() + "', '" +
					spc_name.Replace("'", "''") + "', '" +
					Rnk + "')";
				MainMDI.ExecSql(stSql);
				MainMDI.Write_JFS(stSql);
				stSql = MainMDI.Find_One_Field("select SPC_LID from PSM_Q_SPCS where Sol_LID=" + SID.ToString() + " AND SPC_Name='" + spc_name.Replace("'", "''") + "' and Rnk=" + Rnk);
				if (stSql != MainMDI.VIDE) return Convert.ToInt32(stSql);
				else MessageBox.Show("Error Occurs while Saving current SPEC...contact your Admin !!!" + MainMDI.stXP);
				return 0;
			}
		}

		private void ref_PXAG_Price(char opera)
		{
            if (opera != 'S') //selection
            {
                bool _conf = false;
                if (Tools.Conv_Dbl(AlsTOT.Text) > Tools.Conv_Dbl(AlsTOT_orig.Text))
                {
                    if (chk_savOVRG.Checked) _conf = false;
                    //else _conf = MainMDI.Confirm("Want to Update Primax Sell Price / Agent Price: ?");
                    //!MainMDI.Confirm("Selling Price is higher than PGESCOM Price , do you want to Save current Selling Price / Agent Price: ?");
                    //removed: 25/11/2008 else _conf = !MainMDI.Confirm("Selling Price is higher than PGESCOM Price , do you want to IMPOSE the NEW Price on all others Prices: ?");
                    else _conf = true;
                }
                else _conf = (Tools.Conv_Dbl(AlsTOT.Text) < Tools.Conv_Dbl(AlsTOT_orig.Text));
                if (_conf)
                {
                    AlsTOT.Text = MainMDI.A00(AlsTOT_orig.Text);
                    tAGprice.Text = MainMDI.A00(tPxPrice.Text);
                }
                if (Tools.Conv_Dbl(tAGprice.Text) < Tools.Conv_Dbl(tPxPrice.Text)) tAGprice.Text = MainMDI.A00(tPxPrice.Text);
            }
		}

        private void ref_PXAG_PriceokOLD(char opera)
		{
		    //if (Tools.Conv_Dbl(tAGprice.Text) == 0) ???? 
			if (Tools.Conv_Dbl(AlsTOT.Text) < Tools.Conv_Dbl(AlsTOT_orig.Text))
			{
				AlsTOT.Text = MainMDI.A00(AlsTOT_orig.Text);
				tAGprice.Text = MainMDI.A00(tPxPrice.Text);
			}
			if (Tools.Conv_Dbl(tAGprice.Text) < Tools.Conv_Dbl(tPxPrice.Text)) tAGprice.Text = MainMDI.A00(tPxPrice.Text);
			if (OldAlsTot.Text != AlsTOT_orig.Text && OldAlsTot.Text != "")
			{
				AlsTOT.Text = MainMDI.A00(AlsTOT_orig.Text);
				tAGprice.Text = MainMDI.A00(tPxPrice.Text);
				OldAlsTot.Text = AlsTOT_orig.Text;
			}
			if (Tools.Conv_Dbl(AlsTOT.Text) != Tools.Conv_Dbl(AlsTOT_orig.Text) || Tools.Conv_Dbl(tAGprice.Text) != Tools.Conv_Dbl(tPxPrice.Text))
			{
				if (toolBar1.Buttons[16].Pushed)
				{
					if (MainMDI.Confirm("Want to Update Primax Sell Price / Agent Price: ?"))
					{
						AlsTOT.Text = MainMDI.A00(AlsTOT_orig.Text);
						tAGprice.Text = MainMDI.A00(tPxPrice.Text);
					}
				}
			}
		}

		private void ref_PXAG_Priceooold()
		{
			if (Tools.Conv_Dbl(tPxPrice.Text) < Tools.Conv_Dbl(AlsTOT.Text))
			{
				tPxPrice.Text = MainMDI.A00(AlsTOT.Text);
				tAGprice.Text = MainMDI.A00(tPxPrice.Text);
			}
		    if (Tools.Conv_Dbl(tAGprice.Text) < Tools.Conv_Dbl(tPxPrice.Text)) tAGprice.Text = MainMDI.A00(tPxPrice.Text);
	        //tPxPrice.Text = MainMDI.A00(tPxPrice.Text);
	        //tAGprice.Text = MainMDI.A00(tAGprice.Text);
			if (OldAlsTot.Text != AlsTOT.Text && OldAlsTot.Text != "")
			{
				tPxPrice.Text = MainMDI.A00(AlsTOT.Text);
				tAGprice.Text = MainMDI.A00(tPxPrice.Text);
			}
		}

		private long Save_ALS(long SPCID, string als_Name, string Rnk, string Tot, string PXPrice, string AGPrice, string r_qty)
		{
			//string stSql = MainMDI.Find_One_Field("select ALS_LID from PSM_Q_ALS where SPC_LID=" + SPCID.ToString() + " AND ALS_Name='" + als_Name + "' and Rnk=" + Rnk);

			//ref_PXAG_Price();
            int _ovrg = (chk_savOVRG.Checked) ? 1 : 0;
			string stSql = MainMDI.Find_One_Field("select ALS_LID from PSM_Q_ALS where SPC_LID=" + SPCID.ToString() + " AND ALS_Name='" + als_Name.Replace("'", "''") + "' ");
			if (stSql != MainMDI.VIDE)
			{
                string stt = "UPDATE PSM_Q_ALS SET  [Tot]=" + Tools.Conv_Dbl(Tot) + ", [PxPrice]=" + Tools.Conv_Dbl(PXPrice) + ", [AGPrice]=" + Tools.Conv_Dbl(AGPrice) + ", [AlsQty]=" + Tools.Conv_Dbl(r_qty) + ", [SV_Ovrg]=" + _ovrg.ToString() + " where ALS_LID=" + stSql;
				MainMDI.ExecSql(stt);
				MainMDI.Write_JFS(stt);
				return Convert.ToInt32(stSql);
			}
			else 
			{
				stSql = "INSERT INTO PSM_Q_ALS ([SPC_LID],[ALS_Name],[Tot], " +
                    "[PxPrice],[AGPrice],[AlsQty], [SV_Ovrg], [Rnk] ) VALUES (" +
					SPCID.ToString() + ", '" +
					als_Name.Replace("'", "''") + "', " +
					Tools.Conv_Dbl(Tot) + ", " + Tools.Conv_Dbl(PXPrice) + 
                    ", " +Tools.Conv_Dbl(AGPrice) + 
					", " +Tools.Conv_Dbl(r_qty) +
                    ", " + _ovrg.ToString() + 
                    ", '" + Rnk + "')";
				MainMDI.ExecSql(stSql);
				MainMDI.Write_JFS(stSql);
				stSql = MainMDI.Find_One_Field("select ALS_LID from PSM_Q_ALS where SPC_LID=" + SPCID.ToString() + " AND ALS_Name='" + als_Name.Replace("'", "''") + "' and Rnk=" + Rnk);
				if (stSql != MainMDI.VIDE) return Convert.ToInt32(stSql);
				else MessageBox.Show("Error Occurs while Saving current ALIAS...contact your Admin !!!" + MainMDI.stXP);
				return 0;
			}
		}
	
		private bool Save_Details_Arr(long ALSID, long i)
		{
            //int LA = (curr_ALS[i, 6] == "") ? 0 : Convert.ToInt32(curr_ALS[i, 6]);
	    	//string stSql = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " + 
			    //" [Desc],[Qty],[Mult], [Uprice],[LeadTime],[Rnk] ) VALUES ('" +
			    //ALSID + "', '" +
			    //curr_ALS[i, 0] + "', '" +
			    //curr_ALS[i, 1] + "', '" +
			    //Tools.Conv_Dbl(curr_ALS[i, 2]) + "', '" +
			    //Tools.Conv_Dbl(curr_ALS[i, 3]) + "', '" +
			    //Tools.Conv_Dbl(curr_ALS[i, 4]) + "', '" + //lokij
			    //LA.ToString() + "', '" +
			    //i.ToString() + "')";
			//return MainMDI.ExecSql(stSql);
			return true;
		}

		private bool Save_Details(long ALSID, int i)
		{
            int _ItmGrp = CB_Group.FindStringExact(lvQITEMS.Items[i].SubItems[6].Text) + 1;
            if (_ItmGrp == -1) _ItmGrp = 1; //group A by default if error
			//!!! 
		    //double ddUP = (lvQITEMS.Items[i].SubItems[5].Text.Length < 2) ? 0 : Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[5].Text.Substring(1, lvQITEMS.Items[i].SubItems[5].Text.Length - 1));
			double ddUP = (lvQITEMS.Items[i].SubItems[5].Text == "") ? 0 : Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[5].Text);
		    //int LA = (lvQITEMS.Items[i].SubItems[8].Text == "") ? 0 : Convert.ToInt32(lvQITEMS.Items[i].SubItems[8].Text);
		    string st_DESC = (lvQITEMS.Items[i].SubItems[2].Text.Length > 0) ? lvQITEMS.Items[i].SubItems[2].Text.Replace("'", "''") : "   ";
			string stSql = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " + 
				" [Desc],[Qty],[Xch_Mult],[Uprice], [Mult],[Ext],[LeadTime],[Rnk],[PN] ,[Q_tec_Val]) VALUES ('" +
				ALSID + "', '" +
				lvQITEMS.Items[i].SubItems[1].Text + "', '" +
				st_DESC + "', '" +
				Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[3].Text) + "', '" +
                _ItmGrp.ToString() + "', '" + //Xch_Mult saves item_group 
				ddUP.ToString() + "', '" +
                Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[4].Text) + "', '" +
                Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[7].Text) + "', '" +
		        //LA.ToString() + "', '" +
				lvQITEMS.Items[i].SubItems[8].Text + "', '" +
				i.ToString() + "', '" +
				lvQITEMS.Items[i].SubItems[10].Text + "', '" +
		        //"" + "')";
			    lvQITEMS.Items[i].SubItems[12].Text + "')";
			MainMDI.Write_JFS(stSql);
			return MainMDI.ExecSql(stSql);
		}

        /*
		private bool Save_Detailsold(long ALSID, int i)
		{
			//!!! 
			//double ddUP = (lvQITEMS.Items[i].SubItems[5].Text.Length < 2) ? 0 : Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[5].Text.Substring(1, lvQITEMS.Items[i].SubItems[5].Text.Length - 1));
			double ddUP = (lvQITEMS.Items[i].SubItems[5].Text == "") ? 0 : Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[5].Text);
			//int LA = (lvQITEMS.Items[i].SubItems[8].Text == "") ? 0 : Convert.ToInt32(lvQITEMS.Items[i].SubItems[8].Text);
			string stSql = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " + 
				" [Desc],[Qty],[Xch_Mult],[Uprice], [Mult],[Ext],[LeadTime],[Rnk],[PN] ) VALUES ('" +
				ALSID + "', '" +
				lvQITEMS.Items[i].SubItems[1].Text + "', '" +
				lvQITEMS.Items[i].SubItems[2].Text.Replace("'", "''") + "', '" +
				Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[3].Text) + "', '" +
				Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[6].Text) + "', '" +
				ddUP.ToString() + "', '" +
				Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[4].Text) + "', '" +
				Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[7].Text) + "', '" +
				//LA.ToString() + "', '" +
				lvQITEMS.Items[i].SubItems[8].Text + "', '" +
				i.ToString() + "', '" +
				lvQITEMS.Items[i].SubItems[10].Text + "')";
			MainMDI.Write_JFS(stSql);
			return MainMDI.ExecSql(stSql);
		}
        */

		/*
		private void Add_optionold()
		{
			Options frmOpt = new Options('A', "*");
		    //frmOpt.optFR.Checked = (MainMDI.Lang == 1);
            //frmOpt.optEng.Checked = (MainMDI.Lang == 0);
			this.Hide();
			frmOpt.ShowDialog();
			this.Visible = true;

			if (frmOpt.lConsopt.Text == "Y")
			{
				ItemCount++;
				string stt = (MainMDI.Lang == 0) ? frmOpt.tERef.Text : frmOpt.tFRef.Text;
				string prtNB = (frmOpt.tPx.Text != "") ? frmOpt.tPx.Text + "~~" + frmOpt.tManifac.Text : " " + "~~" + frmOpt.tManifac.Text;
			    //add_LVO(1, 0, ItemCount.ToString(), frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)), frmOpt.tDlvDelay.Text, frmOpt.tPx.Text);
				add_LVO(1, 0, ItemCount.ToString(), stt + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)), frmOpt.tDlvDelay.Text, prtNB);

				Opt_added = true;
				Ref_ALSTOT();
			}
			frmOpt.Dispose();
		}
		*/

		private void Add_option()
		{
			Options frmOpt = new Options('A', "*", 'N');
			this.Hide();
			frmOpt.ShowDialog();
			this.Visible = true;

			if (frmOpt.lConsopt.Text == "Y")
			{
				ItemCount++;
				string stt = (MainMDI.Lang == 0) ? frmOpt.tERef.Text : frmOpt.tFRef.Text;
				string prtNB = (frmOpt.tPx.Text != "") ? frmOpt.tPx.Text + "~~" + frmOpt.tManifac.Text : " " + "~~" + frmOpt.tManifac.Text;
				//stt = (frmOpt.lFullDesc.Text.ToUpper().IndexOf(stt.ToUpper()) == -1) ? "" : stt + " ";
                add_LVO(1, 0, ItemCount.ToString(), stt + "  " + frmOpt.lFullDesc.Text + " [" + frmOpt.tPX_code.Text + "]", frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)), frmOpt.tDlvDelay.Text, prtNB, "C_TCC||A", "A");
			    //add_LVO(1, 0, ItemCount.ToString(), frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)), frmOpt.tDlvDelay.Text, prtNB, "");
	         	Opt_added = true;
				Ref_ALSTOT('A');
			}
			else if (frmOpt.lConsopt.Text == "L")
			{
				for (int i = 0; i < frmOpt.lvCadi.Items.Count; i++)
				{
					ItemCount++;
					add_LVO(1, 0, ItemCount.ToString(), frmOpt.lvCadi.Items[i].SubItems[0].Text, frmOpt.lvCadi.Items[i].SubItems[1].Text, tCust_Mult.Text, frmOpt.lvCadi.Items[i].SubItems[2].Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.lvCadi.Items[i].SubItems[2].Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)), frmOpt.lvCadi.Items[i].SubItems[4].Text, frmOpt.lvCadi.Items[i].SubItems[3].Text, "C_TCC||A", "A");
	         		Opt_added = true;
				}
				Ref_ALSTOT('A');
			}
			frmOpt.Dispose();
		}

		/*
		private void Add_optionoldz()
		{
			Options frmOpt = new Options('A', "*");
			this.Hide();
			frmOpt.ShowDialog();
			this.Visible = true;

			if (frmOpt.lConsopt.Text == "Y")
			{
				//OptionCount++;
		        //old add_LVO(3, ".", frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), Charger.NB_DEC_AFF)), frmOpt.tDlvDelay.Text, frmOpt.tPx.Text);
	        	ItemCount++;
				add_LVO(1, 0, ItemCount.ToString(), frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)), frmOpt.tDlvDelay.Text, frmOpt.tPx.Text);
	
	            //else add_LVO(3, ".", frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), Charger.NB_DEC_AFF)), frmOpt.tDlvDelay.Text);
				Opt_added = true;
				Ref_ALSTOT();
			}
			frmOpt.Dispose();
		}
	
		private void Add_optionNew()
		{
		    //string stDesc = "";	
			Options frmOpt = new Options('A', "*");
			frmOpt.ShowDialog();

			if (frmOpt.lConsopt.Text == "Y")
			{
				//for (int i = 0; i < frmOpt.lv
				if (frmOpt.btnOK.Text == "Update")
				{
					if (!Opt_added) add_LVO(2, ".", MainMDI.arr_EFSdict[21, MainMDI.Lang] + "=  ", "", "", "", "", "");
					OptionCount++;
					add_LVO(3, ".", frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), Charger.NB_DEC_AFF)), frmOpt.tDlvDelay.Text);
					//else add_LVO(3, ".", frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), Charger.NB_DEC_AFF)), frmOpt.tDlvDelay.Text);
					Opt_added = true;
				}
				else 
				{
					for (int i = 0; i < frmOpt.lvOptPricelst.SelectedItems.Count; i++)
					{
						if (!Opt_added) add_LVO(2, ".", MainMDI.arr_EFSdict[21, MainMDI.Lang] + "=  ", "", "", "", "", "");
						OptionCount++;
					    //add_LVO(3, ".", frmOpt.tERef.Text + "  " + stDesc, frmOpt.lvOptPricelst.SelectedItems[i].SubItems[2], tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), Charger.NB_DEC_AFF)), frmOpt.tDlvDelay.Text);
						//else add_LVO(3, ".", frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text, frmOpt.tOptqty.Text, tCust_Mult.Text, frmOpt.tUPrice.Text, Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), Charger.NB_DEC_AFF)), frmOpt.tDlvDelay.Text);
						Opt_added = true;
					}
				}
				Ref_ALSTOT();
			}
		}
	    */ 	
		
		private void Add_optionoldnew()
		{
			Options frmOpt = new Options('A', "*", 'N');
			frmOpt.ShowDialog();

			if (frmOpt.lConsopt.Text == "Y")
			{
				ListViewItem lvI = lvQITEMS.Items.Add("");
				lvI.BackColor = Color.LightYellow;
				OptionCount++;
				lvI.SubItems.Add(ItemCount + "." + OptionCount.ToString());	
				lvI.SubItems.Add("Option / " + frmOpt.tERef.Text + "  " + frmOpt.lFullDesc.Text);
				lvI.SubItems.Add(frmOpt.tOptqty.Text);
				lvI.SubItems.Add(tCust_Mult.Text);
				lvI.SubItems.Add(frmOpt.tUPrice.Text);
				lvI.SubItems.Add(Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.Q_NB_DEC_AFF)));
				lvI.SubItems.Add(frmOpt.tDlvDelay.Text);
				Ref_ALSTOT('A');
			}
		}

		private void Add_CBR(char cbr)
		{
			string nbCell = "", stIn = "";
			if (lvQITEMS.SelectedItems.Count == 1)
			{
				if (lvQITEMS.SelectedItems[0].SubItems[2].Text.Substring(0, 5) == "Cell#")
					nbCell = lvQITEMS.SelectedItems[0].SubItems[2].Text.Substring(8, lvQITEMS.SelectedItems[0].SubItems[2].Text.Length - 8);
			}
			PbsInfo pbsI = new PbsInfo(cbr, nbCell);
			pbsI.ShowDialog();
			if (pbsI.SaveOK)
			{
				Tosave = true;
				switch (cbr)
				{
					case 'C':
					case 'c':
						ItemCount++;
						add_LVO(1, 0, ItemCount.ToString(), "Cabinet " + pbsI.tcModel.Text, pbsI.tcQtyCab.Text, tCust_Mult.Text, pbsI.tcPrice.Text, pbsI.tcextCab.Text, pbsI.tcLT.Text, pbsI.tcModel.Text, "C_TCC||A", "A");
						div_Dim(pbsI.tcDim.Text, ref stIn);
                        add_LVO(1, 1, "", "Dimensions: " + stIn, "", "", "", "", "", "", "", "A");
					    //add_LVO(1, "", "                   " + stMm, "", "", "", "", "");
                        add_LVO(1, 1, "", "Color: " + pbsI.tccolor.Text, "", "", "", "", "", "", "", "A");
						if (pbsI.lcetat.Text == "S")
						{
                            if (pbsI.tc1Tstep.Text != "0") add_LVO(1, 1, "", "First Tier: " + pbsI.tc1Tstep.Text + " step(s)", pbsI.tc1Tstep.Text, tCust_Mult.Text, pbsI.tcstpUP.Text, pbsI.tc1TPrice.Text, pbsI.tcLT.Text, "", "", "A");
                            if (pbsI.tc2Tstep.Text != "0") add_LVO(1, 1, "", "Second Tier: " + pbsI.tc2Tstep.Text + " step(s)", pbsI.tc2Tstep.Text, tCust_Mult.Text, pbsI.tcstpUP.Text, pbsI.tc2TPrice.Text, pbsI.tcLT.Text, "", "", "A");
						}
                        else { if (pbsI.tc1Tstep.Text != "0") add_LVO(1, 1, "", "Tiers # : " + pbsI.tc1Tstep.Text, pbsI.tc1Tstep.Text, tCust_Mult.Text, pbsI.tcstpUP.Text, pbsI.tc1TPrice.Text, pbsI.tcLT.Text, "", "", "A"); }
                        if (pbsI.chkprint.Checked) add_LVO(1, 1, "", "Cell# :" + pbsI.tcNBCell.Text, "", "", "", "", "", "", "", "A");
                        if (pbsI.tcITExt.Text != "0") add_LVO(1, 1, "", "Inter Tiers ", pbsI.tcITQty.Text, tCust_Mult.Text, pbsI.tcITup.Text, pbsI.tcITExt.Text, "", "", "", "A");
                        if (pbsI.tcBTBExt.Text != "0") add_LVO(1, 1, "", "Battery Terminal Block ", pbsI.tcBTBQty.Text, tCust_Mult.Text, pbsI.tcBTBup.Text, pbsI.tcBTBExt.Text, "", "", "", "A");
						break;	
					case 'B':
					case 'b':
						ItemCount++;
						double UP = Math.Round(Tools.Conv_Dbl(pbsI.tbExt.Text) / Tools.Conv_Dbl(pbsI.tsysnb.Text), MainMDI.NB_DEC_AFF);
						double NExt = Math.Round(UP * Tools.Conv_Dbl(tCust_Mult.Text), MainMDI.NB_DEC_AFF);
                        add_LVO(1, 0, ItemCount.ToString(), pbsI.tbType.Text, pbsI.tsysnb.Text, tCust_Mult.Text, UP.ToString(), NExt.ToString(), pbsI.tbLT.Text, pbsI.tbName.Text, "C_TCC||C", "C");
				        //add_LVO(0, ItemCount.ToString(), pbsI.tbType.Text + " Battery:  " + pbsI.tbName.Text, pbsI.tbNBcell.Text, tCust_Mult.Text, pbsI.tbPrice.Text, pbsI.tbExt.Text, pbsI.tbLT.Text, pbsI.tbName.Text);
					    //add_LVO(1, 0, ItemCount.ToString(), pbsI.tbType.Text, pbsI.tsysnb.Text, tCust_Mult.Text, pbsI.tbPrice.Text, pbsI.tbExt.Text, pbsI.tbLT.Text, pbsI.tbName.Text);
                        add_LVO(1, 1, "", pbsI.tbNBcell.Text + " Cells/Blocks " + pbsI.tbName.Text, "", "", "", "", "", "", "", "C");
                        add_LVO(1, 1, "", "Capacity: " + pbsI.tbCapa.Text + " Ah", "", "", "", "", "", "", "", "C");
					    //add_LVO(1, "", "Dimensions: " + pbsI.tbDim.Text, "", "", "", "", "");
						div_Dim(pbsI.tbDim.Text, ref stIn);
                        add_LVO(1, 1, "", "Dimensions: " + stIn, "", "", "", "", "", "", "", "C");
						//add_LVO(1, "", "            " + stMm, "", "", "", "", "");
                        add_LVO(1, 1, "", "Warranty: " + pbsI.tbWaran.Text, "", "", "", "", "", "", "", "C");
                        if (pbsI.tbRack.Text != "") add_LVO(1, 1, "", "Battery rack: " + pbsI.tbRack.Text, "", "", "", "", "", "", "", "C");
                        if (pbsI.tbICExt.Text != "0") add_LVO(1, 1, "", "Inter Cell ", pbsI.tbICQty.Text, tCust_Mult.Text, pbsI.tbICup.Text, pbsI.tbICExt.Text, "", "", "", "C");
                        if (pbsI.tbELExt.Text != "0") add_LVO(1, 1, "", "End Lugs", pbsI.tbELQty.Text, tCust_Mult.Text, pbsI.tbELup.Text, pbsI.tbELExt.Text, "", "", "", "C");
						break;
					case 'R':
					case 'r':
						ItemCount++;
                        add_LVO(1, 0, ItemCount.ToString(), pbsI.tbType.Text + " Rack:  " + pbsI.trModel.Text, pbsI.trQty.Text, tCust_Mult.Text, pbsI.trPrice.Text, pbsI.trExt.Text, pbsI.trLT.Text, pbsI.trModel.Text, "C_TCC||C", "C");
						div_Dim(pbsI.trDim.Text, ref stIn);
                        add_LVO(1, 1, "", "Dimensions: " + stIn, "", "", "", "", "", "", "", "C");
					    //add_LVO(1, "", "            " + stMm, "", "", "", "", "");
						break;	
				}
				Ref_ALSTOT('A');
			}
		}

		private void div_Dim(string st, ref string stIn)
		{
			int pos = st.IndexOf("mm", 0);
			if (pos > -1)
			{
				stIn = " (mm)" + st.Substring(pos + 3, st.Length - pos - 3);
				stIn += "   (inch) " + st.Substring(6, pos - 6);
			}
			else { stIn = " (inch) " + st; }
		}

		private void add_LVO(int ToBePrinted, int deb, string nb, string Desc, string Qt, string mult, string up, string ext, string LT, string stPartnb, string TecVal, string Grp)
		{
			ListViewItem lvI = lvQITEMS.Items.Add(""); //order
			lvI.Checked = (ToBePrinted != 0);
			if (deb == 0 || deb == 2 || deb == 3)
			{				
				if (deb == 0) lvI.BackColor = Color.Salmon;
				if (deb == 2) lvI.BackColor = Color.LightYellow;
				lvI.SubItems.Add(nb);
			}
			else lvI.SubItems.Add(" "); ////aff
			if (ext != "" && tXRATE.Text != "" && ext != "0") ext = Convert.ToString(Math.Round(Tools.Conv_Dbl(mult) * Tools.Conv_Dbl(up) * Tools.Conv_Dbl(Qt) * Tools.Conv_Dbl(tXRATE.Text), MainMDI.Q_NB_DEC_AFF)); else ext = "";
			lvI.SubItems.Add(Desc); //item
			lvI.SubItems.Add(Qt); //Qty
			if (ext != "" && ext != "0") lvI.SubItems.Add(MainMDI.A00(mult));
			else lvI.SubItems.Add(""); //Mult
			lvI.SubItems.Add(MainMDI.A00(up)); //Unit Price
			//if (up != "" && Qt != "") ext = Convert.ToString(Math.Round(Tools.Conv_Dbl(up) * Tools.Conv_Dbl(Qt) * Tools.Conv_Dbl(tXRATE.Text), MainMDI.NB_DEC_AFF));
			//if (ext != "" && ext != "0")
			if (ext != "" && ext != "0") lvI.SubItems.Add(Grp); else lvI.SubItems.Add(""); //Xchnge
			lvI.SubItems.Add(MainMDI.A00(ext)); //Extension
			if (ext == "0") lvI.SubItems[lvI.SubItems.Count - 1].BackColor = Color.DarkTurquoise;
			if (ext != "" && ext != "0") lvI.SubItems.Add(LT);
			else lvI.SubItems.Add(""); //LT
			lvI.SubItems.Add(""); //nbDef
			lvI.SubItems.Add(stPartnb); //PartNB
			lvI.SubItems.Add(""); //Det_LID
			lvI.SubItems.Add(TecVal); //Tech. Values
		}

		private void add_LVO_NL(byte deb, string nb, string Desc, string Qt, string mult, string up, string ext, string LT, string stPartnb, string Grp)
		{
			ListViewItem lvI = lvQITEMS.Items.Add("");
			if (deb == 0 || deb == 2 || deb == 3)
			{				
				if (deb == 0) lvI.BackColor = Color.Salmon;
				if (deb == 2) lvI.BackColor = Color.LightYellow;
				lvI.SubItems.Add(nb);
			}
			else lvI.SubItems.Add(" "); //must be space
			lvI.SubItems.Add(Desc);
			lvI.SubItems.Add(Qt);
			lvI.SubItems.Add(mult); //lvI.SubItems.Add("");
			if (up != "0") lvI.SubItems.Add(up); else lvI.SubItems.Add("");
		    lvI.SubItems.Add(Grp);
			lvI.SubItems.Add(MainMDI.A00(ext));
			//if (ext == "0") lvI.SubItems[lvI.SubItems.Count - 1].BackColor = Color.DarkTurquoise;
			if (ext != "" && ext != "0") lvI.SubItems.Add(LT);
			    else lvI.SubItems.Add("");
			lvI.SubItems.Add("");
			lvI.SubItems.Add("");
			lvI.SubItems.Add(stPartnb);
			lvI.SubItems.Add("");
		}
		
		private void Add_Rectif()
		{
			P5500 Rectifdlg = new P5500();
			Rectifdlg.ShowDialog();
			if (Rectifdlg.lsave.Text == "Y")
			{
				ItemCount++;
				//string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
				//add_LVO(0, ItemCount.ToString(), frmchdlg.lvDefOption.Items[i].SubItems[2].Text, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text);
				//string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
				add_LVO(1, 0, ItemCount.ToString(), "EDI RECTIFIER " + Rectifdlg.lRecModel.Text, Rectifdlg.tIQty.Text, Rectifdlg.tSMRK.Text, Rectifdlg.tIPU.Text, Rectifdlg.tIExt.Text, Rectifdlg.tILT.Text, "", "", "A");
                if (Rectifdlg.chkEnc.Checked) add_LVO(1, 1, "", Rectifdlg.chkEnc.Text + ": " + Rectifdlg.cbEnc.Text, "", "", "", "", "", "", "", "A");
                if (Rectifdlg.chkInput.Checked) add_LVO(1, 1, "", Rectifdlg.chkInput.Text + ": " + Rectifdlg.cbInput.Text, "", "", "", "", "", "", "", "A");
                if (Rectifdlg.chkheat.Checked) add_LVO(1, 1, "", Rectifdlg.chkheat.Text + ": " + Rectifdlg.cbHeat.Text, "", "", "", "", "", "", "", "A");
                if (Rectifdlg.chkplc.Checked) add_LVO(1, 1, "", Rectifdlg.chkplc.Text + ": " + Rectifdlg.cbPLC.Text, "", "", "", "", "", "", "", "A");
                if (Rectifdlg.chkinternal.Checked) add_LVO(1, 1, "", Rectifdlg.chkinternal.Text + ": " + Rectifdlg.cbInternal.Text, "", "", "", "", "", "", "", "A");
                if (Rectifdlg.chk3PHS.Checked) add_LVO(1, 1, "", Rectifdlg.chk3PHS.Text + ": " + Rectifdlg.cb3PHS.Text, "", "", "", "", "", "", "", "A");
                if (Rectifdlg.chktermalP.Checked) add_LVO(1, 1, "", Rectifdlg.chktermalP.Text + ((Rectifdlg.ttermalP.Text == "STD") ? "" : ": " + Rectifdlg.ttermalP.Text), "", "", "", "", "", "", "", "A");
                if (Rectifdlg.chkApp.Checked) add_LVO(1, 1, "", Rectifdlg.chkApp.Text + ": " + Rectifdlg.tApp.Text, "", "", "", "", "", "", "", "A");
				Ref_ALSTOT('A');
			}
		}

        /*		
		private void Add_ChargerOLD()
		{
			Chargerdlg frmchdlg = new Chargerdlg('0', MainMDI._connectionString);
			this.Hide();
			frmchdlg.ShowDialog();
			this.Visible = true;
			if (frmchdlg.lSave.Text == "Y")
			{
			  for (int i = 0; i < frmchdlg.lvDefOption.Items.Count; i++)
				{
					if (i == 0)
					{
						ItemCount++;
						string lFrml = "";
						for (int y = 0; y < Charger.NB_FRML; y++)
						{
							if (frmchdlg.dlg_arr_CAL_FRML[y] != "")
								lFrml += " " + frmchdlg.dlg_arr_CAL_FRML[y];
							else break;
						}
						add_LVO(1, 0, ItemCount.ToString(), frmchdlg.lvDefOption.Items[i].SubItems[1].Text, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text, frmchdlg.lvDefOption.Items[i].SubItems[11].Text, lFrml);
					    //arr_Tech_values[lvQITEMS.Items.Count - 1] = lFrml;
					}
					else
					{
						if (frmchdlg.lvDefOption.Items[i].Checked)
						{
							//added on 07/12/05
							string r_TecV = "";
							if (frmchdlg.lvDefOption.Items[i].SubItems[8].Text != "")
							{
								if (frmchdlg.lvDefOption.Items[i].SubItems[10].Text == "ALRM")
								    r_TecV = frmchdlg.lvDefOption.Items[i].SubItems[11].Text;
							}
						    //added on 07/12/05
							string st = frmchdlg.lvDefOption.Items[i].SubItems[1].Text == "" ? frmchdlg.lvDefOption.Items[i].SubItems[2].Text : frmchdlg.lvDefOption.Items[i].SubItems[1].Text + "= " + frmchdlg.lvDefOption.Items[i].SubItems[2].Text;
							if (frmchdlg.lvDefOption.Items[i].SubItems[4].Text != "0")
								add_LVO(1, 1, "", st, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text, frmchdlg.lvDefOption.Items[i].SubItems[11].Text, r_TecV);
							else add_LVO(1, 1, "", st, "", "", "", "", "", frmchdlg.lvDefOption.Items[i].SubItems[11].Text, r_TecV);
							if (frmchdlg.lvDefOption.Items[i].ForeColor == Color.Red) lvQITEMS.Items[lvQITEMS.Items.Count - 1].ForeColor = Color.Red;
						}
					}
				}
			  Ref_ALSTOT();
			}
			frmchdlg.Dispose();
		}
		*/

        private void Add_P5500()
        {
            Chargerdlg_P5500 frmchdlgP5500 = new Chargerdlg_P5500('0', MainMDI.M_stCon);
            this.Hide();
            frmchdlgP5500.ShowDialog();
            this.Visible = true;
            if (frmchdlgP5500.lSave.Text == "Y")
            {
                for (int i = 0; i < frmchdlgP5500.lvDefOption.Items.Count; i++)
                {
                    if (i == 0)
                    {
                        ItemCount++;
                        string lFrml = "";
                        string model = frmchdlgP5500.lvDefOption.Items[i].SubItems[1].Text;
                        //int ipos = model.IndexOf("charger") + 8;
                        string st = MainMDI.arr_EFSdict[39, MainMDI.Lang];
                        int ipos = model.IndexOf(st) + st.Length + 1;
                        model = model.Substring(ipos, model.Length - ipos);
                        for (int y = 0; y < Charger.NB_FRML; y++)
                        {
                            if (frmchdlgP5500.dlg_arr_CAL_FRML[y] != "")
                                lFrml += " " + frmchdlgP5500.dlg_arr_CAL_FRML[y];
                            else break;
                        }
                        lFrml += " C_MODEL||" + model + " C_TCC||A";
                        //here add TV value to TEC_Val
                        lFrml += " " + frmchdlgP5500.lOth_TV;
                        add_LVO(1, 0, ItemCount.ToString(), frmchdlgP5500.lvDefOption.Items[i].SubItems[1].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[4].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[5].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[6].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[11].Text, lFrml, "A");
                        //arr_Tech_values[lvQITEMS.Items.Count - 1] = lFrml;
                    }
                    else
                    {
                        if (frmchdlgP5500.lvDefOption.Items[i].Checked)
                        {
                            string r_TecV = frmchdlgP5500.lvDefOption.Items[i].SubItems[11].Text;
                            //added on 07/12/05
                            //string r_TecV = "";
                            //if (frmchdlg.lvDefOption.Items[i].SubItems[8].Text != "")
                            //{
                                //if (frmchdlg.lvDefOption.Items[i].SubItems[10].Text == "ALRM")
                                    //r_TecV = frmchdlg.lvDefOption.Items[i].SubItems[11].Text;
                                //
                                //
                            //}
                            //added on 07/12/05
                            string st = frmchdlgP5500.lvDefOption.Items[i].SubItems[1].Text == "" ? frmchdlgP5500.lvDefOption.Items[i].SubItems[2].Text : frmchdlgP5500.lvDefOption.Items[i].SubItems[1].Text + "= " + frmchdlgP5500.lvDefOption.Items[i].SubItems[2].Text;
                            if (frmchdlgP5500.lvDefOption.Items[i].SubItems[4].Text != "0")
                                add_LVO(1, 1, "", st, frmchdlgP5500.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[4].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[5].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[6].Text, frmchdlgP5500.lvDefOption.Items[i].SubItems[10].Text, r_TecV, "A");
                            else add_LVO(1, 1, "", st, "", "", "", "", "", frmchdlgP5500.lvDefOption.Items[i].SubItems[10].Text, r_TecV, "A");
                            if (frmchdlgP5500.lvDefOption.Items[i].ForeColor == Color.Red) lvQITEMS.Items[lvQITEMS.Items.Count - 1].ForeColor = Color.Red;
                        }
                    }
                }
                Ref_ALSTOT('A');
            }
            frmchdlgP5500.Dispose();
        }

		private void Add_Charger()
		{
			Chargerdlg frmchdlg = new Chargerdlg('0', MainMDI.M_stCon, 'N');
			this.Hide();
			frmchdlg.ShowDialog();
			this.Visible = true;
			if (frmchdlg.lSave.Text == "Y")
			{
				for (int i = 0; i < frmchdlg.lvDefOption.Items.Count; i++)
				{
					if (i == 0)
					{
						ItemCount++;
						string lFrml = "";
						string model = frmchdlg.lvDefOption.Items[i].SubItems[1].Text;
					    //int ipos = model.IndexOf("charger") + 8;
						string st = MainMDI.arr_EFSdict[39, MainMDI.Lang];
						int ipos = model.IndexOf(st) + st.Length + 1;
						model = model.Substring(ipos, model.Length - ipos);
						for (int y = 0; y < Charger.NB_FRML; y++)
						{
							if (frmchdlg.dlg_arr_CAL_FRML[y] != "")
								lFrml += " " + frmchdlg.dlg_arr_CAL_FRML[y];
							else break;
						}
						lFrml += " C_MODEL||" + model + " C_TCC||A";
						//here add TV value to TEC_Val
                        lFrml += " " + frmchdlg.lOth_TV;
                        add_LVO(1, 0, ItemCount.ToString(), frmchdlg.lvDefOption.Items[i].SubItems[1].Text, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text, frmchdlg.lvDefOption.Items[i].SubItems[11].Text, lFrml, "A");
						//arr_Tech_values[lvQITEMS.Items.Count - 1] = lFrml;
					}
					else
					{
						if (frmchdlg.lvDefOption.Items[i].Checked)
						{
							string r_TecV = frmchdlg.lvDefOption.Items[i].SubItems[11].Text;
							//added on 07/12/05
						    //string r_TecV = "";
						    //if (frmchdlg.lvDefOption.Items[i].SubItems[8].Text != "")
						    //{
						        //if (frmchdlg.lvDefOption.Items[i].SubItems[10].Text == "ALRM")
						            //r_TecV = frmchdlg.lvDefOption.Items[i].SubItems[11].Text;
                                //
                                //
                            //}
							//added on 07/12/05
							string st = frmchdlg.lvDefOption.Items[i].SubItems[1].Text == "" ? frmchdlg.lvDefOption.Items[i].SubItems[2].Text : frmchdlg.lvDefOption.Items[i].SubItems[1].Text + "= " + frmchdlg.lvDefOption.Items[i].SubItems[2].Text;
							if (frmchdlg.lvDefOption.Items[i].SubItems[4].Text != "0")
                                add_LVO(1, 1, "", st, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text, frmchdlg.lvDefOption.Items[i].SubItems[10].Text, r_TecV, "A");
                            else add_LVO(1, 1, "", st, "", "", "", "", "", frmchdlg.lvDefOption.Items[i].SubItems[10].Text, r_TecV, "A");
							if (frmchdlg.lvDefOption.Items[i].ForeColor == Color.Red) lvQITEMS.Items[lvQITEMS.Items.Count - 1].ForeColor = Color.Red;
						}
					}
				}
				Ref_ALSTOT('A');
			}
			frmchdlg.Dispose();
		}

		/*
		private void Add_Chargerold()
		{
			Chargerdlg frmchdlg = new Chargerdlg('0', MainMDI._connectionString);
			frmchdlg.ShowDialog();
			if (frmchdlg.lSave.Text == "Y")
			{
				for (int i = 0; i < frmchdlg.lvDefOption.Items.Count; i++)
				{
					if (i == 0)
					{
						ItemCount++;
						//string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
						//add_LVO(0, ItemCount.ToString(), frmchdlg.lvDefOption.Items[i].SubItems[2].Text, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text);
						//string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
						add_LVO(1, 0, ItemCount.ToString(), frmchdlg.lvDefOption.Items[i].SubItems[1].Text, "", "", "", "", "", "");
					}
					else
					{
						if (frmchdlg.lvDefOption.Items[i].Checked)
						{
							string st = frmchdlg.lvDefOption.Items[i].SubItems[1].Text == "" ? frmchdlg.lvDefOption.Items[i].SubItems[2].Text : frmchdlg.lvDefOption.Items[i].SubItems[1].Text + "= " + frmchdlg.lvDefOption.Items[i].SubItems[2].Text;
							if (frmchdlg.lvDefOption.Items[i].SubItems[4].Text != "0")
								add_LVO(1, 1, "", st, frmchdlg.lvDefOption.Items[i].SubItems[3].Text, tCust_Mult.Text, frmchdlg.lvDefOption.Items[i].SubItems[4].Text, frmchdlg.lvDefOption.Items[i].SubItems[5].Text, frmchdlg.lvDefOption.Items[i].SubItems[6].Text, frmchdlg.lvDefOption.Items[i].SubItems[7].Text);
							else add_LVO(1, 1, "", st, "", "", "", "", "", "");
						}
					}
				}
				Ref_ALSTOT();
			}
		}

		private void Add_ChargerOLD2()
		{
			Chargerdlg frmchdlg = new Chargerdlg('0', MainMDI._connectionString);
			frmchdlg.ShowDialog();
			if (frmchdlg.lSave.Text == "Y")
			{
				for (int i = 0; i < frmchdlg.lvDefOption.Items.Count; i++)
				{
					if (frmchdlg.lvDefOption.Items[i].Checked)
					{
						ListViewItem lvI = lvQITEMS.Items.Add(""); //
						if (i == 0)
						{
							lvI.BackColor = Color.Salmon;
							ItemCount++;
							lvI.SubItems.Add(ItemCount.ToString()); //1
						}
						else lvI.SubItems.Add(" ");
						string st = (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") ? frmchdlg.lvDefOption.Items[i].SubItems[1].Text + " / " : "";
						lvI.SubItems.Add(st + frmchdlg.lvDefOption.Items[i].SubItems[2].Text); //2
						lvI.SubItems.Add(frmchdlg.lvDefOption.Items[i].SubItems[3].Text); //3
						if (frmchdlg.lvDefOption.Items[i].SubItems[4].Text == "" || frmchdlg.lvDefOption.Items[i].SubItems[4].Text == "0")
						{
							lvI.SubItems.Add(""); //4
							lvI.SubItems.Add(""); //5
							lvI.SubItems.Add(""); //6
							lvI.SubItems.Add(""); //7
						}
						else
						{
							if (frmchdlg.lvDefOption.Items[i].SubItems[1].Text != "") lvI.SubItems.Add(tCust_Mult.Text);
							else lvI.SubItems.Add("");
							lvI.SubItems.Add(frmchdlg.lvDefOption.Items[i].SubItems[4].Text); //curr_ALS[als_NDX, 4] = frmchdlg.lvDefOption.Items[i].SubItems[4].Text;
							lvI.SubItems.Add(frmchdlg.lvDefOption.Items[i].SubItems[5].Text); //curr_ALS[als_NDX, 5] = frmchdlg.lvDefOption.Items[i].SubItems[5].Text;
							lvI.SubItems.Add(frmchdlg.lvDefOption.Items[i].SubItems[6].Text); //curr_ALS[als_NDX, 6] = frmchdlg.lvDefOption.Items[i].SubItems[6].Text;
						}
					}
				    //lvQITEMS.Refresh();
				}
			}
		}

		private bool labelExistold(string st)
		{
			int nb = (tvSol.SelectedNode.ImageIndex == 2) ? tvSol.Nodes.Count : tvSol.SelectedNode.Parent.Nodes.Count;
			for (int i = 0; i < nb; i++)
			{
				string lbl = (tvSol.SelectedNode.ImageIndex == 2) ? tvSol.Nodes[i].Text : tvSol.SelectedNode.Parent.Nodes[i].Text;
				if (st == lbl) return true;
			}
			return false;
		}
        */

		private bool LBL_Exist(string st)
		{
			switch (tvSol.SelectedNode.ImageIndex)
			{
				case 0:
				case 1:
					for (int i = 0; i < tvSol.SelectedNode.Parent.Nodes.Count; i++)
						if (st == tvSol.SelectedNode.Parent.Nodes[i].Text) return true;
					break;
				case 2:
					for (int i = 0; i < tvSol.Nodes.Count; i++)
						if (st == tvSol.Nodes[i].Text) return true;
					break;
			}
			return false;
		}

		private int REV_Nb(string revSt)
		{
			int nb = -1;
			for (int i = 0; i < tvSol.Nodes.Count; i++)
			{
				if (tvSol.Nodes[i].Text.Substring(0, 2) == revSt)
				{
					int tt = Convert.ToInt32(tvSol.Nodes[i].Text.Substring(3, tvSol.Nodes[i].Text.Length - 3));
					if (tt > nb) nb = tt;
				}
			}
			return nb;
		}

		private bool REv_Exist(string st)
		{
			if (tvSol.Nodes.Count > 0)
			{
				for (int i = 0; i < tvSol.Nodes.Count; i++)
					if (st == tvSol.Nodes[i].Text) return true;
			}
			return false;
		}

		private bool LBL_Exist_Newa(string st)
		{
			if (lTVSel.Text == "Y" && tvSol.Nodes.Count > 0)
			{
				for (int i = 0; i < tvSol.SelectedNode.Nodes.Count; i++)
					if (st == tvSol.SelectedNode.Nodes[i].Text) return true;
			}
			return false;
		}

		private void Add_NLItemOption()
		{
			NL_Item_Option frmNLIO = new NL_Item_Option(tQuoteID.Text);
			this.Hide();
			frmNLIO.ShowDialog();
			this.Visible = true;
			if (frmNLIO.SaveOK)
			{
				ItemCount++;
				string st = (frmNLIO.tIModel.Text == "") ? frmNLIO.tIName.Text : frmNLIO.tIName.Text + " / " + frmNLIO.tIModel.Text;
			    //add_LVO(0, ItemCount.ToString(), st, frmNLIO.tIQty.Text, tCust_Mult.Text, frmNLIO.tIPU.Text, frmNLIO.tIExt.Text, frmNLIO.tILT.Text);
				add_LVO_NL (0, ItemCount.ToString(), st, frmNLIO.tIQty.Text, frmNLIO.tSMRK.Text, frmNLIO.tIPU.Text, frmNLIO.tIExt.Text, frmNLIO.tILT.Text, frmNLIO.tIModel.Text, "C");
                if (frmNLIO.tIdim.Text != "") add_LVO(1, 1, "", "Dimensions= " + frmNLIO.tIdim.Text, "", "", "", "", "", "", "", "C");
                if (frmNLIO.tIf1.Text != "") add_LVO(1, 1, "", frmNLIO.lif1.Text + "=  " + frmNLIO.tIf1.Text, "", "", "", "", "", "", "", "C");
                if (frmNLIO.tIf2.Text != "") add_LVO(1, 1, "", frmNLIO.lif2.Text + "=  " + frmNLIO.tIf2.Text, "", "", "", "", "", "", "", "C");
				if (frmNLIO.tIotherF.Text != "")
				{
					st = frmNLIO.tIotherF.Text;
					//if (frmNLIO.lIotherF.Text != "") add_LVO(1, "", frmNLIO.lIotherF.Text, "", "", "", "", "");
				 	while (st.Length > 0)
					{
						int ipos = st.IndexOf('\n', 0);
						if (ipos == -1)
						{
                            add_LVO(1, 1, "", "          " + st, "", "", "", "", "", "", "", "C");
							break;
						}
						else
						{
                            add_LVO(1, 1, "", "          " + st.Substring(0, ipos - 1), "", "", "", "", "", "", "", "C");
							st = st.Substring(ipos + 1, st.Length - ipos - 1);
						}
					}
				}
				Ref_ALSTOT('A');
			}
		}

		private void dup_Alias()
		{
	        //MessageBox.Show("Alias= " + tvSol.SelectedNode.Text);
	        //string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* " +
                //" FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                //" WHERE (((PSM_Q_IGen.i_Quoteid)=62)) ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
		}

		private void Duplica_Sol()
		{
			bool alsAdded = false;
			int nbSol = 1, nbSpc = 1, nbAls = 1;
			long r_Spcid = 0, r_SolId = 0, r_alsId = 0;
            ini_arrSql();
            int S = 0;
	        string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.*, PSM_Q_SPCS.Rnk AS SPCS_Rnk, PSM_Q_ALS.Rnk AS ALS_Rnk, PSM_Q_Details.Rnk AS Details_Rnk " +
				" FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
				" WHERE (PSM_Q_IGen.i_Quoteid=" + lCurrIQID.Text + " and PSM_Q_SOL.Sol_Name='" + lCurSoln.Text + "') ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
			
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			string Osol = "", Nsol = "", Ospc = "", Nspc = "", Nals = "", Oals = "";
			while (Oreadr.Read())
			{
				//alsAdded = false;
 
				if (Nsol == "")
				{
					int t = REV_Nb(lCurSoln.Text.Substring(0, 2)) + 1;
					Nsol = lCurSoln.Text.Substring(0, 2) + "-" + MainMDI.A00(t, 2);
					//Nsol = "Copy_" + Oreadr["Sol_Name"].ToString();
				}
				Nspc = Oreadr["SPC_Name"].ToString();
				Nals = Oreadr["ALS_Name"].ToString();
				if (Osol != Nsol)	
				{
					nbSol = tvSol.Nodes.Count;
					//Nsol = "Copy" + nbSol + "_" + Oreadr["Sol_Name"].ToString();
					r_SolId = Save_SOL(lCurrIQID.Text, Nsol, nbSol.ToString(), Oreadr["img"].ToString());
				    //addNode_Sol(Nsol, Oreadr["img"].ToString(), Oreadr["status_Rev"].ToString());
					addNode_Sol(Nsol, Oreadr["img"].ToString(), "N");
					Osol = Nsol;
				}
				if (Ospc != Nspc)
				{
					if (tvSol.Nodes[nbSol].Nodes.Count == 0)
					{
						nbSpc = 0;
						nbAls = 0;
					}
					else
					{
						nbSpc = tvSol.Nodes[nbSol].Nodes.Count;
						nbAls = tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count;
					}
					//r_Spcid = Save_SPEC(r_SolId, Nspc.ToString(), nbSpc.ToString());
					r_Spcid = Save_SPEC(r_SolId, Nspc, Oreadr["SPCS_Rnk"].ToString());
					addNode_Spc(Nspc, nbSol, nbSpc, Nals); //alsAdded = true;
					//Ospc = Nspc;
				}
				if (Oals != Nals || Ospc != Nspc) //|| alsAdded)
				{
					//r_alsId = Save_ALS(r_Spcid, Nals, nbAls.ToString(), Oreadr["tot"].ToString());
					r_alsId = Save_ALS(r_Spcid, Nals, Oreadr["ALS_Rnk"].ToString(), Oreadr["Tot"].ToString(), Oreadr["PxPrice"].ToString(), Oreadr["AGPrice"].ToString(), Oreadr["AlsQty"].ToString());
					//if (!alsAdded)
					if (!AlsNodeAdded(Nals, nbSol, nbSpc))
					{
						addNode_Als(Nals, nbSol, nbSpc);
						nbAls = (nbSpc == 0) ? 0 : tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count;
					}
					//Oals = Nals;
				}
				Ospc = Nspc;
				Oals = Nals;
				
				double ddUP = (Oreadr["Uprice"].ToString() == "") ? 0 : Tools.Conv_Dbl(Oreadr["Uprice"].ToString());
				string LA = (Oreadr["LeadTime"].ToString() == "") ? "04-06" : Oreadr["LeadTime"].ToString();
				string stSql2 = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " + 
					" [Desc],[Qty],[Xch_Mult], [Uprice],[Mult],[Ext],[LeadTime],[PN],[Q_tec_Val], [Rnk] ) VALUES ('" +
					r_alsId.ToString() + "', '" +
					Oreadr["Aff_ID"].ToString() + "', '" +
					Oreadr["Desc"].ToString().Replace("'", "''") + "', '" +
					Oreadr["Qty"] + "', '" +
					Oreadr["Xch_Mult"] + "', '" +
					Oreadr["Uprice"] + "', '" +
					Oreadr["Mult"] + "', '" +
					Oreadr["Ext"] + "', '" +
					Oreadr["LeadTime"] + "', '" +
					Oreadr["PN"] + "', '" +
					Oreadr["Q_tec_Val"] + "', '" +
					Oreadr["Details_Rnk"].ToString() + "')";
			    //MainMDI.Write_JFS(stSql);
			    //if (!MainMDI.ExecSql(stSql2)) MessageBox.Show("Error Details Duplication....");
                arr_Sql[S++] = stSql2;
                //MainMDI.Write_JFS(stSql);
                //if (!MainMDI.ExecSql_Big(stSql2)) MessageBox.Show("Error Details Duplication....");
            }
            Oreadr.Close();
            OConn.Close();
            for (int i = 0; i < S; i++)
            {
                MainMDI.Write_JFS(arr_Sql[i]);
                if (!MainMDI.ExecSql(arr_Sql[i]))
                {
                    MessageBox.Show("Error Details Duplication....");
                    i = S;
                }
            }
			tvSol.Select();
	    }

		/*
		double ddUP = (Oreadr["Uprice"].ToString().Length < 2) ? 0 : Tools.Conv_Dbl(Oreadr["Uprice"].ToString());
		int LA = (Oreadr["LeadTime"].ToString() == "") ? 0 : Convert.ToInt32(Oreadr["LeadTime"].ToString());
		string stSql2 = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " + 
			" [Desc],[Qty],[Xch_Mult], [Uprice],[Mult],[Ext],[LeadTime],[PN], [Rnk] ) VALUES ('" +
			r_alsId.ToString() + "', '" +
			Oreadr["Aff_ID"].ToString() + "', '" +
			Oreadr["Desc"].ToString().Replace("'", "''") + "', '" +
			Tools.Conv_Dbl(Oreadr["Qty"].ToString()) + "', '" +
			Tools.Conv_Dbl(Oreadr["Xch_Mult"].ToString()) + "', '" +
			ddUP.ToString() + "', '" +
			Tools.Conv_Dbl(Oreadr["Mult"].ToString()) + "', '" +
			Tools.Conv_Dbl(Oreadr["Ext"].ToString()) + "', '" +
			LA.ToString() + "', '" +
			Oreadr["PSM_Q_Details.Rnk"].ToString() + "')";
		*/

        private void ini_arrSql()
        {
            for (int i = 0; i < arr_Sql.Length; i++) arr_Sql[i] = "";
        }

        private void Duplica_SPC()
		{
		    ini_arrSql(); int S = 0;

			int nbSol = 1, nbSpc = 1, nbAls = 1;
			long r_Spcid = 0, r_SolId = 0, r_alsId = 0;
			string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* ,PSM_Q_ALS.Rnk as A_Rnk, PSM_Q_SOL.Sol_LID AS SOL_ID, PSM_Q_ALS.Rnk AS ALS_Rnk, PSM_Q_Details.Rnk AS Details_Rnk " +
				" FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
				" WHERE (PSM_Q_IGen.i_Quoteid=" + lCurrIQID.Text + " and PSM_Q_SOL.Sol_Name='" + lCurSoln.Text + "' and PSM_Q_SPCS.SPC_Name='" + lCurSPCn.Text.Replace("'", "''") + "') ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
			
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
            //Ocmd.CommandTimeout = 1000;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			string Nsol = "", Ospc = "", Nspc = "", Nals = "", Oals = "";
			nbSol = Convert.ToInt32(lCurSolNDX.Text);
			//r_SolId = Save_SOL(lCurrIQID.Text, Nsol, nbSol.ToString(), Oreadr["img"].ToString());
			//r_SolId = Convert.ToInt32(lC urrIQID.Text);
			while (Oreadr.Read())
			{
				if (r_SolId == 0) r_SolId = Convert.ToInt32(Oreadr["SOL_ID"].ToString());
				Nsol = Oreadr["Sol_Name"].ToString();
				//if (r_SolId == 0) r_SolId = Save_SOL(lCurrIQID.Text, Nsol, nbSol.ToString(), Oreadr["img"].ToString());
				if (Nspc == "") Nspc = "Copy_" + Oreadr["SPC_Name"].ToString();
				Nals = Oreadr["ALS_Name"].ToString();
				if (Ospc != Nspc)
				{
					if (tvSol.Nodes[nbSol].Nodes.Count == 0)
					{
						nbSpc = 0;
						nbAls = 0;
					}
					else
					{
						nbSpc = tvSol.Nodes[nbSol].Nodes.Count;
						//nbAls = tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count;
						nbAls = tvSol.Nodes[Convert.ToInt32(lCurSolNDX.Text)].Nodes[Convert.ToInt32(lCurSPCNDX.Text)].Nodes.Count;
						//if (nbAls > 0) nbAls--;
					}
					if (nbAls > 0) nbAls -= 1;
					Nspc = "Copy" + nbSpc + "_" + Oreadr["SPC_Name"].ToString();
					r_Spcid = Save_SPEC(r_SolId, Nspc.ToString(), nbSpc.ToString());
					addNode_Spc(Nspc, nbSol, nbSpc, Nals); //alsAdded = true;
					nbAls++;
                    Ospc = Nspc;
				}
				//if (Oals != Nals || alsAdded)
				if (Oals != Nals) //&& !alsAdded)
				{
					//r_alsId = Save_ALS(r_Spcid, Nals, nbAls.ToString(), Oreadr["tot"].ToString());
					r_alsId = Save_ALS(r_Spcid, Nals, Oreadr["ALS_Rnk"].ToString(), Oreadr["Tot"].ToString(), Oreadr["PxPrice"].ToString(), Oreadr["AGPrice"].ToString(), Oreadr["AlsQty"].ToString());
					//if (!alsAdded)
					if (!AlsNodeAdded(Nals, nbSol, nbSpc))
					{	
						addNode_Als(Nals, nbSol, nbSpc);

						nbAls = (nbSpc == 0) ? 0 : tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count;
					}
					Oals = Nals;
				}
				double ddUP = (Oreadr["Uprice"].ToString() == "") ? 0 : Tools.Conv_Dbl(Oreadr["Uprice"].ToString());
				string LA = (Oreadr["LeadTime"].ToString() == "") ? "04-06" : Oreadr["LeadTime"].ToString();
				string stSql2 = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " + 
					" [Desc],[Qty],[Xch_Mult], [Uprice],[Mult],[Ext],[LeadTime],[PN],[Q_tec_Val], [Rnk] ) VALUES ('" +
					r_alsId.ToString() + "', '" +
					Oreadr["Aff_ID"].ToString() + "', '" +
					Oreadr["Desc"].ToString().Replace("'", "''") + "', '" +
					Oreadr["Qty"] + "', '" +
					Oreadr["Xch_Mult"] + "', '" +
					Oreadr["Uprice"] + "', '" +
					Oreadr["Mult"] + "', '" +
					Oreadr["Ext"] + "', '" +
					Oreadr["LeadTime"] + "', '" +
					Oreadr["PN"] + "', '" +
					Oreadr["Q_tec_Val"] + "', '" + 
        			Oreadr["Details_Rnk"].ToString() + "')";
                arr_Sql[S++] = stSql2;
			    //MainMDI.Write_JFS(stSql);
			    //if (!MainMDI.ExecSql_Big(stSql2)) MessageBox.Show("Error Details Duplication....");
			}
            Oreadr.Close();
            OConn.Close();
            for (int i = 0; i < S; i++)
            {
                	MainMDI.Write_JFS(arr_Sql[i]);
                    if (!MainMDI.ExecSql(arr_Sql[i]))
                    {
                        MessageBox.Show("Error Details Duplication....");
                        i = S;
                    }
            }
			tvSol.Select();
		}

        private bool AlsNodeAdded(string AlsNme, int nbSol, int nbSpc)
		{
			for (int i = 0; i < tvSol.Nodes[nbSol].Nodes[tvSol.Nodes[nbSol].Nodes.Count - 1].Nodes.Count; i++)
				if (tvSol.Nodes[nbSol].Nodes[tvSol.Nodes[nbSol].Nodes.Count - 1].Nodes[i].Text == AlsNme) return true;
			return false;
		}

		private void Duplica_ALS()
		{
			bool alsAdded = false;
			int nbSol = 1, nbSpc = 1, nbAls = 1;
			long r_Spcid = 0, r_SolId = 0, r_alsId = 0;
			string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* " +
				" FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
				" WHERE (PSM_Q_IGen.i_Quoteid=" + lCurrIQID.Text + " and PSM_Q_SOL.Sol_Name='" + lCurSoln.Text + "' and PSM_Q_SPCS.SPC_Name='" + lCurSPCn.Text.Replace("'", "''") + "') ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
			
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			string Nsol = "", Ospc = "", Nspc = "", Nals = "", Oals = "";
			nbSol = Convert.ToInt32(lCurSolNDX.Text);
			//r_SolId = Save_SOL(lCurrIQID.Text, Nsol, nbSol.ToString(), Oreadr["img"].ToString());
			
			while (Oreadr.Read())
			{
				alsAdded = false;
				Nsol = Oreadr["Sol_Name"].ToString();
				if (r_SolId == 0) r_SolId = Save_SOL(lCurrIQID.Text, Nsol, nbSol.ToString(), Oreadr["img"].ToString());
				if (Nspc == "") Nspc = "Copy_" + Oreadr["SPC_Name"].ToString();
				Nals = Oreadr["ALS_Name"].ToString();
				if (Ospc != Nspc)
				{
					if (tvSol.Nodes[nbSol].Nodes.Count == 0)
					{
						nbSpc = 0;
						nbAls = 0;
					}
					else
					{
						nbSpc = tvSol.Nodes[nbSol].Nodes.Count;
						//nbAls = tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count;
						nbAls = tvSol.Nodes[Convert.ToInt32(lCurSolNDX.Text)].Nodes[Convert.ToInt32(lCurSPCNDX.Text)].Nodes.Count;
						if (nbAls > 0) nbAls--;
					}
					Nspc = "Copy" + nbSpc + "_" + Oreadr["SPC_Name"].ToString();
					r_Spcid = Save_SPEC(r_SolId, Nspc.ToString(), nbSpc.ToString());
					addNode_Spc(Nspc, nbSol, nbSpc, Nals); alsAdded = true;
					Ospc = Nspc;
				}
				if (Oals != Nals || alsAdded)
				{
					//r_alsId = Save_ALS(r_Spcid, Nals, nbAls.ToString(), Oreadr["tot"].ToString());
					r_alsId = Save_ALS(r_Spcid, Nals, Oreadr["PSM_Q_ALS.Rnk"].ToString(), Oreadr["Tot"].ToString(), Oreadr["PxPrice"].ToString(), Oreadr["AGPrice"].ToString(), Oreadr["AlsQty"].ToString());
					if (!alsAdded)
					{	
						addNode_Als(Nals, nbSol, nbSpc);
						nbAls = (nbSpc == 0) ? 0 : tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count;
					}
					Oals = Nals;
				}
				//double ddUP = (Oreadr["Uprice"].ToString().Length < 2) ? 0 : Tools.Conv_Dbl(Oreadr["Uprice"].ToString());
				double ddUP = (Oreadr["Uprice"].ToString() == "") ? 0 : Tools.Conv_Dbl(Oreadr["Uprice"].ToString());
			    //int LA = (Oreadr["LeadTime"].ToString() == "") ? 0 : Convert.ToInt32(Oreadr["LeadTime"].ToString());
				string LA = (Oreadr["LeadTime"].ToString() == "") ? "04-06" : Oreadr["LeadTime"].ToString();
				string stSql2 = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " + 
					" [Desc],[Qty],[Mult], [Uprice],[LeadTime],[Rnk] ) VALUES ('" +
					r_alsId.ToString() + "', '" +
					Oreadr["Aff_ID"].ToString() + "', '" +
					Oreadr["Desc"].ToString().Replace("'", "''") + "', '" +
					Tools.Conv_Dbl(Oreadr["Qty"].ToString()) + "', '" +
					Tools.Conv_Dbl(Oreadr["Xch_Mult"].ToString()) + "', '" +
					ddUP.ToString() + "', '" +
					LA.ToString() + "', '" +
					Oreadr["PSM_Q_Details.Rnk"].ToString() + "')";
				MainMDI.Write_JFS(stSql);
				if (!MainMDI.ExecSql(stSql2)) MessageBox.Show("Error Details Duplication....");
			}
			tvSol.Select();
		}

		private void Save_LBL(string NewLBL, string OldLbl)
		{ //???
			if (lCurrIQID.Text != "0")
			{
				switch (tvSol.SelectedNode.ImageIndex)
				{
					case 1: //Spec
						lCurSPCn.Text = NewLBL;
						string st = MainMDI.Find_One_Field("SELECT PSM_Q_SPCS.SPC_LID FROM PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID " +
							" WHERE PSM_Q_SOL.Sol_Name='" + lCurSoln.Text + "' AND PSM_Q_SPCS.SPC_Name='" + OldLbl.Replace("'", "''") + "' and PSM_Q_SOL.I_Quoteid=" + lCurrIQID.Text);
						if (st != MainMDI.VIDE) MainMDI.ExecSql("UPDATE PSM_Q_SPCS SET [SPC_Name]='" + NewLBL.Replace("'", "''") + "' where SPC_LID=" + st);
						break;
					case 0: //Alias
					case 3:
						//if (lCurSPCn.Text == MainMDI.VIDE) del_Spc(lCurSoln.Text, lCurSPCn.Text);
						lCurALSn.Text = NewLBL;
						string stSql = "SELECT PSM_Q_ALS.ALS_LID FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
							" WHERE PSM_Q_SOL.Sol_Name='" + lCurSoln.Text + "' AND PSM_Q_SPCS.SPC_Name='" + lCurSPCn.Text.Replace("'", "''") + "' AND PSM_Q_ALS.ALS_Name='" + OldLbl.Replace("'", "''") + "' and PSM_Q_SOL.I_Quoteid=" + lCurrIQID.Text;
						stSql = MainMDI.Find_One_Field(stSql);
						if (stSql != MainMDI.VIDE) MainMDI.ExecSql("UPDATE PSM_Q_ALS SET  [ALS_Name]='" + NewLBL.Replace("'", "''") + "' where ALS_LID=" + stSql);
						//lCurALSn.Text = NewLBL;
						break;
					case 2: //Solution
					case 5:
					case 4:
						//excluded
					    //lCurSoln.Text = NewLBL;
					    //MainMDI.ExecSql("UPDATE PSM_Q_SOL SET [Sol_Name]='" + NewLBL + "' where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + tvSol.SelectedNode.Text + "'");
						break;
				}
				OldLabel = "";
			}
		}

		private void Save_LBLold(string NewLBL, string OldLbl)
		{ //???
			if (lCurrIQID.Text != "0")
			{
				switch (tvSol.SelectedNode.ImageIndex)
				{
					case 1: //Spec
						lCurSPCn.Text = NewLBL;
						string st = MainMDI.Find_One_Field("SELECT PSM_Q_SPCS.SPC_LID FROM PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID " +
							" WHERE (((PSM_Q_SOL.Sol_Name)='" + lCurSoln.Text + "') AND ((PSM_Q_SPCS.SPC_Name)='" + OldLbl.Replace("'", "''") + "'))");
						if (st != MainMDI.VIDE) MainMDI.ExecSql("UPDATE PSM_Q_SPCS SET [SPC_Name]='" + NewLBL.Replace("'", "''") + "' where SPC_LID=" + st);
						break;
					case 0: //Alias
					case 3:
						//if (lCurSPCn.Text == MainMDI.VIDE) del_Spc(lCurSoln.Text, lCurSPCn.Text);
						lCurALSn.Text = NewLBL;
						string stSql = "SELECT PSM_Q_ALS.ALS_LID FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
							" WHERE (((PSM_Q_SOL.Sol_Name)='" + lCurSoln.Text + "') AND ((PSM_Q_SPCS.SPC_Name)='" + lCurSPCn.Text.Replace("'", "''") + "') AND ((PSM_Q_ALS.ALS_Name)='" + OldLbl.Replace("'", "''") + "'))";
						stSql = MainMDI.Find_One_Field(stSql);
						if (stSql != MainMDI.VIDE) MainMDI.ExecSql("UPDATE PSM_Q_ALS SET  [ALS_Name]='" + NewLBL.Replace("'", "''") + "' where ALS_LID=" + stSql);
					    //lCurALSn.Text = NewLBL;
						break;
					case 2: //Solution
					case 5:
					case 4:
						lCurSoln.Text = NewLBL;
						 MainMDI.ExecSql("UPDATE PSM_Q_SOL SET [Sol_Name]='" + NewLBL + "' where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + tvSol.SelectedNode.Text + "'");
						break;
				}
				OldLabel = "";
			}
		}

		//END Prog. Methodes 

		private void cbSi_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lSi.Text = MainMDI.Find_One_Field("select SA_ID from PSM_SALES_AGENTS where (First_Name + ' ' + Last_Name) ='" + cbSi.Text + "' AND SA='S'");
			if (lSi.Text == MainMDI.VIDE) lSi.Text = "0";
		}

		private void cbSo_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lSO.Text = MainMDI.Find_One_Field("select SA_ID from PSM_SALES_AGENTS where (First_Name + ' ' + Last_Name)='" + cbSo.Text + "' AND SA='S'");
			if (lSO.Text == MainMDI.VIDE) lSO.Text = "0";
		}

		private void cbSe_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lSE.Text = MainMDI.Find_One_Field("select SA_ID from PSM_SALES_AGENTS where (First_Name + ' ' + Last_Name)='" + cbSe.Text + "' AND SA='S'");
			if (lSE.Text == MainMDI.VIDE) lSE.Text = "0";
		}

		private void cbSp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lSP.Text = MainMDI.Find_One_Field("select SA_ID from PSM_SALES_AGENTS where (First_Name + ' ' + Last_Name)='" + cbSp.Text + "' AND SA='S'");
			if (lSP.Text == MainMDI.VIDE) lSP.Text = "0";
		}

		private void tvSol_AfterLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
			if (e.Label != null)
			{
			    //if (e.Label.IndexOf("\\", 0) > -1 || e.Label == "" || labelExist(e.Label))
				if (e.Label.IndexOf("\\", 0) > -1 || e.Label.Length < 2 || LBL_Exist(e.Label) || e.Label.IndexOf(" ") > -1)
				{
					MessageBox.Show("INVALID new name    (Empty name, '\\' and spaces are not allowed .....    OR this Name already Exists !!!  ");
					e.CancelEdit = true;
				}
				else if (OldLabel != "" && e.Label != OldLabel) Save_LBL(e.Label, OldLabel);
			}
		}

		private void lvQITEMS_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
		
		}

		private void pictureBox2_Click(object sender, System.EventArgs e)
		{
			if (cbSi.Text != "")
			{
				cbSe.Text = cbSi.Text;
				cbSo.Text = cbSi.Text;
				cbSi.Text = cbSi.Text;
				cbSp.Text = cbSi.Text;
			}
		}

		private void lvQITEMS_DoubleClick(object sender, System.EventArgs e)
		{
		    //lvQITEMS.SelectedItems[0].Remove();
		    //if (lvQITEMS.SelectedItems[0].SubItems[7].Text != "")
		    //{
			if (lcurSol_Status.Text != "C" || MainMDI.User == "ede")
			{
				//picDwn.Visible = false;
				//picUp.Visible = false;
				if (MainMDI.User == "ede") tTV.Visible = true;
				if (in_opera != 'C')
				{
                    //tdesc.Enabled = (!(lvQITEMS.SelectedItems[0].SubItems[10].Text == "ALRM" && lvQITEMS.SelectedItems[0].SubItems[12].Text != "" || lvQITEMS.SelectedItems[0].SubItems[10].Text != ""));			
				    //tdesc.Enabled = ((lvQITEMS.SelectedItems[0].SubItems[12].Text == "" && lvQITEMS.SelectedItems[0].SubItems[10].Text == ""));			
					ndxSelect = lvQITEMS.SelectedItems[0].Index;
					tqty.Text = lvQITEMS.SelectedItems[0].SubItems[3].Text;
					tNB.Text = lvQITEMS.SelectedItems[0].SubItems[1].Text;
					tmult.Text = lvQITEMS.SelectedItems[0].SubItems[4].Text;
					tUprice.Text = (lvQITEMS.SelectedItems[0].SubItems[5].Text == "") ? "0" : lvQITEMS.SelectedItems[0].SubItems[5].Text;
                    tXchng.Text = "1"; //lvQITEMS.SelectedItems[0].SubItems[6].Text; group
					tExt.Text = lvQITEMS.SelectedItems[0].SubItems[7].Text;

                    tSaleExt.Text = tExt.Text;
                    tAGExt.Text = tExt.Text;

					tLT.Text = lvQITEMS.SelectedItems[0].SubItems[8].Text;
					if (tLT.Text.Length < 5) tLT.Text = "04-06";
					minLT.Text = tLT.Text.Substring(0, 2);
					MaxLT.Text = tLT.Text.Substring(3, 2);
					tdesc.Text = lvQITEMS.SelectedItems[0].SubItems[2].Text;
					TOALS.Text = AlsTOT_orig.Text;
					tTV.Text = lvQITEMS.SelectedItems[0].SubItems[12].Text;
					lALSmAmnt.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(AlsTOT_orig.Text) - Tools.Conv_Dbl(tExt.Text), MainMDI.Q_NB_DEC_AFF));
                    CB_Group.Text = lvQITEMS.SelectedItems[0].SubItems[6].Text; //group 
					if (tqty.Text != "" || tmult.Text != "" || tUprice.Text != "")
					{
						lvQITEMS.SelectedItems[0].Checked = !lvQITEMS.SelectedItems[0].Checked;
						grpChng.Visible = true;
						grpCmnt.Visible = !grpChng.Visible;
						tqty.Focus();
						//tmrChng.Enabled = true;
					}
					else
					{
						tqty.Text = "";
						tmult.Text = "";
						tUprice.Text = "";
					}
				    //tNB.Visible = (tNB.Text != "" && tNB.Text != " ");
				    //lnb.Visible = (tNB.Text != "" && tNB.Text != " ");
					chkTBP.Checked = lvQITEMS.SelectedItems[0].Checked;
				    //lvQITEMS.Enabled = false;
				    //tvSol.Enabled = false;
					Enable_ALL(false);
					lvQITEMS.SelectedItems[0].BackColor = Color.Aqua;
				}
			}
			else MessageBox.Show("This Revision cannot be Modified !!!");
		}

		private void modif_All_Items()
		{
			if (lcurSol_Status.Text != "C")
			{
				if (in_opera != 'C')
				{
                   	tAqty.Text = MainMDI.VIDE;
					tAmult.Text = MainMDI.VIDE;
					tAup.Text = MainMDI.VIDE;
				    //lALT.Text = "04-06";
				    //minLT.Text = lALT.Text.Substring(0, 2);
				    //MaxLT.Text = lALT.Text.Substring(3, 2);
					Enable_ALL(false);
					grpAmodif.Visible = true;
				}
			}
			else MessageBox.Show("No item of this Revision can be Modified !!!");
		}

        /*
		private void lvQITEMS_DoubleClickOLD(object sender, System.EventArgs e)
		{
			//lvQITEMS.SelectedItems[0].Remove();
			if (lvQITEMS.SelectedItems[0].SubItems[7].Text != "" && lvQITEMS.SelectedItems[0].SubItems[12].Text == "")
			{
				tqty.Text = lvQITEMS.SelectedItems[0].SubItems[3].Text;
				tmult.Text = lvQITEMS.SelectedItems[0].SubItems[4].Text;
				tUprice.Text = (lvQITEMS.SelectedItems[0].SubItems[5].Text == "") ? "0" : lvQITEMS.SelectedItems[0].SubItems[5].Text;
				tXchng.Text = lvQITEMS.SelectedItems[0].SubItems[6].Text;
				tExt.Text = lvQITEMS.SelectedItems[0].SubItems[7].Text;
				tLT.Text = lvQITEMS.SelectedItems[0].SubItems[8].Text;
				tdesc.Text = lvQITEMS.SelectedItems[0].SubItems[2].Text;
				if (tqty.Text != "" || tmult.Text != "" || tUprice.Text != "")
				{
					lvQITEMS.SelectedItems[0].Checked = !lvQITEMS.SelectedItems[0].Checked;
					grpChng.Visible = true;
					grpCmnt.Visible = !grpChng.Visible;
					tqty.Focus();
					tmrChng.Enabled = true;
				}
				else
				{
					tqty.Text = "";
					tmult.Text = "";
					tUprice.Text = "";
				}
			}
		}
        */

		private void groupBox3_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void cbSS_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void cbCQA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		    //if (cbCQA.Text != cbCompany.Text) fill_Company_Info(cbCQA.Text, 'Q');
			fill_Company_Info(cbCQA.Text, 'Q');
		}

		private void cbCPA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//if (cbCPA.Text != cbCompany.Text) fill_Company_Info(cbCPA.Text, 'P');
			fill_Company_Info(cbCPA.Text, 'P');
		}

		private void cbCSA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//if (cbCSA.Text != cbCompany.Text) fill_Company_Info(cbCSA.Text, 'S');
			fill_Company_Info(cbCSA.Text, 'S');
		}

		private void cbCIA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//if (cbCIA.Text != cbCompany.Text) fill_Company_Info(cbCIA.Text, 'I');
			fill_Company_Info(cbCIA.Text, 'I');
		}

		private void btnAP_Click(object sender, System.EventArgs e)
		{
			QuoteXAdrs('P', lPA.Text);
		}

		private void btnAS_Click(object sender, System.EventArgs e)
		{
			QuoteXAdrs('S', lSA.Text);
			
		    //dlgAdrs dAdrs = new dlgAdrs("");
		    //dAdrs.chkSave.Visible = true;
		    //dAdrs.ShowDialog();
		    //if (dAdrs.tStreet.Text != "")
		        //lSA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text + "," + dAdrs.tZip.Text + "," + dAdrs.cbCountry.Text;
		    //if (dAdrs.chkSave.Checked) save_Adrs('S');
		}

		private void btnAI_Click(object sender, System.EventArgs e)
		{
			QuoteXAdrs('I', lIA.Text);
		}

		private void btnNewID_Click(object sender, System.EventArgs e)
		{
			//MessageBox.Show(Imp_IQID);
			if (MainMDI.ALWD_USR("QT_SV", true))
			{
				if (tQuoteID.Text == "")
				{
					if (MainMDI.Find_One_Field("select NewQ from PSM_SYSETUP ") == "1")
					{
						gifCounter.Visible = true;
						this.Refresh();
						init_Curr_ALS();
						long Res = fill_QID();
						if (Res == 0 || Res == -1) this.Close();
						else lCurr_opera.Text = "N";
						gifCounter.Visible = false;
					}
					else MessageBox.Show("New Quotes are impossible");
				}
			}
		}

		private void mnuSPare_Click(object sender, System.EventArgs e)
		{
		    if (MainMDI.profile != 'R') Sol_Rep_SPP('S');
		}

		private void mnuRepair_Click(object sender, System.EventArgs e)
		{
			if (MainMDI.profile != 'R') Sol_Rep_SPP('R');
		}

		private void Rev_Click(object sender, System.EventArgs e)
		{
			if (MainMDI.profile != 'R') Sol_Rep_SPP('V');
		}

		private void RevMnu_Popup(object sender, System.EventArgs e)
		{

		}

		private void lvQITEMS_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		    //picDwn.Visible = true;
		    //picUp.Visible = true;
			MNoCut.Enabled =(lvQITEMS.SelectedItems.Count > 0);
			mnOcopy.Enabled =(lvQITEMS.SelectedItems.Count > 0);
            MNocopyTxt.Enabled = (lvQITEMS.SelectedItems.Count > 0);
		}

		//if (lvQITEMS.SelectedItems[0].SubItems[7].Text != "")
		//{

		private void btnOKchng_Click(object sender, System.EventArgs e)
		{
			if (lcurSol_Status.Text != "C") //never update converted quote because details are deleted and created !!!
			{
				tExt.ReadOnly = true;
				tExt.Text = Tools.Conv_Dbl(tExt.Text).ToString();
				if (maj_LT())
				{
					//if ((tExt.Text != "0" && tExt.Text != "") || lvQITEMS.Items[ndxSelect].SubItems[7].Text == "")
					//{
					    //if (Tools.Conv_Dbl(lvQITEMS.Items[ndxSelect].SubItems[7].Text) != 0)
					    if (Tools.Conv_Dbl(tExt.Text) != 0)
					    {
                            //if (CB_Group.Text == "") CB_Group.Text = "A";
						    lvQITEMS.Items[ndxSelect].SubItems[3].Text = tqty.Text;
                            lvQITEMS.Items[ndxSelect].SubItems[6].Text = (CB_Group.Text == "") ? "A" : CB_Group.Text; //tXchng.Text;
						    lvQITEMS.Items[ndxSelect].SubItems[4].Text = tmult.Text;
					    }
					    else
					    {
						    lvQITEMS.Items[ndxSelect].SubItems[3].Text = (tqty.Text != "") ? tqty.Text : "0";
                            lvQITEMS.Items[ndxSelect].SubItems[6].Text = "A"; //CB_Group.Text;
						    lvQITEMS.Items[ndxSelect].SubItems[4].Text = "0";
					    }
					    if (tNB.Visible) lvQITEMS.Items[ndxSelect].SubItems[1].Text = (tNB.Text == "") ? " " : tNB.Text;
					    //added to avoid blank DESC
					    lvQITEMS.Items[ndxSelect].SubItems[2].Text = (tdesc.Text.Length > 0) ? tdesc.Text : "   ";
					    if (tUprice.Text != "0") lvQITEMS.Items[ndxSelect].SubItems[5].Text = tUprice.Text;
					    lvQITEMS.Items[ndxSelect].SubItems[7].Text = MainMDI.A00(tExt.Text);
					    if (tExt.Text != "") lvQITEMS.Items[ndxSelect].SubItems[8].Text = tLT.Text;
					    else lvQITEMS.Items[ndxSelect].SubItems[8].Text = "";
					    lvQITEMS.Items[ndxSelect].Checked = chkTBP.Checked;
					    Tosave = true;
					    if (lvQITEMS.Items[ndxSelect].ForeColor == Color.Red && tExt.Text != "0" && tExt.Text != " " && tExt.Text != "") lvQITEMS.Items[ndxSelect].ForeColor = Color.Black;
                        Ref_ALSTOT('A'); //????
					    ChngCancel_Click(sender, e);
					    Enable_ALL(true);
					    //lvQITEMS.Enabled = true;
					    //tvSol.Enabled = true;
					//}
					//else MessageBox.Show("Sell Price is Invalid (Extension) !!!!!");
				}
				lvQITEMS.SelectedItems[0].BackColor = (tNB.Text == "" || tNB.Text == " ") ? Color.WhiteSmoke : Color.Salmon;
			}
			else MessageBox.Show("Save Denied....(converted Rev.)....");
		}

        /*
        private void btnOKchng_ClickOld(object sender, System.EventArgs e)
        {
            if (maj_LT())
            {
                if ((tExt.Text != "0" && tExt.Text != "") || lvQITEMS.SelectedItems[0].SubItems[7].Text == "")
                {
                    if (lvQITEMS.SelectedItems[0].SubItems[7].Text != "")
                    {
                        lvQITEMS.SelectedItems[0].SubItems[3].Text = tqty.Text;
                        lvQITEMS.SelectedItems[0].SubItems[6].Text = tXchng.Text;
                        lvQITEMS.SelectedItems[0].SubItems[4].Text = tmult.Text;
                    }
                    lvQITEMS.SelectedItems[0].SubItems[2].Text = tdesc.Text;
                    if (tUprice.Text != "0") lvQITEMS.SelectedItems[0].SubItems[5].Text = tUprice.Text;
                    lvQITEMS.SelectedItems[0].SubItems[7].Text = tExt.Text;
                    if (tExt.Text != "") lvQITEMS.SelectedItems[0].SubItems[8].Text = tLT.Text;
                    else lvQITEMS.SelectedItems[0].SubItems[8].Text = "";
                    Tosave = true;
                    Ref_ALSTOT('A');
                    ChngCancel_Click(sender, e);
                }
                else MessageBox.Show("Sell Price is Invalid (Extension) !!!!!");
            }
        }

        private void btnOKchng_Clickold(object sender, System.EventArgs e)
        {
            if (tExt.Text != "0" && tExt.Text != "")
            {
                lvQITEMS.SelectedItems[0].SubItems[3].Text = tqty.Text;
                lvQITEMS.SelectedItems[0].SubItems[2].Text = tdesc.Text;
                lvQITEMS.SelectedItems[0].SubItems[4].Text = tmult.Text;
                lvQITEMS.SelectedItems[0].SubItems[5].Text = tUprice.Text;
                lvQITEMS.SelectedItems[0].SubItems[6].Text = tXchng.Text;
                lvQITEMS.SelectedItems[0].SubItems[7].Text = tExt.Text;
                lvQITEMS.SelectedItems[0].SubItems[8].Text = tLT.Text;
                Tosave = true;
                Ref_ALSTOT('A');
                ChngCancel_Click(sender, e);
            }
            else MessageBox.Show("Sell Price is Invalid (Extension) !!!!!");
        }
        */

        private void ChngCancel_Click(object sender, System.EventArgs e)
		{
			grpChng.Visible = false;
			tqty.Text = "";
			tmult.Text = "";
			tUprice.Text = "";
			grpCmnt.Visible = !grpChng.Visible;
            Enable_ALL(true);
			lvQITEMS.SelectedItems[0].BackColor = (tNB.Text == "" || tNB.Text == " ") ? Color.WhiteSmoke : Color.Salmon;
		}

		private void tmrChng_Tick(object sender, System.EventArgs e)
		{
			if (grpChng.Visible)
			{
				ChngCancel_Click(sender, e);
				tmrChng.Enabled = false;
			}
		}

		private void cbSi_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox8_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void tvSol_BeforeSelect(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
			SAVE_CHANGE_ALS();
		}

		private void SAVE_CHANGE_ALS()
		{
			if (MainMDI.PermT_user("QS"))
			{
				if (Tosave)
				{
					DialogResult dr = MessageBox.Show("Save Changes ? : ", "Saving....", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
					if (dr == DialogResult.Yes)
					{
						Save_Q_ALL_Details();
						//Maj_AlsTOT();
					}
					Tosave = false;
				}
			}
		}

		private void Maj_AlsTOT()
		{
			if (lcurrALSLID.Text != "0")
			{
				MainMDI.ExecSql("UPDATE PSM_Q_ALS SET [Tot]='" + AlsTOT_orig.Text + "' where ALS_LID=" + lcurrALSLID.Text);
			    //AlterTOT.Text = MainMDI.A00(MainMDI.SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
                AlterTOT.Text = MainMDI.Curr_FRMT(MainMDI.SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
			}
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			Add_option();
	    }

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			Add_CBR('C');
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Add_CBR('B');
		}

		private void menuItem7_Click(object sender, System.EventArgs e)
		{
	    	Add_CBR('R');
		}

		private void lvQITEMS_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			//MessageBox.Show("ITEMW: " + lvQITEMS.Width + " thiW= " + this.Width + "\n" + "   ITMH= " + lvQITEMS.Height + "ThisH= " + this.Height);
			
	        //MessageBox.Show("grpTab H: " + gbxSol.Height + " thiH= " + this.Height + "\n" + "   ITMH= " + lvQITEMS.Height + "ThisH= " + this.Height);
		    //tvSol.CheckBoxes = true;
			//tvSol.RecreatingHandle = true;
            //grpOrder.Height = this.Height - 202;
	        //tvSol.Refresh();
		}

		private void gbxSol_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void lvQITEMS_SelectedIndexChanged_2(object sender, System.EventArgs e)
		{
		
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			Add_CBR('c');
		}

		private void tvSol_BeforeLabelEdit(object sender, System.Windows.Forms.NodeLabelEditEventArgs e)
		{
			OldLabel = e.Node.Text;
			if (e.Node.ImageIndex == 2 || lcurSol_Status.Text == "C") e.CancelEdit = true;
			//MessageBox.Show("Lbl= " + e.Label + " nod= " + OldLabel);
		}

		private void lvQITEMS_ColumnClick_1(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			//lvQITEMS.Columns[0].Width = 35;
		}

		private void btnImpChrgPrices_Click_1(object sender, System.EventArgs e)
		{
		
		}

		private void tmult_TextChanged(object sender, System.EventArgs e)
		{
			//Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(lMLTPLY.Text), Charger.NB_DEC_AFF)))
		    cal_SellExt();
		}

		private void cal_SellExt()
		{
			if (tXchng.Text == "") tXchng.Text = tXRATE.Text;
			if (tUprice.Text != "" && tqty.Text != "" && tmult.Text != "") tExt.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tmult.Text) * Tools.Conv_Dbl(tUprice.Text) * Tools.Conv_Dbl(tqty.Text) * Tools.Conv_Dbl(tXchng.Text), MainMDI.Q_NB_DEC_AFF));
		}
		private void tqty_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tmult_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tUprice_TextChanged(object sender, System.EventArgs e)
		{
			cal_SellExt();
		}

		private void tUprice_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = (Tools.OnlyDBL(e.KeyChar) || e.KeyChar == 45); //for Sign
		}

		private void tXchng_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tLT_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tXRATE_TextChanged(object sender, System.EventArgs e)
		{
			if (tXRATE.Text == "") tXRATE.Text = MainMDI.A00("1");
		}

		private void tqty_TextChanged(object sender, System.EventArgs e)
		{
			cal_SellExt();
		}

		private void tXRATE_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tXchng_TextChanged(object sender, System.EventArgs e)
		{
			cal_SellExt();
		}

		private void groupBox3_Enter_1(object sender, System.EventArgs e)
		{
		
		}

		private void tCust_Mult_TextChanged(object sender, System.EventArgs e)
		{
			//loM.Visible = STDMultp.Text != tCust_Mult.Text;
		    //STDMultp.Visible = STDMultp.Text != tCust_Mult.Text;
		}

		private void STDMultp_TextChanged(object sender, System.EventArgs e)
		{
			//loM.Visible = STDMultp.Text != tCust_Mult.Text;
			//STDMultp.Visible = STDMultp.Text != tCust_Mult.Text;
		}

		private void btnApply_Click(object sender, System.EventArgs e)
		{
            btnApply.Text = (btnApply.Text == "CAN $") ? "US $" : "CAN $";
		    ////apply USD Xrate to All Quote Items
		    //double dtot = 0;
		    //for (int i = 0; i < lvQITEMS.Items.Count; i++)
		    //{				
		        //if (lvQITEMS.Items[i].SubItems[3].Text != "" && lvQITEMS.Items[i].SubItems[4].Text != "" && lvQITEMS.Items[i].SubItems[5].Text != "")
		        //{
		            //lvQITEMS.Items[i].SubItems[6].Text = tXRATE.Text;
		            //double dext = Math.Round(Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[3].Text) * Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[4].Text) * Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[5].Text) * Tools.Conv_Dbl(tXRATE.Text), MainMDI.NB_DEC_AFF);
		            //lvQITEMS.Items[i].SubItems[7].Text = Convert.ToString(dext);
		            //dtot += dext;
		        //}
		    //}
		    //AlsTOT.Text = Convert.ToString(dtot);
		}
	
		private void P_AlsTot(string mt)
		{
			if (mt != "" && AlsTOT.Text != "") AlsTOT.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(mt) + Tools.Conv_Dbl(AlsTOT.Text), MainMDI.Q_NB_DEC_AFF));
		}

		private void M_AlsTot(string mt)
		{
			if (mt != "" && AlsTOT.Text != "") AlsTOT.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(AlsTOT.Text) - Tools.Conv_Dbl(mt), MainMDI.Q_NB_DEC_AFF));
		}

		private void Ref_ALSTOTOLD()
		{
			double dtot = 0;
			for (int i = 0; i < lvQITEMS.Items.Count; i++)
			{
				//if (lvQITEMS.Items[i].SubItems.Count == 9)
				if (lvQITEMS.Items[i].SubItems[7].Text != "") dtot = dtot + Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[7].Text);
			}
			lALSTOT.Text = lCurALSn.Text + ": ";
			AlsTOT.Text = Convert.ToString(Math.Round(dtot, MainMDI.Q_NB_DEC_AFF));
		}

		private void btnM_Click(object sender, System.EventArgs e)
		{
			tvSol.Width -= 40;
		}

		private void fill_NbDef()
		{
			/*
			int nbI = 0;
			int nb = 1;
			int Lin = 0;
			for (int i = 0; i < lvQITEMS.Items.Count; i++)
			{
				if (lvQITEMS.Items[i].SubItems[1].Text == "") nb++;
				else
				{
					arr_nbDef[lin, 0] = i;
					arr_nbDef[lin, 1] = nb;
					nb = 0;
					lin = i;
				}
            */
		}

		private void apply_OGA()
		{
			if (lvQITEMS.Items.Count > 0)
			{
				int nb = 0;
				int lin = 0;
				double dtot = 0;
				for (int i = 0; i < lvQITEMS.Items.Count; i++)
				{
					if (lvQITEMS.Items[i].SubItems[7].Text != "") dtot = dtot + Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[7].Text);
					if (lvQITEMS.Items[i].SubItems[1].Text == " " || (lvQITEMS.Items[i].SubItems[1].Text == "." && lvQITEMS.Items[i].BackColor == Color.WhiteSmoke)) nb++; //item # is always==" " not ""
					else
					{
						if (i > 0) //&& lvQITEMS.Items[i].BackColor ==)
						{
							lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
							lin = i; //if (i == lvQITEMS.Items.Count - 1) lvQITEMS.Items[lin].SubItems[9].Text = "0";
							nb = 0;
							if (Tools.Conv_Dbl(lvQITEMS.Items[lin].SubItems[8].Text) > Tools.Conv_Dbl(lHiDelv.Text)) lHiDelv.Text = lvQITEMS.Items[lin].SubItems[8].Text;
						}
					}
				}
				lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
				lALSTOT.Text = lCurALSn.Text + ": "; //" TOTAL :";
				//lALSnb.Text = lCurALSn.Text + " #:";
				AlsTOT.Text = MainMDI.A00(Convert.ToString(Math.Round(dtot, MainMDI.Q_NB_DEC_AFF)));
				lAlterTOT.Text = lCurSPCn.Text; //+ " TOTAL :";
				//string tt = SPEC_TOT(lcur
				//if (OldAlsTot.Text != "")
				//{
				    //double res_ALt_Bal = Tools.Conv_Dbl(AlterTOT.Text) + dtot - Tools.Conv_Dbl(OldAlsTot.Text);
				    //AlterTOT.Text = A00(Convert.ToString(Math.Round(res_ALt_Bal, MainMDI.NB_DEC_AFF)));
				//}
			}
			ref_PXAG_Price('O');
			MNoPaste.Enabled = (MainMDI.arr_clpB[0, 1] != "~");
			menuItem9.Enabled = MNoPaste.Enabled;
		}

		private void Ref_ALSTOT(char _op)
		{
			lHiDelv.Text = "4";
			if (lvQITEMS.Items.Count > 0)
			{
				int nb = 0;
				int lin = 0;
				double dtot = 0;
				for (int i = 0; i < lvQITEMS.Items.Count; i++)
				{
					if (lvQITEMS.Items[i].SubItems[7].Text != "") dtot = dtot + Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[7].Text);
					if (lvQITEMS.Items[i].SubItems[1].Text == " " || (lvQITEMS.Items[i].SubItems[1].Text == "." && lvQITEMS.Items[i].BackColor == Color.WhiteSmoke)) nb++; //item # is always==" " not ""
					else
					{
						if (i > 0) //&& lvQITEMS.Items[i].BackColor ==)
						{
							lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
							lin = i; //if (i == lvQITEMS.Items.Count - 1) lvQITEMS.Items[lin].SubItems[9].Text = "0";
							nb = 0;
							if (Tools.Conv_Dbl(lvQITEMS.Items[lin].SubItems[8].Text) > Tools.Conv_Dbl(lHiDelv.Text)) lHiDelv.Text = lvQITEMS.Items[lin].SubItems[8].Text;
						}
					}
				}
				lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
				lALSTOT.Text = lCurALSn.Text + ": "; //" TOTAL :";
				//lALSnb.Text = lCurALSn.Text + " #:";
				AlsTOT_orig.Text = MainMDI.A00(Convert.ToString(Math.Round(dtot, MainMDI.Q_NB_DEC_AFF)));
				lAlterTOT.Text = lCurSPCn.Text; //+ " TOTAL :";
			}
			ref_PXAG_Price(_op);
			MNoPaste.Enabled = (MainMDI.arr_clpB[0, 1] != "~");
			menuItem9.Enabled = MNoPaste.Enabled;
		}

	    /*
        private void Ref_ALSTOT_OK()
		{
			lHiDelv.Text = "4";
			if (lvQITEMS.Items.Count > 0)
			{
				int nb = 0;
				int lin = 0;
				double dtot = 0;
				for (int i = 0; i < lvQITEMS.Items.Count; i++)
				{
					if (lvQITEMS.Items[i].SubItems[7].Text != "") dtot = dtot + Tools.Conv_Dbl(lvQITEMS.Items[i].SubItems[7].Text);
					if (lvQITEMS.Items[i].SubItems[1].Text == " " || (lvQITEMS.Items[i].SubItems[1].Text == "." && lvQITEMS.Items[i].BackColor == Color.WhiteSmoke)) nb++; //item # is always==" " not ""
					else
					{
						if (i > 0) //&& lvQITEMS.Items[i].BackColor ==)
						{
							lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
							lin = i; //if (i == lvQITEMS.Items.Count - 1) lvQITEMS.Items[lin].SubItems[9].Text = "0";
							nb = 0;
							if (Tools.Conv_Dbl(lvQITEMS.Items[lin].SubItems[8].Text) > Tools.Conv_Dbl(lHiDelv.Text)) lHiDelv.Text = lvQITEMS.Items[lin].SubItems[8].Text;
						}
					}
				}
				lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
				lALSTOT.Text = lCurALSn.Text + ": "; //" TOTAL :";
		        //lALSnb.Text = lCurALSn.Text + " #:";
				AlsTOT_orig.Text = MainMDI.A00(Convert.ToString(Math.Round(dtot, MainMDI.Q_NB_DEC_AFF)));
				lAlterTOT.Text = lCurSPCn.Text; //+ " TOTAL :";
			    //string tt = SPEC_TOT(lcur
			    //if (OldAlsTot.Text != "")
			    //{
			        //double res_ALt_Bal = Tools.Conv_Dbl(AlterTOT.Text) + dtot - Tools.Conv_Dbl(OldAlsTot.Text);
			        //AlterTOT.Text = A00(Convert.ToString(Math.Round(res_ALt_Bal, MainMDI.NB_DEC_AFF)));
			    //}
			}
	        //if (Tools.Conv_Dbl(tPxPrice.Text) < Tools.Conv_Dbl(AlsTOT.Text)) tPxPrice.Text = AlsTOT.Text;
	        //if (Tools.Conv_Dbl(tAGprice.Text) < Tools.Conv_Dbl(tPxPrice.Text)) tAGprice.Text = tPxPrice.Text;
	        //tPxPrice.Text = MainMDI.A00(tPxPrice.Text);
	        //tAGprice.Text = MainMDI.A00(tAGprice.Text);

            ref_PXAG_Price();
			MNoPaste.Enabled = (MainMDI.arr_clpB[0, 1] != "~");
			menuItem9.Enabled = MNoPaste.Enabled;
		}
        */

		private void maj_Rank_ALS()
		{
            /*
			if (lvQITEMS.Items.Count > 0)
			{
		      	int nb = 1;
				int lin = 0;
				double dtot = 0;
			
				for (int i = 0; i < lvQITEMS.Items.Count; i++)
				{
					if (lvQITEMS.Items[i].SubItems[1].Text != " ")
					{
						if (lvQITEMS.Items[i].SubItems[1].Text.IndexOf(".", 0) == -1 
						nb++; //item # is always==" " not ""
					else
					{
						if (i > 0)
						{
							lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
							lin = i; //if (i == lvQITEMS.Items.Count - 1) lvQITEMS.Items[lin].SubItems[9].Text = "0";
							nb = 0;
						}
					}
				}
				lvQITEMS.Items[lin].SubItems[9].Text = nb.ToString();
				lALSTOT.Text = lCurALSn.Text + " TOTAL :";
				AlsTOT.Text = Convert.ToString(Math.Round(dtot, MainMDI.NB_DEC_AFF));
			}
			*/
		}

		//Del from LV and Save current image with current Ranks !!!!
		private void del_Als_IO(int ndx)
		{
			int ndell = 0;
			int nbDef = (lvQITEMS.Items[ndx].SubItems[9].Text == "") ? 0 : Convert.ToInt32(lvQITEMS.Items[ndx].SubItems[9].Text);
			for (int j = ndx + nbDef; j >= ndx; j--)
			{	if (lvQITEMS.Items[j].BackColor == Color.Salmon) ItemCount--;
				lvQITEMS.Items[j].Remove();
				ndell++;	
			}
			Ref_ALSTOT('D');
			
			if (lvQITEMS.Items.Count == 0) del_Als(lCurSoln.Text, lCurSPCn.Text, lCurALSn.Text);
			else if (ndell > 0)
			{
				Save_Q_ALL_Details();
				Maj_AlsTOT();
				//AlterTOT.Text = A00(SPEC_TOT(lCurrIQID.Text, lCurSoln.Text, lCurSPCn.Text));
			}
		}

		private void del_Als_IOold(int ndx)
		{
			//MessageBox.Show(lvQITEMS.SelectedItems[0].Index.ToString());
			//for (int j = lvQITEMS.SelectedItems.Count - 1; j > -1; j--)
			//{
			//string st = MainMDI.Find_One_Field("SELECT  PSM_Q_Details.Detail_LID " + 
			    //" FROM PSM_Q_IGen INNER JOIN ((PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID) ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid " +
			    //" WHERE PSM_Q_ALS.ALS_Name='" + lCurALSn.Text + "' AND PSM_Q_Details.Desc='" + lvQITEMS.SelectedItems[j].SubItems[2].Text + "' AND PSM_Q_Details.Rnk=" + j);
			//MainMDI.ExecSql("delete * FROM PSM_Q_Details WHERE Detail_LID=" + st);
			//lvQITEMS.SelectedItems[j].Remove();
		
			int ndell = 0;
			int nbDef = (lvQITEMS.Items[ndx].SubItems[9].Text == "") ? 0 : Convert.ToInt32(lvQITEMS.Items[ndx].SubItems[9].Text);
			for (int j = ndx + nbDef; j >= ndx; j--)
			{
				string st = MainMDI.Find_One_Field("SELECT  PSM_Q_Details.Detail_LID " + 
					" FROM PSM_Q_IGen INNER JOIN ((PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID) ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid " +
					" WHERE PSM_Q_ALS.ALS_Name='" + lCurALSn.Text.Replace("'", "''") + "' AND PSM_Q_Details.[Desc]='" + lvQITEMS.Items[j].SubItems[2].Text + "' AND PSM_Q_Details.Rnk =" + (j + ndell));
				if (st != MainMDI.VIDE)
				{
					 MainMDI.ExecSql("delete   PSM_Q_Details WHERE Detail_LID=" + st);
					lvQITEMS.Items[j].Remove(); ndell++;
				}
				else MessageBox.Show(" Line not found !!! or BAD SQL: ");
			}
		}

        /*
		private void Duplica_All_Sol(long NewIQID, long Orig_IQID)
		{
			bool alsAdded = false;
			int nbSol = 1, nbSpc = 1, nbAls = 1;
			long r_Spcid = 0, r_SolId = 0, r_alsId = 0;
			string stSql = "SELECT PSM_Q_SOL.*, PSM_Q_SPCS.*, PSM_Q_ALS.*, PSM_Q_Details.* " +
				" FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
				" WHERE (PSM_Q_IGen.i_Quoteid=" + Orig_IQID + "') ORDER BY PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
			
			SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			string Osol = "", Nsol = "", Ospc = "", Nspc = "", Nals = "", Oals = "";
			while (Oreadr.Read())
			{
				alsAdded = false;
				if (Nsol == "") Nsol = Oreadr["Sol_Name"].ToString();
				Nspc = Oreadr["SPC_Name"].ToString();
				Nals = Oreadr["ALS_Name"].ToString();
				if (Osol != Nsol)	
				{
					//nbSol = tvSol.Nodes.Count;
					Nsol = Oreadr["Sol_Name"].ToString();
					r_SolId = Save_SOL(NewIQID, Nsol, nbSol.ToString(), Oreadr["img"].ToString());
				    //addNode_Sol(Nsol, Oreadr["img"].ToString());
					Osol = Nsol;
				}
				if (Ospc != Nspc)
				{
					if (tvSol.Nodes[nbSol].Nodes.Count == 0) //
					{
						nbSpc = 0;
						nbAls = 0;
					}
					else
					{
						nbSpc = tvSol.Nodes[nbSol].Nodes.Count; //
						nbAls = tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count; //
					}
					r_Spcid = Save_SPEC(r_SolId, Nspc.ToString(), nbSpc.ToString());
				    //addNode_Spc(Nspc, nbSol, nbSpc, Nals);
					alsAdded = true;
					Ospc = Nspc;
				}
				if (Oals != Nals || alsAdded)
				{
					r_alsId = Save_ALS(r_Spcid, Nals, nbAls.ToString());
					if (!alsAdded)
					{	
						//addNode_Als(Nals, nbSol, nbSpc);
						nbAls = (nbSpc == 0) ? 0 : tvSol.Nodes[nbSol].Nodes[nbSpc - 1].Nodes.Count;
					}
					Oals = Nals;
				}
				double ddUP = (Oreadr["Uprice"].ToString().Length < 2) ? 0 : Tools.Conv_Dbl(Oreadr["Uprice"].ToString());
				int LA = (Oreadr["LeadTime"].ToString() == "") ? 0 : Convert.ToInt32(Oreadr["LeadTime"].ToString());
				string stSql2 = "INSERT INTO PSM_Q_Details ([ALS_LID],[Aff_ID], " + 
					" [Desc],[Qty],[Mult], [Uprice],[LeadTime],[Rnk] ) VALUES ('" +
					r_alsId.ToString() + "', '" +
					Oreadr["Aff_ID"].ToString() + "', '" +
					Oreadr["Desc"].ToString() + "', '" +
					Tools.Conv_Dbl(Oreadr["Qty"].ToString()) + "', '" +
					Tools.Conv_Dbl(Oreadr["Xch_Mult"].ToString()) + "', '" +
					ddUP.ToString() + "', '" +
					LA.ToString() + "', '" +
					Oreadr["PSM_Q_Details.Rnk"].ToString() + "')";
				if (!MainMDI.ExecSql(stSql2)) MessageBox.Show("Error Details Duplication....");
			}
			tvSol.Select();
		}

		private bool Save_Dup_IGen()
		{
			string stSql = "INSERT INTO PSM_Q_IGen ([Quote_ID],[CPNY_ID],[Employ_ID], " + 
				" [ProjectName],[Opndate],[Clsdate],[Contact_ID],[Cust_Mult],  " + 
				" [Term_ID],[Via_ID],[IncoTerm_ID], " + 
				" [SI],[SO],[SE],[SP],[SS], " + 
				" [AD],[AI],[AE],[AP],[AS], " + 
				" [QA],[SA],[PA],[IA] , " + 
				" [Lang]," +
				" [DEL]," +
				" [Cmnt]) VALUES ('" +
				tQuoteID.Text + "', '" +
				lcpnyID.Text + "', '" +
				lEmp_ID.Text + "', '" +
				tProjNAME.Text + "', '" +
				tOpendate.Text + "', '" +
				"11/11/11" + "', '" +
				lContact_ID.Text + "', '" +
				tCust_Mult.Text + "', '" +
				lTerm_ID.Text + "', '" +
				lVia_ID.Text + "', '" +
				lIncoT_ID.Text + "', '" +
				lSi.Text + "', '" +
				lSO.Text + "', '" +
				lSE.Text + "', '" +
				lSP.Text + "', '" +
				lSS.Text + "', '" +
				lAD.Text + "', '" +
				lAI.Text + "', '" +
				lAE.Text + "', '" +
				lAP.Text + "', '" +
				lAS.Text + "', '" +
				lQA.Text + "', '" +
				lSA.Text + "', '" +
				lPA.Text + "', '" +
				lIA.Text + "', '" +
				lLang.Text + "', '" +
				"N" + "', '" +
				tGCmnt.Text + "')";
			t1 = MainMDI.ExecSql(stSql);
			string stId = MainMDI.Find_One_Field("select I_Quoteid from PSM_Q_IGen where Quote_ID=" + tQuoteID.Text + " AND CPNY_ID=" + lcpnyID.Text);
			//MessageBox.Show("ID= " + MainMDI.stXP + "     foundID= " + stId);
			if (stId != MainMDI.VIDE) lCurrIQID.Text = stId;
		}
	    */

		private void AlS_Wizard()
		{
			tvSol.Nodes.Add("RV-" + MainMDI.A00(0, 2));
			tvSol.Nodes[0].ImageIndex = 2;
			tvSol.Nodes[0].SelectedImageIndex = 2;
			tvSol.Nodes[0].Nodes.Add("!Alt#1");	
            tvSol.Nodes[0].Nodes[0].SelectedImageIndex = 1;
			tvSol.Nodes[0].Nodes[0].ImageIndex = 1;

			//tvSol.Nodes[0].Nodes[0].Nodes.Add("!Alias#0");	
			tvSol.Nodes[0].Nodes[0].Nodes.Add(MainMDI.arr_EFSdict[38, MainMDI.Lang] + "#1"); //to use system | systéme instead of alias

			tvSol.Nodes[0].Nodes[0].Nodes[0].SelectedImageIndex = 0;
			tvSol.Nodes[0].Nodes[0].Nodes[0].ImageIndex = 0;
		}

		private void grpChng_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox8_Enter_1(object sender, System.EventArgs e)
		{
		
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
			string solId = MainMDI.Find_One_Field("select  Sol_LID from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " and Sol_Name='" + lCurSoln.Text + "'");
			FichWord_Config FC = new FichWord_Config(lCurrIQID.Text, solId, cbTerms.Text, lHiDelv.Text, lcurDol.Text, "");
			FC.ShowDialog();
			this.Refresh();
			if (FC.NXT)
			{
				pbPrintQt.Value = 0;
				grpPB.Visible = true;
				grpPB.Refresh();
				FichWord_aNEW FW = new FichWord_aNEW(this, FC);
				FW.Wexport();
			}
			/*
			if (MainMDI.Lang == 0)
			{
				MainMDI.Lang++;
				button4.Text = "Francais";
			}
			else
			{
				MainMDI.Lang--;
				button4.Text = "English";
			}
			//FichWord kiki = new FichWord(this);
			*/
		}

		private void lSA_Click(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox5_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void textBox5_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void label51_Click(object sender, System.EventArgs e)
		{
		
		}

		private void Quote_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			if (in_opera != 'C') e.Cancel = true;
			//MessageBox.Show("cancel= " + e.Cancel);
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			if (tQuoteID.Text != "") MainMDI.flag_QRID('Q', 'u', 0, Convert.ToUInt32(tQuoteID.Text));
			this.Hide();
		}

		private void toolBar1_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//MessageBox.Show(e.Button.ToString());
			toolBar1.Buttons[18].ImageIndex = 27;
		}

		private void toolBar1_MouseLeave(object sender, System.EventArgs e)
		{
			toolBar1.Buttons[18].ImageIndex = 28;
		}

		private void btnImpChrgPrices_Click_2(object sender, System.EventArgs e)
		{
		
		}

		private void button5_Click_1(object sender, System.EventArgs e)
		{
            button5.Visible = false;
		    button6.Visible = false;
		    grpPB.Visible = false;
		}

		private void button6_Click(object sender, System.EventArgs e)
		{
			button5_Click_1(sender, e);
		    MainMDI.OpenKnownFile(lOFName.Text);
		}

		private void groupBox1_Enter_1(object sender, System.EventArgs e)
		{
		
		}

		private void lPhone_Click(object sender, System.EventArgs e)
		{
		
		}

		private void cbAI_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lAI.Text = MainMDI.Find_One_Field("select SA_ID from PSM_SALES_AGENTS where (First_Name + ' ' + Last_Name) ='" + cbAI.Text + "' AND SA='A'");
			if (lAI.Text == MainMDI.VIDE) lAI.Text = "0";
		}

		private void cbAE_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lAE.Text = MainMDI.Find_One_Field("select SA_ID from PSM_SALES_AGENTS where (First_Name + ' ' + Last_Name) ='" + cbAE.Text + "' AND SA='A'");
			if (lAE.Text == MainMDI.VIDE) lAE.Text = "0";
		}

		private void cbAP_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lAP.Text = MainMDI.Find_One_Field("select SA_ID from PSM_SALES_AGENTS where (First_Name + ' ' + Last_Name) ='" + cbAP.Text + "' AND SA='A'");
			if (lAP.Text == MainMDI.VIDE) lAP.Text = "0";
		}

		private void cbADD_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lAD.Text = MainMDI.Find_One_Field("select SA_ID from PSM_SALES_AGENTS where (First_Name + ' ' + Last_Name) ='" + cbADD.Text + "' AND SA='A'");
			if (lAD.Text == MainMDI.VIDE) lAD.Text = "0";
		}

		private void tvSol_DoubleClick(object sender, System.EventArgs e)
		{
			//tvSol.SelectedNode.BackColor = Color.YellowGreen;
		}

		private void tvSol_BeforeCheck(object sender, System.Windows.Forms.TreeViewCancelEventArgs e)
		{
		    //MessageBox.Show("el= " + e.Node.Text + "  et= " + e.Node.Checked);
			Chkable = true;
			if (e.Node.Checked && !btnUnchk) { e.Cancel = true; Chkable = false; }
		}

        private void fill_cbTerrito()
        {
            cb_Territo.Items.Clear();
            string stSql = "select Terito_ABR , Terito_LID from PSM_C_ComTERITORY order by Rnk ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                MainMDI.add_CB_itm(cb_Territo, Oreadr[0].ToString(), Oreadr[1].ToString());
            }
            //cbSerItems.BringToFront();
            cb_Territo.SelectedIndex = 0;
            OConn.Close();
        }

		private void tvSol_AfterCheck(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			//MessageBox.Show("AFTER.....el= " + e.Node.Text + "  et= " + e.Node.Checked);
			if (e.Node.Checked && Chkable)
			{
				switch (e.Node.ImageIndex)
				{
					case 2:
					case 4:
					case 5:
						//lRimgNdx.Text = e.Node.ImageIndex = e.Node.ImageIndex;
						if (curR_sol == "") curR_sol = e.Node.Text;
						if (e.Node.Checked && e.Node.Text == curR_sol)
						{
							add_LVR(e.Node.Text, e.Node.Index.ToString(), "", "", "", "", "", "");
							for (int i = 0; i < e.Node.Nodes.Count; i++)
								e.Node.Nodes[i].Checked = true;
						}
						else
						{						
							for (int r = lvOrder.Items.Count - 1; r > -1; r--) delLvOrderALL(r);
							btnUnchk = true; e.Node.Checked = false; btnUnchk = false;
                            curR_sol = "";
							e.Node.Checked = true;
						}
						break;
					case 1:
						if (curR_sol == "") curR_sol = e.Node.Parent.Text;
						if (e.Node.Checked && e.Node.Parent.Text == curR_sol)
						{	
							//if (e.Node.Parent.Index.ToString() != curR_sol) for (int r = lvOrder.Items.Count - 1; r > -1; r--) delLvOrderALL(r);
							add_LVR("  " + e.Node.Text, e.Node.Parent.Index.ToString(), e.Node.Index.ToString(), "", "", "", "", "");
							for (int i = 0; i < e.Node.Nodes.Count; i++)		
								e.Node.Nodes[i].Checked = true;
						}
						else { btnUnchk = true; e.Node.Checked = false; btnUnchk = false; }
						break;
					case 0:
					case 3:
						
						if (curR_sol == "") curR_sol = e.Node.Parent.Parent.Text;
						if (e.Node.Checked && e.Node.Parent.Parent.Text == curR_sol)
						{
							//if (e.Node.Parent.Parent.Index.ToString() != curR_sol) for (int r = lvOrder.Items.Count - 1; r > -1; r--) delLvOrderALL(r);
							//string TotALS = ????
							add_LVR("    " + e.Node.Text, e.Node.Parent.Parent.Index.ToString(), e.Node.Parent.Index.ToString(), e.Node.Index.ToString(), "", "", "", "");
						}
						else { btnUnchk = true; e.Node.Checked = false; btnUnchk = false; }
						break;
				}
			}
		}

		private bool IsOrdered(string Iname, string SolN, string AlsN, string DetLID)
		{
			return true;
		}

		private void add_LVR(string DescR, string SolNm, string SpcNm, string ALSNm, string DetailID, string ndx, string r_AA, string r_ext)
		{
			ListViewItem lvI = lvOrder.Items.Add(DescR);
			lvI.SubItems.Add(SolNm);
			curR_sol = tvSol.Nodes[Convert.ToInt32(SolNm)].Text;
			lRimgNdx.Text = tvSol.Nodes[Convert.ToInt32(SolNm)].ImageIndex.ToString();
			lRSoln.Text = tvSol.Nodes[Convert.ToInt32(SolNm)].Text;
			lvI.SubItems.Add(SpcNm);
			lvI.SubItems.Add(ALSNm);
			lvI.SubItems.Add(DetailID);
			lvI.SubItems.Add(ndx);
			lvI.SubItems.Add(r_AA);
			lvI.SubItems.Add(r_ext);
		}

		private void add_LVROLD(string DescR, string SolNm, string SpcNm, string ALSNm, string DetailID, string ndx)
		{
			ListViewItem lvI = lvOrder.Items.Add(DescR);
			lvI.SubItems.Add(SolNm);
			lvI.SubItems.Add(SpcNm);
			lvI.SubItems.Add(ALSNm);
			lvI.SubItems.Add(DetailID);
			lvI.SubItems.Add(ndx);
		}

		private void gbxSol_Enter_1(object sender, System.EventArgs e)
		{
		
		}

		private void cbIPmgr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string[] arr_Val = new string[6]{ "", "", "", "", "", "" };
			string stSql = "select SA_ID ,Extension,sfx from PSM_SALES_AGENTS where (First_Name + ' ' + Last_Name) ='" + cbIPmgr.Text + "'";
			lIpmgr.Text = MainMDI.Find_One_Field(stSql);
			if (lIpmgr.Text == MainMDI.VIDE) lIpmgr.Text = "0";
		}

		private void cbCPmgr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//string[] arr_Val = new string[6]{ "", "", "", "", "", "" };
			string stSql = "SELECT PSM_Contacts.Contact_ID, PSM_Prefix.Prefix, PSM_Contacts.[First_Name], PSM_Contacts.Last_Name, PSM_Contacts.JOBTitle, Extension " +
				" FROM PSM_Contacts INNER JOIN PSM_Prefix ON PSM_Contacts.Prefix_ID = PSM_Prefix.[Prefix ID]  WHERE ([PSM_Contacts].[First_Name] + ' ' + [PSM_Contacts].[Last_Name])='" + cbCPmgr.Text.Replace("'", "''") + "' ";
			lCpmgr.Text = MainMDI.Find_One_Field(stSql);
			if (lCpmgr.Text == MainMDI.VIDE) lCpmgr.Text = "0";
		}

		private void lvOrder_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnInsert_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			for (int r = lvOrder.SelectedItems.Count - 1; r > -1; r--) delLvOrderALL(lvOrder.SelectedItems[r].Index);
		}

		private void delLvOrder(int Rndx)
		{
			btnUnchk = true;
			if (lvOrder.SelectedItems.Count > 0)
			{
				if (lvOrder.SelectedItems[Rndx].SubItems[5].Text != "")
				{
					int ndx = Convert.ToInt32(lvOrder.SelectedItems[Rndx].SubItems[5].Text);
					lvQITEMS.Items[ndx].Checked = false;
					lvOrder.Items[lvOrder.SelectedItems[Rndx].Index].Remove();
				}
				else
				{
					int AI = (lvOrder.SelectedItems[Rndx].SubItems[3].Text != "") ? Convert.ToInt32(lvOrder.SelectedItems[Rndx].SubItems[3].Text) : -1;
					int PI = (lvOrder.SelectedItems[Rndx].SubItems[2].Text != "") ? Convert.ToInt32(lvOrder.SelectedItems[Rndx].SubItems[2].Text) : -1;
					int SI = (lvOrder.SelectedItems[Rndx].SubItems[1].Text != "") ? Convert.ToInt32(lvOrder.SelectedItems[Rndx].SubItems[1].Text) : -1;
					if (AI != -1) tvSol.Nodes[SI].Nodes[PI].Nodes[AI].Checked = false;
					else 
					{
						if (PI != -1) tvSol.Nodes[SI].Nodes[PI].Checked = false;
						else if (SI != -1) tvSol.Nodes[SI].Checked = false;
					}
				}
				lvOrder.SelectedItems[Rndx].Remove();
			}
			btnUnchk = false;	
		}

		private void delLvOrderALL(int Rndx)
		{
			btnUnchk = true;
			if (lvOrder.Items.Count > 0)
			{
				if (lvOrder.Items[Rndx].SubItems[5].Text != "")
				{
					int ndx = Convert.ToInt32(lvOrder.Items[Rndx].SubItems[5].Text);
					lvQITEMS.Items[ndx].Checked = false;
					//lvOrder.Items[lvOrder.Items[Rndx].Index].Remove();
				    //lvOrder.Items[Rndx].Remove();
				}
				else
				{
					int AI = (lvOrder.Items[Rndx].SubItems[3].Text != "") ? Convert.ToInt32(lvOrder.Items[Rndx].SubItems[3].Text) : -1;
					int PI = (lvOrder.Items[Rndx].SubItems[2].Text != "") ? Convert.ToInt32(lvOrder.Items[Rndx].SubItems[2].Text) : -1;
					int SI = (lvOrder.Items[Rndx].SubItems[1].Text != "") ? Convert.ToInt32(lvOrder.Items[Rndx].SubItems[1].Text) : -1;
					if (AI != -1) tvSol.Nodes[SI].Nodes[PI].Nodes[AI].Checked = false;
					else 
					{
						if (PI != -1) tvSol.Nodes[SI].Nodes[PI].Checked = false;
						else if (SI != -1) tvSol.Nodes[SI].Checked = false;
					}
					lvOrder.Items[Rndx].Remove();
				}
				//lvOrder.Items[Rndx].Remove();
			}
			btnUnchk = false;	
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnsSaveOrd_Click(object sender, System.EventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
			string stSql = MainMDI.Find_One_Field("select Sol_LID from PSM_Q_SOL where I_Quoteid=" + lCurrIQID.Text + " AND Sol_Name='" + lRSoln.Text + "'");
			isDellAll = true;
			if (stSql != MainMDI.VIDE)
			{
				//MainMDI.ExecSql("delete * from pgm_Det_OL");
				MainMDI.ExecSql("delete " + MainMDI.t_Det_OL);
				MainMDI.ExecSql("INSERT INTO " + MainMDI.t_Det_OL + " ([detailLID],[AA_orig],[rank],[Det_Qty],[Als_Qty],[brkdwn]) VALUES ('" + 
					lRimgNdx.Text + "~" + lCurrIQID.Text + "~" + stSql + "', '','0','0','0','0')"); //Header 
				for (int r = 0; r < lvOrder.Items.Count; r++)
				{
					if (Tools.Conv_Dbl(lvOrder.Items[r].SubItems[4].Text) != 0)
                        Nsrt_Det_OL(lvOrder.Items[r].SubItems[7].Text, lvOrder.Items[r].SubItems[6].Text, lvOrder.Items[r].SubItems[4].Text, lvOrder.Items[r].SubItems[5].Text);
						//MainMDI.ExecSql("INSERT INTO pgm_Det_OL ([detailLID]) VALUES (" + lvOrder.Items[r].SubItems[4].Text + "')");
					else if (lvOrder.Items[r].SubItems[3].Text != "") save_DetLID(lCurrIQID.Text, lvOrder.Items[r].SubItems[1].Text, lvOrder.Items[r].SubItems[2].Text, lvOrder.Items[r].SubItems[3].Text, r);
				}
				Order child_Ord = new Order("*", "*");
				this.Hide();
				child_Ord.ShowDialog();
				string Conv_RRevID = child_Ord.lOKConv.Text;
				string NewProjID = child_Ord.LRID.Text;
				if (Conv_RRevID != "") BCONV = child_Ord.BCOnv;
				this.Visible = true;
				for (int r = lvOrder.Items.Count - 1; r > -1; r--) delLvOrderALL(r);
				if (lvOrder.Items.Count > 0) lvOrder.Items.Clear();
				isDellAll = false;
				//child_Ord.Dispose();
			}
			else MessageBox.Show("This Quote Revision is not Saved Yet  !!!");
			this.Cursor = Cursors.Default;
			if (BCONV) this.Hide();
		}

		private void save_DetLID(string iQID, string solN, string SpcN, string AlsN, int r)
		{
			int AI = (AlsN != "") ? Convert.ToInt32(AlsN) : -1;
			int PI = (SpcN != "") ? Convert.ToInt32(SpcN) : -1;
			int SI = (solN != "") ? Convert.ToInt32(solN) : -1;

			string stSql = " SELECT PSM_Q_Details.* ,PSM_Q_SPCS.SPC_Name + '/' + PSM_Q_ALS.ALS_Name AS AA_orig " +
                " FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " WHERE ((PSM_Q_IGen.i_Quoteid)=" + iQID + ") AND ((PSM_Q_SOL.Sol_Name)='" + tvSol.Nodes[SI].Text + "')"; //+ "') AND ((PSM_Q_SPCS.SPC_Name)='" + SpcNm + "') AND ((PSM_Q_ALS.ALS_Name)='" + AlsNm + "')) ";
            if (AI != -1) stSql += " AND ((PSM_Q_SPCS.SPC_Name)='" + tvSol.Nodes[SI].Nodes[PI].Text.Replace("'", "''") + "') AND ((PSM_Q_ALS.ALS_Name)='" + tvSol.Nodes[SI].Nodes[PI].Nodes[AI].Text.Replace("'", "''") + "') ";
			if (PI != -1) stSql += " AND ((PSM_Q_SPCS.SPC_Name)='" + tvSol.Nodes[SI].Nodes[PI].Text.Replace("'", "''") + "')";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				if (!(Tools.Conv_Dbl(Oreadr["Ext"].ToString()) == 0 && Oreadr["Aff_ID"].ToString() == ".")) Nsrt_Det_OL(Oreadr["Ext"].ToString(), Oreadr["AA_orig"].ToString(), Oreadr["Detail_LID"].ToString(), r.ToString());
			}
		}
		private void Nsrt_Det_OL(string ext, string r_AA, string r_det_LID, string r)
		{
			string AA = (ext == "") ? "" : r_AA;
			MainMDI.ExecSql("INSERT INTO " + MainMDI.t_Det_OL + " ([detailLID],[AA_orig],[rank]) VALUES (" + r_det_LID + ", '" + AA + "', " + r + ")");
		}

		private void cbCurr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
		
		}

		private bool maj_LT()
		{
			if (minLT.Text.Length == 1) minLT.Text = "0" + minLT.Text;
			if (MaxLT.Text.Length == 1) MaxLT.Text = "0" + MaxLT.Text;
			if (tExt.Text != "" && tExt.Text != " ")
			{
				int mLT = (minLT.Text == "") ? 0 : Convert.ToInt32(minLT.Text);
				int xLT = (MaxLT.Text == "") ? 0 : Convert.ToInt32(MaxLT.Text);
				if (mLT< xLT) tLT.Text = MainMDI.A00(mLT, 2) + "-" + MainMDI.A00(xLT, 2);
				else
				{
					MessageBox.Show("Min LeadTime must < MAX LeadTime !!!");
					return false;
				}
			}
			else tXchng.Text = "1";
			return true;
		}

		private void MaxLT_TextChanged(object sender, System.EventArgs e)
		{
		    //maj_LT();
		}

		private void minLT_TextChanged(object sender, System.EventArgs e)
		{
			//maj_LT();
		}

		private void MaxLT_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyInt(e.KeyChar);
		}

		private void minLT_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyInt(e.KeyChar);
		}

		private void Lang_Click(object sender, System.EventArgs e)
		{
		
		}

		//Main functions....

		public static long oldGen_ID(char tNm)
		{
			long ResID = 0;
			 string tblNm = "PSM_" + tNm + "_GenID";
		    //string Res = MainMDI.Find_One_Field("select " + tNm + "ID from " + tblNm + " where not flaged and not InUse ORDER BY PSM_Q_GenID.QID");
			string Res = MainMDI.Find_One_Field("select " + tNm + "ID from " + tblNm + " where not flaged and not InUse order by  " + tNm + "ID ");
			if (Res == MainMDI.VIDE)
			{
				string lastID = MainMDI.Find_One_Field(" select " + tNm + "ID from " + tblNm + " order by  " + tNm + "ID DESC");
				if (lastID != MainMDI.VIDE)
				{
					if (New100_QRID(tNm, lastID)) ResID = Convert.ToInt32(lastID);
					else ResID = 0; //means PSM_Q_GenID is Full or cannot Write In.
				}
				else ResID = -1; //means PSM_Q_GenID is Empty & must be Init.
			}
			else ResID = Convert.ToInt32(Res);
			return ResID;
		}

		public static bool lock_table(char tNm)
		{
			bool Res = true;
			string tableNM = "PSM_" + tNm + "_GenID";
			while (true)
			{
				string st = MainMDI.Find_One_Field(" select TableName from PSM_LOCKED_TABLES where TableName='" + tableNM + "'");
				if (st == MainMDI.VIDE)	
				{
					Res = MainMDI.ExecSql(" INSERT INTO PSM_LOCKED_TABLES ([TableName]) VALUES ('" + tableNM + "')");
					break;
				}
				else 
				{
					DialogResult dr = MessageBox.Show("Can not Generate New ID  Table is Locked by another User, please try later or contact your Admin...", "Generating New ID", MessageBoxButtons.RetryCancel, MessageBoxIcon.Question);
					if (dr == DialogResult.Cancel)
					{
						Res = false;
						break;
					}
				}
			}
			return Res;
		}

		public static bool New100_QRID(char c, string IdFrom)
		{
			long debId = Convert.ToInt32(IdFrom);
			try
			{
				string tblNm = "PSM_" + c + "_GenID";
				string s_LastId = MainMDI.Find_One_Field("select " + c + "ID from " + tblNm + " ORDER BY " + c + "ID DESC");
				if (s_LastId == MainMDI.VIDE) s_LastId = "0";
				long LastID = Convert.ToInt32(s_LastId);
				if (LastID < debId) for (long i = LastID; i < debId - 1; i++) MainMDI.ExecSql("INSERT INTO " + tblNm + " ([flaged],[inuse]) VALUES (TRUE,FALSE)");
				for (long i = 0; i < 100; i++) MainMDI.ExecSql("INSERT INTO " + tblNm + " ([flaged],[inuse]) VALUES (FALSE,FALSE)");
				return true;
			}
			catch (OleDbException Oexp)
			{
				MainMDI.stXP = Oexp.Message;
				return false;
			}
		}

		public static bool New100_QRIDOLD(char c, string st)
		{
			long debQid = Convert.ToInt32(st);
			try
			{
				string tblNm = (c == 'Q') ? "PSM_Q_GenID" : "PSM_R_GenID";
				SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
				OConn.Open();
				SqlCommand Ocmd = OConn.CreateCommand();
				long limt = (debQid <= MainMDI.MAX_QID - 99) ? debQid + 100 : (MainMDI.MAX_QID + 1);
				for (long i = debQid; i < limt; i++)
				{
					Ocmd.CommandText = "INSERT INTO" + tblNm + " ([" + c + "ID],[flaged]) VALUES ('" + i.ToString() + "',FALSE)";
					Ocmd.ExecuteNonQuery();
				}
				OConn.Close();
				return true;
			}
			catch (OleDbException Oexp)
			{
				MainMDI.stXP = Oexp.Message;
				return false;
			}
		}

		public static bool Unlock_table(string tableNM)
		{
			return MainMDI.ExecSql("delete PSM_LOCKED_TABLES where TableName='" + tableNM + "'");
		}

	    /*
		public static string Find_One_Field(string stSql)
		{
			//string stSql = "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
			SqlConnection OConn = null;
			SqlCommand Ocmd = null;
			SqlDataReader Oreadr = null;

			//tst
			stSql.Replace("'", "''");
			//tst

			try
			{
				OConn = new SqlConnection(MainMDI._connectionString);
				OConn.Open();
				Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql;
				Oreadr = Ocmd.ExecuteReader();
				while (Oreadr.Read()) return Oreadr[0].ToString();
				return MainMDI.VIDE;
			}
			catch(Exception ex)
			{
				MessageBox.Show("FOF-ERROR= " + ex.Message);
				return MainMDI.VIDE;
			}
			finally
			{
				OConn.Close();
				Oreadr.Close();
			}
		}

		public static bool Confirm(string msg)
		{
			DialogResult dr = MessageBox.Show(msg, "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			return (dr == DialogResult.Yes);
		}
		
		public static string Find_arr_Fields(string stSql, string[] vals)
		{
			//string stSql = "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
			//tst
			stSql.Replace("'", "''");
			//tst

			SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				for (int i = 0; i < Oreadr.FieldCount; i++) vals[i] = Oreadr[i].ToString();
				return Oreadr[0].ToString();
			}
			OConn.Close();
			return MainMDI.VIDE;
		}

		public static string A00(string st)
		{
			if (st == "0") return ".00";
			double dd = Tools.Conv_Dbl(st);
			if (dd != 0)
			{
				int ipos = st.IndexOf(".", 0);
				if (ipos == -1 ) st = st + ".00";
				else
				{
					string st1 = st.Substring(0, ipos);
					string st2 = st.Substring(ipos, st.Length - ipos);
					for (int j = st2.Length; j < 3; j++) st2 += "0";
					return st1 + st2;
				}
			}
			return st;
		}

		public static string A00(int ii, int Lnt)
		{
			//if (st == "0") return "00";
			string st = ii.ToString();
			for (int j = st.Length; j < Lnt; j++)
				st = "0" + st;
			return st;
		}

		public static bool flag_QRID(char tNm, char c, bool etat, long ID)
		{
			//flag flaged ==> flag('f', true, xxx)
			//Unflag flaged ==> flag('f', false, xxx)
			//flag InUse ==> flag('u', true, xxx)
			//uflag InUse ==> flag('u', false, xxx)
			string stflag = (c == 'f') ? "[flaged]=" + etat.ToString() : "[InUse]=" + etat.ToString();
			string stSql = "UPDATE " + "PSM_" + tNm + "_GenID" + " SET " + stflag + " WHERE " + tNm + "ID=" + ID.ToString();
			return MainMDI.ExecSql(stSql);
		}

		public static bool flag_QRIDOLD(char tNm, char c, bool etat, long ID)
		{
			//flag flaged ==> flag('f', true, xxx)
			//Unflag flaged ==> flag('f', false, xxx)
			//flag InUse ==> flag('u', true, xxx)
			//uflag InUse ==> flag('u', false, xxx)
			string tblNm = (tNm == 'Q') ? "PSM_Q_GenID" : "PSM_R_GenID";
			string stflag = (c == 'f') ? "[flaged]=" + etat.ToString() : "[InUse]=" + etat.ToString();
			string stSql = "UPDATE " + tblNm + " SET " + stflag + " WHERE " + tNm + "ID=" + ID.ToString();
			return MainMDI.ExecSql(stSql);
		}

		public static bool ExecSql(string stSql)
		{
			//tst
			//stSql.Replace("'", "''");
			//tst
			try
			{
				SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
				OConn.Open();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql;
				Ocmd.ExecuteNonQuery();
				OConn.Close();
				MainMDI.stXP = MainMDI.VIDE;
				return true;
			}
			catch (OleDbException Oexp)
			{
				MainMDI.stXP = Oexp.Message;
				MessageBox.Show("STSQL= " + stSql + "\n" + "Msg= " + MainMDI.stXP);
				return false;
			}
		}
        */

		private void lQstatus_TextChanged(object sender, System.EventArgs e)
		{
			if (lQstatus.Text == "C")
			{
				lCancel.Text = "Cancelled";
				lCancel.Visible = true;
				tabControl1.Enabled = false;
			}
			else 
			{
				lCancel.Text = "Normal";
				lCancel.Visible = false;
				tabControl1.Enabled = true;
			}
		}

		private void pictureBox3_Click(object sender, System.EventArgs e)
		{
			Ges_Cont_Sal_Ag gCSA = new Ges_Cont_Sal_Ag('C');
			gCSA.ShowDialog();
		}

		private void opUS_CheckedChanged(object sender, System.EventArgs e)
		{
			lcurDol.Text = "CAD";
            Curr_SQLMLTP = " CAN_MLTP ";
		}

		private void groupBox9_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void opUS_CheckedChanged_1(object sender, System.EventArgs e)
		{
			lcurDol.Text = "USD";
            Curr_SQLMLTP = " US_MLTP ";
		}

		private void opEuro_CheckedChanged(object sender, System.EventArgs e)
		{
			lcurDol.Text = "EUR";
            Curr_SQLMLTP = " EURO_MLTP ";
		}

		private void lCancel_Click(object sender, System.EventArgs e)
		{
		
		}

		private void picSeek_Click(object sender, System.EventArgs e)
		{
			bool FOUND = false;
			if (ndxfound > cbCompany.Items.Count) ndxfound = 0;
			for (int i = ndxfound; i < cbCompany.Items.Count; i++)
			{
				//if (cbCompany.Items[i].ToString().ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1)
			    //int ln = (tKey.Text.Length < cbCompany.Items[i].ToString().Length) ? tKey.Text.Length : cbCompany.Items[i].ToString().Length;
			    //if (cbCompany.Items[i].ToString().Substring(0, ln).ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1)
			    //
				if (cbCompany.Items[i].ToString().ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1)
				{
					cbCompany.SelectedIndex = i;
					ndxfound = i + 1;
					i = cbCompany.Items.Count;
					cbCompany_SelectedIndexChanged(sender, e); //cbOptGrp_SelectedValueChanged(sender, e);
					//if (ndxfound < cbOptGrp.Items.Count) button1.Text = "Next";
					FOUND = true;
				}
			}
			if (!FOUND)
			{
				ndxfound = 0;
				button1.Text = "Search";
				MessageBox.Show("KeyWord not Found !!!!");
			}
		}

		private void picSeek_Clickoldd(object sender, System.EventArgs e)
		{
			bool FOUND = false;
			if (ndxfound > cbCompany.Items.Count) ndxfound = 0;
			for (int i = ndxfound; i < cbCompany.Items.Count; i++)
			{
				//if (cbCompany.Items[i].ToString().ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1)
				int ln = (tKey.Text.Length < cbCompany.Items[i].ToString().Length) ? tKey.Text.Length : cbCompany.Items[i].ToString().Length;
				if (cbCompany.Items[i].ToString().Substring(0, ln).ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1)
				{
					cbCompany.SelectedIndex = i;
					ndxfound = i + 1;
					i = cbCompany.Items.Count;
					cbCompany_SelectedIndexChanged(sender, e); //cbOptGrp_SelectedValueChanged(sender, e);
					//if (ndxfound < cbOptGrp.Items.Count) button1.Text = "Next";
					FOUND = true;
				}
			}
			if (!FOUND)
			{
				ndxfound = 0;
				button1.Text = "Search";
				MessageBox.Show("KeyWord not Found !!!!");
			}
		}

		private void CHSPrt()
		{
			PrintDocument prtdoc = new PrintDocument();
			string strDefaultPrinter = prtdoc.PrinterSettings.PrinterName;
			foreach(String strPrinter in PrinterSettings.InstalledPrinters)
			{
				cbprinters.Items.Add(strPrinter);
				if (strPrinter == strDefaultPrinter)
				{
					cbprinters.SelectedIndex = cbprinters.Items.IndexOf(strPrinter);
				}
			}
		}

		private void printLabel_Click(object sender, System.EventArgs e)
		{
			if (lCpnyName.Text != "" && tQuoteID.Text != "")
			{
				this.Cursor = Cursors.WaitCursor;
				 
				//printDialog1.ShowDialog();
				string prtNmeOLD = printDialog1.PrinterSettings.PrinterName;
				string prtNme = MainMDI.DYMOName;
				Print_label ll = new Print_label('L', tQuoteID.Text, lCpnyName.Text, "", prtNme, null, null);
				ll.Wexport();
				this.Cursor = Cursors.Default;
			}
		}

		private void btnchngCN_Click(object sender, System.EventArgs e)
		{
			cbContacts.Visible = true;
			lContacts.Visible = false;
			btnchngCN.Visible = false;
			btnchngCN.Visible = false;
		}

		private void btnchngCP_Click(object sender, System.EventArgs e)
		{
			cbCPmgr.Visible = true;
			lcbCPmgr.Visible = false;
			btnchngCP.Visible = false;
			btnchngCP.Visible = false;
		}

		private void btnCHNGCmpny_Click(object sender, System.EventArgs e)
		{
			cbCompany.Visible = true;
			lCpnyName.Visible = false;
			btnCHNGCmpny.Visible = false;
			picSeek.Visible = true;
			tKey.Visible = true;
		}

		private void lCpnyName_Click(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox4_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void tKey_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			cbprinters.Visible = true;
		}

		private void cbprinters_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			linkLabel1.Text = cbprinters.Text;
		}

		private void MNoCut_Click(object sender, System.EventArgs e)
		{
			//vider_arr_clpB(); //MainMDI.arr_clpB[i, j] = "~";
			CutCopy('D');
		}

		private void CutCopy(char c)
		{
			vider_arr_clpB();
			int i = -1;
			for (i = 0; i < lvQITEMS.SelectedItems.Count; i++)
			{
                for (int j = 0; j < lvQITEMS.Items[i].SubItems.Count; j++)
                {
                    MainMDI.arr_clpB[i, j] = lvQITEMS.SelectedItems[i].SubItems[j].Text;

                    if (c == 'T') //c == 'D' for cut must copy tech values
                    {
                        if (j == 12) MainMDI.arr_clpB[i, j] = "";
                        arr_Tech_values[lvQITEMS.SelectedItems[i].Index] = "";
                    }
                }
			}
			LstNdx = i;
			if (c == 'D') while (lvQITEMS.SelectedItems.Count > 0) lvQITEMS.Items[lvQITEMS.SelectedItems[0].Index].Remove();
		    //aff();
			MNoPaste.Enabled = true;
			menuItem9.Enabled = true;
			//+ 240806
			Ref_ALSTOT('C');
		}

        private void CutCopyOKOLD(char c)
        {
            MNoPaste.Enabled = true;

            vider_arr_clpB();
            int i = -1;
            for (i = 0; i < lvQITEMS.SelectedItems.Count; i++)
            {
                //for (int j = 0; j < lvQITEMS.Columns.Count; j++)
                for (int j = 0; j < lvQITEMS.Items[i].SubItems.Count; j++)
                    MainMDI.arr_clpB[i, j] = lvQITEMS.SelectedItems[i].SubItems[j].Text;
                //arr_clpB[i, j] = arr_Tech_values[lvQITEMS.SelectedItems[i].Index];
                if (c == 'D' || c == 'T') arr_Tech_values[lvQITEMS.SelectedItems[i].Index] = "";
            }
            LstNdx = i;
            if (c == 'D') while (lvQITEMS.SelectedItems.Count > 0) lvQITEMS.Items[lvQITEMS.SelectedItems[0].Index].Remove();
            //aff();
            MNoPaste.Enabled = true;
            menuItem9.Enabled = true;
            //+ 240806
            Ref_ALSTOT('C');
        }

		private void MNoPaste_Click(object sender, System.EventArgs e)
		{
            if (lvQITEMS.SelectedItems.Count > 0) paste(lvQITEMS.SelectedItems[0].Index);	
		    else paste(0);
		}

		private void menuItem9_Click(object sender, System.EventArgs e)
		{
			if (lvQITEMS.SelectedItems.Count > 0) paste(lvQITEMS.SelectedItems[0].Index + 1);	
			else paste(0);
		}

		private void paste(int InsertNdx)
		{
		    int K = (LstNdx == -1) ? -1 : LstNdx - 1;
			for (int i = InsertNdx; i < lvQITEMS.Items.Count; i++)
			{
				K++;
				for (int j = 0; j < lvQITEMS.Items[i].SubItems.Count; j++)
					MainMDI.arr_clpB[K, j] = lvQITEMS.Items[i].SubItems[j].Text;
				//LstNdx++;
			}
		    //aff();
			while (lvQITEMS.Items.Count > InsertNdx) lvQITEMS.Items[lvQITEMS.Items.Count - 1].Remove();
			for (int i = 0; i < MainMDI.MAX_Quote_lines; i++)
			{
				if (MainMDI.arr_clpB[i, 0] == "~") i = MainMDI.MAX_Quote_lines;
				else 
				{
					ListViewItem lv = lvQITEMS.Items.Add(MainMDI.arr_clpB[i, 0]);
					if (MainMDI.arr_clpB[i, 1] != " ") lv.BackColor = Color.Salmon;
					int k = 1;
				    //while (k < 13 && arr_clpB[i, k] != "~")
					while (k < 13)
						lv.SubItems.Add(MainMDI.arr_clpB[i, k++]);
				}
			}
			//vider_arr_clpB(); MainMDI.arr_clpB[i, j] = "~";
			//MNoPaste.Enabled = false;
			MNoCut.Enabled = true;
			menuItem9.Enabled = false;
			Tosave = true;
			Ref_ALSTOT('C');
		}

		private void vider_arr_clpB()
		{
			for (int i = 0; i < MainMDI.MAX_Quote_lines; i++)
				for (int j = 0; j < 12; j++)
					MainMDI.arr_clpB[i, j] = "~";
			LstNdx = 0;
		}

		private void aff()
		{
			string st = "";
			for (int i = 0; i < 10; i++)
			{
				st += "\n";
				for (int k = 0; k < 12; k++) st += "/" + MainMDI.arr_clpB[i, k++];
			}
			MessageBox.Show("arr=   " + st);
		}

		private void CMlvQitem_Popup(object sender, System.EventArgs e)
		{
		
		}

		private void mnOcopy_Click(object sender, System.EventArgs e)
		{
		    //vider_arr_clpB(); //MainMDI.arr_clpB[i, j] = "~";
		    CutCopy('C');
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			if (lCurrIQID.Text != "0" && tQuoteID.Text != "" && lcurSol_Status.Text != "C" && MainMDI.profile != 'R')
			{
				Add_Charger();
				Tosave = true;
			}
		}

        private void menuItem13_Click(object sender, EventArgs e)
        {
            if (MainMDI.User.ToLower() == "ede")
            {
                if (lCurrIQID.Text != "0" && tQuoteID.Text != "" && lcurSol_Status.Text != "C" && MainMDI.profile != 'R')
                {
                    Add_P5500();
                    Tosave = true;
                }
            }
        }

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			if (lCurrIQID.Text != "0" && tQuoteID.Text != "" && lcurSol_Status.Text != "C" && MainMDI.profile != 'R')
			{
				Add_Rectif();
				Tosave = true;
			}
		}

		private void tOpendate_ValueChanged(object sender, System.EventArgs e)
		{
			lQDopen.Text = tOpendate.Value.ToShortDateString();
		}

		private void btnIn_Click(object sender, System.EventArgs e)
		{
			btnNewID.Visible = false;
			tQuoteID.ReadOnly = false;
		}

		private void tALSnb_TextChanged(object sender, System.EventArgs e)
		{
			tPxPrice.Text = RndCAL(AlsTOT.Text, '*', tALSnb.Text);

			//AlsBigTOT.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tALSnb.Text) * Tools.Conv_Dbl(AlsTOT.Text), MainMDI.Q_NB_DEC_AFF));
	     	//AlsBigTOT.Text = RndCAL(AlsTOT.Text, tALSnb.Text);
			//AlsTOT.Text = RndCAL(AlsTOT_orig.Text, tALSnb.Text);
		    //string dd = RndCAL(AlsTOT.Text, tALSnb.Text);
		    //if (Tools.Conv_Dbl(tPxPrice.Text) < Tools.Conv_Dbl(dd))
		}

		private string RndCAL(string st, char op, string st2)
		{
			string res = "0.00";
			switch (op)
			{
				case '*':
					res = MainMDI.A00(Convert.ToString(Math.Round(Tools.Conv_Dbl(st) * Tools.Conv_Dbl(st2), MainMDI.Q_NB_DEC_AFF)));
					break;
				case '/':
					res = MainMDI.A00(Convert.ToString(Math.Round(Tools.Conv_Dbl(st) / Tools.Conv_Dbl(st2), MainMDI.Q_NB_DEC_AFF)));
					break;
			}
            return (res == "0.00") ? "" : res;
		}

		private void tExt_TextChanged(object sender, System.EventArgs e)
		{
			TOALS.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(lALSmAmnt.Text) + Tools.Conv_Dbl(tExt.Text), MainMDI.Q_NB_DEC_AFF));
		}

		private void tExt_DoubleClick(object sender, System.EventArgs e)
		{
			tExt.ReadOnly = false;
		}

		private void lCurALSn_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lQDopen_Click(object sender, System.EventArgs e)
		{
			tOpendate.Visible = true;
			lQDopen.Visible = false;
		}

		private void printQSum()
		{
			this.Cursor = Cursors.WaitCursor;
			if (lvQITEMS.Items.Count > 0)
			{
				//printDialog1.ShowDialog();
				//string prtNmeOLD = printDialog1.PrinterSettings.PrinterName;
				string prtNme = MainMDI.DYMOName;
				Print_label_NEW ll = new Print_label_NEW('Q', "*", "*", "*", prtNme, null, this);
				ll.Wexport();
				MainMDI.OpenKnownFile(lOFName.Text);
			}
			 this.Cursor = Cursors.Default;
		}
		private void printALS_Click(object sender, System.EventArgs e)
		{
			printQSum();
		}

		private void tNB_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyInt(e.KeyChar);
		}

		private void picExit_Click(object sender, System.EventArgs e)
		{
			bool fin = true;
			if (in_opera != 'V' && MainMDI.ALWD_USR("QT_SV", false))
			{
				SAVE_CHANGE_ALS();
				if (lCurrIQID.Text != "" && tQuoteID.Text != "")
				{
					if (tQuoteID.Text != "") MainMDI.flag_QRID('Q', 'u', 0, Convert.ToUInt32(tQuoteID.Text));
					else fin = MainMDI.Confirm("This Quote is not Saved yet ... Quit anyway ? ");
				}
			}
			if (fin) this.Hide();
		}

		private void pictureBox9_Click(object sender, System.EventArgs e)
		{
			if (cbCQA.Text != "")
			{
				cbCPA.Text = cbCQA.Text;
				cbCSA.Text = cbCQA.Text;
				cbCIA.Text = cbCQA.Text;
			}
		}

		private void tGCmnt_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tPxPrice_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{

		}

		private void tAGprice_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = (Tools.OnlyDBL(e.KeyChar) || e.KeyChar == 45);
		}

		private void button8_Click(object sender, System.EventArgs e)
		{
			//MessageBox.Show(tGCmnt.Text + " Double=" + IsDoubleNumber(tGCmnt.Text).ToString());
			MainMDI.send_email("hedebbab@primax-e.com", "edebbab@gmail.com", "Automatic e-mail  test..", "Automatic e-mail  test..");
	        MessageBox.Show("send done");
		}

		private void mnuModif_Click(object sender, System.EventArgs e)
		{
			modif_All_Items();
		}

		private void Enable_ALL(bool stat)
		{
			lvQITEMS.Enabled = stat;
			tvSol.Enabled = stat;
			groupBox5.Enabled = stat;
		}

		private void btnAsave_Click(object sender, System.EventArgs e)
		{
			string r_Xchng = "1";
			if (tAmult.Text != MainMDI.VIDE || tAqty.Text != MainMDI.VIDE || tAup.Text != MainMDI.VIDE)
			{
				for (int s = 0; s < lvQITEMS.SelectedItems.Count; s++)
				{
					if (Tools.Conv_Dbl(lvQITEMS.SelectedItems[s].SubItems[7].Text) > 0)
					{
						if (tAqty.Text != MainMDI.VIDE) lvQITEMS.SelectedItems[s].SubItems[3].Text = tAqty.Text;
						if (tAup.Text != MainMDI.VIDE) lvQITEMS.SelectedItems[s].SubItems[5].Text = tAup.Text;
						if (tAmult.Text != MainMDI.VIDE) lvQITEMS.SelectedItems[s].SubItems[4].Text = tAmult.Text;
						lvQITEMS.SelectedItems[s].SubItems[7].Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(lvQITEMS.SelectedItems[s].SubItems[4].Text) * Tools.Conv_Dbl(lvQITEMS.SelectedItems[s].SubItems[5].Text) * Tools.Conv_Dbl(lvQITEMS.SelectedItems[s].SubItems[3].Text) * Tools.Conv_Dbl(r_Xchng), MainMDI.Q_NB_DEC_AFF));
						Tosave = true;
					}
				}
				Ref_ALSTOT('C'); //????
			}
			Enable_ALL(true);
			grpAmodif.Visible = false;
		}

		private void btnAcancel_Click(object sender, System.EventArgs e)
		{
            Enable_ALL(true);
			grpAmodif.Visible = false;
		}

		private void AlsTOT_orig_TextChanged(object sender, System.EventArgs e)
		{
			//if (OldAlsTot.Text != AlsTOT_orig.Text && OldAlsTot.Text != "") AlsTOT.Text = AlsTOT_orig.Text;
		}

		private void AlsTOT_TextChanged(object sender, System.EventArgs e)
		{
			if (!AlsTOT.ReadOnly)
			{
				//string dd = RndCAL(AlsTOT.Text, '*', tALSnb.Text);
				//tPxPrice.Text = (OldAlsTot.Text != "") ? dd : RndCAL(tPxPrice.Text, '/', tALSnb.Text);
				tPxPrice.Text = RndCAL(AlsTOT.Text, '*', tALSnb.Text);
			}
		    //ref_PXAG_Price();
		    //OldAlsTot.Text = AlsTOT.Text;
		}

		private void AlsTOT_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = (Tools.OnlyDBL(e.KeyChar) || e.KeyChar == 45);
		}

		private void chkPrintALL_CheckedChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tvSol_Resize(object sender, System.EventArgs e)
		{
			//lvQITEMS.Width = 578 - tvSol.Width;
        }

        private void pictureBox10_Click(object sender, EventArgs e)
        {
            tAGprice.Text = tPxPrice.Text;
        }

        private void picbadRevSta_Click(object sender, EventArgs e)
        {
            tAGprice.Text = tPxPrice.Text;
            picbadRevSta.Visible = false; //(tAGprice.Text != tPxPrice.Text);
        }

        private void tAGprice_TextChanged(object sender, EventArgs e)
        {
            picbadRevSta.Visible = (tAGprice.Text != tPxPrice.Text);
        }

        private void tPxPrice_TextChanged(object sender, EventArgs e)
        {
            picbadRevSta.Visible = (tAGprice.Text != tPxPrice.Text);
        }

        private void lAlterTOT_Click(object sender, EventArgs e)
        {

        }

        private void Quote_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private long XSP_NSRT_CurrentMLTP(string _Cpny_ID, string _CAN_MLTP, string _US_MLTP, string _EURO_MLTP)
        {
            string LID = "-1";
            string stXP = "";
            try
            {
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = new SqlCommand("NSRT_CpnyCurrMLTP", OConn);
                Ocmd.CommandType = CommandType.StoredProcedure;

                Ocmd.Parameters.AddWithValue("@Cpny_ID", _Cpny_ID);
                Ocmd.Parameters.AddWithValue("@CAN_MLTP", _CAN_MLTP);
                Ocmd.Parameters.AddWithValue("@US_MLTP", _US_MLTP);
                Ocmd.Parameters.AddWithValue("@EURO_MLTP", _EURO_MLTP);
                //LID = Ocmd.exe;
                SqlDataReader rdr = Ocmd.ExecuteReader();
                while (rdr.Read()) LID = rdr[0].ToString();
                OConn.Close();
                stXP = MainMDI.VIDE;
                return Int64.Parse(LID);
            }
            catch (SqlException Oexp)
            {
                stXP = Oexp.Message;
                MessageBox.Show("NSRT_CpnyCurrMLTP \n" + "Msg= " + stXP);
                return -1;
            }
        }

        private void btnSavMLTP_Click(object sender, EventArgs e)
        {
            string res = MainMDI.Find_One_Field("select mltp_LID from PSM_Cmpny_CurrMLTP where Cpny_ID=" + lcpnyID.Text);
            if (res == MainMDI.VIDE)
            {
                long _lid = _lid = XSP_NSRT_CurrentMLTP(lcpnyID.Text, STDMultp_CAN, STDMultp_US, STDMultp_EURO);
                MainMDI.Write_JFS(" New Current multiplyer for Company=" + lCpnyName.Text.Replace("'", "''"));
            }
            MainMDI.Exec_SQL_JFS("update PSM_Cmpny_CurrMLTP set [" + Curr_SQLMLTP.Trim() + "] = " + tCust_Mult.Text + " where Cpny_ID=" + lcpnyID.Text, " Change Current multiplyer for Company=" + lCpnyName.Text.Replace("'", "''"));
        }

        private void btnChangMLTP_Click(object sender, EventArgs e)
        {
            string _stUS = "", _stCAN = "", _stEURO = "";
            if (MainMDI.profile != 'R')
            {
                this.Cursor = Cursors.WaitCursor;
			    Company frmComapny = new Company(lCpnyName.Text, 'M', "");
				frmComapny.ShowDialog();
                MainMDI.Find_2_Field("SELECT multpl1, multpl1_US,multpl1_EURO FROM PSM_COMPANY inner join  PSM_CmpnyTYPE on PSM_COMPANY.CustomerType= PSM_CmpnyTYPE.CpnyType_ID where Cpny_ID=" + lcpnyID.Text, ref _stCAN, ref _stUS, ref _stEURO);
                fill_NewMLTP(_stCAN, _stUS, _stEURO);

                this.Cursor = Cursors.Default;
            }
            else MessageBox.Show("ACCESS DENIED... ", MainMDI.User, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        private void pictureBox12_Click(object sender, EventArgs e)
        {
            tCust_Mult.Text = STDMultp.Text;
        }

        private void cb_Territo_SelectedIndexChanged(object sender, EventArgs e)
        {
            System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
            itm = (System.Web.UI.WebControls.ListItem)cb_Territo.Items[cb_Territo.SelectedIndex];
            lSi.Text = itm.Value;
            txcb_Territo.Text = cb_Territo.Text;
            //lSi.Text = MainMDI.Find_One_Field("select SA_ID from PSM_SALES_AGENTS where (First_Name + ' ' + Last_Name) ='" + cbSi.Text + "' AND SA='S'");
            //if (lSi.Text == MainMDI.VIDE) lSi.Text = "0";
        }

        private void txcb_Territo_TextChanged(object sender, EventArgs e)
        {

        }

        private void txcb_Territo_DoubleClick(object sender, EventArgs e)
        {
            cb_Territo.BringToFront();
        }

        private void lOFName_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox13_Click(object sender, EventArgs e)
        {
            if (cbADD.Text != "")
            {
                cbAE.Text = cbADD.Text;
                cbAI.Text = cbADD.Text;
                cbAP.Text = cbADD.Text;
                cbAS.Text = cbADD.Text;
            }
        }

        private void CHRECmnu_Popup(object sender, EventArgs e)
        {

        }

        private void paste_emptyNL(int InsertNdx)
        {
            int K = (LstNdx == -1) ? -1 : LstNdx - 1;
            for (int i = InsertNdx; i < lvQITEMS.Items.Count; i++)
            {
                K++;
                for (int j = 0; j < lvQITEMS.Items[i].SubItems.Count; j++)
                    MainMDI.arr_clpB[K, j] = lvQITEMS.Items[i].SubItems[j].Text;
                //LstNdx++;
            }
            //aff();
            while (lvQITEMS.Items.Count > InsertNdx) lvQITEMS.Items[lvQITEMS.Items.Count - 1].Remove();
            for (int i = 0; i < MainMDI.MAX_Quote_lines; i++)
            {
                if (MainMDI.arr_clpB[i, 0] == "~") i = MainMDI.MAX_Quote_lines;
                else
                {
                    ListViewItem lv = lvQITEMS.Items.Add(MainMDI.arr_clpB[i, 0]);
                    if (MainMDI.arr_clpB[i, 1] != " ") lv.BackColor = Color.Salmon;
                    int k = 1;
                    //while (k < 13 && arr_clpB[i, k] != "~")
                    while (k < 13)
                        lv.SubItems.Add(MainMDI.arr_clpB[i, k++]);
                }
            }
            //vider_arr_clpB(); MainMDI.arr_clpB[i, j] = "~";
            //MNoPaste.Enabled = false;
            MNoCut.Enabled = true;
            menuItem9.Enabled = false;
            Tosave = true;
            Ref_ALSTOT('C');
        }

        private void menuItem16_Click(object sender, EventArgs e)
        {
            CutCopy('T');

            //if (lcurSol_Status.Text != "C")
            //{
                //if (lvQITEMS.Items.Count > 0)
                //{
                    //copyEmptyL(0);
                    //if (lvQITEMS.SelectedItems.Count > 0) paste(lvQITEMS.SelectedItems[0].Index + 1);
                    //else paste(0);
                //}
            //}
            //else MessageBox.Show("No item of this Revision can be Modified !!!");
        }

        private void copyEmptyL(int _ndx)
        {
            vider_arr_clpB();
            int i = _ndx;
                for (int j = 0; j < lvQITEMS.Items[i].SubItems.Count; j++)
                    if (j == 1 || j == 12) MainMDI.arr_clpB[i, j] = "";
                    else MainMDI.arr_clpB[i, j] = "00";
            LstNdx = i;
            //+ 240806
            //Ref_ALSTOT('C');
        }

        /*
        private void xprt_priceList(string _cptLID, string srt)
        {
            string stSql = "";
            string srtSql = find_CPT_Sort(loptID_orig.Text, srt);

            stSql = " SELECT     COMPNT_PRICE_LIST.PRICE_LINE_ID, COMPNT_PRICE_LIST.CAT1_VALUE, COMPNT_PRICE_LIST.CAT2_VALUE, COMPNT_PRICE_LIST.CAT3_VALUE, COMPNT_PRICE_LIST.PRICE, COMPNT_PRICE_LIST.CAT4_VALUE, COMPNT_PRICE_LIST.CAT5_VALUE, COMPNT_PRICE_LIST.CAT6_VALUE, " +
                "           COMPNT_PRICE_LIST.LeadTime, COMPNT_PRICE_LIST.PL_Code, COMPNT_LIST.Component_Name,COMPNT_LIST.COMPONENT_REF, COMPNT_LIST.CatName1, COMPNT_LIST.CatName2, COMPNT_LIST.CatName3        " +
                " FROM   COMPNT_PRICE_LIST INNER JOIN COMPNT_LIST ON COMPNT_PRICE_LIST.COMPONENT_ID = COMPNT_LIST.Component_ID INNER JOIN COMPNT_MANUFAC ON COMPNT_PRICE_LIST.Manufac_ID = COMPNT_MANUFAC.MANUFAC_ID INNER JOIN " +
                "        COMPNT_MANUFAC_FAMILY ON COMPNT_PRICE_LIST.compnt_man_Fam_ID = COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID " +
                " WHERE  COMPNT_PRICE_LIST.COMPONENT_ID =" + _cptLID + " ORDER BY COMPNT_PRICE_LIST.Manufac_ID, COMPNT_PRICE_LIST.compnt_man_Fam_ID ";
            if (srtSql != "") stSql += ", " + srtSql;
            if (MainMDI.Find_One_Field(stSql) != MainMDI.VIDE)
            {
                SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();

                string NewCpt = "";
                Object m_objOpt = System.Reflection.Missing.Value;
                Excel.Application m_objXL = new Excel.Application();

                Excel.Workbook m_objBook = m_objXL.Workbooks.Open(XLName, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                Excel.Sheets m_objSheets = m_objBook.Worksheets;

                Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.Add(m_objOpt, m_objOpt, m_objOpt, m_objOpt); //.get_Item(1);

                string CelFrom = "A1", CelTo = "F1", cat1NM = "", cat2NM = "", cat3NM = "";
                Idata = new string[500, 6];
                init_Idata();
                icount = 0;

                while (Oreadr.Read())
                {
                    if (cat1NM == "")
                    {
                        cat1NM = (Oreadr["CatName1"].ToString() == "T" || Oreadr["CatName1"].ToString() == MainMDI.VIDE) ? "CAT1" : Oreadr["CatName1"].ToString();
                        cat2NM = (Oreadr["CatName2"].ToString() == "T" || Oreadr["CatName2"].ToString() == MainMDI.VIDE) ? "CAT2" : Oreadr["CatName2"].ToString();
                        cat3NM = (Oreadr["CatName3"].ToString() == "T" || Oreadr["CatName3"].ToString() == MainMDI.VIDE) ? "CAT3" : Oreadr["CatName3"].ToString();

                        //NewCpt = "(" + Oreadr["COMPONENT_REF"].ToString() + ") " + MainMDI.optDesc(0, Oreadr["Component_Name"].ToString());
                        NewCpt = MainMDI.optDesc(0, Oreadr["Component_Name"].ToString());
                    }
                    string stfullD = Oreadr["CAT4_VALUE"].ToString() + ", " + Oreadr["CAT5_VALUE"].ToString() + ", " + Oreadr["CAT6_VALUE"].ToString(); //+ ", " + Oreadr["CAT7_VALUE"].ToString();
                    stfullD += (Oreadr["CAT5_VALUE"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAT5_VALUE"].ToString();
                    stfullD += (Oreadr["CAT6_VALUE"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAT6_VALUE"].ToString();
                    Idata[icount, 0] = stfullD;
                    Idata[icount, 1] = (cat1NM == "CAT1") ? " " : Oreadr["CAT1_VALUE"].ToString();
                    Idata[icount, 2] = (cat2NM == "CAT2") ? " " : Oreadr["CAT2_VALUE"].ToString();
                    Idata[icount, 3] = (cat3NM == "CAT3") ? " " : Oreadr["CAT3_VALUE"].ToString();
                    Idata[icount, 4] = Oreadr["PRICE"].ToString();
                    Idata[icount++, 5] = Oreadr["PL_Code"].ToString();

                    //write_XL(Oreadr["Component_Name"].ToString(), CelFromTo, objHdrs, Idata);
                }
                //Excel._Worksheet ws = ((Excel._Worksheet) m_objSheets.get_Item(

                Excel.Range m_objRng = m_objSheet.get_Range(CelFrom, CelTo);
                string[] objHdrs = { "Description", cat1NM, cat2NM, cat3NM, "Sell Price", "Primax Code" };
                m_objRng.Value2 = objHdrs;
                Excel.Font m_objFont = m_objRng.Font;
                m_objFont.Bold = true;
                object[,] objData = new object[500, 6];
                for (int i = 0; i < 500; i++)
                {
                    for (int j = 0; j < 6; j++) objData[i, j] = (Idata[i, 0] != "") ? Idata[i, j] : "";
                }
                m_objRng = m_objSheet.get_Range("A2", m_objOpt);
                m_objRng = m_objRng.get_Resize(500, 6);
                m_objRng.Value2 = objData;
                NewCpt = NewCpt.Replace("/", " ");
                NewCpt = (NewCpt.Length > 30) ? NewCpt.Substring(0, 30) : NewCpt;
                m_objSheet.Name = (NewCpt != "") ? NewCpt : _cptLID;

                int WSNb = m_objBook.Worksheets.Count;
                m_objSheet.Move(m_objOpt, m_objBook.Worksheets[WSNb]);
                if (m_objBook.Worksheets.Count > 2)
                {
                    Excel.Worksheet ws = (Excel.Worksheet)m_objBook.Worksheets[1];
                    if (ws.Name == "Sheet1") ws.Delete();
                    //((Excel.Worksheet)this.Application.ActiveWorkbook.Sheets[1]).Select(missing);
                    //&& m_objBook.Worksheets[1] == "Sheet1") m_objBook.Worksheets
                }
                if (debut)
                {
                    XLName = MainMDI.XL_Path + @"\PriceList.xls";
                    m_objBook.SaveAs(XLName, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                    debut = false;
                }
                else m_objBook.Save();
                m_objBook.Close(false, m_objOpt, m_objOpt);
                m_objXL.Quit();

                OConn.Close();
            }
        }
        */
	}
}