namespace PGESCOM
{
    partial class Qimport_duplicat
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Qimport_duplicat));
            this.grpBrd = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.mdl_customers = new PGESCOM.Modified_EditListView();
            this.CustLID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sysproCode = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lCustLID = new System.Windows.Forms.Label();
            this.cbCompanyy = new System.Windows.Forms.ComboBox();
            this.LIQID = new System.Windows.Forms.Label();
            this.btnDuplica = new System.Windows.Forms.Button();
            this.label66 = new System.Windows.Forms.Label();
            this.btnSeek = new System.Windows.Forms.Button();
            this.Qnb = new System.Windows.Forms.TextBox();
            this.btn_find_code = new System.Windows.Forms.Button();
            this.lkey = new System.Windows.Forms.Label();
            this.tKey = new System.Windows.Forms.TextBox();
            this.picDel = new System.Windows.Forms.PictureBox();
            this.pic_MoveR = new System.Windows.Forms.PictureBox();
            this.grpBrd.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_MoveR)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBrd
            // 
            this.grpBrd.Controls.Add(this.label2);
            this.grpBrd.Controls.Add(this.label1);
            this.grpBrd.Controls.Add(this.panel1);
            this.grpBrd.Controls.Add(this.lCustLID);
            this.grpBrd.Controls.Add(this.cbCompanyy);
            this.grpBrd.Controls.Add(this.LIQID);
            this.grpBrd.Controls.Add(this.btnDuplica);
            this.grpBrd.Controls.Add(this.label66);
            this.grpBrd.Controls.Add(this.btnSeek);
            this.grpBrd.Controls.Add(this.Qnb);
            this.grpBrd.Controls.Add(this.btn_find_code);
            this.grpBrd.Controls.Add(this.lkey);
            this.grpBrd.Controls.Add(this.tKey);
            this.grpBrd.Controls.Add(this.picDel);
            this.grpBrd.Controls.Add(this.pic_MoveR);
            this.grpBrd.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBrd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.grpBrd.Location = new System.Drawing.Point(0, 0);
            this.grpBrd.Name = "grpBrd";
            this.grpBrd.Size = new System.Drawing.Size(732, 426);
            this.grpBrd.TabIndex = 369;
            this.grpBrd.TabStop = false;
            this.grpBrd.Enter += new System.EventHandler(this.grpBrd_Enter);
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(585, 269);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(123, 21);
            this.label2.TabIndex = 400;
            this.label2.Text = "Delete from list";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(588, 120);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(123, 21);
            this.label1.TabIndex = 399;
            this.label1.Text = "Add to list";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.mdl_customers);
            this.panel1.Location = new System.Drawing.Point(12, 141);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 279);
            this.panel1.TabIndex = 398;
            // 
            // mdl_customers
            // 
            this.mdl_customers.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.mdl_customers.AutoArrange = false;
            this.mdl_customers.BackColor = System.Drawing.Color.Honeydew;
            this.mdl_customers.CheckBoxes = true;
            this.mdl_customers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.CustLID,
            this.columnHeader2,
            this.sysproCode});
            this.mdl_customers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdl_customers.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdl_customers.ForeColor = System.Drawing.Color.Black;
            this.mdl_customers.FullRowSelect = true;
            this.mdl_customers.GridLines = true;
            this.mdl_customers.Location = new System.Drawing.Point(0, 0);
            this.mdl_customers.Name = "mdl_customers";
            this.mdl_customers.Size = new System.Drawing.Size(506, 279);
            this.mdl_customers.TabIndex = 380;
            this.mdl_customers.UseCompatibleStateImageBehavior = false;
            this.mdl_customers.View = System.Windows.Forms.View.Details;
            // 
            // CustLID
            // 
            this.CustLID.Text = "";
            this.CustLID.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.CustLID.Width = 0;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "Customer Name";
            this.columnHeader2.Width = 481;
            // 
            // sysproCode
            // 
            this.sysproCode.Text = "";
            this.sysproCode.Width = 0;
            // 
            // lCustLID
            // 
            this.lCustLID.BackColor = System.Drawing.Color.MintCream;
            this.lCustLID.Location = new System.Drawing.Point(676, 198);
            this.lCustLID.Name = "lCustLID";
            this.lCustLID.Size = new System.Drawing.Size(35, 24);
            this.lCustLID.TabIndex = 397;
            this.lCustLID.Visible = false;
            // 
            // cbCompanyy
            // 
            this.cbCompanyy.BackColor = System.Drawing.Color.LightGreen;
            this.cbCompanyy.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCompanyy.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cbCompanyy.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCompanyy.ForeColor = System.Drawing.Color.Black;
            this.cbCompanyy.FormattingEnabled = true;
            this.cbCompanyy.Location = new System.Drawing.Point(12, 106);
            this.cbCompanyy.Name = "cbCompanyy";
            this.cbCompanyy.Size = new System.Drawing.Size(509, 24);
            this.cbCompanyy.TabIndex = 395;
            this.cbCompanyy.SelectedIndexChanged += new System.EventHandler(this.cbCompanyy_SelectedIndexChanged);
            // 
            // LIQID
            // 
            this.LIQID.BackColor = System.Drawing.Color.MintCream;
            this.LIQID.Location = new System.Drawing.Point(112, 24);
            this.LIQID.Name = "LIQID";
            this.LIQID.Size = new System.Drawing.Size(35, 13);
            this.LIQID.TabIndex = 394;
            this.LIQID.Visible = false;
            // 
            // btnDuplica
            // 
            this.btnDuplica.BackColor = System.Drawing.Color.Green;
            this.btnDuplica.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDuplica.ForeColor = System.Drawing.Color.White;
            this.btnDuplica.Location = new System.Drawing.Point(552, 16);
            this.btnDuplica.Name = "btnDuplica";
            this.btnDuplica.Size = new System.Drawing.Size(171, 71);
            this.btnDuplica.TabIndex = 392;
            this.btnDuplica.Text = "Duplicate Quote";
            this.btnDuplica.UseVisualStyleBackColor = false;
            this.btnDuplica.Click += new System.EventHandler(this.btnDuplica_Click);
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.SystemColors.Control;
            this.label66.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.Color.DarkRed;
            this.label66.Location = new System.Drawing.Point(153, 25);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(115, 27);
            this.label66.TabIndex = 364;
            this.label66.Text = "Quote #:";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSeek
            // 
            this.btnSeek.BackColor = System.Drawing.Color.Bisque;
            this.btnSeek.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeek.ForeColor = System.Drawing.Color.Black;
            this.btnSeek.Location = new System.Drawing.Point(300, 77);
            this.btnSeek.Name = "btnSeek";
            this.btnSeek.Size = new System.Drawing.Size(80, 23);
            this.btnSeek.TabIndex = 388;
            this.btnSeek.Text = "By Name";
            this.btnSeek.UseVisualStyleBackColor = false;
            this.btnSeek.Click += new System.EventHandler(this.btnSeek_Click);
            // 
            // Qnb
            // 
            this.Qnb.BackColor = System.Drawing.SystemColors.Control;
            this.Qnb.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Qnb.ForeColor = System.Drawing.Color.Black;
            this.Qnb.Location = new System.Drawing.Point(268, 16);
            this.Qnb.MaxLength = 49;
            this.Qnb.Multiline = true;
            this.Qnb.Name = "Qnb";
            this.Qnb.ReadOnly = true;
            this.Qnb.Size = new System.Drawing.Size(137, 38);
            this.Qnb.TabIndex = 363;
            this.Qnb.Text = "99999";
            this.Qnb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Qnb.TextChanged += new System.EventHandler(this.Qnb_TextChanged);
            // 
            // btn_find_code
            // 
            this.btn_find_code.BackColor = System.Drawing.Color.Bisque;
            this.btn_find_code.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_find_code.ForeColor = System.Drawing.Color.Black;
            this.btn_find_code.Location = new System.Drawing.Point(386, 77);
            this.btn_find_code.Name = "btn_find_code";
            this.btn_find_code.Size = new System.Drawing.Size(132, 23);
            this.btn_find_code.TabIndex = 390;
            this.btn_find_code.Text = "By SYSPRO code";
            this.btn_find_code.UseVisualStyleBackColor = false;
            this.btn_find_code.Click += new System.EventHandler(this.btn_find_code_Click);
            // 
            // lkey
            // 
            this.lkey.Font = new System.Drawing.Font("Verdana", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lkey.Location = new System.Drawing.Point(12, 55);
            this.lkey.Name = "lkey";
            this.lkey.Size = new System.Drawing.Size(213, 21);
            this.lkey.TabIndex = 389;
            this.lkey.Text = "Search Customer";
            this.lkey.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.Bisque;
            this.tKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.ForeColor = System.Drawing.Color.Black;
            this.tKey.Location = new System.Drawing.Point(12, 76);
            this.tKey.MaxLength = 60;
            this.tKey.Multiline = true;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(282, 24);
            this.tKey.TabIndex = 0;
            // 
            // picDel
            // 
            this.picDel.BackColor = System.Drawing.Color.Transparent;
            this.picDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDel.Image = ((System.Drawing.Image)(resources.GetObject("picDel.Image")));
            this.picDel.Location = new System.Drawing.Point(524, 259);
            this.picDel.Name = "picDel";
            this.picDel.Size = new System.Drawing.Size(56, 44);
            this.picDel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDel.TabIndex = 383;
            this.picDel.TabStop = false;
            this.picDel.Click += new System.EventHandler(this.picDel_Click);
            // 
            // pic_MoveR
            // 
            this.pic_MoveR.BackColor = System.Drawing.Color.Transparent;
            this.pic_MoveR.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_MoveR.Image = ((System.Drawing.Image)(resources.GetObject("pic_MoveR.Image")));
            this.pic_MoveR.Location = new System.Drawing.Point(527, 97);
            this.pic_MoveR.Name = "pic_MoveR";
            this.pic_MoveR.Size = new System.Drawing.Size(56, 65);
            this.pic_MoveR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_MoveR.TabIndex = 382;
            this.pic_MoveR.TabStop = false;
            this.pic_MoveR.Click += new System.EventHandler(this.pic_MoveR_Click);
            // 
            // Qimport_duplicat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(732, 426);
            this.Controls.Add(this.grpBrd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Qimport_duplicat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Qimport_duplicat";
            this.Load += new System.EventHandler(this.Qimport_duplicat_Load);
            this.grpBrd.ResumeLayout(false);
            this.grpBrd.PerformLayout();
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_MoveR)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBrd;
        private System.Windows.Forms.Button btnDuplica;
        private System.Windows.Forms.Label label66;
        private System.Windows.Forms.Button btnSeek;
        public System.Windows.Forms.TextBox Qnb;
        private System.Windows.Forms.Button btn_find_code;
        private System.Windows.Forms.Label lkey;
        public System.Windows.Forms.TextBox tKey;
        private System.Windows.Forms.PictureBox picDel;
        private System.Windows.Forms.PictureBox pic_MoveR;
        private System.Windows.Forms.Label LIQID;
        private System.Windows.Forms.ComboBox cbCompanyy;
        private System.Windows.Forms.Label lCustLID;
        private System.Windows.Forms.Panel panel1;
        public Modified_EditListView mdl_customers;
        private System.Windows.Forms.ColumnHeader CustLID;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader sysproCode;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}