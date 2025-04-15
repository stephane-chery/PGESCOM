namespace PGESCOM
{
    partial class CF_PrintSetup
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CF_PrintSetup));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvCurConfig = new System.Windows.Forms.ListView();
            this.chk1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cfDetlid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CF_oldRnk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.lConfigName = new System.Windows.Forms.Label();
            this.TS_IDC = new System.Windows.Forms.ToolStrip();
            this.newSU = new System.Windows.Forms.ToolStripButton();
            this.SaveSU = new System.Windows.Forms.ToolStripButton();
            this.DelSU = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tnBold = new System.Windows.Forms.ToolStripButton();
            this._cut = new System.Windows.Forms.ToolStripButton();
            this._Copy = new System.Windows.Forms.ToolStripButton();
            this._past_B = new System.Windows.Forms.ToolStripButton();
            this._Past_A = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton12 = new System.Windows.Forms.ToolStripButton();
            this.CMnu_move = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.pastBeforeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pastAfterToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.TS_IDC.SuspendLayout();
            this.CMnu_move.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvCurConfig);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1053, 574);
            this.groupBox1.TabIndex = 7;
            this.groupBox1.TabStop = false;
            // 
            // lvCurConfig
            // 
            this.lvCurConfig.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvCurConfig.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chk1,
            this.Description,
            this.cfDetlid,
            this.CF_oldRnk});
            this.lvCurConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCurConfig.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCurConfig.FullRowSelect = true;
            this.lvCurConfig.GridLines = true;
            this.lvCurConfig.Location = new System.Drawing.Point(3, 85);
            this.lvCurConfig.Name = "lvCurConfig";
            this.lvCurConfig.Size = new System.Drawing.Size(1047, 486);
            this.lvCurConfig.TabIndex = 6;
            this.lvCurConfig.UseCompatibleStateImageBehavior = false;
            this.lvCurConfig.View = System.Windows.Forms.View.Details;
            this.lvCurConfig.SelectedIndexChanged += new System.EventHandler(this.lvCurConfig_SelectedIndexChanged);
            // 
            // chk1
            // 
            this.chk1.Text = "Bold";
            this.chk1.Width = 0;
            // 
            // Description
            // 
            this.Description.Text = "                                     Item Description";
            this.Description.Width = 950;
            // 
            // cfDetlid
            // 
            this.cfDetlid.DisplayIndex = 3;
            this.cfDetlid.Text = "";
            this.cfDetlid.Width = 0;
            // 
            // CF_oldRnk
            // 
            this.CF_oldRnk.DisplayIndex = 2;
            this.CF_oldRnk.Text = "";
            this.CF_oldRnk.Width = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.picCIP);
            this.groupBox2.Controls.Add(this.lConfigName);
            this.groupBox2.Controls.Add(this.TS_IDC);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1047, 69);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(951, 16);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(39, 37);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 275;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // lConfigName
            // 
            this.lConfigName.BackColor = System.Drawing.Color.White;
            this.lConfigName.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lConfigName.Location = new System.Drawing.Point(685, 28);
            this.lConfigName.Name = "lConfigName";
            this.lConfigName.Size = new System.Drawing.Size(217, 23);
            this.lConfigName.TabIndex = 274;
            this.lConfigName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // TS_IDC
            // 
            this.TS_IDC.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TS_IDC.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newSU,
            this.SaveSU,
            this.DelSU,
            this.toolStripSeparator2,
            this.tnBold,
            this._cut,
            this._Copy,
            this._past_B,
            this._Past_A,
            this.toolStripButton12});
            this.TS_IDC.Location = new System.Drawing.Point(3, 16);
            this.TS_IDC.Name = "TS_IDC";
            this.TS_IDC.Size = new System.Drawing.Size(1041, 54);
            this.TS_IDC.TabIndex = 273;
            this.TS_IDC.Text = "toolStrip2";
            // 
            // newSU
            // 
            this.newSU.Image = ((System.Drawing.Image)(resources.GetObject("newSU.Image")));
            this.newSU.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newSU.Name = "newSU";
            this.newSU.Size = new System.Drawing.Size(68, 51);
            this.newSU.Text = "New Setup";
            this.newSU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.newSU.ToolTipText = "New";
            this.newSU.Click += new System.EventHandler(this.newSU_Click);
            // 
            // SaveSU
            // 
            this.SaveSU.Image = ((System.Drawing.Image)(resources.GetObject("SaveSU.Image")));
            this.SaveSU.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.SaveSU.Name = "SaveSU";
            this.SaveSU.Size = new System.Drawing.Size(59, 51);
            this.SaveSU.Text = "   Save     ";
            this.SaveSU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.SaveSU.ToolTipText = "Save";
            this.SaveSU.Click += new System.EventHandler(this.SaveSU_Click);
            // 
            // DelSU
            // 
            this.DelSU.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelSU.Name = "DelSU";
            this.DelSU.Size = new System.Drawing.Size(44, 51);
            this.DelSU.Text = "Delete";
            this.DelSU.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DelSU.ToolTipText = "Delete Batch";
            this.DelSU.Visible = false;
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 54);
            // 
            // tnBold
            // 
            this.tnBold.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tnBold.Name = "tnBold";
            this.tnBold.Size = new System.Drawing.Size(41, 51);
            this.tnBold.Text = "BOLD";
            this.tnBold.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tnBold.Click += new System.EventHandler(this.tnBold_Click);
            // 
            // _cut
            // 
            this._cut.Image = ((System.Drawing.Image)(resources.GetObject("_cut.Image")));
            this._cut.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._cut.Name = "_cut";
            this._cut.Size = new System.Drawing.Size(36, 51);
            this._cut.Text = "Cut";
            this._cut.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._cut.Click += new System.EventHandler(this._cut_Click);
            // 
            // _Copy
            // 
            this._Copy.Image = ((System.Drawing.Image)(resources.GetObject("_Copy.Image")));
            this._Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._Copy.Name = "_Copy";
            this._Copy.Size = new System.Drawing.Size(39, 51);
            this._Copy.Text = "Copy";
            this._Copy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._Copy.Click += new System.EventHandler(this._Copy_Click);
            // 
            // _past_B
            // 
            this._past_B.Enabled = false;
            this._past_B.Image = ((System.Drawing.Image)(resources.GetObject("_past_B.Image")));
            this._past_B.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._past_B.Name = "_past_B";
            this._past_B.Size = new System.Drawing.Size(70, 51);
            this._past_B.Text = "Past Before";
            this._past_B.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._past_B.Click += new System.EventHandler(this._past_B_Click);
            // 
            // _Past_A
            // 
            this._Past_A.Enabled = false;
            this._Past_A.Image = ((System.Drawing.Image)(resources.GetObject("_Past_A.Image")));
            this._Past_A.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._Past_A.Name = "_Past_A";
            this._Past_A.Size = new System.Drawing.Size(62, 51);
            this._Past_A.Text = "Past After";
            this._Past_A.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._Past_A.Click += new System.EventHandler(this._Past_A_Click);
            // 
            // toolStripButton12
            // 
            this.toolStripButton12.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton12.Image")));
            this.toolStripButton12.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton12.Name = "toolStripButton12";
            this.toolStripButton12.Size = new System.Drawing.Size(59, 51);
            this.toolStripButton12.Text = "     Exit     ";
            this.toolStripButton12.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton12.ToolTipText = "Exit";
            this.toolStripButton12.Click += new System.EventHandler(this.toolStripButton12_Click);
            // 
            // CMnu_move
            // 
            this.CMnu_move.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1,
            this.copyToolStripMenuItem,
            this.toolStripSeparator1,
            this.pastBeforeToolStripMenuItem,
            this.pastAfterToolStripMenuItem});
            this.CMnu_move.Name = "CMnu_move";
            this.CMnu_move.Size = new System.Drawing.Size(134, 98);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(133, 22);
            this.toolStripMenuItem1.Text = "Cut";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(130, 6);
            // 
            // pastBeforeToolStripMenuItem
            // 
            this.pastBeforeToolStripMenuItem.Name = "pastBeforeToolStripMenuItem";
            this.pastBeforeToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.pastBeforeToolStripMenuItem.Text = "Past Before";
            // 
            // pastAfterToolStripMenuItem
            // 
            this.pastAfterToolStripMenuItem.Name = "pastAfterToolStripMenuItem";
            this.pastAfterToolStripMenuItem.Size = new System.Drawing.Size(133, 22);
            this.pastAfterToolStripMenuItem.Text = "Past After";
            // 
            // CF_PrintSetup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1053, 574);
            this.Controls.Add(this.groupBox1);
            this.Name = "CF_PrintSetup";
            this.Text = "PRINT Setup";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.CF_PrintSetup_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.TS_IDC.ResumeLayout(false);
            this.TS_IDC.PerformLayout();
            this.CMnu_move.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        public System.Windows.Forms.ListView lvCurConfig;
        private System.Windows.Forms.ColumnHeader chk1;
        private System.Windows.Forms.ColumnHeader Description;
        private System.Windows.Forms.ColumnHeader CF_oldRnk;
        private System.Windows.Forms.ColumnHeader cfDetlid;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ToolStrip TS_IDC;
        private System.Windows.Forms.ToolStripButton newSU;
        private System.Windows.Forms.ToolStripButton SaveSU;
        private System.Windows.Forms.ToolStripButton DelSU;
        private System.Windows.Forms.ToolStripButton toolStripButton12;
        private System.Windows.Forms.Label lConfigName;
        private System.Windows.Forms.ContextMenuStrip CMnu_move;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem pastBeforeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pastAfterToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton _cut;
        private System.Windows.Forms.ToolStripButton _Copy;
        private System.Windows.Forms.ToolStripButton _past_B;
        private System.Windows.Forms.ToolStripButton _Past_A;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tnBold;
        public System.Windows.Forms.PictureBox picCIP;
    }
}