using System;
using System.Text ;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data ;
using System.Data.OleDb ;
using System.Data.SqlClient  ;
using Excel = Microsoft.Office.Interop.Excel ;
//using DTS;
using EAHLibs;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for Stati.
	/// </summary>
	public class Stati_NEW : System.Windows.Forms.Form
	{
        //virtual LV 190707
        ListViewItem[] Lvi;
        double AMNT_FM = 0, AMNT_TO = 0;
        double USD_SQ = 0, EUR_SQ = 0, CAD_SQ = 0, USD_SQnb = 0, EUR_SQnb = 0, CAD_SQnb = 0, USD_SQcad = 0, EUR_SQcad = 0, CAD_SQcad = 0,
             BT_OR = 0, UST_OR = 0, CADT_OR = 0, EurT_OR = 0,UST_ORcad = 0, CADT_ORcad = 0, EurT_ORcad = 0, UST_ORnb = 0, CADT_ORnb = 0, EurT_ORnb = 0;
        //virtual LV 190707
        double BT = 0, UST = 0, CADT = 0, EurT = 0, USTnb = 0, CADTnb = 0, EurTnb = 0;
        char Opera = ' ';
	//sort lIst
		private ListViewColumnSorter  lvSorter=null;
		private ListViewColumnSorter  lvSorterProj=null;
        private ListViewColumnSorter lvSorterSYS = null;
		private int seelCol=0;
		private int oldSC=0,TOTnb=0;
		private char srtType='A';
        private const int Irrev_MAX_ROW=4000, SYSNB=50,SYSCols=7;
        Double TOTExt = 0,TOTSYS=0;
        string[,] arr_Irrev_Ndx = new string[Irrev_MAX_ROW, 2];
        string[,] arr_SYS = new string[SYSNB, SYSCols];
	//sort lIst
		private Lib1 Tools = new Lib1();
		private int ndxfound=0;
		private System.Windows.Forms.GroupBox grpfind;
		private System.Windows.Forms.Button btnQt;
		public System.Windows.Forms.DateTimePicker dpFrom;
		public System.Windows.Forms.DateTimePicker dpTo;
		private System.Windows.Forms.Button btnRRev;
        private System.Windows.Forms.GroupBox grpTot;
		private System.Windows.Forms.PictureBox picSeek;
		public System.Windows.Forms.TextBox tKey;
		private System.Windows.Forms.ComboBox cbCompany;
		private System.Windows.Forms.ComboBox cbEmploy;
		private System.Windows.Forms.Label lcpnyID;
        private System.Windows.Forms.Label lempID;
		private System.Windows.Forms.Label lemp;
		private System.Windows.Forms.Label lcpny;
        private System.Windows.Forms.Label lfrom;
        private System.Windows.Forms.Label lTo;
		private System.Windows.Forms.RadioButton opSHP;
		private System.Windows.Forms.RadioButton opInP;
		private System.Windows.Forms.RadioButton opAll;
		private System.Windows.Forms.Label lOp;
        private System.Windows.Forms.RadioButton opFapp;
		private System.Windows.Forms.GroupBox grpQt;
		private System.Windows.Forms.RadioButton opQt;
        private System.Windows.Forms.RadioButton opQP;
		private System.Windows.Forms.TextBox tSQL;
		private System.Windows.Forms.ImageList Fst_IL32;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListView lvQuotes;
		private System.Windows.Forms.ColumnHeader Qdat;
		private System.Windows.Forms.ColumnHeader Empl;
		private System.Windows.Forms.ColumnHeader QID;
		private System.Windows.Forms.ColumnHeader Cpny;
		private System.Windows.Forms.ColumnHeader amt;
		private System.Windows.Forms.ColumnHeader q_dblAmt;
		private System.Windows.Forms.ColumnHeader Curr;
		private System.Windows.Forms.ColumnHeader ProID;
		private System.Windows.Forms.ListView lvProj;
		private System.Windows.Forms.ColumnHeader Rdat;
		private System.Windows.Forms.ColumnHeader empR;
		private System.Windows.Forms.ColumnHeader RID;
		private System.Windows.Forms.ColumnHeader QIDR;
		private System.Windows.Forms.ColumnHeader cpnyNm;
		private System.Windows.Forms.ColumnHeader PO;
		private System.Windows.Forms.ColumnHeader AmntR;
		private System.Windows.Forms.ColumnHeader r_dblamt;
		private System.Windows.Forms.ColumnHeader CurrR;
		private System.Windows.Forms.ColumnHeader CADmnt;
        private System.Windows.Forms.ColumnHeader xrate;
		private System.Windows.Forms.GroupBox grpcat;
        private System.Windows.Forms.CheckBox chkcat;
        private ToolStrip toolStrip1;
        private GroupBox grpAdv;
        private ToolStripButton picQT;
        private ToolStripButton picOrders;
        private ToolStripButton picXL;
        private ToolStripButton exit;
        private RadioButton opSHP_TSTnc;
        private ColumnHeader PName;
        private ColumnHeader prjName;
        private GroupBox grpDates;
        private RadioButton optshpDate;
        private RadioButton optInvdate;
        private Label lbldates;
        private RadioButton optrdrDate;
        private ListBox lv_Ex;
        private PictureBox picEX;
        private Label label1;
        private PictureBox picEx2;
        public PictureBox picCIP;
        private ColumnHeader irrevLIDD;
        private ColumnHeader phone;
        private ColumnHeader adrs;
        private GroupBox grpCurr;
        private Label label5;
        private Label label4;
        private Label tUSDTot;
        private Label tBigTot;
        private RadioButton optInv;
        private TextBox txCMP;
        private ColumnHeader itmSN;
        private CheckBox chSN;
        private ColumnHeader des;
        private ColumnHeader ddlvr;
        private GroupBox grpCharg;
        private CheckBox chkModel;
        public TextBox tkey_CHREC;
        private Label label11;
        private ToolStripButton tlsbtn_Cust;
        private ToolStripButton toolStripButton2;
        private ToolStripButton tlsbtnRectif;
        private GroupBox grpCH;
        private Panel pnlCharger;
        private Label label2;
        private Label label3;
        private Label label7;
        private Label label8;
        private Label label9;
        private Label label10;
        public ComboBox cbPhs;
        private Label label22;
        private ComboBox cbPxx;
        public ComboBox cbVdc;
        public ComboBox cbIdc;
        private GroupBox grpREC;
        private Panel pnlRectif;
        private Label lcbRectifiers;
        public ComboBox cbRectifiers;
        public TextBox tkeyHidn;
        private ListView lvSYS;
        private ColumnHeader desc;
        private ColumnHeader SysNm;
        private ColumnHeader cntr;
        private ColumnHeader RIDlst;
        private ColumnHeader SNlst;
        public PictureBox picFind;
        private ToolStripButton toolStripButton1;
        private DataGridView dgvSYS;
        private Label label12;
        private Button button1;
        private GroupBox groupBox3;
        private Label lSucc;
        private Label lSucc0;
        private Label lAvrg;
        private Label lav;
        private Label lProjNB;
        private Label lProjNB0;
        private Label lNBQ;
        private Label lQ;
        private GroupBox grpTOTsys;
        private Label label13;
        private Label label15;
        private Label lTOTnb;
        private Label lTOTSYS;
        private Label label19;
        private Button btnDispCols;
        private ed_LVmodif ed_tot_ratios;
        private ColumnHeader id;
        private ColumnHeader yy;
        private ColumnHeader volume;
        private ColumnHeader Moy;
        private ColumnHeader nb;
        private DataGridViewTextBoxColumn Column1;
        private DataGridViewTextBoxColumn Column2;
        private DataGridViewTextBoxColumn Column3;
        private DataGridViewTextBoxColumn Column4;
        private DataGridViewTextBoxColumn Column5;
        private DataGridViewTextBoxColumn Column6;
        private DataGridViewTextBoxColumn sysPrc;
        private TextBox txAMNT_T;
        private TextBox txAMNT_F;
        private Label label14;
        private Label label16;
        private Label lAM_TO;
        private Label lAM_FM;
        private ToolStripButton picQvsP;
        private Label label17;
        private Label lEROTot;
        private GroupBox grpTOTqo;
        private ed_LVmodif edlv_QtOr;
        private ColumnHeader columnHeader1;
        private ColumnHeader txt;
        private ColumnHeader colNB;
        private ColumnHeader colAM;
        private ColumnHeader colAVRG;
        private GroupBox groupBox4;
        private Label lcad_USD;
        private TextBox txReuro;
        private TextBox txRusd;
        private TextBox txRcad;
        private Label label24;
        private Label label23;
        private Label label21;
        private Label lcad_CAD;
        private Label lcad_EURO;
        private Label tCADTot;
        private Label lCADnb;
        private Label lEROnb;
        private Label label18;
        private Label lUSDnb;
        private Label NBqo;
        private Label lnbQS;
        private RadioButton opOrders;
        private RadioButton opQuote;
        private GroupBox grpQvsR;
        private ed_LVmodif edlv_QvsOR;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private Label lvisi;
        public PictureBox findQT;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripSeparator toolStripSeparator2;
        private Panel pnl_terri;
        private Label label6;
        public ComboBox cbSales;
        private ToolStripButton tls_terri;
        private Label lSnn;
		private System.ComponentModel.IContainer components;

        public Stati_NEW()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			lvSorter = new ListViewColumnSorter(); 
			this.lvQuotes.ListViewItemSorter  = lvSorter ; 
			lvQuotes.AutoArrange=true; 

			lvSorterProj  = new ListViewColumnSorter(); 
			this.lvProj.ListViewItemSorter  = lvSorterProj    ; 
            lvProj.AutoArrange=true;

            lvSorterSYS = new ListViewColumnSorter();
            this.lvSYS.ListViewItemSorter = lvSorterSYS;
            lvSYS.AutoArrange = true; 

			lvSorter.SortColumn =0;
			lvSorter.Order =System.Windows.Forms.SortOrder.Descending  ;
			seelCol=0;
			fill_cbCompany();
			fill_cbSal_AG("S");
			cbCompany.Text ="ALL";
			cbEmploy.Text ="ALL";

             


         //   mak_lvProj_VM();

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Stati_NEW));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "", System.Drawing.Color.Black, System.Drawing.Color.Salmon, new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)))),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "QUOTES", System.Drawing.Color.Black, System.Drawing.Color.Salmon, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)))),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0", System.Drawing.Color.Black, System.Drawing.Color.Salmon, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0", System.Drawing.Color.Black, System.Drawing.Color.Salmon, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0", System.Drawing.Color.Black, System.Drawing.Color.Salmon, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))))}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "", System.Drawing.Color.Black, System.Drawing.Color.PaleTurquoise, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)))),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "ORDERS", System.Drawing.Color.Black, System.Drawing.Color.PaleTurquoise, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)))),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0", System.Drawing.Color.Black, System.Drawing.Color.PaleTurquoise, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0", System.Drawing.Color.Black, System.Drawing.Color.PaleTurquoise, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0", System.Drawing.Color.Black, System.Drawing.Color.PaleTurquoise, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))))}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "", System.Drawing.Color.Black, System.Drawing.Color.Ivory, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)))),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "    %", System.Drawing.Color.Black, System.Drawing.Color.Ivory, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)))),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0", System.Drawing.Color.Black, System.Drawing.Color.Ivory, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0", System.Drawing.Color.Black, System.Drawing.Color.Ivory, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)))),
            new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "0", System.Drawing.Color.Black, System.Drawing.Color.Ivory, new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0))))}, -1);
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.grpfind = new System.Windows.Forms.GroupBox();
            this.grpCharg = new System.Windows.Forms.GroupBox();
            this.grpREC = new System.Windows.Forms.GroupBox();
            this.pnlRectif = new System.Windows.Forms.Panel();
            this.lcbRectifiers = new System.Windows.Forms.Label();
            this.cbRectifiers = new System.Windows.Forms.ComboBox();
            this.grpCH = new System.Windows.Forms.GroupBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pnlCharger = new System.Windows.Forms.Panel();
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.cbPhs = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cbPxx = new System.Windows.Forms.ComboBox();
            this.cbVdc = new System.Windows.Forms.ComboBox();
            this.cbIdc = new System.Windows.Forms.ComboBox();
            this.btnDispCols = new System.Windows.Forms.Button();
            this.picFind = new System.Windows.Forms.PictureBox();
            this.tkeyHidn = new System.Windows.Forms.TextBox();
            this.tkey_CHREC = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.pnl_terri = new System.Windows.Forms.Panel();
            this.lSnn = new System.Windows.Forms.Label();
            this.cbSales = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.findQT = new System.Windows.Forms.PictureBox();
            this.lvisi = new System.Windows.Forms.Label();
            this.opOrders = new System.Windows.Forms.RadioButton();
            this.opQuote = new System.Windows.Forms.RadioButton();
            this.chkModel = new System.Windows.Forms.CheckBox();
            this.txCMP = new System.Windows.Forms.TextBox();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.lbldates = new System.Windows.Forms.Label();
            this.chkcat = new System.Windows.Forms.CheckBox();
            this.lempID = new System.Windows.Forms.Label();
            this.btnRRev = new System.Windows.Forms.Button();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.lOp = new System.Windows.Forms.Label();
            this.lTo = new System.Windows.Forms.Label();
            this.lcpnyID = new System.Windows.Forms.Label();
            this.btnQt = new System.Windows.Forms.Button();
            this.lfrom = new System.Windows.Forms.Label();
            this.grpQt = new System.Windows.Forms.GroupBox();
            this.opQP = new System.Windows.Forms.RadioButton();
            this.opQt = new System.Windows.Forms.RadioButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.picQT = new System.Windows.Forms.ToolStripButton();
            this.picOrders = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.picQvsP = new System.Windows.Forms.ToolStripButton();
            this.tlsbtn_Cust = new System.Windows.Forms.ToolStripButton();
            this.tls_terri = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.tlsbtnRectif = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.picXL = new System.Windows.Forms.ToolStripButton();
            this.exit = new System.Windows.Forms.ToolStripButton();
            this.grpAdv = new System.Windows.Forms.GroupBox();
            this.cbCompany = new System.Windows.Forms.ComboBox();
            this.lAM_TO = new System.Windows.Forms.Label();
            this.lAM_FM = new System.Windows.Forms.Label();
            this.txAMNT_T = new System.Windows.Forms.TextBox();
            this.txAMNT_F = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.chSN = new System.Windows.Forms.CheckBox();
            this.picEx2 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.picEX = new System.Windows.Forms.PictureBox();
            this.lv_Ex = new System.Windows.Forms.ListBox();
            this.grpDates = new System.Windows.Forms.GroupBox();
            this.optrdrDate = new System.Windows.Forms.RadioButton();
            this.optshpDate = new System.Windows.Forms.RadioButton();
            this.optInvdate = new System.Windows.Forms.RadioButton();
            this.cbEmploy = new System.Windows.Forms.ComboBox();
            this.picSeek = new System.Windows.Forms.PictureBox();
            this.lcpny = new System.Windows.Forms.Label();
            this.lemp = new System.Windows.Forms.Label();
            this.grpcat = new System.Windows.Forms.GroupBox();
            this.optInv = new System.Windows.Forms.RadioButton();
            this.opSHP_TSTnc = new System.Windows.Forms.RadioButton();
            this.opInP = new System.Windows.Forms.RadioButton();
            this.opAll = new System.Windows.Forms.RadioButton();
            this.opSHP = new System.Windows.Forms.RadioButton();
            this.opFapp = new System.Windows.Forms.RadioButton();
            this.tKey = new System.Windows.Forms.TextBox();
            this.tSQL = new System.Windows.Forms.TextBox();
            this.Fst_IL32 = new System.Windows.Forms.ImageList(this.components);
            this.grpTot = new System.Windows.Forms.GroupBox();
            this.grpQvsR = new System.Windows.Forms.GroupBox();
            this.edlv_QvsOR = new PGESCOM.ed_LVmodif();
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpTOTqo = new System.Windows.Forms.GroupBox();
            this.edlv_QtOr = new PGESCOM.ed_LVmodif();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.txt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colNB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colAVRG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ed_tot_ratios = new PGESCOM.ed_LVmodif();
            this.id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.yy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.volume = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Moy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.nb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpTOTsys = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.lTOTnb = new System.Windows.Forms.Label();
            this.lTOTSYS = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lSucc = new System.Windows.Forms.Label();
            this.lSucc0 = new System.Windows.Forms.Label();
            this.lAvrg = new System.Windows.Forms.Label();
            this.lav = new System.Windows.Forms.Label();
            this.lProjNB = new System.Windows.Forms.Label();
            this.lProjNB0 = new System.Windows.Forms.Label();
            this.lNBQ = new System.Windows.Forms.Label();
            this.lQ = new System.Windows.Forms.Label();
            this.grpCurr = new System.Windows.Forms.GroupBox();
            this.lnbQS = new System.Windows.Forms.Label();
            this.NBqo = new System.Windows.Forms.Label();
            this.lCADnb = new System.Windows.Forms.Label();
            this.lEROnb = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.lUSDnb = new System.Windows.Forms.Label();
            this.tCADTot = new System.Windows.Forms.Label();
            this.txRcad = new System.Windows.Forms.TextBox();
            this.label24 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.lcad_CAD = new System.Windows.Forms.Label();
            this.lcad_EURO = new System.Windows.Forms.Label();
            this.lcad_USD = new System.Windows.Forms.Label();
            this.txReuro = new System.Windows.Forms.TextBox();
            this.txRusd = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.lEROTot = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tUSDTot = new System.Windows.Forms.Label();
            this.tBigTot = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvProj = new System.Windows.Forms.ListView();
            this.Rdat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.empR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QIDR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cpnyNm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AmntR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.r_dblamt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CurrR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CADmnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.xrate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prjName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.irrevLIDD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.des = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.itmSN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ddlvr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvQuotes = new System.Windows.Forms.ListView();
            this.Qdat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Empl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cpny = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.q_dblAmt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Curr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.adrs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dgvSYS = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sysPrc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lvSYS = new System.Windows.Forms.ListView();
            this.desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SysNm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cntr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RIDlst = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SNlst = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpfind.SuspendLayout();
            this.grpCharg.SuspendLayout();
            this.grpREC.SuspendLayout();
            this.pnlRectif.SuspendLayout();
            this.grpCH.SuspendLayout();
            this.pnlCharger.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picFind)).BeginInit();
            this.pnl_terri.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.findQT)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.grpQt.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.grpAdv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEx2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEX)).BeginInit();
            this.grpDates.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).BeginInit();
            this.grpcat.SuspendLayout();
            this.grpTot.SuspendLayout();
            this.grpQvsR.SuspendLayout();
            this.grpTOTqo.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.grpTOTsys.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.grpCurr.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSYS)).BeginInit();
            this.SuspendLayout();
            // 
            // grpfind
            // 
            this.grpfind.BackColor = System.Drawing.Color.Azure;
            this.grpfind.Controls.Add(this.grpAdv);
            this.grpfind.Controls.Add(this.grpCharg);
            this.grpfind.Controls.Add(this.pnl_terri);
            this.grpfind.Controls.Add(this.findQT);
            this.grpfind.Controls.Add(this.lvisi);
            this.grpfind.Controls.Add(this.opOrders);
            this.grpfind.Controls.Add(this.opQuote);
            this.grpfind.Controls.Add(this.chkModel);
            this.grpfind.Controls.Add(this.txCMP);
            this.grpfind.Controls.Add(this.dpFrom);
            this.grpfind.Controls.Add(this.picCIP);
            this.grpfind.Controls.Add(this.lbldates);
            this.grpfind.Controls.Add(this.chkcat);
            this.grpfind.Controls.Add(this.lempID);
            this.grpfind.Controls.Add(this.btnRRev);
            this.grpfind.Controls.Add(this.dpTo);
            this.grpfind.Controls.Add(this.lOp);
            this.grpfind.Controls.Add(this.lTo);
            this.grpfind.Controls.Add(this.lcpnyID);
            this.grpfind.Controls.Add(this.btnQt);
            this.grpfind.Controls.Add(this.lfrom);
            this.grpfind.Controls.Add(this.grpQt);
            this.grpfind.Controls.Add(this.toolStrip1);
            this.grpfind.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpfind.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpfind.Location = new System.Drawing.Point(0, 0);
            this.grpfind.Name = "grpfind";
            this.grpfind.Size = new System.Drawing.Size(1468, 220);
            this.grpfind.TabIndex = 7;
            this.grpfind.TabStop = false;
            this.grpfind.Enter += new System.EventHandler(this.grpfind_Enter);
            // 
            // grpCharg
            // 
            this.grpCharg.Controls.Add(this.grpREC);
            this.grpCharg.Controls.Add(this.grpCH);
            this.grpCharg.Controls.Add(this.btnDispCols);
            this.grpCharg.Controls.Add(this.picFind);
            this.grpCharg.Controls.Add(this.tkeyHidn);
            this.grpCharg.Controls.Add(this.tkey_CHREC);
            this.grpCharg.Controls.Add(this.label11);
            this.grpCharg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCharg.Location = new System.Drawing.Point(729, 72);
            this.grpCharg.Name = "grpCharg";
            this.grpCharg.Size = new System.Drawing.Size(736, 143);
            this.grpCharg.TabIndex = 266;
            this.grpCharg.TabStop = false;
            this.grpCharg.Visible = false;
            // 
            // grpREC
            // 
            this.grpREC.Controls.Add(this.pnlRectif);
            this.grpREC.Location = new System.Drawing.Point(20, 23);
            this.grpREC.Name = "grpREC";
            this.grpREC.Size = new System.Drawing.Size(480, 63);
            this.grpREC.TabIndex = 217;
            this.grpREC.TabStop = false;
            this.grpREC.Visible = false;
            // 
            // pnlRectif
            // 
            this.pnlRectif.Controls.Add(this.lcbRectifiers);
            this.pnlRectif.Controls.Add(this.cbRectifiers);
            this.pnlRectif.Location = new System.Drawing.Point(6, 12);
            this.pnlRectif.Name = "pnlRectif";
            this.pnlRectif.Size = new System.Drawing.Size(468, 46);
            this.pnlRectif.TabIndex = 216;
            // 
            // lcbRectifiers
            // 
            this.lcbRectifiers.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcbRectifiers.ForeColor = System.Drawing.Color.Blue;
            this.lcbRectifiers.Location = new System.Drawing.Point(7, 13);
            this.lcbRectifiers.Name = "lcbRectifiers";
            this.lcbRectifiers.Size = new System.Drawing.Size(146, 20);
            this.lcbRectifiers.TabIndex = 231;
            this.lcbRectifiers.Text = "Select Rectifier";
            this.lcbRectifiers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbRectifiers
            // 
            this.cbRectifiers.BackColor = System.Drawing.Color.Lavender;
            this.cbRectifiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRectifiers.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbRectifiers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbRectifiers.Location = new System.Drawing.Point(153, 13);
            this.cbRectifiers.Name = "cbRectifiers";
            this.cbRectifiers.Size = new System.Drawing.Size(311, 22);
            this.cbRectifiers.TabIndex = 230;
            this.cbRectifiers.SelectedIndexChanged += new System.EventHandler(this.cbRectifiers_SelectedIndexChanged);
            // 
            // grpCH
            // 
            this.grpCH.Controls.Add(this.label12);
            this.grpCH.Controls.Add(this.pnlCharger);
            this.grpCH.Location = new System.Drawing.Point(14, 12);
            this.grpCH.Name = "grpCH";
            this.grpCH.Size = new System.Drawing.Size(585, 79);
            this.grpCH.TabIndex = 216;
            this.grpCH.TabStop = false;
            this.grpCH.Visible = false;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(6, 32);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(142, 20);
            this.label12.TabIndex = 232;
            this.label12.Text = "Select Charger";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnlCharger
            // 
            this.pnlCharger.Controls.Add(this.button1);
            this.pnlCharger.Controls.Add(this.label2);
            this.pnlCharger.Controls.Add(this.label3);
            this.pnlCharger.Controls.Add(this.label7);
            this.pnlCharger.Controls.Add(this.label8);
            this.pnlCharger.Controls.Add(this.label9);
            this.pnlCharger.Controls.Add(this.label10);
            this.pnlCharger.Controls.Add(this.cbPhs);
            this.pnlCharger.Controls.Add(this.label22);
            this.pnlCharger.Controls.Add(this.cbPxx);
            this.pnlCharger.Controls.Add(this.cbVdc);
            this.pnlCharger.Controls.Add(this.cbIdc);
            this.pnlCharger.Location = new System.Drawing.Point(148, 15);
            this.pnlCharger.Name = "pnlCharger";
            this.pnlCharger.Size = new System.Drawing.Size(431, 62);
            this.pnlCharger.TabIndex = 217;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.Color.Firebrick;
            this.button1.Location = new System.Drawing.Point(330, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 23);
            this.button1.TabIndex = 224;
            this.button1.Text = "ALL Chargers";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(101, 21);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(16, 31);
            this.label2.TabIndex = 223;
            this.label2.Text = "-";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(167, 21);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(16, 31);
            this.label3.TabIndex = 222;
            this.label3.Text = "-";
            this.label3.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(239, 21);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(16, 31);
            this.label7.TabIndex = 221;
            this.label7.Text = "-";
            this.label7.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Firebrick;
            this.label8.Location = new System.Drawing.Point(255, 7);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(41, 21);
            this.label8.TabIndex = 220;
            this.label8.Text = "IDC";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Firebrick;
            this.label9.Location = new System.Drawing.Point(185, 7);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 21);
            this.label9.TabIndex = 218;
            this.label9.Text = "VDC";
            this.label9.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Firebrick;
            this.label10.Location = new System.Drawing.Point(123, 7);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(40, 21);
            this.label10.TabIndex = 216;
            this.label10.Text = "PHS";
            this.label10.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cbPhs
            // 
            this.cbPhs.BackColor = System.Drawing.Color.Lavender;
            this.cbPhs.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPhs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPhs.ItemHeight = 13;
            this.cbPhs.Items.AddRange(new object[] {
            "ALL",
            "1",
            "3"});
            this.cbPhs.Location = new System.Drawing.Point(117, 28);
            this.cbPhs.Name = "cbPhs";
            this.cbPhs.Size = new System.Drawing.Size(50, 21);
            this.cbPhs.TabIndex = 215;
            this.cbPhs.SelectedIndexChanged += new System.EventHandler(this.cbPhs_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Firebrick;
            this.label22.Location = new System.Drawing.Point(16, 7);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 21);
            this.label22.TabIndex = 214;
            this.label22.Text = "PXXXX";
            this.label22.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cbPxx
            // 
            this.cbPxx.BackColor = System.Drawing.Color.Lavender;
            this.cbPxx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPxx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPxx.ItemHeight = 13;
            this.cbPxx.Location = new System.Drawing.Point(5, 28);
            this.cbPxx.Name = "cbPxx";
            this.cbPxx.Size = new System.Drawing.Size(96, 21);
            this.cbPxx.TabIndex = 213;
            this.cbPxx.SelectedIndexChanged += new System.EventHandler(this.cbPxx_SelectedIndexChanged);
            // 
            // cbVdc
            // 
            this.cbVdc.BackColor = System.Drawing.Color.Lavender;
            this.cbVdc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVdc.ItemHeight = 13;
            this.cbVdc.Location = new System.Drawing.Point(183, 28);
            this.cbVdc.MaxDropDownItems = 20;
            this.cbVdc.Name = "cbVdc";
            this.cbVdc.Size = new System.Drawing.Size(56, 21);
            this.cbVdc.TabIndex = 217;
            this.cbVdc.SelectedIndexChanged += new System.EventHandler(this.cbVdc_SelectedIndexChanged);
            // 
            // cbIdc
            // 
            this.cbIdc.BackColor = System.Drawing.Color.Lavender;
            this.cbIdc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIdc.ItemHeight = 13;
            this.cbIdc.Location = new System.Drawing.Point(255, 28);
            this.cbIdc.Name = "cbIdc";
            this.cbIdc.Size = new System.Drawing.Size(56, 21);
            this.cbIdc.TabIndex = 219;
            this.cbIdc.SelectedIndexChanged += new System.EventHandler(this.cbIdc_SelectedIndexChanged);
            // 
            // btnDispCols
            // 
            this.btnDispCols.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDispCols.ForeColor = System.Drawing.Color.Firebrick;
            this.btnDispCols.Location = new System.Drawing.Point(579, 119);
            this.btnDispCols.Name = "btnDispCols";
            this.btnDispCols.Size = new System.Drawing.Size(152, 23);
            this.btnDispCols.TabIndex = 267;
            this.btnDispCols.Text = "Display All Columns";
            this.btnDispCols.UseVisualStyleBackColor = true;
            this.btnDispCols.Click += new System.EventHandler(this.btnDispCols_Click);
            // 
            // picFind
            // 
            this.picFind.BackColor = System.Drawing.Color.AliceBlue;
            this.picFind.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picFind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picFind.Image = ((System.Drawing.Image)(resources.GetObject("picFind.Image")));
            this.picFind.Location = new System.Drawing.Point(605, 12);
            this.picFind.Name = "picFind";
            this.picFind.Size = new System.Drawing.Size(126, 78);
            this.picFind.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picFind.TabIndex = 266;
            this.picFind.TabStop = false;
            this.picFind.Click += new System.EventHandler(this.picFind_Click);
            // 
            // tkeyHidn
            // 
            this.tkeyHidn.BackColor = System.Drawing.Color.White;
            this.tkeyHidn.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tkeyHidn.ForeColor = System.Drawing.Color.Black;
            this.tkeyHidn.Location = new System.Drawing.Point(428, 95);
            this.tkeyHidn.MaxLength = 60;
            this.tkeyHidn.Name = "tkeyHidn";
            this.tkeyHidn.Size = new System.Drawing.Size(264, 20);
            this.tkeyHidn.TabIndex = 218;
            this.tkeyHidn.Visible = false;
            // 
            // tkey_CHREC
            // 
            this.tkey_CHREC.BackColor = System.Drawing.Color.PeachPuff;
            this.tkey_CHREC.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tkey_CHREC.ForeColor = System.Drawing.Color.Black;
            this.tkey_CHREC.Location = new System.Drawing.Point(107, 93);
            this.tkey_CHREC.MaxLength = 60;
            this.tkey_CHREC.Name = "tkey_CHREC";
            this.tkey_CHREC.Size = new System.Drawing.Size(321, 24);
            this.tkey_CHREC.TabIndex = 213;
            this.tkey_CHREC.TextChanged += new System.EventHandler(this.tkey_CHREC_TextChanged);
            this.tkey_CHREC.DoubleClick += new System.EventHandler(this.tkey_CHREC_DoubleClick);
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(10, 95);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(97, 20);
            this.label11.TabIndex = 214;
            this.label11.Text = "Keyword:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnl_terri
            // 
            this.pnl_terri.Controls.Add(this.lSnn);
            this.pnl_terri.Controls.Add(this.cbSales);
            this.pnl_terri.Controls.Add(this.label6);
            this.pnl_terri.Location = new System.Drawing.Point(6, 157);
            this.pnl_terri.Name = "pnl_terri";
            this.pnl_terri.Size = new System.Drawing.Size(394, 54);
            this.pnl_terri.TabIndex = 272;
            this.pnl_terri.Visible = false;
            // 
            // lSnn
            // 
            this.lSnn.BackColor = System.Drawing.Color.PaleGreen;
            this.lSnn.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lSnn.Location = new System.Drawing.Point(268, 33);
            this.lSnn.Name = "lSnn";
            this.lSnn.Size = new System.Drawing.Size(47, 16);
            this.lSnn.TabIndex = 358;
            this.lSnn.Text = "0";
            this.lSnn.Visible = false;
            // 
            // cbSales
            // 
            this.cbSales.BackColor = System.Drawing.Color.White;
            this.cbSales.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSales.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbSales.ForeColor = System.Drawing.Color.Black;
            this.cbSales.Location = new System.Drawing.Point(128, 9);
            this.cbSales.Name = "cbSales";
            this.cbSales.Size = new System.Drawing.Size(214, 21);
            this.cbSales.TabIndex = 357;
            this.cbSales.SelectedIndexChanged += new System.EventHandler(this.cbSales_SelectedIndexChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.CornflowerBlue;
            this.label6.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(10, 7);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(118, 24);
            this.label6.TabIndex = 212;
            this.label6.Text = "OutSide Sales:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // findQT
            // 
            this.findQT.BackColor = System.Drawing.Color.Moccasin;
            this.findQT.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.findQT.Cursor = System.Windows.Forms.Cursors.Hand;
            this.findQT.Image = ((System.Drawing.Image)(resources.GetObject("findQT.Image")));
            this.findQT.Location = new System.Drawing.Point(277, 76);
            this.findQT.Name = "findQT";
            this.findQT.Size = new System.Drawing.Size(119, 78);
            this.findQT.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.findQT.TabIndex = 271;
            this.findQT.TabStop = false;
            this.findQT.Click += new System.EventHandler(this.findQT_Click);
            // 
            // lvisi
            // 
            this.lvisi.BackColor = System.Drawing.Color.PaleGreen;
            this.lvisi.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lvisi.Location = new System.Drawing.Point(247, 173);
            this.lvisi.Name = "lvisi";
            this.lvisi.Size = new System.Drawing.Size(149, 16);
            this.lvisi.TabIndex = 270;
            this.lvisi.Text = "0";
            this.lvisi.Visible = false;
            // 
            // opOrders
            // 
            this.opOrders.AutoSize = true;
            this.opOrders.Location = new System.Drawing.Point(98, 191);
            this.opOrders.Name = "opOrders";
            this.opOrders.Size = new System.Drawing.Size(56, 17);
            this.opOrders.TabIndex = 269;
            this.opOrders.Text = "Orders";
            this.opOrders.UseVisualStyleBackColor = true;
            this.opOrders.Visible = false;
            this.opOrders.CheckedChanged += new System.EventHandler(this.opOrders_CheckedChanged);
            // 
            // opQuote
            // 
            this.opQuote.AutoSize = true;
            this.opQuote.Checked = true;
            this.opQuote.Location = new System.Drawing.Point(24, 191);
            this.opQuote.Name = "opQuote";
            this.opQuote.Size = new System.Drawing.Size(56, 17);
            this.opQuote.TabIndex = 268;
            this.opQuote.TabStop = true;
            this.opQuote.Text = "Orders";
            this.opQuote.UseVisualStyleBackColor = true;
            this.opQuote.Visible = false;
            this.opQuote.CheckedChanged += new System.EventHandler(this.opQuote_CheckedChanged);
            // 
            // chkModel
            // 
            this.chkModel.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkModel.Location = new System.Drawing.Point(223, 219);
            this.chkModel.Name = "chkModel";
            this.chkModel.Size = new System.Drawing.Size(98, 24);
            this.chkModel.TabIndex = 267;
            this.chkModel.Text = "Charger Model";
            this.chkModel.Visible = false;
            this.chkModel.CheckedChanged += new System.EventHandler(this.chkModel_CheckedChanged);
            // 
            // txCMP
            // 
            this.txCMP.Location = new System.Drawing.Point(12, 191);
            this.txCMP.Name = "txCMP";
            this.txCMP.Size = new System.Drawing.Size(187, 20);
            this.txCMP.TabIndex = 217;
            this.txCMP.Visible = false;
            this.txCMP.TextChanged += new System.EventHandler(this.txCMP_TextChanged);
            // 
            // dpFrom
            // 
            this.dpFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpFrom.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dpFrom.CalendarTitleBackColor = System.Drawing.Color.Lavender;
            this.dpFrom.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dpFrom.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFrom.Location = new System.Drawing.Point(152, 78);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(119, 23);
            this.dpFrom.TabIndex = 160;
            this.dpFrom.ValueChanged += new System.EventHandler(this.dpFrom_ValueChanged);
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(1016, 19);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(48, 44);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 265;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // lbldates
            // 
            this.lbldates.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lbldates.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbldates.ForeColor = System.Drawing.Color.White;
            this.lbldates.Location = new System.Drawing.Point(12, 76);
            this.lbldates.Name = "lbldates";
            this.lbldates.Size = new System.Drawing.Size(59, 24);
            this.lbldates.TabIndex = 211;
            this.lbldates.Text = "Period:";
            this.lbldates.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // chkcat
            // 
            this.chkcat.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkcat.Location = new System.Drawing.Point(142, 223);
            this.chkcat.Name = "chkcat";
            this.chkcat.Size = new System.Drawing.Size(75, 16);
            this.chkcat.TabIndex = 205;
            this.chkcat.Text = "Customers";
            this.chkcat.Visible = false;
            this.chkcat.CheckedChanged += new System.EventHandler(this.chkcat_CheckedChanged);
            // 
            // lempID
            // 
            this.lempID.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lempID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lempID.Location = new System.Drawing.Point(784, 16);
            this.lempID.Name = "lempID";
            this.lempID.Size = new System.Drawing.Size(24, 16);
            this.lempID.TabIndex = 172;
            this.lempID.Text = "0";
            this.lempID.Visible = false;
            // 
            // btnRRev
            // 
            this.btnRRev.BackColor = System.Drawing.Color.PowderBlue;
            this.btnRRev.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnRRev.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRRev.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnRRev.Image = ((System.Drawing.Image)(resources.GetObject("btnRRev.Image")));
            this.btnRRev.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnRRev.Location = new System.Drawing.Point(928, 10);
            this.btnRRev.Name = "btnRRev";
            this.btnRRev.Size = new System.Drawing.Size(24, 24);
            this.btnRRev.TabIndex = 163;
            this.btnRRev.Text = "Projects";
            this.btnRRev.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnRRev.UseVisualStyleBackColor = false;
            this.btnRRev.Visible = false;
            // 
            // dpTo
            // 
            this.dpTo.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dpTo.CalendarTitleBackColor = System.Drawing.Color.Lavender;
            this.dpTo.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dpTo.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpTo.Location = new System.Drawing.Point(152, 104);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(119, 23);
            this.dpTo.TabIndex = 162;
            // 
            // lOp
            // 
            this.lOp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lOp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lOp.Location = new System.Drawing.Point(296, 140);
            this.lOp.Name = "lOp";
            this.lOp.Size = new System.Drawing.Size(24, 16);
            this.lOp.TabIndex = 177;
            this.lOp.Text = "A";
            this.lOp.Visible = false;
            // 
            // lTo
            // 
            this.lTo.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTo.ForeColor = System.Drawing.Color.Firebrick;
            this.lTo.Location = new System.Drawing.Point(87, 104);
            this.lTo.Name = "lTo";
            this.lTo.Size = new System.Drawing.Size(65, 21);
            this.lTo.TabIndex = 161;
            this.lTo.Text = "TO:";
            this.lTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcpnyID
            // 
            this.lcpnyID.BackColor = System.Drawing.Color.PaleGreen;
            this.lcpnyID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lcpnyID.Location = new System.Drawing.Point(326, 140);
            this.lcpnyID.Name = "lcpnyID";
            this.lcpnyID.Size = new System.Drawing.Size(24, 16);
            this.lcpnyID.TabIndex = 171;
            this.lcpnyID.Text = "0";
            this.lcpnyID.Visible = false;
            // 
            // btnQt
            // 
            this.btnQt.BackColor = System.Drawing.Color.PowderBlue;
            this.btnQt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnQt.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnQt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnQt.Image = ((System.Drawing.Image)(resources.GetObject("btnQt.Image")));
            this.btnQt.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnQt.Location = new System.Drawing.Point(920, 32);
            this.btnQt.Name = "btnQt";
            this.btnQt.Size = new System.Drawing.Size(32, 24);
            this.btnQt.TabIndex = 158;
            this.btnQt.Text = "Quotes";
            this.btnQt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnQt.UseVisualStyleBackColor = false;
            this.btnQt.Visible = false;
            this.btnQt.Click += new System.EventHandler(this.btnQt_Click);
            // 
            // lfrom
            // 
            this.lfrom.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lfrom.ForeColor = System.Drawing.Color.Firebrick;
            this.lfrom.Location = new System.Drawing.Point(81, 78);
            this.lfrom.Name = "lfrom";
            this.lfrom.Size = new System.Drawing.Size(68, 23);
            this.lfrom.TabIndex = 157;
            this.lfrom.Text = "FROM:";
            this.lfrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpQt
            // 
            this.grpQt.Controls.Add(this.opQP);
            this.grpQt.Controls.Add(this.opQt);
            this.grpQt.Location = new System.Drawing.Point(928, 64);
            this.grpQt.Name = "grpQt";
            this.grpQt.Size = new System.Drawing.Size(32, 40);
            this.grpQt.TabIndex = 180;
            this.grpQt.TabStop = false;
            this.grpQt.Visible = false;
            // 
            // opQP
            // 
            this.opQP.Checked = true;
            this.opQP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opQP.ForeColor = System.Drawing.Color.Blue;
            this.opQP.Location = new System.Drawing.Point(88, 8);
            this.opQP.Name = "opQP";
            this.opQP.Size = new System.Drawing.Size(200, 20);
            this.opQP.TabIndex = 183;
            this.opQP.TabStop = true;
            this.opQP.Text = "Quotes converted to Projects";
            // 
            // opQt
            // 
            this.opQt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opQt.ForeColor = System.Drawing.Color.Red;
            this.opQt.Location = new System.Drawing.Point(8, 8);
            this.opQt.Name = "opQt";
            this.opQt.Size = new System.Drawing.Size(72, 20);
            this.opQt.TabIndex = 182;
            this.opQt.Text = "Quotes";
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LemonChiffon;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.picQT,
            this.picOrders,
            this.toolStripSeparator1,
            this.picQvsP,
            this.tlsbtn_Cust,
            this.tls_terri,
            this.toolStripButton2,
            this.tlsbtnRectif,
            this.toolStripButton1,
            this.toolStripSeparator2,
            this.picXL,
            this.exit});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1462, 54);
            this.toolStrip1.TabIndex = 209;
            this.toolStrip1.Text = "   Exit   ";
            // 
            // picQT
            // 
            this.picQT.BackColor = System.Drawing.Color.LemonChiffon;
            this.picQT.Image = ((System.Drawing.Image)(resources.GetObject("picQT.Image")));
            this.picQT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.picQT.Name = "picQT";
            this.picQT.Size = new System.Drawing.Size(49, 51);
            this.picQT.Text = "Quotes";
            this.picQT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.picQT.Click += new System.EventHandler(this.picQT_Click);
            // 
            // picOrders
            // 
            this.picOrders.Image = ((System.Drawing.Image)(resources.GetObject("picOrders.Image")));
            this.picOrders.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.picOrders.Name = "picOrders";
            this.picOrders.Size = new System.Drawing.Size(53, 51);
            this.picOrders.Text = "Projects";
            this.picOrders.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.picOrders.Click += new System.EventHandler(this.picOrders_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // picQvsP
            // 
            this.picQvsP.Image = ((System.Drawing.Image)(resources.GetObject("picQvsP.Image")));
            this.picQvsP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.picQvsP.Name = "picQvsP";
            this.picQvsP.Size = new System.Drawing.Size(110, 51);
            this.picQvsP.Text = "Quotes VS Projects";
            this.picQvsP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.picQvsP.Visible = false;
            this.picQvsP.Click += new System.EventHandler(this.picQvsP_Click);
            // 
            // tlsbtn_Cust
            // 
            this.tlsbtn_Cust.Image = ((System.Drawing.Image)(resources.GetObject("tlsbtn_Cust.Image")));
            this.tlsbtn_Cust.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsbtn_Cust.Name = "tlsbtn_Cust";
            this.tlsbtn_Cust.Size = new System.Drawing.Size(109, 51);
            this.tlsbtn_Cust.Text = "Advanced Options";
            this.tlsbtn_Cust.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsbtn_Cust.Click += new System.EventHandler(this.tlsbtn_Cust_Click);
            // 
            // tls_terri
            // 
            this.tls_terri.Image = ((System.Drawing.Image)(resources.GetObject("tls_terri.Image")));
            this.tls_terri.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_terri.Name = "tls_terri";
            this.tls_terri.Size = new System.Drawing.Size(144, 51);
            this.tls_terri.Text = "Territories / Outside Sales";
            this.tls_terri.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_terri.Click += new System.EventHandler(this.tls_terri_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(58, 51);
            this.toolStripButton2.Text = "Chargers";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Visible = false;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // tlsbtnRectif
            // 
            this.tlsbtnRectif.Image = ((System.Drawing.Image)(resources.GetObject("tlsbtnRectif.Image")));
            this.tlsbtnRectif.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsbtnRectif.Name = "tlsbtnRectif";
            this.tlsbtnRectif.Size = new System.Drawing.Size(59, 51);
            this.tlsbtnRectif.Text = "Rectifiers";
            this.tlsbtnRectif.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsbtnRectif.Visible = false;
            this.tlsbtnRectif.Click += new System.EventHandler(this.tlsbtnRectif_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(71, 51);
            this.toolStripButton1.Text = "All Systems";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // picXL
            // 
            this.picXL.Image = ((System.Drawing.Image)(resources.GetObject("picXL.Image")));
            this.picXL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.picXL.Name = "picXL";
            this.picXL.Size = new System.Drawing.Size(87, 51);
            this.picXL.Text = "Export to Excel";
            this.picXL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.picXL.Click += new System.EventHandler(this.picXL_Click);
            // 
            // exit
            // 
            this.exit.Image = ((System.Drawing.Image)(resources.GetObject("exit.Image")));
            this.exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exit.Name = "exit";
            this.exit.Size = new System.Drawing.Size(36, 51);
            this.exit.Text = "Exit";
            this.exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exit.Click += new System.EventHandler(this.exit_Click);
            // 
            // grpAdv
            // 
            this.grpAdv.Controls.Add(this.cbCompany);
            this.grpAdv.Controls.Add(this.lAM_TO);
            this.grpAdv.Controls.Add(this.lAM_FM);
            this.grpAdv.Controls.Add(this.txAMNT_T);
            this.grpAdv.Controls.Add(this.txAMNT_F);
            this.grpAdv.Controls.Add(this.label14);
            this.grpAdv.Controls.Add(this.label16);
            this.grpAdv.Controls.Add(this.chSN);
            this.grpAdv.Controls.Add(this.picEx2);
            this.grpAdv.Controls.Add(this.label1);
            this.grpAdv.Controls.Add(this.picEX);
            this.grpAdv.Controls.Add(this.lv_Ex);
            this.grpAdv.Controls.Add(this.grpDates);
            this.grpAdv.Controls.Add(this.cbEmploy);
            this.grpAdv.Controls.Add(this.picSeek);
            this.grpAdv.Controls.Add(this.lcpny);
            this.grpAdv.Controls.Add(this.lemp);
            this.grpAdv.Controls.Add(this.grpcat);
            this.grpAdv.Controls.Add(this.tKey);
            this.grpAdv.Location = new System.Drawing.Point(402, 72);
            this.grpAdv.Name = "grpAdv";
            this.grpAdv.Size = new System.Drawing.Size(656, 143);
            this.grpAdv.TabIndex = 210;
            this.grpAdv.TabStop = false;
            this.grpAdv.Visible = false;
            // 
            // cbCompany
            // 
            this.cbCompany.BackColor = System.Drawing.Color.Lavender;
            this.cbCompany.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompany.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCompany.Location = new System.Drawing.Point(63, 8);
            this.cbCompany.Name = "cbCompany";
            this.cbCompany.Size = new System.Drawing.Size(281, 21);
            this.cbCompany.TabIndex = 164;
            this.cbCompany.SelectedIndexChanged += new System.EventHandler(this.cbCompany_SelectedIndexChanged);
            // 
            // lAM_TO
            // 
            this.lAM_TO.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lAM_TO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lAM_TO.Location = new System.Drawing.Point(285, 85);
            this.lAM_TO.Name = "lAM_TO";
            this.lAM_TO.Size = new System.Drawing.Size(34, 19);
            this.lAM_TO.TabIndex = 223;
            this.lAM_TO.Text = "0";
            this.lAM_TO.Visible = false;
            // 
            // lAM_FM
            // 
            this.lAM_FM.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lAM_FM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lAM_FM.Location = new System.Drawing.Point(285, 57);
            this.lAM_FM.Name = "lAM_FM";
            this.lAM_FM.Size = new System.Drawing.Size(34, 19);
            this.lAM_FM.TabIndex = 222;
            this.lAM_FM.Text = "0";
            this.lAM_FM.Visible = false;
            // 
            // txAMNT_T
            // 
            this.txAMNT_T.Location = new System.Drawing.Point(111, 85);
            this.txAMNT_T.Name = "txAMNT_T";
            this.txAMNT_T.Size = new System.Drawing.Size(168, 20);
            this.txAMNT_T.TabIndex = 221;
            this.txAMNT_T.Text = "0";
            this.txAMNT_T.TextChanged += new System.EventHandler(this.txAMNT_T_TextChanged);
            // 
            // txAMNT_F
            // 
            this.txAMNT_F.Location = new System.Drawing.Point(111, 58);
            this.txAMNT_F.Name = "txAMNT_F";
            this.txAMNT_F.Size = new System.Drawing.Size(168, 20);
            this.txAMNT_F.TabIndex = 220;
            this.txAMNT_F.Text = "0";
            this.txAMNT_F.TextChanged += new System.EventHandler(this.txAMNT_F_TextChanged);
            // 
            // label14
            // 
            this.label14.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.Color.DarkRed;
            this.label14.Location = new System.Drawing.Point(46, 86);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(65, 18);
            this.label14.TabIndex = 219;
            this.label14.Text = "TO: $";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Transparent;
            this.label16.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.Color.DarkRed;
            this.label16.Location = new System.Drawing.Point(0, 56);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(111, 23);
            this.label16.TabIndex = 218;
            this.label16.Text = "Amount FROM: $";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chSN
            // 
            this.chSN.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chSN.Location = new System.Drawing.Point(6, 121);
            this.chSN.Name = "chSN";
            this.chSN.Size = new System.Drawing.Size(136, 16);
            this.chSN.TabIndex = 217;
            this.chSN.Text = "Include items with SN";
            this.chSN.Visible = false;
            this.chSN.CheckedChanged += new System.EventHandler(this.chSN_CheckedChanged);
            // 
            // picEx2
            // 
            this.picEx2.BackColor = System.Drawing.Color.Transparent;
            this.picEx2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEx2.Image = ((System.Drawing.Image)(resources.GetObject("picEx2.Image")));
            this.picEx2.Location = new System.Drawing.Point(350, 96);
            this.picEx2.Name = "picEx2";
            this.picEx2.Size = new System.Drawing.Size(43, 25);
            this.picEx2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEx2.TabIndex = 216;
            this.picEx2.TabStop = false;
            this.picEx2.Click += new System.EventHandler(this.picEx2_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(443, 8);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 20);
            this.label1.TabIndex = 215;
            this.label1.Text = " Excluded Companies";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picEX
            // 
            this.picEX.BackColor = System.Drawing.Color.Transparent;
            this.picEX.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picEX.Image = ((System.Drawing.Image)(resources.GetObject("picEX.Image")));
            this.picEX.Location = new System.Drawing.Point(350, 65);
            this.picEX.Name = "picEX";
            this.picEX.Size = new System.Drawing.Size(43, 25);
            this.picEX.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picEX.TabIndex = 214;
            this.picEX.TabStop = false;
            this.picEX.Click += new System.EventHandler(this.picEX_Click);
            // 
            // lv_Ex
            // 
            this.lv_Ex.BackColor = System.Drawing.Color.MintCream;
            this.lv_Ex.FormattingEnabled = true;
            this.lv_Ex.Location = new System.Drawing.Point(399, 28);
            this.lv_Ex.Name = "lv_Ex";
            this.lv_Ex.Size = new System.Drawing.Size(246, 108);
            this.lv_Ex.TabIndex = 213;
            // 
            // grpDates
            // 
            this.grpDates.Controls.Add(this.optrdrDate);
            this.grpDates.Controls.Add(this.optshpDate);
            this.grpDates.Controls.Add(this.optInvdate);
            this.grpDates.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.grpDates.Location = new System.Drawing.Point(7, 149);
            this.grpDates.Name = "grpDates";
            this.grpDates.Size = new System.Drawing.Size(269, 48);
            this.grpDates.TabIndex = 212;
            this.grpDates.TabStop = false;
            this.grpDates.Text = "Project Dates:";
            this.grpDates.Visible = false;
            // 
            // optrdrDate
            // 
            this.optrdrDate.Checked = true;
            this.optrdrDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optrdrDate.Location = new System.Drawing.Point(10, 19);
            this.optrdrDate.Name = "optrdrDate";
            this.optrdrDate.Size = new System.Drawing.Size(87, 20);
            this.optrdrDate.TabIndex = 181;
            this.optrdrDate.TabStop = true;
            this.optrdrDate.Text = "Order date";
            this.optrdrDate.CheckedChanged += new System.EventHandler(this.optrdrDate_CheckedChanged);
            // 
            // optshpDate
            // 
            this.optshpDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optshpDate.Location = new System.Drawing.Point(190, 21);
            this.optshpDate.Name = "optshpDate";
            this.optshpDate.Size = new System.Drawing.Size(70, 16);
            this.optshpDate.TabIndex = 180;
            this.optshpDate.Text = "Ship date";
            this.optshpDate.CheckedChanged += new System.EventHandler(this.optshpDate_CheckedChanged);
            // 
            // optInvdate
            // 
            this.optInvdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optInvdate.Location = new System.Drawing.Point(97, 19);
            this.optInvdate.Name = "optInvdate";
            this.optInvdate.Size = new System.Drawing.Size(93, 20);
            this.optInvdate.TabIndex = 175;
            this.optInvdate.Text = "invoice date";
            this.optInvdate.CheckedChanged += new System.EventHandler(this.optInvdate_CheckedChanged);
            // 
            // cbEmploy
            // 
            this.cbEmploy.BackColor = System.Drawing.Color.Lavender;
            this.cbEmploy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEmploy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbEmploy.Location = new System.Drawing.Point(85, 29);
            this.cbEmploy.Name = "cbEmploy";
            this.cbEmploy.Size = new System.Drawing.Size(234, 21);
            this.cbEmploy.TabIndex = 169;
            this.cbEmploy.SelectedIndexChanged += new System.EventHandler(this.cbEmploy_SelectedIndexChanged);
            // 
            // picSeek
            // 
            this.picSeek.BackColor = System.Drawing.Color.Transparent;
            this.picSeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSeek.Image = ((System.Drawing.Image)(resources.GetObject("picSeek.Image")));
            this.picSeek.Location = new System.Drawing.Point(350, 8);
            this.picSeek.Name = "picSeek";
            this.picSeek.Size = new System.Drawing.Size(43, 24);
            this.picSeek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSeek.TabIndex = 166;
            this.picSeek.TabStop = false;
            this.picSeek.Click += new System.EventHandler(this.picSeek_Click);
            // 
            // lcpny
            // 
            this.lcpny.BackColor = System.Drawing.Color.Transparent;
            this.lcpny.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lcpny.ForeColor = System.Drawing.Color.Black;
            this.lcpny.Location = new System.Drawing.Point(12, 9);
            this.lcpny.Name = "lcpny";
            this.lcpny.Size = new System.Drawing.Size(61, 19);
            this.lcpny.TabIndex = 168;
            this.lcpny.Text = "Company:";
            this.lcpny.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lcpny.Click += new System.EventHandler(this.lcpny_Click);
            this.lcpny.DoubleClick += new System.EventHandler(this.lcpny_DoubleClick);
            // 
            // lemp
            // 
            this.lemp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lemp.ForeColor = System.Drawing.Color.Black;
            this.lemp.Location = new System.Drawing.Point(10, 27);
            this.lemp.Name = "lemp";
            this.lemp.Size = new System.Drawing.Size(75, 24);
            this.lemp.TabIndex = 170;
            this.lemp.Text = "Inside Sales:";
            this.lemp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpcat
            // 
            this.grpcat.Controls.Add(this.optInv);
            this.grpcat.Controls.Add(this.opSHP_TSTnc);
            this.grpcat.Controls.Add(this.opInP);
            this.grpcat.Controls.Add(this.opAll);
            this.grpcat.Controls.Add(this.opSHP);
            this.grpcat.Controls.Add(this.opFapp);
            this.grpcat.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpcat.Location = new System.Drawing.Point(148, 115);
            this.grpcat.Name = "grpcat";
            this.grpcat.Size = new System.Drawing.Size(143, 22);
            this.grpcat.TabIndex = 202;
            this.grpcat.TabStop = false;
            this.grpcat.Text = "Project satus:";
            this.grpcat.Visible = false;
            // 
            // optInv
            // 
            this.optInv.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optInv.Location = new System.Drawing.Point(50, 41);
            this.optInv.Name = "optInv";
            this.optInv.Size = new System.Drawing.Size(69, 20);
            this.optInv.TabIndex = 181;
            this.optInv.Text = "Invoiced";
            this.optInv.Visible = false;
            this.optInv.CheckedChanged += new System.EventHandler(this.optInv_CheckedChanged);
            // 
            // opSHP_TSTnc
            // 
            this.opSHP_TSTnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opSHP_TSTnc.Location = new System.Drawing.Point(91, 86);
            this.opSHP_TSTnc.Name = "opSHP_TSTnc";
            this.opSHP_TSTnc.Size = new System.Drawing.Size(138, 18);
            this.opSHP_TSTnc.TabIndex = 180;
            this.opSHP_TSTnc.Text = "Shipped with SN";
            this.opSHP_TSTnc.Visible = false;
            this.opSHP_TSTnc.CheckedChanged += new System.EventHandler(this.opSHP_TSTnc_CheckedChanged);
            // 
            // opInP
            // 
            this.opInP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opInP.ForeColor = System.Drawing.Color.Blue;
            this.opInP.Location = new System.Drawing.Point(179, 20);
            this.opInP.Name = "opInP";
            this.opInP.Size = new System.Drawing.Size(81, 20);
            this.opInP.TabIndex = 174;
            this.opInP.Text = "In Process";
            this.opInP.CheckedChanged += new System.EventHandler(this.opInP_CheckedChanged);
            // 
            // opAll
            // 
            this.opAll.Checked = true;
            this.opAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opAll.Location = new System.Drawing.Point(10, 19);
            this.opAll.Name = "opAll";
            this.opAll.Size = new System.Drawing.Size(43, 22);
            this.opAll.TabIndex = 176;
            this.opAll.TabStop = true;
            this.opAll.Text = "All projects";
            this.opAll.CheckedChanged += new System.EventHandler(this.opAll_CheckedChanged);
            // 
            // opSHP
            // 
            this.opSHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opSHP.Location = new System.Drawing.Point(148, 42);
            this.opSHP.Name = "opSHP";
            this.opSHP.Size = new System.Drawing.Size(64, 20);
            this.opSHP.TabIndex = 175;
            this.opSHP.Text = "Shipped ";
            this.opSHP.Visible = false;
            this.opSHP.CheckedChanged += new System.EventHandler(this.opSHP_CheckedChanged);
            // 
            // opFapp
            // 
            this.opFapp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opFapp.ForeColor = System.Drawing.Color.Red;
            this.opFapp.Location = new System.Drawing.Point(81, 20);
            this.opFapp.Name = "opFapp";
            this.opFapp.Size = new System.Drawing.Size(98, 20);
            this.opFapp.TabIndex = 178;
            this.opFapp.Text = "For Approval";
            this.opFapp.CheckedChanged += new System.EventHandler(this.opFapp_CheckedChanged);
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.DarkSalmon;
            this.tKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.ForeColor = System.Drawing.Color.Blue;
            this.tKey.Location = new System.Drawing.Point(71, 8);
            this.tKey.MaxLength = 60;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(273, 20);
            this.tKey.TabIndex = 165;
            // 
            // tSQL
            // 
            this.tSQL.Location = new System.Drawing.Point(24, 166);
            this.tSQL.Name = "tSQL";
            this.tSQL.Size = new System.Drawing.Size(1432, 20);
            this.tSQL.TabIndex = 181;
            this.tSQL.Visible = false;
            this.tSQL.TextChanged += new System.EventHandler(this.tSQL_TextChanged);
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
            // 
            // grpTot
            // 
            this.grpTot.Controls.Add(this.grpQvsR);
            this.grpTot.Controls.Add(this.grpTOTqo);
            this.grpTot.Controls.Add(this.groupBox4);
            this.grpTot.Controls.Add(this.grpTOTsys);
            this.grpTot.Controls.Add(this.groupBox3);
            this.grpTot.Controls.Add(this.grpCurr);
            this.grpTot.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.grpTot.ForeColor = System.Drawing.Color.Blue;
            this.grpTot.Location = new System.Drawing.Point(0, 515);
            this.grpTot.Name = "grpTot";
            this.grpTot.Size = new System.Drawing.Size(1468, 143);
            this.grpTot.TabIndex = 12;
            this.grpTot.TabStop = false;
            // 
            // grpQvsR
            // 
            this.grpQvsR.Controls.Add(this.edlv_QvsOR);
            this.grpQvsR.ForeColor = System.Drawing.Color.Blue;
            this.grpQvsR.Location = new System.Drawing.Point(1008, 8);
            this.grpQvsR.Name = "grpQvsR";
            this.grpQvsR.Size = new System.Drawing.Size(457, 128);
            this.grpQvsR.TabIndex = 255;
            this.grpQvsR.TabStop = false;
            this.grpQvsR.Text = "Quotes VS  Orders";
            this.grpQvsR.Visible = false;
            // 
            // edlv_QvsOR
            // 
            this.edlv_QvsOR.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.edlv_QvsOR.AutoArrange = false;
            this.edlv_QvsOR.BackColor = System.Drawing.Color.LightCyan;
            this.edlv_QvsOR.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6});
            this.edlv_QvsOR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edlv_QvsOR.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edlv_QvsOR.ForeColor = System.Drawing.Color.Black;
            this.edlv_QvsOR.FullRowSelect = true;
            this.edlv_QvsOR.GridLines = true;
            this.edlv_QvsOR.Location = new System.Drawing.Point(3, 16);
            this.edlv_QvsOR.Name = "edlv_QvsOR";
            this.edlv_QvsOR.Size = new System.Drawing.Size(451, 109);
            this.edlv_QvsOR.TabIndex = 252;
            this.edlv_QvsOR.UseCompatibleStateImageBehavior = false;
            this.edlv_QvsOR.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 99;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "#";
            this.columnHeader4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.columnHeader4.Width = 75;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "CAD Amount";
            this.columnHeader5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader5.Width = 137;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "Average";
            this.columnHeader6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.columnHeader6.Width = 123;
            // 
            // grpTOTqo
            // 
            this.grpTOTqo.Controls.Add(this.edlv_QtOr);
            this.grpTOTqo.ForeColor = System.Drawing.Color.Red;
            this.grpTOTqo.Location = new System.Drawing.Point(494, 8);
            this.grpTOTqo.Name = "grpTOTqo";
            this.grpTOTqo.Size = new System.Drawing.Size(514, 128);
            this.grpTOTqo.TabIndex = 252;
            this.grpTOTqo.TabStop = false;
            this.grpTOTqo.Text = "Quotes VS  Succ. Quotes";
            this.grpTOTqo.Visible = false;
            // 
            // edlv_QtOr
            // 
            this.edlv_QtOr.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.edlv_QtOr.AutoArrange = false;
            this.edlv_QtOr.BackColor = System.Drawing.Color.Cornsilk;
            this.edlv_QtOr.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.txt,
            this.colNB,
            this.colAM,
            this.colAVRG});
            this.edlv_QtOr.Dock = System.Windows.Forms.DockStyle.Fill;
            this.edlv_QtOr.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.edlv_QtOr.ForeColor = System.Drawing.Color.Black;
            this.edlv_QtOr.FullRowSelect = true;
            this.edlv_QtOr.GridLines = true;
            this.edlv_QtOr.Location = new System.Drawing.Point(3, 16);
            this.edlv_QtOr.Name = "edlv_QtOr";
            this.edlv_QtOr.Size = new System.Drawing.Size(508, 109);
            this.edlv_QtOr.TabIndex = 252;
            this.edlv_QtOr.UseCompatibleStateImageBehavior = false;
            this.edlv_QtOr.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 0;
            // 
            // txt
            // 
            this.txt.Text = "";
            this.txt.Width = 127;
            // 
            // colNB
            // 
            this.colNB.Text = "#";
            this.colNB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.colNB.Width = 83;
            // 
            // colAM
            // 
            this.colAM.Text = "CAD Amount";
            this.colAM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colAM.Width = 150;
            // 
            // colAVRG
            // 
            this.colAVRG.Text = "Average";
            this.colAVRG.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.colAVRG.Width = 123;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ed_tot_ratios);
            this.groupBox4.Location = new System.Drawing.Point(686, 140);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(378, 90);
            this.groupBox4.TabIndex = 254;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Quotes VS Orders";
            this.groupBox4.Visible = false;
            // 
            // ed_tot_ratios
            // 
            this.ed_tot_ratios.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_tot_ratios.AutoArrange = false;
            this.ed_tot_ratios.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ed_tot_ratios.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.id,
            this.yy,
            this.volume,
            this.Moy,
            this.nb});
            this.ed_tot_ratios.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_tot_ratios.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_tot_ratios.ForeColor = System.Drawing.Color.Black;
            this.ed_tot_ratios.FullRowSelect = true;
            this.ed_tot_ratios.GridLines = true;
            listViewItem1.UseItemStyleForSubItems = false;
            listViewItem2.UseItemStyleForSubItems = false;
            listViewItem3.UseItemStyleForSubItems = false;
            this.ed_tot_ratios.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3});
            this.ed_tot_ratios.Location = new System.Drawing.Point(3, 16);
            this.ed_tot_ratios.Name = "ed_tot_ratios";
            this.ed_tot_ratios.Size = new System.Drawing.Size(372, 71);
            this.ed_tot_ratios.TabIndex = 251;
            this.ed_tot_ratios.UseCompatibleStateImageBehavior = false;
            this.ed_tot_ratios.View = System.Windows.Forms.View.Details;
            // 
            // id
            // 
            this.id.DisplayIndex = 4;
            this.id.Text = "";
            this.id.Width = 0;
            // 
            // yy
            // 
            this.yy.DisplayIndex = 0;
            this.yy.Text = "";
            this.yy.Width = 85;
            // 
            // volume
            // 
            this.volume.DisplayIndex = 1;
            this.volume.Text = "$$ Amount";
            this.volume.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.volume.Width = 195;
            // 
            // Moy
            // 
            this.Moy.DisplayIndex = 2;
            this.Moy.Text = "Average";
            this.Moy.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Moy.Width = 163;
            // 
            // nb
            // 
            this.nb.DisplayIndex = 3;
            this.nb.Text = "#";
            this.nb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.nb.Width = 138;
            // 
            // grpTOTsys
            // 
            this.grpTOTsys.Controls.Add(this.label13);
            this.grpTOTsys.Controls.Add(this.label15);
            this.grpTOTsys.Controls.Add(this.lTOTnb);
            this.grpTOTsys.Controls.Add(this.lTOTSYS);
            this.grpTOTsys.Controls.Add(this.label19);
            this.grpTOTsys.Location = new System.Drawing.Point(655, 187);
            this.grpTOTsys.Name = "grpTOTsys";
            this.grpTOTsys.Size = new System.Drawing.Size(420, 63);
            this.grpTOTsys.TabIndex = 174;
            this.grpTOTsys.TabStop = false;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Transparent;
            this.label13.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label13.ForeColor = System.Drawing.Color.Red;
            this.label13.Location = new System.Drawing.Point(271, 7);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(77, 18);
            this.label13.TabIndex = 183;
            this.label13.Text = "TOTAL Cost";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label15
            // 
            this.label15.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.label15.ForeColor = System.Drawing.Color.Red;
            this.label15.Location = new System.Drawing.Point(111, 8);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 18);
            this.label15.TabIndex = 181;
            this.label15.Text = "   TOTAL #   ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lTOTnb
            // 
            this.lTOTnb.BackColor = System.Drawing.Color.LightSalmon;
            this.lTOTnb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lTOTnb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTOTnb.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lTOTnb.Location = new System.Drawing.Point(81, 26);
            this.lTOTnb.Name = "lTOTnb";
            this.lTOTnb.Size = new System.Drawing.Size(127, 20);
            this.lTOTnb.TabIndex = 180;
            this.lTOTnb.Text = "0";
            this.lTOTnb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lTOTSYS
            // 
            this.lTOTSYS.BackColor = System.Drawing.Color.LightSalmon;
            this.lTOTSYS.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lTOTSYS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTOTSYS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lTOTSYS.Location = new System.Drawing.Point(242, 25);
            this.lTOTSYS.Name = "lTOTSYS";
            this.lTOTSYS.Size = new System.Drawing.Size(155, 20);
            this.lTOTSYS.TabIndex = 178;
            this.lTOTSYS.Text = "0";
            this.lTOTSYS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label19
            // 
            this.label19.Font = new System.Drawing.Font("Book Antiqua", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.Color.DarkRed;
            this.label19.Location = new System.Drawing.Point(6, 26);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(69, 20);
            this.label19.TabIndex = 177;
            this.label19.Text = "TOTALS:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lSucc);
            this.groupBox3.Controls.Add(this.lSucc0);
            this.groupBox3.Controls.Add(this.lAvrg);
            this.groupBox3.Controls.Add(this.lav);
            this.groupBox3.Controls.Add(this.lProjNB);
            this.groupBox3.Controls.Add(this.lProjNB0);
            this.groupBox3.Controls.Add(this.lNBQ);
            this.groupBox3.Controls.Add(this.lQ);
            this.groupBox3.Location = new System.Drawing.Point(11, 194);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(603, 90);
            this.groupBox3.TabIndex = 173;
            this.groupBox3.TabStop = false;
            // 
            // lSucc
            // 
            this.lSucc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lSucc.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSucc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lSucc.Location = new System.Drawing.Point(278, 17);
            this.lSucc.Name = "lSucc";
            this.lSucc.Size = new System.Drawing.Size(64, 20);
            this.lSucc.TabIndex = 179;
            this.lSucc.Text = "0";
            this.lSucc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lSucc.Visible = false;
            // 
            // lSucc0
            // 
            this.lSucc0.Font = new System.Drawing.Font("Arial", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSucc0.ForeColor = System.Drawing.Color.Red;
            this.lSucc0.Location = new System.Drawing.Point(342, 17);
            this.lSucc0.Name = "lSucc0";
            this.lSucc0.Size = new System.Drawing.Size(24, 20);
            this.lSucc0.TabIndex = 178;
            this.lSucc0.Text = "%";
            this.lSucc0.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lSucc0.Visible = false;
            // 
            // lAvrg
            // 
            this.lAvrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lAvrg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAvrg.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lAvrg.Location = new System.Drawing.Point(475, 17);
            this.lAvrg.Name = "lAvrg";
            this.lAvrg.Size = new System.Drawing.Size(121, 20);
            this.lAvrg.TabIndex = 177;
            this.lAvrg.Text = "0";
            this.lAvrg.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lav
            // 
            this.lav.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lav.ForeColor = System.Drawing.Color.Red;
            this.lav.Location = new System.Drawing.Point(367, 16);
            this.lav.Name = "lav";
            this.lav.Size = new System.Drawing.Size(112, 20);
            this.lav.TabIndex = 176;
            this.lav.Text = "Average Amount:";
            this.lav.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lProjNB
            // 
            this.lProjNB.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lProjNB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lProjNB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lProjNB.Location = new System.Drawing.Point(208, 16);
            this.lProjNB.Name = "lProjNB";
            this.lProjNB.Size = new System.Drawing.Size(56, 20);
            this.lProjNB.TabIndex = 175;
            this.lProjNB.Text = "0";
            this.lProjNB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lProjNB.Visible = false;
            // 
            // lProjNB0
            // 
            this.lProjNB0.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lProjNB0.ForeColor = System.Drawing.Color.Red;
            this.lProjNB0.Location = new System.Drawing.Point(134, 17);
            this.lProjNB0.Name = "lProjNB0";
            this.lProjNB0.Size = new System.Drawing.Size(74, 20);
            this.lProjNB0.TabIndex = 174;
            this.lProjNB0.Text = "Projects#:";
            this.lProjNB0.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lProjNB0.Visible = false;
            // 
            // lNBQ
            // 
            this.lNBQ.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lNBQ.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lNBQ.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lNBQ.Location = new System.Drawing.Point(72, 17);
            this.lNBQ.Name = "lNBQ";
            this.lNBQ.Size = new System.Drawing.Size(66, 20);
            this.lNBQ.TabIndex = 173;
            this.lNBQ.Text = "0";
            this.lNBQ.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lQ
            // 
            this.lQ.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold);
            this.lQ.ForeColor = System.Drawing.Color.Red;
            this.lQ.Location = new System.Drawing.Point(6, 17);
            this.lQ.Name = "lQ";
            this.lQ.Size = new System.Drawing.Size(66, 20);
            this.lQ.TabIndex = 172;
            this.lQ.Text = "Quotes #:";
            this.lQ.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpCurr
            // 
            this.grpCurr.Controls.Add(this.lnbQS);
            this.grpCurr.Controls.Add(this.NBqo);
            this.grpCurr.Controls.Add(this.lCADnb);
            this.grpCurr.Controls.Add(this.lEROnb);
            this.grpCurr.Controls.Add(this.label18);
            this.grpCurr.Controls.Add(this.lUSDnb);
            this.grpCurr.Controls.Add(this.tCADTot);
            this.grpCurr.Controls.Add(this.txRcad);
            this.grpCurr.Controls.Add(this.label24);
            this.grpCurr.Controls.Add(this.label23);
            this.grpCurr.Controls.Add(this.label21);
            this.grpCurr.Controls.Add(this.lcad_CAD);
            this.grpCurr.Controls.Add(this.lcad_EURO);
            this.grpCurr.Controls.Add(this.lcad_USD);
            this.grpCurr.Controls.Add(this.txReuro);
            this.grpCurr.Controls.Add(this.txRusd);
            this.grpCurr.Controls.Add(this.label17);
            this.grpCurr.Controls.Add(this.lEROTot);
            this.grpCurr.Controls.Add(this.label5);
            this.grpCurr.Controls.Add(this.label4);
            this.grpCurr.Controls.Add(this.tUSDTot);
            this.grpCurr.Controls.Add(this.tBigTot);
            this.grpCurr.ForeColor = System.Drawing.Color.Red;
            this.grpCurr.Location = new System.Drawing.Point(6, 8);
            this.grpCurr.Name = "grpCurr";
            this.grpCurr.Size = new System.Drawing.Size(485, 128);
            this.grpCurr.TabIndex = 172;
            this.grpCurr.TabStop = false;
            this.grpCurr.Text = "Quotes totals / Currency ";
            this.grpCurr.Visible = false;
            // 
            // lnbQS
            // 
            this.lnbQS.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lnbQS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lnbQS.Location = new System.Drawing.Point(24, 105);
            this.lnbQS.Name = "lnbQS";
            this.lnbQS.Size = new System.Drawing.Size(53, 16);
            this.lnbQS.TabIndex = 237;
            this.lnbQS.Text = "0";
            this.lnbQS.Visible = false;
            // 
            // NBqo
            // 
            this.NBqo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.NBqo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.NBqo.ForeColor = System.Drawing.Color.Red;
            this.NBqo.Location = new System.Drawing.Point(420, 105);
            this.NBqo.Name = "NBqo";
            this.NBqo.Size = new System.Drawing.Size(61, 20);
            this.NBqo.TabIndex = 236;
            this.NBqo.Text = "0";
            this.NBqo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lCADnb
            // 
            this.lCADnb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lCADnb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCADnb.ForeColor = System.Drawing.Color.Red;
            this.lCADnb.Location = new System.Drawing.Point(420, 74);
            this.lCADnb.Name = "lCADnb";
            this.lCADnb.Size = new System.Drawing.Size(61, 20);
            this.lCADnb.TabIndex = 235;
            this.lCADnb.Text = "0";
            this.lCADnb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lEROnb
            // 
            this.lEROnb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lEROnb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEROnb.ForeColor = System.Drawing.Color.Red;
            this.lEROnb.Location = new System.Drawing.Point(420, 54);
            this.lEROnb.Name = "lEROnb";
            this.lEROnb.Size = new System.Drawing.Size(61, 20);
            this.lEROnb.TabIndex = 234;
            this.lEROnb.Text = "0";
            this.lEROnb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(424, 13);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(58, 18);
            this.label18.TabIndex = 233;
            this.label18.Text = "#";
            this.label18.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lUSDnb
            // 
            this.lUSDnb.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lUSDnb.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUSDnb.ForeColor = System.Drawing.Color.Red;
            this.lUSDnb.Location = new System.Drawing.Point(420, 34);
            this.lUSDnb.Name = "lUSDnb";
            this.lUSDnb.Size = new System.Drawing.Size(61, 20);
            this.lUSDnb.TabIndex = 232;
            this.lUSDnb.Text = "0";
            this.lUSDnb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tCADTot
            // 
            this.tCADTot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tCADTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCADTot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tCADTot.Location = new System.Drawing.Point(53, 74);
            this.tCADTot.Name = "tCADTot";
            this.tCADTot.Size = new System.Drawing.Size(155, 20);
            this.tCADTot.TabIndex = 231;
            this.tCADTot.Text = "0";
            this.tCADTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tCADTot.TextChanged += new System.EventHandler(this.tCADTot_TextChanged);
            // 
            // txRcad
            // 
            this.txRcad.BackColor = System.Drawing.SystemColors.Control;
            this.txRcad.Location = new System.Drawing.Point(208, 74);
            this.txRcad.Multiline = true;
            this.txRcad.Name = "txRcad";
            this.txRcad.ReadOnly = true;
            this.txRcad.Size = new System.Drawing.Size(57, 21);
            this.txRcad.TabIndex = 230;
            this.txRcad.Text = "1.00";
            this.txRcad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label24
            // 
            this.label24.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Black;
            this.label24.Location = new System.Drawing.Point(278, 13);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(123, 18);
            this.label24.TabIndex = 229;
            this.label24.Text = "CAD Amounts";
            this.label24.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label23
            // 
            this.label23.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Black;
            this.label23.Location = new System.Drawing.Point(203, 13);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(69, 18);
            this.label23.TabIndex = 228;
            this.label23.Text = "$ Xchng";
            this.label23.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label21
            // 
            this.label21.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(178, 106);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(87, 18);
            this.label21.TabIndex = 227;
            this.label21.Text = " TOTAL ";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcad_CAD
            // 
            this.lcad_CAD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lcad_CAD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcad_CAD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lcad_CAD.Location = new System.Drawing.Point(265, 74);
            this.lcad_CAD.Name = "lcad_CAD";
            this.lcad_CAD.Size = new System.Drawing.Size(155, 20);
            this.lcad_CAD.TabIndex = 226;
            this.lcad_CAD.Text = "0";
            this.lcad_CAD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcad_EURO
            // 
            this.lcad_EURO.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lcad_EURO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcad_EURO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lcad_EURO.Location = new System.Drawing.Point(265, 54);
            this.lcad_EURO.Name = "lcad_EURO";
            this.lcad_EURO.Size = new System.Drawing.Size(155, 20);
            this.lcad_EURO.TabIndex = 225;
            this.lcad_EURO.Text = "0";
            this.lcad_EURO.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lcad_USD
            // 
            this.lcad_USD.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lcad_USD.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcad_USD.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lcad_USD.Location = new System.Drawing.Point(265, 34);
            this.lcad_USD.Name = "lcad_USD";
            this.lcad_USD.Size = new System.Drawing.Size(155, 20);
            this.lcad_USD.TabIndex = 224;
            this.lcad_USD.Text = "0";
            this.lcad_USD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txReuro
            // 
            this.txReuro.BackColor = System.Drawing.Color.White;
            this.txReuro.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txReuro.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txReuro.ForeColor = System.Drawing.Color.Red;
            this.txReuro.Location = new System.Drawing.Point(208, 54);
            this.txReuro.MaxLength = 6;
            this.txReuro.Multiline = true;
            this.txReuro.Name = "txReuro";
            this.txReuro.Size = new System.Drawing.Size(57, 21);
            this.txReuro.TabIndex = 223;
            this.txReuro.Text = "1.00";
            this.txReuro.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txReuro.TextChanged += new System.EventHandler(this.txReuro_TextChanged);
            // 
            // txRusd
            // 
            this.txRusd.BackColor = System.Drawing.Color.White;
            this.txRusd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txRusd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txRusd.ForeColor = System.Drawing.Color.Red;
            this.txRusd.Location = new System.Drawing.Point(208, 34);
            this.txRusd.MaxLength = 6;
            this.txRusd.Multiline = true;
            this.txRusd.Name = "txRusd";
            this.txRusd.Size = new System.Drawing.Size(57, 21);
            this.txRusd.TabIndex = 222;
            this.txRusd.Text = "1.00";
            this.txRusd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txRusd.TextChanged += new System.EventHandler(this.txRusd_TextChanged);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Transparent;
            this.label17.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.Color.Maroon;
            this.label17.Location = new System.Drawing.Point(9, 54);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(44, 18);
            this.label17.TabIndex = 185;
            this.label17.Text = "EURO";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lEROTot
            // 
            this.lEROTot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lEROTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lEROTot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lEROTot.Location = new System.Drawing.Point(53, 54);
            this.lEROTot.Name = "lEROTot";
            this.lEROTot.Size = new System.Drawing.Size(155, 20);
            this.lEROTot.TabIndex = 184;
            this.lEROTot.Text = "0";
            this.lEROTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lEROTot.TextChanged += new System.EventHandler(this.lEROTot_TextChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(15, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(38, 18);
            this.label5.TabIndex = 182;
            this.label5.Text = "USD";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(12, 75);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(41, 18);
            this.label4.TabIndex = 181;
            this.label4.Text = "CAD";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tUSDTot
            // 
            this.tUSDTot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tUSDTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tUSDTot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tUSDTot.Location = new System.Drawing.Point(53, 34);
            this.tUSDTot.Name = "tUSDTot";
            this.tUSDTot.Size = new System.Drawing.Size(155, 20);
            this.tUSDTot.TabIndex = 179;
            this.tUSDTot.Text = "0";
            this.tUSDTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tUSDTot.TextChanged += new System.EventHandler(this.tUSDTot_TextChanged);
            this.tUSDTot.Click += new System.EventHandler(this.tUSDTot_Click);
            // 
            // tBigTot
            // 
            this.tBigTot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBigTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBigTot.ForeColor = System.Drawing.Color.Firebrick;
            this.tBigTot.Location = new System.Drawing.Point(265, 105);
            this.tBigTot.Name = "tBigTot";
            this.tBigTot.Size = new System.Drawing.Size(155, 20);
            this.tBigTot.TabIndex = 178;
            this.tBigTot.Text = "0";
            this.tBigTot.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tSQL);
            this.groupBox1.Controls.Add(this.lvProj);
            this.groupBox1.Controls.Add(this.lvQuotes);
            this.groupBox1.Controls.Add(this.dgvSYS);
            this.groupBox1.Controls.Add(this.lvSYS);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 220);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1468, 295);
            this.groupBox1.TabIndex = 202;
            this.groupBox1.TabStop = false;
            // 
            // lvProj
            // 
            this.lvProj.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvProj.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Rdat,
            this.empR,
            this.RID,
            this.QIDR,
            this.cpnyNm,
            this.PO,
            this.AmntR,
            this.r_dblamt,
            this.CurrR,
            this.CADmnt,
            this.xrate,
            this.prjName,
            this.irrevLIDD,
            this.des,
            this.itmSN,
            this.ddlvr});
            this.lvProj.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvProj.ForeColor = System.Drawing.Color.Blue;
            this.lvProj.FullRowSelect = true;
            this.lvProj.GridLines = true;
            this.lvProj.Location = new System.Drawing.Point(3, 16);
            this.lvProj.MultiSelect = false;
            this.lvProj.Name = "lvProj";
            this.lvProj.Size = new System.Drawing.Size(1462, 276);
            this.lvProj.TabIndex = 12;
            this.lvProj.UseCompatibleStateImageBehavior = false;
            this.lvProj.View = System.Windows.Forms.View.Details;
            this.lvProj.Visible = false;
            this.lvProj.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvProj_ColumnClick);
            this.lvProj.SelectedIndexChanged += new System.EventHandler(this.lvProj_SelectedIndexChanged);
            this.lvProj.DoubleClick += new System.EventHandler(this.lvProj_DoubleClick);
            // 
            // Rdat
            // 
            this.Rdat.Text = "Date ";
            this.Rdat.Width = 120;
            // 
            // empR
            // 
            this.empR.Text = "Inside Sales";
            this.empR.Width = 178;
            // 
            // RID
            // 
            this.RID.Text = "Project# ";
            this.RID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.RID.Width = 78;
            // 
            // QIDR
            // 
            this.QIDR.Text = "Quote# ";
            this.QIDR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.QIDR.Width = 80;
            // 
            // cpnyNm
            // 
            this.cpnyNm.Text = "Company Name ";
            this.cpnyNm.Width = 253;
            // 
            // PO
            // 
            this.PO.Text = "PO # ";
            this.PO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PO.Width = 122;
            // 
            // AmntR
            // 
            this.AmntR.Text = "$ Amount ";
            this.AmntR.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AmntR.Width = 99;
            // 
            // r_dblamt
            // 
            this.r_dblamt.Text = "";
            this.r_dblamt.Width = 0;
            // 
            // CurrR
            // 
            this.CurrR.Text = "Currency";
            this.CurrR.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CurrR.Width = 100;
            // 
            // CADmnt
            // 
            this.CADmnt.Text = "CAD Amount";
            this.CADmnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CADmnt.Width = 100;
            // 
            // xrate
            // 
            this.xrate.Text = "SN shipped";
            this.xrate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.xrate.Width = 0;
            // 
            // prjName
            // 
            this.prjName.Text = "Project Name";
            this.prjName.Width = 150;
            // 
            // irrevLIDD
            // 
            this.irrevLIDD.Text = "";
            this.irrevLIDD.Width = 0;
            // 
            // des
            // 
            this.des.Text = "Item Description";
            this.des.Width = 150;
            // 
            // itmSN
            // 
            this.itmSN.Text = "Item SN";
            this.itmSN.Width = 80;
            // 
            // ddlvr
            // 
            this.ddlvr.Text = "Delivery Date";
            this.ddlvr.Width = 100;
            // 
            // lvQuotes
            // 
            this.lvQuotes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvQuotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Qdat,
            this.Empl,
            this.QID,
            this.Cpny,
            this.amt,
            this.q_dblAmt,
            this.Curr,
            this.ProID,
            this.PName,
            this.phone,
            this.adrs});
            this.lvQuotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvQuotes.ForeColor = System.Drawing.Color.Red;
            this.lvQuotes.FullRowSelect = true;
            this.lvQuotes.GridLines = true;
            this.lvQuotes.Location = new System.Drawing.Point(3, 16);
            this.lvQuotes.Name = "lvQuotes";
            this.lvQuotes.Size = new System.Drawing.Size(1462, 276);
            this.lvQuotes.TabIndex = 11;
            this.lvQuotes.UseCompatibleStateImageBehavior = false;
            this.lvQuotes.View = System.Windows.Forms.View.Details;
            this.lvQuotes.Visible = false;
            this.lvQuotes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvQuotes_ColumnClick);
            // 
            // Qdat
            // 
            this.Qdat.Text = "Date ";
            this.Qdat.Width = 76;
            // 
            // Empl
            // 
            this.Empl.Text = "Inside Sales";
            this.Empl.Width = 179;
            // 
            // QID
            // 
            this.QID.Text = "Quote# ";
            this.QID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.QID.Width = 83;
            // 
            // Cpny
            // 
            this.Cpny.Text = "Company Name ";
            this.Cpny.Width = 356;
            // 
            // amt
            // 
            this.amt.Text = "$ Amount ";
            this.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amt.Width = 99;
            // 
            // q_dblAmt
            // 
            this.q_dblAmt.Text = "";
            this.q_dblAmt.Width = 0;
            // 
            // Curr
            // 
            this.Curr.Text = "Currency";
            this.Curr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Curr.Width = 76;
            // 
            // ProID
            // 
            this.ProID.Text = "Project #";
            this.ProID.Width = 0;
            // 
            // PName
            // 
            this.PName.Text = "Project Name";
            this.PName.Width = 196;
            // 
            // phone
            // 
            this.phone.Text = "Phone";
            this.phone.Width = 100;
            // 
            // adrs
            // 
            this.adrs.Text = "Address";
            this.adrs.Width = 120;
            // 
            // dgvSYS
            // 
            this.dgvSYS.AllowUserToAddRows = false;
            this.dgvSYS.AllowUserToDeleteRows = false;
            this.dgvSYS.AllowUserToOrderColumns = true;
            this.dgvSYS.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvSYS.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.sysPrc});
            this.dgvSYS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvSYS.Location = new System.Drawing.Point(3, 16);
            this.dgvSYS.MultiSelect = false;
            this.dgvSYS.Name = "dgvSYS";
            this.dgvSYS.ReadOnly = true;
            this.dgvSYS.Size = new System.Drawing.Size(1462, 276);
            this.dgvSYS.TabIndex = 14;
            this.dgvSYS.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "desc";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 5;
            // 
            // Column2
            // 
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopLeft;
            this.Column2.DefaultCellStyle = dataGridViewCellStyle1;
            this.Column2.HeaderText = "System Name";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 400;
            // 
            // Column3
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopCenter;
            this.Column3.DefaultCellStyle = dataGridViewCellStyle2;
            this.Column3.HeaderText = "       Total #";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "SN  List";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            this.Column4.Width = 200;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Project List";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Visible = false;
            this.Column5.Width = 200;
            // 
            // Column6
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.TopRight;
            this.Column6.DefaultCellStyle = dataGridViewCellStyle3;
            this.Column6.HeaderText = "Unit Price";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // sysPrc
            // 
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            this.sysPrc.DefaultCellStyle = dataGridViewCellStyle4;
            this.sysPrc.HeaderText = "System Price";
            this.sysPrc.Name = "sysPrc";
            this.sysPrc.ReadOnly = true;
            this.sysPrc.Width = 200;
            // 
            // lvSYS
            // 
            this.lvSYS.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvSYS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.desc,
            this.SysNm,
            this.cntr,
            this.RIDlst,
            this.SNlst});
            this.lvSYS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvSYS.ForeColor = System.Drawing.Color.Blue;
            this.lvSYS.FullRowSelect = true;
            this.lvSYS.GridLines = true;
            this.lvSYS.Location = new System.Drawing.Point(3, 16);
            this.lvSYS.MultiSelect = false;
            this.lvSYS.Name = "lvSYS";
            this.lvSYS.Size = new System.Drawing.Size(1462, 276);
            this.lvSYS.TabIndex = 13;
            this.lvSYS.UseCompatibleStateImageBehavior = false;
            this.lvSYS.View = System.Windows.Forms.View.Details;
            this.lvSYS.Visible = false;
            this.lvSYS.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvSYS_ColumnClick);
            // 
            // desc
            // 
            this.desc.Text = "";
            this.desc.Width = 0;
            // 
            // SysNm
            // 
            this.SysNm.Text = "System Name";
            this.SysNm.Width = 287;
            // 
            // cntr
            // 
            this.cntr.Text = "#";
            this.cntr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cntr.Width = 61;
            // 
            // RIDlst
            // 
            this.RIDlst.Text = "";
            this.RIDlst.Width = 0;
            // 
            // SNlst
            // 
            this.SNlst.Text = "";
            this.SNlst.Width = 0;
            // 
            // Stati_NEW
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1468, 658);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpTot);
            this.Controls.Add(this.grpfind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Stati_NEW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Statistics";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Stati_Load);
            this.Resize += new System.EventHandler(this.Stati_Resize);
            this.grpfind.ResumeLayout(false);
            this.grpfind.PerformLayout();
            this.grpCharg.ResumeLayout(false);
            this.grpCharg.PerformLayout();
            this.grpREC.ResumeLayout(false);
            this.pnlRectif.ResumeLayout(false);
            this.grpCH.ResumeLayout(false);
            this.pnlCharger.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picFind)).EndInit();
            this.pnl_terri.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.findQT)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.grpQt.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.grpAdv.ResumeLayout(false);
            this.grpAdv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picEx2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picEX)).EndInit();
            this.grpDates.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).EndInit();
            this.grpcat.ResumeLayout(false);
            this.grpTot.ResumeLayout(false);
            this.grpQvsR.ResumeLayout(false);
            this.grpTOTqo.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.grpTOTsys.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.grpCurr.ResumeLayout(false);
            this.grpCurr.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvSYS)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


        public void fill_arr_Q(char c)   //S: only qoutes  P: prcnt of projects
        {
            double BT = 0;


            string cnd_cpny = (lcpnyID.Text != "-1") ? " AND PSM_Q_IGen.CPNY_ID =" + lcpnyID.Text : "";
            string cnd_Emp = (lempID.Text != "-1") ? " AND PSM_Q_IGen.Employ_ID =" + lempID.Text : ""; ;//"AND (PSM_Q_IGen.CPNY_ID = 4) AND (PSM_Q_IGen.Employ_ID = 4)"

            string stSql = (c == 'P') ? "SELECT     PSM_Q_IGen.Quote_ID, PSM_Q_IGen.ProjectName, PSM_Q_IGen.Opndate AS Qdate, PSM_COMPANY.Cpny_Name1, " +
                  "   PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS Employee, PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name,  " +
                  "   PSM_Q_SPCS.Rnk AS SPCRnk, PSM_Q_IGen.curr, SUM(PSM_Q_ALS.AGPrice) AS Amount, PSM_Q_IGen.CPNY_ID, PSM_R_Rev.RID " +
                  " FROM         PSM_Q_IGen INNER JOIN   PSM_COMPANY ON PSM_Q_IGen.CPNY_ID = PSM_COMPANY.Cpny_ID INNER JOIN " +
                  "   PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid INNER JOIN " +
                  "   PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID INNER JOIN  PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID LEFT OUTER JOIN " +
                  "   PSM_R_Rev ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID " +
                  " GROUP BY PSM_Q_IGen.Quote_ID, PSM_Q_IGen.ProjectName, PSM_Q_IGen.Opndate, PSM_COMPANY.Cpny_Name1,  PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name, PSM_Q_SOL.Sol_Name, PSM_Q_IGen.curr, PSM_Q_SPCS.SPC_Name, " +
                  "   PSM_Q_SPCS.Rnk, PSM_Q_IGen.CPNY_ID, PSM_Q_IGen.Employ_ID, PSM_R_Rev.RID " +
                  " HAVING   dbo.PSM_Q_IGen.Opndate >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND dbo.PSM_Q_IGen.Opndate <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   AND SUM(PSM_Q_ALS.AGPrice) <> 0 " + cnd_cpny + cnd_Emp +
                " ORDER BY PSM_Q_IGen.Quote_ID, PSM_Q_IGen.Opndate, PSM_Q_SOL.Sol_Name DESC, PSM_Q_SPCS.Rnk DESC, PSM_R_Rev.RID "
                                    : " SELECT     dbo.PSM_Q_IGen.Quote_ID, dbo.PSM_Q_IGen.ProjectName, dbo.PSM_Q_IGen.Opndate AS Qdate, " +
               "   dbo.PSM_COMPANY.Cpny_Name1, dbo.PSM_SALES_AGENTS.First_Name + ' ' + dbo.PSM_SALES_AGENTS.Last_Name AS Employee, " +
               "   dbo.PSM_Q_SOL.Sol_Name, dbo.PSM_Q_SPCS.SPC_Name, dbo.PSM_Q_SPCS.Rnk AS SPCRnk, dbo.PSM_Q_IGen.curr, SUM(dbo.PSM_Q_ALS.AGPrice) AS Amount , PSM_Q_IGen.CPNY_ID " +
               " FROM  dbo.PSM_Q_IGen INNER JOIN dbo.PSM_COMPANY ON dbo.PSM_Q_IGen.CPNY_ID = dbo.PSM_COMPANY.Cpny_ID INNER JOIN " +
               "   dbo.PSM_SALES_AGENTS ON dbo.PSM_Q_IGen.Employ_ID = dbo.PSM_SALES_AGENTS.SA_ID INNER JOIN dbo.PSM_Q_SOL ON dbo.PSM_Q_IGen.i_Quoteid = dbo.PSM_Q_SOL.I_Quoteid INNER JOIN " +
               "   dbo.PSM_Q_SPCS ON dbo.PSM_Q_SOL.Sol_LID = dbo.PSM_Q_SPCS.Sol_LID INNER JOIN dbo.PSM_Q_ALS ON dbo.PSM_Q_SPCS.SPC_LID = dbo.PSM_Q_ALS.SPC_LID " +
               " GROUP BY dbo.PSM_Q_IGen.Quote_ID, dbo.PSM_Q_IGen.ProjectName, dbo.PSM_Q_IGen.Opndate, dbo.PSM_COMPANY.Cpny_Name1, " +
               "   dbo.PSM_SALES_AGENTS.First_Name + ' ' + dbo.PSM_SALES_AGENTS.Last_Name, dbo.PSM_Q_SOL.Sol_Name, dbo.PSM_Q_IGen.curr,  dbo.PSM_Q_SPCS.SPC_Name, dbo.PSM_Q_SPCS.Rnk  , PSM_Q_IGen.CPNY_ID, PSM_Q_IGen.Employ_ID " +   //, PSM_Q_ALS.AGPrice
               " HAVING   dbo.PSM_Q_IGen.Opndate >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND dbo.PSM_Q_IGen.Opndate <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   AND SUM(PSM_Q_ALS.AGPrice) <> 0 " + cnd_cpny + cnd_Emp +
                //      " ORDER BY PSM_Q_IGen.Opndate DESC, PSM_Q_IGen.Quote_ID, PSM_Q_SOL.Sol_Name DESC, PSM_Q_SPCS.Rnk DESC, PSM_R_Rev.RID " ;
               " ORDER BY dbo.PSM_Q_IGen.Quote_ID, dbo.PSM_Q_IGen.Opndate, PSM_Q_SOL.Sol_Name DESC, dbo.PSM_Q_SPCS.Rnk DESC";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string OldQID = "", Oldcpny = "", OldRID = "";
            int NBQ = 0, NBSuc = 0, curNDX = -1;
            lvQuotes.Items.Clear();
            tSQL.Text = stSql;
            //	lvSorter.Order = SortOrder.None ; 
 //           lvQuotes.BeginUpdate();
            while (Oreadr.Read())
            {

                if (OldQID == Oreadr["Quote_ID"].ToString() && Oldcpny == Oreadr["CPNY_ID"].ToString())
                {
                    if (c == 'S') continue;
                    else if (Oreadr["RID"].ToString() != "" && lvQuotes.Items[curNDX].SubItems[6].Text.IndexOf(Oreadr["RID"].ToString()) == -1)
                    {
                        lvQuotes.Items[curNDX].SubItems[6].Text += "-" + Oreadr["RID"].ToString();
                        lvQuotes.Items[curNDX].UseItemStyleForSubItems = false;
                        lvQuotes.Items[curNDX].SubItems[6].ForeColor = Color.Blue;
                        NBSuc++;
                    }
                }
                else
                {
                    string dat = Oreadr["Qdate"].ToString().Substring(0, 10);
                    //ListViewItem lv =lvQuotes.Items.Add("");
                    //dat=dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2) ;

                    ListViewItem lv = lvQuotes.Items.Add(MainMDI.frmt_date(dat));//dat);
                    lv.SubItems.Add(Oreadr["Employee"].ToString());
                    lv.SubItems.Add(Oreadr["Quote_ID"].ToString());
                    lv.SubItems.Add(Oreadr["Cpny_Name1"].ToString());
                    lv.SubItems.Add("$ " + MainMDI.A00(Oreadr["Amount"].ToString()));
                    double dd = Tools.Conv_Dbl(Oreadr["Amount"].ToString());
                    BT += dd;
                    lv.SubItems.Add(dd.ToString());
                    dat = (Oreadr["curr"].ToString() == "U") ? "US" : "CAD";
                    lv.SubItems.Add(dat);
                    lv.SubItems.Add(" ");
                    lv.SubItems.Add(Oreadr["ProjectName"].ToString());
                    if (c == 'P' && lv.SubItems[7].Text != " ")
                    {
                        dat = Oreadr["RID"].ToString();
                        lv.UseItemStyleForSubItems = false;
                        lv.SubItems[7].ForeColor = Color.Blue;
                    }
                    else dat = "";

                    //		if(c=='P')    old version
                    //		{
                    //			dat= Oreadr["RID"].ToString ();
                    //			lv.UseItemStyleForSubItems=false; 
                    //			lv.SubItems[7].ForeColor = Color.Blue ;
                    //		}
                    //		else dat= "";
                    if (dat != "") { NBSuc++; lv.SubItems[7].Text = dat; }

                    curNDX = lv.Index;

                    NBQ++;
                }
                OldQID = Oreadr["Quote_ID"].ToString();
                Oldcpny = Oreadr["CPNY_ID"].ToString();
                OldRID = (c == 'P') ? Oreadr["RID"].ToString() : "";

            }
 //           lvQuotes.EndUpdate(); //cacher 

            OConn.Close();
            BT = Math.Round(BT, 2);
    //        UST = Math.Round(UST, 2);
    //        CADT = Math.Round(CADT, 2);

            tBigTot.Text = " $ " + MainMDI.Curr_FRMT(BT.ToString());
            lNBQ.Text = NBQ.ToString();
            lAvrg.Text = (BT != 0 && NBQ != 0) ? "$ " + MainMDI.Curr_FRMT(Convert.ToString(Math.Round(BT / NBQ, MainMDI.NB_DEC_AFF))) : "$ 0";
            if (c == 'P' && NBSuc > 0)
            {
                lProjNB.Text = NBSuc.ToString();
                lSucc.Text = MainMDI.A00(Convert.ToString(Math.Round(Convert.ToDouble(NBSuc) / NBQ * 100.00, MainMDI.NB_DEC_AFF)));
            }



        }


        
        public void fill_lvQuote()   //S: only qoutes  P: prcnt of projects
        {
            BT = 0; UST = 0; CADT = 0; EurT = 0; USTnb = 0; CADTnb = 0; EurTnb = 0;
          

    //       string cnd_AMNT =(AMNT_FM ==0 && AMNT_TO ==0) ? "" : " AND " 
            string cnd_cpny = (lcpnyID.Text != "-1") ? " AND PSM_Q_IGen.CPNY_ID =" + lcpnyID.Text : "";
            string cnd_Emp = (lempID.Text != "-1") ? " AND PSM_Q_IGen.Employ_ID =" + lempID.Text : ""; //"AND (PSM_Q_IGen.CPNY_ID = 4) AND (PSM_Q_IGen.Employ_ID = 4)"
            string cnd_Terri = (pnl_terri.Visible) ? " AND PSM_COMPANY.Sales ='" + lSnn.Text + "'": "";

            string stSql = "SELECT    PSM_Q_IGen.Quote_ID, PSM_Q_IGen.ProjectName, PSM_Q_IGen.Opndate AS Qdate, PSM_COMPANY.Cpny_Name1, PSM_COMPANY.M_Adrs, PSM_COMPANY.Tel1, " +
                           "   PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS Employee, PSM_Q_SOL.Sol_Name, PSM_Q_IGen.curr,  PSM_Q_IGen.CPNY_ID, [Quotes-TOT_by_lastRevision].BigTot as Amount , PSM_Q_IGen.i_Quoteid , PSM_COMPANY.Sales" +
                           "   FROM         PSM_Q_IGen INNER JOIN PSM_COMPANY ON PSM_Q_IGen.CPNY_ID = PSM_COMPANY.Cpny_ID INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID INNER JOIN " +
                           "                PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid INNER JOIN [Quotes-TOT_by_lastRevision] ON PSM_Q_SOL.Sol_LID = [Quotes-TOT_by_lastRevision].Sol_LID " +
                           "   GROUP BY PSM_Q_IGen.Quote_ID, PSM_Q_IGen.ProjectName, PSM_Q_IGen.Opndate, PSM_COMPANY.Cpny_Name1, PSM_COMPANY.M_Adrs, PSM_COMPANY.Tel1, PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name, PSM_Q_SOL.Sol_Name, PSM_Q_IGen.curr, PSM_Q_IGen.CPNY_ID, PSM_Q_IGen.Employ_ID, [Quotes-TOT_by_lastRevision].BigTot , PSM_Q_IGen.i_Quoteid , PSM_COMPANY.Sales" +
                           "   HAVING      PSM_Q_IGen.Opndate >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND dbo.PSM_Q_IGen.Opndate <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString())  + cnd_cpny + cnd_Emp + cnd_Terri +
                           "   ORDER BY PSM_Q_IGen.Quote_ID, Qdate, PSM_Q_SOL.Sol_Name DESC";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string OldQID = "", Oldcpny = "", OldRID = "", OldRev="";
            int  curNDX = -1;
            double NBQ = 0 ;
            lvQuotes.Items.Clear();
            tSQL.Text = stSql;
            //	lvSorter.Order = SortOrder.None ; 
            lvQuotes.BeginUpdate();
            while (Oreadr.Read())
            {
                //
                if (lv_Ex.FindStringExact(Oreadr["Cpny_Name1"].ToString()) == -1)
                {
                    //
                    if (OldQID == Oreadr["Quote_ID"].ToString() && Oldcpny == Oreadr["CPNY_ID"].ToString()) continue;
                    else
                    {
                        if (GoodAMNTFT(Tools.Conv_Dbl(Oreadr["Amount"].ToString())))
                        {
                            string dat = Oreadr["Qdate"].ToString().Substring(0, 10);
                            ListViewItem lv = lvQuotes.Items.Add(MainMDI.frmt_date(dat));//dat);
                            lv.SubItems.Add(Oreadr["Employee"].ToString());
                            lv.SubItems.Add(Oreadr["Quote_ID"].ToString());
                            lv.SubItems.Add(Oreadr["Cpny_Name1"].ToString());
                            //  lv.SubItems.Add("$ " + MainMDI.A00(Oreadr["Amount"].ToString()));
                            lv.SubItems.Add(MainMDI.A00(Oreadr["Amount"].ToString()));
                            double dd = Tools.Conv_Dbl(Oreadr["Amount"].ToString());
                            BT += dd;
                            lv.SubItems.Add(dd.ToString());
                            //    dat = (Oreadr["curr"].ToString() == "U") ? "US" : "CAD";

                            switch (Oreadr["curr"].ToString()[0])
                            {
                                case 'U':
                                    dat = "US";
                                    UST += dd;
                                    USTnb++;
                                    break;
                                case 'E':
                                    dat = "EUR";
                                    EurT += dd;
                                    EurTnb++;
                                    break;
                                case 'C':
                                    dat = "CAD";
                                    CADT += dd;
                                    CADTnb++;
                                    break;
                                default:
                                    MessageBox.Show("Currency Code is Invalid......PA= " + Oreadr["PA"].ToString());
                                    dat = "CAD";
                                    CADT += dd;
                                    CADTnb++;
                                    break;


                            }

                            lv.SubItems.Add(dat);
                            lv.SubItems.Add(" ");
                            lv.SubItems.Add(Oreadr["ProjectName"].ToString());
                            if (Opera == 'P' && lv.SubItems[7].Text != " ")
                            {
                                dat = Oreadr["RID"].ToString();
                                lv.UseItemStyleForSubItems = false;
                                lv.SubItems[7].ForeColor = Color.Blue;
                            }
                            else dat = Oreadr["i_Quoteid"].ToString();

                            lv.SubItems.Add("[" + Oreadr["Tel1"].ToString() + "]");
                            lv.SubItems.Add(Oreadr["M_Adrs"].ToString());

                            if (dat != "") { 
                               // NBSuc++; 
                                lv.SubItems[7].Text = dat; 
                            }
                            //      lv.SubItems.Add(Oreadr["i_QuoteID"].ToString());
                            curNDX = lv.Index;

                            NBQ++;

                            OldQID = Oreadr["Quote_ID"].ToString();
                            Oldcpny = Oreadr["CPNY_ID"].ToString();
                            OldRev = Oreadr["i_Quoteid"].ToString();
                            OldRID = (Opera == 'P') ? Oreadr["RID"].ToString() : "";
                        }
                    }
                }
            }
            lvQuotes.EndUpdate();
            lvQuotes.Refresh();


           // grpCurr.Visible = false;

            BT = Math.Round(BT, 2);
            UST = Math.Round(UST, 2);
            CADT = Math.Round(CADT, 2);

//format $$
            OConn.Close();
            //tBigTot.Text = " $ " + MainMDI.Curr_FRMT(BT.ToString());
            tUSDTot.Text = " $ " + MainMDI.Curr_FRMT(UST.ToString()); lUSDnb.Text = USTnb.ToString();
            tCADTot.Text = " $ " + MainMDI.Curr_FRMT(CADT.ToString()); lCADnb.Text = CADTnb.ToString();
            lEROTot.Text =  MainMDI.Curr_FRMT(EurT.ToString()); lEROnb.Text = EurTnb.ToString();

     //       tUSDTot.Text = UST.ToString(); lUSDnb.Text =USTnb.ToString();
     //       tCADTot.Text = CADT.ToString(); lCADnb.Text =CADTnb.ToString();
      //      lEROTot.Text = EurT.ToString(); lEROnb.Text = EurTnb.ToString ();


           // lNBQ.Text = NBQ.ToString();
            NBqo.Text = NBQ.ToString();
            lnbQS.Text = (USD_SQnb + EUR_SQnb + CAD_SQnb).ToString ();


              //  lProjNB.Text = NBSuc.ToString();
              // lAvrg.Text = (BT != 0 && NBQ != 0) ? "$ " + MainMDI.Curr_FRMT(Convert.ToString(Math.Round(BT / NBQ, MainMDI.NB_DEC_AFF))) : "$ 0";

            format_LV();
            edlv_QtOr.Items[0].SubItems[2].Text = NBQ.ToString();
            edlv_QtOr.Items[0].SubItems[3].Text = " $ " + MainMDI.Curr_FRMT(BT.ToString());
            double avrgQ=Math.Round(BT / NBQ, 2);
            edlv_QtOr.Items[0].SubItems[4].Text = " $ " + MainMDI.Curr_FRMT(avrgQ.ToString());
 
            Quotes_status();

            double ALL_SQ=USD_SQ + EUR_SQ + CAD_SQ;
            edlv_QtOr.Items[1].SubItems[2].Text = (USD_SQnb + EUR_SQnb + CAD_SQnb).ToString();
            edlv_QtOr.Items[1].SubItems[3].Text = " $ " + MainMDI.Curr_FRMT(ALL_SQ.ToString());
           double  avrgSQ = Math.Round(ALL_SQ / (USD_SQnb + EUR_SQnb + CAD_SQnb), 2);
           edlv_QtOr.Items[1].SubItems[4].Text = " $ " + MainMDI.Curr_FRMT(avrgSQ.ToString());

            edlv_QtOr.Items[2].SubItems[2].Text = Math.Round((USD_SQnb + EUR_SQnb + CAD_SQnb) / NBQ * 100.0, 0).ToString () +"%";
            edlv_QtOr.Items[2].SubItems[3].Text = Math.Round(ALL_SQ / BT * 100.0, 0).ToString() + "%";
            avrgQ = Math.Round(avrgSQ / avrgQ * 100.0,0);
            edlv_QtOr.Items[2].SubItems[4].Text = avrgQ.ToString() + "%";

            grpTot.Visible = (lvQuotes.Items.Count > 0);

        }

        void format_LV()
        {
            edlv_QtOr.Items.Clear();
            edlv_QvsOR.Items.Clear();
            ListViewItem lv = null;
            switch (Opera)
            {
                case 'Q':
                    lv = edlv_QtOr.Items.Add(" ");
                    lv.SubItems.Add("Quotes"); for (int i = 0; i < 3; i++) lv.SubItems.Add(" ");lv.ForeColor  =Color.Red;

                    lv = edlv_QtOr.Items.Add("");
                    lv.SubItems.Add("Succ. Quotes"); for (int i = 0; i < 3; i++) lv.SubItems.Add(" ");lv.ForeColor  =Color.Blue;

                    lv = edlv_QtOr.Items.Add("");
                    lv.SubItems.Add("Ratios"); for (int i = 0; i < 3; i++) lv.SubItems.Add(" ");lv.ForeColor  =Color.Green;


                    //QvsOR
                    ListViewItem lvv =edlv_QvsOR.Items.Add(" ");
                    lvv.SubItems.Add("Quotes"); for (int i = 0; i < 3; i++) lvv.SubItems.Add(" ");lvv.ForeColor  =Color.Red;

                    lvv = edlv_QvsOR.Items.Add("");
                    lvv.SubItems.Add("Orders"); for (int i = 0; i < 3; i++) lvv.SubItems.Add(" ");lvv.ForeColor  =Color.Blue;

                    lvv = edlv_QvsOR.Items.Add("");
                    lvv.SubItems.Add("Ratios"); for (int i = 0; i < 3; i++) lvv.SubItems.Add(" ");lvv.ForeColor  =Color.Green;


                    break;
                case 'R':
                    
                    lv = edlv_QtOr.Items.Add(" ");
                    lv.SubItems.Add("Orders"); for (int i = 0; i < 3; i++) lv.SubItems.Add(" ");lv.ForeColor  =Color.Blue;
                  //  lv = edlv_QtOr.Items.Add("");
                 //   lv.SubItems.Add("Projects"); for (int i = 0; i < 3; i++) lv.SubItems.Add(" ");
                    break;

            }



        }
     
			private void lvQuotes_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
			{
	
				seelCol=e.Column; 
				ListView myListView = (ListView)sender;
		
				if ( e.Column == lvSorter.SortColumn )
				{
				    if (lvSorter.Order == System.Windows.Forms.SortOrder.Ascending)
					{
						lvSorter.Order = System.Windows.Forms.SortOrder.Descending;
					}
					else
					{
						lvSorter.Order = System.Windows.Forms.SortOrder.Ascending;
					}
				}
				else
				{

					lvSorter.Order = (srtType=='A') ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
					srtType=(srtType=='A') ? 'D' : 'A';
					lvSorter.SortColumn = (e.Column!=4) ? e.Column : 5 ;
					
				}

	    		myListView.Sort();
				oldSC=lvSorter.SortColumn;
				lvSorter.SortColumn =0;



			
		}

            private string make_Sql()
            {
                string cnd_Tsts = "", stSql = "";
                for (int i = 0; i < Irrev_MAX_ROW; i++) arr_Irrev_Ndx[i, 0] = "";

                //new for shipped with SN
                if (lOp.Text == "T")       lOp.Text = "S";

                //    string stWhr_date = (opSHP.Checked ) ? "         PSM_R_Rev.dateRRev >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_Rev.dateRRev <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   AND PSM_R_Rev.RRev_Tot <> 0 " + cnd_cpny + cnd_Emp + cnd_Ship + cnd_Tsts : "         PSM_R_Rev.dateRRev >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_Rev.dateRRev <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   AND PSM_R_Rev.RRev_Tot <> 0 " + cnd_cpny + cnd_Emp + cnd_Ship + cnd_Tsts;
                string cnd_cpny = (lcpnyID.Text != "-1") ? " AND PSM_Q_IGen.CPNY_ID =" + lcpnyID.Text : "";
                string cnd_Emp = (lempID.Text != "-1") ? " AND PSM_Q_IGen.Employ_ID =" + lempID.Text : "";
                string cnd_Ship = (lOp.Text != "A") ? " AND PSM_R_Rev.shiped ='" + lOp.Text + "'" : "";
                string cnd_Terri = (pnl_terri.Visible) ? " AND PSM_COMPANY.Sales ='" + lSnn.Text + "'" : "";
                if (lOp.Text == "*") cnd_Ship = " AND (PSM_R_Rev.shiped =' ' OR PSM_R_Rev.shiped ='F' OR PSM_R_Rev.shiped ='" + lOp.Text + "') ";
                
                if (opSHP.Checked)
                    stSql = " SELECT  PSM_R_Rev.Tests, PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_Q_IGen.Quote_ID, PSM_COMPANY.Cpny_Name1, PSM_R_Rev.Custm_PO, PSM_R_Rev.dateRRev, " +
                             "         PSM_R_Rev.RRev_Tot, PSM_R_Rev.RRev_Name, PSM_R_Rev.shiped, PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS Employee, PSM_Q_IGen.curr, " +
                             "         PSM_R_Rev.Rnk, PSM_Q_IGen.CPNY_ID, PSM_Q_IGen.Employ_ID, PSM_R_Rev.PA , PSM_Q_IGen.ProjectName , PSM_R_SLots.ShipDat, PSM_R_Rev.dateDlvr, PSM_COMPANY.Sales " +
                             " FROM    PSM_Q_IGen INNER JOIN PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID INNER JOIN " +
                             "         PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID INNER JOIN PSM_R_SLots ON PSM_R_Rev.IRRevID = PSM_R_SLots.l_RRevLID " +
                             " WHERE   PSM_R_Rev.shiped <> 'C' AND PSM_R_Rev.shiped <> 'D' AND PSM_COMPANY.Cpny_ID <> 2170 AND PSM_R_Rev.Custm_PO <> N'TEST' and " +
                             "         PSM_R_SLots.ShipDat >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_SLots.ShipDat <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   AND PSM_R_Rev.RRev_Tot <> 0 " + cnd_cpny + cnd_Emp + cnd_Ship + cnd_Tsts + cnd_Terri +
                             " ORDER  by  PSM_R_Rev.IRRevID, PSM_R_Rev.Rnk, PSM_R_SLots.ShipDat desc   ";
                else
                {
                    if (optInv.Checked) //invoice
                        stSql = " SELECT  PSM_R_Rev.Tests, PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_Q_IGen.Quote_ID, PSM_COMPANY.Cpny_Name1, PSM_R_Rev.Custm_PO, PSM_R_Rev.dateRRev, PSM_R_Rev.RRev_Tot, PSM_R_Rev.RRev_Name, PSM_R_Rev.shiped,  " +
                       "         PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS Employee, PSM_Q_IGen.curr, PSM_R_Rev.Rnk, PSM_Q_IGen.CPNY_ID, PSM_Q_IGen.Employ_ID, PSM_R_Rev.PA, PSM_Q_IGen.ProjectName, PSM_R_SBills.InvoicDat, PSM_R_Rev.dateDlvr , PSM_COMPANY.Sales" +
                       " FROM    PSM_Q_IGen INNER JOIN PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID INNER JOIN  PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID INNER JOIN PSM_R_SBills ON PSM_R_Rev.IRRevID = PSM_R_SBills.b_RRevLID " +
                       " WHERE   (PSM_R_Rev.shiped <> 'C') AND  (PSM_R_Rev.shiped <> 'D') AND (PSM_COMPANY.Cpny_ID <> 2170) AND (PSM_R_Rev.Custm_PO <> N'TEST') AND (PSM_R_Rev.RRev_Tot <> 0) " +
                       " AND        PSM_R_SBills.InvoicDat  >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_SBills.InvoicDat <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + " and ( substring( PSM_R_SBills.AccInv,1,6) <>'tmpNB_')" + cnd_cpny + cnd_Emp +cnd_Terri +
                       " ORDER BY PSM_R_Rev.IRRevID, PSM_R_Rev.Rnk, PSM_R_SBills.InvoicDat ";
                    else
                        stSql = " SELECT  PSM_R_Rev.Tests, PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_Q_IGen.Quote_ID, PSM_COMPANY.Cpny_Name1, PSM_R_Rev.Custm_PO, PSM_R_Rev.dateRRev, " +
                                "         PSM_R_Rev.RRev_Tot, PSM_R_Rev.RRev_Name, PSM_R_Rev.shiped, PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS Employee, PSM_Q_IGen.curr, " +
                                "         PSM_R_Rev.Rnk, PSM_Q_IGen.CPNY_ID, PSM_Q_IGen.Employ_ID, PSM_R_Rev.PA , PSM_Q_IGen.ProjectName , PSM_R_Rev.dateDlvr , PSM_COMPANY.Sales" +
                                " FROM    PSM_Q_IGen INNER JOIN PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID INNER JOIN " +
                                "         PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID " +
                                " WHERE   PSM_R_Rev.shiped <> 'C' AND PSM_R_Rev.shiped <> 'D' AND PSM_COMPANY.Cpny_ID <> 2170 AND PSM_R_Rev.Custm_PO <> N'TEST' and " +
                                "         PSM_R_Rev.dateRRev >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_Rev.dateRRev <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   " + cnd_cpny + cnd_Emp + cnd_Ship + cnd_Tsts + cnd_Terri +
                                " ORDER   BY PSM_R_Rev.dateRRev, PSM_R_Rev.IRRevID, PSM_R_Rev.Rnk               ";
                }
                if (cnd_Tsts.Length > 0) lOp.Text = "T";
                return stSql;
            }

            private string make_Sql_details()
            {
                string cnd_Tsts = "", stSql = "";
                for (int i = 0; i < Irrev_MAX_ROW; i++) arr_Irrev_Ndx[i, 0] = "";

                //new for shipped with SN
                if (lOp.Text == "T") lOp.Text = "S";

                //    string stWhr_date = (opSHP.Checked ) ? "         PSM_R_Rev.dateRRev >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_Rev.dateRRev <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   AND PSM_R_Rev.RRev_Tot <> 0 " + cnd_cpny + cnd_Emp + cnd_Ship + cnd_Tsts : "         PSM_R_Rev.dateRRev >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_Rev.dateRRev <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   AND PSM_R_Rev.RRev_Tot <> 0 " + cnd_cpny + cnd_Emp + cnd_Ship + cnd_Tsts;
                string cnd_cpny = (lcpnyID.Text != "-1") ? " AND PSM_Q_IGen.CPNY_ID =" + lcpnyID.Text : "";
                string cnd_Emp = (lempID.Text != "-1") ? " AND PSM_Q_IGen.Employ_ID =" + lempID.Text : "";
                string cnd_Ship = (lOp.Text != "A") ? " AND PSM_R_Rev.shiped ='" + lOp.Text + "'" : "";
                if (lOp.Text == "*") cnd_Ship = " AND (PSM_R_Rev.shiped =' ' OR PSM_R_Rev.shiped ='F' OR PSM_R_Rev.shiped ='" + lOp.Text + "') ";
                string cnd_Terri = (pnl_terri.Visible) ? " AND PSM_COMPANY.Sales ='" + lSnn.Text + "'" : "";

                if (opSHP.Checked)
                    stSql = " SELECT  PSM_R_Rev.Tests, PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_Q_IGen.Quote_ID, PSM_COMPANY.Cpny_Name1, PSM_R_Rev.Custm_PO, PSM_R_Rev.dateRRev, PSM_R_Rev.RRev_Tot, PSM_R_Rev.RRev_Name, PSM_R_Rev.shiped, " +
                            "         PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS Employee, PSM_Q_IGen.curr, PSM_R_Rev.Rnk, PSM_Q_IGen.CPNY_ID, PSM_Q_IGen.Employ_ID, PSM_R_Rev.PA, PSM_Q_IGen.ProjectName, PSM_R_SLots.ShipDat, PSM_Q_Details.[Desc], PSM_R_Detail.PrimaxSN , len(PSM_R_Detail.PrimaxSN) as LEN_SN, PSM_R_Rev.dateDlvr " +
                            " FROM    PSM_Q_IGen INNER JOIN PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID INNER JOIN PSM_R_SLots ON PSM_R_Rev.IRRevID = PSM_R_SLots.l_RRevLID INNER JOIN " +
                            "         PSM_R_Detail ON PSM_R_Rev.IRRevID = PSM_R_Detail.IRRev_LID INNER JOIN PSM_Q_Details ON PSM_R_Detail.Qdet_LID = PSM_Q_Details.Detail_LID " +
                            " WHERE   PSM_R_Rev.shiped <> 'C' AND PSM_R_Rev.shiped <> 'D' AND PSM_COMPANY.Cpny_ID <> 2170 AND PSM_R_Rev.Custm_PO <> N'TEST' and " +
                            "         PSM_R_SLots.ShipDat >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_SLots.ShipDat <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   AND PSM_R_Rev.RRev_Tot <> 0 " + cnd_cpny + cnd_Emp + cnd_Ship + cnd_Tsts + cnd_Terri +
                            " ORDER  by  PSM_R_Rev.IRRevID, PSM_R_Rev.Rnk, PSM_R_SLots.ShipDat desc   ";
                else
                {
                    if (optInv.Checked) //invoice
                        stSql = " SELECT     PSM_R_Rev.Tests, PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_Q_IGen.Quote_ID, PSM_COMPANY.Cpny_Name1, PSM_R_Rev.Custm_PO, " + 
                                "            PSM_R_Rev.dateRRev, PSM_R_Rev.RRev_Tot, PSM_R_Rev.RRev_Name, PSM_R_Rev.shiped, PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS Employee, PSM_Q_IGen.curr, PSM_R_Rev.Rnk, PSM_Q_IGen.CPNY_ID, " +
                                "            PSM_Q_IGen.Employ_ID, PSM_R_Rev.PA, PSM_Q_IGen.ProjectName, PSM_R_SBills.InvoicDat, PSM_Q_Details.[Desc], PSM_R_Detail.PrimaxSN,len( PSM_R_Detail.PrimaxSN) as LEN_SN, PSM_R_Rev.dateDlvr  " +
                                " FROM       PSM_Q_IGen INNER JOIN PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID INNER JOIN " +
                                "            PSM_R_SBills ON PSM_R_Rev.IRRevID = PSM_R_SBills.b_RRevLID INNER JOIN PSM_R_Detail ON PSM_R_Rev.IRRevID = PSM_R_Detail.IRRev_LID INNER JOIN PSM_Q_Details ON PSM_R_Detail.Qdet_LID = PSM_Q_Details.Detail_LID " +
                                " WHERE     (PSM_R_Rev.shiped <> 'C') AND  (PSM_R_Rev.shiped <> 'D') AND (PSM_COMPANY.Cpny_ID <> 2170) AND (PSM_R_Rev.Custm_PO <> N'TEST') AND (PSM_R_Rev.RRev_Tot <> 0) " +
                                " AND        PSM_R_SBills.InvoicDat  >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_SBills.InvoicDat <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + " and ( substring( PSM_R_SBills.AccInv,1,6) <>'tmpNB_')" +
                                " ORDER BY PSM_R_Rev.IRRevID, PSM_R_Rev.Rnk, PSM_R_SBills.InvoicDat ";
                    else
                        stSql = " SELECT     PSM_R_Rev.Tests, PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_Q_IGen.Quote_ID, PSM_COMPANY.Cpny_Name1, PSM_R_Rev.Custm_PO, " +
                            "            PSM_R_Rev.dateRRev, PSM_R_Rev.RRev_Tot, PSM_R_Rev.RRev_Name, PSM_R_Rev.shiped, PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS Employee, PSM_Q_IGen.curr, PSM_R_Rev.Rnk, PSM_Q_IGen.CPNY_ID, " +
                            "            PSM_Q_IGen.Employ_ID, PSM_R_Rev.PA, PSM_Q_IGen.ProjectName, PSM_Q_Details.[Desc],PSM_R_Detail.PrimaxSN, len(PSM_R_Detail.PrimaxSN) as LEN_SN, PSM_R_Rev.dateDlvr " +
                            " FROM       PSM_Q_IGen INNER JOIN PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID INNER JOIN " +
                            "            PSM_R_Detail ON PSM_R_Rev.IRRevID = PSM_R_Detail.IRRev_LID INNER JOIN PSM_Q_Details ON PSM_R_Detail.Qdet_LID = PSM_Q_Details.Detail_LID " +
                                 " WHERE  PSM_R_Rev.shiped <> 'C' AND  PSM_R_Rev.shiped <> 'D' AND PSM_COMPANY.Cpny_ID <> 2170 AND PSM_R_Rev.Custm_PO <> N'TEST' and " +
                                "         PSM_R_Rev.dateRRev >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_Rev.dateRRev <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   " + cnd_cpny + cnd_Emp + cnd_Ship + cnd_Tsts + cnd_Terri +
                                " ORDER   BY PSM_R_Rev.dateRRev, PSM_R_Rev.IRRevID, PSM_R_Rev.Rnk               ";
                }
                if (cnd_Tsts.Length > 0) lOp.Text = "T";
                return stSql;
            }


        public void fill_lvProj()
        {
            BT = 0; UST = 0; CADT = 0; EurT = 0; USTnb = 0; CADTnb = 0; EurTnb = 0;
            bool ShippedSN = (lOp.Text == "T");

            string stSql = (chSN.Checked ) ? make_Sql_details() :  make_Sql();
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
           // string OldQID = "", Oldcpny = "";
            int NBQ = 0, NDX_IIREV = 0;
            string xrt = "0", CADamnt = "0";
            tSQL.Text = stSql;
            lvProj.Items.Clear();

            lvProj.Columns[13].Width = (chSN.Checked) ? 150 : 0;
            lvProj.Columns[14].Width = (chSN.Checked) ? 80 : 0;
  
            lvProj.BeginUpdate();
            string oldRevLID = "";
            while (Oreadr.Read())
            {
                if (GoodAMNTFT(Tools.Conv_Dbl(Oreadr["RRev_Tot"].ToString())))
                {
                    if (lv_Ex.FindStringExact(Oreadr["Cpny_Name1"].ToString()) == -1)
                    {

                        string stdesc = (chSN.Checked) ? Oreadr["PrimaxSN"].ToString() : "";//############## checked totals
                        if (oldRevLID != Oreadr["IRRevID"].ToString() || stdesc.Length > 4)
                        {
                            string dat = Oreadr["dateRRev"].ToString().Substring(0, 10);
                            if (opSHP.Checked) dat = Oreadr["ShipDat"].ToString().Substring(0, 10);
                            if (optInv.Checked) dat = Oreadr["InvoicDat"].ToString().Substring(0, 10);

                            //ListViewItem lv =lvQuotes.Items.Add("");
                            //dat=dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2) ;
                            ListViewItem lv = lvProj.Items.Add(MainMDI.frmt_date(dat)); //dat);
                            lv.SubItems.Add(Oreadr["Employee"].ToString());
                            lv.SubItems.Add(Oreadr["RID"].ToString());
                            lv.SubItems.Add(Oreadr["Quote_ID"].ToString());
                            lv.SubItems.Add(Oreadr["Cpny_Name1"].ToString());
                            lv.SubItems.Add(Oreadr["Custm_PO"].ToString());
                            // lv.SubItems.Add("$ " + MainMDI.A00(Oreadr["RRev_Tot"].ToString()));
                            lv.SubItems.Add(MainMDI.A00(Oreadr["RRev_Tot"].ToString()));
                            double dd = Tools.Conv_Dbl(Oreadr["RRev_Tot"].ToString());

                            if (oldRevLID != Oreadr["IRRevID"].ToString()) BT += dd;

                            lv.SubItems.Add(dd.ToString());
                            CADamnt = Oreadr["RRev_Tot"].ToString();
                            xrt = "1";
                            string pa = Oreadr["PA"].ToString();

                            switch (pa[0])
                            {
                                case 'U':
                                    dat = "US";
                                    if (oldRevLID != Oreadr["IRRevID"].ToString()) { UST += dd; USTnb++; }
                                    break;
                                case 'E':
                                    dat = "EUR";
                                    if (oldRevLID != Oreadr["IRRevID"].ToString()) { EurT += dd; EurTnb++; }
                                    break;
                                case 'C':
                                    dat = "CAD";
                                    if (oldRevLID != Oreadr["IRRevID"].ToString()) { CADT += dd; CADTnb++; }
                                    break;
                                default:
                                    MessageBox.Show("Currency Code is Invalid......PA= " + Oreadr["PA"].ToString());
                                    dat = "CAD";
                                    if (oldRevLID != Oreadr["IRRevID"].ToString()) { CADT += dd; CADTnb++; }
                                    break;


                            }
                            //	dat=(pa[0]=='U') ? "US" : "CAD";


                            if (pa.Length > 1 && (dat == "US" || dat == "EUR"))
                            {
                                xrt = MainMDI.A00(Convert.ToString(Tools.Conv_Dbl(pa.Substring(pa.Length - 1))));
                                CADamnt = Convert.ToString(Math.Round(Tools.Conv_Dbl(CADamnt) * Tools.Conv_Dbl(xrt), MainMDI.NB_DEC_AFF));
                            }
                            lv.SubItems.Add(dat);
                            lv.SubItems.Add("$ " + MainMDI.A00(CADamnt));
                            lv.SubItems.Add(MainMDI.A00(xrt));
                            lv.SubItems.Add(Oreadr["ProjectName"].ToString());
                            lv.SubItems.Add(Oreadr["IRRevID"].ToString());
                            stdesc = (chSN.Checked) ? Oreadr["Desc"].ToString() : "";
                            lv.SubItems.Add(stdesc);
                            stdesc = (chSN.Checked) ? Oreadr["PrimaxSN"].ToString() : "";
                            lv.SubItems.Add(stdesc);


                            lv.SubItems.Add(MainMDI.frmt_date(Oreadr["dateDlvr"].ToString().Substring(0, 10)));   // Oreadr["dateDlvr"].ToString()); 

                            lv.ForeColor = RRev_Colr(Oreadr["shiped"].ToString()[0]);

                            if (oldRevLID != Oreadr["IRRevID"].ToString()) NBQ++;

                            // fill arr_Irrev_Ndx 
                            arr_Irrev_Ndx[NDX_IIREV, 0] = Oreadr["IRRevID"].ToString();
                            arr_Irrev_Ndx[NDX_IIREV++, 1] = Convert.ToString(lvProj.Items.Count - 1);
                            oldRevLID = Oreadr["IRRevID"].ToString();
                        }
                    }
                }
                }
                //    if (ShippedSN) list_ShippedSN();
                lvProj.EndUpdate();
                lvProj.Refresh();
                OConn.Close();

                BT = Math.Round(BT, 2);
                UST = Math.Round(UST, 2);
                CADT = Math.Round(CADT, 2);

                tBigTot.Text = " $ " + MainMDI.Curr_FRMT(BT.ToString());
                tUSDTot.Text = " $ " + MainMDI.Curr_FRMT(UST.ToString());
                tCADTot.Text = " $ " + MainMDI.Curr_FRMT(CADT.ToString());
                lEROTot.Text = " $ " + MainMDI.Curr_FRMT(EurT.ToString());
                lNBQ.Text = NBQ.ToString();

                tUSDTot.Text = " $ " + MainMDI.Curr_FRMT(UST.ToString()); lUSDnb.Text = USTnb.ToString();
                tCADTot.Text = " $ " + MainMDI.Curr_FRMT(CADT.ToString()); lCADnb.Text = CADTnb.ToString();
                lEROTot.Text = MainMDI.Curr_FRMT(EurT.ToString()); lEROnb.Text = EurTnb.ToString();

                //       tUSDTot.Text = UST.ToString(); lUSDnb.Text =USTnb.ToString();
                //       tCADTot.Text = CADT.ToString(); lCADnb.Text =CADTnb.ToString();
                //      lEROTot.Text = EurT.ToString(); lEROnb.Text = EurTnb.ToString ();


                // lNBQ.Text = NBQ.ToString();
                NBqo.Text = NBQ.ToString();
                lnbQS.Text = (USD_SQnb + EUR_SQnb + CAD_SQnb).ToString();


                //  lProjNB.Text = NBSuc.ToString();
                // lAvrg.Text = (BT != 0 && NBQ != 0) ? "$ " + MainMDI.Curr_FRMT(Convert.ToString(Math.Round(BT / NBQ, MainMDI.NB_DEC_AFF))) : "$ 0";

                format_LV();

                edlv_QtOr.Items[0].SubItems[2].Text = NBQ.ToString();
                edlv_QtOr.Items[0].SubItems[3].Text = " $ " + MainMDI.Curr_FRMT(BT.ToString());
                double avrgQ = Math.Round(BT / NBQ, 2);
                edlv_QtOr.Items[0].SubItems[4].Text = " $ " + MainMDI.Curr_FRMT(avrgQ.ToString());
            

                grpTOTqo.Visible = true;
                grpCurr.Visible = true;
                grpTot.Visible = (lvProj.Items.Count > 0);
           
        }


        public void fill_lvProj_noFill()
        {
            BT_OR = 0; UST_OR = 0; CADT_OR = 0; EurT_OR = 0; UST_ORnb = 0; CADT_ORnb = 0; EurT_ORnb = 0;
            bool ShippedSN = (lOp.Text == "T");

            string stSql = (chSN.Checked) ? make_Sql_details() : make_Sql();
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            // string OldQID = "", Oldcpny = "";
            int NBQ = 0, NDX_IIREV = 0;
            string xrt = "0", CADamnt = "0";
    //        tSQL.Text = stSql;
           lvProj.Items.Clear();

            lvProj.Columns[13].Width = (chSN.Checked) ? 150 : 0;
            lvProj.Columns[14].Width = (chSN.Checked) ? 80 : 0;

            lvProj.BeginUpdate();
            string oldRevLID = "";
            while (Oreadr.Read())
            {
                if (GoodAMNTFT(Tools.Conv_Dbl(Oreadr["RRev_Tot"].ToString())))
                {
                    if (lv_Ex.FindStringExact(Oreadr["Cpny_Name1"].ToString()) == -1)
                    {

                        string stdesc = (chSN.Checked) ? Oreadr["PrimaxSN"].ToString() : "";//############## checked totals
                        if (oldRevLID != Oreadr["IRRevID"].ToString() || stdesc.Length > 4)
                        {
                            string dat = Oreadr["dateRRev"].ToString().Substring(0, 10);
                            if (opSHP.Checked) dat = Oreadr["ShipDat"].ToString().Substring(0, 10);
                            if (optInv.Checked) dat = Oreadr["InvoicDat"].ToString().Substring(0, 10);

                            //ListViewItem lv =lvQuotes.Items.Add("");
                            //dat=dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2) ;
                            ListViewItem lv = lvProj.Items.Add(MainMDI.frmt_date(dat)); //dat);
                            lv.SubItems.Add(Oreadr["Employee"].ToString());
                            lv.SubItems.Add(Oreadr["RID"].ToString());
                            lv.SubItems.Add(Oreadr["Quote_ID"].ToString());
                            lv.SubItems.Add(Oreadr["Cpny_Name1"].ToString());
                            lv.SubItems.Add(Oreadr["Custm_PO"].ToString());
                            // lv.SubItems.Add("$ " + MainMDI.A00(Oreadr["RRev_Tot"].ToString()));
                           lv.SubItems.Add(MainMDI.A00(Oreadr["RRev_Tot"].ToString()));
                            double dd = Tools.Conv_Dbl(Oreadr["RRev_Tot"].ToString());

                            if (oldRevLID != Oreadr["IRRevID"].ToString()) BT += dd;

                            lv.SubItems.Add(dd.ToString());
                            CADamnt = Oreadr["RRev_Tot"].ToString();
                            xrt = "1";
                            string pa = Oreadr["PA"].ToString();

                            switch (pa[0])
                            {
                                case 'U':
                                    dat = "US";
                                    if (oldRevLID != Oreadr["IRRevID"].ToString()) { UST_OR += dd; UST_ORnb++; }
                                    break;
                                case 'E':
                                    dat = "EUR";
                                    if (oldRevLID != Oreadr["IRRevID"].ToString()) { EurT_OR += dd; EurT_ORnb++; }
                                    break;
                                case 'C':
                                    dat = "CAD";
                                    if (oldRevLID != Oreadr["IRRevID"].ToString()) { CADT_OR += dd; CADT_ORnb++; }
                                    break;
                                default:
                                    MessageBox.Show("Currency Code is Invalid......PA= " + Oreadr["PA"].ToString());
                                    dat = "CAD";
                                    if (oldRevLID != Oreadr["IRRevID"].ToString()) { CADT_OR += dd; CADT_ORnb++; }
                                    break;


                            }
                            //	dat=(pa[0]=='U') ? "US" : "CAD";


                            if (pa.Length > 1 && (dat == "US" || dat == "EUR"))
                            {
                                xrt = MainMDI.A00(Convert.ToString(Tools.Conv_Dbl(pa.Substring(pa.Length - 1))));
                                CADamnt = Convert.ToString(Math.Round(Tools.Conv_Dbl(CADamnt) * Tools.Conv_Dbl(xrt), MainMDI.NB_DEC_AFF));
                            }
                            lv.SubItems.Add(dat);
                            lv.SubItems.Add("$ " + MainMDI.A00(CADamnt));
                            lv.SubItems.Add(MainMDI.A00(xrt));
                            lv.SubItems.Add(Oreadr["ProjectName"].ToString());
                            lv.SubItems.Add(Oreadr["IRRevID"].ToString());
                            stdesc = (chSN.Checked) ? Oreadr["Desc"].ToString() : "";
                           lv.SubItems.Add(stdesc);
                            stdesc = (chSN.Checked) ? Oreadr["PrimaxSN"].ToString() : "";
                            lv.SubItems.Add(stdesc);


                            lv.SubItems.Add(MainMDI.frmt_date(Oreadr["dateDlvr"].ToString().Substring(0, 10)));   // Oreadr["dateDlvr"].ToString()); 

                            lv.ForeColor = RRev_Colr(Oreadr["shiped"].ToString()[0]);

                            if (oldRevLID != Oreadr["IRRevID"].ToString()) NBQ++;

                            // fill arr_Irrev_Ndx 
                            arr_Irrev_Ndx[NDX_IIREV, 0] = Oreadr["IRRevID"].ToString();
                            arr_Irrev_Ndx[NDX_IIREV++, 1] = Convert.ToString(lvProj.Items.Count - 1);
                            oldRevLID = Oreadr["IRRevID"].ToString();
                        }
                    }
                }
            }
    
        //    lvProj.EndUpdate();
          //  lvProj.Refresh();
            OConn.Close();

            BT_OR = Math.Round(BT_OR , 2);
            UST_OR = Math.Round(UST_OR, 2);
            CADT_OR = Math.Round(CADT_OR, 2);
            EurT_OR = Math.Round(EurT_OR, 2);



           // format_LV();

           edlv_QvsOR.Items[0].SubItems[2].Text= edlv_QtOr.Items[0].SubItems[2].Text ;//= NBQ.ToString();
           edlv_QvsOR.Items[0].SubItems[3].Text= edlv_QtOr.Items[0].SubItems[3].Text ;//= " $ " + MainMDI.Curr_FRMT(BT.ToString());
           edlv_QvsOR.Items[0].SubItems[4].Text = edlv_QtOr.Items[0].SubItems[4].Text;//= " $ " + MainMDI.Curr_FRMT(avrgQ.ToString());

  
            double ALL_OR = UST_OR  + EurT_OR  + CADT_OR,ALL_ORnb=UST_ORnb + EurT_ORnb + CADT_ORnb;
            edlv_QvsOR.Items[1].SubItems[2].Text = ALL_ORnb.ToString();
            edlv_QvsOR.Items[1].SubItems[3].Text = " $ " + MainMDI.Curr_FRMT(ALL_OR.ToString());
            double avrgOR = Math.Round(ALL_OR / ALL_ORnb, 2);
            edlv_QvsOR.Items[1].SubItems[4].Text = " $ " + MainMDI.Curr_FRMT(avrgOR.ToString());


            double nbQ = Tools.Conv_Dbl(edlv_QvsOR.Items[0].SubItems[2].Text);
            double amnt = Tools.Conv_Dbl(edlv_QvsOR.Items[0].SubItems[3].Text.Replace("$", "").Replace(" ", ""));
            double avrgQ = Tools.Conv_Dbl(edlv_QvsOR.Items[0].SubItems[4].Text.Replace("$", "").Replace(" ", "")); 
            edlv_QvsOR.Items[2].SubItems[2].Text = Math.Round(ALL_ORnb / nbQ * 100.0, 0).ToString() + "%";
            edlv_QvsOR.Items[2].SubItems[3].Text = Math.Round(ALL_OR / amnt * 100.0, 0).ToString() + "%";
            avrgOR = Math.Round(avrgOR / avrgQ * 100.0, 0);
            edlv_QvsOR.Items[2].SubItems[4].Text = avrgOR.ToString() + "%";

          //  for (int i = 1; i < 5; i++) edlv_QvsOR.Items[0].SubItems[i].Text = edlv_QtOr.Items[0].SubItems[i].Text; // NBQ.ToString();

            lvProj.EndUpdate();



        }






        private string make_Sql_SYS_OLD(char AS)
        {
            string stSql = "";
          //  for (int i = 0; i < Irrev_MAX_ROW; i++) arr_Irrev_Ndx[i, 0] = "";

   
            //    string stWhr_date = (opSHP.Checked ) ? "         PSM_R_Rev.dateRRev >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_Rev.dateRRev <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   AND PSM_R_Rev.RRev_Tot <> 0 " + cnd_cpny + cnd_Emp + cnd_Ship + cnd_Tsts : "         PSM_R_Rev.dateRRev >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_Rev.dateRRev <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   AND PSM_R_Rev.RRev_Tot <> 0 " + cnd_cpny + cnd_Emp + cnd_Ship + cnd_Tsts;
            string cnd_SYS = (tkeyHidn.Text != "") ? " AND (PSM_Q_Details.[Desc] LIKE  '" + tkeyHidn.Text + "')" : "";
            if (AS == 'A') cnd_SYS = "";
            stSql = " SELECT      PSM_R_Rev.RID, PSM_R_Rev.RRev_Name, PSM_R_Rev.dateRRev, PSM_R_Detail.Rdetail_LID,PSM_R_Detail.PrimaxSN, PSM_Q_Details.[Desc],PSM_Q_Details.Ext " +
                     "      FROM   PSM_R_Detail INNER JOIN PSM_Q_Details ON PSM_R_Detail.Qdet_LID = PSM_Q_Details.Detail_LID INNER JOIN " +
                     "             PSM_R_Rev ON PSM_R_Detail.IRRev_LID = PSM_R_Rev.IRRevID " +
                     "      WHERE  (PSM_R_Detail.PrimaxSN <> '') AND (PSM_R_Rev.shiped <> 'C') AND (PSM_R_Rev.shiped <> 'D') AND (PSM_R_Rev.cpnyID <> 2170) AND " +
                     "             (PSM_R_Rev.dateRRev >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + ") AND (PSM_R_Rev.dateRRev <= " + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) +") " + cnd_SYS + 
                     " ORDER BY PSM_R_Rev.dateRRev, PSM_R_Detail.PrimaxSN ";

            return stSql;
        }
        private string make_Sql_SYS(char AS)
        {
            string stSql = "";
            string cnd_SYS = (tkeyHidn.Text != "") ? " AND (PSM_Q_Details.[Desc] LIKE  '" + tkeyHidn.Text + "')" : "";
            if (AS == 'A') cnd_SYS = "";
            stSql = " SELECT     PSM_R_Rev.RID, PSM_R_Rev.RRev_Name, PSM_R_Rev.dateRRev, PSM_R_Detail.Rdetail_LID, PSM_R_Detail.PrimaxSN, PSM_Q_Details.[Desc], " +
                    "            PSM_Q_Details.Ext, PSM_R_RevSys.R_PXTot " +
                    " FROM       PSM_R_Detail INNER JOIN  PSM_Q_Details ON PSM_R_Detail.Qdet_LID = PSM_Q_Details.Detail_LID INNER JOIN  PSM_R_Rev ON PSM_R_Detail.IRRev_LID = PSM_R_Rev.IRRevID INNER JOIN " +
                    "            PSM_R_RevSys ON PSM_R_Detail.SysLID = PSM_R_RevSys.R_sysLID " +
                    " WHERE  (PSM_R_Detail.PrimaxSN <> '') AND (PSM_R_Rev.shiped <> 'C') AND (PSM_R_Rev.shiped <> 'D') AND (PSM_R_Rev.cpnyID <> 2170) AND " +
                     "             (PSM_R_Rev.dateRRev >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + ") AND (PSM_R_Rev.dateRRev <= " + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + ") " + cnd_SYS +
                     " ORDER BY PSM_R_Rev.dateRRev, PSM_R_Detail.PrimaxSN ";

            return stSql;
        }
        string Find_Model(string Desc)
        {
            string[] KEYSYS=new string[9]{
                "Switchcmode",
                "Switch mode",
                "Inverter",
                "Fully automatic battery charger",
                "Chargeur automatique de batteries",
                "Rectifier",
                "UPS",
                "Carica batteria automatico",
                "EDI RECTIFIER"};

            string model=Desc;
          for (int i=0;i<9;i++)
          {
             if (Desc.IndexOf(KEYSYS[i]) >-1)
             {
                switch (i)
                {
                    case 0:
                    case 1:
                    case 2:
                    case 5:
                    case 6:
                    case 8:
                       model=Desc;
                        i=10;
                        break;
                    case 3:
                    case 4:
                    case 7:
//#######if desc=""Fully automatic battery charger",
                           int ipos = Desc.IndexOf("P4");
                           if (ipos == -1)
                           {
                              // MessageBox.Show("EROOOOOORRRRR............");
                               model = "???";
                               i = 10;
                           }
                           else
                           {
                               int II = Desc.IndexOf(" ", ipos);
                               model = (II > -1) ? Desc.Substring(ipos, II - ipos) : Desc.Substring(ipos, Desc.Length - ipos); //  res = desc.Substring(i2, II - i2 - 1);
                               i = 10;
                           }
                           break;
                }
             }
         }
            return model;
        }


     
        void fill_arrSYS(string Desc,string SN, string Rid,string Ext,string _SYSPRC)
        {
            string model=Find_Model(Desc);
            if (model != "" && model != "???")
            {
                for (int i = 0; i < SYSNB; i++)
                {
                    if (arr_SYS[i, 0] == "")
                    {
                        arr_SYS[i, 0] = model;
                        arr_SYS[i, 1] = "1";
                        arr_SYS[i, 2] = SN;
                        arr_SYS[i, 3] = Rid;
                        arr_SYS[i, 4] = Desc;
                        arr_SYS[i, 5] = Ext;
                        arr_SYS[i, 6] = _SYSPRC;
                        TOTExt += Tools.Conv_Dbl(Ext);
                        TOTSYS += Tools.Conv_Dbl(_SYSPRC);
                        TOTnb++;
                        i = SYSNB;
                    }
                    else
                    {
                        if (arr_SYS[i, 0] == model)
                        {
                            string sep = (arr_SYS[i, 2] != "") ? " / " : "";
                            arr_SYS[i, 1] = (Int32.Parse(arr_SYS[i, 1]) + 1).ToString();
                            arr_SYS[i, 2] += sep + SN;
                            arr_SYS[i, 3] += sep + Rid;
                            arr_SYS[i, 5] = (Tools.Conv_Dbl(arr_SYS[i, 5]) + Tools.Conv_Dbl(Ext)).ToString();
                            arr_SYS[i, 6] = (Tools.Conv_Dbl(arr_SYS[i, 6]) + Tools.Conv_Dbl(_SYSPRC)).ToString(); 
                            TOTExt += Tools.Conv_Dbl(Ext);
                            TOTSYS += Tools.Conv_Dbl(_SYSPRC);
                            TOTnb++;
                            i = SYSNB;
                        }
                    }

                }
            }
        }

        void init_ArrSYS()
        {
            for (int i=0;i<SYSNB;i++)
                for (int j=0;j<SYSCols;j++) arr_SYS[i,j]="";
        }

        public void fill_lvSYS()
        {
        
            init_ArrSYS();
            TOTExt = 0; TOTnb = 0; TOTSYS =0;
            string stSql = make_Sql_SYS(Opera);
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            tSQL.Text = stSql;

            lvSYS.Items.Clear();
            dgvSYS.Rows.Clear();
            lvSYS.BeginUpdate();


            while (Oreadr.Read())
            {

                fill_arrSYS(Oreadr["Desc"].ToString(), Oreadr["PrimaxSN"].ToString(), Oreadr["RID"].ToString(), Oreadr["Ext"].ToString(),Oreadr["R_PXTot"].ToString());
      
            }

 
            //Totals



           // lvSYS.Items.Clear();

            for (int i = 0; i < SYSNB; i++)
            {
                if (arr_SYS[i, 0] != "")
                {
                    ListViewItem lv = lvSYS.Items.Add(arr_SYS[i, 4]); //model
                    for (int j = 0; j < 4; j++) lv.SubItems.Add(arr_SYS[i, j]);
                    dgvSYS.Rows.Add(arr_SYS[i, 4], arr_SYS[i, 0], MainMDI.A00(arr_SYS[i, 1], 3), arr_SYS[i, 2], arr_SYS[i, 3], MainMDI.Curr_FRMT(arr_SYS[i, 5].ToString()), MainMDI.Curr_FRMT(arr_SYS[i, 6].ToString()));
                }
                else i = SYSNB;

            }

            if (TOTExt != 0 && TOTnb != 0)
            {
                lTOTnb.Text = MainMDI.A00(TOTnb, 3);
                lTOTSYS.Text = " $ " + MainMDI.Curr_FRMT(TOTExt.ToString());// MainMDI.A00(TOTExt.ToString(), 2);

              //  dgvSYS.Rows.Add("    TOTALS    ", "       TOTALS    ", MainMDI.A00(TOTnb, 3), "   ", "     ", MainMDI.A00(TOTExt.ToString(), 2));
            //    dgvSYS.Rows[dgvSYS.Rows.Count - 1].DefaultCellStyle.BackColor = Color.Salmon;
            }
            //    if (ShippedSN) list_ShippedSN();
            lvSYS.EndUpdate();
            lvSYS.Refresh();
            OConn.Close();
       
            //lAvrg.Text = (BT != 0 && NBQ != 0) ? " $ " + MainMDI.Curr_FRMT(Convert.ToString(Math.Round(BT / NBQ, MainMDI.NB_DEC_AFF))) : "$ 0";
            //   if (cnd_Tsts.Length > 0) lOp.Text = "T";
        }





        public void fill_lvProj_OLDok()
        {
            double BT = 0, UST = 0, CADT = 0, EurT = 0;
            bool ShippedSN = false;
            string cnd_Tsts = "", stSql = "";
            for (int i = 0; i < Irrev_MAX_ROW; i++) arr_Irrev_Ndx[i, 0] = "";

            //new for shipped with SN
            if (lOp.Text == "T")
            {
                // cnd_Tsts = " AND PSM_R_Rev.Tests <>'C' AND PSM_R_Rev.Tests <>'M' AND PSM_R_Rev.Tests <>'A' ";
                ShippedSN = true;
                lOp.Text = "S";
            }
            //    string stWhr_date = (opSHP.Checked ) ? "         PSM_R_Rev.dateRRev >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_Rev.dateRRev <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   AND PSM_R_Rev.RRev_Tot <> 0 " + cnd_cpny + cnd_Emp + cnd_Ship + cnd_Tsts : "         PSM_R_Rev.dateRRev >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_Rev.dateRRev <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   AND PSM_R_Rev.RRev_Tot <> 0 " + cnd_cpny + cnd_Emp + cnd_Ship + cnd_Tsts;
            string cnd_cpny = (lcpnyID.Text != "-1") ? " AND PSM_Q_IGen.CPNY_ID =" + lcpnyID.Text : "";
            string cnd_Emp = (lempID.Text != "-1") ? " AND PSM_Q_IGen.Employ_ID =" + lempID.Text : "";
            string cnd_Ship = (lOp.Text != "A") ? " AND PSM_R_Rev.shiped ='" + lOp.Text + "'" : "";
            if (lOp.Text == "*") cnd_Ship = " AND (PSM_R_Rev.shiped =' ' OR PSM_R_Rev.shiped ='F' OR PSM_R_Rev.shiped ='" + lOp.Text + "') ";



            if (opSHP.Checked)
                stSql = " SELECT  PSM_R_Rev.Tests, PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_Q_IGen.Quote_ID, PSM_COMPANY.Cpny_Name1, PSM_R_Rev.Custm_PO, PSM_R_Rev.dateRRev, " +
                         "         PSM_R_Rev.RRev_Tot, PSM_R_Rev.RRev_Name, PSM_R_Rev.shiped, PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS Employee, PSM_Q_IGen.curr, " +
                         "         PSM_R_Rev.Rnk, PSM_Q_IGen.CPNY_ID, PSM_Q_IGen.Employ_ID, PSM_R_Rev.PA , PSM_Q_IGen.ProjectName , PSM_R_SLots.ShipDat " +
                         " FROM    PSM_Q_IGen INNER JOIN PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID INNER JOIN " +
                         "         PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID INNER JOIN PSM_R_SLots ON PSM_R_Rev.IRRevID = PSM_R_SLots.l_RRevLID " +
                         " WHERE   PSM_R_Rev.shiped <> 'D' AND PSM_COMPANY.Cpny_ID <> 2170 AND PSM_R_Rev.Custm_PO <> N'TEST' and " +
                         "         PSM_R_SLots.ShipDat >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_SLots.ShipDat <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   AND PSM_R_Rev.RRev_Tot <> 0 " + cnd_cpny + cnd_Emp + cnd_Ship + cnd_Tsts +
                         " ORDER  by  PSM_R_Rev.IRRevID, PSM_R_Rev.Rnk, PSM_R_SLots.ShipDat desc   ";
            else
            {
                if (optInv.Checked)
                    stSql = " SELECT  PSM_R_Rev.Tests, PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_Q_IGen.Quote_ID, PSM_COMPANY.Cpny_Name1, PSM_R_Rev.Custm_PO, PSM_R_Rev.dateRRev, PSM_R_Rev.RRev_Tot, PSM_R_Rev.RRev_Name, PSM_R_Rev.shiped,  " +
                   "         PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS Employee, PSM_Q_IGen.curr, PSM_R_Rev.Rnk, PSM_Q_IGen.CPNY_ID, PSM_Q_IGen.Employ_ID, PSM_R_Rev.PA, PSM_Q_IGen.ProjectName, PSM_R_SBills.InvoicDat " +
                   " FROM    PSM_Q_IGen INNER JOIN PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID INNER JOIN  PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID INNER JOIN PSM_R_SBills ON PSM_R_Rev.IRRevID = PSM_R_SBills.b_RRevLID " +
                   " WHERE     (PSM_R_Rev.shiped <> 'D') AND (PSM_COMPANY.Cpny_ID <> 2170) AND (PSM_R_Rev.Custm_PO <> N'TEST') AND (PSM_R_Rev.RRev_Tot <> 0) " +
                   " AND        PSM_R_SBills.InvoicDat  >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_SBills.InvoicDat <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + " and ( substring( PSM_R_SBills.AccInv,1,6) <>'tmpNB_')" +
                   " ORDER BY PSM_R_Rev.IRRevID, PSM_R_Rev.Rnk, PSM_R_SBills.InvoicDat ";
                else
                    stSql = " SELECT  PSM_R_Rev.Tests, PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_Q_IGen.Quote_ID, PSM_COMPANY.Cpny_Name1, PSM_R_Rev.Custm_PO, PSM_R_Rev.dateRRev, " +
                            "         PSM_R_Rev.RRev_Tot, PSM_R_Rev.RRev_Name, PSM_R_Rev.shiped, PSM_SALES_AGENTS.First_Name + ' ' + PSM_SALES_AGENTS.Last_Name AS Employee, PSM_Q_IGen.curr, " +
                            "         PSM_R_Rev.Rnk, PSM_Q_IGen.CPNY_ID, PSM_Q_IGen.Employ_ID, PSM_R_Rev.PA , PSM_Q_IGen.ProjectName " +
                            " FROM    PSM_Q_IGen INNER JOIN PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID INNER JOIN " +
                            "         PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID " +
                            " WHERE   PSM_R_Rev.shiped <> 'D' AND PSM_COMPANY.Cpny_ID <> 2170 AND PSM_R_Rev.Custm_PO <> N'TEST' and " +
                            "         PSM_R_Rev.dateRRev >=" + MainMDI.SSV_date(dpFrom.Value.ToShortDateString()) + "  AND PSM_R_Rev.dateRRev <=" + MainMDI.SSV_date(dpTo.Value.ToShortDateString()) + "   " + cnd_cpny + cnd_Emp + cnd_Ship + cnd_Tsts +
                            " ORDER   BY PSM_R_Rev.dateRRev, PSM_R_Rev.IRRevID, PSM_R_Rev.Rnk               ";
            }


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
         //   string OldQID = "", Oldcpny = "";
            int NBQ = 0, NDX_IIREV = 0;
            string xrt = "0", CADamnt = "0";
            tSQL.Text = stSql;
            lvProj.Items.Clear();

            lvProj.BeginUpdate();
            string oldRevLID = "";
            while (Oreadr.Read())
            {
                if (lv_Ex.FindStringExact(Oreadr["Cpny_Name1"].ToString()) == -1)
                {

                    if (oldRevLID != Oreadr["IRRevID"].ToString())
                    {
                        string dat = Oreadr["dateRRev"].ToString().Substring(0, 10);
                        if (opSHP.Checked) Oreadr["ShipDat"].ToString().Substring(0, 10);
                        if (optInv.Checked) Oreadr["InvoicDat"].ToString().Substring(0, 10);

                        //ListViewItem lv =lvQuotes.Items.Add("");
                        //dat=dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2) ;
                        ListViewItem lv = lvProj.Items.Add(MainMDI.frmt_date(dat)); //dat);
                        lv.SubItems.Add(Oreadr["Employee"].ToString());
                        lv.SubItems.Add(Oreadr["RID"].ToString());
                        lv.SubItems.Add(Oreadr["Quote_ID"].ToString());
                        lv.SubItems.Add(Oreadr["Cpny_Name1"].ToString());
                        lv.SubItems.Add(Oreadr["Custm_PO"].ToString());
                        lv.SubItems.Add("$ " + MainMDI.A00(Oreadr["RRev_Tot"].ToString()));
                        double dd = Tools.Conv_Dbl(Oreadr["RRev_Tot"].ToString());
                        BT += dd;
                        lv.SubItems.Add(dd.ToString());
                        CADamnt = Oreadr["RRev_Tot"].ToString();
                        xrt = "1";
                        string pa = Oreadr["PA"].ToString();

                        switch (pa[0])
                        {
                            case 'U':
                                dat = "US";
                                UST += dd;
                                break;
                            case 'E':
                                dat = "EUR";
                                EurT += dd;
                                break;
                            case 'C':
                                dat = "CAD";
                                CADT += dd;
                                break;
                            default:
                                MessageBox.Show("Currency Code is Invalid......PA= " + Oreadr["PA"].ToString());
                                dat = "CAD";
                                CADT += dd;
                                break;


                        }
                        //	dat=(pa[0]=='U') ? "US" : "CAD";


                        if (pa.Length > 1 && (dat == "US" || dat == "EUR"))
                        {
                            xrt = MainMDI.A00(Convert.ToString(Tools.Conv_Dbl(pa.Substring(pa.Length - 1))));
                            CADamnt = Convert.ToString(Math.Round(Tools.Conv_Dbl(CADamnt) * Tools.Conv_Dbl(xrt), MainMDI.NB_DEC_AFF));
                        }
                        lv.SubItems.Add(dat);
                        lv.SubItems.Add("$ " + MainMDI.A00(CADamnt));
                        lv.SubItems.Add(MainMDI.A00(xrt));
                        lv.SubItems.Add(Oreadr["ProjectName"].ToString());
                        lv.SubItems.Add(Oreadr["IRRevID"].ToString());

                        lv.ForeColor = RRev_Colr(Oreadr["shiped"].ToString()[0]);
                        NBQ++;

                        // fill arr_Irrev_Ndx 
                        arr_Irrev_Ndx[NDX_IIREV, 0] = Oreadr["IRRevID"].ToString();
                        arr_Irrev_Ndx[NDX_IIREV++, 1] = Convert.ToString(lvProj.Items.Count - 1);
                        oldRevLID = Oreadr["IRRevID"].ToString();
                    }
                }
            }
            if (ShippedSN) list_ShippedSN();
            lvProj.EndUpdate();
            lvProj.Refresh();
            OConn.Close();

            BT = Math.Round(BT, 2);
            UST = Math.Round(UST, 2);
            CADT = Math.Round(CADT, 2);

            tBigTot.Text = " $ " + MainMDI.Curr_FRMT(BT.ToString());
            tUSDTot.Text = " $ " + MainMDI.Curr_FRMT(UST.ToString());
            tCADTot.Text = " $ " + MainMDI.Curr_FRMT(CADT.ToString());
            lNBQ.Text = NBQ.ToString();

            lAvrg.Text = (BT != 0 && NBQ != 0) ? " $ " + MainMDI.Curr_FRMT(Convert.ToString(Math.Round(BT / NBQ, MainMDI.NB_DEC_AFF))) : "$ 0";
            if (cnd_Tsts.Length > 0) lOp.Text = "T";
        }




        private void list_ShippedSN()
        {
            lvProj.Columns[10].Width = 70;
            for (int i = 0; i < Irrev_MAX_ROW; i++)
            {
                if (arr_Irrev_Ndx[i, 0] != "")
                {
                   
                    int ndx = Int32.Parse(arr_Irrev_Ndx[i, 1]);
                    lvProj.Items[ndx].SubItems[10].Text = MainMDI.Find_One_Field("SELECT count( PSM_R_SBill_SN.sn_SN) as nbSN FROM  PSM_R_SBills INNER JOIN PSM_R_SLots ON PSM_R_SBills.b_RRevLID = PSM_R_SLots.l_RRevLID INNER JOIN PSM_R_SBill_SN ON PSM_R_SBills.Bil_LID = PSM_R_SBill_SN.BSN_LID " +
                                              " WHERE     PSM_R_SLots.l_RRevLID =" + arr_Irrev_Ndx[i, 0]);
                }
                else i = Irrev_MAX_ROW;
            }
        }

        private Color RRev_Colr(char c)
		{
			Color clr=Color.Chocolate ;
			switch (c)
			{
				case '*':
				case ' ':
				case 'P':
					clr=Color.Blue ;
					break;
				case 'S':
					clr=Color.Black ;
					break;
				case 'F':
					clr=Color.Salmon ;
					break;
				case 'D':
					clr=Color.Green  ;
					break;
				case 'C':
					clr=Color.LightBlue   ;
					break;
					
			}
			return clr;
		}


		private void init_disp( )
		{
            char c = Opera;
			Color clr=Color.Red ;
            lvQuotes.Visible = (c == 'Q' || c == 'V');
		//	lvProj.Visible =(c=='R');
           dgvSYS.Visible = (c == 'S' || c == 'A');
        //    lvSYS.Visible = (c == 'S' || c == 'A');
		//	grpTot.Visible =false; 
		//	opAll.Visible =(c=='R');
		//	opSHP.Visible =(c=='R');
		//	opInP.Visible =(c=='R');
		//	opFapp.Visible =(c=='R');
		//	grpQt.Visible =(c=='Q');


			switch (c)
			{
				case 'Q':
					lQ.Text = "Quotes #:";
				//	lbgtot.Text = "Totals:";
					break;
				case 'R':
					lQ.Text = "Projects #:";
				//	lbgtot.Text = "CAD Total:";
                //    lbgtot.Text = "Totals:";
					clr =Color.Blue ;
					break;
                case 'S':
                case 'A':
                    lQ.Text = "SYSTEMS #:";
                    //	lbgtot.Text = "CAD Total:";
                    //    lbgtot.Text = "Totals:";
                    clr = Color.Green;
                    break;

			}
			lemp.ForeColor =clr;
			lQ.ForeColor =clr;
			lfrom.ForeColor =clr;
			lTo.ForeColor =clr;
			lcpny.ForeColor =clr;
			lav.ForeColor =clr;
		//	lbgtot.ForeColor =clr;

		}

		private void Disp_QR()
		{
			this.Cursor=Cursors.WaitCursor;   
			switch (Opera)
			{
				case 'Q':
				//	lvQuotes.Visible =false;
                                edlv_QtOr.Items.Clear();
                               edlv_QvsOR.Items.Clear();
					fill_lvQuote();
                if (lvQuotes.Items.Count >0)    fill_lvProj_noFill();
                	lvQuotes.Columns[6].Width =80;
                    //lvQuotes.Visible =true;
                    //dgvSYS.Visible = false;
                    LV_Visible(Opera);
					break;
				case 'V':
					//lvQuotes.Visible =false;
            
					fill_lvQuote();
                    fill_lvProj(); 
					lvQuotes.Columns[6].Width =80;
                    LV_Visible(Opera);
                    //lvQuotes.Visible =true;
                    //dgvSYS.Visible = false;
					break;
				case 'R':
                                edlv_QtOr.Items.Clear();
                                 edlv_QvsOR.Items.Clear();

                   // Opera = 'R';
					fill_lvProj();
                    LV_Visible(Opera);

					break;
                case 'S':
                case 'A':

                    LV_Visible(Opera);
                    fill_lvSYS();
                    break;
			}
		//	grpTot.Visible = (tBigTot.Text !="");  
			this.Cursor=Cursors.Default ;  

		}

       void  LV_Visible(char opera)
        {

            lvProj.Visible = false;
            dgvSYS.Visible = false;
            lvQuotes.Visible =false;
            dgvSYS.Visible = false;
            switch (Opera)
            {
                case 'Q':
                    lvQuotes.Visible = true;
                    break;
                case 'V':
                    lvQuotes.Visible = true;
                    break;
                case 'R':
                    lvProj.Visible = true;
                    break;
                case 'S':
                case 'A':
                    dgvSYS.Visible = true;
                    break;
            }


        }
        private void Quotes_status()
        {
            USD_SQ = 0; EUR_SQ = 0; CAD_SQ = 0; USD_SQnb = 0; EUR_SQnb = 0; CAD_SQnb = 0; 


            for (int i = 0; i < lvQuotes.Items.Count; i++)
            {
                string st = MainMDI.Find_One_Field("SELECT PSM_Q_SOL.status_Rev FROM PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid " +
                    " WHERE PSM_Q_IGen.i_Quoteid=" + lvQuotes.Items[i].SubItems[7].Text + " and  PSM_Q_SOL.status_Rev='C'");

                if (st != MainMDI.VIDE)
                {
                    lvQuotes.Items[i].ForeColor = Color.Blue;
                   
                    double dd= Tools.Conv_Dbl(lvQuotes.Items[i].SubItems[4].Text);

                    switch (lvQuotes.Items[i].SubItems[6].Text[0])
                    {
                        case 'U':

                            USD_SQ += dd;
                            USD_SQnb++;
                            break;
                        case 'E':
                            EUR_SQ += dd;
                            EUR_SQnb++;
                            break;
                        case 'C':
                            CAD_SQ += dd;
                            CAD_SQnb++;
                            break;

                    }


          
                }

            }
          

        }
		private void aff_statis()
		{
			switch (Opera)  
			{

				case 'Q':  //Quote Stat
					init_disp();
 					break;
				case 'P':  //Order stat
					init_disp();
					break;
                case 'S':  //Order stat
                    init_disp();
                    break;
				default:
					MessageBox.Show("Coming Sooooooooooooooooon...on your Screen !! "); 
					break;
			}
		}
	
