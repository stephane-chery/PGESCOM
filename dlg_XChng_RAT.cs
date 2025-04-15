using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using EAHLibs;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for dlgCreditCrds.
	/// </summary>
	public class dlg_XChng_RAT: System.Windows.Forms.Form
	{
        public bool done = false;
		private string in_IRRevid = "";
        string[] in_arr_CFTR = new string[20];
		long lcpnyLID = 0;
		char Opera = 'F';
		int ndxfound = 0;
		private Lib1 Tools = new Lib1();
        public bool lOK = false;
        private ToolStripButton del;
        private ToolStrip TSmain;
        private ToolStripButton newcard;
        private ToolStripButton Save;
        private ToolStripButton exiit;
        private GroupBox groupBox1;
        public ListView lvXchng_rat;
        private ColumnHeader r_LID;
        private ColumnHeader Cur_Nm;
        private ColumnHeader dat_chng;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public dlg_XChng_RAT()
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();

			fill_lvCFTR();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlg_XChng_RAT));
            this.del = new System.Windows.Forms.ToolStripButton();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.newcard = new System.Windows.Forms.ToolStripButton();
            this.Save = new System.Windows.Forms.ToolStripButton();
            this.exiit = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvXchng_rat = new System.Windows.Forms.ListView();
            this.r_LID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cur_Nm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.dat_chng = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader5 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TSmain.SuspendLayout();
            this.SuspendLayout();
            // 
            // del
            // 
            this.del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(87, 60);
            this.del.Text = "Delete Payment";
            this.del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.del.Visible = false;
            // 
            // TSmain
            // 
            this.TSmain.AutoSize = false;
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newcard,
            this.Save,
            this.exiit});
            this.TSmain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.HorizontalStackWithOverflow;
            this.TSmain.Location = new System.Drawing.Point(0, 0);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(551, 63);
            this.TSmain.TabIndex = 331;
            // 
            // newcard
            // 
            this.newcard.Image = ((System.Drawing.Image)(resources.GetObject("newcard.Image")));
            this.newcard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newcard.Name = "newcard";
            this.newcard.Size = new System.Drawing.Size(63, 60);
            this.newcard.Text = "New Card";
            this.newcard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // Save
            // 
            this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
            this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(36, 60);
            this.Save.Text = "Save";
            this.Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // exiit
            // 
            this.exiit.Image = ((System.Drawing.Image)(resources.GetObject("exiit.Image")));
            this.exiit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exiit.Name = "exiit";
            this.exiit.Size = new System.Drawing.Size(60, 60);
            this.exiit.Text = "     Exit     ";
            this.exiit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exiit.ToolTipText = "Exit";
            // 
            // groupBox1
            // 
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 63);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 90);
            this.groupBox1.TabIndex = 332;
            this.groupBox1.TabStop = false;
            // 
            // lvXchng_rat
            // 
            this.lvXchng_rat.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvXchng_rat.AutoArrange = false;
            this.lvXchng_rat.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvXchng_rat.CheckBoxes = true;
            this.lvXchng_rat.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.r_LID,
            this.Cur_Nm,
            this.dat_chng,
            this.columnHeader4,
            this.columnHeader5});
            this.lvXchng_rat.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvXchng_rat.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvXchng_rat.ForeColor = System.Drawing.Color.Black;
            this.lvXchng_rat.FullRowSelect = true;
            this.lvXchng_rat.GridLines = true;
            this.lvXchng_rat.HideSelection = false;
            this.lvXchng_rat.Location = new System.Drawing.Point(0, 153);
            this.lvXchng_rat.Name = "lvXchng_rat";
            this.lvXchng_rat.Size = new System.Drawing.Size(551, 264);
            this.lvXchng_rat.TabIndex = 333;
            this.lvXchng_rat.UseCompatibleStateImageBehavior = false;
            this.lvXchng_rat.View = System.Windows.Forms.View.Details;
            // 
            // r_LID
            // 
            this.r_LID.Text = "";
            this.r_LID.Width = 0;
            // 
            // Cur_Nm
            // 
            this.Cur_Nm.Text = "Currency name";
            // 
            // columnHeader5
            // 
            this.columnHeader5.Width = 78;
            // 
            // dlg_XChng_RAT
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(551, 417);
            this.Controls.Add(this.lvXchng_rat);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TSmain);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Name = "dlg_XChng_RAT";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restore Config  / Test Report";
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void fill_lvCFTR()
		{
            string stSql = "SELECT  CFLID, ConfigNm FROM PSM_R_CFinfo WHERE c_SN ='";
            Color _clr = Color.OldLace;
            for (int t = 0; t < 2; t++)
            {
                if (t == 1)
                {
                    stSql = "SELECT tr_LID, tr_TRName FROM PSM_R_TRInfo WHERE tr_TRName ='TR_";
                    _clr = Color.Beige;
                }
                for (int i = 0; i < 20; i++)
                {
                    if (in_arr_CFTR[i] != "")
                    {
                        string _Nm = "", _cfLID = "";
                        MainMDI.Find_2_Field(stSql + in_arr_CFTR[i] + "'", ref _cfLID, ref _Nm);
                        if (_cfLID != MainMDI.VIDE)
                        {
                            ListViewItem lv = lvXchng_rat.Items.Add("");
                            lv.SubItems.Add(_Nm);
                            lv.SubItems.Add(_cfLID);
                            lv.UseItemStyleForSubItems = false;
                            for (int jj = 0; jj < 3; jj++) lv.SubItems[jj].BackColor = _clr;
                        }
                    }
                    else i = 20;
                }
            }
		}

        private void btnCan_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void btnRstr_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < lvXchng_rat.Items.Count; i++)
            {
                if (lvXchng_rat.Items[i].Checked)
                {
                    string stSql = (lvXchng_rat.Items[i].SubItems[1].Text[0] == 'T') ? "UPDATE PSM_R_TRInfo SET tr_iRRevID =" + in_IRRevid + " where tr_LID=" + lvXchng_rat.Items[i].SubItems[2].Text : "UPDATE PSM_R_CFinfo SET c_RRevLID =" + in_IRRevid + " where CFLID=" + lvXchng_rat.Items[i].SubItems[2].Text;
                    MainMDI.Exec_SQL_JFS(stSql, stSql + " restore config/tst report");
                    done = true;
                }
            }
            if (done)
            {
                MessageBox.Show("Restore Done Successfully .....");
                this.Hide();
            }
            else MessageBox.Show("ERROR in Restore... Contact Admin  .....");
        }
    }
}
