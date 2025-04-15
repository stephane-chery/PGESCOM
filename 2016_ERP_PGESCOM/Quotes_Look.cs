using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb ;
using System.Data.SqlClient ;
using System.Threading;
using EAHLibs;

namespace PGESCOM
{

    #region delegate
    public delegate void deleg_fill_lLV(string QTid,string dat,string cpny,string idQT, string nbtimes );
  //  public delegate void deleg_endTHR(string msg);
    #endregion delegate
    /// <summary>
    /// Summary description for LookQuotes.
    /// </summary>
    public class Quotes_Look : System.Windows.Forms.Form
	{

        //threads
        bool killseek = false;
        Thread m_WkTHRD;
        ManualResetEvent m_EventStopThread;
        ManualResetEvent m_EventThreadStopped;
        public deleg_fill_lLV m_RepTrace;
        public deleg_endTHR m_endTHR;
        //thrd functions

        private ListViewColumnSorter  lvSorter=null;
		private int oldSC=0;
        private char srtType='A';
		private int ndxCLRD=-1;
		private int seelCol=0;
		private string seekColNm;
		string curr_LIQID="";
		char in_c='L';
		private static Lib1 Tools = new Lib1();
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton Nquote;
		private System.Windows.Forms.ToolBarButton seekQ;
		private System.Windows.Forms.ToolBarButton EditQ;
		private System.Windows.Forms.ToolBarButton DelQ;
		private System.Windows.Forms.ToolBarButton dup;
		private System.Windows.Forms.ToolBarButton convrt;
        private System.Windows.Forms.ToolBarButton EXIT;
		private System.Windows.Forms.Button btnseek;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox tKey;
		private System.Windows.Forms.GroupBox grpFindqq;
        private System.Windows.Forms.ToolBarButton status;
        private System.Windows.Forms.Label lxtt;
		private System.Windows.Forms.ToolBarButton refrsh;
		private System.Windows.Forms.ImageList Fst_IL32;
        private GroupBox grpFind;
        private ListView lvQuotes;
        private ColumnHeader QID;
        private ColumnHeader Qdate;
        private ColumnHeader Cpny;
        private ColumnHeader Proj;
        private ColumnHeader iqid;
        private ColumnHeader Amount;
        private ColumnHeader DblAmnt;
        private ToolStrip TSmain;
        private ToolStripButton findQ;
        private ToolStripButton newQ;
        private ToolStripButton ConvertQ;
        private ToolStripButton Q3;
        private ToolStripButton _exit;
        private ToolStripLabel PBWait;
        private ToolStripProgressBar TSpbar;
        public PictureBox picCIP;
        private ColumnHeader rid;
        private Button button3;
        private Button button2;
        private Button button1;
        private ToolStripButton toolStripButton1;
        private ToolStripButton NewQ3;
        private Label lSN;
        private ColumnHeader owner;
        private Button btnkill;
        private ToolStripLabel SyncLBL;
        private Panel pnl_stopSrch;
        private System.ComponentModel.IContainer components;

		public Quotes_Look(char x_c)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            //thrd functions
            m_RepTrace = new deleg_fill_lLV(this.fill_lLV);
            m_endTHR = new deleg_endTHR(this.endTHRmsg);
            m_EventStopThread = new ManualResetEvent(false);
            m_EventThreadStopped = new ManualResetEvent(false);

            lvSorter = new ListViewColumnSorter(); 
			this.lvQuotes.ListViewItemSorter  = lvSorter ; 
	//		lvQuotes.Sorting =SortOrder.Ascending ;
	//	    lvQuotes.Sorting =SortOrder.Descending ;
			lvQuotes.AutoArrange=true; 
			in_c=x_c;
			fill_lvQuotes(in_c=='B'); 
			ColName(0) ;
			seelCol=0;

		 	lvSorter.SortColumn =seelCol;
			lvSorter.Order =System.Windows.Forms.SortOrder.Descending  ;
            btnseek.Text = lvQuotes.Columns[seelCol].Text; //"Search by:    " +
			ColName(seelCol);
			Quotes_status();
			Quotes_RV_PRICE(-1);
			
		    Q3.Visible = MainMDI.User.ToLower ()=="ede";
          //  NewQ3.Visible = MainMDI.User.ToLower() == "ede";
            
			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}


        //public void fill_lLV(string QTid,string dat,string cpny,string idQT, string nbtimes )
        //{
        //    // lvqt(QTid,  dat,  cpny,  idQT,  nbtimes);
        //    if (lvQuotes.InvokeRequired)
        //    {
        //        lvQuotes.Invoke((MethodInvoker)delegate ()
        //        {
        //            ListViewItem lvI = lvQuotes.Items.Add(QTid);
        //            lvI.SubItems.Add(MainMDI.frmt_date(dat)); // dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2)   ); 
        //            lvI.SubItems.Add(cpny);
        //            //   if (Oreadr["ProjectName"].ToString() != "")
        //            lvI.SubItems.Add("");

        //            lvI.SubItems.Add(idQT);
        //            lvI.SubItems.Add("");
        //            lvI.SubItems.Add("");
        //            lvI.SubItems.Add("");
        //            lvI.SubItems.Add(nbtimes);
        //            curr_LIQID = idQT;
        //           // lvQuotes.Refresh();
        //        });
        //    }
        //}
        //public void aff_trace(string trace)
        //{
        //    SyncLBL.Text = trace;
        //    TSmain.Refresh();
        //    //  this.Refresh();
        //}
        //public void endTHRmsg(string msg)
        //{

        //    pnl_stopSrch.Visible = false;
        //    lvQuotes.Visible = true;

        //    //// SyncLBL.Text = msg;
        //    //SyncLBL.Visible = false;
        //    //this.Cursor = Cursors.Default;
        //    //MessageBox.Show("Companies SYNC. Done...........");
        //}

        //void lvqt(string QTid, string dat, string cpny, string idQT, string nbtimes)
        //{
        //    ListViewItem lvI = lvQuotes.Items.Add(QTid);
        //    lvI.SubItems.Add(MainMDI.frmt_date(dat)); // dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2)   ); 
        //    lvI.SubItems.Add(cpny);
        //    //   if (Oreadr["ProjectName"].ToString() != "")
        //    lvI.SubItems.Add("");

        //    lvI.SubItems.Add(idQT);
        //    lvI.SubItems.Add("");
        //    lvI.SubItems.Add("");
        //    lvI.SubItems.Add("");
        //    lvI.SubItems.Add(nbtimes);



        //    //    Quotes_RV_PRICE(lvQuotes.Items.Count - 2);
        //    curr_LIQID = idQT;
        //    //TSmain.Refresh();
        //    lvQuotes.Refresh();
        //    //  this.Refresh();


