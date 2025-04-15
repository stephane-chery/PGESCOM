using System;
using System.Drawing;
using System.Threading;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb ;
using System.Data.SqlClient ;
using System.Data ;
using EAHLibs;


namespace PGESCOM
{
	/// <summary>
	/// Summary description for LookQuotes.
	/// </summary>
	public class Orders_Look : System.Windows.Forms.Form
	{

        private ListViewColumnSorter  lvSorter=null;
		private int oldSC=0;
        Lib1 Tools = new Lib1();
        char EM = 'E';
        Color oldOrdersCLR = Color.Gray;

        private char srtType='A';
		private int ndxCLRD=-1;
		private int seelCol=0;
		private string seekColNm;
		private char in_typeO='L';
        private Hashtable HT_Projects = new Hashtable();
        private System.Windows.Forms.PictureBox picExit;
		private System.Windows.Forms.ImageList Fst_IL32;
        private Button btnUtst;
        private Label lblAff;
        private Label label2;
        private GroupBox groupBox1;
        private ToolStrip TSmain;
        private ToolStripButton findOrdr;
        private ToolStripButton _exit;
        private GroupBox grpfind;
        private CheckBox chk_ADV;
        private GroupBox grpCharg;
        private Label label1;
        private Label label5;
        private Label lFTTT;
        private Label lxxx;
        private ComboBox cbXXX;
        private Label label6;
        private Label label3;
        private Label label7;
        private Label label8;
        public ComboBox cbPhs;
        private Label label22;
        private ComboBox cbPxx;
        public ComboBox cbVdc;
        public ComboBox cbIdctmp;
        public ComboBox cbIdc;
        public ComboBox cbseekby;
        private Button button1;
        private Button btn_dispCB;
        private Button btnseek;
        public ComboBox cbRectifiers;
        public TextBox tKey;
        private Label lmodel;
        private Label label4;
        private ListView lvQuotes;
        private ColumnHeader Qdate;
        private ColumnHeader Proj_ID;
        private ColumnHeader CPO;
        private ColumnHeader Cpny;
        private ColumnHeader Proj;
        private ColumnHeader iRid;
        private ColumnHeader ProjID;
        private ColumnHeader amt;
        private ColumnHeader SNlist;
        private ColumnHeader QID;
        private ColumnHeader Tests;
        private ColumnHeader dblAmnt;
        public DateTimePicker dpTo;
        private Label lTo;
        public DateTimePicker dpFrom;
        private Label lfrom;
        private CheckBox chkdate;
        public ComboBox comboBox1;
        private ToolStripLabel PBWait;
        private ToolStripProgressBar TSpbar;
        private GroupBox groupBox2;
        private Label lnb;
        private ToolStripButton brd;
        private GroupBox grpcat;
        private RadioButton opInP;
        private RadioButton opAll;
        private RadioButton opSHP;
        private RadioButton opFapp;
        private Label lwhr_prjStatus;
        private Label lcbRectifiers;
        private Button button2;
        private ToolStripButton bigLst;
        public PictureBox picCIP;
        private ToolStripButton ts_sysPro;
        private ToolStripDropDownButton SCH_Ordr;
        private ToolStripMenuItem MecSC_AM;
        private ToolStripMenuItem MecSC_List;
        private ToolStripDropDownButton ListSCD;
        private ToolStripMenuItem ElecSC_AM;
        private ToolStripMenuItem ElecSC_List;
        private Button btnxl;
        private ToolStripDropDownButton tlsDDRep;
        private ToolStripMenuItem projectsScheduleToolStripMenuItem;
        private Label lprj;
        public TextBox txPrj;
		private System.ComponentModel.IContainer components;

		public Orders_Look(char x_typeO)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			lvSorter = new ListViewColumnSorter(); 
			this.lvQuotes.ListViewItemSorter  = lvSorter ; 
			lvQuotes.AutoArrange=true; 
            in_typeO=x_typeO; 
			lvQuotes.Items.Clear();  
			switch (in_typeO)
			{
				case 'B':  //big list
				case 'L':  //   liste=60 lines
                                     lblAff.Text = DateTime.Now.ToLongTimeString(); 
                    fill_lv_ORDERs_fast (in_typeO=='B');
                                     label2.Text = DateTime.Now.ToLongTimeString(); 
					break;
				case 'O':
                    button2.Visible = false;
                    grpcat.Visible = false;
                    chk_ADV.Visible = false;
                    ts_sysPro.Visible = false;
                    ListSCD.Visible = false;

					fill_lv_PX_ORDERs();
					break;
			}

			lvSorter.SortColumn =0;
			lvSorter.Order =System.Windows.Forms.SortOrder.Descending  ; //first err
			btnseek.Text = "Search by:    " + lvQuotes.Columns[0].Text ; 
			ColName(0);
			seelCol=0;
		//	btnseek.Enabled =true;
		//	ReSORT_lvQuotes(seelCol ); if you chng seelcol !=0 
		
