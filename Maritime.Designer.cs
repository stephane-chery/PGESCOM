namespace PGESCOM
{
    partial class Maritime
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Maritime));
            this.grpBox_ok = new System.Windows.Forms.GroupBox();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.btn_ok = new System.Windows.Forms.Button();
            this.lstView_Maritime = new System.Windows.Forms.ListView();
            this.Inc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.description = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cat1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cat2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cat3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cataloguePrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.costPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sellPrice = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.leadTime = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.priceLine_Id = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.primaxCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lbl_save = new System.Windows.Forms.Label();
            this.grpBox_ok.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBox_ok
            // 
            this.grpBox_ok.Controls.Add(this.btn_cancel);
            this.grpBox_ok.Controls.Add(this.btn_ok);
            this.grpBox_ok.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBox_ok.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpBox_ok.Location = new System.Drawing.Point(0, 0);
            this.grpBox_ok.Name = "grpBox_ok";
            this.grpBox_ok.Size = new System.Drawing.Size(1121, 50);
            this.grpBox_ok.TabIndex = 0;
            this.grpBox_ok.TabStop = false;
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cancel.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_cancel.Location = new System.Drawing.Point(554, 11);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(80, 34);
            this.btn_cancel.TabIndex = 3;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // btn_ok
            // 
            this.btn_ok.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_ok.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_ok.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_ok.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_ok.Location = new System.Drawing.Point(423, 11);
            this.btn_ok.Name = "btn_ok";
            this.btn_ok.Size = new System.Drawing.Size(80, 34);
            this.btn_ok.TabIndex = 2;
            this.btn_ok.Text = "Ok";
            this.btn_ok.UseVisualStyleBackColor = false;
            this.btn_ok.Click += new System.EventHandler(this.btn_ok_Click);
            // 
            // lstView_Maritime
            // 
            this.lstView_Maritime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lstView_Maritime.CheckBoxes = true;
            this.lstView_Maritime.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Inc,
            this.description,
            this.cat1,
            this.cat2,
            this.cat3,
            this.cataloguePrice,
            this.costPrice,
            this.sellPrice,
            this.leadTime,
            this.priceLine_Id,
            this.primaxCode});
            this.lstView_Maritime.Dock = System.Windows.Forms.DockStyle.Top;
            this.lstView_Maritime.ForeColor = System.Drawing.Color.Blue;
            this.lstView_Maritime.FullRowSelect = true;
            this.lstView_Maritime.GridLines = true;
            this.lstView_Maritime.HideSelection = false;
            this.lstView_Maritime.Location = new System.Drawing.Point(0, 50);
            this.lstView_Maritime.Name = "lstView_Maritime";
            this.lstView_Maritime.Size = new System.Drawing.Size(1121, 510);
            this.lstView_Maritime.TabIndex = 1;
            this.lstView_Maritime.UseCompatibleStateImageBehavior = false;
            this.lstView_Maritime.View = System.Windows.Forms.View.Details;
            this.lstView_Maritime.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lstView_Maritime_ColumnClick);
            // 
            // Inc
            // 
            this.Inc.Text = "In";
            this.Inc.Width = 30;
            // 
            // description
            // 
            this.description.Text = "Description";
            this.description.Width = 522;
            // 
            // cat1
            // 
            this.cat1.Text = "Cat1";
            this.cat1.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cat1.Width = 50;
            // 
            // cat2
            // 
            this.cat2.Text = "Cat2";
            this.cat2.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cat2.Width = 50;
            // 
            // cat3
            // 
            this.cat3.Text = "Cat3";
            this.cat3.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cat3.Width = 50;
            // 
            // cataloguePrice
            // 
            this.cataloguePrice.Text = "Catalogue Price";
            this.cataloguePrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.cataloguePrice.Width = 88;
            // 
            // costPrice
            // 
            this.costPrice.Text = "Cost Price";
            this.costPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.costPrice.Width = 68;
            // 
            // sellPrice
            // 
            this.sellPrice.Text = "Sell Price";
            this.sellPrice.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.sellPrice.Width = 68;
            // 
            // leadTime
            // 
            this.leadTime.Text = "Lead Time";
            this.leadTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.leadTime.Width = 62;
            // 
            // priceLine_Id
            // 
            this.priceLine_Id.Text = "";
            this.priceLine_Id.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.priceLine_Id.Width = 0;
            // 
            // primaxCode
            // 
            this.primaxCode.Text = "Primax Code";
            this.primaxCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.primaxCode.Width = 130;
            // 
            // lbl_save
            // 
            this.lbl_save.BackColor = System.Drawing.Color.DodgerBlue;
            this.lbl_save.Location = new System.Drawing.Point(856, 192);
            this.lbl_save.Name = "lbl_save";
            this.lbl_save.Size = new System.Drawing.Size(40, 16);
            this.lbl_save.TabIndex = 2;
            this.lbl_save.Text = "N";
            this.lbl_save.Visible = false;
            // 
            // Maritime
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.ClientSize = new System.Drawing.Size(1121, 568);
            this.Controls.Add(this.lbl_save);
            this.Controls.Add(this.lstView_Maritime);
            this.Controls.Add(this.grpBox_ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Maritime";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Maritime";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.grpBox_ok.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBox_ok;
        public System.Windows.Forms.ListView lstView_Maritime;
        private System.Windows.Forms.ColumnHeader Inc;
        private System.Windows.Forms.ColumnHeader description;
        private System.Windows.Forms.ColumnHeader cataloguePrice;
        private System.Windows.Forms.ColumnHeader leadTime;
        private System.Windows.Forms.ColumnHeader primaxCode;
        private System.Windows.Forms.Button btn_ok;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.ColumnHeader costPrice;
        private System.Windows.Forms.ColumnHeader sellPrice;
        private System.Windows.Forms.ColumnHeader priceLine_Id;
        private System.Windows.Forms.ColumnHeader cat1;
        private System.Windows.Forms.ColumnHeader cat2;
        private System.Windows.Forms.ColumnHeader cat3;
        public System.Windows.Forms.Label lbl_save;
    }
}