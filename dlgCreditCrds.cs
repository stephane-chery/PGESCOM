using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using EAHLibs;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for dlgCreditCrds.
	/// </summary>
	public class dlgCreditCrds : System.Windows.Forms.Form
	{

		private string in_CCnb = "", in_cpny;
		long lcpnyLID = 0;
		char Opera = 'F';
		int ndxfound = 0;
		private Lib1 Tools = new Lib1();
		public bool lOK = false;

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label12;
		public System.Windows.Forms.ComboBox cbcpny;
		public System.Windows.Forms.TextBox tKey;
		public System.Windows.Forms.TextBox lcpny;
        private System.Windows.Forms.Label label1;
		private System.Windows.Forms.PictureBox picContact;
		public System.Windows.Forms.TextBox tCHfn;
		private System.Windows.Forms.PictureBox picfind;
        private System.Windows.Forms.ComboBox cbContacts;
        private System.Windows.Forms.PictureBox pic_reset;
		private System.Windows.Forms.Button picExit;
		private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.GroupBox groupBox2;
        private ToolStrip TSmain;
        private ToolStripButton newcard;
        private ToolStripButton Save;
        private ToolStripButton del;
        private ToolStripButton exiit;
        public ListView lvCpnyCC;
        private ColumnHeader CardNB;
        private ColumnHeader CardLID;
        private GroupBox grpCC;
        private Label lCCLID;
        private Label lDatEx;
        private PictureBox picSeek_SH;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox pic_reset_SP;
        private Label label11;
        private Label label10;
        public TextBox tsecC;
        private Label label8;
        private Label label7;
        public ComboBox cbMM;
        public ComboBox cbYY;
        public ComboBox cbCCType;
        private Label label6;
        public TextBox tCCnb;
        private Label label9;
        private PictureBox btnOK;
        private PictureBox pic_resetCC;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public dlgCreditCrds(string x_CCnb, string x_cpny)
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();
			in_CCnb = x_CCnb;
			in_cpny = x_cpny;

			Opera = 'F';
			fill_cbCompany(); Opera = 'N';

			//if (in_CCnb

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgCreditCrds));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvCpnyCC = new System.Windows.Forms.ListView();
            this.CardNB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CardLID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpCC = new System.Windows.Forms.GroupBox();
            this.lCCLID = new System.Windows.Forms.Label();
            this.btnLogin = new System.Windows.Forms.Button();
            this.picExit = new System.Windows.Forms.Button();
            this.lDatEx = new System.Windows.Forms.Label();
            this.picSeek_SH = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pic_reset_SP = new System.Windows.Forms.PictureBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.tsecC = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.cbMM = new System.Windows.Forms.ComboBox();
            this.cbYY = new System.Windows.Forms.ComboBox();
            this.cbCCType = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tCCnb = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.PictureBox();
            this.pic_resetCC = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picContact = new System.Windows.Forms.PictureBox();
            this.cbcpny = new System.Windows.Forms.ComboBox();
            this.lcpny = new System.Windows.Forms.TextBox();
            this.cbContacts = new System.Windows.Forms.ComboBox();
            this.tCHfn = new System.Windows.Forms.TextBox();
            this.tKey = new System.Windows.Forms.TextBox();
            this.pic_reset = new System.Windows.Forms.PictureBox();
            this.picfind = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.newcard = new System.Windows.Forms.ToolStripButton();
            this.Save = new System.Windows.Forms.ToolStripButton();
            this.exiit = new System.Windows.Forms.ToolStripButton();
            this.del = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.grpCC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek_SH)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_reset_SP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_resetCC)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picContact)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_reset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picfind)).BeginInit();
            this.TSmain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvCpnyCC);
            this.groupBox1.Controls.Add(this.grpCC);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(12, 72);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(633, 329);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lvCpnyCC
            // 
            this.lvCpnyCC.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvCpnyCC.AutoArrange = false;
            this.lvCpnyCC.BackColor = System.Drawing.Color.OldLace;
            this.lvCpnyCC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CardNB,
            this.CardLID});
            this.lvCpnyCC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCpnyCC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCpnyCC.ForeColor = System.Drawing.Color.Black;
            this.lvCpnyCC.FullRowSelect = true;
            this.lvCpnyCC.GridLines = true;
            this.lvCpnyCC.Location = new System.Drawing.Point(3, 206);
            this.lvCpnyCC.Name = "lvCpnyCC";
            this.lvCpnyCC.Size = new System.Drawing.Size(627, 120);
            this.lvCpnyCC.TabIndex = 327;
            this.lvCpnyCC.UseCompatibleStateImageBehavior = false;
            this.lvCpnyCC.View = System.Windows.Forms.View.Details;
            this.lvCpnyCC.SelectedIndexChanged += new System.EventHandler(this.lvCpnyCC_SelectedIndexChanged);
            this.lvCpnyCC.DoubleClick += new System.EventHandler(this.lvCpnyCC_DoubleClick);
            // 
            // CardNB
            // 
            this.CardNB.Text = "Credit card #";
            this.CardNB.Width = 418;
            // 
            // CardLID
            // 
            this.CardLID.Text = "";
            this.CardLID.Width = 0;
            // 
            // grpCC
            // 
            this.grpCC.Controls.Add(this.lCCLID);
            this.grpCC.Controls.Add(this.btnLogin);
            this.grpCC.Controls.Add(this.picExit);
            this.grpCC.Controls.Add(this.lDatEx);
            this.grpCC.Controls.Add(this.picSeek_SH);
            this.grpCC.Controls.Add(this.pictureBox2);
            this.grpCC.Controls.Add(this.pictureBox1);
            this.grpCC.Controls.Add(this.pic_reset_SP);
            this.grpCC.Controls.Add(this.label11);
            this.grpCC.Controls.Add(this.label10);
            this.grpCC.Controls.Add(this.tsecC);
            this.grpCC.Controls.Add(this.label8);
            this.grpCC.Controls.Add(this.label7);
            this.grpCC.Controls.Add(this.cbMM);
            this.grpCC.Controls.Add(this.cbYY);
            this.grpCC.Controls.Add(this.cbCCType);
            this.grpCC.Controls.Add(this.label6);
            this.grpCC.Controls.Add(this.tCCnb);
            this.grpCC.Controls.Add(this.label9);
            this.grpCC.Controls.Add(this.btnOK);
            this.grpCC.Controls.Add(this.pic_resetCC);
            this.grpCC.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpCC.ForeColor = System.Drawing.Color.Blue;
            this.grpCC.Location = new System.Drawing.Point(3, 95);
            this.grpCC.Name = "grpCC";
            this.grpCC.Size = new System.Drawing.Size(627, 111);
            this.grpCC.TabIndex = 326;
            this.grpCC.TabStop = false;
            this.grpCC.Text = "Credit Card Information";
            // 
            // lCCLID
            // 
            this.lCCLID.BackColor = System.Drawing.Color.Tomato;
            this.lCCLID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lCCLID.Location = new System.Drawing.Point(8, 16);
            this.lCCLID.Name = "lCCLID";
            this.lCCLID.Size = new System.Drawing.Size(16, 16);
            this.lCCLID.TabIndex = 328;
            this.lCCLID.Visible = false;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLogin.Location = new System.Drawing.Point(485, 13);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(88, 24);
            this.btnLogin.TabIndex = 277;
            this.btnLogin.Text = "&OK";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Visible = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.SystemColors.Control;
            this.picExit.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.picExit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.picExit.Location = new System.Drawing.Point(490, 50);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(88, 24);
            this.picExit.TabIndex = 278;
            this.picExit.Text = "&Cancel";
            this.picExit.UseVisualStyleBackColor = false;
            this.picExit.Visible = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // lDatEx
            // 
            this.lDatEx.BackColor = System.Drawing.Color.Tomato;
            this.lDatEx.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lDatEx.Location = new System.Drawing.Point(232, 56);
            this.lDatEx.Name = "lDatEx";
            this.lDatEx.Size = new System.Drawing.Size(16, 16);
            this.lDatEx.TabIndex = 326;
            this.lDatEx.Visible = false;
            // 
            // picSeek_SH
            // 
            this.picSeek_SH.BackColor = System.Drawing.Color.Transparent;
            this.picSeek_SH.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSeek_SH.Image = ((System.Drawing.Image)(resources.GetObject("picSeek_SH.Image")));
            this.picSeek_SH.Location = new System.Drawing.Point(400, 24);
            this.picSeek_SH.Name = "picSeek_SH";
            this.picSeek_SH.Size = new System.Drawing.Size(40, 32);
            this.picSeek_SH.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSeek_SH.TabIndex = 311;
            this.picSeek_SH.TabStop = false;
            this.picSeek_SH.Click += new System.EventHandler(this.picSeek_SH_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(368, 16);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 16);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 310;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(328, 16);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(32, 16);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 309;
            this.pictureBox1.TabStop = false;
            // 
            // pic_reset_SP
            // 
            this.pic_reset_SP.BackColor = System.Drawing.Color.Transparent;
            this.pic_reset_SP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_reset_SP.Image = ((System.Drawing.Image)(resources.GetObject("pic_reset_SP.Image")));
            this.pic_reset_SP.Location = new System.Drawing.Point(288, 16);
            this.pic_reset_SP.Name = "pic_reset_SP";
            this.pic_reset_SP.Size = new System.Drawing.Size(32, 16);
            this.pic_reset_SP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_reset_SP.TabIndex = 308;
            this.pic_reset_SP.TabStop = false;
            // 
            // label11
            // 
            this.label11.ForeColor = System.Drawing.Color.MediumBlue;
            this.label11.Location = new System.Drawing.Point(176, 80);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(104, 16);
            this.label11.TabIndex = 280;
            this.label11.Text = "3- or 4-digit number";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(32, 80);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(88, 16);
            this.label10.TabIndex = 279;
            this.label10.Text = "Security Code:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsecC
            // 
            this.tsecC.BackColor = System.Drawing.Color.Lavender;
            this.tsecC.Location = new System.Drawing.Point(120, 80);
            this.tsecC.MaxLength = 4;
            this.tsecC.Name = "tsecC";
            this.tsecC.Size = new System.Drawing.Size(56, 20);
            this.tsecC.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(8, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(112, 16);
            this.label8.TabIndex = 277;
            this.label8.Text = "Expiry Date:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(168, 59);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(8, 16);
            this.label7.TabIndex = 276;
            this.label7.Text = "/";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cbMM
            // 
            this.cbMM.BackColor = System.Drawing.Color.Lavender;
            this.cbMM.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbMM.Items.AddRange(new object[] {
            "MM",
            "01",
            "02",
            "03",
            "04",
            "05",
            "06",
            "07",
            "08",
            "09",
            "10",
            "11",
            "12"});
            this.cbMM.Location = new System.Drawing.Point(120, 57);
            this.cbMM.Name = "cbMM";
            this.cbMM.Size = new System.Drawing.Size(48, 21);
            this.cbMM.TabIndex = 2;
            this.cbMM.SelectedIndexChanged += new System.EventHandler(this.cbMM_SelectedIndexChanged);
            // 
            // cbYY
            // 
            this.cbYY.BackColor = System.Drawing.Color.Lavender;
            this.cbYY.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbYY.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbYY.Items.AddRange(new object[] {
            "YYYY",
            "2007",
            "2008",
            "2009",
            "2010",
            "2011",
            "2012",
            "2013",
            "2014",
            "2015",
            "2016",
            "2017",
            "2018",
            "2019",
            "2020",
            "2021",
            "2022",
            "2023",
            "2024",
            "2025",
            "2026",
            "2027",
            "2028",
            "2029",
            "2030"});
            this.cbYY.Location = new System.Drawing.Point(176, 57);
            this.cbYY.Name = "cbYY";
            this.cbYY.Size = new System.Drawing.Size(56, 21);
            this.cbYY.TabIndex = 3;
            this.cbYY.SelectedIndexChanged += new System.EventHandler(this.cbYY_SelectedIndexChanged);
            // 
            // cbCCType
            // 
            this.cbCCType.BackColor = System.Drawing.Color.Lavender;
            this.cbCCType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCCType.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCCType.Items.AddRange(new object[] {
            "Please choose",
            "Visa",
            "MasterCard",
            "American Express"});
            this.cbCCType.Location = new System.Drawing.Point(120, 16);
            this.cbCCType.Name = "cbCCType";
            this.cbCCType.Size = new System.Drawing.Size(168, 21);
            this.cbCCType.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(48, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 272;
            this.label6.Text = "Credit Card:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tCCnb
            // 
            this.tCCnb.BackColor = System.Drawing.Color.Lavender;
            this.tCCnb.Location = new System.Drawing.Point(120, 37);
            this.tCCnb.Name = "tCCnb";
            this.tCCnb.Size = new System.Drawing.Size(280, 20);
            this.tCCnb.TabIndex = 1;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(8, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(112, 20);
            this.label9.TabIndex = 260;
            this.label9.Text = "Credit Card Number:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Transparent;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.Location = new System.Drawing.Point(312, 64);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(56, 48);
            this.btnOK.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnOK.TabIndex = 275;
            this.btnOK.TabStop = false;
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // pic_resetCC
            // 
            this.pic_resetCC.BackColor = System.Drawing.Color.Transparent;
            this.pic_resetCC.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_resetCC.Image = ((System.Drawing.Image)(resources.GetObject("pic_resetCC.Image")));
            this.pic_resetCC.Location = new System.Drawing.Point(384, 68);
            this.pic_resetCC.Name = "pic_resetCC";
            this.pic_resetCC.Size = new System.Drawing.Size(56, 40);
            this.pic_resetCC.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_resetCC.TabIndex = 327;
            this.pic_resetCC.TabStop = false;
            this.pic_resetCC.Visible = false;
            this.pic_resetCC.Click += new System.EventHandler(this.pic_resetCC_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picContact);
            this.groupBox2.Controls.Add(this.cbcpny);
            this.groupBox2.Controls.Add(this.lcpny);
            this.groupBox2.Controls.Add(this.cbContacts);
            this.groupBox2.Controls.Add(this.tCHfn);
            this.groupBox2.Controls.Add(this.tKey);
            this.groupBox2.Controls.Add(this.pic_reset);
            this.groupBox2.Controls.Add(this.picfind);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(627, 79);
            this.groupBox2.TabIndex = 279;
            this.groupBox2.TabStop = false;
            // 
            // picContact
            // 
            this.picContact.BackColor = System.Drawing.Color.Transparent;
            this.picContact.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picContact.Image = ((System.Drawing.Image)(resources.GetObject("picContact.Image")));
            this.picContact.Location = new System.Drawing.Point(359, 39);
            this.picContact.Name = "picContact";
            this.picContact.Size = new System.Drawing.Size(32, 32);
            this.picContact.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picContact.TabIndex = 289;
            this.picContact.TabStop = false;
            this.picContact.Click += new System.EventHandler(this.picContact_Click);
            // 
            // cbcpny
            // 
            this.cbcpny.BackColor = System.Drawing.Color.Lavender;
            this.cbcpny.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbcpny.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbcpny.Location = new System.Drawing.Point(87, 18);
            this.cbcpny.Name = "cbcpny";
            this.cbcpny.Size = new System.Drawing.Size(272, 21);
            this.cbcpny.TabIndex = 92;
            this.cbcpny.Visible = false;
            this.cbcpny.SelectedIndexChanged += new System.EventHandler(this.cbcpny_SelectedIndexChanged);
            // 
            // lcpny
            // 
            this.lcpny.BackColor = System.Drawing.Color.AliceBlue;
            this.lcpny.Location = new System.Drawing.Point(87, 18);
            this.lcpny.Name = "lcpny";
            this.lcpny.Size = new System.Drawing.Size(272, 20);
            this.lcpny.TabIndex = 5;
            this.lcpny.WordWrap = false;
            // 
            // cbContacts
            // 
            this.cbContacts.BackColor = System.Drawing.Color.Lavender;
            this.cbContacts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbContacts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbContacts.Location = new System.Drawing.Point(87, 39);
            this.cbContacts.Name = "cbContacts";
            this.cbContacts.Size = new System.Drawing.Size(272, 21);
            this.cbContacts.TabIndex = 323;
            this.cbContacts.Visible = false;
            this.cbContacts.SelectedIndexChanged += new System.EventHandler(this.cbContacts_SelectedIndexChanged);
            // 
            // tCHfn
            // 
            this.tCHfn.BackColor = System.Drawing.Color.Lavender;
            this.tCHfn.Location = new System.Drawing.Point(87, 39);
            this.tCHfn.Name = "tCHfn";
            this.tCHfn.Size = new System.Drawing.Size(272, 20);
            this.tCHfn.TabIndex = 6;
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.DarkSalmon;
            this.tKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.ForeColor = System.Drawing.Color.Black;
            this.tKey.Location = new System.Drawing.Point(400, 18);
            this.tKey.MaxLength = 60;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(208, 20);
            this.tKey.TabIndex = 172;
            this.tKey.Visible = false;
            // 
            // pic_reset
            // 
            this.pic_reset.BackColor = System.Drawing.Color.Transparent;
            this.pic_reset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_reset.Image = ((System.Drawing.Image)(resources.GetObject("pic_reset.Image")));
            this.pic_reset.Location = new System.Drawing.Point(490, 47);
            this.pic_reset.Name = "pic_reset";
            this.pic_reset.Size = new System.Drawing.Size(32, 24);
            this.pic_reset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_reset.TabIndex = 324;
            this.pic_reset.TabStop = false;
            this.pic_reset.Visible = false;
            this.pic_reset.Click += new System.EventHandler(this.pic_reset_Click);
            // 
            // picfind
            // 
            this.picfind.BackColor = System.Drawing.Color.Transparent;
            this.picfind.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picfind.Image = ((System.Drawing.Image)(resources.GetObject("picfind.Image")));
            this.picfind.Location = new System.Drawing.Point(359, 6);
            this.picfind.Name = "picfind";
            this.picfind.Size = new System.Drawing.Size(42, 30);
            this.picfind.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picfind.TabIndex = 173;
            this.picfind.TabStop = false;
            this.picfind.Click += new System.EventHandler(this.picfind_Click);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(15, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 322;
            this.label1.Text = "Company:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(6, 39);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(80, 20);
            this.label12.TabIndex = 286;
            this.label12.Text = "Holder Name:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TSmain
            // 
            this.TSmain.AutoSize = false;
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newcard,
            this.Save,
            this.exiit});
            this.TSmain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.TSmain.Location = new System.Drawing.Point(0, 0);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(652, 63);
            this.TSmain.TabIndex = 327;
            // 
            // newcard
            // 
            this.newcard.Image = ((System.Drawing.Image)(resources.GetObject("newcard.Image")));
            this.newcard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newcard.Name = "newcard";
            this.newcard.Size = new System.Drawing.Size(63, 60);
            this.newcard.Text = "New Card";
            this.newcard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.newcard.Click += new System.EventHandler(this.pic_resetCC_Click);
            // 
            // Save
            // 
            this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
            this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(36, 60);
            this.Save.Text = "Save";
            this.Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Save.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // exiit
            // 
            this.exiit.Image = ((System.Drawing.Image)(resources.GetObject("exiit.Image")));
            this.exiit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exiit.Name = "exiit";
            this.exiit.Size = new System.Drawing.Size(59, 60);
            this.exiit.Text = "     Exit     ";
            this.exiit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exiit.ToolTipText = "Exit";
            this.exiit.Click += new System.EventHandler(this.exiit_Click);
            // 
            // del
            // 
            this.del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(87, 60);
            this.del.Text = "Delete Payment";
            this.del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.del.Visible = false;
            // 
            // dlgCreditCrds
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(652, 406);
            this.Controls.Add(this.TSmain);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgCreditCrds";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Credit Card Info";
            this.Load += new System.EventHandler(this.dlgCreditCrds_Load);
            this.groupBox1.ResumeLayout(false);
            this.grpCC.ResumeLayout(false);
            this.grpCC.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek_SH)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_reset_SP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnOK)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_resetCC)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picContact)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_reset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picfind)).EndInit();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private bool fields_ok()
		{
			return (cbCCType.Text != "Please choose" && tCCnb.Text.Length > 5 && lDatEx.Text != "MMYYYY" && lcpny.Text != "" && tCHfn.Text != "");
		}

		private void fill_cbCompany()
		{
			string stSql = "select Cpny_Name1 FROM PSM_Company order by Cpny_Name1";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read()) cbcpny.Items.Add(Oreadr["Cpny_Name1"].ToString());
			OConn.Close();
		}

		private void fill_lvCC(long _cpnyLID)
		{
			string stSql = "SELECT  CCLID, CCNO FROM  PSM_CmpnyCCINFO wHERE  CpnyLID =" + _cpnyLID;
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			lvCpnyCC.Items.Clear();
			while (Oreadr.Read())
			{
				ListViewItem lv = lvCpnyCC.Items.Add(Oreadr["CCNO"].ToString());
				lv.SubItems.Add(Oreadr["CCLID"].ToString());
			}
			OConn.Close();
		}

		private void fill_cb_Contacts(long cpnyID)
		{
			//string stSql = "select * FROM PSM_Contacts  where  Company_ID=" + cpnyID + "";
			string stSql = "select First_Name, Last_Name FROM PSM_Contacts  where  Company_ID=" + cpnyID + "  Order by First_Name";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			cbContacts.Items.Clear();
			while (Oreadr.Read()) cbContacts.Items.Add(Oreadr["First_Name"].ToString() + " " + Oreadr["Last_Name"].ToString());
			if (cbContacts.Items.Count > 0) cbContacts.Text = cbContacts.Items[0].ToString();
			OConn.Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (fields_ok())
			{ 
				if (lCCLID.Text == "")
				{
					if (MainMDI.Find_One_Field("Select CCLID from PSM_CmpnyCCINFO where CCNO='" + tCCnb.Text + "' and CCtype='" + cbCCType.Text[0] + "'") == MainMDI.VIDE)
					{
						try
						{
							string stSql = "INSERT INTO PSM_CmpnyCCINFO ([CCtype],[CCNO], " + 
								" [ExprDat],[Sec_cod],[CH_Name],[CpnyLID]) VALUES ('" +
								cbCCType.Text[0] + "', '" + tCCnb.Text + "', '" + lDatEx.Text + "', '" +
								tsecC.Text + "', '" + tCHfn.Text.Replace("'", "''") + "', " + lcpnyLID + ")";
							MainMDI.ExecSql(stSql);
							MainMDI.Write_JFS(stSql);
							fill_CC(tCCnb.Text);
							lOK = true;
						}
						catch (SqlException Oexp)
						{
							MessageBox.Show("Adding Company INFO Error...= " + Oexp.Message);
						}
					}
					else MessageBox.Show("This Credit Card already Exists ...");
				}
				else 
				{	
					try
					{
						string stSql = "UPDATE PSM_CmpnyCCINFO SET " +
							" [CCtype]='" + cbCCType.Text[0] + "', " +
							" [CCNO]='" + tCCnb.Text + "', " +
							" [ExprDat]='" + lDatEx.Text + "', " +
							" [Sec_cod]='" + tsecC.Text + "', " +
							" [CH_Name]='" + tCHfn.Text.Replace("'", "''") + "', " +
							" [CpnyLID]=" + lcpnyLID+
							" WHERE [CCLID]=" + lCCLID.Text;
						MainMDI.ExecSql(stSql);
						MainMDI.Write_JFS(stSql);
						btnOK.Text = "Save";
					}
					catch (SqlException Oexp)
					{
						MessageBox.Show("Updating Credit Card Info Error...= " + Oexp.Message);
					}
				}
				fill_lvCC(lcpnyLID);
			}
			else MessageBox.Show("You missed some data.....");
		}

		private void cbMM_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lDatEx.Text = cbMM.Text + cbYY.Text;
		}

		private void cbYY_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lDatEx.Text = cbMM.Text + cbYY.Text;
		}

		private void updat_cpny()
		{
			lcpny.Text = cbcpny.Text;
			string res = MainMDI.Find_One_Field("SELECT Cpny_ID FROM PSM_Company where  Cpny_Name1='" + cbcpny.Text.Replace("'", "''") + "'");
			lcpnyLID = (res == MainMDI.VIDE) ? 0 : Int32.Parse(res);
			fill_cb_Contacts(lcpnyLID);
			fill_lvCC(lcpnyLID);
		}

		private void cbcpny_SelectedIndexChanged(object sender, System.EventArgs e)
		{
	       if (Opera != 'F') updat_cpny();
		}

		private void Seek_Cmpny()
		{
			//int ndxfound = 0;
			bool FOUND = false;
			if (ndxfound > cbcpny.Items.Count) ndxfound = 0;
			for (int i = ndxfound; i < cbcpny.Items.Count; i++)
			{
				if (cbcpny.Items[i].ToString().ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1)
				{
					cbcpny.SelectedIndex = i;
					ndxfound = i + 1;
					i = cbcpny.Items.Count;
					updat_cpny(); //cbOptGrp_SelectedValueChanged(sender, e);
					//if (ndxfound < cbOptGrp.Items.Count) button1.Text = "Next";
					FOUND = true;
				}
			}
			if (!FOUND)
			{
				ndxfound = 0;
				MessageBox.Show("KeyWord not Found !!!!");
			}
		}

		private void picfind_Click(object sender, System.EventArgs e)
		{
			if (lcpny.Visible)
			{
				lcpny.Visible = false;
				cbcpny.Visible = true;
				tKey.Visible = true;
			}
			else
				if (tKey.Text.Length > 2) Seek_Cmpny();
			else 
			{
				lcpny.Visible = true;
				cbcpny.Visible = false;
				tKey.Visible = false;
			}
		}

		private void picExit_Click(object sender, System.EventArgs e)
		{
			lOK = false;
			this.Hide();
		}

		private void picContact_Click(object sender, System.EventArgs e)
		{
			cbContacts.Visible = !cbContacts.Visible;
			tCHfn.Visible = !cbContacts.Visible;
		}

		private void cbContacts_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			tCHfn.Text = cbContacts.Text;
		}

		private void pic_reset_Click(object sender, System.EventArgs e)
		{
			cbContacts.Visible = false;
			tCHfn.Visible = true;
			lcpny.Visible = true;
			cbcpny.Visible = false;
			tKey.Visible = false;
		}

		private void pic_resetCC_Click(object sender, System.EventArgs e)
		{
			cbCCType.Text = cbCCType.Items[0].ToString();
			tCCnb.Clear();
			cbMM.Text = "MM"; cbYY.Text = "YYYY";
			tsecC.Clear();
			cbcpny.Text = "g";
			lOK = false;
			lCCLID.Text = "";
		}

		private void dlgCreditCrds_Load(object sender, System.EventArgs e)
		{
			//pic_resetCC_Click(sender, e);
			cbcpny.Text = in_cpny;
			if (in_CCnb != "") fill_CC(in_CCnb);
		}

		string CCtype(char cc)
		{
			string st = "??????????";
			switch (cc)
			{
				case 'M':
					st = "MasterCard";
					break;
				case 'V':
					st = "Visa";
					break;
				case 'A':
					st = "American Express";
					break;
			}
			return st;
		}

		private void fill_CC(string CCnb)
		{
			string[] arr_Val = new string[8]{ "", "", "", "", "", "", "", "" };
            string stSql = " SELECT     PSM_COMPANY.Cpny_Name1, PSM_CmpnyCCINFO.CCtype, PSM_CmpnyCCINFO.CCNO, PSM_CmpnyCCINFO.ExprDat, PSM_CmpnyCCINFO.Sec_cod, PSM_CmpnyCCINFO.CH_Name, PSM_CmpnyCCINFO.CCLID " +
                " FROM   PSM_CmpnyCCINFO INNER JOIN PSM_COMPANY ON PSM_CmpnyCCINFO.CpnyLID = PSM_COMPANY.Cpny_ID " +
                " WHERE     (PSM_CmpnyCCINFO.CCNO ='" + CCnb + "') ";
			if (MainMDI.Find_arr_Fields(stSql, arr_Val) != MainMDI.VIDE)
            {
				lcpny.Text = arr_Val[0];
				cbCCType.Text = CCtype(arr_Val[1][0]);
				cbMM.Text = arr_Val[3].Substring(0, 2);
			    cbYY.Text = arr_Val[3].Substring(2, 4);
				tCCnb.Text = CCnb;
				tsecC.Text = arr_Val[4];
				tCHfn.Text = arr_Val[5];
				lCCLID.Text = arr_Val[6];
				lOK = true;
			}
			else
			{
				MessageBox.Show("Card number NOT FOUND ...");
				lOK = false;
				//tCCnb.Text = "?????????????????????";
			}
		}

		private void picSeek_SH_Click(object sender, System.EventArgs e)
		{
			fill_CC(tCCnb.Text);
		}

		private void tCCnb_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyInt(e.KeyChar);
		}

		private void tCCnb_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tsecC_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyInt(e.KeyChar);
		}

		private void btnLogin_Click(object sender, System.EventArgs e)
		{
			if (in_cpny != lcpny.Text) MessageBox.Show("current Company Name must be same as Project Company Name....!!!!");
			else this.Hide();
		}

		private void grpCC_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void lvCpnyCC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lvCpnyCC_DoubleClick(object sender, System.EventArgs e)
		{
		  	if (lvCpnyCC.SelectedItems.Count == 1) fill_CC(lvCpnyCC.SelectedItems[0].SubItems[0].Text);
		}

        private void exiit_Click(object sender, EventArgs e)
        {
            if (in_cpny != lcpny.Text) MessageBox.Show("current Company Name must be same as Project Company Name....!!!!");
            else this.Hide();
        }
	}
}