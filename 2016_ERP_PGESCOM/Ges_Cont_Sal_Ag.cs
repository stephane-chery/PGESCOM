using System;
using System.Diagnostics;
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
	/// Summary description for Ges_Company.
	/// </summary>
	public class Ges_Cont_Sal_Ag: System.Windows.Forms.Form
	{    
		private char in_C='C';
	//	private string MainMDI.M_stCon ;
		private string In_user_Name ;
		private int oldSC=0;
		private char srtType='A';
		private int ndxfound=-1;
		private int seelCol=0;
		private int ndxCLRD=-1;

		private ListViewColumnSorter lvSorter=null;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolBarButton add;
		private System.Windows.Forms.ToolBarButton del;
		private System.Windows.Forms.ToolBarButton edit;
		private System.Windows.Forms.ToolBarButton choose;
		private System.Windows.Forms.ToolBarButton Exit;
		public System.Windows.Forms.Label lCLID;
		public System.Windows.Forms.Label lFNLN;
		public System.Windows.Forms.Label leml;
		public System.Windows.Forms.Label lphn;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.PictureBox picExit;
		private System.Windows.Forms.GroupBox grpFind;
		private System.Windows.Forms.Button btnseek;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.ListView lvCSA;
		private System.Windows.Forms.ColumnHeader cpnyName;
		private System.Windows.Forms.ColumnHeader phone;
		private System.Windows.Forms.ColumnHeader EMAIL;
		private System.Windows.Forms.ColumnHeader Adrss;
		private System.Windows.Forms.ColumnHeader LID;
		private System.Windows.Forms.ToolBarButton find;
		public System.Windows.Forms.TextBox tKeyaaaaa;
		public System.Windows.Forms.TextBox tKey;
		private System.Windows.Forms.ToolBarButton em;
		private System.Windows.Forms.ImageList Fst_IL32;
        public PictureBox picCIP;
        private ToolBarButton ex;
		private System.ComponentModel.IContainer components;

		public Ges_Cont_Sal_Ag(char c)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			In_user_Name =MainMDI.User ;
			MainMDI.M_stCon =  MainMDI.M_stCon  ;
            in_C=c;
			lCLID.Text ="";
			lFNLN.Text ="";
			lvSorter = new ListViewColumnSorter(); 
			this.lvCSA.ListViewItemSorter  = lvSorter ; 
			lvCSA.Sorting =System.Windows.Forms.SortOrder.Ascending ;
			lvCSA.AutoArrange =true; 
			switch (c)
			{
				case 'C':
					this.Text ="Contacts";
					lvCSA.Columns[3].Text ="Company "; 
					fill_lvContact();
					break;
				case 'S':
					this.Text ="Sales ";
					lvCSA.Columns[3].Text ="Company "; 
				//	fill_lvContact();
					this.Text ="Sales";
					break;
				case 'A':
					this.Text ="Agents/Rep.";
					break;
			}
			btnseek.Text = "Search by:    " + lvCSA.Columns[0].Text ; 
			seelCol=0;


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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ges_Cont_Sal_Ag));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.add = new System.Windows.Forms.ToolBarButton();
            this.edit = new System.Windows.Forms.ToolBarButton();
            this.del = new System.Windows.Forms.ToolBarButton();
            this.choose = new System.Windows.Forms.ToolBarButton();
            this.Exit = new System.Windows.Forms.ToolBarButton();
            this.find = new System.Windows.Forms.ToolBarButton();
            this.em = new System.Windows.Forms.ToolBarButton();
            this.ex = new System.Windows.Forms.ToolBarButton();
            this.Fst_IL32 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.lCLID = new System.Windows.Forms.Label();
            this.lFNLN = new System.Windows.Forms.Label();
            this.leml = new System.Windows.Forms.Label();
            this.lphn = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tKeyaaaaa = new System.Windows.Forms.TextBox();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.grpFind = new System.Windows.Forms.GroupBox();
            this.btnseek = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tKey = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvCSA = new System.Windows.Forms.ListView();
            this.cpnyName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phone = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EMAIL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Adrss = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.picCIP = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            this.grpFind.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.add,
            this.edit,
            this.del,
            this.choose,
            this.Exit,
            this.find,
            this.em,
            this.ex});
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
            this.toolBar1.ImageList = this.Fst_IL32;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(913, 61);
            this.toolBar1.TabIndex = 1;
            this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
            // 
            // add
            // 
            this.add.ImageIndex = 0;
            this.add.Name = "add";
            this.add.Text = "New Contact";
            // 
            // edit
            // 
            this.edit.ImageIndex = 2;
            this.edit.Name = "edit";
            this.edit.Text = "Edit Contact";
            // 
            // del
            // 
            this.del.ImageIndex = 5;
            this.del.Name = "del";
            this.del.Text = "Disable Contact";
            // 
            // choose
            // 
            this.choose.ImageIndex = 4;
            this.choose.Name = "choose";
            this.choose.Text = "select";
            this.choose.Visible = false;
            // 
            // Exit
            // 
            this.Exit.ImageIndex = 5;
            this.Exit.Name = "Exit";
            this.Exit.Text = "EXIT";
            this.Exit.Visible = false;
            // 
            // find
            // 
            this.find.ImageIndex = 1;
            this.find.Name = "find";
            this.find.Text = "Find Contact";
            // 
            // em
            // 
            this.em.ImageIndex = 7;
            this.em.Name = "em";
            this.em.Text = "Send e-mail";
            this.em.Visible = false;
            // 
            // ex
            // 
            this.ex.ImageIndex = 8;
            this.ex.Name = "ex";
            this.ex.Text = "Exit";
            // 
            // Fst_IL32
            // 
            this.Fst_IL32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Fst_IL32.ImageStream")));
            this.Fst_IL32.TransparentColor = System.Drawing.Color.Transparent;
            this.Fst_IL32.Images.SetKeyName(0, "");
            this.Fst_IL32.Images.SetKeyName(1, "");
            this.Fst_IL32.Images.SetKeyName(2, "");
            this.Fst_IL32.Images.SetKeyName(3, "");
            this.Fst_IL32.Images.SetKeyName(4, "");
            this.Fst_IL32.Images.SetKeyName(5, "");
            this.Fst_IL32.Images.SetKeyName(6, "");
            this.Fst_IL32.Images.SetKeyName(7, "");
            this.Fst_IL32.Images.SetKeyName(8, "Log-Out-icon.png");
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(608, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // lCLID
            // 
            this.lCLID.BackColor = System.Drawing.Color.Gainsboro;
            this.lCLID.Location = new System.Drawing.Point(408, 16);
            this.lCLID.Name = "lCLID";
            this.lCLID.Size = new System.Drawing.Size(48, 16);
            this.lCLID.TabIndex = 4;
            this.lCLID.Visible = false;
            // 
            // lFNLN
            // 
            this.lFNLN.BackColor = System.Drawing.Color.Gainsboro;
            this.lFNLN.Location = new System.Drawing.Point(464, 16);
            this.lFNLN.Name = "lFNLN";
            this.lFNLN.Size = new System.Drawing.Size(48, 16);
            this.lFNLN.TabIndex = 5;
            this.lFNLN.Visible = false;
            // 
            // leml
            // 
            this.leml.BackColor = System.Drawing.Color.Gainsboro;
            this.leml.Location = new System.Drawing.Point(584, 16);
            this.leml.Name = "leml";
            this.leml.Size = new System.Drawing.Size(48, 16);
            this.leml.TabIndex = 7;
            this.leml.Visible = false;
            // 
            // lphn
            // 
            this.lphn.BackColor = System.Drawing.Color.Gainsboro;
            this.lphn.Location = new System.Drawing.Point(528, 16);
            this.lphn.Name = "lphn";
            this.lphn.Size = new System.Drawing.Size(48, 16);
            this.lphn.TabIndex = 6;
            this.lphn.Visible = false;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(712, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(48, 20);
            this.button1.TabIndex = 158;
            this.button1.Text = "Search";
            this.button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(392, 8);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 20);
            this.label4.TabIndex = 157;
            this.label4.Text = "Keyword:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Visible = false;
            // 
            // tKeyaaaaa
            // 
            this.tKeyaaaaa.BackColor = System.Drawing.Color.DarkSalmon;
            this.tKeyaaaaa.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKeyaaaaa.ForeColor = System.Drawing.Color.Blue;
            this.tKeyaaaaa.Location = new System.Drawing.Point(472, 8);
            this.tKeyaaaaa.MaxLength = 60;
            this.tKeyaaaaa.Name = "tKeyaaaaa";
            this.tKeyaaaaa.Size = new System.Drawing.Size(240, 20);
            this.tKeyaaaaa.TabIndex = 156;
            this.tKeyaaaaa.Visible = false;
            this.tKeyaaaaa.TextChanged += new System.EventHandler(this.tKey_TextChanged);
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.Image = ((System.Drawing.Image)(resources.GetObject("picExit.Image")));
            this.picExit.Location = new System.Drawing.Point(728, 8);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(40, 40);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 200;
            this.picExit.TabStop = false;
            this.picExit.Visible = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // grpFind
            // 
            this.grpFind.Controls.Add(this.btnseek);
            this.grpFind.Controls.Add(this.label2);
            this.grpFind.Controls.Add(this.tKey);
            this.grpFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFind.ForeColor = System.Drawing.Color.Blue;
            this.grpFind.Location = new System.Drawing.Point(0, 61);
            this.grpFind.Name = "grpFind";
            this.grpFind.Size = new System.Drawing.Size(913, 43);
            this.grpFind.TabIndex = 201;
            this.grpFind.TabStop = false;
            this.grpFind.Visible = false;
            // 
            // btnseek
            // 
            this.btnseek.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnseek.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnseek.Location = new System.Drawing.Point(408, 14);
            this.btnseek.Name = "btnseek";
            this.btnseek.Size = new System.Drawing.Size(376, 24);
            this.btnseek.TabIndex = 161;
            this.btnseek.Text = "Search by:";
            this.btnseek.Click += new System.EventHandler(this.btnseek_Click);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Firebrick;
            this.label2.Location = new System.Drawing.Point(0, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 20);
            this.label2.TabIndex = 160;
            this.label2.Text = "Keyword:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.PeachPuff;
            this.tKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.ForeColor = System.Drawing.Color.Black;
            this.tKey.Location = new System.Drawing.Point(80, 16);
            this.tKey.MaxLength = 60;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(320, 20);
            this.tKey.TabIndex = 159;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvCSA);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 104);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(913, 334);
            this.groupBox1.TabIndex = 202;
            this.groupBox1.TabStop = false;
            // 
            // lvCSA
            // 
            this.lvCSA.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvCSA.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cpnyName,
            this.phone,
            this.EMAIL,
            this.Adrss,
            this.LID});
            this.lvCSA.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCSA.ForeColor = System.Drawing.Color.Blue;
            this.lvCSA.FullRowSelect = true;
            this.lvCSA.GridLines = true;
            this.lvCSA.Location = new System.Drawing.Point(3, 16);
            this.lvCSA.MultiSelect = false;
            this.lvCSA.Name = "lvCSA";
            this.lvCSA.Size = new System.Drawing.Size(907, 315);
            this.lvCSA.TabIndex = 1;
            this.lvCSA.UseCompatibleStateImageBehavior = false;
            this.lvCSA.View = System.Windows.Forms.View.Details;
            this.lvCSA.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvCSA_ColumnClick);
            this.lvCSA.SelectedIndexChanged += new System.EventHandler(this.lvCSA_SelectedIndexChanged_1);
            this.lvCSA.DoubleClick += new System.EventHandler(this.lvCSA_DoubleClick);
            // 
            // cpnyName
            // 
            this.cpnyName.Text = "Name";
            this.cpnyName.Width = 278;
            // 
            // phone
            // 
            this.phone.Text = "Phone";
            this.phone.Width = 102;
            // 
            // EMAIL
            // 
            this.EMAIL.Text = "E-mail";
            this.EMAIL.Width = 164;
            // 
            // Adrss
            // 
            this.Adrss.Text = "";
            this.Adrss.Width = 182;
            // 
            // LID
            // 
            this.LID.Text = "";
            this.LID.Width = 0;
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(553, 8);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(39, 42);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 267;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // Ges_Cont_Sal_Ag
            // 
            this.AcceptButton = this.btnseek;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(913, 438);
            this.Controls.Add(this.picCIP);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpFind);
            this.Controls.Add(this.picExit);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.tKeyaaaaa);
            this.Controls.Add(this.leml);
            this.Controls.Add(this.lphn);
            this.Controls.Add(this.lFNLN);
            this.Controls.Add(this.lCLID);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.toolBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ges_Cont_Sal_Ag";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Contacts";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ges_Cont_Sal_Ag_Load);
            this.Resize += new System.EventHandler(this.Ges_Cont_Sal_Ag_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            this.grpFind.ResumeLayout(false);
            this.grpFind.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion


/*
		private void fill_lvCmpny(int col )
		{ 

			string stsql="";
		    string tblName="PSM_Company";
			switch (col)
			{
				case 0: 
					stsql = "select * FROM PSM_Company order by Cpny_Name1";
				    break;
				case 1:
					 stsql = "select * FROM PSM_Company order by Tel1";
					break;
				case 2: 
					 stsql = "select * FROM PSM_Company order by Email";
					break;
				case 3: 
					 stsql = "select * FROM PSM_Company order by M_adrs";
					break;
			}

		  //  string stsql = "select * FROM PSM_Company order by Cpny_Name1";

			SqlConnection Ipsm_Conn  = new SqlConnection(MainMDI.M_stCon  );
			SqlDataAdapter Ipsm_OAdp = new SqlDataAdapter(stsql , Ipsm_Conn );
			DataSet Ipsm_Ds = new DataSet(tblName) ;
			Ipsm_OAdp.Fill(Ipsm_Ds  ,tblName ); 
			label1.Text = Ipsm_Ds.Tables[0].Rows.Count.ToString (); 
			label1.Refresh();
		//	lvCompany.Clear ();
			for (int i=0;i< Ipsm_Ds.Tables[0].Rows.Count ;i++)
			{
				ListViewItem lvI= lvCompany.Items.Add(Ipsm_Ds.Tables["PSM_Company"].Rows[i][1].ToString ()  );
				//lvCompany.Items[lvCompany.Items.Count-1].SubItems[0].ForeColor =Color.Brown ;   
			    lvI.SubItems.Add(Ipsm_Ds.Tables["PSM_Company"].Rows[i][11].ToString()  ); 
			    lvI.SubItems.Add(Ipsm_Ds.Tables["PSM_Company"].Rows[i][16].ToString () ); 
			    lvI.SubItems.Add(Ipsm_Ds.Tables["PSM_Company"].Rows[i][4].ToString () ); 
				//lvCompany.Items[lvCompany.Items.Count-1].SubItems[0].ForeColor =Color.Tomato  ; 
			}

		}
*/		

		private void fill_lvContact()
		{ 

		//	string stSql = "select * FROM PSM_Contacts order by First_Name";
			string stSql = "SELECT PSM_Contacts.*, PSM_COMPANY.Cpny_Name1, [First_Name] + ' ' + [Last_Name] AS Expr1, * " +
				           " FROM PSM_Contacts INNER JOIN PSM_COMPANY ON PSM_Contacts.Company_ID = PSM_COMPANY.Cpny_ID " +
				           " WHERE (((PSM_Contacts.First_Name)<>'')) ORDER BY [First_Name] + ' ' + [Last_Name]";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
            OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
			lvCSA.Items.Clear();
			lvCSA.Refresh ();
			while (Oreadr.Read ())
			{
				ListViewItem lvI= lvCSA.Items.Add( Oreadr["First_Name"].ToString () + " " + Oreadr["Last_Name"].ToString () );
				string st1=(Oreadr["Main_TEL"].ToString()=="") ? " "   : Oreadr["Main_TEL"].ToString()  ;lvI.SubItems.Add(st1+" ");
		   	    st1=( Oreadr["Email Address"].ToString()=="") ? " "   :  Oreadr["Email Address"].ToString(); lvI.SubItems.Add(st1);
				st1=( Oreadr["Cpny_Name1"].ToString()=="") ? " "  :  Oreadr["Cpny_Name1"].ToString();lvI.SubItems.Add(st1);
			    lvI.SubItems.Add(Oreadr["Contact_ID"].ToString());
				if ( Oreadr["JOBTitle"].ToString ()=="~~") lvI.ForeColor=Color.CornflowerBlue; 
	

			}

		}

	

	
		private void lvCSA_DoubleClick(object sender, System.EventArgs e)
		{
			if (MainMDI.profile !='R')
			{
				this.Cursor = Cursors.WaitCursor ;
				edit_CSA();
				this.Cursor = Cursors.Default ;
			}		
			else MessageBox.Show("ACCESS DENIED... ",MainMDI.User ,MessageBoxButtons.OK ,MessageBoxIcon.Stop ); 





				//frmComapny.lUserName.Text = MainMDI.User    ;
			
		}
		private void edit_CSA()
		{
			if (lvCSA.SelectedItems.Count ==1)
			{
				
				switch (in_C)
				{
					case 'C':
						Contacts  frm_Contact=new Contacts('C',lvCSA.SelectedItems[0].SubItems[4].Text    ,'M');
						frm_Contact.grpContact.Enabled =(lvCSA.SelectedItems[0].ForeColor != Color.CornflowerBlue);  
                        frm_Contact.ShowDialog();  
						if (frm_Contact.lsave.Text =="Y") // && frm_Contact.grpContact.Enabled )  
						{
							try
							{ 
								//string st=frm_Contact.tphone1.text;
								string st=frm_Contact.tt.Text ;
								string stSql= "UPDATE PSM_Contacts SET " +
									" [Prefix_ID]='" + frm_Contact.lprefID.Text + "', " +
									" [First_Name]='" + frm_Contact.tFname.Text.Replace("'","''") + "', " +
									" [Last_Name]='" + frm_Contact.tLname.Text.Replace("'","''")  + "', " +
									" [JOBTitle]='" + frm_Contact.tsufx.Text.Replace("'","''")  + "', " +
									" [Company_ID]='" + frm_Contact.lcpnyIDD.Text.Replace("'","''")  + "', " +
									" [Department]='" + frm_Contact.tdepart.Text.Replace("'","''")  + "', " +
									" [Main_TEL]='" + st.Replace("'","''")  + "', " +
									" [Extension]='" + frm_Contact.TTExt.Text.Replace("'","''")  + "', " +
									" [Fax Number]='" +  frm_Contact.tFax.Text.Replace("'","''")  + "', " +
									" [Cell Number]='" + frm_Contact.tCell.Text.Replace("'","''")  + "', " +
									" [Pager Number]='" + frm_Contact.tpager.Text.Replace("'","''")  + "', " +
									" [Email Address]='" + frm_Contact.tEmail.Text.Replace("'","''")  + "', " +
									" [Catalog Number]='" + frm_Contact.tCatalog.Text.Replace("'","''")  + "', " + 
									" [Tel2]='" + frm_Contact.tTel2.Text.Replace("'","''") + "', " +
									" [Ext2]='" + frm_Contact.TText2.Text.Replace("'","''") + "' " +
									" WHERE [Contact_ID]=" + lvCSA.SelectedItems[0].SubItems[4].Text   ;
								MainMDI.ExecSql(stSql);
								lvCSA.SelectedItems[0].SubItems[0].Text =   frm_Contact.tFname.Text + " " + frm_Contact.tLname.Text;
								lvCSA.SelectedItems[0].SubItems[1].Text =   frm_Contact.tt.Text;
								lvCSA.SelectedItems[0].SubItems[2].Text =   frm_Contact.tEmail.Text;
								lvCSA.SelectedItems[0].SubItems[3].Text =   frm_Contact.lcomp.Text   ; //.tFname.Text + " " + frm_Contact.tLname.Text;

							
							}
							catch (SqlException Oexp) 
							{
								MessageBox.Show("Updating CONTACT failed   ERROR msg= " + Oexp.Message );
							}
						}
						break;
					case 'S':
						break;
					case 'A':
						break;
				}

			}
		}

		public bool Add_CSA(string r_cpnyNm)
		{
			bool Cont=true;
			Contacts  frm_Contact=new Contacts('C',"*" ,'N');
			while (Cont)
			{
				switch (in_C)
				{
					case 'C':
						frm_Contact.lsave.Text ="N";
						frm_Contact.cbMainCmpny.Text = r_cpnyNm ;// tCompanyName1.Text ;
						frm_Contact.ShowDialog();  
						if (frm_Contact.lsave.Text =="Y")  
						{

							//	if (MainMDI.Find_One_Field("SELECT PSM_Contacts.Contact_ID FROM PSM_Contacts where First_Name='" + frm_Contact.tFname.Text + "' and Last_Name='" + frm_Contact.tLname.Text + "'")==MainMDI.VIDE )	
							if (MainMDI.Find_One_Field("SELECT PSM_Contacts.Contact_ID FROM PSM_Contacts where First_Name='" + frm_Contact.tFname.Text.Replace("'","''")  + "' and Last_Name='" + frm_Contact.tLname.Text.Replace("'","''")  + "' and Company_ID=" + frm_Contact.lcpnyIDD.Text )==MainMDI.VIDE )					
							{
								try
								{
									string st = MainMDI.Find_One_Field("SELECT PSM_Contacts.Contact_ID FROM PSM_Contacts ORDER BY PSM_Contacts.Contact_ID DESC");
								//	long ID=(st==MainMDI.VIDE ) ? 1 : Convert.ToInt32(st) + 1;  
								//	string stSql= "INSERT INTO PSM_Contacts ([Contact_ID],[Prefix_ID], " + 
									string stSql= "INSERT INTO PSM_Contacts ([Prefix_ID], " + 
										" [First_Name],[Last_Name],[JOBTitle],[Company_ID],[Department],[Main_TEL],[Extension], " + 
										" [Fax Number],[Cell Number],[Pager Number],[Email Address],[Catalog Number],[Tel2], " +
										" [Ext2]) VALUES (" +
										frm_Contact.lprefID.Text + ", '" + 
										frm_Contact.tFname.Text.Replace("'","''")    + "', '" +
										frm_Contact.tLname.Text.Replace("'","''")   + "', '" +
										frm_Contact.tsufx.Text.Replace("'","''") + "', " +
										frm_Contact.lcpnyIDD.Text + ", '" +
										frm_Contact.tdepart.Text.Replace("'","''")+ "', '" + 
										frm_Contact.tt.Text.Replace("'","''")  + "', '" + 
										frm_Contact.TTExt.Text.Replace("'","''")  + "', '" + 
										frm_Contact.tFax.Text.Replace("'","''")  + "', '" + 
										frm_Contact.tCell.Text.Replace("'","''") + "', '" +  
										frm_Contact.tpager.Text.Replace("'","''")  + "', '" +  
										frm_Contact.tEmail.Text.Replace("'","''") + "', '"    + 
										frm_Contact.tCatalog.Text.Replace("'","''") + "', '" + 
										frm_Contact.tTel2.Text.Replace("'","''") + "', '" +
										frm_Contact.TText2.Text.Replace("'","''") +"')" ;
									MainMDI.ExecSql(stSql);
									MainMDI.Write_JFS(stSql );
									st = MainMDI.Find_One_Field("SELECT PSM_Contacts.Contact_ID FROM PSM_Contacts where First_Name='" + frm_Contact.tFname.Text.Replace("'","''")  + "' and Last_Name='" + frm_Contact.tLname.Text.Replace("'","''")  + "'");
									if (st!=MainMDI.VIDE ) 
									{
										ListViewItem lvI= lvCSA.Items.Add( frm_Contact.tFname.Text + " " + frm_Contact.tLname.Text );
										string st1=(frm_Contact.tt.Text=="") ? " "   : frm_Contact.tt.Text ;lvI.SubItems.Add(st1+" ");
										st1=( frm_Contact.tEmail.Text=="") ? " "   :  frm_Contact.tEmail.Text; lvI.SubItems.Add(st1);
										st1=( frm_Contact.cbMainCmpny.Text=="") ? " "  :  frm_Contact.cbMainCmpny.Text;lvI.SubItems.Add(st1);
										lvI.SubItems.Add(st);
	
										return true;
									}
									else return false;
								}
								catch (SqlException Oexp)
								{
									MessageBox.Show("Adding CONTACT failed...= " + Oexp.Message );
								}
							}
							else MessageBox.Show("Conatct Already Exists !!!"); 
						}
						else Cont =false;
						break;
					case 'S':
						break;
					case 'A':
						break;
				}
			}
             return false;
		
		}



		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{

			if (MainMDI.profile !='R')
			{
				switch (toolBar1.Buttons.IndexOf(e.Button))    
				{
					case 0: 
						Add_CSA(MainMDI.VIDE );   //  ) fill_lvContact() ;
						break;
					case 1: 	
						edit_CSA();
						break;
					case 2:
						//	if (MainMDI.User == "Admin" || MainMDI.User == "hnassrat") 
						//	{
								if (MainMDI.Confirm("WANT TO DELETE '" +lvCSA.SelectedItems[0].Text + "'  ??  " ))
								{
									string stDel="";
								//	if (in_C =='C') stDel= "delete * from PSM_Contacts where Contact_ID=" + lvCSA.SelectedItems[0].SubItems[4].Text; 
									if (in_C =='C') stDel= "UPDATE PSM_Contacts SET [JOBTitle]='~~' WHERE [Contact_ID]=" + lvCSA.SelectedItems[0].SubItems[4].Text   ;
									if (in_C =='A') stDel= ""; 
									if (in_C =='S') stDel= ""; 
									if (stDel !="") if (MainMDI.ExecSql(stDel )) 
													{
														MainMDI.Write_JFS(stDel.Replace("'","''")  );
														lvCSA.SelectedItems[0].ForeColor = Color.CornflowerBlue;
													//	lvCSA.Items[lvCSA.SelectedItems[0].Index ].Remove();   
													}
								}
						//	}
						//	MessageBox.Show("No permission !!!  Please Contact your Admin..."); 
						break;
					case 3: 	
						if (lvCSA.SelectedItems.Count ==1) 
						{
							lCLID.Text =  lvCSA.SelectedItems[0].SubItems[4].Text;
							lphn.Text =  lvCSA.SelectedItems[0].SubItems[1].Text;
							leml.Text =  lvCSA.SelectedItems[0].SubItems[2].Text;
							lFNLN.Text =  lvCSA.SelectedItems[0].Text;
							this.Hide(); 

						}
						break;
					case 7: 	
						this.Hide ();	
						break;
					case 5:  //find Quote
						grpFind.Visible =!grpFind.Visible ;
						break;
                    case 6:
						if (lvCSA.SelectedItems.Count ==1)
						{
							if (lvCSA.SelectedItems[0].SubItems[2].Text.Length>6 && lvCSA.SelectedItems[0].SubItems[2].Text.IndexOf("@")>0  )
							{
							
								string sentEmail = lvCSA.SelectedItems[0].SubItems[2].Text;
								string subject = " ";
								string body = " ";
								string msg = string.Format( "mailto:{0}?subject={1}&body={2}", sentEmail ,
									subject, body);
								Process.Start( msg);
							}
							else MessageBox.Show("Invalid e-mail.....!!!!");  
						}
						break;
				}
			}
			else 
			{
				if (toolBar1.Buttons.IndexOf(e.Button) == 4)	this.Hide();
				else MessageBox.Show("ACCESS DENIED... ",MainMDI.User ,MessageBoxButtons.OK ,MessageBoxIcon.Stop );
			}
					
			  
		
		}

	

	
		private void lvCSA_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			//MessageBox.Show (   e.Column.ToString() + " SorterCol= " + lvSorter.SortColumn.ToString()   );

			btnseek.Text = "Search by:    " + lvCSA.Columns[e.Column].Text ; 
			seelCol=e.Column; 
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
				//	lvSorter.Order = (srtType=='A') ? System.Windows.Forms.SortOrder.Ascending : SortOrder.Descending;
				//	srtType=(srtType=='A') ? 'D' : 'A';
				}
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				lvSorter.Order = (srtType=='A') ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
				srtType=(srtType=='A') ? 'D' : 'A';
				lvSorter.SortColumn = e.Column;

				//lvSorter.Order = SortOrder.Ascending;
			}

			// Perform the sort with these new sort options.
			myListView.Sort();
			oldSC=lvSorter.SortColumn;
			lvSorter.SortColumn =0;


	
	    //	lvCSA.Items.Clear();
		//	lvCompany.Refresh ();
         //	fill_lvCmpny_Fast  (e.Column );
   

		}

		private void lvCSA_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	
			private void button1_Click(object sender, System.EventArgs e)
			{
				bool FOUND=false;
				
				if (button1.Text=="Search") ndxfound =0;  
				for (int i=ndxfound;i<lvCSA.Items.Count;i++)
					if (lvCSA.Items[i].Text.ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1) 
					{   
						lvCSA.SelectedIndices.Contains(i);
						ndxfound =i+1;
						i=lvCSA.Items.Count;
						lvCSA_SelectedIndexChanged(sender,e);
						if (ndxfound <lvCSA.Items.Count) button1.Text ="Next"; 
						FOUND=true;
					}
				if (!FOUND) 
				{
						ndxfound=0;
					button1.Text ="Search"; 
					MessageBox.Show("KeyWord not Found !!!!"); 
				}
			}

		private void tKey_TextChanged(object sender, System.EventArgs e)
		{
			
		}

		private void Ges_Cont_Sal_Ag_Resize(object sender, System.EventArgs e)
		{
			picExit.Left =this.Width -48;
		}

		private void picExit_Click(object sender, System.EventArgs e)
		{
				this.Hide ();	
		}

		private void lvCSA_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
	      	if (ndxCLRD>-1) lvCSA.Items[ndxCLRD].BackColor =Color.WhiteSmoke ; 
		}

		private void btnseek_Click(object sender, System.EventArgs e)
		{
			int ideb=0;
			bool found=false;
			if (tKey.Text !="")
			{
				if (ndxCLRD>-1) 
				{ 
					lvCSA.Items[ndxCLRD].BackColor =Color.WhiteSmoke ; 
					ideb=ndxCLRD+1;
					ndxCLRD=-1;
				}
				for (int i=ideb;i<lvCSA.Items.Count ;i++)
				{
					if (( lvCSA.Items[i].SubItems[seelCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1)) 
					{
						lvCSA.Items[i].BackColor =Color.Yellow    ;
						lvCSA.Items[i].Selected =true;
						lvCSA.Items[i].EnsureVisible(); 
						ndxCLRD=i;
						i=lvCSA.Items.Count+1;
						found=true;
						btnseek.Text = btnseek.Text.Replace("Search","Next ") ; 
					}
				}
			}
			if (!found) { MessageBox.Show("Sorry, Not Found !!!..."); ndxCLRD=-1;}
		}

		private void Ges_Cont_Sal_Ag_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!"; 
				MainMDI.Write_Whodo_SSetup("Contacts",'I');
                picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
		}


	


	




		

	



	

	
	
	}
}
