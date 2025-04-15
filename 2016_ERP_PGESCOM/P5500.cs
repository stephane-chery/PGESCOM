using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data ;
using System.Data.OleDb ;  
using System.Data.SqlClient ;
using EAHLibs;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for importRxx.
	/// </summary>
	public class P5500 : System.Windows.Forms.Form
	{
		 private static Lib1 Tools = new Lib1();
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnImport;
		public System.Windows.Forms.ListView lvP5500;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.ColumnHeader columnHeader17;
		public System.Windows.Forms.Label lsave;
		private System.Windows.Forms.ColumnHeader columnHeader18;
		private System.Windows.Forms.ColumnHeader STKNB;
		private System.Windows.Forms.ColumnHeader chk;
		public System.Windows.Forms.ComboBox cb3PHS;
		public System.Windows.Forms.ComboBox cbInternal;
		public System.Windows.Forms.ComboBox cbPLC;
		public System.Windows.Forms.ComboBox cbAux;
		public System.Windows.Forms.ComboBox cbHeat;
		public System.Windows.Forms.ComboBox cbInput;
		public System.Windows.Forms.ComboBox cbEnc;
		public System.Windows.Forms.TextBox tApp;
		public System.Windows.Forms.TextBox ttermalP;
		private System.Windows.Forms.ColumnHeader price;
		public System.Windows.Forms.Label lRecModel;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox tIExt;
		private System.Windows.Forms.Label label34;
		public System.Windows.Forms.TextBox tILT;
		private System.Windows.Forms.Label label36;
		public System.Windows.Forms.TextBox tSMRK;
		private System.Windows.Forms.Label label38;
		public System.Windows.Forms.TextBox tIQty;
		private System.Windows.Forms.Label label42;
		public System.Windows.Forms.TextBox tIPU;
		public System.Windows.Forms.CheckBox chktermalP;
		public System.Windows.Forms.CheckBox chkApp;
		public System.Windows.Forms.CheckBox chk3PHS;
		public System.Windows.Forms.CheckBox chkinternal;
		public System.Windows.Forms.CheckBox chkplc;
		public System.Windows.Forms.CheckBox chkAux;
		public System.Windows.Forms.CheckBox chkheat;
		public System.Windows.Forms.CheckBox chkInput;
		public System.Windows.Forms.CheckBox chkEnc;
        private ColumnHeader app;
        private Label label1;
        public TextBox tapplication;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public P5500()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			fill_lvP5500();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P5500));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tapplication = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tIExt = new System.Windows.Forms.TextBox();
            this.label34 = new System.Windows.Forms.Label();
            this.tILT = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.tSMRK = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.tIQty = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.tIPU = new System.Windows.Forms.TextBox();
            this.lRecModel = new System.Windows.Forms.Label();
            this.ttermalP = new System.Windows.Forms.TextBox();
            this.chktermalP = new System.Windows.Forms.CheckBox();
            this.lsave = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.tApp = new System.Windows.Forms.TextBox();
            this.chkApp = new System.Windows.Forms.CheckBox();
            this.chk3PHS = new System.Windows.Forms.CheckBox();
            this.chkinternal = new System.Windows.Forms.CheckBox();
            this.chkplc = new System.Windows.Forms.CheckBox();
            this.chkAux = new System.Windows.Forms.CheckBox();
            this.chkheat = new System.Windows.Forms.CheckBox();
            this.chkInput = new System.Windows.Forms.CheckBox();
            this.chkEnc = new System.Windows.Forms.CheckBox();
            this.cb3PHS = new System.Windows.Forms.ComboBox();
            this.cbInternal = new System.Windows.Forms.ComboBox();
            this.cbPLC = new System.Windows.Forms.ComboBox();
            this.cbAux = new System.Windows.Forms.ComboBox();
            this.cbHeat = new System.Windows.Forms.ComboBox();
            this.cbInput = new System.Windows.Forms.ComboBox();
            this.cbEnc = new System.Windows.Forms.ComboBox();
            this.lvP5500 = new System.Windows.Forms.ListView();
            this.chk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.STKNB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.app = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tapplication);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lRecModel);
            this.groupBox1.Controls.Add(this.ttermalP);
            this.groupBox1.Controls.Add(this.chktermalP);
            this.groupBox1.Controls.Add(this.lsave);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnImport);
            this.groupBox1.Controls.Add(this.tApp);
            this.groupBox1.Controls.Add(this.chkApp);
            this.groupBox1.Controls.Add(this.chk3PHS);
            this.groupBox1.Controls.Add(this.chkinternal);
            this.groupBox1.Controls.Add(this.chkplc);
            this.groupBox1.Controls.Add(this.chkAux);
            this.groupBox1.Controls.Add(this.chkheat);
            this.groupBox1.Controls.Add(this.chkInput);
            this.groupBox1.Controls.Add(this.chkEnc);
            this.groupBox1.Controls.Add(this.cb3PHS);
            this.groupBox1.Controls.Add(this.cbInternal);
            this.groupBox1.Controls.Add(this.cbPLC);
            this.groupBox1.Controls.Add(this.cbAux);
            this.groupBox1.Controls.Add(this.cbHeat);
            this.groupBox1.Controls.Add(this.cbInput);
            this.groupBox1.Controls.Add(this.cbEnc);
            this.groupBox1.Controls.Add(this.lvP5500);
            this.groupBox1.Location = new System.Drawing.Point(8, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(888, 493);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(368, 238);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 197;
            this.label1.Text = "Application";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tapplication
            // 
            this.tapplication.BackColor = System.Drawing.SystemColors.Control;
            this.tapplication.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tapplication.ForeColor = System.Drawing.Color.Red;
            this.tapplication.Location = new System.Drawing.Point(336, 257);
            this.tapplication.MaxLength = 8;
            this.tapplication.Name = "tapplication";
            this.tapplication.ReadOnly = true;
            this.tapplication.Size = new System.Drawing.Size(136, 26);
            this.tapplication.TabIndex = 184;
            this.tapplication.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.tIExt);
            this.groupBox2.Controls.Add(this.label34);
            this.groupBox2.Controls.Add(this.tILT);
            this.groupBox2.Controls.Add(this.label36);
            this.groupBox2.Controls.Add(this.tSMRK);
            this.groupBox2.Controls.Add(this.label38);
            this.groupBox2.Controls.Add(this.tIQty);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.tIPU);
            this.groupBox2.Location = new System.Drawing.Point(320, 376);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(408, 72);
            this.groupBox2.TabIndex = 183;
            this.groupBox2.TabStop = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(240, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 16);
            this.label4.TabIndex = 202;
            this.label4.Text = "Sell Price:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tIExt
            // 
            this.tIExt.BackColor = System.Drawing.Color.Lavender;
            this.tIExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIExt.ForeColor = System.Drawing.Color.Red;
            this.tIExt.Location = new System.Drawing.Point(216, 32);
            this.tIExt.MaxLength = 49;
            this.tIExt.Multiline = true;
            this.tIExt.Name = "tIExt";
            this.tIExt.ReadOnly = true;
            this.tIExt.Size = new System.Drawing.Size(128, 24);
            this.tIExt.TabIndex = 201;
            this.tIExt.Text = "0";
            this.tIExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tIExt.TextChanged += new System.EventHandler(this.tIExt_TextChanged);
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.SystemColors.Control;
            this.label34.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(336, 16);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(64, 16);
            this.label34.TabIndex = 200;
            this.label34.Text = "Lead Time:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tILT
            // 
            this.tILT.BackColor = System.Drawing.Color.Lavender;
            this.tILT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tILT.ForeColor = System.Drawing.Color.Red;
            this.tILT.Location = new System.Drawing.Point(344, 32);
            this.tILT.MaxLength = 49;
            this.tILT.Multiline = true;
            this.tILT.Name = "tILT";
            this.tILT.Size = new System.Drawing.Size(56, 24);
            this.tILT.TabIndex = 195;
            this.tILT.Text = "04-06";
            this.tILT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.SystemColors.Control;
            this.label36.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label36.Location = new System.Drawing.Point(160, 16);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(64, 16);
            this.label36.TabIndex = 199;
            this.label36.Text = "Markup:";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tSMRK
            // 
            this.tSMRK.BackColor = System.Drawing.Color.Lavender;
            this.tSMRK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSMRK.ForeColor = System.Drawing.Color.Red;
            this.tSMRK.Location = new System.Drawing.Point(160, 32);
            this.tSMRK.MaxLength = 49;
            this.tSMRK.Name = "tSMRK";
            this.tSMRK.Size = new System.Drawing.Size(56, 24);
            this.tSMRK.TabIndex = 198;
            this.tSMRK.Text = "1";
            this.tSMRK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tSMRK.TextChanged += new System.EventHandler(this.tSMRK_TextChanged);
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.SystemColors.Control;
            this.label38.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label38.Location = new System.Drawing.Point(112, 16);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(24, 16);
            this.label38.TabIndex = 197;
            this.label38.Text = "Qty:";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tIQty
            // 
            this.tIQty.BackColor = System.Drawing.Color.Lavender;
            this.tIQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIQty.ForeColor = System.Drawing.Color.Red;
            this.tIQty.Location = new System.Drawing.Point(104, 32);
            this.tIQty.MaxLength = 49;
            this.tIQty.Name = "tIQty";
            this.tIQty.Size = new System.Drawing.Size(56, 24);
            this.tIQty.TabIndex = 194;
            this.tIQty.Text = "1";
            this.tIQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tIQty.TextChanged += new System.EventHandler(this.tIQty_TextChanged);
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.SystemColors.Control;
            this.label42.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label42.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label42.Location = new System.Drawing.Point(32, 16);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(56, 16);
            this.label42.TabIndex = 196;
            this.label42.Text = "Unit Cost:";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tIPU
            // 
            this.tIPU.BackColor = System.Drawing.Color.Lavender;
            this.tIPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIPU.ForeColor = System.Drawing.Color.Red;
            this.tIPU.Location = new System.Drawing.Point(16, 32);
            this.tIPU.MaxLength = 49;
            this.tIPU.Name = "tIPU";
            this.tIPU.Size = new System.Drawing.Size(88, 24);
            this.tIPU.TabIndex = 193;
            this.tIPU.Text = "0";
            this.tIPU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tIPU.TextChanged += new System.EventHandler(this.tIPU_TextChanged);
            // 
            // lRecModel
            // 
            this.lRecModel.BackColor = System.Drawing.Color.Brown;
            this.lRecModel.ForeColor = System.Drawing.Color.Firebrick;
            this.lRecModel.Location = new System.Drawing.Point(6, 460);
            this.lRecModel.Name = "lRecModel";
            this.lRecModel.Size = new System.Drawing.Size(874, 20);
            this.lRecModel.TabIndex = 182;
            // 
            // ttermalP
            // 
            this.ttermalP.BackColor = System.Drawing.SystemColors.Control;
            this.ttermalP.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ttermalP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ttermalP.Location = new System.Drawing.Point(592, 184);
            this.ttermalP.MaxLength = 8;
            this.ttermalP.Name = "ttermalP";
            this.ttermalP.ReadOnly = true;
            this.ttermalP.Size = new System.Drawing.Size(136, 26);
            this.ttermalP.TabIndex = 178;
            // 
            // chktermalP
            // 
            this.chktermalP.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chktermalP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chktermalP.Location = new System.Drawing.Point(320, 184);
            this.chktermalP.Name = "chktermalP";
            this.chktermalP.Size = new System.Drawing.Size(272, 24);
            this.chktermalP.TabIndex = 177;
            this.chktermalP.Text = "Thermal protection";
            this.chktermalP.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lsave
            // 
            this.lsave.BackColor = System.Drawing.Color.Brown;
            this.lsave.ForeColor = System.Drawing.Color.Firebrick;
            this.lsave.Location = new System.Drawing.Point(848, 96);
            this.lsave.Name = "lsave";
            this.lsave.Size = new System.Drawing.Size(24, 16);
            this.lsave.TabIndex = 175;
            this.lsave.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(752, 416);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 24);
            this.btnCancel.TabIndex = 174;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // btnImport
            // 
            this.btnImport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnImport.Location = new System.Drawing.Point(752, 384);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(128, 24);
            this.btnImport.TabIndex = 173;
            this.btnImport.Text = "&OK";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click_1);
            // 
            // tApp
            // 
            this.tApp.BackColor = System.Drawing.SystemColors.Control;
            this.tApp.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tApp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tApp.Location = new System.Drawing.Point(592, 208);
            this.tApp.MaxLength = 8;
            this.tApp.Name = "tApp";
            this.tApp.ReadOnly = true;
            this.tApp.Size = new System.Drawing.Size(136, 26);
            this.tApp.TabIndex = 143;
            this.tApp.Text = "CSA/UL/CE";
            // 
            // chkApp
            // 
            this.chkApp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkApp.Checked = true;
            this.chkApp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkApp.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkApp.Location = new System.Drawing.Point(320, 208);
            this.chkApp.Name = "chkApp";
            this.chkApp.Size = new System.Drawing.Size(272, 24);
            this.chkApp.TabIndex = 142;
            this.chkApp.Text = "Approvals";
            this.chkApp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chk3PHS
            // 
            this.chk3PHS.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk3PHS.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chk3PHS.Location = new System.Drawing.Point(312, 158);
            this.chk3PHS.Name = "chk3PHS";
            this.chk3PHS.Size = new System.Drawing.Size(280, 26);
            this.chk3PHS.TabIndex = 141;
            this.chk3PHS.Text = "3 phase recirc. pump Contactor && O/L";
            this.chk3PHS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chk3PHS.CheckedChanged += new System.EventHandler(this.chk3PHS_CheckedChanged);
            // 
            // chkinternal
            // 
            this.chkinternal.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkinternal.Checked = true;
            this.chkinternal.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkinternal.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkinternal.Location = new System.Drawing.Point(320, 134);
            this.chkinternal.Name = "chkinternal";
            this.chkinternal.Size = new System.Drawing.Size(272, 24);
            this.chkinternal.TabIndex = 140;
            this.chkinternal.Text = "Internal control voltage";
            this.chkinternal.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkplc
            // 
            this.chkplc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkplc.Checked = true;
            this.chkplc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkplc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkplc.Location = new System.Drawing.Point(320, 110);
            this.chkplc.Name = "chkplc";
            this.chkplc.Size = new System.Drawing.Size(272, 24);
            this.chkplc.TabIndex = 139;
            this.chkplc.Text = "PLC interface voltage";
            this.chkplc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAux
            // 
            this.chkAux.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkAux.Checked = true;
            this.chkAux.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAux.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkAux.Location = new System.Drawing.Point(320, 86);
            this.chkAux.Name = "chkAux";
            this.chkAux.Size = new System.Drawing.Size(272, 24);
            this.chkAux.TabIndex = 138;
            this.chkAux.Text = "Auxiliary output for PLC";
            this.chkAux.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkheat
            // 
            this.chkheat.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkheat.Checked = true;
            this.chkheat.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkheat.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkheat.Location = new System.Drawing.Point(320, 62);
            this.chkheat.Name = "chkheat";
            this.chkheat.Size = new System.Drawing.Size(272, 24);
            this.chkheat.TabIndex = 137;
            this.chkheat.Text = "Heat Dissipation";
            this.chkheat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkInput
            // 
            this.chkInput.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkInput.Checked = true;
            this.chkInput.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkInput.Location = new System.Drawing.Point(320, 40);
            this.chkInput.Name = "chkInput";
            this.chkInput.Size = new System.Drawing.Size(272, 24);
            this.chkInput.TabIndex = 136;
            this.chkInput.Text = "Input Specs";
            this.chkInput.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkEnc
            // 
            this.chkEnc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnc.Checked = true;
            this.chkEnc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkEnc.Location = new System.Drawing.Point(320, 16);
            this.chkEnc.Name = "chkEnc";
            this.chkEnc.Size = new System.Drawing.Size(272, 24);
            this.chkEnc.TabIndex = 135;
            this.chkEnc.Text = "Enclosure - Standard - NEMA3R / IP33";
            this.chkEnc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb3PHS
            // 
            this.cb3PHS.BackColor = System.Drawing.Color.Lavender;
            this.cb3PHS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb3PHS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cb3PHS.Location = new System.Drawing.Point(592, 161);
            this.cb3PHS.Name = "cb3PHS";
            this.cb3PHS.Size = new System.Drawing.Size(136, 21);
            this.cb3PHS.TabIndex = 133;
            // 
            // cbInternal
            // 
            this.cbInternal.BackColor = System.Drawing.Color.Lavender;
            this.cbInternal.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInternal.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbInternal.Location = new System.Drawing.Point(592, 136);
            this.cbInternal.Name = "cbInternal";
            this.cbInternal.Size = new System.Drawing.Size(248, 21);
            this.cbInternal.TabIndex = 131;
            // 
            // cbPLC
            // 
            this.cbPLC.BackColor = System.Drawing.Color.Lavender;
            this.cbPLC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPLC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbPLC.Location = new System.Drawing.Point(592, 112);
            this.cbPLC.Name = "cbPLC";
            this.cbPLC.Size = new System.Drawing.Size(248, 21);
            this.cbPLC.TabIndex = 129;
            // 
            // cbAux
            // 
            this.cbAux.BackColor = System.Drawing.Color.Lavender;
            this.cbAux.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAux.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbAux.Location = new System.Drawing.Point(592, 88);
            this.cbAux.Name = "cbAux";
            this.cbAux.Size = new System.Drawing.Size(248, 21);
            this.cbAux.TabIndex = 127;
            // 
            // cbHeat
            // 
            this.cbHeat.BackColor = System.Drawing.Color.Lavender;
            this.cbHeat.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbHeat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbHeat.Location = new System.Drawing.Point(592, 64);
            this.cbHeat.Name = "cbHeat";
            this.cbHeat.Size = new System.Drawing.Size(248, 21);
            this.cbHeat.TabIndex = 125;
            // 
            // cbInput
            // 
            this.cbInput.BackColor = System.Drawing.Color.Lavender;
            this.cbInput.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbInput.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbInput.Location = new System.Drawing.Point(592, 40);
            this.cbInput.Name = "cbInput";
            this.cbInput.Size = new System.Drawing.Size(248, 21);
            this.cbInput.TabIndex = 123;
            // 
            // cbEnc
            // 
            this.cbEnc.BackColor = System.Drawing.Color.Lavender;
            this.cbEnc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEnc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbEnc.Location = new System.Drawing.Point(592, 18);
            this.cbEnc.Name = "cbEnc";
            this.cbEnc.Size = new System.Drawing.Size(288, 21);
            this.cbEnc.TabIndex = 121;
            // 
            // lvP5500
            // 
            this.lvP5500.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvP5500.AutoArrange = false;
            this.lvP5500.BackColor = System.Drawing.Color.OldLace;
            this.lvP5500.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvP5500.CheckBoxes = true;
            this.lvP5500.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chk,
            this.STKNB,
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
            this.price,
            this.app});
            this.lvP5500.ForeColor = System.Drawing.Color.Blue;
            this.lvP5500.FullRowSelect = true;
            this.lvP5500.GridLines = true;
            this.lvP5500.Location = new System.Drawing.Point(8, 16);
            this.lvP5500.Name = "lvP5500";
            this.lvP5500.Size = new System.Drawing.Size(304, 432);
            this.lvP5500.TabIndex = 115;
            this.lvP5500.UseCompatibleStateImageBehavior = false;
            this.lvP5500.View = System.Windows.Forms.View.Details;
            this.lvP5500.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvP5500_ItemCheck);
            this.lvP5500.SelectedIndexChanged += new System.EventHandler(this.lvP5500_SelectedIndexChanged);
            // 
            // chk
            // 
            this.chk.Text = " RECTIFIERS MODELS";
            this.chk.Width = 198;
            // 
            // STKNB
            // 
            this.STKNB.Text = "Stack #";
            this.STKNB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.STKNB.Width = 79;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "";
            this.columnHeader2.Width = 0;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 0;
            // 
            // columnHeader5
            // 
            this.columnHeader5.Text = "";
            this.columnHeader5.Width = 0;
            // 
            // columnHeader6
            // 
            this.columnHeader6.Text = "";
            this.columnHeader6.Width = 0;
            // 
            // columnHeader7
            // 
            this.columnHeader7.Text = "";
            this.columnHeader7.Width = 0;
            // 
            // columnHeader8
            // 
            this.columnHeader8.Text = "";
            this.columnHeader8.Width = 0;
            // 
            // columnHeader9
            // 
            this.columnHeader9.Text = "";
            this.columnHeader9.Width = 0;
            // 
            // columnHeader10
            // 
            this.columnHeader10.Text = "";
            this.columnHeader10.Width = 0;
            // 
            // columnHeader11
            // 
            this.columnHeader11.Text = "";
            this.columnHeader11.Width = 0;
            // 
            // columnHeader12
            // 
            this.columnHeader12.Text = "";
            this.columnHeader12.Width = 0;
            // 
            // columnHeader13
            // 
            this.columnHeader13.Text = "";
            this.columnHeader13.Width = 0;
            // 
            // columnHeader14
            // 
            this.columnHeader14.Text = "";
            this.columnHeader14.Width = 0;
            // 
            // columnHeader15
            // 
            this.columnHeader15.Text = "";
            this.columnHeader15.Width = 0;
            // 
            // columnHeader16
            // 
            this.columnHeader16.Text = "";
            this.columnHeader16.Width = 0;
            // 
            // columnHeader17
            // 
            this.columnHeader17.Text = "";
            this.columnHeader17.Width = 0;
            // 
            // columnHeader18
            // 
            this.columnHeader18.Text = "";
            this.columnHeader18.Width = 0;
            // 
            // price
            // 
            this.price.Text = "";
            this.price.Width = 0;
            // 
            // app
            // 
            this.app.Width = 0;
            // 
            // P5500
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(904, 513);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "P5500";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RECTIFIERS";
            this.Load += new System.EventHandler(this.importRxx_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void importRxx_Load(object sender, System.EventArgs e)
		{
			if (MainMDI.currDB =="XTT") this.Text = "XXXXXXXXXXXXXXXXXXTT";
            lRecModel.Visible = (MainMDI.User.ToLower() == "ede"); 
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		public void fill_lvP5500()
		{

            
			lvP5500.Items.Clear();  
			string stSql = "SELECT * FROM PSM_RECTIFIERS  ORDER BY IDin";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
			while (Oreadr.Read ())
            {
                string stout = "";
				ListViewItem lvI = lvP5500.Items.Add( Oreadr[1].ToString ());
                for (int i = 2; i < 21; i++)
                {
                    lvI.SubItems.Add(Oreadr[i].ToString());
                 //   stout += Oreadr[i].ToString() + "  I=" + i.ToString() + '\n';
                }
            //    MessageBox.Show(stout+ "  LV=" + lvI.SubItems.Count.ToString ()  ); 
			}

		}

	

	

	

	

		private void btnImport_Click(object sender, System.EventArgs e)
		{

		 lsave.Text ="Y";
			this.Hide();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
		lsave.Text ="N";
        this.Hide();
		}

		private void lvP5500_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}
		private void init_feat()
		{
			cbEnc.Items.Clear();
			cbInput.Items.Clear();
			cbHeat.Items.Clear();
			cbAux.Items.Clear();
			cb3PHS.Items.Clear();
			cbInternal.Items.Clear();
			cbPLC.Items.Clear();
			lRecModel.Text ="";
            tapplication.Clear();

			
		}
		private void init_lvP5500()
		{
			for (int i=0;i<lvP5500.Items.Count;i++) lvP5500.Items[i].Checked =false;
		
		}

		private void lvP5500_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			
			int ndx=e.Index ;
			if (!lvP5500.Items[ndx].Checked) 
			{ 
              init_lvP5500();
			  init_feat();
              cbEnc.Items.Add(lvP5500.Items[ndx].SubItems[2].Text + " WxHxD " + "mm: " + lvP5500.Items[ndx].SubItems[3].Text + " inch: " +  lvP5500.Items[ndx].SubItems[4].Text);  
   			  cbEnc.Text =cbEnc.Items[0].ToString();

			  cbInput.Items.Add(lvP5500.Items[ndx].SubItems[5].Text);
			  cbInput.Items.Add(lvP5500.Items[ndx].SubItems[6].Text);
			  cbInput.Text =cbInput.Items[0].ToString();

			  cbHeat.Items.Add(lvP5500.Items[ndx].SubItems[7].Text);
			  cbHeat.Text =cbHeat.Items[0].ToString();

			  cbAux.Items.Add(lvP5500.Items[ndx].SubItems[9].Text);
			  cbAux.Items.Add(lvP5500.Items[ndx].SubItems[10].Text);
			  cbAux.Text =cbAux.Items[0].ToString();

			  cbPLC.Items.Add(lvP5500.Items[ndx].SubItems[11].Text);
			  cbPLC.Items.Add(lvP5500.Items[ndx].SubItems[12].Text);
	    	  cbPLC.Items.Add(lvP5500.Items[ndx].SubItems[13].Text);
			  cbPLC.Text =cbPLC.Items[0].ToString();

			  cbInternal.Items.Add(lvP5500.Items[ndx].SubItems[14].Text);
			  cbInternal.Items.Add(lvP5500.Items[ndx].SubItems[15].Text);
			  cbInternal.Text =cbInternal.Items[0].ToString();

			  cb3PHS.Items.Add(lvP5500.Items[ndx].SubItems[16].Text);
			  cb3PHS.Text =cb3PHS.Items[0].ToString();
             // MessageBox.Show(lvP5500.Items[ndx].SubItems.Count.ToString());  
              tapplication.Text = lvP5500.Items[ndx].SubItems[19].Text;

			  ttermalP.Text = lvP5500.Items[ndx].SubItems[8].Text;
			  tApp.Text = lvP5500.Items[ndx].SubItems[17].Text;
			  tIPU.Text =Convert.ToString(Math.Round(Tools.Conv_Dbl(lvP5500.Items[ndx].SubItems[18].Text),MainMDI.NB_DEC_AFF));  ;
        //      lRecModel.Text = lvP5500.Items[ndx].SubItems[0].Text; 
              string ststk = ((Int32.Parse(lvP5500.Items[ndx].SubItems[1].Text)) >1) ? " E-CELL stacks" : " E-CELL stack";
              lRecModel.Text = lvP5500.Items[ndx].SubItems[0].Text + " / " + lvP5500.Items[ndx].SubItems[1].Text + ststk;  //  ede 25/04/08 to include stk# in model
			}
			else  init_feat();
		
		}
		private void calIOExt()
		{
							 
					double dPU=Tools.Conv_Dbl(tIPU.Text  ) ;
					double dQty=Tools.Conv_Dbl(tIQty.Text ) ;
					tIExt.Text= Convert.ToString ( Math.Round(dPU *  dQty * Tools.Conv_Dbl(tSMRK.Text),MainMDI.NB_DEC_AFF) ); 
	
			  
		}

		private void tIPU_TextChanged(object sender, System.EventArgs e)
		{
			calIOExt();
		}

		private void tIQty_TextChanged(object sender, System.EventArgs e)
		{
			calIOExt();
		}

		private void tSMRK_TextChanged(object sender, System.EventArgs e)
		{
			calIOExt();
		}

		private void tIExt_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnImport_Click_1(object sender, System.EventArgs e)
		{
			lsave.Text =(lRecModel.Text !="" && tIExt.Text !="0") ? "Y" : "N"; 
			this.Hide ();
		}

		private void btnCancel_Click_1(object sender, System.EventArgs e)
		{
			lsave.Text = "N"; 
			this.Hide();
		}

		private void chk3PHS_CheckedChanged(object sender, System.EventArgs e)
		{
			chktermalP.Checked = chk3PHS.Checked ;
		}





	}
}
