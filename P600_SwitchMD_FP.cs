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
	public class P600_SwitchMD_FP : System.Windows.Forms.Form
	{
		private static Lib1 Tools = new Lib1();
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnImport;
		public System.Windows.Forms.ListView lvP600fp;
		private System.Windows.Forms.ColumnHeader f1;
		private System.Windows.Forms.ColumnHeader f2;
		private System.Windows.Forms.ColumnHeader f3;
		private System.Windows.Forms.ColumnHeader f4;
		private System.Windows.Forms.ColumnHeader f5;
		private System.Windows.Forms.ColumnHeader f6;
		private System.Windows.Forms.ColumnHeader p1;
        private System.Windows.Forms.ColumnHeader mdl;
        public System.Windows.Forms.ComboBox cbEnc;
		private System.Windows.Forms.ColumnHeader price;
		public System.Windows.Forms.Label lRecModel;
        private System.Windows.Forms.GroupBox groupBox2;
        public System.Windows.Forms.TextBox tIExt;
        public System.Windows.Forms.TextBox tILT;
        public System.Windows.Forms.TextBox tSMRK;
		public System.Windows.Forms.TextBox tIQty;
		private System.Windows.Forms.Label label42;
        public System.Windows.Forms.TextBox tIPU;
		public System.Windows.Forms.CheckBox chkEnc;
        private ColumnHeader phs;
        private Label label1;
        public TextBox tapplication;
        private Label lwar;
        private Label label9;
        private Label label8;
        private Label label7;
        public TextBox txf4;
        private Label label6;
        public TextBox txf3;
        private Label label5;
        public TextBox txf2;
        private Label label3;
        public TextBox txf1;
        private Label label2;
        private Label label15;
        private Label label14;
        private Label label13;
        private Label label12;
        private Label lPHS;
        private Label label4;
        public ComboBox cb3PHS;
        public Label lsave;
        public Label lmodel;
        private Button button1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public P600_SwitchMD_FP()
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();
		    //fill_lvP5500();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P600_SwitchMD_FP));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lmodel = new System.Windows.Forms.Label();
            this.lPHS = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb3PHS = new System.Windows.Forms.ComboBox();
            this.lwar = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txf4 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txf3 = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txf2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txf1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tapplication = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label13 = new System.Windows.Forms.Label();
            this.lsave = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tIExt = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tILT = new System.Windows.Forms.TextBox();
            this.tSMRK = new System.Windows.Forms.TextBox();
            this.tIQty = new System.Windows.Forms.TextBox();
            this.label42 = new System.Windows.Forms.Label();
            this.tIPU = new System.Windows.Forms.TextBox();
            this.btnImport = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.lRecModel = new System.Windows.Forms.Label();
            this.chkEnc = new System.Windows.Forms.CheckBox();
            this.cbEnc = new System.Windows.Forms.ComboBox();
            this.lvP600fp = new System.Windows.Forms.ListView();
            this.p1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.f1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.f2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.f3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.f4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.f5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.f6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.LemonChiffon;
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lmodel);
            this.groupBox1.Controls.Add(this.lPHS);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cb3PHS);
            this.groupBox1.Controls.Add(this.lwar);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txf4);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txf3);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txf2);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txf1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tapplication);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lRecModel);
            this.groupBox1.Controls.Add(this.chkEnc);
            this.groupBox1.Controls.Add(this.cbEnc);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(482, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(660, 489);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.Khaki;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold);
            this.button1.Location = new System.Drawing.Point(398, 681);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 64);
            this.button1.TabIndex = 220;
            this.button1.Text = "3";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lmodel
            // 
            this.lmodel.BackColor = System.Drawing.Color.Lavender;
            this.lmodel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lmodel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmodel.ForeColor = System.Drawing.Color.Black;
            this.lmodel.Location = new System.Drawing.Point(0, 10);
            this.lmodel.Name = "lmodel";
            this.lmodel.Size = new System.Drawing.Size(761, 35);
            this.lmodel.TabIndex = 218;
            this.lmodel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lPHS
            // 
            this.lPHS.BackColor = System.Drawing.Color.AliceBlue;
            this.lPHS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lPHS.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPHS.ForeColor = System.Drawing.Color.Red;
            this.lPHS.Location = new System.Drawing.Point(397, 681);
            this.lPHS.Name = "lPHS";
            this.lPHS.Size = new System.Drawing.Size(48, 63);
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
            this.label4.Location = new System.Drawing.Point(217, 692);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(180, 40);
            this.label4.TabIndex = 216;
            this.label4.Text = "PHASE: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Visible = false;
            // 
            // cb3PHS
            // 
            this.cb3PHS.BackColor = System.Drawing.Color.Lavender;
            this.cb3PHS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb3PHS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cb3PHS.Location = new System.Drawing.Point(41, 636);
            this.cb3PHS.Name = "cb3PHS";
            this.cb3PHS.Size = new System.Drawing.Size(163, 24);
            this.cb3PHS.TabIndex = 215;
            this.cb3PHS.Visible = false;
            // 
            // lwar
            // 
            this.lwar.BackColor = System.Drawing.Color.Red;
            this.lwar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lwar.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lwar.ForeColor = System.Drawing.Color.White;
            this.lwar.Location = new System.Drawing.Point(221, 588);
            this.lwar.Name = "lwar";
            this.lwar.Size = new System.Drawing.Size(409, 24);
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
            this.label8.Location = new System.Drawing.Point(65, 625);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(87, 19);
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
            this.label7.Location = new System.Drawing.Point(65, 588);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(87, 19);
            this.label7.TabIndex = 206;
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label7.Visible = false;
            // 
            // txf4
            // 
            this.txf4.BackColor = System.Drawing.SystemColors.Control;
            this.txf4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txf4.ForeColor = System.Drawing.Color.DarkRed;
            this.txf4.Location = new System.Drawing.Point(138, 171);
            this.txf4.MaxLength = 8;
            this.txf4.Name = "txf4";
            this.txf4.ReadOnly = true;
            this.txf4.Size = new System.Drawing.Size(568, 30);
            this.txf4.TabIndex = 205;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.LemonChiffon;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(43, 177);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 18);
            this.label6.TabIndex = 204;
            this.label6.Text = "#4";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txf3
            // 
            this.txf3.BackColor = System.Drawing.SystemColors.Control;
            this.txf3.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txf3.ForeColor = System.Drawing.Color.DarkRed;
            this.txf3.Location = new System.Drawing.Point(138, 134);
            this.txf3.MaxLength = 8;
            this.txf3.Name = "txf3";
            this.txf3.ReadOnly = true;
            this.txf3.Size = new System.Drawing.Size(568, 30);
            this.txf3.TabIndex = 203;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.LemonChiffon;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(-20, 140);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(151, 18);
            this.label5.TabIndex = 202;
            this.label5.Text = "#3";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txf2
            // 
            this.txf2.BackColor = System.Drawing.SystemColors.Control;
            this.txf2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txf2.ForeColor = System.Drawing.Color.DarkRed;
            this.txf2.Location = new System.Drawing.Point(138, 97);
            this.txf2.MaxLength = 8;
            this.txf2.Name = "txf2";
            this.txf2.ReadOnly = true;
            this.txf2.Size = new System.Drawing.Size(568, 30);
            this.txf2.TabIndex = 201;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.LemonChiffon;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(43, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 18);
            this.label3.TabIndex = 200;
            this.label3.Text = "#2";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txf1
            // 
            this.txf1.BackColor = System.Drawing.SystemColors.Control;
            this.txf1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txf1.ForeColor = System.Drawing.Color.DarkRed;
            this.txf1.Location = new System.Drawing.Point(138, 60);
            this.txf1.MaxLength = 8;
            this.txf1.Name = "txf1";
            this.txf1.ReadOnly = true;
            this.txf1.Size = new System.Drawing.Size(568, 30);
            this.txf1.TabIndex = 199;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.LemonChiffon;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(43, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 18);
            this.label2.TabIndex = 198;
            this.label2.Text = "#1";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(386, 642);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 18);
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
            this.tapplication.Location = new System.Drawing.Point(216, 630);
            this.tapplication.MaxLength = 8;
            this.tapplication.Name = "tapplication";
            this.tapplication.ReadOnly = true;
            this.tapplication.Size = new System.Drawing.Size(163, 30);
            this.tapplication.TabIndex = 184;
            this.tapplication.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tapplication.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.lsave);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.tIExt);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.tILT);
            this.groupBox2.Controls.Add(this.tSMRK);
            this.groupBox2.Controls.Add(this.tIQty);
            this.groupBox2.Controls.Add(this.label42);
            this.groupBox2.Controls.Add(this.tIPU);
            this.groupBox2.Controls.Add(this.btnImport);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Location = new System.Drawing.Point(32, 219);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(723, 209);
            this.groupBox2.TabIndex = 183;
            this.groupBox2.TabStop = false;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.LemonChiffon;
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
            // lsave
            // 
            this.lsave.BackColor = System.Drawing.Color.Brown;
            this.lsave.ForeColor = System.Drawing.Color.Firebrick;
            this.lsave.Location = new System.Drawing.Point(422, 168);
            this.lsave.Name = "lsave";
            this.lsave.Size = new System.Drawing.Size(29, 19);
            this.lsave.TabIndex = 218;
            this.lsave.Visible = false;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.LemonChiffon;
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
            this.label14.BackColor = System.Drawing.Color.LemonChiffon;
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
            // label12
            // 
            this.label12.BackColor = System.Drawing.Color.LemonChiffon;
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
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.LemonChiffon;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(528, 170);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(88, 18);
            this.label9.TabIndex = 210;
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label9.Visible = false;
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
            this.label42.BackColor = System.Drawing.Color.LemonChiffon;
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
            this.btnImport.Location = new System.Drawing.Point(444, 57);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(248, 41);
            this.btnImport.TabIndex = 173;
            this.btnImport.Text = "OK";
            this.btnImport.UseVisualStyleBackColor = false;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click_1);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.PeachPuff;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(444, 107);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(248, 42);
            this.btnCancel.TabIndex = 174;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
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
            this.chkEnc.Location = new System.Drawing.Point(481, 632);
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
            this.cbEnc.Location = new System.Drawing.Point(612, 632);
            this.cbEnc.Name = "cbEnc";
            this.cbEnc.Size = new System.Drawing.Size(115, 23);
            this.cbEnc.TabIndex = 121;
            this.cbEnc.Visible = false;
            // 
            // lvP600fp
            // 
            this.lvP600fp.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvP600fp.AutoArrange = false;
            this.lvP600fp.BackColor = System.Drawing.Color.Azure;
            this.lvP600fp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvP600fp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.p1,
            this.mdl,
            this.price,
            this.phs,
            this.f1,
            this.f2,
            this.f3,
            this.f4,
            this.f5,
            this.f6});
            this.lvP600fp.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvP600fp.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvP600fp.ForeColor = System.Drawing.Color.Red;
            this.lvP600fp.FullRowSelect = true;
            this.lvP600fp.GridLines = true;
            this.lvP600fp.HideSelection = false;
            this.lvP600fp.Location = new System.Drawing.Point(0, 0);
            this.lvP600fp.MultiSelect = false;
            this.lvP600fp.Name = "lvP600fp";
            this.lvP600fp.Size = new System.Drawing.Size(482, 489);
            this.lvP600fp.TabIndex = 115;
            this.lvP600fp.UseCompatibleStateImageBehavior = false;
            this.lvP600fp.View = System.Windows.Forms.View.Details;
            this.lvP600fp.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvP600_ItemCheck);
            this.lvP600fp.SelectedIndexChanged += new System.EventHandler(this.lvP600_SelectedIndexChanged);
            // 
            // p1
            // 
            this.p1.Text = "id";
            this.p1.Width = 0;
            // 
            // mdl
            // 
            this.mdl.Text = " SwitchMode P600 Flex Power models";
            this.mdl.Width = 369;
            // 
            // price
            // 
            this.price.Text = "price";
            this.price.Width = 0;
            // 
            // phs
            // 
            this.phs.Text = "";
            this.phs.Width = 0;
            // 
            // f1
            // 
            this.f1.Text = "";
            this.f1.Width = 0;
            // 
            // f2
            // 
            this.f2.Text = "";
            this.f2.Width = 0;
            // 
            // f3
            // 
            this.f3.Text = "";
            this.f3.Width = 0;
            // 
            // f4
            // 
            this.f4.Text = "";
            this.f4.Width = 0;
            // 
            // f5
            // 
            this.f5.Text = "";
            this.f5.Width = 0;
            // 
            // f6
            // 
            this.f6.Text = "";
            this.f6.Width = 0;
            // 
            // P600_SwitchMD_FP
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(1142, 489);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvP600fp);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "P600_SwitchMD_FP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SwitchMode P600 Flex Power";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
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

		public void fill_lvP600_FP()
		{
			lvP600fp.Items.Clear();
            string stSql = "SELECT * FROM PSM_CSU_SwitchMDP600_FP  ORDER BY fpModel";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
			while (Oreadr.Read())
            {
                //string stout = "";
				ListViewItem lvI = lvP600fp.Items.Add(Oreadr[0].ToString());
                for (int i = 1; i < 9; i++) lvI.SubItems.Add(Oreadr[i].ToString());
                //MessageBox.Show("nb items=" + lvI.SubItems.Count.ToString());
			}
            //int colON = (lPHS.Text == "3") ? 1 : 0, colOFF = (lPHS.Text == "3") ? 0 : 1;
            //lvP600fp.Columns[colON].Width = 325;
            //lvP600fp.Columns[colOFF].Width = 0;
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

        //va sélectionner la date de livraison pour le P600 Flex
        //va sélectionner la date de livraison pour les P4600 et P4500
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
            Ocmd.Parameters.AddWithValue("@charger", "P600-Flex");
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
			txf4.Clear();

            txf1.Clear();

            txf2.Clear();

            txf3.Clear();

            lmodel.Text = "";
            tILT.Text = LeadTime();
            tIExt.Clear();
            tIPU.Text = "0";
            tIQty.Text = "1";
            tSMRK.Text = "1";
		}

		private void init_lvP600()
		{
			for (int i = 0; i < lvP600fp.Items.Count; i++) lvP600fp.Items[i].Checked = false;
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

            fill_lvP600_FP();
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
                lmodel.Text = lvP600fp.Items[ndx].SubItems[1].Text; //: lvP600fp.Items[ndx].SubItems[1].Text;
                txf4.Text = lvP600fp.Items[ndx].SubItems[7].Text;
                txf3.Text = lvP600fp.Items[ndx].SubItems[6].Text;

                txf1.Text = lvP600fp.Items[ndx].SubItems[4].Text;

                txf2.Text = lvP600fp.Items[ndx].SubItems[5].Text;

                //lwar.Visible = (lvP600fp.Items[ndx].SubItems[14].Text == "1");

                tIPU.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(lvP600fp.Items[ndx].SubItems[2].Text), MainMDI.NB_DEC_AFF));
            }
        }

        private void lvP600_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvP600fp.SelectedItems.Count > 0) Sel_ModelP600(lvP600fp.SelectedItems[0].Index);
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
	}
}