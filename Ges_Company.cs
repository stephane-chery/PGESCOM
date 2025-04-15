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
	/// Summary description for Ges_Company.
	/// </summary>
	public class Ges_Company : System.Windows.Forms.Form
	{    
		private string In_stCon ;
		private string In_user_Name ;
		private int oldSC=0;
		private char srtType='A';
		private int seelCol=0;
		private int ndxCLRD=-1;

		private ListViewColumnSorter lvSorter=null;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ToolBarButton add;
		private System.Windows.Forms.ToolBarButton del;
		private System.Windows.Forms.ToolBarButton edit;
		private System.Windows.Forms.ToolBarButton exit;
		private System.Windows.Forms.PictureBox picExit;
		private System.Windows.Forms.ToolBarButton fix;
		private System.Windows.Forms.GroupBox grpFind;
		private System.Windows.Forms.Button btnseek;
        private System.Windows.Forms.Label label2;
		private System.Windows.Forms.ToolBarButton Find;
		public System.Windows.Forms.TextBox tKey;
		private System.Windows.Forms.ImageList Fst_IL32;
        private GroupBox grpSrch;
        private GroupBox groupBox1;
        private ListView lvCompany;
        private ColumnHeader cpnyName;
        private ColumnHeader phone;
        private ColumnHeader EMAIL;
        private ColumnHeader adrs;
        private ColumnHeader cpnyID;
        private ToolStrip TSmain;
        private ToolStripButton Newcpny;
        private ToolStripButton del_cpny;
        private ToolStripButton seek_cpny;
        private ToolStripButton exiit;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
		private System.ComponentModel.IContainer components;

		public Ges_Company()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			In_user_Name =MainMDI.User ;
			In_stCon =  MainMDI.M_stCon  ;

			lvSorter = new ListViewColumnSorter(); 
			this.lvCompany.ListViewItemSorter  = lvSorter ; 
			lvCompany.Sorting =System.Windows.Forms.SortOrder.Ascending ;
			lvCompany.AutoArrange =true; 
	    	fill_lvCmpny_Fast(0);
			btnseek.Text = "Search by:    " + lvCompany.Columns[0].Text ; 
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Ges_Company));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.add = new System.Windows.Forms.ToolBarButton();
            this.edit = new System.Windows.Forms.ToolBarButton();
            this.del = new System.Windows.Forms.ToolBarButton();
            this.exit = new System.Windows.Forms.ToolBarButton();
            this.fix = new System.Windows.Forms.ToolBarButton();
            this.Find = new System.Windows.Forms.ToolBarButton();
            this.Fst_IL32 = new System.Windows.Forms.ImageList(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.grpFind = new System.Windows.Forms.GroupBox();
            this.btnseek = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tKey = new System.Windows.Forms.TextBox();
            this.grpSrch = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvCompany = new System.Windows.Forms.ListView();
            this.cpnyName = new System.Windows.Forms.ColumnHeader();
            this.phone = new System.Windows.Forms.ColumnHeader();
            this.EMAIL = new System.Windows.Forms.ColumnHeader();
            this.adrs = new System.Windows.Forms.ColumnHeader();
            this.cpnyID = new System.Windows.Forms.ColumnHeader();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.Newcpny = new System.Windows.Forms.ToolStripButton();
            this.del_cpny = new System.Windows.Forms.ToolStripButton();
            this.seek_cpny = new System.Windows.Forms.ToolStripButton();
            this.exiit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.grpFind.SuspendLayout();
            this.grpSrch.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.TSmain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.AutoSize = false;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.add,
            this.edit,
            this.del,
            this.exit,
            this.fix,
            this.Find});
            this.toolBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.Font = new System.Drawing.Font("Trebuchet MS", 8.25F);
            this.toolBar1.ImageList = this.Fst_IL32;
            this.toolBar1.Location = new System.Drawing.Point(189, 40);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(313, 44);
            this.toolBar1.TabIndex = 1;
            this.toolBar1.Visible = false;
            // 
            // add
            // 
            this.add.ImageIndex = 0;
            this.add.Name = "add";
            this.add.Text = "New Company";
            // 
            // edit
            // 
            this.edit.ImageIndex = 2;
            this.edit.Name = "edit";
            this.edit.Text = "Edit Company";
            // 
            // del
            // 
            this.del.ImageIndex = 1;
            this.del.Name = "del";
            this.del.Text = "Delete Company";
            this.del.Visible = false;
            // 
            // exit
            // 
            this.exit.ImageIndex = 3;
            this.exit.Name = "exit";
            this.exit.Text = "Exit";
            this.exit.Visible = false;
            // 
            // fix
            // 
            this.fix.Enabled = false;
            this.fix.Name = "fix";
            this.fix.Text = "Fix-ADRS";
            this.fix.Visible = false;
            // 
            // Find
            // 
            this.Find.ImageIndex = 1;
            this.Find.Name = "Find";
            this.Find.Text = "Find Company";
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
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(608, 408);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "label1";
            // 
            // grpFind
            // 
            this.grpFind.Controls.Add(this.TSmain);
            this.grpFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFind.ForeColor = System.Drawing.Color.Blue;
            this.grpFind.Location = new System.Drawing.Point(0, 0);
            this.grpFind.Name = "grpFind";
            this.grpFind.Size = new System.Drawing.Size(854, 72);
            this.grpFind.TabIndex = 202;
            this.grpFind.TabStop = false;
            // 
            // btnseek
            // 
            this.btnseek.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnseek.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnseek.Location = new System.Drawing.Point(411, 9);
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
            this.label2.Location = new System.Drawing.Point(3, 11);
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
            this.tKey.Location = new System.Drawing.Point(83, 11);
            this.tKey.MaxLength = 60;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(320, 20);
            this.tKey.TabIndex = 159;
            // 
            // grpSrch
            // 
            this.grpSrch.Controls.Add(this.toolBar1);
            this.grpSrch.Controls.Add(this.btnseek);
            this.grpSrch.Controls.Add(this.label2);
            this.grpSrch.Controls.Add(this.tKey);
            this.grpSrch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSrch.Location = new System.Drawing.Point(0, 72);
            this.grpSrch.Name = "grpSrch";
            this.grpSrch.Size = new System.Drawing.Size(854, 39);
            this.grpSrch.TabIndex = 204;
            this.grpSrch.TabStop = false;
            this.grpSrch.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvCompany);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 111);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(854, 419);
            this.groupBox1.TabIndex = 206;
            this.groupBox1.TabStop = false;
            // 
            // lvCompany
            // 
            this.lvCompany.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvCompany.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.cpnyName,
            this.phone,
            this.EMAIL,
            this.adrs,
            this.cpnyID});
            this.lvCompany.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCompany.ForeColor = System.Drawing.Color.Blue;
            this.lvCompany.FullRowSelect = true;
            this.lvCompany.GridLines = true;
            this.lvCompany.Location = new System.Drawing.Point(3, 16);
            this.lvCompany.MultiSelect = false;
            this.lvCompany.Name = "lvCompany";
            this.lvCompany.Size = new System.Drawing.Size(848, 400);
            this.lvCompany.TabIndex = 1;
            this.lvCompany.UseCompatibleStateImageBehavior = false;
            this.lvCompany.View = System.Windows.Forms.View.Details;
            this.lvCompany.SelectedIndexChanged += new System.EventHandler(this.lvCompany_SelectedIndexChanged);
            this.lvCompany.DoubleClick += new System.EventHandler(this.lvCompany_DoubleClick);
            this.lvCompany.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvCompany_ColumnClick);
            // 
            // cpnyName
            // 
            this.cpnyName.Text = "Name";
            this.cpnyName.Width = 228;
            // 
            // phone
            // 
            this.phone.Text = "Phone";
            this.phone.Width = 98;
            // 
            // EMAIL
            // 
            this.EMAIL.Text = "E-mail";
            this.EMAIL.Width = 127;
            // 
            // adrs
            // 
            this.adrs.Text = "Main Address";
            this.adrs.Width = 298;
            // 
            // cpnyID
            // 
            this.cpnyID.Text = "";
            this.cpnyID.Width = 0;
            // 
            // TSmain
            // 
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Newcpny,
            this.del_cpny,
            this.seek_cpny,
            this.exiit,
            this.toolStripButton1,
            this.toolStripButton2});
            this.TSmain.Location = new System.Drawing.Point(3, 16);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(848, 52);
            this.TSmain.TabIndex = 258;
            this.TSmain.Text = "toolStrip2";
            // 
            // Newcpny
            // 
            this.Newcpny.ForeColor = System.Drawing.Color.Black;
            this.Newcpny.Image = global::PGESCOM.Properties.Resources.new_48x48;
            this.Newcpny.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Newcpny.Name = "Newcpny";
            this.Newcpny.Size = new System.Drawing.Size(80, 49);
            this.Newcpny.Text = "New Company";
            this.Newcpny.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Newcpny.ToolTipText = "New Company";
            this.Newcpny.DisplayStyleChanged += new System.EventHandler(this.Newcpny_DisplayStyleChanged);
            this.Newcpny.Click += new System.EventHandler(this.Newcpny_Click);
            // 
            // del_cpny
            // 
            this.del_cpny.ForeColor = System.Drawing.Color.Black;
            this.del_cpny.Image = global::PGESCOM.Properties.Resources.remove1;
            this.del_cpny.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del_cpny.Name = "del_cpny";
            this.del_cpny.Size = new System.Drawing.Size(90, 49);
            this.del_cpny.Text = "Delete Company";
            this.del_cpny.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.del_cpny.ToolTipText = "Delete Company";
            this.del_cpny.Visible = false;
            // 
            // seek_cpny
            // 
            this.seek_cpny.ForeColor = System.Drawing.Color.Black;
            this.seek_cpny.Image = global::PGESCOM.Properties.Resources.Magnifying_Glass_2_48x48;
            this.seek_cpny.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.seek_cpny.Name = "seek_cpny";
            this.seek_cpny.Size = new System.Drawing.Size(91, 49);
            this.seek_cpny.Text = "search Company";
            this.seek_cpny.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.seek_cpny.ToolTipText = "Save Company";
            this.seek_cpny.Click += new System.EventHandler(this.seek_cpny_Click);
            // 
            // exiit
            // 
            this.exiit.ForeColor = System.Drawing.Color.Black;
            this.exiit.Image = global::PGESCOM.Properties.Resources.Log_Off;
            this.exiit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exiit.Name = "exiit";
            this.exiit.Size = new System.Drawing.Size(47, 49);
            this.exiit.Text = "   Exit   ";
            this.exiit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exiit.ToolTipText = "Exit";
            this.exiit.Click += new System.EventHandler(this.exiit_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::PGESCOM.Properties.Resources.folder_full_accept;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 49);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Visible = false;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::PGESCOM.Properties.Resources.folder_full_delete;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 49);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Visible = false;
            // 
            // picExit
            // 
            this.picExit.BackColor = System.Drawing.Color.Transparent;
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.Image = ((System.Drawing.Image)(resources.GetObject("picExit.Image")));
            this.picExit.Location = new System.Drawing.Point(736, 8);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(40, 40);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 200;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // Ges_Company
            // 
            this.AcceptButton = this.btnseek;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(854, 530);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.grpSrch);
            this.Controls.Add(this.grpFind);
            this.Controls.Add(this.picExit);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Ges_Company";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ges_Company";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Ges_Company_Load);
            this.Resize += new System.EventHandler(this.Ges_Company_Resize);
            this.grpFind.ResumeLayout(false);
            this.grpFind.PerformLayout();
            this.grpSrch.ResumeLayout(false);
            this.grpSrch.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            this.ResumeLayout(false);

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

			SqlConnection Ipsm_Conn  = new SqlConnection(In_stCon  );
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

		private void fill_lvCmpny_Fast(int col )
		{ 

			string stSql="";
			switch (col)
			{
				case 0: 
					stSql = "select * FROM PSM_Company order by Cpny_Name1";
					break;
				case 1:
				//	stSql = "select * FROM PSM_Company order by Tel1";
					break;
				case 2: 
				//	stSql = "select * FROM PSM_Company order by Email";
					break;
				case 3: 
				//	stSql = "select * FROM PSM_Company order by M_adrs";
					break;
			}


			SqlConnection OConn  = new SqlConnection(In_stCon  );
            OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
			//	lvCompany.Clear ();
			while (Oreadr.Read ())
			{
				ListViewItem lvI= lvCompany.Items.Add( Oreadr["Cpny_Name1"].ToString () );
				//lvCompany.Items[lvCompany.Items.Count-1].SubItems[0].ForeColor =Color.Brown ;   
				string st1=(Oreadr["Tel1"].ToString()=="") ? MainMDI.VIDE  : Oreadr["Tel1"].ToString()  ;lvI.SubItems.Add( st1  ); 
				 st1=( Oreadr["Email"].ToString()=="") ? MainMDI.VIDE  :  Oreadr["Email"].ToString(); lvI.SubItems.Add(st1); 
				 st1=( Oreadr["M_Adrs"].ToString()=="") ? MainMDI.VIDE  :  Oreadr["M_Adrs"].ToString();lvI.SubItems.Add(st1 ); 
				 lvI.SubItems.Add(Oreadr["Cpny_ID"].ToString() ); 

				//lvCompany.Items[lvCompany.Items.Count-1].SubItems[0].ForeColor =Color.Tomato  ; 
			}

		}

	
		private void lvCompany_DoubleClick(object sender, System.EventArgs e)
		{
			if (MainMDI.profile !='R')
			{
				this.Cursor = Cursors.WaitCursor ;
				if (lvCompany.SelectedItems.Count ==1)
					edit_cpny(lvCompany.SelectedItems[0].Text.ToString().Replace("'","''")  ,'M');
				this.Cursor = Cursors.Default  ;
			}		
			else MessageBox.Show("ACCESS DENIED... ",MainMDI.User ,MessageBoxButtons.OK ,MessageBoxIcon.Stop );

				//frmComapny.lUserName.Text = MainMDI.User    ;
			
		}
		private void edit_cpny(string cpnyName,char c)
		{
            
			    int ndx=-1;
			    if (c=='M') ndx=lvCompany.SelectedItems[0].Index ;
			    Company frmComapny = new Company(cpnyName ,c     );
				frmComapny.ShowDialog()  ; 
				if (frmComapny.lupdate.Text !="N")
				{
					if (frmComapny.lupdate.Text =="U") 
					{
						
						lvCompany.Items[ndx].SubItems[0].Text= frmComapny.tCompanyName1.Text ;
						lvCompany.Items[ndx].SubItems[1].Text=frmComapny.tTel1.Text ; 
						lvCompany.Items[ndx].SubItems[2].Text=frmComapny.tEmail.Text ; 
						lvCompany.Items[ndx].SubItems[3].Text=frmComapny.lMainAdrs.Text ; 
					}
					else
					{
						ListViewItem lv=lvCompany.Items.Add(frmComapny.tCompanyName1.Text) ;
						lv.SubItems.Add(frmComapny.tTel1.Text ); 
						lv.SubItems.Add(frmComapny.tEmail.Text) ; 
						lv.SubItems.Add(frmComapny.lMainAdrs.Text) ; 

					}
				}
					
																						
		}



		private void fix_Cpny_Adrs()
		{
			string MainAdrs="";
			int y=1;
			string 	stSql = "select * FROM PSM_Company order by Cpny_ID";
			SqlConnection OConn  = new SqlConnection(In_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ())
			{
				if (Oreadr["City"].ToString () !="" && Oreadr["Province_State"].ToString () !="" && Oreadr["Country_Name"].ToString () !="")
				{
					MainAdrs = Oreadr["M_Adrs"].ToString ().Replace(","," ")  +  ", " + Oreadr["City"].ToString ().Replace(","," ")+ ", " + Oreadr["Province_State"].ToString ().Replace(","," ")  + ", " + Oreadr["Postal_Code_Zip"].ToString ().Replace(","," ") + ", " + Oreadr["Country_Name"].ToString ().Replace(","," ")    ;
					stSql= "UPDATE PSM_COMPANY SET " +
						
						" [M_Adrs]='" + MainAdrs.Replace("'","''") + "', " +
						" [City]='" + " "  + "', " +
						" [Province_State]='" + " " + "', " +
						" [Postal_Code_Zip]='" + " "  + "',  " +
						" [Country_Name]='" + " "  + "'  " +
						" WHERE [Cpny_ID]=" + Oreadr["Cpny_ID"].ToString () ;
					MainMDI.ExecSql(stSql);
					toolBar1.Buttons[4].Text =y++.ToString();
					toolBar1.Refresh ();
				}
			}
			OConn.Close();

		}
		
		

	

	
		private void lvCompany_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			//MessageBox.Show (   e.Column.ToString() + " SorterCol= " + lvSorter.SortColumn.ToString()   );

			btnseek.Text = "Search by:    " + lvCompany.Columns[e.Column].Text ; 
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
				}
			}
			else
			{
				// Set the column number that is to be sorted; default to ascending.
				//lvSorter.SortColumn = e.Column;  old 
				//lvSorter.Order = SortOrder.Ascending; old

				lvSorter.Order = (srtType=='A') ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
				srtType=(srtType=='A') ? 'D' : 'A';
				lvSorter.SortColumn = e.Column;
			}

			// Perform the sort with these new sort options.
			myListView.Sort();
			oldSC=lvSorter.SortColumn;
			lvSorter.SortColumn =0;


	
	    //	lvCompany.Items.Clear();
		//	lvCompany.Refresh ();
         //	fill_lvCmpny_Fast  (e.Column );
   

		}

		private void lvCompany_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		   
		}

		private void Ges_Company_Load(object sender, System.EventArgs e)
		{
			if (MainMDI.currDB =="XTT") this.Text = "XXXXXXXXXXXXXXXXXXTT"; 
			MainMDI.Write_Whodo_SSetup("Companies",'I');
		
		}

		private void lvCompany_SelectedIndexChanged_1(object sender, System.EventArgs e)
		{
		
		}

		private void Ges_Company_Resize(object sender, System.EventArgs e)
		{
			picExit.Left = this.Width -48;
		}

		private void picExit_Click(object sender, System.EventArgs e)
		{
			this.Hide ();	
		}

		private void btnseek_Click(object sender, System.EventArgs e)
		{
			int ideb=0;
			bool found=false;
			if (tKey.Text !="")
			{
				if (ndxCLRD>-1) 
				{ 
					lvCompany.Items[ndxCLRD].BackColor =Color.WhiteSmoke ; 
					ideb=ndxCLRD+1;
					ndxCLRD=-1;
				}
				for (int i=ideb;i<lvCompany.Items.Count ;i++)
				{
					if (( lvCompany.Items[i].SubItems[seelCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1)) 
					{
						lvCompany.Items[i].BackColor =Color.Yellow    ;
						lvCompany.Items[i].Selected =true;
						lvCompany.Items[i].EnsureVisible(); 
						ndxCLRD=i;
						i=lvCompany.Items.Count+1;
						found=true;
						btnseek.Text = btnseek.Text.Replace("Search","Next ") ; 
					}
				}
			}
			if (!found) { MessageBox.Show("Sorry, Not Found !!!..."); ndxCLRD=-1;}
		}

		private void lvCompany_SelectedIndexChanged_2(object sender, System.EventArgs e)
		{
			if (ndxCLRD>-1) lvCompany.Items[ndxCLRD].BackColor =Color.WhiteSmoke ;
        }

        private void Newcpny_DisplayStyleChanged(object sender, EventArgs e)
        {

        }



        private void toolBar1_exec(int _butt) // _ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
        {

                switch (_butt)
                {
                    case 0:
                        edit_cpny("*", 'N');
                        //frmAddCpny.ShowDialog (); 
                        //fill_lvCmpny_Fast(0);
                        break;
                    case 1:
                        if (lvCompany.SelectedItems.Count == 1)
                            edit_cpny(lvCompany.SelectedItems[0].Text.ToString(), 'M');
                        break;
                    case 2:
                        if (MainMDI.User == "Admin" || MainMDI.User == "hnasrat")
                        {
                            if (MainMDI.Confirm("WANT TO DELETE Customer  '" + lvCompany.SelectedItems[0].Text.ToString() + "'  ??  "))
                            {
                                if (MainMDI.ExecSql("delete PSM_COMPANY where Cpny_ID=" + lvCompany.SelectedItems[0].SubItems[4].Text.ToString()))
                                    lvCompany.Items[lvCompany.SelectedItems[0].Index].Remove();
                            }
                        }
                        break;
                    case 3:
                        this.Hide();
                        break;
                    case 4:
                        fix_Cpny_Adrs();

                        break;
                    case 5:  //find Quote
                        grpSrch.Visible = !grpSrch.Visible;
                        tKey.Focus();
                        break;


                }
           


        }
        private void Newcpny_Click(object sender, EventArgs e)
        {
            toolBar1_exec(0);
        }

        private void seek_cpny_Click(object sender, EventArgs e)
        {
            toolBar1_exec(5);
        }

        private void exiit_Click(object sender, EventArgs e)
        {
            toolBar1_exec(3);
        }
		

	



	

	
	
	}
}
