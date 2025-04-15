using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb ;
using System.Data.SqlClient ;
using Excel = Microsoft.Office.Interop.Excel ;
using EAHLibs;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for Options.
	/// </summary>
	public class Options_Admin : System.Windows.Forms.Form
	{
		string In_user_Name="", In_Cpt_Name="", XLName="" ,cptCODE="",MANCode="",FAMCode="";
        Excel.Application m_objXL = null; //new Excel.Application();
		char In_Opera;
		private Lib1 Tools = new Lib1();
		private ListViewColumnSorter lvSorter=null;
		private int ndxfound=-1;
		private bool msgDisp=false;
		string[,] Idata, arr_Table_Cols=new string [500,2];
		int icount=0, XL_MaxItem = 1500, ndx_Table_Cols=0;
        bool debut = true;
        

		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label19;
        private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label loptID;
		private System.Windows.Forms.Label lOptGrp;
		private System.Windows.Forms.ComboBox cbOptGrp;
		private System.Windows.Forms.Label r_tERef;
        private System.Windows.Forms.Label r_tFRef;
		private System.Windows.Forms.Label r_type;
        private System.Windows.Forms.Label ltype;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label lFamID;
        private System.Windows.Forms.Label lManID;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbPFamily;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ComboBox cbManuf;
		private System.Windows.Forms.Label r_tManifac;
        private System.Windows.Forms.Label r_tPx;
		private System.Windows.Forms.Label r_tDlvDelay;
		private System.Windows.Forms.Label r_tUPrice;
        public System.Windows.Forms.Label loptPLID;
        internal System.Windows.Forms.TextBox tManifac;
        internal System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lcbOptGrp;
		private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox tKey;
        private System.Windows.Forms.PictureBox picDely;
		private System.Windows.Forms.Label r_tOptCmnt;
		private System.Windows.Forms.Label lImpNB;
        internal System.Windows.Forms.Button btnImport;
		private System.Windows.Forms.Button button2x;
		private System.Windows.Forms.Button button1x;
		private System.Windows.Forms.PictureBox button1;
        private System.Windows.Forms.PictureBox button2ww;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Button eee;
        private System.Windows.Forms.PictureBox btnSkPLcode;
        public System.Windows.Forms.Label lExttt;
        internal System.Windows.Forms.Button btncpycat;
        private Label lCPTname;
        internal Button button2;
        private Button button3;
        public TextBox tFRef;
        public TextBox tERef;
        private GroupBox groupBox3;
        private GroupBox groupBox6;
        private GroupBox groupBox4;
        public TextBox tCat3;
        public TextBox tCat2;
        public TextBox tCat1;
        private PictureBox pictureBox3;
        public Label label17;
        public Label label16;
        public Label label14;
        private Label r_tCat3;
        private Label r_tCat2;
        private Label r_tCat1;
        private CheckBox chk3;
        private CheckBox chk1;
        private CheckBox chk2;
        public Label lCat3;
        public Label lCat2;
        public Label lCat1;
        private GroupBox groupBox5;
        internal TextBox tComnt;
        private Label lCmnt;
        private Label label18;
        private Label lineLID;
        internal Button btnPrintPL;
        private Label r_tComnt;
        public TextBox tPX_code;
        internal Button picDel;
        public RadioButton optFR;
        public RadioButton optEng;
        private Label r_tCat7fr;
        private Label r_tCat6fr;
        private Label r_tCat5fr;
        private Label r_tCat4fr;
        internal Button btnConsOK;
        private PictureBox pictureBox2;
        private Button btnClear;
        private PictureBox pictureBox1;
        internal Button btnOK;
        internal Button btnConsCancel;
        internal TextBox tCat7fr;
        internal TextBox tCat6fr;
        internal TextBox tCat5fr;
        internal TextBox tCat4fr;
        public Label lConsopt;
        public TextBox lFullDesc;
        private Label label13;
        private Label r_tCat7;
        private Label r_tCat6;
        private Label r_tCat5;
        private Label r_tCat4;
        private Label label15;
        private Label label12;
        private Label label11;
        private Label label7;
        public CheckBox chk7;
        internal TextBox tCat7;
        public CheckBox chk6;
        public CheckBox chk5;
        public CheckBox chk4;
        internal TextBox tCat6;
        internal TextBox tCat5;
        internal TextBox tCat4;
        private GroupBox groupBox7;
        public ListView lvOptPricelst;
        private ColumnHeader fullDesc;
        private ColumnHeader Cat1;
        private ColumnHeader Cat2;
        private ColumnHeader Cat3;
        private ColumnHeader Cat_Uprice;
        private ColumnHeader Cost;
        private ColumnHeader Sell;
        private ColumnHeader LeadTime;
        private ColumnHeader LID;
        private ColumnHeader plcode;
        private Label loptID_orig;
        internal TextBox tSellFac;
        private Label lSellFac;
        internal TextBox tCostFac;
        public TextBox lExt;
        public TextBox tPx;
        internal TextBox tOptCmnt;
        public TextBox tSort;
        private GroupBox grpOptionType;
        internal Button btnCancelOpt;
        internal Button btnSavOpt;
        private GroupBox groupBox8;
        private CheckBox chkDef;
        private CheckBox chkhide;
        private GroupBox groupBox9;
        private RadioButton optBaS;
        private RadioButton optPrimax;
        private RadioButton radioButton1;
        private Label cbndx;
        private Label label1;
        private Label label9;
        public TextBox textBox1;
        internal TextBox tOptqty;
        public TextBox tDlvDelay;
        public TextBox tUPrice;
        private Label lblPrice;
        public TextBox textBox2;
        private Label label6;
        public TextBox BOM;
        private Label label8;
        private Label label5;
        public TextBox Mdrw;
        internal Button btnFixCost;
        internal Button button4;
        internal Button button5;
        internal Button button6;
        public TextBox tCostUP;
        private Label label10;
        private Label r_tcostUP;
        public PictureBox picCIP;
        private Label lCostFac;
        internal Button button7;
        internal Button btnPref;
        private Label lPriority;
        internal TextBox tPriority;
        private Button button8;
        private CheckBox chk_ALLCpts;
        internal Button btn_PL_BACK_ORIG;
        internal Button button9;
        private Label label21;
        internal Button button10;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Options_Admin(char x_Code,string x_cptName)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

		//	lvSorter = new ListViewColumnSorter(); 
		//	this.lvOptPricelst.ListViewItemSorter  = lvSorter ; 
		//	this.lvOptPricelst.Sorting =SortOrder.None ;// .Ascending ;
		//	this.lvOptPricelst.AutoArrange =true; 

			In_user_Name =MainMDI.User ;
			MainMDI.M_stCon =  MainMDI.M_stCon ;
			In_Cpt_Name=x_cptName ;
			In_Opera=x_Code;  //M:Modif from admin dialog.....C: from Charger dialog  ....  A: Add from Quote dialog
			Tools = new Lib1(); 
			if (In_Opera =='C' ) lcbOptGrp.Text = In_Cpt_Name; 
			fill_cboptGrp(In_Cpt_Name);
			disable_Maj();
			
			//if (In_Opera=='N')  MessageBox.Show( "ERROR CODE= N");  //New_Option();
		//	lblPrice.Text = (In_Opera != 'M') ? "Published Price:" : "Catalog Price:";
			picDel.Visible =  (In_Opera=='M');
		//	lvOptPricelst.MultiSelect = !(In_Opera=='M');
            tERef.BackColor = Color.AliceBlue;//(In_Opera=='M') ? Color.Lavender : Color.AliceBlue ;
            tFRef.BackColor = Color.AliceBlue;//(In_Opera=='M') ? Color.Lavender : Color.AliceBlue ;
            tERef.ReadOnly = true;// (In_Opera != 'M');
            tFRef.ReadOnly = true;// (In_Opera!='M');
			clear_scrn();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options_Admin));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.loptID_orig = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.PictureBox();
            this.button2 = new System.Windows.Forms.Button();
            this.lImpNB = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.button2ww = new System.Windows.Forms.PictureBox();
            this.r_tOptCmnt = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tKey = new System.Windows.Forms.TextBox();
            this.lcbOptGrp = new System.Windows.Forms.Label();
            this.r_tFRef = new System.Windows.Forms.Label();
            this.r_tERef = new System.Windows.Forms.Label();
            this.loptID = new System.Windows.Forms.Label();
            this.lOptGrp = new System.Windows.Forms.Label();
            this.cbOptGrp = new System.Windows.Forms.ComboBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.tFRef = new System.Windows.Forms.TextBox();
            this.tERef = new System.Windows.Forms.TextBox();
            this.r_type = new System.Windows.Forms.Label();
            this.ltype = new System.Windows.Forms.Label();
            this.loptPLID = new System.Windows.Forms.Label();
            this.r_tDlvDelay = new System.Windows.Forms.Label();
            this.lManID = new System.Windows.Forms.Label();
            this.lFamID = new System.Windows.Forms.Label();
            this.button2x = new System.Windows.Forms.Button();
            this.button1x = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.grpOptionType = new System.Windows.Forms.GroupBox();
            this.btnCancelOpt = new System.Windows.Forms.Button();
            this.btnSavOpt = new System.Windows.Forms.Button();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.chkDef = new System.Windows.Forms.CheckBox();
            this.chkhide = new System.Windows.Forms.CheckBox();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.optBaS = new System.Windows.Forms.RadioButton();
            this.optPrimax = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.cbndx = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tSort = new System.Windows.Forms.TextBox();
            this.tOptCmnt = new System.Windows.Forms.TextBox();
            this.tPx = new System.Windows.Forms.TextBox();
            this.lExt = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tOptqty = new System.Windows.Forms.TextBox();
            this.lCPTname = new System.Windows.Forms.Label();
            this.lExttt = new System.Windows.Forms.Label();
            this.r_tManifac = new System.Windows.Forms.Label();
            this.r_tPx = new System.Windows.Forms.Label();
            this.picDely = new System.Windows.Forms.PictureBox();
            this.r_tUPrice = new System.Windows.Forms.Label();
            this.tManifac = new System.Windows.Forms.TextBox();
            this.btncpycat = new System.Windows.Forms.Button();
            this.eee = new System.Windows.Forms.Button();
            this.btnSkPLcode = new System.Windows.Forms.PictureBox();
            this.label22 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.button10 = new System.Windows.Forms.Button();
            this.label21 = new System.Windows.Forms.Label();
            this.btn_PL_BACK_ORIG = new System.Windows.Forms.Button();
            this.chk_ALLCpts = new System.Windows.Forms.CheckBox();
            this.r_tcostUP = new System.Windows.Forms.Label();
            this.tCostUP = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tDlvDelay = new System.Windows.Forms.TextBox();
            this.tUPrice = new System.Windows.Forms.TextBox();
            this.lblPrice = new System.Windows.Forms.Label();
            this.tComnt = new System.Windows.Forms.TextBox();
            this.lCmnt = new System.Windows.Forms.Label();
            this.lineLID = new System.Windows.Forms.Label();
            this.btnPrintPL = new System.Windows.Forms.Button();
            this.r_tComnt = new System.Windows.Forms.Label();
            this.picDel = new System.Windows.Forms.Button();
            this.optFR = new System.Windows.Forms.RadioButton();
            this.optEng = new System.Windows.Forms.RadioButton();
            this.r_tCat7fr = new System.Windows.Forms.Label();
            this.r_tCat6fr = new System.Windows.Forms.Label();
            this.r_tCat5fr = new System.Windows.Forms.Label();
            this.r_tCat4fr = new System.Windows.Forms.Label();
            this.btnConsOK = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnConsCancel = new System.Windows.Forms.Button();
            this.tCat7fr = new System.Windows.Forms.TextBox();
            this.tCat6fr = new System.Windows.Forms.TextBox();
            this.tCat5fr = new System.Windows.Forms.TextBox();
            this.tCat4fr = new System.Windows.Forms.TextBox();
            this.lConsopt = new System.Windows.Forms.Label();
            this.lFullDesc = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.r_tCat7 = new System.Windows.Forms.Label();
            this.r_tCat6 = new System.Windows.Forms.Label();
            this.r_tCat5 = new System.Windows.Forms.Label();
            this.r_tCat4 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.chk7 = new System.Windows.Forms.CheckBox();
            this.tCat7 = new System.Windows.Forms.TextBox();
            this.chk6 = new System.Windows.Forms.CheckBox();
            this.chk5 = new System.Windows.Forms.CheckBox();
            this.chk4 = new System.Windows.Forms.CheckBox();
            this.tCat6 = new System.Windows.Forms.TextBox();
            this.tCat5 = new System.Windows.Forms.TextBox();
            this.tCat4 = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.tCat3 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tCat2 = new System.Windows.Forms.TextBox();
            this.BOM = new System.Windows.Forms.TextBox();
            this.tCat1 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.Mdrw = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.tPX_code = new System.Windows.Forms.TextBox();
            this.r_tCat3 = new System.Windows.Forms.Label();
            this.r_tCat2 = new System.Windows.Forms.Label();
            this.r_tCat1 = new System.Windows.Forms.Label();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.lCat3 = new System.Windows.Forms.Label();
            this.lCat2 = new System.Windows.Forms.Label();
            this.lCat1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.button9 = new System.Windows.Forms.Button();
            this.tPriority = new System.Windows.Forms.TextBox();
            this.btnPref = new System.Windows.Forms.Button();
            this.lPriority = new System.Windows.Forms.Label();
            this.lCostFac = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.btnFixCost = new System.Windows.Forms.Button();
            this.tSellFac = new System.Windows.Forms.TextBox();
            this.lSellFac = new System.Windows.Forms.Label();
            this.tCostFac = new System.Windows.Forms.TextBox();
            this.cbPFamily = new System.Windows.Forms.ComboBox();
            this.cbManuf = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.lvOptPricelst = new System.Windows.Forms.ListView();
            this.fullDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cat1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cat2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cat3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cat_Uprice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cost = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sell = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LeadTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.plcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.button2ww)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.grpOptionType.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDely)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSkPLcode)).BeginInit();
            this.groupBox5.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btnImport);
            this.groupBox2.Controls.Add(this.button8);
            this.groupBox2.Controls.Add(this.picCIP);
            this.groupBox2.Controls.Add(this.button4);
            this.groupBox2.Controls.Add(this.loptID_orig);
            this.groupBox2.Controls.Add(this.button3);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.button2);
            this.groupBox2.Controls.Add(this.lImpNB);
            this.groupBox2.Controls.Add(this.label23);
            this.groupBox2.Controls.Add(this.button2ww);
            this.groupBox2.Controls.Add(this.r_tOptCmnt);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tKey);
            this.groupBox2.Controls.Add(this.lcbOptGrp);
            this.groupBox2.Controls.Add(this.r_tFRef);
            this.groupBox2.Controls.Add(this.r_tERef);
            this.groupBox2.Controls.Add(this.loptID);
            this.groupBox2.Controls.Add(this.lOptGrp);
            this.groupBox2.Controls.Add(this.cbOptGrp);
            this.groupBox2.Controls.Add(this.label19);
            this.groupBox2.Controls.Add(this.label20);
            this.groupBox2.Controls.Add(this.tFRef);
            this.groupBox2.Controls.Add(this.tERef);
            this.groupBox2.Controls.Add(this.r_type);
            this.groupBox2.Controls.Add(this.ltype);
            this.groupBox2.Controls.Add(this.loptPLID);
            this.groupBox2.Controls.Add(this.r_tDlvDelay);
            this.groupBox2.Controls.Add(this.lManID);
            this.groupBox2.Controls.Add(this.lFamID);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1131, 69);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btnImport
            // 
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.ForeColor = System.Drawing.Color.Brown;
            this.btnImport.Location = new System.Drawing.Point(664, 8);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(121, 24);
            this.btnImport.TabIndex = 174;
            this.btnImport.Text = "TO BACK_PL";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(875, 13);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(148, 23);
            this.button8.TabIndex = 211;
            this.button8.Text = "BUY &&  RESELL ITEMS";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(791, 10);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(41, 28);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 267;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // button4
            // 
            this.button4.ForeColor = System.Drawing.Color.Green;
            this.button4.Location = new System.Drawing.Point(365, 38);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(43, 24);
            this.button4.TabIndex = 203;
            this.button4.Text = "Edit";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // loptID_orig
            // 
            this.loptID_orig.BackColor = System.Drawing.Color.IndianRed;
            this.loptID_orig.Location = new System.Drawing.Point(969, 16);
            this.loptID_orig.Name = "loptID_orig";
            this.loptID_orig.Size = new System.Drawing.Size(28, 16);
            this.loptID_orig.TabIndex = 184;
            this.loptID_orig.Visible = false;
            // 
            // button3
            // 
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Location = new System.Drawing.Point(328, 7);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(87, 23);
            this.button3.TabIndex = 1;
            this.button3.Text = "Search";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Transparent;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.Location = new System.Drawing.Point(424, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(40, 22);
            this.button1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.button1.TabIndex = 177;
            this.button1.TabStop = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.ForeColor = System.Drawing.Color.Brown;
            this.button2.Location = new System.Drawing.Point(464, 7);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(200, 24);
            this.button2.TabIndex = 183;
            this.button2.Text = "Advanced Search (Desc, PXcode)";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lImpNB
            // 
            this.lImpNB.BackColor = System.Drawing.Color.IndianRed;
            this.lImpNB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lImpNB.ForeColor = System.Drawing.Color.White;
            this.lImpNB.Location = new System.Drawing.Point(720, 12);
            this.lImpNB.Name = "lImpNB";
            this.lImpNB.Size = new System.Drawing.Size(56, 16);
            this.lImpNB.TabIndex = 175;
            this.lImpNB.Text = "0";
            this.lImpNB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lImpNB.Visible = false;
            // 
            // label23
            // 
            this.label23.ForeColor = System.Drawing.Color.Blue;
            this.label23.Location = new System.Drawing.Point(328, 12);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(64, 16);
            this.label23.TabIndex = 182;
            this.label23.Text = "Primax Ref.";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button2ww
            // 
            this.button2ww.BackColor = System.Drawing.Color.Transparent;
            this.button2ww.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button2ww.Image = ((System.Drawing.Image)(resources.GetObject("button2ww.Image")));
            this.button2ww.Location = new System.Drawing.Point(523, 19);
            this.button2ww.Name = "button2ww";
            this.button2ww.Size = new System.Drawing.Size(40, 24);
            this.button2ww.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.button2ww.TabIndex = 179;
            this.button2ww.TabStop = false;
            this.button2ww.Visible = false;
            this.button2ww.Click += new System.EventHandler(this.button2_Click);
            // 
            // r_tOptCmnt
            // 
            this.r_tOptCmnt.BackColor = System.Drawing.Color.IndianRed;
            this.r_tOptCmnt.Location = new System.Drawing.Point(856, 8);
            this.r_tOptCmnt.Name = "r_tOptCmnt";
            this.r_tOptCmnt.Size = new System.Drawing.Size(8, 16);
            this.r_tOptCmnt.TabIndex = 173;
            this.r_tOptCmnt.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(0, 10);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 153;
            this.label4.Text = "Keyword:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.PeachPuff;
            this.tKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.ForeColor = System.Drawing.Color.Black;
            this.tKey.Location = new System.Drawing.Point(80, 8);
            this.tKey.MaxLength = 60;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(248, 20);
            this.tKey.TabIndex = 0;
            this.tKey.TextChanged += new System.EventHandler(this.tKey_TextChanged);
            // 
            // lcbOptGrp
            // 
            this.lcbOptGrp.BackColor = System.Drawing.Color.YellowGreen;
            this.lcbOptGrp.Location = new System.Drawing.Point(917, 12);
            this.lcbOptGrp.Name = "lcbOptGrp";
            this.lcbOptGrp.Size = new System.Drawing.Size(16, 24);
            this.lcbOptGrp.TabIndex = 151;
            this.lcbOptGrp.Visible = false;
            // 
            // r_tFRef
            // 
            this.r_tFRef.BackColor = System.Drawing.Color.IndianRed;
            this.r_tFRef.Location = new System.Drawing.Point(880, 80);
            this.r_tFRef.Name = "r_tFRef";
            this.r_tFRef.Size = new System.Drawing.Size(8, 16);
            this.r_tFRef.TabIndex = 148;
            this.r_tFRef.Visible = false;
            // 
            // r_tERef
            // 
            this.r_tERef.BackColor = System.Drawing.Color.IndianRed;
            this.r_tERef.Location = new System.Drawing.Point(382, 28);
            this.r_tERef.Name = "r_tERef";
            this.r_tERef.Size = new System.Drawing.Size(8, 16);
            this.r_tERef.TabIndex = 147;
            this.r_tERef.Visible = false;
            // 
            // loptID
            // 
            this.loptID.BackColor = System.Drawing.Color.YellowGreen;
            this.loptID.Location = new System.Drawing.Point(792, 32);
            this.loptID.Name = "loptID";
            this.loptID.Size = new System.Drawing.Size(16, 16);
            this.loptID.TabIndex = 133;
            this.loptID.Visible = false;
            // 
            // lOptGrp
            // 
            this.lOptGrp.Location = new System.Drawing.Point(16, 40);
            this.lOptGrp.Name = "lOptGrp";
            this.lOptGrp.Size = new System.Drawing.Size(64, 20);
            this.lOptGrp.TabIndex = 132;
            this.lOptGrp.Text = "Primax Ref:";
            this.lOptGrp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbOptGrp
            // 
            this.cbOptGrp.BackColor = System.Drawing.Color.Lavender;
            this.cbOptGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbOptGrp.Location = new System.Drawing.Point(80, 40);
            this.cbOptGrp.Name = "cbOptGrp";
            this.cbOptGrp.Size = new System.Drawing.Size(275, 21);
            this.cbOptGrp.TabIndex = 1;
            this.cbOptGrp.SelectedIndexChanged += new System.EventHandler(this.cbOptGrp_SelectedIndexChanged);
            this.cbOptGrp.SelectedValueChanged += new System.EventHandler(this.cbOptGrp_SelectedValueChanged);
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(428, 40);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(46, 20);
            this.label19.TabIndex = 114;
            this.label19.Text = "&English:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Location = new System.Drawing.Point(730, 40);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(45, 20);
            this.label20.TabIndex = 113;
            this.label20.Text = "French:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tFRef
            // 
            this.tFRef.BackColor = System.Drawing.Color.AliceBlue;
            this.tFRef.Location = new System.Drawing.Point(775, 40);
            this.tFRef.MaxLength = 60;
            this.tFRef.Multiline = true;
            this.tFRef.Name = "tFRef";
            this.tFRef.ReadOnly = true;
            this.tFRef.Size = new System.Drawing.Size(256, 20);
            this.tFRef.TabIndex = 3;
            // 
            // tERef
            // 
            this.tERef.BackColor = System.Drawing.Color.AliceBlue;
            this.tERef.Location = new System.Drawing.Point(474, 40);
            this.tERef.MaxLength = 60;
            this.tERef.Multiline = true;
            this.tERef.Name = "tERef";
            this.tERef.ReadOnly = true;
            this.tERef.Size = new System.Drawing.Size(256, 20);
            this.tERef.TabIndex = 2;
            // 
            // r_type
            // 
            this.r_type.BackColor = System.Drawing.Color.IndianRed;
            this.r_type.Location = new System.Drawing.Point(880, 24);
            this.r_type.Name = "r_type";
            this.r_type.Size = new System.Drawing.Size(16, 16);
            this.r_type.TabIndex = 140;
            this.r_type.Visible = false;
            // 
            // ltype
            // 
            this.ltype.BackColor = System.Drawing.Color.IndianRed;
            this.ltype.Location = new System.Drawing.Point(896, 40);
            this.ltype.Name = "ltype";
            this.ltype.Size = new System.Drawing.Size(16, 16);
            this.ltype.TabIndex = 139;
            this.ltype.Visible = false;
            // 
            // loptPLID
            // 
            this.loptPLID.BackColor = System.Drawing.Color.YellowGreen;
            this.loptPLID.Location = new System.Drawing.Point(816, 40);
            this.loptPLID.Name = "loptPLID";
            this.loptPLID.Size = new System.Drawing.Size(16, 16);
            this.loptPLID.TabIndex = 145;
            this.loptPLID.Visible = false;
            // 
            // r_tDlvDelay
            // 
            this.r_tDlvDelay.BackColor = System.Drawing.Color.IndianRed;
            this.r_tDlvDelay.Location = new System.Drawing.Point(840, 40);
            this.r_tDlvDelay.Name = "r_tDlvDelay";
            this.r_tDlvDelay.Size = new System.Drawing.Size(8, 16);
            this.r_tDlvDelay.TabIndex = 147;
            this.r_tDlvDelay.Visible = false;
            // 
            // lManID
            // 
            this.lManID.BackColor = System.Drawing.Color.YellowGreen;
            this.lManID.Location = new System.Drawing.Point(864, 40);
            this.lManID.Name = "lManID";
            this.lManID.Size = new System.Drawing.Size(8, 16);
            this.lManID.TabIndex = 160;
            this.lManID.Visible = false;
            // 
            // lFamID
            // 
            this.lFamID.BackColor = System.Drawing.Color.YellowGreen;
            this.lFamID.Location = new System.Drawing.Point(736, 40);
            this.lFamID.Name = "lFamID";
            this.lFamID.Size = new System.Drawing.Size(8, 16);
            this.lFamID.TabIndex = 161;
            this.lFamID.Visible = false;
            // 
            // button2x
            // 
            this.button2x.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2x.Location = new System.Drawing.Point(24, 134);
            this.button2x.Name = "button2x";
            this.button2x.Size = new System.Drawing.Size(40, 24);
            this.button2x.TabIndex = 156;
            this.button2x.Text = "CPT Description";
            this.button2x.Visible = false;
            this.button2x.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1x
            // 
            this.button1x.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1x.Location = new System.Drawing.Point(64, 134);
            this.button1x.Name = "button1x";
            this.button1x.Size = new System.Drawing.Size(27, 24);
            this.button1x.TabIndex = 155;
            this.button1x.Text = "Primax Ref.";
            this.button1x.Visible = false;
            this.button1x.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox6);
            this.groupBox1.Controls.Add(this.groupBox5);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Controls.Add(this.groupBox3);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 69);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1131, 301);
            this.groupBox1.TabIndex = 3;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter_1);
            // 
            // groupBox6
            // 
            this.groupBox6.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.groupBox6.Controls.Add(this.grpOptionType);
            this.groupBox6.Controls.Add(this.tSort);
            this.groupBox6.Controls.Add(this.tOptCmnt);
            this.groupBox6.Controls.Add(this.tPx);
            this.groupBox6.Controls.Add(this.lExt);
            this.groupBox6.Controls.Add(this.btnCancel);
            this.groupBox6.Controls.Add(this.textBox1);
            this.groupBox6.Controls.Add(this.tOptqty);
            this.groupBox6.Controls.Add(this.lCPTname);
            this.groupBox6.Controls.Add(this.lExttt);
            this.groupBox6.Controls.Add(this.r_tManifac);
            this.groupBox6.Controls.Add(this.r_tPx);
            this.groupBox6.Controls.Add(this.picDely);
            this.groupBox6.Controls.Add(this.r_tUPrice);
            this.groupBox6.Controls.Add(this.tManifac);
            this.groupBox6.Controls.Add(this.btncpycat);
            this.groupBox6.Controls.Add(this.eee);
            this.groupBox6.Controls.Add(this.button2x);
            this.groupBox6.Controls.Add(this.button1x);
            this.groupBox6.Controls.Add(this.btnSkPLcode);
            this.groupBox6.Controls.Add(this.label22);
            this.groupBox6.Location = new System.Drawing.Point(116, 325);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(871, 132);
            this.groupBox6.TabIndex = 197;
            this.groupBox6.TabStop = false;
            this.groupBox6.Text = "groupBox6";
            this.groupBox6.Visible = false;
            // 
            // grpOptionType
            // 
            this.grpOptionType.Controls.Add(this.btnCancelOpt);
            this.grpOptionType.Controls.Add(this.btnSavOpt);
            this.grpOptionType.Controls.Add(this.groupBox8);
            this.grpOptionType.Controls.Add(this.groupBox9);
            this.grpOptionType.Controls.Add(this.cbndx);
            this.grpOptionType.Controls.Add(this.label1);
            this.grpOptionType.Location = new System.Drawing.Point(663, 14);
            this.grpOptionType.Name = "grpOptionType";
            this.grpOptionType.Size = new System.Drawing.Size(38, 34);
            this.grpOptionType.TabIndex = 205;
            this.grpOptionType.TabStop = false;
            // 
            // btnCancelOpt
            // 
            this.btnCancelOpt.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancelOpt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancelOpt.Location = new System.Drawing.Point(56, 8);
            this.btnCancelOpt.Name = "btnCancelOpt";
            this.btnCancelOpt.Size = new System.Drawing.Size(16, 24);
            this.btnCancelOpt.TabIndex = 167;
            this.btnCancelOpt.Text = "&Cancel";
            this.btnCancelOpt.Visible = false;
            // 
            // btnSavOpt
            // 
            this.btnSavOpt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSavOpt.Location = new System.Drawing.Point(4, 9);
            this.btnSavOpt.Name = "btnSavOpt";
            this.btnSavOpt.Size = new System.Drawing.Size(72, 64);
            this.btnSavOpt.TabIndex = 166;
            this.btnSavOpt.Text = " Save component Info";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.chkDef);
            this.groupBox8.Controls.Add(this.chkhide);
            this.groupBox8.Location = new System.Drawing.Point(80, 48);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(304, 24);
            this.groupBox8.TabIndex = 165;
            this.groupBox8.TabStop = false;
            // 
            // chkDef
            // 
            this.chkDef.BackColor = System.Drawing.Color.Transparent;
            this.chkDef.ForeColor = System.Drawing.Color.Red;
            this.chkDef.Location = new System.Drawing.Point(8, 7);
            this.chkDef.Name = "chkDef";
            this.chkDef.Size = new System.Drawing.Size(160, 16);
            this.chkDef.TabIndex = 138;
            this.chkDef.Text = "Default option for Chargers";
            this.chkDef.UseVisualStyleBackColor = false;
            // 
            // chkhide
            // 
            this.chkhide.BackColor = System.Drawing.Color.Transparent;
            this.chkhide.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkhide.Checked = true;
            this.chkhide.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkhide.ForeColor = System.Drawing.Color.Red;
            this.chkhide.Location = new System.Drawing.Point(200, 7);
            this.chkhide.Name = "chkhide";
            this.chkhide.Size = new System.Drawing.Size(96, 16);
            this.chkhide.TabIndex = 191;
            this.chkhide.Text = "Hide to sales";
            this.chkhide.UseVisualStyleBackColor = false;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.optBaS);
            this.groupBox9.Controls.Add(this.optPrimax);
            this.groupBox9.Controls.Add(this.radioButton1);
            this.groupBox9.Location = new System.Drawing.Point(80, 8);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(304, 40);
            this.groupBox9.TabIndex = 164;
            this.groupBox9.TabStop = false;
            // 
            // optBaS
            // 
            this.optBaS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optBaS.Location = new System.Drawing.Point(160, 16);
            this.optBaS.Name = "optBaS";
            this.optBaS.Size = new System.Drawing.Size(104, 16);
            this.optBaS.TabIndex = 138;
            this.optBaS.Text = "Buy and Resell";
            this.optBaS.Visible = false;
            // 
            // optPrimax
            // 
            this.optPrimax.Checked = true;
            this.optPrimax.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.optPrimax.Location = new System.Drawing.Point(16, 16);
            this.optPrimax.Name = "optPrimax";
            this.optPrimax.Size = new System.Drawing.Size(96, 16);
            this.optPrimax.TabIndex = 137;
            this.optPrimax.TabStop = true;
            this.optPrimax.Text = "Primax Product";
            // 
            // radioButton1
            // 
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton1.Location = new System.Drawing.Point(248, 16);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(80, 16);
            this.radioButton1.TabIndex = 139;
            this.radioButton1.Text = "Private";
            this.radioButton1.Visible = false;
            // 
            // cbndx
            // 
            this.cbndx.BackColor = System.Drawing.Color.YellowGreen;
            this.cbndx.Location = new System.Drawing.Point(552, 32);
            this.cbndx.Name = "cbndx";
            this.cbndx.Size = new System.Drawing.Size(32, 16);
            this.cbndx.TabIndex = 154;
            this.cbndx.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.YellowGreen;
            this.label1.Location = new System.Drawing.Point(560, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 16);
            this.label1.TabIndex = 150;
            this.label1.Visible = false;
            // 
            // tSort
            // 
            this.tSort.BackColor = System.Drawing.SystemColors.Control;
            this.tSort.Location = new System.Drawing.Point(755, 14);
            this.tSort.MaxLength = 3;
            this.tSort.Name = "tSort";
            this.tSort.ReadOnly = true;
            this.tSort.Size = new System.Drawing.Size(26, 20);
            this.tSort.TabIndex = 204;
            // 
            // tOptCmnt
            // 
            this.tOptCmnt.AcceptsReturn = true;
            this.tOptCmnt.BackColor = System.Drawing.Color.Lavender;
            this.tOptCmnt.Location = new System.Drawing.Point(719, 10);
            this.tOptCmnt.MaxLength = 250;
            this.tOptCmnt.Name = "tOptCmnt";
            this.tOptCmnt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tOptCmnt.Size = new System.Drawing.Size(30, 20);
            this.tOptCmnt.TabIndex = 203;
            // 
            // tPx
            // 
            this.tPx.BackColor = System.Drawing.Color.Lavender;
            this.tPx.Location = new System.Drawing.Point(776, 62);
            this.tPx.MaxLength = 50;
            this.tPx.Name = "tPx";
            this.tPx.Size = new System.Drawing.Size(43, 20);
            this.tPx.TabIndex = 200;
            // 
            // lExt
            // 
            this.lExt.BackColor = System.Drawing.Color.AliceBlue;
            this.lExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lExt.ForeColor = System.Drawing.Color.Red;
            this.lExt.Location = new System.Drawing.Point(894, 69);
            this.lExt.MaxLength = 15;
            this.lExt.Name = "lExt";
            this.lExt.ReadOnly = true;
            this.lExt.Size = new System.Drawing.Size(50, 20);
            this.lExt.TabIndex = 199;
            this.lExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(80, 40);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(35, 24);
            this.btnCancel.TabIndex = 177;
            this.btnCancel.Text = "&Finish";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Red;
            this.textBox1.Location = new System.Drawing.Point(576, 25);
            this.textBox1.MaxLength = 15;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(19, 20);
            this.textBox1.TabIndex = 204;
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tOptqty
            // 
            this.tOptqty.BackColor = System.Drawing.Color.Lavender;
            this.tOptqty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tOptqty.Location = new System.Drawing.Point(601, 23);
            this.tOptqty.MaxLength = 8;
            this.tOptqty.Multiline = true;
            this.tOptqty.Name = "tOptqty";
            this.tOptqty.Size = new System.Drawing.Size(32, 20);
            this.tOptqty.TabIndex = 201;
            this.tOptqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tOptqty.TextChanged += new System.EventHandler(this.tOptqty_TextChanged);
            // 
            // lCPTname
            // 
            this.lCPTname.BackColor = System.Drawing.Color.IndianRed;
            this.lCPTname.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lCPTname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCPTname.ForeColor = System.Drawing.Color.White;
            this.lCPTname.Location = new System.Drawing.Point(161, 48);
            this.lCPTname.Name = "lCPTname";
            this.lCPTname.Size = new System.Drawing.Size(28, 16);
            this.lCPTname.TabIndex = 195;
            this.lCPTname.Text = "0";
            this.lCPTname.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lCPTname.Visible = false;
            // 
            // lExttt
            // 
            this.lExttt.BackColor = System.Drawing.Color.AliceBlue;
            this.lExttt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lExttt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lExttt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lExttt.ForeColor = System.Drawing.Color.Red;
            this.lExttt.Location = new System.Drawing.Point(59, 8);
            this.lExttt.Name = "lExttt";
            this.lExttt.Size = new System.Drawing.Size(24, 13);
            this.lExttt.TabIndex = 181;
            this.lExttt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // r_tManifac
            // 
            this.r_tManifac.BackColor = System.Drawing.Color.IndianRed;
            this.r_tManifac.Location = new System.Drawing.Point(112, 14);
            this.r_tManifac.Name = "r_tManifac";
            this.r_tManifac.Size = new System.Drawing.Size(24, 16);
            this.r_tManifac.TabIndex = 150;
            this.r_tManifac.Visible = false;
            // 
            // r_tPx
            // 
            this.r_tPx.BackColor = System.Drawing.Color.IndianRed;
            this.r_tPx.Location = new System.Drawing.Point(37, 40);
            this.r_tPx.Name = "r_tPx";
            this.r_tPx.Size = new System.Drawing.Size(8, 16);
            this.r_tPx.TabIndex = 149;
            this.r_tPx.Visible = false;
            // 
            // picDely
            // 
            this.picDely.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDely.Image = ((System.Drawing.Image)(resources.GetObject("picDely.Image")));
            this.picDely.Location = new System.Drawing.Point(142, 63);
            this.picDely.Name = "picDely";
            this.picDely.Size = new System.Drawing.Size(16, 24);
            this.picDely.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDely.TabIndex = 182;
            this.picDely.TabStop = false;
            this.picDely.Visible = false;
            this.picDely.Click += new System.EventHandler(this.picDel_Click);
            // 
            // r_tUPrice
            // 
            this.r_tUPrice.BackColor = System.Drawing.Color.IndianRed;
            this.r_tUPrice.Location = new System.Drawing.Point(128, 54);
            this.r_tUPrice.Name = "r_tUPrice";
            this.r_tUPrice.Size = new System.Drawing.Size(8, 16);
            this.r_tUPrice.TabIndex = 146;
            this.r_tUPrice.Visible = false;
            // 
            // tManifac
            // 
            this.tManifac.BackColor = System.Drawing.Color.IndianRed;
            this.tManifac.Location = new System.Drawing.Point(40, 65);
            this.tManifac.MaxLength = 50;
            this.tManifac.Name = "tManifac";
            this.tManifac.Size = new System.Drawing.Size(16, 20);
            this.tManifac.TabIndex = 7;
            this.tManifac.Visible = false;
            // 
            // btncpycat
            // 
            this.btncpycat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btncpycat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncpycat.Location = new System.Drawing.Point(6, 91);
            this.btncpycat.Name = "btncpycat";
            this.btncpycat.Size = new System.Drawing.Size(133, 20);
            this.btncpycat.TabIndex = 194;
            this.btncpycat.Text = "CopyCate: save same rec + new values";
            this.btncpycat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btncpycat.Visible = false;
            this.btncpycat.Click += new System.EventHandler(this.button3_Click_1);
            // 
            // eee
            // 
            this.eee.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.eee.Location = new System.Drawing.Point(91, 133);
            this.eee.Name = "eee";
            this.eee.Size = new System.Drawing.Size(33, 24);
            this.eee.TabIndex = 176;
            this.eee.Text = "Primax code";
            this.eee.Visible = false;
            // 
            // btnSkPLcode
            // 
            this.btnSkPLcode.BackColor = System.Drawing.Color.Transparent;
            this.btnSkPLcode.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSkPLcode.Image = ((System.Drawing.Image)(resources.GetObject("btnSkPLcode.Image")));
            this.btnSkPLcode.Location = new System.Drawing.Point(149, 112);
            this.btnSkPLcode.Name = "btnSkPLcode";
            this.btnSkPLcode.Size = new System.Drawing.Size(40, 24);
            this.btnSkPLcode.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnSkPLcode.TabIndex = 178;
            this.btnSkPLcode.TabStop = false;
            this.btnSkPLcode.Visible = false;
            // 
            // label22
            // 
            this.label22.ForeColor = System.Drawing.Color.Blue;
            this.label22.Location = new System.Drawing.Point(117, 143);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(72, 20);
            this.label22.TabIndex = 181;
            this.label22.Text = "Primax code";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label22.Visible = false;
            this.label22.Click += new System.EventHandler(this.label22_Click);
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.button10);
            this.groupBox5.Controls.Add(this.label21);
            this.groupBox5.Controls.Add(this.btn_PL_BACK_ORIG);
            this.groupBox5.Controls.Add(this.chk_ALLCpts);
            this.groupBox5.Controls.Add(this.r_tcostUP);
            this.groupBox5.Controls.Add(this.tCostUP);
            this.groupBox5.Controls.Add(this.label10);
            this.groupBox5.Controls.Add(this.label9);
            this.groupBox5.Controls.Add(this.tDlvDelay);
            this.groupBox5.Controls.Add(this.tUPrice);
            this.groupBox5.Controls.Add(this.lblPrice);
            this.groupBox5.Controls.Add(this.tComnt);
            this.groupBox5.Controls.Add(this.lCmnt);
            this.groupBox5.Controls.Add(this.lineLID);
            this.groupBox5.Controls.Add(this.btnPrintPL);
            this.groupBox5.Controls.Add(this.r_tComnt);
            this.groupBox5.Controls.Add(this.picDel);
            this.groupBox5.Controls.Add(this.optFR);
            this.groupBox5.Controls.Add(this.optEng);
            this.groupBox5.Controls.Add(this.r_tCat7fr);
            this.groupBox5.Controls.Add(this.r_tCat6fr);
            this.groupBox5.Controls.Add(this.r_tCat5fr);
            this.groupBox5.Controls.Add(this.r_tCat4fr);
            this.groupBox5.Controls.Add(this.btnConsOK);
            this.groupBox5.Controls.Add(this.pictureBox2);
            this.groupBox5.Controls.Add(this.btnClear);
            this.groupBox5.Controls.Add(this.pictureBox1);
            this.groupBox5.Controls.Add(this.btnOK);
            this.groupBox5.Controls.Add(this.btnConsCancel);
            this.groupBox5.Controls.Add(this.tCat7fr);
            this.groupBox5.Controls.Add(this.tCat6fr);
            this.groupBox5.Controls.Add(this.tCat5fr);
            this.groupBox5.Controls.Add(this.tCat4fr);
            this.groupBox5.Controls.Add(this.lConsopt);
            this.groupBox5.Controls.Add(this.lFullDesc);
            this.groupBox5.Controls.Add(this.label13);
            this.groupBox5.Controls.Add(this.r_tCat7);
            this.groupBox5.Controls.Add(this.r_tCat6);
            this.groupBox5.Controls.Add(this.r_tCat5);
            this.groupBox5.Controls.Add(this.r_tCat4);
            this.groupBox5.Controls.Add(this.label15);
            this.groupBox5.Controls.Add(this.label12);
            this.groupBox5.Controls.Add(this.label11);
            this.groupBox5.Controls.Add(this.label7);
            this.groupBox5.Controls.Add(this.chk7);
            this.groupBox5.Controls.Add(this.tCat7);
            this.groupBox5.Controls.Add(this.chk6);
            this.groupBox5.Controls.Add(this.chk5);
            this.groupBox5.Controls.Add(this.chk4);
            this.groupBox5.Controls.Add(this.tCat6);
            this.groupBox5.Controls.Add(this.tCat5);
            this.groupBox5.Controls.Add(this.tCat4);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox5.Location = new System.Drawing.Point(3, 153);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(1125, 138);
            this.groupBox5.TabIndex = 198;
            this.groupBox5.TabStop = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.Gold;
            this.button10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Location = new System.Drawing.Point(1039, 14);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(48, 24);
            this.button10.TabIndex = 274;
            this.button10.Text = "DF";
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Visible = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Yellow;
            this.label21.Location = new System.Drawing.Point(1075, 120);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(232, 16);
            this.label21.TabIndex = 206;
            this.label21.Text = "Cell contains more Text than displayed !!!";
            // 
            // btn_PL_BACK_ORIG
            // 
            this.btn_PL_BACK_ORIG.BackColor = System.Drawing.Color.ForestGreen;
            this.btn_PL_BACK_ORIG.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_PL_BACK_ORIG.ForeColor = System.Drawing.Color.White;
            this.btn_PL_BACK_ORIG.Location = new System.Drawing.Point(808, 116);
            this.btn_PL_BACK_ORIG.Name = "btn_PL_BACK_ORIG";
            this.btn_PL_BACK_ORIG.Size = new System.Drawing.Size(121, 24);
            this.btn_PL_BACK_ORIG.TabIndex = 205;
            this.btn_PL_BACK_ORIG.Text = "update BACKUP";
            this.btn_PL_BACK_ORIG.UseVisualStyleBackColor = false;
            this.btn_PL_BACK_ORIG.Click += new System.EventHandler(this.btn_PL_BACK_ORIG_Click);
            // 
            // chk_ALLCpts
            // 
            this.chk_ALLCpts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chk_ALLCpts.Location = new System.Drawing.Point(935, 117);
            this.chk_ALLCpts.Name = "chk_ALLCpts";
            this.chk_ALLCpts.Size = new System.Drawing.Size(93, 16);
            this.chk_ALLCpts.TabIndex = 204;
            this.chk_ALLCpts.Text = "ALL Cpts";
            // 
            // r_tcostUP
            // 
            this.r_tcostUP.BackColor = System.Drawing.Color.IndianRed;
            this.r_tcostUP.Location = new System.Drawing.Point(507, 116);
            this.r_tcostUP.Name = "r_tcostUP";
            this.r_tcostUP.Size = new System.Drawing.Size(8, 16);
            this.r_tcostUP.TabIndex = 203;
            this.r_tcostUP.Visible = false;
            // 
            // tCostUP
            // 
            this.tCostUP.BackColor = System.Drawing.Color.Lavender;
            this.tCostUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCostUP.ForeColor = System.Drawing.Color.Red;
            this.tCostUP.Location = new System.Drawing.Point(287, 116);
            this.tCostUP.MaxLength = 15;
            this.tCostUP.Name = "tCostUP";
            this.tCostUP.Size = new System.Drawing.Size(72, 20);
            this.tCostUP.TabIndex = 201;
            this.tCostUP.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Blue;
            this.label10.Location = new System.Drawing.Point(176, 118);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(111, 16);
            this.label10.TabIndex = 202;
            this.label10.Text = "Cost Unit Price:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.ForeColor = System.Drawing.Color.Blue;
            this.label9.Location = new System.Drawing.Point(359, 118);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(58, 16);
            this.label9.TabIndex = 200;
            this.label9.Text = "Lead Time:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tDlvDelay
            // 
            this.tDlvDelay.BackColor = System.Drawing.Color.Lavender;
            this.tDlvDelay.Location = new System.Drawing.Point(417, 116);
            this.tDlvDelay.MaxLength = 8;
            this.tDlvDelay.Name = "tDlvDelay";
            this.tDlvDelay.ReadOnly = true;
            this.tDlvDelay.Size = new System.Drawing.Size(48, 20);
            this.tDlvDelay.TabIndex = 198;
            this.tDlvDelay.Text = "04-06";
            // 
            // tUPrice
            // 
            this.tUPrice.BackColor = System.Drawing.Color.Lavender;
            this.tUPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tUPrice.ForeColor = System.Drawing.Color.Red;
            this.tUPrice.Location = new System.Drawing.Point(104, 116);
            this.tUPrice.MaxLength = 15;
            this.tUPrice.Name = "tUPrice";
            this.tUPrice.Size = new System.Drawing.Size(72, 20);
            this.tUPrice.TabIndex = 197;
            this.tUPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tUPrice.TextChanged += new System.EventHandler(this.tUPrice_TextChanged);
            // 
            // lblPrice
            // 
            this.lblPrice.BackColor = System.Drawing.SystemColors.Control;
            this.lblPrice.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPrice.ForeColor = System.Drawing.Color.Blue;
            this.lblPrice.Location = new System.Drawing.Point(19, 118);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(85, 16);
            this.lblPrice.TabIndex = 199;
            this.lblPrice.Text = "Sell Unit Price:";
            this.lblPrice.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tComnt
            // 
            this.tComnt.BackColor = System.Drawing.Color.Lavender;
            this.tComnt.Location = new System.Drawing.Point(674, 28);
            this.tComnt.MaxLength = 250;
            this.tComnt.Multiline = true;
            this.tComnt.Name = "tComnt";
            this.tComnt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tComnt.Size = new System.Drawing.Size(255, 63);
            this.tComnt.TabIndex = 196;
            // 
            // lCmnt
            // 
            this.lCmnt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lCmnt.ForeColor = System.Drawing.Color.Black;
            this.lCmnt.Location = new System.Drawing.Point(753, 14);
            this.lCmnt.Name = "lCmnt";
            this.lCmnt.Size = new System.Drawing.Size(56, 16);
            this.lCmnt.TabIndex = 195;
            this.lCmnt.Text = "Comments:";
            this.lCmnt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lineLID
            // 
            this.lineLID.BackColor = System.Drawing.Color.Salmon;
            this.lineLID.Location = new System.Drawing.Point(670, 12);
            this.lineLID.Name = "lineLID";
            this.lineLID.Size = new System.Drawing.Size(27, 13);
            this.lineLID.TabIndex = 186;
            this.lineLID.Visible = false;
            // 
            // btnPrintPL
            // 
            this.btnPrintPL.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrintPL.ForeColor = System.Drawing.Color.Brown;
            this.btnPrintPL.Location = new System.Drawing.Point(935, 93);
            this.btnPrintPL.Name = "btnPrintPL";
            this.btnPrintPL.Size = new System.Drawing.Size(94, 24);
            this.btnPrintPL.TabIndex = 194;
            this.btnPrintPL.Text = "XL LIST";
            this.btnPrintPL.Click += new System.EventHandler(this.btnPrintPL_Click);
            // 
            // r_tComnt
            // 
            this.r_tComnt.BackColor = System.Drawing.Color.IndianRed;
            this.r_tComnt.Location = new System.Drawing.Point(717, 9);
            this.r_tComnt.Name = "r_tComnt";
            this.r_tComnt.Size = new System.Drawing.Size(8, 16);
            this.r_tComnt.TabIndex = 148;
            this.r_tComnt.Visible = false;
            // 
            // picDel
            // 
            this.picDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.picDel.Location = new System.Drawing.Point(935, 10);
            this.picDel.Name = "picDel";
            this.picDel.Size = new System.Drawing.Size(88, 22);
            this.picDel.TabIndex = 190;
            this.picDel.Text = "&Delete";
            this.picDel.Visible = false;
            this.picDel.Click += new System.EventHandler(this.picDel_Click);
            // 
            // optFR
            // 
            this.optFR.Location = new System.Drawing.Point(648, 16);
            this.optFR.Name = "optFR";
            this.optFR.Size = new System.Drawing.Size(16, 16);
            this.optFR.TabIndex = 180;
            this.optFR.Text = "radioButton2";
            // 
            // optEng
            // 
            this.optEng.Checked = true;
            this.optEng.Location = new System.Drawing.Point(16, 16);
            this.optEng.Name = "optEng";
            this.optEng.Size = new System.Drawing.Size(16, 16);
            this.optEng.TabIndex = 179;
            this.optEng.TabStop = true;
            this.optEng.Text = "radioButton1";
            // 
            // r_tCat7fr
            // 
            this.r_tCat7fr.BackColor = System.Drawing.Color.IndianRed;
            this.r_tCat7fr.Location = new System.Drawing.Point(632, 80);
            this.r_tCat7fr.Name = "r_tCat7fr";
            this.r_tCat7fr.Size = new System.Drawing.Size(8, 16);
            this.r_tCat7fr.TabIndex = 178;
            this.r_tCat7fr.Visible = false;
            // 
            // r_tCat6fr
            // 
            this.r_tCat6fr.BackColor = System.Drawing.Color.IndianRed;
            this.r_tCat6fr.Location = new System.Drawing.Point(632, 64);
            this.r_tCat6fr.Name = "r_tCat6fr";
            this.r_tCat6fr.Size = new System.Drawing.Size(8, 12);
            this.r_tCat6fr.TabIndex = 177;
            this.r_tCat6fr.Visible = false;
            // 
            // r_tCat5fr
            // 
            this.r_tCat5fr.BackColor = System.Drawing.Color.IndianRed;
            this.r_tCat5fr.Location = new System.Drawing.Point(632, 40);
            this.r_tCat5fr.Name = "r_tCat5fr";
            this.r_tCat5fr.Size = new System.Drawing.Size(8, 16);
            this.r_tCat5fr.TabIndex = 176;
            this.r_tCat5fr.Visible = false;
            // 
            // r_tCat4fr
            // 
            this.r_tCat4fr.BackColor = System.Drawing.Color.IndianRed;
            this.r_tCat4fr.Location = new System.Drawing.Point(632, 16);
            this.r_tCat4fr.Name = "r_tCat4fr";
            this.r_tCat4fr.Size = new System.Drawing.Size(8, 16);
            this.r_tCat4fr.TabIndex = 175;
            this.r_tCat4fr.Visible = false;
            // 
            // btnConsOK
            // 
            this.btnConsOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConsOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnConsOK.Location = new System.Drawing.Point(1029, 45);
            this.btnConsOK.Name = "btnConsOK";
            this.btnConsOK.Size = new System.Drawing.Size(88, 22);
            this.btnConsOK.TabIndex = 173;
            this.btnConsOK.Text = "&OK";
            this.btnConsOK.Visible = false;
            this.btnConsOK.Click += new System.EventHandler(this.btnConsOK_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(644, 40);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(24, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 174;
            this.pictureBox2.TabStop = false;
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Location = new System.Drawing.Point(935, 34);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(88, 22);
            this.btnClear.TabIndex = 178;
            this.btnClear.Text = "&Clear";
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(12, 40);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(24, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 173;
            this.pictureBox1.TabStop = false;
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(935, 62);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(88, 22);
            this.btnOK.TabIndex = 176;
            this.btnOK.Text = "&Save";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnConsCancel
            // 
            this.btnConsCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnConsCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnConsCancel.Location = new System.Drawing.Point(1029, 75);
            this.btnConsCancel.Name = "btnConsCancel";
            this.btnConsCancel.Size = new System.Drawing.Size(88, 22);
            this.btnConsCancel.TabIndex = 174;
            this.btnConsCancel.Text = "&Cancel";
            this.btnConsCancel.Visible = false;
            this.btnConsCancel.Click += new System.EventHandler(this.btnConsCancel_Click);
            // 
            // tCat7fr
            // 
            this.tCat7fr.BackColor = System.Drawing.Color.Khaki;
            this.tCat7fr.Location = new System.Drawing.Point(374, 76);
            this.tCat7fr.MaxLength = 250;
            this.tCat7fr.Name = "tCat7fr";
            this.tCat7fr.ReadOnly = true;
            this.tCat7fr.Size = new System.Drawing.Size(256, 20);
            this.tCat7fr.TabIndex = 172;
            this.tCat7fr.TextChanged += new System.EventHandler(this.tCat7fr_TextChanged);
            // 
            // tCat6fr
            // 
            this.tCat6fr.BackColor = System.Drawing.Color.Lavender;
            this.tCat6fr.Location = new System.Drawing.Point(374, 56);
            this.tCat6fr.MaxLength = 250;
            this.tCat6fr.Name = "tCat6fr";
            this.tCat6fr.Size = new System.Drawing.Size(256, 20);
            this.tCat6fr.TabIndex = 171;
            this.tCat6fr.TextChanged += new System.EventHandler(this.tCat6fr_TextChanged);
            // 
            // tCat5fr
            // 
            this.tCat5fr.BackColor = System.Drawing.Color.Lavender;
            this.tCat5fr.Location = new System.Drawing.Point(374, 36);
            this.tCat5fr.MaxLength = 250;
            this.tCat5fr.Name = "tCat5fr";
            this.tCat5fr.Size = new System.Drawing.Size(256, 20);
            this.tCat5fr.TabIndex = 170;
            this.tCat5fr.TextChanged += new System.EventHandler(this.tCat5fr_TextChanged);
            // 
            // tCat4fr
            // 
            this.tCat4fr.BackColor = System.Drawing.Color.Lavender;
            this.tCat4fr.Location = new System.Drawing.Point(374, 16);
            this.tCat4fr.MaxLength = 250;
            this.tCat4fr.Name = "tCat4fr";
            this.tCat4fr.Size = new System.Drawing.Size(256, 20);
            this.tCat4fr.TabIndex = 169;
            this.tCat4fr.TextChanged += new System.EventHandler(this.tCat4fr_TextChanged);
            // 
            // lConsopt
            // 
            this.lConsopt.BackColor = System.Drawing.Color.IndianRed;
            this.lConsopt.Location = new System.Drawing.Point(648, 64);
            this.lConsopt.Name = "lConsopt";
            this.lConsopt.Size = new System.Drawing.Size(8, 16);
            this.lConsopt.TabIndex = 168;
            this.lConsopt.Text = "N";
            this.lConsopt.Visible = false;
            // 
            // lFullDesc
            // 
            this.lFullDesc.BackColor = System.Drawing.Color.AliceBlue;
            this.lFullDesc.Location = new System.Drawing.Point(104, 96);
            this.lFullDesc.MaxLength = 50;
            this.lFullDesc.Name = "lFullDesc";
            this.lFullDesc.ReadOnly = true;
            this.lFullDesc.Size = new System.Drawing.Size(825, 20);
            this.lFullDesc.TabIndex = 159;
            // 
            // label13
            // 
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.Color.Brown;
            this.label13.Location = new System.Drawing.Point(25, 99);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(79, 14);
            this.label13.TabIndex = 158;
            this.label13.Text = "Description:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // r_tCat7
            // 
            this.r_tCat7.BackColor = System.Drawing.Color.IndianRed;
            this.r_tCat7.Location = new System.Drawing.Point(40, 72);
            this.r_tCat7.Name = "r_tCat7";
            this.r_tCat7.Size = new System.Drawing.Size(8, 16);
            this.r_tCat7.TabIndex = 157;
            this.r_tCat7.Visible = false;
            // 
            // r_tCat6
            // 
            this.r_tCat6.BackColor = System.Drawing.Color.IndianRed;
            this.r_tCat6.Location = new System.Drawing.Point(40, 56);
            this.r_tCat6.Name = "r_tCat6";
            this.r_tCat6.Size = new System.Drawing.Size(8, 12);
            this.r_tCat6.TabIndex = 156;
            this.r_tCat6.Visible = false;
            // 
            // r_tCat5
            // 
            this.r_tCat5.BackColor = System.Drawing.Color.IndianRed;
            this.r_tCat5.Location = new System.Drawing.Point(40, 32);
            this.r_tCat5.Name = "r_tCat5";
            this.r_tCat5.Size = new System.Drawing.Size(8, 16);
            this.r_tCat5.TabIndex = 155;
            this.r_tCat5.Visible = false;
            // 
            // r_tCat4
            // 
            this.r_tCat4.BackColor = System.Drawing.Color.IndianRed;
            this.r_tCat4.Location = new System.Drawing.Point(40, 8);
            this.r_tCat4.Name = "r_tCat4";
            this.r_tCat4.Size = new System.Drawing.Size(8, 16);
            this.r_tCat4.TabIndex = 154;
            this.r_tCat4.Visible = false;
            // 
            // label15
            // 
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(16, 80);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(88, 20);
            this.label15.TabIndex = 135;
            this.label15.Text = "Technical Values:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(56, 58);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 20);
            this.label12.TabIndex = 134;
            this.label12.Text = "Desc #6:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(56, 38);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(48, 20);
            this.label11.TabIndex = 133;
            this.label11.Text = "Desc #5:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(56, 16);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 20);
            this.label7.TabIndex = 132;
            this.label7.Text = "Desc #4:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chk7
            // 
            this.chk7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chk7.Location = new System.Drawing.Point(360, 76);
            this.chk7.Name = "chk7";
            this.chk7.Size = new System.Drawing.Size(16, 20);
            this.chk7.TabIndex = 130;
            this.chk7.CheckedChanged += new System.EventHandler(this.chk7_CheckedChanged);
            // 
            // tCat7
            // 
            this.tCat7.BackColor = System.Drawing.Color.Khaki;
            this.tCat7.Location = new System.Drawing.Point(104, 76);
            this.tCat7.MaxLength = 250;
            this.tCat7.Name = "tCat7";
            this.tCat7.ReadOnly = true;
            this.tCat7.Size = new System.Drawing.Size(256, 20);
            this.tCat7.TabIndex = 14;
            this.tCat7.TextChanged += new System.EventHandler(this.tCat7_TextChanged);
            // 
            // chk6
            // 
            this.chk6.Checked = true;
            this.chk6.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chk6.Location = new System.Drawing.Point(360, 56);
            this.chk6.Name = "chk6";
            this.chk6.Size = new System.Drawing.Size(16, 20);
            this.chk6.TabIndex = 128;
            this.chk6.Visible = false;
            this.chk6.CheckedChanged += new System.EventHandler(this.chk6_CheckedChanged);
            // 
            // chk5
            // 
            this.chk5.Checked = true;
            this.chk5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chk5.Location = new System.Drawing.Point(360, 36);
            this.chk5.Name = "chk5";
            this.chk5.Size = new System.Drawing.Size(16, 20);
            this.chk5.TabIndex = 127;
            this.chk5.Visible = false;
            this.chk5.CheckedChanged += new System.EventHandler(this.chk5_CheckedChanged);
            // 
            // chk4
            // 
            this.chk4.Checked = true;
            this.chk4.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chk4.Location = new System.Drawing.Point(360, 16);
            this.chk4.Name = "chk4";
            this.chk4.Size = new System.Drawing.Size(16, 20);
            this.chk4.TabIndex = 126;
            this.chk4.Visible = false;
            this.chk4.CheckedChanged += new System.EventHandler(this.chk4_CheckedChanged);
            // 
            // tCat6
            // 
            this.tCat6.BackColor = System.Drawing.Color.Lavender;
            this.tCat6.Location = new System.Drawing.Point(104, 56);
            this.tCat6.MaxLength = 250;
            this.tCat6.Name = "tCat6";
            this.tCat6.Size = new System.Drawing.Size(256, 20);
            this.tCat6.TabIndex = 13;
            this.tCat6.TextChanged += new System.EventHandler(this.tCat6_TextChanged);
            // 
            // tCat5
            // 
            this.tCat5.BackColor = System.Drawing.Color.Lavender;
            this.tCat5.Location = new System.Drawing.Point(104, 36);
            this.tCat5.MaxLength = 250;
            this.tCat5.Name = "tCat5";
            this.tCat5.Size = new System.Drawing.Size(256, 20);
            this.tCat5.TabIndex = 12;
            this.tCat5.TextChanged += new System.EventHandler(this.tCat5_TextChanged);
            // 
            // tCat4
            // 
            this.tCat4.BackColor = System.Drawing.Color.Lavender;
            this.tCat4.Location = new System.Drawing.Point(104, 16);
            this.tCat4.MaxLength = 250;
            this.tCat4.Name = "tCat4";
            this.tCat4.Size = new System.Drawing.Size(256, 20);
            this.tCat4.TabIndex = 11;
            this.tCat4.TextChanged += new System.EventHandler(this.tCat4_TextChanged);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.textBox2);
            this.groupBox4.Controls.Add(this.tCat3);
            this.groupBox4.Controls.Add(this.label6);
            this.groupBox4.Controls.Add(this.tCat2);
            this.groupBox4.Controls.Add(this.BOM);
            this.groupBox4.Controls.Add(this.tCat1);
            this.groupBox4.Controls.Add(this.label8);
            this.groupBox4.Controls.Add(this.label18);
            this.groupBox4.Controls.Add(this.label5);
            this.groupBox4.Controls.Add(this.pictureBox3);
            this.groupBox4.Controls.Add(this.Mdrw);
            this.groupBox4.Controls.Add(this.label17);
            this.groupBox4.Controls.Add(this.label16);
            this.groupBox4.Controls.Add(this.label14);
            this.groupBox4.Controls.Add(this.tPX_code);
            this.groupBox4.Controls.Add(this.r_tCat3);
            this.groupBox4.Controls.Add(this.r_tCat2);
            this.groupBox4.Controls.Add(this.r_tCat1);
            this.groupBox4.Controls.Add(this.chk3);
            this.groupBox4.Controls.Add(this.chk1);
            this.groupBox4.Controls.Add(this.chk2);
            this.groupBox4.Controls.Add(this.lCat3);
            this.groupBox4.Controls.Add(this.lCat2);
            this.groupBox4.Controls.Add(this.lCat1);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(3, 87);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1125, 66);
            this.groupBox4.TabIndex = 197;
            this.groupBox4.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.Lavender;
            this.textBox2.Location = new System.Drawing.Point(61, 40);
            this.textBox2.MaxLength = 50;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(200, 20);
            this.textBox2.TabIndex = 205;
            // 
            // tCat3
            // 
            this.tCat3.BackColor = System.Drawing.Color.Lavender;
            this.tCat3.ForeColor = System.Drawing.Color.Black;
            this.tCat3.Location = new System.Drawing.Point(576, 13);
            this.tCat3.MaxLength = 30;
            this.tCat3.Name = "tCat3";
            this.tCat3.Size = new System.Drawing.Size(64, 20);
            this.tCat3.TabIndex = 10;
            this.tCat3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label6
            // 
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(3, 40);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(58, 18);
            this.label6.TabIndex = 206;
            this.label6.Text = "Elec. Drw#:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tCat2
            // 
            this.tCat2.BackColor = System.Drawing.Color.Lavender;
            this.tCat2.ForeColor = System.Drawing.Color.Black;
            this.tCat2.Location = new System.Drawing.Point(360, 13);
            this.tCat2.MaxLength = 30;
            this.tCat2.Name = "tCat2";
            this.tCat2.Size = new System.Drawing.Size(64, 20);
            this.tCat2.TabIndex = 9;
            this.tCat2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // BOM
            // 
            this.BOM.BackColor = System.Drawing.Color.Lavender;
            this.BOM.Location = new System.Drawing.Point(309, 40);
            this.BOM.MaxLength = 50;
            this.BOM.Name = "BOM";
            this.BOM.Size = new System.Drawing.Size(176, 20);
            this.BOM.TabIndex = 210;
            // 
            // tCat1
            // 
            this.tCat1.BackColor = System.Drawing.Color.Lavender;
            this.tCat1.ForeColor = System.Drawing.Color.Black;
            this.tCat1.Location = new System.Drawing.Point(136, 13);
            this.tCat1.MaxLength = 30;
            this.tCat1.Name = "tCat1";
            this.tCat1.Size = new System.Drawing.Size(64, 20);
            this.tCat1.TabIndex = 8;
            this.tCat1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(261, 42);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 209;
            this.label8.Text = "BOM #:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label18.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Brown;
            this.label18.Location = new System.Drawing.Point(741, 42);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(104, 16);
            this.label18.TabIndex = 182;
            this.label18.Text = "Primax Code:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(485, 42);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 207;
            this.label5.Text = "Mecan. Drw#:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(662, 5);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 24);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 185;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // Mdrw
            // 
            this.Mdrw.BackColor = System.Drawing.Color.Lavender;
            this.Mdrw.Location = new System.Drawing.Point(557, 40);
            this.Mdrw.MaxLength = 50;
            this.Mdrw.Name = "Mdrw";
            this.Mdrw.Size = new System.Drawing.Size(184, 20);
            this.Mdrw.TabIndex = 208;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label17.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label17.Location = new System.Drawing.Point(352, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(10, 13);
            this.label17.TabIndex = 155;
            this.label17.Text = ":";
            this.label17.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label16.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label16.Location = new System.Drawing.Point(568, 16);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(10, 13);
            this.label16.TabIndex = 154;
            this.label16.Text = ":";
            this.label16.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label14.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.label14.Location = new System.Drawing.Point(128, 16);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(10, 13);
            this.label14.TabIndex = 153;
            this.label14.Text = ":";
            this.label14.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // tPX_code
            // 
            this.tPX_code.BackColor = System.Drawing.Color.AliceBlue;
            this.tPX_code.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPX_code.ForeColor = System.Drawing.Color.DarkGreen;
            this.tPX_code.Location = new System.Drawing.Point(845, 39);
            this.tPX_code.MaxLength = 50;
            this.tPX_code.Name = "tPX_code";
            this.tPX_code.ReadOnly = true;
            this.tPX_code.Size = new System.Drawing.Size(172, 22);
            this.tPX_code.TabIndex = 181;
            // 
            // r_tCat3
            // 
            this.r_tCat3.BackColor = System.Drawing.Color.IndianRed;
            this.r_tCat3.Location = new System.Drawing.Point(952, 21);
            this.r_tCat3.Name = "r_tCat3";
            this.r_tCat3.Size = new System.Drawing.Size(24, 8);
            this.r_tCat3.TabIndex = 152;
            this.r_tCat3.Visible = false;
            // 
            // r_tCat2
            // 
            this.r_tCat2.BackColor = System.Drawing.Color.IndianRed;
            this.r_tCat2.Location = new System.Drawing.Point(968, 13);
            this.r_tCat2.Name = "r_tCat2";
            this.r_tCat2.Size = new System.Drawing.Size(16, 8);
            this.r_tCat2.TabIndex = 151;
            this.r_tCat2.Visible = false;
            // 
            // r_tCat1
            // 
            this.r_tCat1.BackColor = System.Drawing.Color.IndianRed;
            this.r_tCat1.Location = new System.Drawing.Point(944, 13);
            this.r_tCat1.Name = "r_tCat1";
            this.r_tCat1.Size = new System.Drawing.Size(16, 8);
            this.r_tCat1.TabIndex = 150;
            this.r_tCat1.Visible = false;
            // 
            // chk3
            // 
            this.chk3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chk3.Location = new System.Drawing.Point(640, 15);
            this.chk3.Name = "chk3";
            this.chk3.Size = new System.Drawing.Size(16, 16);
            this.chk3.TabIndex = 126;
            this.chk3.Visible = false;
            // 
            // chk1
            // 
            this.chk1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chk1.Location = new System.Drawing.Point(200, 15);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(24, 16);
            this.chk1.TabIndex = 125;
            this.chk1.Visible = false;
            // 
            // chk2
            // 
            this.chk2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chk2.Location = new System.Drawing.Point(424, 15);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(16, 16);
            this.chk2.TabIndex = 124;
            this.chk2.Visible = false;
            // 
            // lCat3
            // 
            this.lCat3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lCat3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lCat3.Location = new System.Drawing.Point(456, 16);
            this.lCat3.Name = "lCat3";
            this.lCat3.Size = new System.Drawing.Size(112, 20);
            this.lCat3.TabIndex = 123;
            this.lCat3.Text = "n/a";
            this.lCat3.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lCat2
            // 
            this.lCat2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lCat2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lCat2.Location = new System.Drawing.Point(240, 16);
            this.lCat2.Name = "lCat2";
            this.lCat2.Size = new System.Drawing.Size(112, 20);
            this.lCat2.TabIndex = 122;
            this.lCat2.Text = "n/a";
            this.lCat2.TextAlign = System.Drawing.ContentAlignment.BottomRight;
            // 
            // lCat1
            // 
            this.lCat1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lCat1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.lCat1.Location = new System.Drawing.Point(16, 16);
            this.lCat1.Name = "lCat1";
            this.lCat1.Size = new System.Drawing.Size(112, 20);
            this.lCat1.TabIndex = 121;
            this.lCat1.Text = "n/a";
            this.lCat1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.button9);
            this.groupBox3.Controls.Add(this.tPriority);
            this.groupBox3.Controls.Add(this.btnPref);
            this.groupBox3.Controls.Add(this.lPriority);
            this.groupBox3.Controls.Add(this.lCostFac);
            this.groupBox3.Controls.Add(this.button7);
            this.groupBox3.Controls.Add(this.button6);
            this.groupBox3.Controls.Add(this.button5);
            this.groupBox3.Controls.Add(this.btnFixCost);
            this.groupBox3.Controls.Add(this.tSellFac);
            this.groupBox3.Controls.Add(this.lSellFac);
            this.groupBox3.Controls.Add(this.tCostFac);
            this.groupBox3.Controls.Add(this.cbPFamily);
            this.groupBox3.Controls.Add(this.cbManuf);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(3, 16);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1125, 71);
            this.groupBox3.TabIndex = 196;
            this.groupBox3.TabStop = false;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.ForeColor = System.Drawing.Color.Brown;
            this.button9.Location = new System.Drawing.Point(788, 43);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(229, 28);
            this.button9.TabIndex = 206;
            this.button9.Text = "options xl Desc by language";
            this.button9.Click += new System.EventHandler(this.button9_Click);
            // 
            // tPriority
            // 
            this.tPriority.BackColor = System.Drawing.Color.AliceBlue;
            this.tPriority.ForeColor = System.Drawing.Color.Red;
            this.tPriority.Location = new System.Drawing.Point(772, 12);
            this.tPriority.MaxLength = 3;
            this.tPriority.Name = "tPriority";
            this.tPriority.ReadOnly = true;
            this.tPriority.Size = new System.Drawing.Size(38, 20);
            this.tPriority.TabIndex = 210;
            this.tPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnPref
            // 
            this.btnPref.ForeColor = System.Drawing.Color.Red;
            this.btnPref.Location = new System.Drawing.Point(816, 10);
            this.btnPref.Name = "btnPref";
            this.btnPref.Size = new System.Drawing.Size(101, 24);
            this.btnPref.TabIndex = 209;
            this.btnPref.Text = "Change";
            this.btnPref.Click += new System.EventHandler(this.btnPref_Click);
            // 
            // lPriority
            // 
            this.lPriority.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lPriority.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPriority.ForeColor = System.Drawing.Color.Red;
            this.lPriority.Location = new System.Drawing.Point(686, 14);
            this.lPriority.Name = "lPriority";
            this.lPriority.Size = new System.Drawing.Size(86, 16);
            this.lPriority.TabIndex = 208;
            this.lPriority.Text = "Family Priority:";
            this.lPriority.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lCostFac
            // 
            this.lCostFac.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lCostFac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCostFac.ForeColor = System.Drawing.Color.Black;
            this.lCostFac.Location = new System.Drawing.Point(19, 41);
            this.lCostFac.Name = "lCostFac";
            this.lCostFac.Size = new System.Drawing.Size(70, 16);
            this.lCostFac.TabIndex = 206;
            this.lCostFac.Text = "Cost Factor:";
            this.lCostFac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button7
            // 
            this.button7.ForeColor = System.Drawing.Color.Red;
            this.button7.Location = new System.Drawing.Point(441, 39);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(199, 24);
            this.button7.TabIndex = 205;
            this.button7.Text = "Change (not implemented yet)";
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button6
            // 
            this.button6.ForeColor = System.Drawing.Color.Green;
            this.button6.Location = new System.Drawing.Point(621, 10);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 24);
            this.button6.TabIndex = 204;
            this.button6.Text = "Edit";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button5
            // 
            this.button5.ForeColor = System.Drawing.Color.Green;
            this.button5.Location = new System.Drawing.Point(295, 10);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 24);
            this.button5.TabIndex = 203;
            this.button5.Text = "Edit";
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // btnFixCost
            // 
            this.btnFixCost.ForeColor = System.Drawing.Color.Red;
            this.btnFixCost.Location = new System.Drawing.Point(137, 39);
            this.btnFixCost.Name = "btnFixCost";
            this.btnFixCost.Size = new System.Drawing.Size(102, 24);
            this.btnFixCost.TabIndex = 202;
            this.btnFixCost.Text = "Change";
            this.btnFixCost.Click += new System.EventHandler(this.btnFixCost_Click);
            // 
            // tSellFac
            // 
            this.tSellFac.BackColor = System.Drawing.Color.AliceBlue;
            this.tSellFac.ForeColor = System.Drawing.Color.Red;
            this.tSellFac.Location = new System.Drawing.Point(401, 41);
            this.tSellFac.MaxLength = 8;
            this.tSellFac.Name = "tSellFac";
            this.tSellFac.ReadOnly = true;
            this.tSellFac.Size = new System.Drawing.Size(40, 20);
            this.tSellFac.TabIndex = 200;
            this.tSellFac.Text = "1.00";
            this.tSellFac.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lSellFac
            // 
            this.lSellFac.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lSellFac.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSellFac.ForeColor = System.Drawing.Color.Black;
            this.lSellFac.Location = new System.Drawing.Point(318, 43);
            this.lSellFac.Name = "lSellFac";
            this.lSellFac.Size = new System.Drawing.Size(83, 16);
            this.lSellFac.TabIndex = 201;
            this.lSellFac.Text = "Sell Factor:";
            this.lSellFac.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tCostFac
            // 
            this.tCostFac.BackColor = System.Drawing.Color.AliceBlue;
            this.tCostFac.ForeColor = System.Drawing.Color.Red;
            this.tCostFac.Location = new System.Drawing.Point(89, 41);
            this.tCostFac.MaxLength = 8;
            this.tCostFac.Name = "tCostFac";
            this.tCostFac.ReadOnly = true;
            this.tCostFac.Size = new System.Drawing.Size(40, 20);
            this.tCostFac.TabIndex = 198;
            this.tCostFac.Text = "1.00";
            this.tCostFac.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbPFamily
            // 
            this.cbPFamily.BackColor = System.Drawing.Color.Lavender;
            this.cbPFamily.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPFamily.Location = new System.Drawing.Point(401, 12);
            this.cbPFamily.Name = "cbPFamily";
            this.cbPFamily.Size = new System.Drawing.Size(214, 21);
            this.cbPFamily.TabIndex = 154;
            this.cbPFamily.SelectedIndexChanged += new System.EventHandler(this.cbPFamily_SelectedIndexChanged_2);
            this.cbPFamily.SelectedValueChanged += new System.EventHandler(this.cbPFamily_SelectedValueChanged);
            // 
            // cbManuf
            // 
            this.cbManuf.BackColor = System.Drawing.Color.Lavender;
            this.cbManuf.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbManuf.Location = new System.Drawing.Point(89, 12);
            this.cbManuf.Name = "cbManuf";
            this.cbManuf.Size = new System.Drawing.Size(200, 21);
            this.cbManuf.TabIndex = 152;
            this.cbManuf.SelectedIndexChanged += new System.EventHandler(this.cbManuf_SelectedIndexChanged_1);
            this.cbManuf.SelectedValueChanged += new System.EventHandler(this.cbManuf_SelectedValueChanged);
            // 
            // label2
            // 
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Location = new System.Drawing.Point(9, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 153;
            this.label2.Text = "&Manufacturer: ";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Location = new System.Drawing.Point(332, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 16);
            this.label3.TabIndex = 155;
            this.label3.Text = " Family:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.lvOptPricelst);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 370);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1131, 246);
            this.groupBox7.TabIndex = 4;
            this.groupBox7.TabStop = false;
            // 
            // lvOptPricelst
            // 
            this.lvOptPricelst.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvOptPricelst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fullDesc,
            this.Cat1,
            this.Cat2,
            this.Cat3,
            this.Cat_Uprice,
            this.Cost,
            this.Sell,
            this.LeadTime,
            this.LID,
            this.plcode});
            this.lvOptPricelst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvOptPricelst.ForeColor = System.Drawing.Color.Blue;
            this.lvOptPricelst.FullRowSelect = true;
            this.lvOptPricelst.GridLines = true;
            this.lvOptPricelst.Location = new System.Drawing.Point(3, 16);
            this.lvOptPricelst.Name = "lvOptPricelst";
            this.lvOptPricelst.Size = new System.Drawing.Size(1125, 227);
            this.lvOptPricelst.TabIndex = 8;
            this.lvOptPricelst.UseCompatibleStateImageBehavior = false;
            this.lvOptPricelst.View = System.Windows.Forms.View.Details;
            this.lvOptPricelst.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvOptPricelst_ColumnClick_1);
            this.lvOptPricelst.SelectedIndexChanged += new System.EventHandler(this.lvOptPricelst_SelectedIndexChanged_1);
            this.lvOptPricelst.Click += new System.EventHandler(this.lvOptPricelst_Click);
            this.lvOptPricelst.DoubleClick += new System.EventHandler(this.lvOptPricelst_DoubleClick);
            // 
            // fullDesc
            // 
            this.fullDesc.Text = "Full Description";
            this.fullDesc.Width = 337;
            // 
            // Cat1
            // 
            this.Cat1.Text = "Category #1";
            this.Cat1.Width = 87;
            // 
            // Cat2
            // 
            this.Cat2.Text = "Category #2";
            this.Cat2.Width = 81;
            // 
            // Cat3
            // 
            this.Cat3.Text = "Category #3";
            this.Cat3.Width = 83;
            // 
            // Cat_Uprice
            // 
            this.Cat_Uprice.Text = "Catalog Price";
            this.Cat_Uprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Cat_Uprice.Width = 86;
            // 
            // Cost
            // 
            this.Cost.Text = "Cost Price";
            this.Cost.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Cost.Width = 70;
            // 
            // Sell
            // 
            this.Sell.Text = "Sell Price";
            this.Sell.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // LeadTime
            // 
            this.LeadTime.Text = "Lead Time";
            this.LeadTime.Width = 67;
            // 
            // LID
            // 
            this.LID.Text = "";
            this.LID.Width = 0;
            // 
            // plcode
            // 
            this.plcode.Text = "Primax Code";
            this.plcode.Width = 143;
            // 
            // Options_Admin
            // 
            this.AcceptButton = this.button3;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1131, 616);
            this.Controls.Add(this.groupBox7);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Options_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Components";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Options_Load);
            this.Resize += new System.EventHandler(this.Options_Resize);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.button2ww)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.grpOptionType.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDely)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnSkPLcode)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox7.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


		private void lvCompany_DoubleClick(object sender, System.EventArgs e)
		{
			MessageBox.Show ("Hi..."); 
			   
			//Optionsdlg optdlg = new Optionsdlg('c',MainMDI.M_stCon );
		//	optdlg.ShowDialog ();
		}

		private void fill_cboptGrp(string cptName)
		{


		//	string stSql = (cptName == "*") ? "select [COMPNT_LIST].COMPONENT_REF  FROM [COMPNT_LIST] where Compnt_Type='C' OR Compnt_Type='D' or Compnt_Type='E' or Compnt_Type='F' or Compnt_Type='S' or Compnt_Type='T' order by COMPONENT_REF" :"select [COMPNT_LIST].COMPONENT_REF FROM [COMPNT_LIST] where COMPONENT_REF='" + cptName + "' order by COMPONENT_REF" ;
		
	//		string stSql = (cptName == "*") ? "select * FROM [COM PNT_LIST] where Compnt_Type='C' OR Compnt_Type='D' or Compnt_Type='E' or Compnt_Type='F' or Compnt_Type='S' or Compnt_Type='T' order by COMPONENT_REF" :"select * FROM [COMPNT_LIST] where COMPONENT_REF='" + cptName + "' order by COMPONENT_REF" ;
			string stSql = (cptName == "*") ? "select * FROM [COMPNT_LIST] where Compnt_Type='C' OR Compnt_Type='D' or Compnt_Type='E' or Compnt_Type='F' or Compnt_Type='S' or Compnt_Type='T' order by Component_Name" :"select * FROM [COMPNT_LIST] where COMPONENT_REF='" + cptName + "' order by Component_Name" ;
	//	    stSql = (In_Opera=='A') ? "select * FROM [COMPNT_LIST] where Compnt_Type='S' order by Component_Name" :stSql;
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			cbOptGrp.Items.Clear (); 
			while (Oreadr.Read ())
			{
			   // if ((In_Opera!='M' && Oreadr["Component_Name"].ToString().IndexOf("Alarms")==-1) || (In_Opera=='M')) 	cbOptGrp.Items.Add( MainMDI.optDesc(0,Oreadr["Component_Name"].ToString()) + "         (" + Oreadr["COMPONENT_REF"].ToString() +")")  ; 
				if ((In_Opera!='M' && Oreadr["Component_Name"].ToString().IndexOf("haissam")==-1) || (In_Opera=='M')) 	cbOptGrp.Items.Add( MainMDI.optDesc(0,Oreadr["Component_Name"].ToString()) + "         (" + Oreadr["COMPONENT_REF"].ToString() +")")  ; 
			}
		//	if (cbOptGrp.Items.Count >0) cbOptGrp.Items.Add(MainMDI.VIDE );
			OConn.Close(); 

		}

		private void fill_lvOpt_priceListOK(int col )
		{ 
			/*
			double cF=1, sF=1;
			string stSql="";
			if (loptID.Text =="") loptID.Text ="0";
			if (lManID.Text =="") lManID.Text ="0";
			if (lFamID.Text =="") lFamID.Text ="0";
			switch (col)
			{
				case 0: 
					stSql = "select * from COMPNT_PRICE_LIST where COMPONENT_ID=" + Convert.ToInt16(loptID_orig.Text) + " and Manufac_ID=" + Convert.ToInt32(lManID.Text) + " and compnt_man_Fam_ID=" + Convert.ToInt32(lFamID.Text) + " order by PRICE_LINE_ID";
				break;
				
			}
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
			lvOptPricelst.Items.Clear ();
			while (Oreadr.Read ())
			{
				//string stfullD=Oreadr["CAT4_VALUE"].ToString () + ", " + Oreadr["CAT5_VALUE"].ToString () + ", " + Oreadr["CAT6_VALUE"].ToString () + ", " + Oreadr["CAT7_VALUE"].ToString () ;
				string stfullD=Oreadr["CAT4_VALUE"].ToString () + ", " + Oreadr["CAT5_VALUE"].ToString () + ", " + Oreadr["CAT6_VALUE"].ToString (); // + ", " + Oreadr["CAT7_VALUE"].ToString () ;
			
				ListViewItem lvI= lvOptPricelst.Items.Add( stfullD );
				lvI.SubItems.Add(Oreadr["CAT1_VALUE"].ToString()  ); 
				lvI.SubItems.Add( Oreadr["CAT2_VALUE"].ToString()); 
				lvI.SubItems.Add(Oreadr["CAT3_VALUE"].ToString()); 
				//string tprice =(In_Opera != 'M') ? Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["price"].ToString()) * Tools.Conv_Dbl(tSellFac.Text ),MainMDI.NB_DEC_AFF  ))  :  Oreadr["price"].ToString();
				if (In_Opera == 'M') lvI.SubItems.Add(MainMDI.A00(Oreadr["price"].ToString())); 
				else lvI.SubItems.Add(MainMDI.VIDE); 
				if (tCostFac.Text !="") cF=Convert.ToDouble(tCostFac.Text )   ;
				if (tSellFac.Text !="") sF=Convert.ToDouble(tSellFac.Text );
				double Cost =Math.Round(Tools.Conv_Dbl(Oreadr["price"].ToString()) * cF,MainMDI.NB_DEC_AFF );
				double Sell = Math.Round(Tools.Conv_Dbl(Oreadr["price"].ToString()) * sF,MainMDI.NB_DEC_AFF );
				if (In_Opera == 'M') lvI.SubItems.Add(MainMDI.A00(Cost.ToString ())); 
				else lvI.SubItems.Add(MainMDI.VIDE); 
				lvI.SubItems.Add(MainMDI.A00(Sell.ToString () )); 
				if (Oreadr["LeadTime"].ToString()!="") lvI.SubItems.Add(Oreadr["LeadTime"].ToString()); 
				else lvI.SubItems.Add(MainMDI.Default_LeadTime  ); 
				lvI.SubItems.Add(Oreadr["PRICE_LINE_ID"].ToString()); 
						
			}
			OConn.Close (); 
			*/
		}

		private string find_CPT_Sort(string cptLID ,string st)    //st=sort string
		{
            string srt1="",srt2="",srt3="";
		//	string st=MainMDI.Find_One_Field("select Sort_flds from COMPNT_LIST where Component_ID=" + cptLID);
			if (st !="")
			{
				for (int i=0;i<3;i++) 
				{
					switch (i)  
					{
						case 0:
							if ( st[i]=='7') srt1=" CAT1_VALUE ";
							if ( st[i]=='4') srt1=" CAT4_VALUE ";
							if ( st[i]=='1') srt1=" cast (CAT1_VALUE as float) ";
							break;
						case 1:
							if ( st[i]=='8') srt2=" CAT2_VALUE ";
							if ( st[i]=='5') srt2=" CAT5_VALUE ";
							if ( st[i]=='2') srt2=" cast (CAT2_VALUE as float) ";
                            if  (srt1!="" && srt2!="") srt2=", " + srt2;
                           
						//	if ( st[i]=='2' || st[i]=='5') srt2=" CAT"+ st[i] +"_VALUE, ";
						//	if ( st[i]=='8') srt2=(srt1=="") ? " CAT2_VALUE " :", CAT2_VALUE "   ;
							break;
						case 2:
							if ( st[i]=='9') srt3=" CAT3_VALUE ";
							if ( st[i]=='6') srt3=" CAT6_VALUE ";
							if ( st[i]=='3') srt3=" cast (CAT3_VALUE as float) ";
							if  (srt1!="" && srt2!="" && srt3!="") srt3=", " + srt3;


					//		if ( st[i]=='3' || st[i]=='6') srt3=" CAT"+ st[i] +"_VALUE ";
					//		if ( st[i]=='9') srt3=(srt2=="" && srt1=="" ) ? " CAT3_VALUE " :", CAT3_VALUE "   ;
							break;
					}

				}
   
				
			}
	        return srt1 +srt2 +srt3;


		}



		private void fill_lvOpt_priceList(int col )
		{ 
			
			double cF=1, sF=1;
			string stSql="";
			if (loptID.Text =="") loptID.Text ="0";
			if (lManID.Text =="") lManID.Text ="0";
			if (lFamID.Text =="") lFamID.Text ="0";
		//	string srtSql=find_CPT_Sort(loptID_orig.Text,tSort.Text  );
         //   if (srtSql!="") srtSql=" ORDER BY " + srtSql; 2 line below added for sorting all options (hakim 22/05/2008)

       //     if (srtSql != "") srtSql = " ORDER BY " + srtSql + ", CAT4_VALUE, CAT5_VALUE, CAT6_VALUE ";
        //    else srtSql = " ORDER BY CAT4_VALUE, CAT5_VALUE, CAT6_VALUE ";
            string srtSql = " ORDER BY CAT4_VALUE, CAT5_VALUE, CAT6_VALUE ";

			switch (col)
			{
				case 0: 
			//		stSql = "select * from COMPNT_PRICE_LIST where COMPONENT_ID=" + Convert.ToInt16(loptID_orig.Text) + " and Manufac_ID=" + Convert.ToInt32(lManID.Text) + " and compnt_man_Fam_ID=" + Convert.ToInt32(lFamID.Text) + srtSql;
            // ORDER BY CAT1_VALUE, CAT4_VALUE, CAT5_VALUE, CAT6_VALUE
                    stSql = "select * from COMPNT_PRICE_LIST where COMPONENT_ID=" + Convert.ToInt16(loptID_orig.Text) + " and Manufac_ID=" + Convert.ToInt32(lManID.Text) + " and compnt_man_Fam_ID=" + Convert.ToInt32(lFamID.Text) + srtSql;	
					break;
				
			}
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
 //string stout="";
			lvOptPricelst.Items.Clear ();
			while (Oreadr.Read ())
			{
			//	stout+=Oreadr["CAT1_VALUE"].ToString() +" / " + Oreadr["CAT2_VALUE"].ToString() +" / " + Oreadr["CAT3_VALUE"].ToString() +"\n";
				//string stfullD=Oreadr["CAT4_VALUE"].ToString () + ", " + Oreadr["CAT5_VALUE"].ToString () + ", " + Oreadr["CAT6_VALUE"].ToString () + ", " + Oreadr["CAT7_VALUE"].ToString () ;
				string stfullD=Oreadr["CAT4_VALUE"].ToString () + ", " + Oreadr["CAT5_VALUE"].ToString () + ", " + Oreadr["CAT6_VALUE"].ToString (); // + ", " + Oreadr["CAT7_VALUE"].ToString () ;
			
				ListViewItem lvI= lvOptPricelst.Items.Add( stfullD );

                if (stfullD.Length > 249)
                {
                    lvI.UseItemStyleForSubItems = false;
                    lvI.SubItems[0].BackColor = Color.Yellow;  
                }

				lvI.SubItems.Add(Oreadr["CAT1_VALUE"].ToString()  ); 
				lvI.SubItems.Add( Oreadr["CAT2_VALUE"].ToString()); 
				lvI.SubItems.Add(Oreadr["CAT3_VALUE"].ToString());  
				//string tprice =(In_Opera != 'M') ? Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["price"].ToString()) * Tools.Conv_Dbl(tSellFac.Text ),MainMDI.NB_DEC_AFF  ))  :  Oreadr["price"].ToString();
				if (In_Opera == 'M') lvI.SubItems.Add(MainMDI.A00(Oreadr["price"].ToString())); 
				else lvI.SubItems.Add(MainMDI.VIDE); 
				if (tCostFac.Text !="") cF=Convert.ToDouble(tCostFac.Text )   ;
				if (tSellFac.Text !="") sF=Convert.ToDouble(tSellFac.Text );
			//	double Cost =Math.Round(Tools.Conv_Dbl(Oreadr["price"].ToString()) * cF,MainMDI.NB_DEC_AFF );
			//	double Sell = Math.Round(Tools.Conv_Dbl(Oreadr["price"].ToString()) * sF,MainMDI.NB_DEC_AFF );
                double Cost = Math.Round(Tools.Conv_Dbl(Oreadr["Cost_Price"].ToString()), MainMDI.NB_DEC_AFF);
                double Sell = Math.Round(Tools.Conv_Dbl(Oreadr["Price"].ToString()), MainMDI.NB_DEC_AFF); //its sell price
				if (In_Opera == 'M') lvI.SubItems.Add(MainMDI.A00(Cost.ToString ())); 
				else lvI.SubItems.Add(MainMDI.VIDE); 
				lvI.SubItems.Add(MainMDI.A00(Sell.ToString () )); 
				if (Oreadr["LeadTime"].ToString()!="") lvI.SubItems.Add(Oreadr["LeadTime"].ToString()); 
				else lvI.SubItems.Add(MainMDI.Default_LeadTime  ); 
				lvI.SubItems.Add(Oreadr["PRICE_LINE_ID"].ToString()); 
				lvI.SubItems.Add(Oreadr["PL_CODE"].ToString());  
			//	MessageBox.Show(stout); 
						
			}
			OConn.Close (); 
		
		}

		private void cbOptGrp_SelectedValueChanged(object sender, System.EventArgs e)
		{

            GO_GRPOptio();


/*
			//if (cbOptGrp.Text.IndexOf("ALRM") > -1 && !msgDisp && In_Opera !='M') // check if option is Alarm msg=denied
			if (cbOptGrp.Text.IndexOf("haissam") > -1 && In_Opera !='M' && !msgDisp) // bypass ALRM test (haissam=Alarm)
			{
				MessageBox.Show("Choosing ALARM here is not recommended !!!!"); 
				this.Hide();
                this.Close();				
				msgDisp=true;
			}
			lcbOptGrp.Text = deco_desc_Ref(cbOptGrp.Text);
			string cpt_price_orig=Price_List_Exist(lcbOptGrp.Text) ;

			clear_CBEFREF(); 
			clear_CBmanufc();
			clear_scrn();
			lvOptPricelst.Items.Clear ();
			if (cpt_price_orig != MainMDI.VIDE && In_Opera == 'M'   ) 
			{
				fill_optionsWND(lcbOptGrp.Text ); 	
				MessageBox.Show("Please Refer to: " + cpt_price_orig + "\'s Price-List !!!!");  
			}
			else 
			{
				fill_optionsWND(lcbOptGrp.Text); 
				loptID_orig.Text= (cpt_price_orig != MainMDI.VIDE) ? MainMDI.Find_One_Field("select Component_ID from COMPNT_LIST where COMPONENT_REF='" + cpt_price_orig + "'") : loptID.Text;
				aff_Manufac(Convert.ToInt32(loptID_orig.Text) );
				cbManuf.Text = cbManuf.Items[0].ToString();   
			}
		*/	
		
		}
        private void GO_GRPOptio()
        {

            //if (cbOptGrp.Text.IndexOf("ALRM") > -1 && !msgDisp && In_Opera !='M') // check if option is Alarm msg=denied
            if (cbOptGrp.Text.IndexOf("haissam") > -1 && In_Opera != 'M' && !msgDisp) // bypass ALRM test (haissam=Alarm)
            {
                MessageBox.Show("Choosing ALARM here is not recommended !!!!");
                this.Hide();
                this.Close();
                msgDisp = true;
            }
            lcbOptGrp.Text = deco_desc_Ref(cbOptGrp.Text);
            string cpt_price_orig = Price_List_Exist(lcbOptGrp.Text);

            clear_CBEFREF();
            clear_CBmanufc();
            clear_scrn();
            lvOptPricelst.Items.Clear();
            if (cpt_price_orig != MainMDI.VIDE && In_Opera == 'M')
            {
                fill_optionsWND(lcbOptGrp.Text);
                MessageBox.Show("Please Refer to: " + cpt_price_orig + "\'s Price-List !!!!");
            }
            else
            {
                fill_optionsWND(lcbOptGrp.Text);
                loptID_orig.Text = (cpt_price_orig != MainMDI.VIDE) ? MainMDI.Find_One_Field("select Component_ID from COMPNT_LIST where COMPONENT_REF='" + cpt_price_orig + "'") : loptID.Text;
                aff_Manufac(Convert.ToInt32(loptID_orig.Text));
                if (cbManuf.Items.Count >0 ) cbManuf.Text = cbManuf.Items[0].ToString();
            }
			
        }
		private string deco_desc_Ref(string st)
		{
			int ipos=st.IndexOf("         (",0);
			if (ipos >-1) return st.Substring(ipos+10,st.Length - ipos -11);
			return MainMDI.VIDE ; 
		}
        
        private string Price_List_Exist(string CptRef)
		{
          string CM_ID= MainMDI.Find_One_Field("SELECT COMPNT_LIST.Value_Type FROM COMPNT_LIST WHERE (((COMPNT_LIST.COMPONENT_REF)='" + CptRef +"'))");
			if (CM_ID != MainMDI.VIDE )
			{
				string cptRef_orig= MainMDI.Find_One_Field("SELECT COMPNT_LIST.COMPONENT_REF FROM COMPUTE_MODELS INNER JOIN COMPNT_LIST ON COMPUTE_MODELS.PRC_Compnt_ID = COMPNT_LIST.Component_ID " + 
					" WHERE (((COMPUTE_MODELS.CM_ID)=" + CM_ID + "))");
				if (cptRef_orig!=MainMDI.VIDE ) return cptRef_orig;
			}
           return MainMDI.VIDE ;

		}

		private void tUPrice_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled =  Tools.OnlyDBL(e.KeyChar);
		}


		private void clear_CBmanufc()
		{
			cbManuf.Items.Clear();
			cbPFamily.Items.Clear(); 
		}
		private void clear_CBEFREF()
		{
			tERef.Text ="";
			tFRef.Text ="";
		}
		private void clear_scrn()
		{
			tComnt.Clear();
			tUPrice.Text ="";
			tOptqty.Text="1"  ; 
			tDlvDelay.Text ="04-06";
			lFullDesc.Text ="";
			tPx.Text ="";
			BOM.Clear();
			Mdrw.Clear(); 
			tManifac.Text ="";
			init_LCATn();
			tCat4.Text =MainMDI.VIDE ;
			tCat5.Text =MainMDI.VIDE ;
			tCat6.Text =MainMDI.VIDE ;
			tCat7.Text =MainMDI.VIDE ;
			tCat4fr.Text =MainMDI.VIDE ;
			tCat5fr.Text =MainMDI.VIDE ;
			tCat6fr.Text =MainMDI.VIDE ;
			tCat7fr.Text =MainMDI.VIDE ;
			//	tComnt.Text ="";
		}

		private void tDlvDelay_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			//e.Handled =DLL_NInt(e.KeyChar );
		}
		private bool DLL_Ndble(char c)
		{
			if ((c < 48 || c > 57 ) && c != 8 && c != 44  && c != 46)
				return true;
			else return false;
        
		}

		private bool DLL_NInt(char c)
		{
			if ((c < 48 || c > 57 ) && c != 8 )
				return true;
			else return false;
        
		}
		private void Upd_fullDesc()
		{
			optFR.Checked  =(MainMDI.Lang ==1);
            optEng.Checked = (MainMDI.Lang == 0 || MainMDI.Lang == 2);
		    if (optFR.Checked) if (tCat4fr.Text == MainMDI.VIDE )  optEng.Checked=true ;
			if (optEng.Checked) 
			{
				lFullDesc.Text = (tCat4.Text != Charger.VIDE    && tCat4.Text !="" && chk4.Checked   ) ? tCat4.Text : "";
				lFullDesc.Text = lFullDesc.Text + ((tCat5.Text != Charger.VIDE    && tCat5.Text !="" &&  chk5.Checked  ) ? ", " + tCat5.Text : "");
				lFullDesc.Text = lFullDesc.Text + ((tCat6.Text != Charger.VIDE    && tCat6.Text !="" && chk6.Checked  ) ? ", " + tCat6.Text : "");
				lFullDesc.Text = lFullDesc.Text +  ((tCat7.Text != Charger.VIDE    && tCat7.Text !="" && chk7.Checked  ) ? ", " + tCat7.Text : "");
			}
			else
			{
				lFullDesc.Text = (tCat4fr.Text != Charger.VIDE    && tCat4fr.Text !="" && chk4.Checked   ) ? tCat4fr.Text : "";
				lFullDesc.Text = lFullDesc.Text + ((tCat5fr.Text != Charger.VIDE    && tCat5fr.Text !="" &&  chk5.Checked  ) ? ", " + tCat5fr.Text : "");
				lFullDesc.Text = lFullDesc.Text + ((tCat6fr.Text != Charger.VIDE    && tCat6fr.Text !="" && chk6.Checked  ) ? ", " + tCat6fr.Text : "");
				lFullDesc.Text = lFullDesc.Text +  ((tCat7fr.Text != Charger.VIDE    && tCat7fr.Text !="" && chk7.Checked  ) ? ", " + tCat7fr.Text : "");
			}
		}

        private string get_latest_code(string cptID, string manuf, string Fam)
        {
            string cod = MainMDI.Find_One_Field(" SELECT PL_Code FROM COMPNT_PRICE_LIST " +
              " WHERE  COMPONENT_ID =" + cptID + " AND Manufac_ID =" + manuf + " AND compnt_man_Fam_ID =" + Fam + " ORDER BY PL_Code DESC ");
            if (cod == MainMDI.VIDE)
            {
              
              return cptCODE +"M"+ MANCode + "F" +FAMCode + "-001" ;   
            }
            else
            {
                int pos = cod.IndexOf("-");
                return cod.Substring(0, pos + 1) + MainMDI.A00(Int32.Parse(cod.Substring(pos + 1, 3)) + 1, 3);

            }
        }
		private void btnOK_Click(object sender, System.EventArgs e)
		{
            Save_LinePrice();
		}

        private void Save_LinePrice()
        {
            if (MainMDI.ALWD_USR("CPT_SV", true))
            {
                tCat7.ReadOnly = true;
                if (fields_ok())
                {
                    this.Cursor = Cursors.WaitCursor;
                    if (tPX_code.Text == "") tPX_code.Text = get_latest_code(loptID_orig.Text, lManID.Text, lFamID.Text);
                    if (btnOK.Text == "&Save")
                    {
                        if (!optPL_Exist(Convert.ToInt32(loptID.Text)))       // ,tCat1.Text  ,tCat2.Text  ,tCat3.Text  ) ) 
                        {
                            try
                            {
                                //" [PL_Code]='" + tPX_code.Text + "', " +
                                string stSql = "INSERT INTO COMPNT_PRICE_LIST ([COMPONENT_ID],[Manufac_ID],[compnt_man_Fam_ID] " +
                                    ", [Manufac_PARTN],[Primax_PARTN],[CAT1_VALUE],[CAT2_VALUE], " +
                                    " [CAT3_VALUE],[PRICE],[Cost_Price],[SPR_PRTS_COEF],[COMMENTS],[CAT4_VALUE],[CAT5_VALUE],[CAT6_VALUE],[CAT7_VALUE],[LeadTime],[PL_Code], " +
                                    "[CAT4fr_VALUE],[CAT5fr_VALUE],[CAT6fr_VALUE],[CAT7fr_VALUE]) VALUES ('" +
                                    loptID.Text + "', '" + lManID.Text + "', '" + lFamID.Text + "', '" +
                                    tManifac.Text.Replace("'", "''") + "', '" + tPx.Text.Replace("'", "''") + "', '" + tCat1.Text.Replace("'", "''") + "', '" +
                                    tCat2.Text.Replace("'", "''") + "', '" + tCat3.Text.Replace("'", "''") + "', " + tUPrice.Text + ", " + tCostUP.Text + ", " +
                                    1 + ", '" + tComnt.Text.Replace("'", "''") + "', '" + tCat4.Text.Replace("'", "''") + "', '" +
                                    tCat5.Text.Replace("'", "''") + "', '" + tCat6.Text.Replace("'", "''") + "', '" + tCat7.Text.Replace("'", "''") + "', '" +
                                    tDlvDelay.Text + "', '" + tPX_code.Text + "', '" + tCat4fr.Text.Replace("'", "''") + "', '" + tCat5fr.Text.Replace("'", "''") + "', '" +
                                    tCat6fr.Text.Replace("'", "''") + "', '" + tCat7fr.Text.Replace("'", "''") + "')";
                                MainMDI.ExecSql(stSql);
                                MainMDI.Write_JFS(stSql);
                                tPX_code.Text = "";
                                fill_lvOpt_priceList(0);

                            }
                            catch (SqlException Oexp)
                            {
                                MessageBox.Show("Adding Option Error...= " + Oexp.Message);
                            }
                        }
                        else MessageBox.Show("This Option Price_list Already EXISTS......");
                    }
                    else
                    {
                        try
                        {
                            string stSql = "UPDATE COMPNT_PRICE_LIST SET " +
                                " [Manufac_PARTN]='" + tManifac.Text.Replace("'", "''") + "', " +
                                " [Primax_PARTN]='" + tPx.Text.Replace("'", "''") + "', " +
                                " [CAT1_VALUE]='" + tCat1.Text.Replace("'", "''") + "', " +
                                " [CAT2_VALUE]='" + tCat2.Text.Replace("'", "''") + "', " +
                                " [CAT3_VALUE]='" + tCat3.Text.Replace("'", "''") + "', " +
                                " [CAT4_VALUE]='" + tCat4.Text.Replace("'", "''") + "', " +
                                " [CAT5_VALUE]='" + tCat5.Text.Replace("'", "''") + "', " +
                                " [CAT6_VALUE]='" + tCat6.Text.Replace("'", "''") + "', " +
                                " [CAT7_VALUE]='" + tCat7.Text.Replace("'", "''") + "', " +
                                " [CAT4fr_VALUE]='" + tCat4fr.Text.Replace("'", "''") + "', " +
                                " [CAT5fr_VALUE]='" + tCat5fr.Text.Replace("'", "''") + "', " +
                                " [CAT6fr_VALUE]='" + tCat6fr.Text.Replace("'", "''") + "', " +
                                " [CAT7fr_VALUE]='" + tCat7fr.Text.Replace("'", "''") + "', " +
                                " [PRICE]=" + tUPrice.Text + ", " +
                                " [Cost_Price]=" + tCostUP.Text + ", " +
                                " [SPR_PRTS_COEF]=" + "1" + ", " +
                                " [LeadTime]='" + tDlvDelay.Text + "', " +
                                " [PL_Code]='" + tPX_code.Text + "', " +
                                " [COMMENTS]='" + tComnt.Text.Replace("'", "''") + "' " +
                                " WHERE [PRICE_LINE_ID]=" + loptPLID.Text;
                            MainMDI.ExecSql(stSql);
                            MainMDI.Write_JFS(stSql);
                            fill_lvOpt_priceList(0);
                            btnOK.Text = "&Save";
                            tPX_code.Text = "";
                            update_Compnt_List();
                        }
                        catch (SqlException Oexp)
                        {
                            MessageBox.Show("Updating Option Error...= " + Oexp.Message);
                        }

                    }
                }
                else MessageBox.Show("You missed some data.....");
            }
            this.Cursor = Cursors.Default; 
        }
        private void update_Compnt_List()
        {

         
                        if (r_type.Text != ltype.Text || r_tERef.Text != tERef.Text || r_tFRef.Text != tFRef.Text || r_tOptCmnt.Text != tOptCmnt.Text)
                        {
                            string descEF = (tFRef.Text != "") ? tERef.Text + " ~ " + tFRef.Text : tERef.Text;

                            try
                            {
                                string stSql = "UPDATE COMPNT_LIST SET " +
                                    " [Compnt_Type]='" + ltype.Text +
                                    "', [Component_Name]='" + descEF.Replace("'", "''") +
                                    "', [Ref_cmnt]='" + tOptCmnt.Text.Replace("'", "''") +
                                    "'  WHERE [Component_ID]=" + loptID.Text;
                                MainMDI.ExecSql(stSql);
                                MainMDI.Write_JFS(stSql);
                                r_type.Text = ltype.Text;
                                //	btnSavOpt.Enabled =false;
                                //	btnCancelOpt.Enabled =false; 
                            }
                            catch (SqlException Oexp)
                            {
                                MessageBox.Show("Error occurs When Updating Component Type ...= " + Oexp.Message);
                            }

                        }
          
        }





		private void btnClear_Click(object sender, System.EventArgs e)
		{
			clear_scrn ();
			if (btnOK.Text =="&Update") btnOK.Text="&Save";
			
		}

		private void cbOptGrp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