        //}


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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quotes_Look));
            this.toolBar1 = new System.Windows.Forms.ToolBar();
            this.Nquote = new System.Windows.Forms.ToolBarButton();
            this.seekQ = new System.Windows.Forms.ToolBarButton();
            this.EditQ = new System.Windows.Forms.ToolBarButton();
            this.DelQ = new System.Windows.Forms.ToolBarButton();
            this.dup = new System.Windows.Forms.ToolBarButton();
            this.convrt = new System.Windows.Forms.ToolBarButton();
            this.status = new System.Windows.Forms.ToolBarButton();
            this.refrsh = new System.Windows.Forms.ToolBarButton();
            this.EXIT = new System.Windows.Forms.ToolBarButton();
            this.Fst_IL32 = new System.Windows.Forms.ImageList(this.components);
            this.grpFindqq = new System.Windows.Forms.GroupBox();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.newQ = new System.Windows.Forms.ToolStripButton();
            this.findQ = new System.Windows.Forms.ToolStripButton();
            this.ConvertQ = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.Q3 = new System.Windows.Forms.ToolStripButton();
            this.NewQ3 = new System.Windows.Forms.ToolStripButton();
            this._exit = new System.Windows.Forms.ToolStripButton();
            this.PBWait = new System.Windows.Forms.ToolStripLabel();
            this.TSpbar = new System.Windows.Forms.ToolStripProgressBar();
            this.SyncLBL = new System.Windows.Forms.ToolStripLabel();
            this.lxtt = new System.Windows.Forms.Label();
            this.btnseek = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tKey = new System.Windows.Forms.TextBox();
            this.grpFind = new System.Windows.Forms.GroupBox();
            this.lSN = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnkill = new System.Windows.Forms.Button();
            this.lvQuotes = new System.Windows.Forms.ListView();
            this.QID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Qdate = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cpny = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Proj = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.iqid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Amount = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DblAmnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.rid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.owner = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pnl_stopSrch = new System.Windows.Forms.Panel();
            this.grpFindqq.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.TSmain.SuspendLayout();
            this.grpFind.SuspendLayout();
            this.pnl_stopSrch.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolBar1
            // 
            this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
            this.toolBar1.AutoSize = false;
            this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.Nquote,
            this.seekQ,
            this.EditQ,
            this.DelQ,
            this.dup,
            this.convrt,
            this.status,
            this.refrsh,
            this.EXIT});
            this.toolBar1.ButtonSize = new System.Drawing.Size(50, 36);
            this.toolBar1.Dock = System.Windows.Forms.DockStyle.None;
            this.toolBar1.DropDownArrows = true;
            this.toolBar1.ImageList = this.Fst_IL32;
            this.toolBar1.Location = new System.Drawing.Point(0, 0);
            this.toolBar1.Name = "toolBar1";
            this.toolBar1.ShowToolTips = true;
            this.toolBar1.Size = new System.Drawing.Size(876, 64);
            this.toolBar1.TabIndex = 3;
            // 
            // Nquote
            // 
            this.Nquote.ImageIndex = 0;
            this.Nquote.Name = "Nquote";
            this.Nquote.Text = "New Quote";
            this.Nquote.ToolTipText = "New Quote";
            // 
            // seekQ
            // 
            this.seekQ.ImageIndex = 1;
            this.seekQ.Name = "seekQ";
            this.seekQ.Text = "Find Quote";
            this.seekQ.ToolTipText = "Find Quote";
            // 
            // EditQ
            // 
            this.EditQ.ImageIndex = 2;
            this.EditQ.Name = "EditQ";
            this.EditQ.Text = "Edit Quote";
            this.EditQ.ToolTipText = "Edit Quote";
            // 
            // DelQ
            // 
            this.DelQ.ImageIndex = 2;
            this.DelQ.Name = "DelQ";
            this.DelQ.Text = "Delete";
            this.DelQ.ToolTipText = "Delete Quote";
            this.DelQ.Visible = false;
            // 
            // dup
            // 
            this.dup.ImageIndex = 4;
            this.dup.Name = "dup";
            this.dup.Text = "Duplicate";
            this.dup.ToolTipText = "Duplicate Quote";
            this.dup.Visible = false;
            // 
            // convrt
            // 
            this.convrt.ImageIndex = 4;
            this.convrt.Name = "convrt";
            this.convrt.Text = "Convert to Order";
            this.convrt.ToolTipText = "Convert to Order";
            // 
            // status
            // 
            this.status.ImageIndex = 9;
            this.status.Name = "status";
            this.status.Text = "All quotes status";
            this.status.Visible = false;
            // 
            // refrsh
            // 
            this.refrsh.ImageIndex = 12;
            this.refrsh.Name = "refrsh";
            this.refrsh.Text = "Refresh";
            this.refrsh.Visible = false;
            // 
            // EXIT
            // 
            this.EXIT.ImageIndex = 7;
            this.EXIT.Name = "EXIT";
            this.EXIT.Text = "Exit";
            this.EXIT.Visible = false;
            // 
            // Fst_IL32
            // 
            this.Fst_IL32.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("Fst_IL32.ImageStream")));
            this.Fst_IL32.TransparentColor = System.Drawing.Color.Transparent;
            this.Fst_IL32.Images.SetKeyName(0, "");
            this.Fst_IL32.Images.SetKeyName(1, "");
            this.Fst_IL32.Images.SetKeyName(2, "");
            this.Fst_IL32.Images.SetKeyName(3, "");
            this.Fst_IL32.Images.SetKeyName(4, "");
            // 
            // grpFindqq
            // 
            this.grpFindqq.BackColor = System.Drawing.SystemColors.Control;
            this.grpFindqq.Controls.Add(this.picCIP);
            this.grpFindqq.Controls.Add(this.TSmain);
            this.grpFindqq.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFindqq.ForeColor = System.Drawing.Color.Blue;
            this.grpFindqq.Location = new System.Drawing.Point(0, 0);
            this.grpFindqq.Name = "grpFindqq";
            this.grpFindqq.Size = new System.Drawing.Size(1323, 81);
            this.grpFindqq.TabIndex = 1;
            this.grpFindqq.TabStop = false;
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(948, 20);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(47, 48);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 265;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // TSmain
            // 
            this.TSmain.AutoSize = false;
            this.TSmain.BackColor = System.Drawing.Color.LemonChiffon;
            this.TSmain.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newQ,
            this.findQ,
            this.ConvertQ,
            this.toolStripButton1,
            this.Q3,
            this.NewQ3,
            this._exit,
            this.PBWait,
            this.TSpbar,
            this.SyncLBL});
            this.TSmain.LayoutStyle = System.Windows.Forms.ToolStripLayoutStyle.Flow;
            this.TSmain.Location = new System.Drawing.Point(3, 16);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(1317, 57);
            this.TSmain.TabIndex = 260;
            // 
            // newQ
            // 
            this.newQ.ForeColor = System.Drawing.Color.Black;
            this.newQ.Image = ((System.Drawing.Image)(resources.GetObject("newQ.Image")));
            this.newQ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.newQ.Name = "newQ";
            this.newQ.Size = new System.Drawing.Size(71, 51);
            this.newQ.Text = "New Quote";
            this.newQ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.newQ.ToolTipText = "New Quote";
            this.newQ.Click += new System.EventHandler(this.newQ_Click);
            // 
            // findQ
            // 
            this.findQ.ForeColor = System.Drawing.Color.Black;
            this.findQ.Image = ((System.Drawing.Image)(resources.GetObject("findQ.Image")));
            this.findQ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.findQ.Name = "findQ";
            this.findQ.Size = new System.Drawing.Size(70, 51);
            this.findQ.Text = "Find Quote";
            this.findQ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.findQ.ToolTipText = "Find Quote";
            this.findQ.Click += new System.EventHandler(this.findQ_Click);
            // 
            // ConvertQ
            // 
            this.ConvertQ.ForeColor = System.Drawing.Color.Black;
            this.ConvertQ.Image = ((System.Drawing.Image)(resources.GetObject("ConvertQ.Image")));
            this.ConvertQ.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ConvertQ.Name = "ConvertQ";
            this.ConvertQ.Size = new System.Drawing.Size(100, 51);
            this.ConvertQ.Text = "Convert to Order";
            this.ConvertQ.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ConvertQ.ToolTipText = "Convert to Order";
            this.ConvertQ.Click += new System.EventHandler(this.ConvertQ_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.ForeColor = System.Drawing.Color.Black;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(97, 51);
            this.toolStripButton1.Text = "Duplicate Quote";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // Q3
            // 
            this.Q3.ForeColor = System.Drawing.Color.Black;
            this.Q3.Image = ((System.Drawing.Image)(resources.GetObject("Q3.Image")));
            this.Q3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Q3.Name = "Q3";
            this.Q3.Size = new System.Drawing.Size(66, 51);
            this.Q3.Text = "   Quote IV";
            this.Q3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Q3.Click += new System.EventHandler(this.Q3_Click);
            // 
            // NewQ3
            // 
            this.NewQ3.ForeColor = System.Drawing.Color.Black;
            this.NewQ3.Image = ((System.Drawing.Image)(resources.GetObject("NewQ3.Image")));
            this.NewQ3.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewQ3.Name = "NewQ3";
            this.NewQ3.Size = new System.Drawing.Size(130, 51);
            this.NewQ3.Text = "Configurator feedback";
            this.NewQ3.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.NewQ3.Click += new System.EventHandler(this.NewQ3_Click);
            // 
            // _exit
            // 
            this._exit.ForeColor = System.Drawing.Color.Black;
            this._exit.Image = ((System.Drawing.Image)(resources.GetObject("_exit.Image")));
            this._exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this._exit.Name = "_exit";
            this._exit.Size = new System.Drawing.Size(47, 51);
            this._exit.Text = "   Exit   ";
            this._exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this._exit.ToolTipText = "Exit";
            this._exit.Click += new System.EventHandler(this._exit_Click);
            // 
            // PBWait
            // 
            this.PBWait.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PBWait.ForeColor = System.Drawing.Color.Red;
            this.PBWait.Name = "PBWait";
            this.PBWait.Size = new System.Drawing.Size(279, 19);
            this.PBWait.Text = "Search in Progress, please wait...";
            this.PBWait.Visible = false;
            // 
            // TSpbar
            // 
            this.TSpbar.AutoSize = false;
            this.TSpbar.Name = "TSpbar";
            this.TSpbar.Size = new System.Drawing.Size(200, 20);
            this.TSpbar.Step = 5;
            this.TSpbar.Visible = false;
            // 
            // SyncLBL
            // 
            this.SyncLBL.Name = "SyncLBL";
            this.SyncLBL.Size = new System.Drawing.Size(86, 15);
            this.SyncLBL.Text = "toolStripLabel1";
            this.SyncLBL.Visible = false;
            // 
            // lxtt
            // 
            this.lxtt.BackColor = System.Drawing.SystemColors.Control;
            this.lxtt.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lxtt.Font = new System.Drawing.Font("Microsoft Sans Serif", 26.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lxtt.ForeColor = System.Drawing.Color.Red;
            this.lxtt.Location = new System.Drawing.Point(943, 68);
            this.lxtt.Name = "lxtt";
            this.lxtt.Size = new System.Drawing.Size(88, 34);
            this.lxtt.TabIndex = 200;
            this.lxtt.Text = "XTT";
            this.lxtt.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lxtt.Visible = false;
            // 
            // btnseek
            // 
            this.btnseek.BackColor = System.Drawing.Color.Lavender;
            this.btnseek.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnseek.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnseek.ForeColor = System.Drawing.Color.Black;
            this.btnseek.Location = new System.Drawing.Point(601, 15);
            this.btnseek.Name = "btnseek";
            this.btnseek.Size = new System.Drawing.Size(310, 32);
            this.btnseek.TabIndex = 161;
            this.btnseek.Text = "Quote #";
            this.btnseek.UseVisualStyleBackColor = false;
            this.btnseek.Click += new System.EventHandler(this.btnseek_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold);
            this.label4.ForeColor = System.Drawing.Color.Firebrick;
            this.label4.Location = new System.Drawing.Point(6, 37);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(101, 20);
            this.label4.TabIndex = 160;
            this.label4.Text = "Keyword:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tKey
            // 
            this.tKey.BackColor = System.Drawing.Color.PeachPuff;
            this.tKey.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tKey.ForeColor = System.Drawing.Color.Black;
            this.tKey.Location = new System.Drawing.Point(107, 37);
            this.tKey.MaxLength = 60;
            this.tKey.Name = "tKey";
            this.tKey.Size = new System.Drawing.Size(383, 23);
            this.tKey.TabIndex = 159;
            this.tKey.TextChanged += new System.EventHandler(this.tKey_TextChanged);
            // 
            // grpFind
            // 
            this.grpFind.Controls.Add(this.lSN);
            this.grpFind.Controls.Add(this.button3);
            this.grpFind.Controls.Add(this.button2);
            this.grpFind.Controls.Add(this.button1);
            this.grpFind.Controls.Add(this.lxtt);
            this.grpFind.Controls.Add(this.tKey);
            this.grpFind.Controls.Add(this.btnseek);
            this.grpFind.Controls.Add(this.label4);
            this.grpFind.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpFind.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.grpFind.ForeColor = System.Drawing.Color.Blue;
            this.grpFind.Location = new System.Drawing.Point(0, 81);
            this.grpFind.Name = "grpFind";
            this.grpFind.Size = new System.Drawing.Size(1323, 102);
            this.grpFind.TabIndex = 200;
            this.grpFind.TabStop = false;
            this.grpFind.Visible = false;
            // 
            // lSN
            // 
            this.lSN.Font = new System.Drawing.Font("Verdana", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lSN.ForeColor = System.Drawing.Color.Firebrick;
            this.lSN.Location = new System.Drawing.Point(502, 37);
            this.lSN.Name = "lSN";
            this.lSN.Size = new System.Drawing.Size(93, 20);
            this.lSN.TabIndex = 204;
            this.lSN.Text = "Search by";
            this.lSN.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button3
            // 
            this.button3.Enabled = false;
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button3.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button3.Location = new System.Drawing.Point(48, 94);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(185, 24);
            this.button3.TabIndex = 203;
            this.button3.Text = "Item Description";
            this.button3.Visible = false;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.Lavender;
            this.button2.FlatAppearance.BorderSize = 2;
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("Verdana", 12F);
            this.button2.ForeColor = System.Drawing.Color.Black;
            this.button2.Location = new System.Drawing.Point(601, 49);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(310, 32);
            this.button2.TabIndex = 202;
            this.button2.Text = "Item Description";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.button1.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(934, 21);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(94, 24);
            this.button1.TabIndex = 201;
            this.button1.Text = "Options...";
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnkill
            // 
            this.btnkill.BackColor = System.Drawing.Color.Red;
            this.btnkill.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnkill.Font = new System.Drawing.Font("Verdana", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnkill.ForeColor = System.Drawing.Color.White;
            this.btnkill.Location = new System.Drawing.Point(15, 30);
            this.btnkill.Name = "btnkill";
            this.btnkill.Size = new System.Drawing.Size(515, 40);
            this.btnkill.TabIndex = 205;
            this.btnkill.Text = "Please Wait.......click this button to stop searching";
            this.btnkill.UseVisualStyleBackColor = false;
            this.btnkill.Click += new System.EventHandler(this.btnkill_Click);
            // 
            // lvQuotes
            // 
            this.lvQuotes.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvQuotes.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.QID,
            this.Qdate,
            this.Cpny,
            this.Proj,
            this.iqid,
            this.Amount,
            this.DblAmnt,
            this.rid,
            this.owner});
            this.lvQuotes.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvQuotes.ForeColor = System.Drawing.Color.Red;
            this.lvQuotes.FullRowSelect = true;
            this.lvQuotes.GridLines = true;
            this.lvQuotes.Location = new System.Drawing.Point(0, 183);
            this.lvQuotes.MultiSelect = false;
            this.lvQuotes.Name = "lvQuotes";
            this.lvQuotes.Size = new System.Drawing.Size(1323, 354);
            this.lvQuotes.TabIndex = 201;
            this.lvQuotes.UseCompatibleStateImageBehavior = false;
            this.lvQuotes.View = System.Windows.Forms.View.Details;
            this.lvQuotes.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvQuotes_ColumnClick);
            this.lvQuotes.SelectedIndexChanged += new System.EventHandler(this.lvQuotes_SelectedIndexChanged);
            this.lvQuotes.DoubleClick += new System.EventHandler(this.lvQuotes_DoubleClick);
            // 
            // QID
            // 
            this.QID.Text = "Quote #";
            this.QID.Width = 94;
            // 
            // Qdate
            // 
            this.Qdate.Text = "Date: yy/mm/dd";
            this.Qdate.Width = 94;
            // 
            // Cpny
            // 
            this.Cpny.Text = "Company Name";
            this.Cpny.Width = 447;
            // 
            // Proj
            // 
            this.Proj.Text = "Project Name";
            this.Proj.Width = 269;
            // 
            // iqid
            // 
            this.iqid.Text = "";
            this.iqid.Width = 0;
            // 
            // Amount
            // 
            this.Amount.Text = "Amnt";
            this.Amount.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.Amount.Width = 120;
            // 
            // DblAmnt
            // 
            this.DblAmnt.Text = "";
            this.DblAmnt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.DblAmnt.Width = 0;
            // 
            // rid
            // 
            this.rid.Text = "Projects #";
            this.rid.Width = 200;
            // 
            // owner
            // 
            this.owner.Text = "Quote Owner";
            this.owner.Width = 100;
            // 
            // pnl_stopSrch
            // 
            this.pnl_stopSrch.Controls.Add(this.btnkill);
            this.pnl_stopSrch.Location = new System.Drawing.Point(402, 309);
            this.pnl_stopSrch.Name = "pnl_stopSrch";
            this.pnl_stopSrch.Size = new System.Drawing.Size(550, 100);
            this.pnl_stopSrch.TabIndex = 202;
            this.pnl_stopSrch.Visible = false;
            // 
            // Quotes_Look
            // 
            this.AcceptButton = this.btnseek;
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1323, 537);
            this.Controls.Add(this.pnl_stopSrch);
            this.Controls.Add(this.lvQuotes);
            this.Controls.Add(this.grpFind);
            this.Controls.Add(this.grpFindqq);
            this.Controls.Add(this.toolBar1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Quotes_Look";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Quotes List";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Activated += new System.EventHandler(this.Quotes_Look_Activated);
            this.Load += new System.EventHandler(this.LookQuotes_Load);
            this.Resize += new System.EventHandler(this.Quotes_Look_Resize);
            this.grpFindqq.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.grpFind.ResumeLayout(false);
            this.grpFind.PerformLayout();
            this.pnl_stopSrch.ResumeLayout(false);
            this.ResumeLayout(false);

		}
		#endregion

		private void LookQuotes_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!"; 
			MainMDI.Write_Whodo_SSetup("Quotes",'I');
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD); 
           
		
		}

		private void lvQuotes_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if (ndxCLRD>-1) lvQuotes.Items[ndxCLRD].BackColor =Color.WhiteSmoke ;

            
		}

		private void ColName(int colndx)
		{
			seekColNm="~";
			switch (colndx)
			{
				case 0:
					seekColNm="Quote_ID";
					break;
				case 2:
					seekColNm="Cpny_Name1";
                    break;
				case 3:
					seekColNm="ProjectName";
					break;
				case 6:
					seekColNm="Amount";
					break;

			}
		//	btnseek.Enabled = (seekColNm!="~" );//&& tKey.Text.Length>0   );
		}


		private void lvQuotes_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
            //MessageBox.Show (   e.Column.ToString()  );
            if (lvQuotes.Columns[e.Column].Text != "Quote Owner" && lvQuotes.Columns[e.Column].Text != "Times" && lvQuotes.Columns[e.Column].Text != "Projects #")
            {
                btnseek.Text = lvQuotes.Columns[e.Column].Text; //"Search by:    " +
                if (ndxCLRD > -1)
                {
                    lvQuotes.Items[ndxCLRD].BackColor = Color.WhiteSmoke;
                    ndxCLRD = -1;
                }
                ColName(e.Column);
                seelCol = e.Column;

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

                    lvSorter.Order = (srtType == 'A') ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
                    srtType = (srtType == 'A') ? 'D' : 'A';
                    lvSorter.SortColumn = (e.Column != 5) ? e.Column : 6;
                }

                // Perform the sort with these new sort options.
                myListView.Sort();
                oldSC = lvSorter.SortColumn;
                lvSorter.SortColumn = 0;
            }
       
        }


		private void ReSORT_lvQuotes(int e)
		{
			//MessageBox.Show (   e.Column.ToString()  );

            btnseek.Text = lvQuotes.Columns[e].Text; //"Search by:    " +
			ColName(e) ;
			
			seelCol=e; 
            object sender=lvQuotes ;
			ListView myListView = (ListView)sender;

			// Determine if clicked column is already the column that is being sorted.
			if ( e == lvSorter.SortColumn )
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
				//	lvSorter.Order = SortOrder.Ascending; old

				lvSorter.Order = (srtType=='A') ? System.Windows.Forms.SortOrder.Ascending : System.Windows.Forms.SortOrder.Descending;
				srtType=(srtType=='A') ? 'D' : 'A';
				lvSorter.SortColumn = e;
			}

			// Perform the sort with these new sort options.
			myListView.Sort();
			oldSC=lvSorter.SortColumn;
			lvSorter.SortColumn =0;




		}
		private bool Confirm(string msg)
		{
			DialogResult dr=MessageBox.Show(msg ,"Confirmation ",MessageBoxButtons.YesNo ,MessageBoxIcon.Question ); 
			return (dr == DialogResult.Yes  );
		}

		private bool btnOK(int btn)
		{

			bool res=true;
			switch (btn)
			{
				case 0:  //new quote
					res= MainMDI.ALWD_USR("QT_SV",true); //Quotes: Saving, Delete, duplication and Word print.
					break;
				case 5:  //new quote
					res= MainMDI.ALWD_USR("OR_SV",true); //Quotes Conversion.
					break;
			}
			return res;
				
			
		}


		
		private void ref_QList(string r_iqid,int ndx)
		{

				string stSql = "SELECT PSM_Q_IGen.*, PSM_Company.Cpny_Name1 FROM PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID " + 
					" where i_Quoteid=" + r_iqid + " ORDER BY PSM_Q_IGen.Quote_ID ";
				SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
				OConn.Open ();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql ;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();
           
			while (Oreadr.Read ())
			{
				if (ndx==-1)
				{
					string dat=Oreadr["Opndate"].ToString().Substring(0,10);
					ListViewItem lvI= lvQuotes.Items.Add( Oreadr["Quote_ID"].ToString () );
					lvI.SubItems.Add( MainMDI.frmt_date(dat)); //dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2)   ); 
					lvI.SubItems.Add( Oreadr["Cpny_Name1"].ToString()); 
					if (Oreadr["ProjectName"].ToString()=="") lvI.SubItems.Add(" "); else  lvI.SubItems.Add(Oreadr["ProjectName"].ToString() );
					lvI.SubItems.Add(Oreadr["i_Quoteid"].ToString() ); 
					lvI.SubItems.Add("");
					// Quotes_RV_PRICE(lvQuotes.Items.Count -1); 
				}
				else 
				{    
					string dat=Oreadr["Opndate"].ToString().Substring(0,10);
					lvQuotes.Items[ndx].SubItems[0].Text  = Oreadr["Quote_ID"].ToString ();
					lvQuotes.Items[ndx].SubItems[1].Text= MainMDI.frmt_date(dat) ;//dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2)  ; 
					lvQuotes.Items[ndx].SubItems[2].Text  =  Oreadr["Cpny_Name1"].ToString(); 
					lvQuotes.Items[ndx].SubItems[3].Text  = Oreadr["ProjectName"].ToString();
					lvQuotes.Items[ndx].SubItems[4].Text  = Oreadr["i_Quoteid"].ToString() ; 
					lvQuotes.Items[ndx].SubItems[5].Text  = Oreadr["i_Quoteid"].ToString() ; 
				    Quotes_RV_PRICE(ndx); 
					//lvQuotes.Items[ndx].SubItems[5].Text  =""; 
				}

			}
		

			
		}

        public bool fill_found_Qtes(string stSql)
		{

            Hashtable HT_QT = new Hashtable();
            lvQuotes.BeginUpdate(); 
            lvQuotes.Items.Clear();
           	bool found =false;
			if (seekColNm.Length >1)
			{

                ////if (stSql =="")	 stSql = "SELECT PSM_Q_IGen.*, PSM_Company.Cpny_Name1 FROM PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID  " + 
                ////	" where " + seekColNm + " like '%" + tKey.Text +"%'"  +	
                ////	" ORDER BY  Opndate DESC , PSM_Q_IGen.Quote_ID  ";

                if (stSql == "") stSql = "SELECT PSM_Q_IGen.*, PSM_Company.Cpny_Name1, substring(PSM_SALES_AGENTS.First_Name,1,1) +' ' + substring( PSM_SALES_AGENTS.Last_Name,1,1) as owner   FROM PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID INNER JOIN   PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID " +
    " where " + seekColNm + " like '%" + tKey.Text + "%'" +
    " ORDER BY  Opndate DESC , PSM_Q_IGen.Quote_ID  ";
                SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
				OConn.Open ();
				SqlCommand Ocmd = OConn.CreateCommand();
				Ocmd.CommandText = stSql ;
				SqlDataReader Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {
                    if (Oreadr["ProjectName"].ToString().IndexOf("Hakim") == -1)
                    {
                        if (!HT_QT.ContainsKey(Oreadr["i_Quoteid"].ToString()))
                        {
                            string dat = Oreadr["Opndate"].ToString().Substring(0, 10);
                            ListViewItem lvI = lvQuotes.Items.Add(Oreadr["Quote_ID"].ToString());
                            lvI.SubItems.Add(MainMDI.frmt_date(dat)); // dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2)   ); 
                            lvI.SubItems.Add(Oreadr["Cpny_Name1"].ToString());
                            if (Oreadr["ProjectName"].ToString() != "")
                                lvI.SubItems.Add(Oreadr["ProjectName"].ToString());
                            else lvI.SubItems.Add(MainMDI.VIDE);
                            lvI.SubItems.Add(Oreadr["i_Quoteid"].ToString());
                            lvI.SubItems.Add("");
                            lvI.SubItems.Add("");
                            lvI.SubItems.Add("");
                            lvI.SubItems.Add(Oreadr["owner"].ToString()); //lvQuotes.Columns[8].Text = "Owner";
                            Quotes_RV_PRICE(lvQuotes.Items.Count - 2);
                            curr_LIQID = Oreadr["i_Quoteid"].ToString();
                            found = true;
                            HT_QT.Add(Oreadr["i_Quoteid"].ToString(), Convert.ToString(lvQuotes.Items.Count - 1));
                        }

                    }
                }
                chng_lvquotes("Q");
                OConn.Close();
			}

            lvQuotes.EndUpdate();
			return found;

           


		}


    


        void chng_lvquotes(string st)
        {
            if (st=="S")
            {
                lvQuotes.Columns[8].Text = "Times";
                lvQuotes.Columns[3].Width = 0;
                lvQuotes.Columns[5].Width = 0;
                lvQuotes.Columns[7].Width = 0;
            }
            else
            {
                lvQuotes.Columns[8].Text = "Quote Owner";
                lvQuotes.Columns[3].Width = 269;
                lvQuotes.Columns[5].Width = 120;
                lvQuotes.Columns[7].Width = 200;
            }
        }
        public bool fill_found_Qtes_OLD(string stSql)
        {


            lvQuotes.BeginUpdate();
            lvQuotes.Items.Clear();
            bool found = false;
            if (seekColNm.Length > 1)
            {

                if (stSql == "") stSql = "SELECT PSM_Q_IGen.*, PSM_Company.Cpny_Name1 FROM PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID  " +
                    " where " + seekColNm + " like '%" + tKey.Text + "%'" +
                    " ORDER BY  Opndate DESC , PSM_Q_IGen.Quote_ID  ";
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read())
                {


                    string dat = Oreadr["Opndate"].ToString().Substring(0, 10);
                    ListViewItem lvI = lvQuotes.Items.Add(Oreadr["Quote_ID"].ToString());
                    lvI.SubItems.Add(MainMDI.frmt_date(dat)); // dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2)   ); 
                    lvI.SubItems.Add(Oreadr["Cpny_Name1"].ToString());
                    if (Oreadr["ProjectName"].ToString() != "")
                        lvI.SubItems.Add(Oreadr["ProjectName"].ToString());
                    else lvI.SubItems.Add(MainMDI.VIDE);
                    lvI.SubItems.Add(Oreadr["i_Quoteid"].ToString());
                    lvI.SubItems.Add("");
                    lvI.SubItems.Add("");
                    lvI.SubItems.Add("");
                    Quotes_RV_PRICE(lvQuotes.Items.Count - 2);
                    curr_LIQID = Oreadr["i_Quoteid"].ToString();
                    found = true;



                }
                OConn.Close();
            }

            lvQuotes.EndUpdate();
            return found;




        }
		public void fill_lvQuotes(bool BigL)
		{ 

	         int r_NBOrdr=MainMDI.NBOrdr ;
			lvQuotes.Items.Clear();
            //string stSql = "SELECT TOP 50 PSM_Q_IGen.*, PSM_Company.Cpny_Name1 FROM PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID  " + 
            //	" ORDER BY  Opndate DESC , PSM_Q_IGen.Quote_ID ";
            string stSql = " SELECT TOP 50 PSM_Q_IGen.*, PSM_Company.Cpny_Name1  , substring(PSM_SALES_AGENTS.First_Name,1,1) +' ' + substring( PSM_SALES_AGENTS.Last_Name,1,1) as owner  " +
                           " FROM PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID  INNER JOIN   PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID " +
    " ORDER BY  Opndate DESC , PSM_Q_IGen.Quote_ID ";

           

            SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
           
			while (Oreadr.Read ())
			{
          
                string dat=Oreadr["Opndate"].ToString().Substring(0,10);
				ListViewItem lvI= lvQuotes.Items.Add( Oreadr["Quote_ID"].ToString () );
				lvI.SubItems.Add( MainMDI.frmt_date(dat)); //dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2)   ); 
				lvI.SubItems.Add( Oreadr["Cpny_Name1"].ToString()); 
				if (Oreadr["ProjectName"].ToString()!="") 
					lvI.SubItems.Add(Oreadr["ProjectName"].ToString() );
				else lvI.SubItems.Add(MainMDI.VIDE ); 
				lvI.SubItems.Add(Oreadr["i_Quoteid"].ToString() ); 
				lvI.SubItems.Add(""); 
				lvI.SubItems.Add("0");   //DBL_AMNT
                lvI.SubItems.Add("");
                lvI.SubItems.Add(Oreadr["owner"].ToString());
                //	if (!BigL && (r_NBOrdr--) ==0) break;

            }
		//	toolBar1.Buttons[1].Enabled = BigL ;
			grpFind.Visible = BigL ;
			OConn.Close();


		}

		private void Quotes_status_OLDOK()  //display converted or not
		{
			for (int i=0;i<lvQuotes.Items.Count ;i++)
			{
				string st=MainMDI.Find_One_Field("SELECT PSM_Q_SOL.status_Rev FROM PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid " +
					" WHERE PSM_Q_IGen.i_Quoteid=" + lvQuotes.Items[i].SubItems[4].Text + " and  PSM_Q_SOL.status_Rev='C'"  );
//		string st=MainMDI.Find_One_Field("SELECT PSM_R_Rev.RID FROM (PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid) INNER JOIN PSM_R_Rev ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID " +
//                                         WHERE (((PSM_Q_SOL.status_Rev)='C') AND ((PSM_Q_IGen.i_Quoteid)=16));
				
				if (st !=MainMDI.VIDE )   lvQuotes.Items[i].ForeColor =Color.Blue ;
					   //lvQuotes.Items[i].BackColor  =Color.LightSkyBlue ; 
				 
			}

		}

        private void Quotes_status()
        {
            for (int i = 0; i < lvQuotes.Items.Count; i++)
            {
                string stSql = " SELECT  PSM_R_Rev.RID FROM PSM_Q_IGen INNER JOIN  PSM_R_Rev ON PSM_Q_IGen.i_Quoteid = PSM_R_Rev.iQID " +
                               " WHERE     PSM_Q_IGen.i_Quoteid = " + lvQuotes.Items[i].SubItems[4].Text;
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                string prjlist = "";
                while (Oreadr.Read())
                {
                    prjlist += (prjlist == "") ? Oreadr["RID"].ToString() : ", " + Oreadr["RID"].ToString();
                }
                OConn.Close();
                if (prjlist !="") 
                {
                    lvQuotes.Items[i].SubItems[7].Text = prjlist;
                    lvQuotes.Items[i].ForeColor = Color.Blue;
                }
            }

        }

		private void Quotes_RV_PRICEOLD(int ndx)
		{
            int finNdx=(ndx==-1) ? lvQuotes.Items.Count : ndx+1;
			int deb=(ndx==-1) ? 0 : ndx;
			string st2="0";
			for (int i=deb;i<finNdx ;i++)
			{
				// RV_PRICE based on ALS Agent price AGPRICE
				string st=MainMDI.Find_One_Field(" SELECT     SUM(PSM_Q_ALS.AGPrice) AS Expr4 " +
                                                 " FROM         PSM_Q_IGen INNER JOIN PSM_Q_SOL ON PSM_Q_IGen.i_Quoteid = PSM_Q_SOL.I_Quoteid INNER JOIN " +
                                                 "              PSM_Q_SPCS ON PSM_Q_SOL.Sol_LID = PSM_Q_SPCS.Sol_LID INNER JOIN PSM_Q_ALS ON PSM_Q_SPCS.SPC_LID = PSM_Q_ALS.SPC_LID " +
					                             " WHERE     (PSM_Q_IGen.i_Quoteid =" + lvQuotes.Items[i].SubItems[4].Text  + ") " +
				                         	     " GROUP BY PSM_Q_SOL.Sol_Name, PSM_Q_SPCS.SPC_Name, PSM_Q_SOL.Rnk, PSM_Q_SPCS.Rnk " +                          
					                             " ORDER BY SUM(PSM_Q_ALS.AGPrice) DESC ");
					//          " ORDER BY PSM_Q_SOL.Rnk DESC, PSM_Q_SPCS.Rnk DESC ");
				if (st !=MainMDI.VIDE ) 
				{
					st2=Tools.Conv_Dbl(st).ToString() ; 
					st= "$ " +MainMDI.Curr_FRMT(st) ;
				}
				else
				{
					st2="0";
					st="$ 0.00"; 
				}
				lvQuotes.Items[i].SubItems[5].Text =st;
				lvQuotes.Items[i].SubItems[6].Text =st2;
				//lvQuotes.Items[i].BackColor  =Color.LightSkyBlue ; 
				 
			}

		}




        private void Quotes_RV_PRICE(int ndx)
        {
            int finNdx = (ndx == -1) ? lvQuotes.Items.Count : ndx + 1;
            int deb = (ndx == -1) ? 0 : ndx;
            string st2 = "0", revname="",st="";
            for (int i = deb; i < finNdx; i++)
            {
                //last REV Total based on ALS Agent price AGPRICE
                MainMDI.LastRevAndSum(lvQuotes.Items[i].SubItems[4].Text, ref revname, ref st2);
                //  done 21/11/2008      
                if (st2 != MainMDI.VIDE)
                {
                    st = "$ " + MainMDI.Curr_FRMT(st2);
                    st2 = Tools.Conv_Dbl(st2).ToString();
                    
                }
                else
                {
                    st2 = "0";
                    st = "$ 0.00";
                }
                lvQuotes.Items[i].SubItems[5].Text = st;
                lvQuotes.Items[i].SubItems[6].Text = st2;
                //lvQuotes.Items[i].BackColor  =Color.LightSkyBlue ; 

            }

        }



		private void lvQuotes_DoubleClick(object sender, System.EventArgs e)
		{
            OpenQuote2();
            // OpenQuote4();
		}

        void OpenQuote2()
        {

            this.Cursor = Cursors.WaitCursor;
            if (lvQuotes.SelectedItems.Count > 0)
            {
                edit_Quote(lvQuotes.SelectedItems[0].SubItems[0].Text, lvQuotes.SelectedItems[0].SubItems[2].Text);
                ref_QList(lvQuotes.SelectedItems[0].SubItems[4].Text, lvQuotes.SelectedItems[0].Index);

            }

            this.Cursor = Cursors.Default;
        }

        void OpenQuote4()
        {

            this.Cursor = Cursors.WaitCursor;
            if (lvQuotes.SelectedItems.Count > 0)
            {
                edit_Quote4(lvQuotes.SelectedItems[0].SubItems[0].Text, lvQuotes.SelectedItems[0].SubItems[2].Text);
                ref_QList(lvQuotes.SelectedItems[0].SubItems[4].Text, lvQuotes.SelectedItems[0].Index);

            }

            this.Cursor = Cursors.Default;
        }

        private void edit_Quote(string QNB, string CpnyName)
        {
            if (MainMDI.User == "ede")
            {
                MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where [user]='Admin'");
                MainMDI.Use_QRID(-1, 'Q', "Admin");
            }

            string usr = MainMDI.is_QR_Used('Q', lvQuotes.SelectedItems[0].SubItems[4].Text);
            if (usr == MainMDI.VIDE || MainMDI.User == "ede")
            {

                MainMDI.Use_QRID(1, 'Q', lvQuotes.SelectedItems[0].SubItems[4].Text);
                char c = (QNB == "0") ? 'N' : 'E';
                int ndx = lvQuotes.SelectedItems[0].Index;
                QuoteV2 child4 = new QuoteV2(Convert.ToInt32(QNB), CpnyName, c);
                this.Hide();
                child4.ShowDialog();
                this.Visible = true;
                if (child4.lSave.Text == "S")
                {

                    lvQuotes.Items[ndx].SubItems[0].Text = child4.tQuoteID.Text;
                    string dat = child4.tOpendate.Text;
                    lvQuotes.Items[ndx].SubItems[1].Text = MainMDI.frmt_date(dat);// dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2);
                    lvQuotes.Items[ndx].SubItems[2].Text = child4.lCpnyName.Text;
                    lvQuotes.Items[ndx].SubItems[3].Text = child4.tProjNAME.Text;

                }
                MainMDI.Use_QRID(0, 'Q', lvQuotes.SelectedItems[0].SubItems[4].Text);
                child4.Dispose();
            }
            else MessageBox.Show("Sorry, This Quote is opened by: " + usr);


        }

        private void edit_Quote4(string QNB, string CpnyName)
        {
            if (MainMDI.User == "ede")
            {
                MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where [user]='Admin'");
                MainMDI.Use_QRID(-1, 'Q', "Admin");
            }

            string usr = MainMDI.is_QR_Used('Q', lvQuotes.SelectedItems[0].SubItems[4].Text);
            if (usr == MainMDI.VIDE || MainMDI.User == "ede")
            {

                MainMDI.Use_QRID(1, 'Q', lvQuotes.SelectedItems[0].SubItems[4].Text);
                char c = (QNB == "0") ? 'N' : 'E';
                int ndx = lvQuotes.SelectedItems[0].Index;
                QuoteV4 child4 = new QuoteV4(Convert.ToInt32(QNB), CpnyName, c);
                this.Hide();
                child4.ShowDialog();
                this.Visible = true;
                if (child4.lSave.Text == "S")
                {

                    lvQuotes.Items[ndx].SubItems[0].Text = child4.tQuoteID.Text;
                    string dat = child4.tOpendate.Text;
                    lvQuotes.Items[ndx].SubItems[1].Text = MainMDI.frmt_date(dat);// dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2);
                    lvQuotes.Items[ndx].SubItems[2].Text = child4.lCpnyName.Text;
                    lvQuotes.Items[ndx].SubItems[3].Text = child4.tProjNAME.Text;

                }
                MainMDI.Use_QRID(0, 'Q', lvQuotes.SelectedItems[0].SubItems[4].Text);
                child4.Dispose();
            }
            else MessageBox.Show("Sorry, This Quote is opened by: " + usr);


        }

		private void edit_QuoteIII(string QNB,string CpnyName)
		{
			if (MainMDI.User =="ede")
			{
				MainMDI.ExecSql("UPDATE PSM_users_New  SET [inuse]='0' where [user]='Admin'" );
				MainMDI.Use_QRID(-1,'Q',"Admin");  
			}

            string usr=MainMDI.is_QR_Used('Q',lvQuotes.SelectedItems[0].SubItems[4].Text );
			if (usr == MainMDI.VIDE  || MainMDI.User =="ede" )
			{

                MainMDI.Use_QRID(1,'Q',lvQuotes.SelectedItems[0].SubItems[4].Text);  
				char c=(QNB=="0") ? 'N' : 'E';
				int ndx=lvQuotes.SelectedItems[0].Index ;
                QuoteV3 child4 = new QuoteV3(Convert.ToInt32(QNB), CpnyName, c);
				this.Hide();
                child4.ShowDialog ();
				this.Visible =true;
				if (child4.lSave.Text =="S" ) 
				{

					lvQuotes.Items[ndx].SubItems[0].Text = child4.tQuoteID.Text ;
					string dat=child4.tOpendate.Text;
					lvQuotes.Items[ndx].SubItems[1].Text =MainMDI.frmt_date(dat);// dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2);
					lvQuotes.Items[ndx].SubItems[2].Text =child4.lCpnyName.Text ;
					lvQuotes.Items[ndx].SubItems[3].Text =child4.tProjNAME.Text;
 
				}
				MainMDI.Use_QRID(0,'Q',lvQuotes.SelectedItems[0].SubItems[4].Text);  
				child4.Dispose(); 
			}
			else MessageBox.Show("Sorry, This Quote is opened by: " + usr); 

/*
			if (QNB !="0" )
			{

			   Quote child4 = new Quote(Convert.ToInt32(QNB),CpnyName,'E'  );
			   child4.ShowDialog ();
			   child4.Dispose(); 
			//	MainMDI.frm_Qte.x_QID = Convert.ToInt32(QNB);  
			//	MainMDI.frm_Qte.x_CpnyName  =CpnyName;
			//	MainMDI.frm_Qte.x_opera  ='E';
			//	MainMDI.frm_Qte.ShowDialog ();

				//fill_lvQuotes(); 
			}
			else
			{ 
				Quote child4 = new Quote(0,"*",'N' );
				child4.ShowDialog ();
				child4.Dispose(); 
			//	MainMDI.frm_Qte = new Quote(0,"*",'E');
			//	MainMDI.frm_Qte.ShowDialog ();
			}
			 child4.Dispose(); 
			 */
		}

		private void Quotes_Look_Activated(object sender, System.EventArgs e)
		{
		// fill_lvQuotes(); 
		}

		private void grpRech_Enter(object sender, System.EventArgs e)
		{
		
		}


		private void btnDup_Click(object sender, System.EventArgs e)
		{
			
		}

	

		private void lCpnyID_Click(object sender, System.EventArgs e)
		{
		
		}



		private void btnseek_BIGLIST()
		{
			
			bool found=false;
			
			if (tKey.Text !="")
			{
				if (ndxCLRD>-1) 
				{ 
					lvQuotes.Items[ndxCLRD].BackColor =Color.WhiteSmoke ; 
					ndxCLRD=-1;
				}
				ndxCLRD=-1;
				for (int i=0;i<lvQuotes.Items.Count ;i++)
				{
					if (( lvQuotes.Items[i].SubItems[seelCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1)) 
					{
						lvQuotes.Items[i].BackColor =Color.Yellow  ;
						lvQuotes.Items[i].Selected =true;
						lvQuotes.Items[i].EnsureVisible(); 
						ndxCLRD=i;
						i=lvQuotes.Items.Count+1;
						found=true;
					}
				}
			}
			if (!found) { MessageBox.Show("Sorry, Not Found !!!..."); ndxCLRD=-1;}
		}
      
		

		private void btnseek_Click_old(object sender, System.EventArgs e)
		{
			int ideb=0;
			bool found=false;
			if (tKey.Text !="")
			{
				if (ndxCLRD>-1) 
				{ 
					lvQuotes.Items[ndxCLRD].BackColor =Color.WhiteSmoke ; 
					ideb=ndxCLRD+1;
					ndxCLRD=-1;
				}
				for (int i=ideb;i<lvQuotes.Items.Count ;i++)
				{
					if (( lvQuotes.Items[i].SubItems[seelCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1)) 
					{
						lvQuotes.Items[i].BackColor =Color.Yellow    ;
						lvQuotes.Items[i].Selected =true;
						lvQuotes.Items[i].EnsureVisible(); 
						ndxCLRD=i;
						i=lvQuotes.Items.Count+1;
						found=true;
						//btnseek.Text = btnseek.Text.Replace("Search","Next ") ; 
                        lSN.Text = "Next";
					}
				}
			}
			if (!found) { MessageBox.Show("Sorry, Not Found !!!..."); ndxCLRD=-1;}
	

		
		}
		
		private void ReSeek()
		{
			
			bool found=false;
			
			if (tKey.Text !="")
			{
				if (ndxCLRD>-1) 
				{ 
					lvQuotes.Items[ndxCLRD].BackColor =Color.WhiteSmoke ; 
					ndxCLRD=-1;
				}
				ndxCLRD=-1;
				for (int i=0;i<lvQuotes.Items.Count ;i++)
				{
					if (( lvQuotes.Items[i].SubItems[seelCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1)) 
					{
						lvQuotes.Items[i].BackColor =Color.Yellow  ;
					    lvQuotes.Items[i].Selected =true;
						lvQuotes.Items[i].EnsureVisible(); 
						ndxCLRD=i;
						i=lvQuotes.Items.Count+1;
						found=true;
					}
				}
			}
			if (!found) { MessageBox.Show("Sorry, Not Found !!!..."); ndxCLRD=-1;}
		}
		private void Del_Bfr_seek()
		{
		   for (int i=0;i<lvQuotes.Items.Count ;i++)
			if (( lvQuotes.Items[i].SubItems[seelCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1))	lvQuotes.Items[i].Remove();
		
		}

		private bool Found_InLV()
		{
			int ideb=0;
			bool found=false;
			if (tKey.Text !="")
			{
				if (ndxCLRD>-1 ) 
				{ 
					lvQuotes.Items[ndxCLRD].BackColor =Color.WhiteSmoke ; 
					ideb=ndxCLRD+1;
					ndxCLRD=-1;
				}
				int i=ideb;
				while (true)
				{  
					for (i=ideb;i<lvQuotes.Items.Count ;i++)
					{
						if (( lvQuotes.Items[i].SubItems[seelCol].Text.ToUpper().IndexOf(tKey.Text.ToUpper() ,0) >-1)) 
						{
							lvQuotes.Items[i].BackColor =Color.Yellow    ;
							lvQuotes.Items[i].Selected =true;
							lvQuotes.Items[i].EnsureVisible(); 
							ndxCLRD=i;
							i=lvQuotes.Items.Count+1;
							found=true;
						//	btnseek.Text = btnseek.Text.Replace("Search","Next ") ;
                            lSN.Text = "Next";
						}
					}
					if (!found && ideb>0) ideb=0;
					else break;
				//	if (!found  || i>= lvQuotes.Items.Count) break;

				}
			}

			if (!found) ndxCLRD=-1;
            return found ;	

		
		}


		private void Quotes_Look_Resize(object sender, System.EventArgs e)
		{
		//	picExit.Left = this.Width - 48;
		}

		private void picExit_Click(object sender, System.EventArgs e)
		{

			
		}

		private void littl_list()
		{
			bool res_Found=false;
			if (ndxCLRD==-1) Del_Bfr_seek();
			else res_Found= Found_InLV();
			if (!res_Found )
			{
				if (!fill_found_Qtes("") )
				{
					MessageBox.Show("Sorry, Not Found !!!..."); 
					ndxCLRD=-1;
				}
				else 
				{
					ReSORT_lvQuotes(seelCol );  
					ReSeek();
					lvQuotes.Refresh();
				}
			}
			Quotes_RV_PRICE(-1); 
			Quotes_status();
			
		}
        private void littl_list_ItemDescOLD()
        {
           // bool res_Found = false;
            Del_Bfr_seek();
            this.Cursor = Cursors.WaitCursor;

            //string whr = tKey.Text.Replace("**", "*").Replace("*", "%");
            //string stSql = " SELECT DISTINCT PSM_Q_IGen.Quote_ID AS QTnb, PSM_Q_IGen.*, PSM_COMPANY.Cpny_Name1 " +
            //      " FROM         PSM_Q_Details INNER JOIN PSM_Q_ALS ON PSM_Q_Details.ALS_LID = PSM_Q_ALS.ALS_LID INNER JOIN PSM_Q_SPCS ON PSM_Q_ALS.SPC_LID = PSM_Q_SPCS.SPC_LID INNER JOIN " +
            //      "              PSM_Q_SOL ON PSM_Q_SPCS.Sol_LID = PSM_Q_SOL.Sol_LID INNER JOIN PSM_Q_IGen ON PSM_Q_SOL.I_Quoteid = PSM_Q_IGen.i_Quoteid INNER JOIN PSM_COMPANY ON PSM_Q_IGen.CPNY_ID = PSM_COMPANY.Cpny_ID " +
            //      " WHERE    Charindex('" + tKey.Text + "', PSM_Q_Details.[Desc]) > 0   order by QTnb ";//%P4500-%IT%') ";

              
            if (!fill_found_txtQT())
                {
                    MessageBox.Show("Sorry, Not Found !!!...");
                    ndxCLRD = -1;
                }
            Quotes_RV_PRICE(-1);
            Quotes_status();
            this.Cursor = Cursors.Default;

        }

        public bool fill_found_txtQT()
        {

            Hashtable HT_QT = new Hashtable();
            lvQuotes.Items.Clear();

            lvQuotes.BeginUpdate();

            bool found = false;
            if (tKey.Text.Length > 1)
            {

                ////if (stSql =="")	 stSql = "SELECT PSM_Q_IGen.*, PSM_Company.Cpny_Name1 FROM PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID  " + 
                ////	" where " + seekColNm + " like '%" + tKey.Text +"%'"  +	
                ////	" ORDER BY  Opndate DESC , PSM_Q_IGen.Quote_ID  ";

                //            if (stSql == "") stSql = "SELECT PSM_Q_IGen.*, PSM_Company.Cpny_Name1, substring(PSM_SALES_AGENTS.First_Name,1,1) +' ' + substring( PSM_SALES_AGENTS.Last_Name,1,1) as owner   FROM PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID INNER JOIN   PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID " +
                //" where " + seekColNm + " like '%" + tKey.Text + "%'" +
                //" ORDER BY  Opndate DESC , PSM_Q_IGen.Quote_ID  ";

                string stSql = " SELECT    PSM_Q_IGen.Opndate,   PSM_Q_IGen.Quote_ID, PSM_Q_IGen.i_Quoteid, PSM_COMPANY.Cpny_Name1, COUNT(PSM_Q_Details.[Desc]) AS nbtimes " +
                           " FROM PSM_Q_Details INNER JOIN PSM_Q_ALS ON PSM_Q_Details.ALS_LID = PSM_Q_ALS.ALS_LID INNER JOIN  PSM_Q_SPCS ON PSM_Q_ALS.SPC_LID = PSM_Q_SPCS.SPC_LID INNER JOIN " +
                           "                    PSM_Q_SOL ON PSM_Q_SPCS.Sol_LID = PSM_Q_SOL.Sol_LID INNER JOIN PSM_Q_IGen ON PSM_Q_SOL.I_Quoteid = PSM_Q_IGen.i_Quoteid INNER JOIN  PSM_COMPANY ON PSM_Q_IGen.CPNY_ID = PSM_COMPANY.Cpny_ID " +
                           " WHERE (ProjectName not like 'hakim') and(PSM_Q_Details.[Desc] LIKE '%" + tKey.Text + "%') " +
                           " GROUP BY PSM_Q_IGen.Opndate,PSM_Q_IGen.Quote_ID, PSM_Q_IGen.i_Quoteid, PSM_COMPANY.Cpny_Name1  ORDER BY PSM_Q_IGen.i_Quoteid ";



                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
         
                while (Oreadr.Read())
                {

                    string dat = Oreadr["Opndate"].ToString().Substring(0, 10);
                    ListViewItem lvI = lvQuotes.Items.Add(Oreadr["Quote_ID"].ToString());
                    lvI.SubItems.Add(MainMDI.frmt_date(dat)); // dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2)   ); 
                    lvI.SubItems.Add(Oreadr["Cpny_Name1"].ToString());
                    //   if (Oreadr["ProjectName"].ToString() != "")
                    lvI.SubItems.Add("");

                    lvI.SubItems.Add(Oreadr["i_Quoteid"].ToString());
                    lvI.SubItems.Add("");
                    lvI.SubItems.Add("");
                    lvI.SubItems.Add("");
                    lvI.SubItems.Add(Oreadr["nbtimes"].ToString());



                    //    Quotes_RV_PRICE(lvQuotes.Items.Count - 2);
                    curr_LIQID = Oreadr["i_Quoteid"].ToString();
                    found = true;


                }
                OConn.Close();

                chng_lvquotes("S");
            }

            lvQuotes.EndUpdate();

            return found;
           

        }

        private void btnseek_Click(object sender, System.EventArgs e)
		{
            if (tKey.Text.Length > 2)
            {
                this.Cursor = Cursors.WaitCursor;
                lvQuotes.BeginUpdate();
                lvQuotes.Items.Clear(); ndxCLRD = -1;

                if (in_c == 'B') btnseek_BIGLIST();
                else littl_list();
                lvQuotes.EndUpdate();
                this.Cursor = Cursors.Default;
               MainMDI.Q_tkey = tKey.Text;
            }
	 	//	if (!found) { MessageBox.Show("Sorry, Not Found !!!..."); ndxCLRD=-1;}
		}


		private void tKey_TextChanged(object sender, System.EventArgs e)
		{
		//	btnseek.Enabled =  (tKey.Text.Length >2) ;
        //    button2.Enabled = (tKey.Text.Length > 2);
		}

        private void _exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }


        private bool CustomerNOTinBL(string cpnyName)
        {
            string BLcmnt = "", InBL = "", usr = "";
            MainMDI.Find_2_Field("select BLack_List,  BL_Cmnt, BL_usr  from PSM_COMPANY Where Cpny_Name1='" + cpnyName + "'", ref InBL, ref BLcmnt, ref  usr);
            if (InBL == "0") return true;
            else     MessageBox.Show("Sorry, This Company is in BLACK LIST ...You have to contact Admin....\n Why? : " + BLcmnt + "\n Added in Black-List by: " + usr, "BLACK LIST", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            return false;

        }


        private bool QuoteHas_bad_XTRN_SP(string my_i_Quoteid)
        {
            string cpny_code = MainMDI.Find_One_Field("select distinct dbo.PSM_COMPANY.Syspro_Code from dbo.PSM_Q_IGen inner join dbo.PSM_COMPANY on dbo.PSM_COMPANY.Cpny_ID=dbo.PSM_Q_IGen.CPNY_ID where i_Quoteid=" + my_i_Quoteid);
            string SalCd= MainMDI.Find_One_Field_SYSPRO("select dbo.v_PGCustomerXRef.Salesperson from dbo.v_PGCustomerXRef where Customer='" + cpny_code  + "'");
            return ((SalCd == MainMDI.VIDE || SalCd == "H03"));        

        }





        private void OldtoolBar(int btn)
        {

            if (btnOK(btn))
            {
                switch (btn)
                {

                    case 0:  //New quote


                        ////Quote2
                        QuoteV2 child4 = new QuoteV2(0, "*", 'N');
                        this.Hide();
                        child4.ShowDialog();
                        this.Visible = true;
                        if (child4.lCurrIQID.Text != "") ref_QList(child4.lCurrIQID.Text, -1);
                        child4.Dispose();

                    //Quote4
                        //QuoteV4 child4 = new QuoteV4(0, "*", 'N');
                        //this.Hide();
                        //child4.ShowDialog();
                        //this.Visible = true;
                        //if (child4.lCurrIQID.Text != "") ref_QList(child4.lCurrIQID.Text, -1);
                        //child4.Dispose();

                        break;
                    case 2:  //edit Quote
                      //  lvQuotes_DoubleClick(sender, e);

                        break;
                    case 1:  //find Quote
                        grpFind.Visible = !grpFind.Visible;
                        tKey.Focus();
                        break;
                    case 3:  //delete Quote disabled
                        /*
                        if (lvQuotes.SelectedItems.Count ==1)
                        {
                            if (Confirm("DELETE THIS QUOTE#" + lvQuotes.SelectedItems[0].SubItems[0].Text + " ? : ")) 
                            {
                                MainMDI.ExecSql("delete PSM_Q_IGen where i_Quoteid=" + lvQuotes.SelectedItems[0].SubItems[4].Text );
                                lvQuotes.Items[lvQuotes.SelectedItems[0].Index ].Remove();  
                            }
                        }
                        */
                        break;
                    case 4:   //duplicate Quote
                        QuoteV2 frm_Qte = new QuoteV2(0, "*", 'D');
                        this.Hide();
                        frm_Qte.ShowDialog();
                        this.Visible = true;
                        frm_Qte.Dispose();
                        //	fill_lvQuotes(); 

                        //	groupBox1.Visible = (lvQuotes.SelectedItems.Count == 1);
                        //	btnDup.Enabled = lCpnyID.Text !="0" ;
                        break;


                    case 5:  //Convert Quote To Order
                        if (MainMDI.PermT_user("RS"))
                        {

                            string res = MainMDI.Find_One_Field("select  AGency from PSM_Q_IGen where i_Quoteid=" +  lvQuotes.SelectedItems[0].SubItems[4].Text);
                            if (res != "2")
                            {
                               string  res2 = MainMDI.Find_One_Field("SELECT [A_CMSLID]  ,[AG_Dest]  ,[AG_Infl]   ,[AG_Eng]   ,[AG_PO] FROM [Orig_PSM_FDB].[dbo].[PSM_R_REV_agCMS] where A_CMS_IQID=" + lvQuotes.SelectedItems[0].SubItems[4].Text);
                               if (res == "0" || res2 != MainMDI.VIDE)
                               {

                                   if (QuoteHas_bad_XTRN_SP(lvQuotes.SelectedItems[0].SubItems[4].Text))
                                   {
                                       MessageBox.Show("You may check:  EXTERNAL SALE NAME in this Quote before conversion to Project.... ", "EXTERNAL SALE NAME", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                                   }
                                   if (lvQuotes.SelectedItems.Count == 1 && CustomerNOTinBL(lvQuotes.SelectedItems[0].SubItems[2].Text))
                                   {   // MainMDI.ExecSql("delete pgm_Det_OL");  

                                       if ((lvQuotes.SelectedItems[0].ForeColor != Color.Blue) || (lvQuotes.SelectedItems[0].ForeColor == Color.Blue && MainMDI.Confirm("This Quote has been already Converted !! ,  Continue Conversion ?")))
                                       {
                                           //          if (MainMDI.IsValid_Quote(lvQuotes.SelectedItems[0].SubItems[0].Text))
                                           //          {
                                           if (lvQuotes.SelectedItems[0].SubItems[3].Text != "")
                                           {
                                               MainMDI.ExecSql("delete " + MainMDI.t_Det_OL);
                                               QuoteV2 child44 = new QuoteV2(Convert.ToInt32(lvQuotes.SelectedItems[0].SubItems[0].Text), lvQuotes.SelectedItems[0].SubItems[2].Text, 'C');
                                               this.Hide();
                                               child44.ShowDialog();
                                               this.Visible = true;
                                               child44.Dispose();
                                               // this.Hide();
                                           }
                                           else MessageBox.Show("The Project Name is Invalid, edit this Quote && Change the Project Name !!!!", "Project Name Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                           //   }
                                           //  else MessageBox.Show("Sorry,  this Quote is INVALID you must create a new one to continue Conversion .....!!", "INVALID Quote: " + lvQuotes.SelectedItems[0].SubItems[0].Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
                                       }
                                   }
                               }
                               else MessageBox.Show("Can not CONVERT This quote since AGENTS are not defined.....\n Pls. open this Quote and fill [Agents] TAB )");

                            }
                            else MessageBox.Show("Can not CONVERT This quote  since AGENT status is Unknown ....\n   Pls. open this Quote and check AGENTs status in [Agent] TAB )");

                        }
                        else MessageBox.Show(MainMDI.User + ": is NOT allowed to perform this option, contact you Admin....! ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        break;
                    case 6:
                        this.Cursor = Cursors.WaitCursor;
                        Quotes_status();
                        this.Cursor = Cursors.Default;
                        break;
                    case 7:
                        if (lvQuotes.SelectedItems.Count == 1) ref_QList(lvQuotes.SelectedItems[0].SubItems[4].Text, lvQuotes.SelectedItems[0].Index);
                        break;
                    case 8:
                        this.Hide();
                        break;
                }


 
            }
        }
        private void newQ_Click(object sender, EventArgs e)
        {
            OldtoolBar(0);
        }

        private void findQ_Click(object sender, EventArgs e)
        {
            tKey.Text = MainMDI.Q_tkey;
            OldtoolBar(1);
        }

        private void ConvertQ_Click(object sender, EventArgs e)
        {
            if (lvQuotes.SelectedItems.Count ==1)    OldtoolBar(5);
        }

        private void button2_ClickOLD(object sender, EventArgs e)
        {
           
            if (tKey.Text.Length > 2 && tKey.Text.IndexOf("**")== -1 )
            {
                lvQuotes.BeginUpdate();
                littl_list_ItemDescOLD();
                lvQuotes.EndUpdate();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

            if (tKey.Text.Length > 2 && tKey.Text.IndexOf("**") == -1)
            {
                chng_lvquotes("S");
                pnl_stopSrch.Visible = true;
                lvQuotes.Visible = false;

                killseek = false;
                lvQuotes.Items.Clear();

            //    lvQuotes.BeginUpdate();

                MTRD_Find_TxtinQT();

               

                //pnl_stopSrch.Visible = false;
                //lvQuotes.Visible = true;

                //     lvQuotes.EndUpdate();

                // this.Cursor = Cursors.Default;
            }
        }






        public void fill_lLV(string QTid, string dat, string cpny, string idQT, string nbtimes)
        {
            // lvqt(QTid,  dat,  cpny,  idQT,  nbtimes);
            if (lvQuotes.InvokeRequired)
            {
                lvQuotes.Invoke((MethodInvoker)delegate ()
                {
                    ListViewItem lvI = lvQuotes.Items.Add(QTid);
                    lvI.SubItems.Add(MainMDI.frmt_date(dat)); // dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2)   ); 
                    lvI.SubItems.Add(cpny);
                    //   if (Oreadr["ProjectName"].ToString() != "")
                    lvI.SubItems.Add("");

                    lvI.SubItems.Add(idQT);
                    lvI.SubItems.Add("");
                    lvI.SubItems.Add("");
                    lvI.SubItems.Add("");
                    lvI.SubItems.Add(nbtimes);
                    curr_LIQID = idQT;
                    // lvQuotes.Refresh();
                });
            }
        }
        public void aff_trace(string trace)
        {
            SyncLBL.Text = trace;
            TSmain.Refresh();
            //  this.Refresh();
        }
        public void endTHRmsg(string msg)
        {

            pnl_stopSrch.Visible = false;
            lvQuotes.Visible = true;

            //// SyncLBL.Text = msg;
            //SyncLBL.Visible = false;
            //this.Cursor = Cursors.Default;
            //MessageBox.Show("Companies SYNC. Done...........");
        }

        void lvqt(string QTid, string dat, string cpny, string idQT, string nbtimes)
        {
            ListViewItem lvI = lvQuotes.Items.Add(QTid);
            lvI.SubItems.Add(MainMDI.frmt_date(dat)); // dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2)   ); 
            lvI.SubItems.Add(cpny);
            //   if (Oreadr["ProjectName"].ToString() != "")
            lvI.SubItems.Add("");

            lvI.SubItems.Add(idQT);
            lvI.SubItems.Add("");
            lvI.SubItems.Add("");
            lvI.SubItems.Add("");
            lvI.SubItems.Add(nbtimes);



            //    Quotes_RV_PRICE(lvQuotes.Items.Count - 2);
            curr_LIQID = idQT;
            //TSmain.Refresh();
            lvQuotes.Refresh();
            //  this.Refresh();


        }
        void MTRD_Find_TxtinQT()
        {
          //  lvQuotes.BeginUpdate();

            killseek = false;
            m_EventStopThread.Reset();
            m_EventThreadStopped.Reset();
            m_WkTHRD = new Thread(new ThreadStart(this.fill_found_txtQT_TH));
            m_WkTHRD.Start();


       //     lvQuotes.EndUpdate();

        }
        public void fill_found_txtQT_TH()
        {

            Hashtable HT_QT = new Hashtable();

       
            bool found = false;
            if (tKey.Text.Length > 1)
            {

                ////if (stSql =="")	 stSql = "SELECT PSM_Q_IGen.*, PSM_Company.Cpny_Name1 FROM PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID  " + 
                ////	" where " + seekColNm + " like '%" + tKey.Text +"%'"  +	
                ////	" ORDER BY  Opndate DESC , PSM_Q_IGen.Quote_ID  ";

                //            if (stSql == "") stSql = "SELECT PSM_Q_IGen.*, PSM_Company.Cpny_Name1, substring(PSM_SALES_AGENTS.First_Name,1,1) +' ' + substring( PSM_SALES_AGENTS.Last_Name,1,1) as owner   FROM PSM_Q_IGen INNER JOIN PSM_Company ON PSM_Q_IGen.CPNY_ID = PSM_Company.Cpny_ID INNER JOIN   PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID " +
                //" where " + seekColNm + " like '%" + tKey.Text + "%'" +
                //" ORDER BY  Opndate DESC , PSM_Q_IGen.Quote_ID  ";

                string stSql = " SELECT    PSM_Q_IGen.Opndate,   PSM_Q_IGen.Quote_ID, PSM_Q_IGen.i_Quoteid, PSM_COMPANY.Cpny_Name1, COUNT(PSM_Q_Details.[Desc]) AS nbtimes " +
                           " FROM PSM_Q_Details INNER JOIN PSM_Q_ALS ON PSM_Q_Details.ALS_LID = PSM_Q_ALS.ALS_LID INNER JOIN  PSM_Q_SPCS ON PSM_Q_ALS.SPC_LID = PSM_Q_SPCS.SPC_LID INNER JOIN " +
                           "                    PSM_Q_SOL ON PSM_Q_SPCS.Sol_LID = PSM_Q_SOL.Sol_LID INNER JOIN PSM_Q_IGen ON PSM_Q_SOL.I_Quoteid = PSM_Q_IGen.i_Quoteid INNER JOIN  PSM_COMPANY ON PSM_Q_IGen.CPNY_ID = PSM_COMPANY.Cpny_ID " +
                           " WHERE (ProjectName not like 'hakim') and(PSM_Q_Details.[Desc] LIKE '%" + tKey.Text + "%') " +
                           " GROUP BY PSM_Q_IGen.Opndate,PSM_Q_IGen.Quote_ID, PSM_Q_IGen.i_Quoteid, PSM_COMPANY.Cpny_Name1  ORDER BY PSM_Q_IGen.i_Quoteid ";



                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();

                while (Oreadr.Read() && !killseek )
                {

                    string dat = Oreadr["Opndate"].ToString().Substring(0, 10);
                   fill_lLV(Oreadr["Quote_ID"].ToString(), dat, Oreadr["Cpny_Name1"].ToString(), Oreadr["i_Quoteid"].ToString(), Oreadr["nbtimes"].ToString());

                    // ListViewItem lvI = lvQuotes.Items.Add();
                    // lvI.SubItems.Add(MainMDI.frmt_date(dat)); // dat.Substring(6,4) + "/" +dat.Substring(3,2)  + "/" +dat.Substring(0,2)   ); 
                    // lvI.SubItems.Add(Oreadr["Cpny_Name1"].ToString());
                    // //   if (Oreadr["ProjectName"].ToString() != "")
                    // lvI.SubItems.Add("");
                    // lvI.SubItems.Add(Oreadr["i_Quoteid"].ToString());
                    // lvI.SubItems.Add("");
                    // lvI.SubItems.Add("");
                    // lvI.SubItems.Add("");
                    //lvI.SubItems.Add(Oreadr["nbtimes"].ToString());
                    // //    Quotes_RV_PRICE(lvQuotes.Items.Count - 2);
                    // curr_LIQID = Oreadr["i_Quoteid"].ToString();

                    found = true;
           

                }
                OConn.Close();
                //   this.Invoke(this.m_RepTrace, new object[] { s });
                this.Invoke(this.m_endTHR, new object[] {"Vide" });
                
            }


            //pnl_stopSrch.Visible = false;
            //lvQuotes.Visible = true;


            if (!found)
            {
                MessageBox.Show("Sorry, Not Found !!!...");
                ndxCLRD = -1;
            }
         //   Quotes_RV_PRICE(-1);
         //   Quotes_status();
          

        }






        private void button1_Click(object sender, EventArgs e)
        {
           grpFind.Height= (grpFind.Height == 50) ? 105 : 50;
           
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            //if (MainMDI.PermT_user("QS"))
                if (MainMDI.ALWD_USR("QT_SV", true)) 
            {

                if (lvQuotes.SelectedItems.Count == 1 && CustomerNOTinBL(lvQuotes.SelectedItems[0].SubItems[2].Text))
                {

                    Qimport_duplicat duplica = new Qimport_duplicat(lvQuotes.SelectedItems[0].SubItems[0].Text, lvQuotes.SelectedItems[0].SubItems[4].Text);
                    duplica.ShowDialog();
                }
                else MessageBox.Show("Please Select a Quote....");
            }
        }


        private void NewQ3_Click(object sender, EventArgs e)
        {

            //QuoteV3 child4 = new QuoteV3(0, "*", 'N');
            //this.Hide();
            //child4.ShowDialog();
            //this.Visible = true;
            //if (child4.lCurrIQID.Text != "") ref_QList(child4.lCurrIQID.Text, -1);
            //child4.Dispose();



            //configo tools
             GoConfigo();

        }
            void GoConfigo()
            {

                GenConfigi_Quotes myFRM = new GenConfigi_Quotes();
            this.Hide();
          
            myFRM.ShowDialog();
            this.Visible = true;
            myFRM.Dispose();


            ////for using copy past in quotes
            //if (myFRM.lCopy.Text == "Y")
            //{
            //    MNoPaste.Enabled = true;
            //    menuItem9.Enabled = true;
            //}
        }

    


        void Open_Quote23()
        {

            this.Cursor = Cursors.WaitCursor;

            if (lvQuotes.SelectedItems.Count == 1)
            {
                string typQ = MainMDI.Find_One_Field("SELECT [Qtype] FROM [Orig_PSM_FDB].[dbo].[PSM_Q_IGen] where [i_Quoteid]=" + lvQuotes.SelectedItems[0].SubItems[4].Text);
                if (typQ == "3")
                {
                    edit_QuoteIII(lvQuotes.SelectedItems[0].SubItems[0].Text, lvQuotes.SelectedItems[0].SubItems[2].Text);
                    ref_QList(lvQuotes.SelectedItems[0].SubItems[4].Text, lvQuotes.SelectedItems[0].Index);
                }
                else
                {
                    if (typQ == "2")
                    {
                        edit_Quote(lvQuotes.SelectedItems[0].SubItems[0].Text, lvQuotes.SelectedItems[0].SubItems[2].Text);
                        ref_QList(lvQuotes.SelectedItems[0].SubItems[4].Text, lvQuotes.SelectedItems[0].Index);

                    }
                    else MessageBox.Show("Sorry Cannot open This Quote..........contact your Admin.....");

                }


            }

            this.Cursor = Cursors.Default;
        }

        private void Q3_Click(object sender, EventArgs e)
        {

            OpenQuote4();
            //Open_Quote23();
        }

        private void btnkill_Click(object sender, EventArgs e)
        {
            killseek = true;
        }

        /*
        private bool cpy_Quote(string OIQID,string CpnyID)
        {

            string stSql="SELECT * from  PSM_Q_IGen WHERE i_Quoteid=" + OIQID ;

            SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
            OConn.Open ();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql ;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read ())
            {
                    string stSql= "INSERT INTO PSM_Q_IGen ([Quote_ID],[CPNY_ID],[Employ_ID], " + 
                        " [ProjectName],[Opndate],[Clsdate],[Contact_ID],[Cust_Mult],  " + 
                        " [Term_ID],[Via_ID],[IncoTerm_ID], " + 
                        " [SI],[SO],[SE],[SP],[SS], " + 
                        " [AD],[AI],[AE],[AP],[AS], " + 
                        " [QA],[SA],[PA],[IA] , " + 
                        " [Lang]," +
                        " [DEL]," +" [IPmgr]," +" [CPmgr]," + " [curr]," +
                        " [Cmnt]) VALUES ('" +
                        Oreadr["Quote_ID"].ToString() + "', '" +
                        lCpnyID.Text    + "', '" +
                        Oreadr["Quote_ID"].ToString() + "', '" +
                        Oreadr["Quote_ID"].ToString().Replace("'","''")   + "', '" +
                        tOpendate.Text + "', '" +
                        "11/11/11" + "', '" +
                        lContact_ID.Text + "', '" +
                        Oreadr["Quote_ID"].ToString()+ "', '" +
                        lTerm_ID.Text + "', '" +
                        lVia_ID.Text + "', '" +
                        lIncoT_ID.Text + "', '" +
                        lSi.Text  + "', '" +
                        lSO.Text  + "', '" +
                        lSE.Text  + "', '" +
                        lSP.Text  + "', '" +
                        cbSS.Text + "', '" +
                        lAD.Text  + "', '" +
                        lAI.Text  + "', '" +
                        lAE.Text  + "', '" +
                        lAP.Text  + "', '" +
                        cbAS.Text + "', '" +
                        lQA.Text  + "', '" +
                        lSA.Text  + "', '" +
                        lPA.Text  + "', '" +
                        lIA.Text + "', '" +
                        lLang.Text  + "', '" +
                        lQstatus.Text    + "', '" + lIpmgr.Text   + "', '" + lCpmgr.Text   + "', '" + lcurDol.Text.Substring(0,1) + "', '" +
                        tGCmnt.Text   + "')";
                    t1 =  ExecSql(stSql);
                    lCurr_opera.Text  = "E";
                    string stId=MainMDI.Find_One_Field("select I_Quoteid from PSM_Q_IGen where Quote_ID=" + tQuoteID.Text + " AND CPNY_ID=" + lcpnyID.Text) ;   
                    //	MessageBox.Show("ID= " + MainMDI.stXP + "     foundID= " + stId  );  
                    if (stId!=MainMDI.VIDE ) lCurrIQID.Text = stId ; 
                    else MessageBox.Show("Error Occurs while Saving this Quote...contact your Admin !!!" + MainMDI.stXP  ); 
                }


*/






    }
		

}
