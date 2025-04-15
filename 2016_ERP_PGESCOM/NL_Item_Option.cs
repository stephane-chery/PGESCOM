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
	/// Summary description for NL_Item_Option.
	/// </summary>
	public class NL_Item_Option : System.Windows.Forms.Form
	{

		private Lib1 Tools = new Lib1();
		private ListViewColumnSorter  lvSorter=null;
		private string In_QID;
		public bool SaveOK=false;
		private int LVNdx=-1;
		private System.Windows.Forms.GroupBox grpItem;
		public System.Windows.Forms.TextBox lIotherF;
		public System.Windows.Forms.TextBox tIotherF;
		private System.Windows.Forms.Label not;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOKnSave;
		public System.Windows.Forms.TextBox tIf1;
		public System.Windows.Forms.TextBox tINotes;
		public System.Windows.Forms.TextBox lif2;
		public System.Windows.Forms.TextBox tIf2;
		public System.Windows.Forms.TextBox lif1;
		private System.Windows.Forms.Label ll;
		public System.Windows.Forms.TextBox tIName;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label47;
		public System.Windows.Forms.TextBox tIdim;
		private System.Windows.Forms.Label label48;
		public System.Windows.Forms.TextBox tIModel;
		private System.Windows.Forms.ListView lvNLIO;
		private System.Windows.Forms.ColumnHeader IOName;
		private System.Windows.Forms.ColumnHeader Model;
		private System.Windows.Forms.ColumnHeader Dim;
		private System.Windows.Forms.ColumnHeader F1;
		private System.Windows.Forms.ColumnHeader F2;
		private System.Windows.Forms.ColumnHeader OFt;
		private System.Windows.Forms.ColumnHeader UP;
		private System.Windows.Forms.ColumnHeader LT;
		private System.Windows.Forms.ColumnHeader note;
		private System.Windows.Forms.ColumnHeader usr;
		private System.Windows.Forms.ColumnHeader QID;
		private System.Windows.Forms.ColumnHeader LID;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnDel;
		public System.Windows.Forms.CheckBox chk1;
		public System.Windows.Forms.CheckBox chk2;
		public System.Windows.Forms.CheckBox checkBox1;
		private System.Windows.Forms.GroupBox groupBox1;
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
		public System.Windows.Forms.CheckBox chkD;
		public System.Windows.Forms.CheckBox chkM;
		private System.Windows.Forms.Button btnClear;
		public System.Windows.Forms.CheckBox chkAuto;
		private System.Windows.Forms.ColumnHeader qTTY;
		private System.Windows.Forms.ColumnHeader Sprice;
		private System.Windows.Forms.ColumnHeader Mult;
		private System.Windows.Forms.PictureBox picSeek;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label52;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label57;
		private System.Windows.Forms.GroupBox groupBox9;
		private System.Windows.Forms.RadioButton opEuro;
		private System.Windows.Forms.RadioButton opUS;
		private System.Windows.Forms.RadioButton opCan;
		private System.Windows.Forms.Label lcurDol;
		private System.Windows.Forms.PictureBox pictureBox3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public NL_Item_Option(string x_QID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			In_QID= x_QID;
			lvSorter = new ListViewColumnSorter(); 
			this.lvNLIO.ListViewItemSorter  = lvSorter ; 
			lvNLIO.Sorting =System.Windows.Forms.SortOrder.Ascending ;
			lvNLIO.AutoArrange=true; 
			fill_lvNLIO();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NL_Item_Option));
            this.grpItem = new System.Windows.Forms.GroupBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.label57 = new System.Windows.Forms.Label();
            this.groupBox9 = new System.Windows.Forms.GroupBox();
            this.opEuro = new System.Windows.Forms.RadioButton();
            this.opUS = new System.Windows.Forms.RadioButton();
            this.opCan = new System.Windows.Forms.RadioButton();
            this.label52 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.picSeek = new System.Windows.Forms.PictureBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.chkD = new System.Windows.Forms.CheckBox();
            this.chkM = new System.Windows.Forms.CheckBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lcurDol = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.chkAuto = new System.Windows.Forms.CheckBox();
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
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.chk2 = new System.Windows.Forms.CheckBox();
            this.chk1 = new System.Windows.Forms.CheckBox();
            this.btnEdit = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            this.lIotherF = new System.Windows.Forms.TextBox();
            this.tIotherF = new System.Windows.Forms.TextBox();
            this.not = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOKnSave = new System.Windows.Forms.Button();
            this.tIf1 = new System.Windows.Forms.TextBox();
            this.tINotes = new System.Windows.Forms.TextBox();
            this.lif2 = new System.Windows.Forms.TextBox();
            this.tIf2 = new System.Windows.Forms.TextBox();
            this.lif1 = new System.Windows.Forms.TextBox();
            this.ll = new System.Windows.Forms.Label();
            this.tIName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label47 = new System.Windows.Forms.Label();
            this.tIdim = new System.Windows.Forms.TextBox();
            this.label48 = new System.Windows.Forms.Label();
            this.tIModel = new System.Windows.Forms.TextBox();
            this.lvNLIO = new System.Windows.Forms.ListView();
            this.IOName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Model = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dim = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.F1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.F2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OFt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qTTY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.UP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Mult = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Sprice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.note = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.usr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.QID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.groupBox9.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpItem
            // 
            this.grpItem.Controls.Add(this.pictureBox3);
            this.grpItem.Controls.Add(this.label57);
            this.grpItem.Controls.Add(this.groupBox9);
            this.grpItem.Controls.Add(this.label52);
            this.grpItem.Controls.Add(this.pictureBox2);
            this.grpItem.Controls.Add(this.pictureBox1);
            this.grpItem.Controls.Add(this.picSeek);
            this.grpItem.Controls.Add(this.btnClear);
            this.grpItem.Controls.Add(this.chkD);
            this.grpItem.Controls.Add(this.chkM);
            this.grpItem.Controls.Add(this.groupBox1);
            this.grpItem.Controls.Add(this.checkBox1);
            this.grpItem.Controls.Add(this.chk2);
            this.grpItem.Controls.Add(this.chk1);
            this.grpItem.Controls.Add(this.btnEdit);
            this.grpItem.Controls.Add(this.btnDel);
            this.grpItem.Controls.Add(this.lIotherF);
            this.grpItem.Controls.Add(this.tIotherF);
            this.grpItem.Controls.Add(this.not);
            this.grpItem.Controls.Add(this.btnOK);
            this.grpItem.Controls.Add(this.btnCancel);
            this.grpItem.Controls.Add(this.btnOKnSave);
            this.grpItem.Controls.Add(this.tIf1);
            this.grpItem.Controls.Add(this.tINotes);
            this.grpItem.Controls.Add(this.lif2);
            this.grpItem.Controls.Add(this.tIf2);
            this.grpItem.Controls.Add(this.lif1);
            this.grpItem.Controls.Add(this.ll);
            this.grpItem.Controls.Add(this.tIName);
            this.grpItem.Controls.Add(this.label3);
            this.grpItem.Controls.Add(this.label47);
            this.grpItem.Controls.Add(this.tIdim);
            this.grpItem.Controls.Add(this.label48);
            this.grpItem.Controls.Add(this.tIModel);
            this.grpItem.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpItem.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpItem.Location = new System.Drawing.Point(0, 0);
            this.grpItem.Name = "grpItem";
            this.grpItem.Size = new System.Drawing.Size(1021, 208);
            this.grpItem.TabIndex = 125;
            this.grpItem.TabStop = false;
            this.grpItem.Enter += new System.EventHandler(this.grpItem_Enter_1);
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(776, 152);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(40, 40);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 169;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Visible = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // label57
            // 
            this.label57.BackColor = System.Drawing.SystemColors.Control;
            this.label57.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label57.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label57.Location = new System.Drawing.Point(408, 180);
            this.label57.Name = "label57";
            this.label57.Size = new System.Drawing.Size(48, 16);
            this.label57.TabIndex = 168;
            this.label57.Text = "Currency:";
            this.label57.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox9
            // 
            this.groupBox9.Controls.Add(this.opEuro);
            this.groupBox9.Controls.Add(this.opUS);
            this.groupBox9.Controls.Add(this.opCan);
            this.groupBox9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox9.ForeColor = System.Drawing.Color.Red;
            this.groupBox9.Location = new System.Drawing.Point(456, 168);
            this.groupBox9.Name = "groupBox9";
            this.groupBox9.Size = new System.Drawing.Size(208, 32);
            this.groupBox9.TabIndex = 167;
            this.groupBox9.TabStop = false;
            // 
            // opEuro
            // 
            this.opEuro.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opEuro.ForeColor = System.Drawing.Color.DarkRed;
            this.opEuro.Location = new System.Drawing.Point(136, 10);
            this.opEuro.Name = "opEuro";
            this.opEuro.Size = new System.Drawing.Size(64, 16);
            this.opEuro.TabIndex = 108;
            this.opEuro.Text = "EURO €";
            this.opEuro.CheckedChanged += new System.EventHandler(this.opEuro_CheckedChanged);
            // 
            // opUS
            // 
            this.opUS.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opUS.ForeColor = System.Drawing.Color.DarkRed;
            this.opUS.Location = new System.Drawing.Point(80, 10);
            this.opUS.Name = "opUS";
            this.opUS.Size = new System.Drawing.Size(56, 16);
            this.opUS.TabIndex = 107;
            this.opUS.Text = "US $";
            this.opUS.CheckedChanged += new System.EventHandler(this.opUS_CheckedChanged);
            // 
            // opCan
            // 
            this.opCan.Checked = true;
            this.opCan.Font = new System.Drawing.Font("Palatino Linotype", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.opCan.ForeColor = System.Drawing.Color.DarkRed;
            this.opCan.Location = new System.Drawing.Point(8, 8);
            this.opCan.Name = "opCan";
            this.opCan.Size = new System.Drawing.Size(64, 20);
            this.opCan.TabIndex = 106;
            this.opCan.TabStop = true;
            this.opCan.Text = "CDN $";
            this.opCan.CheckedChanged += new System.EventHandler(this.opCan_CheckedChanged);
            // 
            // label52
            // 
            this.label52.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label52.ForeColor = System.Drawing.Color.Red;
            this.label52.Location = new System.Drawing.Point(16, 40);
            this.label52.Name = "label52";
            this.label52.Size = new System.Drawing.Size(9, 12);
            this.label52.TabIndex = 166;
            this.label52.Text = "*";
            this.label52.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(872, 152);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(40, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 165;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            this.pictureBox2.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox2_MouseDown);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(824, 152);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 164;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            // 
            // picSeek
            // 
            this.picSeek.BackColor = System.Drawing.Color.Transparent;
            this.picSeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSeek.Image = ((System.Drawing.Image)(resources.GetObject("picSeek.Image")));
            this.picSeek.Location = new System.Drawing.Point(712, 152);
            this.picSeek.Name = "picSeek";
            this.picSeek.Size = new System.Drawing.Size(48, 40);
            this.picSeek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSeek.TabIndex = 163;
            this.picSeek.TabStop = false;
            this.picSeek.Click += new System.EventHandler(this.picSeek_Click);
            this.picSeek.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picSeek_MouseDown);
            // 
            // btnClear
            // 
            this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnClear.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnClear.Location = new System.Drawing.Point(864, 128);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(48, 20);
            this.btnClear.TabIndex = 162;
            this.btnClear.Text = "Clear";
            this.btnClear.Visible = false;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // chkD
            // 
            this.chkD.Checked = true;
            this.chkD.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkD.Location = new System.Drawing.Point(328, 82);
            this.chkD.Name = "chkD";
            this.chkD.Size = new System.Drawing.Size(40, 16);
            this.chkD.TabIndex = 161;
            // 
            // chkM
            // 
            this.chkM.Checked = true;
            this.chkM.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkM.Location = new System.Drawing.Point(328, 62);
            this.chkM.Name = "chkM";
            this.chkM.Size = new System.Drawing.Size(40, 16);
            this.chkM.TabIndex = 160;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lcurDol);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.chkAuto);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.tIExt);
            this.groupBox1.Controls.Add(this.label34);
            this.groupBox1.Controls.Add(this.tILT);
            this.groupBox1.Controls.Add(this.label36);
            this.groupBox1.Controls.Add(this.tSMRK);
            this.groupBox1.Controls.Add(this.label38);
            this.groupBox1.Controls.Add(this.tIQty);
            this.groupBox1.Controls.Add(this.label42);
            this.groupBox1.Controls.Add(this.tIPU);
            this.groupBox1.Location = new System.Drawing.Point(8, 140);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(392, 60);
            this.groupBox1.TabIndex = 159;
            this.groupBox1.TabStop = false;
            // 
            // lcurDol
            // 
            this.lcurDol.BackColor = System.Drawing.SystemColors.Control;
            this.lcurDol.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lcurDol.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcurDol.ForeColor = System.Drawing.Color.ForestGreen;
            this.lcurDol.Location = new System.Drawing.Point(56, 14);
            this.lcurDol.Name = "lcurDol";
            this.lcurDol.Size = new System.Drawing.Size(64, 16);
            this.lcurDol.TabIndex = 170;
            this.lcurDol.Text = "CDN $";
            this.lcurDol.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(240, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(9, 12);
            this.label1.TabIndex = 165;
            this.label1.Text = "*";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkAuto
            // 
            this.chkAuto.Checked = true;
            this.chkAuto.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkAuto.Location = new System.Drawing.Point(408, 16);
            this.chkAuto.Name = "chkAuto";
            this.chkAuto.Size = new System.Drawing.Size(72, 32);
            this.chkAuto.TabIndex = 164;
            this.chkAuto.Text = "Auto Sell  Price";
            this.chkAuto.Visible = false;
            this.chkAuto.CheckedChanged += new System.EventHandler(this.chkAuto_CheckedChanged);
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(248, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 16);
            this.label4.TabIndex = 161;
            this.label4.Text = "Sell Price";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tIExt
            // 
            this.tIExt.BackColor = System.Drawing.Color.Lavender;
            this.tIExt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIExt.ForeColor = System.Drawing.Color.Red;
            this.tIExt.Location = new System.Drawing.Point(212, 30);
            this.tIExt.MaxLength = 49;
            this.tIExt.Name = "tIExt";
            this.tIExt.ReadOnly = true;
            this.tIExt.Size = new System.Drawing.Size(128, 20);
            this.tIExt.TabIndex = 160;
            this.tIExt.Text = "0";
            this.tIExt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tIExt.TextChanged += new System.EventHandler(this.tIExt_TextChanged);
            this.tIExt.DoubleClick += new System.EventHandler(this.tIExt_DoubleClick);
            // 
            // label34
            // 
            this.label34.BackColor = System.Drawing.SystemColors.Control;
            this.label34.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(332, 14);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(56, 16);
            this.label34.TabIndex = 159;
            this.label34.Text = "Lead Time:";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tILT
            // 
            this.tILT.BackColor = System.Drawing.Color.Lavender;
            this.tILT.ForeColor = System.Drawing.Color.Red;
            this.tILT.Location = new System.Drawing.Point(340, 30);
            this.tILT.MaxLength = 49;
            this.tILT.Name = "tILT";
            this.tILT.Size = new System.Drawing.Size(44, 20);
            this.tILT.TabIndex = 154;
            this.tILT.Text = "04-06";
            this.tILT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tILT.TextChanged += new System.EventHandler(this.tILT_TextChanged_1);
            // 
            // label36
            // 
            this.label36.BackColor = System.Drawing.SystemColors.Control;
            this.label36.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label36.Location = new System.Drawing.Point(156, 14);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(64, 16);
            this.label36.TabIndex = 158;
            this.label36.Text = "Sell Markup";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tSMRK
            // 
            this.tSMRK.BackColor = System.Drawing.Color.Lavender;
            this.tSMRK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tSMRK.ForeColor = System.Drawing.Color.Red;
            this.tSMRK.Location = new System.Drawing.Point(156, 30);
            this.tSMRK.MaxLength = 49;
            this.tSMRK.Name = "tSMRK";
            this.tSMRK.Size = new System.Drawing.Size(56, 20);
            this.tSMRK.TabIndex = 157;
            this.tSMRK.Text = "1";
            this.tSMRK.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tSMRK.TextChanged += new System.EventHandler(this.tSMRK_TextChanged);
            // 
            // label38
            // 
            this.label38.BackColor = System.Drawing.SystemColors.Control;
            this.label38.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label38.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label38.Location = new System.Drawing.Point(120, 14);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(24, 16);
            this.label38.TabIndex = 156;
            this.label38.Text = "Qty";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tIQty
            // 
            this.tIQty.BackColor = System.Drawing.Color.Lavender;
            this.tIQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIQty.ForeColor = System.Drawing.Color.Red;
            this.tIQty.Location = new System.Drawing.Point(100, 30);
            this.tIQty.MaxLength = 49;
            this.tIQty.Name = "tIQty";
            this.tIQty.Size = new System.Drawing.Size(56, 20);
            this.tIQty.TabIndex = 153;
            this.tIQty.Text = "1";
            this.tIQty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tIQty.TextChanged += new System.EventHandler(this.tIQty_TextChanged);
            // 
            // label42
            // 
            this.label42.BackColor = System.Drawing.SystemColors.Control;
            this.label42.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label42.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label42.Location = new System.Drawing.Point(8, 14);
            this.label42.Name = "label42";
            this.label42.Size = new System.Drawing.Size(48, 16);
            this.label42.TabIndex = 155;
            this.label42.Text = "Unit Cost/";
            this.label42.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tIPU
            // 
            this.tIPU.BackColor = System.Drawing.Color.Lavender;
            this.tIPU.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tIPU.ForeColor = System.Drawing.Color.Red;
            this.tIPU.Location = new System.Drawing.Point(12, 30);
            this.tIPU.MaxLength = 49;
            this.tIPU.Name = "tIPU";
            this.tIPU.Size = new System.Drawing.Size(88, 20);
            this.tIPU.TabIndex = 152;
            this.tIPU.Text = "0";
            this.tIPU.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tIPU.TextChanged += new System.EventHandler(this.tIPU_TextChanged);
            // 
            // checkBox1
            // 
            this.checkBox1.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.checkBox1.Checked = true;
            this.checkBox1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBox1.Location = new System.Drawing.Point(416, 60);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(40, 16);
            this.checkBox1.TabIndex = 158;
            this.checkBox1.Tag = "";
            this.checkBox1.Text = "#3";
            // 
            // chk2
            // 
            this.chk2.Checked = true;
            this.chk2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk2.Location = new System.Drawing.Point(328, 122);
            this.chk2.Name = "chk2";
            this.chk2.Size = new System.Drawing.Size(40, 16);
            this.chk2.TabIndex = 157;
            this.chk2.Text = "#2";
            // 
            // chk1
            // 
            this.chk1.Checked = true;
            this.chk1.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chk1.Location = new System.Drawing.Point(328, 102);
            this.chk1.Name = "chk1";
            this.chk1.Size = new System.Drawing.Size(40, 16);
            this.chk1.TabIndex = 156;
            this.chk1.Text = "#1";
            // 
            // btnEdit
            // 
            this.btnEdit.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnEdit.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEdit.Location = new System.Drawing.Point(741, 16);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(115, 20);
            this.btnEdit.TabIndex = 153;
            this.btnEdit.Text = "import 1/1";
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // btnDel
            // 
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(920, 128);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(48, 20);
            this.btnDel.TabIndex = 152;
            this.btnDel.Text = "Delete";
            this.btnDel.Visible = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lIotherF
            // 
            this.lIotherF.BackColor = System.Drawing.Color.Lavender;
            this.lIotherF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lIotherF.Location = new System.Drawing.Point(368, 40);
            this.lIotherF.MaxLength = 49;
            this.lIotherF.Name = "lIotherF";
            this.lIotherF.Size = new System.Drawing.Size(88, 20);
            this.lIotherF.TabIndex = 148;
            // 
            // tIotherF
            // 
            this.tIotherF.BackColor = System.Drawing.Color.Lavender;
            this.tIotherF.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tIotherF.Location = new System.Drawing.Point(456, 40);
            this.tIotherF.MaxLength = 1000;
            this.tIotherF.Multiline = true;
            this.tIotherF.Name = "tIotherF";
            this.tIotherF.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tIotherF.Size = new System.Drawing.Size(344, 80);
            this.tIotherF.TabIndex = 145;
            this.tIotherF.TextChanged += new System.EventHandler(this.tIotherF_TextChanged);
            // 
            // not
            // 
            this.not.BackColor = System.Drawing.SystemColors.Control;
            this.not.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.not.ForeColor = System.Drawing.SystemColors.ControlText;
            this.not.Location = new System.Drawing.Point(424, 136);
            this.not.Name = "not";
            this.not.Size = new System.Drawing.Size(32, 16);
            this.not.TabIndex = 144;
            this.not.Text = "Notes:";
            this.not.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(808, 48);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(96, 24);
            this.btnOK.TabIndex = 143;
            this.btnOK.Text = "OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(808, 80);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 142;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOKnSave
            // 
            this.btnOKnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOKnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOKnSave.Location = new System.Drawing.Point(808, 128);
            this.btnOKnSave.Name = "btnOKnSave";
            this.btnOKnSave.Size = new System.Drawing.Size(48, 20);
            this.btnOKnSave.TabIndex = 9;
            this.btnOKnSave.Text = "Save";
            this.btnOKnSave.Visible = false;
            this.btnOKnSave.Click += new System.EventHandler(this.btnOKnSave_Click);
            // 
            // tIf1
            // 
            this.tIf1.BackColor = System.Drawing.Color.Lavender;
            this.tIf1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tIf1.Location = new System.Drawing.Point(80, 100);
            this.tIf1.MaxLength = 49;
            this.tIf1.Name = "tIf1";
            this.tIf1.Size = new System.Drawing.Size(248, 20);
            this.tIf1.TabIndex = 3;
            // 
            // tINotes
            // 
            this.tINotes.BackColor = System.Drawing.Color.Lavender;
            this.tINotes.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tINotes.Location = new System.Drawing.Point(456, 120);
            this.tINotes.MaxLength = 49;
            this.tINotes.Multiline = true;
            this.tINotes.Name = "tINotes";
            this.tINotes.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tINotes.Size = new System.Drawing.Size(256, 48);
            this.tINotes.TabIndex = 8;
            this.tINotes.TextChanged += new System.EventHandler(this.tINotes_TextChanged);
            // 
            // lif2
            // 
            this.lif2.BackColor = System.Drawing.Color.Lavender;
            this.lif2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lif2.Location = new System.Drawing.Point(8, 120);
            this.lif2.MaxLength = 49;
            this.lif2.Name = "lif2";
            this.lif2.Size = new System.Drawing.Size(72, 20);
            this.lif2.TabIndex = 134;
            // 
            // tIf2
            // 
            this.tIf2.BackColor = System.Drawing.Color.Lavender;
            this.tIf2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tIf2.Location = new System.Drawing.Point(80, 120);
            this.tIf2.MaxLength = 49;
            this.tIf2.Name = "tIf2";
            this.tIf2.Size = new System.Drawing.Size(248, 20);
            this.tIf2.TabIndex = 4;
            // 
            // lif1
            // 
            this.lif1.BackColor = System.Drawing.Color.Lavender;
            this.lif1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lif1.Location = new System.Drawing.Point(8, 100);
            this.lif1.MaxLength = 49;
            this.lif1.Name = "lif1";
            this.lif1.Size = new System.Drawing.Size(72, 20);
            this.lif1.TabIndex = 132;
            // 
            // ll
            // 
            this.ll.BackColor = System.Drawing.SystemColors.Control;
            this.ll.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.ll.ForeColor = System.Drawing.SystemColors.ControlText;
            this.ll.Location = new System.Drawing.Point(24, 40);
            this.ll.Name = "ll";
            this.ll.Size = new System.Drawing.Size(56, 16);
            this.ll.TabIndex = 128;
            this.ll.Text = "Item Name:";
            this.ll.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tIName
            // 
            this.tIName.BackColor = System.Drawing.Color.Lavender;
            this.tIName.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tIName.Location = new System.Drawing.Point(80, 40);
            this.tIName.MaxLength = 49;
            this.tIName.Name = "tIName";
            this.tIName.Size = new System.Drawing.Size(248, 20);
            this.tIName.TabIndex = 0;
            this.tIName.TextChanged += new System.EventHandler(this.tIName_TextChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Comic Sans MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Blue;
            this.label3.Location = new System.Drawing.Point(8, 8);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(904, 32);
            this.label3.TabIndex = 126;
            this.label3.Text = "BUY &&  RESELL ITEM / OPTION";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label47
            // 
            this.label47.BackColor = System.Drawing.SystemColors.Control;
            this.label47.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label47.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label47.Location = new System.Drawing.Point(24, 80);
            this.label47.Name = "label47";
            this.label47.Size = new System.Drawing.Size(56, 16);
            this.label47.TabIndex = 98;
            this.label47.Text = "Dimensions:";
            this.label47.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tIdim
            // 
            this.tIdim.BackColor = System.Drawing.Color.Lavender;
            this.tIdim.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tIdim.Location = new System.Drawing.Point(80, 80);
            this.tIdim.MaxLength = 49;
            this.tIdim.Name = "tIdim";
            this.tIdim.Size = new System.Drawing.Size(248, 20);
            this.tIdim.TabIndex = 2;
            // 
            // label48
            // 
            this.label48.BackColor = System.Drawing.SystemColors.Control;
            this.label48.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label48.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label48.Location = new System.Drawing.Point(24, 62);
            this.label48.Name = "label48";
            this.label48.Size = new System.Drawing.Size(56, 16);
            this.label48.TabIndex = 96;
            this.label48.Text = "Model :";
            this.label48.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tIModel
            // 
            this.tIModel.BackColor = System.Drawing.Color.Lavender;
            this.tIModel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tIModel.Location = new System.Drawing.Point(80, 60);
            this.tIModel.MaxLength = 49;
            this.tIModel.Name = "tIModel";
            this.tIModel.Size = new System.Drawing.Size(248, 20);
            this.tIModel.TabIndex = 1;
            // 
            // lvNLIO
            // 
            this.lvNLIO.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvNLIO.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.IOName,
            this.Model,
            this.Dim,
            this.F1,
            this.F2,
            this.OFt,
            this.qTTY,
            this.UP,
            this.Mult,
            this.Sprice,
            this.LT,
            this.note,
            this.usr,
            this.QID,
            this.LID});
            this.lvNLIO.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvNLIO.ForeColor = System.Drawing.Color.Blue;
            this.lvNLIO.FullRowSelect = true;
            this.lvNLIO.GridLines = true;
            this.lvNLIO.Location = new System.Drawing.Point(0, 208);
            this.lvNLIO.MultiSelect = false;
            this.lvNLIO.Name = "lvNLIO";
            this.lvNLIO.Size = new System.Drawing.Size(1021, 357);
            this.lvNLIO.TabIndex = 126;
            this.lvNLIO.UseCompatibleStateImageBehavior = false;
            this.lvNLIO.View = System.Windows.Forms.View.Details;
            this.lvNLIO.SelectedIndexChanged += new System.EventHandler(this.lvNLIO_SelectedIndexChanged_1);
            this.lvNLIO.DoubleClick += new System.EventHandler(this.lvNLIO_DoubleClick);
            // 
            // IOName
            // 
            this.IOName.Text = "Item/Option Name";
            this.IOName.Width = 194;
            // 
            // Model
            // 
            this.Model.Text = "Model";
            this.Model.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Model.Width = 123;
            // 
            // Dim
            // 
            this.Dim.Text = "Dimensions";
            this.Dim.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Dim.Width = 73;
            // 
            // F1
            // 
            this.F1.Text = "#1";
            this.F1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.F1.Width = 55;
            // 
            // F2
            // 
            this.F2.Text = "#2";
            this.F2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.F2.Width = 49;
            // 
            // OFt
            // 
            this.OFt.Text = "#3";
            this.OFt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.OFt.Width = 57;
            // 
            // qTTY
            // 
            this.qTTY.Text = "QTY";
            this.qTTY.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.qTTY.Width = 37;
            // 
            // UP
            // 
            this.UP.Text = "Unit Cost";
            this.UP.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // Mult
            // 
            this.Mult.Text = "Markup";
            this.Mult.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Mult.Width = 62;
            // 
            // Sprice
            // 
            this.Sprice.Text = "Sell Price";
            this.Sprice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // LT
            // 
            this.LT.Text = "Lead time";
            this.LT.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // note
            // 
            this.note.Text = "Notes";
            this.note.Width = 77;
            // 
            // usr
            // 
            this.usr.Text = "User";
            this.usr.Width = 89;
            // 
            // QID
            // 
            this.QID.Text = "Quote #";
            this.QID.Width = 0;
            // 
            // LID
            // 
            this.LID.Text = "";
            this.LID.Width = 0;
            // 
            // NL_Item_Option
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1021, 565);
            this.Controls.Add(this.lvNLIO);
            this.Controls.Add(this.grpItem);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "NL_Item_Option";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "NL_Item_Option";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.NL_Item_Option_Load);
            this.grpItem.ResumeLayout(false);
            this.grpItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.groupBox9.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void label38_Click(object sender, System.EventArgs e)
		{
		
		}

		private void tIQty_TextChanged(object sender, System.EventArgs e)
		{
			calIOExt();
		}
		private void calIOExt()
		{
			if (chkAuto.Checked )
			{   
				tIExt.ReadOnly =true; 
				if (tIPU.Text != "" && tIQty.Text !="")
				{												 
					double dPU=Tools.Conv_Dbl(tIPU.Text  ) ;
					double dQty=Tools.Conv_Dbl(tIQty.Text ) ;
					tSMRK.Text="";
					if (tSMRK.Text =="") tIExt.Text= Cal_SellPrice(dPU *  dQty ).ToString () ; 
					else tIExt.Text= Convert.ToString ( Math.Round(dPU *  dQty * Tools.Conv_Dbl(tSMRK.Text),MainMDI.NB_DEC_AFF) ); 
				}
			}
			  
	
			  
		}



		private string Cal_SellPrice(double ext)
		{
			if ( ext >0)
			{
				string stSql = "SELECT * FROM PSM_SMarkup where  " + ext + " <= Hlim and " + ext + " >= Llim ORDER BY Hlim ";
				SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
				OConn.Open ();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql ;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
				while (Oreadr.Read ()) 
				{
					tSMRK.Text =Oreadr["MRKPCA"].ToString();
					return  Convert.ToString(Math.Round (Tools.Conv_Dbl(Oreadr["MRKPCA"].ToString()) * ext,MainMDI.NB_DEC_AFF));
			    
				}
				OConn.Close(); 
				tSMRK.Text="0";
			}
			return "0";
		}


	
		private void tIPU_TextChanged(object sender, System.EventArgs e)
		{
			calIOExt();
		
		}

		private void grpItem_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void NL_Item_Option_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!"; 
		}


		private void lvNLIO_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			//MessageBox.Show (   e.Column.ToString()  );

			ListView myListView = (ListView)sender;

			// Determine if clicked column is already the column that is being sorted.
			if ( e.Column == lvSorter.SortColumn )
			{
				// Reverse the current sort direction for this column.
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
				// Set the column number that is to be sorted; default to ascending.
				lvSorter.SortColumn = e.Column;
				lvSorter.Order = System.Windows.Forms.SortOrder.Ascending;
			}

			// Perform the sort with these new sort options.
			myListView.Sort();



		}
		public void fill_lvNLIO()
		{ 

	
			lvNLIO.Items.Clear();  
			string stSql = "SELECT * FROM PSM_NLItemOption  ORDER BY IOName";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
         lvNLIO.BeginUpdate();
			while (Oreadr.Read ())
			{
				
				ListViewItem lvI= lvNLIO.Items.Add( Oreadr["IOName"].ToString () );
				lvI.SubItems.Add( Oreadr["Model"].ToString()  ); 
				lvI.SubItems.Add( Oreadr["dim"].ToString()); 
				lvI.SubItems.Add( Oreadr["feat1"].ToString()); 
				lvI.SubItems.Add( Oreadr["feat2"].ToString()); 
				lvI.SubItems.Add( Oreadr["featO"].ToString()); 
				lvI.SubItems.Add( Oreadr["QTY"].ToString()); 
				lvI.SubItems.Add( Oreadr["UP"].ToString()); 
				                                               ///if (Oreadr["UP"].ToString() != "" && Oreadr["QTY"].ToString() != "")  st = "$" + Convert.ToString(Math.Round (Tools.Conv_Dbl(Oreadr["UP"].ToString() ) *  Tools.Conv_Dbl(Oreadr["QTY"].ToString() ),MainMDI.NB_DEC_AFF ));  
				lvI.SubItems.Add( Oreadr["Mult"].ToString()); 
				lvI.SubItems.Add( Oreadr["SelPrice"].ToString()); 
				lvI.SubItems.Add( Oreadr["LT"].ToString()); 
				lvI.SubItems.Add( Oreadr["notes"].ToString()); 
				lvI.SubItems.Add(Oreadr["userName"].ToString() ); 
				lvI.SubItems.Add(Oreadr["QID"].ToString() ); 
				lvI.SubItems.Add(Oreadr["IOLID"].ToString() ); 

			
			}
            lvNLIO.EndUpdate(); 

		}

		private void lvNLIO_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
		}

		private void lvNLIO_ColumnClickpp(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
		
		}

		private void btnOKnSave_Click(object sender, System.EventArgs e)
		{
		//	MessageBox.Show (tIotherF.Text + " pos= " + tIotherF.Text.IndexOf('\n',0).ToString()   ); 
			
			if (sav_info()) 
			{
				fill_lvNLIO();
				btnOKnSave.Text ="Save";
				init_scr();
				picSeek.Enabled =false;
			}

		
		}
		private void init_scr()
		{
			tIPU.Text ="1";
			tIName.Clear();
			tIModel.Clear ();
			tIQty.Text ="1";
			tINotes.Clear();
			tIf1.Clear ();
			tIf2.Clear ();
			tILT.Text ="04-06";
			tIExt.Text ="0";
			lif1.Clear ();
			lif2.Clear ();
			lIotherF.Clear();
			tIotherF.Clear();
			tINotes.Clear ();
			tIdim.Clear();
			tSMRK.Text ="1";
		}

		private bool IO_InfoValid()
		{

		//	if (tIName.Text !="" && tIPU.Text !="" && chkAuto.Checked  ) return true;
			
			return (tIName.Text !="" && tIExt.Text !="");
		}

		private bool sav_info()
		{
			string stf1="", stf2="",stSql="";
			if (IO_InfoValid() )
			{
				
				if (lif1.Text !="" && tIf1.Text !="") stf1 = lif1.Text + ": " + tIf1.Text;
				if (lif2.Text !="" && tIf2.Text !="") stf2 = lif2.Text + ": " + tIf2.Text;
				string st=tIotherF.Text.Replace("'","''" ); 
				if (st != "" )
				{
					//	for (int i=0;i<st.Length ;i++) if (st[i]=='\n') st[i]='~';
					//if (lIotherF.Text !="") 
					st =  lIotherF.Text + ": " + st;
				}
				tINotes.Text = lcurDol.Text[0] + tINotes.Text;  
				if (btnOKnSave.Text =="Save")
				{
					stSql= "INSERT INTO PSM_NLItemOption ([IOName],[Model],[DIM], " + 
						" [feat1],[feat2], " + 
						" [featO], " + 
						" [Qty],[UP], " + 
						" [Mult],[SelPrice], " + 
						" [LT], " + 
						" [notes],[UserName], " + 
						" [QID]) VALUES ('" +
						tIName.Text + "', '" +
						tIModel.Text  + "', '" +
						tIdim.Text  + "', '" +
						stf1  + "', '" +
						stf2 + "', '" +
						st  + "', " +
						tIQty.Text + ", " +
						tIPU.Text + ", " +
						tSMRK.Text + ", " +
						tIExt.Text + ", '" +
						tILT.Text + "', '" +
						tINotes.Text + "', '" +
						MainMDI.User + "', '" +
						In_QID.ToString()   + "')";
					picSeek.Enabled =false;

				}
					    
				else 
					stSql= "Update PSM_NLItemOption SET [IOName]='"+tIName.Text + "', " +
						"[Model]='" +tIModel.Text  + "', " +
						"[DIM]='" + tIdim.Text + "', " +
						"[feat1]='" +stf1  + "', " +
						"[feat2]='" +stf2   + "', " +
						"[featO]='" +st   + "', " +
						"[Qty]=" +tIQty.Text   + ", " +
						"[UP]=" + tIPU.Text   + ", " +
						"[Mult]=" + tSMRK.Text   + ", " +
						"[SelPrice]=" + tIExt.Text  + ", " +
						"[LT]='" + tILT.Text  + "', " +
						"[notes]='" +tINotes.Text + "', " +
						"[UserName]='" +MainMDI.User  + "', " +
										"[QID]=" + In_QID.ToString() + " where IOLID=" + lvNLIO.SelectedItems[0].SubItems[14].Text ; 
//						"[QID]=" + In_QID.ToString() + " where IOLID=" + lvNLIO.SelectedItems[0].SubItems[14].Text ; 
			
				MainMDI.ExecSql(stSql);
				MainMDI.Write_JFS(stSql );
				//	if ( MainMDI.ExecSql(stSql)==true  ) MessageBox.Show("Error Occurs while Saving this Quote...contact your Admin !!!" + MainMDI.stXP  ); 
			  if (lvNLIO.SelectedItems.Count ==1)  lvNLIO.SelectedItems[0].BackColor =Color.WhiteSmoke ;
			}
		    else
			{
				MessageBox.Show("EMPTY Fields  (Item-Name/Unit-Cost) !!!");
				tIName.Focus();
				return false;
			}

			return true;
		}

		private bool sav_infoWITH_QTY()
		{
			string stf1="", stf2="",stSql="";
			if (IO_InfoValid() )
			{
				
				if (lif1.Text !="" && tIf1.Text !="") stf1 = lif1.Text + ": " + tIf1.Text;
				if (lif2.Text !="" && tIf2.Text !="") stf2 = lif2.Text + ": " + tIf2.Text;
				string st=tIotherF.Text;
				if (st != "" )  st =  lIotherF.Text + ": " + st;
				
					//	for (int i=0;i<st.Length ;i++) if (st[i]=='\n') st[i]='~';
					
					 
				
				if (btnOKnSave.Text =="&Save")
					stSql= "INSERT INTO PSM_NLItemOption ([IOName],[Model],[DIM], " + 
						" [feat1],[feat2], " + 
						" [featO], " + 
						" [UP],[QTY],[LT], " + 
						" [notes],[UserName], " + 
						" [QID]) VALUES ('" +
						tIName.Text + "', '" +
						tIModel.Text  + "', '" +
						tIdim.Text  + "', '" +
						stf1  + "', '" +
						stf2 + "', '" + 
						st  + "', " +
						tIPU.Text + ", " +
						tIQty.Text + ", '" +
						tILT.Text + "', '" +
						tINotes.Text + "', '" +
						MainMDI.User + "', '" +
						In_QID.ToString()   + "')";
				else 
					stSql= "Update PSM_NLItemOption SET [IOName]='"+tIName.Text + "', " +
						"[Model]='" +tIModel.Text  + "', " +
						"[DIM]='" + tIdim.Text + "', " +
						"[feat1]='" +stf1  + "', " +
						"[feat2]='" +stf2   + "', " +
						"[featO]='" +st   + "', " +
						"[UP]='" + tIPU.Text   + "', " +
						"[QTY]=" + tIQty.Text + ", " +
						"[LT]='" + tILT.Text  + "', " +
						"[notes]='" +tINotes.Text + "', " +
						"[UserName]='" +MainMDI.User  + "', " +
						"[QID]=" + In_QID.ToString() + " where IOLID=" + lvNLIO.SelectedItems[0].SubItems[11].Text ; 
			
				MainMDI.ExecSql(stSql);
				MainMDI.Write_JFS(stSql );
				//	if ( MainMDI.ExecSql(stSql)==true  ) MessageBox.Show("Error Occurs while Saving this Quote...contact your Admin !!!" + MainMDI.stXP  ); 
				lvNLIO.SelectedItems[0].BackColor =Color.WhiteSmoke ;
			}
			else
			{
				MessageBox.Show("EMPTY Fields  (Item-Name/Unit-Cost) !!!");
				tIName.Focus();
				return false;
			}
			return true;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if ( tIName.Text !="")  // tIExt.Text !="0" &&
			{
				SaveOK =true;
				this.Hide();
			}
			else 	MessageBox.Show("Item INFO are Invalid !!!!!");

		}

		private void tIPU_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar ); 
		}

		private void tIQty_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar ); 
		}

		private void tILT_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = Tools.OnlyDBL(e.KeyChar ); 
		}

		private void tILT_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			SaveOK =false;
			this.Hide();
		}

		private void lvNLIO_DoubleClick(object sender, System.EventArgs e)
		{
				
			if (lvNLIO.SelectedItems.Count ==1) 	
			{

				picSeek.Enabled =true;
				LVNdx=lvNLIO.SelectedItems[0].Index ;
				lvNLIO.SelectedItems[0].BackColor =Color.Cyan ;
				tIName.Text = lvNLIO.SelectedItems[0].SubItems[0].Text;
				tIModel.Text =lvNLIO.SelectedItems[0].SubItems[1].Text; 
				tIdim.Text =lvNLIO.SelectedItems[0].SubItems[2].Text; 
				int Ipos=lvNLIO.SelectedItems[0].SubItems[3].Text.IndexOf(": ",0);
				if (lvNLIO.SelectedItems[0].SubItems[3].Text!="")
				{
					lif1.Text   =lvNLIO.SelectedItems[0].SubItems[3].Text.Substring(0,Ipos) ; 
					tIf1.Text   =lvNLIO.SelectedItems[0].SubItems[3].Text.Substring(Ipos+2,lvNLIO.SelectedItems[0].SubItems[3].Text.Length - Ipos -2 ) ; 
				}
				Ipos=lvNLIO.SelectedItems[0].SubItems[4].Text.IndexOf(": ",0);
				if (lvNLIO.SelectedItems[0].SubItems[4].Text!="")
				{
					lif2.Text   =lvNLIO.SelectedItems[0].SubItems[4].Text.Substring(0,Ipos) ; 
					tIf2.Text   =lvNLIO.SelectedItems[0].SubItems[4].Text.Substring(Ipos+2,lvNLIO.SelectedItems[0].SubItems[4].Text.Length - Ipos-2 ) ; 
				}
				Ipos=lvNLIO.SelectedItems[0].SubItems[5].Text.IndexOf(": ",0);
				if (lvNLIO.SelectedItems[0].SubItems[5].Text!="")
				{
					lIotherF.Text   =lvNLIO.SelectedItems[0].SubItems[5].Text.Substring(0,Ipos) ; 
					tIotherF.Text   =lvNLIO.SelectedItems[0].SubItems[5].Text.Substring(Ipos+2,lvNLIO.SelectedItems[0].SubItems[5].Text.Length - Ipos-2 ) ; 
				}

				tIQty.Text =lvNLIO.SelectedItems[0].SubItems[6].Text;
				tIPU.Text =lvNLIO.SelectedItems[0].SubItems[7].Text;
				tSMRK.Text =lvNLIO.SelectedItems[0].SubItems[8].Text;
				tIExt.Text =lvNLIO.SelectedItems[0].SubItems[9].Text;
				
				tILT.Text =lvNLIO.SelectedItems[0].SubItems[10].Text;
				if (lvNLIO.SelectedItems[0].SubItems[11].Text.Length >0)
				{
					tINotes.Text =lvNLIO.SelectedItems[0].SubItems[11].Text.Substring(1,lvNLIO.SelectedItems[0].SubItems[11].Text.Length -1) ;
					opCan.Checked =(lvNLIO.SelectedItems[0].SubItems[11].Text[0]=='C');
					opUS.Checked =(lvNLIO.SelectedItems[0].SubItems[11].Text[0]=='U');
					opEuro.Checked =(lvNLIO.SelectedItems[0].SubItems[11].Text[0]=='E');   
				}
				else opCan.Checked =true;
				btnOKnSave.Text ="Update"; 
				lvNLIO.Enabled =false; 
				 

			}

		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{

            string stSql = "SELECT * FROM s_byNresell_import order by yy ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                tIName.Text = Oreadr["Item_name"].ToString();
                tIModel.Text = Oreadr["Model"].ToString();
                tIdim.Text = Oreadr["dimensions"].ToString();
                lif1.Text = "Description1"; tIf1.Text = Oreadr["d1"].ToString();
                lif2.Text = "Description2"; tIf2.Text = Oreadr["d2"].ToString();
                lIotherF.Text = "";
                tIQty.Text = Oreadr["qty"].ToString();
                tIPU.Text = Oreadr["unit_cost"].ToString();
                tSMRK.Text = Oreadr["Mark_up"].ToString();
                tIExt.Text = Oreadr["sell_price"].ToString();
                tILT.Text = Oreadr["lead_time"].ToString();
                MessageBox.Show("Continue...........");
                picSeek_Click(sender, e);


            }
            OConn.Close(); 

                     


		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			if (lvNLIO.SelectedItems.Count ==1)
			{
				string stSql= "delete PSM_NLItemOption where IOLID= " + lvNLIO.SelectedItems[0].SubItems[14].Text ; 
				MainMDI.ExecSql(stSql);
				lvNLIO.Items[lvNLIO.SelectedItems[0].Index ].Remove(); 
			}
		//	else MessageBox.Show("Please select ONE(1) RECORD !!!"); 
		}

		private void tINotes_TextChanged(object sender, System.EventArgs e)
		{
		
		}

	

		private void tSMRK_TextChanged(object sender, System.EventArgs e)
		{
			if (chkAuto.Checked )
			{
				double dPU=Tools.Conv_Dbl(tIPU.Text  ) ;
				double dQty=Tools.Conv_Dbl(tIQty.Text ) ;
				tIExt.Text= Convert.ToString ( Math.Round(dPU *  dQty * Tools.Conv_Dbl(tSMRK.Text),MainMDI.NB_DEC_AFF) ); 
			}
		  }

		private void lvNLIO_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
		
		}

		private void grpItem_Enter_1(object sender, System.EventArgs e)
		{
		
		}

	

		private void btnClear_Click(object sender, System.EventArgs e)
		{
			init_scr();
			btnOKnSave.Text ="Save";
			if (lvNLIO.SelectedItems.Count  ==1) lvNLIO.SelectedItems[0].BackColor =Color.WhiteSmoke ;
		
		}

		private void chkAuto_CheckedChanged(object sender, System.EventArgs e)
		{
			//tIExt.ReadOnly = chkAuto.Checked ; 
			//tIPU.Text =  tIPU.Text
			tSMRK.ReadOnly = chkAuto.Checked ;
		}

		private void tIExt_TextChanged(object sender, System.EventArgs e)
		{
			if (!picSeek.Enabled) picSeek.Enabled =true;
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
			init_scr();
			btnOKnSave.Text ="Save";
			picSeek.Enabled =true;
			if (lvNLIO.SelectedItems.Count  ==1) lvNLIO.SelectedItems[0].BackColor =Color.WhiteSmoke ;
			lvNLIO.Enabled =true;
			pictureBox1.BorderStyle = BorderStyle.None ;
		
		}

		private void picSeek_Click(object sender, System.EventArgs e)
		{ 
			//if (!tIExt.ReadOnly) { tIPU.Text =tIExt.Text ;tIQty.Text =1  ;
			tIExt.ReadOnly =true;
			tIExt.Text = Tools.Conv_Dbl(tIExt.Text ).ToString() ;  
			if (sav_info()) 
			{
				//pictureBox1_Click(sender,e); 
				fill_lvNLIO();
				lvNLIO.Enabled =true; 
				//btnOKnSave.Text ="Save";
				//init_scr();
             
			}

			 picSeek.BorderStyle = BorderStyle.None  ; 
		}

		private void pictureBox2_Click(object sender, System.EventArgs e)
		{
			if (lvNLIO.SelectedItems.Count ==1 && MainMDI.Confirm("Delete this Item ?  '" + lvNLIO.SelectedItems[0].SubItems[0].Text +"'" )  )
			{
				string stSql= "delete PSM_NLItemOption where IOLID= " + lvNLIO.SelectedItems[0].SubItems[14].Text ; 
				MainMDI.ExecSql(stSql);
				lvNLIO.Items[lvNLIO.SelectedItems[0].Index ].Remove(); 
			}
			 pictureBox2.BorderStyle = BorderStyle.None ;
		}

		private void opCan_CheckedChanged(object sender, System.EventArgs e)
		{
			lcurDol.Text ="CDN $ ";
		}

		private void opUS_CheckedChanged(object sender, System.EventArgs e)
		{
			lcurDol.Text ="USD $ ";
		}

		private void opEuro_CheckedChanged(object sender, System.EventArgs e)
		{
			lcurDol.Text ="EURO € ";
		}

		private void tIotherF_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tIExt_DoubleClick(object sender, System.EventArgs e)
		{
			tIExt.ReadOnly =false;
		}

		private void picSeek_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		   picSeek.BorderStyle = BorderStyle.Fixed3D   ; 
		}

		private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
		   pictureBox1.BorderStyle = BorderStyle.Fixed3D   ; 
		}

	

		private void tILT_TextChanged_1(object sender, System.EventArgs e)
		{
		
		}

		private void pictureBox2_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			 pictureBox2.BorderStyle = BorderStyle.Fixed3D   ; 
		}

		private void tIName_TextChanged(object sender, System.EventArgs e)
		{
			if (!picSeek.Enabled) picSeek.Enabled =true;
		}

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }


	

	

	
	
	









	}
}
