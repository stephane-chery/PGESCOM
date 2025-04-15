using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb ;  
using System.Data.SqlClient ;
using Excel = Microsoft.Office.Interop.Excel;
using System.IO;


namespace PGESCOM
{
	/// <summary>
	/// Summary description for OR_ToSched.
	/// </summary>
	public class OR_Sched_projects : System.Windows.Forms.Form
    {
       //local var
        string LcurConflid="",in_IRRevID = "", in_RID = "",in_CSTMR="",  SN = "", cur_CFTVA = "", DLVRD = "", lcurConfNm = "", lCFLID="";
        int LcurConfndx = -1, OLDTVConf_Selndx = -1, tsk_cur_ndx = -1, tsk_old_ndx = -1;
        string[,] arr_Tasks = new string[MainMDI.MAX_SC_TASKS , 5];
        string[,] arr_Tskscopy = new string[20, 3];
        private int oldSC = 0;
      
        private ListViewColumnSorter lvSorter = null;
        private char srtType = 'A';
        private int ndxCLRD = -1;
        private int seelCol = 0;
        private string seekColNm;
        //local var

       // columnheaders for lvallproj
        private ColumnHeader ch0, ch1, ch2, ch3, ch4, ch5, ch6, ch7, ch8, ch9, ch10;
        private ColumnHeader ch11, ch12, ch13, ch14, ch15, ch16, ch17, ch18, ch19, ch20;

       //

        private ImageList imageList16;
        private GroupBox grpACF;
        public ListView lvAllProjects;
        private ToolStrip toolStrip1;
        private ToolStripButton XLxport;
        private ToolStripSeparator hhh;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripLabel PBWait;
       // private ColumnHeader Cntr;
        private IContainer components;
        private int in_affcod;

        public OR_Sched_projects(int x_affcod)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
            in_affcod = x_affcod;
            init_CHnn();
            lvSorter = new ListViewColumnSorter();
            this.lvAllProjects.ListViewItemSorter = lvSorter;
            lvAllProjects.AutoArrange = true;
            lvSorter.SortColumn = 0;
            lvSorter.Order = System.Windows.Forms.SortOrder.Descending;
       //     ColName(0);
       //     seelCol = 0;
            
         



