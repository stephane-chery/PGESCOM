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
	public class P850xx_MBS : System.Windows.Forms.Form
	{
		private static Lib1 Tools = new Lib1();
        char in_UI;
        string Uname = "Industrial UPS ";

        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnImport;
		public System.Windows.Forms.ListView lvP850;
		private System.Windows.Forms.ColumnHeader colhdr2;
		private System.Windows.Forms.ColumnHeader mdl;
		private System.Windows.Forms.ColumnHeader pu;
		private System.Windows.Forms.ColumnHeader des;
		private System.Windows.Forms.ColumnHeader in_out;
		private System.Windows.Forms.ColumnHeader cabint;
		private System.Windows.Forms.ColumnHeader breakr;
		private System.Windows.Forms.ColumnHeader desgn;
		private System.Windows.Forms.ColumnHeader inrnl;
		private System.Windows.Forms.ColumnHeader lt;
        private System.Windows.Forms.ColumnHeader wei;
        private System.Windows.Forms.ColumnHeader p3;
        public System.Windows.Forms.ComboBox cbEnc;
		public System.Windows.Forms.Label lRecModel;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox tIExt;
        public System.Windows.Forms.TextBox tILT;
        public System.Windows.Forms.TextBox tSMRK;
		public System.Windows.Forms.TextBox tIQty;
		private System.Windows.Forms.Label label42;
        public System.Windows.Forms.TextBox tIPU;
		public System.Windows.Forms.CheckBox chkEnc;
        private Label label1;
        public TextBox tapplication;
        public TextBox txbps;
        private Label label9;
        public TextBox txdes;
        private Label label8;
        public TextBox txbrkr;
        private Label label7;
        public TextBox txcab;
        private Label label5;
        public TextBox txIO;
        private Label label3;
        public TextBox txdesc;
        private Label label2;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label lPHS;
        private Label label4;
        public ComboBox cb3PHS;
        public Label lsave;
        private Button button1;
        public Label lmodel;
        private Label lUname;

        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.Container components = null;

        public P850xx_MBS()
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();
            //fill_lvP5500();

            //
            //TODO: Add any constructor code after InitializeComponent call
            //

            //in_UI = x_UI;
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lUname = new System.Windows.Forms.Label();
            this.lmodel = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lsave = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tIExt = new System.Windows.Forms.TextBox();
            this.tILT = new System.Windows.Forms.TextBox();
            this.tSMRK = new System.Windows.Forms.TextBox();
            this.tIQty = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.tIPU = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.lPHS = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb3PHS = new System.Windows.Forms.ComboBox();
            this.txbps = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txdes = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txbrkr = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txcab = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txIO = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txdesc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tapplication = new System.Windows.Forms.TextBox();
            this.lRecModel = new System.Windows.Forms.Label();
            this.chkEnc = new System.Windows.Forms.CheckBox();
            this.cbEnc = new System.Windows.Forms.ComboBox();
            this.lvP850 = new System.Windows.Forms.ListView();
            this.p3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdr2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pu = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.des = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.in_out = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cabint = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.breakr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.desgn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.inrnl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.wei = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lUname);
            this.groupBox1.Controls.Add(this.lmodel);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lPHS);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cb3PHS);
            this.groupBox1.Controls.Add(this.txbps);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txdes);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txbrkr);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txcab);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txIO);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txdesc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tapplication);
            this.groupBox1.Controls.Add(this.lRecModel);
            this.groupBox1.Controls.Add(this.chkEnc);
            this.groupBox1.Controls.Add(this.cbEnc);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(475, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(990, 728);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // lUname
            // 
            this.lUname.BackColor = System.Drawing.Color.AliceBlue;
            this.lUname.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lUname.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lUname.ForeColor = System.Drawing.Color.Black;
            this.lUname.Location = new System.Drawing.Point(95, 11);
            this.lUname.Name = "lUname";
            this.lUname.Size = new System.Drawing.Size(279, 36);
            this.lUname.TabIndex = 222;
            this.lUname.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lmodel
            // 
            this.lmodel.BackColor = System.Drawing.Color.AliceBlue;
            this.lmodel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lmodel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmodel.ForeColor = System.Drawing.Color.Red;
            this.lmodel.Location = new System.Drawing.Point(378, 11);
            this.lmodel.Name = "lmodel";
            this.lmodel.Size = new System.Drawing.Size(338, 36);
            this.lmodel.TabIndex = 221;
            this.lmodel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lmodel.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lsave);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tIExt);
            this.groupBox2.Controls.Add(this.tILT);
            this.groupBox2.Controls.Add(this.tSMRK);
            this.groupBox2.Controls.Add(this.tIQty);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.tIPU);
            this.groupBox2.Controls.Add(this.btnImport);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Location = new System.Drawing.Point(4, 92);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(606, 209);
            this.groupBox2.TabIndex = 183;
            this.groupBox2.TabStop = false;
            // 
            // lsave
            // 
            this.lsave.BackColor = System.Drawing.Color.Brown;
            this.lsave.ForeColor = System.Drawing.Color.Firebrick;
            this.lsave.Location = new System.Drawing.Point(440, 91);
            this.lsave.Name = "lsave";
            this.lsave.Size = new System.Drawing.Size(29, 19);
            this.lsave.TabIndex = 218;
            this.lsave.Visible = false;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.AliceBlue;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label15.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(17, 160);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(138, 28);
            this.label15.TabIndex = 206;
            this.label15.Text = "Lead Time ";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.AliceBlue;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label14.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(16, 126);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(138, 27);
            this.label14.TabIndex = 205;
            this.label14.Text = "Sell Price ";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.AliceBlue;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(16, 95);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(138, 27);
            this.label13.TabIndex = 204;
            this.label13.Text = "Markup ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.AliceBlue;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label12.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(17, 57);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(138, 27);
            this.label12.TabIndex = 203;
            this.label12.Text = "QTY ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tIExt
            // 
            this.tIExt.BackColor = System.Drawing.Color.White;
            this.tIExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIExt.ForeColor = System.Drawing.Color.Red;
            this.tIExt.Location = new System.Drawing.Point(155, 126);
            this.tIExt.MaxLength = 49;
            this.tIExt.Multiline = true;
            this.tIExt.Name = "tIExt";
            this.tIExt.ReadOnly = true;
            this.tIExt.Size = new System.Drawing.Size(241, 27);
            this.tIExt.TabIndex = 201;
            this.tIExt.Text = "0";
            this.tIExt.TextChanged += new System.EventHandler(this.tIExt_TextChanged);
            // 
            // tILT
            // 
            this.tILT.BackColor = System.Drawing.Color.White;
            this.tILT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tILT.ForeColor = System.Drawing.Color.Red;
            this.tILT.Location = new System.Drawing.Point(155, 160);
            this.tILT.MaxLength = 49;
            this.tILT.Multiline = true;
            this.tILT.Name = "tILT";
            this.tILT.Size = new System.Drawing.Size(67, 28);
            this.tILT.TabIndex = 195;
            // 
            // tSMRK
            // 
            this.tSMRK.BackColor = System.Drawing.Color.White;
            this.tSMRK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSMRK.ForeColor = System.Drawing.Color.Red;
            this.tSMRK.Location = new System.Drawing.Point(155, 91);
            this.tSMRK.MaxLength = 49;
            this.tSMRK.Name = "tSMRK";
            this.tSMRK.Size = new System.Drawing.Size(67, 29);
            this.tSMRK.TabIndex = 198;
            this.tSMRK.Text = "1";
            this.tSMRK.TextChanged += new System.EventHandler(this.tSMRK_TextChanged);
            // 
            // tIQty
            // 
            this.tIQty.BackColor = System.Drawing.Color.White;
            this.tIQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIQty.ForeColor = System.Drawing.Color.Red;
            this.tIQty.Location = new System.Drawing.Point(155, 57);
            this.tIQty.MaxLength = 49;
            this.tIQty.Name = "tIQty";
            this.tIQty.Size = new System.Drawing.Size(67, 29);
            this.tIQty.TabIndex = 194;
            this.tIQty.Text = "1";
            this.tIQty.TextChanged += new System.EventHandler(this.tIQty_TextChanged);
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.Color.AliceBlue;
            this.label42.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label42.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label42.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label42.Location = new System.Drawing.Point(17, 22);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(138, 28);
            this.label42.TabIndex = 196;
            this.label42.Text = "Unit Cost ";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tIPU
            // 
            this.tIPU.BackColor = System.Drawing.Color.White;
            this.tIPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIPU.ForeColor = System.Drawing.Color.Red;
            this.tIPU.Location = new System.Drawing.Point(155, 22);
            this.tIPU.MaxLength = 49;
            this.tIPU.Name = "tIPU";
            this.tIPU.Size = new System.Drawing.Size(241, 29);
            this.tIPU.TabIndex = 193;
            this.tIPU.Text = "0";
            this.tIPU.TextChanged += new System.EventHandler(this.tIPU_TextChanged);
            // 
            // btnImport
            // 
            this.btnImport.BackColor = System.Drawing.Color.PeachPuff;
            this.btnImport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(428, 42);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(153, 41);
            this.btnImport.TabIndex = 173;
            this.btnImport.Text = "&OK";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.PeachPuff;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(428, 99);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(153, 42);
            this.btnCancel.TabIndex = 174;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Khaki;
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(16, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(57, 58);
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
            this.lPHS.Location = new System.Drawing.Point(491, 527);
            this.lPHS.Name = "lPHS";
            this.lPHS.Size = new System.Drawing.Size(48, 62);
            this.lPHS.TabIndex = 217;
            this.lPHS.Text = "3";
            this.lPHS.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lPHS.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.AliceBlue;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(13, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 29);
            this.label4.TabIndex = 216;
            this.label4.Text = "PHS";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label4.Visible = false;
            // 
            // cb3PHS
            // 
            this.cb3PHS.BackColor = System.Drawing.Color.Lavender;
            this.cb3PHS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb3PHS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cb3PHS.Location = new System.Drawing.Point(49, 410);
            this.cb3PHS.Name = "cb3PHS";
            this.cb3PHS.Size = new System.Drawing.Size(163, 24);
            this.cb3PHS.TabIndex = 215;
            this.cb3PHS.Visible = false;
            // 
            // txbps
            // 
            this.txbps.BackColor = System.Drawing.SystemColors.Control;
            this.txbps.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txbps.ForeColor = System.Drawing.Color.DarkRed;
            this.txbps.Location = new System.Drawing.Point(244, 586);
            this.txbps.MaxLength = 8;
            this.txbps.Name = "txbps";
            this.txbps.ReadOnly = true;
            this.txbps.Size = new System.Drawing.Size(462, 30);
            this.txbps.TabIndex = 211;
            this.txbps.Visible = false;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.AliceBlue;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(30, 591);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(208, 18);
            this.label9.TabIndex = 210;
            this.label9.Text = "Internal bypass switch";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Visible = false;
            // 
            // txdes
            // 
            this.txdes.BackColor = System.Drawing.SystemColors.Control;
            this.txdes.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txdes.ForeColor = System.Drawing.Color.DarkRed;
            this.txdes.Location = new System.Drawing.Point(244, 553);
            this.txdes.MaxLength = 8;
            this.txdes.Name = "txdes";
            this.txdes.ReadOnly = true;
            this.txdes.Size = new System.Drawing.Size(462, 30);
            this.txdes.TabIndex = 209;
            this.txdes.Visible = false;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.AliceBlue;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(64, 558);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(174, 19);
            this.label8.TabIndex = 208;
            this.label8.Text = "Charger design";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label8.Visible = false;
            // 
            // txbrkr
            // 
            this.txbrkr.BackColor = System.Drawing.SystemColors.Control;
            this.txbrkr.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txbrkr.ForeColor = System.Drawing.Color.DarkRed;
            this.txbrkr.Location = new System.Drawing.Point(245, 523);
            this.txbrkr.MaxLength = 8;
            this.txbrkr.Name = "txbrkr";
            this.txbrkr.ReadOnly = true;
            this.txbrkr.Size = new System.Drawing.Size(462, 30);
            this.txbrkr.TabIndex = 207;
            this.txbrkr.Visible = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.AliceBlue;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(14, 527);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(228, 19);
            this.label7.TabIndex = 206;
            this.label7.Text = "Breakers";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Visible = false;
            // 
            // txcab
            // 
            this.txcab.BackColor = System.Drawing.SystemColors.Control;
            this.txcab.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txcab.ForeColor = System.Drawing.Color.DarkRed;
            this.txcab.Location = new System.Drawing.Point(244, 490);
            this.txcab.MaxLength = 8;
            this.txcab.Name = "txcab";
            this.txcab.ReadOnly = true;
            this.txcab.Size = new System.Drawing.Size(463, 30);
            this.txcab.TabIndex = 203;
            this.txcab.Visible = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.AliceBlue;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(18, 496);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(222, 18);
            this.label5.TabIndex = 202;
            this.label5.Text = "Cabinet";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Visible = false;
            // 
            // txIO
            // 
            this.txIO.BackColor = System.Drawing.SystemColors.Control;
            this.txIO.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txIO.ForeColor = System.Drawing.Color.DarkRed;
            this.txIO.Location = new System.Drawing.Point(244, 458);
            this.txIO.MaxLength = 8;
            this.txIO.Name = "txIO";
            this.txIO.ReadOnly = true;
            this.txIO.Size = new System.Drawing.Size(463, 30);
            this.txIO.TabIndex = 201;
            this.txIO.Visible = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.AliceBlue;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(12, 463);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(230, 19);
            this.label3.TabIndex = 200;
            this.label3.Text = "Input/output/bypass voltages";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label3.Visible = false;
            // 
            // txdesc
            // 
            this.txdesc.BackColor = System.Drawing.SystemColors.Control;
            this.txdesc.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txdesc.ForeColor = System.Drawing.Color.DarkRed;
            this.txdesc.Location = new System.Drawing.Point(147, 60);
            this.txdesc.MaxLength = 8;
            this.txdesc.Name = "txdesc";
            this.txdesc.ReadOnly = true;
            this.txdesc.Size = new System.Drawing.Size(463, 30);
            this.txdesc.TabIndex = 199;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.AliceBlue;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(19, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 17);
            this.label2.TabIndex = 198;
            this.label2.Text = "Description";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(395, 415);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 19);
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
            this.tapplication.Location = new System.Drawing.Point(224, 404);
            this.tapplication.MaxLength = 8;
            this.tapplication.Name = "tapplication";
            this.tapplication.ReadOnly = true;
            this.tapplication.Size = new System.Drawing.Size(164, 30);
            this.tapplication.TabIndex = 184;
            this.tapplication.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tapplication.Visible = false;
            // 
            // lRecModel
            // 
            this.lRecModel.BackColor = System.Drawing.Color.Brown;
            this.lRecModel.ForeColor = System.Drawing.Color.Firebrick;
            this.lRecModel.Location = new System.Drawing.Point(29, 775);
            this.lRecModel.Name = "lRecModel";
            this.lRecModel.Size = new System.Drawing.Size(707, 23);
            this.lRecModel.TabIndex = 182;
            this.lRecModel.Visible = false;
            // 
            // chkEnc
            // 
            this.chkEnc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnc.Checked = true;
            this.chkEnc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkEnc.Location = new System.Drawing.Point(490, 406);
            this.chkEnc.Name = "chkEnc";
            this.chkEnc.Size = new System.Drawing.Size(127, 28);
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
            this.cbEnc.Location = new System.Drawing.Point(620, 406);
            this.cbEnc.Name = "cbEnc";
            this.cbEnc.Size = new System.Drawing.Size(116, 23);
            this.cbEnc.TabIndex = 121;
            this.cbEnc.Visible = false;
            // 
            // lvP850
            // 
            this.lvP850.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvP850.AutoArrange = false;
            this.lvP850.BackColor = System.Drawing.Color.PeachPuff;
            this.lvP850.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvP850.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.p3,
            this.colhdr2,
            this.mdl,
            this.pu,
            this.des,
            this.in_out,
            this.cabint,
            this.breakr,
            this.desgn,
            this.inrnl,
            this.lt,
            this.wei});
            this.lvP850.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvP850.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvP850.ForeColor = System.Drawing.Color.Black;
            this.lvP850.FullRowSelect = true;
            this.lvP850.GridLines = true;
            this.lvP850.HideSelection = false;
            this.lvP850.Location = new System.Drawing.Point(0, 0);
            this.lvP850.MultiSelect = false;
            this.lvP850.Name = "lvP850";
            this.lvP850.Size = new System.Drawing.Size(475, 728);
            this.lvP850.TabIndex = 115;
            this.lvP850.UseCompatibleStateImageBehavior = false;
            this.lvP850.View = System.Windows.Forms.View.Details;
            this.lvP850.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvP600_ItemCheck);
            this.lvP850.SelectedIndexChanged += new System.EventHandler(this.lvP600_SelectedIndexChanged);
            // 
            // p3
            // 
            this.p3.Text = " MBS Models";
            this.p3.Width = 405;
            // 
            // colhdr2
            // 
            this.colhdr2.Text = "";
            this.colhdr2.Width = 0;
            // 
            // mdl
            // 
            this.mdl.Text = "";
            this.mdl.Width = 0;
            // 
            // pu
            // 
            this.pu.Text = "";
            this.pu.Width = 0;
            // 
            // des
            // 
            this.des.Text = "";
            this.des.Width = 0;
            // 
            // in_out
            // 
            this.in_out.Text = "";
            this.in_out.Width = 0;
            // 
            // cabint
            // 
            this.cabint.Text = "";
            this.cabint.Width = 0;
            // 
            // breakr
            // 
            this.breakr.Text = "";
            this.breakr.Width = 0;
            // 
            // desgn
            // 
            this.desgn.Text = "";
            this.desgn.Width = 0;
            // 
            // inrnl
            // 
            this.inrnl.Text = "";
            this.inrnl.Width = 0;
            // 
            // lt
            // 
            this.lt.Text = "";
            this.lt.Width = 0;
            // 
            // wei
            // 
            this.wei.Text = "";
            this.wei.Width = 0;
            // 
            // P850xx_MBS
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1465, 728);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvP850);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "P850xx_MBS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SwitchMode P600";
            this.Load += new System.EventHandler(this.P600_SwitchMD_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		public void fill_lvMBS()
		{
            //string psm = (in_UI == 'U') ? "PSM_CSU_P850u_" : "PSM_CSU_P850i_";

            lvP850.Items.Clear();
            string stSql = "SELECT * FROM PSM_CSU_MBS ORDER BY IDLine";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
			while (Oreadr.Read())
            {
                //string stout = "";
				ListViewItem lvI = lvP850.Items.Add(Oreadr[1].ToString());
                lvI.SubItems.Add(Oreadr[0].ToString());
                lvI.SubItems.Add(Oreadr[1].ToString());
                lvI.SubItems.Add(Oreadr[2].ToString());
                for (int i = 3; i < 12; i++) lvI.SubItems.Add(" ");
            }
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


        //va sélectionner la date de livraison pour le MBS
        public static string LeadTime()
        {
            string leadtime = "";
            string stSql = "SELECT * FROM Chargers_DeliveryDate WHERE charger = @charger";
            //object users;

            //SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
            // OConn.Open();

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.Parameters.AddWithValue("@charger", "MBS");
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                leadtime = Oreadr["leadTime"].ToString();
            }
            return leadtime;
        }

        private void init_feat()
		{
			//txBlnk.Clear();
            txbps.Clear();
            txdesc.Clear();
            txdes.Clear();
            txIO.Clear();
            //txRU.Clear();
            txcab.Clear();
            txbrkr.Clear();
            lmodel.Text = "";
            tILT.Text = LeadTime();
            tIExt.Clear();
            tIPU.Text = "0";
            tIQty.Text = "1";
            tSMRK.Text = "1";
		}

		private void init_lvP600()
		{
			for (int i = 0; i < lvP850.Items.Count; i++) lvP850.Items[i].Checked = false;
		}

		private void lvP5500_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {

        }

		private void calIOExt()
		{
			double dPU = Tools.Conv_Dbl(tIPU.Text);
			double dQty = Tools.Conv_Dbl(tIQty.Text);
			tIExt.Text = Convert.ToString(Math.Round(dPU * dQty * Tools.Conv_Dbl(tSMRK.Text), MainMDI.NB_DEC_AFF));
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
            //"Modular Industrial Battery Charger""
            lsave.Text = (lmodel.Text != "" && tIExt.Text != "0") ? "Y" : "N";
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
            if (MainMDI.currDB == "XTT") this.Text = "XXXXXXXXXXXXXXXXXXTT";
            lRecModel.Visible = (MainMDI.User.ToLower() == "ede");

            button1.Text = "1"; lPHS.Text = "1";

            //if (in_UI=='U')
            //{
                //lvP850.Columns[0].Text = "UPS Models";
                //lUname.Text = "Industrial UPS ";
            //}
            //else
            //{
                //lvP850.Columns[0].Text = "INVERTER Models";
                //lUname.Text = "Industrial INVERTER ";
            //}
            fill_lvMBS();
        }

        private void lvP600_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int ndx = e.Index;

            //else init_feat();
        }

        void Sel_ModelMBS(int ndx)
        {
            if (ndx > -1)
            {
                init_feat();
                txdesc.Text = lvP850.Items[ndx].SubItems[0].Text;
                lmodel.Text = lvP850.Items[ndx].SubItems[0].Text;

                //MessageBox.Show("nb items=" + lvP600.Items[ndx].SubItems.Count.ToString());
                //lmodel.Text = lvP850.Items[ndx].SubItems[0].Text;
                //lmodel.Text = lvP850.Items[ndx].SubItems[1].Text;
                //lmodel.Text = lvP850.Items[ndx].SubItems[3].Text;
                ////lmodel.Text = Uname + lvP850.Items[ndx].SubItems[2].Text;
                //txcab.Text = lvP850.Items[ndx].SubItems[6].Text;
                //txbps.Text = lvP850.Items[ndx].SubItems[9].Text;

                //txdes.Text = lvP850.Items[ndx].SubItems[8].Text;
                //txIO.Text = lvP850.Items[ndx].SubItems[5].Text;
                //txbrkr.Text = lvP850.Items[ndx].SubItems[7].Text;
                //tILT.Text = lvP850.Items[ndx].SubItems[10].Text;

                tIPU.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(lvP850.Items[ndx].SubItems[3].Text), 0));
            }
        }

        private void lvP600_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvP850.SelectedItems.Count == 1) Sel_ModelMBS(lvP850.SelectedItems[0].Index);
        }

        private void btnphs_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //button1.Text = (button1.Text == "3") ? "1" : "3";
            //lPHS.Text = button1.Text;
            //fill_lvUPS();
            //init_feat();
        }
	}
}