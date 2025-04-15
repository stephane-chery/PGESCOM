using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb ;
using System.Data.SqlClient ;
using EAHLibs;
namespace PGESCOM
{
	/// <summary>
	/// Summary description for Company.
	/// </summary>
	public class Company : System.Windows.Forms.Form
	{
        private string In_CompanyName, in_cpnySPcode;
	//	private string MainMDI.M_stCon ;
		private char In_Opera;

          private Lib1 Tools =new Lib1();

		//	private string[][] ar_Terms ; 
		
		

		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.ComboBox cbActivity;
		private System.Windows.Forms.TextBox tWeb;
		public System.Windows.Forms.TextBox tEmail;
		private System.Windows.Forms.TextBox tFax;
		public System.Windows.Forms.TextBox tTel1;
		private System.Windows.Forms.Button btnAdrs;
		private System.Windows.Forms.Button btnAS;
		private System.Windows.Forms.Button btnAP;
		private System.Windows.Forms.Button btnAQ;
		private System.Windows.Forms.Button btnAI;
		private System.Windows.Forms.LinkLabel lnkCtype;
		private System.Windows.Forms.Label lCtype;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label label23;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.ComboBox cbMainCmpny;
		private System.Windows.Forms.TextBox tCompanyName2;
		public System.Windows.Forms.TextBox tCompanyName1;
		private System.Windows.Forms.TextBox tToll;
		private System.Windows.Forms.TextBox tTel2;
		private System.Windows.Forms.TextBox tCreditLim;
		private System.Windows.Forms.ComboBox cbCurr;
		private System.Windows.Forms.ComboBox cbTerms;
		private System.Windows.Forms.ComboBox cbIncoTerm;
		private System.Windows.Forms.ComboBox cbShipVia;
        private System.Windows.Forms.LinkLabel linkLabel3;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		public System.Windows.Forms.Label lPA;
		public System.Windows.Forms.Label lSA;
		public System.Windows.Forms.Label lQA;
		public System.Windows.Forms.Label lIA;
		public System.Windows.Forms.Label lMainCmpny;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox groupBox8;
		private System.Windows.Forms.CheckBox chkSupp;
		private System.Windows.Forms.CheckBox chkCust;
		private System.Windows.Forms.Label tCompanyID;
		private System.Windows.Forms.CheckBox chkManufac;
		public System.Windows.Forms.TextBox lMainAdrs;
		private System.Windows.Forms.Label lMainCpnyID;
		private System.Windows.Forms.Label lcustmTp;
		private System.Windows.Forms.Label lTermsId;
		private System.Windows.Forms.Label lViaId;
		private System.Windows.Forms.Label lInTermId;
		private System.Windows.Forms.Label lActId;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.ListView lvContact;
		private System.Windows.Forms.ColumnHeader Namee;
		private System.Windows.Forms.ColumnHeader Tel;
		private System.Windows.Forms.ColumnHeader email;
		private System.Windows.Forms.ColumnHeader LID;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.ColumnHeader newad;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.TabPage Ginfo;
		private System.Windows.Forms.TabPage Det;
		private System.Windows.Forms.TabPage cmnts;
		private System.Windows.Forms.GroupBox groupBox6;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.PictureBox btnComnt;
		private System.Windows.Forms.TextBox tComnt;
		private System.Windows.Forms.ListView lvComment;
		private System.Windows.Forms.ColumnHeader dd;
		private System.Windows.Forms.ColumnHeader usr;
		private System.Windows.Forms.ColumnHeader cmnt;
		private System.Windows.Forms.ColumnHeader cLID;
        public System.Windows.Forms.Label lupdate;
		private System.Windows.Forms.ListBox lbxCtypeol;
		private System.Windows.Forms.ComboBox lbxCtype;
		private System.Windows.Forms.PictureBox picVcon;
        private GroupBox grpCF;
        public TextBox tNCF_val;
        private Label label24;
        private Label label21;
        private Button btn_tNCF_save;
        private Button btn_tNCF_cancel;
        private Label lNCF_Name;
        private Button btneditCF;
        private Label lctypeID;
        private Label TbxCtype;
        private Label label26;
        private GroupBox groupBox10;
        private Label label30;
        private Label EurMlt;
        private Label label28;
        private Label USMlt;
        private Label label27;
        private Label canMlt;
        private ToolStrip TSmain;
        private ToolStripButton Newcontact;
        private ToolStripButton del_BRD;
        private ToolStripButton Sav_;
        private ToolStripButton exiit;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private GroupBox groupBox11;
        private GroupBox groupBox12;
        private Label label25;
        public PictureBox picCIP;
        private Label ldone;
        private TextBox txBL;
        private CheckBox chkLN;
        private PictureBox pictureBox5;
        private PictureBox pictureBox6;
        public TextBox txLID;
        private TextBox Q_sysPcod;
		private System.ComponentModel.IContainer components;

		public Company(string st,char X_opera,string x_cpnySPcode)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			In_CompanyName =st; 
			MainMDI.M_stCon = MainMDI.M_stCon;
			In_Opera = X_opera;
            in_cpnySPcode = x_cpnySPcode;
			
