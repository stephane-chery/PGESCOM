using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb ;
using System.Data.SqlClient ;
using EAHLibs;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for Alarms.
	/// </summary>
	public class Order_ItemsBrkDown : System.Windows.Forms.Form
	{

		private Lib1 Tools = new Lib1();
		public bool ToBRKDWN=false;
		
		private Chargerdlg in_frm_FDR;
		private System.Windows.Forms.Button btnSave;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton EXIT;
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.ListView lv_Ritems;
		private System.Windows.Forms.ColumnHeader Brkd;
		private System.Windows.Forms.ColumnHeader Desc;
		private System.Windows.Forms.ColumnHeader det_Qty;
		private System.Windows.Forms.ColumnHeader Als_Qty;
		private System.Windows.Forms.ColumnHeader mnt;
		private System.Windows.Forms.ColumnHeader linedID;
		private System.Windows.Forms.ToolBarButton Ntitle;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ColumnHeader SYS;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btnSaveSN;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnskip;
		private System.Windows.Forms.Button btnSv;
		public System.Windows.Forms.Label lSP;
        private Button button1;
		char in_opra='?';

		public Order_ItemsBrkDown(char x_opra)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		//	in_frm_FDR=x_Frm_Cdlg;
			in_opra=x_opra;
			switch (in_opra)
			{
				case 'B':
					fill_Items ();
					btnSave.Visible =true; 
					btnskip.Visible =true; 
					break;
				case 'S':
					btnCancel.Visible =true; 
					btnSaveSN.Visible =true; 
					break;
			}


            btnSv.Visible = MainMDI.User.ToLower() == "ede";  



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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order_ItemsBrkDown));
            this.btnskip = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSv = new System.Windows.Forms.Button();
            this.lSP = new System.Windows.Forms.Label();
            this.btnSaveSN = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.Ntitle = new System.Windows.Forms.ToolBarButton();
            this.EXIT = new System.Windows.Forms.ToolBarButton();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lv_Ritems = new System.Windows.Forms.ListView();
            this.Brkd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SYS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Als_Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.det_Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.linedID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnskip
            // 
            this.btnskip.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnskip.Location = new System.Drawing.Point(808, 16);
            this.btnskip.Name = "btnskip";
            this.btnskip.Size = new System.Drawing.Size(96, 24);
            this.btnskip.TabIndex = 147;
            this.btnskip.Text = "Skip";
            this.btnskip.Visible = false;
            this.btnskip.Click += new System.EventHandler(this.btnskip_Click);
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(704, 16);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(96, 24);
            this.btnSave.TabIndex = 146;
            this.btnSave.Text = "OK";
            this.btnSave.Visible = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnSv);
            this.groupBox2.Controls.Add(this.lSP);
            this.groupBox2.Controls.Add(this.btnSaveSN);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnskip);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 694);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(910, 48);
            this.groupBox2.TabIndex = 149;
            this.groupBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(468, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 24);
            this.button1.TabIndex = 152;
            this.button1.Text = "Print Selected SN";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSv
            // 
            this.btnSv.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSv.Location = new System.Drawing.Point(120, 16);
            this.btnSv.Name = "btnSv";
            this.btnSv.Size = new System.Drawing.Size(128, 24);
            this.btnSv.TabIndex = 151;
            this.btnSv.Text = "Save Serials";
            this.btnSv.Click += new System.EventHandler(this.btnSv_Click);
            // 
            // lSP
            // 
            this.lSP.BackColor = System.Drawing.Color.DarkCyan;
            this.lSP.Location = new System.Drawing.Point(80, 16);
            this.lSP.Name = "lSP";
            this.lSP.Size = new System.Drawing.Size(24, 16);
            this.lSP.TabIndex = 150;
            this.lSP.Text = "C";
            this.lSP.Visible = false;
            // 
            // btnSaveSN
            // 
            this.btnSaveSN.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSaveSN.Location = new System.Drawing.Point(334, 16);
            this.btnSaveSN.Name = "btnSaveSN";
            this.btnSaveSN.Size = new System.Drawing.Size(128, 24);
            this.btnSaveSN.TabIndex = 148;
            this.btnSaveSN.Text = "Save + Print Serials";
            this.btnSaveSN.Visible = false;
            this.btnSaveSN.Click += new System.EventHandler(this.btnSaveSN_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(576, 16);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(96, 24);
            this.btnCancel.TabIndex = 149;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Visible = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.AutoSize = false;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.Ntitle,
            this.EXIT});
            this.toolBar1.ButtonSize = new System.Drawing.Size(50, 36);
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.imageList1;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(910, 56);
            this.toolBar1.TabIndex = 151;
            this.toolBar1.Visible = false;
            this.toolBar1.Wrappable = false;
            // 
            // Ntitle
            // 
            this.Ntitle.ImageIndex = 0;
            this.Ntitle.Name = "Ntitle";
            this.Ntitle.Text = "new line";
            this.Ntitle.ToolTipText = "new line";
            // 
            // EXIT
            // 
            this.EXIT.ImageIndex = 7;
            this.EXIT.Name = "EXIT";
            this.EXIT.Text = "Exit";
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lv_Ritems);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 56);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(910, 638);
            this.groupBox1.TabIndex = 152;
            this.groupBox1.TabStop = false;
            // 
            // lv_Ritems
            // 
            this.lv_Ritems.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lv_Ritems.CheckBoxes = true;
            this.lv_Ritems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Brkd,
            this.SYS,
            this.Als_Qty,
            this.Desc,
            this.det_Qty,
            this.mnt,
            this.linedID});
            this.lv_Ritems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_Ritems.ForeColor = System.Drawing.Color.Blue;
            this.lv_Ritems.FullRowSelect = true;
            this.lv_Ritems.GridLines = true;
            this.lv_Ritems.HideSelection = false;
            this.lv_Ritems.Location = new System.Drawing.Point(3, 16);
            this.lv_Ritems.Name = "lv_Ritems";
            this.lv_Ritems.Size = new System.Drawing.Size(904, 619);
            this.lv_Ritems.TabIndex = 137;
            this.lv_Ritems.UseCompatibleStateImageBehavior = false;
            this.lv_Ritems.View = System.Windows.Forms.View.Details;
            // 
            // Brkd
            // 
            this.Brkd.Text = "Breakdown";
            this.Brkd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Brkd.Width = 68;
            // 
            // SYS
            // 
            this.SYS.Text = "System Name";
            this.SYS.Width = 193;
            // 
            // Als_Qty
            // 
            this.Als_Qty.Text = "System Qty";
            this.Als_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Als_Qty.Width = 72;
            // 
            // Desc
            // 
            this.Desc.Text = "Item Description";
            this.Desc.Width = 385;
            // 
            // det_Qty
            // 
            this.det_Qty.Text = "Item Qty";
            this.det_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.det_Qty.Width = 59;
            // 
            // mnt
            // 
            this.mnt.Text = "Extension";
            this.mnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mnt.Width = 108;
            // 
            // linedID
            // 
            this.linedID.Text = "";
            this.linedID.Width = 0;
            // 
            // Order_ItemsBrkDown
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(910, 742);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolBar1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Order_ItemsBrkDown";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Items Breakdown";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Alarms_Load);
            this.Resize += new System.EventHandler(this.Order_ItemsBrkDown_Resize);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			Options frmOpt = new Options('A',"ALRM");
			frmOpt.ShowDialog();
			if (frmOpt.lConsopt.Text =="Y")
			{
              if (MainMDI.Lang ==1 && frmOpt.optFR.Checked ) 
				   add_LVO(frmOpt.lExt.Text,frmOpt.tCat1.Text,frmOpt.tCat2.Text,frmOpt.tCat3.Text,frmOpt.tCat4fr.Text,frmOpt.tCat5fr.Text,frmOpt.tCat6fr.Text,frmOpt.tCat7fr.Text); 
			else   add_LVO(frmOpt.lExt.Text,frmOpt.tCat1.Text,frmOpt.tCat2.Text,frmOpt.tCat3.Text,frmOpt.tCat4.Text,frmOpt.tCat5.Text,frmOpt.tCat6.Text,frmOpt.tCat7.Text); 
			  //else  
				//3,".",frmOpt.tERef.Text + "  "   + frmOpt.lFullDesc.Text,frmOpt.tOptqty.Text,tCust_Mult.Text,frmOpt.tUPrice.Text , Convert.ToString(Math.Round(Tools.Conv_Dbl(frmOpt.tUPrice.Text) * Tools.Conv_Dbl(tCust_Mult.Text) ,Charger.NB_DEC_AFF)),frmOpt.tDlvDelay.Text);
			
			}

		}

		private void Alarms_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!"; 
		}


		private void fill_Items()
		{ 
			
		string stSql = " SELECT  PSM_Q_Details.*, PSM_Q_ALS.AGPrice AS Tagprice, PSM_Q_ALS.AlsQty AS AlsQT, PSM_Q_Details.Qty AS itemQt, " + MainMDI.t_Det_OL +  ".lineID , " + MainMDI.t_Det_OL +  ".AA_orig " +
                       " FROM         " + MainMDI.t_Det_OL +  " INNER JOIN  PSM_Q_Details ON " + MainMDI.t_Det_OL +  ".detailLID = PSM_Q_Details.Detail_LID INNER JOIN " +
                       " PSM_Q_ALS ON PSM_Q_Details.ALS_LID = PSM_Q_ALS.ALS_LID INNER JOIN PSM_Q_SPCS ON PSM_Q_ALS.SPC_LID = PSM_Q_SPCS.SPC_LID INNER JOIN " +
                       " PSM_Q_SOL ON PSM_Q_SPCS.Sol_LID = PSM_Q_SOL.Sol_LID INNER JOIN PSM_Q_IGen ON PSM_Q_SOL.I_Quoteid = PSM_Q_IGen.i_Quoteid " +
                       " WHERE     (isnumeric(" + MainMDI.t_Det_OL +  ".detailLID) = 1) " +
			           " ORDER BY " + MainMDI.t_Det_OL +  ".lineID, PSM_Q_Details.Detail_LID "; 
		//	ORDER BY PSM_Q_Details.Detail_LID ";
		
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon    );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			lv_Ritems.Items.Clear();  
			string newSYS="",oldSYS="";
			ListViewItem lvI=null;
			while (Oreadr.Read ())
			{
				newSYS=Oreadr["AA_orig"].ToString ();
				if (newSYS != oldSYS) 
				{
					lvI= lv_Ritems.Items.Add("");
					lvI.SubItems.Add(newSYS );
					lvI.SubItems.Add(Oreadr["AlsQT"].ToString ());
					for (int r=3;r<lv_Ritems.Columns.Count ;r++) lvI.SubItems.Add(" " );
					oldSYS=newSYS;
					lvI.BackColor = Color.Sienna  ; 
					lvI.ForeColor  = Color.White  ; 
				}
				lvI= lv_Ritems.Items.Add("");
				lvI.SubItems.Add(" " );
				lvI.SubItems.Add(" " );
				lvI.SubItems.Add(Oreadr["Desc"].ToString ());
				lvI.SubItems.Add(Oreadr["itemQt"].ToString ());
				lvI.SubItems.Add(Oreadr["Ext"].ToString ());
		//		double qq= Tools.Conv_Dbl (Oreadr["AlsQT"].ToString ()) * Tools.Conv_Dbl (Oreadr["itemQt"].ToString ()); 
		//		lvI.SubItems.Add(qq.ToString() );
		//	    qq = Math.Round(qq * Tools.Conv_Dbl (Oreadr["Ext"].ToString ()),MainMDI.NB_DEC_AFF )  ; 
		//		lvI.SubItems.Add(qq.ToString ());

				lvI.SubItems.Add(Oreadr["lineID"].ToString ());
			//	if ( (Tools.Conv_Dbl( Oreadr["AlsQT"].ToString ()) * Tools.Conv_Dbl( Oreadr["itemQt"].ToString ())) >1) lvI.BackColor = Color.Coral  ; 
				if ( Tools.Conv_Dbl( Oreadr["itemQt"].ToString ()) >1) 	
				{
					lvI.BackColor = Color.Moccasin   ; 
					ToBRKDWN=true;
				}


			}
			OConn.Close (); 
		
		}

		private void add_LVO(string price,string c1,string c2,string c3,string c4,string c5,string c6,string c7)
		{

/*			ListViewItem lvI= lvAlrmPL.Items.Add("");
			lvI.SubItems.Add(""); // desc will be filled at end of function
			lvI.SubItems.Add(price); 
			lvI.SubItems.Add(c1);
			lvI.SubItems.Add(c2); 
			lvI.SubItems.Add(c3); 
			lvI.SubItems.Add(c4);
			lvI.SubItems.Add(c5);
			lvI.SubItems.Add(c6); 
			lvI.SubItems.Add(c7); 
			
			string stfullD=c4;
			if (c5!= MainMDI.VIDE && c5!= "0")  stfullD +=  ", " + c5;
			if (c6!= MainMDI.VIDE && c6!= "0")  stfullD +=  ", " + c6;
		//	if (c7!= MainMDI.VIDE &&  c7!= "0")  stfullD +=  ", " + c7;  since cat7 is Reserved for EQ andAlarm's Tech. Values
			if (c1!=MainMDI.VIDE &&  c1!= "0")  stfullD += "-" + Deco_Alrm_Frml(c1) +"V";
			if (c2!=MainMDI.VIDE &&  c2!= "0")  stfullD +=  "-" + Deco_Alrm_Frml(c2)+"A";
			if (c3!=MainMDI.VIDE &&  c3!= "0")  stfullD +=  "-" + Deco_DLL(c3);
			lvAlrmPL.Items[lvAlrmPL.Items.Count-1].SubItems[1].Text = stfullD ;
	//		lvAlrmPL.Items[lvAlrmPL.Items.Count-1].SubItems[3].Text = stfullD ;
			lvAlrmPL.Items[lvAlrmPL.Items.Count-1].Checked =(price=="0");
*/	
	}

		private string Deco_Alrm_Frml(string st)
		{
			string res="0",opRnd="";
			double oprT1=0, oprT2=0;
            
			switch (st[0])
			{

				case '$':
					res= st.Substring(1,st.Length -1); 
					break;
				case '!':
					int ipos=st.IndexOf(" " ,0);
					if (ipos==-1) 
					{ 
						if (st.Length >1 ) res= deco_Var(st.Substring(1,st.Length -1)).ToString ();
						else res= "";
					}
					else 
					{ 
						oprT1 = deco_Var(st.Substring(1,ipos-1));
						opRnd = st.Substring(ipos+1,1);
						oprT2 = Tools.Conv_Dbl(st.Substring(ipos+3,st.Length - ipos - 3 ));
						res=calul_Amnt(oprT1  ,opRnd ,oprT2  ).ToString (); 
					}
					break;
			}
			if (res =="0") MessageBox.Show ("This alarm Desc is invalid =" + st);
			return res;
						   
			
		}
	
		private double deco_Var(string st)
		{
				
				double res= 0;
				switch ( st)
				{
					case "VFLOAT":
						res= Tools.Conv_Dbl(in_frm_FDR.tVFLOAT.Text) ; 
						break;
					case "VEQUAL":
						res=Tools.Conv_Dbl(in_frm_FDR.tVEQL.Text) ; 
						break;
					case "VAC":
						res=Tools.Conv_Dbl(in_frm_FDR.tVac.Text) ; 
						break;
					case "IDC":
						res=Tools.Conv_Dbl(in_frm_FDR.cbIdc.Text) ; 
						break;
					case "VDCNOM":
						res=Tools.Conv_Dbl(in_frm_FDR.cbVdc.Text) ; 
						break;
					case "PHS":
						res=Tools.Conv_Dbl(in_frm_FDR.cbPhs.Text) ; 
						break;
				} 
				return res ;
			}

			
			private string calul_Amnt(double mnt1, string oper, double mnt2)
			{
				
				string calul_Amnt_Res = "0";
			//	double mnt1=0,mnt2=0;
			//	if (mnt1=="" ||   amnt2=="") return "0";
				switch ( oper)
				{
					case "*":
						calul_Amnt_Res = Convert.ToString(Math.Round(mnt1 * mnt2,Charger.NB_DEC_CAL ));
						break;
					case "-":
						calul_Amnt_Res  = Convert.ToString(Math.Round(mnt1 - mnt2,Charger.NB_DEC_CAL ));
						break;
					case "/":
						if (mnt2 > 0) calul_Amnt_Res  = Convert.ToString(Math.Round(mnt1 / mnt2, Charger.NB_DEC_CAL ));
						else calul_Amnt_Res  = "0";
						break;
					case "+":
						calul_Amnt_Res  = Convert.ToString(  Math.Round(mnt1 + mnt2, Charger.NB_DEC_CAL )  );
						break;
				} 
				return calul_Amnt_Res;
			}

		private string Deco_DLL(string st)
		{
          return Tools.Conv_Dbl(st.Substring(0,2)) + "sec-" + ((st.Substring(3,1)=="Y") ? "Latch-" : "No Latch-") +
			             ((st.Substring(5,1)=="P") ? "Fail Safe" : "No Fail Safe " );
		}

		private void lvAlrmPL_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

	
	
	
		private void tdelay_TextChanged(object sender, System.EventArgs e)
		{
		
		}

		private void btnSave_Click(object sender, System.EventArgs e)
		{
			Save_tmp_Config();
		}
		private void Save_tmp_Config()
		{
					int res=0;
			string r_Qtysys="";
			for (int b=0;b<lv_Ritems.Items.Count ;b++)
			{
				if (lv_Ritems.Items[b].SubItems[6].Text==" " ) r_Qtysys = lv_Ritems.Items[b].SubItems[2].Text;
				else 
				{
					if ( lv_Ritems.Items[b].Checked &&  lv_Ritems.Items[b].BackColor == Color.Moccasin  ) res=((lv_Ritems.Items[b].Checked) ? 1:0);
					else res=0;
					MainMDI.ExecSql("UPDATE "+ MainMDI.t_Det_OL + " SET Det_Qty ='" + lv_Ritems.Items[b].SubItems[4].Text + "', Als_Qty='" +  r_Qtysys  + "', brkdwn=" + res    + " WHERE  lineID=" + lv_Ritems.Items[b].SubItems[6].Text );  
				}
			}
			this.Close();
		}

		private void tUP_TextChanged(object sender, System.EventArgs e)
		{
           cal_tEXT();		
		}
		private void cal_tEXT()
		{
		//	tExt.Text = Convert.ToString(  Math.Round(Tools.Conv_Dbl(tQty.Text ) *  Tools.Conv_Dbl(tUP.Text ),MainMDI.NB_DEC_AFF));  
		}

		private void tQty_TextChanged(object sender, System.EventArgs e)
		{
			cal_tEXT();	
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void groupBox1_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void Order_ItemsBrkDown_Resize(object sender, System.EventArgs e)
		{
			lv_Ritems.Columns[3].Width = this.Width -   537 ; //377;
		}

		private void btnskip_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnSaveSN_Click(object sender, System.EventArgs e)
		{
			lSP.Text="SP";
			this.Hide ();
		}

		private void btnSv_Click(object sender, System.EventArgs e)
		{
			lSP.Text="S";
			this.Hide ();

		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			lSP.Text="C";
			this.Hide ();
		}

        private void button1_Click(object sender, EventArgs e)
        {
            if (lv_Ritems.SelectedItems.Count > 0)
            {

                lSP.Text = "P";
                this.Hide();
            }
            else MessageBox.Show("NO Items Selected....!!!!!"); 
        }


	

	}
}
