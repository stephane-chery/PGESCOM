namespace SIMCHUPS
{
    partial class MainM
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainM));
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btnMSG = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.btnfloat = new System.Windows.Forms.Button();
            this.btnEqua = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.btnRelay = new System.Windows.Forms.Button();
            this.btnAMBR = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnfloat_modif = new System.Windows.Forms.Button();
            this.btnSetting = new System.Windows.Forms.Button();
            this.btnEqua_modif = new System.Windows.Forms.Button();
            this.btnTools = new System.Windows.Forms.Button();
            this.timer_Msg = new System.Windows.Forms.Timer(this.components);
            this.timer_blink = new System.Windows.Forms.Timer(this.components);
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox4
            // 
            this.groupBox4.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox4.Controls.Add(this.btnMSG);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox4.Location = new System.Drawing.Point(0, 319);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1031, 131);
            this.groupBox4.TabIndex = 11;
            this.groupBox4.TabStop = false;
            this.groupBox4.Enter += new System.EventHandler(this.groupBox4_Enter);
            // 
            // btnMSG
            // 
            this.btnMSG.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnMSG.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnMSG.Font = new System.Drawing.Font("Verdana", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnMSG.ForeColor = System.Drawing.Color.White;
            this.btnMSG.Location = new System.Drawing.Point(6, 12);
            this.btnMSG.Name = "btnMSG";
            this.btnMSG.Size = new System.Drawing.Size(1018, 114);
            this.btnMSG.TabIndex = 0;
            this.btnMSG.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnMSG.UseVisualStyleBackColor = false;
            // 
            // groupBox3
            // 
            this.groupBox3.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox3.Controls.Add(this.btnfloat);
            this.groupBox3.Controls.Add(this.btnEqua);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox3.Location = new System.Drawing.Point(0, 188);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1031, 131);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Enter += new System.EventHandler(this.groupBox3_Enter);
            // 
            // btnfloat
            // 
            this.btnfloat.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfloat.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfloat.ForeColor = System.Drawing.Color.White;
            this.btnfloat.Location = new System.Drawing.Point(6, 12);
            this.btnfloat.Name = "btnfloat";
            this.btnfloat.Size = new System.Drawing.Size(502, 111);
            this.btnfloat.TabIndex = 0;
            this.btnfloat.Text = "136.2V";
            this.btnfloat.UseVisualStyleBackColor = true;
            this.btnfloat.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnEqua
            // 
            this.btnEqua.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqua.Font = new System.Drawing.Font("Verdana", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEqua.ForeColor = System.Drawing.Color.White;
            this.btnEqua.Location = new System.Drawing.Point(514, 14);
            this.btnEqua.Name = "btnEqua";
            this.btnEqua.Size = new System.Drawing.Size(511, 111);
            this.btnEqua.TabIndex = 1;
            this.btnEqua.Text = "20.1A";
            this.btnEqua.UseVisualStyleBackColor = true;
            this.btnEqua.Click += new System.EventHandler(this.button4_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox2.Controls.Add(this.pictureBox1);
            this.groupBox2.Controls.Add(this.btnRelay);
            this.groupBox2.Controls.Add(this.btnAMBR);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(0, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(1031, 97);
            this.groupBox2.TabIndex = 9;
            this.groupBox2.TabStop = false;
            this.groupBox2.Enter += new System.EventHandler(this.groupBox2_Enter);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(904, 50);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 17);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            // 
            // btnRelay
            // 
            this.btnRelay.BackColor = System.Drawing.SystemColors.HotTrack;
            this.btnRelay.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRelay.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRelay.ForeColor = System.Drawing.Color.White;
            this.btnRelay.Location = new System.Drawing.Point(633, 14);
            this.btnRelay.Name = "btnRelay";
            this.btnRelay.Size = new System.Drawing.Size(391, 78);
            this.btnRelay.TabIndex = 1;
            this.btnRelay.Text = "Relay reset";
            this.btnRelay.UseVisualStyleBackColor = false;
            this.btnRelay.Click += new System.EventHandler(this.btnRelay_Click);
            // 
            // btnAMBR
            // 
            this.btnAMBR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAMBR.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAMBR.ForeColor = System.Drawing.Color.White;
            this.btnAMBR.Location = new System.Drawing.Point(6, 12);
            this.btnAMBR.Name = "btnAMBR";
            this.btnAMBR.Size = new System.Drawing.Size(621, 80);
            this.btnAMBR.TabIndex = 0;
            this.btnAMBR.Text = "Alarm message && buzzer reset";
            this.btnAMBR.UseVisualStyleBackColor = true;
            this.btnAMBR.Click += new System.EventHandler(this.btnAMBR_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.BackColor = System.Drawing.SystemColors.HotTrack;
            this.groupBox1.Controls.Add(this.btnfloat_modif);
            this.groupBox1.Controls.Add(this.btnSetting);
            this.groupBox1.Controls.Add(this.btnEqua_modif);
            this.groupBox1.Controls.Add(this.btnTools);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1031, 91);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // btnfloat_modif
            // 
            this.btnfloat_modif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnfloat_modif.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnfloat_modif.ForeColor = System.Drawing.Color.White;
            this.btnfloat_modif.Location = new System.Drawing.Point(6, 12);
            this.btnfloat_modif.Name = "btnfloat_modif";
            this.btnfloat_modif.Size = new System.Drawing.Size(236, 72);
            this.btnfloat_modif.TabIndex = 0;
            this.btnfloat_modif.Text = "Float";
            this.btnfloat_modif.UseVisualStyleBackColor = true;
            this.btnfloat_modif.Click += new System.EventHandler(this.btnfloat_modif_Click);
            // 
            // btnSetting
            // 
            this.btnSetting.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSetting.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSetting.ForeColor = System.Drawing.Color.White;
            this.btnSetting.Location = new System.Drawing.Point(724, 12);
            this.btnSetting.Name = "btnSetting";
            this.btnSetting.Size = new System.Drawing.Size(301, 72);
            this.btnSetting.TabIndex = 3;
            this.btnSetting.Text = "Setting";
            this.btnSetting.UseVisualStyleBackColor = true;
            this.btnSetting.Click += new System.EventHandler(this.btnSetting_Click);
            // 
            // btnEqua_modif
            // 
            this.btnEqua_modif.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnEqua_modif.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEqua_modif.ForeColor = System.Drawing.Color.White;
            this.btnEqua_modif.Location = new System.Drawing.Point(248, 12);
            this.btnEqua_modif.Name = "btnEqua_modif";
            this.btnEqua_modif.Size = new System.Drawing.Size(236, 72);
            this.btnEqua_modif.TabIndex = 1;
            this.btnEqua_modif.Text = "Equalize";
            this.btnEqua_modif.UseVisualStyleBackColor = true;
            this.btnEqua_modif.Click += new System.EventHandler(this.btnEqua_modif_Click);
            // 
            // btnTools
            // 
            this.btnTools.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTools.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTools.ForeColor = System.Drawing.Color.White;
            this.btnTools.Location = new System.Drawing.Point(490, 12);
            this.btnTools.Name = "btnTools";
            this.btnTools.Size = new System.Drawing.Size(228, 72);
            this.btnTools.TabIndex = 2;
            this.btnTools.Text = "Tools";
            this.btnTools.UseVisualStyleBackColor = true;
            this.btnTools.Click += new System.EventHandler(this.btnTools_Click);
            // 
            // timer_Msg
            // 
            this.timer_Msg.Interval = 1000;
            this.timer_Msg.Tick += new System.EventHandler(this.timer_Msg_Tick);
            // 
            // timer_blink
            // 
            this.timer_blink.Enabled = true;
            this.timer_blink.Interval = 1000;
            this.timer_blink.Tick += new System.EventHandler(this.timer_blink_Tick);
            // 
            // MainM
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HotTrack;
            this.ClientSize = new System.Drawing.Size(1031, 457);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainM";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Charger Simulator";
            this.Load += new System.EventHandler(this.MainM_Load);
            this.VisibleChanged += new System.EventHandler(this.MainM_VisibleChanged);
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btnMSG;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button btnfloat;
        private System.Windows.Forms.Button btnEqua;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnAMBR;
        private System.Windows.Forms.Button btnRelay;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnfloat_modif;
        private System.Windows.Forms.Button btnSetting;
        private System.Windows.Forms.Button btnEqua_modif;
        private System.Windows.Forms.Button btnTools;
        private System.Windows.Forms.Timer timer_Msg;
        private System.Windows.Forms.Timer timer_blink;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}