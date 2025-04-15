using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb ;
using System.Data.SqlClient ;
namespace PGESCOM
{
	/// <summary>
	/// Summary description for dlgAdrs.
	/// </summary>
	public class dlgAdrs : System.Windows.Forms.Form
	{
        //kim
		   private string In_adrs;
	//	   private string MainMDI.M_stCon;
		//kim

		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		internal System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.Button btnOK;
		internal System.Windows.Forms.ComboBox cbCountry;
		internal System.Windows.Forms.ComboBox cbSP;
		internal System.Windows.Forms.TextBox tZip;
		public System.Windows.Forms.TextBox tStreet;
		public System.Windows.Forms.ComboBox cbCity;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.PictureBox pictureBox3;
		public System.Windows.Forms.CheckBox chkSave;
		public System.Windows.Forms.TextBox tCity;
		public System.Windows.Forms.TextBox tSt;
		public System.Windows.Forms.TextBox tCountry;
		private System.Windows.Forms.RadioButton radioButton1;
		private System.Windows.Forms.RadioButton radioButton2;
		private System.Windows.Forms.RadioButton radioButton3;
		private System.Windows.Forms.Label lCU;
		private System.Windows.Forms.Label label9;
		public System.Windows.Forms.TextBox toldAdrs;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public dlgAdrs(string X_adrs)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
              In_adrs = X_adrs;
		      MainMDI.M_stCon= MainMDI.M_stCon  ;
			fill_Adrs(); //lkoli
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlgAdrs));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.cbCity = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.cbCountry = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbSP = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.tZip = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.tStreet = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.tCity = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.tSt = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tCountry = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.chkSave = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.lCU = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.toldAdrs = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnOK);
            this.groupBox1.Controls.Add(this.cbCity);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.cbCountry);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cbSP);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tZip);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.tStreet);
            this.groupBox1.ForeColor = System.Drawing.Color.MediumBlue;
            this.groupBox1.Location = new System.Drawing.Point(8, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(496, 168);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Address Details";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnOK
            // 
            this.btnOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Location = new System.Drawing.Point(360, 88);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(128, 24);
            this.btnOK.TabIndex = 43;
            this.btnOK.Text = "&OK";
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // cbCity
            // 
            this.cbCity.BackColor = System.Drawing.Color.Lavender;
            this.cbCity.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCity.Location = new System.Drawing.Point(96, 72);
            this.cbCity.Name = "cbCity";
            this.cbCity.Size = new System.Drawing.Size(232, 21);
            this.cbCity.TabIndex = 45;
            this.cbCity.SelectedIndexChanged += new System.EventHandler(this.cbcities_SelectedIndexChanged);
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(360, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 24);
            this.btnCancel.TabIndex = 44;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // cbCountry
            // 
            this.cbCountry.BackColor = System.Drawing.Color.Lavender;
            this.cbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCountry.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCountry.Location = new System.Drawing.Point(96, 134);
            this.cbCountry.Name = "cbCountry";
            this.cbCountry.Size = new System.Drawing.Size(232, 21);
            this.cbCountry.TabIndex = 9;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(8, 134);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 20);
            this.label5.TabIndex = 8;
            this.label5.Text = "C&ountry:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(8, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 20);
            this.label4.TabIndex = 7;
            this.label4.Text = "&Zip/Postal Code:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbSP
            // 
            this.cbSP.BackColor = System.Drawing.Color.Lavender;
            this.cbSP.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSP.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSP.Location = new System.Drawing.Point(96, 93);
            this.cbSP.Name = "cbSP";
            this.cbSP.Size = new System.Drawing.Size(232, 21);
            this.cbSP.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(8, 93);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "S&tate/Province:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tZip
            // 
            this.tZip.BackColor = System.Drawing.Color.Lavender;
            this.tZip.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tZip.Location = new System.Drawing.Point(96, 114);
            this.tZip.MaxLength = 15;
            this.tZip.Name = "tZip";
            this.tZip.Size = new System.Drawing.Size(232, 20);
            this.tZip.TabIndex = 3;
            this.tZip.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tZip_KeyPress);
            // 
            // label2
            // 
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(8, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(88, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "&City:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(8, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "&Street";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tStreet
            // 
            this.tStreet.BackColor = System.Drawing.Color.Lavender;
            this.tStreet.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tStreet.Location = new System.Drawing.Point(96, 22);
            this.tStreet.MaxLength = 150;
            this.tStreet.Multiline = true;
            this.tStreet.Name = "tStreet";
            this.tStreet.Size = new System.Drawing.Size(392, 50);
            this.tStreet.TabIndex = 0;
            this.tStreet.TextChanged += new System.EventHandler(this.tStreet_TextChanged);
            this.tStreet.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tStreet_KeyPress);
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(8, 248);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(88, 16);
            this.label6.TabIndex = 3;
            this.label6.Text = "New City:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tCity
            // 
            this.tCity.BackColor = System.Drawing.Color.Lavender;
            this.tCity.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tCity.Location = new System.Drawing.Point(96, 240);
            this.tCity.MaxLength = 60;
            this.tCity.Multiline = true;
            this.tCity.Name = "tCity";
            this.tCity.Size = new System.Drawing.Size(312, 24);
            this.tCity.TabIndex = 2;
            // 
            // label7
            // 
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(8, 272);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 16);
            this.label7.TabIndex = 5;
            this.label7.Text = "New State/Prov:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tSt
            // 
            this.tSt.BackColor = System.Drawing.Color.Lavender;
            this.tSt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tSt.Location = new System.Drawing.Point(96, 264);
            this.tSt.MaxLength = 60;
            this.tSt.Multiline = true;
            this.tSt.Name = "tSt";
            this.tSt.Size = new System.Drawing.Size(144, 24);
            this.tSt.TabIndex = 4;
            // 
            // label8
            // 
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(8, 296);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(88, 16);
            this.label8.TabIndex = 7;
            this.label8.Text = "New Country:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tCountry
            // 
            this.tCountry.BackColor = System.Drawing.Color.Lavender;
            this.tCountry.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tCountry.Location = new System.Drawing.Point(96, 288);
            this.tCountry.MaxLength = 60;
            this.tCountry.Multiline = true;
            this.tCountry.Name = "tCountry";
            this.tCountry.Size = new System.Drawing.Size(312, 24);
            this.tCountry.TabIndex = 6;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(416, 224);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(65, 88);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 83;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // chkSave
            // 
            this.chkSave.Checked = true;
            this.chkSave.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.chkSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSave.ForeColor = System.Drawing.Color.Red;
            this.chkSave.Location = new System.Drawing.Point(416, 296);
            this.chkSave.Name = "chkSave";
            this.chkSave.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.chkSave.Size = new System.Drawing.Size(96, 24);
            this.chkSave.TabIndex = 84;
            this.chkSave.Text = "Save values:";
            this.chkSave.Visible = false;
            // 
            // radioButton1
            // 
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(248, 268);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(64, 16);
            this.radioButton1.TabIndex = 85;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "canada";
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.Location = new System.Drawing.Point(312, 268);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(40, 16);
            this.radioButton2.TabIndex = 86;
            this.radioButton2.Text = "usa";
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // radioButton3
            // 
            this.radioButton3.Location = new System.Drawing.Point(360, 268);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(56, 16);
            this.radioButton3.TabIndex = 87;
            this.radioButton3.Text = "Others";
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // lCU
            // 
            this.lCU.BackColor = System.Drawing.Color.LightGreen;
            this.lCU.Location = new System.Drawing.Point(472, 248);
            this.lCU.Name = "lCU";
            this.lCU.Size = new System.Drawing.Size(24, 16);
            this.lCU.TabIndex = 88;
            this.lCU.Text = "c";
            this.lCU.Visible = false;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label9.Location = new System.Drawing.Point(16, 18);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(64, 20);
            this.label9.TabIndex = 90;
            this.label9.Text = "Address:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // toldAdrs
            // 
            this.toldAdrs.BackColor = System.Drawing.Color.AliceBlue;
            this.toldAdrs.ForeColor = System.Drawing.SystemColors.ControlText;
            this.toldAdrs.Location = new System.Drawing.Point(80, 8);
            this.toldAdrs.MaxLength = 150;
            this.toldAdrs.Multiline = true;
            this.toldAdrs.Name = "toldAdrs";
            this.toldAdrs.Size = new System.Drawing.Size(424, 40);
            this.toldAdrs.TabIndex = 89;
            // 
            // dlgAdrs
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(514, 320);
            this.Controls.Add(this.pictureBox3);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.toldAdrs);
            this.Controls.Add(this.tCountry);
            this.Controls.Add(this.tSt);
            this.Controls.Add(this.tCity);
            this.Controls.Add(this.lCU);
            this.Controls.Add(this.radioButton3);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.chkSave);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlgAdrs";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "dlgAdrs";
            this.Load += new System.EventHandler(this.dlgAdrs_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (tZip.Text ==" ") tZip.Text =""; 
		}

	

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
    		 tStreet.Text  ="";
		}

		private void fill_Adrs()
		{
			string stsql= "select [PSM_CITY].City_Name FROM [PSM_CITY] order by [PSM_CITY].City_Name";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			SqlDataAdapter  OAdp = new SqlDataAdapter (stsql , OConn );
			DataSet m_Ds = new DataSet("PSM_CITY" ) ;
		
			OAdp.Fill(m_Ds  ,"PSM_CITY" ); 
		    for (int i=0;i< m_Ds.Tables[0].Rows.Count ;i++)
			  cbCity.Items.Add( m_Ds.Tables["PSM_CITY"].Rows[i][0].ToString ()  ); 
		   		
		    stsql="SELECT [PSM_ST_PROV].SP_NAME, [PSM_ST_PROV].sp_ID, [PSM_ST_PROV].CU FROM [PSM_ST_PROV] ORDER BY [PSM_ST_PROV].sp_ID, [PSM_ST_PROV].CU";
			OAdp = new SqlDataAdapter(stsql , OConn );
			OAdp.Fill(m_Ds  ,"PSM_ST_PROV" ); 
			for (int i=0;i< m_Ds.Tables[1].Rows.Count ;i++)	
                cbSP.Items.Add(  m_Ds.Tables["PSM_ST_PROV" ].Rows[i][0].ToString ()  ); 
			
			stsql="SELECT [PSM_country].Country_Name , [PSM_country].Country_ID, [PSM_country].Country_Abr FROM [PSM_country] ORDER BY [PSM_country].Country_ID ";
			OAdp = new SqlDataAdapter(stsql , OConn );
			OAdp.Fill(m_Ds  ,"PSM_country" ); 
			for (int i=0;i< m_Ds.Tables[2].Rows.Count ;i++)	
				cbCountry.Items.Add(  m_Ds.Tables["PSM_country" ].Rows[i][0].ToString ()  ); 
            toldAdrs.Text =In_adrs ; 
			OConn.Close ();
		
		//	stsql="SELECT [PSM_CITYww].City_Name FROM [PSM_CITYww] " ;// ORDER BY [PSM_CITY].City_Name ";
	//		OAdp = new SqlDataAdapter(stsql , OConn );
	//		OAdp.Fill(m_Ds  ,"PSM_CITYww" ); 
	//		for (int i=0;i< m_Ds.Tables[1].Rows.Count ;i++)	
	//			cbCountry.Items.Add(  m_Ds.Tables["PSM_CITYww" ].Rows[i][0]  ); 
	

		}
		private void Deco_Adrs(string Adrs,ref string[] Res)
		{
			Res = new string[5]{"","","","",""}; 
			int Start_pos=0;
			int jpos=0;
            if (Adrs.IndexOf(",") > 0)
            {
                for (int i = 0; i < 5 && Adrs.Length > 4; i++)
                {
                    if (i == 4) Res[i] = Adrs.Substring(Start_pos, Adrs.Length - Start_pos);
                    else
                    {
                        jpos = Adrs.IndexOf(",", Start_pos);
                        if (jpos > -1) Res[i] = Adrs.Substring(Start_pos, jpos - Start_pos);
                        else { Res[i] = Res[i] = Adrs.Substring(Start_pos, Adrs.Length - Start_pos); i = 6; }
                        Start_pos = jpos + 1;
                    }
                    //	if (Res[i][0]==' ') Res[i]=Res[i].Substring(1,Res[i].Length -1); 
                    if (Res[i].Length > 0 && Res[i][0] == ' ') Res[i] = Res[i].Substring(1, Res[i].Length - 1);
                }
            }
            else Res[0] = Adrs;
    	}

		private void dlgAdrs_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";  //MessageBox.Show("4= " + In_adrs. .IndexOf(",",).ToString() ); 
			if (In_adrs !="" ) 
			{
				string[] Res=new string[5];
				Deco_Adrs(In_adrs,  ref Res);
				tStreet.Text = Res[0];
				cbCity.Text = Res[1];
				//cbCity.FindStringExact(Res[1],0);  
				//MessageBox.Show("city=" + cbCity.Text +"=");
				if (cbCity.Text =="") tCity.Text = Res[1];  
				cbSP.Text = Res[2];if (cbSP.Text =="") tSt.Text = Res[2];  
				tZip.Text = Res[3]; 
				cbCountry.Text =Res[4]; if (cbCountry.Text =="") tCountry.Text = Res[4]; 
			}
		}

		private void cbcities_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			//MessageBox.Show("CBCITY=" + cbCity.Text +"=");  
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void tStreet_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void tStreet_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = (e.KeyChar == 44); 
			
              
		}

		private void tZip_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			e.Handled = (e.KeyChar == 44); 
		}


		private void pictureBox3_Click(object sender, System.EventArgs e)
		{
			if (tCity.Text !="")
			{
				if (cbCity.FindStringExact(tCity.Text) <0)   
				{
					cbCity.Items.Add( tCity.Text);
					if (chkSave.Checked )  if (!add("INSERT INTO PSM_CITY ([City_Name]) VALUES ('" + tCity.Text + "')")) MessageBox.Show("Error while adding: " + tCity.Text + "    Err=" + MainMDI.stXP); 
				}
				cbCity.Text = tCity.Text;
			}
			if (tSt.Text !="")
			{
				if (cbSP.FindString(tSt.Text) <0)   
				{
					cbSP.Items.Add( tSt.Text);
					if (chkSave.Checked ) if (!add("INSERT INTO PSM_ST_PROV ([SP_NAME],[cu]) VALUES ('" + tSt.Text + "', '" + lCU.Text +  "')")) MessageBox.Show("Error while adding: " + tSt.Text + "    Err=" + MainMDI.stXP); 
				}
				cbSP.Text = tSt.Text ;
			}
			if (tCountry.Text !="")
			{
				if (cbCountry.FindString(tCountry.Text) <0)   
				{
					cbCountry.Items.Add( tCountry.Text);
					if (chkSave.Checked ) if (!add("INSERT INTO PSM_Country ([Country_Name]) VALUES ('" + tCountry.Text + "')")) MessageBox.Show("Error while adding: " + tCountry.Text + "    Err=" + MainMDI.stXP);  
				}
				cbCountry.Text = tCountry.Text;
			}


 

		}

		private bool add(string stsql)
		{
		
			try 
			{
				MainMDI.ExecSql(stsql);
				MainMDI.Write_JFS(stsql );
			}
		
			catch (SqlException Oexp) 
			{   
				MainMDI.stXP = Oexp.Message ; 
				return false;
			}
		   return true;

		}

		private void radioButton1_CheckedChanged(object sender, System.EventArgs e)
		{
			lCU.Text ="c";
		}

		private void radioButton2_CheckedChanged(object sender, System.EventArgs e)
		{
			lCU.Text ="u";
		}

		private void radioButton3_CheckedChanged(object sender, System.EventArgs e)
		{
			lCU.Text ="w";
		}
	

	






	

		
	}
}