/*
		private void lvoptPL_Add(string st1,string st2,string st3,string st4,string st5,string st6,string st7)
		{
			//string stfullD=Oreadr["st1"].ToString () + ", " + Oreadr["CAT5_VALUE"].ToString () + ", " + ", " + Oreadr["CAT6_VALUE"].ToString () + ", " + ", " + Oreadr["CAT7_VALUE"].ToString () ;
			ListViewItem lvI= lvOptPricelst.Items.Add( st1 );
			lvI.SubItems.Add( st2  ); 
			lvI.SubItems.Add( st3); 
			lvI.SubItems.Add(st4 ); 
			lvI.SubItems.Add(st5 ); 
			lvI.SubItems.Add(st6); 
			lvI.SubItems.Add(st6); 
			lvI.SubItems.Add(st7); 
		
		}
		*/

		private void tCat4_TextChanged(object sender, System.EventArgs e)
		{
                       
			Upd_fullDesc ();
		}

		private void tCat5_TextChanged(object sender, System.EventArgs e)
		{
			Upd_fullDesc ();
		}

		private void tCat6_TextChanged(object sender, System.EventArgs e)
		{
			Upd_fullDesc ();
		}

		private void tCat7_TextChanged(object sender, System.EventArgs e)
		{
			//Upd_fullDesc ();
		}
	
		private void fill_optionsWND(string stref)
		{
			string stSql= "select * FROM [COMPNT_LIST] where (Compnt_Type='S' or Compnt_Type='D' or Compnt_Type='F' or Compnt_Type='C' or Compnt_Type='E' or Compnt_Type='T') and COMPONENT_REF='" + stref + "' order by COMPONENT_REF";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
            
			//	lvCompany.Clear ();
			while (Oreadr.Read ())
			{
				//	tERef.Text =  Oreadr["COMPONENT_REF"].ToString() ; 
				//	tFRef.Text =  Oreadr["Component_Name"].ToString() ; 
				tERef.Text = MainMDI.optDesc(0,Oreadr["Component_Name"].ToString());
				tFRef.Text = MainMDI.optDesc(1,Oreadr["Component_Name"].ToString());
				tOptCmnt.Text=Oreadr["Ref_cmnt"].ToString() ; 
				r_tOptCmnt.Text=tOptCmnt.Text;
				r_tERef.Text =tERef.Text ;
				r_tFRef.Text= tFRef.Text;
				lCat1.Text =  Oreadr["CatName1"].ToString() ; 
				lCat2.Text =  Oreadr["CatName2"].ToString() ; 
				lCat3.Text =  Oreadr["CatName3"].ToString() ;

				lvOptPricelst.Columns[1].Text =lCat1.Text ;
				lvOptPricelst.Columns[2].Text =lCat2.Text ;
				lvOptPricelst.Columns[3].Text =lCat3.Text ;
  
				lCat1.Enabled= ( Oreadr["CatName1"].ToString() != "n/a" ); 
				lCat2.Enabled= ( Oreadr["CatName2"].ToString() != "n/a" ); 
				lCat3.Enabled= ( Oreadr["CatName3"].ToString() != "n/a" ); 
				
				init_LCATn();

				tCat1.Enabled=lCat1.Enabled;
				tCat2.Enabled=lCat2.Enabled;
				tCat3.Enabled=lCat3.Enabled;
				loptID.Text = Oreadr["Component_ID"].ToString(); 
				Aff_CptType(Oreadr["Compnt_Type"].ToString());
				ltype.Text =Oreadr["Compnt_Type"].ToString();
				r_type.Text = ltype.Text ;
				tSort.Text =  Oreadr["Sort_flds"].ToString();
                cptCODE = Oreadr["PX_Code"].ToString();
				
				//if (loptID.Text !="")	fill_lvOpt_priceList(0);		
			}
			OConn.Close (); 
		}
		/*
		private void fill_optionsWNDold(string Ref_Orig, string Ref_Curr)
		{
			string stSql= "select * FROM [COMPNT_LIST] where (Compnt_Type='S' or Compnt_Type='D' or Compnt_Type='F' or Compnt_Type='C' or Compnt_Type='E' or Compnt_Type='T') and COMPONENT_REF='" + Ref_Orig  + "' order by COMPONENT_REF";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
            
			//	lvCompany.Clear ();
			while (Oreadr.Read ())
			{
				//	tERef.Text =  Oreadr["COMPONENT_REF"].ToString() ; 
				//	tFRef.Text =  Oreadr["Component_Name"].ToString() ; 
				tERef.Text = MainMDI.optDesc(0,Oreadr["Component_Name"].ToString());
				tFRef.Text = MainMDI.optDesc(1,Oreadr["Component_Name"].ToString());
				r_tERef.Text =tERef.Text ;
				r_tFRef.Text= tFRef.Text;
				lCat1.Text =  Oreadr["CatName1"].ToString() ; 
				lCat2.Text =  Oreadr["CatName2"].ToString() ; 
				lCat3.Text =  Oreadr["CatName3"].ToString() ;

				lvOptPricelst.Columns[1].Text =lCat1.Text ;
				lvOptPricelst.Columns[2].Text =lCat2.Text ;
				lvOptPricelst.Columns[3].Text =lCat3.Text ;
  
				lCat1.Enabled= ( Oreadr["CatName1"].ToString() != "n/a" ); 
				lCat2.Enabled= ( Oreadr["CatName2"].ToString() != "n/a" ); 
				lCat3.Enabled= ( Oreadr["CatName3"].ToString() != "n/a" ); 
				
				init_LCATn();

				tCat1.Enabled=lCat1.Enabled;
				tCat2.Enabled=lCat2.Enabled;
				tCat3.Enabled=lCat3.Enabled;
				loptID.Text = Oreadr["Component_ID"].ToString(); 
				Aff_CptType(Oreadr["Compnt_Type"].ToString());
				ltype.Text =Oreadr["Compnt_Type"].ToString();
				r_type.Text = ltype.Text ;
				
				if (loptID.Text !="")	fill_lvOpt_priceList(0);		
			}
			OConn.Close (); 
		}
		*/
		
		private void init_LCATn()
		{
			tCat1.Text = (lCat1.Text =="n/a") ? MainMDI.VIDE : "";
			tCat2.Text=(lCat2.Text =="n/a") ? MainMDI.VIDE: "";
			tCat3.Text=(lCat3.Text =="n/a") ? MainMDI.VIDE : "";
		}

		private bool fields_ok()
		{

			if (tUPrice.Text =="" )   
			{       
				tUPrice.Focus();
				return false;
			}
            if (tCostUP.Text == "")
            {
                tCostUP.Focus();
                return false;
            }
			if (tDlvDelay.Text =="") 			
			{       
				tDlvDelay.Focus();
				return false;

			}
			if (In_Opera == 'N')	if (lFullDesc.Text !="") return true; 
			if (tCat1.Text =="" && lCat1.Text  != MainMDI.VIDE)    			
			{       
				tCat1.Focus();
				return false;
			}
			if (tCat2.Text =="" && lCat2.Text  != MainMDI.VIDE )    			
			{       
				tCat2.Focus();
				return false;
			}
			if (tCat3.Text =="" && lCat3.Text  != MainMDI.VIDE)     			
			{       
				tCat3.Focus();
				return false;
			}
			if (tCat4.Text =="")    			
			{       
				tCat4.Focus();
				return false;
			}
			if (tCat4fr.Text =="") tCat4fr.Text = MainMDI.VIDE  ;  
			if (tCat5fr.Text =="") tCat5fr.Text = MainMDI.VIDE  ;  
			if (tCat6fr.Text =="") tCat6fr.Text = MainMDI.VIDE  ;  
			if (tCat7fr.Text =="") tCat6fr.Text = MainMDI.VIDE  ; 
			if (tCat7.Text =="") tCat6fr.Text = MainMDI.VIDE  ; 
			if (lCat1.Text  == MainMDI.VIDE) lCat1.Text ="0";
			return true;
			
		}

		private bool optPL_ExistOld(int optID,string cat1,string cat2, string cat3)
		{

			string stSql= "select Count(*) FROM COMPNT_PRICE_LIST where COMPONENT_ID=" + optID + " and CAT1_VALUE='" + cat1 + "' and CAT2_VALUE='" + cat2 + "' and CAT3_VALUE='" + cat3 + "'";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			Object count = Ocmd.ExecuteScalar() ;
			OConn.Close (); 
			return (count.ToString()  != "0");
		}

		private bool optPL_Existold(int CptID)
		{

			string stSql= "select Count(*) FROM COMPNT_PRICE_LIST where COMPONENT_ID=" + CptID + " and CAT1_VALUE='" + tCat1.Text  + "' and CAT2_VALUE='" + tCat2.Text  + "' and CAT3_VALUE='" + tCat3.Text  + "' and CAT4_VALUE='" + tCat4.Text   + "' and CAT5_VALUE='" + tCat5.Text  + "' and CAT6_VALUE='" + tCat6.Text  + "'"    ;
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			Object count = Ocmd.ExecuteScalar() ;
			OConn.Close (); 
			return (count.ToString()  != "0");
		}

		private bool optPL_Exist(int CptID)
		{

		//	string stSql= "select Count(*) FROM COMPNT_PRICE_LIST where COMPONENT_ID=" + CptID + " and CAT1_VALUE='" + tCat1.Text  + "' and CAT2_VALUE='" + tCat2.Text  + "' and CAT3_VALUE='" + tCat3.Text  + "' and CAT4_VALUE='" + tCat4.Text   + "' and CAT5_VALUE='" + tCat5.Text  + "' and CAT6_VALUE='" + tCat6.Text  + "'"    ;
			
			string stSql= "SELECT COMPNT_PRICE_LIST.compnt_man_Fam_ID FROM COMPNT_PRICE_LIST " +
                          " WHERE COMPNT_PRICE_LIST.COMPONENT_ID=" + CptID + " AND COMPNT_PRICE_LIST.CAT1_VALUE='" + tCat1.Text  + "' AND COMPNT_PRICE_LIST.CAT2_VALUE='" + tCat2.Text  + "' AND COMPNT_PRICE_LIST.CAT3_VALUE='" + tCat3.Text  + "' AND COMPNT_PRICE_LIST.CAT4_VALUE='" + tCat4.Text   + "' AND COMPNT_PRICE_LIST.CAT5_VALUE='" + tCat5.Text  + "' AND COMPNT_PRICE_LIST.CAT6_VALUE='" + tCat6.Text  + "' AND COMPNT_PRICE_LIST.compnt_man_Fam_ID="+lFamID.Text   ;
           	return (MainMDI.Find_One_Field(stSql )!=MainMDI.VIDE );
		}



		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			this.Hide ();
		}
		private void get_2stIn1(string tt,ref string t1, ref string t2)	
		{   
			
			string[] ar_T=new string[2];
			ar_T[0]="" ;ar_T[1]="";
			int i=0;
			int ipos=0;
			while (tt.Length >0)
			{
				ipos=tt.IndexOf("~~");
				if (ipos >-1)
				{
					ar_T [i++] =tt.Substring(0,ipos);
					tt=tt.Substring(ipos+2,tt.Length - (ipos +2));
				}
				else
				{   
					ar_T[i++]=tt;
					tt="";
				}
			}
			t1=ar_T[0];
			t2=ar_T[1];
			//t3=ar_T[2];
			
		}

		private void lvOptPricelst_DoubleClick(object sender, System.EventArgs e)
		{
			
			clear_scrn(); 
			this.AcceptButton =btnOK ;
			lvOptPricelst.SelectedItems[0].BackColor = Color.WhiteSmoke;   
			//	MessageBox.Show ("cat1= " +  lvOptPricelst.SelectedItems[0].SubItems[1].Text     ) ;

			//	string stSql= "select * FROM COMPNT_PRICE_LIST where COMPONENT_ID=" + loptID.Text   + " and Manufac_ID=" + lManID.Text  + " and compnt_man_Fam_ID=" + lFamID.Text  + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
			string stSql= "select * FROM COMPNT_PRICE_LIST where PRICE_LINE_ID=" + lvOptPricelst.SelectedItems[0].SubItems[8].Text ;//         loptID.Text   + " and Manufac_ID=" + lManID.Text  + " and compnt_man_Fam_ID=" + lFamID.Text  + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			string st1="", st2="";
			while (Oreadr.Read ())
			{
				loptPLID.Text = Oreadr["PRICE_LINE_ID"].ToString();
                lineLID.Text = loptPLID.Text; lineLID.Visible = (MainMDI.User == "Admin");

			//	tManifac.Text =   Oreadr["Manufac_PARTN"].ToString() ; ~~
                get_2stIn1( Oreadr["Manufac_PARTN"].ToString(),ref st1,ref st2); 
				if (st1=="" && st2=="") tManifac.Text ="~~";
				Mdrw.Text =st1;  BOM.Text = st2;  
				tPX_code.Text =  Oreadr["PL_Code"].ToString();
				tPx.Text =        Oreadr["Primax_PARTN"].ToString() ; 
				tCat1.Text =      Oreadr["CAT1_VALUE"].ToString() ; 
				tCat2.Text =      Oreadr["CAT2_VALUE"].ToString() ;
                tCat3.Text = Oreadr["CAT3_VALUE"].ToString(); ;// Math.Round(Tools.Conv_Dbl(Oreadr["CAT3_VALUE"].ToString()), 2).ToString(); //Oreadr["CAT3_VALUE"].ToString();
				tCat4.Text =      Oreadr["CAT4_VALUE"].ToString() ;
				tCat5.Text =      Oreadr["CAT5_VALUE"].ToString() ;
				tCat6.Text =      Oreadr["CAT6_VALUE"].ToString() ;
				tCat7.Text =      Oreadr["CAT7_VALUE"].ToString() ;
				tCat4fr.Text =    Oreadr["CAT4fr_VALUE"].ToString() ;
				tCat5fr.Text =    Oreadr["CAT5fr_VALUE"].ToString() ;
				tCat6fr.Text =    Oreadr["CAT6fr_VALUE"].ToString() ;
				tCat7fr.Text =    Oreadr["CAT7fr_VALUE"].ToString() ;

                tUPrice.Text = MainMDI.A00(Oreadr["PRICE"].ToString());// Math.Round(Tools.Conv_Dbl(Oreadr["PRICE"].ToString()), 2).ToString();// //; lblPrice.Text ="Published Price:";}
                tCostUP.Text = MainMDI.A00(Oreadr["Cost_Price"].ToString()); //; Cost-price
        //        if (In_Opera == 'M')   tUPrice.Text = MainMDI.A00(Oreadr["PRICE"].ToString()); //; lblPrice.Text ="Published Price:";}
        //            tCostUP.Text = MainMDI.A00(Oreadr["Cost_Price"].ToString()); //; Cost-price
        //           else     tUPrice.Text = MainMDI.A00(Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["price"].ToString()) * Tools.Conv_Dbl(tSellFac.Text), MainMDI.NB_DEC_AFF))); //lblPrice.Text ="Catalog Price:";}

                tDlvDelay.Text = (Oreadr["LeadTime"].ToString().Length >4 ) ? Oreadr["LeadTime"].ToString() : "04-06";//MainMDI.Default_LeadTime ; 
				tComnt.Text =     Oreadr["COMMENTS"].ToString() ; 
				r_tManifac.Text =   Oreadr["Manufac_PARTN"].ToString() ; 
				r_tPx.Text =        Oreadr["Manufac_PARTN"].ToString() ; 
				r_tCat1.Text =      Oreadr["CAT1_VALUE"].ToString() ; 
				r_tCat2.Text =      Oreadr["CAT2_VALUE"].ToString() ;
				r_tCat3.Text =      Oreadr["CAT3_VALUE"].ToString() ;
				r_tCat4.Text =      Oreadr["CAT4_VALUE"].ToString() ;
				r_tCat5.Text =      Oreadr["CAT5_VALUE"].ToString() ;
				r_tCat6.Text =      Oreadr["CAT6_VALUE"].ToString() ;
				r_tCat7.Text =      Oreadr["CAT7_VALUE"].ToString() ;
				r_tUPrice.Text =    Oreadr["PRICE"].ToString() ;
                r_tcostUP.Text = Oreadr["Cost_Price"].ToString(); 
				r_tDlvDelay.Text = tDlvDelay.Text ;//(Oreadr["LeadTime"].ToString()!="") ? Oreadr["LeadTime"].ToString() : MainMDI.Default_LeadTime ; 
				r_tComnt.Text =     Oreadr["COMMENTS"].ToString() ; 
              
				btnOK.Text ="&Update"; 
			}
			
			OConn.Close (); 
			
		}
		private bool Modif_OK()
		{
			if (r_tManifac.Text !=   tManifac.Text) return true ; 
			if (r_tPx.Text !=        tPx.Text ) return true ; 
			if (r_tCat1.Text !=      tCat1.Text) return true ; 
			if (r_tCat2.Text !=      tCat2.Text) return true ; 
			if (r_tCat3.Text !=      tCat3.Text) return true ; 
			if (r_tCat4.Text !=      tCat4.Text) return true ; 
			if (r_tCat5.Text !=      tCat5.Text) return true ; 
			if (r_tCat6.Text !=      tCat6.Text) return true ; 
			if (r_tUPrice.Text !=    tUPrice.Text) return true ; 
			if (r_tDlvDelay.Text !=  tDlvDelay.Text) return true ;  
			if (r_tComnt.Text !=  tComnt.Text) return true; 
			return false;
		
		}

		private void optPrimax_CheckedChanged(object sender, System.EventArgs e)
		{
			swtch_type();
		}

		private void swtch_typeOLDdfdgdgd()
		{
			// To be a Charger Pricing a component must have in Type C,B,T,I 
			// To be a Sale component   it must have in Type S,D,F,Y ( means this component price is not used to determine a cherger PRICE (pricing Modules VB)
			if (chkDef.Checked && 	optPrimax.Checked)   ltype.Text= ("DFY".IndexOf(r_type.Text)>-1) ?"D" : "B";       //default + Primax product 
			if (chkDef.Checked && 	optBaS.Checked )     ltype.Text= ("SDFY".IndexOf(r_type.Text)>-1) ?"F" : "T";       //default + Buy & Sell product 
			if (!chkDef.Checked && 	optPrimax.Checked )  ltype.Text= ("SDFY".IndexOf(r_type.Text)>-1) ?"S" : "C";       //Accessory  + Primax product 
			if (!chkDef.Checked && 	optBaS.Checked)      ltype.Text= ("SDFY".IndexOf(r_type.Text)>-1) ?"Y" : "I";       //Accessory + Buy & Sell product 
		
			if (ltype.Text != r_type.Text ) { btnSavOpt.Enabled =true;btnCancelOpt.Enabled =true;} 
		}
		private void swtch_type()
		{
			// To be a Charger Pricing a component must have in Type C,B,T,I 
			// Sale component means his price is not used to determine a charger PRICE (pricing Modules VB)
			if (!chkDef.Enabled ) ltype.Text =(optPrimax.Checked) ? "S" : "T";       //Sales : Primax or Buy&sell 
			else
			{
				if (chkDef.Checked)  	ltype.Text= (optPrimax.Checked) ? "E" : "D"; // Pricing : Primax OR Buy&sell (Charger default) 
				else                    ltype.Text= (optPrimax.Checked) ? "C" : "F"; // Pricing : Primax OR Buy&sell ( Not Charger default) 
			}
			if (ltype.Text != r_type.Text ) { btnSavOpt.Enabled =true;btnCancelOpt.Enabled =true;} 
		}
		private void optBaS_CheckedChanged(object sender, System.EventArgs e)
		{
			swtch_type();
		}

		private void chkDef_CheckedChanged(object sender, System.EventArgs e)
		{
			swtch_type();
		}
		private string Find_ID(string stSql)
		{
			//string stSql= "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text   + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr .Read ())
			{  
				return Oreadr[0].ToString ();
			}
			OConn.Close (); 
			return MainMDI.VIDE  ;
		}
	

		private void btnCancelOpt_Click(object sender, System.EventArgs e)
		{
			ltype.Text = r_type.Text ;
			Aff_CptType(ltype.Text );
			btnSavOpt.Enabled =false;
			btnCancelOpt.Enabled =false; 
		}

		private void Options_Resize(object sender, System.EventArgs e)
		{
			//MessageBox.Show ("Resize Y= " + lvOptPricelst.Location.Y.ToString());  
			lvOptPricelst.Columns[0].Width = this.Width - 805;//502;
		//	lvOptPricelst.Height = this.Height  - 436; // 376;
		//	grpCadi.Width = this.Width - 800;
		//	lvCadi.Width = this.Width - 864;
		//	lvCadi.Columns[0].Width= lvCadi.Width-21;


		}

	

		private void cbManuf_SelectedValueChanged(object sender, System.EventArgs e)
		{
           affManuf(cbManuf.Text );
		 if (cbPFamily.Items.Count >0)  cbPFamily.Text = cbPFamily.Items[0].ToString();  
		//	aff_Manufac((cbManuf.Text );
		}
		private void affManuf(string manufCB)
		{
            string st1="",st2="";
            string stSql = "SELECT COMPNT_MANUFAC.MANUFAC_ID, M_code FROM COMPNT_MANUFAC where COMPNT_MANUFAC.MANUFAC_NAME= '" + manufCB + "' ";
            MainMDI.Find_2_Field(stSql, ref st1, ref st2);
            if (st1 != MainMDI.VIDE)
            {
                lManID.Text = st1;
                MANCode = st2;
                fill_cbFam(Convert.ToInt32(loptID_orig.Text), Convert.ToInt32(lManID.Text));
            }
            else MessageBox.Show("Invalid Manufac Name....."); 
		}
		private void aff_Manufac(int opt_id)
		{

			string stSql=  "SELECT COMPNT_MANUFAC.MANUFAC_ID, COMPNT_MANUFAC.MANUFAC_NAME " +
				" FROM COMPNT_MANUFAC_FAMILY INNER JOIN COMPNT_MANUFAC ON " +
				" COMPNT_MANUFAC_FAMILY.Manufac_ID = COMPNT_MANUFAC.MANUFAC_ID GROUP " + 
				" BY COMPNT_MANUFAC.MANUFAC_ID, COMPNT_MANUFAC.MANUFAC_NAME, " + 
				"COMPNT_MANUFAC_FAMILY.Compnt_ID HAVING (((COMPNT_MANUFAC_FAMILY.Compnt_ID)=" + opt_id + ")) ORDER BY COMPNT_MANUFAC.MANUFAC_NAME";

			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			cbManuf.Items.Clear (); 
			while (Oreadr.Read ())
			{
				cbManuf.Items.Add( Oreadr["MANUFAC_NAME"].ToString()  ); 
			}
			OConn.Close(); 
		
		}

		private void chkUseInPL_CheckedChanged(object sender, System.EventArgs e)
		{
			//cbcpt.Visible = chkUseInPL.Checked  ;
         
		}

		private void fill_cbFam (int optID, int ManufacID)
		{
	//		string stSql=" SELECT COMPNT_MANUFAC_FAMILY.*, COMPNT_MANUFAC_FAMILY.Manufac_ID, COMPNT_MANUFAC_FAMILY.Compnt_ID " +
	//			" From COMPNT_MANUFAC_FAMILY Where (((COMPNT_MANUFAC_FAMILY.Manufac_ID) =" + ManufacID  + ") And ((COMPNT_MANUFAC_FAMILY.Compnt_ID) =" + optID + "))";

            string stSql = " SELECT   [Desc], Pref From COMPNT_MANUFAC_FAMILY " +
                           " Where COMPNT_MANUFAC_FAMILY.Manufac_ID =" + ManufacID + " And COMPNT_MANUFAC_FAMILY.Compnt_ID =" + optID + " ORDER BY Pref ";
  
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			cbPFamily.Items.Clear (); 
			while (Oreadr.Read ())
			{
				cbPFamily.Items.Add( Oreadr["Desc"].ToString()  ); 
			}
			OConn.Close(); 
		}



		

		private void cbPFamily_SelectedValueChanged(object sender, System.EventArgs e)
		{
		   
			btnClear_Click(sender,e);
 
			string stSql=" SELECT COMPNT_MANUFAC_FAMILY.* From COMPNT_MANUFAC_FAMILY Where [Desc] ='" + cbPFamily.Text  + "' and Compnt_ID=" + loptID_orig.Text + " and Manufac_ID=" + lManID.Text  ;
    
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ())
			{
				lFamID.Text =Oreadr["Compnt_Man_FAM_ID"].ToString(); 
				tPriority.Text =Oreadr["Pref"].ToString(); 
				tCostFac.Text =Oreadr["Cost_factor"].ToString(); 
				tSellFac.Text = Oreadr["Sell_factor"].ToString();
                FAMCode = Oreadr["F_Code"].ToString();
                tCostFac.ReadOnly = true;
                tPriority.ReadOnly = true;
			}
			OConn.Close(); 
			//lvOptPricelst.Items.Clear();
			fill_lvOpt_priceList(0); 
			
		}
		

	

		private void btnSavOpt_Click(object sender, System.EventArgs e)
		{
			if (MainMDI.ALWD_USR("CPT_SV",true))
			{
				update_Compnt_List();
			}
		
				
		}

		private void Aff_CptType(string t)
		{
			 
			chkDef.Enabled = (!("TS".IndexOf(t)>-1));
			chkDef.Enabled = (("CDEF".IndexOf(t)>-1));
			switch (t)    
			{  

					// a charger_pricing component C changes to D if it becomes 
					// a Charger default option 
  
				case "E":  //default + Primax product   (Pricing..)
					chkDef.Checked =true;
					optPrimax.Checked =true;
					break;
		
				case "D":  //default + Buy & Sell product  (Pricing..)
					chkDef.Checked =true;
					optBaS.Checked =true;
					break;

					// by Default a component is C: not default && Primax Product
					// so C==S    STUV
				case "C":    //Not Default  + Primax product  (Pricing..)
				case "S"  :  //Not Default  + Primax product  (not Pricing...)
					if (chkDef.Enabled ) chkDef.Checked =false;
					optPrimax.Checked =true;
					break;
				case "F":   //Not Default  + Buy & Sell product  (Pricing..)
				case "T":   //Not Default  + Buy & Sell product   (not Pricing...)
					if (chkDef.Enabled ) chkDef.Checked =false;
					optBaS.Checked =true;
					break;
				   
			}
		}

		private void groupBox2_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void cbManuf_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void cbPFamily_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
		
		}


		private void disable_Maj()
		{
			bool Modif=In_Opera =='M';
			
			//		        tUPrice.ReadOnly  =!Modif  ;
			//				tSellFac.Visible =!Modif ; 
			//				tDlvDelay.ReadOnly =!Modif ; 
			//				tPriority.Visible  =!Modif ;
			//				tComnt.ReadOnly =!Modif ;
			//	tPx.ReadOnly =true;
			//	tCat1.ReadOnly =true;
			//	tCat2.ReadOnly =true;
			//	tCat3.ReadOnly =true;
			//	tCat4.ReadOnly =true;
			//	tCat5.ReadOnly =true;
			//	tCat6.ReadOnly =true;
			//	tCat7.ReadOnly =true;
			//	tCat4fr.ReadOnly =true;
			//	tCat5fr.ReadOnly =true;
			//	tCat6fr.ReadOnly =true;
			//	tCat7fr.ReadOnly =true;
			//	tManifac.ReadOnly =true;
	
			btnClear.Visible =Modif ; 
			btnCancel.Visible =Modif;
			btnOK.Visible =Modif;
			btnConsCancel.Visible =!Modif;
			btnConsOK.Visible =!Modif; 
			grpOptionType.Visible =Modif;
            tOptCmnt.ReadOnly = !Modif;
			chk4.Visible =!Modif;
			chk5.Visible =!Modif;
			chk6.Visible =!Modif;
			chk7.Visible =!Modif;
			
			optEng.Visible =!Modif;
			optFR.Visible =!Modif;
			
		//	lQty.Visible =!Modif;
			tOptqty.Visible =!Modif;
		//	grpCadi.Visible =!Modif; 
			lExt.Visible =!Modif;
		//	lbext.Visible =!Modif;
			tOptqty.Text ="1"; 
			tUPrice.ReadOnly  =!Modif  ;
			tSellFac.Visible =Modif ; 
			tCostFac.Visible =Modif ; 
			tPriority.Visible  =Modif ;
			lSellFac.Visible =Modif ; 
			lCostFac.Visible =Modif ; 
		//	lPriority.Visible  =Modif ;
			tDlvDelay.ReadOnly =!Modif ; 
					
			tComnt.ReadOnly =!Modif ;
	
			if (In_Opera != 'M' && In_Opera != 'C' && In_Opera != 'A')  MessageBox.Show("ERROR CODE = " + In_Opera );
					
			
				

			
		}

		private void groupBox7_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void chk4_CheckedChanged(object sender, System.EventArgs e)
		{
			Upd_fullDesc ();
		}

		private void label6_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnConsOK_Click(object sender, System.EventArgs e)
		{
			if (fields_ok()) { lConsopt.Text ="Y";this.Hide();} 
		}

		private void btnConsCancel_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lvOptPricelst_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void New_Option()
		{
			tUPrice.ReadOnly =false;
			tDlvDelay.ReadOnly=false;
			lFullDesc.ReadOnly =false;
			tUPrice.BackColor =Color.Tomato  ; 
			tDlvDelay.BackColor =Color.Tomato  ; 
			lFullDesc.BackColor =Color.Tomato  ; 
			cbManuf.Enabled =false;
			cbPFamily.Enabled =false ; 
			cbOptGrp.Enabled =false;
			tERef.Enabled =false;
			tFRef.Enabled =false;
 
		}

		private void groupBox1_Enter_1(object sender, System.EventArgs e)
		{
		
		}

		private void label11_Click(object sender, System.EventArgs e)
		{
		
		}

		private void tCat4fr_TextChanged(object sender, System.EventArgs e)
		{
			Upd_fullDesc ();
		}

		private void tCat5fr_TextChanged(object sender, System.EventArgs e)
		{
			Upd_fullDesc ();
		}

		private void tCat6fr_TextChanged(object sender, System.EventArgs e)
		{
			Upd_fullDesc ();
		}

		private void tCat7fr_TextChanged(object sender, System.EventArgs e)
		{
			// Upd_fullDesc ();
		}

		private void optFR_CheckedChanged(object sender, System.EventArgs e)
		{
			//Upd_fullDesc ();
		}

		private void optEng_CheckedChanged(object sender, System.EventArgs e)
		{
			//Upd_fullDesc ();
		}

		private void Options_Resize_1(object sender, System.EventArgs e)
		{
			//lvOptPricelst.Height = this.Height  -316; 
		}

		private void tUPrice_TextChanged_1(object sender, System.EventArgs e)
		{
			//	if (tUPrice.Text !=""  && tOptqty.Text != "" ) 
			lExt.Text = MainMDI.A00(Convert.ToString (Math.Round(Tools.Conv_Dbl(tUPrice.Text) *  Tools.Conv_Dbl(tOptqty.Text),MainMDI.NB_DEC_AFF)  )) ;  
		}

		private void tOptqty_TextChanged(object sender, System.EventArgs e)
		{
			//	if (tUPrice.Text !=""  && tOptqty.Text != "" )
			lExt.Text = MainMDI.A00(Convert.ToString (Math.Round(Tools.Conv_Dbl(tUPrice.Text) *  Tools.Conv_Dbl(tOptqty.Text),MainMDI.NB_DEC_AFF)  )) ; 
		}

		private void chk5_CheckedChanged(object sender, System.EventArgs e)
		{
			Upd_fullDesc ();
		}

		private void chk6_CheckedChanged(object sender, System.EventArgs e)
		{
			Upd_fullDesc ();
		}

		private void chk7_CheckedChanged(object sender, System.EventArgs e)
		{
			Upd_fullDesc ();
		}

		private void picDel_Click(object sender, System.EventArgs e)
		{
			if (MainMDI.ALWD_USR("CPT_SV",true))
			{
				if (lvOptPricelst.SelectedItems.Count ==1 )
				{
					if (MainMDI.Confirm("WANT TO DELETE OPTION: '" + lvOptPricelst.SelectedItems[0].SubItems[0].Text     + "'  ?  " )) 
					{
						string stSql=" Delete COMPNT_PRICE_LIST WHERE PRICE_LINE_ID=" + lvOptPricelst.SelectedItems[0].SubItems[8].Text;
						lvOptPricelst.Items[lvOptPricelst.SelectedItems[0].Index].Remove();     
						MainMDI.ExecSql(stSql);
						MainMDI.Write_JFS(stSql);
						picDel.Enabled =false;
					}
				}
			}
		}

		private void lvOptPricelst_Click(object sender, System.EventArgs e)
		{
			if (In_Opera =='M')  picDel.Enabled  = lvOptPricelst.SelectedItems.Count ==1 ;  
		}

		private void lvOptPricelst_Leave(object sender, System.EventArgs e)
		{
			picDel.Enabled = false ;  
		}

		private void lvOptPricelst_MouseMove(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			if (In_Opera=='M')  picDel.Enabled = lvOptPricelst.SelectedItems.Count ==1 ;  
		}

		private void lvOptPricelst_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			//  MessageBox.Show (lvOptPricelst.Columns[0].Width.ToString ());   
			/*
				ListView myListView = (ListView)sender;

					// Determine if clicked column is already the column that is being sorted.
					if ( e.Column == lvSorter.SortColumn )
					{
						// Reverse the current sort direction for this column.
						if (lvSorter.Order == SortOrder.Ascending)
						{
							lvSorter.Order = SortOrder.Descending;
						}
						else
						{
							lvSorter.Order = SortOrder.Ascending;
						}
					}
					else
					{
						// Set the column number that is to be sorted; default to ascending.
						lvSorter.SortColumn = e.Column;
						lvSorter.Order = SortOrder.Ascending;
					}

					// Perform the sort with these new sort options.
					myListView.Sort();


	
					//	lvCompany.Items.Clear();
					//	lvCompany.Refresh ();
					//	fill_lvCmpny_Fast  (e.Column );
   
	*/
	
		}

		private void cbManuf_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
		
		}



		private void btnseek_Click(object sender, System.EventArgs e)
		{
			for (int i=0;i<cbOptGrp.Items.Count;i++)
				if (cbOptGrp.Items[i].ToString().IndexOf(tKey.Text,0) >-1) 
				{
					cbOptGrp.SelectedIndex = i;
					i=cbOptGrp.Items.Count;
				}
		}
		private void button1_ClickOK(object sender, System.EventArgs e)
		{
			bool FOUND=false;
			lvOptPricelst.Items.Clear();  
			cbManuf.Items.Clear();
			cbPFamily.Items.Clear();
			
			for (int i=0;i<cbOptGrp.Items.Count;i++)
				if (cbOptGrp.Items[i].ToString().ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1) 
				{   
					cbOptGrp.SelectedIndex = i;
					i=cbOptGrp.Items.Count;
					//cbOptGrp_SelectedValueChanged(sender,e);
                    GO_GRPOptio();
					ndxfound =i;
					FOUND=true;
				}
			if (!FOUND) MessageBox.Show("KeyWord not Found !!!!"); 
		}
		private void button1_Click(object sender, System.EventArgs e)
		{
            look_CPT_Ref();

            /*
			if (tKey.Text !="")
			{
				bool FOUND=false;
				lvOptPricelst.Items.Clear();  
				cbManuf.Items.Clear();
				cbPFamily.Items.Clear();
				if (button1x.Text=="Search") ndxfound =0;  
				for (int i=ndxfound;i<cbOptGrp.Items.Count;i++)
					if (cbOptGrp.Items[i].ToString().ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1) 
					{   
						cbOptGrp.SelectedIndex = i;
						ndxfound =i+1;
						i=cbOptGrp.Items.Count;
						cbOptGrp_SelectedValueChanged(sender,e);
						if (ndxfound <cbOptGrp.Items.Count) button1x.Text ="Next"; 
						FOUND=true;
					}
				if (!FOUND) 
				{
					ndxfound=0;
					button1x.Text ="Search / Primax REF"; 
					MessageBox.Show("KeyWord not Found !!!!"); 
				}
			}
             * */
		}

        private void look_CPT_Ref()
        {
            if (tKey.Text != "")
            {
                bool FOUND = false;
                lvOptPricelst.Items.Clear();
                cbManuf.Items.Clear();
                cbPFamily.Items.Clear();
                if (button1x.Text == "Search") ndxfound = 0;
                for (int i = ndxfound; i < cbOptGrp.Items.Count; i++)
                    if (cbOptGrp.Items[i].ToString().ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1)
                    {
                        cbOptGrp.SelectedIndex = i;
                        ndxfound = i + 1;
                        i = cbOptGrp.Items.Count;
                    //    cbOptGrp_SelectedValueChanged(sender, e);
                        GO_GRPOptio();
                        if (ndxfound < cbOptGrp.Items.Count) button1x.Text = "Next";
                        FOUND = true;
                    }
                if (!FOUND)
                {
                    ndxfound = 0;
                    button1x.Text = "Search / Primax REF";
                    MessageBox.Show("KeyWord not Found !!!!");
                }
            }
        }


		private void tKey_TextChanged(object sender, System.EventArgs e)
		{
			//this.AcceptButton = button1x ;
			button1x.Text="Search";
		}

		private void label4_Click(object sender, System.EventArgs e)
		{
		
		}

		private void pictureBox3_Click(object sender, System.EventArgs e)
		{
			if (tCat3.Text =="") tCat3.Text ="n/a"; 
			if (tCat1.Text =="") tCat1.Text ="n/a"; 
			if (tCat2.Text =="") tCat2.Text ="n/a"; 
		}

		private void Mdrw_TextChanged(object sender, System.EventArgs e)
		{
			
			tManifac.Text = ((Mdrw.Text!="") ? Mdrw.Text : " ")   +"~~"+ ((BOM.Text!="") ? BOM.Text : " ")  ; 
		}

		private void BOM_TextChanged(object sender, System.EventArgs e)
		{
			tManifac.Text = ((Mdrw.Text!="") ? Mdrw.Text : " ")   +"~~"+ ((BOM.Text!="") ? BOM.Text : " ")  ; 
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			Options_look  child = new  Options_look();  
		//	this.Hide ();
			child.ShowDialog(); 
		//	this.Visible =true;
			if (child.SelRow !=-1)
			{   
				int ndx=child.SelRow ;
				cbOptGrp.Text = child.lvQuotes.Items[ndx].SubItems[7].Text ;
				cbManuf.Text = child.lvQuotes.Items[ndx].SubItems[6].Text ;
				cbPFamily.Text =child.lvQuotes.Items[ndx].SubItems[4].Text ;
				for (int y=0;y<lvOptPricelst.Items.Count ;y++)
				{
					if (lvOptPricelst.Items[y].SubItems[8].Text == child.lvQuotes.Items[ndx].SubItems[2].Text) 
					{
						lvOptPricelst.Items[y].BackColor =Color.Yellow    ;
						lvOptPricelst.Items[y].Selected =true;
						lvOptPricelst.Items[y].EnsureVisible(); 
						//y=lvOptPricelst.Items.Count ;
					}
					else lvOptPricelst.Items[y].BackColor =Color.WhiteSmoke    ;
				}
				
			}
 

			child.Dispose();
		}

		private void tPx_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			//picDel_Click(sender,e); 
           // button3_Click_2(sender, e);
            look_CPT_Ref();
  
		}

		private void picAdd_Click(object sender, System.EventArgs e)
		{
/*
			string stt=(MainMDI.Lang ==0  ) ?  tERef.Text : tFRef.Text;
			string prtNB=(tPx.Text!="") ? tPx.Text +"~~" + tManifac.Text : " " +"~~" + tManifac.Text ;
            ListViewItem lv = lvCadi.Items.Add(stt + "  " + lFullDesc.Text + " [" +tPX_code.Text  + "]");
			lv.SubItems.Add(tOptqty.Text );
			lv.SubItems.Add(tUPrice.Text);
			lv.SubItems.Add(prtNB);
			lv.SubItems.Add( tDlvDelay.Text);
			btnConsOK.Visible =(lvCadi.Items.Count ==0); 
*/
	
		}

