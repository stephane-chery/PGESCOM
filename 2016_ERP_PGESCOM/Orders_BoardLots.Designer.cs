namespace PGESCOM
{
    partial class Orders_BoardLots
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Orders_BoardLots));
            this.grpConf = new System.Windows.Forms.GroupBox();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.Newbrd = new System.Windows.Forms.ToolStripButton();
            this.del_BRD = new System.Windows.Forms.ToolStripButton();
            this.Sav_BRD = new System.Windows.Forms.ToolStripButton();
            this.list_BI = new System.Windows.Forms.ToolStripButton();
            this.exitt = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.grpLV = new System.Windows.Forms.GroupBox();
            this.ed_lvBRD = new PGESCOM.ed_LVmodif();
            this.lotLID = new System.Windows.Forms.ColumnHeader();
            this.datRecp = new System.Windows.Forms.ColumnHeader();
            this.lotPO = new System.Windows.Forms.ColumnHeader();
            this.Bver = new System.Windows.Forms.ColumnHeader();
            this.BOMrev = new System.Windows.Forms.ColumnHeader();
            this.PCBdat = new System.Windows.Forms.ColumnHeader();
            this.Assmbdat = new System.Windows.Forms.ColumnHeader();
            this.Qty = new System.Windows.Forms.ColumnHeader();
            this.ccmnt = new System.Windows.Forms.ColumnHeader();
            this.label65 = new System.Windows.Forms.Label();
            this.tBrdDesc = new System.Windows.Forms.TextBox();
            this.tbV = new System.Windows.Forms.TextBox();
            this.lbomRev = new System.Windows.Forms.Label();
            this.grpBrdSN = new System.Windows.Forms.GroupBox();
            this.CB_brd = new System.Windows.Forms.ComboBox();
            this.lotLid_CHS = new System.Windows.Forms.Label();
            this.lmodelLID = new System.Windows.Forms.Label();
            this.msk_BomRev = new System.Windows.Forms.MaskedTextBox();
            this.msk_grb_ver = new System.Windows.Forms.MaskedTextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pictureBox11 = new System.Windows.Forms.PictureBox();
            this.lLotsLID = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.txcmnt = new System.Windows.Forms.TextBox();
            this.msk_assdat = new System.Windows.Forms.MaskedTextBox();
            this.msk_pcbdat = new System.Windows.Forms.MaskedTextBox();
            this.lbcod = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txLotQty = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txLotPO = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.dp_grbDate = new System.Windows.Forms.DateTimePicker();
            this.ldp_grbDate = new System.Windows.Forms.TextBox();
            this.grbr_lver = new System.Windows.Forms.Label();
            this.tbomv = new System.Windows.Forms.TextBox();
            this.cbmodel = new System.Windows.Forms.ComboBox();
            this.dpRecpdat = new System.Windows.Forms.DateTimePicker();
            this.txR_date = new System.Windows.Forms.TextBox();
            this.grpConf.SuspendLayout();
            this.TSmain.SuspendLayout();
            this.grpLV.SuspendLayout();
            this.grpBrdSN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).BeginInit();
            this.SuspendLayout();
            // 
            // grpConf
            // 
            this.grpConf.Controls.Add(this.TSmain);
            this.grpConf.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConf.Location = new System.Drawing.Point(0, 0);
            this.grpConf.Name = "grpConf";
            this.grpConf.Size = new System.Drawing.Size(930, 68);
            this.grpConf.TabIndex = 241;
            this.grpConf.TabStop = false;
            // 
            // TSmain
            // 
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Newbrd,
            this.del_BRD,
            this.Sav_BRD,
            this.list_BI,
            this.exitt,
            this.toolStripButton1,
            this.toolStripButton2});
            this.TSmain.Location = new System.Drawing.Point(3, 16);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(924, 52);
            this.TSmain.TabIndex = 257;
            this.TSmain.Text = "toolStrip2";
            // 
            // Newbrd
            // 
      //      this.Newbrd.Image = global::PGESCOM.Properties.Resources.new_48x48;
            this.Newbrd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Newbrd.Name = "Newbrd";
            this.Newbrd.Size = new System.Drawing.Size(62, 49);
            this.Newbrd.Text = "New batch";
            this.Newbrd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Newbrd.ToolTipText = "New Batch";
            this.Newbrd.Click += new System.EventHandler(this.Newbrd_Click);
            // 
            // del_BRD
            // 
            this.del_BRD.Image = global::PGESCOM.Properties.Resources.remove1;
            this.del_BRD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del_BRD.Name = "del_BRD";
            this.del_BRD.Size = new System.Drawing.Size(72, 49);
            this.del_BRD.Text = "Delete batch";
            this.del_BRD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.del_BRD.ToolTipText = "Delete Batch";
            this.del_BRD.Click += new System.EventHandler(this.del_BRD_Click);
            // 
            // Sav_BRD
            // 
            this.Sav_BRD.Image = ((System.Drawing.Image)(resources.GetObject("Sav_BRD.Image")));
            this.Sav_BRD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Sav_BRD.Name = "Sav_BRD";
            this.Sav_BRD.Size = new System.Drawing.Size(65, 49);
            this.Sav_BRD.Text = "Save batch";
            this.Sav_BRD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Sav_BRD.ToolTipText = "Save Batch Info";
            this.Sav_BRD.Click += new System.EventHandler(this.Sav_BRD_Click);
            // 
            // list_BI
            // 
            this.list_BI.Image = global::PGESCOM.Properties.Resources.mac;
            this.list_BI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.list_BI.Name = "list_BI";
            this.list_BI.Size = new System.Drawing.Size(69, 49);
            this.list_BI.Text = "MAC Adress";
            this.list_BI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.list_BI.ToolTipText = "New MAC Adress";
            this.list_BI.Click += new System.EventHandler(this.list_BI_Click);
            // 
            // exitt
            // 
            this.exitt.Image = global::PGESCOM.Properties.Resources.Log_Off;
            this.exitt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitt.Name = "exitt";
            this.exitt.Size = new System.Drawing.Size(47, 49);
            this.exitt.Text = "   Exit   ";
            this.exitt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exitt.ToolTipText = "Exit";
            this.exitt.Click += new System.EventHandler(this.toolStripButton3_Click);
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
            // grpLV
            // 
            this.grpLV.Controls.Add(this.ed_lvBRD);
            this.grpLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLV.Location = new System.Drawing.Point(0, 159);
            this.grpLV.Name = "grpLV";
            this.grpLV.Size = new System.Drawing.Size(930, 297);
            this.grpLV.TabIndex = 244;
            this.grpLV.TabStop = false;
            // 
            // ed_lvBRD
            // 
            this.ed_lvBRD.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvBRD.AutoArrange = false;
            this.ed_lvBRD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ed_lvBRD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lotLID,
            this.datRecp,
            this.lotPO,
            this.Bver,
            this.BOMrev,
            this.PCBdat,
            this.Assmbdat,
            this.Qty,
            this.ccmnt});
            this.ed_lvBRD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_lvBRD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvBRD.ForeColor = System.Drawing.Color.Black;
            this.ed_lvBRD.FullRowSelect = true;
            this.ed_lvBRD.GridLines = true;
            this.ed_lvBRD.Location = new System.Drawing.Point(3, 16);
            this.ed_lvBRD.Name = "ed_lvBRD";
            this.ed_lvBRD.Size = new System.Drawing.Size(924, 278);
            this.ed_lvBRD.TabIndex = 250;
            this.ed_lvBRD.UseCompatibleStateImageBehavior = false;
            this.ed_lvBRD.View = System.Windows.Forms.View.Details;
            this.ed_lvBRD.SelectedIndexChanged += new System.EventHandler(this.ed_lvBRD_SelectedIndexChanged);
            this.ed_lvBRD.DoubleClick += new System.EventHandler(this.ed_lvBRD_DoubleClick);
            // 
            // lotLID
            // 
            this.lotLID.Text = "";
            this.lotLID.Width = 0;
            // 
            // datRecp
            // 
            this.datRecp.Text = "Reception date";
            this.datRecp.Width = 102;
            // 
            // lotPO
            // 
            this.lotPO.Text = "PO #";
            this.lotPO.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lotPO.Width = 135;
            // 
            // Bver
            // 
            this.Bver.Text = "Board Version";
            this.Bver.Width = 128;
            // 
            // BOMrev
            // 
            this.BOMrev.Text = "BOM revision";
            this.BOMrev.Width = 136;
            // 
            // PCBdat
            // 
            this.PCBdat.Text = "PCB date";
            this.PCBdat.Width = 75;
            // 
            // Assmbdat
            // 
            this.Assmbdat.Text = "Assembley Date";
            this.Assmbdat.Width = 92;
            // 
            // Qty
            // 
            this.Qty.Text = "";
            this.Qty.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Qty.Width = 0;
            // 
            // ccmnt
            // 
            this.ccmnt.Text = "Comments";
            this.ccmnt.Width = 229;
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.SystemColors.Control;
            this.label65.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label65.Location = new System.Drawing.Point(6, 11);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(63, 14);
            this.label65.TabIndex = 188;
            this.label65.Text = "Board Name:";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBrdDesc
            // 
            this.tBrdDesc.BackColor = System.Drawing.Color.AliceBlue;
            this.tBrdDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBrdDesc.ForeColor = System.Drawing.Color.DarkRed;
            this.tBrdDesc.Location = new System.Drawing.Point(75, 8);
            this.tBrdDesc.MaxLength = 49;
            this.tBrdDesc.Multiline = true;
            this.tBrdDesc.Name = "tBrdDesc";
            this.tBrdDesc.ReadOnly = true;
            this.tBrdDesc.Size = new System.Drawing.Size(157, 20);
            this.tBrdDesc.TabIndex = 189;
            // 
            // tbV
            // 
            this.tbV.BackColor = System.Drawing.Color.AliceBlue;
            this.tbV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbV.ForeColor = System.Drawing.Color.DarkRed;
            this.tbV.Location = new System.Drawing.Point(335, 48);
            this.tbV.MaxLength = 49;
            this.tbV.Multiline = true;
            this.tbV.Name = "tbV";
            this.tbV.Size = new System.Drawing.Size(206, 20);
            this.tbV.TabIndex = 197;
            this.tbV.Visible = false;
            // 
            // lbomRev
            // 
            this.lbomRev.BackColor = System.Drawing.SystemColors.Control;
            this.lbomRev.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbomRev.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbomRev.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lbomRev.Location = new System.Drawing.Point(457, 30);
            this.lbomRev.Name = "lbomRev";
            this.lbomRev.Size = new System.Drawing.Size(34, 14);
            this.lbomRev.TabIndex = 199;
            this.lbomRev.Text = "Rev.";
            this.lbomRev.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // grpBrdSN
            // 
            this.grpBrdSN.Controls.Add(this.CB_brd);
            this.grpBrdSN.Controls.Add(this.lotLid_CHS);
            this.grpBrdSN.Controls.Add(this.lmodelLID);
            this.grpBrdSN.Controls.Add(this.tbV);
            this.grpBrdSN.Controls.Add(this.msk_BomRev);
            this.grpBrdSN.Controls.Add(this.msk_grb_ver);
            this.grpBrdSN.Controls.Add(this.label10);
            this.grpBrdSN.Controls.Add(this.label8);
            this.grpBrdSN.Controls.Add(this.pictureBox11);
            this.grpBrdSN.Controls.Add(this.lLotsLID);
            this.grpBrdSN.Controls.Add(this.label7);
            this.grpBrdSN.Controls.Add(this.txcmnt);
            this.grpBrdSN.Controls.Add(this.msk_assdat);
            this.grpBrdSN.Controls.Add(this.msk_pcbdat);
            this.grpBrdSN.Controls.Add(this.lbcod);
            this.grpBrdSN.Controls.Add(this.label4);
            this.grpBrdSN.Controls.Add(this.txLotQty);
            this.grpBrdSN.Controls.Add(this.label6);
            this.grpBrdSN.Controls.Add(this.txLotPO);
            this.grpBrdSN.Controls.Add(this.label5);
            this.grpBrdSN.Controls.Add(this.label3);
            this.grpBrdSN.Controls.Add(this.label2);
            this.grpBrdSN.Controls.Add(this.label1);
            this.grpBrdSN.Controls.Add(this.label65);
            this.grpBrdSN.Controls.Add(this.lbomRev);
            this.grpBrdSN.Controls.Add(this.dp_grbDate);
            this.grpBrdSN.Controls.Add(this.ldp_grbDate);
            this.grpBrdSN.Controls.Add(this.grbr_lver);
            this.grpBrdSN.Controls.Add(this.tbomv);
            this.grpBrdSN.Controls.Add(this.cbmodel);
            this.grpBrdSN.Controls.Add(this.tBrdDesc);
            this.grpBrdSN.Controls.Add(this.dpRecpdat);
            this.grpBrdSN.Controls.Add(this.txR_date);
            this.grpBrdSN.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBrdSN.Location = new System.Drawing.Point(0, 68);
            this.grpBrdSN.Name = "grpBrdSN";
            this.grpBrdSN.Size = new System.Drawing.Size(930, 91);
            this.grpBrdSN.TabIndex = 243;
            this.grpBrdSN.TabStop = false;
            // 
            // CB_brd
            // 
            this.CB_brd.BackColor = System.Drawing.Color.Lavender;
            this.CB_brd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_brd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CB_brd.Location = new System.Drawing.Point(75, 8);
            this.CB_brd.Name = "CB_brd";
            this.CB_brd.Size = new System.Drawing.Size(157, 21);
            this.CB_brd.TabIndex = 330;
            this.CB_brd.SelectedIndexChanged += new System.EventHandler(this.CB_brd_SelectedIndexChanged);
            this.CB_brd.SelectedValueChanged += new System.EventHandler(this.CB_brd_SelectedValueChanged);
            // 
            // lotLid_CHS
            // 
            this.lotLid_CHS.BackColor = System.Drawing.Color.LimeGreen;
            this.lotLid_CHS.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lotLid_CHS.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lotLid_CHS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lotLid_CHS.Location = new System.Drawing.Point(398, 71);
            this.lotLid_CHS.Name = "lotLid_CHS";
            this.lotLid_CHS.Size = new System.Drawing.Size(25, 14);
            this.lotLid_CHS.TabIndex = 365;
            this.lotLid_CHS.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lotLid_CHS.Visible = false;
            // 
            // lmodelLID
            // 
            this.lmodelLID.BackColor = System.Drawing.Color.Brown;
            this.lmodelLID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lmodelLID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lmodelLID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lmodelLID.Location = new System.Drawing.Point(304, 71);
            this.lmodelLID.Name = "lmodelLID";
            this.lmodelLID.Size = new System.Drawing.Size(39, 14);
            this.lmodelLID.TabIndex = 364;
            this.lmodelLID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lmodelLID.UseWaitCursor = true;
            this.lmodelLID.Visible = false;
            // 
            // msk_BomRev
            // 
            this.msk_BomRev.BackColor = System.Drawing.Color.Lavender;
            this.msk_BomRev.Location = new System.Drawing.Point(491, 27);
            this.msk_BomRev.Mask = "0.0";
            this.msk_BomRev.Name = "msk_BomRev";
            this.msk_BomRev.Size = new System.Drawing.Size(50, 20);
            this.msk_BomRev.TabIndex = 363;
            this.msk_BomRev.Text = "00";
            this.msk_BomRev.TextChanged += new System.EventHandler(this.msk_BomRev_TextChanged);
            // 
            // msk_grb_ver
            // 
            this.msk_grb_ver.BackColor = System.Drawing.Color.Lavender;
            this.msk_grb_ver.Location = new System.Drawing.Point(371, 48);
            this.msk_grb_ver.Mask = "0.0";
            this.msk_grb_ver.Name = "msk_grb_ver";
            this.msk_grb_ver.Size = new System.Drawing.Size(40, 20);
            this.msk_grb_ver.TabIndex = 362;
            this.msk_grb_ver.Text = "00";
            this.msk_grb_ver.TextChanged += new System.EventHandler(this.msk_grb_ver_TextChanged);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label10.Location = new System.Drawing.Point(410, 51);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(42, 14);
            this.label10.TabIndex = 360;
            this.label10.Text = "date:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(248, 51);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(81, 14);
            this.label8.TabIndex = 355;
            this.label8.Text = "Gerber Rev:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox11
            // 
            this.pictureBox11.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox11.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox11.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox11.Image")));
            this.pictureBox11.Location = new System.Drawing.Point(756, 11);
            this.pictureBox11.Name = "pictureBox11";
            this.pictureBox11.Size = new System.Drawing.Size(168, 74);
            this.pictureBox11.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox11.TabIndex = 354;
            this.pictureBox11.TabStop = false;
            // 
            // lLotsLID
            // 
            this.lLotsLID.BackColor = System.Drawing.Color.Brown;
            this.lLotsLID.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lLotsLID.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lLotsLID.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lLotsLID.Location = new System.Drawing.Point(232, 72);
            this.lLotsLID.Name = "lLotsLID";
            this.lLotsLID.Size = new System.Drawing.Size(25, 14);
            this.lLotsLID.TabIndex = 353;
            this.lLotsLID.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lLotsLID.Visible = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(547, 8);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 14);
            this.label7.TabIndex = 351;
            this.label7.Text = "Comment:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txcmnt
            // 
            this.txcmnt.BackColor = System.Drawing.Color.Lavender;
            this.txcmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txcmnt.ForeColor = System.Drawing.Color.DarkRed;
            this.txcmnt.Location = new System.Drawing.Point(550, 22);
            this.txcmnt.MaxLength = 49;
            this.txcmnt.Multiline = true;
            this.txcmnt.Name = "txcmnt";
            this.txcmnt.Size = new System.Drawing.Size(200, 64);
            this.txcmnt.TabIndex = 350;
            // 
            // msk_assdat
            // 
            this.msk_assdat.BackColor = System.Drawing.Color.Lavender;
            this.msk_assdat.Location = new System.Drawing.Point(501, 8);
            this.msk_assdat.Mask = "00-00";
            this.msk_assdat.Name = "msk_assdat";
            this.msk_assdat.Size = new System.Drawing.Size(40, 20);
            this.msk_assdat.TabIndex = 349;
            this.msk_assdat.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // msk_pcbdat
            // 
            this.msk_pcbdat.BackColor = System.Drawing.Color.Lavender;
            this.msk_pcbdat.Location = new System.Drawing.Point(335, 8);
            this.msk_pcbdat.Mask = "00-00";
            this.msk_pcbdat.Name = "msk_pcbdat";
            this.msk_pcbdat.Size = new System.Drawing.Size(40, 20);
            this.msk_pcbdat.TabIndex = 348;
            this.msk_pcbdat.TextMaskFormat = System.Windows.Forms.MaskFormat.IncludePromptAndLiterals;
            // 
            // lbcod
            // 
            this.lbcod.BackColor = System.Drawing.Color.Lavender;
            this.lbcod.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbcod.ForeColor = System.Drawing.Color.DarkRed;
            this.lbcod.Location = new System.Drawing.Point(3, 19);
            this.lbcod.MaxLength = 49;
            this.lbcod.Multiline = true;
            this.lbcod.Name = "lbcod";
            this.lbcod.ReadOnly = true;
            this.lbcod.Size = new System.Drawing.Size(14, 20);
            this.lbcod.TabIndex = 347;
            this.lbcod.Visible = false;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(61, 72);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 14);
            this.label4.TabIndex = 346;
            this.label4.Text = "Qty:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label4.Visible = false;
            // 
            // txLotQty
            // 
            this.txLotQty.BackColor = System.Drawing.Color.Lavender;
            this.txLotQty.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txLotQty.ForeColor = System.Drawing.Color.DarkRed;
            this.txLotQty.Location = new System.Drawing.Point(97, 69);
            this.txLotQty.MaxLength = 49;
            this.txLotQty.Multiline = true;
            this.txLotQty.Name = "txLotQty";
            this.txLotQty.Size = new System.Drawing.Size(47, 20);
            this.txLotQty.TabIndex = 345;
            this.txLotQty.Text = "0";
            this.txLotQty.Visible = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(46, 52);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(51, 14);
            this.label6.TabIndex = 342;
            this.label6.Text = "Lot PO#:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txLotPO
            // 
            this.txLotPO.BackColor = System.Drawing.Color.Lavender;
            this.txLotPO.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txLotPO.ForeColor = System.Drawing.Color.DarkRed;
            this.txLotPO.Location = new System.Drawing.Point(97, 49);
            this.txLotPO.MaxLength = 49;
            this.txLotPO.Multiline = true;
            this.txLotPO.Name = "txLotPO";
            this.txLotPO.Size = new System.Drawing.Size(135, 20);
            this.txLotPO.TabIndex = 341;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(15, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 14);
            this.label5.TabIndex = 340;
            this.label5.Text = "Reception Date:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(381, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 14);
            this.label3.TabIndex = 210;
            this.label3.Text = "Assembly date (ww-yy):";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(254, 32);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 14);
            this.label2.TabIndex = 208;
            this.label2.Text = "BOM revision:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(232, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 14);
            this.label1.TabIndex = 206;
            this.label1.Text = "PCB date (ww-yy):";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dp_grbDate
            // 
            this.dp_grbDate.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dp_grbDate.CalendarTitleBackColor = System.Drawing.Color.Lavender;
            this.dp_grbDate.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dp_grbDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dp_grbDate.Location = new System.Drawing.Point(452, 48);
            this.dp_grbDate.Name = "dp_grbDate";
            this.dp_grbDate.Size = new System.Drawing.Size(89, 20);
            this.dp_grbDate.TabIndex = 361;
            this.dp_grbDate.ValueChanged += new System.EventHandler(this.dp_grbDate_ValueChanged);
            // 
            // ldp_grbDate
            // 
            this.ldp_grbDate.BackColor = System.Drawing.Color.Lavender;
            this.ldp_grbDate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ldp_grbDate.ForeColor = System.Drawing.Color.DarkRed;
            this.ldp_grbDate.Location = new System.Drawing.Point(452, 48);
            this.ldp_grbDate.MaxLength = 49;
            this.ldp_grbDate.Multiline = true;
            this.ldp_grbDate.Name = "ldp_grbDate";
            this.ldp_grbDate.Size = new System.Drawing.Size(89, 20);
            this.ldp_grbDate.TabIndex = 359;
            this.ldp_grbDate.TextChanged += new System.EventHandler(this.ldp_grbDate_TextChanged);
            // 
            // grbr_lver
            // 
            this.grbr_lver.BackColor = System.Drawing.Color.Lavender;
            this.grbr_lver.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.grbr_lver.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grbr_lver.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grbr_lver.ForeColor = System.Drawing.SystemColors.ControlText;
            this.grbr_lver.Location = new System.Drawing.Point(335, 48);
            this.grbr_lver.Name = "grbr_lver";
            this.grbr_lver.Size = new System.Drawing.Size(36, 20);
            this.grbr_lver.TabIndex = 358;
            this.grbr_lver.Text = "Rev.";
            this.grbr_lver.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tbomv
            // 
            this.tbomv.BackColor = System.Drawing.Color.AliceBlue;
            this.tbomv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbomv.ForeColor = System.Drawing.Color.DarkRed;
            this.tbomv.Location = new System.Drawing.Point(335, 28);
            this.tbomv.MaxLength = 49;
            this.tbomv.Multiline = true;
            this.tbomv.Name = "tbomv";
            this.tbomv.Size = new System.Drawing.Size(206, 20);
            this.tbomv.TabIndex = 207;
            this.tbomv.Visible = false;
            // 
            // cbmodel
            // 
            this.cbmodel.BackColor = System.Drawing.Color.Lavender;
            this.cbmodel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbmodel.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbmodel.Location = new System.Drawing.Point(335, 27);
            this.cbmodel.Name = "cbmodel";
            this.cbmodel.Size = new System.Drawing.Size(122, 21);
            this.cbmodel.TabIndex = 356;
            this.cbmodel.SelectedIndexChanged += new System.EventHandler(this.cbmodel_SelectedIndexChanged);
            // 
            // dpRecpdat
            // 
            this.dpRecpdat.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dpRecpdat.CalendarTitleBackColor = System.Drawing.Color.Lavender;
            this.dpRecpdat.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dpRecpdat.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpRecpdat.Location = new System.Drawing.Point(97, 28);
            this.dpRecpdat.Name = "dpRecpdat";
            this.dpRecpdat.Size = new System.Drawing.Size(135, 20);
            this.dpRecpdat.TabIndex = 352;
            this.dpRecpdat.ValueChanged += new System.EventHandler(this.dpRecpdat_ValueChanged);
            // 
            // txR_date
            // 
            this.txR_date.BackColor = System.Drawing.Color.Lavender;
            this.txR_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txR_date.ForeColor = System.Drawing.Color.DarkRed;
            this.txR_date.Location = new System.Drawing.Point(97, 29);
            this.txR_date.MaxLength = 49;
            this.txR_date.Multiline = true;
            this.txR_date.Name = "txR_date";
            this.txR_date.Size = new System.Drawing.Size(135, 20);
            this.txR_date.TabIndex = 339;
            // 
            // Orders_BoardLots
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 456);
            this.Controls.Add(this.grpLV);
            this.Controls.Add(this.grpBrdSN);
            this.Controls.Add(this.grpConf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Orders_BoardLots";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Boards Batch General Info";
            this.Load += new System.EventHandler(this.Orders_Boards_Load);
            this.grpConf.ResumeLayout(false);
            this.grpConf.PerformLayout();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.grpLV.ResumeLayout(false);
            this.grpBrdSN.ResumeLayout(false);
            this.grpBrdSN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox11)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConf;
        private System.Windows.Forms.ToolStrip TSmain;
        private System.Windows.Forms.ToolStripButton Newbrd;
        private System.Windows.Forms.ToolStripButton del_BRD;
        private System.Windows.Forms.ToolStripButton Sav_BRD;
        private System.Windows.Forms.ToolStripButton list_BI;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox grpLV;
        private ed_LVmodif ed_lvBRD;
        private System.Windows.Forms.ColumnHeader lotLID;
        private System.Windows.Forms.ColumnHeader datRecp;
        private System.Windows.Forms.ColumnHeader lotPO;
        private System.Windows.Forms.ColumnHeader Qty;
        private System.Windows.Forms.ColumnHeader Bver;
        private System.Windows.Forms.Label label65;
        public System.Windows.Forms.TextBox tBrdDesc;
        public System.Windows.Forms.TextBox tbV;
        private System.Windows.Forms.Label lbomRev;
        private System.Windows.Forms.GroupBox grpBrdSN;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.TextBox tbomv;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ColumnHeader BOMrev;
        private System.Windows.Forms.ColumnHeader PCBdat;
        private System.Windows.Forms.ColumnHeader Assmbdat;
        public System.Windows.Forms.ComboBox CB_brd;
        public System.Windows.Forms.TextBox txR_date;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.TextBox txLotPO;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txLotQty;
        public System.Windows.Forms.TextBox lbcod;
        private System.Windows.Forms.MaskedTextBox msk_assdat;
        private System.Windows.Forms.MaskedTextBox msk_pcbdat;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txcmnt;
        public System.Windows.Forms.DateTimePicker dpRecpdat;
        private System.Windows.Forms.ColumnHeader ccmnt;
        private System.Windows.Forms.Label lLotsLID;
        private System.Windows.Forms.PictureBox pictureBox11;
        private System.Windows.Forms.Label label8;
        public System.Windows.Forms.ComboBox cbmodel;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.DateTimePicker dp_grbDate;
        public System.Windows.Forms.TextBox ldp_grbDate;
        private System.Windows.Forms.Label grbr_lver;
        private System.Windows.Forms.MaskedTextBox msk_grb_ver;
        private System.Windows.Forms.MaskedTextBox msk_BomRev;
        private System.Windows.Forms.Label lmodelLID;
        private System.Windows.Forms.ToolStripButton exitt;
        public System.Windows.Forms.Label lotLid_CHS;
    }
}