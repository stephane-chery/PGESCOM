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
	/// Summary description for PbsInfo.
	/// </summary>
	public class PbsInfo : System.Windows.Forms.Form
	{
        private Lib1 Tools = new Lib1();
        private char In_CBR;
		private string In_CellNB;
		public bool SaveOK = false;

		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label37;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.GroupBox grpbat;
		private System.Windows.Forms.GroupBox grprack;
		public System.Windows.Forms.TextBox tbDim;
		public System.Windows.Forms.TextBox tbPrice;
		public System.Windows.Forms.TextBox tbWaran;
		public System.Windows.Forms.TextBox tbCapa;
		public System.Windows.Forms.TextBox tbName;
		public System.Windows.Forms.TextBox tbType;
		public System.Windows.Forms.TextBox trNBcell;
		public System.Windows.Forms.TextBox trPrice;
		public System.Windows.Forms.TextBox trDim;
		private System.Windows.Forms.Label lblVide;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox grpCab;
		private System.Windows.Forms.Label label23;
		public System.Windows.Forms.TextBox tcNBCell;
		public System.Windows.Forms.TextBox tc2TPrice;
		public System.Windows.Forms.TextBox tc1TPrice;
		public System.Windows.Forms.TextBox tcPrice;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label7;
		public System.Windows.Forms.TextBox tccolor;
		private System.Windows.Forms.Label label8;
		public System.Windows.Forms.TextBox tcDim;
		private System.Windows.Forms.Label label9;
		public System.Windows.Forms.TextBox tcModel;
		public System.Windows.Forms.TextBox trModel;
		public System.Windows.Forms.TextBox tc1Tstep;
		public System.Windows.Forms.TextBox tc2Tstep;
		public System.Windows.Forms.TextBox tcstpUP;
		public System.Windows.Forms.TextBox tcQtyCab;
		public System.Windows.Forms.TextBox tcextCab;
		private System.Windows.Forms.Label label17;
		public System.Windows.Forms.CheckBox chkprint;
		public System.Windows.Forms.TextBox tbExt;
		public System.Windows.Forms.TextBox tbNBcell;
		private System.Windows.Forms.Label label28;
		public System.Windows.Forms.TextBox tbLT;
		private System.Windows.Forms.Label label29;
		public System.Windows.Forms.TextBox trLT;
		private System.Windows.Forms.Label label30;
		private System.Windows.Forms.Label label32;
		public System.Windows.Forms.TextBox trQty;
		public System.Windows.Forms.TextBox trExt;
		private System.Windows.Forms.Label label31;
		public System.Windows.Forms.TextBox chRcellNB;
		private System.Windows.Forms.Label lblT2;
		private System.Windows.Forms.Label lblT1;
		private System.Windows.Forms.Label lCArea;
		private System.Windows.Forms.Label lRefArea;
		private System.Windows.Forms.Label lRefName;
		public System.Windows.Forms.Label lcetat;
		public System.Windows.Forms.TextBox textBox6;
		public System.Windows.Forms.TextBox tIf1;
		private System.Windows.Forms.Label lGext;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label33;
		private System.Windows.Forms.Label label34;
		private System.Windows.Forms.Label label35;
		private System.Windows.Forms.Label label40;
		private System.Windows.Forms.Label label19;
		public System.Windows.Forms.TextBox tcITExt;
		public System.Windows.Forms.TextBox tcITQty;
		public System.Windows.Forms.TextBox tcITup;
		public System.Windows.Forms.TextBox tcBTBExt;
		public System.Windows.Forms.TextBox tcBTBQty;
		public System.Windows.Forms.TextBox tcBTBup;
		public System.Windows.Forms.TextBox tcstpUP2;
		public System.Windows.Forms.TextBox tbICExt;
		public System.Windows.Forms.TextBox tbICQty;
		public System.Windows.Forms.TextBox tbICup;
		public System.Windows.Forms.TextBox tbELExt;
		public System.Windows.Forms.TextBox tbELQty;
		public System.Windows.Forms.TextBox tbELup;
		public System.Windows.Forms.TextBox tcLT;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox tbRack;
		private System.Windows.Forms.Label label24;
		public System.Windows.Forms.TextBox tsysnb;
		private System.Windows.Forms.Label label16;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PbsInfo(char CBR, string x_CellNB)
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();
			In_CBR = CBR;
			In_CellNB = x_CellNB;
			switch (CBR)
			{
				case 'C':
				    fill_Cab();
					break;
				case 'c':
					if (!grpCab.Visible) grpCab.Visible = true;
					init_Cab();
					tcNBCell.Text = In_CellNB;
					tcLT.Text = "4";
					tcQtyCab.Text = "1";
					break;
				case 'B':
					fill_Bat();
					break;
				case 'R':
					fill_Rack();
					break;
			}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PbsInfo));
            this.grpbat = new System.Windows.Forms.GroupBox();
            this.label24 = new System.Windows.Forms.Label();
            this.tsysnb = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tbRack = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.tbELExt = new System.Windows.Forms.TextBox();
            this.tbELQty = new System.Windows.Forms.TextBox();
            this.tbELup = new System.Windows.Forms.TextBox();
            this.tbICExt = new System.Windows.Forms.TextBox();
            this.tbICQty = new System.Windows.Forms.TextBox();
            this.tbICup = new System.Windows.Forms.TextBox();
            this.label28 = new System.Windows.Forms.Label();
            this.tbLT = new System.Windows.Forms.TextBox();
            this.tbExt = new System.Windows.Forms.TextBox();
            this.tbNBcell = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.tbDim = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.tbPrice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tbWaran = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tbCapa = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.tbType = new System.Windows.Forms.TextBox();
            this.grprack = new System.Windows.Forms.GroupBox();
            this.label31 = new System.Windows.Forms.Label();
            this.chRcellNB = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.trExt = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.trQty = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.trLT = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.trNBcell = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label10 = new System.Windows.Forms.Label();
            this.trPrice = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.trDim = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.trModel = new System.Windows.Forms.TextBox();
            this.lblVide = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpCab = new System.Windows.Forms.GroupBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label40 = new System.Windows.Forms.Label();
            this.tcstpUP2 = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.tcBTBExt = new System.Windows.Forms.TextBox();
            this.tcBTBQty = new System.Windows.Forms.TextBox();
            this.tcBTBup = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.tcITExt = new System.Windows.Forms.TextBox();
            this.tcITQty = new System.Windows.Forms.TextBox();
            this.tcITup = new System.Windows.Forms.TextBox();
            this.lcetat = new System.Windows.Forms.Label();
            this.lRefName = new System.Windows.Forms.Label();
            this.lRefArea = new System.Windows.Forms.Label();
            this.lCArea = new System.Windows.Forms.Label();
            this.chkprint = new System.Windows.Forms.CheckBox();
            this.label17 = new System.Windows.Forms.Label();
            this.tcLT = new System.Windows.Forms.TextBox();
            this.tcextCab = new System.Windows.Forms.TextBox();
            this.tcQtyCab = new System.Windows.Forms.TextBox();
            this.tcstpUP = new System.Windows.Forms.TextBox();
            this.label23 = new System.Windows.Forms.Label();
            this.tcNBCell = new System.Windows.Forms.TextBox();
            this.tc2TPrice = new System.Windows.Forms.TextBox();
            this.tc1TPrice = new System.Windows.Forms.TextBox();
            this.tcPrice = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.lblT2 = new System.Windows.Forms.Label();
            this.tc2Tstep = new System.Windows.Forms.TextBox();
            this.lblT1 = new System.Windows.Forms.Label();
            this.tc1Tstep = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tccolor = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tcDim = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tcModel = new System.Windows.Forms.TextBox();
            this.tIf1 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.lGext = new System.Windows.Forms.Label();
            this.grpbat.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grprack.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.grpCab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // grpbat
            // 
            this.grpbat.Controls.Add(this.label24);
            this.grpbat.Controls.Add(this.tsysnb);
            this.grpbat.Controls.Add(this.label4);
            this.grpbat.Controls.Add(this.tbRack);
            this.grpbat.Controls.Add(this.label19);
            this.grpbat.Controls.Add(this.label21);
            this.grpbat.Controls.Add(this.label6);
            this.grpbat.Controls.Add(this.label3);
            this.grpbat.Controls.Add(this.tbELExt);
            this.grpbat.Controls.Add(this.tbELQty);
            this.grpbat.Controls.Add(this.tbELup);
            this.grpbat.Controls.Add(this.tbICExt);
            this.grpbat.Controls.Add(this.tbICQty);
            this.grpbat.Controls.Add(this.tbICup);
            this.grpbat.Controls.Add(this.label28);
            this.grpbat.Controls.Add(this.tbLT);
            this.grpbat.Controls.Add(this.tbExt);
            this.grpbat.Controls.Add(this.tbNBcell);
            this.grpbat.Controls.Add(this.label11);
            this.grpbat.Controls.Add(this.label15);
            this.grpbat.Controls.Add(this.tbDim);
            this.grpbat.Controls.Add(this.pictureBox1);
            this.grpbat.Controls.Add(this.tbPrice);
            this.grpbat.Controls.Add(this.label5);
            this.grpbat.Controls.Add(this.tbWaran);
            this.grpbat.Controls.Add(this.label2);
            this.grpbat.Controls.Add(this.tbCapa);
            this.grpbat.Controls.Add(this.label1);
            this.grpbat.Controls.Add(this.tbName);
            this.grpbat.Controls.Add(this.label37);
            this.grpbat.Controls.Add(this.tbType);
            this.grpbat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpbat.Location = new System.Drawing.Point(32, 48);
            this.grpbat.Name = "grpbat";
            this.grpbat.Size = new System.Drawing.Size(352, 304);
            this.grpbat.TabIndex = 95;
            this.grpbat.TabStop = false;
            this.grpbat.Visible = false;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.SystemColors.Control;
            this.label24.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.Color.Blue;
            this.label24.Location = new System.Drawing.Point(16, 184);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(112, 24);
            this.label24.TabIndex = 149;
            this.label24.Text = "System #:";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsysnb
            // 
            this.tsysnb.BackColor = System.Drawing.Color.Lavender;
            this.tsysnb.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsysnb.ForeColor = System.Drawing.Color.Maroon;
            this.tsysnb.Location = new System.Drawing.Point(128, 180);
            this.tsysnb.MaxLength = 3;
            this.tsysnb.Name = "tsysnb";
            this.tsysnb.Size = new System.Drawing.Size(40, 26);
            this.tsysnb.TabIndex = 148;
            this.tsysnb.Text = "1";
            this.tsysnb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tsysnb.TextChanged += new System.EventHandler(this.tsysnb_TextChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(12, 154);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 16);
            this.label4.TabIndex = 147;
            this.label4.Text = "Batt. Rack:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbRack
            // 
            this.tbRack.BackColor = System.Drawing.Color.Lavender;
            this.tbRack.ForeColor = System.Drawing.Color.Maroon;
            this.tbRack.Location = new System.Drawing.Point(68, 152);
            this.tbRack.MaxLength = 100;
            this.tbRack.Name = "tbRack";
            this.tbRack.Size = new System.Drawing.Size(172, 20);
            this.tbRack.TabIndex = 146;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Red;
            this.label19.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label19.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label19.Location = new System.Drawing.Point(0, 216);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(352, 18);
            this.label19.TabIndex = 144;
            this.label19.Text = "                          Unit #        U Price          TOTAL";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.SystemColors.Control;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(32, 276);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(56, 16);
            this.label21.TabIndex = 121;
            this.label21.Text = "End Lugs:";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(32, 256);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(56, 16);
            this.label6.TabIndex = 120;
            this.label6.Text = "Inter Cell:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(8, 236);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 16);
            this.label3.TabIndex = 119;
            this.label3.Text = "Cells / Blocks #:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbELExt
            // 
            this.tbELExt.BackColor = System.Drawing.Color.Lavender;
            this.tbELExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbELExt.ForeColor = System.Drawing.Color.Maroon;
            this.tbELExt.Location = new System.Drawing.Point(220, 274);
            this.tbELExt.MaxLength = 49;
            this.tbELExt.Name = "tbELExt";
            this.tbELExt.ReadOnly = true;
            this.tbELExt.Size = new System.Drawing.Size(112, 20);
            this.tbELExt.TabIndex = 118;
            this.tbELExt.Text = "0";
            this.tbELExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbELQty
            // 
            this.tbELQty.BackColor = System.Drawing.Color.Lavender;
            this.tbELQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbELQty.ForeColor = System.Drawing.Color.Maroon;
            this.tbELQty.Location = new System.Drawing.Point(88, 274);
            this.tbELQty.MaxLength = 49;
            this.tbELQty.Name = "tbELQty";
            this.tbELQty.Size = new System.Drawing.Size(76, 20);
            this.tbELQty.TabIndex = 117;
            this.tbELQty.Text = "2";
            this.tbELQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbELQty.TextChanged += new System.EventHandler(this.tbELQty_TextChanged);
            this.tbELQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbELQty_KeyPress);
            // 
            // tbELup
            // 
            this.tbELup.BackColor = System.Drawing.Color.Lavender;
            this.tbELup.ForeColor = System.Drawing.Color.Maroon;
            this.tbELup.Location = new System.Drawing.Point(164, 274);
            this.tbELup.MaxLength = 49;
            this.tbELup.Name = "tbELup";
            this.tbELup.Size = new System.Drawing.Size(56, 20);
            this.tbELup.TabIndex = 116;
            this.tbELup.Text = "0";
            this.tbELup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbELup.TextChanged += new System.EventHandler(this.tbELup_TextChanged);
            this.tbELup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbELup_KeyPress);
            // 
            // tbICExt
            // 
            this.tbICExt.BackColor = System.Drawing.Color.Lavender;
            this.tbICExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbICExt.ForeColor = System.Drawing.Color.Maroon;
            this.tbICExt.Location = new System.Drawing.Point(220, 254);
            this.tbICExt.MaxLength = 49;
            this.tbICExt.Name = "tbICExt";
            this.tbICExt.ReadOnly = true;
            this.tbICExt.Size = new System.Drawing.Size(112, 20);
            this.tbICExt.TabIndex = 115;
            this.tbICExt.Text = "0";
            this.tbICExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tbICQty
            // 
            this.tbICQty.BackColor = System.Drawing.Color.Lavender;
            this.tbICQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbICQty.ForeColor = System.Drawing.Color.Maroon;
            this.tbICQty.Location = new System.Drawing.Point(88, 254);
            this.tbICQty.MaxLength = 49;
            this.tbICQty.Name = "tbICQty";
            this.tbICQty.Size = new System.Drawing.Size(76, 20);
            this.tbICQty.TabIndex = 114;
            this.tbICQty.Text = "0";
            this.tbICQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbICQty.TextChanged += new System.EventHandler(this.tbICQty_TextChanged);
            this.tbICQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbICQty_KeyPress);
            // 
            // tbICup
            // 
            this.tbICup.BackColor = System.Drawing.Color.Lavender;
            this.tbICup.ForeColor = System.Drawing.Color.Maroon;
            this.tbICup.Location = new System.Drawing.Point(164, 254);
            this.tbICup.MaxLength = 49;
            this.tbICup.Name = "tbICup";
            this.tbICup.Size = new System.Drawing.Size(56, 20);
            this.tbICup.TabIndex = 113;
            this.tbICup.Text = "0";
            this.tbICup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbICup.TextChanged += new System.EventHandler(this.tbICup_TextChanged);
            this.tbICup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbICup_KeyPress);
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.SystemColors.Control;
            this.label28.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label28.Location = new System.Drawing.Point(240, 155);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(56, 16);
            this.label28.TabIndex = 112;
            this.label28.Text = "Lead Time:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbLT
            // 
            this.tbLT.BackColor = System.Drawing.SystemColors.Control;
            this.tbLT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tbLT.Location = new System.Drawing.Point(296, 152);
            this.tbLT.MaxLength = 5;
            this.tbLT.Name = "tbLT";
            this.tbLT.ReadOnly = true;
            this.tbLT.Size = new System.Drawing.Size(43, 20);
            this.tbLT.TabIndex = 111;
            this.tbLT.Text = "12-14";
            this.tbLT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbLT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbLT_KeyPress);
            // 
            // tbExt
            // 
            this.tbExt.BackColor = System.Drawing.Color.Lavender;
            this.tbExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbExt.ForeColor = System.Drawing.Color.Maroon;
            this.tbExt.Location = new System.Drawing.Point(220, 234);
            this.tbExt.MaxLength = 49;
            this.tbExt.Name = "tbExt";
            this.tbExt.ReadOnly = true;
            this.tbExt.Size = new System.Drawing.Size(112, 20);
            this.tbExt.TabIndex = 109;
            this.tbExt.Text = "0";
            this.tbExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tbExt.TextChanged += new System.EventHandler(this.tbExt_TextChanged);
            // 
            // tbNBcell
            // 
            this.tbNBcell.BackColor = System.Drawing.Color.Lavender;
            this.tbNBcell.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbNBcell.ForeColor = System.Drawing.Color.Maroon;
            this.tbNBcell.Location = new System.Drawing.Point(88, 234);
            this.tbNBcell.MaxLength = 49;
            this.tbNBcell.Name = "tbNBcell";
            this.tbNBcell.Size = new System.Drawing.Size(76, 20);
            this.tbNBcell.TabIndex = 107;
            this.tbNBcell.Text = "0";
            this.tbNBcell.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbNBcell.TextChanged += new System.EventHandler(this.tbNBcell_TextChanged);
            this.tbNBcell.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbNBcell_KeyPress);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.Blue;
            this.label11.Location = new System.Drawing.Point(136, 24);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(120, 24);
            this.label11.TabIndex = 106;
            this.label11.Text = "BATTERIES";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(4, 114);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(64, 16);
            this.label15.TabIndex = 105;
            this.label15.Text = "Dimensions:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbDim
            // 
            this.tbDim.BackColor = System.Drawing.Color.Lavender;
            this.tbDim.ForeColor = System.Drawing.Color.Maroon;
            this.tbDim.Location = new System.Drawing.Point(68, 112);
            this.tbDim.MaxLength = 100;
            this.tbDim.Name = "tbDim";
            this.tbDim.Size = new System.Drawing.Size(272, 20);
            this.tbDim.TabIndex = 104;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(8, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(48, 48);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox1.TabIndex = 103;
            this.pictureBox1.TabStop = false;
            // 
            // tbPrice
            // 
            this.tbPrice.BackColor = System.Drawing.Color.Lavender;
            this.tbPrice.ForeColor = System.Drawing.Color.Maroon;
            this.tbPrice.Location = new System.Drawing.Point(164, 234);
            this.tbPrice.MaxLength = 49;
            this.tbPrice.Name = "tbPrice";
            this.tbPrice.Size = new System.Drawing.Size(56, 20);
            this.tbPrice.TabIndex = 101;
            this.tbPrice.Text = "0";
            this.tbPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tbPrice.TextChanged += new System.EventHandler(this.tbPrice_TextChanged);
            this.tbPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbPrice_KeyPress);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(12, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 16);
            this.label5.TabIndex = 100;
            this.label5.Text = "Warranty:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbWaran
            // 
            this.tbWaran.BackColor = System.Drawing.Color.Lavender;
            this.tbWaran.ForeColor = System.Drawing.Color.Maroon;
            this.tbWaran.Location = new System.Drawing.Point(68, 132);
            this.tbWaran.MaxLength = 100;
            this.tbWaran.Name = "tbWaran";
            this.tbWaran.Size = new System.Drawing.Size(272, 20);
            this.tbWaran.TabIndex = 99;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(20, 94);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(48, 16);
            this.label2.TabIndex = 98;
            this.label2.Text = "Capacity:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbCapa
            // 
            this.tbCapa.BackColor = System.Drawing.Color.Lavender;
            this.tbCapa.ForeColor = System.Drawing.Color.Maroon;
            this.tbCapa.Location = new System.Drawing.Point(68, 92);
            this.tbCapa.MaxLength = 100;
            this.tbCapa.Name = "tbCapa";
            this.tbCapa.Size = new System.Drawing.Size(272, 20);
            this.tbCapa.TabIndex = 97;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(20, 74);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 16);
            this.label1.TabIndex = 96;
            this.label1.Text = "Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbName
            // 
            this.tbName.BackColor = System.Drawing.Color.Lavender;
            this.tbName.ForeColor = System.Drawing.Color.Maroon;
            this.tbName.Location = new System.Drawing.Point(68, 72);
            this.tbName.MaxLength = 100;
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(272, 20);
            this.tbName.TabIndex = 95;
            // 
            // label37
            // 
            this.label37.BackColor = System.Drawing.SystemColors.Control;
            this.label37.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label37.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label37.Location = new System.Drawing.Point(28, 54);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(40, 16);
            this.label37.TabIndex = 94;
            this.label37.Text = "Type:";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tbType
            // 
            this.tbType.BackColor = System.Drawing.Color.Lavender;
            this.tbType.ForeColor = System.Drawing.Color.Maroon;
            this.tbType.Location = new System.Drawing.Point(68, 52);
            this.tbType.MaxLength = 100;
            this.tbType.Name = "tbType";
            this.tbType.Size = new System.Drawing.Size(271, 20);
            this.tbType.TabIndex = 93;
            // 
            // grprack
            // 
            this.grprack.Controls.Add(this.label31);
            this.grprack.Controls.Add(this.chRcellNB);
            this.grprack.Controls.Add(this.label32);
            this.grprack.Controls.Add(this.trExt);
            this.grprack.Controls.Add(this.label30);
            this.grprack.Controls.Add(this.trQty);
            this.grprack.Controls.Add(this.label29);
            this.grprack.Controls.Add(this.trLT);
            this.grprack.Controls.Add(this.label22);
            this.grprack.Controls.Add(this.trNBcell);
            this.grprack.Controls.Add(this.label12);
            this.grprack.Controls.Add(this.pictureBox3);
            this.grprack.Controls.Add(this.label10);
            this.grprack.Controls.Add(this.trPrice);
            this.grprack.Controls.Add(this.label13);
            this.grprack.Controls.Add(this.trDim);
            this.grprack.Controls.Add(this.label14);
            this.grprack.Controls.Add(this.trModel);
            this.grprack.Location = new System.Drawing.Point(16, 80);
            this.grprack.Name = "grprack";
            this.grprack.Size = new System.Drawing.Size(384, 160);
            this.grprack.TabIndex = 96;
            this.grprack.TabStop = false;
            this.grprack.Visible = false;
            // 
            // label31
            // 
            this.label31.BackColor = System.Drawing.SystemColors.Control;
            this.label31.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label31.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label31.ForeColor = System.Drawing.Color.Green;
            this.label31.Location = new System.Drawing.Point(160, 34);
            this.label31.Name = "label31";
            this.label31.Size = new System.Drawing.Size(120, 16);
            this.label31.TabIndex = 113;
            this.label31.Text = "Choosed Rack Unit #:";
            this.label31.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chRcellNB
            // 
            this.chRcellNB.BackColor = System.Drawing.Color.Lavender;
            this.chRcellNB.ForeColor = System.Drawing.Color.Red;
            this.chRcellNB.Location = new System.Drawing.Point(280, 32);
            this.chRcellNB.MaxLength = 49;
            this.chRcellNB.Name = "chRcellNB";
            this.chRcellNB.Size = new System.Drawing.Size(56, 20);
            this.chRcellNB.TabIndex = 112;
            // 
            // label32
            // 
            this.label32.BackColor = System.Drawing.SystemColors.Control;
            this.label32.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label32.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label32.Location = new System.Drawing.Point(200, 114);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(32, 16);
            this.label32.TabIndex = 111;
            this.label32.Text = "Ext:";
            this.label32.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trExt
            // 
            this.trExt.BackColor = System.Drawing.Color.Lavender;
            this.trExt.ForeColor = System.Drawing.Color.Red;
            this.trExt.Location = new System.Drawing.Point(232, 112);
            this.trExt.MaxLength = 49;
            this.trExt.Name = "trExt";
            this.trExt.ReadOnly = true;
            this.trExt.Size = new System.Drawing.Size(104, 20);
            this.trExt.TabIndex = 110;
            this.trExt.TextChanged += new System.EventHandler(this.trExt_TextChanged);
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.SystemColors.Control;
            this.label30.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(120, 114);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(24, 16);
            this.label30.TabIndex = 107;
            this.label30.Text = "Qty:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trQty
            // 
            this.trQty.BackColor = System.Drawing.Color.Lavender;
            this.trQty.ForeColor = System.Drawing.Color.Red;
            this.trQty.Location = new System.Drawing.Point(144, 112);
            this.trQty.MaxLength = 49;
            this.trQty.Name = "trQty";
            this.trQty.Size = new System.Drawing.Size(56, 20);
            this.trQty.TabIndex = 106;
            this.trQty.TextChanged += new System.EventHandler(this.trQty_TextChanged);
            this.trQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.trQty_KeyPress);
            // 
            // label29
            // 
            this.label29.BackColor = System.Drawing.SystemColors.Control;
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label29.Location = new System.Drawing.Point(8, 134);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(56, 16);
            this.label29.TabIndex = 105;
            this.label29.Text = "Lead Time:";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trLT
            // 
            this.trLT.BackColor = System.Drawing.SystemColors.Control;
            this.trLT.ForeColor = System.Drawing.SystemColors.ControlText;
            this.trLT.Location = new System.Drawing.Point(64, 132);
            this.trLT.MaxLength = 49;
            this.trLT.Name = "trLT";
            this.trLT.ReadOnly = true;
            this.trLT.Size = new System.Drawing.Size(40, 20);
            this.trLT.TabIndex = 104;
            this.trLT.Text = "04-06";
            this.trLT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.trLT_KeyPress);
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Green;
            this.label22.Location = new System.Drawing.Point(192, 54);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(88, 16);
            this.label22.TabIndex = 103;
            this.label22.Text = "Charger Cell #:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trNBcell
            // 
            this.trNBcell.BackColor = System.Drawing.Color.Lavender;
            this.trNBcell.ForeColor = System.Drawing.Color.Red;
            this.trNBcell.Location = new System.Drawing.Point(280, 52);
            this.trNBcell.MaxLength = 49;
            this.trNBcell.Name = "trNBcell";
            this.trNBcell.Size = new System.Drawing.Size(56, 20);
            this.trNBcell.TabIndex = 102;
            this.trNBcell.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.trNBcell_KeyPress);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label12.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.Blue;
            this.label12.Location = new System.Drawing.Point(80, 24);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 40);
            this.label12.TabIndex = 101;
            this.label12.Text = "RACK";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox3
            // 
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(8, 16);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(64, 48);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 100;
            this.pictureBox3.TabStop = false;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(16, 114);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(48, 16);
            this.label10.TabIndex = 99;
            this.label10.Text = "Price:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trPrice
            // 
            this.trPrice.BackColor = System.Drawing.Color.Lavender;
            this.trPrice.ForeColor = System.Drawing.Color.Red;
            this.trPrice.Location = new System.Drawing.Point(64, 112);
            this.trPrice.MaxLength = 49;
            this.trPrice.Name = "trPrice";
            this.trPrice.Size = new System.Drawing.Size(56, 20);
            this.trPrice.TabIndex = 98;
            this.trPrice.TextChanged += new System.EventHandler(this.trPrice_TextChanged);
            this.trPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.trPrice_KeyPress);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(8, 94);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(56, 16);
            this.label13.TabIndex = 97;
            this.label13.Text = "Dimensions:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trDim
            // 
            this.trDim.BackColor = System.Drawing.Color.Lavender;
            this.trDim.ForeColor = System.Drawing.Color.Red;
            this.trDim.Location = new System.Drawing.Point(64, 92);
            this.trDim.MaxLength = 49;
            this.trDim.Name = "trDim";
            this.trDim.Size = new System.Drawing.Size(272, 20);
            this.trDim.TabIndex = 96;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(24, 74);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(40, 16);
            this.label14.TabIndex = 95;
            this.label14.Text = "Model:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // trModel
            // 
            this.trModel.BackColor = System.Drawing.Color.Lavender;
            this.trModel.ForeColor = System.Drawing.Color.Red;
            this.trModel.Location = new System.Drawing.Point(64, 72);
            this.trModel.MaxLength = 49;
            this.trModel.Name = "trModel";
            this.trModel.Size = new System.Drawing.Size(272, 20);
            this.trModel.TabIndex = 94;
            // 
            // lblVide
            // 
            this.lblVide.BackColor = System.Drawing.Color.Black;
            this.lblVide.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblVide.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lblVide.Location = new System.Drawing.Point(8, 32);
            this.lblVide.Name = "lblVide";
            this.lblVide.Size = new System.Drawing.Size(408, 208);
            this.lblVide.TabIndex = 105;
            this.lblVide.Text = "EMPTY CHOICE                                  (Please use PBSIZING)";
            this.lblVide.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lblVide.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(200, 360);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 24);
            this.btnCancel.TabIndex = 120;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(64, 360);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(128, 24);
            this.btnOK.TabIndex = 119;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // grpCab
            // 
            this.grpCab.Controls.Add(this.label16);
            this.grpCab.Controls.Add(this.label40);
            this.grpCab.Controls.Add(this.tcstpUP2);
            this.grpCab.Controls.Add(this.label35);
            this.grpCab.Controls.Add(this.label34);
            this.grpCab.Controls.Add(this.tcBTBExt);
            this.grpCab.Controls.Add(this.tcBTBQty);
            this.grpCab.Controls.Add(this.tcBTBup);
            this.grpCab.Controls.Add(this.label33);
            this.grpCab.Controls.Add(this.tcITExt);
            this.grpCab.Controls.Add(this.tcITQty);
            this.grpCab.Controls.Add(this.tcITup);
            this.grpCab.Controls.Add(this.lcetat);
            this.grpCab.Controls.Add(this.lRefName);
            this.grpCab.Controls.Add(this.lRefArea);
            this.grpCab.Controls.Add(this.lCArea);
            this.grpCab.Controls.Add(this.chkprint);
            this.grpCab.Controls.Add(this.label17);
            this.grpCab.Controls.Add(this.tcLT);
            this.grpCab.Controls.Add(this.tcextCab);
            this.grpCab.Controls.Add(this.tcQtyCab);
            this.grpCab.Controls.Add(this.tcstpUP);
            this.grpCab.Controls.Add(this.label23);
            this.grpCab.Controls.Add(this.tcNBCell);
            this.grpCab.Controls.Add(this.tc2TPrice);
            this.grpCab.Controls.Add(this.tc1TPrice);
            this.grpCab.Controls.Add(this.tcPrice);
            this.grpCab.Controls.Add(this.label18);
            this.grpCab.Controls.Add(this.pictureBox2);
            this.grpCab.Controls.Add(this.lblT2);
            this.grpCab.Controls.Add(this.tc2Tstep);
            this.grpCab.Controls.Add(this.lblT1);
            this.grpCab.Controls.Add(this.tc1Tstep);
            this.grpCab.Controls.Add(this.label7);
            this.grpCab.Controls.Add(this.tccolor);
            this.grpCab.Controls.Add(this.label8);
            this.grpCab.Controls.Add(this.tcDim);
            this.grpCab.Controls.Add(this.label9);
            this.grpCab.Controls.Add(this.tcModel);
            this.grpCab.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpCab.Location = new System.Drawing.Point(32, 24);
            this.grpCab.Name = "grpCab";
            this.grpCab.Size = new System.Drawing.Size(360, 264);
            this.grpCab.TabIndex = 121;
            this.grpCab.TabStop = false;
            this.grpCab.Visible = false;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Red;
            this.label16.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label16.Location = new System.Drawing.Point(4, 119);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(352, 18);
            this.label16.TabIndex = 145;
            this.label16.Text = "                     Unit #        U Price          TOTAL";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label40
            // 
            this.label40.BackColor = System.Drawing.SystemColors.Control;
            this.label40.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label40.Location = new System.Drawing.Point(8, 138);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(64, 16);
            this.label40.TabIndex = 144;
            this.label40.Text = "Cabinet(s):";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tcstpUP2
            // 
            this.tcstpUP2.BackColor = System.Drawing.Color.Lavender;
            this.tcstpUP2.ForeColor = System.Drawing.Color.Red;
            this.tcstpUP2.Location = new System.Drawing.Point(148, 176);
            this.tcstpUP2.MaxLength = 49;
            this.tcstpUP2.Name = "tcstpUP2";
            this.tcstpUP2.Size = new System.Drawing.Size(56, 20);
            this.tcstpUP2.TabIndex = 143;
            this.tcstpUP2.Text = "196";
            this.tcstpUP2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tcstpUP2.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcstpUP2_KeyPress);
            // 
            // label35
            // 
            this.label35.BackColor = System.Drawing.SystemColors.Control;
            this.label35.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label35.ForeColor = System.Drawing.Color.OliveDrab;
            this.label35.Location = new System.Drawing.Point(8, 236);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(112, 16);
            this.label35.TabIndex = 139;
            this.label35.Text = "(Battery Terminal Block)";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.SystemColors.Control;
            this.label34.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(8, 218);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(64, 16);
            this.label34.TabIndex = 138;
            this.label34.Text = "B.T.B:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tcBTBExt
            // 
            this.tcBTBExt.BackColor = System.Drawing.Color.Lavender;
            this.tcBTBExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcBTBExt.ForeColor = System.Drawing.Color.Red;
            this.tcBTBExt.Location = new System.Drawing.Point(204, 216);
            this.tcBTBExt.MaxLength = 49;
            this.tcBTBExt.Name = "tcBTBExt";
            this.tcBTBExt.ReadOnly = true;
            this.tcBTBExt.Size = new System.Drawing.Size(112, 20);
            this.tcBTBExt.TabIndex = 137;
            this.tcBTBExt.Text = "0";
            this.tcBTBExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tcBTBQty
            // 
            this.tcBTBQty.BackColor = System.Drawing.Color.Lavender;
            this.tcBTBQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcBTBQty.ForeColor = System.Drawing.Color.Red;
            this.tcBTBQty.Location = new System.Drawing.Point(72, 216);
            this.tcBTBQty.MaxLength = 49;
            this.tcBTBQty.Name = "tcBTBQty";
            this.tcBTBQty.Size = new System.Drawing.Size(76, 20);
            this.tcBTBQty.TabIndex = 136;
            this.tcBTBQty.Text = "0";
            this.tcBTBQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tcBTBQty.TextChanged += new System.EventHandler(this.tcBTBQty_TextChanged);
            this.tcBTBQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcBTBQty_KeyPress);
            // 
            // tcBTBup
            // 
            this.tcBTBup.BackColor = System.Drawing.Color.Lavender;
            this.tcBTBup.ForeColor = System.Drawing.Color.Red;
            this.tcBTBup.Location = new System.Drawing.Point(148, 216);
            this.tcBTBup.MaxLength = 49;
            this.tcBTBup.Name = "tcBTBup";
            this.tcBTBup.Size = new System.Drawing.Size(56, 20);
            this.tcBTBup.TabIndex = 135;
            this.tcBTBup.Text = "0";
            this.tcBTBup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tcBTBup.TextChanged += new System.EventHandler(this.tcBTBup_TextChanged);
            this.tcBTBup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcBTBup_KeyPress);
            // 
            // label33
            // 
            this.label33.BackColor = System.Drawing.SystemColors.Control;
            this.label33.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label33.Location = new System.Drawing.Point(16, 198);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(56, 16);
            this.label33.TabIndex = 134;
            this.label33.Text = "Inter Tiers:";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tcITExt
            // 
            this.tcITExt.BackColor = System.Drawing.Color.Lavender;
            this.tcITExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcITExt.ForeColor = System.Drawing.Color.Red;
            this.tcITExt.Location = new System.Drawing.Point(204, 196);
            this.tcITExt.MaxLength = 49;
            this.tcITExt.Name = "tcITExt";
            this.tcITExt.ReadOnly = true;
            this.tcITExt.Size = new System.Drawing.Size(112, 20);
            this.tcITExt.TabIndex = 133;
            this.tcITExt.Text = "0";
            this.tcITExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tcITQty
            // 
            this.tcITQty.BackColor = System.Drawing.Color.Lavender;
            this.tcITQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcITQty.ForeColor = System.Drawing.Color.Red;
            this.tcITQty.Location = new System.Drawing.Point(72, 196);
            this.tcITQty.MaxLength = 49;
            this.tcITQty.Name = "tcITQty";
            this.tcITQty.Size = new System.Drawing.Size(76, 20);
            this.tcITQty.TabIndex = 132;
            this.tcITQty.Text = "0";
            this.tcITQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tcITQty.TextChanged += new System.EventHandler(this.tcITQty_TextChanged);
            this.tcITQty.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcITQty_KeyPress);
            // 
            // tcITup
            // 
            this.tcITup.BackColor = System.Drawing.Color.Lavender;
            this.tcITup.ForeColor = System.Drawing.Color.Red;
            this.tcITup.Location = new System.Drawing.Point(148, 196);
            this.tcITup.MaxLength = 49;
            this.tcITup.Name = "tcITup";
            this.tcITup.Size = new System.Drawing.Size(56, 20);
            this.tcITup.TabIndex = 131;
            this.tcITup.Text = "0";
            this.tcITup.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tcITup.TextChanged += new System.EventHandler(this.tcITup_TextChanged);
            this.tcITup.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcITup_KeyPress);
            // 
            // lcetat
            // 
            this.lcetat.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lcetat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lcetat.ForeColor = System.Drawing.SystemColors.Control;
            this.lcetat.Location = new System.Drawing.Point(256, 8);
            this.lcetat.Name = "lcetat";
            this.lcetat.Size = new System.Drawing.Size(20, 16);
            this.lcetat.TabIndex = 130;
            this.lcetat.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lcetat.Visible = false;
            // 
            // lRefName
            // 
            this.lRefName.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lRefName.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lRefName.ForeColor = System.Drawing.SystemColors.Control;
            this.lRefName.Location = new System.Drawing.Point(320, 240);
            this.lRefName.Name = "lRefName";
            this.lRefName.Size = new System.Drawing.Size(24, 16);
            this.lRefName.TabIndex = 129;
            this.lRefName.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lRefName.Visible = false;
            // 
            // lRefArea
            // 
            this.lRefArea.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lRefArea.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lRefArea.ForeColor = System.Drawing.SystemColors.Control;
            this.lRefArea.Location = new System.Drawing.Point(256, 240);
            this.lRefArea.Name = "lRefArea";
            this.lRefArea.Size = new System.Drawing.Size(32, 16);
            this.lRefArea.TabIndex = 128;
            this.lRefArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lRefArea.Visible = false;
            // 
            // lCArea
            // 
            this.lCArea.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lCArea.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lCArea.ForeColor = System.Drawing.SystemColors.Control;
            this.lCArea.Location = new System.Drawing.Point(176, 240);
            this.lCArea.Name = "lCArea";
            this.lCArea.Size = new System.Drawing.Size(24, 16);
            this.lCArea.TabIndex = 127;
            this.lCArea.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lCArea.Visible = false;
            // 
            // chkprint
            // 
            this.chkprint.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkprint.Location = new System.Drawing.Point(288, 16);
            this.chkprint.Name = "chkprint";
            this.chkprint.Size = new System.Drawing.Size(56, 16);
            this.chkprint.TabIndex = 126;
            this.chkprint.Text = "Print";
            this.chkprint.Visible = false;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(208, 98);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(56, 16);
            this.label17.TabIndex = 125;
            this.label17.Text = "Lead Time:";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcLT
            // 
            this.tcLT.BackColor = System.Drawing.SystemColors.Control;
            this.tcLT.ForeColor = System.Drawing.Color.Black;
            this.tcLT.Location = new System.Drawing.Point(272, 96);
            this.tcLT.MaxLength = 49;
            this.tcLT.Name = "tcLT";
            this.tcLT.ReadOnly = true;
            this.tcLT.Size = new System.Drawing.Size(40, 20);
            this.tcLT.TabIndex = 124;
            this.tcLT.Text = "04-06";
            this.tcLT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tcLT.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcLT_KeyPress);
            // 
            // tcextCab
            // 
            this.tcextCab.BackColor = System.Drawing.Color.Lavender;
            this.tcextCab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcextCab.ForeColor = System.Drawing.Color.Red;
            this.tcextCab.Location = new System.Drawing.Point(204, 136);
            this.tcextCab.MaxLength = 49;
            this.tcextCab.Name = "tcextCab";
            this.tcextCab.ReadOnly = true;
            this.tcextCab.Size = new System.Drawing.Size(112, 20);
            this.tcextCab.TabIndex = 121;
            this.tcextCab.Text = "0";
            this.tcextCab.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.tcextCab.TextChanged += new System.EventHandler(this.tcextCab_TextChanged);
            // 
            // tcQtyCab
            // 
            this.tcQtyCab.BackColor = System.Drawing.Color.Lavender;
            this.tcQtyCab.ForeColor = System.Drawing.Color.Red;
            this.tcQtyCab.Location = new System.Drawing.Point(72, 136);
            this.tcQtyCab.MaxLength = 49;
            this.tcQtyCab.Name = "tcQtyCab";
            this.tcQtyCab.Size = new System.Drawing.Size(76, 20);
            this.tcQtyCab.TabIndex = 119;
            this.tcQtyCab.Text = "1";
            this.tcQtyCab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tcQtyCab.TextChanged += new System.EventHandler(this.tcQtyCab_TextChanged);
            this.tcQtyCab.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcQtyCab_KeyPress);
            // 
            // tcstpUP
            // 
            this.tcstpUP.BackColor = System.Drawing.Color.Lavender;
            this.tcstpUP.ForeColor = System.Drawing.Color.Red;
            this.tcstpUP.Location = new System.Drawing.Point(148, 156);
            this.tcstpUP.MaxLength = 49;
            this.tcstpUP.Name = "tcstpUP";
            this.tcstpUP.Size = new System.Drawing.Size(56, 20);
            this.tcstpUP.TabIndex = 117;
            this.tcstpUP.Text = "196";
            this.tcstpUP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tcstpUP.TextChanged += new System.EventHandler(this.tcstpUP_TextChanged);
            this.tcstpUP.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcstpUP_KeyPress);
            // 
            // label23
            // 
            this.label23.BackColor = System.Drawing.SystemColors.Control;
            this.label23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.Color.Green;
            this.label23.Location = new System.Drawing.Point(240, 34);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(48, 16);
            this.label23.TabIndex = 116;
            this.label23.Text = "Cell #:";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tcNBCell
            // 
            this.tcNBCell.BackColor = System.Drawing.Color.Lavender;
            this.tcNBCell.ForeColor = System.Drawing.Color.Red;
            this.tcNBCell.Location = new System.Drawing.Point(288, 32);
            this.tcNBCell.MaxLength = 49;
            this.tcNBCell.Name = "tcNBCell";
            this.tcNBCell.Size = new System.Drawing.Size(56, 20);
            this.tcNBCell.TabIndex = 115;
            this.tcNBCell.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcNBCell_KeyPress);
            // 
            // tc2TPrice
            // 
            this.tc2TPrice.BackColor = System.Drawing.Color.Lavender;
            this.tc2TPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tc2TPrice.ForeColor = System.Drawing.Color.Red;
            this.tc2TPrice.Location = new System.Drawing.Point(204, 176);
            this.tc2TPrice.MaxLength = 49;
            this.tc2TPrice.Name = "tc2TPrice";
            this.tc2TPrice.ReadOnly = true;
            this.tc2TPrice.Size = new System.Drawing.Size(112, 20);
            this.tc2TPrice.TabIndex = 113;
            this.tc2TPrice.Text = "0";
            this.tc2TPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tc1TPrice
            // 
            this.tc1TPrice.BackColor = System.Drawing.Color.Lavender;
            this.tc1TPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tc1TPrice.ForeColor = System.Drawing.Color.Red;
            this.tc1TPrice.Location = new System.Drawing.Point(204, 156);
            this.tc1TPrice.MaxLength = 49;
            this.tc1TPrice.Name = "tc1TPrice";
            this.tc1TPrice.ReadOnly = true;
            this.tc1TPrice.Size = new System.Drawing.Size(112, 20);
            this.tc1TPrice.TabIndex = 111;
            this.tc1TPrice.Text = "0";
            this.tc1TPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // tcPrice
            // 
            this.tcPrice.BackColor = System.Drawing.Color.Lavender;
            this.tcPrice.ForeColor = System.Drawing.Color.Red;
            this.tcPrice.Location = new System.Drawing.Point(148, 136);
            this.tcPrice.MaxLength = 49;
            this.tcPrice.Name = "tcPrice";
            this.tcPrice.Size = new System.Drawing.Size(56, 20);
            this.tcPrice.TabIndex = 109;
            this.tcPrice.Text = "0";
            this.tcPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tcPrice.TextChanged += new System.EventHandler(this.tcPrice_TextChanged);
            this.tcPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tcPrice_KeyPress);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label18.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Blue;
            this.label18.Location = new System.Drawing.Point(120, 24);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(112, 24);
            this.label18.TabIndex = 108;
            this.label18.Text = "CABINET";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(8, 8);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(48, 48);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.pictureBox2.TabIndex = 105;
            this.pictureBox2.TabStop = false;
            // 
            // lblT2
            // 
            this.lblT2.BackColor = System.Drawing.SystemColors.Control;
            this.lblT2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblT2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblT2.Location = new System.Drawing.Point(8, 178);
            this.lblT2.Name = "lblT2";
            this.lblT2.Size = new System.Drawing.Size(64, 16);
            this.lblT2.TabIndex = 104;
            this.lblT2.Text = "step/2st Tier:";
            this.lblT2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tc2Tstep
            // 
            this.tc2Tstep.BackColor = System.Drawing.Color.Lavender;
            this.tc2Tstep.ForeColor = System.Drawing.Color.Red;
            this.tc2Tstep.Location = new System.Drawing.Point(72, 176);
            this.tc2Tstep.MaxLength = 49;
            this.tc2Tstep.Name = "tc2Tstep";
            this.tc2Tstep.Size = new System.Drawing.Size(76, 20);
            this.tc2Tstep.TabIndex = 103;
            this.tc2Tstep.Text = "0";
            this.tc2Tstep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tc2Tstep.TextChanged += new System.EventHandler(this.tc2Tstep_TextChanged);
            this.tc2Tstep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tc2Tstep_KeyPress);
            // 
            // lblT1
            // 
            this.lblT1.BackColor = System.Drawing.SystemColors.Control;
            this.lblT1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lblT1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblT1.Location = new System.Drawing.Point(8, 158);
            this.lblT1.Name = "lblT1";
            this.lblT1.Size = new System.Drawing.Size(64, 16);
            this.lblT1.TabIndex = 102;
            this.lblT1.Text = "step/1st Tier:";
            this.lblT1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tc1Tstep
            // 
            this.tc1Tstep.BackColor = System.Drawing.Color.Lavender;
            this.tc1Tstep.ForeColor = System.Drawing.Color.Red;
            this.tc1Tstep.Location = new System.Drawing.Point(72, 156);
            this.tc1Tstep.MaxLength = 49;
            this.tc1Tstep.Name = "tc1Tstep";
            this.tc1Tstep.Size = new System.Drawing.Size(76, 20);
            this.tc1Tstep.TabIndex = 101;
            this.tc1Tstep.Text = "0";
            this.tc1Tstep.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tc1Tstep.TextChanged += new System.EventHandler(this.tc1Tstep_TextChanged);
            this.tc1Tstep.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tc1Tstep_KeyPress);
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(24, 98);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(48, 16);
            this.label7.TabIndex = 100;
            this.label7.Text = "Color:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tccolor
            // 
            this.tccolor.BackColor = System.Drawing.Color.Lavender;
            this.tccolor.ForeColor = System.Drawing.Color.Red;
            this.tccolor.Location = new System.Drawing.Point(72, 96);
            this.tccolor.MaxLength = 49;
            this.tccolor.Name = "tccolor";
            this.tccolor.Size = new System.Drawing.Size(112, 20);
            this.tccolor.TabIndex = 99;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(16, 78);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(56, 16);
            this.label8.TabIndex = 98;
            this.label8.Text = "Dimensions:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tcDim
            // 
            this.tcDim.BackColor = System.Drawing.SystemColors.Control;
            this.tcDim.ForeColor = System.Drawing.Color.Red;
            this.tcDim.Location = new System.Drawing.Point(72, 76);
            this.tcDim.MaxLength = 100;
            this.tcDim.Name = "tcDim";
            this.tcDim.ReadOnly = true;
            this.tcDim.Size = new System.Drawing.Size(272, 20);
            this.tcDim.TabIndex = 97;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(32, 58);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(40, 16);
            this.label9.TabIndex = 96;
            this.label9.Text = "Model:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tcModel
            // 
            this.tcModel.BackColor = System.Drawing.Color.Lavender;
            this.tcModel.ForeColor = System.Drawing.Color.Red;
            this.tcModel.Location = new System.Drawing.Point(72, 56);
            this.tcModel.MaxLength = 100;
            this.tcModel.Name = "tcModel";
            this.tcModel.Size = new System.Drawing.Size(272, 20);
            this.tcModel.TabIndex = 95;
            // 
            // tIf1
            // 
            this.tIf1.Location = new System.Drawing.Point(0, 0);
            this.tIf1.Name = "tIf1";
            this.tIf1.Size = new System.Drawing.Size(100, 20);
            this.tIf1.TabIndex = 0;
            // 
            // textBox6
            // 
            this.textBox6.Location = new System.Drawing.Point(0, 0);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 20);
            this.textBox6.TabIndex = 0;
            // 
            // lGext
            // 
            this.lGext.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.lGext.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lGext.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lGext.Location = new System.Drawing.Point(360, 256);
            this.lGext.Name = "lGext";
            this.lGext.Size = new System.Drawing.Size(24, 24);
            this.lGext.TabIndex = 122;
            this.lGext.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lGext.Visible = false;
            // 
            // PbsInfo
            // 
            this.AcceptButton = this.btnOK;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(432, 390);
            this.Controls.Add(this.grpbat);
            this.Controls.Add(this.grpCab);
            this.Controls.Add(this.grprack);
            this.Controls.Add(this.lGext);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblVide);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PbsInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PbsInfo";
            this.Load += new System.EventHandler(this.PbsInfo_Load);
            this.grpbat.ResumeLayout(false);
            this.grpbat.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grprack.ResumeLayout(false);
            this.grprack.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.grpCab.ResumeLayout(false);
            this.grpCab.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void grpCab_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void PbsInfo_Load(object sender, System.EventArgs e)
		{
			if (MainMDI.currDB == "XTT") this.Text = "XXXXXXXXXXXXXXXXXXTT";
			if (!grpbat.Visible && !grpCab.Visible && !grprack.Visible) lblVide.Visible = true;
		}

		private string find_OptionPrice(string cptName, string optionName)
		{
			string stSql = "SELECT COMPNT_PRICE_LIST.PRICE, COMPNT_PRICE_LIST.Manufac_PARTN " +
				" FROM COMPNT_LIST INNER JOIN COMPNT_PRICE_LIST ON COMPNT_LIST.Component_ID = COMPNT_PRICE_LIST.COMPONENT_ID " +
				" WHERE (((COMPNT_LIST.COMPONENT_REF)='" + cptName + "') AND (COMPNT_PRICE_LIST.Manufac_PARTN='" + optionName + "' OR COMPNT_PRICE_LIST.CAT1_VALUE='" + optionName + "'))";

			OleDbConnection OConn = new OleDbConnection(MainMDI.M_stCon);
			OConn.Open();
			OleDbCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			OleDbDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				return Oreadr[0].ToString();
			}
			return MainMDI.VIDE;
		}

		private void fill_Cab()
		{
			string stSql = "select * FROM cady_Cab ";
			OleDbConnection OConn = new OleDbConnection(MainMDI.M_PBS_stCon);
			OConn.Open();
			OleDbCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			OleDbDataReader Oreadr = Ocmd.ExecuteReader();
			init_Cab();
			while (Oreadr.Read())
			{
				if (!grpCab.Visible) grpCab.Visible = true;
				tcModel.Text = Oreadr["model"].ToString();
				tccolor.Text = Oreadr["Color"].ToString();
				tcDim.Text = Oreadr["DIM"].ToString();
				tcPrice.Text = Tools.Conv_Dbl(Oreadr["Price"].ToString()).ToString();
				tcNBCell.Text = Oreadr["nbCell"].ToString();
				tc1Tstep.Text = Oreadr["T1Stp"].ToString();
				tc2Tstep.Text = Oreadr["T2Stp"].ToString();
				lcetat.Text = Oreadr["etat"].ToString();
				tcstpUP.Text = "196";
				tcNBCell.Text = In_CellNB;
				tcLT.Text = "04-06";
				tcQtyCab.Text = "1";
				if (Oreadr["etat"].ToString() == "S") 
				{
					tc1TPrice.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tc1Tstep.Text) * Tools.Conv_Dbl(tcstpUP.Text), MainMDI.NB_DEC_AFF));
					tc2TPrice.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tc2Tstep.Text) * Tools.Conv_Dbl(tcstpUP.Text), MainMDI.NB_DEC_AFF));
				}
				else
				{
					lblT1.Text = "Tiers #:";
					lblT2.Visible = false;
					tc2Tstep.Visible = false;
					//lextT2.Visible = false;
					tc2TPrice.Visible = false;
				}
			    //if (Oreadr["model"].ToString() != "CUSTOM")
			    //{
			        //lCArea.Text = Oreadr["Area"].ToString();
			        //int Pos = Oreadr["CabRef"].ToString().IndexOf("|", 0);
			        //lRefName.Text = Oreadr["CabRef"].ToString().Substring(0, Pos);
			        //lRefArea.Text = Oreadr["CabRef"].ToString().Substring(Pos + 1, Oreadr["CabRef"].ToString().Length - Pos - 1);
			        //string RefUP = find_OptionPrice("EN1", lRefName.Text);
			        //tcPrice.Text = Convert.ToString(Math.Round((Tools.Conv_Dbl(lCArea.Text) / Tools.Conv_Dbl(lRefArea.Text)) * Tools.Conv_Dbl(RefUP), MainMDI.NB_DEC_AFF));
			    //}
				//else //tcPrice.Text = find_OptionPrice("EN1", Oreadr["model"].ToString());
			}
			OConn.Close();
		}

		private void init_Cab()
		{
			tc1TPrice.Clear();
			tc1Tstep.Clear();
			//tc2TPrice.Clear();
			tc2Tstep.Clear();
			tccolor.Clear();
			tcDim.Clear();
			tcModel.Clear();
			tcNBCell.Clear();
		}

		private void init_Batt()
		{
			tbCapa.Clear();
			tbDim.Clear();
			tbName.Clear();
			tbPrice.Clear();
			tbType.Clear();
			tbWaran.Clear();
		}

		private void fill_Bat()
		{
			string stSql = "select * FROM cady_Batt ";
			OleDbConnection OConn = new OleDbConnection(MainMDI.M_PBS_stCon);
			OConn.Open();
			OleDbCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			OleDbDataReader Oreadr = Ocmd.ExecuteReader();
			init_Batt();
			while (Oreadr.Read())
			{
				if (!grpbat.Visible) grpbat.Visible = true;
				tbCapa.Text = Oreadr["capa"].ToString();
				tbDim.Text = Oreadr["dim"].ToString();
				tbName.Text = Oreadr["Model"].ToString();
				tbPrice.Text = Oreadr["price"].ToString(); //Oreadr["Price"].ToString();
				tbWaran.Text = "0% 1 an/year, 0% 0 an/year prorata"; //Oreadr["waranty"].ToString();
				tbType.Text = Oreadr["type"].ToString() + " Battery(ies)";
				tbNBcell.Text = In_CellNB;
				tbLT.Text = "12-14";
			}
			OConn.Close();
		}

		private void init_Rack()
		{
			trDim.Clear();
			trNBcell.Clear();
			trPrice.Clear();
			trModel.Clear();
		}

		private void fill_Rack()
		{
			string stSql = "select * FROM cady_Rack";
			OleDbConnection OConn = new OleDbConnection(MainMDI.M_PBS_stCon);
			OConn.Open();
			OleDbCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			OleDbDataReader Oreadr = Ocmd.ExecuteReader();
			init_Batt();
			while (Oreadr.Read())
			{
				if (!grprack.Visible) grprack.Visible = true;
				trDim.Text = Oreadr["dim"].ToString();
				chRcellNB.Text = Oreadr["nbCell"].ToString();
				trPrice.Text = Oreadr["Price"].ToString();
				trModel.Text = Oreadr["Model"].ToString();
				trNBcell.Text = In_CellNB;
				trLT.Text = "04-06";
				trQty.Text = "1";
			}
			OConn.Close();
		}

		private bool chk_vald()
		{
			if (grpbat.Visible && tbNBcell.Text == "") 
			{
				MessageBox.Show("Unit # is Empty   !!!");
				return false;
			}
			return true;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			//if (Tools.Conv_Dbl(lGext.Text) != 0)
			//{
			    if (!lblVide.Visible && chk_vald())
			    {
				    SaveOK = true;
				    this.Close();
			    }
			//}
			//else MessageBox.Show(" Some Values are Null !!!! ");
		}

		private void calRackExt()
		{
			if (trPrice.Text != "" && trQty.Text != "") trExt.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(trPrice.Text) * Tools.Conv_Dbl(trQty.Text), MainMDI.NB_DEC_AFF));
		}

		private void calBatExt()
		{
			//if (tbPrice.Text != "" && tbNBcell.Text != "") 
			tbExt.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tbPrice.Text) * Tools.Conv_Dbl(tsysnb.Text) * Tools.Conv_Dbl(tbNBcell.Text), MainMDI.NB_DEC_AFF));
		}

		private void calICExt()
		{
			//if (tbPrice.Text != "" && tbNBcell.Text != "") 
			tbICExt.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tbICup.Text) * Tools.Conv_Dbl(tbICQty.Text), MainMDI.NB_DEC_AFF));
		}

		private void calELExt()
		{
			//if (tbPrice.Text != "" && tbNBcell.Text != "") 
			tbELExt.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tbELup.Text) * Tools.Conv_Dbl(tbELQty.Text), MainMDI.NB_DEC_AFF));
		}

		private void calITExt()
		{
			//if (tbPrice.Text != "" && tbNBcell.Text != "") 
			tcITExt.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tcITup.Text) * Tools.Conv_Dbl(tcITQty.Text), MainMDI.NB_DEC_AFF));
		}

		private void calBTBExt()
		{
			//if (tbPrice.Text != "" && tbNBcell.Text != "") 
			tcBTBExt.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tcBTBup.Text) * Tools.Conv_Dbl(tcBTBQty.Text), MainMDI.NB_DEC_AFF));
		}

		private void calCabExt()
		{
			//if (tcPrice.Text != "" && tcQtyCab.Text != "") 
			tcextCab.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tcPrice.Text) * Tools.Conv_Dbl(tcQtyCab.Text), MainMDI.NB_DEC_AFF));
		}

		private void calTNExt(byte t)
		{
			if (t == 1) { if (tc1Tstep.Text != "" && tcstpUP.Text != "") tc1TPrice.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tc1Tstep.Text) * Tools.Conv_Dbl(tcstpUP.Text), MainMDI.NB_DEC_AFF)); }
			else if (tc2Tstep.Text != "" && tcstpUP2.Text != "") tc2TPrice.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tc2Tstep.Text) * Tools.Conv_Dbl(tcstpUP.Text), MainMDI.NB_DEC_AFF));
		}

		private void tcPrice_TextChanged(object sender, System.EventArgs e)
		{
			this.calCabExt();
		}

		private void tcQtyCab_TextChanged(object sender, System.EventArgs e)
		{
			this.calCabExt();
		}

		private void tc1Tstep_TextChanged(object sender, System.EventArgs e)
		{
			this.calTNExt(1);
		}

		private void tc2Tstep_TextChanged(object sender, System.EventArgs e)
		{
			this.calTNExt(2);
		}

		private void tcstpUP_TextChanged(object sender, System.EventArgs e)
		{
			this.calTNExt(1);
			this.calTNExt(2);
		}

		private void tbPrice_TextChanged(object sender, System.EventArgs e)
		{
			this.calBatExt();
		}

		private void tbNBcell_TextChanged(object sender, System.EventArgs e)
		{
			this.calBatExt();
		}

		private void trPrice_TextChanged(object sender, System.EventArgs e)
		{
			this.calRackExt();
		}

		private void trQty_TextChanged(object sender, System.EventArgs e)
		{
			this.calRackExt();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			SaveOK = false;
			this.Close();
		}

		private void tbLT_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tcPrice_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tcstpUP_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tcQtyCab_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tc1Tstep_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tc2Tstep_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tcLT_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void trNBcell_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyInt(e.KeyChar);
		}

		private void trPrice_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void trLT_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void trQty_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tcNBCell_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tbPrice_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tbExt_TextChanged(object sender, System.EventArgs e)
		{
			lGext.Text = Convert.ToString(Tools.Conv_Dbl(tbExt.Text));
		}

		private void trExt_TextChanged(object sender, System.EventArgs e)
		{
			lGext.Text = Convert.ToString(Tools.Conv_Dbl(trExt.Text));
		}

		private void tcextCab_TextChanged(object sender, System.EventArgs e)
		{
			lGext.Text = Convert.ToString(Tools.Conv_Dbl(tcextCab.Text));
		}

		private void label39_Click(object sender, System.EventArgs e)
		{
		
		}

		private void textBox9_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void textBox12_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tcITQty_TextChanged(object sender, System.EventArgs e)
		{
			calITExt();
		}

		private void tcITQty_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tcBTBQty_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tcstpUP2_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tcITup_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tcBTBup_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tbNBcell_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tbICQty_TextChanged(object sender, System.EventArgs e)
		{
			calICExt();
		}

		private void tbICQty_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tbELQty_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tbICup_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tbELup_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar);
		}

		private void tbICup_TextChanged(object sender, System.EventArgs e)
		{
			calICExt();
		}

		private void tbELQty_TextChanged(object sender, System.EventArgs e)
		{
			calELExt();
		}

		private void tbELup_TextChanged(object sender, System.EventArgs e)
		{
			calELExt();
		}

		private void tcBTBQty_TextChanged(object sender, System.EventArgs e)
		{
			calBTBExt();
		}

		private void tcBTBup_TextChanged(object sender, System.EventArgs e)
		{
			calBTBExt();
		}

		private void tcITup_TextChanged(object sender, System.EventArgs e)
		{
			calITExt();
		}

		private void tsysnb_TextChanged(object sender, System.EventArgs e)
		{
			if (Tools.Conv_Dbl(tsysnb.Text) == 0) tsysnb.Text = "1";
			this.calBatExt();
		}
	}
}