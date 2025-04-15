
namespace PGESCOM
{
    partial class Add_Protocol
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Add_Protocol));
            this.lbl_description = new System.Windows.Forms.Label();
            this.txtBox_description = new System.Windows.Forms.TextBox();
            this.lbl_price = new System.Windows.Forms.Label();
            this.txtBox_price = new System.Windows.Forms.TextBox();
            this.btn_save = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbl_description
            // 
            this.lbl_description.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_description.ForeColor = System.Drawing.Color.Black;
            this.lbl_description.Location = new System.Drawing.Point(10, 13);
            this.lbl_description.Name = "lbl_description";
            this.lbl_description.Size = new System.Drawing.Size(100, 23);
            this.lbl_description.TabIndex = 0;
            this.lbl_description.Text = "Description";
            this.lbl_description.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBox_description
            // 
            this.txtBox_description.BackColor = System.Drawing.Color.Lavender;
            this.txtBox_description.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_description.ForeColor = System.Drawing.Color.DarkRed;
            this.txtBox_description.Location = new System.Drawing.Point(110, 10);
            this.txtBox_description.MaxLength = 50;
            this.txtBox_description.Multiline = true;
            this.txtBox_description.Name = "txtBox_description";
            this.txtBox_description.Size = new System.Drawing.Size(450, 29);
            this.txtBox_description.TabIndex = 1;
            // 
            // lbl_price
            // 
            this.lbl_price.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lbl_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_price.ForeColor = System.Drawing.Color.Black;
            this.lbl_price.Location = new System.Drawing.Point(560, 13);
            this.lbl_price.Name = "lbl_price";
            this.lbl_price.Size = new System.Drawing.Size(60, 23);
            this.lbl_price.TabIndex = 2;
            this.lbl_price.Text = "Price";
            this.lbl_price.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtBox_price
            // 
            this.txtBox_price.BackColor = System.Drawing.Color.Lavender;
            this.txtBox_price.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBox_price.ForeColor = System.Drawing.Color.DarkRed;
            this.txtBox_price.Location = new System.Drawing.Point(620, 10);
            this.txtBox_price.MaxLength = 50;
            this.txtBox_price.Multiline = true;
            this.txtBox_price.Name = "txtBox_price";
            this.txtBox_price.Size = new System.Drawing.Size(100, 29);
            this.txtBox_price.TabIndex = 3;
            // 
            // btn_save
            // 
            this.btn_save.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_save.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_save.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_save.Location = new System.Drawing.Point(245, 60);
            this.btn_save.Name = "btn_save";
            this.btn_save.Size = new System.Drawing.Size(105, 35);
            this.btn_save.TabIndex = 4;
            this.btn_save.Text = "Save";
            this.btn_save.UseVisualStyleBackColor = false;
            this.btn_save.Click += new System.EventHandler(this.btn_save_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.BackColor = System.Drawing.Color.PowderBlue;
            this.btn_cancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btn_cancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_cancel.Location = new System.Drawing.Point(380, 60);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(105, 35);
            this.btn_cancel.TabIndex = 0;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = false;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // Add_Protocol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(730, 108);
            this.Controls.Add(this.btn_cancel);
            this.Controls.Add(this.btn_save);
            this.Controls.Add(this.txtBox_price);
            this.Controls.Add(this.lbl_price);
            this.Controls.Add(this.txtBox_description);
            this.Controls.Add(this.lbl_description);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Add_Protocol";
            this.Text = "Add Protocol";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lbl_description;
        internal System.Windows.Forms.TextBox txtBox_description;
        private System.Windows.Forms.Label lbl_price;
        internal System.Windows.Forms.TextBox txtBox_price;
        private System.Windows.Forms.Button btn_save;
        private System.Windows.Forms.Button btn_cancel;
    }
}