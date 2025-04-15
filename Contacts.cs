using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Diagnostics;
namespace PGESCOM
{
	/// <summary>
	/// Summary description for Company.
	/// </summary>
	public class Contacts: System.Windows.Forms.Form
	{
        private string In_stID;
        //private string MainMDI._connectionString;
		private char In_Opera;
		private char in_c;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox cbPrefx;
		public System.Windows.Forms.TextBox tEmail;
		private System.Windows.Forms.Label label19;
		public System.Windows.Forms.TextBox tFax;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label14;
		public System.Windows.Forms.TextBox tFname;
		public System.Windows.Forms.TextBox tLname;
		public System.Windows.Forms.TextBox tdepart;
		public System.Windows.Forms.TextBox tCell;
		public System.Windows.Forms.TextBox tpager;
		public System.Windows.Forms.TextBox tCatalog;
		public System.Windows.Forms.TextBox tsufx;
		public System.Windows.Forms.TextBox TTExt;
		public System.Windows.Forms.TextBox tTel2;
		private System.Windows.Forms.Label label15;
		public System.Windows.Forms.TextBox TText2;
		private System.Windows.Forms.Label label16;
		private System.Windows.Forms.TextBox lMainAdrs;
		private System.Windows.Forms.Button btnAdrs;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.TextBox tcpny;
		private System.Windows.Forms.TextBox tWeb;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.Label lprefID;
		public System.Windows.Forms.Label lsave;
		public System.Windows.Forms.Label lcpnyIDD;
		public System.Windows.Forms.ComboBox cbMainCmpny;
		public System.Windows.Forms.Label lcomp;
		public System.Windows.Forms.TextBox tt;
		private System.Windows.Forms.Label label18;
		private System.Windows.Forms.Label label20;
		private System.Windows.Forms.Label label21;
		private System.Windows.Forms.Label label22;
		private System.Windows.Forms.PictureBox picSeek;
		public System.Windows.Forms.TextBox tKey;
		public System.Windows.Forms.GroupBox grpContact;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label label118;
		private System.Windows.Forms.Label label17;
		private System.Windows.Forms.PictureBox pictureBox1z;
		private System.Windows.Forms.Button pictureBox1;
		private System.Windows.Forms.Button button2;
		private System.ComponentModel.IContainer components;

		public Contacts(char x_c, string x_st_ID, char X_opera)
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();
            //In_CompanyName = st;
			in_c = x_c; //C = contact, S = sales, A = agent      
			MainMDI.M_stCon = MainMDI.M_stCon;
			In_Opera = X_opera; //N = new, M = modify
			In_stID = x_st_ID;
			fill_cbPrefx();
			fill_cbCompany();

