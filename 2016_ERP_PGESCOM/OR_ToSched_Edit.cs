using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb ;
using EAHLibs;
using System.Data.SqlClient ;
namespace PGESCOM
{
	/// <summary>
	/// Summary description for dlgAdrs.
	/// </summary>
	public class OR_ToSched_Edit : System.Windows.Forms.Form
	{

        string in_scd_LID=""; //  [,] arr_STD_Opt = new string[50, 2];


        //kim
		   private string[,] In_arr_Info;
                char In_EM='E';
	//	   private string MainMDI.M_stCon;
           //kim
        private GroupBox grpData;
        private Label label2;
        public TextBox t3;
        private Label label1;
        public TextBox t1;
        private Label label65;
        public ComboBox CB_Panel_Emp;
        public TextBox t0;
        private Label label11;
        public TextBox t11;
        private Label label12;
        public TextBox t10;
        private Label label13;
        public TextBox t9;
        private Label label14;
        public TextBox t7;
        private Label label15;
        public TextBox t6;
        private Label label4;
        public TextBox t5;
        private Label label5;
        public TextBox t55;
        private Label label7;
        public TextBox t4;
        private Panel panel1;
        private Panel panel2;
        private Label label9;
        public TextBox t12;
        private Label label3;
        public TextBox t13;
        private Label label6;
        public TextBox t14;
        private Label label21;
        private Label label22;
        public TextBox t8;
        private Label label16;
        public TextBox t2;
        private Label label17;
        public TextBox txNotes;
        private Label label24;
        private Button btnOK;
        private Button btnCancel;
        private Button button1;
        private DateTimePicker dt_SPanel;
        private Button btnNm1ED;
        private Button button4;
        private DateTimePicker dt_ECab;
        private DateTimePicker dt_SCab;
        private Button button3;
        private DateTimePicker dt_EPanel;
        public ComboBox CB_Cab_Emp;
        private static Lib1 Tools = new Lib1();
        private DateTimePicker dpDelvry;
        private Button button6;
        private CheckBox chk_multi_Cab;
        private CheckBox chk_multi_panel;
        private Panel panel4;
        private Panel panel3;
        private GroupBox grpPanel;
        private GroupBox grpCAB;
        private Label label8;
        private Button btnBRopt;
        public TextBox txOPTtm;
        private Label label25;
        private Button btnBRstd;
        public TextBox txSTDtm;
        private Label label36;
        private Label label35;
        private Label label33;
        private Label label34;
        private Button btnBRoptCab;
        public TextBox txOPTtmCAB;
        private Label label37;
        private Button btnBRstdCab;
        public TextBox txSTDtmCab;
        private Label label38;
        private Label label39;
        public TextBox t111;
        private Label label40;
        public TextBox t15;
        private Label label10;
        public TextBox calTm_Cab;
        private Label label44;
        public TextBox calTm_Pnl;
        private Button button5;
        private Button button2;
        private Button button7;
        private Button button8;
        private Label label18;
        private Label label20;
        private Label label19;
        private DateTimePicker dtm4;
        private DateTimePicker dtm3;
        private DateTimePicker dtm2;
        private DateTimePicker dtm1;
        private Label lPanDiff;
        private Label lPanelDiff;
        private Label label28;
        private Label label29;
        public TextBox txCmin;
        public TextBox txChh;
        private Label label30;
        private Label label27;
        private Label label26;
        private Label label23;
        public TextBox txPmin;
        public TextBox txPhh;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public OR_ToSched_Edit(ref string[,] x_Arr_INFO,char x_EM, string x_scd_LID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
              In_arr_Info  = x_Arr_INFO ;
		       In_EM =x_EM ;
               in_scd_LID = x_scd_LID;
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OR_ToSched_Edit));
            this.grpData = new System.Windows.Forms.GroupBox();
            this.grpCAB = new System.Windows.Forms.GroupBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.label28 = new System.Windows.Forms.Label();
            this.label29 = new System.Windows.Forms.Label();
            this.txCmin = new System.Windows.Forms.TextBox();
            this.txChh = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.lPanDiff = new System.Windows.Forms.Label();
            this.dtm4 = new System.Windows.Forms.DateTimePicker();
            this.dtm3 = new System.Windows.Forms.DateTimePicker();
            this.label18 = new System.Windows.Forms.Label();
            this.button7 = new System.Windows.Forms.Button();
            this.button8 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.calTm_Cab = new System.Windows.Forms.TextBox();
            this.label39 = new System.Windows.Forms.Label();
            this.t111 = new System.Windows.Forms.TextBox();
            this.label33 = new System.Windows.Forms.Label();
            this.label34 = new System.Windows.Forms.Label();
            this.btnBRoptCab = new System.Windows.Forms.Button();
            this.txOPTtmCAB = new System.Windows.Forms.TextBox();
            this.label37 = new System.Windows.Forms.Label();
            this.btnBRstdCab = new System.Windows.Forms.Button();
            this.txSTDtmCab = new System.Windows.Forms.TextBox();
            this.label38 = new System.Windows.Forms.Label();
            this.dt_SCab = new System.Windows.Forms.DateTimePicker();
            this.chk_multi_Cab = new System.Windows.Forms.CheckBox();
            this.button4 = new System.Windows.Forms.Button();
            this.dt_ECab = new System.Windows.Forms.DateTimePicker();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.t13 = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.t14 = new System.Windows.Forms.TextBox();
            this.label21 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.CB_Cab_Emp = new System.Windows.Forms.ComboBox();
            this.t12 = new System.Windows.Forms.TextBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.t8 = new System.Windows.Forms.TextBox();
            this.t7 = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.txNotes = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label24 = new System.Windows.Forms.Label();
            this.t6 = new System.Windows.Forms.TextBox();
            this.t5 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dpDelvry = new System.Windows.Forms.DateTimePicker();
            this.t0 = new System.Windows.Forms.TextBox();
            this.button6 = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.t2 = new System.Windows.Forms.TextBox();
            this.t55 = new System.Windows.Forms.TextBox();
            this.label17 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.t4 = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.t1 = new System.Windows.Forms.TextBox();
            this.t3 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.grpPanel = new System.Windows.Forms.GroupBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label27 = new System.Windows.Forms.Label();
            this.label26 = new System.Windows.Forms.Label();
            this.label23 = new System.Windows.Forms.Label();
            this.txPmin = new System.Windows.Forms.TextBox();
            this.txPhh = new System.Windows.Forms.TextBox();
            this.lPanelDiff = new System.Windows.Forms.Label();
            this.dtm2 = new System.Windows.Forms.DateTimePicker();
            this.dtm1 = new System.Windows.Forms.DateTimePicker();
            this.label20 = new System.Windows.Forms.Label();
            this.label19 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label44 = new System.Windows.Forms.Label();
            this.calTm_Pnl = new System.Windows.Forms.TextBox();
            this.label40 = new System.Windows.Forms.Label();
            this.t15 = new System.Windows.Forms.TextBox();
            this.label36 = new System.Windows.Forms.Label();
            this.label35 = new System.Windows.Forms.Label();
            this.btnBRopt = new System.Windows.Forms.Button();
            this.txOPTtm = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.btnBRstd = new System.Windows.Forms.Button();
            this.txSTDtm = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.dt_SPanel = new System.Windows.Forms.DateTimePicker();
            this.chk_multi_panel = new System.Windows.Forms.CheckBox();
            this.dt_EPanel = new System.Windows.Forms.DateTimePicker();
            this.button3 = new System.Windows.Forms.Button();
            this.btnNm1ED = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.t10 = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.t11 = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.CB_Panel_Emp = new System.Windows.Forms.ComboBox();
            this.t9 = new System.Windows.Forms.TextBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpData.SuspendLayout();
            this.grpCAB.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.panel3.SuspendLayout();
            this.grpPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpData
            // 
            this.grpData.BackColor = System.Drawing.Color.Honeydew;
            this.grpData.Controls.Add(this.grpCAB);
            this.grpData.Controls.Add(this.panel4);
            this.grpData.Controls.Add(this.panel3);
            this.grpData.Controls.Add(this.grpPanel);
            this.grpData.Controls.Add(this.btnOK);
            this.grpData.Controls.Add(this.btnCancel);
            this.grpData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpData.Location = new System.Drawing.Point(0, 0);
            this.grpData.Name = "grpData";
            this.grpData.Size = new System.Drawing.Size(932, 506);
            this.grpData.TabIndex = 367;
            this.grpData.TabStop = false;
            // 
            // grpCAB
            // 
            this.grpCAB.Controls.Add(this.panel2);
            this.grpCAB.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpCAB.Location = new System.Drawing.Point(455, 131);
            this.grpCAB.Name = "grpCAB";
            this.grpCAB.Size = new System.Drawing.Size(471, 311);
            this.grpCAB.TabIndex = 423;
            this.grpCAB.TabStop = false;
            this.grpCAB.Text = "CABINET";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.Gold;
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.label28);
            this.panel2.Controls.Add(this.label29);
            this.panel2.Controls.Add(this.txCmin);
            this.panel2.Controls.Add(this.txChh);
            this.panel2.Controls.Add(this.label30);
            this.panel2.Controls.Add(this.lPanDiff);
            this.panel2.Controls.Add(this.dtm4);
            this.panel2.Controls.Add(this.dtm3);
            this.panel2.Controls.Add(this.label18);
            this.panel2.Controls.Add(this.button7);
            this.panel2.Controls.Add(this.button8);
            this.panel2.Controls.Add(this.label10);
            this.panel2.Controls.Add(this.calTm_Cab);
            this.panel2.Controls.Add(this.label39);
            this.panel2.Controls.Add(this.t111);
            this.panel2.Controls.Add(this.label33);
            this.panel2.Controls.Add(this.label34);
            this.panel2.Controls.Add(this.btnBRoptCab);
            this.panel2.Controls.Add(this.txOPTtmCAB);
            this.panel2.Controls.Add(this.label37);
            this.panel2.Controls.Add(this.btnBRstdCab);
            this.panel2.Controls.Add(this.txSTDtmCab);
            this.panel2.Controls.Add(this.label38);
            this.panel2.Controls.Add(this.dt_SCab);
            this.panel2.Controls.Add(this.chk_multi_Cab);
            this.panel2.Controls.Add(this.button4);
            this.panel2.Controls.Add(this.dt_ECab);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.t13);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.t14);
            this.panel2.Controls.Add(this.label21);
            this.panel2.Controls.Add(this.label22);
            this.panel2.Controls.Add(this.CB_Cab_Emp);
            this.panel2.Controls.Add(this.t12);
            this.panel2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel2.Location = new System.Drawing.Point(6, 19);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(455, 286);
            this.panel2.TabIndex = 415;
            // 
            // label28
            // 
            this.label28.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label28.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label28.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label28.Location = new System.Drawing.Point(172, 145);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(22, 14);
            this.label28.TabIndex = 480;
            this.label28.Text = "Min";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label29
            // 
            this.label29.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label29.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label29.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label29.Location = new System.Drawing.Point(126, 145);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(12, 14);
            this.label29.TabIndex = 479;
            this.label29.Text = "H";
            this.label29.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txCmin
            // 
            this.txCmin.BackColor = System.Drawing.Color.White;
            this.txCmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txCmin.ForeColor = System.Drawing.Color.Red;
            this.txCmin.Location = new System.Drawing.Point(138, 139);
            this.txCmin.MaxLength = 49;
            this.txCmin.Multiline = true;
            this.txCmin.Name = "txCmin";
            this.txCmin.Size = new System.Drawing.Size(34, 27);
            this.txCmin.TabIndex = 478;
            this.txCmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txCmin.TextChanged += new System.EventHandler(this.txCmin_TextChanged);
            // 
            // txChh
            // 
            this.txChh.BackColor = System.Drawing.Color.White;
            this.txChh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txChh.ForeColor = System.Drawing.Color.Red;
            this.txChh.Location = new System.Drawing.Point(92, 139);
            this.txChh.MaxLength = 49;
            this.txChh.Multiline = true;
            this.txChh.Name = "txChh";
            this.txChh.Size = new System.Drawing.Size(34, 27);
            this.txChh.TabIndex = 477;
            this.txChh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txChh.TextChanged += new System.EventHandler(this.txChh_TextChanged);
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Gold;
            this.label30.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label30.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label30.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label30.Location = new System.Drawing.Point(14, 144);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(78, 21);
            this.label30.TabIndex = 476;
            this.label30.Text = "Real Time:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lPanDiff
            // 
            this.lPanDiff.BackColor = System.Drawing.Color.Red;
            this.lPanDiff.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lPanDiff.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPanDiff.ForeColor = System.Drawing.Color.White;
            this.lPanDiff.Location = new System.Drawing.Point(355, 209);
            this.lPanDiff.Name = "lPanDiff";
            this.lPanDiff.Size = new System.Drawing.Size(58, 25);
            this.lPanDiff.TabIndex = 470;
            this.lPanDiff.Text = "999";
            this.lPanDiff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtm4
            // 
            this.dtm4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtm4.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtm4.Location = new System.Drawing.Point(354, 54);
            this.dtm4.Name = "dtm4";
            this.dtm4.ShowUpDown = true;
            this.dtm4.Size = new System.Drawing.Size(96, 20);
            this.dtm4.TabIndex = 469;
            this.dtm4.Visible = false;
            this.dtm4.ValueChanged += new System.EventHandler(this.dtm4_ValueChanged);
            // 
            // dtm3
            // 
            this.dtm3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtm3.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtm3.Location = new System.Drawing.Point(354, 26);
            this.dtm3.Name = "dtm3";
            this.dtm3.ShowUpDown = true;
            this.dtm3.Size = new System.Drawing.Size(96, 20);
            this.dtm3.TabIndex = 468;
            this.dtm3.Visible = false;
            this.dtm3.ValueChanged += new System.EventHandler(this.dtm3_ValueChanged);
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.Color.Gold;
            this.label18.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label18.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label18.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label18.Location = new System.Drawing.Point(19, 237);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(135, 24);
            this.label18.TabIndex = 467;
            this.label18.Text = "Real Time:";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(220, 53);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(33, 23);
            this.button7.TabIndex = 466;
            this.button7.Text = "...";
            this.button7.UseVisualStyleBackColor = true;
            this.button7.Click += new System.EventHandler(this.button7_Click);
            // 
            // button8
            // 
            this.button8.Location = new System.Drawing.Point(220, 25);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(33, 23);
            this.button8.TabIndex = 465;
            this.button8.Text = "...";
            this.button8.UseVisualStyleBackColor = true;
            this.button8.Click += new System.EventHandler(this.button8_Click);
            // 
            // label10
            // 
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(237, 205);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(22, 14);
            this.label10.TabIndex = 456;
            this.label10.Text = "Min";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // calTm_Cab
            // 
            this.calTm_Cab.BackColor = System.Drawing.Color.PeachPuff;
            this.calTm_Cab.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calTm_Cab.ForeColor = System.Drawing.Color.Black;
            this.calTm_Cab.Location = new System.Drawing.Point(154, 199);
            this.calTm_Cab.MaxLength = 49;
            this.calTm_Cab.Multiline = true;
            this.calTm_Cab.Name = "calTm_Cab";
            this.calTm_Cab.ReadOnly = true;
            this.calTm_Cab.Size = new System.Drawing.Size(83, 27);
            this.calTm_Cab.TabIndex = 455;
            this.calTm_Cab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.calTm_Cab.TextChanged += new System.EventHandler(this.calTm_Cab_TextChanged);
            // 
            // label39
            // 
            this.label39.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label39.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label39.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label39.Location = new System.Drawing.Point(237, 237);
            this.label39.Name = "label39";
            this.label39.Size = new System.Drawing.Size(22, 14);
            this.label39.TabIndex = 454;
            this.label39.Text = "Min";
            this.label39.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t111
            // 
            this.t111.BackColor = System.Drawing.Color.Khaki;
            this.t111.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t111.ForeColor = System.Drawing.Color.Red;
            this.t111.Location = new System.Drawing.Point(154, 231);
            this.t111.MaxLength = 49;
            this.t111.Multiline = true;
            this.t111.Name = "t111";
            this.t111.ReadOnly = true;
            this.t111.Size = new System.Drawing.Size(83, 27);
            this.t111.TabIndex = 453;
            this.t111.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.t111.TextChanged += new System.EventHandler(this.t111_TextChanged);
            // 
            // label33
            // 
            this.label33.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label33.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label33.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label33.Location = new System.Drawing.Point(159, 111);
            this.label33.Name = "label33";
            this.label33.Size = new System.Drawing.Size(22, 14);
            this.label33.TabIndex = 452;
            this.label33.Text = "Min";
            this.label33.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label34
            // 
            this.label34.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label34.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label34.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label34.Location = new System.Drawing.Point(159, 85);
            this.label34.Name = "label34";
            this.label34.Size = new System.Drawing.Size(22, 14);
            this.label34.TabIndex = 451;
            this.label34.Text = "Min";
            this.label34.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBRoptCab
            // 
            this.btnBRoptCab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBRoptCab.Location = new System.Drawing.Point(181, 107);
            this.btnBRoptCab.Name = "btnBRoptCab";
            this.btnBRoptCab.Size = new System.Drawing.Size(62, 23);
            this.btnBRoptCab.TabIndex = 450;
            this.btnBRoptCab.Text = "Browse...";
            this.btnBRoptCab.UseVisualStyleBackColor = true;
            this.btnBRoptCab.Click += new System.EventHandler(this.btnBRoptCab_Click);
            // 
            // txOPTtmCAB
            // 
            this.txOPTtmCAB.BackColor = System.Drawing.Color.PeachPuff;
            this.txOPTtmCAB.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txOPTtmCAB.ForeColor = System.Drawing.Color.Black;
            this.txOPTtmCAB.Location = new System.Drawing.Point(92, 108);
            this.txOPTtmCAB.MaxLength = 49;
            this.txOPTtmCAB.Multiline = true;
            this.txOPTtmCAB.Name = "txOPTtmCAB";
            this.txOPTtmCAB.ReadOnly = true;
            this.txOPTtmCAB.Size = new System.Drawing.Size(67, 20);
            this.txOPTtmCAB.TabIndex = 449;
            this.txOPTtmCAB.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label37
            // 
            this.label37.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label37.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label37.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label37.Location = new System.Drawing.Point(16, 111);
            this.label37.Name = "label37";
            this.label37.Size = new System.Drawing.Size(76, 14);
            this.label37.TabIndex = 448;
            this.label37.Text = "Options :";
            this.label37.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBRstdCab
            // 
            this.btnBRstdCab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBRstdCab.Location = new System.Drawing.Point(181, 81);
            this.btnBRstdCab.Name = "btnBRstdCab";
            this.btnBRstdCab.Size = new System.Drawing.Size(62, 23);
            this.btnBRstdCab.TabIndex = 447;
            this.btnBRstdCab.Text = "Browse...";
            this.btnBRstdCab.UseVisualStyleBackColor = true;
            this.btnBRstdCab.Click += new System.EventHandler(this.btnBRstdCab_Click);
            // 
            // txSTDtmCab
            // 
            this.txSTDtmCab.BackColor = System.Drawing.Color.PeachPuff;
            this.txSTDtmCab.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txSTDtmCab.ForeColor = System.Drawing.Color.Black;
            this.txSTDtmCab.Location = new System.Drawing.Point(92, 82);
            this.txSTDtmCab.MaxLength = 49;
            this.txSTDtmCab.Multiline = true;
            this.txSTDtmCab.Name = "txSTDtmCab";
            this.txSTDtmCab.ReadOnly = true;
            this.txSTDtmCab.Size = new System.Drawing.Size(67, 20);
            this.txSTDtmCab.TabIndex = 446;
            this.txSTDtmCab.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label38
            // 
            this.label38.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label38.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label38.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label38.Location = new System.Drawing.Point(8, 85);
            this.label38.Name = "label38";
            this.label38.Size = new System.Drawing.Size(84, 14);
            this.label38.TabIndex = 445;
            this.label38.Text = "Standard :";
            this.label38.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt_SCab
            // 
            this.dt_SCab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_SCab.Location = new System.Drawing.Point(253, 26);
            this.dt_SCab.Name = "dt_SCab";
            this.dt_SCab.Size = new System.Drawing.Size(101, 20);
            this.dt_SCab.TabIndex = 432;
            this.dt_SCab.Visible = false;
            this.dt_SCab.ValueChanged += new System.EventHandler(this.dt_SCab_ValueChanged);
            // 
            // chk_multi_Cab
            // 
            this.chk_multi_Cab.AutoSize = true;
            this.chk_multi_Cab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_multi_Cab.Location = new System.Drawing.Point(337, 3);
            this.chk_multi_Cab.Name = "chk_multi_Cab";
            this.chk_multi_Cab.Size = new System.Drawing.Size(83, 17);
            this.chk_multi_Cab.TabIndex = 444;
            this.chk_multi_Cab.Text = "multi-Names";
            this.chk_multi_Cab.UseVisualStyleBackColor = true;
            this.chk_multi_Cab.Visible = false;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(706, 41);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(31, 23);
            this.button4.TabIndex = 441;
            this.button4.Text = "...";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Visible = false;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // dt_ECab
            // 
            this.dt_ECab.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_ECab.Location = new System.Drawing.Point(253, 54);
            this.dt_ECab.Name = "dt_ECab";
            this.dt_ECab.Size = new System.Drawing.Size(101, 20);
            this.dt_ECab.TabIndex = 437;
            this.dt_ECab.Visible = false;
            this.dt_ECab.ValueChanged += new System.EventHandler(this.dt_ECab_ValueChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 0);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(31, 23);
            this.button1.TabIndex = 424;
            this.button1.Text = "...";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.Color.Gold;
            this.label9.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(553, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 19);
            this.label9.TabIndex = 417;
            this.label9.Text = "CABINET  ";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Gold;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(7, 6);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 14);
            this.label3.TabIndex = 389;
            this.label3.Text = "Name :";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t13
            // 
            this.t13.BackColor = System.Drawing.Color.FloralWhite;
            this.t13.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t13.ForeColor = System.Drawing.Color.Black;
            this.t13.Location = new System.Drawing.Point(91, 26);
            this.t13.MaxLength = 49;
            this.t13.Multiline = true;
            this.t13.Name = "t13";
            this.t13.ReadOnly = true;
            this.t13.Size = new System.Drawing.Size(129, 20);
            this.t13.TabIndex = 392;
            this.t13.TextChanged += new System.EventHandler(this.t13_TextChanged);
            this.t13.DoubleClick += new System.EventHandler(this.t13_DoubleClick);
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.Gold;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(15, 29);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 14);
            this.label6.TabIndex = 391;
            this.label6.Text = "Cabinet Start :";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t14
            // 
            this.t14.BackColor = System.Drawing.Color.FloralWhite;
            this.t14.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t14.ForeColor = System.Drawing.Color.Black;
            this.t14.Location = new System.Drawing.Point(91, 54);
            this.t14.MaxLength = 49;
            this.t14.Multiline = true;
            this.t14.Name = "t14";
            this.t14.ReadOnly = true;
            this.t14.Size = new System.Drawing.Size(129, 20);
            this.t14.TabIndex = 394;
            this.t14.TextChanged += new System.EventHandler(this.t14_TextChanged);
            this.t14.DoubleClick += new System.EventHandler(this.t14_DoubleClick);
            // 
            // label21
            // 
            this.label21.BackColor = System.Drawing.Color.Gold;
            this.label21.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label21.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label21.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label21.Location = new System.Drawing.Point(15, 57);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(76, 14);
            this.label21.TabIndex = 393;
            this.label21.Text = "Cabinet End :";
            this.label21.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.Color.Gold;
            this.label22.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label22.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label22.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label22.Location = new System.Drawing.Point(19, 205);
            this.label22.Name = "label22";
            this.label22.Size = new System.Drawing.Size(135, 24);
            this.label22.TabIndex = 395;
            this.label22.Text = "Estimated Time:";
            this.label22.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_Cab_Emp
            // 
            this.CB_Cab_Emp.BackColor = System.Drawing.Color.Lavender;
            this.CB_Cab_Emp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Cab_Emp.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Cab_Emp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CB_Cab_Emp.Location = new System.Drawing.Point(251, 0);
            this.CB_Cab_Emp.Name = "CB_Cab_Emp";
            this.CB_Cab_Emp.Size = new System.Drawing.Size(86, 23);
            this.CB_Cab_Emp.TabIndex = 443;
            this.CB_Cab_Emp.Visible = false;
            this.CB_Cab_Emp.SelectedIndexChanged += new System.EventHandler(this.CB_Cab_Emp_SelectedIndexChanged);
            // 
            // t12
            // 
            this.t12.BackColor = System.Drawing.Color.PaleGreen;
            this.t12.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t12.ForeColor = System.Drawing.Color.Black;
            this.t12.Location = new System.Drawing.Point(91, 0);
            this.t12.MaxLength = 49;
            this.t12.Multiline = true;
            this.t12.Name = "t12";
            this.t12.ReadOnly = true;
            this.t12.Size = new System.Drawing.Size(129, 22);
            this.t12.TabIndex = 390;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.t8);
            this.panel4.Controls.Add(this.t7);
            this.panel4.Controls.Add(this.label16);
            this.panel4.Controls.Add(this.label14);
            this.panel4.Controls.Add(this.txNotes);
            this.panel4.Controls.Add(this.label15);
            this.panel4.Controls.Add(this.label24);
            this.panel4.Controls.Add(this.t6);
            this.panel4.Controls.Add(this.t5);
            this.panel4.Controls.Add(this.label4);
            this.panel4.Location = new System.Drawing.Point(441, 12);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(485, 113);
            this.panel4.TabIndex = 422;
            // 
            // t8
            // 
            this.t8.BackColor = System.Drawing.Color.White;
            this.t8.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t8.ForeColor = System.Drawing.Color.Black;
            this.t8.Location = new System.Drawing.Point(103, 66);
            this.t8.MaxLength = 0;
            this.t8.Multiline = true;
            this.t8.Name = "t8";
            this.t8.Size = new System.Drawing.Size(376, 20);
            this.t8.TabIndex = 390;
            // 
            // t7
            // 
            this.t7.BackColor = System.Drawing.Color.White;
            this.t7.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t7.ForeColor = System.Drawing.Color.Black;
            this.t7.Location = new System.Drawing.Point(103, 46);
            this.t7.MaxLength = 0;
            this.t7.Multiline = true;
            this.t7.Name = "t7";
            this.t7.Size = new System.Drawing.Size(376, 20);
            this.t7.TabIndex = 388;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.Color.Honeydew;
            this.label16.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label16.Location = new System.Drawing.Point(11, 69);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(92, 14);
            this.label16.TabIndex = 389;
            this.label16.Text = "Missing :";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.Color.Honeydew;
            this.label14.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label14.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label14.Location = new System.Drawing.Point(11, 49);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(92, 14);
            this.label14.TabIndex = 387;
            this.label14.Text = "Options :";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txNotes
            // 
            this.txNotes.BackColor = System.Drawing.Color.White;
            this.txNotes.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txNotes.ForeColor = System.Drawing.Color.Black;
            this.txNotes.Location = new System.Drawing.Point(102, 86);
            this.txNotes.MaxLength = 0;
            this.txNotes.Multiline = true;
            this.txNotes.Name = "txNotes";
            this.txNotes.Size = new System.Drawing.Size(377, 20);
            this.txNotes.TabIndex = 417;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.Color.Honeydew;
            this.label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label15.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label15.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label15.Location = new System.Drawing.Point(4, 29);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(99, 14);
            this.label15.TabIndex = 385;
            this.label15.Text = "HARNAIS :";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label24
            // 
            this.label24.BackColor = System.Drawing.Color.Honeydew;
            this.label24.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label24.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label24.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label24.Location = new System.Drawing.Point(21, 89);
            this.label24.Name = "label24";
            this.label24.Size = new System.Drawing.Size(82, 14);
            this.label24.TabIndex = 416;
            this.label24.Text = "Notes :";
            this.label24.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t6
            // 
            this.t6.BackColor = System.Drawing.Color.White;
            this.t6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t6.ForeColor = System.Drawing.Color.Black;
            this.t6.Location = new System.Drawing.Point(103, 26);
            this.t6.MaxLength = 0;
            this.t6.Multiline = true;
            this.t6.Name = "t6";
            this.t6.Size = new System.Drawing.Size(376, 20);
            this.t6.TabIndex = 386;
            // 
            // t5
            // 
            this.t5.BackColor = System.Drawing.Color.White;
            this.t5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t5.ForeColor = System.Drawing.Color.Black;
            this.t5.Location = new System.Drawing.Point(103, 6);
            this.t5.MaxLength = 0;
            this.t5.Multiline = true;
            this.t5.Name = "t5";
            this.t5.Size = new System.Drawing.Size(267, 20);
            this.t5.TabIndex = 384;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.Honeydew;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(7, 9);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(96, 14);
            this.label4.TabIndex = 383;
            this.label4.Text = "Enclosure (ARM) :";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dpDelvry);
            this.panel3.Controls.Add(this.t0);
            this.panel3.Controls.Add(this.button6);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Controls.Add(this.t2);
            this.panel3.Controls.Add(this.t55);
            this.panel3.Controls.Add(this.label17);
            this.panel3.Controls.Add(this.label7);
            this.panel3.Controls.Add(this.t4);
            this.panel3.Controls.Add(this.label65);
            this.panel3.Controls.Add(this.label2);
            this.panel3.Controls.Add(this.t1);
            this.panel3.Controls.Add(this.t3);
            this.panel3.Controls.Add(this.label1);
            this.panel3.Location = new System.Drawing.Point(6, 12);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(433, 113);
            this.panel3.TabIndex = 421;
            // 
            // dpDelvry
            // 
            this.dpDelvry.Location = new System.Drawing.Point(212, 43);
            this.dpDelvry.Name = "dpDelvry";
            this.dpDelvry.Size = new System.Drawing.Size(91, 20);
            this.dpDelvry.TabIndex = 428;
            this.dpDelvry.Visible = false;
            this.dpDelvry.ValueChanged += new System.EventHandler(this.dpDelvry_ValueChanged);
            // 
            // t0
            // 
            this.t0.BackColor = System.Drawing.Color.PeachPuff;
            this.t0.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t0.ForeColor = System.Drawing.Color.Black;
            this.t0.Location = new System.Drawing.Point(96, 3);
            this.t0.MaxLength = 49;
            this.t0.Multiline = true;
            this.t0.Name = "t0";
            this.t0.ReadOnly = true;
            this.t0.Size = new System.Drawing.Size(128, 20);
            this.t0.TabIndex = 363;
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(181, 42);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(31, 23);
            this.button6.TabIndex = 427;
            this.button6.Text = "...";
            this.button6.UseVisualStyleBackColor = true;
            this.button6.Click += new System.EventHandler(this.button6_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.Honeydew;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(202, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(55, 14);
            this.label5.TabIndex = 381;
            this.label5.Text = "AMP : ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t2
            // 
            this.t2.BackColor = System.Drawing.Color.PeachPuff;
            this.t2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t2.ForeColor = System.Drawing.Color.Black;
            this.t2.Location = new System.Drawing.Point(95, 43);
            this.t2.MaxLength = 49;
            this.t2.Multiline = true;
            this.t2.Name = "t2";
            this.t2.ReadOnly = true;
            this.t2.Size = new System.Drawing.Size(90, 20);
            this.t2.TabIndex = 384;
            // 
            // t55
            // 
            this.t55.BackColor = System.Drawing.Color.PeachPuff;
            this.t55.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F);
            this.t55.ForeColor = System.Drawing.Color.Black;
            this.t55.Location = new System.Drawing.Point(257, 83);
            this.t55.MaxLength = 49;
            this.t55.Multiline = true;
            this.t55.Name = "t55";
            this.t55.ReadOnly = true;
            this.t55.Size = new System.Drawing.Size(105, 20);
            this.t55.TabIndex = 382;
            this.t55.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.Color.Honeydew;
            this.label17.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label17.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label17.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label17.Location = new System.Drawing.Point(7, 46);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(88, 14);
            this.label17.TabIndex = 383;
            this.label17.Text = "Delivery Date :";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.Color.Honeydew;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(1, 86);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(95, 14);
            this.label7.TabIndex = 377;
            this.label7.Text = "Serial# :";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t4
            // 
            this.t4.BackColor = System.Drawing.Color.PeachPuff;
            this.t4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t4.ForeColor = System.Drawing.Color.Black;
            this.t4.Location = new System.Drawing.Point(96, 83);
            this.t4.MaxLength = 49;
            this.t4.Multiline = true;
            this.t4.Name = "t4";
            this.t4.ReadOnly = true;
            this.t4.Size = new System.Drawing.Size(90, 20);
            this.t4.TabIndex = 378;
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.Color.Honeydew;
            this.label65.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label65.Location = new System.Drawing.Point(4, 9);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(92, 14);
            this.label65.TabIndex = 362;
            this.label65.Text = "Project# :";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Honeydew;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(4, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(92, 14);
            this.label2.TabIndex = 375;
            this.label2.Text = "Model :";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t1
            // 
            this.t1.BackColor = System.Drawing.Color.PeachPuff;
            this.t1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t1.ForeColor = System.Drawing.Color.Black;
            this.t1.Location = new System.Drawing.Point(96, 23);
            this.t1.MaxLength = 49;
            this.t1.Multiline = true;
            this.t1.Name = "t1";
            this.t1.ReadOnly = true;
            this.t1.Size = new System.Drawing.Size(321, 20);
            this.t1.TabIndex = 372;
            // 
            // t3
            // 
            this.t3.BackColor = System.Drawing.Color.PeachPuff;
            this.t3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t3.ForeColor = System.Drawing.Color.Black;
            this.t3.Location = new System.Drawing.Point(96, 63);
            this.t3.MaxLength = 49;
            this.t3.Multiline = true;
            this.t3.Name = "t3";
            this.t3.ReadOnly = true;
            this.t3.Size = new System.Drawing.Size(266, 20);
            this.t3.TabIndex = 376;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Honeydew;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(4, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 14);
            this.label1.TabIndex = 371;
            this.label1.Text = "Customer :";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpPanel
            // 
            this.grpPanel.Controls.Add(this.panel1);
            this.grpPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpPanel.Location = new System.Drawing.Point(3, 131);
            this.grpPanel.Name = "grpPanel";
            this.grpPanel.Size = new System.Drawing.Size(452, 311);
            this.grpPanel.TabIndex = 420;
            this.grpPanel.TabStop = false;
            this.grpPanel.Text = "PANEL";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.Gold;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.label27);
            this.panel1.Controls.Add(this.label26);
            this.panel1.Controls.Add(this.label23);
            this.panel1.Controls.Add(this.txPmin);
            this.panel1.Controls.Add(this.txPhh);
            this.panel1.Controls.Add(this.lPanelDiff);
            this.panel1.Controls.Add(this.dtm2);
            this.panel1.Controls.Add(this.dtm1);
            this.panel1.Controls.Add(this.label20);
            this.panel1.Controls.Add(this.label19);
            this.panel1.Controls.Add(this.button5);
            this.panel1.Controls.Add(this.button2);
            this.panel1.Controls.Add(this.label44);
            this.panel1.Controls.Add(this.calTm_Pnl);
            this.panel1.Controls.Add(this.label40);
            this.panel1.Controls.Add(this.t15);
            this.panel1.Controls.Add(this.label36);
            this.panel1.Controls.Add(this.label35);
            this.panel1.Controls.Add(this.btnBRopt);
            this.panel1.Controls.Add(this.txOPTtm);
            this.panel1.Controls.Add(this.label25);
            this.panel1.Controls.Add(this.btnBRstd);
            this.panel1.Controls.Add(this.txSTDtm);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.dt_SPanel);
            this.panel1.Controls.Add(this.chk_multi_panel);
            this.panel1.Controls.Add(this.dt_EPanel);
            this.panel1.Controls.Add(this.button3);
            this.panel1.Controls.Add(this.btnNm1ED);
            this.panel1.Controls.Add(this.label13);
            this.panel1.Controls.Add(this.t10);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Controls.Add(this.t11);
            this.panel1.Controls.Add(this.label11);
            this.panel1.Controls.Add(this.CB_Panel_Emp);
            this.panel1.Controls.Add(this.t9);
            this.panel1.Location = new System.Drawing.Point(5, 19);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(441, 286);
            this.panel1.TabIndex = 414;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Gold;
            this.label27.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label27.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label27.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label27.Location = new System.Drawing.Point(19, 237);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(135, 24);
            this.label27.TabIndex = 476;
            this.label27.Text = "REALTime:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label26
            // 
            this.label26.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label26.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label26.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label26.Location = new System.Drawing.Point(160, 139);
            this.label26.Name = "label26";
            this.label26.Size = new System.Drawing.Size(22, 14);
            this.label26.TabIndex = 475;
            this.label26.Text = "Min";
            this.label26.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label23
            // 
            this.label23.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label23.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label23.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label23.Location = new System.Drawing.Point(114, 139);
            this.label23.Name = "label23";
            this.label23.Size = new System.Drawing.Size(12, 14);
            this.label23.TabIndex = 474;
            this.label23.Text = "H";
            this.label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txPmin
            // 
            this.txPmin.BackColor = System.Drawing.Color.White;
            this.txPmin.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txPmin.ForeColor = System.Drawing.Color.Red;
            this.txPmin.Location = new System.Drawing.Point(126, 133);
            this.txPmin.MaxLength = 2;
            this.txPmin.Multiline = true;
            this.txPmin.Name = "txPmin";
            this.txPmin.Size = new System.Drawing.Size(34, 27);
            this.txPmin.TabIndex = 473;
            this.txPmin.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txPmin.TextChanged += new System.EventHandler(this.txPmin_TextChanged);
            // 
            // txPhh
            // 
            this.txPhh.BackColor = System.Drawing.Color.White;
            this.txPhh.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txPhh.ForeColor = System.Drawing.Color.Red;
            this.txPhh.Location = new System.Drawing.Point(80, 133);
            this.txPhh.MaxLength = 2;
            this.txPhh.Multiline = true;
            this.txPhh.Name = "txPhh";
            this.txPhh.Size = new System.Drawing.Size(34, 27);
            this.txPhh.TabIndex = 472;
            this.txPhh.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txPhh.TextChanged += new System.EventHandler(this.txPhh_TextChanged);
            // 
            // lPanelDiff
            // 
            this.lPanelDiff.BackColor = System.Drawing.Color.Red;
            this.lPanelDiff.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lPanelDiff.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lPanelDiff.ForeColor = System.Drawing.Color.White;
            this.lPanelDiff.Location = new System.Drawing.Point(355, 209);
            this.lPanelDiff.Name = "lPanelDiff";
            this.lPanelDiff.Size = new System.Drawing.Size(58, 25);
            this.lPanelDiff.TabIndex = 471;
            this.lPanelDiff.Text = "999";
            this.lPanelDiff.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dtm2
            // 
            this.dtm2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtm2.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtm2.Location = new System.Drawing.Point(343, 53);
            this.dtm2.Name = "dtm2";
            this.dtm2.ShowUpDown = true;
            this.dtm2.Size = new System.Drawing.Size(87, 20);
            this.dtm2.TabIndex = 470;
            this.dtm2.Visible = false;
            this.dtm2.ValueChanged += new System.EventHandler(this.dtm2_ValueChanged);
            // 
            // dtm1
            // 
            this.dtm1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtm1.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtm1.Location = new System.Drawing.Point(342, 25);
            this.dtm1.Name = "dtm1";
            this.dtm1.ShowUpDown = true;
            this.dtm1.Size = new System.Drawing.Size(88, 20);
            this.dtm1.TabIndex = 469;
            this.dtm1.Visible = false;
            this.dtm1.ValueChanged += new System.EventHandler(this.dtm1_ValueChanged);
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.Color.Gold;
            this.label20.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label20.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label20.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label20.Location = new System.Drawing.Point(2, 138);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(78, 21);
            this.label20.TabIndex = 468;
            this.label20.Text = "Real Time:";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label19
            // 
            this.label19.BackColor = System.Drawing.Color.Gold;
            this.label19.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label19.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label19.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label19.Location = new System.Drawing.Point(19, 205);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(135, 24);
            this.label19.TabIndex = 465;
            this.label19.Text = "Estimated Time:";
            this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(209, 52);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(33, 23);
            this.button5.TabIndex = 464;
            this.button5.Text = "...";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click_1);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(208, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(33, 23);
            this.button2.TabIndex = 463;
            this.button2.Text = "...";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click_1);
            // 
            // label44
            // 
            this.label44.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label44.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label44.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label44.Location = new System.Drawing.Point(237, 205);
            this.label44.Name = "label44";
            this.label44.Size = new System.Drawing.Size(22, 14);
            this.label44.TabIndex = 462;
            this.label44.Text = "Min";
            this.label44.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // calTm_Pnl
            // 
            this.calTm_Pnl.BackColor = System.Drawing.Color.PeachPuff;
            this.calTm_Pnl.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.calTm_Pnl.ForeColor = System.Drawing.Color.Black;
            this.calTm_Pnl.Location = new System.Drawing.Point(154, 199);
            this.calTm_Pnl.MaxLength = 49;
            this.calTm_Pnl.Multiline = true;
            this.calTm_Pnl.Name = "calTm_Pnl";
            this.calTm_Pnl.ReadOnly = true;
            this.calTm_Pnl.Size = new System.Drawing.Size(83, 27);
            this.calTm_Pnl.TabIndex = 461;
            this.calTm_Pnl.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.calTm_Pnl.TextChanged += new System.EventHandler(this.calTm_Pnl_TextChanged);
            // 
            // label40
            // 
            this.label40.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label40.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label40.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label40.Location = new System.Drawing.Point(237, 237);
            this.label40.Name = "label40";
            this.label40.Size = new System.Drawing.Size(22, 14);
            this.label40.TabIndex = 457;
            this.label40.Text = "Min";
            this.label40.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // t15
            // 
            this.t15.BackColor = System.Drawing.Color.Khaki;
            this.t15.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t15.ForeColor = System.Drawing.Color.Red;
            this.t15.Location = new System.Drawing.Point(154, 231);
            this.t15.MaxLength = 49;
            this.t15.Multiline = true;
            this.t15.Name = "t15";
            this.t15.ReadOnly = true;
            this.t15.Size = new System.Drawing.Size(83, 27);
            this.t15.TabIndex = 456;
            this.t15.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.t15.TextChanged += new System.EventHandler(this.t15_TextChanged);
            // 
            // label36
            // 
            this.label36.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label36.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label36.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label36.Location = new System.Drawing.Point(147, 110);
            this.label36.Name = "label36";
            this.label36.Size = new System.Drawing.Size(22, 14);
            this.label36.TabIndex = 441;
            this.label36.Text = "Min";
            this.label36.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label35
            // 
            this.label35.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label35.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.label35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label35.Location = new System.Drawing.Point(147, 84);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(22, 14);
            this.label35.TabIndex = 440;
            this.label35.Text = "Min";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnBRopt
            // 
            this.btnBRopt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBRopt.Location = new System.Drawing.Point(169, 106);
            this.btnBRopt.Name = "btnBRopt";
            this.btnBRopt.Size = new System.Drawing.Size(62, 23);
            this.btnBRopt.TabIndex = 439;
            this.btnBRopt.Text = "Browse...";
            this.btnBRopt.UseVisualStyleBackColor = true;
            this.btnBRopt.Click += new System.EventHandler(this.btnBRopt_Click);
            // 
            // txOPTtm
            // 
            this.txOPTtm.BackColor = System.Drawing.Color.PeachPuff;
            this.txOPTtm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txOPTtm.ForeColor = System.Drawing.Color.Black;
            this.txOPTtm.Location = new System.Drawing.Point(80, 107);
            this.txOPTtm.MaxLength = 49;
            this.txOPTtm.Multiline = true;
            this.txOPTtm.Name = "txOPTtm";
            this.txOPTtm.ReadOnly = true;
            this.txOPTtm.Size = new System.Drawing.Size(67, 20);
            this.txOPTtm.TabIndex = 438;
            this.txOPTtm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label25
            // 
            this.label25.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label25.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label25.Location = new System.Drawing.Point(22, 110);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(58, 14);
            this.label25.TabIndex = 437;
            this.label25.Text = "Options :";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnBRstd
            // 
            this.btnBRstd.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBRstd.Location = new System.Drawing.Point(169, 80);
            this.btnBRstd.Name = "btnBRstd";
            this.btnBRstd.Size = new System.Drawing.Size(62, 23);
            this.btnBRstd.TabIndex = 436;
            this.btnBRstd.Text = "Browse...";
            this.btnBRstd.UseVisualStyleBackColor = true;
            this.btnBRstd.Click += new System.EventHandler(this.btnBRstd_Click);
            // 
            // txSTDtm
            // 
            this.txSTDtm.BackColor = System.Drawing.Color.PeachPuff;
            this.txSTDtm.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txSTDtm.ForeColor = System.Drawing.Color.Black;
            this.txSTDtm.Location = new System.Drawing.Point(80, 81);
            this.txSTDtm.MaxLength = 49;
            this.txSTDtm.Multiline = true;
            this.txSTDtm.Name = "txSTDtm";
            this.txSTDtm.ReadOnly = true;
            this.txSTDtm.Size = new System.Drawing.Size(67, 20);
            this.txSTDtm.TabIndex = 435;
            this.txSTDtm.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label8
            // 
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(22, 84);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 14);
            this.label8.TabIndex = 434;
            this.label8.Text = "Standard :";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dt_SPanel
            // 
            this.dt_SPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_SPanel.Location = new System.Drawing.Point(241, 25);
            this.dt_SPanel.Name = "dt_SPanel";
            this.dt_SPanel.Size = new System.Drawing.Size(102, 20);
            this.dt_SPanel.TabIndex = 422;
            this.dt_SPanel.Visible = false;
            this.dt_SPanel.ValueChanged += new System.EventHandler(this.dt_SPanel_ValueChanged);
            // 
            // chk_multi_panel
            // 
            this.chk_multi_panel.AutoSize = true;
            this.chk_multi_panel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chk_multi_panel.Location = new System.Drawing.Point(327, 2);
            this.chk_multi_panel.Name = "chk_multi_panel";
            this.chk_multi_panel.Size = new System.Drawing.Size(83, 17);
            this.chk_multi_panel.TabIndex = 433;
            this.chk_multi_panel.Text = "multi-Names";
            this.chk_multi_panel.UseVisualStyleBackColor = true;
            this.chk_multi_panel.Visible = false;
            // 
            // dt_EPanel
            // 
            this.dt_EPanel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dt_EPanel.Location = new System.Drawing.Point(242, 53);
            this.dt_EPanel.Name = "dt_EPanel";
            this.dt_EPanel.Size = new System.Drawing.Size(101, 20);
            this.dt_EPanel.TabIndex = 427;
            this.dt_EPanel.Visible = false;
            this.dt_EPanel.ValueChanged += new System.EventHandler(this.dt_EPanel_ValueChanged);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(678, 37);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(31, 23);
            this.button3.TabIndex = 431;
            this.button3.Text = "...";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // btnNm1ED
            // 
            this.btnNm1ED.Location = new System.Drawing.Point(208, -1);
            this.btnNm1ED.Name = "btnNm1ED";
            this.btnNm1ED.Size = new System.Drawing.Size(33, 23);
            this.btnNm1ED.TabIndex = 420;
            this.btnNm1ED.Text = "...";
            this.btnNm1ED.UseVisualStyleBackColor = true;
            this.btnNm1ED.Click += new System.EventHandler(this.btnNm1ED_Click);
            // 
            // label13
            // 
            this.label13.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label13.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label13.Location = new System.Drawing.Point(22, 5);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(57, 14);
            this.label13.TabIndex = 389;
            this.label13.Text = "Name :";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t10
            // 
            this.t10.BackColor = System.Drawing.Color.FloralWhite;
            this.t10.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t10.ForeColor = System.Drawing.Color.Black;
            this.t10.Location = new System.Drawing.Point(79, 25);
            this.t10.MaxLength = 49;
            this.t10.Multiline = true;
            this.t10.Name = "t10";
            this.t10.ReadOnly = true;
            this.t10.Size = new System.Drawing.Size(129, 20);
            this.t10.TabIndex = 392;
            this.t10.TextChanged += new System.EventHandler(this.t10_TextChanged);
            this.t10.DoubleClick += new System.EventHandler(this.t10_DoubleClick);
            // 
            // label12
            // 
            this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label12.Location = new System.Drawing.Point(7, 30);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 14);
            this.label12.TabIndex = 391;
            this.label12.Text = "Panel Start :";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // t11
            // 
            this.t11.BackColor = System.Drawing.Color.FloralWhite;
            this.t11.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t11.ForeColor = System.Drawing.Color.Black;
            this.t11.Location = new System.Drawing.Point(80, 53);
            this.t11.MaxLength = 49;
            this.t11.Multiline = true;
            this.t11.Name = "t11";
            this.t11.ReadOnly = true;
            this.t11.Size = new System.Drawing.Size(129, 20);
            this.t11.TabIndex = 394;
            this.t11.DoubleClick += new System.EventHandler(this.t11_DoubleClick);
            // 
            // label11
            // 
            this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label11.Location = new System.Drawing.Point(19, 56);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(61, 14);
            this.label11.TabIndex = 393;
            this.label11.Text = "Panel End :";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_Panel_Emp
            // 
            this.CB_Panel_Emp.BackColor = System.Drawing.Color.Lavender;
            this.CB_Panel_Emp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_Panel_Emp.Font = new System.Drawing.Font("Arial", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_Panel_Emp.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CB_Panel_Emp.Location = new System.Drawing.Point(241, -1);
            this.CB_Panel_Emp.Name = "CB_Panel_Emp";
            this.CB_Panel_Emp.Size = new System.Drawing.Size(86, 22);
            this.CB_Panel_Emp.TabIndex = 370;
            this.CB_Panel_Emp.Visible = false;
            this.CB_Panel_Emp.SelectedIndexChanged += new System.EventHandler(this.CB_Panel_Emp_SelectedIndexChanged);
            // 
            // t9
            // 
            this.t9.BackColor = System.Drawing.Color.PaleGreen;
            this.t9.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.t9.ForeColor = System.Drawing.Color.Black;
            this.t9.Location = new System.Drawing.Point(79, -1);
            this.t9.MaxLength = 49;
            this.t9.Multiline = true;
            this.t9.Name = "t9";
            this.t9.ReadOnly = true;
            this.t9.Size = new System.Drawing.Size(129, 22);
            this.t9.TabIndex = 390;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(671, 460);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(114, 34);
            this.btnOK.TabIndex = 419;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(791, 460);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(127, 34);
            this.btnCancel.TabIndex = 418;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // OR_ToSched_Edit
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(932, 506);
            this.Controls.Add(this.grpData);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OR_ToSched_Edit";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "                                                                                 " +
    " ELECTRICAL";
            this.Load += new System.EventHandler(this.OR_ToSched_Edit_Load);
            this.grpData.ResumeLayout(false);
            this.grpCAB.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.grpPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion


      

        private void optSave_Click(object sender, EventArgs e)
        {

        }

        private void OR_ToSched_Edit_Load(object sender, EventArgs e)
        {

            this.Text = (In_EM == 'E') ? "                                                                                  ELECTRICAL" : "                                                                                  MECANICAL";
         //   Color curr_clr = (In_EM == 'E') ? Color.LightGoldenrodYellow : Color.Honeydew;

        //    groupBox1.BackColor =curr_clr ;
         //   groupBox2.BackColor =curr_clr ;
        //    grpData.BackColor = curr_clr;

  //          foreach (Control ctrl in groupBox1.Controls)
  //          {
  //              if (ctrl is Label) ctrl.BackColor =curr_clr ; 
  //          }
       //     foreach (Control ctrl in groupBox2.Controls)
       //     {
      //          if (ctrl is Label) ctrl.BackColor =curr_clr ; 
      //      }
            this.Refresh();

            string whr=(In_EM =='E') ? " [Grp]in ('E','F') " : " [Grp]in ('M','N') "; 
            string stsql=" SELECT  [Emp_Name]  ,[Emp_ID] FROM [Orig_PSM_FDB].[dbo].[PSM_R_SCD_Emp] where " + whr + " order by Emp_Name ";
            MainMDI.fill_Any_CB(CB_Panel_Emp, stsql, true, "SELECT");
            MainMDI.fill_Any_CB(CB_Cab_Emp, stsql, true, "SELECT");

            t0.Text = In_arr_Info[0, 2];
            t1.Text = In_arr_Info[1, 2];

            t2.Text = In_arr_Info[2, 2];//delivery date
         //   t2.Text = In_arr_Info[2, 2].Substring(6, 4) + "/" + In_arr_Info[2, 2].Substring(3, 2) + "/" + In_arr_Info[2, 2].Substring(0, 2);

            t3.Text = In_arr_Info[3, 2];
            t4.Text = In_arr_Info[4, 2];
            t55.Text = In_arr_Info[5, 2];
            t5.Text = In_arr_Info[6, 2];
            t6.Text = In_arr_Info[7, 2];
            t7.Text = In_arr_Info[8, 2];

            t8.Text = In_arr_Info[19, 2];
//Panel
            t9.Text = In_arr_Info[9, 2];
            t10.Text = In_arr_Info[10, 2];
            t11.Text = In_arr_Info[11, 2];
//Cabinet
            t12.Text = In_arr_Info[14, 2];
            t13.Text = In_arr_Info[15, 2];
            t14.Text = In_arr_Info[16, 2];

            txNotes.Text = In_arr_Info[20, 2];
            if (In_arr_Info[17, 2].IndexOf("H") > 0) t111.Text = HHminTOmin(In_arr_Info[17, 2]).ToString ();
            else t111.Text =Tools.Conv_Dbl (  In_arr_Info[17, 2]).ToString ();

            if (In_arr_Info[12, 2].IndexOf("H") > 0) t15.Text = HHminTOmin(In_arr_Info[12, 2]).ToString();
            else t15.Text = Tools.Conv_Dbl(In_arr_Info[12, 2]).ToString(); 


            CAL_TIME(1);
            CAL_TIME(2);

     //       GetHHMN (txPanelDuraHH,txPanelDuraMN , In_arr_Info[12, 2]);
     //       GetHHMN(txCabinetDuraHH, txCabinetDuraMN, In_arr_Info[16, 2]);
        }

        double HHminTOmin(string stHHmin)
        {
            int pos = stHHmin.IndexOf("H");
            double HH=Tools.Conv_Dbl (stHHmin.Substring (0,pos));
            double MM = Tools.Conv_Dbl(stHHmin.Substring(pos+1,stHHmin.Length -pos -1 ));
            MM = MM + HH * 60;
            return MM;
  
        }

        private void GetHHMN( TextBox txHH, TextBox txMN,string _HHMN)
        {
            if (_HHMN == "" || _HHMN == "n/a") 
            {
                txHH.Text = ""; txMN.Text = "";
            }
            else 
            {
                int ipos=_HHMN.IndexOf ("H");
                if (ipos > -1)
                {
                    txHH.Text = _HHMN.Substring(0, ipos);
                    txMN.Text = _HHMN.Substring(ipos + 1, _HHMN.Length - ipos - 1);
                }
                else txHH.Text = ""; txMN.Text = "";
            }
        }



        private void btnOK_Click(object sender, EventArgs e)
        {
            In_arr_Info[0, 2] = t0.Text;
            In_arr_Info[1, 2] = t1.Text;
            In_arr_Info[2, 2] = t2.Text;
            In_arr_Info[3, 2] = t3.Text;
            In_arr_Info[4, 2] = t4.Text;
            In_arr_Info[5, 2] = t55.Text;
            In_arr_Info[6, 2] = t5.Text;
            In_arr_Info[7, 2] = t6.Text;
            In_arr_Info[8, 2] = t7.Text;

            In_arr_Info[19, 2] = t8.Text;

            In_arr_Info[9, 2] = t9.Text;
            In_arr_Info[10, 2] = t10.Text;
            In_arr_Info[11, 2] = t11.Text;
            In_arr_Info[14, 2] = t12.Text;

            In_arr_Info[15, 2] = t13.Text;
            In_arr_Info[16, 2] = t14.Text;
            In_arr_Info[20, 2] = txNotes.Text;

            In_arr_Info[17, 2] = t111.Text;
            In_arr_Info[12, 2] = t15.Text;


            this.Hide();

        }

     

        private void modifDPxx(TextBox txx, DateTimePicker dtp1, DateTimePicker tmp2)
        {
            string dt = dtp1.Value.Year + "/" + MainMDI.A00(dtp1.Value.Month, 2) + "/" + MainMDI.A00(dtp1.Value.Day, 2);
            string tm = MainMDI.A00(tmp2.Value.Hour, 2) + "H" + MainMDI.A00(tmp2.Value.Minute, 2);
            txx.Text = dt +" " + tm;
        }
        private void modifDPxxold(TextBox txx, DateTimePicker dtp1)
        {
            string dt = dtp1.Value.Year + "/" + MainMDI.A00(dtp1.Value.Month, 2) + "/" + MainMDI.A00(dtp1.Value.Day, 2);
            txx.Text = dt;// +" " + tm;
        }

        private void dtp_SPanel_ValueChanged(object sender, EventArgs e)
        {
            
        }

        private void dt_SPanel_ValueChanged(object sender, EventArgs e)
        {
            modifDPxx(t10, dt_SPanel,dtm1 );
        }

        private void tm_SPanel_ValueChanged(object sender, EventArgs e)
        {
           // modifDPxx(t10, dt_SPanel);
        }


   

        private void dt_EPanel_ValueChanged(object sender, EventArgs e)
        {
            modifDPxx(t11, dt_EPanel ,dtm2  );
        }

        private void tm_EPanel_ValueChanged(object sender, EventArgs e)
        {
           // modifDPxx(t11, dt_EPanel);
        }


        private void dt_SCab_ValueChanged(object sender, EventArgs e)
        {
            modifDPxx(t13, dt_SCab,dtm3 );
        }

        private void tm_SCab_ValueChanged(object sender, EventArgs e)
        {
          //  modifDPxx(t13, dt_SCab);
        }

        private void dt_ECab_ValueChanged(object sender, EventArgs e)
        {
            modifDPxx(t14, dt_ECab,dtm4);
        }

        private void tm_ECab_ValueChanged(object sender, EventArgs e)
        {
           // modifDPxx(t14, dt_ECab);
        }

        private void btnNm1ED_Click(object sender, EventArgs e)
        {
            CB_Panel_Emp.Visible = !CB_Panel_Emp.Visible;
            chk_multi_panel.Visible = true; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
          //  pnl_DT_panel.Visible = !pnl_DT_panel.Visible;
        }

        private void button3_Click(object sender, EventArgs e)
        {
          //  pnl_DT_panel.Visible = !pnl_DT_panel.Visible;
        }

        private void button5_Click(object sender, EventArgs e)
        {
          //  pnl_DT_cab.Visible = !pnl_DT_cab.Visible;
        }

        private void button4_Click(object sender, EventArgs e)
        {
          //  pnl_DT_cab.Visible = !pnl_DT_cab.Visible;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CB_Cab_Emp.Visible = !CB_Cab_Emp.Visible;
            chk_multi_Cab.Visible = true; 
        }

        private void CB_Panel_Emp_SelectedIndexChanged(object sender, EventArgs e)
        {
            string st = (chk_multi_panel.Checked) ? st = t9.Text + ", " : "";
           if (CB_Panel_Emp.Text != "SELECT") t9.Text= st + CB_Panel_Emp.Text;  
        }


        private void modifDuraXX(TextBox txx, DateTimePicker dtp1, DateTimePicker tmp2)
        {
            string dt = dtp1.Value.Year + "/" + MainMDI.A00(dtp1.Value.Month, 2) + "/" + MainMDI.A00(dtp1.Value.Day, 2);
            string tm = MainMDI.A00(tmp2.Value.Hour, 2) + "H" + MainMDI.A00(tmp2.Value.Minute, 2);
            txx.Text = dt + " " + tm;
        }





        private void CB_Cab_Emp_SelectedIndexChanged(object sender, EventArgs e)
        {
           // t12.Text = (CB_Cab_Emp.Text == "SELECT") ? "" : CB_Cab_Emp.Text;

            string st = (chk_multi_Cab.Checked) ? st = t12.Text + ", " : "";
            if (CB_Cab_Emp.Text != "SELECT") t12.Text = st + CB_Cab_Emp.Text;  
        }


        void HHMN(TextBox res, TextBox txHH, TextBox txMN)
        {
           double dd= Tools.Conv_Dbl(txHH.Text);
           double dd2= Tools.Conv_Dbl(txMN.Text);
           
          if (dd >0 && dd2 >-1 && dd2<60)  res.Text = dd.ToString ()+ "H" +MainMDI.A00( (int)dd2,2);
        }


        private void txPanelDuraHH_TextChanged(object sender, EventArgs e)
        {
           // HHMN(t111, txPanelDuraHH, txPanelDuraMN);
        }
        private void txPanelDuraMN_TextChanged(object sender, EventArgs e)
        {
           // HHMN(t111, txPanelDuraHH, txPanelDuraMN);
        }


        private void txCabinetDuraHH_TextChanged(object sender, EventArgs e)
        {
           // HHMN(t15, txCabinetDuraHH , txCabinetDuraMN);
        }

        private void txCabinetDuraMN_TextChanged(object sender, EventArgs e)
        {
           // HHMN(t15, txCabinetDuraHH, txCabinetDuraMN);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            dpDelvry.Visible = !dpDelvry.Visible;  
        }

        private void dpDelvry_ValueChanged(object sender, EventArgs e)
        {
           t2.Text = dpDelvry.Value.Year + "/" + MainMDI.A00(dpDelvry.Value.Month, 2) + "/" + MainMDI.A00(dpDelvry.Value.Day, 2);

        }

        private void t10_DoubleClick(object sender, EventArgs e)
        {
            dt_SPanel.Visible = !dt_SPanel.Visible;
            dtm1.Visible = !dtm1.Visible;
        }

        private void t10_TextChanged(object sender, EventArgs e)
        {

        }

        private void t11_DoubleClick(object sender, EventArgs e)
        {
            dt_EPanel.Visible = !dt_EPanel.Visible;
            dtm2.Visible = !dtm2.Visible;
        }

        private void t13_DoubleClick(object sender, EventArgs e)
        {
            dt_SCab.Visible = !dt_SCab.Visible;
            dtm3.Visible = !dtm3.Visible;
        }

        private void t14_DoubleClick(object sender, EventArgs e)
        {
            dt_ECab.Visible = !dt_ECab.Visible;
            dtm4.Visible = !dtm4.Visible;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
          private void CAL_TIME(int pnl_cab)
        {
            if (pnl_cab ==1)
            {
              txSTDtm.Text = findTIME_STD_OPT(1, 1);
             txOPTtm.Text = findTIME_STD_OPT(1, 2);
             calTm_Pnl.Text = (Tools.Conv_Dbl(txSTDtm.Text) + Tools.Conv_Dbl(txOPTtm.Text)).ToString ();
            }
            else
            {
                txSTDtmCab.Text = findTIME_STD_OPT(2, 1);
                txOPTtmCAB.Text = findTIME_STD_OPT(2, 2);
                calTm_Cab.Text = (Tools.Conv_Dbl(txSTDtmCab.Text) + Tools.Conv_Dbl(txOPTtmCAB.Text)).ToString();
            }



        }
      



        private void btnBRstd_Click(object sender, EventArgs e)
        {
            OR_ToSched_Sel myFrm = new OR_ToSched_Sel( 1, 1,in_scd_LID );
            myFrm.ShowDialog();

            CAL_TIME(1);
 
        }



        string findTIME_STD_OPT(int PAN_CAB,int STD_OPT)
        {
            double res = 0;

            string tblNM = (STD_OPT == 1) ? " PSM_R_SCD_Detail_STD " : " PSM_R_SCD_Detail_Options ";
            string stsql = "SELECT sum([dura])  FROM " + tblNM +  " where sc_LID="+ in_scd_LID  + " and sc_Pnl_Cab=" +PAN_CAB;
            res = Tools.Conv_Dbl(MainMDI.Find_One_Field(stsql));  

            return res.ToString();
        }


        private void btnBRopt_Click(object sender, EventArgs e)
        {
            OR_ToSched_Sel myFrm = new OR_ToSched_Sel(1, 2, in_scd_LID);
            myFrm.ShowDialog();
            CAL_TIME(1);
        }



        private void btnBRstdCab_Click(object sender, EventArgs e)
        {
            OR_ToSched_Sel myFrm = new OR_ToSched_Sel(2, 1, in_scd_LID);
            myFrm.ShowDialog();
            CAL_TIME(2);
        }

        private void btnBRoptCab_Click(object sender, EventArgs e)
        {
            OR_ToSched_Sel myFrm = new OR_ToSched_Sel(2, 2, in_scd_LID);
            myFrm.ShowDialog();
            CAL_TIME(2);
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            t10_DoubleClick(sender, e);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            t11_DoubleClick(sender, e);
        }

        private void t13_TextChanged(object sender, EventArgs e)
        {

        }

        private void button8_Click(object sender, EventArgs e)
        {
            t13_DoubleClick(sender, e);
        }

        private void t14_TextChanged(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            t14_DoubleClick(sender, e);
        }

        private void dtm1_ValueChanged(object sender, EventArgs e)
        {
            modifDPxx(t10, dt_SPanel, dtm1);
        }

        private void dtm2_ValueChanged(object sender, EventArgs e)
        {
            modifDPxx(t11, dt_EPanel, dtm2);
        }

        private void dtm3_ValueChanged(object sender, EventArgs e)
        {
            modifDPxx(t13, dt_SCab, dtm3);
        }

        private void dtm4_ValueChanged(object sender, EventArgs e)
        {
            modifDPxx(t14, dt_ECab, dtm4);
        }

        private void calTm_Cab_TextChanged(object sender, EventArgs e)
        {
            CAL_DIFF(calTm_Cab.Text, t111.Text, lPanDiff); 
        }
	
      //  private string YYYcnvrtDate(string ing 

        private void CAL_DIFF(string ESTTM, string RLTM, Label  myTX)
        {
            double dET = Tools.Conv_Dbl(ESTTM);
            double dRT = Tools.Conv_Dbl(RLTM );
            if (dET > 0 && dRT > 0)
            {
                myTX.Text = (dET - dRT).ToString();
                myTX.BackColor = (dRT > dET) ? Color.Red : Color.Green;
                myTX.Visible = true;

            }
            else
            {
                myTX.Text = ""; 
                myTX.Visible = false;
            }


        }

        private void t111_TextChanged(object sender, EventArgs e)
        {
            CAL_DIFF(calTm_Cab.Text, t111.Text, lPanDiff); 
        }

        private void calTm_Pnl_TextChanged(object sender, EventArgs e)
        {
            CAL_DIFF(calTm_Pnl.Text, t15.Text, lPanelDiff ); 
        }

        private void t15_TextChanged(object sender, EventArgs e)
        {
            CAL_DIFF(calTm_Pnl.Text, t15.Text, lPanelDiff); 
        }

  
        void HHminTOmin(TextBox txHH, TextBox txMN, TextBox RES)
        {

            double dd = Tools.Conv_Dbl(txHH.Text);
            double dd2 = Tools.Conv_Dbl(txMN.Text);

            if (dd > 0 && dd2 > -1 && dd2 < 60) RES.Text = (dd * 60 + dd2).ToString();
            else RES.Text = "";
        }

        private void txPhh_TextChanged(object sender, EventArgs e)
        {
            HHminTOmin(txPhh, txPmin, t15);
        }

        private void txPmin_TextChanged(object sender, EventArgs e)
        {
            HHminTOmin(txPhh, txPmin, t15);
        }

        private void txChh_TextChanged(object sender, EventArgs e)
        {
            HHminTOmin(txChh, txCmin, t111);
        }

        private void txCmin_TextChanged(object sender, EventArgs e)
        {
            HHminTOmin(txChh, txCmin, t111);
        }
		
	}
}
