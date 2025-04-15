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
	/// Summary description for importRxx.
	/// </summary>
	public class QimportRxx : System.Windows.Forms.Form
	{
		private System.Windows.Forms.GroupBox groupBox1;
		public System.Windows.Forms.ListView lvQuotes;
		private System.Windows.Forms.ColumnHeader qid;
		private System.Windows.Forms.Label label3;
		public System.Windows.Forms.TextBox tQuoteID;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.ColumnHeader Qn;
		private System.Windows.Forms.ColumnHeader Cpny;
		public System.Windows.Forms.TextBox tcpnyName;
		public System.Windows.Forms.TextBox tSolName;
		public System.Windows.Forms.Label lIQID;
		private System.Windows.Forms.ColumnHeader cpnyID;
		public System.Windows.Forms.Label lcpnyID;
		public System.Windows.Forms.ListView lvSol;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		public System.Windows.Forms.Label lSolid;
		private System.Windows.Forms.Button btnImport;
		public System.Windows.Forms.Label lsave;
        private Button btnSeek;
        private Button btn_find_code;
        public TextBox tKey;
        private Label label4;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public QimportRxx()
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();
			fill_lvQuotes();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QimportRxx));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lvSol = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader4 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lvQuotes = new System.Windows.Forms.ListView();
            this.Qn = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cpny = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.qid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cpnyID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.label3 = new System.Windows.Forms.Label();
            this.tQuoteID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tcpnyName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.tSolName = new System.Windows.Forms.TextBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnImport = new System.Windows.Forms.Button();
            this.lIQID = new System.Windows.Forms.Label();
            this.lcpnyID = new System.Windows.Forms.Label();
            this.lSolid = new System.Windows.Forms.Label();
            this.lsave = new System.Windows.Forms.Label();
            this.btnSeek = new System.Windows.Forms.Button();
            this.btn_find_code = new System.Windows.Forms.Button();
            this.tKey = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lvSol);
            this.groupBox1.Controls.Add(this.lvQuotes);
            this.groupBox1.Location = new System.Drawing.Point(8, 48);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(576, 444);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // lvSol
            // 
            this.lvSol.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvSol.AutoArrange = false;
            this.lvSol.BackColor = System.Drawing.Color.GhostWhite;
            this.lvSol.CheckBoxes = true;
            this.lvSol.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader3,
            this.columnHeader4});
            this.lvSol.ForeColor = System.Drawing.Color.Blue;
            this.lvSol.FullRowSelect = true;
            this.lvSol.GridLines = true;
            this.lvSol.Location = new System.Drawing.Point(384, 16);
            this.lvSol.Name = "lvSol";
            this.lvSol.Size = new System.Drawing.Size(186, 353);
            this.lvSol.TabIndex = 116;
            this.lvSol.UseCompatibleStateImageBehavior = false;
            this.lvSol.View = System.Windows.Forms.View.Details;
            this.lvSol.ItemCheck += new System.Windows.Forms.ItemCheckEventHandler(this.lvSol_ItemCheck);
            this.lvSol.SelectedIndexChanged += new System.EventHandler(this.lvSol_SelectedIndexChanged);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "Revisions List";
            this.columnHeader1.Width = 153;
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "";
            this.columnHeader3.Width = 0;
            // 
            // columnHeader4
            // 
            this.columnHeader4.Text = "";
            this.columnHeader4.Width = 2;
            // 
            // lvQuotes
            // 
            this.lvQuotes.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvQuotes.AutoArrange = false;
            this.lvQuotes.BackColor = System.Drawing.Color.OldLace;
            this.lvQuotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Qn,
            this.Cpny,
            this.qid,
            this.cpnyID});
            this.lvQuotes.ForeColor = System.Drawing.Color.Blue;
            this.lvQuotes.FullRowSelect = true;
            this.lvQuotes.GridLines = true;
            this.lvQuotes.Location = new System.Drawing.Point(8, 16);
            this.lvQuotes.Name = "lvQuotes";
            this.lvQuotes.Size = new System.Drawing.Size(376, 422);
            this.lvQuotes.TabIndex = 115;
            this.lvQuotes.UseCompatibleStateImageBehavior = false;
            this.lvQuotes.View = System.Windows.Forms.View.Details;
            this.lvQuotes.SelectedIndexChanged += new System.EventHandler(this.lvQuotes_SelectedIndexChanged);
            // 
            // Qn
            // 
            this.Qn.Text = "Quotes #";
            this.Qn.Width = 94;
            // 
            // Cpny
            // 
            this.Cpny.Text = "Company ";
            this.Cpny.Width = 259;
            // 
            // qid
            // 
            this.qid.Text = "";
            this.qid.Width = 0;
            // 
            // cpnyID
            // 
            this.cpnyID.Text = "";
            this.cpnyID.Width = 0;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.label3.ForeColor = System.Drawing.Color.Red;
            this.label3.Location = new System.Drawing.Point(42, 506);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 18);
            this.label3.TabIndex = 25;
            this.label3.Text = "Quote #:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tQuoteID
            // 
            this.tQuoteID.BackColor = System.Drawing.SystemColors.Control;
            this.tQuoteID.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tQuoteID.ForeColor = System.Drawing.Color.Blue;
            this.tQuoteID.Location = new System.Drawing.Point(122, 502);
            this.tQuoteID.MaxLength = 8;
            this.tQuoteID.Name = "tQuoteID";
            this.tQuoteID.ReadOnly = true;
            this.tQuoteID.Size = new System.Drawing.Size(136, 26);
            this.tQuoteID.TabIndex = 26;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.label1.ForeColor = System.Drawing.Color.Red;
            this.label1.Location = new System.Drawing.Point(34, 530);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 22);
            this.label1.TabIndex = 27;
            this.label1.Text = "Company:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tcpnyName
            // 
            this.tcpnyName.BackColor = System.Drawing.SystemColors.Control;
            this.tcpnyName.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tcpnyName.ForeColor = System.Drawing.Color.Blue;
            this.tcpnyName.Location = new System.Drawing.Point(122, 528);
            this.tcpnyName.MaxLength = 8;
            this.tcpnyName.Name = "tcpnyName";
            this.tcpnyName.ReadOnly = true;
            this.tcpnyName.Size = new System.Drawing.Size(360, 26);
            this.tcpnyName.TabIndex = 28;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.label2.ForeColor = System.Drawing.Color.Red;
            this.label2.Location = new System.Drawing.Point(10, 555);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 20);
            this.label2.TabIndex = 29;
            this.label2.Text = "Revision #:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tSolName
            // 
            this.tSolName.BackColor = System.Drawing.SystemColors.Control;
            this.tSolName.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.tSolName.ForeColor = System.Drawing.Color.Blue;
            this.tSolName.Location = new System.Drawing.Point(122, 554);
            this.tSolName.MaxLength = 8;
            this.tSolName.Name = "tSolName";
            this.tSolName.ReadOnly = true;
            this.tSolName.Size = new System.Drawing.Size(114, 23);
            this.tSolName.TabIndex = 30;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold);
            this.btnCancel.Location = new System.Drawing.Point(496, 540);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(99, 30);
            this.btnCancel.TabIndex = 59;
            this.btnCancel.Text = "&Cancel";
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnImport
            // 
            this.btnImport.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnImport.Enabled = false;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnImport.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(496, 506);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(99, 30);
            this.btnImport.TabIndex = 58;
            this.btnImport.Text = "Import";
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // lIQID
            // 
            this.lIQID.BackColor = System.Drawing.Color.OliveDrab;
            this.lIQID.Location = new System.Drawing.Point(419, 500);
            this.lIQID.Name = "lIQID";
            this.lIQID.Size = new System.Drawing.Size(16, 16);
            this.lIQID.TabIndex = 60;
            this.lIQID.Text = "0";
            this.lIQID.Visible = false;
            // 
            // lcpnyID
            // 
            this.lcpnyID.BackColor = System.Drawing.Color.OliveDrab;
            this.lcpnyID.Location = new System.Drawing.Point(505, 504);
            this.lcpnyID.Name = "lcpnyID";
            this.lcpnyID.Size = new System.Drawing.Size(24, 16);
            this.lcpnyID.TabIndex = 61;
            this.lcpnyID.Text = "0";
            this.lcpnyID.Visible = false;
            // 
            // lSolid
            // 
            this.lSolid.BackColor = System.Drawing.Color.OliveDrab;
            this.lSolid.Location = new System.Drawing.Point(457, 502);
            this.lSolid.Name = "lSolid";
            this.lSolid.Size = new System.Drawing.Size(32, 16);
            this.lSolid.TabIndex = 62;
            this.lSolid.Text = "0";
            this.lSolid.Visible = false;
            // 
            // lsave
            // 
            this.lsave.BackColor = System.Drawing.Color.OliveDrab;
            this.lsave.Location = new System.Drawing.Point(553, 502);
            this.lsave.Name = "lsave";
            this.lsave.Size = new System.Drawing.Size(24, 16);
            this.lsave.TabIndex = 63;
            this.lsave.Text = "N";
            this.lsave.Visible = false;
            // 
            // btnSeek
            // 
            this.btnSeek.BackColor = System.Drawing.Color.Bisque;
            this.btnSeek.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSeek.ForeColor = System.Drawing.Color.Black;
            this.btnSeek.Location = new System.Drawing.Point(264, 13);
            this.btnSeek.Name = "btnSeek";
            this.btnSeek.Size = new System.Drawing.Size(143, 23);
            this.btnSeek.TabIndex = 392;
            this.btnSeek.Text = "find Quote ";
            this.btnSeek.UseVisualStyleBackColor = false;
            this.btnSeek.Click += new System.EventHandler(this.btnSeek_Click);
            // 
            // btn_find_code
            // 
            this.btn_find_code.BackColor = System.Drawing.Color.Bisque;
            this.btn_find_code.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_find_code.ForeColor = System.Drawing.Color.Black;
            this.btn_find_code.Location = new System.Drawing.Point(422, 13);
            this.btn_find_code.Name = "btn_find_code";
            this.btn_find_code.Size = new System.Drawing.Size(132, 23);
            this.btn_find_code.TabIndex = 393;
            this.btn_find_code.Text = "By SYSPRO code";
            this.btn_find_code.UseVisualStyleBackColor = false;
            this.btn_find_code.Visible = false;
            this.btn_find_code.Click += new System.EventHandler(this.btn_find_code_Click);
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.White;
            this.tKey.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tKey.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.ForeColor = System.Drawing.Color.Black;
            this.tKey.Location = new System.Drawing.Point(94, 12);
            this.tKey.MaxLength = 60;
            this.tKey.Multiline = true;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(164, 24);
            this.tKey.TabIndex = 391;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Courier New", 12F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Red;
            this.label4.Location = new System.Drawing.Point(12, 16);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(80, 18);
            this.label4.TabIndex = 393;
            this.label4.Text = "Quote #:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // QimportRxx
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(607, 609);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btn_find_code);
            this.Controls.Add(this.btnSeek);
            this.Controls.Add(this.tKey);
            this.Controls.Add(this.lsave);
            this.Controls.Add(this.lSolid);
            this.Controls.Add(this.lcpnyID);
            this.Controls.Add(this.lIQID);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tSolName);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tcpnyName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.tQuoteID);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "QimportRxx";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quote Import";
            this.Load += new System.EventHandler(this.importRxx_Load);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		#endregion

		private void importRxx_Load(object sender, System.EventArgs e)
		{
			if (MainMDI.currDB == "XTT") this.Text = "XXXXXXXXXXXXXXXXXXTT";
		}

		private void listView1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		public void fill_lvQuotes()
		{
			lvQuotes.Items.Clear();
			string stSql = "SELECT i_Quoteid,Quote_ID, PSM_Company.Cpny_Name1,PSM_Company.Cpny_ID FROM PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID " + 
				" ORDER BY PSM_Q_IGen.Quote_ID DESC";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
 
			while (Oreadr.Read())
			{
				ListViewItem lvI = lvQuotes.Items.Add(Oreadr["Quote_ID"].ToString());
				lvI.SubItems.Add(Oreadr["Cpny_Name1"].ToString());
				lvI.SubItems.Add(Oreadr["i_Quoteid"].ToString());
				lvI.SubItems.Add(Oreadr["Cpny_ID"].ToString());
			}
		}

        void selectItem(int ndx)
        {
            tQuoteID.Text = lvQuotes.Items[ndx].SubItems[0].Text;
            tcpnyName.Text = lvQuotes.Items[ndx].SubItems[1].Text;
            lIQID.Text = lvQuotes.Items[ndx].SubItems[2].Text;
            lcpnyID.Text = lvQuotes.Items[ndx].SubItems[3].Text;
            tSolName.Text = "";
            lSolid.Text = "0";
            fill_Sol();
        }

		private void lvQuotes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (lvQuotes.SelectedItems.Count == 1)
			{
                selectItem(lvQuotes.SelectedItems[0].Index);
			}
		}

		private void fill_Sol()
		{
			string stSql = "select Sol_LID,Sol_Name FROM PSM_Q_SOL where I_Quoteid=" + lIQID.Text;
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			lvSol.Items.Clear();
			while (Oreadr.Read())
			{
				ListViewItem lv = lvSol.Items.Add(Oreadr["Sol_Name"].ToString());
				lv.SubItems.Add(Oreadr["Sol_LID"].ToString());
			}
			OConn.Close();
		}

		private void lvSol_SelectedIndexChanged(object sender, System.EventArgs e)
		{

		}

		private void lvSol_ItemCheck(object sender, System.Windows.Forms.ItemCheckEventArgs e)
		{
			if (!lvSol.Items[e.Index].Checked)	
			{
				tSolName.Text = lvSol.Items[e.Index].Text;
				lSolid.Text = lvSol.Items[e.Index].SubItems[1].Text;
			}
			else { tSolName.Text = ""; lSolid.Text = "0"; }
			btnImport.Enabled = tSolName.Text != "";
		    //if (!lvQITEMS.Items[e.Index].Checked)
		    //{
		        //if (in_opera == 'C' && lvQITEMS.Items[e.Index].SubItems[9].Text != "")
		            //if (seek_LvOrder(lvQITEMS.Items[e.Index].SubItems[11].Text, 'c') == -1) add_LVR("      " + lvQITEMS.Items[e.Index].SubItems[2].Text, lCurSolNDX.Text, lCurSPCNDX.Text, lCurALSNDX.Text, lvQITEMS.Items[e.Index].SubItems[11].Text, e.Index.ToString(), lCurSPCn.Text + "/" + lCurALSn.Text, lvQITEMS.Items[e.Index].SubItems[7].Text);
		        //}
		        //else seek_LvOrder(lvQITEMS.Items[e.Index].SubItems[11].Text, 'r');
		    //}
		}

		private void btnImport_Click(object sender, System.EventArgs e)
		{
		    lsave.Text = "Y";
			this.Hide();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
		    lsave.Text = "N";
            this.Hide();
		}

        private void btnSeek_Click(object sender, EventArgs e)
        {
            tQuoteID.Clear();
            tcpnyName.Clear();
            tSolName.Clear();

            bool trv = false;
            for (int i = 0; i < lvQuotes.Items.Count; i++)
            {
                if (lvQuotes.Items[i].SubItems[0].Text == tKey.Text)
                {
                    selectItem(i);
                    trv = true;
                    i = lvQuotes.Items.Count;
                }
            }
            if (!trv) MessageBox.Show("Sorry, NOT FOUND.....");
        }

        private void btn_find_code_Click(object sender, EventArgs e)
        {
            //string CpnyNm = "", lid = "";
            //MainMDI.Find_2_Field("select Cpny_Name1,Cpny_ID from PSM_COMPANY where Syspro_Code='" + tKey.Text.ToUpper() + "'", ref CpnyNm, ref lid);

            //if (CpnyNm == MainMDI.VIDE)
                //MessageBox.Show("NOT FOUND..........!!!!");
            //else
            //{
                //cbCompanyy.Text = CpnyNm + " (" + tKey.Text.ToUpper() + ")";
            //}
        }
	}
}