			switch (in_c)
			{
				case 'C':
					this.Text = "CONTACTS...";
					init_scr();
                    if (In_Opera == 'M') fill_Contact();
					break;
				case 'S':
					this.Text = "SALES...";
					break;
				case 'A':
					this.Text = "AGENTS && REPs...";
					break;
			}
		    //Fill_frmCompany();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Contacts));
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnOK = new System.Windows.Forms.Button();
            this.grpContact = new System.Windows.Forms.GroupBox();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.label118 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.picSeek = new System.Windows.Forms.PictureBox();
            this.tKey = new System.Windows.Forms.TextBox();
            this.label22 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.pictureBox1z = new System.Windows.Forms.PictureBox();
            this.tt = new System.Windows.Forms.TextBox();
            this.lcomp = new System.Windows.Forms.Label();
            this.TText2 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.tTel2 = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tsufx = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tCatalog = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.tpager = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.tCell = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.TTExt = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.tLname = new System.Windows.Forms.TextBox();
            this.lprefID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbPrefx = new System.Windows.Forms.ComboBox();
            this.tEmail = new System.Windows.Forms.TextBox();
            this.label19 = new System.Windows.Forms.Label();
            this.tFax = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.tdepart = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tFname = new System.Windows.Forms.TextBox();
            this.lcpnyIDD = new System.Windows.Forms.Label();
            this.cbMainCmpny = new System.Windows.Forms.ComboBox();
            this.tcpny = new System.Windows.Forms.TextBox();
            this.lsave = new System.Windows.Forms.Label();
            this.lMainAdrs = new System.Windows.Forms.TextBox();
            this.btnAdrs = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.tWeb = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpContact.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1z)).BeginInit();
            this.SuspendLayout();
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(120, 208);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 24);
            this.btnCancel.TabIndex = 57;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(40, 208);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(72, 24);
            this.btnOK.TabIndex = 56;
            this.btnOK.Text = "&Save";
            this.btnOK.Visible = false;
            // 
            // grpContact
            // 
            this.grpContact.Controls.Add(this.button2);
            this.grpContact.Controls.Add(this.pictureBox1);
            this.grpContact.Controls.Add(this.label17);
            this.grpContact.Controls.Add(this.label118);
            this.grpContact.Controls.Add(this.pictureBox2);
            this.grpContact.Controls.Add(this.picSeek);
            this.grpContact.Controls.Add(this.tKey);
            this.grpContact.Controls.Add(this.label22);
            this.grpContact.Controls.Add(this.label21);
            this.grpContact.Controls.Add(this.label20);
            this.grpContact.Controls.Add(this.label18);
            this.grpContact.Controls.Add(this.pictureBox1z);
            this.grpContact.Controls.Add(this.tt);
            this.grpContact.Controls.Add(this.lcomp);
            this.grpContact.Controls.Add(this.TText2);
            this.grpContact.Controls.Add(this.label16);
            this.grpContact.Controls.Add(this.tTel2);
            this.grpContact.Controls.Add(this.label15);
            this.grpContact.Controls.Add(this.tsufx);
            this.grpContact.Controls.Add(this.label14);
            this.grpContact.Controls.Add(this.tCatalog);
            this.grpContact.Controls.Add(this.label13);
            this.grpContact.Controls.Add(this.tpager);
            this.grpContact.Controls.Add(this.label12);
            this.grpContact.Controls.Add(this.tCell);
            this.grpContact.Controls.Add(this.label8);
            this.grpContact.Controls.Add(this.TTExt);
            this.grpContact.Controls.Add(this.label7);
            this.grpContact.Controls.Add(this.label6);
            this.grpContact.Controls.Add(this.label5);
            this.grpContact.Controls.Add(this.tLname);
            this.grpContact.Controls.Add(this.lprefID);
            this.grpContact.Controls.Add(this.label1);
            this.grpContact.Controls.Add(this.cbPrefx);
            this.grpContact.Controls.Add(this.tEmail);
            this.grpContact.Controls.Add(this.label19);
            this.grpContact.Controls.Add(this.tFax);
            this.grpContact.Controls.Add(this.label4);
            this.grpContact.Controls.Add(this.label10);
            this.grpContact.Controls.Add(this.label9);
            this.grpContact.Controls.Add(this.tdepart);
            this.grpContact.Controls.Add(this.label2);
            this.grpContact.Controls.Add(this.tFname);
            this.grpContact.Controls.Add(this.lcpnyIDD);
            this.grpContact.Controls.Add(this.cbMainCmpny);
            this.grpContact.Controls.Add(this.tcpny);
            this.grpContact.Controls.Add(this.lsave);
            this.grpContact.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpContact.Location = new System.Drawing.Point(0, 0);
            this.grpContact.Name = "grpContact";
            this.grpContact.Size = new System.Drawing.Size(490, 276);
            this.grpContact.TabIndex = 63;
            this.grpContact.TabStop = false;
            this.grpContact.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(383, 243);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(95, 25);
            this.button2.TabIndex = 249;
            this.button2.Text = "Cancel";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.pictureBox1.Location = new System.Drawing.Point(278, 243);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(95, 25);
            this.pictureBox1.TabIndex = 248;
            this.pictureBox1.Text = "Save";
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // label17
            // 
            this.label17.ForeColor = System.Drawing.Color.Blue;
            this.label17.Location = new System.Drawing.Point(368, 207);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(69, 16);
            this.label17.TabIndex = 247;
            this.label17.Text = "Send e-mail";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label17.Visible = false;
            // 
            // label118
            // 
            this.label118.Font = new System.Drawing.Font("Eras Bold ITC", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label118.ForeColor = System.Drawing.Color.Blue;
            this.label118.Location = new System.Drawing.Point(56, 272);
            this.label118.Name = "label118";
            this.label118.Size = new System.Drawing.Size(35, 21);
            this.label118.TabIndex = 246;
            this.label118.Text = "Save";
            this.label118.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label118.Visible = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(334, 202);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(32, 29);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 161;
            this.pictureBox2.TabStop = false;
            this.pictureBox2.Visible = false;
            this.pictureBox2.Click += new System.EventHandler(this.pictureBox2_Click);
            // 
            // picSeek
            // 
            this.picSeek.BackColor = System.Drawing.Color.Transparent;
            this.picSeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSeek.Image = ((System.Drawing.Image)(resources.GetObject("picSeek.Image")));
            this.picSeek.Location = new System.Drawing.Point(148, 83);
            this.picSeek.Name = "picSeek";
            this.picSeek.Size = new System.Drawing.Size(45, 19);
            this.picSeek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSeek.TabIndex = 160;
            this.picSeek.TabStop = false;
            this.picSeek.Click += new System.EventHandler(this.picSeek_Click);
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.PeachPuff;
            this.tKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.ForeColor = System.Drawing.Color.Blue;
            this.tKey.Location = new System.Drawing.Point(197, 83);
            this.tKey.MaxLength = 60;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(283, 22);
            this.tKey.TabIndex = 159;
            // 
            // label22
            // 
            this.label22.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.Color.Red;
            this.label22.Location = new System.Drawing.Point(6, 37);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(9, 12);
            this.label22.TabIndex = 91;
            this.label22.Text = "*";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Transparent;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.Color.Red;
            this.label21.Location = new System.Drawing.Point(4, 59);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(12, 8);
            this.label21.TabIndex = 90;
            this.label21.Text = "*";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label20
            // 
            this.label20.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.Color.Red;
            this.label20.Location = new System.Drawing.Point(8, 77);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(9, 12);
            this.label20.TabIndex = 89;
            this.label20.Text = "*";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label18
            // 
            this.label18.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.Color.Red;
            this.label18.Location = new System.Drawing.Point(32, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(11, 12);
            this.label18.TabIndex = 88;
            this.label18.Text = "*";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox1z
            // 
            this.pictureBox1z.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1z.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1z.Image")));
            this.pictureBox1z.Location = new System.Drawing.Point(40, 274);
            this.pictureBox1z.Name = "pictureBox1z";
            this.pictureBox1z.Size = new System.Drawing.Size(18, 21);
            this.pictureBox1z.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1z.TabIndex = 86;
            this.pictureBox1z.TabStop = false;
            this.pictureBox1z.Visible = false;
            this.pictureBox1z.Click += new System.EventHandler(this.pictureBox1_Click);
            this.pictureBox1z.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1z.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // tt
            // 
            this.tt.BackColor = System.Drawing.Color.Lavender;
            this.tt.Location = new System.Drawing.Point(76, 145);
            this.tt.Name = "tt";
            this.tt.Size = new System.Drawing.Size(118, 20);
            this.tt.TabIndex = 15;
            // 
            // lcomp
            // 
            this.lcomp.BackColor = System.Drawing.Color.LawnGreen;
            this.lcomp.Location = new System.Drawing.Point(603, 75);
            this.lcomp.Name = "lcomp";
            this.lcomp.Size = new System.Drawing.Size(38, 20);
            this.lcomp.TabIndex = 83;
            this.lcomp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lcomp.Visible = false;
            // 
            // TText2
            // 
            this.TText2.BackColor = System.Drawing.Color.Lavender;
            this.TText2.Location = new System.Drawing.Point(222, 165);
            this.TText2.Name = "TText2";
            this.TText2.Size = new System.Drawing.Size(65, 20);
            this.TText2.TabIndex = 81;
            // 
            // label16
            // 
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(196, 165);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(26, 20);
            this.label16.TabIndex = 80;
            this.label16.Text = "Ext.";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tTel2
            // 
            this.tTel2.BackColor = System.Drawing.Color.Lavender;
            this.tTel2.Location = new System.Drawing.Point(76, 165);
            this.tTel2.Name = "tTel2";
            this.tTel2.Size = new System.Drawing.Size(118, 20);
            this.tTel2.TabIndex = 79;
            // 
            // label15
            // 
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(25, 165);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(51, 20);
            this.label15.TabIndex = 78;
            this.label15.Text = "Phone2:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tsufx
            // 
            this.tsufx.BackColor = System.Drawing.Color.Lavender;
            this.tsufx.Location = new System.Drawing.Point(216, 12);
            this.tsufx.Name = "tsufx";
            this.tsufx.Size = new System.Drawing.Size(139, 20);
            this.tsufx.TabIndex = 2;
            // 
            // label14
            // 
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(175, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(42, 20);
            this.label14.TabIndex = 76;
            this.label14.Text = "Suffixe:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tCatalog
            // 
            this.tCatalog.BackColor = System.Drawing.Color.Lavender;
            this.tCatalog.Location = new System.Drawing.Point(76, 245);
            this.tCatalog.Name = "tCatalog";
            this.tCatalog.Size = new System.Drawing.Size(153, 20);
            this.tCatalog.TabIndex = 19;
            // 
            // label13
            // 
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(15, 245);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(60, 20);
            this.label13.TabIndex = 74;
            this.label13.Text = "Catalog #:";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tpager
            // 
            this.tpager.BackColor = System.Drawing.Color.Lavender;
            this.tpager.Location = new System.Drawing.Point(328, 147);
            this.tpager.Name = "tpager";
            this.tpager.Size = new System.Drawing.Size(149, 20);
            this.tpager.TabIndex = 73;
            // 
            // label12
            // 
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(289, 147);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(39, 20);
            this.label12.TabIndex = 72;
            this.label12.Text = "Pager:";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tCell
            // 
            this.tCell.BackColor = System.Drawing.Color.Lavender;
            this.tCell.Location = new System.Drawing.Point(76, 185);
            this.tCell.Name = "tCell";
            this.tCell.Size = new System.Drawing.Size(118, 20);
            this.tCell.TabIndex = 16;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(42, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 20);
            this.label8.TabIndex = 70;
            this.label8.Text = "Cell#:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // TTExt
            // 
            this.TTExt.BackColor = System.Drawing.Color.Lavender;
            this.TTExt.Location = new System.Drawing.Point(222, 145);
            this.TTExt.Name = "TTExt";
            this.TTExt.Size = new System.Drawing.Size(65, 20);
            this.TTExt.TabIndex = 69;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(195, 145);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(25, 20);
            this.label7.TabIndex = 68;
            this.label7.Text = "Ext.";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(10, 125);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 20);
            this.label6.TabIndex = 67;
            this.label6.Text = "Department:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(38, 12);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(37, 20);
            this.label5.TabIndex = 66;
            this.label5.Text = "Prefix:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tLname
            // 
            this.tLname.BackColor = System.Drawing.Color.Lavender;
            this.tLname.Location = new System.Drawing.Point(78, 53);
            this.tLname.Name = "tLname";
            this.tLname.Size = new System.Drawing.Size(276, 20);
            this.tLname.TabIndex = 13;
            // 
            // lprefID
            // 
            this.lprefID.BackColor = System.Drawing.Color.LawnGreen;
            this.lprefID.Location = new System.Drawing.Point(546, 115);
            this.lprefID.Name = "lprefID";
            this.lprefID.Size = new System.Drawing.Size(36, 17);
            this.lprefID.TabIndex = 64;
            this.lprefID.Text = "1";
            this.lprefID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lprefID.Visible = false;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 57;
            this.label1.Text = "Last Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // cbPrefx
            // 
            this.cbPrefx.BackColor = System.Drawing.Color.Lavender;
            this.cbPrefx.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbPrefx.Location = new System.Drawing.Point(78, 12);
            this.cbPrefx.Name = "cbPrefx";
            this.cbPrefx.Size = new System.Drawing.Size(92, 21);
            this.cbPrefx.TabIndex = 0;
            this.cbPrefx.SelectedIndexChanged += new System.EventHandler(this.cbPrefx_SelectedIndexChanged);
            // 
            // tEmail
            // 
            this.tEmail.BackColor = System.Drawing.Color.Lavender;
            this.tEmail.Location = new System.Drawing.Point(76, 205);
            this.tEmail.Name = "tEmail";
            this.tEmail.Size = new System.Drawing.Size(256, 20);
            this.tEmail.TabIndex = 17;
            // 
            // label19
            // 
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(33, 205);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(43, 20);
            this.label19.TabIndex = 31;
            this.label19.Text = "&E-mail:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tFax
            // 
            this.tFax.BackColor = System.Drawing.Color.Lavender;
            this.tFax.Location = new System.Drawing.Point(76, 225);
            this.tFax.Name = "tFax";
            this.tFax.Size = new System.Drawing.Size(119, 20);
            this.tFax.TabIndex = 18;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(31, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 20);
            this.label4.TabIndex = 29;
            this.label4.Text = "&Fax:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(25, 145);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(51, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "Phone:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(16, 103);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 23);
            this.label9.TabIndex = 15;
            this.label9.Text = "Company:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tdepart
            // 
            this.tdepart.BackColor = System.Drawing.Color.Lavender;
            this.tdepart.Location = new System.Drawing.Point(76, 125);
            this.tdepart.Name = "tdepart";
            this.tdepart.Size = new System.Drawing.Size(234, 20);
            this.tdepart.TabIndex = 20;
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(12, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "First Name:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tFname
            // 
            this.tFname.BackColor = System.Drawing.Color.Lavender;
            this.tFname.Location = new System.Drawing.Point(78, 33);
            this.tFname.Name = "tFname";
            this.tFname.Size = new System.Drawing.Size(277, 20);
            this.tFname.TabIndex = 12;
            // 
            // lcpnyIDD
            // 
            this.lcpnyIDD.BackColor = System.Drawing.Color.LawnGreen;
            this.lcpnyIDD.Location = new System.Drawing.Point(612, 34);
            this.lcpnyIDD.Name = "lcpnyIDD";
            this.lcpnyIDD.Size = new System.Drawing.Size(41, 20);
            this.lcpnyIDD.TabIndex = 63;
            this.lcpnyIDD.Text = "0";
            this.lcpnyIDD.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lcpnyIDD.Visible = false;
            // 
            // cbMainCmpny
            // 
            this.cbMainCmpny.BackColor = System.Drawing.Color.Lavender;
            this.cbMainCmpny.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbMainCmpny.IntegralHeight = false;
            this.cbMainCmpny.Location = new System.Drawing.Point(76, 104);
            this.cbMainCmpny.Name = "cbMainCmpny";
            this.cbMainCmpny.Size = new System.Drawing.Size(402, 21);
            this.cbMainCmpny.TabIndex = 14;
            this.cbMainCmpny.SelectedIndexChanged += new System.EventHandler(this.cbMainCmpny_SelectedIndexChanged);
            // 
            // tcpny
            // 
            this.tcpny.BackColor = System.Drawing.Color.AliceBlue;
            this.tcpny.Location = new System.Drawing.Point(76, 104);
            this.tcpny.Name = "tcpny";
            this.tcpny.ReadOnly = true;
            this.tcpny.Size = new System.Drawing.Size(257, 20);
            this.tcpny.TabIndex = 82;
            // 
            // lsave
            // 
            this.lsave.BackColor = System.Drawing.Color.LawnGreen;
            this.lsave.Location = new System.Drawing.Point(631, 97);
            this.lsave.Name = "lsave";
            this.lsave.Size = new System.Drawing.Size(22, 20);
            this.lsave.TabIndex = 69;
            this.lsave.Text = "N";
            this.lsave.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lsave.Visible = false;
            // 
            // lMainAdrs
            // 
            this.lMainAdrs.BackColor = System.Drawing.Color.AliceBlue;
            this.lMainAdrs.Location = new System.Drawing.Point(80, 272);
            this.lMainAdrs.Name = "lMainAdrs";
            this.lMainAdrs.ReadOnly = true;
            this.lMainAdrs.Size = new System.Drawing.Size(468, 20);
            this.lMainAdrs.TabIndex = 66;
            // 
            // btnAdrs
            // 
            this.btnAdrs.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnAdrs.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAdrs.Location = new System.Drawing.Point(552, 272);
            this.btnAdrs.Name = "btnAdrs";
            this.btnAdrs.Size = new System.Drawing.Size(33, 20);
            this.btnAdrs.TabIndex = 65;
            this.btnAdrs.Text = "...";
            // 
            // label11
            // 
            this.label11.Location = new System.Drawing.Point(32, 272);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(50, 20);
            this.label11.TabIndex = 64;
            this.label11.Text = "Address:";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tWeb
            // 
            this.tWeb.BackColor = System.Drawing.Color.Lavender;
            this.tWeb.Location = new System.Drawing.Point(80, 296);
            this.tWeb.Name = "tWeb";
            this.tWeb.Size = new System.Drawing.Size(253, 20);
            this.tWeb.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(24, 296);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 67;
            this.label3.Text = "Web Site:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Contacts
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(490, 276);
            this.Controls.Add(this.grpContact);
            this.Controls.Add(this.tWeb);
            this.Controls.Add(this.lMainAdrs);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btnAdrs);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Contacts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contacts";
            this.Load += new System.EventHandler(this.Contacts_Load);
            this.grpContact.ResumeLayout(false);
            this.grpContact.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1z)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			lsave.Text = "Y";
			this.Hide();
		}

		/*
		private void tabPage1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnAdrs_Click(object sender, System.EventArgs e)
		{
			dlgAdrs dAdrs = new dlgAdrs(lMainAdrs.Text);
			dAdrs.ShowDialog();
			if (dAdrs.tStreet.Text != "") lMainAdrs.Text = dAdrs.tStreet.Text + ", " + dAdrs.cbCity.Text + ", " + dAdrs.cbSP.Text + ", " + dAdrs.tZip.Text + ", " + dAdrs.cbCountry.Text;
		}

		private void Company_Load(object sender, System.EventArgs e)
		{
		    
		}

		private void cbActivity_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		    //string tt = e.KeyChar.ToString();
		    //int ndx = cbActivity.FindString(tt);
		    //MessageBox.Show("ndx= " + ndx.ToString() + "  tt= " + tt);
		    //cbActivity.SelectedIndex = ndx;
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private bool fields_ok()
		{
			return true;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (fields_ok())
			{ 
				if (btnOK.Text == "&Save")
				{
					try
					{
						string stSql = "INSERT INTO PSM_COMPANY ([Cpny_Name1],[M_Adrs], " + 
							" [Tel1],[Fax],[TollFree],[Web],[Email],[Customer],[Supplier], " + 
							" [Manufacturer],[Cpny_Name2],[Cpny_Main],[Q_Adrs],[P_Adrs],[S_Adrs],[I_Adrs],[Tel2], " + 
							"[CustomerType],[TermID],[CreditLim],[Currency],[ShipVia_ID],[IncoTerm_ID], " +
							"[City],[Province_State],[Country_Name],[actvId]) VALUES ('" +
							tCompanyName1.Text.Replace("'", "''") + "', '" + lMainAdrs.Text.Replace("'", "''") + "', '" + tTel1.Text + "', '" +
							tFax.Text + "', '" + tToll.Text + "', '" + tWeb.Text + "', '" +
							tEmail.Text + "', " + chkCust.Checked + ", " + chkSupp.Checked + ", " + chkManufac.Checked + ", '" +
							tCompanyName2.Text.Replace("'", "''") + "', " + lMainCpnyID.Text + ", '" + lQA.Text.Replace("'", "''") + "', '" +
							lPA.Text.Replace("'", "''") + "', '" + lSA.Text.Replace("'", "''") + "', '" + lIA.Text.Replace("'", "''") + "', '" +
							tTel2.Text + "', " + lcustmTp.Text + ", " + lTermsId.Text + ", '" + tCreditLim.Text + "', '" +
							cbCurr.Text + "', " + lViaId.Text + ", " + lInTermId.Text + ", '" +
							"" + "', '" + "" + "', '" + "" + "', " + lActId.Text + ")";
						MainMDI.ExecSql(stSql);
					}
					catch (OleDbException Oexp)
					{
						MessageBox.Show("Adding Option Error...= " + Oexp.Message);
					}
				}
				else 
				{	
					try
					{
						string stSql = "UPDATE PSM_COMPANY SET " +
							" [Cpny_Name1]='" + tCompanyName1.Text.Replace("'", "''") + "', " +
							" [M_Adrs]='" + lMainAdrs.Text.Replace("'", "''") + "', " +
							" [Tel1]='" + tTel1.Text + "', " +
							" [Fax]='" + tFax.Text + "', " +
							" [TollFree]='" + tToll.Text + "', " +
							" [Web]='" + tWeb.Text + "', " +
							" [Email]='" + tEmail.Text + "', " +
							" [Customer]=" + chkCust.Checked + ", " +
							" [Supplier]=" + chkSupp.Checked + ", " +
							" [Manufacturer]=" + chkManufac.Checked + ", " +
							" [Cpny_Name2]='" + tCompanyName2.Text.Replace("'", "''") + "', " +
							" [Cpny_Main]=" + lMainCpnyID.Text + ", " +
							" [Q_Adrs]='" + lQA.Text.Replace("'", "''") + "', " +
							" [P_Adrs]='" + lPA.Text.Replace("'", "''") + "', " +
							" [S_Adrs]='" + lSA.Text.Replace("'", "''") + "', " +
							" [I_Adrs]='" + lIA.Text.Replace("'", "''") + "', " +
							" [Tel2]='" + tTel2.Text + "', " +
							" [CustomerType]=" + lcustmTp.Text + ", " +
							" [TermID]=" + lTermsId.Text + ", " +
							" [CreditLim]='" + tCreditLim.Text.Replace("'", "''") + "', " +
							" [Currency]='" + cbCurr.Text.Replace("'", "''") + "', " +
							" [ShipVia_ID]=" + lViaId.Text + ", " +
							" [IncoTerm_ID]=" + lInTermId.Text + ", " +
							" [City]='" + ""  + "', " +
							" [Province_State]='" + "" + "', " +
							" [Country_Name]='" + ""  + "', " +
							" [actvId]=" + lActId.Text + " " +
							" WHERE [Cpny_ID]=" + tCompanyID.Text;
						MainMDI.ExecSql(stSql);
						btnOK.Text = "&Save";
					}
					catch (OleDbException Oexp)
					{
						MessageBox.Show("Updating Option Error...= " + Oexp.Message);
					}
				}
			}
			else MessageBox.Show("You missed some data.....");
		}

		private void btnComnt_Click(object sender, System.EventArgs e)
		{
			
		}

		private void cbMainCmpny_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lMainCpnyID.Text = "0";
			if (cbMainCmpny.Text != "")
			{
				lMainCpnyID.Text = MainMDI.Find_One_Field("select Cpny_ID from PSM_COMPANY where Cpny_Name1='" + cbMainCmpny.Text + "'");
				if (lMainCpnyID.Text == MainMDI.VIDE) lMainCpnyID.Text = "0";
			}
		}

		private void btnAQ_Click(object sender, System.EventArgs e)
		{
			QuoteXAdrs('Q', lQA.Text);
		}

		private void QuoteXAdrs(char c_adrs, string adrs)
		{
			dlgAdrs dAdrs = new dlgAdrs(adrs);
			//dAdrs.chkSave.Visible = true;
			dAdrs.ShowDialog();
			if (dAdrs.tStreet.Text != "")
			{
				switch (c_adrs)
				{
					case 'Q':
						lQA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text + "," + dAdrs.tZip.Text + "," + dAdrs.cbCountry.Text;
						break;
					case 'S':
						lSA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text + "," + dAdrs.tZip.Text + "," + dAdrs.cbCountry.Text;
						break;
					case 'I':
						lIA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text + "," + dAdrs.tZip.Text + "," + dAdrs.cbCountry.Text;
						break;
					case 'P':
						lPA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text + "," + dAdrs.tZip.Text + "," + dAdrs.cbCountry.Text;
						break;
				}
			}
		}
        */	

		private void fill_Contact()
		{
		    //string stSql = "select * FROM PSM_Contacts where Contact_ID=" + In_stID + " order by First_Name ";
		    //string stSql = " SELECT PSM_Contacts.*, PSM_COMPANY.Cpny_Name1 FROM PSM_COMPANY, PSM_Contacts " +
                //" WHERE PSM_Contacts.Contact_ID=" + In_stID + " ORDER BY PSM_Contacts.First_Name ";
		    string stSql = " SELECT PSM_Contacts.*, PSM_COMPANY.Cpny_Name1, PSM_Prefix.Prefix " + 
                " FROM (PSM_Contacts INNER JOIN PSM_COMPANY ON PSM_Contacts.Company_ID = PSM_COMPANY.Cpny_ID) INNER JOIN PSM_Prefix ON PSM_Contacts.Prefix_ID = PSM_Prefix.[Prefix ID] " +
                " WHERE PSM_Contacts.Contact_ID=" + In_stID + "  ORDER BY PSM_Contacts.First_Name";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read())
			{
				tFname.Text = Oreadr["First_Name"].ToString();
				tLname.Text = Oreadr["Last_Name"].ToString();
				cbMainCmpny.Text = Oreadr["Cpny_Name1"].ToString();
				cbPrefx.Text = Oreadr["Prefix"].ToString();
				tsufx.Text = Oreadr["JOBTitle"].ToString();
				tt.Text = Oreadr["Main_TEL"].ToString();
				TTExt.Text = Oreadr["Extension"].ToString();
				tFax.Text = Oreadr["Fax Number"].ToString();
				tCell.Text = Oreadr["Cell Number"].ToString();
				tpager.Text = Oreadr["Pager Number"].ToString();
				tEmail.Text = Oreadr["Email Address"].ToString();
				tCatalog.Text = Oreadr["Catalog Number"].ToString();
				tTel2.Text = Oreadr["Tel2"].ToString();
				TText2.Text = Oreadr["ext2"].ToString();
			}
			//if (cbOptGrp.Items.Count > 0) cbOptGrp.Items.Add(MainMDI.VIDE);
			OConn.Close();
		}

		private void init_scr()
		{
			tFax.Clear();
			tFname.Clear();
			tLname.Clear();
			tcpny.Clear();
			tdepart.Clear();
			tEmail.Clear();
			tCell.Clear();
			tCatalog.Clear();
			tpager.Clear();
		}

		private void fill_cbCompany()
		{
			string stSql = "select Cpny_Name1 FROM PSM_Company order by Cpny_Name1";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read()) cbMainCmpny.Items.Add(Oreadr["Cpny_Name1"].ToString());
	
			OConn.Close();
		}

		private void fill_cbPrefx()
		{
			string stSql = "select [Prefix] FROM PSM_Prefix ";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read()) cbPrefx.Items.Add(Oreadr["Prefix"].ToString());
	
			OConn.Close();
		}

		private void cbMainCmpny_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lcomp.Text = cbMainCmpny.Text;
			string cpID = "", tel = "";
			MainMDI.Find_2_Field("SELECT [Cpny_ID],Tel1 FROM PSM_Company where  Cpny_Name1='" + cbMainCmpny.Text.Replace("'", "''") + "'", ref cpID, ref tel);
			lcpnyIDD.Text = (cpID == MainMDI.VIDE) ? "0" : cpID;
			tt.Text = tel;
		}

		private void cbPrefx_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string st = MainMDI.Find_One_Field("SELECT [Prefix ID] FROM PSM_Prefix where  Prefix='" + cbPrefx.Text + "'");
			lprefID.Text = (st == MainMDI.VIDE) ? "0" : st;
		}

		private void Contacts_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
		}

		private void groupBox3_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
			if (MainMDI.ALWD_USR("CNT_SV", true))
			{
				if (tFname.Text != "" && tLname.Text != "" && cbMainCmpny.Text != "" && cbPrefx.Text != "")
				{
					lsave.Text = "Y";
					this.Hide();
				}
				else MessageBox.Show("First/Last Name or Company  are empty....");
			}
			else lsave.Text = "N";
			//MessageBox.Show("ACCESS DENIED... ", MainMDI.User, MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}

		private void picSeek_Click(object sender, System.EventArgs e)
		{
			bool FOUND = false;
					   
			for (int i = 0; i < cbMainCmpny.Items.Count; i++)
			{
				//if (cbCompany.Items[i].ToString().ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1)
				int ln = (tKey.Text.Length < cbMainCmpny.Items[i].ToString().Length) ? tKey.Text.Length : cbMainCmpny.Items[i].ToString().Length;
				if (cbMainCmpny.Items[i].ToString().Substring(0, ln).ToUpper().IndexOf(tKey.Text.ToUpper(), 0) > -1)
				{   
					cbMainCmpny.SelectedIndex = i;
					FOUND = true;
					i = cbMainCmpny.Items.Count + 1;
				}
			}
			if (!FOUND) MessageBox.Show("KeyWord not Found !!!!");
		}

		private void pictureBox1_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//pictureBox1.BorderStyle = BorderStyle.Fixed3D;
		}

		private void pictureBox1_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			//pictureBox1.BorderStyle = BorderStyle.None;
		}

		private void label1_Click(object sender, System.EventArgs e)
		{
		
		}

		private void pictureBox2_Click(object sender, System.EventArgs e)
		{
			if (tEmail.Text.Length > 6 && tEmail.Text.IndexOf("@") > 0)
			{
				string sentEmail = tEmail.Text;
				string subject = " ";
				string body = " ";
				string msg = string.Format("mailto:{0}?subject={1}&body={2}", sentEmail,
					subject, body);
				Process.Start(msg);
			}
			else MessageBox.Show("Invalid e-mail.....!!!!");
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			lsave.Text = "N";
			this.Hide();
		}
	}
}