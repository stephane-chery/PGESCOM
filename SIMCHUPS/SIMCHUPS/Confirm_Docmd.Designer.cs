﻿namespace SIMCHUPS
{
    partial class Confirm_Docmd
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Confirm_Docmd));
            this.btnRET = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnNewV = new System.Windows.Forms.Button();
            this.btnNV_title = new System.Windows.Forms.Button();
            this.btn_oldV = new System.Windows.Forms.Button();
            this.btnOV_title = new System.Windows.Forms.Button();
            this.lstat = new System.Windows.Forms.Label();
            this.btnYES = new System.Windows.Forms.Button();
            this.btnPWD = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_title = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnfloat = new System.Windows.Forms.Button();
            this.btnEqua = new System.Windows.Forms.Button();
            this.btnX = new System.Windows.Forms.Button();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnRET
            // 
            this.btnRET.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnRET.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRET.BackgroundImage")));
            this.btnRET.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRET.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRET.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRET.ForeColor = System.Drawing.Color.White;
            this.btnRET.Location = new System.Drawing.Point(727, 12);
            this.btnRET.Name = "btnRET";
            this.btnRET.Size = new System.Drawing.Size(138, 54);
            this.btnRET.TabIndex = 3;
            this.btnRET.UseVisualStyleBackColor = false;
            this.btnRET.Click += new System.EventHandler(this.btnRET_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Controls.Add(this.btnYES);
            this.groupBox3.Controls.Add(this.btnNewV);
            this.groupBox3.Controls.Add(this.btnNV_title);
            this.groupBox3.Controls.Add(this.btn_oldV);
            this.groupBox3.Controls.Add(this.btnOV_title);
            this.groupBox3.Controls.Add(this.lstat);
            this.groupBox3.Controls.Add(this.btnPWD);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 145);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1032, 312);
            this.groupBox3.TabIndex = 14;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // btnNewV
            // 
            this.btnNewV.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnNewV.FlatAppearance.BorderSize = 0;
            this.btnNewV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNewV.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNewV.ForeColor = System.Drawing.Color.White;
            this.btnNewV.Location = new System.Drawing.Point(670, 187);
            this.btnNewV.Name = "btnNewV";
            this.btnNewV.Size = new System.Drawing.Size(313, 41);
            this.btnNewV.TabIndex = 23;
            this.btnNewV.Text = "9999";
            this.btnNewV.UseVisualStyleBackColor = false;
            this.btnNewV.Visible = false;
            // 
            // btnNV_title
            // 
            this.btnNV_title.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnNV_title.FlatAppearance.BorderSize = 0;
            this.btnNV_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNV_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNV_title.ForeColor = System.Drawing.Color.White;
            this.btnNV_title.Location = new System.Drawing.Point(670, 140);
            this.btnNV_title.Name = "btnNV_title";
            this.btnNV_title.Size = new System.Drawing.Size(313, 41);
            this.btnNV_title.TabIndex = 22;
            this.btnNV_title.Text = "New Value:";
            this.btnNV_title.UseVisualStyleBackColor = false;
            this.btnNV_title.Visible = false;
            // 
            // btn_oldV
            // 
            this.btn_oldV.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_oldV.FlatAppearance.BorderSize = 0;
            this.btn_oldV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_oldV.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_oldV.ForeColor = System.Drawing.Color.White;
            this.btn_oldV.Location = new System.Drawing.Point(670, 66);
            this.btn_oldV.Name = "btn_oldV";
            this.btn_oldV.Size = new System.Drawing.Size(313, 41);
            this.btn_oldV.TabIndex = 21;
            this.btn_oldV.Text = "9999";
            this.btn_oldV.UseVisualStyleBackColor = false;
            this.btn_oldV.Visible = false;
            this.btn_oldV.Click += new System.EventHandler(this.btn_ActV_Click);
            // 
            // btnOV_title
            // 
            this.btnOV_title.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnOV_title.FlatAppearance.BorderSize = 0;
            this.btnOV_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOV_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOV_title.ForeColor = System.Drawing.Color.White;
            this.btnOV_title.Location = new System.Drawing.Point(670, 19);
            this.btnOV_title.Name = "btnOV_title";
            this.btnOV_title.Size = new System.Drawing.Size(313, 41);
            this.btnOV_title.TabIndex = 20;
            this.btnOV_title.Text = "Actual Status:";
            this.btnOV_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnOV_title.UseVisualStyleBackColor = false;
            this.btnOV_title.Click += new System.EventHandler(this.button2_Click);
            // 
            // lstat
            // 
            this.lstat.BackColor = System.Drawing.Color.Yellow;
            this.lstat.Location = new System.Drawing.Point(492, 187);
            this.lstat.Name = "lstat";
            this.lstat.Size = new System.Drawing.Size(20, 13);
            this.lstat.TabIndex = 18;
            this.lstat.Visible = false;
            // 
            // btnYES
            // 
            this.btnYES.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnYES.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnYES.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnYES.ForeColor = System.Drawing.Color.White;
            this.btnYES.Location = new System.Drawing.Point(624, 127);
            this.btnYES.Name = "btnYES";
            this.btnYES.Size = new System.Drawing.Size(152, 60);
            this.btnYES.TabIndex = 13;
            this.btnYES.Text = "OK";
            this.btnYES.UseVisualStyleBackColor = false;
            this.btnYES.Click += new System.EventHandler(this.btnYES_Click);
            // 
            // btnPWD
            // 
            this.btnPWD.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnPWD.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPWD.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPWD.ForeColor = System.Drawing.Color.White;
            this.btnPWD.Location = new System.Drawing.Point(6, 11);
            this.btnPWD.Name = "btnPWD";
            this.btnPWD.Size = new System.Drawing.Size(658, 56);
            this.btnPWD.TabIndex = 0;
            this.btnPWD.Text = "Are you sure ?";
            this.btnPWD.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPWD.UseVisualStyleBackColor = false;
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Controls.Add(this.btn_title);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 72);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1032, 73);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // btn_title
            // 
            this.btn_title.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btn_title.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_title.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_title.ForeColor = System.Drawing.Color.White;
            this.btn_title.Location = new System.Drawing.Point(6, 12);
            this.btn_title.Name = "btn_title";
            this.btn_title.Size = new System.Drawing.Size(1020, 55);
            this.btn_title.TabIndex = 0;
            this.btn_title.Text = "Setting";
            this.btn_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btn_title.UseVisualStyleBackColor = false;
            this.btn_title.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Controls.Add(this.btnfloat);
            this.groupBox1.Controls.Add(this.btnRET);
            this.groupBox1.Controls.Add(this.btnEqua);
            this.groupBox1.Controls.Add(this.btnX);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1032, 72);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnfloat
            // 
            this.btnfloat.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnfloat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfloat.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfloat.ForeColor = System.Drawing.Color.White;
            this.btnfloat.Location = new System.Drawing.Point(6, 12);
            this.btnfloat.Name = "btnfloat";
            this.btnfloat.Size = new System.Drawing.Size(354, 54);
            this.btnfloat.TabIndex = 0;
            this.btnfloat.Text = "136.2V";
            this.btnfloat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnfloat.UseVisualStyleBackColor = false;
            this.btnfloat.Click += new System.EventHandler(this.btnfloat_Click);
            // 
            // btnEqua
            // 
            this.btnEqua.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnEqua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqua.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEqua.ForeColor = System.Drawing.Color.White;
            this.btnEqua.Location = new System.Drawing.Point(366, 12);
            this.btnEqua.Name = "btnEqua";
            this.btnEqua.Size = new System.Drawing.Size(355, 54);
            this.btnEqua.TabIndex = 1;
            this.btnEqua.Text = "20.1A";
            this.btnEqua.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnEqua.UseVisualStyleBackColor = false;
            this.btnEqua.Click += new System.EventHandler(this.btnEqua_Click);
            // 
            // btnX
            // 
            this.btnX.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnX.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnX.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnX.ForeColor = System.Drawing.Color.White;
            this.btnX.Location = new System.Drawing.Point(871, 12);
            this.btnX.Name = "btnX";
            this.btnX.Size = new System.Drawing.Size(155, 54);
            this.btnX.TabIndex = 2;
            this.btnX.Text = "X";
            this.btnX.UseVisualStyleBackColor = false;
            this.btnX.Click += new System.EventHandler(this.btnX_Click);
            // 
            // Confirm_Docmd
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1032, 457);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Confirm_Docmd";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mode Confirmation";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Confirm_Docmd_FormClosing);
            this.Load += new System.EventHandler(this.Confirm_Docmd_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnRET;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnPWD;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_title;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnfloat;
        private System.Windows.Forms.Button btnEqua;
        private System.Windows.Forms.Button btnX;
        private System.Windows.Forms.Button btnYES;
        public System.Windows.Forms.Label lstat;
        private System.Windows.Forms.Button btnNV_title;
        private System.Windows.Forms.Button btn_oldV;
        private System.Windows.Forms.Button btnOV_title;
        public System.Windows.Forms.Button btnNewV;
    }
}