using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb ;  
using System.Data.SqlClient ;
using System.Threading;
using System.Security.Cryptography;
using System.Text;
using System.IO;
using System.Collections.Generic;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for Passwd.
	/// </summary>
	public class Passwd : System.Windows.Forms.Form
	{
        int PSMCONOK=2;


        Thread m_WkTHRD;
        ManualResetEvent m_EventStopThread;
        ManualResetEvent m_EventThreadStopped;
        public deleg_RepTrace m_RepTrace;
        public deleg_endTHR m_endTHR;
        string mykey = "primax";



		private char In_Type_dlg ;
		private int nbtry=0;
		public bool denied=false;
		private bool loaded=false;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.GroupBox grpUsers;
		private System.Windows.Forms.TextBox tPass;
		private System.Windows.Forms.TextBox tUser;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.PictureBox pictureBox2;
		private System.Windows.Forms.Label lPDecry;
		private System.Windows.Forms.Label lCancel;
		private System.Windows.Forms.GroupBox grpLogin;
		private System.Windows.Forms.TextBox tLoginPass;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnLogin;
		public System.Windows.Forms.Label lblWait;
		private System.Windows.Forms.ProgressBar pbL;
		private System.Windows.Forms.GroupBox grpLoad;
		private System.Windows.Forms.ColumnHeader enabled;
		private System.Windows.Forms.ColumnHeader User;
		private System.Windows.Forms.ColumnHeader pswd;
		private System.Windows.Forms.ColumnHeader profile;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.Label lprofile;
		private System.Windows.Forms.ListView lvUsers;
		private System.Windows.Forms.ColumnHeader LId;
		private System.Windows.Forms.PictureBox picSave;
		private System.Windows.Forms.Label lndx;
		private System.Windows.Forms.Label toto;
		public System.Windows.Forms.Label logPswdEnc;
		private System.Windows.Forms.TextBox tLoginUser;
		public System.Windows.Forms.Label Svpwd;
		private System.Windows.Forms.Label lpsEnc;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label tpassCLR;
		private System.Windows.Forms.ListView lvprofile;
		private System.Windows.Forms.ColumnHeader mdlname;
		private System.Windows.Forms.ColumnHeader mdl_LID;
		private System.Windows.Forms.Button btnProf;
		private System.Windows.Forms.Button btnSav;
		private System.Windows.Forms.ColumnHeader u_m_LID;
		private System.Windows.Forms.ColumnHeader permT;
		private System.Windows.Forms.Label lusr_LID;
        private System.Windows.Forms.Button btnPcancel;
        private Label lWait;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Passwd(char X_type_dlg)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();



			In_Type_dlg =  X_type_dlg;
			lCancel.Text ="";
			grpLogin.Visible = (In_Type_dlg =='L');
			grpUsers.Visible = (In_Type_dlg =='U');
			disp_profile(false); 
			if (In_Type_dlg =='L') 
			{
				this.FormBorderStyle = FormBorderStyle.None ;
				this.AcceptButton=btnLogin ; 
			}
			if (In_Type_dlg =='U') 
			{
				this.Text ="Users Manager";
				fill_lvUsers();
				fill_mdls();
			}
			 
           // tLoginUser.Text = System.Environment.UserName;
            tLoginUser.Text = MainMDI.Def_LoginUser;  
			tLoginPass.Text =MainMDI.Def_LoginPass ;
			//		load_Loc_Config();
			
			

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Passwd));
            this.grpUsers = new System.Windows.Forms.GroupBox();
            this.lvUsers = new System.Windows.Forms.ListView();
            this.enabled = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.User = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.profile = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LId = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pswd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lusr_LID = new System.Windows.Forms.Label();
            this.btnPcancel = new System.Windows.Forms.Button();
            this.tPass = new System.Windows.Forms.TextBox();
            this.btnSav = new System.Windows.Forms.Button();
            this.btnProf = new System.Windows.Forms.Button();
            this.toto = new System.Windows.Forms.Label();
            this.picSave = new System.Windows.Forms.PictureBox();
            this.lprofile = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tUser = new System.Windows.Forms.TextBox();
            this.tpassCLR = new System.Windows.Forms.Label();
            this.lPDecry = new System.Windows.Forms.Label();
            this.lCancel = new System.Windows.Forms.Label();
            this.lpsEnc = new System.Windows.Forms.Label();
            this.lvprofile = new System.Windows.Forms.ListView();
            this.permT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdlname = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdl_LID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.u_m_LID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lndx = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpLogin = new System.Windows.Forms.GroupBox();
            this.lWait = new System.Windows.Forms.Label();
            this.grpLoad = new System.Windows.Forms.GroupBox();
            this.lblWait = new System.Windows.Forms.Label();
            this.pbL = new System.Windows.Forms.ProgressBar();
            this.Svpwd = new System.Windows.Forms.Label();
            this.tLoginUser = new System.Windows.Forms.TextBox();
            this.logPswdEnc = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnLogin = new System.Windows.Forms.Button();
            this.tLoginPass = new System.Windows.Forms.TextBox();
            this.grpUsers.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSave)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpLogin.SuspendLayout();
            this.grpLoad.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpUsers
            // 
            this.grpUsers.Controls.Add(this.lvUsers);
            this.grpUsers.Controls.Add(this.lusr_LID);
            this.grpUsers.Controls.Add(this.btnPcancel);
            this.grpUsers.Controls.Add(this.tPass);
            this.grpUsers.Controls.Add(this.btnSav);
            this.grpUsers.Controls.Add(this.btnProf);
            this.grpUsers.Controls.Add(this.toto);
            this.grpUsers.Controls.Add(this.picSave);
            this.grpUsers.Controls.Add(this.lprofile);
            this.grpUsers.Controls.Add(this.radioButton3);
            this.grpUsers.Controls.Add(this.radioButton2);
            this.grpUsers.Controls.Add(this.radioButton1);
            this.grpUsers.Controls.Add(this.label2);
            this.grpUsers.Controls.Add(this.label1);
            this.grpUsers.Controls.Add(this.tUser);
            this.grpUsers.Controls.Add(this.tpassCLR);
            this.grpUsers.Controls.Add(this.lPDecry);
            this.grpUsers.Controls.Add(this.lCancel);
            this.grpUsers.Controls.Add(this.lpsEnc);
            this.grpUsers.Controls.Add(this.lvprofile);
            this.grpUsers.Location = new System.Drawing.Point(8, 56);
            this.grpUsers.Name = "grpUsers";
            this.grpUsers.Size = new System.Drawing.Size(463, 448);
            this.grpUsers.TabIndex = 0;
            this.grpUsers.TabStop = false;
            this.grpUsers.Enter += new System.EventHandler(this.grpUsers_Enter);
            // 
            // lvUsers
            // 
            this.lvUsers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvUsers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.enabled,
            this.User,
            this.profile,
            this.LId,
            this.pswd});
            this.lvUsers.ForeColor = System.Drawing.Color.Blue;
            this.lvUsers.FullRowSelect = true;
            this.lvUsers.GridLines = true;
            this.lvUsers.Location = new System.Drawing.Point(40, 72);
            this.lvUsers.MultiSelect = false;
            this.lvUsers.Name = "lvUsers";
            this.lvUsers.Size = new System.Drawing.Size(312, 176);
            this.lvUsers.TabIndex = 20;
            this.lvUsers.UseCompatibleStateImageBehavior = false;
            this.lvUsers.View = System.Windows.Forms.View.Details;
            this.lvUsers.SelectedIndexChanged += new System.EventHandler(this.lvUsers_SelectedIndexChanged);
            this.lvUsers.DoubleClick += new System.EventHandler(this.lvUsers_DoubleClick);
            // 
            // enabled
            // 
            this.enabled.Text = "Enabled";
            this.enabled.Width = 0;
            // 
            // User
            // 
            this.User.Text = "User Name";
            this.User.Width = 237;
            // 
            // profile
            // 
            this.profile.Text = "status";
            this.profile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.profile.Width = 50;
            // 
            // LId
            // 
            this.LId.Text = "";
            this.LId.Width = 0;
            // 
            // pswd
            // 
            this.pswd.Text = "";
            this.pswd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.pswd.Width = 0;
            // 
            // lusr_LID
            // 
            this.lusr_LID.BackColor = System.Drawing.Color.SkyBlue;
            this.lusr_LID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lusr_LID.Location = new System.Drawing.Point(232, 16);
            this.lusr_LID.Name = "lusr_LID";
            this.lusr_LID.Size = new System.Drawing.Size(16, 16);
            this.lusr_LID.TabIndex = 181;
            this.lusr_LID.Visible = false;
            // 
            // btnPcancel
            // 
            this.btnPcancel.BackColor = System.Drawing.Color.Moccasin;
            this.btnPcancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnPcancel.Location = new System.Drawing.Point(376, 408);
            this.btnPcancel.Name = "btnPcancel";
            this.btnPcancel.Size = new System.Drawing.Size(72, 24);
            this.btnPcancel.TabIndex = 180;
            this.btnPcancel.Text = "Cancel";
            this.btnPcancel.UseVisualStyleBackColor = false;
            this.btnPcancel.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // tPass
            // 
            this.tPass.Location = new System.Drawing.Point(88, 42);
            this.tPass.Name = "tPass";
            this.tPass.PasswordChar = '*';
            this.tPass.Size = new System.Drawing.Size(144, 20);
            this.tPass.TabIndex = 16;
            this.tPass.TextChanged += new System.EventHandler(this.tPass_TextChanged);
            // 
            // btnSav
            // 
            this.btnSav.BackColor = System.Drawing.Color.Moccasin;
            this.btnSav.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSav.Location = new System.Drawing.Point(376, 376);
            this.btnSav.Name = "btnSav";
            this.btnSav.Size = new System.Drawing.Size(72, 24);
            this.btnSav.TabIndex = 179;
            this.btnSav.Text = "Save profile";
            this.btnSav.UseVisualStyleBackColor = false;
            this.btnSav.Click += new System.EventHandler(this.btnSav_Click);
            // 
            // btnProf
            // 
            this.btnProf.Location = new System.Drawing.Point(304, 38);
            this.btnProf.Name = "btnProf";
            this.btnProf.Size = new System.Drawing.Size(72, 20);
            this.btnProf.TabIndex = 178;
            this.btnProf.Text = "Profile";
            this.btnProf.Visible = false;
            this.btnProf.Click += new System.EventHandler(this.btnProf_Click);
            // 
            // toto
            // 
            this.toto.BackColor = System.Drawing.Color.SkyBlue;
            this.toto.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.toto.Location = new System.Drawing.Point(480, 40);
            this.toto.Name = "toto";
            this.toto.Size = new System.Drawing.Size(16, 16);
            this.toto.TabIndex = 175;
            this.toto.Visible = false;
            // 
            // picSave
            // 
            this.picSave.BackColor = System.Drawing.Color.Transparent;
            this.picSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSave.Image = ((System.Drawing.Image)(resources.GetObject("picSave.Image")));
            this.picSave.Location = new System.Drawing.Point(400, 8);
            this.picSave.Name = "picSave";
            this.picSave.Size = new System.Drawing.Size(48, 56);
            this.picSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSave.TabIndex = 172;
            this.picSave.TabStop = false;
            this.picSave.Click += new System.EventHandler(this.picSave_Click);
            // 
            // lprofile
            // 
            this.lprofile.BackColor = System.Drawing.Color.SkyBlue;
            this.lprofile.Location = new System.Drawing.Point(384, 24);
            this.lprofile.Name = "lprofile";
            this.lprofile.Size = new System.Drawing.Size(8, 16);
            this.lprofile.TabIndex = 24;
            this.lprofile.Text = "N";
            this.lprofile.Visible = false;
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(376, 224);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(40, 16);
            this.radioButton3.TabIndex = 23;
            this.radioButton3.Text = "Restricted";
            this.radioButton3.Visible = false;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Checked = true;
            this.radioButton2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton2.Location = new System.Drawing.Point(248, 40);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(64, 16);
            this.radioButton2.TabIndex = 22;
            this.radioButton2.TabStop = true;
            this.radioButton2.Text = "Normal ";
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioButton1.Location = new System.Drawing.Point(248, 24);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(64, 16);
            this.radioButton1.TabIndex = 21;
            this.radioButton1.Text = "Super";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(8, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 17;
            this.label2.Text = "Password:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(0, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 15;
            this.label1.Text = "User Name:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tUser
            // 
            this.tUser.Location = new System.Drawing.Point(88, 16);
            this.tUser.Name = "tUser";
            this.tUser.Size = new System.Drawing.Size(144, 20);
            this.tUser.TabIndex = 12;
            // 
            // tpassCLR
            // 
            this.tpassCLR.BackColor = System.Drawing.Color.SkyBlue;
            this.tpassCLR.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.tpassCLR.Location = new System.Drawing.Point(96, 40);
            this.tpassCLR.Name = "tpassCLR";
            this.tpassCLR.Size = new System.Drawing.Size(136, 16);
            this.tpassCLR.TabIndex = 176;
            this.tpassCLR.Visible = false;
            // 
            // lPDecry
            // 
            this.lPDecry.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lPDecry.Location = new System.Drawing.Point(376, 128);
            this.lPDecry.Name = "lPDecry";
            this.lPDecry.Size = new System.Drawing.Size(80, 23);
            this.lPDecry.TabIndex = 24;
            this.lPDecry.Visible = false;
            // 
            // lCancel
            // 
            this.lCancel.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.lCancel.Location = new System.Drawing.Point(376, 160);
            this.lCancel.Name = "lCancel";
            this.lCancel.Size = new System.Drawing.Size(80, 16);
            this.lCancel.TabIndex = 23;
            this.lCancel.Visible = false;
            // 
            // lpsEnc
            // 
            this.lpsEnc.BackColor = System.Drawing.Color.SkyBlue;
            this.lpsEnc.Location = new System.Drawing.Point(376, 184);
            this.lpsEnc.Name = "lpsEnc";
            this.lpsEnc.Size = new System.Drawing.Size(80, 16);
            this.lpsEnc.TabIndex = 27;
            this.lpsEnc.Visible = false;
            // 
            // lvprofile
            // 
            this.lvprofile.BackColor = System.Drawing.Color.PeachPuff;
            this.lvprofile.CheckBoxes = true;
            this.lvprofile.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.permT,
            this.mdlname,
            this.mdl_LID,
            this.u_m_LID});
            this.lvprofile.ForeColor = System.Drawing.Color.Black;
            this.lvprofile.FullRowSelect = true;
            this.lvprofile.GridLines = true;
            this.lvprofile.Location = new System.Drawing.Point(8, 72);
            this.lvprofile.MultiSelect = false;
            this.lvprofile.Name = "lvprofile";
            this.lvprofile.Size = new System.Drawing.Size(360, 368);
            this.lvprofile.TabIndex = 177;
            this.lvprofile.UseCompatibleStateImageBehavior = false;
            this.lvprofile.View = System.Windows.Forms.View.Details;
            this.lvprofile.SelectedIndexChanged += new System.EventHandler(this.lvprofile_SelectedIndexChanged);
            // 
            // permT
            // 
            this.permT.Text = "Allowed";
            this.permT.Width = 51;
            // 
            // mdlname
            // 
            this.mdlname.Text = "module Name";
            this.mdlname.Width = 277;
            // 
            // mdl_LID
            // 
            this.mdl_LID.Text = "";
            this.mdl_LID.Width = 0;
            // 
            // u_m_LID
            // 
            this.u_m_LID.Text = "";
            this.u_m_LID.Width = 0;
            // 
            // lndx
            // 
            this.lndx.BackColor = System.Drawing.Color.SkyBlue;
            this.lndx.Location = new System.Drawing.Point(288, 8);
            this.lndx.Name = "lndx";
            this.lndx.Size = new System.Drawing.Size(16, 16);
            this.lndx.TabIndex = 173;
            this.lndx.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(474, 56);
            this.panel2.TabIndex = 5;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(168, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 24);
            this.label3.TabIndex = 34;
            this.label3.Visible = false;
            this.label3.Click += new System.EventHandler(this.label3_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(0, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(144, 40);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(392, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(56, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 32;
            this.pictureBox1.TabStop = false;
            // 
            // grpLogin
            // 
            this.grpLogin.BackColor = System.Drawing.SystemColors.Control;
            this.grpLogin.Controls.Add(this.lWait);
            this.grpLogin.Controls.Add(this.grpLoad);
            this.grpLogin.Controls.Add(this.Svpwd);
            this.grpLogin.Controls.Add(this.tLoginUser);
            this.grpLogin.Controls.Add(this.logPswdEnc);
            this.grpLogin.Controls.Add(this.label4);
            this.grpLogin.Controls.Add(this.label5);
            this.grpLogin.Controls.Add(this.btnCancel);
            this.grpLogin.Controls.Add(this.btnLogin);
            this.grpLogin.Controls.Add(this.lndx);
            this.grpLogin.Controls.Add(this.tLoginPass);
            this.grpLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLogin.Location = new System.Drawing.Point(16, 88);
            this.grpLogin.Name = "grpLogin";
            this.grpLogin.Size = new System.Drawing.Size(448, 125);
            this.grpLogin.TabIndex = 26;
            this.grpLogin.TabStop = false;
            this.grpLogin.Enter += new System.EventHandler(this.grpLogin_Enter);
            // 
            // lWait
            // 
            this.lWait.BackColor = System.Drawing.SystemColors.Control;
            this.lWait.Font = new System.Drawing.Font("Viner Hand ITC", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lWait.ForeColor = System.Drawing.Color.Red;
            this.lWait.Location = new System.Drawing.Point(11, 96);
            this.lWait.Name = "lWait";
            this.lWait.Size = new System.Drawing.Size(421, 21);
            this.lWait.TabIndex = 338;
            this.lWait.Text = "Connecting........please Wait....!!!";
            this.lWait.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lWait.Visible = false;
            // 
            // grpLoad
            // 
            this.grpLoad.BackColor = System.Drawing.SystemColors.Control;
            this.grpLoad.Controls.Add(this.lblWait);
            this.grpLoad.Controls.Add(this.pbL);
            this.grpLoad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpLoad.Location = new System.Drawing.Point(8, 168);
            this.grpLoad.Name = "grpLoad";
            this.grpLoad.Size = new System.Drawing.Size(496, 80);
            this.grpLoad.TabIndex = 30;
            this.grpLoad.TabStop = false;
            this.grpLoad.Visible = false;
            // 
            // lblWait
            // 
            this.lblWait.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblWait.ForeColor = System.Drawing.Color.Blue;
            this.lblWait.Location = new System.Drawing.Point(12, 16);
            this.lblWait.Name = "lblWait";
            this.lblWait.Size = new System.Drawing.Size(156, 32);
            this.lblWait.TabIndex = 1;
            this.lblWait.Text = "Loading database...";
            this.lblWait.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pbL
            // 
            this.pbL.Location = new System.Drawing.Point(6, 48);
            this.pbL.Maximum = 1000;
            this.pbL.Name = "pbL";
            this.pbL.Size = new System.Drawing.Size(482, 26);
            this.pbL.TabIndex = 0;
            // 
            // Svpwd
            // 
            this.Svpwd.BackColor = System.Drawing.Color.SkyBlue;
            this.Svpwd.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Svpwd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Svpwd.Location = new System.Drawing.Point(64, 16);
            this.Svpwd.Name = "Svpwd";
            this.Svpwd.Size = new System.Drawing.Size(80, 16);
            this.Svpwd.TabIndex = 32;
            this.Svpwd.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.Svpwd.Visible = false;
            // 
            // tLoginUser
            // 
            this.tLoginUser.BackColor = System.Drawing.SystemColors.Control;
            this.tLoginUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tLoginUser.ForeColor = System.Drawing.Color.DarkRed;
            this.tLoginUser.Location = new System.Drawing.Point(120, 32);
            this.tLoginUser.Name = "tLoginUser";
            this.tLoginUser.Size = new System.Drawing.Size(160, 20);
            this.tLoginUser.TabIndex = 2;
            this.tLoginUser.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // logPswdEnc
            // 
            this.logPswdEnc.BackColor = System.Drawing.Color.SkyBlue;
            this.logPswdEnc.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.logPswdEnc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.logPswdEnc.Location = new System.Drawing.Point(-16, 16);
            this.logPswdEnc.Name = "logPswdEnc";
            this.logPswdEnc.Size = new System.Drawing.Size(104, 21);
            this.logPswdEnc.TabIndex = 31;
            this.logPswdEnc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.logPswdEnc.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(32, 57);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 23);
            this.label4.TabIndex = 28;
            this.label4.Text = "Password:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(8, 33);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(112, 23);
            this.label5.TabIndex = 26;
            this.label5.Text = "User Name:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.Control;
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(312, 56);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.SystemColors.Control;
            this.btnLogin.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnLogin.Location = new System.Drawing.Point(312, 29);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(96, 24);
            this.btnLogin.TabIndex = 3;
            this.btnLogin.Text = "&OK";
            this.btnLogin.UseVisualStyleBackColor = false;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // tLoginPass
            // 
            this.tLoginPass.BackColor = System.Drawing.SystemColors.Control;
            this.tLoginPass.ForeColor = System.Drawing.Color.DarkRed;
            this.tLoginPass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.tLoginPass.Location = new System.Drawing.Point(120, 56);
            this.tLoginPass.Name = "tLoginPass";
            this.tLoginPass.PasswordChar = '*';
            this.tLoginPass.Size = new System.Drawing.Size(160, 20);
            this.tLoginPass.TabIndex = 1;
            this.tLoginPass.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tLoginPass.TextChanged += new System.EventHandler(this.tLoginPass_TextChanged);
            // 
            // Passwd
            // 
            this.AcceptButton = this.btnLogin;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(474, 516);
            this.Controls.Add(this.grpUsers);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.grpLogin);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Passwd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "USER LOGIN";
            this.Load += new System.EventHandler(this.Passwd_Load);
            this.grpUsers.ResumeLayout(false);
            this.grpUsers.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSave)).EndInit();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpLogin.ResumeLayout(false);
            this.grpLogin.PerformLayout();
            this.grpLoad.ResumeLayout(false);
            this.ResumeLayout(false);

		}

	  

		#endregion


		private void Save_usr()
		{
			if (tUser.Text.Length >2  && tPass.Text.Length >2 ) 
			{
                lpsEnc.Text = StringCipher.Encrypt(tPass.Text, mykey);
				if (lndx.Text =="")
				{
					if (MainMDI.Find_One_Field("select userID from  PSM_users_New_New where [user]='" + tUser.Text +"'")==MainMDI.VIDE )  
						MainMDI.ExecSql("INSERT INTO PSM_users_New ([user],[user_pass], " + 
							" [type], " + " [inuse]) VALUES ('" +
							tUser.Text   + "', '" +
							lpsEnc.Text.Replace("'","''")    + "', '" +
							lprofile.Text      + "', " + " '0' )");
					else	MessageBox.Show("this User already exists !!!"); 
				}
				else  MainMDI.ExecSql("UPDATE PSM_users_New  SET  [user]='"+ tUser.Text + "', [user_pass]='" + lpsEnc.Text  + "', [type]='" + lprofile.Text  + "' where userID=" + toto.Text  ); 
				fill_lvUsers();
				lndx.Text ="";
			}
			
		}
		private void fill_lvUsers()
		{
			lvUsers.Items.Clear();  
			string stSql = "select * fROM PSM_users_New order by [user]";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ())
			{
				ListViewItem lvI =  lvUsers.Items.Add("");
				lvI.SubItems.Add(Oreadr["user"].ToString());
				lvI.SubItems.Add(Oreadr["type"].ToString());
				lvI.SubItems.Add(Oreadr["userID"].ToString());
				lvI.SubItems.Add(Oreadr["user_pass"].ToString());

				
			}
			OConn.Close(); 
				 
		}

		private void btndeco_Click(object sender, System.EventArgs e)
		{
			//string st=lPEncry.Text ;
			//	lPDecry.Text ="";
			//	for (int i=0;i<st.Length;i++)
			//	{
			//		int cod=Convert.ToByte(st[i]-35);
			//		lPDecry.Text = lPDecry.Text + Convert.ToChar(cod);
			//	}
			// if ( Encr_Decr('D',ref st)) lPDecry.Text=st;
		}

		private string Encr_Decrold(char c,string st )
		{
			int v = (c=='E') ? 35 : -35;
	  
			string stout  ="";
			 
			for (int i=0;i<st.Length;i++)
			{
				int cod=Convert.ToByte(st[i]+ v);
				stout = stout + Convert.ToChar(cod);
			}
			st=stout;
			if (stout.Length >0 ) return stout;
			else return MainMDI.VIDE ; 
		}


		private string Find_UserPass(string userName)
		{
			if (userName == "t" ) { MainMDI.UserID =2;  return("y");}
			else return "Rien";
		}

		private bool good_PswdOLD(string userName,string pswd)
		{
			Svpwd.Text =Encr_Decrold('D', MainMDI.Find_One_Field("select user_pass from  PSM_users_New where [user]='" + userName + "'"));
			return (MainMDI.Find_One_Field("select userID from  PSM_users_New where [user]='" + userName +"' and user_pass='" + pswd +  "'") != MainMDI.VIDE );  
			//  return (MainMDI.Find_One_Field("select userID from  PSM_users_New where [user]='" + userName +"' and user_pass='" + pswd +  "' and inuse=0") != MainMDI.VIDE );  
		}

        private bool good_Pswd(string userName, string pswd)
        {
          //  if (userName=="ede") return true;

            Svpwd.Text =pswd ;
           string DBpwd=  MainMDI.Find_One_Field("select user_pass from  PSM_users_New where [user]='" + userName + "'");
          if (DBpwd!=MainMDI.VIDE) DBpwd=   StringCipher.Decrypt(DBpwd, mykey);
          else return false;
          return (pswd == DBpwd);
      }

        private void button16_Click_1(object sender, EventArgs e)
        {
        //    string mykey = "primax";

         //   txENC.Text = StringCipher.Encrypt(txCLR.Text, mykey);
            //   txCLR2.Text =StringCipher.Decrypt(txENC.Text,mykey);
        }

        private void button17_Click(object sender, EventArgs e)
        {
         //   string mykey = "primax";
          //  txCLR2.Text = StringCipher.Decrypt(txENC.Text, mykey);
        }


        public static class StringCipher
        {
            private static readonly byte[] initVectorBytes = Encoding.ASCII.GetBytes("tu89geji340t89u2");

            private const int keysize = 256;

            public static string Encrypt(string plainText, string passPhrase)
            {
                byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream())
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                                {
                                    cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                    cryptoStream.FlushFinalBlock();
                                    byte[] cipherTextBytes = memoryStream.ToArray();
                                    return Convert.ToBase64String(cipherTextBytes);
                                }
                            }
                        }
                    }
                }
            }

            public static string Decrypt(string cipherText, string passPhrase)
            {
                byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }
        }


		private void load_Loc_ConfigOLD()
		{
            
			string ret=MainMDI.Find_One_Field("select PBSpath from PSM_Loc_Config ");
			if (ret==MainMDI.VIDE ) 
			{ 
				//MessageBox.Show(" User's Profile is Missed...contact your Admmin !!!..");
				MainMDI.PBSPath = @"C:\program files\PBSIZING\PBSIZING";
			}
			else MainMDI.PBSPath = @ret; 
			MainMDI.M_PBS_stCon =  @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MainMDI.PBSPath  + @"\PX_batlist.mdb" + @";Persist Security Info=False" ; //;Jet OLEDB:Database Password =" + "aaa999";
			ret=MainMDI.Find_One_Field("select curr_usr from PSM_Loc_Config ");	
			tLoginUser.Text = ret; 
			tLoginPass.Text ="123"; 

		}

  
		private void btnLogin_Click(object sender, System.EventArgs e)
		{


            lWait.Visible = true;
            this.Cursor = Cursors.WaitCursor;
            this.Refresh();
            if (MainMDI.ConnectBD())
            {
                lWait.Visible = false;
              
                denied = false;

                //	string st = Find_UserPass(tLoginUser.Text ) ;
                //if (tLoginPass.Text ==  Find_UserPass(tLoginUser.Text )) 


                string stGescom = MainMDI.Find_One_Field("select  s_stat from PSM_SYSETUP  ");
               MainMDI.Mach_Name = System.Environment.MachineName; 

                if (good_Pswd(tLoginUser.Text, tLoginPass.Text))
                {
                    if (tLoginUser.Text.ToLower() == "ede" || stGescom != "8" || tLoginUser.Text.ToLower() == "admin")
                    {
                        //MessageBox.Show ("User= " + tLoginUser.Text + "    Pass= " + st);
                        //string stID = MainMDI.Find_One_Field("select userID from  PSM_users_New where user='" + tLoginUser.Text +"' and inuse='0'");   

                        //	string stID = MainMDI.Find_One_Field("select userID from  PSM_users_New where [user]='" + tLoginUser.Text +"' and inuse='0'");  
                        string _st = "", stID = "", _portnb = "";
                        MainMDI.Find_2_Field("select userID, U_IPport from  PSM_users_New where [user]='" + tLoginUser.Text + "' and inuse='0'", ref stID, ref _portnb);
                        if (stID != MainMDI.VIDE)
                        {
                            MainMDI.IPportNB = _portnb;
                            MainMDI.IPadress = MainMDI.Get_stationIP(MainMDI.Mach_Name);
                            MainMDI.UserID = Convert.ToInt32(stID);
                            MainMDI.User = tLoginUser.Text.ToLower();
                            if (tLoginUser.Text.ToLower() != "unlock")
                            {
                            //  //  MainMDI.ExecSql("delete PSM_Loc_Config where Mach_Name='" + MainMDI.Mach_Name + "'");
                            //    MainMDI.ExecSql("delete PSM_Loc_Config where [curr_usr]='" + MainMDI.User + "'");
                           //     MainMDI.ExecSql("INSERT INTO PSM_Loc_Config ([Mach_Name],[PBSpath],[curr_usr],[DymoName], [WQfiles], [PDFfiles]) VALUES ('" + MainMDI.Mach_Name + "','" + MainMDI.PBSPath + "','" + MainMDI.User + "','" + MainMDI.DYMOName + "','" + MainMDI.WQfiles + "','" + MainMDI.PDF_READER + "')");
                               // //"Insert UPDATE PSM_Loc_Config  SET [curr_usr]='" + tLoginUser.Text   + "'" )  ; 

                                MainMDI.profile = MainMDI.Find_One_Field("select type from  PSM_users_New where userID=" + stID)[0];
                                //	MainMDI.profile = MainMDI.Find_2_Field("select type,mod_del from  PSM_users_New where userID=" + stID,MainMDI.profile,MainMDI.mode) ; 

                                if (MainMDI.profile != 'S' && MainMDI.profile != 'A') MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='1' where userID=" + stID);
                            }
                            if (!MainMDI.login)
                            {
                                grpLoad.Visible = true;
                                grpLoad.Refresh();
                                pbL.Value = 0;
                                //	MainMDI.frm_Qte = new Quote(0,"*",'E');
                                pbL.Value += 200;
                                //	MainMDI.frm_Ord = new Order("*");  
                                pbL.Value += 200;
                                //  .Dispose(); 
                            }

                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("User: '" + tLoginUser.Text + "'   is LOCKED , use 'unlock' user to UNLOCK it ");
                            //	string mch= MainMDI.Find_One_Field("select machNm  from PSM_Whodo where UserNm='" + tLoginUser.Text + "'");
                            //	if ( mch==MainMDI.VIDE ) MessageBox.Show("User: '" + tLoginUser.Text + "'   is LOCKED , use 'unlock' user to UNLOCK it ");
                            //	      else               MessageBox.Show(tLoginUser.Text + " is opening GESCON on station='" + mch + "'");
                            nbtry = 4;
                        }
                    }
                    else
                    {
                        MessageBox.Show("Sorry, PGESCOM is under maintenance, contact Administrator...!!! ", "                           ALERT        ");
                        nbtry = 3;
                    }

                }
                else
                {
                    MessageBox.Show(" User Name / Password  Invalid OR user Disabled .....Call your Admin... ");
                    tPass.Text = "";
                    tLoginPass.Focus();
                    //tLoginUser.Focus ();
                    nbtry++;

                }
                if (nbtry == 3) { denied = true; this.Close(); }

                this.Cursor = Cursors.Default;
            }
            else MessageBox.Show("Sorry, Cannot Connect to DATABASE, pls contact Admin URGENTLY !!!! \n" + MainMDI.SQLDB, "                URGENT ALERT        ",MessageBoxButtons.OK ,MessageBoxIcon.Stop );
            lWait.Visible = false;
            this.Cursor = Cursors.Default;
            this.Refresh();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{   
			lCancel.Text ="C";
			denied=true;

			Application.Exit ();
		}

		private void grpLogin_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			lprofile.Text ="S";
			btnProf.Visible =false;
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			lprofile.Text ="N";
			btnProf.Visible =false;
		}

		private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
		{
			lprofile.Text ="R";
		}

		private void tPass_TextChanged(object sender, System.EventArgs e)
		{
          //  lpsEnc.Text = StringCipher.Decrypt(tPass.Text, mykey); //Encr_Decrold('E', tPass.Text); 
		}

		private void picSave_Click(object sender, System.EventArgs e)
		{
			Save_usr(); 
			tPass.Text ="";
			lpsEnc.Text ="";
			tUser.Text ="";
			radioButton2.Checked =true;
		}

		private void lvUsers_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lvUsers_DoubleClick(object sender, System.EventArgs e)
		{
		
			if (lvUsers.SelectedItems.Count ==1) 
			{
				tUser.Text = lvUsers.SelectedItems[0].SubItems[1].Text ; 
				switch (lvUsers.SelectedItems[0].SubItems[2].Text[0])
				{
					case 'N': 
						radioButton2.Checked =true;
						btnProf.Visible =true;
						break;
					case 'S': 
						radioButton1.Checked =true;
						break;
					case 'R': 
						radioButton3.Checked =true;
						break;
				} 
			
				lndx.Text = lvUsers.SelectedItems[0].Index.ToString(); 
				lusr_LID.Text = lvUsers.SelectedItems[0].SubItems[3].Text ; 
				//	tPass.Text = Encr_Decr('D', lvUsers.SelectedItems[0].SubItems[4].Text)  ;
                tpassCLR.Text = StringCipher.Decrypt(lvUsers.SelectedItems[0].SubItems[4].Text, mykey);// Encr_Decr('D', lvUsers.SelectedItems[0].SubItems[4].Text);
				tPass.Text = tpassCLR.Text  ;
				toto.Text  = lvUsers.SelectedItems[0].SubItems[3].Text ;
				
			}
		}

		private void tLoginPass_TextChanged(object sender, System.EventArgs e)
		{
			//logPswdEnc.Text = Encr_Decr('E',  tLoginPass.Text ); 
		}

		private void Passwd_Load(object sender, System.EventArgs e)
		{
			//if (In_Type_dlg =='L') tLoginPass.Focus () ;
			//else tUser.Focus() ; 
           // if (!load_Loc_Config()) btnCancel_Click(sender,e);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			
		}

		private void label3_Click(object sender, System.EventArgs e)
		{
			//Svpwd.Visible = !Svpwd.Visible;
		 	tpassCLR.Visible = !tpassCLR.Visible; 
			
		}
		private void disp_profile(bool pr_st)
		{
			this.Height =(pr_st ) ? 552 :360;
			grpUsers.Height =(pr_st ) ? 448 :256;

			lvUsers.Visible =!pr_st ;
			picSave.Visible =!pr_st ;
			lvprofile.Visible =pr_st; 
			btnPcancel.Visible =pr_st;
			btnSav.Visible =pr_st;
			


		}
		private void fill_mdls()
		{
					

			lvprofile.Items.Clear();  
			string stSql = " SELECT m_LID , m_Desc FROM PSM_AS_modules ORDER BY m_LID  ";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ())
			{
				ListViewItem lvI =  lvprofile.Items.Add("");
				lvI.SubItems.Add(Oreadr["m_Desc"].ToString());
				lvI.SubItems.Add(Oreadr["m_LID"].ToString());
				lvI.SubItems.Add("");
				//	lvI.SubItems.Add(Oreadr[""].ToString());

				
			}
			OConn.Close(); 

		}
		private void init_lvprofile()
		{
			for (int i=0;i<lvprofile.Items.Count ;i++) 
			{
				lvprofile.Items[i].Checked =false;
				lvprofile.Items[i].SubItems[3].Text =""; 
			}
		}

		private void fill_profile(string _usr)
		{
			init_lvprofile ();
	
			string stSql = " SELECT PSM_AS_UsrMudls.lineID, PSM_AS_modules.m_LID " +
				" FROM  PSM_AS_UsrMudls INNER JOIN PSM_users_New ON PSM_AS_UsrMudls.UsrLID = PSM_users_New.userID INNER JOIN PSM_AS_modules ON PSM_AS_UsrMudls.mdl_LID = PSM_AS_modules.m_LID " +
				" WHERE   PSM_users_New.[user] = '" + _usr + "'ORDER BY PSM_AS_modules.m_LID ";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ())
			{
				for (int i=0;i<lvprofile.Items.Count ;i++)
					if (lvprofile.Items[i].SubItems[2].Text == Oreadr["m_LID"].ToString()) 
					{
						lvprofile.Items[i].Checked =true;
						lvprofile.Items[i].SubItems[3].Text = Oreadr["lineID"].ToString(); 
					}
			}
			OConn.Close(); 
		}	
	

		private void btnProf_Click(object sender, System.EventArgs e)
		{
			if (tUser.Text.Length >2)
			{
				fill_profile(tUser.Text );
				disp_profile(true);
				btnProf.Visible = false;
			}
			else MessageBox.Show("Invalid User Name....(L<3)..."); 
		}

		private void btnSav_Click(object sender, System.EventArgs e)
		{
			string stSql="";
			for (int i=0;i<lvprofile.Items.Count ;i++)
			{
				
				if (lvprofile.Items[i].Checked ) 
				{
					if (lvprofile.Items[i].SubItems[3].Text == "" ) 
						stSql ="INSERT INTO PSM_AS_UsrMudls ([UsrLID],[mdl_LID]) VALUES (" +
																		lusr_LID.Text   + ", " + lvprofile.Items[i].SubItems[2].Text  + ")" ;
				}
				else if (lvprofile.Items[i].SubItems[3].Text != "" ) stSql = "delete  PSM_AS_UsrMudls where lineID= " +lvprofile.Items[i].SubItems[3].Text ;
				if (stSql !="") 
				{
					MainMDI.ExecSql(stSql);
					MainMDI.Write_JFS(stSql);
				}
				stSql="";
			}
			disp_profile(false); 
		}

		private void button1_Click_1(object sender, System.EventArgs e)
		{
			disp_profile(false); 
		}

		private void lvprofile_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


        private bool load_Loc_Config()
        {

           string Mach_Name = System.Environment.MachineName;

            bool loaded = false;

         //   if (MainMDI.Find_One_Field("select * fROM PSM_Loc_Config where Mach_Name='" + Mach_Name + "'") !=MainMDI.VIDE) loaded = load_Profile(Mach_Name);
            if (MainMDI.Find_One_Field("select * fROM PSM_Loc_Config where curr_usr='" + MainMDI.User.ToLower ()   + "'") != MainMDI.VIDE) loaded = load_Profile(Mach_Name);
            else loaded = load_Profile("*");

            if (!loaded) MessageBox.Show("Loading Initial Config Failed....Contact Admin !");
            return loaded;


        }


        private bool load_Profile(string userName)
        {

            bool loaded = false;
            string stSql = "select * fROM PSM_Loc_Config where curr_usr='" + userName  + "'";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {


                MainMDI.WQfiles = Oreadr["WQfiles"].ToString();
                if (MainMDI.WQfiles == "") MainMDI.WQfiles = @"H:\Sales\PSM_Quotes";
                MainMDI.PBSPath = Oreadr["PBSpath"].ToString();
                MainMDI.M_PBS_stCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MainMDI.PBSPath + @"\PX_batlist.mdb" + @";Persist Security Info=False"; //;Jet OLEDB:Database Password =" + "aaa999";
                MainMDI.DYMOName = Oreadr["DymoName"].ToString();
                MainMDI.Def_LoginUser = Oreadr["curr_usr"].ToString();
                MainMDI.Def_LoginPass = "123";


                loaded = true;

            }
            OConn.Close();
            Oreadr.Close();
            return loaded;
        }
        private bool load_ProfileOLD(string Cptr_Nme)
        {

            bool loaded = false;
            string stSql = "select * fROM PSM_Loc_Config where Mach_Name='" + Cptr_Nme + "'";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {


                MainMDI.WQfiles = Oreadr["WQfiles"].ToString();
                if (MainMDI.WQfiles == "") MainMDI.WQfiles = @"H:\Sales\PSM_Quotes";
                MainMDI.PBSPath = Oreadr["PBSpath"].ToString();
                MainMDI.M_PBS_stCon = @"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + MainMDI.PBSPath + @"\PX_batlist.mdb" + @";Persist Security Info=False"; //;Jet OLEDB:Database Password =" + "aaa999";
                MainMDI.DYMOName = Oreadr["DymoName"].ToString();
                MainMDI.Def_LoginUser = Oreadr["curr_usr"].ToString();
                MainMDI.Def_LoginPass = "123";


                loaded = true;

            }
            OConn.Close();
            Oreadr.Close();
            return loaded;
        }

        private void grpUsers_Enter(object sender, EventArgs e)
        {

        }

	

	

	



	

	


	           
	}
}
