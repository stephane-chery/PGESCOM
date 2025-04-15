namespace PGESCOM
{
    partial class CMS_xlBills
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMS_xlBills));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.Newbrd = new System.Windows.Forms.ToolStripButton();
            this.del_BRD = new System.Windows.Forms.ToolStripButton();
            this.Sav_BRD = new System.Windows.Forms.ToolStripButton();
            this.exiit = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ed_lvXL = new PGESCOM.ed_LVmodif();
            this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox1.SuspendLayout();
            this.TSmain.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TSmain);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(993, 75);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // TSmain
            // 
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Newbrd,
            this.del_BRD,
            this.Sav_BRD,
            this.exiit,
            this.toolStripButton1,
            this.toolStripButton2});
            this.TSmain.Location = new System.Drawing.Point(3, 16);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(987, 52);
            this.TSmain.TabIndex = 258;
            this.TSmain.Text = "toolStrip2";
            // 
            // Newbrd
            // 
   //         this.Newbrd.Image = global::PGESCOM.Properties.Resources.new_48x48;
            this.Newbrd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Newbrd.Name = "Newbrd";
            this.Newbrd.Size = new System.Drawing.Size(84, 49);
            this.Newbrd.Text = "import Bills Info";
            this.Newbrd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Newbrd.ToolTipText = "New Board";
            this.Newbrd.Click += new System.EventHandler(this.Newbrd_Click);
            // 
            // del_BRD
            // 
            this.del_BRD.Image = global::PGESCOM.Properties.Resources.remove1;
            this.del_BRD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del_BRD.Name = "del_BRD";
            this.del_BRD.Size = new System.Drawing.Size(73, 49);
            this.del_BRD.Text = "Delete Board";
            this.del_BRD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.del_BRD.ToolTipText = "Delete Board";
            // 
            // Sav_BRD
            // 
            this.Sav_BRD.Image = ((System.Drawing.Image)(resources.GetObject("Sav_BRD.Image")));
            this.Sav_BRD.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Sav_BRD.Name = "Sav_BRD";
            this.Sav_BRD.Size = new System.Drawing.Size(66, 49);
            this.Sav_BRD.Text = "Save Board";
            this.Sav_BRD.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Sav_BRD.ToolTipText = "Save Board";
            // 
            // exiit
            // 
            this.exiit.Image = global::PGESCOM.Properties.Resources.Log_Off;
            this.exiit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exiit.Name = "exiit";
            this.exiit.Size = new System.Drawing.Size(47, 49);
            this.exiit.Text = "   Exit   ";
            this.exiit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exiit.ToolTipText = "Exit";
            this.exiit.Click += new System.EventHandler(this.exiit_Click);
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
            this.toolStripButton2.Image = global::PGESCOM.Properties.Resources.folder_full_delete;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(100, 49);
            this.toolStripButton2.Text = "Testing XML";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ed_lvXL);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox2.Location = new System.Drawing.Point(0, 75);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(993, 376);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            // 
            // ed_lvXL
            // 
            this.ed_lvXL.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvXL.AutoArrange = false;
            this.ed_lvXL.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ed_lvXL.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3,
            this.columnHeader4,
            this.columnHeader5,
            this.columnHeader6,
            this.columnHeader7,
            this.columnHeader8,
            this.columnHeader9,
            this.columnHeader10,
            this.columnHeader11,
            this.columnHeader12,
            this.columnHeader13,
            this.columnHeader14,
            this.columnHeader15,
            this.columnHeader16});
            this.ed_lvXL.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_lvXL.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvXL.ForeColor = System.Drawing.Color.Black;
            this.ed_lvXL.FullRowSelect = true;
            this.ed_lvXL.GridLines = true;
            this.ed_lvXL.Location = new System.Drawing.Point(3, 16);
            this.ed_lvXL.Name = "ed_lvXL";
            this.ed_lvXL.Size = new System.Drawing.Size(987, 357);
            this.ed_lvXL.TabIndex = 251;
            this.ed_lvXL.UseCompatibleStateImageBehavior = false;
            this.ed_lvXL.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Width = 92;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Width = 90;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Width = 109;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.DefaultExt = "*.xls";
            this.openFileDialog1.Filter = "Excel File (*.xls) | All Files (*.*) ||";
            this.openFileDialog1.Title = "Choose an Excel File";
            // 
            // CMS_xlBills
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(993, 451);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "CMS_xlBills";
            this.Text = "CMS_xlBills";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip TSmain;
        private System.Windows.Forms.ToolStripButton Newbrd;
        private System.Windows.Forms.ToolStripButton del_BRD;
        private System.Windows.Forms.ToolStripButton Sav_BRD;
        private System.Windows.Forms.ToolStripButton exiit;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.GroupBox groupBox2;
        private ed_LVmodif ed_lvXL;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private System.Windows.Forms.ColumnHeader columnHeader4;
        private System.Windows.Forms.ColumnHeader columnHeader5;
        private System.Windows.Forms.ColumnHeader columnHeader6;
        private System.Windows.Forms.ColumnHeader columnHeader7;
        private System.Windows.Forms.ColumnHeader columnHeader8;
        private System.Windows.Forms.ColumnHeader columnHeader9;
        private System.Windows.Forms.ColumnHeader columnHeader10;
        private System.Windows.Forms.ColumnHeader columnHeader11;
        private System.Windows.Forms.ColumnHeader columnHeader12;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.ColumnHeader columnHeader13;
        private System.Windows.Forms.ColumnHeader columnHeader14;
        private System.Windows.Forms.ColumnHeader columnHeader15;
        private System.Windows.Forms.ColumnHeader columnHeader16;
    }
}