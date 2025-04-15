using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Threading;
using System.Data ;
using System.Data.OleDb ;
using System.Data.SqlClient  ;
using EAHLibs;

namespace PGESCOM
{
	#region delegate
	public delegate void deleg_RepTrace(string trace);
	public delegate void deleg_endTHR(string msg);
	#endregion delegate
	/// <summary>
	/// Summary description for Stati.
	/// </summary>
	
	public class ChargerCOST : System.Windows.Forms.Form
	{
		#region kim decla
		private ListViewColumnSorter  lvSorter=null;
		private ListViewColumnSorter  lvSorterProj=null;
		private int seelCol=0;
		private int oldSC=0;
		private char srtType='A';
		
		private Lib1 Tools = new Lib1();
		private int ndxfound=0;
		private Charger CHRGR;
		private Component Cpt;
		public char curr_PHS='1';
		public double CH_COST=0;
		
		
		Thread m_WkTHRD;
		ManualResetEvent m_EventStopThread;
		ManualResetEvent m_EventThreadStopped;
		public deleg_RepTrace m_RepTrace;
		public deleg_endTHR m_endTHR;


		#endregion kim decla

		private System.Windows.Forms.GroupBox grpfind;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Button btnQt;
		private System.Windows.Forms.Button btnRRev;
		private System.Windows.Forms.PictureBox picExit;
		private System.Windows.Forms.Label lcpnyID;
		private System.Windows.Forms.Label lempID;
		private System.Windows.Forms.Label lTo;
		private System.Windows.Forms.Label lOp;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbTo;
		private System.Windows.Forms.ComboBox cbCpts;
		private System.Windows.Forms.ToolBarButton ph1;
		private System.Windows.Forms.ColumnHeader CPTREF;
		private System.Windows.Forms.ColumnHeader CAT1;
		private System.Windows.Forms.ColumnHeader val1;
		private System.Windows.Forms.ColumnHeader CAT2;
		private System.Windows.Forms.ColumnHeader val2;
		private System.Windows.Forms.ColumnHeader CAT3;
		private System.Windows.Forms.ColumnHeader val3;
		private System.Windows.Forms.ColumnHeader Qty;
		private System.Windows.Forms.ColumnHeader COST;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label lfrom;
		private System.Windows.Forms.ComboBox cbFrom;
		private System.Windows.Forms.RadioButton opPHS1;
		private System.Windows.Forms.RadioButton opPHS3;
		private System.Windows.Forms.Label tBigTot;
		private System.Windows.Forms.Label lbgtot;
		public System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.Label LPxx;
		private System.Windows.Forms.Panel pnlALL;
		private System.Windows.Forms.Panel pnlone;
		private System.Windows.Forms.ToolBarButton chrg1;
		private System.Windows.Forms.ContextMenu PHS_XL_mnu;
		private System.Windows.Forms.ContextMenu PHS_COST_mnu;
		private System.Windows.Forms.ToolBarButton XL;
		private System.Windows.Forms.MenuItem Cost_1;
		private System.Windows.Forms.MenuItem Cost_3;
		private System.Windows.Forms.MenuItem XL_1;
		private System.Windows.Forms.MenuItem XL_3;
		public System.Windows.Forms.ListView lvQuotesOLD;
		public System.Windows.Forms.ListView lvQuotes;
		private System.Windows.Forms.ColumnHeader c_CPTREF;
		private System.Windows.Forms.ColumnHeader c_5;
		private System.Windows.Forms.ColumnHeader c_10;
		private System.Windows.Forms.ColumnHeader c_15;
		private System.Windows.Forms.ColumnHeader c_20;
		private System.Windows.Forms.ColumnHeader c_25;
		private System.Windows.Forms.ColumnHeader c_30;
		private System.Windows.Forms.ColumnHeader c_35;
		private System.Windows.Forms.ColumnHeader c_40;
		private System.Windows.Forms.ColumnHeader c_50;
		private System.Windows.Forms.ColumnHeader c_60;
		private System.Windows.Forms.ColumnHeader c_70;
		private System.Windows.Forms.ColumnHeader c_75;
		private System.Windows.Forms.ColumnHeader c_80;
		private System.Windows.Forms.ColumnHeader c_100;
		private System.Windows.Forms.ColumnHeader c_125;
		private System.Windows.Forms.ColumnHeader c_150;
		private System.Windows.Forms.ColumnHeader c_175;
		private System.Windows.Forms.ColumnHeader c_200;
		private System.Windows.Forms.ColumnHeader c_225;
		private System.Windows.Forms.ColumnHeader c_250;
		private System.Windows.Forms.ColumnHeader c_275;
		private System.Windows.Forms.ColumnHeader c_300;
		private System.Windows.Forms.ColumnHeader c_325;
		private System.Windows.Forms.ColumnHeader c_350;
		private System.Windows.Forms.ColumnHeader c_375;
		private System.Windows.Forms.ColumnHeader c_400;
		private System.Windows.Forms.ColumnHeader c_500;
		private System.Windows.Forms.ColumnHeader c_600;
		private System.Windows.Forms.ColumnHeader c_750;
		private System.Windows.Forms.ColumnHeader c_800;
		private System.Windows.Forms.ColumnHeader c_900;
		private System.Windows.Forms.ColumnHeader c_1000;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		public System.Windows.Forms.ComboBox cbPhs;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.ComboBox cbPxx;
		public System.Windows.Forms.ComboBox cbVdc;
		public System.Windows.Forms.ComboBox cbIdc;
		public System.Windows.Forms.PictureBox pictureBox1;
		public System.Windows.Forms.ComboBox cbIDCto;
		private System.Windows.Forms.Label lcbTo;
		private System.Windows.Forms.ColumnHeader linID;
		private System.Windows.Forms.ColumnHeader crec;
		private System.Windows.Forms.CheckBox chk_tecV;
		private System.Windows.Forms.Label lidc2;
		private System.Windows.Forms.ToolBarButton Stpl;
		private System.Windows.Forms.ImageList Fst_IL32;
		private System.ComponentModel.IContainer components;

		public ChargerCOST()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//thrd functions
			m_RepTrace  = new deleg_RepTrace(this.disp_trace);  
			m_endTHR = new deleg_endTHR(this.endTHRmsg );
            m_EventStopThread = new ManualResetEvent(false);
			m_EventThreadStopped = new ManualResetEvent(false);
		


			//thrd functions


			// Sort is disabled
		//	lvSorter = new ListViewColumnSorter(); 
		//	this.lvQuotes.ListViewItemSorter  = lvSorter ; 
		//	lvQuotes.AutoArrange=true; 


		//	lvSorter.SortColumn =34;  //LineID column
		//	lvSorter.Order =SortOrder.Ascending  ;
		//	seelCol=34;

