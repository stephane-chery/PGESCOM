using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing.Printing;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Data.SqlClient;
using EAHLibs;
using System.Net;
using System.Net.Sockets;
using System.Net.Mail;
namespace PGESCOM
{
	/// <summary>
	/// Summary description for Misc.
	/// </summary>
	public class Misc : System.Windows.Forms.Form
	{
        //static System.Globalization.NumberFormatInfo ni = null;
        private Lib1 Tools = new Lib1();
        Socket mySocClient_Mgr;
        AsyncCallback myAsyncCallBack;
        IAsyncResult myAsynResult;
        string TCPreceivedTXT = "";

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label ltime;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button8;
		private System.Windows.Forms.PictureBox picExit;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox grpConfig;
		private System.Windows.Forms.Button svDymo;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.ComboBox cbprinters;
		private System.Windows.Forms.Button btnsaveConfig;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.TextBox tpbsPath;
		private System.Windows.Forms.GroupBox grpIDs;
		private System.Windows.Forms.Button btnAddGenID;
		private System.Windows.Forms.TextBox tNB;
		private System.Windows.Forms.TextBox tSfrom;
		private System.Windows.Forms.TextBox tOfrom;
		private System.Windows.Forms.TextBox tQfrom;
		private System.Windows.Forms.CheckBox chkSN;
		private System.Windows.Forms.CheckBox chkOrders;
		private System.Windows.Forms.CheckBox chkQuote;
		private System.Windows.Forms.PictureBox pS;
		private System.Windows.Forms.PictureBox pR;
		private System.Windows.Forms.PictureBox pQ;
		private System.Windows.Forms.Label laff;
		private System.Windows.Forms.Button btnNewGenID;
		private System.Windows.Forms.GroupBox grpFree;
		private System.Windows.Forms.TextBox tuser;
		private System.Windows.Forms.Button button6;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.ListView lvTools;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Button BtnUsers;
		private System.Windows.Forms.Button button7;
		private System.Windows.Forms.ComboBox cbUsers;
		private System.Windows.Forms.Button button5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.ColumnHeader User;
		private System.Windows.Forms.ColumnHeader station;
		private System.Windows.Forms.ColumnHeader mdl;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox grpCurrU;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.ColumnHeader timeIn;
		private System.Windows.Forms.ListView lvstation;
		private System.Windows.Forms.Button button10;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Button button11;
		private System.Windows.Forms.Button btnStop;
		private System.Windows.Forms.TextBox tmsg;
		private System.Windows.Forms.Label lUser;
		private System.Windows.Forms.RadioButton chkALL;
		private System.Windows.Forms.RadioButton chkSUsr;
		private System.Windows.Forms.Label lmach;
		private System.Windows.Forms.Button btnSTOPALL;
		private System.Windows.Forms.Button btnUPPGESCOM;
		private System.Windows.Forms.Label ldispUS;
		private System.Windows.Forms.Label lSrvr_statt;
		private System.Windows.Forms.Label lSrvr_stat;
		private System.Windows.Forms.ImageList Fst_IL32;
		private System.Windows.Forms.Button btnow;
		private System.Windows.Forms.Button lstop;
		private System.Windows.Forms.TextBox tpwd;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox t_bld;
		private System.Windows.Forms.Button btnbld;
		private System.Windows.Forms.Label lQ_rem;
		private System.Windows.Forms.Label lR_rem;
		private System.Windows.Forms.Label lS_rem;
		private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox textBox3;
        private Label lport;
        private Label lip;
        private Button btn2Mn;
        private TextBox textBox5;
        private CheckBox chkGhosts;
        private TextBox textBox4;
        private CheckBox chkBrds;
        private Label lG9rem;
        private Label label10;
        private Button btn_macAdrs;
        public PictureBox picCIP;
        private Label label11;
        private Button button9;
        private TextBox lWQfiles;
        private TextBox txPDFrdr;
        private Button btnSVpdf;
        private Label label12;
        private Button button12;
        private OpenFileDialog openFileDialog1;
        private TextBox txDymo;
        private Button btnUPGC;
        private ToolStrip TSmain;
        private ToolStripButton Addids;
        private ToolStripButton unlock;
        private ToolStripButton tlsusers;
        private ToolStripButton tlsconf;
        private ToolStripButton _exit;
        private ToolStripButton tlsSTAT;
        private Button button13;
		private System.ComponentModel.IContainer components;

