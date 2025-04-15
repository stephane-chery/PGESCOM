namespace PGESCOM
{
    partial class Setng_002
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setng_002));
            this.grpConf = new System.Windows.Forms.GroupBox();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.NewItm = new System.Windows.Forms.ToolStripButton();
            this.Sav_Itm = new System.Windows.Forms.ToolStripButton();
            this.del_BRD = new System.Windows.Forms.ToolStripButton();
            this.exitt = new System.Windows.Forms.ToolStripButton();
            this.grpITM = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbCurr = new System.Windows.Forms.ComboBox();
            this.picNew = new System.Windows.Forms.PictureBox();
            this.label5 = new System.Windows.Forms.Label();
            this.lCurr = new System.Windows.Forms.Label();
            this.txcmnt = new System.Windows.Forms.TextBox();
            this.label27 = new System.Windows.Forms.Label();
            this.txR_date = new System.Windows.Forms.TextBox();
            this.dpdate = new System.Windows.Forms.DateTimePicker();
            this.grpLV = new System.Windows.Forms.GroupBox();
            this.ed_lvITM = new PGESCOM.ed_LVmodif();
            this.lotLID = new System.Windows.Forms.ColumnHeader();
            this.d1 = new System.Windows.Forms.ColumnHeader();
            this.x = new System.Windows.Forms.ColumnHeader();
            this.ccmnt = new System.Windows.Forms.ColumnHeader();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.grpConf.SuspendLayout();
            this.TSmain.SuspendLayout();
            this.grpITM.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).BeginInit();
            this.grpLV.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.SuspendLayout();
            // 
            // grpConf
            // 
            this.grpConf.Controls.Add(this.picCIP);
            this.grpConf.Controls.Add(this.TSmain);
            this.grpConf.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConf.Location = new System.Drawing.Point(0, 0);
            this.grpConf.Name = "grpConf";
            this.grpConf.Size = new System.Drawing.Size(507, 68);
            this.grpConf.TabIndex = 241;
            this.grpConf.TabStop = false;
            // 
            // TSmain
            // 
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewItm,
            this.Sav_Itm,
            this.del_BRD,
            this.exitt});
            this.TSmain.Location = new System.Drawing.Point(3, 16);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(501, 52);
            this.TSmain.TabIndex = 257;
            this.TSmain.Text = "toolStrip2";
            // 
            // NewItm
            // 
        //    this.NewItm.Image = global::PGESCOM.Properties.Resources.new_48x48;
            this.NewItm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewItm.Name = "NewItm";
            this.NewItm.Size = new System.Drawing.Size(58, 49);
            this.NewItm.Text = "New Rate";
            this.NewItm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NewItm.ToolTipText = "New";
            this.NewItm.Visible = false;
            this.NewItm.Click += new System.EventHandler(this.NewItm_Click);
            // 
            // Sav_Itm
            // 
            this.Sav_Itm.Image = ((System.Drawing.Image)(resources.GetObject("Sav_Itm.Image")));
            this.Sav_Itm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Sav_Itm.Name = "Sav_Itm";
            this.Sav_Itm.Size = new System.Drawing.Size(59, 49);
            this.Sav_Itm.Text = "   Save     ";
            this.Sav_Itm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Sav_Itm.ToolTipText = "Save";
            this.Sav_Itm.Click += new System.EventHandler(this.Sav_Itm_Click);
            // 
            // del_BRD
            // 
            this.del_BRD.Image = global::PGESCOM.Properties.Resources.remove1;
            this.del_BRD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del_BRD.Name = "del_BRD";
            this.del_BRD.Size = new System.Drawing.Size(42, 49);
            this.del_BRD.Text = "Delete";
            this.del_BRD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.del_BRD.ToolTipText = "Delete Batch";
            this.del_BRD.Click += new System.EventHandler(this.del_BRD_Click);
            // 
            // exitt
            // 
            this.exitt.Image = global::PGESCOM.Properties.Resources.Log_Off;
            this.exitt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitt.Name = "exitt";
            this.exitt.Size = new System.Drawing.Size(59, 49);
            this.exitt.Text = "     Exit     ";
            this.exitt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exitt.ToolTipText = "Exit";
            this.exitt.Click += new System.EventHandler(this.exitt_Click);
            // 
            // grpITM
            // 
            this.grpITM.Controls.Add(this.label6);
            this.grpITM.Controls.Add(this.cbCurr);
            this.grpITM.Controls.Add(this.picNew);
            this.grpITM.Controls.Add(this.label5);
            this.grpITM.Controls.Add(this.lCurr);
            this.grpITM.Controls.Add(this.txcmnt);
            this.grpITM.Controls.Add(this.label27);
            this.grpITM.Controls.Add(this.txR_date);
            this.grpITM.Controls.Add(this.dpdate);
            this.grpITM.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpITM.Location = new System.Drawing.Point(0, 68);
            this.grpITM.Name = "grpITM";
            this.grpITM.Size = new System.Drawing.Size(507, 42);
            this.grpITM.TabIndex = 243;
            this.grpITM.TabStop = false;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(1, 17);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(49, 14);
            this.label6.TabIndex = 358;
            this.label6.Text = "Currency:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // cbCurr
            // 
            this.cbCurr.BackColor = System.Drawing.Color.Lavender;
            this.cbCurr.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCurr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCurr.Items.AddRange(new object[] {
            "Select Currency",
            "USD",
            "EURO"});
            this.cbCurr.Location = new System.Drawing.Point(50, 14);
            this.cbCurr.Name = "cbCurr";
            this.cbCurr.Size = new System.Drawing.Size(129, 21);
            this.cbCurr.TabIndex = 359;
            this.cbCurr.SelectedIndexChanged += new System.EventHandler(this.cbCurr_SelectedIndexChanged);
            // 
            // picNew
            // 
            this.picNew.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNew.Image = global::PGESCOM.Properties.Resources.information_2;
            this.picNew.Location = new System.Drawing.Point(360, 10);
            this.picNew.Name = "picNew";
            this.picNew.Size = new System.Drawing.Size(39, 28);
            this.picNew.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNew.TabIndex = 357;
            this.picNew.TabStop = false;
            this.picNew.Click += new System.EventHandler(this.picNew_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(213, 17);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 14);
            this.label5.TabIndex = 354;
            this.label5.Text = "Date:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lCurr
            // 
            this.lCurr.BackColor = System.Drawing.Color.Turquoise;
            this.lCurr.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lCurr.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCurr.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lCurr.Location = new System.Drawing.Point(423, 13);
            this.lCurr.Name = "lCurr";
            this.lCurr.Size = new System.Drawing.Size(36, 14);
            this.lCurr.TabIndex = 353;
            this.lCurr.Text = "0";
            this.lCurr.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.lCurr.Visible = false;
            // 
            // txcmnt
            // 
            this.txcmnt.BackColor = System.Drawing.Color.Lavender;
            this.txcmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txcmnt.ForeColor = System.Drawing.Color.DarkRed;
            this.txcmnt.Location = new System.Drawing.Point(511, 10);
            this.txcmnt.MaxLength = 49;
            this.txcmnt.Multiline = true;
            this.txcmnt.Name = "txcmnt";
            this.txcmnt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.txcmnt.Size = new System.Drawing.Size(413, 48);
            this.txcmnt.TabIndex = 352;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.ForeColor = System.Drawing.Color.Firebrick;
            this.label27.Location = new System.Drawing.Point(82, 38);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(86, 17);
            this.label27.TabIndex = 340;
            this.label27.Text = "Exchange Rate:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label27.Visible = false;
            // 
            // txR_date
            // 
            this.txR_date.BackColor = System.Drawing.Color.Lavender;
            this.txR_date.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txR_date.ForeColor = System.Drawing.Color.DarkRed;
            this.txR_date.Location = new System.Drawing.Point(257, 14);
            this.txR_date.MaxLength = 49;
            this.txR_date.Multiline = true;
            this.txR_date.Name = "txR_date";
            this.txR_date.ReadOnly = true;
            this.txR_date.Size = new System.Drawing.Size(97, 20);
            this.txR_date.TabIndex = 356;
            this.txR_date.DoubleClick += new System.EventHandler(this.txR_date_DoubleClick);
            this.txR_date.TextChanged += new System.EventHandler(this.txR_date_TextChanged);
            // 
            // dpdate
            // 
            this.dpdate.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dpdate.CalendarTitleBackColor = System.Drawing.Color.Lavender;
            this.dpdate.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dpdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpdate.Location = new System.Drawing.Point(257, 14);
            this.dpdate.Name = "dpdate";
            this.dpdate.Size = new System.Drawing.Size(97, 20);
            this.dpdate.TabIndex = 355;
            this.dpdate.ValueChanged += new System.EventHandler(this.dpdate_ValueChanged);
            // 
            // grpLV
            // 
            this.grpLV.Controls.Add(this.ed_lvITM);
            this.grpLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLV.Location = new System.Drawing.Point(0, 110);
            this.grpLV.Name = "grpLV";
            this.grpLV.Size = new System.Drawing.Size(507, 346);
            this.grpLV.TabIndex = 245;
            this.grpLV.TabStop = false;
            // 
            // ed_lvITM
            // 
            this.ed_lvITM.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvITM.AutoArrange = false;
            this.ed_lvITM.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ed_lvITM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lotLID,
            this.d1,
            this.x,
            this.ccmnt});
            this.ed_lvITM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_lvITM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvITM.ForeColor = System.Drawing.Color.Black;
            this.ed_lvITM.FullRowSelect = true;
            this.ed_lvITM.GridLines = true;
            this.ed_lvITM.Location = new System.Drawing.Point(3, 16);
            this.ed_lvITM.MultiSelect = false;
            this.ed_lvITM.Name = "ed_lvITM";
            this.ed_lvITM.Size = new System.Drawing.Size(501, 327);
            this.ed_lvITM.TabIndex = 250;
            this.ed_lvITM.UseCompatibleStateImageBehavior = false;
            this.ed_lvITM.View = System.Windows.Forms.View.Details;
            this.ed_lvITM.DoubleClick += new System.EventHandler(this.ed_lvITM_DoubleClick);
            // 
            // lotLID
            // 
            this.lotLID.Text = "";
            this.lotLID.Width = 0;
            // 
            // d1
            // 
            this.d1.Text = "Date (JJ/MM/YY)";
            this.d1.Width = 98;
            // 
            // x
            // 
            this.x.Text = "Exchange Rate";
            this.x.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.x.Width = 107;
            // 
            // ccmnt
            // 
            this.ccmnt.Text = "Comments";
            this.ccmnt.Width = 268;
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(456, 19);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(39, 37);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 267;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // Setng_002
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(507, 456);
            this.Controls.Add(this.grpLV);
            this.Controls.Add(this.grpITM);
            this.Controls.Add(this.grpConf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Setng_002";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting Xchange rate";
            this.Load += new System.EventHandler(this.Setng_002_Load);
            this.grpConf.ResumeLayout(false);
            this.grpConf.PerformLayout();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.grpITM.ResumeLayout(false);
            this.grpITM.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNew)).EndInit();
            this.grpLV.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConf;
        private System.Windows.Forms.ToolStrip TSmain;
        private System.Windows.Forms.ToolStripButton NewItm;
        private System.Windows.Forms.ToolStripButton del_BRD;
        private System.Windows.Forms.ToolStripButton Sav_Itm;
        private System.Windows.Forms.GroupBox grpITM;
        private System.Windows.Forms.ToolStripButton exitt;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label lCurr;
        public System.Windows.Forms.TextBox txcmnt;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.DateTimePicker dpdate;
        public System.Windows.Forms.TextBox txR_date;
        private System.Windows.Forms.GroupBox grpLV;
        private ed_LVmodif ed_lvITM;
        private System.Windows.Forms.ColumnHeader lotLID;
        private System.Windows.Forms.ColumnHeader d1;
        private System.Windows.Forms.ColumnHeader x;
        private System.Windows.Forms.ColumnHeader ccmnt;
        private System.Windows.Forms.PictureBox picNew;
        private System.Windows.Forms.Label label6;
        public System.Windows.Forms.ComboBox cbCurr;
        public System.Windows.Forms.PictureBox picCIP;
    }
}