			if (In_Opera=='N') 
			{
				btnOK.Text ="&Save";
			}
			else btnOK.Text ="&OK";
			Fill_frmCompany ();
			fill_Cmnt();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Company));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.Ginfo = new System.Windows.Forms.TabPage();
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.picVcon = new System.Windows.Forms.PictureBox();
            this.lvContact = new System.Windows.Forms.ListView();
            this.Namee = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.newad = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.Q_sysPcod = new System.Windows.Forms.TextBox();
            this.txLID = new System.Windows.Forms.TextBox();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.ldone = new System.Windows.Forms.Label();
            this.txBL = new System.Windows.Forms.TextBox();
            this.chkLN = new System.Windows.Forms.CheckBox();
            this.grpCF = new System.Windows.Forms.GroupBox();
            this.lctypeID = new System.Windows.Forms.Label();
            this.lNCF_Name = new System.Windows.Forms.Label();
            this.btneditCF = new System.Windows.Forms.Button();
            this.btn_tNCF_save = new System.Windows.Forms.Button();
            this.btn_tNCF_cancel = new System.Windows.Forms.Button();
            this.label24 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.tNCF_val = new System.Windows.Forms.TextBox();
            this.lnkCtype = new System.Windows.Forms.LinkLabel();
            this.label25 = new System.Windows.Forms.Label();
            this.lbxCtype = new System.Windows.Forms.ComboBox();
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.label30 = new System.Windows.Forms.Label();
            this.EurMlt = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.USMlt = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.canMlt = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.TbxCtype = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.lActId = new System.Windows.Forms.Label();
            this.lMainAdrs = new System.Windows.Forms.TextBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.chkSupp = new System.Windows.Forms.CheckBox();
            this.chkManufac = new System.Windows.Forms.CheckBox();
            this.chkCust = new System.Windows.Forms.CheckBox();
            this.label1 = new System.Windows.Forms.Label();
            this.linkLabel3 = new System.Windows.Forms.LinkLabel();
            this.lbxCtypeol = new System.Windows.Forms.ListBox();
            this.btnAdrs = new System.Windows.Forms.Button();
            this.cbActivity = new System.Windows.Forms.ComboBox();
            this.label22 = new System.Windows.Forms.Label();
            this.tWeb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tEmail = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tFax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tTel1 = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tCompanyName2 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tCompanyName1 = new System.Windows.Forms.TextBox();
            this.lcustmTp = new System.Windows.Forms.Label();
            this.cbMainCmpny = new System.Windows.Forms.ComboBox();
            this.lMainCmpny = new System.Windows.Forms.Label();
            this.lCtype = new System.Windows.Forms.Label();
            this.Det = new System.Windows.Forms.TabPage();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lInTermId = new System.Windows.Forms.Label();
            this.lViaId = new System.Windows.Forms.Label();
            this.cbIncoTerm = new System.Windows.Forms.ComboBox();
            this.label23 = new System.Windows.Forms.Label();
            this.cbShipVia = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.tToll = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tTel2 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lTermsId = new System.Windows.Forms.Label();
            this.tCreditLim = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cbCurr = new System.Windows.Forms.ComboBox();
            this.label15 = new System.Windows.Forms.Label();
            this.cbTerms = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.lIA = new System.Windows.Forms.Label();
            this.lQA = new System.Windows.Forms.Label();
            this.lSA = new System.Windows.Forms.Label();
            this.lPA = new System.Windows.Forms.Label();
            this.btnAI = new System.Windows.Forms.Button();
            this.btnAQ = new System.Windows.Forms.Button();
            this.btnAP = new System.Windows.Forms.Button();
            this.btnAS = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.cmnts = new System.Windows.Forms.TabPage();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.lvComment = new System.Windows.Forms.ListView();
            this.dd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cLID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label12 = new System.Windows.Forms.Label();
            this.btnComnt = new System.Windows.Forms.PictureBox();
            this.tComnt = new System.Windows.Forms.TextBox();
            this.tCompanyID = new System.Windows.Forms.Label();
            this.lMainCpnyID = new System.Windows.Forms.Label();
            this.lupdate = new System.Windows.Forms.Label();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.Sav_ = new System.Windows.Forms.ToolStripButton();
            this.Newcontact = new System.Windows.Forms.ToolStripButton();
            this.del_BRD = new System.Windows.Forms.ToolStripButton();
            this.exiit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.groupBox11 = new System.Windows.Forms.GroupBox();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.tabControl1.SuspendLayout();
            this.Ginfo.SuspendLayout();
            this.groupBox7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picVcon)).BeginInit();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            this.grpCF.SuspendLayout();
            this.groupBox12.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox10.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.Det.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.cmnts.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnComnt)).BeginInit();
            this.TSmain.SuspendLayout();
            this.groupBox11.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.Ginfo);
            this.tabControl1.Controls.Add(this.Det);
            this.tabControl1.Controls.Add(this.cmnts);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(3, 16);
            this.tabControl1.Multiline = true;
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1068, 401);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // Ginfo
            // 
            this.Ginfo.Controls.Add(this.groupBox7);
            this.Ginfo.Controls.Add(this.groupBox3);
            this.Ginfo.Location = new System.Drawing.Point(4, 22);
            this.Ginfo.Name = "Ginfo";
            this.Ginfo.Size = new System.Drawing.Size(1060, 375);
            this.Ginfo.TabIndex = 0;
            this.Ginfo.Text = "General Info";
            this.Ginfo.Click += new System.EventHandler(this.tabPage1_Click);
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.picVcon);
            this.groupBox7.Controls.Add(this.lvContact);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox7.Location = new System.Drawing.Point(0, 223);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1060, 152);
            this.groupBox7.TabIndex = 47;
            this.groupBox7.TabStop = false;
            this.groupBox7.Text = "Contacts:";
            // 
            // picVcon
            // 
            this.picVcon.BackColor = System.Drawing.Color.Transparent;
            this.picVcon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picVcon.Image = ((System.Drawing.Image)(resources.GetObject("picVcon.Image")));
            this.picVcon.Location = new System.Drawing.Point(144, 8);
            this.picVcon.Name = "picVcon";
            this.picVcon.Size = new System.Drawing.Size(40, 24);
            this.picVcon.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picVcon.TabIndex = 84;
            this.picVcon.TabStop = false;
            this.picVcon.Visible = false;
            this.picVcon.WaitOnLoad = true;
            this.picVcon.Click += new System.EventHandler(this.picVcon_Click);
            // 
            // lvContact
            // 
            this.lvContact.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvContact.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Namee,
            this.Tel,
            this.email,
            this.LID,
            this.newad});
            this.lvContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvContact.GridLines = true;
            this.lvContact.Location = new System.Drawing.Point(3, 16);
            this.lvContact.Name = "lvContact";
            this.lvContact.Size = new System.Drawing.Size(1054, 133);
            this.lvContact.TabIndex = 1;
            this.lvContact.UseCompatibleStateImageBehavior = false;
            this.lvContact.View = System.Windows.Forms.View.Details;
            this.lvContact.RightToLeftLayoutChanged += new System.EventHandler(this.lvContact_RightToLeftLayoutChanged);
            // 
            // Namee
            // 
            this.Namee.Text = "Contact Name";
            this.Namee.Width = 281;
            // 
            // Tel
            // 
            this.Tel.Text = "Phone";
            this.Tel.Width = 149;
            // 
            // email
            // 
            this.email.Text = "E-mail";
            this.email.Width = 169;
            // 
            // LID
            // 
            this.LID.Text = "";
            this.LID.Width = 0;
            // 
            // newad
            // 
            this.newad.Text = "";
            this.newad.Width = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.Q_sysPcod);
            this.groupBox3.Controls.Add(this.txLID);
            this.groupBox3.Controls.Add(this.pictureBox5);
            this.groupBox3.Controls.Add(this.pictureBox6);
            this.groupBox3.Controls.Add(this.ldone);
            this.groupBox3.Controls.Add(this.txBL);
            this.groupBox3.Controls.Add(this.chkLN);
            this.groupBox3.Controls.Add(this.grpCF);
            this.groupBox3.Controls.Add(this.label25);
            this.groupBox3.Controls.Add(this.lbxCtype);
            this.groupBox3.Controls.Add(this.groupBox12);
            this.groupBox3.Controls.Add(this.groupBox10);
            this.groupBox3.Controls.Add(this.label26);
            this.groupBox3.Controls.Add(this.TbxCtype);
            this.groupBox3.Controls.Add(this.label20);
            this.groupBox3.Controls.Add(this.lActId);
            this.groupBox3.Controls.Add(this.lMainAdrs);
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.linkLabel3);
            this.groupBox3.Controls.Add(this.lbxCtypeol);
            this.groupBox3.Controls.Add(this.btnAdrs);
            this.groupBox3.Controls.Add(this.cbActivity);
            this.groupBox3.Controls.Add(this.label22);
            this.groupBox3.Controls.Add(this.tWeb);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.tEmail);
            this.groupBox3.Controls.Add(this.label19);
            this.groupBox3.Controls.Add(this.tFax);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tTel1);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.tCompanyName2);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tCompanyName1);
            this.groupBox3.Controls.Add(this.lcustmTp);
            this.groupBox3.Controls.Add(this.cbMainCmpny);
            this.groupBox3.Controls.Add(this.lMainCmpny);
            this.groupBox3.Controls.Add(this.lCtype);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1060, 223);
            this.groupBox3.TabIndex = 15;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // Q_sysPcod
            // 
            this.Q_sysPcod.BackColor = System.Drawing.Color.White;
            this.Q_sysPcod.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Q_sysPcod.ForeColor = System.Drawing.Color.Red;
            this.Q_sysPcod.Location = new System.Drawing.Point(815, 176);
            this.Q_sysPcod.Multiline = true;
            this.Q_sysPcod.Name = "Q_sysPcod";
            this.Q_sysPcod.ReadOnly = true;
            this.Q_sysPcod.Size = new System.Drawing.Size(120, 27);
            this.Q_sysPcod.TabIndex = 377;
            this.Q_sysPcod.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txLID
            // 
            this.txLID.BackColor = System.Drawing.Color.AliceBlue;
            this.txLID.Location = new System.Drawing.Point(414, 37);
            this.txLID.Name = "txLID";
            this.txLID.ReadOnly = true;
            this.txLID.Size = new System.Drawing.Size(154, 20);
            this.txLID.TabIndex = 350;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(1019, 6);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(30, 30);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 349;
            this.pictureBox5.TabStop = false;
            this.pictureBox5.Click += new System.EventHandler(this.pictureBox5_Click);
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(987, 6);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(30, 30);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 348;
            this.pictureBox6.TabStop = false;
            this.pictureBox6.Click += new System.EventHandler(this.pictureBox6_Click);
            // 
            // ldone
            // 
            this.ldone.BackColor = System.Drawing.Color.Red;
            this.ldone.ForeColor = System.Drawing.Color.White;
            this.ldone.Location = new System.Drawing.Point(753, 136);
            this.ldone.Name = "ldone";
            this.ldone.Size = new System.Drawing.Size(92, 22);
            this.ldone.TabIndex = 346;
            this.ldone.Text = "done by:";
            this.ldone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ldone.Visible = false;
            // 
            // txBL
            // 
            this.txBL.BackColor = System.Drawing.Color.White;
            this.txBL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txBL.ForeColor = System.Drawing.Color.Turquoise;
            this.txBL.Location = new System.Drawing.Point(753, 37);
            this.txBL.MaxLength = 199;
            this.txBL.Multiline = true;
            this.txBL.Name = "txBL";
            this.txBL.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txBL.Size = new System.Drawing.Size(297, 99);
            this.txBL.TabIndex = 344;
            // 
            // chkLN
            // 
            this.chkLN.AutoCheck = false;
            this.chkLN.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLN.ForeColor = System.Drawing.Color.Red;
            this.chkLN.Location = new System.Drawing.Point(756, 14);
            this.chkLN.Name = "chkLN";
            this.chkLN.Size = new System.Drawing.Size(126, 24);
            this.chkLN.TabIndex = 343;
            this.chkLN.Text = "In Black List";
            this.chkLN.UseVisualStyleBackColor = true;
            this.chkLN.CheckedChanged += new System.EventHandler(this.chkLN_CheckedChanged);
            // 
            // grpCF
            // 
            this.grpCF.Controls.Add(this.lctypeID);
            this.grpCF.Controls.Add(this.lNCF_Name);
            this.grpCF.Controls.Add(this.btneditCF);
            this.grpCF.Controls.Add(this.btn_tNCF_save);
            this.grpCF.Controls.Add(this.btn_tNCF_cancel);
            this.grpCF.Controls.Add(this.label24);
            this.grpCF.Controls.Add(this.label21);
            this.grpCF.Controls.Add(this.tNCF_val);
            this.grpCF.Controls.Add(this.lnkCtype);
            this.grpCF.Location = new System.Drawing.Point(705, 158);
            this.grpCF.Name = "grpCF";
            this.grpCF.Size = new System.Drawing.Size(57, 49);
            this.grpCF.TabIndex = 94;
            this.grpCF.TabStop = false;
            this.grpCF.Visible = false;
            // 
            // lctypeID
            // 
            this.lctypeID.BackColor = System.Drawing.Color.LawnGreen;
            this.lctypeID.Location = new System.Drawing.Point(174, 18);
            this.lctypeID.Name = "lctypeID";
            this.lctypeID.Size = new System.Drawing.Size(16, 20);
            this.lctypeID.TabIndex = 100;
            this.lctypeID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lctypeID.Visible = false;
            // 
            // lNCF_Name
            // 
            this.lNCF_Name.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lNCF_Name.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lNCF_Name.Location = new System.Drawing.Point(45, 34);
            this.lNCF_Name.Name = "lNCF_Name";
            this.lNCF_Name.Size = new System.Drawing.Size(123, 20);
            this.lNCF_Name.TabIndex = 99;
            this.lNCF_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lNCF_Name.Click += new System.EventHandler(this.lNCF_Name_Click);
            // 
            // btneditCF
            // 
            this.btneditCF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btneditCF.Location = new System.Drawing.Point(282, 13);
            this.btneditCF.Name = "btneditCF";
            this.btneditCF.Size = new System.Drawing.Size(42, 20);
            this.btneditCF.TabIndex = 330;
            this.btneditCF.Text = "New";
            this.btneditCF.Visible = false;
            this.btneditCF.Click += new System.EventHandler(this.btneditCF_Click);
            // 
            // btn_tNCF_save
            // 
            this.btn_tNCF_save.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_tNCF_save.Location = new System.Drawing.Point(183, 9);
            this.btn_tNCF_save.Name = "btn_tNCF_save";
            this.btn_tNCF_save.Size = new System.Drawing.Size(47, 25);
            this.btn_tNCF_save.TabIndex = 97;
            this.btn_tNCF_save.Text = "&Save";
            this.btn_tNCF_save.Click += new System.EventHandler(this.btn_tNCF_save_Click);
            // 
            // btn_tNCF_cancel
            // 
            this.btn_tNCF_cancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btn_tNCF_cancel.Location = new System.Drawing.Point(183, 36);
            this.btn_tNCF_cancel.Name = "btn_tNCF_cancel";
            this.btn_tNCF_cancel.Size = new System.Drawing.Size(47, 25);
            this.btn_tNCF_cancel.TabIndex = 98;
            this.btn_tNCF_cancel.Text = "&Cancel";
            this.btn_tNCF_cancel.Click += new System.EventHandler(this.btn_tNCF_cancel_Click);
            // 
            // label24
            // 
            this.label24.Location = new System.Drawing.Point(6, 14);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(39, 20);
            this.label24.TabIndex = 96;
            this.label24.Text = "Value:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.Location = new System.Drawing.Point(6, 34);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(39, 20);
            this.label21.TabIndex = 94;
            this.label21.Text = "Name:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tNCF_val
            // 
            this.tNCF_val.BackColor = System.Drawing.Color.Lavender;
            this.tNCF_val.Location = new System.Drawing.Point(45, 14);
            this.tNCF_val.Name = "tNCF_val";
            this.tNCF_val.Size = new System.Drawing.Size(123, 20);
            this.tNCF_val.TabIndex = 93;
            this.tNCF_val.TextChanged += new System.EventHandler(this.tNCF_val_TextChanged);
            this.tNCF_val.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tNCF_val_KeyPress);
            // 
            // lnkCtype
            // 
            this.lnkCtype.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lnkCtype.Location = new System.Drawing.Point(330, 13);
            this.lnkCtype.Name = "lnkCtype";
            this.lnkCtype.Size = new System.Drawing.Size(44, 19);
            this.lnkCtype.TabIndex = 47;
            this.lnkCtype.TabStop = true;
            this.lnkCtype.Text = "Customer Type:";
            this.lnkCtype.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lnkCtype.Visible = false;
            this.lnkCtype.VisitedLinkColor = System.Drawing.Color.Blue;
            this.lnkCtype.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lnkCtype_LinkClicked);
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Red;
            this.label25.Location = new System.Drawing.Point(324, 149);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(84, 17);
            this.label25.TabIndex = 342;
            this.label25.Text = "Mulipliers:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lbxCtype
            // 
            this.lbxCtype.BackColor = System.Drawing.Color.Lavender;
            this.lbxCtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.lbxCtype.Location = new System.Drawing.Point(408, 115);
            this.lbxCtype.Name = "lbxCtype";
            this.lbxCtype.Size = new System.Drawing.Size(339, 21);
            this.lbxCtype.TabIndex = 92;
            this.lbxCtype.SelectedIndexChanged += new System.EventHandler(this.lbxCtype_SelectedIndexChanged);
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.btnCancel);
            this.groupBox12.Controls.Add(this.pictureBox1);
            this.groupBox12.Controls.Add(this.btnOK);
            this.groupBox12.Location = new System.Drawing.Point(354, 166);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(48, 46);
            this.groupBox12.TabIndex = 341;
            this.groupBox12.TabStop = false;
            this.groupBox12.Text = "groupBox12";
            this.groupBox12.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(81, 35);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(51, 25);
            this.btnCancel.TabIndex = 57;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(29, 22);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 32);
            this.pictureBox1.TabIndex = 83;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(72, 18);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(40, 25);
            this.btnOK.TabIndex = 56;
            this.btnOK.Text = "&Save";
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.label30);
            this.groupBox10.Controls.Add(this.EurMlt);
            this.groupBox10.Controls.Add(this.label28);
            this.groupBox10.Controls.Add(this.USMlt);
            this.groupBox10.Controls.Add(this.label27);
            this.groupBox10.Controls.Add(this.canMlt);
            this.groupBox10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox10.Location = new System.Drawing.Point(408, 135);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(276, 45);
            this.groupBox10.TabIndex = 339;
            this.groupBox10.TabStop = false;
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.ForeColor = System.Drawing.Color.Blue;
            this.label30.Location = new System.Drawing.Point(175, 17);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(41, 17);
            this.label30.TabIndex = 344;
            this.label30.Text = "EURO:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // EurMlt
            // 
            this.EurMlt.BackColor = System.Drawing.Color.Chartreuse;
            this.EurMlt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.EurMlt.Location = new System.Drawing.Point(216, 16);
            this.EurMlt.Name = "EurMlt";
            this.EurMlt.Size = new System.Drawing.Size(48, 18);
            this.EurMlt.TabIndex = 343;
            this.EurMlt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.ForeColor = System.Drawing.Color.Blue;
            this.label28.Location = new System.Drawing.Point(96, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(25, 17);
            this.label28.TabIndex = 342;
            this.label28.Text = "US:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // USMlt
            // 
            this.USMlt.BackColor = System.Drawing.Color.Chartreuse;
            this.USMlt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.USMlt.Location = new System.Drawing.Point(121, 16);
            this.USMlt.Name = "USMlt";
            this.USMlt.Size = new System.Drawing.Size(48, 18);
            this.USMlt.TabIndex = 341;
            this.USMlt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.ForeColor = System.Drawing.Color.Blue;
            this.label27.Location = new System.Drawing.Point(8, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(34, 17);
            this.label27.TabIndex = 340;
            this.label27.Text = "CAN:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // canMlt
            // 
            this.canMlt.BackColor = System.Drawing.Color.Chartreuse;
            this.canMlt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.canMlt.ForeColor = System.Drawing.Color.Black;
            this.canMlt.Location = new System.Drawing.Point(42, 15);
            this.canMlt.Name = "canMlt";
            this.canMlt.Size = new System.Drawing.Size(48, 18);
            this.canMlt.TabIndex = 339;
            this.canMlt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label26
            // 
            this.label26.Location = new System.Drawing.Point(16, 186);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(41, 17);
            this.label26.TabIndex = 332;
            this.label26.Text = "Status:";
            // 
            // TbxCtype
            // 
            this.TbxCtype.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TbxCtype.ForeColor = System.Drawing.Color.Red;
            this.TbxCtype.Location = new System.Drawing.Point(342, 117);
            this.TbxCtype.Name = "TbxCtype";
            this.TbxCtype.Size = new System.Drawing.Size(66, 17);
            this.TbxCtype.TabIndex = 331;
            this.TbxCtype.Text = "Activity:";
            this.TbxCtype.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(6, 18);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(15, 12);
            this.label20.TabIndex = 90;
            this.label20.Text = "*";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lActId
            // 
            this.lActId.BackColor = System.Drawing.Color.LawnGreen;
            this.lActId.Location = new System.Drawing.Point(513, 92);
            this.lActId.Name = "lActId";
            this.lActId.Size = new System.Drawing.Size(16, 20);
            this.lActId.TabIndex = 64;
            this.lActId.Text = "0";
            this.lActId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lActId.Visible = false;
            // 
            // lMainAdrs
            // 
            this.lMainAdrs.BackColor = System.Drawing.Color.AliceBlue;
            this.lMainAdrs.Location = new System.Drawing.Point(58, 57);
            this.lMainAdrs.Name = "lMainAdrs";
            this.lMainAdrs.ReadOnly = true;
            this.lMainAdrs.Size = new System.Drawing.Size(540, 20);
            this.lMainAdrs.TabIndex = 59;
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.chkSupp);
            this.groupBox8.Controls.Add(this.chkManufac);
            this.groupBox8.Controls.Add(this.chkCust);
            this.groupBox8.Location = new System.Drawing.Point(58, 178);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(182, 32);
            this.groupBox8.TabIndex = 58;
            this.groupBox8.TabStop = false;
            // 
            // chkSupp
            // 
            this.chkSupp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSupp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSupp.Location = new System.Drawing.Point(81, 9);
            this.chkSupp.Name = "chkSupp";
            this.chkSupp.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSupp.Size = new System.Drawing.Size(64, 16);
            this.chkSupp.TabIndex = 60;
            this.chkSupp.Text = "Supplier";
            this.chkSupp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkSupp.CheckedChanged += new System.EventHandler(this.chkSupp_CheckedChanged);
            // 
            // chkManufac
            // 
            this.chkManufac.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkManufac.Location = new System.Drawing.Point(219, 13);
            this.chkManufac.Name = "chkManufac";
            this.chkManufac.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkManufac.Size = new System.Drawing.Size(40, 16);
            this.chkManufac.TabIndex = 61;
            this.chkManufac.Text = "Manufacturer";
            this.chkManufac.Visible = false;
            // 
            // chkCust
            // 
            this.chkCust.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkCust.Checked = true;
            this.chkCust.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkCust.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkCust.Location = new System.Drawing.Point(5, 10);
            this.chkCust.Name = "chkCust";
            this.chkCust.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkCust.Size = new System.Drawing.Size(67, 16);
            this.chkCust.TabIndex = 59;
            this.chkCust.Text = "Customer";
            this.chkCust.CheckedChanged += new System.EventHandler(this.chkCust_CheckedChanged);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(11, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 20);
            this.label1.TabIndex = 57;
            this.label1.Text = "Name2:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // linkLabel3
            // 
            this.linkLabel3.Location = new System.Drawing.Point(423, 81);
            this.linkLabel3.Name = "linkLabel3";
            this.linkLabel3.Size = new System.Drawing.Size(29, 16);
            this.linkLabel3.TabIndex = 52;
            this.linkLabel3.TabStop = true;
            this.linkLabel3.Text = "Customer Area:";
            this.linkLabel3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.linkLabel3.Visible = false;
            this.linkLabel3.VisitedLinkColor = System.Drawing.Color.Blue;
            // 
            // lbxCtypeol
            // 
            this.lbxCtypeol.BackColor = System.Drawing.Color.Lavender;
            this.lbxCtypeol.Location = new System.Drawing.Point(658, 72);
            this.lbxCtypeol.Name = "lbxCtypeol";
            this.lbxCtypeol.Size = new System.Drawing.Size(46, 43);
            this.lbxCtypeol.TabIndex = 49;
            this.lbxCtypeol.Visible = false;
            this.lbxCtypeol.SelectedIndexChanged += new System.EventHandler(this.lbxCtype_SelectedIndexChanged);
            // 
            // btnAdrs
            // 
            this.btnAdrs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdrs.Location = new System.Drawing.Point(600, 56);
            this.btnAdrs.Name = "btnAdrs";
            this.btnAdrs.Size = new System.Drawing.Size(52, 20);
            this.btnAdrs.TabIndex = 43;
            this.btnAdrs.Text = "change";
            this.btnAdrs.Click += new System.EventHandler(this.btnAdrs_Click);
            // 
            // cbActivity
            // 
            this.cbActivity.BackColor = System.Drawing.Color.AliceBlue;
            this.cbActivity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActivity.Location = new System.Drawing.Point(58, 157);
            this.cbActivity.Name = "cbActivity";
            this.cbActivity.Size = new System.Drawing.Size(259, 21);
            this.cbActivity.TabIndex = 41;
            this.cbActivity.SelectedIndexChanged += new System.EventHandler(this.cbActivity_SelectedIndexChanged);
            // 
            // label22
            // 
            this.label22.Location = new System.Drawing.Point(8, 157);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(49, 20);
            this.label22.TabIndex = 40;
            this.label22.Text = "Type:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tWeb
            // 
            this.tWeb.BackColor = System.Drawing.Color.Lavender;
            this.tWeb.Location = new System.Drawing.Point(58, 137);
            this.tWeb.Name = "tWeb";
            this.tWeb.Size = new System.Drawing.Size(259, 20);
            this.tWeb.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(2, 137);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 33;
            this.label3.Text = "Web Site:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tEmail
            // 
            this.tEmail.BackColor = System.Drawing.Color.Lavender;
            this.tEmail.Location = new System.Drawing.Point(58, 117);
            this.tEmail.Name = "tEmail";
            this.tEmail.Size = new System.Drawing.Size(259, 20);
            this.tEmail.TabIndex = 32;
            // 
            // label19
            // 
            this.label19.Location = new System.Drawing.Point(11, 118);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(47, 18);
            this.label19.TabIndex = 31;
            this.label19.Text = "e-mail:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label19.Click += new System.EventHandler(this.label19_Click);
            // 
            // tFax
            // 
            this.tFax.BackColor = System.Drawing.Color.Lavender;
            this.tFax.Location = new System.Drawing.Point(58, 97);
            this.tFax.Name = "tFax";
            this.tFax.Size = new System.Drawing.Size(162, 20);
            this.tFax.TabIndex = 30;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(14, 97);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "&Fax:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tTel1
            // 
            this.tTel1.BackColor = System.Drawing.Color.Lavender;
            this.tTel1.Location = new System.Drawing.Point(58, 77);
            this.tTel1.Name = "tTel1";
            this.tTel1.Size = new System.Drawing.Size(162, 20);
            this.tTel1.TabIndex = 28;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(8, 77);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "Phone:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(10, 57);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 20);
            this.label11.TabIndex = 18;
            this.label11.Text = "Address:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(321, 19);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(93, 17);
            this.label9.TabIndex = 15;
            this.label9.Text = "Main   Company:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tCompanyName2
            // 
            this.tCompanyName2.BackColor = System.Drawing.Color.Lavender;
            this.tCompanyName2.Location = new System.Drawing.Point(58, 37);
            this.tCompanyName2.Name = "tCompanyName2";
            this.tCompanyName2.Size = new System.Drawing.Size(257, 20);
            this.tCompanyName2.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(17, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(39, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tCompanyName1
            // 
            this.tCompanyName1.BackColor = System.Drawing.Color.Lavender;
            this.tCompanyName1.Location = new System.Drawing.Point(58, 17);
            this.tCompanyName1.Name = "tCompanyName1";
            this.tCompanyName1.Size = new System.Drawing.Size(257, 20);
            this.tCompanyName1.TabIndex = 12;
            // 
            // lcustmTp
            // 
            this.lcustmTp.BackColor = System.Drawing.Color.LawnGreen;
            this.lcustmTp.Location = new System.Drawing.Point(247, 188);
            this.lcustmTp.Name = "lcustmTp";
            this.lcustmTp.Size = new System.Drawing.Size(24, 18);
            this.lcustmTp.TabIndex = 63;
            this.lcustmTp.Text = "0";
            this.lcustmTp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lcustmTp.Visible = false;
            // 
            // cbMainCmpny
            // 
            this.cbMainCmpny.BackColor = System.Drawing.Color.Lavender;
            this.cbMainCmpny.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMainCmpny.Location = new System.Drawing.Point(414, 17);
            this.cbMainCmpny.Name = "cbMainCmpny";
            this.cbMainCmpny.Size = new System.Drawing.Size(333, 21);
            this.cbMainCmpny.TabIndex = 16;
            this.cbMainCmpny.SelectedIndexChanged += new System.EventHandler(this.cbMainCmpny_SelectedIndexChanged);
            // 
            // lMainCmpny
            // 
            this.lMainCmpny.BackColor = System.Drawing.Color.AliceBlue;
            this.lMainCmpny.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lMainCmpny.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lMainCmpny.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lMainCmpny.Location = new System.Drawing.Point(414, 17);
            this.lMainCmpny.Name = "lMainCmpny";
            this.lMainCmpny.Size = new System.Drawing.Size(333, 20);
            this.lMainCmpny.TabIndex = 56;
            this.lMainCmpny.Visible = false;
            // 
            // lCtype
            // 
            this.lCtype.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lCtype.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lCtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.lCtype.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lCtype.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lCtype.Location = new System.Drawing.Point(408, 114);
            this.lCtype.Name = "lCtype";
            this.lCtype.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lCtype.Size = new System.Drawing.Size(339, 22);
            this.lCtype.TabIndex = 48;
            this.lCtype.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lCtype.DoubleClick += new System.EventHandler(this.lCtype_DoubleClick);
            // 
            // Det
            // 
            this.Det.Controls.Add(this.groupBox4);
            this.Det.Controls.Add(this.groupBox2);
            this.Det.Controls.Add(this.groupBox1);
            this.Det.Controls.Add(this.groupBox5);
            this.Det.Location = new System.Drawing.Point(4, 22);
            this.Det.Name = "Det";
            this.Det.Size = new System.Drawing.Size(1060, 375);
            this.Det.TabIndex = 1;
            this.Det.Text = "Details";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lInTermId);
            this.groupBox4.Controls.Add(this.lViaId);
            this.groupBox4.Controls.Add(this.cbIncoTerm);
            this.groupBox4.Controls.Add(this.label23);
            this.groupBox4.Controls.Add(this.cbShipVia);
            this.groupBox4.Controls.Add(this.label13);
            this.groupBox4.Location = new System.Drawing.Point(8, 240);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(632, 48);
            this.groupBox4.TabIndex = 45;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Shipping Info:";
            // 
            // lInTermId
            // 
            this.lInTermId.BackColor = System.Drawing.Color.LawnGreen;
            this.lInTermId.Location = new System.Drawing.Point(560, 16);
            this.lInTermId.Name = "lInTermId";
            this.lInTermId.Size = new System.Drawing.Size(16, 20);
            this.lInTermId.TabIndex = 65;
            this.lInTermId.Text = "0";
            this.lInTermId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lInTermId.Visible = false;
            // 
            // lViaId
            // 
            this.lViaId.BackColor = System.Drawing.Color.LawnGreen;
            this.lViaId.Location = new System.Drawing.Point(256, 16);
            this.lViaId.Name = "lViaId";
            this.lViaId.Size = new System.Drawing.Size(16, 20);
            this.lViaId.TabIndex = 64;
            this.lViaId.Text = "0";
            this.lViaId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lViaId.Visible = false;
            // 
            // cbIncoTerm
            // 
            this.cbIncoTerm.BackColor = System.Drawing.Color.Lavender;
            this.cbIncoTerm.Location = new System.Drawing.Point(384, 16);
            this.cbIncoTerm.Name = "cbIncoTerm";
            this.cbIncoTerm.Size = new System.Drawing.Size(176, 21);
            this.cbIncoTerm.TabIndex = 38;
            this.cbIncoTerm.SelectedIndexChanged += new System.EventHandler(this.cbIncoTerm_SelectedIndexChanged);
            // 
            // label23
            // 
            this.label23.Location = new System.Drawing.Point(288, 16);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(80, 20);
            this.label23.TabIndex = 37;
            this.label23.Text = "IncoTerm:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbShipVia
            // 
            this.cbShipVia.BackColor = System.Drawing.Color.Lavender;
            this.cbShipVia.Location = new System.Drawing.Point(80, 16);
            this.cbShipVia.Name = "cbShipVia";
            this.cbShipVia.Size = new System.Drawing.Size(176, 21);
            this.cbShipVia.TabIndex = 36;
            this.cbShipVia.SelectedIndexChanged += new System.EventHandler(this.cbShipVia_SelectedIndexChanged);
            // 
            // label13
            // 
            this.label13.Location = new System.Drawing.Point(16, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 20);
            this.label13.TabIndex = 35;
            this.label13.Text = "Via:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.tToll);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.tTel2);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(8, 128);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(632, 32);
            this.groupBox2.TabIndex = 32;
            this.groupBox2.TabStop = false;
            // 
            // tToll
            // 
            this.tToll.BackColor = System.Drawing.Color.Lavender;
            this.tToll.Location = new System.Drawing.Point(384, 8);
            this.tToll.Name = "tToll";
            this.tToll.Size = new System.Drawing.Size(176, 20);
            this.tToll.TabIndex = 32;
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(296, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(64, 20);
            this.label7.TabIndex = 31;
            this.label7.Text = "&Toll Free:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tTel2
            // 
            this.tTel2.BackColor = System.Drawing.Color.Lavender;
            this.tTel2.Location = new System.Drawing.Point(80, 8);
            this.tTel2.Name = "tTel2";
            this.tTel2.Size = new System.Drawing.Size(176, 20);
            this.tTel2.TabIndex = 30;
            // 
            // label8
            // 
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Location = new System.Drawing.Point(16, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(64, 20);
            this.label8.TabIndex = 29;
            this.label8.Text = "Phone2 :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lTermsId);
            this.groupBox1.Controls.Add(this.tCreditLim);
            this.groupBox1.Controls.Add(this.label18);
            this.groupBox1.Controls.Add(this.cbCurr);
            this.groupBox1.Controls.Add(this.label15);
            this.groupBox1.Controls.Add(this.cbTerms);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(8, 160);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(632, 80);
            this.groupBox1.TabIndex = 31;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Credit Info:";
            // 
            // lTermsId
            // 
            this.lTermsId.BackColor = System.Drawing.Color.LawnGreen;
            this.lTermsId.Location = new System.Drawing.Point(256, 24);
            this.lTermsId.Name = "lTermsId";
            this.lTermsId.Size = new System.Drawing.Size(24, 20);
            this.lTermsId.TabIndex = 63;
            this.lTermsId.Text = "0";
            this.lTermsId.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lTermsId.Visible = false;
            // 
            // tCreditLim
            // 
            this.tCreditLim.BackColor = System.Drawing.Color.Lavender;
            this.tCreditLim.Location = new System.Drawing.Point(80, 48);
            this.tCreditLim.Name = "tCreditLim";
            this.tCreditLim.Size = new System.Drawing.Size(88, 20);
            this.tCreditLim.TabIndex = 40;
            this.tCreditLim.Text = "0";
            // 
            // label18
            // 
            this.label18.Location = new System.Drawing.Point(8, 48);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(72, 20);
            this.label18.TabIndex = 39;
            this.label18.Text = "Credit Limit:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbCurr
            // 
            this.cbCurr.BackColor = System.Drawing.Color.Lavender;
            this.cbCurr.Items.AddRange(new object[] {
            "USD",
            "CAD",
            "Other..."});
            this.cbCurr.Location = new System.Drawing.Point(384, 24);
            this.cbCurr.Name = "cbCurr";
            this.cbCurr.Size = new System.Drawing.Size(176, 21);
            this.cbCurr.TabIndex = 38;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(296, 24);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(72, 20);
            this.label15.TabIndex = 37;
            this.label15.Text = "Currency:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbTerms
            // 
            this.cbTerms.BackColor = System.Drawing.Color.Lavender;
            this.cbTerms.Location = new System.Drawing.Point(80, 24);
            this.cbTerms.Name = "cbTerms";
            this.cbTerms.Size = new System.Drawing.Size(176, 21);
            this.cbTerms.TabIndex = 36;
            this.cbTerms.SelectedIndexChanged += new System.EventHandler(this.cbTerms_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(8, 24);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 20);
            this.label5.TabIndex = 35;
            this.label5.Text = "Terms:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.lIA);
            this.groupBox5.Controls.Add(this.lQA);
            this.groupBox5.Controls.Add(this.lSA);
            this.groupBox5.Controls.Add(this.lPA);
            this.groupBox5.Controls.Add(this.btnAI);
            this.groupBox5.Controls.Add(this.btnAQ);
            this.groupBox5.Controls.Add(this.btnAP);
            this.groupBox5.Controls.Add(this.btnAS);
            this.groupBox5.Controls.Add(this.label6);
            this.groupBox5.Controls.Add(this.label14);
            this.groupBox5.Controls.Add(this.label16);
            this.groupBox5.Controls.Add(this.label17);
            this.groupBox5.Location = new System.Drawing.Point(8, 8);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(632, 120);
            this.groupBox5.TabIndex = 14;
            this.groupBox5.TabStop = false;
            this.groupBox5.Text = " Address Info:";
            // 
            // lIA
            // 
            this.lIA.BackColor = System.Drawing.Color.AliceBlue;
            this.lIA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lIA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lIA.Location = new System.Drawing.Point(80, 88);
            this.lIA.Name = "lIA";
            this.lIA.Size = new System.Drawing.Size(480, 20);
            this.lIA.TabIndex = 52;
            // 
            // lQA
            // 
            this.lQA.BackColor = System.Drawing.Color.AliceBlue;
            this.lQA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lQA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lQA.Location = new System.Drawing.Point(80, 16);
            this.lQA.Name = "lQA";
            this.lQA.Size = new System.Drawing.Size(480, 20);
            this.lQA.TabIndex = 51;
            // 
            // lSA
            // 
            this.lSA.BackColor = System.Drawing.Color.AliceBlue;
            this.lSA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lSA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lSA.Location = new System.Drawing.Point(80, 64);
            this.lSA.Name = "lSA";
            this.lSA.Size = new System.Drawing.Size(480, 20);
            this.lSA.TabIndex = 50;
            // 
            // lPA
            // 
            this.lPA.BackColor = System.Drawing.Color.AliceBlue;
            this.lPA.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lPA.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lPA.Location = new System.Drawing.Point(80, 40);
            this.lPA.Name = "lPA";
            this.lPA.Size = new System.Drawing.Size(480, 20);
            this.lPA.TabIndex = 49;
            // 
            // btnAI
            // 
            this.btnAI.Location = new System.Drawing.Point(568, 88);
            this.btnAI.Name = "btnAI";
            this.btnAI.Size = new System.Drawing.Size(24, 20);
            this.btnAI.TabIndex = 48;
            this.btnAI.Text = "...";
            this.btnAI.Click += new System.EventHandler(this.btnAI_Click);
            // 
            // btnAQ
            // 
            this.btnAQ.Location = new System.Drawing.Point(568, 16);
            this.btnAQ.Name = "btnAQ";
            this.btnAQ.Size = new System.Drawing.Size(24, 20);
            this.btnAQ.TabIndex = 47;
            this.btnAQ.Text = "...";
            this.btnAQ.Click += new System.EventHandler(this.btnAQ_Click);
            // 
            // btnAP
            // 
            this.btnAP.Location = new System.Drawing.Point(568, 40);
            this.btnAP.Name = "btnAP";
            this.btnAP.Size = new System.Drawing.Size(24, 20);
            this.btnAP.TabIndex = 46;
            this.btnAP.Text = "...";
            this.btnAP.Click += new System.EventHandler(this.btnAP_Click);
            // 
            // btnAS
            // 
            this.btnAS.Location = new System.Drawing.Point(568, 64);
            this.btnAS.Name = "btnAS";
            this.btnAS.Size = new System.Drawing.Size(24, 20);
            this.btnAS.TabIndex = 45;
            this.btnAS.Text = "...";
            this.btnAS.Click += new System.EventHandler(this.btnAS_Click);
            // 
            // label6
            // 
            this.label6.Location = new System.Drawing.Point(16, 88);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 20);
            this.label6.TabIndex = 15;
            this.label6.Text = "Invoice:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(16, 64);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(64, 20);
            this.label14.TabIndex = 13;
            this.label14.Text = "Ship:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label16
            // 
            this.label16.Location = new System.Drawing.Point(16, 40);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(64, 20);
            this.label16.TabIndex = 11;
            this.label16.Text = "Purchase:";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label17
            // 
            this.label17.Location = new System.Drawing.Point(16, 16);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(64, 20);
            this.label17.TabIndex = 9;
            this.label17.Text = "Quotation:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cmnts
            // 
            this.cmnts.Controls.Add(this.groupBox6);
            this.cmnts.Location = new System.Drawing.Point(4, 22);
            this.cmnts.Name = "cmnts";
            this.cmnts.Size = new System.Drawing.Size(1060, 375);
            this.cmnts.TabIndex = 2;
            this.cmnts.Text = "Comments";
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.lvComment);
            this.groupBox6.Controls.Add(this.groupBox9);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox6.Location = new System.Drawing.Point(0, 0);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(1060, 375);
            this.groupBox6.TabIndex = 47;
            this.groupBox6.TabStop = false;
            // 
            // lvComment
            // 
            this.lvComment.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvComment.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.dd,
            this.usr,
            this.cmnt,
            this.cLID});
            this.lvComment.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvComment.FullRowSelect = true;
            this.lvComment.GridLines = true;
            this.lvComment.Location = new System.Drawing.Point(3, 104);
            this.lvComment.MultiSelect = false;
            this.lvComment.Name = "lvComment";
            this.lvComment.Size = new System.Drawing.Size(1054, 268);
            this.lvComment.TabIndex = 53;
            this.lvComment.UseCompatibleStateImageBehavior = false;
            this.lvComment.View = System.Windows.Forms.View.Details;
            this.lvComment.SelectedIndexChanged += new System.EventHandler(this.lvComment_SelectedIndexChanged_1);
            this.lvComment.DoubleClick += new System.EventHandler(this.lvComment_DoubleClick);
            // 
            // dd
            // 
            this.dd.Text = "Date";
            this.dd.Width = 102;
            // 
            // usr
            // 
            this.usr.Text = "User";
            this.usr.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.usr.Width = 92;
            // 
            // cmnt
            // 
            this.cmnt.Text = "Comments";
            this.cmnt.Width = 399;
            // 
            // cLID
            // 
            this.cLID.Text = "";
            this.cLID.Width = 0;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.pictureBox3);
            this.groupBox9.Controls.Add(this.pictureBox2);
            this.groupBox9.Controls.Add(this.label12);
            this.groupBox9.Controls.Add(this.btnComnt);
            this.groupBox9.Controls.Add(this.tComnt);
            this.groupBox9.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox9.Location = new System.Drawing.Point(3, 16);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(1054, 88);
            this.groupBox9.TabIndex = 52;
            this.groupBox9.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(72, 48);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(30, 30);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 180;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(40, 48);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(30, 30);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 179;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // label12
            // 
            this.label12.Location = new System.Drawing.Point(40, 16);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 16);
            this.label12.TabIndex = 178;
            this.label12.Text = "Comment:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnComnt
            // 
            this.btnComnt.BackColor = System.Drawing.Color.Transparent;
            this.btnComnt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnComnt.Image = ((System.Drawing.Image)(resources.GetObject("btnComnt.Image")));
            this.btnComnt.Location = new System.Drawing.Point(8, 48);
            this.btnComnt.Name = "btnComnt";
            this.btnComnt.Size = new System.Drawing.Size(30, 30);
            this.btnComnt.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnComnt.TabIndex = 177;
            this.btnComnt.TabStop = false;
            this.btnComnt.Click += new System.EventHandler(this.btnComnt_Click);
            // 
            // tComnt
            // 
            this.tComnt.BackColor = System.Drawing.Color.Lavender;
            this.tComnt.Location = new System.Drawing.Point(104, 16);
            this.tComnt.MaxLength = 199;
            this.tComnt.Multiline = true;
            this.tComnt.Name = "tComnt";
            this.tComnt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tComnt.Size = new System.Drawing.Size(640, 64);
            this.tComnt.TabIndex = 176;
            // 
            // tCompanyID
            // 
            this.tCompanyID.BackColor = System.Drawing.Color.LawnGreen;
            this.tCompanyID.Location = new System.Drawing.Point(16, 448);
            this.tCompanyID.Name = "tCompanyID";
            this.tCompanyID.Size = new System.Drawing.Size(16, 20);
            this.tCompanyID.TabIndex = 61;
            this.tCompanyID.Text = "0";
            this.tCompanyID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.tCompanyID.Visible = false;
            // 
            // lMainCpnyID
            // 
            this.lMainCpnyID.BackColor = System.Drawing.Color.LawnGreen;
            this.lMainCpnyID.Location = new System.Drawing.Point(40, 448);
            this.lMainCpnyID.Name = "lMainCpnyID";
            this.lMainCpnyID.Size = new System.Drawing.Size(16, 20);
            this.lMainCpnyID.TabIndex = 62;
            this.lMainCpnyID.Text = "0";
            this.lMainCpnyID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lMainCpnyID.Visible = false;
            // 
            // lupdate
            // 
            this.lupdate.BackColor = System.Drawing.Color.LawnGreen;
            this.lupdate.Location = new System.Drawing.Point(160, 448);
            this.lupdate.Name = "lupdate";
            this.lupdate.Size = new System.Drawing.Size(16, 20);
            this.lupdate.TabIndex = 63;
            this.lupdate.Text = "N";
            this.lupdate.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lupdate.Visible = false;
            // 
            // TSmain
            // 
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Sav_,
            this.Newcontact,
            this.del_BRD,
            this.exiit,
            this.toolStripButton1,
            this.toolStripButton2});
            this.TSmain.Location = new System.Drawing.Point(0, 0);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(1074, 54);
            this.TSmain.TabIndex = 258;
            this.TSmain.Text = "toolStrip2";
            this.TSmain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TSmain_ItemClicked);
            // 
            // Sav_
            // 
            this.Sav_.Image = ((System.Drawing.Image)(resources.GetObject("Sav_.Image")));
            this.Sav_.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Sav_.Name = "Sav_";
            this.Sav_.Size = new System.Drawing.Size(36, 51);
            this.Sav_.Text = "Save";
            this.Sav_.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Sav_.ToolTipText = "Save Info.";
            this.Sav_.Click += new System.EventHandler(this.Sav__Click);
            // 
            // Newcontact
            // 
            this.Newcontact.Image = ((System.Drawing.Image)(resources.GetObject("Newcontact.Image")));
            this.Newcontact.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Newcontact.Name = "Newcontact";
            this.Newcontact.Size = new System.Drawing.Size(80, 51);
            this.Newcontact.Text = "New Contact";
            this.Newcontact.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Newcontact.ToolTipText = "New Contact";
            this.Newcontact.Click += new System.EventHandler(this.Newcontact_Click);
            // 
            // del_BRD
            // 
            this.del_BRD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del_BRD.Name = "del_BRD";
            this.del_BRD.Size = new System.Drawing.Size(78, 51);
            this.del_BRD.Text = "Delete Board";
            this.del_BRD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.del_BRD.ToolTipText = "Delete Board";
            this.del_BRD.Visible = false;
            // 
            // exiit
            // 
            this.exiit.Image = ((System.Drawing.Image)(resources.GetObject("exiit.Image")));
            this.exiit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exiit.Name = "exiit";
            this.exiit.Size = new System.Drawing.Size(47, 51);
            this.exiit.Text = "   Exit   ";
            this.exiit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exiit.ToolTipText = "Exit";
            this.exiit.Click += new System.EventHandler(this.exiit_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 51);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Visible = false;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 51);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Visible = false;
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // groupBox11
            // 
            this.groupBox11.Controls.Add(this.tabControl1);
            this.groupBox11.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox11.Location = new System.Drawing.Point(0, 54);
            this.groupBox11.Name = "groupBox11";
            this.groupBox11.Size = new System.Drawing.Size(1074, 420);
            this.groupBox11.TabIndex = 259;
            this.groupBox11.TabStop = false;
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(749, 4);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(39, 42);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 265;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // Company
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1074, 474);
            this.Controls.Add(this.picCIP);
            this.Controls.Add(this.groupBox11);
            this.Controls.Add(this.TSmain);
            this.Controls.Add(this.lupdate);
            this.Controls.Add(this.lMainCpnyID);
            this.Controls.Add(this.tCompanyID);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Company";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Company";
            this.Load += new System.EventHandler(this.Company_Load);
            this.tabControl1.ResumeLayout(false);
            this.Ginfo.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picVcon)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            this.grpCF.ResumeLayout(false);
            this.grpCF.PerformLayout();
            this.groupBox12.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox10.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.Det.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.cmnts.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox9.ResumeLayout(false);
            this.groupBox9.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnComnt)).EndInit();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.groupBox11.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

	

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			lupdate.Text ="N";
			this.Hide();
		}

		private void tabPage1_Click(object sender, System.EventArgs e)
		{
		
		}

	

		private void btnAdrs_Click(object sender, System.EventArgs e)
		{
		    
			
			dlgAdrs dAdrs = new dlgAdrs(lMainAdrs.Text  );
			dAdrs.ShowDialog(); 
			if (dAdrs.tStreet.Text   != ""  )  lMainAdrs.Text = dAdrs.tStreet.Text + ", " + dAdrs.cbCity.Text + ", " + dAdrs.cbSP.Text  + ", " + dAdrs.tZip.Text  + ", " + dAdrs.cbCountry .Text     ;
		}

	

		private void chkCust_CheckedChanged(object sender, System.EventArgs e)
		{
			
		//	lnkCtype.Visible =chkCust.Checked  ;
	//		if (lCtype.Text =="") lCtype.Text ="PL";
	//		lCtype.Visible =chkCust.Checked ;
			if (!lnkCtype.Visible) lcustmTp.Text ="0";
			

		}

		private void lnkCtype_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{


			lCtype.Visible =false ;
            lbxCtype.Text = lCtype.Text;
			lbxCtype.Visible =true;
            TbxCtype.Visible = true;
            btneditCF.Visible = (MainMDI.User.ToLower () == "ede" || MainMDI.profile == 'S');
            
		
		}

		private void lbxCtype_SelectedIndexChangedtttttt(object sender, System.EventArgs e)
		{
		//	lCtype.Text = lbxCtype.SelectedItem.ToString (); 
		//	lCtype.Visible =true ;
		//	lbxCtype.Visible =false;
		//	lcustmTp.Text = lbxCtype.SelectedIndex.ToString();   
		}

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			tComnt.Visible =!tComnt.Visible;
			btnComnt.Visible =!btnComnt.Visible ;
			 
		}

		private void fill_infoCompany()
		{
	
			try
			{
		
		//		string stsql= "select [PSM_Company].* FROM [PSM_Company] where [PSM_Company].Cpny_Name1='" + In_CompanyName + "' order by [PSM_Company].Cpny_Name1" ;
				//			string stsql="SELECT PSM_Company.*, PSM_IncoTerm.IT_DESC, PSM_ShipMeth.ShipEng, PSM_Terms.Descr, PSM_Activity.Activ_Desc " +
				//                       " FROM (((PSM_Company INNER JOIN PSM_Activity ON PSM_Company.actvId = PSM_Activity.Activ_ID) INNER JOIN PSM_IncoTerm ON PSM_Company.IncoTerm_ID = PSM_IncoTerm.IT_ID) " + 
				//			         " INNER JOIN PSM_ShipMeth ON PSM_Company.ShipVia_ID = PSM_ShipMeth.ship_ID) INNER JOIN PSM_Terms ON PSM_Company.TermID = PSM_Terms.InTermId " +
				//                   " WHERE (((PSM_Company.Cpny_Name1)='" + In_CompanyName + "')) ORDER BY PSM_Company.Cpny_Name1";
                string stSql = "select PSM_Company.*,PSM_CmpnyTYPE.*  FROM PSM_Company inner join PSM_CmpnyTYPE on PSM_Company.CustomerType =PSM_CmpnyTYPE.CpnyType_ID    where [PSM_Company].Cpny_Name1='" + In_CompanyName + "' and  Syspro_Code='" + in_cpnySPcode +  "'  order by [PSM_Company].Cpny_Name1";
                
                SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
				SqlDataAdapter  OAdp = new SqlDataAdapter (stSql , OConn );
				DataSet m_Ds = new DataSet("PSM_Company" ) ;
				OAdp.Fill(m_Ds  ,"PSM_Company" ); 
				lMainCmpny.Text = In_CompanyName;lMainCpnyID.Text ="0"; 
				lMainCmpny.Visible = true;
				cbMainCmpny.Visible =false;
				lTermsId.Text ="0"; lActId.Text="0";
				cbShipVia.Text="0";
				if (m_Ds.Tables[0].Rows.Count >0) 
				{
                    if (m_Ds.Tables[0].Rows.Count >1) MessageBox.Show ("other companies may have SAME NAME ...Ask Admin to check this !!!");
					if ( m_Ds.Tables["PSM_Company"].Rows[0]["Cpny_Main"].ToString () != "" ) 
					{
						lMainCmpny.Text  = MainMDI.Find_One_Field("select Cpny_Name1 from PSM_COMPANY where  Cpny_ID=" + m_Ds.Tables["PSM_Company"].Rows[0]["Cpny_Main"].ToString () );  
						lMainCpnyID.Text ="0"; 
					}
                    bool InBLackLst =( m_Ds.Tables["PSM_Company"].Rows[0]["BLack_List"].ToString()=="1");
                    ldone.Text = "Done by: " + m_Ds.Tables["PSM_Company"].Rows[0]["BL_usr"].ToString();
                    txBL.Text = m_Ds.Tables["PSM_Company"].Rows[0]["BL_Cmnt"].ToString();
                    chkLN.Checked = InBLackLst;


                    tCompanyID.Text = m_Ds.Tables["PSM_Company"].Rows[0]["Cpny_ID"].ToString(); txLID.Text = tCompanyID.Text;
                    Q_sysPcod.Text = m_Ds.Tables["PSM_Company"].Rows[0]["Syspro_Code"].ToString(); 
					tCompanyName1.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["Cpny_Name1"].ToString () ; 
					tCompanyName2.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["Cpny_Name2"].ToString () ; 
					lMainAdrs.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["M_Adrs"].ToString () ;//+ ", " + m_Ds.Tables["PSM_Company"].Rows[0]["M_Adrs"].ToString () + ", " + m_Ds.Tables["PSM_Company"].Rows[0]["City"].ToString ()+ ", " + m_Ds.Tables["PSM_Company"].Rows[0]["Province_State"].ToString ()+ ", " + m_Ds.Tables["PSM_Company"].Rows[0]["Country_Name"].ToString (); 
					lQA.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["Q_Adrs"].ToString () ; 
					lPA.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["P_Adrs"].ToString () ; 
					lSA.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["S_Adrs"].ToString () ; 
					lIA.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["I_Adrs"].ToString () ; 
					lIA.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["I_Adrs"].ToString () ; 
					tTel1.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["Tel1"].ToString () ; 
					tTel2.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["Tel2"].ToString () ; 
					tFax.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["Fax"].ToString () ; 
					tToll.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["TollFree"].ToString () ; 
					tWeb.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["Web"].ToString () ; 
					tEmail.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["Email"].ToString () ; 
					//MessageBox.Show (  m_Ds.Tables["PSM_Company"].Rows[0]["Term"].ToString ());
					if ( m_Ds.Tables["PSM_Company"].Rows[0]["IncoTerm_ID"].ToString () != "" ) 	{ cbIncoTerm.Text = MainMDI.Find_One_Field("select IT_DESC from PSM_IncoTerm where IT_ID=" +m_Ds.Tables["PSM_Company"].Rows[0]["IncoTerm_ID"].ToString () );  lTermsId.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["IncoTerm_ID"].ToString ();} 
					else cbIncoTerm.Text = MainMDI.VIDE  ;
					if ( m_Ds.Tables["PSM_Company"].Rows[0]["TermID"].ToString () != "" ) 	cbTerms.Text  =  MainMDI.Find_One_Field("select Descr  from PSM_Terms where InTermId=" +  m_Ds.Tables["PSM_Company"].Rows[0]["TERMID"].ToString ()  );  
					else cbTerms.Text = MainMDI.VIDE  ;
					if ( m_Ds.Tables["PSM_Company"].Rows[0]["ShipVia_ID"].ToString () != "" ) {	cbShipVia.Text =  MainMDI.Find_One_Field("select ShipEng  from PSM_ShipMeth where ship_ID=" + m_Ds.Tables["PSM_Company"].Rows[0]["ShipVia_ID"].ToString ()  ); lViaId.Text = m_Ds.Tables["PSM_Company"].Rows[0]["ShipVia_ID"].ToString ();} 
					else cbShipVia.Text = MainMDI.VIDE  ;
					if ( m_Ds.Tables["PSM_Company"].Rows[0]["actvId"].ToString () != "" ) 	{ cbActivity.Text  = MainMDI.Find_One_Field("select Activ_Desc from PSM_Activity where  Activ_ID=" + m_Ds.Tables["PSM_Company"].Rows[0]["actvId"].ToString () );  lActId.Text =m_Ds.Tables["PSM_Company"].Rows[0]["actvId"].ToString ();} 
					else 	cbActivity.Text = MainMDI.VIDE  ;
				    		  
				
					tCreditLim.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["CreditLim"].ToString () ; 
					//	tEmail.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["Email"].ToString () ; 
					//	tEmail.Text =  m_Ds.Tables["PSM_Company"].Rows[0]["Email"].ToString () ; 
					chkCust.Checked = ( m_Ds.Tables["PSM_Company"].Rows[0]["Customer"].ToString().ToLower() =="true") ? true :false  ; 
					chkSupp.Checked = ( m_Ds.Tables["PSM_Company"].Rows[0]["Supplier"].ToString().ToLower() =="true") ? true :false  ; 
					chkManufac.Checked = ( m_Ds.Tables["PSM_Company"].Rows[0]["Manufacturer"].ToString().ToLower() =="true") ? true :false  ;
                
                    lbxCtype.Text =m_Ds.Tables["PSM_Company"].Rows[0]["CpnyType"].ToString();
                    
						//lCtype.Text= lbxCtype.Items[inx].ToString();	lcustmTp.Text = inx.ToString();  
		
					if (m_Ds.Tables["PSM_Company"].Rows[0]["City"].ToString () !="" || m_Ds.Tables["PSM_Company"].Rows[0]["Province_State"].ToString () !="" || m_Ds.Tables["PSM_Company"].Rows[0]["Country_Name"].ToString () !="")
					{
						lMainAdrs.Text = lMainAdrs.Text.Replace(",","-")  +  ", " + m_Ds.Tables["PSM_Company"].Rows[0]["City"].ToString ().Replace(",","-")+ ", " + m_Ds.Tables["PSM_Company"].Rows[0]["Province_State"].ToString ().Replace(",","-")  + ", " + "" + ", " + m_Ds.Tables["PSM_Company"].Rows[0]["Country_Name"].ToString ().Replace(",","-")    ;
					}
					fill_contacts();
				}
				else MessageBox.Show ("Error-->company NOT FOUND....  please contact your Admin !!!");
			
				OConn.Close (); 
			}
			catch (SqlException Oexp)
			{
				MessageBox.Show("ERROR= " + Oexp.Message );
			}
			
		}

		private void fill_contacts()
		{
			//	string stsql= "select [PSM_Contacts].* FROM [PSM_Contacts] where [PSM_Contacts].Company_ID='" + tCompanyID.Text  + "' order by [PSM_Contacts].First_Name, [PSM_Contacts].Last_Name" ;
			string stsql= "SELECT PSM_Contacts.* FROM PSM_Contacts WHERE (PSM_Contacts.Company_ID)=" + Convert.ToInt32(tCompanyID.Text)  + " and JOBTitle<>'~~' order by First_Name " ;
			//	MessageBox.Show ("SQL= " + stsql  ); 
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			SqlDataAdapter OAdp = new SqlDataAdapter (stsql , OConn );
			DataSet m_Ds = new DataSet("PSM_Contacts" ) ;
			OAdp.Fill(m_Ds  ,"PSM_Contacts" ); 
			//		MessageBox.Show ("SQL= " + stsql + " NBR= " + m_Ds.Tables[0].Rows.Count ); 
			for (int i=0;i< m_Ds.Tables[0].Rows.Count ;i++)
			{
				if (m_Ds.Tables["PSM_Contacts"].Rows[i][2 ].ToString()  != "")
				{
					ListViewItem lvI= lvContact.Items.Add(m_Ds.Tables["PSM_Contacts"].Rows[i][2].ToString () + " " + m_Ds.Tables["PSM_Contacts"].Rows[i][3].ToString () );
					//lvCompany.Items[lvCompany.Items.Count-1].SubItems[0].ForeColor =Color.Brown ;   
					lvI.SubItems.Add(m_Ds.Tables["PSM_Contacts"].Rows[i][7].ToString());// + " " + m_Ds.Tables["PSM_Contacts"].Rows[i][3].ToString() ); 
					lvI.SubItems.Add(m_Ds.Tables["PSM_Contacts"].Rows[i][12].ToString () ); 
					lvI.SubItems.Add(m_Ds.Tables["PSM_Contacts"].Rows[i][0].ToString () ); 
					lvI.SubItems.Add("*"); 
					//lvCompany.Items[lvCompany.Items.Count-1].SubItems[0].ForeColor =Color.Tomato  ; 
				}
			}
			OConn.Close ();
		}


		private void Fill_frmCompany()
		{
        
			string tblName="PSM_Company";
			string stsql = "select * FROM PSM_Company order by Cpny_Name1";
			SqlConnection Ipsm_Conn  = new SqlConnection(MainMDI.M_stCon  );
			ArrayList ar_CName = new ArrayList(); 

			SqlDataAdapter OAdp = new SqlDataAdapter(stsql , Ipsm_Conn );
			//	OAdp = new SqlDataReader(stsql , Ipsm_Conn );
			DataSet Ipsm_Ds = new DataSet(tblName) ;
			OAdp.Fill(Ipsm_Ds  ,tblName ); 
			for (int i=0;i< Ipsm_Ds.Tables[0].Rows.Count ;i++)	cbMainCmpny.Items.Add(  Ipsm_Ds.Tables["PSM_Company"].Rows[i][1].ToString ()  ); 
			OAdp = new SqlDataAdapter("select * FROM PSM_Activity" , Ipsm_Conn );
			OAdp.Fill(Ipsm_Ds  ,"PSM_Activity" ); 
			for (int i=0;i< Ipsm_Ds.Tables[1 ].Rows.Count ;i++)	cbActivity.Items.Add(  Ipsm_Ds.Tables["PSM_Activity" ].Rows[i][1].ToString ()  ); 
			//    for (int i=0;i< Ipsm_Ds.Tables[1 ].Rows.Count ;i++)	ar_CName.Add( new ar_CName(Ipsm_Ds.Tables["PSM_Activity" ].Rows[i][0].ToString (),Ipsm_Ds.Tables["PSM_Activity" ].Rows[i][1].ToString ()));
			//	cbActivity.Items.Add(  new arrL[Ipsm_Ds.Tables["PSM_Activity" ].Rows[i][1].ToString (),Ipsm_Ds.Tables["PSM_Activity" ].Rows[i][0].ToString ()  ); 
		    
			OAdp = new SqlDataAdapter("select * FROM PSM_Terms" , Ipsm_Conn );
			OAdp.Fill(Ipsm_Ds  ,"PSM_Terms" ); 
			for (int i=0;i< Ipsm_Ds.Tables[2 ].Rows.Count ;i++)	cbTerms.Items.Add(  Ipsm_Ds.Tables["PSM_Terms" ].Rows[i][2].ToString ()  ); 
		
			OAdp = new SqlDataAdapter("select * FROM PSM_ShipMeth" , Ipsm_Conn );
			OAdp.Fill(Ipsm_Ds  ,"PSM_ShipMeth" ); 
			for (int i=0;i< Ipsm_Ds.Tables[3].Rows.Count ;i++)	cbShipVia.Items.Add(  Ipsm_Ds.Tables["PSM_ShipMeth" ].Rows[i][1].ToString ()  ); 
		  
			OAdp = new SqlDataAdapter("select * FROM PSM_IncoTerm" , Ipsm_Conn );
			OAdp.Fill(Ipsm_Ds  ,"PSM_IncoTerm" ); 
			for (int i=0;i< Ipsm_Ds.Tables[4 ].Rows.Count ;i++)	
			{
				cbIncoTerm.Items.Add(  Ipsm_Ds.Tables["PSM_IncoTerm" ].Rows[i][2].ToString ()  ); 
				//	    ar_Terms[i][0]= 
			}
		//	OAdp = new SqlDataAdapter("select * FROM PSM_CmpnyTYPE" , Ipsm_Conn );
            OAdp = new SqlDataAdapter("select * FROM PSM_CmpnyTYPE where NorO='N'", Ipsm_Conn);
			OAdp.Fill(Ipsm_Ds  ,"PSM_CmpnyTYPE" );
        //    lbxCtype.Items.Add("NEW"); 
			for (int i=0;i< Ipsm_Ds.Tables[5].Rows.Count ;i++)	
			{
				lbxCtype.Items.Add(Ipsm_Ds.Tables["PSM_CmpnyTYPE" ].Rows[i][1].ToString ()  ); 
				
			}
            
			//if (In_Opera  =='N') MessageBox.Show ("Adding"); 
			if (In_Opera  =='M'){ fill_infoCompany();btnOK.Text ="&Update";}  
		
		}



		private void Company_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!"; 
        //    btneditCF.Visible =(MainMDI.User == "Admin" || MainMDI.profile == 'S');
       //     picNewcf.Visible =(MainMDI.User == "Admin" || MainMDI.profile == 'S');
            
            
		}

		private void cbActivity_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lActId.Text = MainMDI.Find_One_Field("select Activ_ID from PSM_Activity where  Activ_Desc='" + cbActivity.Text   + "'");  
			if (lActId.Text  == MainMDI.VIDE ) lActId.Text = "0" ; 
		
		}

		private void cbActivity_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			//	string tt=e.KeyChar.ToString ();
			//	int ndx=cbActivity.FindString(tt  );
			//	MessageBox.Show ("ndx= " + ndx.ToString ()+ "  tt= " +tt);
			//	cbActivity.SelectedIndex=ndx; 
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lnkCmnt_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			tComnt.Visible =true ;
			btnComnt.Visible =true ;
		}
		private bool fields_ok()
		{
            bool res = true;
            if (tCompanyName1.Text == "") res = false;
            else if (chkLN.Checked && txBL.Text.Length < 3) res = false;
			return res  ;
		}
		private void btnOK_Click(object sender, System.EventArgs e)
		{

			if (MainMDI.ALWD_USR("CPN_SV",true))
			{

				lupdate.Text ="E";
				if (fields_ok()) 
				{ 
                        int BL = (chkLN.Checked) ? 1 : 0;
                        string BLCmnt = (chkLN.Checked) ? txBL.Text   : "";
                        string BLusr=(chkLN.Checked) ? MainMDI.User   : "";
					if (btnOK.Text == "&Save" )
					{
						//if (MainMDI.Find_One_Field("Select Cpny_ID from PSM_COMPANY where Cpny_Name1='" + tCompanyName1.Text.Replace("'","''")  + "'"  )==MainMDI.VIDE )  

                        if (!company_Exists (tCompanyName1.Text.Replace("'","''"),""))
                        {
							try
							{
								//int ID= Convert.ToInt32(  MainMDI.Find_One_Field("Select Cpny_ID from PSM_COMPANY order by Cpny_ID DESC"));  
                            //	string stSql= "INSERT INTO PSM_COMPANY ([Cpny_ID],[Cpny_Name1],[M_Adrs], " + 
								string stSql= "INSERT INTO PSM_COMPANY ([Cpny_Name1],[M_Adrs], " + 
									" [Tel1],[Fax],[TollFree],[Web],[Email],[Customer],[Supplier], " + 
									" [Manufacturer],[Cpny_Name2],[Cpny_Main],[Q_Adrs],[P_Adrs],[S_Adrs],[I_Adrs],[Tel2], " + 
									"[CustomerType],[TermID],[CreditLim],[Currency],[ShipVia_ID],[IncoTerm_ID], " +
                                    "[BLack_List],[BL_Cmnt],[BL_usr], " +
									"[City],[Province_State],[Country_Name],[actvId]) VALUES ('" +
									tCompanyName1.Text.Replace("'","''")   + "', '" + 	lMainAdrs.Text.Replace("'","''")    + "', '" + tTel1.Text    + "', '" +
									tFax.Text   + "', '" + tToll.Text + "', '" + tWeb.Text + "', '" +
									tEmail.Text + "', " + ((chkCust.Checked) ? 1:0)  + ", " + ((chkSupp.Checked) ? 1:0)   + ", " +  ((chkManufac.Checked) ? 1:0)  + ", '" +
									tCompanyName2.Text.Replace("'","''") + "', "    + lMainCpnyID.Text + ", '" + lQA.Text.Replace("'","''") + "', '" +
									lPA.Text.Replace("'","''") +  "', '"  +  lSA.Text.Replace("'","''") + "', '" + lIA.Text.Replace("'","''") + "', '" +
									tTel2.Text + "', " +	lcustmTp.Text + ", " + lTermsId.Text  + ", '" + tCreditLim.Text + "', '" +
                                    cbCurr.Text + "', " + lViaId.Text + ", " + lInTermId.Text + ", " +
                                    BL.ToString() + ", '" + BLCmnt.Replace("'", "''") + "', '" + BLusr + "', '" +
									"" + "', '" +"" + "', '" + "" + "', " + lActId.Text +")" ;
								MainMDI.ExecSql(stSql);
								MainMDI.Write_JFS(stSql );
								lupdate.Text ="S";
								
							}
							catch (SqlException Oexp)
							{
								MessageBox.Show("Adding Company INFO Error...= " + Oexp.Message );
							}
						}
						else MessageBox.Show("This Company Exists already...."); 
					}
					else 
					{

                            try
                            {
                                string stSql = "UPDATE PSM_COMPANY SET " +
                                    " [Cpny_Name1]='" + tCompanyName1.Text.Replace("'", "''") + "', " +
                                    " [M_Adrs]='" + lMainAdrs.Text.Replace("'", "''") + "', " +
                                    " [Tel1]='" + tTel1.Text + "', " +
                                    " [Fax]='" + tFax.Text + "', " +
                                    " [TollFree]='" + tToll.Text + "', " +
                                    " [Web]='" + tWeb.Text + "', " +
                                    " [Email]='" + tEmail.Text + "', " +
                                    " [Customer]=" + ((chkCust.Checked) ? 1 : 0) + ", " +
                                    " [Supplier]=" + ((chkSupp.Checked) ? 1 : 0) + ", " +
                                    " [Manufacturer]=" + ((chkManufac.Checked) ? 1 : 0) + ", " +
                                    " [Cpny_Name2]='" + tCompanyName2.Text.Replace("'", "''") + "', " +
                                    " [Cpny_Main]=" + lMainCpnyID.Text + ", " +
                                    " [Q_Adrs]='" + lQA.Text.Replace("'", "''") + "', " +
                                    " [P_Adrs]='" + lPA.Text.Replace("'", "''") + "', " +
                                    " [S_Adrs]='" + lSA.Text.Replace("'", "''") + "', " +
                                    " [I_Adrs]='" + lIA.Text.Replace("'", "''") + "', " +
                                    " [Tel2]='" + tTel2.Text + "', " +
                                    " [CustomerType]=" + lcustmTp.Text + ", " +
                                    " [TermID]=" + lTermsId.Text + ", " +
                                    " [CreditLim]='" + tCreditLim.Text.Replace("'", "''") + "', " +
                                    " [Currency]='" + cbCurr.Text.Replace("'", "''") + "', " +
                                    " [ShipVia_ID]=" + lViaId.Text + ", " +
                                    " [IncoTerm_ID]=" + lInTermId.Text + ", " +
                                    " [BLack_List]=" + BL.ToString() + ", " +
                                    " [BL_Cmnt]='" + BLCmnt.Replace("'", "''") + "', " +
                                    " [BL_usr]='" + BLusr + "', " +
                                    " [City]='" + "" + "', " +
                                    " [Province_State]='" + "" + "', " +
                                    " [Country_Name]='" + "" + "', " +
                                    " [actvId]=" + lActId.Text + " " +
                                    " WHERE [Cpny_ID]=" + tCompanyID.Text;
                                MainMDI.ExecSql(stSql);
                                MainMDI.Write_JFS(stSql);
                                btnOK.Text = "&Save";
                                lupdate.Text = "U";
                            }
                            catch (SqlException Oexp)
                            {
                                MessageBox.Show("Updating Company Error...= " + Oexp.Message);
                            }
					}
				}
				else MessageBox.Show ("You missed some data, [company Name] or [comment for Black_list]  "); 
				if (lupdate.Text !="E") this.Hide() ;
			}
			else {	lupdate.Text ="N";	this.Hide();}
		}
	

		private bool company_Exists(string _cpnyNme,string _cLID)
        {
          
            if (_cLID == "")
            {
                if (Int32.Parse(MainMDI.Find_One_Field("select count(*) from PSM_COMPANY where Cpny_Name1='" + _cpnyNme + "'")) == 0) return false;
            }
            else if (Int32.Parse(MainMDI.Find_One_Field("select count(*) from PSM_COMPANY where Cpny_Name1='" + _cpnyNme + "' and Cpny_ID <>" + _cLID )) == 0) return false;
       
            return true;
        }

        private bool company_Exists_SYSPROcode(string sysPcode)
        {

            return (MainMDI.Find_One_Field("select count(*) from PSM_COMPANY where Syspro_Code'" + sysPcode + "'") != MainMDI.VIDE);
          
           
        }


		private void btnComnt_Click(object sender, System.EventArgs e)
		{
			if (tComnt.Text !=""  ) 
			{ 
				try
				{
					string stSql= "INSERT INTO PSM_ALL_Cmnt([CTYP],[user], " + 
						" [ILID],[dateC],[cmnt]) VALUES ('C', '" +  
						MainMDI.User   + "', '" + 	tCompanyID.Text  + "', " + MainMDI.SSV_date(System.DateTime.Now.ToShortDateString())  + ", '" +
						tComnt.Text.Replace("'","''") + "')" ;
					MainMDI.ExecSql(stSql);

					lv_Cmnt(System.DateTime.Now.ToShortDateString() ,MainMDI.User ,tComnt.Text,"0");
					tComnt.Clear ();			
				}
				catch (SqlException Oexp)
				{
					MessageBox.Show("Adding Cpny Comment Error...= " + Oexp.Message );
				}
			}
						
		}

		private void cbMainCmpny_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lMainCpnyID.Text="0";
			if (cbMainCmpny.Text !="")
			{
				lMainCpnyID.Text = MainMDI.Find_One_Field("select Cpny_ID from PSM_COMPANY where Cpny_Name1='" + cbMainCmpny.Text + "'");  
				if (lMainCpnyID.Text   == MainMDI.VIDE ) lMainCpnyID.Text  = "0" ; 
			}
		
		}

		private void btnAQ_Click(object sender, System.EventArgs e)
		{
			QuoteXAdrs('Q',lQA.Text );
		}
		private void QuoteXAdrs(char c_adrs, string adrs)
		{
			dlgAdrs dAdrs = new dlgAdrs(adrs );
			//	dAdrs.chkSave.Visible=true;   
			dAdrs.ShowDialog(); 
			if (dAdrs.tStreet.Text   != ""  ) 
			{
				switch (c_adrs)
				{
					case 'Q':
						lQA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text  + "," + dAdrs.tZip.Text  + "," + dAdrs.cbCountry .Text     ;
						break;
					case 'S':
						lSA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text  + "," + dAdrs.tZip.Text  + "," + dAdrs.cbCountry .Text     ;
						break;
					case 'I':
						lIA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text  + "," + dAdrs.tZip.Text  + "," + dAdrs.cbCountry .Text     ;
						break;
					case 'P':
						lPA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text  + "," + dAdrs.tZip.Text  + "," + dAdrs.cbCountry .Text     ;
						break;
				}
			}
			

		}

		private void btnAP_Click(object sender, System.EventArgs e)
		{
			QuoteXAdrs('P',lPA.Text );
		
		}

		private void btnAS_Click(object sender, System.EventArgs e)
		{
			QuoteXAdrs('S',lSA.Text );
		}

		private void btnAI_Click(object sender, System.EventArgs e)
		{
			QuoteXAdrs('I',lIA.Text );
		}

		private void cbTerms_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lTermsId.Text = MainMDI.Find_One_Field("select InTermId from PSM_Terms where Descr='" + cbTerms.Text   + "'");  
			if (lTermsId.Text  == MainMDI.VIDE ) lTermsId.Text = "0" ; 
		}

		private void cbShipVia_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lViaId.Text = MainMDI.Find_One_Field("select ship_ID from PSM_ShipMeth where ShipEng='" + cbShipVia.Text   + "'");  
			if (lViaId.Text  == MainMDI.VIDE ) lViaId.Text = "0" ; 
		}

		private void cbIncoTerm_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lInTermId.Text = MainMDI.Find_One_Field("select IT_ID from PSM_IncoTerm where IT_DESC='" + cbIncoTerm.Text   + "'");  
			if (lInTermId.Text  == MainMDI.VIDE ) lInTermId.Text = "0" ; 
		
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{

			if ( tCompanyName1.Text.Length >2) 
			{
				Ges_Cont_Sal_Ag gCSA = new Ges_Cont_Sal_Ag('C');
			   
			//	Contacts  gCSA = new Contacts('C',"*",'C');
			//	gCSA.cbMainCmpny.Text =  tCompanyName1.Text ;
				gCSA.Add_CSA(tCompanyName1.Text); 
				//	      gCSA.(); 
				lvContact.Items.Clear(); 
				fill_contacts();
				//     ListViewItem lv=lvContact.Items.Add(gCSA.lFNLN.Text );
				//   lv.SubItems.Add( gCSA.lphn.Text); 
				// lv.SubItems.Add( gCSA.leml.Text); 
				//  lv.SubItems.Add( gCSA.lCLID.Text); 
				//  lv.SubItems.Add( "N"); 
			}
				     
		}

		private void fill_Cmnt()
		{
			if (tCompanyID.Text !="0")
			{
				string stSql = "select * FROM PSM_ALL_Cmnt where CTYP='C' and ILID=" + tCompanyID.Text  ;
				SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
				OConn.Open ();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql ;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();
				while (Oreadr.Read ())
					lv_Cmnt( Oreadr["dateC"].ToString(),Oreadr["user"].ToString(),Oreadr["cmnt"].ToString() ,Oreadr["cmnt_LID"].ToString() );
	
				OConn.Close(); 
			}
				 
		}
		
		private void lv_Cmnt(string d,string usr,string cmnt,string lid)
		{
			ListViewItem lvI= lvComment.Items.Add(d );
			lvI.SubItems.Add(usr  ); 
			lvI.SubItems.Add(cmnt  ); 
			lvI.SubItems.Add(lid  ); 
		}

		private void lvComment_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lvComment_DoubleClick(object sender, System.EventArgs e)
		{
			tComnt.Text =lvComment.SelectedItems[0].SubItems[2].Text ;
		//	LCLID.Text =lvComment.SelectedItems[0].SubItems[3].Text;
			tComnt.ReadOnly = true;
			btnComnt.Enabled  =false;
			pictureBox2.Enabled =false; 
		}

		private void pictureBox3_Click(object sender, System.EventArgs e)
		{
			tComnt.Clear(); 
			tComnt.ReadOnly =false;
			btnComnt.Enabled  =true;
		}

		private void pictureBox2_Click(object sender, System.EventArgs e)
		{
			if (lvComment.SelectedItems.Count ==1)
			{
				if (MainMDI.Confirm("Want to delete this Comment ?"))
				{
					MainMDI.ExecSql("delete PSM_ALL_Cmnt where CTYP='C' and cmnt_LID=" + lvComment.SelectedItems[0].SubItems[3].Text);
				    lvComment.Items[lvComment.SelectedItems[0].Index ].Remove();  
					btnComnt.Enabled  =true;
				}
			}
		}

		private void lvComment_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
			pictureBox2.Enabled =true; 
		}

		private void label19_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lbxCtype_SelectedIndexChanged(object sender, System.EventArgs e)
		{
            string st1 = "", st2 = "", st3 = "", st4 = "";
                lCtype.Text = lbxCtype.SelectedItem.ToString();
                MainMDI.Find_2_Field("select CpnyType_ID, multpl1,multpl1_US,multpl1_EURO from dbo.PSM_CmpnyTYPE where NorO='N' and CpnyType='" + lCtype.Text + "'", ref st1, ref st2, ref st3,ref st4);
                if (st1 != MainMDI.VIDE)
                {
                    lcustmTp.Text = st1;
                    canMlt.Text = st2;
                    USMlt.Text = st3;
                    EurMlt.Text = st4;
                }
                else MessageBox.Show("Activity is Invalid ....."); 
              
         //   }
		//	lCtype.Visible =true ;
		//	lbxCtype.Visible =false;
		//	lbxCtype.Visible =false;
		}

        private long XSP_NSRT_CmpnyTYPE(string _CpnyType, string _multpl1, string _multpl2, string _cfDesc)
        {
            string LID = "-1";
            string stXP = "";
            try
            {
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = new SqlCommand("NSRT_CmpnyTYPE", OConn);
                Ocmd.CommandType = CommandType.StoredProcedure;

                Ocmd.Parameters.AddWithValue ("@CpnyType", _CpnyType);
                Ocmd.Parameters.AddWithValue("@multpl1", _multpl1);
                Ocmd.Parameters.AddWithValue("@multpl2", _multpl2);
                Ocmd.Parameters.AddWithValue("@cfDesc", _cfDesc);
                  //  LID = Ocmd.exe;
                SqlDataReader rdr = Ocmd.ExecuteReader();
                while (rdr.Read()) LID = rdr[0].ToString();
                OConn.Close();
                stXP = MainMDI.VIDE;
                return Int64.Parse(LID);
            }
            catch (SqlException Oexp)
            {
                stXP = Oexp.Message;
                MessageBox.Show("XSP_NSRT_CmpnyTYPE \n" + "Msg= " + stXP);
                return -1;

            }
        }

        private void btn_tNCF_save_Click_with_update(object sender, EventArgs e)
        {
            long _lid=0;
            if (lctypeID.Text == "" && lbxCtype.Text == "NEW")
                _lid = XSP_NSRT_CmpnyTYPE(lNCF_Name.Text, tNCF_val.Text, "1", MainMDI.VIDE);
            else
            {
                if (lctypeID.Text != "")
                    // MainMDI.ExecSql("UPDATE PSM_CmpnyTYPE SET CpnyType ='" + lNCF_Name.Text + "', multpl1 =" + tNCF_val.Text + ", multpl1 = 1, cfDesc ='" + MainMDI.VIDE + "' WHERE CpnyType_ID =" + lctypeID.Text );
                    MainMDI.ExecSql("UPDATE PSM_CmpnyTYPE SET multpl1 =" + tNCF_val.Text + " WHERE CpnyType_ID =" + lctypeID.Text);
            }
            Fill_lbxCtype();
            grpCF.Visible = false;
        }
        private void btn_tNCF_save_Click(object sender, EventArgs e)
        {
            if (tNCF_val.Text != "" )
            {
                lNCF_Name.Text = lNCF_Name.Text.Replace(".", "-");
                lNCF_Name.Text = lNCF_Name.Text.Replace(",", "-");
                if (MainMDI.Find_One_Field("SELECT CpnyType_ID FROM PSM_CmpnyTYPE WHERE CpnyType ='" + lNCF_Name.Text +"'")==MainMDI.VIDE )
                {
                long _lid = _lid = XSP_NSRT_CmpnyTYPE(lNCF_Name.Text, tNCF_val.Text, "1", MainMDI.VIDE);
                Fill_lbxCtype();
                }
                else MessageBox.Show("Sorry this Markup already exists...."); 
            }
            grpCF.Visible = false;
        }
        private void Fill_lbxCtype()
        {
            //string stSql = "select  CpnyType FROM PSM_CmpnyTYPE ORDER BY multpl1 ";
            string stSql = "select  CpnyType FROM PSM_CmpnyTYPE ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            lbxCtype.Items.Clear();
        //    lbxCtype.Items.Add("NEW");
            while (Oreadr.Read()) 
            {
               lbxCtype.Items.Add(Oreadr[0].ToString());

            }
            OConn.Close();

        }

        private void btn_tNCF_cancel_Click(object sender, EventArgs e)
        {


            grpCF.Visible = false;
        }

        private void picNewcf_Click(object sender, EventArgs e)
        {
           grpCF.Visible = true;


        }

        private void btneditCF_Click(object sender, EventArgs e)
        {
            grpCF.Visible = true;
            tNCF_val.Text ="";
            lNCF_Name.Text = "";
            // for updating
         //   if (lbxCtype.Text != "")
        //    {
         //       string stSql="SELECT CpnyType_ID, CpnyType, multpl1 FROM PSM_CmpnyTYPE WHERE CpnyType ='" + lbxCtype.Text + "'"; 
         //       string[] starr=new string[6] ;
         //       MainMDI.Find_arr_Fields(stSql,starr);
         //       lctypeID.Text=starr[0];
         //       tNCF_val.Text =starr[2];
         //       lNCF_Name.Text = starr[1];
          //  }


        }

        private void tNCF_val_TextChanged(object sender, EventArgs e)
        {
          //  if (lbxCtype.Text == "NEW") 
                if (Tools.Conv_Dbl(tNCF_val.Text) > 0) lNCF_Name.Text = "CF" + tNCF_val.Text;
            
        }

        private void tNCF_val_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyDBL(e.KeyChar);
           
        }

        private void lNCF_Name_Click(object sender, EventArgs e)
        {

        }

        private void lbxCtype_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void lvContact_RightToLeftLayoutChanged(object sender, EventArgs e)
        {

        }

        private void chkSupp_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void lCtype_DoubleClick(object sender, EventArgs e)
        {
            lbxCtype.BringToFront();
        }

        private void picVcon_Click(object sender, EventArgs e)
        {

        }

        private void Sav__Click(object sender, EventArgs e)
        {
            btnOK_Click(sender, e);
        }

        private void Newcontact_Click(object sender, EventArgs e)
        {
            pictureBox1_Click(sender, e);
        }

        private void exiit_Click(object sender, EventArgs e)
        {
            btnCancel_Click(sender, e);
        }

        private void chkLN_CheckedChanged(object sender, EventArgs e)
        {
            if (ldone.Text !="Done by: " && ldone.Text.Length >0)    ldone.Visible = chkLN.Checked;
            txBL.BackColor = (chkLN.Checked) ? Color.Red : Color.White;
            
            //txBL.ReadOnly = !chkLN.Checked;
        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("CPN_SV", false))
            {
                if (!chkLN.Checked) chkLN.Checked = true;
            }
            else  MessageBox.Show("You are not allowed, contact Admin..... !!"); 
        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {
            if (MainMDI.User.ToLower() == "ede" || MainMDI.User.ToLower() == "hnasrat" || MainMDI.User.ToLower() == "mrouleau")
            {
                chkLN.Checked = false;
                txBL.Text = "";

            }
            else MessageBox.Show("You are not allowed, contact Admin..... !!"); 
        }



        private void MOVE_company_SYSPROCode_PGC_()
        {


            string stSql = "SELECT * FROM v_PGCustomerXRef order by Name";

            //      string stSql = "SELECT Name,Customer, ShortName FROM v_PGCustomerXRef where substring(Customer,LEN(Customer),1 ) in ( 'U', 'C', 'E') order by Name";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
         
            while (Oreadr.Read())
            {
                if (Oreadr["ShortName"].ToString() != "" )
                {
                    MainMDI.Exec_SQL_JFS("update dbo.PSM_COMPANY set [Syspro_Code]=" + Oreadr["Customer"].ToString() + " where Cpny_ID=" + Oreadr["ShortName"].ToString()," update SYSPRO code for companies..");
   
                }

            }
          
            OConn.Close();

        }



        private void SYNC_COMPNY_SYSP_PGC_()
        {


            string stSql = "SELECT * FROM v_PGCustomerXRef order by Name";

            //      string stSql = "SELECT Name,Customer, ShortName FROM v_PGCustomerXRef where substring(Customer,LEN(Customer),1 ) in ( 'U', 'C', 'E') order by Name";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                if (Oreadr["ShortName"].ToString() == "" && !company_Exists_SYSPROcode(Oreadr["Customer"].ToString()))
                {
                    string Adrs = Oreadr["SoldToAddr1"].ToString().TrimEnd() + Oreadr["SoldToAddr2"].ToString().TrimEnd() + Oreadr["SoldToAddr3"].ToString().TrimEnd() + "," + Oreadr["SoldToAddr4"].ToString().TrimEnd() + "," + Oreadr["SoldPostalCode"].ToString().TrimEnd() + "," + Oreadr["SoldToAddr5"].ToString().TrimEnd();
                    Save_NewCpny(Oreadr["Name"].ToString(), Adrs, Oreadr["Telephone"].ToString(), Oreadr["Fax"].ToString(), Oreadr["Customer"].ToString());
                }

            }

            OConn.Close();

        }





        private void Save_NewCpny(string tCpny_Name1,string lMainAdrs,string tTel1, string tFax,string SYSPRO_code)
        {


            string vide="";

                if (!company_Exists(tCompanyName1.Text.Replace("'", "''"), ""))
                {
                    try
                    {
                        //int ID= Convert.ToInt32(  MainMDI.Find_One_Field("Select Cpny_ID from PSM_COMPANY order by Cpny_ID DESC"));  
                        //	string stSql= "INSERT INTO PSM_COMPANY ([Cpny_ID],[Cpny_Name1],[M_Adrs], " + 
                        string stSql = "INSERT INTO PSM_COMPANY ([Cpny_Name1],[M_Adrs], " +
                            " [Tel1],[Fax],[TollFree],[Web],[Email],[Customer],[Supplier], " +
                            " [Manufacturer],[Cpny_Name2],[Cpny_Main],[Q_Adrs],[P_Adrs],[S_Adrs],[I_Adrs],[Tel2], " +
                            "[CustomerType],[TermID],[CreditLim],[Currency],[ShipVia_ID],[IncoTerm_ID], " +
                            "[BLack_List],[BL_Cmnt],[BL_usr], " +
                            "[City],[Province_State],[Country_Name],[actvId]) VALUES ('" +
                            tCpny_Name1.Replace("'", "''") + "', '" + lMainAdrs.Replace("'", "''") + "', '" + tTel1 + "', '" +
                            tFax + "', '" + vide + "', '" + vide + "', '" +
                            vide + "', " + "1" + ", " + "0" + ", " + "0" + ", '" +
                            vide.Replace("'", "''") + "', " + "0" + ", '" + vide + "', '" +
                            vide.Replace("'", "''") + "', '" + vide.Replace("'", "''") + "', '" + vide.Replace("'", "''") + "', '" +
                            vide + "', " + "0" + ", " + "0" + ", '" + "0" + "', '" +
                            vide + "', " + "0" + ", " + "0" + ", " +
                           "0" + ", '" + vide + "', '" + "0" + "', '" +
                            "" + "', '" + "" + "', '" + "" + "', " + "0" + ")";
                        MainMDI.Exec_SQL_JFS (stSql," New cpny from sysypro....");
 
                    }
                    catch (SqlException Oexp)
                    {
                        MessageBox.Show("Adding Company INFO from SYSPRO   failed......... Error...= " + Oexp.Message);
                    }
                }
                else MessageBox.Show("This Company Exists already....");
              
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox3_Enter(object sender, EventArgs e)
        {

        }

        private void TSmain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
	








	
	}
}
