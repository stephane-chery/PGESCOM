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
	/// Summary description for importRxx.
	/// </summary>
	public class Options_brkr_Cfgv2 : System.Windows.Forms.Form
	{
		 private static Lib1 Tools = new Lib1();
        string in_ACDC = "";
        int countbig = 0;

        private System.Windows.Forms.GroupBox grp1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnImport;
        public System.Windows.Forms.ComboBox cbEnc;
		public System.Windows.Forms.Label lRecModel;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox tIExt;
        public System.Windows.Forms.TextBox tILT;
        public System.Windows.Forms.TextBox tSMRK;
		public System.Windows.Forms.TextBox tIQty;
		private System.Windows.Forms.Label label42;
		public System.Windows.Forms.CheckBox chkEnc;
        private Label label1;
        public TextBox tapplication;
        private Label lwar;
        private Label label9;
        private Label label8;
        private Label label7;
        public TextBox txf4;
        public TextBox txf3;
        public TextBox txf2;
        public TextBox txf1;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label lPHS;
        private Label label4;
        public ComboBox cb3PHS;
        public Label lsave;
        private Button button1;
        private CheckBox chk4;
        private CheckBox chk3;
        private CheckBox chk2;
        private CheckBox chk1;
        public TextBox tlPU;
        private Label label2;
        public ListView lvACDCbreaker;
        private ColumnHeader p1;
        private ColumnHeader dsc;
        private ColumnHeader manuf;
        private ColumnHeader mdl;
        private ColumnHeader price;
        private ColumnHeader phs;
        private ColumnHeader vac;
        private ColumnHeader ICB1;
        private ColumnHeader f5;
        private ColumnHeader f6;
        private Button button2;
        public Label lcntr;
        public TextBox txddd;
        private Label label3;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public Options_brkr_Cfgv2(string x_ACDC)
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();
            //fill_lvP5500();

            //
            //TODO: Add any constructor code after InitializeComponent call
            //
            in_ACDC = x_ACDC;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options_brkr_Cfgv2));
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txddd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lcntr = new System.Windows.Forms.Label();
            this.tlPU = new System.Windows.Forms.TextBox();
            this.chk4 = new System.Windows.Forms.CheckBox();
            this.chk3 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.lsave = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lPHS = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tIExt = new System.Windows.Forms.TextBox();
            this.cb3PHS = new System.Windows.Forms.ComboBox();
            this.lwar = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.tIQty = new System.Windows.Forms.TextBox();
            this.txf4 = new System.Windows.Forms.TextBox();
            this.txf3 = new System.Windows.Forms.TextBox();
            this.txf2 = new System.Windows.Forms.TextBox();
            this.txf1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tapplication = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tILT = new System.Windows.Forms.TextBox();
            this.tSMRK = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.lRecModel = new System.Windows.Forms.Label();
            this.chkEnc = new System.Windows.Forms.CheckBox();
            this.cbEnc = new System.Windows.Forms.ComboBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.lvACDCbreaker = new System.Windows.Forms.ListView();
            this.p1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dsc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ICB1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.vac = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.manuf = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.f5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.f6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grp1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // grp1
            // 
            this.grp1.BackColor = System.Drawing.Color.LemonChiffon;
            this.grp1.Controls.Add(this.button2);
            this.grp1.Controls.Add(this.btnCancel);
            this.grp1.Controls.Add(this.txddd);
            this.grp1.Controls.Add(this.label3);
            this.grp1.Controls.Add(this.lcntr);
            this.grp1.Controls.Add(this.tlPU);
            this.grp1.Controls.Add(this.chk4);
            this.grp1.Controls.Add(this.chk3);
            this.grp1.Controls.Add(this.chk2);
            this.grp1.Controls.Add(this.chk1);
            this.grp1.Controls.Add(this.lsave);
            this.grp1.Controls.Add(this.btnImport);
            this.grp1.Controls.Add(this.button1);
            this.grp1.Controls.Add(this.lPHS);
            this.grp1.Controls.Add(this.label4);
            this.grp1.Controls.Add(this.tIExt);
            this.grp1.Controls.Add(this.cb3PHS);
            this.grp1.Controls.Add(this.lwar);
            this.grp1.Controls.Add(this.label8);
            this.grp1.Controls.Add(this.label7);
            this.grp1.Controls.Add(this.tIQty);
            this.grp1.Controls.Add(this.txf4);
            this.grp1.Controls.Add(this.txf3);
            this.grp1.Controls.Add(this.txf2);
            this.grp1.Controls.Add(this.txf1);
            this.grp1.Controls.Add(this.label1);
            this.grp1.Controls.Add(this.tapplication);
            this.grp1.Controls.Add(this.groupBox2);
            this.grp1.Controls.Add(this.lRecModel);
            this.grp1.Controls.Add(this.chkEnc);
            this.grp1.Controls.Add(this.cbEnc);
            this.grp1.Controls.Add(this.label14);
            this.grp1.Controls.Add(this.label2);
            this.grp1.Controls.Add(this.label12);
            this.grp1.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp1.Location = new System.Drawing.Point(0, 0);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(1372, 82);
            this.grp1.TabIndex = 0;
            this.grp1.TabStop = false;
            this.grp1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PeachPuff;
            this.button2.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Location = new System.Drawing.Point(905, 27);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(149, 34);
            this.button2.TabIndex = 227;
            this.button2.Text = "Generate CBxx12";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.PeachPuff;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(771, 23);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 43);
            this.btnCancel.TabIndex = 174;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // txddd
            // 
            this.txddd.BackColor = System.Drawing.Color.White;
            this.txddd.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txddd.ForeColor = System.Drawing.Color.Black;
            this.txddd.Location = new System.Drawing.Point(11, 30);
            this.txddd.MaxLength = 49;
            this.txddd.Multiline = true;
            this.txddd.Name = "txddd";
            this.txddd.ReadOnly = true;
            this.txddd.Size = new System.Drawing.Size(355, 29);
            this.txddd.TabIndex = 229;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LemonChiffon;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(140, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 24);
            this.label3.TabIndex = 230;
            this.label3.Text = "Description";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lcntr
            // 
            this.lcntr.BackColor = System.Drawing.Color.White;
            this.lcntr.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcntr.ForeColor = System.Drawing.Color.Black;
            this.lcntr.Location = new System.Drawing.Point(858, 8);
            this.lcntr.Name = "lcntr";
            this.lcntr.Size = new System.Drawing.Size(82, 33);
            this.lcntr.TabIndex = 228;
            this.lcntr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tlPU
            // 
            this.tlPU.BackColor = System.Drawing.Color.White;
            this.tlPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tlPU.ForeColor = System.Drawing.Color.Red;
            this.tlPU.Location = new System.Drawing.Point(419, 30);
            this.tlPU.MaxLength = 49;
            this.tlPU.Multiline = true;
            this.tlPU.Name = "tlPU";
            this.tlPU.ReadOnly = true;
            this.tlPU.Size = new System.Drawing.Size(91, 29);
            this.tlPU.TabIndex = 225;
            this.tlPU.Text = "0";
            this.tlPU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tlPU.TextChanged += new System.EventHandler(this.tlPU_TextChanged);
            // 
            // chk4
            // 
            this.chk4.AutoSize = true;
            this.chk4.Location = new System.Drawing.Point(188, 298);
            this.chk4.Name = "chk4";
            this.chk4.Size = new System.Drawing.Size(39, 17);
            this.chk4.TabIndex = 224;
            this.chk4.Text = "#4";
            this.chk4.UseVisualStyleBackColor = true;
            // 
            // chk3
            // 
            this.chk3.AutoSize = true;
            this.chk3.Location = new System.Drawing.Point(188, 272);
            this.chk3.Name = "chk3";
            this.chk3.Size = new System.Drawing.Size(39, 17);
            this.chk3.TabIndex = 223;
            this.chk3.Text = "#3";
            this.chk3.UseVisualStyleBackColor = true;
            // 
            // chk2
            // 
            this.chk2.AutoSize = true;
            this.chk2.Location = new System.Drawing.Point(188, 245);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(39, 17);
            this.chk2.TabIndex = 222;
            this.chk2.Text = "#2";
            this.chk2.UseVisualStyleBackColor = true;
            // 
            // chk1
            // 
            this.chk1.AutoSize = true;
            this.chk1.Location = new System.Drawing.Point(188, 219);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(39, 17);
            this.chk1.TabIndex = 221;
            this.chk1.Text = "#1";
            this.chk1.UseVisualStyleBackColor = true;
            // 
            // lsave
            // 
            this.lsave.BackColor = System.Drawing.Color.Brown;
            this.lsave.ForeColor = System.Drawing.Color.Firebrick;
            this.lsave.Location = new System.Drawing.Point(1047, 112);
            this.lsave.Name = "lsave";
            this.lsave.Size = new System.Drawing.Size(23, 16);
            this.lsave.TabIndex = 218;
            this.lsave.Visible = false;
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.PeachPuff;
            this.btnImport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(681, 23);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(78, 42);
            this.btnImport.TabIndex = 173;
            this.btnImport.Text = "OK";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Khaki;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(332, 590);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(56, 56);
            this.button1.TabIndex = 220;
            this.button1.Text = "3";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lPHS
            // 
            this.lPHS.BackColor = System.Drawing.Color.AliceBlue;
            this.lPHS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lPHS.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPHS.ForeColor = System.Drawing.Color.Red;
            this.lPHS.Location = new System.Drawing.Point(332, 590);
            this.lPHS.Name = "lPHS";
            this.lPHS.Size = new System.Drawing.Size(40, 55);
            this.lPHS.TabIndex = 217;
            this.lPHS.Text = "3";
            this.lPHS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lPHS.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.AliceBlue;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Verdana", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(182, 600);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 34);
            this.label4.TabIndex = 216;
            this.label4.Text = "PHASE: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Visible = false;
            // 
            // tIExt
            // 
            this.tIExt.BackColor = System.Drawing.Color.White;
            this.tIExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIExt.ForeColor = System.Drawing.Color.Red;
            this.tIExt.Location = new System.Drawing.Point(514, 30);
            this.tIExt.MaxLength = 49;
            this.tIExt.Multiline = true;
            this.tIExt.Name = "tIExt";
            this.tIExt.ReadOnly = true;
            this.tIExt.Size = new System.Drawing.Size(122, 29);
            this.tIExt.TabIndex = 201;
            this.tIExt.Text = "0";
            this.tIExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tIExt.TextChanged += new System.EventHandler(this.tIExt_TextChanged);
            // 
            // cb3PHS
            // 
            this.cb3PHS.BackColor = System.Drawing.Color.Lavender;
            this.cb3PHS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb3PHS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cb3PHS.Location = new System.Drawing.Point(33, 551);
            this.cb3PHS.Name = "cb3PHS";
            this.cb3PHS.Size = new System.Drawing.Size(137, 21);
            this.cb3PHS.TabIndex = 215;
            this.cb3PHS.Visible = false;
            // 
            // lwar
            // 
            this.lwar.BackColor = System.Drawing.Color.Red;
            this.lwar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lwar.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lwar.ForeColor = System.Drawing.Color.White;
            this.lwar.Location = new System.Drawing.Point(183, 510);
            this.lwar.Name = "lwar";
            this.lwar.Size = new System.Drawing.Size(342, 20);
            this.lwar.TabIndex = 214;
            this.lwar.Text = "Warning:  please check Enclosure";
            this.lwar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lwar.Visible = false;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.White;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(53, 542);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 16);
            this.label8.TabIndex = 208;
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Visible = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.White;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(53, 510);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(74, 16);
            this.label7.TabIndex = 206;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Visible = false;
            // 
            // tIQty
            // 
            this.tIQty.BackColor = System.Drawing.Color.White;
            this.tIQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIQty.ForeColor = System.Drawing.Color.Red;
            this.tIQty.Location = new System.Drawing.Point(370, 30);
            this.tIQty.MaxLength = 49;
            this.tIQty.Multiline = true;
            this.tIQty.Name = "tIQty";
            this.tIQty.Size = new System.Drawing.Size(45, 29);
            this.tIQty.TabIndex = 194;
            this.tIQty.Text = "1";
            this.tIQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tIQty.TextChanged += new System.EventHandler(this.tIQty_TextChanged);
            // 
            // txf4
            // 
            this.txf4.BackColor = System.Drawing.SystemColors.Control;
            this.txf4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txf4.ForeColor = System.Drawing.Color.DarkRed;
            this.txf4.Location = new System.Drawing.Point(226, 295);
            this.txf4.MaxLength = 8;
            this.txf4.Name = "txf4";
            this.txf4.ReadOnly = true;
            this.txf4.Size = new System.Drawing.Size(342, 26);
            this.txf4.TabIndex = 205;
            // 
            // txf3
            // 
            this.txf3.BackColor = System.Drawing.SystemColors.Control;
            this.txf3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txf3.ForeColor = System.Drawing.Color.DarkRed;
            this.txf3.Location = new System.Drawing.Point(226, 269);
            this.txf3.MaxLength = 8;
            this.txf3.Name = "txf3";
            this.txf3.ReadOnly = true;
            this.txf3.Size = new System.Drawing.Size(342, 26);
            this.txf3.TabIndex = 203;
            // 
            // txf2
            // 
            this.txf2.BackColor = System.Drawing.SystemColors.Control;
            this.txf2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txf2.ForeColor = System.Drawing.Color.DarkRed;
            this.txf2.Location = new System.Drawing.Point(226, 240);
            this.txf2.MaxLength = 8;
            this.txf2.Name = "txf2";
            this.txf2.ReadOnly = true;
            this.txf2.Size = new System.Drawing.Size(342, 26);
            this.txf2.TabIndex = 201;
            // 
            // txf1
            // 
            this.txf1.BackColor = System.Drawing.SystemColors.Control;
            this.txf1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txf1.ForeColor = System.Drawing.Color.DarkRed;
            this.txf1.Location = new System.Drawing.Point(226, 214);
            this.txf1.MaxLength = 8;
            this.txf1.Name = "txf1";
            this.txf1.ReadOnly = true;
            this.txf1.Size = new System.Drawing.Size(342, 26);
            this.txf1.TabIndex = 199;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(322, 556);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(73, 16);
            this.label1.TabIndex = 197;
            this.label1.Text = "Application";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label1.Visible = false;
            // 
            // tapplication
            // 
            this.tapplication.BackColor = System.Drawing.SystemColors.Control;
            this.tapplication.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tapplication.ForeColor = System.Drawing.Color.Red;
            this.tapplication.Location = new System.Drawing.Point(180, 546);
            this.tapplication.MaxLength = 8;
            this.tapplication.Name = "tapplication";
            this.tapplication.ReadOnly = true;
            this.tapplication.Size = new System.Drawing.Size(137, 26);
            this.tapplication.TabIndex = 184;
            this.tapplication.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tapplication.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.Color.Gold;
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.tILT);
            this.groupBox2.Controls.Add(this.tSMRK);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Location = new System.Drawing.Point(983, 113);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(54, 56);
            this.groupBox2.TabIndex = 183;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.LemonChiffon;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(158, 72);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 24);
            this.label13.TabIndex = 204;
            this.label13.Text = "Markup ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.LemonChiffon;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(440, 147);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 16);
            this.label9.TabIndex = 210;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Visible = false;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.LemonChiffon;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label15.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(180, 105);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 24);
            this.label15.TabIndex = 206;
            this.label15.Text = "Lead Time ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tILT
            // 
            this.tILT.BackColor = System.Drawing.Color.White;
            this.tILT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tILT.ForeColor = System.Drawing.Color.Red;
            this.tILT.Location = new System.Drawing.Point(295, 105);
            this.tILT.MaxLength = 49;
            this.tILT.Multiline = true;
            this.tILT.Name = "tILT";
            this.tILT.Size = new System.Drawing.Size(57, 24);
            this.tILT.TabIndex = 195;
            this.tILT.Text = "04-06";
            // 
            // tSMRK
            // 
            this.tSMRK.BackColor = System.Drawing.Color.White;
            this.tSMRK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSMRK.ForeColor = System.Drawing.Color.Red;
            this.tSMRK.Location = new System.Drawing.Point(277, 68);
            this.tSMRK.MaxLength = 49;
            this.tSMRK.Name = "tSMRK";
            this.tSMRK.Size = new System.Drawing.Size(55, 24);
            this.tSMRK.TabIndex = 198;
            this.tSMRK.Text = "1";
            this.tSMRK.TextChanged += new System.EventHandler(this.tSMRK_TextChanged);
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.LemonChiffon;
            this.label42.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label42.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label42.Location = new System.Drawing.Point(158, 36);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(115, 24);
            this.label42.TabIndex = 196;
            this.label42.Text = "Unit Cost ";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lRecModel
            // 
            this.lRecModel.BackColor = System.Drawing.Color.Brown;
            this.lRecModel.ForeColor = System.Drawing.Color.Firebrick;
            this.lRecModel.Location = new System.Drawing.Point(23, 672);
            this.lRecModel.Name = "lRecModel";
            this.lRecModel.Size = new System.Drawing.Size(590, 20);
            this.lRecModel.TabIndex = 182;
            this.lRecModel.Visible = false;
            // 
            // chkEnc
            // 
            this.chkEnc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnc.Checked = true;
            this.chkEnc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkEnc.Location = new System.Drawing.Point(402, 548);
            this.chkEnc.Name = "chkEnc";
            this.chkEnc.Size = new System.Drawing.Size(105, 24);
            this.chkEnc.TabIndex = 135;
            this.chkEnc.Text = "Enclosure";
            this.chkEnc.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnc.Visible = false;
            // 
            // cbEnc
            // 
            this.cbEnc.BackColor = System.Drawing.Color.Lavender;
            this.cbEnc.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.cbEnc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbEnc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbEnc.Location = new System.Drawing.Point(510, 548);
            this.cbEnc.Name = "cbEnc";
            this.cbEnc.Size = new System.Drawing.Size(97, 21);
            this.cbEnc.TabIndex = 121;
            this.cbEnc.Visible = false;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.LemonChiffon;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label14.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(418, 10);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(98, 24);
            this.label14.TabIndex = 205;
            this.label14.Text = "Sell Price ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LemonChiffon;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(526, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(96, 24);
            this.label2.TabIndex = 226;
            this.label2.Text = "Extension";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.LemonChiffon;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label12.Font = new System.Drawing.Font("Verdana", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(385, 10);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(30, 24);
            this.label12.TabIndex = 203;
            this.label12.Text = "QTY ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lvACDCbreaker
            // 
            this.lvACDCbreaker.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvACDCbreaker.AutoArrange = false;
            this.lvACDCbreaker.BackColor = System.Drawing.Color.LightBlue;
            this.lvACDCbreaker.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvACDCbreaker.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.p1,
            this.dsc,
            this.phs,
            this.ICB1,
            this.vac,
            this.manuf,
            this.mdl,
            this.price,
            this.f5,
            this.f6});
            this.lvACDCbreaker.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvACDCbreaker.Font = new System.Drawing.Font("Verdana", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvACDCbreaker.ForeColor = System.Drawing.Color.Red;
            this.lvACDCbreaker.FullRowSelect = true;
            this.lvACDCbreaker.GridLines = true;
            this.lvACDCbreaker.HideSelection = false;
            this.lvACDCbreaker.Location = new System.Drawing.Point(0, 82);
            this.lvACDCbreaker.MultiSelect = false;
            this.lvACDCbreaker.Name = "lvACDCbreaker";
            this.lvACDCbreaker.Size = new System.Drawing.Size(1372, 787);
            this.lvACDCbreaker.TabIndex = 119;
            this.lvACDCbreaker.UseCompatibleStateImageBehavior = false;
            this.lvACDCbreaker.View = System.Windows.Forms.View.Details;
            this.lvACDCbreaker.DoubleClick += new System.EventHandler(this.lvACDCbreaker_DoubleClick);
            // 
            // p1
            // 
            this.p1.Text = "id";
            this.p1.Width = 0;
            // 
            // dsc
            // 
            this.dsc.Text = "Breaker Description";
            this.dsc.Width = 473;
            // 
            // phs
            // 
            this.phs.Text = "PHASE";
            this.phs.Width = 100;
            // 
            // ICB1
            // 
            this.ICB1.Text = "ICB1";
            this.ICB1.Width = 100;
            // 
            // vac
            // 
            this.vac.Text = "VAC";
            this.vac.Width = 100;
            // 
            // manuf
            // 
            this.manuf.Text = "manufacturer";
            this.manuf.Width = 184;
            // 
            // mdl
            // 
            this.mdl.Text = "Model";
            this.mdl.Width = 146;
            // 
            // price
            // 
            this.price.Text = "Price";
            this.price.Width = 108;
            // 
            // f5
            // 
            this.f5.Text = "";
            this.f5.Width = 0;
            // 
            // f6
            // 
            this.f6.Text = "";
            this.f6.Width = 3;
            // 
            // Options_brkr_Cfgv2
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1372, 869);
            this.Controls.Add(this.lvACDCbreaker);
            this.Controls.Add(this.grp1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Options_brkr_Cfgv2";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AC BREAKERS";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Options_brkr_Cfgv2_Load);
            this.grp1.ResumeLayout(false);
            this.grp1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

        public void fill_lvBreaker()
        {
            this.Cursor = Cursors.WaitCursor;
            lvACDCbreaker.Items.Clear();
            //lvDCbreaker.Items.Clear();

            //string stSql = (in_ACDC == "A") ? "SELECT Configo_CBxx.Description, Configo_CBxx.PHASE, Configo_CBxx.VAC, Configo_CBxx.ICB1, Configo_CBxx.[VSC ac 120], Configo_CBxx.[VSC ac 240], Configo_CBxx.[VSC ac 400], Configo_CBxx.[VSC ac 480], Configo_CBxx.[VSC ac 600], Configo_CBxx.[VSC dc 125], " +
                //" Configo_CBxx.[VSC dc 130], Configo_CBxx.[VSC dc 250], Configo_CBxx.[VSC dc 600], Configo_CBxx.[Sell Price], Configo_CBxx.[Cost Price], Configo_CBxx.[CPT Family], Configo_CBxx.Priority," +
                //" Configo_CBxx.FamID, Configo_CBxx.[Primax Code], Configo_CBxx.hh, Configo_CBxx.multiplier,  Configo_CBxx.SellPriceNew, COMPNT_MANUFAC.MANUFAC_NAME " +
                //" FROM   Configo_CBxx INNER JOIN COMPNT_MANUFAC_FAMILY ON Configo_CBxx.FamID = COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID INNER JOIN " +
                //"        COMPNT_MANUFAC ON COMPNT_MANUFAC_FAMILY.Manufac_ID = COMPNT_MANUFAC.MANUFAC_ID " +
                //" ORDER BY Configo_CBxx.PHASE, Configo_CBxx.VAC, Configo_CBxx.ICB1" :
                //" SELECT Configo_CB2xx.Description, Configo_CB2xx.PHASE, Configo_CB2xx.VDC, Configo_CB2xx.ICB1, Configo_CB2xx.[VSC ac 120], Configo_CB2xx.[VSC ac 240], Configo_CB2xx.[VSC ac 400], Configo_CB2xx.[VSC ac 480], " +
                //"        Configo_CB2xx.[VSC ac 600], Configo_CB2xx.[VSC dc 125],  Configo_CB2xx.[VSC dc 130], Configo_CB2xx.[VSC dc 250], Configo_CB2xx.[VSC dc 600]," +
                //"        Configo_CB2xx.[Sell Price], Configo_CB2xx.[Cost Price], Configo_CB2xx.[CPT Family], Configo_CB2xx.Priority, Configo_CB2xx.FamID, Configo_CB2xx.[Primax Code], Configo_CB2xx.hh, " +
                //"        Configo_CB2xx.multiplier, Configo_CB2xx.SellPriceNew, COMPNT_MANUFAC.MANUFAC_NAME " +
                //"FROM   COMPNT_MANUFAC INNER JOIN COMPNT_MANUFAC_FAMILY ON COMPNT_MANUFAC.MANUFAC_ID = COMPNT_MANUFAC_FAMILY.Manufac_ID INNER JOIN " +
                //"       Configo_CB2xx ON COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID = Configo_CB2xx.FamID " +
                //" ORDER BY Configo_CB2xx.PHASE, Configo_CB2xx.VDC, Configo_CB2xx.ICB1";

            string stSql = (in_ACDC == "A") ? "SELECT * FROM   Configo_CB1xx_CB2xx_biglist where cb12 = 1 order by phase,icb1,V_value,ka" :
                "SELECT * FROM   Configo_CB1xx_CB2xx_biglist where cb12 = 2 order by phase,icb1,V_value,ka";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            if (in_ACDC == "A") lvACDCbreaker.Columns[4].Text = "VAC";
            else lvACDCbreaker.Columns[4].Text = "VDC";
            lvACDCbreaker.BeginUpdate();

            while (Oreadr.Read())
            {
                //string stout = "";
                ListViewItem lvI = lvACDCbreaker.Items.Add("");
                lvI.SubItems.Add(Oreadr["ddd"].ToString());
                lvI.SubItems.Add(Oreadr["PHASE"].ToString());
                lvI.SubItems.Add(Oreadr["ICB1"].ToString());
                lvI.SubItems.Add(Oreadr["V_value"].ToString());
                lvI.SubItems.Add(Oreadr["MANIFAC"].ToString());
                lvI.SubItems.Add(Oreadr["CPT_Family"].ToString());
                lvI.SubItems.Add(Oreadr["List_Price"].ToString());

                //MessageBox.Show("nb items=" + lvI.SubItems.Count.ToString());
            }
            lvACDCbreaker.EndUpdate();
            this.Cursor = Cursors.Default;
        }

        public void fill_lvBreakerOLDok()
		{
			lvACDCbreaker.Items.Clear();
            //lvDCbreaker.Items.Clear();

            string stSql = (in_ACDC == "A") ? "SELECT Configo_CBxx.Description, Configo_CBxx.PHASE, Configo_CBxx.VAC, Configo_CBxx.ICB1, Configo_CBxx.[VSC ac 120], Configo_CBxx.[VSC ac 240], Configo_CBxx.[VSC ac 400], Configo_CBxx.[VSC ac 480], Configo_CBxx.[VSC ac 600], Configo_CBxx.[VSC dc 125], " +
                " Configo_CBxx.[VSC dc 130], Configo_CBxx.[VSC dc 250], Configo_CBxx.[VSC dc 600], Configo_CBxx.[Sell Price], Configo_CBxx.[Cost Price], Configo_CBxx.[CPT Family], Configo_CBxx.Priority," +
                " Configo_CBxx.FamID, Configo_CBxx.[Primax Code], Configo_CBxx.hh, Configo_CBxx.multiplier,  Configo_CBxx.SellPriceNew, COMPNT_MANUFAC.MANUFAC_NAME " +
                " FROM   Configo_CBxx INNER JOIN COMPNT_MANUFAC_FAMILY ON Configo_CBxx.FamID = COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID INNER JOIN " +
                "        COMPNT_MANUFAC ON COMPNT_MANUFAC_FAMILY.Manufac_ID = COMPNT_MANUFAC.MANUFAC_ID " +
                " ORDER BY Configo_CBxx.PHASE, Configo_CBxx.VAC, Configo_CBxx.ICB1" :
                " SELECT Configo_CB2xx.Description, Configo_CB2xx.PHASE, Configo_CB2xx.VDC, Configo_CB2xx.ICB1, Configo_CB2xx.[VSC ac 120], Configo_CB2xx.[VSC ac 240], Configo_CB2xx.[VSC ac 400], Configo_CB2xx.[VSC ac 480], " +
                "        Configo_CB2xx.[VSC ac 600], Configo_CB2xx.[VSC dc 125],  Configo_CB2xx.[VSC dc 130], Configo_CB2xx.[VSC dc 250], Configo_CB2xx.[VSC dc 600]," +
                "        Configo_CB2xx.[Sell Price], Configo_CB2xx.[Cost Price], Configo_CB2xx.[CPT Family], Configo_CB2xx.Priority, Configo_CB2xx.FamID, Configo_CB2xx.[Primax Code], Configo_CB2xx.hh, " +
                "        Configo_CB2xx.multiplier, Configo_CB2xx.SellPriceNew, COMPNT_MANUFAC.MANUFAC_NAME " +
                "FROM   COMPNT_MANUFAC INNER JOIN COMPNT_MANUFAC_FAMILY ON COMPNT_MANUFAC.MANUFAC_ID = COMPNT_MANUFAC_FAMILY.Manufac_ID INNER JOIN " +
                "       Configo_CB2xx ON COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID = Configo_CB2xx.FamID " +
                " ORDER BY Configo_CB2xx.PHASE, Configo_CB2xx.VDC, Configo_CB2xx.ICB1";

			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
			while (Oreadr.Read())
            {
                //string stout = "";
				ListViewItem lvI = lvACDCbreaker.Items.Add("");
                lvI.SubItems.Add(Oreadr["Description"].ToString());
                lvI.SubItems.Add(Oreadr["MANUFAC_NAME"].ToString());
                lvI.SubItems.Add(Oreadr["CPT Family"].ToString());
                lvI.SubItems.Add(Oreadr["SellPriceNew"].ToString());
                lvI.SubItems.Add(Oreadr["PHASE"].ToString());
                if (in_ACDC=="A") lvI.SubItems.Add(Oreadr["VAC"].ToString());
                else lvI.SubItems.Add(Oreadr["VDC"].ToString());
                lvI.SubItems.Add(Oreadr["ICB1"].ToString());

                //MessageBox.Show("nb items=" + lvI.SubItems.Count.ToString());
            }
		}

        bool writ_big(string cb12, string PHASE, string ICB1, string V_value, string ka, string Sell_Price, string Cost_Price, string CPT_Family, string List_Price, string MANIFAC, string pref)
        {
            try
            {
                string samlog = "-----phs=" + PHASE + " / " + CPT_Family + " / " + List_Price;
                string ddd = (cb12 == "2") ? "DC breaker, " + ICB1 + " A, " + V_value + "A, " + ka + " kA" :
                    "AC breaker, " + ICB1 + " A, " + V_value + "A, " + ka + " kA";
                double pp = Math.Round(Tools.Conv_Dbl(List_Price), 0);
                string stSql = "INSERT INTO Configo_CB1xx_CB2xx_biglist (" +
                    "[cb12]  ,[PHASE]  ,[ICB1] ,[V_value] ,[ka] ,[Sell_Price] ,[Cost_Price] ,[CPT_Family]  ,[List_Price] ,[MANIFAC]" +
                    "  ,[pref],[ddd],[samlog]) VALUES (" +
                    cb12 + ", " +
                    PHASE + ", " +
                    ICB1 + ", " +
                    V_value + ", " +
                    ka + ", " +
                    Sell_Price + ", " +
                    Cost_Price + ", '" +
                    CPT_Family + "', " +
                    pp.ToString() + ", '" +
                    MANIFAC + "', " +
                    pref + ", '" +
                    ddd + "', '" +
                    samlog + "')";

                MainMDI.Exec_SQL_JFS(stSql, " Configo insert cf deails");
                countbig++;
                lcntr.Text = countbig.ToString();
                lcntr.Refresh();
            }
            catch (SqlException Oexp)
            {
                MessageBox.Show("Cannot generate breakers big file error...= " + Oexp.Message);
                return false;
            }
            return true;
        }

        public void Gen_CBxx12()
        {
            this.Cursor = Cursors.WaitCursor;

            string stSql = "select * from Configo_CB1xx_CB2xx ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            countbig = 0;
            while (Oreadr.Read())
            {
                if (countbig == 0) MainMDI.Exec_SQL_JFS("delete Configo_CB1xx_CB2xx_biglist", "init cbxxx_bigfile....");
                if (Tools.Conv_Dbl(Oreadr["120Vac"].ToString()) > 0) writ_big("1", Oreadr["PHASE"].ToString(), Oreadr["ICB1"].ToString(), "120", Oreadr["120Vac"].ToString(), Oreadr["Sell_Price"].ToString(),
                        Oreadr["Cost_Price"].ToString(), Oreadr["CPT_Family"].ToString(), Oreadr["List_Price"].ToString(),
                        Oreadr["MANIFAC"].ToString(), Oreadr["pref"].ToString());
                if (Tools.Conv_Dbl(Oreadr["240Vac"].ToString()) > 0) writ_big("1", Oreadr["PHASE"].ToString(), Oreadr["ICB1"].ToString(), "240", Oreadr["240Vac"].ToString(), Oreadr["Sell_Price"].ToString(),
                        Oreadr["Cost_Price"].ToString(), Oreadr["CPT_Family"].ToString(), Oreadr["List_Price"].ToString(),
                        Oreadr["MANIFAC"].ToString(), Oreadr["pref"].ToString());
                if (Tools.Conv_Dbl(Oreadr["400Vac"].ToString()) > 0) writ_big("1", Oreadr["PHASE"].ToString(), Oreadr["ICB1"].ToString(), "400", Oreadr["400Vac"].ToString(), Oreadr["Sell_Price"].ToString(),
                        Oreadr["Cost_Price"].ToString(), Oreadr["CPT_Family"].ToString(), Oreadr["List_Price"].ToString(),
                        Oreadr["MANIFAC"].ToString(), Oreadr["pref"].ToString());
                if (Tools.Conv_Dbl(Oreadr["480Vac"].ToString()) > 0) writ_big("1", Oreadr["PHASE"].ToString(), Oreadr["ICB1"].ToString(), "480", Oreadr["480Vac"].ToString(), Oreadr["Sell_Price"].ToString(),
                        Oreadr["Cost_Price"].ToString(), Oreadr["CPT_Family"].ToString(), Oreadr["List_Price"].ToString(),
                        Oreadr["MANIFAC"].ToString(), Oreadr["pref"].ToString());
                if (Tools.Conv_Dbl(Oreadr["600Vac"].ToString()) > 0) writ_big("1", Oreadr["PHASE"].ToString(), Oreadr["ICB1"].ToString(), "600", Oreadr["600Vac"].ToString(), Oreadr["Sell_Price"].ToString(),
                        Oreadr["Cost_Price"].ToString(), Oreadr["CPT_Family"].ToString(), Oreadr["List_Price"].ToString(),
                        Oreadr["MANIFAC"].ToString(), Oreadr["pref"].ToString());
                if (Tools.Conv_Dbl(Oreadr["80Vdc"].ToString()) > 0) writ_big("2", Oreadr["PHASE"].ToString(), Oreadr["ICB1"].ToString(), "80", Oreadr["80Vdc"].ToString(), Oreadr["Sell_Price"].ToString(),
                        Oreadr["Cost_Price"].ToString(), Oreadr["CPT_Family"].ToString(), Oreadr["List_Price"].ToString(),
                        Oreadr["MANIFAC"].ToString(), Oreadr["pref"].ToString());
                if (Tools.Conv_Dbl(Oreadr["125Vdc"].ToString()) > 0) writ_big("2", Oreadr["PHASE"].ToString(), Oreadr["ICB1"].ToString(), "125", Oreadr["125Vdc"].ToString(), Oreadr["Sell_Price"].ToString(),
                        Oreadr["Cost_Price"].ToString(), Oreadr["CPT_Family"].ToString(), Oreadr["List_Price"].ToString(),
                        Oreadr["MANIFAC"].ToString(), Oreadr["pref"].ToString());
                if (Tools.Conv_Dbl(Oreadr["130Vdc"].ToString()) > 0) writ_big("2", Oreadr["PHASE"].ToString(), Oreadr["ICB1"].ToString(), "130", Oreadr["130Vdc"].ToString(), Oreadr["Sell_Price"].ToString(),
                        Oreadr["Cost_Price"].ToString(), Oreadr["CPT_Family"].ToString(), Oreadr["List_Price"].ToString(),
                        Oreadr["MANIFAC"].ToString(), Oreadr["pref"].ToString());
                if (Tools.Conv_Dbl(Oreadr["250Vdc"].ToString()) > 0) writ_big("2", Oreadr["PHASE"].ToString(), Oreadr["ICB1"].ToString(), "250", Oreadr["250Vdc"].ToString(), Oreadr["Sell_Price"].ToString(),
                        Oreadr["Cost_Price"].ToString(), Oreadr["CPT_Family"].ToString(), Oreadr["List_Price"].ToString(),
                        Oreadr["MANIFAC"].ToString(), Oreadr["pref"].ToString());
                if (Tools.Conv_Dbl(Oreadr["500Vdc"].ToString()) > 0) writ_big("2", Oreadr["PHASE"].ToString(), Oreadr["ICB1"].ToString(), "500", Oreadr["500Vdc"].ToString(), Oreadr["Sell_Price"].ToString(),
                        Oreadr["Cost_Price"].ToString(), Oreadr["CPT_Family"].ToString(), Oreadr["List_Price"].ToString(),
                        Oreadr["MANIFAC"].ToString(), Oreadr["pref"].ToString());
                if (Tools.Conv_Dbl(Oreadr["600Vdc"].ToString()) > 0) writ_big("2", Oreadr["PHASE"].ToString(), Oreadr["ICB1"].ToString(), "600", Oreadr["600Vdc"].ToString(), Oreadr["Sell_Price"].ToString(),
                        Oreadr["Cost_Price"].ToString(), Oreadr["CPT_Family"].ToString(), Oreadr["List_Price"].ToString(),
                        Oreadr["MANIFAC"].ToString(), Oreadr["pref"].ToString());
            }
            this.Cursor = Cursors.Default;
            MessageBox.Show("rec#: " + countbig.ToString());
        }

        private void btnImport_Click(object sender, System.EventArgs e)
		{
		    lsave.Text = "Y";
			this.Hide();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
		    lsave.Text = "N";
            this.Hide();
        }

		private void init_feat()
		{
			txf4.Clear();

            txf1.Clear();

            txf2.Clear();

            txf3.Clear();

            //lmodel.Text = "";
            tILT.Text = "04-06";
            tIExt.Clear();
            lvACDCbreaker.Text = "0";
            tIQty.Text = "1";
            tSMRK.Text = "1";
		}

		private void init_lvP600()
		{
			for (int i = 0; i < lvACDCbreaker.Items.Count; i++) lvACDCbreaker.Items[i].Checked = false;
		}

		private void lvP5500_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {

        }

		private void calIOExt()
		{
			double dPU = Tools.Conv_Dbl(tlPU.Text);
			double dQty = Tools.Conv_Dbl(tIQty.Text);
            //tIExt.Text = Convert.ToString(Math.Round(dPU * dQty * Tools.Conv_Dbl(tSMRK.Text), 0));
            tIExt.Text = Convert.ToString(Math.Round(dPU * dQty, 0));
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
		    //calIOExt();
		}

		private void tIExt_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnImport_Click_1(object sender, System.EventArgs e)
		{
            //"Modular Industrial Battery Charger""
            lsave.Text = (txf1.Text != "" && tIExt.Text != "0") ? "Y" : "N";
            this.Hide();
		}

		private void btnCancel_Click_1(object sender, System.EventArgs e)
		{
			lsave.Text = "N";
			this.Hide();
		}

		private void chk3PHS_CheckedChanged(object sender, System.EventArgs e)
		{
			//chktermalP.Checked = chk3PHS.Checked;
		}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void P600_SwitchMD_Load(object sender, EventArgs e)
        {

        }

        private void lvP600_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int ndx = e.Index;

            //else init_feat();
        }

        void Sel_ModelP600(int ndx)
        {
            if (ndx > -1)
            {
                init_feat();
                //MessageBox.Show("nb items=" + lvP600.Items[ndx].SubItems.Count.ToString());
                //lmodel.Text = lvP600fp.Items[ndx].SubItems[1].Text; //: lvP600fp.Items[ndx].SubItems[1].Text;
                txf4.Text = lvACDCbreaker.Items[ndx].SubItems[7].Text;
                txf3.Text = lvACDCbreaker.Items[ndx].SubItems[6].Text;

                txf1.Text = lvACDCbreaker.Items[ndx].SubItems[4].Text;

                txf2.Text = lvACDCbreaker.Items[ndx].SubItems[5].Text;

                //lwar.Visible = (lvP600fp.Items[ndx].SubItems[14].Text == "1");

                lvACDCbreaker.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(lvACDCbreaker.Items[ndx].SubItems[2].Text), MainMDI.NB_DEC_AFF));
            }
        }

        private void lvP600_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvACDCbreaker.SelectedItems.Count > 0) Sel_ModelP600(lvACDCbreaker.SelectedItems[0].Index);
        }

        private void btnphs_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Text = (button1.Text == "3") ? "1" : "3";
            //lPHS.Text = button1.Text;
            //fill_lvP600();
            //init_feat();
        }

        private void Options_brkr_Cfgv2_Load(object sender, EventArgs e)
        {
            if (MainMDI.currDB == "XTT") this.Text = "XXXXXXXXXXXXXXXXXXTT";
            lRecModel.Visible = (MainMDI.User.ToLower() == "ede");
            button2.Visible = (MainMDI.User.ToLower() == "ede");
            //button1.Text = "1"; lPHS.Text = "1";

            //if (in_ACDC == "A")
            //{
                //lvACbreaker.Visible = true;
                //lvDCbreaker.Visible = false;
                //lvACbreaker.Dock = DockStyle.Fill;
            //}
            //else 
            //{
                //lvACbreaker.Visible = false;
                //lvDCbreaker.Visible = true;
                //lvDCbreaker.Dock = DockStyle.Fill;
            //}
            //lvACDCbreaker.BackColor = (in_ACDC == "A") ? Color.Azure : Color.LightBlue;
            if (in_ACDC == "A")
            {
                this.Text = "AC BREAKERS.....";
                lvACDCbreaker.BackColor = Color.Azure;
            }
            else
            {
                this.Text = "DC BREAKERS.....";
                lvACDCbreaker.BackColor = Color.LightBlue;
            }
            fill_lvBreaker();
        }

        void clr_brkr()
        {
            lvACDCbreaker.Text = "0";
            tIQty.Text = "1";
            tIExt.Text = "0";
            txddd.Clear();
            //txf1.Clear();
            //txf2.Clear();
            //txf3.Clear();
            //txf4.Clear();
        }

        void deco_desc(string desc, string pu)
        {
            string[] arr_1234 = new string[] { "n/a", "n/a", "n/a", "n/a" };
            arr_1234 = desc.Split(','); //string[] Vals = QReq.Text.Split('|');
            txf1.Text = arr_1234[0];
            txf2.Text = arr_1234[1];
            txf3.Text = arr_1234[2];
            txf4.Text = arr_1234[3];
            tIQty.Text = "1";
            tlPU.Text = pu;
        }
        private void lvACbreaker_DoubleClick(object sender, EventArgs e)
        {

        }

        private void lvACbreaker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void lvACDCbreaker_DoubleClick(object sender, EventArgs e)
        {
            fill_dcbrkr();
        }

        private void lvACDCbreaker_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        void fill_dcbrkr()
        {
            if (lvACDCbreaker.SelectedItems.Count == 1)
            {
                clr_brkr();

                deco_desc(lvACDCbreaker.SelectedItems[0].SubItems[1].Text, lvACDCbreaker.SelectedItems[0].SubItems[4].Text);

                txddd.Text = lvACDCbreaker.SelectedItems[0].SubItems[1].Text;
                tIQty.Text = "1";
                tlPU.Text = lvACDCbreaker.SelectedItems[0].SubItems[7].Text;
            }
        }

        private void tlPU_TextChanged(object sender, EventArgs e)
        {
            calIOExt();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Gen_CBxx12();
        }
    }
}