/*
		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			switch (toolBar1.Buttons.IndexOf(e.Button))    
			{

				case 0:  //Quote Stat
					//btnQt_Click(sender,e); 
					init_disp('Q');
 
					break;
				case 1:  //Order stat
				//	btnRRev_Click(sender ,e);
					init_disp('R');
					break;
				case 2:
					MessageBox.Show("Coming Sooooooooooooooooon...on your Screen !! "); 
					break;
			}
		}
		*/
		private void picExit_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}



		private void Stati_Resize(object sender, System.EventArgs e)
		{
			//picExit.Left = this.Width -48;3
    //        tBigTot.Left = grpTot.Width - 110;// 184;  //144
    //        tUSBigTot.Left = grpTot.Width - 110;
    //        tBigTot.Left = grpTot.Width - 110;


	//		lbgtot.Left = grpTot.Width - 304 ;//344;   //200
			lvQuotes.Height =this.Height - 152 - 80 ;  //136 
			lvProj.Height =this.Height - 152 - 80 ;
			Math.Ceiling(15.25);
		}

		private void btnCHNGCmpny_Click(object sender, System.EventArgs e)
		{
		
		}

		private void picSeek_Click(object sender, System.EventArgs e)
		{
			if (cbCompany.Visible )
			{
				cbCompany.Visible =false;
			}
			else
			{
				bool FOUND=false;
				if (ndxfound > cbCompany.Items.Count) ndxfound =0; 
			   
				for (int i=ndxfound;i<cbCompany.Items.Count;i++)
				{
					//if (cbCompany.Items[i].ToString().ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1) 
					int ln= (tKey.Text.Length < cbCompany.Items[i].ToString().Length ) ?   tKey.Text.Length :  cbCompany.Items[i].ToString().Length;
					if (cbCompany.Items[i].ToString().Substring(0,ln).ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1) 
					{   
						cbCompany.SelectedIndex = i;
						ndxfound =i+1;
						i=cbCompany.Items.Count;
						cbCompany_SelectedIndexChanged(sender,e) ;// cbOptGrp_SelectedValueChanged(sender,e);
						//if (ndxfound <cbOptGrp.Items.Count) button1.Text ="Next"; 
						FOUND=true;
						cbCompany.Visible =true;
					}
				}
				if (!FOUND) 
				{
					ndxfound=0;
					  //button1.Text ="Search"; 
					MessageBox.Show("KeyWord not Found !!!!"); 
				}
				

			}
		}

		private void fill_cbCompany()
		{
			
			string stSql = "select Cpny_Name1 FROM PSM_Company order by Cpny_Name1";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			cbCompany.Items.Add("ALL");
			while (Oreadr.Read ()) cbCompany.Items.Add( Oreadr["Cpny_Name1"].ToString()  ); 
			OConn.Close(); 
				 
		}

		private void find_R_for_Q(string QID)
		{
			string stSql = "select RID FROM PSM_Company order by Cpny_Name1";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			cbCompany.Items.Add("ALL");
			while (Oreadr.Read ()) cbCompany.Items.Add( Oreadr["Cpny_Name1"].ToString()  ); 
			OConn.Close(); 
				 
		}

		private void cbCompany_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
	        if (cbCompany.Text =="ALL") lcpnyID.Text = "-1";
			else lcpnyID.Text =MainMDI.Find_One_Field("SELECT PSM_COMPANY.Cpny_ID FROM PSM_Company where  Cpny_Name1='" + cbCompany.Text +"'");
            if (lcpnyID.Text == MainMDI.VIDE ) lcpnyID.Text = "0"  	;	         
		}
		private void fill_cbSal_AG(string SA)
		{
			string stSql = "select First_Name, Last_Name FROM PSM_SALES_AGENTS where SA='" + SA + "'";
	//		string stOR="";
	//		stOR   = (SA=="S" ) ? " OR SA ='T' " : " OR SA ='B' ";
	//		string stSql ="select First_Name, Last_Name FROM PSM_SALES_AGENTS where SA='" + SA + "'" + stOR  ; //:"select First_Name, Last_Name FROM PSM_SALES_AGENTS where SA='" + SA + "'"; 
		
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			cbEmploy.Items.Add("ALL");
			while (Oreadr.Read ())
			{
				stSql=Oreadr[0].ToString() + " " +  Oreadr[1].ToString();
				if (SA=="S")	cbEmploy.Items.Add( stSql  );  //employee
			}
			OConn.Close(); 
				 
		}

		private void cbEmploy_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string stSql="";
			if (cbEmploy.Text =="ALL") lempID.Text = "-1";
			else
			{
				stSql="select SA_ID  from PSM_SALES_AGENTS where (First_Name + ' ' + Last_Name) ='" + cbEmploy.Text + "' and SA='S'" ;
				lempID.Text= MainMDI.Find_One_Field(stSql);
			}
			if (lempID.Text == MainMDI.VIDE ) lempID.Text="0"; 
		
		}

		private void Stati_Load(object sender, System.EventArgs e)
		{
           // grpfind.Height = 166;
            if (MainMDI.User.ToLower() == "ede")
            {
                opSHP_TSTnc.Visible = true;
                tSQL.Visible = true;
               // txCMP.Visible = true;
            }

            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!"; 
			MainMDI.Write_Whodo_SSetup("Statistics",'I');
			picSeek.Focus();
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
            fill_lvP5500();
            fill_All_cb("cvi");
            fill_Sales("C1");
		}
        public void fill_lvP5500()
        {


            cbRectifiers.Items.Clear();
            string stSql = "SELECT * FROM PSM_RECTIFIERS  ORDER BY IDin";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            cbRectifiers.Items.Add("ALL");
            while (Oreadr.Read())
            {
                cbRectifiers.Items.Add(Oreadr[1].ToString());


            }

        }
		private void lvProj_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{

			seelCol=e.Column; 
			ListView myListView = (ListView)sender;
			if ( e.Column == lvSorterProj.SortColumn )
			{
				
				if (lvSorterProj.Order == System.Windows.Forms.SortOrder.Ascending)
				{
					lvSorterProj.Order = System.Windows.Forms.SortOrder.Descending;
				}
				else
				{
					lvSorterProj.Order = System.Windows.Forms.SortOrder.Ascending;
				}
			}
			else
			{
	
				lvSorterProj.Order = (srtType=='A') ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
				srtType=(srtType=='A') ? 'D' : 'A';
			//	lvSorterProj.SortColumn = (e.Column!=6) ? e.Column : 7 ;
                lvSorterProj.SortColumn = (e.Column == 6 || e.Column == 9) ? 7 : e.Column;
				//lvSorterProj.SortColumn = e.Column;
			}
            		
			myListView.Sort();
			oldSC=lvSorterProj.SortColumn;
			lvSorterProj.SortColumn =0;



		
		}


		private void picdisp_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("SCRN= " + SystemInformation.PrimaryMonitorSize.ToString() + this.Width.ToString () +" / " + this.Height.ToString ()  );  
			//char c='R';
			init_QT_TOT();
			if (lTo.ForeColor ==Color.Red ) 
				if (opQt.Checked ) Opera='Q';
                else Opera = 'P';
			Disp_QR();
			lvQuotes.Height =this.Height - 152 - 80 ;  //136 
			lvProj.Height =this.Height - 152 - 80 ;         
		}

		private void opAll_CheckedChanged(object sender, System.EventArgs e)
		{
			lOp.Text ="A";
		}

		private void opInP_CheckedChanged(object sender, System.EventArgs e)
		{
			lOp.Text ="*";
		}

		private void opSHP_CheckedChanged(object sender, System.EventArgs e)
		{
			lOp.Text ="S";
           
		}

		private void opFapp_CheckedChanged(object sender, System.EventArgs e)
		{
			lOp.Text ="F";
		}

		private void btnQt_Click(object sender, System.EventArgs e)
		{
			lvQuotes.Height-=10;
			MessageBox.Show ( "QH= " + lvQuotes.Height);

		}

		private void chkProj_CheckedChanged(object sender, System.EventArgs e)
		{

		}

	

		private void init_QT_TOT()
		{
			lProjNB.Visible =(opQP.Checked && grpQt.Visible )   ;
			lProjNB0.Visible =(opQP.Checked && grpQt.Visible );
			lSucc.Visible =(opQP.Checked && grpQt.Visible );
			lSucc0.Visible=(opQP.Checked && grpQt.Visible );
			lProjNB.Text ="";
			lSucc.Text ="";
			lNBQ.Text ="";
			lAvrg.Text ="";
			tBigTot.Text ="";
			grpTot.Refresh (); 
		}

		private void toolBar1_DoubleClick(object sender, System.EventArgs e)
		{
			tSQL.Visible =!tSQL.Visible;
		}

		private void chkcat_CheckedChanged(object sender, System.EventArgs e)
		{
            if (chkcat.Checked)
            {
                opAll.Checked = true;
                grpAdv.Visible = chkcat.Checked;
                grpfind.Height = (chkcat.Checked) ? 301 : 131;  //171
                // grpcat.Visible = (grpAdv.Visible && 
                //	grpcat.Visible = chkcat.Checked ;
                //	opAll.Checked = !chkcat.Checked  ;
            }
            else chkModel.Checked = true;

		}

        private void picOrders_Click(object sender, System.EventArgs e)
        {
            tls_terri.Visible = true;
            findQT.Visible = true;
            grpCH.Visible = false;
            grpCharg.Visible = false;

            if (!grpAdv.Visible) grpfind.Height = 220;// 166;
            enable_QT_OR('O');

        }
        void seekOrders()
        {
            //picOrders.BackColor = Color.Wheat;
            //picQT.BackColor = Color.LemonChiffon;
            grpTot.Visible = true;
            if (GoodAMNTFT())
            {
                disp_grps(false);
                init_TOTs();
                //    grpCurr.Visible = false;
                groupBox3.Visible = true;
                grpTOTsys.Visible = false;
                Opera = 'R';
                aff_statistics();
                grpcat.Enabled = true;
                grpDates.Enabled = true;
                string lbldat = " Order Date ";
                if (opSHP.Checked) lbldat = " Shipping Date ";
                if (optInv.Checked) lbldat = " Invoicing Date ";
                lvProj.Columns[0].Text = lbldat;
                disp_grps(true);
            }
            else MessageBox.Show("Invalid Amounts !!!!!");

            lvisi.Text = lvProj.Visible.ToString();


        }
		private void aff_statistics()
		{
			//	MessageBox.Show("SCRN= " + SystemInformation.PrimaryMonitorSize.ToString() + this.Width.ToString () +" / " + this.Height.ToString ()  );  
			init_QT_TOT();
			init_disp();
			Disp_QR();

		}

        bool GoodAMNTFT()
        {
            return (AMNT_TO >= AMNT_FM);
        }
        bool GoodAMNTFT(double AM)
        {

            if (AMNT_FM == 0 && AMNT_TO == 0) return true;
            return (AM >=AMNT_FM && AM<= AMNT_TO ) ;

        }
        void init_TOTs()
        {
            tBigTot.Text = "0";
            tUSDTot.Text = "0";
            tCADTot.Text = "0";
            lEROTot.Text = "0";
        }

        void disp_grps(bool st)
        {
            switch (Opera)
            {
                case 'Q':
                    if (st) grpTOTqo.Text = "Quotes VS  Succ. Quotes";
                     grpTOTqo.Visible = st;
                    grpCurr.Visible = st;
                    grpQvsR.Visible = st;
                    
                    break;
                case 'R':
                    if (st) grpTOTqo.Text = "Orders";
                    grpTOTqo.Visible = st;
                    grpCurr.Visible = st;
                    grpQvsR.Visible = false;
                    break;
            }


        }

        void enable_QT_OR(char QO)
        {

            switch (QO)
            {
                case 'Q':
                    findQT.BackColor = Color.Moccasin;
                    tlsbtn_Cust.Visible = true;
                //    tls_terri.Visible = true;
                    toolStripButton2.Visible = false;
                    tlsbtnRectif.Visible = false;
                    toolStripButton1.Visible = false;
                    break;
                case 'O':
                    findQT.BackColor = Color.LightSkyBlue;
                    tlsbtn_Cust.Visible =false ;
              //      tls_terri.Visible = false;
                    toolStripButton2.Visible = true;
                    tlsbtnRectif.Visible = true;
                    toolStripButton1.Visible =true ;
                    break;


            }

        }

        private void picQT_Click(object sender, System.EventArgs e)
        {
           tls_terri.Visible = true;
            findQT.Visible = true;
            grpCH.Visible = false;
            grpCharg.Visible = false;
            if (!grpAdv.Visible) grpfind.Height = 220;// 166;
            enable_QT_OR('Q');
          
        }

        void seekQuote()
        {

            //picQT.BackColor = Color.Wheat;
            //picOrders.BackColor = Color.LemonChiffon;
            grpTot.Visible = true;
            disp_grps(false);
            if (GoodAMNTFT())
            {
                grpTOTqo.Visible = false;
                //      grpCurr.Visible = false;
                init_TOTs();
                //   grpCurr.Visible = true;
                groupBox3.Visible = true;
                grpTOTsys.Visible = false;
                lvSorter.SortColumn = -1;
                //chkcat.Checked = false; 
                // aff_statistics('Q');
                Opera = 'Q';
                aff_statistics();
                //   lbldates.Text = "Quote Date";
                grpcat.Enabled = false;
                grpDates.Enabled = false;

                grpTOTqo.Visible = true;
                grpCurr.Visible = true;
                grpQvsR.Visible = true;
                // lvQuotes.Visible = true;
                disp_grps(true);
            }
            else MessageBox.Show("Invalid Amounts !!!!!");
            lvisi.Text = lvProj.Visible.ToString();

        }

		private void label1_Click(object sender, System.EventArgs e)
		{
			picQT_Click (sender,e);
		}

		private void label2_Click(object sender, System.EventArgs e)
		{
			picOrders_Click(sender,e); 
		}

		private void picXL_Click(object sender, System.EventArgs e)
		{
      //      string st = @"\titi.dts";
      //      RunDTSPackage(st);
	/*		
	//		
	//		OleDbConnection OConn  = new OleDbConnection(MainMDI.M_stCon_XL);
	//		OConn.Open ();
      //      string stSql="";
			OleDbCommand Ocmd = new OleDbCommand();//    OConn.CreateCommand();
            Ocmd.Connection=OConn;
			try
			{
				stSql= "insert into MyTable (Col1,Col2) values ('Employee','Project #')";
				Ocmd.CommandText = stSql ;
				Ocmd.ExecuteNonQuery();//  .ExecuteNonQuery(); 

		//		stSql = "insert into myTable (Col1,col2) values ('mdimassi','P2570')";
		//		Ocmd.CommandText = stSql ;
		//		Ocmd.ExecuteNonQuery(); 
			}
		
			catch (OleDbException Oexp) 
			{
				string stXP  =Oexp.Message ;
				MessageBox.Show("STSQL= " + stSql + "\n" + "Msg= " + stXP);  
				
			}
			
			OConn.Close(); 

		//	if (lvProj.Visible && lvProj.Items.Count >0) Xport_XL('P');
	//		else if (lvQuotes.Visible && lvQuotes.Items.Count >0) Xport_XL('Q');
*/
            if (dgvSYS.Visible) write_XLSYS();
            else
            {
                if (grpcat.Enabled) write_XLPrj();
                else write_XLQuotes();
            }
		}





		private void Xport_XLpara(char c)
		{
			   Decoder uniDecoder = Encoding.Unicode.GetDecoder();
			int tt=Convert.ToInt32('A');
		//	char cc=uniDecoder.GetChars(6???
           MessageBox.Show("int A="+ tt.ToString ());  
		}
        /*
		private void write_XL(object[] objHdrs,object[,] objData,int NBCols)
		{
			Object m_objOpt= System.Reflection.Missing.Value ;   
			Excel.Application  m_objXL = new Excel.Application()   ;
			Excel.Workbooks  m_objbooks = m_objXL.Workbooks ;
			Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);    
            Excel.Sheets m_objSheets = m_objBook.Worksheets ;
			Excel._Worksheet m_objSheet =(Excel._Worksheet) m_objSheets.get_Item(1);
  
			object[] objHdrs = {"Project Date","Employee","Project#","Quote#","Company Name","PO #","Amount","Currency"};
			Excel.Range  m_objRng = m_objSheet.get_Range("A1","H1");
			m_objRng.Value2=objHdrs ;
			Excel.Font m_objFont = m_objRng.Font ;
			m_objFont.Bold = true;

		//	object[,] objData = new object[500,2];
			for (int i=0;i<500 ;i++)
			{
				objData[i,0]= (i< lvQuotes.Items.Count ) ? lvQuotes.Items[i].SubItems[1].Text : "" ;  
				objData[i,1]= (i< lvQuotes.Items.Count ) ? lvQuotes.Items[i].SubItems[2].Text : ""  ;   
			}

			m_objRng = m_objSheet.get_Range("A2",m_objOpt);
			m_objRng = m_objRng.get_Resize(500,2);
			m_objRng.Value2  = objData;   

			m_objBook.SaveAs(MainMDI.XL_Path+ @"\XL_stat.xls",m_objOpt,m_objOpt,m_objOpt ,m_objOpt ,m_objOpt ,Excel.XlSaveAsAccessMode.xlNoChange ,m_objOpt ,m_objOpt ,m_objOpt ,m_objOpt,m_objOpt );
			m_objBook.Close (false,m_objOpt ,m_objOpt );
			m_objXL.Quit (); 


			
		}
         * */

        private void write_XLQuotesOldOK()
        {
            System.IO.File.Delete(MainMDI.XL_Path + @"\XL_stat.xls");
            Object m_objOpt = System.Reflection.Missing.Value;
            Excel.Application m_objXL = new Excel.Application();
            Excel.Workbooks m_objbooks = m_objXL.Workbooks;
            Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);
            Excel.Sheets m_objSheets = m_objBook.Worksheets;
            Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

            object[] objHdrs = { "Quote Date", "Employee", "Quote#", "Company Name", "Amount", "Currency" };
            Excel.Range m_objRng = m_objSheet.get_Range("A1", "F1");
            m_objRng.Value2 = objHdrs;
            Excel.Font m_objFont = m_objRng.Font;
            m_objFont.Bold = true;

            object[,] objData = new object[MainMDI.MAX_XLlines_XPRT  , 6];
            for (int i = 0; i < MainMDI.MAX_XLlines_XPRT; i++)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (i < lvQuotes.Items.Count) objData[i, j] = (j != 5) ? "'" + lvQuotes.Items[i].SubItems[j].Text : "'" + lvQuotes.Items[i].SubItems[6].Text;
                }
            }

            m_objRng = m_objSheet.get_Range("A2", m_objOpt);
            m_objRng = m_objRng.get_Resize(MainMDI.MAX_XLlines_XPRT, 6);
            m_objRng.Value2 = objData;

            m_objBook.SaveAs(MainMDI.XL_Path + @"\XL_stat.xls", m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();
            //  ??? NO  data
            MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\XL_stat.xls");

        }
        private void write_XLQuotes()
        {
            System.IO.File.Delete(MainMDI.XL_Path + @"\XL_stat.xls");
            Object m_objOpt = System.Reflection.Missing.Value;
            Excel.Application m_objXL = new Excel.Application();
            Excel.Workbooks m_objbooks = m_objXL.Workbooks;
            Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);
            Excel.Sheets m_objSheets = m_objBook.Worksheets;
            Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

            object[] objHdrs = { "Quote Date", "Sale name", "Quote#", "Company Name", "Amount", "Currency", "Converted", "PHONE", "Address" };
            int nbCols = 9;
            Excel.Range m_objRng = m_objSheet.get_Range("A1", "I1");
            m_objRng.Value2 = objHdrs;
            Excel.Font m_objFont = m_objRng.Font;
            m_objFont.Bold = true;

            object[,] objData = new object[MainMDI.MAX_XLlines_XPRT, nbCols ];
            for (int i = 0; i < MainMDI.MAX_XLlines_XPRT; i++)
            {
                for (int j = 0; j < nbCols ; j++)
                {
                    if (i < lvQuotes.Items.Count)
                    {
                        switch (j)
                        {
                            case 7:
                            case 8:
                               objData[i, j] = "'" + lvQuotes.Items[i].SubItems[j+2].Text;
                                break;
                            case 5:
                                objData[i, j] = "'" + lvQuotes.Items[i].SubItems[6].Text;
                                break;
                            case 6:
                                objData[i, j] = (lvQuotes.Items[i].ForeColor ==Color.Red ) ? "'N" : "'Y";
                                break;
                            default:
                                objData[i, j] = "'" + lvQuotes.Items[i].SubItems[j].Text;
                                break;
                        }
                    }
                }
            }

            m_objRng = m_objSheet.get_Range("A2", m_objOpt);
            m_objRng = m_objRng.get_Resize(MainMDI.MAX_XLlines_XPRT, nbCols );
            m_objRng.Value2 = objData;

            m_objBook.SaveAs(MainMDI.XL_Path + @"\XL_stat.xls", m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();
            //  ??? NO  data
            MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\XL_stat.xls");

        }


		private void write_XLPrj()
		{

            System.IO.File.Delete(MainMDI.XL_Path + @"\XL_stat.xls");
			Object m_objOpt= System.Reflection.Missing.Value ;    
			Excel.Application  m_objXL = new Excel.Application()   ;
			Excel.Workbooks  m_objbooks = m_objXL.Workbooks ;
			Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);    
			Excel.Sheets m_objSheets = m_objBook.Worksheets ;
			Excel._Worksheet m_objSheet =(Excel._Worksheet) m_objSheets.get_Item(1);

            object[] objHdrs = { "Project Date", "Employee", "Project#", "Quote#", "Company Name", "PO #", "Amount", "Currency", "CAD AMOUNT", "Project Name", "Item Description", "Item SN", "Delivery Date (yyyy/mm/dd)" };
   			Excel.Range  m_objRng = m_objSheet.get_Range("A1","M1");
            int NBCols = 13;
			m_objRng.Value2=objHdrs ;
			Excel.Font m_objFont = m_objRng.Font ;
			m_objFont.Bold = true;

            object[,] objData = new object[MainMDI.MAX_XLlines_XPRT, NBCols];
            for (int i = 0; i < MainMDI.MAX_XLlines_XPRT; i++)
            {
                for (int j = 0; j < NBCols; j++)
                {
                    if (i < lvProj.Items.Count)
                    {
                        switch (j)
                        {
                            case 7:
                                objData[i, j] = "'" + lvProj.Items[i].SubItems[8].Text;
                                break;
                            case 8:
                                objData[i, j] = "'" + lvProj.Items[i].SubItems[9].Text;
                                break;
                            case 9:
                                objData[i, j] = "'" + lvProj.Items[i].SubItems[11].Text;
                                break;
                            case 10:
                                objData[i, j] = "'" + lvProj.Items[i].SubItems[13].Text;
                                break;
                            case 11:
                                objData[i, j] = "'" + lvProj.Items[i].SubItems[14].Text;
                                break;
                            case 12:
                                objData[i, j] = "'" + lvProj.Items[i].SubItems[15].Text;
                                break;
                            default:
                                objData[i, j] = "'" + lvProj.Items[i].SubItems[j].Text;
                                break;
                        }
                    }
                        
                    
                }
            }

			m_objRng = m_objSheet.get_Range("A2",m_objOpt);
            m_objRng = m_objRng.get_Resize(MainMDI.MAX_XLlines_XPRT, NBCols);
			m_objRng.Value2  = objData;

			m_objBook.SaveAs(MainMDI.XL_Path+ @"\XL_stat.xls",m_objOpt,m_objOpt,m_objOpt ,m_objOpt ,m_objOpt ,Excel.XlSaveAsAccessMode.xlNoChange ,m_objOpt ,m_objOpt ,m_objOpt ,m_objOpt,m_objOpt );
			m_objBook.Close (false,m_objOpt ,m_objOpt );
			m_objXL.Quit ();
            //  ??? NO  data
            MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\XL_stat.xls");
			
		}

        private void write_XLPrj_OLDOK()
        {

            System.IO.File.Delete(MainMDI.XL_Path + @"\XL_stat.xls");
            Object m_objOpt = System.Reflection.Missing.Value;
            Excel.Application m_objXL = new Excel.Application();
            Excel.Workbooks m_objbooks = m_objXL.Workbooks;
            Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);
            Excel.Sheets m_objSheets = m_objBook.Worksheets;
            Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

            object[] objHdrs = { "Project Date", "Employee", "Project#", "Quote#", "Company Name", "PO #", "Amount", "Currency" };
            Excel.Range m_objRng = m_objSheet.get_Range("A1", "H1");
            m_objRng.Value2 = objHdrs;
            Excel.Font m_objFont = m_objRng.Font;
            m_objFont.Bold = true;

            object[,] objData = new object[MainMDI.MAX_XLlines_XPRT, 8];
            for (int i = 0; i < MainMDI.MAX_XLlines_XPRT; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (i < lvProj.Items.Count) objData[i, j] = (j != 7) ? "'" + lvProj.Items[i].SubItems[j].Text : "'" + lvProj.Items[i].SubItems[8].Text;
                }
            }

            m_objRng = m_objSheet.get_Range("A2", m_objOpt);
            m_objRng = m_objRng.get_Resize(MainMDI.MAX_XLlines_XPRT, 8);
            m_objRng.Value2 = objData;

            m_objBook.SaveAs(MainMDI.XL_Path + @"\XL_stat.xls", m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();
            //  ??? NO  data
            MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\XL_stat.xls");

        }


        private void write_XLSYS()
        {
            if (dgvSYS.Rows.Count > 0)
            {
                System.IO.File.Delete(MainMDI.XL_Path + @"\XL_stat.xls");
                Object m_objOpt = System.Reflection.Missing.Value;
                Excel.Application m_objXL = new Excel.Application();
                Excel.Workbooks m_objbooks = m_objXL.Workbooks;
                Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);
                Excel.Sheets m_objSheets = m_objBook.Worksheets;
                Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

                object[] objHdrs = { "SYSTEM NAME", "    SYSTEM #     ", "Unit Price", "System Price" };
                Excel.Range m_objRng = m_objSheet.get_Range("A1", "D1");
                m_objRng.Value2 = objHdrs;
                Excel.Font m_objFont = m_objRng.Font;
                m_objFont.Bold = true;
                int NBCol = 4;
                object[,] objData = new object[MainMDI.MAX_XLlines_XPRT, NBCol];
                for (int i = 0; i < dgvSYS.Rows.Count; i++)
                {
             //       for (int j = 0; j < NBCol; j++)
             //       {
              //          objData[i, j] = dgvSYS.Rows[i].Cells[j + 1].Value.ToString();
              //          if ((MainMDI.MAX_XLlines_XPRT - 1) == i) i = MainMDI.MAX_XLlines_XPRT;
              //      }

                    objData[i, 0] = dgvSYS.Rows[i].Cells[1].Value.ToString();
                    objData[i, 1] = dgvSYS.Rows[i].Cells[2].Value.ToString();
                    objData[i, 2] = dgvSYS.Rows[i].Cells[5].Value.ToString().Replace(" ", ""); ;
                    objData[i, 3] = dgvSYS.Rows[i].Cells[6].Value.ToString().Replace(" ","");
                }

                m_objRng = m_objSheet.get_Range("A2", m_objOpt);
                m_objRng = m_objRng.get_Resize(MainMDI.MAX_XLlines_XPRT, 4);
                m_objRng.Value2 = objData;

                m_objBook.SaveAs(MainMDI.XL_Path + @"\XL_stat.xls", m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                m_objBook.Close(false, m_objOpt, m_objOpt);
                m_objXL.Quit();
                //  ??? NO  data
                MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\XL_stat.xls");
            }
        }



        private void mak_lvProj_VM()
        {
            lvProj.VirtualMode = true;
            lvProj.VirtualListSize = Lvi.Length;
        }
        private void lvProj_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            e.Item = Lvi[e.ItemIndex];
        }

        private void lcpny_DoubleClick(object sender, EventArgs e)
        {
            tSQL.Visible = !tSQL.Visible;
        }

        private void lcpny_Click(object sender, EventArgs e)
        {

        }

