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
	public class dlg_VDC_IDC_Disable: System.Windows.Forms.Form
	{

        public bool done = false;
		private string in_VDC="",in_IorV="",in_Phs="1",in_stSql="",in_PXX="P4500";
        Setng_003_Avail in_frm =null;
      
		long lcpnyLID =0;
		char Opera='F';
		int ndxfound=0;
		private Lib1 Tools = new Lib1();
        public bool lOK = false;
        private ToolStripButton del;
        private GroupBox grpIDC;
        private ListView lv_IDC;
        private ColumnHeader picidc;
        private ColumnHeader Item;
        private GroupBox groupBox3;
        private Label label2;
        private PictureBox picExit;
        private Label label1;
        private PictureBox picsav;
        private ImageList imageList1;
        private ListView lv_VDC;
        private ColumnHeader st;
        private ColumnHeader VDC;
        private ColumnHeader disLID;
        private ColumnHeader lid;
        private PictureBox picena;
        private PictureBox picdisa;
        private Label label4;
        private Label label3;
        private Label label5;
        private PictureBox picphs3;
        private PictureBox picPhs1;
        private IContainer components;

        public dlg_VDC_IDC_Disable(string x_phs,string x_IorV)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
   


            in_Phs = x_phs ;
            in_IorV = x_IorV;


		
    
	

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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlg_VDC_IDC_Disable));
            this.grpIDC = new System.Windows.Forms.GroupBox();
            this.lv_VDC = new System.Windows.Forms.ListView();
            this.st = new System.Windows.Forms.ColumnHeader();
            this.VDC = new System.Windows.Forms.ColumnHeader();
            this.disLID = new System.Windows.Forms.ColumnHeader();
            this.imageList1 = new System.Windows.Forms.ImageList(this.components);
            this.lv_IDC = new System.Windows.Forms.ListView();
            this.picidc = new System.Windows.Forms.ColumnHeader();
            this.Item = new System.Windows.Forms.ColumnHeader();
            this.lid = new System.Windows.Forms.ColumnHeader();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.picdisa = new System.Windows.Forms.PictureBox();
            this.picena = new System.Windows.Forms.PictureBox();
            this.picExit = new System.Windows.Forms.PictureBox();
            this.picsav = new System.Windows.Forms.PictureBox();
            this.picPhs1 = new System.Windows.Forms.PictureBox();
            this.picphs3 = new System.Windows.Forms.PictureBox();
            this.del = new System.Windows.Forms.ToolStripButton();
            this.grpIDC.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picdisa)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picena)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picsav)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhs1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picphs3)).BeginInit();
            this.SuspendLayout();
            // 
            // grpIDC
            // 
            this.grpIDC.Controls.Add(this.lv_VDC);
            this.grpIDC.Controls.Add(this.lv_IDC);
            this.grpIDC.Dock = System.Windows.Forms.DockStyle.Left;
            this.grpIDC.Location = new System.Drawing.Point(0, 0);
            this.grpIDC.Name = "grpIDC";
            this.grpIDC.Size = new System.Drawing.Size(222, 589);
            this.grpIDC.TabIndex = 345;
            this.grpIDC.TabStop = false;
            // 
            // lv_VDC
            // 
            this.lv_VDC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lv_VDC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.st,
            this.VDC,
            this.disLID});
            this.lv_VDC.Dock = System.Windows.Forms.DockStyle.Left;
            this.lv_VDC.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_VDC.FullRowSelect = true;
            this.lv_VDC.GridLines = true;
            this.lv_VDC.Location = new System.Drawing.Point(221, 16);
            this.lv_VDC.Name = "lv_VDC";
            this.lv_VDC.Size = new System.Drawing.Size(218, 570);
            this.lv_VDC.SmallImageList = this.imageList1;
            this.lv_VDC.TabIndex = 347;
            this.lv_VDC.UseCompatibleStateImageBehavior = false;
            this.lv_VDC.View = System.Windows.Forms.View.Details;
            this.lv_VDC.Visible = false;
            // 
            // st
            // 
            this.st.Text = "Status";
            this.st.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.st.Width = 64;
            // 
            // VDC
            // 
            this.VDC.Text = "VDC List";
            this.VDC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.VDC.Width = 133;
            // 
            // disLID
            // 
            this.disLID.Text = "";
            this.disLID.Width = 0;
            // 
            // imageList1
            // 
            this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
            this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList1.Images.SetKeyName(0, "bullet_ball_red.png");
            this.imageList1.Images.SetKeyName(1, "bullet_ball_glass_green.png");
            this.imageList1.Images.SetKeyName(2, "NetByte Design Studio - 0007.png");
            this.imageList1.Images.SetKeyName(3, "Safe Shield.png");
            // 
            // lv_IDC
            // 
            this.lv_IDC.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lv_IDC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.picidc,
            this.Item,
            this.lid});
            this.lv_IDC.Dock = System.Windows.Forms.DockStyle.Left;
            this.lv_IDC.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lv_IDC.FullRowSelect = true;
            this.lv_IDC.GridLines = true;
            this.lv_IDC.LargeImageList = this.imageList1;
            this.lv_IDC.Location = new System.Drawing.Point(3, 16);
            this.lv_IDC.Name = "lv_IDC";
            this.lv_IDC.Size = new System.Drawing.Size(218, 570);
            this.lv_IDC.SmallImageList = this.imageList1;
            this.lv_IDC.TabIndex = 344;
            this.lv_IDC.UseCompatibleStateImageBehavior = false;
            this.lv_IDC.View = System.Windows.Forms.View.Details;
            this.lv_IDC.Visible = false;
            // 
            // picidc
            // 
            this.picidc.Text = "Status";
            this.picidc.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.picidc.Width = 61;
            // 
            // Item
            // 
            this.Item.Text = "IDC List";
            this.Item.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Item.Width = 133;
            // 
            // lid
            // 
            this.lid.Text = "";
            this.lid.Width = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.picdisa);
            this.groupBox3.Controls.Add(this.picena);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.picExit);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.picsav);
            this.groupBox3.Controls.Add(this.picPhs1);
            this.groupBox3.Controls.Add(this.picphs3);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox3.Location = new System.Drawing.Point(222, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(116, 589);
            this.groupBox3.TabIndex = 350;
            this.groupBox3.TabStop = false;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(13, 32);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(49, 17);
            this.label5.TabIndex = 395;
            this.label5.Text = "Phase";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label4.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(6, 149);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 17);
            this.label4.TabIndex = 393;
            this.label4.Text = "Disable";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(13, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 17);
            this.label3.TabIndex = 392;
            this.label3.Text = "Enable";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(2, 525);
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
            this.label1.Location = new System.Drawing.Point(2, 447);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 388;
            this.label1.Text = "Save";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picdisa
            // 
            this.picdisa.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picdisa.Cursor = System.Windows.Forms.Cursors.Hand;
       //     this.picdisa.Image = global::PGESCOM.Properties.Resources.bullet_ball_glass_red;
            this.picdisa.Location = new System.Drawing.Point(71, 137);
            this.picdisa.Name = "picdisa";
            this.picdisa.Size = new System.Drawing.Size(39, 40);
            this.picdisa.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picdisa.TabIndex = 391;
            this.picdisa.TabStop = false;
            this.picdisa.Click += new System.EventHandler(this.picdisa_Click);
            // 
            // picena
            // 
            this.picena.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picena.Cursor = System.Windows.Forms.Cursors.Hand;
        //    this.picena.Image = global::PGESCOM.Properties.Resources.bullet_ball_glass_green;
            this.picena.Location = new System.Drawing.Point(71, 91);
            this.picena.Name = "picena";
            this.picena.Size = new System.Drawing.Size(39, 40);
            this.picena.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picena.TabIndex = 390;
            this.picena.TabStop = false;
            this.picena.Click += new System.EventHandler(this.picena_Click);
            // 
            // picExit
            // 
            this.picExit.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picExit.Image = global::PGESCOM.Properties.Resources.Log_Off;
            this.picExit.Location = new System.Drawing.Point(49, 497);
            this.picExit.Name = "picExit";
            this.picExit.Size = new System.Drawing.Size(59, 69);
            this.picExit.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picExit.TabIndex = 361;
            this.picExit.TabStop = false;
            this.picExit.Click += new System.EventHandler(this.picExit_Click_1);
            // 
            // picsav
            // 
            this.picsav.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picsav.Cursor = System.Windows.Forms.Cursors.Hand;
          //  this.picsav.Image = global::PGESCOM.Properties.Resources._1__7_;
            this.picsav.Location = new System.Drawing.Point(49, 422);
            this.picsav.Name = "picsav";
            this.picsav.Size = new System.Drawing.Size(59, 69);
            this.picsav.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picsav.TabIndex = 360;
            this.picsav.TabStop = false;
            this.picsav.Click += new System.EventHandler(this.picsav_Click_1);
            // 
            // picPhs1
            // 
            this.picPhs1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picPhs1.Cursor = System.Windows.Forms.Cursors.Hand;
         //   this.picPhs1.Image = global::PGESCOM.Properties.Resources.glass_numbers_1;
            this.picPhs1.Location = new System.Drawing.Point(69, 19);
            this.picPhs1.Name = "picPhs1";
            this.picPhs1.Size = new System.Drawing.Size(39, 40);
            this.picPhs1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPhs1.TabIndex = 396;
            this.picPhs1.TabStop = false;
            this.picPhs1.Click += new System.EventHandler(this.picPhs1_Click);
            // 
            // picphs3
            // 
            this.picphs3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picphs3.Cursor = System.Windows.Forms.Cursors.Hand;
       //     this.picphs3.Image = global::PGESCOM.Properties.Resources.glass_numbers_3;
            this.picphs3.Location = new System.Drawing.Point(69, 19);
            this.picphs3.Name = "picphs3";
            this.picphs3.Size = new System.Drawing.Size(39, 40);
            this.picphs3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picphs3.TabIndex = 394;
            this.picphs3.TabStop = false;
            this.picphs3.Visible = false;
            this.picphs3.Click += new System.EventHandler(this.picphs3_Click);
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
            // dlg_VDC_IDC_Disable
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(342, 589);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpIDC);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "dlg_VDC_IDC_Disable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Enable / Disable VDC ";
            this.Load += new System.EventHandler(this.dlg_VDC_IDC_Disable_Load);
            this.grpIDC.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picdisa)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picena)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picExit)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picsav)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPhs1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picphs3)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion


        private void fill_VDC()
        {

      //      string stSql = "SELECT  V_VDC_List.VDC, PSM_DISA_VDC_IDC.typ ,  PSM_DISA_VDC_IDC.phs, disa_LID FROM  V_VDC_List LEFT OUTER JOIN " +
      //                     "  PSM_DISA_VDC_IDC ON V_VDC_List.VDC = PSM_DISA_VDC_IDC.VDC_IDC_value  order by  cast (vdc as int) ";
     
            string stSql = "SELECT V_VDC_List.VDC, typ, PHS, disa_LID FROM V_VDC_List LEFT OUTER JOIN " +
             "  V_DISA_VDC" + in_Phs + " ON V_VDC_List.VDC = V_DISA_VDC" + in_Phs + ".VDC_IDC_value ORDER BY CAST(V_VDC_List.VDC AS int)";
            
            
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            lv_VDC.Items.Clear(); 

            while (Oreadr.Read())
            {
                if ((Oreadr["phs"].ToString() == in_Phs || Oreadr["phs"].ToString() =="") && (Oreadr["typ"].ToString() == "V" || Oreadr["typ"].ToString() ==""))
                {
                    ListViewItem lv = lv_VDC.Items.Add("");
                    lv.SubItems.Add(Oreadr["VDC"].ToString());
                    lv.SubItems.Add(Oreadr["disa_LID"].ToString());

                    lv.ImageIndex = (Oreadr["disa_LID"].ToString() == "") ? 1 : 0;
                }
 
            }
            OConn.Close();


        }


        private void fill_IDC()
        {

     //       string stSql = "SELECT  V_IDC_List.IDC, PSM_DISA_VDC_IDC.typ ,  PSM_DISA_VDC_IDC.phs, disa_LID FROM  V_IDC_List LEFT OUTER JOIN " +
    //                       "  PSM_DISA_VDC_IDC ON V_IDC_List.IDC = PSM_DISA_VDC_IDC.VDC_IDC_value  order by  cast (idc as int) ";

            string stSql = "SELECT V_IDC_List.IDC, typ, PHS, disa_LID FROM V_IDC_List LEFT OUTER JOIN " +
                         "  V_DISA_IDC" + in_Phs + " ON V_IDC_List.IDC = V_DISA_IDC" + in_Phs + ".VDC_IDC_value ORDER BY CAST(V_IDC_List.IDC AS int)";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            lv_IDC.Items.Clear();

            while (Oreadr.Read())
            {
                if ((Oreadr["phs"].ToString() == in_Phs || Oreadr["phs"].ToString() == "") && (Oreadr["typ"].ToString() == "I" || Oreadr["typ"].ToString() == ""))
                {


                    ListViewItem lv = lv_IDC.Items.Add("");
                    lv.SubItems.Add(Oreadr["IDC"].ToString());
                    lv.SubItems.Add(Oreadr["disa_LID"].ToString());
             
                    lv.ImageIndex = (Oreadr["disa_LID"].ToString() == "") ? 1 : 0;
                }

            }
            OConn.Close();


        }


        private void picExit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void picsav_Click(object sender, EventArgs e)
        {
            /*
            string stSql = "";
            for (int i = 0; i < LV_VDC.Items.Count; i++)
            {
                if (lv_VDC.Items[i].SubItems[0].Text == "" && LV_VDC.Items[i].SubItems[2].Text != "")
                {
                    stSql = "insert into link_COMPNT_AVAIL ([Compnt_ID],[Avail_ID],[Qty],[phs]) Values (" + in_CPTid +
               ", " + lv_VDC.Items[i].SubItems[3].Text + ", 1, '" + in_Phs + "')";
                    //      if (MainMDI.Confirm(stSql)) 
                    MainMDI.Exec_SQL_JFS(stSql, " create New LNK availability..");

                }
            }

            for (int i = 0; i < lv_IDC.Items.Count; i++)
            {
                if (lv_IDC.Items[i].SubItems[0].Text != "" && lv_IDC.Items[i].SubItems[3].Text == "")
                {
                    stSql = "delete link_COMPNT_AVAIL  where LCA_LID=" + lv_IDC.Items[i].SubItems[0].Text;
                    //    if (MainMDI.Confirm (stSql )) 
                    MainMDI.Exec_SQL_JFS(stSql, " delete lnk Availability...");

                }
                
            }

            fill_VDC();
             * */
            
        }

        private void dlg_VDC_IDC_Disable_Load(object sender, EventArgs e)
        {
            switch (in_IorV )
            {
                case "V":
                    fill_VDC();
                    lv_VDC.Visible=true;
                    break;
                case "I":
                    fill_IDC();
                    lv_IDC.Visible=true;
                    break;
            }

        }

        private void Enable_IDC_VDC(char IV)
        {
            switch (IV)
            {
                case 'V':
                    for (int i = 0; i < lv_VDC.SelectedItems.Count; i++)
                        if (lv_VDC.Items[lv_VDC.SelectedItems[i].Index].ImageIndex == 0) lv_VDC.Items[lv_VDC.SelectedItems[i].Index].ImageIndex = 1;
                     break;
                case 'I':
                     for (int i = 0; i < lv_IDC.SelectedItems.Count; i++)
                         if (lv_IDC.Items[lv_IDC.SelectedItems[i].Index].ImageIndex == 0) lv_IDC.Items[lv_IDC.SelectedItems[i].Index].ImageIndex = 1;
                     break;

            }
        }
        private void Save_IDC_VDC(char IV)
        {
            switch (IV)
            {
                case 'V':
                    for (int i = 0; i < lv_VDC.Items.Count; i++)
                    {
                        if (lv_VDC.Items[i].ImageIndex == 1)
                        {
                            if (lv_VDC.Items[i].SubItems[2].Text != "")
                                MainMDI.Exec_SQL_JFS("delete PSM_DISA_VDC_IDC where disa_LID=" + lv_VDC.Items[i].SubItems[2].Text, " Enable VDC");

                        }
                        else
                        {
                            if (lv_VDC.Items[i].SubItems[2].Text == "")
                                MainMDI.Exec_SQL_JFS("insert into PSM_DISA_VDC_IDC ([PHS],[typ],[VDC_IDC_value]) Values ('" + in_Phs + "' ,'V', '" + lv_VDC.Items[i].SubItems[1].Text + "')", " Disable VDC");
                        }

                    }
                    break;
                case 'I':
                    for (int i = 0; i < lv_IDC.Items.Count; i++)
                    {
                        if (lv_IDC.Items[i].ImageIndex == 1)
                        {
                            if (lv_IDC.Items[i].SubItems[2].Text != "")
                                MainMDI.Exec_SQL_JFS("delete PSM_DISA_VDC_IDC where disa_LID=" + lv_IDC.Items[i].SubItems[2].Text, " Enable IDC");

                        }
                        else
                        {
                            if (lv_IDC.Items[i].SubItems[2].Text == "")
                                MainMDI.Exec_SQL_JFS("insert into PSM_DISA_VDC_IDC ([PHS],[typ],[VDC_IDC_value]) Values ('" + in_Phs + "' ,'I', '" + lv_IDC.Items[i].SubItems[1].Text + "')", " Disable IDC");
                        }

                    }
                    break;

            }
        }
        private void Disable_IDC_VDC(char IV)
        {
            switch (IV)
            {
                case 'V':
                    for (int i = 0; i < lv_VDC.SelectedItems.Count; i++)
                        if (lv_VDC.Items[lv_VDC.SelectedItems[i].Index].ImageIndex == 1) lv_VDC.Items[lv_VDC.SelectedItems[i].Index].ImageIndex = 0;
                    break;
                case 'I':
                    for (int i = 0; i < lv_IDC.SelectedItems.Count; i++)
                        if (lv_IDC.Items[lv_IDC.SelectedItems[i].Index].ImageIndex == 1) lv_IDC.Items[lv_IDC.SelectedItems[i].Index].ImageIndex = 0;
                    break;

            }
        }
        private void picena_Click(object sender, EventArgs e)
        {
   
            if (lv_VDC.Visible)  Enable_IDC_VDC('V');

            if (lv_IDC.Visible)  Enable_IDC_VDC('I');

  
 
        }

        private void picdisa_Click(object sender, EventArgs e)
        {
            if (lv_VDC.Visible) Disable_IDC_VDC('V');
            if (lv_IDC.Visible) Disable_IDC_VDC('I');
        }

        private void picsav_Click_1(object sender, EventArgs e)
        {
            if (lv_VDC.Visible)
            {
                Save_IDC_VDC('V');
                fill_VDC();
            }
            if (lv_IDC.Visible)
            {
                Save_IDC_VDC('I');
                fill_IDC ();
            }

        }

        private void picExit_Click_1(object sender, EventArgs e)
        {
            this.Hide(); 
        }

        private void picPhs1_Click(object sender, EventArgs e)
        {
            in_Phs = "3"; picPhs1.Visible = false; picphs3.Visible = true; 
            if (in_IorV == "V") fill_VDC();
            if (in_IorV == "I") fill_IDC();
            
        }

        private void picphs3_Click(object sender, EventArgs e)
        {
            in_Phs = "1"; picphs3.Visible = false; picPhs1.Visible = true; 
            if (in_IorV == "V") fill_VDC();
            if (in_IorV == "I") fill_IDC();
        }








    }
}
