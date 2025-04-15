namespace PGESCOM
{
    partial class Order_Sched_RP
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Order_Sched_RP));
            this.grpSrch = new System.Windows.Forms.GroupBox();
            this.grpSearch = new System.Windows.Forms.GroupBox();
            this.grpPRJ = new System.Windows.Forms.GroupBox();
            this.picSeek = new System.Windows.Forms.PictureBox();
            this.tKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.Vtot = new System.Windows.Forms.Label();
            this.ltot = new System.Windows.Forms.Label();
            this.lcurNm = new System.Windows.Forms.Label();
            this.lcurTRndx = new System.Windows.Forms.Label();
            this.btnxl = new System.Windows.Forms.Button();
            this.cbCrit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnLook = new System.Windows.Forms.Button();
            this.grpLVcms = new System.Windows.Forms.GroupBox();
            this.lvCMS = new System.Windows.Forms.ListView();
            this.PRD = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Prj = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cust = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dd = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Stk = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Selling = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SalesP = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Salescode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvsumm = new System.Windows.Forms.TreeView();
            this.grpSrch.SuspendLayout();
            this.grpSearch.SuspendLayout();
            this.grpPRJ.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).BeginInit();
            this.grpLVcms.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpSrch
            // 
            this.grpSrch.BackColor = System.Drawing.Color.Linen;
            this.grpSrch.Controls.Add(this.grpSearch);
            this.grpSrch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSrch.Location = new System.Drawing.Point(0, 0);
            this.grpSrch.Name = "grpSrch";
            this.grpSrch.Size = new System.Drawing.Size(1587, 102);
            this.grpSrch.TabIndex = 207;
            this.grpSrch.TabStop = false;
            // 
            // grpSearch
            // 
            this.grpSearch.BackColor = System.Drawing.Color.Linen;
            this.grpSearch.Controls.Add(this.grpPRJ);
            this.grpSearch.Controls.Add(this.Vtot);
            this.grpSearch.Controls.Add(this.ltot);
            this.grpSearch.Controls.Add(this.lcurNm);
            this.grpSearch.Controls.Add(this.lcurTRndx);
            this.grpSearch.Controls.Add(this.btnxl);
            this.grpSearch.Controls.Add(this.cbCrit);
            this.grpSearch.Controls.Add(this.label1);
            this.grpSearch.Controls.Add(this.btnLook);
            this.grpSearch.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpSearch.Location = new System.Drawing.Point(3, 16);
            this.grpSearch.Name = "grpSearch";
            this.grpSearch.Size = new System.Drawing.Size(1581, 68);
            this.grpSearch.TabIndex = 408;
            this.grpSearch.TabStop = false;
            // 
            // grpPRJ
            // 
            this.grpPRJ.Controls.Add(this.picSeek);
            this.grpPRJ.Controls.Add(this.tKey);
            this.grpPRJ.Controls.Add(this.label4);
            this.grpPRJ.Location = new System.Drawing.Point(132, 33);
            this.grpPRJ.Name = "grpPRJ";
            this.grpPRJ.Size = new System.Drawing.Size(304, 52);
            this.grpPRJ.TabIndex = 449;
            this.grpPRJ.TabStop = false;
            this.grpPRJ.Visible = false;
            // 
            // picSeek
            // 
            this.picSeek.BackColor = System.Drawing.Color.Linen;
            this.picSeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSeek.Image = ((System.Drawing.Image)(resources.GetObject("picSeek.Image")));
            this.picSeek.Location = new System.Drawing.Point(202, 10);
            this.picSeek.Name = "picSeek";
            this.picSeek.Size = new System.Drawing.Size(91, 36);
            this.picSeek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSeek.TabIndex = 454;
            this.picSeek.TabStop = false;
            this.picSeek.Click += new System.EventHandler(this.picSeek_Click);
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.PeachPuff;
            this.tKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.ForeColor = System.Drawing.Color.Black;
            this.tKey.Location = new System.Drawing.Point(100, 21);
            this.tKey.MaxLength = 60;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(96, 20);
            this.tKey.TabIndex = 452;
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Blue;
            this.label4.Location = new System.Drawing.Point(10, 18);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 453;
            this.label4.Text = "Project #:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // Vtot
            // 
            this.Vtot.BackColor = System.Drawing.Color.PaleTurquoise;
            this.Vtot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Vtot.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Vtot.Location = new System.Drawing.Point(1134, 39);
            this.Vtot.Name = "Vtot";
            this.Vtot.Size = new System.Drawing.Size(285, 23);
            this.Vtot.TabIndex = 448;
            this.Vtot.Text = "0";
            this.Vtot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.Vtot.Visible = false;
            // 
            // ltot
            // 
            this.ltot.BackColor = System.Drawing.Color.PaleTurquoise;
            this.ltot.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ltot.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ltot.Location = new System.Drawing.Point(1134, 16);
            this.ltot.Name = "ltot";
            this.ltot.Size = new System.Drawing.Size(285, 23);
            this.ltot.TabIndex = 447;
            this.ltot.Text = "Total Selling Price";
            this.ltot.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.ltot.Visible = false;
            // 
            // lcurNm
            // 
            this.lcurNm.BackColor = System.Drawing.Color.Coral;
            this.lcurNm.Location = new System.Drawing.Point(635, 60);
            this.lcurNm.Name = "lcurNm";
            this.lcurNm.Size = new System.Drawing.Size(44, 23);
            this.lcurNm.TabIndex = 446;
            this.lcurNm.Visible = false;
            // 
            // lcurTRndx
            // 
            this.lcurTRndx.BackColor = System.Drawing.Color.Coral;
            this.lcurTRndx.Location = new System.Drawing.Point(715, 60);
            this.lcurTRndx.Name = "lcurTRndx";
            this.lcurTRndx.Size = new System.Drawing.Size(44, 23);
            this.lcurTRndx.TabIndex = 445;
            this.lcurTRndx.Visible = false;
            // 
            // btnxl
            // 
            this.btnxl.BackColor = System.Drawing.Color.Linen;
            this.btnxl.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnxl.BackgroundImage")));
            this.btnxl.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnxl.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnxl.FlatAppearance.BorderSize = 0;
            this.btnxl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnxl.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnxl.ForeColor = System.Drawing.Color.White;
            this.btnxl.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnxl.Location = new System.Drawing.Point(8, 13);
            this.btnxl.Name = "btnxl";
            this.btnxl.Size = new System.Drawing.Size(85, 49);
            this.btnxl.TabIndex = 444;
            this.btnxl.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.btnxl.UseVisualStyleBackColor = false;
            this.btnxl.Click += new System.EventHandler(this.btnxl_Click);
            // 
            // cbCrit
            // 
            this.cbCrit.BackColor = System.Drawing.Color.White;
            this.cbCrit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCrit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCrit.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCrit.ForeColor = System.Drawing.Color.Red;
            this.cbCrit.FormattingEnabled = true;
            this.cbCrit.Items.AddRange(new object[] {
            "Sales Name"});
            this.cbCrit.Location = new System.Drawing.Point(99, 12);
            this.cbCrit.Name = "cbCrit";
            this.cbCrit.Size = new System.Drawing.Size(337, 21);
            this.cbCrit.TabIndex = 443;
            this.cbCrit.Visible = false;
            this.cbCrit.SelectedIndexChanged += new System.EventHandler(this.cbCrit_SelectedIndexChanged);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Linen;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(4, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(95, 18);
            this.label1.TabIndex = 410;
            this.label1.Text = "Sort By: ";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.label1.Visible = false;
            // 
            // btnLook
            // 
            this.btnLook.BackColor = System.Drawing.Color.Linen;
            this.btnLook.FlatAppearance.BorderSize = 0;
            this.btnLook.Font = new System.Drawing.Font("Verdana", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLook.ForeColor = System.Drawing.Color.White;
            this.btnLook.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnLook.Location = new System.Drawing.Point(768, 16);
            this.btnLook.Name = "btnLook";
            this.btnLook.Size = new System.Drawing.Size(57, 39);
            this.btnLook.TabIndex = 408;
            this.btnLook.UseVisualStyleBackColor = false;
            this.btnLook.Visible = false;
            this.btnLook.Click += new System.EventHandler(this.btnLook_Click);
            // 
            // grpLVcms
            // 
            this.grpLVcms.BackColor = System.Drawing.Color.Linen;
            this.grpLVcms.Controls.Add(this.lvCMS);
            this.grpLVcms.Controls.Add(this.tvsumm);
            this.grpLVcms.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpLVcms.Location = new System.Drawing.Point(0, 102);
            this.grpLVcms.Name = "grpLVcms";
            this.grpLVcms.Size = new System.Drawing.Size(1587, 435);
            this.grpLVcms.TabIndex = 412;
            this.grpLVcms.TabStop = false;
            // 
            // lvCMS
            // 
            this.lvCMS.BackColor = System.Drawing.Color.PeachPuff;
            this.lvCMS.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.PRD,
            this.Prj,
            this.Cust,
            this.dd,
            this.Stk,
            this.Selling,
            this.SalesP,
            this.Salescode});
            this.lvCMS.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCMS.ForeColor = System.Drawing.Color.Black;
            this.lvCMS.FullRowSelect = true;
            this.lvCMS.GridLines = true;
            this.lvCMS.HideSelection = false;
            this.lvCMS.Location = new System.Drawing.Point(791, 16);
            this.lvCMS.MultiSelect = false;
            this.lvCMS.Name = "lvCMS";
            this.lvCMS.Size = new System.Drawing.Size(793, 416);
            this.lvCMS.TabIndex = 413;
            this.lvCMS.UseCompatibleStateImageBehavior = false;
            this.lvCMS.View = System.Windows.Forms.View.Details;
            // 
            // PRD
            // 
            this.PRD.Text = "PRD #";
            this.PRD.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.PRD.Width = 131;
            // 
            // Prj
            // 
            this.Prj.Text = "Project #";
            this.Prj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Prj.Width = 91;
            // 
            // Cust
            // 
            this.Cust.Text = "Customer";
            this.Cust.Width = 232;
            // 
            // dd
            // 
            this.dd.Text = "Delivry Date";
            this.dd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dd.Width = 117;
            // 
            // Stk
            // 
            this.Stk.Text = "STK Code";
            this.Stk.Width = 282;
            // 
            // Selling
            // 
            this.Selling.Text = "Selling Price $";
            this.Selling.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Selling.Width = 147;
            // 
            // SalesP
            // 
            this.SalesP.Text = "Sales Name";
            this.SalesP.Width = 133;
            // 
            // Salescode
            // 
            this.Salescode.Text = "";
            this.Salescode.Width = 0;
            // 
            // tvsumm
            // 
            this.tvsumm.BackColor = System.Drawing.Color.Linen;
            this.tvsumm.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvsumm.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvsumm.ForeColor = System.Drawing.Color.Blue;
            this.tvsumm.FullRowSelect = true;
            this.tvsumm.Location = new System.Drawing.Point(3, 16);
            this.tvsumm.Name = "tvsumm";
            this.tvsumm.Size = new System.Drawing.Size(788, 416);
            this.tvsumm.TabIndex = 412;
            this.tvsumm.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvsumm_AfterSelect);
            // 
            // Order_Sched_RP
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1587, 537);
            this.Controls.Add(this.grpLVcms);
            this.Controls.Add(this.grpSrch);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Order_Sched_RP";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Schedule List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Order_Sched_RP_Load);
            this.grpSrch.ResumeLayout(false);
            this.grpSearch.ResumeLayout(false);
            this.grpPRJ.ResumeLayout(false);
            this.grpPRJ.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).EndInit();
            this.grpLVcms.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpSrch;
        private System.Windows.Forms.GroupBox grpSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox grpLVcms;
        public System.Windows.Forms.ComboBox cbCrit;
        private System.Windows.Forms.Button btnxl;
        private System.Windows.Forms.ListView lvCMS;
        private System.Windows.Forms.ColumnHeader SalesP;
        private System.Windows.Forms.ColumnHeader Prj;
        private System.Windows.Forms.ColumnHeader Cust;
        private System.Windows.Forms.ColumnHeader dd;
        private System.Windows.Forms.ColumnHeader PRD;
        private System.Windows.Forms.ColumnHeader Stk;
        private System.Windows.Forms.ColumnHeader Selling;
        private System.Windows.Forms.ColumnHeader Salescode;
        private System.Windows.Forms.TreeView tvsumm;
        private System.Windows.Forms.Label lcurTRndx;
        private System.Windows.Forms.Label lcurNm;
        private System.Windows.Forms.Label Vtot;
        private System.Windows.Forms.Label ltot;
        private System.Windows.Forms.Button btnLook;
        private System.Windows.Forms.GroupBox grpPRJ;
        private System.Windows.Forms.PictureBox picSeek;
        public System.Windows.Forms.TextBox tKey;
        private System.Windows.Forms.Label label4;
    }
}