		//	this.Cursor =Cursors.Default  ; 
			
			
  
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Orders_Look));
            this.Fst_IL32 = new System.Windows.Forms.ImageList(this.components);
            this.btnUtst = new System.Windows.Forms.Button();
            this.lblAff = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.findOrdr = new System.Windows.Forms.ToolStripButton();
            this.ts_sysPro = new System.Windows.Forms.ToolStripButton();
            this.tlsDDRep = new System.Windows.Forms.ToolStripDropDownButton();
            this.projectsScheduleToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bigLst = new System.Windows.Forms.ToolStripButton();
            this.SCH_Ordr = new System.Windows.Forms.ToolStripDropDownButton();
            this.MecSC_AM = new System.Windows.Forms.ToolStripMenuItem();
            this.MecSC_List = new System.Windows.Forms.ToolStripMenuItem();
            this.ListSCD = new System.Windows.Forms.ToolStripDropDownButton();
            this.ElecSC_AM = new System.Windows.Forms.ToolStripMenuItem();
            this.ElecSC_List = new System.Windows.Forms.ToolStripMenuItem();
            this.brd = new System.Windows.Forms.ToolStripButton();
            this._exit = new System.Windows.Forms.ToolStripButton();
            this.PBWait = new System.Windows.Forms.ToolStripLabel();
            this.TSpbar = new System.Windows.Forms.ToolStripProgressBar();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.grpfind = new System.Windows.Forms.GroupBox();
            this.lprj = new System.Windows.Forms.Label();
            this.btnxl = new System.Windows.Forms.Button();
            this.grpcat = new System.Windows.Forms.GroupBox();
            this.opInP = new System.Windows.Forms.RadioButton();
            this.opAll = new System.Windows.Forms.RadioButton();
            this.opSHP = new System.Windows.Forms.RadioButton();
            this.opFapp = new System.Windows.Forms.RadioButton();
            this.grpCharg = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lFTTT = new System.Windows.Forms.Label();
            this.lxxx = new System.Windows.Forms.Label();
            this.cbXXX = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbPhs = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cbPxx = new System.Windows.Forms.ComboBox();
            this.cbVdc = new System.Windows.Forms.ComboBox();
            this.cbIdctmp = new System.Windows.Forms.ComboBox();
            this.cbIdc = new System.Windows.Forms.ComboBox();
            this.lcbRectifiers = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.lwhr_prjStatus = new System.Windows.Forms.Label();
            this.lnb = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.lfrom = new System.Windows.Forms.Label();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.lTo = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.chkdate = new System.Windows.Forms.CheckBox();
            this.chk_ADV = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_dispCB = new System.Windows.Forms.Button();
            this.cbRectifiers = new System.Windows.Forms.ComboBox();
            this.tKey = new System.Windows.Forms.TextBox();
            this.lmodel = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbseekby = new System.Windows.Forms.ComboBox();
            this.btnseek = new System.Windows.Forms.Button();
            this.txPrj = new System.Windows.Forms.TextBox();
            this.lvQuotes = new System.Windows.Forms.ListView();
            this.Qdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Proj_ID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CPO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cpny = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Proj = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iRid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ProjID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SNlist = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tests = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dblAmnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.TSmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            this.grpfind.SuspendLayout();
            this.grpcat.SuspendLayout();
            this.grpCharg.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
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
            this.Fst_IL32.Images.SetKeyName(5, "scheduled_tasks-8.ICO");
            this.Fst_IL32.Images.SetKeyName(6, "clock-8.ICO");
            this.Fst_IL32.Images.SetKeyName(7, "view_text-8.ICO");
            // 
            // btnUtst
            // 
            this.btnUtst.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnUtst.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUtst.Location = new System.Drawing.Point(17, 107);
            this.btnUtst.Name = "btnUtst";
            this.btnUtst.Size = new System.Drawing.Size(54, 24);
            this.btnUtst.TabIndex = 201;
            this.btnUtst.Text = "Update TESTING";
            this.btnUtst.Visible = false;
            this.btnUtst.Click += new System.EventHandler(this.btnUtst_Click);
            // 
            // lblAff
            // 
            this.lblAff.BackColor = System.Drawing.Color.LimeGreen;
            this.lblAff.ForeColor = System.Drawing.Color.White;
            this.lblAff.Location = new System.Drawing.Point(989, 71);
            this.lblAff.Name = "lblAff";
            this.lblAff.Size = new System.Drawing.Size(152, 22);
            this.lblAff.TabIndex = 202;
            this.lblAff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblAff.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(989, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(152, 22);
            this.label2.TabIndex = 203;
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picCIP);
            this.groupBox1.Controls.Add(this.TSmain);
            this.groupBox1.Controls.Add(this.picExit);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1150, 81);
            this.groupBox1.TabIndex = 204;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(1094, 19);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(44, 48);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 266;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // TSmain
            // 
            this.TSmain.AutoSize = false;
            this.TSmain.BackColor = System.Drawing.Color.LemonChiffon;
            this.TSmain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.findOrdr,
            this.ts_sysPro,
            this.tlsDDRep,
            this.bigLst,
            this.SCH_Ordr,
            this.ListSCD,
            this.brd,
            this._exit,
            this.PBWait,
            this.TSpbar});
            this.TSmain.Location = new System.Drawing.Point(3, 16);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(1144, 57);
            this.TSmain.TabIndex = 259;
            // 
            // findOrdr
            // 
            this.findOrdr.Image = ((System.Drawing.Image)(resources.GetObject("findOrdr.Image")));
            this.findOrdr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findOrdr.Name = "findOrdr";
            this.findOrdr.Size = new System.Drawing.Size(74, 54);
            this.findOrdr.Text = "Find Project";
            this.findOrdr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.findOrdr.ToolTipText = "Find Project";
            this.findOrdr.Click += new System.EventHandler(this.findOrdr_Click);
            // 
            // ts_sysPro
            // 
            this.ts_sysPro.Image = ((System.Drawing.Image)(resources.GetObject("ts_sysPro.Image")));
            this.ts_sysPro.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ts_sysPro.Name = "ts_sysPro";
            this.ts_sysPro.Size = new System.Drawing.Size(96, 54);
            this.ts_sysPro.Text = "Send to SYSPRO";
            this.ts_sysPro.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ts_sysPro.Click += new System.EventHandler(this.ts_sysPro_Click);
            // 
            // tlsDDRep
            // 
            this.tlsDDRep.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.projectsScheduleToolStripMenuItem});
            this.tlsDDRep.Image = ((System.Drawing.Image)(resources.GetObject("tlsDDRep.Image")));
            this.tlsDDRep.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsDDRep.Name = "tlsDDRep";
            this.tlsDDRep.Size = new System.Drawing.Size(105, 54);
            this.tlsDDRep.Text = "SYSPRO Reports";
            this.tlsDDRep.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsDDRep.Click += new System.EventHandler(this.tlsDDRep_Click);
            // 
            // projectsScheduleToolStripMenuItem
            // 
            this.projectsScheduleToolStripMenuItem.BackColor = System.Drawing.Color.Khaki;
            this.projectsScheduleToolStripMenuItem.Name = "projectsScheduleToolStripMenuItem";
            this.projectsScheduleToolStripMenuItem.Size = new System.Drawing.Size(167, 22);
            this.projectsScheduleToolStripMenuItem.Text = "Projects Schedule";
            this.projectsScheduleToolStripMenuItem.Click += new System.EventHandler(this.projectsScheduleToolStripMenuItem_Click);
            // 
            // bigLst
            // 
            this.bigLst.Image = ((System.Drawing.Image)(resources.GetObject("bigLst.Image")));
            this.bigLst.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.bigLst.Name = "bigLst";
            this.bigLst.Size = new System.Drawing.Size(135, 54);
            this.bigLst.Text = "SYSPRO Projects InWait";
            this.bigLst.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.bigLst.Visible = false;
            this.bigLst.Click += new System.EventHandler(this.bigLst_Click);
            // 
            // SCH_Ordr
            // 
            this.SCH_Ordr.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.MecSC_AM,
            this.MecSC_List});
            this.SCH_Ordr.Image = ((System.Drawing.Image)(resources.GetObject("SCH_Ordr.Image")));
            this.SCH_Ordr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SCH_Ordr.Name = "SCH_Ordr";
            this.SCH_Ordr.Size = new System.Drawing.Size(138, 54);
            this.SCH_Ordr.Text = "MECANICAL Schedule";
            this.SCH_Ordr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SCH_Ordr.ToolTipText = "Add to Electrical List";
            this.SCH_Ordr.Visible = false;
            this.SCH_Ordr.Click += new System.EventHandler(this.SCH_Ordr_Click);
            // 
            // MecSC_AM
            // 
            this.MecSC_AM.Name = "MecSC_AM";
            this.MecSC_AM.Size = new System.Drawing.Size(145, 22);
            this.MecSC_AM.Text = "Add / Modify";
            this.MecSC_AM.Click += new System.EventHandler(this.MecSC_AM_Click);
            // 
            // MecSC_List
            // 
            this.MecSC_List.Name = "MecSC_List";
            this.MecSC_List.Size = new System.Drawing.Size(145, 22);
            this.MecSC_List.Text = "Schedule List";
            this.MecSC_List.Click += new System.EventHandler(this.MecSC_List_Click);
            // 
            // ListSCD
            // 
            this.ListSCD.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ElecSC_AM,
            this.ElecSC_List});
            this.ListSCD.Image = ((System.Drawing.Image)(resources.GetObject("ListSCD.Image")));
            this.ListSCD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ListSCD.Name = "ListSCD";
            this.ListSCD.Size = new System.Drawing.Size(136, 54);
            this.ListSCD.Text = "ELECTRICAL Schedule";
            this.ListSCD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ListSCD.ToolTipText = "Display Electrical List";
            this.ListSCD.Visible = false;
            this.ListSCD.Click += new System.EventHandler(this.ListSCD_Click);
            // 
            // ElecSC_AM
            // 
            this.ElecSC_AM.Name = "ElecSC_AM";
            this.ElecSC_AM.Size = new System.Drawing.Size(145, 22);
            this.ElecSC_AM.Text = "Add / Modify";
            this.ElecSC_AM.Click += new System.EventHandler(this.ElecSC_AM_Click);
            // 
            // ElecSC_List
            // 
            this.ElecSC_List.Name = "ElecSC_List";
            this.ElecSC_List.Size = new System.Drawing.Size(145, 22);
            this.ElecSC_List.Text = "Schedule List";
            this.ElecSC_List.Click += new System.EventHandler(this.ElecSC_List_Click);
            // 
            // brd
            // 
            this.brd.Image = ((System.Drawing.Image)(resources.GetObject("brd.Image")));
            this.brd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.brd.Name = "brd";
            this.brd.Size = new System.Drawing.Size(89, 54);
            this.brd.Text = "Boards batch   ";
            this.brd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.brd.Visible = false;
            this.brd.Click += new System.EventHandler(this.brd_Click);
            // 
            // _exit
            // 
            this._exit.Image = ((System.Drawing.Image)(resources.GetObject("_exit.Image")));
            this._exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(47, 54);
            this._exit.Text = "   Exit   ";
            this._exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._exit.ToolTipText = "Exit";
            this._exit.Click += new System.EventHandler(this._exit_Click);
            // 
            // PBWait
            // 
            this.PBWait.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PBWait.ForeColor = System.Drawing.Color.Red;
            this.PBWait.Name = "PBWait";
            this.PBWait.Size = new System.Drawing.Size(279, 54);
            this.PBWait.Text = "Search in Progress, please wait...";
            this.PBWait.Visible = false;
            this.PBWait.Click += new System.EventHandler(this.PBWait_Click);
            // 
            // TSpbar
            // 
            this.TSpbar.AutoSize = false;
            this.TSpbar.Name = "TSpbar";
            this.TSpbar.Size = new System.Drawing.Size(200, 20);
            this.TSpbar.Step = 5;
            this.TSpbar.Visible = false;
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.Image = ((System.Drawing.Image)(resources.GetObject("picExit.Image")));
            this.picExit.Location = new System.Drawing.Point(1051, 58);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(40, 40);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 200;
            this.picExit.TabStop = false;
            this.picExit.Visible = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // grpfind
            // 
            this.grpfind.Controls.Add(this.lprj);
            this.grpfind.Controls.Add(this.btnxl);
            this.grpfind.Controls.Add(this.grpcat);
            this.grpfind.Controls.Add(this.grpCharg);
            this.grpfind.Controls.Add(this.lcbRectifiers);
            this.grpfind.Controls.Add(this.button2);
            this.grpfind.Controls.Add(this.lwhr_prjStatus);
            this.grpfind.Controls.Add(this.lnb);
            this.grpfind.Controls.Add(this.groupBox2);
            this.grpfind.Controls.Add(this.comboBox1);
            this.grpfind.Controls.Add(this.btnUtst);
            this.grpfind.Controls.Add(this.chkdate);
            this.grpfind.Controls.Add(this.lblAff);
            this.grpfind.Controls.Add(this.label2);
            this.grpfind.Controls.Add(this.chk_ADV);
            this.grpfind.Controls.Add(this.button1);
            this.grpfind.Controls.Add(this.btn_dispCB);
            this.grpfind.Controls.Add(this.cbRectifiers);
            this.grpfind.Controls.Add(this.tKey);
            this.grpfind.Controls.Add(this.lmodel);
            this.grpfind.Controls.Add(this.label4);
            this.grpfind.Controls.Add(this.cbseekby);
            this.grpfind.Controls.Add(this.btnseek);
            this.grpfind.Controls.Add(this.txPrj);
            this.grpfind.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpfind.ForeColor = System.Drawing.Color.Blue;
            this.grpfind.Location = new System.Drawing.Point(0, 81);
            this.grpfind.Name = "grpfind";
            this.grpfind.Size = new System.Drawing.Size(1150, 134);
            this.grpfind.TabIndex = 205;
            this.grpfind.TabStop = false;
            this.grpfind.Visible = false;
            this.grpfind.Enter += new System.EventHandler(this.grpfind_Enter);
            // 
            // lprj
            // 
            this.lprj.BackColor = System.Drawing.Color.Transparent;
            this.lprj.ForeColor = System.Drawing.Color.Black;
            this.lprj.Location = new System.Drawing.Point(185, 64);
            this.lprj.Name = "lprj";
            this.lprj.Size = new System.Drawing.Size(85, 20);
            this.lprj.TabIndex = 231;
            this.lprj.Text = "Project Info.";
            this.lprj.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lprj.Visible = false;
            // 
            // btnxl
            // 
            this.btnxl.Enabled = false;
            this.btnxl.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnxl.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxl.Location = new System.Drawing.Point(440, 62);
            this.btnxl.Name = "btnxl";
            this.btnxl.Size = new System.Drawing.Size(145, 24);
            this.btnxl.TabIndex = 229;
            this.btnxl.Text = "XL FILE";
            this.btnxl.Visible = false;
            this.btnxl.Click += new System.EventHandler(this.btnxl_Click);
            // 
            // grpcat
            // 
            this.grpcat.Controls.Add(this.opInP);
            this.grpcat.Controls.Add(this.opAll);
            this.grpcat.Controls.Add(this.opSHP);
            this.grpcat.Controls.Add(this.opFapp);
            this.grpcat.Location = new System.Drawing.Point(770, 34);
            this.grpcat.Name = "grpcat";
            this.grpcat.Size = new System.Drawing.Size(374, 34);
            this.grpcat.TabIndex = 225;
            this.grpcat.TabStop = false;
            // 
            // opInP
            // 
            this.opInP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opInP.ForeColor = System.Drawing.Color.Blue;
            this.opInP.Location = new System.Drawing.Point(148, 8);
            this.opInP.Name = "opInP";
            this.opInP.Size = new System.Drawing.Size(148, 20);
            this.opInP.TabIndex = 174;
            this.opInP.Text = "In Process / Scheduled";
            this.opInP.CheckedChanged += new System.EventHandler(this.opInP_CheckedChanged);
            // 
            // opAll
            // 
            this.opAll.Checked = true;
            this.opAll.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opAll.Location = new System.Drawing.Point(6, 9);
            this.opAll.Name = "opAll";
            this.opAll.Size = new System.Drawing.Size(47, 19);
            this.opAll.TabIndex = 176;
            this.opAll.TabStop = true;
            this.opAll.Text = "ALL";
            this.opAll.CheckedChanged += new System.EventHandler(this.opAll_CheckedChanged);
            // 
            // opSHP
            // 
            this.opSHP.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opSHP.ForeColor = System.Drawing.Color.Black;
            this.opSHP.Location = new System.Drawing.Point(302, 8);
            this.opSHP.Name = "opSHP";
            this.opSHP.Size = new System.Drawing.Size(68, 20);
            this.opSHP.TabIndex = 175;
            this.opSHP.Text = "Shipped ";
            this.opSHP.Visible = false;
            this.opSHP.CheckedChanged += new System.EventHandler(this.opSHP_CheckedChanged);
            // 
            // opFapp
            // 
            this.opFapp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opFapp.ForeColor = System.Drawing.Color.Red;
            this.opFapp.Location = new System.Drawing.Point(53, 8);
            this.opFapp.Name = "opFapp";
            this.opFapp.Size = new System.Drawing.Size(96, 20);
            this.opFapp.TabIndex = 178;
            this.opFapp.Text = "For Approval";
            this.opFapp.CheckedChanged += new System.EventHandler(this.opFapp_CheckedChanged);
            // 
            // grpCharg
            // 
            this.grpCharg.Controls.Add(this.label1);
            this.grpCharg.Controls.Add(this.label5);
            this.grpCharg.Controls.Add(this.lFTTT);
            this.grpCharg.Controls.Add(this.lxxx);
            this.grpCharg.Controls.Add(this.cbXXX);
            this.grpCharg.Controls.Add(this.label6);
            this.grpCharg.Controls.Add(this.label3);
            this.grpCharg.Controls.Add(this.label7);
            this.grpCharg.Controls.Add(this.label8);
            this.grpCharg.Controls.Add(this.cbPhs);
            this.grpCharg.Controls.Add(this.label22);
            this.grpCharg.Controls.Add(this.cbPxx);
            this.grpCharg.Controls.Add(this.cbVdc);
            this.grpCharg.Controls.Add(this.cbIdctmp);
            this.grpCharg.Controls.Add(this.cbIdc);
            this.grpCharg.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCharg.Location = new System.Drawing.Point(440, 0);
            this.grpCharg.Name = "grpCharg";
            this.grpCharg.Size = new System.Drawing.Size(324, 63);
            this.grpCharg.TabIndex = 213;
            this.grpCharg.TabStop = false;
            this.grpCharg.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(102, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(16, 31);
            this.label1.TabIndex = 212;
            this.label1.Text = "-";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(168, 25);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(16, 31);
            this.label5.TabIndex = 211;
            this.label5.Text = "-";
            this.label5.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lFTTT
            // 
            this.lFTTT.BackColor = System.Drawing.Color.Lime;
            this.lFTTT.ForeColor = System.Drawing.Color.Black;
            this.lFTTT.Location = new System.Drawing.Point(46, 112);
            this.lFTTT.Name = "lFTTT";
            this.lFTTT.Size = new System.Drawing.Size(32, 16);
            this.lFTTT.TabIndex = 204;
            this.lFTTT.Visible = false;
            // 
            // lxxx
            // 
            this.lxxx.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lxxx.Location = new System.Drawing.Point(221, 85);
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
            this.cbXXX.Location = new System.Drawing.Point(221, 104);
            this.cbXXX.Name = "cbXXX";
            this.cbXXX.Size = new System.Drawing.Size(56, 24);
            this.cbXXX.TabIndex = 165;
            this.cbXXX.Visible = false;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(240, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(16, 31);
            this.label6.TabIndex = 164;
            this.label6.Text = "-";
            this.label6.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(256, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(41, 21);
            this.label3.TabIndex = 161;
            this.label3.Text = "IDC";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(186, 11);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 21);
            this.label7.TabIndex = 159;
            this.label7.Text = "VDC";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(124, 11);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 21);
            this.label8.TabIndex = 157;
            this.label8.Text = "PHS";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
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
            this.cbPhs.Location = new System.Drawing.Point(118, 32);
            this.cbPhs.Name = "cbPhs";
            this.cbPhs.Size = new System.Drawing.Size(50, 21);
            this.cbPhs.TabIndex = 156;
            this.cbPhs.SelectedIndexChanged += new System.EventHandler(this.cbPhs_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(17, 11);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 21);
            this.label22.TabIndex = 155;
            this.label22.Text = "PXXXX";
            this.label22.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cbPxx
            // 
            this.cbPxx.BackColor = System.Drawing.Color.Lavender;
            this.cbPxx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPxx.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPxx.ItemHeight = 13;
            this.cbPxx.Location = new System.Drawing.Point(6, 32);
            this.cbPxx.Name = "cbPxx";
            this.cbPxx.Size = new System.Drawing.Size(96, 21);
            this.cbPxx.TabIndex = 154;
            this.cbPxx.SelectedIndexChanged += new System.EventHandler(this.cbPxx_SelectedIndexChanged);
            // 
            // cbVdc
            // 
            this.cbVdc.BackColor = System.Drawing.Color.Lavender;
            this.cbVdc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVdc.ItemHeight = 13;
            this.cbVdc.Location = new System.Drawing.Point(184, 32);
            this.cbVdc.MaxDropDownItems = 20;
            this.cbVdc.Name = "cbVdc";
            this.cbVdc.Size = new System.Drawing.Size(56, 21);
            this.cbVdc.TabIndex = 158;
            this.cbVdc.SelectedIndexChanged += new System.EventHandler(this.cbVdc_SelectedIndexChanged);
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
            this.cbIdctmp.Location = new System.Drawing.Point(143, 77);
            this.cbIdctmp.Name = "cbIdctmp";
            this.cbIdctmp.Size = new System.Drawing.Size(56, 24);
            this.cbIdctmp.TabIndex = 210;
            this.cbIdctmp.Visible = false;
            // 
            // cbIdc
            // 
            this.cbIdc.BackColor = System.Drawing.Color.Lavender;
            this.cbIdc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIdc.ItemHeight = 13;
            this.cbIdc.Location = new System.Drawing.Point(256, 32);
            this.cbIdc.Name = "cbIdc";
            this.cbIdc.Size = new System.Drawing.Size(56, 21);
            this.cbIdc.TabIndex = 160;
            this.cbIdc.SelectedIndexChanged += new System.EventHandler(this.cbIdc_SelectedIndexChanged);
            // 
            // lcbRectifiers
            // 
            this.lcbRectifiers.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcbRectifiers.ForeColor = System.Drawing.Color.Blue;
            this.lcbRectifiers.Location = new System.Drawing.Point(500, 9);
            this.lcbRectifiers.Name = "lcbRectifiers";
            this.lcbRectifiers.Size = new System.Drawing.Size(153, 20);
            this.lcbRectifiers.TabIndex = 227;
            this.lcbRectifiers.Text = "Select Rectifier Model ";
            this.lcbRectifiers.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lcbRectifiers.Visible = false;
            // 
            // button2
            // 
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(1038, 9);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(106, 26);
            this.button2.TabIndex = 228;
            this.button2.Text = "Latest Projects";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // lwhr_prjStatus
            // 
            this.lwhr_prjStatus.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lwhr_prjStatus.Location = new System.Drawing.Point(36, 37);
            this.lwhr_prjStatus.Name = "lwhr_prjStatus";
            this.lwhr_prjStatus.Size = new System.Drawing.Size(25, 23);
            this.lwhr_prjStatus.TabIndex = 226;
            this.lwhr_prjStatus.Visible = false;
            // 
            // lnb
            // 
            this.lnb.BackColor = System.Drawing.Color.Red;
            this.lnb.ForeColor = System.Drawing.Color.White;
            this.lnb.Location = new System.Drawing.Point(107, 62);
            this.lnb.Name = "lnb";
            this.lnb.Size = new System.Drawing.Size(41, 24);
            this.lnb.TabIndex = 224;
            this.lnb.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lnb.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dpTo);
            this.groupBox2.Controls.Add(this.lfrom);
            this.groupBox2.Controls.Add(this.dpFrom);
            this.groupBox2.Controls.Add(this.lTo);
            this.groupBox2.Location = new System.Drawing.Point(463, 106);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(322, 32);
            this.groupBox2.TabIndex = 223;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // dpTo
            // 
            this.dpTo.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dpTo.CalendarTitleBackColor = System.Drawing.Color.Lavender;
            this.dpTo.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpTo.Location = new System.Drawing.Point(213, 9);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(104, 20);
            this.dpTo.TabIndex = 220;
            // 
            // lfrom
            // 
            this.lfrom.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lfrom.ForeColor = System.Drawing.Color.Red;
            this.lfrom.Location = new System.Drawing.Point(8, 9);
            this.lfrom.Name = "lfrom";
            this.lfrom.Size = new System.Drawing.Size(62, 20);
            this.lfrom.TabIndex = 217;
            this.lfrom.Text = "FROM:";
            this.lfrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dpFrom
            // 
            this.dpFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpFrom.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dpFrom.CalendarTitleBackColor = System.Drawing.Color.Lavender;
            this.dpFrom.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFrom.Location = new System.Drawing.Point(70, 9);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(104, 20);
            this.dpFrom.TabIndex = 218;
            // 
            // lTo
            // 
            this.lTo.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTo.ForeColor = System.Drawing.Color.Red;
            this.lTo.Location = new System.Drawing.Point(174, 9);
            this.lTo.Name = "lTo";
            this.lTo.Size = new System.Drawing.Size(39, 20);
            this.lTo.TabIndex = 219;
            this.lTo.Text = "TO:";
            this.lTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.Color.Lavender;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.comboBox1.Location = new System.Drawing.Point(240, 112);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(211, 21);
            this.comboBox1.TabIndex = 222;
            this.comboBox1.Visible = false;
            // 
            // chkdate
            // 
            this.chkdate.Location = new System.Drawing.Point(165, 114);
            this.chkdate.Name = "chkdate";
            this.chkdate.Size = new System.Drawing.Size(75, 17);
            this.chkdate.TabIndex = 221;
            this.chkdate.Text = "Use date:";
            this.chkdate.UseVisualStyleBackColor = true;
            this.chkdate.Visible = false;
            // 
            // chk_ADV
            // 
            this.chk_ADV.Location = new System.Drawing.Point(90, 43);
            this.chk_ADV.Name = "chk_ADV";
            this.chk_ADV.Size = new System.Drawing.Size(127, 17);
            this.chk_ADV.TabIndex = 216;
            this.chk_ADV.Text = "Advanced search by:";
            this.chk_ADV.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_ADV.UseVisualStyleBackColor = true;
            this.chk_ADV.CheckedChanged += new System.EventHandler(this.chk_ADV_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(99, 110);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(49, 23);
            this.button1.TabIndex = 210;
            this.button1.Text = " ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_dispCB
            // 
            this.btn_dispCB.Location = new System.Drawing.Point(323, 146);
            this.btn_dispCB.Name = "btn_dispCB";
            this.btn_dispCB.Size = new System.Drawing.Size(46, 22);
            this.btn_dispCB.TabIndex = 159;
            this.btn_dispCB.Text = "More...";
            this.btn_dispCB.UseVisualStyleBackColor = true;
            this.btn_dispCB.Visible = false;
            this.btn_dispCB.Click += new System.EventHandler(this.btn_dispCB_Click);
            // 
            // cbRectifiers
            // 
            this.cbRectifiers.BackColor = System.Drawing.Color.Lavender;
            this.cbRectifiers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbRectifiers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbRectifiers.Location = new System.Drawing.Point(446, 30);
            this.cbRectifiers.Name = "cbRectifiers";
            this.cbRectifiers.Size = new System.Drawing.Size(311, 21);
            this.cbRectifiers.TabIndex = 214;
            this.cbRectifiers.Visible = false;
            this.cbRectifiers.SelectedIndexChanged += new System.EventHandler(this.cbRectifiers_SelectedIndexChanged);
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.PeachPuff;
            this.tKey.Font = new System.Drawing.Font("Copperplate Gothic Bold", 11.25F);
            this.tKey.ForeColor = System.Drawing.Color.Black;
            this.tKey.Location = new System.Drawing.Point(106, 19);
            this.tKey.MaxLength = 60;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(322, 24);
            this.tKey.TabIndex = 156;
            this.tKey.TextChanged += new System.EventHandler(this.tKey_TextChanged);
            // 
            // lmodel
            // 
            this.lmodel.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmodel.ForeColor = System.Drawing.Color.Black;
            this.lmodel.Location = new System.Drawing.Point(251, 145);
            this.lmodel.Name = "lmodel";
            this.lmodel.Size = new System.Drawing.Size(80, 20);
            this.lmodel.TabIndex = 215;
            this.lmodel.Text = "Models:";
            this.lmodel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lmodel.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Copperplate Gothic Bold", 11.25F);
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(12, 20);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(94, 20);
            this.label4.TabIndex = 157;
            this.label4.Text = "Keyword:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbseekby
            // 
            this.cbseekby.BackColor = System.Drawing.Color.Lavender;
            this.cbseekby.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbseekby.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbseekby.Location = new System.Drawing.Point(217, 43);
            this.cbseekby.Name = "cbseekby";
            this.cbseekby.Size = new System.Drawing.Size(211, 21);
            this.cbseekby.TabIndex = 209;
            this.cbseekby.Visible = false;
            this.cbseekby.SelectedIndexChanged += new System.EventHandler(this.cbseekby_SelectedIndexChanged);
            // 
            // btnseek
            // 
            this.btnseek.Enabled = false;
            this.btnseek.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnseek.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnseek.Location = new System.Drawing.Point(770, 9);
            this.btnseek.Name = "btnseek";
            this.btnseek.Size = new System.Drawing.Size(262, 26);
            this.btnseek.TabIndex = 158;
            this.btnseek.Text = "Search by: Date";
            this.btnseek.Click += new System.EventHandler(this.btnseek_Click);
            // 
            // txPrj
            // 
            this.txPrj.BackColor = System.Drawing.Color.Beige;
            this.txPrj.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txPrj.ForeColor = System.Drawing.Color.Black;
            this.txPrj.Location = new System.Drawing.Point(270, 64);
            this.txPrj.MaxLength = 60;
            this.txPrj.Name = "txPrj";
            this.txPrj.ReadOnly = true;
            this.txPrj.Size = new System.Drawing.Size(158, 20);
            this.txPrj.TabIndex = 230;
            this.txPrj.Visible = false;
            // 
            // lvQuotes
            // 
            this.lvQuotes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvQuotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Qdate,
            this.Proj_ID,
            this.CPO,
            this.Cpny,
            this.Proj,
            this.iRid,
            this.ProjID,
            this.amt,
            this.SNlist,
            this.QID,
            this.Tests,
            this.dblAmnt});
            this.lvQuotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvQuotes.ForeColor = System.Drawing.Color.Blue;
            this.lvQuotes.FullRowSelect = true;
            this.lvQuotes.GridLines = true;
            this.lvQuotes.Location = new System.Drawing.Point(0, 215);
            this.lvQuotes.MultiSelect = false;
            this.lvQuotes.Name = "lvQuotes";
            this.lvQuotes.Size = new System.Drawing.Size(1150, 322);
            this.lvQuotes.TabIndex = 206;
            this.lvQuotes.UseCompatibleStateImageBehavior = false;
            this.lvQuotes.View = System.Windows.Forms.View.Details;
            this.lvQuotes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvQuotes_ColumnClick);
            this.lvQuotes.SelectedIndexChanged += new System.EventHandler(this.lvQuotes_SelectedIndexChanged);
            this.lvQuotes.DoubleClick += new System.EventHandler(this.lvQuotes_DoubleClick);
            // 
            // Qdate
            // 
            this.Qdate.Text = "Date(yy/mm/dd)";
            this.Qdate.Width = 96;
            // 
            // Proj_ID
            // 
            this.Proj_ID.Text = "Project #";
            this.Proj_ID.Width = 120;
            // 
            // CPO
            // 
            this.CPO.Text = "Customer PO#";
            this.CPO.Width = 118;
            // 
            // Cpny
            // 
            this.Cpny.Text = "Company Name";
            this.Cpny.Width = 185;
            // 
            // Proj
            // 
            this.Proj.Text = "Project Name";
            this.Proj.Width = 170;
            // 
            // iRid
            // 
            this.iRid.Text = "";
            this.iRid.Width = 0;
            // 
            // ProjID
            // 
            this.ProjID.Text = "";
            this.ProjID.Width = 0;
            // 
            // amt
            // 
            this.amt.Text = "Amount";
            this.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.amt.Width = 106;
            // 
            // SNlist
            // 
            this.SNlist.Text = "SN List";
            this.SNlist.Width = 109;
            // 
            // QID
            // 
            this.QID.Text = "Quote #";
            this.QID.Width = 76;
            // 
            // Tests
            // 
            this.Tests.Text = "Tests";
            this.Tests.Width = 0;
            // 
            // dblAmnt
            // 
            this.dblAmnt.Text = "";
            this.dblAmnt.Width = 0;
            // 
            // Orders_Look
            // 
            this.AcceptButton = this.btnseek;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1150, 537);
            this.Controls.Add(this.lvQuotes);
            this.Controls.Add(this.grpfind);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Orders_Look";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Orders List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Quotes_Look_Activated);
            this.Load += new System.EventHandler(this.LookQuotes_Load);
            this.Resize += new System.EventHandler(this.Orders_Look_Resize);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            this.grpfind.ResumeLayout(false);
            this.grpfind.PerformLayout();
            this.grpcat.ResumeLayout(false);
            this.grpCharg.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion


        private void visible_ede()
        {
            bool visa = (MainMDI.User.ToLower() == "ede");
       //     btnUtst.Visible = visa;
      //      lblAff.Visible = visa;
      //      label2.Visible = visa;
        }
        void fill_cbssekbye()
        {
            cbseekby.Items.Add("System Serial #");
            cbseekby.Items.Add("Charger Model ");
            cbseekby.Items.Add("Rectifier Model ");
            cbseekby.Items.Add("Syspro-Invoice # ");
            cbseekby.Items.Add("Board Serial #");
            cbseekby.Items.Add("Option Primax code ");
 //           cbseekby.Items.Add("Company Name");
 //           cbseekby.Items.Add("Project Name");
 //           cbseekby.Items.Add("Quote #");
 
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
               cbRectifiers.Items.Add (Oreadr[1].ToString());
        

            }

        }

        private void fill_All_cb(string s_cb)
        {
            cbPxx.Items.Clear();
            cbVdc.Items.Clear();
            cbIdc.Items.Clear();

            cbPxx.Items.Add("ALL P4500");
            cbPxx.Items.Add("ALL P4600");
            cbPxx.Items.Add("ALL P600");
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
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon );
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
		private void LookQuotes_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!"; 
			MainMDI.Write_Whodo_SSetup("Orders",'I');
            visible_ede();
            fill_cbssekbye();
            fill_lvP5500();
            fill_All_cb("cvi");
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
       //     SCH_Ordr.Visible = ((MainMDI.User.ToLower() == "nboudjellab" || MainMDI.User.ToLower() == "ede"));
        //    ListSCD.Visible=  SCH_Ordr.Visible;
           // tlsDDRep.Visible = MainMDI.User.ToLower() == "ede";

          //  if (MainMDI.User.ToLower() == "mbyad" || MainMDI.User.ToLower() == "mrouleau") tlsDDRep.Visible = false;
		}

		private void lvQuotes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ndxCLRD>-1) lvQuotes.Items[ndxCLRD].BackColor =Color.WhiteSmoke ; 
			
		}

		private void lvQuotes_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			 //MessageBox.Show (   e.Column.ToString()  );

 //           if (!cbseekby.Visible)
 //           {
                //btn_dispCB_Click(sender, e);
                btnseek.Text = "Search by:    " + lvQuotes.Columns[e.Column].Text;
                //	if (e.Column == 8 || e.Column == 8 || e.Column == 8) btnseek.Enabled =false; 

                if (ndxCLRD > -1)
                {
                    lvQuotes.Items[ndxCLRD].BackColor = Color.WhiteSmoke;
                    ndxCLRD = -1;
                }
                seelCol = e.Column;
                ColName(e.Column);
                disp_seek_KEY("TKEY");

                ListView myListView = (ListView)sender;

                // Determine if clicked column is already the column that is being sorted.
                if (e.Column == lvSorter.SortColumn)
                {
                    // Reverse the current sort direction for this column.
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
                    // Set the column number that is to be sorted; default to ascending.
                    //lvSorter.SortColumn = e.Column; old
                    //	lvSorter.Order = System.Windows.Forms.SortOrder.Ascending; old

                    lvSorter.Order = (srtType == 'A') ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
                    srtType = (srtType == 'A') ? 'D' : 'A';
                    lvSorter.SortColumn = e.Column;
                    lvSorter.SortColumn = (e.Column != 7) ? e.Column : 11;
                }

                // Perform the sort with these new sort options.
                myListView.Sort();
                oldSC = lvSorter.SortColumn;
                lvSorter.SortColumn = 0;


           // }
		}
		private bool Confirm(string msg)
		{
			DialogResult dr=MessageBox.Show(msg ,"Confirmation ",MessageBoxButtons.YesNo ,MessageBoxIcon.Question ); 
			return (dr == DialogResult.Yes  );
		}

		private void toolBar1_code(int _cod)
		{
			
			switch (_cod)    
			{

				case 0:  //seek Order
                    if (!grpfind.Visible) opAll.Checked = true;
                    grpfind.Visible =!grpfind.Visible ;
                    
                    if (grpfind.Visible)
                    {

                        tKey.Text = MainMDI.R_tkey;
                        btnseek.Enabled = true;
                        seelCol = 1;
                        ReSORT_lvQuotes(1);


                    }
                    else
                    {
                        cbseekby.Visible = false;
                        
                    }
                   chk_ADV.Visible =  (in_typeO == 'L');
                    tKey.Focus();

 
			        break;
				case 1:  //edit Order
                    //  lvQuotes_DoubleClick(sender ,e);
					break;

				case 2:
					this.Hide();
					break;

                case 3:
                   
                    if (lvQuotes.SelectedItems.Count ==1 && MainMDI.ALWD_USR("OR_SCD", true) )
                    {
                        int ndx = lvQuotes.SelectedItems[0].Index;
                        this.Cursor = Cursors.WaitCursor;
                        if (lvQuotes.SelectedItems.Count == 1 )
                        {
                            if (lvQuotes.SelectedItems[0].ForeColor == Color.Blue || lvQuotes.SelectedItems[0].ForeColor == Color.Salmon || lvQuotes.SelectedItems[0].ForeColor == MainMDI.clr_R_Scheduled  )
                            {
                                OR_ToSched ts = new OR_ToSched(lvQuotes.SelectedItems[0].SubItems[1].Text, lvQuotes.SelectedItems[0].SubItems[5].Text, lvQuotes.SelectedItems[0].SubItems[3].Text,EM);
                                ts.ShowDialog();
                            }
                        }
                        if (lvQuotes.Items[ndx].ForeColor == Color.Blue)
                        {
                            if (MainMDI.Find_One_Field("SELECT sc_LID FROM PSM_R_SCD_INFO WHERE sc_status = 1 AND sc_IREVID =" + lvQuotes.Items[ndx].SubItems[5].Text) != MainMDI.VIDE)
                                lvQuotes.Items[ndx].ForeColor = MainMDI.clr_R_Scheduled;
                        }
                        this.Cursor = Cursors.Default;
                    }
                    break;
                case 4:
                    if (MainMDI.ALWD_USR("OR_SCD", true))
                    {
                        this.Cursor = Cursors.WaitCursor;
                     //       OR_Sched_projects ALLP = new OR_Sched_projects(1);
                        OR_Sched_projects_NEW  ALLP = new OR_Sched_projects_NEW (1,EM );
                            this.Hide();
                            ALLP.ShowDialog();
                            this.Visible = true;
                          this.Cursor = Cursors.Default;
                          ALLP.Dispose();
                     }
                    break;
                case 5:
                    if (MainMDI.ALWD_USR("OR_SCD", true))
                    {
                        this.Cursor = Cursors.WaitCursor;
                       
               //         OR_Sched_projects ALLP = new OR_Sched_projects(0);
                        OR_Sched_projects_NEW  ALLP = new OR_Sched_projects_NEW (0,EM);
                        this.Hide();
                        ALLP.ShowDialog();
                        this.Visible = true;
                        ALLP.Close();
                        this.Cursor = Cursors.Default;
                    }
                    break;


                case 6:
                    if (lvQuotes.SelectedItems.Count == 1)
                    {

                        if (MainMDI.ALWD_USR("OR_SCD", true))
                        {


                     //       string res = MainMDI.Find_One_Field("select  AGency from PSM_R_Rev where IRRevID=" + lvQuotes.SelectedItems[0].SubItems[5].Text);
                    //       if (res != "2")
                    //        {
                    //          string  res2 = MainMDI.Find_One_Field("SELECT [A_CMSLID]  ,[AG_Dest]  ,[AG_Infl]   ,[AG_Eng]   ,[AG_PO] FROM [Orig_PSM_FDB].[dbo].[PSM_R_REV_agCMS] where A_CMS_REVID=" + lvQuotes.SelectedItems[0].SubItems[5].Text);
                   //             if ( res=="0" || res2 != MainMDI.VIDE  )
                    //            {
                                    this.Cursor = Cursors.WaitCursor;
                                    //         OR_Sched_projects ALLP = new OR_Sched_projects(0);
                                    Order_SysPro_XML xml_Frm = new Order_SysPro_XML(lvQuotes.SelectedItems[0].SubItems[5].Text, lvQuotes.SelectedItems[0].SubItems[1].Text);
                                    this.Hide();
                                    xml_Frm.ShowDialog();
                                    this.Visible = true;
                                    xml_Frm.Close();
                                    this.Cursor = Cursors.Default;
                      //          }
                     //           else MessageBox.Show("Can not Send ORDER to SYSPRO since AGENTS are not defined.....\n Pls. open this order and fill [Agent / CMS] TAB )");



                      //      }
                      //      else MessageBox.Show("Can not Send ORDER to SYSPRO since AGENT status is Unknown ....\n   Pls. open this order and check AGENT status...... [Agent / CMS] TAB )");


                        }
                    }
                    break;
			}
		}

		public void fill_lv_PX_ORDERs()
		{ 

	
			//lvQuotes.Items.Clear(); 
			
			string stSql = "SELECT PSM_PXOrders.[OrderDate], PSM_PXOrders.[OrderNumber], PSM_PXOrders.CustomerPO, PSM_PXOrders.[CompanyName], PSM_PXOrders.[ProjectName], PSM_PXOrders.OldRlid ,TotalOrderPrice" +
                           " FROM PSM_PXOrders ORDER BY PSM_PXOrders.[OrderDate] DESC, PSM_PXOrders.[OrderNumber] DESC " ;
//             string stSql = "SELECT PSM_PXOrders.OrderDate, PSM_PXOrders.OrdeNumber, PSM_PXOrders.CustomerPO, PSM_PXOrders.Company_Name, PSM_PXOrders.ProjectName, PSM_PXOrders.OldRlid " +
  //                           " FROM PSM_PXOrders ORDER BY PSM_PXOrders.OrderDate, PSM_PXOrders.OrdeNumber";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
			while (Oreadr.Read ())
			{
				lvO_ORDER(Oreadr["OrderDate"].ToString ().Substring(0,10) ,Oreadr["OrderNumber"].ToString (),Oreadr["CustomerPO"].ToString (),Oreadr["CompanyName"].ToString (),Oreadr["ProjectName"].ToString (),Oreadr["OldRlid"].ToString (),oldOrdersCLR     ," ",Oreadr["TotalOrderPrice"].ToString()," "," ","X");
				
			}
			OConn.Close();

		}



		private string RRev_SNList(string r_IRRevID)
		{
			string stSql="SELECT PSM_R_Detail.PrimaxSN FROM PSM_R_Detail " + 
				         " WHERE PSM_R_Detail.IRRev_LID=" + r_IRRevID +  " AND PSM_R_Detail.PrimaxSN<>'' ORDER BY PSM_R_Detail.PrimaxSN";
		
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
            stSql="[";
			while (Oreadr.Read ())	stSql += Oreadr[0].ToString () + "-";
			OConn.Close();
		
			if (stSql.Length <2) stSql+="]";
			else stSql=stSql.Substring(0,stSql.Length -1) + "]";
			return stSql ;	
			
		
		
		}
		private string BoardIn_SNList(string r_IRRevID,char typ)
		{
		//	string stSql="SELECT brd_SN FROM PSM_Boards " + 
		//		" WHERE b_RRevDetLID=" + r_IRRevID +  " AND brd_SN<>'' ORDER BY brd_Desc";
			string stSql="";
			//I=item  B=Board
			if (typ=='I') stSql="SELECT     dbo.PSM_Boards.brd_SN AS BSN " +
                          " FROM         dbo.PSM_R_Detail INNER JOIN dbo.PSM_R_Rev ON dbo.PSM_R_Detail.IRRev_LID = dbo.PSM_R_Rev.IRRevID INNER JOIN " +
                          " dbo.PSM_Boards ON dbo.PSM_R_Detail.Rdetail_LID = dbo.PSM_Boards.b_RRevDetLID " +
                          " WHERE     (dbo.PSM_Boards.brd_SN <> '') AND (dbo.PSM_R_Rev.IRRevID = " + r_IRRevID + ") ";
		    else        stSql="	SELECT     dbo.PSM_Boards.*, dbo.PSM_Boards.brd_SN AS BSN " +
                              " FROM         dbo.PSM_R_Detail INNER JOIN dbo.PSM_Boards ON dbo.PSM_R_Detail.Rdetail_LID = dbo.PSM_Boards.b_RRevDetLID " +
                              " WHERE     (dbo.PSM_Boards.brd_SN <> '') AND (dbo.PSM_R_Detail.Rdetail_LID =" + r_IRRevID + ") ";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			stSql="[";
			while (Oreadr.Read ())	stSql += Oreadr["BSN"].ToString () + "-";
			OConn.Close();
		
			if (stSql.Length <2) stSql+="]";
			else stSql=stSql.Substring(0,stSql.Length -1) + "]";
			return stSql ;	
			
		
		
		}

	

		private Color RRev_Colr(char c,string dat_rev)
		{
			string dcmp=(MainMDI.C_Style=="103") ? "03/04/2007" : "04/03/2007";
		//	DateTime ndd=DateTime.Parse(dcmp,Thread.CurrentThread.CurrentCulture,(datet MainMDI.C_Style );
			DateTime dd= DateTime.Parse(dat_rev);
			TimeSpan  ds=DateTime.Parse(dat_rev).Subtract(DateTime.Parse(dcmp));
			int Tdays=(int) ds.TotalDays;
			Color clr=Color.Chocolate ;
			
			switch (c)
			{
				case '*':
				case ' ':
                case 'P':
					clr=(Tdays<0 ) ?  Color.RoyalBlue :  Color.Blue   ;
					break;
				case 'S':
				//	clr=Color.Black ;
                    clr = MainMDI.Clr_s_Shipped; 
					break;
				case 'T':
					clr=MainMDI.Clr_s_Stock   ;
					break;
				case 'F':
					clr=Color.Salmon ;
					break;
				case 'D':
					clr=Color.Green  ;
					break;
				case 'C':
					clr=Color.LightSkyBlue ;// .LightBlue   ;
					break;
					
			}
			return clr;
		}

        /*
		public void fill_lv_ORDERs(bool BigL)
		{ 
			string stTim="fill_lv_ORDERs===>" +DateTime.Now.ToLongTimeString ();  
		
            int r_NBOrdr=MainMDI.NBOrdr ;
                //		string stSql = "SELECT PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_R_Rev.dateRRev, PSM_R_Rev.Custm_PO, PSM_COMPANY.Cpny_Name1, PSM_R_prj.PrjName, PSM_R_Rev.RRev_Name, PSM_R_Rev.RRev_Tot, PSM_Q_IGen.Quote_ID, PSM_R_Rev.shiped " +
//				"    FROM PSM_Q_IGen INNER JOIN (PSM_R_prj INNER JOIN (PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID) ON PSM_R_prj.PROJID = PSM_R_Rev.RID) ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID " +
//				"    where PSM_R_Rev.shiped <>'D' ORDER BY PSM_R_Rev.dateRRev DESC, PSM_R_Rev.IRRevID DESC";
            string stSql = "SELECT PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_R_Rev.opendate as dateRRev, PSM_R_Rev.Custm_PO, PSM_COMPANY.Cpny_Name1, PSM_R_prj.PrjName, PSM_R_Rev.RRev_Name, PSM_R_Rev.RRev_Tot, PSM_Q_IGen.Quote_ID, PSM_R_Rev.shiped,  PSM_R_Rev.Tests " +
							"    FROM PSM_Q_IGen INNER JOIN (PSM_R_prj INNER JOIN (PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID) ON PSM_R_prj.PROJID = PSM_R_Rev.RID) ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID " +
							"    where PSM_R_Rev.shiped <>'D' ORDER BY PSM_R_Rev.opendate DESC, PSM_R_Rev.IRRevID DESC";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
           	 stTim +="\n exec= "+DateTime.Now.ToLongTimeString ();  
			int nb=0;
			while (Oreadr.Read ())
			{
				//if (Oreadr["RID"].ToString() =="2354") MessageBox.Show("ici"); 
			//	if (Oreadr["Custm_PO"].ToString ()=="2880") MessageBox.Show("Go"); 
               // string tot=(Oreadr["shiped"].ToString()[0]=='D') ? "0" :Oreadr["RRev_Tot"].ToString ();
				string tot=Oreadr["RRev_Tot"].ToString ();
				Color  clr= RRev_Colr(Oreadr["shiped"].ToString()[0],Oreadr["dateRRev"].ToString ());
				if (Oreadr["shiped"].ToString()[0]!='D' )
				{

					//MessageBox.Show ("date=" + DateTime.Parse(Oreadr["dateRRev"].ToString ())); 
					//DateTime dd = DateTime.Parse(Oreadr["dateRRev"].ToString ());
				//	MessageBox.Show ("date=" + dd. .ToShortDateString() );
                    lvO_ORDER(Oreadr["dateRRev"].ToString().Substring(0, 10), MainMDI.A00(Convert.ToInt32(Oreadr["RID"].ToString()), MainMDI.NB_LookOrders_A00) + " " + Oreadr["RRev_Name"].ToString(), Oreadr["Custm_PO"].ToString(), Oreadr["Cpny_Name1"].ToString(), Oreadr["PrjName"].ToString(), Oreadr["IRRevID"].ToString(), clr, Oreadr["RID"].ToString(), tot, RRev_SNList(Oreadr["IRRevID"].ToString()) + " " + BoardIn_SNList(Oreadr["IRRevID"].ToString(), 'I'), "Q" + Oreadr["Quote_ID"].ToString(), Oreadr["Tests"].ToString());
				        if (!BigL && (r_NBOrdr--) ==0) break;
				}
			 	nb++;
			}
			//toolBar1.Buttons[0].Enabled = BigL ;
		//	grpfind.Visible = BigL ;
			OConn.Close();
		stTim +="\n Fill= "+DateTime.Now.ToLongTimeString ();  
			if (!BigL) lvQuotes.Columns[8].Width =0;  
			fill_Test_Stat();
		stTim +="\n Stat= "+DateTime.Now.ToLongTimeString ();  

	 MessageBox.Show(stTim);  

			//MessageBox.Show ("NB= " + nb ); 
         
		}
         * 
         * */
		
		public void fill_lv_ORDERs_fast(bool BigL)
		{ 
	
			string stdeb=DateTime.Now.ToLongTimeString ();

            if (lwhr_prjStatus.Text == "") opInP.Checked = true;// lwhr_prjStatus.Text = " PSM_R_Rev.shiped <> 'D' AND PSM_R_Rev.shiped <> 'W'";
            string NBLines = (BigL || opInP.Checked ) ? "" : " TOP " + MainMDI.NBOrdr;
	    //	string stSql = "SELECT " + NBLines + " PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_R_Rev.opendate as dateRRev, PSM_R_Rev.Custm_PO, PSM_COMPANY.Cpny_Name1, PSM_R_prj.PrjName, PSM_R_Rev.RRev_Name, PSM_R_Rev.RRev_Tot, PSM_Q_IGen.Quote_ID, PSM_R_Rev.shiped, PSM_R_Rev.Tests " +
		//		"    FROM PSM_Q_IGen INNER JOIN (PSM_R_prj INNER JOIN (PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID) ON PSM_R_prj.PROJID = PSM_R_Rev.RID) ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID " +
		//		"    where PSM_R_Rev.shiped <>'D' ORDER BY PSM_R_Rev.opendate DESC, PSM_R_Rev.IRRevID DESC";



            NBLines = "TOP 50";   //added 23-01-2013

            string stSql = "SELECT " + NBLines + " PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_R_Rev.opendate as dateRRev, PSM_R_Rev.Custm_PO, PSM_COMPANY.Cpny_Name1, PSM_R_prj.PrjName, PSM_R_Rev.RRev_Name, PSM_R_Rev.RRev_Tot, PSM_Q_IGen.Quote_ID, PSM_R_Rev.shiped, PSM_R_Rev.Tests " +
    "    FROM PSM_Q_IGen INNER JOIN (PSM_R_prj INNER JOIN (PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID) ON PSM_R_prj.PROJID = PSM_R_Rev.RID) ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID " +
    "    where " + lwhr_prjStatus.Text + " ORDER BY PSM_R_Rev.opendate desc , PSM_R_Rev.IRRevID desc ";

			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
           
			
			while (Oreadr.Read ())
			{
			
				//	if (Oreadr["Custm_PO"].ToString ()=="2880") MessageBox.Show("Go"); 
				// string tot=(Oreadr["shiped"].ToString()[0]=='D') ? "0" :Oreadr["RRev_Tot"].ToString ();
				string tot=Oreadr["RRev_Tot"].ToString ();
				Color  clr= RRev_Colr(Oreadr["shiped"].ToString()[0],Oreadr["dateRRev"].ToString ());
				if (Oreadr["shiped"].ToString()[0]!='D' )
				{
                    //RRev_SNList(Oreadr["IRRevID"].ToString ())+" " + BoardIn_SNList(Oreadr["IRRevID"].ToString (),'I')....look for SN was in LVO_order
					lvO_ORDER(Oreadr["dateRRev"].ToString ().Substring(0,10) ,MainMDI.A00(Convert.ToInt32(Oreadr["RID"].ToString ()),MainMDI.NB_LookOrders_A00 )+" "+Oreadr["RRev_Name"].ToString (),Oreadr["Custm_PO"].ToString (),Oreadr["Cpny_Name1"].ToString (),Oreadr["PrjName"].ToString (),Oreadr["IRRevID"].ToString (),clr,Oreadr["RID"].ToString (),tot,"SN","Q"+Oreadr["Quote_ID"].ToString (), Oreadr["Tests"].ToString());
					
				}
				
			}
			//toolBar1.Buttons[0].Enabled = BigL ;
			//	grpfind.Visible = BigL ;
			OConn.Close();
			if (!BigL) lvQuotes.Columns[8].Width =0;  
	//		fill_Test_Stat();  removed since [Tests] in psm_R_rrev is tests status (modified every tests save)

	

		}

