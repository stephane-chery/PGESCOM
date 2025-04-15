using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data ;
using System.Data.OleDb ;
using System.Data.SqlClient  ;
using EAHLibs;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for dlgCreditCrds.
	/// </summary>
	public class dlg_Avail: System.Windows.Forms.Form
	{

        public bool done = false;
		private string in_CPTid="",in_VDC="",in_CPTnm="",in_Phs="1",in_stSql="",in_PXX="P4500";
        Setng_003_Avail in_frm =null;
      
		long lcpnyLID =0;
		char Opera='F';
		int ndxfound=0;
		private Lib1 Tools = new Lib1();
        public bool lOK = false;
        private ToolStripButton del;
        private GroupBox groupBox1;
        private PictureBox picExit;
        private Label lVDC;
        private PictureBox picsav;
        public TextBox txVDC;
        private Label lCPT;
        public TextBox txCPT;
        private GroupBox groupBox3;
        private PictureBox picAdd;
        private PictureBox PicDel;
        private GroupBox groupBox2;
        private ListView lv_IDCout;
        private ColumnHeader lnk_availid;
        private ColumnHeader Item;
        private ColumnHeader IDC;
        private ColumnHeader AvailLID;
        private GroupBox grpVDC;
        private ListView LV_IN;
        private ColumnHeader flnk_Availid;
        private ColumnHeader fdesc;
        private ColumnHeader fidc;
        private ColumnHeader AVlid;
        private Label label1;
        private Label label2;
        public ComboBox cbVDC;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public dlg_Avail(string x_Phs,string x_CptLID, string x_CPTnm, string x_VDC) //,string x_stSql)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            in_CPTid = x_CptLID;
            in_VDC = x_VDC;
            in_CPTnm = x_CPTnm;
            txCPT.Text = in_CPTnm;
            txVDC.Text  = in_VDC;
        //    in_stSql = x_stSql;
         
            in_Phs = x_Phs;// in_frm.toolStripComboBox1.Text[0].ToString();



		
    
	

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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbVDC = new System.Windows.Forms.ComboBox();
            this.lVDC = new System.Windows.Forms.Label();
            this.txVDC = new System.Windows.Forms.TextBox();
            this.lCPT = new System.Windows.Forms.Label();
            this.txCPT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lv_IDCout = new System.Windows.Forms.ListView();
            this.lnk_availid = new System.Windows.Forms.ColumnHeader();
            this.Item = new System.Windows.Forms.ColumnHeader();
            this.IDC = new System.Windows.Forms.ColumnHeader();
            this.AvailLID = new System.Windows.Forms.ColumnHeader();
            this.grpVDC = new System.Windows.Forms.GroupBox();
            this.LV_IN = new System.Windows.Forms.ListView();
            this.flnk_Availid = new System.Windows.Forms.ColumnHeader();
            this.fdesc = new System.Windows.Forms.ColumnHeader();
            this.fidc = new System.Windows.Forms.ColumnHeader();
            this.AVlid = new System.Windows.Forms.ColumnHeader();
            this.picAdd = new System.Windows.Forms.PictureBox();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.PicDel = new System.Windows.Forms.PictureBox();
            this.picsav = new System.Windows.Forms.PictureBox();
            this.del = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.grpVDC.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picsav)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbVDC);
            this.groupBox1.Controls.Add(this.lVDC);
            this.groupBox1.Controls.Add(this.txVDC);
            this.groupBox1.Controls.Add(this.lCPT);
            this.groupBox1.Controls.Add(this.txCPT);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(210, 672);
            this.groupBox1.TabIndex = 338;
            this.groupBox1.TabStop = false;
            // 
            // cbVDC
            // 
            this.cbVDC.BackColor = System.Drawing.Color.AliceBlue;
            this.cbVDC.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbVDC.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbVDC.Location = new System.Drawing.Point(66, 304);
            this.cbVDC.Name = "cbVDC";
            this.cbVDC.Size = new System.Drawing.Size(141, 21);
            this.cbVDC.TabIndex = 388;
            this.cbVDC.SelectedIndexChanged += new System.EventHandler(this.cbVDC_SelectedIndexChanged);
            // 
            // lVDC
            // 
            this.lVDC.BackColor = System.Drawing.SystemColors.Control;
            this.lVDC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lVDC.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVDC.ForeColor = System.Drawing.Color.Red;
            this.lVDC.Location = new System.Drawing.Point(14, 306);
            this.lVDC.Name = "lVDC";
            this.lVDC.Size = new System.Drawing.Size(52, 17);
            this.lVDC.TabIndex = 387;
            this.lVDC.Text = "VDC:";
            this.lVDC.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txVDC
            // 
            this.txVDC.BackColor = System.Drawing.Color.AliceBlue;
            this.txVDC.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txVDC.ForeColor = System.Drawing.Color.DarkRed;
            this.txVDC.Location = new System.Drawing.Point(66, 326);
            this.txVDC.MaxLength = 49;
            this.txVDC.Multiline = true;
            this.txVDC.Name = "txVDC";
            this.txVDC.ReadOnly = true;
            this.txVDC.Size = new System.Drawing.Size(75, 28);
            this.txVDC.TabIndex = 386;
            this.txVDC.Visible = false;
            // 
            // lCPT
            // 
            this.lCPT.BackColor = System.Drawing.SystemColors.Control;
            this.lCPT.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lCPT.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCPT.ForeColor = System.Drawing.Color.Red;
            this.lCPT.Location = new System.Drawing.Point(12, 241);
            this.lCPT.Name = "lCPT";
            this.lCPT.Size = new System.Drawing.Size(152, 20);
            this.lCPT.TabIndex = 385;
            this.lCPT.Text = "Component REF.";
            this.lCPT.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txCPT
            // 
            this.txCPT.BackColor = System.Drawing.Color.AliceBlue;
            this.txCPT.Font = new System.Drawing.Font("Verdana", 14.25F, System.Drawing.FontStyle.Bold);
            this.txCPT.ForeColor = System.Drawing.Color.DarkRed;
            this.txCPT.Location = new System.Drawing.Point(12, 261);
            this.txCPT.MaxLength = 49;
            this.txCPT.Multiline = true;
            this.txCPT.Name = "txCPT";
            this.txCPT.ReadOnly = true;
            this.txCPT.Size = new System.Drawing.Size(194, 28);
            this.txCPT.TabIndex = 384;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(38, 576);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 389;
            this.label2.Text = "Exit";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(40, 326);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 388;
            this.label1.Text = "Save";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.picAdd);
            this.groupBox3.Controls.Add(this.picExit);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.PicDel);
            this.groupBox3.Controls.Add(this.picsav);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(502, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(92, 672);
            this.groupBox3.TabIndex = 347;
            this.groupBox3.TabStop = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lv_IDCout);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(210, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(292, 672);
            this.groupBox2.TabIndex = 345;
            this.groupBox2.TabStop = false;
            // 
            // lv_IDCout
            // 
            this.lv_IDCout.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lv_IDCout.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lnk_availid,
            this.Item,
            this.IDC,
            this.AvailLID});
            this.lv_IDCout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lv_IDCout.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_IDCout.FullRowSelect = true;
            this.lv_IDCout.GridLines = true;
            this.lv_IDCout.Location = new System.Drawing.Point(3, 16);
            this.lv_IDCout.Name = "lv_IDCout";
            this.lv_IDCout.Size = new System.Drawing.Size(286, 653);
            this.lv_IDCout.TabIndex = 344;
            this.lv_IDCout.UseCompatibleStateImageBehavior = false;
            this.lv_IDCout.View = System.Windows.Forms.View.Details;
            // 
            // lnk_availid
            // 
            this.lnk_availid.Text = "";
            this.lnk_availid.Width = 0;
            // 
            // Item
            // 
            this.Item.Text = "Disabled Chargers";
            this.Item.Width = 263;
            // 
            // IDC
            // 
            this.IDC.Text = "";
            this.IDC.Width = 0;
            // 
            // AvailLID
            // 
            this.AvailLID.Text = "";
            this.AvailLID.Width = 0;
            // 
            // grpVDC
            // 
            this.grpVDC.Controls.Add(this.LV_IN);
            this.grpVDC.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpVDC.Location = new System.Drawing.Point(594, 0);
            this.grpVDC.Name = "grpVDC";
            this.grpVDC.Size = new System.Drawing.Size(314, 672);
            this.grpVDC.TabIndex = 349;
            this.grpVDC.TabStop = false;
            // 
            // LV_IN
            // 
            this.LV_IN.BackColor = System.Drawing.Color.LightGreen;
            this.LV_IN.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.flnk_Availid,
            this.fdesc,
            this.fidc,
            this.AVlid});
            this.LV_IN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_IN.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LV_IN.FullRowSelect = true;
            this.LV_IN.GridLines = true;
            this.LV_IN.Location = new System.Drawing.Point(3, 16);
            this.LV_IN.Name = "LV_IN";
            this.LV_IN.Size = new System.Drawing.Size(308, 653);
            this.LV_IN.TabIndex = 344;
            this.LV_IN.UseCompatibleStateImageBehavior = false;
            this.LV_IN.View = System.Windows.Forms.View.Details;
            // 
            // flnk_Availid
            // 
            this.flnk_Availid.Text = "";
            this.flnk_Availid.Width = 0;
            // 
            // fdesc
            // 
            this.fdesc.Text = "Enabled Chargers";
            this.fdesc.Width = 281;
            // 
            // fidc
            // 
            this.fidc.Text = "";
            this.fidc.Width = 0;
            // 
            // AVlid
            // 
            this.AVlid.Text = "";
            this.AVlid.Width = 0;
            // 
            // picAdd
            // 
            this.picAdd.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picAdd.Cursor = System.Windows.Forms.Cursors.Hand;
        //    this.picAdd.Image = global::PGESCOM.Properties.Resources.Arrow_Right;
            this.picAdd.Location = new System.Drawing.Point(3, 153);
            this.picAdd.Name = "picAdd";
            this.picAdd.Size = new System.Drawing.Size(78, 61);
            this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAdd.TabIndex = 359;
            this.picAdd.TabStop = false;
            this.picAdd.Click += new System.EventHandler(this.picAdd_Click);
            // 
            // picExit
            // 
            this.picExit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.Image = global::PGESCOM.Properties.Resources.Log_Off;
            this.picExit.Location = new System.Drawing.Point(32, 596);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(49, 69);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 361;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // PicDel
            // 
            this.PicDel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.PicDel.Cursor = System.Windows.Forms.Cursors.Hand;
     //       this.PicDel.Image = global::PGESCOM.Properties.Resources.Arrow_Left;
            this.PicDel.Location = new System.Drawing.Point(3, 241);
            this.PicDel.Name = "PicDel";
            this.PicDel.Size = new System.Drawing.Size(78, 61);
            this.PicDel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PicDel.TabIndex = 358;
            this.PicDel.TabStop = false;
            this.PicDel.Click += new System.EventHandler(this.PicDel_Click);
            // 
            // picsav
            // 
            this.picsav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picsav.Cursor = System.Windows.Forms.Cursors.Hand;
        //    this.picsav.Image = global::PGESCOM.Properties.Resources._1__7_;
            this.picsav.Location = new System.Drawing.Point(22, 346);
            this.picsav.Name = "picsav";
            this.picsav.Size = new System.Drawing.Size(59, 69);
            this.picsav.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picsav.TabIndex = 360;
            this.picsav.TabStop = false;
            this.picsav.Click += new System.EventHandler(this.picsav_Click);
            // 
            // del
            // 
            this.del.Image = global::PGESCOM.Properties.Resources.remove1;
            this.del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(87, 60);
            this.del.Text = "Delete Payment";
            this.del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.del.Visible = false;
            // 
            // dlg_Avail
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(919, 672);
            this.Controls.Add(this.grpVDC);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "dlg_Avail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enable / Disable Availabilities";
            this.Load += new System.EventHandler(this.dlg_Avail_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.grpVDC.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.PicDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picsav)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

        private void dlg_Avail_Load(object sender, EventArgs e)
        {
            Fill_VDC();
            cbVDC.Text = in_VDC; 
          //  txVDC.Visible = (txVDC.Text != "");
            lVDC.Visible = txVDC.Visible;
           // fill_Avail_IN();
            fill_Avail_OUT (in_Phs ,in_PXX ,txVDC.Text ,in_CPTid  ) ;
            
        }

        private void fill_Avail_INOLD()
        {
            LV_IN.Items.Clear();  
           for (int i=0;i<in_frm.lvCH_QTY.Items.Count ;i++)
               add_LVIN(in_frm.lvCH_QTY.Items[i].SubItems[3].Text, in_frm.lvCH_QTY.Items[i].SubItems[1].Text, "","");

        }
        private void fill_Avail_IN()
        {

            string stSql = " SELECT  COMPNT_LIST.Component_ID, CAST(TBLAVAIL" + in_Phs + ".idc AS int) AS IDC, link_COMPNT_AVAIL.Qty, link_COMPNT_AVAIL.Avail_ID, link_COMPNT_AVAIL.LCA_LID " +
                        " FROM         link_COMPNT_AVAIL INNER JOIN  TBLAVAIL" + in_Phs + " ON link_COMPNT_AVAIL.Avail_ID = TBLAVAIL" + in_Phs + ".Avail_ID INNER JOIN  COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = COMPNT_LIST.Component_ID " +
                        " WHERE     (link_COMPNT_AVAIL.phs = " + in_Phs + ") AND (COMPNT_LIST.COMPONENT_REF = '" + in_CPTnm + "') AND (TBLAVAIL" + in_Phs + ".charger = '" + in_PXX + "') AND (CAST(TBLAVAIL" + in_Phs + ".vdc AS int)  = " +in_VDC + ") " +
                        " ORDER BY IDC ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            LV_IN.Items.Clear(); 

            while (Oreadr.Read())
            {

                add_LVIN(Oreadr["LCA_LID"].ToString(),in_PXX  + "-" + in_Phs + "-" + in_VDC + "-" + Oreadr["IDC"].ToString(),"", "");
 
            }
            OConn.Close();


        }

        private void add_LVIN(string _lnkid, string _desc, string _Idc, string _AvLID)
        {
            ListViewItem lv = LV_IN.Items.Add(_lnkid);
            lv.SubItems.Add(_desc);
            lv.SubItems.Add(_Idc);
            lv.SubItems.Add(_AvLID);
            lv.BackColor = (_Idc == "") ? Color.LightGreen : Color.Yellow;

        }
        private void add_LVIDC_OUT(string _lnkAVlid,string _desc, string _idc, string _avLID)
        {
            ListViewItem lv = lv_IDCout.Items.Add(_lnkAVlid);
            lv.SubItems.Add(_desc  );
            lv.SubItems.Add(_idc);
            lv.SubItems.Add(_avLID );
            lv.BackColor = (_lnkAVlid == "") ? Color.WhiteSmoke : Color.Salmon ;

        }

        private void fill_Avail_OUT(string _phs,string _pxx,string _vdc,string _cptID)
        {
          
      
            string stSql = " SELECT * from  TBLAVAIL" + _phs +" WHERE  TBLAVAIL" + _phs +".charger = '" + _pxx + "' and vdc='" + _vdc +"' and Avail_ID not in (SELECT link_COMPNT_AVAIL.Avail_ID  " +
                           " FROM   link_COMPNT_AVAIL INNER JOIN TBLAVAIL" + _phs +" ON link_COMPNT_AVAIL.Avail_ID = TBLAVAIL" + _phs +".Avail_ID " +
                           " WHERE     (TBLAVAIL" + _phs + ".charger = '" + _pxx + "') AND (TBLAVAIL" + _phs + ".vdc = '" + _vdc + "') and link_COMPNT_AVAIL.Compnt_ID=" + _cptID + " and phs='" + _phs + "')";
            
                     
                  SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                  OConn.Open();
                  SqlCommand Ocmd = OConn.CreateCommand();
                  Ocmd.CommandText = stSql;
                  SqlDataReader Oreadr = Ocmd.ExecuteReader();
                  lv_IDCout.Items.Clear();  
                  while (Oreadr.Read())
                  {
                      string desc=_pxx +"-" + _phs + "-" + _vdc +"-" +Oreadr["idc"].ToString ();
                      add_LVIDC_OUT("", desc, Oreadr["idc"].ToString(), Oreadr["Avail_ID"].ToString());

                  }



        }

        private void exiit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void picAdd_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lv_IDCout.SelectedItems.Count; i++) add_LVIN(lv_IDCout.Items[lv_IDCout.SelectedItems[i].Index].SubItems[0].Text, lv_IDCout.Items[lv_IDCout.SelectedItems[i].Index].SubItems[1].Text, lv_IDCout.Items[lv_IDCout.SelectedItems[i].Index].SubItems[2].Text, lv_IDCout.Items[lv_IDCout.SelectedItems[i].Index].SubItems[3].Text);
            for (int i = lv_IDCout.SelectedItems.Count-1; i > -1; i--) lv_IDCout.Items[lv_IDCout.SelectedItems[i].Index].Remove();
            LV_IN.Items[LV_IN.Items.Count - 1].Selected = true;
            LV_IN.Select();
            LV_IN.EnsureVisible(LV_IN.Items.Count - 1); 
        }

        private void picExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void picsav_Click(object sender, EventArgs e)
        {
            string stSql = "";
            for (int i = 0; i < LV_IN.Items.Count; i++)
            {
                if (LV_IN.Items[i].SubItems[0].Text == "" && LV_IN.Items[i].SubItems[2].Text != "")
                {
                    stSql = "insert into link_COMPNT_AVAIL ([Compnt_ID],[Avail_ID],[Qty],[phs]) Values (" + in_CPTid +
               ", " + LV_IN.Items[i].SubItems[3].Text + ", 1, '" + in_Phs + "')";
                    //      if (MainMDI.Confirm(stSql)) 
                    MainMDI.Exec_SQL_JFS(stSql, " create New LNK availability..");

                }
            }

            for (int i = 0; i < lv_IDCout.Items.Count; i++)
            {
                if (lv_IDCout.Items[i].SubItems[0].Text != "" && lv_IDCout.Items[i].SubItems[3].Text == "")
                {
                    stSql = "delete link_COMPNT_AVAIL  where LCA_LID=" + lv_IDCout.Items[i].SubItems[0].Text;
                    //    if (MainMDI.Confirm (stSql )) 
                    MainMDI.Exec_SQL_JFS(stSql, " delete lnk Availability...");

                }
                
            }

            fill_Avail_IN();
            fill_Avail_OUT(in_Phs, in_PXX , in_VDC, in_CPTid);
        }

        private void PicDel_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LV_IN.SelectedItems.Count; i++) add_LVIDC_OUT(LV_IN.Items[LV_IN.SelectedItems[i].Index].SubItems[0].Text, LV_IN.Items[LV_IN.SelectedItems[i].Index].SubItems[1].Text, LV_IN.Items[LV_IN.SelectedItems[i].Index].SubItems[2].Text, LV_IN.Items[LV_IN.SelectedItems[i].Index].SubItems[3].Text);
            for (int i = LV_IN.SelectedItems.Count - 1; i > -1; i--) LV_IN.Items[LV_IN.SelectedItems[i].Index].Remove();
          
        }


        private void Fill_VDC()
        {


            string stSql = "  SELECT * from V_VDC_List ORDER BY cast (VDC as int)";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())  cbVDC.Items.Add(Oreadr["VDC"].ToString());

            OConn.Close();
        }

        private void cbVDC_SelectedIndexChanged(object sender, EventArgs e)
        {
            in_VDC = cbVDC.Text;
            txVDC.Text = in_VDC;

            fill_Avail_IN();
            fill_Avail_OUT(in_Phs, in_PXX, txVDC.Text, in_CPTid);
        }





    }
}
