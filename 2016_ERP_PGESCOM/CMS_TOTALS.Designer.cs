namespace PGESCOM
{
    partial class CMS_TOTALS
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CMS_TOTALS));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.grpInv = new System.Windows.Forms.GroupBox();
            this.ed_lvITM = new PGESCOM.ed_LVmodif();
            this.Name = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TOTAL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.grpInv.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(363, 54);
            this.groupBox1.TabIndex = 250;
            this.groupBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(45, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(34, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Copy ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(12, 12);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(33, 35);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // grpInv
            // 
            this.grpInv.Controls.Add(this.ed_lvITM);
            this.grpInv.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpInv.Location = new System.Drawing.Point(0, 54);
            this.grpInv.Name = "grpInv";
            this.grpInv.Size = new System.Drawing.Size(363, 374);
            this.grpInv.TabIndex = 251;
            this.grpInv.TabStop = false;
            // 
            // ed_lvITM
            // 
            this.ed_lvITM.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvITM.AutoArrange = false;
            this.ed_lvITM.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ed_lvITM.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Name,
            this.TOTAL});
            this.ed_lvITM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_lvITM.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvITM.ForeColor = System.Drawing.Color.Black;
            this.ed_lvITM.FullRowSelect = true;
            this.ed_lvITM.GridLines = true;
            this.ed_lvITM.Location = new System.Drawing.Point(3, 16);
            this.ed_lvITM.Name = "ed_lvITM";
            this.ed_lvITM.Size = new System.Drawing.Size(357, 355);
            this.ed_lvITM.TabIndex = 251;
            this.ed_lvITM.UseCompatibleStateImageBehavior = false;
            this.ed_lvITM.View = System.Windows.Forms.View.Details;
            this.ed_lvITM.SelectedIndexChanged += new System.EventHandler(this.ed_lvITM_SelectedIndexChanged);
            // 
            // Name
            // 
            this.Name.Text = "CMS_TOTALS";
            this.Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Name.Width = 202;
            // 
            // TOTAL
            // 
            this.TOTAL.Text = "TOTAL";
            this.TOTAL.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.TOTAL.Width = 128;
            // 
            // CMS_TOTALS
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(363, 428);
            this.Controls.Add(this.grpInv);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
       //     this.Name = "CMS";// "CMS_TOTALS";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CMS TOTALS";
            this.Load += new System.EventHandler(this.CMS_TOTALS_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.grpInv.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox grpInv;
        private ed_LVmodif ed_lvITM;
        private System.Windows.Forms.ColumnHeader Name;
        private System.Windows.Forms.ColumnHeader TOTAL;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
    }
}