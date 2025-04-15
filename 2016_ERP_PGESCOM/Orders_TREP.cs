using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for Orders_TREP.
	/// </summary>
	public class Orders_TREP : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ColumnHeader tested;
		private System.Windows.Forms.ColumnHeader descSnb;
		private System.Windows.Forms.ColumnHeader Adj;
		private System.Windows.Forms.ColumnHeader com;
		private System.Windows.Forms.ColumnHeader lv_TecV;
		private System.Windows.Forms.ColumnHeader ELID;
		private System.Windows.Forms.ColumnHeader C_DY;
		private System.Windows.Forms.ColumnHeader C_ML;
		private System.Windows.Forms.ColumnHeader C_RY;
		private System.Windows.Forms.ColumnHeader C_RL;
		private System.Windows.Forms.ColumnHeader C_FS;
		private System.Windows.Forms.ColumnHeader C_TO;
		private System.Windows.Forms.GroupBox groupBox14;
		private System.Windows.Forms.PictureBox pictureBox6;
		private System.Windows.Forms.PictureBox pictureBox3;
		private System.Windows.Forms.ColumnHeader DVV;
		private System.Windows.Forms.ColumnHeader DYV;
		private System.Windows.Forms.ColumnHeader MLV;
		private System.Windows.Forms.ColumnHeader RYV;
		private System.Windows.Forms.ColumnHeader RLV;
		private System.Windows.Forms.ColumnHeader FSV;
		private System.Windows.Forms.ColumnHeader TOV;
		public PGESCOM.Modified_EditListView MLV_EqAlrmTR;
		private System.ComponentModel.IContainer components;

		public Orders_TREP()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new string[] {
            "",
            "",
            ""}, 9);
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Orders_TREP));
            this.MLV_EqAlrmTR = new PGESCOM.Modified_EditListView();
            this.tested = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.descSnb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Adj = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DVV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.C_DY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DYV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.C_ML = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.MLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.C_RY = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RYV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.C_RL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.RLV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.C_FS = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FSV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.C_TO = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TOV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.com = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lv_TecV = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ELID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox14 = new System.Windows.Forms.GroupBox();
            this.pictureBox6 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.groupBox14.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            this.SuspendLayout();
            // 
            // MLV_EqAlrmTR
            // 
            this.MLV_EqAlrmTR.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.MLV_EqAlrmTR.AutoArrange = false;
            this.MLV_EqAlrmTR.BackColor = System.Drawing.Color.WhiteSmoke;
            this.MLV_EqAlrmTR.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.tested,
            this.descSnb,
            this.Adj,
            this.DVV,
            this.C_DY,
            this.DYV,
            this.C_ML,
            this.MLV,
            this.C_RY,
            this.RYV,
            this.C_RL,
            this.RLV,
            this.C_FS,
            this.FSV,
            this.C_TO,
            this.TOV,
            this.com,
            this.lv_TecV,
            this.ELID});
            this.MLV_EqAlrmTR.Dock = System.Windows.Forms.DockStyle.Top;
            this.MLV_EqAlrmTR.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MLV_EqAlrmTR.ForeColor = System.Drawing.Color.Black;
            this.MLV_EqAlrmTR.FullRowSelect = true;
            this.MLV_EqAlrmTR.GridLines = true;
            this.MLV_EqAlrmTR.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
            listViewItem1});
            this.MLV_EqAlrmTR.Location = new System.Drawing.Point(0, 48);
            this.MLV_EqAlrmTR.Name = "MLV_EqAlrmTR";
            this.MLV_EqAlrmTR.Size = new System.Drawing.Size(944, 568);
            this.MLV_EqAlrmTR.TabIndex = 257;
            this.MLV_EqAlrmTR.UseCompatibleStateImageBehavior = false;
            this.MLV_EqAlrmTR.View = System.Windows.Forms.View.Details;
            // 
            // tested
            // 
            this.tested.Text = "Tested";
            this.tested.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.tested.Width = 46;
            // 
            // descSnb
            // 
            this.descSnb.Text = " Description / Symbol";
            this.descSnb.Width = 123;
            // 
            // Adj
            // 
            this.Adj.Text = " Adjusment";
            this.Adj.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Adj.Width = 68;
            // 
            // DVV
            // 
            this.DVV.Text = "tst";
            this.DVV.Width = 34;
            // 
            // C_DY
            // 
            this.C_DY.Text = " Delay";
            this.C_DY.Width = 44;
            // 
            // DYV
            // 
            this.DYV.Text = "tst";
            this.DYV.Width = 35;
            // 
            // C_ML
            // 
            this.C_ML.Text = " Msg Latch";
            this.C_ML.Width = 69;
            // 
            // MLV
            // 
            this.MLV.Text = "tst";
            this.MLV.Width = 27;
            // 
            // C_RY
            // 
            this.C_RY.Text = " Relay #";
            this.C_RY.Width = 54;
            // 
            // RYV
            // 
            this.RYV.Text = "tst";
            this.RYV.Width = 30;
            // 
            // C_RL
            // 
            this.C_RL.Text = " Relay Latch";
            this.C_RL.Width = 72;
            // 
            // RLV
            // 
            this.RLV.Text = "tst";
            this.RLV.Width = 35;
            // 
            // C_FS
            // 
            this.C_FS.Text = " Fail Safe";
            // 
            // FSV
            // 
            this.FSV.Text = "tst";
            this.FSV.Width = 31;
            // 
            // C_TO
            // 
            this.C_TO.Text = " Time Out";
            // 
            // TOV
            // 
            this.TOV.Text = "tst";
            this.TOV.Width = 33;
            // 
            // com
            // 
            this.com.Text = "Comments";
            this.com.Width = 86;
            // 
            // lv_TecV
            // 
            this.lv_TecV.Text = "";
            this.lv_TecV.Width = 0;
            // 
            // ELID
            // 
            this.ELID.Text = "";
            this.ELID.Width = 0;
            // 
            // groupBox14
            // 
            this.groupBox14.Controls.Add(this.pictureBox6);
            this.groupBox14.Controls.Add(this.pictureBox3);
            this.groupBox14.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox14.Location = new System.Drawing.Point(0, 0);
            this.groupBox14.Name = "groupBox14";
            this.groupBox14.Size = new System.Drawing.Size(944, 48);
            this.groupBox14.TabIndex = 256;
            this.groupBox14.TabStop = false;
            // 
            // pictureBox6
            // 
            this.pictureBox6.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox6.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox6.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox6.Image")));
            this.pictureBox6.Location = new System.Drawing.Point(56, 8);
            this.pictureBox6.Name = "pictureBox6";
            this.pictureBox6.Size = new System.Drawing.Size(32, 32);
            this.pictureBox6.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox6.TabIndex = 247;
            this.pictureBox6.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox3.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox3.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox3.Image")));
            this.pictureBox3.Location = new System.Drawing.Point(8, 8);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(32, 32);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox3.TabIndex = 246;
            this.pictureBox3.TabStop = false;
            // 
            // Orders_TREP
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(944, 626);
            this.Controls.Add(this.MLV_EqAlrmTR);
            this.Controls.Add(this.groupBox14);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Orders_TREP";
            this.Text = "Test Report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Orders_TREP_Load);
            this.groupBox14.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox6)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void Orders_TREP_Load(object sender, System.EventArgs e)
		{
		
		}
	}
}
