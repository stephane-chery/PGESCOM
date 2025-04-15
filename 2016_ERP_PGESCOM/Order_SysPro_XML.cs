using System;
using System.Drawing;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb ;
using System.Data.SqlClient ;
using System.Xml;
using EAHLibs;
using System.ServiceProcess;
using Outlook = Microsoft.Office.Interop.Outlook;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for Alarms.
	/// </summary>
    /// 
    
	public class Order_SysPro_XML: System.Windows.Forms.Form
	{

		private Lib1 Tools = new Lib1();
		public bool ToBRKDWN=false;


        private Chargerdlg in_frm_FDR;
        private System.Windows.Forms.ImageList imageList1;
        private System.ComponentModel.IContainer components;
        private ToolStrip TSmain;
        private ToolStripButton NewItm;
        private ToolStripButton send_XML;
        private ToolStripButton Qty_repr;
        private ToolStripButton exitt;
        private GroupBox groupBox1;
        string in_irevLID = "", in_RID = "";
        private Label lCMSOvrg;
        private Label lCMSBad;
        private ToolStripButton toolStripButton1;
        private Label label1;
        private GroupBox groupBox2;
        private Label label2;
        public Label lAG_email;
        private Label lAG_CodeName;
        private Label label126;
        private ComboBox cbAG;
        public CheckBox chkSendAG;
        private GroupBox groupBox3;
        private Button btnskip;
        public Label lCustomerID;
        private Button btnSave;
        public Label lSP;
        private Button btnSv;
        private Button button1;
        private Button btnCancel;
        private ed_LVmodif ed_lvItems;
        private ColumnHeader stck;
        private ColumnHeader sys;
        private ColumnHeader c_SN;
        private ColumnHeader Item;
        private ColumnHeader c_Qty;
        private ColumnHeader PU;
        private ColumnHeader Ext;
        private ColumnHeader ItmTotal;
        private ColumnHeader c_revID;
        private ColumnHeader RevNM;
        private ColumnHeader c_cpnyNM;
        private ColumnHeader c_QID;
        private ColumnHeader c_PO;
        private ColumnHeader c_Opendat;
        private ColumnHeader c_dateRRev;
        private ColumnHeader c_dateDlvr;
        private ColumnHeader c_RID;
        private ColumnHeader c_TVA;
        private ColumnHeader c_stkCode;
        private ColumnHeader curr;
        private ColumnHeader OV_Sale;
        private ColumnHeader OV_AG;
        private ColumnHeader Xch_Mlt;
        private Label lIRREV;
        public Label lag;
        private Button btnSaveSN;

        

        public Order_SysPro_XML(string x_irrevLID, string x_RID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		//	in_frm_FDR=x_Frm_Cdlg;
			in_irevLID =x_irrevLID ;
            in_RID = x_RID;
	                   




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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order_SysPro_XML));
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.NewItm = new System.Windows.Forms.ToolStripButton();
            this.Qty_repr = new System.Windows.Forms.ToolStripButton();
            this.send_XML = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.exitt = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ed_lvItems = new PGESCOM.ed_LVmodif();
            this.stck = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sys = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_SN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Item = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_Qty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PU = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ext = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItmTotal = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_revID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RevNM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_cpnyNM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_QID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_PO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_Opendat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_dateRRev = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_dateDlvr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_RID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_TVA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.c_stkCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.curr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OV_Sale = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.OV_AG = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Xch_Mlt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lIRREV = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lAG_CodeName = new System.Windows.Forms.Label();
            this.label126 = new System.Windows.Forms.Label();
            this.chkSendAG = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnskip = new System.Windows.Forms.Button();
            this.lCustomerID = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.lSP = new System.Windows.Forms.Label();
            this.btnSv = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSaveSN = new System.Windows.Forms.Button();
            this.lag = new System.Windows.Forms.Label();
            this.lAG_email = new System.Windows.Forms.Label();
            this.cbAG = new System.Windows.Forms.ComboBox();
            this.lCMSOvrg = new System.Windows.Forms.Label();
            this.lCMSBad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TSmain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "");
            // 
            // TSmain
            // 
            this.TSmain.BackColor = System.Drawing.Color.LemonChiffon;
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewItm,
            this.Qty_repr,
            this.send_XML,
            this.toolStripButton1,
            this.exitt});
            this.TSmain.Location = new System.Drawing.Point(0, 0);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(1270, 54);
            this.TSmain.TabIndex = 258;
            this.TSmain.Text = "toolStrip2";
            this.TSmain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TSmain_ItemClicked);
            // 
            // NewItm
            // 
            this.NewItm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewItm.Name = "NewItm";
            this.NewItm.Size = new System.Drawing.Size(61, 51);
            this.NewItm.Text = "New Rate";
            this.NewItm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NewItm.ToolTipText = "New";
            this.NewItm.Visible = false;
            // 
            // Qty_repr
            // 
            this.Qty_repr.Image = ((System.Drawing.Image)(resources.GetObject("Qty_repr.Image")));
            this.Qty_repr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Qty_repr.Name = "Qty_repr";
            this.Qty_repr.Size = new System.Drawing.Size(104, 51);
            this.Qty_repr.Text = "Start SYSPRO-xml";
            this.Qty_repr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Qty_repr.ToolTipText = "Delete Batch";
            this.Qty_repr.Click += new System.EventHandler(this.Qty_repr_Click);
            // 
            // send_XML
            // 
            this.send_XML.Image = ((System.Drawing.Image)(resources.GetObject("send_XML.Image")));
            this.send_XML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.send_XML.Name = "send_XML";
            this.send_XML.Size = new System.Drawing.Size(102, 51);
            this.send_XML.Text = "  Send  To SYPRO";
            this.send_XML.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.send_XML.ToolTipText = "Save";
            this.send_XML.Click += new System.EventHandler(this.send_XML_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(65, 51);
            this.toolStripButton1.Text = "SAVE XML";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.ToolTipText = "Save";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // exitt
            // 
            this.exitt.Image = ((System.Drawing.Image)(resources.GetObject("exitt.Image")));
            this.exitt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitt.Name = "exitt";
            this.exitt.Size = new System.Drawing.Size(59, 51);
            this.exitt.Text = "     Exit     ";
            this.exitt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exitt.ToolTipText = "Exit";
            this.exitt.Click += new System.EventHandler(this.exitt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ed_lvItems);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 54);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1270, 688);
            this.groupBox1.TabIndex = 259;
            this.groupBox1.TabStop = false;
            // 
            // ed_lvItems
            // 
            this.ed_lvItems.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvItems.AutoArrange = false;
            this.ed_lvItems.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ed_lvItems.CheckBoxes = true;
            this.ed_lvItems.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.stck,
            this.sys,
            this.c_SN,
            this.Item,
            this.c_Qty,
            this.PU,
            this.Ext,
            this.ItmTotal,
            this.c_revID,
            this.RevNM,
            this.c_cpnyNM,
            this.c_QID,
            this.c_PO,
            this.c_Opendat,
            this.c_dateRRev,
            this.c_dateDlvr,
            this.c_RID,
            this.c_TVA,
            this.c_stkCode,
            this.curr,
            this.OV_Sale,
            this.OV_AG,
            this.Xch_Mlt});
            this.ed_lvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_lvItems.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvItems.ForeColor = System.Drawing.Color.Black;
            this.ed_lvItems.FullRowSelect = true;
            this.ed_lvItems.GridLines = true;
            this.ed_lvItems.Location = new System.Drawing.Point(3, 72);
            this.ed_lvItems.MultiSelect = false;
            this.ed_lvItems.Name = "ed_lvItems";
            this.ed_lvItems.Size = new System.Drawing.Size(1264, 613);
            this.ed_lvItems.TabIndex = 254;
            this.ed_lvItems.UseCompatibleStateImageBehavior = false;
            this.ed_lvItems.View = System.Windows.Forms.View.Details;
            // 
            // stck
            // 
            this.stck.Text = "stk";
            this.stck.Width = 0;
            // 
            // sys
            // 
            this.sys.Text = "System Name";
            this.sys.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sys.Width = 204;
            // 
            // c_SN
            // 
            this.c_SN.Text = "Serial #";
            this.c_SN.Width = 73;
            // 
            // Item
            // 
            this.Item.Text = "Item";
            this.Item.Width = 265;
            // 
            // c_Qty
            // 
            this.c_Qty.Text = "Qty";
            this.c_Qty.Width = 50;
            // 
            // PU
            // 
            this.PU.Text = "Unit Price";
            this.PU.Width = 126;
            // 
            // Ext
            // 
            this.Ext.Text = "Extension";
            this.Ext.Width = 155;
            // 
            // ItmTotal
            // 
            this.ItmTotal.Text = "Job Total";
            this.ItmTotal.Width = 100;
            // 
            // c_revID
            // 
            this.c_revID.Text = "";
            this.c_revID.Width = 0;
            // 
            // RevNM
            // 
            this.RevNM.Text = "";
            this.RevNM.Width = 0;
            // 
            // c_cpnyNM
            // 
            this.c_cpnyNM.Text = "";
            this.c_cpnyNM.Width = 0;
            // 
            // c_QID
            // 
            this.c_QID.Text = "";
            this.c_QID.Width = 0;
            // 
            // c_PO
            // 
            this.c_PO.Text = "";
            this.c_PO.Width = 0;
            // 
            // c_Opendat
            // 
            this.c_Opendat.Text = "";
            this.c_Opendat.Width = 0;
            // 
            // c_dateRRev
            // 
            this.c_dateRRev.Text = "";
            this.c_dateRRev.Width = 0;
            // 
            // c_dateDlvr
            // 
            this.c_dateDlvr.Width = 0;
            // 
            // c_RID
            // 
            this.c_RID.Text = "";
            this.c_RID.Width = 0;
            // 
            // c_TVA
            // 
            this.c_TVA.Text = "";
            this.c_TVA.Width = 0;
            // 
            // c_stkCode
            // 
            this.c_stkCode.Text = "Stock Code";
            this.c_stkCode.Width = 220;
            // 
            // curr
            // 
            this.curr.Text = "";
            this.curr.Width = 0;
            // 
            // OV_Sale
            // 
            this.OV_Sale.Text = "";
            this.OV_Sale.Width = 0;
            // 
            // OV_AG
            // 
            this.OV_AG.Text = "";
            this.OV_AG.Width = 0;
            // 
            // Xch_Mlt
            // 
            this.Xch_Mlt.Text = "";
            this.Xch_Mlt.Width = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lIRREV);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.lAG_CodeName);
            this.groupBox2.Controls.Add(this.label126);
            this.groupBox2.Controls.Add(this.chkSendAG);
            this.groupBox2.Controls.Add(this.groupBox3);
            this.groupBox2.Controls.Add(this.lag);
            this.groupBox2.Controls.Add(this.lAG_email);
            this.groupBox2.Controls.Add(this.cbAG);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1264, 56);
            this.groupBox2.TabIndex = 253;
            this.groupBox2.TabStop = false;
            // 
            // lIRREV
            // 
            this.lIRREV.BackColor = System.Drawing.Color.White;
            this.lIRREV.Location = new System.Drawing.Point(1049, 24);
            this.lIRREV.Name = "lIRREV";
            this.lIRREV.Size = new System.Drawing.Size(73, 16);
            this.lIRREV.TabIndex = 272;
            this.lIRREV.Text = "0";
            this.lIRREV.Visible = false;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Blue;
            this.label2.Location = new System.Drawing.Point(573, 24);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(68, 21);
            this.label2.TabIndex = 271;
            this.label2.Text = "E-mail:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lAG_CodeName
            // 
            this.lAG_CodeName.BackColor = System.Drawing.Color.CornflowerBlue;
            this.lAG_CodeName.Location = new System.Drawing.Point(603, 6);
            this.lAG_CodeName.Name = "lAG_CodeName";
            this.lAG_CodeName.Size = new System.Drawing.Size(16, 16);
            this.lAG_CodeName.TabIndex = 269;
            this.lAG_CodeName.Visible = false;
            // 
            // label126
            // 
            this.label126.BackColor = System.Drawing.Color.Transparent;
            this.label126.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label126.ForeColor = System.Drawing.Color.Blue;
            this.label126.Location = new System.Drawing.Point(220, 24);
            this.label126.Name = "label126";
            this.label126.Size = new System.Drawing.Size(62, 21);
            this.label126.TabIndex = 267;
            this.label126.Text = "Agency";
            this.label126.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // chkSendAG
            // 
            this.chkSendAG.BackColor = System.Drawing.SystemColors.Control;
            this.chkSendAG.Checked = true;
            this.chkSendAG.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkSendAG.Enabled = false;
            this.chkSendAG.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.chkSendAG.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.chkSendAG.ForeColor = System.Drawing.Color.Blue;
            this.chkSendAG.Location = new System.Drawing.Point(47, 22);
            this.chkSendAG.Name = "chkSendAG";
            this.chkSendAG.Size = new System.Drawing.Size(173, 24);
            this.chkSendAG.TabIndex = 265;
            this.chkSendAG.Text = "Sent mail to Agency";
            this.chkSendAG.UseVisualStyleBackColor = false;
            this.chkSendAG.CheckedChanged += new System.EventHandler(this.chkSendAG_CheckedChanged);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.btnskip);
            this.groupBox3.Controls.Add(this.lCustomerID);
            this.groupBox3.Controls.Add(this.btnSave);
            this.groupBox3.Controls.Add(this.lSP);
            this.groupBox3.Controls.Add(this.btnSv);
            this.groupBox3.Controls.Add(this.button1);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.btnSaveSN);
            this.groupBox3.Location = new System.Drawing.Point(1152, 6);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(94, 44);
            this.groupBox3.TabIndex = 154;
            this.groupBox3.TabStop = false;
            this.groupBox3.Visible = false;
            // 
            // btnskip
            // 
            this.btnskip.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnskip.Location = new System.Drawing.Point(290, 14);
            this.btnskip.Name = "btnskip";
            this.btnskip.Size = new System.Drawing.Size(30, 24);
            this.btnskip.TabIndex = 147;
            this.btnskip.Text = "Skip";
            this.btnskip.Visible = false;
            // 
            // lCustomerID
            // 
            this.lCustomerID.BackColor = System.Drawing.Color.DarkCyan;
            this.lCustomerID.Location = new System.Drawing.Point(29, 20);
            this.lCustomerID.Name = "lCustomerID";
            this.lCustomerID.Size = new System.Drawing.Size(23, 16);
            this.lCustomerID.TabIndex = 153;
            this.lCustomerID.Text = "C";
            this.lCustomerID.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(251, 14);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(33, 24);
            this.btnSave.TabIndex = 146;
            this.btnSave.Text = "OK";
            this.btnSave.Visible = false;
            // 
            // lSP
            // 
            this.lSP.BackColor = System.Drawing.Color.DarkCyan;
            this.lSP.Location = new System.Drawing.Point(70, 20);
            this.lSP.Name = "lSP";
            this.lSP.Size = new System.Drawing.Size(24, 16);
            this.lSP.TabIndex = 150;
            this.lSP.Text = "C";
            this.lSP.Visible = false;
            // 
            // btnSv
            // 
            this.btnSv.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSv.Location = new System.Drawing.Point(100, 10);
            this.btnSv.Name = "btnSv";
            this.btnSv.Size = new System.Drawing.Size(27, 24);
            this.btnSv.TabIndex = 151;
            this.btnSv.Text = "Save Serials";
            this.btnSv.Visible = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(169, 16);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(36, 24);
            this.button1.TabIndex = 152;
            this.button1.Text = "Print Selected SN";
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(211, 14);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(34, 24);
            this.btnCancel.TabIndex = 149;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Visible = false;
            // 
            // btnSaveSN
            // 
            this.btnSaveSN.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSaveSN.Location = new System.Drawing.Point(133, 14);
            this.btnSaveSN.Name = "btnSaveSN";
            this.btnSaveSN.Size = new System.Drawing.Size(30, 24);
            this.btnSaveSN.TabIndex = 148;
            this.btnSaveSN.Text = "Save + Print Serials";
            this.btnSaveSN.Visible = false;
            // 
            // lag
            // 
            this.lag.BackColor = System.Drawing.Color.PaleGreen;
            this.lag.ForeColor = System.Drawing.Color.Black;
            this.lag.Location = new System.Drawing.Point(282, 24);
            this.lag.Name = "lag";
            this.lag.Size = new System.Drawing.Size(291, 20);
            this.lag.TabIndex = 273;
            this.lag.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lAG_email
            // 
            this.lAG_email.BackColor = System.Drawing.Color.PaleGreen;
            this.lAG_email.ForeColor = System.Drawing.Color.Black;
            this.lAG_email.Location = new System.Drawing.Point(641, 24);
            this.lAG_email.Name = "lAG_email";
            this.lAG_email.Size = new System.Drawing.Size(297, 20);
            this.lAG_email.TabIndex = 270;
            this.lAG_email.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbAG
            // 
            this.cbAG.BackColor = System.Drawing.Color.Green;
            this.cbAG.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbAG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbAG.ForeColor = System.Drawing.Color.White;
            this.cbAG.Location = new System.Drawing.Point(282, 24);
            this.cbAG.Name = "cbAG";
            this.cbAG.Size = new System.Drawing.Size(291, 21);
            this.cbAG.TabIndex = 268;
            this.cbAG.SelectedIndexChanged += new System.EventHandler(this.cbAG_SelectedIndexChanged);
            // 
            // lCMSOvrg
            // 
            this.lCMSOvrg.BackColor = System.Drawing.Color.PaleGreen;
            this.lCMSOvrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lCMSOvrg.Location = new System.Drawing.Point(655, 18);
            this.lCMSOvrg.Name = "lCMSOvrg";
            this.lCMSOvrg.Size = new System.Drawing.Size(117, 18);
            this.lCMSOvrg.TabIndex = 167;
            this.lCMSOvrg.Text = "VALID";
            this.lCMSOvrg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lCMSBad
            // 
            this.lCMSBad.BackColor = System.Drawing.Color.Salmon;
            this.lCMSBad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lCMSBad.Location = new System.Drawing.Point(496, 18);
            this.lCMSBad.Name = "lCMSBad";
            this.lCMSBad.Size = new System.Drawing.Size(159, 18);
            this.lCMSBad.TabIndex = 168;
            this.lCMSBad.Text = "INVALID   ( SN / STK-Code )";
            this.lCMSBad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Violet;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(772, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(157, 18);
            this.label1.TabIndex = 260;
            this.label1.Text = " STK-Code:  length error ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Order_SysPro_XML
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1270, 742);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lCMSOvrg);
            this.Controls.Add(this.lCMSBad);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TSmain);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Order_SysPro_XML";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "S/O  for SYSPRO ";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Order_SysPro_XML_Load);
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        

        private string Find_STKCODE(string desc)
        {
            string stSql = "select f2, f3,f4 from PSM_C_GConfig where F1_Code='serial' ",  F3= "",F4="",res="";
            bool found=false;
            int II=0;


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            stSql = "";
            
            while (Oreadr.Read() && !found)
            {
                if (desc.ToLower ().IndexOf(Oreadr["f2"].ToString().ToLower ()) > -1)
                {
                    F3 = Oreadr["f3"].ToString(); F4 = Oreadr["f4"].ToString();

                    switch (F3[0])
                    {
                        case '!':

                            break;
                        case '<':
                            II = Convert.ToInt32(F3.Substring(1, F3.Length - 1));
                            res = desc.Substring(0, II);
                            break;
                        case '+':
                            string key = F3.Substring(1, F3.Length - 1);
                             int i2 = desc.IndexOf(key);
                            
                            II = desc.IndexOf(" ",i2);
                           
                            res =(II>-1) ? desc.Substring(i2, II - i2 ) : F4 ; //  res = desc.Substring(i2, II - i2 - 1);
                            break;
                        default:
                            res = F3;
                            break;
                    }
                    found = true;
                }
            }

            if (!found)
            {

                int i3 = desc.IndexOf("["), i4 = desc.IndexOf("]");
                if ((i4 - i3) > 5) res = desc.Substring(i3, i4 - i3 + 1);
                else  res = (desc.Length <15 ) ? desc.Replace(" ", "-") :desc.Substring(0, 15).Replace(" ", "-") ;
                
            }

            OConn.Close();
            return res;
        }



        private void Load_ProjNm(string projID)
        {
            string stSql = " SELECT    PSM_R_Rev.IRRevID, PSM_R_Rev.RID, PSM_R_Rev.RRev_Name,PSM_R_Rev.Custm_PO,PSM_R_Rev.opendate,PSM_R_Rev.dateRRev,PSM_R_Rev.dateDlvr, PSM_COMPANY.Cpny_Name1, PSM_Q_IGen.Quote_ID, PSM_R_RevSys.R_sysName,  " +
                           "           PSM_R_RevSys.R_sysRnk, PSM_Q_Details.[Desc] as ItemDesc, PSM_Q_Details.Qty, PSM_Q_Details.Uprice, PSM_Q_Details.Ext, PSM_Q_Details.A_Ext, PSM_Q_Details.S_Ext, PSM_R_Detail.PrimaxSN, PSM_Q_Details.Q_tec_Val, PSM_Q_Details.Rnk, PSM_R_RevSys.R_GSTot, PSM_R_RevSys.R_PXTot as SysTOT_AG , PSM_R_RevSys.R_sysTot , PSM_R_Detail.Rdetail_LID, PSM_Q_IGen.curr, PSM_COMPANY.Syspro_Code, PSM_Q_Details.Xch_Mult, PSM_R_Rev.dateManufac " +
                           " FROM    PSM_R_Rev INNER JOIN PSM_R_Detail ON PSM_R_Rev.IRRevID = PSM_R_Detail.IRRev_LID INNER JOIN PSM_R_RevSys ON PSM_R_Detail.SysLID = PSM_R_RevSys.R_sysLID INNER JOIN " +
                           "         PSM_Q_Details ON PSM_R_Detail.Qdet_LID = PSM_Q_Details.Detail_LID INNER JOIN PSM_COMPANY ON PSM_R_Rev.cpnyID = PSM_COMPANY.Cpny_ID INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid " +
                           " WHERE     (PSM_R_Rev.IRRevID =" + projID + ") ORDER BY PSM_R_RevSys.R_sysRnk, PSM_Q_Details.Rnk ";
                
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            string grps = "?ABCD";
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            string ORev = "", NRev = "", OSys = "", NSys = "";
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvItems.Items.Clear();
            string newSYS = "", oldSYS = "",totSys;
            ListViewItem lvI = null;
            lCustomerID.Text = "";
            while (Oreadr.Read())
            {

                if (lCustomerID.Text == "") lCustomerID.Text = Oreadr["Syspro_Code"].ToString();
                string STK_Code = "";
                string sysNm = oldSYS ;
                newSYS = Oreadr["R_sysName"].ToString();
                lvI = ed_lvItems.Items.Add("");
                if (newSYS != oldSYS)
                {

                    sysNm = newSYS;
                    oldSYS = newSYS;
//#############
                    totSys = Oreadr["R_GSTot"].ToString()        ;//Oreadr["SysTOT_AG"].ToString(); ag_total
                    
//###################                   
                    lvI.BackColor = Color.PaleGreen;// Salmon;



                TestEQA TEA = new TestEQA(Oreadr["Q_tec_Val"].ToString());  // Oreadr["Q_tec_Val"].ToString()
                if (Oreadr["Q_tec_Val"].ToString().IndexOf("C_MODEL") > -1)
                {
                    STK_Code = TEA.look_Req_Value("C_MODEL", Oreadr["Q_tec_Val"].ToString(), 'C');
                }
                else 
                {
                    STK_Code = Find_STKCODE (Oreadr["ItemDesc"].ToString());
                   

                }
                if (STK_Code.Length > 3 && STK_Code.Length <23)
                {
                    if (Oreadr["PrimaxSN"].ToString().Length > 3) STK_Code += "_" + Oreadr["PrimaxSN"].ToString();
                    else STK_Code += "_G" + Oreadr["Rdetail_LID"].ToString();
                    
                    // lvI.BackColor = Color.Green ;
                }
                else
                {
                    Color tt = (STK_Code.Length <= 3 || STK_Code.Length >= 23) ? Color.Violet : Color.Salmon;
                    lvI.BackColor = tt;
                    send_XML.Enabled = false;
                }
          
      // if (STK_Code.Length > lvI.BackColor =(Oreadr["PrimaxSN"].ToString().Length > 5 && STK_Code.Length >2 ) ?  Color.Green : Color.Salmon ;

                lvI.Checked = (STK_Code != "");
                 
                }
                else
                {
                    sysNm = "--";
                    totSys = "";
                }
              
                lvI.SubItems.Add(sysNm );                         //1
                lvI.SubItems.Add(Oreadr["PrimaxSN"].ToString());  //2 
                lvI.SubItems.Add(Oreadr["ItemDesc"].ToString());
                lvI.SubItems.Add(Oreadr["Qty"].ToString());
                lvI.SubItems.Add(Oreadr["Uprice"].ToString());
                lvI.SubItems.Add(Oreadr["Ext"].ToString());
                lvI.SubItems.Add(totSys);
                lvI.SubItems.Add(Oreadr["IRRevID"].ToString());
                lvI.SubItems.Add(Oreadr["RRev_Name"].ToString());
                lvI.SubItems.Add(Oreadr["Cpny_Name1"].ToString());
                lvI.SubItems.Add(Oreadr["Quote_ID"].ToString());

                lvI.SubItems.Add(Oreadr["Custm_PO"].ToString());
                lvI.SubItems.Add(Oreadr["opendate"].ToString());
                lvI.SubItems.Add(Oreadr["dateRRev"].ToString());
                lvI.SubItems.Add(Oreadr["dateManufac"].ToString());// before was: 'dateDlvr'

            // add Revxx to RID as alternate-key in SYSPRO  07-12-2015 (agent_cms)
           //     lvI.SubItems.Add(Oreadr["RID"].ToString());  //old alternate-key
                string RevName = Oreadr["RRev_Name"].ToString().Replace("(", "").Replace(")", "").Replace("-", "");
                lvI.SubItems.Add(Oreadr["RID"].ToString()+"_"+RevName);
         // add Revxx to RID as alternate-key in SYSPRO  07-12-2015 (agent_cms)


                lvI.SubItems.Add(Oreadr["Q_tec_Val"].ToString());
                lvI.SubItems.Add(STK_Code);

                string st = "";
             //   if (Oreadr["PrimaxSN"].ToString() == "S6874") st = st;

                lvI.SubItems.Add(Oreadr["curr"].ToString());
         //       double dd =Math.Round ( Convert.ToDouble(Oreadr["R_sysTot"].ToString()) - Convert.ToDouble(Oreadr["R_GSTot"].ToString()),2); lvI.SubItems.Add(dd.ToString ());
        //        dd = Math.Round ( Convert.ToDouble(Oreadr["SysTOT_AG"].ToString()) - Convert.ToDouble(Oreadr["R_sysTot"].ToString()),2);   lvI.SubItems.Add(dd.ToString());

                double d_GSTot = Convert.ToDouble(Oreadr["R_GSTot"].ToString()); //px
               double d_TOT_AG= Convert.ToDouble(Oreadr["SysTOT_AG"].ToString());//sls
               double d_RsysTOT = Convert.ToDouble(Oreadr["R_sysTot"].ToString());//ag


        //       if ((d_TOT_AG * 2) >= d_RsysTOT) d_RsysTOT = d_TOT_AG;
         //     int rt=(int) (d_RsysTOT % d_TOT_AG);
           //      if (Math.Round(rt,0)==0) d_RsysTOT = d_TOT_AG;


               double dvsr = d_RsysTOT / d_TOT_AG;

               if (d_RsysTOT == (d_TOT_AG * dvsr )) d_RsysTOT = d_TOT_AG;
               double dd = Math.Round(d_TOT_AG - d_GSTot, 2); lvI.SubItems.Add(dd.ToString());
                      dd = Math.Round(d_RsysTOT - d_TOT_AG, 2); lvI.SubItems.Add(dd.ToString());

                lvI.SubItems.Add(grps[Int32.Parse(Oreadr["Xch_Mult"].ToString())].ToString());
      
               
            }



            OConn.Close();

        }

        private void maj_Qty()
        {
            string old_NB = "", old_EXT = "";
            for (int i = 0; i < ed_lvItems.Items.Count; i++)
            {
                if (ed_lvItems.Items[i].SubItems[3].Text == old_NB && ed_lvItems.Items[i].SubItems[6].Text == old_EXT && Tools.Conv_Dbl(ed_lvItems.Items[i].SubItems[7].Text) != 0)
                {
                    ed_lvItems.Items[i - 1].SubItems[3].Text = "1";
                    ed_lvItems.Items[i].SubItems[3].Text = "1";
                }
                old_NB = ed_lvItems.Items[i].SubItems[3].Text;
                old_EXT = ed_lvItems.Items[i].SubItems[6].Text;
            }


        }

        private void maj_TOTALS()
        {
            string old_NB = "", old_EXT = "";
            for (int i = 0; i < ed_lvItems.Items.Count; i++)
            {
                if (ed_lvItems.Items[i].SubItems[3].Text == old_NB && ed_lvItems.Items[i].SubItems[6].Text == old_EXT && Tools.Conv_Dbl(ed_lvItems.Items[i].SubItems[7].Text) != 0)
                {
                    ed_lvItems.Items[i - 1].SubItems[3].Text = "1";
                    ed_lvItems.Items[i].SubItems[3].Text = "1";
                }
                old_NB = ed_lvItems.Items[i].SubItems[3].Text;
                old_EXT = ed_lvItems.Items[i].SubItems[6].Text;
            }


        }
	
		

        private void ed_lvItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Order_SysPro_XML_Load(object sender, EventArgs e)
        {
            lIRREV.Visible = (MainMDI.User.ToLower() == "ede");
            lIRREV.Text = in_irevLID;
            Load_orderXML();
            fill_cbAGent_SYSPRO("C");
            load_lastAGmail();
            chkSendAG.Checked = true;
        }

        void load_lastAGmail()
        {


            string stSql = " SELECT        PSM_Q_WConfig.WFLID, PSM_Q_WConfig.IQID, PSM_Q_WConfig.Sol_LID, PSM_Q_WConfig.tsubmit, PSM_Q_WConfig.tCompl, PSM_Q_WConfig.[TComp-Fname], PSM_Q_WConfig.TbatCmnt, PSM_Q_WConfig.dateSOL, PSM_Q_WConfig.othertxt, PSM_Q_WConfig.agent, PSM_Q_WConfig.chkAG " +
                           " FROM            PSM_R_Rev INNER JOIN PSM_Q_WConfig ON PSM_R_Rev.iQID = PSM_Q_WConfig.IQID " +
                           " WHERE        PSM_R_Rev.IRRevID =" + in_irevLID;

	
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ()) 
			{

                cbAG.Text = Oreadr["agent"].ToString();
                if (Oreadr["agent"].ToString().Length >4) load_AGemail(); //lAG_CodeName.Text = (cbAG.Text.Length > 3) ? cbAG.Text.Substring(0, 3) : "";
               

			}
			OConn.Close(); 
			
	
        }

        void Load_orderXML()
        {

                Load_ProjNm(in_irevLID);
                btnSave.Visible = true;
                btnskip.Visible = true;
                Qty_repr.Visible = (MainMDI.User.ToLower() == "ede");
                toolStripButton1.Visible = (MainMDI.User.ToLower() == "ede");

        }
        private void fill_cbAGent_SYSPRO(string branch)
        {
            string stSql = "SELECT distinct Salesperson, Name FROM  dbo.SalSalesperson where SUBSTRING (Salesperson,1,1)='A' and Branch ='" + branch + "1' order by Name ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon_PL_SYSPRO);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                stSql = Oreadr["Salesperson"].ToString() + " - " + Oreadr["Name"].ToString();// no last name for agency.....  // +" " + Oreadr[1].ToString();
                cbAG.Items.Add(stSql);

            }
            OConn.Close();


        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
        bool valid_email(string email)
        {
            if (email.Length < 3) return false;
            if (email.IndexOf("@") > -1 && email.IndexOf(".") > -1) return true;
            else return false;


        }
        private void send_XML_Click(object sender, EventArgs e)
        {

            OKsend_XML();
            //if (chkSendAG.Checked)
            //{
            //    if (valid_email(lAG_email.Text))     OKsend_XML();
            // //   else MessageBox.Show("Agency email is Invalid.............");
            //}
            //else
            //{
            //    OKsend_XML();

            //}

        }
        //void email_AGENCIES()
        //{

        //    string TXT = "Primax has sent the following proposal: \n",
        //           _subject = "PRIMAX Quotation";
        //    double TOTAG = 0;
        //    TXT += "\n" + "Quote#: " + AffQNB.Text;
        //    TXT += "\n" + "Customer: " + cbCompanyy.Text;
        //    TXT += "\n" + "Contact Name: " + cbContacts.Text;
        //    TXT += "\n" + "Phone #: " + lPhone.Text;

        //    TXT += "\n\nInside sale: " + cbEmploy.Text + "\nTel: +514-459-9990 ex.:" + lEExt.Text + "\nEmail: " + lemail.Text;
        //    TXT += "\n\n" + "Outside sale: " + lSP_Name.Text + "\nCell#: " + lOutSaleCell.Text + "\nEmail: " + lOutSaleemail.Text;

        //    TXT += "\n\n" + "Quote consists of: ";
        //    int cnt = 1;
        //    for (int i = 0; i < FC.lvPTC.Items.Count; i++)
        //    {
        //        if (FC.lvPTC.Items[i].SubItems[7].Text == "S")
        //        {
        //            TXT += "\n" + (cnt++).ToString() + " - " + FC.lvPTC.Items[i + 1].SubItems[0].Text.TrimStart();// +"  $" + FC.lvPTC.Items[i].SubItems[6].Text.TrimStart(); 
        //            TOTAG += Tools.Conv_Dbl(FC.lvPTC.Items[i].SubItems[6].Text.TrimStart().Replace(" ", ""));
        //        }

        //    }
        //    // string TOT = "0";// FC.lvPTC.Items[i].SubItems[6].Text.TrimStart();
        //    TXT += "\n" + "TOTAL: " + "$" + TOTAG.ToString();
        //    TXT += "\n\n\n\n" + "Best regards";
        //    Outlook_email(FC.lAG_email.Text, _subject, TXT);




        //}
        void OKsend_XML()
        {

            this.Cursor = Cursors.WaitCursor;
            send_XMLFILE(in_irevLID, in_RID);
            this.Cursor = Cursors.Default;
            MainMDI.send_email("PGC_SYSYPRO_XML@primax-e.com", "hedebbab@primax-e.com", "XML sent TO SYSPRO by: " + MainMDI.User, "XML sent TO SYSPRO by: " + MainMDI.User + "  irRelID=" + in_irevLID + "   RID= " + in_RID);
            if (chkSendAG.Checked &&  valid_email(lAG_email.Text) ) email_AGENCIES();
            
            MessageBox.Show("     Sending DONE  .......................");
        }

        void email_AGENCIES()
        {

            string res = MainMDI.Find_One_Field(" SELECT PSM_Q_IGen.AGmail  FROM [Orig_PSM_FDB].[dbo].[PSM_R_Rev] inner join [dbo].[PSM_Q_IGen] on PSM_R_Rev.[iQID]=PSM_Q_IGen.i_Quoteid " +
                                                " where  PSM_R_Rev.IRRevID="+in_irevLID );
            if (res.Length > 10)
            {

                string G_TXT = "Primax just booked the following job: \n",
                       _subject = "PRIMAX Orders";
                double TOTAG = 0;

                string TXT = G_TXT + "\n" + "Project#: " + in_RID.Substring (0,5) + "\n";
                TXT += res.Replace("~~","\n");
             //   TXT += "\n" + "TOTAL: " + "$" + TOTAG.ToString();
                TXT += "\n\n\n\n" + "Best regards";
                                       //  MainMDI.Exec_SQL_JFS("update  [PSM_Q_IGen] set [AGmail]='" + SavTXT + "' where i_Quoteid=" + lCurrIQID.Text, " save TXT AGency Mail....");
                Outlook_email(lAG_email.Text, _subject, TXT);
            }
        }

        void Outlook_email(string TO, string Subject, string txt)
        {

            try
            {
                List<string> lstAllRecipients = new List<string>();
                //Below is hardcoded - can be replaced with db data
                lstAllRecipients.Add(TO);
                // lstAllRecipients.Add("chandan.kumarpanda@testmail.com");

                Outlook.Application outlookApp = new Outlook.Application();
                Outlook._MailItem oMailItem = (Outlook._MailItem)outlookApp.CreateItem(Outlook.OlItemType.olMailItem);
                Outlook.Inspector oInspector = oMailItem.GetInspector;
                // Thread.Sleep(10000);

                // Recipient
                Outlook.Recipients oRecips = (Outlook.Recipients)oMailItem.Recipients;
                foreach (String recipient in lstAllRecipients)
                {
                    Outlook.Recipient oRecip = (Outlook.Recipient)oRecips.Add(recipient);
                    oRecip.Resolve();
                }

                //Add CC
                //      Outlook.Recipient oCCRecip = oRecips.Add("THIYAGARAJAN.DURAIRAJAN@testmail.com");
                //      oCCRecip.Type = (int)Outlook.OlMailRecipientType.olCC;
                //       oCCRecip.Resolve();

                //Add Subject
                oMailItem.Subject = Subject;
                oMailItem.Body = txt;

                // body, bcc etc...

                //Display the mailbox
                oMailItem.Display(true);
            }
            catch (Exception objEx)
            {
                MessageBox.Show("Outlook ERROR: " + objEx.ToString());
            }

        }



        private void send_XMLFILE(string _IRRevID,string _RID)
        {

          //  string _RevNm = MainMDI.Find_One_Field("select RRev_Name from PSM_R_Rev where IRRevID=" + _IRRevID);
            if (_RID != MainMDI.VIDE  || lCustomerID.Text !="" )
            {
     //     string filename = @"c:\SYSPRO_XML\PSM_" + _RID.Replace (" ","_") + ".xml"; // + DateTime.Now.Day;
           string filename = @"\\Erpserver\syspro61\DFM\CompanyP\Sales Orders\Polling\PSM_" + _RID.Replace(" ", "_") + ".xml"; // + DateTime.Now.Day;
                System.IO.File.Delete(filename);
                XML_SPdata mySPdata = new XML_SPdata(_IRRevID, filename,ed_lvItems ,lCustomerID.Text  );
                mySPdata.my_WriteXML_byPROJECT();
    //            string fdesti=@"\\NTSERVER2\Common_Big_Files\SYSPRO_XMLlogs\" +DateTime.Now.ToString ().Replace (":","-").Replace ("/","-") +"__" + "PSM_" + _RID.Replace(" ", "_") + ".xml";
                string fdesti = @"\\NTSERVER\Common\SYSPRO_XMLlogs\" + DateTime.Now.ToString().Replace(":", "-").Replace("/", "-") + "__" + "PSM_" + _RID.Replace(" ", "_") + ".xml";
                System.IO.File.Copy (filename ,fdesti ); // + DateTime.Now.Day;
            }
            else MessageBox.Show("Sorry can not send XML file (bad REVISION Name)........."); 
        }


        private void SAVE_XMLFILE(string _IRRevID, string _RID)
        {

            //  string _RevNm = MainMDI.Find_One_Field("select RRev_Name from PSM_R_Rev where IRRevID=" + _IRRevID);
            if (_RID != MainMDI.VIDE || lCustomerID.Text != "")
            {
                   string filename = @"c:\SYSPRO_XML\PSM_" + _RID.Replace (" ","_") + ".xml"; // + DateTime.Now.Day;
            //    string filename = @"\\Erpserver\syspro61\DFM\CompanyP\Sales Orders\Polling\PSM_" + _RID.Replace(" ", "_") + ".xml"; // + DateTime.Now.Day;
                System.IO.File.Delete(filename);
                XML_SPdata mySPdata = new XML_SPdata(_IRRevID, filename, ed_lvItems, lCustomerID.Text);
                mySPdata.my_WriteXML_byPROJECT();
            }
            else MessageBox.Show("Sorry can not send XML file (bad REVISION Name).........");
        }
        


        class XML_SPdata
        {
            Lib1 Tools = new Lib1();
            string in_XMLFname = "", in_IRrevLID = "",in_lCustomerID;
            ed_LVmodif in_ed_lvItems = null;
            XmlDocument xmlDoc = null;
            private int MAX_XML_len30 = 28, MAX_XML_len45 = 43;

            public XML_SPdata(string X_IrevLID, string X_filename, ed_LVmodif x_ed_lvItems,string x_lCustomerID)
            {
                in_XMLFname = X_filename;
                in_IRrevLID = X_IrevLID;
                in_ed_lvItems = x_ed_lvItems;
                in_lCustomerID = x_lCustomerID;

            }



            private void Fill_MiscChrg_Line_OLD(ref XmlElement OrderDetail_node, string _Desc_item,string _Ext,ref int POline, ref int _CurrPOLine)  //sent with negative value -39
            {
                string[] my_arr_TXT = new string[10];

                _CurrPOLine = POline;

                XmlElement StkLine_node = xmlDoc.CreateElement("MiscChargeLine");
                OrderDetail_node.AppendChild(StkLine_node);

                XmlElement POline_node = xmlDoc.CreateElement("CustomerPoLine");
                XmlText xTXT = xmlDoc.CreateTextNode(POline.ToString()); POline++;
                POline_node.AppendChild(xTXT);
                StkLine_node.AppendChild(POline_node);

                XmlElement LA_node = xmlDoc.CreateElement("LineActionType");
                xTXT = xmlDoc.CreateTextNode("A");
                LA_node.AppendChild(xTXT);
                StkLine_node.AppendChild(LA_node);

                XmlElement MiscChargeValue_node = xmlDoc.CreateElement("MiscChargeValue");
                xTXT = xmlDoc.CreateTextNode(_Ext );
                MiscChargeValue_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscChargeValue_node);

                XmlElement MiscChargeCost_node = xmlDoc.CreateElement("MiscChargeCost");
                xTXT = xmlDoc.CreateTextNode("0.00");
                MiscChargeCost_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscChargeCost_node);



                XmlElement MiscQuantity_node = xmlDoc.CreateElement("MiscQuantity");
                xTXT = xmlDoc.CreateTextNode("1");
                MiscQuantity_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscQuantity_node);


                XmlElement MiscProductClass_node = xmlDoc.CreateElement("MiscProductClass");
               // xTXT = xmlDoc.CreateTextNode("_OTH");  req. by stephano  12/04/2011
                xTXT = xmlDoc.CreateTextNode("_DIS");
                MiscProductClass_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscProductClass_node);


                XmlElement MiscTaxCode_node = xmlDoc.CreateElement("MiscTaxCode");
                xTXT = xmlDoc.CreateTextNode("A");
                MiscTaxCode_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscTaxCode_node);


                XmlElement MiscFstCode_node = xmlDoc.CreateElement("MiscFstCode");
                xTXT = xmlDoc.CreateTextNode("B");
                MiscFstCode_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscFstCode_node);





                split_Desc(_Desc_item, MAX_XML_len30 , ref my_arr_TXT);
                //   ####### remainig text must be splited by 45 not 30

                XmlElement MiscDescription_node = xmlDoc.CreateElement("MiscDescription");
                XmlCDataSection myCdata = xmlDoc.CreateCDataSection(my_arr_TXT[0]);
                MiscDescription_node.AppendChild(myCdata);
                StkLine_node.AppendChild(MiscDescription_node);

                //suite du descr >30 as comnt
                //####### remainig text must be splited by 45 not 30    (45 will be 43 and 30 will be 28 ===> since adding ~~ and ~!
                split_Desc(_Desc_item.Substring(my_arr_TXT[0].Length, _Desc_item.Length - my_arr_TXT[0].Length), MAX_XML_len45, ref my_arr_TXT);
                int s = 0;
                while (my_arr_TXT[s] != "")
                {
                    Fill_Comments(ref OrderDetail_node, my_arr_TXT[s++], ref POline, _CurrPOLine);

                }

            }


            private void Fill_MiscChrg_Line(ref XmlElement OrderDetail_node, string _Desc_item, string _Ext, ref int POline, ref int _CurrPOLine,bool isStkLine)
            {
                string[] my_arr_TXT = new string[50];

                _CurrPOLine = POline;

                XmlElement StkLine_node = xmlDoc.CreateElement("MiscChargeLine");
                OrderDetail_node.AppendChild(StkLine_node);

                XmlElement POline_node = xmlDoc.CreateElement("CustomerPoLine");
                XmlText xTXT = xmlDoc.CreateTextNode(POline.ToString()); POline++;
                POline_node.AppendChild(xTXT);
                StkLine_node.AppendChild(POline_node);

                XmlElement LA_node = xmlDoc.CreateElement("LineActionType");
                xTXT = xmlDoc.CreateTextNode("A");
                LA_node.AppendChild(xTXT);
                StkLine_node.AppendChild(LA_node);

                XmlElement MiscChargeValue_node = xmlDoc.CreateElement("MiscChargeValue");

                //modified 22/03/2012

                if (isStkLine )  xTXT = xmlDoc.CreateTextNode(_Ext);
                else xTXT = xmlDoc.CreateTextNode("0.00");      
 
                //modified 22/03/2012

                MiscChargeValue_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscChargeValue_node);

                XmlElement MiscChargeCost_node = xmlDoc.CreateElement("MiscChargeCost");
                xTXT = xmlDoc.CreateTextNode("0.00");
                MiscChargeCost_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscChargeCost_node);



                XmlElement MiscQuantity_node = xmlDoc.CreateElement("MiscQuantity");
                xTXT = xmlDoc.CreateTextNode("1");
                MiscQuantity_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscQuantity_node);


                XmlElement MiscProductClass_node = xmlDoc.CreateElement("MiscProductClass");
                // xTXT = xmlDoc.CreateTextNode("_OTH");  req. by stephano  12/04/2011
                xTXT = xmlDoc.CreateTextNode("_DIS");
                MiscProductClass_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscProductClass_node);


                XmlElement MiscTaxCode_node = xmlDoc.CreateElement("MiscTaxCode");
                xTXT = xmlDoc.CreateTextNode("A");
                MiscTaxCode_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscTaxCode_node);


                XmlElement MiscFstCode_node = xmlDoc.CreateElement("MiscFstCode");
                xTXT = xmlDoc.CreateTextNode("B");
                MiscFstCode_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscFstCode_node);

                
                if (!isStkLine ) _Desc_item += "  (" + _Ext + ") "; //added 22/03/2012

                split_Desc(_Desc_item, MAX_XML_len30, ref my_arr_TXT);
                //   ####### remainig text must be splited by 45 not 30

                XmlElement MiscDescription_node = xmlDoc.CreateElement("MiscDescription");
                XmlCDataSection myCdata = xmlDoc.CreateCDataSection(my_arr_TXT[0]);
                MiscDescription_node.AppendChild(myCdata);
                StkLine_node.AppendChild(MiscDescription_node);

                //suite du descr >30 as comnt
                //####### remainig text must be splited by 45 not 30    (45 will be 43 and 30 will be 28 ===> since adding ~~ and ~!
                split_Desc(_Desc_item.Substring(my_arr_TXT[0].Length, _Desc_item.Length - my_arr_TXT[0].Length), MAX_XML_len45, ref my_arr_TXT);
                int s = 0;
                while (my_arr_TXT[s] != "")
                {
                    Fill_Comments(ref OrderDetail_node, my_arr_TXT[s++], ref POline, _CurrPOLine);

                }

            }


            private void Fill_OVRG_Line(ref XmlElement OrderDetail_node, string _Desc_item, string _Ext, ref int POline, ref int _CurrPOLine,string OVGCode)
            {
                string[] my_arr_TXT = new string[50];

                _CurrPOLine = POline;

                XmlElement StkLine_node = xmlDoc.CreateElement("MiscChargeLine");
                OrderDetail_node.AppendChild(StkLine_node);

                XmlElement POline_node = xmlDoc.CreateElement("CustomerPoLine");
                XmlText xTXT = xmlDoc.CreateTextNode(POline.ToString()); POline++;
                POline_node.AppendChild(xTXT);
                StkLine_node.AppendChild(POline_node);

                XmlElement LA_node = xmlDoc.CreateElement("LineActionType");
                xTXT = xmlDoc.CreateTextNode("A");
                LA_node.AppendChild(xTXT);
                StkLine_node.AppendChild(LA_node);

                XmlElement MiscChargeValue_node = xmlDoc.CreateElement("MiscChargeValue");
                xTXT = xmlDoc.CreateTextNode(_Ext);
                MiscChargeValue_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscChargeValue_node);

                XmlElement MiscChargeCost_node = xmlDoc.CreateElement("MiscChargeCost");
                xTXT = xmlDoc.CreateTextNode("0.00");
                MiscChargeCost_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscChargeCost_node);



                XmlElement MiscQuantity_node = xmlDoc.CreateElement("MiscQuantity");
                xTXT = xmlDoc.CreateTextNode("1");
                MiscQuantity_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscQuantity_node);


                XmlElement MiscProductClass_node = xmlDoc.CreateElement("MiscProductClass");
                // xTXT = xmlDoc.CreateTextNode("_OTH");  req. by stephano  12/04/2011
                xTXT = xmlDoc.CreateTextNode("PRIM");
                MiscProductClass_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscProductClass_node);


                XmlElement MiscTaxCode_node = xmlDoc.CreateElement("MiscTaxCode");
                xTXT = xmlDoc.CreateTextNode("A");
                MiscTaxCode_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscTaxCode_node);


                XmlElement MiscFstCode_node = xmlDoc.CreateElement("MiscFstCode");
                xTXT = xmlDoc.CreateTextNode("B");
                MiscFstCode_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscFstCode_node);


                split_Desc(_Desc_item, MAX_XML_len30, ref my_arr_TXT);
                //   ####### remainig text must be splited by 45 not 30

                XmlElement MiscDescription_node = xmlDoc.CreateElement("MiscDescription");
                XmlCDataSection myCdata = xmlDoc.CreateCDataSection(my_arr_TXT[0]);
                MiscDescription_node.AppendChild(myCdata);
                StkLine_node.AppendChild(MiscDescription_node);

                //suite du descr >30 as comnt
                //####### remainig text must be splited by 45 not 30    (45 will be 43 and 30 will be 28 ===> since adding ~~ and ~!
                split_Desc(_Desc_item.Substring(my_arr_TXT[0].Length, _Desc_item.Length - my_arr_TXT[0].Length), MAX_XML_len45, ref my_arr_TXT);
                int s = 0;
                while (my_arr_TXT[s] != "")
                {
                    Fill_Comments(ref OrderDetail_node, my_arr_TXT[s++], ref POline, _CurrPOLine);

                }



                XmlElement MiscChargeCode_node = xmlDoc.CreateElement("MiscChargeCode");
                xTXT = xmlDoc.CreateTextNode(OVGCode );
                MiscChargeCode_node.AppendChild(xTXT);
                StkLine_node.AppendChild(MiscChargeCode_node);


            }






            private void Fill_Comments(ref XmlElement OrderDetail_node, string Desc_CMNT, ref int POline, int _CurrPOline)
            {

                XmlElement ComntLine_node = xmlDoc.CreateElement("CommentLine");
                OrderDetail_node.AppendChild(ComntLine_node);

                XmlElement POline_node = xmlDoc.CreateElement("CustomerPoLine");
                XmlText xTXT = xmlDoc.CreateTextNode(POline.ToString()); POline++;
                POline_node.AppendChild(xTXT);
                ComntLine_node.AppendChild(POline_node);

                XmlElement LA_node = xmlDoc.CreateElement("LineActionType");
                xTXT = xmlDoc.CreateTextNode("A");
                LA_node.AppendChild(xTXT);
                ComntLine_node.AppendChild(LA_node);

                XmlElement Cmnt_node = xmlDoc.CreateElement("Comment");
                XmlCDataSection myCdata2 = xmlDoc.CreateCDataSection(Desc_CMNT);
                Cmnt_node.AppendChild(myCdata2);
                ComntLine_node.AppendChild(Cmnt_node);

                XmlElement AttLine_node = xmlDoc.CreateElement("AttachedLineNumber");
                //  xTXT = xmlDoc.CreateTextNode("1");
                xTXT = xmlDoc.CreateTextNode(_CurrPOline.ToString());
                AttLine_node.AppendChild(xTXT);
                ComntLine_node.AppendChild(AttLine_node);
            }

            private void Fill_Stk_Line(ref XmlElement OrderDetail_node, string _StockCode, string _Desc_item, string _Qty, string _Ext, string stkln_status, ref int POline, ref int _CurrPOLine, string _CustReqDate, string _UserDefined)
            {
                string[] my_arr_TXT = new string[50];

                _CurrPOLine = POline;

                XmlElement StkLine_node = xmlDoc.CreateElement("StockLine");
                OrderDetail_node.AppendChild(StkLine_node);

                XmlElement POline_node = xmlDoc.CreateElement("CustomerPoLine");
                XmlText xTXT = xmlDoc.CreateTextNode(POline.ToString()); POline++;
                POline_node.AppendChild(xTXT);
                StkLine_node.AppendChild(POline_node);

                XmlElement LA_node = xmlDoc.CreateElement("LineActionType");
                xTXT = xmlDoc.CreateTextNode("A");
                LA_node.AppendChild(xTXT);
                StkLine_node.AppendChild(LA_node);

                XmlElement StkCode_node = xmlDoc.CreateElement("StockCode");
                //    xTXT = xmlDoc.CreateTextNode(Oreadr["Desc_item"].ToString());  //??????
                xTXT = xmlDoc.CreateTextNode(_StockCode );
                StkCode_node.AppendChild(xTXT);
                StkLine_node.AppendChild(StkCode_node);


                //     xTXT = xmlDoc.CreateTextNode(Oreadr["Desc_item"].ToString());
                //     StkDesc_node.AppendChild(xTXT);
                //     if (Oreadr["Desc_item"].ToString().Length > 30)

                split_Desc(_Desc_item, MAX_XML_len30 , ref my_arr_TXT);
                //   ####### remainig text must be splited by 45 not 30
                //   split_Desc(Oreadr["Desc_item"].ToString().Substring(arr_TXT[0].Length), 45, ref arr_TXT);

                XmlElement StkDesc_node = xmlDoc.CreateElement("StockDescription");
                XmlCDataSection myCdata = xmlDoc.CreateCDataSection(my_arr_TXT[0]);
                StkDesc_node.AppendChild(myCdata);
                StkLine_node.AppendChild(StkDesc_node);



                XmlElement Qty_node = xmlDoc.CreateElement("OrderQty");
                xTXT = xmlDoc.CreateTextNode(_Qty);
                Qty_node.AppendChild(xTXT);
                StkLine_node.AppendChild(Qty_node);

                XmlElement Or_Uom_node = xmlDoc.CreateElement("OrderUom");
                xTXT = xmlDoc.CreateTextNode("EA");
                Or_Uom_node.AppendChild(xTXT);
                StkLine_node.AppendChild(Or_Uom_node);


                 // Unit Price
                double _UP = Math.Round ( Tools.Conv_Dbl(_Ext ) / Tools.Conv_Dbl(_Qty),4);
                // Unit Price
                XmlElement Price_node = xmlDoc.CreateElement("Price");
                xTXT = xmlDoc.CreateTextNode(_UP.ToString ());
                Price_node.AppendChild(xTXT);
                StkLine_node.AppendChild(Price_node);

                XmlElement Prc_Uom_node = xmlDoc.CreateElement("PriceUom");
                xTXT = xmlDoc.CreateTextNode("EA");
                Prc_Uom_node.AppendChild(xTXT);
                StkLine_node.AppendChild(Prc_Uom_node);

                XmlElement NS_status_node = xmlDoc.CreateElement("NonStockedLine");
                xTXT = xmlDoc.CreateTextNode(stkln_status);
                NS_status_node.AppendChild(xTXT);
                StkLine_node.AppendChild(NS_status_node);

                XmlElement NsProd_class_node = xmlDoc.CreateElement("NsProductClass");
                xTXT = xmlDoc.CreateTextNode("NS");
                NsProd_class_node.AppendChild(xTXT);
                StkLine_node.AppendChild(NsProd_class_node);

                XmlElement CustRequestDate_node = xmlDoc.CreateElement("CustRequestDate");
                xTXT = xmlDoc.CreateTextNode(MainMDI.Eng_date(_CustReqDate, "-"));
                CustRequestDate_node.AppendChild(xTXT);
                StkLine_node.AppendChild(CustRequestDate_node);

                XmlElement UserDefined_node = xmlDoc.CreateElement("UserDefined");
                xTXT = xmlDoc.CreateTextNode(_UserDefined);
                UserDefined_node.AppendChild(xTXT);
                StkLine_node.AppendChild(UserDefined_node);

                if (_Desc_item.Length > MAX_XML_len30 )
                {
                    //suite du descr >30 as comnt
                    //####### remainig text must be splited by 45 not 30
                 //   split_Desc(_Desc_item.Substring(my_arr_TXT[0].Length - 2, _Desc_item.Length - my_arr_TXT[0].Length), , ref my_arr_TXT);
                    int s = 1;
                    while (my_arr_TXT[s] != "")
                    {
                        Fill_Comments(ref OrderDetail_node, my_arr_TXT[s++], ref POline, _CurrPOLine);

                    }
                }

            }



            private void Fill_Stk_Line_OVRG(ref XmlElement OrderDetail_node, string _StockCode, string _Desc_item, string _Qty, string _Ext, string stkln_status, ref int POline, ref int _CurrPOLine, string _CustReqDate,string OVGTYPE)
            {
                string[] my_arr_TXT = new string[50];

                _CurrPOLine = POline;

                XmlElement StkLine_node = xmlDoc.CreateElement("StockLine");
                OrderDetail_node.AppendChild(StkLine_node);

                XmlElement POline_node = xmlDoc.CreateElement("CustomerPoLine");
                XmlText xTXT = xmlDoc.CreateTextNode(POline.ToString()); POline++;
                POline_node.AppendChild(xTXT);
                StkLine_node.AppendChild(POline_node);

                XmlElement LA_node = xmlDoc.CreateElement("LineActionType");
                xTXT = xmlDoc.CreateTextNode("A");
                LA_node.AppendChild(xTXT);
                StkLine_node.AppendChild(LA_node);

                XmlElement StkCode_node = xmlDoc.CreateElement("StockCode");
                xTXT = xmlDoc.CreateTextNode(_StockCode);
                StkCode_node.AppendChild(xTXT);
                StkLine_node.AppendChild(StkCode_node);



                split_Desc(_Desc_item, MAX_XML_len30, ref my_arr_TXT);

                XmlElement StkDesc_node = xmlDoc.CreateElement("StockDescription");
                XmlCDataSection myCdata = xmlDoc.CreateCDataSection(my_arr_TXT[0]);
                StkDesc_node.AppendChild(myCdata);
                StkLine_node.AppendChild(StkDesc_node);



                XmlElement Qty_node = xmlDoc.CreateElement("OrderQty");
                xTXT = xmlDoc.CreateTextNode(_Qty);
                Qty_node.AppendChild(xTXT);
                StkLine_node.AppendChild(Qty_node);

                XmlElement Or_Uom_node = xmlDoc.CreateElement("OrderUom");
                xTXT = xmlDoc.CreateTextNode("EA");
                Or_Uom_node.AppendChild(xTXT);
                StkLine_node.AppendChild(Or_Uom_node);

                XmlElement Price_node = xmlDoc.CreateElement("Price");
                xTXT = xmlDoc.CreateTextNode(_Ext);
                Price_node.AppendChild(xTXT);
                StkLine_node.AppendChild(Price_node);

                XmlElement Prc_Uom_node = xmlDoc.CreateElement("PriceUom");
                xTXT = xmlDoc.CreateTextNode("EA");
                Prc_Uom_node.AppendChild(xTXT);
                StkLine_node.AppendChild(Prc_Uom_node);

                XmlElement NS_status_node = xmlDoc.CreateElement("NonStockedLine");
                xTXT = xmlDoc.CreateTextNode(stkln_status);
                NS_status_node.AppendChild(xTXT);
                StkLine_node.AppendChild(NS_status_node);

                XmlElement NsProd_class_node = xmlDoc.CreateElement("NsProductClass");
                xTXT = xmlDoc.CreateTextNode(OVGTYPE);
                NsProd_class_node.AppendChild(xTXT);
                StkLine_node.AppendChild(NsProd_class_node);

                XmlElement CustRequestDate_node = xmlDoc.CreateElement("CustRequestDate");
                xTXT = xmlDoc.CreateTextNode(MainMDI.Eng_date(_CustReqDate, "-"));
                CustRequestDate_node.AppendChild(xTXT);
                StkLine_node.AppendChild(CustRequestDate_node);

                if (_Desc_item.Length > MAX_XML_len30)
                {

                    int s = 1;
                    while (my_arr_TXT[s] != "")
                    {
                        Fill_Comments(ref OrderDetail_node, my_arr_TXT[s++], ref POline, _CurrPOLine);

                    }
                }

            }






            private string[] split_Desc(string _desc, int MAXLen, ref string[] arr_sub_desc)
            {
                //   string[] arr_sub_desc = new string[10];


                int s = 0, pos = -1;
                for (int i = 0; i < 50; i++) arr_sub_desc[i] = "";

                while (_desc.Length > MAXLen)
                {
                    if (_desc[MAXLen - 1] == ',' || _desc[MAXLen - 1] == ' ') pos = MAXLen - 1;
                    {
                        int ipos = _desc.LastIndexOf(' ', MAXLen);
                        int ipos_vrgl = _desc.LastIndexOf(',', MAXLen);

                        if (ipos > 10) pos = ipos;
                        else pos = (ipos_vrgl > 10) ? ipos_vrgl : MAXLen;
                    }

                   

                    arr_sub_desc[s++] = _desc.Substring(0, pos);
                    _desc = _desc.Substring(pos + 1, _desc.Length - pos - 1);

                }

                if (_desc.Length <= MAXLen)
                {
                    arr_sub_desc[s++] = _desc;
                    _desc = "";

                }
                if (arr_sub_desc[0] != "" && s>1)
                {
                    arr_sub_desc[0] += "~~";
                    arr_sub_desc[s - 1] += "~!";
                }
                return arr_sub_desc;

            }

            private string get_TVA(string TVA)
            {
                string Res_Tva = "";
                TestEQA TEA = new TestEQA(TVA);


                string stSql = " Select * from PSM_SP_TVA where actif=1";
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {

                    string st = TEA.look_Req_Value(Oreadr["VCS_Name"].ToString(), TVA, 'C');
                    Res_Tva += (st != "???") ? " || " + Oreadr["VCS_Txt"].ToString() + "=" + st : "";


                }

                OConn.Close();

                return Res_Tva;
            }




            // reste "P4500F-1-48-20" comme StockCode a reparer !!!!  21/10/2010
            public void my_WriteXML_byPROJECT()
            {
                bool QID_sent = false;
                string[] arr_TXT = new string[50];
                int CurrPOLine = 1;


                try
                {
                    //pick whatever filename with .xml extension

                    xmlDoc = new XmlDocument();

                    try
                    {
                        xmlDoc.Load(in_XMLFname);
                    }
                    catch (System.IO.FileNotFoundException)
                    {
                        //if file is not found, create a new xml file
                        XmlTextWriter xmlWriter = new XmlTextWriter(in_XMLFname, System.Text.Encoding.UTF8);
                        xmlWriter.Formatting = Formatting.Indented;
                        xmlWriter.WriteProcessingInstruction("xml", "version='1.0' encoding='Windows-1252'");
                        xmlWriter.WriteStartElement("SalesOrders");
                        //If WriteProcessingInstruction is used as above,
                        //Do not use WriteEndElement() here
                        //xmlWriter.WriteEndElement();
                        //it will cause the <Root></Root> to be <Root />
                        xmlWriter.Close();
                        xmlDoc.Load(in_XMLFname);
                    }

                    XmlText xTXT;

                    XmlNode root = xmlDoc.DocumentElement;
                    XmlElement T_HDR_node = xmlDoc.CreateElement("TransmissionHeader");
                    root.AppendChild(T_HDR_node);


                    XmlElement childNode1 = xmlDoc.CreateElement("TransmissionReference");
                    xTXT = xmlDoc.CreateTextNode("00000000000003");
                    childNode1.AppendChild(xTXT);
                    T_HDR_node.AppendChild(childNode1);

                    XmlElement childNode2 = xmlDoc.CreateElement("ReceiverCode");
                    xTXT = xmlDoc.CreateTextNode("HO");
                    childNode2.AppendChild(xTXT);
                    T_HDR_node.AppendChild(childNode2);

                    XmlElement childNode3 = xmlDoc.CreateElement("DatePrepared");
                    xTXT = xmlDoc.CreateTextNode(MainMDI.Eng_date(DateTime.Now.ToShortDateString(), "-"));
                    childNode3.AppendChild(xTXT);
                    T_HDR_node.AppendChild(childNode3);

                    XmlElement childNode4 = xmlDoc.CreateElement("TimePrepared");
                    xTXT = xmlDoc.CreateTextNode(DateTime.Now.ToShortTimeString());
                    childNode4.AppendChild(xTXT);
                    T_HDR_node.AppendChild(childNode4);
                    bool deb = true, O_AGENT = false, O_PRIMAX = false; 
                    XmlElement Order_node = xmlDoc.CreateElement("Orders");
                    XmlElement O_HDR_node = xmlDoc.CreateElement("OrderHeader");
                    XmlElement OrderDetail_node = xmlDoc.CreateElement("OrderDetails");
                    int POline = 0; 
                    string PX_Model = "", pPX18="", pPX20="",pPX15="",   pAG18="",pAG21="",pAG15="";
       for (int i=0;i<in_ed_lvItems.Items.Count ;i++) 
                    {
                        if (deb)
                        {

                            root.AppendChild(Order_node);
                            Order_node.AppendChild(O_HDR_node);

                            XmlElement CustPO_node = xmlDoc.CreateElement("CustomerPoNumber");
                            xTXT = xmlDoc.CreateTextNode(in_ed_lvItems.Items[i].SubItems[12].Text    ); //readr["Custm_PO"].ToString()
                            CustPO_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(CustPO_node);

                            XmlElement A_node = xmlDoc.CreateElement("OrderActionType");
                            xTXT = xmlDoc.CreateTextNode("A");
                            A_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(A_node);

                            XmlElement Cust_NB_node = xmlDoc.CreateElement("Customer");
                            xTXT = xmlDoc.CreateTextNode(in_lCustomerID);  //customer code from SYSP
                            Cust_NB_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(Cust_NB_node);


                            XmlElement O_date_node = xmlDoc.CreateElement("OrderDate");
                            xTXT = xmlDoc.CreateTextNode(MainMDI.Eng_date(in_ed_lvItems.Items[i].SubItems[14].Text, "-"));  //Oreadr["dateRRev"].ToString()
                            O_date_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(O_date_node);

                            XmlElement CustName_node = xmlDoc.CreateElement("CustomerName");
                            xTXT = xmlDoc.CreateTextNode("");  //Oreadr["Cpny_Name1"].ToString()
                            CustName_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(CustName_node);

                            XmlElement AlternateReference_node = xmlDoc.CreateElement("AlternateReference");
                            xTXT = xmlDoc.CreateTextNode(in_ed_lvItems.Items[i].SubItems[16].Text); //Oreadr["RID"].ToString()
                            AlternateReference_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(AlternateReference_node);


                            XmlElement Sales_node = xmlDoc.CreateElement("Salesperson");
                            xTXT = xmlDoc.CreateTextNode(""); // ("I01");  // sales # from SYSP
                            Sales_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(Sales_node);


//######################  sent manufac-ship-date
                            XmlElement Req_ShpDate_node = xmlDoc.CreateElement("RequestedShipDate");
                            xTXT = xmlDoc.CreateTextNode(MainMDI.Eng_date(in_ed_lvItems.Items[i].SubItems[15].Text, "-")); //Oreadr["dateDlvr"].ToString()
                            Req_ShpDate_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(Req_ShpDate_node);

                            Order_node.AppendChild(OrderDetail_node);
                            POline = 1;
                            deb = false;
                        }

                        string stkln_status = "Y";

                        if (in_ed_lvItems.Items[i].Checked && Tools.Conv_Dbl(in_ed_lvItems.Items[i].SubItems[6].Text) > 0)   // was (> 0) 13022012
                        {

                            if (O_PRIMAX) Fill_Stk_Line_OVRG(ref OrderDetail_node, pPX18, "PRIMAX OVERAGE", "1", pPX20, "Y", ref POline, ref CurrPOLine, pPX15, "OVGP");
                            if (O_AGENT) Fill_Stk_Line_OVRG(ref OrderDetail_node, pAG18, "AGENT OVERAGE", "1", pAG21, "Y", ref POline, ref CurrPOLine, pAG15, "OVGA");
                            O_AGENT = false;
                            O_PRIMAX = false;
                      /*
                             PX_Model = "P????-?-???-???";
                             string STK_Code="P4500F-1-48-20";
                             
                             // Tech. values 
                             TestEQA TEA = new TestEQA(in_ed_lvItems.Items[i].SubItems[17].Text);  // Oreadr["Q_tec_Val"].ToString()
                             if (in_ed_lvItems.Items[i].SubItems[17].Text.IndexOf("C_MODEL") > -1)
                            {
                                PX_Model = TEA.look_Req_Value("C_MODEL", in_ed_lvItems.Items[i].SubItems[17].Text, 'C');
                            }
                           
                           // Fill_Stk_Line(ref OrderDetail_node, "P4500F-1-48-20", Oreadr["Desc_item"].ToString(), Oreadr["Qty"].ToString(), Oreadr["Ext"].ToString(), stkln_status, ref POline, ref CurrPOLine);
                      */
                            //  "P4500F-1-48-20" == stockCode from SYSP if stkCode not found

                            //      MessageBox.Show ("TVA= " +  get_TVA(Oreadr["Q_tec_Val"].ToString()));
                            //Tech. Values



                            stkln_status = "Y";  //changed from " " to  "Y"   Stephano REQuest 23/03/2011



                            Fill_Stk_Line(ref OrderDetail_node, in_ed_lvItems.Items[i].SubItems[18].Text, in_ed_lvItems.Items[i].SubItems[3].Text, in_ed_lvItems.Items[i].SubItems[4].Text, in_ed_lvItems.Items[i].SubItems[7].Text, stkln_status, ref POline, ref CurrPOLine, in_ed_lvItems.Items[i].SubItems[15].Text, in_ed_lvItems.Items[i].SubItems[22].Text);
                        
                            if (!QID_sent)
                            {
                                Fill_Comments(ref OrderDetail_node, "QUOTE:" +in_ed_lvItems.Items[i].SubItems[11].Text , ref POline, CurrPOLine);
                                string PX_SN = (in_ed_lvItems.Items[i].SubItems[2].Text != "") ? in_ed_lvItems.Items[i].SubItems[2].Text : MainMDI.VIDE; 
                                Fill_Comments(ref OrderDetail_node, "SERIAL:" + PX_SN , ref POline, CurrPOLine);
                                QID_sent = true;
                            }




                            // add OVRG after last Comment off all the system
                            if (Tools.Conv_Dbl(in_ed_lvItems.Items[i].SubItems[20].Text) > 0)
                            {
                                //fill arrayList with param1....param2....etc    and bool OVRGP=true
                            //    Fill_Stk_Line_OVRG(ref OrderDetail_node, in_ed_lvItems.Items[i].SubItems[18].Text, "PRIMAX OVERAGE", "1", in_ed_lvItems.Items[i].SubItems[20].Text, stkln_status, ref POline, ref CurrPOLine, in_ed_lvItems.Items[i].SubItems[15].Text, "OVGP");
                                pPX18 = in_ed_lvItems.Items[i].SubItems[18].Text;
                                pPX20 = in_ed_lvItems.Items[i].SubItems[20].Text;
                                pPX15 = in_ed_lvItems.Items[i].SubItems[15].Text;
                                O_PRIMAX = true;

                            }

                            if (Tools.Conv_Dbl(in_ed_lvItems.Items[i].SubItems[21].Text) > 0)
                            {
                                //fill arrayList2 with param1....param2....etc    and bool OVRGA=true
                               // Fill_Stk_Line_OVRG(ref OrderDetail_node, in_ed_lvItems.Items[i].SubItems[18].Text, "AGENT OVERAGE", "1", in_ed_lvItems.Items[i].SubItems[21].Text, stkln_status, ref POline, ref CurrPOLine, in_ed_lvItems.Items[i].SubItems[15].Text, "OVGA");
                            
                                pAG18 =in_ed_lvItems.Items[i].SubItems[18].Text;
                                pAG21 =in_ed_lvItems.Items[i].SubItems[21].Text;
                                pAG15 = in_ed_lvItems.Items[i].SubItems[15].Text;
                                O_AGENT = true;

                            }






            //        if  (Tools.Conv_Dbl (in_ed_lvItems.Items[i].SubItems[20].Text) >0)   Fill_Stk_Line_OVRG (ref OrderDetail_node,in_ed_lvItems.Items[i].SubItems[18].Text,"PRIMAX OVERAGE","1",in_ed_lvItems.Items[i].SubItems[20].Text,stkln_status, ref POline, ref CurrPOLine, in_ed_lvItems.Items[i].SubItems[15].Text,"OVGP");
            //        if (Tools.Conv_Dbl(in_ed_lvItems.Items[i].SubItems[21].Text) > 0)    Fill_Stk_Line_OVRG(ref OrderDetail_node, in_ed_lvItems.Items[i].SubItems[18].Text, "AGENT OVERAGE", "1", in_ed_lvItems.Items[i].SubItems[21].Text, stkln_status, ref POline, ref CurrPOLine, in_ed_lvItems.Items[i].SubItems[15].Text, "OVGA");

             //             Fill_OVRG_Line(ref OrderDetail_node,"PRIMAX OVERAGE",in_ed_lvItems.Items[i].SubItems[20].Text,ref POline,ref CurrPOLine,"OVG_P"+in_ed_lvItems.Items[i].SubItems[19].Text);
             //              Fill_OVRG_Line(ref OrderDetail_node, "AGENT OVERAGE", in_ed_lvItems.Items[i].SubItems[21].Text, ref POline,ref CurrPOLine, "OVG_P" + in_ed_lvItems.Items[i].SubItems[19].Text);



                        }
                        else
                        {
                           if (Tools.Conv_Dbl(in_ed_lvItems.Items[i].SubItems[6].Text) < 0)  //active Misc 21022012 :req by steph
                         //   if (Tools.Conv_Dbl(in_ed_lvItems.Items[i].SubItems[6].Text) >999999999999)
                            {
                                Fill_MiscChrg_Line(ref OrderDetail_node, in_ed_lvItems.Items[i].SubItems[3].Text, in_ed_lvItems.Items[i].SubItems[6].Text, ref POline, ref CurrPOLine, in_ed_lvItems.Items[i].Checked );

                            }
                            else
                            {   
                                split_Desc(in_ed_lvItems.Items[i].SubItems[3].Text,MAX_XML_len45 , ref arr_TXT);
                                int s = 0;
                                while (arr_TXT[s] != "")
                                {
                                    Fill_Comments(ref OrderDetail_node, arr_TXT[s++], ref POline, CurrPOLine);
                                }
                            }
                        }

                    }
           if (O_PRIMAX )    Fill_Stk_Line_OVRG(ref OrderDetail_node, pPX18 , "PRIMAX OVERAGE", "1", pPX20 , "Y", ref POline, ref CurrPOLine, pPX15 , "OVGP");
           if (O_AGENT)      Fill_Stk_Line_OVRG(ref OrderDetail_node, pAG18 , "AGENT OVERAGE", "1",pAG21 , "Y", ref POline, ref CurrPOLine, pAG15 , "OVGA");

                    xmlDoc.Save(in_XMLFname);
                }

                catch (Exception ex) { MessageBox.Show("Error XML:  " + ex.ToString()); }

            }
        }




        private void Qty_repr_Click(object sender, EventArgs e)
        {
           // maj_Qty();

        //    ServiceController mySC = new ServiceController("Document Flow Manager", "ERPSERVER");
       //     MessageBox.Show("msg status....." + mySC.Status); 

            //psexec a checker

            MainMDI.Exec_SQL_JFS(" update [Orig_PSM_FDB].[dbo].[PSM_SYSETUP] set [DFM]=0  where s_machNm='PGESCOM' ", "restart DFM");
            MessageBox.Show("WakeUP sent to SYSPRO................"); 
        }





        private void TSmain_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (MainMDI.User.ToLower() == "ede")
            {
                this.Cursor = Cursors.WaitCursor;
                SAVE_XMLFILE (in_irevLID, in_RID);
                this.Cursor = Cursors.Default;

            //    MainMDI.send_email("PGC_SYSYPRO_XML@primax-e.com", "hedebbab@primax-e.com", "XML sent TO SYSPRO by: " + MainMDI.User, "XML sent TO SYSPRO by: " + MainMDI.User + "  irRelID=" + in_irevLID + "   RID= " + in_RID);


                MessageBox.Show("     Sending DONE  .......................");

            }
        }

        private void ed_lvItems_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void chkSendAG_CheckedChanged(object sender, EventArgs e)
        {
            cbAG.Enabled = chkSendAG.Checked;
          //  picCIP.Visible = !chkSendAG.Checked;
       //     picCIP.Visible = false;
        }

        private void cbAG_SelectedIndexChanged(object sender, EventArgs e)
        {
            lag.Text = cbAG.Text;
            load_AGemail();
        }

        void load_AGemail()
        {

            if (chkSendAG.Checked)
            {
                lAG_CodeName.Text = cbAG.Text;
                string codAG = (lAG_CodeName.Text.Length < 4) ? "n/a" : lAG_CodeName.Text.Substring(0, 3);
                string email = MainMDI.Find_One_Field("select email from SalSalesperson where Salesperson='" + codAG + "'");
                lAG_email.Text = email;
                if (email == MainMDI.VIDE || email == "")
                {
                    MessageBox.Show("No email assigned to this Agencie.....\nplease provide an email or Uncheck <Sent mail to Agency>.........");
                    //   btnSave.Enabled = false;
                    //   btnNext.Enabled = false;
                }

            }


        }

			
	

	
	
	/*
	

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


	*/

	}
}
