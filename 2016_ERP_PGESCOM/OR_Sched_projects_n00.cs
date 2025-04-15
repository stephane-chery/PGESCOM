using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb ;  
using System.Data.SqlClient ;
using Excel = Microsoft.Office.Interop.Excel;
using EAHLibs;
using System.IO;


namespace PGESCOM
{
	/// <summary>
	/// Summary description for OR_ToSched.
	/// </summary>
	public class OR_Sched_projects_N00 : System.Windows.Forms.Form
    {
       //local var
        private Lib1 Tools = new Lib1();
        string LcurConflid="",in_IRRevID = "", in_RID = "",in_CSTMR="",  SN = "", cur_CFTVA = "", DLVRD = "", lcurConfNm = "", lCFLID="", st_Editable="";
        int LcurConfndx = -1, OLDTVConf_Selndx = -1, tsk_cur_ndx = -1, tsk_old_ndx = -1;
        string[,] arr_Tasks = new string[MainMDI.MAX_SC_TASKS , 5];
        string[,] arr_Tskscopy = new string[20, 3];
        private int oldSC = 0,OLDcol=-1,CURcol=-1;
        
        //virtual ListView
        private ListViewItem[] LVcash;
        private string[,] arr_cash_VL, arr_cash_TG;
      
        private ListViewColumnSorter lvSorter = null;
        private char srtType = 'A';
        private int ndxCLRD = -1;
        private int seelCol = 0;
        private string seekColNm;
        //local var

        // columnheaders for lvallproj

       //

        private ImageList imageList16;
        private GroupBox grpACF;
        //   public ListView lvAllProjects;
        private ToolStrip toolStrip1;
        private ToolStripButton XLxport;
        private ToolStripSeparator hhh;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel PBWait;
       // private ColumnHeader Cntr;
        private IContainer components;
        private ed_LVmodif lvAllProjects;
        private ColumnHeader ch0;
        private ColumnHeader ch1;
        private ColumnHeader ch2;
        private ColumnHeader ch3;
        private ColumnHeader ch4;
        private ColumnHeader ch5;
        private ColumnHeader ch6;
        private ColumnHeader ch7;
        private ColumnHeader ch8;
        private ColumnHeader ch9;
        private ColumnHeader ch10;
        private ColumnHeader ch11;
        private ColumnHeader ch12;
        private ColumnHeader ch13;
        private ColumnHeader ch14;
        private ColumnHeader ch15;
        private ColumnHeader ch16;
        private ColumnHeader ch17;
        private ColumnHeader ch18;
        private ColumnHeader ch19;
        private ColumnHeader ch20;
        private GroupBox grpPRCT;
        private ToolStripButton sav;
        private ToolStripProgressBar TSpbar;
        private Label label1;
        private PictureBox picPastVEB;
        private ToolStripButton edit;
        private TextBox tpct;
        private Label lprct;
        private GroupBox grpPRCTS;
        private GroupBox grpVEB;
        private TextBox txVEB;
        private Label lVEB;
        private PictureBox picPastpct;
        private ToolStripButton _exit;
        private Label ldeb;
        private Label lfin;
        private Label lII;
        private int in_affcod;

        public OR_Sched_projects_N00(int x_affcod)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            in_affcod = x_affcod;
            init_CHnn();
            lvSorter = new ListViewColumnSorter();
            this.lvAllProjects.ListViewItemSorter = lvSorter;
            lvAllProjects.AutoArrange = true;
            lvSorter.SortColumn = 0;
            lvSorter.Order = System.Windows.Forms.SortOrder.Descending;
       //     ColName(0);
       //     seelCol = 0;
            
         