		//	fill_FROM_TO();
		//	fill_CPT();
         //	cbCpts.Text ="ALL";
            //fill_All_cb("c"); 
			cbPxx.Items.Clear();cbPxx.Items.Add("P4500"); 
			fill_All_cb("v"); 
			fill_All_cb("i"); 
			if (cbPxx.Items.Count >0) cbPxx.Text = cbPxx.Items[0].ToString() ;  
			if (cbPhs.Items.Count >0) cbPhs.Text = cbPhs.Items[0].ToString();  
			if (cbVdc.Items.Count >0) cbVdc.Text = cbVdc.Items[0].ToString();  
			if (cbIdc.Items.Count >0) cbIdc.Text = cbIdc.Items[0].ToString(); 
		//	cbPxx.locked =true;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChargerCOST));
            this.grpfind = new System.Windows.Forms.GroupBox();
            this.lOp = new System.Windows.Forms.Label();
            this.lempID = new System.Windows.Forms.Label();
            this.lcpnyID = new System.Windows.Forms.Label();
            this.btnRRev = new System.Windows.Forms.Button();
            this.lTo = new System.Windows.Forms.Label();
            this.btnQt = new System.Windows.Forms.Button();
            this.lvQuotesOLD = new System.Windows.Forms.ListView();
            this.CPTREF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CAT1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.val1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CAT2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.val2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CAT3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.val3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.COST = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnlone = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.chk_tecV = new System.Windows.Forms.CheckBox();
            this.lidc2 = new System.Windows.Forms.Label();
            this.lcbTo = new System.Windows.Forms.Label();
            this.cbIDCto = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.cbPhs = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.cbPxx = new System.Windows.Forms.ComboBox();
            this.cbVdc = new System.Windows.Forms.ComboBox();
            this.cbIdc = new System.Windows.Forms.ComboBox();
            this.lfrom = new System.Windows.Forms.Label();
            this.cbFrom = new System.Windows.Forms.ComboBox();
            this.tBigTot = new System.Windows.Forms.Label();
            this.lbgtot = new System.Windows.Forms.Label();
            this.opPHS1 = new System.Windows.Forms.RadioButton();
            this.opPHS3 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlALL = new System.Windows.Forms.Panel();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.LPxx = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbCpts = new System.Windows.Forms.ComboBox();
            this.cbTo = new System.Windows.Forms.ComboBox();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.ph1 = new System.Windows.Forms.ToolBarButton();
            this.PHS_COST_mnu = new System.Windows.Forms.ContextMenu();
            this.Cost_1 = new System.Windows.Forms.MenuItem();
            this.Cost_3 = new System.Windows.Forms.MenuItem();
            this.XL = new System.Windows.Forms.ToolBarButton();
            this.PHS_XL_mnu = new System.Windows.Forms.ContextMenu();
            this.XL_1 = new System.Windows.Forms.MenuItem();
            this.XL_3 = new System.Windows.Forms.MenuItem();
            this.chrg1 = new System.Windows.Forms.ToolBarButton();
            this.Stpl = new System.Windows.Forms.ToolBarButton();
            this.Fst_IL32 = new System.Windows.Forms.ImageList(this.components);
            this.picExit = new System.Windows.Forms.PictureBox();
            this.lvQuotes = new System.Windows.Forms.ListView();
            this.c_CPTREF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_25 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_35 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_40 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_50 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_60 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_70 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_75 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_80 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_100 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_125 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_150 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_175 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_200 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_225 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_250 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_275 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_300 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_325 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_350 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_375 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_400 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_500 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_600 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_750 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_800 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_900 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_1000 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.crec = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.linID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpfind.SuspendLayout();
            this.pnlone.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlALL.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            this.SuspendLayout();
            // 
            // grpfind
            // 
            this.grpfind.Controls.Add(this.lOp);
            this.grpfind.Controls.Add(this.lempID);
            this.grpfind.Controls.Add(this.lcpnyID);
            this.grpfind.Controls.Add(this.btnRRev);
            this.grpfind.Controls.Add(this.lTo);
            this.grpfind.Controls.Add(this.btnQt);
            this.grpfind.Controls.Add(this.lvQuotesOLD);
            this.grpfind.Controls.Add(this.pnlone);
            this.grpfind.Controls.Add(this.pnlALL);
            this.grpfind.Controls.Add(this.label1);
            this.grpfind.Controls.Add(this.cbCpts);
            this.grpfind.Controls.Add(this.cbTo);
            this.grpfind.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpfind.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grpfind.Location = new System.Drawing.Point(0, 56);
            this.grpfind.Name = "grpfind";
            this.grpfind.Size = new System.Drawing.Size(960, 88);
            this.grpfind.TabIndex = 7;
            this.grpfind.TabStop = false;
            // 
            // lOp
            // 
            this.lOp.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lOp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lOp.Location = new System.Drawing.Point(808, 40);
            this.lOp.Name = "lOp";
            this.lOp.Size = new System.Drawing.Size(24, 16);
            this.lOp.TabIndex = 177;
            this.lOp.Text = "A";
            this.lOp.Visible = false;
            // 
            // lempID
            // 
            this.lempID.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lempID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lempID.Location = new System.Drawing.Point(896, 16);
            this.lempID.Name = "lempID";
            this.lempID.Size = new System.Drawing.Size(24, 16);
            this.lempID.TabIndex = 172;
            this.lempID.Text = "0";
            this.lempID.Visible = false;
            // 
            // lcpnyID
            // 
            this.lcpnyID.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lcpnyID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lcpnyID.Location = new System.Drawing.Point(888, 40);
            this.lcpnyID.Name = "lcpnyID";
            this.lcpnyID.Size = new System.Drawing.Size(24, 16);
            this.lcpnyID.TabIndex = 171;
            this.lcpnyID.Text = "0";
            this.lcpnyID.Visible = false;
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
            // lTo
            // 
            this.lTo.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTo.ForeColor = System.Drawing.Color.Red;
            this.lTo.Location = new System.Drawing.Point(576, 16);
            this.lTo.Name = "lTo";
            this.lTo.Size = new System.Drawing.Size(32, 20);
            this.lTo.TabIndex = 161;
            this.lTo.Text = "To:";
            this.lTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lTo.Visible = false;
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
            // lvQuotesOLD
            // 
            this.lvQuotesOLD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvQuotesOLD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CPTREF,
            this.CAT1,
            this.val1,
            this.CAT2,
            this.val2,
            this.CAT3,
            this.val3,
            this.Qty,
            this.COST});
            this.lvQuotesOLD.ForeColor = System.Drawing.Color.Red;
            this.lvQuotesOLD.FullRowSelect = true;
            this.lvQuotesOLD.GridLines = true;
            this.lvQuotesOLD.Location = new System.Drawing.Point(728, 16);
            this.lvQuotesOLD.Name = "lvQuotesOLD";
            this.lvQuotesOLD.Size = new System.Drawing.Size(184, 48);
            this.lvQuotesOLD.TabIndex = 202;
            this.lvQuotesOLD.UseCompatibleStateImageBehavior = false;
            this.lvQuotesOLD.View = System.Windows.Forms.View.Details;
            this.lvQuotesOLD.Visible = false;
            // 
            // CPTREF
            // 
            this.CPTREF.Text = "CPT REF";
            this.CPTREF.Width = 152;
            // 
            // CAT1
            // 
            this.CAT1.Text = "Feat#1";
            this.CAT1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CAT1.Width = 70;
            // 
            // val1
            // 
            this.val1.Text = "Value";
            this.val1.Width = 64;
            // 
            // CAT2
            // 
            this.CAT2.Text = "Feat#2";
            this.CAT2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CAT2.Width = 70;
            // 
            // val2
            // 
            this.val2.Text = "Value";
            this.val2.Width = 64;
            // 
            // CAT3
            // 
            this.CAT3.Text = "Feat#3";
            this.CAT3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.CAT3.Width = 70;
            // 
            // val3
            // 
            this.val3.Text = "Value";
            this.val3.Width = 64;
            // 
            // Qty
            // 
            this.Qty.Text = "QTY";
            this.Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // COST
            // 
            this.COST.Text = "COST";
            this.COST.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.COST.Width = 113;
            // 
            // pnlone
            // 
            this.pnlone.Controls.Add(this.pictureBox1);
            this.pnlone.Controls.Add(this.chk_tecV);
            this.pnlone.Controls.Add(this.lidc2);
            this.pnlone.Controls.Add(this.lcbTo);
            this.pnlone.Controls.Add(this.cbIDCto);
            this.pnlone.Controls.Add(this.label6);
            this.pnlone.Controls.Add(this.label5);
            this.pnlone.Controls.Add(this.label4);
            this.pnlone.Controls.Add(this.label3);
            this.pnlone.Controls.Add(this.label7);
            this.pnlone.Controls.Add(this.label8);
            this.pnlone.Controls.Add(this.cbPhs);
            this.pnlone.Controls.Add(this.label22);
            this.pnlone.Controls.Add(this.cbPxx);
            this.pnlone.Controls.Add(this.cbVdc);
            this.pnlone.Controls.Add(this.cbIdc);
            this.pnlone.Controls.Add(this.lfrom);
            this.pnlone.Controls.Add(this.cbFrom);
            this.pnlone.Controls.Add(this.tBigTot);
            this.pnlone.Controls.Add(this.lbgtot);
            this.pnlone.Controls.Add(this.opPHS1);
            this.pnlone.Controls.Add(this.opPHS3);
            this.pnlone.Controls.Add(this.label2);
            this.pnlone.Location = new System.Drawing.Point(8, 16);
            this.pnlone.Name = "pnlone";
            this.pnlone.Size = new System.Drawing.Size(696, 64);
            this.pnlone.TabIndex = 238;
            this.pnlone.Visible = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pictureBox1.ForeColor = System.Drawing.Color.Blue;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(608, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(64, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 240;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // chk_tecV
            // 
            this.chk_tecV.Location = new System.Drawing.Point(488, 24);
            this.chk_tecV.Name = "chk_tecV";
            this.chk_tecV.Size = new System.Drawing.Size(128, 24);
            this.chk_tecV.TabIndex = 244;
            this.chk_tecV.Text = "display Tech. Values";
            // 
            // lidc2
            // 
            this.lidc2.BackColor = System.Drawing.SystemColors.Control;
            this.lidc2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lidc2.Location = new System.Drawing.Point(408, 8);
            this.lidc2.Name = "lidc2";
            this.lidc2.Size = new System.Drawing.Size(56, 16);
            this.lidc2.TabIndex = 243;
            this.lidc2.Text = "IDC";
            this.lidc2.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // lcbTo
            // 
            this.lcbTo.BackColor = System.Drawing.SystemColors.Control;
            this.lcbTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcbTo.ForeColor = System.Drawing.Color.Red;
            this.lcbTo.Location = new System.Drawing.Point(360, 26);
            this.lcbTo.Name = "lcbTo";
            this.lcbTo.Size = new System.Drawing.Size(40, 20);
            this.lcbTo.TabIndex = 242;
            this.lcbTo.Text = "TO:";
            this.lcbTo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbIDCto
            // 
            this.cbIDCto.BackColor = System.Drawing.Color.Lavender;
            this.cbIDCto.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIDCto.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIDCto.ItemHeight = 16;
            this.cbIDCto.Location = new System.Drawing.Point(400, 24);
            this.cbIDCto.Name = "cbIDCto";
            this.cbIDCto.Size = new System.Drawing.Size(80, 24);
            this.cbIDCto.TabIndex = 241;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(256, 24);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(8, 20);
            this.label6.TabIndex = 201;
            this.label6.Text = "-";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(176, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(8, 20);
            this.label5.TabIndex = 200;
            this.label5.Text = "-";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(112, 24);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(8, 20);
            this.label4.TabIndex = 199;
            this.label4.Text = "-";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(280, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 198;
            this.label3.Text = "IDC";
            this.label3.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(192, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 196;
            this.label7.Text = "VDC";
            this.label7.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(128, 8);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(40, 16);
            this.label8.TabIndex = 194;
            this.label8.Text = "PHS";
            this.label8.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
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
            this.cbPhs.Location = new System.Drawing.Point(120, 24);
            this.cbPhs.Name = "cbPhs";
            this.cbPhs.Size = new System.Drawing.Size(56, 24);
            this.cbPhs.TabIndex = 193;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.Location = new System.Drawing.Point(24, 8);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(70, 16);
            this.label22.TabIndex = 192;
            this.label22.Text = "PXXXX";
            this.label22.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // cbPxx
            // 
            this.cbPxx.BackColor = System.Drawing.Color.Lavender;
            this.cbPxx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPxx.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbPxx.ItemHeight = 16;
            this.cbPxx.Location = new System.Drawing.Point(16, 24);
            this.cbPxx.Name = "cbPxx";
            this.cbPxx.Size = new System.Drawing.Size(96, 24);
            this.cbPxx.TabIndex = 191;
            this.cbPxx.SelectedIndexChanged += new System.EventHandler(this.cbPxx_SelectedIndexChanged);
            // 
            // cbVdc
            // 
            this.cbVdc.BackColor = System.Drawing.Color.Lavender;
            this.cbVdc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbVdc.ItemHeight = 16;
            this.cbVdc.Location = new System.Drawing.Point(184, 24);
            this.cbVdc.MaxDropDownItems = 20;
            this.cbVdc.Name = "cbVdc";
            this.cbVdc.Size = new System.Drawing.Size(72, 24);
            this.cbVdc.TabIndex = 195;
            // 
            // cbIdc
            // 
            this.cbIdc.BackColor = System.Drawing.Color.Lavender;
            this.cbIdc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbIdc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbIdc.ItemHeight = 16;
            this.cbIdc.Location = new System.Drawing.Point(264, 24);
            this.cbIdc.Name = "cbIdc";
            this.cbIdc.Size = new System.Drawing.Size(96, 24);
            this.cbIdc.TabIndex = 197;
            this.cbIdc.SelectedIndexChanged += new System.EventHandler(this.cbIdc_SelectedIndexChanged);
            // 
            // lfrom
            // 
            this.lfrom.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lfrom.ForeColor = System.Drawing.Color.Red;
            this.lfrom.Location = new System.Drawing.Point(16, 80);
            this.lfrom.Name = "lfrom";
            this.lfrom.Size = new System.Drawing.Size(56, 20);
            this.lfrom.TabIndex = 184;
            this.lfrom.Text = "From:";
            this.lfrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbFrom
            // 
            this.cbFrom.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbFrom.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbFrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbFrom.Location = new System.Drawing.Point(80, 80);
            this.cbFrom.Name = "cbFrom";
            this.cbFrom.Size = new System.Drawing.Size(256, 21);
            this.cbFrom.TabIndex = 187;
            this.cbFrom.SelectedIndexChanged += new System.EventHandler(this.cbFrom_SelectedIndexChanged);
            // 
            // tBigTot
            // 
            this.tBigTot.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBigTot.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tBigTot.Location = new System.Drawing.Point(448, 80);
            this.tBigTot.Name = "tBigTot";
            this.tBigTot.Size = new System.Drawing.Size(104, 20);
            this.tBigTot.TabIndex = 186;
            this.tBigTot.Text = "0";
            // 
            // lbgtot
            // 
            this.lbgtot.Font = new System.Drawing.Font("Book Antiqua", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbgtot.ForeColor = System.Drawing.Color.Red;
            this.lbgtot.Location = new System.Drawing.Point(344, 80);
            this.lbgtot.Name = "lbgtot";
            this.lbgtot.Size = new System.Drawing.Size(112, 20);
            this.lbgtot.TabIndex = 185;
            this.lbgtot.Text = "Charger Cost:";
            this.lbgtot.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // opPHS1
            // 
            this.opPHS1.Checked = true;
            this.opPHS1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opPHS1.Location = new System.Drawing.Point(696, 88);
            this.opPHS1.Name = "opPHS1";
            this.opPHS1.Size = new System.Drawing.Size(32, 20);
            this.opPHS1.TabIndex = 188;
            this.opPHS1.TabStop = true;
            this.opPHS1.Text = "1";
            this.opPHS1.CheckedChanged += new System.EventHandler(this.opPHS1_CheckedChanged);
            // 
            // opPHS3
            // 
            this.opPHS3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opPHS3.Location = new System.Drawing.Point(736, 88);
            this.opPHS3.Name = "opPHS3";
            this.opPHS3.Size = new System.Drawing.Size(32, 20);
            this.opPHS3.TabIndex = 189;
            this.opPHS3.Text = "3";
            this.opPHS3.CheckedChanged += new System.EventHandler(this.opPHS3_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Arial Unicode MS", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(624, 88);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 20);
            this.label2.TabIndex = 190;
            this.label2.Text = "PHASE:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pnlALL
            // 
            this.pnlALL.Controls.Add(this.pictureBox3);
            this.pnlALL.Controls.Add(this.LPxx);
            this.pnlALL.Location = new System.Drawing.Point(176, 16);
            this.pnlALL.Name = "pnlALL";
            this.pnlALL.Size = new System.Drawing.Size(504, 56);
            this.pnlALL.TabIndex = 239;
            this.pnlALL.Visible = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.pictureBox3.ForeColor = System.Drawing.Color.Blue;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(424, 8);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(72, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 239;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // LPxx
            // 
            this.LPxx.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.LPxx.Font = new System.Drawing.Font("Century Gothic", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LPxx.Location = new System.Drawing.Point(8, 12);
            this.LPxx.Name = "LPxx";
            this.LPxx.Size = new System.Drawing.Size(408, 32);
            this.LPxx.TabIndex = 238;
            this.LPxx.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.LPxx.TextChanged += new System.EventHandler(this.LPxx_TextChanged);
            this.LPxx.Click += new System.EventHandler(this.LPxx_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(592, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(56, 20);
            this.label1.TabIndex = 178;
            this.label1.Text = "CPTs:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Visible = false;
            // 
            // cbCpts
            // 
            this.cbCpts.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbCpts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCpts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCpts.Location = new System.Drawing.Point(648, 40);
            this.cbCpts.Name = "cbCpts";
            this.cbCpts.Size = new System.Drawing.Size(216, 21);
            this.cbCpts.TabIndex = 179;
            this.cbCpts.Visible = false;
            // 
            // cbTo
            // 
            this.cbTo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.cbTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbTo.Location = new System.Drawing.Point(608, 16);
            this.cbTo.Name = "cbTo";
            this.cbTo.Size = new System.Drawing.Size(272, 21);
            this.cbTo.TabIndex = 169;
            this.cbTo.Visible = false;
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.AutoSize = false;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.ph1,
            this.XL,
            this.chrg1,
            this.Stpl});
            this.toolBar1.ButtonSize = new System.Drawing.Size(50, 36);
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolBar1.ImageList = this.Fst_IL32;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(960, 56);
            this.toolBar1.TabIndex = 8;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // ph1
            // 
            this.ph1.DropDownMenu = this.PHS_COST_mnu;
            this.ph1.ImageIndex = 0;
            this.ph1.Name = "ph1";
            this.ph1.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.ph1.Text = "Re-calculate";
            // 
            // PHS_COST_mnu
            // 
            this.PHS_COST_mnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.Cost_1,
            this.Cost_3});
            // 
            // Cost_1
            // 
            this.Cost_1.Index = 0;
            this.Cost_1.Text = "PHASE 1";
            this.Cost_1.Click += new System.EventHandler(this.Cost_1_Click);
            // 
            // Cost_3
            // 
            this.Cost_3.Index = 1;
            this.Cost_3.Text = "PHASE 3";
            this.Cost_3.Click += new System.EventHandler(this.Cost_3_Click);
            // 
            // XL
            // 
            this.XL.DropDownMenu = this.PHS_XL_mnu;
            this.XL.ImageIndex = 4;
            this.XL.Name = "XL";
            this.XL.Style = System.Windows.Forms.ToolBarButtonStyle.DropDownButton;
            this.XL.Text = "EXCEL FORMAT";
            this.XL.ToolTipText = "export Result to Word File";
            this.XL.Visible = false;
            // 
            // PHS_XL_mnu
            // 
            this.PHS_XL_mnu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.XL_1,
            this.XL_3});
            // 
            // XL_1
            // 
            this.XL_1.Index = 0;
            this.XL_1.Text = "PHASE 1";
            this.XL_1.Click += new System.EventHandler(this.XL_1_Click);
            // 
            // XL_3
            // 
            this.XL_3.Index = 1;
            this.XL_3.Text = "PHASE 3";
            this.XL_3.Click += new System.EventHandler(this.XL_3_Click);
            // 
            // chrg1
            // 
            this.chrg1.ImageIndex = 1;
            this.chrg1.Name = "chrg1";
            this.chrg1.Text = "Display";
            // 
            // Stpl
            // 
            this.Stpl.ImageIndex = 2;
            this.Stpl.Name = "Stpl";
            this.Stpl.Text = "Update Static List Price";
            // 
            // Fst_IL32
            // 
            this.Fst_IL32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Fst_IL32.ImageStream")));
            this.Fst_IL32.TransparentColor = System.Drawing.Color.Transparent;
            this.Fst_IL32.Images.SetKeyName(0, "");
            this.Fst_IL32.Images.SetKeyName(1, "");
            this.Fst_IL32.Images.SetKeyName(2, "");
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.Image = ((System.Drawing.Image)(resources.GetObject("picExit.Image")));
            this.picExit.Location = new System.Drawing.Point(912, 8);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(40, 40);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 201;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // lvQuotes
            // 
            this.lvQuotes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvQuotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.c_CPTREF,
            this.c_5,
            this.c_10,
            this.c_15,
            this.c_20,
            this.c_25,
            this.c_30,
            this.c_35,
            this.c_40,
            this.c_50,
            this.c_60,
            this.c_70,
            this.c_75,
            this.c_80,
            this.c_100,
            this.c_125,
            this.c_150,
            this.c_175,
            this.c_200,
            this.c_225,
            this.c_250,
            this.c_275,
            this.c_300,
            this.c_325,
            this.c_350,
            this.c_375,
            this.c_400,
            this.c_500,
            this.c_600,
            this.c_750,
            this.c_800,
            this.c_900,
            this.c_1000,
            this.crec,
            this.linID});
            this.lvQuotes.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvQuotes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lvQuotes.FullRowSelect = true;
            this.lvQuotes.GridLines = true;
            this.lvQuotes.Location = new System.Drawing.Point(0, 144);
            this.lvQuotes.Name = "lvQuotes";
            this.lvQuotes.Size = new System.Drawing.Size(960, 512);
            this.lvQuotes.TabIndex = 203;
            this.lvQuotes.UseCompatibleStateImageBehavior = false;
            this.lvQuotes.View = System.Windows.Forms.View.Details;
            this.lvQuotes.Visible = false;
            this.lvQuotes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvQuotes_ColumnClick);
            this.lvQuotes.SelectedIndexChanged += new System.EventHandler(this.lvQuotes_SelectedIndexChanged);
            // 
            // c_CPTREF
            // 
            this.c_CPTREF.Text = "Component REF";
            this.c_CPTREF.Width = 152;
            // 
            // c_5
            // 
            this.c_5.Text = "5 Amp";
            this.c_5.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_5.Width = 70;
            // 
            // c_10
            // 
            this.c_10.Text = "10 Amp";
            this.c_10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_10.Width = 70;
            // 
            // c_15
            // 
            this.c_15.Text = "15 Amp";
            this.c_15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_15.Width = 70;
            // 
            // c_20
            // 
            this.c_20.Text = "20 Amp";
            this.c_20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_20.Width = 70;
            // 
            // c_25
            // 
            this.c_25.Text = "25 Amp";
            this.c_25.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_25.Width = 70;
            // 
            // c_30
            // 
            this.c_30.Text = "30 Amp";
            this.c_30.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_30.Width = 70;
            // 
            // c_35
            // 
            this.c_35.Text = "35 Amp";
            this.c_35.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_35.Width = 70;
            // 
            // c_40
            // 
            this.c_40.Text = "40 Amp";
            this.c_40.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_40.Width = 70;
            // 
            // c_50
            // 
            this.c_50.Text = "50 Amp";
            this.c_50.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_50.Width = 70;
            // 
            // c_60
            // 
            this.c_60.Text = "60 Amp";
            this.c_60.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_60.Width = 70;
            // 
            // c_70
            // 
            this.c_70.Text = "70 Amper";
            this.c_70.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_70.Width = 70;
            // 
            // c_75
            // 
            this.c_75.Text = "75 Amp";
            this.c_75.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_75.Width = 70;
            // 
            // c_80
            // 
            this.c_80.Text = "80 Amp";
            this.c_80.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_80.Width = 70;
            // 
            // c_100
            // 
            this.c_100.Text = "100 Amp";
            this.c_100.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_100.Width = 70;
            // 
            // c_125
            // 
            this.c_125.Text = "125 Ampr";
            this.c_125.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_125.Width = 70;
            // 
            // c_150
            // 
            this.c_150.Text = "150 Amp";
            this.c_150.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_150.Width = 70;
            // 
            // c_175
            // 
            this.c_175.Text = "175 Amp";
            this.c_175.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_175.Width = 70;
            // 
            // c_200
            // 
            this.c_200.Text = "200 Amp";
            this.c_200.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_200.Width = 70;
            // 
            // c_225
            // 
            this.c_225.Text = "225 Amp";
            this.c_225.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_225.Width = 70;
            // 
            // c_250
            // 
            this.c_250.Text = "250 Amp";
            this.c_250.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_250.Width = 70;
            // 
            // c_275
            // 
            this.c_275.Text = "275 Amp";
            this.c_275.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_275.Width = 70;
            // 
            // c_300
            // 
            this.c_300.Text = "300 Amp";
            this.c_300.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_300.Width = 70;
            // 
            // c_325
            // 
            this.c_325.Text = "325 Amp";
            this.c_325.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_325.Width = 70;
            // 
            // c_350
            // 
            this.c_350.Text = "350 Amp";
            this.c_350.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_350.Width = 70;
            // 
            // c_375
            // 
            this.c_375.Text = "375 Amp";
            this.c_375.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_375.Width = 70;
            // 
            // c_400
            // 
            this.c_400.Text = "400 Amp";
            this.c_400.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_400.Width = 70;
            // 
            // c_500
            // 
            this.c_500.Text = "500 Amp";
            this.c_500.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_500.Width = 70;
            // 
            // c_600
            // 
            this.c_600.Text = "600 Amp";
            this.c_600.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_600.Width = 70;
            // 
            // c_750
            // 
            this.c_750.Text = "750 Amp";
            this.c_750.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_750.Width = 70;
            // 
            // c_800
            // 
            this.c_800.Text = "800 Amp";
            this.c_800.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_800.Width = 70;
            // 
            // c_900
            // 
            this.c_900.Text = "900 Amp";
            this.c_900.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_900.Width = 70;
            // 
            // c_1000
            // 
            this.c_1000.Text = "1000 Amp";
            this.c_1000.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.c_1000.Width = 70;
            // 
            // crec
            // 
            this.crec.Text = "";
            this.crec.Width = 0;
            // 
            // linID
            // 
            this.linID.Text = "";
            this.linID.Width = 0;
            // 
            // ChargerCOST
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(960, 658);
            this.Controls.Add(this.lvQuotes);
            this.Controls.Add(this.grpfind);
            this.Controls.Add(this.picExit);
            this.Controls.Add(this.toolBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "ChargerCOST";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Charger COST";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closed += new System.EventHandler(this.ChargerCOST_Closed);
            this.Load += new System.EventHandler(this.Stati_Load);
            this.Resize += new System.EventHandler(this.Stati_Resize);
            this.grpfind.ResumeLayout(false);
            this.pnlone.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlALL.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

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
						cbIdc.Items.Add( "ALL");
						break;
				}
				SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
				OConn.Open ();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql ;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();
				while (Oreadr.Read ())
				{
					switch (s_cb[i]) 
					{
						case 'c':
							if (Oreadr["VALUE1"].ToString().Substring(0,5)!= "P4000")   cbPxx.Items.Add( Oreadr["VALUE1"].ToString()  ); 
							break;
						case 'v':  
							cbVdc.Items.Add( Oreadr["VALUE1"].ToString()  ); 
							break;
						case 'i':  
							cbIdc.Items.Add( Oreadr["VALUE1"].ToString()  ); 
							cbIDCto.Items.Add( Oreadr["VALUE1"].ToString()  ); 
							break;
					}
				  
				}
				OConn.Close(); 
			}
		}
		public void disp_trace(string trace)
		{
			LPxx.Text = trace;
		}
		public void endTHRmsg(string msg)
		{
			LPxx.Text = msg;
		}

	
		private void lvQuotes_ColumnClickOLD(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			//MessageBox.Show (   e.Column.ToString()  );

			//	btnseek.Text = "Search by:    " + lvQuotes.Columns[e.Column].Text ; 
			seelCol=e.Column; 
			ListView myListView = (ListView)sender;

			// Determine if clicked column is already the column that is being sorted.
			if ( e.Column == lvSorter.SortColumn )
			{
				// Reverse the current sort direction for this column.
				if (lvSorter.Order == System.Windows.Forms.SortOrder.Ascending )
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
				//	lvSorter.Order = SortOrder.Ascending; old

				lvSorter.Order = (srtType=='A') ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
				srtType=(srtType=='A') ? 'D' : 'A';
				lvSorter.SortColumn = e.Column;
			}

			// Perform the sort with these new sort options.
			myListView.Sort();
			oldSC=lvSorter.SortColumn;
			lvSorter.SortColumn =0;



			
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




	


	

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			this.Cursor =Cursors.WaitCursor ; 
			
			switch (toolBar1.Buttons.IndexOf(e.Button))    
			{

				case 2:
					pnlALL.Visible =false;
					pnlone.Visible =true;
					lvQuotes.Visible =true; 
					break;
				case 3:
					pnlALL.Visible =true;
					pnlone.Visible =false;
					lvQuotes.Visible =false; 
					break;
	
			}
			this.Cursor =Cursors.Default  ; 
			pictureBox3.Visible =false; 
			//timer1.Enabled =false;
		}
		private void picExit_Click(object sender, System.EventArgs e)
		{
			StopP45xx();
			this.Hide();
		}



		private void Stati_Resize(object sender, System.EventArgs e)
		{
			picExit.Left = this.Width -48;
			//tBigTot.Left = grpTot.Width - 184;  //144
		//	lbgtot.Left = grpTot.Width - 304 ;//344;   //200
			lvQuotes.Height =this.Height - 152 - 80 ;  //136 
			//	lvProj.Height =this.Height - 152 - 80 ;
			Math.Ceiling(15.25);
		}

		private void btnCHNGCmpny_Click(object sender, System.EventArgs e)
		{
		
		}

		

		private void fill_FROM_TO()
		{
			string phs=(opPHS1.Checked) ? "1" :"3";  
			string stSql = " SELECT     charger + '-" + phs + "-' + vdc + '-' + idc AS CHRef " +
				" FROM   TBLAVAIL"+ phs + " WHERE     (charger = 'P4500') " +
				" ORDER BY charger, CAST(vdc AS float), CAST(idc AS float)";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			cbFrom.Items.Clear();
			cbTo.Items.Clear();
			while (Oreadr.Read ())
			{
				cbFrom.Items.Add( Oreadr["CHRef"].ToString()  ); 
				cbTo.Items.Add( Oreadr["CHRef"].ToString()  ); 
			}
			if (cbFrom.Items.Count >0) 	cbFrom.Text = cbFrom.Items[0].ToString() ; 
			if (cbTo.Items.Count >0) cbTo.Text = cbTo.Items[0].ToString (); 
			OConn.Close(); 
				 
		}

	

	
		private void fill_CPT()
		{
			string stSql = "select COMPONENT_REF  FROM COMPNT_LIST where Compnt_Type='E' OR Compnt_Type='C'";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			cbCpts.Items.Add("ALL");
			while (Oreadr.Read ())
			{
				cbCpts.Items.Add( Oreadr["COMPONENT_REF"].ToString() );  //employee
			}
			OConn.Close(); 
				 
		}

	

		private void Stati_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!"; 
			MainMDI.Write_Whodo_SSetup("Statistics",'I');
		
		}

		private void lvProj_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{

			seelCol=e.Column; 
			ListView myListView = (ListView)sender;

			// Determine if clicked column is already the column that is being sorted.
			if ( e.Column == lvSorterProj.SortColumn )
			{
				// Reverse the current sort direction for this column.
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
				// Set the column number that is to be sorted; default to ascending.
				//lvSorter.SortColumn = e.Column; old
				//	lvSorter.Order = SortOrder.Ascending; old

				lvSorterProj.Order = (srtType=='A') ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
				srtType=(srtType=='A') ? 'D' : 'A';
				lvSorterProj.SortColumn = e.Column;
			}

			// Perform the sort with these new sort options.
			myListView.Sort();
			oldSC=lvSorterProj.SortColumn;
			lvSorterProj.SortColumn =0;



		
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
	
			
		
		//	lProjNB.Text ="";
		//	lSucc.Text ="";
		//	lNBQ.Text ="";
			//lAvrg.Text ="";
			tBigTot.Text ="";
		//	grpTot.Refresh (); 
		}

		private void opPHS1_CheckedChanged(object sender, System.EventArgs e)
		{
			fill_FROM_TO(); 
		}

		private void opPHS3_CheckedChanged(object sender, System.EventArgs e)
		{
			fill_FROM_TO(); 
		}
		private void Cal_ALL_CHRG_COST13old()
		{
			
			for (int p=1;p<4;p+=2)                         //For p = 1 To 3 Step 2
			{
				string stSql = " SELECT     charger, vdc, idc  " +
					" FROM   TBLAVAIL"+ p + " WHERE     (charger = 'P4500') " +
					" ORDER BY charger, CAST(vdc AS float), CAST(idc AS float)";
				SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
				OConn.Open ();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql ;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();
				MainMDI.ExecSql("delete CHARGERS_COST0"+p  );
				while (Oreadr.Read ())
				{
					
					CHARGER_COST( Oreadr["charger"].ToString().Substring(0,5),p.ToString(),Oreadr["vdc"].ToString(),Oreadr["IDC"].ToString()); 
					LPxx.Text = Oreadr["charger"].ToString()+"-" + p +"-" + Oreadr["vdc"].ToString() +"-" + Oreadr["IDC"].ToString();
				    LPxx.Refresh ();
					this.Refresh ();
					
					
				}

				OConn.Close(); 
			}
		}
		private void Cal_ALL_CHRG_COST13bad(int p)
		{
		//	timer1.Enabled =true;
			
				string stSql = " SELECT     charger, vdc, idc  " +
					" FROM   TBLAVAIL"+ p + " WHERE     (charger = 'P4500') " +
					" ORDER BY charger, CAST(vdc AS float), CAST(idc AS float)";
				SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
				OConn.Open ();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql ;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();
			    MainMDI.ExecSql("delete CHARGERS_COST0"+p  );
			   // MessageBox.Show("Count= " +Oreadr.FieldCount.ToString()); 
				while (Oreadr.Read ())
				{
					
					CHARGER_COST( Oreadr["charger"].ToString().Substring(0,5),p.ToString(),Oreadr["vdc"].ToString(),Oreadr["IDC"].ToString()); 
			//		LPxx.Text = Oreadr["charger"].ToString()+"-" + p +"-" + Oreadr["vdc"].ToString() +"-" + Oreadr["IDC"].ToString();
			//		LPxx.Refresh ();
			//		this.Refresh ();
				}

				OConn.Close(); 
			
			
		}

		private void picdisp_Click(object sender, System.EventArgs e)
		{
	
            StopP45xx();
			pictureBox3.Visible =false;
		   
		}
		private void P45xx_cost()
		{

			ChargerCOST_P45xx P45xx = new ChargerCOST_P45xx(m_EventStopThread ,m_EventThreadStopped ,this);
			P45xx.Cal_ALL_CHRG_COST13(curr_PHS );   
		}
		private void P45xx_XL()
		{

			ChargerCOST_P45xx P45xx = new ChargerCOST_P45xx(m_EventStopThread ,m_EventThreadStopped ,this);
			P45xx.XL_ALL_CHRGR13 (curr_PHS );   
		}

		private void dec_CHREF(string tt, ref string[] ar_T)
		{
	  
			//string[] ar_T=new string[4];
			int i=0;
			int ipos=0;
			while (tt.Length >0)
			{
				ipos=tt.IndexOf("-");
				if (ipos >-1)
				{
					ar_T [i++] =tt.Substring(0,ipos);
					tt=tt.Substring(ipos+1,tt.Length - (ipos +1));
				}
				else
				{   
					ar_T[i++]=tt;
					tt="";
				}
			}
	//		t1=ar_T[0];
	//		t2=ar_T[1];
	//		t3=ar_T[2];
	//		t4=ar_T[3];
			
		}
	

		private void CHARGER_COST(string Pxx, string PHS, string V, string I)
		{
            

			
			string stSql = "select * from COMPNT_LIST where Compnt_Type <>'S'  order by Component_ID";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			CHRGR  =new Charger(0 ,"0" , Pxx  ,PHS,V ,I,"0","0" );
			MainMDI.ExecSql("delete CHARGERS_COST0"+PHS );
			while (Oreadr.Read ())
			{
				CPT_COST( Convert.ToInt32(Oreadr["Component_ID"].ToString()),Charger.AvailId,PHS,'F');
				
			}
		//	tBigTot.Text = CH_COST.ToString();

               
		}
		private void CHARGER_COST(string chRef)
		{
            

            string[] arr_PxxPVI= new string[5];
		//	string stSql = "select * from COMPNT_LIST where Compnt_Type='E' or Compnt_Type='D' or Compnt_Type='C'   order by Component_ID";
			string stSql = "select * from COMPNT_LIST where Compnt_Type<>'S'   order by Component_ID";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			lvQuotes.Items.Clear ();
			dec_CHREF(cbFrom.Text ,ref arr_PxxPVI);
			CH_COST=0;
			CHRGR  =new Charger(0 ,"0" , cbFrom.Text.Substring(0,5)  ,arr_PxxPVI[1],arr_PxxPVI[2] ,arr_PxxPVI[3],"0","0" );
			while (Oreadr.Read ())
			{
				CPT_COST( Convert.ToInt32(Oreadr["Component_ID"].ToString()),Charger.AvailId,arr_PxxPVI[1]); 
				
			}
			tBigTot.Text = CH_COST.ToString();

               
		}

		public void CPT_COST(long dccompnt,long availID,string P)
		{
			

			string stSql= "SELECT TBLAVAIL" + P + ".Avail_ID, COMPNT_LIST.Component_ID,COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + P + ".charger, TBLAVAIL" + P + ".vdc, TBLAVAIL" + P +  ".idc, link_COMPNT_AVAIL.Qty, " +
				" COMPNT_LIST.* " +
				" FROM (TBLAVAIL" + P +  " INNER JOIN link_COMPNT_AVAIL ON TBLAVAIL" + P +  ".Avail_ID = link_COMPNT_AVAIL.Avail_ID) INNER JOIN COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = COMPNT_LIST.Component_ID " +
				" Where (((link_COMPNT_AVAIL.phs) = '" + P +  "') and ((link_COMPNT_AVAIL.Avail_ID) = " + availID +  ") and ((link_COMPNT_AVAIL.Compnt_ID) = " + dccompnt + ")) ORDER BY TBLAVAIL" + P +  ".Avail_ID, COMPNT_LIST.Component_ID" ;
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			
			if (Oreadr.HasRows)
			{
				while (Oreadr.Read ())
				{
					Cpt  =new Component();

					Cpt.Cal_chrg_CostADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()),"C"); 
					if (Cpt.G_PRICE != Charger.VIDE )
					{
						ListViewItem lvI= lvQuotes.Items.Add(Oreadr["COMPONENT_REF"].ToString() );
						lvI.SubItems.Add(Oreadr["CatName1"].ToString()); 
						lvI.SubItems.Add(Cpt.CAP1); 
						lvI.SubItems.Add(Oreadr["CatName2"].ToString()); 
						lvI.SubItems.Add(Cpt.CAP2); 
						lvI.SubItems.Add(Oreadr["CatName3"].ToString()); 
						lvI.SubItems.Add(Cpt.CAP3); 
						lvI.SubItems.Add(Cpt.Real_QTY ); 
						lvI.SubItems.Add(MainMDI.Curr_FRMT(Cpt.G_PRICE)   ); 
						CH_COST+=Tools.Conv_Dbl(Cpt.G_PRICE) ; 

					}
				}
				
			}
			else
			{
				//MessageBox.Show ("No Component is Available....(Availability)...cpt="+dccompnt);
				Cpt.G_Desc =Charger.VIDE;
				Cpt.G_PRICE =Charger.VIDE;

			}
			OConn.Close (); 

		}

		public void CPT_COST(long dccompnt,long availID,string P, char Cd)
		{
           
			string stSql= "SELECT TBLAVAIL" + P + ".Avail_ID, COMPNT_LIST.Component_ID,COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + P + ".charger, TBLAVAIL" + P + ".vdc, TBLAVAIL" + P +  ".idc, link_COMPNT_AVAIL.Qty, " +
				" COMPNT_LIST.* " +
				" FROM (TBLAVAIL" + P +  " INNER JOIN link_COMPNT_AVAIL ON TBLAVAIL" + P +  ".Avail_ID = link_COMPNT_AVAIL.Avail_ID) INNER JOIN COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = COMPNT_LIST.Component_ID " +
				" Where (((link_COMPNT_AVAIL.phs) = '" + P +  "') and ((link_COMPNT_AVAIL.Avail_ID) = " + availID +  ") and ((link_COMPNT_AVAIL.Compnt_ID) = " + dccompnt + ")) ORDER BY TBLAVAIL" + P +  ".Avail_ID, COMPNT_LIST.Component_ID" ;
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			
			if (Oreadr.HasRows)
			{
				while (Oreadr.Read ())
				{
					Cpt  =new Component();

					Cpt.Cal_chrg_CostADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()),"C"); 
					if (Cpt.G_PRICE != Charger.VIDE )
					{
						if (Cd=='D')
						{
							ListViewItem lvI= lvQuotes.Items.Add(Oreadr["COMPONENT_REF"].ToString() );
							lvI.SubItems.Add(Oreadr["CatName1"].ToString()); 
							lvI.SubItems.Add(Cpt.CAP1); 
							lvI.SubItems.Add(Oreadr["CatName2"].ToString()); 
							lvI.SubItems.Add(Cpt.CAP2); 
							lvI.SubItems.Add(Oreadr["CatName3"].ToString()); 
							lvI.SubItems.Add(Cpt.CAP3); 
							lvI.SubItems.Add(Cpt.Real_QTY ); 
							lvI.SubItems.Add(MainMDI.Curr_FRMT(Cpt.G_PRICE)   ); 
							CH_COST+=Tools.Conv_Dbl(Cpt.G_PRICE) ; 
						}
						else 
						{
							string c1=(Oreadr["Compnt_Type"].ToString()=="%")? "0" : Cpt.CAP1;
							string c2=(Oreadr["Compnt_Type"].ToString()=="%")? "0" : Cpt.CAP2;
							string c3=(Oreadr["Compnt_Type"].ToString()=="%")? "0" : Cpt.CAP3;
							 stSql="INSERT INTO CHARGERS_COST0" + P + " ([Avail_ID],[Compnt_ID],[Cap1],[Cap2], " + 
								" [Cap3],[Real_QTY],[COST],[cost_type]) VALUES ('" +
								Oreadr["Avail_id"].ToString()    + "', '" +
								Oreadr["Component_ID"].ToString()     + "', '" +
								c1 + "', '" +c2 + "', '" + c3 + "', '" +
								Cpt.Real_QTY     + "', '" + Cpt.G_PRICE    + "', '" +
								Oreadr["Compnt_Type"].ToString()     + "')";
							MainMDI.ExecSql(stSql);
						}

					}
				}
			}
			else
			{
				//MessageBox.Show ("No Component is Available....(Availability)...cpt="+dccompnt);
				Cpt.G_Desc =Charger.VIDE;
				Cpt.G_PRICE =Charger.VIDE;
			}
			OConn.Close (); 

		}
		private void fill_ALL_IDC_Cost(string Idc )
		{
			bool colW_fixed=false;
			int XL_Fldcount=MainMDI.Find_Flds_Count("select * from SIM_TBLTOXL0"+cbPhs.Text   ); 
			string stSql=" SELECT  * FROM SIM_TBLTOXL0" + cbPhs.Text + 
				" WHERE (REF_CHRG = '" +cbPxx.Text+"-" +  cbVdc.Text  + "' AND cRec <> 'L') " +
				"   ORDER BY LineID ";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			lvQuotes.Items.Clear(); 
			while (Oreadr.Read ())
			{
				if (!chk_tecV.Checked  && Oreadr["cRec"].ToString()=="V") continue;
				else
				{
					ListViewItem lvI= lvQuotes.Items.Add(Oreadr["COMPONENT"].ToString() );
					for (int i=1;i<=XL_Fldcount - 4;i++)
					{
						string st=(Oreadr["cRec"].ToString()=="V") ?Oreadr[i].ToString():"$"+MainMDI.A00(Oreadr[i].ToString());
						lvI.SubItems.Add(st); 
						if (!colW_fixed)
						{
							lvQuotes.Columns[i].Width = width_col(Oreadr.GetName(i));   
							
						}
					}
					colW_fixed=true;
					lvI.SubItems.Add(Oreadr["cRec"].ToString());
					lvI.SubItems.Add(Oreadr["LineID"].ToString());
					if (Oreadr["cRec"].ToString()=="T") lvI.BackColor = Color.AntiqueWhite ;
					if (Oreadr["cRec"].ToString()=="C" || Oreadr["cRec"].ToString()=="T") lvI.ForeColor  = Color.Blue ;
					
				}
			}

		
		}
	      


		private int width_col(string IdcName)
		{
            int WDT=0;
			bool debut=false;
			if (cbIdc.Text.ToUpper()  =="ALL") WDT =70;
			else  
			{
				for (int i=1;i< cbIdc.Items.Count ;i++)  //i=1 because ALL=0
				{
					if (!debut) debut =(cbIdc.Items[i].ToString()==cbIdc.Text );
					if (debut)
					{
						if (cbIdc.Items[i].ToString() == IdcName)
						{
							WDT=70;
							break;
						}
						if ( cbIdc.Items[i].ToString()  == cbIDCto.Text ) break;
					}
				}
			}
			return WDT;
		}

		private void cbIdc_SelectedIndexChanged(object sender, System.EventArgs e)
		{
          //  MessageBox.Show(cbIdc.SelectedIte .ToString());  

			if (cbIdc.Text =="ALL") 
			{
				lcbTo.Visible =false;
				lidc2.Visible =false;
				cbIDCto.Visible =false;
 
			}
			else
			{
				lcbTo.Visible =true;
				cbIDCto.Visible =true;
				lidc2.Visible=true;
				cbIDCto.Text = cbIdc.Text ;  
			}
		}


	
		private void cbFrom_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		//	CHARGER_COST(cbFrom.Text );
		     
		}

	
		private void StopP45xx()
		{
			if ( m_WkTHRD != null  &&  m_WkTHRD.IsAlive )  // thread is active
			{
				// set event "Stop"
				m_EventStopThread.Set();

				// wait when thread  will stop or finish
				while (m_WkTHRD.IsAlive)
				{
					// We cannot use here infinite wait because our thread
					// makes syncronous calls to main form, this will cause deadlock.
					// Instead of this we wait for event some appropriate time
					// (and by the way give time to worker thread) and
					// process events. These events may contain Invoke calls.
					if ( WaitHandle.WaitAll((new ManualResetEvent[] {m_EventThreadStopped}),100,true) ) break;
					Application.DoEvents();
				}
			}

			
		}

		private void ChargerCOST_Closed(object sender, System.EventArgs e)
		{
			StopP45xx();
		}

		private void LPxx_Click(object sender, System.EventArgs e)
		{
		
		}

		private void LPxx_TextChanged(object sender, System.EventArgs e)
		{
			pnlALL.Visible =true;
			pictureBox3.Visible =  (LPxx.Text.IndexOf("P4500") >-1);
		}

		private void pictureBox3_Click(object sender, System.EventArgs e)
		{
			StopP45xx();
			pictureBox3.Visible =false;
		}


		private void mnu_COST(char Phs)
		{
	//		pnlALL.Visible =true;
			pictureBox3.Visible =true;
			pnlone.Visible =false;
			lvQuotes.Visible =false;
			curr_PHS =  Phs; // (toolBar1.Buttons.IndexOf(e.Button)==1) ?  '1': '3';
			m_EventStopThread.Reset();
			m_EventThreadStopped.Reset();
			m_WkTHRD = new Thread(new ThreadStart(this.P45xx_cost));
			m_WkTHRD.Start();
			//	m_WorkerThread.Name = "Worker Thread Sample";	// looks nice in Output window
			
		}
		private void mnu_XL(char Phs)
		{
		//	pnlALL.Visible =true;
			pictureBox3.Visible =true;
			pnlone.Visible =false;
			lvQuotes.Visible =false;
			curr_PHS =  Phs; // (toolBar1.Buttons.IndexOf(e.Button)==1) ?  '1': '3';
			m_EventStopThread.Reset();
			m_EventThreadStopped.Reset();
			m_WkTHRD = new Thread(new ThreadStart(this.P45xx_XL ));
			m_WkTHRD.Start();
			//	m_WorkerThread.Name = "Worker Thread Sample";	// looks nice in Output window
			
		}


	

		private void XL_1_Click(object sender, System.EventArgs e)
		{
			mnu_XL('1'); 
		}

		private void XL_3_Click(object sender, System.EventArgs e)
		{
		   mnu_XL('3'); 
		}

		private void Cost_1_Click(object sender, System.EventArgs e)
		{
		   mnu_COST('1');
		 //  mnu_XL('1'); its starting is included in mnu_COST
		}

		private void Cost_3_Click(object sender, System.EventArgs e)
		{
		   mnu_COST('3');
		 //  mnu_XL('3'); 
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
			  
			   fill_ALL_IDC_Cost(cbIdc.Text );  
		}

		private void lvQuotes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lvQuotes_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			lvQuotes.Columns[33].Width =70;
			lvQuotes.Columns[34].Width =70;
  
		}

        private void cbPxx_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

	

	

	

	

	

/*
		private void Rien(string m_vdcMax,string m_Vac)
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
					CHRGR  =new Charger(0 ,lFV.Text , cbPxx.Text.Substring(0,5)  ,cbPhs.Text ,cbVdc.Text ,cbIdc.Text,tVac.Text,tVdcMax.Text );
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
		*/




   


	}
}
