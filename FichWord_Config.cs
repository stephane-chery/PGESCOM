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
	/// Summary description for pik_Option.
	/// </summary>
	public class FichWord_Config : System.Windows.Forms.Form
	{
		public bool NXT = false;
		private string in_IQID = "";
		private string in_Pterms = "", in_Delv = "", in_IncoT = "";
		private string in_sol_ID = "";
		private Lib1 Tools = new Lib1();
		private const int NB_PTC_Lines = 10;
		private string cRR = "CA$ ";

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnNext;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.CheckBox checkBox1;
		public System.Windows.Forms.TextBox tsubmit;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label lsubmit;
		private System.Windows.Forms.Label WFLID;
		public System.Windows.Forms.DateTimePicker tCQRdatea;
		public System.Windows.Forms.Label tCQRdate;
		private System.Windows.Forms.GroupBox groupBox4;
		public System.Windows.Forms.CheckBox chkbatCmnt;
		public System.Windows.Forms.CheckBox chkWFname;
		public System.Windows.Forms.CheckBox chkComptxt;
		private System.Windows.Forms.Label lSelI;
		private System.Windows.Forms.Label lWFLID;
		private System.Windows.Forms.GroupBox groupBox6;
		public System.Windows.Forms.TextBox tCompl;
		public System.Windows.Forms.TextBox tbatCmnt;
		public System.Windows.Forms.TextBox tCalBat;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox7;
		private System.Windows.Forms.GroupBox groupBox8;
		public System.Windows.Forms.ListView lvPTC;
		private System.Windows.Forms.ColumnHeader ColDesc;
		private System.Windows.Forms.ColumnHeader ColValueer1;
		private System.Windows.Forms.ColumnHeader qty;
		private System.Windows.Forms.ColumnHeader Tot;
		private System.Windows.Forms.GroupBox grpmodif;
		private System.Windows.Forms.ColumnHeader AGtot;
		private System.Windows.Forms.Button btnUpCancel;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox col3;
		private System.Windows.Forms.Button btnAdd;
		public System.Windows.Forms.TextBox col2;
		public System.Windows.Forms.TextBox col1;
        private System.Windows.Forms.CheckBox chkBoldox5;
		private System.Windows.Forms.ColumnHeader AGpu;
		private System.Windows.Forms.ColumnHeader AGqty;
		public System.Windows.Forms.CheckBox checkBox2;
		public System.Windows.Forms.TextBox tothers;
		private System.Windows.Forms.PictureBox picDefSTxtf;
		private System.Windows.Forms.Button picDefSTxt;
		private System.Windows.Forms.Button btndefO;
		private System.Windows.Forms.PictureBox picStdtxtd;
		private System.Windows.Forms.Button picStdtxt;
        private Button b_sad_other;
        private Button b_sad_sub;
        private Button b_sad_Compl;
        public TextBox tRectif_TXT;
        private GroupBox groupBox5;
        public CheckBox checkBox3;
        public CheckBox chkSendAG;
        public CheckBox chkAGP;
        public CheckBox chk_VQ;
        private Label label126;
        private ComboBox cbAG;
        private Label lAG_CodeName;
        public Label lAG_email;
        private ColumnHeader RASI;
        public PictureBox picCIP;
        public ListView lvUPS;
        private ColumnHeader crit;
        private ColumnHeader ind_grd;
        private ColumnHeader it_grd;
        public CheckBox chk_UPS;
        public CheckBox chk_sumry;
        private Button btnNewWF;
        public Label lNO;
        public CheckBox chk_ALT;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

		public FichWord_Config(string x_IQID, string x_solID, string x_Pterms, string x_incoT, string x_Ldlr, string PXXXX)
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();
			in_IQID = x_IQID;
			in_sol_ID = x_solID;
			in_Pterms = x_Pterms;
			in_IncoT = x_incoT;
			//in_Delv = x_Delv;
			cRR = x_Ldlr;

            string codeSP = MainMDI.Find_One_Field("SELECT c.Syspro_Code  FROM [Orig_PSM_FDB].[dbo].[PSM_Q_IGen] q inner join [dbo].[PSM_COMPANY] c on q.CPNY_ID=c.Cpny_ID  where q.i_Quoteid=" + in_IQID);
            if (codeSP != MainMDI.VIDE) fill_cbAGent_SYSPRO(codeSP.Substring(codeSP.Length - 1, 1) + "1");
            else MessageBox.Show("Customer SYSPRO CODE is Invalid.....contact Admin...");
			load_profile();
			if (tCompl.Text == "") fill_stdTEXT('P');
            if (tsubmit.Text == "") fill_stdTEXT('S'); if (PXXXX != "") tsubmit.Text.Replace("P4500", PXXXX);
			if (tothers.Text == "") fill_stdTEXT('O');
            if (tRectif_TXT.Text == "") fill_stdTEXT('R');
			fill_Config();
            bool tt = (MainMDI.profile == 'S' || MainMDI.User.ToLower() == "ede");
            b_sad_sub.Enabled = tt;
            b_sad_Compl.Enabled = tt;
            b_sad_other.Enabled = tt;

			//fill_stdTEXT();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FichWord_Config));
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "Input/output and battery circuit breakers",
            "Y",
            "N"}, -1);
            System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new string[] {
            "Input and output transformers for total galvanic isolation",
            "Y",
            "N"}, -1);
            System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new string[] {
            "Standard NEMA PE5 charger and 12hrs recharge time with no dc-dc converter to rech" +
                "arge batteries",
            "Y",
            "N"}, -1);
            System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new string[] {
            "Full STS: SCRs on both inverter and bypass line",
            "Y",
            "N"}, -1);
            System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new string[] {
            "Low volts dc bus with less cells in series for reduced maintenance (60 cells for " +
                "≤100kVA)",
            "Y",
            "N"}, -1);
            System.Windows.Forms.ListViewItem listViewItem6 = new System.Windows.Forms.ListViewItem(new string[] {
            "MBS: rotary MBB switch. Not contactors or interlocked breakers",
            "Y",
            "N"}, -1);
            System.Windows.Forms.ListViewItem listViewItem7 = new System.Windows.Forms.ListViewItem(new string[] {
            "Downstream protection device clearance up to 2.5-3x nominal current-10ms without " +
                "transferring to bypass",
            "Y",
            "N"}, -1);
            System.Windows.Forms.ListViewItem listViewItem8 = new System.Windows.Forms.ListViewItem(new string[] {
            "Black start capabilities",
            "Y",
            "N"}, -1);
            this.btnNext = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chk_ALT = new System.Windows.Forms.CheckBox();
            this.chk_sumry = new System.Windows.Forms.CheckBox();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.lAG_email = new System.Windows.Forms.Label();
            this.lAG_CodeName = new System.Windows.Forms.Label();
            this.label126 = new System.Windows.Forms.Label();
            this.cbAG = new System.Windows.Forms.ComboBox();
            this.chkAGP = new System.Windows.Forms.CheckBox();
            this.chk_VQ = new System.Windows.Forms.CheckBox();
            this.chkSendAG = new System.Windows.Forms.CheckBox();
            this.b_sad_sub = new System.Windows.Forms.Button();
            this.b_sad_other = new System.Windows.Forms.Button();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btndefO = new System.Windows.Forms.Button();
            this.picDefSTxt = new System.Windows.Forms.Button();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.tothers = new System.Windows.Forms.TextBox();
            this.picDefSTxtf = new System.Windows.Forms.PictureBox();
            this.tCQRdate = new System.Windows.Forms.Label();
            this.WFLID = new System.Windows.Forms.Label();
            this.lsubmit = new System.Windows.Forms.Label();
            this.tCQRdatea = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.tsubmit = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lvUPS = new System.Windows.Forms.ListView();
            this.crit = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ind_grd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.it_grd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.chk_UPS = new System.Windows.Forms.CheckBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.tRectif_TXT = new System.Windows.Forms.TextBox();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.tbatCmnt = new System.Windows.Forms.TextBox();
            this.tCalBat = new System.Windows.Forms.TextBox();
            this.tCompl = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.b_sad_Compl = new System.Windows.Forms.Button();
            this.picStdtxt = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.chkbatCmnt = new System.Windows.Forms.CheckBox();
            this.chkWFname = new System.Windows.Forms.CheckBox();
            this.chkComptxt = new System.Windows.Forms.CheckBox();
            this.picStdtxtd = new System.Windows.Forms.PictureBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox8 = new System.Windows.Forms.GroupBox();
            this.lvPTC = new System.Windows.Forms.ListView();
            this.ColDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ColValueer1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Tot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AGpu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AGqty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AGtot = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RASI = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox7 = new System.Windows.Forms.GroupBox();
            this.btnNewWF = new System.Windows.Forms.Button();
            this.grpmodif = new System.Windows.Forms.GroupBox();
            this.lNO = new System.Windows.Forms.Label();
            this.btnUpCancel = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnAdd = new System.Windows.Forms.Button();
            this.col2 = new System.Windows.Forms.TextBox();
            this.col1 = new System.Windows.Forms.TextBox();
            this.chkBoldox5 = new System.Windows.Forms.CheckBox();
            this.lSelI = new System.Windows.Forms.Label();
            this.lWFLID = new System.Windows.Forms.Label();
            this.col3 = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDefSTxtf)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox6.SuspendLayout();
            this.groupBox5.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picStdtxtd)).BeginInit();
            this.groupBox3.SuspendLayout();
            this.groupBox8.SuspendLayout();
            this.groupBox7.SuspendLayout();
            this.grpmodif.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnNext
            // 
            this.btnNext.BackColor = System.Drawing.Color.ForestGreen;
            this.btnNext.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNext.ForeColor = System.Drawing.Color.White;
            this.btnNext.Location = new System.Drawing.Point(738, 7);
            this.btnNext.Name = "btnNext";
            this.btnNext.Size = new System.Drawing.Size(115, 34);
            this.btnNext.TabIndex = 154;
            this.btnNext.Text = "Old word file";
            this.btnNext.UseVisualStyleBackColor = false;
            this.btnNext.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.ForestGreen;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(857, 7);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(82, 34);
            this.btnCancel.TabIndex = 153;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.ForestGreen;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.White;
            this.btnSave.Location = new System.Drawing.Point(498, 7);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(111, 34);
            this.btnSave.TabIndex = 174;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chk_ALT);
            this.groupBox1.Controls.Add(this.chk_sumry);
            this.groupBox1.Controls.Add(this.picCIP);
            this.groupBox1.Controls.Add(this.lAG_email);
            this.groupBox1.Controls.Add(this.lAG_CodeName);
            this.groupBox1.Controls.Add(this.label126);
            this.groupBox1.Controls.Add(this.cbAG);
            this.groupBox1.Controls.Add(this.chkAGP);
            this.groupBox1.Controls.Add(this.chk_VQ);
            this.groupBox1.Controls.Add(this.chkSendAG);
            this.groupBox1.Controls.Add(this.b_sad_sub);
            this.groupBox1.Controls.Add(this.b_sad_other);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btndefO);
            this.groupBox1.Controls.Add(this.picDefSTxt);
            this.groupBox1.Controls.Add(this.checkBox2);
            this.groupBox1.Controls.Add(this.tothers);
            this.groupBox1.Controls.Add(this.picDefSTxtf);
            this.groupBox1.Controls.Add(this.tCQRdate);
            this.groupBox1.Controls.Add(this.WFLID);
            this.groupBox1.Controls.Add(this.lsubmit);
            this.groupBox1.Controls.Add(this.tCQRdatea);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tsubmit);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1540, 211);
            this.groupBox1.TabIndex = 177;
            this.groupBox1.TabStop = false;
            // 
            // chk_ALT
            // 
            this.chk_ALT.BackColor = System.Drawing.SystemColors.Control;
            this.chk_ALT.Checked = true;
            this.chk_ALT.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ALT.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chk_ALT.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_ALT.ForeColor = System.Drawing.Color.Blue;
            this.chk_ALT.Location = new System.Drawing.Point(991, 31);
            this.chk_ALT.Name = "chk_ALT";
            this.chk_ALT.Size = new System.Drawing.Size(146, 24);
            this.chk_ALT.TabIndex = 266;
            this.chk_ALT.Text = "Print alternatives";
            this.chk_ALT.UseVisualStyleBackColor = false;
            // 
            // chk_sumry
            // 
            this.chk_sumry.BackColor = System.Drawing.SystemColors.Control;
            this.chk_sumry.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chk_sumry.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_sumry.ForeColor = System.Drawing.Color.Blue;
            this.chk_sumry.Location = new System.Drawing.Point(1182, 115);
            this.chk_sumry.Name = "chk_sumry";
            this.chk_sumry.Size = new System.Drawing.Size(171, 24);
            this.chk_sumry.TabIndex = 265;
            this.chk_sumry.Text = "summarize Detals";
            this.chk_sumry.UseVisualStyleBackColor = false;
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(1360, 8);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(57, 33);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 264;
            this.picCIP.TabStop = false;
            // 
            // lAG_email
            // 
            this.lAG_email.BackColor = System.Drawing.Color.LightBlue;
            this.lAG_email.Location = new System.Drawing.Point(1262, 71);
            this.lAG_email.Name = "lAG_email";
            this.lAG_email.Size = new System.Drawing.Size(216, 16);
            this.lAG_email.TabIndex = 229;
            // 
            // lAG_CodeName
            // 
            this.lAG_CodeName.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lAG_CodeName.Location = new System.Drawing.Point(1188, 52);
            this.lAG_CodeName.Name = "lAG_CodeName";
            this.lAG_CodeName.Size = new System.Drawing.Size(17, 16);
            this.lAG_CodeName.TabIndex = 228;
            this.lAG_CodeName.Visible = false;
            // 
            // label126
            // 
            this.label126.BackColor = System.Drawing.Color.Transparent;
            this.label126.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label126.ForeColor = System.Drawing.Color.MidnightBlue;
            this.label126.Location = new System.Drawing.Point(1153, 47);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(109, 21);
            this.label126.TabIndex = 226;
            this.label126.Text = "Agency";
            this.label126.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbAG
            // 
            this.cbAG.BackColor = System.Drawing.Color.LightBlue;
            this.cbAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAG.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbAG.Location = new System.Drawing.Point(1262, 47);
            this.cbAG.Name = "cbAG";
            this.cbAG.Size = new System.Drawing.Size(290, 21);
            this.cbAG.TabIndex = 227;
            this.cbAG.SelectedIndexChanged += new System.EventHandler(this.cbAG_SelectedIndexChanged);
            // 
            // chkAGP
            // 
            this.chkAGP.BackColor = System.Drawing.SystemColors.Control;
            this.chkAGP.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkAGP.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkAGP.ForeColor = System.Drawing.Color.Blue;
            this.chkAGP.Location = new System.Drawing.Point(1182, 146);
            this.chkAGP.Name = "chkAGP";
            this.chkAGP.Size = new System.Drawing.Size(171, 24);
            this.chkAGP.TabIndex = 225;
            this.chkAGP.Text = "Use Agent Price";
            this.chkAGP.UseVisualStyleBackColor = false;
            this.chkAGP.CheckedChanged += new System.EventHandler(this.chkAGP_CheckedChanged);
            // 
            // chk_VQ
            // 
            this.chk_VQ.BackColor = System.Drawing.SystemColors.Control;
            this.chk_VQ.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chk_VQ.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_VQ.ForeColor = System.Drawing.Color.Blue;
            this.chk_VQ.Location = new System.Drawing.Point(1182, 84);
            this.chk_VQ.Name = "chk_VQ";
            this.chk_VQ.Size = new System.Drawing.Size(311, 24);
            this.chk_VQ.TabIndex = 224;
            this.chk_VQ.Text = "Include ventilated quote / Excel file";
            this.chk_VQ.UseVisualStyleBackColor = false;
            this.chk_VQ.CheckedChanged += new System.EventHandler(this.chk_VQ_CheckedChanged);
            // 
            // chkSendAG
            // 
            this.chkSendAG.BackColor = System.Drawing.SystemColors.Control;
            this.chkSendAG.Checked = true;
            this.chkSendAG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSendAG.Enabled = false;
            this.chkSendAG.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSendAG.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSendAG.ForeColor = System.Drawing.Color.Blue;
            this.chkSendAG.Location = new System.Drawing.Point(1182, 20);
            this.chkSendAG.Name = "chkSendAG";
            this.chkSendAG.Size = new System.Drawing.Size(171, 24);
            this.chkSendAG.TabIndex = 223;
            this.chkSendAG.Text = "Sent mail to Agency";
            this.chkSendAG.UseVisualStyleBackColor = false;
            this.chkSendAG.CheckedChanged += new System.EventHandler(this.chkSendAG_CheckedChanged);
            // 
            // b_sad_sub
            // 
            this.b_sad_sub.Enabled = false;
            this.b_sad_sub.Location = new System.Drawing.Point(388, 12);
            this.b_sad_sub.Name = "b_sad_sub";
            this.b_sad_sub.Size = new System.Drawing.Size(84, 24);
            this.b_sad_sub.TabIndex = 222;
            this.b_sad_sub.Text = "Set as Default";
            this.b_sad_sub.Click += new System.EventHandler(this.b_sad_sub_Click);
            // 
            // b_sad_other
            // 
            this.b_sad_other.Enabled = false;
            this.b_sad_other.Location = new System.Drawing.Point(828, 12);
            this.b_sad_other.Name = "b_sad_other";
            this.b_sad_other.Size = new System.Drawing.Size(84, 24);
            this.b_sad_other.TabIndex = 221;
            this.b_sad_other.Text = "Set as Default";
            this.b_sad_other.Click += new System.EventHandler(this.b_sad_other_Click);
            // 
            // checkBox1
            // 
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox1.Location = new System.Drawing.Point(160, 18);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(152, 16);
            this.checkBox1.TabIndex = 168;
            this.checkBox1.Text = "Print Submit Text";
            this.checkBox1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btndefO
            // 
            this.btndefO.BackColor = System.Drawing.Color.SkyBlue;
            this.btndefO.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btndefO.Enabled = false;
            this.btndefO.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btndefO.Location = new System.Drawing.Point(512, 16);
            this.btndefO.Name = "btndefO";
            this.btndefO.Size = new System.Drawing.Size(80, 20);
            this.btndefO.TabIndex = 220;
            this.btndefO.Text = "Default text";
            this.btndefO.UseVisualStyleBackColor = false;
            this.btndefO.Click += new System.EventHandler(this.btndefO_Click);
            // 
            // picDefSTxt
            // 
            this.picDefSTxt.BackColor = System.Drawing.Color.SkyBlue;
            this.picDefSTxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDefSTxt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.picDefSTxt.ForeColor = System.Drawing.Color.Black;
            this.picDefSTxt.Location = new System.Drawing.Point(8, 16);
            this.picDefSTxt.Name = "picDefSTxt";
            this.picDefSTxt.Size = new System.Drawing.Size(72, 20);
            this.picDefSTxt.TabIndex = 219;
            this.picDefSTxt.Text = "Default text";
            this.picDefSTxt.UseVisualStyleBackColor = false;
            this.picDefSTxt.Click += new System.EventHandler(this.picDefSTxt_Click);
            // 
            // checkBox2
            // 
            this.checkBox2.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox2.Location = new System.Drawing.Point(617, 18);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(151, 16);
            this.checkBox2.TabIndex = 203;
            this.checkBox2.Text = "Print Other Text:";
            this.checkBox2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // tothers
            // 
            this.tothers.AcceptsReturn = true;
            this.tothers.BackColor = System.Drawing.Color.Lavender;
            this.tothers.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tothers.Enabled = false;
            this.tothers.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tothers.Location = new System.Drawing.Point(512, 36);
            this.tothers.MaxLength = 2000;
            this.tothers.Multiline = true;
            this.tothers.Name = "tothers";
            this.tothers.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tothers.Size = new System.Drawing.Size(465, 136);
            this.tothers.TabIndex = 202;
            // 
            // picDefSTxtf
            // 
            this.picDefSTxtf.BackColor = System.Drawing.Color.Transparent;
            this.picDefSTxtf.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDefSTxtf.Image = ((System.Drawing.Image)(resources.GetObject("picDefSTxtf.Image")));
            this.picDefSTxtf.Location = new System.Drawing.Point(777, 8);
            this.picDefSTxtf.Name = "picDefSTxtf";
            this.picDefSTxtf.Size = new System.Drawing.Size(46, 36);
            this.picDefSTxtf.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDefSTxtf.TabIndex = 200;
            this.picDefSTxtf.TabStop = false;
            this.picDefSTxtf.Visible = false;
            this.picDefSTxtf.Click += new System.EventHandler(this.picDefSTxt_Click);
            // 
            // tCQRdate
            // 
            this.tCQRdate.Location = new System.Drawing.Point(137, 8);
            this.tCQRdate.Name = "tCQRdate";
            this.tCQRdate.Size = new System.Drawing.Size(46, 16);
            this.tCQRdate.TabIndex = 186;
            this.tCQRdate.Visible = false;
            // 
            // WFLID
            // 
            this.WFLID.BackColor = System.Drawing.Color.CornflowerBlue;
            this.WFLID.Location = new System.Drawing.Point(360, 8);
            this.WFLID.Name = "WFLID";
            this.WFLID.Size = new System.Drawing.Size(23, 16);
            this.WFLID.TabIndex = 185;
            this.WFLID.Visible = false;
            // 
            // lsubmit
            // 
            this.lsubmit.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lsubmit.Location = new System.Drawing.Point(320, 8);
            this.lsubmit.Name = "lsubmit";
            this.lsubmit.Size = new System.Drawing.Size(17, 16);
            this.lsubmit.TabIndex = 184;
            this.lsubmit.Visible = false;
            // 
            // tCQRdatea
            // 
            this.tCQRdatea.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.tCQRdatea.CalendarTitleBackColor = System.Drawing.Color.Lavender;
            this.tCQRdatea.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.tCQRdatea.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.tCQRdatea.Location = new System.Drawing.Point(392, 16);
            this.tCQRdatea.Name = "tCQRdatea";
            this.tCQRdatea.Size = new System.Drawing.Size(80, 20);
            this.tCQRdatea.TabIndex = 170;
            this.tCQRdatea.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(17, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 16);
            this.label1.TabIndex = 169;
            this.label1.Text = "1st Page:";
            // 
            // tsubmit
            // 
            this.tsubmit.AcceptsReturn = true;
            this.tsubmit.BackColor = System.Drawing.Color.Lavender;
            this.tsubmit.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.tsubmit.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tsubmit.Location = new System.Drawing.Point(8, 36);
            this.tsubmit.MaxLength = 2000;
            this.tsubmit.Multiline = true;
            this.tsubmit.Name = "tsubmit";
            this.tsubmit.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tsubmit.Size = new System.Drawing.Size(495, 136);
            this.tsubmit.TabIndex = 167;
            this.tsubmit.TextChanged += new System.EventHandler(this.tsubmit_TextChanged_1);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lvUPS);
            this.groupBox2.Controls.Add(this.chk_UPS);
            this.groupBox2.Controls.Add(this.groupBox6);
            this.groupBox2.Controls.Add(this.groupBox4);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 211);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1540, 262);
            this.groupBox2.TabIndex = 178;
            this.groupBox2.TabStop = false;
            // 
            // lvUPS
            // 
            this.lvUPS.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvUPS.AutoArrange = false;
            this.lvUPS.BackColor = System.Drawing.Color.Azure;
            this.lvUPS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.crit,
            this.ind_grd,
            this.it_grd});
            this.lvUPS.Font = new System.Drawing.Font("Microsoft Tai Le", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvUPS.ForeColor = System.Drawing.Color.Red;
            this.lvUPS.FullRowSelect = true;
            this.lvUPS.GridLines = true;
            this.lvUPS.HideSelection = false;
            listViewItem1.StateImageIndex = 0;
            this.lvUPS.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1,
            listViewItem2,
            listViewItem3,
            listViewItem4,
            listViewItem5,
            listViewItem6,
            listViewItem7,
            listViewItem8});
            this.lvUPS.Location = new System.Drawing.Point(1033, 24);
            this.lvUPS.MultiSelect = false;
            this.lvUPS.Name = "lvUPS";
            this.lvUPS.Size = new System.Drawing.Size(509, 188);
            this.lvUPS.TabIndex = 185;
            this.lvUPS.UseCompatibleStateImageBehavior = false;
            this.lvUPS.View = System.Windows.Forms.View.Details;
            // 
            // crit
            // 
            this.crit.Text = "Criterium";
            this.crit.Width = 330;
            // 
            // ind_grd
            // 
            this.ind_grd.Text = "Industrial grad";
            this.ind_grd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ind_grd.Width = 107;
            // 
            // it_grd
            // 
            this.it_grd.Text = "IT grad";
            this.it_grd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.it_grd.Width = 50;
            // 
            // chk_UPS
            // 
            this.chk_UPS.BackColor = System.Drawing.Color.Transparent;
            this.chk_UPS.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk_UPS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_UPS.ForeColor = System.Drawing.Color.Red;
            this.chk_UPS.Location = new System.Drawing.Point(1033, 6);
            this.chk_UPS.Name = "chk_UPS";
            this.chk_UPS.Size = new System.Drawing.Size(104, 20);
            this.chk_UPS.TabIndex = 181;
            this.chk_UPS.Text = "UPS features";
            this.chk_UPS.UseVisualStyleBackColor = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.tRectif_TXT);
            this.groupBox6.Controls.Add(this.groupBox5);
            this.groupBox6.Controls.Add(this.tbatCmnt);
            this.groupBox6.Controls.Add(this.tCalBat);
            this.groupBox6.Controls.Add(this.tCompl);
            this.groupBox6.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox6.Location = new System.Drawing.Point(195, 16);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(794, 243);
            this.groupBox6.TabIndex = 179;
            this.groupBox6.TabStop = false;
            // 
            // tRectif_TXT
            // 
            this.tRectif_TXT.BackColor = System.Drawing.Color.Lavender;
            this.tRectif_TXT.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tRectif_TXT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tRectif_TXT.Location = new System.Drawing.Point(510, 16);
            this.tRectif_TXT.MaxLength = 200;
            this.tRectif_TXT.Multiline = true;
            this.tRectif_TXT.Name = "tRectif_TXT";
            this.tRectif_TXT.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tRectif_TXT.Size = new System.Drawing.Size(281, 224);
            this.tRectif_TXT.TabIndex = 180;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.checkBox3);
            this.groupBox5.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox5.Location = new System.Drawing.Point(412, 16);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(98, 224);
            this.groupBox5.TabIndex = 177;
            this.groupBox5.TabStop = false;
            // 
            // checkBox3
            // 
            this.checkBox3.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.checkBox3.Location = new System.Drawing.Point(10, 28);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(83, 92);
            this.checkBox3.TabIndex = 180;
            this.checkBox3.Text = "Rectifiers   Text     ";
            this.checkBox3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbatCmnt
            // 
            this.tbatCmnt.BackColor = System.Drawing.Color.Lavender;
            this.tbatCmnt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbatCmnt.Location = new System.Drawing.Point(588, 44);
            this.tbatCmnt.MaxLength = 200;
            this.tbatCmnt.Multiline = true;
            this.tbatCmnt.Name = "tbatCmnt";
            this.tbatCmnt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tbatCmnt.Size = new System.Drawing.Size(129, 32);
            this.tbatCmnt.TabIndex = 176;
            this.tbatCmnt.Visible = false;
            // 
            // tCalBat
            // 
            this.tCalBat.BackColor = System.Drawing.Color.Lavender;
            this.tCalBat.Enabled = false;
            this.tCalBat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tCalBat.Location = new System.Drawing.Point(588, 16);
            this.tCalBat.MaxLength = 200;
            this.tCalBat.Multiline = true;
            this.tCalBat.Name = "tCalBat";
            this.tCalBat.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tCalBat.Size = new System.Drawing.Size(129, 28);
            this.tCalBat.TabIndex = 175;
            this.tCalBat.Visible = false;
            // 
            // tCompl
            // 
            this.tCompl.AcceptsReturn = true;
            this.tCompl.AcceptsTab = true;
            this.tCompl.BackColor = System.Drawing.Color.Lavender;
            this.tCompl.Dock = System.Windows.Forms.DockStyle.Left;
            this.tCompl.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tCompl.Location = new System.Drawing.Point(3, 16);
            this.tCompl.MaxLength = 3000;
            this.tCompl.Multiline = true;
            this.tCompl.Name = "tCompl";
            this.tCompl.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tCompl.Size = new System.Drawing.Size(409, 224);
            this.tCompl.TabIndex = 172;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.b_sad_Compl);
            this.groupBox4.Controls.Add(this.picStdtxt);
            this.groupBox4.Controls.Add(this.label2);
            this.groupBox4.Controls.Add(this.chkbatCmnt);
            this.groupBox4.Controls.Add(this.chkWFname);
            this.groupBox4.Controls.Add(this.chkComptxt);
            this.groupBox4.Controls.Add(this.picStdtxtd);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox4.Location = new System.Drawing.Point(3, 16);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(192, 243);
            this.groupBox4.TabIndex = 178;
            this.groupBox4.TabStop = false;
            // 
            // b_sad_Compl
            // 
            this.b_sad_Compl.Enabled = false;
            this.b_sad_Compl.Location = new System.Drawing.Point(105, 144);
            this.b_sad_Compl.Name = "b_sad_Compl";
            this.b_sad_Compl.Size = new System.Drawing.Size(83, 24);
            this.b_sad_Compl.TabIndex = 222;
            this.b_sad_Compl.Text = "Set as Default";
            // 
            // picStdtxt
            // 
            this.picStdtxt.BackColor = System.Drawing.Color.SkyBlue;
            this.picStdtxt.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picStdtxt.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.picStdtxt.Location = new System.Drawing.Point(103, 16);
            this.picStdtxt.Name = "picStdtxt";
            this.picStdtxt.Size = new System.Drawing.Size(80, 20);
            this.picStdtxt.TabIndex = 220;
            this.picStdtxt.Text = "Default text";
            this.picStdtxt.UseVisualStyleBackColor = false;
            this.picStdtxt.Click += new System.EventHandler(this.picStdtxt_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Maroon;
            this.label2.Location = new System.Drawing.Point(8, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(129, 16);
            this.label2.TabIndex = 199;
            this.label2.Text = "Default Compliance";
            this.label2.Visible = false;
            this.label2.Click += new System.EventHandler(this.label2_Click);
            // 
            // chkbatCmnt
            // 
            this.chkbatCmnt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkbatCmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkbatCmnt.Location = new System.Drawing.Point(97, 192);
            this.chkbatCmnt.Name = "chkbatCmnt";
            this.chkbatCmnt.Size = new System.Drawing.Size(86, 16);
            this.chkbatCmnt.TabIndex = 181;
            this.chkbatCmnt.Text = "Comments";
            this.chkbatCmnt.Visible = false;
            // 
            // chkWFname
            // 
            this.chkWFname.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkWFname.Enabled = false;
            this.chkWFname.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkWFname.Location = new System.Drawing.Point(8, 104);
            this.chkWFname.Name = "chkWFname";
            this.chkWFname.Size = new System.Drawing.Size(175, 32);
            this.chkWFname.TabIndex = 180;
            this.chkWFname.Text = "          Insert   Battery  Sizing   ";
            this.chkWFname.Visible = false;
            // 
            // chkComptxt
            // 
            this.chkComptxt.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkComptxt.Checked = true;
            this.chkComptxt.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkComptxt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkComptxt.Location = new System.Drawing.Point(17, 56);
            this.chkComptxt.Name = "chkComptxt";
            this.chkComptxt.Size = new System.Drawing.Size(166, 20);
            this.chkComptxt.TabIndex = 179;
            this.chkComptxt.Text = "Print Compliance Text";
            this.chkComptxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkComptxt.CheckedChanged += new System.EventHandler(this.chkComptxt_CheckedChanged);
            // 
            // picStdtxtd
            // 
            this.picStdtxtd.BackColor = System.Drawing.Color.Transparent;
            this.picStdtxtd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picStdtxtd.Image = ((System.Drawing.Image)(resources.GetObject("picStdtxtd.Image")));
            this.picStdtxtd.Location = new System.Drawing.Point(72, 8);
            this.picStdtxtd.Name = "picStdtxtd";
            this.picStdtxtd.Size = new System.Drawing.Size(48, 36);
            this.picStdtxtd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picStdtxtd.TabIndex = 183;
            this.picStdtxtd.TabStop = false;
            this.picStdtxtd.Visible = false;
            this.picStdtxtd.Click += new System.EventHandler(this.picStdtxt_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.groupBox8);
            this.groupBox3.Controls.Add(this.groupBox7);
            this.groupBox3.Controls.Add(this.grpmodif);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 473);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1540, 182);
            this.groupBox3.TabIndex = 179;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Prices, Terms and Conditions Page";
            // 
            // groupBox8
            // 
            this.groupBox8.Controls.Add(this.lvPTC);
            this.groupBox8.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox8.Location = new System.Drawing.Point(3, 80);
            this.groupBox8.Name = "groupBox8";
            this.groupBox8.Size = new System.Drawing.Size(1534, 36);
            this.groupBox8.TabIndex = 185;
            this.groupBox8.TabStop = false;
            // 
            // lvPTC
            // 
            this.lvPTC.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvPTC.AutoArrange = false;
            this.lvPTC.BackColor = System.Drawing.Color.PowderBlue;
            this.lvPTC.CheckBoxes = true;
            this.lvPTC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ColDesc,
            this.ColValueer1,
            this.qty,
            this.Tot,
            this.AGpu,
            this.AGqty,
            this.AGtot,
            this.RASI});
            this.lvPTC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPTC.FullRowSelect = true;
            this.lvPTC.GridLines = true;
            this.lvPTC.HideSelection = false;
            this.lvPTC.Location = new System.Drawing.Point(3, 16);
            this.lvPTC.MultiSelect = false;
            this.lvPTC.Name = "lvPTC";
            this.lvPTC.Size = new System.Drawing.Size(1528, 17);
            this.lvPTC.TabIndex = 184;
            this.lvPTC.UseCompatibleStateImageBehavior = false;
            this.lvPTC.View = System.Windows.Forms.View.Details;
            this.lvPTC.SelectedIndexChanged += new System.EventHandler(this.lvPTC_SelectedIndexChanged_2);
            this.lvPTC.DoubleClick += new System.EventHandler(this.lvPTC_DoubleClick);
            // 
            // ColDesc
            // 
            this.ColDesc.Text = "Description";
            this.ColDesc.Width = 611;
            // 
            // ColValueer1
            // 
            this.ColValueer1.Text = "Price        ";
            this.ColValueer1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ColValueer1.Width = 200;
            // 
            // qty
            // 
            this.qty.Text = "Qty";
            this.qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Tot
            // 
            this.Tot.Text = "Primax Total              ";
            this.Tot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Tot.Width = 125;
            // 
            // AGpu
            // 
            this.AGpu.Text = "Price   ";
            this.AGpu.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AGpu.Width = 0;
            // 
            // AGqty
            // 
            this.AGqty.Text = "Qty";
            this.AGqty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.AGqty.Width = 0;
            // 
            // AGtot
            // 
            this.AGtot.Text = "Agent Total";
            this.AGtot.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.AGtot.Width = 0;
            // 
            // RASI
            // 
            this.RASI.Text = "LT";
            this.RASI.Width = 0;
            // 
            // groupBox7
            // 
            this.groupBox7.Controls.Add(this.btnNewWF);
            this.groupBox7.Controls.Add(this.btnSave);
            this.groupBox7.Controls.Add(this.btnCancel);
            this.groupBox7.Controls.Add(this.btnNext);
            this.groupBox7.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox7.Location = new System.Drawing.Point(3, 116);
            this.groupBox7.Name = "groupBox7";
            this.groupBox7.Size = new System.Drawing.Size(1534, 63);
            this.groupBox7.TabIndex = 184;
            this.groupBox7.TabStop = false;
            // 
            // btnNewWF
            // 
            this.btnNewWF.BackColor = System.Drawing.Color.ForestGreen;
            this.btnNewWF.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewWF.ForeColor = System.Drawing.Color.White;
            this.btnNewWF.Location = new System.Drawing.Point(612, 7);
            this.btnNewWF.Name = "btnNewWF";
            this.btnNewWF.Size = new System.Drawing.Size(120, 34);
            this.btnNewWF.TabIndex = 175;
            this.btnNewWF.Text = "Next";
            this.btnNewWF.UseVisualStyleBackColor = false;
            this.btnNewWF.Click += new System.EventHandler(this.btnNewWF_Click);
            // 
            // grpmodif
            // 
            this.grpmodif.BackColor = System.Drawing.Color.BlanchedAlmond;
            this.grpmodif.Controls.Add(this.lNO);
            this.grpmodif.Controls.Add(this.btnUpCancel);
            this.grpmodif.Controls.Add(this.label6);
            this.grpmodif.Controls.Add(this.label5);
            this.grpmodif.Controls.Add(this.label4);
            this.grpmodif.Controls.Add(this.btnAdd);
            this.grpmodif.Controls.Add(this.col2);
            this.grpmodif.Controls.Add(this.col1);
            this.grpmodif.Controls.Add(this.chkBoldox5);
            this.grpmodif.Controls.Add(this.lSelI);
            this.grpmodif.Controls.Add(this.lWFLID);
            this.grpmodif.Controls.Add(this.col3);
            this.grpmodif.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpmodif.Location = new System.Drawing.Point(3, 16);
            this.grpmodif.Name = "grpmodif";
            this.grpmodif.Size = new System.Drawing.Size(1534, 64);
            this.grpmodif.TabIndex = 182;
            this.grpmodif.TabStop = false;
            this.grpmodif.Visible = false;
            // 
            // lNO
            // 
            this.lNO.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lNO.Location = new System.Drawing.Point(685, 15);
            this.lNO.Name = "lNO";
            this.lNO.Size = new System.Drawing.Size(16, 17);
            this.lNO.TabIndex = 219;
            this.lNO.Text = "N";
            this.lNO.Visible = false;
            // 
            // btnUpCancel
            // 
            this.btnUpCancel.Location = new System.Drawing.Point(807, 30);
            this.btnUpCancel.Name = "btnUpCancel";
            this.btnUpCancel.Size = new System.Drawing.Size(80, 24);
            this.btnUpCancel.TabIndex = 218;
            this.btnUpCancel.Text = "Cancel";
            this.btnUpCancel.Click += new System.EventHandler(this.btnUpCancel_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Maroon;
            this.label6.Location = new System.Drawing.Point(583, 16);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(74, 16);
            this.label6.TabIndex = 217;
            this.label6.Text = "Total";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Maroon;
            this.label5.Location = new System.Drawing.Point(440, 16);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 216;
            this.label5.Text = "Price";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Maroon;
            this.label4.Location = new System.Drawing.Point(208, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(95, 16);
            this.label4.TabIndex = 215;
            this.label4.Text = "Description";
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(717, 30);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(83, 24);
            this.btnAdd.TabIndex = 213;
            this.btnAdd.Text = "Add";
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // col2
            // 
            this.col2.BackColor = System.Drawing.Color.Lavender;
            this.col2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.col2.Location = new System.Drawing.Point(417, 32);
            this.col2.MaxLength = 49;
            this.col2.Name = "col2";
            this.col2.Size = new System.Drawing.Size(120, 20);
            this.col2.TabIndex = 212;
            this.col2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.col2.TextChanged += new System.EventHandler(this.col2_TextChanged);
            // 
            // col1
            // 
            this.col1.BackColor = System.Drawing.Color.Lavender;
            this.col1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.col1.Location = new System.Drawing.Point(8, 32);
            this.col1.MaxLength = 49;
            this.col1.Name = "col1";
            this.col1.Size = new System.Drawing.Size(409, 20);
            this.col1.TabIndex = 211;
            this.col1.TextChanged += new System.EventHandler(this.col1_TextChanged);
            // 
            // chkBoldox5
            // 
            this.chkBoldox5.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkBoldox5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkBoldox5.Location = new System.Drawing.Point(817, 16);
            this.chkBoldox5.Name = "chkBoldox5";
            this.chkBoldox5.Size = new System.Drawing.Size(46, 16);
            this.chkBoldox5.TabIndex = 210;
            this.chkBoldox5.Text = "Bold";
            this.chkBoldox5.Visible = false;
            // 
            // lSelI
            // 
            this.lSelI.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lSelI.Location = new System.Drawing.Point(897, 16);
            this.lSelI.Name = "lSelI";
            this.lSelI.Size = new System.Drawing.Size(15, 16);
            this.lSelI.TabIndex = 196;
            this.lSelI.Visible = false;
            // 
            // lWFLID
            // 
            this.lWFLID.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lWFLID.Location = new System.Drawing.Point(897, 40);
            this.lWFLID.Name = "lWFLID";
            this.lWFLID.Size = new System.Drawing.Size(15, 16);
            this.lWFLID.TabIndex = 195;
            this.lWFLID.Visible = false;
            // 
            // col3
            // 
            this.col3.BackColor = System.Drawing.Color.Lavender;
            this.col3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.col3.Location = new System.Drawing.Point(537, 32);
            this.col3.MaxLength = 49;
            this.col3.Name = "col3";
            this.col3.Size = new System.Drawing.Size(135, 20);
            this.col3.TabIndex = 214;
            this.col3.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // FichWord_Config
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1540, 655);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimizeBox = false;
            this.Name = "FichWord_Config";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quote Word File Configuration";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Closing += new System.ComponentModel.CancelEventHandler(this.FichWord_Config_Closing);
            this.Load += new System.EventHandler(this.FichWord_Config_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDefSTxtf)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox6.ResumeLayout(false);
            this.groupBox6.PerformLayout();
            this.groupBox5.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picStdtxtd)).EndInit();
            this.groupBox3.ResumeLayout(false);
            this.groupBox8.ResumeLayout(false);
            this.groupBox7.ResumeLayout(false);
            this.grpmodif.ResumeLayout(false);
            this.grpmodif.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		/*
		private void fill_ConfigOLD()
		{
			string stSql = "select * from PSM_Q_WConfig where IQID=" + in_IQID + " and Sol_LID=" + in_sol_ID;
			SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			lWFLID.Text = "";
			while (Oreadr.Read())
			{
				lWFLID.Text = Oreadr["WFLID"].ToString();
				tsubmit.Text = Oreadr["tsubmit"].ToString();
				tCompl.Text = Oreadr["tCompl"].ToString();
				tCalBat.Text = Oreadr["TComp-Fname"].ToString(); //+ "\r\n";
				tbatCmnt.Text = Oreadr["tbatCmnt"].ToString();
				if (Oreadr["TPTC-1"].ToString() != "")
				{
					for (int i = 0; i < NB_PTC_Lines; i++)
					{
						string st = Oreadr[i + 7].ToString();
						if (st != "")
						{
							int ipos = st.IndexOf("~~", 0);
							if (ipos != -1)
							{
								ListViewItem lvI = lvPTC.Items.Add(st.Substring(0, ipos));
								lvI.SubItems.Add(st.Substring(ipos + 2, st.Length - ipos - 2));
							}
							else 
							{							
								ListViewItem lvI = lvPTC.Items.Add(st);
								lvI.SubItems.Add("");
							}
						}
						else break;
					}
				}
			}
			OConn.Close();
			if (lWFLID.Text =="") fill_stdTEXT();
		}
		*/

		private void load_profile()
		{
			string stSql = "select * from PSM_Q_WConfig where IQID=" + in_IQID + " and Sol_LID=" + in_sol_ID;
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			lWFLID.Text = "";

            chkSendAG.Checked = true;

			while (Oreadr.Read())
			{
				lWFLID.Text = Oreadr["WFLID"].ToString();
				tsubmit.Text = Oreadr["tsubmit"].ToString().Replace("~~", "\r\n");
				tCompl.Text = Oreadr["tCompl"].ToString();
                tothers.Text = Oreadr["othertxt"].ToString();

                //check it after
                //chkSendAG.Checked = (Oreadr["chkAG"].ToString() == "1");

                cbAG.Text = Oreadr["agent"].ToString();
                if (Oreadr["agent"].ToString().Length > 4) load_AGemail(); //lAG_CodeName.Text = (cbAG.Text.Length > 3) ? cbAG.Text.Substring(0, 3) : "";

				//tCalBat.Text = Oreadr["TComp-Fname"].ToString(); //+ "\r\n";
				//tbatCmnt.Text = Oreadr["tbatCmnt"].ToString();
			}
			OConn.Close();
		}

		private void fill_Config()
		{
			string stt = "";
			//string stSql = "select * from PSM_Q_WConfig where IQID=" + in_IQID + " and Sol_LID=" + in_sol_ID;
            string stSql = " SELECT PSM_Q_IGen.i_Quoteid, PSM_Q_SOL.Sol_Name,PSM_Q_SOL.date_Rev, PSM_Q_SPCS.SPC_Name, PSM_Q_SPCS.SPC_LID, PSM_Q_ALS.ALS_Name, PSM_Q_ALS.ALS_LID, PSM_Q_ALS.PxPrice, PSM_Q_ALS.AGPrice,PSM_Q_ALS.AlsQty, PSM_Q_Details.[Desc], PSM_Q_Details.Ext ,PSM_Q_Details.Qty,PSM_Q_Details.Uprice,PSM_Q_Details.Mult  " +
                " FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID         " +
                " WHERE (((PSM_Q_IGen.i_Quoteid)=" + in_IQID + ") AND ((PSM_Q_SOL.Sol_LID)=" + in_sol_ID + ") AND ((PSM_Q_Details.Ext)<>0)) ORDER BY PSM_Q_SPCS.Rnk, PSM_Q_ALS.ALS_LID, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
            //string cRR = in_Ldlr;
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			lWFLID.Text = "";
			int SolNDX = -1;
			double SolTOT = 0;
			string OSoln = "", OAlsn = "", OSpcn = "", stName = "", stVal = "";
            //string NSoln = "", NAlsn = "", NSpcn = "";
			addLVO(" ", MainMDI.arr_EFSdict[35, MainMDI.Lang] + " " + cRR, " QTY ", "  Total " + cRR, true, MainMDI.arr_EFSdict[35, MainMDI.Lang] + " " + cRR, " QTY ", "  Total " + cRR, ' '); //cRR: curency CAD$
			while (Oreadr.Read())
			{
                if (Oreadr["Sol_Name"].ToString() != OSoln)
                {
                    tCQRdate.Text = (Oreadr["date_Rev"].ToString() == "") ? tCQRdatea.Value.ToShortDateString() : Oreadr["date_Rev"].ToString().Substring(0, 10);
                    addLVO(Oreadr["Sol_Name"].ToString(), "", "1", "", false, "", "", "", 'R'); //Rev print is unchecked Oreadr["Sol_Name"].ToString()
                    SolNDX = lvPTC.Items.Count - 1;
                    OSoln = Oreadr["Sol_Name"].ToString();
                }
                if (Oreadr["SPC_Name"].ToString() != OSpcn)
				{
					stt = MainMDI.Curr_FRMT(MainMDI.SPEC_TOT(in_IQID, Oreadr["Sol_Name"].ToString(), Oreadr["SPC_Name"].ToString()));
					addLVO(Oreadr["SPC_Name"].ToString(), stt.PadLeft(15), stt.PadLeft(15), false); //first was true
					stVal = MainMDI.SPEC_TOT(in_IQID, Oreadr["Sol_Name"].ToString(), Oreadr["SPC_Name"].ToString());
					SolTOT += Tools.Conv_Dbl(stVal);
	    		}
				if (Oreadr["ALS_Name"].ToString() != OAlsn || Oreadr["SPC_Name"].ToString() != OSpcn)
				{
					stt = MainMDI.Curr_FRMT(Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["PxPrice"].ToString()), MainMDI.Q_NB_DEC_AFF)));
			        string AGstt = MainMDI.Curr_FRMT(Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["AGPrice"].ToString()), MainMDI.Q_NB_DEC_AFF)));
					double d_qty = Tools.Conv_Dbl(Oreadr["AlsQty"].ToString());
								
					double ddu = Tools.Conv_Dbl(Oreadr["PxPrice"].ToString()) / d_qty;
					string sttU = MainMDI.Curr_FRMT(Convert.ToString(Math.Round(ddu, MainMDI.Q_NB_DEC_AFF)));

					double d_AGup = Tools.Conv_Dbl(Oreadr["AGPrice"].ToString()) / d_qty;
					string AGsttU = MainMDI.Curr_FRMT(Convert.ToString(Math.Round(d_AGup, MainMDI.Q_NB_DEC_AFF)));

					addLVO(Oreadr["ALS_Name"].ToString(), sttU.PadLeft(15), Oreadr["AlsQty"].ToString(), stt.PadLeft(15), true, AGsttU.PadLeft(15), Oreadr["AlsQty"].ToString(), AGstt.PadLeft(15), 'S');
					OAlsn = Oreadr["ALS_Name"].ToString();
				}

                OSpcn = Oreadr["SPC_Name"].ToString();
                string stUP = MainMDI.Curr_FRMT(Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["Uprice"].ToString()) * Tools.Conv_Dbl(Oreadr["Mult"].ToString()), MainMDI.Q_NB_DEC_AFF)));
				string stEXT = MainMDI.Curr_FRMT(Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["Ext"].ToString()), MainMDI.Q_NB_DEC_AFF)));
				string qty = Oreadr["Qty"].ToString();

                //stop printing details
				addLVO(Oreadr["Desc"].ToString(), stUP.PadLeft(15), qty, stEXT.PadLeft(15), false, stUP.PadLeft(15), qty, stEXT.PadLeft(15), 'I');
            }
			if (SolNDX != -1)
			{
				stt = MainMDI.Curr_FRMT(Convert.ToString(Math.Round(SolTOT, MainMDI.Q_NB_DEC_AFF)));
				lvPTC.Items[SolNDX ].SubItems[1].Text = stt.PadLeft(15);
				lvPTC.Items[SolNDX ].SubItems[3].Text = stt.PadLeft(15);
				lvPTC.Items[SolNDX ].SubItems[4].Text = stt.PadLeft(15);
				lvPTC.Items[SolNDX ].SubItems[6].Text = stt.PadLeft(15);
			}

            Add_More();
            Add_Terms();
			OConn.Close();
			//if (lWFLID.Text == "") fill_stdTEXT();
		}

        /*
		private void fill_Config_310706()
		{
			string stt = "";
			//string stSql = "select * from PSM_Q_WConfig where IQID=" + in_IQID + " and Sol_LID=" + in_sol_ID;
			string stSql = " SELECT PSM_Q_IGen.i_Quoteid, PSM_Q_SOL.Sol_Name,PSM_Q_SOL.date_Rev, PSM_Q_SPCS.SPC_Name, PSM_Q_SPCS.SPC_LID, PSM_Q_ALS.ALS_Name, PSM_Q_ALS.ALS_LID, PSM_Q_ALS.Tot, PSM_Q_Details.[Desc], PSM_Q_Details.Ext ,PSM_Q_Details.Qty,PSM_Q_Details.Uprice,PSM_Q_Details.Mult  " +
				" FROM ((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN (PSM_Q_ALS INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID) ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID         " +
				" WHERE (((PSM_Q_IGen.i_Quoteid)=" + in_IQID + ") AND ((PSM_Q_SOL.Sol_LID)=" + in_sol_ID + ") AND ((PSM_Q_Details.Ext)<>0)) ORDER BY PSM_Q_SPCS.Rnk, PSM_Q_ALS.Rnk, PSM_Q_Details.Rnk";
			//string cRR = in_Ldlr;
			SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			lWFLID.Text = "";
			int SolNDX = -1;
			double SolTOT = 0;
			string OSoln = "", OAlsn = "", OSpcn = "", stName = "", stVal = "";
			//string NSoln = "", NAlsn = "", NSpcn = "";
			addLVO(" ", MainMDI.arr_EFSdict[35, MainMDI.Lang] + " " + cRR, "  Total " + cRR, true);
			while (Oreadr.Read())
			{
				//NSoln = Oreadr["Sol_Name"].ToString();
				//NSpcn = Oreadr["SPC_Name"].ToString();
				//NAlsn = Oreadr["ALS_Name"].ToString();
				if (Oreadr["Sol_Name"].ToString() != OSoln)
				{
					tCQRdate.Text = (Oreadr["date_Rev"].ToString() == "") ? tCQRdatea.Value.ToShortDateString() : Oreadr["date_Rev"].ToString().Substring(0, 10);
					addLVO(Oreadr["Sol_Name"].ToString(), "", "", false); //first was true
					SolNDX = lvPTC.Items.Count - 1;
					OSoln = Oreadr["Sol_Name"].ToString();
				}
				if (Oreadr["SPC_Name"].ToString() != OSpcn)
				{
					stt = MainMDI.Curr_FRMT(SPEC_TOT(in_IQID, Oreadr["Sol_Name"].ToString(), Oreadr["SPC_Name"].ToString()));
					
					addLVO(Oreadr["SPC_Name"].ToString(), stt.PadLeft(15), stt.PadLeft(15), false); //first was true
					//stName=Oreadr["SPC_Name"].ToString();
					stVal = SPEC_TOT(in_IQID, Oreadr["Sol_Name"].ToString(), Oreadr["SPC_Name"].ToString());
					SolTOT += Tools.Conv_Dbl(stVal);
					//OSpcn = Oreadr["SPC_Name"].ToString();
				}
				if (Oreadr["ALS_Name"].ToString() != OAlsn || Oreadr["SPC_Name"].ToString() != OSpcn)
				{
					stt = MainMDI.Curr_FRMT(Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["Tot"].ToString()), MainMDI.Q_NB_DEC_AFF)));
					addLVO(Oreadr["ALS_Name"].ToString(), stt.PadLeft(15), stt.PadLeft(15), true);
					OAlsn = Oreadr["ALS_Name"].ToString();
				}
				OSpcn = Oreadr["SPC_Name"].ToString();
				string stUP = MainMDI.Curr_FRMT(Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["Uprice"].ToString()) * Tools.Conv_Dbl(Oreadr["Mult"].ToString()), MainMDI.Q_NB_DEC_AFF)));
				string stEXT = MainMDI.Curr_FRMT(Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["Ext"].ToString()), MainMDI.Q_NB_DEC_AFF)));
				string qty = Oreadr["Qty"].ToString();
				addLVO(qty + " x " + Oreadr["Desc"].ToString(), stUP.PadLeft(15), stEXT.PadLeft(15), false);
			}
			if (SolNDX != -1)
			{
				stt = MainMDI.Curr_FRMT(Convert.ToString(Math.Round(SolTOT, MainMDI.Q_NB_DEC_AFF)));
				lvPTC.Items[SolNDX].SubItems[1].Text = stt.PadLeft(15); lvPTC.Items[SolNDX].SubItems[2].Text = stt.PadLeft(15);
			}
			Add_Terms();
			OConn.Close();
			//if (lWFLID.Text == "") fill_stdTEXT();
		}
        */

		/*
		private void Add_Termsolds()
		{
			addLVO("!", "!", true);
			addLVO("!", "!", true);
			string stTerms = (in_Pterms == "" || in_Pterms == MainMDI.VIDE) ? MainMDI.arr_EFSdict[22, MainMDI.Lang] : in_Pterms;
			addLVO(MainMDI.arr_EFSdict[28, MainMDI.Lang], stTerms, true);
			addLVO(MainMDI.arr_EFSdict[26, MainMDI.Lang], MainMDI.arr_EFSdict[23, MainMDI.Lang], true);
			addLVO(MainMDI.arr_EFSdict[25, MainMDI.Lang], MainMDI.arr_EFSdict[29, MainMDI.Lang], true);
			addLVO(MainMDI.arr_EFSdict[30, MainMDI.Lang], HigDelv() + " " + MainMDI.arr_EFSdict[24, MainMDI.Lang], true);
			addLVO(MainMDI.arr_EFSdict[27, MainMDI.Lang], MainMDI.arr_EFSdict[1, MainMDI.Lang], true);
		}
		*/

        private void Add_More()
        {
            addLVO(MainMDI.arr_EFSdict[41, MainMDI.Lang], "999999", "999999", false);
            addLVO(MainMDI.arr_EFSdict[42, MainMDI.Lang], "999999", "999999", false);
        }

		private void Add_Terms()
		{
            //18032020 corona alert
            addLVO("!", "!", "!", true);
            //addLVO(MainMDI.arr_EFSdict[51, MainMDI.Lang], " ", " ", true);

            //18032020

            addLVO("!", "!", "!", true);
			addLVO("!", "!", "!", true);
			string stTerms = (in_Pterms == "" || in_Pterms == MainMDI.VIDE) ? MainMDI.arr_EFSdict[22, MainMDI.Lang] : in_Pterms;
            //Si la langue est en FR, alors changer la valeur en FR
            //Permet de changer la valeur en fonction de la langue
            if (stTerms == "To Be Determined" && MainMDI.Lang == 1) stTerms = "À déterminer";
			addLVO(MainMDI.arr_EFSdict[28, MainMDI.Lang], stTerms, " ", true);
			addLVO(MainMDI.arr_EFSdict[26, MainMDI.Lang], MainMDI.arr_EFSdict[23, MainMDI.Lang], " ", true);
			//addLVO(MainMDI.arr_EFSdict[25, MainMDI.Lang], MainMDI.arr_EFSdict[29, MainMDI.Lang], " ", true);
            addLVO(MainMDI.arr_EFSdict[45, MainMDI.Lang], MainMDI.arr_EFSdict[47, MainMDI.Lang], " ", true);
            addLVO(MainMDI.arr_EFSdict[46, MainMDI.Lang], MainMDI.arr_EFSdict[48, MainMDI.Lang], " ", true);
			addLVO(MainMDI.arr_EFSdict[30, MainMDI.Lang], HigDelv() + " " + MainMDI.arr_EFSdict[24, MainMDI.Lang], " ", true);
			addLVO(MainMDI.arr_EFSdict[27, MainMDI.Lang], MainMDI.arr_EFSdict[1, MainMDI.Lang], " ", true);
            addLVO(MainMDI.arr_EFSdict[40, MainMDI.Lang], " ", " ", true);
            addLVO(MainMDI.arr_EFSdict[44, MainMDI.Lang], " ", " ", true);
            //addLVO(MainMDI.arr_EFSdict[45, MainMDI.Lang], " ", " ", true);
            //addLVO(MainMDI.arr_EFSdict[46, MainMDI.Lang], " ", " ", true);
		}

		private string HigDelv()
		{
            //????? Q#=9353
	        //string stSql = "SELECT PSM_Q_Details.LeadTime FROM (((PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID) INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID " +
                //" WHERE (((PSM_Q_IGen.i_Quoteid)=" + in_IQID + ") AND ((PSM_Q_SOL.Sol_LID)=" + in_sol_ID + ")) ORDER BY PSM_Q_Details.LeadTime DESC ";
		    string stSql = " SELECT     PSM_Q_Details.LeadTime FROM         PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid INNER JOIN " +
                "           PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID INNER JOIN PSM_Q_Details ON PSM_Q_ALS.ALS_LID = PSM_Q_Details.ALS_LID " +
                " WHERE     (PSM_Q_IGen.i_Quoteid = " + in_IQID + ") AND (PSM_Q_SOL.Sol_LID = " + in_sol_ID + ") " +
                " ORDER BY SUBSTRING(PSM_Q_Details.LeadTime, 4, 2) DESC, SUBSTRING(PSM_Q_Details.LeadTime, 1, 2) DESC ";
			
			string res = MainMDI.Find_One_Field(stSql);
			if (res == MainMDI.VIDE || res == "4" || res == "" || res.IndexOf("-") == -1) return "04-06";
			else return Convert.ToInt32(res.Substring(0, 2)) + "-" + Convert.ToInt32(res.Substring(3, 2));
		}

		private void addLVO(string stName, string stval, string qty, string stTOT, bool disp, string AGstval, string AGqty, string AGstTOT, char typLine)
		{
            //if (disp)
            //{
            ListViewItem lvI = lvPTC.Items.Add(stName);
            lvI.SubItems.Add(stval);
            lvI.SubItems.Add(qty);
            lvI.SubItems.Add(stTOT);
            lvI.SubItems.Add(AGstval);
            lvI.SubItems.Add(AGqty);
            lvI.SubItems.Add(AGstTOT);
            lvI.SubItems.Add(typLine.ToString());
            lvI.Checked = disp;
            //}
		}

        private void addLVO(string stName, string stval, string stTOT, bool disp)
		{
			ListViewItem lvI = lvPTC.Items.Add(stName);
			lvI.SubItems.Add(stval);
			lvI.SubItems.Add("");
			lvI.SubItems.Add(stTOT);
			lvI.SubItems.Add(stval);
			lvI.SubItems.Add("");
			lvI.SubItems.Add(stTOT);
            lvI.SubItems.Add(" ");
			lvI.Checked = disp;
		}

		/*
	    private string SPEC_TOT(string r_IQID, string Sname, string SpecName)
        {
	        string stSql = "SELECT Sum(PSM_Q_ALS.Tot) AS SommeDeTot FROM (PSM_Q_SOL INNER JOIN PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID) INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
	            " GROUP BY PSM_Q_SOL.I_Quoteid, PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name HAVING (((PSM_Q_SOL.I_Quoteid)=" + r_IQID + ") AND ((PSM_Q_SOL.Sol_Name)='" + Sname + "') AND ((PSM_Q_SPCS.SPC_Name)='" + SpecName + "'))";
	        string res = MainMDI.Find_One_Field(stSql);
	        if (res == MainMDI.VIDE) return "0";
	        return Convert.ToString(Math.Round(Tools.Conv_Dbl(res), MainMDI.Q_NB_DEC_AFF));
        }
        */

		private void fill_stdTEXT(char SorC)
		{
			//string stSql = "select * from PSM_STDFEATURES where ItemCode='" + PC + "' order by rnk";
		    //string stSql = "select * from PSM_ALLSTD where (ItemCode='P' OR ItemCode='S' OR ItemCode='O') and disp=1 order by ItemCode, rnk ";
			string stSql = "select * from PSM_ALLSTD where ItemCode='" + SorC.ToString() + "' and disp=1 order by ItemCode, rnk ";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			if (SorC == 'P') tCompl.Text = "";
			if (SorC == 'S') tsubmit.Text = "";
			if (SorC == 'O') tothers.Text = "";
			SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
			{
				//if (Oreadr["ItemCode"].ToString()[0] == SorC)
				//{
				switch (SorC)
				{
					case 'P':
						tCompl.Text += Oreadr[MainMDI.Lang + 2].ToString() + "\r\n";
						break;
				    case 'S':
						tsubmit.Text += Oreadr[MainMDI.Lang + 2].ToString() + "\r\n";
						break;
				    case 'O':
						tothers.Text += Oreadr[MainMDI.Lang + 2].ToString() + "\r\n";
						break;
                    case 'R':
                        tRectif_TXT.Text += Oreadr[MainMDI.Lang + 2].ToString() + "\r\n";
                        break;
				}
				//}
				//tCompl.Text += (Oreadr["ItemCode"].ToString() == 'P') ? Oreadr[MainMDI.Lang + 2].ToString() + "\r\n" : Oreadr[MainMDI.Lang + 2].ToString() + "\r\n";
			}
			OConn.Close();
			tbatCmnt.Text = ""; //"The charger capacity has been calculated to recharge a fully discharged battery in less than 10 hours";
			tCalBat.Text = "";
			//tsubmit.Text = ""; //1. P4500F-1-125-5 Battery charger" + "\r\n" + "  2. TP18 Nickel-Cadmium Battery";
		}

        private void FichWord_Config_Load(object sender, System.EventArgs e)
        {
            if (MainMDI.ALWD_USR("QT_SV", true))
            {
                lAG_CodeName.Text = MainMDI.VIDE;
                if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
                chkComptxt.Focus();
                picCIP.Visible = !chkSendAG.Checked;
                this.btnNext.Visible = false;
                this.btnCancel.Location = new Point(857, 7);
                this.btnSave.Location = new Point(612, 7);
                this.btnNewWF.Location = new Point(738, 7);
            }
            else
            {
                NXT = false;
                this.Hide();
            }
        }

        bool valid_email(string email)
        {
            if (email.Length < 3) return false;
            if (email.IndexOf("@") > -1 && email.IndexOf(".") > -1) return true;
            else return false;
        }

		private void btnOK_Click(object sender, System.EventArgs e)
		{
            //MessageBox.Show(tCompl.Text);
            lNO.Text = "O";
            if (chkSendAG.Checked)
            {
                if (valid_email(lAG_email.Text))
                {
                    NXT = true;
                    save_ConfigW();
                    this.Hide();
                }
                else if (!MainMDI.Confirm("Agency email is Invalid \n You want to add new email ????"))
                {
                    chkSendAG.Checked = false;
                    NXT = true;
                    this.Hide();
                }
            }
            else
            {
                NXT = true;
                this.Hide();
            }
		}

		private void tsubmit_TextChanged(object sender, System.EventArgs e)
		{
			 
		}

		private void tCompl_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			
		}

		private void tCompl_TextChanged(object sender, System.EventArgs e)
		{
			chkComptxt.Checked = (tCompl.Text.Length > 5);
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			if (btnAdd.Text != "Update")
			{
				ListViewItem lvI = lvPTC.Items.Add(col1.Text);
				lvI.SubItems.Add(col2.Text);
				grpmodif.Visible = false;
			}
			else
			{
				lvPTC.Enabled = true;
				lvPTC.Items[Convert.ToInt32(lSelI.Text)].SubItems[0].Text = col1.Text;
				lvPTC.Items[Convert.ToInt32(lSelI.Text)].SubItems[1].Text = col2.Text;
				lvPTC.Items[Convert.ToInt32(lSelI.Text)].SubItems[3].Text = col3.Text;
                btnSave_Click(sender, e);
				btnAdd.Text = "Add";
			}
		}

		private void col1_TextChanged(object sender, System.EventArgs e)
		{
			btnAdd.Enabled = (col1.Text != "" && col2.Text != "");
		}

		private void col2_TextChanged(object sender, System.EventArgs e)
		{
			btnAdd.Enabled = (col1.Text != "" && col2.Text != "");
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
            save_ConfigW();
		}

        void save_ConfigW()
        {
            string[] arr_t = new string[NB_PTC_Lines];
            string sendemail = "1"; //(chkSendAG.Checked) ? "1" : "0";
            MainMDI.ExecSql("delete PSM_Q_WConfig where IQID=" + in_IQID + " and Sol_LID=" + in_sol_ID);
            lsubmit.Text = (tsubmit.Text != "") ? tsubmit.Text.Replace("\r\n", "~~") : "";
            string stSql = "INSERT INTO PSM_Q_WConfig ([IQID],[Sol_LID], " +
                " [tsubmit],[tCompl],[TComp-Fname], " +
                " [TbatCmnt]," +
                " [othertxt]," +
                " [agent]," +
                " [chkAG]," +
                " [dateSOL]) VALUES ('" +
                in_IQID + "', '" +
                in_sol_ID + "', '" +
                lsubmit.Text.Replace("'", "''") + "', '" +
                tCompl.Text.Replace("'", "''") + "', '" +
                tCalBat.Text + "', '" +
                tbatCmnt.Text.Replace("'", "''") + "', '" +
                tothers.Text.Replace("'", "''") + "', '" +
                lAG_CodeName.Text.Replace("'", "''") + "', '" +
                sendemail + "', " +
                MainMDI.SSV_date(tCQRdate.Text) + ")";

            MainMDI.Exec_SQL_JFS(stSql, stSql);

            //MainMDI.Write_JFS(stSql);
            //MainMDI.ExecSql(stSql);
        }

		private void btnSave_Clickold(object sender, System.EventArgs e)
		{
			string[] arr_t = new string[NB_PTC_Lines];

			MainMDI.ExecSql("delete PSM_Q_WConfig where IQID=" + in_IQID + " and Sol_LID=" + in_sol_ID);
			for (int i = 0; i < NB_PTC_Lines; i++) arr_t[i] = "";
			for (int i = 0; i < lvPTC.Items.Count && i < NB_PTC_Lines; i++)
				arr_t[i] = lvPTC.Items[i].SubItems[0].Text + "~~" + lvPTC.Items[i].SubItems[1].Text;
			lsubmit.Text = (tsubmit.Text != "") ? tsubmit.Text.Replace("\r\n", "~~") : "";
			string stSql = "INSERT INTO PSM_Q_WConfig ([IQID],[Sol_LID], " + 
				" [tsubmit],[tCompl],[TComp-Fname], " + 
				" [TbatCmnt],[TPTC-1],[TPTC-2], " + 
				" [TPTC-3],[TPTC-4],[TPTC-5], " + 
				" [TPTC-6],[TPTC-7],[TPTC-8], " + 
				" [TPTC-9], [TPTC-10]) VALUES ('" +
				in_IQID + "', '" +
				in_sol_ID + "', '" +
				lsubmit.Text + "', '" +
				tCompl.Text + "', '" +
				tCalBat.Text + "', '" +
				tbatCmnt.Text + "', '" +
				arr_t[0] + "', '" +
				arr_t[1] + "', '" +
				arr_t[2] + "', '" +
				arr_t[3] + "', '" +
				arr_t[4] + "', '" +
				arr_t[5] + "', '" +
				arr_t[6] + "', '" +
				arr_t[7] + "', '" +
				arr_t[8] + "', '" +
				arr_t[9] + "')";
			MainMDI.ExecSql(stSql);
		}

		private void lvPTC_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lvPTC_DoubleClick(object sender, System.EventArgs e)
		{
		    col1.Text = lvPTC.SelectedItems[0].SubItems[0].Text;
		    col2.Text = lvPTC.SelectedItems[0].SubItems[1].Text;
		    col3.Text = lvPTC.SelectedItems[0].SubItems[3].Text;
            btnAdd.Text = "Update";
            lSelI.Text = lvPTC.SelectedItems[0].Index.ToString();
			lvPTC.Enabled = false;
			grpmodif.Visible = true;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			NXT = false;
			this.Hide();
		}

		private void FichWord_Config_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			e.Cancel = true;
        }

		private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
		{
			tsubmit.Enabled = checkBox1.Checked;
		}

		private void lvPTC_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
		
		}

		private void btnDefaultCmp_Click(object sender, System.EventArgs e)
		{

		}

		private void btnUpCancel_Click(object sender, System.EventArgs e)
		{
			lvPTC.Enabled = true;
			btnAdd.Text = "Add";
			col1.Clear();
			col2.Clear();
			col3.Clear();
			grpmodif.Visible = false;

        }

		private void picStdtxt_Click(object sender, System.EventArgs e)
		{
			tCompl.Text ="";
			fill_stdTEXT('P');
		}

		private void label2_Click(object sender, System.EventArgs e)
		{
		    picStdtxt_Click(sender, e);
		}

		private void chkAGP_CheckedChanged(object sender, System.EventArgs e)
		{
			lvPTC.Columns[1].Width = (chkAGP.Checked) ? 0 : 200;
			lvPTC.Columns[2].Width = (chkAGP.Checked) ? 0 : 60;
			lvPTC.Columns[3].Width = (chkAGP.Checked) ? 0 : 125;

			lvPTC.Columns[4].Width = (chkAGP.Checked) ? 200 : 0;
			lvPTC.Columns[5].Width = (chkAGP.Checked) ? 60 : 0;
			lvPTC.Columns[6].Width = (chkAGP.Checked) ? 125 : 0;
		}

		private void lvPTC_SelectedIndexChanged_2(object sender, System.EventArgs e)
		{
		
		}

		private void picDefSTxt_Click(object sender, System.EventArgs e)
		{
			tsubmit.Text = "";
			fill_stdTEXT('S');
		}

		private void checkBox2_CheckedChanged(object sender, System.EventArgs e)
		{
			tothers.Enabled = checkBox2.Checked;
			btndefO.Enabled = checkBox2.Checked;
		}

		private void btndefO_Click(object sender, System.EventArgs e)
		{
			tothers.Text = "";
			fill_stdTEXT('O');
		}

		private void chkComptxt_CheckedChanged(object sender, System.EventArgs e)
		{
			tCompl.Enabled = chkComptxt.Checked;
		}

        private void b_sad_sub_Click(object sender, EventArgs e)
        {

        }

        private void tsubmit_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void b_sad_other_Click(object sender, EventArgs e)
        {

        }

        private void chk_VQ_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        //##########
        private void fill_cbAGent_SYSPROOLD(string branch)
        {
            string stSql = "SELECT distinct Salesperson, Name FROM  dbo.SalSalesperson where SUBSTRING (Salesperson,1,1)='A' and Branch ='" + branch + "1' order by Name ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                stSql = Oreadr["Salesperson"].ToString() + " - " + Oreadr["Name"].ToString(); //no last name for agency..... //+ " " + Oreadr[1].ToString();
                string actif = MainMDI.Find_One_Field("select actif from SalSalesperson where Salesperson='" + Oreadr["Salesperson"].ToString() + "' and Branch='" + branch + "'");
                if (actif == "1") cbAG.Items.Add(stSql);
            }
            OConn.Close();
        }

        private void fill_cbAGent_SYSPRO(string branch)
        {
            if (branch == "C1" || branch == "U1")
            {
                string stSql = "SELECT distinct Salesperson, Name FROM  dbo.SalSalesperson where SUBSTRING (Salesperson,1,1)='A' and Branch ='" + branch + "' and actif='1'  order by Name ";
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                while (Oreadr.Read())
                {
                    stSql = Oreadr["Salesperson"].ToString() + " - " + Oreadr["Name"].ToString(); //no last name for agency..... //+ " " + Oreadr[1].ToString();
                    cbAG.Items.Add(stSql);

                    //string actif = MainMDI.Find_One_Field("select actif from SalSalesperson where Salesperson='" + Oreadr["Salesperson"].ToString() + "' and Branch='" + branch + "'");
                    //if (actif == "1") cbAG.Items.Add(stSql);
                }
                OConn.Close();
            }
            else if (branch != "E1") MessageBox.Show("Customer SYSPRO CODE is Invalid.....contact Admin...branch");
        }

        private void chkSendAG_CheckedChanged(object sender, EventArgs e)
        {
            cbAG.Enabled = chkSendAG.Checked;
            picCIP.Visible = !chkSendAG.Checked;
            //btnSave.Enabled = true;
            //btnNext.Enabled = true;
        }

        private void btnNewWF_Click(object sender, EventArgs e)
        {
            lNO.Text = "N";
            chkSendAG.Checked = false;
            NXT = true;
            this.Hide();

            //lNO.Text = "N";
            //if (chkSendAG.Checked)
            //{
                //if (valid_email(lAG_email.Text))
                //{
                    //NXT = true;
                    //save_ConfigW();
                    //this.Hide();
                //}
                //else if (!MainMDI.Confirm("Agency email is Invalid \n You want to add new email ????"))
                //{
                    //chkSendAG.Checked = false;
                    //NXT = true;
                    //this.Hide();
                //}
            //}
            //else
            //{
                //NXT = true;
                //this.Hide();
            //}
        }

        private void cbAG_SelectedIndexChanged(object sender, EventArgs e)
        {
            load_AGemail();
        }

        void load_AGemail()
        {
            if (chkSendAG.Checked)
            {
                lAG_CodeName.Text = cbAG.Text;
                string codAG = (lAG_CodeName.Text.Length < 4) ? "n/a" : lAG_CodeName.Text.Substring(0, 3);
                string email = MainMDI.Find_One_Field("select email from SalSalesperson where Salesperson='" + codAG + "'");
                lAG_email.Text = email;
                if (email == MainMDI.VIDE || email == "")
                {
                    MessageBox.Show("No email assigned to this Agencie.....\nplease provide an email or Uncheck <Sent mail to Agency>.........");
                    //btnSave.Enabled = false;
                    //btnNext.Enabled = false;
                }
            }
        }
	}
}