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
	/// Summary description for OR_ToSched.
	/// </summary>
	public class cedulo_ToSched : System.Windows.Forms.Form
    {
        //local var
        string LcurConflid = "", in_IRRevID = "", in_RID = "", in_CSTMR = "", SN = "", cur_CFTVA = "", DLVRD = "", lcurConfNm = "", 
            lCFLID = "";
        char in_EM = 'E';
        int LcurConfndx = -1, OLDTVConf_Selndx = -1, tsk_cur_ndx = -1, tsk_old_ndx = -1, ndx_pastTo= -1;
        string[,] arr_Tasks = new string[MainMDI.MAX_SC_TASKS, 5];
        string[,] arr_Tskscopy = new string[MainMDI.MAX_SC_TASKS, 3];
        string[] arr_cf_pastTo = new string[200];
        Color curr_clr = Color.LightGoldenrodYellow;
        string SP_Name = "", SCD_DETAIL_Name = "";
        //local var
        private static Lib1 Tools = new Lib1();

        private GroupBox groupBox3;
        private Button button1;
        private GroupBox grpConf;
        private Button button2;
        private GroupBox groupBox1;
        private ed_LVmodif ed_lvInfo;
        private ColumnHeader irrev;
        private ColumnHeader sys;
        private ColumnHeader Ival;
        private ColumnHeader tDura;
        private TreeView tvConfig;
        private GroupBox grpACF;
        private ToolStrip toolStrip1;
        private ToolStripButton tadd;
        public ListView lvCurConfig;
        private ToolStrip TSmain;
        private ToolStripButton disableSP;
        private ToolStripButton Save;
        private ToolStripButton Copy;
        private ColumnHeader Vdesc;
        private ColumnHeader Un;
        private ColumnHeader tva;
        private ToolStripTextBox C_txt;
        private ToolStripSeparator hhh;
        private DateTimePicker dpdlvrd;
        private ImageList imageList16;
        private ToolStripButton enbleSP;
        private ToolStripButton Past;
        private ToolStripButton xpnd;
        private ToolStripButton mov;
        private ColumnHeader TIlid;
        private DateTimePicker dp_datConvert;
        private ToolStripButton sc_exit;
        private ToolStripButton del_prj;
        private ToolStripLabel lSCDlid;
        private ColumnHeader sel;
        private IContainer components;

        public cedulo_ToSched(string x_RID, string x_IRRevID, string x_CSTMR, char x_EM)
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();
            in_IRRevID = x_IRRevID;
            in_RID = x_RID;
            in_CSTMR = x_CSTMR;
            in_EM = x_EM;
            string st = (in_EM == 'E') ? "ELECTRICAL" : "MECANICAL";
            this.Text = "                                                              " + st + " Schedule  (add / Modify ) ";
            curr_clr = (in_EM == 'E') ? Color.LightGoldenrodYellow : Color.Honeydew;
            ed_lvInfo.BackColor = curr_clr;
            SCD_DETAIL_Name = (in_EM == 'E') ? "PSM_R_SCD_Detail" : "PSM_R_SCD_Detail_Meca";

            //fill_TVConfig();
            //fill_TVConfigBIG();
            load_ALLCFs();
            init_arr_cf_pastTo();

			//
			//TODO : Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if(disposing)
				if(components != null) components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(cedulo_ToSched));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grpACF = new System.Windows.Forms.GroupBox();
            this.lvCurConfig = new System.Windows.Forms.ListView();
            this.Vdesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tva = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tadd = new System.Windows.Forms.ToolStripButton();
            this.hhh = new System.Windows.Forms.ToolStripSeparator();
            this.mov = new System.Windows.Forms.ToolStripButton();
            this.C_txt = new System.Windows.Forms.ToolStripTextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.ed_lvInfo = new PGESCOM.ed_LVmodif();
            this.sel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.irrev = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sys = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ival = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tDura = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Un = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TIlid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tvConfig = new System.Windows.Forms.TreeView();
            this.imageList16 = new System.Windows.Forms.ImageList(this.components);
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.grpConf = new System.Windows.Forms.GroupBox();
            this.dpdlvrd = new System.Windows.Forms.DateTimePicker();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.Save = new System.Windows.Forms.ToolStripButton();
            this.xpnd = new System.Windows.Forms.ToolStripButton();
            this.enbleSP = new System.Windows.Forms.ToolStripButton();
            this.disableSP = new System.Windows.Forms.ToolStripButton();
            this.Copy = new System.Windows.Forms.ToolStripButton();
            this.Past = new System.Windows.Forms.ToolStripButton();
            this.del_prj = new System.Windows.Forms.ToolStripButton();
            this.sc_exit = new System.Windows.Forms.ToolStripButton();
            this.lSCDlid = new System.Windows.Forms.ToolStripLabel();
            this.groupBox3.SuspendLayout();
            this.grpACF.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.grpConf.SuspendLayout();
            this.TSmain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grpACF);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 91);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1301, 474);
            this.groupBox3.TabIndex = 241;
            this.groupBox3.TabStop = false;
            // 
            // grpACF
            // 
            this.grpACF.Controls.Add(this.lvCurConfig);
            this.grpACF.Controls.Add(this.toolStrip1);
            this.grpACF.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpACF.Location = new System.Drawing.Point(883, 18);
            this.grpACF.Name = "grpACF";
            this.grpACF.Size = new System.Drawing.Size(415, 453);
            this.grpACF.TabIndex = 253;
            this.grpACF.TabStop = false;
            // 
            // lvCurConfig
            // 
            this.lvCurConfig.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvCurConfig.AutoArrange = false;
            this.lvCurConfig.BackColor = System.Drawing.Color.OldLace;
            this.lvCurConfig.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Vdesc,
            this.tva});
            this.lvCurConfig.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lvCurConfig.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvCurConfig.ForeColor = System.Drawing.Color.Black;
            this.lvCurConfig.FullRowSelect = true;
            this.lvCurConfig.GridLines = true;
            this.lvCurConfig.HideSelection = false;
            this.lvCurConfig.Location = new System.Drawing.Point(3, 87);
            this.lvCurConfig.Name = "lvCurConfig";
            this.lvCurConfig.ShowGroups = false;
            this.lvCurConfig.Size = new System.Drawing.Size(409, 363);
            this.lvCurConfig.TabIndex = 257;
            this.lvCurConfig.UseCompatibleStateImageBehavior = false;
            this.lvCurConfig.View = System.Windows.Forms.View.Details;
            this.lvCurConfig.SelectedIndexChanged += new System.EventHandler(this.lvCurConfig_SelectedIndexChanged);
            // 
            // Vdesc
            // 
            this.Vdesc.Text = "Description";
            this.Vdesc.Width = 301;
            // 
            // tva
            // 
            this.tva.Text = "TECH. Values";
            this.tva.Width = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.AutoSize = false;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tadd,
            this.hhh,
            this.mov,
            this.C_txt});
            this.toolStrip1.Location = new System.Drawing.Point(3, 18);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(409, 69);
            this.toolStrip1.TabIndex = 256;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tadd
            // 
            this.tadd.Image = ((System.Drawing.Image)(resources.GetObject("tadd.Image")));
            this.tadd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tadd.Name = "tadd";
            this.tadd.Size = new System.Drawing.Size(50, 66);
            this.tadd.Text = "Move";
            this.tadd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tadd.ToolTipText = "Move Content";
            this.tadd.Click += new System.EventHandler(this.tadd_Click);
            // 
            // hhh
            // 
            this.hhh.Name = "hhh";
            this.hhh.Size = new System.Drawing.Size(6, 69);
            // 
            // mov
            // 
            this.mov.Image = ((System.Drawing.Image)(resources.GetObject("mov.Image")));
            this.mov.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.mov.Name = "mov";
            this.mov.Size = new System.Drawing.Size(45, 66);
            this.mov.Text = "Add ";
            this.mov.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.mov.ToolTipText = "Add to Content";
            this.mov.Click += new System.EventHandler(this.mov_Click);
            // 
            // C_txt
            // 
            this.C_txt.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.C_txt.Name = "C_txt";
            this.C_txt.Size = new System.Drawing.Size(240, 69);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.ed_lvInfo);
            this.groupBox1.Controls.Add(this.tvConfig);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(880, 453);
            this.groupBox1.TabIndex = 252;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Projects";
            // 
            // ed_lvInfo
            // 
            this.ed_lvInfo.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvInfo.AutoArrange = false;
            this.ed_lvInfo.BackColor = System.Drawing.Color.LightGoldenrodYellow;
            this.ed_lvInfo.CheckBoxes = true;
            this.ed_lvInfo.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sel,
            this.irrev,
            this.sys,
            this.Ival,
            this.tDura,
            this.Un,
            this.TIlid});
            this.ed_lvInfo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_lvInfo.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvInfo.ForeColor = System.Drawing.Color.Black;
            this.ed_lvInfo.FullRowSelect = true;
            this.ed_lvInfo.GridLines = true;
            this.ed_lvInfo.HideSelection = false;
            this.ed_lvInfo.Location = new System.Drawing.Point(327, 18);
            this.ed_lvInfo.Name = "ed_lvInfo";
            this.ed_lvInfo.Size = new System.Drawing.Size(550, 432);
            this.ed_lvInfo.TabIndex = 247;
            this.ed_lvInfo.UseCompatibleStateImageBehavior = false;
            this.ed_lvInfo.View = System.Windows.Forms.View.Details;
            this.ed_lvInfo.SelectedIndexChanged += new System.EventHandler(this.ed_lvInfo_SelectedIndexChanged);
            this.ed_lvInfo.DoubleClick += new System.EventHandler(this.ed_lvInfo_DoubleClick);
            // 
            // sel
            // 
            this.sel.DisplayIndex = 6;
            this.sel.Text = "select";
            this.sel.Width = 10;
            // 
            // irrev
            // 
            this.irrev.DisplayIndex = 0;
            this.irrev.Text = "";
            this.irrev.Width = 0;
            // 
            // sys
            // 
            this.sys.DisplayIndex = 1;
            this.sys.Text = "System SN";
            this.sys.Width = 132;
            // 
            // Ival
            // 
            this.Ival.DisplayIndex = 2;
            this.Ival.Text = "Value";
            this.Ival.Width = 350;
            // 
            // tDura
            // 
            this.tDura.DisplayIndex = 3;
            this.tDura.Text = "Duration";
            this.tDura.Width = 0;
            // 
            // Un
            // 
            this.Un.DisplayIndex = 4;
            this.Un.Text = "Unit";
            this.Un.Width = 0;
            // 
            // TIlid
            // 
            this.TIlid.DisplayIndex = 5;
            this.TIlid.Text = "";
            this.TIlid.Width = 0;
            // 
            // tvConfig
            // 
            this.tvConfig.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tvConfig.Dock = System.Windows.Forms.DockStyle.Left;
            this.tvConfig.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvConfig.ForeColor = System.Drawing.Color.Blue;
            this.tvConfig.FullRowSelect = true;
            this.tvConfig.ImageIndex = 0;
            this.tvConfig.ImageList = this.imageList16;
            this.tvConfig.LabelEdit = true;
            this.tvConfig.Location = new System.Drawing.Point(3, 18);
            this.tvConfig.Name = "tvConfig";
            this.tvConfig.SelectedImageIndex = 0;
            this.tvConfig.Size = new System.Drawing.Size(324, 432);
            this.tvConfig.TabIndex = 246;
            this.tvConfig.AfterCheck += new System.Windows.Forms.TreeViewEventHandler(this.tvConfig_AfterCheck);
            this.tvConfig.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvConfig_AfterSelect);
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
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(204, 67);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(86, 28);
            this.button2.TabIndex = 243;
            this.button2.Text = "config";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(50, 67);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(87, 28);
            this.button1.TabIndex = 1;
            this.button1.Text = "fill";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grpConf
            // 
            this.grpConf.Controls.Add(this.dpdlvrd);
            this.grpConf.Controls.Add(this.TSmain);
            this.grpConf.Controls.Add(this.button1);
            this.grpConf.Controls.Add(this.button2);
            this.grpConf.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConf.Location = new System.Drawing.Point(0, 0);
            this.grpConf.Name = "grpConf";
            this.grpConf.Size = new System.Drawing.Size(1301, 91);
            this.grpConf.TabIndex = 240;
            this.grpConf.TabStop = false;
            // 
            // dpdlvrd
            // 
            this.dpdlvrd.Location = new System.Drawing.Point(944, 38);
            this.dpdlvrd.Name = "dpdlvrd";
            this.dpdlvrd.Size = new System.Drawing.Size(98, 22);
            this.dpdlvrd.TabIndex = 258;
            this.dpdlvrd.Visible = false;
            // 
            // TSmain
            // 
            this.TSmain.AutoSize = false;
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Save,
            this.xpnd,
            this.enbleSP,
            this.disableSP,
            this.Copy,
            this.Past,
            this.del_prj,
            this.sc_exit,
            this.lSCDlid});
            this.TSmain.Location = new System.Drawing.Point(3, 18);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(1295, 69);
            this.TSmain.TabIndex = 257;
            this.TSmain.Text = "toolStrip2";
            // 
            // Save
            // 
            this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
            this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(44, 66);
            this.Save.Text = "Save";
            this.Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Save.ToolTipText = "Save sub-project";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // xpnd
            // 
            this.xpnd.Image = ((System.Drawing.Image)(resources.GetObject("xpnd.Image")));
            this.xpnd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.xpnd.Name = "xpnd";
            this.xpnd.Size = new System.Drawing.Size(82, 66);
            this.xpnd.Text = "Expand all";
            this.xpnd.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.xpnd.Click += new System.EventHandler(this.xpnd_Click);
            // 
            // enbleSP
            // 
            this.enbleSP.Image = ((System.Drawing.Image)(resources.GetObject("enbleSP.Image")));
            this.enbleSP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.enbleSP.Name = "enbleSP";
            this.enbleSP.Size = new System.Drawing.Size(58, 66);
            this.enbleSP.Text = "Enable";
            this.enbleSP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.enbleSP.ToolTipText = "Enable sub-project";
            this.enbleSP.Visible = false;
            this.enbleSP.Click += new System.EventHandler(this.enbleSP_Click);
            // 
            // disableSP
            // 
            this.disableSP.Image = ((System.Drawing.Image)(resources.GetObject("disableSP.Image")));
            this.disableSP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.disableSP.Name = "disableSP";
            this.disableSP.Size = new System.Drawing.Size(63, 66);
            this.disableSP.Text = "Disable";
            this.disableSP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.disableSP.ToolTipText = "Disable sub-project";
            this.disableSP.Visible = false;
            this.disableSP.Click += new System.EventHandler(this.disableSP_Click);
            // 
            // Copy
            // 
            this.Copy.Image = ((System.Drawing.Image)(resources.GetObject("Copy.Image")));
            this.Copy.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Copy.Name = "Copy";
            this.Copy.Size = new System.Drawing.Size(94, 66);
            this.Copy.Text = "Copy Profile";
            this.Copy.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Copy.ToolTipText = "Copy tasks Values/Durations";
            this.Copy.Click += new System.EventHandler(this.Copy_Click);
            // 
            // Past
            // 
            this.Past.Enabled = false;
            this.Past.Image = ((System.Drawing.Image)(resources.GetObject("Past.Image")));
            this.Past.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Past.Name = "Past";
            this.Past.Size = new System.Drawing.Size(86, 66);
            this.Past.Text = "Past Profile";
            this.Past.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Past.ToolTipText = "Past Tasks values/Durations";
            this.Past.Click += new System.EventHandler(this.Past_Click);
            // 
            // del_prj
            // 
            this.del_prj.Image = ((System.Drawing.Image)(resources.GetObject("del_prj.Image")));
            this.del_prj.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del_prj.Name = "del_prj";
            this.del_prj.Size = new System.Drawing.Size(118, 66);
            this.del_prj.Text = "Remove project";
            this.del_prj.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.del_prj.ToolTipText = "Remove Project from Schedule";
            this.del_prj.Visible = false;
            this.del_prj.Click += new System.EventHandler(this.del_prj_Click);
            // 
            // sc_exit
            // 
            this.sc_exit.Image = ((System.Drawing.Image)(resources.GetObject("sc_exit.Image")));
            this.sc_exit.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.sc_exit.Name = "sc_exit";
            this.sc_exit.Size = new System.Drawing.Size(61, 66);
            this.sc_exit.Text = "   Exit   ";
            this.sc_exit.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.sc_exit.Click += new System.EventHandler(this.sc_exit_Click);
            // 
            // lSCDlid
            // 
            this.lSCDlid.BackColor = System.Drawing.Color.Bisque;
            this.lSCDlid.Name = "lSCDlid";
            this.lSCDlid.Size = new System.Drawing.Size(0, 66);
            // 
            // cedulo_ToSched
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.ClientSize = new System.Drawing.Size(1301, 565);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpConf);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "cedulo_ToSched";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Project Schedule";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.OR_ToSched_Load);
            this.groupBox3.ResumeLayout(false);
            this.grpACF.ResumeLayout(false);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.grpConf.ResumeLayout(false);
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

		private void dataGrid1_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
		{
		
		}

        private void load_ALLCFs()
        {
            //this.Cursor = Cursors.WaitCursor;
            string stSql = " SELECT " + SCD_DETAIL_Name + ".sc_det_LID" +
                " FROM  PSM_R_SCD_INFO INNER JOIN " + SCD_DETAIL_Name + " ON PSM_R_SCD_INFO.sc_LID = " + SCD_DETAIL_Name + ".d_sc_LID " +
                " WHERE  PSM_R_SCD_INFO.sc_IREVID =" + in_IRRevID;
            if (MainMDI.Find_One_Field(stSql) == MainMDI.VIDE)
            {
                fill_arr_Tasks();
                New_All_SCD();
            }
            else fill_TVConfigBIG();
            //this.Cursor = Cursors.WaitCursor;
        }

        private void init_arr_cf_pastTo()
        {
            for (int i = 0; i < 200; i++) arr_cf_pastTo[i] = "";
        }

        private void fill_dgTasks()
		{
            /*
			string strSql = "";
		    //int intSkip = 0;
		    //intSkip = (this.mintCurrentPage * this.mintPageSize);

			//Select only the n records.
			strSql = "SELECT * FROM PSM_R_Shed_Tasks ";
			SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
			OConn.Open();
			SqlCommand cmd = OConn.CreateCommand();
			cmd.CommandText = strSql;
			SqlDataAdapter da = new SqlDataAdapter(cmd);
			DataSet ds = new DataSet();

            da.Fill(ds, "toto"); //PSM_R_Shed_Tasks");
            ds.Tables[0].Columns[0].ColumnMapping = MappingType.Hidden;
		    this.dgSched.DataSource = ds.Tables[0].DefaultView; //PSM_R_Shed_Tasks"].DefaultView;

            //DataGridTableStyle tbs = dgSched.TableStyles[0];
            //tbs.GridColumnStyles[0].Width = 0;
            ///dgSched.Refresh();
            //dgSched.TableStyles[0].

			//Show Status
		    //this.lblStatus.Text = (this.mintCurrentPage + 1).ToString() + " / " + this.mintPageCount.ToString();
 
			cmd.Dispose();
			da.Dispose();
			ds.Dispose();
            * */
		}

        private void init_ITasks()
        {
            ed_lvInfo.Items.Clear();
            cur_CFTVA = "";
        }

        private void fill_arr_Tasks()
        {
            for (int i = 0; i < MainMDI.MAX_SC_TASKS; i++)
                for (int j = 0; j < 4; j++) arr_Tasks[i, j] = "";

            string stSql = "SELECT *  FROM PSM_R_SCD_ITasks where used=1 ORDER BY ti_rnk  ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int ti = 0;
            while (Oreadr.Read())
            {
                arr_Tasks[ti, 0] = Oreadr["ti_LID"].ToString();
                //arr_Tasks[ti, 1] = Oreadr["ti_Desc"].ToString();
                arr_Tasks[ti, 1] = Oreadr["ti_Value"].ToString();
                arr_Tasks[ti, 2] = Oreadr["ti_dura"].ToString();
                arr_Tasks[ti, 3] = Oreadr["ti_duraUn"].ToString();
                arr_Tasks[ti++, 4] = Oreadr["ti_rnk"].ToString();
            }
            OConn.Close();
        }

        private void New_All_SCD()
        {
            string Nstm = "", Ostm = "", Ncf = "", _dlvD="";
            tvConfig.Nodes.Clear();
            lvCurConfig.Items.Clear();
            string stSql = " SELECT   PSM_R_RevSys.R_sysName, PSM_R_CFinfo.c_SN,PSM_R_CFinfo.CFLID, PSM_R_CFinfo.ConfigNm" +
                " FROM PSM_R_CFinfo INNER JOIN PSM_R_Detail ON PSM_R_CFinfo.c_SN = PSM_R_Detail.PrimaxSN AND PSM_R_CFinfo.c_RRevLID = PSM_R_Detail.IRRev_LID" +
                "        INNER JOIN PSM_R_RevSys ON PSM_R_Detail.IRRev_LID = PSM_R_RevSys.IRRev_LID AND PSM_R_Detail.SysLID = PSM_R_RevSys.R_sysLID " +
                " WHERE   (PSM_R_CFinfo.c_SN LIKE '%S%'  OR PSM_R_CFinfo.c_SN LIKE '%G9%'  )  AND PSM_R_RevSys.IRRev_LID =" + in_IRRevID +
                " ORDER BY PSM_R_RevSys.IRRev_LID, PSM_R_RevSys.R_sysRnk ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                //tvConfig.Nodes.Add(Oreadr["R_sysName"].ToString() + "..." + Oreadr["ConfigNm"].ToString());

                Nstm = Oreadr["R_sysName"].ToString();
                Ncf = Oreadr["ConfigNm"].ToString();
                _dlvD = Oreadr["CFLID"].ToString();

                if (Nstm != Ostm)
                {
                    tvConfig.Nodes.Add(Nstm); //Sysstem node
                    tvConfig.Nodes[tvConfig.Nodes.Count - 1].ImageIndex = 1;
                    tvConfig.Nodes[tvConfig.Nodes.Count - 1].SelectedImageIndex = 7; //3
                    Ostm = Nstm;
                    //add_Sys(s, Oreadr["R_sysName"].ToString());
                }
                //seek CFTVA
                stSql = MainMDI.Find_One_Field(" SELECT PSM_R_CFDetail.cf_tecVal" +
                    " FROM  PSM_R_CFDetail INNER JOIN  PSM_R_CFinfo ON PSM_R_CFDetail.d_CFLID = PSM_R_CFinfo.CFLID " +
                    " WHERE     PSM_R_CFinfo.ConfigNm = '" + Ncf + "' AND PSM_R_CFinfo.c_RRevLID =" + in_IRRevID + " AND PSM_R_CFDetail.cf_tecVal LIKE '%C_MODEL||%'" +
                    " ORDER BY PSM_R_CFDetail.d_Rnk ");
                cur_CFTVA = (stSql != MainMDI.VIDE) ? stSql : "";
                Fill_CurConf(Ncf, false);
                TVConfig_AddCFxxx(Ncf, true); //(Oreadr["R_sysName"].ToString());

                XW_TSK_info(Nstm, Ncf, _dlvD, LcurConfndx);
                //tvConfig.Nodes[tvConfig.Nodes.Count - 1].ImageIndex = 0;
                //tvConfig.Nodes[tvConfig.Nodes.Count - 1].Nodes[SelectedImageIndex = 2;
            }
            OConn.Close();
        }

        private void XW_TSK_info(string Nstm, string Ncf, string _dlvD, int rnk)
        {
            long lid = -1;
            string scdID = MainMDI.Find_One_Field(" SELECT sc_LID  FROM PSM_R_SCD_INFO where sc_SysName='" + Nstm + "' and sc_Name='" + Ncf + 
                "' and sc_IREVID=" + in_IRRevID + " and sc_status=1 and sc_CF_LID=" + _dlvD);

            if (scdID == MainMDI.VIDE)
            {
                lid = XSP_NSRT_SCD_INFO(Nstm, Ncf, in_IRRevID, "1", _dlvD, rnk.ToString());
                scdID = lid.ToString();
            }
            for (int i = 0; i < arr_Tasks.Length; i++)
            {
                if (arr_Tasks[i, 0] != "")
                {
                    string st = arr_Tasks[i, 1];
                    if (st[0] == '!') st = Ntrn_CFTVA(st.Substring(1, st.Length - 1));
                    long d_lid = XSP_NSRT_SCD_Detail(scdID, arr_Tasks[i, 0], st, arr_Tasks[i, 2], arr_Tasks[i, 4]);
                }
                else i = arr_Tasks.Length;
            }
            //arr_Tasks[ti, 0] = Oreadr["ti_LID"].ToString();
            //arr_Tasks[ti, 1] = Oreadr["ti_Value"].ToString();
            //arr_Tasks[ti, 2] = Oreadr["ti_dura"].ToString();
            //arr_Tasks[ti, 3] = Oreadr["ti_duraUn"].ToString();
            //arr_Tasks[ti++, 4] = Oreadr["ti_rnk"].ToString();
        }

        //stored procedure
        private long XSP_NSRT_SCD_Detail(string d_sc_LID, string scd_TILID, string scd_Value, string scd_dura, string scd_Rnk)
        {
            SP_Name = (in_EM == 'E') ? "NSRT_SCD_Detail" : "NSRT_SCD_Detail_Meca";
            string LID = "-1";
            string stXP = "";
            try
            {
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = new SqlCommand(SP_Name, OConn);
                Ocmd.CommandType = CommandType.StoredProcedure;

                Ocmd.Parameters.AddWithValue("@d_sc_LID", d_sc_LID);
                Ocmd.Parameters.AddWithValue("@scd_TILID", scd_TILID); //lid a ajouter.....
                Ocmd.Parameters.AddWithValue("@scd_Value", scd_Value);
                Ocmd.Parameters.AddWithValue("@scd_dura", scd_dura);
                Ocmd.Parameters.AddWithValue("@scd_Rnk", scd_Rnk);

                //LID = Ocmd.exe;
                SqlDataReader rdr = Ocmd.ExecuteReader();
                while (rdr.Read()) 
                    LID = rdr[0].ToString();
                OConn.Close();
                stXP = MainMDI.VIDE;
                MainMDI.Write_JFS("XSP_NSRT_SCD_Detail: " + Ocmd.Parameters.ToString());
                return Int64.Parse(LID);
            }
            catch (SqlException Oexp)
            {
                stXP = Oexp.Message;
                MessageBox.Show("XSP NSRT_SCD_Detail \n" + "Msg= " + stXP);
                return -1;
            }
        }

        private long XSP_NSRT_SCD_INFO(string sc_SysName, string sc_Name, string sc_IREVID, string sc_status, string _dlvD, string sc_Rnk)
        {
            string LID = "-1";
            string stXP = "";
            try
            {
                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = new SqlCommand("NSRT_SCD_INFO", OConn);
                Ocmd.CommandType = CommandType.StoredProcedure;

                Ocmd.Parameters.AddWithValue("@sc_SysName", sc_SysName);
                Ocmd.Parameters.AddWithValue("@sc_Name", sc_Name);
                Ocmd.Parameters.AddWithValue("@sc_CF_LID", _dlvD);
                Ocmd.Parameters.AddWithValue("@sc_IREVID", sc_IREVID);
                Ocmd.Parameters.AddWithValue("@sc_status", sc_status);
                Ocmd.Parameters.AddWithValue("@sc_Rnk", sc_Rnk);

                //LID = Ocmd.exe;
                SqlDataReader rdr = Ocmd.ExecuteReader();
                while (rdr.Read()) 
                    LID = rdr[0].ToString();
                OConn.Close();
                stXP = MainMDI.VIDE;
                MainMDI.Write_JFS("XSP_NSRT_SCD_INFO: " + Ocmd.Parameters.ToString());
                return Int64.Parse(LID);
            }
            catch (SqlException Oexp)
            {
                stXP = Oexp.Message;
                MessageBox.Show("XSP NSRT_SCD_INFO \n" + "Msg= " + stXP);
                return -1;
            }
        }

        private void Fill_CurConf(string _cCF, bool fill_lv)
        {
            if (fill_lv) lvCurConfig.Items.Clear();

            string stSql = "SELECT     PSM_R_CFDetail.*, PSM_R_CFinfo.*" +
                " FROM  PSM_R_CFDetail INNER JOIN  PSM_R_CFinfo ON PSM_R_CFDetail.d_CFLID = PSM_R_CFinfo.CFLID " +
                " WHERE     PSM_R_CFinfo.ConfigNm = '" + _cCF + "' AND PSM_R_CFinfo.c_RRevLID =" + in_IRRevID + 
                " ORDER BY PSM_R_CFDetail.d_Rnk ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            bool filled = false;
            while (Oreadr.Read())
            {
                if (!filled)
                {
                    lCFLID = Oreadr["CFLID"].ToString();
                    SN = Oreadr["c_SN"].ToString();
                    dpdlvrd.Text = Oreadr["c_datDlvr"].ToString();
                    //dpdlvrd.Text = Oreadr["dateManufac"].ToString();

                    DLVRD = dpdlvrd.Value.ToShortDateString();
                    filled = true;
                    if (!fill_lv) break;
                }
                ListViewItem lv = lvCurConfig.Items.Add(Oreadr["d_ItemDesc"].ToString());
                lv.SubItems.Add(Oreadr["cf_tecVal"].ToString());
                if (Oreadr["cf_tecVal"].ToString().IndexOf("C_MODEL") > -1) cur_CFTVA = Oreadr["cf_tecVal"].ToString();
            }
            OConn.Close();
        }

        string findTIME_STD_OPT(int PAN_CAB, int STD_OPT, string sc_LID)
        {
            double res = 0;

            string tblNM = (STD_OPT == 1) ? " PSM_R_SCD_Detail_STD " : " PSM_R_SCD_Detail_Options ";
            string stsql = "SELECT sum([dura])  FROM " + tblNM + " where sc_LID=" + sc_LID + " and sc_Pnl_Cab=" + PAN_CAB;
            res = Tools.Conv_Dbl(MainMDI.Find_One_Field(stsql));

            return res.ToString();
        }

        string CAL_TIME(int pnl_cab, string Sc_LID)
        {
            double dd = (pnl_cab == 1) ? 
                dd = Tools.Conv_Dbl(findTIME_STD_OPT(1, 1, Sc_LID)) + Tools.Conv_Dbl(findTIME_STD_OPT(1, 2, Sc_LID)) : 
                Tools.Conv_Dbl(findTIME_STD_OPT(2, 1, Sc_LID)) + Tools.Conv_Dbl(findTIME_STD_OPT(2, 2, Sc_LID));

            return dd.ToString();
        }

        private void fill_lvTasks()
        {
            string stSql = " SELECT     PSM_R_SCD_INFO.sc_LID, PSM_R_SCD_INFO.sc_SysName, PSM_R_SCD_INFO.sc_Name, PSM_R_SCD_INFO.sc_status, " + SCD_DETAIL_Name + ".* , PSM_R_SCD_ITasks.ti_editable, PSM_R_SCD_ITasks.ti_Desc, PSM_R_SCD_ITasks.ti_duraUn " +
                " FROM         PSM_R_SCD_INFO INNER JOIN " + SCD_DETAIL_Name + " ON PSM_R_SCD_INFO.sc_LID = " + SCD_DETAIL_Name + ".d_sc_LID INNER JOIN " +
                "              PSM_R_SCD_ITasks ON " + SCD_DETAIL_Name + ".scd_TILID = PSM_R_SCD_ITasks.ti_LID " +
                " WHERE     PSM_R_SCD_INFO.sc_IREVID =" + in_IRRevID + " AND PSM_R_SCD_INFO.sc_Name ='" + lcurConfNm + "'" +
                " ORDER BY PSM_R_SCD_INFO.sc_Rnk, PSM_R_SCD_ITasks.ti_rnk, " + SCD_DETAIL_Name + ".scd_Rnk ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvInfo.Items.Add(Oreadr["sc_det_LID"].ToString());
                lv.SubItems.Add(Oreadr["ti_Desc"].ToString());

                lv.SubItems.Add(Oreadr["scd_Value"].ToString());
                lv.SubItems.Add(Oreadr["scd_dura"].ToString());
                lv.SubItems.Add(Oreadr["ti_duraUn"].ToString());
                lv.SubItems.Add(Oreadr["scd_TILID"].ToString());
                LcurConflid = Oreadr["sc_LID"].ToString();
                lv.BackColor = (Oreadr["ti_editable"].ToString() == "0") ? Color.Moccasin : curr_clr; //Color.WhiteSmoke; //0 = by default must be calculated if not quote is bad....error

                if (Oreadr["ti_Desc"].ToString() == "Cabinet duration" || Oreadr["ti_Desc"].ToString() == "Panel duration")
                {
                    ListViewItem lvv = ed_lvInfo.Items.Add("0");
                    lvv.SubItems.Add("Estimated Time");

                    if (Oreadr["ti_Desc"].ToString() == "Panel duration") lvv.SubItems.Add(CAL_TIME(1, Oreadr["sc_LID"].ToString()));
                    else lvv.SubItems.Add(CAL_TIME(2, LcurConflid));
                    lvv.SubItems.Add(" ");
                    lvv.SubItems.Add(" ");
                    lvv.SubItems.Add(" ");
                    lvv.SubItems.Add(" ");
                    lvv.BackColor = Color.Moccasin;
                }
            }
            lSCDlid.Text = LcurConflid;
            OConn.Close();
            //ed_lvInfo.AddEditableCell(-1, 2);
            //ed_lvInfo.AddEditableCell(-1, 3);
        }

        private void fill_lvTasks_oldFashion()
        {
            string stSql = "SELECT *  FROM PSM_R_SCD_ITasks ORDER BY ti_rnk ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvInfo.Items.Add(Oreadr["ti_LID"].ToString());
                lv.SubItems.Add(Oreadr["ti_Desc"].ToString());
                string st = Oreadr["ti_Value"].ToString();
                if (st[0] == '!') lv.SubItems.Add(Ntrn_CFTVA(st.Substring(1, st.Length - 1)));
                else lv.SubItems.Add(st);
                lv.SubItems.Add(Oreadr["ti_dura"].ToString());
                lv.SubItems.Add(Oreadr["ti_duraUn"].ToString());
            }
            OConn.Close();
            ed_lvInfo.AddEditableCell(-1, 2);
            ed_lvInfo.AddEditableCell(-1, 3);
        }

        private string Ntrn_CFTVA(string x_TVA)
        {
            string st = "";
            TestEQA TEA = new TestEQA(cur_CFTVA);
            string res = MainMDI.VIDE;
            if (x_TVA.Substring(0, 2) == "S_" || x_TVA.Substring(0, 2) == "C_" || x_TVA.Substring(0, 2) == "B_")
            {
                switch (x_TVA)
                {
                    case "Z_":
                        res = "0";
                        //MainMDI.Find_One_Field("SELECT PSM_SALES_AGENTS.FL FROM PSM_R_Rev INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID " +
                            //" WHERE     PSM_R_Rev.IRRevID =" + in_IRRevID);
                        break;
                    case "B_":
                        res = " ";
                        //MainMDI.Find_One_Field("SELECT PSM_SALES_AGENTS.FL FROM PSM_R_Rev INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID " +
                            //" WHERE     PSM_R_Rev.IRRevID =" + in_IRRevID);
                        break;
                    case "S_SALES":
                        res = MainMDI.Find_One_Field("SELECT PSM_SALES_AGENTS.FL" +
                            " FROM PSM_R_Rev INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid" +
                            "        INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID " +
                            " WHERE     PSM_R_Rev.IRRevID =" + in_IRRevID);
                        break;
                    case "S_PRJNB":
                        res = MainMDI.Find_One_Field("SELECT PSM_R_Rev.RID" +
                            " FROM PSM_R_Rev INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid" +
                            "        INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID " +
                            " WHERE     PSM_R_Rev.IRRevID =" + in_IRRevID);
                        break;
                    case "S_PONB":
                        res = MainMDI.Find_One_Field("SELECT PSM_R_Rev.Custm_PO" +
                            " FROM PSM_R_Rev INNER JOIN PSM_Q_IGen ON PSM_R_Rev.iQID = PSM_Q_IGen.i_Quoteid" +
                            "        INNER JOIN PSM_SALES_AGENTS ON PSM_Q_IGen.Employ_ID = PSM_SALES_AGENTS.SA_ID " +
                            " WHERE     PSM_R_Rev.IRRevID =" + in_IRRevID);
                        break;
                    case "S_CUSTMR":
                        res = in_CSTMR;
                        break;
                    case "S_SN":
                        res = SN;
                        break;
                    case "S_VPH":
                        st = TEA.look_Req_Value("C_VAC", cur_CFTVA, 'C');
                        res = (st == "???") ? res = MainMDI.VIDE : 
                            st + "VAC/" + TEA.look_Req_Value("U_PHASE", cur_CFTVA, 'C') + "PH/" + TEA.look_Req_Value("FHZ", cur_CFTVA, 'C') + 
                            "HZ";
                        break;
                    case "S_IDC":
                        st = TEA.look_Req_Value("U_IDC", cur_CFTVA, 'C');
                        res = (st == "???") ? res = MainMDI.VIDE : st; //+ "VAC/" + TEA.look_Req_Value("U_PHASE", cur_CFTVA, 'C') + "PH/" + TEA.look_Req_Value("FHZ", cur_CFTVA, 'C') + "HZ";
                        break;
                    case "S_DLVRD":
                        //res = DLVRD; //modified to manufacDate on 25/09/2008
                        res = DLVRD.Substring(6, 4) + "/" + DLVRD.Substring(3, 2) + "/" + DLVRD.Substring(0, 2);
                        break;
                    case "S_INVDT": //real shipping date
                        //dpdlvrd.Text = MainMDI.Find_One_Field("SELECT PSM_R_Rev.dateRRev FROM PSM_R_Rev WHERE     PSM_R_Rev.IRRevID =" + in_IRRevID);
                        //res = dpdlvrd.Value.ToShortDateString();
                        //dpdlvrd.Text = "01/01/1900";
                        //res = dpdlvrd.Value.ToShortDateString();
                        res = "N/S";

                        //double dd = nbWeek * 7;
                        //dpDelvdate.Text = dpDelvdate.Value.AddDays(dd).ToShortDateString();
                        //dpDelvdate.Text = tRRevDate.Value.ToShortDateString(); //Delvdate.Value.AddDays(dd).ToShortDateString();
                        break;
                    default:
                        st = TEA.look_Req_Value(x_TVA, cur_CFTVA, 'C');
                        res = (st == "???") ? MainMDI.VIDE : st;
                        break;
                }
            }
            return res;
        }

		private void button1_Click(object sender, System.EventArgs e)
		{
			//fill_dgTasks();
            //ed_lvInfo.AddSubItem = true;

            fill_lvTasks();

            ////Set the combobox
            //StringCollection grades = new StringCollection();
            //grades.AddRange(new string[] { "A", "B", "C", "D", "E" });
            //this.listViewMain.AddComboBoxCell(-1, 1, grades);
		}

        private void load_CurConf()
        {
            /*
             * 
            string stSql = "SELECT     PSM_R_CFDetail.*, PSM_R_CFinfo.* FROM  PSM_R_CFDetail INNER JOIN  PSM_R_CFinfo ON PSM_R_CFDetail.d_CFLID = PSM_R_CFinfo.CFLID " +
                " WHERE     PSM_R_CFinfo.ConfigNm = '" + lcurConfNm.Text + "' AND PSM_R_CFinfo.c_RRevLID =" + lIRRevID.Text + " ORDER BY PSM_R_CFDetail.d_Rnk ";
            SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            bool filled = false;
            string Edrw = "", Mdrw = "", r_Bom = "";
            while (Oreadr.Read())
            {
                lCFLID.Text = Oreadr["CFLID"].ToString();
                ListViewItem lv = lvCurConfig.Items.Add(""); lv.Checked = true;
                lv.SubItems.Add(Oreadr["d_ItemDesc"].ToString());
                if (NBst("~~", Oreadr["DWGnb"].ToString()) == 3)
                    get_XDRW(Oreadr["DWGnb"].ToString(), ref Edrw, ref Mdrw, ref r_Bom);
                else
                {
                    Edrw = get_DRW(Oreadr["DWGnb"].ToString());
                    Mdrw = "";
                    r_Bom = "";
                }
                lv.SubItems.Add(Edrw);
                lv.SubItems.Add(Oreadr["CfDet_LID"].ToString());
                lv.SubItems.Add(Mdrw);
                lv.SubItems.Add(r_Bom);
                lv.SubItems.Add(Oreadr["cf_tecVal"].ToString());

                if (!filled)
                {
                    dpCFdlvr.Visible = false;
                    dpConfig.Visible = false;
                    lSn.Text = Oreadr["c_SN"].ToString();
                    dpConfig.Text = Oreadr["c_date"].ToString();

                    tRRevDate2.Text = Oreadr["c_datapp"].ToString();
                    if (tRRevDate2.Text == "01/01/1900") tRRevDate2.Text = tRRevDate.Text;

                    dpCFdlvr.Text = Oreadr["c_datDlvr"].ToString();
                    if (dpCFdlvr.Text == "01/01/1900") dpCFdlvr.Text = dpDelvdate.Text;

                    //dpConfig.Visible = false;
                    picLock.Visible = (Oreadr["c_sta"].ToString() == "0");
                    picUnlock.Visible = (Oreadr["c_sta"].ToString() == "1");
                    filled = true;
                }
            }
            OConn.Close();
            */
        }

        private void visible_ede()
        {
            del_prj.Visible = (MainMDI.User.ToLower() == "ede"); //(MainMDI.User.ToLower() == "ede");
        }

        private void OR_ToSched_Load(object sender, EventArgs e)
        {
            //groupBox1.Width = 750;
            //tvConfig.Width = 455; /$%*&?%????

            //this.Refresh();
            visible_ede();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void fill_TVConfig()
        {
            tvConfig.Nodes.Clear();
            lvCurConfig.Items.Clear();
            string stSql = "SELECT ConfigNm  from PSM_R_CFinfo where c_RRevLID=" + in_IRRevID;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read()) 
                tvConfig.Nodes.Add(Oreadr["ConfigNm"].ToString());
            OConn.Close();
        }

        private void fill_TVConfigBIG()
        {
            string Nstm = "", Ostm = "", Ncf = "";
            tvConfig.Nodes.Clear();
            lvCurConfig.Items.Clear();
            string stSql = "SELECT sc_SysName , sc_Name, sc_status FROM PSM_R_SCD_INFO WHERE sc_IREVID =" + in_IRRevID + 
                " ORDER BY sc_Name, sc_Rnk ";
            //SELECT   PSM_R_RevSys.R_sysName, PSM_R_CFinfo.c_SN, PSM_R_CFinfo.ConfigNm FROM PSM_R_CFinfo INNER JOIN " +
                //"         PSM_R_Detail ON PSM_R_CFinfo.c_SN = PSM_R_Detail.PrimaxSN AND PSM_R_CFinfo.c_RRevLID = PSM_R_Detail.IRRev_LID INNER JOIN PSM_R_RevSys ON PSM_R_Detail.IRRev_LID = PSM_R_RevSys.IRRev_LID AND PSM_R_Detail.SysLID = PSM_R_RevSys.R_sysLID " +
                //" WHERE   PSM_R_CFinfo.c_SN LIKE '%S%' AND PSM_R_RevSys.IRRev_LID =" + in_IRRevID +
                //" ORDER BY PSM_R_RevSys.IRRev_LID, PSM_R_RevSys.R_sysRnk ";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                //tvConfig.Nodes.Add(Oreadr["R_sysName"].ToString() + "..." + Oreadr["ConfigNm"].ToString());

                Nstm = Oreadr["sc_SysName"].ToString();
                Ncf = Oreadr["sc_Name"].ToString();

                if (Nstm != Ostm)
                {
                    tvConfig.Nodes.Add(Nstm); //Sysstem node
                    tvConfig.Nodes[tvConfig.Nodes.Count - 1].ImageIndex = 1;
                    tvConfig.Nodes[tvConfig.Nodes.Count - 1].SelectedImageIndex = 7; //3
                    Ostm = Nstm;
                    //add_Sys(s, Oreadr["R_sysName"].ToString());
                }
                TVConfig_AddCFxxx(Ncf, (Oreadr["sc_status"].ToString() == "1")); //(Oreadr["R_sysName"].ToString());
                //tvConfig.Nodes[tvConfig.Nodes.Count - 1].ImageIndex = 0;
                //tvConfig.Nodes[tvConfig.Nodes.Count - 1].Nodes[SelectedImageIndex = 2;
            }
            OConn.Close();
            //groupBox1.Width = 865;
            //tvConfig.Width = 455;
        }

        private void TVConfig_AddCFxxx(string CF, bool EnDi)
        {
            int ndx = tvConfig.Nodes.Count - 1;
            tvConfig.Nodes[ndx].Nodes.Add(CF);
            int ndx2 = tvConfig.Nodes[ndx].Nodes.Count - 1;
            tvConfig.Nodes[ndx].Nodes[ndx2].SelectedImageIndex = 3;
            tvConfig.Nodes[ndx].Nodes[ndx2].ImageIndex = 0;
            tvConfig.Nodes[ndx].Nodes[ndx2].ForeColor = (EnDi) ? Color.Black : Color.Gray;
            lcurConfNm = CF;
            LcurConfndx = ndx2;
            //tvSol.SelectedNode.Nodes[tvSol.SelectedNode.Nodes.Count - 1].BeginEdit();
        }

        private void lvCurConfig_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvCurConfig.SelectedItems.Count == 1) C_txt.Text = lvCurConfig.SelectedItems[0].SubItems[0].Text;
        }

        private void tdel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("delete.........");
        }

        private void tadd_Click(object sender, EventArgs e)
        {
            if (tsk_cur_ndx == 3)
                if (ed_lvInfo.Items[tsk_cur_ndx].SubItems[2].Text == MainMDI.VIDE || ed_lvInfo.Items[tsk_cur_ndx].SubItems[2].Text == "")
                    ed_lvInfo.Items[tsk_cur_ndx].SubItems[2].Text = C_txt.Text;
            else if (tsk_cur_ndx != -1 && C_txt.Text != "" && tsk_cur_ndx > 5) ed_lvInfo.Items[tsk_cur_ndx].SubItems[2].Text = C_txt.Text;
        }

        private void tsave_Click(object sender, EventArgs e)
        {
            MessageBox.Show("saaaaaaaaaaaaaave........"); //gtftr //
        }

        private void toolStripSplitButton1_ButtonClick(object sender, EventArgs e)
        {

        }

        private void tvConfig_AfterSelect(object sender, TreeViewEventArgs e)
        {
            init_ITasks();
            switch (tvConfig.SelectedNode.ImageIndex)
            {
                case 1:
                case 7:
                    LcurConfndx = -1;
                    lcurConfNm = "";
                    for (int bt = 0; bt < 4; bt++) TSmain.Items[bt].Enabled = false;
                    break;
                case 0:
                case 3:
                    for (int bt = 0; bt < 4; bt++) TSmain.Items[bt].Enabled = true;
                    OLDTVConf_Selndx = LcurConfndx;
                    LcurConfndx = tvConfig.SelectedNode.Index;
                    lcurConfNm = tvConfig.SelectedNode.Text;
                    //if (tvConfig.SelectedNode.ForeColor == Color.Black)
                    //{
                        Fill_CurConf(lcurConfNm, true);
                        fill_lvTasks();
                    //}
                    if (tvConfig.SelectedNode.ForeColor != Color.Black)
                    { 
                        lvCurConfig.Items.Clear(); 
                        ed_lvInfo.Items.Clear(); 
                    }
                    break;
            }
        }

        private void tvConfig_AfterSelectokkk(object sender, TreeViewEventArgs e)
        {
            init_ITasks();
            switch (tvConfig.SelectedNode.ImageIndex)
            {
                case 1:
                case 7:
                    LcurConfndx = -1;
                    lcurConfNm = "";
                    for (int bt = 0; bt < 4; bt++) TSmain.Items[bt].Enabled = false;
                    break;
                case 0:
                case 3:
                    for (int bt = 0; bt < 4; bt++) TSmain.Items[bt].Enabled = true;
                    OLDTVConf_Selndx = LcurConfndx;
                    LcurConfndx = tvConfig.SelectedNode.Index;
                    lcurConfNm = tvConfig.SelectedNode.Text;
                    if (tvConfig.SelectedNode.ForeColor == Color.Black)
                    {
                        Fill_CurConf(lcurConfNm, true);
                        fill_lvTasks();
                    }
                    else 
                    { 
                        lvCurConfig.Items.Clear(); 
                        ed_lvInfo.Items.Clear(); 
                    }
                    break;
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            fill_arr_Tasks();
            New_All_SCD();
        }

        private void Disable_Prj(bool dsbl)
        {
            string msg = "Disable this Project ?";
            int sta = 0;
            if (!dsbl)
            {
                msg = "Enable this Project ?";
                sta = 1;
            }
            if (LcurConflid != "" && MainMDI.Confirm(msg))
            {
                string stSql = "UPDATE PSM_R_SCD_INFO SET [sc_status]=" + sta + " WHERE [sc_LID]=" + LcurConflid;
                MainMDI.Exec_SQL_JFS(stSql, msg + ", cfLID=" + LcurConflid);
                //MainMDI.Write_JFS(stSql);
                //int ndx = tvConfig.SelectedNode.Parent.Index;
                //tvConfig.Nodes[ndx].NO
                tvConfig.SelectedNode.ForeColor = (dsbl) ? Color.Gray : Color.Black;
            }
        }

        /*
        private void Fill_CurConf()
        {
            lvCurConfig.Items.Clear();

            string stSql = "SELECT     PSM_R_CFDetail.*, PSM_R_CFinfo.* FROM  PSM_R_CFDetail INNER JOIN  PSM_R_CFinfo ON PSM_R_CFDetail.d_CFLID = PSM_R_CFinfo.CFLID " +
                " WHERE     PSM_R_CFinfo.ConfigNm = '" + lcurConfNm + "' AND PSM_R_CFinfo.c_RRevLID =" + in_IRRevID + " ORDER BY PSM_R_CFDetail.d_Rnk ";
            SqlConnection OConn = new SqlConnection(MainMDI._connectionString);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            bool filled = false;
            while (Oreadr.Read())
            {
                if (!filled)
                {
                    lCFLID = Oreadr["CFLID"].ToString();
                    SN = Oreadr["c_SN"].ToString();
                    dpdlvrd.Text = Oreadr["c_datDlvr"].ToString();
                    DLVRD = dpdlvrd.Value.ToShortDateString();

                    filled = true;
                }
                ListViewItem lv = lvCurConfig.Items.Add(Oreadr["d_ItemDesc"].ToString());
                lv.SubItems.Add(Oreadr["cf_tecVal"].ToString());
                if (Oreadr["cf_tecVal"].ToString().IndexOf("C_MODEL") > -1) cur_CFTVA = Oreadr["cf_tecVal"].ToString();
            }
            OConn.Close();
        }
        * 
        * */

        private void ed_lvInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ed_lvInfo.SelectedItems.Count == 1)
            {
                tsk_cur_ndx = ed_lvInfo.SelectedItems[0].Index;
                ed_lvInfo.Items[tsk_cur_ndx].ForeColor = Color.Red;
                if (tsk_old_ndx != -1 && tsk_old_ndx != tsk_cur_ndx) ed_lvInfo.Items[tsk_old_ndx].ForeColor = Color.Black;
                tsk_old_ndx = tsk_cur_ndx;
            }
            else tsk_cur_ndx = -1;
        }

        private void chk_TVconfig(bool sta)
        {
            for (int ni = 0; ni < tvConfig.Nodes.Count; ni++)
                for (int nj = 0; nj < tvConfig.Nodes[ni].Nodes.Count; nj++) tvConfig.Nodes[ni].Nodes[nj].Checked = sta;
        }

        private void Copy_Click(object sender, EventArgs e)
        {
            //chk_TVconfig(false);
            for (int i = 0; i < 20; i++) 
                for (int j = 0; j < 3; j++) arr_Tskscopy[i, j] = "";
            for (int v = 0; v < ed_lvInfo.SelectedItems.Count; v++)
            {
                arr_Tskscopy[v, 0] = ed_lvInfo.SelectedItems[v].Index.ToString(); //.SubItems[0].Text; //tsk - lid
                arr_Tskscopy[v, 1] = ed_lvInfo.SelectedItems[v].SubItems[1].Text; //Val
                arr_Tskscopy[v, 2] = ed_lvInfo.SelectedItems[v].SubItems[2].Text; //dura
                if (!Past.Enabled) Past.Enabled = true;
            }
        }

        private void Past_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 20; i++)
            {
                if (arr_Tskscopy[i, 0] != "")
                {
                    int v = Int32.Parse(arr_Tskscopy[i, 0]);
                    if (v > 5)
                    {
                        ed_lvInfo.Items[v].SubItems[1].Text = arr_Tskscopy[i, 1];
                        ed_lvInfo.Items[v].SubItems[2].Text = arr_Tskscopy[i, 2];
                    }
                }
            }
        }

            //string stOut = "";
            //for (int v = 0; v < 20; v++)
            //{
                //stOut += "\n" + arr_Tskscopy[v, 0] + "    " + arr_Tskscopy[v, 1] + "    " + arr_Tskscopy[v, 2];
            //}
            //MessageBox.Show(stOut);
        //}

        private void Save_Click(object sender, EventArgs e)
        {
            for (int ti = 0; ti < ed_lvInfo.Items.Count; ti++)
            {
                if (ed_lvInfo.Items[ti].SubItems[0].Text != "" && ed_lvInfo.Items[ti].SubItems[0].Text != "0")
                {
                    string stSql = "UPDATE " + SCD_DETAIL_Name + " SET " +
                        " [scd_Value]='" + ed_lvInfo.Items[ti].SubItems[2].Text.Replace("'", "''") + "', " +
                        " [scd_dura]='" + ed_lvInfo.Items[ti].SubItems[3].Text.Replace("'", "''") + "' " +
                        " WHERE [sc_det_LID]=" + ed_lvInfo.Items[ti].SubItems[0].Text;
                    MainMDI.ExecSql(stSql);
                    MainMDI.Write_JFS(stSql);
                }
            }
        }

        private void xpnd_Click(object sender, EventArgs e)
        {
            bool X = (xpnd.Text == "Expand all") ? true : false;
            for (int n = 0; n < tvConfig.Nodes.Count; n++)
            {
                if (X) tvConfig.Nodes[n].Expand(); 
                else tvConfig.Nodes[n].Collapse();
            }                
            xpnd.Text = (X) ? "Collapse all" : "Expand all";
        }

        private void mov_Click(object sender, EventArgs e)
        {
            if (tsk_cur_ndx != -1 && C_txt.Text != "") ed_lvInfo.Items[tsk_cur_ndx].SubItems[2].Text += "~~~" + C_txt.Text;
        }

        private void enbleSP_Click(object sender, EventArgs e)
        {
            Disable_Prj(false);
            Fill_CurConf(lcurConfNm, true);
            fill_lvTasks();
        }

        private void disableSP_Click(object sender, EventArgs e)
        {
            Disable_Prj(true);
            if (tvConfig.SelectedNode.ForeColor != Color.Black)
            { 
                lvCurConfig.Items.Clear(); 
                ed_lvInfo.Items.Clear(); 
            }
        }

        private void nsrt_CF_arr(string cfNm, bool InsertIn)
        {
            string stFind = (InsertIn) ? "" : cfNm;
            string stNSRT = (InsertIn) ? cfNm : "";
            for (int i = 0; i < 200; i++)
                if (arr_cf_pastTo[i] == stFind)
                {
                    arr_cf_pastTo[i] = stNSRT;
                    i = 200;
                }
        }

        private void tvConfig_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Node.Checked) nsrt_CF_arr(e.Node.Text, true);
            else nsrt_CF_arr(e.Node.Text, false);

            //MessageBox.Show(e.Node.Text + "   ===>" + "stat: " + e.Node.Checked.ToString());
        }

        private void Past_Clickold(object sender, EventArgs e)
        {
            for (int cf = 0; cf < 200; cf++)
                if (arr_cf_pastTo[cf] != "") Past_CopiedTsks(arr_cf_pastTo[cf]);

            init_arr_cf_pastTo(); //end past
            Past.Enabled = false;
        }

        private void Past_CopiedTsks(string CFnm)
        {
            string stSql = " SELECT " + SCD_DETAIL_Name + ".sc_det_LID" +
                " FROM PSM_R_SCD_INFO INNER JOIN " + SCD_DETAIL_Name + " ON PSM_R_SCD_INFO.sc_LID = " + SCD_DETAIL_Name + ".d_sc_LID " +
                " WHERE  PSM_R_SCD_INFO.sc_IREVID = " + in_IRRevID + " AND PSM_R_SCD_INFO.sc_Name = '" + CFnm + "'";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            bool filled = false;
            while (Oreadr.Read())
            {
                for (int j = 0; j < MainMDI.MAX_SC_TASKS; j++)
                {
                    if (arr_Tskscopy[j, 0] != "")
                    {
                        stSql = "UPDATE " + SCD_DETAIL_Name + " SET " +
                            " [scd_Value]='" + arr_Tskscopy[j, 1] + "', " +
                            " [scd_dura]='" + arr_Tskscopy[j, 2] + "' " +
                            " WHERE [sc_det_LID]=" + Oreadr["sc_det_LID"].ToString() + " AND scd_TILID=" + arr_Tskscopy[j, 0];
                        if (MainMDI.ExecSql(stSql)) MainMDI.Write_JFS(stSql);
                    }
                    else j = Int32.Parse(MainMDI.MAX_SC_TASKS.ToString());
                }
            }
            OConn.Close();
        }

        private void sc_exit_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void del_prj_Click(object sender, EventArgs e)
        {
            if (MainMDI.User.ToLower() == "ede")
            {
                if (MainMDI.Confirm("Want to delete this project#: " + in_RID + " from Schedule ? "))
                {
                    MainMDI.Exec_SQL_JFS("delete  PSM_R_SCD_INFO where PSM_R_SCD_INFO.sc_IREVID=" + in_IRRevID, 
                        "delete project from SCD_INFO....usr=" + MainMDI.User + "  PC=" + MainMDI.Mach_Name);
                    //load_ALLCFs();
                    //init_arr_cf_pastTo();
                    this.Hide();
                }
            }
            else del_prj.Visible = false;
        }

        private void ed_lvInfo_DoubleClick(object sender, EventArgs e)
        {
            string[,] arr_info = new string[ed_lvInfo.Items.Count, 7];

            for (int i = 0; i < ed_lvInfo.Items.Count; i++)
                for (int y = 0; y < ed_lvInfo.Items[i].SubItems.Count; y++) arr_info[i, y] = ed_lvInfo.Items[i].SubItems[y].Text;

            OR_ToSched_Edit my_editFRM = new OR_ToSched_Edit(ref arr_info, in_EM, LcurConflid);
            my_editFRM.ShowDialog();

            for (int i = 0; i < ed_lvInfo.Items.Count; i++)
                for (int y = 0; y < ed_lvInfo.Items[i].SubItems.Count; y++) ed_lvInfo.Items[i].SubItems[y].Text = arr_info[i, y];
        }
    }
}