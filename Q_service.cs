using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using EAHLibs;
using System.Collections.Generic;

namespace PGESCOM
{
	/// <summary>
    /// Summary description for Q_service.
	/// </summary>
	public class Q_service : System.Windows.Forms.Form
	{
        string H1_val = "0", H2_val = "0", H3_val = "0", H4_val = "0", H5_val = "0", H6_val = "0";
        string H1_lim = "0", H2_lim = "0", H3_lim = "0", H4_lim = "0", H5_lim = "0", H6_lim = "0";
        string H1_amt = "0", H2_amt = "0", H3_amt = "0", H4_amt = "0", H5_amt = "0", H6_amt = "0";

        bool AutoCal = true;

        bool dblclik = false;
		private Lib1 Tools = new Lib1();
		private ListViewColumnSorter lvSorter = null;
		private string In_QID;
		public bool SaveOK = false;
		private int LVNdx = -1;
        string in_keyinfo = "";
		private System.Windows.Forms.GroupBox grpItem;
		public System.Windows.Forms.TextBox lIotherF;
		public System.Windows.Forms.TextBox tIotherF;
		private System.Windows.Forms.Label not;
		private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        public System.Windows.Forms.TextBox lif2;
		public System.Windows.Forms.TextBox lif1;
        private System.Windows.Forms.Label ll;
        private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button btnDel;
		public System.Windows.Forms.CheckBox chk1;
		public System.Windows.Forms.CheckBox chk2;
		public System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label36;
        public System.Windows.Forms.TextBox tSMRK;
		public System.Windows.Forms.CheckBox chkD;
		public System.Windows.Forms.CheckBox chkM;
		private System.Windows.Forms.Button btnClear;
        public System.Windows.Forms.CheckBox chkAuto;
        private System.Windows.Forms.PictureBox pictureBox3;
        public TextBox valFrais;
        private Label label10;
        private Label label9;
        private Label lsave;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private PictureBox picSeek;
        public TextBox textBox4;
        public TextBox txC7;
        public TextBox textBox7;
        public TextBox textBox1;
        public TextBox txB9;
        public TextBox textBox2;
        public TextBox txB6;
        public TextBox txC11;
        public TextBox textBox8;
        public TextBox textBox9;
        public TextBox txB10;
        public TextBox textBox6;
        public TextBox textBox5;
        public TextBox textBox3;
        public TextBox textBox10;
        public TextBox textBox15;
        public TextBox txB19;
        public TextBox textBox19;
        public TextBox txB18;
        public TextBox txC24_th;
        public TextBox textBox14;
        public TextBox txB17;
        public TextBox textBox16;
        public TextBox textBox17;
        public TextBox txB16;
        private Label label1;
        public TextBox txC13;
        public TextBox textBox13;
        private Label cof13;
        public ComboBox cbTmtype;
        public TextBox textBox21;
        public TextBox txB21;
        public TextBox textBox23;
        public TextBox txB20;
        private Label label11;
        private Label label8;
        private Label label7;
        private Label label6;
        public TextBox textBox27;
        public TextBox B32;
        public TextBox textBox11;
        public TextBox B31;
        private Label B29;
        public ComboBox cbsvcType;
        public TextBox textBox38;
        public TextBox txB30;
        public TextBox textBox40;
        public TextBox txC33_ts;
        public TextBox textBox43;
        public TextBox textBox45;
        public TextBox textBox46;
        public TextBox txB27;
        private Label cof11_b;
        private Label cof11_a;
        private Label cof7;
        private Label cof21;
        private Label cof20;
        private Label cof19;
        private Label cof18;
        private Label cof17;
        private Label cof16;
        public TextBox txC17;
        public TextBox txC18;
        public TextBox txC21;
        public TextBox txC20;
        public TextBox txC19;
        public TextBox txC16;
        private Label label5;
        private Label label2;
        private Label cof32;
        private Label cof31;
        private Label cof30;
        public TextBox B30;
        public TextBox txC38_ts;
        public TextBox textBox41;
        public TextBox txC37_ts;
        public TextBox textBox35;
        public TextBox txB36_ts;
        public TextBox txC36_ts;
        public TextBox textBox32;
        public TextBox txC35;
        public TextBox textBox26;
        private Label label14;
        private Label label13;
        public TextBox txC39;
        public TextBox txitem;
        public TextBox txC22;
        private Label lcbval;
        private Label lhrs_msg;
        public PictureBox picalrm;
        public TextBox txC38_th;
        public TextBox textBox18;
        public TextBox txC37_th;
        public TextBox textBox22;
        public TextBox txB36_th;
        public TextBox txC36_th;
        public TextBox textBox28;
        public TextBox txC35_th;
        public TextBox textBox30;
        private Panel panel2;
        private Panel panel1;
        private Label lfr_ts;
        private Label leng_ts;
        public TextBox txC39_ts;
        public TextBox txitem_ts;
        private Label lfr_dh;
        private Label leng_dh;
        public TextBox txC39_th;
        public TextBox txitem_th;
        public TextBox txC35_ts;
        public CheckBox chk_ts;
        public TextBox textBox31;
        public CheckBox chk_th;
        public TextBox textBox29;

        int in_lang = 0;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public Q_service()
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();