/*
		public void fill_lv_ORDERs_SP(bool BigL)   // use Stored Procedure
		{ 
	
			string stTim="STORED===>" +DateTime.Now.ToLongTimeString ();  
   
        
		//	string NBLines=(BigL) ? "" : " TOP " + MainMDI.NBOrdr;
			string stSql = "SELECT PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_R_Rev.opendate as dateRRev, PSM_R_Rev.Custm_PO, PSM_COMPANY.Cpny_Name1, PSM_R_prj.PrjName, PSM_R_Rev.RRev_Name, PSM_R_Rev.RRev_Tot, PSM_Q_IGen.Quote_ID, PSM_R_Rev.shiped " +
				"    FROM PSM_Q_IGen INNER JOIN (PSM_R_prj INNER JOIN (PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID) ON PSM_R_prj.PROJID = PSM_R_Rev.RID) ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID " +
				"    where PSM_R_Rev.shiped <>'D' ORDER BY PSM_R_Rev.opendate DESC, PSM_R_Rev.IRRevID DESC";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
			OConn.Open ();
			SqlCommand Ocmd = new SqlCommand("look_Orders4",OConn);  //OConn.CreateCommand();
			Ocmd.CommandType = CommandType.StoredProcedure; //("look_Orders"
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
stTim +="\n exec= "+DateTime.Now.ToLongTimeString ();  
			while (Oreadr.Read ())
			{
				string tot=Oreadr["RRev_Tot"].ToString ();
				Color  clr= RRev_Colr(Oreadr["shiped"].ToString()[0]);
				lvO_ORDER(f ,f,MainMDI.NB_LookOrders_A00 )+" "+Oreadr["RRev_Name"].ToString (),Oreadr["Custm_PO"].ToString (),Oreadr["Cpny_Name1"].ToString (),Oreadr["PrjName"].ToString (),Oreadr["IRRevID"].ToString (),clr,Oreadr["RID"].ToString (),tot,RRev_SNList(Oreadr["IRRevID"].ToString ())+" " + BoardIn_SNList(Oreadr["IRRevID"].ToString (),'I'),"Q"+Oreadr["Quote_ID"].ToString ());
		
				ListViewItem lvI= lvQuotes.Items.Add(MainMDI.frmt_date(Oreadr["dateRRev"].ToString ().Substring(0,10)));
				lvI.SubItems.Add( MainMDI.A00(Convert.ToInt32(Oreadr["RID"].ToString () ); 
				if (CPO=="") lvI.SubItems.Add(" "); else  lvI.SubItems.Add(CPO );
				if (cpnyName =="") lvI.SubItems.Add(" "); else  lvI.SubItems.Add(cpnyName  );
				if (PName=="") lvI.SubItems.Add(" "); else  lvI.SubItems.Add(PName );
				lvI.SubItems.Add(rlid ); 
				lvI.ForeColor = clr ;
				lvI.SubItems.Add(ProjID ); 
				lvI.SubItems.Add("$ " + MainMDI.Curr_FRMT( Tot )); 
				lvI.SubItems.Add(SNL ); 
				lvI.SubItems.Add(Qid  ); 
				lvI.SubItems.Add(""); 
				//		if (S[0]=='C' ) lvI.SubItems.Add("Completed" ); 
				//		if (S[0]=='S' ) lvI.SubItems.Add("StandBy" ); 
				// 			if (S[0]=='I' ) lvI.SubItems.Add("In Process" ); 

				if (lvI.ForeColor != Color.Gray ) if (MainMDI.Find_One_Field(" SELECT Aprvd FROM  PSM_R_Detail WHERE  Aprvd = 0 AND IRRev_LID =" + rlid)!=MainMDI.VIDE )  lvI.ForeColor= Color.Salmon   ; 
				
			}

			OConn.Close();
		stTim +="\n Fill= "+DateTime.Now.ToLongTimeString ();  
			if (!BigL) lvQuotes.Columns[8].Width =0;  
			fill_Test_Stat();

		stTim +="\n Stat= "+DateTime.Now.ToLongTimeString ();  
			 MessageBox.Show(stTim);  

		}


*/
        private void fill_Colr_Revs()
        {
            for (int i = 0; i < lvQuotes.Items.Count; i++)
            {
                if (lvQuotes.Items[i].ForeColor == Color.Blue)
                {
                    if (MainMDI.Find_One_Field("SELECT sc_LID FROM PSM_R_SCD_INFO WHERE sc_status = 1 AND sc_IREVID =" + lvQuotes.Items[i].SubItems[5].Text) != MainMDI.VIDE)
                        lvQuotes.Items[i].ForeColor = MainMDI.clr_R_Scheduled;
                }

            }

        }
		
		private void fill_Test_Stat()
		{
            for (int i = 0; i < lvQuotes.Items.Count; i++)
            {
                lvQuotes.Items[i].SubItems[10].Text = MainMDI.Test_Stat(lvQuotes.Items[i].SubItems[5].Text);
                if (lvQuotes.Items[i].ForeColor == Color.Blue)
                {
                    if (MainMDI.Find_One_Field("SELECT sc_LID FROM PSM_R_SCD_INFO WHERE sc_status = 1 AND sc_IREVID =" + lvQuotes.Items[i].SubItems[5].Text) != MainMDI.VIDE)
                        lvQuotes.Items[i].ForeColor = MainMDI.clr_R_Scheduled;
                }

            }
			
		}

        /*
		private string Test_Stat(string IRREVID)
		{		
		//	int y= lvQuotes.Items[i].SubItems[1].Text.IndexOf("2516");
     
         //    if (lvQuotes.Items[i].SubItems[1].Text.IndexOf("2538") > -1 ) MessageBox.Show("Hiiiiiiiiiiiiiiiiiiii"); 

				string stSql=" SELECT PSM_R_TRInfo.tr_stat AS stat, PSM_R_TRInfo.tr_TRName as TRNm" +
					" FROM         PSM_R_TRInfo INNER JOIN  PSM_R_Rev ON PSM_R_TRInfo.tr_iRRevID = PSM_R_Rev.IRRevID " +
					" WHERE     (PSM_R_Rev.IRRevID =" + IRREVID  + ")";
				SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
				OConn.Open ();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql ;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();
				int C=0,I=0,S=0;
				string st="N/C";
				while (Oreadr.Read ())
				{
					if (Oreadr["stat"].ToString () =="I") I++;
					if (Oreadr["stat"].ToString () =="S") S++;
					if (Oreadr["stat"].ToString () =="C") C++;
					st="";
				}
			OConn.Close();
            if (st!="N/C") 
				{
					if (I!=0 || C!=0 || S!=0) st="In Process";
					if (I==0 && C==0) st="StandBy";
					if (I==0 && S==0) st="Completed";
				}
			return st;
		
					
		}
         * */
	  

		public void ref_ORDERlist(string r_iRid,int ndx)
		{ 
			
		
			//	string stSql = "SELECT PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_R_Rev.dateRRev, PSM_R_Rev.Custm_PO, PSM_COMPANY.Cpny_Name1, PSM_R_prj.PrjName, PSM_R_Rev.RRev_Name,PSM_R_Rev.RRev_Tot , PSM_Q_IGen.Quote_ID" +
			//                    " FROM PSM_Q_IGen INNER JOIN PSM_R_prj INNER JOIN PSM_R_Rev ON PSM_R_prj.PROJID = PSM_R_Rev.RID INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID order by dateRRev DESC";

			string stSql = "SELECT PSM_R_Rev.IRRevID, PSM_R_Rev.RID,PSM_R_Rev.shiped, PSM_R_Rev.dateRRev, PSM_R_Rev.Custm_PO, PSM_COMPANY.Cpny_Name1, PSM_R_prj.PrjName, PSM_R_Rev.RRev_Name, PSM_R_Rev.RRev_Tot, PSM_Q_IGen.Quote_ID, PSM_R_Rev.Tests " +
				"    FROM PSM_Q_IGen INNER JOIN (PSM_R_prj INNER JOIN (PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID) ON PSM_R_prj.PROJID = PSM_R_Rev.RID) ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID " +
				" where PSM_R_Rev.IRRevID=" + r_iRid;

			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
			while (Oreadr.Read ())
			{
				Color clr=RRev_Colr(Oreadr["shiped"].ToString()[0],Oreadr["dateRRev"].ToString ());
				if (ndx >-1)
				{
				//	MessageBox.Show ("date=" + DateTime.Parse(Oreadr["dateRRev"].ToString ())); 
					//MessageBox.Show ("date=" + DateTime.Parse(Oreadr["dateRRev"].ToString ())); 
					//	DateTime dd = DateTime.Parse(Oreadr["dateRRev"].ToString ());
					//	MessageBox.Show ("date=" + dd.ToShortDateString() );
					string dat=Oreadr["dateRRev"].ToString ().Substring(0,10) ;
					lvQuotes.Items[ndx].SubItems[0].Text = MainMDI.frmt_date(dat) ;//  dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2) ;
					lvQuotes.Items[ndx].SubItems[1].Text=MainMDI.A00(Convert.ToInt32(Oreadr["RID"].ToString ()),MainMDI.NB_LookOrders_A00)+" "+Oreadr["RRev_Name"].ToString ();  //MainMDI.A00(Convert.ToInt32(Oreadr["RID"].ToString ()),6)
					lvQuotes.Items[ndx].SubItems[2].Text=Oreadr["Custm_PO"].ToString ();
					lvQuotes.Items[ndx].SubItems[3].Text=Oreadr["Cpny_Name1"].ToString ();
					lvQuotes.Items[ndx].SubItems[4].Text=Oreadr["PrjName"].ToString ();
					lvQuotes.Items[ndx].SubItems[5].Text=Oreadr["IRRevID"].ToString ();
					lvQuotes.Items[ndx].SubItems[6].Text=Oreadr["RID"].ToString ();
					lvQuotes.Items[ndx].SubItems[7].Text="$ " + MainMDI.Curr_FRMT(Oreadr["RRev_Tot"].ToString ());
                    lvQuotes.Items[ndx].SubItems[8].Text = "SN";// RRev_SNList(Oreadr["IRRevID"].ToString()) + " " + BoardIn_SNList(Oreadr["IRRevID"].ToString(), 'I');
					lvQuotes.Items[ndx].SubItems[9].Text="Q"+Oreadr["Quote_ID"].ToString ();
				    lvQuotes.Items[ndx].ForeColor  = clr  ; 
				}
                else lvO_ORDER(Oreadr["dateRRev"].ToString().Substring(0, 10), Oreadr["RID"].ToString() + " " + Oreadr["RRev_Name"].ToString(), Oreadr["Custm_PO"].ToString(), Oreadr["Cpny_Name1"].ToString(), Oreadr["PrjName"].ToString(), Oreadr["IRRevID"].ToString(), clr, Oreadr["RID"].ToString(), Oreadr["RRev_Tot"].ToString(), "SN", "Q" + Oreadr["Quote_ID"].ToString(), Oreadr["Tests"].ToString()); //RRev_SNList(Oreadr["IRRevID"].ToString()) + " " + BoardIn_SNList(Oreadr["IRRevID"].ToString(), 'I') sn..lookup
				  
			}
			OConn.Close();


		}

        private void lvO_ORDER(string dat, string RID, string CPO, string cpnyName, string PName, string rlid, Color clr, string ProjID, string Tot, string SNL, string Qid, string S)
        {

            //	string da=dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2);
            string da = MainMDI.frmt_date(dat);

            ListViewItem lvI = lvQuotes.Items.Add(da);
            lvI.SubItems.Add(RID);
            if (CPO == "") lvI.SubItems.Add(" "); else lvI.SubItems.Add(CPO);
            if (cpnyName == "") lvI.SubItems.Add(" "); else lvI.SubItems.Add(cpnyName);
            if (PName == "") lvI.SubItems.Add(" "); else lvI.SubItems.Add(PName);
            lvI.SubItems.Add(rlid);
            lvI.ForeColor = clr;
            lvI.SubItems.Add(ProjID);
            lvI.SubItems.Add("$ " + MainMDI.Curr_FRMT(Tot));
            lvI.SubItems.Add(SNL);
            lvI.SubItems.Add(Qid);
            lvI.SubItems.Add(msg_Tests_Stat(S));
            if (clr != Color.DarkBlue) // .DarkOrange) 
            {
                if (MainMDI.Find_One_Field("SELECT sc_LID FROM  PSM_R_SCD_INFO INNER JOIN PSM_R_Rev ON PSM_R_SCD_INFO.sc_IREVID = PSM_R_Rev.IRRevID WHERE PSM_R_Rev.shiped <> 'S' and sc_status = 1 AND sc_IREVID =" + lvI.SubItems[5].Text) != MainMDI.VIDE)
                    lvI.ForeColor = MainMDI.clr_R_Scheduled;
            }
            lvI.SubItems.Add(Tot);
            if (lvI.ForeColor != oldOrdersCLR )
            {
              //  if (MainMDI.Find_One_Field(" SELECT Aprvd FROM  PSM_R_Detail WHERE  Aprvd = 0 AND IRRev_LID =" + rlid) != MainMDI.VIDE)
              //      lvI.ForeColor = Color.Salmon;

            }

            //   if (lvI.SubItems[1].Text.IndexOf("9910") > -1 || lvI.SubItems[1].Text.IndexOf("9911") > -1)
            if (IsTestingPrj(lvI.SubItems[1].Text))
            {
               // lvI.ForeColor = Color.DarkMagenta;
            }

            //	lvI.SubItems.Add(MainMDI.Curr_FRMT( Tot )); 

        }




		private void lvO_ORDER_OLD_soSLOW(string dat,string RID,string CPO, string cpnyName,string PName,string rlid,Color  clr,string ProjID,string Tot,string SNL,string Qid,string S )
		{
			
		//	string da=dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2);
			string da=MainMDI.frmt_date(dat);
		
			ListViewItem lvI= lvQuotes.Items.Add(da );
			lvI.SubItems.Add( RID ); 
			if (CPO=="") lvI.SubItems.Add(" "); else  lvI.SubItems.Add(CPO );
			if (cpnyName =="") lvI.SubItems.Add(" "); else  lvI.SubItems.Add(cpnyName  );
			if (PName=="") lvI.SubItems.Add(" "); else  lvI.SubItems.Add(PName );
			lvI.SubItems.Add(rlid ); 
			lvI.ForeColor = clr ;
			lvI.SubItems.Add(ProjID ); 
			lvI.SubItems.Add("$ " + MainMDI.Curr_FRMT( Tot )); 
			lvI.SubItems.Add(SNL ); 
			lvI.SubItems.Add(Qid  ); 
            lvI.SubItems.Add(msg_Tests_Stat(S ));
            if (clr != Color.DarkBlue) // .DarkOrange) 
            {
                if (MainMDI.Find_One_Field("SELECT sc_LID FROM  PSM_R_SCD_INFO INNER JOIN PSM_R_Rev ON PSM_R_SCD_INFO.sc_IREVID = PSM_R_Rev.IRRevID WHERE PSM_R_Rev.shiped <> 'S' and sc_status = 1 AND sc_IREVID =" + lvI.SubItems[5].Text) != MainMDI.VIDE) 
                    lvI.ForeColor = MainMDI.clr_R_Scheduled;
            }
            lvI.SubItems.Add(Tot);
			if (lvI.ForeColor !=oldOrdersCLR )
			{
				if (MainMDI.Find_One_Field(" SELECT Aprvd FROM  PSM_R_Detail WHERE  Aprvd = 0 AND IRRev_LID =" + rlid)!=MainMDI.VIDE )  
					lvI.ForeColor= Color.Salmon   ; 
				
			}

         //   if (lvI.SubItems[1].Text.IndexOf("9910") > -1 || lvI.SubItems[1].Text.IndexOf("9911") > -1)
            if (IsTestingPrj (lvI.SubItems[1].Text))
            {
                lvI.ForeColor = Color.DarkMagenta;
            }

		//	lvI.SubItems.Add(MainMDI.Curr_FRMT( Tot )); 

		}

        private bool IsTestingPrj(string prjNB)
        {
            int prjFrom=9910, prjTO=9921;
            for (int i = prjFrom; i < prjTO; i++)
                if (prjNB.IndexOf(i.ToString()) > -1) return true;

            return false;
        }




        private string msg_Tests_Stat(string S)
        {
            //if (S.ToString ().Length ==0) S='N';
            string _stat = "";
            switch (S)
            {
                case "C":
                    _stat = "Completed";
                    break;
                case "S":
                    _stat = "StandBy";
                    break;
                case "I":
                    _stat = "In Process";
                    break;
                case "N":
                case "":
                    _stat = "N/C";
                    break;
                case "A":
                    // _stat ="n/a";
                    _stat = "---";
                    break;
                case "M":
                    _stat = "Tested Manually";// Completed";
                    break;
                default:
                    _stat = "?" + S + "?";
                    break;
            }
            return _stat;
        }

		private void lvQuotes_DoubleClick(object sender, System.EventArgs e)
		{

            bool OKgo = true;
          
            int ipos=lvQuotes.SelectedItems[0].SubItems[1].Text.IndexOf (" ");
      //      bool testPRJ = (Tools.Conv_Dbl (lvQuotes.SelectedItems[0].SubItems[1].Text.Substring (0,ipos)) > 9900);     // (lvQuotes.SelectedItems[0].SubItems[1].Text.IndexOf("9910") > -1 || lvQuotes.SelectedItems[0].SubItems[1].Text.IndexOf("9911") > -1);
      //     if (testPRJ)  OKgo = (MainMDI.User.ToLower ()=="bmustapha" ||   MainMDI.User.ToLower ()=="ede") ;

            if (IsTestingPrj(lvQuotes.SelectedItems[0].SubItems[1].Text)) OKgo = (MainMDI.User.ToLower() == "bmustapha" || MainMDI.User.ToLower() == "ede");


            if (OKgo )  
            {
                this.Cursor = Cursors.WaitCursor;
                MainMDI.ExecSql("delete " + MainMDI.t_Det_OL);
                edit_Order();
                this.Cursor = Cursors.Default;

                if (IsTestingPrj(lvQuotes.SelectedItems[0].SubItems[1].Text)) lvQuotes.SelectedItems[0].ForeColor = Color.DarkMagenta;
            }

         
		}

		private void edit_Order()
		{
			if (lvQuotes.SelectedItems.Count ==1) 	
			{
				if (MainMDI.User =="Admin")  //open project even opened one
				{
					MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where [user]='Admin'" );
					MainMDI.Use_QRID(-1,'R',"Admin");  
				}

				string usr=MainMDI.is_QR_Used('R',lvQuotes.SelectedItems[0].SubItems[5].Text ); //chek if project is opened open project even opened one
			//    string usr=MainMDI.VIDE ; //open project even opened one

				if (usr == MainMDI.VIDE  || MainMDI.User =="ede" )
				{

					MainMDI.Use_QRID(1,'R',lvQuotes.SelectedItems[0].SubItems[5].Text);  
					if (lvQuotes.SelectedItems[0].ForeColor != oldOrdersCLR )
					{
						string RRevName=lvQuotes.SelectedItems[0].SubItems[1].Text;
						int ipos=RRevName.IndexOf(" "); 
						RRevName=RRevName.Substring(ipos+1,RRevName.Length - (ipos+1));   
						Order  child_Ord = new Order(lvQuotes.SelectedItems[0].SubItems[6].Text,RRevName  );
						this.Hide();
						child_Ord.ShowDialog();
					
						this.Visible =true;
                        if (!cbseekby.Visible)
                        {
                            ref_ORDERlist(lvQuotes.SelectedItems[0].SubItems[5].Text, lvQuotes.SelectedItems[0].Index);

                            lvQuotes.SelectedItems[0].SubItems[10].Text = MainMDI.Test_Stat(lvQuotes.SelectedItems[0].SubItems[5].Text);

                            if (lvQuotes.Items[lvQuotes.SelectedItems[0].Index].ForeColor == Color.Blue)
                            {
                                if (MainMDI.Find_One_Field("SELECT sc_LID FROM PSM_R_SCD_INFO WHERE sc_status = 1 AND sc_IREVID =" + lvQuotes.Items[lvQuotes.SelectedItems[0].Index].SubItems[5].Text) != MainMDI.VIDE)
                                    lvQuotes.Items[lvQuotes.SelectedItems[0].Index].ForeColor = MainMDI.clr_R_Scheduled;
                            }
                        }
						MainMDI.Use_QRID(0,'R',lvQuotes.SelectedItems[0].SubItems[5].Text);  
						child_Ord.Close();child_Ord.Dispose();  
					}
					else    // Old orders format
					{
						Orders_XQR   XQR_Ord = new Orders_XQR('R',lvQuotes.SelectedItems[0].SubItems[5].Text );
						this.Hide ();
						XQR_Ord.ShowDialog();
						this.Visible =true;
						XQR_Ord.Close(); XQR_Ord.Dispose(); 

					}
				}
				else MessageBox.Show("Sorry, This PROJECT is opened by: " + usr); 
			}
		}

		private void edit_Quote(string QNB,string CpnyName)
		{
			char c=(QNB=="0") ? 'N' : 'E';
			int ndx=lvQuotes.SelectedItems[0].Index ;  
			Quote child4 = new Quote(Convert.ToInt32(QNB),CpnyName,c );
			child4.ShowDialog ();
			if (child4.lSave.Text =="S" ) 
			{

				lvQuotes.Items[ndx].SubItems[0].Text = child4.tQuoteID.Text ;
				lvQuotes.Items[ndx].SubItems[1].Text =child4.lQDopen.Text ;
				lvQuotes.Items[ndx].SubItems[2].Text =child4.lCpnyName.Text ;
				lvQuotes.Items[ndx].SubItems[3].Text =child4.tProjNAME.Text;
 
			}
			child4.Dispose(); 

/*
			if (QNB !="0" )
			{

			   Quote child4 = new Quote(Convert.ToInt32(QNB),CpnyName,'E'  );
			   child4.ShowDialog ();
			   child4.Dispose(); 
			//	MainMDI.frm_Qte.x_QID = Convert.ToInt32(QNB);  
			//	MainMDI.frm_Qte.x_CpnyName  =CpnyName;
			//	MainMDI.frm_Qte.x_opera  ='E';
			//	MainMDI.frm_Qte.ShowDialog ();

				//fill_lvQuotes(); 
			}
			else
			{ 
				Quote child4 = new Quote(0,"*",'N' );
				child4.ShowDialog ();
				child4.Dispose(); 
			//	MainMDI.frm_Qte = new Quote(0,"*",'E');
			//	MainMDI.frm_Qte.ShowDialog ();
			}
			 child4.Dispose(); 
			 */
		}

		private void Quotes_Look_Activated(object sender, System.EventArgs e)
		{
		// fill_lvQuotes(); 
		}

		private void grpRech_Enter(object sender, System.EventArgs e)
		{
		
		}


		private void btnDup_Click(object sender, System.EventArgs e)
		{
			
		}

	

		private void lCpnyID_Click(object sender, System.EventArgs e)
		{
		
		}

	

	
		private bool Found_InLV()
		{
			int ideb=0;
			bool found=false;
			if (tKey.Text !="")
			{
				if (ndxCLRD>-1 ) 
				{ 
					lvQuotes.Items[ndxCLRD].BackColor =Color.WhiteSmoke ; 
					ideb=ndxCLRD+1;
					ndxCLRD=-1;
				}
				while (true)
				{
					for (int i=ideb;i<lvQuotes.Items.Count ;i++)
					{
						if (( lvQuotes.Items[i].SubItems[seelCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1)) 
						{
							lvQuotes.Items[i].BackColor =Color.Yellow    ;
							lvQuotes.Items[i].Selected =true;
							lvQuotes.Items[i].EnsureVisible(); 
							ndxCLRD=i;
							i=lvQuotes.Items.Count+1;
							found=true;
							btnseek.Text = btnseek.Text.Replace("Search","Next ") ; 
						}
					}
					if (!found && ideb>0) ideb=0;
					else break;
				}
			}

			if (!found) ndxCLRD=-1;
			return found ;	

		
		}
	

		private void btnseek_BIGLIST()
		{
			int ideb=0;
			bool found=false;
			if (tKey.Text !="")
			{
				if (ndxCLRD>-1) 
				{ 
					lvQuotes.Items[ndxCLRD].BackColor =Color.WhiteSmoke ; 
					ideb=ndxCLRD+1;
					ndxCLRD=-1;
				}
				for (int i=ideb;i<lvQuotes.Items.Count ;i++)
				{
					if (( lvQuotes.Items[i].SubItems[seelCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1)) 
					{
						lvQuotes.Items[i].BackColor =Color.Yellow    ;
						lvQuotes.Items[i].Selected =true;
						lvQuotes.Items[i].EnsureVisible(); 
						ndxCLRD=i;
						i=lvQuotes.Items.Count+1;
						found=true;
						btnseek.Text = btnseek.Text.Replace("Search","Next ") ; 
					}
				}
			}
			if (!found) { MessageBox.Show("Sorry, Not Found !!!..."); ndxCLRD=-1;}
			
		}

        private void btnseek_OLORDERS()
        {
            int ideb = 0;
            bool found = false;
            if (tKey.Text != "")
            {
                if (ndxCLRD > -1)
                {
                    lvQuotes.Items[ndxCLRD].BackColor = Color.WhiteSmoke;
                    ideb = ndxCLRD + 1;
                    ndxCLRD = -1;
                }
                for (int i = ideb; i < lvQuotes.Items.Count; i++)
                {
                    if ((lvQuotes.Items[i].SubItems[seelCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1))
                    {
                        lvQuotes.Items[i].BackColor = Color.Yellow;
                        lvQuotes.Items[i].Selected = true;
                        lvQuotes.Items[i].EnsureVisible();
                        ndxCLRD = i;
                        i = lvQuotes.Items.Count + 1;
                        found = true;
                        btnseek.Text = btnseek.Text.Replace("Search", "Next ");
                    }
                }
            }
            if (!found) { MessageBox.Show("Sorry, Not Found !!!..."); ndxCLRD = -1; }

        }

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
		
		}

		private void Orders_Look_Resize(object sender, System.EventArgs e)
		{
			picExit.Left = this.Width -48;
		}

		private void picExit_Click(object sender, System.EventArgs e)
		{
			this.Hide();
		}



        public void Find_N_fill_Ord(string stSql)
        {
            lblAff.Text = DateTime.Now.ToLongTimeString();

            HT_Projects.Clear(); 
            if (tKey.Text.Length > 0)
            {

                int r_NBOrdr = MainMDI.NBOrdr;

                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                lnb.Text = "0"; lnb.Refresh();
                while (Oreadr.Read())
                {
                    if (Oreadr["PrjName"].ToString().IndexOf("Hakim") == -1)
                    {
                        string tot = Oreadr["RRev_Tot"].ToString();
                        if (HT_Projects.ContainsKey(Oreadr["IRRevID"].ToString()))
                        {
                            int ndxii = Int32.Parse(HT_Projects[Oreadr["IRRevID"].ToString()].ToString());
                            lvQuotes.Items[ndxii].SubItems[8].Text += "-" + Oreadr[0].ToString();
                            //  if (lvQuotes.Items[ndxii].SubItems[8].Text.IndexOf (" ++++") ==-1) lvQuotes.Items[ndxii].SubItems[8].Text += " ++++"; // / " + Oreadr[0].ToString();    
                        }
                        else
                        {
                            lvO_ORDER(Oreadr["dateRRev"].ToString().Substring(0, 10), MainMDI.A00(Convert.ToInt32(Oreadr["RID"].ToString()), MainMDI.NB_LookOrders_A00) + " " + Oreadr["RRev_Name"].ToString(), Oreadr["Custm_PO"].ToString(), Oreadr["Cpny_Name1"].ToString(), Oreadr["PrjName"].ToString(), Oreadr["IRRevID"].ToString(), Color.DarkBlue, Oreadr["RID"].ToString(), tot, Oreadr[0].ToString(), "Q" + Oreadr["Quote_ID"].ToString(), Oreadr["Tests"].ToString());
                            HT_Projects.Add(Oreadr["IRRevID"].ToString(), Convert.ToString(lvQuotes.Items.Count - 1));
                        }
                        if (cbseekby.Text != "Syspro-Invoice # ")
                        {
                            if (lvQuotes.Columns[8].Width == 0)
                            {
                                lvQuotes.Columns[8].Width = 250;
                                lvQuotes.Columns[8].Text = cbseekby.Text;
                            }
                        }
                        lnb.Text = Convert.ToString(Int32.Parse(lnb.Text) + 1); lnb.Refresh();
                    }
                }
                OConn.Close();
                label2.Text = DateTime.Now.ToLongTimeString();
                this.Refresh();
            }


            //MessageBox.Show ("NB= " + nb ); 

        }

        public void Find_N_fill_Ord_oldOK(string stSql)
        {
            lblAff.Text = DateTime.Now.ToLongTimeString();

            HT_Projects.Clear();
            if (tKey.Text.Length > 0)
            {

                int r_NBOrdr = MainMDI.NBOrdr;

                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                lnb.Text = "0"; lnb.Refresh();
                while (Oreadr.Read())
                {
                    string tot = Oreadr["RRev_Tot"].ToString();
                    if (HT_Projects.ContainsKey(Oreadr["IRRevID"].ToString()))
                    {
                        int ndxii = Int32.Parse(HT_Projects[Oreadr["IRRevID"].ToString()].ToString());
                        lvQuotes.Items[ndxii].SubItems[8].Text += "-" + Oreadr[0].ToString();
                        //  if (lvQuotes.Items[ndxii].SubItems[8].Text.IndexOf (" ++++") ==-1) lvQuotes.Items[ndxii].SubItems[8].Text += " ++++"; // / " + Oreadr[0].ToString();    
                    }
                    else
                    {
                        lvO_ORDER(Oreadr["dateRRev"].ToString().Substring(0, 10), MainMDI.A00(Convert.ToInt32(Oreadr["RID"].ToString()), MainMDI.NB_LookOrders_A00) + " " + Oreadr["RRev_Name"].ToString(), Oreadr["Custm_PO"].ToString(), Oreadr["Cpny_Name1"].ToString(), Oreadr["PrjName"].ToString(), Oreadr["IRRevID"].ToString(), Color.DarkBlue, Oreadr["RID"].ToString(), tot, Oreadr[0].ToString(), "Q" + Oreadr["Quote_ID"].ToString(), Oreadr["Tests"].ToString());
                        HT_Projects.Add(Oreadr["IRRevID"].ToString(), Convert.ToString(lvQuotes.Items.Count - 1));
                    }
                    if (lvQuotes.Columns[8].Width == 0)
                    {
                        lvQuotes.Columns[8].Width = 250;
                        lvQuotes.Columns[8].Text = cbseekby.Text;
                    }
                    lnb.Text = Convert.ToString(Int32.Parse(lnb.Text) + 1); lnb.Refresh();
                }
                OConn.Close();
                label2.Text = DateTime.Now.ToLongTimeString();
                this.Refresh();
            }


            //MessageBox.Show ("NB= " + nb ); 
        }



		public bool fill_found_Ord()
		{ 
			bool found =false;
			if (seekColNm.Length >1)
			{
                //[AND PSM_R_Rev.shiped <> 'C'"] replaced by [AND PSM_R_Rev.shiped <> 'W'] to display Canceled projects
                if (lwhr_prjStatus.Text == "") lwhr_prjStatus.Text = " PSM_R_Rev.shiped <> 'D' AND PSM_R_Rev.shiped <> 'W'";
   				int r_NBOrdr=MainMDI.NBOrdr ;
             //   string stSql = "SELECT PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_R_Rev.dateRRev, PSM_R_Rev.Custm_PO, PSM_COMPANY.Cpny_Name1, PSM_R_prj.PrjName, PSM_R_Rev.RRev_Name, PSM_R_Rev.RRev_Tot, PSM_Q_IGen.Quote_ID, PSM_R_Rev.shiped,PSM_R_Rev.Tests ,PSM_R_Rev.Tests " +
			//		"    FROM PSM_Q_IGen INNER JOIN (PSM_R_prj INNER JOIN (PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID) ON PSM_R_prj.PROJID = PSM_R_Rev.RID) ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID " +
			//		" where " + seekColNm + " like '%" + tKey.Text +"%'"  +	
			//		"    and PSM_R_Rev.shiped <>'D' ORDER BY PSM_R_Rev.dateRRev DESC, PSM_R_Rev.IRRevID DESC";

                string stSql = "SELECT PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_R_Rev.dateRRev, PSM_R_Rev.Custm_PO, PSM_COMPANY.Cpny_Name1, PSM_R_prj.PrjName, PSM_R_Rev.RRev_Name, PSM_R_Rev.RRev_Tot, PSM_Q_IGen.Quote_ID, PSM_R_Rev.shiped,PSM_R_Rev.Tests ,PSM_R_Rev.Tests " +
    "    FROM PSM_Q_IGen INNER JOIN (PSM_R_prj INNER JOIN (PSM_R_Rev INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID) ON PSM_R_prj.PROJID = PSM_R_Rev.RID) ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID " +
    " where " + seekColNm + " like '%" + tKey.Text + "%' AND " + lwhr_prjStatus.Text  + " ORDER BY PSM_R_Rev.dateRRev DESC, PSM_R_Rev.IRRevID DESC";

				SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
				OConn.Open ();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql ;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();
				
				while (Oreadr.Read ())
				{
					//if (Oreadr["RID"].ToString() =="2354") MessageBox.Show("ici"); 
					//	if (Oreadr["Custm_PO"].ToString ()=="2880") MessageBox.Show("Go"); 
					// string tot=(Oreadr["shiped"].ToString()[0]=='D') ? "0" :Oreadr["RRev_Tot"].ToString ();
					string tot=Oreadr["RRev_Tot"].ToString ();
					Color  clr= RRev_Colr(Oreadr["shiped"].ToString()[0],Oreadr["dateRRev"].ToString ());
                    if (clr == Color.Blue)
                    {
                        if (MainMDI.Find_One_Field("SELECT sc_LID FROM PSM_R_SCD_INFO WHERE sc_status = 1 AND sc_IREVID =" + Oreadr["IRRevID"].ToString()) != MainMDI.VIDE)
                            clr = MainMDI.clr_R_Scheduled;
                    }
					if (Oreadr["shiped"].ToString()[0]!='D' )
					{
                        lvO_ORDER(Oreadr["dateRRev"].ToString().Substring(0, 10), MainMDI.A00(Convert.ToInt32(Oreadr["RID"].ToString()), MainMDI.NB_LookOrders_A00) + " " + Oreadr["RRev_Name"].ToString(), Oreadr["Custm_PO"].ToString(), Oreadr["Cpny_Name1"].ToString(), Oreadr["PrjName"].ToString(), Oreadr["IRRevID"].ToString(), clr, Oreadr["RID"].ToString(), tot, "SN", "Q" + Oreadr["Quote_ID"].ToString(), Oreadr["Tests"].ToString()); //sn=RRev_SNList(Oreadr["IRRevID"].ToString()) + " " + BoardIn_SNList(Oreadr["IRRevID"].ToString(), 'I')
				//	MessageBox.Show("added= " +   lvQuotes.Items[lvQuotes.Items.Count -1].SubItems[3].Text ); 
					}
					found=true;
					
				
       /*        
                    string sta = msg_Tests_Stat(Oreadr["Tests"].ToString()); 
					for (int y=0;y<lvQuotes.Items.Count ;y++)
					{
						if (lvQuotes.Items[y].SubItems[5].Text  == Oreadr["IRRevID"].ToString ()) 
						{
							lvQuotes.Items[y].SubItems[10].Text=sta ;
							y=lvQuotes.Items.Count +1;
						}
					}
        */
				
				}
				OConn.Close();
			}
			else found=false;
			return found;
			
			//MessageBox.Show ("NB= " + nb ); 

		}

       
		private void littl_List()
		{

			bool res_Found=false;
			if (ndxCLRD==-1) Del_Bfr_Seek();
			else res_Found= Found_InLV();

			if (!res_Found )
			{
				if (!fill_found_Ord() )
				{
					MessageBox.Show("Sorry, Not Found !!!..."); 
					ndxCLRD=-1;
				}
				else 
				{
					ReSORT_lvQuotes(seelCol );  
					ReSeek();
					lvQuotes.Refresh();
				}
			}
		}



        private void seekby_LVcol()
        {
            this.Cursor = Cursors.WaitCursor;
            lvQuotes.BeginUpdate();
            if (in_typeO != 'O')
            {
                if (in_typeO == 'B') btnseek_BIGLIST();
                else littl_List();
            }
            else btnseek_BIGLIST();

            lvQuotes.EndUpdate();
            this.Cursor = Cursors.Default;
            if (tKey.Text.Length > 0) MainMDI.R_tkey = tKey.Text; 
        }


        string getPRJ_ALTKEYSP(string altkey)
        {

            //  int posU=altkey.IndexOf("_");
           ;
             
            //  int pos=Math.Min ( );
           int pos = altkey.Replace("_", "-").IndexOf("-");
                if (pos > -1)
                {
                    altkey = altkey.Substring(0, pos);
                    if (Tools.Conv_Dbl(altkey) > 0) return altkey;
                }

                return MainMDI.VIDE;

        }

        private string buid_Sql_more(string _keySeek, string _key)
        {
            string stSql=MainMDI.VIDE ;

            switch (_keySeek)                // [AND PSM_R_Rev.shiped <> 'C']  replaced by [AND PSM_R_Rev.shiped <> 'W'] to display Canceled project 
            {
                case "Syspro-Invoice # ":
                  
                    //stSql = "SELECT PSM_R_SBills.AccInv, PSM_R_SBills.b_RRevLID  AS IRRevID ,  PSM_R_prj.PrjName, PSM_COMPANY.Cpny_Name1, PSM_Q_IGen.Quote_ID, PSM_R_Rev.Tests, PSM_R_Rev.dateRRev, PSM_R_Rev.shiped, PSM_R_Rev.RRev_Name, PSM_R_Rev.RID, PSM_R_Rev.RRev_Tot, PSM_R_Rev.Custm_PO " +
                    //        " FROM         PSM_R_SBills INNER JOIN PSM_R_Rev ON PSM_R_SBills.b_RRevLID = PSM_R_Rev.IRRevID INNER JOIN PSM_R_prj ON PSM_R_Rev.RID = PSM_R_prj.PROJID INNER JOIN " +
                    //        "              PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid " +
                    //        " WHERE     (PSM_R_SBills.AccInv LIKE '%" + _key + "%') AND (PSM_R_Rev.shiped <> 'D') AND (PSM_R_Rev.shiped <> 'W')";

                  
                    string txINV = (_key.Length<MainMDI.SYSPRO_INV_len) ? MainMDI.A00(_key, MainMDI.SYSPRO_INV_len) : _key;
                  string altkey=  MainMDI.Find_One_Field_SYSPRO("select AlternateKey  FROM [SysproCompanyP].[dbo].[SorMasterRep]  where  InvoiceNumber ='" + txINV + "'");
                  txPrj.Text = altkey;
                  if (altkey != MainMDI.VIDE)
                  {
                      lprj.Visible = true;
                      txPrj.Visible = true;
                      string prj= getPRJ_ALTKEYSP(altkey);
                      if (prj == MainMDI.VIDE) if (Tools.Conv_Dbl(altkey) > 0) prj = altkey;
                      stSql = prj;
                      if (prj!=MainMDI.VIDE )
                          stSql = "SELECT PSM_R_Detail.PrimaxSN, PSM_R_Detail.IRRev_LID  AS IRRevID,  PSM_Q_IGen.Quote_ID, PSM_COMPANY.Cpny_Name1, PSM_R_prj.PrjName, PSM_R_Rev.RRev_Name, PSM_R_Rev.RID, PSM_R_Rev.RRev_Tot, PSM_R_Rev.Custm_PO, PSM_R_Rev.shiped, PSM_R_Rev.dateRRev, PSM_R_Rev.Tests FROM PSM_R_Detail " +
                                  " INNER JOIN PSM_R_Rev ON PSM_R_Detail.IRRev_LID = PSM_R_Rev.IRRevID INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID INNER JOIN PSM_R_prj ON PSM_R_Rev.RID = PSM_R_prj.PROJID " +
                              " WHERE    RID=" + prj + " AND PSM_R_Rev.shiped <> 'D' AND (PSM_R_Rev.shiped <> 'W ' ) AND (PSM_R_Rev.shiped <> 'C')  order by RID ";
                     
                  }
                  else stSql = MainMDI.VIDE;
                    break;

                case "System Serial #":
                    //   stSql = "SELECT PSM_R_Detail.IRRev_LID, PSM_R_Detail.PrimaxSN FROM PSM_R_Detail INNER JOIN PSM_R_Rev ON PSM_R_Detail.IRRev_LID = PSM_R_Rev.IRRevID WHERE PSM_R_Detail.PrimaxSN LIKE '%" + _key + "%' AND PSM_R_Rev.shiped <> 'D' AND (PSM_R_Rev.shiped <> 'C ')";
                    stSql = "SELECT PSM_R_Detail.PrimaxSN, PSM_R_Detail.IRRev_LID  AS IRRevID,  PSM_Q_IGen.Quote_ID, PSM_COMPANY.Cpny_Name1, PSM_R_prj.PrjName, PSM_R_Rev.RRev_Name, PSM_R_Rev.RID, PSM_R_Rev.RRev_Tot, PSM_R_Rev.Custm_PO, PSM_R_Rev.shiped, PSM_R_Rev.dateRRev, PSM_R_Rev.Tests FROM PSM_R_Detail " +
                            " INNER JOIN PSM_R_Rev ON PSM_R_Detail.IRRev_LID = PSM_R_Rev.IRRevID INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID INNER JOIN PSM_R_prj ON PSM_R_Rev.RID = PSM_R_prj.PROJID " +
                            " WHERE PSM_R_Detail.PrimaxSN LIKE '%" + _key + "%' AND PSM_R_Rev.shiped <> 'D' AND (PSM_R_Rev.shiped <> 'W ' ) AND (PSM_R_Rev.shiped <> 'C')  order by RID "; //, [Desc] ";
                    break;

                case "Charger Model ":
                    stSql = "SELECT  PSM_Q_Details.[Desc],PSM_R_Detail.IRRev_LID  AS IRRevID, PSM_R_Rev.RID, PSM_R_prj.PrjName, PSM_COMPANY.Cpny_Name1,PSM_Q_IGen.Quote_ID, PSM_R_Rev.RRev_Name,  PSM_R_Rev.RRev_Tot, PSM_R_Rev.Custm_PO , PSM_R_Rev.shiped, PSM_R_Rev.dateRRev, PSM_R_Rev.Tests,  PSM_Q_Details.Q_tec_Val FROM PSM_R_Rev " +
                            " INNER JOIN PSM_R_Detail ON PSM_R_Rev.IRRevID = PSM_R_Detail.IRRev_LID INNER JOIN PSM_Q_Details ON PSM_R_Detail.Qdet_LID = PSM_Q_Details.Detail_LID " +
                            " INNER JOIN PSM_R_prj ON PSM_R_Rev.RID = PSM_R_prj.PROJID INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID  inner join PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid " +
                            " WHERE PSM_R_Rev.shiped <> 'D' AND PSM_R_Rev.shiped <> 'W' AND PSM_R_Rev.shiped <> 'C'  AND ( PSM_Q_Details.[Desc] LIKE 'Chargeur automatique de batteries %" + _key + "%'  OR PSM_Q_Details.[Desc] LIKE 'Fully automatic battery charger %" + _key + "%')   ";
                    break;

                case "Rectifier Model ":
                    stSql = " SELECT  PSM_Q_Details.[Desc], PSM_R_Detail.IRRev_LID  AS IRRevID, PSM_R_prj.PrjName, PSM_COMPANY.Cpny_Name1, PSM_Q_IGen.Quote_ID, PSM_R_Rev.RRev_Name, PSM_R_Rev.RID, PSM_R_Rev.RRev_Tot, PSM_R_Rev.Custm_PO, PSM_R_Rev.Tests, PSM_R_Rev.shiped, PSM_R_Rev.dateRRev " +
                                "   FROM  PSM_R_Rev INNER JOIN PSM_R_Detail ON PSM_R_Rev.IRRevID = PSM_R_Detail.IRRev_LID INNER JOIN PSM_Q_Details ON PSM_R_Detail.Qdet_LID = PSM_Q_Details.Detail_LID INNER JOIN " +
                                "         PSM_R_prj ON PSM_R_Rev.RID = PSM_R_prj.PROJID INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid " +
                                " WHERE PSM_R_Rev.shiped <> 'D' AND PSM_R_Rev.shiped <> 'W' AND PSM_Q_Details.[Desc] LIKE '%" + _key + "%'";
                    break;
                case "Option Primax code ":
                    stSql = " SELECT  PSM_Q_Details.[Desc], PSM_R_Detail.IRRev_LID  AS IRRevID, PSM_R_prj.PrjName, PSM_COMPANY.Cpny_Name1, PSM_Q_IGen.Quote_ID, PSM_R_Rev.RRev_Name, PSM_R_Rev.RID, PSM_R_Rev.RRev_Tot, PSM_R_Rev.Custm_PO, PSM_R_Rev.Tests, PSM_R_Rev.shiped, PSM_R_Rev.dateRRev " +
                                "   FROM  PSM_R_Rev INNER JOIN PSM_R_Detail ON PSM_R_Rev.IRRevID = PSM_R_Detail.IRRev_LID INNER JOIN PSM_Q_Details ON PSM_R_Detail.Qdet_LID = PSM_Q_Details.Detail_LID INNER JOIN " +
                                "         PSM_R_prj ON PSM_R_Rev.RID = PSM_R_prj.PROJID INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid " +
                                " WHERE PSM_R_Rev.shiped <> 'D' AND PSM_R_Rev.shiped <> 'W' AND PSM_Q_Details.[Desc] LIKE '%" + _key + "%'";
                    break;

                case "Board Serial #":
                    stSql = " SELECT  PSM_R_Boards.brd_SN ,  PSM_R_Detail.IRRev_LID AS IRRevID, PSM_Q_IGen.Quote_ID, PSM_COMPANY.Cpny_Name1, PSM_R_prj.PrjName, PSM_R_Rev.RRev_Name, PSM_R_Rev.RID, PSM_R_Rev.RRev_Tot, PSM_R_Rev.Custm_PO, PSM_R_Rev.shiped, PSM_R_Rev.dateRRev, PSM_R_Rev.Tests " +
                            " FROM  PSM_R_Detail INNER JOIN PSM_R_Rev ON PSM_R_Detail.IRRev_LID = PSM_R_Rev.IRRevID INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid INNER JOIN " +
                            " PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID INNER JOIN PSM_R_prj ON PSM_R_Rev.RID = PSM_R_prj.PROJID INNER JOIN PSM_R_Boards ON PSM_R_Detail.Rdetail_LID = PSM_R_Boards.b_RRevDetLID " +
                            " WHERE (PSM_R_Rev.shiped <> 'D') AND (PSM_R_Rev.shiped <> 'W ') AND (PSM_R_Boards.brd_SN LIKE '%" + _key + "%') ORDER BY PSM_R_Boards.brd_SN ";
                    break;
            }
           

                return stSql;
        }

        private void seekby_More()
        {
            this.Cursor = Cursors.WaitCursor;
            lvQuotes.BeginUpdate();
                             lprj.Visible = false;
                      txPrj.Visible = false;
            string _stSql = buid_Sql_more(cbseekby.Text, tKey.Text );
            if (_stSql != MainMDI.VIDE)
            {
                Find_N_fill_Ord(_stSql);

                //lvQuotes.EndUpdate();
                //this.Cursor = Cursors.Default;
                if (lvQuotes.Items.Count == 0)
                {
                    MessageBox.Show("Sorry, Not Found !!!...");
                    ndxCLRD = -1;
                }
            }
            else
            {
                if (txPrj.Visible) MessageBox.Show("This Invoice has No Project in PGESCOM....");
                else  MessageBox.Show("Error:  Invalid Key !!!...call your Admin...");
            }
          // if (!cbseekby.Visible && tKey.Text.Length > 0) MainMDI.R_tkey = tKey.Text;
            lvQuotes.EndUpdate();
            this.Cursor = Cursors.Default;
        }

	    private void btnseek_Click(object sender, System.EventArgs e)
		{
            lnb.Text = "0";
            lprj.Visible = false;
            txPrj.Visible = false;
            txPrj.Text = "";
            if (in_typeO != 'O')
            {
                if (cbseekby.Visible)
                {
                    lvQuotes.Items.Clear();
                    seekby_More();
                }
                else
                {
                    lvQuotes.Items.Clear(); ndxCLRD = -1;  // this init is linked with any lvQuotes.Items.Clear()
                    seekby_LVcol();
                }

            }
            else
            {   //old PRMAX Orders   DB Access

                btnseek_OLORDERS();
            }
				

		}

		private void ColName(int colndx)
		{
			seekColNm="~";
 
			switch (colndx)
			{
				case 1:
					seekColNm="RID";   
					break;
				case 2:
					seekColNm="Custm_PO";   
					break;
				case 3:
					seekColNm="Cpny_Name1";
					break;
				case 4:
					seekColNm="ProjectName";
					break;
				case 9:
					seekColNm="Quote_ID";   
					break;
			}
		//	btnseek.Enabled = (seekColNm!="~");
		   //	btnseek.Enabled =  (tKey.Text.Length >0 && (seelCol!=0 && seelCol!=8 && seelCol!=9 && seelCol!=10 || in_typeO=='B') ) ;
				btnseek.Enabled =  (tKey.Text.Length >0 && (seelCol!=0 && seelCol!=8 && seelCol!=10 || in_typeO=='B') ) ;
		}

		private void ReSORT_lvQuotes(int e)
		{
			//MessageBox.Show (   e.Column.ToString()  );

			btnseek.Text = "Search by:    " + lvQuotes.Columns[e].Text ; 
			ColName(e) ;
			
			seelCol=e; 
			object sender=lvQuotes ;
			ListView myListView = (ListView)sender;

			// Determine if clicked column is already the column that is being sorted.
			if ( e == lvSorter.SortColumn )
			{
				// Reverse the current sort direction for this column.
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
				// Set the column number that is to be sorted; default to ascending.
				//lvSorter.SortColumn = e.Column; old
				//	lvSorter.Order = System.Windows.Forms.SortOrder.Ascending; old

				lvSorter.Order = (srtType=='A') ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
				srtType=(srtType=='A') ? 'D' : 'A';
				lvSorter.SortColumn = e;
			}

			// Perform the sort with these new sort options.
			myListView.Sort();
			oldSC=lvSorter.SortColumn;
			lvSorter.SortColumn =0;




		}

		private void Del_Bfr_Seek()
		{
			for (int i=0;i<lvQuotes.Items.Count ;i++)
	    		if (( lvQuotes.Items[i].SubItems[seelCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1)) 
                      lvQuotes.Items[i--].Remove();
			
		}
		private void ReSeek()
		{
			
			bool found=false;
			
			if (tKey.Text !="")
			{
				if (ndxCLRD>-1) 
				{ 
					lvQuotes.Items[ndxCLRD].BackColor =Color.WhiteSmoke ; 
					ndxCLRD=-1;
				}
				ndxCLRD=-1;
				for (int i=0;i<lvQuotes.Items.Count ;i++)
				{
					if (( lvQuotes.Items[i].SubItems[seelCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1)) 
					{
						lvQuotes.Items[i].BackColor =Color.Yellow  ;
						lvQuotes.Items[i].Selected =true;
						lvQuotes.Items[i].EnsureVisible(); 
						ndxCLRD=i;
						i=lvQuotes.Items.Count+1;
						found=true;
					}
				}
			}
			if (!found) { MessageBox.Show("Sorry, Not Found !!!..."); ndxCLRD=-1;}
		}

		private void tKey_TextChanged(object sender, System.EventArgs e)
		{
			btnseek.Enabled =  (tKey.Text.Length >0 && (seelCol!=0 && seelCol!=8 && seelCol!=9 && seelCol!=10)) ;// || in_typeO=='B') ) ;
		}
        private char tst_Status(string _iRRevLID)
        {

            long nbC=0, nbI=0;
            string stSql = " SELECT  tr_stat AS stat, COUNT(tr_TRName) AS nb FROM PSM_R_TRInfo " +
                         " WHERE   tr_iRRevID =" + _iRRevLID + " GROUP BY tr_stat ";
            SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
				OConn.Open ();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql ;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {
                    switch (Oreadr["stat"].ToString()[0])
                    {
                        case 'C':
                        case 'M':
                            nbC++;
                            break;
                        case 'I':
                        case 'S':
                            nbI++;
                            break;
                    }
                }
                return (nbC > 0 && nbI == 0) ? 'C' : 'I';  

        }
        private void btnUtst_Click(object sender, EventArgs e)
        {

         //   Report_ALL_RREV_Test_Stat();

     
        }
/*
        private void maj_stat_ALL_REV_old()
        {
            string stSql = "SELECT IRRevID, RID, Tests FROM  PSM_R_Rev ORDER BY IRRevID";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string tst_Status = "";
            while (Oreadr.Read())
            {
                tst_Status = Test_Stat(Oreadr["IRRevID"].ToString());
                switch (tst_Status)
                {
                    case "In Process":
                    case "StandBy":
                        tst_Status = "I";
                        break;
                    case "Completed":
                    case "Manually":
                        tst_Status = "C";
                        break;
                    case "N/C":
                        tst_Status = "N";
                        break;

                }
                if (tst_Status != Oreadr["Tests"].ToString()) MainMDI.ExecSql("UPDATE  PSM_R_Rev SET Tests ='" + tst_Status + "' WHERE IRRevID=" + Oreadr["IRRevID"].ToString());
                lblAff.Text = Oreadr["RID"].ToString();
                lblAff.Refresh();
            }

        }

        */

        private void Report_ALL_RREV_Test_Stat()
        {
            //	int y= lvQuotes.Items[i].SubItems[1].Text.IndexOf("2516");

            //    if (lvQuotes.Items[i].SubItems[1].Text.IndexOf("2538") > -1 ) MessageBox.Show("Hiiiiiiiiiiiiiiiiiiii"); 

            string stSql = " SELECT IRRevID, RID FROM PSM_R_Rev WHERE shiped <> 'D' AND shiped <> 'C'";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {

                string sta =MainMDI.Test_Stat(Oreadr["IRRevID"].ToString());
                MainMDI.ExecSql("UPDATE  PSM_R_Rev SET Tests ='" + sta[0] + "' WHERE IRRevID =" + Oreadr["IRRevID"].ToString());
                lblAff.Text = Oreadr["RID"].ToString();
                lblAff.Refresh();
            }
            OConn.Close();



        }
        private void disp_seek_KEY(string _keySeek)
        {

         //   tKey.Visible = false;
            grpCharg.Visible = false;
            cbRectifiers.Visible = false;
            lcbRectifiers.Visible = false;
            btnxl.Visible = false; 

            switch (_keySeek)
            {
                case "Syspro-Invoice # ":
                case "System Serial #":
                case "Board Serial #":
                case "Option Primax code ":
                case "TKEY":
                    if (_keySeek != "TKEY") btnseek.Text = "Search by: " + _keySeek; 
                    tKey.Visible = true;
                    tKey.Focus();
                    break;
                case "Charger Model ":
                    btnseek.Text = "Search by: " + _keySeek; 
                    grpCharg.Visible = true;
                    if (cbPxx.Text == "") cbPxx.SelectedIndex = 0;
                    if (cbPhs.Text == "") cbPhs.SelectedIndex = 0;
                    if (cbVdc.Text == "") cbVdc.SelectedIndex = 0;
                    if (cbIdc.Text == "") cbIdc.SelectedIndex = 0;
                    btnxl.Visible = true; 
 
             //       btnseek.Enabled = true; 
                    cbPxx.Focus();
                    break;
                case "Rectifier Model ":
                    btnseek.Text = "Search by: " + _keySeek;
                    if (cbRectifiers.Text == "") cbRectifiers.SelectedIndex = 0;
                    cbRectifiers.Visible = true;
                    lcbRectifiers.Visible = true;
               //     btnseek.Enabled = true;
                    cbRectifiers.Focus();
                    break;

            }
            lmodel.Visible = (grpCharg.Visible || cbRectifiers.Visible ); 

        }


        private void build_ref_Chrg()
        {
            string Pxx = cbPxx.Text;
            if (cbPxx.Text == "ALL P4500") Pxx = "P4500%";
            if (cbPxx.Text == "ALL P4600") Pxx = "P4600%";
            if (cbPxx.Text == "ALL P600") Pxx = "P600%";
            // Pxx = (cbPxx.Text == "ALL P4600") ? "P4600%" : cbPxx.Text;


            string Phs = (cbPhs.Text == "ALL") ? "%" : cbPhs.Text;
            string Vdc = (cbVdc.Text == "ALL") ? "%" : cbVdc.Text;
            string Idc = (cbIdc.Text == "ALL") ? "" : cbIdc.Text;
    

           tKey.Text = Pxx + "-" + Phs + "-" + Vdc + "-" + Idc;
        }
        private void cbseekby_SelectedIndexChanged(object sender, EventArgs e)
        {
            lprj.Visible = false;
            txPrj.Visible = false;
            txPrj.Text = "";
            if (cbseekby.Visible) tKey.Text = "";
            disp_seek_KEY(cbseekby.Text);  
           // if (tKey.Text.Length > 0) MainMDI.R_tkey = tKey.Text;
           
            seelCol = 1;

        }

        private void btn_dispCB_Click(object sender, EventArgs e)
        {
            lvQuotes.Items.Clear();
            lvQuotes.Refresh(); 
            cbseekby.Visible = !cbseekby.Visible;
            if (cbseekby.Visible)
            {
                if (cbseekby.Text == "") cbseekby.SelectedIndex = 0;
                disp_seek_KEY(cbseekby.Text);
            }
            else
            {

                disp_seek_KEY("RIEN");

                this.Cursor = Cursors.WaitCursor;
                lvQuotes.BeginUpdate();

     
                fill_lv_ORDERs_fast(in_typeO == 'B');
                lvSorter.SortColumn = 0;
                lvSorter.Order = System.Windows.Forms.SortOrder.Descending; //first err
                btnseek.Text = "Search by:    " + lvQuotes.Columns[0].Text;
                ColName(0);
                seelCol = 0;

                lvQuotes.EndUpdate();
                this.Cursor = Cursors.Default;

            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Del_Bfr_Seek();
        }

        private void cbRectifiers_SelectedIndexChanged(object sender, EventArgs e)
        {
            tKey.Text = (cbRectifiers.Text == "ALL") ? "P5500-" : cbRectifiers.Text; 
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

        private void chk_ADV_CheckedChanged(object sender, EventArgs e)
        {
            btn_dispCB_Click(sender, e);
            grpcat.Visible = !chk_ADV.Checked;
        }

        private void findOrdr_Click(object sender, EventArgs e)
        {

            toolBar1_code(0);
            
        }

        private void SCH_Ordr_Click(object sender, EventArgs e)
        {
           // if (MainMDI.User.ToLower() == "nboudjellab" || MainMDI.User.ToLower() == "ede") toolBar1_code(3);
        }

        private void ListSCD_Click(object sender, EventArgs e)
        {
            //if (MainMDI.User.ToLower() == "nboudjellab" || MainMDI.User.ToLower() == "ede") toolBar1_code(4);
        }
        private void bigLst_Click(object sender, EventArgs e)
        {
           //biglist
            toolBar1_code(5);



        }
        private void _exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void brd_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_SR3", true))  //Boards batchs
            {
                Orders_BoardLots blots = new Orders_BoardLots('C', "0");
                blots.ShowDialog();
            }
           
        }

        private void grpfind_Enter(object sender, EventArgs e)
        {

        }

        private void opAll_CheckedChanged(object sender, EventArgs e)
        {
            //[AND PSM_R_Rev.shiped <> 'C'"] replaced by [AND PSM_R_Rev.shiped <> 'W'] to display Canceled projects
            lwhr_prjStatus.Text = " PSM_R_Rev.shiped <> 'D' AND PSM_R_Rev.shiped <> 'W'";
        }

        private void opFapp_CheckedChanged(object sender, EventArgs e)
        {
            lwhr_prjStatus.Text = " PSM_R_Rev.shiped <> 'D' AND PSM_R_Rev.shiped <> 'C' AND PSM_R_Rev.shiped = 'F' ";
        }

        private void opInP_CheckedChanged(object sender, EventArgs e)
        {
            lwhr_prjStatus.Text = " PSM_R_Rev.shiped <> 'D' AND PSM_R_Rev.shiped <> 'C' AND PSM_R_Rev.shiped = ' ' ";
        }

        private void optSCD_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void opSHP_CheckedChanged(object sender, EventArgs e)
        {
            lwhr_prjStatus.Text = " PSM_R_Rev.shiped <> 'D' AND PSM_R_Rev.shiped <> 'C' AND PSM_R_Rev.shiped = 'S' ";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            chk_ADV.Checked = false;
            lvQuotes.Items.Clear();
            ndxCLRD = -1;
            fill_lv_ORDERs_fast(in_typeO == 'B');
            if (lvQuotes.Items.Count > 0)
            {
                lvSorter.SortColumn = 0;
                lvSorter.Order = System.Windows.Forms.SortOrder.Descending; //first err
                btnseek.Text = "Search by:    " + lvQuotes.Columns[0].Text;
                ColName(0);
                seelCol = 0;
            }
            else
            {
                MessageBox.Show("Sorry, Not Found !!!...");
                ndxCLRD = -1;
            }
            this.Cursor = Cursors.Default;
        }

        private void bigLst_Click_1(object sender, EventArgs e)
        {

        }


        private string Valid_PRJ(string ST_PRJ)
        {
            string res="";
            if (ST_PRJ[0] == 'P') ST_PRJ = ST_PRJ.Substring(1, ST_PRJ.Length - 1); 
            for (int i = 0; i < ST_PRJ.Length; i++)
            {
                if (ST_PRJ[i] > 47 && ST_PRJ[i] < 58)
                    res += ST_PRJ[i];
                else i = ST_PRJ.Length;
            }
            return res;
 
        }
        private void maj_OLDPRJ_NS()
        {
            

            string stSql = " SELECT * FROM PSM_PXOrders_SN order by Project ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string lst_badPrj="";
            while (Oreadr.Read())
            {

                string PrjNB =Valid_PRJ(Oreadr["Project"].ToString());
                int I_PrjNB = (PrjNB =="") ? 0 : Int32.Parse (PrjNB );
                if (I_PrjNB > 0)
                {
                    string pLID = "", oldSN = "";
                    MainMDI.Find_2_Field("select OldRlid,ALL_SN FROM PSM_PXOrders where OrderNumber='" + I_PrjNB + "'", ref pLID, ref oldSN);
                    if (pLID != MainMDI.VIDE)
                    {
                        if (oldSN.Length >3 &&  oldSN[0] != 'S') oldSN = "S" + oldSN;
                        string NewSN = (oldSN == "") ? Oreadr["SerialN"].ToString() : oldSN + " | " + Oreadr["SerialN"].ToString();
                        stSql = "UPDATE  PSM_PXOrders SET [ALL_SN] ='" + NewSN + "' WHERE OldRlid =" + pLID;
                  //      MainMDI.ExecSql(stSql);
                    }
                    else lst_badPrj += Oreadr["Project"].ToString() + " | " + Oreadr["Project"].ToString() + "\n";
                }
                else lst_badPrj += Oreadr["Project"].ToString() +" / " +Oreadr["Project"].ToString() +  "\n";
            }
            OConn.Close();

            MessageBox.Show(lst_badPrj+"\n"); 

        }



        //new 2010
        private void ts_sysPro_Click(object sender, EventArgs e)
        {
            //maj_OLDPRJ_NS();

            switch (MainMDI.User.ToLower())
            {
                case "mbyad":
                case "mrouleau":
                case "vbalan":
                case "ede":
                   // toolBar1_code(6);
                   // SEND_PROJECT_TO_SYSPRO6 ();
                    SEND_PROJECT_TO_SYSPRO7();
                    break;
                default:
                    MessageBox.Show("Access Denied...................");
                    break;
            }

            //new 2010


        }

        void SEND_PROJECT_TO_SYSPRO6()
        {

            if (lvQuotes.SelectedItems.Count == 1)
            {

                if (MainMDI.ALWD_USR("OR_SCD", true))
                {
                    this.Cursor = Cursors.WaitCursor;
                    Order_SysPro_XML xml_Frm = new Order_SysPro_XML(lvQuotes.SelectedItems[0].SubItems[5].Text, lvQuotes.SelectedItems[0].SubItems[1].Text);
                    this.Hide();
                    xml_Frm.ShowDialog();
                    this.Visible = true;
                    xml_Frm.Close();
                    this.Cursor = Cursors.Default;

                }
            }


        }
        void SEND_PROJECT_TO_SYSPRO7()
        {

            if (lvQuotes.SelectedItems.Count == 1)
            {

                if (MainMDI.ALWD_USR("OR_SCD", true))
                {
                    this.Cursor = Cursors.WaitCursor;
                    Order_SysPro_XML_V7  xml_Frm = new Order_SysPro_XML_V7 (lvQuotes.SelectedItems[0].SubItems[5].Text, lvQuotes.SelectedItems[0].SubItems[1].Text);
                    this.Hide();
                    xml_Frm.ShowDialog();
                    this.Visible = true;
                    xml_Frm.Close();
                    this.Cursor = Cursors.Default;

                }
            }


        }


        private void PBWait_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void AddMecanic_Click(object sender, EventArgs e)
        {

        }

        private void AddElectric_Click(object sender, EventArgs e)
        {

        }

        private void ListMecanic_Click(object sender, EventArgs e)
        {

        }

        private void ListElectric_Click(object sender, EventArgs e)
        {

        }

        private void ElecSC_AM_Click(object sender, EventArgs e)
        {
          //  if (MainMDI.User.ToLower() == "nboudjellab" || MainMDI.User.ToLower() == "ede")
            if (MainMDI.ALWD_USR("SC_EL_G", true))
            {
                EM = 'E';
                toolBar1_code(3);
            }
            
        }

        private void ElecSC_List_Click(object sender, EventArgs e)
        {
          //  if (MainMDI.User.ToLower() == "nboudjellab" || MainMDI.User.ToLower() == "ede")
            if (MainMDI.ALWD_USR("SC_EL_V", true))
            {
                EM = 'E';
                toolBar1_code(4);
            }
        }

        private void MecSC_AM_Click(object sender, EventArgs e)
        {
           // if (MainMDI.User.ToLower() == "nboudjellab" || MainMDI.User.ToLower() == "ede")
            if (MainMDI.ALWD_USR("SC_M_G", true))
            {
                EM = 'M';
                toolBar1_code(3);
            }
        }

        private void MecSC_List_Click(object sender, EventArgs e)
        {
          //  if (MainMDI.User.ToLower() == "nboudjellab" || MainMDI.User.ToLower() == "ede")
            if (MainMDI.ALWD_USR("SC_M_V", true))
            
            {
                EM = 'M';
                toolBar1_code(4);
            }
        }

        private void btnxl_Click(object sender, EventArgs e)
        {
          //  Chargers_list_VAC_MODEL();
        }


        private void Chargers_list_VAC_MODEL()
        {
             this.Cursor = Cursors.WaitCursor;
               
            string _stSql = buid_Sql_more(cbseekby.Text, tKey.Text );
            if (_stSql != MainMDI.VIDE)
            {
               // Find_N_fill_Ord(_stSql);
                Find_N_XLfile(_stSql);
            }
            else MessageBox.Show("Error:  Invalid Key !!!...call your Admin..."); 
             
    
        }

        public void Find_N_XLfile(string stSql)
        {
            lblAff.Text = DateTime.Now.ToLongTimeString();
            lvQuotes.Columns[8].Width = 0;
            HT_Projects.Clear();
            if (tKey.Text.Length > 0)
            {

                int r_NBOrdr = MainMDI.NBOrdr;

                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                lnb.Text = "0"; lnb.Refresh();
                while (Oreadr.Read())
                {
                    string tot = Oreadr["RRev_Tot"].ToString();
                    //     Color clr = RRev_Colr(Oreadr["shiped"].ToString()[0], Oreadr["dateRRev"].ToString());
                    //     if (clr == Color.Blue)
                    //     {
                    //         if (MainMDI.Find_One_Field("SELECT sc_LID FROM PSM_R_SCD_INFO WHERE sc_status = 1 AND sc_IREVID =" + Oreadr["IRRevID"].ToString()) != MainMDI.VIDE)
                    //             clr = MainMDI.clr_R_Scheduled;
                    //      }
                    if (HT_Projects.ContainsKey(Oreadr["IRRevID"].ToString()))
                    {
                        int ndxii = Int32.Parse(HT_Projects[Oreadr["IRRevID"].ToString()].ToString());
                        lvQuotes.Items[ndxii].SubItems[8].Text += "-" + Oreadr[0].ToString();
                        //  if (lvQuotes.Items[ndxii].SubItems[8].Text.IndexOf (" ++++") ==-1) lvQuotes.Items[ndxii].SubItems[8].Text += " ++++"; // / " + Oreadr[0].ToString();    
                    }
                    else
                    {
                        lvO_ORDER(Oreadr["dateRRev"].ToString().Substring(0, 10), MainMDI.A00(Convert.ToInt32(Oreadr["RID"].ToString()), MainMDI.NB_LookOrders_A00) + " " + Oreadr["RRev_Name"].ToString(), Oreadr["Custm_PO"].ToString(), Oreadr["Cpny_Name1"].ToString(), Oreadr["PrjName"].ToString(), Oreadr["IRRevID"].ToString(), Color.DarkBlue, Oreadr["RID"].ToString(), tot, Oreadr[0].ToString(), "Q" + Oreadr["Quote_ID"].ToString(), Oreadr["Tests"].ToString());
                        HT_Projects.Add(Oreadr["IRRevID"].ToString(), Convert.ToString(lvQuotes.Items.Count - 1));
                    }
                    if (lvQuotes.Columns[8].Width == 0)
                    {
                        lvQuotes.Columns[8].Width = 250;
                        lvQuotes.Columns[8].Text = cbseekby.Text;
                    }
                    lnb.Text = Convert.ToString(Int32.Parse(lnb.Text) + 1); lnb.Refresh();
                }
                OConn.Close();
                label2.Text = DateTime.Now.ToLongTimeString();
                this.Refresh();
            }


            //MessageBox.Show ("NB= " + nb ); 

        }

        private void projectsScheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Order_Sched_RP myfrm = new Order_Sched_RP();
            this.Hide();
            myfrm.ShowDialog();
            this.Visible = true;
        }

        private void tlsDDRep_Click(object sender, EventArgs e)
        {

        }

  




		}
		

}
