namespace PGESCOM
{
    partial class dlg_Vaca_Emp
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlg_Vaca_Emp));
            this.grpConf = new System.Windows.Forms.GroupBox();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.NewItm = new System.Windows.Forms.ToolStripButton();
            this.Sav_Itm = new System.Windows.Forms.ToolStripButton();
            this.Modif = new System.Windows.Forms.ToolStripButton();
            this.exitt = new System.Windows.Forms.ToolStripButton();
            this.grpEntry = new System.Windows.Forms.GroupBox();
            this.picUpdate = new System.Windows.Forms.PictureBox();
            this.tBrdSN = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.label65 = new System.Windows.Forms.Label();
            this.CB_brd = new System.Windows.Forms.ComboBox();
            this.grpLV = new System.Windows.Forms.GroupBox();
            this.ed_lvITM = new PGESCOM.ed_LVmodif();
            this.LID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmpName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dep = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EmpCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Depcode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpConf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.TSmain.SuspendLayout();
            this.grpEntry.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).BeginInit();
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
            this.grpConf.Size = new System.Drawing.Size(434, 80);
            this.grpConf.TabIndex = 246;
            this.grpConf.TabStop = false;
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(296, 19);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(39, 37);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 267;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // TSmain
            // 
            this.TSmain.BackColor = System.Drawing.Color.LemonChiffon;
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewItm,
            this.Sav_Itm,
            this.Modif,
            this.exitt});
            this.TSmain.Location = new System.Drawing.Point(3, 16);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(428, 54);
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
            // 
            // exitt
            // 
            this.exitt.Image = ((System.Drawing.Image)(resources.GetObject("exitt.Image")));
            this.exitt.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exitt.Name = "exitt";
            this.exitt.Size = new System.Drawing.Size(60, 51);
            this.exitt.Text = "     Exit     ";
            this.exitt.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exitt.ToolTipText = "Exit";
            // 
            // grpEntry
            // 
            this.grpEntry.Controls.Add(this.picUpdate);
            this.grpEntry.Controls.Add(this.tBrdSN);
            this.grpEntry.Controls.Add(this.label66);
            this.grpEntry.Controls.Add(this.label65);
            this.grpEntry.Controls.Add(this.CB_brd);
            this.grpEntry.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpEntry.Location = new System.Drawing.Point(0, 80);
            this.grpEntry.Name = "grpEntry";
            this.grpEntry.Size = new System.Drawing.Size(434, 75);
            this.grpEntry.TabIndex = 247;
            this.grpEntry.TabStop = false;
            this.grpEntry.Visible = false;
            // 
            // picUpdate
            // 
            this.picUpdate.BackColor = System.Drawing.Color.Transparent;
            this.picUpdate.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picUpdate.Image = ((System.Drawing.Image)(resources.GetObject("picUpdate.Image")));
            this.picUpdate.Location = new System.Drawing.Point(296, 19);
            this.picUpdate.Name = "picUpdate";
            this.picUpdate.Size = new System.Drawing.Size(54, 43);
            this.picUpdate.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picUpdate.TabIndex = 376;
            this.picUpdate.TabStop = false;
            // 
            // tBrdSN
            // 
            this.tBrdSN.BackColor = System.Drawing.SystemColors.Control;
            this.tBrdSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBrdSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBrdSN.ForeColor = System.Drawing.Color.DarkRed;
            this.tBrdSN.Location = new System.Drawing.Point(102, 19);
            this.tBrdSN.MaxLength = 49;
            this.tBrdSN.Multiline = true;
            this.tBrdSN.Name = "tBrdSN";
            this.tBrdSN.Size = new System.Drawing.Size(176, 20);
            this.tBrdSN.TabIndex = 374;
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.SystemColors.Control;
            this.label66.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.Color.Black;
            this.label66.Location = new System.Drawing.Point(13, 22);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(88, 14);
            this.label66.TabIndex = 373;
            this.label66.Text = "Employee Name:";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.SystemColors.Control;
            this.label65.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label65.Location = new System.Drawing.Point(13, 43);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(88, 14);
            this.label65.TabIndex = 371;
            this.label65.Text = "Departement:";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // CB_brd
            // 
            this.CB_brd.BackColor = System.Drawing.Color.Lavender;
            this.CB_brd.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CB_brd.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CB_brd.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CB_brd.Location = new System.Drawing.Point(102, 39);
            this.CB_brd.Name = "CB_brd";
            this.CB_brd.Size = new System.Drawing.Size(176, 23);
            this.CB_brd.TabIndex = 372;
            // 
            // grpLV
            // 
            this.grpLV.Controls.Add(this.ed_lvITM);
            this.grpLV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLV.Location = new System.Drawing.Point(0, 155);
            this.grpLV.Name = "grpLV";
            this.grpLV.Size = new System.Drawing.Size(434, 282);
            this.grpLV.TabIndex = 248;
            this.grpLV.TabStop = false;
            // 
            // ed_lvITM
            // 
            this.ed_lvITM.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvITM.AutoArrange = false;
            this.ed_lvITM.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ed_lvITM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.LID,
            this.EmpName,
            this.Dep,
            this.EmpCode,
            this.Depcode});
            this.ed_lvITM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_lvITM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvITM.ForeColor = System.Drawing.Color.Black;
            this.ed_lvITM.FullRowSelect = true;
            this.ed_lvITM.GridLines = true;
            this.ed_lvITM.HideSelection = false;
            this.ed_lvITM.Location = new System.Drawing.Point(3, 16);
            this.ed_lvITM.MultiSelect = false;
            this.ed_lvITM.Name = "ed_lvITM";
            this.ed_lvITM.Size = new System.Drawing.Size(428, 263);
            this.ed_lvITM.TabIndex = 250;
            this.ed_lvITM.UseCompatibleStateImageBehavior = false;
            this.ed_lvITM.View = System.Windows.Forms.View.Details;
            // 
            // LID
            // 
            this.LID.Text = "";
            this.LID.Width = 0;
            // 
            // EmpName
            // 
            this.EmpName.Text = "Employee  Name";
            this.EmpName.Width = 252;
            // 
            // Dep
            // 
            this.Dep.DisplayIndex = 3;
            this.Dep.Text = "Departement";
            this.Dep.Width = 148;
            // 
            // EmpCode
            // 
            this.EmpCode.DisplayIndex = 4;
            this.EmpCode.Text = "";
            this.EmpCode.Width = 0;
            // 
            // Depcode
            // 
            this.Depcode.DisplayIndex = 2;
            this.Depcode.Text = "";
            this.Depcode.Width = 0;
            // 
            // dlg_Vaca_Emp
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 437);
            this.Controls.Add(this.grpLV);
            this.Controls.Add(this.grpEntry);
            this.Controls.Add(this.grpConf);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlg_Vaca_Emp";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Primax Employees ";
            this.Load += new System.EventHandler(this.dlg_Vaca_Emp_Load);
            this.grpConf.ResumeLayout(false);
            this.grpConf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.grpEntry.ResumeLayout(false);
            this.grpEntry.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picUpdate)).EndInit();
            this.grpLV.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpConf;
        public System.Windows.Forms.PictureBox picCIP;
        private System.Windows.Forms.ToolStrip TSmain;
        private System.Windows.Forms.ToolStripButton NewItm;
        private System.Windows.Forms.ToolStripButton Sav_Itm;
        private System.Windows.Forms.ToolStripButton Modif;
        private System.Windows.Forms.ToolStripButton exitt;
        private System.Windows.Forms.GroupBox grpEntry;
        private System.Windows.Forms.GroupBox grpLV;
        private ed_LVmodif ed_lvITM;
        private System.Windows.Forms.ColumnHeader LID;
        private System.Windows.Forms.ColumnHeader EmpName;
        private System.Windows.Forms.ColumnHeader Depcode;
        private System.Windows.Forms.Label label65;
        public System.Windows.Forms.ComboBox CB_brd;
        public System.Windows.Forms.TextBox tBrdSN;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.PictureBox picUpdate;
        private System.Windows.Forms.ColumnHeader Dep;
        private System.Windows.Forms.ColumnHeader EmpCode;
    }
}