      //      in_IRRevID = x_IRRevID;
      //      in_RID = x_RID ;
      //      in_CSTMR = x_CSTMR;
       //     fill_TVConfig();
      //     fill_TVConfigBIG(); 
         //   load_ALLCFs();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OR_Sched_projects));
            this.imageList16 = new System.Windows.Forms.ImageList(this.components);
            this.grpACF = new System.Windows.Forms.GroupBox();
            this.lvAllProjects = new System.Windows.Forms.ListView();
            this.ch0 = new System.Windows.Forms.ColumnHeader();
            this.ch1 = new System.Windows.Forms.ColumnHeader();
            this.ch2 = new System.Windows.Forms.ColumnHeader();
            this.ch3 = new System.Windows.Forms.ColumnHeader();
            this.ch4 = new System.Windows.Forms.ColumnHeader();
            this.ch5 = new System.Windows.Forms.ColumnHeader();
            this.ch6 = new System.Windows.Forms.ColumnHeader();
            this.ch7 = new System.Windows.Forms.ColumnHeader();
            this.ch8 = new System.Windows.Forms.ColumnHeader();
            this.ch9 = new System.Windows.Forms.ColumnHeader();
            this.ch10 = new System.Windows.Forms.ColumnHeader();
            this.ch11 = new System.Windows.Forms.ColumnHeader();
            this.ch12 = new System.Windows.Forms.ColumnHeader();
            this.ch13 = new System.Windows.Forms.ColumnHeader();
            this.ch14 = new System.Windows.Forms.ColumnHeader();
            this.ch15 = new System.Windows.Forms.ColumnHeader();
            this.ch16 = new System.Windows.Forms.ColumnHeader();
            this.ch17 = new System.Windows.Forms.ColumnHeader();
            this.ch18 = new System.Windows.Forms.ColumnHeader();
            this.ch19 = new System.Windows.Forms.ColumnHeader();
            this.ch20 = new System.Windows.Forms.ColumnHeader();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.XLxport = new System.Windows.Forms.ToolStripButton();
            this.hhh = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.PBWait = new System.Windows.Forms.ToolStripLabel();
            this.grpACF.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // imageList16
            // 
            this.imageList16.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList16.ImageStream")));
            this.imageList16.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList16.Images.SetKeyName(0, "");
            this.imageList16.Images.SetKeyName(1, "");
            this.imageList16.Images.SetKeyName(2, "");
            this.imageList16.Images.SetKeyName(3, "");
            this.imageList16.Images.SetKeyName(4, "");
            this.imageList16.Images.SetKeyName(5, "");
            this.imageList16.Images.SetKeyName(6, "");
            this.imageList16.Images.SetKeyName(7, "");
            // 
            // grpACF
            // 
            this.grpACF.Controls.Add(this.lvAllProjects);
            this.grpACF.Controls.Add(this.toolStrip1);
            this.grpACF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpACF.Location = new System.Drawing.Point(0, 0);
            this.grpACF.Name = "grpACF";
            this.grpACF.Size = new System.Drawing.Size(863, 565);
            this.grpACF.TabIndex = 254;
            this.grpACF.TabStop = false;
            // 
            // lvAllProjects
            // 
            this.lvAllProjects.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvAllProjects.AutoArrange = false;
            this.lvAllProjects.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.lvAllProjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.ch0,
            this.ch1,
            this.ch2,
            this.ch3,
            this.ch4,
            this.ch5,
            this.ch6,
            this.ch7,
            this.ch8,
            this.ch9,
            this.ch10,
            this.ch11,
            this.ch12,
            this.ch13,
            this.ch14,
            this.ch15,
            this.ch16,
            this.ch17,
            this.ch18,
            this.ch19,
            this.ch20});
            this.lvAllProjects.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvAllProjects.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvAllProjects.ForeColor = System.Drawing.Color.Black;
            this.lvAllProjects.FullRowSelect = true;
            this.lvAllProjects.GridLines = true;
            this.lvAllProjects.Location = new System.Drawing.Point(3, 55);
            this.lvAllProjects.Name = "lvAllProjects";
            this.lvAllProjects.ShowGroups = false;
            this.lvAllProjects.Size = new System.Drawing.Size(857, 507);
            this.lvAllProjects.TabIndex = 257;
            this.lvAllProjects.UseCompatibleStateImageBehavior = false;
            this.lvAllProjects.View = System.Windows.Forms.View.Details;
            this.lvAllProjects.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvAllProjects_ColumnClick);
            // 
            // ch0
            // 
            this.ch0.Text = "";
            this.ch0.Width = 26;
            // 
            // ch1
            // 
            this.ch1.Text = "";
            this.ch1.Width = 26;
            // 
            // ch2
            // 
            this.ch2.Text = "";
            this.ch2.Width = 26;
            // 
            // ch3
            // 
            this.ch3.Text = "";
            this.ch3.Width = 26;
            // 
            // ch4
            // 
            this.ch4.Text = "";
            this.ch4.Width = 26;
            // 
            // ch5
            // 
            this.ch5.Text = "";
            this.ch5.Width = 26;
            // 
            // ch6
            // 
            this.ch6.Text = "";
            this.ch6.Width = 26;
            // 
            // ch7
            // 
            this.ch7.Text = "";
            this.ch7.Width = 26;
            // 
            // ch8
            // 
            this.ch8.Text = "";
            this.ch8.Width = 26;
            // 
            // ch9
            // 
            this.ch9.Text = "";
            this.ch9.Width = 26;
            // 
            // ch10
            // 
            this.ch10.Text = "";
            this.ch10.Width = 26;
            // 
            // ch11
            // 
            this.ch11.Text = "";
            this.ch11.Width = 26;
            // 
            // ch12
            // 
            this.ch12.Text = "";
            this.ch12.Width = 26;
            // 
            // ch13
            // 
            this.ch13.Text = "";
            this.ch13.Width = 26;
            // 
            // ch14
            // 
            this.ch14.Text = "";
            this.ch14.Width = 26;
            // 
            // ch15
            // 
            this.ch15.Text = "";
            this.ch15.Width = 26;
            // 
            // ch16
            // 
            this.ch16.Text = "";
            this.ch16.Width = 26;
            // 
            // ch17
            // 
            this.ch17.Text = "";
            this.ch17.Width = 26;
            // 
            // ch18
            // 
            this.ch18.Text = "";
            this.ch18.Width = 26;
            // 
            // ch19
            // 
            this.ch19.Text = "";
            this.ch19.Width = 26;
            // 
            // ch20
            // 
            this.ch20.Text = "";
            this.ch20.Width = 26;
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.XLxport,
            this.hhh,
            this.toolStripSeparator1,
            this.PBWait});
            this.toolStrip1.Location = new System.Drawing.Point(3, 16);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(857, 39);
            this.toolStrip1.TabIndex = 256;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // XLxport
            // 
            this.XLxport.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.XLxport.Image = ((System.Drawing.Image)(resources.GetObject("XLxport.Image")));
            this.XLxport.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.XLxport.Name = "XLxport";
            this.XLxport.Size = new System.Drawing.Size(36, 36);
            this.XLxport.Text = "pick";
            this.XLxport.ToolTipText = "Change Content";
            this.XLxport.Click += new System.EventHandler(this.XLxport_Click);
            // 
            // hhh
            // 
            this.hhh.Name = "hhh";
            this.hhh.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // PBWait
            // 
            this.PBWait.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PBWait.ForeColor = System.Drawing.Color.Red;
            this.PBWait.Name = "PBWait";
            this.PBWait.Size = new System.Drawing.Size(209, 36);
            this.PBWait.Text = "Loading in Progress........";
            // 
            // OR_Sched_projects
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(863, 565);
            this.Controls.Add(this.grpACF);
            this.Name = "OR_Sched_projects";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Scheduled Projects";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OR_Sched_projects_Load);
            this.grpACF.ResumeLayout(false);
            this.grpACF.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

        private void init_CHnn()
       {
           string stSql = "SELECT *  FROM PSM_R_SCD_ITasks ORDER BY ti_xlrnk ";
           SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
           OConn.Open();
           SqlCommand Ocmd = OConn.CreateCommand();
           Ocmd.CommandText = stSql;
           SqlDataReader Oreadr = Ocmd.ExecuteReader();
           int ti = 0;
           while (Oreadr.Read())
           {
               if (ti < 21)
               {
                   lvAllProjects.Columns[ti].Text = Oreadr["ti_Desc"].ToString();
                   lvAllProjects.Columns[ti++].Width = Int32.Parse(Oreadr["ti_xllen"].ToString());  //must be var

               }
               else MessageBox.Show("col hdrs limit...."); 
           
           }
           for (int i = ti; ti < 21; ti++)
               if (lvAllProjects.Columns[ti].Text == "") lvAllProjects.Columns[ti++].Width = 0;
           OConn.Close();

		
		}
        private void NLine_lvAll()
        {
            ListViewItem lvI = lvAllProjects.Items.Add("");
            for (int i=1;i<lvAllProjects.Columns.Count ;i++)
                lvI.SubItems.Add(""); 
        }
        private void load_SubProj()
        {
     //    string stSql = " SELECT PSM_R_SCD_INFO.sc_IREVID, PSM_R_SCD_INFO.sc_Name, PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_Detail.scd_Value, PSM_R_SCD_ITasks.ti_XLrnk,  PSM_R_SCD_ITasks.ti_Desc " +
     //                      " FROM   PSM_R_SCD_INFO INNER JOIN PSM_R_SCD_Detail ON PSM_R_SCD_INFO.sc_LID = PSM_R_SCD_Detail.d_sc_LID INNER JOIN PSM_R_CFinfo ON PSM_R_SCD_INFO.sc_CF_LID = PSM_R_CFinfo.CFLID INNER JOIN " +
 //                          "        PSM_R_SCD_ITasks ON PSM_R_SCD_Detail.scd_TILID = PSM_R_SCD_ITasks.ti_LID INNER JOIN PSM_R_Rev ON PSM_R_SCD_INFO.sc_IREVID = PSM_R_Rev.IRRevID " +
//                           " WHERE     (PSM_R_SCD_INFO.sc_status <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C')" +
//                           " ORDER BY PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_INFO.sc_Name, PSM_R_SCD_ITasks.ti_XLrnk ";

            string WHR = (in_affcod == 0) ? " (PSM_R_SCD_INFO.sc_status <> 0)" : " (PSM_R_SCD_INFO.sc_status <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C') AND (PSM_R_Rev.shiped <> 'D')";
            string stSql = " SELECT PSM_R_SCD_INFO.sc_IREVID, PSM_R_SCD_INFO.sc_Name, PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_Detail.scd_Value, PSM_R_SCD_ITasks.ti_XLrnk,  PSM_R_SCD_ITasks.ti_Desc " +
                " FROM   PSM_R_SCD_INFO INNER JOIN PSM_R_SCD_Detail ON PSM_R_SCD_INFO.sc_LID = PSM_R_SCD_Detail.d_sc_LID INNER JOIN PSM_R_CFinfo ON PSM_R_SCD_INFO.sc_CF_LID = PSM_R_CFinfo.CFLID INNER JOIN " +
                "        PSM_R_SCD_ITasks ON PSM_R_SCD_Detail.scd_TILID = PSM_R_SCD_ITasks.ti_LID INNER JOIN PSM_R_Rev ON PSM_R_SCD_INFO.sc_IREVID = PSM_R_Rev.IRRevID " +
                " WHERE " + WHR +                 //PSM_R_SCD_INFO.sc_status <> 0) AND (PSM_R_Rev.shiped <> 'S') AND (PSM_R_Rev.shiped <> 'T') AND (PSM_R_Rev.shiped <> 'C')" +
                " ORDER BY PSM_R_CFinfo.c_datDlvr, PSM_R_SCD_INFO.sc_Name, PSM_R_SCD_ITasks.ti_XLrnk ";


  lvAllProjects.BeginUpdate();
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
           OConn.Open();
           SqlCommand Ocmd = OConn.CreateCommand();
           Ocmd.CommandText = stSql;
           SqlDataReader Oreadr = Ocmd.ExecuteReader();
            string NCFNm="", OldCFNm="";
            ListViewItem lvI = null;
            while (Oreadr.Read())
            {
                NCFNm = Oreadr["sc_Name"].ToString();
                if (NCFNm != OldCFNm)
                {
                    lvI = lvAllProjects.Items.Add(""); for (int i = 1; i < lvAllProjects.Columns.Count; i++) lvI.SubItems.Add("");
                    //for (i=0;i<lvAllProjects.Columns.Count ;i++) 
                    OldCFNm = NCFNm;
                }
                int ndx=Int32.Parse(Oreadr["ti_XLrnk"].ToString())-1;
                string st = Oreadr["scd_Value"].ToString();
              //  DateTime.Parse (st);    
                if (st.IndexOf('/') == 2 && st.IndexOf('/',3) == 5 && st.Length == 10) st = YYYYMMDD(st);
                lvI.SubItems[ndx].Text = (st == MainMDI.VIDE) ? " " : st;      
          //      lvI.SubItems[ndx].Text  =(Oreadr["scd_Value"].ToString()==MainMDI.VIDE ) ? " " :  Oreadr["scd_Value"].ToString();
              //  MessageBox.Show("ndx= " + ndx.ToString () + "  col. Name= " + lvAllProjects.Columns[ndx].Text + "  val= " + lvI.SubItems[ndx].Text);   
            }
   lvAllProjects.EndUpdate();                            
              
        }

        private string YYYYMMDD(string _dd)
        {
            return _dd.Substring(6, 4) + "/" + _dd.Substring(3, 2) + "/" + _dd.Substring(0, 2);
        }

        private void dataGrid1_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}

        private void lvAllProjects_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //MessageBox.Show(lvAllProjects.Columns[e.Column].Width.ToString());   
            //MessageBox.Show (   e.Column.ToString()  );

          //  btnseek.Text = "Search by:    " + lvQuotes.Columns[e.Column].Text;
            //	if (e.Column == 8 || e.Column == 8 || e.Column == 8) btnseek.Enabled =false; 

            if (ndxCLRD > -1)
            {
                lvAllProjects.Items[ndxCLRD].BackColor = Color.WhiteSmoke;
                ndxCLRD = -1;
            }
            seelCol = e.Column;
        //    ColName(e.Column);


            ListView myListView = (ListView)sender;

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == lvSorter.SortColumn)
            {
                // Reverse the current sort direction for this column.
                if (lvSorter.Order == System.Windows.Forms.SortOrder.Ascending)
                {
                    lvSorter.Order = System.Windows.Forms.SortOrder.Descending;
                }
                else
                {
                    lvSorter.Order = System.Windows.Forms.SortOrder.Ascending;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                //lvSorter.SortColumn = e.Column; old
                //	lvSorter.Order = System.Windows.Forms.SortOrder.Ascending; old

                lvSorter.Order = (srtType == 'A') ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
                srtType = (srtType == 'A') ? 'D' : 'A';
                lvSorter.SortColumn = e.Column;
            }

            // Perform the sort with these new sort options.
            myListView.Sort();
            oldSC = lvSorter.SortColumn;
            lvSorter.SortColumn = 0;

        }

        private void OR_Sched_projects_Load(object sender, EventArgs e)
        {
            this.Refresh();
            this.Cursor = Cursors.WaitCursor;
            init_CHnn();
            load_SubProj();
            this.Cursor = Cursors.Default;
            PBWait.Visible = false;
        }
        private void write_XL_20()
        {
            Object m_objOpt = System.Reflection.Missing.Value;
            Excel.Application m_objXL = new Excel.Application();
            Excel.Workbooks m_objbooks = m_objXL.Workbooks;
            Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);
            Excel.Sheets m_objSheets = m_objBook.Worksheets;
            Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

            object[] objHdrs = { "Sales", "Project#", "Serial#", "Model", "VAC-PHS-HRZ", "Enclosure", "Batteries", "Battery RACK", "Options", "BIN", "Panel Assy.", "Panel Wired", "Mecha. Assy.", "Encl. Wired", "Tests", "Customer", "PO#", "Delivery Date", "Handling & Packaging", "Notes" }; 
            Excel.Range m_objRng = m_objSheet.get_Range("A1", "T1"); // "C1", "D1", "E1", "F1", "G1", "H1", "I1", "J1", "K1", "L1", "M1", "N1", "O1", "P1", "Q1", "R1", "S1", "T1");
            m_objRng.Value2 = objHdrs;
            Excel.Font m_objFont = m_objRng.Font;
            m_objFont.Bold = true;

            object[,] objData = new object[500, 20];
            for (int i = 0; i < lvAllProjects.Items.Count   ; i++)
            {
                for (int j=0;j<20;j++)
                   objData[i, j] = lvAllProjects.Items[i].SubItems[j].Text;
              //  objData[i, 1] = (i < lvQuotes.Items.Count) ? lvQuotes.Items[i].SubItems[2].Text : "";
            }

            m_objRng = m_objSheet.get_Range("A2", m_objOpt);
            m_objRng = m_objRng.get_Resize(500, 20);
            m_objRng.Value2 = objData;
             

            m_objBook.SaveAs(MainMDI.XL_Path + @"\Sched_Projects.xls", m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();


        }
        private void write_XL()
        {
            Object m_objOpt = System.Reflection.Missing.Value;
            Excel.Application m_objXL = new Excel.Application();
            Excel.Workbooks m_objbooks = m_objXL.Workbooks;
            Excel.Workbook m_objBook = m_objbooks.Add(m_objOpt);
            Excel.Sheets m_objSheets = m_objBook.Worksheets;
            Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

            object[] objHdrs = { "Sales", "Project#", "Serial#", "Model", "VAC-PHS-HRZ", "Enclosure", "Batteries", "Battery RACK", "Options", "BIN", "Panel Assy.", "Panel Wired", "Mecha. Assy.", "Encl. Wired", "Tests", "Customer", "PO#", "Delivery Date", "Invoice Date", "Handling & Packaging", "Notes" };
            Excel.Range m_objRng = m_objSheet.get_Range("A1", "U1"); // "C1", "D1", "E1", "F1", "G1", "H1", "I1", "J1", "K1", "L1", "M1", "N1", "O1", "P1", "Q1", "R1", "S1", "T1", "U1");
            m_objRng.Value2 = objHdrs;
            Excel.Font m_objFont = m_objRng.Font;
            m_objFont.Bold = true;

            object[,] objData = new object[500, 21];
            for (int i = 0; i < lvAllProjects.Items.Count; i++)
            {
                for (int j = 0; j < 21; j++)
                    objData[i, j] = lvAllProjects.Items[i].SubItems[j].Text;
                //  objData[i, 1] = (i < lvQuotes.Items.Count) ? lvQuotes.Items[i].SubItems[2].Text : "";
            }

            m_objRng = m_objSheet.get_Range("A2", m_objOpt);
            m_objRng = m_objRng.get_Resize(500, 21);
            m_objRng.Value2 = objData;


            m_objBook.SaveAs(MainMDI.XL_Path + @"\Sched_Projects.xls", m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objBook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();


        }
        private void XLxport_Click(object sender, EventArgs e)
        {
            File.Delete(MainMDI.XL_Path + @"\Sched_Projects.xls"); 
            write_XL();
            MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\Sched_Projects.xls"); 


        }

   

		








    }



}
