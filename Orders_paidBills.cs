using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data ;
using System.Data.OleDb ;
using System.Data.SqlClient  ;
using EAHLibs;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for paidBills.
	/// </summary>
	public class Orders_paidBills : System.Windows.Forms.Form
	{
        private Lib1 Tools = new Lib1();
		char opera='N' ;
		long in_BilLID=-1;
		string in_BAmnt="";
		int ndxSel=-1;

		private System.Windows.Forms.GroupBox groupBox12;
		private System.Windows.Forms.Label LcurConfndx;
		private System.Windows.Forms.Label label67;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ColumnHeader bp_LID;
		private System.Windows.Forms.ColumnHeader bp_Date;
		private System.Windows.Forms.ColumnHeader DocNB;
		private System.Windows.Forms.ColumnHeader bp_Amnt;
		private System.Windows.Forms.PictureBox picAdd_PB;
		private System.Windows.Forms.PictureBox picDelPB;
		private System.Windows.Forms.PictureBox picSavePB;
		private System.Windows.Forms.TextBox tDatPB;
		public System.Windows.Forms.TextBox tdocPB;
		public System.Windows.Forms.TextBox tAmntPB;
		public System.Windows.Forms.ListView lvPB;
		private System.Windows.Forms.GroupBox grpmodif;
		public System.Windows.Forms.DateTimePicker dpDatePB;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.PictureBox picReset;
		public System.Windows.Forms.TextBox lBal;
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.TextBox ltotpaid;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.ComboBox cbLot_Carr;
		private System.Windows.Forms.GroupBox grpchq;
		private System.Windows.Forms.GroupBox grpcc;
		private System.Windows.Forms.TextBox CCalias;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btneditCC;
		public System.Windows.Forms.TextBox tCCnb;
		private System.Windows.Forms.GroupBox grpinfo;
		private System.Windows.Forms.Label label9;
		public System.Windows.Forms.TextBox tinfo;
		private System.Windows.Forms.Label LNB;
		private System.Windows.Forms.ColumnHeader CCTy;
		private System.Windows.Forms.ColumnHeader NB;
		private System.Windows.Forms.PictureBox picExit;
        private ToolStrip TSmain;
        private ToolStripButton new_pay;
        private ToolStripButton Save;
        private ToolStripButton del;
        private ToolStripButton exiit;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Orders_paidBills(long x_bilID ,string x_BAmnt )
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			in_BilLID=x_bilID;
			in_BAmnt=x_BAmnt; 
			load_cur_PB();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Orders_paidBills));
            this.groupBox12 = new System.Windows.Forms.GroupBox();
            this.LcurConfndx = new System.Windows.Forms.Label();
            this.grpinfo = new System.Windows.Forms.GroupBox();
            this.tinfo = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.grpmodif = new System.Windows.Forms.GroupBox();
            this.grpchq = new System.Windows.Forms.GroupBox();
            this.tdocPB = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpcc = new System.Windows.Forms.GroupBox();
            this.btneditCC = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.tCCnb = new System.Windows.Forms.TextBox();
            this.CCalias = new System.Windows.Forms.TextBox();
            this.cbLot_Carr = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label67 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.tAmntPB = new System.Windows.Forms.TextBox();
            this.dpDatePB = new System.Windows.Forms.DateTimePicker();
            this.tDatPB = new System.Windows.Forms.TextBox();
            this.LNB = new System.Windows.Forms.Label();
            this.lBal = new System.Windows.Forms.TextBox();
            this.lvPB = new System.Windows.Forms.ListView();
            this.bp_LID = new System.Windows.Forms.ColumnHeader();
            this.bp_Date = new System.Windows.Forms.ColumnHeader();
            this.DocNB = new System.Windows.Forms.ColumnHeader();
            this.bp_Amnt = new System.Windows.Forms.ColumnHeader();
            this.CCTy = new System.Windows.Forms.ColumnHeader();
            this.NB = new System.Windows.Forms.ColumnHeader();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ltotpaid = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.picReset = new System.Windows.Forms.PictureBox();
            this.picSavePB = new System.Windows.Forms.PictureBox();
            this.picDelPB = new System.Windows.Forms.PictureBox();
            this.new_pay = new System.Windows.Forms.ToolStripButton();
            this.Save = new System.Windows.Forms.ToolStripButton();
            this.del = new System.Windows.Forms.ToolStripButton();
            this.exiit = new System.Windows.Forms.ToolStripButton();
            this.picAdd_PB = new System.Windows.Forms.PictureBox();
            this.groupBox12.SuspendLayout();
            this.grpinfo.SuspendLayout();
            this.grpmodif.SuspendLayout();
            this.grpchq.SuspendLayout();
            this.grpcc.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TSmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReset)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSavePB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelPB)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd_PB)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox12
            // 
            this.groupBox12.Controls.Add(this.TSmain);
            this.groupBox12.Controls.Add(this.picAdd_PB);
            this.groupBox12.Controls.Add(this.LcurConfndx);
            this.groupBox12.Controls.Add(this.grpinfo);
            this.groupBox12.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox12.Location = new System.Drawing.Point(0, 0);
            this.groupBox12.Name = "groupBox12";
            this.groupBox12.Size = new System.Drawing.Size(765, 89);
            this.groupBox12.TabIndex = 264;
            this.groupBox12.TabStop = false;
            this.groupBox12.Enter += new System.EventHandler(this.groupBox12_Enter);
            // 
            // LcurConfndx
            // 
            this.LcurConfndx.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LcurConfndx.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LcurConfndx.Location = new System.Drawing.Point(464, 24);
            this.LcurConfndx.Name = "LcurConfndx";
            this.LcurConfndx.Size = new System.Drawing.Size(24, 16);
            this.LcurConfndx.TabIndex = 236;
            this.LcurConfndx.Visible = false;
            // 
            // grpinfo
            // 
            this.grpinfo.Controls.Add(this.tinfo);
            this.grpinfo.Controls.Add(this.label9);
            this.grpinfo.Location = new System.Drawing.Point(112, 32);
            this.grpinfo.Name = "grpinfo";
            this.grpinfo.Size = new System.Drawing.Size(424, 48);
            this.grpinfo.TabIndex = 274;
            this.grpinfo.TabStop = false;
            this.grpinfo.Visible = false;
            // 
            // tinfo
            // 
            this.tinfo.BackColor = System.Drawing.Color.Lavender;
            this.tinfo.Location = new System.Drawing.Point(40, 16);
            this.tinfo.Name = "tinfo";
            this.tinfo.Size = new System.Drawing.Size(288, 20);
            this.tinfo.TabIndex = 259;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(8, 16);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(32, 20);
            this.label9.TabIndex = 260;
            this.label9.Text = "Info:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(0, 10);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(56, 16);
            this.label2.TabIndex = 268;
            this.label2.Text = "Balance:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpmodif
            // 
            this.grpmodif.Controls.Add(this.grpcc);
            this.grpmodif.Controls.Add(this.grpchq);
            this.grpmodif.Controls.Add(this.picExit);
            this.grpmodif.Controls.Add(this.cbLot_Carr);
            this.grpmodif.Controls.Add(this.label67);
            this.grpmodif.Controls.Add(this.label4);
            this.grpmodif.Controls.Add(this.label12);
            this.grpmodif.Controls.Add(this.tAmntPB);
            this.grpmodif.Controls.Add(this.picSavePB);
            this.grpmodif.Controls.Add(this.picDelPB);
            this.grpmodif.Controls.Add(this.LNB);
            this.grpmodif.Controls.Add(this.dpDatePB);
            this.grpmodif.Controls.Add(this.tDatPB);
            this.grpmodif.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpmodif.Location = new System.Drawing.Point(0, 89);
            this.grpmodif.Name = "grpmodif";
            this.grpmodif.Size = new System.Drawing.Size(765, 68);
            this.grpmodif.TabIndex = 265;
            this.grpmodif.TabStop = false;
            this.grpmodif.Visible = false;
            // 
            // grpchq
            // 
            this.grpchq.Controls.Add(this.tdocPB);
            this.grpchq.Controls.Add(this.label1);
            this.grpchq.Location = new System.Drawing.Point(349, 18);
            this.grpchq.Name = "grpchq";
            this.grpchq.Size = new System.Drawing.Size(285, 37);
            this.grpchq.TabIndex = 272;
            this.grpchq.TabStop = false;
            this.grpchq.Visible = false;
            // 
            // tdocPB
            // 
            this.tdocPB.BackColor = System.Drawing.Color.Lavender;
            this.tdocPB.Location = new System.Drawing.Point(55, 11);
            this.tdocPB.Name = "tdocPB";
            this.tdocPB.Size = new System.Drawing.Size(224, 20);
            this.tdocPB.TabIndex = 259;
            this.tdocPB.TextChanged += new System.EventHandler(this.tdocPB_TextChanged);
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(6, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 20);
            this.label1.TabIndex = 260;
            this.label1.Text = "Check#:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpcc
            // 
            this.grpcc.Controls.Add(this.btneditCC);
            this.grpcc.Controls.Add(this.label5);
            this.grpcc.Controls.Add(this.tCCnb);
            this.grpcc.Controls.Add(this.CCalias);
            this.grpcc.Location = new System.Drawing.Point(349, 18);
            this.grpcc.Name = "grpcc";
            this.grpcc.Size = new System.Drawing.Size(408, 36);
            this.grpcc.TabIndex = 273;
            this.grpcc.TabStop = false;
            this.grpcc.Visible = false;
            // 
            // btneditCC
            // 
            this.btneditCC.Location = new System.Drawing.Point(342, 10);
            this.btneditCC.Name = "btneditCC";
            this.btneditCC.Size = new System.Drawing.Size(56, 20);
            this.btneditCC.TabIndex = 261;
            this.btneditCC.Text = "New";
            this.btneditCC.Click += new System.EventHandler(this.btneditCC_Click);
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(6, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 16);
            this.label5.TabIndex = 260;
            this.label5.Text = "Credit Card#:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tCCnb
            // 
            this.tCCnb.BackColor = System.Drawing.Color.Lavender;
            this.tCCnb.Location = new System.Drawing.Point(80, 10);
            this.tCCnb.Name = "tCCnb";
            this.tCCnb.Size = new System.Drawing.Size(256, 20);
            this.tCCnb.TabIndex = 262;
            this.tCCnb.TextChanged += new System.EventHandler(this.tCCnb_TextChanged);
            // 
            // CCalias
            // 
            this.CCalias.BackColor = System.Drawing.Color.AliceBlue;
            this.CCalias.Location = new System.Drawing.Point(80, 10);
            this.CCalias.Name = "CCalias";
            this.CCalias.ReadOnly = true;
            this.CCalias.Size = new System.Drawing.Size(256, 20);
            this.CCalias.TabIndex = 259;
            // 
            // cbLot_Carr
            // 
            this.cbLot_Carr.BackColor = System.Drawing.Color.Lavender;
            this.cbLot_Carr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbLot_Carr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbLot_Carr.Items.AddRange(new object[] {
            "Please choose",
            "Check",
            "Credit Card"});
            this.cbLot_Carr.Location = new System.Drawing.Point(224, 28);
            this.cbLot_Carr.Name = "cbLot_Carr";
            this.cbLot_Carr.Size = new System.Drawing.Size(119, 21);
            this.cbLot_Carr.TabIndex = 271;
            this.cbLot_Carr.SelectedIndexChanged += new System.EventHandler(this.cbLot_Carr_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(230, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 18);
            this.label4.TabIndex = 270;
            this.label4.Text = "Payment Method:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label67
            // 
            this.label67.BackColor = System.Drawing.Color.Transparent;
            this.label67.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label67.Location = new System.Drawing.Point(12, 7);
            this.label67.Name = "label67";
            this.label67.Size = new System.Drawing.Size(83, 18);
            this.label67.TabIndex = 264;
            this.label67.Text = "Payment date";
            this.label67.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(138, 9);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(48, 18);
            this.label12.TabIndex = 261;
            this.label12.Text = "Amount";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tAmntPB
            // 
            this.tAmntPB.BackColor = System.Drawing.Color.Lavender;
            this.tAmntPB.Location = new System.Drawing.Point(113, 28);
            this.tAmntPB.Name = "tAmntPB";
            this.tAmntPB.Size = new System.Drawing.Size(105, 20);
            this.tAmntPB.TabIndex = 262;
            this.tAmntPB.TextChanged += new System.EventHandler(this.tAmntPB_TextChanged);
            // 
            // dpDatePB
            // 
            this.dpDatePB.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dpDatePB.CalendarTitleBackColor = System.Drawing.Color.Lavender;
            this.dpDatePB.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dpDatePB.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpDatePB.Location = new System.Drawing.Point(3, 27);
            this.dpDatePB.Name = "dpDatePB";
            this.dpDatePB.Size = new System.Drawing.Size(104, 20);
            this.dpDatePB.TabIndex = 265;
            this.dpDatePB.Value = new System.DateTime(2006, 12, 27, 14, 47, 36, 486);
            this.dpDatePB.ValueChanged += new System.EventHandler(this.dpDatePB_ValueChanged);
            // 
            // tDatPB
            // 
            this.tDatPB.BackColor = System.Drawing.Color.AliceBlue;
            this.tDatPB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tDatPB.Location = new System.Drawing.Point(3, 27);
            this.tDatPB.MaxLength = 49;
            this.tDatPB.Name = "tDatPB";
            this.tDatPB.ReadOnly = true;
            this.tDatPB.Size = new System.Drawing.Size(104, 21);
            this.tDatPB.TabIndex = 266;
            // 
            // LNB
            // 
            this.LNB.BackColor = System.Drawing.Color.CornflowerBlue;
            this.LNB.ForeColor = System.Drawing.SystemColors.ControlText;
            this.LNB.Location = new System.Drawing.Point(-6, 81);
            this.LNB.Name = "LNB";
            this.LNB.Size = new System.Drawing.Size(192, 16);
            this.LNB.TabIndex = 275;
            this.LNB.Visible = false;
            // 
            // lBal
            // 
            this.lBal.BackColor = System.Drawing.Color.AliceBlue;
            this.lBal.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lBal.Location = new System.Drawing.Point(56, 8);
            this.lBal.Name = "lBal";
            this.lBal.ReadOnly = true;
            this.lBal.Size = new System.Drawing.Size(112, 20);
            this.lBal.TabIndex = 270;
            // 
            // lvPB
            // 
            this.lvPB.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvPB.AutoArrange = false;
            this.lvPB.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvPB.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bp_LID,
            this.bp_Date,
            this.DocNB,
            this.bp_Amnt,
            this.CCTy,
            this.NB});
            this.lvPB.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvPB.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvPB.ForeColor = System.Drawing.Color.Black;
            this.lvPB.FullRowSelect = true;
            this.lvPB.GridLines = true;
            this.lvPB.Location = new System.Drawing.Point(0, 157);
            this.lvPB.Name = "lvPB";
            this.lvPB.Size = new System.Drawing.Size(765, 335);
            this.lvPB.TabIndex = 266;
            this.lvPB.UseCompatibleStateImageBehavior = false;
            this.lvPB.View = System.Windows.Forms.View.Details;
            this.lvPB.SelectedIndexChanged += new System.EventHandler(this.lvPB_SelectedIndexChanged);
            this.lvPB.DoubleClick += new System.EventHandler(this.lvPB_DoubleClick);
            // 
            // bp_LID
            // 
            this.bp_LID.Text = "";
            this.bp_LID.Width = 0;
            // 
            // bp_Date
            // 
            this.bp_Date.Text = "Date";
            this.bp_Date.Width = 71;
            // 
            // DocNB
            // 
            this.DocNB.Text = "Payment info";
            this.DocNB.Width = 242;
            // 
            // bp_Amnt
            // 
            this.bp_Amnt.Text = "Amount";
            this.bp_Amnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.bp_Amnt.Width = 81;
            // 
            // CCTy
            // 
            this.CCTy.Width = 0;
            // 
            // NB
            // 
            this.NB.Width = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ltotpaid);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.lBal);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 460);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(765, 32);
            this.groupBox1.TabIndex = 267;
            this.groupBox1.TabStop = false;
            // 
            // ltotpaid
            // 
            this.ltotpaid.BackColor = System.Drawing.Color.AliceBlue;
            this.ltotpaid.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ltotpaid.Location = new System.Drawing.Point(312, 8);
            this.ltotpaid.Name = "ltotpaid";
            this.ltotpaid.ReadOnly = true;
            this.ltotpaid.Size = new System.Drawing.Size(112, 20);
            this.ltotpaid.TabIndex = 272;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(240, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(72, 16);
            this.label3.TabIndex = 271;
            this.label3.Text = "Total paid:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TSmain
            // 
            this.TSmain.AutoSize = false;
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.new_pay,
            this.Save,
            this.del,
            this.exiit});
            this.TSmain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.TSmain.Location = new System.Drawing.Point(3, 16);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(759, 63);
            this.TSmain.TabIndex = 275;
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.Image = ((System.Drawing.Image)(resources.GetObject("picExit.Image")));
            this.picExit.Location = new System.Drawing.Point(512, 88);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(48, 40);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 276;
            this.picExit.TabStop = false;
            this.picExit.Visible = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // picReset
            // 
            this.picReset.BackColor = System.Drawing.Color.Transparent;
            this.picReset.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picReset.Image = ((System.Drawing.Image)(resources.GetObject("picReset.Image")));
            this.picReset.Location = new System.Drawing.Point(88, 127);
            this.picReset.Name = "picReset";
            this.picReset.Size = new System.Drawing.Size(32, 30);
            this.picReset.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picReset.TabIndex = 269;
            this.picReset.TabStop = false;
            this.picReset.Visible = false;
            this.picReset.WaitOnLoad = true;
            this.picReset.Click += new System.EventHandler(this.picReset_Click);
            // 
            // picSavePB
            // 
            this.picSavePB.BackColor = System.Drawing.Color.Transparent;
            this.picSavePB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSavePB.Image = ((System.Drawing.Image)(resources.GetObject("picSavePB.Image")));
            this.picSavePB.Location = new System.Drawing.Point(192, 96);
            this.picSavePB.Name = "picSavePB";
            this.picSavePB.Size = new System.Drawing.Size(48, 32);
            this.picSavePB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSavePB.TabIndex = 235;
            this.picSavePB.TabStop = false;
            this.picSavePB.Visible = false;
            this.picSavePB.Click += new System.EventHandler(this.picSavePB_Click);
            // 
            // picDelPB
            // 
            this.picDelPB.BackColor = System.Drawing.Color.Transparent;
            this.picDelPB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelPB.Image = ((System.Drawing.Image)(resources.GetObject("picDelPB.Image")));
            this.picDelPB.Location = new System.Drawing.Point(256, 96);
            this.picDelPB.Name = "picDelPB";
            this.picDelPB.Size = new System.Drawing.Size(48, 32);
            this.picDelPB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelPB.TabIndex = 234;
            this.picDelPB.TabStop = false;
            this.picDelPB.Visible = false;
            this.picDelPB.Click += new System.EventHandler(this.picDelPB_Click);
            // 
            // new_pay
            // 
            this.new_pay.Image = global::PGESCOM.Properties.Resources.calculator_add;
            this.new_pay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.new_pay.Name = "new_pay";
            this.new_pay.Size = new System.Drawing.Size(77, 60);
            this.new_pay.Text = "New Payment";
            this.new_pay.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.new_pay.Click += new System.EventHandler(this.picAdd_PB_Click);
            // 
            // Save
            // 
            this.Save.Image = global::PGESCOM.Properties.Resources.Floppy;
            this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(36, 60);
            this.Save.Text = "Save";
            this.Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Save.Click += new System.EventHandler(this.picSavePB_Click);
            // 
            // del
            // 
            this.del.Image = global::PGESCOM.Properties.Resources.remove1;
            this.del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(87, 60);
            this.del.Text = "Delete Payment";
            this.del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.del.Click += new System.EventHandler(this.picDelPB_Click);
            // 
            // exiit
            // 
            this.exiit.Image = ((System.Drawing.Image)(resources.GetObject("exiit.Image")));
            this.exiit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exiit.Name = "exiit";
            this.exiit.Size = new System.Drawing.Size(36, 60);
            this.exiit.Text = "Exit";
            this.exiit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exiit.ToolTipText = "Exit";
            this.exiit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // picAdd_PB
            // 
            this.picAdd_PB.BackColor = System.Drawing.Color.Transparent;
            this.picAdd_PB.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAdd_PB.Image = ((System.Drawing.Image)(resources.GetObject("picAdd_PB.Image")));
            this.picAdd_PB.Location = new System.Drawing.Point(384, 16);
            this.picAdd_PB.Name = "picAdd_PB";
            this.picAdd_PB.Size = new System.Drawing.Size(64, 32);
            this.picAdd_PB.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAdd_PB.TabIndex = 233;
            this.picAdd_PB.TabStop = false;
            this.picAdd_PB.Visible = false;
            this.picAdd_PB.Click += new System.EventHandler(this.picAdd_PB_Click);
            // 
            // Orders_paidBills
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(765, 492);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.lvPB);
            this.Controls.Add(this.grpmodif);
            this.Controls.Add(this.groupBox12);
            this.Controls.Add(this.picReset);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Orders_paidBills";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Invoice Payments";
            this.Load += new System.EventHandler(this.Orders_paidBills_Load);
            this.groupBox12.ResumeLayout(false);
            this.grpinfo.ResumeLayout(false);
            this.grpinfo.PerformLayout();
            this.grpmodif.ResumeLayout(false);
            this.grpmodif.PerformLayout();
            this.grpchq.ResumeLayout(false);
            this.grpchq.PerformLayout();
            this.grpcc.ResumeLayout(false);
            this.grpcc.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picReset)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSavePB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelPB)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd_PB)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private bool valid_data()
		{
			 bool res=true;
			 res=(Tools.Conv_Dbl(tAmntPB.Text) >0 && tDatPB.Text.Length >4 );
			 if (cbLot_Carr.Text =="Check" && tdocPB.Text.Length <1) res=false;
			 if (cbLot_Carr.Text =="Credit Card" && tCCnb.Text.Length <1) res=false;
			return res;
			 
      
		}

		private void picSavePB_Click(object sender, System.EventArgs e)
		{
			string stSql="";
			if (!valid_data()) MessageBox.Show("Sorry some fields are invalid...!!!!");
			else
			{
				if (Tools.Conv_Dbl(tAmntPB.Text ) <= Tools.Conv_Dbl(lBal.Text))
				{
					if (opera =='N')
					{
						ListViewItem lvI =  lvPB.Items.Add(tDatPB.Text   ); 
						lvI.SubItems.Add(tdocPB.Text   ); 
						lvI.SubItems.Add(tAmntPB.Text   ); 
						stSql= "INSERT INTO PSM_R_SBillsPaid ([pb_BilLID],[pb_date],[PaidType],[pb_DOCNO], " + 
							" [pb_Amnt], [pb_rnk]) VALUES ('" + 
							in_BilLID    + "', " +
							MainMDI.SSV_date(tDatPB.Text) + ", '" +   //date PB
							cbLot_Carr.Text[cbLot_Carr.Text.Length-1]    + "', '" +  //Doc#
							LNB.Text.Replace("'","''")      + "', " +  //Doc#
							Tools.Conv_Dbl(tAmntPB.Text)    + ", " +  //Amnt
							(lvPB.Items.Count - 1)   + ")"; //tmp_ndx
						MainMDI.ExecSql(stSql);  
						MainMDI.Write_JFS(stSql );
					                       	//grpmodif.Visible =false;
						tdocPB.Clear ();
						tAmntPB.Clear (); 
					}
					else
					{
						
						stSql= "UPDATE PSM_R_SBillsPaid  SET " + 	
							" [pb_date]=" + MainMDI.SSV_date(tDatPB.Text) + 
							" [PaidType]=" + cbLot_Carr.Text[cbLot_Carr.Text.Length-1] + 
							", [pb_DOCNO]='" + LNB.Text.Replace("'","''") + 
							"',  [pb_Amnt]=" + Tools.Conv_Dbl(tAmntPB.Text)   + 
 						//	"', [b_Rnk]='" + lcurBilNDX.Text + 
							" WHERE pb_LID=" + lvPB.Items[ndxSel].SubItems[0].Text       ;   
						MainMDI.ExecSql(stSql);
						MainMDI.Write_JFS(stSql );
						lvPB.Items[ndxSel].SubItems[1].Text = tDatPB.Text  ;
						lvPB.Items[ndxSel].SubItems[2].Text = tdocPB.Text  ;
						lvPB.Items[ndxSel].SubItems[3].Text = Tools.Conv_Dbl(tAmntPB.Text).ToString()   ;
						opera ='N'; 
						lvPB.Enabled =true;
					}
					picReset_Click(sender,e);  
				}
				else MessageBox.Show ("Amount is Invalid.... must <= Balance"); 
			}
			
		}
		private void cal_TotPaid()
		{
			double tt=0;
			for (int i=0;i<lvPB.Items.Count ;i++)
				tt += Tools.Conv_Dbl (lvPB.Items[i].SubItems[3].Text) ;   
			ltotpaid.Text = MainMDI.A00( tt.ToString ());
			    
		}
		private void lvPB_DoubleClick(object sender, System.EventArgs e)
		{
			dpDatePB.Text  = lvPB.SelectedItems[0].SubItems[1].Text;
			cbLot_Carr.Text =  paid_type(lvPB.SelectedItems[0].SubItems[4].Text);
            if (grpchq.Visible )  tdocPB.Text =lvPB.SelectedItems[0].SubItems[5].Text ;
			if (grpcc.Visible )  tCCnb.Text =lvPB.SelectedItems[0].SubItems[5].Text ;
			tAmntPB.Text = lvPB.SelectedItems[0].SubItems[3].Text;
			lBal.Text = Convert.ToString (Tools.Conv_Dbl(tAmntPB.Text) +  Tools.Conv_Dbl(lBal.Text));
			opera ='U'; 
			//lSelI.Text = lvPTC.SelectedItems[0].Index.ToString() ;
			lvPB.Enabled =false;
			ndxSel=lvPB.SelectedItems[0].Index ;
			grpmodif.Visible =true;
		}

		private void dpDatePB_ValueChanged(object sender, System.EventArgs e)
		{
			tDatPB.Text = dpDatePB.Value.ToShortDateString();  
		}

		private void picAdd_PB_Click(object sender, System.EventArgs e)
		{
			//dpDatePB_ValueChanged (sender,e); 
			dpDatePB.Text = DateTime.Now.ToShortDateString ();  
			grpmodif.Visible =true;
			opera='N';
            picReset_Click(sender ,e );

		}

		private string paid_type(string cc)
		{
			string res="???";
			switch (cc)
			{
				case "k":
					res="Check";
					break;
				case "d":
					res="Credit Card";
					break;
			}
			return res;
		}
		private void load_cur_PB()
		{
		
			string stSql=" SELECT * FROM PSM_R_SBillsPaid WHERE pb_BilLID = " + in_BilLID + " ORDER BY pb_rnk ";
			
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			lvPB.Items.Clear (); 
			double tot=0;

			while (Oreadr.Read ()) 
			{   
				ListViewItem lv =lvPB.Items.Add(Oreadr["pb_LID"].ToString()); //LID
              	lv.SubItems.Add( Oreadr["pb_date"].ToString().Substring(0,10)); //date
				lv.SubItems.Add(paid_type(Oreadr["PaidType"].ToString()) +"#: " +  Oreadr["pb_DOCNO"].ToString()); //doc#
				lv.SubItems.Add( Oreadr["pb_Amnt"].ToString()); //Amnt
				lv.SubItems.Add( Oreadr["PaidType"].ToString()); //Amnt
				lv.SubItems.Add( Oreadr["pb_DOCNO"].ToString()); //Amnt
				tot+=Tools.Conv_Dbl( Oreadr["pb_Amnt"].ToString());

			}
             lBal.Text = MainMDI.A00 (Convert.ToString((Tools.Conv_Dbl(in_BAmnt) - tot))) ;
			ltotpaid.Text = tot.ToString ();
			OConn.Close(); 
		}

		private void tAmntPB_TextChanged(object sender, System.EventArgs e)
		{

		}

		private void picDelPB_Click(object sender, System.EventArgs e)
		{

			if (lvPB.SelectedItems.Count == 1 && lvPB.Enabled  )
			{
				
				if (MainMDI.Confirm("Want to delete this piament ?"))
				{

					string stSql="delete PSM_R_SBillsPaid  where pb_LID=" + lvPB.SelectedItems[0].SubItems[0].Text;
					MainMDI.ExecSql(stSql); 
					MainMDI.Write_JFS(stSql);  
					picReset_Click(sender,e);
				}
			}
		}

		private void lvPB_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void picReset_Click(object sender, System.EventArgs e)
		{
			lvPB.Enabled =true;
			dpDatePB.Text = DateTime.Now.ToShortDateString ();  
			opera='N';
			tAmntPB.Clear ();
			tdocPB.Clear (); 
			tCCnb.Clear (); 
			load_cur_PB(); 
			cbLot_Carr.Text = cbLot_Carr.Items[0].ToString ();  
 
		
		}

		private void Orders_paidBills_Load(object sender, System.EventArgs e)
		{
			dpDatePB.Text = DateTime.Now.ToShortDateString ();  
		//	grpmodif.Visible =true;
			opera='N'; 
		}

		private void btneditCC_Click(object sender, System.EventArgs e)
		{
			string cpny=MainMDI.Find_One_Field(" SELECT PSM_COMPANY.Cpny_Name1 FROM PSM_R_SBills INNER JOIN PSM_R_Rev ON PSM_R_SBills.b_RRevLID = PSM_R_Rev.IRRevID INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID " +
                                               " WHERE     PSM_R_SBills.Bil_LID =" + in_BilLID );  
			if (cpny != MainMDI.VIDE )
			{
				dlgCreditCrds dlgCC = new dlgCreditCrds(tCCnb.Text,cpny );
				dlgCC.ShowDialog (); 
				if ( dlgCC.lOK ) tCCnb.Text = dlgCC.tCCnb.Text ;
				dlgCC.Close ();dlgCC.Dispose ();
			}
			else MessageBox.Show("Sorry cannot find Company name for this Bill.....contact your Admin"); 
		}

		private void cbLot_Carr_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			grpchq.Visible =cbLot_Carr.Text=="Check";
			grpcc.Visible =cbLot_Carr.Text=="Credit Card";
			grpinfo.Visible =cbLot_Carr.Text=="Bank/Wire Transfer";
		

		}

		private void groupBox12_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void tdocPB_TextChanged(object sender, System.EventArgs e)
		{
			LNB.Text = tdocPB.Text ;
		}

		private void tCCnb_TextChanged(object sender, System.EventArgs e)
		{
			LNB.Text = tCCnb.Text ;
		}

		private void picExit_Click(object sender, System.EventArgs e)
		{
			this.Hide ();
		}





	}
}
