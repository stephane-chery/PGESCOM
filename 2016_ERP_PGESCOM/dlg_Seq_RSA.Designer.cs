namespace PGESCOM
{
    partial class dlg_Seq_RSA
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlg_Seq_RSA));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TLS = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.UCn = new System.Windows.Forms.ToolStripComboBox();
            this.Sync = new System.Windows.Forms.ToolStripButton();
            this.tls_Save = new System.Windows.Forms.ToolStripButton();
            this.tls_new = new System.Windows.Forms.ToolStripButton();
            this.synALL = new System.Windows.Forms.ToolStripButton();
            this.exitt = new System.Windows.Forms.ToolStripButton();
            this.grpInv = new System.Windows.Forms.GroupBox();
            this.lSave = new System.Windows.Forms.Label();
            this.btnUP = new System.Windows.Forms.PictureBox();
            this.btnDown = new System.Windows.Forms.PictureBox();
            this.ed_lvITM = new PGESCOM.ed_LVmodif();
            this.lid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Seq = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RSA_Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            this.TLS.SuspendLayout();
            this.grpInv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUP)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDown)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TLS);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(635, 69);
            this.groupBox1.TabIndex = 250;
            this.groupBox1.TabStop = false;
            // 
            // TLS
            // 
            this.TLS.BackColor = System.Drawing.Color.LemonChiffon;
            this.TLS.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TLS.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.UCn,
            this.Sync,
            this.tls_Save,
            this.tls_new,
            this.synALL,
            this.exitt});
            this.TLS.Location = new System.Drawing.Point(3, 16);
            this.TLS.Name = "TLS";
            this.TLS.Size = new System.Drawing.Size(629, 54);
            this.TLS.TabIndex = 258;
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(44, 51);
            this.toolStripLabel1.Text = "Branch";
            this.toolStripLabel1.Visible = false;
            // 
            // UCn
            // 
            this.UCn.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.UCn.Items.AddRange(new object[] {
            "U1",
            "C1"});
            this.UCn.Name = "UCn";
            this.UCn.Size = new System.Drawing.Size(121, 54);
            this.UCn.Visible = false;
            // 
            // Sync
            // 
            this.Sync.Image = ((System.Drawing.Image)(resources.GetObject("Sync.Image")));
            this.Sync.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Sync.Name = "Sync";
            this.Sync.Size = new System.Drawing.Size(80, 51);
            this.Sync.Text = "Auto ranking";
            this.Sync.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Sync.Visible = false;
            // 
            // tls_Save
            // 
            this.tls_Save.Image = ((System.Drawing.Image)(resources.GetObject("tls_Save.Image")));
            this.tls_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Save.Name = "tls_Save";
            this.tls_Save.Size = new System.Drawing.Size(71, 51);
            this.tls_Save.Text = "      Save      ";
            this.tls_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Save.Click += new System.EventHandler(this.tls_Save_Click);
            // 
            // tls_new
            // 
            this.tls_new.Image = ((System.Drawing.Image)(resources.GetObject("tls_new.Image")));
            this.tls_new.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_new.Name = "tls_new";
            this.tls_new.Size = new System.Drawing.Size(83, 51);
            this.tls_new.Text = "  Edit Agents  ";
            this.tls_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_new.Visible = false;
            // 
            // synALL
            // 
            this.synALL.Image = ((System.Drawing.Image)(resources.GetObject("synALL.Image")));
            this.synALL.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.synALL.Name = "synALL";
            this.synALL.Size = new System.Drawing.Size(122, 51);
            this.synALL.Text = "SYNC ALL (AG-Sales)";
            this.synALL.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.synALL.Visible = false;
            // 
            // exitt
            // 
            this.exitt.Image = ((System.Drawing.Image)(resources.GetObject("exitt.Image")));
            this.exitt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitt.Name = "exitt";
            this.exitt.Size = new System.Drawing.Size(47, 51);
            this.exitt.Text = "   Exit   ";
            this.exitt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exitt.ToolTipText = "Exit";
            this.exitt.Click += new System.EventHandler(this.exitt_Click);
            // 
            // grpInv
            // 
            this.grpInv.Controls.Add(this.lSave);
            this.grpInv.Controls.Add(this.btnUP);
            this.grpInv.Controls.Add(this.btnDown);
            this.grpInv.Controls.Add(this.ed_lvITM);
            this.grpInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInv.Location = new System.Drawing.Point(0, 69);
            this.grpInv.Name = "grpInv";
            this.grpInv.Size = new System.Drawing.Size(635, 529);
            this.grpInv.TabIndex = 251;
            this.grpInv.TabStop = false;
            // 
            // lSave
            // 
            this.lSave.AutoSize = true;
            this.lSave.BackColor = System.Drawing.Color.LawnGreen;
            this.lSave.Location = new System.Drawing.Point(562, 76);
            this.lSave.Name = "lSave";
            this.lSave.Size = new System.Drawing.Size(15, 13);
            this.lSave.TabIndex = 265;
            this.lSave.Text = "N";
            this.lSave.Visible = false;
            // 
            // btnUP
            // 
            this.btnUP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUP.Image = ((System.Drawing.Image)(resources.GetObject("btnUP.Image")));
            this.btnUP.Location = new System.Drawing.Point(545, 127);
            this.btnUP.Name = "btnUP";
            this.btnUP.Size = new System.Drawing.Size(79, 119);
            this.btnUP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnUP.TabIndex = 264;
            this.btnUP.TabStop = false;
            this.btnUP.Click += new System.EventHandler(this.btnUP_Click);
            // 
            // btnDown
            // 
            this.btnDown.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDown.Image = ((System.Drawing.Image)(resources.GetObject("btnDown.Image")));
            this.btnDown.Location = new System.Drawing.Point(545, 262);
            this.btnDown.Name = "btnDown";
            this.btnDown.Size = new System.Drawing.Size(79, 119);
            this.btnDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.btnDown.TabIndex = 263;
            this.btnDown.TabStop = false;
            this.btnDown.Click += new System.EventHandler(this.btnDown_Click);
            // 
            // ed_lvITM
            // 
            this.ed_lvITM.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvITM.AutoArrange = false;
            this.ed_lvITM.BackColor = System.Drawing.Color.Honeydew;
            this.ed_lvITM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.lid,
            this.Seq,
            this.RSA_Name});
            this.ed_lvITM.Dock = System.Windows.Forms.DockStyle.Left;
            this.ed_lvITM.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvITM.ForeColor = System.Drawing.Color.Black;
            this.ed_lvITM.FullRowSelect = true;
            this.ed_lvITM.GridLines = true;
            this.ed_lvITM.Location = new System.Drawing.Point(3, 16);
            this.ed_lvITM.Name = "ed_lvITM";
            this.ed_lvITM.Size = new System.Drawing.Size(525, 510);
            this.ed_lvITM.TabIndex = 262;
            this.ed_lvITM.UseCompatibleStateImageBehavior = false;
            this.ed_lvITM.View = System.Windows.Forms.View.Details;
            // 
            // lid
            // 
            this.lid.Text = "";
            this.lid.Width = 0;
            // 
            // Seq
            // 
            this.Seq.Text = " Rank #";
            this.Seq.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Seq.Width = 99;
            // 
            // RSA_Name
            // 
            this.RSA_Name.Text = "Name";
            this.RSA_Name.Width = 382;
            // 
            // dlg_Seq_RSA
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(635, 598);
            this.Controls.Add(this.grpInv);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlg_Seq_RSA";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Sequence";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.dlg_Seq_RSA_FormClosing);
            this.Load += new System.EventHandler(this.dlg_Seq_RSA_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TLS.ResumeLayout(false);
            this.TLS.PerformLayout();
            this.grpInv.ResumeLayout(false);
            this.grpInv.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.btnUP)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.btnDown)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpInv;
        private System.Windows.Forms.ToolStrip TLS;
        private System.Windows.Forms.ToolStripButton Sync;
        private System.Windows.Forms.ToolStripButton synALL;
        private System.Windows.Forms.ToolStripButton tls_new;
        private System.Windows.Forms.ToolStripButton tls_Save;
        private System.Windows.Forms.ToolStripButton exitt;
        private ed_LVmodif ed_lvITM;
        private System.Windows.Forms.ColumnHeader lid;
        private System.Windows.Forms.ColumnHeader RSA_Name;
        private System.Windows.Forms.ColumnHeader Seq;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripComboBox UCn;
        private System.Windows.Forms.PictureBox btnUP;
        private System.Windows.Forms.PictureBox btnDown;
        public System.Windows.Forms.Label lSave;
    }
}