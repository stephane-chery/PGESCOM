
namespace PGESCOM
{
    partial class FindBestUPSInverter
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
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.labelkVA = new System.Windows.Forms.Label();
            this.textBoxkVA = new System.Windows.Forms.TextBox();
            this.textBoxPH9 = new System.Windows.Forms.TextBox();
            this.labelPH9 = new System.Windows.Forms.Label();
            this.textBoxv9 = new System.Windows.Forms.TextBox();
            this.labelv9 = new System.Windows.Forms.Label();
            this.textBoxVDC = new System.Windows.Forms.TextBox();
            this.labelVDC = new System.Windows.Forms.Label();
            this.labelBestP850result = new System.Windows.Forms.Label();
            this.labelFilledValuesRequired = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonInverter = new System.Windows.Forms.RadioButton();
            this.radioButtonUPS = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(9, 7);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(535, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Find the ideal inverter/UPS by filling in the desired P850 values:";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.PeachPuff;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(188, 80);
            this.button1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(111, 34);
            this.button1.TabIndex = 1;
            this.button1.Text = "Find Model";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.buttonFindP850ModelClick);
            // 
            // labelkVA
            // 
            this.labelkVA.AutoSize = true;
            this.labelkVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelkVA.Location = new System.Drawing.Point(24, 71);
            this.labelkVA.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelkVA.Name = "labelkVA";
            this.labelkVA.Size = new System.Drawing.Size(33, 17);
            this.labelkVA.TabIndex = 2;
            this.labelkVA.Text = "kVA";
            // 
            // textBoxkVA
            // 
            this.textBoxkVA.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBoxkVA.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxkVA.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxkVA.Location = new System.Drawing.Point(56, 71);
            this.textBoxkVA.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxkVA.Name = "textBoxkVA";
            this.textBoxkVA.Size = new System.Drawing.Size(76, 23);
            this.textBoxkVA.TabIndex = 3;
            this.textBoxkVA.TextChanged += new System.EventHandler(this.textBoxkVA_TextChanged);
            // 
            // textBoxPH9
            // 
            this.textBoxPH9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBoxPH9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPH9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxPH9.Location = new System.Drawing.Point(56, 44);
            this.textBoxPH9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxPH9.Name = "textBoxPH9";
            this.textBoxPH9.Size = new System.Drawing.Size(76, 23);
            this.textBoxPH9.TabIndex = 4;
            this.textBoxPH9.TextChanged += new System.EventHandler(this.textBoxPH9_TextChanged);
            // 
            // labelPH9
            // 
            this.labelPH9.AutoSize = true;
            this.labelPH9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPH9.Location = new System.Drawing.Point(22, 44);
            this.labelPH9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPH9.Name = "labelPH9";
            this.labelPH9.Size = new System.Drawing.Size(35, 17);
            this.labelPH9.TabIndex = 5;
            this.labelPH9.Text = "PH9";
            // 
            // textBoxv9
            // 
            this.textBoxv9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBoxv9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxv9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxv9.Location = new System.Drawing.Point(56, 98);
            this.textBoxv9.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxv9.Name = "textBoxv9";
            this.textBoxv9.Size = new System.Drawing.Size(76, 23);
            this.textBoxv9.TabIndex = 6;
            this.textBoxv9.TextChanged += new System.EventHandler(this.textBoxv9_TextChanged);
            // 
            // labelv9
            // 
            this.labelv9.AutoSize = true;
            this.labelv9.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelv9.Location = new System.Drawing.Point(32, 98);
            this.labelv9.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelv9.Name = "labelv9";
            this.labelv9.Size = new System.Drawing.Size(23, 17);
            this.labelv9.TabIndex = 7;
            this.labelv9.Text = "v9";
            // 
            // textBoxVDC
            // 
            this.textBoxVDC.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.textBoxVDC.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxVDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxVDC.Location = new System.Drawing.Point(56, 124);
            this.textBoxVDC.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxVDC.Name = "textBoxVDC";
            this.textBoxVDC.Size = new System.Drawing.Size(76, 23);
            this.textBoxVDC.TabIndex = 8;
            this.textBoxVDC.TextChanged += new System.EventHandler(this.textBoxVDC_TextChanged);
            // 
            // labelVDC
            // 
            this.labelVDC.AutoSize = true;
            this.labelVDC.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelVDC.Location = new System.Drawing.Point(24, 124);
            this.labelVDC.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelVDC.Name = "labelVDC";
            this.labelVDC.Size = new System.Drawing.Size(30, 17);
            this.labelVDC.TabIndex = 9;
            this.labelVDC.Text = "vdc";
            // 
            // labelBestP850result
            // 
            this.labelBestP850result.BackColor = System.Drawing.Color.Moccasin;
            this.labelBestP850result.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.labelBestP850result.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelBestP850result.Location = new System.Drawing.Point(326, 44);
            this.labelBestP850result.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelBestP850result.Name = "labelBestP850result";
            this.labelBestP850result.Size = new System.Drawing.Size(250, 102);
            this.labelBestP850result.TabIndex = 10;
            this.labelBestP850result.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelFilledValuesRequired
            // 
            this.labelFilledValuesRequired.AutoSize = true;
            this.labelFilledValuesRequired.ForeColor = System.Drawing.Color.DarkRed;
            this.labelFilledValuesRequired.Location = new System.Drawing.Point(16, 151);
            this.labelFilledValuesRequired.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelFilledValuesRequired.Name = "labelFilledValuesRequired";
            this.labelFilledValuesRequired.Size = new System.Drawing.Size(0, 13);
            this.labelFilledValuesRequired.TabIndex = 11;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.radioButtonInverter);
            this.groupBox1.Controls.Add(this.radioButtonUPS);
            this.groupBox1.Location = new System.Drawing.Point(186, 35);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(113, 40);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            // 
            // radioButtonInverter
            // 
            this.radioButtonInverter.AutoSize = true;
            this.radioButtonInverter.Location = new System.Drawing.Point(52, 18);
            this.radioButtonInverter.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonInverter.Name = "radioButtonInverter";
            this.radioButtonInverter.Size = new System.Drawing.Size(61, 17);
            this.radioButtonInverter.TabIndex = 13;
            this.radioButtonInverter.Text = "Inverter";
            this.radioButtonInverter.UseVisualStyleBackColor = true;
            // 
            // radioButtonUPS
            // 
            this.radioButtonUPS.AutoSize = true;
            this.radioButtonUPS.Checked = true;
            this.radioButtonUPS.Location = new System.Drawing.Point(5, 18);
            this.radioButtonUPS.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.radioButtonUPS.Name = "radioButtonUPS";
            this.radioButtonUPS.Size = new System.Drawing.Size(47, 17);
            this.radioButtonUPS.TabIndex = 0;
            this.radioButtonUPS.TabStop = true;
            this.radioButtonUPS.Text = "UPS";
            this.radioButtonUPS.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.button2.Location = new System.Drawing.Point(209, 132);
            this.button2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 24);
            this.button2.TabIndex = 13;
            this.button2.Text = "OK";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // FindBestUPSInverter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(600, 180);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.labelFilledValuesRequired);
            this.Controls.Add(this.labelBestP850result);
            this.Controls.Add(this.labelVDC);
            this.Controls.Add(this.textBoxVDC);
            this.Controls.Add(this.labelv9);
            this.Controls.Add(this.textBoxv9);
            this.Controls.Add(this.labelPH9);
            this.Controls.Add(this.textBoxPH9);
            this.Controls.Add(this.textBoxkVA);
            this.Controls.Add(this.labelkVA);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "FindBestUPSInverter";
            this.Text = "Find suggested UPS / Inverter";
            this.Click += new System.EventHandler(this.buttonFindP850ModelClick);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label labelkVA;
        private System.Windows.Forms.TextBox textBoxkVA;
        private System.Windows.Forms.TextBox textBoxPH9;
        private System.Windows.Forms.Label labelPH9;
        private System.Windows.Forms.TextBox textBoxv9;
        private System.Windows.Forms.Label labelv9;
        private System.Windows.Forms.TextBox textBoxVDC;
        private System.Windows.Forms.Label labelVDC;
        private System.Windows.Forms.Label labelBestP850result;
        private System.Windows.Forms.Label labelFilledValuesRequired;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButtonUPS;
        private System.Windows.Forms.RadioButton radioButtonInverter;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ColorDialog colorDialog1;
    }
}