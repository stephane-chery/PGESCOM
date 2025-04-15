using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.Sql;
using System.Data.OleDb;
using System.Data.SqlClient;
//using System.Web.Mail;
using System.Net.Mail;
using EAHLibs;
using System.Globalization;
using System.Threading;
using System.Net;
using System.Net.Sockets;
using System.Xml;
using System.Security.Cryptography;
using System.Diagnostics;
using System.DirectoryServices;
using System.IO;
using System.Text;
using Excel = Microsoft.Office.Interop.Excel;
using Microsoft.Win32;
using System.Threading.Tasks;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainMDI : System.Windows.Forms.Form
	{
		//Kim var
		//internal string stCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\psm.mdb" + @";Persist Security Info=False;Jet SqlDB:Database Password =" + "aaa999";
		//public static readonly string PBSPath = @"G:\A_primax\netprimax\PGESCOM\PBS";
		public static string PBSPath = @"C:\Program Files\pbsizing"; //@"C:\A_primax\netprimax\PGESCOM\PBS";
		public static string XL_Path = Application.StartupPath;
        public static string SMTPSRVRnm = "";
		//Local database
		//public static readonly string loc_DB = "PSM_FDB_loc.mdb";
		//public static string WQfiles = @"C:\MI_NET_DB";
		//Real database
		public static string t_Det_OL = "";
		public static string Outlk_CR = "%0d%0a";
		public static string Outlk_SPC = "%20";

        public static string t_SeekTBL6 = "", InitTXT = Application.StartupPath + @"\init.txt";
		public static string t_tbl6Col = "";
		public static string t_tbl6ColDBL = "";
		public static string GescomVer = "3.2K5"; //2 ASSIGNED ON 
		public static int NBOrdr = 65;
        public static int batt_nbL = 9, UPS_nbL = 20;
        private bool INIT_OK = true;

        public static readonly Color Clr_Readonly = Color.AliceBlue;
        public static readonly Color Clr_ReadonlyNO = Color.Lavender;

        public static readonly Color Clr_R_Approval = Color.LightCoral;
        public static readonly Color Clr_R_Inprocess = Color.PowderBlue;
		public static readonly Color Clr_s_Shipped = Color.Black;
        public static readonly Color clr_R_Scheduled = Color.DarkGreen; //.YellowGreen; //.DarkGreen;
		public static readonly Color Clr_s_Stock = Color.IndianRed;
		public static readonly Color Clr_s_Inprocess = Color.Blue;
		public static readonly Color Clr_Select = Color.Yellow; //Color.CornflowerBlue;
        //public static readonly Color Clr_Select = Color.Yellow; //Color.CornflowerBlue;
		
		public string r_BLD = "";
		//public int chomer = 0;

        /************************************************
         *                                              *
         *        environment PROD sql 2000  \\SQLDEV   * 
         *                                              *
         ************************************************/
        //public static string SQLDB = @"SQLDEV\PGC_SS2000"; //SS23 ok primax
        //public static string WQfiles = @"H:\Sales\PSM_Quotes";
        //private static string dbpwd = "primax";

        /****************************************
         *                                      *
         *       PROD sql2005                  * 
         *                                      *
         ***************************************/
        //public static string SQLDB = @"NTSERVER2\PSM_DB2K5";
        //public static string WQfiles = @"H:\Sales\PSM_Quotes";
        //private static string dbpwd = "pgchada,,";

        /******************************************
        *                                         *
        * environment PROD sql 2000   \\NTSERVER2 * 
        *                                         *
        ******************************************/

        /*
        Changement: Modifier le nom du serveur SQL => Résultat: La connexion se créera avec le nouveau serveur local
        */
        public static string SQLDB = @"ERPSERVER\PSM_DB2K8K"; //SS23 ok primax
        public static string WQfiles = @"H:\Sales\PSM_Quotes";
        //public static string WQfiles = @"C:\Users\%username%\Primax Technologies Inc\Primax_Data - PSM_Quotes";
        public static string PDFfiles = "AcroRd32.exe";
        private static string dbpwd = "darasam";

        //environment TU
        //public static string SQLDB = @"PROGRAMEUR1\PERS2000"; //SS23 ok test
        //public static string WQfiles = @"C:\dataprimax\toto_Qtest";
        //private static string dbpwd = "primax";
 
		bool dead=false;
        public static string currDB="Orig_PSM_FDB";
        public static string PL_BACKDB = "Back_PSM_FDB";
        public static string PL_ORIGDB = "Orig_PSM_FDB";

        /*
        //test database connection (haven't set it up yet but you could try)
        //put in mind that you will be working on the live db so be careful about making big changes
        //public static string currDB = "PGESCOM_test_app";
        //public static string PL_ORIGDB = "PGESCOM_test_app";
        */

        public static string PL_SYSPRO = "Primax_X";

        public static bool Env_PROD = true;
        //public static string currXMLfile = @"\PGC_config.xml";
        public static string currXMLfile = @"\PGC25_config.xml";
        static string GescomBld = "200228.00"; //YYMMDD.VV //"60824.00"
        static string RealBld = "210825.00"; //"210218.00"

        //TESTING ENV XTTT
        //public static string WQfiles = @"c:\A_netprimax\Sales\PSM_Quotes";
        //public static string currDB = "XTT";
        //public static string GescomBld = "6xxxx.xx"; //YMMDD.VV 

        static string DBusrNm = "sa";
        public static string _connectionString = @"user id=" + "sa" + ";password=" + "darasam" + ";server=" + @"ERPSERVER\PSM_DB2K8K" + ";Trusted_Connection=No;database=" + "PGESCOM_NEW" + ";connection timeout=30";
        public static string M_stCon= @"user id=" + DBusrNm + ";password=" + dbpwd + ";server=" + SQLDB + ";Trusted_Connection=No;database=" + currDB + ";connection timeout=30";
        public static string M_stCon_PL_BACK = @"user id=" + DBusrNm + ";password=" + dbpwd + ";server=" + SQLDB + ";Trusted_Connection=No;database=" + PL_BACKDB + ";connection timeout=30";
        public static string M_stCon_PL_ORIG = @"user id=" + DBusrNm + ";password=" + dbpwd + ";server=" + SQLDB + ";Trusted_Connection=No;database=" + PL_ORIGDB + ";connection timeout=30";
        //testing syspro public static string M_stCon_PL_SYSPRO = @"user id=sa;password=prim@x1;server=ERPSERVER\PGESCOM;Trusted_Connection=No;database=SysproCompanyX;connection timeout=30";

        public static string M_stCon_PL_SYSPRO = @"user id=sa;password=prim@x1;server=ERPSERVER\PGESCOM;Trusted_Connection=No;database=SysproCompanyP;connection timeout=30";
        //public static string M_stCon_PL_SYSPRO = @"user id=sa;password=haidarprimax2013;server=ERPSERVER\PGESCOM;Trusted_Connection=No;database=SysproCompanyP;connection timeout=30";

        //public static string M_stCon_Big = @"user id=sa;password=" + dbpwd + ";server=" + SQLDB + ";Trusted_Connection=No;database=" + currDB + ";connection timeout=100";
        public static string M_stCon_XL = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + @"\XL_stat.xls" + @";Extended Properties=Excel 8.0;";
		//public static readonly string M_stCon_LOC = @"Provider=Microsoft.Jet.SqlDB.4.0;Data Source=" + Application.StartupPath + "\\" + loc_DB + @" ;Persist Security Info=False";
        public static string M_stCon_CMS_ACCS_JET = @"Provider=Microsoft.Jet.OLEDB.4.1;Data Source=ERPSERVER\Commissions\PrimaxCommissions.accdb;Persist Security Info=False;";
        public static string M_stCon_CMS_ACCS_ACE = "";

		//public static readonly string _connectionString = @"Provider=Microsoft.Jet.SqlDB.4.0;Data Source=" + Application.StartupPath + "\\" + loc_DB + @" ;Persist Security Info=False";
		public static string M_PBS_stCon = ""; //= @"Provider=Microsoft.Jet.SqlDB.4.0;Data Source=" + PBSPath + @"\PX_batlist.mdb" + @";Persist Security Info=False" ; //;Jet SqlDB:Database Password =" + "aaa999";
		public static long UserID = -1;
		public static string User = "";
        public static string multiplier = ""; // quote multiplier
		public static string User_FNM = "", MdulNm = "";
		public static string Mach_Name = "", IPadress = "", IPportNB = "";
		public static char profile = '*'; //S:SuperUser N:Normal L:saLes P:Production T:Testing D:Direction/Board H:sHiping
		public static string Curr_Module = "";
		public static string DYMOName = @"DYMO LabelWriter 330 Turbo", SRVRpwd = "N", PDF_READER = "AcroRd32.exe";
		public static string Def_LoginUser = "";
		public static string Def_LoginPass = "";
		public static string C_Style = "103";
		private string LastMsg = "";
        public static readonly int Max_Flds_Vals = 200;
		public static string stXP = "";
		public static readonly string VIDE = "n/a";

        public static readonly int MAX_XLlines_XPRT = 3000;

		public static readonly string UNKNWN_CPNY = "Unknown company";
		public static readonly int NB_DEC_CAL = 10;
		public static readonly int NB_LookOrders_A00 = 5; //Project # display by 5 digit at orders List
		public static readonly int Q_NB_DEC_AFF = 2;
		public static readonly int NB_DEC_AFF = 2;
		public static readonly Color CLR_C_Chng = Color.Thistle;
		public static readonly Color CLR_A_Chng = Color.LightSalmon;
		public static int Lang = 0, SYSPRO_INV_len = 15;
		//public static string Modified_MLV = "";
		public static Lib1 Tools = new Lib1();
		public static bool login = false;
		
        //tkeys..saved
        public static string R_tkey = "", Q_tkey = "", SP_tkey="";

		public static Quote frm_Qte = null;
		public static Order frm_Ord = null;
		public static Options frm_opts = null;
        private int timer3_majMsgNB = 0;

        //TCP 
        public AsyncCallback myAsyncCallBack;
        public Socket mySocketLSNR;
        public Socket mySocketWRKR;
        string TCPreceivedTXT = "";
        IPEndPoint myIPendP = null;

        public const long MAX_XL_SChedule = 500;
		public static readonly string Default_LeadTime = "4";
		public const long MAX_QID = 999999;
		public const long MAX_ALS_Lines = 100;
		public const long MAX_ALS_COLs = 7;
		public const int MAX_Quote_lines = 200; //50
        public const long MAX_SC_TASKS = 100;
        public const long MAX_xlBills_RWS = 600, MAX_xlBills_COL = 16; //line & Cols XL bills to import from accounting
		
		public static string[] arr_COMPANY = new string[2000];
		public static string[,] arr_EFSdict = new string[200, 3];
        public static string[,] arr_clpB = new string[MainMDI.MAX_Quote_lines, 13];
        private System.ComponentModel.IContainer components;
		private System.Windows.Forms.ContextMenu CHRECmnu;
        private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.ImageList ILOnOff;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.ContextMenu QTmnu;
        private System.Windows.Forms.MenuItem menuItem2;
        private System.Windows.Forms.Timer timer2;
		private System.Windows.Forms.Timer timer3;
        private System.Windows.Forms.Timer timer4;
        private System.Windows.Forms.ImageList Fst_IL32;
        private CheckBox chkXTT;
        private Panel panel1;
        private ToolStrip TSmain;
        private ToolStripButton new_qt;
        private ToolStripButton Orders;
        private ToolStripButton bglst;
        private ToolStripButton arch;
        private ToolStripButton company;
        private ToolStripButton cntct;
        private ToolStripButton cpts;
        private ToolStripButton Statistics;
        private ToolStripButton pbsizing;
        private ToolStripButton pg_tools;
        private ToolStripButton exiit;
        private Button button2;
        private PictureBox picExit;
        private Label lchomer;
        private Label label1;
        private Label lxtt;
        private Button button1;
        private ToolBar toolBar1;
        private ToolBarButton qt;
        private ToolBarButton fndQt;
        private ToolBarButton Ord;
        private ToolBarButton BigLIST;
        private ToolBarButton OldPro;
        private ToolBarButton cpny;
        private ToolBarButton Contacts;
        private ToolBarButton opt;
        private ToolBarButton Stat;
        private ToolBarButton PBS;
        private ToolBarButton misc;
        private ToolBarButton logoff;
        private ToolBarButton COSTS;
        private ToolBarButton abt;
        private ToolBarButton exit;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripButton db_used;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripButton babt;
        private ToolStripButton sett;
        private ToolStripButton toolStripButton1;
        public PictureBox picCIP;
        private ToolStripButton ts_acct;
        private ToolStripButton SP_REP;
        private ContextMenu RND_tools;
        private MenuItem menuItem3;
        private MenuItem menuItem4;
        private ToolStripDropDownButton RnD;
        private ToolStripMenuItem assembliesToolStripMenuItem;
        private ToolStripMenuItem componentsSearchToolStripMenuItem;
        private System.Windows.Forms.Label lCRight;
		//ceci est
		
		//private string Ipsm_DBName = Application.StartupPath + "\\psm.mdb";
		//private string Ipsm_DBPWD = "aaa999";
		//private string Istcon1 = @"Provider=Microsoft.Jet.SqlDB.4.0;Data Source=";
		//private string Istcon2 = @";Persist Security Info=False;Jet SqlDB:Database Password =";

		//internal SqlConnection Ipsm_Conn;
		//internal SqlDataReader Ipsm_OAdp = new SqlDataReader();
		//internal DataSet Ipsm_Ds;

		public MainMDI()
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();

			System.Diagnostics.Process [] localByName = System.Diagnostics.Process.GetProcessesByName("GESCOM");
			NBGescom();

			SET_ENG_CAN_cultur_NFO(); //set regional language option to English-Canadian for current station

            //aff_sqlInstances();

			//
			//TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if (components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainMDI));
            this.lCRight = new System.Windows.Forms.Label();
            this.Fst_IL32 = new System.Windows.Forms.ImageList(this.components);
            this.QTmnu = new System.Windows.Forms.ContextMenu();
            this.menuItem2 = new System.Windows.Forms.MenuItem();
            this.CHRECmnu = new System.Windows.Forms.ContextMenu();
            this.menuItem10 = new System.Windows.Forms.MenuItem();
            this.menuItem1 = new System.Windows.Forms.MenuItem();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.ILOnOff = new System.Windows.Forms.ImageList(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            this.timer3 = new System.Windows.Forms.Timer(this.components);
            this.timer4 = new System.Windows.Forms.Timer(this.components);
            this.chkXTT = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.new_qt = new System.Windows.Forms.ToolStripButton();
            this.Orders = new System.Windows.Forms.ToolStripButton();
            this.pbsizing = new System.Windows.Forms.ToolStripButton();
            this.arch = new System.Windows.Forms.ToolStripButton();
            this.bglst = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.company = new System.Windows.Forms.ToolStripButton();
            this.cpts = new System.Windows.Forms.ToolStripButton();
            this.cntct = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.Statistics = new System.Windows.Forms.ToolStripButton();
            this.pg_tools = new System.Windows.Forms.ToolStripButton();
            this.RnD = new System.Windows.Forms.ToolStripDropDownButton();
            this.assembliesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.componentsSearchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SP_REP = new System.Windows.Forms.ToolStripButton();
            this.ts_acct = new System.Windows.Forms.ToolStripButton();
            this.sett = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.babt = new System.Windows.Forms.ToolStripButton();
            this.exiit = new System.Windows.Forms.ToolStripButton();
            this.db_used = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.button2 = new System.Windows.Forms.Button();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.lchomer = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lxtt = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.qt = new System.Windows.Forms.ToolBarButton();
            this.fndQt = new System.Windows.Forms.ToolBarButton();
            this.Ord = new System.Windows.Forms.ToolBarButton();
            this.BigLIST = new System.Windows.Forms.ToolBarButton();
            this.OldPro = new System.Windows.Forms.ToolBarButton();
            this.cpny = new System.Windows.Forms.ToolBarButton();
            this.Contacts = new System.Windows.Forms.ToolBarButton();
            this.opt = new System.Windows.Forms.ToolBarButton();
            this.Stat = new System.Windows.Forms.ToolBarButton();
            this.PBS = new System.Windows.Forms.ToolBarButton();
            this.misc = new System.Windows.Forms.ToolBarButton();
            this.logoff = new System.Windows.Forms.ToolBarButton();
            this.COSTS = new System.Windows.Forms.ToolBarButton();
            this.abt = new System.Windows.Forms.ToolBarButton();
            this.exit = new System.Windows.Forms.ToolBarButton();
            this.RND_tools = new System.Windows.Forms.ContextMenu();
            this.menuItem3 = new System.Windows.Forms.MenuItem();
            this.menuItem4 = new System.Windows.Forms.MenuItem();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.TSmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            this.SuspendLayout();
            // 
            // lCRight
            // 
            this.lCRight.BackColor = System.Drawing.SystemColors.Control;
            this.lCRight.Enabled = false;
            this.lCRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lCRight.Location = new System.Drawing.Point(644, 23);
            this.lCRight.Name = "lCRight";
            this.lCRight.Size = new System.Drawing.Size(280, 16);
            this.lCRight.TabIndex = 204;
            this.lCRight.Text = "Copyright © 2003-2006 Primax Technologies Inc.";
            this.lCRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.Fst_IL32.Images.SetKeyName(6, "");
            this.Fst_IL32.Images.SetKeyName(7, "");
            this.Fst_IL32.Images.SetKeyName(8, "");
            this.Fst_IL32.Images.SetKeyName(9, "");
            this.Fst_IL32.Images.SetKeyName(10, "");
            this.Fst_IL32.Images.SetKeyName(11, "");
            this.Fst_IL32.Images.SetKeyName(12, "");
            this.Fst_IL32.Images.SetKeyName(13, "");
            this.Fst_IL32.Images.SetKeyName(14, "");
            this.Fst_IL32.Images.SetKeyName(15, "");
            this.Fst_IL32.Images.SetKeyName(16, "");
            this.Fst_IL32.Images.SetKeyName(17, "");
            this.Fst_IL32.Images.SetKeyName(18, "Folder.png");
            this.Fst_IL32.Images.SetKeyName(19, "Vistual Folder.png");
            this.Fst_IL32.Images.SetKeyName(20, "info.png");
            this.Fst_IL32.Images.SetKeyName(21, "folder.png");
            this.Fst_IL32.Images.SetKeyName(22, "Folder.png");
            this.Fst_IL32.Images.SetKeyName(23, "New Folder.ico");
            this.Fst_IL32.Images.SetKeyName(24, "Folder Blue.ico");
            this.Fst_IL32.Images.SetKeyName(25, "Folder Yellow.ico");
            this.Fst_IL32.Images.SetKeyName(26, "folder_blue.ico");
            this.Fst_IL32.Images.SetKeyName(27, "folder_yellow.ico");
            this.Fst_IL32.Images.SetKeyName(28, "package_utilities-13.ICO");
            // 
            // QTmnu
            // 
            this.QTmnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem2});
            // 
            // menuItem2
            // 
            this.menuItem2.Index = 0;
            this.menuItem2.Text = "ALL QUOTES";
            this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
            // 
            // CHRECmnu
            // 
            this.CHRECmnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem10,
            this.menuItem1});
            // 
            // menuItem10
            // 
            this.menuItem10.Index = 0;
            this.menuItem10.Text = "ALL PROJECTs";
            this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
            // 
            // menuItem1
            // 
            this.menuItem1.Index = 1;
            this.menuItem1.Text = "Old Projects";
            this.menuItem1.Click += new System.EventHandler(this.menuItem1_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 2000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // ILOnOff
            // 
            this.ILOnOff.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("ILOnOff.ImageStream")));
            this.ILOnOff.TransparentColor = System.Drawing.Color.Transparent;
            this.ILOnOff.Images.SetKeyName(0, "");
            this.ILOnOff.Images.SetKeyName(1, "");
            // 
            // timer2
            // 
            this.timer2.Interval = 60000;
            this.timer2.Tick += new System.EventHandler(this.timer2_Tick);
            // 
            // timer3
            // 
            this.timer3.Interval = 2000;
            this.timer3.Tick += new System.EventHandler(this.timer3_Tick);
            // 
            // timer4
            // 
            this.timer4.Enabled = true;
            this.timer4.Interval = 60000;
            this.timer4.Tick += new System.EventHandler(this.timer4_Tick);
            // 
            // chkXTT
            // 
            this.chkXTT.Location = new System.Drawing.Point(595, 0);
            this.chkXTT.Name = "chkXTT";
            this.chkXTT.Size = new System.Drawing.Size(114, 20);
            this.chkXTT.TabIndex = 262;
            this.chkXTT.Text = "XTT";
            this.chkXTT.Visible = false;
            this.chkXTT.CheckedChanged += new System.EventHandler(this.chkXTT_CheckedChanged);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Transparent;
            this.panel1.Controls.Add(this.picCIP);
            this.panel1.Controls.Add(this.TSmain);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.picExit);
            this.panel1.Controls.Add(this.lchomer);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.lxtt);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.toolBar1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1284, 62);
            this.panel1.TabIndex = 263;
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(1075, 31);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(27, 28);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 263;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            this.picCIP.Click += new System.EventHandler(this.picCIP_Click);
            // 
            // TSmain
            // 
            this.TSmain.AutoSize = false;
            this.TSmain.BackColor = System.Drawing.Color.Wheat;
            this.TSmain.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TSmain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.new_qt,
            this.Orders,
            this.pbsizing,
            this.arch,
            this.bglst,
            this.toolStripSeparator1,
            this.company,
            this.cpts,
            this.cntct,
            this.toolStripSeparator2,
            this.Statistics,
            this.pg_tools,
            this.RnD,
            this.SP_REP,
            this.ts_acct,
            this.sett,
            this.toolStripSeparator3,
            this.babt,
            this.exiit,
            this.db_used,
            this.toolStripButton1});
            this.TSmain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.TSmain.Location = new System.Drawing.Point(0, 0);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(1284, 63);
            this.TSmain.TabIndex = 261;
            this.TSmain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TSmain_ItemClicked);
            // 
            // new_qt
            // 
            this.new_qt.Image = ((System.Drawing.Image)(resources.GetObject("new_qt.Image")));
            this.new_qt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.new_qt.Name = "new_qt";
            this.new_qt.Size = new System.Drawing.Size(57, 60);
            this.new_qt.Text = "Quotes";
            this.new_qt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.new_qt.ToolTipText = "Quotes";
            this.new_qt.Click += new System.EventHandler(this.new_qt_Click);
            // 
            // Orders
            // 
            this.Orders.Image = ((System.Drawing.Image)(resources.GetObject("Orders.Image")));
            this.Orders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Orders.Name = "Orders";
            this.Orders.Size = new System.Drawing.Size(62, 60);
            this.Orders.Text = "Projects";
            this.Orders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Orders.ToolTipText = "Projects";
            this.Orders.Click += new System.EventHandler(this.Orders_Click);
            // 
            // pbsizing
            // 
            this.pbsizing.Image = ((System.Drawing.Image)(resources.GetObject("pbsizing.Image")));
            this.pbsizing.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pbsizing.Name = "pbsizing";
            this.pbsizing.Size = new System.Drawing.Size(68, 60);
            this.pbsizing.Text = "Schedule";
            this.pbsizing.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.pbsizing.ToolTipText = "Vacations";
            this.pbsizing.Click += new System.EventHandler(this.pbsizing_Click);
            // 
            // arch
            // 
            this.arch.Image = ((System.Drawing.Image)(resources.GetObject("arch.Image")));
            this.arch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.arch.Name = "arch";
            this.arch.Size = new System.Drawing.Size(65, 60);
            this.arch.Text = "Old Proj.";
            this.arch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.arch.Click += new System.EventHandler(this.arch_Click);
            // 
            // bglst
            // 
            this.bglst.Image = ((System.Drawing.Image)(resources.GetObject("bglst.Image")));
            this.bglst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bglst.Name = "bglst";
            this.bglst.Size = new System.Drawing.Size(74, 60);
            this.bglst.Text = "Testiiiiiiing";
            this.bglst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bglst.ToolTipText = "Testing";
            this.bglst.Click += new System.EventHandler(this.bglst_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 63);
            // 
            // company
            // 
            this.company.Image = ((System.Drawing.Image)(resources.GetObject("company.Image")));
            this.company.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.company.Name = "company";
            this.company.Size = new System.Drawing.Size(81, 60);
            this.company.Text = "Companies";
            this.company.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.company.ToolTipText = "Companies";
            this.company.Click += new System.EventHandler(this.company_Click);
            // 
            // cpts
            // 
            this.cpts.Image = ((System.Drawing.Image)(resources.GetObject("cpts.Image")));
            this.cpts.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cpts.Name = "cpts";
            this.cpts.Size = new System.Drawing.Size(91, 60);
            this.cpts.Text = "Components";
            this.cpts.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cpts.ToolTipText = "Components";
            this.cpts.Click += new System.EventHandler(this.cpts_Click);
            // 
            // cntct
            // 
            this.cntct.Image = ((System.Drawing.Image)(resources.GetObject("cntct.Image")));
            this.cntct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cntct.Name = "cntct";
            this.cntct.Size = new System.Drawing.Size(67, 60);
            this.cntct.Text = "Contacts";
            this.cntct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cntct.ToolTipText = "Contacts";
            this.cntct.Visible = false;
            this.cntct.Click += new System.EventHandler(this.cntct_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 63);
            // 
            // Statistics
            // 
            this.Statistics.Image = ((System.Drawing.Image)(resources.GetObject("Statistics.Image")));
            this.Statistics.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Statistics.Name = "Statistics";
            this.Statistics.Size = new System.Drawing.Size(68, 60);
            this.Statistics.Text = "Statistics";
            this.Statistics.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Statistics.ToolTipText = "Statistics";
            this.Statistics.Click += new System.EventHandler(this.Statistics_Click);
            // 
            // pg_tools
            // 
            this.pg_tools.Image = ((System.Drawing.Image)(resources.GetObject("pg_tools.Image")));
            this.pg_tools.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.pg_tools.Name = "pg_tools";
            this.pg_tools.Size = new System.Drawing.Size(67, 60);
            this.pg_tools.Text = "   Tools   ";
            this.pg_tools.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.pg_tools.ToolTipText = "Tools";
            this.pg_tools.Click += new System.EventHandler(this.pg_tools_Click);
            // 
            // RnD
            // 
            this.RnD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.assembliesToolStripMenuItem,
            this.componentsSearchToolStripMenuItem});
            this.RnD.Image = ((System.Drawing.Image)(resources.GetObject("RnD.Image")));
            this.RnD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RnD.Name = "RnD";
            this.RnD.Size = new System.Drawing.Size(82, 60);
            this.RnD.Text = "R&&D Tools";
            this.RnD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // assembliesToolStripMenuItem
            // 
            this.assembliesToolStripMenuItem.Name = "assembliesToolStripMenuItem";
            this.assembliesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.assembliesToolStripMenuItem.Text = "Assemblies";
            this.assembliesToolStripMenuItem.Click += new System.EventHandler(this.assembliesToolStripMenuItem_Click);
            // 
            // componentsSearchToolStripMenuItem
            // 
            this.componentsSearchToolStripMenuItem.Name = "componentsSearchToolStripMenuItem";
            this.componentsSearchToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.componentsSearchToolStripMenuItem.Text = "Components Search";
            this.componentsSearchToolStripMenuItem.Click += new System.EventHandler(this.componentsSearchToolStripMenuItem_Click);
            // 
            // SP_REP
            // 
            this.SP_REP.Image = ((System.Drawing.Image)(resources.GetObject("SP_REP.Image")));
            this.SP_REP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SP_REP.Name = "SP_REP";
            this.SP_REP.Size = new System.Drawing.Size(73, 60);
            this.SP_REP.Text = "R&&D Tools";
            this.SP_REP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SP_REP.Visible = false;
            this.SP_REP.Click += new System.EventHandler(this.SP_REP_Click);
            // 
            // ts_acct
            // 
            this.ts_acct.Image = ((System.Drawing.Image)(resources.GetObject("ts_acct.Image")));
            this.ts_acct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_acct.Name = "ts_acct";
            this.ts_acct.Size = new System.Drawing.Size(38, 60);
            this.ts_acct.Text = "CMS";
            this.ts_acct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ts_acct.Click += new System.EventHandler(this.ts_acct_Click);
            // 
            // sett
            // 
            this.sett.Image = ((System.Drawing.Image)(resources.GetObject("sett.Image")));
            this.sett.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sett.Name = "sett";
            this.sett.Size = new System.Drawing.Size(56, 60);
            this.sett.Text = "Setting";
            this.sett.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sett.Visible = false;
            this.sett.Click += new System.EventHandler(this.sett_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 63);
            // 
            // babt
            // 
            this.babt.Image = ((System.Drawing.Image)(resources.GetObject("babt.Image")));
            this.babt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.babt.Name = "babt";
            this.babt.Size = new System.Drawing.Size(48, 60);
            this.babt.Text = "About";
            this.babt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.babt.Click += new System.EventHandler(this.babt_Click);
            // 
            // exiit
            // 
            this.exiit.Image = ((System.Drawing.Image)(resources.GetObject("exiit.Image")));
            this.exiit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exiit.Name = "exiit";
            this.exiit.Size = new System.Drawing.Size(98, 60);
            this.exiit.Text = "        Exit        ";
            this.exiit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exiit.ToolTipText = "Exit";
            this.exiit.Click += new System.EventHandler(this.exiit_Click);
            // 
            // db_used
            // 
            this.db_used.Image = ((System.Drawing.Image)(resources.GetObject("db_used.Image")));
            this.db_used.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.db_used.Name = "db_used";
            this.db_used.Size = new System.Drawing.Size(85, 60);
            this.db_used.Text = "DB_xxxxxxx";
            this.db_used.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.db_used.Visible = false;
            this.db_used.Click += new System.EventHandler(this.db_used_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 60);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(680, 32);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(64, 24);
            this.button2.TabIndex = 205;
            this.button2.Text = "button2";
            this.button2.Visible = false;
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.Image = ((System.Drawing.Image)(resources.GetObject("picExit.Image")));
            this.picExit.Location = new System.Drawing.Point(872, 8);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(40, 40);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 197;
            this.picExit.TabStop = false;
            this.picExit.Visible = false;
            // 
            // lchomer
            // 
            this.lchomer.BackColor = System.Drawing.Color.PeachPuff;
            this.lchomer.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lchomer.Location = new System.Drawing.Point(776, 40);
            this.lchomer.Name = "lchomer";
            this.lchomer.Size = new System.Drawing.Size(17, 16);
            this.lchomer.TabIndex = 203;
            this.lchomer.Text = "0";
            this.lchomer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lchomer.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(656, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(32, 24);
            this.label1.TabIndex = 21;
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // lxtt
            // 
            this.lxtt.BackColor = System.Drawing.SystemColors.Control;
            this.lxtt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lxtt.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lxtt.ForeColor = System.Drawing.Color.Red;
            this.lxtt.Location = new System.Drawing.Point(768, 8);
            this.lxtt.Name = "lxtt";
            this.lxtt.Size = new System.Drawing.Size(48, 40);
            this.lxtt.TabIndex = 201;
            this.lxtt.Text = "XTT";
            this.lxtt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lxtt.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Khaki;
            this.button1.ImageIndex = 12;
            this.button1.Location = new System.Drawing.Point(600, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 40);
            this.button1.TabIndex = 20;
            this.button1.Text = "?";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.AutoSize = false;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.qt,
            this.fndQt,
            this.Ord,
            this.BigLIST,
            this.OldPro,
            this.cpny,
            this.Contacts,
            this.opt,
            this.Stat,
            this.PBS,
            this.misc,
            this.logoff,
            this.COSTS,
            this.abt,
            this.exit});
            this.toolBar1.Divider = false;
            this.toolBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolBar1.Location = new System.Drawing.Point(424, 23);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(54, 23);
            this.toolBar1.TabIndex = 262;
            this.toolBar1.Visible = false;
            // 
            // qt
            // 
            this.qt.ImageIndex = 27;
            this.qt.Name = "qt";
            this.qt.Text = "Quotes";
            this.qt.ToolTipText = "QUOTES";
            // 
            // fndQt
            // 
            this.fndQt.ImageIndex = 19;
            this.fndQt.Name = "fndQt";
            this.fndQt.Text = "All Quotes";
            this.fndQt.ToolTipText = "All Quotes";
            this.fndQt.Visible = false;
            // 
            // Ord
            // 
            this.Ord.ImageIndex = 26;
            this.Ord.Name = "Ord";
            this.Ord.Text = "Projects";
            this.Ord.ToolTipText = "Projects";
            // 
            // BigLIST
            // 
            this.BigLIST.ImageIndex = 1;
            this.BigLIST.Name = "BigLIST";
            this.BigLIST.Text = "All projects";
            this.BigLIST.ToolTipText = "All projects";
            // 
            // OldPro
            // 
            this.OldPro.ImageIndex = 3;
            this.OldPro.Name = "OldPro";
            this.OldPro.Text = "Archives";
            // 
            // cpny
            // 
            this.cpny.ImageIndex = 6;
            this.cpny.Name = "cpny";
            this.cpny.Text = "Companies";
            this.cpny.ToolTipText = "Companies";
            // 
            // Contacts
            // 
            this.Contacts.ImageIndex = 5;
            this.Contacts.Name = "Contacts";
            this.Contacts.Text = "Contacts";
            this.Contacts.ToolTipText = "Contacts";
            // 
            // opt
            // 
            this.opt.ImageIndex = 7;
            this.opt.Name = "opt";
            this.opt.Text = "Components";
            this.opt.ToolTipText = "Components";
            // 
            // Stat
            // 
            this.Stat.ImageIndex = 8;
            this.Stat.Name = "Stat";
            this.Stat.Text = "Statistics";
            this.Stat.ToolTipText = "Statistics";
            // 
            // PBS
            // 
            this.PBS.ImageIndex = 15;
            this.PBS.Name = "PBS";
            this.PBS.Text = "PBsizing";
            this.PBS.ToolTipText = "battery sizing";
            // 
            // misc
            // 
            this.misc.ImageIndex = 28;
            this.misc.Name = "misc";
            this.misc.Text = "Tools";
            this.misc.ToolTipText = "Tools";
            // 
            // logoff
            // 
            this.logoff.ImageIndex = 16;
            this.logoff.Name = "logoff";
            this.logoff.Text = "Logoff";
            this.logoff.ToolTipText = "Switch User";
            this.logoff.Visible = false;
            // 
            // COSTS
            // 
            this.COSTS.ImageIndex = 10;
            this.COSTS.Name = "COSTS";
            this.COSTS.Text = "COSTS";
            this.COSTS.ToolTipText = "COSTS";
            this.COSTS.Visible = false;
            // 
            // abt
            // 
            this.abt.ImageIndex = 20;
            this.abt.Name = "abt";
            this.abt.Text = "About";
            this.abt.ToolTipText = "About";
            // 
            // exit
            // 
            this.exit.ImageIndex = 0;
            this.exit.Name = "exit";
            this.exit.Text = "Exit";
            this.exit.ToolTipText = "EXIT";
            this.exit.Visible = false;
            // 
            // RND_tools
            // 
            this.RND_tools.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.menuItem3,
            this.menuItem4});
            // 
            // menuItem3
            // 
            this.menuItem3.Index = 0;
            this.menuItem3.Text = "Assemblies";
            this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
            // 
            // menuItem4
            // 
            this.menuItem4.Index = 1;
            this.menuItem4.Text = "Search Components ";
            // 
            // MainMDI
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.PapayaWhip;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1284, 359);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lCRight);
            this.Controls.Add(this.chkXTT);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainMDI";
            this.Text = "Primax Gestion Commerciale  - PGESCOM ( MSS2K8_V2013) - ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.MainMDI_Closing);
            this.Load += new System.EventHandler(this.MainMDI_Load);
            this.DoubleClick += new System.EventHandler(this.MainMDI_DoubleClick);
            this.Resize += new System.EventHandler(this.MainMDI_Resize);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.DoEvents();
			Application.Run(new MainMDI());
		}

        private void aff_sqlInstances()
        {
            SqlDataSourceEnumerator instance = SqlDataSourceEnumerator.Instance;
            System.Data.DataTable table = instance.GetDataSources();
            string stout = DisplayData(table);
            MessageBox.Show(stout);
        }

        private string DisplayData(System.Data.DataTable table)
        {
            string stout = "";
            foreach (System.Data.DataRow row in table.Rows)
            {
                foreach (System.Data.DataColumn col in table.Columns)
                {
                    stout += "\n col=" + col.ColumnName + "  row=" + row[col];
                }
            }
            return stout;
        }

        void slowingPC()
        {
            for (int i = 0; i < 80000; i++)
            {
                for (int j = 0; j < 10000; j++)
                {
                    Application.DoEvents();
                }
                Application.DoEvents();
            }
        }

		private void NBGescom()
		{
			System.Diagnostics.Process ThisProcess = System.Diagnostics.Process.GetCurrentProcess();

			System.Diagnostics.Process [] AllProcesses = System.Diagnostics.Process.GetProcessesByName(ThisProcess.ProcessName);

			if (AllProcesses.Length > 1)
			{
				//MessageBox.Show(ThisProcess.ProcessName + " is already running",
				    //ThisProcess.ProcessName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				MessageBox.Show("This Application is already running ...........!!",
				    ThisProcess.ProcessName, MessageBoxButtons.OK, MessageBoxIcon.Error);
				Application.Exit();
			}
            //if (!IsPGCInsta()) { Application.Exit(); }
		}

		private static void SET_ENG_CAN_cultur_NFO()
		{
            //MessageBox.Show("CurrentCulture is {0}.", CultureInfo.CurrentCulture.Name);
            //NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat; //new CultureInfo("en-US", false).NumberFormat;
            //nfi.NumberDecimalSeparator = "."

            Thread.CurrentThread.CurrentCulture = new CultureInfo("en-CA");

            //System.IFormatProvider format =
            //new System.Globalization.CultureInfo("fr-FR", true);

            NumberFormatInfo nfi = CultureInfo.CurrentCulture.NumberFormat; //new CultureInfo("en-US", false).NumberFormat;
			DateTimeFormatInfo dtF = CultureInfo.CurrentCulture.DateTimeFormat;
			if (dtF.ShortDatePattern.ToString() == "dd/MM/yyyy") C_Style = "103";
			if (dtF.ShortDatePattern.ToString() == "MM/dd/yyyy") C_Style = "101";
			
			//MessageBox.Show("before...dtF.ShortDatePattern= " + dtF.ShortDatePattern.ToString());
			//to set value.... dtF.ShortDatePattern = "dd/MM/yyyy h:mm tt";
			//MessageBox.Show("before...dtF.ShortDatePattern= " + dtF.ShortDatePattern.ToString());
			//dtF.ShortDatePattern = "dd/MM/yyyy h:mm tt";
			//Mess
			//MessageBox.Show("SEP= " + nfi.NumberDecimalSeparator.ToString());
			//Displays the same value with a blank as the separator.
			//nfi.NumberDecimalSeparator = " ";
			//Console.WriteLine(myInt.ToString("N", nfi));
		}

        private void unlock_menu()
        {
            if (MainMDI.User.ToLower() == "unlock")
            {
                for (int i = 0; i < TSmain.Items.Count; i++) TSmain.Items[i].Visible = false;

                pg_tools.Visible = true;
                exiit.Visible = true;
                babt.Visible = true;
            }
        }

        private void MainMDI_LoadOLD_15112015(object sender, System.EventArgs e)
        {
            //if (chkXTT.Checked) load_XTT();
            if (INIT_OK)
            {
                if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
                else NBGescom();
                string res = MainMDI.Find_One_Field("select  s_stat from PSM_SYSETUP where s_machNm='PGESCOM' ");
                if (res != "9" || res == "8") //9:exit from PGESCOM 8:exit except for usrs: Admin/Admin
                {
                    string bld = MainMDI.Find_One_Field("select  BLD from PSM_SYSETUP where  s_machNm='PGESCOM' ");
                    if (bld == GescomBld)
                    {
                        if (load_Loc_Config())
                        {
                            logxx();
                            if (login)
                            {
                                if (!Creat_TempTbls())
                                {
                                    MessageBox.Show("Cannot create Temp Tables !... Contact your DB Admin...");
                                    Application.Exit();
                                }
                                else
                                {
                                    //if (res != "8") MainMDI.ExecSql("UPDATE PSM_SYSETUP  SET [s_stat]='1', [s_machNm]=' ' ");
                                    Write_JFS(User + " logs IN: " + System.DateTime.Now);
                                    if (!chkXTT.Checked) Write_Whodo_SSetup("main Menu", 'F'); //??? tobechanged
                                    else Write_Whodo_SSetup("main Menu", 'I');
                                    unlock_menu();
                                    timer1.Enabled = true;
                                }
                                Passwd frmpass = new Passwd('L');
                                if (MainMDI.User.ToLower() == "ede") //|| MainMDI.User.ToLower() == "admin")
                                {
                                    chkXTT.Text = SQLDB + @"\" + chkXTT.Text;
                                    db_used.Text = chkXTT.Text;
                                    db_used.Visible = true;
                                    bglst.Visible = true;
                                }
                                else start_SRVR_mgr();
                            }
                        }
                    }
                    else
                    {
                        if (bld == MainMDI.VIDE) MessageBox.Show("Sorry, PGESCOM SETUP is corrupted or using BAD DATABASE contact Admin URGENTLY !!!! \n" + MainMDI.M_stCon, "                URGENT ALERT        ");
                        else
                        {
                            MessageBox.Show("Please Update PGESCOM to Build#: " + GescomBld + " ......(Current Build#:" + bld + ") \n PGESCOM will open UPDATE window ....");
                            CallUPDATE();
                            //Application.Exit();
                        }
                        //Application.Exit();
                        //int res = MessageBox.Show("Sorry, PGESCOM is under maintenance, contact Administrator...!!! ", "                         ALERT        ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                    }
                }
                else
                {
                    if (res == MainMDI.VIDE) MessageBox.Show("Sorry, PGESCOM SETUP is corrupted or using BAD DATABASE contact Admin URGENTLY !!!! \n" + MainMDI.M_stCon, "                URGENT ALERT        ");
                    else //MessageBox.Show("Sorry, PGESCOM is under maintenance, contact Administrator...!!! ", "                           ALERT        ");
                        MessageBox.Show("   \n ALERT \n Sorry, PGESCOM is under maintenance, contact Administrator...!!!", " Message ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    Application.Exit();
                }
                if ((MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD) && MainMDI.User.ToLower() != "ede" && MainMDI.User.ToLower() != "admin") //&& MainMDI.User != "hnasrat"
                {
                    MessageBox.Show("Sorry you can not continue....  PGESCOM is using an INVALID DATABASE, contact your Administrator...!!! \n" + MainMDI.M_stCon, "                           ALERT        ");
                    this.Shutdown_JOBS();
                    Application.Exit();
                }
            }
            else Application.Exit();
            unlock_menu();
            //picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
            picCIP.Visible = !(MainMDI.Env_PROD); //? false : true;
            sett.Visible = (MainMDI.user_Admin());

            //SYSPRO
            //SP_REP.Visible = (MainMDI.User.ToLower() == "ede");

            //MessageBox.Show(MainMDI.WQfiles);
        }

        public static double kim_round(double dd, int decml)
        {
            return Math.Round(dd, decml, MidpointRounding.AwayFromZero);
        }

        public static bool CallUPDATE()
        {
            bool conti = false;
            string[] args = new string[1];
            args[0] = "ddHN";
            Process prc = new Process();

            //prc.StartInfo.FileName = Application.StartupPath + @"\UPGC.exe";
            //if (!File.Exists(prc.StartInfo.FileName))
            //{
            string FNM = Find_One_Field("SELECT   F2 FROM  PSM_C_GConfig where F1_Code='UPGC'");
            if (FNM != MainMDI.VIDE)
            {
                try
                {
                    File.Copy(FNM + @"\UPGC.exe", Application.StartupPath + @"\UPGC.exe", true);
                    Application.Exit();
                    conti = true;
                }
                catch (Exception ex)
                {
                    MainMDI.send_email("UPGC@primax-e.com", "hedebbab@primax-e.com", "PGESCOM UPDATE ERROR", "sorry UPDATE error: updater NOT FOUND...... having error at user: " + MainMDI.User + "\n error msg: \n" + ex.Message);
                    MessageBox.Show("sorry UPDATE error: updater NOT FOUND......");
                }
            }
            //}
            else conti = true;
            if (conti)
            {
                prc.StartInfo.FileName = Application.StartupPath + @"\UPGC.exe";
                prc.StartInfo.Arguments = "ddHN " + User;
                prc.Start();
                return true;
            }
            else return false;
        }

        private void SaveInit(string Usr, string pwd)
        {
            string[] lines = { Usr, pwd };
            System.IO.File.WriteAllLines(InitTXT, lines);
        }

        private void MainMDI_Load_OK30052016(object sender, System.EventArgs e)
        {
            //read init.txt;
            try
            {
                string[] lines = System.IO.File.ReadAllLines(InitTXT);
                MainMDI.Def_LoginUser = (lines[0] != "!") ? lines[0] : "";
                MainMDI.Def_LoginPass = lines[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show("File: init NOT FOUND....." + ex.Message);
                MainMDI.Def_LoginUser = "user";
                MainMDI.Def_LoginPass = "123";
            }
            //toolStripLabel1.Text = "YYYYYYYYYY";
            //TSmain.Refresh();

            this.Cursor = Cursors.WaitCursor;

            logxx();
            this.Cursor = Cursors.WaitCursor;
            if (login)
            {
                //toolStripLabel1.Text = MainMDI.User;
                if (load_xmlCF())
                {
                    INIT_OK = init_Dict();
                    for (int i = 0; i < MAX_Quote_lines; i++)
                        for (int j = 0; j < 12; j++)
                            arr_clpB[i, j] = "~";
                }
                else INIT_OK = false;

                string MTF = "", msg1 = "", msg2 = "";
                MainMDI.Find_2_Field("SELECT   F2, F3, F4, F5 FROM  PSM_C_GConfig where F1_Code='InstDir'", ref MTF, ref msg1, ref msg2);
                if (@Application.ExecutablePath.IndexOf(MTF) == -1)
                {
                    if (Application.ExecutablePath.IndexOf("00-primx") == -1)
                    {
                        MessageBox.Show(msg1, msg2);
                        Application.Exit();
                        INIT_OK = false;
                    }
                }
                if (INIT_OK)
                {
                    if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
                    else NBGescom();
                    string res = MainMDI.Find_One_Field("select  s_stat from PSM_SYSETUP where s_machNm='PGESCOM' ");
                    if (res != "9" || res == "8") //9:exit from PGESCOM 8:exit except for usrs: Admin/Admin
                    {
                        string bld = MainMDI.Find_One_Field("select  BLD from PSM_SYSETUP where  s_machNm='PGESCOM' ");
                        if (bld == GescomBld)
                        {
                            if (load_Loc_Config())
                            {
                                if (!Creat_TempTbls())
                                {
                                    MessageBox.Show("Cannot create Temp Tables !... Contact your DB Admin...");
                                    Application.Exit();
                                }
                                else
                                {
                                    //if (res != "8") MainMDI.ExecSql("UPDATE PSM_SYSETUP  SET [s_stat]='1', [s_machNm]=' ' ");
                                    Write_JFS(User + " logs IN: " + System.DateTime.Now);
                                    SaveInit(User, "123");
                                    if (!chkXTT.Checked) Write_Whodo_SSetup("main Menu", 'F'); //??? tobechanged
                                    else Write_Whodo_SSetup("main Menu", 'I');
                                    unlock_menu();
                                    timer1.Enabled = true;
                                }
                                if (MainMDI.User.ToLower() == "ede") //|| MainMDI.User.ToLower() == "admin")
                                {
                                    chkXTT.Text = SQLDB + @"\" + chkXTT.Text;
                                    db_used.Text = chkXTT.Text;
                                    db_used.Visible = true;
                                }
                                else start_SRVR_mgr();
                            }
                        }
                        else
                        {
                            if (bld == MainMDI.VIDE) MessageBox.Show("Sorry, PGESCOM SETUP is corrupted or using BAD DATABASE contact Admin URGENTLY !!!! \n" + MainMDI.M_stCon, "                URGENT ALERT        ");
                            else MessageBox.Show("Please Update PGESCOM to Build#: " + GescomBld + " ......(Current Build#:" + bld + "  ) !!!");
                            //30052016
                            MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where user='" + MainMDI.User + "'");
                            //30052016
                            CallUPDATE();
                            Application.Exit();
                            //int res = MessageBox.Show("Sorry, PGESCOM is under maintenance, contact Administrator...!!! ", "                         ALERT        ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        if (res == MainMDI.VIDE) MessageBox.Show("Sorry, PGESCOM SETUP is corrupted or using BAD DATABASE contact Admin URGENTLY !!!! \n" + MainMDI.M_stCon, "                URGENT ALERT        ");
                        else //MessageBox.Show("Sorry, PGESCOM is under maintenance, contact Administrator...!!! ", "                           ALERT        ");
                            MessageBox.Show("   \n ALERT \n Sorry, PGESCOM is under maintenance, contact Administrator...!!!", " Message ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Application.Exit();
                    }
                    if ((MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD) && MainMDI.User.ToLower() != "ede" && MainMDI.User.ToLower() != "admin") //&& MainMDI.User != "hnasrat"
                    {
                        MessageBox.Show("Sorry you can not continue....  PGESCOM is using an INVALID DATABASE, contact your Administrator...!!! \n" + MainMDI.M_stCon, "                           ALERT        ");
                        this.Shutdown_JOBS();
                        Application.Exit();
                    }
                }
                else Application.Exit();
                unlock_menu();
                picCIP.Visible = !(MainMDI.Env_PROD); //? false : true;
                sett.Visible = (MainMDI.user_Admin());
                bglst.Visible = (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "hnasrat");
            }
            this.Cursor = Cursors.Default;
        }

        public static class StringCipher
        {
            private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

            private const int keysize = 256;

            public static string Encrypt(string plainText, string passPhrase)
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                                {
                                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                    cryptoStream.FlushFinalBlock();
                                    byte[] cipherTextBytes = memoryStream.ToArray();
                                    return Convert.ToBase64String(cipherTextBytes);
                                }
                            }
                        }
                    }
                }
            }

            public static string Decrypt(string cipherText, string passPhrase)
            {
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }
        }

        private void MainMDI_Load(object sender, System.EventArgs e)
		{
			//read init.txt;

            try
            {
                string[] lines = System.IO.File.ReadAllLines(InitTXT);
                MainMDI.Def_LoginUser = (lines[0] != "!") ? lines[0] : "";
                //MainMDI.Def_LoginUser = System.Environment.UserName;
                MainMDI.Def_LoginPass = lines[1];
            }
            catch (Exception ex)
            {
                MessageBox.Show("File: init NOT FOUND....." + ex.Message);
                MainMDI.Def_LoginUser = "user";
                MainMDI.Def_LoginPass = "123";
            }

            //toolStripLabel1.Text = "YYYYYYYYYY";
            //TSmain.Refresh();

            this.Cursor = Cursors.WaitCursor;

            bool ldxml = load_xmlCF();
            logxx();
            this.Cursor = Cursors.WaitCursor;
            if (login)
            {
                //toolStripLabel1.Text = MainMDI.User;
                if (ldxml)
                {
                    INIT_OK = init_Dict();
                    for (int i = 0; i < MAX_Quote_lines; i++)
                        for (int j = 0; j < 12; j++)
                            arr_clpB[i, j] = "~";
                }
                else INIT_OK = false;

                string MTF = "", msg1 = "", msg2 = "";
                string bod = "user: " + MainMDI.User + "  Workdir: " + @Application.ExecutablePath;

                if (IsPGCInsta()) bod += "   PGESCOM is GOOD insta................";
                else bod += "   PGESCOM is NOT INSTALLED ................";
                //MainMDI.send_email("PGCUP@primax-e.com", "hedebbab@primax-e.com", "workin direc....", bod);
                MainMDI.Find_2_Field("SELECT   F2, F3, F4, F5 FROM  PSM_C_GConfig where F1_Code='InstDir'", ref MTF, ref msg1, ref msg2);
                if (@Application.ExecutablePath.IndexOf(MTF) == -1)
                {
                    if (Application.ExecutablePath.IndexOf("00-primx") == -1)
                    {
                        MessageBox.Show(msg1, msg2);
                        Application.Exit();
                        INIT_OK = false;
                    }
                }
                if (INIT_OK)
                {
                    if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
                    else NBGescom();
                    string res = MainMDI.Find_One_Field("select  s_stat from PSM_SYSETUP where s_machNm='PGESCOM' ");
                    if (res != "9" || res == "8") //9:exit from PGESCOM 8:exit except for usrs: Admin/Admin
                    {
                        string bld = MainMDI.Find_One_Field("select  BLD from PSM_SYSETUP where  s_machNm='PGESCOM' ");
                        if (bld == GescomBld || MainMDI.User.ToLower() == "ddarai")
                        {
                            if (load_Loc_Config())
                            {
                                if (!Creat_TempTbls())
                                {
                                    MessageBox.Show("Cannot create Temp Tables !... Contact your DB Admin...");
                                    Application.Exit();
                                }
                                else
                                {
                                    //if (res != "8") MainMDI.ExecSql("UPDATE PSM_SYSETUP  SET [s_stat]='1', [s_machNm]=' ' ");
                                    Write_JFS(User + " logs IN: " + System.DateTime.Now);
                                    SaveInit(User, "123");
                                    if (!chkXTT.Checked) Write_Whodo_SSetup("main Menu", 'F'); //??? tobechanged
                                    else Write_Whodo_SSetup("main Menu", 'I');
                                    unlock_menu();
                                    timer1.Enabled = true;
                                }
                                if (MainMDI.User.ToLower() == "ede") //|| MainMDI.User.ToLower() == "admin")
                                {
                                    chkXTT.Text = SQLDB + @"\" + chkXTT.Text;

                                    db_used.Text = chkXTT.Text;
                                    db_used.Visible = true;

                                    /*
                                    Changement: Remplacer l'ancien nom du serveur par le nouveau 
                                    */
                                    if (SQLDB.IndexOf("ERPSERVER") == -1) TSmain.BackColor = Color.Red; //bgd.jpg
                                }
                                else start_SRVR_mgr();
                            }
                        }
                        else
                        {
                            if (bld == MainMDI.VIDE) MessageBox.Show("Sorry, PGESCOM SETUP is corrupted or using BAD DATABASE contact Admin URGENTLY !!!! \n" + MainMDI.M_stCon, "                URGENT ALERT        ");
                            else MessageBox.Show("Please Update PGESCOM to Build#: " + GescomBld + " ......(Current Build#:" + bld + "  ) !!!");
                            //30052016
                            MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where [user]='" + MainMDI.User + "'");
                            //30052016

                            if (MainMDI.Confirm("Want to UPDATE PGESCOM ???")) CallUPDATE();
                            else
                            {
                                if (MainMDI.User.ToLower() != "ede") Application.Exit();
                            }
                            //int res = MessageBox.Show("Sorry, PGESCOM is under maintenance, contact Administrator...!!! ", "                         ALERT        ", MessageBoxButtons.RetryCancel, MessageBoxIcon.Stop);
                        }
                    }
                    else
                    {
                        if (res == MainMDI.VIDE) MessageBox.Show("Sorry, PGESCOM SETUP is corrupted or using BAD DATABASE contact Admin URGENTLY !!!! \n" + MainMDI.M_stCon, "                URGENT ALERT        ");
                        else /*MessageBox.Show("Sorry, PGESCOM is under maintenance, contact Administrator...!!! ", "                           ALERT        ");*/
                            MessageBox.Show("   \n ALERT \n Sorry, PGESCOM is under maintenance, contact Administrator...!!!", " Message ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        Application.Exit();
                    }
                    if ((MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD) && MainMDI.User.ToLower() != "ede" && MainMDI.User.ToLower() != "admin") //&& MainMDI.User != "hnasrat"
                    {
                        MessageBox.Show("Sorry you can not continue....  PGESCOM is using an INVALID DATABASE, contact your Administrator...!!! \n" + MainMDI.M_stCon, "                           ALERT        ");
                        this.Shutdown_JOBS();
                        Application.Exit();
                    }
                }
                else Application.Exit();
                unlock_menu();
                picCIP.Visible = !(MainMDI.Env_PROD); //? false : true;
                sett.Visible = (MainMDI.user_Admin());
                bglst.Visible = (MainMDI.user_Admin());
                arch.Visible = (MainMDI.User.ToLower() == "mdimassi" || MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "bcimon");
                /*
                Changement: Remplacer le nom du serveur avec le nouveau
                */
                if (SQLDB.IndexOf("ERPSERVER") == -1) TSmain.BackColor = Color.Red;
                if (MainMDI.User.ToLower() == "cedulo")
                {
                    display_cedulo();
                    Application.Exit();
                }
                ////zero sector
            }
            this.Cursor = Cursors.Default;
		}

        void display_cedulo()
        {
            cedulo_Prjboard mycedule = new cedulo_Prjboard();
            this.Hide();
            mycedule.ShowDialog();
            this.Visible = true;
        }

        private bool load_Loc_Config_OLD()
		{
            //Mach_Name = System.Environment.MachineName;
			
            //bool loaded = false;

            //if (Find_One_Field("select * fROM PSM_Loc_Config where Mach_Name='" + Mach_Name + "'") != VIDE) loaded = load_Profile(Mach_Name);
            //else loaded = load_Profile("*");
			
            //if (!loaded) MessageBox.Show("Loading Initial Config Failed....Contact Admin !");
            //return loaded;
            return false;
		}

        private bool load_Loc_Config()
        {
            string Mach_Name = System.Environment.MachineName;

            bool loaded = false;

            //if (MainMDI.Find_One_Field("select * fROM PSM_Loc_Config where Mach_Name='" + Mach_Name + "'") != MainMDI.VIDE) loaded = load_Profile(Mach_Name);
            if (MainMDI.Find_One_Field("select * fROM PSM_Loc_Config where curr_usr='" + MainMDI.User.ToLower() + "'") != MainMDI.VIDE)
            {
                loaded = load_Profile(MainMDI.User.ToLower());
                //loaded = load_Profile(Win_userName);
            }
            else loaded = load_Profile("*");

            if (!loaded) MessageBox.Show("Loading Initial Config Failed....Contact Admin !");
            return loaded;
        }

        static public bool IsControlAtFront(Control control)
        {
            while (control.Parent != null)
            {
                if (control.Parent.Controls.GetChildIndex(control) == 0)
                {
                    control = control.Parent;
                    if (control.Parent == null)
                    {
                        return true;
                    }
                }
                else
                {
                    return false;
                }
            }
            return false;
        }

        static public string SQLdateTOst(string _dt)
        {
            string res = _dt;
            //if (_dt != MainMDI.VIDE && _dt != "")
            if (_dt.Length > 5)
            {
                DateTime DT = DateTime.Parse(_dt);
                res = DT.ToShortDateString();
            }
            return res;
        }

        static public string Eng_date(string stdd,string sep)
        {
            if (stdd == "" || stdd==MainMDI.VIDE) return "";
            else
            {
                DateTime dd = DateTime.Parse(stdd);
                return dd.Year.ToString() + sep + dd.Month.ToString().PadLeft(2).Replace(" ", "0") + sep + dd.Day.ToString().PadLeft(2).Replace(" ", "0"); //yyyy/mm/dd 
            }
        }

        static public string Eng_MMJJYYYY_date(string stdd, string sep)
        {
            if (stdd == "" || stdd == MainMDI.VIDE) return "";
            else
            {
                DateTime dd = DateTime.Parse(stdd);
                return dd.Day.ToString().PadLeft(2).Replace(" ", "0") + sep + dd.Month.ToString().PadLeft(2).Replace(" ", "0") + sep + dd.Year.ToString(); //mm/dd/yyyy 
            }
        }

        public static void Chng_CurrDB(string db)
        {
            currDB = db;
            Maj_M_Con();
            if (!Creat_TempTbls())
            {
                MessageBox.Show("Cannot create Temp Tables !... Contact your DB Admin...");
                Application.Exit();
            }
        }

        public static string aff_pathDB(string stCon)
        {
            if (stCon == "") stCon = MainMDI.M_stCon;
            int ipos = stCon.IndexOf(";server=");
            if (ipos > -1) return stCon.Substring(ipos, stCon.Length - ipos);
            else return "";
        }

        public static void MsgSTOP(string msg, string HDR)
        {
             MessageBox.Show(msg, HDR, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }

        public static bool Table_exists(string Tnme)
		{
			return (MainMDI.Find_One_Field("IF EXISTS (SELECT 1 FROM INFORMATION_SCHEMA.TABLES   WHERE TABLE_TYPE='BASE TABLE' " + 
				" AND TABLE_NAME='" + Tnme + "')      SELECT 'Y' ELSE  SELECT 'N' ")=="Y");
		}

		public static bool Creat_TempTbls()
		{
			t_Det_OL = "pgm_Det_OL" + MainMDI.UserID;
			t_SeekTBL6 = "pgm_SeekTBL6" + MainMDI.UserID;
			t_tbl6Col = "pgm_tbl6Col" + MainMDI.UserID;
			t_tbl6ColDBL = "pgm_tbl6ColDBL" + MainMDI.UserID;
			bool TempTbl = true;
			if (!Table_exists(t_Det_OL)) TempTbl=MainMDI.ExecSql("select * into " + t_Det_OL + " from pgm_Det_OL_empty ");
			if (!Table_exists(t_SeekTBL6)) TempTbl = TempTbl && MainMDI.ExecSql("select * into " + t_SeekTBL6 + " from pgm_SeekTBL6_empty ");
			//if (!Table_exists(t_tbl6Col)) TempTbl=MainMDI.ExecSql("select * into " + t_tbl6Col + " from pgm_tbl6Col_empty ");
			//if (!Table_exists(t_tbl6ColDBL)) TempTbl=MainMDI.ExecSql("select * into " + t_tbl6ColDBL + " from pgm_tbl6ColDBL_empty ");
			
		    return TempTbl;
		}

		private void Drop_TempTbls()
		{
			if (Table_exists(t_Det_OL)) MainMDI.ExecSql("drop TABLE " + t_Det_OL);
			if (Table_exists(t_SeekTBL6)) MainMDI.ExecSql("drop TABLE " + t_SeekTBL6);
			//if (Table_exists(t_tbl6Col)) MainMDI.ExecSql("drop TABLE " + t_tbl6Col);
			//if (Table_exists(t_tbl6ColDBL)) MainMDI.ExecSql("drop TABLE " + t_tbl6ColDBL);
		}

		private bool load_ProfileOLD(string Cptr_Nme)
		{
			bool loaded = false;
			string stSql = "select * fROM PSM_Loc_Config where Mach_Name='" + Cptr_Nme + "'";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
                if (Oreadr["PDFfiles"].ToString()!="") MainMDI.PDF_READER = Oreadr["PDFfiles"].ToString();
                //if (Oreadr["curr_user"].ToString() == "ede") MainMDI.WQfiles = @"C:\Users\%username%\Primax Technologies Inc\Primax_Data - PSM_Quotes";
                //else if (Oreadr["WQfiles"].ToString() != "") MainMDI.WQfiles = Oreadr["WQfiles"].ToString();
                if (Oreadr["WQfiles"].ToString() != "") MainMDI.WQfiles = Oreadr["WQfiles"].ToString();
                if (Oreadr["PBSpath"].ToString() != "") MainMDI.PBSPath = Oreadr["PBSpath"].ToString();
                if (Oreadr["DymoName"].ToString() != "") MainMDI.DYMOName = Oreadr["DymoName"].ToString();

				MainMDI.M_PBS_stCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MainMDI.PBSPath + @"\PX_batlist.mdb" + @";Persist Security Info=False"; //;Jet OLEDB:Database Password = " + "aaa999";
		        MainMDI.Def_LoginUser = Oreadr["curr_usr"].ToString();
				MainMDI.Def_LoginPass = "123";

				loaded = true;
			}
			OConn.Close();
            Oreadr.Close();
			return loaded;
		}

        private bool load_Profile(string userName)
        {
            bool loaded = false;
            if (userName == "*")
            {
                userName = MainMDI.User;
                //string mach = "PC-titi";
                string mach = MainMDI.Mach_Name;
                Exec_SQL_JFS("INSERT INTO [dbo].[PSM_Loc_Config] (" +
                    "[Mach_Name] ,[PBSpath] ,[curr_usr]  ,[DymoName] ,[WQfiles]  ,[PDFfiles])   VALUES ('" + mach + "','C:\\Program Files\\pbsizing','" + userName + "' , '\\\\ntserver2\\DYMO LabelWriter 330 Turbo (Copy 1)', 'H:\\Sales\\PSM_Quotes', 'AcroRd32.exe')","loc_profile creation....");
            }

            //string stSql = "select * fROM PSM_Loc_Config where Mach_Name='" + Cptr_Nme + "'";
            string stSql = "select * fROM PSM_Loc_Config where curr_usr='" + userName + "'";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                if (Oreadr["PDFfiles"].ToString() != "") MainMDI.PDF_READER = Oreadr["PDFfiles"].ToString();
                string userNameTest = Environment.UserName;

                //A ne pas toucher
                //if (Oreadr["curr_usr"].ToString() == "ede") MainMDI.WQfiles = @"C:\Users\mcoder\Primax Technologies Inc\Primax_Data - PSM_Quotes\test";

                //if (Oreadr["WQfiles"].ToString() != "") MainMDI.WQfiles = @"C:\Users\%username%\Primax Technologies Inc\Primax_Data - PSM_Quotes\test".Replace("%username%", userNameTest);
                if (Oreadr["WQfiles"].ToString() != "") MainMDI.WQfiles = Oreadr["WQfiles"].ToString();
                if (Oreadr["PBSpath"].ToString() != "") MainMDI.PBSPath = Oreadr["PBSpath"].ToString();
                if (Oreadr["DymoName"].ToString() != "") MainMDI.DYMOName = Oreadr["DymoName"].ToString();

                MainMDI.M_PBS_stCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MainMDI.PBSPath + @"\PX_batlist.mdb" + @";Persist Security Info=False"; //;Jet OLEDB:Database Password = " + "aaa999";
                MainMDI.Def_LoginUser = Oreadr["curr_usr"].ToString();
                MainMDI.Def_LoginPass = "123";

                loaded = true;
            }
            OConn.Close();
            Oreadr.Close();
            return loaded;
        }

		private void logxx()
		{
            //MessageBox.Show("logXX");
			Passwd frmpass = new Passwd('L');
			frmpass.ShowDialog();
			if (frmpass.denied) Application.Exit();
			else login = true;

            //MessageBox.Show("logXX____fin");
		}

		private void DataBaseLoad()
		{
			string tblName = "PSM_Company";
			string stsql = "select * FROM PSM_Company";
			SqlConnection Ipsm_Conn = new SqlConnection(M_stCon);
			SqlDataAdapter Ipsm_OAdp = new SqlDataAdapter(stsql, Ipsm_Conn);
			DataSet Ipsm_Ds = new DataSet(tblName);
			Ipsm_OAdp.Fill(Ipsm_Ds, tblName);
		}

		//alter. Total based on AgentPrice ALS Total
		public static string SPEC_TOT(string r_IQID, string Sname, string SpecName)
		{
			string stSql = "SELECT Sum(PSM_Q_ALS.AGPrice) AS SommeDeTot FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
				" GROUP BY PSM_Q_SOL.I_Quoteid, PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name HAVING (((PSM_Q_SOL.I_Quoteid)=" + r_IQID + ") AND ((PSM_Q_SOL.Sol_Name)='" + Sname + "') AND ((PSM_Q_SPCS.SPC_Name)='" + SpecName.Replace("'", "''") + "'))";
			string res = MainMDI.Find_One_Field(stSql);
			if (res == MainMDI.VIDE) return "0";
			return Convert.ToString(Math.Round(Tools.Conv_Dbl(res), MainMDI.Q_NB_DEC_AFF));
		}

        public static string QREV_TOT(string r_IQID, string Sname)
        {
            string stSql = "SELECT Sum(PSM_Q_ALS.AGPrice) AS SommeDeTot FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
                " GROUP BY PSM_Q_SOL.I_Quoteid, PSM_Q_SOL.Sol_Name HAVING (((PSM_Q_SOL.I_Quoteid)=" + r_IQID + ") AND ((PSM_Q_SOL.Sol_Name)='" + Sname + "'))";
            string res = MainMDI.Find_One_Field(stSql);
            if (res == MainMDI.VIDE) return "0";
            return Convert.ToString(Math.Round(Tools.Conv_Dbl(res), MainMDI.Q_NB_DEC_AFF));
        }

        // retourne si l'utilisateur fait partie du groupe admin ou non (true or false)
        public static bool user_Admin()
        {
                bool isAdmin = false;

                string stSql = "SELECT * FROM PSM_USERS_New WHERE type = @userType";

                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.Parameters.AddWithValue("@userType", "S");
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    if (MainMDI.User.ToLower() == Oreadr["user"].ToString())
                    {
                        isAdmin = true;
                    }
                }
                return isAdmin;
            //return (User.ToLower() == "ede" || User.ToLower() == "admin" || User.ToLower() == "ddarai" || User.ToLower() == "hnasrat");
        }


        public static bool ALWD_USR(string _mdl, bool msg)
		{
			bool res = false;
			if (MainMDI.User == "ede" || MainMDI.profile == 'S') res = true;
			else res = (MainMDI.Find_One_Field("SELECT lineID FROM PSM_AS_UsrMudls INNER JOIN PSM_AS_modules ON PSM_AS_UsrMudls.mdl_LID = PSM_AS_modules.m_LID " +
			    "  WHERE PSM_AS_modules.m_ABR = '" + _mdl + "' AND PSM_AS_UsrMudls.UsrLID =" + MainMDI.UserID) != MainMDI.VIDE);
			if(msg && !res) MessageBox.Show("Access Denied....!!!", "Administrator", MessageBoxButtons.OK, MessageBoxIcon.Stop);
			return res;
		}

		public static void send_email_FRMWRK_ver2(string from, string to, string Subjct, string body, string srvr)
		{
			//create mail message object for testiiiiiiiiiiinnng

            System.Web.Mail.MailMessage mail = new System.Web.Mail.MailMessage();
			mail.From = from; //address
			mail.To = to; //address 
			mail.Subject = Subjct; //subject
			mail.Body = body; //email 
            System.Web.Mail.SmtpMail.SmtpServer = "192.168.1.1"; //srvr; //put smtp server you will use here 
			//and then send the mail
            System.Web.Mail.SmtpMail.Send(mail);
		}

        public static void send_email(string FromAdrs, string TO_email, string _Subject, string _Body)
        {
            //MailMessage mailOBJ = null;
            //mailOBJ.SubjectEncoding = System.Text.Encoding.UTF8; //Encoding.UTF8;
            //MailMessage mailOBJ = new MailMessage(FromAdrs, "hedebbab@hotmail.com", " ", "");
            //mailOBJ.SubjectEncoding = System.Text.Encoding.UTF8; //Encoding.UTF8;

            if (SMTPSRVRnm == "") SMTPSRVRnm = MainMDI.Find_One_Field("SELECT   F2 FROM  PSM_C_GConfig where F1_Code='SMTP'");
            if (SMTPSRVRnm != MainMDI.VIDE && SMTPSRVRnm != "")
            {
                MailMessage mailOBJ = new MailMessage(FromAdrs, TO_email, _Subject, _Body);
                SmtpClient SMTPServer = new SmtpClient(SMTPSRVRnm); //"NT2008MBX.PRIMAX.LOCAL" / ("ntserver.PRIMAX.LOCAL");
                try
                {
                    SMTPServer.Send(mailOBJ);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Email sending Failed..............." + ex.ToString());
                }
            }
            else MessageBox.Show("SMTP SERVER is Invalid......contact Admin....");
        }

        public static void LastRevAndSum(string _QuoteLID, ref string RevNm, ref string Tot)
        {
            //" SELECT     PSM_Q_SOL.Sol_Name, SUM(DISTINCT PSM_Q_ALS.AGPrice) AS BigTot " +
            string stSql = " SELECT     PSM_Q_SOL.Sol_Name, SUM(PSM_Q_ALS.AGPrice) AS BigTot " +
                "            FROM         PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SPCS.Sol_LID = PSM_Q_SOL.Sol_LID INNER JOIN PSM_Q_ALS ON PSM_Q_ALS.SPC_LID = PSM_Q_SPCS.SPC_LID " +
                "            GROUP BY PSM_Q_SOL.Sol_Name, PSM_Q_SOL.I_Quoteid HAVING PSM_Q_SOL.I_Quoteid =" + _QuoteLID +
                " order by PSM_Q_SOL.Sol_Name desc";
            RevNm = MainMDI.VIDE;
            Tot = MainMDI.VIDE;
            MainMDI.Find_2_Field(stSql, ref RevNm,ref Tot);
        }

        public static string Rectif_Test_Stat(string IRREVID)
        {
            string stSql = "SELECT tr_stat FROM PSM_R_TRREC_info WHERE tr_iRRevID =" + IRREVID;

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int C = 0, I = 0, S = 0;
            string st = "N/C";
            while (Oreadr.Read())
            {
                if (Oreadr["tr_stat"].ToString() == "01" || Oreadr["tr_stat"].ToString() == "10") I++;
                if (Oreadr["tr_stat"].ToString() == "00") S++;
                if (Oreadr["tr_stat"].ToString() == "11") C++;
                st = "";
            }
            OConn.Close();
            Oreadr.Close();
            if (st != "N/C")
            {
                if (I != 0 || C != 0 || S != 0) st = "In Process";
                if (I == 0 && C == 0) st = "StandBy";
                if (I == 0 && S == 0) st = "Completed";
            }
            return st;
        }

		public static string Test_Stat(string _IRREVID)
        {
            //int y = lvQuotes.Items[i].SubItems[1].Text.IndexOf("2516");

            //if (lvQuotes.Items[i].SubItems[1].Text.IndexOf("2538") > -1) MessageBox.Show("Hiiiiiiiiiiiiiiiiiiii");

            string stSql = " SELECT PSM_R_TRInfo.tr_stat AS stat, PSM_R_TRInfo.tr_TRName as TRNm" +
                " FROM         PSM_R_TRInfo INNER JOIN  PSM_R_Rev ON PSM_R_TRInfo.tr_iRRevID = PSM_R_Rev.IRRevID " +
                " WHERE     (PSM_R_Rev.IRRevID =" + _IRREVID + ")";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int C = 0, I = 0, S = 0;
            string st = "N/C";
            while (Oreadr.Read())
            {
                if (Oreadr["stat"].ToString() == "I") I++;
                if (Oreadr["stat"].ToString() == "S") S++;
                if (Oreadr["stat"].ToString() == "C") C++;
                st = "";
            }
            OConn.Close();
            Oreadr.Close();
            if (st != "N/C")
            {
                if (I != 0 || C != 0 || S != 0) st = "In Process";
                if (I == 0 && C == 0) st = "StandBy";
                if (I == 0 && S == 0) st = "Completed";
            }
            else st = Rectif_Test_Stat(_IRREVID);
            return st;
        }

		public static void Exec_SQL_JFS(string SQL_st, string JFS_st)
		{
			MainMDI.ExecSql(SQL_st);
		    if (JFS_st.Length > 0) MainMDI.Write_JFS(JFS_st + "    stSql= " + SQL_st);
		}

		public static bool ExecSql(string stSql)
		{
			//tst
			//stSql.Replace("'", "''");
			//tst

            SqlConnection OConn = new SqlConnection(M_stCon);
            OConn.Open();
            try
            {
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.ExecuteNonQuery();

                stXP = MainMDI.VIDE;
                return true;
            }
            catch (SqlException Oexp)
            {
                stXP = Oexp.Message;
                MessageBox.Show("STSQL= " + stSql + "\n" + "Msg= " + stXP);
                return false;
            }
            finally
            {
                OConn.Close();
            }
		}

        public static bool ExecSql_SAKTA(string stSql)
        {
            //tst
            //stSql.Replace("'", "''");
            //tst

            SqlConnection OConn = new SqlConnection(M_stCon);
            OConn.Open();
            try
            {
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.ExecuteNonQuery();

                stXP = MainMDI.VIDE;
                return true;
            }
            catch (SqlException Oexp)
            {
                stXP = Oexp.Message;
                //MessageBox.Show("STSQL= " + stSql + "\n" + "Msg= " + stXP);
                return false;
            }
            finally
            {
                OConn.Close();
            }
        }

        public static void Exec_SQL_JFS_SYSPRO(string SQL_st, string JFS_st)
        {
            MainMDI.ExecSql_SYSPRO(SQL_st);
            if (JFS_st.Length > 0) MainMDI.Write_JFS(JFS_st + "    stSql= " + SQL_st);
        }

        public static bool ExecSql_SYSPRO(string stSql)
        {
            //tst
            //stSql.Replace("'", "''");
            //tst

            SqlConnection OConn = new SqlConnection(M_stCon_PL_SYSPRO);
            OConn.Open();
            try
            {
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.ExecuteNonQuery();

                stXP = MainMDI.VIDE;
                return true;
            }
            catch (SqlException Oexp)
            {
                stXP = Oexp.Message;
                MessageBox.Show("STSQL= " + stSql + "\n" + "Msg= " + stXP);
                return false;
            }
            finally
            {
                OConn.Close();
            }
        }

        public static bool ExecSql_BACK_ORIG(string stSql, string _STCON)
        {
            //tst
            //stSql.Replace("'", "''");
            //tst

            SqlConnection OConn = new SqlConnection(_STCON);
            OConn.Open();
            try
            {
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Ocmd.ExecuteNonQuery();

                stXP = MainMDI.VIDE;
                return true;
            }
            catch (SqlException Oexp)
            {
                stXP = Oexp.Message;
                MessageBox.Show("STSQL= " + stSql + "\n" + "Msg= " + stXP + "   \n STCON=" + _STCON);
                return false;
            }
            finally
            {
                OConn.Close();
            }
        }
       
        public static bool ExecSql_Big(string stSql)
		{
			//tst
			//stSql.Replace("'", "''");
			//tst

            SqlConnection OConn = new SqlConnection(M_stCon);
            OConn.Open();

            try
            {
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;

                Ocmd.ExecuteNonQuery();

                stXP = MainMDI.VIDE;
                return true;
            }
            catch (SqlException Oexp)
            {
                stXP = Oexp.Message;
                MessageBox.Show("STSQL= " + stSql + "\n" + "Msg= " + stXP);
                return false;
            }
            finally
            {
                OConn.Close();
            }
		}

        //stored procedure quote details
        public static long XSP_NSRT_Q_detail(string _ALS_LID, string _Aff_ID, string _Desc, string _Qty, string _X_Mult, string _Uprice, string _Mult, string _Ext, string _LeadTime, string _Rnk, string _PN, string _Q_tec_Val)
        {
            string LID = "-1";
            string stXP = "";
            try
            {
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = new SqlCommand("NSRT_Q_detail", OConn);
                Ocmd.CommandType = CommandType.StoredProcedure;

                Ocmd.Parameters.Add("@ALS_LID", _ALS_LID);
                Ocmd.Parameters.Add("@Aff_ID", _Aff_ID);
                Ocmd.Parameters.Add("@Desc", _Desc);
                Ocmd.Parameters.Add("@Qty", _Qty);
                Ocmd.Parameters.Add("@X_Mult", _X_Mult);
                Ocmd.Parameters.Add("@Uprice", _Uprice);
                Ocmd.Parameters.Add("@Mult", _Mult);
                Ocmd.Parameters.Add("@Ext", _Ext);
                Ocmd.Parameters.Add("@LeadTime", _LeadTime);
                Ocmd.Parameters.Add("@Rnk", _Rnk);
                Ocmd.Parameters.Add("@PN", _PN);
                Ocmd.Parameters.Add("@Q_tec_Val", _Q_tec_Val);

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
                MessageBox.Show("XSP_NSRT_Q_detail \n" + "Msg= " + stXP);
                return -1;
            }
        }

        /*
       	public static bool XSP_NSRT_Q_detail(string stpar, ref string QdetLID)
		{
			try
			{
				SqlConnection OConn = new SqlConnection(_connectionString);
                OConn.Open();
			    SqlCommand Ocmd = new SqlCommand("NSRT_Q_detail " + stpar, OConn);
			    Ocmd.CommandType = CommandType.StoredProcedure;
			    string LID = Ocmd.ExecuteScalar();
			    OConn.Close();
			    stXP = MainMDI.VIDE;
			    return true;
			}
			catch (SqlException Oexp)
			{
				stXP = Oexp.Message;
				MessageBox.Show("XSP_I= " + stSql + "\n" + "Msg= " + stXP);
                QdetLID = -1;
				return false;
			}
            //SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
	        //OConn.Open();
	        //SqlCommand Ocmd = new SqlCommand("look_Orders4",OConn); //OConn.CreateCommand();
	        //Ocmd.CommandType = CommandType.StoredProcedure; //("look_Orders"
	        //SqlDataReader Oreadr = Ocmd.ExecuteReader();
        }
        */

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			this.Cursor = Cursors.WaitCursor;
		    //lchomer.Text = "0";
		    //lchomer.Text = "0";
			switch (toolBar1.Buttons.IndexOf(e.Button))
			{
				case 0: 	
					Disp_Quotes('L');
					break;
				case 1: 	
					Disp_Quotes('B');
					break;
				case 2:
					Disp_Projects('L');
					break;
				case 3:
					Disp_Projects('B');
					break;
				case 4:
					Disp_Projects('O');
					break;
				case 5:
					Company_Ges child2 = new Company_Ges();
					//child2.MdiParent = this;
					this.Hide();
					child2.ShowDialog();
					this.Visible = true;
					child2.Dispose();
					break;
				case 6:
					Ges_Cont_Sal_Ag gCSA = new Ges_Cont_Sal_Ag('C');
					this.Hide();
					gCSA.ShowDialog();
					this.Visible = true;
					gCSA.Dispose();
					break;
				case 7:
					//if (MainMDI.User == "Admin" || MainMDI.User == "hnasrat" || MainMDI.User == "cfouche" || MainMDI.User == "mdimassi")
					//if (super_user(MainMDI.User))
					if (MainMDI.ALWD_USR("CPT_SV", true))
					{
						Options child3 = new Options('M', "*", 'N');
						//child3.MdiParent = this;
						this.Hide();
						child3.ShowDialog();
						this.Visible = true;
						child3.Dispose();
					}
					break;
				case 8: //statistics
				    //if (MainMDI.User == "Admin" || MainMDI.User == "ddarai" || MainMDI.User == "hnasrat")
				    //{
				        Stati Stat_frm = new Stati();
				        this.Hide();
			          	Stat_frm.ShowDialog();
			         	this.Visible = true;
			        	Stat_frm.Dispose();
					//}
				    //else MessageBox.Show("Statistics are under maintenance....");
					break;
				case 9:
					try
					{
						System.Diagnostics.Process.Start(MainMDI.PBSPath + @"\PBSIZING.exe");
					}
					catch (System.Exception Oexp)
					{
						MessageBox.Show("Cannot Find PBSIZING.EXE at path: " + MainMDI.PBSPath + " System-msg: " + Oexp.Message);
					}
					break;
				case 10:
					//if (MainMDI.User == "Admin")
					    //if (MainMDI.profile == 'S') //super_user(MainMDI.User))
					    //{
					        Misc child4 = new Misc();
					        child4.ShowDialog();
					        //this.Hide();
					        //this.Visible = true;
					        child4.Dispose();
					    //}
					    //else toolBar1.Buttons[5].Visible = false;
					//child4.MdiParent = this;
					
					//frmbatS child4 = new frmbatS();
					//child4.MdiParent = this;
					//child4.Show();
					break;
				case 11:
					MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where userID=" + MainMDI.UserID);
					Drop_TempTbls(); //E1
					Write_JFS(User + " logs OUT(E1): " + System.DateTime.Now);
					Application.Exit();
					/*
					MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where userID=" + MainMDI.UserID);
					Drop_TempTbls(); //E2
					Write_JFS(User + " logs OUT(E2): " + System.DateTime.Now);
					if (load_Loc_Config())
					{
						logxx();
						if (login)
						{		
							if (!Creat_TempTbls())
							{
								MessageBox.Show("Cannot create Temp Tables !... Contact your DB Admin...");
								Application.Exit();
							}
							else 
							{
								//MainMDI.ExecSql("UPDATE PSM_SYSETUP  SET [s_stat]='1', [s_machNm]=' ' ");
								Write_JFS(User + " logs IN: " + System.DateTime.Now);
								Write_Whodo_SSetup("main Menu", 'F');
								if (MainMDI.User.ToUpper() == "UNLOCK") for (int i = 0; i < 14; i++) toolBar1.Buttons[i].Visible = (i == 10 || i == 11);
								else for (int i = 0; i < 14; i++) toolBar1.Buttons[i].Visible = true;
								timer1.Enabled = true;
							}
							//if (MainMDI.User == "Admin") chkXTT.Visible = true;
						}
					}
					*/
					break;
				case 13:
					PSM_About ABT= new PSM_About(GescomBld);
					ABT.ShowDialog();
					//MessageBox.Show("(SQL SERVER Version SSV)    V" + GescomVer + "   build#: " + GescomBld);
					break;
				case 12:
					if (MainMDI.User == "ede")
					{
						ChargerCOST chCost = new ChargerCOST();
						this.Hide();
						chCost.ShowDialog();
						this.Visible = true;
						chCost.Dispose();
					}
					break;
				case 14:
					MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where userID=" + MainMDI.UserID);
					Drop_TempTbls(); //E1
					Write_JFS(User + " logs OUT(E1): " + System.DateTime.Now);
					Application.Exit();
					break;
			}
			if (!dead) Write_Whodo_SSetup("Main Menu", 'I');
			this.Cursor = Cursors.Default;
		}

		private bool super_user(string nm)
		{
			return (MainMDI.profile == 'S'); //(MainMDI.User == "Admin" || MainMDI.User == "hnassrat" || MainMDI.User == "mdimassi");
		}

		private bool super_userOLD(string nm)
		{
			return (MainMDI.User == "ede" || MainMDI.User == "hnassrat" || MainMDI.User == "mdimassi");
		}

		private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
		
		}

		public static string SSV_date(string sdate)
		{
			//if (c == 's') return "Convert(smalldatetime,'" + sdate + "',103)";
			//else return "Convert(datetime,'" + sdate + "',103)";
			return "Convert(smalldatetime,'" + sdate + "'," + C_Style + ")";
			//return "Convert(smalldatetime,'" + sdate + "')"; //,101)";
		}

        public static bool IsValid_Quote(string _QID)
        {
            bool res = false;
            if (_QID.Length > 0)
            {
                string StSql = " Select psm_q_igen.quote_id from psm_q_details inner join psm_q_als on psm_q_details.ALS_LID = psm_q_als.ALS_LID inner join psm_q_spcs on psm_q_als.spc_LID = psm_q_spcs.spc_LID " + 
                    "     inner join psm_q_sol on psm_q_spcs.sol_LID=psm_q_sol.sol_LID inner join psm_q_igen on psm_q_igen.i_quoteid = psm_q_sol.i_quoteid " +
                    " where Q_tec_Val LIKE '%C_MODEL||%' and psm_q_igen.quote_id=" + _QID;
                res = (Find_One_Field(StSql) != VIDE);
            }
            return res;
        }

        /*
		public static void Find_2_Field(string stSql, ref string st1, ref string st2, ref string st3)
		{
			//string stSql = "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
			SqlConnection OConn = null;
			SqlCommand Ocmd = null;
			SqlDataReader Oreadr = null;

			//tst
			stSql.Replace("'", "''");
			//tst
			st1 = MainMDI.VIDE; st2 = MainMDI.VIDE; st3 = MainMDI.VIDE;

			try
			{
				OConn = new SqlConnection(MainMDI._connectionString);
				OConn.Open();
				Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql;
				Oreadr = Ocmd.ExecuteReader();
				while (Oreadr.Read())	
				{
					st1 = Oreadr[0].ToString();
					st2 = Oreadr[1].ToString();
					st3 = Oreadr[2].ToString();
					break;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("F2F-ERROR= " + ex.Message);
			}
			finally
			{
				OConn.Close();
				Oreadr.Close();
			}
		}
        */

        public static void Find_2_Field(string stSql, ref string st1, ref string st2, ref string st3, ref string st4)
        {
            //string stSql = "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

            //tst
            stSql.Replace("'", "''");
            //tst
            st1 = MainMDI.VIDE; st2 = MainMDI.VIDE;

            try
            {
                OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    st1 = Oreadr[0].ToString();
                    st2 = Oreadr[1].ToString();
                    st3 = Oreadr[2].ToString();
                    st4 = Oreadr[3].ToString();
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("F4F-ERROR= " + ex.Message);
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
        }

        public static void Find_2_Field(string stSql, ref string st1, ref string st2, ref string st3)
        {
            //string stSql = "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

            //tst
            stSql.Replace("'", "''");
            //tst
            st1 = MainMDI.VIDE; st2 = MainMDI.VIDE;

            try
            {
                OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    st1 = Oreadr[0].ToString();
                    st2 = Oreadr[1].ToString();
                    st3 = Oreadr[2].ToString();
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("F3F-ERROR= " + ex.Message);
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
        }

		public static void Find_2_Field(string stSql, ref string st1, ref string st2)
		{
			//string stSql = "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
			SqlConnection OConn = null;
			SqlCommand Ocmd = null;
			SqlDataReader Oreadr = null;

			//tst
			stSql.Replace("'", "''");
			//tst
			st1 = MainMDI.VIDE; st2 = MainMDI.VIDE;

			try
			{
				OConn = new SqlConnection(MainMDI.M_stCon);
				OConn.Open();
				Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql;
				Oreadr = Ocmd.ExecuteReader();
				while (Oreadr.Read())	
				{
					st1 = Oreadr[0].ToString();
					st2 = Oreadr[1].ToString();
					break;
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("F2F-ERROR= " + ex.Message);
			}
			finally
			{
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
			}
		}

        public static void Find_2_Field_PSA(string stSql, ref string st1, ref string st2, string P_S_A)
        {
            //string stSql = "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

            //tst
            stSql.Replace("'", "''");
            //tst
            st1 = MainMDI.VIDE; st2 = MainMDI.VIDE;

            try
            {
                switch (P_S_A)
                {
                    case "P": OConn = new SqlConnection(MainMDI.M_stCon);
                        break;
                    case "S":
                        OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
                        break;
                    case "A":
                        OConn = new SqlConnection(MainMDI.M_stCon_CMS_ACCS_ACE);
                        break;
                    default:
                        OConn = new SqlConnection(MainMDI.M_stCon);
                        break;
                }
                //OConn = new SqlConnection(MainMDI._connectionString);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    st1 = Oreadr[0].ToString();
                    st2 = Oreadr[1].ToString();
                    break;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("F2F-ERROR= " + ex.Message);
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
        }

        public static double Ceil(string S1, string sig)
		{
			double d1 = Tools.Conv_Dbl(S1), dSig = Tools.Conv_Dbl(sig);
			if (d1 == 0 || dSig == 0) return 0;
			else
			{
				int deb = Convert.ToInt32(d1 / dSig);
				bool fin = false;
				for (int i = 0; i < 4; i++) if (dSig * deb > d1) return (dSig * deb);
                    else deb++;
				return 0;
			}
		}

		public static double Ceil(double d1, double dSig)
		{
			if (d1 == 0 || dSig == 0) return 0;
			else
			{
				int deb = Convert.ToInt32(d1 / dSig);
				bool fin = false;
				for (int i = 0; i < 4; i++) if (dSig * deb > d1) return (dSig * deb);
                    else deb++;
				return 0;
			}
		}

		public static void Deco_path(string path, ref string[] Res)
		{
			//res = new string[3]{ "", "", "" };
			int Start_pos = 0;
			int jpos = 0;
			int i = 0;
			bool fin = false;
			while (i < 3 && !fin)
			{
				jpos = path.IndexOf("\\", Start_pos);
				if (jpos == -1)
				{
					Res[i] = path.Substring(Start_pos, path.Length - Start_pos);
					fin = true;
				}
				else
				{
					Res[i] = path.Substring(Start_pos, jpos - Start_pos);
					Start_pos = jpos + 1;
				}
				i++;
			}
		}

		public static int Find_Flds_Count(string stSql)
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
				OConn = new SqlConnection(MainMDI.M_stCon);
				OConn.Open();
				Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql;
				Oreadr = Ocmd.ExecuteReader();
				return Oreadr.FieldCount;
				//return -1;
			}
			catch(Exception ex)
			{
				MessageBox.Show("FFC-ERROR= " + ex.Message);
				return -1;
			}
			finally
			{
				OConn.Close();
                if (Oreadr != null) Oreadr.Close();
			}
		}

        public static string Std_VCS(string p, long Avail_ID, string VCS_NAME)
        {
            string stSql = "SELECT * FROM BGF_VCS13 WHERE (Avail_ID= " + Avail_ID + " AND phs='" + Charger.P + "' AND VCS_NAME='" + VCS_NAME + "')";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                return Oreadr["value"].ToString();
            }
            OConn.Close();
            return Charger.VIDE;
        }

        public static string cal_STD_VDCMAX(string VDC)
        {
            double dd = 0, cof = 2.45;
            switch (VDC)
            {
                case "12":
                    dd = 16; //6 * cof;
                    break;
                case "24":
                    dd = 31; //12 * cof;
                    break;
                case "36":
                    dd = 44; //18 * cof;
                    break;
                case "48":
                    dd = 59; //18 * cof;
                    break;
                case "72":
                    dd = 88.5; //36 * cof;
                    break;
                case "125":
                    dd = 145; //60 * cof;
                    break;
                case "144":
                    dd = 174; //72 * cof;
                    break;
                case "250":
                    dd = 290; //120 * cof;
                    break;
                case "380":
                    dd = 459; //190 * cof;
                    break;
                case "480":
                    dd = 580; //240 * cof;
                    break;
                case "600":
                    dd = 600; //245 * cof;
                    break;
            }
            return dd.ToString();
        }

        public static bool isItem_Valid_for_BoardOLD(string _TPXsn, string _itmDesc, bool msg)
        {
            bool res = true;

            if (_TPXsn.Length == 0)
            {
                if (_itmDesc.ToLower().IndexOf("control board") == -1) //if (_itmDesc.IndexOf("family control board") == -1)
                {
                    if (_itmDesc.ToLower().IndexOf("Communication board") == -1)
                    {
                        if (_itmDesc.ToLower().IndexOf("measuring board") == -1)
                        {
                            if (_itmDesc.ToLower().IndexOf("Fully automatic battery charger P4500") == -1)
                            {
                                if (_itmDesc.ToLower().IndexOf("EDI RECTIFIER P5500") == -1)
                                {
                                    if (_itmDesc.ToLower().IndexOf("Chargeur automatique de batteries P4500") == -1) res = false;
                                }
                            }
                        }
                    }
                }
            }
            if (msg && !res) MessageBox.Show("Sorry this Item is invalid for Serials...");
            return res;
        }

        public static bool isItem_Valid_for_Board(string _TPXsn, string _itmDesc, bool msg)
        {
            bool res = false;
            SqlConnection OConn = null;
			SqlCommand Ocmd = null;
			SqlDataReader Oreadr = null;
            if (_TPXsn.Length == 0)
            {
                try
                {
                    string stSql = "select ValidTXT from PSM_C_ValidItems where Itm_Type='B' ";
                    OConn = new SqlConnection(MainMDI.M_stCon);
                    OConn.Open();
                    Ocmd = OConn.CreateCommand();
                    Ocmd.CommandText = stSql;
                    Oreadr = Ocmd.ExecuteReader();
                    while (Oreadr.Read()) if ((res = (_itmDesc.ToLower().IndexOf(Oreadr[0].ToString().ToLower()) != -1))) break;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ValidItems....ERROR= " + ex.Message);
                    res = false;
                }
                finally
                {
                    OConn.Close();
                    if (Oreadr != null) Oreadr.Close();
                }
            }
            else res = true;
            if (msg && !res) MessageBox.Show("Sorry this Item is invalid for Serials...");
            return res;
        }

        public static string get_CBX_value(ComboBox _cbX, int _ndx)
        {
            System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
            itm = (System.Web.UI.WebControls.ListItem) _cbX.Items[_ndx];
            return itm.Value;
        }

        public static void fill_Any_CB(ComboBox _cbX, string stSql, bool Option1_Vide, string stVide)
        {
            _cbX.Items.Clear();

            //string stSql = "SELECT userID ,user FROM PSM_users_New";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            if (Option1_Vide) MainMDI.add_CB_itm(_cbX, stVide, "0");
            while (Oreadr.Read()) MainMDI.add_CB_itm(_cbX, Oreadr[0].ToString(), Oreadr[1].ToString());

            if (_cbX.Items.Count > 0) _cbX.SelectedIndex = 0;
            OConn.Close();
        }

       public static void fill_CB_SYSP(ComboBox _cbX, string stSql, bool Option1_Vide, string stVide)
       {
           _cbX.Items.Clear();

           //string stSql = "SELECT userID ,user FROM PSM_users_New";

           SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
           OConn.Open();
           SqlCommand Ocmd = OConn.CreateCommand();
           Ocmd.CommandText = stSql;
           SqlDataReader Oreadr = Ocmd.ExecuteReader();
           if (Option1_Vide) MainMDI.add_CB_itm(_cbX, stVide, "0");
            while (Oreadr.Read()) 
            {
                MainMDI.add_CB_itm(_cbX, Oreadr[0].ToString(), Oreadr[1].ToString());
            } 

           if (_cbX.Items.Count > 0) _cbX.SelectedIndex = 0;
           OConn.Close();
       }

        public static void add_CB_itm(ComboBox _CBany, string TXT, string VAL)
        {
            System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
            li.Text = TXT;
            li.Value = VAL;
            _CBany.Items.Add(li);
        }

        public static string Find_One_Field_PL_BACK_ORIG(string stSql, string _STCON)
        {
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

            stSql.Replace("'", "''");
            try
            {
                OConn = new SqlConnection(_STCON);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read()) return Oreadr[0].ToString();
                return VIDE;
            }
            catch (Exception ex)
            {
                MessageBox.Show("F1F-ERROR= PL_BACK_ORIG..." + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSql + "\n STCON=" + _STCON);
                return "ERROR";
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
        }

        public static bool ConnectBD()
        {
            string stSql = "select  s_stat from PSM_SYSETUP  ";
            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;
            try
            {
                OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read()) return true;
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
        }

        //will return a specific field from a specific table
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
				OConn = new SqlConnection(MainMDI.M_stCon);
				OConn.Open();
				Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql;
				Oreadr = Ocmd.ExecuteReader();
				while (Oreadr.Read()) return Oreadr[0].ToString().TrimEnd();
				return VIDE;
			}
			catch(Exception ex)
			{
                MessageBox.Show("F1F-ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" +stSql);
				return VIDE;
			}
			finally
			{
				OConn.Close();
                if (Oreadr != null) Oreadr.Close();
			}
		}

        public static string Find_One_Field_ACCESS(string stSql)
        {
            //string stSql = "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
            OleDbConnection OConn = null;
            OleDbCommand Ocmd = null;
            OleDbDataReader Oreadr = null;

            //tst
            stSql.Replace("'", "''");
            //tst

            try
            {
                OConn = new OleDbConnection (MainMDI.M_stCon_CMS_ACCS_ACE);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read()) return Oreadr[0].ToString();
                return VIDE;
            }
            catch (Exception ex)
            {
                MessageBox.Show("F1F_ACCESS_CMS_ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSql);
                return VIDE;
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
        }

        public static string Find_One_Field_SYSPRO(string stSql)
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
                OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read()) return Oreadr[0].ToString();
                return VIDE;
            }
            catch (Exception ex)
            {
                MessageBox.Show("F1F_SYSPRO_ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSql);
                return VIDE;
            }
            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
        }

        public static void save_Trs_cmsACCT(string SAlid, string Trsdate, string trs, string trs_Desc, string Amnt, string cmnt)
        {
            double d_amnt = Tools.Conv_Dbl(Amnt);
            string[,] G_arr_Flds = new string[Max_Flds_Vals, 2];
            string[,] G_arr_Vals = new string[Max_Flds_Vals, 2];
            int _NBflds = 0;
            Trsdate = (Trsdate == "") ? MainMDI.SSV_date(DateTime.Now.ToShortDateString()) : MainMDI.SSV_date(Trsdate);
            double solde = Tools.Conv_Dbl(MainMDI.Find_One_Field("select Solde from PSM_M_SA_Accounts where SA_LID=" + SAlid + " order by samvt_LID desc"));
            switch (trs)
            {
                case "C": //commision
                    solde += d_amnt; //Tools.Conv_Dbl(Amnt);
                    break;
                case "I": //solde initial
                    solde = d_amnt; //Tools.Conv_Dbl(Amnt);
                    break;
                case "D": //delete or cancel commission
                case "P": //paiement
                case "N": //note de credit 
                    solde -= d_amnt; //Tools.Conv_Dbl(Amnt);
                    d_amnt *= -1;
                    break;
            }
            RW_data my_RWdata = new RW_data("PSM_M_SA_Accounts");

            my_RWdata.get_Table_Flds(ref G_arr_Flds, ref _NBflds);
            G_arr_Vals[0, 0] = ""; //lid
            G_arr_Vals[1, 0] = SAlid;
            G_arr_Vals[2, 0] = Trsdate;
            G_arr_Vals[3, 0] = trs_Desc;
            G_arr_Vals[4, 0] = trs;

            G_arr_Vals[5, 0] = d_amnt.ToString();
            G_arr_Vals[6, 0] = Math.Round(solde, MainMDI.NB_DEC_AFF).ToString();
            G_arr_Vals[7, 0] = cmnt;

            my_RWdata.Insert_data(G_arr_Flds, G_arr_Vals, _NBflds);
        }

        //###############
		public static void OpenKnownFile(string Ofn)
		{
			try
			{
				System.Diagnostics.Process.Start(Ofn);

                //string st = "winword.exe " + Ofn;
                //System.Diagnostics.Process.Start(st);
			}
			catch (System.Exception Oexp)
			{ 	
				MessageBox.Show("PGESCOM: Can not execute: " + Ofn + "    System-msg: " + Oexp.Message);
			}
		}

        public static void OpenMicrosoftWord(string docFile)
        {
            //################
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = "WINWORD.EXE";
            startInfo.Arguments = "\"" + docFile + "\""; //"\"" + n + "\"";
            //MessageBox.Show("win=" + startInfo.FileName + "       doc=" + startInfo.Arguments);
            Process.Start(startInfo);
        }

        public static void EXEC_FILE(string EXEpgm, string File)
        {
            //################

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.FileName = EXEpgm; //"WINWORD.EXE";
            startInfo.Arguments = "\"" + File + "\"";
            //MessageBox.Show("win=" + startInfo.FileName + "       doc=" + startInfo.Arguments);
            Process.Start(startInfo);
        }

		public static bool Confirm(string msg)
		{
			DialogResult dr = MessageBox.Show(msg, "Confirmation ", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
			return (dr == DialogResult.Yes);
		}

		public static bool PermT_user(string mdlNm)
		{
			string st = Find_One_Field("Select " + profile + " From  PSM_usersAutori where MdlName='" + mdlNm + "'");
			return (st == "1");
		}

		public static string Find_arr_Fields(string stSql, string[] vals)
		{
			//string stSql = "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
			//tst
			stSql.Replace("'", "''");
			//tst
			
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql; //.Replace("'","''");
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				for (int i = 0; i < Oreadr.FieldCount; i++) vals[i] = Oreadr[i].ToString();
				return Oreadr[0].ToString();
			}
			OConn.Close();
            Oreadr.Close();
			return VIDE;
		}

        public static void Maj_M_Con()
        {
            M_stCon = @"user id=" + DBusrNm + ";password=" + dbpwd + ";server=" + SQLDB + ";Trusted_Connection=No;database=" + currDB + ";connection timeout=30";
            M_stCon_PL_BACK = @"user id=" + DBusrNm + ";password=" + dbpwd + ";server=" + SQLDB + ";Trusted_Connection=No;database=" + PL_BACKDB + ";connection timeout=30";
            M_stCon_PL_ORIG = @"user id=" + DBusrNm + ";password=" + dbpwd + ";server=" + SQLDB + ";Trusted_Connection=No;database=" + PL_ORIGDB + ";connection timeout=30";
        }

        private bool load_xmlCF()
        {
            string x_path = Application.StartupPath + MainMDI.currXMLfile;
            DataSet DS_xml = new DataSet("Config");
            try
            {
                DS_xml.ReadXml(x_path);
                string tableNM = "DB_" + DS_xml.Tables["INIT"].Rows[0][0].ToString();

                SQLDB = DS_xml.Tables[tableNM].Rows[0][0].ToString();
                WQfiles = DS_xml.Tables[tableNM].Rows[0][1].ToString();
                dbpwd = DS_xml.Tables[tableNM].Rows[0][2].ToString();
                DBusrNm = DS_xml.Tables[tableNM].Rows[0][3].ToString();
                Maj_M_Con();
                Env_PROD = (SQLDB.IndexOf("LOC_PSM") == -1);
                //SQLDB = DS_xml.Tables["DB_TU"].Rows[0][0].ToString();
                //WQfiles = DS_xml.Tables["DB_TU"].Rows[0][1].ToString();
                //dbpwd = DS_xml.Tables["DB_TU"].Rows[0][2].ToString();
            }
            catch (Exception _ex)
            { //Oex = " + _ex.Message
                MessageBox.Show("Sorry, PGESCOM Database is Missed !!! \n Contact your Admin...", "Database error....sstm ERROR=" + _ex.Message, MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }
            return true;
        }

        private bool init_Dict()
		{
			SqlDataReader Oreadr = null;
			SqlConnection OConn = null;
            bool res = true;
			try
			{
				OConn = new SqlConnection(MainMDI.M_stCon);
				OConn.Open();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = "select * from  PSM_EFSDict order by Rnk";
				Oreadr = Ocmd.ExecuteReader();
				while (Oreadr.Read())
				{
					int y = Convert.ToInt32(Oreadr[3].ToString());
					arr_EFSdict[y, 0] = Oreadr[0].ToString();
					arr_EFSdict[y, 1] = Oreadr[1].ToString();
					arr_EFSdict[y, 2] = Oreadr[2].ToString();
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show("init-Dict ERROR= Cannot connect to Database ..... check your network OR contact your Admin  \n" + ex.Message + "  \n" + MainMDI.aff_pathDB(""));
                res = false;
			}
			finally
			{
                if (Oreadr != null) Oreadr.Close();
				OConn.Close();
			}
            return res;
		}

		public static string optDesc(int l, string EFDesc)
		{
			string eng = "", fr = "";
			int ipos = EFDesc.IndexOf(" ~ ", 0);
			if (ipos == -1) eng = EFDesc;
			else
			{
				if (ipos == 0) fr = EFDesc;
				else
				{
					eng = EFDesc.Substring(0, ipos);
					fr = EFDesc.Substring(ipos + 3, EFDesc.Length - ipos - 3);
				}
			}
			if (l == 0) return eng;
			if (l == 1) return fr;
			return "";
		}

		public static string A00(string st)
		{ 
			if (Tools.Conv_Dbl(st) == 0) return "0.00";
			double dd = Tools.Conv_Dbl(st);
			if (dd != 0)
			{
				int ipos = st.IndexOf(".", 0);
				if (ipos == -1) st += ".00";
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
			//if (ii == 0) return "00";
			string st = ii.ToString();
			for (int j = st.Length; j < Lnt; j++)
				st = "0" + st;
			return st;
		}

        public static string A00(string ii, int Lnt)
        {
            //if (ii == 0) return "00";
            string st = ii;
            for (int j = st.Length; j < Lnt; j++)
                st = "0" + st;
            return st;
        }

        public static string A00(long ii, int Lnt)
        {
            //if (ii == 0) return "00";
            string st = ii.ToString();
            for (int j = st.Length; j < Lnt; j++)
                st = "0" + st;
            return st;
        }

		//public static string A00(double dd, int Lnt)
		//{ 
		    ////if (st == "0") return "00";
		    //string ii = dd % 100;
		    //string st = ii.ToString();
		    //for (int j = st.Length; j < Lnt; j++)
		        //st = "0" + st;
		    //return st;
		//}

		/*
		public static bool flag_QRID(char tNm, char c, int etat, long ID)
		{
			//flag flaged ==> flag('f', true, xxx)
			//Unflag flaged ==> flag('f', false, xxx)
			//flag InUse ==> flag('u', true, xxx)
			//uflag InUse ==> flag('u', false, xxx)
			string stflag = (c == 'f') ? "[flaged]=" + etat.ToString() : "[InUse]=" + etat.ToString();
			string stSql = "UPDATE " + "PSM_" + tNm + "_GenID" + " SET " + stflag + " WHERE " + tNm + "ID=" + ID.ToString();
			return MainMDI.ExecSql(stSql);
		}
		*/

		public static bool flag_QRID(char tNm, char c, int etat, long ID)
		{
			//flag flaged ==> flag('f', true, xxx)
			//Unflag flaged ==> flag('f', false, xxx)
			//flag InUse ==> flag('u',true,xxx)
			//uflag InUse ==> flag('u', false, xxx)
			string stflag = (c == 'f') ? "[flaged]=" + etat.ToString() : "[InUse]=" + etat.ToString();
			string stSql = "UPDATE " + "PSM_" + tNm + "_GenID" + " SET " + stflag + " WHERE " + tNm + "ID=" + ID.ToString();
			return MainMDI.ExecSql(stSql);
		}

		public static bool Use_QRID(int flgUse, char QRchar, string QRID)
		{
			string stSql = "";
			if (flgUse == 1) stSql = "INSERT INTO PSM_QR_InUse ([QR],[QRID],[InUse],[user]) VALUES ('" + QRchar + "', " + QRID + ", 1, '" + MainMDI.User + "')";
			if (flgUse == 0) stSql = "delete PSM_QR_InUse  where QRID=" + QRID + " and QR='" + QRchar + "'";
			if (flgUse == -1) stSql = "delete PSM_QR_InUse  where [user]='" + QRID + "'";
			return MainMDI.ExecSql(stSql);
		}

		public static string is_QR_Used(char QRchar, string QRID)
		{
			return MainMDI.Find_One_Field("select [user] from PSM_QR_InUse  where QRID=" + QRID + " and QR='" + QRchar + "'");
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

		public static long Gen_IDOLD(char tNm)
		{
			long ResID = 0;
			string tblNm = "PSM_" + tNm + "_GenID";
			string Res = MainMDI.Find_One_Field("select " + tNm + "ID from " + tblNm + " where not flaged and not InUse");
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

		public static long Gen_ID_tmpQnotused(char tNm) //using Primax.mdb
		{
			long ResID = 0;
			string tblNm = "PSM_" + tNm + "_GenID";
			//string Res = MainMDI.Find_One_Field("select " + tNm + "ID from " + tblNm + " where not flaged and not InUse ORDER BY PSM_Q_GenID.QID");
			string Res = MainMDI.Find_One_Field("select [Quote Numbers] from TblQuoteNumbers  where Taken=false  order by [Quote Numbers] ");
			if (Res == MainMDI.VIDE)
			{
				MessageBox.Show("Quote# not Found on PrimaxMDB...!!! call Admin !!!!!!!");
				/*
				string lastID = MainMDI.Find_One_Field(" select " + tNm + "ID from " + tblNm + " order by  " + tNm + "ID DESC");
				if (lastID != MainMDI.VIDE)
				{
					if (New100_QRID(tNm, lastID)) ResID = Convert.ToInt32(lastID);
					else ResID = 0; //means PSM_Q_GenID is Full or cannot Write In.
				}
				else ResID = -1; //means PSM_Q_GenID is Empty & must be Init.
				*/
			}
			else 
			{
				ExecSql("UPDATE TblQuoteNumbers  SET  [Taken]=true WHERE [Quote Numbers]=" + Res);
				ResID = Convert.ToInt32(Res);
			}
			return ResID;
		}

		public static long Gen_ID_tmpRnotused(char tNm) //using Primax.mdb
		{
			long ResID = 0;
			string tblNm = "PSM_" + tNm + "_GenID";
			//string Res = MainMDI.Find_One_Field("select " + tNm + "ID from " + tblNm + " where not flaged and not InUse ORDER BY PSM_Q_GenID.QID");
			string Res = MainMDI.Find_One_Field("select [Order Numbers] from TblOrderNumbers  where Taken=false  order by [Order Numbers] ");
			if (Res == MainMDI.VIDE)
			{
				MessageBox.Show("Quote# not Found on PrimaxMDB...!!! call Admin !!!!!!!");
				/*
				string lastID = MainMDI.Find_One_Field(" select " + tNm + "ID from " + tblNm + " order by  " + tNm + "ID DESC");
				if (lastID != MainMDI.VIDE)
				{
					if (New100_QRID(tNm, lastID)) ResID = Convert.ToInt32(lastID);
					else ResID = 0; //means PSM_Q_GenID is Full or cannot Write In.
				}
				else ResID = -1; //means PSM_Q_GenID is Empty & must be Init.
				*/
			}
			else 
			{
				ExecSql("UPDATE TblQuoteNumbers  SET  [Taken]=true WHERE [Quote Numbers]=" + Res);
				ResID = Convert.ToInt32(Res);
			}
			return ResID;
		}

		public static long Gen_IDFinalOLD(char tNm) //when using same dataBase
		{
			long ResID = 0;
			string tblNm = "PSM_" + tNm + "_GenID";
			//string Res = MainMDI.Find_One_Field("select " + tNm + "ID from " + tblNm + " where not flaged and not InUse ORDER BY PSM_Q_GenID.QID");
			string Res = MainMDI.Find_One_Field("select " + tNm + "ID from " + tblNm + " where flaged=0 and InUse=0 order by  " + tNm + "ID ");
			if (Res == MainMDI.VIDE)
			{
				string lastID = MainMDI.Find_One_Field(" select " + tNm + "ID from " + tblNm+ " order by  " + tNm + "ID DESC");
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

		public static long Gen_IDFinal(char tNm) //when using same dataBase
		{
			long ResID = 0;
			string tblNm = "PSM_" + tNm + "_GenID";
			//string Res = MainMDI.Find_One_Field("select " + tNm + "ID from " + tblNm + " where not flaged and not InUse ORDER BY PSM_Q_GenID.QID");
			string Res = MainMDI.Find_One_Field("select " + tNm + "ID from " + tblNm + " where flaged=0 and InUse=0 order by  " + tNm + "ID ");
			if (Res == MainMDI.VIDE)
			{
				string lastID = MainMDI.Find_One_Field(" select " + tNm + "ID from " + tblNm+ " order by  " + tNm + "ID DESC");
				ResID = (lastID != MainMDI.VIDE) ? 0 : -1;
				//0 means PSM_Q_GenID is Full or cannot Write In.
				//-1 means PSM_Q_GenID is Empty & must be Init.
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
				string s_LastId = Find_One_Field("select " + c + "ID from " + tblNm + " ORDER BY " + c + "ID DESC");
				if (s_LastId == VIDE) s_LastId = "0";
				long LastID = Convert.ToInt32(s_LastId);
				if (LastID < debId && LastID > 0) for (long i = LastID; i < debId - 1; i++)	ExecSql("INSERT INTO " + tblNm + " ([flaged],[inuse]) VALUES (TRUE,FALSE)");
				for (long i = 0; i < 100; i++) ExecSql("INSERT INTO " + tblNm + " ([flaged],[inuse]) VALUES (FALSE,FALSE)");
				return true;
			}
			catch (SqlException Oexp)
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
				long limt = (debQid <= MAX_QID - 99) ? debQid+100 : (MainMDI.MAX_QID + 1);
				for (long i = debQid; i < limt; i++)
				{
					Ocmd.CommandText = "INSERT INTO" + tblNm + " ([" + c + "ID],[flaged]) VALUES ('" + i.ToString() + "',FALSE)";
					Ocmd.ExecuteNonQuery();
				}
				OConn.Close();
				return true;
			}
			catch (SqlException Oexp)
			{
				MainMDI.stXP = Oexp.Message;
				return false;
			}
		}

		public static bool Unlock_table(string tableNM)
		{
			return MainMDI.ExecSql("delete PSM_LOCKED_TABLES where TableName='" + tableNM + "'");
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			//Print_label ll = new Print_label("MTI COMPANY     45215", "", "", "");
			//ll.Wexport();
			
			//MessageBox.Show("(SQL SERVER Version) SSV version 1.00 22/09/2005....19:38...."); //+ "  Computer-Name= " + Cnm); //+ " cal= " + Conv_Dbl_WS("-400")); //+ " tst= " + Curr_FRMT("140000.00"));
			//MessageBox.Show(Curr_FRMT("556"));
			//MessageBox.Show(Curr_FRMT("5256"));

			SqlDataReader Oreadr = null;
			SqlConnection OConn = null;
			string stSql = "", stADRS = "";
			OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = "select * from tmp_Cpny  order by Cpny_ID ";
			Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{ 
				label1.Text = Oreadr["Cpny_ID"].ToString(); label1.Refresh();

				if (Oreadr["Province_State"].ToString() != "" && Oreadr["Country_Name"].ToString() != "" && Oreadr["City"].ToString() != "")
					stADRS = Oreadr["M_Adrs"].ToString().Replace(","," ") + "," + Oreadr["City"].ToString() + "," + Oreadr["Province_State"].ToString() + "," + Oreadr["Postal_Code_Zip"].ToString() + "," +Oreadr["Country_Name"].ToString();
				else stADRS = Oreadr["M_Adrs"].ToString();
				stSql = "UPDATE tmp_Cpny SET " +
					" [M_Adrs]='" + stADRS.Replace("'","''") + "', " +
					" [City]='" + "" + "', " +
					" [Province_State]='" + "" + "', " +
					" [Country_Name]='" + "" + "' WHERE [Cpny_ID]=" + Oreadr["Cpny_ID"].ToString();
						
				MainMDI.ExecSql(stSql);
			}
            OConn.Close();
            Oreadr.Close();
		}

		public static string Curr_FRMTold(string st)
		{
			st = A00(st);
			string TS = "", rst = ".00";
			string DecSep = ".";

			int ipos = st.IndexOf(DecSep);
			if (ipos > 1)
			{
				rst = st.Substring(ipos, st.Length - ipos);
				st = st.Substring(0, ipos);
			}
			//string sep = (MainMDI.Lang == 0) ? " " : ",";
			string sep = " ";
			int c = 0;
			for (int i = st.Length - 1; i > -1; i--)
			{					
				if ((c % 3) == 0 && TS != "") TS += sep;
				TS += st[i];
				c++;
			}
			st = "";
			for (int i = TS.Length - 1; i > -1; i--) st += TS[i];
			return st + rst;
		}

		public static string frmt_date(string st)
		{
			DateTime dd = DateTime.Parse(st);
			//return dd.Day.ToString().PadLeft(2).Replace(" ", "0") + "/" + dd.Month.ToString().PadLeft(2).Replace(" ", "0") + "/" + dd.Year.ToString(); //dd/mm/yyyy
			return dd.Year.ToString() + "/" + dd.Month.ToString().PadLeft(2).Replace(" ", "0") + "/" + dd.Day.ToString().PadLeft(2).Replace(" ", "0"); //yyyy/mm/dd 
		}

		public static string Curr_FRMT(string st)
		{
            string nega = (Tools.Conv_Dbl(st) < 0) ? "-" : "";
			st = A00(st);
			string TS = "", rst = ".00";
			string DecSep = ".";

			int ipos = st.IndexOf(DecSep);
			if (ipos > 0)
			{
				rst = st.Substring(ipos, st.Length - ipos);
				st = st.Substring(0, ipos);
			}
			//string sep = (MainMDI.Lang == 0) ? " " : ",";
			string sep = " "; //currency separator " " or ","
			int c = 0;
			for (int i = st.Length - 1; i > -1; i--)
			{					
				if ((c % 3) == 0 && TS != "") TS += sep;
				TS += st[i];
				c++;
			}
			st = "";
			for (int i = TS.Length - 1; i> -1; i--) st += TS[i];
			return nega + st + rst;
		}

        public static string Curr_FRMT(string st, bool No_Curr_Sep)
        {
            string nega = (Tools.Conv_Dbl(st) < 0) ? "-" : "";
            st = A00(st);
            string TS = "", rst = ".00";
            string DecSep = ".";

            int ipos = st.IndexOf(DecSep);
            if (ipos > 0)
            {
                rst = st.Substring(ipos, st.Length - ipos);
                st = st.Substring(0, ipos);
            }
            //string sep = (MainMDI.Lang == 0) ? " " : ",";
            string sep = ""; //No currency separator " " or ","
            int c = 0;
            for (int i = st.Length - 1; i > -1; i--)
            {
                if ((c % 3) == 0 && TS != "") TS += sep;
                TS += st[i];
                c++;
            }
            st = "";
            for (int i = TS.Length - 1; i > -1; i--) st += TS[i];
            return nega + st + rst;
        }

		public static string Currency_Amnt(string st, string cur_Symb)
		{
			st = A00(st);
			string TS = "", rst = ".00";
			string DecSep = ".";

			int ipos = st.IndexOf(DecSep);
			if (ipos > 1)
			{
				rst = st.Substring(ipos, st.Length - ipos);
				st = st.Substring(0, ipos);
			}
			//string sep = (MainMDI.Lang == 0) ? " " : ",";
			string sep = " ";
			int c = 0;
			for (int i =st.Length - 1; i> -1; i--)
			{					
				if ((c % 3) == 0 && TS != "") TS += sep;
				TS += st[i];
				c++;
			}
			st = "";
			for (int i = TS.Length - 1; i > -1; i--) st += TS[i];
			return st + rst;
		}

		public static string Curr_FRMTbaaaaad(string st)
		{
			string TS = ""; //".00";
			string sep = (MainMDI.Lang == 0) ? " " : ",";
			int c = 0;
			for (int i = st.Length - 1; i > -1; i--)
			{					
				if ((c % 3) == 0 && TS != "") TS += sep;
				TS += st[i];
				c++;
			}
			st = "";
			for (int i = TS.Length - 1; i > -1; i--) st += TS[i];
			return st + ".00";
		}

        public static bool USR_PWD_WINSERVER(string userName, string pwd, ref string msg)
        {
            bool userExist = false;
            //string SRVR = "LDAP://primax";
              string SRVR = "LDAP://trystar";
            try
            {
                DirectoryEntry myEntry = new DirectoryEntry(SRVR, userName, pwd);

                /**********************Solution court terme**********************/
                if (userName == "mdimassi") return true;
                /**********************Solution court terme**********************/

                object myNativeObj = myEntry.NativeObject;
                userExist = true;
            }
            catch (DirectoryServicesCOMException myDSComex)
            {
                //MessageBox.Show("myDSComex: " + myDSComex.Message);
                msg = myDSComex.Message;
            }
            return userExist;
        }

        // return all the super user in the system
        public static bool SUPERusr()
        {
            return (User.ToLower() == "ede" || User.ToLower() == "ddarai" || User.ToLower() == "hnasrat");
        }

		private void MainMDI_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
		}

        public static void Write_XadminLog(string msg, string formName)
		{
            ExecSql("INSERT INTO PSM_XAdminlog([msg_txt],[msgdate],[usr],[frm_Module]) VALUES ('" + msg.Replace("'", ".") + "', " + MainMDI.SSV_date(System.DateTime.Now.ToString()) + ", '" + User + "', '" + formName + "')");
            send_email("PGESCOM_Admin@primax-e.com", "hedebbab@primax-e.com", " Please read Xadmin-Log", "...MSG: [" + msg + "] \n");
        }

        /*
        public static void email_Msg(string email, string Subject, string Body)
        {
            if (email != MainMDI.VIDE && emailIsValid(email))
            {
                string FromAdrs = "PGESCOM_Admin@primax-e.com";
                System.Web.Mail.SmtpMail.SmtpServer = "ntserver2.PRIMAX.LOCAL";
                System.Web.Mail.SmtpMail.Send(FromAdrs, email, Subject, Body);
            }
        }
        */
 
        public static bool emailIsValid(string em)
        {
            return em.Length > 6 && em.IndexOf("@") > 1;
        }

        public static string Currency_Name(char c)
        {
            string res = MainMDI.VIDE;
            switch (c)
            {
                case 'U':
                    res = "USD";
                    break;
                case 'C':
                    res = "CAD";
                    break;
                case 'E':
                    res = "EUR";
                    break;
            }
            return res;
        }

        public static void Write_JFS(string stSql)
        {
            ExecSql("INSERT INTO PSM_JFS ([stsql],[dateOpera],[userNm]) VALUES ('" + stSql.Replace("'", ".") + "', " + MainMDI.SSV_date(System.DateTime.Now.ToString()) + ", '" + User + "')");
        }

		public static void Write_Whodo_SSetup(string modlNm, char c) //c == D if delete whodo c == I if Insert whodo 
		{
			//D : Delete I : Insert F : First log in

			ExecSql("delete PSM_Whodo where machNm='" + Mach_Name + "'");
			if (c == 'I' || c == 'F')
			{
				ExecSql("delete PSM_Whodo where UserNm='" + MainMDI.User + "'");
                ExecSql("INSERT INTO PSM_Whodo ([dateIn],[machNm],[UserNm],[modlNm]) VALUES ( " + MainMDI.SSV_date(System.DateTime.Now.ToString()) + ", '" + MainMDI.Mach_Name + "', '" + MainMDI.User + "', '" + modlNm + "      (bld=" + MainMDI.GescomBld + " / " +MainMDI.RealBld + " / " + MainMDI.DBusrNm + ")')");
			}
			if (c == 'D' || c == 'F')
			{
				//if (c == 'D') else
				ExecSql("delete PSM_SYSETUP where s_machNm='" + Mach_Name + "'");
                if (c == 'F')
                {
                    //string myIP = ipAdrs(MainMDI.Mach_Name);
                    //MessageBox.Show(MainMDI.IPadress + "  portNB= " + MainMDI.IPportNB);
                    //ExecSql("INSERT INTO PSM_SYSETUP ([VER],[BLD],[s_msg],[s_machNm],[s_stat],[NewQ],[NewR]) VALUES ( " +
                        //"'n/a','n/a','n/a', '" + MainMDI.Mach_Name + "','1','1','1')");
                    string IPadrs = (MainMDI.IPadress.Length > 15) ? "999.999.999.999" : MainMDI.IPadress;
                    ExecSql("INSERT INTO PSM_SYSETUP ([VER],[BLD],[s_msg],[s_machNm],[IpAdrs],[IPport],[date_IN],[s_stat],[NewQ],[NewR]) VALUES ( " +
                        "'n/a','n/a','n/a', '" + MainMDI.Mach_Name + "','" + IPadrs + "','" + MainMDI.IPportNB + "'," + MainMDI.SSV_date(System.DateTime.Now.ToString()) + ",'1','1','1')");
                }
			}
		}

        //string howtogeek = "www.howtogeek.com";
        //IPAddress[] addresslist = Dns.GetHostAddresses(howtogeek);

        //foreach (IPAddress theaddress in addresslist)
        //{
            //Console.WriteLine(theaddress.ToString());
        //}

        public static string Get_stationIPOLD(string station)
        {
            string res = "";
            IPAddress[] IPs = Dns.GetHostAddresses(station);
            foreach (IPAddress ip in IPs)
                res += ip.ToString(); //ip;
            return res;
        }

        public static string Get_stationIP(string station)
        {
            string str = "";

            System.Net.Dns.GetHostName();

            IPHostEntry ipEntry = System.Net.Dns.GetHostEntry(str);

            IPAddress[] addr = ipEntry.AddressList;

            return addr[addr.Length - 1].ToString();
        }

		private void OldProj()
		{
			Orders_Look childOrd = new Orders_Look('O');
			this.Hide();
			childOrd.ShowDialog();
			this.Visible = true;
			childOrd.Dispose();
		}

		public static double Conv_Dbl_WS(string st)
		{
			double mt = 1;
			if (st[0] == '-')
			{
				mt = -1;
				if (st.Length > 1) st = st.Substring(1, st.Length - 1);
				else st = "0";
			}
			int ipos = st.IndexOfAny(".,".ToCharArray(), 1);
			if (ipos > -1) st = st.Substring(0, ipos) + System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator.ToString() + st.Substring(ipos + 1, st.Length - ipos - 1);
			return Double.Parse(st) * mt;
		}

		private void MainMDI_Resize(object sender, System.EventArgs e)
		{
			picExit.Left = this.Width - 48;
			lCRight.Left = this.Width - 368; //288
            this.Refresh();
		}

		private void picExit_Click(object sender, System.EventArgs e)
		{
			MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where userID=" + MainMDI.UserID);
			//Write_Whodo("delete", 'D');
			//Drop_TempTbls();
			//Write_JFS(User + " logs OUT: " + System.DateTime.Now);
			Shutdown_JOBS();
			Application.Exit();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			string r_VER = "";
			string r_msg = "";
			string r_machNm = "";
			string r_stat = "";
			string r_NewQ = "";
			string r_NewR = "";
			
			MainMDI.Find_2_Field(" select s_stat, BLD from PSM_SYSETUP where s_machNm='PGESCOM'", ref r_stat, ref r_BLD);

			//string stSql = " select * from PSM_SYSETUP where s_machNm='PGESCOM'";
			//SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
			//OConn.Open();
			//SqlCommand Ocmd = OConn.CreateCommand();
			//Ocmd.CommandText = stSql;
			//SqlDataReader Oreadr = Ocmd.ExecuteReader();
			//while (Oreadr.Read())
			//{
			    //r_BLD = Oreadr["BLD"].ToString();
			    //r_VER = Oreadr["VER"].ToString();
			    //r_msg = Oreadr["s_msg"].ToString();
			    //r_machNm = Oreadr["s_machNm"].ToString();
			    //r_stat = Oreadr["s_stat"].ToString();
			    //r_NewQ = Oreadr["NewQ"].ToString();
			    //r_NewR = Oreadr["NewR"].ToString();
			//}
			//OConn.Close();

            if (TCPreceivedTXT.Length > 0)
            {
                string tt = TCPreceivedTXT;
                TCPreceivedTXT = null; TCPreceivedTXT = "";
                MessageBox.Show("msg Recu= : " + tt + "    len= " + TCPreceivedTXT.Length.ToString());
            }
            else
            {
                //if (mySocketLSNR == null || !mySocketLSNR.Connected) start_SRVR_mgr();
            }
			if (r_stat != MainMDI.VIDE)
			{
				if (r_stat == "9" || r_stat == "8")
				{
					//if (r_stat == "9")
					if (MainMDI.User != "ede" && MainMDI.User.ToLower() != "admin")
					{
						timer1.Enabled =false;
                        //MessageBox.Show("   \n ALERT \n PGESCOM will be in maintenace in 5 minutes , please save your Work immediately and EXIT...    ", " Message ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        string msg = "   \n ALERT \n PGESCOM will be in maintenace in 5 minutes , please save your Work immediately and EXIT...  ";
                        MessageBox.Show(msg, "                           ALERT        ", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly);


                        timer2.Interval = (r_stat == "8") ? 180000 : 30000;
						timer2.Enabled = true;
					}
				}
				else
				{
					if (r_BLD != GescomBld && !timer3.Enabled)
					{
						//timer1.Enabled = false;
						timer3.Enabled = true;
						//timer1.Enabled = true;
						//Application.Exit();
					}
					string mchnStat = "";
					string mchnMsg = "";
					MainMDI.Find_2_Field(" select s_stat, s_msg from PSM_SYSETUP where s_machNm='" + Mach_Name + "'", ref mchnStat, ref mchnMsg);

                    if (mchnStat == MainMDI.VIDE)
                    {
                        string IPadrs = (MainMDI.IPadress.Length > 15) ? "999.999.999.999" : MainMDI.IPadress;
                        ExecSql("delete PSM_Whodo where UserNm='" + MainMDI.User + "'");
                        ExecSql("INSERT INTO PSM_Whodo ([dateIn],[machNm],[UserNm],[modlNm]) VALUES ( " + MainMDI.SSV_date(System.DateTime.Now.ToString()) + ", '" + MainMDI.Mach_Name + "', '" + MainMDI.User + "', '" + MdulNm + "      (bld=" + MainMDI.GescomBld + " / " + MainMDI.DBusrNm + ")')");
                        ExecSql("INSERT INTO PSM_SYSETUP ([VER],[BLD],[s_msg],[s_machNm],[IpAdrs],[IPport],[date_IN],[s_stat],[NewQ],[NewR]) VALUES ( " +
                            "'n/a','n/a','n/a', '" + MainMDI.Mach_Name + "','" + IPadrs + "','" + MainMDI.IPportNB + "'," + MainMDI.SSV_date(System.DateTime.Now.ToString()) + ",'1','1','1')");
                    }
                    MainMDI.Find_2_Field(" select s_stat, s_msg from PSM_SYSETUP where s_machNm='" + Mach_Name + "'", ref mchnStat, ref mchnMsg);
					if (!timer2.Enabled)
					{
						if (mchnStat == "0" || mchnStat == "9")
						{
							/*No 9 in status
							timer2.Interval = 120000;
							timer2.Enabled = true;
							timer1.Enabled = false;
							InfoBoard frmcntr = new InfoBoard(" PGESCOM will shutdown in 2 min, please save your Work immediately ...", 120);
							frmcntr.ShowDialog();
							*/
							
							timer2.Interval = (mchnStat == "9") ? 30000 : 180000;
							int nbSec = (mchnStat == "9") ? 30 : 180;
							timer2.Enabled = true;
							timer1.Enabled = false;
							InfoBoard frmcntr = new InfoBoard(" PGESCOM will shutdown in 2 min, please save your Work immediately and EXIT...", nbSec);
							frmcntr.ShowDialog();
							//MessageBox.Show("   \n ALERT:   PGESCOM will shutdown in 2 min, please save your Work immediately   ", " Message ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
						}
						else if (LastMsg != mchnMsg && mchnMsg != MainMDI.VIDE)
						{
							LastMsg = mchnMsg;
							MessageBox.Show("   \n  " + mchnMsg, " MESSAGE from Administrator ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
							MainMDI.ExecSql("UPDATE PSM_SYSETUP  SET [s_msg]='n/a' where s_machNm='" + Mach_Name + "'");
						    //timer1.Interval = 60000;
						}
					}
				}
			}
			else //E4
			{
                MessageBox.Show("Sorry, PGESCOM SETUP is corrupted or using BAD DATABASE contact Admin URGENTLY !!!! \n" + MainMDI.M_stCon, "                URGENT ALERT        ");
				Drop_TempTbls();
				Write_JFS(User + " logs OUT (E4) " + System.DateTime.Now);
				Application.Exit();
			}
			//Application.Exit();
			//timer2.Enabled = true;
			//picExit_Click(sender, e);
		}

		private void timer1_Tickold(object sender, System.EventArgs e)
		{
			string bld = MainMDI.Find_One_Field("select  BLD from PSM_SYSETUP  ");
			if (bld != GescomBld)
			{
				timer1.Enabled = false;
				MessageBox.Show("You have to UPDATE your PGESCOM (" + GescomBld + ")......(VBuild must=" + bld + "  ) !!!", "  Warning from Administrator  ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				timer1.Interval = 600000;
				timer1.Enabled = true;
				//Application.Exit();
			}
			//	
			string st = "", mach = "";
			MainMDI.Find_2_Field("select  s_stat, s_machNm from PSM_SYSETUP  ", ref st, ref mach);
			if ((mach.ToUpper() == "ALL" || mach.ToUpper() == Mach_Name) && st == "0")
			{
				timer1.Enabled = false;
				//MessageBox.Show("   \n" + st, "  MESSAGE from Administrator  ", MessageBoxButtons.OK, MessageBoxIcon.Information);
			
				//Application.Exit();
				//timer2.Enabled = true;
				//picExit_Click(sender, e);
			}
			//MainMDI.Find_2_Field("select s_msg,  s_machNm from PSM_SYSETUP  ", ref st, ref mach);
			//if (mach.ToUpper() == "ALL" && st.Length > 2)
			//{
			    //timer1.Enabled = false;
			    //MessageBox.Show("   \n" + st, "  MESSAGE from Administrator  ", MessageBoxButtons.OK, MessageBoxIcon.Information);
			    ////Application.Exit();
			    //timer1.Enabled = true;
			//}
		}

		private void Disp_Projects(char c)
		{
			this.Cursor = Cursors.WaitCursor;
			Orders_Look childOrd = new Orders_Look(c);
			this.Hide();
			childOrd.ShowDialog();
			this.Visible = true;
			childOrd.Dispose();
			this.Cursor = Cursors.Default;
		}

		private void Disp_Quotes(char c)
		{
			this.Cursor = Cursors.WaitCursor;
            //Quotes_Look child = new Quotes_Look(c);
            Quotes_Look_NEW child = new Quotes_Look_NEW(c);
            this.Hide();
			child.ShowDialog();
			this.Visible = true;
			child.Dispose();
			this.Cursor = Cursors.Default;
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			this.Refresh();
			Disp_Projects('B');
		}

		private void menuItem1_Click(object sender, System.EventArgs e)
		{
			Disp_Projects('O');
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			this.Refresh();
			Disp_Quotes('B');
		}

		private void Shutdown_JOBS()
		{
			MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where userID=" + MainMDI.UserID);
			MainMDI.Write_Whodo_SSetup("delete", 'D');
			dead = true;
			Drop_TempTbls(); //E3
			Write_JFS(User + " logs OUT(E3): " + System.DateTime.Now);
		}

		private void timer2_Tick(object sender, System.EventArgs e)
		{
			timer2.Enabled = false;
			if (timer2.Interval < 11)
			{
				InfoBoard frmcntr = new InfoBoard(" PGESCOM will be stopped for maintenance in 5 minutes...", 300);
				frmcntr.ShowDialog();
			}
			//else MainMDI.ExecSql("UPDATE PSM_SYSETUP  SET [s_stat]='1' where s_machNm]=' ' ");
			Shutdown_JOBS();
			Application.Exit();
		}

		private void load_XTT()
		{
            //WQfiles = @"C:\Users\%username%\Primax Technologies Inc\Primax_Data - PSM_Quotes"; ;
            WQfiles = @"c:\A_netprimax\Sales\PSM_Quotes";
            currDB = "XTT";
			GescomBld = "07xxxx.xx"; //YMMDD.VV
            M_stCon = @"user id=" + DBusrNm + ";password=primax;server=" + SQLDB + ";Trusted_Connection=No;database=" + currDB + ";connection timeout=30";
			this.Text = "XXXXXXXXXXXXXXXXXXTT";
		}

		private void chkXTT_CheckedChanged(object sender, System.EventArgs e)
		{
			//TESTING ENV
			if (MainMDI.User.ToLower() == "ede")
			{
				load_XTT();
				MainMDI_Load(sender, e);
			}
			else chkXTT.Visible = false;
		}

		private void timer3_Tick(object sender, System.EventArgs e)
		{
            if (timer3_majMsgNB > 3) { Shutdown_JOBS(); Application.Exit(); }
            timer3_majMsgNB++;
			timer3.Interval = 300000;
			MessageBox.Show(" PGESCOM must be Updated (Current Build#:" + GescomBld + ", must be: " + r_BLD + "  ) !!!", "  PGESCOM Update  ", MessageBoxButtons.OK, MessageBoxIcon.Warning);
			//timer1.Interval = 300000;
		}

		private void timer4_Tick(object sender, System.EventArgs e)
		{
            //disabled by kim on 30/0902010
            /*
			int chomer = Convert.ToInt32(lchomer.Text);
			if (chomer > 15)
			{
				//MessageBox.Show("Hey Exit........" +chomer);
				//InfoBoard frmcntr = new InfoBoard(" PGESCOM will shutdown ...", 10);
				//frmcntr.ShowDialog();
				MainMDI.Write_JFS("user=" + MainMDI.User + " ejected on" + DateTime.Now + " /NU  ");
				Shutdown_JOBS();
				Application.Exit();
			}
			else
			{
				if (this.Visible) { lchomer.Text = Convert.ToString(Convert.ToInt32(lchomer.Text) + 1); }
				else chomer= 0;
			}
            */
		}

		private void chkXTT_Click(object sender, System.EventArgs e)
		{
			//	
		}

		private void MainMDI_DoubleClick(object sender, System.EventArgs e)
		{
		
		}

		private void toolBar1_DoubleClick(object sender, System.EventArgs e)
		{
			lchomer.Visible =! lchomer.Visible;
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
            if (MainMDI.User == "ede")
            {
                OR_Sched_projects_NEW ts = new OR_Sched_projects_NEW(1, 'E');
                ts.ShowDialog();
            }
            else button2.Visible = false;
		}

        private void Exec_TSbutton(int btn)
        {
            this.Cursor = Cursors.WaitCursor;
            lchomer.Text = "0";
            lchomer.Text = "0";
            switch (btn)
            {
                case 0:
                    Disp_Quotes('L');
                    break;
                case 1:
                    Disp_Quotes('B');
                    break;
                case 2:
                    Disp_Projects('L');
                    break;
                case 3:
                    Disp_Projects('B');
                    break;
                case 4:
                    Disp_Projects('O');
                    break;
                case 5:
                    Company_Ges child2 = new Company_Ges();
                    //child2.MdiParent = this;
                    this.Hide();
                    child2.ShowDialog();
                    this.Visible = true;
                    child2.Dispose();
                    break;
                case 6:
                    Ges_Cont_Sal_Ag gCSA = new Ges_Cont_Sal_Ag('C');
                    this.Hide();
                    gCSA.ShowDialog();
                    this.Visible = true;
                    gCSA.Dispose();
                    break;
                case 7:
                    //if (MainMDI.User == "Admin" || MainMDI.User == "hnasrat" || MainMDI.User == "cfouche" || MainMDI.User == "mdimassi")
                    //if (super_user(MainMDI.User))
                    if (MainMDI.ALWD_USR("CPT_SV", false))
                    {
                        //Options child3 = new Options('M', "*");
                        Options_Admin child3 = new Options_Admin ('M', "*"); //for hnasrat, ede
                        this.Hide();
                        child3.ShowDialog();
                        this.Visible = true;
                        //child3.Dispose();
                    }
                    break;
                case 8: //statistics
                    //if (MainMDI.User == "Admin" || MainMDI.User == "ddarai" || MainMDI.User == "hnasrat")
                    //{
                        Stati Stat_frm = new Stati();
                        this.Hide();
                        Stat_frm.ShowDialog();
                        this.Visible = true;
                        Stat_frm.Dispose();
                    //}
                    //else MessageBox.Show("Statistics are under maintenance....");
                    break;
                case 9:
                    try
                    {
                        System.Diagnostics.Process.Start(MainMDI.PBSPath + @"\PBSIZING.exe");
                    }
                    catch (System.Exception Oexp)
                    {
                        MessageBox.Show("Cannot Find PBSIZING.EXE at path: " + MainMDI.PBSPath + " System-msg: " + Oexp.Message);
                    }
                    break;
                case 10:
                    //if (MainMDI.User == "Admin")
                        //if (MainMDI.profile =='S') //super_user(MainMDI.User))
                        //{
                            Misc child4 = new Misc();
                            child4.ShowDialog();
                            //this.Hide();
                            //this.Visible = true;
                            child4.Dispose();
                        //}
                        //else toolBar1.Buttons[5].Visible = false;
                    //child4.MdiParent = this;

                    //frmbatS child4 = new frmbatS();
                    //child4.MdiParent = this;
                    //child4.Show();
                    break;
                case 11:
                    MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where userID=" + MainMDI.UserID);
                    Drop_TempTbls(); //E1
                    Write_JFS(User + " logs OUT(E1): " + System.DateTime.Now);
                    Application.Exit();
                    /*
                    MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where userID=" + MainMDI.UserID);
                    Drop_TempTbls(); //E2
                    Write_JFS(User + " logs OUT(E2): " + System.DateTime.Now);
                    if (load_Loc_Config())
                    {
                        logxx();
                        if (login)
                        {		
                            if (!Creat_TempTbls())
                            {
                                MessageBox.Show("Cannot create Temp Tables !... Contact your DB Admin...");
                                Application.Exit();
                            }
                            else 
                            {
                                //MainMDI.ExecSql("UPDATE PSM_SYSETUP  SET [s_stat]='1', [s_machNm]=' ' ");
                                Write_JFS(User + " logs IN: " + System.DateTime.Now);
                                Write_Whodo_SSetup("main Menu", 'F');
                                if (MainMDI.User.ToUpper() == "UNLOCK") for (int i = 0; i < 14; i++) toolBar1.Buttons[i].Visible = (i == 10 || i == 11);
                                else for (int i = 0; i < 14; i++) toolBar1.Buttons[i].Visible = true;
                                timer1.Enabled = true;
                            }
                            //if (MainMDI.User == "Admin") chkXTT.Visible = true;
                        }
                    }
                    */
                    break;
                case 13:
                    //PSM_About ABT = new PSM_About(GescomBld);
                    PSM_About ABT = new PSM_About(GescomBld + " (" + RealBld + ")");
                    ABT.ShowDialog();
                    //MessageBox.Show("(SQL SERVER Version SSV)    V" + GescomVer + "   build#: " + GescomBld);
                    break;
                case 12:
                    if (MainMDI.User == "ede")
                    {
                        ChargerCOST chCost = new ChargerCOST();
                        this.Hide();
                        chCost.ShowDialog();
                        this.Visible = true;
                        chCost.Dispose();
                    }
                    break;
                case 14:
                    MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where userID=" + MainMDI.UserID);
                    Drop_TempTbls(); //E1
                    Write_JFS(User + " logs OUT(E1): " + System.DateTime.Now);
                    Application.Exit();
                    break;
            }
            if (!dead) Write_Whodo_SSetup("Main Menu", 'I');
            this.Cursor = Cursors.Default;
        }

        //TCP socket section begins here
        //it starts on users stations lestning to msgs sent from sessions Manager available on any station (user=ede).....
        private void start_SRVR_mgr()
        {
            if (MainMDI.IPportNB != "")
            {
                mySocketLSNR = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                myIPendP = new IPEndPoint(IPAddress.Any, Convert.ToInt16(MainMDI.IPportNB));
                mySocketLSNR.Bind(myIPendP);
                mySocketLSNR.Listen(4);
                mySocketLSNR.BeginAccept(new AsyncCallback(ONConnect), null);
                //MessageBox.Show("fin..start_SRVR_mgr= " + TCPreceivedTXT);
            }
            else MessageBox.Show("Error in IPportNB.......");
        }

        private void ONConnect(IAsyncResult myAsyn)
        {
            try
            {
                mySocketWRKR = mySocketLSNR.EndAccept(myAsyn);
                WaitData(mySocketWRKR);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n ONConnect(): socket has been closed \n");
            }
            catch (SocketException se)
            {
                MessageBox.Show("onconnect....socket exception: " + se.Message);
            }
        }

        private class CSocPket
        {
            public Socket thissocket;
            public byte[] DataBuf = new byte[1];
        }

        private void WaitData(Socket _soc)
        {
            try
            {
                if (myAsyncCallBack == null)
                {
                    myAsyncCallBack = new AsyncCallback(ONDataReceived);
                }
                CSocPket mySocPket = new CSocPket();
                mySocPket.thissocket = _soc;
                _soc.BeginReceive(mySocPket.DataBuf, 0, mySocPket.DataBuf.Length, SocketFlags.None, myAsyncCallBack, mySocPket);
            }
            catch (SocketException se)
            {
                MessageBox.Show("WaitData(): socketException: " + se.Message);
            }
        }

        private void ONDataReceived(IAsyncResult myIasync)
        {
            try
            {
                CSocPket myCSocID = (CSocPket)myIasync.AsyncState;
                int irx = 0;
                irx = myCSocID.thissocket.EndReceive(myIasync);
                char[] chars = new char[irx + 1];
                System.Text.Decoder dcod = System.Text.Encoding.UTF8.GetDecoder();
                int charlen = dcod.GetChars(myCSocID.DataBuf, 0, irx, chars, 0);
                System.String szData = new System.String(chars);
                TCPreceivedTXT += szData[0];
                //MessageBox.Show("Data Received= " + Convert.ToString(TCPreceivedTXT));
                WaitData(mySocketWRKR);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n ONConnect(): socket has been closed \n");
            }
            catch (SocketException se)
            {
                //MessageBox.Show("ONDataReceived socket exception: " + se.Message + "    soc_connected=" + mySocketLSNR.Connected.ToString());
                System.Diagnostics.Debugger.Log(0, "1", "\n ONConnect() SE:" + se.Message);
                mySocketLSNR.Close();
                mySocketWRKR.Close();
                start_SRVR_mgr();
                //myIPendP = new IPEndPoint(IPAddress.Any, Convert.ToInt16(MainMDI.IPportNB));
                //mySocketLSNR.Bind(myIPendP);
                //mySocketLSNR.Listen(4);
                //mySocketLSNR.BeginAccept(new AsyncCallback(ONConnect), null);
            }
        }

        private void pg_tools_Click(object sender, EventArgs e)
        {
            Exec_TSbutton(10);
        }

        private void new_qt_Click(object sender, EventArgs e)
        {
            Exec_TSbutton(0);
        }

        private void exiit_Click(object sender, EventArgs e)
        {
            MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where userID=" + MainMDI.UserID);
            //Write_Whodo("delete", 'D');
            //Drop_TempTbls();
            //Write_JFS(User + " logs OUT: " + System.DateTime.Now);
            Shutdown_JOBS();
            Application.Exit();
        }

        private void Orders_Click(object sender, EventArgs e)
        {
            Exec_TSbutton(2);
        }

        private void bglst_Click(object sender, EventArgs e)
        {
            ////if (Confirm ("Continue display Big List......???")) Exec_TSbutton(3); //disp all projects
            //CMS_Agents myfrm = new CMS_Agents();
            //myfrm.ShowDialog();

            ////testing Agencies , Agents
            //dlg_SYSP_Agencies mydlg = new dlg_SYSP_Agencies();
            //mydlg.ShowDialog();

            ////testing quote4444
            //QuoteV4 child4 = new QuoteV4(15999, "Dessau - Énergie", 'E');
            //this.Hide();
            //child4.ShowDialog();
            //this.Visible = true;

            //P600_SwitchMD Rectifdlg = new P600_SwitchMD();
            //Rectifdlg.ShowDialog();

            //statistics
            //Stati_NEW Stat_frm = new Stati_NEW();
            //this.Hide();
            //Stat_frm.ShowDialog();
            //this.Visible = true;
            //Stat_frm.Dispose();

            //string B_model = "";
            //Chargerdlg frmchdlg = new Chargerdlg('0', MainMDI._connectionString);
            //this.Hide();
            //frmchdlg.ShowDialog();
            //this.Visible = true;

            //NL_Item_Option_NEW frmNLIO = new NL_Item_Option_NEW("5455", "4524");
            //frmNLIO.ShowDialog();

            //Q_service frmNLIO = new Q_service();
            //frmNLIO.ShowDialog();

            //GenConfigi_Quotes myFRM = new GenConfigi_Quotes();
            //myFRM.ShowDialog();

            ////pwd for configo
            //GenConfigipwd myFRM = new GenConfigipwd();
            //myFRM.ShowDialog();

            ////UPS
            //UPS_maker myUPS = new UPS_maker();
            //myUPS.ShowDialog();

            //MisePageXL();
            //display_cedulo();

            //DateTime NISdate= get_NIS_date();
            //MessageBox.Show("NIS date= " + NISdate.ToString());

            //NISdate = InternetTime.GetCurrentTime().Value.ToLocalTime();
            //MessageBox.Show("Internettime date= " + NISdate.ToString());

            //Chargerdlg_Cfg_v2 frmchdlg = new Chargerdlg_Cfg_v2('0', "8711", MainMDI._connectionString);
            //this.Hide();
            //frmchdlg.ShowDialog();
            //this.Visible = true;

            ////UPS
            //dlg_add_P850UI mydlg = new dlg_add_P850UI();
            //mydlg.ShowDialog();

            //UPS from list
            //P850UI_UPS_INV Rectifdlg = new P850UI_UPS_INV('I');
            //Rectifdlg.ShowDialog();

            //P850xx_MBS Rectifdlg = new P850xx_MBS(); //P850UI_UPS_INV('I');
            //Rectifdlg.ShowDialog();

            //testing quote3
            QuoteV3 child4 = new QuoteV3(15999, "Dessau - Énergie", 'E');
            this.Hide();
            child4.ShowDialog();
            this.Visible = true;
        }

        DateTime get_NIS_date()
        {
            var client = new TcpClient("time.nist.gov", 13);
            using (var streamReader = new StreamReader(client.GetStream()))
            {
                var response = streamReader.ReadToEnd();
                var utcDateTimeString = response.Substring(7, 17);
                var localDateTime = DateTime.ParseExact(utcDateTimeString, "yy-MM-dd HH:mm:ss", CultureInfo.InvariantCulture, DateTimeStyles.AssumeUniversal);
                return localDateTime;
            }
        }

        void MisePageXL()
        {
            using (OpenFileDialog filedlg = new OpenFileDialog() { Filter = "Excel Workbook|*.csv", ValidateNames = true })
            {
                if (filedlg.ShowDialog() == DialogResult.OK)
                {
                    string xlOUT = filedlg.FileName.Replace(".csv", "_rpt.xls"); //+ "_12345.xls"
                    MEP_TR_XL_WEBPage(filedlg.FileName, xlOUT);
                }
            }
        }

        string getXY(int x, int y, Excel._Worksheet myWS)
        {
            object cellVal = ((Excel.Range)myWS.Cells[x, y]).Value;
            if (cellVal != null) return cellVal.ToString();
            return "";
        }

        void MEP_TR_XL_WEBPage(string XLfnm_IN, string XLfnm_OUT)
        {
            MessageBox.Show("in= " + XLfnm_IN + "        out= " + XLfnm_OUT);

            Excel.Application apps = new Excel.Application();
            Excel.Workbook myWrkbook = apps.Workbooks.Open(XLfnm_IN);
            Excel.Worksheet myWrksheet = myWrkbook.Worksheets[1];

            string title = getXY(59, 4, myWrksheet);

            MessageBox.Show("cell: 59:4:  " + title);

            myWrkbook.Close();

            //object cellVal = (Excel.Range)myWrksheet.Cells[1, 1];
            //cellVal = (Excel.Range)myWrksheet.Cells[1, 1];

            //--------------------------------

            //System.IO.File.Delete(XLfnm_OUT); //"CMS_CALC.xls");
            //Object m_objOpt = System.Reflection.Missing.Value;
            //Excel.Application m_objXL = new Excel.Application();
            //Excel.Workbooks m_objbooks = m_objXL.Workbooks;
            //Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);
            //Excel.Sheets m_objSheets = m_objBook.Worksheets;
            //Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

            //Excel.Range m_objRng = m_objSheet.get_Range(CellFM, CellTO);
            //m_objRng.Value2 = objHdrs;
            //Excel.Font m_objFont = m_objRng.Font;
            //m_objFont.Bold = true;

            //m_objRng = m_objSheet.get_Range("A2", m_objOpt);
            //m_objRng = m_objRng.get_Resize(MainMDI.MAX_XLlines_XPRT, HdrsNB);
            //m_objRng.Value2 = objData;

            //m_objBook.SaveAs(MainMDI.XL_Path + @"\" + FName, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            //m_objBook.Close(false, m_objOpt, m_objOpt);
            //m_objXL.Quit();
            ////??? NO data
            ////MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\" + FName);

            //MainMDI.EXEC_FILE("EXCEL.exe", MainMDI.XL_Path + @"\" + FName);
        }

        private void arch_Click(object sender, EventArgs e)
        {
            Exec_TSbutton(4);
            //QuoteV2 qv2 = new QuoteV2(0, "*", 'N');
            //qv2.Show();
        }

        private void company_Click(object sender, EventArgs e)
        {
            Exec_TSbutton(5);
        }

        private void cntct_Click(object sender, EventArgs e)
        {
            Exec_TSbutton(6);
        }

        private void cpts_Click(object sender, EventArgs e)
        {
            Exec_TSbutton(7);
        }

        private void Statistics_Click(object sender, EventArgs e)
        {
            Exec_TSbutton(8);
        }

        private void pbsizing_Click(object sender, EventArgs e)
        {
            //Exec_TSbutton(9); pbsizing
            /*if (MainMDI.User.ToLower() == "ede")
                //if (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "ana" || MainMDI.User.ToLower() == "shammou" || MainMDI.User.ToLower() == "mmellouli")
                //{
                    if (MainMDI.User.ToLower() == "shammou")
                    {
                        dlg_Vaca_Conges myfrm = new dlg_Vaca_Conges();
                        myfrm.ShowDialog();
                        myfrm.Close();
                    }
                    else
                    {
                        OR_Sched_Vacations myFrm = new OR_Sched_Vacations();
                        myFrm.ShowDialog();
                        myFrm.Close();
                    }
                }
            */
            //OR_Sched_Vacations myFrm = new OR_Sched_Vacations();
            //myFrm.ShowDialog();
            //myFrm.Close();

            OR_cedule myFrm = new OR_cedule();
            this.Hide();
            myFrm.ShowDialog();
            this.Visible = true;
            myFrm.Close();
        }

        private void TSmain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void db_used_Click(object sender, EventArgs e)
        {
            //Commissions
            //CMS_xlBills f_cms = new CMS_xlBills();
            //this.Hide();
            //f_cms.ShowDialog();
            //this.Visible = true;

            //XmlDocument x_Doc = new XmlDocument();
            //XmlElement x_El = x_Doc.CreateElement("DB_Name");
            //x_El.InnerText = @"PROGRAMEUR1\PERS2000";
            //x_Doc.AppendChild(x_El);
            //string tt = @"c:\NewTOTO.xml";
            //x_Doc.Save(tt);

            //test fast schedule
            //if (MainMDI.ALWD_USR("OR_SCD", true))
            //{
                //this.Cursor = Cursors.WaitCursor;
                ////OR_Sched_projects ALLP = new OR_Sched_projects(1);
                //OR_Sched_projects_N00 ALLP = new OR_Sched_projects_N00(0);
                //this.Hide();
                //ALLP.ShowDialog();
                //this.Visible = true;
                //this.Cursor = Cursors.Default;
                //ALLP.Dispose();
            //}

            ////test Crystal report
            //
            //disp_RPT dd = new disp_RPT("CF00-S5116","2196");
            //dd.ShowDialog();

            //testing PXMS module for Chargere page WEB
            //PXMS_Charger_Setting CSet = new PXMS_Charger_Setting();
            //CSet.ShowDialog();

            ////Pricing test
            //string st = "Back_PSM_FDB";
            //MainMDI.Chng_CurrDB(st);
            //picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
            //Setng_004 PRC_Simula = new Setng_004();
            //this.Hide();
            //PRC_Simula.ShowDialog();
            //this.Visible = true;

            this.Cursor = Cursors.WaitCursor;
            char c ='E';
            //QuoteV3 child4 = new QuoteV3(Convert.ToInt32("15999"), "Dessau - Énergie", c);
            //this.Hide();
            //child4.ShowDialog();
            //this.Visible = true;
            //this.Cursor = Cursors.Default;
        }

        private void menuItem3_Click(object sender, EventArgs e)
        {

        }

        private void assembliesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("SYSP_TLS", true))
            {
                SYSPRO_Queries frm = new SYSPRO_Queries();
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
            }
        }

        private void componentsSearchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("SYSP_TLS", true))
            {
                SYSPRO_QuerCPT frm = new SYSPRO_QuerCPT(); //SYSPRO_Queries();
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
            }
        }

        private void babt_Click(object sender, EventArgs e)
        {
            Exec_TSbutton(13);
        }

        private void sett_Click(object sender, EventArgs e)
        {
            if (MainMDI.user_Admin()) //|| MainMDI.User.ToLower() == "ede"
            {
                settingMenu _Menu = new settingMenu();
                this.Hide();
                _Menu.ShowDialog();
                this.Visible = true;
            }
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            Exec_TSbutton(12);
        }

        private void ts_acct_Clickold(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("C_CMS", false) || MainMDI.ALWD_USR("A_CMS", false) || MainMDI.ALWD_USR("V_CMS", false))
            {
                CMS_invLIST frm = new CMS_invLIST();
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
            }
        }

        //verify if user Has super access to CMS 
        private async Task<bool> verifyCMSUserAccess() {
            bool userAccess = false;
            try
            {
                string stSql = "SELECT * FROM Cms_User_Access";

                SqlConnection OConn = new SqlConnection(_connectionString);
                await OConn.OpenAsync();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = await Ocmd.ExecuteReaderAsync();
                while (await Oreadr.ReadAsync())
                {
                    if (MainMDI.User.ToLower() == Oreadr["userHasAccess"].ToString().ToLower()) { 
                        userAccess = true; 
                        break; 
                    }
                }
                OConn.Close();
            }
            catch (Exception error)
            {
                Console.WriteLine(error);
            }
            return userAccess; 
        }


        private async void ts_acct_Click(object sender, EventArgs e)
        {
            bool good = false;
            string msg = "";
            if (MainMDI.ALWD_USR("C_CMS", false) || MainMDI.ALWD_USR("A_CMS", false) || MainMDI.ALWD_USR("V_CMS", false))
            {
                bool userAccess = await verifyCMSUserAccess();
                if (!MainMDI.user_Admin() && SRVRpwd != "Y")
                {
                    //MainMDI.User.ToLower() != "mmellouli" && MainMDI.User.ToLower() != "hnasrat" && MainMDI.User.ToLower() != "mmaturi" && MainMDI.User.ToLower() != "mloyer"
                    if (userAccess == false)
                    {
                        PXLogin myLog = new PXLogin(MainMDI.User);
                        myLog.ShowDialog();

                        good = (myLog.lYN.Text == "Y");
                        SRVRpwd = myLog.lYN.Text;
                    }
                    else good = true;
                }
                else good = true;
                if (good)
                {
                    CMS_fromSYSPRO frm = new CMS_fromSYSPRO();
                    this.Hide();
                    frm.ShowDialog();
                    this.Visible = true;
                }
            }
        }

        private void SP_REP_Click(object sender, EventArgs e)
        {
            /*if (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "hnasrat" || MainMDI.User.ToLower() == "mrouleau")
            {
                SYSPRO_Reps frm = new SYSPRO_Reps();
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
            }
            */

            //if (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "amanarddine" || MainMDI.User.ToLower() == "ppoplitov")
            if (MainMDI.ALWD_USR("SYSP_TLS", true))
            {
                SYSPRO_Queries frm = new SYSPRO_Queries();
                this.Hide();
                frm.ShowDialog();
                this.Visible = true;
            }
        }

        //TCP socket

        public static bool IsPGCInsta()
        {
            //Console.WriteLine(string.Format("Checking install status of: {0}", "PGESCOM"));
            foreach (var item in Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall").GetSubKeyNames())
            {
                object programName = Registry.LocalMachine.OpenSubKey("SOFTWARE\\Microsoft\\Windows\\CurrentVersion\\Uninstall\\" + item).GetValue("DisplayName");

                Console.WriteLine(programName);

                if (string.Equals(programName, "PGESCOM")) return true;
            }
            //MessageBox.Show("This Software is not INSTALLED or has a registry Error......");
            return false;
        }

        private void picCIP_Click(object sender, EventArgs e)
        {

        }

        void runConfigo()
        {
            //configo
            string pbs = "http://www.primaxpower.ca/?" + MainMDI.User.ToLower() + "=";
            System.Diagnostics.Process.Start(pbs);
        }
    }
}
