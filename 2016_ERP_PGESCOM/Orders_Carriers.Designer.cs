namespace PGESCOM
{
    partial class Orders_Carriers
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Orders_Carriers));
            this.grpConf = new System.Windows.Forms.GroupBox();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.NewItm = new System.Windows.Forms.ToolStripButton();
            this.Sav_Itm = new System.Windows.Forms.ToolStripButton();
            this.Modif = new System.Windows.Forms.ToolStripButton();
            this.exitt = new System.Windows.Forms.ToolStripButton();
            this.grpLV = new System.Windows.Forms.GroupBox();
            this.ed_lvITM = new PGESCOM.ed_LVmodif();
            this.LID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.d1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.x = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ccmnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.det = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpConf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.TSmain.SuspendLayout();
            this.grpLV.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConf
            // 
            this.grpConf.Controls.Add(this.picCIP);
            this.grpConf.Controls.Add(this.TSmain);
            this.grpConf.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConf.Location = new System.Drawing.Point(0, 0);
            this.grpConf.Name = "grpConf";
            this.grpConf.Size = new System.Drawing.Size(717, 68);
            this.grpConf.TabIndex = 241;
            this.grpConf.TabStop = false;
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
            // TSmain
            // 
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewItm,
            this.Sav_Itm,
            this.Modif,
            this.exitt});
            this.TSmain.Location = new System.Drawing.Point(3, 16);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(711, 54);
            this.TSmain.TabIndex = 257;
            this.TSmain.Text = "toolStrip2";
            // 
            // NewItm
            // 
            this.NewItm.Image = ((System.Drawing.Image)(resources.GetObject("NewItm.Image")));
            this.NewItm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewItm.Name = "NewItm";
            this.NewItm.Size = new System.Drawing.Size(36, 51);
            this.NewItm.Text = "New";
            this.NewItm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NewItm.ToolTipText = "New";
            this.NewItm.Click += new System.EventHandler(this.NewItm_Click);
            // 
            // Sav_Itm
            // 
            this.Sav_Itm.Image = ((System.Drawing.Image)(resources.GetObject("Sav_Itm.Image")));
            this.Sav_Itm.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Sav_Itm.Name = "Sav_Itm";
            this.Sav_Itm.Size = new System.Drawing.Size(59, 51);
            this.Sav_Itm.Text = "   Save     ";
            this.Sav_Itm.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Sav_Itm.ToolTipText = "Save";
            this.Sav_Itm.Click += new System.EventHandler(this.Sav_Itm_Click);
            // 
            // Modif
            // 
            this.Modif.Image = ((System.Drawing.Image)(resources.GetObject("Modif.Image")));
            this.Modif.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Modif.Name = "Modif";
            this.Modif.Size = new System.Drawing.Size(49, 51);
            this.Modif.Text = "Modify";
            this.Modif.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Modif.ToolTipText = "Modify";
            this.Modif.Click += new System.EventHandler(this.Modif_Click);
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
            // grpLV
            // 
            this.grpLV.Controls.Add(this.ed_lvITM);
            this.grpLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLV.Location = new System.Drawing.Point(0, 68);
            this.grpLV.Name = "grpLV";
            this.grpLV.Size = new System.Drawing.Size(717, 388);
            this.grpLV.TabIndex = 245;
            this.grpLV.TabStop = false;
            // 
            // ed_lvITM
            // 
            this.ed_lvITM.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvITM.AutoArrange = false;
            this.ed_lvITM.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ed_lvITM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LID,
            this.d1,
            this.x,
            this.ccmnt,
            this.det});
            this.ed_lvITM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_lvITM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvITM.ForeColor = System.Drawing.Color.Black;
            this.ed_lvITM.FullRowSelect = true;
            this.ed_lvITM.GridLines = true;
            this.ed_lvITM.Location = new System.Drawing.Point(3, 16);
            this.ed_lvITM.MultiSelect = false;
            this.ed_lvITM.Name = "ed_lvITM";
            this.ed_lvITM.Size = new System.Drawing.Size(711, 369);
            this.ed_lvITM.TabIndex = 250;
            this.ed_lvITM.UseCompatibleStateImageBehavior = false;
            this.ed_lvITM.View = System.Windows.Forms.View.Details;
            this.ed_lvITM.DoubleClick += new System.EventHandler(this.ed_lvITM_DoubleClick);
            // 
            // LID
            // 
            this.LID.Text = "  #  ";
            // 
            // d1
            // 
            this.d1.Text = "Carrier  name";
            this.d1.Width = 151;
            // 
            // x
            // 
            this.x.Text = "Phone #";
            this.x.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.x.Width = 107;
            // 
            // ccmnt
            // 
            this.ccmnt.Text = "Primax Account #";
            this.ccmnt.Width = 117;
            // 
            // det
            // 
            this.det.Text = "Comments";
            this.det.Width = 254;
            // 
            // Orders_Carriers
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(717, 456);
            this.Controls.Add(this.grpLV);
            this.Controls.Add(this.grpConf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Orders_Carriers";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CARRIERS";
            this.Load += new System.EventHandler(this.Setng_002_Load);
            this.grpConf.ResumeLayout(false);
            this.grpConf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.grpLV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConf;
        private System.Windows.Forms.ToolStrip TSmain;
        private System.Windows.Forms.ToolStripButton NewItm;
        private System.Windows.Forms.ToolStripButton Modif;
        private System.Windows.Forms.ToolStripButton Sav_Itm;
        private System.Windows.Forms.ToolStripButton exitt;
        private System.Windows.Forms.GroupBox grpLV;
        private ed_LVmodif ed_lvITM;
        private System.Windows.Forms.ColumnHeader LID;
        private System.Windows.Forms.ColumnHeader d1;
        private System.Windows.Forms.ColumnHeader x;
        private System.Windows.Forms.ColumnHeader ccmnt;
        public System.Windows.Forms.PictureBox picCIP;
        private System.Windows.Forms.ColumnHeader det;
    }
}