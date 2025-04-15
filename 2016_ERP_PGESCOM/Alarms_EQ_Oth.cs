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
	/// Summary description for Alarms.
	/// </summary>
	public class Alarms_EQ_Oth : System.Windows.Forms.Form
	{

		private Lib1 Tools = new Lib1();
		bool currCHK=false;
		bool Dblclk=false;
		bool in_Chkd=false;
		int SelNDX=-1;
		private char In_code='N';   // call from Quote: New Alrms      'M':From order: change current Alrms   
		TestEQA T=null;
		string[] ar_SelLv=new string[24];
	    string r_VFLOAT="0",r_VEQUAL="0",r_VAC="0",r_IDC="0",r_VDCNOM="0",r_PHS="0";
		
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.GroupBox grpDetails;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		internal System.Windows.Forms.TextBox tAnam;
		private System.Windows.Forms.PictureBox picON;
		public System.Windows.Forms.Label lSave;
		internal System.Windows.Forms.TextBox tA;
		private System.Windows.Forms.PictureBox PicOFF;
		public System.Windows.Forms.ListView lvAlrmPL;
		private System.Windows.Forms.ColumnHeader Inc;
		private System.Windows.Forms.ColumnHeader Desc;
		private System.Windows.Forms.ColumnHeader Price;
		private System.Windows.Forms.ColumnHeader c1;
		private System.Windows.Forms.ColumnHeader c2;
		private System.Windows.Forms.ColumnHeader c3;
		private System.Windows.Forms.ColumnHeader c4;
		private System.Windows.Forms.ColumnHeader c5;
		private System.Windows.Forms.ColumnHeader c6;
		private System.Windows.Forms.ColumnHeader c7;
		private System.Windows.Forms.ColumnHeader c4fr;
		private System.Windows.Forms.ColumnHeader c5fr;
		private System.Windows.Forms.ColumnHeader c6fr;
		private System.Windows.Forms.ColumnHeader c7fr;
		private System.Windows.Forms.ColumnHeader sta;
		private System.Windows.Forms.ColumnHeader UN15;
		private System.Windows.Forms.ColumnHeader UN16;
		private System.Windows.Forms.ColumnHeader UN17;
		private System.Windows.Forms.ColumnHeader UN18;
		private System.Windows.Forms.ColumnHeader UN19;
		private System.Windows.Forms.ColumnHeader UN20;
		private System.Windows.Forms.ColumnHeader UN21;
		private System.Windows.Forms.ColumnHeader UN22;
		private System.Windows.Forms.GroupBox grpOK;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label10;
		public System.Windows.Forms.TextBox tExt;
		private System.Windows.Forms.Label label8;
		public System.Windows.Forms.TextBox tQty;
		private System.Windows.Forms.Label label9;
		public System.Windows.Forms.TextBox tUP;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.ColumnHeader TVLst;
		private System.Windows.Forms.ColumnHeader C_DV;
		private System.Windows.Forms.ColumnHeader C_DY;
		private System.Windows.Forms.ColumnHeader C_ML;
		private System.Windows.Forms.ColumnHeader C_RY;
		private System.Windows.Forms.ColumnHeader C_RL;
		private System.Windows.Forms.ColumnHeader C_FS;
		private System.Windows.Forms.ColumnHeader C_TO;
		private System.Windows.Forms.CheckBox chkLogicFS;
		private System.Windows.Forms.Label ltTimeO;
		internal System.Windows.Forms.TextBox tTimeO;
		private System.Windows.Forms.CheckBox chkRlyLCH;
		private System.Windows.Forms.Label ltRelayNB;
		internal System.Windows.Forms.TextBox tRelayNB;
		private System.Windows.Forms.CheckBox chkMLatch;
		private System.Windows.Forms.Label ltdelay;
		internal System.Windows.Forms.TextBox tdelay;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.TextBox tV;
		private System.Windows.Forms.GroupBox grpProp;
		private System.Windows.Forms.CheckBox chkProp;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.PictureBox picOKk1;
		private System.Windows.Forms.Label SNTecV;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button4;
		private System.Windows.Forms.PictureBox button3;
		private System.Windows.Forms.Label desc_SYM;
        private ColumnHeader rndNB;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Alarms_EQ_Oth(string st_TECV ,bool x_Chkd,char x_code)
		{
			//
			// Required for Windows Form Designer support
			// Chargerdlg x_Frm_Cdlg,
			InitializeComponent();
		//	in_frm_FDR=x_Frm_Cdlg;
			SNTecV.Text = st_TECV;
			in_Chkd= x_Chkd;
			In_code = x_code;
			T=new TestEQA(SNTecV.Text );
			fill_BigVCS(); 
			fill_Alrm_priceList(); 
         //   if (In_code=='M') fill_Alrm_ToModify(in_stALRM);
           
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Alarms_EQ_Oth));
            this.grpOK = new System.Windows.Forms.GroupBox();
            this.desc_SYM = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.PictureBox();
            this.label2 = new System.Windows.Forms.Label();
            this.picOKk1 = new System.Windows.Forms.PictureBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpDetails = new System.Windows.Forms.GroupBox();
            this.SNTecV = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.chkProp = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.grpProp = new System.Windows.Forms.GroupBox();
            this.chkLogicFS = new System.Windows.Forms.CheckBox();
            this.ltTimeO = new System.Windows.Forms.Label();
            this.tTimeO = new System.Windows.Forms.TextBox();
            this.chkRlyLCH = new System.Windows.Forms.CheckBox();
            this.ltRelayNB = new System.Windows.Forms.Label();
            this.tRelayNB = new System.Windows.Forms.TextBox();
            this.chkMLatch = new System.Windows.Forms.CheckBox();
            this.ltdelay = new System.Windows.Forms.Label();
            this.tdelay = new System.Windows.Forms.TextBox();
            this.tV = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label10 = new System.Windows.Forms.Label();
            this.tExt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tQty = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.tUP = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tAnam = new System.Windows.Forms.TextBox();
            this.lSave = new System.Windows.Forms.Label();
            this.tA = new System.Windows.Forms.TextBox();
            this.picON = new System.Windows.Forms.PictureBox();
            this.PicOFF = new System.Windows.Forms.PictureBox();
            this.lvAlrmPL = new System.Windows.Forms.ListView();
            this.Inc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Price = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TVLst = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c6 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c7 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c4fr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c5fr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c6fr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c7fr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.C_DV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.C_DY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.C_ML = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.C_RY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.C_RL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.C_FS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.C_TO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sta = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UN15 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UN16 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UN17 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UN18 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UN19 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UN20 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UN21 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UN22 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rndNB = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpOK.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.button3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOKk1)).BeginInit();
            this.grpDetails.SuspendLayout();
            this.grpProp.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picON)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicOFF)).BeginInit();
            this.SuspendLayout();
            // 
            // grpOK
            // 
            this.grpOK.Controls.Add(this.desc_SYM);
            this.grpOK.Controls.Add(this.label3);
            this.grpOK.Controls.Add(this.button3);
            this.grpOK.Controls.Add(this.label2);
            this.grpOK.Controls.Add(this.picOKk1);
            this.grpOK.Controls.Add(this.button4);
            this.grpOK.Controls.Add(this.button2);
            this.grpOK.Controls.Add(this.btnOK);
            this.grpOK.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpOK.Location = new System.Drawing.Point(0, 0);
            this.grpOK.Name = "grpOK";
            this.grpOK.Size = new System.Drawing.Size(1121, 40);
            this.grpOK.TabIndex = 260;
            this.grpOK.TabStop = false;
            // 
            // desc_SYM
            // 
            this.desc_SYM.BackColor = System.Drawing.Color.Khaki;
            this.desc_SYM.ForeColor = System.Drawing.Color.Blue;
            this.desc_SYM.Location = new System.Drawing.Point(460, 6);
            this.desc_SYM.Name = "desc_SYM";
            this.desc_SYM.Size = new System.Drawing.Size(260, 28);
            this.desc_SYM.TabIndex = 298;
            this.desc_SYM.Visible = false;
            // 
            // label3
            // 
            this.label3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(152, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 16);
            this.label3.TabIndex = 292;
            this.label3.Text = "New Alarms";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label3.Click += new System.EventHandler(this.button3_Click);
            // 
            // button3
            // 
            this.button3.AccessibleDescription = "jgjggjgjgj";
            this.button3.BackColor = System.Drawing.Color.Transparent;
            this.button3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button3.Image = ((System.Drawing.Image)(resources.GetObject("button3.Image")));
            this.button3.Location = new System.Drawing.Point(208, 8);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(40, 24);
            this.button3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.button3.TabIndex = 291;
            this.button3.TabStop = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // label2
            // 
            this.label2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(24, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 16);
            this.label2.TabIndex = 290;
            this.label2.Text = "Default Alarms";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label2.Click += new System.EventHandler(this.picOKk1_Click);
            // 
            // picOKk1
            // 
            this.picOKk1.BackColor = System.Drawing.Color.Transparent;
            this.picOKk1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picOKk1.Image = ((System.Drawing.Image)(resources.GetObject("picOKk1.Image")));
            this.picOKk1.Location = new System.Drawing.Point(96, 8);
            this.picOKk1.Name = "picOKk1";
            this.picOKk1.Size = new System.Drawing.Size(24, 24);
            this.picOKk1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOKk1.TabIndex = 289;
            this.picOKk1.TabStop = false;
            this.picOKk1.Click += new System.EventHandler(this.picOKk1_Click);
            // 
            // button4
            // 
            this.button4.BackColor = System.Drawing.Color.AliceBlue;
            this.button4.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Image = ((System.Drawing.Image)(resources.GetObject("button4.Image")));
            this.button4.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button4.Location = new System.Drawing.Point(592, 136);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(96, 24);
            this.button4.TabIndex = 288;
            this.button4.Text = "New";
            this.button4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button4.UseVisualStyleBackColor = false;
            this.button4.Click += new System.EventHandler(this.button3_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.PowderBlue;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button2.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button2.Image = ((System.Drawing.Image)(resources.GetObject("button2.Image")));
            this.button2.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button2.Location = new System.Drawing.Point(856, 10);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(80, 24);
            this.button2.TabIndex = 285;
            this.button2.Text = "Cancel";
            this.button2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.PowderBlue;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnOK.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
            this.btnOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOK.Location = new System.Drawing.Point(768, 10);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(80, 24);
            this.btnOK.TabIndex = 284;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // grpDetails
            // 
            this.grpDetails.Controls.Add(this.SNTecV);
            this.grpDetails.Controls.Add(this.button1);
            this.grpDetails.Controls.Add(this.chkProp);
            this.grpDetails.Controls.Add(this.btnSave);
            this.grpDetails.Controls.Add(this.grpProp);
            this.grpDetails.Controls.Add(this.groupBox1);
            this.grpDetails.Controls.Add(this.label5);
            this.grpDetails.Controls.Add(this.label6);
            this.grpDetails.Controls.Add(this.tAnam);
            this.grpDetails.Controls.Add(this.lSave);
            this.grpDetails.Controls.Add(this.tA);
            this.grpDetails.Controls.Add(this.picON);
            this.grpDetails.Controls.Add(this.PicOFF);
            this.grpDetails.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpDetails.Location = new System.Drawing.Point(0, 40);
            this.grpDetails.Name = "grpDetails";
            this.grpDetails.Size = new System.Drawing.Size(1121, 104);
            this.grpDetails.TabIndex = 262;
            this.grpDetails.TabStop = false;
            this.grpDetails.Visible = false;
            // 
            // SNTecV
            // 
            this.SNTecV.BackColor = System.Drawing.Color.DodgerBlue;
            this.SNTecV.Location = new System.Drawing.Point(445, 38);
            this.SNTecV.Name = "SNTecV";
            this.SNTecV.Size = new System.Drawing.Size(27, 28);
            this.SNTecV.TabIndex = 297;
            this.SNTecV.Visible = false;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PowderBlue;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = ((System.Drawing.Image)(resources.GetObject("button1.Image")));
            this.button1.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.button1.Location = new System.Drawing.Point(296, 66);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(144, 30);
            this.button1.TabIndex = 296;
            this.button1.Text = "Cancel";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // chkProp
            // 
            this.chkProp.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkProp.Checked = true;
            this.chkProp.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkProp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkProp.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkProp.ForeColor = System.Drawing.Color.Red;
            this.chkProp.Location = new System.Drawing.Point(464, 56);
            this.chkProp.Name = "chkProp";
            this.chkProp.Size = new System.Drawing.Size(72, 24);
            this.chkProp.TabIndex = 295;
            this.chkProp.Text = "External";
            this.chkProp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkProp.CheckedChanged += new System.EventHandler(this.chkProp_CheckedChanged);
            this.chkProp.ContextMenuChanged += new System.EventHandler(this.chkProp_CheckedChanged);
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.PowderBlue;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Image = ((System.Drawing.Image)(resources.GetObject("btnSave.Image")));
            this.btnSave.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.btnSave.Location = new System.Drawing.Point(296, 32);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(144, 30);
            this.btnSave.TabIndex = 294;
            this.btnSave.Text = "Update";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // grpProp
            // 
            this.grpProp.Controls.Add(this.chkLogicFS);
            this.grpProp.Controls.Add(this.ltTimeO);
            this.grpProp.Controls.Add(this.tTimeO);
            this.grpProp.Controls.Add(this.chkRlyLCH);
            this.grpProp.Controls.Add(this.ltRelayNB);
            this.grpProp.Controls.Add(this.tRelayNB);
            this.grpProp.Controls.Add(this.chkMLatch);
            this.grpProp.Controls.Add(this.ltdelay);
            this.grpProp.Controls.Add(this.tdelay);
            this.grpProp.Controls.Add(this.tV);
            this.grpProp.Controls.Add(this.label1);
            this.grpProp.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpProp.Location = new System.Drawing.Point(536, 32);
            this.grpProp.Name = "grpProp";
            this.grpProp.Size = new System.Drawing.Size(400, 64);
            this.grpProp.TabIndex = 289;
            this.grpProp.TabStop = false;
            // 
            // chkLogicFS
            // 
            this.chkLogicFS.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLogicFS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkLogicFS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkLogicFS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkLogicFS.Location = new System.Drawing.Point(288, 40);
            this.chkLogicFS.Name = "chkLogicFS";
            this.chkLogicFS.Size = new System.Drawing.Size(96, 16);
            this.chkLogicFS.TabIndex = 292;
            this.chkLogicFS.Text = "Fail Safe:";
            this.chkLogicFS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkLogicFS.CheckedChanged += new System.EventHandler(this.chkLogicFS_CheckedChanged_1);
            this.chkLogicFS.CheckStateChanged += new System.EventHandler(this.chkLogicFS_CheckedChanged);
            // 
            // ltTimeO
            // 
            this.ltTimeO.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ltTimeO.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltTimeO.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ltTimeO.Location = new System.Drawing.Point(224, 16);
            this.ltTimeO.Name = "ltTimeO";
            this.ltTimeO.Size = new System.Drawing.Size(48, 16);
            this.ltTimeO.TabIndex = 291;
            this.ltTimeO.Text = "TimeOut";
            this.ltTimeO.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tTimeO
            // 
            this.tTimeO.BackColor = System.Drawing.Color.Lavender;
            this.tTimeO.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tTimeO.ForeColor = System.Drawing.Color.DarkRed;
            this.tTimeO.Location = new System.Drawing.Point(216, 32);
            this.tTimeO.MaxLength = 2;
            this.tTimeO.Name = "tTimeO";
            this.tTimeO.Size = new System.Drawing.Size(64, 26);
            this.tTimeO.TabIndex = 290;
            this.tTimeO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tTimeO.TextChanged += new System.EventHandler(this.tTimeO_TextChanged);
            // 
            // chkRlyLCH
            // 
            this.chkRlyLCH.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRlyLCH.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkRlyLCH.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkRlyLCH.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkRlyLCH.Location = new System.Drawing.Point(288, 8);
            this.chkRlyLCH.Name = "chkRlyLCH";
            this.chkRlyLCH.Size = new System.Drawing.Size(96, 16);
            this.chkRlyLCH.TabIndex = 289;
            this.chkRlyLCH.Text = "Relay Latch:";
            this.chkRlyLCH.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkRlyLCH.CheckedChanged += new System.EventHandler(this.chkRlyLCH_CheckedChanged);
            // 
            // ltRelayNB
            // 
            this.ltRelayNB.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ltRelayNB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltRelayNB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ltRelayNB.Location = new System.Drawing.Point(160, 16);
            this.ltRelayNB.Name = "ltRelayNB";
            this.ltRelayNB.Size = new System.Drawing.Size(48, 16);
            this.ltRelayNB.TabIndex = 288;
            this.ltRelayNB.Text = "Relay #";
            this.ltRelayNB.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tRelayNB
            // 
            this.tRelayNB.BackColor = System.Drawing.Color.Lavender;
            this.tRelayNB.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tRelayNB.ForeColor = System.Drawing.Color.DarkRed;
            this.tRelayNB.Location = new System.Drawing.Point(152, 32);
            this.tRelayNB.MaxLength = 2;
            this.tRelayNB.Name = "tRelayNB";
            this.tRelayNB.Size = new System.Drawing.Size(64, 26);
            this.tRelayNB.TabIndex = 287;
            this.tRelayNB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tRelayNB.TextChanged += new System.EventHandler(this.tRelayNB_TextChanged);
            // 
            // chkMLatch
            // 
            this.chkMLatch.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMLatch.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkMLatch.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkMLatch.ForeColor = System.Drawing.SystemColors.ControlText;
            this.chkMLatch.Location = new System.Drawing.Point(288, 24);
            this.chkMLatch.Name = "chkMLatch";
            this.chkMLatch.Size = new System.Drawing.Size(96, 16);
            this.chkMLatch.TabIndex = 286;
            this.chkMLatch.Text = "Msg Latch:";
            this.chkMLatch.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMLatch.CheckedChanged += new System.EventHandler(this.chkMLatch_CheckedChanged);
            // 
            // ltdelay
            // 
            this.ltdelay.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ltdelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltdelay.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ltdelay.Location = new System.Drawing.Point(104, 16);
            this.ltdelay.Name = "ltdelay";
            this.ltdelay.Size = new System.Drawing.Size(40, 16);
            this.ltdelay.TabIndex = 285;
            this.ltdelay.Text = "Delay";
            this.ltdelay.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tdelay
            // 
            this.tdelay.BackColor = System.Drawing.Color.Lavender;
            this.tdelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tdelay.ForeColor = System.Drawing.Color.DarkRed;
            this.tdelay.Location = new System.Drawing.Point(96, 32);
            this.tdelay.MaxLength = 3;
            this.tdelay.Name = "tdelay";
            this.tdelay.Size = new System.Drawing.Size(56, 26);
            this.tdelay.TabIndex = 284;
            this.tdelay.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tdelay.TextChanged += new System.EventHandler(this.tdelay_TextChanged);
            // 
            // tV
            // 
            this.tV.BackColor = System.Drawing.Color.Lavender;
            this.tV.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tV.ForeColor = System.Drawing.Color.DarkRed;
            this.tV.Location = new System.Drawing.Point(8, 32);
            this.tV.MaxLength = 50;
            this.tV.Name = "tV";
            this.tV.Size = new System.Drawing.Size(88, 26);
            this.tV.TabIndex = 282;
            this.tV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tV.TextChanged += new System.EventHandler(this.tV_TextChanged);
            // 
            // label1
            // 
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(16, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 283;
            this.label1.Text = "Adjustment";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.tExt);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tQty);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.tUP);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(8, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(280, 64);
            this.groupBox1.TabIndex = 288;
            this.groupBox1.TabStop = false;
            // 
            // label10
            // 
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.MediumBlue;
            this.label10.Location = new System.Drawing.Point(152, 16);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(96, 16);
            this.label10.TabIndex = 278;
            this.label10.Text = "Extension";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tExt
            // 
            this.tExt.BackColor = System.Drawing.Color.Lavender;
            this.tExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tExt.ForeColor = System.Drawing.Color.Red;
            this.tExt.Location = new System.Drawing.Point(128, 32);
            this.tExt.MaxLength = 50;
            this.tExt.Name = "tExt";
            this.tExt.Size = new System.Drawing.Size(144, 21);
            this.tExt.TabIndex = 277;
            this.tExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.MediumBlue;
            this.label8.Location = new System.Drawing.Point(88, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(32, 16);
            this.label8.TabIndex = 276;
            this.label8.Text = "Qty";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tQty
            // 
            this.tQty.BackColor = System.Drawing.Color.Lavender;
            this.tQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tQty.ForeColor = System.Drawing.Color.Red;
            this.tQty.Location = new System.Drawing.Point(88, 32);
            this.tQty.MaxLength = 50;
            this.tQty.Name = "tQty";
            this.tQty.Size = new System.Drawing.Size(40, 21);
            this.tQty.TabIndex = 275;
            this.tQty.Text = "1";
            this.tQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tQty.ContextMenuChanged += new System.EventHandler(this.tQty_TextChanged);
            this.tQty.TextChanged += new System.EventHandler(this.tQty_TextChanged);
            // 
            // label9
            // 
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.MediumBlue;
            this.label9.Location = new System.Drawing.Point(8, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(72, 16);
            this.label9.TabIndex = 274;
            this.label9.Text = "Unit Price";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tUP
            // 
            this.tUP.BackColor = System.Drawing.Color.Lavender;
            this.tUP.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tUP.ForeColor = System.Drawing.Color.Red;
            this.tUP.Location = new System.Drawing.Point(8, 32);
            this.tUP.MaxLength = 50;
            this.tUP.Name = "tUP";
            this.tUP.Size = new System.Drawing.Size(80, 21);
            this.tUP.TabIndex = 273;
            this.tUP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tUP.ContextMenuChanged += new System.EventHandler(this.tUP_TextChanged);
            this.tUP.TextChanged += new System.EventHandler(this.tUP_TextChanged);
            // 
            // label5
            // 
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Palatino Linotype", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.MediumBlue;
            this.label5.Location = new System.Drawing.Point(696, 192);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 24);
            this.label5.TabIndex = 287;
            this.label5.Text = "Status:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label5.Visible = false;
            // 
            // label6
            // 
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 12);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 16);
            this.label6.TabIndex = 261;
            this.label6.Text = "Description:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tAnam
            // 
            this.tAnam.BackColor = System.Drawing.Color.Lavender;
            this.tAnam.ForeColor = System.Drawing.Color.DarkRed;
            this.tAnam.Location = new System.Drawing.Point(80, 8);
            this.tAnam.MaxLength = 50;
            this.tAnam.Multiline = true;
            this.tAnam.Name = "tAnam";
            this.tAnam.Size = new System.Drawing.Size(856, 24);
            this.tAnam.TabIndex = 260;
            // 
            // lSave
            // 
            this.lSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.lSave.Location = new System.Drawing.Point(856, 192);
            this.lSave.Name = "lSave";
            this.lSave.Size = new System.Drawing.Size(40, 16);
            this.lSave.TabIndex = 285;
            this.lSave.Text = "N";
            this.lSave.Visible = false;
            // 
            // tA
            // 
            this.tA.BackColor = System.Drawing.Color.Lavender;
            this.tA.Location = new System.Drawing.Point(888, 160);
            this.tA.MaxLength = 50;
            this.tA.Name = "tA";
            this.tA.Size = new System.Drawing.Size(24, 20);
            this.tA.TabIndex = 282;
            this.tA.Visible = false;
            // 
            // picON
            // 
            this.picON.Image = ((System.Drawing.Image)(resources.GetObject("picON.Image")));
            this.picON.Location = new System.Drawing.Point(792, 176);
            this.picON.Name = "picON";
            this.picON.Size = new System.Drawing.Size(32, 32);
            this.picON.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picON.TabIndex = 279;
            this.picON.TabStop = false;
            this.picON.Visible = false;
            this.picON.Click += new System.EventHandler(this.picON_Click);
            // 
            // PicOFF
            // 
            this.PicOFF.Image = ((System.Drawing.Image)(resources.GetObject("PicOFF.Image")));
            this.PicOFF.Location = new System.Drawing.Point(792, 176);
            this.PicOFF.Name = "PicOFF";
            this.PicOFF.Size = new System.Drawing.Size(32, 32);
            this.PicOFF.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicOFF.TabIndex = 280;
            this.PicOFF.TabStop = false;
            this.PicOFF.Visible = false;
            this.PicOFF.Click += new System.EventHandler(this.PicOFF_Click);
            // 
            // lvAlrmPL
            // 
            this.lvAlrmPL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvAlrmPL.CheckBoxes = true;
            this.lvAlrmPL.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Inc,
            this.Desc,
            this.Price,
            this.TVLst,
            this.c1,
            this.c2,
            this.c3,
            this.c4,
            this.c5,
            this.c6,
            this.c7,
            this.c4fr,
            this.c5fr,
            this.c6fr,
            this.c7fr,
            this.C_DV,
            this.C_DY,
            this.C_ML,
            this.C_RY,
            this.C_RL,
            this.C_FS,
            this.C_TO,
            this.sta,
            this.UN15,
            this.UN16,
            this.UN17,
            this.UN18,
            this.UN19,
            this.UN20,
            this.UN21,
            this.UN22,
            this.rndNB});
            this.lvAlrmPL.Dock = System.Windows.Forms.DockStyle.Top;
            this.lvAlrmPL.ForeColor = System.Drawing.Color.Blue;
            this.lvAlrmPL.FullRowSelect = true;
            this.lvAlrmPL.GridLines = true;
            this.lvAlrmPL.HideSelection = false;
            this.lvAlrmPL.Location = new System.Drawing.Point(0, 144);
            this.lvAlrmPL.Name = "lvAlrmPL";
            this.lvAlrmPL.Size = new System.Drawing.Size(1121, 416);
            this.lvAlrmPL.TabIndex = 263;
            this.lvAlrmPL.UseCompatibleStateImageBehavior = false;
            this.lvAlrmPL.View = System.Windows.Forms.View.Details;
            this.lvAlrmPL.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvAlrmPL_ColumnClick);
            this.lvAlrmPL.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvAlrmPL_ItemCheck);
            this.lvAlrmPL.SelectedIndexChanged += new System.EventHandler(this.lvAlrmPL_SelectedIndexChanged);
            this.lvAlrmPL.DoubleClick += new System.EventHandler(this.lvAlrmPL_DoubleClick);
            // 
            // Inc
            // 
            this.Inc.Text = "In";
            this.Inc.Width = 31;
            // 
            // Desc
            // 
            this.Desc.Text = "Description";
            this.Desc.Width = 417;
            // 
            // Price
            // 
            this.Price.Text = "Price";
            this.Price.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Price.Width = 47;
            // 
            // TVLst
            // 
            this.TVLst.Text = "";
            this.TVLst.Width = 0;
            // 
            // c1
            // 
            this.c1.Text = "";
            this.c1.Width = 0;
            // 
            // c2
            // 
            this.c2.Text = "";
            this.c2.Width = 0;
            // 
            // c3
            // 
            this.c3.Text = "";
            this.c3.Width = 0;
            // 
            // c4
            // 
            this.c4.Text = "";
            this.c4.Width = 0;
            // 
            // c5
            // 
            this.c5.Text = "";
            this.c5.Width = 0;
            // 
            // c6
            // 
            this.c6.Text = "";
            this.c6.Width = 0;
            // 
            // c7
            // 
            this.c7.Text = "";
            this.c7.Width = 0;
            // 
            // c4fr
            // 
            this.c4fr.Text = "";
            this.c4fr.Width = 0;
            // 
            // c5fr
            // 
            this.c5fr.Text = "";
            this.c5fr.Width = 0;
            // 
            // c6fr
            // 
            this.c6fr.Text = "";
            this.c6fr.Width = 0;
            // 
            // c7fr
            // 
            this.c7fr.Text = "";
            this.c7fr.Width = 0;
            // 
            // C_DV
            // 
            this.C_DV.Text = "Adjustment";
            this.C_DV.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.C_DV.Width = 73;
            // 
            // C_DY
            // 
            this.C_DY.Text = "Delay";
            this.C_DY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.C_DY.Width = 52;
            // 
            // C_ML
            // 
            this.C_ML.Text = "Msg Latch";
            this.C_ML.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.C_ML.Width = 68;
            // 
            // C_RY
            // 
            this.C_RY.Text = "Relay #";
            this.C_RY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.C_RY.Width = 51;
            // 
            // C_RL
            // 
            this.C_RL.Text = "Relay Latch";
            this.C_RL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.C_RL.Width = 71;
            // 
            // C_FS
            // 
            this.C_FS.Text = "Fail Safe";
            this.C_FS.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.C_FS.Width = 53;
            // 
            // C_TO
            // 
            this.C_TO.Text = "Time Out";
            this.C_TO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.C_TO.Width = 62;
            // 
            // sta
            // 
            this.sta.Text = "";
            this.sta.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sta.Width = 0;
            // 
            // UN15
            // 
            this.UN15.Text = "";
            this.UN15.Width = 0;
            // 
            // UN16
            // 
            this.UN16.Text = "";
            this.UN16.Width = 0;
            // 
            // UN17
            // 
            this.UN17.Text = "";
            this.UN17.Width = 0;
            // 
            // UN18
            // 
            this.UN18.Text = "";
            this.UN18.Width = 0;
            // 
            // UN19
            // 
            this.UN19.Text = "";
            this.UN19.Width = 0;
            // 
            // UN20
            // 
            this.UN20.Text = "";
            this.UN20.Width = 0;
            // 
            // UN21
            // 
            this.UN21.Text = "";
            this.UN21.Width = 0;
            // 
            // UN22
            // 
            this.UN22.Width = 0;
            // 
            // rndNB
            // 
            this.rndNB.Text = "RND #";
            // 
            // Alarms_EQ_Oth
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1121, 568);
            this.Controls.Add(this.lvAlrmPL);
            this.Controls.Add(this.grpDetails);
            this.Controls.Add(this.grpOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Alarms_EQ_Oth";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Alarms, Equalize & Others tests";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Alarms_Load);
            this.SizeChanged += new System.EventHandler(this.Alarms_EQ_Oth_SizeChanged);
            this.Resize += new System.EventHandler(this.Alarms_EQ_Oth_Resize);
            this.grpOK.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.button3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOKk1)).EndInit();
            this.grpDetails.ResumeLayout(false);
            this.grpDetails.PerformLayout();
            this.grpProp.ResumeLayout(false);
            this.grpProp.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picON)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicOFF)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        //private void btnAdd_Click(object sender, System.EventArgs e)
        //{
        //    Options frmOpt = new Options('A',"ALRM");
        //    frmOpt.ShowDialog();
        //    if (frmOpt.lConsopt.Text =="Y")
        //    {
        //      if (MainMDI.Lang ==1 && frmOpt.optFR.Checked ) 
        //           add_LVO(frmOpt.lExt.Text,frmOpt.tCat1.Text,frmOpt.tCat2.Text,frmOpt.tCat3.Text,frmOpt.tCat4fr.Text,frmOpt.tCat5fr.Text,frmOpt.tCat6fr.Text,frmOpt.tCat7fr.Text); 
        //      else   add_LVO(frmOpt.lExt.Text,frmOpt.tCat1.Text,frmOpt.tCat2.Text,frmOpt.tCat3.Text,frmOpt.tCat4.Text,frmOpt.tCat5.Text,frmOpt.tCat6.Text,frmOpt.tCat7.Text); 
        //      //else  
        //        //3,".",frmOpt.tERef.Text + "  "   + frmOpt.lFullDesc.Text,frmOpt.tOptqty.Text,tCust_Mult.Text,frmOpt.tUPrice.Text , Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text) ,Charger.NB_DEC_AFF)),frmOpt.tDlvDelay.Text);
			
        //    }

        //}

		private void Alarms_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!"; 
		    Alarms_EQ_Oth_SizeChanged(sender,e);
		
		}


		private void fill_Alrm_priceList()
		{ 
			
	//		string stSql = "SELECT COMPNT_PRICE_LIST.* FROM (COMPNT_LIST INNER JOIN COMPNT_MANUFAC_FAMILY ON COMPNT_LIST.Component_ID = COMPNT_MANUFAC_FAMILY.Compnt_ID) INNER JOIN COMPNT_PRICE_LIST ON COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID = COMPNT_PRICE_LIST.compnt_man_Fam_ID " + 
	//			" WHERE (((COMPNT_LIST.COMPONENT_REF)='ALRM') AND ((COMPNT_PRICE_LIST.PRICE)=0)) ORDER BY COMPNT_LIST.COMPONENT_REF";
			string stSql = "SELECT COMPNT_PRICE_LIST.* FROM (COMPNT_LIST INNER JOIN COMPNT_MANUFAC_FAMILY ON COMPNT_LIST.Component_ID = COMPNT_MANUFAC_FAMILY.Compnt_ID) INNER JOIN COMPNT_PRICE_LIST ON COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID = COMPNT_PRICE_LIST.compnt_man_Fam_ID " + 
				" WHERE  ((COMPNT_LIST.COMPONENT_REF)='ALRM') ORDER BY CAT4_VALUE"; //PRICE";
		
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon    );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			lvAlrmPL.Items.Clear ();
			while (Oreadr.Read ())
			{
                string ALC = (Oreadr["charger_alarm"].ToString() != "") ? Oreadr["charger_alarm"].ToString() : "0";
                if (MainMDI.Lang == 0 || MainMDI.Lang == 2) add_LVO(Oreadr["PRICE"].ToString(), Oreadr["CAT1_VALUE"].ToString(),
				Oreadr["CAT2_VALUE"].ToString (),Oreadr["CAT3_VALUE"].ToString (),
				Oreadr["CAT4_VALUE"].ToString (),Oreadr["CAT5_VALUE"].ToString (),
				Oreadr["CAT6_VALUE"].ToString (),Oreadr["CAT7_VALUE"].ToString (),ALC); 
				else add_LVO(Oreadr["PRICE"].ToString (),Oreadr["CAT1_VALUE"].ToString (),
						 Oreadr["CAT2_VALUE"].ToString (),Oreadr["CAT3_VALUE"].ToString (),
						 Oreadr["CAT4fr_VALUE"].ToString (),Oreadr["CAT5fr_VALUE"].ToString (),
						 Oreadr["CAT6fr_VALUE"].ToString (),Oreadr["CAT7_VALUE"].ToString (),ALC);   //same CAT7 as english
			//	Oreadr["CAT4fr_VALUE"].ToString (),Oreadr["CAT5fr_VALUE"].ToString (), 
			//	Oreadr["CAT6fr_VALUE"].ToString (),Oreadr["CAT7fr_VALUE"].ToString ());

			}
			OConn.Close (); 
			BuildTV_lvAlrmPL () ;

		}

		private string boolToCarOLD(string st,char typ,ref string UN)
		{
			// typ=T text             typ=B  bool checked or Not
			int ipos=st.IndexOf("^");
			if (ipos != -1)
			{
				UN = st.Substring(ipos+1,st.Length -ipos-1);
				st=st.Substring(0,ipos);
			}
			else UN=""; 
 
			string res=" ";
			switch (st)
			{
				case "E":
				case "ON":
					res= "Y";
					break;
				case "D":
					case "OFF":
					res= "N";
					break;
			}
			if (typ=='T' && st!=MainMDI.VIDE  && st!="???" ) res=st;
			return res;
		}

		private string CarToBoolOLD(string st,string UN)
		{
			// typ=T text             typ=B  bool checked or Not

			string res="";
			char typ='T';
			switch (st)
			{
				case "Y":
					res= "E";
					typ='B';
					break;
				case "N":
    				res= "D";
					typ='B';
					break;
			}
			if (typ=='T' && st!=MainMDI.VIDE  && st!=" "  && st!="???"  ) res=st;
			if (UN!="" && res!="") res+= "^" + UN;
			return res;
		}
		
		private string NMCol_lvAlrmPL(int ndx)
		{
			string st="???";
			switch (ndx)
			{
				case 15:
					st="C_DV";
					break;
				case 16:
					st="C_DY";
					break;
				case 17:
					st="C_ML";
					break;
				case 18:
					st="C_RY";
					break;
				case 19:
					st="C_RL";
					break;
				case 20:
					st="C_FS";
					break;
				case 21:
					st="C_TO";
					break;
			}
            return st;
		}

		private void BuildTV_lvAlrmPL () 
		{
			
			for (int l=0;l<lvAlrmPL.Items.Count ;l++)
			{
				string st= build_TV_Item(l);
				lvAlrmPL.Items[l].SubItems[3].Text += (st==";" ) ? "" : "~" + st; 
			}
				
		}

		private string build_TV_Item(int ndx)
		{
			string Btv="";
			string sep="",Desc="",Sym="";
		
			string dS=lvAlrmPL.Items[ndx].SubItems[3].Text;
			int ipos2=-1;
			if (dS=="") return ""; //dS;
			else
			{
				int ipos =(dS.Length >1)?  dS.IndexOf("~") : -1;
				if (ipos!=-1) 
				{
					Desc = dS.Substring(0,ipos+1);
					ipos2= dS.IndexOf("~",ipos+1);
					if (ipos2!=-1) Sym= dS.Substring(ipos+1,ipos2-ipos -1);
					else if (ipos < dS.Length)  Sym= dS.Substring(ipos+1,dS.Length - ipos -1);
				}
				Btv=Desc + Sym ;
				for (int c=15;c<22;c++)
				{
					if (Btv !="") sep= "~" ;
					Btv += (lvAlrmPL.Items[ndx].SubItems[c].Text !=" " && lvAlrmPL.Items[ndx].SubItems[c].Text !="")  ? sep + NMCol_lvAlrmPL(c) + "||" + CarToBool(lvAlrmPL.Items[ndx].SubItems[c].Text, lvAlrmPL.Items[ndx].SubItems[c+8].Text) : "";  
				}
				Btv+=(Btv !="") ? " ;" : ";";  //if TV==";" ---> Tst/alarm properties free
				//Btv+=(Btv !="") ? " ;" : ";"; 
				return Btv ;
			}

		}

        private void add_LVO(string price, string c1, string c2, string c3, string c4, string c5, string c6, string c7,string alc)
		{

			ListViewItem lvI= lvAlrmPL.Items.Add("");
			lvI.SubItems.Add(""); // desc will be filled at end of function
			lvI.UseItemStyleForSubItems = false;
			lvI.SubItems.Add(price); 
			lvI.SubItems.Add("");
			lvI.SubItems.Add(c1);
			lvI.SubItems.Add(c2); 
			lvI.SubItems.Add(c3); 
			lvI.SubItems.Add(c4);
			lvI.SubItems.Add(c5);
			lvI.SubItems.Add(c6); 
			lvI.SubItems.Add(c7); 
			for (int y=0;y<4;y++) lvI.SubItems.Add(""); 
			//TestEQA T=new TestEQA(SNTecV.Text );//lvI.SubItems[15].Text =(boolToCar(T.look_Req_Value("C_DV", TV,'A'),'T',ref UN)) 
			string TV=T.look_Tests_VCS(c7); 
			string UN=MainMDI.VIDE ;
			for (int CC=15;CC<31;CC++)	lvI.SubItems.Add("");
			//  'T' for txtFields ex: relaysNB ... 'B' for bool fields ex: Msg Lach
			
			                     //fill Desc and Symbl if Exists
			string st = T.boolToCar(T.look_Req_Value("C_DESC", TV,'A'),'T',ref UN,'P');
			lvI.SubItems[3].Text =(st.Length>1) ? "C_DESC||" + st : "";
			st =T.boolToCar(T.look_Req_Value("C_SNB", TV,'A'),'T',ref UN,'P');
			lvI.SubItems[3].Text +=(st.Length>1) ? "~" + "C_SNB||" + st : "";
            lvI.SubItems[3].Text += "~" + "C_ALC||" + alc;
			
			lvI.SubItems[15].Text =(T.boolToCar(T.look_Req_Value("C_DV", TV,'A'),'T',ref UN,'P'))  ; //+" " + boolToCar(T.look_Req_Value("C_UN", TV,'A'),'T'));   // Adj   
			lvI.SubItems[23].Text=UN;
			lvI.SubItems[16].Text =(T.boolToCar(T.look_Req_Value("C_DY", TV,'A'),'T',ref UN,'P'));   // Delay
			lvI.SubItems[24].Text=UN;
			lvI.SubItems[17].Text =T.boolToCar(T.look_Req_Value("C_ML", TV,'A'),'B',ref UN,'P');   //Msg Lach
			lvI.SubItems[25].Text=UN;
			lvI.SubItems[18].Text =(T.boolToCar(T.look_Req_Value("C_RY", TV,'A'),'T',ref UN,'P'));   //Relay #
			lvI.SubItems[26].Text=UN;
			lvI.SubItems[19].Text =(T.boolToCar(T.look_Req_Value("C_RL", TV,'A'),'B',ref UN,'P'));   //Relay Lach
			lvI.SubItems[27].Text=UN;
			lvI.SubItems[20].Text =(T.boolToCar(T.look_Req_Value("C_FS", TV,'A'),'B',ref UN,'P'));   // Fail Safe
			lvI.SubItems[28].Text=UN;
			lvI.SubItems[21].Text =(T.boolToCar(T.look_Req_Value("C_TO", TV,'A'),'T',ref UN,'P'));   //TimeOut
			lvI.SubItems[29].Text=UN;
			lvI.SubItems[22].Text =(T.boolToCar(T.look_Req_Value("C_ST", TV,'A'),'T',ref UN,'P'));   //Status
			lvI.SubItems[30].Text=UN;
			if (price=="0" && in_Chkd) {lvI.UseItemStyleForSubItems=true;  lvI.BackColor = Color.Khaki;}
			for (int CC=17;CC<23;CC++)
			{
				if  (lvI.SubItems[CC].Text =="Y" || lvI.SubItems[CC].Text =="ON") lvI.SubItems[CC].ForeColor = Color.Green ; 
				//if  (lvI.SubItems[CC].Text =="X") lvI.SubItems[CC].ForeColor = Color.Red ;
			}

/*
			string stfullD=c4;
			if (c5!= MainMDI.VIDE && c5!= "0")  stfullD +=  ", " + c5;
			if (c6!= MainMDI.VIDE && c6!= "0")  stfullD +=  ", " + c6;
		//	if (c7!= MainMDI.VIDE &&  c7!= "0")  stfullD +=  ", " + c7;  since cat7 is Reserved for EQ andAlarm's Tech. Values
			if (c1!=MainMDI.VIDE &&  c1!= "0")  stfullD += "-" + Deco_Alrm_Frml(c1) +"V";
			if (c2!=MainMDI.VIDE &&  c2!= "0")  stfullD +=  "-" + Deco_Alrm_Frml(c2)+"A";
			if (c3!=MainMDI.VIDE &&  c3!= "0")  stfullD +=  "-" + Deco_DLL(c3);
*/
			string stfullD=c4;
			if (c5!= MainMDI.VIDE && c5!= "0")  stfullD +=  ", " + c5;
			if (c6!= MainMDI.VIDE && c6!= "0")  stfullD +=  ", " + c6;
			for (int l=15;l<22;l++) 
			{
				if (lvI.SubItems[l].Text!="")
				{
					TV=deco_val(lvI.SubItems[l].Text,lvAlrmPL.Columns[l].Text , lvI.SubItems[l+8].Text ); 
					if (TV!="")  stfullD += ", " +TV ; 
				}
			
			}
			lvAlrmPL.Items[lvAlrmPL.Items.Count-1].SubItems[1].Text = stfullD ;
			lvAlrmPL.Items[lvAlrmPL.Items.Count-1].Checked =(price=="0" && in_Chkd);
		//	if (price=="0") {lvAlrmPL.Items[lvAlrmPL.Items.Count-1].Checked =true;lvAlrmPL.Items[lvAlrmPL.Items.Count-1]. BackColor = Color.Salmon ;}
			
			


		}
		
		private string oldEn_deco_val(string vl,string Coltxt,string Un)
		{

			string res=vl;
			switch (vl)
			{
				case "N":
					res= "No " + Coltxt;
					break;
				case "Y":
					res= Coltxt;
					break;
				case " ":
				case "~":
					res= "";
					break;
				default:
					res=Coltxt +": " + vl+ " " + Un;
					break;
			}
			return res;
		}
		private string deco_val(string vl,string Coltxt,string Un)
		{

			string res=vl;
			switch (vl)
			{
				case "N":
					res= (MainMDI.Lang ==1) ? fr_ALRM("No " + Coltxt) :  "No " + Coltxt;
					break;
				case "Y":
					res= (MainMDI.Lang ==1) ? fr_ALRM(Coltxt):Coltxt;
					break;
				case " ":
				case "~":
					res= "";
					break;
				default:
					res=(MainMDI.Lang ==1) ? fr_ALRM(Coltxt) +": " + vl+ " " + Un : Coltxt +": " + vl+ " " + Un;
					break;
			}
			return res;
		}
		private string fr_ALRM(string st)
		{
			string tt="???";
			switch (st)
			{

				case "Adjustment":
					tt= "Ajustement";
					break;
				case "Delay":
					tt= "Delai";
					break;
				case "No Delay":
					tt= "Pas de Delai";
					break;

				case "Msg Latch":
					tt= "Msg Verr.";
					break;
				case "No Msg Latch":
					tt= "Msg Non Verr.";
					break;

				case "Relay #":
					tt= "Relai #";
					break;

                case "Relay Latch":
					tt= "Relai Verr.";
					break;
				case "No Relay Latch":
					tt= "Relai Non Verr.";
					break;

				case "Fail Safe":
					tt= "Logique Positive";
					break;
				case "No Fail Safe":
					tt= "Pas de Logique Positive";
					break;

				case "Time Out":
					tt= "Temps arrêt";
					break;
				default:
					tt=st ;
					break;
			}
			return tt;

		}
	

		private string Deco_Alrm_Frml(string st)
		{
			string res="0",opRnd="";
			double oprT1=0, oprT2=0;
            
			switch (st[0])
			{

				case '$':
					res= st.Substring(1,st.Length -1); 
					break;
				case '!':
					int ipos=st.IndexOf(" " ,0);
					if (ipos==-1) 
					{ 
						if (st.Length >1 ) res= deco_Var(st.Substring(1,st.Length -1)).ToString ();
						else res= "";
					}
					else 
					{ 
						oprT1 = deco_Var(st.Substring(1,ipos-1));
						opRnd = st.Substring(ipos+1,1);
						oprT2 = Tools.Conv_Dbl(st.Substring(ipos+3,st.Length - ipos - 3 ));
						res=calul_Amnt(oprT1  ,opRnd ,oprT2  ).ToString (); 
					}
					break;
			}
			if (res =="0") MessageBox.Show ("This alarm Desc is invalid =" + st);
			return res;
						   
			
		}
		
		/*
		private double deco_Var_old(string st)
		{
				
			double res= 0;
			switch ( st)
			{
				case "VFLOAT":
					res= Tools.Conv_Dbl(in_frm_FDR.tVFLOAT.Text) ; 
					break;
				case "VEQUAL":
					res=Tools.Conv_Dbl(in_frm_FDR.tVEQL.Text) ; 
					break;
				case "VAC":
					res=Tools.Conv_Dbl(in_frm_FDR.tVac.Text) ; 
					break;
				case "IDC":
					res=Tools.Conv_Dbl(in_frm_FDR.cbIdc.Text) ; 
					break;
				case "VDCNOM":
					res=Tools.Conv_Dbl(in_frm_FDR.cbVdc.Text) ; 
					break;
				case "PHS":
					res=Tools.Conv_Dbl(in_frm_FDR.cbPhs.Text) ; 
					break;
			} 
			return res ;
		}
		*/
	
		private void fill_BigVCS()
		{
			string UN="";
			r_VFLOAT=T.boolToCar(T.look_Req_Value("Float",SNTecV.Text ,'C'),'T',ref UN,'P');
			r_VEQUAL=T.boolToCar(T.look_Req_Value("Eq",SNTecV.Text ,'C'),'T',ref UN,'P');
			r_VAC=T.boolToCar(T.look_Req_Value("C_VAC",SNTecV.Text ,'C'),'T',ref UN,'P');
			r_IDC=T.boolToCar(T.look_Req_Value("U_IDC",SNTecV.Text ,'C'),'T',ref UN,'P');
			r_VDCNOM=T.boolToCar(T.look_Req_Value("U_VDCNOM",SNTecV.Text ,'C'),'T',ref UN,'P');
			r_PHS=T.boolToCar(T.look_Req_Value("U_PHASE",SNTecV.Text ,'C'),'T',ref UN,'P');

		}
		private double deco_Var(string st)
		{
				
				double res= 0;
				switch ( st)
				{
					case "VFLOAT":
						res=Tools.Conv_Dbl(r_VFLOAT) ; 
						break;
					case "VEQUAL":
						res=Tools.Conv_Dbl(r_VEQUAL) ; 
						break;
					case "VAC":
						res=Tools.Conv_Dbl(r_VAC) ; 
						break;
					case "IDC":
						res=Tools.Conv_Dbl(r_IDC) ; 
						break;
					case "VDCNOM":
						res=Tools.Conv_Dbl(r_VDCNOM) ; 
						break;
					case "PHS":
						res=Tools.Conv_Dbl(r_PHS) ; 
						break;
				} 
				return res ;
		}

			
			private string calul_Amnt(double mnt1, string oper, double mnt2)
			{
				
				string calul_Amnt_Res = "0";
			//	double mnt1=0,mnt2=0;
			//	if (mnt1=="" ||   amnt2=="") return "0";
				switch ( oper)
				{
					case "*":
						calul_Amnt_Res = Convert.ToString(Math.Round(mnt1 * mnt2,Charger.NB_DEC_CAL ));
						break;
					case "-":
						calul_Amnt_Res  = Convert.ToString(Math.Round(mnt1 - mnt2,Charger.NB_DEC_CAL ));
						break;
					case "/":
						if (mnt2 > 0) calul_Amnt_Res  = Convert.ToString(Math.Round(mnt1 / mnt2, Charger.NB_DEC_CAL ));
						else calul_Amnt_Res  = "0";
						break;
					case "+":
						calul_Amnt_Res  = Convert.ToString(  Math.Round(mnt1 + mnt2, Charger.NB_DEC_CAL )  );
						break;
				} 
				return calul_Amnt_Res;
			}

		private string Deco_DLL(string st)
		{
          return Tools.Conv_Dbl(st.Substring(0,2)) + "sec-" + ((st.Substring(3,1)=="Y") ? "Latch-" : "No Latch-") +
			             ((st.Substring(5,1)=="P") ? "Fail Safe" : "No Fail Safe " );
		}

		private void lvAlrmPL_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lvAlrmPL.SelectedItems.Count ==1)  currCHK=lvAlrmPL.SelectedItems[0].Checked ; 

			
		}

		private void clear_scrn()
		{

			tAnam.Clear();
			tV.Clear();
			tTimeO.Clear ();
			tRelayNB.Clear (); 
			tdelay.Clear ();
			chkLogicFS.Checked =false;
			chkLogicFS.Checked =false; 
			chkMLatch.Checked =false;
			chkRlyLCH.Checked =false;
			chkLogicFS.Enabled  =true;
			chkLogicFS.Enabled  =true;
			chkMLatch.Enabled  =true;
			chkRlyLCH.Enabled  =true;
			ltdelay.Enabled =true;
			ltRelayNB.Enabled =true; 
			ltTimeO.Enabled =true; 
			tdelay.Enabled =true;
			tRelayNB.Enabled =true; 
			tTimeO.Enabled =true; 
			chkProp.Checked =true; 
			chkProp.Visible =true;
		//	lDesc.Text ="";
 
		}
		private void maj_tAname()
		{
			
			string stfullD=ar_SelLv[0];
			string TV="";
			if (ar_SelLv[1]!= MainMDI.VIDE && ar_SelLv[1]!= "0")  stfullD +=  ", " + ar_SelLv[1];
			if (ar_SelLv[2]!= MainMDI.VIDE && ar_SelLv[2]!= "0")  stfullD +=  ", " + ar_SelLv[2];
			for (int l=8;l<15;l++) 
			{
				if (ar_SelLv[l]!="")
				{
					TV=(MainMDI.Lang == 1 ) ? deco_val(ar_SelLv[l],lvAlrmPL.Columns[l+7].Text , ar_SelLv[l+8] ) : deco_val(ar_SelLv[l],lvAlrmPL.Columns[l+7].Text , ar_SelLv[l+8] )  ; 
					if (TV!="")  stfullD += ", " +TV ; 
				}
			
			}
			tAnam.Text = stfullD ;


		}
		private bool Valid_EQAL(string st)
		{
			return (st!=" " && st!="~");
		}

		private void lvAlrmPL_DoubleClick(object sender, System.EventArgs e)
		{
			Dblclk=true;
            lvAlrmPL.Enabled =false;
			grpDetails.Visible =true;grpOK.Visible = false;
			Alarms_EQ_Oth_SizeChanged(sender,e);
            lvAlrmPL.SelectedItems[0].Checked = currCHK ;
			SelNDX = lvAlrmPL.SelectedItems[0].Index ;
			clear_scrn();
			for (int s=0;s<24;s++) ar_SelLv[s]=lvAlrmPL.Items[SelNDX].SubItems[s+7].Text ; 
		//	lDesc.Text = lvAlrmPL.Items[SelNDX].SubItems[7];  
			tAnam.Text =lvAlrmPL.SelectedItems[0].SubItems[1].Text ;
			tV.Text = lvAlrmPL.SelectedItems[0].SubItems[15].Text;
	//		//
	//		if (tV.Text.Length >2 )
	//		{
	//			int ipos=tV.Text.IndexOf("~",0,2);
	//			if (ipos!=1) {ar_SelLv[1]= tV.Text.Substring(0,ipos); ar_SelLv[2]="n/a";}
	//		}
	//		//
         
			if (Valid_EQAL(lvAlrmPL.SelectedItems[0].SubItems[16].Text)) tdelay.Text = lvAlrmPL.SelectedItems[0].SubItems[16].Text ;
			     else {tdelay.Enabled = false;ltdelay.Enabled = false;}
            if (Valid_EQAL(lvAlrmPL.SelectedItems[0].SubItems[17].Text)) chkMLatch.Checked = (lvAlrmPL.SelectedItems[0].SubItems[17].Text=="Y") ;
		         else chkMLatch.Enabled =false;
			if (Valid_EQAL(lvAlrmPL.SelectedItems[0].SubItems[18].Text)) tRelayNB.Text =  lvAlrmPL.SelectedItems[0].SubItems[18].Text;
			     else {tRelayNB.Enabled =false;ltRelayNB.Enabled =false;}
			if (Valid_EQAL(lvAlrmPL.SelectedItems[0].SubItems[19].Text)) chkRlyLCH.Checked = (lvAlrmPL.SelectedItems[0].SubItems[19].Text=="Y") ;
			     else chkRlyLCH.Enabled =false;
			if (Valid_EQAL(lvAlrmPL.SelectedItems[0].SubItems[20].Text)) chkLogicFS.Checked = (lvAlrmPL.SelectedItems[0].SubItems[20].Text=="Y") ;
		         else chkLogicFS.Enabled =false;
            if (Valid_EQAL(lvAlrmPL.SelectedItems[0].SubItems[21].Text)) tTimeO.Text = lvAlrmPL.SelectedItems[0].SubItems[21].Text ;
		         else {tTimeO.Enabled =false;ltTimeO.Enabled =false;}
			if ( lvAlrmPL.SelectedItems[0].SubItems[3].Text==";") 
			{
				chkProp.Checked =false;
				chkProp.Enabled =false;
			}
			tUP.Text = lvAlrmPL.SelectedItems[0].SubItems[2].Text;
			tQty.Text ="1";
			btnSave.Text ="Update";

		//	if (lvAlrmPL.SelectedItems[0].SubItems[7].Text != MainMDI.VIDE )  tAnam.Text +=  ", " + lvAlrmPL.SelectedItems[0].SubItems[6].Text;
		//	if (lvAlrmPL.SelectedItems[0].SubItems[8].Text != MainMDI.VIDE )  tAnam.Text +=  ", " + lvAlrmPL.SelectedItems[0].SubItems[7].Text;
          //  if (lvAlrmPL.SelectedItems[0].SubItems[9].Text != MainMDI.VIDE )  tAnam.Text +=  ", " + lvAlrmPL.SelectedItems[0].SubItems[9].Text;
			
			
			

			
		    
		}


		private void disp_DLL(string st)
		{
	/*		if (st.Length == 6) 
			{
				tdelay.Text = Tools.Conv_Dbl(st.Substring(0,2)).ToString() ;
				chkLatch.Checked = (st.Substring(3,1)=="Y")  ;
				chkLogic.Checked = (st.Substring(5,1)=="P")  ;
			}
			*/
		
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			Dblclk=false;
			if ( btnSave.Text =="Update")
			{
				lvAlrmPL.Items[SelNDX].SubItems[1].Text =  tAnam.Text;  
				lvAlrmPL.Items[SelNDX].SubItems[15].Text=tV.Text;
				if (tdelay.Enabled) lvAlrmPL.Items[SelNDX].SubItems[16].Text=tdelay.Text;
				if (chkMLatch.Enabled)  lvAlrmPL.Items[SelNDX].SubItems[17].Text=( chkMLatch.Checked) ? "Y" : "N"  ;
				if (tRelayNB.Enabled) lvAlrmPL.Items[SelNDX].SubItems[18].Text=tRelayNB.Text;
				if (chkRlyLCH.Enabled)  lvAlrmPL.Items[SelNDX].SubItems[19].Text=( chkRlyLCH.Checked) ? "Y" : "N"  ;
				if (chkLogicFS.Enabled)  lvAlrmPL.Items[SelNDX].SubItems[20].Text=( chkLogicFS.Checked) ? "Y" : "N"  ;
				if (tTimeO.Enabled) lvAlrmPL.Items[SelNDX].SubItems[21].Text=tTimeO.Text;
				lvAlrmPL.Items[SelNDX].SubItems[2].Text=tUP.Text;
				//btnSave.Text ="Save";
				clear_scrn();
				grpDetails.Visible =false; 
				grpOK.Visible =true;
				Slmn_Line(SelNDX);
				lvAlrmPL.Items[SelNDX].SubItems[3].Text =  build_TV_Item(SelNDX);
				lvAlrmPL.Enabled =true;
			//	lvAlrmPL.Refresh();
					
				//lvAlrmPL.SelectedItems[0].Checked=true; 
				//return Tools.Conv_Dbl(st.Substring(0,2)) + "sec-" + ((st.Substring(3,1)=="Y") ? "Latch-" : "No Latch-") +
				//	((st.Substring(5,1)=="P") ? "Fail Safe" : "No Fail Safe" );
			}
			else 		
			{
				add_LVO(tUP.Text,MainMDI.VIDE ,MainMDI.VIDE,MainMDI.VIDE,tAnam.Text,MainMDI.VIDE,MainMDI.VIDE,MainMDI.VIDE,"0");
				clear_scrn();
				grpDetails.Visible =false; 
				grpOK.Visible =true;
				int tt=lvAlrmPL.Items.Count-1;
				lvAlrmPL.Items[tt].Checked =true;
				Slmn_Line(tt);
				lvAlrmPL.Items[tt].SubItems[3].Text =  build_TV_Item(tt);
				lvAlrmPL.Enabled =true;
				
				//if TV==";" ---> Tst/alarm properties free
				//lvAlrmPL.Items[lvAlrmPL.Items.Count-1 ].SubItems[3].Text =  build_TV_Item(lvAlrmPL.Items.Count-1); 
				

			}
		}
		private void Slmn_Line(int ndx)
		{
			if (lvAlrmPL.Items[ndx].Checked) 
			{
				lvAlrmPL.Items[ndx].UseItemStyleForSubItems=true; 
				lvAlrmPL.Items[ndx].BackColor = Color.Khaki ;
			}
			else 
			{
				lvAlrmPL.Items[ndx].UseItemStyleForSubItems=false; 
				lvAlrmPL.Items[ndx].BackColor = Color.WhiteSmoke  ;
			}
			
		}
		


		private void tUP_TextChanged(object sender, System.EventArgs e)
		{
           cal_tEXT();		
		}
		private void cal_tEXT()
		{
			tExt.Text = Convert.ToString(  Math.Round(Tools.Conv_Dbl(tQty.Text ) *  Tools.Conv_Dbl(tUP.Text ),MainMDI.NB_DEC_AFF));  
		}

		private void tQty_TextChanged(object sender, System.EventArgs e)
		{
			cal_tEXT();	
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			lSave.Text ="N";
			this.Close();
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void MLV_ALARMS_EQO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void chkON_CheckedChanged(object sender, System.EventArgs e)
		{
			//chkON.Text = "Status: " + ((chkON.Checked) ? "ON" : "OFF");  
		}

		private void picON_Click(object sender, System.EventArgs e)
		{
			
			PicOFF.Visible = picON.Visible ;
			picON.Visible = !PicOFF.Visible ; 
		}

		private void PicOFF_Click(object sender, System.EventArgs e)
		{
			PicOFF.Visible = picON.Visible ;
			picON.Visible = !PicOFF.Visible ; 
		}

		private void Alarms_EQ_Oth_SizeChanged(object sender, System.EventArgs e)
		{
			lvAlrmPL.Height =  (grpOK.Visible ) ? this.Height  - grpOK.Height  - 48 : this.Height  - grpDetails.Height   - 48 ;
			lvAlrmPL.Columns[1].Width = this.Width - 542;  //586;
		
		}

		private void Alarms_EQ_Oth_Resize(object sender, System.EventArgs e)
		{

		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{


			lSave.Text ="Y";
			this.Hide();
		}

		private void tV_TextChanged(object sender, System.EventArgs e)
		{
			ar_SelLv[8]=tV.Text ; 
			maj_tAname();
		}

		private void tdelay_TextChanged(object sender, System.EventArgs e)
		{
			ar_SelLv[9]=tdelay.Text ; 
			maj_tAname();
		}

		private void tRelayNB_TextChanged(object sender, System.EventArgs e)
		{
			ar_SelLv[11]=tRelayNB.Text ; 
			maj_tAname();
		}

		private void chkRlyLCH_CheckedChanged(object sender, System.EventArgs e)
		{
			ar_SelLv[12]=(chkRlyLCH.Checked ) ? "Y" : "N";
			maj_tAname();
		}

		private void chkMLatch_CheckedChanged(object sender, System.EventArgs e)
		{
			ar_SelLv[10]=(chkMLatch.Checked ) ? "Y" : "N";
			maj_tAname();
		}

		private void chkLogicFS_CheckedChanged(object sender, System.EventArgs e)
		{
			ar_SelLv[13]=(chkLogicFS.Checked ) ? "Y" : "N";
			maj_tAname();
		}

		private void tTimeO_TextChanged(object sender, System.EventArgs e)
		{
			ar_SelLv[14]=tTimeO.Text ; 
			maj_tAname();
		}

		private void lvAlrmPL_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			lvAlrmPL.Columns[3].Width =200; 
		}

		private void chkProp_CheckedChanged(object sender, System.EventArgs e)
		{
			grpProp.Visible = chkProp.Checked ;
            chkProp.Text = (chkProp.Checked) ? "Internal" : "External";
			btnSave.Text = ( chkProp.Checked ) ? "Update" : "Add";
		}

		private void chkProp_CheckedChanged_1(object sender, System.EventArgs e)
		{
		
		}
		public string CarToBool(string st,string UN)
		{
			// typ=T text             typ=B  bool checked or Not

			string res="";
			char typ='T';
			switch (st)
			{
				case "Y":
					res= "E";
					typ='B';
					break;
				case "N":
					res= "D";
					typ='B';
					break;
			}
			if (typ=='T' && st!=MainMDI.VIDE  && st!=" "  && st!="???"  ) res=st;
			if (UN!="" && res!="") res+= "^" + UN;
			return res;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			clear_scrn();
			grpDetails.Visible =false; 
			grpOK.Visible =true;
			if (SelNDX >-1)
			{
				Slmn_Line(SelNDX);
				lvAlrmPL.Enabled =true;
				lvAlrmPL.Refresh();
			}
		}

		private void lvAlrmPL_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			if (!Dblclk)
			{
				if (e.NewValue== CheckState.Checked  ) 
				{
					lvAlrmPL.Items[e.Index].UseItemStyleForSubItems=true; 
					lvAlrmPL.Items[e.Index].BackColor = Color.Khaki;
				}
				else 
				{
					lvAlrmPL.Items[e.Index].UseItemStyleForSubItems=false; 
					lvAlrmPL.Items[e.Index].BackColor = Color.WhiteSmoke  ;
				}
			}
		
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			lvAlrmPL.Enabled =false;
			grpDetails.Visible =true;
			grpOK.Visible = false;
			Alarms_EQ_Oth_SizeChanged(sender,e);
			//lvAlrmPL.SelectedItems[0].Checked = currCHK ;
			SelNDX = -1 ;
			clear_scrn();
			chkProp.Checked=false;
			chkProp.Visible =false;
		//	grpProp.Visible = chkProp.Checked ;
		//	chkProp.Text = (chkProp.Checked) ? "Internal" : "External";
		//	btnSave.Text = ( chkProp.Checked ) ? "Update" : "Add";
		}

		private void picOKk1_Click(object sender, System.EventArgs e)
		{
			
			for (int CC=0;CC<lvAlrmPL.Items.Count  ;CC++)
			 if (lvAlrmPL.Items[CC].SubItems[2].Text =="0" ) 
				{
					lvAlrmPL.Items[CC].Checked = !lvAlrmPL.Items[CC].Checked;
					lvAlrmPL.Items[CC].BackColor = (lvAlrmPL.Items[CC].Checked ) ? Color.Khaki : Color.WhiteSmoke   ;
				}

		}

		private void chkLogicFS_CheckedChanged_1(object sender, System.EventArgs e)
		{
		
		}
	

	

	

	


		//		string stfullD=Oreadr["CAT4_VALUE"].ToString ();
		//		if (Oreadr["CAT5_VALUE"].ToString ()!= MainMDI.VIDE )  stfullD +=  ", " + Oreadr["CAT5_VALUE"].ToString ();
		//		if (Oreadr["CAT6_VALUE"].ToString ()!= MainMDI.VIDE )  stfullD +=  ", " + Oreadr["CAT6_VALUE"].ToString ();
		//		if (Oreadr["CAT7_VALUE"].ToString ()!= MainMDI.VIDE )  stfullD +=  ", " + Oreadr["CAT7_VALUE"].ToString (); 				
		//		if (Oreadr["CAT1_VALUE"].ToString ()!=MainMDI.VIDE)  stfullD += "-" + Deco_Alrm_Frml(Oreadr["CAT1_VALUE"].ToString () ) +"V";
		//		if (Oreadr["CAT2_VALUE"].ToString ()!=MainMDI.VIDE)  stfullD +=  "-" + Deco_Alrm_Frml(Oreadr["CAT2_VALUE"].ToString ())+"A";
		//		if (Oreadr["CAT3_VALUE"].ToString ()!=MainMDI.VIDE)  stfullD +=  "-" + Deco_DLL(Oreadr["CAT3_VALUE"].ToString ());
		//		lvAlrmPL.Items[lvAlrmPL.Items.Count-1].SubItems[1].Text = stfullD ;
		//		lvAlrmPL.Items[lvAlrmPL.Items.Count-1].SubItems[3].Text = stfullD ;
		//		lvAlrmPL.Items[lvAlrmPL.Items.Count-1].Checked =true;
	

	}
}
