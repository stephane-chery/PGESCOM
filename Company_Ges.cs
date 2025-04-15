using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using EAHLibs;
using System.Threading;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for Ges_Company.
	/// </summary>
	public class Company_Ges : System.Windows.Forms.Form
	{
	    //private string MainMDI._connectionString;
		private string In_user_Name;
		private int oldSC = 0;
		private char srtType = 'A';
		private int seelCol = 0;
		private int ndxCLRD = -1;
        private static Lib1 Tools = new Lib1();
        private string G_msg = "";

        //threads
        Thread m_WkTHRD;
		ManualResetEvent m_EventStopThread;
		ManualResetEvent m_EventThreadStopped;
		public deleg_RepTrace m_RepTrace;
		public deleg_endTHR m_endTHR;
        //thrd functions

		private ListViewColumnSorter lvSorter=null;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolBarButton add;
		private System.Windows.Forms.ToolBarButton del;
		private System.Windows.Forms.ToolBarButton edit;
		private System.Windows.Forms.ToolBarButton exit;
		private System.Windows.Forms.PictureBox picExit;
		private System.Windows.Forms.ToolBarButton fix;
		private System.Windows.Forms.GroupBox grpFind;
		private System.Windows.Forms.Button btnseek;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolBarButton Find;
		public System.Windows.Forms.TextBox tKey;
		private System.Windows.Forms.ImageList Fst_IL32;
        private GroupBox grpSrch;
        private GroupBox groupBox1;
        private ListView lvCompany;
        private ColumnHeader cpnyName;
        private ColumnHeader phone;
        private ColumnHeader EMAIL;
        private ColumnHeader adrs;
        private ColumnHeader cpnyID;
        public PictureBox picCIP;
        private ColumnHeader SYSP_id;
        private GroupBox grpSync;
        private Button btnSync_All;
        private Button btnSync1;
        private Label label3;
        public TextBox tkeySync;
        private System.Windows.Forms.Timer timer1;
        private ToolStrip TSmain;
        private ToolStripButton Newcpny;
        private ToolStripButton toolStripButton2;
        private ToolStripButton del_cpny;
        private ToolStripButton seek_cpny;
        private ToolStripButton tls_contact;
        private ToolStripButton tls_Agencies;
        private ToolStripButton toolStripButton1;
        private ToolStripButton exiit;
        private ToolStripLabel SyncLBL;
        private Button btnLastCode;
        public TextBox txABB;
        private Label label4;
        public TextBox textBox2;
        public ComboBox cbBranch;
        private ListView SYSPRO_LIST;
        private ColumnHeader columnHeader1;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader6;
		private System.ComponentModel.IContainer components;

		public Company_Ges()
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();
			In_user_Name = MainMDI.User;
			MainMDI.M_stCon = MainMDI.M_stCon;

			lvSorter = new ListViewColumnSorter();
			this.lvCompany.ListViewItemSorter = lvSorter;
			lvCompany.Sorting = System.Windows.Forms.SortOrder.Ascending;
			lvCompany.AutoArrange = true;
	    	fill_lvCmpny_Fast(0);
			btnseek.Text = "Search by:    " + lvCompany.Columns[0].Text;
			seelCol = 0;

            //thrd functions
            m_RepTrace = new deleg_RepTrace(this.disp_trace);
            m_endTHR = new deleg_endTHR(this.endTHRmsg);
            m_EventStopThread = new ManualResetEvent(false);
            m_EventThreadStopped = new ManualResetEvent(false);

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Company_Ges));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.add = new System.Windows.Forms.ToolBarButton();
            this.edit = new System.Windows.Forms.ToolBarButton();
            this.del = new System.Windows.Forms.ToolBarButton();
            this.exit = new System.Windows.Forms.ToolBarButton();
            this.fix = new System.Windows.Forms.ToolBarButton();
            this.Find = new System.Windows.Forms.ToolBarButton();
            this.Fst_IL32 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.grpFind = new System.Windows.Forms.GroupBox();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.Newcpny = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.del_cpny = new System.Windows.Forms.ToolStripButton();
            this.seek_cpny = new System.Windows.Forms.ToolStripButton();
            this.tls_contact = new System.Windows.Forms.ToolStripButton();
            this.tls_Agencies = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.exiit = new System.Windows.Forms.ToolStripButton();
            this.SyncLBL = new System.Windows.Forms.ToolStripLabel();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.btnseek = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tKey = new System.Windows.Forms.TextBox();
            this.grpSrch = new System.Windows.Forms.GroupBox();
            this.grpSync = new System.Windows.Forms.GroupBox();
            this.btnSync_All = new System.Windows.Forms.Button();
            this.btnSync1 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.tkeySync = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.cbBranch = new System.Windows.Forms.ComboBox();
            this.txABB = new System.Windows.Forms.TextBox();
            this.btnLastCode = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.SYSPRO_LIST = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvCompany = new System.Windows.Forms.ListView();
            this.cpnyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EMAIL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.adrs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cpnyID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SYSP_id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.picExit = new System.Windows.Forms.PictureBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.grpFind.SuspendLayout();
            this.TSmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.grpSrch.SuspendLayout();
            this.grpSync.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.AutoSize = false;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.add,
            this.edit,
            this.del,
            this.exit,
            this.fix,
            this.Find});
            this.toolBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
            this.toolBar1.ImageList = this.Fst_IL32;
            this.toolBar1.Location = new System.Drawing.Point(922, 11);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(17, 44);
            this.toolBar1.TabIndex = 1;
            this.toolBar1.Visible = false;
            // 
            // add
            // 
            this.add.ImageIndex = 0;
            this.add.Name = "add";
            this.add.Text = "New Company";
            // 
            // edit
            // 
            this.edit.ImageIndex = 2;
            this.edit.Name = "edit";
            this.edit.Text = "Edit Company";
            // 
            // del
            // 
            this.del.ImageIndex = 1;
            this.del.Name = "del";
            this.del.Text = "Delete Company";
            this.del.Visible = false;
            // 
            // exit
            // 
            this.exit.ImageIndex = 3;
            this.exit.Name = "exit";
            this.exit.Text = "Exit";
            this.exit.Visible = false;
            // 
            // fix
            // 
            this.fix.Enabled = false;
            this.fix.Name = "fix";
            this.fix.Text = "Fix-ADRS";
            this.fix.Visible = false;
            // 
            // Find
            // 
            this.Find.ImageIndex = 1;
            this.Find.Name = "Find";
            this.Find.Text = "Find Company";
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
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(608, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // grpFind
            // 
            this.grpFind.Controls.Add(this.TSmain);
            this.grpFind.Controls.Add(this.picCIP);
            this.grpFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFind.ForeColor = System.Drawing.Color.Blue;
            this.grpFind.Location = new System.Drawing.Point(0, 0);
            this.grpFind.Name = "grpFind";
            this.grpFind.Size = new System.Drawing.Size(1202, 88);
            this.grpFind.TabIndex = 202;
            this.grpFind.TabStop = false;
            // 
            // TSmain
            // 
            this.TSmain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TSmain.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Newcpny,
            this.toolStripButton2,
            this.del_cpny,
            this.seek_cpny,
            this.tls_contact,
            this.tls_Agencies,
            this.toolStripButton1,
            this.exiit,
            this.SyncLBL});
            this.TSmain.Location = new System.Drawing.Point(3, 16);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(1196, 69);
            this.TSmain.TabIndex = 267;
            this.TSmain.Text = "toolStrip2";
            // 
            // Newcpny
            // 
            this.Newcpny.ForeColor = System.Drawing.Color.Black;
            this.Newcpny.Image = ((System.Drawing.Image)(resources.GetObject("Newcpny.Image")));
            this.Newcpny.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Newcpny.Name = "Newcpny";
            this.Newcpny.Size = new System.Drawing.Size(90, 66);
            this.Newcpny.Text = "New Company";
            this.Newcpny.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Newcpny.ToolTipText = "New Company";
            this.Newcpny.Click += new System.EventHandler(this.Newcpny_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.ForeColor = System.Drawing.Color.Black;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(81, 66);
            this.toolStripButton2.Text = "SYSPRO Sync";
            this.toolStripButton2.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // del_cpny
            // 
            this.del_cpny.ForeColor = System.Drawing.Color.Black;
            this.del_cpny.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del_cpny.Name = "del_cpny";
            this.del_cpny.Size = new System.Drawing.Size(99, 66);
            this.del_cpny.Text = "Delete Company";
            this.del_cpny.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.del_cpny.ToolTipText = "Delete Company";
            this.del_cpny.Visible = false;
            // 
            // seek_cpny
            // 
            this.seek_cpny.ForeColor = System.Drawing.Color.Black;
            this.seek_cpny.Image = ((System.Drawing.Image)(resources.GetObject("seek_cpny.Image")));
            this.seek_cpny.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seek_cpny.Name = "seek_cpny";
            this.seek_cpny.Size = new System.Drawing.Size(89, 66);
            this.seek_cpny.Text = "Find Company";
            this.seek_cpny.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.seek_cpny.ToolTipText = "Save Company";
            this.seek_cpny.Click += new System.EventHandler(this.seek_cpny_Click);
            // 
            // tls_contact
            // 
            this.tls_contact.ForeColor = System.Drawing.Color.Black;
            this.tls_contact.Image = ((System.Drawing.Image)(resources.GetObject("tls_contact.Image")));
            this.tls_contact.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_contact.Name = "tls_contact";
            this.tls_contact.Size = new System.Drawing.Size(124, 66);
            this.tls_contact.Text = "Companies Contacts ";
            this.tls_contact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_contact.Click += new System.EventHandler(this.tls_contact_Click);
            // 
            // tls_Agencies
            // 
            this.tls_Agencies.ForeColor = System.Drawing.Color.Black;
            this.tls_Agencies.Image = ((System.Drawing.Image)(resources.GetObject("tls_Agencies.Image")));
            this.tls_Agencies.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Agencies.Name = "tls_Agencies";
            this.tls_Agencies.Size = new System.Drawing.Size(185, 66);
            this.tls_Agencies.Text = "             Agencies  /  Agents           ";
            this.tls_Agencies.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Agencies.Click += new System.EventHandler(this.tls_Agencies_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(126, 66);
            this.toolStripButton1.Text = "update SYSPRO_Code";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Visible = false;
            // 
            // exiit
            // 
            this.exiit.ForeColor = System.Drawing.Color.Black;
            this.exiit.Image = ((System.Drawing.Image)(resources.GetObject("exiit.Image")));
            this.exiit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exiit.Name = "exiit";
            this.exiit.Size = new System.Drawing.Size(52, 66);
            this.exiit.Text = "   Exit   ";
            this.exiit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exiit.ToolTipText = "Exit";
            this.exiit.Click += new System.EventHandler(this.exiit_Click);
            // 
            // SyncLBL
            // 
            this.SyncLBL.AutoSize = false;
            this.SyncLBL.BackColor = System.Drawing.Color.Gold;
            this.SyncLBL.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.SyncLBL.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SyncLBL.ForeColor = System.Drawing.Color.Red;
            this.SyncLBL.Name = "SyncLBL";
            this.SyncLBL.Size = new System.Drawing.Size(200, 51);
            this.SyncLBL.Visible = false;
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(871, 19);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(39, 42);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 266;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // btnseek
            // 
            this.btnseek.BackColor = System.Drawing.Color.Khaki;
            this.btnseek.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnseek.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnseek.ForeColor = System.Drawing.Color.Black;
            this.btnseek.Location = new System.Drawing.Point(411, 9);
            this.btnseek.Name = "btnseek";
            this.btnseek.Size = new System.Drawing.Size(257, 24);
            this.btnseek.TabIndex = 161;
            this.btnseek.Text = "Search by:";
            this.btnseek.UseVisualStyleBackColor = false;
            this.btnseek.Click += new System.EventHandler(this.btnseek_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(3, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 160;
            this.label2.Text = "Keyword:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.PeachPuff;
            this.tKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.ForeColor = System.Drawing.Color.Black;
            this.tKey.Location = new System.Drawing.Point(85, 11);
            this.tKey.MaxLength = 60;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(320, 20);
            this.tKey.TabIndex = 159;
            // 
            // grpSrch
            // 
            this.grpSrch.Controls.Add(this.grpSync);
            this.grpSrch.Controls.Add(this.label4);
            this.grpSrch.Controls.Add(this.textBox2);
            this.grpSrch.Controls.Add(this.cbBranch);
            this.grpSrch.Controls.Add(this.txABB);
            this.grpSrch.Controls.Add(this.toolBar1);
            this.grpSrch.Controls.Add(this.btnseek);
            this.grpSrch.Controls.Add(this.label2);
            this.grpSrch.Controls.Add(this.tKey);
            this.grpSrch.Controls.Add(this.btnLastCode);
            this.grpSrch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSrch.Location = new System.Drawing.Point(0, 88);
            this.grpSrch.Name = "grpSrch";
            this.grpSrch.Size = new System.Drawing.Size(1202, 70);
            this.grpSrch.TabIndex = 204;
            this.grpSrch.TabStop = false;
            this.grpSrch.Visible = false;
            // 
            // grpSync
            // 
            this.grpSync.Controls.Add(this.btnSync_All);
            this.grpSync.Controls.Add(this.btnSync1);
            this.grpSync.Controls.Add(this.label3);
            this.grpSync.Controls.Add(this.tkeySync);
            this.grpSync.Location = new System.Drawing.Point(7, 11);
            this.grpSync.Name = "grpSync";
            this.grpSync.Size = new System.Drawing.Size(945, 53);
            this.grpSync.TabIndex = 162;
            this.grpSync.TabStop = false;
            // 
            // btnSync_All
            // 
            this.btnSync_All.BackColor = System.Drawing.Color.Khaki;
            this.btnSync_All.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync_All.Location = new System.Drawing.Point(546, 19);
            this.btnSync_All.Name = "btnSync_All";
            this.btnSync_All.Size = new System.Drawing.Size(218, 24);
            this.btnSync_All.TabIndex = 169;
            this.btnSync_All.Text = "SYNC. all Companies";
            this.btnSync_All.UseVisualStyleBackColor = false;
            this.btnSync_All.Click += new System.EventHandler(this.btnSync_All_Click);
            // 
            // btnSync1
            // 
            this.btnSync1.BackColor = System.Drawing.Color.Khaki;
            this.btnSync1.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSync1.Location = new System.Drawing.Point(359, 19);
            this.btnSync1.Name = "btnSync1";
            this.btnSync1.Size = new System.Drawing.Size(156, 24);
            this.btnSync1.TabIndex = 168;
            this.btnSync1.Text = "SYNC. ONE  Company";
            this.btnSync1.UseVisualStyleBackColor = false;
            this.btnSync1.Click += new System.EventHandler(this.btnSync1_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Firebrick;
            this.label3.Location = new System.Drawing.Point(39, 18);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(143, 20);
            this.label3.TabIndex = 167;
            this.label3.Text = "Company Code:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tkeySync
            // 
            this.tkeySync.BackColor = System.Drawing.Color.PeachPuff;
            this.tkeySync.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tkeySync.ForeColor = System.Drawing.Color.Black;
            this.tkeySync.Location = new System.Drawing.Point(182, 21);
            this.tkeySync.MaxLength = 60;
            this.tkeySync.Name = "tkeySync";
            this.tkeySync.Size = new System.Drawing.Size(177, 20);
            this.tkeySync.TabIndex = 166;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(3, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 482;
            this.label4.Text = "ABC---U";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.PeachPuff;
            this.textBox2.Font = new System.Drawing.Font("Footlight MT Light", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(131, 38);
            this.textBox2.MaxLength = 60;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(35, 22);
            this.textBox2.TabIndex = 481;
            this.textBox2.Text = "***";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // cbBranch
            // 
            this.cbBranch.BackColor = System.Drawing.Color.PeachPuff;
            this.cbBranch.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbBranch.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbBranch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbBranch.Items.AddRange(new object[] {
            "U",
            "C",
            "E",
            "all"});
            this.cbBranch.Location = new System.Drawing.Point(166, 37);
            this.cbBranch.Name = "cbBranch";
            this.cbBranch.Size = new System.Drawing.Size(60, 24);
            this.cbBranch.TabIndex = 480;
            // 
            // txABB
            // 
            this.txABB.BackColor = System.Drawing.Color.PeachPuff;
            this.txABB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txABB.ForeColor = System.Drawing.Color.Black;
            this.txABB.Location = new System.Drawing.Point(85, 38);
            this.txABB.MaxLength = 3;
            this.txABB.Name = "txABB";
            this.txABB.Size = new System.Drawing.Size(46, 22);
            this.txABB.TabIndex = 164;
            this.txABB.Text = "ABB";
            this.txABB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // btnLastCode
            // 
            this.btnLastCode.BackColor = System.Drawing.Color.Khaki;
            this.btnLastCode.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLastCode.ForeColor = System.Drawing.Color.Black;
            this.btnLastCode.Location = new System.Drawing.Point(230, 37);
            this.btnLastCode.Name = "btnLastCode";
            this.btnLastCode.Size = new System.Drawing.Size(305, 24);
            this.btnLastCode.TabIndex = 163;
            this.btnLastCode.Text = "SYSPRO code list ";
            this.btnLastCode.UseVisualStyleBackColor = false;
            this.btnLastCode.Click += new System.EventHandler(this.btnLastCode_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.SYSPRO_LIST);
            this.groupBox1.Controls.Add(this.lvCompany);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 158);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1202, 372);
            this.groupBox1.TabIndex = 206;
            this.groupBox1.TabStop = false;
            // 
            // SYSPRO_LIST
            // 
            this.SYSPRO_LIST.BackColor = System.Drawing.Color.AliceBlue;
            this.SYSPRO_LIST.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader4,
            this.columnHeader6});
            this.SYSPRO_LIST.Dock = System.Windows.Forms.DockStyle.Fill;
            this.SYSPRO_LIST.ForeColor = System.Drawing.Color.Blue;
            this.SYSPRO_LIST.FullRowSelect = true;
            this.SYSPRO_LIST.GridLines = true;
            this.SYSPRO_LIST.HideSelection = false;
            this.SYSPRO_LIST.Location = new System.Drawing.Point(3, 16);
            this.SYSPRO_LIST.MultiSelect = false;
            this.SYSPRO_LIST.Name = "SYSPRO_LIST";
            this.SYSPRO_LIST.Size = new System.Drawing.Size(1196, 353);
            this.SYSPRO_LIST.TabIndex = 2;
            this.SYSPRO_LIST.UseCompatibleStateImageBehavior = false;
            this.SYSPRO_LIST.View = System.Windows.Forms.View.Details;
            this.SYSPRO_LIST.Visible = false;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Name";
            this.columnHeader1.Width = 228;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "Main Address";
            this.columnHeader4.Width = 389;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "SYSPRO CODE";
            this.columnHeader6.Width = 120;
            // 
            // lvCompany
            // 
            this.lvCompany.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvCompany.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cpnyName,
            this.phone,
            this.EMAIL,
            this.adrs,
            this.cpnyID,
            this.SYSP_id});
            this.lvCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCompany.ForeColor = System.Drawing.Color.Blue;
            this.lvCompany.FullRowSelect = true;
            this.lvCompany.GridLines = true;
            this.lvCompany.HideSelection = false;
            this.lvCompany.Location = new System.Drawing.Point(3, 16);
            this.lvCompany.MultiSelect = false;
            this.lvCompany.Name = "lvCompany";
            this.lvCompany.Size = new System.Drawing.Size(1196, 353);
            this.lvCompany.TabIndex = 1;
            this.lvCompany.UseCompatibleStateImageBehavior = false;
            this.lvCompany.View = System.Windows.Forms.View.Details;
            this.lvCompany.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvCompany_ColumnClick);
            this.lvCompany.SelectedIndexChanged += new System.EventHandler(this.lvCompany_SelectedIndexChanged);
            this.lvCompany.DoubleClick += new System.EventHandler(this.lvCompany_DoubleClick);
            // 
            // cpnyName
            // 
            this.cpnyName.Text = "Name";
            this.cpnyName.Width = 228;
            // 
            // phone
            // 
            this.phone.Text = "Phone";
            this.phone.Width = 98;
            // 
            // EMAIL
            // 
            this.EMAIL.Text = "E-mail";
            this.EMAIL.Width = 127;
            // 
            // adrs
            // 
            this.adrs.Text = "Main Address";
            this.adrs.Width = 389;
            // 
            // cpnyID
            // 
            this.cpnyID.Text = "";
            this.cpnyID.Width = 0;
            // 
            // SYSP_id
            // 
            this.SYSP_id.Text = "SYSPRO CODE";
            this.SYSP_id.Width = 120;
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.Image = ((System.Drawing.Image)(resources.GetObject("picExit.Image")));
            this.picExit.Location = new System.Drawing.Point(736, 8);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(40, 40);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 200;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Company_Ges
            // 
            this.AcceptButton = this.btnseek;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1202, 530);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSrch);
            this.Controls.Add(this.grpFind);
            this.Controls.Add(this.picExit);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Company_Ges";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ges_Company";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ges_Company_Load);
            this.Resize += new System.EventHandler(this.Ges_Company_Resize);
            this.grpFind.ResumeLayout(false);
            this.grpFind.PerformLayout();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.grpSrch.ResumeLayout(false);
            this.grpSrch.PerformLayout();
            this.grpSync.ResumeLayout(false);
            this.grpSync.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        public void disp_trace(string trace)
        {
            SyncLBL.Text = trace;
            TSmain.Refresh();
            //this.Refresh();
        }

        public void endTHRmsg(string msg)
        {
            //SyncLBL.Text = msg;
            SyncLBL.Visible = false;
            this.Cursor = Cursors.Default;
            MessageBox.Show("Companies SYNC. Done...........");
        }

        /*
		private void fill_lvCmpny(int col)
		{
			string stsql = "";
		    string tblName = "PSM_Company";
			switch (col)
			{
				case 0: 
					stsql = "select * FROM PSM_Company order by Cpny_Name1";
				    break;
				case 1:
					stsql = "select * FROM PSM_Company order by Tel1";
					break;
				case 2: 
					stsql = "select * FROM PSM_Company order by Email";
					break;
				case 3: 
					stsql = "select * FROM PSM_Company order by M_adrs";
					break;
			}
		    //string stsql = "select * FROM PSM_Company order by Cpny_Name1";

			SqlConnection Ipsm_Conn = new SqlConnection(MainMDI._connectionString);
			SqlDataAdapter Ipsm_OAdp = new SqlDataAdapter(stsql, Ipsm_Conn);
			DataSet Ipsm_Ds = new DataSet(tblName);
			Ipsm_OAdp.Fill(Ipsm_Ds, tblName);
			label1.Text = Ipsm_Ds.Tables[0].Rows.Count.ToString();
			label1.Refresh();
		    //lvCompany.Clear();
			for (int i = 0; i < Ipsm_Ds.Tables[0].Rows.Count; i++)
			{
				ListViewItem lvI = lvCompany.Items.Add(Ipsm_Ds.Tables["PSM_Company"].Rows[i][1].ToString());
				//lvCompany.Items[lvCompany.Items.Count - 1].SubItems[0].ForeColor = Color.Brown;
			    lvI.SubItems.Add(Ipsm_Ds.Tables["PSM_Company"].Rows[i][11].ToString());
			    lvI.SubItems.Add(Ipsm_Ds.Tables["PSM_Company"].Rows[i][16].ToString());
			    lvI.SubItems.Add(Ipsm_Ds.Tables["PSM_Company"].Rows[i][4].ToString());
				//lvCompany.Items[lvCompany.Items.Count - 1].SubItems[0].ForeColor = Color.Tomato;
			}
		}
        */		

		private void fill_lvCmpny_Fast(int col)
		{
			string stSql = "";
			switch (col)
			{
				case 0: 
					stSql = "select * FROM PSM_Company order by Cpny_Name1";
					break;
				case 1:
				    //stSql = "select * FROM PSM_Company order by Tel1";
					break;
				case 2: 
				    //stSql = "select * FROM PSM_Company order by Email";
					break;
				case 3: 
				    //stSql = "select * FROM PSM_Company order by M_adrs";
					break;
			}
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
			//lvCompany.Clear();
			while (Oreadr.Read())
			{
				ListViewItem lvI = lvCompany.Items.Add(Oreadr["Cpny_Name1"].ToString());
				//lvCompany.Items[lvCompany.Items.Count - 1].SubItems[0].ForeColor = Color.Brown;
				string st1 = (Oreadr["Tel1"].ToString() == "") ? MainMDI.VIDE : Oreadr["Tel1"].ToString(); lvI.SubItems.Add(st1);
				st1 = (Oreadr["Email"].ToString() == "") ? MainMDI.VIDE : Oreadr["Email"].ToString(); lvI.SubItems.Add(st1);
				st1 = (Oreadr["M_Adrs"].ToString() == "") ? MainMDI.VIDE : Oreadr["M_Adrs"].ToString(); lvI.SubItems.Add(st1);
				lvI.SubItems.Add(Oreadr["Cpny_ID"].ToString());

                lvI.SubItems.Add(Oreadr["Syspro_Code"].ToString());

                lvI.BackColor = (Oreadr["BLack_List"].ToString() == "1") ? Color.Red : Color.White;
				//lvCompany.Items[lvCompany.Items.Count - 1].SubItems[0].ForeColor = Color.Tomato;
			}
		}

		private void lvCompany_DoubleClick(object sender, System.EventArgs e)
		{
			if (MainMDI.profile != 'R')
			{
				this.Cursor = Cursors.WaitCursor;
				if (lvCompany.SelectedItems.Count == 1)
                    edit_cpny(lvCompany.SelectedItems[0].Text.ToString().Replace("'", "''"), 'M', lvCompany.SelectedItems[0].SubItems[5].Text.ToString());
				this.Cursor = Cursors.Default;
			}		
			else MessageBox.Show("ACCESS DENIED... ", MainMDI.User, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			//frmComapny.lUserName.Text = MainMDI.User;
		}

		private void edit_cpny(string cpnyName, char c, string cpnySPcode)
		{
			int ndx = -1;
			if (c == 'M') ndx = lvCompany.SelectedItems[0].Index;
			Company frmComapny = new Company(cpnyName, c, cpnySPcode);
			frmComapny.ShowDialog();
			if (frmComapny.lupdate.Text != "N")
			{
				if (frmComapny.lupdate.Text == "U")
				{
					lvCompany.Items[ndx].SubItems[0].Text = frmComapny.tCompanyName1.Text;
					lvCompany.Items[ndx].SubItems[1].Text = frmComapny.tTel1.Text;
					lvCompany.Items[ndx].SubItems[2].Text = frmComapny.tEmail.Text;
					lvCompany.Items[ndx].SubItems[3].Text = frmComapny.lMainAdrs.Text;
				}
				else
				{
					ListViewItem lv = lvCompany.Items.Add(frmComapny.tCompanyName1.Text);
					lv.SubItems.Add(frmComapny.tTel1.Text);
					lv.SubItems.Add(frmComapny.tEmail.Text);
					lv.SubItems.Add(frmComapny.lMainAdrs.Text);
				}
			}
		}

		private void fix_Cpny_Adrs()
		{
			string MainAdrs = "";
			int y = 1;
			string stSql = "select * FROM PSM_Company order by Cpny_ID";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				if (Oreadr["City"].ToString() != "" && Oreadr["Province_State"].ToString() != "" && Oreadr["Country_Name"].ToString() != "")
				{
					MainAdrs = Oreadr["M_Adrs"].ToString().Replace(",", " ") + ", " + Oreadr["City"].ToString().Replace(",", " ") + ", " + Oreadr["Province_State"].ToString().Replace(",", " ") + ", " + Oreadr["Postal_Code_Zip"].ToString().Replace(",", " ") + ", " + Oreadr["Country_Name"].ToString().Replace(",", " ");
					stSql = "UPDATE PSM_COMPANY SET " +
						" [M_Adrs]='" + MainAdrs.Replace("'", "''") + "', " +
						" [City]='" + " " + "', " +
						" [Province_State]='" + " " + "', " +
						" [Postal_Code_Zip]='" + " " + "',  " +
						" [Country_Name]='" + " " + "'  " +
						" WHERE [Cpny_ID]=" + Oreadr["Cpny_ID"].ToString();
					MainMDI.ExecSql(stSql);
					toolBar1.Buttons[4].Text = y++.ToString();
					toolBar1.Refresh();
				}
			}
			OConn.Close();
		}

		private void lvCompany_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			//MessageBox.Show(e.Column.ToString() + " SorterCol= " + lvSorter.SortColumn.ToString());

			btnseek.Text = "Search by:    " + lvCompany.Columns[e.Column].Text;
			seelCol = e.Column;
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
				//lvSorter.SortColumn = e.Column; old 
				//lvSorter.Order = SortOrder.Ascending; old

				lvSorter.Order = (srtType == 'A') ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
				srtType = (srtType == 'A') ? 'D' : 'A';
				lvSorter.SortColumn = e.Column;
			}
			//Perform the sort with these new sort options.
			myListView.Sort();
			oldSC = lvSorter.SortColumn;
			lvSorter.SortColumn = 0;

	        //lvCompany.Items.Clear();
		    //lvCompany.Refresh();
            //fill_lvCmpny_Fast(e.Column);
		}

		private void lvCompany_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}

		private void Ges_Company_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
			MainMDI.Write_Whodo_SSetup("Companies", 'I');
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
		}

		private void lvCompany_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
		
		}

		private void Ges_Company_Resize(object sender, System.EventArgs e)
		{
			picExit.Left = this.Width - 48;
		}

		private void picExit_Click(object sender, System.EventArgs e)
		{
			this.Hide();	
		}

		private void btnseek_Click(object sender, System.EventArgs e)
		{
            if (tKey.Text.Length > 2)
            {
                SYSPRO_LIST.Visible = false;
                lvCompany.Visible = true;
                int ideb = 0;
                bool found = false;
                if (tKey.Text != "")
                {
                    if (ndxCLRD > -1)
                    {
                        lvCompany.Items[ndxCLRD].BackColor = Color.WhiteSmoke;
                        ideb = ndxCLRD + 1;
                        ndxCLRD = -1;
                    }
                    for (int i = ideb; i < lvCompany.Items.Count; i++)
                    {
                        if ((lvCompany.Items[i].SubItems[seelCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1))
                        {
                            lvCompany.Items[i].BackColor = Color.Yellow;
                            lvCompany.Items[i].Selected = true;
                            lvCompany.Items[i].EnsureVisible();
                            ndxCLRD = i;
                            i = lvCompany.Items.Count + 1;
                            found = true;
                            btnseek.Text = btnseek.Text.Replace("Search", "Next ");
                        }
                    }
                }
                if (!found) { MessageBox.Show("Sorry, Not Found !!!..."); ndxCLRD = -1; }
            }
            else MessageBox.Show("Sorry, Search key is empty .....(+2).... ");
		}

		private void lvCompany_SelectedIndexChanged_2(object sender, System.EventArgs e)
		{
			if (ndxCLRD > -1) lvCompany.Items[ndxCLRD].BackColor = Color.WhiteSmoke;
        }

        private void Newcpny_DisplayStyleChanged(object sender, EventArgs e)
        {

        }

        private void toolBar1_exec(int _butt) //_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {
            switch (_butt)
            {
                case 0:
                    edit_cpny("*", 'N', "");
                    //frmAddCpny.ShowDialog();
                    //fill_lvCmpny_Fast(0);
                    break;
                case 1:
                    if (lvCompany.SelectedItems.Count == 1)
                       edit_cpny(lvCompany.SelectedItems[0].Text.ToString(), 'M',"baaaad");
                    break;
                case 2:
                    if (MainMDI.User == "Admin" || MainMDI.User == "hnasrat")
                    {
                        if (MainMDI.Confirm("WANT TO DELETE Customer  '" + lvCompany.SelectedItems[0].Text.ToString() + "'  ??  "))
                        {
                            if (MainMDI.ExecSql("delete PSM_COMPANY where Cpny_ID=" + lvCompany.SelectedItems[0].SubItems[4].Text.ToString()))
                                lvCompany.Items[lvCompany.SelectedItems[0].Index].Remove();
                        }
                    }
                    break;
                case 3:
                    this.Hide();
                    break;
                case 4:
                    fix_Cpny_Adrs();
                    break;
                case 5: //find Quote
                    grpSrch.Visible = true;
                    grpSync.Visible = false;
                    tKey.Focus();
                    break;
                case 6: //Sync
                    grpSrch.Visible = true;
                    grpSync.Visible = true;
                    tkeySync.Focus();
                    break;
            }
        }

        private void Newcpny_Click(object sender, EventArgs e)
        {
            //toolBar1_exec(0);
        }

        private void seek_cpny_Click(object sender, EventArgs e)
        {
            toolBar1_exec(5);
        }

        private void exiit_Click(object sender, EventArgs e)
        {
            toolBar1_exec(3);
        }

        private void del_cpny_Click(object sender, EventArgs e)
        {
             
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MainMDI.User.ToLower() == "ede") MOVE_company_SYSPROCode_PGC_();
        }

        private void toolStripButton2_ClickOK_old(object sender, EventArgs e)
        {
            //SYNC_COMPNY_SYSP_PGC_();

            if (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "cfouche" || MainMDI.User.ToLower() == "blombard" || MainMDI.User.ToLower() == "mdimassi" || MainMDI.User.ToLower() == "bcimon" || MainMDI.User.ToLower() == "bmustapha" || MainMDI.User.ToLower() == "mrouleau")
            {
                G_msg = "";
                this.Cursor = Cursors.WaitCursor;
                SyncLBL.Visible = true;

                //REFRESH_COMPNY_NAMES_bySysproCode();
                MTRD_REFRESH_COMPNY_NAMES_bySysproCode();
                if (G_msg.Length > 0)
                {
                    G_msg = " ERRORs while adding following Contacts: " + G_msg;
                    MainMDI.send_email("SYNC_CMPNY@primax-e.com", "hedebbab@primax-e.com", "Companies Sync. ERROR....", G_msg);
                    G_msg = " "; //"bzzzzzzzzzzzzzzzzzz";
                }
                //MessageBox.Show(G_msg + "\n Companies SYNC is DONE...........");
                //MainMDI.Write_JFS("SYNC done ");
                //this.Cursor = Cursors.Default;
            }
            SyncLBL.Visible = false;
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            toolBar1_exec(6);

            //SYNC_COMPNY_SYSP_PGC_();
        }

        //######################
        void Sync_all()
        {
            if (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "cfouche" || MainMDI.User.ToLower() == "blombard" || MainMDI.User.ToLower() == "mdimassi" || MainMDI.User.ToLower() == "bcimon" || MainMDI.User.ToLower() == "bmustapha" || MainMDI.User.ToLower() == "mrouleau" || MainMDI.User.ToLower() == "avalencia")
            {
                G_msg = "";
                this.Cursor = Cursors.WaitCursor;
                SyncLBL.Visible = true;
                enable_all(false);
                timer1.Enabled = true;

                MTRD_REFRESH_COMPNY_NAMES_bySysproCode();
                if (G_msg.Length > 0)
                {
                    G_msg = " ERRORs while adding following Contacts: " + G_msg;
                    MainMDI.send_email("SYNC_CMPNY@primax-e.com", "hedebbab@primax-e.com", "Companies Sync. ERROR....", G_msg);
                    G_msg = " "; //"bzzzzzzzzzzzzzzzzzz";
                }
                //MessageBox.Show(G_msg + "\n Companies SYNC is DONE...........");
                //MainMDI.Write_JFS("SYNC done ");
                //this.Cursor = Cursors.Default;
            }
            //SyncLBL.Visible = false;
        }

        void MTRD_REFRESH_COMPNY_NAMES_bySysproCode()
        {
            m_EventStopThread.Reset();
            m_EventThreadStopped.Reset();
            m_WkTHRD = new Thread(new ThreadStart(this.REFRESH_COMPNY_NAMES_bySysproCode));
            m_WkTHRD.Start();
        }

        private void REFRESH_COMPNY_NAMES_bySysproCode()
        {
            //#threading
            //Salesperson
            string stSql = (tkeySync.Text.Length > 1) ? "SELECT * FROM v_PGCustomerXRef  where Customer='" + tkeySync.Text + "'" : "SELECT * FROM v_PGCustomerXRef order by Customer";

            //string stSql = "SELECT Name,Customer, ShortName FROM v_PGCustomerXRef where substring(Customer,LEN(Customer),1 ) in ( 'U', 'C', 'E') order by Name";
            string st = "";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string PGC_Nm = MainMDI.VIDE, PGC_Code = "";
            while (Oreadr.Read())
            {
                //SyncLBL.Text = Oreadr["Customer"].ToString();
                string Adrs = Oreadr["SoldToAddr1"].ToString().TrimEnd() + Oreadr["SoldToAddr2"].ToString().TrimEnd() + "," + Oreadr["SoldToAddr3"].ToString().TrimEnd() + "," + Oreadr["SoldToAddr4"].ToString().TrimEnd() + "," + Oreadr["SoldPostalCode"].ToString().TrimEnd() + "," + Oreadr["SoldToAddr5"].ToString().TrimEnd();
                if (Oreadr["Name"].ToString().TrimEnd().Length > 1)
                {
                    MainMDI.Find_2_Field("select Cpny_ID,Cpny_Name1 from PSM_COMPANY where Syspro_Code='" + Oreadr["Customer"].ToString() + "'", ref PGC_Code, ref PGC_Nm);
                    if (PGC_Code != MainMDI.VIDE)
                    {
                        //if (Oreadr["Name"].ToString().TrimEnd() != PGC_Nm)

                        //good
                        //MainMDI.Exec_SQL_JFS("update PSM_COMPANY  set [Cpny_Name1]='" + Oreadr["Name"].ToString().TrimEnd().Replace("'", "''") +
                            //"', [Tel1]='" + Oreadr["Telephone"].ToString().Replace("'", "''") +
                            //"', [Fax]='" + Oreadr["Fax"].ToString().Replace("'", "''") +
                            //"', [Sales]='" + Oreadr["Salesperson"].ToString().Replace("'", "''") +
                            //"', [M_Adrs]='" + Adrs.Replace("'", "''") +
                            //"', [Agent]='" + Oreadr["Salesperson1"].ToString().Replace("'", "''") +
                            //"'        where Cpny_ID=" + PGC_Code, "REFRESH COMPANIEeeeeeeeeeeeesss");

                        MainMDI.Exec_SQL_JFS("update PSM_COMPANY  set [Cpny_Name1]='" + Oreadr["Name"].ToString().TrimEnd().Replace("'", "''") +
                            "', [Q_Adrs]='" + Oreadr["SoldToAddr1"].ToString().TrimEnd().Replace("'", "''") +
                            "', [P_Adrs]='" + Oreadr["SoldToAddr2"].ToString().TrimEnd().Replace("'", "''") +
                            "', [S_Adrs]='" + Oreadr["SoldToAddr3"].ToString().TrimEnd().Replace("'", "''") +
                            "', [I_Adrs]='" + Oreadr["SoldToAddr4"].ToString().TrimEnd().Replace("'", "''") +
                            "', [5_Adrs]='" + Oreadr["SoldToAddr5"].ToString().TrimEnd().Replace("'", "''") +
                            "', [Area]='" + Oreadr["Area"].ToString().TrimEnd().Replace("'", "''") +
                            "', [Tel1]='" + Oreadr["Telephone"].ToString().Replace("'", "''") +
                            "', [Fax]='" + Oreadr["Fax"].ToString().Replace("'", "''") +
                            "', [Sales]='" + Oreadr["Salesperson"].ToString().Replace("'", "''") +
                            "', [M_Adrs]='" + Adrs.Replace("'", "''") +
                            "', [Agent]='" + Oreadr["Salesperson1"].ToString().Replace("'", "''") +
                            "'        where Cpny_ID=" + PGC_Code, "REFRESH COMPANIEeeeeeeeeeeeesss");

                        //SYSout_LOG("update company name", Oreadr["Name"].ToString().TrimEnd().Replace("'", "''"), Oreadr["Customer"].ToString(), "");

                        ADD_ALL_Contact_TO_PGC(Oreadr["Customer"].ToString());
                    }
                    else
                    {
                        Save_NewCpny_PGC(Oreadr["Name"].ToString().TrimEnd().Replace("'", "''"), Adrs, Oreadr["Telephone"].ToString(), Oreadr["Fax"].ToString(), Oreadr["Customer"].ToString(), Oreadr["Salesperson1"].ToString());
                        ADD_ALL_Contact_TO_PGC(Oreadr["Customer"].ToString());
                    }
                    //st = "(" + Oreadr["Customer"].ToString() + ") " + Oreadr["Name"].ToString();
                    st = Oreadr["Customer"].ToString(); //+ ") " + Oreadr["Name"].ToString();
                    Thread.Sleep(10);
                    this.Invoke(this.m_RepTrace, new object[] { st });
                    if (m_EventStopThread.WaitOne(0, true))
                    {
                        m_EventThreadStopped.Set();
                        return;
                    }
                }
            }
            if (st == "") st = st;
            OConn.Close();

            SyncLBL.Text = "";
            SyncLBL.Visible = false;
            MessageBox.Show("Global SYNC DONE.....");
        }

        private void MOVE_company_SYSPROCode_PGC_()
        {
            string stSql = "SELECT * FROM v_PGCustomerXRef order by Name";

            //string stSql = "SELECT Name,Customer, ShortName FROM v_PGCustomerXRef where substring(Customer,LEN(Customer),1 ) in ( 'U', 'C', 'E') order by Name";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                if (Tools.Conv_Dbl(Oreadr["ShortName"].ToString()) != 0)
                {
                    MainMDI.Exec_SQL_JFS("update dbo.PSM_COMPANY set [Syspro_Code]='" + Oreadr["Customer"].ToString() + "' where Cpny_ID=" + Oreadr["ShortName"].ToString(), " update SYSPRO code for companies..");
                }
            }
            OConn.Close();
        }

        private void SYNC_COMPNY_SYSP_PGC_()
        {
            //string stSql = "SELECT * FROM v_PGCustomerXRef order by Name";

            ////string stSql = "SELECT Name,Customer, ShortName FROM v_PGCustomerXRef where substring(Customer,LEN(Customer),1 ) in ( 'U', 'C', 'E') order by Name";

            //SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            //OConn.Open();
            //SqlCommand Ocmd = OConn.CreateCommand();
            //Ocmd.CommandText = stSql;
            //SqlDataReader Oreadr = Ocmd.ExecuteReader();

            //while (Oreadr.Read())
            //{
                //if (Oreadr["Name"].ToString().Replace(" ", "") == "Primax-Syspro-Test") stSql = stSql;
                //if (Tools.Conv_Dbl(Oreadr["ShortName"].ToString()) == 0 && Oreadr["Name"].ToString().Replace(" ", "").Length > 3 && !company_Exists_SYSPROcode(Oreadr["Customer"].ToString()))
                //{
                    //string Adrs = Oreadr["SoldToAddr1"].ToString().TrimEnd() + Oreadr["SoldToAddr2"].ToString().TrimEnd() + Oreadr["SoldToAddr3"].ToString().TrimEnd() + "," + Oreadr["SoldToAddr4"].ToString().TrimEnd() + "," + Oreadr["SoldPostalCode"].ToString().TrimEnd() + "," + Oreadr["SoldToAddr5"].ToString().TrimEnd();
                    //Save_NewCpny_PGC(Oreadr["Name"].ToString().TrimEnd(), Adrs, Oreadr["Telephone"].ToString(), Oreadr["Fax"].ToString(), Oreadr["Customer"].ToString());
                    //ADD_ALL_Contact_TO_PGC(Oreadr["Customer"].ToString());
                //}
            //}
            //OConn.Close();
        }

        private void REFRESH_COMPNY_PGESCOM_()
        {
            //string stSql = "SELECT * FROM v_PGCustomerXRef order by Name";

            ////string stSql = "SELECT Name,Customer, ShortName FROM v_PGCustomerXRef where substring(Customer,LEN(Customer),1 ) in ( 'U', 'C', 'E') order by Name";

            //SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            //OConn.Open();
            //SqlCommand Ocmd = OConn.CreateCommand();
            //Ocmd.CommandText = stSql;
            //SqlDataReader Oreadr = Ocmd.ExecuteReader();

            //while (Oreadr.Read())
            //{
                ////if (Oreadr["Name"].ToString().Replace(" ", "") == "Primax-Syspro-Test") stSql = stSql;
                //if (Tools.Conv_Dbl(Oreadr["ShortName"].ToString()) == 0 && Oreadr["Name"].ToString().Replace(" ", "").Length > 3 && !company_Exists_SYSPROcode(Oreadr["Customer"].ToString()))
                //{
                    //string Adrs = Oreadr["SoldToAddr1"].ToString().TrimEnd() + Oreadr["SoldToAddr2"].ToString().TrimEnd() + Oreadr["SoldToAddr3"].ToString().TrimEnd() + "," + Oreadr["SoldToAddr4"].ToString().TrimEnd() + "," + Oreadr["SoldPostalCode"].ToString().TrimEnd() + "," + Oreadr["SoldToAddr5"].ToString().TrimEnd();
                    //Save_NewCpny_PGC(Oreadr["Name"].ToString().TrimEnd(), Adrs, Oreadr["Telephone"].ToString(), Oreadr["Fax"].ToString(), Oreadr["Customer"].ToString());
                    //ADD_ALL_Contact_TO_PGC(Oreadr["Customer"].ToString());
                //}
                //else stSql = stSql;
            //}
            //OConn.Close();
        }

        private void SYSout_LOG(string col1, string col2, string col3, string col4)
        {
            //col1 = col1;
            try
            {
                string stSql = "INSERT INTO PSM_SYSOUT_LOGS ([col1], " +
                    " [col2],[col3],[col4]) VALUES ('" +
                    col1.Replace("'", "''") + "', '" +
                    col2.Replace("'", "''") + "', '" +
                    col3.Replace("'", "''") + "', '" +
                    col4.Replace("'", "''") + "')";
                MainMDI.Exec_SQL_JFS(stSql, "SYSLOG writing......");
            }
            catch (SqlException Oexp)
            {
                MessageBox.Show("SYSout_LOG inserting failed...= " + Oexp.Message);
            }
        }

        private void ADD_ALL_Contact_TO_PGC(string Customer)
        {
            string stSql = "SELECT *  FROM [v_PGContactXRef_HAK] where Customer ='" + Customer + "'";

            //string stSql = "SELECT Name,Customer, ShortName FROM v_PGCustomerXRef where substring(Customer,LEN(Customer),1 ) in ( 'U', 'C', 'E') order by Name";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string cpnyID = MainMDI.Find_One_Field("select  Cpny_ID from  PSM_COMPANY   where Syspro_Code='" + Customer + "'");

            while (Oreadr.Read())
            {
                if (cpnyID != MainMDI.VIDE)
                {
                    string stLastNm = (Oreadr["MiddleName"].ToString().TrimEnd() != "") ? Oreadr["MiddleName"].ToString().TrimEnd() + " " + Oreadr["LastName"].ToString().TrimEnd() : Oreadr["LastName"].ToString().TrimEnd();
                    Add_Contact_SYSP_PGC(Oreadr["FirstName"].ToString().TrimEnd(), stLastNm, cpnyID, Oreadr["Telephone"].ToString().TrimEnd(), "", Oreadr["Email"].ToString());
                    //SYSout_LOG("New Contact", Oreadr["FirstName"].ToString() + " " + Oreadr["LastName"].ToString(), cpnyID, Customer);
                }
                else
                {
                    Add_Contact_SYSP_PGC("NONE", "NONE", cpnyID, "NONE", "NONE", "NONE");
                    //SYSout_LOG("New Contact", "NONE/NONE", cpnyID, Customer);
                }
            }
            OConn.Close();
        }

        public void Add_Contact_SYSP_PGC(string tFname, string tLname, string lcpnyIDD, string tel, string tFax, string email)
        {
            int i = 0;
            email = email.Replace("'", "").TrimEnd();
            //if (tFname.ToLower() == "jerry") i = i;

            try
            {
                string ContID = MainMDI.Find_One_Field("SELECT PSM_Contacts.Contact_ID FROM PSM_Contacts where First_Name='" + tFname.Replace("'", "''") + "' and Last_Name='" + tLname.Replace("'", "''") + "' and Company_ID=" + lcpnyIDD);
                if (ContID == MainMDI.VIDE || tFname == "NONE")
                {
                    string stSql = "INSERT INTO PSM_Contacts ([Prefix_ID], " +
                        " [First_Name],[Last_Name],[JOBTitle],[Company_ID],[Department],[Main_TEL],[Extension], " +
                        " [Fax Number],[Cell Number],[Pager Number],[Email Address],[Catalog Number],[Tel2], " +
                        " [Ext2]) VALUES (" +
                        "0" + ", '" +
                        tFname.Replace("'", "''") + "', '" +
                        tLname.Replace("'", "''") + "', '" +
                        "" + "', " +
                        lcpnyIDD + ", '" +
                        "" + "', '" +
                        tel + "', '" +
                        "" + "', '" +
                        tFax + "', '" +
                        "" + "', '" +
                        "" + "', '" +
                        email + "', '" +
                        "" + "', '" +
                        "" + "', '" +
                        "" + "')";
                    if (tFname.Length > 1 && tLname.Length > 1) MainMDI.Exec_SQL_JFS(stSql, " Add contact from SYSP to PGC........");
                    else G_msg += "\n FName='" + tFname + "'  LName='" + tLname + "'     cpnyID=" + lcpnyIDD;
                    //MessageBox.Show("can not add Contact... First Name='" + tFname + "'  Last name='" + tLname + "'     cpnyID=" + lcpnyIDD);
                }
                else
                {
                    string stSql = "UPDATE PSM_Contacts SET [Main_TEL]='" + tel + "', [Fax Number]='" + tFax + "', [Email Address]='" + email.TrimEnd() + "' where Contact_ID=" + ContID;
                    if (tel.Length > 6) MainMDI.Exec_SQL_JFS(stSql, " UPDATE contact from SYSP to PGC........");
                }
            }
            catch (SqlException Oexp)
            {
                MessageBox.Show("Adding CONTACT failed...= " + Oexp.Message);
            }
        }

        private void Save_NewCpny_PGC(string tCpny_Name1, string lMainAdrs, string tTel1, string tFax, string SYSPRO_code, string ag)
        {
            string vide = "";

            //if (!company_Exists(tCpny_Name1.Replace("'", "''"), ""))
            if (tCpny_Name1.Replace("'", "''").Length > 2)
            {
                try
                {
                    //int ID = Convert.ToInt32(MainMDI.Find_One_Field("Select Cpny_ID from PSM_COMPANY order by Cpny_ID DESC"));
                    //string stSql= "INSERT INTO PSM_COMPANY ([Cpny_ID],[Cpny_Name1],[M_Adrs], " + 
                    ag = (ag.Length > 2) ? ag : "*";
                    string stSql = "INSERT INTO PSM_COMPANY ([Cpny_Name1],[M_Adrs], " +
                        " [Tel1],[Fax],[TollFree],[Web],[Email],[Customer],[Supplier], " +
                        " [Manufacturer],[Cpny_Name2],[Cpny_Main],[Q_Adrs],[P_Adrs],[S_Adrs],[I_Adrs],[Tel2], " +
                        "[CustomerType],[TermID],[CreditLim],[Currency],[ShipVia_ID],[IncoTerm_ID], " +
                        "[BLack_List],[BL_Cmnt],[BL_usr], " +
                        "[City],[Province_State],[Country_Name],[Syspro_Code],[actvId],[Agent]) VALUES ('" +
                        tCpny_Name1.Replace("'", "''") + "', '" + lMainAdrs.Replace("'", "''") + "', '" + tTel1 + "', '" +
                        tFax + "', '" + vide + "', '" + vide + "', '" +
                        vide + "', " + "1" + ", " + "0" + ", " + "0" + ", '" +
                        vide.Replace("'", "''") + "', " + "0" + ", '" + vide + "', '" +
                        vide.Replace("'", "''") + "', '" + vide.Replace("'", "''") + "', '" + vide.Replace("'", "''") + "', '" +
                        vide + "', " + "0" + ", " + "0" + ", '" + "0" + "', '" +
                        vide + "', " + "0" + ", " + "0" + ", " +
                       "0" + ", '" + vide + "', '" + "0" + "', '" +
                        "" + "', '" + "" + "', '"
                        + "" + "', '"
                        + SYSPRO_code + "', "
                        + "0" + ", '" 
                        + ag + "')";
                    MainMDI.Exec_SQL_JFS(stSql, " New cpny from sysypro....");
                    //SYSout_LOG("New SYSPRO company name", tCpny_Name1, SYSPRO_code, "");
                }
                catch (SqlException Oexp)
                {
                    MessageBox.Show("Adding Company INFO from SYSPRO   failed......... Error...= " + Oexp.Message);
                }
            }
            //else MessageBox.Show("This Company Exists already....");
        }

        private bool company_Exists(string _cpnyNme, string _cLID)
        {
            if (_cLID == "")
            {
                if (Int32.Parse(MainMDI.Find_One_Field("select count(*) from PSM_COMPANY where Cpny_Name1='" + _cpnyNme.TrimEnd() + "'")) == 0) return false;
            }
            else if (Int32.Parse(MainMDI.Find_One_Field("select count(*) from PSM_COMPANY where Cpny_Name1='" + _cpnyNme.TrimEnd() + "' and Cpny_ID <>" + _cLID)) == 0) return false;
            return true;
        }

        private bool company_Exists_SYSPROcode(string sysPcode)
        {
            return (MainMDI.Find_One_Field("select Cpny_ID from PSM_COMPANY where Syspro_Code='" + sysPcode + "'") != MainMDI.VIDE);
        }

        private void btnSync1_Click(object sender, EventArgs e)
        {
            if (tkeySync.Text.Length > 6) Sync_all();
            else MessageBox.Show("Sorry,  You missed:  SYSPRO Company Code (WVT010C)...");
            //G_sync = tkeySync.Text;
        }

        private void btnSync_All_Click(object sender, EventArgs e)
        {
            tkeySync.Text = "";
            Sync_all();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (!SyncLBL.Visible)
            {
                this.Cursor = Cursors.Default;
                timer1.Enabled = false;
                enable_all(true);
                grpSrch.Visible = false;
            }
        }

        void enable_all(bool st)
        {
            //TSmain.Enabled = st;
            lvCompany.Enabled = st;
            grpSrch.Enabled = st;
            Newcpny.Enabled = st;
            toolStripButton2.Enabled = st;
            seek_cpny.Enabled = st;
            exiit.Enabled = st;
        }

        private void tls_contact_Click(object sender, EventArgs e)
        {
            Ges_Cont_Sal_Ag gCSA = new Ges_Cont_Sal_Ag('C');
            this.Hide();
            gCSA.ShowDialog();
            this.Visible = true;
            gCSA.Dispose();
        }

        private void tls_Agencies_Click(object sender, EventArgs e)
        {
            //testing Agencies, Agents
            dlg_SYSP_Agencies mydlg = new dlg_SYSP_Agencies();
            mydlg.ShowDialog();
        }

        private void btnLastCode_Click(object sender, EventArgs e)
        {
            fill_ABC_UC();
        }

        private void fill_ABC_UC()
        {
            SYSPRO_LIST.Visible = true;
            lvCompany.Visible = false;
            string cond = "", kfind = txABB.Text.Replace("*", "");
            string condbranch = (cbBranch.Text != "all" && cbBranch.Text != "") ? " and RIGHT(Customer, 1) ='" + cbBranch.Text + "' " : "";
            //kfind.Replace("*", "");
            if (txABB.Text[0] == '*') kfind = "%" + kfind;
            cond = kfind + "%' " + condbranch;
            string stSql = "select Name, SoldToAddr1,Customer   from v_PGCustomerXRef  where Customer like '" + cond + " order by RIGHT(Customer,1) ,Customer ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            SYSPRO_LIST.Items.Clear();

            while (Oreadr.Read())
            {
                ListViewItem lvI = SYSPRO_LIST.Items.Add(Oreadr["Name"].ToString());
                string st1 = (Oreadr["SoldToAddr1"].ToString() == "") ? MainMDI.VIDE : Oreadr["SoldToAddr1"].ToString(); lvI.SubItems.Add(st1);
                lvI.SubItems.Add(Oreadr["Customer"].ToString());
            }
        }

    }
}