//		private void picSavLst_Click(object sender, System.EventArgs e)
//		{
//			if (lvCadi.Items.Count >0  ) { lConsopt.Text ="L";this.Hide();} 
//		}

		private void lvCadi_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			//MessageBox.Show(lvCadi.Columns[0].Width.ToString()+"  " + lvCadi.Width.ToString()   );     
		}

		private void lvCadi_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void Options_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
            this.AcceptButton = button3;
            btnImport.Visible = (MainMDI.User == "ede") ;// && MainMDI.currDB != "Back_PSM_FDB");
            lImpNB.Visible = btnImport.Visible;
            if (MainMDI.M_stCon_PL_BACK == MainMDI.M_stCon) btn_PL_BACK_ORIG.Text = "update PROD.";// _STCON = MainMDI.M_stCon_PL_ORIG;
            if (MainMDI.M_stCon_PL_ORIG == MainMDI.M_stCon) btn_PL_BACK_ORIG.Text = "update BACKUP"; // _STCON = MainMDI.M_stCon_PL_BACK;
            btn_PL_BACK_ORIG.Visible = (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "hnasrat");
        
        }

	

		private void tCat7_DoubleClick(object sender, System.EventArgs e)
		{
		  tCat7.ReadOnly = false;
		}

		private void tCat7fr_DoubleClick(object sender, System.EventArgs e)
		{
		  tCat7fr.ReadOnly = false; ;
		}



		private void import_newCpts()
		{
		
			//	clear_scrn(); 
				
			//	lvOptPricelst.SelectedItems[0].BackColor = Color.WhiteSmoke;  
 
	     		string stSql= "select * FROM _ImportNew_Cpts ";
				SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
				OConn.Open ();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql ;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();
			    string roptID ="",rManID  = "", rFamID= "", rManifac = "", rPx="",rCat1="",rCat2="", rCat3 = "", rCat4  = "", rCat5 = "", rCat6 = "",rCat4fr = "";
			    string rCat5fr="",rCat6fr = "",	rUPrice = "", rDlvDelay ="04-06";
           	    string big_exst="Lines# Duplicated:",xst="";

			while (Oreadr.Read ())
			{
				//loptPLID.Text = Oreadr["PRICE_LINE_ID"].ToString();
				roptID  = Oreadr["CPTLID"].ToString();
				rManID  = Oreadr["ManufacLID"].ToString();
				rFamID  = Oreadr["famLID"].ToString();
				if (rFamID !="-1" && rFamID !="")
				{
					rManifac = Oreadr["ELEC_DWG"].ToString()+"~~" + Oreadr["MECAN_DWG"].ToString() ; 
					rPx =  Oreadr["BOM1"].ToString()+ Oreadr["BOM2"].ToString() + Oreadr["BOM3"].ToString() ;  
					rCat1  =      Oreadr["CAT1"].ToString() ; 
					rCat2  =      Oreadr["CAT2"].ToString() ;
					rCat3  =      Oreadr["CAT3"].ToString() ;
					rCat4  =      Oreadr["DESC4"].ToString() ;
					rCat5  =      Oreadr["DESC5"].ToString() ;
					rCat6  =      Oreadr["DESC6"].ToString() ;
					rCat4fr  =    Oreadr["DESC4"].ToString() ;
					rCat5fr  =    Oreadr["DESC5"].ToString() ;
					rCat6fr  =    Oreadr["DESC6"].ToString() ;
					rUPrice   =  Oreadr["PRICE"].ToString(); 
					rDlvDelay  = (Oreadr["Lead_Time"].ToString().Length >5 ) ? Oreadr["Lead_Time"].ToString() : "04-06";
					//tCat7.ReadOnly = true;
   
						
					stSql= "SELECT COMPNT_PRICE_LIST.compnt_man_Fam_ID FROM COMPNT_PRICE_LIST " +
						" WHERE COMPNT_PRICE_LIST.COMPONENT_ID=" + roptID + " AND COMPNT_PRICE_LIST.CAT1_VALUE='" + rCat1  + "' AND COMPNT_PRICE_LIST.CAT2_VALUE='" + rCat2  + "' AND COMPNT_PRICE_LIST.CAT3_VALUE='" + rCat3  + "' AND COMPNT_PRICE_LIST.CAT4_VALUE='" + rCat4   + "' AND COMPNT_PRICE_LIST.CAT5_VALUE='" + rCat5  + "' AND COMPNT_PRICE_LIST.CAT6_VALUE='" + rCat6 + "' AND COMPNT_PRICE_LIST.compnt_man_Fam_ID="+rFamID  + " AND COMPNT_PRICE_LIST.Manufac_ID="+rManID  ;
					if (!(MainMDI.Find_One_Field(stSql) !=MainMDI.VIDE ))
					{
						try
						{
							stSql= "INSERT INTO COMPNT_PRICE_LIST ([COMPONENT_ID],[Manufac_ID],[compnt_man_Fam_ID] " + 
								", [Manufac_PARTN],[Primax_PARTN],[CAT1_VALUE],[CAT2_VALUE], " + 
								" [CAT3_VALUE],[PRICE],[SPR_PRTS_COEF],[COMMENTS],[CAT4_VALUE],[CAT5_VALUE],[CAT6_VALUE],[CAT7_VALUE],[LeadTime], " + 
								"[CAT4fr_VALUE],[CAT5fr_VALUE],[CAT6fr_VALUE],[CAT7fr_VALUE]) VALUES ('" +
								roptID + "', '" + 	rManID  + "', '" + rFamID  + "', '" +
								rManifac.Replace("'","''") + "', '" + rPx.Replace("'","''")   + "', '" + rCat1.Replace("'","''") + "', '" +
								rCat2.Replace("'","''") + "', '"    + rCat3.Replace("'","''") + "', " + rUPrice + ", " +
								1  + ", '"  + " "   + "', '" + rCat4.Replace("'","''") + "', '" +
								rCat5.Replace("'","''") + "', '" + rCat6.Replace("'","''") + "', '" + "n/a" + "', '" +
								rDlvDelay + "', '" + rCat4fr.Replace("'","''") + "', '" + rCat5fr.Replace("'","''") + "', '" +
								rCat6fr.Replace("'","''") + "', '" + "n/a" +"')" ;
							MainMDI.ExecSql( stSql);
							MainMDI.Write_JFS(" IMPORT: " +stSql );
							//fill_lvOpt_priceList (0);
							lImpNB.Text = Convert.ToString (Int32.Parse(lImpNB.Text) +1);  
							this.Refresh ();
						
						}
						catch (SqlException Oexp)
						{
							MessageBox.Show("Adding Option Error...= " + Oexp.Message );
						}
					}
					else if (Oreadr["LineID"].ToString()!="")
					{
						if (xst.Length > 60) { big_exst += "\n" + xst  ; xst="";}
						xst += "," + Oreadr["LineID"].ToString(); 
					}
				}
			}

			if (big_exst.Length >18)  MessageBox.Show (big_exst+ "\n" + xst,"Import Errors"); 
			OConn.Close (); 
				
		}




		private void btnImport_Click(object sender, System.EventArgs e)
		{

          //  import_Cpts_Thyristor();
        //    import_Cpts_TB123();
            MessageBox.Show("BACKUP=" + (MainMDI.M_stCon_PL_BACK == MainMDI.M_stCon).ToString());
            MessageBox.Show("PROD=" + (MainMDI.M_stCon_PL_ORIG  == MainMDI.M_stCon).ToString());
 
            import_Cpts_PROD_TO_BACKPL();
			
			
		}


        
        private void insert_Update_PL_BACK_ORIG(string _tPX_code, string _loptID, string _lManID, string _lFamID, string _tManifac, string _tPx,
                                           string _tCat1, string _tCat2, string _tCat3, string _tUPrice, string _tCostUP, string _tComnt,
                                           string _tCat4, string _tCat5, string _tCat6, string _tCat7, string _tDlvDelay,string _tCat4fr, string _tCat5fr,
                                           string _tCat6fr, string _tCat7fr)
        {

            string _STCON = "";

            if (MainMDI.M_stCon_PL_BACK == MainMDI.M_stCon) _STCON =MainMDI.M_stCon_PL_ORIG;
            if (MainMDI.M_stCon_PL_ORIG == MainMDI.M_stCon) _STCON = MainMDI.M_stCon_PL_BACK;


            if (_tPX_code != "")
            {
                string _loptPLID = MainMDI.Find_One_Field_PL_BACK_ORIG("select PRICE_LINE_ID from COMPNT_PRICE_LIST where PL_Code='" + _tPX_code + "'",_STCON );
                if (_loptPLID == MainMDI.VIDE)
                {
                    try
                    {
                        string stSql = "INSERT INTO COMPNT_PRICE_LIST ([COMPONENT_ID],[Manufac_ID],[compnt_man_Fam_ID] " +
                            ", [Manufac_PARTN],[Primax_PARTN],[CAT1_VALUE],[CAT2_VALUE], " +
                            " [CAT3_VALUE],[PRICE],[Cost_Price],[SPR_PRTS_COEF],[COMMENTS],[CAT4_VALUE],[CAT5_VALUE],[CAT6_VALUE],[CAT7_VALUE],[LeadTime],[PL_Code], " +
                            "[CAT4fr_VALUE],[CAT5fr_VALUE],[CAT6fr_VALUE],[CAT7fr_VALUE]) VALUES ('" +
                              _loptID + "', '"
                            + _lManID + "', '"
                            + _lFamID + "', '"
                            + _tManifac.Replace("'", "''") + "', '"
                            + _tPx.Replace("'", "''") + "', '"
                            + _tCat1.Replace("'", "''") + "', '"
                            + _tCat2.Replace("'", "''") + "', '"
                            + _tCat3.Replace("'", "''") + "', "
                            + _tUPrice + ", "
                            + _tCostUP + ", "
                            + 1 + ", '"
                            + _tComnt.Replace("'", "''") + "', '"
                            + _tCat4.Replace("'", "''") + "', '"
                            + _tCat5.Replace("'", "''") + "', '"
                            + _tCat6.Replace("'", "''") + "', '"
                            + _tCat7.Replace("'", "''") + "', '"
                            + _tDlvDelay + "', '"
                            + _tPX_code + "', '"
                            + _tCat4fr.Replace("'", "''") + "', '"
                            + _tCat5fr.Replace("'", "''") + "', '"
                            + _tCat6fr.Replace("'", "''") + "', '"
                            + _tCat7fr.Replace("'", "''") + "')";
                        MainMDI.ExecSql_BACK_ORIG (stSql,_STCON );
                        MainMDI.Write_JFS(stSql + "====> INSERT into BACKUP LIST_PRice...pxcode=" + _tPX_code);
                    }
                    catch (SqlException Oexp)
                    {
                        MessageBox.Show("Adding  / insert_Update_PL_BACK options..." + Oexp.Message);
                    }
                }
                else if (_loptPLID!="ERROR")
                {
                    try
                    {
                        string stSql = "UPDATE COMPNT_PRICE_LIST SET " +
                            " [Manufac_PARTN]='" + _tManifac.Replace("'", "''") + "', " +
                            " [Primax_PARTN]='" + _tPx.Replace("'", "''") + "', " +
                            " [CAT1_VALUE]='" + _tCat1.Replace("'", "''") + "', " +
                            " [CAT2_VALUE]='" + _tCat2.Replace("'", "''") + "', " +
                            " [CAT3_VALUE]='" + _tCat3.Replace("'", "''") + "', " +
                            " [CAT4_VALUE]='" + _tCat4.Replace("'", "''") + "', " +
                            " [CAT5_VALUE]='" + _tCat5.Replace("'", "''") + "', " +
                            " [CAT6_VALUE]='" + _tCat6.Replace("'", "''") + "', " +
                            " [CAT7_VALUE]='" + _tCat7.Replace("'", "''") + "', " +
                            " [CAT4fr_VALUE]='" + _tCat4fr.Replace("'", "''") + "', " +
                            " [CAT5fr_VALUE]='" + _tCat5fr.Replace("'", "''") + "', " +
                            " [CAT6fr_VALUE]='" + _tCat6fr.Replace("'", "''") + "', " +
                            " [CAT7fr_VALUE]='" + _tCat7fr.Replace("'", "''") + "', " +
                            " [PRICE]=" + _tUPrice + ", " +
                            " [Cost_Price]=" + _tCostUP + ", " +
                            " [SPR_PRTS_COEF]=" + "1" + ", " +
                            " [LeadTime]='" + _tDlvDelay + "', " +
                            " [COMMENTS]='" + _tComnt.Replace("'", "''") + "' " +
                            " WHERE [PL_Code]='" + _tPX_code +"'";
                        //if (_tPX_code =="EN02M11F01-005") _tPX_code =_tPX_code ;
                        MainMDI.ExecSql_BACK_ORIG  (stSql,_STCON );
                        MainMDI.Write_JFS(stSql + "====> UPDATE BACKUP LIST_PRice....pxcode: " + _tPX_code);

                    }
                    catch (SqlException Oexp)
                    {
                        MessageBox.Show("Updating / insert_Update_PL_BACK options...= " + Oexp.Message);
                    }

                }
            }
            else MessageBox.Show("ERROR PX_CODE....." + _tPX_code);
        }


        private void FindRec_TO_PLBACK(string PX_Code)
        {



            string stSql = "select * FROM COMPNT_PRICE_LIST where PL_Code='" + PX_Code +"'";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                insert_Update_PL_BACK_ORIG(Oreadr["PL_Code"].ToString(), Oreadr["COMPONENT_ID"].ToString(), Oreadr["Manufac_ID"].ToString(), Oreadr["compnt_man_Fam_ID"].ToString(), Oreadr["Manufac_PARTN"].ToString(), Oreadr["Primax_PARTN"].ToString(), Oreadr["CAT1_VALUE"].ToString(), Oreadr["CAT2_VALUE"].ToString(), Oreadr["CAT3_VALUE"].ToString(), Oreadr["PRICE"].ToString(), Oreadr["Cost_Price"].ToString(), Oreadr["COMMENTS"].ToString(), Oreadr["CAT4_VALUE"].ToString(), Oreadr["CAT5_VALUE"].ToString(), Oreadr["CAT6_VALUE"].ToString(), Oreadr["CAT7_VALUE"].ToString(), Oreadr["LeadTime"].ToString(), Oreadr["CAT4FR_VALUE"].ToString(), Oreadr["CAT5FR_VALUE"].ToString(), Oreadr["CAT6FR_VALUE"].ToString(), Oreadr["CAT7FR_VALUE"].ToString());
            }

            OConn.Close();

        }

        private void Upadte_PL_BACK_FROMTO_ORIG()
        {

           for (int i = 0; i < lvOptPricelst.SelectedItems.Count; i++)
            {
                string PX_code = lvOptPricelst.Items[lvOptPricelst.SelectedItems[i].Index].SubItems[9].Text;
                if (PX_code.Length < 7) MessageBox.Show("PX_code ????= " + PX_code );
                else FindRec_TO_PLBACK(PX_code );
            }

        }


        private void import_Cpts_PROD_TO_BACKPL()
        {



            string stSql = "select * FROM Sheet1 ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                if (Oreadr["Primax Code"].ToString().Length < 7) MessageBox.Show("debut import=" + Oreadr["Description"].ToString());
                else FindRec_TO_PLBACK(Oreadr["Primax Code"].ToString());

            }

            OConn.Close();

        }


        private void import_Cpts_Fuses()
        {

            //	clear_scrn(); 

            //	lvOptPricelst.SelectedItems[0].BackColor = Color.WhiteSmoke;  

            string stSql = "select * FROM Import_fuses ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                if (Oreadr["Code"].ToString() == "n/a")
                {
                  //  cbPFamily.Text = Oreadr["CPT_Family"].ToString();
                    tCat1.Text = Oreadr["IF1"].ToString();
                    tCat2.Text = Oreadr["VDC"].ToString();
                    tCat3.Text = Oreadr["IFA"].ToString();
                    tUPrice.Text = Math.Round ( Tools.Conv_Dbl (Oreadr["Sell_Price"].ToString()),0).ToString ();
                    tCostUP.Text = Math.Round(Tools.Conv_Dbl(Oreadr["Cost_Price"].ToString()), 0).ToString();
                    tComnt.Text = "";
                    tDlvDelay.Text = "04-06";
                    tCat4.Text = MainMDI.VIDE;
                    tCat5.Text = MainMDI.VIDE;
                    tCat6.Text = MainMDI.VIDE;
                    tCat7.Text = MainMDI.VIDE;
                    tPX_code.Text = "";
                    tCat4fr.Text = MainMDI.VIDE;
                    tCat5fr.Text = MainMDI.VIDE;
                    tCat6fr.Text = MainMDI.VIDE;
                    tCat7fr.Text = MainMDI.VIDE;

                    if (MainMDI.Confirm("Save ?")) Save_LinePrice();
                }

            }

            OConn.Close();

        }

        private void import_Cpts_TB123()
        {

            //Thyristor

            string stSql = "select * FROM Import_TB123 ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                if (Oreadr["Primax Code"].ToString() == "n/a")
                {
                   MessageBox.Show("Baaaaaaaaaaaaaaaaad");
                    //  cbPFamily.Text = Oreadr["CPT_Family"].ToString();
/*
                    
                    tCat1.Text = Oreadr["W1mm"].ToString();
                     tCat2.Text = MainMDI.VIDE;// Oreadr["IDC"].ToString();
                    tCat3.Text =MainMDI.VIDE;// Oreadr["A/10ms"].ToString();
                    tUPrice.Text = Math.Round(Tools.Conv_Dbl(Oreadr["Sell Price"].ToString()), 0).ToString();
                    tCostUP.Text = Math.Round(Tools.Conv_Dbl(Oreadr["Cost Price"].ToString()), 0).ToString();
                    tComnt.Text = "";
                    tDlvDelay.Text = "04-06";
                    tCat4.Text = Oreadr["Description"].ToString();
                    tCat5.Text = MainMDI.VIDE;
                    tCat6.Text = MainMDI.VIDE;
                    tCat7.Text = MainMDI.VIDE;
                    tPX_code.Text = "";
                    tCat4fr.Text = MainMDI.VIDE;
                    tCat5fr.Text = MainMDI.VIDE;
                    tCat6fr.Text = MainMDI.VIDE;
                    tCat7fr.Text = MainMDI.VIDE;

                    if (MainMDI.Confirm("Save ?")) Save_LinePrice();
 */
                   
                }
                else
                {
                    string st1 = Math.Round(Tools.Conv_Dbl(Oreadr["Sell Price"].ToString()), 0).ToString();
                    string st2 = Math.Round(Tools.Conv_Dbl(Oreadr["Cost Price"].ToString()), 0).ToString();
                    MessageBox.Show("NB= " + MainMDI.Find_One_Field("select count(PRICE_LINE_ID) from COMPNT_PRICE_LIST where  PL_Code='" + Oreadr["Primax Code"].ToString() + "'") + "    Sprice=" + st1 + "  Cprice=" + st2);
                    stSql = "UPDATE COMPNT_PRICE_LIST SET " +
                                " [PRICE]=" + st1 + ", " +
                                " [Cost_Price]=" + st2 +
                                " where  PL_Code='" + Oreadr["Primax Code"].ToString() + "'";

                    MainMDI.ExecSql(stSql);

                }


            }

            OConn.Close();

        }



        private void import_Cpts_Thyristor()
        {

            //Thyristor

            string stSql = "select * FROM Import_Thyristor ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                if (Oreadr["Code"].ToString() == "n/a")
                {
                    MessageBox.Show("Baaaaaaaaaaaaaaaaad"); 
                    //  cbPFamily.Text = Oreadr["CPT_Family"].ToString();
          
                    /*
                     * tCat1.Text = Oreadr["PHASE"].ToString();
                    tCat2.Text = Oreadr["IDC"].ToString();
                    tCat3.Text = Oreadr["A/10ms"].ToString();
                    tUPrice.Text = Math.Round(Tools.Conv_Dbl(Oreadr["Sell_Price"].ToString()), 0).ToString();
                    tCostUP.Text = Math.Round(Tools.Conv_Dbl(Oreadr["Cost_Price"].ToString()), 0).ToString();
                    tComnt.Text = "";
                    tDlvDelay.Text = "04-06";
                    tCat4.Text = Oreadr["Description"].ToString();
                    tCat5.Text = MainMDI.VIDE;
                    tCat6.Text = MainMDI.VIDE;
                    tCat7.Text = MainMDI.VIDE;
                    tPX_code.Text = "";
                    tCat4fr.Text = MainMDI.VIDE;
                    tCat5fr.Text = MainMDI.VIDE;
                    tCat6fr.Text = MainMDI.VIDE;
                    tCat7fr.Text = MainMDI.VIDE;

                    if (MainMDI.Confirm("Save ?")) Save_LinePrice();
                     * */
                }
                else
                {
                    MessageBox.Show("NB= " + MainMDI.Find_One_Field("select count(PRICE_LINE_ID) from COMPNT_PRICE_LIST where  PL_Code='" + Oreadr["Code"].ToString() + "'"));
                    stSql = "UPDATE COMPNT_PRICE_LIST SET " +
                                " [PRICE]=" + Math.Round(Tools.Conv_Dbl(Oreadr["Sell_Price"].ToString()), 0).ToString() + ", " +
                                " [Cost_Price]=" + Math.Round(Tools.Conv_Dbl(Oreadr["Cost_Price"].ToString()), 0).ToString() +
                                " where  PL_Code='" + Oreadr["Code"].ToString() + "'";

                    MainMDI.ExecSql(stSql);
                }
 

            }

            OConn.Close();

        }

        //import new prices from XL file [ code / newprice ] to Table named T1 for ex.
        //call import_NewPrices_CPTxx("T1")




		private void Codif_Cpts()    //after creating COMPNT_Codif_temp
		{
		
 
			string stSql= "select * FROM COMPNT_Codif_temp ";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			string oldP="", oldM="",oldF="" ;
			int PL=0;
			lImpNB.Text="0";

			while (Oreadr.Read ())
			{
				//loptPLID.Text = Oreadr["PRICE_LINE_ID"].ToString();
				if (oldP !=  Oreadr["PX_Code"].ToString()) 	{ oldP =  Oreadr["PX_Code"].ToString(); PL =0;}
				if (oldM !=  Oreadr["M_Code"].ToString()) 	{ oldM =  Oreadr["M_Code"].ToString(); PL =0;}
				if (oldF !=  Oreadr["F_Code"].ToString()) 	{ oldF =  Oreadr["F_Code"].ToString(); PL =0;}
			    string prcLst_PLcod=MainMDI.Find_One_Field("select  PL_Code from COMPNT_PRICE_LIST where PRICE_LINE_ID=" + Oreadr["PRICE_LINE_ID"].ToString());
				if (prcLst_PLcod=="")
				{
					PL++;
					string plcode=Oreadr["PX_Code"].ToString()+"M"+ Oreadr["M_Code"].ToString() + "F" +  Oreadr["F_Code"].ToString() + "-" + MainMDI.A00(PL,3);   
					try
					{
						stSql= " UPDATE   COMPNT_PRICE_LIST SET PL_Code ='" + plcode + "' WHERE PRICE_LINE_ID =" +  Oreadr["PRICE_LINE_ID"].ToString();
						MainMDI.ExecSql( stSql);
						MainMDI.Write_JFS(" CPT Codif.:  " +stSql );
						lImpNB.Text = Convert.ToString (Int32.Parse(lImpNB.Text) +1);  
						this.Refresh ();
						
					}
					catch (SqlException Oexp)
					{
						MessageBox.Show("Updating Codif. Error...= " + Oexp.Message );
					}
				}
			}	
			OConn.Close (); 
				
		}

		private void label22_Click(object sender, System.EventArgs e)
		{
		
		}

		private void cbPFamily_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


		private void XPRT_ALLPL_OKold()
		{


            string stSql = " SELECT   Component_ID, Sort_flds , Component_Name From COMPNT_LIST ";
  
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
        //    MainMDI.OpenKnownFile("DEL " + MainMDI.XL_Path+ @"\XL_PriceList.xls");
            System.IO.File.Delete(MainMDI.XL_Path + @"\PriceList.xls");
            debut = true;
            XLName = MainMDI.XL_Path + @"\XL_PriceList.xls";
			while (Oreadr.Read ())
			{
             //   if (Oreadr["Component_ID"].ToString() == "230") stSql = stSql; //debug

                xprt_priceList(Oreadr["Component_ID"].ToString(),Oreadr["Sort_flds"].ToString());
                //lImpNB.Text = Oreadr["Component_ID"].ToString();
                lCPTname.Text = Oreadr["Component_Name"].ToString();
                lCPTname.Refresh();
               if (btnPrintPL.Text != "OPEN XL")
               {
                   btnPrintPL.Text = "OPEN XL";
                   btnPrintPL.Enabled =false;
                   
               }

			}
			OConn.Close(); 
             btnPrintPL.Enabled =true;
             lCPTname.Visible = false;
			//lvOptPricelst.Items.Clear();
		
			
		}

        private bool find_inNCL(char _cod, string _cptID, string _MANid, string _FAMid, string _PriceLID)
        {
            bool res = false;
            string STwhr = " Where Cod_op='" + _cod + "' and ";
            switch (_cod)
            {
                case 'T':
                    STwhr += " CPTid='" + _cptID + "' ";
                    break;
                case 'M':
                    STwhr += " CPTid='" + _cptID + "' and MANid='" + _MANid + "' ";
                    break;
                case 'F':
                    STwhr += " CPTid='" + _cptID + "' and MANid='" + _MANid + "' and FAMid='" + _FAMid + "' ";
                    break;
                case 'P':
                    STwhr += " LPRICEid='" + _PriceLID + "' ";
                    break;
                default:
                    MessageBox.Show("find_inNCL.....cod=" + _cod);
                    STwhr = "";
                    break;
            }
            if (STwhr != "")
            {
                res = MainMDI.Find_One_Field("select cfLID from PSM_C_XLPList " + STwhr) != MainMDI.VIDE;
            }
            return res;

        }


        private void XPRT_ALLPL(int cod)
        {


            string stSql = " SELECT   Component_ID, Sort_flds , Component_Name From COMPNT_LIST ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            //    MainMDI.OpenKnownFile("DEL " + MainMDI.XL_Path+ @"\XL_PriceList.xls");
            System.IO.File.Delete(MainMDI.XL_Path + @"\PriceList.xls");
            debut = true;
            XLName = MainMDI.XL_Path + @"\XL_PriceList.xls";
            while (Oreadr.Read())
            {
                //   if (Oreadr["Component_ID"].ToString() == "230") stSql = stSql; //debug
                if (  !find_inNCL('T', Oreadr["Component_ID"].ToString(), "", "", ""))
                {
                   if (cod==0)  xprt_priceList(Oreadr["Component_ID"].ToString(), Oreadr["Sort_flds"].ToString());
                   else xprt_priceList_DESC_LANG (Oreadr["Component_ID"].ToString(), Oreadr["Sort_flds"].ToString());
                    //lImpNB.Text = Oreadr["Component_ID"].ToString();
                    lCPTname.Text = Oreadr["Component_Name"].ToString();
                    lCPTname.Refresh();
                    if (btnPrintPL.Text != "OPEN XL")
                    {
                        btnPrintPL.Text = "OPEN XL";
                        btnPrintPL.Enabled = false;

                    }
                }

            }
            OConn.Close();
            btnPrintPL.Enabled = true;
            lCPTname.Visible = false;
            //lvOptPricelst.Items.Clear();


        }
	

		private void xprt_priceListOK_24082009(string _cptLID,string srt )
		{

			string stSql="";
          
			string srtSql=find_CPT_Sort(loptID_orig.Text,srt);
			
	//        stSql=" SELECT     COMPNT_PRICE_LIST.PRICE_LINE_ID, COMPNT_PRICE_LIST.CAT1_VALUE, COMPNT_PRICE_LIST.CAT2_VALUE, COMPNT_PRICE_LIST.CAT3_VALUE, COMPNT_PRICE_LIST.PRICE, COMPNT_PRICE_LIST.CAT4_VALUE, COMPNT_PRICE_LIST.CAT5_VALUE, COMPNT_PRICE_LIST.CAT6_VALUE, " +
    //              "           COMPNT_PRICE_LIST.LeadTime, COMPNT_PRICE_LIST.PL_Code, COMPNT_LIST.Component_Name,COMPNT_LIST.COMPONENT_REF, COMPNT_LIST.CatName1, COMPNT_LIST.CatName2, COMPNT_LIST.CatName3        " +        
    //              " FROM   COMPNT_PRICE_LIST INNER JOIN COMPNT_LIST ON COMPNT_PRICE_LIST.COMPONENT_ID = COMPNT_LIST.Component_ID INNER JOIN COMPNT_MANUFAC ON COMPNT_PRICE_LIST.Manufac_ID = COMPNT_MANUFAC.MANUFAC_ID INNER JOIN " +
     //             "        COMPNT_MANUFAC_FAMILY ON COMPNT_PRICE_LIST.compnt_man_Fam_ID = COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID " + 
	//			  " WHERE  COMPNT_PRICE_LIST.COMPONENT_ID =" + _cptLID + " ORDER BY COMPNT_PRICE_LIST.Manufac_ID, COMPNT_PRICE_LIST.compnt_man_Fam_ID ";

            stSql = " SELECT COMPNT_PRICE_LIST.PRICE_LINE_ID, COMPNT_PRICE_LIST.CAT1_VALUE, COMPNT_PRICE_LIST.CAT2_VALUE, COMPNT_PRICE_LIST.CAT3_VALUE, COMPNT_PRICE_LIST.CAT4_VALUE, COMPNT_PRICE_LIST.CAT5_VALUE, COMPNT_PRICE_LIST.CAT6_VALUE, COMPNT_PRICE_LIST.LeadTime, " +
                  "        COMPNT_PRICE_LIST.PL_Code, COMPNT_LIST.Component_Name, COMPNT_LIST.COMPONENT_REF, COMPNT_LIST.CatName1, COMPNT_LIST.CatName2, COMPNT_LIST.CatName3, COMPNT_PRICE_LIST.Cost_Price, COMPNT_PRICE_LIST.PRICE AS sellPrice, " +
                  "        COMPNT_MANUFAC_FAMILY.[Desc] AS family, COMPNT_MANUFAC_FAMILY.Pref AS priority, COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID AS FAM_ID " +
                  " FROM   COMPNT_PRICE_LIST INNER JOIN COMPNT_LIST ON COMPNT_PRICE_LIST.COMPONENT_ID = COMPNT_LIST.Component_ID INNER JOIN COMPNT_MANUFAC ON COMPNT_PRICE_LIST.Manufac_ID = COMPNT_MANUFAC.MANUFAC_ID INNER JOIN " +
                  "        COMPNT_MANUFAC_FAMILY ON COMPNT_PRICE_LIST.compnt_man_Fam_ID = COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID " +
                  " WHERE     COMPNT_PRICE_LIST.COMPONENT_ID = " + _cptLID  +
                  " ORDER BY COMPNT_PRICE_LIST.Manufac_ID, COMPNT_PRICE_LIST.compnt_man_Fam_ID ";//, CAST(COMPNT_PRICE_LIST.CAT1_VALUE AS float), CAST(COMPNT_PRICE_LIST.CAT2_VALUE AS float), CAST(COMPNT_PRICE_LIST.CAT3_VALUE AS float) ";
            
            if (srtSql!="") stSql += ", " + srtSql;
            if (MainMDI.Find_One_Field(stSql) != MainMDI.VIDE)
            {
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();

                string NewCpt = "";
                Object m_objOpt = System.Reflection.Missing.Value;
                // Excel.Application  m_objXL = new Excel.Application();
               if (m_objXL ==null ) m_objXL = new Excel.Application();

                Excel.Workbook m_objBook = m_objXL.Workbooks.Open(XLName, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                Excel.Sheets m_objSheets = m_objBook.Worksheets;
                int MAX_Cols = 10;

                Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.Add(m_objOpt, m_objOpt, m_objOpt, m_objOpt);//  .get_Item(1);

                string CelFrom = "A1", CelTo = "J1", cat1NM = "", cat2NM = "", cat3NM = "";
                Idata = new string[XL_MaxItem, MAX_Cols ];
                init_Idata();
                icount = 0;

                while (Oreadr.Read())
                {
                    if (cat1NM == "")
                    {

                        cat1NM = (Oreadr["CatName1"].ToString()=="T" || Oreadr["CatName1"].ToString()==MainMDI.VIDE ) ? "CAT1" : Oreadr["CatName1"].ToString();
                        cat2NM = (Oreadr["CatName2"].ToString() == "T" || Oreadr["CatName2"].ToString() == MainMDI.VIDE) ? "CAT2" : Oreadr["CatName2"].ToString();
                        cat3NM = (Oreadr["CatName3"].ToString() == "T" || Oreadr["CatName3"].ToString() == MainMDI.VIDE) ? "CAT3" : Oreadr["CatName3"].ToString();
                      
                       // NewCpt = "(" + Oreadr["COMPONENT_REF"].ToString() + ") " + MainMDI.optDesc(0, Oreadr["Component_Name"].ToString());
                        NewCpt = MainMDI.optDesc(0, Oreadr["Component_Name"].ToString());
                    }

                    string stfullD = Oreadr["CAT4_VALUE"].ToString() + ", " + Oreadr["CAT5_VALUE"].ToString() + ", " + Oreadr["CAT6_VALUE"].ToString(); // + ", " + Oreadr["CAT7_VALUE"].ToString () ;
                    stfullD += (Oreadr["CAT5_VALUE"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAT5_VALUE"].ToString();
                    stfullD += (Oreadr["CAT6_VALUE"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAT6_VALUE"].ToString();
                    Idata[icount, 0] = "'" + stfullD; //.Replace ("=","'=");
                    Idata[icount, 1] =(cat1NM == "CAT1") ? " " : Oreadr["CAT1_VALUE"].ToString();
                    Idata[icount, 2] = (cat2NM == "CAT2") ? " " : Oreadr["CAT2_VALUE"].ToString();
                    Idata[icount, 3] = (cat3NM == "CAT3") ? " " : Oreadr["CAT3_VALUE"].ToString();
                    Idata[icount, 4] = Oreadr["sellPrice"].ToString();
                    Idata[icount, 5] = Oreadr["Cost_Price"].ToString();
                    Idata[icount, 6] = Oreadr["family"].ToString();
                    Idata[icount, 7] = Oreadr["priority"].ToString();
                    Idata[icount, 8] = Oreadr["FAM_ID"].ToString();
                    

                    Idata[icount++, 9] = Oreadr["PL_Code"].ToString();

                    //	write_XL(Oreadr["Component_Name"].ToString (),CelFromTo ,objHdrs,Idata); 

                }
                //     Excel._Worksheet ws = ((Excel._Worksheet) m_objSheets.get_Item( 
             //   MessageBox.Show (icount.ToString ()); 
                Excel.Range m_objRng = m_objSheet.get_Range(CelFrom, CelTo);
                string[] objHdrs = { "Description", cat1NM, cat2NM, cat3NM, "Sell Price", "Cost Price","CPT Family","Priority","FamID" ,"Primax Code" };
                m_objRng.Value2 = objHdrs;
                Excel.Font m_objFont = m_objRng.Font;
                m_objFont.Bold = true;
                object[,] objData = new object[XL_MaxItem, MAX_Cols];
                for (int i = 0; i < XL_MaxItem; i++)
                {
                    for (int j = 0; j < MAX_Cols; j++) objData[i, j] = (Idata[i, 0] != "") ? Idata[i, j] : "";
                }

                m_objRng = m_objSheet.get_Range("A2", m_objOpt);
                m_objRng = m_objRng.get_Resize(XL_MaxItem, MAX_Cols);
                m_objRng.Value2 = objData;
                NewCpt=NewCpt.Replace("/", " ");
                NewCpt =(NewCpt.Length >30) ? NewCpt.Substring(0,30) : NewCpt ;
                m_objSheet.Name = (NewCpt != "") ? NewCpt  : _cptLID;

                int WSNb = m_objBook.Worksheets.Count;
                m_objSheet.Move(m_objOpt, m_objBook.Worksheets[WSNb]);
                if (m_objBook.Worksheets.Count >2 )
                {
                    Excel.Worksheet ws = (Excel.Worksheet)m_objBook.Worksheets[1];
                    if (ws.Name == "Sheet1") ws.Delete(); 
               //         ((Excel.Worksheet)this.Application.ActiveWorkbook.Sheets[1]).Select(missing);
                   // &&  m_objBook.Worksheets[1]=="Sheet1")  m_objBook.Worksheets
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

        private void my_columnDelete(ref Excel._Worksheet objSheet, string cell)
        {
            Object m_objOpt = System.Reflection.Missing.Value;

            Excel.Range objRange =
            (Excel.Range)objSheet.get_Range(cell, m_objOpt);
            objRange.EntireColumn.Delete(m_objOpt );
           // releaseComObj(objRange);
        }

        private void xprt_priceList(string _cptLID, string srt)
        {

            string stSql = "";
            string[] arr_Cols = new string[10] { "A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1", "I1", "J1" };
            string srtSql = find_CPT_Sort(loptID_orig.Text, srt);

            //        stSql=" SELECT     COMPNT_PRICE_LIST.PRICE_LINE_ID, COMPNT_PRICE_LIST.CAT1_VALUE, COMPNT_PRICE_LIST.CAT2_VALUE, COMPNT_PRICE_LIST.CAT3_VALUE, COMPNT_PRICE_LIST.PRICE, COMPNT_PRICE_LIST.CAT4_VALUE, COMPNT_PRICE_LIST.CAT5_VALUE, COMPNT_PRICE_LIST.CAT6_VALUE, " +
            //              "           COMPNT_PRICE_LIST.LeadTime, COMPNT_PRICE_LIST.PL_Code, COMPNT_LIST.Component_Name,COMPNT_LIST.COMPONENT_REF, COMPNT_LIST.CatName1, COMPNT_LIST.CatName2, COMPNT_LIST.CatName3        " +        
            //              " FROM   COMPNT_PRICE_LIST INNER JOIN COMPNT_LIST ON COMPNT_PRICE_LIST.COMPONENT_ID = COMPNT_LIST.Component_ID INNER JOIN COMPNT_MANUFAC ON COMPNT_PRICE_LIST.Manufac_ID = COMPNT_MANUFAC.MANUFAC_ID INNER JOIN " +
            //             "        COMPNT_MANUFAC_FAMILY ON COMPNT_PRICE_LIST.compnt_man_Fam_ID = COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID " + 
            //			  " WHERE  COMPNT_PRICE_LIST.COMPONENT_ID =" + _cptLID + " ORDER BY COMPNT_PRICE_LIST.Manufac_ID, COMPNT_PRICE_LIST.compnt_man_Fam_ID ";

            stSql = " SELECT COMPNT_PRICE_LIST.PRICE_LINE_ID, COMPNT_PRICE_LIST.CAT1_VALUE, COMPNT_PRICE_LIST.CAT2_VALUE, COMPNT_PRICE_LIST.CAT3_VALUE, COMPNT_PRICE_LIST.CAT4_VALUE, COMPNT_PRICE_LIST.CAT5_VALUE, COMPNT_PRICE_LIST.CAT6_VALUE, COMPNT_PRICE_LIST.LeadTime, " +
                  "        COMPNT_PRICE_LIST.PL_Code, COMPNT_LIST.Component_Name, COMPNT_LIST.COMPONENT_REF, COMPNT_LIST.CatName1, COMPNT_LIST.CatName2, COMPNT_LIST.CatName3, COMPNT_PRICE_LIST.Cost_Price, COMPNT_PRICE_LIST.PRICE AS sellPrice, " +
                  "        COMPNT_MANUFAC_FAMILY.[Desc] AS family, COMPNT_MANUFAC_FAMILY.Pref AS priority, COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID AS FAM_ID, COMPNT_MANUFAC_FAMILY.Manufac_ID, COMPNT_PRICE_LIST.COMPONENT_ID " +
                  " FROM   COMPNT_PRICE_LIST INNER JOIN COMPNT_LIST ON COMPNT_PRICE_LIST.COMPONENT_ID = COMPNT_LIST.Component_ID INNER JOIN COMPNT_MANUFAC ON COMPNT_PRICE_LIST.Manufac_ID = COMPNT_MANUFAC.MANUFAC_ID INNER JOIN " +
                  "        COMPNT_MANUFAC_FAMILY ON COMPNT_PRICE_LIST.compnt_man_Fam_ID = COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID " +
                  " WHERE     COMPNT_PRICE_LIST.COMPONENT_ID = " + _cptLID +
                  " ORDER BY COMPNT_PRICE_LIST.Manufac_ID, COMPNT_PRICE_LIST.compnt_man_Fam_ID ";//, CAST(COMPNT_PRICE_LIST.CAT1_VALUE AS float), CAST(COMPNT_PRICE_LIST.CAT2_VALUE AS float), CAST(COMPNT_PRICE_LIST.CAT3_VALUE AS float) ";

            if (srtSql != "") stSql += ", " + srtSql;
            if (MainMDI.Find_One_Field(stSql) != MainMDI.VIDE)
            {
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();

                string NewCpt = "";
                Object m_objOpt = System.Reflection.Missing.Value;
                // Excel.Application  m_objXL = new Excel.Application();
                if (m_objXL == null) m_objXL = new Excel.Application();

                Excel.Workbook m_objBook = m_objXL.Workbooks.Open(XLName, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                Excel.Sheets m_objSheets = m_objBook.Worksheets;
                int MAX_Cols = 10;

                Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.Add(m_objOpt, m_objOpt, m_objOpt, m_objOpt);//  .get_Item(1);

                string CelFrom = "A1", CelTo = "J1", cat1NM = "", cat2NM = "", cat3NM = "";
                Idata = new string[XL_MaxItem, MAX_Cols];
                init_Idata();
                icount = 0;
                
                while (Oreadr.Read())
                {
                    bool Cont=(!find_inNCL('P',"","","", Oreadr["PRICE_LINE_ID"].ToString()) && !find_inNCL('M',Oreadr["COMPONENT_ID"].ToString(),Oreadr["Manufac_ID"].ToString(),"","") && !find_inNCL('F',Oreadr["COMPONENT_ID"].ToString(),Oreadr["Manufac_ID"].ToString(),Oreadr["FAM_ID"].ToString(),""));
                    if (Cont)
                    {
                        if (cat1NM == "")
                        {

                            cat1NM = (Oreadr["CatName1"].ToString() == "T" || Oreadr["CatName1"].ToString() == MainMDI.VIDE) ? "CAT1" : Oreadr["CatName1"].ToString();
                            cat2NM = (Oreadr["CatName2"].ToString() == "T" || Oreadr["CatName2"].ToString() == MainMDI.VIDE) ? "CAT2" : Oreadr["CatName2"].ToString();
                            cat3NM = (Oreadr["CatName3"].ToString() == "T" || Oreadr["CatName3"].ToString() == MainMDI.VIDE) ? "CAT3" : Oreadr["CatName3"].ToString();

                            // NewCpt = "(" + Oreadr["COMPONENT_REF"].ToString() + ") " + MainMDI.optDesc(0, Oreadr["Component_Name"].ToString());
                            NewCpt = MainMDI.optDesc(0, Oreadr["Component_Name"].ToString());
                        }

                        string stfullD = Oreadr["CAT4_VALUE"].ToString() + ", " + Oreadr["CAT5_VALUE"].ToString() + ", " + Oreadr["CAT6_VALUE"].ToString(); // + ", " + Oreadr["CAT7_VALUE"].ToString () ;
                        stfullD += (Oreadr["CAT5_VALUE"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAT5_VALUE"].ToString();
                        stfullD += (Oreadr["CAT6_VALUE"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAT6_VALUE"].ToString();
                        Idata[icount, 0] = "'" + stfullD; //.Replace ("=","'=");
                        Idata[icount, 1] = (cat1NM == "CAT1") ? " " : Oreadr["CAT1_VALUE"].ToString();
                        Idata[icount, 2] = (cat2NM == "CAT2") ? " " : Oreadr["CAT2_VALUE"].ToString();
                        Idata[icount, 3] = (cat3NM == "CAT3") ? " " : Oreadr["CAT3_VALUE"].ToString();
                        Idata[icount, 4] = Oreadr["sellPrice"].ToString();
                        Idata[icount, 5] = Oreadr["Cost_Price"].ToString();
                        Idata[icount, 6] = Oreadr["family"].ToString();
                        Idata[icount, 7] = Oreadr["priority"].ToString();
                        Idata[icount, 8] = Oreadr["FAM_ID"].ToString();


                        Idata[icount++, 9] = Oreadr["PL_Code"].ToString();

                        //	write_XL(Oreadr["Component_Name"].ToString (),CelFromTo ,objHdrs,Idata); 
                    }
                }

                //     Excel._Worksheet ws = ((Excel._Worksheet) m_objSheets.get_Item( 
                //   MessageBox.Show (icount.ToString ()); 
                Excel.Range m_objRng = m_objSheet.get_Range(CelFrom, CelTo);
                string[] objHdrs = { "Description", cat1NM, cat2NM, cat3NM, "Sell Price", "Cost Price", "CPT Family", "Priority", "FamID", "Primax Code" };
                m_objRng.Value2 = objHdrs;
                Excel.Font m_objFont = m_objRng.Font;
                m_objFont.Bold = true;
                object[,] objData = new object[XL_MaxItem, MAX_Cols];
                for (int i = 0; i < XL_MaxItem; i++)
                {
                    for (int j = 0; j < MAX_Cols; j++) objData[i, j] = (Idata[i, 0] != "") ? Idata[i, j] : "";
                }

                m_objRng = m_objSheet.get_Range("A2", m_objOpt);
                m_objRng = m_objRng.get_Resize(XL_MaxItem, MAX_Cols);
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
                    //         ((Excel.Worksheet)this.Application.ActiveWorkbook.Sheets[1]).Select(missing);
                    // &&  m_objBook.Worksheets[1]=="Sheet1")  m_objBook.Worksheets
                }

                  
//delete column
               string binCols= MainMDI.Find_One_Field ("select CPTid from PSM_C_XLPList where Cod_op='C'");
               int c=0;
               if (binCols != MainMDI.VIDE)
               {
                   while (c<binCols.Length )
                   {
                       if (binCols[c] == '0')
                       {
                           Excel.Range objRange = m_objSheet.get_Range(arr_Cols[c], m_objOpt);
                           objRange.EntireColumn.Delete(m_objOpt);

                           binCols = binCols.Substring(0, c) + binCols.Substring(c + 1, binCols.Length - (c + 1));
                       }
                       else c++;
                   }
               }
//delete column

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



        private void xprt_priceList_DESC_LANG(string _cptLID, string srt)
        {

            string stSql = "";
            string[] arr_Cols = new string[10] { "A1", "B1", "C1", "D1", "E1", "F1", "G1", "H1", "I1", "J1" };
            string srtSql = find_CPT_Sort(loptID_orig.Text, srt);

            //        stSql=" SELECT     COMPNT_PRICE_LIST.PRICE_LINE_ID, COMPNT_PRICE_LIST.CAT1_VALUE, COMPNT_PRICE_LIST.CAT2_VALUE, COMPNT_PRICE_LIST.CAT3_VALUE, COMPNT_PRICE_LIST.PRICE, COMPNT_PRICE_LIST.CAT4_VALUE, COMPNT_PRICE_LIST.CAT5_VALUE, COMPNT_PRICE_LIST.CAT6_VALUE, " +
            //              "           COMPNT_PRICE_LIST.LeadTime, COMPNT_PRICE_LIST.PL_Code, COMPNT_LIST.Component_Name,COMPNT_LIST.COMPONENT_REF, COMPNT_LIST.CatName1, COMPNT_LIST.CatName2, COMPNT_LIST.CatName3        " +        
            //              " FROM   COMPNT_PRICE_LIST INNER JOIN COMPNT_LIST ON COMPNT_PRICE_LIST.COMPONENT_ID = COMPNT_LIST.Component_ID INNER JOIN COMPNT_MANUFAC ON COMPNT_PRICE_LIST.Manufac_ID = COMPNT_MANUFAC.MANUFAC_ID INNER JOIN " +
            //             "        COMPNT_MANUFAC_FAMILY ON COMPNT_PRICE_LIST.compnt_man_Fam_ID = COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID " + 
            //			  " WHERE  COMPNT_PRICE_LIST.COMPONENT_ID =" + _cptLID + " ORDER BY COMPNT_PRICE_LIST.Manufac_ID, COMPNT_PRICE_LIST.compnt_man_Fam_ID ";

            stSql = " SELECT COMPNT_PRICE_LIST.PRICE_LINE_ID, COMPNT_PRICE_LIST.CAT1_VALUE, COMPNT_PRICE_LIST.CAT2_VALUE, COMPNT_PRICE_LIST.CAT3_VALUE, COMPNT_PRICE_LIST.CAT4_VALUE, COMPNT_PRICE_LIST.CAT5_VALUE, COMPNT_PRICE_LIST.CAT6_VALUE,COMPNT_PRICE_LIST.CAT4FR_VALUE, COMPNT_PRICE_LIST.CAT5FR_VALUE, COMPNT_PRICE_LIST.CAT6FR_VALUE, COMPNT_PRICE_LIST.LeadTime, " +
                  "        COMPNT_PRICE_LIST.PL_Code, COMPNT_LIST.Component_Name, COMPNT_LIST.COMPONENT_REF, COMPNT_LIST.CatName1, COMPNT_LIST.CatName2, COMPNT_LIST.CatName3, COMPNT_PRICE_LIST.Cost_Price, COMPNT_PRICE_LIST.PRICE AS sellPrice, " +
                  "        COMPNT_MANUFAC_FAMILY.[Desc] AS family, COMPNT_MANUFAC_FAMILY.Pref AS priority, COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID AS FAM_ID, COMPNT_MANUFAC_FAMILY.Manufac_ID, COMPNT_PRICE_LIST.COMPONENT_ID " +
                  " FROM   COMPNT_PRICE_LIST INNER JOIN COMPNT_LIST ON COMPNT_PRICE_LIST.COMPONENT_ID = COMPNT_LIST.Component_ID INNER JOIN COMPNT_MANUFAC ON COMPNT_PRICE_LIST.Manufac_ID = COMPNT_MANUFAC.MANUFAC_ID INNER JOIN " +
                  "        COMPNT_MANUFAC_FAMILY ON COMPNT_PRICE_LIST.compnt_man_Fam_ID = COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID " +
                  " WHERE     COMPNT_PRICE_LIST.COMPONENT_ID = " + _cptLID +
                  " ORDER BY COMPNT_PRICE_LIST.Manufac_ID, COMPNT_PRICE_LIST.compnt_man_Fam_ID ";//, CAST(COMPNT_PRICE_LIST.CAT1_VALUE AS float), CAST(COMPNT_PRICE_LIST.CAT2_VALUE AS float), CAST(COMPNT_PRICE_LIST.CAT3_VALUE AS float) ";

            if (srtSql != "") stSql += ", " + srtSql;
            if (MainMDI.Find_One_Field(stSql) != MainMDI.VIDE)
            {
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();

                string NewCpt_EN = "", NewCpt_FR = "";
                Object m_objOpt = System.Reflection.Missing.Value;
                // Excel.Application  m_objXL = new Excel.Application();
                if (m_objXL == null) m_objXL = new Excel.Application();

                Excel.Workbook m_objBook = m_objXL.Workbooks.Open(XLName, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                Excel.Sheets m_objSheets = m_objBook.Worksheets;
                int MAX_Cols = 10;

                Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.Add(m_objOpt, m_objOpt, m_objOpt, m_objOpt);//  .get_Item(1);

                string CelFrom = "A1", CelTo = "J1", cat1NM = "", cat2NM = "", cat3NM = "";
                Idata = new string[XL_MaxItem, MAX_Cols];
                init_Idata();
                icount = 0;

                while (Oreadr.Read())
                {
                    bool Cont = (!find_inNCL('P', "", "", "", Oreadr["PRICE_LINE_ID"].ToString()) && !find_inNCL('M', Oreadr["COMPONENT_ID"].ToString(), Oreadr["Manufac_ID"].ToString(), "", "") && !find_inNCL('F', Oreadr["COMPONENT_ID"].ToString(), Oreadr["Manufac_ID"].ToString(), Oreadr["FAM_ID"].ToString(), ""));
                    if (Cont)
                    {
                        if (cat1NM == "")
                        {

                       //     cat1NM = (Oreadr["CatName1"].ToString() == "T" || Oreadr["CatName1"].ToString() == MainMDI.VIDE) ? "CAT1" : Oreadr["CatName1"].ToString();
                        //    cat2NM = (Oreadr["CatName2"].ToString() == "T" || Oreadr["CatName2"].ToString() == MainMDI.VIDE) ? "CAT2" : Oreadr["CatName2"].ToString();
                       //     cat3NM = (Oreadr["CatName3"].ToString() == "T" || Oreadr["CatName3"].ToString() == MainMDI.VIDE) ? "CAT3" : Oreadr["CatName3"].ToString();

                            // NewCpt = "(" + Oreadr["COMPONENT_REF"].ToString() + ") " + MainMDI.optDesc(0, Oreadr["Component_Name"].ToString());
                            NewCpt_EN = MainMDI.optDesc(0, Oreadr["Component_Name"].ToString());
                            NewCpt_FR = MainMDI.optDesc(1, Oreadr["Component_Name"].ToString());
                        }

                   //     string stfullD = Oreadr["CAT4_VALUE"].ToString() + ", " + Oreadr["CAT5_VALUE"].ToString() + ", " + Oreadr["CAT6_VALUE"].ToString(); // + ", " + Oreadr["CAT7_VALUE"].ToString () ;
                  //      stfullD += (Oreadr["CAT5_VALUE"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAT5_VALUE"].ToString();
                  //      stfullD += (Oreadr["CAT6_VALUE"].ToString() == MainMDI.VIDE) ? "" : Oreadr["CAT6_VALUE"].ToString();
                    
                        Idata[icount, 0] = "'" + NewCpt_EN ;
                        Idata[icount, 1] = (Oreadr["CAT4_VALUE"].ToString() == MainMDI.VIDE) ? " " : "'" + Oreadr["CAT4_VALUE"].ToString();
                        Idata[icount, 2] = (Oreadr["CAT5_VALUE"].ToString() == MainMDI.VIDE) ? " " : "'" + Oreadr["CAT5_VALUE"].ToString();
                        Idata[icount, 3] = (Oreadr["CAT6_VALUE"].ToString() == MainMDI.VIDE) ? " " : "'" + Oreadr["CAT6_VALUE"].ToString();
                        Idata[icount, 4] = NewCpt_FR;
                        Idata[icount, 5] = (Oreadr["CAT4FR_VALUE"].ToString() == MainMDI.VIDE) ? " " : "'" + Oreadr["CAT4FR_VALUE"].ToString();
                        Idata[icount, 6] = (Oreadr["CAT5FR_VALUE"].ToString() == MainMDI.VIDE) ? " " : "'" + Oreadr["CAT5FR_VALUE"].ToString();
                        Idata[icount, 7] = (Oreadr["CAT6FR_VALUE"].ToString() == MainMDI.VIDE) ? " " : "'" + Oreadr["CAT6FR_VALUE"].ToString();
                        Idata[icount, 8] = Oreadr["PL_Code"].ToString();


                        Idata[icount++, 9] = Oreadr["PRICE_LINE_ID"].ToString();

                        //	write_XL(Oreadr["Component_Name"].ToString (),CelFromTo ,objHdrs,Idata); 
                    }
                }

                //     Excel._Worksheet ws = ((Excel._Worksheet) m_objSheets.get_Item( 
                //   MessageBox.Show (icount.ToString ()); 
                Excel.Range m_objRng = m_objSheet.get_Range(CelFrom, CelTo);
                string[] objHdrs = { "EN_Name", "EN_Desc1", "EN_Desc2", "EN_Desc3", "FR_Name", "FR_Desc1", "FR_Desc2", "FR_Desc3","Primax Code","SYS_ID" };
                m_objRng.Value2 = objHdrs;
                Excel.Font m_objFont = m_objRng.Font;
                m_objFont.Bold = true;
                object[,] objData = new object[XL_MaxItem, MAX_Cols];
                for (int i = 0; i < XL_MaxItem; i++)
                {
                    for (int j = 0; j < MAX_Cols; j++) objData[i, j] = (Idata[i, 0] != "") ? Idata[i, j] : "";
                }

                m_objRng = m_objSheet.get_Range("A2", m_objOpt);
                m_objRng = m_objRng.get_Resize(XL_MaxItem, MAX_Cols);
                m_objRng.Value2 = objData;
                NewCpt_EN = NewCpt_EN.Replace("/", " ");
                NewCpt_EN = (NewCpt_EN.Length > 30) ? NewCpt_EN.Substring(0, 30) : NewCpt_EN;
                m_objSheet.Name = (NewCpt_EN != "") ? NewCpt_EN : _cptLID;

                int WSNb = m_objBook.Worksheets.Count;
                m_objSheet.Move(m_objOpt, m_objBook.Worksheets[WSNb]);
                if (m_objBook.Worksheets.Count > 2)
                {
                    Excel.Worksheet ws = (Excel.Worksheet)m_objBook.Worksheets[1];
                    if (ws.Name == "Sheet1") ws.Delete();
                    //         ((Excel.Worksheet)this.Application.ActiveWorkbook.Sheets[1]).Select(missing);
                    // &&  m_objBook.Worksheets[1]=="Sheet1")  m_objBook.Worksheets
                }


                //delete column
                /*
                string binCols = MainMDI.Find_One_Field("select CPTid from PSM_C_XLPList where Cod_op='C'");
                int c = 0;
                if (binCols != MainMDI.VIDE)
                {
                    while (c < binCols.Length)
                    {
                        if (binCols[c] == '0')
                        {
                            Excel.Range objRange = m_objSheet.get_Range(arr_Cols[c], m_objOpt);
                            objRange.EntireColumn.Delete(m_objOpt);

                            binCols = binCols.Substring(0, c) + binCols.Substring(c + 1, binCols.Length - (c + 1));
                        }
                        else c++;
                    }
                }
                 * */
                //delete column

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



		private void init_Idata()
		{
            for (int i = 0; i < XL_MaxItem; i++) Idata[i, 0] = "";
		}

		private void button3_Click_1(object sender, System.EventArgs e)
		{
		//	if (MainMDI.User =="Admin")
		//	{
		//		btnOK.Text ="&Save";
		//		btnOK_Click(sender,e); 
		//	}
		//	else btncpycat.Visible =false;
            if (tKey.Text != "")
            {
                bool FOUND = false;
                lvOptPricelst.Items.Clear();
                cbManuf.Items.Clear();
                cbPFamily.Items.Clear();
                if (button1x.Text == "Search") ndxfound = 0;
                for (int i = ndxfound; i < cbOptGrp.Items.Count; i++)
                    if (cbOptGrp.Items[i].ToString().ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1)
                    {
                        cbOptGrp.SelectedIndex = i;
                        ndxfound = i + 1;
                        i = cbOptGrp.Items.Count;
                      //  cbOptGrp_SelectedValueChanged(sender, e);
                        GO_GRPOptio();
                        if (ndxfound < cbOptGrp.Items.Count) button1x.Text = "Next";
                        FOUND = true;
                    }
                if (!FOUND)
                {
                    ndxfound = 0;
                    button1x.Text = "Search / Primax REF";
                    MessageBox.Show("KeyWord not Found !!!!");
                }
            }
		}

        private void btnPrintPL_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //Xport CPT's pricelist 
            if (MainMDI.User.ToLower () == "hnasrat" || MainMDI.User.ToLower () == "ede" || MainMDI.User.ToLower() == "blombard")
            {
                if (btnPrintPL.Text == "OPEN XL")
                {
                    MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\PriceList.xls");
                    btnPrintPL.Text = "XL PRICE LIST";
                }
                else if (MainMDI.Confirm("You want Create Price List ?"))
                {
                   // lImpNB.Visible = btnImport.Visible;
                    this.Refresh();
                    lCPTname.Visible = true;
                    XPRT_ALLPL(0);

                }
            }
            this.Cursor = Cursors.Default;

        }



        private void cbPFamily_SelectedIndexChanged_2(object sender, EventArgs e)
        {

        }

        private void button3_Click_2(object sender, EventArgs e)
        {
            if (tKey.Text != "")
            {
                bool FOUND = false;
                lvOptPricelst.Items.Clear();
                cbManuf.Items.Clear();
                cbPFamily.Items.Clear();
                if (button1x.Text == "Search") ndxfound = 0;
                for (int i = ndxfound; i < cbOptGrp.Items.Count; i++)
                    if (cbOptGrp.Items[i].ToString().ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1)
                    {
                        cbOptGrp.SelectedIndex = i;
                        ndxfound = i + 1;
                        i = cbOptGrp.Items.Count;
                      //  cbOptGrp_SelectedValueChanged(sender, e);
                        GO_GRPOptio();
                        if (ndxfound < cbOptGrp.Items.Count) button1x.Text = "Next";
                        FOUND = true;
                    }
                if (!FOUND)
                {
                    ndxfound = 0;
                    button1x.Text = "Search / Primax REF";
                    MessageBox.Show("KeyWord not Found !!!!");
                }
            }
        }

        private void button3_Enter(object sender, EventArgs e)
        {
            look_CPT_Ref();
        }

        private void tCostFac_DoubleClick(object sender, EventArgs e)
        {
            tCostFac.ReadOnly = !(MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "hnasrat");
     
        }



        private void tCostFac_TextChanged(object sender, EventArgs e)
        {

        }

        private void tPriority_TextChanged(object sender, EventArgs e)
        {

        }

        private void tPriority_DoubleClick(object sender, EventArgs e)
        {
            tPriority.ReadOnly = !(MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "hnasrat");
        }

        private void tUPrice_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnED_cpt_Click(object sender, EventArgs e)
        {
       //     Options_Cpt O_cpt = new Options_Cpt(cbOptGrp.Text  );
       //     this.Hide();
      //      O_cpt.ShowDialog();
      //     this.Visible = true;
            Edit_CPTs();

        }

        private void lvOptPricelst_ColumnClick_1(object sender, ColumnClickEventArgs e)
        {
            MessageBox.Show(lvOptPricelst.Columns[0].Width.ToString());
        }

        private void Edit_CPTs()
        {
            Options_Cpt O_cpt = new Options_Cpt(cbOptGrp.Text,cbManuf.Text  ,cbPFamily.Text  );
            O_cpt.ShowDialog();
            if (loptID_orig.Text!="") GO_GRPOptio();
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Edit_CPTs();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Edit_CPTs();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Edit_CPTs();
        }

        private void btnFixCost_Click(object sender, EventArgs e)
        {
            if (Tools.Conv_Dbl(tCostFac.Text) > 0 && (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "hnasrat"))
            {
                if (btnFixCost.Text == "Change")
                {
                    tCostFac.ReadOnly = false;
                    btnFixCost.Text = "Update Sell Price ";
                    tCostFac.Focus();
                    tCostFac.BackColor = Color.Lavender;
                    
                }
                else
                {
                    for (int i = 0; i < lvOptPricelst.Items.Count; i++)
                    {
                        double dd = Math.Round(Tools.Conv_Dbl(tCostFac.Text) * Tools.Conv_Dbl(lvOptPricelst.Items[i].SubItems[6].Text),0);// MainMDI.NB_DEC_AFF);
                        lvOptPricelst.Items[i].SubItems[5].Text = MainMDI.A00 (dd.ToString());
                        MainMDI.Exec_SQL_JFS("update COMPNT_PRICE_LIST set [Cost_Price]=" + dd.ToString() + " where PRICE_LINE_ID=" + lvOptPricelst.Items[i].SubItems[8].Text, " update new Price based on Cost factor !!!");

                    }
                    btnFixCost.Text = "Change";
                    tCostFac.ReadOnly = true;
                    tCostFac.BackColor = Color.AliceBlue;
                }
            }
            else btnFixCost.Visible = false;


        }

        private void btnPref_Click(object sender, EventArgs e)
        {
            if (Tools.Conv_Dbl(tPriority.Text) > 0 && picCIP.Visible && (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "hnasrat"))
            {
                if (btnPref.Text == "Change")
                {
                    tPriority.ReadOnly = false;
                    btnPref.Text = "Update family Priority";
                    tPriority.Focus();
                    tPriority.BackColor = Color.Lavender;
                }
                else
                {
                    string stsql = "update COMPNT_MANUFAC_FAMILY set [Pref]= " + tPriority.Text + " where Compnt_Man_FAM_ID=" + lFamID.Text;
                    MainMDI.Exec_SQL_JFS(stsql, " update Pref family....");
                    btnPref.Text = "Change";
                    tPriority.ReadOnly = true;
                    tPriority.BackColor = Color.AliceBlue;
                }
            }
            else btnPref.Visible = false;
        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            NL_Item_Option frmNLIO = new NL_Item_Option("0");
            this.Hide();
            frmNLIO.ShowDialog();
            this.Visible = true;
        }

        private void lvOptPricelst_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btn_PL_BACK_ORIG_Click(object sender, EventArgs e)
        {
            Upadte_PL_BACK_FROMTO_ORIG();
        }



        private void load_CPTs_Info_FRMLS()
        {
            string stSql = "select * FROM [COMPNT_LIST] where Compnt_Type='C' or Compnt_Type='E'  order by COMPONENT_REF";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            //	lvCompany.Clear ();
            while (Oreadr.Read())
            {
                //	tERef.Text =  Oreadr["COMPONENT_REF"].ToString() ; 
                //	tFRef.Text =  Oreadr["Component_Name"].ToString() ; 
                tERef.Text = MainMDI.optDesc(0, Oreadr["Component_Name"].ToString());
                tFRef.Text = MainMDI.optDesc(1, Oreadr["Component_Name"].ToString());
                tOptCmnt.Text = Oreadr["Ref_cmnt"].ToString();
                r_tOptCmnt.Text = tOptCmnt.Text;
                r_tERef.Text = tERef.Text;
                r_tFRef.Text = tFRef.Text;
                lCat1.Text = Oreadr["CatName1"].ToString();
                lCat2.Text = Oreadr["CatName2"].ToString();
                lCat3.Text = Oreadr["CatName3"].ToString();

                lvOptPricelst.Columns[1].Text = lCat1.Text;
                lvOptPricelst.Columns[2].Text = lCat2.Text;
                lvOptPricelst.Columns[3].Text = lCat3.Text;

                lCat1.Enabled = (Oreadr["CatName1"].ToString() != "n/a");
                lCat2.Enabled = (Oreadr["CatName2"].ToString() != "n/a");
                lCat3.Enabled = (Oreadr["CatName3"].ToString() != "n/a");

                init_LCATn();

                tCat1.Enabled = lCat1.Enabled;
                tCat2.Enabled = lCat2.Enabled;
                tCat3.Enabled = lCat3.Enabled;
                loptID.Text = Oreadr["Component_ID"].ToString();
                Aff_CptType(Oreadr["Compnt_Type"].ToString());
                ltype.Text = Oreadr["Compnt_Type"].ToString();
                r_type.Text = ltype.Text;
                tSort.Text = Oreadr["Sort_flds"].ToString();
                cptCODE = Oreadr["PX_Code"].ToString();

                //if (loptID.Text !="")	fill_lvOpt_priceList(0);		
            }
            OConn.Close();
        }

        private void button9_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            //Xport CPT's pricelist 
            if (MainMDI.User.ToLower () == "hnasrat" || MainMDI.User.ToLower () == "ede")
            {
                if (btnPrintPL.Text == "OPEN XL")
                {
                    MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\PriceList.xls");
                    btnPrintPL.Text = "XL PRICE LIST";
                }
                else if (MainMDI.Confirm("You want Create Price List ?"))
                {
                   // lImpNB.Visible = btnImport.Visible;
                    this.Refresh();
                    lCPTname.Visible = true;
                    XPRT_ALLPL (1);

                }
            }
            this.Cursor = Cursors.Default;

      
        }

        private void button10_Click(object sender, EventArgs e)
        {
            if (MainMDI.User.ToLower() == "ede")
            {
                tCat4fr.Text = tCat4fr.Text + " A";
                tCat4.Text = tCat4.Text + " A";
            }
            else button10.Visible = false;
        }



				
		/*
				ListViewItem lvI= lvOptPricelst.Items.Add( stfullD );
				lvI.SubItems.Add(Oreadr["CAT1_VALUE"].ToString()  ); 
				lvI.SubItems.Add( Oreadr["CAT2_VALUE"].ToString()); 
				lvI.SubItems.Add(Oreadr["CAT3_VALUE"].ToString());  
				//string tprice =(In_Opera != 'M') ? Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["price"].ToString()) * Tools.Conv_Dbl(tSellFac.Text ),MainMDI.NB_DEC_AFF  ))  :  Oreadr["price"].ToString();
				if (In_Opera == 'M') lvI.SubItems.Add(MainMDI.A00(Oreadr["price"].ToString())); 
				else lvI.SubItems.Add(MainMDI.VIDE); 
				if (tCostFac.Text !="") cF=Convert.ToDouble(tCostFac.Text )   ;
				if (tSellFac.Text !="") sF=Convert.ToDouble(tSellFac.Text );
				double Cost =Math.Round(Tools.Conv_Dbl(Oreadr["price"].ToString()) * cF,MainMDI.NB_DEC_AFF );
				double Sell = Math.Round(Tools.Conv_Dbl(Oreadr["price"].ToString()) * sF,MainMDI.NB_DEC_AFF );
				if (In_Opera == 'M') lvI.SubItems.Add(MainMDI.A00(Cost.ToString ())); 
				else lvI.SubItems.Add(MainMDI.VIDE); 
				lvI.SubItems.Add(MainMDI.A00(Sell.ToString () )); 
				if (Oreadr["LeadTime"].ToString()!="") lvI.SubItems.Add(Oreadr["LeadTime"].ToString()); 
				else lvI.SubItems.Add(MainMDI.Default_LeadTime  ); 
				lvI.SubItems.Add(Oreadr["PRICE_LINE_ID"].ToString()); 
				lvI.SubItems.Add(Oreadr["PL_CODE"].ToString());  
				//	MessageBox.Show(stout); 
		  */

		/*
		private string write_XL(string cptName, string CelsFromTo, string[] objHdrs  )
		{
			Object m_objOpt= System.Reflection.Missing.Value ;    
			Excel.Application  m_objXL = new Excel.Application()   ;
			Excel.Workbooks  m_objbooks = m_objXL.Workbooks ;
			Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);    
			Excel.Sheets m_objSheets = m_objBook.Worksheets ;
			Excel._Worksheet m_objSheet =(Excel._Worksheet) m_objSheets.get_Item(1);
  
			//object[] objHdrs = {"Emplyee","Project #"};
			Excel.Range  m_objRng = m_objSheet.get_Range(CelsFromTo.Substring(0,2),CelsFromTo.Substring(3,2));
			m_objRng.Value2=objHdrs ;
			Excel.Font m_objFont = m_objRng.Font ;
			m_objFont.Bold = true;

			object[,] objData = new object[500,6];
			for (int i=0;i<500 ;i++)
			{
				for (int j=0;j<6;j++)	objData[i,j]= (Idata[i,0] !="") ? Idata[i,j] : "" ; 
			}
 		
			m_objRng = m_objSheet.get_Range("A2",m_objOpt);
			m_objRng = m_objRng.get_Resize(500,2);
			m_objRng.Value2  = objData;

			m_objBook.SaveAs(MainMDI.XL_Path+ @"\XL_PriceList.xls",m_objOpt,m_objOpt,m_objOpt ,m_objOpt ,m_objOpt ,Excel.XlSaveAsAccessMode.xlNoChange ,m_objOpt ,m_objOpt ,m_objOpt ,m_objOpt,m_objOpt );
			m_objBook.Close (false,m_objOpt ,m_objOpt );
			m_objXL.Quit (); 

			
		}


		private void write_XL(object[] objHdrs,object[,] objData,int NBCols)
		{
			Object m_objOpt= System.Reflection.Missing.Value ;   
			Excel.Application  m_objXL = new Excel.Application()   ;
			Excel.Workbooks  m_objbooks = m_objXL.Workbooks ;
			Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);    
			Excel.Sheets m_objSheets = m_objBook.Worksheets ;
			Excel._Worksheet m_objSheet =(Excel._Worksheet) m_objSheets.get_Item(1);
  
			//object[] objHdrs = {"Emplyee","Project #"};
			Excel.Range  m_objRng = m_objSheet.get_Range("A1","B1");
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
		*/
	


	



	

	
	


	
		
	}
}
		

