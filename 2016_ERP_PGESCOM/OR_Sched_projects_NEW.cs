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
	public class OR_Sched_projects_NEW : System.Windows.Forms.Form
    {
       //local var
        private Lib1 Tools = new Lib1();
        string LcurConflid="",in_IRRevID = "", in_RID = "",in_CSTMR="",  SN = "", cur_CFTVA = "", DLVRD = "", lcurConfNm = "", lCFLID="", st_Editable="";
        int LcurConfndx = -1, OLDTVConf_Selndx = -1, tsk_cur_ndx = -1, tsk_old_ndx = -1;
        string[,] arr_Tasks = new string[MainMDI.MAX_SC_TASKS , 5];
        string[,] arr_Tskscopy = new string[20, 3];
        private int oldSC = 0,OLDcol=-1,CURcol=-1;
        const int NBCOLLISTING = 19+3;

        Color clr_cab = Color.Orange , clr_pnl = Color.Gold ;

        //virtual ListView
        private ListViewItem[] LVcash;
        private string[,] arr_cash_VL, arr_cash_TG, arr_Estim_Time;
      
        private ListViewColumnSorter lvSorter = null;
        private char srtType = 'A';
        private int ndxCLRD = -1;
        private int seelCol = 0;
        private string seekColNm, SCD_DETAIL_Name="";
        Color curr_clr = Color.LightGoldenrodYellow; 

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
        private ToolStripButton addArch;
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
        private GroupBox grpSeek;
        private ToolStripButton fndP;
        private Label label2;
        private Button btnseekSN;
        private Label lFndx;
        private ed_LVmodif Back_lvAllProjects;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader2;
        private ColumnHeader columnHeader3;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        private ColumnHeader columnHeader6;
        private ColumnHeader columnHeader7;
        private ColumnHeader columnHeader8;
        private ColumnHeader columnHeader9;
        private ColumnHeader columnHeader10;
        private ColumnHeader columnHeader11;
        private ColumnHeader columnHeader12;
        private ColumnHeader columnHeader13;
        private ColumnHeader columnHeader14;
        private ColumnHeader columnHeader15;
        private ColumnHeader columnHeader16;
        private ColumnHeader columnHeader17;
        private ColumnHeader columnHeader18;
        private ColumnHeader columnHeader19;
        private ColumnHeader columnHeader20;
        private ColumnHeader columnHeader21;
        private Button btn_displayALL;
        private Button btn_addPRJ;
        private Label label4;
        public TextBox textBox1;
        private Button button2;
        private Label lsc_LID;
        private Button button1;
        private ToolStripButton inPRO;
        private ToolStripButton Arch_prj;
        private int in_affcod;
        private GroupBox grpEmp;
        private RadioButton radioButton2;
        private RadioButton radioButton1;
        public ComboBox CB_Panel_Emp;
        private Button btn_seekNM;
        private GroupBox grpsk;
        private Label dateTO;
        private Label dateFROM;
        private Button btnDate;
        public DateTimePicker dpFrom;
        public DateTimePicker dpTo;
        private Label lTo;
        private Label lfrom;
        private Label label3;
        private Button btnseekPN;
        public TextBox tKey;
        char in_EM = 'E';

        public OR_Sched_projects_NEW(int x_affcod,char x_EM)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            in_affcod = x_affcod;
            in_EM = x_EM;
            init_CHnn();
            //make this LV  using SORTing cols
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OR_Sched_projects_NEW));
            this.imageList16 = new System.Windows.Forms.ImageList(this.components);
            this.grpACF = new System.Windows.Forms.GroupBox();
            this.lII = new System.Windows.Forms.Label();
            this.ldeb = new System.Windows.Forms.Label();
            this.lfin = new System.Windows.Forms.Label();
            this.lvAllProjects = new PGESCOM.ed_LVmodif();
            this.ch0 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ch20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpPRCT = new System.Windows.Forms.GroupBox();
            this.grpSeek = new System.Windows.Forms.GroupBox();
            this.grpsk = new System.Windows.Forms.GroupBox();
            this.dateTO = new System.Windows.Forms.Label();
            this.dateFROM = new System.Windows.Forms.Label();
            this.btnDate = new System.Windows.Forms.Button();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.dpTo = new System.Windows.Forms.DateTimePicker();
            this.lTo = new System.Windows.Forms.Label();
            this.lfrom = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btnseekPN = new System.Windows.Forms.Button();
            this.tKey = new System.Windows.Forms.TextBox();
            this.grpEmp = new System.Windows.Forms.GroupBox();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.CB_Panel_Emp = new System.Windows.Forms.ComboBox();
            this.btn_seekNM = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lsc_LID = new System.Windows.Forms.Label();
            this.btnseekSN = new System.Windows.Forms.Button();
            this.btn_displayALL = new System.Windows.Forms.Button();
            this.Back_lvAllProjects = new PGESCOM.ed_LVmodif();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader8 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader9 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader10 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader11 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader12 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader13 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader14 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lFndx = new System.Windows.Forms.Label();
            this.grpVEB = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.btn_addPRJ = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txVEB = new System.Windows.Forms.TextBox();
            this.grpPRCTS = new System.Windows.Forms.GroupBox();
            this.picPastpct = new System.Windows.Forms.PictureBox();
            this.tpct = new System.Windows.Forms.TextBox();
            this.lprct = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picPastVEB = new System.Windows.Forms.PictureBox();
            this.lVEB = new System.Windows.Forms.Label();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.inPRO = new System.Windows.Forms.ToolStripButton();
            this.edit = new System.Windows.Forms.ToolStripButton();
            this.fndP = new System.Windows.Forms.ToolStripButton();
            this.XLxport = new System.Windows.Forms.ToolStripButton();
            this.addArch = new System.Windows.Forms.ToolStripButton();
            this.Arch_prj = new System.Windows.Forms.ToolStripButton();
            this._exit = new System.Windows.Forms.ToolStripButton();
            this.hhh = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PBWait = new System.Windows.Forms.ToolStripLabel();
            this.TSpbar = new System.Windows.Forms.ToolStripProgressBar();
            this.grpACF.SuspendLayout();
            this.grpPRCT.SuspendLayout();
            this.grpSeek.SuspendLayout();
            this.grpsk.SuspendLayout();
            this.grpEmp.SuspendLayout();
            this.grpVEB.SuspendLayout();
            this.grpPRCTS.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPastpct)).BeginInit();
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
            this.grpACF.Size = new System.Drawing.Size(968, 565);
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
            this.lII.Visible = false;
            // 
            // ldeb
            // 
            this.ldeb.BackColor = System.Drawing.Color.ForestGreen;
            this.ldeb.ForeColor = System.Drawing.Color.White;
            this.ldeb.Location = new System.Drawing.Point(648, 28);
            this.ldeb.Name = "ldeb";
            this.ldeb.Size = new System.Drawing.Size(72, 23);
            this.ldeb.TabIndex = 261;
            this.ldeb.Visible = false;
            // 
            // lfin
            // 
            this.lfin.BackColor = System.Drawing.Color.Blue;
            this.lfin.ForeColor = System.Drawing.Color.White;
            this.lfin.Location = new System.Drawing.Point(804, 28);
            this.lfin.Name = "lfin";
            this.lfin.Size = new System.Drawing.Size(82, 23);
            this.lfin.TabIndex = 260;
            this.lfin.Visible = false;
            // 
            // lvAllProjects
            // 
            this.lvAllProjects.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvAllProjects.AutoArrange = false;
            this.lvAllProjects.BackColor = System.Drawing.Color.Wheat;
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
            this.lvAllProjects.ForeColor = System.Drawing.Color.Blue;
            this.lvAllProjects.FullRowSelect = true;
            this.lvAllProjects.GridLines = true;
            this.lvAllProjects.Location = new System.Drawing.Point(3, 192);
            this.lvAllProjects.Name = "lvAllProjects";
            this.lvAllProjects.ShowGroups = false;
            this.lvAllProjects.Size = new System.Drawing.Size(962, 370);
            this.lvAllProjects.TabIndex = 259;
            this.lvAllProjects.UseCompatibleStateImageBehavior = false;
            this.lvAllProjects.View = System.Windows.Forms.View.Details;
            this.lvAllProjects.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvAllProjects_ColumnClick);
            this.lvAllProjects.SelectedIndexChanged += new System.EventHandler(this.lvAllProjects_SelectedIndexChanged);
            this.lvAllProjects.Click += new System.EventHandler(this.lvAllProjects_Click);
            this.lvAllProjects.DoubleClick += new System.EventHandler(this.lvAllProjects_DoubleClick);
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
            // grpPRCT
            // 
            this.grpPRCT.Controls.Add(this.grpSeek);
            this.grpPRCT.Controls.Add(this.grpVEB);
            this.grpPRCT.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpPRCT.Location = new System.Drawing.Point(3, 70);
            this.grpPRCT.Name = "grpPRCT";
            this.grpPRCT.Size = new System.Drawing.Size(962, 122);
            this.grpPRCT.TabIndex = 258;
            this.grpPRCT.TabStop = false;
            this.grpPRCT.Visible = false;
            // 
            // grpSeek
            // 
            this.grpSeek.Controls.Add(this.grpsk);
            this.grpSeek.Controls.Add(this.grpEmp);
            this.grpSeek.Controls.Add(this.button1);
            this.grpSeek.Controls.Add(this.lsc_LID);
            this.grpSeek.Controls.Add(this.btnseekSN);
            this.grpSeek.Controls.Add(this.btn_displayALL);
            this.grpSeek.Controls.Add(this.Back_lvAllProjects);
            this.grpSeek.Controls.Add(this.lFndx);
            this.grpSeek.Location = new System.Drawing.Point(9, 17);
            this.grpSeek.Name = "grpSeek";
            this.grpSeek.Size = new System.Drawing.Size(944, 98);
            this.grpSeek.TabIndex = 6;
            this.grpSeek.TabStop = false;
            // 
            // grpsk
            // 
            this.grpsk.Controls.Add(this.dateTO);
            this.grpsk.Controls.Add(this.dateFROM);
            this.grpsk.Controls.Add(this.btnDate);
            this.grpsk.Controls.Add(this.dpFrom);
            this.grpsk.Controls.Add(this.dpTo);
            this.grpsk.Controls.Add(this.lTo);
            this.grpsk.Controls.Add(this.lfrom);
            this.grpsk.Controls.Add(this.label3);
            this.grpsk.Controls.Add(this.btnseekPN);
            this.grpsk.Controls.Add(this.tKey);
            this.grpsk.Location = new System.Drawing.Point(6, 11);
            this.grpsk.Name = "grpsk";
            this.grpsk.Size = new System.Drawing.Size(411, 83);
            this.grpsk.TabIndex = 276;
            this.grpsk.TabStop = false;
            // 
            // dateTO
            // 
            this.dateTO.BackColor = System.Drawing.Color.ForestGreen;
            this.dateTO.ForeColor = System.Drawing.Color.White;
            this.dateTO.Location = new System.Drawing.Point(165, 28);
            this.dateTO.Name = "dateTO";
            this.dateTO.Size = new System.Drawing.Size(14, 23);
            this.dateTO.TabIndex = 282;
            this.dateTO.Visible = false;
            // 
            // dateFROM
            // 
            this.dateFROM.BackColor = System.Drawing.Color.ForestGreen;
            this.dateFROM.ForeColor = System.Drawing.Color.White;
            this.dateFROM.Location = new System.Drawing.Point(299, 24);
            this.dateFROM.Name = "dateFROM";
            this.dateFROM.Size = new System.Drawing.Size(14, 23);
            this.dateFROM.TabIndex = 281;
            this.dateFROM.Visible = false;
            // 
            // btnDate
            // 
            this.btnDate.Enabled = false;
            this.btnDate.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDate.Location = new System.Drawing.Point(299, 9);
            this.btnDate.Name = "btnDate";
            this.btnDate.Size = new System.Drawing.Size(100, 26);
            this.btnDate.TabIndex = 280;
            this.btnDate.Text = "by Date";
            this.btnDate.Click += new System.EventHandler(this.btnDate_Click);
            // 
            // dpFrom
            // 
            this.dpFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpFrom.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dpFrom.CalendarTitleBackColor = System.Drawing.Color.Lavender;
            this.dpFrom.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFrom.Location = new System.Drawing.Point(55, 12);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(104, 20);
            this.dpFrom.TabIndex = 277;
            this.dpFrom.ValueChanged += new System.EventHandler(this.dpFrom_ValueChanged);
            // 
            // dpTo
            // 
            this.dpTo.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dpTo.CalendarTitleBackColor = System.Drawing.Color.Lavender;
            this.dpTo.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dpTo.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpTo.Location = new System.Drawing.Point(189, 12);
            this.dpTo.Name = "dpTo";
            this.dpTo.Size = new System.Drawing.Size(104, 20);
            this.dpTo.TabIndex = 279;
            this.dpTo.ValueChanged += new System.EventHandler(this.dpTo_ValueChanged);
            // 
            // lTo
            // 
            this.lTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lTo.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lTo.Location = new System.Drawing.Point(159, 12);
            this.lTo.Name = "lTo";
            this.lTo.Size = new System.Drawing.Size(30, 21);
            this.lTo.TabIndex = 278;
            this.lTo.Text = "TO:";
            this.lTo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lfrom
            // 
            this.lfrom.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lfrom.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lfrom.Location = new System.Drawing.Point(6, 11);
            this.lfrom.Name = "lfrom";
            this.lfrom.Size = new System.Drawing.Size(49, 23);
            this.lfrom.TabIndex = 276;
            this.lfrom.Text = "FROM:";
            this.lfrom.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 55);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 275;
            this.label3.Text = "Project# :";
            // 
            // btnseekPN
            // 
            this.btnseekPN.Enabled = false;
            this.btnseekPN.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnseekPN.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnseekPN.Location = new System.Drawing.Point(303, 48);
            this.btnseekPN.Name = "btnseekPN";
            this.btnseekPN.Size = new System.Drawing.Size(100, 26);
            this.btnseekPN.TabIndex = 274;
            this.btnseekPN.Text = "by Project #";
            this.btnseekPN.Click += new System.EventHandler(this.btnseekPN_Click);
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.PeachPuff;
            this.tKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.ForeColor = System.Drawing.Color.Black;
            this.tKey.Location = new System.Drawing.Point(59, 51);
            this.tKey.MaxLength = 60;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(238, 20);
            this.tKey.TabIndex = 273;
            this.tKey.TextChanged += new System.EventHandler(this.tKey_TextChanged);
            // 
            // grpEmp
            // 
            this.grpEmp.Controls.Add(this.radioButton2);
            this.grpEmp.Controls.Add(this.radioButton1);
            this.grpEmp.Controls.Add(this.CB_Panel_Emp);
            this.grpEmp.Controls.Add(this.btn_seekNM);
            this.grpEmp.Location = new System.Drawing.Point(441, 10);
            this.grpEmp.Name = "grpEmp";
            this.grpEmp.Size = new System.Drawing.Size(480, 80);
            this.grpEmp.TabIndex = 275;
            this.grpEmp.TabStop = false;
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(75, 16);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(61, 17);
            this.radioButton2.TabIndex = 377;
            this.radioButton2.Text = "Cabinet";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(17, 15);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(52, 17);
            this.radioButton1.TabIndex = 376;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Panel";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // CB_Panel_Emp
            // 
            this.CB_Panel_Emp.BackColor = System.Drawing.Color.Lavender;
            this.CB_Panel_Emp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Panel_Emp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Panel_Emp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CB_Panel_Emp.Location = new System.Drawing.Point(286, 15);
            this.CB_Panel_Emp.Name = "CB_Panel_Emp";
            this.CB_Panel_Emp.Size = new System.Drawing.Size(171, 23);
            this.CB_Panel_Emp.TabIndex = 375;
            this.CB_Panel_Emp.SelectedIndexChanged += new System.EventHandler(this.CB_Panel_Emp_SelectedIndexChanged);
            // 
            // btn_seekNM
            // 
            this.btn_seekNM.Enabled = false;
            this.btn_seekNM.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_seekNM.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_seekNM.Location = new System.Drawing.Point(17, 41);
            this.btn_seekNM.Name = "btn_seekNM";
            this.btn_seekNM.Size = new System.Drawing.Size(440, 26);
            this.btn_seekNM.TabIndex = 374;
            this.btn_seekNM.Text = "by Employee Name";
            this.btn_seekNM.Click += new System.EventHandler(this.btn_seekNM_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(473, 42);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(59, 26);
            this.button1.TabIndex = 274;
            this.button1.Text = "Display archive";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lsc_LID
            // 
            this.lsc_LID.BackColor = System.Drawing.Color.White;
            this.lsc_LID.ForeColor = System.Drawing.Color.Black;
            this.lsc_LID.Location = new System.Drawing.Point(538, 45);
            this.lsc_LID.Name = "lsc_LID";
            this.lsc_LID.Size = new System.Drawing.Size(29, 23);
            this.lsc_LID.TabIndex = 273;
            this.lsc_LID.Visible = false;
            // 
            // btnseekSN
            // 
            this.btnseekSN.Enabled = false;
            this.btnseekSN.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnseekSN.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnseekSN.Location = new System.Drawing.Point(787, 42);
            this.btnseekSN.Name = "btnseekSN";
            this.btnseekSN.Size = new System.Drawing.Size(35, 26);
            this.btnseekSN.TabIndex = 162;
            this.btnseekSN.Text = "by Serial #";
            this.btnseekSN.Visible = false;
            this.btnseekSN.Click += new System.EventHandler(this.btnseekSN_Click);
            // 
            // btn_displayALL
            // 
            this.btn_displayALL.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_displayALL.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_displayALL.Location = new System.Drawing.Point(543, 45);
            this.btn_displayALL.Name = "btn_displayALL";
            this.btn_displayALL.Size = new System.Drawing.Size(69, 26);
            this.btn_displayALL.TabIndex = 270;
            this.btn_displayALL.Text = "Display all  In Process";
            this.btn_displayALL.Visible = false;
            this.btn_displayALL.Click += new System.EventHandler(this.btn_displayALL_Click);
            // 
            // Back_lvAllProjects
            // 
            this.Back_lvAllProjects.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.Back_lvAllProjects.AutoArrange = false;
            this.Back_lvAllProjects.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.Back_lvAllProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16,
            this.columnHeader17,
            this.columnHeader18,
            this.columnHeader19,
            this.columnHeader20,
            this.columnHeader21});
            this.Back_lvAllProjects.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Back_lvAllProjects.ForeColor = System.Drawing.Color.Black;
            this.Back_lvAllProjects.FullRowSelect = true;
            this.Back_lvAllProjects.GridLines = true;
            this.Back_lvAllProjects.Location = new System.Drawing.Point(835, 17);
            this.Back_lvAllProjects.Name = "Back_lvAllProjects";
            this.Back_lvAllProjects.ShowGroups = false;
            this.Back_lvAllProjects.Size = new System.Drawing.Size(55, 49);
            this.Back_lvAllProjects.TabIndex = 269;
            this.Back_lvAllProjects.UseCompatibleStateImageBehavior = false;
            this.Back_lvAllProjects.View = System.Windows.Forms.View.Details;
            this.Back_lvAllProjects.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 95;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 26;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 26;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 26;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.Width = 26;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "";
            this.columnHeader6.Width = 26;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "";
            this.columnHeader7.Width = 26;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "";
            this.columnHeader8.Width = 26;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "";
            this.columnHeader9.Width = 26;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "";
            this.columnHeader10.Width = 26;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "";
            this.columnHeader11.Width = 26;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "";
            this.columnHeader12.Width = 26;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "";
            this.columnHeader13.Width = 26;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "";
            this.columnHeader14.Width = 26;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "";
            this.columnHeader15.Width = 26;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "";
            this.columnHeader16.Width = 26;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "";
            this.columnHeader17.Width = 26;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "";
            this.columnHeader18.Width = 26;
            // 
            // columnHeader19
            // 
            this.columnHeader19.Text = "";
            this.columnHeader19.Width = 26;
            // 
            // columnHeader20
            // 
            this.columnHeader20.Text = "";
            this.columnHeader20.Width = 26;
            // 
            // columnHeader21
            // 
            this.columnHeader21.Text = "";
            this.columnHeader21.Width = 26;
            // 
            // lFndx
            // 
            this.lFndx.BackColor = System.Drawing.Color.ForestGreen;
            this.lFndx.ForeColor = System.Drawing.Color.White;
            this.lFndx.Location = new System.Drawing.Point(438, 46);
            this.lFndx.Name = "lFndx";
            this.lFndx.Size = new System.Drawing.Size(14, 23);
            this.lFndx.TabIndex = 262;
            this.lFndx.Visible = false;
            // 
            // grpVEB
            // 
            this.grpVEB.Controls.Add(this.label2);
            this.grpVEB.Controls.Add(this.button2);
            this.grpVEB.Controls.Add(this.btn_addPRJ);
            this.grpVEB.Controls.Add(this.label4);
            this.grpVEB.Controls.Add(this.textBox1);
            this.grpVEB.Controls.Add(this.txVEB);
            this.grpVEB.Controls.Add(this.grpPRCTS);
            this.grpVEB.Controls.Add(this.picPastVEB);
            this.grpVEB.Controls.Add(this.lVEB);
            this.grpVEB.Location = new System.Drawing.Point(873, 17);
            this.grpVEB.Name = "grpVEB";
            this.grpVEB.Size = new System.Drawing.Size(80, 32);
            this.grpVEB.TabIndex = 5;
            this.grpVEB.TabStop = false;
            this.grpVEB.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(916, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(25, 29);
            this.label2.TabIndex = 4;
            this.label2.Text = "X";
            this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(611, 42);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(85, 23);
            this.button2.TabIndex = 267;
            this.button2.Text = "Cancel";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btn_addPRJ
            // 
            this.btn_addPRJ.Location = new System.Drawing.Point(487, 41);
            this.btn_addPRJ.Name = "btn_addPRJ";
            this.btn_addPRJ.Size = new System.Drawing.Size(118, 23);
            this.btn_addPRJ.TabIndex = 266;
            this.btn_addPRJ.Text = "OK";
            this.btn_addPRJ.UseVisualStyleBackColor = true;
            this.btn_addPRJ.Click += new System.EventHandler(this.btn_addPRJ_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(222, 40);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(81, 24);
            this.label4.TabIndex = 265;
            this.label4.Text = "Project #:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.PeachPuff;
            this.textBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(303, 41);
            this.textBox1.MaxLength = 60;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(184, 22);
            this.textBox1.TabIndex = 264;
            // 
            // txVEB
            // 
            this.txVEB.BackColor = System.Drawing.Color.Lavender;
            this.txVEB.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txVEB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.txVEB.Location = new System.Drawing.Point(772, 19);
            this.txVEB.Multiline = true;
            this.txVEB.Name = "txVEB";
            this.txVEB.Size = new System.Drawing.Size(17, 26);
            this.txVEB.TabIndex = 0;
            this.txVEB.Visible = false;
            // 
            // grpPRCTS
            // 
            this.grpPRCTS.Controls.Add(this.picPastpct);
            this.grpPRCTS.Controls.Add(this.tpct);
            this.grpPRCTS.Controls.Add(this.lprct);
            this.grpPRCTS.Controls.Add(this.label1);
            this.grpPRCTS.Location = new System.Drawing.Point(787, 56);
            this.grpPRCTS.Name = "grpPRCTS";
            this.grpPRCTS.Size = new System.Drawing.Size(78, 23);
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
            this.lprct.BackColor = System.Drawing.Color.Gray;
            this.lprct.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lprct.Location = new System.Drawing.Point(6, 11);
            this.lprct.Name = "lprct";
            this.lprct.Size = new System.Drawing.Size(29, 23);
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
            // picPastVEB
            // 
            this.picPastVEB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPastVEB.Image = ((System.Drawing.Image)(resources.GetObject("picPastVEB.Image")));
            this.picPastVEB.Location = new System.Drawing.Point(817, 9);
            this.picPastVEB.Name = "picPastVEB";
            this.picPastVEB.Size = new System.Drawing.Size(48, 33);
            this.picPastVEB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPastVEB.TabIndex = 2;
            this.picPastVEB.TabStop = false;
            this.picPastVEB.Visible = false;
            this.picPastVEB.Click += new System.EventHandler(this.picPastVEB_Click);
            // 
            // lVEB
            // 
            this.lVEB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVEB.Location = new System.Drawing.Point(68, 44);
            this.lVEB.Name = "lVEB";
            this.lVEB.Size = new System.Drawing.Size(207, 23);
            this.lVEB.TabIndex = 3;
            this.lVEB.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.inPRO,
            this.edit,
            this.fndP,
            this.XLxport,
            this.addArch,
            this.Arch_prj,
            this._exit,
            this.hhh,
            this.toolStripSeparator1,
            this.PBWait,
            this.TSpbar});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(962, 54);
            this.toolStrip1.TabIndex = 256;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // inPRO
            // 
            this.inPRO.Image = ((System.Drawing.Image)(resources.GetObject("inPRO.Image")));
            this.inPRO.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.inPRO.Name = "inPRO";
            this.inPRO.Size = new System.Drawing.Size(109, 51);
            this.inPRO.Text = "Projects In Process";
            this.inPRO.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.inPRO.ToolTipText = "Add project to Mecanical List";
            this.inPRO.Click += new System.EventHandler(this.inPRO_Click);
            // 
            // edit
            // 
            this.edit.Image = ((System.Drawing.Image)(resources.GetObject("edit.Image")));
            this.edit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.edit.Name = "edit";
            this.edit.Size = new System.Drawing.Size(73, 51);
            this.edit.Text = "Add Project";
            this.edit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.edit.ToolTipText = "Add project to Mecanical List";
            this.edit.Visible = false;
            this.edit.Click += new System.EventHandler(this.edit_Click);
            // 
            // fndP
            // 
            this.fndP.Image = ((System.Drawing.Image)(resources.GetObject("fndP.Image")));
            this.fndP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.fndP.Name = "fndP";
            this.fndP.Size = new System.Drawing.Size(74, 51);
            this.fndP.Text = "Find Project";
            this.fndP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.fndP.ToolTipText = "Find project";
            this.fndP.Click += new System.EventHandler(this.fndP_Click);
            // 
            // XLxport
            // 
            this.XLxport.Image = ((System.Drawing.Image)(resources.GetObject("XLxport.Image")));
            this.XLxport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.XLxport.Name = "XLxport";
            this.XLxport.Size = new System.Drawing.Size(73, 51);
            this.XLxport.Text = "Excel export";
            this.XLxport.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.XLxport.ToolTipText = "Change Content";
            this.XLxport.Click += new System.EventHandler(this.XLxport_Click);
            // 
            // addArch
            // 
            this.addArch.Image = ((System.Drawing.Image)(resources.GetObject("addArch.Image")));
            this.addArch.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.addArch.Name = "addArch";
            this.addArch.Size = new System.Drawing.Size(88, 51);
            this.addArch.Text = "Add to archive";
            this.addArch.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.addArch.ToolTipText = "Add to archive";
            this.addArch.Click += new System.EventHandler(this.addArch_Click);
            // 
            // Arch_prj
            // 
            this.Arch_prj.Image = ((System.Drawing.Image)(resources.GetObject("Arch_prj.Image")));
            this.Arch_prj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Arch_prj.Name = "Arch_prj";
            this.Arch_prj.Size = new System.Drawing.Size(51, 51);
            this.Arch_prj.Text = "Archive";
            this.Arch_prj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Arch_prj.ToolTipText = "Add to archive";
            this.Arch_prj.Click += new System.EventHandler(this.Arch_prj_Click);
            // 
            // _exit
            // 
            this._exit.Image = ((System.Drawing.Image)(resources.GetObject("_exit.Image")));
            this._exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(47, 51);
            this._exit.Text = "   Exit   ";
            this._exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._exit.Click += new System.EventHandler(this._exit_Click);
            // 
            // hhh
            // 
            this.hhh.Name = "hhh";
            this.hhh.Size = new System.Drawing.Size(6, 54);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 54);
            // 
            // PBWait
            // 
            this.PBWait.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PBWait.ForeColor = System.Drawing.Color.Red;
            this.PBWait.Name = "PBWait";
            this.PBWait.Size = new System.Drawing.Size(209, 51);
            this.PBWait.Text = "Loading in Progress........";
            // 
            // TSpbar
            // 
            this.TSpbar.AutoSize = false;
            this.TSpbar.Name = "TSpbar";
            this.TSpbar.Size = new System.Drawing.Size(200, 20);
            this.TSpbar.Step = 5;
            this.TSpbar.Visible = false;
            // 
            // OR_Sched_projects_NEW
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(968, 565);
            this.Controls.Add(this.grpACF);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OR_Sched_projects_NEW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduled Projects";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OR_Sched_projects_NEW_Load);
            this.grpACF.ResumeLayout(false);
            this.grpACF.PerformLayout();
            this.grpPRCT.ResumeLayout(false);
            this.grpSeek.ResumeLayout(false);
            this.grpsk.ResumeLayout(false);
            this.grpsk.PerformLayout();
            this.grpEmp.ResumeLayout(false);
            this.grpEmp.PerformLayout();
            this.grpVEB.ResumeLayout(false);
            this.grpVEB.PerformLayout();
            this.grpPRCTS.ResumeLayout(false);
            this.grpPRCTS.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picPastpct)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPastVEB)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private void init_CHnn()
       {
         //  MessageBox.Show("debut= " + DateTime.Now.ToString ());   
     //      string stSql = "SELECT *  FROM PSM_R_SCD_ITasks where used=1 ORDER BY ti_xlrnk ";
           string stSql = "SELECT *  FROM PSM_R_SCD_ITasks ORDER BY ti_xlrnk ";
           SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
           OConn.Open();
           SqlCommand Ocmd = OConn.CreateCommand();
           Ocmd.CommandText = stSql;
           SqlDataReader Oreadr = Ocmd.ExecuteReader();
           int ti = 0;
           while (Oreadr.Read())
           {
               if (ti < NBCOLLISTING )
               {
                   lvAllProjects.Columns[ti].Text = Oreadr["ti_Desc"].ToString();
                   lvAllProjects.Columns[ti++].Width = Int32.Parse(Oreadr["ti_xllen"].ToString());  //must be var
                   if (Oreadr["ti_Desc"].ToString() == "Panel duration" || Oreadr["ti_Desc"].ToString() == "Cabinet duration")
                   {
                       lvAllProjects.Columns[ti].Text = "Estimated Time";
                       lvAllProjects.Columns[ti++].Width = Int32.Parse(Oreadr["ti_xllen"].ToString()); 
                   }
               }
               else MessageBox.Show("col hdrs limit...."); 
           
           }
           for (int i = ti; ti < lvAllProjects.Columns.Count ; ti++)
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
            string stSql = " SELECT PSM_R_SCD_INFO.sc_IREVID, PSM_R_SCD_INFO.sc_Name, PSM_R_CFinfo.c_datDlvr, " + SCD_DETAIL_Name + ".scd_Value, PSM_R_SCD_ITasks.ti_XLrnk,  PSM_R_SCD_ITasks.ti_Desc , " + SCD_DETAIL_Name + ".sc_det_LID " +
                " FROM   PSM_R_SCD_INFO INNER JOIN " + SCD_DETAIL_Name + " ON PSM_R_SCD_INFO.sc_LID = " + SCD_DETAIL_Name + ".d_sc_LID INNER JOIN PSM_R_CFinfo ON PSM_R_SCD_INFO.sc_CF_LID = PSM_R_CFinfo.CFLID INNER JOIN " +
                "        PSM_R_SCD_ITasks ON " + SCD_DETAIL_Name + ".scd_TILID = PSM_R_SCD_ITasks.ti_LID INNER JOIN PSM_R_Rev ON PSM_R_SCD_INFO.sc_IREVID = PSM_R_Rev.IRRevID " +
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
              // TSpbar.Maximum = Int32.Parse(st_bigNB);
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
     string stSql = " SELECT PSM_R_SCD_INFO.sc_IREVID, PSM_R_SCD_INFO.sc_Name, PSM_R_CFinfo.c_datDlvr, " + SCD_DETAIL_Name + ".scd_Value, PSM_R_SCD_ITasks.ti_XLrnk,  PSM_R_SCD_ITasks.ti_Desc , " + SCD_DETAIL_Name + ".sc_det_LID " +
                " FROM   PSM_R_SCD_INFO INNER JOIN " + SCD_DETAIL_Name + " ON PSM_R_SCD_INFO.sc_LID = " + SCD_DETAIL_Name + ".d_sc_LID INNER JOIN PSM_R_CFinfo ON PSM_R_SCD_INFO.sc_CF_LID = PSM_R_CFinfo.CFLID INNER JOIN " +
                "        PSM_R_SCD_ITasks ON " + SCD_DETAIL_Name + ".scd_TILID = PSM_R_SCD_ITasks.ti_LID INNER JOIN PSM_R_Rev ON PSM_R_SCD_INFO.sc_IREVID = PSM_R_Rev.IRRevID " +
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

              pbU = Math.Round((100.00 / Int32.Parse(st_bigNB)), 4);
      //          TSpbar.Maximum = Int32.Parse(st_bigNB);
            }
     //       long II =   0;
     //       lvSorter.SortColumn = -1;
            while (Oreadr.Read())
            {
                NCFNm = Oreadr["sc_Name"].ToString();
                if (NCFNm != OldCFNm)
                {
                    lvI = lvAllProjects.Items.Add(" ");
                    for (int i = 1; i < lvAllProjects.Columns.Count; i++)
                    {
                        lvI.SubItems.Add(" ");
   
                    }
                    OldCFNm = NCFNm;
                }
                int ndx = Int32.Parse(Oreadr["ti_XLrnk"].ToString()) - 1;
                string st = Oreadr["scd_Value"].ToString();
                //  DateTime.Parse (st);    
                if (st.IndexOf('/') == 2 && st.IndexOf('/', 3) == 5 && st.Length == 10) st = YYYYMMDD(st);
                lvI.SubItems[ndx].Text = (st == MainMDI.VIDE || st == "") ? " " : st;
                lvI.SubItems[ndx].Tag = Oreadr["sc_det_LID"].ToString();
     //           TSpbar.Value++;
     //           toolStrip1.Refresh();
            
                
                //II++;  lII.Text = II.ToString(); this.Refresh();
              


            }
            enable_editLV(true);

            lvAllProjects.EndUpdate();
            lfin.Text = DateTime.Now.ToLongTimeString();
            this.Refresh();

        }

        string NBrec_Schedule (int _arch)
        {

            
            string stSql = " SELECT count (*)  FROM  dbo.PSM_R_SCD_INFO INNER JOIN  dbo." + SCD_DETAIL_Name + " ON dbo.PSM_R_SCD_INFO.sc_LID = dbo." + SCD_DETAIL_Name + ".d_sc_LID INNER JOIN " +
                         "                     dbo.PSM_R_CFinfo ON dbo.PSM_R_SCD_INFO.sc_CF_LID = dbo.PSM_R_CFinfo.CFLID INNER JOIN  dbo.PSM_R_SCD_ITasks ON dbo." + SCD_DETAIL_Name + ".scd_TILID = dbo.PSM_R_SCD_ITasks.ti_LID INNER JOIN " +
                         "                     dbo.PSM_R_Rev ON dbo.PSM_R_SCD_INFO.sc_IREVID = dbo.PSM_R_Rev.IRRevID " +
                         "                   WHERE     (" + SCD_DETAIL_Name + ".arch =" + _arch  + ") ";//AND (dbo.PSM_R_Rev.shiped <> 'S') AND (dbo.PSM_R_Rev.shiped <> 'T') AND (dbo.PSM_R_Rev.shiped <> 'C') AND (dbo.PSM_R_Rev.shiped <> 'D') ";
          
            
            return MainMDI.Find_One_Field(stSql );


        }

        private void load_cash_arr(int arch )
        {


         //   ldeb.Text = DateTime.Now.ToLongTimeString();
            int intI = -1;
         //   string WHR = (arch == 1) ? " (" + SCD_DETAIL_Name + ".arch <> 0)" : " (" + SCD_DETAIL_Name + ".arch <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C') AND (PSM_R_Rev.shiped <> 'D')";
            string stSql = " SELECT TOP 2000 PSM_R_SCD_INFO.sc_IREVID, PSM_R_SCD_INFO.sc_Name, PSM_R_CFinfo.c_datDlvr, " + SCD_DETAIL_Name + ".scd_Value, PSM_R_SCD_ITasks.ti_XLrnk,  PSM_R_SCD_ITasks.ti_Desc , " + SCD_DETAIL_Name + ".sc_det_LID , PSM_R_SCD_Detail.d_sc_LID" +
                " FROM   PSM_R_SCD_INFO INNER JOIN " + SCD_DETAIL_Name + " ON PSM_R_SCD_INFO.sc_LID = " + SCD_DETAIL_Name + ".d_sc_LID INNER JOIN PSM_R_CFinfo ON PSM_R_SCD_INFO.sc_CF_LID = PSM_R_CFinfo.CFLID INNER JOIN " +
                "        PSM_R_SCD_ITasks ON " + SCD_DETAIL_Name + ".scd_TILID = PSM_R_SCD_ITasks.ti_LID INNER JOIN PSM_R_Rev ON PSM_R_SCD_INFO.sc_IREVID = PSM_R_Rev.IRRevID " +
                " WHERE (" + SCD_DETAIL_Name + ".arch =" + arch.ToString() + ")" +              //PSM_R_SCD_INFO.sc_status <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C')" +
                " ORDER BY PSM_R_CFinfo.c_datDlvr Desc, PSM_R_SCD_INFO.sc_Name, PSM_R_SCD_ITasks.ti_XLrnk ";

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
            string st_bigNB = NBrec_Schedule(arch);//MainMDI.Find_One_Field("select count(*) from V_sched_proj_" + in_affcod);
            int arrMAX = 300, ColMAX = NBCOLLISTING ;
            if (st_bigNB != MainMDI.VIDE)
            {
                ColMAX = lvAllProjects.Columns.Count; 
              //old one  arrMAX = (Int32.Parse(st_bigNB) / ColMAX) +1;
                arrMAX = (Int32.Parse(st_bigNB) / 18) + 1;
                arr_cash_VL = new string[arrMAX, ColMAX];
                arr_cash_TG = new string[arrMAX, ColMAX];
                arr_Estim_Time = new string[arrMAX, 2];
                for (int r = 0; r < arrMAX; r++)
                {
                    arr_Estim_Time[r, 0] = "";
                    arr_Estim_Time[r, 1] = "";
                    for (int j = 0; j < ColMAX; j++)
                    {
                        arr_cash_TG[r, j] = "";
                        arr_cash_VL[r, j] = "";
                    }
                }
            }
            else
            {
                MessageBox.Show("Error  st_bigNB ...");
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
     
                    if (st.IndexOf('/') == 2 && st.IndexOf('/', 3) == 5 && st.Length == 10) st = YYYYMMDD(st);
                    arr_cash_VL[intI, ndx] = (st == MainMDI.VIDE || st == "") ? " " : st;
                    arr_cash_TG[intI, ndx] = Oreadr["sc_det_LID"].ToString();

                    string tt = ""; if (Oreadr["d_sc_LID"].ToString() == "3718") tt=Oreadr["d_sc_LID"].ToString();


                    if (Oreadr["ti_Desc"].ToString() == "Panel duration")
                    {
                        arr_Estim_Time[intI, 0] = CAL_TIME(1, Oreadr["d_sc_LID"].ToString());
                    }
                       if (Oreadr["ti_Desc"].ToString() == "Cabinet duration" )
                    {
                        arr_Estim_Time[intI, 1] = CAL_TIME(2, Oreadr["d_sc_LID"].ToString()); 
                    }


                }
            }
         //   lII.Text = intI.ToString(); this.Refresh();
            lvSorter.SortColumn = -1;
            for (int L = 0; L < intI+1; L++)
            {

                ListViewItem LVV = lvAllProjects.Items.Add(" "); 
                for (int j = 1; j < ColMAX; j++) LVV.SubItems.Add(" ");
                
                
                for (int i = 0; i < ColMAX; i++)
                {

               
                    if ( lvAllProjects.Columns[i].Text  == "Estimated Time" )
                    {
                        if (lvAllProjects.Columns[i - 1].Text == "Panel duration") LVV.SubItems[i].Text = arr_Estim_Time[L, 0];
                        if (lvAllProjects.Columns[i - 1].Text == "Cabinet duration") LVV.SubItems[i].Text = arr_Estim_Time[L, 1];
                    
                    }
                    else
                    {
                        LVV.SubItems[i].Text = arr_cash_VL[L, i];
                        LVV.SubItems[i].Tag = arr_cash_TG[L, i];
                    }


                //    LVV.SubItems[i].Text = arr_cash_VL[L, i];
                 //   LVV.SubItems[i].Tag = arr_cash_TG[L, i];
                    switch (i)
                    {
                        case 9:
                        case 10:
                        case 11:
                        case 12:
                            LVV.UseItemStyleForSubItems = false;
                            LVV.SubItems[i].BackColor = clr_cab  ;
                            LVV.SubItems[i].ForeColor = Color.Black;
                            break;
                        case 13:
                        case 14:
                        case 15:
                        case 16:
                            LVV.UseItemStyleForSubItems = false;
                            LVV.SubItems[i].BackColor = clr_pnl  ;
                            LVV.SubItems[i].ForeColor = Color.Black ;
                            break;
                    }
                }

            }
         //   enable_editLV(true);
            lvAllProjects.EndUpdate();
        //    lfin.Text = DateTime.Now.ToLongTimeString();
        //    this.Refresh();

        }

        string findTIME_STD_OPT(int PAN_CAB, int STD_OPT, string sc_LID)
        {
            double res = 0;

            string tblNM = (STD_OPT == 1) ? " PSM_R_SCD_Detail_STD " : " PSM_R_SCD_Detail_Options ";
            string stsql = "SELECT sum([dura])  FROM " + tblNM + " where sc_LID=" + sc_LID + " and sc_Pnl_Cab=" + PAN_CAB;
            res = Tools.Conv_Dbl(MainMDI.Find_One_Field(stsql));

            return res.ToString();
        }

        string CAL_TIME(int pnl_cab, string Sc_LID)
        {

            double dd = (pnl_cab == 1) ? dd = Tools.Conv_Dbl(findTIME_STD_OPT(1, 1, Sc_LID)) + Tools.Conv_Dbl(findTIME_STD_OPT(1, 2, Sc_LID)) : Tools.Conv_Dbl(findTIME_STD_OPT(2, 1, Sc_LID)) + Tools.Conv_Dbl(findTIME_STD_OPT(2, 2, Sc_LID));

            return dd.ToString();


        }

        private void load_cash_S()
        {

        //    System.Diagnostics.Stopwatch Wdog = new System.Diagnostics.Stopwatch();
       //     Wdog.Reset();
       //     Wdog.Start();
       
            
            int intI = -1;
            string WHR = (in_affcod == 0) ? " (PSM_R_SCD_INFO.sc_status <> 0)" : " (PSM_R_SCD_INFO.sc_status <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C') AND (PSM_R_Rev.shiped <> 'D')";
            string stSql = " SELECT PSM_R_SCD_INFO.sc_IREVID, PSM_R_SCD_INFO.sc_Name, PSM_R_CFinfo.c_datDlvr, " + SCD_DETAIL_Name + ".scd_Value, PSM_R_SCD_ITasks.ti_XLrnk,  PSM_R_SCD_ITasks.ti_Desc , " + SCD_DETAIL_Name + ".sc_det_LID " +
                " FROM   PSM_R_SCD_INFO INNER JOIN " + SCD_DETAIL_Name + " ON PSM_R_SCD_INFO.sc_LID = " + SCD_DETAIL_Name + ".d_sc_LID INNER JOIN PSM_R_CFinfo ON PSM_R_SCD_INFO.sc_CF_LID = PSM_R_CFinfo.CFLID INNER JOIN " +
                "        PSM_R_SCD_ITasks ON " + SCD_DETAIL_Name + ".scd_TILID = PSM_R_SCD_ITasks.ti_LID INNER JOIN PSM_R_Rev ON PSM_R_SCD_INFO.sc_IREVID = PSM_R_Rev.IRRevID " +
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
            string st_bigNB = MainMDI.Find_One_Field("select count(*) from V_sched_proj_" + in_affcod);
            if (st_bigNB != MainMDI.VIDE)
            {
                LVcash = new ListViewItem[Int32.Parse(st_bigNB) + 1];
             //   arr_cash_VL  = new string[Int32.Parse(st_bigNB) + 1, lvAllProjects.Columns.Count];
             //   arr_cash_TG  = new string[Int32.Parse(st_bigNB) + 1, lvAllProjects.Columns.Count];

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
                        LVcash[intI] = new ListViewItem(" ");
                        for (int i = 1; i < lvAllProjects.Columns.Count; i++) LVcash[intI].SubItems.Add(" ");
                        OldCFNm = NCFNm;
                      
                    }
                    int ndx = Int32.Parse(Oreadr["ti_XLrnk"].ToString()) - 1;
                    string st = Oreadr["scd_Value"].ToString();
                    //  DateTime.Parse (st);    
                    if (st.IndexOf('/') == 2 && st.IndexOf('/', 3) == 5 && st.Length == 10) st = YYYYMMDD(st);
                   LVcash[intI].SubItems[ndx].Text  = (st == MainMDI.VIDE || st == "") ? " " : st;
                   LVcash[intI].SubItems[ndx].Tag  = Oreadr["sc_det_LID"].ToString();
                   
                }
            }
         //   Wdog.Stop();
        //    MessageBox.Show("temps en ms=" + Wdog.ElapsedMilliseconds);
            
            for (int TT=0;TT<intI ;TT++)
            {
               ListViewItem  lvI = lvAllProjects.Items.Add(" ");for (int i = 1; i < lvAllProjects.Columns.Count; i++) lvI.SubItems.Add(" ");
                for (int j = 0; j < lvAllProjects.Columns.Count; j++) 
                {
                    lvI.SubItems[j].Text =LVcash[TT].SubItems[j].Text ; 
                    lvI.SubItems[j].Tag= LVcash[TT].SubItems[j].Tag  ; 
                }
            }
            lvAllProjects.Refresh();

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

            if (grpPRCT.Visible && grpPRCTS.Visible  ) select_col(e.Column );
            else
            {

                // OLDcol = e.Column; 
                //MessageBox.Show (   e.Column.ToString()  );

                //  btnseek.Text = "Search by:    " + lvQuotes.Columns[e.Column].Text;
                btnseekPN.Enabled =(e.Column == 1);
                btnseekSN.Enabled = (e.Column == 2); 
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

        private void fill_emp()
        {
            string whr = (in_EM == 'E') ? " [Grp]in ('E','F') " : " [Grp]in ('M','N') ";
            string stsql = " SELECT  [Emp_Name]  ,[Emp_ID] FROM [Orig_PSM_FDB].[dbo].[PSM_R_SCD_Emp] where " + whr + " order by Emp_Name ";
            MainMDI.fill_Any_CB(CB_Panel_Emp, stsql, true, "Select Employee");
           // MainMDI.fill_Any_CB(CB_Cab_Emp, stsql, true, "SELECT");
        }



        private void OR_Sched_projects_NEW_Load(object sender, EventArgs e)
        {
           

            this.Cursor = Cursors.WaitCursor;

                        string st = (in_EM == 'E') ? "ELECTRICAL" : "MECANICAL";
            this.Text = "                                                              " +st +" Schedule  List  ";
       //     curr_clr = (in_EM == 'E') ? Color.LightGoldenrodYellow : Color.Honeydew;

            curr_clr = (in_EM == 'E') ? Color.Wheat : Color.LightBlue;

            lvAllProjects.BackColor = curr_clr;
            lvAllProjects.ForeColor = (in_EM == 'E') ? Color.Black : Color.Black;
            SCD_DETAIL_Name = (in_EM == 'E') ? "PSM_R_SCD_Detail" : "PSM_R_SCD_Detail_Meca";
            init_CHnn();
            fill_st_editable();
            fill_emp();
       //     load_SubProj();  old display was slow
          load_cash_arr(0);


            this.Cursor = Cursors.Default;
            PBWait.Visible = false;
            TSpbar.Visible = false;

        //    Back_lvAllProjects = lvAllProjects;
            for (int i = 0; i < lvAllProjects.Items.Count; i++)
            {
                ListViewItem lvI = Back_lvAllProjects.Items.Add(lvAllProjects.Items[i].SubItems[0].Text);
                for (int c = 1; c < lvAllProjects.Columns.Count; c++)
                    lvI.SubItems.Add(lvAllProjects.Items[i].SubItems[c].Text);

            }
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

                object[] objHdrs = { "Project#", "Customer", "Delivery Date", "Model", "Serial#", "AMP", "Enclosure (ARM)", "HARNAIS", "Options", "Employee Name", "Panel Start", "Panel End", "Panel duration", "Employee Name", "Cabinet Start", "Cabinet End", "Cabinet duration", "Missing", "Notes" };
                Excel.Range m_objRng = m_objSheet.get_Range("A1", "S1"); // "C1", "D1", "E1", "F1", "G1", "H1", "I1", "J1", "K1", "L1", "M1", "N1", "O1", "P1", "Q1", "R1", "S1", "T1", "U1");
                m_objRng.Value2 = objHdrs;
                Excel.Font m_objFont = m_objRng.Font;
                m_objFont.Bold = true;

               // object[,] objData = new object[MainMDI.MAX_XL_SChedule, 21];
                object[,] objData = new object[lvAllProjects.Items.Count, NBCOLLISTING];
                for (int i = 0; i < lvAllProjects.Items.Count; i++)
                {
                    for (int j = 0; j < NBCOLLISTING; j++)
                        objData[i, j] = lvAllProjects.Items[i].SubItems[j].Text;
                    //  objData[i, 1] = (i < lvQuotes.Items.Count) ? lvQuotes.Items[i].SubItems[2].Text : "";
                }

                m_objRng = m_objSheet.get_Range("A2", m_objOpt);
                m_objRng = m_objRng.get_Resize(lvAllProjects.Items.Count, NBCOLLISTING);
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

  //        grpPRCT.Visible = true;
 //         grpSeek.Visible = false;
  //        enable_editLV(!grpPRCT.Visible);

            grpPRCT.Visible = true;
            grpVEB.Visible = true;
            grpSeek.Visible = false; 


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

        private void fndP_Click(object sender, EventArgs e)
        {
           
            grpPRCT.Visible = true;
            grpVEB.Visible = true;
           grpSeek.Visible = true;
           dpFrom.Value = DateTime.Now;
           dpTo.Value = DateTime.Now;
           btnDate_Click(sender, e);



        }


        void disp_grp(int grp)
        {
            grpPRCT.Visible = true;
            grpPRCTS.Visible = (grp == 2 || grp == 3);
            grpSeek.Visible = (grp == 1);
        }

        private void label2_Click(object sender, EventArgs e)
        {
            grpPRCT.Visible = false;
            enable_editLV(!grpPRCT.Visible);
        }

        private void tKey_TextChanged(object sender, EventArgs e)
        {
            btnseekPN.Enabled = (tKey.Text.Length > 3);
           btnseekSN.Enabled = (tKey.Text.Length > 3);
         
        }

        private void btnseekPN_ClickOLD(object sender, EventArgs e)
        {
            ListViewItem itm= (lvAllProjects.FindItemWithText(tKey.Text )) ;
            if (itm == null) MessageBox.Show("Not Found.......");
            else
            {
                //MessageBox.Show("ndx= " + itm.Index.ToString ()); 
           
             //   lvAllProjects.Items[itm.Index].Selected =true ;
             //   lvAllProjects.Select();
                if (lFndx.Text != "") Sel_lvPrj(Int32.Parse(lFndx.Text), false);
            //    lvAllProjects.TopItem = lvAllProjects.Items[itm.Index-2];
                lvAllProjects.EnsureVisible(itm.Index);
                Sel_lvPrj(itm.Index, true);
                lFndx.Text = itm.Index.ToString();
            }
        }


        private void btnseekPN_Click(object sender, EventArgs e)
        {

            lvAllProjects.Items.Clear();
            for (int i = 0; i < Back_lvAllProjects.Items.Count; i++)
            {
                if (Back_lvAllProjects.Items[i].SubItems[0].Text == tKey.Text)
                {
                  NLine_lvAll();
                  for (int c = 0; c < lvAllProjects.Columns.Count; c++)
                      lvAllProjects.Items[lvAllProjects.Items.Count - 1].SubItems[c].Text  = Back_lvAllProjects.Items[i].SubItems[c].Text;       
                }
            }
 

        }

        private void btnseekSN_Clickold(object sender, EventArgs e)
        {
            if (tKey.Text.Length > 0 && tKey.Text[0] != 'S') tKey.Text = "S" + tKey.Text;
            ListViewItem itm = (lvAllProjects.FindItemWithText(tKey.Text));
            if (itm == null) MessageBox.Show("Not Found.......");
            else
            {
                //MessageBox.Show("ndx= " + itm.Index.ToString()); 
                 
              //  if (lFndx.Text != "") Sel_lvPrj(Int32.Parse(lFndx.Text), false);
                
                lvAllProjects.EnsureVisible(itm.Index);
                Sel_lvPrj(itm.Index, true);
                lFndx.Text = itm.Index.ToString();
            }
        }

        private void btnseekSN_Click(object sender, EventArgs e)
        {
            lvAllProjects.Items.Clear();
            for (int i = 0; i < Back_lvAllProjects.Items.Count; i++)
            {
                if (Back_lvAllProjects.Items[i].SubItems[1].Text == tKey.Text)
                {
                    NLine_lvAll();
                    for (int c = 0; c < lvAllProjects.Columns.Count; c++)
                        lvAllProjects.Items[lvAllProjects.Items.Count - 1].SubItems[c].Text = Back_lvAllProjects.Items[i].SubItems[c].Text;
                }
            }
        }

        private void Sel_lvPrj(int _ndx,bool _stat)
        {
            lvAllProjects.SelectedItems.Clear(); 
            lvAllProjects.Items[_ndx ].Selected = _stat;
            lvAllProjects.Select();

        }

        private void dpFrom_ValueChanged(object sender, EventArgs e)
        {

            btnDate.Enabled = true;
            dateFROM.Text = dpFrom.Value.Year + "/" + MainMDI.A00(dpFrom.Value.Month, 2) + "/" + MainMDI.A00(dpFrom.Value.Day, 2); 
          //  dateFROM.Text = dpFrom.Value.Year + MainMDI.A00(dpFrom.Value.Month, 2) + MainMDI.A00(dpFrom.Value.Day, 2); 

        }

        private void btnDate_Clickold(object sender, EventArgs e)
        {
            ListViewItem itm= (lvAllProjects.FindItemWithText(tKey.Text )) ;
            if (itm == null) MessageBox.Show("Not Found.......");
            else
            {
                
                //MessageBox.Show("ndx= " + itm.Index.ToString ()); 
           
             //   lvAllProjects.Items[itm.Index].Selected =true ;
             //   lvAllProjects.Select();
                if (lFndx.Text != "") Sel_lvPrj(Int32.Parse(lFndx.Text), false);
            //    lvAllProjects.TopItem = lvAllProjects.Items[itm.Index-2];
                lvAllProjects.EnsureVisible(itm.Index);
                Sel_lvPrj(itm.Index, true);
                lFndx.Text = itm.Index.ToString();
            }
     
        }

        private long date_val(string dt)
        {
            string res = "";
            try
            {
                res = dt.Substring(0, 4) + dt.Substring(5, 2) + dt.Substring(8, 2);
                return  Convert.ToInt64(res);
            }
            catch (Exception ex)
            {
                res = ex.Message;
                return 0;
            }

        }


        private void btnDate_Click(object sender, EventArgs e)
        {
            lvAllProjects.Items.Clear();
            for (int i = 0; i < Back_lvAllProjects.Items.Count; i++)
            {
                if (date_val(Back_lvAllProjects.Items[i].SubItems[2].Text) >= date_val(dateFROM.Text) && date_val(Back_lvAllProjects.Items[i].SubItems[2].Text) <= date_val(dateTO.Text)) 
                {
                    NLine_lvAll();
                    for (int c = 0; c < lvAllProjects.Columns.Count; c++)
                        lvAllProjects.Items[lvAllProjects.Items.Count - 1].SubItems[c].Text = Back_lvAllProjects.Items[i].SubItems[c].Text;
                }
            }

        }


        private void copy_TOBACKLV()
        {

            //    Back_lvAllProjects = lvAllProjects;
            Back_lvAllProjects.Items.Clear();
            for (int i = 0; i < lvAllProjects.Items.Count; i++)
            {
                ListViewItem lvI = Back_lvAllProjects.Items.Add(lvAllProjects.Items[i].SubItems[0].Text);
                for (int c = 1; c < lvAllProjects.Columns.Count; c++)
                    lvI.SubItems.Add(lvAllProjects.Items[i].SubItems[c].Text);

            }
        }
        private void load_all_project(int arch)
        {
            load_cash_arr(arch);
            copy_TOBACKLV();

        //    this.Cursor = Cursors.Default;
          //  PBWait.Visible = false;
          //  TSpbar.Visible = false;

         

        }

        private void allinProcess()
        {
            lvAllProjects.Items.Clear();
            for (int i = 0; i < Back_lvAllProjects.Items.Count; i++)
            {
                NLine_lvAll();
                for (int c = 0; c < lvAllProjects.Columns.Count; c++)
                    lvAllProjects.Items[lvAllProjects.Items.Count - 1].SubItems[c].Text = Back_lvAllProjects.Items[i].SubItems[c].Text;
            }
            this.lvAllProjects.Refresh(); 
        }

        private void btn_displayALL_Click(object sender, EventArgs e)
        {
           // lvAllProjects = Back_lvAllProjects;


        }

        private void dpTo_ValueChanged(object sender, EventArgs e)
        {
            btnDate.Visible = true;
            dateTO.Text = dpTo.Value.Year + "/" + MainMDI.A00(dpTo.Value.Month, 2) + "/" + MainMDI.A00(dpTo.Value.Day, 2); 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            grpSeek.Visible = true;
        }

        private void btn_addPRJ_Click(object sender, EventArgs e)
        {



         //   OR_ToSched ts = new OR_ToSched(RID,iRRevID,cpny);
          //  ts.ShowDialog();
        }

        private void lvAllProjects_Click(object sender, EventArgs e)
        {
            int ndx = lvAllProjects.SelectedItems[0].Index;
            lsc_LID.Text =MainMDI.Find_One_Field (" SELECT [d_sc_LID]  FROM [Orig_PSM_FDB].[dbo].[" + SCD_DETAIL_Name + "] where sc_det_LID=" + lvAllProjects.Items[ndx].SubItems[0].Tag.ToString()); 
        }


        private bool valid_ToArch(int ndx)
        {

            for (int i = 9; i < 17; i++)
                if (lvAllProjects.Items[ndx].SubItems[i].Text == " ") return false;
            return true;
        }
        private void addArch_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("SC_EL_G", true) || MainMDI.ALWD_USR("SC_M_G",false))
            {
                for (int i = lvAllProjects.SelectedItems.Count - 1; i > -1; i--)
                {
                    int ndx = lvAllProjects.SelectedItems[i].Index;
                    if (valid_ToArch(ndx))
                    {
                        string sc_LID = MainMDI.Find_One_Field(" SELECT [d_sc_LID]  FROM [Orig_PSM_FDB].[dbo].[" + SCD_DETAIL_Name + "] where sc_det_LID=" + lvAllProjects.Items[ndx].SubItems[0].Tag.ToString());
                        MainMDI.Exec_SQL_JFS("update dbo." + SCD_DETAIL_Name + " set arch=1 where d_sc_LID=" + sc_LID, "archive sc_details");
                        lvAllProjects.Items[lvAllProjects.SelectedItems[i].Index].Remove();
                    }
                    else
                    {
                        MessageBox.Show("Sorry cannot Archive,  Cabinet Info / Panel Info  must be completed.....contact Admin...");
                        i = -1;
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void inPRO_Click(object sender, EventArgs e)
        {
            lvAllProjects.ForeColor = Color.Black; ;// Color.Blue;  
            lvAllProjects.Items.Clear();
            load_all_project(0);
        }

        private void Arch_prj_Click(object sender, EventArgs e)
        {
            lvAllProjects.ForeColor = Color.Black;
            lvAllProjects.Items.Clear();
            load_all_project(1);
        }

        private void btn_seekNM_Click(object sender, EventArgs e)
        {
            if (CB_Panel_Emp.Text != "Select Employee" && CB_Panel_Emp.Text != "")
            {
                lvAllProjects.Items.Clear();
                for (int i = 0; i < Back_lvAllProjects.Items.Count; i++)
                {
                    if (Back_lvAllProjects.Items[i].SubItems[9].Text == CB_Panel_Emp.Text || Back_lvAllProjects.Items[i].SubItems[13].Text == CB_Panel_Emp.Text)
                    {
                        NLine_lvAll();
                        for (int c = 0; c < lvAllProjects.Columns.Count; c++)
                            lvAllProjects.Items[lvAllProjects.Items.Count - 1].SubItems[c].Text = Back_lvAllProjects.Items[i].SubItems[c].Text;
                    }
                }
            }
 
        }

        private void CB_Panel_Emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            btn_seekNM.Enabled = true; 
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            //fill_emp();
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
         //   fill_emp();
        }







    }



}
