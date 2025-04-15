using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Xml;
using EAHLibs;
using System.ServiceProcess;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for Alarms.
	/// </summary>
    /// 

	public class Order_SysPro_XML_V7: System.Windows.Forms.Form
	{
		private Lib1 Tools = new Lib1();
		public bool ToBRKDWN = false;

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
        private ToolStrip TSmain;
        private ToolStripButton NewItm;
        private ToolStripButton send_XML;
        private ToolStripButton Qty_repr;
        private ToolStripButton exitt;
        private GroupBox groupBox1;
        private ed_LVmodif ed_lvItems;
        private ColumnHeader stck;
        private ColumnHeader sys;
        private ColumnHeader c_SN;
        private ColumnHeader Item;
        private ColumnHeader c_Qty;
        private ColumnHeader PU;
        private ColumnHeader Ext;
        private ColumnHeader c_revID;
        private ColumnHeader RevNM;
        private ColumnHeader c_cpnyNM;
        private ColumnHeader c_QID;
        private ColumnHeader ItmTotal;
		string in_irevLID = "", in_RID = "";
        private ColumnHeader c_PO;
        private ColumnHeader c_Opendat;
        private ColumnHeader c_dateRRev;
        private ColumnHeader c_RID;
        private ColumnHeader c_TVA;
        private ColumnHeader c_stkCode;
        private Label lCMSOvrg;
        private Label lCMSBad;
        private ColumnHeader curr;
        private ColumnHeader OV_Sale;
        private ColumnHeader OV_AG;
        public Label lCustomerID;
        private ColumnHeader Xch_Mlt;
        private ToolStripButton toolStripButton1;
        private Label label1;
        private ColumnHeader c_dateDlvr;

        public Order_SysPro_XML_V7(string x_irrevLID, string x_RID)
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();
		    //in_frm_FDR = x_Frm_Cdlg;
			in_irevLID = x_irrevLID;
            in_RID = x_RID;

			//
			//TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if (disposing)
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order_SysPro_XML_V7));
            this.btnskip = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lCustomerID = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSv = new System.Windows.Forms.Button();
            this.lSP = new System.Windows.Forms.Label();
            this.btnSaveSN = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.NewItm = new System.Windows.Forms.ToolStripButton();
            this.send_XML = new System.Windows.Forms.ToolStripButton();
            this.Qty_repr = new System.Windows.Forms.ToolStripButton();
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
            this.lCMSOvrg = new System.Windows.Forms.Label();
            this.lCMSBad = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox2.SuspendLayout();
            this.TSmain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnskip
            // 
            this.btnskip.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnskip.Location = new System.Drawing.Point(970, 18);
            this.btnskip.Name = "btnskip";
            this.btnskip.Size = new System.Drawing.Size(115, 28);
            this.btnskip.TabIndex = 147;
            this.btnskip.Text = "Skip";
            this.btnskip.Visible = false;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSave.Location = new System.Drawing.Point(845, 18);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(115, 28);
            this.btnSave.TabIndex = 146;
            this.btnSave.Text = "OK";
            this.btnSave.Visible = false;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lCustomerID);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Controls.Add(this.btnSv);
            this.groupBox2.Controls.Add(this.lSP);
            this.groupBox2.Controls.Add(this.btnSaveSN);
            this.groupBox2.Controls.Add(this.btnCancel);
            this.groupBox2.Controls.Add(this.btnSave);
            this.groupBox2.Controls.Add(this.btnskip);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox2.Location = new System.Drawing.Point(0, 687);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(910, 55);
            this.groupBox2.TabIndex = 149;
            this.groupBox2.TabStop = false;
            this.groupBox2.Visible = false;
            // 
            // lCustomerID
            // 
            this.lCustomerID.BackColor = System.Drawing.Color.DarkCyan;
            this.lCustomerID.Location = new System.Drawing.Point(28, 25);
            this.lCustomerID.Name = "lCustomerID";
            this.lCustomerID.Size = new System.Drawing.Size(92, 19);
            this.lCustomerID.TabIndex = 153;
            this.lCustomerID.Text = "C";
            this.lCustomerID.Visible = false;
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Location = new System.Drawing.Point(562, 18);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(122, 28);
            this.button1.TabIndex = 152;
            this.button1.Text = "Print Selected SN";
            // 
            // btnSv
            // 
            this.btnSv.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSv.Location = new System.Drawing.Point(144, 18);
            this.btnSv.Name = "btnSv";
            this.btnSv.Size = new System.Drawing.Size(154, 28);
            this.btnSv.TabIndex = 151;
            this.btnSv.Text = "Save Serials";
            this.btnSv.Visible = false;
            // 
            // lSP
            // 
            this.lSP.BackColor = System.Drawing.Color.DarkCyan;
            this.lSP.Location = new System.Drawing.Point(329, 18);
            this.lSP.Name = "lSP";
            this.lSP.Size = new System.Drawing.Size(29, 19);
            this.lSP.TabIndex = 150;
            this.lSP.Text = "C";
            this.lSP.Visible = false;
            // 
            // btnSaveSN
            // 
            this.btnSaveSN.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnSaveSN.Location = new System.Drawing.Point(401, 18);
            this.btnSaveSN.Name = "btnSaveSN";
            this.btnSaveSN.Size = new System.Drawing.Size(153, 28);
            this.btnSaveSN.TabIndex = 148;
            this.btnSaveSN.Text = "Save + Print Serials";
            this.btnSaveSN.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(691, 18);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(115, 28);
            this.btnCancel.TabIndex = 149;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.Visible = false;
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
            this.send_XML,
            this.Qty_repr,
            this.toolStripButton1,
            this.exitt});
            this.TSmain.Location = new System.Drawing.Point(0, 0);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(910, 59);
            this.TSmain.TabIndex = 258;
            this.TSmain.Text = "toolStrip2";
            this.TSmain.ItemClicked += new System.Windows.Forms.ToolStripItemClickedEventHandler(this.TSmain_ItemClicked);
            // 
            // NewItm
            // 
            this.NewItm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewItm.Name = "NewItm";
            this.NewItm.Size = new System.Drawing.Size(77, 56);
            this.NewItm.Text = "New Rate";
            this.NewItm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NewItm.ToolTipText = "New";
            this.NewItm.Visible = false;
            // 
            // send_XML
            // 
            this.send_XML.Image = ((System.Drawing.Image)(resources.GetObject("send_XML.Image")));
            this.send_XML.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.send_XML.Name = "send_XML";
            this.send_XML.Size = new System.Drawing.Size(126, 56);
            this.send_XML.Text = "  Send  To SYPRO";
            this.send_XML.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.send_XML.ToolTipText = "Save";
            this.send_XML.Click += new System.EventHandler(this.send_XML_Click);
            // 
            // Qty_repr
            // 
            this.Qty_repr.Image = ((System.Drawing.Image)(resources.GetObject("Qty_repr.Image")));
            this.Qty_repr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Qty_repr.Name = "Qty_repr";
            this.Qty_repr.Size = new System.Drawing.Size(130, 56);
            this.Qty_repr.Text = "Start SYSPRO-xml";
            this.Qty_repr.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Qty_repr.ToolTipText = "Delete Batch";
            this.Qty_repr.Visible = false;
            this.Qty_repr.Click += new System.EventHandler(this.Qty_repr_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(80, 56);
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
            this.exitt.Size = new System.Drawing.Size(77, 56);
            this.exitt.Text = "     Exit     ";
            this.exitt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exitt.ToolTipText = "Exit";
            this.exitt.Click += new System.EventHandler(this.exitt_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ed_lvItems);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(910, 628);
            this.groupBox1.TabIndex = 259;
            this.groupBox1.TabStop = false;
            // 
            // ed_lvItems
            // 
            this.ed_lvItems.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvItems.AutoArrange = false;
            this.ed_lvItems.BackColor = System.Drawing.Color.Honeydew;
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
            this.ed_lvItems.HideSelection = false;
            this.ed_lvItems.Location = new System.Drawing.Point(3, 18);
            this.ed_lvItems.MultiSelect = false;
            this.ed_lvItems.Name = "ed_lvItems";
            this.ed_lvItems.Size = new System.Drawing.Size(904, 607);
            this.ed_lvItems.TabIndex = 252;
            this.ed_lvItems.UseCompatibleStateImageBehavior = false;
            this.ed_lvItems.View = System.Windows.Forms.View.Details;
            this.ed_lvItems.SelectedIndexChanged += new System.EventHandler(this.ed_lvItems_SelectedIndexChanged_1);
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
            // lCMSOvrg
            // 
            this.lCMSOvrg.BackColor = System.Drawing.Color.PaleGreen;
            this.lCMSOvrg.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lCMSOvrg.Location = new System.Drawing.Point(786, 21);
            this.lCMSOvrg.Name = "lCMSOvrg";
            this.lCMSOvrg.Size = new System.Drawing.Size(140, 21);
            this.lCMSOvrg.TabIndex = 167;
            this.lCMSOvrg.Text = "VALID";
            this.lCMSOvrg.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lCMSBad
            // 
            this.lCMSBad.BackColor = System.Drawing.Color.Salmon;
            this.lCMSBad.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lCMSBad.Location = new System.Drawing.Point(595, 21);
            this.lCMSBad.Name = "lCMSBad";
            this.lCMSBad.Size = new System.Drawing.Size(191, 21);
            this.lCMSBad.TabIndex = 168;
            this.lCMSBad.Text = "INVALID   ( SN / STK-Code )";
            this.lCMSBad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Violet;
            this.label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label1.Location = new System.Drawing.Point(926, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(189, 21);
            this.label1.TabIndex = 260;
            this.label1.Text = " STK-Code:  length error ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Order_SysPro_XML_V7
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(910, 742);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lCMSOvrg);
            this.Controls.Add(this.lCMSBad);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TSmain);
            this.Controls.Add(this.groupBox2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Order_SysPro_XML_V7";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sending Project to SYSPRO7";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Order_SysPro_XML_Load);
            this.groupBox2.ResumeLayout(false);
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

        private string Find_STKCODE(string desc)
        {
            string stSql = "select f2, f3,f4 from PSM_C_GConfig where F1_Code='serial' ", F3 = "", F4 = "", res = "";
            bool found = false;
            int II = 0;

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            stSql = "";
            
            while (Oreadr.Read() && !found)
            {
                if (desc.ToLower().IndexOf(Oreadr["f2"].ToString().ToLower()) > -1)
                {
                    F3 = Oreadr["f3"].ToString(); F4 = Oreadr["f4"].ToString();

                    switch (F3[0])
                    {
                        case '!':
                            res = F3;
                            break;
                        case '<':
                            II = Convert.ToInt32(F3.Substring(1, F3.Length - 1));
                            res = desc.Substring(0, II);
                            break;
                        case '+':
                            string key = F3.Substring(1, F3.Length - 1);
                            int i2 = desc.IndexOf(key);

                            II = desc.IndexOf(" ", i2);

                            res = (II > -1) ? desc.Substring(i2, II - i2) : F4; //res = desc.Substring(i2, II - i2 - 1);
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
                else res = (desc.Length < 15) ? desc.Replace(" ", "-") : desc.Substring(0, 15).Replace(" ", "-");
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
            string grps = "?ABCDEF";
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            string ORev = "", NRev = "", OSys = "", NSys = "";
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvItems.Items.Clear();
            string newSYS = "", oldSYS = "", totSys;
            ListViewItem lvI = null;
            lCustomerID.Text = "";
            while (Oreadr.Read())
            {
                if (lCustomerID.Text == "") lCustomerID.Text = Oreadr["Syspro_Code"].ToString();
                string STK_Code = "";
                string sysNm = oldSYS;
                newSYS = Oreadr["R_sysName"].ToString();
                lvI = ed_lvItems.Items.Add("");
                if (newSYS != oldSYS)
                {
                    sysNm = newSYS;
                    oldSYS = newSYS;
                    //#############
                    totSys = Oreadr["R_GSTot"].ToString(); //Oreadr["SysTOT_AG"].ToString(); ag_total

                    //###################
                    lvI.BackColor = Color.PaleGreen; //Salmon;

                    TestEQA TEA = new TestEQA(Oreadr["Q_tec_Val"].ToString()); //Oreadr["Q_tec_Val"].ToString()
                    if (Oreadr["Q_tec_Val"].ToString().IndexOf("C_MODEL") > -1)
                    {
                        STK_Code = TEA.look_Req_Value("C_MODEL", Oreadr["Q_tec_Val"].ToString(), 'C');
                    }
                    else 
                    {
                        STK_Code = Find_STKCODE(Oreadr["ItemDesc"].ToString());
                    }
                    if (STK_Code.Length > 3 && STK_Code.Length < 23)
                    {
                        if (Oreadr["PrimaxSN"].ToString().Length > 3) STK_Code += "_" + Oreadr["PrimaxSN"].ToString();
                        else STK_Code += "_G" + Oreadr["Rdetail_LID"].ToString();

                        //lvI.BackColor = Color.Green;
                    }
                    else
                    {
                        Color tt = (STK_Code.Length <= 3 || STK_Code.Length >= 23) ? Color.Violet : Color.Salmon; //23
                        lvI.BackColor = tt;
                        send_XML.Enabled = false;
                    }
                    //if (STK_Code.Length > lvI.BackColor = (Oreadr["PrimaxSN"].ToString().Length > 5 && STK_Code.Length > 2) ? Color.Green : Color.Salmon;

                    lvI.Checked = (STK_Code != "");
                }
                else
                {
                    sysNm = "--";
                    totSys = "";
                }
                lvI.SubItems.Add(sysNm); //1
                lvI.SubItems.Add(Oreadr["PrimaxSN"].ToString()); //2 
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
                lvI.SubItems.Add(Oreadr["dateManufac"].ToString()); //before was: 'dateDlvr'

                //add Revxx to RID as alternate-key in SYSPRO 07-12-2015 (agent_cms)
                //lvI.SubItems.Add(Oreadr["RID"].ToString()); //old alternate-key
                string RevName = Oreadr["RRev_Name"].ToString().Replace("(", "").Replace(")", "").Replace("-", "");
                lvI.SubItems.Add(Oreadr["RID"].ToString() + "_" + RevName);
                //add Revxx to RID as alternate-key in SYSPRO 07-12-2015 (agent_cms)

                lvI.SubItems.Add(Oreadr["Q_tec_Val"].ToString());
                lvI.SubItems.Add(STK_Code);

                string st = "";
                //if (Oreadr["PrimaxSN"].ToString() == "S6874") st = st;

                lvI.SubItems.Add(Oreadr["curr"].ToString());
                //double dd = Math.Round(Convert.ToDouble(Oreadr["R_sysTot"].ToString()) - Convert.ToDouble(Oreadr["R_GSTot"].ToString()), 2); lvI.SubItems.Add(dd.ToString());
                //dd = Math.Round(Convert.ToDouble(Oreadr["SysTOT_AG"].ToString()) - Convert.ToDouble(Oreadr["R_sysTot"].ToString()), 2); lvI.SubItems.Add(dd.ToString());

                double d_GSTot = Convert.ToDouble(Oreadr["R_GSTot"].ToString()); //px
                double d_TOT_AG= Convert.ToDouble(Oreadr["SysTOT_AG"].ToString()); //sls
                double d_RsysTOT = Convert.ToDouble(Oreadr["R_sysTot"].ToString()); //ag

                //if ((d_TOT_AG * 2) >= d_RsysTOT) d_RsysTOT = d_TOT_AG;
                //int rt = (int) (d_RsysTOT % d_TOT_AG);
                //if (Math.Round(rt, 0) == 0) d_RsysTOT = d_TOT_AG;

                double dvsr = d_RsysTOT / d_TOT_AG;

                if (d_RsysTOT == (d_TOT_AG * dvsr)) d_RsysTOT = d_TOT_AG;
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
            Load_orderXML();
        }

        void Load_orderXML()
        {
            Load_ProjNm(in_irevLID);
            btnSave.Visible = true;
            btnskip.Visible = true;
            Qty_repr.Visible = (MainMDI.User.ToLower() == "ede");
            toolStripButton1.Visible = (MainMDI.User.ToLower() == "ede");
        }

        private void exitt_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void send_XML_Click(object sender, EventArgs e)
        {
            this.Cursor = Cursors.WaitCursor;
            send_XMLFILE_V7(in_irevLID, in_RID);
            this.Cursor = Cursors.Default;

            MainMDI.send_email("PGC_SYSYPRO_XML@primax-e.com", "hedebbab@primax-e.com", "XML sent TO SYSPRO by: " + MainMDI.User, "XML sent TO SYSPRO by: " + MainMDI.User + "  irRelID=" + in_irevLID + "   RID= " + in_RID);

            MessageBox.Show("     Sending DONE  .......................");
        }

        private void send_XMLFILE_V7_TST(string _IRRevID, string _RID)
        {
            //string _RevNm = MainMDI.Find_One_Field("select RRev_Name from PSM_R_Rev where IRRevID=" + _IRRevID);
            if (_RID != MainMDI.VIDE || lCustomerID.Text != "")
            {
                //string filename = @"\\Erpserver\syspro61\DFM\CompanyP\Sales Orders\Polling\PSM_" + _RID.Replace(" ", "_") + ".xml"; //+ DateTime.Now.Day;
                string filename = @"\\NTSERVER\common\dataprimax\6pro\PSM_" + _RID.Replace(" ", "_") + ".xml"; //+ DateTime.Now.Day;
                System.IO.File.Delete(filename);
                XML_SPdata mySPdata = new XML_SPdata(_IRRevID, filename, ed_lvItems, lCustomerID.Text);
                mySPdata.my_WriteXML_byPROJECT();
 
                string fdesti = @"\\NTSERVER\Common\SYSPRO_XMLlogs\" + DateTime.Now.ToString().Replace(":", "-").Replace("/", "-") + "__" + "PSM_" + _RID.Replace(" ", "_") + ".xml";
                System.IO.File.Copy(filename, fdesti); //+ DateTime.Now.Day;
            }
            else MessageBox.Show("Sorry can not send XML file (bad REVISION Name).........");
        }

        private void send_XMLFILE_V7(string _IRRevID, string _RID)
        {
            //string _RevNm = MainMDI.Find_One_Field("select RRev_Name from PSM_R_Rev where IRRevID=" + _IRRevID);
            if (_RID != MainMDI.VIDE || lCustomerID.Text != "")
            {
                //string filename = @"c:\SYSPRO_XML\PSM_" + _RID.Replace(" ", "_") + ".xml"; //+ DateTime.Now.Day;
                string filename = @"\\Erpserver\syspro61\DFM\CompanyP\Sales Orders\Polling\PSM_" + _RID.Replace(" ", "_") + ".xml"; //+ DateTime.Now.Day;
                System.IO.File.Delete(filename);
                XML_SPdata mySPdata = new XML_SPdata(_IRRevID, filename, ed_lvItems, lCustomerID.Text);
                if (mySPdata.my_WriteXML_byPROJECT())
                {
                    //string fdesti = @"\\NTSERVER2\Common_Big_Files\SYSPRO_XMLlogs\" + DateTime.Now.ToString().Replace(":", "-").Replace("/", "-") + "__" + "PSM_" + _RID.Replace(" ", "_") + ".xml";
                    string fdesti = @"\\NTSERVER\Common\SYSPRO_XMLlogs\" + DateTime.Now.ToString().Replace(":", "-").Replace("/", "-") + "__" + "PSM_" + _RID.Replace(" ", "_") + ".xml";
                    System.IO.File.Copy(filename, fdesti); //+ DateTime.Now.Day;
                }
                //MessageBox.Show("Sorry can not send XML file (system error).........");
            }
            else MessageBox.Show("Sorry can not send XML file (bad REVISION Name).........");
        }

        private void SAVE_XMLFILE(string _IRRevID, string _RID)
        {
            //string _RevNm = MainMDI.Find_One_Field("select RRev_Name from PSM_R_Rev where IRRevID=" + _IRRevID);
            if (_RID != MainMDI.VIDE || lCustomerID.Text != "")
            {
                string filename = @"c:\SYSPRO_XML\PSM_" + _RID.Replace(" ", "_") + ".xml"; //+ DateTime.Now.Day;
                //string filename = @"\\Erpserver\syspro61\DFM\CompanyP\Sales Orders\Polling\PSM_" + _RID.Replace(" ", "_") + ".xml"; //+ DateTime.Now.Day;
                System.IO.File.Delete(filename);
                XML_SPdata mySPdata = new XML_SPdata(_IRRevID, filename, ed_lvItems, lCustomerID.Text);
                mySPdata.my_WriteXML_byPROJECT();
            }
            else MessageBox.Show("Sorry can not send XML file (bad REVISION Name).........");
        }

        class XML_SPdata
        {
            Lib1 Tools = new Lib1();
            string in_XMLFname = "", in_IRrevLID = "", in_lCustomerID;
            ed_LVmodif in_ed_lvItems = null;
            XmlDocument xmlDoc = null;
            //private int MAX_XML_len30 = 28, MAX_XML_len45 = 43; //SYSPRO Ver6
            //private int MAX_XML_len30 = 65, MAX_XML_len45 = 78; //SYSPRO Ver7 before 28/22/2017
            private int MAX_XML_len30 = 47, MAX_XML_len45 = 78;

            public XML_SPdata(string X_IrevLID, string X_filename, ed_LVmodif x_ed_lvItems, string x_lCustomerID)
            {
                in_XMLFname = X_filename;
                in_IRrevLID = X_IrevLID;
                in_ed_lvItems = x_ed_lvItems;
                in_lCustomerID = x_lCustomerID;
                getLENs();
            }

            void getLENs()
            {
                string l30 = "", l45 = "";
                MainMDI.Find_2_Field("select f3, f5 from PSM_C_GConfig where [F1_Code]='syspro' and f2='len30' ", ref l30, ref l45);
                if (l30 != MainMDI.VIDE)
                {
                    MAX_XML_len30 = (int)Tools.Conv_Dbl(l30);

                    MAX_XML_len45 = (int)Tools.Conv_Dbl(l45);
                }
                if (MAX_XML_len30 < 4 || MAX_XML_len45 < 4)
                {
                    MessageBox.Show("ERROR in standard Lentgth.......will use old one.....Admin Alert....");
                    MAX_XML_len30 = 47;
                    MAX_XML_len45 = 78;
                }
            }

            private void Fill_MiscChrg_Line_OLD(ref XmlElement OrderDetail_node, string _Desc_item,string _Ext, ref int POline, ref int _CurrPOLine) //sent with negative value - 39
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
                //xTXT = xmlDoc.CreateTextNode("_OTH"); req. by stephano 12/04/2011
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

                split_Desc(_Desc_item, MAX_XML_len30, ref my_arr_TXT);
                //####### remainig text must be splited by 45 not 30

                XmlElement MiscDescription_node = xmlDoc.CreateElement("MiscDescription");
                XmlCDataSection myCdata = xmlDoc.CreateCDataSection(my_arr_TXT[0]);
                MiscDescription_node.AppendChild(myCdata);
                StkLine_node.AppendChild(MiscDescription_node);

                //suite du descr > 30 as comnt
                //####### remainig text must be splited by 45 not 30 (45 will be 43 and 30 will be 28 ===> since adding ~~ and ~!
                split_Desc(_Desc_item.Substring(my_arr_TXT[0].Length, _Desc_item.Length - my_arr_TXT[0].Length), MAX_XML_len45, ref my_arr_TXT);
                int s = 0;
                while (my_arr_TXT[s] != "")
                {
                    Fill_Comments(ref OrderDetail_node, my_arr_TXT[s++], ref POline, _CurrPOLine);
                }
            }

            private void Fill_MiscChrg_Line(ref XmlElement OrderDetail_node, string _Desc_item, string _Ext, ref int POline, ref int _CurrPOLine, bool isStkLine)
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

                if (isStkLine) xTXT = xmlDoc.CreateTextNode(_Ext);
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
                //xTXT = xmlDoc.CreateTextNode("_OTH"); req. by stephano 12/04/2011
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

                if (!isStkLine) _Desc_item += "  (" + _Ext + ") "; //added 22/03/2012

                split_Desc(_Desc_item, MAX_XML_len30, ref my_arr_TXT);
                //####### remainig text must be splited by 45 not 30

                XmlElement MiscDescription_node = xmlDoc.CreateElement("MiscDescription");
                XmlCDataSection myCdata = xmlDoc.CreateCDataSection(my_arr_TXT[0]);
                MiscDescription_node.AppendChild(myCdata);
                StkLine_node.AppendChild(MiscDescription_node);

                //suite du descr > 30 as comnt
                //####### remainig text must be splited by 45 not 30 (45 will be 43 and 30 will be 28 ===> since adding ~~ and ~!
                split_Desc(_Desc_item.Substring(my_arr_TXT[0].Length, _Desc_item.Length - my_arr_TXT[0].Length), MAX_XML_len45, ref my_arr_TXT);
                int s = 0;
                while (my_arr_TXT[s] != "")
                {
                    Fill_Comments(ref OrderDetail_node, my_arr_TXT[s++], ref POline, _CurrPOLine);
                }
            }

            private void Fill_OVRG_Line(ref XmlElement OrderDetail_node, string _Desc_item, string _Ext, ref int POline, ref int _CurrPOLine, string OVGCode)
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
                //xTXT = xmlDoc.CreateTextNode("_OTH"); req. by stephano 12/04/2011
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
                //####### remainig text must be splited by 45 not 30

                XmlElement MiscDescription_node = xmlDoc.CreateElement("MiscDescription");
                XmlCDataSection myCdata = xmlDoc.CreateCDataSection(my_arr_TXT[0]);
                MiscDescription_node.AppendChild(myCdata);
                StkLine_node.AppendChild(MiscDescription_node);

                //suite du descr >30 as comnt
                //####### remainig text must be splited by 45 not 30 (45 will be 43 and 30 will be 28 ===> since adding ~~ and ~!
                split_Desc(_Desc_item.Substring(my_arr_TXT[0].Length, _Desc_item.Length - my_arr_TXT[0].Length), MAX_XML_len45, ref my_arr_TXT);
                int s = 0;
                while (my_arr_TXT[s] != "")
                {
                    Fill_Comments(ref OrderDetail_node, my_arr_TXT[s++], ref POline, _CurrPOLine);
                }
                XmlElement MiscChargeCode_node = xmlDoc.CreateElement("MiscChargeCode");
                xTXT = xmlDoc.CreateTextNode(OVGCode);
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
                //xTXT = xmlDoc.CreateTextNode("1");
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
                //xTXT = xmlDoc.CreateTextNode(Oreadr["Desc_item"].ToString()); //??????
                xTXT = xmlDoc.CreateTextNode(_StockCode);
                StkCode_node.AppendChild(xTXT);
                StkLine_node.AppendChild(StkCode_node);

                //xTXT = xmlDoc.CreateTextNode(Oreadr["Desc_item"].ToString());
                //StkDesc_node.AppendChild(xTXT);
                //if (Oreadr["Desc_item"].ToString().Length > 30)

                split_Desc(_Desc_item, MAX_XML_len30, ref my_arr_TXT);
                //####### remainig text must be splited by 45 not 30
                //split_Desc(Oreadr["Desc_item"].ToString().Substring(arr_TXT[0].Length), 45, ref arr_TXT);

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

                //Unit Price
                double _UP = Math.Round(Tools.Conv_Dbl(_Ext) / Tools.Conv_Dbl(_Qty), 4);
                //Unit Price
                XmlElement Price_node = xmlDoc.CreateElement("Price");
                xTXT = xmlDoc.CreateTextNode(_UP.ToString());
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

                if (_Desc_item.Length > MAX_XML_len30)
                {
                    //suite du descr > 30 as comnt
                    //####### remainig text must be splited by 45 not 30
                    //split_Desc(_Desc_item.Substring(my_arr_TXT[0].Length - 2, _Desc_item.Length - my_arr_TXT[0].Length), , ref my_arr_TXT);
                    int s = 1;
                    while (my_arr_TXT[s] != "")
                    {
                        Fill_Comments(ref OrderDetail_node, my_arr_TXT[s++], ref POline, _CurrPOLine);
                    }
                }
            }

            private void Fill_Stk_Line_OVRG(ref XmlElement OrderDetail_node, string _StockCode, string _Desc_item, string _Qty, string _Ext, string stkln_status, ref int POline, ref int _CurrPOLine, string _CustReqDate, string OVGTYPE)
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
                //string[] arr_sub_desc = new string[10];

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

            //reste "P4500F-1-48-20" comme StockCode a reparer !!!! 21/10/2010
            public bool my_WriteXML_byPROJECT()
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
                    string PX_Model = "", pPX18 = "", pPX20 = "", pPX15 = "", pAG18 = "", pAG21 = "", pAG15 = "";
                    for (int i = 0; i < in_ed_lvItems.Items.Count; i++)
                    {
                        if (deb)
                        {
                            root.AppendChild(Order_node);
                            Order_node.AppendChild(O_HDR_node);

                            XmlElement CustPO_node = xmlDoc.CreateElement("CustomerPoNumber");
                            xTXT = xmlDoc.CreateTextNode(in_ed_lvItems.Items[i].SubItems[12].Text); //readr["Custm_PO"].ToString()
                            CustPO_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(CustPO_node);

                            XmlElement A_node = xmlDoc.CreateElement("OrderActionType");
                            xTXT = xmlDoc.CreateTextNode("A");
                            A_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(A_node);

                            XmlElement Cust_NB_node = xmlDoc.CreateElement("Customer");
                            xTXT = xmlDoc.CreateTextNode(in_lCustomerID); //customer code from SYSP
                            Cust_NB_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(Cust_NB_node);

                            XmlElement O_date_node = xmlDoc.CreateElement("OrderDate");
                            xTXT = xmlDoc.CreateTextNode(MainMDI.Eng_date(in_ed_lvItems.Items[i].SubItems[14].Text, "-")); //Oreadr["dateRRev"].ToString()
                            O_date_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(O_date_node);

                            XmlElement CustName_node = xmlDoc.CreateElement("CustomerName");
                            xTXT = xmlDoc.CreateTextNode(""); //Oreadr["Cpny_Name1"].ToString()
                            CustName_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(CustName_node);

                            XmlElement AlternateReference_node = xmlDoc.CreateElement("AlternateReference");
                            xTXT = xmlDoc.CreateTextNode(in_ed_lvItems.Items[i].SubItems[16].Text); //Oreadr["RID"].ToString()
                            AlternateReference_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(AlternateReference_node);

                            XmlElement Sales_node = xmlDoc.CreateElement("Salesperson");
                            xTXT = xmlDoc.CreateTextNode(""); //("I01"); //sales # from SYSP
                            Sales_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(Sales_node);

                            //###################### sent manufac-ship-date
                            XmlElement Req_ShpDate_node = xmlDoc.CreateElement("RequestedShipDate");
                            xTXT = xmlDoc.CreateTextNode(MainMDI.Eng_date(in_ed_lvItems.Items[i].SubItems[15].Text, "-")); //Oreadr["dateDlvr"].ToString()
                            Req_ShpDate_node.AppendChild(xTXT);
                            O_HDR_node.AppendChild(Req_ShpDate_node);

                            Order_node.AppendChild(OrderDetail_node);
                            POline = 1;
                            deb = false;
                        }
                        string stkln_status = "Y";

                        if (in_ed_lvItems.Items[i].Checked && Tools.Conv_Dbl(in_ed_lvItems.Items[i].SubItems[6].Text) > 0) //was (> 0) 13022012
                        {
                            if (O_PRIMAX) Fill_Stk_Line_OVRG(ref OrderDetail_node, pPX18, "PRIMAX OVERAGE", "1", pPX20, "Y", ref POline, ref CurrPOLine, pPX15, "OVGP");
                            if (O_AGENT) Fill_Stk_Line_OVRG(ref OrderDetail_node, pAG18, "AGENT OVERAGE", "1", pAG21, "Y", ref POline, ref CurrPOLine, pAG15, "OVGA");
                            O_AGENT = false;
                            O_PRIMAX = false;
                            /*
                            PX_Model = "P????-?-???-???";
                            string STK_Code = "P4500F-1-48-20";
                             
                            //Tech. values 
                            TestEQA TEA = new TestEQA(in_ed_lvItems.Items[i].SubItems[17].Text); //Oreadr["Q_tec_Val"].ToString()
                            if (in_ed_lvItems.Items[i].SubItems[17].Text.IndexOf("C_MODEL") > -1)
                            {
                                PX_Model = TEA.look_Req_Value("C_MODEL", in_ed_lvItems.Items[i].SubItems[17].Text, 'C');
                            }
                            //Fill_Stk_Line(ref OrderDetail_node, "P4500F-1-48-20", Oreadr["Desc_item"].ToString(), Oreadr["Qty"].ToString(), Oreadr["Ext"].ToString(), stkln_status, ref POline, ref CurrPOLine);
                            */
                            //"P4500F-1-48-20" == stockCode from SYSP if stkCode not found

                            //MessageBox.Show("TVA= " + get_TVA(Oreadr["Q_tec_Val"].ToString()));
                            //Tech. Values

                            stkln_status = "Y"; //changed from " " to "Y" Stephano REQuest 23/03/2011

                            Fill_Stk_Line(ref OrderDetail_node, in_ed_lvItems.Items[i].SubItems[18].Text, in_ed_lvItems.Items[i].SubItems[3].Text, in_ed_lvItems.Items[i].SubItems[4].Text, in_ed_lvItems.Items[i].SubItems[7].Text, stkln_status, ref POline, ref CurrPOLine, in_ed_lvItems.Items[i].SubItems[15].Text, in_ed_lvItems.Items[i].SubItems[22].Text);

                            if (!QID_sent)
                            {
                                Fill_Comments(ref OrderDetail_node, "QUOTE:" + in_ed_lvItems.Items[i].SubItems[11].Text, ref POline, CurrPOLine);
                                string PX_SN = (in_ed_lvItems.Items[i].SubItems[2].Text != "") ? in_ed_lvItems.Items[i].SubItems[2].Text : MainMDI.VIDE;
                                Fill_Comments(ref OrderDetail_node, "SERIAL:" + PX_SN, ref POline, CurrPOLine);
                                QID_sent = true;
                            }
                            //add OVRG after last Comment off all the system
                            if (Tools.Conv_Dbl(in_ed_lvItems.Items[i].SubItems[20].Text) > 0)
                            {
                                //fill arrayList with param1....param2....etc and bool OVRGP = true
                                //Fill_Stk_Line_OVRG(ref OrderDetail_node, in_ed_lvItems.Items[i].SubItems[18].Text, "PRIMAX OVERAGE", "1", in_ed_lvItems.Items[i].SubItems[20].Text, stkln_status, ref POline, ref CurrPOLine, in_ed_lvItems.Items[i].SubItems[15].Text, "OVGP");
                                pPX18 = in_ed_lvItems.Items[i].SubItems[18].Text;
                                pPX20 = in_ed_lvItems.Items[i].SubItems[20].Text;
                                pPX15 = in_ed_lvItems.Items[i].SubItems[15].Text;
                                O_PRIMAX = true;
                            }
                            if (Tools.Conv_Dbl(in_ed_lvItems.Items[i].SubItems[21].Text) > 0)
                            {
                                //fill arrayList2 with param1....param2....etc and bool OVRGA = true
                                //Fill_Stk_Line_OVRG(ref OrderDetail_node, in_ed_lvItems.Items[i].SubItems[18].Text, "AGENT OVERAGE", "1", in_ed_lvItems.Items[i].SubItems[21].Text, stkln_status, ref POline, ref CurrPOLine, in_ed_lvItems.Items[i].SubItems[15].Text, "OVGA");

                                pAG18 = in_ed_lvItems.Items[i].SubItems[18].Text;
                                pAG21 = in_ed_lvItems.Items[i].SubItems[21].Text;
                                pAG15 = in_ed_lvItems.Items[i].SubItems[15].Text;
                                O_AGENT = true;
                            }
                            //if (Tools.Conv_Dbl(in_ed_lvItems.Items[i].SubItems[20].Text) > 0) Fill_Stk_Line_OVRG(ref OrderDetail_node, in_ed_lvItems.Items[i].SubItems[18].Text, "PRIMAX OVERAGE", "1", in_ed_lvItems.Items[i].SubItems[20].Text, stkln_status, ref POline, ref CurrPOLine, in_ed_lvItems.Items[i].SubItems[15].Text, "OVGP");
                            //if (Tools.Conv_Dbl(in_ed_lvItems.Items[i].SubItems[21].Text) > 0) Fill_Stk_Line_OVRG(ref OrderDetail_node, in_ed_lvItems.Items[i].SubItems[18].Text, "AGENT OVERAGE", "1", in_ed_lvItems.Items[i].SubItems[21].Text, stkln_status, ref POline, ref CurrPOLine, in_ed_lvItems.Items[i].SubItems[15].Text, "OVGA");

                            //Fill_OVRG_Line(ref OrderDetail_node, "PRIMAX OVERAGE", in_ed_lvItems.Items[i].SubItems[20].Text, ref POline, ref CurrPOLine, "OVG_P" + in_ed_lvItems.Items[i].SubItems[19].Text);
                            //Fill_OVRG_Line(ref OrderDetail_node, "AGENT OVERAGE", in_ed_lvItems.Items[i].SubItems[21].Text, ref POline, ref CurrPOLine, "OVG_P" + in_ed_lvItems.Items[i].SubItems[19].Text);
                        }
                        else
                        {
                            if (Tools.Conv_Dbl(in_ed_lvItems.Items[i].SubItems[6].Text) < 0) //active Misc 21022012 : req by steph
                            //if (Tools.Conv_Dbl(in_ed_lvItems.Items[i].SubItems[6].Text) > 999999999999)
                            {
                                Fill_MiscChrg_Line(ref OrderDetail_node, in_ed_lvItems.Items[i].SubItems[3].Text, in_ed_lvItems.Items[i].SubItems[6].Text, ref POline, ref CurrPOLine, in_ed_lvItems.Items[i].Checked);
                            }
                            else
                            {
                                split_Desc(in_ed_lvItems.Items[i].SubItems[3].Text, MAX_XML_len45, ref arr_TXT);
                                int s = 0;
                                while (arr_TXT[s] != "")
                                {
                                    Fill_Comments(ref OrderDetail_node, arr_TXT[s++], ref POline, CurrPOLine);
                                }
                            }
                        }
                    }
                    if (O_PRIMAX) Fill_Stk_Line_OVRG(ref OrderDetail_node, pPX18, "PRIMAX OVERAGE", "1", pPX20, "Y", ref POline, ref CurrPOLine, pPX15, "OVGP");
                    if (O_AGENT) Fill_Stk_Line_OVRG(ref OrderDetail_node, pAG18, "AGENT OVERAGE", "1", pAG21, "Y", ref POline, ref CurrPOLine, pAG15, "OVGA");

                    xmlDoc.Save(in_XMLFname);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error XML:  " + ex.ToString());
                    return false;
                }
                return true;
            }
        }

        private void Qty_repr_Click(object sender, EventArgs e)
        {
            //maj_Qty();

            //ServiceController mySC = new ServiceController("Document Flow Manager", "ERPSERVER");
            //MessageBox.Show("msg status....." + mySC.Status);

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
                SAVE_XMLFILE(in_irevLID, in_RID);
                this.Cursor = Cursors.Default;

                //MainMDI.send_email("PGC_SYSYPRO_XML@primax-e.com", "hedebbab@primax-e.com", "XML sent TO SYSPRO by: " + MainMDI.User, "XML sent TO SYSPRO by: " + MainMDI.User + "  irRelID=" + in_irevLID + "   RID= " + in_RID);

                MessageBox.Show("     Sending DONE  .......................");
            }
        }

        private void ed_lvItems_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

	    /*
		private void btnSave_Click(object sender, System.EventArgs e)
		{
			Save_tmp_Config();
		}

		private void Save_tmp_Config()
		{
			int res = 0;
			string r_Qtysys = "";
			for (int b = 0; b < lv_Ritems.Items.Count; b++)
			{
				if (lv_Ritems.Items[b].SubItems[6].Text == " ") r_Qtysys = lv_Ritems.Items[b].SubItems[2].Text;
				else 
				{
					if (lv_Ritems.Items[b].Checked && lv_Ritems.Items[b].BackColor == Color.Moccasin) res = ((lv_Ritems.Items[b].Checked) ? 1 : 0);
					else res = 0;
					MainMDI.ExecSql("UPDATE " + MainMDI.t_Det_OL + " SET Det_Qty ='" + lv_Ritems.Items[b].SubItems[4].Text + "', Als_Qty='" + r_Qtysys + "', brkdwn=" + res + " WHERE  lineID=" + lv_Ritems.Items[b].SubItems[6].Text);
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
		    //tExt.Text = Convert.ToString(Math.Round(Tools.Conv_Dbl(tQty.Text) * Tools.Conv_Dbl(tUP.Text), MainMDI.NB_DEC_AFF));
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
			lv_Ritems.Columns[3].Width = this.Width - 537; //377;
		}

		private void btnskip_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void btnSaveSN_Click(object sender, System.EventArgs e)
		{
			lSP.Text = "SP";
			this.Hide();
		}

		private void btnSv_Click(object sender, System.EventArgs e)
		{
			lSP.Text = "S";
			this.Hide();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			lSP.Text = "C";
			this.Hide();
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