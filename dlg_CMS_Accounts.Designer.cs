namespace PGESCOM
{
    partial class dlg_CMS_Accounts
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlg_CMS_Accounts));
            this.grpConf = new System.Windows.Forms.GroupBox();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.cb_AGTerr = new System.Windows.Forms.ToolStrip();
            this.Disp_acct = new System.Windows.Forms.ToolStripButton();
            this.NewItm = new System.Windows.Forms.ToolStripButton();
            this.btn_Payer = new System.Windows.Forms.ToolStripButton();
            this.list_BI = new System.Windows.Forms.ToolStripButton();
            this.exitt = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.grpLV = new System.Windows.Forms.GroupBox();
            this.ed_lvITM = new PGESCOM.ed_LVmodif();
            this.lid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.t_date = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.t_desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.amt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sld = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cmnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.trs = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpITM = new System.Windows.Forms.GroupBox();
            this.txRef_sold = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dpFrom = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.lSA_ID = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Lrrevlid = new System.Windows.Forms.Label();
            this.cbSA = new System.Windows.Forms.ComboBox();
            this.lcbSA = new System.Windows.Forms.TextBox();
            this.grpBal = new System.Windows.Forms.GroupBox();
            this.picSavBAL = new System.Windows.Forms.PictureBox();
            this.tBAL_amnt = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.grpPay = new System.Windows.Forms.GroupBox();
            this.lpayid = new System.Windows.Forms.Label();
            this.tcmntPAy = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.dpPaydate = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.picSavPAY = new System.Windows.Forms.PictureBox();
            this.tpay_Amnt = new System.Windows.Forms.TextBox();
            this.label35 = new System.Windows.Forms.Label();
            this.grpConf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.cb_AGTerr.SuspendLayout();
            this.grpLV.SuspendLayout();
            this.grpITM.SuspendLayout();
            this.grpBal.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSavBAL)).BeginInit();
            this.grpPay.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSavPAY)).BeginInit();
            this.SuspendLayout();
            // 
            // grpConf
            // 
            this.grpConf.Controls.Add(this.picCIP);
            this.grpConf.Controls.Add(this.cb_AGTerr);
            this.grpConf.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConf.Location = new System.Drawing.Point(0, 0);
            this.grpConf.Name = "grpConf";
            this.grpConf.Size = new System.Drawing.Size(909, 84);
            this.grpConf.TabIndex = 241;
            this.grpConf.TabStop = false;
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(594, 31);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(39, 37);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 268;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // cb_AGTerr
            // 
            this.cb_AGTerr.ImageScalingSize = new System.Drawing.Size(48, 48);
            this.cb_AGTerr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Disp_acct,
            this.NewItm,
            this.btn_Payer,
            this.list_BI,
            this.exitt,
            this.toolStripButton1,
            this.toolStripButton2});
            this.cb_AGTerr.Location = new System.Drawing.Point(3, 16);
            this.cb_AGTerr.Name = "cb_AGTerr";
            this.cb_AGTerr.Size = new System.Drawing.Size(903, 70);
            this.cb_AGTerr.TabIndex = 257;
            this.cb_AGTerr.Text = "toolStrip2";
            // 
            // Disp_acct
            // 
       //     this.Disp_acct.Image = global::PGESCOM.Properties.Resources.K013;
            this.Disp_acct.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Disp_acct.Name = "Disp_acct";
            this.Disp_acct.Size = new System.Drawing.Size(97, 67);
            this.Disp_acct.Text = "Display Account";
            this.Disp_acct.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Disp_acct.ToolTipText = "Delete";
            this.Disp_acct.Click += new System.EventHandler(this.Disp_acct_Click);
            // 
            // NewItm
            // 
            this.NewItm.Image = global::PGESCOM.Properties.Resources.new_48x48;
            this.NewItm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewItm.Name = "NewItm";
            this.NewItm.Size = new System.Drawing.Size(79, 67);
            this.NewItm.Text = "New Balance";
            this.NewItm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NewItm.ToolTipText = "New";
            this.NewItm.Visible = false;
            this.NewItm.Click += new System.EventHandler(this.NewItm_Click);
            // 
            // btn_Payer
            // 
         //   this.btn_Payer.Image = global::PGESCOM.Properties.Resources.cheques1;
            this.btn_Payer.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btn_Payer.Name = "btn_Payer";
            this.btn_Payer.Size = new System.Drawing.Size(131, 67);
            this.btn_Payer.Text = "Commission Paiement";
            this.btn_Payer.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.btn_Payer.ToolTipText = "Commissions Paiement";
            this.btn_Payer.Visible = false;
            this.btn_Payer.Click += new System.EventHandler(this.Payer_Click);
            // 
            // list_BI
            // 
            this.list_BI.Image = global::PGESCOM.Properties.Resources.mac;
            this.list_BI.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.list_BI.Name = "list_BI";
            this.list_BI.Size = new System.Drawing.Size(76, 67);
            this.list_BI.Text = "MAC Adress";
            this.list_BI.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.list_BI.ToolTipText = "New MAC Adress";
            this.list_BI.Visible = false;
            // 
            // exitt
            // 
            this.exitt.Image = global::PGESCOM.Properties.Resources.Log_Off;
            this.exitt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitt.Name = "exitt";
            this.exitt.Size = new System.Drawing.Size(52, 67);
            this.exitt.Text = "   Exit   ";
            this.exitt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exitt.ToolTipText = "Exit";
            this.exitt.Click += new System.EventHandler(this.exitt_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = global::PGESCOM.Properties.Resources.folder_full_accept;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(52, 67);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Visible = false;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = global::PGESCOM.Properties.Resources.folder_full_delete;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(52, 67);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Visible = false;
            // 
            // grpLV
            // 
            this.grpLV.Controls.Add(this.ed_lvITM);
            this.grpLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLV.Location = new System.Drawing.Point(0, 246);
            this.grpLV.Name = "grpLV";
            this.grpLV.Size = new System.Drawing.Size(909, 343);
            this.grpLV.TabIndex = 244;
            this.grpLV.TabStop = false;
            // 
            // ed_lvITM
            // 
            this.ed_lvITM.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvITM.AutoArrange = false;
            this.ed_lvITM.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ed_lvITM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lid,
            this.t_date,
            this.t_desc,
            this.amt,
            this.sld,
            this.cmnt,
            this.trs});
            this.ed_lvITM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_lvITM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvITM.ForeColor = System.Drawing.Color.Black;
            this.ed_lvITM.FullRowSelect = true;
            this.ed_lvITM.GridLines = true;
            this.ed_lvITM.Location = new System.Drawing.Point(3, 16);
            this.ed_lvITM.Name = "ed_lvITM";
            this.ed_lvITM.Size = new System.Drawing.Size(903, 324);
            this.ed_lvITM.TabIndex = 250;
            this.ed_lvITM.UseCompatibleStateImageBehavior = false;
            this.ed_lvITM.View = System.Windows.Forms.View.Details;
            this.ed_lvITM.SelectedIndexChanged += new System.EventHandler(this.ed_lvITM_SelectedIndexChanged_2);
            this.ed_lvITM.DoubleClick += new System.EventHandler(this.ed_lvITM_DoubleClick);
            // 
            // lid
            // 
            this.lid.Text = "";
            this.lid.Width = 0;
            // 
            // t_date
            // 
            this.t_date.Text = "Date";
            this.t_date.Width = 86;
            // 
            // t_desc
            // 
            this.t_desc.Text = "Description";
            this.t_desc.Width = 262;
            // 
            // amt
            // 
            this.amt.Text = "Amount";
            this.amt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.amt.Width = 109;
            // 
            // sld
            // 
            this.sld.Text = "Balance";
            this.sld.Width = 91;
            // 
            // cmnt
            // 
            this.cmnt.Text = "Comments";
            this.cmnt.Width = 293;
            // 
            // trs
            // 
            this.trs.Text = "";
            this.trs.Width = 0;
            // 
            // grpITM
            // 
            this.grpITM.Controls.Add(this.txRef_sold);
            this.grpITM.Controls.Add(this.label6);
            this.grpITM.Controls.Add(this.dpFrom);
            this.grpITM.Controls.Add(this.label2);
            this.grpITM.Controls.Add(this.lSA_ID);
            this.grpITM.Controls.Add(this.label1);
            this.grpITM.Controls.Add(this.Lrrevlid);
            this.grpITM.Controls.Add(this.cbSA);
            this.grpITM.Controls.Add(this.lcbSA);
            this.grpITM.Controls.Add(this.grpPay);
            this.grpITM.Controls.Add(this.grpBal);
            this.grpITM.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpITM.Location = new System.Drawing.Point(0, 84);
            this.grpITM.Name = "grpITM";
            this.grpITM.Size = new System.Drawing.Size(909, 162);
            this.grpITM.TabIndex = 243;
            this.grpITM.TabStop = false;
            // 
            // txRef_sold
            // 
            this.txRef_sold.BackColor = System.Drawing.Color.Lavender;
            this.txRef_sold.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txRef_sold.Location = new System.Drawing.Point(705, 15);
            this.txRef_sold.Name = "txRef_sold";
            this.txRef_sold.ReadOnly = true;
            this.txRef_sold.Size = new System.Drawing.Size(178, 23);
            this.txRef_sold.TabIndex = 483;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(606, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(99, 20);
            this.label6.TabIndex = 484;
            this.label6.Text = "Balance:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dpFrom
            // 
            this.dpFrom.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpFrom.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dpFrom.CalendarTitleBackColor = System.Drawing.Color.Lavender;
            this.dpFrom.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dpFrom.Enabled = false;
            this.dpFrom.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpFrom.Location = new System.Drawing.Point(81, 14);
            this.dpFrom.Name = "dpFrom";
            this.dpFrom.Size = new System.Drawing.Size(104, 20);
            this.dpFrom.TabIndex = 480;
            this.dpFrom.Value = new System.DateTime(2009, 3, 31, 0, 0, 0, 0);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 9F);
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(5, 14);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(76, 20);
            this.label2.TabIndex = 479;
            this.label2.Text = "From date:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lSA_ID
            // 
            this.lSA_ID.BackColor = System.Drawing.Color.Red;
            this.lSA_ID.Location = new System.Drawing.Point(174, 3);
            this.lSA_ID.Name = "lSA_ID";
            this.lSA_ID.Size = new System.Drawing.Size(18, 15);
            this.lSA_ID.TabIndex = 478;
            this.lSA_ID.Text = "0";
            this.lSA_ID.Visible = false;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9F);
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(185, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 468;
            this.label1.Text = "Sale / Agency:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Lrrevlid
            // 
            this.Lrrevlid.BackColor = System.Drawing.Color.Salmon;
            this.Lrrevlid.Location = new System.Drawing.Point(887, -6);
            this.Lrrevlid.Name = "Lrrevlid";
            this.Lrrevlid.Size = new System.Drawing.Size(11, 17);
            this.Lrrevlid.TabIndex = 404;
            this.Lrrevlid.Text = "0";
            this.Lrrevlid.Visible = false;
            // 
            // cbSA
            // 
            this.cbSA.BackColor = System.Drawing.Color.Lavender;
            this.cbSA.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbSA.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbSA.Location = new System.Drawing.Point(291, 14);
            this.cbSA.Name = "cbSA";
            this.cbSA.Size = new System.Drawing.Size(306, 21);
            this.cbSA.TabIndex = 467;
            this.cbSA.SelectedIndexChanged += new System.EventHandler(this.cbSA_SelectedIndexChanged);
            // 
            // lcbSA
            // 
            this.lcbSA.BackColor = System.Drawing.Color.AliceBlue;
            this.lcbSA.Location = new System.Drawing.Point(291, 14);
            this.lcbSA.Name = "lcbSA";
            this.lcbSA.ReadOnly = true;
            this.lcbSA.Size = new System.Drawing.Size(306, 20);
            this.lcbSA.TabIndex = 469;
            // 
            // grpBal
            // 
            this.grpBal.Controls.Add(this.picSavBAL);
            this.grpBal.Controls.Add(this.tBAL_amnt);
            this.grpBal.Controls.Add(this.label3);
            this.grpBal.Location = new System.Drawing.Point(6, 56);
            this.grpBal.Name = "grpBal";
            this.grpBal.Size = new System.Drawing.Size(323, 68);
            this.grpBal.TabIndex = 482;
            this.grpBal.TabStop = false;
            this.grpBal.Visible = false;
            // 
            // picSavBAL
            // 
            this.picSavBAL.Cursor = System.Windows.Forms.Cursors.Hand;
           // this.picSavBAL.Image = global::PGESCOM.Properties.Resources._1__7_;
            this.picSavBAL.Location = new System.Drawing.Point(238, 10);
            this.picSavBAL.Name = "picSavBAL";
            this.picSavBAL.Size = new System.Drawing.Size(67, 51);
            this.picSavBAL.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSavBAL.TabIndex = 468;
            this.picSavBAL.TabStop = false;
            this.picSavBAL.Click += new System.EventHandler(this.picSavBAL_Click);
            // 
            // tBAL_amnt
            // 
            this.tBAL_amnt.BackColor = System.Drawing.Color.Lavender;
            this.tBAL_amnt.Location = new System.Drawing.Point(107, 24);
            this.tBAL_amnt.Name = "tBAL_amnt";
            this.tBAL_amnt.Size = new System.Drawing.Size(125, 20);
            this.tBAL_amnt.TabIndex = 464;
            this.tBAL_amnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tBAL_amnt_KeyPress);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(8, 24);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 20);
            this.label3.TabIndex = 467;
            this.label3.Text = "New Balance:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // grpPay
            // 
            this.grpPay.Controls.Add(this.dpPaydate);
            this.grpPay.Controls.Add(this.lpayid);
            this.grpPay.Controls.Add(this.tcmntPAy);
            this.grpPay.Controls.Add(this.label5);
            this.grpPay.Controls.Add(this.label4);
            this.grpPay.Controls.Add(this.picSavPAY);
            this.grpPay.Controls.Add(this.tpay_Amnt);
            this.grpPay.Controls.Add(this.label35);
            this.grpPay.Location = new System.Drawing.Point(6, 56);
            this.grpPay.Name = "grpPay";
            this.grpPay.Size = new System.Drawing.Size(798, 100);
            this.grpPay.TabIndex = 481;
            this.grpPay.TabStop = false;
            this.grpPay.Visible = false;
            // 
            // lpayid
            // 
            this.lpayid.BackColor = System.Drawing.Color.Red;
            this.lpayid.Location = new System.Drawing.Point(45, 55);
            this.lpayid.Name = "lpayid";
            this.lpayid.Size = new System.Drawing.Size(18, 15);
            this.lpayid.TabIndex = 485;
            this.lpayid.Text = "0";
            this.lpayid.Visible = false;
            // 
            // tcmntPAy
            // 
            this.tcmntPAy.BackColor = System.Drawing.Color.Lavender;
            this.tcmntPAy.Location = new System.Drawing.Point(90, 31);
            this.tcmntPAy.Multiline = true;
            this.tcmntPAy.Name = "tcmntPAy";
            this.tcmntPAy.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.tcmntPAy.Size = new System.Drawing.Size(620, 56);
            this.tcmntPAy.TabIndex = 483;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(6, 35);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(84, 20);
            this.label5.TabIndex = 484;
            this.label5.Text = "Comments:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dpPaydate
            // 
            this.dpPaydate.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dpPaydate.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dpPaydate.CalendarTitleBackColor = System.Drawing.Color.Lavender;
            this.dpPaydate.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dpPaydate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpPaydate.Location = new System.Drawing.Point(90, 11);
            this.dpPaydate.Name = "dpPaydate";
            this.dpPaydate.Size = new System.Drawing.Size(104, 20);
            this.dpPaydate.TabIndex = 482;
            this.dpPaydate.Value = new System.DateTime(2009, 3, 31, 0, 0, 0, 0);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 9F);
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(45, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 20);
            this.label4.TabIndex = 481;
            this.label4.Text = "Date:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picSavPAY
            // 
            this.picSavPAY.Cursor = System.Windows.Forms.Cursors.Hand;
        //    this.picSavPAY.Image = global::PGESCOM.Properties.Resources._1__7_;
            this.picSavPAY.Location = new System.Drawing.Point(716, 19);
            this.picSavPAY.Name = "picSavPAY";
            this.picSavPAY.Size = new System.Drawing.Size(72, 68);
            this.picSavPAY.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSavPAY.TabIndex = 468;
            this.picSavPAY.TabStop = false;
            this.picSavPAY.Click += new System.EventHandler(this.picSavPAY_Click);
            // 
            // tpay_Amnt
            // 
            this.tpay_Amnt.BackColor = System.Drawing.Color.Lavender;
            this.tpay_Amnt.Location = new System.Drawing.Point(259, 11);
            this.tpay_Amnt.Name = "tpay_Amnt";
            this.tpay_Amnt.Size = new System.Drawing.Size(156, 20);
            this.tpay_Amnt.TabIndex = 464;
            this.tpay_Amnt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tpay_Amnt_KeyPress);
            // 
            // label35
            // 
            this.label35.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label35.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label35.Location = new System.Drawing.Point(194, 11);
            this.label35.Name = "label35";
            this.label35.Size = new System.Drawing.Size(65, 20);
            this.label35.TabIndex = 467;
            this.label35.Text = "Amount:";
            this.label35.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dlg_CMS_Accounts
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(909, 589);
            this.Controls.Add(this.grpLV);
            this.Controls.Add(this.grpITM);
            this.Controls.Add(this.grpConf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "dlg_CMS_Accounts";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Commissions Accounts";
            this.Load += new System.EventHandler(this.dlg_CMS_Accounts_Load);
            this.grpConf.ResumeLayout(false);
            this.grpConf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.cb_AGTerr.ResumeLayout(false);
            this.cb_AGTerr.PerformLayout();
            this.grpLV.ResumeLayout(false);
            this.grpITM.ResumeLayout(false);
            this.grpITM.PerformLayout();
            this.grpBal.ResumeLayout(false);
            this.grpBal.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSavBAL)).EndInit();
            this.grpPay.ResumeLayout(false);
            this.grpPay.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSavPAY)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConf;
        private System.Windows.Forms.ToolStrip cb_AGTerr;
        private System.Windows.Forms.ToolStripButton NewItm;
        private System.Windows.Forms.ToolStripButton Disp_acct;
        private System.Windows.Forms.ToolStripButton btn_Payer;
        private System.Windows.Forms.ToolStripButton list_BI;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox grpLV;
        private ed_LVmodif ed_lvITM;
        private System.Windows.Forms.ColumnHeader lid;
        private System.Windows.Forms.ColumnHeader sld;
        private System.Windows.Forms.ColumnHeader t_desc;
        private System.Windows.Forms.ColumnHeader amt;
        private System.Windows.Forms.GroupBox grpITM;
        private System.Windows.Forms.ToolStripButton exitt;
        public System.Windows.Forms.PictureBox picCIP;
        private System.Windows.Forms.Label Lrrevlid;
        private System.Windows.Forms.ColumnHeader cmnt;
        private System.Windows.Forms.ColumnHeader t_date;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.ComboBox cbSA;
        private System.Windows.Forms.TextBox lcbSA;
        public System.Windows.Forms.TextBox tpay_Amnt;
        private System.Windows.Forms.Label label35;
        private System.Windows.Forms.Label lSA_ID;
        public System.Windows.Forms.DateTimePicker dpFrom;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ColumnHeader trs;
        private System.Windows.Forms.GroupBox grpPay;
        public System.Windows.Forms.PictureBox picSavPAY;
        private System.Windows.Forms.GroupBox grpBal;
        public System.Windows.Forms.PictureBox picSavBAL;
        public System.Windows.Forms.TextBox tBAL_amnt;
        private System.Windows.Forms.Label label3;
        public System.Windows.Forms.TextBox tcmntPAy;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DateTimePicker dpPaydate;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox txRef_sold;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lpayid;
    }
}