using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb ;
using EAHLibs;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for Optionsdlg.
	/// </summary>
	public class Optionsdlg : System.Windows.Forms.Form
	{
        private Lib1 Tools;
        private char In_code;
        private string In_stCon;
		private System.Windows.Forms.ComboBox cbOptGrp;
		private System.Windows.Forms.Label lOptGrp;
		private System.Windows.Forms.Label lOptItems;
		private System.Windows.Forms.ComboBox cbOptItems;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Label label19;
		private System.Windows.Forms.Label label20;
		public System.Windows.Forms.TextBox tFRef;
		public System.Windows.Forms.TextBox tERef;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.CheckBox chkDef;
		private System.Windows.Forms.RadioButton optBaS;
		private System.Windows.Forms.RadioButton optPrimax;
		internal System.Windows.Forms.TextBox tDlvDelay;
		private System.Windows.Forms.Label lFullDesc;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label9;
		internal System.Windows.Forms.TextBox tUPrice;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.GroupBox groupBox4;
		private System.Windows.Forms.Label lCat3;
		private System.Windows.Forms.Label lCat2;
		private System.Windows.Forms.Label lCat1;
		internal System.Windows.Forms.TextBox tCat3;
		internal System.Windows.Forms.TextBox tCat2;
		internal System.Windows.Forms.TextBox tCat1;
		private System.Windows.Forms.CheckBox chk2;
		private System.Windows.Forms.CheckBox chk1;
		private System.Windows.Forms.CheckBox chk3;
		private System.Windows.Forms.GroupBox groupBox5;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.CheckBox chk7;
		internal System.Windows.Forms.TextBox tCat7;
		private System.Windows.Forms.CheckBox chk6;
		private System.Windows.Forms.CheckBox chk5;
		private System.Windows.Forms.CheckBox chk4;
		internal System.Windows.Forms.TextBox tCat6;
		internal System.Windows.Forms.TextBox tCat5;
		internal System.Windows.Forms.TextBox tCat4;
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Label label1;
		internal System.Windows.Forms.Button btnClear;
		internal System.Windows.Forms.TextBox tManifac;
		internal System.Windows.Forms.TextBox tPx;
		private System.Windows.Forms.Label loptID;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Optionsdlg(char X_code, string X_stcon)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            In_code =X_code;
			In_stCon =X_stcon ;
			Tools=new Lib1() ;
		  //  cbOptGrp.Visible = (In_code == 'a');
           // lOptGrp.Visible =  (In_code == 'a');
			cbOptItems.Visible = (In_code == 'c');
			if (In_code == 'a') lOptItems.Visible  = (In_code == 'c');
			fill_cboptGrp();
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
			this.cbOptGrp = new System.Windows.Forms.ComboBox();
			this.lOptGrp = new System.Windows.Forms.Label();
			this.lOptItems = new System.Windows.Forms.Label();
			this.cbOptItems = new System.Windows.Forms.ComboBox();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.chkDef = new System.Windows.Forms.CheckBox();
			this.optBaS = new System.Windows.Forms.RadioButton();
			this.optPrimax = new System.Windows.Forms.RadioButton();
			this.label19 = new System.Windows.Forms.Label();
			this.label20 = new System.Windows.Forms.Label();
			this.tFRef = new System.Windows.Forms.TextBox();
			this.tERef = new System.Windows.Forms.TextBox();
			this.tDlvDelay = new System.Windows.Forms.TextBox();
			this.lFullDesc = new System.Windows.Forms.Label();
			this.label13 = new System.Windows.Forms.Label();
			this.label9 = new System.Windows.Forms.Label();
			this.tUPrice = new System.Windows.Forms.TextBox();
			this.label8 = new System.Windows.Forms.Label();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.groupBox5 = new System.Windows.Forms.GroupBox();
			this.btnClear = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.label15 = new System.Windows.Forms.Label();
			this.label12 = new System.Windows.Forms.Label();
			this.label11 = new System.Windows.Forms.Label();
			this.label7 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.chk7 = new System.Windows.Forms.CheckBox();
			this.tCat7 = new System.Windows.Forms.TextBox();
			this.chk6 = new System.Windows.Forms.CheckBox();
			this.chk5 = new System.Windows.Forms.CheckBox();
			this.chk4 = new System.Windows.Forms.CheckBox();
			this.tCat6 = new System.Windows.Forms.TextBox();
			this.tCat5 = new System.Windows.Forms.TextBox();
			this.tCat4 = new System.Windows.Forms.TextBox();
			this.groupBox4 = new System.Windows.Forms.GroupBox();
			this.chk3 = new System.Windows.Forms.CheckBox();
			this.chk1 = new System.Windows.Forms.CheckBox();
			this.chk2 = new System.Windows.Forms.CheckBox();
			this.lCat3 = new System.Windows.Forms.Label();
			this.lCat2 = new System.Windows.Forms.Label();
			this.lCat1 = new System.Windows.Forms.Label();
			this.tCat3 = new System.Windows.Forms.TextBox();
			this.tCat2 = new System.Windows.Forms.TextBox();
			this.tCat1 = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.tManifac = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.tPx = new System.Windows.Forms.TextBox();
			this.loptID = new System.Windows.Forms.Label();
			this.groupBox2.SuspendLayout();
			this.groupBox3.SuspendLayout();
			this.groupBox1.SuspendLayout();
			this.groupBox5.SuspendLayout();
			this.groupBox4.SuspendLayout();
			this.SuspendLayout();
			// 
			// cbOptGrp
			// 
			this.cbOptGrp.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOptGrp.Location = new System.Drawing.Point(88, 8);
			this.cbOptGrp.Name = "cbOptGrp";
			this.cbOptGrp.Size = new System.Drawing.Size(208, 21);
			this.cbOptGrp.TabIndex = 0;
			this.cbOptGrp.SelectedValueChanged += new System.EventHandler(this.cbOptGrp_SelectedValueChanged);
			this.cbOptGrp.SelectedIndexChanged += new System.EventHandler(this.cbOptGrp_SelectedIndexChanged);
			// 
			// lOptGrp
			// 
			this.lOptGrp.Location = new System.Drawing.Point(0, 8);
			this.lOptGrp.Name = "lOptGrp";
			this.lOptGrp.Size = new System.Drawing.Size(88, 20);
			this.lOptGrp.TabIndex = 74;
			this.lOptGrp.Text = "&Option Name:";
			this.lOptGrp.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lOptGrp.Click += new System.EventHandler(this.lOptGrp_Click);
			// 
			// lOptItems
			// 
			this.lOptItems.Location = new System.Drawing.Point(8, 40);
			this.lOptItems.Name = "lOptItems";
			this.lOptItems.Size = new System.Drawing.Size(80, 20);
			this.lOptItems.TabIndex = 125;
			this.lOptItems.Text = "&Options Items:";
			this.lOptItems.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.lOptItems.Click += new System.EventHandler(this.lOptItems_Click);
			// 
			// cbOptItems
			// 
			this.cbOptItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbOptItems.Location = new System.Drawing.Point(88, 40);
			this.cbOptItems.Name = "cbOptItems";
			this.cbOptItems.Size = new System.Drawing.Size(600, 21);
			this.cbOptItems.TabIndex = 1;
			this.cbOptItems.SelectedIndexChanged += new System.EventHandler(this.cbOptItems_SelectedIndexChanged);
			// 
			// groupBox2
			// 
			this.groupBox2.Controls.Add(this.groupBox3);
			this.groupBox2.Controls.Add(this.label19);
			this.groupBox2.Controls.Add(this.label20);
			this.groupBox2.Controls.Add(this.tFRef);
			this.groupBox2.Controls.Add(this.tERef);
			this.groupBox2.Location = new System.Drawing.Point(8, 64);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(680, 80);
			this.groupBox2.TabIndex = 126;
			this.groupBox2.TabStop = false;
			this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
			// 
			// groupBox3
			// 
			this.groupBox3.Controls.Add(this.chkDef);
			this.groupBox3.Controls.Add(this.optBaS);
			this.groupBox3.Controls.Add(this.optPrimax);
			this.groupBox3.Location = new System.Drawing.Point(336, 16);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(336, 56);
			this.groupBox3.TabIndex = 115;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Status";
			// 
			// chkDef
			// 
			this.chkDef.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.chkDef.Location = new System.Drawing.Point(184, 24);
			this.chkDef.Name = "chkDef";
			this.chkDef.Size = new System.Drawing.Size(144, 16);
			this.chkDef.TabIndex = 134;
			this.chkDef.Text = "Charger Default option";
			// 
			// optBaS
			// 
			this.optBaS.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.optBaS.Location = new System.Drawing.Point(8, 32);
			this.optBaS.Name = "optBaS";
			this.optBaS.Size = new System.Drawing.Size(112, 16);
			this.optBaS.TabIndex = 133;
			this.optBaS.Text = "Buy and Resell";
			// 
			// optPrimax
			// 
			this.optPrimax.Checked = true;
			this.optPrimax.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.optPrimax.Location = new System.Drawing.Point(8, 16);
			this.optPrimax.Name = "optPrimax";
			this.optPrimax.Size = new System.Drawing.Size(136, 16);
			this.optPrimax.TabIndex = 132;
			this.optPrimax.TabStop = true;
			this.optPrimax.Text = "Primax Product";
			// 
			// label19
			// 
			this.label19.Location = new System.Drawing.Point(8, 24);
			this.label19.Name = "label19";
			this.label19.Size = new System.Drawing.Size(72, 20);
			this.label19.TabIndex = 114;
			this.label19.Text = "&English REF:";
			this.label19.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label20
			// 
			this.label20.Location = new System.Drawing.Point(8, 48);
			this.label20.Name = "label20";
			this.label20.Size = new System.Drawing.Size(72, 20);
			this.label20.TabIndex = 113;
			this.label20.Text = "Frensh REF:";
			this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tFRef
			// 
			this.tFRef.AutoSize = false;
			this.tFRef.Location = new System.Drawing.Point(80, 48);
			this.tFRef.MaxLength = 60;
			this.tFRef.Multiline = true;
			this.tFRef.Name = "tFRef";
			this.tFRef.Size = new System.Drawing.Size(232, 20);
			this.tFRef.TabIndex = 3;
			this.tFRef.Text = "";
			// 
			// tERef
			// 
			this.tERef.AutoSize = false;
			this.tERef.Location = new System.Drawing.Point(80, 24);
			this.tERef.MaxLength = 60;
			this.tERef.Multiline = true;
			this.tERef.Name = "tERef";
			this.tERef.Size = new System.Drawing.Size(232, 20);
			this.tERef.TabIndex = 2;
			this.tERef.Text = "";
			// 
			// tDlvDelay
			// 
			this.tDlvDelay.AutoSize = false;
			this.tDlvDelay.Location = new System.Drawing.Point(264, 16);
			this.tDlvDelay.MaxLength = 8;
			this.tDlvDelay.Name = "tDlvDelay";
			this.tDlvDelay.Size = new System.Drawing.Size(48, 20);
			this.tDlvDelay.TabIndex = 5;
			this.tDlvDelay.Text = "";
			this.tDlvDelay.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tDlvDelay_KeyPress);
			this.tDlvDelay.TextChanged += new System.EventHandler(this.tDlvDelay_TextChanged);
			// 
			// lFullDesc
			// 
			this.lFullDesc.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.lFullDesc.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.lFullDesc.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lFullDesc.Location = new System.Drawing.Point(80, 40);
			this.lFullDesc.Name = "lFullDesc";
			this.lFullDesc.Size = new System.Drawing.Size(592, 24);
			this.lFullDesc.TabIndex = 85;
			this.lFullDesc.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(8, 40);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(72, 20);
			this.label13.TabIndex = 84;
			this.label13.Text = "&Description:";
			this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(184, 16);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(80, 20);
			this.label9.TabIndex = 63;
			this.label9.Text = "&Delivery :";
			this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tUPrice
			// 
			this.tUPrice.AutoSize = false;
			this.tUPrice.Location = new System.Drawing.Point(80, 16);
			this.tUPrice.MaxLength = 8;
			this.tUPrice.Name = "tUPrice";
			this.tUPrice.Size = new System.Drawing.Size(72, 20);
			this.tUPrice.TabIndex = 4;
			this.tUPrice.Text = "";
			this.tUPrice.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tUPrice_KeyPress);
			this.tUPrice.TextChanged += new System.EventHandler(this.tUPrice_TextChanged);
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(24, 16);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(56, 20);
			this.label8.TabIndex = 61;
			this.label8.Text = "&Unit Price:";
			this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.groupBox5);
			this.groupBox1.Controls.Add(this.groupBox4);
			this.groupBox1.Controls.Add(this.label4);
			this.groupBox1.Controls.Add(this.tManifac);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.Controls.Add(this.tPx);
			this.groupBox1.Controls.Add(this.tDlvDelay);
			this.groupBox1.Controls.Add(this.lFullDesc);
			this.groupBox1.Controls.Add(this.label13);
			this.groupBox1.Controls.Add(this.label9);
			this.groupBox1.Controls.Add(this.tUPrice);
			this.groupBox1.Controls.Add(this.label8);
			this.groupBox1.Location = new System.Drawing.Point(8, 144);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(680, 312);
			this.groupBox1.TabIndex = 1;
			this.groupBox1.TabStop = false;
			this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
			// 
			// groupBox5
			// 
			this.groupBox5.Controls.Add(this.btnClear);
			this.groupBox5.Controls.Add(this.label1);
			this.groupBox5.Controls.Add(this.btnCancel);
			this.groupBox5.Controls.Add(this.btnOK);
			this.groupBox5.Controls.Add(this.label15);
			this.groupBox5.Controls.Add(this.label12);
			this.groupBox5.Controls.Add(this.label11);
			this.groupBox5.Controls.Add(this.label7);
			this.groupBox5.Controls.Add(this.label3);
			this.groupBox5.Controls.Add(this.chk7);
			this.groupBox5.Controls.Add(this.tCat7);
			this.groupBox5.Controls.Add(this.chk6);
			this.groupBox5.Controls.Add(this.chk5);
			this.groupBox5.Controls.Add(this.chk4);
			this.groupBox5.Controls.Add(this.tCat6);
			this.groupBox5.Controls.Add(this.tCat5);
			this.groupBox5.Controls.Add(this.tCat4);
			this.groupBox5.Location = new System.Drawing.Point(8, 152);
			this.groupBox5.Name = "groupBox5";
			this.groupBox5.Size = new System.Drawing.Size(664, 152);
			this.groupBox5.TabIndex = 129;
			this.groupBox5.TabStop = false;
			// 
			// btnClear
			// 
			this.btnClear.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnClear.Location = new System.Drawing.Point(384, 112);
			this.btnClear.Name = "btnClear";
			this.btnClear.Size = new System.Drawing.Size(88, 24);
			this.btnClear.TabIndex = 15;
			this.btnClear.Text = "&Clear";
			this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(168, 16);
			this.label1.TabIndex = 138;
			this.label1.Text = "Splitted Description:";
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnCancel.Location = new System.Drawing.Point(576, 112);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 24);
			this.btnCancel.TabIndex = 17;
			this.btnCancel.Text = "&Finish";
			// 
			// btnOK
			// 
			this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.btnOK.Location = new System.Drawing.Point(480, 112);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(88, 24);
			this.btnOK.TabIndex = 16;
			this.btnOK.Text = "&Save ";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click_1);
			// 
			// label15
			// 
			this.label15.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label15.ForeColor = System.Drawing.Color.Black;
			this.label15.Location = new System.Drawing.Point(16, 112);
			this.label15.Name = "label15";
			this.label15.Size = new System.Drawing.Size(56, 16);
			this.label15.TabIndex = 135;
			this.label15.Text = "Desc #7:";
			this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label12
			// 
			this.label12.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label12.ForeColor = System.Drawing.Color.Black;
			this.label12.Location = new System.Drawing.Point(16, 88);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(56, 16);
			this.label12.TabIndex = 134;
			this.label12.Text = "Desc #6:";
			this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label11
			// 
			this.label11.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label11.ForeColor = System.Drawing.Color.Black;
			this.label11.Location = new System.Drawing.Point(16, 64);
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(56, 16);
			this.label11.TabIndex = 133;
			this.label11.Text = "Desc #5:";
			this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label7
			// 
			this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label7.ForeColor = System.Drawing.Color.Black;
			this.label7.Location = new System.Drawing.Point(16, 40);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 132;
			this.label7.Text = "Desc #4:";
			this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(312, 16);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(120, 20);
			this.label3.TabIndex = 131;
			this.label3.Text = " Display this Option ";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
			// 
			// chk7
			// 
			this.chk7.Checked = true;
			this.chk7.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk7.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chk7.Location = new System.Drawing.Point(344, 112);
			this.chk7.Name = "chk7";
			this.chk7.Size = new System.Drawing.Size(24, 16);
			this.chk7.TabIndex = 130;
			this.chk7.CheckedChanged += new System.EventHandler(this.chk7_CheckedChanged);
			// 
			// tCat7
			// 
			this.tCat7.AutoSize = false;
			this.tCat7.Location = new System.Drawing.Point(80, 112);
			this.tCat7.MaxLength = 50;
			this.tCat7.Name = "tCat7";
			this.tCat7.Size = new System.Drawing.Size(264, 20);
			this.tCat7.TabIndex = 14;
			this.tCat7.Text = "";
			this.tCat7.TextChanged += new System.EventHandler(this.tCat7_TextChanged);
			// 
			// chk6
			// 
			this.chk6.Checked = true;
			this.chk6.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk6.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chk6.Location = new System.Drawing.Point(344, 88);
			this.chk6.Name = "chk6";
			this.chk6.Size = new System.Drawing.Size(24, 16);
			this.chk6.TabIndex = 128;
			this.chk6.CheckedChanged += new System.EventHandler(this.chk6_CheckedChanged);
			// 
			// chk5
			// 
			this.chk5.Checked = true;
			this.chk5.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk5.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chk5.Location = new System.Drawing.Point(344, 64);
			this.chk5.Name = "chk5";
			this.chk5.Size = new System.Drawing.Size(24, 16);
			this.chk5.TabIndex = 127;
			this.chk5.CheckedChanged += new System.EventHandler(this.chk5_CheckedChanged);
			// 
			// chk4
			// 
			this.chk4.Checked = true;
			this.chk4.CheckState = System.Windows.Forms.CheckState.Checked;
			this.chk4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chk4.Location = new System.Drawing.Point(344, 40);
			this.chk4.Name = "chk4";
			this.chk4.Size = new System.Drawing.Size(24, 16);
			this.chk4.TabIndex = 126;
			this.chk4.CheckedChanged += new System.EventHandler(this.chk4_CheckedChanged);
			// 
			// tCat6
			// 
			this.tCat6.AutoSize = false;
			this.tCat6.Location = new System.Drawing.Point(80, 88);
			this.tCat6.MaxLength = 50;
			this.tCat6.Name = "tCat6";
			this.tCat6.Size = new System.Drawing.Size(264, 20);
			this.tCat6.TabIndex = 13;
			this.tCat6.Text = "";
			this.tCat6.TextChanged += new System.EventHandler(this.tCat6_TextChanged);
			// 
			// tCat5
			// 
			this.tCat5.AutoSize = false;
			this.tCat5.Location = new System.Drawing.Point(80, 64);
			this.tCat5.MaxLength = 50;
			this.tCat5.Name = "tCat5";
			this.tCat5.Size = new System.Drawing.Size(264, 20);
			this.tCat5.TabIndex = 12;
			this.tCat5.Text = "";
			this.tCat5.TextChanged += new System.EventHandler(this.tCat5_TextChanged);
			// 
			// tCat4
			// 
			this.tCat4.AutoSize = false;
			this.tCat4.Location = new System.Drawing.Point(80, 40);
			this.tCat4.MaxLength = 50;
			this.tCat4.Name = "tCat4";
			this.tCat4.Size = new System.Drawing.Size(264, 20);
			this.tCat4.TabIndex = 11;
			this.tCat4.Text = "";
			this.tCat4.TextChanged += new System.EventHandler(this.tCat4_TextChanged);
			// 
			// groupBox4
			// 
			this.groupBox4.Controls.Add(this.chk3);
			this.groupBox4.Controls.Add(this.chk1);
			this.groupBox4.Controls.Add(this.chk2);
			this.groupBox4.Controls.Add(this.lCat3);
			this.groupBox4.Controls.Add(this.lCat2);
			this.groupBox4.Controls.Add(this.lCat1);
			this.groupBox4.Controls.Add(this.tCat3);
			this.groupBox4.Controls.Add(this.tCat2);
			this.groupBox4.Controls.Add(this.tCat1);
			this.groupBox4.Location = new System.Drawing.Point(8, 96);
			this.groupBox4.Name = "groupBox4";
			this.groupBox4.Size = new System.Drawing.Size(664, 56);
			this.groupBox4.TabIndex = 128;
			this.groupBox4.TabStop = false;
			this.groupBox4.Text = "Searching Desc :";
			// 
			// chk3
			// 
			this.chk3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chk3.Location = new System.Drawing.Point(640, 24);
			this.chk3.Name = "chk3";
			this.chk3.Size = new System.Drawing.Size(16, 16);
			this.chk3.TabIndex = 126;
			this.chk3.Visible = false;
			// 
			// chk1
			// 
			this.chk1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chk1.Location = new System.Drawing.Point(200, 24);
			this.chk1.Name = "chk1";
			this.chk1.Size = new System.Drawing.Size(24, 16);
			this.chk1.TabIndex = 125;
			this.chk1.Visible = false;
			// 
			// chk2
			// 
			this.chk2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.chk2.Location = new System.Drawing.Point(424, 24);
			this.chk2.Name = "chk2";
			this.chk2.Size = new System.Drawing.Size(16, 16);
			this.chk2.TabIndex = 124;
			this.chk2.Visible = false;
			// 
			// lCat3
			// 
			this.lCat3.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lCat3.ForeColor = System.Drawing.Color.DarkRed;
			this.lCat3.Location = new System.Drawing.Point(448, 24);
			this.lCat3.Name = "lCat3";
			this.lCat3.Size = new System.Drawing.Size(120, 20);
			this.lCat3.TabIndex = 123;
			this.lCat3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lCat2
			// 
			this.lCat2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lCat2.ForeColor = System.Drawing.Color.DarkRed;
			this.lCat2.Location = new System.Drawing.Point(232, 24);
			this.lCat2.Name = "lCat2";
			this.lCat2.Size = new System.Drawing.Size(120, 20);
			this.lCat2.TabIndex = 122;
			this.lCat2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// lCat1
			// 
			this.lCat1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.lCat1.ForeColor = System.Drawing.Color.DarkRed;
			this.lCat1.Location = new System.Drawing.Point(8, 24);
			this.lCat1.Name = "lCat1";
			this.lCat1.Size = new System.Drawing.Size(120, 20);
			this.lCat1.TabIndex = 121;
			this.lCat1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tCat3
			// 
			this.tCat3.AutoSize = false;
			this.tCat3.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.tCat3.Location = new System.Drawing.Point(576, 24);
			this.tCat3.MaxLength = 8;
			this.tCat3.Name = "tCat3";
			this.tCat3.Size = new System.Drawing.Size(64, 20);
			this.tCat3.TabIndex = 10;
			this.tCat3.Text = "";
			// 
			// tCat2
			// 
			this.tCat2.AutoSize = false;
			this.tCat2.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.tCat2.Location = new System.Drawing.Point(360, 24);
			this.tCat2.MaxLength = 8;
			this.tCat2.Name = "tCat2";
			this.tCat2.Size = new System.Drawing.Size(64, 20);
			this.tCat2.TabIndex = 9;
			this.tCat2.Text = "";
			// 
			// tCat1
			// 
			this.tCat1.AutoSize = false;
			this.tCat1.BackColor = System.Drawing.Color.BlanchedAlmond;
			this.tCat1.Location = new System.Drawing.Point(136, 24);
			this.tCat1.MaxLength = 8;
			this.tCat1.Name = "tCat1";
			this.tCat1.Size = new System.Drawing.Size(64, 20);
			this.tCat1.TabIndex = 8;
			this.tCat1.Text = "";
			// 
			// label4
			// 
			this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label4.ForeColor = System.Drawing.Color.Black;
			this.label4.Location = new System.Drawing.Point(352, 72);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(56, 16);
			this.label4.TabIndex = 126;
			this.label4.Text = "Manufac #:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tManifac
			// 
			this.tManifac.AutoSize = false;
			this.tManifac.Location = new System.Drawing.Point(416, 72);
			this.tManifac.MaxLength = 50;
			this.tManifac.Name = "tManifac";
			this.tManifac.Size = new System.Drawing.Size(256, 20);
			this.tManifac.TabIndex = 7;
			this.tManifac.Text = "";
			// 
			// label2
			// 
			this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.label2.ForeColor = System.Drawing.Color.Black;
			this.label2.Location = new System.Drawing.Point(24, 72);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 124;
			this.label2.Text = "Primax #:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// tPx
			// 
			this.tPx.AutoSize = false;
			this.tPx.Location = new System.Drawing.Point(80, 72);
			this.tPx.MaxLength = 50;
			this.tPx.Name = "tPx";
			this.tPx.Size = new System.Drawing.Size(256, 20);
			this.tPx.TabIndex = 6;
			this.tPx.Text = "";
			// 
			// loptID
			// 
			this.loptID.BackColor = System.Drawing.Color.IndianRed;
			this.loptID.Location = new System.Drawing.Point(304, 8);
			this.loptID.Name = "loptID";
			this.loptID.Size = new System.Drawing.Size(32, 24);
			this.loptID.TabIndex = 127;
			this.loptID.Click += new System.EventHandler(this.loptID_Click);
			// 
			// Optionsdlg
			// 
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(696, 462);
			this.Controls.Add(this.loptID);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.lOptItems);
			this.Controls.Add(this.cbOptItems);
			this.Controls.Add(this.lOptGrp);
			this.Controls.Add(this.cbOptGrp);
			this.Controls.Add(this.groupBox1);
			this.Name = "Optionsdlg";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "OPTION INFO";
			this.Load += new System.EventHandler(this.Optionsdlg_Load);
			this.groupBox2.ResumeLayout(false);
			this.groupBox3.ResumeLayout(false);
			this.groupBox1.ResumeLayout(false);
			this.groupBox5.ResumeLayout(false);
			this.groupBox4.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void Optionsdlg_Load(object sender, System.EventArgs e)
		{
		     
		}



		private void fill_cboptGrp()
		{


			string stSql= "select [COMPNT_LIST].COMPONENT_REF FROM [COMPNT_LIST] where Compnt_Type='S' order by COMPONENT_REF";
			OleDbConnection OConn  = new OleDbConnection(In_stCon  );
			OConn.Open ();
			OleDbCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			OleDbDataReader Oreadr = Ocmd.ExecuteReader();
 
			//	lvCompany.Clear ();
			while (Oreadr.Read ())
			{
                cbOptGrp.Items.Add( Oreadr["COMPONENT_REF"].ToString()  ); 
			}


		
	//		string stsql= "select [COMPNT_LIST].COMPONENT_REF FROM [COMPNT_LIST] where Compnt_Type='S' order by COMPONENT_REF";
	//		OleDbConnection OConn  = new OleDbConnection(In_stCon  );
	//		OleDbDataAdapter OAdp = new OleDbDataAdapter (stsql , OConn );
	//		string tblName="COMPNT_LIST";
	//		DataSet m_Ds = new DataSet(tblName) ;
	//		OAdp.Fill(m_Ds  ,tblName); 
	//		MessageBox.Show (  m_Ds.Tables[0].Rows.Count.ToString ());
	//		for (int i=0;i< m_Ds.Tables[0].Rows.Count ;i++)
	//			cbOptGrp.Items.Add( m_Ds.Tables[tblName].Rows[i][0].ToString ()  ); 
		}

		private void cbOptGrp_SelectedValueChanged(object sender, System.EventArgs e)
		{
			MessageBox.Show ("choosen: " + cbOptGrp.Text  ); 
			string stSql= "select * FROM [COMPNT_LIST] where Compnt_Type='S' and COMPONENT_REF='" + cbOptGrp.Text + "' order by COMPONENT_REF";
			OleDbConnection OConn  = new OleDbConnection(In_stCon  );
			OConn.Open ();
			OleDbCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			OleDbDataReader Oreadr = Ocmd.ExecuteReader();
            
			//	lvCompany.Clear ();
			while (Oreadr.Read ())
			{
				tERef.Text =  Oreadr["COMPONENT_REF"].ToString() ; 
				tFRef.Text =  Oreadr["Component_Name"].ToString() ; 
				lCat1.Text =  Oreadr["CatName1"].ToString() ; 
				lCat2.Text =  Oreadr["CatName2"].ToString() ; 
				lCat3.Text =  Oreadr["CatName3"].ToString() ;
				
				lCat1.Enabled= ( Oreadr["CatName1"].ToString() != "n/a" ); 
				lCat2.Enabled= ( Oreadr["CatName2"].ToString() != "n/a" ); 
				lCat3.Enabled= ( Oreadr["CatName3"].ToString() != "n/a" ); 
				
				tCat1.Enabled=lCat1.Enabled;
				tCat2.Enabled=lCat2.Enabled;
				tCat3.Enabled=lCat3.Enabled;
                loptID.Text = Oreadr["Component_ID"].ToString(); 
				switch (Oreadr["CatName3"].ToString())    
				{
					case "D":  //default + Primax product 
	                    chkDef.Checked =true;
						optPrimax.Checked =true;
						break;
					case "F":  //default + Buy & Sell product 
	                    chkDef.Checked =true;
						optBaS.Checked =true;
						break;
					case "S":  //Accessory  + Primax product 
						chkDef.Checked =false;
						optPrimax.Checked =true;
						break;
					case "Y":  //Accessory + Buy & Sell product 
						chkDef.Checked =false;
						optBaS.Checked =true;
						break;
				   
				}
			}

		}

		private void cbOptGrp_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


		private void Upd_fullDesc()
		{
	      
				lFullDesc.Text = (tCat4.Text !="" && chk4.Checked  ) ? tCat4.Text : "";
				lFullDesc.Text = lFullDesc.Text + ((tCat5.Text !="" &&  chk5.Checked  ) ? ", " + tCat5.Text : "");
				lFullDesc.Text = lFullDesc.Text + ((tCat6.Text !="" && chk6.Checked  ) ? ", " + tCat6.Text : "");
				lFullDesc.Text = lFullDesc.Text +  ((tCat7.Text !="" && chk7.Checked  ) ? ", " + tCat7.Text : "");

		   }
		private void tCat4_TextChanged(object sender, System.EventArgs e)
		{

           
           Upd_fullDesc ();
		}

		private void tCat5_TextChanged(object sender, System.EventArgs e)
		{
			Upd_fullDesc ();
		}

		private void tCat6_TextChanged(object sender, System.EventArgs e)
		{
		Upd_fullDesc ();
		}

		private void tCat7_TextChanged(object sender, System.EventArgs e)
		{
			Upd_fullDesc ();
		}

		private void chk4_CheckedChanged(object sender, System.EventArgs e)
		{
			Upd_fullDesc ();
		}

		private void chk5_CheckedChanged(object sender, System.EventArgs e)
		{
		Upd_fullDesc ();
		}

		private void chk6_CheckedChanged(object sender, System.EventArgs e)
		{
			Upd_fullDesc ();
		}

		private void chk7_CheckedChanged(object sender, System.EventArgs e)
		{
			Upd_fullDesc ();
		}

		private void tUPrice_TextChanged(object sender, System.EventArgs e)
		{
		  // MessageBox.Show ( Convert.ToDouble(tUPrice.Text).ToString () );      
		}

			/*
		private bool DLL_Ndble(char c)
		{
			if ((c < 48 || c > 57 ) && c != 8 && c != 44  && c != 46)
				return true;
		    else return false;
        
		}

	
		private bool DLL_NInt(char c)
		{
			if ((c < 48 || c > 57 ) && c != 8 )
				return true;
			else return false;
        
		}

		private void tUPrice_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		//	  if ((e.KeyChar < 48 || e.KeyChar > 57 ) && e.KeyChar != 8 && e.KeyChar != 44  && e.KeyChar != 46)
		//		    e.Handled=true;
			e.Handled = DLL_Ndble(e.KeyChar);
		}
*/
		private void tDlvDelay_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		   e.Handled =Tools.OnlyInt(e.KeyChar );
		}
		private void clear_scrn()
		{
			tUPrice.Text ="";
			tDlvDelay.Text ="";
			lFullDesc.Text ="";
			tPx.Text ="";
			tManifac.Text ="";
			tCat1.Text ="";
			tCat2.Text ="";
			tCat3.Text ="";
			tCat4.Text ="";
			tCat5.Text ="";
			tCat6.Text ="";
			tCat7.Text ="";
		}
		private void btnClear_Click(object sender, System.EventArgs e)
		{

          clear_scrn ();
		  

		}

		private void btnOK_Click_1(object sender, System.EventArgs e)
		{
			try
			{
				
				OleDbConnection oleDbConnection1  = new OleDbConnection(In_stCon  );
				OleDbDataAdapter OAdp1 = new OleDbDataAdapter("select * from PSM_Options_PriceList",oleDbConnection1 );
				string stsql= "INSERT INTO PSM_Options_PriceList ([Option_ID],[Manufac_ID], " + 
                    " [Manufac_PARTN],[Primax_PARTN],[CAT1_VALUE],[CAT2_VALUE], " + 
					" [CAT3_VALUE],[CAT4_VALUE],[CAT5_VALUE],[CAT6_VALUE],[CAT7_VALUE], " + 
                    "[PRICE],[LeadTime],[COMMENTS]) VALUES ('" +
					loptID.Text + "', '" +
					"1" + "', '" +
					tManifac.Text + "', '" +
					tPx.Text + "', '" +
                    tCat1.Text + "', '" +
					tCat2.Text + "', '" +
					tCat3.Text + "', '" +
					tCat4.Text + "', '" +
					tCat5.Text + "', '" +
					tCat6.Text + "', '" +
					tCat7.Text + "', '" +
					tUPrice.Text + "', '" +
					tDlvDelay.Text + "', '" +
					"---" + "')" ;
				OAdp1.InsertCommand = new OleDbCommand(stsql,oleDbConnection1 );  
				OAdp1.InsertCommand.Connection.Open (); 
				OAdp1.InsertCommand.ExecuteNonQuery();
				DataSet ds1 = new DataSet("PSM_Options_PriceList");
				//OAdp1.Fill(ds1 );
				//dgXL1.DataSource=ds1.Tables[0].DefaultView; 
			}
			catch (OleDbException Oexp)
			{
				MessageBox.Show("Adding Option Error...= " + Oexp.Message );
			}
		}

		private void cbOptItems_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lOptGrp_Click(object sender, System.EventArgs e)
		{
		
		}

		private void lOptItems_Click(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox2_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void loptID_Click(object sender, System.EventArgs e)
		{
		
		}

		private void tDlvDelay_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tUPrice_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		   e.Handled = Tools.OnlyInt(e.KeyChar );
		}


   
   





	







	
  
	}
}
