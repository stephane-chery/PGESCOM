namespace PGESCOM
{
    partial class Setng_001
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setng_001));
            this.grpConf = new System.Windows.Forms.GroupBox();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.NewItm = new System.Windows.Forms.ToolStripButton();
            this.del_BRD = new System.Windows.Forms.ToolStripButton();
            this.Sav_Itm = new System.Windows.Forms.ToolStripButton();
            this.list_BI = new System.Windows.Forms.ToolStripButton();
            this.exitt = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.grpLV = new System.Windows.Forms.GroupBox();
            this.label65 = new System.Windows.Forms.Label();
            this.tActv = new System.Windows.Forms.TextBox();
            this.grpITM = new System.Windows.Forms.GroupBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txcmnt = new System.Windows.Forms.TextBox();
            this.label25 = new System.Windows.Forms.Label();
            this.groupBox10 = new System.Windows.Forms.GroupBox();
            this.btnupdate = new System.Windows.Forms.Button();
            this.tEurMlt = new System.Windows.Forms.TextBox();
            this.tUSMlt = new System.Windows.Forms.TextBox();
            this.tCANMult = new System.Windows.Forms.TextBox();
            this.label30 = new System.Windows.Forms.Label();
            this.label28 = new System.Windows.Forms.Label();
            this.label27 = new System.Windows.Forms.Label();
            this.ed_lvITM = new PGESCOM.ed_LVmodif();
            this.lotLID = new System.Windows.Forms.ColumnHeader();
            this.d1 = new System.Windows.Forms.ColumnHeader();
            this.can = new System.Windows.Forms.ColumnHeader();
            this.US = new System.Windows.Forms.ColumnHeader();
            this.Eur = new System.Windows.Forms.ColumnHeader();
            this.ccmnt = new System.Windows.Forms.ColumnHeader();
            this.grpConf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.TSmain.SuspendLayout();
            this.grpLV.SuspendLayout();
            this.grpITM.SuspendLayout();
            this.groupBox10.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConf
            // 
            this.grpConf.Controls.Add(this.picCIP);
            this.grpConf.Controls.Add(this.TSmain);
            this.grpConf.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConf.Location = new System.Drawing.Point(0, 0);
            this.grpConf.Name = "grpConf";
            this.grpConf.Size = new System.Drawing.Size(930, 68);
            this.grpConf.TabIndex = 241;
            this.grpConf.TabStop = false;
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(870, 25);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(39, 37);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 268;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // TSmain
            // 
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewItm,
            this.del_BRD,
            this.Sav_Itm,
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
            // NewItm
            // 
            this.NewItm.Image = global::PGESCOM.Properties.Resources.new_48x48;
            this.NewItm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewItm.Name = "NewItm";
            this.NewItm.Size = new System.Drawing.Size(71, 49);
            this.NewItm.Text = "New Activity";
            this.NewItm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NewItm.ToolTipText = "New";
            this.NewItm.Click += new System.EventHandler(this.NewItm_Click);
            // 
            // del_BRD
            // 
            this.del_BRD.Image = global::PGESCOM.Properties.Resources.remove1;
            this.del_BRD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del_BRD.Name = "del_BRD";
            this.del_BRD.Size = new System.Drawing.Size(42, 49);
            this.del_BRD.Text = "Delete";
            this.del_BRD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.del_BRD.ToolTipText = "Delete";
            this.del_BRD.Visible = false;
            this.del_BRD.Click += new System.EventHandler(this.del_BRD_Click);
            // 
            // Sav_Itm
            // 
            this.Sav_Itm.Image = ((System.Drawing.Image)(resources.GetObject("Sav_Itm.Image")));
            this.Sav_Itm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Sav_Itm.Name = "Sav_Itm";
            this.Sav_Itm.Size = new System.Drawing.Size(36, 49);
            this.Sav_Itm.Text = "Save";
            this.Sav_Itm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Sav_Itm.ToolTipText = "Save";
            this.Sav_Itm.Click += new System.EventHandler(this.Sav_Itm_Click);
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
            this.list_BI.Visible = false;
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
            this.exitt.Click += new System.EventHandler(this.exitt_Click);
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
            this.grpLV.Controls.Add(this.ed_lvITM);
            this.grpLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLV.Location = new System.Drawing.Point(0, 151);
            this.grpLV.Name = "grpLV";
            this.grpLV.Size = new System.Drawing.Size(930, 381);
            this.grpLV.TabIndex = 244;
            this.grpLV.TabStop = false;
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.SystemColors.Control;
            this.label65.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label65.Location = new System.Drawing.Point(6, 13);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(79, 14);
            this.label65.TabIndex = 188;
            this.label65.Text = "Activity Name:";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tActv
            // 
            this.tActv.BackColor = System.Drawing.Color.Lavender;
            this.tActv.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tActv.ForeColor = System.Drawing.Color.Black;
            this.tActv.Location = new System.Drawing.Point(85, 10);
            this.tActv.MaxLength = 49;
            this.tActv.Multiline = true;
            this.tActv.Name = "tActv";
            this.tActv.Size = new System.Drawing.Size(291, 20);
            this.tActv.TabIndex = 189;
            // 
            // grpITM
            // 
            this.grpITM.Controls.Add(this.label7);
            this.grpITM.Controls.Add(this.txcmnt);
            this.grpITM.Controls.Add(this.label25);
            this.grpITM.Controls.Add(this.groupBox10);
            this.grpITM.Controls.Add(this.label65);
            this.grpITM.Controls.Add(this.tActv);
            this.grpITM.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpITM.Location = new System.Drawing.Point(0, 68);
            this.grpITM.Name = "grpITM";
            this.grpITM.Size = new System.Drawing.Size(930, 83);
            this.grpITM.TabIndex = 243;
            this.grpITM.TabStop = false;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(382, 14);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(58, 14);
            this.label7.TabIndex = 353;
            this.label7.Text = "Comment:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // txcmnt
            // 
            this.txcmnt.BackColor = System.Drawing.Color.Lavender;
            this.txcmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txcmnt.ForeColor = System.Drawing.Color.DarkRed;
            this.txcmnt.Location = new System.Drawing.Point(442, 10);
            this.txcmnt.MaxLength = 49;
            this.txcmnt.Multiline = true;
            this.txcmnt.Name = "txcmnt";
            this.txcmnt.Size = new System.Drawing.Size(482, 65);
            this.txcmnt.TabIndex = 352;
            // 
            // label25
            // 
            this.label25.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label25.ForeColor = System.Drawing.Color.Black;
            this.label25.Location = new System.Drawing.Point(1, 44);
            this.label25.Name = "label25";
            this.label25.Size = new System.Drawing.Size(84, 17);
            this.label25.TabIndex = 344;
            this.label25.Text = "Mulipliers:";
            this.label25.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // groupBox10
            // 
            this.groupBox10.Controls.Add(this.btnupdate);
            this.groupBox10.Controls.Add(this.tEurMlt);
            this.groupBox10.Controls.Add(this.tUSMlt);
            this.groupBox10.Controls.Add(this.tCANMult);
            this.groupBox10.Controls.Add(this.label30);
            this.groupBox10.Controls.Add(this.label28);
            this.groupBox10.Controls.Add(this.label27);
            this.groupBox10.ForeColor = System.Drawing.SystemColors.ControlText;
            this.groupBox10.Location = new System.Drawing.Point(85, 30);
            this.groupBox10.Name = "groupBox10";
            this.groupBox10.Size = new System.Drawing.Size(291, 45);
            this.groupBox10.TabIndex = 343;
            this.groupBox10.TabStop = false;
            // 
            // btnupdate
            // 
            this.btnupdate.Location = new System.Drawing.Point(282, 13);
            this.btnupdate.Name = "btnupdate";
            this.btnupdate.Size = new System.Drawing.Size(63, 23);
            this.btnupdate.TabIndex = 357;
            this.btnupdate.Text = "all selected";
            this.btnupdate.UseVisualStyleBackColor = true;
            this.btnupdate.Visible = false;
            // 
            // tEurMlt
            // 
            this.tEurMlt.BackColor = System.Drawing.Color.Lavender;
            this.tEurMlt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tEurMlt.ForeColor = System.Drawing.Color.Black;
            this.tEurMlt.Location = new System.Drawing.Point(228, 14);
            this.tEurMlt.MaxLength = 5;
            this.tEurMlt.Multiline = true;
            this.tEurMlt.Name = "tEurMlt";
            this.tEurMlt.Size = new System.Drawing.Size(48, 20);
            this.tEurMlt.TabIndex = 356;
            this.tEurMlt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tEurMlt_KeyPress);
            // 
            // tUSMlt
            // 
            this.tUSMlt.BackColor = System.Drawing.Color.Lavender;
            this.tUSMlt.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tUSMlt.ForeColor = System.Drawing.Color.Black;
            this.tUSMlt.Location = new System.Drawing.Point(133, 14);
            this.tUSMlt.MaxLength = 5;
            this.tUSMlt.Multiline = true;
            this.tUSMlt.Name = "tUSMlt";
            this.tUSMlt.Size = new System.Drawing.Size(48, 20);
            this.tUSMlt.TabIndex = 355;
            this.tUSMlt.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tUSMlt_KeyPress);
            // 
            // tCANMult
            // 
            this.tCANMult.BackColor = System.Drawing.Color.Lavender;
            this.tCANMult.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tCANMult.ForeColor = System.Drawing.Color.Black;
            this.tCANMult.Location = new System.Drawing.Point(42, 14);
            this.tCANMult.MaxLength = 5;
            this.tCANMult.Multiline = true;
            this.tCANMult.Name = "tCANMult";
            this.tCANMult.Size = new System.Drawing.Size(48, 20);
            this.tCANMult.TabIndex = 354;
            this.tCANMult.TextChanged += new System.EventHandler(this.tCANMult_TextChanged);
            this.tCANMult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tCANMult_KeyPress);
            // 
            // label30
            // 
            this.label30.BackColor = System.Drawing.Color.Transparent;
            this.label30.ForeColor = System.Drawing.Color.Firebrick;
            this.label30.Location = new System.Drawing.Point(187, 16);
            this.label30.Name = "label30";
            this.label30.Size = new System.Drawing.Size(41, 17);
            this.label30.TabIndex = 344;
            this.label30.Text = "EURO:";
            this.label30.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label28
            // 
            this.label28.BackColor = System.Drawing.Color.Transparent;
            this.label28.ForeColor = System.Drawing.Color.Firebrick;
            this.label28.Location = new System.Drawing.Point(108, 16);
            this.label28.Name = "label28";
            this.label28.Size = new System.Drawing.Size(25, 17);
            this.label28.TabIndex = 342;
            this.label28.Text = "US:";
            this.label28.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label27
            // 
            this.label27.BackColor = System.Drawing.Color.Transparent;
            this.label27.ForeColor = System.Drawing.Color.Firebrick;
            this.label27.Location = new System.Drawing.Point(8, 16);
            this.label27.Name = "label27";
            this.label27.Size = new System.Drawing.Size(34, 17);
            this.label27.TabIndex = 340;
            this.label27.Text = "CAN:";
            this.label27.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // ed_lvITM
            // 
            this.ed_lvITM.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvITM.AutoArrange = false;
            this.ed_lvITM.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ed_lvITM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lotLID,
            this.d1,
            this.can,
            this.US,
            this.Eur,
            this.ccmnt});
            this.ed_lvITM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_lvITM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvITM.ForeColor = System.Drawing.Color.Black;
            this.ed_lvITM.FullRowSelect = true;
            this.ed_lvITM.GridLines = true;
            this.ed_lvITM.Location = new System.Drawing.Point(3, 16);
            this.ed_lvITM.Name = "ed_lvITM";
            this.ed_lvITM.Size = new System.Drawing.Size(924, 362);
            this.ed_lvITM.TabIndex = 250;
            this.ed_lvITM.UseCompatibleStateImageBehavior = false;
            this.ed_lvITM.View = System.Windows.Forms.View.Details;
            this.ed_lvITM.SelectedIndexChanged += new System.EventHandler(this.ed_lvITM_SelectedIndexChanged);
            this.ed_lvITM.DoubleClick += new System.EventHandler(this.ed_lvITM_DoubleClick);
            // 
            // lotLID
            // 
            this.lotLID.Text = "";
            this.lotLID.Width = 0;
            // 
            // d1
            // 
            this.d1.Text = "Activity";
            this.d1.Width = 221;
            // 
            // can
            // 
            this.can.Text = "CAN Multiplier";
            this.can.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.can.Width = 100;
            // 
            // US
            // 
            this.US.Text = "US Multiplier";
            this.US.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.US.Width = 100;
            // 
            // Eur
            // 
            this.Eur.Text = "EURO Multiplier";
            this.Eur.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Eur.Width = 100;
            // 
            // ccmnt
            // 
            this.ccmnt.Text = "Comments";
            this.ccmnt.Width = 379;
            // 
            // Setng_001
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(930, 532);
            this.Controls.Add(this.grpLV);
            this.Controls.Add(this.grpITM);
            this.Controls.Add(this.grpConf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "Setng_001";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Setting Companies Activity and Multipliers";
            this.Load += new System.EventHandler(this.Setng_001_Load);
            this.grpConf.ResumeLayout(false);
            this.grpConf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.grpLV.ResumeLayout(false);
            this.grpITM.ResumeLayout(false);
            this.grpITM.PerformLayout();
            this.groupBox10.ResumeLayout(false);
            this.groupBox10.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConf;
        private System.Windows.Forms.ToolStrip TSmain;
        private System.Windows.Forms.ToolStripButton NewItm;
        private System.Windows.Forms.ToolStripButton del_BRD;
        private System.Windows.Forms.ToolStripButton Sav_Itm;
        private System.Windows.Forms.ToolStripButton list_BI;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox grpLV;
        private ed_LVmodif ed_lvITM;
        private System.Windows.Forms.ColumnHeader lotLID;
        private System.Windows.Forms.ColumnHeader d1;
        private System.Windows.Forms.ColumnHeader can;
        private System.Windows.Forms.ColumnHeader US;
        private System.Windows.Forms.Label label65;
        public System.Windows.Forms.TextBox tActv;
        private System.Windows.Forms.GroupBox grpITM;
        private System.Windows.Forms.ColumnHeader Eur;
        private System.Windows.Forms.ColumnHeader ccmnt;
        private System.Windows.Forms.ToolStripButton exitt;
        private System.Windows.Forms.Label label25;
        private System.Windows.Forms.GroupBox groupBox10;
        private System.Windows.Forms.Label label30;
        private System.Windows.Forms.Label label28;
        private System.Windows.Forms.Label label27;
        private System.Windows.Forms.Label label7;
        public System.Windows.Forms.TextBox txcmnt;
        public System.Windows.Forms.TextBox tCANMult;
        public System.Windows.Forms.TextBox tEurMlt;
        public System.Windows.Forms.TextBox tUSMlt;
        private System.Windows.Forms.Button btnupdate;
        public System.Windows.Forms.PictureBox picCIP;
    }
}