      //      in_IRRevID = x_IRRevID;
      //      in_RID = x_RID ;
      //      in_CSTMR = x_CSTMR;
       //     fill_TVConfig();
      //     fill_TVConfigBIG(); 
         //   load_ALLCFs();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OR_Sched_projects_N00));
            this.imageList16 = new System.Windows.Forms.ImageList(this.components);
            this.grpACF = new System.Windows.Forms.GroupBox();
            this.lII = new System.Windows.Forms.Label();
            this.ldeb = new System.Windows.Forms.Label();
            this.lfin = new System.Windows.Forms.Label();
            this.grpPRCT = new System.Windows.Forms.GroupBox();
            this.grpPRCTS = new System.Windows.Forms.GroupBox();
            this.picPastpct = new System.Windows.Forms.PictureBox();
            this.tpct = new System.Windows.Forms.TextBox();
            this.lprct = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.grpVEB = new System.Windows.Forms.GroupBox();
            this.txVEB = new System.Windows.Forms.TextBox();
            this.picPastVEB = new System.Windows.Forms.PictureBox();
            this.lVEB = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.edit = new System.Windows.Forms.ToolStripButton();
            this.sav = new System.Windows.Forms.ToolStripButton();
            this.XLxport = new System.Windows.Forms.ToolStripButton();
            this._exit = new System.Windows.Forms.ToolStripButton();
            this.hhh = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PBWait = new System.Windows.Forms.ToolStripLabel();
            this.TSpbar = new System.Windows.Forms.ToolStripProgressBar();
            this.lvAllProjects = new PGESCOM.ed_LVmodif();
            this.ch0 = new System.Windows.Forms.ColumnHeader();
            this.ch1 = new System.Windows.Forms.ColumnHeader();
            this.ch2 = new System.Windows.Forms.ColumnHeader();
            this.ch3 = new System.Windows.Forms.ColumnHeader();
            this.ch4 = new System.Windows.Forms.ColumnHeader();
            this.ch5 = new System.Windows.Forms.ColumnHeader();
            this.ch6 = new System.Windows.Forms.ColumnHeader();
            this.ch7 = new System.Windows.Forms.ColumnHeader();
            this.ch8 = new System.Windows.Forms.ColumnHeader();
            this.ch9 = new System.Windows.Forms.ColumnHeader();
            this.ch10 = new System.Windows.Forms.ColumnHeader();
            this.ch11 = new System.Windows.Forms.ColumnHeader();
            this.ch12 = new System.Windows.Forms.ColumnHeader();
            this.ch13 = new System.Windows.Forms.ColumnHeader();
            this.ch14 = new System.Windows.Forms.ColumnHeader();
            this.ch15 = new System.Windows.Forms.ColumnHeader();
            this.ch16 = new System.Windows.Forms.ColumnHeader();
            this.ch17 = new System.Windows.Forms.ColumnHeader();
            this.ch18 = new System.Windows.Forms.ColumnHeader();
            this.ch19 = new System.Windows.Forms.ColumnHeader();
            this.ch20 = new System.Windows.Forms.ColumnHeader();
            this.grpACF.SuspendLayout();
            this.grpPRCT.SuspendLayout();
            this.grpPRCTS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPastpct)).BeginInit();
            this.grpVEB.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPastVEB)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
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
            // grpACF
            // 
            this.grpACF.Controls.Add(this.lII);
            this.grpACF.Controls.Add(this.ldeb);
            this.grpACF.Controls.Add(this.lfin);
            this.grpACF.Controls.Add(this.lvAllProjects);
            this.grpACF.Controls.Add(this.grpPRCT);
            this.grpACF.Controls.Add(this.toolStrip1);
            this.grpACF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpACF.Location = new System.Drawing.Point(0, 0);
            this.grpACF.Name = "grpACF";
            this.grpACF.Size = new System.Drawing.Size(892, 565);
            this.grpACF.TabIndex = 254;
            this.grpACF.TabStop = false;
            this.grpACF.Enter += new System.EventHandler(this.grpACF_Enter);
            // 
            // lII
            // 
            this.lII.BackColor = System.Drawing.Color.Yellow;
            this.lII.ForeColor = System.Drawing.Color.Black;
            this.lII.Location = new System.Drawing.Point(726, 28);
            this.lII.Name = "lII";
            this.lII.Size = new System.Drawing.Size(72, 23);
            this.lII.TabIndex = 262;
            // 
            // ldeb
            // 
            this.ldeb.BackColor = System.Drawing.Color.ForestGreen;
            this.ldeb.ForeColor = System.Drawing.Color.White;
            this.ldeb.Location = new System.Drawing.Point(648, 28);
            this.ldeb.Name = "ldeb";
            this.ldeb.Size = new System.Drawing.Size(72, 23);
            this.ldeb.TabIndex = 261;
            // 
            // lfin
            // 
            this.lfin.BackColor = System.Drawing.Color.Blue;
            this.lfin.ForeColor = System.Drawing.Color.White;
            this.lfin.Location = new System.Drawing.Point(804, 28);
            this.lfin.Name = "lfin";
            this.lfin.Size = new System.Drawing.Size(82, 23);
            this.lfin.TabIndex = 260;
            // 
            // grpPRCT
            // 
            this.grpPRCT.Controls.Add(this.grpPRCTS);
            this.grpPRCT.Controls.Add(this.grpVEB);
            this.grpPRCT.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPRCT.Location = new System.Drawing.Point(3, 68);
            this.grpPRCT.Name = "grpPRCT";
            this.grpPRCT.Size = new System.Drawing.Size(886, 62);
            this.grpPRCT.TabIndex = 258;
            this.grpPRCT.TabStop = false;
            this.grpPRCT.Visible = false;
            // 
            // grpPRCTS
            // 
            this.grpPRCTS.Controls.Add(this.picPastpct);
            this.grpPRCTS.Controls.Add(this.tpct);
            this.grpPRCTS.Controls.Add(this.lprct);
            this.grpPRCTS.Controls.Add(this.label1);
            this.grpPRCTS.Location = new System.Drawing.Point(6, 8);
            this.grpPRCTS.Name = "grpPRCTS";
            this.grpPRCTS.Size = new System.Drawing.Size(283, 44);
            this.grpPRCTS.TabIndex = 4;
            this.grpPRCTS.TabStop = false;
            this.grpPRCTS.Visible = false;
            // 
            // picPastpct
            // 
            this.picPastpct.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPastpct.Image = ((System.Drawing.Image)(resources.GetObject("picPastpct.Image")));
            this.picPastpct.Location = new System.Drawing.Point(216, 9);
            this.picPastpct.Name = "picPastpct";
            this.picPastpct.Size = new System.Drawing.Size(51, 33);
            this.picPastpct.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPastpct.TabIndex = 4;
            this.picPastpct.TabStop = false;
            this.picPastpct.Click += new System.EventHandler(this.picPastpct_Click);
            // 
            // tpct
            // 
            this.tpct.BackColor = System.Drawing.Color.Lavender;
            this.tpct.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpct.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tpct.Location = new System.Drawing.Point(112, 11);
            this.tpct.MaxLength = 3;
            this.tpct.Name = "tpct";
            this.tpct.Size = new System.Drawing.Size(63, 29);
            this.tpct.TabIndex = 0;
            this.tpct.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tpct.TextChanged += new System.EventHandler(this.tpct_TextChanged);
            this.tpct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tpct_KeyPress);
            // 
            // lprct
            // 
            this.lprct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lprct.Location = new System.Drawing.Point(12, 14);
            this.lprct.Name = "lprct";
            this.lprct.Size = new System.Drawing.Size(100, 23);
            this.lprct.TabIndex = 3;
            this.lprct.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Rockwell Extra Bold", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(175, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 28);
            this.label1.TabIndex = 1;
            this.label1.Text = "%";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // grpVEB
            // 
            this.grpVEB.Controls.Add(this.txVEB);
            this.grpVEB.Controls.Add(this.picPastVEB);
            this.grpVEB.Controls.Add(this.lVEB);
            this.grpVEB.Location = new System.Drawing.Point(6, 8);
            this.grpVEB.Name = "grpVEB";
            this.grpVEB.Size = new System.Drawing.Size(871, 44);
            this.grpVEB.TabIndex = 5;
            this.grpVEB.TabStop = false;
            this.grpVEB.Visible = false;
            // 
            // txVEB
            // 
            this.txVEB.BackColor = System.Drawing.Color.Lavender;
            this.txVEB.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txVEB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txVEB.Location = new System.Drawing.Point(146, 12);
            this.txVEB.Multiline = true;
            this.txVEB.Name = "txVEB";
            this.txVEB.Size = new System.Drawing.Size(665, 26);
            this.txVEB.TabIndex = 0;
            // 
            // picPastVEB
            // 
            this.picPastVEB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPastVEB.Image = ((System.Drawing.Image)(resources.GetObject("picPastVEB.Image")));
            this.picPastVEB.Location = new System.Drawing.Point(817, 9);
            this.picPastVEB.Name = "picPastVEB";
            this.picPastVEB.Size = new System.Drawing.Size(51, 33);
            this.picPastVEB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPastVEB.TabIndex = 2;
            this.picPastVEB.TabStop = false;
            this.picPastVEB.Click += new System.EventHandler(this.picPastVEB_Click);
            // 
            // lVEB
            // 
            this.lVEB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVEB.Location = new System.Drawing.Point(12, 14);
            this.lVEB.Name = "lVEB";
            this.lVEB.Size = new System.Drawing.Size(134, 23);
            this.lVEB.TabIndex = 3;
            this.lVEB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.edit,
            this.sav,
            this.XLxport,
            this._exit,
            this.hhh,
            this.toolStripSeparator1,
            this.PBWait,
            this.TSpbar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(886, 52);
            this.toolStrip1.TabIndex = 256;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // edit
            // 
            this.edit.Image = ((System.Drawing.Image)(resources.GetObject("edit.Image")));
            this.edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(43, 49);
            this.edit.Text = "Modify";
            this.edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.edit.ToolTipText = "Change %";
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // sav
            // 
            this.sav.Image = ((System.Drawing.Image)(resources.GetObject("sav.Image")));
            this.sav.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sav.Name = "sav";
            this.sav.Size = new System.Drawing.Size(36, 49);
            this.sav.Text = "Save";
            this.sav.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sav.ToolTipText = "save ";
            this.sav.Click += new System.EventHandler(this.sav_Click);
            // 
            // XLxport
            // 
            this.XLxport.Image = ((System.Drawing.Image)(resources.GetObject("XLxport.Image")));
            this.XLxport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.XLxport.Name = "XLxport";
            this.XLxport.Size = new System.Drawing.Size(71, 49);
            this.XLxport.Text = "Excel export";
            this.XLxport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.XLxport.ToolTipText = "Change Content";
            this.XLxport.Click += new System.EventHandler(this.XLxport_Click);
            // 
            // _exit
            // 
            this._exit.Image = ((System.Drawing.Image)(resources.GetObject("_exit.Image")));
            this._exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(47, 49);
            this._exit.Text = "   Exit   ";
            this._exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._exit.Click += new System.EventHandler(this._exit_Click);
            // 
            // hhh
            // 
            this.hhh.Name = "hhh";
            this.hhh.Size = new System.Drawing.Size(6, 52);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 52);
            // 
            // PBWait
            // 
            this.PBWait.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PBWait.ForeColor = System.Drawing.Color.Red;
            this.PBWait.Name = "PBWait";
            this.PBWait.Size = new System.Drawing.Size(209, 49);
            this.PBWait.Text = "Loading in Progress........";
            // 
            // TSpbar
            // 
            this.TSpbar.AutoSize = false;
            this.TSpbar.Name = "TSpbar";
            this.TSpbar.Size = new System.Drawing.Size(200, 20);
            this.TSpbar.Step = 5;
            // 
            // lvAllProjects
            // 
            this.lvAllProjects.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvAllProjects.AutoArrange = false;
            this.lvAllProjects.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lvAllProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch0,
            this.ch1,
            this.ch2,
            this.ch3,
            this.ch4,
            this.ch5,
            this.ch6,
            this.ch7,
            this.ch8,
            this.ch9,
            this.ch10,
            this.ch11,
            this.ch12,
            this.ch13,
            this.ch14,
            this.ch15,
            this.ch16,
            this.ch17,
            this.ch18,
            this.ch19,
            this.ch20});
            this.lvAllProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAllProjects.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAllProjects.ForeColor = System.Drawing.Color.Black;
            this.lvAllProjects.FullRowSelect = true;
            this.lvAllProjects.GridLines = true;
            this.lvAllProjects.Location = new System.Drawing.Point(3, 130);
            this.lvAllProjects.Name = "lvAllProjects";
            this.lvAllProjects.ShowGroups = false;
            this.lvAllProjects.Size = new System.Drawing.Size(886, 432);
            this.lvAllProjects.TabIndex = 259;
            this.lvAllProjects.UseCompatibleStateImageBehavior = false;
            this.lvAllProjects.View = System.Windows.Forms.View.Details;
            this.lvAllProjects.DoubleClick += new System.EventHandler(this.lvAllProjects_DoubleClick);
            this.lvAllProjects.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvAllProjects_ColumnClick);
     //       this.lvAllProjects.RetrieveVirtualItem += new System.Windows.Forms.RetrieveVirtualItemEventHandler(this.lvAllProjects_RetrieveVirtualItem);
            // 
            // ch0
            // 
            this.ch0.Text = "";
            this.ch0.Width = 26;
            // 
            // ch1
            // 
            this.ch1.Text = "";
            this.ch1.Width = 26;
            // 
            // ch2
            // 
            this.ch2.Text = "";
            this.ch2.Width = 26;
            // 
            // ch3
            // 
            this.ch3.Text = "";
            this.ch3.Width = 26;
            // 
            // ch4
            // 
            this.ch4.Text = "";
            this.ch4.Width = 26;
            // 
            // ch5
            // 
            this.ch5.Text = "";
            this.ch5.Width = 26;
            // 
            // ch6
            // 
            this.ch6.Text = "";
            this.ch6.Width = 26;
            // 
            // ch7
            // 
            this.ch7.Text = "";
            this.ch7.Width = 26;
            // 
            // ch8
            // 
            this.ch8.Text = "";
            this.ch8.Width = 26;
            // 
            // ch9
            // 
            this.ch9.Text = "";
            this.ch9.Width = 26;
            // 
            // ch10
            // 
            this.ch10.Text = "";
            this.ch10.Width = 26;
            // 
            // ch11
            // 
            this.ch11.Text = "";
            this.ch11.Width = 26;
            // 
            // ch12
            // 
            this.ch12.Text = "";
            this.ch12.Width = 26;
            // 
            // ch13
            // 
            this.ch13.Text = "";
            this.ch13.Width = 26;
            // 
            // ch14
            // 
            this.ch14.Text = "";
            this.ch14.Width = 26;
            // 
            // ch15
            // 
            this.ch15.Text = "";
            this.ch15.Width = 26;
            // 
            // ch16
            // 
            this.ch16.Text = "";
            this.ch16.Width = 26;
            // 
            // ch17
            // 
            this.ch17.Text = "";
            this.ch17.Width = 26;
            // 
            // ch18
            // 
            this.ch18.Text = "";
            this.ch18.Width = 26;
            // 
            // ch19
            // 
            this.ch19.Text = "";
            this.ch19.Width = 26;
            // 
            // ch20
            // 
            this.ch20.Text = "";
            this.ch20.Width = 26;
            // 
            // OR_Sched_projects_N00
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(892, 565);
            this.Controls.Add(this.grpACF);
            this.Name = "OR_Sched_projects_N00";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduled Projects 00";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OR_Sched_projects_NEW_Load);
            this.grpACF.ResumeLayout(false);
            this.grpACF.PerformLayout();
            this.grpPRCT.ResumeLayout(false);
            this.grpPRCTS.ResumeLayout(false);
            this.grpPRCTS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPastpct)).EndInit();
            this.grpVEB.ResumeLayout(false);
            this.grpVEB.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPastVEB)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private void init_CHnn()
       {
         //  MessageBox.Show("debut= " + DateTime.Now.ToString ());   
           string stSql = "SELECT *  FROM PSM_R_SCD_ITasks ORDER BY ti_xlrnk ";
           SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
           OConn.Open();
           SqlCommand Ocmd = OConn.CreateCommand();
           Ocmd.CommandText = stSql;
           SqlDataReader Oreadr = Ocmd.ExecuteReader();
           int ti = 0;
           while (Oreadr.Read())
           {
               if (ti < 21)
               {
                   lvAllProjects.Columns[ti].Text = Oreadr["ti_Desc"].ToString();
                   lvAllProjects.Columns[ti++].Width = Int32.Parse(Oreadr["ti_xllen"].ToString());  //must be var

               }
               else MessageBox.Show("col hdrs limit...."); 
           
           }
           for (int i = ti; ti < 21; ti++)
               if (lvAllProjects.Columns[ti].Text == "") lvAllProjects.Columns[ti++].Width = 0;
           OConn.Close();
        //   MessageBox.Show("debut= " + DateTime.Now.ToString ()); 
		
		}
        private void NLine_lvAll()
        {
            ListViewItem lvI = lvAllProjects.Items.Add("");
            for (int i=1;i<lvAllProjects.Columns.Count ;i++)
                lvI.SubItems.Add(""); 
        }

        private void load_SubProjold()
        {
            ldeb.Text = DateTime.Now.ToLongTimeString();
            int bigNB = 0;
            double pbU =0;
     //    string stSql = " SELECT PSM_R_SCD_INFO.sc_IREVID, PSM_R_SCD_INFO.sc_Name, PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_Detail.scd_Value, PSM_R_SCD_ITasks.ti_XLrnk,  PSM_R_SCD_ITasks.ti_Desc " +
     //                      " FROM   PSM_R_SCD_INFO INNER JOIN PSM_R_SCD_Detail ON PSM_R_SCD_INFO.sc_LID = PSM_R_SCD_Detail.d_sc_LID INNER JOIN PSM_R_CFinfo ON PSM_R_SCD_INFO.sc_CF_LID = PSM_R_CFinfo.CFLID INNER JOIN " +
 //                          "        PSM_R_SCD_ITasks ON PSM_R_SCD_Detail.scd_TILID = PSM_R_SCD_ITasks.ti_LID INNER JOIN PSM_R_Rev ON PSM_R_SCD_INFO.sc_IREVID = PSM_R_Rev.IRRevID " +
//                           " WHERE     (PSM_R_SCD_INFO.sc_status <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C')" +
//                           " ORDER BY PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_INFO.sc_Name, PSM_R_SCD_ITasks.ti_XLrnk ";

            string WHR = (in_affcod == 0) ? " (PSM_R_SCD_INFO.sc_status <> 0)" : " (PSM_R_SCD_INFO.sc_status <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C') AND (PSM_R_Rev.shiped <> 'D')";
            string stSql = " SELECT PSM_R_SCD_INFO.sc_IREVID, PSM_R_SCD_INFO.sc_Name, PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_Detail.scd_Value, PSM_R_SCD_ITasks.ti_XLrnk,  PSM_R_SCD_ITasks.ti_Desc , PSM_R_SCD_Detail.sc_det_LID " +
                " FROM   PSM_R_SCD_INFO INNER JOIN PSM_R_SCD_Detail ON PSM_R_SCD_INFO.sc_LID = PSM_R_SCD_Detail.d_sc_LID INNER JOIN PSM_R_CFinfo ON PSM_R_SCD_INFO.sc_CF_LID = PSM_R_CFinfo.CFLID INNER JOIN " +
                "        PSM_R_SCD_ITasks ON PSM_R_SCD_Detail.scd_TILID = PSM_R_SCD_ITasks.ti_LID INNER JOIN PSM_R_Rev ON PSM_R_SCD_INFO.sc_IREVID = PSM_R_Rev.IRRevID " +
                " WHERE " + WHR +                 //PSM_R_SCD_INFO.sc_status <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C')" +
                " ORDER BY PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_INFO.sc_Name, PSM_R_SCD_ITasks.ti_XLrnk ";

            this.Refresh(); 
  lvAllProjects.BeginUpdate();
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
           OConn.Open();
           SqlCommand Ocmd = OConn.CreateCommand();
           Ocmd.CommandText = stSql;
           SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string NCFNm="", OldCFNm="";
            ListViewItem lvI = null;
            string st_bigNB = MainMDI.Find_One_Field("select count(*) from V_sched_proj_" + in_affcod);
           if (st_bigNB != MainMDI.VIDE)
           {

               pbU = Math.Round((100.00 / Int32.Parse(st_bigNB )), 4);
               TSpbar.Maximum = Int32.Parse(st_bigNB);
           }
            while (Oreadr.Read())
            {
                NCFNm = Oreadr["sc_Name"].ToString();
                if (NCFNm != OldCFNm)
                {
                    lvI = lvAllProjects.Items.Add(" "); for (int i = 1; i < lvAllProjects.Columns.Count; i++) lvI.SubItems.Add(" ");
                    OldCFNm = NCFNm;
                }
                int ndx=Int32.Parse(Oreadr["ti_XLrnk"].ToString())-1;
                string st = Oreadr["scd_Value"].ToString();
              //  DateTime.Parse (st);    
                if (st.IndexOf('/') == 2 && st.IndexOf('/',3) == 5 && st.Length == 10) st = YYYYMMDD(st);
                lvI.SubItems[ndx].Text = (st == MainMDI.VIDE || st == "") ? " " : st;
                lvI.SubItems[ndx].Tag = Oreadr["sc_det_LID"].ToString(); 
                TSpbar.Value++;
                toolStrip1.Refresh(); 

  
            }
            enable_editLV(true);
              
   lvAllProjects.EndUpdate();
   lfin.Text = DateTime.Now.ToLongTimeString();
   this.Refresh();
              
        }


        private void load_SubProj()
        {
            ldeb.Text = DateTime.Now.ToLongTimeString();
            int bigNB = 0;
            double pbU = 0;
     string WHR = (in_affcod == 0) ? " (PSM_R_SCD_INFO.sc_status <> 0)" : " (PSM_R_SCD_INFO.sc_status <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C') AND (PSM_R_Rev.shiped <> 'D')";
            string stSql = " SELECT PSM_R_SCD_INFO.sc_IREVID, PSM_R_SCD_INFO.sc_Name, PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_Detail.scd_Value, PSM_R_SCD_ITasks.ti_XLrnk,  PSM_R_SCD_ITasks.ti_Desc , PSM_R_SCD_Detail.sc_det_LID " +
                " FROM   PSM_R_SCD_INFO INNER JOIN PSM_R_SCD_Detail ON PSM_R_SCD_INFO.sc_LID = PSM_R_SCD_Detail.d_sc_LID INNER JOIN PSM_R_CFinfo ON PSM_R_SCD_INFO.sc_CF_LID = PSM_R_CFinfo.CFLID INNER JOIN " +
                "        PSM_R_SCD_ITasks ON PSM_R_SCD_Detail.scd_TILID = PSM_R_SCD_ITasks.ti_LID INNER JOIN PSM_R_Rev ON PSM_R_SCD_INFO.sc_IREVID = PSM_R_Rev.IRRevID " +
                " WHERE " + WHR +                 //PSM_R_SCD_INFO.sc_status <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C')" +
                " ORDER BY PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_INFO.sc_Name, PSM_R_SCD_ITasks.ti_XLrnk ";

            this.Refresh();
            lvAllProjects.BeginUpdate();
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string NCFNm = "", OldCFNm = "";
            ListViewItem lvI = null;
            string st_bigNB = MainMDI.Find_One_Field("select count(*) from V_sched_proj_" + in_affcod);
            if (st_bigNB != MainMDI.VIDE)
            {

               // pbU = Math.Round((100.00 / Int32.Parse(st_bigNB)), 4);
              //  TSpbar.Maximum = Int32.Parse(st_bigNB);
            }
     //       long II =   0;
            while (Oreadr.Read())
            {
                NCFNm = Oreadr["sc_Name"].ToString();
                if (NCFNm != OldCFNm)
                {
                    lvI = lvAllProjects.Items.Add(" "); for (int i = 1; i < lvAllProjects.Columns.Count; i++) lvI.SubItems.Add(" ");
                    OldCFNm = NCFNm;
                }
                int ndx = Int32.Parse(Oreadr["ti_XLrnk"].ToString()) - 1;
                string st = Oreadr["scd_Value"].ToString();
                //  DateTime.Parse (st);    
                if (st.IndexOf('/') == 2 && st.IndexOf('/', 3) == 5 && st.Length == 10) st = YYYYMMDD(st);
                lvI.SubItems[ndx].Text = (st == MainMDI.VIDE || st == "") ? " " : st;
                lvI.SubItems[ndx].Tag = Oreadr["sc_det_LID"].ToString();
           //     TSpbar.Value++;
           //     toolStrip1.Refresh();
            
                
                //II++;  lII.Text = II.ToString(); this.Refresh();
              


            }
            enable_editLV(true);

            lvAllProjects.EndUpdate();
            lfin.Text = DateTime.Now.ToLongTimeString();
            this.Refresh();

        }

        private void load_cash()
        {
            ldeb.Text = DateTime.Now.ToLongTimeString();
            int bigNB = 0;
            double pbU = 0;
            //    string stSql = " SELECT PSM_R_SCD_INFO.sc_IREVID, PSM_R_SCD_INFO.sc_Name, PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_Detail.scd_Value, PSM_R_SCD_ITasks.ti_XLrnk,  PSM_R_SCD_ITasks.ti_Desc " +
            //                      " FROM   PSM_R_SCD_INFO INNER JOIN PSM_R_SCD_Detail ON PSM_R_SCD_INFO.sc_LID = PSM_R_SCD_Detail.d_sc_LID INNER JOIN PSM_R_CFinfo ON PSM_R_SCD_INFO.sc_CF_LID = PSM_R_CFinfo.CFLID INNER JOIN " +
            //                          "        PSM_R_SCD_ITasks ON PSM_R_SCD_Detail.scd_TILID = PSM_R_SCD_ITasks.ti_LID INNER JOIN PSM_R_Rev ON PSM_R_SCD_INFO.sc_IREVID = PSM_R_Rev.IRRevID " +
            //                           " WHERE     (PSM_R_SCD_INFO.sc_status <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C')" +
            //                           " ORDER BY PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_INFO.sc_Name, PSM_R_SCD_ITasks.ti_XLrnk ";

            string WHR = (in_affcod == 0) ? " (PSM_R_SCD_INFO.sc_status <> 0)" : " (PSM_R_SCD_INFO.sc_status <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C') AND (PSM_R_Rev.shiped <> 'D')";
            string stSql = " SELECT PSM_R_SCD_INFO.sc_IREVID, PSM_R_SCD_INFO.sc_Name, PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_Detail.scd_Value, PSM_R_SCD_ITasks.ti_XLrnk,  PSM_R_SCD_ITasks.ti_Desc , PSM_R_SCD_Detail.sc_det_LID " +
                " FROM   PSM_R_SCD_INFO INNER JOIN PSM_R_SCD_Detail ON PSM_R_SCD_INFO.sc_LID = PSM_R_SCD_Detail.d_sc_LID INNER JOIN PSM_R_CFinfo ON PSM_R_SCD_INFO.sc_CF_LID = PSM_R_CFinfo.CFLID INNER JOIN " +
                "        PSM_R_SCD_ITasks ON PSM_R_SCD_Detail.scd_TILID = PSM_R_SCD_ITasks.ti_LID INNER JOIN PSM_R_Rev ON PSM_R_SCD_INFO.sc_IREVID = PSM_R_Rev.IRRevID " +
                " WHERE " + WHR +                 //PSM_R_SCD_INFO.sc_status <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C')" +
                " ORDER BY PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_INFO.sc_Name, PSM_R_SCD_ITasks.ti_XLrnk ";

            this.Refresh();
    //        lvAllProjects.BeginUpdate();
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string NCFNm = "", OldCFNm = "";
            
            string st_bigNB = MainMDI.Find_One_Field("select count(*) from V_sched_proj_" + in_affcod);

            if (st_bigNB != MainMDI.VIDE)
            {
                LVcash = new ListViewItem[Int32.Parse("200")+ 1];
                pbU = Math.Round((100.00 / Int32.Parse("200")), 4);
           //     TSpbar.Maximum = Int32.Parse(st_bigNB);
            }
            ListViewItem LVV_vide = new ListViewItem(" ");
            for (int j = 1; j < lvAllProjects.Columns.Count; j++) LVV_vide.SubItems.Add(" "); 

            int intI=-1;
            while (Oreadr.Read())
            {
                NCFNm = Oreadr["sc_Name"].ToString();
                if (NCFNm != OldCFNm)
                {
                    intI++;
                   // LVcash[intI] = new ListViewItem();
                    LVcash[intI] = LVV_vide;
                                
                    OldCFNm = NCFNm;
                }
                int ndx = Int32.Parse(Oreadr["ti_XLrnk"].ToString()) - 1;
                string st = Oreadr["scd_Value"].ToString();
                if (st.IndexOf('/') == 2 && st.IndexOf('/', 3) == 5 && st.Length == 10) st = YYYYMMDD(st);
                LVcash[intI].SubItems[ndx].Text = (st == MainMDI.VIDE || st == "") ? " " : st;
                LVcash[intI].SubItems[ndx].Tag = Oreadr["sc_det_LID"].ToString();
                lII.Text = intI.ToString(); //this.Refresh();

            }
            lvSorter.SortColumn =-1;
            aff_lvcash(LVcash, 7);
          //  aff_lvcash(LVcash, intI);
           for (int p = 0; p < intI; p++)
            {

                ListViewItem TT = lvAllProjects.Items.Add(" "); for (int j = 1; j < lvAllProjects.Columns.Count; j++) TT.SubItems.Add(LVcash[p].Text  ); 
                for (int jj = 1; jj < LVcash[p].SubItems.Count; jj++) TT.SubItems[jj] = LVcash[p].SubItems[jj];// TT.SubItems.Add(LVcash[p].SubItems[jj]);
            }
      
            enable_editLV(true);
            lvAllProjects.Refresh();
  //          lvAllProjects.EndUpdate();
            lfin.Text = DateTime.Now.ToLongTimeString();
            this.Refresh();

        }
        private void aff_lvcash(ListViewItem[] _lc,int _intI)
        {
            string stout = "";
            for (int p = 0; p < _intI; p++)
            {
                stout = "\n P=" + p.ToString()+ "  ";
                for (int jj = 1; jj < LVcash[_intI].SubItems.Count; jj++)
                {
                    stout += " T=" + LVcash[p].SubItems[jj].Text +"   G=" + LVcash[p].SubItems[jj].Tag ;
                }
                MessageBox.Show(stout); 
            }
             

        }

        private void load_cash_arr()
        {

            int intI = -1;
            string WHR = (in_affcod == 0) ? " (PSM_R_SCD_INFO.sc_status <> 0)" : " (PSM_R_SCD_INFO.sc_status <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C') AND (PSM_R_Rev.shiped <> 'D')";
            string stSql = " SELECT PSM_R_SCD_INFO.sc_IREVID, PSM_R_SCD_INFO.sc_Name, PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_Detail.scd_Value, PSM_R_SCD_ITasks.ti_XLrnk,  PSM_R_SCD_ITasks.ti_Desc , PSM_R_SCD_Detail.sc_det_LID " +
                " FROM   PSM_R_SCD_INFO INNER JOIN PSM_R_SCD_Detail ON PSM_R_SCD_INFO.sc_LID = PSM_R_SCD_Detail.d_sc_LID INNER JOIN PSM_R_CFinfo ON PSM_R_SCD_INFO.sc_CF_LID = PSM_R_CFinfo.CFLID INNER JOIN " +
                "        PSM_R_SCD_ITasks ON PSM_R_SCD_Detail.scd_TILID = PSM_R_SCD_ITasks.ti_LID INNER JOIN PSM_R_Rev ON PSM_R_SCD_INFO.sc_IREVID = PSM_R_Rev.IRRevID " +
                " WHERE " + WHR +                 //PSM_R_SCD_INFO.sc_status <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C')" +
                " ORDER BY PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_INFO.sc_Name, PSM_R_SCD_ITasks.ti_XLrnk ";

            ListViewItem LVV_vide = new ListViewItem(" ");
            for (int j = 1; j < lvAllProjects.Columns.Count; j++) LVV_vide.SubItems.Add(" "); 

            
            this.Refresh();
            lvAllProjects.BeginUpdate();
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string NCFNm = "", OldCFNm = "";
            string st_bigNB = MainMDI.Find_One_Field("select count(*) from V_sched_proj_" + in_affcod);
            int arrMAX = 200, ColMAX = 21;
            if (st_bigNB != MainMDI.VIDE)
            {
                ColMAX = lvAllProjects.Columns.Count; arrMAX = Int32.Parse ( st_bigNB) / ColMAX;
                arr_cash_VL = new string[arrMAX, ColMAX];
                arr_cash_TG = new string[arrMAX, ColMAX];
                for (int r = 0; r < arrMAX; r++)
                    for (int j = 0; j < ColMAX; j++)
                    {
                        arr_cash_TG[r, j] = "";
                        arr_cash_VL[r, j] = "";
                    }
            }
            else
            {
                MessageBox.Show ("Error  st_bigNB ...");
                intI = 9999;
            }


            if (intI == -1)
            {
                while (Oreadr.Read())
                {

                    NCFNm = Oreadr["sc_Name"].ToString();
                    if (NCFNm != OldCFNm)
                    {
                        intI++;
                        OldCFNm = NCFNm;
                    }
                    int ndx = Int32.Parse(Oreadr["ti_XLrnk"].ToString()) - 1;
                    string st = Oreadr["scd_Value"].ToString();
                    //  DateTime.Parse (st);    
                    if (st.IndexOf('/') == 2 && st.IndexOf('/', 3) == 5 && st.Length == 10) st = YYYYMMDD(st);
                    arr_cash_VL[intI,ndx] = (st == MainMDI.VIDE || st == "") ? " " : st;
                    arr_cash_TG[intI,ndx]= Oreadr["sc_det_LID"].ToString();
                   
                }
            }
            lII.Text = intI.ToString(); this.Refresh();
            lvSorter.SortColumn = -1;
                for (int L = 0; L < intI; L++)
                {
                    
                    ListViewItem LVV = lvAllProjects.Items.Add(" "); for (int j = 1; j < ColMAX; j++) LVV.SubItems.Add("--"); 
                    for (int i = 0; i < ColMAX; i++)
                    {
                        LVV.SubItems[i].Text =arr_cash_VL[L, i];
                        LVV.SubItems[i].Tag = arr_cash_TG[L, i];
                    }
                    
                }

                lvAllProjects.EndUpdate(); 

        }





        private string YYYYMMDD(string _dd)
        {
            return _dd.Substring(6, 4) + "/" + _dd.Substring(3, 2) + "/" + _dd.Substring(0, 2);
        }

        private void dataGrid1_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}

        private bool iseditable(int col)
        {
            bool _res = false;
            if (st_Editable.IndexOf("|" + col.ToString() +"|") > -1)
            {
                _res = true;
                switch (col)
                {
                    case 9:
                    case 10:
                    case 11:
                    case 12:
                    case 13:
                    case 14:
                        grpPRCTS.Visible = true;
                        grpVEB.Visible = false;
                        lprct.Text = lvAllProjects.Columns[col].Text + ": ";
                        break;

                    case 4:
                    case 5:
                    case 6:
                        grpVEB.Visible = true;
                        grpPRCTS.Visible = false;
                        lVEB.Text = lvAllProjects.Columns[col].Text + ": ";
                        break;
                }
            }
            else _res = false;


            return _res;


        }


        private void select_col(int _col )
        {
            if (OLDcol != _col  && iseditable (_col))
            {

                for (int cc = 0; cc < lvAllProjects.Items.Count; cc++)
                {
                    lvAllProjects.Items[cc].UseItemStyleForSubItems = false;
                    lvAllProjects.Items[cc].SubItems[_col].BackColor = Color.AliceBlue;
                    if (OLDcol != -1) lvAllProjects.Items[cc].SubItems[OLDcol].BackColor = Color.LightGoldenrodYellow;
                }
                OLDcol = _col;
            }
        }


        private void Unselect_col()
        {
            if (OLDcol !=  -1)
            {

                for (int cc = 0; cc < lvAllProjects.Items.Count; cc++)
                {
                    lvAllProjects.Items[cc].UseItemStyleForSubItems = false;
                    lvAllProjects.Items[cc].SubItems[OLDcol].BackColor = Color.LightGoldenrodYellow;
                }
                OLDcol = -1;
            }
        }
        private void lvAllProjects_ColumnClick(object sender, ColumnClickEventArgs e)
        {

            if (grpPRCT.Visible) select_col(e.Column );
            else
            {

                // OLDcol = e.Column; 
                //MessageBox.Show (   e.Column.ToString()  );

                //  btnseek.Text = "Search by:    " + lvQuotes.Columns[e.Column].Text;
                //	if (e.Column == 8 || e.Column == 8 || e.Column == 8) btnseek.Enabled =false; 

                if (ndxCLRD > -1)
                {
                    lvAllProjects.Items[ndxCLRD].BackColor = Color.WhiteSmoke;
                    ndxCLRD = -1;
                }
                seelCol = e.Column;
                //    ColName(e.Column);


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
                }

                // Perform the sort with these new sort options.
                myListView.Sort();
                oldSC = lvSorter.SortColumn;
                lvSorter.SortColumn = 0;
            }

        }

        private void OR_Sched_projects_NEW_Load(object sender, EventArgs e)
        {
           

            this.Cursor = Cursors.WaitCursor;
            init_CHnn();
            fill_st_editable();

       //    load_SubProj();
              
       //    load_cash ();
            load_cash_arr();

            this.Cursor = Cursors.Default;
            PBWait.Visible = false;
            TSpbar.Visible = false; 
     
        }
        private void write_XL_20()
        {
            
            Object m_objOpt = System.Reflection.Missing.Value;
            Excel.Application m_objXL = new Excel.Application();
            Excel.Workbooks m_objbooks = m_objXL.Workbooks;
            Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);
            Excel.Sheets m_objSheets = m_objBook.Worksheets;
            Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

            object[] objHdrs = { "Sales", "Project#", "Serial#", "Model", "VAC-PHS-HRZ", "Enclosure", "Batteries", "Battery RACK", "Options", "BIN", "Panel Assy.", "Panel Wired", "Mecha. Assy.", "Encl. Wired", "Tests", "Customer", "PO#", "Delivery Date", "Handling & Packaging", "Notes" }; 
            Excel.Range m_objRng = m_objSheet.get_Range("A1", "T1"); // "C1", "D1", "E1", "F1", "G1", "H1", "I1", "J1", "K1", "L1", "M1", "N1", "O1", "P1", "Q1", "R1", "S1", "T1");
            m_objRng.Value2 = objHdrs;
            Excel.Font m_objFont = m_objRng.Font;
            m_objFont.Bold = true;

            object[,] objData = new object[MainMDI.MAX_XL_SChedule  , 20];
            for (int i = 0; i < lvAllProjects.Items.Count   ; i++)
            {
                for (int j=0;j<20;j++)
                   objData[i, j] = lvAllProjects.Items[i].SubItems[j].Text;
              //  objData[i, 1] = (i < lvQuotes.Items.Count) ? lvQuotes.Items[i].SubItems[2].Text : "";
            }

            m_objRng = m_objSheet.get_Range("A2", m_objOpt);
            m_objRng = m_objRng.get_Resize(MainMDI.MAX_XL_SChedule, 20);
            m_objRng.Value2 = objData;
             

            m_objBook.SaveAs(MainMDI.XL_Path + @"\Sched_Projects.xls", m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();


        }
        private void write_XL()
        {
         //   if (MainMDI.MAX_XL_SChedule > lvAllProjects.Items.Count ) 
            
                Object m_objOpt = System.Reflection.Missing.Value;
                Excel.Application m_objXL = new Excel.Application();
                Excel.Workbooks m_objbooks = m_objXL.Workbooks;
                Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);
                Excel.Sheets m_objSheets = m_objBook.Worksheets;
                Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

                object[] objHdrs = { "Sales", "Project#", "Serial#", "Model", "VAC-PHS-HRZ", "Enclosure", "Batteries", "Battery RACK", "Options", "BIN", "Panel Assy.", "Panel Wired", "Mecha. Assy.", "Encl. Wired", "Tests", "Customer", "PO#", "Delivery Date", "Invoice Date", "Handling & Packaging", "Notes" };
                Excel.Range m_objRng = m_objSheet.get_Range("A1", "U1"); // "C1", "D1", "E1", "F1", "G1", "H1", "I1", "J1", "K1", "L1", "M1", "N1", "O1", "P1", "Q1", "R1", "S1", "T1", "U1");
                m_objRng.Value2 = objHdrs;
                Excel.Font m_objFont = m_objRng.Font;
                m_objFont.Bold = true;

               // object[,] objData = new object[MainMDI.MAX_XL_SChedule, 21];
                object[,] objData = new object[lvAllProjects.Items.Count, 21];
                for (int i = 0; i < lvAllProjects.Items.Count; i++)
                {
                    for (int j = 0; j < 21; j++)
                        objData[i, j] = lvAllProjects.Items[i].SubItems[j].Text;
                    //  objData[i, 1] = (i < lvQuotes.Items.Count) ? lvQuotes.Items[i].SubItems[2].Text : "";
                }

                m_objRng = m_objSheet.get_Range("A2", m_objOpt);
                m_objRng = m_objRng.get_Resize(lvAllProjects.Items.Count, 21);
                m_objRng.Value2 = objData;


                m_objBook.SaveAs(MainMDI.XL_Path + @"\Sched_Projects.xls", m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
                m_objBook.Close(false, m_objOpt, m_objOpt);
                m_objXL.Quit();
          


        }
        private void XLxport_Click(object sender, EventArgs e)
        {
            File.Delete(MainMDI.XL_Path + @"\Sched_Projects.xls"); 
            write_XL();
            MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\Sched_Projects.xls"); 


        }

        private void grpACF_Enter(object sender, EventArgs e)
        {

        }



        private void fill_dg_SCD()
        {
           /*
            string stSql = "SELECT *  FROM PSM_Boards_List_oldd ORDER BY brd_Desc ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlDataAdapter adptr = new SqlDataAdapter(stSql,OConn  );
            DataSet _DS = new DataSet();
            adptr.Fill(_DS, "PSM_Boardsoldd");
            dg_SCD.DataSource = _DS.DefaultViewManager;
            this.Refresh(); 
            * */
        }
        private void fill_dg_SCD(int c)
        {
            /*
            string stSql = "SELECT *  FROM PSM_Boards_List_oldd ORDER BY brd_Desc ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();


            SqlDataAdapter ODadptr = new SqlDataAdapter(stSql, OConn); ;

            SqlCommandBuilder commandBuilder = new SqlCommandBuilder(ODadptr);
            DataTable tbl = new DataTable();
            tbl.Locale = System.Globalization.CultureInfo.InvariantCulture;
            ODadptr.Fill(tbl);
            bdSRC.DataSource = tbl;
            dg_SCD.AutoResizeColumn((int) DataGridViewAutoSizeColumnMode.ColumnHeader );
            dg_SCD.DataSource = bdSRC;

*/


        }
        private void enable_editLV(bool _stat)
        {
            if (_stat)
            {
                for (int jj = 9; jj < 15; jj++) lvAllProjects.AddEditableCell(-1, jj);
                Unselect_col();
            }
            else lvAllProjects.DelALL_EditableCell();
        }

        private void edit_Click(object sender, EventArgs e)
        {
            grpPRCT.Visible = !grpPRCT.Visible;
            enable_editLV(!grpPRCT.Visible);

        }

 

        private void past(char cd)
        {
            switch (cd)
            {

                case 'P':
                       if (Tools.Conv_Dbl(tpct.Text.Replace("%","") ) > 0)
                {
                    for (int s = 0; s < lvAllProjects.SelectedItems.Count; s++)
                        lvAllProjects.SelectedItems[s].SubItems[OLDcol].Text = tpct.Text.Replace("%", "") + "%";
                }
                break;
                case 'F':
                    if (txVEB.Text.Length >2)
                    {
                        for (int s = 0; s < lvAllProjects.SelectedItems.Count; s++)
                            lvAllProjects.SelectedItems[s].SubItems[OLDcol].Text = txVEB.Text.Replace("'", "''"); ;
                    }
                    break;

            }
            
        }
        private void print_Modif_LVPROJECTS()
        {
            string stout = "";
            for (int cc = 0; cc < lvAllProjects.Items.Count; cc++)
            {
                for (int jj = 0; jj < lvAllProjects.Columns.Count; jj++)
                    if (st_Editable.IndexOf("|" + jj.ToString() + "|") > -1)
                    {
                        string sep = ((cc % 20) == 0) ? "\n" : "***";
                        stout += lvAllProjects.Items[cc].SubItems[jj].Text + "____" + lvAllProjects.Items[cc].SubItems[jj].Tag + sep;
                    }
            }

            MessageBox.Show("stOUT= \n" + stout);
        }

        private void sav_Click(object sender, EventArgs e)
        {
            
            
            for (int cc=0;cc<lvAllProjects.Items.Count ;cc++)
            {
               for (int jj=0;jj<lvAllProjects.Columns.Count ;jj++)  
                if (st_Editable.IndexOf("|"+jj.ToString()+"|") >-1)
                {
                    if (lvAllProjects.Items[cc].SubItems[jj].Tag.ToString().Length > 0)
                    {
                        string stSql = "UPDATE PSM_R_SCD_Detail SET " + " [scd_Value]='" + lvAllProjects.Items[cc].SubItems[jj].Text + "' WHERE sc_det_LID=" + lvAllProjects.Items[cc].SubItems[jj].Tag;
                        MainMDI.ExecSql(stSql);
                    }
                }
            }
          
            grpPRCT.Visible = false;
            enable_editLV(true);
            OLDcol = -1;
        }

        private void lvAllProjects_DoubleClick(object sender, EventArgs e)
        {
            if (OLDcol != -1)
            {
                if (grpPRCTS.Visible) tpct.Text = lvAllProjects.SelectedItems[0].SubItems[OLDcol].Text;
                else txVEB.Text = lvAllProjects.SelectedItems[0].SubItems[OLDcol].Text;
            }

        }

        private void picPastpct_Click(object sender, EventArgs e)
        {
            double dd=Tools.Conv_Dbl(tpct.Text);
            if (dd  > 100) tpct.Text = "100";
            if (dd <0) tpct.Text = "0";
            past('P');
        }

        private void picPastVEB_Click(object sender, EventArgs e)
        {
            past('F');
        }

        private void tpct_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyDBL(e.KeyChar);
        }

        private void fill_st_editable()
        {

            st_Editable = "";
            string stSql = "SELECT ti_XLrnk FROM PSM_R_SCD_ITasks WHERE ti_editable = 1 ORDER BY ti_XLrnk";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())       st_Editable += "|" + Convert.ToString(Int32.Parse(Oreadr["ti_XLrnk"].ToString())  - 1);
            st_Editable += "|";
            OConn.Close();
          //  MessageBox.Show("edit= " + st_Editable);  
        }

        private void tpct_TextChanged(object sender, EventArgs e)
        {

        }

        private void _exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void lvAllProjects_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

   



 
  
  







    }



}
