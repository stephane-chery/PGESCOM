using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb ;
using System.Data.SqlClient ;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for LookQuotes.
	/// </summary>
	public class Options_look : System.Windows.Forms.Form
	{

        private ListViewColumnSorter  lvSorter=null;
		private int oldSC=0;
        private char srtType='A';
		private int ndxCLRD=-1;
		private int seelCol=0;
		public int SelRow=-1;
		public System.Windows.Forms.ListView lvQuotes;
		private System.Windows.Forms.Button btnseek;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox tKey;
		private System.Windows.Forms.GroupBox grpFind;
		private System.Windows.Forms.ColumnHeader FDesc;
		private System.Windows.Forms.ColumnHeader REF;
		private System.Windows.Forms.ColumnHeader PriceLID;
		private System.Windows.Forms.ColumnHeader famID;
		private System.Windows.Forms.ColumnHeader famDesc;
		private System.Windows.Forms.ColumnHeader ManID;
		private System.Windows.Forms.ColumnHeader ManDesc;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.ColumnHeader REFCpt;
		private System.Windows.Forms.Button btnCancel2;
		private System.Windows.Forms.PictureBox btnCancel;
		private System.Windows.Forms.ColumnHeader PXcode;
		private System.ComponentModel.IContainer components;

		public Options_look()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            
			lvSorter = new ListViewColumnSorter(); 
			this.lvQuotes.ListViewItemSorter  = lvSorter ; 
	//		lvQuotes.Sorting =SortOrder.Ascending ;
	//	    lvQuotes.Sorting =SortOrder.Descending ;
			lvQuotes.AutoArrange=true; 
			fill_lvCptList();
			lvSorter.SortColumn =1;
			lvSorter.Order =System.Windows.Forms.SortOrder.Ascending ;
			btnseek.Text = "Search by:    " + lvQuotes.Columns[1].Text ; 
			seelCol=1;
			    
            
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Options_look));
            this.grpFind = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.PictureBox();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel2 = new System.Windows.Forms.Button();
            this.btnseek = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tKey = new System.Windows.Forms.TextBox();
            this.lvQuotes = new System.Windows.Forms.ListView();
            this.REF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PriceLID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.famID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.famDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ManID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ManDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.REFCpt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PXcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpFind.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).BeginInit();
            this.SuspendLayout();
            // 
            // grpFind
            // 
            this.grpFind.Controls.Add(this.btnCancel);
            this.grpFind.Controls.Add(this.btnOK);
            this.grpFind.Controls.Add(this.btnCancel2);
            this.grpFind.Controls.Add(this.btnseek);
            this.grpFind.Controls.Add(this.label4);
            this.grpFind.Controls.Add(this.tKey);
            this.grpFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFind.ForeColor = System.Drawing.Color.Blue;
            this.grpFind.Location = new System.Drawing.Point(0, 0);
            this.grpFind.Name = "grpFind";
            this.grpFind.Size = new System.Drawing.Size(880, 80);
            this.grpFind.TabIndex = 1;
            this.grpFind.TabStop = false;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.Transparent;
            this.btnCancel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
            this.btnCancel.Location = new System.Drawing.Point(832, 8);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(40, 48);
            this.btnCancel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnCancel.TabIndex = 200;
            this.btnCancel.TabStop = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnOK
            // 
            this.btnOK.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnOK.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(752, 16);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(48, 16);
            this.btnOK.TabIndex = 163;
            this.btnOK.Text = "OK";
            this.btnOK.Visible = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel2
            // 
            this.btnCancel2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel2.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel2.Location = new System.Drawing.Point(792, 40);
            this.btnCancel2.Name = "btnCancel2";
            this.btnCancel2.Size = new System.Drawing.Size(40, 24);
            this.btnCancel2.TabIndex = 162;
            this.btnCancel2.Text = "Exit";
            this.btnCancel2.Visible = false;
            // 
            // btnseek
            // 
            this.btnseek.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnseek.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnseek.Location = new System.Drawing.Point(448, 38);
            this.btnseek.Name = "btnseek";
            this.btnseek.Size = new System.Drawing.Size(328, 24);
            this.btnseek.TabIndex = 161;
            this.btnseek.Text = "Search by:";
            this.btnseek.Click += new System.EventHandler(this.btnseek_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(8, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(160, 20);
            this.label4.TabIndex = 160;
            this.label4.Text = "Component Keyword:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.PeachPuff;
            this.tKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.ForeColor = System.Drawing.Color.Black;
            this.tKey.Location = new System.Drawing.Point(8, 40);
            this.tKey.MaxLength = 60;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(440, 20);
            this.tKey.TabIndex = 159;
            // 
            // lvQuotes
            // 
            this.lvQuotes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvQuotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.REF,
            this.FDesc,
            this.PriceLID,
            this.famID,
            this.famDesc,
            this.ManID,
            this.ManDesc,
            this.REFCpt,
            this.PXcode});
            this.lvQuotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvQuotes.ForeColor = System.Drawing.Color.Red;
            this.lvQuotes.FullRowSelect = true;
            this.lvQuotes.GridLines = true;
            this.lvQuotes.Location = new System.Drawing.Point(0, 80);
            this.lvQuotes.MultiSelect = false;
            this.lvQuotes.Name = "lvQuotes";
            this.lvQuotes.Size = new System.Drawing.Size(880, 457);
            this.lvQuotes.TabIndex = 6;
            this.lvQuotes.UseCompatibleStateImageBehavior = false;
            this.lvQuotes.View = System.Windows.Forms.View.Details;
            this.lvQuotes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvQuotes_ColumnClick);
            this.lvQuotes.SelectedIndexChanged += new System.EventHandler(this.lvQuotes_SelectedIndexChanged);
            this.lvQuotes.DoubleClick += new System.EventHandler(this.lvQuotes_DoubleClick);
            // 
            // REF
            // 
            this.REF.Text = "Primax REF";
            this.REF.Width = 74;
            // 
            // FDesc
            // 
            this.FDesc.Text = "Full Description";
            this.FDesc.Width = 642;
            // 
            // PriceLID
            // 
            this.PriceLID.Text = "";
            this.PriceLID.Width = 0;
            // 
            // famID
            // 
            this.famID.Text = "";
            this.famID.Width = 0;
            // 
            // famDesc
            // 
            this.famDesc.Text = "";
            this.famDesc.Width = 0;
            // 
            // ManID
            // 
            this.ManID.Text = "";
            this.ManID.Width = 0;
            // 
            // ManDesc
            // 
            this.ManDesc.Text = "";
            this.ManDesc.Width = 0;
            // 
            // REFCpt
            // 
            this.REFCpt.Text = "";
            this.REFCpt.Width = 0;
            // 
            // PXcode
            // 
            this.PXcode.Text = "Primax Code";
            this.PXcode.Width = 141;
            // 
            // Options_look
            // 
            this.AcceptButton = this.btnseek;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(880, 537);
            this.Controls.Add(this.lvQuotes);
            this.Controls.Add(this.grpFind);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Options_look";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Components Listing";
            this.Activated += new System.EventHandler(this.Quotes_Look_Activated);
            this.Load += new System.EventHandler(this.LookQuotes_Load);
            this.grpFind.ResumeLayout(false);
            this.grpFind.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnCancel)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void LookQuotes_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!"; 
		
		}


		private void lvQuotes_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
            this.Cursor = Cursors.WaitCursor; 

			 //MessageBox.Show (   e.Column.ToString()  );

			btnseek.Text = "Search by:    " + lvQuotes.Columns[e.Column].Text ; 
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
				//lvSorter.SortColumn = e.Column; old
			//	lvSorter.Order = SortOrder.Ascending; old

				lvSorter.Order = (srtType=='A') ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
				srtType=(srtType=='A') ? 'D' : 'A';
				lvSorter.SortColumn = e.Column;
			}

			// Perform the sort with these new sort options.
			myListView.Sort();
			oldSC=lvSorter.SortColumn;
			lvSorter.SortColumn =0;

            this.Cursor = Cursors.Default;

		}
		private bool Confirm(string msg)
		{
			DialogResult dr=MessageBox.Show(msg ,"Confirmation ",MessageBoxButtons.YesNo ,MessageBoxIcon.Question ); 
			return (dr == DialogResult.Yes  );
		}

		
		private void ref_QList(string r_iqid,int ndx)
		{

				string stSql = "SELECT PSM_Q_IGen.*, PSM_Company.Cpny_Name1 FROM PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID " + 
					" where i_Quoteid=" + r_iqid + " ORDER BY PSM_Q_IGen.Quote_ID ";
				SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
				OConn.Open ();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql ;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();
           
			while (Oreadr.Read ())
			{
				if (ndx==-1)
				{
					string dat=Oreadr["Opndate"].ToString().Substring(0,10);
					ListViewItem lvI= lvQuotes.Items.Add( Oreadr["Quote_ID"].ToString () );
					lvI.SubItems.Add(MainMDI.frmt_date(dat));// dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2)   ); 
					lvI.SubItems.Add( Oreadr["Cpny_Name1"].ToString()); 
					if (Oreadr["ProjectName"].ToString()=="") lvI.SubItems.Add(" "); else  lvI.SubItems.Add(Oreadr["ProjectName"].ToString() );
					lvI.SubItems.Add(Oreadr["i_Quoteid"].ToString() ); 
				}
				else 
				{    
					string dat=Oreadr["Opndate"].ToString().Substring(0,10);
					lvQuotes.Items[ndx].SubItems[0].Text  = Oreadr["Quote_ID"].ToString ();
					lvQuotes.Items[ndx].SubItems[1].Text= MainMDI.frmt_date(dat) ;//dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2)  ; 
					lvQuotes.Items[ndx].SubItems[2].Text  =  Oreadr["Cpny_Name1"].ToString(); 
					lvQuotes.Items[ndx].SubItems[3].Text  = Oreadr["ProjectName"].ToString();
					lvQuotes.Items[ndx].SubItems[4].Text  = Oreadr["i_Quoteid"].ToString() ; 
					//lvQuotes.Items[ndx].SubItems[5].Text  =""; 
				}

			}
		

			
		}

		public void fill_lvCptList()
		{ 

	
			lvQuotes.Items.Clear();  

	//		string stSql = " SELECT   TOP 100 PERCENT  dbo.COMPNT_PRICE_LIST.PRICE_LINE_ID, dbo.COMPNT_PRICE_LIST.COMPONENT_ID, dbo.COMPNT_LIST.COMPONENT_REF, dbo.COMPNT_LIST.Component_Name, " +
      //                     " dbo.COMPNT_PRICE_LIST.CAT4_VALUE, dbo.COMPNT_PRICE_LIST.CAT5_VALUE, dbo.COMPNT_PRICE_LIST.CAT6_VALUE, " +
        //                   " dbo.COMPNT_PRICE_LIST.CAT7_value, dbo.COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID, " +
     //                      " dbo.COMPNT_MANUFAC_FAMILY.[Desc] AS FAM_DESC, dbo.COMPNT_MANUFAC.MANUFAC_ID, dbo.COMPNT_MANUFAC.MANUFAC_NAME  " +
     //                      " FROM         dbo.COMPNT_MANUFAC_FAMILY INNER JOIN   dbo.COMPNT_MANUFAC ON dbo.COMPNT_MANUFAC_FAMILY.Manufac_ID = dbo.COMPNT_MANUFAC.MANUFAC_ID INNER JOIN " +
     //                      " dbo.COMPNT_LIST INNER JOIN     dbo.COMPNT_PRICE_LIST ON dbo.COMPNT_LIST.Component_ID = dbo.COMPNT_PRICE_LIST.COMPONENT_ID ON " +
     //                      " dbo.COMPNT_MANUFAC_FAMILY.Compnt_ID = dbo.COMPNT_LIST.Component_ID " +
     //                      " ORDER BY dbo.COMPNT_LIST.COMPONENT_REF, dbo.COMPNT_MANUFAC.MANUFAC_NAME, dbo.COMPNT_MANUFAC_FAMILY.[Desc]" ;
	
			//string stSql = " SELECT   TOP 100 PERCENT  dbo.COMPNT_PRICE_LIST.PRICE_LINE_ID, dbo.COMPNT_PRICE_LIST.COMPONENT_ID, dbo.COMPNT_LIST.COMPONENT_REF, dbo.COMPNT_LIST.Component_Name, " +
			//	" dbo.COMPNT_PRICE_LIST.CAT4_VALUE, dbo.COMPNT_PRICE_LIST.CAT5_VALUE, dbo.COMPNT_PRICE_LIST.CAT6_VALUE, " +
			//	" dbo.COMPNT_PRICE_LIST.CAT7_value, dbo.COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID, " +
			//	" dbo.COMPNT_MANUFAC_FAMILY.[Desc] AS FAM_DESC, dbo.COMPNT_MANUFAC.MANUFAC_ID, dbo.COMPNT_MANUFAC.MANUFAC_NAME  " +
			//	" FROM         dbo.COMPNT_MANUFAC_FAMILY INNER JOIN   dbo.COMPNT_MANUFAC ON dbo.COMPNT_MANUFAC_FAMILY.Manufac_ID = dbo.COMPNT_MANUFAC.MANUFAC_ID INNER JOIN " +
			//	" dbo.COMPNT_LIST INNER JOIN     dbo.COMPNT_PRICE_LIST ON dbo.COMPNT_LIST.Component_ID = dbo.COMPNT_PRICE_LIST.COMPONENT_ID ON " +
			//	" dbo.COMPNT_MANUFAC_FAMILY.Compnt_ID = dbo.COMPNT_LIST.Component_ID  where dbo.COMPNT_PRICE_LIST.CAT4_VALUE <>'n/a'" +
			//	" ORDER BY dbo.COMPNT_LIST.COMPONENT_REF, dbo.COMPNT_MANUFAC.MANUFAC_NAME, dbo.COMPNT_MANUFAC_FAMILY.[Desc]" ;
		
			
			string stSql = " SELECT      COMPNT_PRICE_LIST.PL_Code, COMPNT_PRICE_LIST.PRICE_LINE_ID, COMPNT_LIST.Component_Name, COMPNT_LIST.COMPONENT_REF, COMPNT_PRICE_LIST.CAT4_VALUE, " +
                           "      COMPNT_PRICE_LIST.CAT5_VALUE, COMPNT_PRICE_LIST.CAT6_VALUE, COMPNT_PRICE_LIST.CAT7_value, COMPNT_MANUFAC.MANUFAC_NAME, COMPNT_MANUFAC.MANUFAC_ID ,  COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID,  COMPNT_MANUFAC_FAMILY.[Desc] as FAM_DESC " +
						   " FROM         COMPNT_PRICE_LIST INNER JOIN COMPNT_LIST ON COMPNT_PRICE_LIST.COMPONENT_ID = COMPNT_LIST.Component_ID INNER JOIN " +
                           " COMPNT_MANUFAC ON COMPNT_PRICE_LIST.Manufac_ID = COMPNT_MANUFAC.MANUFAC_ID INNER JOIN  COMPNT_MANUFAC_FAMILY ON COMPNT_PRICE_LIST.compnt_man_Fam_ID = COMPNT_MANUFAC_FAMILY.Compnt_Man_FAM_ID " +
                           " WHERE     (COMPNT_PRICE_LIST.CAT4_VALUE <> N'n/a') ORDER BY COMPNT_PRICE_LIST.PRICE_LINE_ID ";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
           
			while (Oreadr.Read ())
			{
                ListViewItem lvI= lvQuotes.Items.Add( Oreadr["COMPONENT_REF"].ToString () );
				string stFDes = MainMDI.optDesc(0,Oreadr["Component_Name"].ToString()) ;
				stFDes += (Oreadr["CAT4_VALUE"].ToString ()!= MainMDI.VIDE )   ?  " " + Oreadr["CAT4_VALUE"].ToString () : "";
				stFDes += (Oreadr["CAT5_VALUE"].ToString ()!= MainMDI.VIDE )   ?  " " + Oreadr["CAT5_VALUE"].ToString () : "";
				stFDes += (Oreadr["CAT6_VALUE"].ToString ()!= MainMDI.VIDE )   ?  " " + Oreadr["CAT6_VALUE"].ToString () : "";
				stFDes += (Oreadr["CAT7_VALUE"].ToString ()!= MainMDI.VIDE )   ?  " " + Oreadr["CAT7_VALUE"].ToString () : "";
				lvI.SubItems.Add(stFDes);
                lvI.SubItems.Add(Oreadr["PRICE_LINE_ID"].ToString ()) ;
				lvI.SubItems.Add(Oreadr["Compnt_Man_FAM_ID"].ToString ()) ;
				lvI.SubItems.Add(Oreadr["FAM_DESC"].ToString ()) ;
				lvI.SubItems.Add(Oreadr["MANUFAC_ID"].ToString ()) ;
				lvI.SubItems.Add(Oreadr["MANUFAC_NAME"].ToString ()) ;
				lvI.SubItems.Add( MainMDI.optDesc(0,Oreadr["Component_Name"].ToString()) + "         (" + Oreadr["COMPONENT_REF"].ToString() +")");
                string cd = (Oreadr["PL_Code"].ToString().Length > 0) ? Oreadr["PL_Code"].ToString() : "??????????";
                lvI.SubItems.Add(cd) ;	
			}


		}

	

		private void lvQuotes_DoubleClick(object sender, System.EventArgs e)
		{
			SelRow  = (lvQuotes.SelectedItems.Count >0) ? lvQuotes.SelectedItems[0].Index : -1;  
			this.Hide();
		}



		private void edit_Quote(string QNB,string CpnyName)
		{
			if (MainMDI.User =="Admin")
			{
				MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where [user]='Admin'" );
				MainMDI.Use_QRID(-1,'Q',"Admin");  
			}

            string usr=MainMDI.is_QR_Used('Q',lvQuotes.SelectedItems[0].SubItems[4].Text );
			if (usr == MainMDI.VIDE  || MainMDI.User =="Admin" )
			{

                MainMDI.Use_QRID(1,'Q',lvQuotes.SelectedItems[0].SubItems[4].Text);  
				char c=(QNB=="0") ? 'N' : 'E';
				int ndx=lvQuotes.SelectedItems[0].Index ;  
				Quote child4 = new Quote(Convert.ToInt32(QNB),CpnyName,c );
				this.Hide();
				child4.ShowDialog ();
				this.Visible =true;
				if (child4.lSave.Text =="S" ) 
				{

					lvQuotes.Items[ndx].SubItems[0].Text = child4.tQuoteID.Text ;
					string dat=child4.tOpendate.Text;
					lvQuotes.Items[ndx].SubItems[1].Text =MainMDI.frmt_date(dat);// dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2);
					lvQuotes.Items[ndx].SubItems[2].Text =child4.lCpnyName.Text ;
					lvQuotes.Items[ndx].SubItems[3].Text =child4.tProjNAME.Text;
 
				}
				MainMDI.Use_QRID(0,'Q',lvQuotes.SelectedItems[0].SubItems[4].Text);  
				child4.Dispose(); 
			}
			else MessageBox.Show("Sorry, This Quote is opened by: " + usr); 

/*
			if (QNB !="0" )
			{

			   Quote child4 = new Quote(Convert.ToInt32(QNB),CpnyName,'E'  );
			   child4.ShowDialog ();
			   child4.Dispose(); 
			//	MainMDI.frm_Qte.x_QID = Convert.ToInt32(QNB);  
			//	MainMDI.frm_Qte.x_CpnyName  =CpnyName;
			//	MainMDI.frm_Qte.x_opera  ='E';
			//	MainMDI.frm_Qte.ShowDialog ();

				//fill_lvQuotes(); 
			}
			else
			{ 
				Quote child4 = new Quote(0,"*",'N' );
				child4.ShowDialog ();
				child4.Dispose(); 
			//	MainMDI.frm_Qte = new Quote(0,"*",'E');
			//	MainMDI.frm_Qte.ShowDialog ();
			}
			 child4.Dispose(); 
			 */
		}

		private void Quotes_Look_Activated(object sender, System.EventArgs e)
		{
		// fill_lvQuotes(); 
		}

		private void grpRech_Enter(object sender, System.EventArgs e)
		{
		
		}


		private void btnDup_Click(object sender, System.EventArgs e)
		{
			
		}

	

		private void lCpnyID_Click(object sender, System.EventArgs e)
		{
		
		}

		private void btnseek_ClickOLD(object sender, System.EventArgs e)
		{
			
			bool found=false;
			
			if (tKey.Text !="")
			{
				if (ndxCLRD>-1) 
				{ 
					lvQuotes.Items[ndxCLRD].BackColor =Color.WhiteSmoke ; 
					ndxCLRD=-1;
				}
				ndxCLRD=-1;
				for (int i=0;i<lvQuotes.Items.Count ;i++)
				{
					if (( lvQuotes.Items[i].SubItems[seelCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1)) 
					{
						lvQuotes.Items[i].BackColor =Color.Yellow  ;
						lvQuotes.Items[i].Selected =true;
						lvQuotes.Items[i].EnsureVisible(); 
						ndxCLRD=i;
						i=lvQuotes.Items.Count+1;
						found=true;
					}
				}
			}
			if (!found) { MessageBox.Show("Sorry, Not Found !!!..."); ndxCLRD=-1;}
		}
      
		
		private void btnseek_Click(object sender, System.EventArgs e)
		{
			int ideb=0;
			bool found=false;
			if (tKey.Text !="")
			{
				if (ndxCLRD>-1) 
				{ 
					lvQuotes.Items[ndxCLRD].BackColor =Color.WhiteSmoke ; 
					ideb=ndxCLRD+1;
					ndxCLRD=-1;
				}
				for (int i=ideb;i<lvQuotes.Items.Count ;i++)
				{
					if (( lvQuotes.Items[i].SubItems[seelCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1)) 
					{
						lvQuotes.Items[i].BackColor =Color.Yellow    ;
						lvQuotes.Items[i].Selected =true;
						lvQuotes.Items[i].EnsureVisible(); 
						ndxCLRD=i;
						i=lvQuotes.Items.Count+1;
						found=true;
						btnseek.Text = btnseek.Text.Replace("Search","Next ") ; 
					}
				}
			}
			if (!found) { MessageBox.Show("Sorry, Not Found !!!..."); ndxCLRD=-1;}
	

		
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			SelRow  = (lvQuotes.SelectedItems.Count >1) ? lvQuotes.SelectedItems[0].Index : -1;  
			this.Hide();
		
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			SelRow  =-1;  
			this.Hide();
		}

		private void lvQuotes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}




		/*
		private bool cpy_Quote(string OIQID,string CpnyID)
		{
     
			string stSql="SELECT * from  PSM_Q_IGen WHERE i_Quoteid=" + OIQID ;
			
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
	
			while (Oreadr.Read ())
			{
					string stSql= "INSERT INTO PSM_Q_IGen ([Quote_ID],[CPNY_ID],[Employ_ID], " + 
						" [ProjectName],[Opndate],[Clsdate],[Contact_ID],[Cust_Mult],  " + 
						" [Term_ID],[Via_ID],[IncoTerm_ID], " + 
						" [SI],[SO],[SE],[SP],[SS], " + 
						" [AD],[AI],[AE],[AP],[AS], " + 
						" [QA],[SA],[PA],[IA] , " + 
						" [Lang]," +
						" [DEL]," +" [IPmgr]," +" [CPmgr]," + " [curr]," +
						" [Cmnt]) VALUES ('" +
						Oreadr["Quote_ID"].ToString() + "', '" +
						lCpnyID.Text    + "', '" +
						Oreadr["Quote_ID"].ToString() + "', '" +
						Oreadr["Quote_ID"].ToString().Replace("'","''")   + "', '" +
						tOpendate.Text + "', '" +
						"11/11/11" + "', '" +
						lContact_ID.Text + "', '" +
						Oreadr["Quote_ID"].ToString()+ "', '" +
						lTerm_ID.Text + "', '" +
						lVia_ID.Text + "', '" +
						lIncoT_ID.Text + "', '" +
						lSi.Text  + "', '" +
						lSO.Text  + "', '" +
						lSE.Text  + "', '" +
						lSP.Text  + "', '" +
						cbSS.Text + "', '" +
						lAD.Text  + "', '" +
						lAI.Text  + "', '" +
						lAE.Text  + "', '" +
						lAP.Text  + "', '" +
						cbAS.Text + "', '" +
						lQA.Text  + "', '" +
						lSA.Text  + "', '" +
						lPA.Text  + "', '" +
						lIA.Text + "', '" +
						lLang.Text  + "', '" +
						lQstatus.Text    + "', '" + lIpmgr.Text   + "', '" + lCpmgr.Text   + "', '" + lcurDol.Text.Substring(0,1) + "', '" +
						tGCmnt.Text   + "')";
					t1 =  ExecSql(stSql);
					lCurr_opera.Text  = "E";
					string stId=MainMDI.Find_One_Field("select I_Quoteid from PSM_Q_IGen where Quote_ID=" + tQuoteID.Text + " AND CPNY_ID=" + lcpnyID.Text) ;   
					//	MessageBox.Show("ID= " + MainMDI.stXP + "     foundID= " + stId  );  
					if (stId!=MainMDI.VIDE ) lCurrIQID.Text = stId ; 
					else MessageBox.Show("Error Occurs while Saving this Quote...contact your Admin !!!" + MainMDI.stXP  ); 
				}


*/






		}
		

}
