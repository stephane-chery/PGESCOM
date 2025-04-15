namespace PGESCOM
{
    partial class dlg_add_P850UI
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlg_add_P850UI));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TS_AGTerr = new System.Windows.Forms.ToolStrip();
            this.Disp_Sales = new System.Windows.Forms.ToolStripButton();
            this.Disp_Agency = new System.Windows.Forms.ToolStripButton();
            this.tls_new = new System.Windows.Forms.ToolStripButton();
            this.tls_Save = new System.Windows.Forms.ToolStripButton();
            this.exitt = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.dg_InfoSP = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.TS_AGTerr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_InfoSP)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TS_AGTerr);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(889, 103);
            this.groupBox1.TabIndex = 250;
            this.groupBox1.TabStop = false;
            // 
            // TS_AGTerr
            // 
            this.TS_AGTerr.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.TS_AGTerr.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TS_AGTerr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Disp_Sales,
            this.Disp_Agency,
            this.tls_new,
            this.tls_Save,
            this.exitt,
            this.toolStripButton1,
            this.toolStripButton2});
            this.TS_AGTerr.Location = new System.Drawing.Point(4, 24);
            this.TS_AGTerr.Name = "TS_AGTerr";
            this.TS_AGTerr.Padding = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.TS_AGTerr.Size = new System.Drawing.Size(881, 66);
            this.TS_AGTerr.TabIndex = 258;
            this.TS_AGTerr.Text = "toolStrip2";
            // 
            // Disp_Sales
            // 
            this.Disp_Sales.Image = ((System.Drawing.Image)(resources.GetObject("Disp_Sales.Image")));
            this.Disp_Sales.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Disp_Sales.Name = "Disp_Sales";
            this.Disp_Sales.Size = new System.Drawing.Size(113, 61);
            this.Disp_Sales.Text = "New System";
            this.Disp_Sales.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Disp_Sales.Click += new System.EventHandler(this.Disp_Sales_Click);
            // 
            // Disp_Agency
            // 
            this.Disp_Agency.Image = ((System.Drawing.Image)(resources.GetObject("Disp_Agency.Image")));
            this.Disp_Agency.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Disp_Agency.Name = "Disp_Agency";
            this.Disp_Agency.Size = new System.Drawing.Size(141, 61);
            this.Disp_Agency.Text = "Change current ";
            this.Disp_Agency.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // tls_new
            // 
            this.tls_new.Image = ((System.Drawing.Image)(resources.GetObject("tls_new.Image")));
            this.tls_new.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_new.Name = "tls_new";
            this.tls_new.Size = new System.Drawing.Size(91, 61);
            this.tls_new.Text = "New Rate";
            this.tls_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_new.Visible = false;
            // 
            // tls_Save
            // 
            this.tls_Save.Image = ((System.Drawing.Image)(resources.GetObject("tls_Save.Image")));
            this.tls_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Save.Name = "tls_Save";
            this.tls_Save.Size = new System.Drawing.Size(141, 61);
            this.tls_Save.Text = "Save this config";
            this.tls_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Save.Click += new System.EventHandler(this.tls_Save_Click);
            // 
            // exitt
            // 
            this.exitt.Image = ((System.Drawing.Image)(resources.GetObject("exitt.Image")));
            this.exitt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitt.Name = "exitt";
            this.exitt.Size = new System.Drawing.Size(73, 61);
            this.exitt.Text = "   Exit   ";
            this.exitt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exitt.ToolTipText = "Exit";
            this.exitt.Click += new System.EventHandler(this.exitt_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(34, 61);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Visible = false;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(34, 61);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Visible = false;
            // 
            // dg_InfoSP
            // 
            this.dg_InfoSP.AllowUserToAddRows = false;
            this.dg_InfoSP.AllowUserToResizeColumns = false;
            this.dg_InfoSP.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.Black;
            this.dg_InfoSP.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_InfoSP.BackgroundColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_InfoSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dg_InfoSP.ColumnHeadersHeight = 34;
            this.dg_InfoSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dg_InfoSP.ColumnHeadersVisible = false;
            this.dg_InfoSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_InfoSP.DefaultCellStyle = dataGridViewCellStyle5;
            this.dg_InfoSP.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dg_InfoSP.GridColor = System.Drawing.Color.White;
            this.dg_InfoSP.Location = new System.Drawing.Point(13, 123);
            this.dg_InfoSP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.dg_InfoSP.MultiSelect = false;
            this.dg_InfoSP.Name = "dg_InfoSP";
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_InfoSP.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dg_InfoSP.RowHeadersVisible = false;
            this.dg_InfoSP.RowHeadersWidth = 62;
            dataGridViewCellStyle7.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.Color.Black;
            this.dg_InfoSP.RowsDefaultCellStyle = dataGridViewCellStyle7;
            this.dg_InfoSP.Size = new System.Drawing.Size(863, 639);
            this.dg_InfoSP.TabIndex = 263;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.Salmon;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.AntiqueWhite;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 250;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Verdana", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridViewTextBoxColumn2.HeaderText = "";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 8;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 310;
            // 
            // dlg_add_P850UI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(889, 776);
            this.Controls.Add(this.dg_InfoSP);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "dlg_add_P850UI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "UPS P850U";
            this.Load += new System.EventHandler(this.dlg_add_P850UI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TS_AGTerr.ResumeLayout(false);
            this.TS_AGTerr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_InfoSP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ToolStrip TS_AGTerr;
        private System.Windows.Forms.ToolStripButton Disp_Sales;
        private System.Windows.Forms.ToolStripButton Disp_Agency;
        private System.Windows.Forms.ToolStripButton tls_new;
        private System.Windows.Forms.ToolStripButton tls_Save;
        private System.Windows.Forms.ToolStripButton exitt;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.DataGridView dg_InfoSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}