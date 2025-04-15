using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using EAHLibs;
using System.Collections.Generic;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for NL_Item_Option.
	/// </summary>
	public class NL_Item_Option_NEW_2 : System.Windows.Forms.Form
	{
        string H1_val = "0", H2_val = "0", H3_val = "0", H4_val = "0", H5_val = "0", H6_val = "0";
        string H1_lim = "0", H2_lim = "0", H3_lim = "0", H4_lim = "0", H5_lim = "0", H6_lim = "0";
        string H1_amt = "0", H2_amt = "0", H3_amt = "0", H4_amt = "0", H5_amt = "0", H6_amt = "0";

        bool AutoCal = true;

        bool dblclik = false;
		private Lib1 Tools = new Lib1();
		private ListViewColumnSorter lvSorter = null;
		private string In_QID;
		public bool SaveOK = false;
		private int LVNdx = -1;
        string in_keyinfo = "";
		private System.Windows.Forms.GroupBox grpItem;
		public System.Windows.Forms.TextBox lIotherF;
		public System.Windows.Forms.TextBox tIotherF;
		private System.Windows.Forms.Label not;
		private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox tIf1;
		public System.Windows.Forms.TextBox lif2;
		public System.Windows.Forms.TextBox tIf2;
		public System.Windows.Forms.TextBox lif1;
		private System.Windows.Forms.Label ll;
		public System.Windows.Forms.TextBox tIName;
        private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox tIdim;
		private System.Windows.Forms.Label label48;
		public System.Windows.Forms.TextBox tIModel;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDel;
		public System.Windows.Forms.CheckBox chk1;
		public System.Windows.Forms.CheckBox chk2;
		public System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox tIExt;
		private System.Windows.Forms.Label label34;
		public System.Windows.Forms.TextBox tILT;
		private System.Windows.Forms.Label label36;
		public System.Windows.Forms.TextBox tSMRK;
		private System.Windows.Forms.Label label38;
		public System.Windows.Forms.TextBox tIQty;
		private System.Windows.Forms.Label label42;
		public System.Windows.Forms.TextBox tIPU;
		public System.Windows.Forms.CheckBox chkD;
		public System.Windows.Forms.CheckBox chkM;
		private System.Windows.Forms.Button btnClear;
		public System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.Label label57;
		private System.Windows.Forms.RadioButton opEuro;
		private System.Windows.Forms.RadioButton opUS;
		private System.Windows.Forms.RadioButton opCan;
		private System.Windows.Forms.Label lcurDol;
		private System.Windows.Forms.PictureBox pictureBox3;
        private Label label6;
        private Label label5;
        private Label label2;
        private Panel panel2;
        private Panel panel1;
        private Label label7;
        private Panel pnlStrat;
        public TextBox up6;
        public TextBox textBox18;
        public TextBox Amnt6;
        public TextBox hh6;
        public TextBox up5;
        public TextBox textBox14;
        public TextBox Amnt5;
        public TextBox hh5;
        public TextBox up4;
        public TextBox textBox10;
        public TextBox Amnt4;
        public TextBox hh4;
        public TextBox up2;
        public TextBox textBox6;
        public TextBox Amnt2;
        public TextBox hh2;
        public TextBox up1;
        public TextBox textBox2;
        private Label label12;
        private Label label14;
        public TextBox Amnt1;
        public TextBox hh1;
        private Label label16;
        public TextBox txD42;
        private Panel panel4;
        private RadioButton optNo;
        private RadioButton optYes;
        public TextBox textBox21;
        private Button btnbrowse;
        public TextBox valFrais;
        private RadioButton optALL;
        private RadioButton optQNB;
        private Panel panel3;
        private RadioButton optuser;
        private ToolStrip toolStrip1;
        private ToolStripButton NewST;
        private ToolStripButton delitm;
        private ToolStripButton newitm;
        private ToolStripButton _exit;
        private Label label10;
        private Label label9;
        private Label lsave;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox picSeek;
        private Label tINotes;
        private Label lQTy;
        private Label lOpt;
        private Label tINotes_OLD;
        private ToolStripButton tlsOFF;
        private ToolStripButton tlsON;
        private PictureBox picOFF;
        private PictureBox picON;
        public TextBox textBox23;
        public TextBox textBox24;
        public TextBox txD34;
        public TextBox textBox26;
        public TextBox textBox17;
        public TextBox textBox19;
        public TextBox txD33;
        public TextBox textBox22;
        public TextBox textBox12;
        public TextBox textBox13;
        public TextBox txD32;
        public TextBox textBox16;
        public TextBox textBox7;
        public TextBox textBox8;
        public TextBox txD31;
        public TextBox textBox11;
        public TextBox textBox1;
        public TextBox textBox3;
        public TextBox txD30;
        public TextBox textBox5;
        public TextBox textBox28;
        public TextBox txD44;
        public TextBox textBox29;
        public TextBox txD46;
        public TextBox up3;
        public TextBox textBox9;
        public TextBox Amnt3;
        public TextBox hh3;
        private RadioButton optCAD;
        private RadioButton optUS;
        private PictureBox picMoveUP;
        private PictureBox pictureBox4;
        private Panel panel5;
        public TextBox cal_multipl;
        private Label label17;
        private Label label1;
        public TextBox cal_ext;
        private Label label8;
        public TextBox cal_qty;
        private Label label11;
        public TextBox cal_pu;
        private Label label13;
        private Label label15;
        public TextBox textBox25;
        public RadioButton opt_withmult;
        public RadioButton opt_NOmult;
        public TextBox textBox20;
        public TextBox txSTAX;
        public TextBox textBox4;
        public TextBox txCstms;
        private Panel panel6;
        private Label label18;
        private Label label19;
        private Label label20;
        public TextBox txD31_UCst;
        public TextBox txD30_UCst;
        public TextBox txD31_Qty;
        public TextBox txD30_Qty;
        private Label label21;
        private PictureBox pictureBox5;
        private ToolStripButton toolStripButton1;
        public Label lsavALLinfo;
        private Label lvalfrais;
        private Label lSTAX;
        private Label lCstms;
        private Label label23;
        private Label label22;
        private ListView lvNLIO;
        private ColumnHeader IOName;
        private ColumnHeader Model;
        private ColumnHeader Dim;
        private ColumnHeader F1;
        private ColumnHeader F2;
        private ColumnHeader OFt;
        private ColumnHeader qTTY;
        private ColumnHeader UP;
        private ColumnHeader Mult;
        private ColumnHeader Sprice;
        private ColumnHeader LT;
        private ColumnHeader note;
        private ColumnHeader usr;
        private ColumnHeader QID;
        private ColumnHeader LID;
        private GroupBox groupBox2;
        private Panel panel8;
        private ToolStripButton addBatt;
        private GroupBox groupBox3;
        private GroupBox groupBox4;
        private Label label_seismicYes;
        private Label label_seismicNo;
        private GroupBox groupBox5;
        private GroupBox groupBox6;
        private Label label_batteryWeight;
        private Label label_batteryWidth;
        private Label label_batteryLength;
        private Label label_batteryHeight;
        private Label label_batteryCapacity;
        private Label label_batteryAlloy;
        private Label label_batteryManufacturer;
        private Label label_batteryType;
        private Label label_batteryModel;
        private Label label_batteryPrice;
        private Label label_batteryLife;
        private Label label_batteryRack;
        private Label label_rackType;
        private Label label_rackHeight;
        private Label label_rackLength;
        private Label label_rackWidth;
        private TextBox textBox_rackWidth;
        private TextBox textBox_rackLength;
        private TextBox textBox_rackHeight;
        private Label label_rackDimensionsMeters;
        private Label label_rackDimensionsInches;
        private RadioButton radioButton_seismicYes;
        private RadioButton radioButton_seismicNo;
        private RadioButton radioButton_rackDimensionsMeters;
        private RadioButton radioButton_rackDimensionsInches;
        private Label label_rackPrice;
        private TextBox textBox_rackPrice;
        private Label label_rackPriceUS;
        private Label label_rackPriceCA;
        private RadioButton radioButton_rackPriceUS;
        private RadioButton radioButton_rackPriceCA;
        private Label label_date;
        private TextBox textBox_date;
        private ToolStripButton cancel;
        private Button button_Ajouter;
        private Button button_Sauvegarder;
        private Label label_batteryDimensionsInches;
        private Label label_batteryDimensionsMeters;
        private RadioButton radioButton_batteryDimensionsMeters;
        private RadioButton radioButton_batteryDimensionsInches;
        private Label label_batteryPriceUS;
        private Label label_batteryPriceCA;
        private RadioButton radioButton_batteryPriceUS;
        private RadioButton radioButton_batteryPriceCA;
        private GroupBox groupBox7;
        private ListView listView_Battery;
        private ColumnHeader batteryModel;
        private ColumnHeader batteryManufacturer;
        private ColumnHeader batteryType;
        private ColumnHeader batteryAlloy;
        private ColumnHeader batteryCapacity;
        private ColumnHeader batteryDimensions;
        private ColumnHeader batteryLife;
        private ColumnHeader batteryPrice;
        private ColumnHeader batterySeismic;
        private ColumnHeader rack;
        private ColumnHeader rackType;
        private ColumnHeader rackDimensions;
        private ColumnHeader rackPrice;
        private ColumnHeader date;
        private TextBox textBox_batteryWeight;
        private TextBox textBox_batteryHeight;
        private TextBox textBox_batteryLength;
        private TextBox textBox_batteryWidth;
        private TextBox textBox_batteryPrice;
        private TextBox textBox_batteryManufacturer;
        private TextBox textBox_batteryType;
        private TextBox textBox_batteryModel;
        private TextBox textBox_batteryAlloy;
        private TextBox textBox_batteryCapacity;
        private TextBox textBox_batteryLife;
        private TextBox textBox_rackType;
        private TextBox textBox_batteryRack;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public NL_Item_Option_NEW_2(string x_QID, string x_keyInfo)
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();
			In_QID = x_QID;
            in_keyinfo = x_keyInfo;
			lvSorter = new ListViewColumnSorter();
			this.lvNLIO.ListViewItemSorter = lvSorter;
			lvNLIO.Sorting = System.Windows.Forms.SortOrder.Ascending;
			lvNLIO.AutoArrange = true;
			
            tINotes.Text = x_keyInfo;
            optQNB.Text += " " + In_QID;
            optuser.Text += MainMDI.User;
            lOpt.Text = "Q";
            fill_lvNLIO();
            fill_cbBox_supplier();
            fill_cbBox_supportType();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NL_Item_Option_NEW_2));
            this.grpItem = new System.Windows.Forms.GroupBox();
            this.panel8 = new System.Windows.Forms.Panel();
            this.listView_Battery = new System.Windows.Forms.ListView();
            this.batteryModel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.batteryManufacturer = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.batteryType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.batteryAlloy = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.batteryCapacity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.batteryDimensions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.batteryLife = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.batteryPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.batterySeismic = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rack = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rackType = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rackDimensions = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rackPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.textBox_batteryWeight = new System.Windows.Forms.TextBox();
            this.textBox_batteryHeight = new System.Windows.Forms.TextBox();
            this.textBox_batteryLength = new System.Windows.Forms.TextBox();
            this.textBox_batteryWidth = new System.Windows.Forms.TextBox();
            this.label_batteryDimensionsMeters = new System.Windows.Forms.Label();
            this.label_batteryDimensionsInches = new System.Windows.Forms.Label();
            this.radioButton_batteryDimensionsInches = new System.Windows.Forms.RadioButton();
            this.radioButton_batteryDimensionsMeters = new System.Windows.Forms.RadioButton();
            this.label_batteryHeight = new System.Windows.Forms.Label();
            this.label_batteryLength = new System.Windows.Forms.Label();
            this.label_batteryWidth = new System.Windows.Forms.Label();
            this.label_batteryWeight = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox_rackType = new System.Windows.Forms.TextBox();
            this.textBox_batteryRack = new System.Windows.Forms.TextBox();
            this.button_Ajouter = new System.Windows.Forms.Button();
            this.button_Sauvegarder = new System.Windows.Forms.Button();
            this.textBox_date = new System.Windows.Forms.TextBox();
            this.label_date = new System.Windows.Forms.Label();
            this.label_batteryRack = new System.Windows.Forms.Label();
            this.radioButton_rackPriceUS = new System.Windows.Forms.RadioButton();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.radioButton_rackDimensionsMeters = new System.Windows.Forms.RadioButton();
            this.radioButton_rackDimensionsInches = new System.Windows.Forms.RadioButton();
            this.label_rackDimensionsMeters = new System.Windows.Forms.Label();
            this.label_rackDimensionsInches = new System.Windows.Forms.Label();
            this.textBox_rackWidth = new System.Windows.Forms.TextBox();
            this.textBox_rackLength = new System.Windows.Forms.TextBox();
            this.textBox_rackHeight = new System.Windows.Forms.TextBox();
            this.label_rackHeight = new System.Windows.Forms.Label();
            this.label_rackLength = new System.Windows.Forms.Label();
            this.label_rackWidth = new System.Windows.Forms.Label();
            this.radioButton_rackPriceCA = new System.Windows.Forms.RadioButton();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.radioButton_seismicYes = new System.Windows.Forms.RadioButton();
            this.radioButton_seismicNo = new System.Windows.Forms.RadioButton();
            this.label_seismicYes = new System.Windows.Forms.Label();
            this.label_seismicNo = new System.Windows.Forms.Label();
            this.label_rackPriceUS = new System.Windows.Forms.Label();
            this.label_rackType = new System.Windows.Forms.Label();
            this.label_rackPriceCA = new System.Windows.Forms.Label();
            this.textBox_rackPrice = new System.Windows.Forms.TextBox();
            this.label_rackPrice = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textBox_batteryPrice = new System.Windows.Forms.TextBox();
            this.textBox_batteryManufacturer = new System.Windows.Forms.TextBox();
            this.textBox_batteryType = new System.Windows.Forms.TextBox();
            this.textBox_batteryModel = new System.Windows.Forms.TextBox();
            this.textBox_batteryAlloy = new System.Windows.Forms.TextBox();
            this.textBox_batteryCapacity = new System.Windows.Forms.TextBox();
            this.textBox_batteryLife = new System.Windows.Forms.TextBox();
            this.radioButton_batteryPriceCA = new System.Windows.Forms.RadioButton();
            this.radioButton_batteryPriceUS = new System.Windows.Forms.RadioButton();
            this.label_batteryPriceUS = new System.Windows.Forms.Label();
            this.label_batteryPriceCA = new System.Windows.Forms.Label();
            this.label_batteryPrice = new System.Windows.Forms.Label();
            this.label_batteryLife = new System.Windows.Forms.Label();
            this.label_batteryCapacity = new System.Windows.Forms.Label();
            this.label_batteryAlloy = new System.Windows.Forms.Label();
            this.label_batteryManufacturer = new System.Windows.Forms.Label();
            this.label_batteryType = new System.Windows.Forms.Label();
            this.label_batteryModel = new System.Windows.Forms.Label();
            this.pnlStrat = new System.Windows.Forms.Panel();
            this.lSTAX = new System.Windows.Forms.Label();
            this.lCstms = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.lvalfrais = new System.Windows.Forms.Label();
            this.lsavALLinfo = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.valFrais = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.txD31_UCst = new System.Windows.Forms.TextBox();
            this.txD30_UCst = new System.Windows.Forms.TextBox();
            this.txD31_Qty = new System.Windows.Forms.TextBox();
            this.txD30_Qty = new System.Windows.Forms.TextBox();
            this.textBox20 = new System.Windows.Forms.TextBox();
            this.txSTAX = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.txCstms = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.optCAD = new System.Windows.Forms.RadioButton();
            this.optUS = new System.Windows.Forms.RadioButton();
            this.picMoveUP = new System.Windows.Forms.PictureBox();
            this.up3 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.Amnt3 = new System.Windows.Forms.TextBox();
            this.hh3 = new System.Windows.Forms.TextBox();
            this.txD44 = new System.Windows.Forms.TextBox();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.txD46 = new System.Windows.Forms.TextBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.textBox24 = new System.Windows.Forms.TextBox();
            this.txD34 = new System.Windows.Forms.TextBox();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.txD33 = new System.Windows.Forms.TextBox();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox12 = new System.Windows.Forms.TextBox();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.txD32 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.txD31 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txD30 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.txD42 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.optNo = new System.Windows.Forms.RadioButton();
            this.optYes = new System.Windows.Forms.RadioButton();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.up6 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.Amnt6 = new System.Windows.Forms.TextBox();
            this.hh6 = new System.Windows.Forms.TextBox();
            this.up5 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.Amnt5 = new System.Windows.Forms.TextBox();
            this.hh5 = new System.Windows.Forms.TextBox();
            this.up4 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.Amnt4 = new System.Windows.Forms.TextBox();
            this.hh4 = new System.Windows.Forms.TextBox();
            this.up2 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.Amnt2 = new System.Windows.Forms.TextBox();
            this.hh2 = new System.Windows.Forms.TextBox();
            this.up1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.Amnt1 = new System.Windows.Forms.TextBox();
            this.hh1 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.tIName = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.cal_multipl = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cal_ext = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cal_qty = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.cal_pu = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.textBox25 = new System.Windows.Forms.TextBox();
            this.opt_withmult = new System.Windows.Forms.RadioButton();
            this.tIModel = new System.Windows.Forms.TextBox();
            this.opt_NOmult = new System.Windows.Forms.RadioButton();
            this.label48 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ll = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.tIf2 = new System.Windows.Forms.TextBox();
            this.tIf1 = new System.Windows.Forms.TextBox();
            this.lOpt = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lcurDol = new System.Windows.Forms.Label();
            this.tIExt = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tIQty = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.tIPU = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.label38 = new System.Windows.Forms.Label();
            this.tILT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tIdim = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.picON = new System.Windows.Forms.PictureBox();
            this.tINotes_OLD = new System.Windows.Forms.Label();
            this.lQTy = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.newitm = new System.Windows.Forms.ToolStripButton();
            this.addBatt = new System.Windows.Forms.ToolStripButton();
            this.cancel = new System.Windows.Forms.ToolStripButton();
            this.NewST = new System.Windows.Forms.ToolStripButton();
            this.delitm = new System.Windows.Forms.ToolStripButton();
            this.tlsOFF = new System.Windows.Forms.ToolStripButton();
            this.tlsON = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this._exit = new System.Windows.Forms.ToolStripButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.optuser = new System.Windows.Forms.RadioButton();
            this.optALL = new System.Windows.Forms.RadioButton();
            this.optQNB = new System.Windows.Forms.RadioButton();
            this.btnbrowse = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.opEuro = new System.Windows.Forms.RadioButton();
            this.opUS = new System.Windows.Forms.RadioButton();
            this.opCan = new System.Windows.Forms.RadioButton();
            this.label57 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.lIotherF = new System.Windows.Forms.TextBox();
            this.tIotherF = new System.Windows.Forms.TextBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lsave = new System.Windows.Forms.Label();
            this.chkM = new System.Windows.Forms.CheckBox();
            this.chkD = new System.Windows.Forms.CheckBox();
            this.tSMRK = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.lif2 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.not = new System.Windows.Forms.Label();
            this.picSeek = new System.Windows.Forms.PictureBox();
            this.lif1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnEdit = new System.Windows.Forms.Button();
            this.tINotes = new System.Windows.Forms.Label();
            this.picOFF = new System.Windows.Forms.PictureBox();
            this.lvNLIO = new System.Windows.Forms.ListView();
            this.IOName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dim = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.F1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.F2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OFt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qTTY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sprice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.note = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.grpItem.SuspendLayout();
            this.panel8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.pnlStrat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoveUP)).BeginInit();
            this.panel4.SuspendLayout();
            this.panel6.SuspendLayout();
            this.panel5.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picON)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOFF)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpItem
            // 
            this.grpItem.BackColor = System.Drawing.SystemColors.Control;
            this.grpItem.Controls.Add(this.panel8);
            this.grpItem.Controls.Add(this.pnlStrat);
            this.grpItem.Controls.Add(this.panel6);
            this.grpItem.Controls.Add(this.picON);
            this.grpItem.Controls.Add(this.tINotes_OLD);
            this.grpItem.Controls.Add(this.lQTy);
            this.grpItem.Controls.Add(this.toolStrip1);
            this.grpItem.Controls.Add(this.panel3);
            this.grpItem.Controls.Add(this.btnbrowse);
            this.grpItem.Controls.Add(this.label7);
            this.grpItem.Controls.Add(this.panel2);
            this.grpItem.Controls.Add(this.label57);
            this.grpItem.Controls.Add(this.groupBox1);
            this.grpItem.Controls.Add(this.btnEdit);
            this.grpItem.Controls.Add(this.tINotes);
            this.grpItem.Controls.Add(this.picOFF);
            this.grpItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpItem.Location = new System.Drawing.Point(0, 0);
            this.grpItem.Name = "grpItem";
            this.grpItem.Size = new System.Drawing.Size(1612, 734);
            this.grpItem.TabIndex = 125;
            this.grpItem.TabStop = false;
            this.grpItem.Enter += new System.EventHandler(this.grpItem_Enter_1);
            // 
            // panel8
            // 
            this.panel8.Controls.Add(this.listView_Battery);
            this.panel8.Controls.Add(this.groupBox7);
            this.panel8.Controls.Add(this.groupBox4);
            this.panel8.Controls.Add(this.groupBox3);
            this.panel8.Location = new System.Drawing.Point(2160, 923);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1927, 652);
            this.panel8.TabIndex = 374;
            this.panel8.Visible = false;
            // 
            // listView_Battery
            // 
            this.listView_Battery.BackColor = System.Drawing.Color.WhiteSmoke;
            this.listView_Battery.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.batteryModel,
            this.batteryManufacturer,
            this.batteryType,
            this.batteryAlloy,
            this.batteryCapacity,
            this.batteryDimensions,
            this.batteryLife,
            this.batteryPrice,
            this.batterySeismic,
            this.rack,
            this.rackType,
            this.rackDimensions,
            this.rackPrice,
            this.date});
            this.listView_Battery.ForeColor = System.Drawing.Color.Blue;
            this.listView_Battery.FullRowSelect = true;
            this.listView_Battery.GridLines = true;
            this.listView_Battery.HideSelection = false;
            this.listView_Battery.Location = new System.Drawing.Point(356, 157);
            this.listView_Battery.Name = "listView_Battery";
            this.listView_Battery.Size = new System.Drawing.Size(1566, 493);
            this.listView_Battery.TabIndex = 127;
            this.listView_Battery.UseCompatibleStateImageBehavior = false;
            this.listView_Battery.View = System.Windows.Forms.View.Details;
            // 
            // batteryModel
            // 
            this.batteryModel.Text = "Model";
            // 
            // batteryManufacturer
            // 
            this.batteryManufacturer.Text = "Manufacturer";
            // 
            // batteryType
            // 
            this.batteryType.Text = "Type";
            // 
            // batteryAlloy
            // 
            this.batteryAlloy.Text = "Alloy";
            // 
            // batteryCapacity
            // 
            this.batteryCapacity.Text = "Capacity";
            // 
            // batteryDimensions
            // 
            this.batteryDimensions.Text = "Dimensions";
            // 
            // batteryLife
            // 
            this.batteryLife.Text = "Life";
            // 
            // batteryPrice
            // 
            this.batteryPrice.Text = "Price";
            // 
            // batterySeismic
            // 
            this.batterySeismic.Text = "Seismic";
            // 
            // rack
            // 
            this.rack.Text = "Rack";
            // 
            // rackType
            // 
            this.rackType.Text = "Rack Type";
            // 
            // rackDimensions
            // 
            this.rackDimensions.Text = "Rack Dimensions";
            // 
            // rackPrice
            // 
            this.rackPrice.Text = "Rack Price";
            // 
            // date
            // 
            this.date.Text = "Date";
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.textBox_batteryWeight);
            this.groupBox7.Controls.Add(this.textBox_batteryHeight);
            this.groupBox7.Controls.Add(this.textBox_batteryLength);
            this.groupBox7.Controls.Add(this.textBox_batteryWidth);
            this.groupBox7.Controls.Add(this.label_batteryDimensionsMeters);
            this.groupBox7.Controls.Add(this.label_batteryDimensionsInches);
            this.groupBox7.Controls.Add(this.radioButton_batteryDimensionsInches);
            this.groupBox7.Controls.Add(this.radioButton_batteryDimensionsMeters);
            this.groupBox7.Controls.Add(this.label_batteryHeight);
            this.groupBox7.Controls.Add(this.label_batteryLength);
            this.groupBox7.Controls.Add(this.label_batteryWidth);
            this.groupBox7.Controls.Add(this.label_batteryWeight);
            this.groupBox7.Location = new System.Drawing.Point(7, 305);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(319, 214);
            this.groupBox7.TabIndex = 391;
            this.groupBox7.TabStop = false;
            // 
            // textBox_batteryWeight
            // 
            this.textBox_batteryWeight.Location = new System.Drawing.Point(4, 175);
            this.textBox_batteryWeight.Name = "textBox_batteryWeight";
            this.textBox_batteryWeight.Size = new System.Drawing.Size(229, 22);
            this.textBox_batteryWeight.TabIndex = 400;
            // 
            // textBox_batteryHeight
            // 
            this.textBox_batteryHeight.Location = new System.Drawing.Point(4, 37);
            this.textBox_batteryHeight.Name = "textBox_batteryHeight";
            this.textBox_batteryHeight.Size = new System.Drawing.Size(229, 22);
            this.textBox_batteryHeight.TabIndex = 397;
            // 
            // textBox_batteryLength
            // 
            this.textBox_batteryLength.Location = new System.Drawing.Point(4, 83);
            this.textBox_batteryLength.Name = "textBox_batteryLength";
            this.textBox_batteryLength.Size = new System.Drawing.Size(229, 22);
            this.textBox_batteryLength.TabIndex = 398;
            // 
            // textBox_batteryWidth
            // 
            this.textBox_batteryWidth.Location = new System.Drawing.Point(4, 129);
            this.textBox_batteryWidth.Name = "textBox_batteryWidth";
            this.textBox_batteryWidth.Size = new System.Drawing.Size(229, 22);
            this.textBox_batteryWidth.TabIndex = 399;
            // 
            // label_batteryDimensionsMeters
            // 
            this.label_batteryDimensionsMeters.Location = new System.Drawing.Point(244, 57);
            this.label_batteryDimensionsMeters.Name = "label_batteryDimensionsMeters";
            this.label_batteryDimensionsMeters.Size = new System.Drawing.Size(49, 15);
            this.label_batteryDimensionsMeters.TabIndex = 386;
            this.label_batteryDimensionsMeters.Text = "Meters";
            // 
            // label_batteryDimensionsInches
            // 
            this.label_batteryDimensionsInches.Location = new System.Drawing.Point(244, 117);
            this.label_batteryDimensionsInches.Name = "label_batteryDimensionsInches";
            this.label_batteryDimensionsInches.Size = new System.Drawing.Size(49, 15);
            this.label_batteryDimensionsInches.TabIndex = 387;
            this.label_batteryDimensionsInches.Text = "Inches";
            // 
            // radioButton_batteryDimensionsInches
            // 
            this.radioButton_batteryDimensionsInches.AutoSize = true;
            this.radioButton_batteryDimensionsInches.Location = new System.Drawing.Point(258, 144);
            this.radioButton_batteryDimensionsInches.Name = "radioButton_batteryDimensionsInches";
            this.radioButton_batteryDimensionsInches.Size = new System.Drawing.Size(17, 16);
            this.radioButton_batteryDimensionsInches.TabIndex = 3;
            this.radioButton_batteryDimensionsInches.TabStop = true;
            this.radioButton_batteryDimensionsInches.UseVisualStyleBackColor = true;
            // 
            // radioButton_batteryDimensionsMeters
            // 
            this.radioButton_batteryDimensionsMeters.AutoSize = true;
            this.radioButton_batteryDimensionsMeters.Location = new System.Drawing.Point(258, 83);
            this.radioButton_batteryDimensionsMeters.Name = "radioButton_batteryDimensionsMeters";
            this.radioButton_batteryDimensionsMeters.Size = new System.Drawing.Size(17, 16);
            this.radioButton_batteryDimensionsMeters.TabIndex = 2;
            this.radioButton_batteryDimensionsMeters.TabStop = true;
            this.radioButton_batteryDimensionsMeters.UseVisualStyleBackColor = true;
            // 
            // label_batteryHeight
            // 
            this.label_batteryHeight.Location = new System.Drawing.Point(4, 12);
            this.label_batteryHeight.Name = "label_batteryHeight";
            this.label_batteryHeight.Size = new System.Drawing.Size(229, 24);
            this.label_batteryHeight.TabIndex = 380;
            this.label_batteryHeight.Text = "Battery Height:";
            this.label_batteryHeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_batteryLength
            // 
            this.label_batteryLength.Location = new System.Drawing.Point(4, 58);
            this.label_batteryLength.Name = "label_batteryLength";
            this.label_batteryLength.Size = new System.Drawing.Size(229, 24);
            this.label_batteryLength.TabIndex = 381;
            this.label_batteryLength.Text = "Battery Length:";
            this.label_batteryLength.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_batteryWidth
            // 
            this.label_batteryWidth.Location = new System.Drawing.Point(4, 104);
            this.label_batteryWidth.Name = "label_batteryWidth";
            this.label_batteryWidth.Size = new System.Drawing.Size(229, 24);
            this.label_batteryWidth.TabIndex = 382;
            this.label_batteryWidth.Text = "Battery Width:";
            this.label_batteryWidth.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_batteryWeight
            // 
            this.label_batteryWeight.Location = new System.Drawing.Point(4, 150);
            this.label_batteryWeight.Name = "label_batteryWeight";
            this.label_batteryWeight.Size = new System.Drawing.Size(229, 24);
            this.label_batteryWeight.TabIndex = 383;
            this.label_batteryWeight.Text = "Battery Weight:";
            this.label_batteryWeight.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox_rackType);
            this.groupBox4.Controls.Add(this.textBox_batteryRack);
            this.groupBox4.Controls.Add(this.button_Ajouter);
            this.groupBox4.Controls.Add(this.button_Sauvegarder);
            this.groupBox4.Controls.Add(this.textBox_date);
            this.groupBox4.Controls.Add(this.label_date);
            this.groupBox4.Controls.Add(this.label_batteryRack);
            this.groupBox4.Controls.Add(this.radioButton_rackPriceUS);
            this.groupBox4.Controls.Add(this.groupBox6);
            this.groupBox4.Controls.Add(this.radioButton_rackPriceCA);
            this.groupBox4.Controls.Add(this.groupBox5);
            this.groupBox4.Controls.Add(this.label_rackPriceUS);
            this.groupBox4.Controls.Add(this.label_rackType);
            this.groupBox4.Controls.Add(this.label_rackPriceCA);
            this.groupBox4.Controls.Add(this.textBox_rackPrice);
            this.groupBox4.Controls.Add(this.label_rackPrice);
            this.groupBox4.Location = new System.Drawing.Point(355, 5);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1567, 148);
            this.groupBox4.TabIndex = 1;
            this.groupBox4.TabStop = false;
            // 
            // textBox_rackType
            // 
            this.textBox_rackType.Location = new System.Drawing.Point(250, 46);
            this.textBox_rackType.Name = "textBox_rackType";
            this.textBox_rackType.Size = new System.Drawing.Size(229, 22);
            this.textBox_rackType.TabIndex = 403;
            // 
            // textBox_batteryRack
            // 
            this.textBox_batteryRack.Location = new System.Drawing.Point(250, 104);
            this.textBox_batteryRack.Name = "textBox_batteryRack";
            this.textBox_batteryRack.Size = new System.Drawing.Size(229, 22);
            this.textBox_batteryRack.TabIndex = 404;
            // 
            // button_Ajouter
            // 
            this.button_Ajouter.Location = new System.Drawing.Point(1463, 88);
            this.button_Ajouter.Name = "button_Ajouter";
            this.button_Ajouter.Size = new System.Drawing.Size(90, 26);
            this.button_Ajouter.TabIndex = 392;
            this.button_Ajouter.Text = "Ajouter";
            this.button_Ajouter.UseVisualStyleBackColor = true;
            // 
            // button_Sauvegarder
            // 
            this.button_Sauvegarder.Location = new System.Drawing.Point(1463, 46);
            this.button_Sauvegarder.Name = "button_Sauvegarder";
            this.button_Sauvegarder.Size = new System.Drawing.Size(90, 27);
            this.button_Sauvegarder.TabIndex = 391;
            this.button_Sauvegarder.Text = "Sauvegarder";
            this.button_Sauvegarder.UseVisualStyleBackColor = true;
            // 
            // textBox_date
            // 
            this.textBox_date.Location = new System.Drawing.Point(1014, 104);
            this.textBox_date.Name = "textBox_date";
            this.textBox_date.Size = new System.Drawing.Size(145, 22);
            this.textBox_date.TabIndex = 2;
            // 
            // label_date
            // 
            this.label_date.Location = new System.Drawing.Point(1014, 75);
            this.label_date.Name = "label_date";
            this.label_date.Size = new System.Drawing.Size(145, 24);
            this.label_date.TabIndex = 2;
            this.label_date.Text = "Date (dd/mm/yy) :";
            this.label_date.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_batteryRack
            // 
            this.label_batteryRack.Location = new System.Drawing.Point(250, 75);
            this.label_batteryRack.Name = "label_batteryRack";
            this.label_batteryRack.Size = new System.Drawing.Size(229, 24);
            this.label_batteryRack.TabIndex = 387;
            this.label_batteryRack.Text = "Battery Rack:";
            this.label_batteryRack.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // radioButton_rackPriceUS
            // 
            this.radioButton_rackPriceUS.AutoSize = true;
            this.radioButton_rackPriceUS.Location = new System.Drawing.Point(1321, 87);
            this.radioButton_rackPriceUS.Name = "radioButton_rackPriceUS";
            this.radioButton_rackPriceUS.Size = new System.Drawing.Size(17, 16);
            this.radioButton_rackPriceUS.TabIndex = 390;
            this.radioButton_rackPriceUS.TabStop = true;
            this.radioButton_rackPriceUS.UseVisualStyleBackColor = true;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.radioButton_rackDimensionsMeters);
            this.groupBox6.Controls.Add(this.radioButton_rackDimensionsInches);
            this.groupBox6.Controls.Add(this.label_rackDimensionsMeters);
            this.groupBox6.Controls.Add(this.label_rackDimensionsInches);
            this.groupBox6.Controls.Add(this.textBox_rackWidth);
            this.groupBox6.Controls.Add(this.textBox_rackLength);
            this.groupBox6.Controls.Add(this.textBox_rackHeight);
            this.groupBox6.Controls.Add(this.label_rackHeight);
            this.groupBox6.Controls.Add(this.label_rackLength);
            this.groupBox6.Controls.Add(this.label_rackWidth);
            this.groupBox6.Location = new System.Drawing.Point(613, 10);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(307, 125);
            this.groupBox6.TabIndex = 6;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "Dimensions";
            // 
            // radioButton_rackDimensionsMeters
            // 
            this.radioButton_rackDimensionsMeters.AutoSize = true;
            this.radioButton_rackDimensionsMeters.Location = new System.Drawing.Point(256, 32);
            this.radioButton_rackDimensionsMeters.Name = "radioButton_rackDimensionsMeters";
            this.radioButton_rackDimensionsMeters.Size = new System.Drawing.Size(17, 16);
            this.radioButton_rackDimensionsMeters.TabIndex = 3;
            this.radioButton_rackDimensionsMeters.TabStop = true;
            this.radioButton_rackDimensionsMeters.UseVisualStyleBackColor = true;
            // 
            // radioButton_rackDimensionsInches
            // 
            this.radioButton_rackDimensionsInches.AutoSize = true;
            this.radioButton_rackDimensionsInches.Location = new System.Drawing.Point(256, 89);
            this.radioButton_rackDimensionsInches.Name = "radioButton_rackDimensionsInches";
            this.radioButton_rackDimensionsInches.Size = new System.Drawing.Size(17, 16);
            this.radioButton_rackDimensionsInches.TabIndex = 2;
            this.radioButton_rackDimensionsInches.TabStop = true;
            this.radioButton_rackDimensionsInches.UseVisualStyleBackColor = true;
            // 
            // label_rackDimensionsMeters
            // 
            this.label_rackDimensionsMeters.Location = new System.Drawing.Point(239, 12);
            this.label_rackDimensionsMeters.Name = "label_rackDimensionsMeters";
            this.label_rackDimensionsMeters.Size = new System.Drawing.Size(49, 24);
            this.label_rackDimensionsMeters.TabIndex = 2;
            this.label_rackDimensionsMeters.Text = "Meters";
            // 
            // label_rackDimensionsInches
            // 
            this.label_rackDimensionsInches.Location = new System.Drawing.Point(239, 69);
            this.label_rackDimensionsInches.Name = "label_rackDimensionsInches";
            this.label_rackDimensionsInches.Size = new System.Drawing.Size(49, 24);
            this.label_rackDimensionsInches.TabIndex = 3;
            this.label_rackDimensionsInches.Text = "Inches";
            // 
            // textBox_rackWidth
            // 
            this.textBox_rackWidth.Location = new System.Drawing.Point(97, 92);
            this.textBox_rackWidth.Name = "textBox_rackWidth";
            this.textBox_rackWidth.Size = new System.Drawing.Size(120, 22);
            this.textBox_rackWidth.TabIndex = 7;
            // 
            // textBox_rackLength
            // 
            this.textBox_rackLength.Location = new System.Drawing.Point(97, 58);
            this.textBox_rackLength.Name = "textBox_rackLength";
            this.textBox_rackLength.Size = new System.Drawing.Size(120, 22);
            this.textBox_rackLength.TabIndex = 6;
            // 
            // textBox_rackHeight
            // 
            this.textBox_rackHeight.Location = new System.Drawing.Point(97, 23);
            this.textBox_rackHeight.Name = "textBox_rackHeight";
            this.textBox_rackHeight.Size = new System.Drawing.Size(120, 22);
            this.textBox_rackHeight.TabIndex = 5;
            // 
            // label_rackHeight
            // 
            this.label_rackHeight.Location = new System.Drawing.Point(4, 23);
            this.label_rackHeight.Name = "label_rackHeight";
            this.label_rackHeight.Size = new System.Drawing.Size(90, 24);
            this.label_rackHeight.TabIndex = 2;
            this.label_rackHeight.Text = "Rack Height:";
            // 
            // label_rackLength
            // 
            this.label_rackLength.Location = new System.Drawing.Point(4, 58);
            this.label_rackLength.Name = "label_rackLength";
            this.label_rackLength.Size = new System.Drawing.Size(90, 24);
            this.label_rackLength.TabIndex = 3;
            this.label_rackLength.Text = "Rack Length:";
            // 
            // label_rackWidth
            // 
            this.label_rackWidth.Location = new System.Drawing.Point(4, 92);
            this.label_rackWidth.Name = "label_rackWidth";
            this.label_rackWidth.Size = new System.Drawing.Size(90, 25);
            this.label_rackWidth.TabIndex = 4;
            this.label_rackWidth.Text = "Rack Width:";
            // 
            // radioButton_rackPriceCA
            // 
            this.radioButton_rackPriceCA.AutoSize = true;
            this.radioButton_rackPriceCA.Location = new System.Drawing.Point(1273, 87);
            this.radioButton_rackPriceCA.Name = "radioButton_rackPriceCA";
            this.radioButton_rackPriceCA.Size = new System.Drawing.Size(17, 16);
            this.radioButton_rackPriceCA.TabIndex = 389;
            this.radioButton_rackPriceCA.TabStop = true;
            this.radioButton_rackPriceCA.UseVisualStyleBackColor = true;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.radioButton_seismicYes);
            this.groupBox5.Controls.Add(this.radioButton_seismicNo);
            this.groupBox5.Controls.Add(this.label_seismicYes);
            this.groupBox5.Controls.Add(this.label_seismicNo);
            this.groupBox5.Location = new System.Drawing.Point(7, 20);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(111, 115);
            this.groupBox5.TabIndex = 4;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = "Seismic";
            // 
            // radioButton_seismicYes
            // 
            this.radioButton_seismicYes.AutoSize = true;
            this.radioButton_seismicYes.Location = new System.Drawing.Point(25, 70);
            this.radioButton_seismicYes.Name = "radioButton_seismicYes";
            this.radioButton_seismicYes.Size = new System.Drawing.Size(17, 16);
            this.radioButton_seismicYes.TabIndex = 2;
            this.radioButton_seismicYes.TabStop = true;
            this.radioButton_seismicYes.UseVisualStyleBackColor = true;
            // 
            // radioButton_seismicNo
            // 
            this.radioButton_seismicNo.AutoSize = true;
            this.radioButton_seismicNo.Location = new System.Drawing.Point(73, 70);
            this.radioButton_seismicNo.Name = "radioButton_seismicNo";
            this.radioButton_seismicNo.Size = new System.Drawing.Size(17, 16);
            this.radioButton_seismicNo.TabIndex = 3;
            this.radioButton_seismicNo.TabStop = true;
            this.radioButton_seismicNo.UseVisualStyleBackColor = true;
            // 
            // label_seismicYes
            // 
            this.label_seismicYes.AutoSize = true;
            this.label_seismicYes.Location = new System.Drawing.Point(18, 42);
            this.label_seismicYes.Name = "label_seismicYes";
            this.label_seismicYes.Size = new System.Drawing.Size(32, 17);
            this.label_seismicYes.TabIndex = 2;
            this.label_seismicYes.Text = "Yes";
            this.label_seismicYes.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_seismicNo
            // 
            this.label_seismicNo.AutoSize = true;
            this.label_seismicNo.Location = new System.Drawing.Point(70, 42);
            this.label_seismicNo.Name = "label_seismicNo";
            this.label_seismicNo.Size = new System.Drawing.Size(26, 17);
            this.label_seismicNo.TabIndex = 3;
            this.label_seismicNo.Text = "No";
            this.label_seismicNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_rackPriceUS
            // 
            this.label_rackPriceUS.Location = new System.Drawing.Point(1315, 65);
            this.label_rackPriceUS.Name = "label_rackPriceUS";
            this.label_rackPriceUS.Size = new System.Drawing.Size(30, 15);
            this.label_rackPriceUS.TabIndex = 388;
            this.label_rackPriceUS.Text = "US";
            this.label_rackPriceUS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_rackType
            // 
            this.label_rackType.Location = new System.Drawing.Point(250, 17);
            this.label_rackType.Name = "label_rackType";
            this.label_rackType.Size = new System.Drawing.Size(229, 25);
            this.label_rackType.TabIndex = 386;
            this.label_rackType.Text = "Rack Type:";
            this.label_rackType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_rackPriceCA
            // 
            this.label_rackPriceCA.Location = new System.Drawing.Point(1267, 65);
            this.label_rackPriceCA.Name = "label_rackPriceCA";
            this.label_rackPriceCA.Size = new System.Drawing.Size(30, 15);
            this.label_rackPriceCA.TabIndex = 387;
            this.label_rackPriceCA.Text = "CA";
            this.label_rackPriceCA.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox_rackPrice
            // 
            this.textBox_rackPrice.Location = new System.Drawing.Point(1014, 46);
            this.textBox_rackPrice.Name = "textBox_rackPrice";
            this.textBox_rackPrice.Size = new System.Drawing.Size(145, 22);
            this.textBox_rackPrice.TabIndex = 386;
            // 
            // label_rackPrice
            // 
            this.label_rackPrice.Location = new System.Drawing.Point(1014, 17);
            this.label_rackPrice.Name = "label_rackPrice";
            this.label_rackPrice.Size = new System.Drawing.Size(145, 25);
            this.label_rackPrice.TabIndex = 2;
            this.label_rackPrice.Text = "Price:";
            this.label_rackPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textBox_batteryPrice);
            this.groupBox3.Controls.Add(this.textBox_batteryManufacturer);
            this.groupBox3.Controls.Add(this.textBox_batteryType);
            this.groupBox3.Controls.Add(this.textBox_batteryModel);
            this.groupBox3.Controls.Add(this.textBox_batteryAlloy);
            this.groupBox3.Controls.Add(this.textBox_batteryCapacity);
            this.groupBox3.Controls.Add(this.textBox_batteryLife);
            this.groupBox3.Controls.Add(this.radioButton_batteryPriceCA);
            this.groupBox3.Controls.Add(this.radioButton_batteryPriceUS);
            this.groupBox3.Controls.Add(this.label_batteryPriceUS);
            this.groupBox3.Controls.Add(this.label_batteryPriceCA);
            this.groupBox3.Controls.Add(this.label_batteryPrice);
            this.groupBox3.Controls.Add(this.label_batteryLife);
            this.groupBox3.Controls.Add(this.label_batteryCapacity);
            this.groupBox3.Controls.Add(this.label_batteryAlloy);
            this.groupBox3.Controls.Add(this.label_batteryManufacturer);
            this.groupBox3.Controls.Add(this.label_batteryType);
            this.groupBox3.Controls.Add(this.label_batteryModel);
            this.groupBox3.Location = new System.Drawing.Point(7, 5);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(341, 647);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Battery";
            // 
            // textBox_batteryPrice
            // 
            this.textBox_batteryPrice.Location = new System.Drawing.Point(4, 606);
            this.textBox_batteryPrice.Name = "textBox_batteryPrice";
            this.textBox_batteryPrice.Size = new System.Drawing.Size(229, 22);
            this.textBox_batteryPrice.TabIndex = 402;
            // 
            // textBox_batteryManufacturer
            // 
            this.textBox_batteryManufacturer.AutoCompleteCustomSource.AddRange(new string[] {
            "Abel",
            "Bing",
            "Catherine",
            "John",
            "Kerry",
            "Varghese"});
            this.textBox_batteryManufacturer.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.textBox_batteryManufacturer.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.textBox_batteryManufacturer.Location = new System.Drawing.Point(4, 46);
            this.textBox_batteryManufacturer.Name = "textBox_batteryManufacturer";
            this.textBox_batteryManufacturer.Size = new System.Drawing.Size(229, 22);
            this.textBox_batteryManufacturer.TabIndex = 392;
            // 
            // textBox_batteryType
            // 
            this.textBox_batteryType.Location = new System.Drawing.Point(4, 104);
            this.textBox_batteryType.Name = "textBox_batteryType";
            this.textBox_batteryType.Size = new System.Drawing.Size(229, 22);
            this.textBox_batteryType.TabIndex = 393;
            // 
            // textBox_batteryModel
            // 
            this.textBox_batteryModel.Location = new System.Drawing.Point(4, 162);
            this.textBox_batteryModel.Name = "textBox_batteryModel";
            this.textBox_batteryModel.Size = new System.Drawing.Size(229, 22);
            this.textBox_batteryModel.TabIndex = 394;
            // 
            // textBox_batteryAlloy
            // 
            this.textBox_batteryAlloy.Location = new System.Drawing.Point(4, 219);
            this.textBox_batteryAlloy.Name = "textBox_batteryAlloy";
            this.textBox_batteryAlloy.Size = new System.Drawing.Size(229, 22);
            this.textBox_batteryAlloy.TabIndex = 395;
            // 
            // textBox_batteryCapacity
            // 
            this.textBox_batteryCapacity.Location = new System.Drawing.Point(4, 277);
            this.textBox_batteryCapacity.Name = "textBox_batteryCapacity";
            this.textBox_batteryCapacity.Size = new System.Drawing.Size(229, 22);
            this.textBox_batteryCapacity.TabIndex = 396;
            // 
            // textBox_batteryLife
            // 
            this.textBox_batteryLife.Location = new System.Drawing.Point(4, 548);
            this.textBox_batteryLife.Name = "textBox_batteryLife";
            this.textBox_batteryLife.Size = new System.Drawing.Size(229, 22);
            this.textBox_batteryLife.TabIndex = 401;
            // 
            // radioButton_batteryPriceCA
            // 
            this.radioButton_batteryPriceCA.AutoSize = true;
            this.radioButton_batteryPriceCA.Location = new System.Drawing.Point(257, 600);
            this.radioButton_batteryPriceCA.Name = "radioButton_batteryPriceCA";
            this.radioButton_batteryPriceCA.Size = new System.Drawing.Size(17, 16);
            this.radioButton_batteryPriceCA.TabIndex = 390;
            this.radioButton_batteryPriceCA.TabStop = true;
            this.radioButton_batteryPriceCA.UseVisualStyleBackColor = true;
            // 
            // radioButton_batteryPriceUS
            // 
            this.radioButton_batteryPriceUS.AutoSize = true;
            this.radioButton_batteryPriceUS.Location = new System.Drawing.Point(312, 600);
            this.radioButton_batteryPriceUS.Name = "radioButton_batteryPriceUS";
            this.radioButton_batteryPriceUS.Size = new System.Drawing.Size(17, 16);
            this.radioButton_batteryPriceUS.TabIndex = 391;
            this.radioButton_batteryPriceUS.TabStop = true;
            this.radioButton_batteryPriceUS.UseVisualStyleBackColor = true;
            // 
            // label_batteryPriceUS
            // 
            this.label_batteryPriceUS.Location = new System.Drawing.Point(306, 577);
            this.label_batteryPriceUS.Name = "label_batteryPriceUS";
            this.label_batteryPriceUS.Size = new System.Drawing.Size(30, 15);
            this.label_batteryPriceUS.TabIndex = 389;
            this.label_batteryPriceUS.Text = "US";
            this.label_batteryPriceUS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_batteryPriceCA
            // 
            this.label_batteryPriceCA.Location = new System.Drawing.Point(252, 577);
            this.label_batteryPriceCA.Name = "label_batteryPriceCA";
            this.label_batteryPriceCA.Size = new System.Drawing.Size(30, 15);
            this.label_batteryPriceCA.TabIndex = 388;
            this.label_batteryPriceCA.Text = "CA";
            this.label_batteryPriceCA.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_batteryPrice
            // 
            this.label_batteryPrice.Location = new System.Drawing.Point(4, 577);
            this.label_batteryPrice.Name = "label_batteryPrice";
            this.label_batteryPrice.Size = new System.Drawing.Size(229, 24);
            this.label_batteryPrice.TabIndex = 385;
            this.label_batteryPrice.Text = "Battery Price:";
            this.label_batteryPrice.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_batteryLife
            // 
            this.label_batteryLife.Location = new System.Drawing.Point(4, 519);
            this.label_batteryLife.Name = "label_batteryLife";
            this.label_batteryLife.Size = new System.Drawing.Size(229, 24);
            this.label_batteryLife.TabIndex = 384;
            this.label_batteryLife.Text = "Battery Life:";
            this.label_batteryLife.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_batteryCapacity
            // 
            this.label_batteryCapacity.Location = new System.Drawing.Point(4, 248);
            this.label_batteryCapacity.Name = "label_batteryCapacity";
            this.label_batteryCapacity.Size = new System.Drawing.Size(229, 24);
            this.label_batteryCapacity.TabIndex = 379;
            this.label_batteryCapacity.Text = "Battery Capacity:";
            this.label_batteryCapacity.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_batteryAlloy
            // 
            this.label_batteryAlloy.Location = new System.Drawing.Point(4, 190);
            this.label_batteryAlloy.Name = "label_batteryAlloy";
            this.label_batteryAlloy.Size = new System.Drawing.Size(229, 25);
            this.label_batteryAlloy.TabIndex = 378;
            this.label_batteryAlloy.Text = "Battery Alloy:";
            this.label_batteryAlloy.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_batteryManufacturer
            // 
            this.label_batteryManufacturer.Location = new System.Drawing.Point(4, 17);
            this.label_batteryManufacturer.Name = "label_batteryManufacturer";
            this.label_batteryManufacturer.Size = new System.Drawing.Size(229, 25);
            this.label_batteryManufacturer.TabIndex = 375;
            this.label_batteryManufacturer.Text = "Battery Manufacturer:";
            this.label_batteryManufacturer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_batteryType
            // 
            this.label_batteryType.Location = new System.Drawing.Point(4, 75);
            this.label_batteryType.Name = "label_batteryType";
            this.label_batteryType.Size = new System.Drawing.Size(229, 24);
            this.label_batteryType.TabIndex = 376;
            this.label_batteryType.Text = "Battery Type:";
            this.label_batteryType.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_batteryModel
            // 
            this.label_batteryModel.Location = new System.Drawing.Point(4, 133);
            this.label_batteryModel.Name = "label_batteryModel";
            this.label_batteryModel.Size = new System.Drawing.Size(229, 24);
            this.label_batteryModel.TabIndex = 377;
            this.label_batteryModel.Text = "Battery Model:";
            this.label_batteryModel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pnlStrat
            // 
            this.pnlStrat.BackColor = System.Drawing.SystemColors.Control;
            this.pnlStrat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlStrat.Controls.Add(this.lSTAX);
            this.pnlStrat.Controls.Add(this.lCstms);
            this.pnlStrat.Controls.Add(this.label23);
            this.pnlStrat.Controls.Add(this.label22);
            this.pnlStrat.Controls.Add(this.lvalfrais);
            this.pnlStrat.Controls.Add(this.lsavALLinfo);
            this.pnlStrat.Controls.Add(this.label21);
            this.pnlStrat.Controls.Add(this.pictureBox5);
            this.pnlStrat.Controls.Add(this.valFrais);
            this.pnlStrat.Controls.Add(this.label18);
            this.pnlStrat.Controls.Add(this.label19);
            this.pnlStrat.Controls.Add(this.label20);
            this.pnlStrat.Controls.Add(this.txD31_UCst);
            this.pnlStrat.Controls.Add(this.txD30_UCst);
            this.pnlStrat.Controls.Add(this.txD31_Qty);
            this.pnlStrat.Controls.Add(this.txD30_Qty);
            this.pnlStrat.Controls.Add(this.textBox20);
            this.pnlStrat.Controls.Add(this.txSTAX);
            this.pnlStrat.Controls.Add(this.textBox4);
            this.pnlStrat.Controls.Add(this.txCstms);
            this.pnlStrat.Controls.Add(this.pictureBox4);
            this.pnlStrat.Controls.Add(this.optCAD);
            this.pnlStrat.Controls.Add(this.optUS);
            this.pnlStrat.Controls.Add(this.picMoveUP);
            this.pnlStrat.Controls.Add(this.up3);
            this.pnlStrat.Controls.Add(this.textBox9);
            this.pnlStrat.Controls.Add(this.Amnt3);
            this.pnlStrat.Controls.Add(this.hh3);
            this.pnlStrat.Controls.Add(this.txD44);
            this.pnlStrat.Controls.Add(this.textBox29);
            this.pnlStrat.Controls.Add(this.txD46);
            this.pnlStrat.Controls.Add(this.textBox28);
            this.pnlStrat.Controls.Add(this.textBox23);
            this.pnlStrat.Controls.Add(this.textBox24);
            this.pnlStrat.Controls.Add(this.txD34);
            this.pnlStrat.Controls.Add(this.textBox26);
            this.pnlStrat.Controls.Add(this.textBox17);
            this.pnlStrat.Controls.Add(this.textBox19);
            this.pnlStrat.Controls.Add(this.txD33);
            this.pnlStrat.Controls.Add(this.textBox22);
            this.pnlStrat.Controls.Add(this.textBox12);
            this.pnlStrat.Controls.Add(this.textBox13);
            this.pnlStrat.Controls.Add(this.txD32);
            this.pnlStrat.Controls.Add(this.textBox16);
            this.pnlStrat.Controls.Add(this.textBox7);
            this.pnlStrat.Controls.Add(this.txD31);
            this.pnlStrat.Controls.Add(this.textBox11);
            this.pnlStrat.Controls.Add(this.textBox1);
            this.pnlStrat.Controls.Add(this.txD30);
            this.pnlStrat.Controls.Add(this.textBox5);
            this.pnlStrat.Controls.Add(this.txD42);
            this.pnlStrat.Controls.Add(this.panel4);
            this.pnlStrat.Controls.Add(this.textBox21);
            this.pnlStrat.Controls.Add(this.up6);
            this.pnlStrat.Controls.Add(this.textBox18);
            this.pnlStrat.Controls.Add(this.Amnt6);
            this.pnlStrat.Controls.Add(this.hh6);
            this.pnlStrat.Controls.Add(this.up5);
            this.pnlStrat.Controls.Add(this.textBox14);
            this.pnlStrat.Controls.Add(this.Amnt5);
            this.pnlStrat.Controls.Add(this.hh5);
            this.pnlStrat.Controls.Add(this.up4);
            this.pnlStrat.Controls.Add(this.textBox10);
            this.pnlStrat.Controls.Add(this.Amnt4);
            this.pnlStrat.Controls.Add(this.hh4);
            this.pnlStrat.Controls.Add(this.up2);
            this.pnlStrat.Controls.Add(this.textBox6);
            this.pnlStrat.Controls.Add(this.Amnt2);
            this.pnlStrat.Controls.Add(this.hh2);
            this.pnlStrat.Controls.Add(this.up1);
            this.pnlStrat.Controls.Add(this.textBox2);
            this.pnlStrat.Controls.Add(this.label12);
            this.pnlStrat.Controls.Add(this.label14);
            this.pnlStrat.Controls.Add(this.Amnt1);
            this.pnlStrat.Controls.Add(this.hh1);
            this.pnlStrat.Controls.Add(this.label16);
            this.pnlStrat.Location = new System.Drawing.Point(7, 88);
            this.pnlStrat.Name = "pnlStrat";
            this.pnlStrat.Size = new System.Drawing.Size(1486, 392);
            this.pnlStrat.TabIndex = 179;
            this.pnlStrat.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlStrat_Paint);
            // 
            // lSTAX
            // 
            this.lSTAX.BackColor = System.Drawing.Color.PeachPuff;
            this.lSTAX.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lSTAX.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSTAX.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lSTAX.Location = new System.Drawing.Point(442, 197);
            this.lSTAX.Name = "lSTAX";
            this.lSTAX.Size = new System.Drawing.Size(46, 23);
            this.lSTAX.TabIndex = 388;
            this.lSTAX.Text = "0.05";
            this.lSTAX.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lSTAX.Visible = false;
            // 
            // lCstms
            // 
            this.lCstms.BackColor = System.Drawing.Color.PeachPuff;
            this.lCstms.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lCstms.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCstms.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lCstms.Location = new System.Drawing.Point(446, 130);
            this.lCstms.Name = "lCstms";
            this.lCstms.Size = new System.Drawing.Size(47, 23);
            this.lCstms.TabIndex = 387;
            this.lCstms.Text = "0.07";
            this.lCstms.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lCstms.Visible = false;
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.SystemColors.Control;
            this.label23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label23.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(392, 130);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(26, 23);
            this.label23.TabIndex = 386;
            this.label23.Text = "%";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label22.Font = new System.Drawing.Font("Arial", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(391, 196);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(27, 23);
            this.label22.TabIndex = 385;
            this.label22.Text = "%";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lvalfrais
            // 
            this.lvalfrais.BackColor = System.Drawing.Color.PeachPuff;
            this.lvalfrais.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lvalfrais.Font = new System.Drawing.Font("Arial Narrow", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvalfrais.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lvalfrais.Location = new System.Drawing.Point(655, 276);
            this.lvalfrais.Name = "lvalfrais";
            this.lvalfrais.Size = new System.Drawing.Size(29, 23);
            this.lvalfrais.TabIndex = 384;
            this.lvalfrais.Text = "TF";
            this.lvalfrais.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lvalfrais.Visible = false;
            // 
            // lsavALLinfo
            // 
            this.lsavALLinfo.BackColor = System.Drawing.Color.LightSkyBlue;
            this.lsavALLinfo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lsavALLinfo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsavALLinfo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lsavALLinfo.Location = new System.Drawing.Point(552, 348);
            this.lsavALLinfo.Name = "lsavALLinfo";
            this.lsavALLinfo.Size = new System.Drawing.Size(932, 26);
            this.lsavALLinfo.TabIndex = 383;
            this.lsavALLinfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label21.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(691, 129);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(98, 25);
            this.label21.TabIndex = 382;
            this.label21.Text = "Refresh";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label21.Visible = false;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(698, 155);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(87, 82);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 381;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Visible = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // valFrais
            // 
            this.valFrais.BackColor = System.Drawing.Color.White;
            this.valFrais.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valFrais.ForeColor = System.Drawing.Color.Black;
            this.valFrais.Location = new System.Drawing.Point(659, 301);
            this.valFrais.MaxLength = 49;
            this.valFrais.Name = "valFrais";
            this.valFrais.ReadOnly = true;
            this.valFrais.Size = new System.Drawing.Size(177, 26);
            this.valFrais.TabIndex = 181;
            this.valFrais.Text = "0";
            this.valFrais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valFrais.Visible = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label18.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(592, 10);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(105, 25);
            this.label18.TabIndex = 380;
            this.label18.Text = "Unit Cost";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label18.Visible = false;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.BackColor = System.Drawing.SystemColors.Control;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label19.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(197, 24);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(111, 25);
            this.label19.TabIndex = 379;
            this.label19.Text = "Total Cost";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label20.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(749, 5);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(48, 25);
            this.label20.TabIndex = 378;
            this.label20.Text = "Qty";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label20.Visible = false;
            // 
            // txD31_UCst
            // 
            this.txD31_UCst.BackColor = System.Drawing.Color.Orange;
            this.txD31_UCst.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txD31_UCst.ForeColor = System.Drawing.Color.Black;
            this.txD31_UCst.Location = new System.Drawing.Point(690, 69);
            this.txD31_UCst.MaxLength = 49;
            this.txD31_UCst.Name = "txD31_UCst";
            this.txD31_UCst.Size = new System.Drawing.Size(48, 32);
            this.txD31_UCst.TabIndex = 376;
            this.txD31_UCst.Text = "0";
            this.txD31_UCst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txD31_UCst.Visible = false;
            this.txD31_UCst.TextChanged += new System.EventHandler(this.txD31_UCst_TextChanged);
            // 
            // txD30_UCst
            // 
            this.txD30_UCst.BackColor = System.Drawing.Color.SkyBlue;
            this.txD30_UCst.Enabled = false;
            this.txD30_UCst.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txD30_UCst.ForeColor = System.Drawing.Color.Black;
            this.txD30_UCst.Location = new System.Drawing.Point(691, 31);
            this.txD30_UCst.MaxLength = 49;
            this.txD30_UCst.Name = "txD30_UCst";
            this.txD30_UCst.Size = new System.Drawing.Size(47, 32);
            this.txD30_UCst.TabIndex = 377;
            this.txD30_UCst.Text = "0";
            this.txD30_UCst.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txD30_UCst.Visible = false;
            this.txD30_UCst.TextChanged += new System.EventHandler(this.txD30_UCst_TextChanged);
            // 
            // txD31_Qty
            // 
            this.txD31_Qty.BackColor = System.Drawing.Color.Orange;
            this.txD31_Qty.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txD31_Qty.ForeColor = System.Drawing.Color.Black;
            this.txD31_Qty.Location = new System.Drawing.Point(752, 68);
            this.txD31_Qty.MaxLength = 49;
            this.txD31_Qty.Name = "txD31_Qty";
            this.txD31_Qty.Size = new System.Drawing.Size(51, 32);
            this.txD31_Qty.TabIndex = 374;
            this.txD31_Qty.Text = "1";
            this.txD31_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txD31_Qty.Visible = false;
            this.txD31_Qty.TextChanged += new System.EventHandler(this.txD31_Qty_TextChanged);
            // 
            // txD30_Qty
            // 
            this.txD30_Qty.BackColor = System.Drawing.Color.SkyBlue;
            this.txD30_Qty.Enabled = false;
            this.txD30_Qty.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txD30_Qty.ForeColor = System.Drawing.Color.Black;
            this.txD30_Qty.Location = new System.Drawing.Point(752, 30);
            this.txD30_Qty.MaxLength = 49;
            this.txD30_Qty.Name = "txD30_Qty";
            this.txD30_Qty.Size = new System.Drawing.Size(51, 32);
            this.txD30_Qty.TabIndex = 375;
            this.txD30_Qty.Text = "1";
            this.txD30_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txD30_Qty.Visible = false;
            this.txD30_Qty.TextChanged += new System.EventHandler(this.txD30_Qty_TextChanged);
            // 
            // textBox20
            // 
            this.textBox20.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox20.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox20.ForeColor = System.Drawing.Color.Black;
            this.textBox20.Location = new System.Drawing.Point(16, 196);
            this.textBox20.MaxLength = 49;
            this.textBox20.Multiline = true;
            this.textBox20.Name = "textBox20";
            this.textBox20.ReadOnly = true;
            this.textBox20.Size = new System.Drawing.Size(334, 27);
            this.textBox20.TabIndex = 372;
            this.textBox20.Text = "Selling State TAX";
            this.textBox20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txSTAX
            // 
            this.txSTAX.BackColor = System.Drawing.Color.White;
            this.txSTAX.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txSTAX.ForeColor = System.Drawing.Color.Red;
            this.txSTAX.Location = new System.Drawing.Point(350, 196);
            this.txSTAX.MaxLength = 49;
            this.txSTAX.Name = "txSTAX";
            this.txSTAX.Size = new System.Drawing.Size(41, 27);
            this.txSTAX.TabIndex = 373;
            this.txSTAX.Text = "5";
            this.txSTAX.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txSTAX.TextChanged += new System.EventHandler(this.txSTAX_TextChanged);
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox4.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.Black;
            this.textBox4.Location = new System.Drawing.Point(16, 129);
            this.textBox4.MaxLength = 49;
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(334, 27);
            this.textBox4.TabIndex = 370;
            this.textBox4.Text = "Import Customs";
            this.textBox4.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txCstms
            // 
            this.txCstms.BackColor = System.Drawing.Color.White;
            this.txCstms.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txCstms.ForeColor = System.Drawing.Color.Red;
            this.txCstms.Location = new System.Drawing.Point(350, 129);
            this.txCstms.MaxLength = 49;
            this.txCstms.Name = "txCstms";
            this.txCstms.Size = new System.Drawing.Size(41, 27);
            this.txCstms.TabIndex = 371;
            this.txCstms.Text = "7";
            this.txCstms.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txCstms.TextChanged += new System.EventHandler(this.txCstms_TextChanged);
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox4.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox4.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox4.Image")));
            this.pictureBox4.Location = new System.Drawing.Point(450, 305);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(86, 82);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox4.TabIndex = 369;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // optCAD
            // 
            this.optCAD.AutoSize = true;
            this.optCAD.BackColor = System.Drawing.Color.Orange;
            this.optCAD.Checked = true;
            this.optCAD.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optCAD.Location = new System.Drawing.Point(16, 90);
            this.optCAD.Name = "optCAD";
            this.optCAD.Size = new System.Drawing.Size(127, 29);
            this.optCAD.TabIndex = 303;
            this.optCAD.TabStop = true;
            this.optCAD.Text = "C$ COST";
            this.optCAD.UseVisualStyleBackColor = false;
            this.optCAD.CheckedChanged += new System.EventHandler(this.optCAD_CheckedChanged);
            // 
            // optUS
            // 
            this.optUS.AutoSize = true;
            this.optUS.BackColor = System.Drawing.Color.SkyBlue;
            this.optUS.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optUS.Location = new System.Drawing.Point(16, 52);
            this.optUS.Name = "optUS";
            this.optUS.Size = new System.Drawing.Size(129, 29);
            this.optUS.TabIndex = 302;
            this.optUS.Text = "US COST";
            this.optUS.UseVisualStyleBackColor = false;
            this.optUS.CheckedChanged += new System.EventHandler(this.optUS_CheckedChanged);
            // 
            // picMoveUP
            // 
            this.picMoveUP.BackColor = System.Drawing.Color.Transparent;
            this.picMoveUP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picMoveUP.Image = ((System.Drawing.Image)(resources.GetObject("picMoveUP.Image")));
            this.picMoveUP.Location = new System.Drawing.Point(122, 305);
            this.picMoveUP.Name = "picMoveUP";
            this.picMoveUP.Size = new System.Drawing.Size(86, 82);
            this.picMoveUP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picMoveUP.TabIndex = 368;
            this.picMoveUP.TabStop = false;
            this.picMoveUP.Click += new System.EventHandler(this.picMoveUP_Click);
            // 
            // up3
            // 
            this.up3.BackColor = System.Drawing.Color.PaleGreen;
            this.up3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.up3.ForeColor = System.Drawing.Color.Black;
            this.up3.Location = new System.Drawing.Point(1260, 103);
            this.up3.MaxLength = 49;
            this.up3.Name = "up3";
            this.up3.ReadOnly = true;
            this.up3.Size = new System.Drawing.Size(86, 27);
            this.up3.TabIndex = 301;
            this.up3.Text = "120";
            this.up3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.ForeColor = System.Drawing.Color.Black;
            this.textBox9.Location = new System.Drawing.Point(853, 103);
            this.textBox9.MaxLength = 49;
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(335, 26);
            this.textBox9.TabIndex = 298;
            this.textBox9.Text = "Syspro";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Amnt3
            // 
            this.Amnt3.BackColor = System.Drawing.Color.PaleGreen;
            this.Amnt3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amnt3.ForeColor = System.Drawing.Color.Black;
            this.Amnt3.Location = new System.Drawing.Point(1346, 103);
            this.Amnt3.MaxLength = 49;
            this.Amnt3.Name = "Amnt3";
            this.Amnt3.ReadOnly = true;
            this.Amnt3.Size = new System.Drawing.Size(131, 27);
            this.Amnt3.TabIndex = 299;
            this.Amnt3.Text = "120";
            this.Amnt3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hh3
            // 
            this.hh3.BackColor = System.Drawing.Color.White;
            this.hh3.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh3.ForeColor = System.Drawing.Color.Black;
            this.hh3.Location = new System.Drawing.Point(1188, 103);
            this.hh3.MaxLength = 49;
            this.hh3.Name = "hh3";
            this.hh3.Size = new System.Drawing.Size(72, 27);
            this.hh3.TabIndex = 300;
            this.hh3.Text = "2";
            this.hh3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hh3.TextChanged += new System.EventHandler(this.hh3_TextChanged);
            // 
            // txD44
            // 
            this.txD44.BackColor = System.Drawing.Color.White;
            this.txD44.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txD44.ForeColor = System.Drawing.Color.Red;
            this.txD44.Location = new System.Drawing.Point(1188, 275);
            this.txD44.MaxLength = 49;
            this.txD44.Name = "txD44";
            this.txD44.Size = new System.Drawing.Size(288, 27);
            this.txD44.TabIndex = 293;
            this.txD44.Text = "1.35";
            this.txD44.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txD44.TextChanged += new System.EventHandler(this.txD44_TextChanged);
            // 
            // textBox29
            // 
            this.textBox29.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox29.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox29.ForeColor = System.Drawing.Color.Red;
            this.textBox29.Location = new System.Drawing.Point(853, 309);
            this.textBox29.MaxLength = 49;
            this.textBox29.Multiline = true;
            this.textBox29.Name = "textBox29";
            this.textBox29.ReadOnly = true;
            this.textBox29.Size = new System.Drawing.Size(335, 27);
            this.textBox29.TabIndex = 296;
            this.textBox29.Text = "NET COST FOB PRIMAX";
            this.textBox29.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txD46
            // 
            this.txD46.BackColor = System.Drawing.Color.PaleGreen;
            this.txD46.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txD46.ForeColor = System.Drawing.Color.Black;
            this.txD46.Location = new System.Drawing.Point(1188, 309);
            this.txD46.MaxLength = 49;
            this.txD46.Name = "txD46";
            this.txD46.ReadOnly = true;
            this.txD46.Size = new System.Drawing.Size(288, 27);
            this.txD46.TabIndex = 297;
            this.txD46.Text = "0";
            this.txD46.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txD46.TextChanged += new System.EventHandler(this.txD46_TextChanged);
            // 
            // textBox28
            // 
            this.textBox28.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox28.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox28.ForeColor = System.Drawing.Color.Black;
            this.textBox28.Location = new System.Drawing.Point(853, 275);
            this.textBox28.MaxLength = 49;
            this.textBox28.Multiline = true;
            this.textBox28.Name = "textBox28";
            this.textBox28.ReadOnly = true;
            this.textBox28.Size = new System.Drawing.Size(335, 26);
            this.textBox28.TabIndex = 291;
            this.textBox28.Text = "Exchange rate";
            this.textBox28.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox23
            // 
            this.textBox23.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox23.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox23.ForeColor = System.Drawing.Color.Black;
            this.textBox23.Location = new System.Drawing.Point(1156, 624);
            this.textBox23.MaxLength = 49;
            this.textBox23.Name = "textBox23";
            this.textBox23.ReadOnly = true;
            this.textBox23.Size = new System.Drawing.Size(86, 27);
            this.textBox23.TabIndex = 290;
            this.textBox23.Text = " ";
            this.textBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox23.Visible = false;
            // 
            // textBox24
            // 
            this.textBox24.BackColor = System.Drawing.SystemColors.Control;
            this.textBox24.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox24.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox24.ForeColor = System.Drawing.Color.Black;
            this.textBox24.Location = new System.Drawing.Point(398, 240);
            this.textBox24.MaxLength = 49;
            this.textBox24.Multiline = true;
            this.textBox24.Name = "textBox24";
            this.textBox24.ReadOnly = true;
            this.textBox24.Size = new System.Drawing.Size(179, 28);
            this.textBox24.TabIndex = 287;
            this.textBox24.Text = "Sell in US$";
            this.textBox24.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txD34
            // 
            this.txD34.BackColor = System.Drawing.Color.SkyBlue;
            this.txD34.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txD34.ForeColor = System.Drawing.Color.Black;
            this.txD34.Location = new System.Drawing.Point(350, 268);
            this.txD34.MaxLength = 49;
            this.txD34.Name = "txD34";
            this.txD34.ReadOnly = true;
            this.txD34.Size = new System.Drawing.Size(288, 30);
            this.txD34.TabIndex = 288;
            this.txD34.Text = "0";
            this.txD34.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox26
            // 
            this.textBox26.BackColor = System.Drawing.Color.White;
            this.textBox26.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox26.ForeColor = System.Drawing.Color.Black;
            this.textBox26.Location = new System.Drawing.Point(1084, 624);
            this.textBox26.MaxLength = 49;
            this.textBox26.Name = "textBox26";
            this.textBox26.Size = new System.Drawing.Size(72, 27);
            this.textBox26.TabIndex = 289;
            this.textBox26.Text = " ";
            this.textBox26.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox26.Visible = false;
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox17.ForeColor = System.Drawing.Color.Black;
            this.textBox17.Location = new System.Drawing.Point(1154, 591);
            this.textBox17.MaxLength = 49;
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(87, 27);
            this.textBox17.TabIndex = 286;
            this.textBox17.Text = " ";
            this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox17.Visible = false;
            // 
            // textBox19
            // 
            this.textBox19.BackColor = System.Drawing.SystemColors.Control;
            this.textBox19.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox19.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox19.ForeColor = System.Drawing.Color.Black;
            this.textBox19.Location = new System.Drawing.Point(66, 240);
            this.textBox19.MaxLength = 49;
            this.textBox19.Multiline = true;
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new System.Drawing.Size(193, 28);
            this.textBox19.TabIndex = 283;
            this.textBox19.Text = "Sell in C$";
            this.textBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txD33
            // 
            this.txD33.BackColor = System.Drawing.Color.Orange;
            this.txD33.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txD33.ForeColor = System.Drawing.Color.Black;
            this.txD33.Location = new System.Drawing.Point(20, 268);
            this.txD33.MaxLength = 49;
            this.txD33.Name = "txD33";
            this.txD33.ReadOnly = true;
            this.txD33.Size = new System.Drawing.Size(300, 30);
            this.txD33.TabIndex = 284;
            this.txD33.Text = "0";
            this.txD33.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txD33.TextChanged += new System.EventHandler(this.txD33_TextChanged);
            // 
            // textBox22
            // 
            this.textBox22.BackColor = System.Drawing.Color.White;
            this.textBox22.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox22.ForeColor = System.Drawing.Color.Black;
            this.textBox22.Location = new System.Drawing.Point(1082, 591);
            this.textBox22.MaxLength = 49;
            this.textBox22.Name = "textBox22";
            this.textBox22.Size = new System.Drawing.Size(72, 27);
            this.textBox22.TabIndex = 285;
            this.textBox22.Text = " ";
            this.textBox22.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox22.Visible = false;
            // 
            // textBox12
            // 
            this.textBox12.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox12.ForeColor = System.Drawing.Color.Black;
            this.textBox12.Location = new System.Drawing.Point(1154, 557);
            this.textBox12.MaxLength = 49;
            this.textBox12.Name = "textBox12";
            this.textBox12.ReadOnly = true;
            this.textBox12.Size = new System.Drawing.Size(87, 27);
            this.textBox12.TabIndex = 282;
            this.textBox12.Text = " ";
            this.textBox12.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox12.Visible = false;
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.ForeColor = System.Drawing.Color.Black;
            this.textBox13.Location = new System.Drawing.Point(16, 163);
            this.textBox13.MaxLength = 49;
            this.textBox13.Multiline = true;
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(334, 26);
            this.textBox13.TabIndex = 279;
            this.textBox13.Text = "Shipping to Primax";
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txD32
            // 
            this.txD32.BackColor = System.Drawing.Color.White;
            this.txD32.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txD32.ForeColor = System.Drawing.Color.Red;
            this.txD32.Location = new System.Drawing.Point(350, 163);
            this.txD32.MaxLength = 49;
            this.txD32.Name = "txD32";
            this.txD32.Size = new System.Drawing.Size(138, 27);
            this.txD32.TabIndex = 280;
            this.txD32.Text = "1";
            this.txD32.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txD32.TextChanged += new System.EventHandler(this.txD32_TextChanged);
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.Color.White;
            this.textBox16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.ForeColor = System.Drawing.Color.Black;
            this.textBox16.Location = new System.Drawing.Point(1082, 557);
            this.textBox16.MaxLength = 49;
            this.textBox16.Name = "textBox16";
            this.textBox16.Size = new System.Drawing.Size(72, 27);
            this.textBox16.TabIndex = 281;
            this.textBox16.Text = " ";
            this.textBox16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox16.Visible = false;
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.ForeColor = System.Drawing.Color.Black;
            this.textBox7.Location = new System.Drawing.Point(1154, 524);
            this.textBox7.MaxLength = 49;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(87, 27);
            this.textBox7.TabIndex = 278;
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox7.Visible = false;
            // 
            // txD31
            // 
            this.txD31.BackColor = System.Drawing.Color.White;
            this.txD31.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txD31.ForeColor = System.Drawing.Color.Black;
            this.txD31.Location = new System.Drawing.Point(134, 89);
            this.txD31.MaxLength = 49;
            this.txD31.Name = "txD31";
            this.txD31.Size = new System.Drawing.Size(216, 32);
            this.txD31.TabIndex = 0;
            this.txD31.Text = "0";
            this.txD31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txD31.TextChanged += new System.EventHandler(this.txD31_TextChanged);
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.Color.White;
            this.textBox11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.ForeColor = System.Drawing.Color.Black;
            this.textBox11.Location = new System.Drawing.Point(1082, 524);
            this.textBox11.MaxLength = 49;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(72, 27);
            this.textBox11.TabIndex = 277;
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox11.Visible = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(1154, 478);
            this.textBox1.MaxLength = 49;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(87, 27);
            this.textBox1.TabIndex = 274;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox1.Visible = false;
            // 
            // txD30
            // 
            this.txD30.BackColor = System.Drawing.Color.White;
            this.txD30.Enabled = false;
            this.txD30.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txD30.ForeColor = System.Drawing.Color.Black;
            this.txD30.Location = new System.Drawing.Point(134, 51);
            this.txD30.MaxLength = 49;
            this.txD30.Name = "txD30";
            this.txD30.Size = new System.Drawing.Size(216, 32);
            this.txD30.TabIndex = 1;
            this.txD30.Text = "0";
            this.txD30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txD30.TextChanged += new System.EventHandler(this.txD30_TextChanged);
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.White;
            this.textBox5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.Black;
            this.textBox5.Location = new System.Drawing.Point(1082, 478);
            this.textBox5.MaxLength = 49;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(72, 27);
            this.textBox5.TabIndex = 273;
            this.textBox5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox5.Visible = false;
            // 
            // txD42
            // 
            this.txD42.BackColor = System.Drawing.Color.White;
            this.txD42.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txD42.ForeColor = System.Drawing.Color.Red;
            this.txD42.Location = new System.Drawing.Point(1345, 241);
            this.txD42.MaxLength = 49;
            this.txD42.Name = "txD42";
            this.txD42.Size = new System.Drawing.Size(131, 27);
            this.txD42.TabIndex = 181;
            this.txD42.Text = "37.5";
            this.txD42.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txD42.TextChanged += new System.EventHandler(this.TOTamnt_TextChanged);
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.Color.PaleGreen;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.optNo);
            this.panel4.Controls.Add(this.optYes);
            this.panel4.Location = new System.Drawing.Point(1188, 241);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(157, 27);
            this.panel4.TabIndex = 180;
            // 
            // optNo
            // 
            this.optNo.AutoSize = true;
            this.optNo.Checked = true;
            this.optNo.Location = new System.Drawing.Point(94, 2);
            this.optNo.Name = "optNo";
            this.optNo.Size = new System.Drawing.Size(47, 21);
            this.optNo.TabIndex = 180;
            this.optNo.TabStop = true;
            this.optNo.Text = "No";
            this.optNo.UseVisualStyleBackColor = true;
            this.optNo.CheckedChanged += new System.EventHandler(this.optNo_CheckedChanged);
            // 
            // optYes
            // 
            this.optYes.AutoSize = true;
            this.optYes.Location = new System.Drawing.Point(19, 2);
            this.optYes.Name = "optYes";
            this.optYes.Size = new System.Drawing.Size(53, 21);
            this.optYes.TabIndex = 179;
            this.optYes.Text = "Yes";
            this.optYes.UseVisualStyleBackColor = true;
            this.optYes.CheckedChanged += new System.EventHandler(this.optYes_CheckedChanged);
            // 
            // textBox21
            // 
            this.textBox21.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox21.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox21.ForeColor = System.Drawing.Color.Black;
            this.textBox21.Location = new System.Drawing.Point(853, 241);
            this.textBox21.MaxLength = 49;
            this.textBox21.Multiline = true;
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(335, 27);
            this.textBox21.TabIndex = 178;
            this.textBox21.Text = "Agent";
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // up6
            // 
            this.up6.BackColor = System.Drawing.Color.PaleGreen;
            this.up6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.up6.ForeColor = System.Drawing.Color.Black;
            this.up6.Location = new System.Drawing.Point(1260, 208);
            this.up6.MaxLength = 49;
            this.up6.Name = "up6";
            this.up6.ReadOnly = true;
            this.up6.Size = new System.Drawing.Size(85, 27);
            this.up6.TabIndex = 177;
            this.up6.Text = "75";
            this.up6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox18
            // 
            this.textBox18.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox18.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox18.ForeColor = System.Drawing.Color.Black;
            this.textBox18.Location = new System.Drawing.Point(853, 208);
            this.textBox18.MaxLength = 49;
            this.textBox18.Multiline = true;
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(335, 26);
            this.textBox18.TabIndex = 174;
            this.textBox18.Text = "Invoicing";
            this.textBox18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Amnt6
            // 
            this.Amnt6.BackColor = System.Drawing.Color.PaleGreen;
            this.Amnt6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amnt6.ForeColor = System.Drawing.Color.Black;
            this.Amnt6.Location = new System.Drawing.Point(1345, 208);
            this.Amnt6.MaxLength = 49;
            this.Amnt6.Name = "Amnt6";
            this.Amnt6.ReadOnly = true;
            this.Amnt6.Size = new System.Drawing.Size(131, 27);
            this.Amnt6.TabIndex = 175;
            this.Amnt6.Text = "37.5";
            this.Amnt6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hh6
            // 
            this.hh6.BackColor = System.Drawing.Color.White;
            this.hh6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh6.ForeColor = System.Drawing.Color.Black;
            this.hh6.Location = new System.Drawing.Point(1188, 208);
            this.hh6.MaxLength = 49;
            this.hh6.Name = "hh6";
            this.hh6.Size = new System.Drawing.Size(72, 27);
            this.hh6.TabIndex = 176;
            this.hh6.Text = "0.5";
            this.hh6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hh6.TextChanged += new System.EventHandler(this.hh6_TextChanged);
            // 
            // up5
            // 
            this.up5.BackColor = System.Drawing.Color.PaleGreen;
            this.up5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.up5.ForeColor = System.Drawing.Color.Black;
            this.up5.Location = new System.Drawing.Point(1260, 173);
            this.up5.MaxLength = 49;
            this.up5.Name = "up5";
            this.up5.ReadOnly = true;
            this.up5.Size = new System.Drawing.Size(86, 27);
            this.up5.TabIndex = 173;
            this.up5.Text = "65";
            this.up5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox14
            // 
            this.textBox14.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.ForeColor = System.Drawing.Color.Black;
            this.textBox14.Location = new System.Drawing.Point(853, 173);
            this.textBox14.MaxLength = 49;
            this.textBox14.Multiline = true;
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(335, 27);
            this.textBox14.TabIndex = 170;
            this.textBox14.Text = "Receiving quality C. packag. & shipping";
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Amnt5
            // 
            this.Amnt5.BackColor = System.Drawing.Color.PaleGreen;
            this.Amnt5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amnt5.ForeColor = System.Drawing.Color.Black;
            this.Amnt5.Location = new System.Drawing.Point(1346, 173);
            this.Amnt5.MaxLength = 49;
            this.Amnt5.Name = "Amnt5";
            this.Amnt5.ReadOnly = true;
            this.Amnt5.Size = new System.Drawing.Size(131, 27);
            this.Amnt5.TabIndex = 171;
            this.Amnt5.Text = "130";
            this.Amnt5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hh5
            // 
            this.hh5.BackColor = System.Drawing.Color.White;
            this.hh5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh5.ForeColor = System.Drawing.Color.Black;
            this.hh5.Location = new System.Drawing.Point(1188, 173);
            this.hh5.MaxLength = 49;
            this.hh5.Name = "hh5";
            this.hh5.Size = new System.Drawing.Size(72, 27);
            this.hh5.TabIndex = 172;
            this.hh5.Text = "2";
            this.hh5.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hh5.TextChanged += new System.EventHandler(this.hh5_TextChanged);
            // 
            // up4
            // 
            this.up4.BackColor = System.Drawing.Color.PaleGreen;
            this.up4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.up4.ForeColor = System.Drawing.Color.Black;
            this.up4.Location = new System.Drawing.Point(1260, 138);
            this.up4.MaxLength = 49;
            this.up4.Name = "up4";
            this.up4.ReadOnly = true;
            this.up4.Size = new System.Drawing.Size(85, 27);
            this.up4.TabIndex = 169;
            this.up4.Text = "100";
            this.up4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.ForeColor = System.Drawing.Color.Black;
            this.textBox10.Location = new System.Drawing.Point(853, 138);
            this.textBox10.MaxLength = 49;
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(335, 27);
            this.textBox10.TabIndex = 166;
            this.textBox10.Text = "HO PO and follow up";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Amnt4
            // 
            this.Amnt4.BackColor = System.Drawing.Color.PaleGreen;
            this.Amnt4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amnt4.ForeColor = System.Drawing.Color.Black;
            this.Amnt4.Location = new System.Drawing.Point(1345, 138);
            this.Amnt4.MaxLength = 49;
            this.Amnt4.Name = "Amnt4";
            this.Amnt4.ReadOnly = true;
            this.Amnt4.Size = new System.Drawing.Size(131, 27);
            this.Amnt4.TabIndex = 167;
            this.Amnt4.Text = "100";
            this.Amnt4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hh4
            // 
            this.hh4.BackColor = System.Drawing.Color.White;
            this.hh4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh4.ForeColor = System.Drawing.Color.Black;
            this.hh4.Location = new System.Drawing.Point(1188, 138);
            this.hh4.MaxLength = 49;
            this.hh4.Name = "hh4";
            this.hh4.Size = new System.Drawing.Size(72, 27);
            this.hh4.TabIndex = 168;
            this.hh4.Text = "1";
            this.hh4.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hh4.TextChanged += new System.EventHandler(this.hh4_TextChanged);
            // 
            // up2
            // 
            this.up2.BackColor = System.Drawing.Color.PaleGreen;
            this.up2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.up2.ForeColor = System.Drawing.Color.Black;
            this.up2.Location = new System.Drawing.Point(1260, 69);
            this.up2.MaxLength = 49;
            this.up2.Name = "up2";
            this.up2.ReadOnly = true;
            this.up2.Size = new System.Drawing.Size(86, 27);
            this.up2.TabIndex = 165;
            this.up2.Text = "120";
            this.up2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.up2.TextChanged += new System.EventHandler(this.up2_TextChanged);
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.ForeColor = System.Drawing.Color.Black;
            this.textBox6.Location = new System.Drawing.Point(853, 69);
            this.textBox6.MaxLength = 49;
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(335, 27);
            this.textBox6.TabIndex = 162;
            this.textBox6.Text = "Engineering";
            this.textBox6.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // Amnt2
            // 
            this.Amnt2.BackColor = System.Drawing.Color.PaleGreen;
            this.Amnt2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amnt2.ForeColor = System.Drawing.Color.Black;
            this.Amnt2.Location = new System.Drawing.Point(1346, 69);
            this.Amnt2.MaxLength = 49;
            this.Amnt2.Name = "Amnt2";
            this.Amnt2.ReadOnly = true;
            this.Amnt2.Size = new System.Drawing.Size(131, 27);
            this.Amnt2.TabIndex = 163;
            this.Amnt2.Text = "120";
            this.Amnt2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hh2
            // 
            this.hh2.BackColor = System.Drawing.Color.White;
            this.hh2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh2.ForeColor = System.Drawing.Color.Black;
            this.hh2.Location = new System.Drawing.Point(1188, 69);
            this.hh2.MaxLength = 49;
            this.hh2.Name = "hh2";
            this.hh2.Size = new System.Drawing.Size(72, 27);
            this.hh2.TabIndex = 164;
            this.hh2.Text = "2";
            this.hh2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hh2.TextChanged += new System.EventHandler(this.hh2_TextChanged);
            // 
            // up1
            // 
            this.up1.BackColor = System.Drawing.Color.PaleGreen;
            this.up1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.up1.ForeColor = System.Drawing.Color.Black;
            this.up1.Location = new System.Drawing.Point(1260, 35);
            this.up1.MaxLength = 49;
            this.up1.Name = "up1";
            this.up1.ReadOnly = true;
            this.up1.Size = new System.Drawing.Size(86, 27);
            this.up1.TabIndex = 160;
            this.up1.Text = "100";
            this.up1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.up1.TextChanged += new System.EventHandler(this.up1_TextChanged);
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.PaleGreen;
            this.textBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(853, 35);
            this.textBox2.MaxLength = 49;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(335, 26);
            this.textBox2.TabIndex = 152;
            this.textBox2.Text = "Quotation+ supplier quote and negotiation";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label12.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(1270, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(76, 18);
            this.label12.TabIndex = 161;
            this.label12.Text = "U.Price";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label14.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(1354, 15);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(116, 18);
            this.label14.TabIndex = 159;
            this.label14.Text = "Amount";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Amnt1
            // 
            this.Amnt1.BackColor = System.Drawing.Color.PaleGreen;
            this.Amnt1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Amnt1.ForeColor = System.Drawing.Color.Black;
            this.Amnt1.Location = new System.Drawing.Point(1346, 35);
            this.Amnt1.MaxLength = 49;
            this.Amnt1.Name = "Amnt1";
            this.Amnt1.ReadOnly = true;
            this.Amnt1.Size = new System.Drawing.Size(131, 27);
            this.Amnt1.TabIndex = 154;
            this.Amnt1.Text = "100";
            this.Amnt1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // hh1
            // 
            this.hh1.BackColor = System.Drawing.Color.White;
            this.hh1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.hh1.ForeColor = System.Drawing.Color.Black;
            this.hh1.Location = new System.Drawing.Point(1188, 35);
            this.hh1.MaxLength = 49;
            this.hh1.Name = "hh1";
            this.hh1.Size = new System.Drawing.Size(72, 27);
            this.hh1.TabIndex = 157;
            this.hh1.Text = "1";
            this.hh1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.hh1.TextChanged += new System.EventHandler(this.hh1_TextChanged);
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(1177, 15);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(93, 18);
            this.label16.TabIndex = 158;
            this.label16.Text = "Hours";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel6
            // 
            this.panel6.Controls.Add(this.tIName);
            this.panel6.Controls.Add(this.panel5);
            this.panel6.Controls.Add(this.opt_withmult);
            this.panel6.Controls.Add(this.tIModel);
            this.panel6.Controls.Add(this.opt_NOmult);
            this.panel6.Controls.Add(this.label48);
            this.panel6.Controls.Add(this.btnCancel);
            this.panel6.Controls.Add(this.ll);
            this.panel6.Controls.Add(this.btnOK);
            this.panel6.Controls.Add(this.tIf2);
            this.panel6.Controls.Add(this.tIf1);
            this.panel6.Controls.Add(this.lOpt);
            this.panel6.Controls.Add(this.panel1);
            this.panel6.Controls.Add(this.label2);
            this.panel6.Controls.Add(this.label5);
            this.panel6.Controls.Add(this.label6);
            this.panel6.Controls.Add(this.tIdim);
            this.panel6.Controls.Add(this.textBox3);
            this.panel6.Controls.Add(this.textBox8);
            this.panel6.Location = new System.Drawing.Point(7, 485);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1489, 175);
            this.panel6.TabIndex = 373;
            // 
            // tIName
            // 
            this.tIName.BackColor = System.Drawing.Color.LemonChiffon;
            this.tIName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tIName.Location = new System.Drawing.Point(836, 7);
            this.tIName.MaxLength = 49;
            this.tIName.Name = "tIName";
            this.tIName.Size = new System.Drawing.Size(597, 22);
            this.tIName.TabIndex = 0;
            this.tIName.TextChanged += new System.EventHandler(this.tIName_TextChanged);
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel5.Controls.Add(this.cal_multipl);
            this.panel5.Controls.Add(this.label17);
            this.panel5.Controls.Add(this.label1);
            this.panel5.Controls.Add(this.cal_ext);
            this.panel5.Controls.Add(this.label8);
            this.panel5.Controls.Add(this.cal_qty);
            this.panel5.Controls.Add(this.label11);
            this.panel5.Controls.Add(this.cal_pu);
            this.panel5.Controls.Add(this.label13);
            this.panel5.Controls.Add(this.label15);
            this.panel5.Controls.Add(this.textBox25);
            this.panel5.Location = new System.Drawing.Point(43, 18);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(605, 66);
            this.panel5.TabIndex = 370;
            // 
            // cal_multipl
            // 
            this.cal_multipl.BackColor = System.Drawing.Color.Red;
            this.cal_multipl.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cal_multipl.ForeColor = System.Drawing.Color.White;
            this.cal_multipl.Location = new System.Drawing.Point(241, 21);
            this.cal_multipl.MaxLength = 49;
            this.cal_multipl.Name = "cal_multipl";
            this.cal_multipl.ReadOnly = true;
            this.cal_multipl.Size = new System.Drawing.Size(121, 32);
            this.cal_multipl.TabIndex = 171;
            this.cal_multipl.Text = "1";
            this.cal_multipl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cal_multipl.TextChanged += new System.EventHandler(this.cal_multipl_TextChanged);
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.LemonChiffon;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(270, -2);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(103, 18);
            this.label17.TabIndex = 172;
            this.label17.Text = "Multiplier";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.LemonChiffon;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(104, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 18);
            this.label1.TabIndex = 170;
            this.label1.Text = "CDN $";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cal_ext
            // 
            this.cal_ext.BackColor = System.Drawing.Color.Red;
            this.cal_ext.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cal_ext.ForeColor = System.Drawing.Color.White;
            this.cal_ext.Location = new System.Drawing.Point(370, 21);
            this.cal_ext.MaxLength = 49;
            this.cal_ext.Name = "cal_ext";
            this.cal_ext.ReadOnly = true;
            this.cal_ext.Size = new System.Drawing.Size(220, 32);
            this.cal_ext.TabIndex = 160;
            this.cal_ext.Text = "0";
            this.cal_ext.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.LemonChiffon;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(433, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(108, 18);
            this.label8.TabIndex = 161;
            this.label8.Text = "Extension";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cal_qty
            // 
            this.cal_qty.BackColor = System.Drawing.Color.Red;
            this.cal_qty.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cal_qty.ForeColor = System.Drawing.Color.White;
            this.cal_qty.Location = new System.Drawing.Point(157, 21);
            this.cal_qty.MaxLength = 49;
            this.cal_qty.Name = "cal_qty";
            this.cal_qty.Size = new System.Drawing.Size(77, 32);
            this.cal_qty.TabIndex = 153;
            this.cal_qty.Text = "1";
            this.cal_qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cal_qty.TextChanged += new System.EventHandler(this.cal_qty_TextChanged);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.LemonChiffon;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(1, -1);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(108, 18);
            this.label11.TabIndex = 155;
            this.label11.Text = "Unit Cost /";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cal_pu
            // 
            this.cal_pu.BackColor = System.Drawing.Color.Red;
            this.cal_pu.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cal_pu.ForeColor = System.Drawing.Color.White;
            this.cal_pu.Location = new System.Drawing.Point(4, 21);
            this.cal_pu.MaxLength = 49;
            this.cal_pu.Name = "cal_pu";
            this.cal_pu.ReadOnly = true;
            this.cal_pu.Size = new System.Drawing.Size(146, 32);
            this.cal_pu.TabIndex = 152;
            this.cal_pu.Text = "0";
            this.cal_pu.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cal_pu.TextChanged += new System.EventHandler(this.cal_pu_TextChanged);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.Wheat;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(492, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(116, 18);
            this.label13.TabIndex = 159;
            this.label13.Text = "Lead Time";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.Visible = false;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.LemonChiffon;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label15.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(184, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(46, 18);
            this.label15.TabIndex = 156;
            this.label15.Text = "Qty";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox25
            // 
            this.textBox25.BackColor = System.Drawing.Color.White;
            this.textBox25.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox25.ForeColor = System.Drawing.Color.Black;
            this.textBox25.Location = new System.Drawing.Point(616, 74);
            this.textBox25.MaxLength = 49;
            this.textBox25.Name = "textBox25";
            this.textBox25.Size = new System.Drawing.Size(111, 32);
            this.textBox25.TabIndex = 154;
            this.textBox25.Text = "04-06";
            this.textBox25.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox25.Visible = false;
            // 
            // opt_withmult
            // 
            this.opt_withmult.AutoSize = true;
            this.opt_withmult.Checked = true;
            this.opt_withmult.Location = new System.Drawing.Point(1453, 129);
            this.opt_withmult.Name = "opt_withmult";
            this.opt_withmult.Size = new System.Drawing.Size(17, 16);
            this.opt_withmult.TabIndex = 372;
            this.opt_withmult.TabStop = true;
            this.opt_withmult.UseVisualStyleBackColor = true;
            this.opt_withmult.Visible = false;
            // 
            // tIModel
            // 
            this.tIModel.BackColor = System.Drawing.Color.LemonChiffon;
            this.tIModel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tIModel.Location = new System.Drawing.Point(836, 37);
            this.tIModel.MaxLength = 49;
            this.tIModel.Name = "tIModel";
            this.tIModel.Size = new System.Drawing.Size(597, 22);
            this.tIModel.TabIndex = 1;
            // 
            // opt_NOmult
            // 
            this.opt_NOmult.AutoSize = true;
            this.opt_NOmult.Location = new System.Drawing.Point(522, 310);
            this.opt_NOmult.Name = "opt_NOmult";
            this.opt_NOmult.Size = new System.Drawing.Size(17, 16);
            this.opt_NOmult.TabIndex = 371;
            this.opt_NOmult.UseVisualStyleBackColor = true;
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.SystemColors.Control;
            this.label48.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label48.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label48.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label48.Location = new System.Drawing.Point(731, 39);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(105, 19);
            this.label48.TabIndex = 96;
            this.label48.Text = "Model :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Green;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(350, 98);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(186, 46);
            this.btnCancel.TabIndex = 142;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ll
            // 
            this.ll.BackColor = System.Drawing.SystemColors.Control;
            this.ll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ll.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ll.Location = new System.Drawing.Point(727, 9);
            this.ll.Name = "ll";
            this.ll.Size = new System.Drawing.Size(109, 24);
            this.ll.TabIndex = 128;
            this.ll.Text = "Item Name:";
            this.ll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Green;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(138, 98);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(186, 46);
            this.btnOK.TabIndex = 143;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tIf2
            // 
            this.tIf2.BackColor = System.Drawing.Color.LemonChiffon;
            this.tIf2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tIf2.Location = new System.Drawing.Point(836, 127);
            this.tIf2.MaxLength = 49;
            this.tIf2.Name = "tIf2";
            this.tIf2.Size = new System.Drawing.Size(597, 22);
            this.tIf2.TabIndex = 4;
            // 
            // tIf1
            // 
            this.tIf1.BackColor = System.Drawing.Color.LemonChiffon;
            this.tIf1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tIf1.Location = new System.Drawing.Point(836, 98);
            this.tIf1.MaxLength = 49;
            this.tIf1.Name = "tIf1";
            this.tIf1.Size = new System.Drawing.Size(597, 22);
            this.tIf1.TabIndex = 3;
            // 
            // lOpt
            // 
            this.lOpt.BackColor = System.Drawing.Color.PeachPuff;
            this.lOpt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lOpt.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lOpt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lOpt.Location = new System.Drawing.Point(1441, 67);
            this.lOpt.Name = "lOpt";
            this.lOpt.Size = new System.Drawing.Size(29, 23);
            this.lOpt.TabIndex = 264;
            this.lOpt.Text = "Q";
            this.lOpt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lOpt.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LemonChiffon;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.lcurDol);
            this.panel1.Controls.Add(this.tIExt);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.tIQty);
            this.panel1.Controls.Add(this.label42);
            this.panel1.Controls.Add(this.tIPU);
            this.panel1.Controls.Add(this.label34);
            this.panel1.Controls.Add(this.label38);
            this.panel1.Controls.Add(this.tILT);
            this.panel1.Location = new System.Drawing.Point(550, 280);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(604, 66);
            this.panel1.TabIndex = 173;
            this.panel1.Visible = false;
            // 
            // lcurDol
            // 
            this.lcurDol.BackColor = System.Drawing.Color.LemonChiffon;
            this.lcurDol.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lcurDol.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcurDol.ForeColor = System.Drawing.Color.Black;
            this.lcurDol.Location = new System.Drawing.Point(104, 0);
            this.lcurDol.Name = "lcurDol";
            this.lcurDol.Size = new System.Drawing.Size(64, 18);
            this.lcurDol.TabIndex = 170;
            this.lcurDol.Text = "CDN $";
            this.lcurDol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tIExt
            // 
            this.tIExt.BackColor = System.Drawing.Color.Green;
            this.tIExt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIExt.ForeColor = System.Drawing.Color.White;
            this.tIExt.Location = new System.Drawing.Point(307, 21);
            this.tIExt.MaxLength = 49;
            this.tIExt.Name = "tIExt";
            this.tIExt.ReadOnly = true;
            this.tIExt.Size = new System.Drawing.Size(283, 32);
            this.tIExt.TabIndex = 160;
            this.tIExt.Text = "0";
            this.tIExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tIExt.TextChanged += new System.EventHandler(this.tIExt_TextChanged);
            this.tIExt.DoubleClick += new System.EventHandler(this.tIExt_DoubleClick);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.LemonChiffon;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(374, -1);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 18);
            this.label4.TabIndex = 161;
            this.label4.Text = "Extension";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tIQty
            // 
            this.tIQty.BackColor = System.Drawing.Color.Green;
            this.tIQty.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIQty.ForeColor = System.Drawing.Color.White;
            this.tIQty.Location = new System.Drawing.Point(223, 21);
            this.tIQty.MaxLength = 49;
            this.tIQty.Name = "tIQty";
            this.tIQty.Size = new System.Drawing.Size(77, 32);
            this.tIQty.TabIndex = 153;
            this.tIQty.Text = "1";
            this.tIQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tIQty.TextChanged += new System.EventHandler(this.tIQty_TextChanged);
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.LemonChiffon;
            this.label42.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label42.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label42.Location = new System.Drawing.Point(1, -1);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(108, 18);
            this.label42.TabIndex = 155;
            this.label42.Text = "Unit Cost /";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tIPU
            // 
            this.tIPU.BackColor = System.Drawing.Color.Green;
            this.tIPU.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIPU.ForeColor = System.Drawing.Color.White;
            this.tIPU.Location = new System.Drawing.Point(4, 21);
            this.tIPU.MaxLength = 49;
            this.tIPU.Name = "tIPU";
            this.tIPU.ReadOnly = true;
            this.tIPU.Size = new System.Drawing.Size(212, 32);
            this.tIPU.TabIndex = 152;
            this.tIPU.Text = "0";
            this.tIPU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tIPU.TextChanged += new System.EventHandler(this.tIPU_TextChanged);
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.Color.Wheat;
            this.label34.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label34.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(492, 82);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(116, 18);
            this.label34.TabIndex = 159;
            this.label34.Text = "Lead Time";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label34.Visible = false;
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.Color.LemonChiffon;
            this.label38.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label38.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label38.Location = new System.Drawing.Point(242, -1);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(47, 18);
            this.label38.TabIndex = 156;
            this.label38.Text = "Qty";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tILT
            // 
            this.tILT.BackColor = System.Drawing.Color.White;
            this.tILT.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tILT.ForeColor = System.Drawing.Color.Black;
            this.tILT.Location = new System.Drawing.Point(616, 74);
            this.tILT.MaxLength = 49;
            this.tILT.Name = "tILT";
            this.tILT.Size = new System.Drawing.Size(111, 32);
            this.tILT.TabIndex = 154;
            this.tILT.Text = "04-06";
            this.tILT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tILT.Visible = false;
            this.tILT.TextChanged += new System.EventHandler(this.tILT_TextChanged_1);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(721, 70);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 19);
            this.label2.TabIndex = 170;
            this.label2.Text = "Dimensions:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(755, 100);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 19);
            this.label5.TabIndex = 171;
            this.label5.Text = "Line #1:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(755, 129);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(81, 19);
            this.label6.TabIndex = 172;
            this.label6.Text = "Line #2:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tIdim
            // 
            this.tIdim.BackColor = System.Drawing.Color.LemonChiffon;
            this.tIdim.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tIdim.Location = new System.Drawing.Point(836, 68);
            this.tIdim.MaxLength = 49;
            this.tIdim.Name = "tIdim";
            this.tIdim.Size = new System.Drawing.Size(597, 22);
            this.tIdim.TabIndex = 2;
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.SkyBlue;
            this.textBox3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.textBox3.Location = new System.Drawing.Point(1357, 195);
            this.textBox3.MaxLength = 49;
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(95, 27);
            this.textBox3.TabIndex = 271;
            this.textBox3.Text = "US$  COST";
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox3.Visible = false;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.Coral;
            this.textBox8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.ForeColor = System.Drawing.Color.Black;
            this.textBox8.Location = new System.Drawing.Point(1357, 222);
            this.textBox8.MaxLength = 49;
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(95, 26);
            this.textBox8.TabIndex = 275;
            this.textBox8.Text = "C$  COST";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textBox8.Visible = false;
            // 
            // picON
            // 
            this.picON.BackColor = System.Drawing.Color.Transparent;
            this.picON.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picON.Image = ((System.Drawing.Image)(resources.GetObject("picON.Image")));
            this.picON.Location = new System.Drawing.Point(79, 437);
            this.picON.Name = "picON";
            this.picON.Size = new System.Drawing.Size(49, 44);
            this.picON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picON.TabIndex = 366;
            this.picON.TabStop = false;
            this.picON.Visible = false;
            this.picON.Click += new System.EventHandler(this.picON_Click);
            // 
            // tINotes_OLD
            // 
            this.tINotes_OLD.BackColor = System.Drawing.Color.Black;
            this.tINotes_OLD.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tINotes_OLD.ForeColor = System.Drawing.Color.White;
            this.tINotes_OLD.Location = new System.Drawing.Point(30, 515);
            this.tINotes_OLD.Name = "tINotes_OLD";
            this.tINotes_OLD.Size = new System.Drawing.Size(457, 23);
            this.tINotes_OLD.TabIndex = 265;
            this.tINotes_OLD.Visible = false;
            // 
            // lQTy
            // 
            this.lQTy.BackColor = System.Drawing.Color.PeachPuff;
            this.lQTy.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lQTy.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lQTy.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lQTy.Location = new System.Drawing.Point(142, 487);
            this.lQTy.Name = "lQTy";
            this.lQTy.Size = new System.Drawing.Size(237, 23);
            this.lQTy.TabIndex = 263;
            this.lQTy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lQTy.Visible = false;
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.Lavender;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newitm,
            this.addBatt,
            this.cancel,
            this.NewST,
            this.delitm,
            this.tlsOFF,
            this.tlsON,
            this.toolStripButton1,
            this._exit});
            this.toolStrip1.Location = new System.Drawing.Point(3, 18);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1606, 59);
            this.toolStrip1.TabIndex = 261;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // newitm
            // 
            this.newitm.Image = ((System.Drawing.Image)(resources.GetObject("newitm.Image")));
            this.newitm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newitm.Name = "newitm";
            this.newitm.Size = new System.Drawing.Size(77, 56);
            this.newitm.Text = "New Item";
            this.newitm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.newitm.ToolTipText = "delete test";
            this.newitm.Click += new System.EventHandler(this.newitm_Click);
            // 
            // addBatt
            // 
            this.addBatt.Image = ((System.Drawing.Image)(resources.GetObject("addBatt.Image")));
            this.addBatt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addBatt.Name = "addBatt";
            this.addBatt.Size = new System.Drawing.Size(103, 56);
            this.addBatt.Text = "Add Batteries";
            this.addBatt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addBatt.Click += new System.EventHandler(this.addBatt_Click);
            // 
            // cancel
            // 
            this.cancel.Image = ((System.Drawing.Image)(resources.GetObject("cancel.Image")));
            this.cancel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.cancel.Name = "cancel";
            this.cancel.Size = new System.Drawing.Size(57, 56);
            this.cancel.Text = "Cancel";
            this.cancel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.cancel.Visible = false;
            this.cancel.Click += new System.EventHandler(this.cancel_Click);
            // 
            // NewST
            // 
            this.NewST.Image = ((System.Drawing.Image)(resources.GetObject("NewST.Image")));
            this.NewST.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewST.Name = "NewST";
            this.NewST.Size = new System.Drawing.Size(78, 56);
            this.NewST.Text = "Save Item";
            this.NewST.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NewST.ToolTipText = "New STEP by STEP";
            this.NewST.Visible = false;
            this.NewST.Click += new System.EventHandler(this.NewST_Click);
            // 
            // delitm
            // 
            this.delitm.Image = ((System.Drawing.Image)(resources.GetObject("delitm.Image")));
            this.delitm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.delitm.Name = "delitm";
            this.delitm.Size = new System.Drawing.Size(156, 56);
            this.delitm.Text = "Delete selected Items";
            this.delitm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.delitm.ToolTipText = "save ";
            this.delitm.Visible = false;
            this.delitm.Click += new System.EventHandler(this.delitm_Click);
            // 
            // tlsOFF
            // 
            this.tlsOFF.Image = ((System.Drawing.Image)(resources.GetObject("tlsOFF.Image")));
            this.tlsOFF.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsOFF.Name = "tlsOFF";
            this.tlsOFF.Size = new System.Drawing.Size(164, 56);
            this.tlsOFF.Text = "Calculation is Disabled";
            this.tlsOFF.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsOFF.Visible = false;
            this.tlsOFF.Click += new System.EventHandler(this.tlsOFF_Click);
            // 
            // tlsON
            // 
            this.tlsON.Image = ((System.Drawing.Image)(resources.GetObject("tlsON.Image")));
            this.tlsON.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsON.Name = "tlsON";
            this.tlsON.Size = new System.Drawing.Size(159, 56);
            this.tlsON.Text = "Calculation is Enabled";
            this.tlsON.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsON.Visible = false;
            this.tlsON.Click += new System.EventHandler(this.tlsON_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(62, 56);
            this.toolStripButton1.Text = "Refresh";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // _exit
            // 
            this._exit.Image = ((System.Drawing.Image)(resources.GetObject("_exit.Image")));
            this._exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(61, 56);
            this._exit.Text = "   Exit   ";
            this._exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._exit.Click += new System.EventHandler(this._exit_Click);
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.optuser);
            this.panel3.Controls.Add(this.optALL);
            this.panel3.Controls.Add(this.optQNB);
            this.panel3.Location = new System.Drawing.Point(30, 542);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(457, 30);
            this.panel3.TabIndex = 184;
            this.panel3.Visible = false;
            // 
            // optuser
            // 
            this.optuser.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.optuser.ForeColor = System.Drawing.Color.Blue;
            this.optuser.Location = new System.Drawing.Point(121, 2);
            this.optuser.Name = "optuser";
            this.optuser.Size = new System.Drawing.Size(101, 23);
            this.optuser.TabIndex = 184;
            this.optuser.Text = "user: ";
            this.optuser.CheckedChanged += new System.EventHandler(this.optuser_CheckedChanged);
            // 
            // optALL
            // 
            this.optALL.Font = new System.Drawing.Font("Verdana", 9.75F);
            this.optALL.ForeColor = System.Drawing.Color.Blue;
            this.optALL.Location = new System.Drawing.Point(222, 2);
            this.optALL.Name = "optALL";
            this.optALL.Size = new System.Drawing.Size(122, 23);
            this.optALL.TabIndex = 183;
            this.optALL.Text = "All Quotes";
            this.optALL.CheckedChanged += new System.EventHandler(this.optALL_CheckedChanged);
            // 
            // optQNB
            // 
            this.optQNB.Checked = true;
            this.optQNB.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.optQNB.ForeColor = System.Drawing.Color.Blue;
            this.optQNB.Location = new System.Drawing.Point(7, 2);
            this.optQNB.Name = "optQNB";
            this.optQNB.Size = new System.Drawing.Size(114, 23);
            this.optQNB.TabIndex = 182;
            this.optQNB.TabStop = true;
            this.optQNB.Text = "quote#: ";
            this.optQNB.CheckedChanged += new System.EventHandler(this.optQNB_CheckedChanged);
            // 
            // btnbrowse
            // 
            this.btnbrowse.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnbrowse.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbrowse.Location = new System.Drawing.Point(451, 432);
            this.btnbrowse.Name = "btnbrowse";
            this.btnbrowse.Size = new System.Drawing.Size(41, 23);
            this.btnbrowse.TabIndex = 180;
            this.btnbrowse.Text = "-";
            this.btnbrowse.Visible = false;
            this.btnbrowse.Click += new System.EventHandler(this.btnbrowse_Click);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.LightSkyBlue;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(343, 463);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 18);
            this.label7.TabIndex = 175;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.AliceBlue;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.opEuro);
            this.panel2.Controls.Add(this.opUS);
            this.panel2.Controls.Add(this.opCan);
            this.panel2.Location = new System.Drawing.Point(79, 389);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 31);
            this.panel2.TabIndex = 174;
            this.panel2.Visible = false;
            // 
            // opEuro
            // 
            this.opEuro.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opEuro.ForeColor = System.Drawing.Color.DarkRed;
            this.opEuro.Location = new System.Drawing.Point(161, 3);
            this.opEuro.Name = "opEuro";
            this.opEuro.Size = new System.Drawing.Size(77, 18);
            this.opEuro.TabIndex = 108;
            this.opEuro.Text = "EURO €";
            this.opEuro.CheckedChanged += new System.EventHandler(this.opEuro_CheckedChanged);
            // 
            // opUS
            // 
            this.opUS.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opUS.ForeColor = System.Drawing.Color.DarkRed;
            this.opUS.Location = new System.Drawing.Point(84, 3);
            this.opUS.Name = "opUS";
            this.opUS.Size = new System.Drawing.Size(77, 18);
            this.opUS.TabIndex = 107;
            this.opUS.Text = "USD";
            this.opUS.CheckedChanged += new System.EventHandler(this.opUS_CheckedChanged);
            // 
            // opCan
            // 
            this.opCan.Checked = true;
            this.opCan.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opCan.ForeColor = System.Drawing.Color.DarkRed;
            this.opCan.Location = new System.Drawing.Point(7, 3);
            this.opCan.Name = "opCan";
            this.opCan.Size = new System.Drawing.Size(77, 18);
            this.opCan.TabIndex = 106;
            this.opCan.TabStop = true;
            this.opCan.Text = "CAD";
            this.opCan.CheckedChanged += new System.EventHandler(this.opCan_CheckedChanged);
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.Color.AliceBlue;
            this.label57.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label57.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label57.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label57.Location = new System.Drawing.Point(328, 395);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(81, 18);
            this.label57.TabIndex = 168;
            this.label57.Text = "Currency:";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label57.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Coral;
            this.groupBox1.Controls.Add(this.chkAuto);
            this.groupBox1.Controls.Add(this.lIotherF);
            this.groupBox1.Controls.Add(this.tIotherF);
            this.groupBox1.Controls.Add(this.chk1);
            this.groupBox1.Controls.Add(this.chk2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.lsave);
            this.groupBox1.Controls.Add(this.chkM);
            this.groupBox1.Controls.Add(this.chkD);
            this.groupBox1.Controls.Add(this.tSMRK);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.lif2);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.not);
            this.groupBox1.Controls.Add(this.picSeek);
            this.groupBox1.Controls.Add(this.lif1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(276, 667);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(91, 68);
            this.groupBox1.TabIndex = 159;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // chkAuto
            // 
            this.chkAuto.Checked = true;
            this.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuto.Location = new System.Drawing.Point(449, -135);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(55, 27);
            this.chkAuto.TabIndex = 164;
            this.chkAuto.Text = "Auto Sell  Price";
            this.chkAuto.Visible = false;
            this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
            // 
            // lIotherF
            // 
            this.lIotherF.BackColor = System.Drawing.Color.Lavender;
            this.lIotherF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lIotherF.Location = new System.Drawing.Point(58, 22);
            this.lIotherF.MaxLength = 49;
            this.lIotherF.Name = "lIotherF";
            this.lIotherF.Size = new System.Drawing.Size(105, 22);
            this.lIotherF.TabIndex = 148;
            // 
            // tIotherF
            // 
            this.tIotherF.BackColor = System.Drawing.Color.Lavender;
            this.tIotherF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tIotherF.Location = new System.Drawing.Point(187, 110);
            this.tIotherF.MaxLength = 1000;
            this.tIotherF.Multiline = true;
            this.tIotherF.Name = "tIotherF";
            this.tIotherF.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tIotherF.Size = new System.Drawing.Size(57, 22);
            this.tIotherF.TabIndex = 145;
            this.tIotherF.TextChanged += new System.EventHandler(this.tIotherF_TextChanged);
            // 
            // chk1
            // 
            this.chk1.Checked = true;
            this.chk1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk1.Location = new System.Drawing.Point(10, 93);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(48, 19);
            this.chk1.TabIndex = 156;
            this.chk1.Text = "#1";
            // 
            // chk2
            // 
            this.chk2.Checked = true;
            this.chk2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk2.Location = new System.Drawing.Point(10, 117);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(48, 18);
            this.chk2.TabIndex = 157;
            this.chk2.Text = "#2";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.AliceBlue;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(445, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 16);
            this.label10.TabIndex = 178;
            this.label10.Text = "Empty Item";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(115, 45);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 18);
            this.checkBox1.TabIndex = 158;
            this.checkBox1.Tag = "";
            this.checkBox1.Text = "#3";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.AliceBlue;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(378, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 16);
            this.label9.TabIndex = 177;
            this.label9.Text = "Delete";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(232, 23);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 46);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 169;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // lsave
            // 
            this.lsave.BackColor = System.Drawing.Color.AliceBlue;
            this.lsave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lsave.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsave.ForeColor = System.Drawing.Color.Red;
            this.lsave.Location = new System.Drawing.Point(312, 84);
            this.lsave.Name = "lsave";
            this.lsave.Size = new System.Drawing.Size(47, 16);
            this.lsave.TabIndex = 176;
            this.lsave.Text = "Save";
            this.lsave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkM
            // 
            this.chkM.Checked = true;
            this.chkM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkM.Location = new System.Drawing.Point(10, 47);
            this.chkM.Name = "chkM";
            this.chkM.Size = new System.Drawing.Size(48, 19);
            this.chkM.TabIndex = 160;
            // 
            // chkD
            // 
            this.chkD.Checked = true;
            this.chkD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkD.Location = new System.Drawing.Point(10, 70);
            this.chkD.Name = "chkD";
            this.chkD.Size = new System.Drawing.Size(48, 19);
            this.chkD.TabIndex = 161;
            // 
            // tSMRK
            // 
            this.tSMRK.BackColor = System.Drawing.Color.Gainsboro;
            this.tSMRK.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSMRK.ForeColor = System.Drawing.Color.Black;
            this.tSMRK.Location = new System.Drawing.Point(211, 218);
            this.tSMRK.MaxLength = 49;
            this.tSMRK.Name = "tSMRK";
            this.tSMRK.ReadOnly = true;
            this.tSMRK.Size = new System.Drawing.Size(96, 32);
            this.tSMRK.TabIndex = 157;
            this.tSMRK.Text = "1";
            this.tSMRK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tSMRK.Visible = false;
            this.tSMRK.TextChanged += new System.EventHandler(this.tSMRK_TextChanged);
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.Wheat;
            this.label36.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label36.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label36.Location = new System.Drawing.Point(196, 200);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(122, 18);
            this.label36.TabIndex = 158;
            this.label36.Text = "Markup";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label36.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(144, 136);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(58, 23);
            this.btnClear.TabIndex = 162;
            this.btnClear.Text = "Clear";
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDel
            // 
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(211, 136);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(58, 23);
            this.btnDel.TabIndex = 152;
            this.btnDel.Text = "Delete";
            this.btnDel.Visible = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lif2
            // 
            this.lif2.BackColor = System.Drawing.Color.Lavender;
            this.lif2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lif2.Location = new System.Drawing.Point(180, 80);
            this.lif2.MaxLength = 49;
            this.lif2.Name = "lif2";
            this.lif2.Size = new System.Drawing.Size(86, 22);
            this.lif2.TabIndex = 134;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(382, 39);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 165;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(449, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 164;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // not
            // 
            this.not.BackColor = System.Drawing.Color.AliceBlue;
            this.not.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.not.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.not.ForeColor = System.Drawing.SystemColors.ControlText;
            this.not.Location = new System.Drawing.Point(120, 173);
            this.not.Name = "not";
            this.not.Size = new System.Drawing.Size(60, 19);
            this.not.TabIndex = 144;
            this.not.Text = "Notes:";
            this.not.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picSeek
            // 
            this.picSeek.BackColor = System.Drawing.Color.Transparent;
            this.picSeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSeek.Image = ((System.Drawing.Image)(resources.GetObject("picSeek.Image")));
            this.picSeek.Location = new System.Drawing.Point(319, 43);
            this.picSeek.Name = "picSeek";
            this.picSeek.Size = new System.Drawing.Size(40, 39);
            this.picSeek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSeek.TabIndex = 163;
            this.picSeek.TabStop = false;
            this.picSeek.Click += new System.EventHandler(this.picSeek_Click);
            this.picSeek.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSeek_MouseDown);
            // 
            // lif1
            // 
            this.lif1.BackColor = System.Drawing.Color.Lavender;
            this.lif1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lif1.Location = new System.Drawing.Point(17, 166);
            this.lif1.MaxLength = 49;
            this.lif1.Name = "lif1";
            this.lif1.Size = new System.Drawing.Size(86, 22);
            this.lif1.TabIndex = 132;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(36, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 37);
            this.label3.TabIndex = 126;
            this.label3.Text = "BUY &&  RESELL ITEM / OPTION";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(136, 437);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(87, 23);
            this.btnEdit.TabIndex = 153;
            this.btnEdit.Text = "import 1/1";
            this.btnEdit.Visible = false;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // tINotes
            // 
            this.tINotes.BackColor = System.Drawing.Color.AliceBlue;
            this.tINotes.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tINotes.ForeColor = System.Drawing.Color.Red;
            this.tINotes.Location = new System.Drawing.Point(28, 492);
            this.tINotes.Name = "tINotes";
            this.tINotes.Size = new System.Drawing.Size(459, 23);
            this.tINotes.TabIndex = 262;
            this.tINotes.Visible = false;
            // 
            // picOFF
            // 
            this.picOFF.BackColor = System.Drawing.Color.Transparent;
            this.picOFF.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picOFF.Image = ((System.Drawing.Image)(resources.GetObject("picOFF.Image")));
            this.picOFF.Location = new System.Drawing.Point(79, 436);
            this.picOFF.Name = "picOFF";
            this.picOFF.Size = new System.Drawing.Size(49, 44);
            this.picOFF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOFF.TabIndex = 367;
            this.picOFF.TabStop = false;
            this.picOFF.Visible = false;
            this.picOFF.Click += new System.EventHandler(this.picOFF_Click);
            // 
            // lvNLIO
            // 
            this.lvNLIO.BackColor = System.Drawing.Color.Bisque;
            this.lvNLIO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IOName,
            this.Model,
            this.Dim,
            this.F1,
            this.F2,
            this.OFt,
            this.qTTY,
            this.UP,
            this.Mult,
            this.Sprice,
            this.LT,
            this.note,
            this.usr,
            this.QID,
            this.LID});
            this.lvNLIO.ForeColor = System.Drawing.Color.Blue;
            this.lvNLIO.FullRowSelect = true;
            this.lvNLIO.GridLines = true;
            this.lvNLIO.HideSelection = false;
            this.lvNLIO.Location = new System.Drawing.Point(4, 18);
            this.lvNLIO.MultiSelect = false;
            this.lvNLIO.Name = "lvNLIO";
            this.lvNLIO.Size = new System.Drawing.Size(1492, 0);
            this.lvNLIO.TabIndex = 126;
            this.lvNLIO.UseCompatibleStateImageBehavior = false;
            this.lvNLIO.View = System.Windows.Forms.View.Details;
            this.lvNLIO.SelectedIndexChanged += new System.EventHandler(this.lvNLIO_SelectedIndexChanged_1);
            this.lvNLIO.DoubleClick += new System.EventHandler(this.lvNLIO_DoubleClick);
            // 
            // IOName
            // 
            this.IOName.Text = "Item/Option Name";
            this.IOName.Width = 249;
            // 
            // Model
            // 
            this.Model.Text = "Model";
            this.Model.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Model.Width = 236;
            // 
            // Dim
            // 
            this.Dim.Text = "Dimensions";
            this.Dim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Dim.Width = 187;
            // 
            // F1
            // 
            this.F1.Text = "#1";
            this.F1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.F1.Width = 170;
            // 
            // F2
            // 
            this.F2.Text = "#2";
            this.F2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.F2.Width = 129;
            // 
            // OFt
            // 
            this.OFt.Text = "#3";
            this.OFt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OFt.Width = 0;
            // 
            // qTTY
            // 
            this.qTTY.Text = "QTY";
            this.qTTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.qTTY.Width = 65;
            // 
            // UP
            // 
            this.UP.Text = "Unit Cost";
            this.UP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.UP.Width = 71;
            // 
            // Mult
            // 
            this.Mult.Text = "Markup";
            this.Mult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Mult.Width = 0;
            // 
            // Sprice
            // 
            this.Sprice.Text = "Sell Price";
            this.Sprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Sprice.Width = 114;
            // 
            // LT
            // 
            this.LT.Text = "Lead time";
            this.LT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.LT.Width = 65;
            // 
            // note
            // 
            this.note.Text = "Notes";
            this.note.Width = 0;
            // 
            // usr
            // 
            this.usr.Text = "User";
            this.usr.Width = 88;
            // 
            // QID
            // 
            this.QID.Text = "Quote #";
            this.QID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.QID.Width = 75;
            // 
            // LID
            // 
            this.LID.Text = "";
            this.LID.Width = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvNLIO);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 734);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1612, 73);
            this.groupBox2.TabIndex = 126;
            this.groupBox2.TabStop = false;
            // 
            // NL_Item_Option_NEW_2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(1612, 807);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.grpItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NL_Item_Option_NEW_2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BUY & RESELL ITEM ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NL_Item_Option_Load);
            this.grpItem.ResumeLayout(false);
            this.grpItem.PerformLayout();
            this.panel8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.groupBox7.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.pnlStrat.ResumeLayout(false);
            this.pnlStrat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picMoveUP)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel6.ResumeLayout(false);
            this.panel6.PerformLayout();
            this.panel5.ResumeLayout(false);
            this.panel5.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picON)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOFF)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void label38_Click(object sender, System.EventArgs e)
		{
		
		}

        private void calIOExt_avant_25012018()
        {
            if (chkAuto.Checked)
            {
                //tIExt.ReadOnly = true;
                if (tIPU.Text != "" && tIQty.Text != "")
                {
                    double dPU = Tools.Conv_Dbl(tIPU.Text);
                    double dQty = Tools.Conv_Dbl(tIQty.Text);
                    tSMRK.Text = "";
                    if (tSMRK.Text == "") tIExt.Text = Cal_SellPrice(dPU * dQty).ToString();
                    else tIExt.Text = Convert.ToString(Math.Round(dPU * dQty * Tools.Conv_Dbl(tSMRK.Text), MainMDI.NB_DEC_AFF));
                }
            }
        }

		private void calIOExtOLD()
		{
            //if (chkAuto.Checked)
            //{
            //}
            if (!dblclik)
            {
                //tIExt.ReadOnly = true;
                if (Tools.Conv_Dbl(tIPU.Text) > 0 && Tools.Conv_Dbl(tIQty.Text) > 0)
                {
                    double dPU = Tools.Conv_Dbl(tIPU.Text);
                    double dQty = Tools.Conv_Dbl(tIQty.Text);
                    tSMRK.Text = "1";
                    if (tSMRK.Text == "") tIExt.Text = Cal_SellPrice(dPU * dQty).ToString();
                    else tIExt.Text = Convert.ToString(Math.Round(dPU * dQty * Tools.Conv_Dbl(tSMRK.Text), MainMDI.NB_DEC_AFF));
                    //

                    if (pnlStrat.Enabled) tIExt.Text = cal_Frais(tIExt.Text);
                    //
                }
            }
		}

		private string Cal_SellPrice(double ext)
		{
			if (ext > 0)
			{
				string stSql = "SELECT * FROM PSM_SMarkup where " + ext + " <= Hlim and " + ext + " >= Llim ORDER BY Hlim";
				SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
				OConn.Open();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
				while (Oreadr.Read())
				{
					tSMRK.Text = Oreadr["MRKPCA"].ToString();
					return Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["MRKPCA"].ToString()) * ext, MainMDI.NB_DEC_AFF));
				}
				OConn.Close();
				tSMRK.Text = "0";
			}
			return "0";
		}

		private void tIPU_TextChanged(object sender, System.EventArgs e)
		{
			//calIOExt();
            tIExt.Text = Math.Round(Tools.Conv_Dbl(tIPU.Text) * Tools.Conv_Dbl(tIQty.Text), 2).ToString();
		}

		private void grpItem_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void NL_Item_Option_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
            //fill_Hn();
            init_tblFrais();
            init_scr();
            opt_NOmult.Checked = false;
        }

		private void lvNLIO_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			//MessageBox.Show(e.Column.ToString());

			ListView myListView = (ListView)sender;

			//Determine if clicked column is already the column that is being sorted.
			if (e.Column == lvSorter.SortColumn)
			{
			    //Reverse the current sort direction for this column.
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
				//Set the column number that is to be sorted; default to ascending.
				lvSorter.SortColumn = e.Column;
				lvSorter.Order = System.Windows.Forms.SortOrder.Ascending;
			}
			//Perform the sort with these new sort options.
			myListView.Sort();
		}

		public void fill_lvNLIO()
		{
            this.Cursor = Cursors.WaitCursor;

            string cond = "";
            switch (lOpt.Text)
            {
                case "Q":
                    cond = " Where QID=" + In_QID;
                    break;
                case "U":
                    cond = " Where userName='" + MainMDI.User + "'";
                    break;
                case "A":
                    cond = "";
                    break;
                default:
                    MessageBox.Show("Invalid Criteria............");
                    break;
            }
			lvNLIO.Items.Clear();
			string stSql = "SELECT * FROM PSM_NLItemOption " + cond + " ORDER BY IOName";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
            lvNLIO.BeginUpdate();
			while (Oreadr.Read())
			{
				ListViewItem lvI = lvNLIO.Items.Add(Oreadr["IOName"].ToString());
				lvI.SubItems.Add(Oreadr["Model"].ToString());
				lvI.SubItems.Add(Oreadr["dim"].ToString());
				lvI.SubItems.Add(Oreadr["feat1"].ToString());
				lvI.SubItems.Add(Oreadr["feat2"].ToString());
				lvI.SubItems.Add(Oreadr["featO"].ToString());
				lvI.SubItems.Add(Oreadr["QTY"].ToString());
				lvI.SubItems.Add(Oreadr["UP"].ToString());
                ///if (Oreadr["UP"].ToString() != "" && Oreadr["QTY"].ToString() != "") st = "$" + Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["UP"].ToString()) * Tools.Conv_Dbl(Oreadr["QTY"].ToString()), MainMDI.NB_DEC_AFF));
				lvI.SubItems.Add(Oreadr["Mult"].ToString());
				lvI.SubItems.Add(Oreadr["SelPrice"].ToString());
				lvI.SubItems.Add(Oreadr["LT"].ToString());
				lvI.SubItems.Add(Oreadr["notes"].ToString());
				lvI.SubItems.Add(Oreadr["userName"].ToString());
				lvI.SubItems.Add(Oreadr["QID"].ToString());
				lvI.SubItems.Add(Oreadr["IOLID"].ToString());
			}
            lvNLIO.EndUpdate();
            this.Cursor = Cursors.Default;
		}

		private void lvNLIO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void lvNLIO_ColumnClickpp(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
		
		}

		private void ltSave_Click(object sender, System.EventArgs e)
		{
		    //MessageBox.Show(tIotherF.Text + " pos= " + tIotherF.Text.IndexOf('\n', 0).ToString());
			
			if (sav_info())
			{
				fill_lvNLIO();
				lsave.Text = "Save";
				init_scr();
				picSeek.Enabled = false;
			}
		}

        void fill_Hn()
        {
            string stSql = "SELECT *   FROM [Orig_PSM_FDB].[dbo].[PSM_C_GConfig]   where F1_Code='Hn' OR F1_Code='Hn_lim' OR F1_Code='Hn_amt'  order by LID";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                switch (Oreadr["F1_Code"].ToString())
                {
                    case "Hn":
                        H1_val = Oreadr["F2"].ToString();
                        H2_val = Oreadr["F3"].ToString();
                        H3_val = Oreadr["F4"].ToString();
                        H4_val = Oreadr["F5"].ToString();
                        H5_val = Oreadr["F6"].ToString();
                        H6_val = Oreadr["F7"].ToString();
                        break;
                    case "Hn_lim":
                        H1_lim = Oreadr["F2"].ToString();
                        H2_lim = Oreadr["F3"].ToString();
                        H3_lim = Oreadr["F4"].ToString();
                        H4_lim = Oreadr["F5"].ToString();
                        H5_lim = Oreadr["F6"].ToString();
                        H6_lim = Oreadr["F7"].ToString();
                        break;
                    case "Hn_amt":
                        H1_amt = Oreadr["F2"].ToString();
                        H2_amt = Oreadr["F3"].ToString();
                        H3_amt = Oreadr["F4"].ToString();
                        H4_amt = Oreadr["F5"].ToString();
                        H5_amt = Oreadr["F6"].ToString();
                        H6_amt = Oreadr["F7"].ToString();
                        break;
                }
            }
            OConn.Close();
        }

        void init_finalVals()
        {
            tIPU.Text = "0";
            tIQty.Text = "1";
            tIExt.Text = "0";

            cal_pu.Text = "0";
            cal_multipl.Text = "0";
            cal_qty.Text = "1";
            cal_ext.Text = "0";
        }

		private void init_scr()
		{
            AutoCal = true;

            up1.Text = H1_amt;
            up2.Text = H2_amt;
            up3.Text = H3_amt;
            up4.Text = H4_amt;
            up5.Text = H5_amt;
            up6.Text = H6_amt;

            hh1.Text = H1_val;
            hh2.Text = H2_val;
            hh3.Text = H3_val;
            hh4.Text = H4_val;
            hh5.Text = H5_val;
            hh6.Text = H6_val;

            //optNo.Checked = false;
			tIPU.Text = "0";
			tIName.Clear();
			tIModel.Clear();
			tIQty.Text = "1";
			//tINotes.Clear();
			tIf1.Clear();
			tIf2.Clear();
			tILT.Text = "04-06";
			tIExt.Text = "0";
			lif1.Clear();
			lif2.Clear();
			lIotherF.Clear();
			tIotherF.Clear();
		    //tINotes.Clear();
			tIdim.Clear();
			tSMRK.Text = "1";

            AutoCal = true;
            optNo.Checked = true;
            txD31.Focus();
        }

		private bool IO_InfoValid()
		{
		    //if (tIName.Text != "" && tIPU.Text != "" && chkAuto.Checked) return true;
			
			return (tIName.Text != "" && Tools.Conv_Dbl(tIExt.Text) > 0);
		}

        string savallInfo()
        {
            //BNS: buy and resell
            return "BNS||" + hh1.Text + "||" + hh2.Text + "||" + hh3.Text + "||" + hh4.Text + "||" + hh5.Text + "||" + hh6.Text + "||" + up1.Text + "||" + up2.Text + "||" + up3.Text + "||" + up4.Text + "||" + up5.Text +
                "||" + up6.Text + "||" + ((optYes.Checked) ? "1" : "0") + "||" + txD44.Text + "||" + txD30.Text + "||" + txD31.Text + "||" + txD32.Text + "||" + txD33.Text + "||" + txD34.Text + "||" + lCstms.Text + "||" + lSTAX.Text;
        }

		private bool sav_info()
		{
			string stf1 = "", stf2 = "",stSql = "";

			if (IO_InfoValid())
			{
                //if (lif1.Text != "" && tIf1.Text != "") stf1 = lif1.Text + ": " + tIf1.Text;
                //if (lif2.Text != "" && tIf2.Text != "") stf2 = lif2.Text + ": " + tIf2.Text;
                //string ag = (optYes.Checked) ? "1" : "0";
                if (tIf1.Text != "")
                {
                    stf1 = tIf1.Text;
                    if (tIf2.Text != "") stf2 = tIf2.Text;
                }
                //string st = hh1.Text + "||" + hh2.Text + "||" + hh4.Text + "||" + hh5.Text + "||" + hh6.Text + "||" + ((optYes.Checked) ? "1" : "0");
                string st = savallInfo();
				tINotes.Text = lcurDol.Text[0] + tINotes.Text;
				if (lsave.Text == "Save")
				{
					stSql = "INSERT INTO PSM_NLItemOption ([IOName],[Model],[DIM], " + 
						"[feat1],[feat2], " + 
						"[featO], " + 
						"[Qty],[UP], " + 
						"[Mult],[SelPrice], " + 
						"[LT], " + 
						"[notes],[UserName], " + 
						"[QID]) VALUES ('" +
						tIName.Text + "', '" +
						tIModel.Text + "', '" +
						tIdim.Text + "', '" +
						stf1 + "', '" +
						stf2 + "', '" +
						st + "', " +
						tIQty.Text + ", " +
						tIPU.Text + ", " +
						tSMRK.Text + ", " +
						tIExt.Text + ", '" +
						tILT.Text + "', '" +
						tINotes.Text + "', '" +
						MainMDI.User + "', '" +
						In_QID.ToString() + "')";
					picSeek.Enabled = false;
				}
				else 
					stSql = "Update PSM_NLItemOption SET [IOName]='" + tIName.Text + "', " +
						"[Model]='" + tIModel.Text + "', " +
						"[DIM]='" + tIdim.Text + "', " +
						"[feat1]='" + stf1 + "', " +
						"[feat2]='" + stf2 + "', " +
						"[featO]='" + st + "', " +
						"[Qty]=" + tIQty.Text + ", " +
						"[UP]=" + tIPU.Text + ", " +
						"[Mult]=" + tSMRK.Text + ", " +
						"[SelPrice]=" + tIExt.Text + ", " +
						"[LT]='" + tILT.Text + "', " +
						"[notes]='" + tINotes_OLD.Text + "', " +
						"[UserName]='" + MainMDI.User + "', " +
						"[QID]=" + In_QID.ToString() + " where IOLID=" + lvNLIO.SelectedItems[0].SubItems[14].Text;
                        //"[QID]=" + In_QID.ToString() + " where IOLID=" + lvNLIO.SelectedItems[0].SubItems[14].Text;
			
				MainMDI.ExecSql(stSql);
				MainMDI.Write_JFS(stSql);
				//if (MainMDI.ExecSql(stSql) == true) MessageBox.Show("Error Occurs while Saving this Quote...contact your Admin !!!" + MainMDI.stXP);
			    if (lvNLIO.SelectedItems.Count == 1) lvNLIO.SelectedItems[0].BackColor = Color.Lavender;
			}
		    else
			{
                MessageBox.Show("Fields (Item-Name/Unit-Cost) are EMPTY .....!!!");
				tIName.Focus();
				return false;
			}
			return true;
		}

		private bool sav_infoWITH_QTY()
		{
			string stf1 = "", stf2 = "", stSql = "";
			if (IO_InfoValid())
			{
				if (lif1.Text != "" && tIf1.Text != "") stf1 = lif1.Text + ": " + tIf1.Text;
				if (lif2.Text != "" && tIf2.Text != "") stf2 = lif2.Text + ": " + tIf2.Text;
				string st = tIotherF.Text;
				if (st != "") st = lIotherF.Text + ": " + st;
				
			    //for (int i = 0; i < st.Length; i++) if (st[i] == '\n') st[i] = '~';

				if (lsave.Text == "Save")
					stSql = "INSERT INTO PSM_NLItemOption ([IOName],[Model],[DIM], " + 
						" [feat1],[feat2], " + 
						" [featO], " + 
						" [UP],[QTY],[LT], " + 
						" [notes],[UserName], " + 
						" [QID]) VALUES ('" +
						tIName.Text + "', '" +
						tIModel.Text + "', '" +
						tIdim.Text + "', '" +
						stf1 + "', '" +
						stf2 + "', '" + 
						st + "', " +
						tIPU.Text + ", " +
						tIQty.Text + ", '" +
						tILT.Text + "', '" +
						tINotes.Text + "', '" +
						MainMDI.User + "', '" +
						In_QID.ToString() + "')";
				else 
					stSql = "Update PSM_NLItemOption SET [IOName]='" + tIName.Text + "', " +
						"[Model]='" + tIModel.Text + "', " +
						"[DIM]='" + tIdim.Text + "', " +
						"[feat1]='" + stf1 + "', " +
						"[feat2]='" + stf2 + "', " +
						"[featO]='" + st + "', " +
						"[UP]='" + tIPU.Text + "', " +
						"[QTY]=" + tIQty.Text + ", " +
						"[LT]='" + tILT.Text + "', " +
						"[notes]='" + tINotes.Text + "', " +
						"[UserName]='" + MainMDI.User + "', " +
						"[QID]=" + In_QID.ToString() + " where IOLID=" + lvNLIO.SelectedItems[0].SubItems[11].Text;
			
				MainMDI.ExecSql(stSql);
				MainMDI.Write_JFS(stSql);
				//if (MainMDI.ExecSql(stSql) == true) MessageBox.Show("Error Occurs while Saving this Quote...contact your Admin !!!" + MainMDI.stXP);
				lvNLIO.SelectedItems[0].BackColor = Color.Lavender;
			}
			else
			{
				MessageBox.Show("EMPTY Fields  (Item-Name/Unit-Cost) !!!");
				tIName.Focus();
				return false;
			}
			return true;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (tIName.Text != "") //tIExt.Text != "0" &&
			{
				SaveOK = true;
                opt_NOmult.Checked = false;
                lsavALLinfo.Text = savallInfo();
				this.Hide();
			}
			else MessageBox.Show("Item INFO are Invalid !!!!!");
		}

		private void tIPU_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tIQty_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tILT_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tILT_TextChanged(object sender, System.EventArgs e)
		{
		
		}

        private void btnCancel_Click(object sender, System.EventArgs e)
        {
            //if (lsave.Text == "Save")
            //{
                //SaveOK = false;
                //this.Hide();
            //}
            //else
            //{
                //lsave.Text = "Save";
                //lvNLIO.Enabled = true;
                //lvNLIO.BackColor = Color.Bisque;
                //tINotes_OLD.Visible = false;
            //}
            SaveOK = false;
            this.Hide();
        }

        void deco_info(string st_info, out List<string> Lst_info, string sep)
        {
            Lst_info = new List<string>();
            string st = "";
            if (st_info != "")
            {
                int i = 0;
                int ipos = 0;

                while (st_info.Length > 0)
                {
                    ipos = st_info.IndexOf(sep);
                    if (ipos > -1)
                    {
                        st = st_info.Substring(0, ipos);
                        st_info = st_info.Substring(ipos + 2, st_info.Length - (ipos + 2));
                    }
                    else
                    {
                        st = st_info;
                        st_info = "";
                    }
                    if (st != "") Lst_info.Add(st);
                }
            }
        }

		private void lvNLIO_DoubleClick(object sender, System.EventArgs e)
		{
			if (lvNLIO.SelectedItems.Count == 1)
			{
                lvNLIO.BackColor = Color.LightGray;
                dblclik = true;
				picSeek.Enabled = true;
				LVNdx = lvNLIO.SelectedItems[0].Index;
                lvNLIO.SelectedItems[0].BackColor = Color.Bisque; //Yellow;
                //this.Refresh();
				tIName.Text = lvNLIO.SelectedItems[0].SubItems[0].Text;
				tIModel.Text = lvNLIO.SelectedItems[0].SubItems[1].Text;
				tIdim.Text = lvNLIO.SelectedItems[0].SubItems[2].Text;
                tIf1.Text = lvNLIO.SelectedItems[0].SubItems[3].Text;
                tIf2.Text = lvNLIO.SelectedItems[0].SubItems[4].Text;
			    if (lvNLIO.SelectedItems[0].SubItems[5].Text.IndexOf("||") > 0)
                {
                    List<string> myQTY = new List<string>();
                    deco_info(lvNLIO.SelectedItems[0].SubItems[5].Text, out myQTY, "||");
                    hh1.Text = myQTY[0];
                    hh2.Text = myQTY[1];
                    hh4.Text = myQTY[2];
                    hh5.Text = myQTY[3];
                    hh6.Text = myQTY[4];
                    //optNo.Checked = (myQTY[4] == "0");
                    optYes.Checked = (myQTY[5] == "1");
                }
                else
                {
                    hh1.Text = "1";
                    hh2.Text = "1";
                    hh4.Text = "1";
                    hh5.Text = "2";
                    hh6.Text = "0.5";
                    optNo.Checked = true;
                }
                //if (lvNLIO.SelectedItems[0].SubItems[5].Text != "")
                //{
                    //lIotherF.Text = lvNLIO.SelectedItems[0].SubItems[5].Text.Substring(0, Ipos);
                    //tIotherF.Text = lvNLIO.SelectedItems[0].SubItems[5].Text.Substring(Ipos + 2, lvNLIO.SelectedItems[0].SubItems[5].Text.Length - Ipos - 2);
                //}
				tIQty.Text = lvNLIO.SelectedItems[0].SubItems[6].Text;
				tIPU.Text = lvNLIO.SelectedItems[0].SubItems[7].Text;
				tSMRK.Text = lvNLIO.SelectedItems[0].SubItems[8].Text;
				tIExt.Text = lvNLIO.SelectedItems[0].SubItems[9].Text;
				
				tILT.Text = lvNLIO.SelectedItems[0].SubItems[10].Text;
				if (lvNLIO.SelectedItems[0].SubItems[11].Text.Length > 0)
				{
                    //tINotes.Text = lvNLIO.SelectedItems[0].SubItems[11].Text.Substring(1, lvNLIO.SelectedItems[0].SubItems[11].Text.Length - 1);
                    tINotes_OLD.Text = lvNLIO.SelectedItems[0].SubItems[11].Text.Substring(1, lvNLIO.SelectedItems[0].SubItems[11].Text.Length - 1);
					opCan.Checked = (lvNLIO.SelectedItems[0].SubItems[11].Text[0] == 'C');
					opUS.Checked = (lvNLIO.SelectedItems[0].SubItems[11].Text[0] == 'U');
					opEuro.Checked = (lvNLIO.SelectedItems[0].SubItems[11].Text[0] == 'E');
				}
				else opCan.Checked = true;

                lsave.Text = "Update";
                tIPU.Focus();
				lvNLIO.Enabled = false;
                tINotes_OLD.Visible = true;
			}
            dblclik = false;
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
            string stSql = "SELECT * FROM s_byNresell_import order by yy";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                tIName.Text = Oreadr["Item_name"].ToString();
                tIModel.Text = Oreadr["Model"].ToString();
                tIdim.Text = Oreadr["dimensions"].ToString();
                lif1.Text = "Description1"; tIf1.Text = Oreadr["d1"].ToString();
                lif2.Text = "Description2"; tIf2.Text = Oreadr["d2"].ToString();
                lIotherF.Text = "";
                tIQty.Text = Oreadr["qty"].ToString();
                tIPU.Text = Oreadr["unit_cost"].ToString();
                tSMRK.Text = Oreadr["Mark_up"].ToString();
                tIExt.Text = Oreadr["sell_price"].ToString();
                tILT.Text = Oreadr["lead_time"].ToString();
                MessageBox.Show("Continue...........");
                picSeek_Click(sender, e);
            }
            OConn.Close();
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			if (lvNLIO.SelectedItems.Count == 1)
			{
				string stSql = "delete PSM_NLItemOption where IOLID= " + lvNLIO.SelectedItems[0].SubItems[14].Text;
				MainMDI.ExecSql(stSql);
				lvNLIO.Items[lvNLIO.SelectedItems[0].Index ].Remove();
			}
		    //else MessageBox.Show("Please select ONE(1) RECORD !!!");
		}

		private void tINotes_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tSMRK_TextChanged(object sender, System.EventArgs e)
		{
			if (chkAuto.Checked)
			{
				double dPU = Tools.Conv_Dbl(tIPU.Text);
				double dQty = Tools.Conv_Dbl(tIQty.Text);
				tIExt.Text = Convert.ToString(Math.Round(dPU * dQty * Tools.Conv_Dbl(tSMRK.Text), MainMDI.NB_DEC_AFF));
			}
		}

		private void lvNLIO_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
		
		}

		private void grpItem_Enter_1(object sender, System.EventArgs e)
		{
		
		}

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			init_scr();
			lsave.Text = "Save";
			if (lvNLIO.SelectedItems.Count == 1) lvNLIO.SelectedItems[0].BackColor = Color.Bisque;
		}

		private void chkAuto_CheckedChanged(object sender, System.EventArgs e)
		{
			//tIExt.ReadOnly = chkAuto.Checked;
			//tIPU.Text = tIPU.Text;
			tSMRK.ReadOnly = chkAuto.Checked;
		}

		private void tIExt_TextChanged(object sender, System.EventArgs e)
		{
			//if (!picSeek.Enabled) picSeek.Enabled = true;
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{

		}

		private void picSeek_Click(object sender, System.EventArgs e)
		{ 
			//if (!tIExt.ReadOnly) { tIPU.Text = tIExt.Text; tIQty.Text = 1;
			//tIExt.ReadOnly = true;
			tIExt.Text = Tools.Conv_Dbl(tIExt.Text).ToString();
			if (sav_info())
			{
				//pictureBox1_Click(sender, e);
				fill_lvNLIO();
				lvNLIO.Enabled = true;
				//lSave.Text = "Save";
				//init_scr();
			}
            lsave.Text = "Save";
            lvNLIO.Enabled = true;
			picSeek.BorderStyle = BorderStyle.None;
		}

		private void pictureBox2_Click(object sender, System.EventArgs e)
		{

		}

		private void opCan_CheckedChanged(object sender, System.EventArgs e)
		{
			lcurDol.Text = "CAD";
		}

		private void opUS_CheckedChanged(object sender, System.EventArgs e)
		{
			lcurDol.Text = "USD";
		}

		private void opEuro_CheckedChanged(object sender, System.EventArgs e)
		{
			lcurDol.Text = "EURO";
		}

		private void tIotherF_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tIExt_DoubleClick(object sender, System.EventArgs e)
		{
			//tIExt.ReadOnly = false;
		}

		private void picSeek_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		    picSeek.BorderStyle = BorderStyle.Fixed3D;
		}

		private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		    pictureBox1.BorderStyle = BorderStyle.Fixed3D;
		}

		private void tILT_TextChanged_1(object sender, System.EventArgs e)
		{
		
		}

		private void pictureBox2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			pictureBox2.BorderStyle = BorderStyle.Fixed3D;
		}

		private void tIName_TextChanged(object sender, System.EventArgs e)
		{
			if (!picSeek.Enabled) picSeek.Enabled = true;
		}

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void btnbrowse_Click(object sender, EventArgs e)
        {
            pnlStrat.Visible = (btnbrowse.Text == "+");
            btnbrowse.Text = (pnlStrat.Visible) ? "-" : "+";
        }

        private void hh1_TextChanged(object sender, EventArgs e)
        {
            if (Tools.Conv_Dbl(hh1.Text) >= Tools.Conv_Dbl(H1_lim))
            {
                Amnt1.Text = (Tools.Conv_Dbl(up1.Text) * Tools.Conv_Dbl(hh1.Text)).ToString();
                if (AutoCal)
                {
                    Tot_ref();
                    calIOExt_NEW();
                }
            }
        }

        private void hh2_TextChanged(object sender, EventArgs e)
        {
            if (Tools.Conv_Dbl(hh2.Text) >= Tools.Conv_Dbl(H2_lim))
            {
                Amnt2.Text = (Tools.Conv_Dbl(up2.Text) * Tools.Conv_Dbl(hh2.Text)).ToString();
                if (AutoCal)
                {
                    Tot_ref();
                    calIOExt_NEW();
                }
            }
        }

        private void hh3_TextChanged(object sender, EventArgs e)
        {
            if (Tools.Conv_Dbl(hh3.Text) >= Tools.Conv_Dbl(H3_lim))
            {
                Amnt3.Text = (Tools.Conv_Dbl(up3.Text) * Tools.Conv_Dbl(hh3.Text)).ToString();
                if (AutoCal)
                {
                    Tot_ref();
                    calIOExt_NEW();
                }
            }
        }

        private void hh4_TextChanged(object sender, EventArgs e)
        {
            if (Tools.Conv_Dbl(hh4.Text) >= Tools.Conv_Dbl(H4_lim))
            {
                Amnt4.Text = (Tools.Conv_Dbl(up4.Text) * Tools.Conv_Dbl(hh4.Text)).ToString();
                if (AutoCal)
                {
                    Tot_ref();
                    calIOExt_NEW();
                }
            }
        }

        private void hh5_TextChanged(object sender, EventArgs e)
        {
            if (Tools.Conv_Dbl(hh5.Text) >= Tools.Conv_Dbl(H5_lim))
            {
                Amnt5.Text = (Tools.Conv_Dbl(up5.Text) * Tools.Conv_Dbl(hh5.Text)).ToString();
                if (AutoCal)
                {
                    Tot_ref();
                    calIOExt_NEW();
                }
            }
        }

        void Tot_ref()
        {
            txD42.Text = (Tools.Conv_Dbl(Amnt1.Text) + Tools.Conv_Dbl(Amnt2.Text) + Tools.Conv_Dbl(Amnt3.Text) + Tools.Conv_Dbl(Amnt4.Text) + Tools.Conv_Dbl(Amnt5.Text) + Tools.Conv_Dbl(Amnt6.Text)).ToString();
            init_finalVals();
        }

	    void init_tblFrais()
        {
            fill_Hn();
            Tot_ref();
        }

        private void optYes_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoCal) calIOExt_NEW();
        }

        private void optNo_CheckedChanged(object sender, EventArgs e)
        {
            if (AutoCal) calIOExt_NEW();
        }

        private void NewST_Click(object sender, EventArgs e)
        {
            //if (!tIExt.ReadOnly) { tIPU.Text = tIExt.Text; tIQty.Text = 1;
            //tIExt.ReadOnly = true;
            tIExt.Text = Tools.Conv_Dbl(tIExt.Text).ToString();
            if (sav_info())
            {
                //pictureBox1_Click(sender, e);
                fill_lvNLIO();
                lvNLIO.Enabled = true;
                //lSave.Text = "Save";
                //init_scr();
            }
            lsave.Text = "Save";
            lvNLIO.Enabled = true;
            lvNLIO.BackColor = Color.Bisque;
            tINotes_OLD.Visible = false;
            //picSeek.BorderStyle = BorderStyle.None;
        }

        private void delitm_Click(object sender, EventArgs e)
        {
            if (lvNLIO.SelectedItems.Count == 1 && MainMDI.Confirm("Delete this Item ? '" + lvNLIO.SelectedItems[0].SubItems[0].Text + "'"))
            {
                string stSql = "delete PSM_NLItemOption where IOLID= " + lvNLIO.SelectedItems[0].SubItems[14].Text;
                MainMDI.ExecSql(stSql);
                lvNLIO.Items[lvNLIO.SelectedItems[0].Index].Remove();
            }
            //pictureBox2.BorderStyle = BorderStyle.None;
        }

        private void newitm_Click(object sender, EventArgs e)
        {
            init_scr();
            lsave.Text = "Save";
            picSeek.Enabled = true;
            if (lvNLIO.SelectedItems.Count == 1) lvNLIO.SelectedItems[0].BackColor = Color.Bisque;
            lvNLIO.Enabled = true;
            //pictureBox1.BorderStyle = BorderStyle.None;
        }

        private void _exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void optQNB_CheckedChanged(object sender, EventArgs e)
        {
            lOpt.Text = "Q";
            fill_lvNLIO();
        }

        private void optuser_CheckedChanged(object sender, EventArgs e)
        {
            lOpt.Text = "U";
            fill_lvNLIO();
        }

        private void optALL_CheckedChanged(object sender, EventArgs e)
        {
            lOpt.Text = "A";
            fill_lvNLIO();
        }

        private void TOTamnt_TextChanged(object sender, EventArgs e)
        {
            //if (AutoCal)
            //{
                //Tot_ref();
                //calIOExt_NEW();
            //}
        }

        private void tlsOFF_Click(object sender, EventArgs e)
        {
            //pnlStrat.Enabled = true;
            //tlsOFF.Visible = false;
            //tlsON.Visible = true;
        }

        private void tlsON_Click(object sender, EventArgs e)
        {
            //pnlStrat.Enabled = false;
            //tlsOFF.Visible = true;
            //tlsON.Visible = false;
        }

        private void picOFF_Click(object sender, EventArgs e)
        {
            pnlStrat.Enabled = true;
            picOFF.Visible = false;
            picON.Visible = true;
        }

        private void picON_Click(object sender, EventArgs e)
        {
            pnlStrat.Enabled = false;
            picOFF.Visible = true;
            picON.Visible = false;
        }

        private void pnlStrat_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txD30_TextChanged(object sender, EventArgs e)
        {
            //ship to Primax must > 1
            if (Tools.Conv_Dbl(txD32.Text) < 1) txD32.Text = "1";
            if (txCstms.Text == "")
            {
                txCstms.Text = "7"; //Math.Round(Tools.Conv_Dbl(txD30.Text) * 0.07, 2).ToString();
                //txSTAX.Text = Math.Round(Tools.Conv_Dbl(txD46.Text) * 0.07, 2).ToString();
            }
            if (txSTAX.Text == "")
            {
                //txCstms.Text = Math.Round(Tools.Conv_Dbl(txD46.Text) * 0.07, 2).ToString();
                txSTAX.Text = "5"; //Math.Round(Tools.Conv_Dbl(txD30.Text) * 0.07, 2).ToString();
            }
            //double us = (Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text)) * Tools.Conv_Dbl(txD44.Text);
            //txD46.Text = Math.Max(us, Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text)).ToString();

            //txD46.Text = Math.Max((Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(lCstms.Text) + Tools.Conv_Dbl(lSTAX.Text)) * Tools.Conv_Dbl(txD44.Text), Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(lCstms.Text) + Tools.Conv_Dbl(lSTAX.Text)).ToString();

            //if (optUS.Checked) txD46.Text = (Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(lCstms.Text) + Tools.Conv_Dbl(lSTAX.Text) * Tools.Conv_Dbl(txD44.Text)).ToString();
            if (AutoCal)
            {
                Tot_ref();
                calIOExt_NEW();
            }
            init_finalVals();
        }

        private void txD31_TextChanged(object sender, EventArgs e)
        {
            //ship to Primax must > 1
            if (Tools.Conv_Dbl(txD32.Text) < 1) txD32.Text = "1";
            if (txCstms.Text == "")
            {
                txCstms.Text = "7";
                //txCstms.Text = Math.Round(Tools.Conv_Dbl(txD31.Text) * 0.07, 2).ToString();
            }
            if (txSTAX.Text == "")
            {
                txSTAX.Text = "5";
                //txSTAX.Text = Math.Round(Tools.Conv_Dbl(txD31.Text) * 0.07, 2).ToString();
            }
            //txD46.Text = Math.Max(Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text), Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text)).ToString();
            //double us = (Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text)) * Tools.Conv_Dbl(txD44.Text);
            //txD46.Text = Math.Max(us, Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text)).ToString();

            //txD46.Text = Math.Max((Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(lCstms.Text) + Tools.Conv_Dbl(lSTAX.Text)) * Tools.Conv_Dbl(txD44.Text), Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(lCstms.Text) + Tools.Conv_Dbl(lSTAX.Text)).ToString();

            //if (optCAD.Checked) txD46.Text = (Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(lCstms.Text) + Tools.Conv_Dbl(lSTAX.Text) * Tools.Conv_Dbl(txD44.Text)).ToString();
            if (AutoCal)
            {
                Tot_ref();
                calIOExt_NEW();
            }
            init_finalVals();
        }

        void cal_TabFrais()
        {
            double D7 = (Tools.Conv_Dbl(Amnt1.Text) + Tools.Conv_Dbl(Amnt2.Text) + Tools.Conv_Dbl(Amnt3.Text) + Tools.Conv_Dbl(Amnt4.Text) + Tools.Conv_Dbl(Amnt5.Text) + Tools.Conv_Dbl(Amnt6.Text));
            valFrais.Text = D7.ToString();
        }

        double calc_firstPrice(double priceInitial) //calc_CAD()
        {
            cal_TabFrais();
            double stateTax = Tools.Conv_Dbl(lSTAX.Text) + 1;
            double TT = ((priceInitial + Tools.Conv_Dbl(txD32.Text)) / 0.8) + Tools.Conv_Dbl(valFrais.Text);
            TT = (optUS.Checked) ? TT * stateTax : TT;
            TT = (optYes.Checked) ? TT / 0.97 : TT;
            return Math.Round(TT, 0, MidpointRounding.AwayFromZero);
        }

        private void cal_qty_TextChanged(object sender, EventArgs e)
        {
            cal_ext.Text = Math.Round(Tools.Conv_Dbl(cal_pu.Text) * Tools.Conv_Dbl(cal_qty.Text) * Tools.Conv_Dbl(cal_multipl.Text), 2).ToString();
        }

        private void txCstms_TextChanged(object sender, EventArgs e)
        {
            //txD46.Text = Math.Max((Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text)) * Tools.Conv_Dbl(txD44.Text), Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text)).ToString();
            lCstms.Text = (Tools.Conv_Dbl(txCstms.Text) / 100).ToString();

            txD46.Text = Math.Max(Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(txD42.Text), Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(txD42.Text)).ToString();

            if (AutoCal)
            {
                Tot_ref();
                calIOExt_NEW();
            }
        }

        private void txSTAX_TextChanged(object sender, EventArgs e)
        {
            //txD46.Text = Math.Max((Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text)) * Tools.Conv_Dbl(txD44.Text), Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text)).ToString();
            lSTAX.Text = (Tools.Conv_Dbl(txSTAX.Text) / 100).ToString();

            txD46.Text = Math.Max(Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(txD42.Text), Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(txD42.Text)).ToString();

            if (AutoCal)
            {
                Tot_ref();
                calIOExt_NEW();
            }
        }

        void cal_txD30()
        {
            txD30.Text = Math.Round(Tools.Conv_Dbl(txD30_UCst.Text) * Tools.Conv_Dbl(txD30_Qty.Text), 2).ToString();
        }

        private void txD30_UCst_TextChanged(object sender, EventArgs e)
        {
            cal_txD30();
        }

        private void txD30_Qty_TextChanged(object sender, EventArgs e)
        {
            cal_txD30();
        }

        void cal_txD31()
        {
            txD31.Text = Math.Round(Tools.Conv_Dbl(txD31_UCst.Text) * Tools.Conv_Dbl(txD31_Qty.Text), 2).ToString();
        }

        private void txD31_UCst_TextChanged(object sender, EventArgs e)
        {
            cal_txD31();
        }

        private void txD31_Qty_TextChanged(object sender, EventArgs e)
        {
            cal_txD31();
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (panel8.Visible == true)
            {
                this.initBattery();
            }
            else
            {
                if (optUS.Checked) txD30_TextChanged(sender, e);
                else txD31_TextChanged(sender, e);
            }
        }

        private void cal_pu_TextChanged(object sender, EventArgs e)
        {

        }

        private void cal_multipl_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_addBattery_Click(object sender, EventArgs e)
        {
            transfererInformationBatterie();
        }

        double Calc_secondPrice(double price) //Calc_US()
        {
            double tt = Tools.Conv_Dbl(txD44.Text);
            double customs = Tools.Conv_Dbl(lCstms.Text) + 1;
            double stateTax = Tools.Conv_Dbl(lSTAX.Text) + 1;
            if (tt > 0)
            {
                //De base
                //tt = tt - 0.05d;
                //double selUS_bfr_cstmTax = MainMDI.kim_round(Tools.Conv_Dbl(txD33.Text) / tt, 0);
                //double uscstms = Math.Round(selUS_bfr_cstmTax * Tools.Conv_Dbl(lCstms.Text), 2);
                //double ST1 = Math.Round(selUS_bfr_cstmTax + uscstms, 2);
                //double usTAX = Math.Round(ST1 * Tools.Conv_Dbl(lSTAX.Text), 2);

                double price_exchangeRate = 0;
                if (optCAD.Checked) price_exchangeRate = (price / tt) * stateTax; //(price / tt) * stateTax;
                else
                {
                    price_exchangeRate = ((((price * customs) + Tools.Conv_Dbl(txD32.Text)) * tt) / 0.8) + Tools.Conv_Dbl(valFrais.Text);
                    price_exchangeRate = (optYes.Checked) ? price_exchangeRate / 0.97 : price_exchangeRate;
                }
                price_exchangeRate = Math.Round(price_exchangeRate, 2);
                txD46.Text = Math.Max(Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(txD42.Text), Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(txD42.Text)).ToString();

                //return Math.Round(ST1 + usTAX, 0); //MainMDI.kim_round(Tools.Conv_Dbl(txD33.Text) / tt, 0);
                return Math.Round(price_exchangeRate, 0);
            }
            return 0;
        }

        private void calIOExt_NEW()
        {
            if (!dblclik)
            {
                //txD46.Text = Math.Max(Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text), Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text)).ToString();
                //txD33.Text = calc_CAD().ToString();
                //txD34.Text = Calc_US().ToString();

                if (!optUS.Checked)
                {
                    txD33.Text = calc_firstPrice(Tools.Conv_Dbl(txD31.Text)).ToString();
                    txD34.Text = Calc_secondPrice(Tools.Conv_Dbl(txD33.Text)).ToString();
                }
                else
                {
                    txD34.Text = calc_firstPrice(Tools.Conv_Dbl(txD30.Text)).ToString();
                    txD33.Text = Calc_secondPrice(Tools.Conv_Dbl(txD30.Text)).ToString();
                }
            }
        }

        private void cbBox_supplier_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void cbBox_supportType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txD33_TextChanged(object sender, EventArgs e)
        {

        }

        private void txD46_TextChanged(object sender, EventArgs e)
        {
            if (AutoCal)
            {
                Tot_ref();
                calIOExt_NEW();
            }
        }

        private void addBatt_Click(object sender, EventArgs e)
        {
            this.panel8.Visible = true;
            this._exit.Visible = false;
            this.addBatt.Visible = false;
            this.cancel.Visible = true;
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.panel8.Visible = false;
            this.cancel.Visible = false;
            this.addBatt.Visible = true;
            this._exit.Visible = true;
            this.initBattery();
        }

        private void tIQty_TextChanged(object sender, System.EventArgs e)
        {
            tIExt.Text = Math.Round(Tools.Conv_Dbl(tIPU.Text) * Tools.Conv_Dbl(tIQty.Text), 2).ToString();
        }

        string cal_Frais(string amntBAR) //Buy And R
        {
            double TT = Tools.Conv_Dbl(amntBAR) / 0.8;
            cal_TabFrais();

            TT += Tools.Conv_Dbl(valFrais.Text);
            TT = (optYes.Checked) ? TT / 0.97 : TT;
            return Math.Round(TT, 0).ToString();
        }

        private void hh6_TextChanged(object sender, EventArgs e)
        {
            if (Tools.Conv_Dbl(hh6.Text) >= Tools.Conv_Dbl(H6_lim))
            {
                Amnt6.Text = (Tools.Conv_Dbl(up6.Text) * Tools.Conv_Dbl(hh6.Text)).ToString();
                if (AutoCal)
                {
                    Tot_ref();
                    calIOExt_NEW();
                }
            }
        }

        private void optUS_CheckedChanged(object sender, EventArgs e)
        {
            txD30.Enabled = true;
            txD30_Qty.Enabled = true;
            txD30_UCst.Enabled = true;

            txD31.Enabled = false;
            txD31_Qty.Enabled = false;
            txD31_UCst.Enabled = false;

            txD31.Text = "0";
            txD31_Qty.Text = "1";
            txD31_UCst.Text = "0";

            lcurDol.Text = "USD";
        }

        private void optCAD_CheckedChanged(object sender, EventArgs e)
        {
            txD31.Enabled = true;
            txD31_Qty.Enabled = true;
            txD31_UCst.Enabled = true;

            txD30.Enabled = false;
            txD30_Qty.Enabled = false;
            txD30_UCst.Enabled = false;

            txD30.Text = "0";
            txD30_Qty.Text = "1";
            txD30_UCst.Text = "0";

            txD31.Enabled = true;

            lcurDol.Text = "CAD";
        }

        private void up1_TextChanged(object sender, EventArgs e)
        {

        }

        private void up2_TextChanged(object sender, EventArgs e)
        {

        }

        private void txD44_TextChanged(object sender, EventArgs e)
        {
            //txD46.Text = (optCAD.Checked) ? (Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(txCstms.Text) + Tools.Conv_Dbl(txSTAX.Text) * Tools.Conv_Dbl(txD44.Text)).ToString()
                //: (Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(txCstms.Text) + Tools.Conv_Dbl(txSTAX.Text) * Tools.Conv_Dbl(txD44.Text)).ToString();

            Math.Max(Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(txD42.Text), Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(txD42.Text)).ToString();
            if (AutoCal)
            {
                Tot_ref();
                calIOExt_NEW();
            }
        }

        private void txD32_TextChanged(object sender, EventArgs e)
        {
            //txD46.Text = Math.Max((Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text)) * Tools.Conv_Dbl(txD44.Text), Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text)).ToString();

            //txD46.Text = Math.Max((Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(lCstms.Text) + Tools.Conv_Dbl(lSTAX.Text)) * Tools.Conv_Dbl(txD44.Text), Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(lCstms.Text) + Tools.Conv_Dbl(txSTAX.Text)).ToString();

            //txD46.Text = (!optUS.Checked) ? (Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(txCstms.Text) + Tools.Conv_Dbl(txSTAX.Text) * Tools.Conv_Dbl(txD44.Text)).ToString()
                //: (Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(txCstms.Text) + Tools.Conv_Dbl(txSTAX.Text) * Tools.Conv_Dbl(txD44.Text)).ToString();

            Math.Max(Tools.Conv_Dbl(txD30.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(txD42.Text), Tools.Conv_Dbl(txD31.Text) + Tools.Conv_Dbl(txD32.Text) + Tools.Conv_Dbl(txD42.Text)).ToString();
            if (AutoCal)
            {
                Tot_ref();
                calIOExt_NEW();
            }
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            //if (Tools.Conv_Dbl(txD30.Text) > 0)
            //{

            //}
            if (Tools.Conv_Dbl(txD32.Text) < 1)
                MessageBox.Show("Shipping to Primax must be > 0");
            else
            {
                //tIPU.Text = txD34.Text;
                //double dd = Math.Round((Tools.Conv_Dbl(txD34.Text) / Tools.Conv_Dbl(txD30.Text)), 4);
                //cal_multipl.Text = dd.ToString();
                //cal_qty.Text = txD31_Qty.Text;
                //cal_pu.Text = txD30.Text;
                //cal_ext.Text = txD34.Text;

                //cal_pu.Text = Math.Round(Tools.Conv_Dbl(txD34.Text) / Tools.Conv_Dbl(cal_qty.Text), 0).ToString();
                //cal_multipl.Text = "1"; //dd.ToString();

                cal_pu.Text = (optCAD.Checked) ? txD31.Text : txD30.Text;
                cal_qty.Text = txD30_Qty.Text;
                cal_multipl.Text = (optCAD.Checked) ? (Math.Round(Tools.Conv_Dbl(txD34.Text) / Tools.Conv_Dbl(txD31.Text), 2)).ToString() : (Math.Round(Tools.Conv_Dbl(txD34.Text) / Tools.Conv_Dbl(txD30.Text), 2)).ToString(); //dd.ToString();
                cal_ext.Text = txD34.Text;
            }
        }

        private void picMoveUP_Click(object sender, EventArgs e)
        {
            //if (optCAD.Checked) tIPU.Text = txD33.Text;
            //if (optUS.Checked) tIPU.Text = txD34.Text;
            if (Tools.Conv_Dbl(txD32.Text) < 1)
                MessageBox.Show("Shipping to Primax must be > 0");
            else
            {
                //tIPU.Text = txD33.Text;
                //double dd = Math.Round((Tools.Conv_Dbl(txD33.Text) / Tools.Conv_Dbl(txD31.Text)), 4);
                //cal_multipl.Text = dd.ToString();
                //cal_qty.Text = "1";
                //cal_pu.Text = txD31.Text;
                //cal_ext.Text = txD33.Text;

                //cal_pu.Text = Math.Round(Tools.Conv_Dbl(txD33.Text) / Tools.Conv_Dbl(cal_qty.Text), 0).ToString();
                //cal_multipl.Text = "1"; //dd.ToString();

                cal_pu.Text = (optCAD.Checked) ? txD31.Text : txD30.Text;
                cal_qty.Text = txD31_Qty.Text;
                cal_multipl.Text = (optCAD.Checked) ? (Math.Round(Tools.Conv_Dbl(txD33.Text) / Tools.Conv_Dbl(txD31.Text), 2)).ToString() : (Math.Round(Tools.Conv_Dbl(txD33.Text) / Tools.Conv_Dbl(txD30.Text), 2)).ToString(); //dd.ToString();
                cal_ext.Text = txD33.Text;
            }
        }

        private void transfererInformationBatterie()
        {
            //this.tIModel.Text = this.txtBox_batteryModel.Text;
            //this.tIdim.Text = this.txtBox_dimensions.Text;
            this.clearBatteryTextBox();
        }

        private void clearBatteryTextBox()
        {
            //this.txtBox_batteryCapacity.Clear();
            //this.txtBox_batteryModel.Clear();
            //this.txtBox_batteryTechnology.Clear();
            //this.txtBox_dimensions.Clear();
            //this.txtBox_numberOfCells.Clear();
            //this.txtBox_numberOfSupports.Clear();
            //this.txtBox_price.Clear();
            //this.txtBox_seismicRated.Clear();
            //this.txtBox_supportType.Clear();
        }

        private void fill_cbBox_supplier()
        {

        }

        private void fill_cbBox_supportType()
        {

        }

        private void initBattery()
        {
            this.textBox_batteryManufacturer.Text = "";
            this.textBox_batteryType.Text = "";
            this.textBox_batteryModel.Text = "";
            this.textBox_batteryAlloy.Text = "";
            this.textBox_batteryCapacity.Text = "";
            this.textBox_batteryHeight.Text = "";
            this.textBox_batteryLength.Text = "";
            this.textBox_batteryWidth.Text = "";
            this.textBox_batteryWeight.Text = "";
            this.textBox_batteryLife.Text = "";
            this.textBox_batteryPrice.Text = "";
            this.radioButton_batteryDimensionsInches.Checked = false;
            this.radioButton_batteryDimensionsMeters.Checked = false;
            this.radioButton_batteryPriceCA.Checked = false;
            this.radioButton_batteryPriceUS.Checked = false;
            this.radioButton_seismicYes.Checked = false;
            this.radioButton_seismicNo.Checked = false;
            this.textBox_rackHeight.Text = "";
            this.textBox_rackLength.Text = "";
            this.textBox_rackWidth.Text = "";
            this.radioButton_rackDimensionsInches.Checked = false;
            this.radioButton_rackDimensionsMeters.Checked = false;
            this.textBox_rackPrice.Text = "";
            this.textBox_date.Text = "";
            this.radioButton_rackPriceCA.Checked = false;
            this.radioButton_rackPriceUS.Checked = false;
            this.listView_Battery.Items.Clear();
        }
    }
}
