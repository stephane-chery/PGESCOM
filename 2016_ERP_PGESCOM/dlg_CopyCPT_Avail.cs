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
	public class dlg_CopyCPT_Avail: System.Windows.Forms.Form
	{

        public bool done = false;
		private string in_CPTid="",in_VDC="",in_CPTnm="",in_Phs="1",in_stSql="",in_PXX="P4500";
        Setng_003_Avail in_frm =null;
      
		long lcpnyLID =0;
		char Opera='F';
		int ndxfound=0;
		private Lib1 Tools = new Lib1();
        public bool lOK = false;
        private ToolStripButton del;
        private PictureBox picExit;
        private PictureBox picsav;
        private GroupBox groupBox3;
        private GroupBox grpVDC;
        private ListView LV_IN;
        private ColumnHeader fdesc;
        private ColumnHeader CPTlid;
        private Label label1;
        private Label label2;
        public ComboBox cbCpts;
        private Label lVDC;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public dlg_CopyCPT_Avail(string x_Phs) //,string x_stSql)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
         
            in_Phs = x_Phs;// in_frm.toolStripComboBox1.Text[0].ToString();



		
    
	

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlg_CopyCPT_Avail));
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.cbCpts = new System.Windows.Forms.ComboBox();
            this.lVDC = new System.Windows.Forms.Label();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.picsav = new System.Windows.Forms.PictureBox();
            this.grpVDC = new System.Windows.Forms.GroupBox();
            this.LV_IN = new System.Windows.Forms.ListView();
            this.fdesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.CPTlid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.del = new System.Windows.Forms.ToolStripButton();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picsav)).BeginInit();
            this.grpVDC.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(151, 300);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 389;
            this.label2.Text = "Exit";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Black;
            this.label1.Location = new System.Drawing.Point(35, 300);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 17);
            this.label1.TabIndex = 388;
            this.label1.Text = "Copy";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.cbCpts);
            this.groupBox3.Controls.Add(this.lVDC);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.picExit);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.picsav);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(0, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(244, 672);
            this.groupBox3.TabIndex = 347;
            this.groupBox3.TabStop = false;
            // 
            // cbCpts
            // 
            this.cbCpts.BackColor = System.Drawing.Color.AliceBlue;
            this.cbCpts.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbCpts.ForeColor = System.Drawing.SystemColors.ControlText;
            this.cbCpts.Location = new System.Drawing.Point(7, 241);
            this.cbCpts.Name = "cbCpts";
            this.cbCpts.Size = new System.Drawing.Size(232, 21);
            this.cbCpts.TabIndex = 391;
            this.cbCpts.SelectedIndexChanged += new System.EventHandler(this.cbCpts_SelectedIndexChanged);
            // 
            // lVDC
            // 
            this.lVDC.BackColor = System.Drawing.SystemColors.Control;
            this.lVDC.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lVDC.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lVDC.ForeColor = System.Drawing.Color.Red;
            this.lVDC.Location = new System.Drawing.Point(12, 221);
            this.lVDC.Name = "lVDC";
            this.lVDC.Size = new System.Drawing.Size(182, 17);
            this.lVDC.TabIndex = 390;
            this.lVDC.Text = "Component Source:";
            this.lVDC.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // picExit
            // 
            this.picExit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.Image = ((System.Drawing.Image)(resources.GetObject("picExit.Image")));
            this.picExit.Location = new System.Drawing.Point(145, 320);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(49, 69);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 361;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click);
            // 
            // picsav
            // 
            this.picsav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picsav.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picsav.Image = ((System.Drawing.Image)(resources.GetObject("picsav.Image")));
            this.picsav.Location = new System.Drawing.Point(35, 320);
            this.picsav.Name = "picsav";
            this.picsav.Size = new System.Drawing.Size(59, 69);
            this.picsav.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picsav.TabIndex = 360;
            this.picsav.TabStop = false;
            this.picsav.Click += new System.EventHandler(this.picsav_Click);
            // 
            // grpVDC
            // 
            this.grpVDC.Controls.Add(this.LV_IN);
            this.grpVDC.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpVDC.Location = new System.Drawing.Point(244, 0);
            this.grpVDC.Name = "grpVDC";
            this.grpVDC.Size = new System.Drawing.Size(298, 672);
            this.grpVDC.TabIndex = 349;
            this.grpVDC.TabStop = false;
            // 
            // LV_IN
            // 
            this.LV_IN.BackColor = System.Drawing.Color.LightGreen;
            this.LV_IN.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.fdesc,
            this.CPTlid});
            this.LV_IN.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LV_IN.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.LV_IN.FullRowSelect = true;
            this.LV_IN.GridLines = true;
            this.LV_IN.Location = new System.Drawing.Point(3, 16);
            this.LV_IN.Name = "LV_IN";
            this.LV_IN.Size = new System.Drawing.Size(292, 653);
            this.LV_IN.TabIndex = 344;
            this.LV_IN.UseCompatibleStateImageBehavior = false;
            this.LV_IN.View = System.Windows.Forms.View.Details;
            // 
            // fdesc
            // 
            this.fdesc.Text = "Component destination";
            this.fdesc.Width = 263;
            // 
            // CPTlid
            // 
            this.CPTlid.Text = "";
            this.CPTlid.Width = 0;
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
            // dlg_CopyCPT_Avail
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(547, 672);
            this.Controls.Add(this.grpVDC);
            this.Controls.Add(this.groupBox3);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "dlg_CopyCPT_Avail";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enable / Disable Availabilities";
            this.Load += new System.EventHandler(this.dlg_Avail_Load);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picsav)).EndInit();
            this.grpVDC.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

        private void fill_cbCpts()
        {
            cbCpts.Items.Clear();

            string stSql = "select distinct Component_ID, COMPONENT_REF, CatName1,CatName2,CatName3  from COMPNT_LIST inner join link_COMPNT_AVAIL on Compnt_ID=COMPNT_LIST.Component_ID      order by COMPONENT_REF ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                MainMDI.add_CB_itm(cbCpts, Oreadr["COMPONENT_REF"].ToString(), Oreadr["Component_ID"].ToString());
                add_LVIN(Oreadr["COMPONENT_REF"].ToString(), Oreadr["Component_ID"].ToString());

            }
            cbCpts.SelectedIndex = 0;
            OConn.Close();
        }
        private void add_LVIN(string _desc, string _cptLID)
        {
            ListViewItem lv = LV_IN.Items.Add(_desc);
            lv.SubItems.Add(_cptLID );


        }

        private void dlg_Avail_Load(object sender, EventArgs e)
        {
            fill_cbCpts();

        

            
        }


    
        private void exiit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

   
        private void picExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void picsav_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < LV_IN.SelectedItems.Count; i++)
            {
              if (in_CPTid!= LV_IN.Items[LV_IN.SelectedItems[i].Index].SubItems[1].Text) 
                  copyAV_OneCPT(in_CPTid, LV_IN.Items[LV_IN.SelectedItems[i].Index].SubItems[1].Text);
               
            }
        }

        private void cbCpts_SelectedIndexChanged(object sender, EventArgs e)
        {
                        System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
            itm = (System.Web.UI.WebControls.ListItem)cbCpts.Items[cbCpts.SelectedIndex];
            in_CPTid = itm.Value;
          
        }

        private void copyAV_OneCPT(string srcLID, string destiLID)
        {
            if (srcLID !="" && destiLID !="")
            {

                string stSql = "delete link_COMPNT_AVAIL where phs='" + in_Phs + "' and Compnt_ID=" + destiLID;
                MainMDI.Exec_SQL_JFS(stSql, " delete in LNK cpt Availability...."); 
                stSql = "insert into link_COMPNT_AVAIL select " + destiLID + " as Compnt_ID , Avail_ID, Qty, phs from link_COMPNT_AVAIL where phs='" + in_Phs + "' and Compnt_ID=" + srcLID;
                MainMDI.Exec_SQL_JFS(stSql, " insert into LNK NEW cpt Availability Copied from other Cpts...."); 




            }
        }






    }
}
