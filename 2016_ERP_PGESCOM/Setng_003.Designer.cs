namespace PGESCOM
{
    partial class Setng_003
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Setng_003));
            this.grpConf = new System.Windows.Forms.GroupBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.txIDC = new System.Windows.Forms.TextBox();
            this.btn_create_LCA = new System.Windows.Forms.Button();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.NewItm = new System.Windows.Forms.ToolStripButton();
            this.Sav_Itm = new System.Windows.Forms.ToolStripButton();
            this.del_BRD = new System.Windows.Forms.ToolStripButton();
            this.exitt = new System.Windows.Forms.ToolStripButton();
            this.toolStripComboBox1 = new System.Windows.Forms.ToolStripComboBox();
            this.grpITM = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvCH_QTY = new System.Windows.Forms.ListView();
            this.chk1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CHREF = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cptQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lnk_LID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.TVavail = new System.Windows.Forms.TreeView();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.imageList16 = new System.Windows.Forms.ImageList(this.components);
            this.grpConf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.TSmain.SuspendLayout();
            this.grpITM.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpConf
            // 
            this.grpConf.Controls.Add(this.textBox1);
            this.grpConf.Controls.Add(this.txIDC);
            this.grpConf.Controls.Add(this.btn_create_LCA);
            this.grpConf.Controls.Add(this.picCIP);
            this.grpConf.Controls.Add(this.TSmain);
            this.grpConf.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConf.Location = new System.Drawing.Point(0, 0);
            this.grpConf.Name = "grpConf";
            this.grpConf.Size = new System.Drawing.Size(1079, 68);
            this.grpConf.TabIndex = 241;
            this.grpConf.TabStop = false;
            // 
            // textBox1
            // 
            this.textBox1.BackColor = System.Drawing.SystemColors.Window;
            this.textBox1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBox1.ForeColor = System.Drawing.Color.Black;
            this.textBox1.Location = new System.Drawing.Point(831, 25);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(156, 27);
            this.textBox1.TabIndex = 269;
            // 
            // txIDC
            // 
            this.txIDC.BackColor = System.Drawing.Color.RoyalBlue;
            this.txIDC.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txIDC.ForeColor = System.Drawing.Color.White;
            this.txIDC.Location = new System.Drawing.Point(714, 23);
            this.txIDC.Name = "txIDC";
            this.txIDC.Size = new System.Drawing.Size(100, 27);
            this.txIDC.TabIndex = 268;
            this.txIDC.Text = "1250";
            // 
            // btn_create_LCA
            // 
            this.btn_create_LCA.Location = new System.Drawing.Point(524, 25);
            this.btn_create_LCA.Name = "btn_create_LCA";
            this.btn_create_LCA.Size = new System.Drawing.Size(162, 23);
            this.btn_create_LCA.TabIndex = 267;
            this.btn_create_LCA.Text = "link_cpt_Avail for charger";
            this.btn_create_LCA.UseVisualStyleBackColor = true;
            this.btn_create_LCA.Click += new System.EventHandler(this.btn_create_LCA_Click);
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(1028, 25);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(39, 37);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 266;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // TSmain
            // 
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewItm,
            this.Sav_Itm,
            this.del_BRD,
            this.exitt,
            this.toolStripComboBox1});
            this.TSmain.Location = new System.Drawing.Point(3, 16);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(1073, 25);
            this.TSmain.TabIndex = 257;
            this.TSmain.Text = "toolStrip2";
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
            this.Sav_Itm.Visible = false;
            this.Sav_Itm.Click += new System.EventHandler(this.Sav_Itm_Click);
            // 
            // del_BRD
            // 
            this.del_BRD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del_BRD.Name = "del_BRD";
            this.del_BRD.Size = new System.Drawing.Size(44, 23);
            this.del_BRD.Text = "Delete";
            this.del_BRD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.del_BRD.ToolTipText = "Delete Batch";
            this.del_BRD.Visible = false;
            this.del_BRD.Click += new System.EventHandler(this.del_BRD_Click);
            // 
            // exitt
            // 
            this.exitt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitt.Name = "exitt";
            this.exitt.Size = new System.Drawing.Size(59, 22);
            this.exitt.Text = "     Exit     ";
            this.exitt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exitt.ToolTipText = "Exit";
            this.exitt.Click += new System.EventHandler(this.exitt_Click);
            // 
            // toolStripComboBox1
            // 
            this.toolStripComboBox1.AutoSize = false;
            this.toolStripComboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.toolStripComboBox1.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripComboBox1.ForeColor = System.Drawing.Color.Red;
            this.toolStripComboBox1.Items.AddRange(new object[] {
            "Select Phase         ",
            "1 Phase",
            "3 Phase"});
            this.toolStripComboBox1.Name = "toolStripComboBox1";
            this.toolStripComboBox1.Size = new System.Drawing.Size(150, 26);
            this.toolStripComboBox1.Visible = false;
            this.toolStripComboBox1.SelectedIndexChanged += new System.EventHandler(this.toolStripComboBox1_SelectedIndexChanged);
            this.toolStripComboBox1.Click += new System.EventHandler(this.toolStripComboBox1_Click);
            // 
            // grpITM
            // 
            this.grpITM.Controls.Add(this.groupBox1);
            this.grpITM.Controls.Add(this.TVavail);
            this.grpITM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpITM.Location = new System.Drawing.Point(0, 68);
            this.grpITM.Name = "grpITM";
            this.grpITM.Size = new System.Drawing.Size(1079, 518);
            this.grpITM.TabIndex = 244;
            this.grpITM.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvCH_QTY);
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(524, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(552, 499);
            this.groupBox1.TabIndex = 6;
            this.groupBox1.TabStop = false;
            // 
            // lvCH_QTY
            // 
            this.lvCH_QTY.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvCH_QTY.CheckBoxes = true;
            this.lvCH_QTY.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.chk1,
            this.CHREF,
            this.cptQty,
            this.lnk_LID});
            this.lvCH_QTY.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCH_QTY.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCH_QTY.FullRowSelect = true;
            this.lvCH_QTY.GridLines = true;
            this.lvCH_QTY.Location = new System.Drawing.Point(3, 91);
            this.lvCH_QTY.MultiSelect = false;
            this.lvCH_QTY.Name = "lvCH_QTY";
            this.lvCH_QTY.Size = new System.Drawing.Size(546, 405);
            this.lvCH_QTY.TabIndex = 6;
            this.lvCH_QTY.UseCompatibleStateImageBehavior = false;
            this.lvCH_QTY.View = System.Windows.Forms.View.Details;
            // 
            // chk1
            // 
            this.chk1.DisplayIndex = 1;
            this.chk1.Text = "";
            this.chk1.Width = 28;
            // 
            // CHREF
            // 
            this.CHREF.DisplayIndex = 2;
            this.CHREF.Text = "Charger Ref.";
            this.CHREF.Width = 352;
            // 
            // cptQty
            // 
            this.cptQty.DisplayIndex = 3;
            this.cptQty.Text = "Component QTY";
            this.cptQty.Width = 151;
            // 
            // lnk_LID
            // 
            this.lnk_LID.DisplayIndex = 0;
            this.lnk_LID.Text = "";
            this.lnk_LID.Width = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(546, 75);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            // 
            // TVavail
            // 
            this.TVavail.Dock = System.Windows.Forms.DockStyle.Left;
            this.TVavail.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TVavail.FullRowSelect = true;
            this.TVavail.HideSelection = false;
            this.TVavail.ImageIndex = 0;
            this.TVavail.ImageList = this.imageList1;
            this.TVavail.Location = new System.Drawing.Point(3, 16);
            this.TVavail.Name = "TVavail";
            this.TVavail.SelectedImageIndex = 0;
            this.TVavail.Size = new System.Drawing.Size(521, 499);
            this.TVavail.TabIndex = 4;
            this.TVavail.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.TVavail_AfterSelect);
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "vltag2.jpg");
            this.imageList1.Images.SetKeyName(1, "P4500S.jpg");
            this.imageList1.Images.SetKeyName(2, "cpt.jpg");
            // 
            // imageList16
            // 
            this.imageList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList16.ImageStream")));
            this.imageList16.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList16.Images.SetKeyName(0, "vltag2.jpg");
            this.imageList16.Images.SetKeyName(1, "P4500S.jpg");
            this.imageList16.Images.SetKeyName(2, "cpt.jpg");
            this.imageList16.Images.SetKeyName(3, "");
            this.imageList16.Images.SetKeyName(4, "");
            this.imageList16.Images.SetKeyName(5, "");
            this.imageList16.Images.SetKeyName(6, "");
            this.imageList16.Images.SetKeyName(7, "");
            this.imageList16.Images.SetKeyName(8, "");
            this.imageList16.Images.SetKeyName(9, "");
            this.imageList16.Images.SetKeyName(10, "");
            this.imageList16.Images.SetKeyName(11, "memory.png");
            this.imageList16.Images.SetKeyName(12, "30-Pin-RAM-icon.gif");
            this.imageList16.Images.SetKeyName(13, "56K-Digital-Jack-icon.gif");
            this.imageList16.Images.SetKeyName(14, "images.jpg");
            // 
            // Setng_003
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1079, 586);
            this.Controls.Add(this.grpITM);
            this.Controls.Add(this.grpConf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Setng_003";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pricing - Availability";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Setng_003_Load);
            this.grpConf.ResumeLayout(false);
            this.grpConf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.grpITM.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConf;
        private System.Windows.Forms.ToolStrip TSmain;
        private System.Windows.Forms.ToolStripButton NewItm;
        private System.Windows.Forms.ToolStripButton del_BRD;
        private System.Windows.Forms.ToolStripButton Sav_Itm;
        private System.Windows.Forms.ToolStripButton exitt;
        private System.Windows.Forms.GroupBox grpITM;
        private System.Windows.Forms.ImageList imageList16;
        private System.Windows.Forms.ToolStripComboBox toolStripComboBox1;
        private System.Windows.Forms.TreeView TVavail;
        private System.Windows.Forms.ImageList imageList1;
        public System.Windows.Forms.PictureBox picCIP;
        private System.Windows.Forms.TextBox txIDC;
        private System.Windows.Forms.Button btn_create_LCA;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ListView lvCH_QTY;
        private System.Windows.Forms.ColumnHeader chk1;
        private System.Windows.Forms.ColumnHeader CHREF;
        private System.Windows.Forms.ColumnHeader cptQty;
        private System.Windows.Forms.ColumnHeader lnk_LID;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}