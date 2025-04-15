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
	public class P600_SwitchMD : System.Windows.Forms.Form
	{
		 private static Lib1 Tools = new Lib1();
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnImport;
		public System.Windows.Forms.ListView lvP600;
		private System.Windows.Forms.ColumnHeader colhdr2;
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
		private System.Windows.Forms.ColumnHeader p1;
        private System.Windows.Forms.ColumnHeader p3;
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
        private ColumnHeader war;
        private Label label1;
        public TextBox tapplication;
        private Label lwar;
        public TextBox txRU;
        private Label label10;
        public TextBox txBRU;
        private Label label9;
        public TextBox txInputC;
        private Label label8;
        public TextBox txSubRK;
        private Label label7;
        public TextBox txBlnk;
        private Label label6;
        public TextBox txSHLF;
        private Label label5;
        public TextBox txModnb;
        private Label label3;
        public TextBox txEnc;
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

        public P600_SwitchMD()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		//	fill_lvP5500();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(P600_SwitchMD));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.lmodel = new System.Windows.Forms.Label();
            this.lPHS = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb3PHS = new System.Windows.Forms.ComboBox();
            this.lwar = new System.Windows.Forms.Label();
            this.txRU = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.txBRU = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txInputC = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txSubRK = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txBlnk = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txSHLF = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txModnb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txEnc = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tapplication = new System.Windows.Forms.TextBox();
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
            this.lRecModel = new System.Windows.Forms.Label();
            this.chkEnc = new System.Windows.Forms.CheckBox();
            this.cbEnc = new System.Windows.Forms.ComboBox();
            this.lvP600 = new System.Windows.Forms.ListView();
            this.p3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.p1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.colhdr2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
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
            this.price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.war = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.lmodel);
            this.groupBox1.Controls.Add(this.lPHS);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cb3PHS);
            this.groupBox1.Controls.Add(this.lwar);
            this.groupBox1.Controls.Add(this.txRU);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.txBRU);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.txInputC);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.txSubRK);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.txBlnk);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.txSHLF);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.txModnb);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txEnc);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tapplication);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.lRecModel);
            this.groupBox1.Controls.Add(this.chkEnc);
            this.groupBox1.Controls.Add(this.cbEnc);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(348, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(634, 701);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
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
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // lmodel
            // 
            this.lmodel.BackColor = System.Drawing.Color.Khaki;
            this.lmodel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lmodel.Font = new System.Drawing.Font("Verdana", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmodel.ForeColor = System.Drawing.Color.Black;
            this.lmodel.Location = new System.Drawing.Point(0, 9);
            this.lmodel.Name = "lmodel";
            this.lmodel.Size = new System.Drawing.Size(634, 30);
            this.lmodel.TabIndex = 218;
            this.lmodel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lPHS
            // 
            this.lPHS.BackColor = System.Drawing.Color.AliceBlue;
            this.lPHS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lPHS.Font = new System.Drawing.Font("Verdana", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPHS.ForeColor = System.Drawing.Color.Red;
            this.lPHS.Location = new System.Drawing.Point(331, 590);
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
            this.label4.Location = new System.Drawing.Point(181, 600);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(150, 34);
            this.label4.TabIndex = 216;
            this.label4.Text = "PHASE: ";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cb3PHS
            // 
            this.cb3PHS.BackColor = System.Drawing.Color.Lavender;
            this.cb3PHS.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb3PHS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cb3PHS.Location = new System.Drawing.Point(41, 355);
            this.cb3PHS.Name = "cb3PHS";
            this.cb3PHS.Size = new System.Drawing.Size(136, 21);
            this.cb3PHS.TabIndex = 215;
            this.cb3PHS.Visible = false;
            // 
            // lwar
            // 
            this.lwar.BackColor = System.Drawing.Color.Red;
            this.lwar.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lwar.Font = new System.Drawing.Font("Lucida Fax", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lwar.ForeColor = System.Drawing.Color.White;
            this.lwar.Location = new System.Drawing.Point(191, 314);
            this.lwar.Name = "lwar";
            this.lwar.Size = new System.Drawing.Size(341, 20);
            this.lwar.TabIndex = 214;
            this.lwar.Text = "Warning:  please check Enclosure";
            this.lwar.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lwar.Visible = false;
            // 
            // txRU
            // 
            this.txRU.BackColor = System.Drawing.SystemColors.Control;
            this.txRU.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txRU.ForeColor = System.Drawing.Color.DarkRed;
            this.txRU.Location = new System.Drawing.Point(115, 276);
            this.txRU.MaxLength = 8;
            this.txRU.Name = "txRU";
            this.txRU.ReadOnly = true;
            this.txRU.Size = new System.Drawing.Size(473, 26);
            this.txRU.TabIndex = 213;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.AliceBlue;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(36, 281);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(73, 16);
            this.label10.TabIndex = 212;
            this.label10.Text = "RU";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txBRU
            // 
            this.txBRU.BackColor = System.Drawing.SystemColors.Control;
            this.txBRU.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txBRU.ForeColor = System.Drawing.Color.DarkRed;
            this.txBRU.Location = new System.Drawing.Point(115, 244);
            this.txBRU.MaxLength = 8;
            this.txBRU.Name = "txBRU";
            this.txBRU.ReadOnly = true;
            this.txBRU.Size = new System.Drawing.Size(473, 26);
            this.txBRU.TabIndex = 211;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.AliceBlue;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(36, 249);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(73, 16);
            this.label9.TabIndex = 210;
            this.label9.Text = "Breaker RU";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txInputC
            // 
            this.txInputC.BackColor = System.Drawing.SystemColors.Control;
            this.txInputC.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txInputC.ForeColor = System.Drawing.Color.DarkRed;
            this.txInputC.Location = new System.Drawing.Point(115, 212);
            this.txInputC.MaxLength = 8;
            this.txInputC.Name = "txInputC";
            this.txInputC.ReadOnly = true;
            this.txInputC.Size = new System.Drawing.Size(473, 26);
            this.txInputC.TabIndex = 209;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.AliceBlue;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(36, 217);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(73, 16);
            this.label8.TabIndex = 208;
            this.label8.Text = "Input Current";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txSubRK
            // 
            this.txSubRK.BackColor = System.Drawing.SystemColors.Control;
            this.txSubRK.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txSubRK.ForeColor = System.Drawing.Color.DarkRed;
            this.txSubRK.Location = new System.Drawing.Point(115, 180);
            this.txSubRK.MaxLength = 8;
            this.txSubRK.Name = "txSubRK";
            this.txSubRK.ReadOnly = true;
            this.txSubRK.Size = new System.Drawing.Size(473, 26);
            this.txSubRK.TabIndex = 207;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.AliceBlue;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(36, 185);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 16);
            this.label7.TabIndex = 206;
            this.label7.Text = "Subrack model";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txBlnk
            // 
            this.txBlnk.BackColor = System.Drawing.SystemColors.Control;
            this.txBlnk.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txBlnk.ForeColor = System.Drawing.Color.DarkRed;
            this.txBlnk.Location = new System.Drawing.Point(115, 148);
            this.txBlnk.MaxLength = 8;
            this.txBlnk.Name = "txBlnk";
            this.txBlnk.ReadOnly = true;
            this.txBlnk.Size = new System.Drawing.Size(473, 26);
            this.txBlnk.TabIndex = 205;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.AliceBlue;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(36, 153);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(73, 16);
            this.label6.TabIndex = 204;
            this.label6.Text = "Blank Qty";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txSHLF
            // 
            this.txSHLF.BackColor = System.Drawing.SystemColors.Control;
            this.txSHLF.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txSHLF.ForeColor = System.Drawing.Color.DarkRed;
            this.txSHLF.Location = new System.Drawing.Point(115, 116);
            this.txSHLF.MaxLength = 8;
            this.txSHLF.Name = "txSHLF";
            this.txSHLF.ReadOnly = true;
            this.txSHLF.Size = new System.Drawing.Size(473, 26);
            this.txSHLF.TabIndex = 203;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.AliceBlue;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(-17, 121);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(126, 16);
            this.label5.TabIndex = 202;
            this.label5.Text = "Shelf Qty";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txModnb
            // 
            this.txModnb.BackColor = System.Drawing.SystemColors.Control;
            this.txModnb.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txModnb.ForeColor = System.Drawing.Color.DarkRed;
            this.txModnb.Location = new System.Drawing.Point(115, 84);
            this.txModnb.MaxLength = 8;
            this.txModnb.Name = "txModnb";
            this.txModnb.ReadOnly = true;
            this.txModnb.Size = new System.Drawing.Size(473, 26);
            this.txModnb.TabIndex = 201;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.AliceBlue;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(36, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(73, 16);
            this.label3.TabIndex = 200;
            this.label3.Text = "Modules #";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txEnc
            // 
            this.txEnc.BackColor = System.Drawing.SystemColors.Control;
            this.txEnc.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txEnc.ForeColor = System.Drawing.Color.DarkRed;
            this.txEnc.Location = new System.Drawing.Point(115, 52);
            this.txEnc.MaxLength = 8;
            this.txEnc.Name = "txEnc";
            this.txEnc.ReadOnly = true;
            this.txEnc.Size = new System.Drawing.Size(473, 26);
            this.txEnc.TabIndex = 199;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.AliceBlue;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(36, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(73, 16);
            this.label2.TabIndex = 198;
            this.label2.Text = "Enclosure";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(329, 360);
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
            this.tapplication.Location = new System.Drawing.Point(187, 350);
            this.tapplication.MaxLength = 8;
            this.tapplication.Name = "tapplication";
            this.tapplication.ReadOnly = true;
            this.tapplication.Size = new System.Drawing.Size(136, 26);
            this.tapplication.TabIndex = 184;
            this.tapplication.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tapplication.Visible = false;
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
            this.groupBox2.Location = new System.Drawing.Point(11, 374);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(602, 181);
            this.groupBox2.TabIndex = 183;
            this.groupBox2.TabStop = false;
            // 
            // lsave
            // 
            this.lsave.BackColor = System.Drawing.Color.Brown;
            this.lsave.ForeColor = System.Drawing.Color.Firebrick;
            this.lsave.Location = new System.Drawing.Point(367, 79);
            this.lsave.Name = "lsave";
            this.lsave.Size = new System.Drawing.Size(24, 16);
            this.lsave.TabIndex = 218;
            this.lsave.Visible = false;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.AliceBlue;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label15.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(14, 139);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(115, 24);
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
            this.label14.Location = new System.Drawing.Point(13, 109);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(115, 24);
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
            this.label13.Location = new System.Drawing.Point(13, 82);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(115, 24);
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
            this.label12.Location = new System.Drawing.Point(14, 49);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(115, 24);
            this.label12.TabIndex = 203;
            this.label12.Text = "QTY ";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tIExt
            // 
            this.tIExt.BackColor = System.Drawing.Color.White;
            this.tIExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIExt.ForeColor = System.Drawing.Color.Red;
            this.tIExt.Location = new System.Drawing.Point(129, 109);
            this.tIExt.MaxLength = 49;
            this.tIExt.Multiline = true;
            this.tIExt.Name = "tIExt";
            this.tIExt.ReadOnly = true;
            this.tIExt.Size = new System.Drawing.Size(201, 24);
            this.tIExt.TabIndex = 201;
            this.tIExt.Text = "0";
            this.tIExt.TextChanged += new System.EventHandler(this.tIExt_TextChanged);
            // 
            // tILT
            // 
            this.tILT.BackColor = System.Drawing.Color.White;
            this.tILT.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tILT.ForeColor = System.Drawing.Color.Red;
            this.tILT.Location = new System.Drawing.Point(129, 139);
            this.tILT.MaxLength = 49;
            this.tILT.Multiline = true;
            this.tILT.Name = "tILT";
            this.tILT.Size = new System.Drawing.Size(56, 24);
            this.tILT.TabIndex = 195;
            this.tILT.Text = "04-06";
            // 
            // tSMRK
            // 
            this.tSMRK.BackColor = System.Drawing.Color.White;
            this.tSMRK.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSMRK.ForeColor = System.Drawing.Color.Red;
            this.tSMRK.Location = new System.Drawing.Point(129, 79);
            this.tSMRK.MaxLength = 49;
            this.tSMRK.Name = "tSMRK";
            this.tSMRK.Size = new System.Drawing.Size(56, 24);
            this.tSMRK.TabIndex = 198;
            this.tSMRK.Text = "1";
            this.tSMRK.TextChanged += new System.EventHandler(this.tSMRK_TextChanged);
            // 
            // tIQty
            // 
            this.tIQty.BackColor = System.Drawing.Color.White;
            this.tIQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIQty.ForeColor = System.Drawing.Color.Red;
            this.tIQty.Location = new System.Drawing.Point(129, 49);
            this.tIQty.MaxLength = 49;
            this.tIQty.Name = "tIQty";
            this.tIQty.Size = new System.Drawing.Size(56, 24);
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
            this.label42.Location = new System.Drawing.Point(14, 19);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(115, 24);
            this.label42.TabIndex = 196;
            this.label42.Text = "Unit Cost ";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tIPU
            // 
            this.tIPU.BackColor = System.Drawing.Color.White;
            this.tIPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIPU.ForeColor = System.Drawing.Color.Red;
            this.tIPU.Location = new System.Drawing.Point(129, 19);
            this.tIPU.MaxLength = 49;
            this.tIPU.Name = "tIPU";
            this.tIPU.Size = new System.Drawing.Size(201, 24);
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
            this.btnImport.Location = new System.Drawing.Point(449, 49);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(128, 36);
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
            this.btnCancel.Location = new System.Drawing.Point(449, 93);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 36);
            this.btnCancel.TabIndex = 174;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // lRecModel
            // 
            this.lRecModel.BackColor = System.Drawing.Color.Brown;
            this.lRecModel.ForeColor = System.Drawing.Color.Firebrick;
            this.lRecModel.Location = new System.Drawing.Point(24, 672);
            this.lRecModel.Name = "lRecModel";
            this.lRecModel.Size = new System.Drawing.Size(589, 20);
            this.lRecModel.TabIndex = 182;
            this.lRecModel.Visible = false;
            // 
            // chkEnc
            // 
            this.chkEnc.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkEnc.Checked = true;
            this.chkEnc.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F);
            this.chkEnc.Location = new System.Drawing.Point(408, 352);
            this.chkEnc.Name = "chkEnc";
            this.chkEnc.Size = new System.Drawing.Size(106, 24);
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
            this.cbEnc.Location = new System.Drawing.Point(517, 352);
            this.cbEnc.Name = "cbEnc";
            this.cbEnc.Size = new System.Drawing.Size(96, 21);
            this.cbEnc.TabIndex = 121;
            this.cbEnc.Visible = false;
            // 
            // lvP600
            // 
            this.lvP600.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvP600.AutoArrange = false;
            this.lvP600.BackColor = System.Drawing.Color.Khaki;
            this.lvP600.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lvP600.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.p3,
            this.p1,
            this.colhdr2,
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
            this.price,
            this.war});
            this.lvP600.Dock = System.Windows.Forms.DockStyle.Left;
            this.lvP600.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvP600.ForeColor = System.Drawing.Color.Black;
            this.lvP600.FullRowSelect = true;
            this.lvP600.GridLines = true;
            this.lvP600.Location = new System.Drawing.Point(0, 0);
            this.lvP600.MultiSelect = false;
            this.lvP600.Name = "lvP600";
            this.lvP600.Size = new System.Drawing.Size(348, 701);
            this.lvP600.TabIndex = 115;
            this.lvP600.UseCompatibleStateImageBehavior = false;
            this.lvP600.View = System.Windows.Forms.View.Details;
            this.lvP600.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvP600_ItemCheck);
            this.lvP600.SelectedIndexChanged += new System.EventHandler(this.lvP600_SelectedIndexChanged);
            // 
            // p3
            // 
            this.p3.Text = " SwitchMode P600 MODELS";
            this.p3.Width = 326;
            // 
            // p1
            // 
            this.p1.Text = " SwitchMode P600 MODELS";
            this.p1.Width = 0;
            // 
            // colhdr2
            // 
            this.colhdr2.Text = "";
            this.colhdr2.Width = 0;
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
            // price
            // 
            this.price.Text = "price";
            this.price.Width = 0;
            // 
            // war
            // 
            this.war.Text = "war";
            this.war.Width = 0;
            // 
            // P600_SwitchMD
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(982, 701);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvP600);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "P600_SwitchMD";
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

		public void fill_lvP600()
		{

            
			lvP600.Items.Clear();
            string stSql = "SELECT * FROM PSM_CSU_SwitchMDP600  ORDER BY IDLine";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
			while (Oreadr.Read ())
            {
               // string stout = "";
				ListViewItem lvI = lvP600.Items.Add( Oreadr[1].ToString ());
                for (int i = 2; i < 16 ; i++) lvI.SubItems.Add(Oreadr[i].ToString());
             //   MessageBox.Show("nb items=" + lvI.SubItems.Count.ToString());
			}
            int colON = (lPHS.Text == "3") ? 1 : 0, colOFF = (lPHS.Text == "3") ? 0 : 1;
            lvP600.Columns[colON].Width = 325;
            lvP600.Columns[colOFF].Width = 0;

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
		private void init_feat()
		{
			txBlnk.Clear();
            txBRU.Clear();
            txEnc.Clear();
            txInputC.Clear();
            txModnb.Clear();
            txRU.Clear();
            txSHLF.Clear();
            txSubRK.Clear();
            lmodel.Text = "";
            tILT.Text = "04-06";
            tIExt.Clear();
            tIPU.Text="0";
            tIQty.Text = "1";
            tSMRK.Text = "1";
           
            			
		}
		private void init_lvP600()
		{
			for (int i=0;i<lvP600.Items.Count;i++) lvP600.Items[i].Checked =false;
		
		}

		private void lvP5500_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
        {

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
			//chktermalP.Checked = chk3PHS.Checked ;
		}

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void P600_SwitchMD_Load(object sender, EventArgs e)
        {
            if (MainMDI.currDB == "XTT") this.Text = "XXXXXXXXXXXXXXXXXXTT";
            lRecModel.Visible = (MainMDI.User.ToLower() == "ede");

            button1.Text = "1"; lPHS.Text = "1";
              
            fill_lvP600();
        }

        private void lvP600_ItemCheck(object sender, ItemCheckEventArgs e)
        {
            int ndx = e.Index;

          //  else init_feat();
        }


        void Sel_ModelP600(int ndx)
        {


            if (ndx > -1)
            {

                init_feat();
                //   MessageBox.Show("nb items=" + lvP600.Items[ndx].SubItems.Count.ToString());
                lmodel.Text = (lPHS.Text == "1") ? lvP600.Items[ndx].SubItems[0].Text : lvP600.Items[ndx].SubItems[1].Text;
                txBlnk.Text = lvP600.Items[ndx].SubItems[6].Text;
                txSHLF.Text = lvP600.Items[ndx].SubItems[5].Text;
                txBRU.Text = lvP600.Items[ndx].SubItems[11].Text;
                txEnc.Text = lvP600.Items[ndx].SubItems[2].Text;
                txInputC.Text = (lPHS.Text == "1") ? lvP600.Items[ndx].SubItems[9].Text : lvP600.Items[ndx].SubItems[10].Text;
                txModnb.Text = lvP600.Items[ndx].SubItems[4].Text;
                txRU.Text = lvP600.Items[ndx].SubItems[12].Text;
                txSubRK.Text = lvP600.Items[ndx].SubItems[7].Text;
                lwar.Visible = (lvP600.Items[ndx].SubItems[14].Text == "1");

                tIPU.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(lvP600.Items[ndx].SubItems[13].Text), MainMDI.NB_DEC_AFF)); ;

            }
        }

private void lvP600_SelectedIndexChanged(object sender, EventArgs e)
{
    if (lvP600.SelectedItems.Count >0) Sel_ModelP600(lvP600.SelectedItems[0].Index);
}

private void btnphs_Click(object sender, EventArgs e)
{

}

private void button1_Click(object sender, EventArgs e)
{
    button1.Text = (button1.Text == "3") ? "1" : "3";
    lPHS.Text = button1.Text;
    fill_lvP600();
    init_feat();
}



















	}
}