		public Misc()
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();
			CHSPrt();
			find_REM_IDs();

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
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(" Add IDs ", 0);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(" Unlock", 1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(" Users    ", 4);
            System.Windows.Forms.ListViewItem listViewItem9 = new System.Windows.Forms.ListViewItem("Config.", 2);
            System.Windows.Forms.ListViewItem listViewItem10 = new System.Windows.Forms.ListViewItem("Stations", 3);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Misc));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.ltime = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.BtnUsers = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.lvTools = new System.Windows.Forms.ListView();
            this.Fst_IL32 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button5 = new System.Windows.Forms.Button();
            this.grpFree = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.cbUsers = new System.Windows.Forms.ComboBox();
            this.tuser = new System.Windows.Forms.TextBox();
            this.btnUPGC = new System.Windows.Forms.Button();
            this.grpIDs = new System.Windows.Forms.GroupBox();
            this.btn_macAdrs = new System.Windows.Forms.Button();
            this.lG9rem = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.chkGhosts = new System.Windows.Forms.CheckBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.chkBrds = new System.Windows.Forms.CheckBox();
            this.lS_rem = new System.Windows.Forms.Label();
            this.lR_rem = new System.Windows.Forms.Label();
            this.lQ_rem = new System.Windows.Forms.Label();
            this.btnAddGenID = new System.Windows.Forms.Button();
            this.tNB = new System.Windows.Forms.TextBox();
            this.tSfrom = new System.Windows.Forms.TextBox();
            this.tOfrom = new System.Windows.Forms.TextBox();
            this.tQfrom = new System.Windows.Forms.TextBox();
            this.chkSN = new System.Windows.Forms.CheckBox();
            this.chkOrders = new System.Windows.Forms.CheckBox();
            this.chkQuote = new System.Windows.Forms.CheckBox();
            this.pS = new System.Windows.Forms.PictureBox();
            this.pR = new System.Windows.Forms.PictureBox();
            this.pQ = new System.Windows.Forms.PictureBox();
            this.laff = new System.Windows.Forms.Label();
            this.btnNewGenID = new System.Windows.Forms.Button();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.grpCurrU = new System.Windows.Forms.GroupBox();
            this.btn2Mn = new System.Windows.Forms.Button();
            this.lport = new System.Windows.Forms.Label();
            this.lip = new System.Windows.Forms.Label();
            this.btnbld = new System.Windows.Forms.Button();
            this.t_bld = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.tpwd = new System.Windows.Forms.TextBox();
            this.btnow = new System.Windows.Forms.Button();
            this.lstop = new System.Windows.Forms.Button();
            this.lSrvr_stat = new System.Windows.Forms.Label();
            this.lSrvr_statt = new System.Windows.Forms.Label();
            this.ldispUS = new System.Windows.Forms.Label();
            this.lmach = new System.Windows.Forms.Label();
            this.chkSUsr = new System.Windows.Forms.RadioButton();
            this.chkALL = new System.Windows.Forms.RadioButton();
            this.lUser = new System.Windows.Forms.Label();
            this.button10 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.btnStop = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.tmsg = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.lvstation = new System.Windows.Forms.ListView();
            this.User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.station = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.timeIn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnSTOPALL = new System.Windows.Forms.Button();
            this.btnUPPGESCOM = new System.Windows.Forms.Button();
            this.grpConfig = new System.Windows.Forms.GroupBox();
            this.button13 = new System.Windows.Forms.Button();
            this.txDymo = new System.Windows.Forms.TextBox();
            this.button12 = new System.Windows.Forms.Button();
            this.txPDFrdr = new System.Windows.Forms.TextBox();
            this.btnSVpdf = new System.Windows.Forms.Button();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.button9 = new System.Windows.Forms.Button();
            this.lWQfiles = new System.Windows.Forms.TextBox();
            this.svDymo = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.btnsaveConfig = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.tpbsPath = new System.Windows.Forms.TextBox();
            this.cbprinters = new System.Windows.Forms.ComboBox();
            this.button7 = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.button11 = new System.Windows.Forms.Button();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.Addids = new System.Windows.Forms.ToolStripButton();
            this.unlock = new System.Windows.Forms.ToolStripButton();
            this.tlsusers = new System.Windows.Forms.ToolStripButton();
            this.tlsconf = new System.Windows.Forms.ToolStripButton();
            this.tlsSTAT = new System.Windows.Forms.ToolStripButton();
            this._exit = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpFree.SuspendLayout();
            this.grpIDs.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pS)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pR)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pQ)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            this.grpCurrU.SuspendLayout();
            this.grpConfig.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.TSmain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.textBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.ltime);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.BtnUsers);
            this.groupBox1.Controls.Add(this.button8);
            this.groupBox1.Location = new System.Drawing.Point(710, 21);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(87, 23);
            this.groupBox1.TabIndex = 4;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            this.groupBox1.Visible = false;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(48, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(182, 28);
            this.button2.TabIndex = 7;
            this.button2.Text = "IS Double ??";
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Beige;
            this.label1.Location = new System.Drawing.Point(144, 55);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(211, 27);
            this.label1.TabIndex = 6;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(29, 28);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(120, 22);
            this.textBox1.TabIndex = 5;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(182, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Trans 725 to 0725";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Sylfaen", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(10, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(67, 28);
            this.btnCancel.TabIndex = 179;
            this.btnCancel.Text = "Exit";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // ltime
            // 
            this.ltime.BackColor = System.Drawing.SystemColors.Control;
            this.ltime.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ltime.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltime.Location = new System.Drawing.Point(86, 111);
            this.ltime.Name = "ltime";
            this.ltime.Size = new System.Drawing.Size(77, 27);
            this.ltime.TabIndex = 193;
            this.ltime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltime.Visible = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(67, 148);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(144, 22);
            this.textBox2.TabIndex = 208;
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox2.Visible = false;
            // 
            // BtnUsers
            // 
            this.BtnUsers.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.BtnUsers.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnUsers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.BtnUsers.Location = new System.Drawing.Point(259, 83);
            this.BtnUsers.Name = "BtnUsers";
            this.BtnUsers.Size = new System.Drawing.Size(96, 74);
            this.BtnUsers.TabIndex = 215;
            this.BtnUsers.Text = "Click here to Add/Del/Modify Users (Could be done only by Super User)";
            this.BtnUsers.Visible = false;
            this.BtnUsers.Click += new System.EventHandler(this.BtnUsers_Click);
            // 
            // button8
            // 
            this.button8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button8.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.button8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button8.Location = new System.Drawing.Point(365, 28);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(163, 129);
            this.button8.TabIndex = 207;
            this.button8.Text = "Delete Quote /#:    on UR OWN RISK !!!";
            this.button8.Visible = false;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // lvTools
            // 
            this.lvTools.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvTools.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.lvTools.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lvTools.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvTools.ForeColor = System.Drawing.Color.Crimson;
            this.lvTools.HideSelection = false;
            this.lvTools.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem6,
            listViewItem7,
            listViewItem8,
            listViewItem9,
            listViewItem10});
            this.lvTools.LargeImageList = this.Fst_IL32;
            this.lvTools.Location = new System.Drawing.Point(954, 353);
            this.lvTools.MultiSelect = false;
            this.lvTools.Name = "lvTools";
            this.lvTools.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lvTools.Size = new System.Drawing.Size(254, 275);
            this.lvTools.TabIndex = 211;
            this.lvTools.UseCompatibleStateImageBehavior = false;
            this.lvTools.Visible = false;
            this.lvTools.SelectedIndexChanged += new System.EventHandler(this.lvTools_SelectedIndexChanged);
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
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.AliceBlue;
            this.groupBox2.Controls.Add(this.button5);
            this.groupBox2.Controls.Add(this.grpFree);
            this.groupBox2.Controls.Add(this.btnUPGC);
            this.groupBox2.Controls.Add(this.grpIDs);
            this.groupBox2.Controls.Add(this.picExit);
            this.groupBox2.Controls.Add(this.grpCurrU);
            this.groupBox2.Controls.Add(this.grpConfig);
            this.groupBox2.Location = new System.Drawing.Point(0, 76);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(947, 486);
            this.groupBox2.TabIndex = 212;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // button5
            // 
            this.button5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button5.Font = new System.Drawing.Font("Cooper Black", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button5.Location = new System.Drawing.Point(7, 413);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(173, 46);
            this.button5.TabIndex = 214;
            this.button5.Text = "NEXT";
            this.button5.Visible = false;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // grpFree
            // 
            this.grpFree.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.grpFree.Controls.Add(this.label7);
            this.grpFree.Controls.Add(this.textBox3);
            this.grpFree.Controls.Add(this.label4);
            this.grpFree.Controls.Add(this.groupBox1);
            this.grpFree.Controls.Add(this.button6);
            this.grpFree.Controls.Add(this.button4);
            this.grpFree.Controls.Add(this.cbUsers);
            this.grpFree.Controls.Add(this.tuser);
            this.grpFree.Location = new System.Drawing.Point(19, 18);
            this.grpFree.Name = "grpFree";
            this.grpFree.Size = new System.Drawing.Size(916, 84);
            this.grpFree.TabIndex = 213;
            this.grpFree.TabStop = false;
            this.grpFree.Visible = false;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(77, 45);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 18);
            this.label7.TabIndex = 212;
            this.label7.Text = "Password:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Visible = false;
            // 
            // textBox3
            // 
            this.textBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Black;
            this.textBox3.Location = new System.Drawing.Point(163, 43);
            this.textBox3.Name = "textBox3";
            this.textBox3.PasswordChar = '*';
            this.textBox3.Size = new System.Drawing.Size(144, 26);
            this.textBox3.TabIndex = 211;
            this.textBox3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox3.Visible = false;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(10, 21);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 18);
            this.label4.TabIndex = 209;
            this.label4.Text = "User:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button6
            // 
            this.button6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button6.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.button6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button6.Location = new System.Drawing.Point(307, 16);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(183, 28);
            this.button6.TabIndex = 206;
            this.button6.Text = "Unlock User";
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // button4
            // 
            this.button4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button4.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold);
            this.button4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button4.Location = new System.Drawing.Point(499, 16);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(183, 28);
            this.button4.TabIndex = 205;
            this.button4.Text = "Unlock Quotes/Orders";
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // cbUsers
            // 
            this.cbUsers.BackColor = System.Drawing.Color.White;
            this.cbUsers.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbUsers.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.cbUsers.ForeColor = System.Drawing.Color.OrangeRed;
            this.cbUsers.Location = new System.Drawing.Point(48, 18);
            this.cbUsers.Name = "cbUsers";
            this.cbUsers.Size = new System.Drawing.Size(259, 24);
            this.cbUsers.TabIndex = 210;
            this.cbUsers.SelectedIndexChanged += new System.EventHandler(this.cbUsers_SelectedIndexChanged);
            // 
            // tuser
            // 
            this.tuser.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tuser.ForeColor = System.Drawing.Color.Red;
            this.tuser.Location = new System.Drawing.Point(48, 18);
            this.tuser.Name = "tuser";
            this.tuser.Size = new System.Drawing.Size(259, 26);
            this.tuser.TabIndex = 208;
            this.tuser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tuser.TextChanged += new System.EventHandler(this.tuser_TextChanged);
            // 
            // btnUPGC
            // 
            this.btnUPGC.BackColor = System.Drawing.Color.Salmon;
            this.btnUPGC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUPGC.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPGC.ForeColor = System.Drawing.Color.Black;
            this.btnUPGC.Image = ((System.Drawing.Image)(resources.GetObject("btnUPGC.Image")));
            this.btnUPGC.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUPGC.Location = new System.Drawing.Point(672, 406);
            this.btnUPGC.Name = "btnUPGC";
            this.btnUPGC.Size = new System.Drawing.Size(268, 67);
            this.btnUPGC.TabIndex = 298;
            this.btnUPGC.Text = "PGESCOM update ";
            this.btnUPGC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUPGC.UseVisualStyleBackColor = false;
            this.btnUPGC.Click += new System.EventHandler(this.btnUPGC_Click);
            // 
            // grpIDs
            // 
            this.grpIDs.Controls.Add(this.btn_macAdrs);
            this.grpIDs.Controls.Add(this.lG9rem);
            this.grpIDs.Controls.Add(this.label10);
            this.grpIDs.Controls.Add(this.textBox5);
            this.grpIDs.Controls.Add(this.chkGhosts);
            this.grpIDs.Controls.Add(this.textBox4);
            this.grpIDs.Controls.Add(this.chkBrds);
            this.grpIDs.Controls.Add(this.lS_rem);
            this.grpIDs.Controls.Add(this.lR_rem);
            this.grpIDs.Controls.Add(this.lQ_rem);
            this.grpIDs.Controls.Add(this.btnAddGenID);
            this.grpIDs.Controls.Add(this.tNB);
            this.grpIDs.Controls.Add(this.tSfrom);
            this.grpIDs.Controls.Add(this.tOfrom);
            this.grpIDs.Controls.Add(this.tQfrom);
            this.grpIDs.Controls.Add(this.chkSN);
            this.grpIDs.Controls.Add(this.chkOrders);
            this.grpIDs.Controls.Add(this.chkQuote);
            this.grpIDs.Controls.Add(this.pS);
            this.grpIDs.Controls.Add(this.pR);
            this.grpIDs.Controls.Add(this.pQ);
            this.grpIDs.Controls.Add(this.laff);
            this.grpIDs.Controls.Add(this.btnNewGenID);
            this.grpIDs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpIDs.Location = new System.Drawing.Point(19, 18);
            this.grpIDs.Name = "grpIDs";
            this.grpIDs.Size = new System.Drawing.Size(480, 185);
            this.grpIDs.TabIndex = 212;
            this.grpIDs.TabStop = false;
            this.grpIDs.Text = "Serial Numbers";
            this.grpIDs.Visible = false;
            // 
            // btn_macAdrs
            // 
            this.btn_macAdrs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_macAdrs.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_macAdrs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btn_macAdrs.Location = new System.Drawing.Point(282, 141);
            this.btn_macAdrs.Name = "btn_macAdrs";
            this.btn_macAdrs.Size = new System.Drawing.Size(191, 34);
            this.btn_macAdrs.TabIndex = 301;
            this.btn_macAdrs.Text = "New MAC Adrs IDs ";
            this.btn_macAdrs.Visible = false;
            this.btn_macAdrs.Click += new System.EventHandler(this.btn_macAdrs_Click);
            // 
            // lG9rem
            // 
            this.lG9rem.BackColor = System.Drawing.Color.Transparent;
            this.lG9rem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lG9rem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lG9rem.Location = new System.Drawing.Point(211, 111);
            this.lG9rem.Name = "lG9rem";
            this.lG9rem.Size = new System.Drawing.Size(48, 23);
            this.lG9rem.TabIndex = 300;
            this.lG9rem.Text = "0";
            this.lG9rem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.Transparent;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(211, 88);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 23);
            this.label10.TabIndex = 299;
            this.label10.Text = "0";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label10.Visible = false;
            // 
            // textBox5
            // 
            this.textBox5.Location = new System.Drawing.Point(102, 111);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(106, 22);
            this.textBox5.TabIndex = 298;
            // 
            // chkGhosts
            // 
            this.chkGhosts.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkGhosts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkGhosts.Location = new System.Drawing.Point(19, 108);
            this.chkGhosts.Name = "chkGhosts";
            this.chkGhosts.Size = new System.Drawing.Size(83, 28);
            this.chkGhosts.TabIndex = 297;
            this.chkGhosts.Text = "Ghost :";
            this.chkGhosts.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // textBox4
            // 
            this.textBox4.Location = new System.Drawing.Point(102, 88);
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(106, 22);
            this.textBox4.TabIndex = 296;
            // 
            // chkBrds
            // 
            this.chkBrds.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkBrds.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBrds.Location = new System.Drawing.Point(19, 85);
            this.chkBrds.Name = "chkBrds";
            this.chkBrds.Size = new System.Drawing.Size(83, 28);
            this.chkBrds.TabIndex = 295;
            this.chkBrds.Text = "Boards :";
            this.chkBrds.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lS_rem
            // 
            this.lS_rem.BackColor = System.Drawing.Color.Transparent;
            this.lS_rem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lS_rem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lS_rem.Location = new System.Drawing.Point(211, 65);
            this.lS_rem.Name = "lS_rem";
            this.lS_rem.Size = new System.Drawing.Size(48, 23);
            this.lS_rem.TabIndex = 294;
            this.lS_rem.Text = "0";
            this.lS_rem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lR_rem
            // 
            this.lR_rem.BackColor = System.Drawing.Color.Transparent;
            this.lR_rem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lR_rem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lR_rem.Location = new System.Drawing.Point(211, 42);
            this.lR_rem.Name = "lR_rem";
            this.lR_rem.Size = new System.Drawing.Size(48, 23);
            this.lR_rem.TabIndex = 293;
            this.lR_rem.Text = "0";
            this.lR_rem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lQ_rem
            // 
            this.lQ_rem.BackColor = System.Drawing.Color.Transparent;
            this.lQ_rem.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lQ_rem.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lQ_rem.Location = new System.Drawing.Point(211, 18);
            this.lQ_rem.Name = "lQ_rem";
            this.lQ_rem.Size = new System.Drawing.Size(48, 24);
            this.lQ_rem.TabIndex = 292;
            this.lQ_rem.Text = "0";
            this.lQ_rem.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnAddGenID
            // 
            this.btnAddGenID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAddGenID.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAddGenID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnAddGenID.Location = new System.Drawing.Point(282, 8);
            this.btnAddGenID.Name = "btnAddGenID";
            this.btnAddGenID.Size = new System.Drawing.Size(191, 28);
            this.btnAddGenID.TabIndex = 198;
            this.btnAddGenID.Text = "Add New Serials IDs";
            this.btnAddGenID.Click += new System.EventHandler(this.btnAddGenID_Click);
            // 
            // tNB
            // 
            this.tNB.Location = new System.Drawing.Point(317, 39);
            this.tNB.Name = "tNB";
            this.tNB.Size = new System.Drawing.Size(115, 22);
            this.tNB.TabIndex = 196;
            this.tNB.Text = "500";
            this.tNB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tSfrom
            // 
            this.tSfrom.Location = new System.Drawing.Point(102, 65);
            this.tSfrom.Name = "tSfrom";
            this.tSfrom.ReadOnly = true;
            this.tSfrom.Size = new System.Drawing.Size(106, 22);
            this.tSfrom.TabIndex = 186;
            // 
            // tOfrom
            // 
            this.tOfrom.Location = new System.Drawing.Point(102, 42);
            this.tOfrom.Name = "tOfrom";
            this.tOfrom.ReadOnly = true;
            this.tOfrom.Size = new System.Drawing.Size(106, 22);
            this.tOfrom.TabIndex = 184;
            // 
            // tQfrom
            // 
            this.tQfrom.Location = new System.Drawing.Point(102, 18);
            this.tQfrom.Name = "tQfrom";
            this.tQfrom.ReadOnly = true;
            this.tQfrom.Size = new System.Drawing.Size(106, 22);
            this.tQfrom.TabIndex = 182;
            // 
            // chkSN
            // 
            this.chkSN.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSN.Location = new System.Drawing.Point(19, 62);
            this.chkSN.Name = "chkSN";
            this.chkSN.Size = new System.Drawing.Size(83, 28);
            this.chkSN.TabIndex = 180;
            this.chkSN.Text = "Systems:";
            this.chkSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkOrders
            // 
            this.chkOrders.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkOrders.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkOrders.Location = new System.Drawing.Point(19, 44);
            this.chkOrders.Name = "chkOrders";
            this.chkOrders.Size = new System.Drawing.Size(83, 18);
            this.chkOrders.TabIndex = 179;
            this.chkOrders.Text = "Orders :";
            this.chkOrders.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkQuote
            // 
            this.chkQuote.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkQuote.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkQuote.Location = new System.Drawing.Point(19, 21);
            this.chkQuote.Name = "chkQuote";
            this.chkQuote.Size = new System.Drawing.Size(83, 18);
            this.chkQuote.TabIndex = 178;
            this.chkQuote.Text = "Quotes :";
            this.chkQuote.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pS
            // 
            this.pS.Image = ((System.Drawing.Image)(resources.GetObject("pS.Image")));
            this.pS.Location = new System.Drawing.Point(367, 95);
            this.pS.Name = "pS";
            this.pS.Size = new System.Drawing.Size(39, 18);
            this.pS.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pS.TabIndex = 195;
            this.pS.TabStop = false;
            this.pS.Visible = false;
            // 
            // pR
            // 
            this.pR.Image = ((System.Drawing.Image)(resources.GetObject("pR.Image")));
            this.pR.Location = new System.Drawing.Point(413, 102);
            this.pR.Name = "pR";
            this.pR.Size = new System.Drawing.Size(38, 18);
            this.pR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pR.TabIndex = 194;
            this.pR.TabStop = false;
            this.pR.Visible = false;
            // 
            // pQ
            // 
            this.pQ.Image = ((System.Drawing.Image)(resources.GetObject("pQ.Image")));
            this.pQ.Location = new System.Drawing.Point(413, 83);
            this.pQ.Name = "pQ";
            this.pQ.Size = new System.Drawing.Size(38, 19);
            this.pQ.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pQ.TabIndex = 193;
            this.pQ.TabStop = false;
            this.pQ.Visible = false;
            // 
            // laff
            // 
            this.laff.BackColor = System.Drawing.Color.Khaki;
            this.laff.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laff.Location = new System.Drawing.Point(317, 62);
            this.laff.Name = "laff";
            this.laff.Size = new System.Drawing.Size(115, 19);
            this.laff.TabIndex = 192;
            this.laff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnNewGenID
            // 
            this.btnNewGenID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnNewGenID.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewGenID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnNewGenID.Location = new System.Drawing.Point(19, 148);
            this.btnNewGenID.Name = "btnNewGenID";
            this.btnNewGenID.Size = new System.Drawing.Size(106, 27);
            this.btnNewGenID.TabIndex = 177;
            this.btnNewGenID.Text = "Create IDs";
            this.btnNewGenID.Visible = false;
            this.btnNewGenID.Click += new System.EventHandler(this.btnNewGenID_Click);
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.Image = ((System.Drawing.Image)(resources.GetObject("picExit.Image")));
            this.picExit.Location = new System.Drawing.Point(874, 16);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(67, 65);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 209;
            this.picExit.TabStop = false;
            this.picExit.Visible = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // grpCurrU
            // 
            this.grpCurrU.Controls.Add(this.btn2Mn);
            this.grpCurrU.Controls.Add(this.lport);
            this.grpCurrU.Controls.Add(this.lip);
            this.grpCurrU.Controls.Add(this.btnbld);
            this.grpCurrU.Controls.Add(this.t_bld);
            this.grpCurrU.Controls.Add(this.label9);
            this.grpCurrU.Controls.Add(this.label8);
            this.grpCurrU.Controls.Add(this.tpwd);
            this.grpCurrU.Controls.Add(this.btnow);
            this.grpCurrU.Controls.Add(this.lstop);
            this.grpCurrU.Controls.Add(this.lSrvr_stat);
            this.grpCurrU.Controls.Add(this.lSrvr_statt);
            this.grpCurrU.Controls.Add(this.ldispUS);
            this.grpCurrU.Controls.Add(this.lmach);
            this.grpCurrU.Controls.Add(this.chkSUsr);
            this.grpCurrU.Controls.Add(this.chkALL);
            this.grpCurrU.Controls.Add(this.lUser);
            this.grpCurrU.Controls.Add(this.button10);
            this.grpCurrU.Controls.Add(this.label5);
            this.grpCurrU.Controls.Add(this.btnStop);
            this.grpCurrU.Controls.Add(this.btnOK);
            this.grpCurrU.Controls.Add(this.tmsg);
            this.grpCurrU.Controls.Add(this.label6);
            this.grpCurrU.Controls.Add(this.lvstation);
            this.grpCurrU.Controls.Add(this.btnSTOPALL);
            this.grpCurrU.Controls.Add(this.btnUPPGESCOM);
            this.grpCurrU.Location = new System.Drawing.Point(14, 9);
            this.grpCurrU.Name = "grpCurrU";
            this.grpCurrU.Size = new System.Drawing.Size(945, 390);
            this.grpCurrU.TabIndex = 215;
            this.grpCurrU.TabStop = false;
            this.grpCurrU.Visible = false;
            // 
            // btn2Mn
            // 
            this.btn2Mn.BackColor = System.Drawing.Color.PowderBlue;
            this.btn2Mn.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btn2Mn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn2Mn.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btn2Mn.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btn2Mn.Location = new System.Drawing.Point(755, 242);
            this.btn2Mn.Name = "btn2Mn";
            this.btn2Mn.Size = new System.Drawing.Size(78, 43);
            this.btn2Mn.TabIndex = 312;
            this.btn2Mn.Text = "ALL 2 mn";
            this.btn2Mn.UseVisualStyleBackColor = false;
            this.btn2Mn.Click += new System.EventHandler(this.btn2Mn_Click);
            // 
            // lport
            // 
            this.lport.BackColor = System.Drawing.Color.LightGreen;
            this.lport.Location = new System.Drawing.Point(648, 357);
            this.lport.Name = "lport";
            this.lport.Size = new System.Drawing.Size(187, 23);
            this.lport.TabIndex = 311;
            // 
            // lip
            // 
            this.lip.BackColor = System.Drawing.Color.LightGreen;
            this.lip.Location = new System.Drawing.Point(648, 333);
            this.lip.Name = "lip";
            this.lip.Size = new System.Drawing.Size(187, 24);
            this.lip.TabIndex = 310;
            // 
            // btnbld
            // 
            this.btnbld.BackColor = System.Drawing.Color.PowderBlue;
            this.btnbld.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnbld.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnbld.Image = ((System.Drawing.Image)(resources.GetObject("btnbld.Image")));
            this.btnbld.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnbld.Location = new System.Drawing.Point(499, 342);
            this.btnbld.Name = "btnbld";
            this.btnbld.Size = new System.Drawing.Size(125, 46);
            this.btnbld.TabIndex = 309;
            this.btnbld.Text = "UPDATE";
            this.btnbld.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnbld.UseVisualStyleBackColor = false;
            this.btnbld.Visible = false;
            this.btnbld.Click += new System.EventHandler(this.btnbld_Click);
            // 
            // t_bld
            // 
            this.t_bld.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.t_bld.Font = new System.Drawing.Font("Arial", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t_bld.ForeColor = System.Drawing.Color.Green;
            this.t_bld.Location = new System.Drawing.Point(307, 348);
            this.t_bld.MaxLength = 9;
            this.t_bld.Name = "t_bld";
            this.t_bld.ReadOnly = true;
            this.t_bld.Size = new System.Drawing.Size(192, 35);
            this.t_bld.TabIndex = 308;
            this.t_bld.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(202, 351);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 27);
            this.label9.TabIndex = 306;
            this.label9.Text = "Build#:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(624, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 28);
            this.label8.TabIndex = 304;
            this.label8.Text = "Pwd:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tpwd
            // 
            this.tpwd.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tpwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpwd.ForeColor = System.Drawing.Color.Blue;
            this.tpwd.Location = new System.Drawing.Point(691, 305);
            this.tpwd.MaxLength = 99;
            this.tpwd.Name = "tpwd";
            this.tpwd.PasswordChar = '*';
            this.tpwd.Size = new System.Drawing.Size(144, 26);
            this.tpwd.TabIndex = 303;
            this.tpwd.TextChanged += new System.EventHandler(this.tpwd_TextChanged);
            // 
            // btnow
            // 
            this.btnow.BackColor = System.Drawing.Color.PowderBlue;
            this.btnow.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnow.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnow.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnow.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnow.Location = new System.Drawing.Point(778, 208);
            this.btnow.Name = "btnow";
            this.btnow.Size = new System.Drawing.Size(57, 27);
            this.btnow.TabIndex = 302;
            this.btnow.Text = "Now";
            this.btnow.UseVisualStyleBackColor = false;
            this.btnow.Visible = false;
            this.btnow.Click += new System.EventHandler(this.button12_Click);
            // 
            // lstop
            // 
            this.lstop.BackColor = System.Drawing.SystemColors.Control;
            this.lstop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lstop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lstop.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstop.ForeColor = System.Drawing.Color.Red;
            this.lstop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lstop.Location = new System.Drawing.Point(5, 327);
            this.lstop.Name = "lstop";
            this.lstop.Size = new System.Drawing.Size(69, 27);
            this.lstop.TabIndex = 301;
            this.lstop.Text = "reset";
            this.lstop.UseVisualStyleBackColor = false;
            this.lstop.Click += new System.EventHandler(this.button9_Click);
            // 
            // lSrvr_stat
            // 
            this.lSrvr_stat.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lSrvr_stat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lSrvr_stat.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSrvr_stat.ForeColor = System.Drawing.Color.Green;
            this.lSrvr_stat.Location = new System.Drawing.Point(307, 295);
            this.lSrvr_stat.Name = "lSrvr_stat";
            this.lSrvr_stat.Size = new System.Drawing.Size(192, 34);
            this.lSrvr_stat.TabIndex = 300;
            this.lSrvr_stat.Text = "Running";
            this.lSrvr_stat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lSrvr_statt
            // 
            this.lSrvr_statt.BackColor = System.Drawing.Color.AliceBlue;
            this.lSrvr_statt.Font = new System.Drawing.Font("Arial Black", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSrvr_statt.ForeColor = System.Drawing.Color.Black;
            this.lSrvr_statt.Location = new System.Drawing.Point(86, 290);
            this.lSrvr_statt.Name = "lSrvr_statt";
            this.lSrvr_statt.Size = new System.Drawing.Size(221, 45);
            this.lSrvr_statt.TabIndex = 299;
            this.lSrvr_statt.Text = "PGESCOM is:";
            this.lSrvr_statt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ldispUS
            // 
            this.ldispUS.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.ldispUS.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ldispUS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ldispUS.Location = new System.Drawing.Point(173, 203);
            this.ldispUS.Name = "ldispUS";
            this.ldispUS.Size = new System.Drawing.Size(441, 37);
            this.ldispUS.TabIndex = 298;
            this.ldispUS.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ldispUS.Visible = false;
            // 
            // lmach
            // 
            this.lmach.BackColor = System.Drawing.Color.LightCoral;
            this.lmach.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmach.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmach.Location = new System.Drawing.Point(29, 268);
            this.lmach.Name = "lmach";
            this.lmach.Size = new System.Drawing.Size(48, 27);
            this.lmach.TabIndex = 295;
            this.lmach.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lmach.Visible = false;
            // 
            // chkSUsr
            // 
            this.chkSUsr.ForeColor = System.Drawing.Color.DarkRed;
            this.chkSUsr.Location = new System.Drawing.Point(10, 212);
            this.chkSUsr.Name = "chkSUsr";
            this.chkSUsr.Size = new System.Drawing.Size(163, 28);
            this.chkSUsr.TabIndex = 294;
            this.chkSUsr.Text = "Selected User/station";
            this.chkSUsr.CheckedChanged += new System.EventHandler(this.chkSUsr_CheckedChanged);
            // 
            // chkALL
            // 
            this.chkALL.Checked = true;
            this.chkALL.ForeColor = System.Drawing.Color.DarkRed;
            this.chkALL.Location = new System.Drawing.Point(10, 240);
            this.chkALL.Name = "chkALL";
            this.chkALL.Size = new System.Drawing.Size(163, 28);
            this.chkALL.TabIndex = 293;
            this.chkALL.TabStop = true;
            this.chkALL.Text = "All Stations";
            this.chkALL.CheckedChanged += new System.EventHandler(this.chkALL_CheckedChanged);
            // 
            // lUser
            // 
            this.lUser.BackColor = System.Drawing.Color.LightCoral;
            this.lUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lUser.Location = new System.Drawing.Point(86, 268);
            this.lUser.Name = "lUser";
            this.lUser.Size = new System.Drawing.Size(39, 27);
            this.lUser.TabIndex = 291;
            this.lUser.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lUser.Visible = false;
            // 
            // button10
            // 
            this.button10.BackColor = System.Drawing.Color.PowderBlue;
            this.button10.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button10.Font = new System.Drawing.Font("Palatino Linotype", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button10.Image = ((System.Drawing.Image)(resources.GetObject("button10.Image")));
            this.button10.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button10.Location = new System.Drawing.Point(10, 268);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(48, 55);
            this.button10.TabIndex = 290;
            this.button10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button10.UseVisualStyleBackColor = false;
            this.button10.Click += new System.EventHandler(this.button10_Click);
            // 
            // label5
            // 
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label5.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Blue;
            this.label5.Location = new System.Drawing.Point(10, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(825, 28);
            this.label5.TabIndex = 289;
            this.label5.Text = "Connected  Users/Stations";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.PowderBlue;
            this.btnStop.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnStop.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnStop.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnStop.Location = new System.Drawing.Point(710, 208);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(58, 27);
            this.btnStop.TabIndex = 287;
            this.btnStop.Text = "2 mn";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Visible = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.PowderBlue;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(701, 240);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(47, 45);
            this.btnOK.TabIndex = 286;
            this.btnOK.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // tmsg
            // 
            this.tmsg.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmsg.ForeColor = System.Drawing.Color.Blue;
            this.tmsg.Location = new System.Drawing.Point(221, 246);
            this.tmsg.MaxLength = 99;
            this.tmsg.Name = "tmsg";
            this.tmsg.Size = new System.Drawing.Size(480, 26);
            this.tmsg.TabIndex = 208;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Arial Black", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(173, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(48, 27);
            this.label6.TabIndex = 211;
            this.label6.Text = "Msg:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lvstation
            // 
            this.lvstation.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvstation.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.User,
            this.station,
            this.mdl,
            this.timeIn});
            this.lvstation.ForeColor = System.Drawing.Color.Blue;
            this.lvstation.FullRowSelect = true;
            this.lvstation.GridLines = true;
            this.lvstation.HideSelection = false;
            this.lvstation.Location = new System.Drawing.Point(10, 37);
            this.lvstation.MultiSelect = false;
            this.lvstation.Name = "lvstation";
            this.lvstation.Size = new System.Drawing.Size(923, 166);
            this.lvstation.TabIndex = 212;
            this.lvstation.UseCompatibleStateImageBehavior = false;
            this.lvstation.View = System.Windows.Forms.View.Details;
            this.lvstation.SelectedIndexChanged += new System.EventHandler(this.lvstation_SelectedIndexChanged);
            // 
            // User
            // 
            this.User.Text = "User";
            this.User.Width = 141;
            // 
            // station
            // 
            this.station.Text = "Station";
            this.station.Width = 139;
            // 
            // mdl
            // 
            this.mdl.Text = "Module / Build#";
            this.mdl.Width = 386;
            // 
            // timeIn
            // 
            this.timeIn.Text = "";
            this.timeIn.Width = 0;
            // 
            // btnSTOPALL
            // 
            this.btnSTOPALL.BackColor = System.Drawing.SystemColors.Control;
            this.btnSTOPALL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSTOPALL.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTOPALL.ForeColor = System.Drawing.Color.Black;
            this.btnSTOPALL.Image = ((System.Drawing.Image)(resources.GetObject("btnSTOPALL.Image")));
            this.btnSTOPALL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSTOPALL.Location = new System.Drawing.Point(499, 287);
            this.btnSTOPALL.Name = "btnSTOPALL";
            this.btnSTOPALL.Size = new System.Drawing.Size(125, 49);
            this.btnSTOPALL.TabIndex = 296;
            this.btnSTOPALL.Text = "STOP";
            this.btnSTOPALL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSTOPALL.UseVisualStyleBackColor = false;
            this.btnSTOPALL.Visible = false;
            this.btnSTOPALL.Click += new System.EventHandler(this.btnSTOPALL_Click);
            // 
            // btnUPPGESCOM
            // 
            this.btnUPPGESCOM.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPPGESCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUPPGESCOM.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPPGESCOM.Image = ((System.Drawing.Image)(resources.GetObject("btnUPPGESCOM.Image")));
            this.btnUPPGESCOM.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUPPGESCOM.Location = new System.Drawing.Point(499, 287);
            this.btnUPPGESCOM.Name = "btnUPPGESCOM";
            this.btnUPPGESCOM.Size = new System.Drawing.Size(125, 49);
            this.btnUPPGESCOM.TabIndex = 297;
            this.btnUPPGESCOM.Text = "START";
            this.btnUPPGESCOM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUPPGESCOM.UseVisualStyleBackColor = false;
            this.btnUPPGESCOM.Visible = false;
            this.btnUPPGESCOM.Click += new System.EventHandler(this.btnUPPGESCOM_Click);
            // 
            // grpConfig
            // 
            this.grpConfig.Controls.Add(this.button13);
            this.grpConfig.Controls.Add(this.txDymo);
            this.grpConfig.Controls.Add(this.button12);
            this.grpConfig.Controls.Add(this.txPDFrdr);
            this.grpConfig.Controls.Add(this.btnSVpdf);
            this.grpConfig.Controls.Add(this.label12);
            this.grpConfig.Controls.Add(this.label11);
            this.grpConfig.Controls.Add(this.button9);
            this.grpConfig.Controls.Add(this.lWQfiles);
            this.grpConfig.Controls.Add(this.svDymo);
            this.grpConfig.Controls.Add(this.label3);
            this.grpConfig.Controls.Add(this.btnsaveConfig);
            this.grpConfig.Controls.Add(this.label2);
            this.grpConfig.Controls.Add(this.button3);
            this.grpConfig.Controls.Add(this.tpbsPath);
            this.grpConfig.Controls.Add(this.cbprinters);
            this.grpConfig.Controls.Add(this.button7);
            this.grpConfig.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpConfig.Location = new System.Drawing.Point(19, 46);
            this.grpConfig.Name = "grpConfig";
            this.grpConfig.Size = new System.Drawing.Size(916, 244);
            this.grpConfig.TabIndex = 211;
            this.grpConfig.TabStop = false;
            this.grpConfig.Visible = false;
            // 
            // button13
            // 
            this.button13.BackColor = System.Drawing.Color.Orange;
            this.button13.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button13.Font = new System.Drawing.Font("Constantia", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button13.Location = new System.Drawing.Point(713, 135);
            this.button13.Name = "button13";
            this.button13.Size = new System.Drawing.Size(188, 37);
            this.button13.TabIndex = 217;
            this.button13.Text = "mail / primax-e.com ";
            this.button13.UseVisualStyleBackColor = false;
            this.button13.Click += new System.EventHandler(this.button13_Click);
            // 
            // txDymo
            // 
            this.txDymo.BackColor = System.Drawing.SystemColors.Control;
            this.txDymo.Location = new System.Drawing.Point(130, 106);
            this.txDymo.Name = "txDymo";
            this.txDymo.Size = new System.Drawing.Size(364, 22);
            this.txDymo.TabIndex = 216;
            // 
            // button12
            // 
            this.button12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button12.Location = new System.Drawing.Point(494, 140);
            this.button12.Name = "button12";
            this.button12.Size = new System.Drawing.Size(77, 23);
            this.button12.TabIndex = 215;
            this.button12.Text = "Browse...";
            this.button12.Click += new System.EventHandler(this.button12_Click_1);
            // 
            // txPDFrdr
            // 
            this.txPDFrdr.BackColor = System.Drawing.SystemColors.Control;
            this.txPDFrdr.Location = new System.Drawing.Point(130, 140);
            this.txPDFrdr.Name = "txPDFrdr";
            this.txPDFrdr.Size = new System.Drawing.Size(364, 22);
            this.txPDFrdr.TabIndex = 214;
            // 
            // btnSVpdf
            // 
            this.btnSVpdf.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSVpdf.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSVpdf.Location = new System.Drawing.Point(576, 140);
            this.btnSVpdf.Name = "btnSVpdf";
            this.btnSVpdf.Size = new System.Drawing.Size(77, 24);
            this.btnSVpdf.TabIndex = 213;
            this.btnSVpdf.Text = "Save ";
            this.btnSVpdf.Click += new System.EventHandler(this.btnSVpdf_Click);
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(7, 142);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(123, 18);
            this.label12.TabIndex = 212;
            this.label12.Text = "PDF reader:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(10, 47);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(139, 19);
            this.label11.TabIndex = 210;
            this.label11.Text = "Quotes Word files:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button9
            // 
            this.button9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button9.Location = new System.Drawing.Point(624, 45);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(77, 23);
            this.button9.TabIndex = 209;
            this.button9.Text = "Browse...";
            this.button9.Visible = false;
            // 
            // lWQfiles
            // 
            this.lWQfiles.BackColor = System.Drawing.SystemColors.Control;
            this.lWQfiles.Location = new System.Drawing.Point(149, 45);
            this.lWQfiles.Name = "lWQfiles";
            this.lWQfiles.Size = new System.Drawing.Size(480, 22);
            this.lWQfiles.TabIndex = 208;
            // 
            // svDymo
            // 
            this.svDymo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.svDymo.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.svDymo.Location = new System.Drawing.Point(494, 84);
            this.svDymo.Name = "svDymo";
            this.svDymo.Size = new System.Drawing.Size(77, 24);
            this.svDymo.TabIndex = 169;
            this.svDymo.Text = "Save ";
            this.svDymo.Click += new System.EventHandler(this.svDymo_Click);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(14, 84);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(116, 19);
            this.label3.TabIndex = 168;
            this.label3.Text = "Label Printer:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnsaveConfig
            // 
            this.btnsaveConfig.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnsaveConfig.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnsaveConfig.Location = new System.Drawing.Point(710, 15);
            this.btnsaveConfig.Name = "btnsaveConfig";
            this.btnsaveConfig.Size = new System.Drawing.Size(87, 24);
            this.btnsaveConfig.TabIndex = 126;
            this.btnsaveConfig.Text = "Save";
            this.btnsaveConfig.Click += new System.EventHandler(this.btnsaveConfig_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(22, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(127, 19);
            this.label2.TabIndex = 125;
            this.label2.Text = " PBSIZING Path:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button3
            // 
            this.button3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(624, 15);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(77, 23);
            this.button3.TabIndex = 124;
            this.button3.Text = "Browse...";
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // tpbsPath
            // 
            this.tpbsPath.BackColor = System.Drawing.SystemColors.Control;
            this.tpbsPath.Location = new System.Drawing.Point(149, 15);
            this.tpbsPath.Name = "tpbsPath";
            this.tpbsPath.Size = new System.Drawing.Size(480, 22);
            this.tpbsPath.TabIndex = 123;
            // 
            // cbprinters
            // 
            this.cbprinters.BackColor = System.Drawing.Color.Lavender;
            this.cbprinters.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbprinters.ForeColor = System.Drawing.Color.ForestGreen;
            this.cbprinters.Location = new System.Drawing.Point(130, 83);
            this.cbprinters.Name = "cbprinters";
            this.cbprinters.Size = new System.Drawing.Size(364, 24);
            this.cbprinters.TabIndex = 167;
            // 
            // button7
            // 
            this.button7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button7.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button7.Location = new System.Drawing.Point(7, 190);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(821, 37);
            this.button7.TabIndex = 207;
            this.button7.Text = "Build  formulas Tables  (only if you add new or change formulas )";
            this.button7.Visible = false;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // timer1
            // 
            this.timer1.Interval = 20000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // button11
            // 
            this.button11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button11.Font = new System.Drawing.Font("Comic Sans MS", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button11.Location = new System.Drawing.Point(701, 582);
            this.button11.Name = "button11";
            this.button11.Size = new System.Drawing.Size(221, 46);
            this.button11.TabIndex = 215;
            this.button11.Text = "Charger Cost";
            this.button11.Visible = false;
            this.button11.Click += new System.EventHandler(this.button11_Click);
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(718, 14);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(57, 55);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 265;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "EXE files|*.exe|All files|*.*";
            // 
            // TSmain
            // 
            this.TSmain.AutoSize = false;
            this.TSmain.BackColor = System.Drawing.Color.Bisque;
            this.TSmain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Addids,
            this.unlock,
            this.tlsusers,
            this.tlsconf,
            this.tlsSTAT,
            this._exit});
            this.TSmain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.TSmain.Location = new System.Drawing.Point(0, 0);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(964, 73);
            this.TSmain.TabIndex = 260;
            // 
            // Addids
            // 
            this.Addids.Image = ((System.Drawing.Image)(resources.GetObject("Addids.Image")));
            this.Addids.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Addids.Name = "Addids";
            this.Addids.Size = new System.Drawing.Size(66, 89);
            this.Addids.Text = "Add IDs";
            this.Addids.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Addids.Visible = false;
            this.Addids.Click += new System.EventHandler(this.Addids_Click);
            // 
            // unlock
            // 
            this.unlock.Image = ((System.Drawing.Image)(resources.GetObject("unlock.Image")));
            this.unlock.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.unlock.Name = "unlock";
            this.unlock.Size = new System.Drawing.Size(102, 70);
            this.unlock.Text = "UNLOCK User";
            this.unlock.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.unlock.Click += new System.EventHandler(this.unlock_Click);
            // 
            // tlsusers
            // 
            this.tlsusers.Image = ((System.Drawing.Image)(resources.GetObject("tlsusers.Image")));
            this.tlsusers.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsusers.Name = "tlsusers";
            this.tlsusers.Size = new System.Drawing.Size(106, 89);
            this.tlsusers.Text = "Manage Users";
            this.tlsusers.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsusers.Visible = false;
            this.tlsusers.Click += new System.EventHandler(this.tlsusers_Click);
            // 
            // tlsconf
            // 
            this.tlsconf.Image = ((System.Drawing.Image)(resources.GetObject("tlsconf.Image")));
            this.tlsconf.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsconf.Name = "tlsconf";
            this.tlsconf.Size = new System.Drawing.Size(129, 89);
            this.tlsconf.Text = "PGESCOM config.";
            this.tlsconf.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsconf.Visible = false;
            this.tlsconf.Click += new System.EventHandler(this.tlsconf_Click);
            // 
            // tlsSTAT
            // 
            this.tlsSTAT.Image = ((System.Drawing.Image)(resources.GetObject("tlsSTAT.Image")));
            this.tlsSTAT.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSTAT.Name = "tlsSTAT";
            this.tlsSTAT.Size = new System.Drawing.Size(66, 89);
            this.tlsSTAT.Text = "Stations";
            this.tlsSTAT.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsSTAT.Visible = false;
            this.tlsSTAT.Click += new System.EventHandler(this.tlsSTAT_Click);
            // 
            // _exit
            // 
            this._exit.Image = ((System.Drawing.Image)(resources.GetObject("_exit.Image")));
            this._exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(61, 70);
            this._exit.Text = "   Exit   ";
            this._exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._exit.ToolTipText = "Exit";
            this._exit.Click += new System.EventHandler(this._exit_Click);
            // 
            // Misc
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(964, 555);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.picCIP);
            this.Controls.Add(this.TSmain);
            this.Controls.Add(this.button11);
            this.Controls.Add(this.lvTools);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Misc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tools";
            this.Load += new System.EventHandler(this.Misc_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.grpFree.ResumeLayout(false);
            this.grpFree.PerformLayout();
            this.grpIDs.ResumeLayout(false);
            this.grpIDs.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pS)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pR)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pQ)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            this.grpCurrU.ResumeLayout(false);
            this.grpCurrU.PerformLayout();
            this.grpConfig.ResumeLayout(false);
            this.grpConfig.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
            /*			
			string stCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\primax.mdb " + @";Persist Security Info=False;Jet OLEDB:Database Password =" + "aaa999";

		    string stSql = "select * FROM PSM_Options_PriceList where Option_ID=" + loptID.Text + " and CAT1_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[1].Text + "' and CAT2_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[2].Text + "' and CAT3_VALUE='" + lvOptPricelst.SelectedItems[0].SubItems[3].Text + "'";
			SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				loptPLID.Text = Oreadr["PRICE_LINE_ID"].ToString();
				tManifac.Text = Oreadr["Manufac_PARTN"].ToString();
				tPx.Text = Oreadr["Manufac_PARTN"].ToString();
				tCat1.Text = Oreadr["CAT1_VALUE"].ToString();
				tCat2.Text = Oreadr["CAT2_VALUE"].ToString();
				tCat3.Text = Oreadr["CAT3_VALUE"].ToString();
				tCat4.Text = Oreadr["CAT4_VALUE"].ToString();
				tCat5.Text = Oreadr["CAT5_VALUE"].ToString();
				tCat6.Text = Oreadr["CAT6_VALUE"].ToString();
				tUPrice.Text = Oreadr["PRICE"].ToString();
				tDlvDelay.Text = Oreadr["LeadTime"].ToString();
				tComnt.Text = Oreadr["COMMENTS"].ToString();
				
				r_tManifac.Text = Oreadr["Manufac_PARTN"].ToString();
				r_tPx.Text = Oreadr["Manufac_PARTN"].ToString();
				r_tCat1.Text = Oreadr["CAT1_VALUE"].ToString();
				r_tCat2.Text = Oreadr["CAT2_VALUE"].ToString();
				r_tCat3.Text = Oreadr["CAT3_VALUE"].ToString();
				r_tCat4.Text = Oreadr["CAT4_VALUE"].ToString();
				r_tCat5.Text = Oreadr["CAT5_VALUE"].ToString();
				r_tCat6.Text = Oreadr["CAT6_VALUE"].ToString();
				r_tUPrice.Text = Oreadr["PRICE"].ToString();
				r_tDlvDelay.Text = Oreadr["LeadTime"].ToString();

				btnOK.Text = "&Update";
			}
			OConn.Close();
			*/
            label1.Text = TransN(textBox1.Text);
		}

		private void find_REM_IDs()
		{
			lQ_rem.Text = MainMDI.Find_One_Field("SELECT COUNT(QID) FROM  PSM_Q_GenID WHERE flaged = 0 AND InUse = 0 ");
			lR_rem.Text = MainMDI.Find_One_Field("SELECT COUNT(RID) FROM  PSM_R_GenID WHERE flaged = 0 AND InUse = 0 ");
			lS_rem.Text = MainMDI.Find_One_Field("SELECT COUNT(SID) FROM  PSM_S_GenID WHERE flaged = 0 AND InUse = 0 ");
            lG9rem.Text = MainMDI.Find_One_Field("SELECT COUNT(GID) FROM  PSM_G_GenID WHERE flaged = 0 ");
		}

        private void Misc_Load(object sender, System.EventArgs e)
        {
            if (MainMDI.WQfiles == "") MainMDI.WQfiles = @"H:\Sales\PSM_Quotes";
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);

            //string stCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\PSM_FDB.mdb " + @";Persist Security Info=False;Jet OLEDB:Database Password =" + "aaa999";
            tpbsPath.Text = MainMDI.PBSPath;
            txPDFrdr.Text = MainMDI.PDF_READER;
            lWQfiles.Text = MainMDI.WQfiles;
            txDymo.Text = MainMDI.DYMOName;
            cbprinters.Text = MainMDI.DYMOName;
            fill_lvUsers();
            btnUPGC.Visible = (MainMDI.User.ToLower() != "unlock");
            if (Admin() || MainMDI.profile == 'S')
            {
                cbUsers.Visible = true;
                tuser.Text = MainMDI.User;
            }
            else cbUsers.Visible = false;

            Addids.Visible = Admin();
            tlsconf.Visible = Admin();
            tlsSTAT.Visible = Admin();
            tlsusers.Visible = Admin();

            //if (MainMDI.profile == 'N' || MainMDI.User.ToUpper() != "UNLOCK")
            //{
                //cbUsers.Visible = false;
                //tuser.Text = MainMDI.User;
            //}
            //else
                //grpIDs.Visible = (MainMDI.profile == 'S' && MainMDI.User.ToUpper() != "UNLOCK");
            //cbUsers.Visible = (MainMDI.profile == 'S' && MainMDI.User.ToUpper() != "UNLOCK");

            //lvTools.Items[0].Selected = true;
            //if (MainMDI.User.ToLower() != "ede") lvTools.Items[4].Remove(); //.Text = (MainMDI.User.ToLower() == "Admin") ? "Stations" : " ";
        }

        private void Misc_LoadoldFashion(object sender, System.EventArgs e)
        {
            if (MainMDI.WQfiles == "") MainMDI.WQfiles = @"H:\Sales\PSM_Quotes";
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);

            //string stCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\PSM_FDB.mdb " + @";Persist Security Info=False;Jet OLEDB:Database Password =" + "aaa999";
            tpbsPath.Text = MainMDI.PBSPath;
            txPDFrdr.Text = MainMDI.PDF_READER;
            lWQfiles.Text = MainMDI.WQfiles;
            txDymo.Text = MainMDI.DYMOName;
            cbprinters.Text = MainMDI.DYMOName;
            if (MainMDI.profile == 'N' || MainMDI.User.ToUpper() != "UNLOCK")
            {
                //groupBox2.Enabled = false;
                //button5.Visible = false;

                cbUsers.Visible = false;
                tuser.Text = MainMDI.User;
                //tUserName.Text = MainMDI.User;

                //tuser.ReadOnly = true;
                //tUserName.ReadOnly = true;
            }
            else
                grpIDs.Visible = (MainMDI.profile == 'S' && MainMDI.User.ToUpper() != "UNLOCK");
            cbUsers.Visible = (MainMDI.profile == 'S' && MainMDI.User.ToUpper() != "UNLOCK");

            fill_lvUsers();
            lvTools.Items[0].Selected = true;
            if (MainMDI.User.ToLower() != "ede") lvTools.Items[4].Remove(); //.Text = (MainMDI.User.ToLower() == "Admin") ? "Stations" : " ";
            //if (MainMDI.User.ToUpper() == "UNLOCK") for (int i = 0; i < 5) 

            btnUPGC.Visible = (MainMDI.User.ToLower() != "unlock");
        }

		private void Misc_Loadold(object sender, System.EventArgs e)
		{
            if (MainMDI.WQfiles == "") MainMDI.WQfiles = @"H:\Sales\PSM_Quotes";
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);

			//string stCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + Application.StartupPath + "\\PSM_FDB.mdb " + @";Persist Security Info=False;Jet OLEDB:Database Password =" + "aaa999";
	        tpbsPath.Text = MainMDI.PBSPath;
            txPDFrdr.Text = MainMDI.PDF_READER;
            lWQfiles.Text = MainMDI.WQfiles;
            txDymo.Text = MainMDI.DYMOName;
            cbprinters.Text = MainMDI.DYMOName;
			if (MainMDI.profile == 'N' || MainMDI.User.ToUpper() != "UNLOCK")
			{
				//groupBox2.Enabled = false;
				//button5.Visible = false;

				cbUsers.Visible = false;
				tuser.Text = MainMDI.User;
				//tUserName.Text = MainMDI.User;
				
				//tuser.ReadOnly = true;
				//tUserName.ReadOnly = true;
			}
			else
	        //grpIDs.Visible = (MainMDI.profile == 'S' && MainMDI.User.ToUpper() != "UNLOCK");
	        //cbUsers.Visible = (MainMDI.profile == 'S' && MainMDI.User.ToUpper() != "UNLOCK");
            grpIDs.Visible = (MainMDI.User.ToLower() == "ede");
            cbUsers.Visible = (MainMDI.User.ToLower() == "ede");
			
			fill_lvUsers();
			lvTools.Items[0].Selected = true;
            if (MainMDI.User.ToLower() != "ede") lvTools.Items[4].Remove(); //.Text = (MainMDI.User.ToLower() == "Admin") ? "Stations" : " ";
		    //if (MainMDI.User.ToUpper() == "UNLOCK") for (int i = 0; i < 5)

            btnUPGC.Visible = (MainMDI.User.ToLower() != "unlock");
		}

		private string TransN(string st)
		{
			string stNum = "";
			string stS = "";
			int i = 0;
			bool fin = false;
			while (!fin && i < st.Length)
			{
                if (st[i] > 47 && st[i] < 58) stNum = stNum + st[i];
                else fin = true;
			    i++;	
			}
			if (i < st.Length) stS = st.Substring(i, st.Length - i);
			if (stNum.Length == 3) stNum = "0" + stNum;
			return (stNum + stS);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			 string st = textBox1.Text;
			 
		    //MessageBox.Show(st.IndexOfAny(".,".ToCharArray(), 1).ToString());
		    //MessageBox.Show("ndx= " + "0123456789.,".IndexOf(st[0], 0));
		    //MessageBox.Show("#ndx debu..= " + st.IndexOf(".", 0));
		    //MessageBox.Show("#ndx Suite ..= " + st.LastIndexOf(".", st.IndexOf(".", 0) + 1));
		    //MessageBox.Show("#ndx ..= " + st.IndexOf(",", 0));
			label1.Text = "";
            if (Tools.IsNumeric(textBox1.Text)) label1.Text = Tools.Conv_Dbl(textBox1.Text).ToString();
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			folderBrowserDialog1.ShowDialog();
			tpbsPath.Text = folderBrowserDialog1.SelectedPath;
		}

		private void btnsaveConfig_Click(object sender, System.EventArgs e)
		{
			if (tpbsPath.Text != "" && MainMDI.PBSPath != tpbsPath.Text)
			{
				MainMDI.PBSPath = @tpbsPath.Text;
			    //MainMDI.ExecSql("INSERT INTO PSM_users_New_Config ([PBSpath]) VALUES ('" + MainMDI.PBSPath + "') where userID=" + MainMDI.UserID);
			    MainMDI.ExecSql("UPDATE PSM_Loc_Config  SET [PBSpath]='" + MainMDI.PBSPath + "', [curr_usr]=" + MainMDI.User + "'");
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnAddGenID_ClickOLD(object sender, System.EventArgs e)
		{
			laff.Text = "";
			ltime.Text = DateTime.Now.ToShortTimeString();
			ltime.Refresh();
			if (chkQuote.Checked && tNB.Text != "") AddID('Q');	
			if (chkOrders.Checked && tNB.Text != "") AddID('R');
			if (chkSN.Checked && tNB.Text != "") AddID('S');
			if (laff.Text != "") MessageBox.Show("New ADs were added to ID_LIST  ");
			ltime.Text = ltime.Text + "  " + DateTime.Now.ToShortTimeString();
		}

		private void btnNewGenID_ClickOLD(object sender, System.EventArgs e)
		{
            laff.Text = "";
            ltime.Text = DateTime.Now.ToShortTimeString();
		    ltime.Refresh();
		    if (chkQuote.Checked && tQfrom.Text != "" && tNB.Text != "") NewID('Q', tQfrom.Text);
		    if (chkOrders.Checked && tOfrom.Text != "" && tNB.Text != "") NewID('R', tOfrom.Text);
		    if (chkSN.Checked && tSfrom.Text != "" && tNB.Text != "") NewID('S', tSfrom.Text);
		    if (laff.Text != "") MessageBox.Show("ID_LIST Creation Completed...   ");
            ltime.Text = ltime.Text + "  " + DateTime.Now.ToShortTimeString();
		}

		private void fill_lvUsers()
		{
			cbUsers.Items.Clear();
			string stSql = "select * fROM PSM_users_New order by [user]";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read()) cbUsers.Items.Add(Oreadr["user"].ToString());
			OConn.Close();
		}

		private void fill_stations()
		{
			//string stSql = "select * fROM PSM_Whodo order by [dateIn]";
            string stSql = " SELECT PSM_SYSETUP.IpAdrs, PSM_SYSETUP.IPport, PSM_Whodo.* FROM PSM_Whodo INNER JOIN PSM_SYSETUP ON PSM_Whodo.machNm = PSM_SYSETUP.s_machNm ORDER BY PSM_Whodo.dateIn ";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			lvstation.Items.Clear();
			lvstation.BeginUpdate();
			
			while (Oreadr.Read())
			{
				ListViewItem lvI = lvstation.Items.Add(Oreadr["UserNm"].ToString());
				lvI.SubItems.Add(Oreadr["machNm"].ToString());
				lvI.SubItems.Add(Oreadr["modlNm"].ToString());
				lvI.SubItems.Add(Oreadr["dateIn"].ToString());

                //added for tcp
                lvI.SubItems[0].Tag = (Oreadr["IpAdrs"].ToString().Length > 0) ? Oreadr["IpAdrs"].ToString() : MainMDI.VIDE;
                lvI.SubItems[1].Tag = (Oreadr["IPport"].ToString().Length > 0) ? Oreadr["IPport"].ToString() : MainMDI.VIDE;
			}
			lvstation.EndUpdate();
            chkServer();
			OConn.Close();
		}

		private void chkServer()
		{
			string SrvrST = "", r_bld = "";
			MainMDI.Find_2_Field("select s_stat , BLD from PSM_SYSETUP where  s_machNm='PGESCOM' ", ref SrvrST, ref r_bld);
			t_bld.Text = r_bld;
		    //btnUPPGESCOM.Enabled = (SrvrST == "8" || SrvrST == "9");
		    //btnSTOPALL.Enabled =! btnUPPGESCOM.Enabled;
			if (SrvrST == "8" || SrvrST == "9")
			{
			    //btnUPPGESCOM.BringToFront();
				lSrvr_stat.Text = "Stopped";
				lSrvr_stat.ForeColor = Color.Red;
			}
			else 
			{
			    //btnSTOPALL.BringToFront();
				lSrvr_stat.Text = "Running";
				lSrvr_stat.ForeColor = Color.Green;
			}
		}

		private void NewID(char c, string from)
		{
			MainMDI.ExecSql("DELETE * from PSM_" + c + "_GenID");
			CreateNewIDs_QRID(c, Convert.ToInt32(from), Convert.ToInt32(tNB.Text));
		}

		private void AddID(char c)
		{
			string from = MainMDI.Find_One_Field("Select " + c + "ID from PSM_" + c + "_GenID order by " + c + "ID DESC");
			if (from == MainMDI.VIDE) from = "0";
			CreateNewIDs_QRID(c, Convert.ToInt32(from) + 1, Convert.ToInt32(tNB.Text));
		}

		private bool addNEWIDs_QRS(char c, int NBIds)
		{
			string tblNm = "PSM_" + c + "_GenID";
			try
			{
				for (int i = 0; i < NBIds; i++)
				{
					MainMDI.ExecSql("INSERT INTO " + tblNm + " ([flaged],[inuse]) VALUES (0,0)");
					laff.Text = i.ToString();
					laff.Refresh();
				}
				return true;
			}
			catch (SqlException Oexp)
			{
				MainMDI.stXP = tblNm + " IDs Creation failed....." + Oexp.Message;
				return false;
			}
		}

        private bool addNEWIDs_MACAdrs(long NBIds)
        {
            string tblNm = "PSM_B_MAC_GenID";
            try
            {
                for (long i = 0; i < NBIds; i++)
                {
                    MainMDI.ExecSql("INSERT INTO " + tblNm + " ([flaged],[log]) VALUES (0,' ')");
                    laff.Text = i.ToString();
                    laff.Refresh();
                }
                return true;
            }
            catch (SqlException Oexp)
            {
                MainMDI.stXP = tblNm + " MAC Adrs IDs Creation failed....." + Oexp.Message;
                return false;
            }
        }

		private void chkQuote_CheckedChanged(object sender, System.EventArgs e)
		{
			tQfrom.Text = MainMDI.Find_One_Field("select QID from PSM_Q_GenID order by QID DESC");
		}

		private void tQfrom_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyInt(e.KeyChar);
		}

		private void tOfrom5_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyInt(e.KeyChar);
		}

		private void tSfrom_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyInt(e.KeyChar);
		}

		private void btnCancel_Click_1(object sender, System.EventArgs e)
		{
			this.Close();
		}

        /*
		private double Conv_Dbl(string st)
		{
			int ipos = st.IndexOfAny(".,".ToCharArray(), 1);
			if (ipos > -1) st = st.Substring(0, ipos) + System.Globalization.NumberFormatInfo.CurrentInfo.NumberDecimalSeparator.ToString() + st.Substring(ipos + 1, st.Length - ipos - 1);
			//MessageBox.Show("ST= " + st);
        	return Double.Parse(st);
		}

		private bool IsNumeric(string st)
		{
			int i = 0;
			int Vpos = st.IndexOf(",", 0);
			int Ppos = st.IndexOf(".", 0);
			st = st.Trim();
			bool NumRes = (st != "" && !(st.IndexOf(".", Ppos + 1) > -1) && !(st.IndexOf(",", Vpos + 1) > -1));
			if (Vpos > -1 && Ppos > -1) NumRes = false;
			if (st.Length == 1 && (Vpos > -1 || Ppos > -1)) NumRes = false;
			while (i < st.Length && NumRes) NumRes = ("0123456789.,".IndexOf(st[i++], 0) > -1);
		    //MessageBox.Show("Numeric= " + NumRes.ToString() + "    I=" + i.ToString());
			
			return NumRes;
		}		
        */

		private bool CreateNewIDs_QRID(char c, long debId, int NBids)
		{
			string tblNm = "PSM_" + c + "_GenID";
			try
			{	
				pQ.Visible = c == 'Q';
                pR.Visible = c == 'R';
				pS.Visible = c == 'S';
				grpIDs.Refresh();
				for (long i = 0; i < NBids; i++)
				{
					MainMDI.ExecSql("INSERT INTO " + tblNm + " ([" + c + "ID], [flaged],[inuse]) VALUES (" + debId++ + ",FALSE,FALSE)");
				    laff.Text = i.ToString();
					laff.Refresh();
					this.Refresh();
				}
				return true;
			}
			catch (SqlException Oexp)
			{
				MainMDI.stXP = tblNm + " IDs Creation failed....." + Oexp.Message;
				return false;
			}
		}

		private void button55555_Click(object sender, System.EventArgs e)
		{
			Passwd frmpass = new Passwd('U');
			frmpass.ShowDialog();
		    //if (frmpass.denied) Application.Exit();
		}

		private void button4_Click(object sender, System.EventArgs e)
		{
            if (tuser.Text != "")
                if (tuser.Text.ToLower() == MainMDI.User.ToLower() || MainMDI.profile == 'S') {
                    bool success;
                    success  = MainMDI.Use_QRID(-1, 'Q', tuser.Text);
                    if (success == true)
                    {
                        MessageBox.Show("success");
                    } else
                    {
                        MessageBox.Show("An error occured");
                    }
                } 
		}

        //unlock user button
		private void button6_Click(object sender, System.EventArgs e)
		{
            bool success;
			string mch = MainMDI.Find_One_Field("select machNm  from PSM_Whodo where UserNm='" + MainMDI.User + "'");
			success = MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where [user]='" + tuser.Text + "' and  inuse='1'");

            if (success == true)
            {
                MessageBox.Show("User was unlocked with success");
            } else
            {
                MessageBox.Show("An error occured");
            }
        }

		private void BIGFILES()
		{
			Fill_BigFile13 fillbgf = new Fill_BigFile13();
			fillbgf.ShowDialog();
		}

		private void svDymo_Click(object sender, System.EventArgs e)
		{
			if (cbprinters.Text != "")
			{
				//MainMDI.ExecSql("INSERT INTO PSM_users_New_Config ([PBSpath]) VALUES ('" + MainMDI.PBSPath + "') where userID=" + MainMDI.UserID);
		        //MainMDI.ExecSql("UPDATE PSM_Loc_Config  SET [DymoName]='" + cbprinters.Text + "' where Mach_Name='" + MainMDI.Mach_Name + "'");
                MainMDI.ExecSql("UPDATE PSM_Loc_Config  SET [DymoName]='" + cbprinters.Text + "' where curr_usr='" + MainMDI.User.ToLower() + "'");
			    MainMDI.DYMOName = @cbprinters.Text;
				MessageBox.Show("Please, Restart your GESCOM.");
			}
		}

        void savePDF()
        {
            if (txPDFrdr.Text != "")
            {
                //MainMDI.ExecSql("INSERT INTO PSM_users_New_Config ([PBSpath]) VALUES ('" + MainMDI.PBSPath + "') where userID=" + MainMDI.UserID);
                MainMDI.ExecSql("UPDATE PSM_Loc_Config  SET [PDFfiles]='" + txPDFrdr.Text + "' where Mach_Name='" + MainMDI.Mach_Name + "'");
                MainMDI.PDF_READER = @txPDFrdr.Text;
                MessageBox.Show("Please, Restart your GESCOM.");
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
			cbprinters.Text = @MainMDI.DYMOName;
		}

		private void button8_Click(object sender, System.EventArgs e)
		{

		}

		private void picExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void chkOrders_CheckedChanged(object sender, System.EventArgs e)
		{
			tOfrom.Text = MainMDI.Find_One_Field("select RID from PSM_R_GenID order by RID DESC");
		}

		private void chkSN_CheckedChanged(object sender, System.EventArgs e)
		{
			tSfrom.Text = MainMDI.Find_One_Field("select SID from PSM_S_GenID order by SID DESC");
		}

		private void btnAddGenID_Click(object sender, System.EventArgs e)
		{
            this.Cursor = Cursors.WaitCursor;
			laff.Text = "";
			ltime.Text = DateTime.Now.ToShortTimeString();
			ltime.Refresh();
			if (chkQuote.Checked && tNB.Text != "") addNEWIDs_QRS('Q',Convert.ToInt32(tNB.Text));
			if (chkOrders.Checked && tNB.Text != "") addNEWIDs_QRS('R',Convert.ToInt32(tNB.Text));
			if (chkSN.Checked && tNB.Text != "") addNEWIDs_QRS('S',Convert.ToInt32(tNB.Text));
            if (chkBrds.Checked && tNB.Text != "") addNEWIDs_QRS('B', Convert.ToInt32(tNB.Text));
            if (chkGhosts.Checked && tNB.Text != "")
            {
                string stxp = "";
                X_Serial myGserial = new X_Serial("G");
                myGserial.addNEWIDs(Convert.ToInt32(tNB.Text), ref stxp);
                if (stxp.Length > 0) MessageBox.Show("ERROR adding:  " + stxp);
                // addNEWIDs_QRS('B', Convert.ToInt32(tNB.Text));
            }
			if (laff.Text != "") MessageBox.Show("New ADs were added to ID_LIST  ");
			ltime.Text = ltime.Text + "  " + DateTime.Now.ToShortTimeString();

            this.Cursor = Cursors.Default;
		}

		private void lvTools_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lvTools.SelectedItems.Count == 1)
			{
				timer1.Enabled = false;
				grpCurrU.Visible = false;

				int cc=lvTools.SelectedItems[0].Index;
				grpFree.Visible = (cc == 1);
                grpIDs.Visible = (MainMDI.User.ToLower() == "ede");
				grpConfig.Visible = (cc == 3);
                button5.Visible = (MainMDI.User.ToLower() == "ede");
                if (MainMDI.User.ToLower() == "ede")
				{
                    MainMDI.ExecSql("delete PSM_SYSETUP where s_machNm <>'PGESCOM' ");
                    MainMDI.ExecSql("delete PSM_Whodo ");
                    fill_stations();
					timer1.Enabled = true;
					grpCurrU.Visible = true;
				    //if (MainMDI.User == "Admin")
				    //{
				        //btnStop.Visible = true;
				        //btnSTOPALL.Visible = true;
				        //btnUPPGESCOM.Visible = true;
				    //}
				}
				//=(cc == 2 && MainMDI.profile == 'S');
                button7.Visible = MainMDI.User.ToLower() == "ede";
			}
		}

        private void lvTools_SelectedIndexChangedold_fashion(object sender, System.EventArgs e)
        {
            if (lvTools.SelectedItems.Count == 1)
            {
                timer1.Enabled = false;
                grpCurrU.Visible = false;

                int cc = lvTools.SelectedItems[0].Index;
                grpFree.Visible = (cc == 1);
                grpIDs.Visible = (cc == 0 && MainMDI.profile == 'S' && MainMDI.User.ToUpper() != "UNLOCK");
                grpConfig.Visible = (cc == 3);
                button5.Visible = (cc == 2 && MainMDI.profile == 'S' && MainMDI.User.ToUpper() != "UNLOCK");
                if (cc == 4 && MainMDI.profile == 'S' && MainMDI.User.ToUpper() != "UNLOCK")
                {
                    MainMDI.ExecSql("delete PSM_SYSETUP where s_machNm <>'PGESCOM' ");
                    MainMDI.ExecSql("delete PSM_Whodo ");
                    fill_stations();
                    timer1.Enabled = true;
                    grpCurrU.Visible = true;
                    //if (MainMDI.User == "Admin")
                    //{
                        //btnStop.Visible = true;
                        //btnSTOPALL.Visible = true;
                        //btnUPPGESCOM.Visible = true;
                    //}
                }
                //= (cc == 2 && MainMDI.profile == 'S');
                button7.Visible = MainMDI.User.ToLower() == "ede";
            }
        }

		private void lvTools_DoubleClickoldd(object sender, System.EventArgs e)
		{
			if (MainMDI.profile == 'S')
			{
				switch (lvTools.SelectedItems[0].Index)
				{
					case 2:
					
						Passwd frmpass = new Passwd('U');
						frmpass.ShowDialog();
						break;
				}
			}
		}

		private void BtnUsers_Click(object sender, System.EventArgs e)
		{
			Passwd frmpass = new Passwd('U');
			frmpass.ShowDialog();
		}

		private void cbUsers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			tuser.Text = cbUsers.Text;
		}

		private void button5_Click(object sender, System.EventArgs e)
		{
			Passwd frmpass = new Passwd('U');
			frmpass.ShowDialog();
			button5.Visible = false;
		}

		private void button10_Click(object sender, System.EventArgs e)
		{
			fill_stations();
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			fill_stations();
		}

		private void button11_Click(object sender, System.EventArgs e)
		{
			if (MainMDI.User == "ede")
			{
				ChargerCOST chCost = new ChargerCOST();
				this.Hide();
				chCost.ShowDialog();
				this.Visible = true;
				chCost.Dispose();
			}
		}

		private void lvstation_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			int ndx = -1;
			if (lvstation.SelectedItems.Count == 1)
			{
				ndx = lvstation.SelectedItems[0].Index;
				lUser.Text = lvstation.Items[ndx].SubItems[0].Text;
				lmach.Text = lvstation.Items[ndx].SubItems[1].Text;
				ldispUS.Text = (lUser.Text.Length > 0 && lmach.Text.Length > 0) ? lUser.Text + " / " + lmach.Text : lUser.Text + lmach.Text;
				chkSUsr.Checked = true;
                lip.Text = (lvstation.SelectedItems[0].SubItems[0].Tag.ToString().Length < 1) ? MainMDI.VIDE : lvstation.SelectedItems[0].SubItems[0].Tag.ToString();
                lport.Text = (lvstation.SelectedItems[0].SubItems[1].Tag.ToString().Length < 1) ? MainMDI.VIDE : lvstation.SelectedItems[0].SubItems[1].Tag.ToString();
			}
			else
			{
				chkALL.Checked = true;
				lUser.Text = "";
				lmach.Text = "";
			}
		}

		private void btnStop_Click(object sender, System.EventArgs e)
		{
		    //string tmchn = (chkALL.Checked) ? "ALL" : MainMDI.Mach_Name;
		    //if (lUser.Text != "" || tmchn == "ALL") //lvstation.SelectedItems.Count == 1)
		    //{
		        //tmchn = (tmchn == "ALL") ? "ALL" : lmach.Text;
		        //MainMDI.ExecSql("UPDATE PSM_SYSETUP  SET [s_stat]='0', [s_machNm]='" + tmchn + "'");
		    //} 
			if (chkSUsr.Checked)
			{
				MainMDI.ExecSql("UPDATE PSM_SYSETUP  SET [s_stat]='0' where s_machNm='" + lmach.Text + "' ");
			}
		}

		private void chkALL_CheckedChanged(object sender, System.EventArgs e)
		{
			ldispUS.Visible = !chkALL.Checked;
			btnStop.Visible = false; //ldispUS.Visible;
		}

		private void chkSUsr_CheckedChanged(object sender, System.EventArgs e)
		{
			if (lvstation.SelectedItems.Count == 0) { lUser.Text = ""; lmach.Text = ""; ldispUS.Text = ""; }
		    ldispUS.Visible = chkSUsr.Checked;
		    btnStop.Visible = ldispUS.Visible;
		    lstop.Visible = ldispUS.Visible;
		    btnow.Visible = ldispUS.Visible;
		}

		private void tuser_TextChanged(object sender, System.EventArgs e)
		{
			if (MainMDI.profile != 'S')
			{
				tuser.BringToFront();
				button4.Enabled = (tuser.Text == MainMDI.User);
				button6.Enabled = (tuser.Text == MainMDI.User || MainMDI.User.ToLower() == "unlock");
			}
			else cbUsers.BringToFront();
		}

		private void button7_Click(object sender, System.EventArgs e)
		{
			BIGFILES();
		}

		private void btnSTOPALL_Click(object sender, System.EventArgs e)
		{
			if (MainMDI.Confirm("You want to STOP PGESCOM ? ")) MainMDI.ExecSql("UPDATE PSM_SYSETUP  SET [s_stat]='8' where s_machNm='" + "PGESCOM" + "'");
			fill_stations();
		    ref_btns(true);
		}

		private void btnUPPGESCOM_Click(object sender, System.EventArgs e)
		{
		    //if (tpwd.Text == "----")
		    //{
			if (MainMDI.Confirm("You want to START PGESCOM ? "))
			{
				MainMDI.ExecSql("UPDATE PSM_SYSETUP  SET [s_stat]='1' where s_machNm='" + "PGESCOM" + "'");
				MainMDI.ExecSql("delete fROM PSM_Whodo where UserNm <>'" + MainMDI.User + "'");
			}
			fill_stations();
		    ref_btns(true);
		    //}
		}

        void reset_Status_stations()
        {
                MainMDI.ExecSql("delete fROM PSM_Whodo where UserNm <>'" + MainMDI.User + "'");
                MainMDI.ExecSql("delete PSM_SYSETUP where [s_machNm]<>'" + MainMDI.Mach_Name + "' and [s_machNm]<>'PGESCOM' ");
                fill_stations();
        }

		private void button9_Click(object sender, System.EventArgs e)
		{
            if (MainMDI.Confirm("Realy....????")) reset_Status_stations();
		}

		private void button12_Click(object sender, System.EventArgs e)
		{
			if (chkSUsr.Checked)
			{
				MainMDI.ExecSql("UPDATE PSM_SYSETUP  SET [s_stat]='9' where s_machNm='" + lmach.Text + "' ");
			}
		}

		private void ref_btns(bool _sta)
		{
            if (_sta)
            {
                btnSTOPALL.Visible = (lSrvr_stat.Text == "Running");
                btnUPPGESCOM.Visible = (lSrvr_stat.Text == "Stopped");
            }
		}

		private void tpwd_TextChanged(object sender, System.EventArgs e)
		{
			bool sta = (tpwd.Text == "2~~");
			btnbld.Visible = sta;
            ref_btns(sta);
			t_bld.ReadOnly = !sta;
		}

		private void btnbld_Click(object sender, System.EventArgs e)
		{
		    if (t_bld.Text.Length == 9) MainMDI.ExecSql("UPDATE PSM_SYSETUP  SET [BLD]='" + t_bld.Text + "'  where s_machNm='PGESCOM'");
		    else MessageBox.Show("This Build# is Invalid,    format= 'yymmdd.vv' ..");
		}

        private void btnOK_Clickbaddd(object sender, EventArgs e)
        {
            CmySoc_Station SS = null;
            if (chkALL.Checked)
            {
                foreach (ListViewItem itm in lvstation.Items)
                {
                    SS = new CmySoc_Station(itm.SubItems[0].Tag.ToString(), itm.SubItems[1].Tag.ToString(), tmsg.Text);
                }
                SS.closeAllSoc();
            }
            else
            {
                SS = new CmySoc_Station(lvstation.SelectedItems[0].SubItems[0].Tag.ToString(), lvstation.SelectedItems[0].SubItems[1].Tag.ToString(), tmsg.Text);
                SS.closeAllSoc();
            }
        }

        //TCP socket section begins here
        //it starts on any station Manager as user = ede(tools).....

        private void btnOK_Click(object sender, System.EventArgs e)
        {
            ////string tmchn lmach.Text;
            //if (lUser.Text != "" && chkSUsr.Checked) //lvstation.SelectedItems.Count == 1)
            //{
                //MainMDI.ExecSql("UPDATE PSM_SYSETUP  SET [s_msg]='" + tmsg.Text + "' where s_machNm='" + lmach.Text + "'");
                //
            //} 
            if (lvstation.SelectedItems.Count == 1)
            {
                if (mySocClient_Mgr != null && mySocClient_Mgr.Connected) sent_station(tmsg.Text);
                else Connect_To_Station(lvstation.SelectedItems[0].SubItems[0].Tag.ToString(), lvstation.SelectedItems[0].SubItems[1].Tag.ToString());
                //{
                    //foreach (ListViewItem itm in lvstation.SelectedItems)
                    //{
                        ////
                        //Connect_To_Station(itm.SubItems.Tag.ToString(), itm.SubItems[1].Tag.ToString());
                        //
                    //}
                //}
            }
            else MessageBox.Show("Please select station......");
        }

        private void Connect_To_Station(string _stIP, string _port)
        {
            try
            {
                mySocClient_Mgr = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                IPAddress _ip = IPAddress.Parse(_stIP);
                int _intport = Convert.ToInt16(_port);
                IPEndPoint myIPendP = new IPEndPoint(_ip, _intport);
                mySocClient_Mgr.Connect(myIPendP);
                sent_station(tmsg.Text);
                //if (sent_station("STOP"))
                //WaitData(mySocClient_Mgr);
            }
            catch (SocketException se)
            {
                MessageBox.Show("Connect_To_Station..." + se.Message);
                btnOK.Enabled = true;
            }
        }

        private bool sent_station(string msg)
        {
            try
            {
                Object objData = msg;
                byte[] dataByte = System.Text.Encoding.ASCII.GetBytes(objData.ToString());
                mySocClient_Mgr.Send(dataByte);
            }
            catch (SocketException se)
            {
                MessageBox.Show("sent_station..." + se.Message);
                return false;
            }
            return true;
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

        private class CSocPket
        {
            public Socket thissocket;
            public byte[] DataBuf = new byte[1];
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
                String szData = new String(chars);
                TCPreceivedTXT = szData;

                WaitData(mySocClient_Mgr);
                MessageBox.Show("Data Received= " + TCPreceivedTXT);
            }
            catch (ObjectDisposedException)
            {
                System.Diagnostics.Debugger.Log(0, "1", "\n ONConnect(): socket has been closed \n");
            }
            catch (SocketException se)
            {
                MessageBox.Show("socket exception: " + se.Message);
            }
        }

        private void btn2Mn_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvstation.Items.Count; i++)
            {
                string _lmach = lvstation.Items[i].SubItems[1].Text;
                tmsg.Text = _lmach;
                MainMDI.ExecSql("UPDATE PSM_SYSETUP  SET [s_stat]='0' where s_machNm='" + _lmach + "' ");
                lvstation.Items[i].BackColor = Color.Yellow;
            }
            reset_Status_stations();
        }

        private void btnNewGenID_Click(object sender, EventArgs e)
        {

        }

        private void btn_macAdrs_Click(object sender, EventArgs e)
        {
            addNEWIDs_MACAdrs(12);
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void btnSVpdf_Click(object sender, EventArgs e)
        {
            savePDF();
        }

        private void button12_Click_1(object sender, EventArgs e)
        {
            //folderBrowserDialog1.ShowDialog();
            openFileDialog1.ShowDialog();
            txPDFrdr.Text = openFileDialog1.FileName;
        }

        //update PGESCOM button
        //not working right now because instead of updating it brings them back to an old PGESCOM app. 
        private void btnUPGC_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This functionnality have some issues right now. Please contact Haissam if you want to update PGESCOM");
            //MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where [user]='" + MainMDI.User + "'");
            //bool tt = MainMDI.CallUPDATE();
        }

        void Update_PGC()
        {
            //if (MainMDI.CallUPDATE()) Application.Exit();
        }

        private void Addids_Click(object sender, EventArgs e)
        {
            disVisiALL();
            if (Admin())
            {
                grpIDs.Visible = true;
            }
        }

        //TCP socket section ends here

        bool Admin()
        {
            //return (MainMDI.profile == 'S' && MainMDI.User.ToUpper() != "UNLOCK");
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
        }

        private void unlock_Click(object sender, EventArgs e)
        {
            disVisiALL();
            grpFree.Visible = true;
            tuser.Focus();
        }

        private void tlsusers_Click(object sender, EventArgs e)
        {
            disVisiALL();
            if (Admin())
            {
                button5.Visible = true;
                this.Refresh();
            }
        }

        private void tlsSTAT_Click(object sender, EventArgs e)
        {
            disVisiALL();
            if (Admin())
            {
               grpCurrU.Visible = true;
            }
        }

        void disVisiALL()
        {
            grpCurrU.Visible = false;
            grpFree.Visible = false;
            grpIDs.Visible = false;
            button5.Visible = false;
            grpConfig.Visible = false;
        }

        private void tlsconf_Click(object sender, EventArgs e)
        {
            disVisiALL();
            if (Admin())
            {
                grpConfig.Visible = true;
            }
        }

        private void _exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button13_Click(object sender, EventArgs e)
        {
            //SSsend_email("PGESCOM@primax-e.com", "hedebbab@primax-e.com", "tsttttttttt from PGESCOM.....", "TSTTTTTTTTTTTTTTTTTT");
            MainMDI.send_email("PGESCOM@primax-e.com", "hedebbab@primax-e.com", "tsttttttttt from PGESCOM.....", "TSTTTTTTTTTTTTTTTTTT");
        }

        public static void SSsend_email(string FromAdrs, string TO_email, string _Subject, string _Body)
        {
            string SMTPSRVRnm = "192.168.1.31"; //"ntserver.PRIMAX.LOCAL";
            if (SMTPSRVRnm != MainMDI.VIDE && SMTPSRVRnm != "")
            {
                MailMessage mailOBJ = new MailMessage(FromAdrs, TO_email, _Subject, _Body);
                SmtpClient SMTPServer = new SmtpClient(SMTPSRVRnm); //("ntserver.PRIMAX.LOCAL");
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
	}
}