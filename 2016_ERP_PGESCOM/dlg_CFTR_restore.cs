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
	public class dlg_CFTR_restore: System.Windows.Forms.Form
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
        private GroupBox groupBox1;
        public ListView lvCFTR;
        private ColumnHeader Restore;
        private ColumnHeader itm;
        private ColumnHeader lid;
        private CheckBox checkBox1;
        private Button btnRstr;
        private Button btnCan;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public dlg_CFTR_restore(string[] x_arr,string x_newIRREVid)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            in_arr_CFTR = x_arr;
            in_IRRevid = x_newIRREVid;
			fill_lvCFTRSCD  ();    
            
	

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlg_CFTR_restore));
            this.del = new System.Windows.Forms.ToolStripButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.btnRstr = new System.Windows.Forms.Button();
            this.btnCan = new System.Windows.Forms.Button();
            this.lvCFTR = new System.Windows.Forms.ListView();
            this.Restore = new System.Windows.Forms.ColumnHeader();
            this.itm = new System.Windows.Forms.ColumnHeader();
            this.lid = new System.Windows.Forms.ColumnHeader();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // del
            // 
       //     this.del.Image = global::PGESCOM.Properties.Resources.remove1;
            this.del.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del.Name = "del";
            this.del.Size = new System.Drawing.Size(87, 60);
            this.del.Text = "Delete Payment";
            this.del.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.del.Visible = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.checkBox1);
            this.groupBox1.Controls.Add(this.btnRstr);
            this.groupBox1.Controls.Add(this.btnCan);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(352, 41);
            this.groupBox1.TabIndex = 329;
            this.groupBox1.TabStop = false;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(6, 15);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(65, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "All Items";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // btnRstr
            // 
            this.btnRstr.Location = new System.Drawing.Point(190, 12);
            this.btnRstr.Name = "btnRstr";
            this.btnRstr.Size = new System.Drawing.Size(75, 23);
            this.btnRstr.TabIndex = 1;
            this.btnRstr.Text = "Restore";
            this.btnRstr.UseVisualStyleBackColor = true;
            this.btnRstr.Click += new System.EventHandler(this.btnRstr_Click);
            // 
            // btnCan
            // 
            this.btnCan.Location = new System.Drawing.Point(271, 12);
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(75, 23);
            this.btnCan.TabIndex = 0;
            this.btnCan.Text = "Exit";
            this.btnCan.UseVisualStyleBackColor = true;
            this.btnCan.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // lvCFTR
            // 
            this.lvCFTR.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvCFTR.AutoArrange = false;
            this.lvCFTR.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvCFTR.CheckBoxes = true;
            this.lvCFTR.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Restore,
            this.itm,
            this.lid});
            this.lvCFTR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCFTR.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCFTR.ForeColor = System.Drawing.Color.White;
            this.lvCFTR.FullRowSelect = true;
            this.lvCFTR.GridLines = true;
            this.lvCFTR.Location = new System.Drawing.Point(0, 41);
            this.lvCFTR.Name = "lvCFTR";
            this.lvCFTR.Size = new System.Drawing.Size(352, 376);
            this.lvCFTR.TabIndex = 330;
            this.lvCFTR.UseCompatibleStateImageBehavior = false;
            this.lvCFTR.View = System.Windows.Forms.View.Details;
            // 
            // Restore
            // 
            this.Restore.Text = "Selection";
            this.Restore.Width = 71;
            // 
            // itm
            // 
            this.itm.Text = "Config.  /  Test Report / Schedule";
            this.itm.Width = 255;
            // 
            // lid
            // 
            this.lid.Text = "";
            this.lid.Width = 0;
            // 
            // dlg_CFTR_restore
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(352, 417);
            this.Controls.Add(this.lvCFTR);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlg_CFTR_restore";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restore Config  / Test Report";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion




        private void fill_lvCFTRSCD()
        {
            string stSql = "",stWhr="";
            

            for (int t = 0; t < 3; t++)
            {
                Color _clr = Color.Red ;
                
                switch (t)
                {

                    case 0:
                        stSql = "SELECT  CFLID, ConfigNm FROM PSM_R_CFinfo WHERE c_SN ='";
                        stWhr = "' and  c_RRevLID <>" + in_IRRevid;
                        _clr = Color.Salmon ;// .OldLace;
                        break;
                    case 1:
                        stSql= " SELECT  PSM_R_SCD_INFO.sc_LID, PSM_R_SCD_INFO.sc_Name FROM PSM_R_SCD_INFO INNER JOIN PSM_R_CFinfo ON PSM_R_SCD_INFO.sc_CF_LID = PSM_R_CFinfo.CFLID " +
                               " WHERE PSM_R_CFinfo.c_SN = '";
                        stWhr = "' and  sc_IREVID <>" + in_IRRevid;
                        _clr = Color.Green ;
                        break;
                    case 2:
                         stSql = "SELECT tr_LID, tr_TRName FROM PSM_R_TRInfo WHERE tr_TRName ='TR_";
                         stWhr = "' and  tr_iRRevID <>" + in_IRRevid;
                        _clr = Color.DarkBlue  ;// .Beige;
                        break;

                }


                

                for (int i = 0; i < 20; i++)
                {
                    if (in_arr_CFTR[i] != "")
                    {
                        string _Nm = "", _cfLID = "";
                        MainMDI.Find_2_Field(stSql + in_arr_CFTR[i] + stWhr , ref _cfLID, ref  _Nm);
                        if (_cfLID != MainMDI.VIDE)
                        {
                            ListViewItem lv = lvCFTR.Items.Add("");
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


		private void fill_lvCFTR_CFTR()
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
                            ListViewItem lv = lvCFTR.Items.Add("");
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

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            for (int i = 0; i < lvCFTR.Items.Count; i++)
                lvCFTR.Items[i].Checked = checkBox1.Checked;   
        }

        private void btnRstr_Click(object sender, EventArgs e)
        {
           string stJFS="";
            for (int i = 0; i < lvCFTR.Items.Count; i++)
            {
                if (lvCFTR.Items[i].Checked)
                {
                    string stSql = "";
                    char CC=lvCFTR.Items[i].BackColor.Name[0] ;
                    switch (CC )
                    {
                        case 'S':    //Color.OldLace:  //config
                            stSql = "UPDATE PSM_R_CFinfo SET c_RRevLID =" + in_IRRevid + " where CFLID=" + lvCFTR.Items[i].SubItems[2].Text;
                            stJFS =" restore: config.. ";
                            break;
                        case 'D':   //Color.Beige:  //Test Report
                            stSql = "UPDATE PSM_R_TRInfo SET tr_iRRevID =" + in_IRRevid + " where tr_LID=" + lvCFTR.Items[i].SubItems[2].Text;
                            stJFS =" restore: TST report.. ";
                            break;
                        case 'G':   //Color.Green:  //Schedule
                            stSql = "UPDATE PSM_R_SCD_INFO SET sc_IREVID =" + in_IRRevid + " where sc_LID=" + lvCFTR.Items[i].SubItems[2].Text;
                            stJFS =" restore: Schedule.. ";
                            break;
                    }

                    if (stSql != "")
                    {
                        MainMDI.Exec_SQL_JFS(stSql,stJFS  );
                        done = true;
                    }
                    else MessageBox.Show("Can not exec Sql since stsql is empty....."); 
                
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