/*
        private static void RunDTSPackage(string packageName)
        {
            // Name of the package to run
          //  string packageName = "AzamSharpDTSTesting";
            object pVarPersistStgOfHost = null;

            DTS.PackageClass package = new DTS.PackageClass();
            package.LoadFromSQLServer( MainMDI.SQLDB, "sa", "primax", DTS.DTSSQLServerStorageFlags.DTSSQLStgFlag_UseTrustedConnection
            , null, null, null, packageName, ref pVarPersistStgOfHost);

            try
            {
                // Execute the package
                Console.WriteLine("DTS Package Executing..");
                package.Execute();
                Console.WriteLine("DTS Package Completed");

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            finally
            {
                package.UnInitialize();
                package = null;
            }

        }
 * 
 * */

        private void lvProj_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvProj_DoubleClick(object sender, EventArgs e)
        {
            if (lvProj.SelectedItems.Count ==1)
            {
               string lird="",rvname="";
               MainMDI.Find_2_Field("SELECT IRRevID, RRev_Name FROM PSM_R_Rev WHERE RID =" + lvProj.SelectedItems[0].SubItems[2].Text, ref lird, ref rvname);
           
                if (lird != MainMDI.VIDE )
                {
                      lird = lvProj.SelectedItems[0].SubItems[2].Text;
                   // lird = lvProj.SelectedItems[0].SubItems[12].Text;
                    MainMDI.Use_QRID(1, 'R', lird);
                    Order child_Ord = new Order(lird , rvname);
                    this.Hide();
                    child_Ord.ShowDialog();

                    this.Visible = true;
                 //   ref_ORDERlist(lvQuotes.SelectedItems[0].SubItems[5].Text, lvQuotes.SelectedItems[0].Index);
                //    lvQuotes.SelectedItems[0].SubItems[10].Text = Test_Stat(lvQuotes.SelectedItems[0].SubItems[5].Text);

                    MainMDI.Use_QRID(0, 'R', lird);
                    child_Ord.Close();
                    child_Ord.Dispose();

                }

            }
        }

        private void tSQL_TextChanged(object sender, EventArgs e)
        {

        }

        private void exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void opSHP_TSTnc_CheckedChanged(object sender, EventArgs e)
        {
            lOp.Text = "T";
        }

        private void grpfind_Enter(object sender, EventArgs e)
        {

        }

        private void optrdrDate_CheckedChanged(object sender, EventArgs e)
        {
           // lbldates.Text = optrdrDate.Text;
        }

        private void optInvdate_CheckedChanged(object sender, EventArgs e)
        {
           // lbldates.Text = optInvdate.Text;
        }

        private void optshpDate_CheckedChanged(object sender, EventArgs e)
        {
           // lbldates.Text = optshpDate.Text;
        }

        private void chkEX_CheckedChanged(object sender, EventArgs e)
        {
            //picEX.Visible = chkEX.Checked;
           // lv_Ex.Visible = chkEX.Checked;  
        }




        private void picEX_Click(object sender, EventArgs e)
        {
            if ( lv_Ex.FindStringExact (cbCompany.Text,-1) == -1) lv_Ex.Items.Add(cbCompany.Text);
        }

        private void picEx2_Click(object sender, EventArgs e)
        {
           // for (int i = lv_Ex.SelectedItems.Count - 1; i > 0; i--)
            if (lv_Ex.SelectedItems.Count > 0) lv_Ex.Items.Remove(lv_Ex.Items[lv_Ex.SelectedIndex]);    
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void optInv_CheckedChanged(object sender, EventArgs e)
        {
            lOp.Text = "I";
        }

        private void txCMP_TextChanged(object sender, EventArgs e)
        {

        }

        private void chSN_CheckedChanged(object sender, EventArgs e)
        {
            itmSN.Width = (chSN.Checked) ? 140 : 0;  
        }



        private void build_ref_Chrg()
        {
            string Pxx = (cbPxx.Text == "ALL") ? "P4*" : cbPxx.Text;
            string Phs = (cbPhs.Text == "ALL") ? "*" : cbPhs.Text;
            string Vdc = (cbVdc.Text == "ALL") ? "*" : cbVdc.Text;
            string Idc = (cbIdc.Text == "ALL") ? "" : cbIdc.Text;


            tkey_CHREC.Text = Pxx + "-" + Phs + "-" + Vdc + "-" + Idc;
          //  tkeyHidn.Text = "%" + tkey_CHREC.Text.Replace("*", "%") + "%"; 
        }
        private void cbPxx_SelectedIndexChanged(object sender, EventArgs e)
        {
            build_ref_Chrg();
        }

        private void cbPhs_SelectedIndexChanged(object sender, EventArgs e)
        {
            build_ref_Chrg();
        }

        private void cbVdc_SelectedIndexChanged(object sender, EventArgs e)
        {
            build_ref_Chrg();
        }

        private void cbIdc_SelectedIndexChanged(object sender, EventArgs e)
        {
            build_ref_Chrg();
        }

        private void chkModel_CheckedChanged(object sender, EventArgs e)
        {
            if (chkModel.Checked)
            {
                chkcat.Checked = false;
                grpCharg.Visible = true;
                grpAdv.Visible = chkcat.Checked;
            }
            else chkcat.Checked = true;
        }

        private void tlsbtn_Cust_Click(object sender, EventArgs e)
        {
            findQT.Visible = true;
            if (grpAdv.Visible)
            {
                grpAdv.Visible = false;
                grpfind.Height = 220;// 166;
            }
            else
            {
                grpfind.Height = 220;// 242;//308;
                grpCharg.Visible = false;
                grpAdv.Visible = true;
            }
            pnl_terri.Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            tkeyHidn.Text = "";
            findQT.Visible = false;

            grpCurr.Visible = false;
            groupBox3.Visible = false;
            grpTOTsys.Visible = true;

            grpfind.Height = 220;// 242;// 249;
            grpCharg.Visible = true;
            grpAdv.Visible = false;
            grpCH.Visible = true;
            grpREC.Visible = false;
            dgvSYS.Rows.Clear();

            grpTOTqo.Visible = false;
            grpCurr.Visible = false;
            grpQvsR.Visible = false;
            grpTot.Visible = false;
            pnl_terri.Visible = false;
          
        }


        private void fill_All_cb(string s_cb)
        {
            cbPxx.Items.Clear();
            cbVdc.Items.Clear();
            cbIdc.Items.Clear();

            cbPxx.Items.Add("ALL");
            cbVdc.Items.Add("ALL");
            cbIdc.Items.Add("ALL");
            for (int i = 0; i < s_cb.Length; i++)
            {
                string stSql = "SELECT TABLES_CONTENT.VALUE1 FROM TABLES_CONTENT INNER " +
                    " JOIN TABLES_LIST ON TABLES_CONTENT.TABLE_ID = TABLES_LIST.TABLE_ID " +
                    " WHERE (((TABLES_LIST.TABLE_NAME)='";

                switch (s_cb[i])
                {
                    case 'c':
                        //    stSql = stSql + "CHARGERS') AND (TABLES_CONTENT.VALUE1 LIKE N'%p4500%') ) ORDER BY TABLES_CONTENT.TABLE_Line_id";
                        stSql = stSql + "CHARGERS') AND (TABLES_CONTENT.VALUE1 LIKE N'%p4%') ) ORDER BY TABLES_CONTENT.TABLE_Line_id";
                        break;
                    case 'v':
                        stSql = stSql + "VDCnominal')) ORDER BY cast(TABLES_CONTENT.VALUE1 AS float) ";

                        break;
                    case 'i':
                        stSql = stSql + "IDC')) ORDER BY TABLES_CONTENT.TABLE_Line_id";

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
                            // if (Oreadr["VALUE1"].ToString().Substring(0, 5) != "P4000") 
                            cbPxx.Items.Add(Oreadr["VALUE1"].ToString());
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

        private void tlsbtnRectif_Click(object sender, EventArgs e)
        {

            tkeyHidn.Text = "";
            
            findQT.Visible = false;
            grpCurr.Visible = false;
            groupBox3.Visible = false;
            grpTOTsys.Visible = true;

            grpfind.Height = 220;// 242;// 249;
            grpCharg.Visible = true;
            grpAdv.Visible = false;
            grpCH.Visible = false;
            grpREC.Visible = true;
            dgvSYS.Rows.Clear();

            grpTOTqo.Visible =false;
            grpCurr.Visible = false;
            grpQvsR.Visible = false;
            grpTot.Visible = false;
            pnl_terri.Visible = false;
           
        }

        private void cbRectifiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            tkey_CHREC.Text = (cbRectifiers.Text == "ALL") ? "P5500*-*" : cbRectifiers.Text;
        }

        private void tkey_CHREC_TextChanged(object sender, EventArgs e)
        {
            tkeyHidn.Text = "%" + tkey_CHREC.Text.Replace("*", "%") + "%"; 
        }

        private void picFind_Click(object sender, EventArgs e)
        {
            dgvSYS.Rows.Clear();
            grpCurr.Visible = false;
            groupBox3.Visible = false;
            grpTOTsys.Visible = true;
            lvSorterSYS.SortColumn = -1;
            Opera = 'S';
            if (tkeyHidn.Text != "") aff_statistics();
 
        }

 
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            tkeyHidn.Text = "";
            findQT.Visible = false;
            grpCurr.Visible = false;
            groupBox3.Visible = false;
            grpTOTsys.Visible = true;
            grpfind.Height = 220;// 166;


            grpCharg.Visible = false;
            grpAdv.Visible = false;
            grpCH.Visible = false;
            grpREC.Visible = false;
            Opera = 'A';
            aff_statistics();
            pnl_terri.Visible = false;
        }

        private void lvSYS_ColumnClick(object sender, ColumnClickEventArgs e)
        {
         //   lvSorterSYS.SortColumn = -1;
            lvSorterSYS.SortColumn=e.Column;
            seelCol = e.Column;
            ListView myListView = (ListView)sender;
            if (e.Column == lvSorterSYS.SortColumn)
            {

                if (lvSorterSYS.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvSorterSYS.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvSorterSYS.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {

                lvSorterSYS.Order = (srtType == 'A') ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
                srtType = (srtType == 'A') ? 'D' : 'A';
                lvSorterSYS.SortColumn = e.Column ;
               
            }

            myListView.Sort();
            oldSC = lvSorterSYS.SortColumn;
        //  lvSorterSYS.SortColumn = 0;
            lvSorterSYS.SortColumn = -1;

        }

        private void tkey_CHREC_DoubleClick(object sender, EventArgs e)
        {
            tkeyHidn.Visible = !tkeyHidn.Visible;
        }

        private void btnSS_Click(object sender, EventArgs e)
        {
            lvSorterSYS.SortColumn = -1;
            Opera = 'S';
            aff_statistics();
        }

        private void btnALLS_Click(object sender, EventArgs e)
        {
            grpfind.Height = 130;
            //  grpTot.Visible = false;
            Opera = 'A';
            aff_statistics();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cbIdc.Text = "ALL";
            cbPhs.Text = "ALL";
            cbVdc.Text = "ALL";
            cbPxx.Text = "ALL";
           
        }

        private void btnDispCols_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < dgvSYS.Columns.Count;i++ ) dgvSYS.Columns[i].Visible = true;
        }

        private void txAMNT_F_TextChanged(object sender, EventArgs e)
        {
            AMNT_FM = Tools.Conv_Dbl(txAMNT_F.Text);
        }

        private void txAMNT_T_TextChanged(object sender, EventArgs e)
        {
            AMNT_TO = Tools.Conv_Dbl(txAMNT_T.Text);
        }



        void Analyse_Quotes()
        {
            

            double dd=Math.Round(UST * Tools.Conv_Dbl(txRusd.Text), 2);             
            double TOTOdd=dd;
            lcad_USD.Text = " $ " + MainMDI.Curr_FRMT(dd.ToString());

            dd= Math.Round(EurT * Tools.Conv_Dbl(txReuro.Text),2);             
            TOTOdd+=dd;
            lcad_EURO.Text = " $ " + MainMDI.Curr_FRMT(dd.ToString()); ;

            dd= Math.Round(CADT * Tools.Conv_Dbl(txRcad.Text),2);             
            TOTOdd+=dd;
            lcad_CAD.Text = " $ " + MainMDI.Curr_FRMT(dd.ToString());

            tBigTot.Text = " $ " + MainMDI.Curr_FRMT(TOTOdd.ToString());

            if (edlv_QtOr.Items.Count > 0)
            {
                //-------------------------- SQ


                USD_SQcad = Math.Round(USD_SQ * Tools.Conv_Dbl(txRusd.Text), 2); double TOT_SQcad = USD_SQcad;
                EUR_SQcad = Math.Round(EUR_SQ * Tools.Conv_Dbl(txReuro.Text), 2); TOT_SQcad += EUR_SQcad;
                CAD_SQcad = Math.Round(CAD_SQ * Tools.Conv_Dbl(txRcad.Text), 2); TOT_SQcad += CAD_SQcad;
                double ALL_SQ = USD_SQcad + EUR_SQcad + CAD_SQcad;
                double NBQ = Tools.Conv_Dbl(edlv_QtOr.Items[0].SubItems[2].Text);
                //---------

                double avrgQ = Math.Round(TOTOdd / NBQ , 2);
                edlv_QtOr.Items[0].SubItems[3].Text = " $ " + MainMDI.Curr_FRMT(TOTOdd.ToString());
                edlv_QtOr.Items[0].SubItems[4].Text = " $ " + MainMDI.Curr_FRMT(avrgQ.ToString());

                if (Opera == 'Q')
                {
                    edlv_QtOr.Items[1].SubItems[3].Text = " $ " + MainMDI.Curr_FRMT(ALL_SQ.ToString());
                    double avrgSQ = Math.Round(ALL_SQ / (USD_SQnb + EUR_SQnb + CAD_SQnb), 2);
                    edlv_QtOr.Items[1].SubItems[4].Text = " $ " + MainMDI.Curr_FRMT(avrgSQ.ToString());

                    edlv_QtOr.Items[2].SubItems[3].Text = Math.Round(ALL_SQ / BT * 100.0, 0).ToString() + "%";
                    avrgQ = Math.Round(avrgSQ / avrgQ * 100.0, 0);
                    edlv_QtOr.Items[2].SubItems[4].Text = avrgQ.ToString() + "%";
                }

            }
            if (edlv_QvsOR.Items.Count > 0)
            {
                //-------------------------- SQ


                UST_ORcad = Math.Round(UST_OR * Tools.Conv_Dbl(txRusd.Text), 2); double TOT_ORcad = UST_ORcad;
                EurT_ORcad = Math.Round(EUR_SQ * Tools.Conv_Dbl(txReuro.Text), 2); TOT_ORcad += EurT_ORcad;
                CADT_ORcad = Math.Round(CAD_SQ * Tools.Conv_Dbl(txRcad.Text), 2); TOT_ORcad += CADT_ORcad;
                double ALL_ORcad = UST_ORcad + EurT_ORcad + CADT_ORcad;

                //Quotes
                edlv_QvsOR.Items[0].SubItems[2].Text = edlv_QtOr.Items[0].SubItems[2].Text;
                edlv_QvsOR.Items[0].SubItems[3].Text = edlv_QtOr.Items[0].SubItems[3].Text;
                edlv_QvsOR.Items[0].SubItems[4].Text = edlv_QtOr.Items[0].SubItems[4].Text;


                //orders
                double NBOR = Tools.Conv_Dbl(edlv_QvsOR.Items[1].SubItems[2].Text);
                double NBQ = Tools.Conv_Dbl(edlv_QvsOR.Items[0].SubItems[2].Text);
          
                edlv_QvsOR.Items[1].SubItems[3].Text = " $ " + MainMDI.Curr_FRMT(ALL_ORcad.ToString());
                double avrgOR = Math.Round(ALL_ORcad / NBOR, 2);
                edlv_QvsOR.Items[1].SubItems[4].Text = " $ " + MainMDI.Curr_FRMT(avrgOR.ToString());

                //ratios
                double avrgNB = Math.Round(NBOR / NBQ * 100.0, 0);
                edlv_QvsOR.Items[2].SubItems[2].Text = avrgNB + "%";
                edlv_QvsOR.Items[2].SubItems[3].Text = Math.Round(ALL_ORcad / TOTOdd * 100.0, 0).ToString() + "%";
                double avrgQ = Tools.Conv_Dbl(edlv_QvsOR.Items[0].SubItems[4].Text.Replace ("$","").Replace (" ",""));
                double avrgALL = Math.Round(avrgOR / avrgQ * 100.0, 0);
                edlv_QvsOR.Items[2].SubItems[4].Text = avrgALL.ToString() + "%";


            }

            

        }

        private void txRusd_TextChanged(object sender, EventArgs e)
        {
            Analyse_Quotes();
        }

        private void tUSDTot_TextChanged(object sender, EventArgs e)
        {
            Analyse_Quotes();
        }

        private void lEROTot_TextChanged(object sender, EventArgs e)
        {
            Analyse_Quotes();
        }

        private void tCADTot_TextChanged(object sender, EventArgs e)
        {
            Analyse_Quotes();
        }

        private void txReuro_TextChanged(object sender, EventArgs e)
        {
            Analyse_Quotes();
        }

        private void tUSDTot_Click(object sender, EventArgs e)
        {

        }

        private void picQvsP_Click(object sender, EventArgs e)
        {
            if (GoodAMNTFT())
            {
                grpTOTqo.Visible = false;
                init_TOTs();
                groupBox3.Visible = true;
                grpTOTsys.Visible = false;
                lvSorter.SortColumn = -1;
                Opera = 'V';
                aff_statistics();
            //    lbldates.Text = "Quote Date";
                grpcat.Enabled = false;
                grpDates.Enabled = false;
             }
            else MessageBox.Show("Invalid Amounts !!!!!");
        }

        private void opQuote_CheckedChanged(object sender, EventArgs e)
        {
            //lvQuotes.Visible =true;
            //lvProj.Visible = false;
        }

        private void opOrders_CheckedChanged(object sender, EventArgs e)
        {
            //lvQuotes.Visible = false;
            //lvProj.Visible = true;
        }

        private void dpFrom_ValueChanged(object sender, EventArgs e)
        {

        }

        private void findQT_Click(object sender, EventArgs e)
        {
            if (findQT.BackColor == Color.Moccasin) seekQuote();
            else seekOrders();
        }



        void fill_Sales(string brnch)
        {
            string stSql = " SELECT distinct [Name] AS NM,[Salesperson]   FROM SalSalesperson WHERE SalSalesperson.Branch='" + brnch + "' And (SUBSTRING([Salesperson],1,1)='S' OR SUBSTRING([Salesperson],1,1)='H') and not (Salesperson in ('S01','S02','S07')) order by Salesperson Desc, NM";
            MainMDI.fill_Any_CB(cbSales, stSql, false, "");

        }

        void fill_CBsales_SYSPRO(string brnch)
        {

            SqlConnection OConn = null;
            SqlCommand Ocmd = null;
            SqlDataReader Oreadr = null;

            string stSql = " SELECT [Salesperson] + ' - ' + [Name] AS Expr1 FROM SalSalesperson WHERE SalSalesperson.Branch='"+brnch+"' And SUBSTRING([Salesperson],1,1)='S' order by Expr1";

                //: " SELECT DISTINCT SalSalesperson.Name, SalSalesperson.Salesperson  FROM u_SalCommissionsPrimax INNER JOIN SalSalesperson ON (u_SalCommissionsPrimax.Salesperson = SalSalesperson.Salesperson) " +
                //  " AND (u_SalCommissionsPrimax.Branch = SalSalesperson.Branch)  " +
                //  " WHERE SUBSTRING(SalSalesperson.Salesperson,1,1)='S'   ORDER BY SalSalesperson.Name ";


            cbSales.Items.Clear();
            try
            {
                //OConn = new OleDbConnection(MainMDI.M_stCon_CMS_ACCS_ACE);
                OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
                OConn.Open();
                Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    cbSales.Items.Add(Oreadr[0].ToString());
                }
                //    cbSales.Text = cbSales.Items[0].ToString();
                //  cbSales.Text = PGCUsr_SalesName(MainMDI.User.ToLower ());
            }


            catch (Exception ex)
            {
                MessageBox.Show("fill_cbSales_CMS_ERROR= " + ex.Message + "   er#= " + ex.Source + "\n stsql=" + stSql);
            }


            finally
            {
                OConn.Close();
                if (Oreadr != null) Oreadr.Close();
            }
          

        }

        private void cbSales_SelectedIndexChanged(object sender, EventArgs e)
        {
            lSnn.Text = MainMDI.get_CBX_value(cbSales, cbSales.SelectedIndex);
        }

        private void tls_terri_Click(object sender, EventArgs e)
        {
            if ( !grpAdv.Visible && !grpCH.Visible && !grpCharg.Visible   )     pnl_terri.Visible = !pnl_terri.Visible;
           
        }










    }
}
