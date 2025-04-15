using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data ;
using System.Data.OleDb ;
using System.Data.SqlClient  ;
using EAHLibs;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for dlgCreditCrds.
	/// </summary>
	public class dlg_Admin: System.Windows.Forms.Form
	{

        public bool done = false;
		private string in_IRRevid="";
        string[] in_arr_CFTR = new string[20];
		long lcpnyLID =0;
		char Opera='F';
		int ndxfound=0;
		private Lib1 Tools = new Lib1();
        public bool lOK = false;
        private ToolStripButton del;
        private ToolStrip TSmain;
        private ToolStripButton newcard;
        private ToolStripButton Save;
        private ToolStripButton exiit;
        private GroupBox groupBox1;
        private ColumnHeader r_LID;
        private ColumnHeader Cur_Nm;
        private ColumnHeader dat_chng;
        private ColumnHeader columnHeader4;
        private ColumnHeader columnHeader5;
        public ListView lvXchng_rat;
        private Label label8;
        private TextBox tpwd;
        private Label lSrvr_stat;
        private Label lSrvr_statt;
        private Button btnUPPGESCOM;
        private Button btnSTOPALL;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public dlg_Admin()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

		
            chkServer();
	

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlg_Admin));
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tpwd = new System.Windows.Forms.TextBox();
            this.lSrvr_stat = new System.Windows.Forms.Label();
            this.lSrvr_statt = new System.Windows.Forms.Label();
            this.r_LID = new System.Windows.Forms.ColumnHeader();
            this.Cur_Nm = new System.Windows.Forms.ColumnHeader();
            this.dat_chng = new System.Windows.Forms.ColumnHeader();
            this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
            this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
            this.lvXchng_rat = new System.Windows.Forms.ListView();
            this.btnUPPGESCOM = new System.Windows.Forms.Button();
            this.btnSTOPALL = new System.Windows.Forms.Button();
            this.newcard = new System.Windows.Forms.ToolStripButton();
            this.Save = new System.Windows.Forms.ToolStripButton();
            this.exiit = new System.Windows.Forms.ToolStripButton();
            this.del = new System.Windows.Forms.ToolStripButton();
            this.TSmain.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.TSmain.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.tpwd);
            this.groupBox1.Controls.Add(this.lSrvr_stat);
            this.groupBox1.Controls.Add(this.lSrvr_statt);
            this.groupBox1.Controls.Add(this.btnUPPGESCOM);
            this.groupBox1.Controls.Add(this.btnSTOPALL);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(551, 90);
            this.groupBox1.TabIndex = 332;
            this.groupBox1.TabStop = false;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(445, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(63, 21);
            this.label8.TabIndex = 309;
            this.label8.Text = "password";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tpwd
            // 
            this.tpwd.BackColor = System.Drawing.SystemColors.ControlLight;
            this.tpwd.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpwd.ForeColor = System.Drawing.Color.Blue;
            this.tpwd.Location = new System.Drawing.Point(417, 37);
            this.tpwd.MaxLength = 99;
            this.tpwd.Name = "tpwd";
            this.tpwd.PasswordChar = '*';
            this.tpwd.Size = new System.Drawing.Size(120, 22);
            this.tpwd.TabIndex = 308;
            this.tpwd.TextChanged += new System.EventHandler(this.tpwd_TextChanged);
            // 
            // lSrvr_stat
            // 
            this.lSrvr_stat.BackColor = System.Drawing.Color.PaleGoldenrod;
            this.lSrvr_stat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lSrvr_stat.Font = new System.Drawing.Font("Book Antiqua", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSrvr_stat.ForeColor = System.Drawing.Color.Green;
            this.lSrvr_stat.Location = new System.Drawing.Point(147, 31);
            this.lSrvr_stat.Name = "lSrvr_stat";
            this.lSrvr_stat.Size = new System.Drawing.Size(160, 29);
            this.lSrvr_stat.TabIndex = 307;
            this.lSrvr_stat.Text = "Running";
            this.lSrvr_stat.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lSrvr_statt
            // 
            this.lSrvr_statt.BackColor = System.Drawing.SystemColors.Control;
            this.lSrvr_statt.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSrvr_statt.ForeColor = System.Drawing.Color.Black;
            this.lSrvr_statt.Location = new System.Drawing.Point(6, 27);
            this.lSrvr_statt.Name = "lSrvr_statt";
            this.lSrvr_statt.Size = new System.Drawing.Size(139, 39);
            this.lSrvr_statt.TabIndex = 306;
            this.lSrvr_statt.Text = "PGESCOM is:";
            this.lSrvr_statt.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            this.lvXchng_rat.Location = new System.Drawing.Point(0, 90);
            this.lvXchng_rat.Name = "lvXchng_rat";
            this.lvXchng_rat.Size = new System.Drawing.Size(551, 70);
            this.lvXchng_rat.TabIndex = 333;
            this.lvXchng_rat.UseCompatibleStateImageBehavior = false;
            this.lvXchng_rat.View = System.Windows.Forms.View.Details;
            this.lvXchng_rat.Visible = false;
            // 
            // btnUPPGESCOM
            // 
            this.btnUPPGESCOM.BackColor = System.Drawing.SystemColors.Control;
            this.btnUPPGESCOM.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnUPPGESCOM.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUPPGESCOM.Image = ((System.Drawing.Image)(resources.GetObject("btnUPPGESCOM.Image")));
            this.btnUPPGESCOM.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnUPPGESCOM.Location = new System.Drawing.Point(307, 24);
            this.btnUPPGESCOM.Name = "btnUPPGESCOM";
            this.btnUPPGESCOM.Size = new System.Drawing.Size(104, 42);
            this.btnUPPGESCOM.TabIndex = 305;
            this.btnUPPGESCOM.Text = "START";
            this.btnUPPGESCOM.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnUPPGESCOM.UseVisualStyleBackColor = false;
            this.btnUPPGESCOM.Visible = false;
            this.btnUPPGESCOM.Click += new System.EventHandler(this.btnUPPGESCOM_Click);
            // 
            // btnSTOPALL
            // 
            this.btnSTOPALL.BackColor = System.Drawing.SystemColors.Control;
            this.btnSTOPALL.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnSTOPALL.Font = new System.Drawing.Font("Palatino Linotype", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSTOPALL.ForeColor = System.Drawing.Color.Black;
            this.btnSTOPALL.Image = ((System.Drawing.Image)(resources.GetObject("btnSTOPALL.Image")));
            this.btnSTOPALL.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.btnSTOPALL.Location = new System.Drawing.Point(307, 24);
            this.btnSTOPALL.Name = "btnSTOPALL";
            this.btnSTOPALL.Size = new System.Drawing.Size(104, 42);
            this.btnSTOPALL.TabIndex = 310;
            this.btnSTOPALL.Text = "STOP";
            this.btnSTOPALL.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSTOPALL.UseVisualStyleBackColor = false;
            this.btnSTOPALL.Visible = false;
            this.btnSTOPALL.Click += new System.EventHandler(this.btnSTOPALL_Click);
            // 
            // newcard
            // 
            this.newcard.Image = global::PGESCOM.Properties.Resources.calculator_add;
            this.newcard.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newcard.Name = "newcard";
            this.newcard.Size = new System.Drawing.Size(58, 60);
            this.newcard.Text = "New Card";
            this.newcard.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.newcard.Visible = false;
            // 
            // Save
            // 
            this.Save.Image = global::PGESCOM.Properties.Resources.Floppy;
            this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(36, 60);
            this.Save.Text = "Save";
            this.Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Save.Visible = false;
            // 
            // exiit
            // 
            this.exiit.Image = ((System.Drawing.Image)(resources.GetObject("exiit.Image")));
            this.exiit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.exiit.Name = "exiit";
            this.exiit.Size = new System.Drawing.Size(59, 60);
            this.exiit.Text = "     Exit     ";
            this.exiit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.exiit.ToolTipText = "Exit";
            // 
            // del
            // 
            this.del.Image = global::PGESCOM.Properties.Resources.remove1;
            this.del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(87, 60);
            this.del.Text = "Delete Payment";
            this.del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.del.Visible = false;
            // 
            // dlg_Admin
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(551, 160);
            this.Controls.Add(this.lvXchng_rat);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.TSmain);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "dlg_Admin";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PGESCOM Status";
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

	

	

		private void fill_lvCFTR()
		{
            string stSql = "SELECT  CFLID, ConfigNm FROM PSM_R_CFinfo WHERE c_SN ='" ;
            Color _clr = Color.OldLace;
            for (int t = 0; t < 2; t++)
            {
                if (t == 1)
                {
                    stSql = "SELECT tr_LID, tr_TRName FROM PSM_R_TRInfo WHERE tr_TRName ='TR_" ;
                    _clr = Color.Beige ;
                }
        
                for (int i = 0; i < 20; i++)
                {
                    if (in_arr_CFTR[i] != "")
                    {
                        string _Nm = "", _cfLID = "";
                        MainMDI.Find_2_Field(stSql + in_arr_CFTR[i] + "'", ref _cfLID, ref  _Nm);
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

  
        private void tpwd_TextChanged(object sender, System.EventArgs e)
        {

            bool sta = (tpwd.Text == "2~~");
            btnSTOPALL.Visible = (lSrvr_stat.Text == "Running" && sta );
            btnUPPGESCOM.Visible = (lSrvr_stat.Text == "Stopped" && sta);

        }

         private void btnUPPGESCOM_Click(object sender, System.EventArgs e)
        {
            if (MainMDI.Confirm("You want to START PGESCOM ? "))
            {
                MainMDI.Exec_SQL_JFS ("UPDATE PSM_SYSETUP  SET [s_stat]='1' where s_machNm='" + "PGESCOM" + "'"," setting: stop/start PGESCOM....");
                MainMDI.Exec_SQL_JFS("delete fROM PSM_Whodo where UserNm <>'" + MainMDI.User + "'", " setting: reset Whodo....");
            }
       //     fill_stations();
            chkServer();
            ref_btns((tpwd.Text == "2~~"));

        }

         private void ref_btns(bool _sta)
         {
           if (_sta)
           {
                 btnSTOPALL.Visible = (lSrvr_stat.Text == "Running");
                 btnUPPGESCOM.Visible = (lSrvr_stat.Text == "Stopped");
            }
         }

         private void btnSTOPALL_Click(object sender, System.EventArgs e)
         {

             if (MainMDI.Confirm("You want to STOP PGESCOM ? ")) MainMDI.Exec_SQL_JFS ("UPDATE PSM_SYSETUP  SET [s_stat]='8' where s_machNm='" + "PGESCOM" + "'"," setting: stopping PGESCOM....");
            // fill_stations();
             chkServer();
             ref_btns((tpwd.Text == "2~~"));

         }
         private void chkServer()
         {
             string SrvrST = "", r_bld = "";
             MainMDI.Find_2_Field("select s_stat , BLD from PSM_SYSETUP where  s_machNm='PGESCOM' ", ref SrvrST, ref r_bld);
           //  t_bld.Text = r_bld;
             //	btnUPPGESCOM.Enabled  =(SrvrST =="8" || SrvrST =="9" )   ;  
             //	btnSTOPALL.Enabled  =!btnUPPGESCOM.Enabled;
             if (SrvrST == "8" )
             {
                 //	btnUPPGESCOM.BringToFront(); 
                 lSrvr_stat.Text = "Stopped";
                 lSrvr_stat.ForeColor = Color.Red;

             }
             else
             {
                 //	btnSTOPALL.BringToFront(); 
                 lSrvr_stat.Text = "Running";
                 lSrvr_stat.ForeColor = Color.Green;
             }
           
         }
	
		
	}
}