			lvSorter = new ListViewColumnSorter();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Q_service));
            this.grpItem = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.chk_ts = new System.Windows.Forms.CheckBox();
            this.textBox31 = new System.Windows.Forms.TextBox();
            this.txC35_ts = new System.Windows.Forms.TextBox();
            this.lfr_ts = new System.Windows.Forms.Label();
            this.leng_ts = new System.Windows.Forms.Label();
            this.txC39_ts = new System.Windows.Forms.TextBox();
            this.txitem_ts = new System.Windows.Forms.TextBox();
            this.B31 = new System.Windows.Forms.TextBox();
            this.txB27 = new System.Windows.Forms.TextBox();
            this.textBox46 = new System.Windows.Forms.TextBox();
            this.lhrs_msg = new System.Windows.Forms.Label();
            this.textBox45 = new System.Windows.Forms.TextBox();
            this.picalrm = new System.Windows.Forms.PictureBox();
            this.textBox43 = new System.Windows.Forms.TextBox();
            this.lcbval = new System.Windows.Forms.Label();
            this.txC33_ts = new System.Windows.Forms.TextBox();
            this.textBox40 = new System.Windows.Forms.TextBox();
            this.B30 = new System.Windows.Forms.TextBox();
            this.txC38_ts = new System.Windows.Forms.TextBox();
            this.textBox38 = new System.Windows.Forms.TextBox();
            this.textBox41 = new System.Windows.Forms.TextBox();
            this.cbsvcType = new System.Windows.Forms.ComboBox();
            this.txC37_ts = new System.Windows.Forms.TextBox();
            this.B29 = new System.Windows.Forms.Label();
            this.textBox35 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.txB36_ts = new System.Windows.Forms.TextBox();
            this.B32 = new System.Windows.Forms.TextBox();
            this.txC36_ts = new System.Windows.Forms.TextBox();
            this.textBox27 = new System.Windows.Forms.TextBox();
            this.textBox32 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.textBox26 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cof32 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.cof31 = new System.Windows.Forms.Label();
            this.cof30 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.chk_th = new System.Windows.Forms.CheckBox();
            this.textBox29 = new System.Windows.Forms.TextBox();
            this.lfr_dh = new System.Windows.Forms.Label();
            this.leng_dh = new System.Windows.Forms.Label();
            this.txC39_th = new System.Windows.Forms.TextBox();
            this.txitem_th = new System.Windows.Forms.TextBox();
            this.textBox19 = new System.Windows.Forms.TextBox();
            this.txB6 = new System.Windows.Forms.TextBox();
            this.txC38_th = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox18 = new System.Windows.Forms.TextBox();
            this.txB9 = new System.Windows.Forms.TextBox();
            this.txC37_th = new System.Windows.Forms.TextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.textBox22 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.txB36_th = new System.Windows.Forms.TextBox();
            this.txC7 = new System.Windows.Forms.TextBox();
            this.txC36_th = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.textBox28 = new System.Windows.Forms.TextBox();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.txC35_th = new System.Windows.Forms.TextBox();
            this.txB10 = new System.Windows.Forms.TextBox();
            this.textBox30 = new System.Windows.Forms.TextBox();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.txC11 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.txC22 = new System.Windows.Forms.TextBox();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.cbTmtype = new System.Windows.Forms.ComboBox();
            this.cof13 = new System.Windows.Forms.Label();
            this.textBox13 = new System.Windows.Forms.TextBox();
            this.txC13 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txB16 = new System.Windows.Forms.TextBox();
            this.textBox17 = new System.Windows.Forms.TextBox();
            this.textBox16 = new System.Windows.Forms.TextBox();
            this.txB17 = new System.Windows.Forms.TextBox();
            this.textBox14 = new System.Windows.Forms.TextBox();
            this.txC19 = new System.Windows.Forms.TextBox();
            this.txC24_th = new System.Windows.Forms.TextBox();
            this.txB18 = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txB19 = new System.Windows.Forms.TextBox();
            this.textBox15 = new System.Windows.Forms.TextBox();
            this.txB20 = new System.Windows.Forms.TextBox();
            this.textBox23 = new System.Windows.Forms.TextBox();
            this.txB21 = new System.Windows.Forms.TextBox();
            this.textBox21 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.txC16 = new System.Windows.Forms.TextBox();
            this.txC20 = new System.Windows.Forms.TextBox();
            this.txC21 = new System.Windows.Forms.TextBox();
            this.txC18 = new System.Windows.Forms.TextBox();
            this.txC17 = new System.Windows.Forms.TextBox();
            this.cof16 = new System.Windows.Forms.Label();
            this.cof17 = new System.Windows.Forms.Label();
            this.cof18 = new System.Windows.Forms.Label();
            this.cof19 = new System.Windows.Forms.Label();
            this.cof20 = new System.Windows.Forms.Label();
            this.cof21 = new System.Windows.Forms.Label();
            this.cof7 = new System.Windows.Forms.Label();
            this.cof11_a = new System.Windows.Forms.Label();
            this.cof11_b = new System.Windows.Forms.Label();
            this.txC39 = new System.Windows.Forms.TextBox();
            this.txitem = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkAuto = new System.Windows.Forms.CheckBox();
            this.lIotherF = new System.Windows.Forms.TextBox();
            this.tIotherF = new System.Windows.Forms.TextBox();
            this.valFrais = new System.Windows.Forms.TextBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.label10 = new System.Windows.Forms.Label();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.label9 = new System.Windows.Forms.Label();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.lsave = new System.Windows.Forms.Label();
            this.chkM = new System.Windows.Forms.CheckBox();
            this.chkD = new System.Windows.Forms.CheckBox();
            this.tSMRK = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.lif2 = new System.Windows.Forms.TextBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.not = new System.Windows.Forms.Label();
            this.picSeek = new System.Windows.Forms.PictureBox();
            this.lif1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.ll = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.txC35 = new System.Windows.Forms.TextBox();
            this.grpItem.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picalrm)).BeginInit();
            this.panel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).BeginInit();
            this.SuspendLayout();
            // 
            // grpItem
            // 
            this.grpItem.BackColor = System.Drawing.Color.AliceBlue;
            this.grpItem.Controls.Add(this.panel2);
            this.grpItem.Controls.Add(this.panel1);
            this.grpItem.Controls.Add(this.txC39);
            this.grpItem.Controls.Add(this.txitem);
            this.grpItem.Controls.Add(this.groupBox1);
            this.grpItem.Controls.Add(this.btnOK);
            this.grpItem.Controls.Add(this.ll);
            this.grpItem.Controls.Add(this.btnCancel);
            this.grpItem.Controls.Add(this.txC35);
            this.grpItem.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpItem.Location = new System.Drawing.Point(0, 0);
            this.grpItem.Name = "grpItem";
            this.grpItem.Size = new System.Drawing.Size(1347, 674);
            this.grpItem.TabIndex = 125;
            this.grpItem.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.chk_ts);
            this.panel2.Controls.Add(this.textBox31);
            this.panel2.Controls.Add(this.txC35_ts);
            this.panel2.Controls.Add(this.lfr_ts);
            this.panel2.Controls.Add(this.leng_ts);
            this.panel2.Controls.Add(this.txC39_ts);
            this.panel2.Controls.Add(this.txitem_ts);
            this.panel2.Controls.Add(this.B31);
            this.panel2.Controls.Add(this.txB27);
            this.panel2.Controls.Add(this.textBox46);
            this.panel2.Controls.Add(this.lhrs_msg);
            this.panel2.Controls.Add(this.textBox45);
            this.panel2.Controls.Add(this.picalrm);
            this.panel2.Controls.Add(this.textBox43);
            this.panel2.Controls.Add(this.lcbval);
            this.panel2.Controls.Add(this.txC33_ts);
            this.panel2.Controls.Add(this.textBox40);
            this.panel2.Controls.Add(this.B30);
            this.panel2.Controls.Add(this.txC38_ts);
            this.panel2.Controls.Add(this.textBox38);
            this.panel2.Controls.Add(this.textBox41);
            this.panel2.Controls.Add(this.cbsvcType);
            this.panel2.Controls.Add(this.txC37_ts);
            this.panel2.Controls.Add(this.B29);
            this.panel2.Controls.Add(this.textBox35);
            this.panel2.Controls.Add(this.textBox11);
            this.panel2.Controls.Add(this.txB36_ts);
            this.panel2.Controls.Add(this.B32);
            this.panel2.Controls.Add(this.txC36_ts);
            this.panel2.Controls.Add(this.textBox27);
            this.panel2.Controls.Add(this.textBox32);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.textBox26);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.cof32);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.cof31);
            this.panel2.Controls.Add(this.cof30);
            this.panel2.Location = new System.Drawing.Point(857, 14);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(755, 704);
            this.panel2.TabIndex = 541;
            // 
            // chk_ts
            // 
            this.chk_ts.AutoSize = true;
            this.chk_ts.Checked = true;
            this.chk_ts.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_ts.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_ts.Location = new System.Drawing.Point(18, 657);
            this.chk_ts.Name = "chk_ts";
            this.chk_ts.Size = new System.Drawing.Size(18, 17);
            this.chk_ts.TabIndex = 548;
            this.chk_ts.UseVisualStyleBackColor = true;
            // 
            // textBox31
            // 
            this.textBox31.BackColor = System.Drawing.Color.Lavender;
            this.textBox31.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox31.ForeColor = System.Drawing.Color.Black;
            this.textBox31.Location = new System.Drawing.Point(-1, 0);
            this.textBox31.MaxLength = 49;
            this.textBox31.Multiline = true;
            this.textBox31.Name = "textBox31";
            this.textBox31.Size = new System.Drawing.Size(836, 31);
            this.textBox31.TabIndex = 547;
            this.textBox31.Text = "TRAVAIL SUR SITE (ESTIMÉ)";
            this.textBox31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // txC35_ts
            // 
            this.txC35_ts.BackColor = System.Drawing.Color.PaleGreen;
            this.txC35_ts.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.txC35_ts.ForeColor = System.Drawing.Color.Black;
            this.txC35_ts.Location = new System.Drawing.Point(554, 487);
            this.txC35_ts.MaxLength = 49;
            this.txC35_ts.Name = "txC35_ts";
            this.txC35_ts.ReadOnly = true;
            this.txC35_ts.Size = new System.Drawing.Size(195, 32);
            this.txC35_ts.TabIndex = 546;
            this.txC35_ts.Text = "0";
            this.txC35_ts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lfr_ts
            // 
            this.lfr_ts.BackColor = System.Drawing.Color.Peru;
            this.lfr_ts.Location = new System.Drawing.Point(40, 413);
            this.lfr_ts.Name = "lfr_ts";
            this.lfr_ts.Size = new System.Drawing.Size(514, 27);
            this.lfr_ts.TabIndex = 545;
            this.lfr_ts.Text = "TRAVAIL SUR SITE (ESTIMÉ)";
            this.lfr_ts.Visible = false;
            // 
            // leng_ts
            // 
            this.leng_ts.BackColor = System.Drawing.Color.Peru;
            this.leng_ts.Location = new System.Drawing.Point(86, 378);
            this.leng_ts.Name = "leng_ts";
            this.leng_ts.Size = new System.Drawing.Size(327, 27);
            this.leng_ts.TabIndex = 544;
            this.leng_ts.Text = "On-Site Work (ESTIMATE)";
            this.leng_ts.Visible = false;
            // 
            // txC39_ts
            // 
            this.txC39_ts.BackColor = System.Drawing.Color.PaleGreen;
            this.txC39_ts.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC39_ts.ForeColor = System.Drawing.Color.Black;
            this.txC39_ts.Location = new System.Drawing.Point(554, 650);
            this.txC39_ts.MaxLength = 49;
            this.txC39_ts.Name = "txC39_ts";
            this.txC39_ts.ReadOnly = true;
            this.txC39_ts.Size = new System.Drawing.Size(195, 32);
            this.txC39_ts.TabIndex = 543;
            this.txC39_ts.Text = "0";
            this.txC39_ts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txitem_ts
            // 
            this.txitem_ts.BackColor = System.Drawing.Color.Salmon;
            this.txitem_ts.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txitem_ts.ForeColor = System.Drawing.Color.Black;
            this.txitem_ts.Location = new System.Drawing.Point(43, 650);
            this.txitem_ts.MaxLength = 49;
            this.txitem_ts.Multiline = true;
            this.txitem_ts.Name = "txitem_ts";
            this.txitem_ts.ReadOnly = true;
            this.txitem_ts.Size = new System.Drawing.Size(511, 31);
            this.txitem_ts.TabIndex = 542;
            this.txitem_ts.Text = "FRAIS DE DÉPLACEMENTS ET D\'HÉBERGEMENT (ESTIMATE)";
            this.txitem_ts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // B31
            // 
            this.B31.BackColor = System.Drawing.Color.White;
            this.B31.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B31.ForeColor = System.Drawing.Color.Black;
            this.B31.Location = new System.Drawing.Point(409, 233);
            this.B31.MaxLength = 49;
            this.B31.Name = "B31";
            this.B31.Size = new System.Drawing.Size(108, 27);
            this.B31.TabIndex = 495;
            this.B31.Text = "0";
            this.B31.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.B31.TextChanged += new System.EventHandler(this.B31_TextChanged);
            this.B31.Leave += new System.EventHandler(this.B31_Leave);
            // 
            // txB27
            // 
            this.txB27.BackColor = System.Drawing.Color.White;
            this.txB27.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txB27.ForeColor = System.Drawing.Color.Black;
            this.txB27.Location = new System.Drawing.Point(413, 99);
            this.txB27.MaxLength = 49;
            this.txB27.Name = "txB27";
            this.txB27.Size = new System.Drawing.Size(108, 27);
            this.txB27.TabIndex = 471;
            this.txB27.Text = "0";
            this.txB27.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txB27.TextChanged += new System.EventHandler(this.txB27_TextChanged);
            // 
            // textBox46
            // 
            this.textBox46.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox46.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox46.ForeColor = System.Drawing.Color.Black;
            this.textBox46.Location = new System.Drawing.Point(6, 99);
            this.textBox46.MaxLength = 49;
            this.textBox46.Multiline = true;
            this.textBox46.Name = "textBox46";
            this.textBox46.ReadOnly = true;
            this.textBox46.Size = new System.Drawing.Size(407, 27);
            this.textBox46.TabIndex = 470;
            this.textBox46.Text = "Nombre d\'unités";
            this.textBox46.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lhrs_msg
            // 
            this.lhrs_msg.BackColor = System.Drawing.Color.AliceBlue;
            this.lhrs_msg.ForeColor = System.Drawing.Color.Red;
            this.lhrs_msg.Location = new System.Drawing.Point(425, 306);
            this.lhrs_msg.Name = "lhrs_msg";
            this.lhrs_msg.Size = new System.Drawing.Size(302, 26);
            this.lhrs_msg.TabIndex = 529;
            this.lhrs_msg.Text = "ddddddddddddddddddd";
            this.lhrs_msg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lhrs_msg.Visible = false;
            // 
            // textBox45
            // 
            this.textBox45.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox45.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox45.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox45.ForeColor = System.Drawing.Color.Black;
            this.textBox45.Location = new System.Drawing.Point(6, 70);
            this.textBox45.MaxLength = 49;
            this.textBox45.Multiline = true;
            this.textBox45.Name = "textBox45";
            this.textBox45.ReadOnly = true;
            this.textBox45.Size = new System.Drawing.Size(330, 27);
            this.textBox45.TabIndex = 472;
            this.textBox45.Text = "TRAVAIL SUR SITE ";
            // 
            // picalrm
            // 
            this.picalrm.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picalrm.Image = ((System.Drawing.Image)(resources.GetObject("picalrm.Image")));
            this.picalrm.Location = new System.Drawing.Point(360, 300);
            this.picalrm.Name = "picalrm";
            this.picalrm.Size = new System.Drawing.Size(58, 35);
            this.picalrm.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picalrm.TabIndex = 528;
            this.picalrm.TabStop = false;
            this.picalrm.Visible = false;
            // 
            // textBox43
            // 
            this.textBox43.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox43.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox43.ForeColor = System.Drawing.Color.Black;
            this.textBox43.Location = new System.Drawing.Point(6, 133);
            this.textBox43.MaxLength = 49;
            this.textBox43.Multiline = true;
            this.textBox43.Name = "textBox43";
            this.textBox43.ReadOnly = true;
            this.textBox43.Size = new System.Drawing.Size(407, 26);
            this.textBox43.TabIndex = 473;
            this.textBox43.Text = "Type de service";
            this.textBox43.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // lcbval
            // 
            this.lcbval.BackColor = System.Drawing.Color.Coral;
            this.lcbval.Location = new System.Drawing.Point(684, 132);
            this.lcbval.Name = "lcbval";
            this.lcbval.Size = new System.Drawing.Size(43, 26);
            this.lcbval.TabIndex = 527;
            this.lcbval.Text = "0";
            this.lcbval.Visible = false;
            // 
            // txC33_ts
            // 
            this.txC33_ts.BackColor = System.Drawing.Color.PaleGreen;
            this.txC33_ts.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC33_ts.ForeColor = System.Drawing.Color.Black;
            this.txC33_ts.Location = new System.Drawing.Point(336, 70);
            this.txC33_ts.MaxLength = 49;
            this.txC33_ts.Multiline = true;
            this.txC33_ts.Name = "txC33_ts";
            this.txC33_ts.ReadOnly = true;
            this.txC33_ts.Size = new System.Drawing.Size(185, 27);
            this.txC33_ts.TabIndex = 475;
            this.txC33_ts.Text = "0";
            this.txC33_ts.Visible = false;
            this.txC33_ts.TextChanged += new System.EventHandler(this.txC33_ts_TextChanged);
            // 
            // textBox40
            // 
            this.textBox40.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox40.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox40.ForeColor = System.Drawing.Color.Black;
            this.textBox40.Location = new System.Drawing.Point(6, 166);
            this.textBox40.MaxLength = 49;
            this.textBox40.Multiline = true;
            this.textBox40.Name = "textBox40";
            this.textBox40.ReadOnly = true;
            this.textBox40.Size = new System.Drawing.Size(407, 27);
            this.textBox40.TabIndex = 476;
            this.textBox40.Text = "Temps minimum à facturer";
            this.textBox40.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // B30
            // 
            this.B30.BackColor = System.Drawing.Color.White;
            this.B30.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B30.ForeColor = System.Drawing.Color.Black;
            this.B30.Location = new System.Drawing.Point(409, 200);
            this.B30.MaxLength = 49;
            this.B30.Name = "B30";
            this.B30.Size = new System.Drawing.Size(108, 27);
            this.B30.TabIndex = 479;
            this.B30.Text = "0";
            this.B30.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.B30.TextChanged += new System.EventHandler(this.B30_TextChanged);
            this.B30.Leave += new System.EventHandler(this.B30_Leave);
            // 
            // txC38_ts
            // 
            this.txC38_ts.BackColor = System.Drawing.Color.PaleGreen;
            this.txC38_ts.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC38_ts.ForeColor = System.Drawing.Color.Black;
            this.txC38_ts.Location = new System.Drawing.Point(554, 587);
            this.txC38_ts.MaxLength = 49;
            this.txC38_ts.Name = "txC38_ts";
            this.txC38_ts.ReadOnly = true;
            this.txC38_ts.Size = new System.Drawing.Size(195, 27);
            this.txC38_ts.TabIndex = 520;
            this.txC38_ts.Text = "0";
            this.txC38_ts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txC38_ts.TextChanged += new System.EventHandler(this.txC38_TextChanged);
            // 
            // textBox38
            // 
            this.textBox38.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox38.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox38.ForeColor = System.Drawing.Color.Black;
            this.textBox38.Location = new System.Drawing.Point(6, 200);
            this.textBox38.MaxLength = 49;
            this.textBox38.Multiline = true;
            this.textBox38.Name = "textBox38";
            this.textBox38.ReadOnly = true;
            this.textBox38.Size = new System.Drawing.Size(407, 26);
            this.textBox38.TabIndex = 478;
            this.textBox38.Text = "Lundi à Vendredi - 8am-5pm (heures)";
            this.textBox38.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox41
            // 
            this.textBox41.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox41.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox41.ForeColor = System.Drawing.Color.Black;
            this.textBox41.Location = new System.Drawing.Point(217, 587);
            this.textBox41.MaxLength = 49;
            this.textBox41.Multiline = true;
            this.textBox41.Name = "textBox41";
            this.textBox41.ReadOnly = true;
            this.textBox41.Size = new System.Drawing.Size(337, 27);
            this.textBox41.TabIndex = 519;
            this.textBox41.Text = "TVQ";
            this.textBox41.TextChanged += new System.EventHandler(this.textBox41_TextChanged);
            // 
            // cbsvcType
            // 
            this.cbsvcType.BackColor = System.Drawing.Color.MistyRose;
            this.cbsvcType.DropDownHeight = 120;
            this.cbsvcType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbsvcType.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbsvcType.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbsvcType.ForeColor = System.Drawing.Color.Black;
            this.cbsvcType.IntegralHeight = false;
            this.cbsvcType.ItemHeight = 17;
            this.cbsvcType.Location = new System.Drawing.Point(413, 134);
            this.cbsvcType.Name = "cbsvcType";
            this.cbsvcType.Size = new System.Drawing.Size(260, 25);
            this.cbsvcType.TabIndex = 492;
            this.cbsvcType.SelectedIndexChanged += new System.EventHandler(this.cbsvcType_SelectedIndexChanged);
            // 
            // txC37_ts
            // 
            this.txC37_ts.BackColor = System.Drawing.Color.PaleGreen;
            this.txC37_ts.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC37_ts.ForeColor = System.Drawing.Color.Black;
            this.txC37_ts.Location = new System.Drawing.Point(554, 554);
            this.txC37_ts.MaxLength = 49;
            this.txC37_ts.Name = "txC37_ts";
            this.txC37_ts.ReadOnly = true;
            this.txC37_ts.Size = new System.Drawing.Size(195, 27);
            this.txC37_ts.TabIndex = 517;
            this.txC37_ts.Text = "0";
            this.txC37_ts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txC37_ts.TextChanged += new System.EventHandler(this.txC37_TextChanged);
            // 
            // B29
            // 
            this.B29.BackColor = System.Drawing.Color.Gold;
            this.B29.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B29.ForeColor = System.Drawing.Color.Black;
            this.B29.Location = new System.Drawing.Point(413, 166);
            this.B29.Name = "B29";
            this.B29.Size = new System.Drawing.Size(146, 27);
            this.B29.TabIndex = 493;
            this.B29.Text = "8";
            this.B29.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox35
            // 
            this.textBox35.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox35.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox35.ForeColor = System.Drawing.Color.Black;
            this.textBox35.Location = new System.Drawing.Point(217, 554);
            this.textBox35.MaxLength = 49;
            this.textBox35.Multiline = true;
            this.textBox35.Name = "textBox35";
            this.textBox35.ReadOnly = true;
            this.textBox35.Size = new System.Drawing.Size(337, 26);
            this.textBox35.TabIndex = 516;
            this.textBox35.Text = "TPS";
            this.textBox35.TextChanged += new System.EventHandler(this.textBox35_TextChanged);
            // 
            // textBox11
            // 
            this.textBox11.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox11.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox11.ForeColor = System.Drawing.Color.Black;
            this.textBox11.Location = new System.Drawing.Point(6, 233);
            this.textBox11.MaxLength = 49;
            this.textBox11.Multiline = true;
            this.textBox11.Name = "textBox11";
            this.textBox11.ReadOnly = true;
            this.textBox11.Size = new System.Drawing.Size(407, 27);
            this.textBox11.TabIndex = 494;
            this.textBox11.Text = "Lundi à Vendredi - 5pm-8am (heures)";
            this.textBox11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txB36_ts
            // 
            this.txB36_ts.BackColor = System.Drawing.Color.White;
            this.txB36_ts.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txB36_ts.ForeColor = System.Drawing.Color.Red;
            this.txB36_ts.Location = new System.Drawing.Point(468, 518);
            this.txB36_ts.MaxLength = 3;
            this.txB36_ts.Name = "txB36_ts";
            this.txB36_ts.Size = new System.Drawing.Size(86, 32);
            this.txB36_ts.TabIndex = 515;
            this.txB36_ts.Text = "0";
            this.txB36_ts.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txB36_ts.TextChanged += new System.EventHandler(this.txB36_ts_TextChanged);
            // 
            // B32
            // 
            this.B32.BackColor = System.Drawing.Color.White;
            this.B32.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.B32.ForeColor = System.Drawing.Color.Black;
            this.B32.Location = new System.Drawing.Point(409, 267);
            this.B32.MaxLength = 49;
            this.B32.Name = "B32";
            this.B32.Size = new System.Drawing.Size(108, 27);
            this.B32.TabIndex = 497;
            this.B32.Text = "0";
            this.B32.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.B32.TextChanged += new System.EventHandler(this.B32_TextChanged);
            this.B32.Leave += new System.EventHandler(this.B32_Leave);
            // 
            // txC36_ts
            // 
            this.txC36_ts.BackColor = System.Drawing.Color.PaleGreen;
            this.txC36_ts.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC36_ts.ForeColor = System.Drawing.Color.Black;
            this.txC36_ts.Location = new System.Drawing.Point(554, 520);
            this.txC36_ts.MaxLength = 49;
            this.txC36_ts.Name = "txC36_ts";
            this.txC36_ts.ReadOnly = true;
            this.txC36_ts.Size = new System.Drawing.Size(195, 27);
            this.txC36_ts.TabIndex = 514;
            this.txC36_ts.Text = "0";
            this.txC36_ts.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txC36_ts.TextChanged += new System.EventHandler(this.txC36_TextChanged);
            // 
            // textBox27
            // 
            this.textBox27.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox27.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox27.ForeColor = System.Drawing.Color.Black;
            this.textBox27.Location = new System.Drawing.Point(6, 267);
            this.textBox27.MaxLength = 49;
            this.textBox27.Multiline = true;
            this.textBox27.Name = "textBox27";
            this.textBox27.ReadOnly = true;
            this.textBox27.Size = new System.Drawing.Size(407, 26);
            this.textBox27.TabIndex = 496;
            this.textBox27.Text = "Samedi, dimanche et jour férié (heures)";
            this.textBox27.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox32
            // 
            this.textBox32.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox32.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox32.ForeColor = System.Drawing.Color.Black;
            this.textBox32.Location = new System.Drawing.Point(217, 520);
            this.textBox32.MaxLength = 49;
            this.textBox32.Multiline = true;
            this.textBox32.Name = "textBox32";
            this.textBox32.ReadOnly = true;
            this.textBox32.Size = new System.Drawing.Size(251, 27);
            this.textBox32.TabIndex = 513;
            this.textBox32.Text = "Moins: Rabais (%)";
            this.textBox32.TextChanged += new System.EventHandler(this.textBox32_TextChanged);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.AliceBlue;
            this.label6.ForeColor = System.Drawing.Color.Brown;
            this.label6.Location = new System.Drawing.Point(559, 166);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(84, 27);
            this.label6.TabIndex = 498;
            this.label6.Text = "Heures Min.";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.AliceBlue;
            this.label7.ForeColor = System.Drawing.Color.Brown;
            this.label7.Location = new System.Drawing.Point(517, 200);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(37, 26);
            this.label7.TabIndex = 499;
            this.label7.Text = "Hrs";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox26
            // 
            this.textBox26.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox26.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox26.ForeColor = System.Drawing.Color.Black;
            this.textBox26.Location = new System.Drawing.Point(217, 489);
            this.textBox26.MaxLength = 49;
            this.textBox26.Multiline = true;
            this.textBox26.Name = "textBox26";
            this.textBox26.ReadOnly = true;
            this.textBox26.Size = new System.Drawing.Size(337, 27);
            this.textBox26.TabIndex = 510;
            this.textBox26.Text = "TOTAL";
            this.textBox26.TextChanged += new System.EventHandler(this.textBox26_TextChanged);
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.Color.AliceBlue;
            this.label8.ForeColor = System.Drawing.Color.Brown;
            this.label8.Location = new System.Drawing.Point(517, 233);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(37, 27);
            this.label8.TabIndex = 500;
            this.label8.Text = "Hrs";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cof32
            // 
            this.cof32.BackColor = System.Drawing.Color.Peru;
            this.cof32.Location = new System.Drawing.Point(650, 75);
            this.cof32.Name = "cof32";
            this.cof32.Size = new System.Drawing.Size(44, 27);
            this.cof32.TabIndex = 507;
            this.cof32.Text = "280";
            this.cof32.Visible = false;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.Color.AliceBlue;
            this.label11.ForeColor = System.Drawing.Color.Brown;
            this.label11.Location = new System.Drawing.Point(517, 267);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(37, 26);
            this.label11.TabIndex = 501;
            this.label11.Text = "Hrs";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cof31
            // 
            this.cof31.BackColor = System.Drawing.Color.Peru;
            this.cof31.Location = new System.Drawing.Point(701, 171);
            this.cof31.Name = "cof31";
            this.cof31.Size = new System.Drawing.Size(43, 26);
            this.cof31.TabIndex = 506;
            this.cof31.Text = "200";
            this.cof31.Visible = false;
            // 
            // cof30
            // 
            this.cof30.BackColor = System.Drawing.Color.Peru;
            this.cof30.Location = new System.Drawing.Point(650, 172);
            this.cof30.Name = "cof30";
            this.cof30.Size = new System.Drawing.Size(44, 26);
            this.cof30.TabIndex = 505;
            this.cof30.Text = "165";
            this.cof30.Visible = false;
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.chk_th);
            this.panel1.Controls.Add(this.textBox29);
            this.panel1.Controls.Add(this.lfr_dh);
            this.panel1.Controls.Add(this.leng_dh);
            this.panel1.Controls.Add(this.txC39_th);
            this.panel1.Controls.Add(this.txitem_th);
            this.panel1.Controls.Add(this.textBox19);
            this.panel1.Controls.Add(this.txB6);
            this.panel1.Controls.Add(this.txC38_th);
            this.panel1.Controls.Add(this.textBox2);
            this.panel1.Controls.Add(this.textBox18);
            this.panel1.Controls.Add(this.txB9);
            this.panel1.Controls.Add(this.txC37_th);
            this.panel1.Controls.Add(this.textBox1);
            this.panel1.Controls.Add(this.label14);
            this.panel1.Controls.Add(this.textBox22);
            this.panel1.Controls.Add(this.textBox7);
            this.panel1.Controls.Add(this.txB36_th);
            this.panel1.Controls.Add(this.txC7);
            this.panel1.Controls.Add(this.txC36_th);
            this.panel1.Controls.Add(this.textBox4);
            this.panel1.Controls.Add(this.textBox28);
            this.panel1.Controls.Add(this.textBox6);
            this.panel1.Controls.Add(this.txC35_th);
            this.panel1.Controls.Add(this.txB10);
            this.panel1.Controls.Add(this.textBox30);
            this.panel1.Controls.Add(this.textBox9);
            this.panel1.Controls.Add(this.textBox8);
            this.panel1.Controls.Add(this.txC11);
            this.panel1.Controls.Add(this.textBox3);
            this.panel1.Controls.Add(this.txC22);
            this.panel1.Controls.Add(this.textBox5);
            this.panel1.Controls.Add(this.textBox10);
            this.panel1.Controls.Add(this.cbTmtype);
            this.panel1.Controls.Add(this.cof13);
            this.panel1.Controls.Add(this.textBox13);
            this.panel1.Controls.Add(this.txC13);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txB16);
            this.panel1.Controls.Add(this.textBox17);
            this.panel1.Controls.Add(this.textBox16);
            this.panel1.Controls.Add(this.txB17);
            this.panel1.Controls.Add(this.textBox14);
            this.panel1.Controls.Add(this.txC19);
            this.panel1.Controls.Add(this.txC24_th);
            this.panel1.Controls.Add(this.txB18);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.txB19);
            this.panel1.Controls.Add(this.textBox15);
            this.panel1.Controls.Add(this.txB20);
            this.panel1.Controls.Add(this.textBox23);
            this.panel1.Controls.Add(this.txB21);
            this.panel1.Controls.Add(this.textBox21);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.txC16);
            this.panel1.Controls.Add(this.txC20);
            this.panel1.Controls.Add(this.txC21);
            this.panel1.Controls.Add(this.txC18);
            this.panel1.Controls.Add(this.txC17);
            this.panel1.Controls.Add(this.cof16);
            this.panel1.Controls.Add(this.cof17);
            this.panel1.Controls.Add(this.cof18);
            this.panel1.Controls.Add(this.cof19);
            this.panel1.Controls.Add(this.cof20);
            this.panel1.Controls.Add(this.cof21);
            this.panel1.Controls.Add(this.cof7);
            this.panel1.Controls.Add(this.cof11_a);
            this.panel1.Controls.Add(this.cof11_b);
            this.panel1.Location = new System.Drawing.Point(7, 14);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(841, 709);
            this.panel1.TabIndex = 540;
            // 
            // chk_th
            // 
            this.chk_th.AutoSize = true;
            this.chk_th.Checked = true;
            this.chk_th.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk_th.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_th.Location = new System.Drawing.Point(101, 658);
            this.chk_th.Name = "chk_th";
            this.chk_th.Size = new System.Drawing.Size(18, 17);
            this.chk_th.TabIndex = 549;
            this.chk_th.UseVisualStyleBackColor = true;
            // 
            // textBox29
            // 
            this.textBox29.BackColor = System.Drawing.Color.Lavender;
            this.textBox29.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox29.ForeColor = System.Drawing.Color.Black;
            this.textBox29.Location = new System.Drawing.Point(-1, -1);
            this.textBox29.MaxLength = 49;
            this.textBox29.Multiline = true;
            this.textBox29.Name = "textBox29";
            this.textBox29.Size = new System.Drawing.Size(841, 31);
            this.textBox29.TabIndex = 544;
            this.textBox29.Text = "FRAIS DE DÉPLACEMENTS ET D\'HÉBERGEMENT (ESTIMÉ)";
            this.textBox29.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // lfr_dh
            // 
            this.lfr_dh.BackColor = System.Drawing.Color.Peru;
            this.lfr_dh.Location = new System.Drawing.Point(11, 487);
            this.lfr_dh.Name = "lfr_dh";
            this.lfr_dh.Size = new System.Drawing.Size(229, 26);
            this.lfr_dh.TabIndex = 543;
            this.lfr_dh.Text = "FRAIS DE DÉPLACEMENTS ET D\'HÉBERGEMENT (ESTIMÉ)";
            this.lfr_dh.Visible = false;
            // 
            // leng_dh
            // 
            this.leng_dh.BackColor = System.Drawing.Color.Peru;
            this.leng_dh.Location = new System.Drawing.Point(11, 523);
            this.leng_dh.Name = "leng_dh";
            this.leng_dh.Size = new System.Drawing.Size(276, 26);
            this.leng_dh.TabIndex = 542;
            this.leng_dh.Text = "Travel and Accomodation (ESTIMATE)";
            this.leng_dh.Visible = false;
            // 
            // txC39_th
            // 
            this.txC39_th.BackColor = System.Drawing.Color.PaleGreen;
            this.txC39_th.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC39_th.ForeColor = System.Drawing.Color.Black;
            this.txC39_th.Location = new System.Drawing.Point(637, 648);
            this.txC39_th.MaxLength = 49;
            this.txC39_th.Name = "txC39_th";
            this.txC39_th.ReadOnly = true;
            this.txC39_th.Size = new System.Drawing.Size(195, 32);
            this.txC39_th.TabIndex = 541;
            this.txC39_th.Text = "0";
            this.txC39_th.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txitem_th
            // 
            this.txitem_th.BackColor = System.Drawing.Color.Salmon;
            this.txitem_th.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txitem_th.ForeColor = System.Drawing.Color.Black;
            this.txitem_th.Location = new System.Drawing.Point(126, 648);
            this.txitem_th.MaxLength = 49;
            this.txitem_th.Multiline = true;
            this.txitem_th.Name = "txitem_th";
            this.txitem_th.ReadOnly = true;
            this.txitem_th.Size = new System.Drawing.Size(511, 32);
            this.txitem_th.TabIndex = 540;
            this.txitem_th.Text = "FRAIS DE DÉPLACEMENTS ET D\'HÉBERGEMENT (ESTIMATE)";
            this.txitem_th.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox19
            // 
            this.textBox19.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox19.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox19.ForeColor = System.Drawing.Color.Black;
            this.textBox19.Location = new System.Drawing.Point(11, 340);
            this.textBox19.MaxLength = 49;
            this.textBox19.Multiline = true;
            this.textBox19.Name = "textBox19";
            this.textBox19.ReadOnly = true;
            this.textBox19.Size = new System.Drawing.Size(343, 27);
            this.textBox19.TabIndex = 439;
            this.textBox19.Text = "Location auto";
            this.textBox19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txB6
            // 
            this.txB6.BackColor = System.Drawing.Color.White;
            this.txB6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txB6.ForeColor = System.Drawing.Color.Black;
            this.txB6.Location = new System.Drawing.Point(354, 87);
            this.txB6.MaxLength = 49;
            this.txB6.Name = "txB6";
            this.txB6.Size = new System.Drawing.Size(108, 27);
            this.txB6.TabIndex = 372;
            this.txB6.Text = "0";
            this.txB6.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txB6.TextChanged += new System.EventHandler(this.txB6_TextChanged);
            // 
            // txC38_th
            // 
            this.txC38_th.BackColor = System.Drawing.Color.PaleGreen;
            this.txC38_th.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC38_th.ForeColor = System.Drawing.Color.Black;
            this.txC38_th.Location = new System.Drawing.Point(637, 587);
            this.txC38_th.MaxLength = 49;
            this.txC38_th.Name = "txC38_th";
            this.txC38_th.ReadOnly = true;
            this.txC38_th.Size = new System.Drawing.Size(195, 27);
            this.txC38_th.TabIndex = 538;
            this.txC38_th.Text = "0";
            this.txC38_th.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox2.ForeColor = System.Drawing.Color.Black;
            this.textBox2.Location = new System.Drawing.Point(11, 87);
            this.textBox2.MaxLength = 49;
            this.textBox2.Multiline = true;
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(343, 26);
            this.textBox2.TabIndex = 370;
            this.textBox2.Text = "Distance Google (65 Hymus à destination)";
            this.textBox2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox18
            // 
            this.textBox18.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox18.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox18.ForeColor = System.Drawing.Color.Black;
            this.textBox18.Location = new System.Drawing.Point(294, 587);
            this.textBox18.MaxLength = 49;
            this.textBox18.Multiline = true;
            this.textBox18.Name = "textBox18";
            this.textBox18.ReadOnly = true;
            this.textBox18.Size = new System.Drawing.Size(343, 27);
            this.textBox18.TabIndex = 537;
            this.textBox18.Text = "TVQ";
            // 
            // txB9
            // 
            this.txB9.BackColor = System.Drawing.Color.White;
            this.txB9.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txB9.ForeColor = System.Drawing.Color.Black;
            this.txB9.Location = new System.Drawing.Point(354, 145);
            this.txB9.MaxLength = 49;
            this.txB9.Name = "txB9";
            this.txB9.Size = new System.Drawing.Size(108, 27);
            this.txB9.TabIndex = 415;
            this.txB9.Text = "1";
            this.txB9.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txB9.TextChanged += new System.EventHandler(this.txB9_TextChanged);
            // 
            // txC37_th
            // 
            this.txC37_th.BackColor = System.Drawing.Color.PaleGreen;
            this.txC37_th.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC37_th.ForeColor = System.Drawing.Color.Black;
            this.txC37_th.Location = new System.Drawing.Point(637, 554);
            this.txC37_th.MaxLength = 49;
            this.txC37_th.Name = "txC37_th";
            this.txC37_th.ReadOnly = true;
            this.txC37_th.Size = new System.Drawing.Size(195, 27);
            this.txC37_th.TabIndex = 536;
            this.txC37_th.Text = "0";
            this.txC37_th.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(11, 145);
            this.textBox1.MaxLength = 49;
            this.textBox1.Multiline = true;
            this.textBox1.Name = "textBox1";
            this.textBox1.ReadOnly = true;
            this.textBox1.Size = new System.Drawing.Size(343, 27);
            this.textBox1.TabIndex = 414;
            this.textBox1.Text = "Nombre de personnel";
            this.textBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.AliceBlue;
            this.label14.ForeColor = System.Drawing.Color.Brown;
            this.label14.Location = new System.Drawing.Point(462, 377);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(34, 27);
            this.label14.TabIndex = 509;
            this.label14.Text = "Jr";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // textBox22
            // 
            this.textBox22.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox22.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox22.ForeColor = System.Drawing.Color.Black;
            this.textBox22.Location = new System.Drawing.Point(293, 554);
            this.textBox22.MaxLength = 49;
            this.textBox22.Multiline = true;
            this.textBox22.Name = "textBox22";
            this.textBox22.ReadOnly = true;
            this.textBox22.Size = new System.Drawing.Size(344, 26);
            this.textBox22.TabIndex = 535;
            this.textBox22.Text = "TPS";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox7.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox7.ForeColor = System.Drawing.Color.Black;
            this.textBox7.Location = new System.Drawing.Point(496, 87);
            this.textBox7.MaxLength = 49;
            this.textBox7.Multiline = true;
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(175, 26);
            this.textBox7.TabIndex = 416;
            this.textBox7.Text = "Frais de kilométrage";
            this.textBox7.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txB36_th
            // 
            this.txB36_th.BackColor = System.Drawing.Color.White;
            this.txB36_th.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txB36_th.ForeColor = System.Drawing.Color.Red;
            this.txB36_th.Location = new System.Drawing.Point(551, 518);
            this.txB36_th.MaxLength = 3;
            this.txB36_th.Name = "txB36_th";
            this.txB36_th.Size = new System.Drawing.Size(86, 32);
            this.txB36_th.TabIndex = 534;
            this.txB36_th.Text = "0";
            this.txB36_th.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txB36_th.TextChanged += new System.EventHandler(this.txB36_th_TextChanged);
            // 
            // txC7
            // 
            this.txC7.BackColor = System.Drawing.Color.PaleGreen;
            this.txC7.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC7.ForeColor = System.Drawing.Color.Black;
            this.txC7.Location = new System.Drawing.Point(671, 87);
            this.txC7.MaxLength = 49;
            this.txC7.Name = "txC7";
            this.txC7.ReadOnly = true;
            this.txC7.Size = new System.Drawing.Size(120, 27);
            this.txC7.TabIndex = 417;
            this.txC7.Text = "0";
            this.txC7.TextChanged += new System.EventHandler(this.txC7_TextChanged);
            // 
            // txC36_th
            // 
            this.txC36_th.BackColor = System.Drawing.Color.PaleGreen;
            this.txC36_th.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC36_th.ForeColor = System.Drawing.Color.Black;
            this.txC36_th.Location = new System.Drawing.Point(637, 520);
            this.txC36_th.MaxLength = 49;
            this.txC36_th.Name = "txC36_th";
            this.txC36_th.ReadOnly = true;
            this.txC36_th.Size = new System.Drawing.Size(195, 27);
            this.txC36_th.TabIndex = 533;
            this.txC36_th.Text = "0";
            this.txC36_th.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox4
            // 
            this.textBox4.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox4.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox4.ForeColor = System.Drawing.Color.Black;
            this.textBox4.Location = new System.Drawing.Point(11, 119);
            this.textBox4.MaxLength = 49;
            this.textBox4.Multiline = true;
            this.textBox4.Name = "textBox4";
            this.textBox4.ReadOnly = true;
            this.textBox4.Size = new System.Drawing.Size(283, 19);
            this.textBox4.TabIndex = 418;
            this.textBox4.Text = "PERSONNEL DE SERVICE: ";
            // 
            // textBox28
            // 
            this.textBox28.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox28.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox28.ForeColor = System.Drawing.Color.Black;
            this.textBox28.Location = new System.Drawing.Point(294, 520);
            this.textBox28.MaxLength = 49;
            this.textBox28.Multiline = true;
            this.textBox28.Name = "textBox28";
            this.textBox28.ReadOnly = true;
            this.textBox28.Size = new System.Drawing.Size(257, 27);
            this.textBox28.TabIndex = 532;
            this.textBox28.Text = "Moins: Rabais (%)";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox6.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox6.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox6.ForeColor = System.Drawing.Color.Black;
            this.textBox6.Location = new System.Drawing.Point(11, 60);
            this.textBox6.MaxLength = 49;
            this.textBox6.Multiline = true;
            this.textBox6.Name = "textBox6";
            this.textBox6.ReadOnly = true;
            this.textBox6.Size = new System.Drawing.Size(128, 20);
            this.textBox6.TabIndex = 419;
            this.textBox6.Text = "VÉHICULE: ";
            // 
            // txC35_th
            // 
            this.txC35_th.BackColor = System.Drawing.Color.PaleGreen;
            this.txC35_th.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.txC35_th.ForeColor = System.Drawing.Color.Black;
            this.txC35_th.Location = new System.Drawing.Point(637, 487);
            this.txC35_th.MaxLength = 49;
            this.txC35_th.Name = "txC35_th";
            this.txC35_th.ReadOnly = true;
            this.txC35_th.Size = new System.Drawing.Size(195, 32);
            this.txC35_th.TabIndex = 531;
            this.txC35_th.Text = "0";
            this.txC35_th.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txB10
            // 
            this.txB10.BackColor = System.Drawing.Color.White;
            this.txB10.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txB10.ForeColor = System.Drawing.Color.Black;
            this.txB10.Location = new System.Drawing.Point(354, 179);
            this.txB10.MaxLength = 49;
            this.txB10.Name = "txB10";
            this.txB10.Size = new System.Drawing.Size(108, 27);
            this.txB10.TabIndex = 421;
            this.txB10.Text = "0";
            this.txB10.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txB10.TextChanged += new System.EventHandler(this.txB10_TextChanged);
            // 
            // textBox30
            // 
            this.textBox30.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox30.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox30.ForeColor = System.Drawing.Color.Black;
            this.textBox30.Location = new System.Drawing.Point(294, 489);
            this.textBox30.MaxLength = 49;
            this.textBox30.Multiline = true;
            this.textBox30.Name = "textBox30";
            this.textBox30.ReadOnly = true;
            this.textBox30.Size = new System.Drawing.Size(343, 27);
            this.textBox30.TabIndex = 530;
            this.textBox30.Text = "TOTAL";
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox9.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox9.ForeColor = System.Drawing.Color.Black;
            this.textBox9.Location = new System.Drawing.Point(11, 179);
            this.textBox9.MaxLength = 49;
            this.textBox9.Multiline = true;
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(343, 26);
            this.textBox9.TabIndex = 420;
            this.textBox9.Text = "Temps Google (Hymus à destination)";
            this.textBox9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox8.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox8.ForeColor = System.Drawing.Color.Black;
            this.textBox8.Location = new System.Drawing.Point(496, 179);
            this.textBox8.MaxLength = 49;
            this.textBox8.Multiline = true;
            this.textBox8.Name = "textBox8";
            this.textBox8.ReadOnly = true;
            this.textBox8.Size = new System.Drawing.Size(226, 26);
            this.textBox8.TabIndex = 422;
            this.textBox8.Text = "Temps chargé déplacement";
            this.textBox8.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txC11
            // 
            this.txC11.BackColor = System.Drawing.Color.PaleGreen;
            this.txC11.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC11.ForeColor = System.Drawing.Color.Black;
            this.txC11.Location = new System.Drawing.Point(722, 179);
            this.txC11.MaxLength = 49;
            this.txC11.Name = "txC11";
            this.txC11.ReadOnly = true;
            this.txC11.Size = new System.Drawing.Size(113, 27);
            this.txC11.TabIndex = 423;
            this.txC11.Text = "0";
            // 
            // textBox3
            // 
            this.textBox3.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox3.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox3.ForeColor = System.Drawing.Color.Red;
            this.textBox3.Location = new System.Drawing.Point(139, 60);
            this.textBox3.MaxLength = 49;
            this.textBox3.Multiline = true;
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(129, 27);
            this.textBox3.TabIndex = 424;
            this.textBox3.Text = "xxxxx";
            this.textBox3.Visible = false;
            // 
            // txC22
            // 
            this.txC22.BackColor = System.Drawing.Color.PaleGreen;
            this.txC22.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC22.ForeColor = System.Drawing.Color.Black;
            this.txC22.Location = new System.Drawing.Point(641, 442);
            this.txC22.MaxLength = 49;
            this.txC22.Name = "txC22";
            this.txC22.ReadOnly = true;
            this.txC22.Size = new System.Drawing.Size(159, 27);
            this.txC22.TabIndex = 526;
            this.txC22.Text = "0";
            this.txC22.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txC22.Visible = false;
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox5.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox5.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox5.ForeColor = System.Drawing.Color.Red;
            this.textBox5.Location = new System.Drawing.Point(294, 119);
            this.textBox5.MaxLength = 49;
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(128, 26);
            this.textBox5.TabIndex = 425;
            this.textBox5.Text = "xxxx";
            this.textBox5.Visible = false;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox10.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox10.ForeColor = System.Drawing.Color.Black;
            this.textBox10.Location = new System.Drawing.Point(11, 212);
            this.textBox10.MaxLength = 49;
            this.textBox10.Multiline = true;
            this.textBox10.Name = "textBox10";
            this.textBox10.ReadOnly = true;
            this.textBox10.Size = new System.Drawing.Size(343, 27);
            this.textBox10.TabIndex = 426;
            this.textBox10.Text = "Type de temps";
            this.textBox10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cbTmtype
            // 
            this.cbTmtype.BackColor = System.Drawing.Color.MistyRose;
            this.cbTmtype.DropDownHeight = 120;
            this.cbTmtype.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTmtype.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbTmtype.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTmtype.ForeColor = System.Drawing.Color.Black;
            this.cbTmtype.IntegralHeight = false;
            this.cbTmtype.ItemHeight = 17;
            this.cbTmtype.Location = new System.Drawing.Point(354, 213);
            this.cbTmtype.Name = "cbTmtype";
            this.cbTmtype.Size = new System.Drawing.Size(260, 25);
            this.cbTmtype.TabIndex = 428;
            this.cbTmtype.SelectedIndexChanged += new System.EventHandler(this.cbTmtype_SelectedIndexChanged);
            // 
            // cof13
            // 
            this.cof13.BackColor = System.Drawing.Color.Peru;
            this.cof13.Location = new System.Drawing.Point(523, 145);
            this.cof13.Name = "cof13";
            this.cof13.Size = new System.Drawing.Size(43, 27);
            this.cof13.TabIndex = 429;
            this.cof13.Text = "0";
            this.cof13.Visible = false;
            // 
            // textBox13
            // 
            this.textBox13.BackColor = System.Drawing.Color.WhiteSmoke;
            this.textBox13.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox13.ForeColor = System.Drawing.Color.Black;
            this.textBox13.Location = new System.Drawing.Point(614, 212);
            this.textBox13.MaxLength = 49;
            this.textBox13.Multiline = true;
            this.textBox13.Name = "textBox13";
            this.textBox13.ReadOnly = true;
            this.textBox13.Size = new System.Drawing.Size(108, 27);
            this.textBox13.TabIndex = 430;
            this.textBox13.Text = "Prix";
            this.textBox13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txC13
            // 
            this.txC13.BackColor = System.Drawing.Color.PaleGreen;
            this.txC13.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC13.ForeColor = System.Drawing.Color.Black;
            this.txC13.Location = new System.Drawing.Point(722, 212);
            this.txC13.MaxLength = 49;
            this.txC13.Name = "txC13";
            this.txC13.ReadOnly = true;
            this.txC13.Size = new System.Drawing.Size(113, 27);
            this.txC13.TabIndex = 431;
            this.txC13.Text = "0";
            this.txC13.TextChanged += new System.EventHandler(this.txC13_TextChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.AliceBlue;
            this.label1.ForeColor = System.Drawing.Color.Brown;
            this.label1.Location = new System.Drawing.Point(462, 87);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 26);
            this.label1.TabIndex = 432;
            this.label1.Text = "KM";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txB16
            // 
            this.txB16.BackColor = System.Drawing.Color.White;
            this.txB16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txB16.ForeColor = System.Drawing.Color.Black;
            this.txB16.Location = new System.Drawing.Point(354, 273);
            this.txB16.MaxLength = 49;
            this.txB16.Name = "txB16";
            this.txB16.Size = new System.Drawing.Size(108, 27);
            this.txB16.TabIndex = 434;
            this.txB16.Text = "0";
            this.txB16.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txB16.TextChanged += new System.EventHandler(this.txB16_TextChanged);
            // 
            // textBox17
            // 
            this.textBox17.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox17.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox17.ForeColor = System.Drawing.Color.Black;
            this.textBox17.Location = new System.Drawing.Point(11, 273);
            this.textBox17.MaxLength = 49;
            this.textBox17.Multiline = true;
            this.textBox17.Name = "textBox17";
            this.textBox17.ReadOnly = true;
            this.textBox17.Size = new System.Drawing.Size(343, 27);
            this.textBox17.TabIndex = 433;
            this.textBox17.Text = "Billet d\'avion (avec taxes)";
            this.textBox17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textBox16
            // 
            this.textBox16.BackColor = System.Drawing.Color.AliceBlue;
            this.textBox16.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.textBox16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox16.ForeColor = System.Drawing.Color.Black;
            this.textBox16.Location = new System.Drawing.Point(17, 247);
            this.textBox16.MaxLength = 49;
            this.textBox16.Multiline = true;
            this.textBox16.Name = "textBox16";
            this.textBox16.ReadOnly = true;
            this.textBox16.Size = new System.Drawing.Size(351, 26);
            this.textBox16.TabIndex = 435;
            this.textBox16.Text = "Frais de déplacements (autres): ";
            // 
            // txB17
            // 
            this.txB17.BackColor = System.Drawing.Color.White;
            this.txB17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txB17.ForeColor = System.Drawing.Color.Black;
            this.txB17.Location = new System.Drawing.Point(354, 307);
            this.txB17.MaxLength = 49;
            this.txB17.Name = "txB17";
            this.txB17.Size = new System.Drawing.Size(108, 27);
            this.txB17.TabIndex = 437;
            this.txB17.Text = "0";
            this.txB17.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txB17.TextChanged += new System.EventHandler(this.txB17_TextChanged);
            // 
            // textBox14
            // 
            this.textBox14.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox14.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox14.ForeColor = System.Drawing.Color.Black;
            this.textBox14.Location = new System.Drawing.Point(11, 307);
            this.textBox14.MaxLength = 49;
            this.textBox14.Multiline = true;
            this.textBox14.Name = "textBox14";
            this.textBox14.ReadOnly = true;
            this.textBox14.Size = new System.Drawing.Size(343, 26);
            this.textBox14.TabIndex = 436;
            this.textBox14.Text = "Hébergement (avec taxes)";
            this.textBox14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txC19
            // 
            this.txC19.BackColor = System.Drawing.Color.PaleGreen;
            this.txC19.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC19.ForeColor = System.Drawing.Color.Black;
            this.txC19.Location = new System.Drawing.Point(499, 374);
            this.txC19.MaxLength = 49;
            this.txC19.Name = "txC19";
            this.txC19.ReadOnly = true;
            this.txC19.Size = new System.Drawing.Size(120, 27);
            this.txC19.TabIndex = 452;
            this.txC19.Text = "0";
            this.txC19.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txC24_th
            // 
            this.txC24_th.BackColor = System.Drawing.Color.PaleGreen;
            this.txC24_th.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC24_th.ForeColor = System.Drawing.Color.Black;
            this.txC24_th.Location = new System.Drawing.Point(368, 247);
            this.txC24_th.MaxLength = 49;
            this.txC24_th.Multiline = true;
            this.txC24_th.Name = "txC24_th";
            this.txC24_th.ReadOnly = true;
            this.txC24_th.Size = new System.Drawing.Size(251, 26);
            this.txC24_th.TabIndex = 438;
            this.txC24_th.Text = "0";
            this.txC24_th.Visible = false;
            this.txC24_th.TextChanged += new System.EventHandler(this.txC24_th_TextChanged);
            // 
            // txB18
            // 
            this.txB18.BackColor = System.Drawing.Color.White;
            this.txB18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txB18.ForeColor = System.Drawing.Color.Black;
            this.txB18.Location = new System.Drawing.Point(354, 340);
            this.txB18.MaxLength = 49;
            this.txB18.Name = "txB18";
            this.txB18.Size = new System.Drawing.Size(108, 27);
            this.txB18.TabIndex = 440;
            this.txB18.Text = "0";
            this.txB18.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txB18.TextChanged += new System.EventHandler(this.textBox20_TextChanged);
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.Color.AliceBlue;
            this.label13.ForeColor = System.Drawing.Color.Brown;
            this.label13.Location = new System.Drawing.Point(839, 132);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(33, 26);
            this.label13.TabIndex = 508;
            this.label13.Text = "Hrs";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txB19
            // 
            this.txB19.BackColor = System.Drawing.Color.White;
            this.txB19.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txB19.ForeColor = System.Drawing.Color.Black;
            this.txB19.Location = new System.Drawing.Point(354, 374);
            this.txB19.MaxLength = 49;
            this.txB19.Name = "txB19";
            this.txB19.Size = new System.Drawing.Size(108, 27);
            this.txB19.TabIndex = 442;
            this.txB19.Text = "0";
            this.txB19.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txB19.TextChanged += new System.EventHandler(this.txB19_TextChanged);
            // 
            // textBox15
            // 
            this.textBox15.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox15.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox15.ForeColor = System.Drawing.Color.Black;
            this.textBox15.Location = new System.Drawing.Point(11, 374);
            this.textBox15.MaxLength = 49;
            this.textBox15.Multiline = true;
            this.textBox15.Name = "textBox15";
            this.textBox15.ReadOnly = true;
            this.textBox15.Size = new System.Drawing.Size(343, 26);
            this.textBox15.TabIndex = 441;
            this.textBox15.Text = "Indemnité quotidienne (jours)";
            this.textBox15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txB20
            // 
            this.txB20.BackColor = System.Drawing.Color.White;
            this.txB20.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txB20.ForeColor = System.Drawing.Color.Black;
            this.txB20.Location = new System.Drawing.Point(354, 407);
            this.txB20.MaxLength = 49;
            this.txB20.Name = "txB20";
            this.txB20.Size = new System.Drawing.Size(108, 27);
            this.txB20.TabIndex = 444;
            this.txB20.Text = "0";
            this.txB20.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txB20.TextChanged += new System.EventHandler(this.txB20_TextChanged);
            // 
            // textBox23
            // 
            this.textBox23.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox23.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox23.ForeColor = System.Drawing.Color.Black;
            this.textBox23.Location = new System.Drawing.Point(11, 407);
            this.textBox23.MaxLength = 49;
            this.textBox23.Multiline = true;
            this.textBox23.Name = "textBox23";
            this.textBox23.ReadOnly = true;
            this.textBox23.Size = new System.Drawing.Size(343, 27);
            this.textBox23.TabIndex = 443;
            this.textBox23.Text = "Location chargeur/batteries";
            this.textBox23.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txB21
            // 
            this.txB21.BackColor = System.Drawing.Color.White;
            this.txB21.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txB21.ForeColor = System.Drawing.Color.Black;
            this.txB21.Location = new System.Drawing.Point(354, 441);
            this.txB21.MaxLength = 49;
            this.txB21.Name = "txB21";
            this.txB21.Size = new System.Drawing.Size(108, 27);
            this.txB21.TabIndex = 446;
            this.txB21.Text = "0";
            this.txB21.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txB21.TextChanged += new System.EventHandler(this.txB21_TextChanged);
            // 
            // textBox21
            // 
            this.textBox21.BackColor = System.Drawing.Color.LemonChiffon;
            this.textBox21.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox21.ForeColor = System.Drawing.Color.Black;
            this.textBox21.Location = new System.Drawing.Point(11, 441);
            this.textBox21.MaxLength = 49;
            this.textBox21.Multiline = true;
            this.textBox21.Name = "textBox21";
            this.textBox21.ReadOnly = true;
            this.textBox21.Size = new System.Drawing.Size(343, 26);
            this.textBox21.TabIndex = 445;
            this.textBox21.Text = "Autres";
            this.textBox21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.AliceBlue;
            this.label2.ForeColor = System.Drawing.Color.Brown;
            this.label2.Location = new System.Drawing.Point(462, 145);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 27);
            this.label2.TabIndex = 447;
            this.label2.Text = "Hrs";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.AliceBlue;
            this.label5.ForeColor = System.Drawing.Color.Brown;
            this.label5.Location = new System.Drawing.Point(462, 179);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 26);
            this.label5.TabIndex = 448;
            this.label5.Text = "Hrs";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txC16
            // 
            this.txC16.BackColor = System.Drawing.Color.PaleGreen;
            this.txC16.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC16.ForeColor = System.Drawing.Color.Black;
            this.txC16.Location = new System.Drawing.Point(499, 277);
            this.txC16.MaxLength = 49;
            this.txC16.Name = "txC16";
            this.txC16.ReadOnly = true;
            this.txC16.Size = new System.Drawing.Size(120, 27);
            this.txC16.TabIndex = 450;
            this.txC16.Text = "0";
            this.txC16.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txC20
            // 
            this.txC20.BackColor = System.Drawing.Color.PaleGreen;
            this.txC20.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC20.ForeColor = System.Drawing.Color.Black;
            this.txC20.Location = new System.Drawing.Point(499, 407);
            this.txC20.MaxLength = 49;
            this.txC20.Name = "txC20";
            this.txC20.ReadOnly = true;
            this.txC20.Size = new System.Drawing.Size(120, 27);
            this.txC20.TabIndex = 454;
            this.txC20.Text = "0";
            this.txC20.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txC21
            // 
            this.txC21.BackColor = System.Drawing.Color.PaleGreen;
            this.txC21.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC21.ForeColor = System.Drawing.Color.Black;
            this.txC21.Location = new System.Drawing.Point(499, 441);
            this.txC21.MaxLength = 49;
            this.txC21.Name = "txC21";
            this.txC21.ReadOnly = true;
            this.txC21.Size = new System.Drawing.Size(120, 27);
            this.txC21.TabIndex = 456;
            this.txC21.Text = "0";
            this.txC21.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txC18
            // 
            this.txC18.BackColor = System.Drawing.Color.PaleGreen;
            this.txC18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC18.ForeColor = System.Drawing.Color.Black;
            this.txC18.Location = new System.Drawing.Point(499, 340);
            this.txC18.MaxLength = 49;
            this.txC18.Name = "txC18";
            this.txC18.ReadOnly = true;
            this.txC18.Size = new System.Drawing.Size(120, 27);
            this.txC18.TabIndex = 458;
            this.txC18.Text = "0";
            this.txC18.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // txC17
            // 
            this.txC17.BackColor = System.Drawing.Color.PaleGreen;
            this.txC17.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC17.ForeColor = System.Drawing.Color.Black;
            this.txC17.Location = new System.Drawing.Point(499, 307);
            this.txC17.MaxLength = 49;
            this.txC17.Name = "txC17";
            this.txC17.ReadOnly = true;
            this.txC17.Size = new System.Drawing.Size(120, 27);
            this.txC17.TabIndex = 460;
            this.txC17.Text = "0";
            this.txC17.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // cof16
            // 
            this.cof16.BackColor = System.Drawing.Color.Peru;
            this.cof16.Location = new System.Drawing.Point(648, 277);
            this.cof16.Name = "cof16";
            this.cof16.Size = new System.Drawing.Size(43, 26);
            this.cof16.TabIndex = 461;
            this.cof16.Text = "1.15";
            this.cof16.Visible = false;
            // 
            // cof17
            // 
            this.cof17.BackColor = System.Drawing.Color.Peru;
            this.cof17.Location = new System.Drawing.Point(679, 314);
            this.cof17.Name = "cof17";
            this.cof17.Size = new System.Drawing.Size(43, 26);
            this.cof17.TabIndex = 462;
            this.cof17.Text = "1.15";
            this.cof17.Visible = false;
            // 
            // cof18
            // 
            this.cof18.BackColor = System.Drawing.Color.Peru;
            this.cof18.Location = new System.Drawing.Point(689, 340);
            this.cof18.Name = "cof18";
            this.cof18.Size = new System.Drawing.Size(43, 27);
            this.cof18.TabIndex = 463;
            this.cof18.Text = "1.15";
            this.cof18.Visible = false;
            // 
            // cof19
            // 
            this.cof19.BackColor = System.Drawing.Color.Peru;
            this.cof19.Location = new System.Drawing.Point(689, 374);
            this.cof19.Name = "cof19";
            this.cof19.Size = new System.Drawing.Size(43, 26);
            this.cof19.TabIndex = 464;
            this.cof19.Text = "85";
            this.cof19.Visible = false;
            // 
            // cof20
            // 
            this.cof20.BackColor = System.Drawing.Color.Peru;
            this.cof20.Location = new System.Drawing.Point(770, 278);
            this.cof20.Name = "cof20";
            this.cof20.Size = new System.Drawing.Size(44, 27);
            this.cof20.TabIndex = 465;
            this.cof20.Text = "1";
            this.cof20.Visible = false;
            // 
            // cof21
            // 
            this.cof21.BackColor = System.Drawing.Color.Peru;
            this.cof21.Location = new System.Drawing.Point(748, 346);
            this.cof21.Name = "cof21";
            this.cof21.Size = new System.Drawing.Size(43, 27);
            this.cof21.TabIndex = 466;
            this.cof21.Text = "1.15";
            this.cof21.Visible = false;
            // 
            // cof7
            // 
            this.cof7.BackColor = System.Drawing.Color.Peru;
            this.cof7.Location = new System.Drawing.Point(492, 113);
            this.cof7.Name = "cof7";
            this.cof7.Size = new System.Drawing.Size(43, 27);
            this.cof7.TabIndex = 467;
            this.cof7.Text = "1.4";
            this.cof7.Visible = false;
            // 
            // cof11_a
            // 
            this.cof11_a.BackColor = System.Drawing.Color.Peru;
            this.cof11_a.Location = new System.Drawing.Point(566, 145);
            this.cof11_a.Name = "cof11_a";
            this.cof11_a.Size = new System.Drawing.Size(33, 27);
            this.cof11_a.TabIndex = 468;
            this.cof11_a.Text = "1.2";
            this.cof11_a.Visible = false;
            // 
            // cof11_b
            // 
            this.cof11_b.BackColor = System.Drawing.Color.Peru;
            this.cof11_b.Location = new System.Drawing.Point(599, 145);
            this.cof11_b.Name = "cof11_b";
            this.cof11_b.Size = new System.Drawing.Size(43, 27);
            this.cof11_b.TabIndex = 469;
            this.cof11_b.Text = "0.125";
            this.cof11_b.Visible = false;
            // 
            // txC39
            // 
            this.txC39.BackColor = System.Drawing.Color.Red;
            this.txC39.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txC39.ForeColor = System.Drawing.Color.White;
            this.txC39.Location = new System.Drawing.Point(542, 778);
            this.txC39.MaxLength = 49;
            this.txC39.Name = "txC39";
            this.txC39.ReadOnly = true;
            this.txC39.Size = new System.Drawing.Size(195, 32);
            this.txC39.TabIndex = 525;
            this.txC39.Text = "0";
            this.txC39.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txC39.Visible = false;
            // 
            // txitem
            // 
            this.txitem.BackColor = System.Drawing.Color.White;
            this.txitem.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txitem.ForeColor = System.Drawing.Color.Black;
            this.txitem.Location = new System.Drawing.Point(145, 778);
            this.txitem.MaxLength = 49;
            this.txitem.Multiline = true;
            this.txitem.Name = "txitem";
            this.txitem.Size = new System.Drawing.Size(397, 31);
            this.txitem.TabIndex = 524;
            this.txitem.Text = "SERVICE ";
            this.txitem.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txitem.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.Color.Coral;
            this.groupBox1.Controls.Add(this.chkAuto);
            this.groupBox1.Controls.Add(this.lIotherF);
            this.groupBox1.Controls.Add(this.tIotherF);
            this.groupBox1.Controls.Add(this.valFrais);
            this.groupBox1.Controls.Add(this.chk1);
            this.groupBox1.Controls.Add(this.chk2);
            this.groupBox1.Controls.Add(this.label10);
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.label9);
            this.groupBox1.Controls.Add(this.pictureBox3);
            this.groupBox1.Controls.Add(this.lsave);
            this.groupBox1.Controls.Add(this.chkM);
            this.groupBox1.Controls.Add(this.chkD);
            this.groupBox1.Controls.Add(this.tSMRK);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.btnClear);
            this.groupBox1.Controls.Add(this.btnDel);
            this.groupBox1.Controls.Add(this.lif2);
            this.groupBox1.Controls.Add(this.pictureBox2);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.not);
            this.groupBox1.Controls.Add(this.picSeek);
            this.groupBox1.Controls.Add(this.lif1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Location = new System.Drawing.Point(1716, 528);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(91, 69);
            this.groupBox1.TabIndex = 159;
            this.groupBox1.TabStop = false;
            this.groupBox1.Visible = false;
            // 
            // chkAuto
            // 
            this.chkAuto.Checked = true;
            this.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuto.Location = new System.Drawing.Point(449, -135);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(55, 27);
            this.chkAuto.TabIndex = 164;
            this.chkAuto.Text = "Auto Sell  Price";
            this.chkAuto.Visible = false;
            // 
            // lIotherF
            // 
            this.lIotherF.BackColor = System.Drawing.Color.Lavender;
            this.lIotherF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lIotherF.Location = new System.Drawing.Point(58, 22);
            this.lIotherF.MaxLength = 49;
            this.lIotherF.Name = "lIotherF";
            this.lIotherF.Size = new System.Drawing.Size(105, 22);
            this.lIotherF.TabIndex = 148;
            // 
            // tIotherF
            // 
            this.tIotherF.BackColor = System.Drawing.Color.Lavender;
            this.tIotherF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tIotherF.Location = new System.Drawing.Point(187, 110);
            this.tIotherF.MaxLength = 1000;
            this.tIotherF.Multiline = true;
            this.tIotherF.Name = "tIotherF";
            this.tIotherF.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tIotherF.Size = new System.Drawing.Size(57, 22);
            this.tIotherF.TabIndex = 145;
            // 
            // valFrais
            // 
            this.valFrais.BackColor = System.Drawing.Color.White;
            this.valFrais.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.valFrais.ForeColor = System.Drawing.Color.Black;
            this.valFrais.Location = new System.Drawing.Point(49, 218);
            this.valFrais.MaxLength = 49;
            this.valFrais.Name = "valFrais";
            this.valFrais.ReadOnly = true;
            this.valFrais.Size = new System.Drawing.Size(120, 26);
            this.valFrais.TabIndex = 181;
            this.valFrais.Text = "0";
            this.valFrais.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.valFrais.Visible = false;
            // 
            // chk1
            // 
            this.chk1.Checked = true;
            this.chk1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk1.Location = new System.Drawing.Point(10, 93);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(48, 19);
            this.chk1.TabIndex = 156;
            this.chk1.Text = "#1";
            // 
            // chk2
            // 
            this.chk2.Checked = true;
            this.chk2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk2.Location = new System.Drawing.Point(10, 117);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(48, 18);
            this.chk2.TabIndex = 157;
            this.chk2.Text = "#2";
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.Color.AliceBlue;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.Red;
            this.label10.Location = new System.Drawing.Point(445, 84);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(83, 16);
            this.label10.TabIndex = 178;
            this.label10.Text = "Empty Item";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox1
            // 
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(115, 45);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(48, 18);
            this.checkBox1.TabIndex = 158;
            this.checkBox1.Tag = "";
            this.checkBox1.Text = "#3";
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.AliceBlue;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Red;
            this.label9.Location = new System.Drawing.Point(378, 84);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 16);
            this.label9.TabIndex = 177;
            this.label9.Text = "Delete";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(232, 23);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(48, 46);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 169;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            // 
            // lsave
            // 
            this.lsave.BackColor = System.Drawing.Color.AliceBlue;
            this.lsave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lsave.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lsave.ForeColor = System.Drawing.Color.Red;
            this.lsave.Location = new System.Drawing.Point(312, 84);
            this.lsave.Name = "lsave";
            this.lsave.Size = new System.Drawing.Size(47, 16);
            this.lsave.TabIndex = 176;
            this.lsave.Text = "Save";
            this.lsave.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkM
            // 
            this.chkM.Checked = true;
            this.chkM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkM.Location = new System.Drawing.Point(10, 47);
            this.chkM.Name = "chkM";
            this.chkM.Size = new System.Drawing.Size(48, 19);
            this.chkM.TabIndex = 160;
            // 
            // chkD
            // 
            this.chkD.Checked = true;
            this.chkD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkD.Location = new System.Drawing.Point(10, 70);
            this.chkD.Name = "chkD";
            this.chkD.Size = new System.Drawing.Size(48, 19);
            this.chkD.TabIndex = 161;
            // 
            // tSMRK
            // 
            this.tSMRK.BackColor = System.Drawing.Color.Gainsboro;
            this.tSMRK.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSMRK.ForeColor = System.Drawing.Color.Black;
            this.tSMRK.Location = new System.Drawing.Point(211, 218);
            this.tSMRK.MaxLength = 49;
            this.tSMRK.Name = "tSMRK";
            this.tSMRK.ReadOnly = true;
            this.tSMRK.Size = new System.Drawing.Size(96, 32);
            this.tSMRK.TabIndex = 157;
            this.tSMRK.Text = "1";
            this.tSMRK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tSMRK.Visible = false;
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.Color.Wheat;
            this.label36.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label36.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label36.Location = new System.Drawing.Point(196, 200);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(122, 18);
            this.label36.TabIndex = 158;
            this.label36.Text = "Markup";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label36.Visible = false;
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(144, 136);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(58, 23);
            this.btnClear.TabIndex = 162;
            this.btnClear.Text = "Clear";
            this.btnClear.Visible = false;
            // 
            // btnDel
            // 
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(211, 136);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(58, 23);
            this.btnDel.TabIndex = 152;
            this.btnDel.Text = "Delete";
            this.btnDel.Visible = false;
            // 
            // lif2
            // 
            this.lif2.BackColor = System.Drawing.Color.Lavender;
            this.lif2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lif2.Location = new System.Drawing.Point(180, 80);
            this.lif2.MaxLength = 49;
            this.lif2.Name = "lif2";
            this.lif2.Size = new System.Drawing.Size(86, 22);
            this.lif2.TabIndex = 134;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(382, 39);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 43);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 165;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(449, 39);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(55, 43);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 164;
            this.pictureBox1.TabStop = false;
            // 
            // not
            // 
            this.not.BackColor = System.Drawing.Color.AliceBlue;
            this.not.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.not.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.not.ForeColor = System.Drawing.SystemColors.ControlText;
            this.not.Location = new System.Drawing.Point(120, 173);
            this.not.Name = "not";
            this.not.Size = new System.Drawing.Size(60, 19);
            this.not.TabIndex = 144;
            this.not.Text = "Notes:";
            this.not.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picSeek
            // 
            this.picSeek.BackColor = System.Drawing.Color.Transparent;
            this.picSeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSeek.Image = ((System.Drawing.Image)(resources.GetObject("picSeek.Image")));
            this.picSeek.Location = new System.Drawing.Point(319, 43);
            this.picSeek.Name = "picSeek";
            this.picSeek.Size = new System.Drawing.Size(40, 39);
            this.picSeek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSeek.TabIndex = 163;
            this.picSeek.TabStop = false;
            // 
            // lif1
            // 
            this.lif1.BackColor = System.Drawing.Color.Lavender;
            this.lif1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lif1.Location = new System.Drawing.Point(17, 166);
            this.lif1.MaxLength = 49;
            this.lif1.Name = "lif1";
            this.lif1.Size = new System.Drawing.Size(86, 22);
            this.lif1.TabIndex = 132;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(36, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 37);
            this.label3.TabIndex = 126;
            this.label3.Text = "BUY &&  RESELL ITEM / OPTION";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.Green;
            this.btnOK.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnOK.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.ForeColor = System.Drawing.Color.White;
            this.btnOK.Location = new System.Drawing.Point(636, 730);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(199, 42);
            this.btnOK.TabIndex = 143;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ll
            // 
            this.ll.BackColor = System.Drawing.Color.AliceBlue;
            this.ll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ll.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ll.Location = new System.Drawing.Point(118, 753);
            this.ll.Name = "ll";
            this.ll.Size = new System.Drawing.Size(199, 25);
            this.ll.TabIndex = 128;
            this.ll.Text = "Item Name";
            this.ll.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ll.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Green;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.ForeColor = System.Drawing.Color.White;
            this.btnCancel.Location = new System.Drawing.Point(864, 730);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(216, 42);
            this.btnCancel.TabIndex = 142;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // txC35
            // 
            this.txC35.BackColor = System.Drawing.Color.Red;
            this.txC35.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold);
            this.txC35.ForeColor = System.Drawing.Color.White;
            this.txC35.Location = new System.Drawing.Point(767, 778);
            this.txC35.MaxLength = 49;
            this.txC35.Name = "txC35";
            this.txC35.ReadOnly = true;
            this.txC35.Size = new System.Drawing.Size(194, 32);
            this.txC35.TabIndex = 511;
            this.txC35.Text = "0";
            this.txC35.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.txC35.TextChanged += new System.EventHandler(this.txC35_TextChanged);
            // 
            // Q_service
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(1347, 674);
            this.Controls.Add(this.grpItem);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Q_service";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Service";
            this.Load += new System.EventHandler(this.Q_service_Load);
            this.grpItem.ResumeLayout(false);
            this.grpItem.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picalrm)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void label38_Click(object sender, System.EventArgs e)
		{
		
		}

		private string Cal_SellPrice(double ext)
		{
			if (ext > 0)
			{
				string stSql = "SELECT * FROM PSM_SMarkup where  " + ext + " <= Hlim and " + ext + " >= Llim ORDER BY Hlim ";
				SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
				OConn.Open();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
				while (Oreadr.Read())
				{
					tSMRK.Text = Oreadr["MRKPCA"].ToString();
					return Convert.ToString(Math.Round(Tools.Conv_Dbl(Oreadr["MRKPCA"].ToString()) * ext, MainMDI.NB_DEC_AFF));
				}
				OConn.Close();
				tSMRK.Text = "0";
			}
			return "0";
		}

		private void grpItem_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void NL_Item_Option_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
            //fill_Hn();
		}

		private void lvNLIO_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			//MessageBox.Show(e.Column.ToString());

			ListView myListView = (ListView)sender;

			//Determine if clicked column is already the column that is being sorted.
			if (e.Column == lvSorter.SortColumn)
			{
				//Reverse the current sort direction for this column.
				if (lvSorter.Order == System.Windows.Forms.SortOrder.Ascending)
				{
					lvSorter.Order = System.Windows.Forms.SortOrder.Descending;
				}
				else
				{
					lvSorter.Order = System.Windows.Forms.SortOrder.Ascending;
				}
			}
			else
			{
				//Set the column number that is to be sorted; default to ascending.
				lvSorter.SortColumn = e.Column;
				lvSorter.Order = System.Windows.Forms.SortOrder.Ascending;
			}
			//Perform the sort with these new sort options.
			myListView.Sort();
		}
	
		private void lvNLIO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void lvNLIO_ColumnClickpp(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
		
		}

        void fill_Hn()
        {
            string stSql = "SELECT *   FROM [Orig_PSM_FDB].[dbo].[PSM_C_GConfig]   where F1_Code='Hn' OR F1_Code='Hn_lim' OR F1_Code='Hn_amt'  order by LID";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                switch (Oreadr["F1_Code"].ToString())
                {
                    case "Hn":
                        H1_val = Oreadr["F2"].ToString();
                        H2_val = Oreadr["F3"].ToString();
                        H3_val = Oreadr["F4"].ToString();
                        H4_val = Oreadr["F5"].ToString();
                        H5_val = Oreadr["F6"].ToString();
                        H6_val = Oreadr["F7"].ToString();
                        break;
                    case "Hn_lim":
                        H1_lim = Oreadr["F2"].ToString();
                        H2_lim = Oreadr["F3"].ToString();
                        H3_lim = Oreadr["F4"].ToString();
                        H4_lim = Oreadr["F5"].ToString();
                        H5_lim = Oreadr["F6"].ToString();
                        H6_lim = Oreadr["F7"].ToString();
                        break;
                    case "Hn_amt":
                        H1_amt = Oreadr["F2"].ToString();
                        H2_amt = Oreadr["F3"].ToString();
                        H3_amt = Oreadr["F4"].ToString();
                        H4_amt = Oreadr["F5"].ToString();
                        H5_amt = Oreadr["F6"].ToString();
                        H6_amt = Oreadr["F7"].ToString();
                        break;
                }
            }
            OConn.Close();
        }

        private void Q_service_Load(object sender, EventArgs e)
        {
            init_scr();
        }

        private void txC7_TextChanged(object sender, EventArgs e)
        {

        }

        private void txB6_TextChanged(object sender, EventArgs e)
        {
            txC7.Text = MainMDI.kim_round(Tools.Conv_Dbl(txB6.Text) * Tools.Conv_Dbl(cof7.Text),2).ToString();
        }

        private void txB10_TextChanged(object sender, EventArgs e)
        {
            double B10 = Tools.Conv_Dbl(txB10.Text);
            txC11.Text = MainMDI.kim_round(B10 * Tools.Conv_Dbl(cof11_a.Text) + (B10 * Tools.Conv_Dbl(cof11_b.Text)), 2).ToString();
            cal_C13();
        }

        private void cbTmtype_SelectedIndexChanged(object sender, EventArgs e)
        {
            cof13.Text = MainMDI.get_CBX_value(cbTmtype, cbTmtype.SelectedIndex);
            cal_C13();
        }

        void init_scr()
        {
            fill_CBss();
            if (MainMDI.Lang == 0)
            {
                txitem_th.Text = leng_dh.Text;
                txitem_ts.Text = leng_ts.Text;
            }
            else
            {
                txitem_th.Text = lfr_dh.Text;
                txitem_ts.Text = lfr_ts.Text;
            }
        }

        void fill_CBss()
        {
            MainMDI.add_CB_itm(cbTmtype, "Select", "0");
            MainMDI.add_CB_itm(cbTmtype, "Lundi-Vendredi | 8am-5pm", "90");
            MainMDI.add_CB_itm(cbTmtype, "Lundi-Vendredi | 5pm-8am", "135");
            MainMDI.add_CB_itm(cbTmtype, "Samedi, dimanche et jours fériés", "175");
            cbTmtype.Text = cbTmtype.Items[0].ToString();

            MainMDI.add_CB_itm(cbsvcType, "Select", "0");
            MainMDI.add_CB_itm(cbsvcType, "Réparation", "4");
            MainMDI.add_CB_itm(cbsvcType, "Commissionning", "8");
            MainMDI.add_CB_itm(cbsvcType, "Test de décharge", "8");
            MainMDI.add_CB_itm(cbsvcType, "Training", "4");
            MainMDI.add_CB_itm(cbsvcType, "Open-Frame (min. 2 personnes)", "8");
            cbsvcType.Text = cbsvcType.Items[0].ToString();
        }

        void cal_C13()
        {
            txC13.Text = MainMDI.kim_round(Tools.Conv_Dbl(txC11.Text) * Tools.Conv_Dbl(cof13.Text) * Tools.Conv_Dbl(txB9.Text) * 2, 2).ToString();
        }

        void cal_C33()
        {
            double dd = Tools.Conv_Dbl(B30.Text) * Tools.Conv_Dbl(cof30.Text) + Tools.Conv_Dbl(B31.Text) * Tools.Conv_Dbl(cof31.Text) + Tools.Conv_Dbl(B32.Text) * Tools.Conv_Dbl(cof32.Text);
            txC33_ts.Text = MainMDI.kim_round(dd * Tools.Conv_Dbl(txB9.Text), 2).ToString();

            //txC24.Text = MainMDI.kim_round((Tools.Conv_Dbl(txC13.Text) + Tools.Conv_Dbl(txC22.Text)) + Tools.Conv_Dbl(txC7.Text), 2).ToString();
        }

        void cal_C35_ts()
        {
            txC35_ts.Text = MainMDI.kim_round(Tools.Conv_Dbl(txC33_ts.Text), 2).ToString();
            double dd = Tools.Conv_Dbl(txC35_ts.Text) * Tools.Conv_Dbl(txB36_ts.Text) / 100;
            txC36_ts.Text = MainMDI.kim_round(Tools.Conv_Dbl(txC35_ts.Text) - dd, 2).ToString();
            txC37_ts.Text = MainMDI.kim_round(Tools.Conv_Dbl(txC36_ts.Text) * Tools.Conv_Dbl("0.05"), 2).ToString();
            txC38_ts.Text = MainMDI.kim_round((Tools.Conv_Dbl(txC36_ts.Text) + Tools.Conv_Dbl(txC37_ts.Text)) * Tools.Conv_Dbl("0.09975"), 2).ToString();
            txC39_ts.Text = MainMDI.kim_round(Tools.Conv_Dbl(txC36_ts.Text) + Tools.Conv_Dbl(txC37_ts.Text) + Tools.Conv_Dbl(txC38_ts.Text), 2).ToString();
        }

        void cal_C35_th()
        {
            txC35_th.Text = MainMDI.kim_round(Tools.Conv_Dbl(txC24_th.Text), 2).ToString();
            double dd = Tools.Conv_Dbl(txC35_th.Text) * Tools.Conv_Dbl(txB36_th.Text) / 100;
            txC36_th.Text = MainMDI.kim_round(Tools.Conv_Dbl(txC35_th.Text) - dd, 2).ToString();
            txC37_th.Text = MainMDI.kim_round(Tools.Conv_Dbl(txC36_th.Text) * Tools.Conv_Dbl("0.05"), 2).ToString();
            txC38_th.Text = MainMDI.kim_round((Tools.Conv_Dbl(txC36_th.Text) + Tools.Conv_Dbl(txC37_th.Text)) * Tools.Conv_Dbl("0.09975"), 2).ToString();
            txC39_th.Text = MainMDI.kim_round(Tools.Conv_Dbl(txC36_th.Text) + Tools.Conv_Dbl(txC37_th.Text) + Tools.Conv_Dbl(txC38_th.Text), 2).ToString();
        }

        void cal_B29()
        {
            double dd = Tools.Conv_Dbl(lcbval.Text) * Tools.Conv_Dbl(txB27.Text);
            B29.Text = dd.ToString();
        }

        void cal_C22()
        {
            txC22.Text = MainMDI.kim_round(Tools.Conv_Dbl(txC16.Text) +
                  Tools.Conv_Dbl(txC17.Text) +
                  Tools.Conv_Dbl(txC18.Text) +
                  Tools.Conv_Dbl(txC19.Text) +
                  Tools.Conv_Dbl(txC20.Text) +
                  Tools.Conv_Dbl(txC21.Text), 2).ToString();
            txC24_th.Text = MainMDI.kim_round((Tools.Conv_Dbl(txC13.Text) + Tools.Conv_Dbl(txC22.Text)) + Tools.Conv_Dbl(txC7.Text), 2).ToString();
        }

        private void txB9_TextChanged(object sender, EventArgs e)
        {
            cal_C13();
        }

        private void txB16_TextChanged(object sender, EventArgs e)
        {
            txC16.Text = MainMDI.kim_round(Tools.Conv_Dbl(txB16.Text) * Tools.Conv_Dbl(cof16.Text) * Tools.Conv_Dbl(txB9.Text), 2).ToString();
            cal_C22();
        }

        private void txB17_TextChanged(object sender, EventArgs e)
        {
            txC17.Text = MainMDI.kim_round(Tools.Conv_Dbl(txB17.Text) * Tools.Conv_Dbl(cof17.Text) * Tools.Conv_Dbl(txB9.Text), 2).ToString();
            cal_C22();
        }

        private void textBox20_TextChanged(object sender, EventArgs e)
        {
            txC18.Text = MainMDI.kim_round(Tools.Conv_Dbl(txB18.Text) * Tools.Conv_Dbl(cof18.Text) * Tools.Conv_Dbl(txB9.Text), 2).ToString();
            cal_C22();
        }

        private void txB19_TextChanged(object sender, EventArgs e)
        {
            txC19.Text = MainMDI.kim_round(Tools.Conv_Dbl(txB19.Text) * Tools.Conv_Dbl(cof19.Text) * Tools.Conv_Dbl(txB9.Text), 2).ToString();
            cal_C22();
        }

        private void txB20_TextChanged(object sender, EventArgs e)
        {
            //txC20.Text = MainMDI.kim_round(Tools.Conv_Dbl(txB20.Text) * Tools.Conv_Dbl(cof20.Text) * Tools.Conv_Dbl(txB9.Text), 2).ToString();
            txC20.Text = Tools.Conv_Dbl(txB20.Text).ToString(); //* Tools.Conv_Dbl(cof20.Text) * Tools.Conv_Dbl(txB9.Text), 2).ToString();
            cal_C22();
        }

        private void txB21_TextChanged(object sender, EventArgs e)
        {
            txC21.Text = MainMDI.kim_round(Tools.Conv_Dbl(txB21.Text) * Tools.Conv_Dbl(cof21.Text), 2).ToString();
            cal_C22();
        }

        private void cbsvcType_SelectedIndexChanged(object sender, EventArgs e)
        {
            lcbval.Text = MainMDI.get_CBX_value(cbsvcType, cbsvcType.SelectedIndex);
            cal_B29();
        }

        private void B30_TextChanged(object sender, EventArgs e)
        {
            check_Hrs();
        }

        void check_Hrs()
        {
            if ((Tools.Conv_Dbl(B30.Text) + Tools.Conv_Dbl(B31.Text) + Tools.Conv_Dbl(B32.Text)) < Tools.Conv_Dbl(B29.Text))
            {
                picalrm.Visible = true;
                lhrs_msg.Visible = true;
                lhrs_msg.Text = "Le nombre d'heures sur site doivent etre > " + Tools.Conv_Dbl(B29.Text).ToString();
            }
            else
            {
                picalrm.Visible = false;
                lhrs_msg.Visible = false;
                cal_C33();
            }
        }
        private void B30_Leave(object sender, EventArgs e)
        {

        }

        private void txB27_TextChanged(object sender, EventArgs e)
        {
            cal_B29();
        }

        private void B31_Leave(object sender, EventArgs e)
        {

        }

        private void B32_Leave(object sender, EventArgs e)
        {

        }

        private void B31_TextChanged(object sender, EventArgs e)
        {
            check_Hrs();
        }

        private void B32_TextChanged(object sender, EventArgs e)
        {
            check_Hrs();
        }

        private void txC13_TextChanged(object sender, EventArgs e)
        {
            cal_C22();
        }

        bool chk_info()
        {
            bool res = true;
            if (chk_th.Checked) res = (txitem_th.Text != "" && Tools.Conv_Dbl(txC39_th.Text) > 0);
            if (chk_ts.Checked) res = (txitem_ts.Text != "" && Tools.Conv_Dbl(txC39_ts.Text) > 0);
            return res;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (chk_info()) //tIExt.Text != "0" &&
            {
                SaveOK = true;
                //lsavALLinfo.Text = savallInfo();
                this.Hide();
            }
            else MessageBox.Show("Empty items or Invalid Costs............. !!!!!");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            SaveOK = false;
            this.Hide();
        }

        private void textBox26_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox41_TextChanged(object sender, EventArgs e)
        {

        }

        private void txC37_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox35_TextChanged(object sender, EventArgs e)
        {

        }

        private void txC36_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox32_TextChanged(object sender, EventArgs e)
        {

        }

        private void txC35_TextChanged(object sender, EventArgs e)
        {

        }

        private void txC38_TextChanged(object sender, EventArgs e)
        {

        }

        private void txC33_ts_TextChanged(object sender, EventArgs e)
        {
            cal_C35_ts();
        }

        private void txC24_th_TextChanged(object sender, EventArgs e)
        {
            cal_C35_th();
        }

        private void txB36_ts_TextChanged(object sender, EventArgs e)
        {
            cal_C35_ts();
        }

        private void txB36_th_TextChanged(object sender, EventArgs e)
        {
            cal_C35_th();
        }
	}
}