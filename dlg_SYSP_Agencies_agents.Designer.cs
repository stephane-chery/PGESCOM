namespace PGESCOM
{
    partial class dlg_SYSP_Agencies_agents
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlg_SYSP_Agencies_agents));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.TS_AGTerr = new System.Windows.Forms.ToolStrip();
            this.newAgent = new System.Windows.Forms.ToolStripButton();
            this.tls_Save = new System.Windows.Forms.ToolStripButton();
            this.Del_Agent = new System.Windows.Forms.ToolStripButton();
            this.tls_new = new System.Windows.Forms.ToolStripButton();
            this.exitt = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.grpInv = new System.Windows.Forms.GroupBox();
            this.ed_lvITM = new PGESCOM.ed_LVmodif();
            this.itm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.code = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FNLN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Email = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.phn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.stat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dg_InfoSP = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            this.TS_AGTerr.SuspendLayout();
            this.grpInv.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dg_InfoSP)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TS_AGTerr);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(738, 69);
            this.groupBox1.TabIndex = 250;
            this.groupBox1.TabStop = false;
            // 
            // TS_AGTerr
            // 
            this.TS_AGTerr.BackColor = System.Drawing.Color.LemonChiffon;
            this.TS_AGTerr.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TS_AGTerr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newAgent,
            this.tls_Save,
            this.Del_Agent,
            this.tls_new,
            this.exitt,
            this.toolStripButton1,
            this.toolStripButton2});
            this.TS_AGTerr.Location = new System.Drawing.Point(3, 16);
            this.TS_AGTerr.Name = "TS_AGTerr";
            this.TS_AGTerr.Size = new System.Drawing.Size(732, 54);
            this.TS_AGTerr.TabIndex = 258;
            this.TS_AGTerr.Text = "toolStrip2";
            // 
            // newAgent
            // 
            this.newAgent.Image = ((System.Drawing.Image)(resources.GetObject("newAgent.Image")));
            this.newAgent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newAgent.Name = "newAgent";
            this.newAgent.Size = new System.Drawing.Size(70, 51);
            this.newAgent.Text = "New Agent";
            this.newAgent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.newAgent.Click += new System.EventHandler(this.newAgent_Click);
            // 
            // tls_Save
            // 
            this.tls_Save.Image = ((System.Drawing.Image)(resources.GetObject("tls_Save.Image")));
            this.tls_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Save.Name = "tls_Save";
            this.tls_Save.Size = new System.Drawing.Size(62, 51);
            this.tls_Save.Text = "    SAVE    ";
            this.tls_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Save.Click += new System.EventHandler(this.tls_Save_Click);
            // 
            // Del_Agent
            // 
            this.Del_Agent.Image = ((System.Drawing.Image)(resources.GetObject("Del_Agent.Image")));
            this.Del_Agent.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Del_Agent.Name = "Del_Agent";
            this.Del_Agent.Size = new System.Drawing.Size(84, 51);
            this.Del_Agent.Text = "Delete Agents";
            this.Del_Agent.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Del_Agent.Click += new System.EventHandler(this.Del_Agent_Click);
            // 
            // tls_new
            // 
            this.tls_new.Image = ((System.Drawing.Image)(resources.GetObject("tls_new.Image")));
            this.tls_new.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_new.Name = "tls_new";
            this.tls_new.Size = new System.Drawing.Size(61, 51);
            this.tls_new.Text = "New Rate";
            this.tls_new.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_new.Visible = false;
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
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 51);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Visible = false;
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 51);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Visible = false;
            // 
            // grpInv
            // 
            this.grpInv.Controls.Add(this.ed_lvITM);
            this.grpInv.Controls.Add(this.dg_InfoSP);
            this.grpInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInv.Location = new System.Drawing.Point(0, 69);
            this.grpInv.Name = "grpInv";
            this.grpInv.Size = new System.Drawing.Size(738, 455);
            this.grpInv.TabIndex = 251;
            this.grpInv.TabStop = false;
            this.grpInv.Enter += new System.EventHandler(this.grpInv_Enter);
            // 
            // ed_lvITM
            // 
            this.ed_lvITM.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvITM.AutoArrange = false;
            this.ed_lvITM.BackColor = System.Drawing.Color.Lavender;
            this.ed_lvITM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.itm,
            this.code,
            this.FNLN,
            this.Email,
            this.phn,
            this.stat});
            this.ed_lvITM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_lvITM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvITM.ForeColor = System.Drawing.Color.Black;
            this.ed_lvITM.FullRowSelect = true;
            this.ed_lvITM.GridLines = true;
            this.ed_lvITM.Location = new System.Drawing.Point(3, 111);
            this.ed_lvITM.Name = "ed_lvITM";
            this.ed_lvITM.Size = new System.Drawing.Size(732, 341);
            this.ed_lvITM.TabIndex = 262;
            this.ed_lvITM.UseCompatibleStateImageBehavior = false;
            this.ed_lvITM.View = System.Windows.Forms.View.Details;
            this.ed_lvITM.SelectedIndexChanged += new System.EventHandler(this.ed_lvITM_SelectedIndexChanged);
            this.ed_lvITM.DoubleClick += new System.EventHandler(this.ed_lvITM_DoubleClick);
            // 
            // itm
            // 
            this.itm.Text = "";
            this.itm.Width = 0;
            // 
            // code
            // 
            this.code.Text = "Code";
            this.code.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.code.Width = 99;
            // 
            // FNLN
            // 
            this.FNLN.Text = "Name";
            this.FNLN.Width = 245;
            // 
            // Email
            // 
            this.Email.Text = "E-mail";
            this.Email.Width = 204;
            // 
            // phn
            // 
            this.phn.Text = "Phone";
            this.phn.Width = 155;
            // 
            // stat
            // 
            this.stat.Text = "";
            this.stat.Width = 0;
            // 
            // dg_InfoSP
            // 
            this.dg_InfoSP.AllowUserToAddRows = false;
            this.dg_InfoSP.AllowUserToDeleteRows = false;
            this.dg_InfoSP.AllowUserToResizeRows = false;
            this.dg_InfoSP.BackgroundColor = System.Drawing.Color.LightGoldenrodYellow;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_InfoSP.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dg_InfoSP.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dg_InfoSP.ColumnHeadersVisible = false;
            this.dg_InfoSP.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dg_InfoSP.DefaultCellStyle = dataGridViewCellStyle4;
            this.dg_InfoSP.Dock = System.Windows.Forms.DockStyle.Top;
            this.dg_InfoSP.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnKeystroke;
            this.dg_InfoSP.GridColor = System.Drawing.Color.Lavender;
            this.dg_InfoSP.Location = new System.Drawing.Point(3, 16);
            this.dg_InfoSP.MultiSelect = false;
            this.dg_InfoSP.Name = "dg_InfoSP";
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dg_InfoSP.RowHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dg_InfoSP.RowHeadersVisible = false;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            this.dg_InfoSP.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dg_InfoSP.Size = new System.Drawing.Size(732, 95);
            this.dg_InfoSP.TabIndex = 261;
            this.dg_InfoSP.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.AliceBlue;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.Black;
            this.dataGridViewTextBoxColumn1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridViewTextBoxColumn1.HeaderText = "";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 120;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.AntiqueWhite;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.Red;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.Color.Red;
            this.dataGridViewTextBoxColumn2.DefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridViewTextBoxColumn2.HeaderText = "";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 580;
            // 
            // dlg_SYSP_Agencies_agents
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(738, 524);
            this.Controls.Add(this.grpInv);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlg_SYSP_Agencies_agents";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Agents";
            this.Load += new System.EventHandler(this.dlg_addBatt_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.TS_AGTerr.ResumeLayout(false);
            this.TS_AGTerr.PerformLayout();
            this.grpInv.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dg_InfoSP)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpInv;
        private System.Windows.Forms.ToolStrip TS_AGTerr;
        private System.Windows.Forms.ToolStripButton newAgent;
        private System.Windows.Forms.ToolStripButton Del_Agent;
        private System.Windows.Forms.ToolStripButton tls_new;
        private System.Windows.Forms.ToolStripButton tls_Save;
        private System.Windows.Forms.ToolStripButton exitt;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private ed_LVmodif ed_lvITM;
        private System.Windows.Forms.ColumnHeader itm;
        private System.Windows.Forms.ColumnHeader FNLN;
        private System.Windows.Forms.ColumnHeader phn;
        private System.Windows.Forms.ColumnHeader Email;
        private System.Windows.Forms.ColumnHeader stat;
        private System.Windows.Forms.DataGridView dg_InfoSP;
        private System.Windows.Forms.ColumnHeader code;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
    }
}