
namespace PGESCOM
{
    partial class Confirmation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Confirmation));
            this.grpBox_confirmation = new System.Windows.Forms.GroupBox();
            this.grpBox_batteryType = new System.Windows.Forms.GroupBox();
            this.radioBtn_flooded = new System.Windows.Forms.RadioButton();
            this.radioBtn_ni_cad = new System.Windows.Forms.RadioButton();
            this.radioBtn_vrla = new System.Windows.Forms.RadioButton();
            this.grpBox_confirmation.SuspendLayout();
            this.grpBox_batteryType.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBox_confirmation
            // 
            this.grpBox_confirmation.Controls.Add(this.grpBox_batteryType);
            this.grpBox_confirmation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBox_confirmation.Location = new System.Drawing.Point(0, 0);
            this.grpBox_confirmation.Name = "grpBox_confirmation";
            this.grpBox_confirmation.Size = new System.Drawing.Size(683, 362);
            this.grpBox_confirmation.TabIndex = 0;
            this.grpBox_confirmation.TabStop = false;
            // 
            // grpBox_batteryType
            // 
            this.grpBox_batteryType.Controls.Add(this.radioBtn_vrla);
            this.grpBox_batteryType.Controls.Add(this.radioBtn_ni_cad);
            this.grpBox_batteryType.Controls.Add(this.radioBtn_flooded);
            this.grpBox_batteryType.Location = new System.Drawing.Point(3, 18);
            this.grpBox_batteryType.Name = "grpBox_batteryType";
            this.grpBox_batteryType.Size = new System.Drawing.Size(120, 100);
            this.grpBox_batteryType.TabIndex = 0;
            this.grpBox_batteryType.TabStop = false;
            this.grpBox_batteryType.Text = "Battery Type";
            // 
            // radioBtn_flooded
            // 
            this.radioBtn_flooded.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioBtn_flooded.ForeColor = System.Drawing.Color.Red;
            this.radioBtn_flooded.Location = new System.Drawing.Point(3, 18);
            this.radioBtn_flooded.Name = "radioBtn_flooded";
            this.radioBtn_flooded.Size = new System.Drawing.Size(104, 24);
            this.radioBtn_flooded.TabIndex = 0;
            this.radioBtn_flooded.Text = "Flooded";
            this.radioBtn_flooded.UseVisualStyleBackColor = false;
            // 
            // radioBtn_ni_cad
            // 
            this.radioBtn_ni_cad.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioBtn_ni_cad.ForeColor = System.Drawing.Color.Red;
            this.radioBtn_ni_cad.Location = new System.Drawing.Point(4, 45);
            this.radioBtn_ni_cad.Name = "radioBtn_ni_cad";
            this.radioBtn_ni_cad.Size = new System.Drawing.Size(104, 24);
            this.radioBtn_ni_cad.TabIndex = 1;
            this.radioBtn_ni_cad.Text = "Ni-Cad";
            this.radioBtn_ni_cad.UseVisualStyleBackColor = false;
            // 
            // radioBtn_vrla
            // 
            this.radioBtn_vrla.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.radioBtn_vrla.ForeColor = System.Drawing.Color.Red;
            this.radioBtn_vrla.Location = new System.Drawing.Point(3, 72);
            this.radioBtn_vrla.Name = "radioBtn_vrla";
            this.radioBtn_vrla.Size = new System.Drawing.Size(104, 24);
            this.radioBtn_vrla.TabIndex = 2;
            this.radioBtn_vrla.Text = "VRLA";
            this.radioBtn_vrla.UseVisualStyleBackColor = false;
            // 
            // Confirmation
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(683, 362);
            this.Controls.Add(this.grpBox_confirmation);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Confirmation";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Confirmation";
            this.grpBox_confirmation.ResumeLayout(false);
            this.grpBox_batteryType.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBox_confirmation;
        private System.Windows.Forms.GroupBox grpBox_batteryType;
        private System.Windows.Forms.RadioButton radioBtn_vrla;
        private System.Windows.Forms.RadioButton radioBtn_ni_cad;
        private System.Windows.Forms.RadioButton radioBtn_flooded;
    }
}