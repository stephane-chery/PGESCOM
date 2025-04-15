using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for InfoBoard.
	/// </summary>
	public class PSM_About : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.Label lcntr;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label lCRight;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lBuild;
        private Label label5;
        private PictureBox pictureBox1;
		private System.ComponentModel.IContainer components;

		public PSM_About(string bld)
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();
	        //label1.Text = msg;
	        //timer1.Enabled = true;
			lBuild.Text = bld;

			//
			//TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if(disposing)
			{
				if(components != null)
				{
					components.Dispose();
				}
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PSM_About));
            this.label1 = new System.Windows.Forms.Label();
            this.lcntr = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.panel2 = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lCRight = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lBuild = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.White;
            this.label1.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(9, 93);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(109, 24);
            this.label1.TabIndex = 0;
            this.label1.Text = "Version 17.1.8";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lcntr
            // 
            this.lcntr.BackColor = System.Drawing.SystemColors.Control;
            this.lcntr.Font = new System.Drawing.Font("Georgia", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lcntr.ForeColor = System.Drawing.Color.DarkGreen;
            this.lcntr.Location = new System.Drawing.Point(720, 16);
            this.lcntr.Name = "lcntr";
            this.lcntr.Size = new System.Drawing.Size(80, 72);
            this.lcntr.TabIndex = 1;
            this.lcntr.Text = "10";
            this.lcntr.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Controls.Add(this.pictureBox1);
            this.panel2.Controls.Add(this.pictureBox2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(362, 56);
            this.panel2.TabIndex = 6;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Khaki;
            this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(171, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 210;
            this.pictureBox1.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox2.Image")));
            this.pictureBox2.Location = new System.Drawing.Point(-10, 0);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(181, 48);
            this.pictureBox2.TabIndex = 33;
            this.pictureBox2.TabStop = false;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(72, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(24, 8);
            this.label3.TabIndex = 34;
            // 
            // lCRight
            // 
            this.lCRight.BackColor = System.Drawing.Color.White;
            this.lCRight.Enabled = false;
            this.lCRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCRight.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lCRight.Location = new System.Drawing.Point(5, 126);
            this.lCRight.Name = "lCRight";
            this.lCRight.Size = new System.Drawing.Size(352, 16);
            this.lCRight.TabIndex = 205;
            this.lCRight.Text = "Copyright © 2003-2023 Primax Technologies Inc.";
            this.lCRight.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.Color.White;
            this.label4.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label4.Location = new System.Drawing.Point(9, 64);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 24);
            this.label4.TabIndex = 207;
            this.label4.Text = "Build:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lBuild
            // 
            this.lBuild.BackColor = System.Drawing.Color.White;
            this.lBuild.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lBuild.ForeColor = System.Drawing.Color.Maroon;
            this.lBuild.Location = new System.Drawing.Point(55, 59);
            this.lBuild.Name = "lBuild";
            this.lBuild.Size = new System.Drawing.Size(302, 34);
            this.lBuild.TabIndex = 208;
            this.lBuild.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.lBuild.Click += new System.EventHandler(this.lBuild_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.Color.White;
            this.label5.Enabled = false;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(8, 142);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(339, 16);
            this.label5.TabIndex = 209;
            this.label5.Text = "Credits : Haissam Nasrat && Abdelhakim Edebbab ";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PSM_About
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(362, 167);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.lBuild);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.lCRight);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.lcntr);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "PSM_About";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Primax GEStion COMmerciale";
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if (lcntr.Text == "0") this.Close();
			else 
			{
				lcntr.Text = Convert.ToString(Convert.ToInt32(lcntr.Text) - 1); 
				//this.Opacity -= 10;
			}
		}

        private void lBuild_Click(object sender, EventArgs e)
        {

        }

    }
}