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
	public class Order_ItemsBrkDown_NEW : System.Windows.Forms.Form
	{

		private Lib1 Tools = new Lib1();
		public bool ToBRKDWN=false;
		
		private Chargerdlg in_frm_FDR;
		private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ImageList imageList1;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Button btnSaveSN;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnskip;
		private System.Windows.Forms.Button btnSv;
		public System.Windows.Forms.Label lSP;
        private Button button1;
        private ToolStrip toolStrip1;
        private ToolStripButton tls_setSN;
        private ToolStripButton tlsSave;
        private ToolStripButton tlsPrint;
        private ToolStripButton _exit;
        private ToolStripSeparator hhh;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel PBWait;
        private ToolStripProgressBar TSpbar;
        private GroupBox groupBox1;
        public ListView lv_Ritems;
        private ColumnHeader Brkd;
        private ColumnHeader SYS;
        private ColumnHeader Als_Qty;
        private ColumnHeader Desc;
        private ColumnHeader det_Qty;
        private ColumnHeader mnt;
        private ColumnHeader linedID;
        private ToolStripButton tlsSnP;
        private ToolStripButton tlsSall;
        private ToolStripButton tlsUall;
		char in_opra='?';

        public Order_ItemsBrkDown_NEW(char x_opra)
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
			//		fill_Items ();
					btnSave.Visible =true; 
					btnskip.Visible =true; 
					break;
				case 'S':
					btnCancel.Visible =true; 
					btnSaveSN.Visible =true; 
					break;
			}


            btnSv.Visible = MainMDI.User.ToLower() == "ede";
            lSP.Text = "C";


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order_ItemsBrkDown_NEW));
            this.btnskip = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSv = new System.Windows.Forms.Button();
            this.lSP = new System.Windows.Forms.Label();
            this.btnSaveSN = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tlsSall = new System.Windows.Forms.ToolStripButton();
            this.tlsUall = new System.Windows.Forms.ToolStripButton();
            this.tls_setSN = new System.Windows.Forms.ToolStripButton();
            this.tlsSnP = new System.Windows.Forms.ToolStripButton();
            this.tlsSave = new System.Windows.Forms.ToolStripButton();
            this.tlsPrint = new System.Windows.Forms.ToolStripButton();
            this._exit = new System.Windows.Forms.ToolStripButton();
            this.hhh = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PBWait = new System.Windows.Forms.ToolStripLabel();
            this.TSpbar = new System.Windows.Forms.ToolStripProgressBar();
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
            this.toolStrip1.SuspendLayout();
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
            this.groupBox2.Size = new System.Drawing.Size(1408, 48);
            this.groupBox2.TabIndex = 149;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(468, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(102, 24);
            this.button1.TabIndex = 152;
            this.button1.Text = "Print Selected SN";
            this.button1.Visible = false;
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
            this.btnSv.Visible = false;
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
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // toolStrip1
            // 
            this.toolStrip1.BackColor = System.Drawing.Color.LemonChiffon;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tlsSall,
            this.tlsUall,
            this.tls_setSN,
            this.tlsSnP,
            this.tlsSave,
            this.tlsPrint,
            this._exit,
            this.hhh,
            this.toolStripSeparator1,
            this.PBWait,
            this.TSpbar});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1408, 70);
            this.toolStrip1.TabIndex = 257;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tlsSall
            // 
            this.tlsSall.Image = ((System.Drawing.Image)(resources.GetObject("tlsSall.Image")));
            this.tlsSall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSall.Name = "tlsSall";
            this.tlsSall.Size = new System.Drawing.Size(93, 67);
            this.tlsSall.Text = "Check All items";
            this.tlsSall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsSall.Click += new System.EventHandler(this.tlsSall_Click);
            // 
            // tlsUall
            // 
            this.tlsUall.Image = ((System.Drawing.Image)(resources.GetObject("tlsUall.Image")));
            this.tlsUall.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsUall.Name = "tlsUall";
            this.tlsUall.Size = new System.Drawing.Size(106, 67);
            this.tlsUall.Text = "Uncheck All items";
            this.tlsUall.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsUall.Click += new System.EventHandler(this.tlsUall_Click);
            // 
            // tls_setSN
            // 
            this.tls_setSN.Image = ((System.Drawing.Image)(resources.GetObject("tls_setSN.Image")));
            this.tls_setSN.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_setSN.Name = "tls_setSN";
            this.tls_setSN.Size = new System.Drawing.Size(121, 67);
            this.tls_setSN.Text = "Serial  checked items";
            this.tls_setSN.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_setSN.ToolTipText = "set Serials to selected Systems";
            this.tls_setSN.Click += new System.EventHandler(this.tls_setSN_Click);
            // 
            // tlsSnP
            // 
            this.tlsSnP.Image = ((System.Drawing.Image)(resources.GetObject("tlsSnP.Image")));
            this.tlsSnP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSnP.Name = "tlsSnP";
            this.tlsSnP.Size = new System.Drawing.Size(116, 67);
            this.tlsSnP.Text = "Save && Print serial #";
            this.tlsSnP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsSnP.Click += new System.EventHandler(this.tlsSnP_Click);
            // 
            // tlsSave
            // 
            this.tlsSave.Image = ((System.Drawing.Image)(resources.GetObject("tlsSave.Image")));
            this.tlsSave.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsSave.Name = "tlsSave";
            this.tlsSave.Size = new System.Drawing.Size(81, 67);
            this.tlsSave.Text = "Save Serials #";
            this.tlsSave.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsSave.ToolTipText = "Save Serials";
            this.tlsSave.Visible = false;
            this.tlsSave.Click += new System.EventHandler(this.tlsSave_Click);
            // 
            // tlsPrint
            // 
            this.tlsPrint.BackColor = System.Drawing.Color.Transparent;
            this.tlsPrint.Image = ((System.Drawing.Image)(resources.GetObject("tlsPrint.Image")));
            this.tlsPrint.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tlsPrint.Name = "tlsPrint";
            this.tlsPrint.Size = new System.Drawing.Size(124, 67);
            this.tlsPrint.Text = "Print Selected Serial #";
            this.tlsPrint.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tlsPrint.ToolTipText = "Print Selected SN";
            this.tlsPrint.Visible = false;
            this.tlsPrint.Click += new System.EventHandler(this.tlsPrint_Click);
            // 
            // _exit
            // 
            this._exit.Image = ((System.Drawing.Image)(resources.GetObject("_exit.Image")));
            this._exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(52, 67);
            this._exit.Text = "   Exit   ";
            this._exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._exit.Click += new System.EventHandler(this._exit_Click);
            // 
            // hhh
            // 
            this.hhh.Name = "hhh";
            this.hhh.Size = new System.Drawing.Size(6, 70);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 70);
            // 
            // PBWait
            // 
            this.PBWait.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PBWait.ForeColor = System.Drawing.Color.Red;
            this.PBWait.Name = "PBWait";
            this.PBWait.Size = new System.Drawing.Size(209, 67);
            this.PBWait.Text = "Loading in Progress........";
            this.PBWait.Visible = false;
            // 
            // TSpbar
            // 
            this.TSpbar.AutoSize = false;
            this.TSpbar.Name = "TSpbar";
            this.TSpbar.Size = new System.Drawing.Size(167, 17);
            this.TSpbar.Step = 5;
            this.TSpbar.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lv_Ritems);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 70);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1408, 624);
            this.groupBox1.TabIndex = 258;
            this.groupBox1.TabStop = false;
            // 
            // lv_Ritems
            // 
            this.lv_Ritems.BackColor = System.Drawing.Color.AntiqueWhite;
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
            this.lv_Ritems.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_Ritems.ForeColor = System.Drawing.Color.Blue;
            this.lv_Ritems.FullRowSelect = true;
            this.lv_Ritems.GridLines = true;
            this.lv_Ritems.HideSelection = false;
            this.lv_Ritems.Location = new System.Drawing.Point(3, 16);
            this.lv_Ritems.Name = "lv_Ritems";
            this.lv_Ritems.Size = new System.Drawing.Size(1402, 605);
            this.lv_Ritems.TabIndex = 137;
            this.lv_Ritems.UseCompatibleStateImageBehavior = false;
            this.lv_Ritems.View = System.Windows.Forms.View.Details;
            // 
            // Brkd
            // 
            this.Brkd.Text = "Set Serial#";
            this.Brkd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Brkd.Width = 214;
            // 
            // SYS
            // 
            this.SYS.Text = "System Name";
            this.SYS.Width = 0;
            // 
            // Als_Qty
            // 
            this.Als_Qty.Text = "System Qty";
            this.Als_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Als_Qty.Width = 0;
            // 
            // Desc
            // 
            this.Desc.Text = "Item Description";
            this.Desc.Width = 533;
            // 
            // det_Qty
            // 
            this.det_Qty.Text = "Item Qty";
            this.det_Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.det_Qty.Width = 110;
            // 
            // mnt
            // 
            this.mnt.Text = "Extension";
            this.mnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.mnt.Width = 0;
            // 
            // linedID
            // 
            this.linedID.Text = "";
            this.linedID.Width = 0;
            // 
            // Order_ItemsBrkDown_NEW
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1408, 742);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Order_ItemsBrkDown_NEW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Items Breakdown";
            this.Load += new System.EventHandler(this.Alarms_Load);
            this.Resize += new System.EventHandler(this.Order_ItemsBrkDown_Resize);
            this.groupBox2.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
	

		}

		private void Alarms_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!"; 
		}


		private void fill_Items()
		{ 
			
	
		
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
          // cal_tEXT();		
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
			//lv_Ritems.Columns[3].Width = this.Width -   537 ; //377;
		}

		private void btnskip_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnSaveSN_Click(object sender, System.EventArgs e)
		{

		}

		private void btnSv_Click(object sender, System.EventArgs e)
		{


		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{

		}

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void tlsSave_Click(object sender, EventArgs e)
        {
           
            lSP.Text = "S";
            this.Hide();
        }

        private void tlsPrint_Click(object sender, EventArgs e)
        {

            //cleanNoneSN();

            if (lv_Ritems.SelectedItems.Count > 0)
            {

                lSP.Text = "P";
                this.Hide();
            }
            else MessageBox.Show("You must select Serial # ....!!!!!");
        }

        private void tlsSnP_Click(object sender, EventArgs e)
        {
            cleanNoneSN();
            lSP.Text = "SP";
            this.Hide();
        }

        private void _exit_Click(object sender, EventArgs e)
        {
            lSP.Text = "C";
            this.Hide();
        }

        private void tls_setSN_Click(object sender, EventArgs e)
        {
            Serial_SelectedSN();
        }


        void cleanNoneSN()
        {

            int b = 0;
            while (b < lv_Ritems.Items.Count)
            {
                if (Tools.Conv_Dbl(lv_Ritems.Items[b].SubItems[1].Text) == 0) lv_Ritems.Items[b].Remove();
                else b++;
            }
           
        }
        void Serial_SelectedSN()
        {

            this.Cursor = Cursors.WaitCursor;

            for (int b = 0; b < lv_Ritems.Items.Count; b++)
            {
                Int64 res = 0;
                if (lv_Ritems.Items[b].Checked && Tools.Conv_Dbl(lv_Ritems.Items[b].SubItems[1].Text) == 0)
                {
                    res = fill_SNID();
                    if (res > 0)
                    {
                        lv_Ritems.Items[b].SubItems[1].Text = res.ToString();
                        lv_Ritems.Items[b].ForeColor = Color.Red;
                        // arr_SNcr[SNi++] = Res.ToString();
                    }
                    else b = lv_Ritems.Items.Count;
                        //MessageBox.Show("Sorry, No charger found or Serial# table is full.....Contact your Admin");
                }
            }
          //  cleanNoneSN();
            this.Cursor = Cursors.Default;
        }


        private Int64 fill_SNID()
        {

            MainMDI.lock_table('S');
            long Sn = MainMDI.Gen_IDFinal('S');
           string  TPXsn_Text = "";
            switch (Sn)
            {
                case 0:
                    //MessageBox.Show("Table PSM_S_GenID is Full....");
                    MessageBox.Show("Serials IDs must be added, please contact your Administrator ....");
                    break;
                case -1:
                    MessageBox.Show("No available Serial#, GEN_IDs is empty , please contact your Administrator....");

                    break;
                default:
                    TPXsn_Text = Sn.ToString();
                    MainMDI.flag_QRID('S', 'u', 1, Sn);
                    break;
            }
            MainMDI.Unlock_table("PSM_S_GenID");
            return Convert.ToInt64(Sn);
        }

        private void tlsSall_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lv in lv_Ritems.Items)
                lv.Checked = true;

        }

        private void tlsUall_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lv in lv_Ritems.Items)
                lv.Checked = false;
        }

	

	}
}
