using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb ;  
using System.Data.SqlClient ;
using EAHLibs;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;


namespace PGESCOM
{
	/// <summary>
	/// Summary description for OR_ToSched.
	/// </summary>
    public class Rectif_TR : System.Windows.Forms.Form
    {
        //local var
        string LcurConflid = "",lTRLID="", in_IRRevID = "", in_cmpany="",in_RID = "", in_ConfNm = "", SN = "", cur_CFTVA = "", DLVRD = "", lcurConfNm = "", lCFLID = "", lcurTRndx = "", lcurTRNm = "", TRndxDel = "";
        int LcurConfndx = -1, OLDTVConf_Selndx = -1, tsk_cur_ndx = -1, tsk_old_ndx = -1, ndx_pastTo = -1;
    //    private string[,] arr_Rectif_TList = new string[100, 3], arr_Rectif_Stps = new string[100, 5];
        bool TosaveRTR = false, TosaveCF = false;
        private int OLDTVS_Selndx = -1, OLDTVTR_Selndx = -1, OLDSysSelndx = -1;
        private Hashtable HT_XL_ReqV = new Hashtable(), HT_XL_TestV = new Hashtable(), HT_titles = new Hashtable();

        private Lib1 Tools = new Lib1();

        //local var

        private GroupBox groupBox3;
        private GroupBox grpConf;
        private GroupBox groupBox1;
        private ToolStrip TSmain;
        private ToolStripButton del_RTR;
        private ToolStripButton Save;
        private ToolStripButton errr;
        private ImageList imageList16_stat;
        private ToolStripButton NewTR;
        private DateTimePicker dp_datConvert;
        private GroupBox grp1;
        private TreeView tvTR;
        private GroupBox grp2_Rect_info;
        private GroupBox grp_list;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private GroupBox grp3;
        private ed_LVmodif ed_lvMtst;
        private ColumnHeader Tlid;
        private ColumnHeader TDesc;
        private ColumnHeader Ival;
        private ColumnHeader TestValue;
        private TabPage tabPage2;
        private GroupBox grp4;
        private PictureBox picTM;
        public Label lTRstat;
        private Label label105;
        private Label label90;
        public TextBox PX_Model;
        private Label label87;
        public TextBox tcust_Model;
        private ColumnHeader Cmnt;
        public TextBox tTRuser;
        private Label label114;
        private Label label115;
        public DateTimePicker dpTRdate;
        public TextBox lTRdate;
        private Button button1;
        private Label label86;
        public ComboBox CBSerItems;
        public Label lItemSer;
        private Label st_NE;
        private PictureBox gifHere;
        private Label label1;
        public TextBox TRcmnt;
        private Label st_sTR;
        private ToolStripButton toolStripButton1;
        private ToolStripButton toolStripButton2;
        private ImageList imageList216;
        private GroupBox groupBox2;
        private ed_LVmodif ed_LVStps;
        private ColumnHeader C_lid;
        private ColumnHeader cntrl;
        private ColumnHeader ValC;
        private ColumnHeader ALARM;
        private ColumnHeader ValA;
        private ColumnHeader LVL2;
        private ColumnHeader ValL;
        private GroupBox groupBox4;
        private Label label5;
        public TextBox txSTKnb;
        private ed_LVmodif ed_LVOthers;
        private ColumnHeader oth_lid;
        private ColumnHeader oth_txt;
        private ColumnHeader oth_val;
        private ColumnHeader xl_C;
        private ColumnHeader xl_A;
        private ColumnHeader xl_L;
        private ColumnHeader xl_O;
        private ColumnHeader A_lid;
        private ColumnHeader L_lid;
        private Button btnSTK;
        private Label lM;
        private Label lS;
        private ColumnHeader hdr;
        private ToolStripButton picPrintRTR;
        private ed_LVmodif ed_lvBRD;
        private ColumnHeader brdLID;
        private ColumnHeader bDesc;
        private ColumnHeader Bver;
        private ColumnHeader FWver;
        private ColumnHeader BOMrev;
        private ColumnHeader PCBdat;
        private ColumnHeader Assmbdat;
        private ColumnHeader bSN;
        private ColumnHeader Con;
        private ColumnHeader manual;
        public PictureBox picCIP;
        private TabPage tabPage3;
        private GroupBox groupBox32;
        private GroupBox groupBox33;
        public Modified_EditListView elv_docsP;
        private ColumnHeader DTPid;
        private ColumnHeader DNm;
        private ColumnHeader docPath;
        private ColumnHeader prt;
        private GroupBox grpOpera;
        private ToolStrip TS_AGTerr;
        private ToolStripButton New_Docs;
        private ToolStripButton tls_Save;
        private ToolStripButton DelDocs;
        private ToolStripButton RFP;
        private ToolStripButton Pdoc;
        private ToolStripButton Doc_Printed;
        private ToolStripButton Doc_NOTPrinted;
        private ToolStripLabel lRateTbl;
        private PictureBox picNotPrinted;
        private PictureBox picPrinted;
        private PictureBox picDelDoc;
        private PictureBox picOpen;
        private Label ldocs;
        private PictureBox picSave;
        private OpenFileDialog openFileDialog3;
        private TabPage tabPage4;
        private GroupBox grpBrd_man;
        private PictureBox pic_BManag;
        private GroupBox groupBox31;
        private GroupBox groupBox30;
        private PictureBox ww;
        private GroupBox groupBox6;
        private GroupBox grpCard;
        private PictureBox picDel;
        private PictureBox picSaveBRD;
        private GroupBox grpBrdSN;
        private PictureBox picAdd;
        private Label label99;
        public TextBox tmanual;
        private Label label84;
        public TextBox tConTo;
        private Label label79;
        private Label label78;
        public TextBox tPV;
        public TextBox tbV;
        private Label selBrd;
        public TextBox tBrdSN;
        private Label label66;
        public TextBox tBrdDesc;
        private Label label65;
        private PictureBox pictureBox5;
        public ListView lvBoards;
        private ColumnHeader bord;
        private PictureBox pic_Modif;
        private PictureBox pic_ManSave;
        private ed_LVmodif mdl_brds_REC;
        private ColumnHeader columnHeader30;
        private ColumnHeader columnHeader51;
        public Modified_EditListView mdl_sel_man;
        private ColumnHeader columnHeader49;
        private ColumnHeader columnHeader50;
        private IContainer components;

        public Rectif_TR(string x_IRRevID,string x_cmpany,string x_RID)
        {
            //
            // Required for Windows Form Designer support
            //
            InitializeComponent();
            in_IRRevID = x_IRRevID;
            in_cmpany = x_cmpany;
            in_RID = x_RID;




            //
            // TODO: Add any constructor code after InitializeComponent call
            //
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rectif_TR));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.grp1 = new System.Windows.Forms.GroupBox();
            this.grp_list = new System.Windows.Forms.GroupBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.grp3 = new System.Windows.Forms.GroupBox();
            this.ed_lvMtst = new PGESCOM.ed_LVmodif();
            this.Tlid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Ival = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.TestValue = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Cmnt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.hdr = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.grp4 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.ed_LVOthers = new PGESCOM.ed_LVmodif();
            this.oth_lid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.oth_txt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.oth_val = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.xl_O = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.ed_LVStps = new PGESCOM.ed_LVmodif();
            this.C_lid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.cntrl = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.xl_C = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.A_lid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ALARM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValA = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.xl_A = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.L_lid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.LVL2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ValL = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.xl_L = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.grpBrd_man = new System.Windows.Forms.GroupBox();
            this.pic_BManag = new System.Windows.Forms.PictureBox();
            this.groupBox31 = new System.Windows.Forms.GroupBox();
            this.mdl_sel_man = new PGESCOM.Modified_EditListView();
            this.columnHeader49 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader50 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox30 = new System.Windows.Forms.GroupBox();
            this.mdl_brds_REC = new PGESCOM.ed_LVmodif();
            this.columnHeader30 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader51 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ww = new System.Windows.Forms.PictureBox();
            this.groupBox6 = new System.Windows.Forms.GroupBox();
            this.grpCard = new System.Windows.Forms.GroupBox();
            this.picDel = new System.Windows.Forms.PictureBox();
            this.picSaveBRD = new System.Windows.Forms.PictureBox();
            this.grpBrdSN = new System.Windows.Forms.GroupBox();
            this.picAdd = new System.Windows.Forms.PictureBox();
            this.label99 = new System.Windows.Forms.Label();
            this.tmanual = new System.Windows.Forms.TextBox();
            this.label84 = new System.Windows.Forms.Label();
            this.tConTo = new System.Windows.Forms.TextBox();
            this.label79 = new System.Windows.Forms.Label();
            this.label78 = new System.Windows.Forms.Label();
            this.tPV = new System.Windows.Forms.TextBox();
            this.tbV = new System.Windows.Forms.TextBox();
            this.selBrd = new System.Windows.Forms.Label();
            this.tBrdSN = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.tBrdDesc = new System.Windows.Forms.TextBox();
            this.label65 = new System.Windows.Forms.Label();
            this.pictureBox5 = new System.Windows.Forms.PictureBox();
            this.lvBoards = new System.Windows.Forms.ListView();
            this.bord = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.pic_Modif = new System.Windows.Forms.PictureBox();
            this.pic_ManSave = new System.Windows.Forms.PictureBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.groupBox32 = new System.Windows.Forms.GroupBox();
            this.groupBox33 = new System.Windows.Forms.GroupBox();
            this.elv_docsP = new PGESCOM.Modified_EditListView();
            this.DTPid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DNm = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.docPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.prt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpOpera = new System.Windows.Forms.GroupBox();
            this.TS_AGTerr = new System.Windows.Forms.ToolStrip();
            this.New_Docs = new System.Windows.Forms.ToolStripButton();
            this.tls_Save = new System.Windows.Forms.ToolStripButton();
            this.DelDocs = new System.Windows.Forms.ToolStripButton();
            this.RFP = new System.Windows.Forms.ToolStripButton();
            this.Pdoc = new System.Windows.Forms.ToolStripButton();
            this.Doc_Printed = new System.Windows.Forms.ToolStripButton();
            this.Doc_NOTPrinted = new System.Windows.Forms.ToolStripButton();
            this.lRateTbl = new System.Windows.Forms.ToolStripLabel();
            this.picNotPrinted = new System.Windows.Forms.PictureBox();
            this.picPrinted = new System.Windows.Forms.PictureBox();
            this.picDelDoc = new System.Windows.Forms.PictureBox();
            this.picOpen = new System.Windows.Forms.PictureBox();
            this.ldocs = new System.Windows.Forms.Label();
            this.picSave = new System.Windows.Forms.PictureBox();
            this.imageList16_stat = new System.Windows.Forms.ImageList(this.components);
            this.grp2_Rect_info = new System.Windows.Forms.GroupBox();
            this.ed_lvBRD = new PGESCOM.ed_LVmodif();
            this.brdLID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bDesc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Bver = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.FWver = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.BOMrev = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.PCBdat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Assmbdat = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.bSN = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Con = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.manual = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lM = new System.Windows.Forms.Label();
            this.lS = new System.Windows.Forms.Label();
            this.txSTKnb = new System.Windows.Forms.TextBox();
            this.st_sTR = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.TRcmnt = new System.Windows.Forms.TextBox();
            this.gifHere = new System.Windows.Forms.PictureBox();
            this.st_NE = new System.Windows.Forms.Label();
            this.label86 = new System.Windows.Forms.Label();
            this.label115 = new System.Windows.Forms.Label();
            this.tTRuser = new System.Windows.Forms.TextBox();
            this.label114 = new System.Windows.Forms.Label();
            this.picTM = new System.Windows.Forms.PictureBox();
            this.lTRstat = new System.Windows.Forms.Label();
            this.label105 = new System.Windows.Forms.Label();
            this.label90 = new System.Windows.Forms.Label();
            this.PX_Model = new System.Windows.Forms.TextBox();
            this.label87 = new System.Windows.Forms.Label();
            this.tcust_Model = new System.Windows.Forms.TextBox();
            this.btnSTK = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dpTRdate = new System.Windows.Forms.DateTimePicker();
            this.lTRdate = new System.Windows.Forms.TextBox();
            this.CBSerItems = new System.Windows.Forms.ComboBox();
            this.lItemSer = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.tvTR = new System.Windows.Forms.TreeView();
            this.imageList216 = new System.Windows.Forms.ImageList(this.components);
            this.button1 = new System.Windows.Forms.Button();
            this.grpConf = new System.Windows.Forms.GroupBox();
            this.picCIP = new System.Windows.Forms.PictureBox();
            this.TSmain = new System.Windows.Forms.ToolStrip();
            this.NewTR = new System.Windows.Forms.ToolStripButton();
            this.del_RTR = new System.Windows.Forms.ToolStripButton();
            this.Save = new System.Windows.Forms.ToolStripButton();
            this.picPrintRTR = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.errr = new System.Windows.Forms.ToolStripButton();
            this.openFileDialog3 = new System.Windows.Forms.OpenFileDialog();
            this.groupBox3.SuspendLayout();
            this.grp1.SuspendLayout();
            this.grp_list.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.grp3.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.grp4.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.grpBrd_man.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pic_BManag)).BeginInit();
            this.groupBox31.SuspendLayout();
            this.groupBox30.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.ww)).BeginInit();
            this.groupBox6.SuspendLayout();
            this.grpCard.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSaveBRD)).BeginInit();
            this.grpBrdSN.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Modif)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ManSave)).BeginInit();
            this.tabPage3.SuspendLayout();
            this.groupBox32.SuspendLayout();
            this.groupBox33.SuspendLayout();
            this.grpOpera.SuspendLayout();
            this.TS_AGTerr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNotPrinted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrinted)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelDoc)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpen)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSave)).BeginInit();
            this.grp2_Rect_info.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gifHere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTM)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.grpConf.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.TSmain.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.grp1);
            this.groupBox3.Controls.Add(this.groupBox1);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox3.Location = new System.Drawing.Point(0, 63);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(1128, 581);
            this.groupBox3.TabIndex = 241;
            this.groupBox3.TabStop = false;
            // 
            // grp1
            // 
            this.grp1.Controls.Add(this.grp_list);
            this.grp1.Controls.Add(this.grp2_Rect_info);
            this.grp1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp1.Location = new System.Drawing.Point(233, 16);
            this.grp1.Name = "grp1";
            this.grp1.Size = new System.Drawing.Size(892, 562);
            this.grp1.TabIndex = 253;
            this.grp1.TabStop = false;
            // 
            // grp_list
            // 
            this.grp_list.Controls.Add(this.tabControl1);
            this.grp_list.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp_list.Location = new System.Drawing.Point(3, 136);
            this.grp_list.Name = "grp_list";
            this.grp_list.Size = new System.Drawing.Size(886, 423);
            this.grp_list.TabIndex = 2;
            this.grp_list.TabStop = false;
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.ImageList = this.imageList16_stat;
            this.tabControl1.Location = new System.Drawing.Point(4, 19);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(876, 392);
            this.tabControl1.TabIndex = 1;
            this.tabControl1.SelectedIndexChanged += new System.EventHandler(this.tabControl1_SelectedIndexChanged);
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.grp3);
            this.tabPage1.ImageIndex = 0;
            this.tabPage1.Location = new System.Drawing.Point(4, 23);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(868, 365);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Main Test report";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // grp3
            // 
            this.grp3.BackColor = System.Drawing.SystemColors.Control;
            this.grp3.Controls.Add(this.ed_lvMtst);
            this.grp3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp3.Location = new System.Drawing.Point(3, 3);
            this.grp3.Name = "grp3";
            this.grp3.Size = new System.Drawing.Size(862, 359);
            this.grp3.TabIndex = 0;
            this.grp3.TabStop = false;
            // 
            // ed_lvMtst
            // 
            this.ed_lvMtst.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvMtst.AutoArrange = false;
            this.ed_lvMtst.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ed_lvMtst.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Tlid,
            this.TDesc,
            this.Ival,
            this.TestValue,
            this.Cmnt,
            this.hdr});
            this.ed_lvMtst.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_lvMtst.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvMtst.ForeColor = System.Drawing.Color.Black;
            this.ed_lvMtst.FullRowSelect = true;
            this.ed_lvMtst.GridLines = true;
            this.ed_lvMtst.Location = new System.Drawing.Point(3, 16);
            this.ed_lvMtst.Name = "ed_lvMtst";
            this.ed_lvMtst.Size = new System.Drawing.Size(856, 340);
            this.ed_lvMtst.TabIndex = 249;
            this.ed_lvMtst.UseCompatibleStateImageBehavior = false;
            this.ed_lvMtst.View = System.Windows.Forms.View.Details;
            // 
            // Tlid
            // 
            this.Tlid.Text = "";
            this.Tlid.Width = 0;
            // 
            // TDesc
            // 
            this.TDesc.Text = "Test Name";
            this.TDesc.Width = 327;
            // 
            // Ival
            // 
            this.Ival.Text = "Requirement";
            this.Ival.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Ival.Width = 136;
            // 
            // TestValue
            // 
            this.TestValue.Text = "Test Value";
            this.TestValue.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.TestValue.Width = 106;
            // 
            // Cmnt
            // 
            this.Cmnt.Text = "Comments";
            this.Cmnt.Width = 264;
            // 
            // hdr
            // 
            this.hdr.Text = "";
            this.hdr.Width = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.grp4);
            this.tabPage2.ImageIndex = 0;
            this.tabPage2.Location = new System.Drawing.Point(4, 23);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(868, 365);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Step by Step";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // grp4
            // 
            this.grp4.BackColor = System.Drawing.SystemColors.Control;
            this.grp4.Controls.Add(this.groupBox4);
            this.grp4.Controls.Add(this.groupBox2);
            this.grp4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grp4.Location = new System.Drawing.Point(3, 3);
            this.grp4.Name = "grp4";
            this.grp4.Size = new System.Drawing.Size(862, 359);
            this.grp4.TabIndex = 1;
            this.grp4.TabStop = false;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.ed_LVOthers);
            this.groupBox4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox4.Location = new System.Drawing.Point(3, 252);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(856, 104);
            this.groupBox4.TabIndex = 327;
            this.groupBox4.TabStop = false;
            // 
            // ed_LVOthers
            // 
            this.ed_LVOthers.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_LVOthers.AutoArrange = false;
            this.ed_LVOthers.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ed_LVOthers.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.oth_lid,
            this.oth_txt,
            this.oth_val,
            this.xl_O});
            this.ed_LVOthers.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_LVOthers.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_LVOthers.ForeColor = System.Drawing.Color.Black;
            this.ed_LVOthers.FullRowSelect = true;
            this.ed_LVOthers.GridLines = true;
            this.ed_LVOthers.Location = new System.Drawing.Point(3, 16);
            this.ed_LVOthers.Name = "ed_LVOthers";
            this.ed_LVOthers.Size = new System.Drawing.Size(850, 85);
            this.ed_LVOthers.TabIndex = 250;
            this.ed_LVOthers.UseCompatibleStateImageBehavior = false;
            this.ed_LVOthers.View = System.Windows.Forms.View.Details;
            // 
            // oth_lid
            // 
            this.oth_lid.Text = "";
            this.oth_lid.Width = 0;
            // 
            // oth_txt
            // 
            this.oth_txt.Text = "Security info";
            this.oth_txt.Width = 246;
            // 
            // oth_val
            // 
            this.oth_val.Text = "Value";
            this.oth_val.Width = 583;
            // 
            // xl_O
            // 
            this.xl_O.Text = "";
            this.xl_O.Width = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.ed_LVStps);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox2.Location = new System.Drawing.Point(3, 16);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(856, 236);
            this.groupBox2.TabIndex = 326;
            this.groupBox2.TabStop = false;
            // 
            // ed_LVStps
            // 
            this.ed_LVStps.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_LVStps.AutoArrange = false;
            this.ed_LVStps.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ed_LVStps.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.C_lid,
            this.cntrl,
            this.ValC,
            this.xl_C,
            this.A_lid,
            this.ALARM,
            this.ValA,
            this.xl_A,
            this.L_lid,
            this.LVL2,
            this.ValL,
            this.xl_L});
            this.ed_LVStps.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_LVStps.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_LVStps.ForeColor = System.Drawing.Color.Black;
            this.ed_LVStps.FullRowSelect = true;
            this.ed_LVStps.GridLines = true;
            this.ed_LVStps.Location = new System.Drawing.Point(3, 16);
            this.ed_LVStps.Name = "ed_LVStps";
            this.ed_LVStps.Size = new System.Drawing.Size(850, 217);
            this.ed_LVStps.TabIndex = 250;
            this.ed_LVStps.UseCompatibleStateImageBehavior = false;
            this.ed_LVStps.View = System.Windows.Forms.View.Details;
            // 
            // C_lid
            // 
            this.C_lid.Text = "";
            this.C_lid.Width = 0;
            // 
            // cntrl
            // 
            this.cntrl.Text = "CONTROL";
            this.cntrl.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.cntrl.Width = 155;
            // 
            // ValC
            // 
            this.ValC.Text = "Value";
            this.ValC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ValC.Width = 97;
            // 
            // xl_C
            // 
            this.xl_C.DisplayIndex = 7;
            this.xl_C.Text = "";
            this.xl_C.Width = 0;
            // 
            // A_lid
            // 
            this.A_lid.DisplayIndex = 10;
            this.A_lid.Text = "";
            this.A_lid.Width = 0;
            // 
            // ALARM
            // 
            this.ALARM.DisplayIndex = 3;
            this.ALARM.Text = "ALARM";
            this.ALARM.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.ALARM.Width = 203;
            // 
            // ValA
            // 
            this.ValA.DisplayIndex = 4;
            this.ValA.Text = "Value";
            this.ValA.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ValA.Width = 97;
            // 
            // xl_A
            // 
            this.xl_A.DisplayIndex = 8;
            this.xl_A.Text = "";
            this.xl_A.Width = 0;
            // 
            // L_lid
            // 
            this.L_lid.DisplayIndex = 11;
            this.L_lid.Text = "";
            this.L_lid.Width = 0;
            // 
            // LVL2
            // 
            this.LVL2.DisplayIndex = 5;
            this.LVL2.Text = "LEVEL 2";
            this.LVL2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.LVL2.Width = 182;
            // 
            // ValL
            // 
            this.ValL.DisplayIndex = 6;
            this.ValL.Text = "Value";
            this.ValL.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ValL.Width = 97;
            // 
            // xl_L
            // 
            this.xl_L.DisplayIndex = 9;
            this.xl_L.Text = "";
            this.xl_L.Width = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.grpBrd_man);
            this.tabPage4.Location = new System.Drawing.Point(4, 23);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(868, 365);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "Boards / Manuals";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // grpBrd_man
            // 
            this.grpBrd_man.BackColor = System.Drawing.SystemColors.Control;
            this.grpBrd_man.Controls.Add(this.pic_BManag);
            this.grpBrd_man.Controls.Add(this.groupBox31);
            this.grpBrd_man.Controls.Add(this.groupBox30);
            this.grpBrd_man.Controls.Add(this.ww);
            this.grpBrd_man.Controls.Add(this.groupBox6);
            this.grpBrd_man.Controls.Add(this.pic_Modif);
            this.grpBrd_man.Controls.Add(this.pic_ManSave);
            this.grpBrd_man.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpBrd_man.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grpBrd_man.Location = new System.Drawing.Point(0, 0);
            this.grpBrd_man.Name = "grpBrd_man";
            this.grpBrd_man.Size = new System.Drawing.Size(868, 365);
            this.grpBrd_man.TabIndex = 324;
            this.grpBrd_man.TabStop = false;
            // 
            // pic_BManag
            // 
            this.pic_BManag.BackColor = System.Drawing.Color.Transparent;
            this.pic_BManag.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_BManag.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_BManag.Image = ((System.Drawing.Image)(resources.GetObject("pic_BManag.Image")));
            this.pic_BManag.Location = new System.Drawing.Point(250, 159);
            this.pic_BManag.Name = "pic_BManag";
            this.pic_BManag.Size = new System.Drawing.Size(90, 92);
            this.pic_BManag.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_BManag.TabIndex = 326;
            this.pic_BManag.TabStop = false;
            this.pic_BManag.Click += new System.EventHandler(this.pic_BManag_Click);
            // 
            // groupBox31
            // 
            this.groupBox31.Controls.Add(this.mdl_sel_man);
            this.groupBox31.Location = new System.Drawing.Point(396, 18);
            this.groupBox31.Name = "groupBox31";
            this.groupBox31.Size = new System.Drawing.Size(311, 359);
            this.groupBox31.TabIndex = 325;
            this.groupBox31.TabStop = false;
            this.groupBox31.Text = "Manuals";
            // 
            // mdl_sel_man
            // 
            this.mdl_sel_man.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.mdl_sel_man.AutoArrange = false;
            this.mdl_sel_man.BackColor = System.Drawing.Color.WhiteSmoke;
            this.mdl_sel_man.CheckBoxes = true;
            this.mdl_sel_man.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader49,
            this.columnHeader50});
            this.mdl_sel_man.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdl_sel_man.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdl_sel_man.ForeColor = System.Drawing.Color.Black;
            this.mdl_sel_man.FullRowSelect = true;
            this.mdl_sel_man.GridLines = true;
            this.mdl_sel_man.Location = new System.Drawing.Point(3, 20);
            this.mdl_sel_man.Name = "mdl_sel_man";
            this.mdl_sel_man.Size = new System.Drawing.Size(305, 336);
            this.mdl_sel_man.TabIndex = 380;
            this.mdl_sel_man.UseCompatibleStateImageBehavior = false;
            this.mdl_sel_man.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader49
            // 
            this.columnHeader49.Text = "OK";
            this.columnHeader49.Width = 0;
            // 
            // columnHeader50
            // 
            this.columnHeader50.Text = "Manual Name";
            this.columnHeader50.Width = 281;
            // 
            // groupBox30
            // 
            this.groupBox30.Controls.Add(this.mdl_brds_REC);
            this.groupBox30.Location = new System.Drawing.Point(6, 18);
            this.groupBox30.Name = "groupBox30";
            this.groupBox30.Size = new System.Drawing.Size(195, 362);
            this.groupBox30.TabIndex = 324;
            this.groupBox30.TabStop = false;
            this.groupBox30.Text = "Boards";
            // 
            // mdl_brds_REC
            // 
            this.mdl_brds_REC.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.mdl_brds_REC.AutoArrange = false;
            this.mdl_brds_REC.BackColor = System.Drawing.Color.PowderBlue;
            this.mdl_brds_REC.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader30,
            this.columnHeader51});
            this.mdl_brds_REC.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdl_brds_REC.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdl_brds_REC.ForeColor = System.Drawing.Color.Black;
            this.mdl_brds_REC.FullRowSelect = true;
            this.mdl_brds_REC.GridLines = true;
            this.mdl_brds_REC.Location = new System.Drawing.Point(3, 20);
            this.mdl_brds_REC.Name = "mdl_brds_REC";
            this.mdl_brds_REC.Size = new System.Drawing.Size(189, 339);
            this.mdl_brds_REC.TabIndex = 367;
            this.mdl_brds_REC.UseCompatibleStateImageBehavior = false;
            this.mdl_brds_REC.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader30
            // 
            this.columnHeader30.Text = "";
            this.columnHeader30.Width = 0;
            // 
            // columnHeader51
            // 
            this.columnHeader51.Text = "Board Name";
            this.columnHeader51.Width = 165;
            // 
            // ww
            // 
            this.ww.BackColor = System.Drawing.Color.Transparent;
            this.ww.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.ww.Cursor = System.Windows.Forms.Cursors.Hand;
            this.ww.Image = ((System.Drawing.Image)(resources.GetObject("ww.Image")));
            this.ww.Location = new System.Drawing.Point(42, 21);
            this.ww.Name = "ww";
            this.ww.Size = new System.Drawing.Size(75, 40);
            this.ww.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ww.TabIndex = 322;
            this.ww.TabStop = false;
            this.ww.Visible = false;
            // 
            // groupBox6
            // 
            this.groupBox6.Controls.Add(this.grpCard);
            this.groupBox6.Controls.Add(this.grpBrdSN);
            this.groupBox6.Controls.Add(this.pictureBox5);
            this.groupBox6.Controls.Add(this.lvBoards);
            this.groupBox6.Location = new System.Drawing.Point(370, 223);
            this.groupBox6.Name = "groupBox6";
            this.groupBox6.Size = new System.Drawing.Size(62, 64);
            this.groupBox6.TabIndex = 323;
            this.groupBox6.TabStop = false;
            this.groupBox6.Visible = false;
            // 
            // grpCard
            // 
            this.grpCard.Controls.Add(this.picDel);
            this.grpCard.Controls.Add(this.picSaveBRD);
            this.grpCard.Location = new System.Drawing.Point(4, 9);
            this.grpCard.Name = "grpCard";
            this.grpCard.Size = new System.Drawing.Size(50, 118);
            this.grpCard.TabIndex = 183;
            this.grpCard.TabStop = false;
            this.grpCard.Visible = false;
            // 
            // picDel
            // 
            this.picDel.BackColor = System.Drawing.Color.Transparent;
            this.picDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDel.Image = ((System.Drawing.Image)(resources.GetObject("picDel.Image")));
            this.picDel.Location = new System.Drawing.Point(6, 16);
            this.picDel.Name = "picDel";
            this.picDel.Size = new System.Drawing.Size(38, 40);
            this.picDel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDel.TabIndex = 200;
            this.picDel.TabStop = false;
            // 
            // picSaveBRD
            // 
            this.picSaveBRD.BackColor = System.Drawing.Color.Transparent;
            this.picSaveBRD.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSaveBRD.Image = ((System.Drawing.Image)(resources.GetObject("picSaveBRD.Image")));
            this.picSaveBRD.Location = new System.Drawing.Point(6, 62);
            this.picSaveBRD.Name = "picSaveBRD";
            this.picSaveBRD.Size = new System.Drawing.Size(38, 40);
            this.picSaveBRD.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSaveBRD.TabIndex = 199;
            this.picSaveBRD.TabStop = false;
            // 
            // grpBrdSN
            // 
            this.grpBrdSN.Controls.Add(this.picAdd);
            this.grpBrdSN.Controls.Add(this.label99);
            this.grpBrdSN.Controls.Add(this.tmanual);
            this.grpBrdSN.Controls.Add(this.label84);
            this.grpBrdSN.Controls.Add(this.tConTo);
            this.grpBrdSN.Controls.Add(this.label79);
            this.grpBrdSN.Controls.Add(this.label78);
            this.grpBrdSN.Controls.Add(this.tPV);
            this.grpBrdSN.Controls.Add(this.tbV);
            this.grpBrdSN.Controls.Add(this.selBrd);
            this.grpBrdSN.Controls.Add(this.tBrdSN);
            this.grpBrdSN.Controls.Add(this.label66);
            this.grpBrdSN.Controls.Add(this.tBrdDesc);
            this.grpBrdSN.Controls.Add(this.label65);
            this.grpBrdSN.Location = new System.Drawing.Point(504, 4);
            this.grpBrdSN.Name = "grpBrdSN";
            this.grpBrdSN.Size = new System.Drawing.Size(320, 128);
            this.grpBrdSN.TabIndex = 182;
            this.grpBrdSN.TabStop = false;
            this.grpBrdSN.Visible = false;
            // 
            // picAdd
            // 
            this.picAdd.BackColor = System.Drawing.Color.Transparent;
            this.picAdd.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picAdd.Image = ((System.Drawing.Image)(resources.GetObject("picAdd.Image")));
            this.picAdd.Location = new System.Drawing.Point(6, 98);
            this.picAdd.Name = "picAdd";
            this.picAdd.Size = new System.Drawing.Size(40, 28);
            this.picAdd.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picAdd.TabIndex = 193;
            this.picAdd.TabStop = false;
            // 
            // label99
            // 
            this.label99.BackColor = System.Drawing.SystemColors.Control;
            this.label99.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label99.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label99.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label99.Location = new System.Drawing.Point(11, 100);
            this.label99.Name = "label99";
            this.label99.Size = new System.Drawing.Size(85, 14);
            this.label99.TabIndex = 204;
            this.label99.Text = "Manual :";
            this.label99.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmanual
            // 
            this.tmanual.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tmanual.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tmanual.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tmanual.ForeColor = System.Drawing.Color.DarkRed;
            this.tmanual.Location = new System.Drawing.Point(96, 98);
            this.tmanual.MaxLength = 49;
            this.tmanual.Multiline = true;
            this.tmanual.Name = "tmanual";
            this.tmanual.Size = new System.Drawing.Size(129, 18);
            this.tmanual.TabIndex = 203;
            // 
            // label84
            // 
            this.label84.BackColor = System.Drawing.SystemColors.Control;
            this.label84.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label84.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label84.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label84.Location = new System.Drawing.Point(8, 82);
            this.label84.Name = "label84";
            this.label84.Size = new System.Drawing.Size(88, 14);
            this.label84.TabIndex = 202;
            this.label84.Text = "Connected To:";
            this.label84.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tConTo
            // 
            this.tConTo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tConTo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tConTo.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tConTo.ForeColor = System.Drawing.Color.DarkRed;
            this.tConTo.Location = new System.Drawing.Point(96, 80);
            this.tConTo.MaxLength = 49;
            this.tConTo.Multiline = true;
            this.tConTo.Name = "tConTo";
            this.tConTo.Size = new System.Drawing.Size(129, 18);
            this.tConTo.TabIndex = 201;
            // 
            // label79
            // 
            this.label79.BackColor = System.Drawing.SystemColors.Control;
            this.label79.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label79.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label79.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label79.Location = new System.Drawing.Point(16, 46);
            this.label79.Name = "label79";
            this.label79.Size = new System.Drawing.Size(80, 14);
            this.label79.TabIndex = 200;
            this.label79.Text = "Program Ver.";
            this.label79.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label78
            // 
            this.label78.BackColor = System.Drawing.SystemColors.Control;
            this.label78.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label78.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label78.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label78.Location = new System.Drawing.Point(14, 28);
            this.label78.Name = "label78";
            this.label78.Size = new System.Drawing.Size(82, 14);
            this.label78.TabIndex = 199;
            this.label78.Text = "Board Version:";
            this.label78.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tPV
            // 
            this.tPV.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tPV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tPV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tPV.ForeColor = System.Drawing.Color.DarkRed;
            this.tPV.Location = new System.Drawing.Point(96, 44);
            this.tPV.MaxLength = 49;
            this.tPV.Multiline = true;
            this.tPV.Name = "tPV";
            this.tPV.Size = new System.Drawing.Size(128, 18);
            this.tPV.TabIndex = 198;
            // 
            // tbV
            // 
            this.tbV.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tbV.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tbV.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbV.ForeColor = System.Drawing.Color.DarkRed;
            this.tbV.Location = new System.Drawing.Point(96, 26);
            this.tbV.MaxLength = 49;
            this.tbV.Multiline = true;
            this.tbV.Name = "tbV";
            this.tbV.Size = new System.Drawing.Size(218, 18);
            this.tbV.TabIndex = 197;
            // 
            // selBrd
            // 
            this.selBrd.BackColor = System.Drawing.Color.Brown;
            this.selBrd.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.selBrd.Font = new System.Drawing.Font("Comic Sans MS", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.selBrd.ForeColor = System.Drawing.Color.DarkRed;
            this.selBrd.Location = new System.Drawing.Point(298, 109);
            this.selBrd.Name = "selBrd";
            this.selBrd.Size = new System.Drawing.Size(24, 16);
            this.selBrd.TabIndex = 195;
            this.selBrd.Visible = false;
            // 
            // tBrdSN
            // 
            this.tBrdSN.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tBrdSN.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBrdSN.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBrdSN.ForeColor = System.Drawing.Color.DarkRed;
            this.tBrdSN.Location = new System.Drawing.Point(96, 62);
            this.tBrdSN.MaxLength = 49;
            this.tBrdSN.Multiline = true;
            this.tBrdSN.Name = "tBrdSN";
            this.tBrdSN.Size = new System.Drawing.Size(185, 18);
            this.tBrdSN.TabIndex = 191;
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.SystemColors.Control;
            this.label66.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label66.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label66.Location = new System.Drawing.Point(8, 64);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(88, 14);
            this.label66.TabIndex = 190;
            this.label66.Text = "Board Serial #:";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tBrdDesc
            // 
            this.tBrdDesc.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tBrdDesc.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tBrdDesc.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBrdDesc.ForeColor = System.Drawing.Color.DarkRed;
            this.tBrdDesc.Location = new System.Drawing.Point(96, 8);
            this.tBrdDesc.MaxLength = 49;
            this.tBrdDesc.Multiline = true;
            this.tBrdDesc.Name = "tBrdDesc";
            this.tBrdDesc.Size = new System.Drawing.Size(152, 18);
            this.tBrdDesc.TabIndex = 189;
            // 
            // label65
            // 
            this.label65.BackColor = System.Drawing.SystemColors.Control;
            this.label65.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label65.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label65.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label65.Location = new System.Drawing.Point(8, 10);
            this.label65.Name = "label65";
            this.label65.Size = new System.Drawing.Size(88, 14);
            this.label65.TabIndex = 188;
            this.label65.Text = "Board Name:";
            this.label65.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // pictureBox5
            // 
            this.pictureBox5.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox5.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox5.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox5.Image")));
            this.pictureBox5.Location = new System.Drawing.Point(832, 16);
            this.pictureBox5.Name = "pictureBox5";
            this.pictureBox5.Size = new System.Drawing.Size(120, 112);
            this.pictureBox5.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox5.TabIndex = 181;
            this.pictureBox5.TabStop = false;
            // 
            // lvBoards
            // 
            this.lvBoards.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.lvBoards.AutoArrange = false;
            this.lvBoards.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lvBoards.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.bord});
            this.lvBoards.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lvBoards.ForeColor = System.Drawing.Color.DarkGreen;
            this.lvBoards.FullRowSelect = true;
            this.lvBoards.GridLines = true;
            this.lvBoards.Location = new System.Drawing.Point(54, 8);
            this.lvBoards.MultiSelect = false;
            this.lvBoards.Name = "lvBoards";
            this.lvBoards.Size = new System.Drawing.Size(442, 120);
            this.lvBoards.TabIndex = 180;
            this.lvBoards.UseCompatibleStateImageBehavior = false;
            this.lvBoards.View = System.Windows.Forms.View.Details;
            // 
            // bord
            // 
            this.bord.Text = "Boards info";
            this.bord.Width = 303;
            // 
            // pic_Modif
            // 
            this.pic_Modif.BackColor = System.Drawing.Color.Transparent;
            this.pic_Modif.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_Modif.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_Modif.Image = ((System.Drawing.Image)(resources.GetObject("pic_Modif.Image")));
            this.pic_Modif.Location = new System.Drawing.Point(665, 10);
            this.pic_Modif.Name = "pic_Modif";
            this.pic_Modif.Size = new System.Drawing.Size(65, 55);
            this.pic_Modif.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_Modif.TabIndex = 202;
            this.pic_Modif.TabStop = false;
            this.pic_Modif.Visible = false;
            // 
            // pic_ManSave
            // 
            this.pic_ManSave.BackColor = System.Drawing.Color.Transparent;
            this.pic_ManSave.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pic_ManSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_ManSave.Image = ((System.Drawing.Image)(resources.GetObject("pic_ManSave.Image")));
            this.pic_ManSave.Location = new System.Drawing.Point(424, 8);
            this.pic_ManSave.Name = "pic_ManSave";
            this.pic_ManSave.Size = new System.Drawing.Size(65, 55);
            this.pic_ManSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_ManSave.TabIndex = 201;
            this.pic_ManSave.TabStop = false;
            this.pic_ManSave.Visible = false;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.groupBox32);
            this.tabPage3.Location = new System.Drawing.Point(4, 23);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(868, 365);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Documents to PRINT";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // groupBox32
            // 
            this.groupBox32.BackColor = System.Drawing.SystemColors.Control;
            this.groupBox32.Controls.Add(this.groupBox33);
            this.groupBox32.Controls.Add(this.grpOpera);
            this.groupBox32.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox32.Location = new System.Drawing.Point(0, 0);
            this.groupBox32.Name = "groupBox32";
            this.groupBox32.Size = new System.Drawing.Size(868, 365);
            this.groupBox32.TabIndex = 1;
            this.groupBox32.TabStop = false;
            // 
            // groupBox33
            // 
            this.groupBox33.Controls.Add(this.elv_docsP);
            this.groupBox33.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox33.Location = new System.Drawing.Point(3, 91);
            this.groupBox33.Name = "groupBox33";
            this.groupBox33.Size = new System.Drawing.Size(862, 271);
            this.groupBox33.TabIndex = 328;
            this.groupBox33.TabStop = false;
            // 
            // elv_docsP
            // 
            this.elv_docsP.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.elv_docsP.AutoArrange = false;
            this.elv_docsP.BackColor = System.Drawing.Color.WhiteSmoke;
            this.elv_docsP.CheckBoxes = true;
            this.elv_docsP.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.DTPid,
            this.DNm,
            this.docPath,
            this.prt});
            this.elv_docsP.Dock = System.Windows.Forms.DockStyle.Fill;
            this.elv_docsP.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.elv_docsP.ForeColor = System.Drawing.Color.Red;
            this.elv_docsP.FullRowSelect = true;
            this.elv_docsP.GridLines = true;
            this.elv_docsP.LabelEdit = true;
            this.elv_docsP.Location = new System.Drawing.Point(3, 16);
            this.elv_docsP.Name = "elv_docsP";
            this.elv_docsP.Size = new System.Drawing.Size(856, 252);
            this.elv_docsP.TabIndex = 380;
            this.elv_docsP.UseCompatibleStateImageBehavior = false;
            this.elv_docsP.View = System.Windows.Forms.View.Details;
            // 
            // DTPid
            // 
            this.DTPid.Text = "OK";
            this.DTPid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.DTPid.Width = 0;
            // 
            // DNm
            // 
            this.DNm.Text = "Documet Name";
            this.DNm.Width = 336;
            // 
            // docPath
            // 
            this.docPath.Text = "Path";
            this.docPath.Width = 564;
            // 
            // prt
            // 
            this.prt.Text = "Printed";
            // 
            // grpOpera
            // 
            this.grpOpera.Controls.Add(this.TS_AGTerr);
            this.grpOpera.Controls.Add(this.picNotPrinted);
            this.grpOpera.Controls.Add(this.picPrinted);
            this.grpOpera.Controls.Add(this.picDelDoc);
            this.grpOpera.Controls.Add(this.picOpen);
            this.grpOpera.Controls.Add(this.ldocs);
            this.grpOpera.Controls.Add(this.picSave);
            this.grpOpera.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpOpera.Location = new System.Drawing.Point(3, 16);
            this.grpOpera.Name = "grpOpera";
            this.grpOpera.Size = new System.Drawing.Size(862, 75);
            this.grpOpera.TabIndex = 327;
            this.grpOpera.TabStop = false;
            // 
            // TS_AGTerr
            // 
            this.TS_AGTerr.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TS_AGTerr.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.New_Docs,
            this.tls_Save,
            this.DelDocs,
            this.RFP,
            this.Pdoc,
            this.Doc_Printed,
            this.Doc_NOTPrinted,
            this.lRateTbl});
            this.TS_AGTerr.Location = new System.Drawing.Point(3, 16);
            this.TS_AGTerr.Name = "TS_AGTerr";
            this.TS_AGTerr.Size = new System.Drawing.Size(856, 54);
            this.TS_AGTerr.TabIndex = 259;
            this.TS_AGTerr.Text = "toolStrip2";
            // 
            // New_Docs
            // 
            this.New_Docs.Image = ((System.Drawing.Image)(resources.GetObject("New_Docs.Image")));
            this.New_Docs.ImageTransparentColor = System.Drawing.Color.Transparent;
            this.New_Docs.Name = "New_Docs";
            this.New_Docs.Size = new System.Drawing.Size(99, 51);
            this.New_Docs.Text = "New Documents";
            this.New_Docs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.New_Docs.Click += new System.EventHandler(this.New_Docs_Click);
            // 
            // tls_Save
            // 
            this.tls_Save.Image = ((System.Drawing.Image)(resources.GetObject("tls_Save.Image")));
            this.tls_Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tls_Save.Name = "tls_Save";
            this.tls_Save.Size = new System.Drawing.Size(92, 51);
            this.tls_Save.Text = "      Save List      ";
            this.tls_Save.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tls_Save.Click += new System.EventHandler(this.tls_Save_Click);
            // 
            // DelDocs
            // 
            this.DelDocs.Image = ((System.Drawing.Image)(resources.GetObject("DelDocs.Image")));
            this.DelDocs.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.DelDocs.Name = "DelDocs";
            this.DelDocs.Size = new System.Drawing.Size(114, 51);
            this.DelDocs.Text = "Delete Documents  ";
            this.DelDocs.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.DelDocs.ToolTipText = "Delete Documents  ";
            this.DelDocs.Click += new System.EventHandler(this.DelDocs_Click);
            // 
            // RFP
            // 
            this.RFP.Image = ((System.Drawing.Image)(resources.GetObject("RFP.Image")));
            this.RFP.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.RFP.Name = "RFP";
            this.RFP.Size = new System.Drawing.Size(88, 51);
            this.RFP.Text = "Ready To Print";
            this.RFP.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.RFP.Click += new System.EventHandler(this.RFP_Click);
            // 
            // Pdoc
            // 
            this.Pdoc.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Pdoc.Image = ((System.Drawing.Image)(resources.GetObject("Pdoc.Image")));
            this.Pdoc.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Pdoc.Name = "Pdoc";
            this.Pdoc.Size = new System.Drawing.Size(146, 51);
            this.Pdoc.Text = "Open Selected Document";
            this.Pdoc.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Pdoc.Click += new System.EventHandler(this.Pdoc_Click);
            // 
            // Doc_Printed
            // 
            this.Doc_Printed.Image = ((System.Drawing.Image)(resources.GetObject("Doc_Printed.Image")));
            this.Doc_Printed.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Doc_Printed.Name = "Doc_Printed";
            this.Doc_Printed.Size = new System.Drawing.Size(49, 51);
            this.Doc_Printed.Text = "Printed";
            this.Doc_Printed.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Doc_Printed.Click += new System.EventHandler(this.Doc_Printed_Click);
            // 
            // Doc_NOTPrinted
            // 
            this.Doc_NOTPrinted.Image = ((System.Drawing.Image)(resources.GetObject("Doc_NOTPrinted.Image")));
            this.Doc_NOTPrinted.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Doc_NOTPrinted.Name = "Doc_NOTPrinted";
            this.Doc_NOTPrinted.Size = new System.Drawing.Size(77, 51);
            this.Doc_NOTPrinted.Text = "NOT Printed";
            this.Doc_NOTPrinted.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.Doc_NOTPrinted.Click += new System.EventHandler(this.Doc_NOTPrinted_Click);
            // 
            // lRateTbl
            // 
            this.lRateTbl.ForeColor = System.Drawing.Color.Red;
            this.lRateTbl.Name = "lRateTbl";
            this.lRateTbl.Size = new System.Drawing.Size(133, 51);
            this.lRateTbl.Text = "dddddddddddddddddd";
            this.lRateTbl.Visible = false;
            // 
            // picNotPrinted
            // 
            this.picNotPrinted.BackColor = System.Drawing.Color.Transparent;
            this.picNotPrinted.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picNotPrinted.Image = ((System.Drawing.Image)(resources.GetObject("picNotPrinted.Image")));
            this.picNotPrinted.Location = new System.Drawing.Point(78, 98);
            this.picNotPrinted.Name = "picNotPrinted";
            this.picNotPrinted.Size = new System.Drawing.Size(21, 47);
            this.picNotPrinted.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picNotPrinted.TabIndex = 241;
            this.picNotPrinted.TabStop = false;
            // 
            // picPrinted
            // 
            this.picPrinted.BackColor = System.Drawing.Color.Transparent;
            this.picPrinted.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picPrinted.Image = ((System.Drawing.Image)(resources.GetObject("picPrinted.Image")));
            this.picPrinted.Location = new System.Drawing.Point(15, 98);
            this.picPrinted.Name = "picPrinted";
            this.picPrinted.Size = new System.Drawing.Size(21, 47);
            this.picPrinted.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picPrinted.TabIndex = 240;
            this.picPrinted.TabStop = false;
            // 
            // picDelDoc
            // 
            this.picDelDoc.BackColor = System.Drawing.Color.Transparent;
            this.picDelDoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDelDoc.Image = ((System.Drawing.Image)(resources.GetObject("picDelDoc.Image")));
            this.picDelDoc.Location = new System.Drawing.Point(132, 99);
            this.picDelDoc.Name = "picDelDoc";
            this.picDelDoc.Size = new System.Drawing.Size(21, 47);
            this.picDelDoc.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDelDoc.TabIndex = 239;
            this.picDelDoc.TabStop = false;
            // 
            // picOpen
            // 
            this.picOpen.BackColor = System.Drawing.Color.Transparent;
            this.picOpen.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picOpen.Image = ((System.Drawing.Image)(resources.GetObject("picOpen.Image")));
            this.picOpen.Location = new System.Drawing.Point(42, 98);
            this.picOpen.Name = "picOpen";
            this.picOpen.Size = new System.Drawing.Size(21, 47);
            this.picOpen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picOpen.TabIndex = 238;
            this.picOpen.TabStop = false;
            // 
            // ldocs
            // 
            this.ldocs.BackColor = System.Drawing.Color.Lime;
            this.ldocs.Location = new System.Drawing.Point(6, 18);
            this.ldocs.Name = "ldocs";
            this.ldocs.Size = new System.Drawing.Size(66, 23);
            this.ldocs.TabIndex = 237;
            this.ldocs.Visible = false;
            // 
            // picSave
            // 
            this.picSave.BackColor = System.Drawing.Color.Transparent;
            this.picSave.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSave.Image = ((System.Drawing.Image)(resources.GetObject("picSave.Image")));
            this.picSave.Location = new System.Drawing.Point(105, 99);
            this.picSave.Name = "picSave";
            this.picSave.Size = new System.Drawing.Size(21, 46);
            this.picSave.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSave.TabIndex = 236;
            this.picSave.TabStop = false;
            // 
            // imageList16_stat
            // 
            this.imageList16_stat.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList16_stat.ImageStream")));
            this.imageList16_stat.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList16_stat.Images.SetKeyName(0, "remove.png");
            this.imageList16_stat.Images.SetKeyName(1, "accept.png");
            // 
            // grp2_Rect_info
            // 
            this.grp2_Rect_info.Controls.Add(this.ed_lvBRD);
            this.grp2_Rect_info.Controls.Add(this.lM);
            this.grp2_Rect_info.Controls.Add(this.lS);
            this.grp2_Rect_info.Controls.Add(this.txSTKnb);
            this.grp2_Rect_info.Controls.Add(this.st_sTR);
            this.grp2_Rect_info.Controls.Add(this.label1);
            this.grp2_Rect_info.Controls.Add(this.TRcmnt);
            this.grp2_Rect_info.Controls.Add(this.gifHere);
            this.grp2_Rect_info.Controls.Add(this.st_NE);
            this.grp2_Rect_info.Controls.Add(this.label86);
            this.grp2_Rect_info.Controls.Add(this.label115);
            this.grp2_Rect_info.Controls.Add(this.tTRuser);
            this.grp2_Rect_info.Controls.Add(this.label114);
            this.grp2_Rect_info.Controls.Add(this.picTM);
            this.grp2_Rect_info.Controls.Add(this.lTRstat);
            this.grp2_Rect_info.Controls.Add(this.label105);
            this.grp2_Rect_info.Controls.Add(this.label90);
            this.grp2_Rect_info.Controls.Add(this.PX_Model);
            this.grp2_Rect_info.Controls.Add(this.label87);
            this.grp2_Rect_info.Controls.Add(this.tcust_Model);
            this.grp2_Rect_info.Controls.Add(this.btnSTK);
            this.grp2_Rect_info.Controls.Add(this.label5);
            this.grp2_Rect_info.Controls.Add(this.dpTRdate);
            this.grp2_Rect_info.Controls.Add(this.lTRdate);
            this.grp2_Rect_info.Controls.Add(this.CBSerItems);
            this.grp2_Rect_info.Controls.Add(this.lItemSer);
            this.grp2_Rect_info.Dock = System.Windows.Forms.DockStyle.Top;
            this.grp2_Rect_info.Location = new System.Drawing.Point(3, 16);
            this.grp2_Rect_info.Name = "grp2_Rect_info";
            this.grp2_Rect_info.Size = new System.Drawing.Size(886, 120);
            this.grp2_Rect_info.TabIndex = 1;
            this.grp2_Rect_info.TabStop = false;
            // 
            // ed_lvBRD
            // 
            this.ed_lvBRD.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_lvBRD.AutoArrange = false;
            this.ed_lvBRD.BackColor = System.Drawing.Color.WhiteSmoke;
            this.ed_lvBRD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.brdLID,
            this.bDesc,
            this.Bver,
            this.FWver,
            this.BOMrev,
            this.PCBdat,
            this.Assmbdat,
            this.bSN,
            this.Con,
            this.manual});
            this.ed_lvBRD.Font = new System.Drawing.Font("Tahoma", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_lvBRD.ForeColor = System.Drawing.Color.Red;
            this.ed_lvBRD.FullRowSelect = true;
            this.ed_lvBRD.GridLines = true;
            this.ed_lvBRD.Location = new System.Drawing.Point(631, 11);
            this.ed_lvBRD.Name = "ed_lvBRD";
            this.ed_lvBRD.Size = new System.Drawing.Size(245, 103);
            this.ed_lvBRD.TabIndex = 343;
            this.ed_lvBRD.UseCompatibleStateImageBehavior = false;
            this.ed_lvBRD.View = System.Windows.Forms.View.Details;
            this.ed_lvBRD.Visible = false;
            // 
            // brdLID
            // 
            this.brdLID.Text = "";
            this.brdLID.Width = 0;
            // 
            // bDesc
            // 
            this.bDesc.Text = "Board Name";
            this.bDesc.Width = 91;
            // 
            // Bver
            // 
            this.Bver.Text = "";
            this.Bver.Width = 0;
            // 
            // FWver
            // 
            this.FWver.Text = "Firmware Version";
            this.FWver.Width = 0;
            // 
            // BOMrev
            // 
            this.BOMrev.Text = "BOM revision";
            this.BOMrev.Width = 0;
            // 
            // PCBdat
            // 
            this.PCBdat.Text = "PCB date";
            this.PCBdat.Width = 0;
            // 
            // Assmbdat
            // 
            this.Assmbdat.Text = "Assembley Date";
            this.Assmbdat.Width = 0;
            // 
            // bSN
            // 
            this.bSN.Text = "Board SN";
            this.bSN.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.bSN.Width = 132;
            // 
            // Con
            // 
            this.Con.Text = "Connected TO";
            this.Con.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Con.Width = 0;
            // 
            // manual
            // 
            this.manual.Text = "Manual";
            this.manual.Width = 0;
            // 
            // lM
            // 
            this.lM.BackColor = System.Drawing.Color.Red;
            this.lM.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lM.Location = new System.Drawing.Point(594, 8);
            this.lM.Name = "lM";
            this.lM.Size = new System.Drawing.Size(12, 16);
            this.lM.TabIndex = 342;
            this.lM.Text = "0";
            this.lM.Visible = false;
            // 
            // lS
            // 
            this.lS.BackColor = System.Drawing.Color.Red;
            this.lS.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lS.Location = new System.Drawing.Point(612, 10);
            this.lS.Name = "lS";
            this.lS.Size = new System.Drawing.Size(12, 16);
            this.lS.TabIndex = 341;
            this.lS.Text = "0";
            this.lS.Visible = false;
            // 
            // txSTKnb
            // 
            this.txSTKnb.BackColor = System.Drawing.Color.Red;
            this.txSTKnb.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txSTKnb.ForeColor = System.Drawing.Color.White;
            this.txSTKnb.Location = new System.Drawing.Point(335, 30);
            this.txSTKnb.MaxLength = 2;
            this.txSTKnb.Name = "txSTKnb";
            this.txSTKnb.Size = new System.Drawing.Size(53, 20);
            this.txSTKnb.TabIndex = 338;
            this.txSTKnb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txSTKnb.TextChanged += new System.EventHandler(this.txSTKnb_TextChanged);
            this.txSTKnb.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txSTKnb_KeyPress);
            // 
            // st_sTR
            // 
            this.st_sTR.BackColor = System.Drawing.Color.CornflowerBlue;
            this.st_sTR.ForeColor = System.Drawing.SystemColors.ControlText;
            this.st_sTR.Location = new System.Drawing.Point(533, 9);
            this.st_sTR.Name = "st_sTR";
            this.st_sTR.Size = new System.Drawing.Size(12, 16);
            this.st_sTR.TabIndex = 337;
            this.st_sTR.Text = "0";
            this.st_sTR.Visible = false;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(403, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(104, 16);
            this.label1.TabIndex = 335;
            this.label1.Text = "Main test Comments:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            // 
            // TRcmnt
            // 
            this.TRcmnt.BackColor = System.Drawing.Color.Lavender;
            this.TRcmnt.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.TRcmnt.ForeColor = System.Drawing.SystemColors.ControlText;
            this.TRcmnt.Location = new System.Drawing.Point(394, 30);
            this.TRcmnt.MaxLength = 0;
            this.TRcmnt.Multiline = true;
            this.TRcmnt.Name = "TRcmnt";
            this.TRcmnt.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.TRcmnt.Size = new System.Drawing.Size(231, 83);
            this.TRcmnt.TabIndex = 334;
            // 
            // gifHere
            // 
            this.gifHere.Image = ((System.Drawing.Image)(resources.GetObject("gifHere.Image")));
            this.gifHere.Location = new System.Drawing.Point(245, 10);
            this.gifHere.Name = "gifHere";
            this.gifHere.Size = new System.Drawing.Size(27, 20);
            this.gifHere.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.gifHere.TabIndex = 332;
            this.gifHere.TabStop = false;
            this.gifHere.Visible = false;
            // 
            // st_NE
            // 
            this.st_NE.BackColor = System.Drawing.Color.CornflowerBlue;
            this.st_NE.ForeColor = System.Drawing.SystemColors.ControlText;
            this.st_NE.Location = new System.Drawing.Point(513, 11);
            this.st_NE.Name = "st_NE";
            this.st_NE.Size = new System.Drawing.Size(14, 16);
            this.st_NE.TabIndex = 331;
            this.st_NE.Text = "E";
            this.st_NE.Visible = false;
            // 
            // label86
            // 
            this.label86.BackColor = System.Drawing.SystemColors.Control;
            this.label86.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label86.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label86.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label86.Location = new System.Drawing.Point(20, 11);
            this.label86.Name = "label86";
            this.label86.Size = new System.Drawing.Size(72, 16);
            this.label86.TabIndex = 328;
            this.label86.Text = "Rectifier S/N:";
            this.label86.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label115
            // 
            this.label115.BackColor = System.Drawing.SystemColors.Control;
            this.label115.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label115.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label115.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label115.Location = new System.Drawing.Point(228, 72);
            this.label115.Name = "label115";
            this.label115.Size = new System.Drawing.Size(63, 16);
            this.label115.TabIndex = 325;
            this.label115.Text = "Last Change:";
            this.label115.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tTRuser
            // 
            this.tTRuser.BackColor = System.Drawing.Color.AliceBlue;
            this.tTRuser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.tTRuser.Font = new System.Drawing.Font("Courier New", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tTRuser.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tTRuser.Location = new System.Drawing.Point(92, 92);
            this.tTRuser.MaxLength = 49;
            this.tTRuser.Name = "tTRuser";
            this.tTRuser.ReadOnly = true;
            this.tTRuser.Size = new System.Drawing.Size(296, 21);
            this.tTRuser.TabIndex = 324;
            // 
            // label114
            // 
            this.label114.BackColor = System.Drawing.SystemColors.Control;
            this.label114.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label114.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label114.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label114.Location = new System.Drawing.Point(35, 94);
            this.label114.Name = "label114";
            this.label114.Size = new System.Drawing.Size(57, 16);
            this.label114.TabIndex = 323;
            this.label114.Text = "Done by: ";
            this.label114.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // picTM
            // 
            this.picTM.Image = ((System.Drawing.Image)(resources.GetObject("picTM.Image")));
            this.picTM.Location = new System.Drawing.Point(551, 8);
            this.picTM.Name = "picTM";
            this.picTM.Size = new System.Drawing.Size(28, 22);
            this.picTM.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picTM.TabIndex = 322;
            this.picTM.TabStop = false;
            this.picTM.Visible = false;
            // 
            // lTRstat
            // 
            this.lTRstat.BackColor = System.Drawing.Color.AliceBlue;
            this.lTRstat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lTRstat.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lTRstat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTRstat.ForeColor = System.Drawing.Color.Red;
            this.lTRstat.Location = new System.Drawing.Point(92, 70);
            this.lTRstat.Name = "lTRstat";
            this.lTRstat.Size = new System.Drawing.Size(130, 22);
            this.lTRstat.TabIndex = 321;
            this.lTRstat.Text = "N/C";
            this.lTRstat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label105
            // 
            this.label105.BackColor = System.Drawing.SystemColors.Control;
            this.label105.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label105.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label105.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label105.Location = new System.Drawing.Point(27, 72);
            this.label105.Name = "label105";
            this.label105.Size = new System.Drawing.Size(64, 16);
            this.label105.TabIndex = 320;
            this.label105.Text = "Tests Status:";
            this.label105.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label90
            // 
            this.label90.BackColor = System.Drawing.SystemColors.Control;
            this.label90.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label90.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label90.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label90.Location = new System.Drawing.Point(11, 32);
            this.label90.Name = "label90";
            this.label90.Size = new System.Drawing.Size(80, 16);
            this.label90.TabIndex = 319;
            this.label90.Text = "Primax Model:";
            this.label90.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // PX_Model
            // 
            this.PX_Model.BackColor = System.Drawing.Color.Lavender;
            this.PX_Model.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PX_Model.ForeColor = System.Drawing.SystemColors.ControlText;
            this.PX_Model.Location = new System.Drawing.Point(92, 30);
            this.PX_Model.MaxLength = 0;
            this.PX_Model.Name = "PX_Model";
            this.PX_Model.Size = new System.Drawing.Size(243, 20);
            this.PX_Model.TabIndex = 318;
            // 
            // label87
            // 
            this.label87.BackColor = System.Drawing.SystemColors.Control;
            this.label87.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label87.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label87.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label87.Location = new System.Drawing.Point(11, 52);
            this.label87.Name = "label87";
            this.label87.Size = new System.Drawing.Size(80, 16);
            this.label87.TabIndex = 317;
            this.label87.Text = "Customer Model:";
            this.label87.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tcust_Model
            // 
            this.tcust_Model.BackColor = System.Drawing.Color.Lavender;
            this.tcust_Model.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tcust_Model.ForeColor = System.Drawing.SystemColors.ControlText;
            this.tcust_Model.Location = new System.Drawing.Point(92, 50);
            this.tcust_Model.MaxLength = 0;
            this.tcust_Model.Name = "tcust_Model";
            this.tcust_Model.Size = new System.Drawing.Size(296, 20);
            this.tcust_Model.TabIndex = 316;
            // 
            // btnSTK
            // 
            this.btnSTK.Location = new System.Drawing.Point(335, 10);
            this.btnSTK.Name = "btnSTK";
            this.btnSTK.Size = new System.Drawing.Size(53, 22);
            this.btnSTK.TabIndex = 340;
            this.btnSTK.Text = "Stack #";
            this.btnSTK.UseVisualStyleBackColor = true;
            this.btnSTK.Visible = false;
            this.btnSTK.Click += new System.EventHandler(this.btnSTK_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(335, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(53, 16);
            this.label5.TabIndex = 339;
            this.label5.Text = "Stack #";
            this.label5.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            // 
            // dpTRdate
            // 
            this.dpTRdate.CalendarMonthBackground = System.Drawing.Color.Lavender;
            this.dpTRdate.CalendarTitleBackColor = System.Drawing.Color.Lavender;
            this.dpTRdate.CalendarTitleForeColor = System.Drawing.SystemColors.ControlText;
            this.dpTRdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dpTRdate.Location = new System.Drawing.Point(292, 70);
            this.dpTRdate.Name = "dpTRdate";
            this.dpTRdate.Size = new System.Drawing.Size(96, 20);
            this.dpTRdate.TabIndex = 326;
            this.dpTRdate.ValueChanged += new System.EventHandler(this.dpTRdate_ValueChanged);
            // 
            // lTRdate
            // 
            this.lTRdate.BackColor = System.Drawing.Color.AliceBlue;
            this.lTRdate.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lTRdate.ForeColor = System.Drawing.Color.DarkRed;
            this.lTRdate.Location = new System.Drawing.Point(292, 70);
            this.lTRdate.MaxLength = 49;
            this.lTRdate.Name = "lTRdate";
            this.lTRdate.ReadOnly = true;
            this.lTRdate.Size = new System.Drawing.Size(96, 21);
            this.lTRdate.TabIndex = 327;
            this.lTRdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CBSerItems
            // 
            this.CBSerItems.BackColor = System.Drawing.Color.Lavender;
            this.CBSerItems.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CBSerItems.ForeColor = System.Drawing.SystemColors.ControlText;
            this.CBSerItems.Location = new System.Drawing.Point(92, 9);
            this.CBSerItems.Name = "CBSerItems";
            this.CBSerItems.Size = new System.Drawing.Size(153, 21);
            this.CBSerItems.TabIndex = 329;
            this.CBSerItems.Visible = false;
            this.CBSerItems.SelectedIndexChanged += new System.EventHandler(this.CBSerItems_SelectedIndexChanged);
            this.CBSerItems.SelectedValueChanged += new System.EventHandler(this.CBSerItems_SelectedValueChanged);
            // 
            // lItemSer
            // 
            this.lItemSer.BackColor = System.Drawing.Color.AliceBlue;
            this.lItemSer.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lItemSer.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.lItemSer.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold);
            this.lItemSer.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lItemSer.Location = new System.Drawing.Point(92, 10);
            this.lItemSer.Name = "lItemSer";
            this.lItemSer.Size = new System.Drawing.Size(153, 20);
            this.lItemSer.TabIndex = 330;
            this.lItemSer.TextAlign = System.Drawing.ContentAlignment.BottomLeft;
            this.lItemSer.Click += new System.EventHandler(this.lItemSer_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.tvTR);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox1.Location = new System.Drawing.Point(3, 16);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(230, 562);
            this.groupBox1.TabIndex = 252;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Rectifier Reports";
            // 
            // tvTR
            // 
            this.tvTR.BackColor = System.Drawing.Color.WhiteSmoke;
            this.tvTR.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tvTR.Font = new System.Drawing.Font("Comic Sans MS", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tvTR.ForeColor = System.Drawing.Color.Blue;
            this.tvTR.FullRowSelect = true;
            this.tvTR.ImageIndex = 0;
            this.tvTR.ImageList = this.imageList216;
            this.tvTR.LabelEdit = true;
            this.tvTR.Location = new System.Drawing.Point(3, 16);
            this.tvTR.Name = "tvTR";
            this.tvTR.SelectedImageIndex = 0;
            this.tvTR.Size = new System.Drawing.Size(224, 543);
            this.tvTR.TabIndex = 248;
            this.tvTR.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.tvTR_AfterSelect);
            // 
            // imageList216
            // 
            this.imageList216.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList216.ImageStream")));
            this.imageList216.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList216.Images.SetKeyName(0, "");
            this.imageList216.Images.SetKeyName(1, "");
            this.imageList216.Images.SetKeyName(2, "");
            this.imageList216.Images.SetKeyName(3, "");
            this.imageList216.Images.SetKeyName(4, "");
            this.imageList216.Images.SetKeyName(5, "");
            this.imageList216.Images.SetKeyName(6, "");
            this.imageList216.Images.SetKeyName(7, "");
            this.imageList216.Images.SetKeyName(8, "");
            this.imageList216.Images.SetKeyName(9, "");
            this.imageList216.Images.SetKeyName(10, "");
            this.imageList216.Images.SetKeyName(11, "");
            this.imageList216.Images.SetKeyName(12, "");
            this.imageList216.Images.SetKeyName(13, "");
            this.imageList216.Images.SetKeyName(14, "");
            this.imageList216.Images.SetKeyName(15, "");
            this.imageList216.Images.SetKeyName(16, "");
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(549, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // grpConf
            // 
            this.grpConf.Controls.Add(this.picCIP);
            this.grpConf.Controls.Add(this.button1);
            this.grpConf.Controls.Add(this.TSmain);
            this.grpConf.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpConf.Location = new System.Drawing.Point(0, 0);
            this.grpConf.Name = "grpConf";
            this.grpConf.Size = new System.Drawing.Size(1128, 63);
            this.grpConf.TabIndex = 240;
            this.grpConf.TabStop = false;
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(1029, 18);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(39, 37);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 269;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // TSmain
            // 
            this.TSmain.ImageScalingSize = new System.Drawing.Size(32, 32);
            this.TSmain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.NewTR,
            this.del_RTR,
            this.Save,
            this.picPrintRTR,
            this.toolStripButton1,
            this.toolStripButton2,
            this.errr});
            this.TSmain.Location = new System.Drawing.Point(3, 16);
            this.TSmain.Name = "TSmain";
            this.TSmain.Size = new System.Drawing.Size(1122, 39);
            this.TSmain.TabIndex = 257;
            // 
            // NewTR
            // 
            this.NewTR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.NewTR.Image = ((System.Drawing.Image)(resources.GetObject("NewTR.Image")));
            this.NewTR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.NewTR.Name = "NewTR";
            this.NewTR.Size = new System.Drawing.Size(36, 36);
            this.NewTR.Text = "Schedule all";
            this.NewTR.ToolTipText = "New Test Report";
            this.NewTR.Click += new System.EventHandler(this.NewTR_Click);
            // 
            // del_RTR
            // 
            this.del_RTR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.del_RTR.Image = ((System.Drawing.Image)(resources.GetObject("del_RTR.Image")));
            this.del_RTR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.del_RTR.Name = "del_RTR";
            this.del_RTR.Size = new System.Drawing.Size(36, 36);
            this.del_RTR.Text = "Disable sub-project";
            this.del_RTR.ToolTipText = "Delete Test Report";
            this.del_RTR.Click += new System.EventHandler(this.del_RTR_Click);
            // 
            // Save
            // 
            this.Save.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.Save.Image = ((System.Drawing.Image)(resources.GetObject("Save.Image")));
            this.Save.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(36, 36);
            this.Save.Text = "Save";
            this.Save.ToolTipText = "Save Test Report";
            this.Save.Click += new System.EventHandler(this.Save_Click);
            // 
            // picPrintRTR
            // 
            this.picPrintRTR.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.picPrintRTR.Image = ((System.Drawing.Image)(resources.GetObject("picPrintRTR.Image")));
            this.picPrintRTR.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.picPrintRTR.Name = "picPrintRTR";
            this.picPrintRTR.Size = new System.Drawing.Size(36, 36);
            this.picPrintRTR.Text = "pick";
            this.picPrintRTR.ToolTipText = "Excel export";
            this.picPrintRTR.Click += new System.EventHandler(this.picPrintRTR_Click);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.ToolTipText = "Checked";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(36, 36);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.ToolTipText = "Unchecked";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // errr
            // 
            this.errr.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.errr.Image = ((System.Drawing.Image)(resources.GetObject("errr.Image")));
            this.errr.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.errr.Name = "errr";
            this.errr.Size = new System.Drawing.Size(36, 36);
            this.errr.Text = "Print";
            this.errr.ToolTipText = "Print ";
            this.errr.Click += new System.EventHandler(this.errr_Click);
            // 
            // openFileDialog3
            // 
            this.openFileDialog3.FileName = "openFileDialog2";
            this.openFileDialog3.Multiselect = true;
            // 
            // Rectif_TR
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(1128, 644);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.grpConf);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Rectif_TR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RECTIFIER tests report";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Rectif_TR_Load);
            this.Resize += new System.EventHandler(this.Rectif_TR_Resize);
            this.groupBox3.ResumeLayout(false);
            this.grp1.ResumeLayout(false);
            this.grp_list.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.grp3.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.grp4.ResumeLayout(false);
            this.groupBox4.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.grpBrd_man.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pic_BManag)).EndInit();
            this.groupBox31.ResumeLayout(false);
            this.groupBox30.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.ww)).EndInit();
            this.groupBox6.ResumeLayout(false);
            this.grpCard.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSaveBRD)).EndInit();
            this.grpBrdSN.ResumeLayout(false);
            this.grpBrdSN.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picAdd)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_Modif)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_ManSave)).EndInit();
            this.tabPage3.ResumeLayout(false);
            this.groupBox32.ResumeLayout(false);
            this.groupBox33.ResumeLayout(false);
            this.grpOpera.ResumeLayout(false);
            this.grpOpera.PerformLayout();
            this.TS_AGTerr.ResumeLayout(false);
            this.TS_AGTerr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picNotPrinted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picPrinted)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picDelDoc)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picOpen)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSave)).EndInit();
            this.grp2_Rect_info.ResumeLayout(false);
            this.grp2_Rect_info.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gifHere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picTM)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.grpConf.ResumeLayout(false);
            this.grpConf.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.TSmain.ResumeLayout(false);
            this.TSmain.PerformLayout();
            this.ResumeLayout(false);

        }
        #endregion

        private void dataGrid1_Navigate(object sender, System.Windows.Forms.NavigateEventArgs ne)
        {

        }

        private void init_RTR_Info()
        {
            /*
              lTRLID.Text = "";
            
              
              lbrdNm.Text = "";
              lbrdVer.Text = "";
              lbrdSoftV.Text = "";
              tTRuser.Clear();
           
              TecVMainSn.Text = "";
          
              lowner2.Clear();
              lvIOTest.Items.Clear();
              MLV_ChkList.Items.Clear();
              lvLTest.Items.Clear();
              MLV_EqAlrm.Items.Clear();
            
              cbSerItems.Items.Clear();
             * */


            //   TRLsn.Text = "";
            dpTRdate.Text = System.DateTime.Now.ToShortDateString();
            lTRLID = ""; 
            tcust_Model.Clear();
            PX_Model.Clear();
            lTRstat.Text = "N/C";
            tTRuser.Clear();
            txSTKnb.Text = ""; txSTKnb.ReadOnly = false;
            TRcmnt.Clear();
            
            st_NE.Text = "E";                  //MessageBox.Show("nbcol= " + ed_lvMtst.Columns.Count.ToString() + "\n nbcol stps= " + ed_LVStps.Columns.Count.ToString());
            ed_lvMtst.Items.Clear();
            ed_LVStps.Items.Clear();
            ed_LVOthers.Items.Clear();
            ed_lvBRD.Items.Clear();
         //   MessageBox.Show("nbcol= " + ed_lvMtst.Columns.Count.ToString() + "\n nbcol stps= " + ed_LVStps.Columns.Count.ToString());

        }
        private void load_CurTR()
        {
/*
            string stSql = " SELECT     *, PSM_R_TRInfo.*, PSM_R_TRDetail.* " +
                " FROM  PSM_R_TRInfo INNER JOIN   PSM_R_TRDetail ON PSM_R_TRInfo.tr_LID = PSM_R_TRDetail.d_TR_LID " +
                " WHERE     PSM_R_TRInfo.tr_iRRevID =" + lIRRevID.Text + " AND PSM_R_TRInfo.tr_TRName = '" + lcurTRNm.Text +
                "' ORDER BY PSM_R_TRDetail.d_TR_Ttyp, PSM_R_TRDetail.d_TR_Rnk ";


            //	SELECT     PSM_R_CFDetail.*, PSM_R_CFinfo.CFLID ,PSM_R_CFinfo.c_date,PSM_R_CFinfo.c_SN FROM  PSM_R_CFDetail INNER JOIN  PSM_R_CFinfo ON PSM_R_CFDetail.d_CFLID = PSM_R_CFinfo.CFLID " +
            //	" WHERE     PSM_R_CFinfo.ConfigNm = '" + lcurConfNm.Text + "' AND PSM_R_CFinfo.c_RRevLID =" + lIRRevID.Text + " ORDER BY PSM_R_CFDetail.d_Rnk ";
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
                    lTRLID.Text = Oreadr["tr_LID"].ToString();
                    lItemSer.Text = Oreadr["tr_ConfNm"].ToString();
                    int ipos = lItemSer.Text.IndexOf("-S") + 1;
                    TRLsn.Text = lItemSer.Text.Substring(ipos, lItemSer.Text.Length - ipos);
                    string t1 = "", t2 = "", t3 = "", t4 = "";
                    stSql = "SELECT PSM_Boards.brd_Desc, PSM_Boards.brd_SN  " +
                        " FROM  PSM_R_CFinfo INNER JOIN  PSM_R_Detail ON PSM_R_CFinfo.c_RRevLID = PSM_R_Detail.IRRev_LID INNER JOIN " +
                        " PSM_Boards ON PSM_R_Detail.Rdetail_LID = PSM_Boards.b_RRevDetLID " +
                        " WHERE     (PSM_R_CFinfo.ConfigNm = '" + lItemSer.Text + "') AND (PSM_R_Detail.PrimaxSN ='" + TRLsn.Text + "' )";
                    string BRD = "", r_brdSN = "";
                    MainMDI.Find_2_Field(stSql, ref BRD, ref r_brdSN);
                    //	get_BoardInfo( MainMDI.Find_One_Field(stSql) ,ref t1,ref t2,ref t3,ref t4);
                    //	get_BoardInfo( BRD ,ref t1,ref t2,ref t3,ref t4);
                    //	lbrdNm.Text =t1;
                    //	lbrdVer.Text = t2;
                    //	lbrdSoftV.Text = t3; 
                    //	lConTO.Text = t4; 
                    string[] ar_T = new string[6];
                    get_BoardInfo(BRD, ref ar_T);
                    lbrdNm.Text = ar_T[0]; lbrdVer.Text = ar_T[1]; lbrdSoftV.Text = ar_T[2];
                    lConTO.Text = ar_T[3];
                    Lman.Text = ar_T[4];
                    lBsn.Text = r_brdSN;
                    tTRuser.Text = Oreadr["tr_TesterNm"].ToString();
                    dpTRdate.Text = Oreadr["tr_Date"].ToString();
                    TRcmnt.Text = Oreadr["tr_Cmnt"].ToString();
                    t1 = Oreadr["tr_Cust_Model"].ToString();
                    ipos = t1.IndexOf("||");
                    if (ipos > -1)
                    {
                        PX_Model.Text = t1.Substring(0, ipos);
                        tcust_Model.Text = t1.Substring(ipos + 2, t1.Length - (ipos + 2));
                    }
                    else
                    {
                        PX_Model.Text = t1;
                        tcust_Model.Text = MainMDI.VIDE;

                    }
                    TR_UserList();
                    filled = true;
                }
                string st = ""; int imgNdx = 0;
                switch (Oreadr["d_TR_Tstat"].ToString())
                {
                    case "C":
                        //	st="checked";
                        imgNdx = 8;
                        break;
                    case "U":
                        //	st="Unchecked";
                        imgNdx = 9;
                        break;
                }

                ListViewItem lv = null;
                switch (Oreadr["d_TR_Ttyp"].ToString())
                {
                    case "I":
                    case "L":
                        lv = (Oreadr["d_TR_Ttyp"].ToString() == "I") ? lvIOTest.Items.Add(st) : lvLTest.Items.Add(st);
                        lv.ImageIndex = imgNdx;
                        lv.SubItems.Add(((Oreadr["d_TR_TName"].ToString() != "") ? Oreadr["d_TR_TName"].ToString() : " "));  //desc  ndx=1
                        lv.SubItems.Add(((Oreadr["d_TecVALreq"].ToString() != "") ? Oreadr["d_TecVALreq"].ToString() : " "));
                        lv.SubItems.Add(((Oreadr["d_TecVALTST"].ToString() != "") ? Oreadr["d_TecVALTST"].ToString() : " "));
                        lv.SubItems.Add(((Oreadr["d_TR_Cmnt"].ToString() != "") ? Oreadr["d_TR_Cmnt"].ToString() : " "));  //cmnt
                        lv.SubItems.Add(Oreadr["d_trDetLID"].ToString()); //tr_detail_LID
                        lv.UseItemStyleForSubItems = false;
                        lv.SubItems[3].BackColor = Color.Violet;
                        break;
                    case "E":
                    case "M":
                    case "O":
                        string unDV = "", unDY = "", unRY = "", unTO = "", UNx = "";
                        TestEQA TEA = new TestEQA(TecVMainSn.Text);
                        lv = MLV_EqAlrm.Items.Add(st);
                        lv.ImageIndex = imgNdx;
                        lv.SubItems.Add(Oreadr["d_TR_TName"].ToString());  //desc  ndx=1
                        //C_DV 
                        //			st = TEA.boolToCar(TEA.look_Req_Value("C_DV",Oreadr["d_TecVALreq"].ToString(),'A'),'T',ref unDV,'F');if (unDV!="") unDV= " "+ unDV;lv.SubItems.Add(st+ unDV );
                        //			st = TEA.boolToCar(TEA.look_Req_Value("C_DV",Oreadr["d_TecVALTST"].ToString(),'A'),'T',ref unDV,'F');lv.SubItems.Add(st);
                        st = TEA.boolToCar(TEA.look_Req_Value("C_DV", Oreadr["d_TecVALreq"].ToString(), 'A'), 'T', ref unDV, 'F'); lv.SubItems.Add(st);
                        st = TEA.boolToCar(TEA.look_Req_Value("C_DV", Oreadr["d_TecVALTST"].ToString(), 'A'), 'T', ref unDV, 'F'); lv.SubItems.Add(st);

                        //C_DY 
                        st = TEA.boolToCar(TEA.look_Req_Value("C_DY", Oreadr["d_TecVALreq"].ToString(), 'A'), 'T', ref unDY, 'F'); if (unDY != "") unDY = " " + unDY; lv.SubItems.Add(st + unDY);
                        //	st = TEA.boolToCar(TEA.look_Req_Value("C_DY",Oreadr["d_TecVALreq"].ToString(),'A'),'T',ref unDY,'F');lv.SubItems.Add(st );
                        st = TEA.boolToCar(TEA.look_Req_Value("C_DY", Oreadr["d_TecVALTST"].ToString(), 'A'), 'T', ref unDY, 'F'); lv.SubItems.Add(st);

                        //C_RY 
                        st = TEA.boolToCar(TEA.look_Req_Value("C_RY", Oreadr["d_TecVALreq"].ToString(), 'A'), 'T', ref unRY, 'F'); if (unRY != "") unRY = " " + unRY; lv.SubItems.Add(st + unRY);
                        //	st = TEA.boolToCar(TEA.look_Req_Value("C_RY",Oreadr["d_TecVALreq"].ToString(),'A'),'T',ref unRY,'F');lv.SubItems.Add(st );
                        st = TEA.boolToCar(TEA.look_Req_Value("C_RY", Oreadr["d_TecVALTST"].ToString(), 'A'), 'T', ref unRY, 'F'); lv.SubItems.Add(st);

                        //C_TO 
                        st = TEA.boolToCar(TEA.look_Req_Value("C_TO", Oreadr["d_TecVALreq"].ToString(), 'A'), 'T', ref unTO, 'F'); if (unTO != "") unTO = " " + unTO; lv.SubItems.Add(st + unTO);
                        st = TEA.boolToCar(TEA.look_Req_Value("C_TO", Oreadr["d_TecVALTST"].ToString(), 'A'), 'T', ref unTO, 'F'); lv.SubItems.Add(st);

                        //C_ML 
                        st = TEA.boolToCar(TEA.look_Req_Value("C_ML", Oreadr["d_TecVALreq"].ToString(), 'A'), 'B', ref UNx, 'F'); lv.SubItems.Add(st);
                        st = TEA.boolToCar(TEA.look_Req_Value("C_ML", Oreadr["d_TecVALTST"].ToString(), 'A'), 'B', ref UNx, 'F'); lv.SubItems.Add(st);

                        //C_RL 
                        st = TEA.boolToCar(TEA.look_Req_Value("C_RL", Oreadr["d_TecVALreq"].ToString(), 'A'), 'B', ref UNx, 'F'); lv.SubItems.Add(st);
                        st = TEA.boolToCar(TEA.look_Req_Value("C_RL", Oreadr["d_TecVALTST"].ToString(), 'A'), 'B', ref UNx, 'F'); lv.SubItems.Add(st);

                        //C_FS 
                        st = TEA.boolToCar(TEA.look_Req_Value("C_FS", Oreadr["d_TecVALreq"].ToString(), 'A'), 'B', ref UNx, 'F'); lv.SubItems.Add(st);
                        st = TEA.boolToCar(TEA.look_Req_Value("C_FS", Oreadr["d_TecVALTST"].ToString(), 'A'), 'B', ref UNx, 'F'); lv.SubItems.Add(st);
                        lv.SubItems.Add(Oreadr["d_TR_Cmnt"].ToString());  //cmnt
                        lv.SubItems.Add(Oreadr["d_TR_Ttyp"].ToString());  //type alrm eq other
                        lv.SubItems.Add(Oreadr["d_TecVALreq"].ToString());
                        lv.SubItems.Add(Oreadr["d_TecVALTST"].ToString());
                        lv.SubItems.Add(Oreadr["d_trDetLID"].ToString()); //tr_detail_LID
                        lv.SubItems.Add(unDV); lv.SubItems.Add(unDY); lv.SubItems.Add(unRY); lv.SubItems.Add(unTO);
                        lv.SubItems.Add(""); lv.SubItems.Add(""); lv.SubItems.Add("");  //unit for ML,RL,FS

                        lv.UseItemStyleForSubItems = false;
                        for (int i = 3; i < 17; i += 2)
                            lv.SubItems[i].BackColor = (lv.SubItems[i].Text != "" && lv.SubItems[i].Text != " ") ? Color.Violet : Color.WhiteSmoke;

                        break;

                }


            }

            OConn.Close();

*/

        }

        private void fill_RTR_Info(string RTR_LID)
        {
            //    string stSql = " SELECT  PSM_R_TRREC_info.tr_TesterNm, PSM_R_TRREC_info.tr_Cust_Model, PSM_R_TRREC_info.tr_Date, PSM_R_TRREC_info.tr_Cmnt, PSM_R_TRREC_info.tr_Rnk, PSM_R_TRREC_info.tr_stat, PSM_R_TRREC_Detail.* " +

            string stSql = " SELECT  PSM_R_TRREC_info.* , PSM_R_TRREC_Detail.* " +
                           " FROM PSM_R_TRREC_info INNER JOIN PSM_R_TRREC_Detail ON PSM_R_TRREC_info.tr_LID = PSM_R_TRREC_Detail.d_TR_LID " +
                           " WHERE     PSM_R_TRREC_info.tr_LID =" + RTR_LID + " ORDER BY PSM_R_TRREC_Detail.d_trDetLID, PSM_R_TRREC_Detail.d_TR_Rnk ";
                          // " ORDER BY PSM_R_TRREC_info.tr_Rnk, PSM_R_TRREC_Detail.d_TR_Ttyp, PSM_R_TRREC_Detail.d_TR_Rnk ";

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int ii = 0;
            bool New_TR = (ed_lvMtst.Items.Count == 0);
            bool info_filled = false;
            while (Oreadr.Read())
            {
                if (!info_filled)
                {
                    lTRLID = RTR_LID;
                    
                    tTRuser.Text = Oreadr["tr_TesterNm"].ToString();
                    lTRstat.Text = LVs_TR_status(Oreadr["tr_stat"].ToString());
                    tabControl1.TabPages[0].ImageIndex =  Int32.Parse (Oreadr["tr_stat"].ToString().Substring(0,1) );
                    tabControl1.TabPages[1].ImageIndex = Int32.Parse(Oreadr["tr_stat"].ToString().Substring(1, 1)); 
                    dpTRdate.Text = Oreadr["tr_Date"].ToString();
                    TRcmnt.Text = Oreadr["tr_Cmnt"].ToString();
                    txSTKnb.Text = Oreadr["tr_nbSTK"].ToString(); txSTKnb.ReadOnly = true; 
                    string t1 = Oreadr["tr_Cust_Model"].ToString();
                    lItemSer.Text = Oreadr["tr_TRName"].ToString().Substring(4, Oreadr["tr_TRName"].ToString().Length - 4); 
                    int ipos = t1.IndexOf("||");
                    if (ipos > -1)
                    {
                        PX_Model.Text = t1.Substring(0, ipos);
                        tcust_Model.Text = t1.Substring(ipos + 2, t1.Length - (ipos + 2));
                    }
                    else
                    {
                        PX_Model.Text = t1;
                        tcust_Model.Text = MainMDI.VIDE;

                    }
                    fill_Boards(lItemSer.Text);
                    info_filled = true;
                
                }
                switch (Oreadr["d_TR_Ttyp"].ToString())
                {
                    case "M":
                    case "T":
                        add_ToMaintst(Oreadr["d_trDetLID"].ToString(), Oreadr["d_tr_Tname"].ToString(), Oreadr["d_TecVALreq"].ToString(), Oreadr["d_TecVALTST"].ToString(), Oreadr["d_TR_Cmnt"].ToString(), Oreadr["d_TR_Ttyp"].ToString());
                        break;

                    case "O":
                        add_ToOtherst(Oreadr["d_trDetLID"].ToString(), Oreadr["d_tr_Tname"].ToString(),  Oreadr["d_TecVALTST"].ToString(),Oreadr["d_TecVALreq"].ToString());
                        break;

                    case "C":
                    case "L":
                    case "A":
                        int _rnk =Int32.Parse ( Oreadr["d_TR_Rnk"].ToString());
                        add_ToStps(Oreadr["d_TR_Ttyp"].ToString(), Oreadr["d_trDetLID"].ToString(), Oreadr["d_TR_Tname"].ToString(), Oreadr["d_TecVALTST"].ToString(), Oreadr["d_TecVALreq"].ToString(), _rnk);
                        break;

                }
                // fill list des RTR to complete....

            }
            edit_edLV('M');
            edit_edLV('S');
            edit_edLV('O');
            colr_valueZone('M');
            colr_valueZone('S');
            Colr_Title('M');

         //    out_LVstps();
            

        }
        private void out_LV()
        {
            string stOut="";
            for (int i = 0; i < ed_lvMtst.Items.Count; i++)
            {
                for (int j = 0; j < ed_lvMtst.Columns.Count; j++)
                    stOut += "|| " + j +"= "  + ed_lvMtst.Items[i].SubItems[j].Text;
                stOut += "\n";
            }
            MessageBox.Show (stOut); 
        }

        /*
        private void out_LV()
        {
            string stOut = "";
            for (int i = 0; i < ed_lvMtst.Items.Count; i++)
            {
                for (int j = 0; j < ed_lvMtst.Columns.Count; j++)
                    stOut += "|| " + j + "= " + ed_lvMtst.Items[i].SubItems[j].Text;
                stOut += "\n";
            }
            MessageBox.Show(stOut);
        }
        */
  
  /*      
        private void out_arr_rectif_MT()
        {
            string stOut = "";
            for (int i = 0; i < 100 ; i++)
            {
                for (int j = 0; j < 3; j++)
                    stOut += "|| " + j + "= " + arr_Rectif_TList[i,j].ToString ();
                stOut += "\n";
            }
            MessageBox.Show(stOut);
        }
                       

   */          
        
        private string NAb(string st)
        {
            return (st == MainMDI.VIDE) ? "" : st; 
        }
        private void add_ToMaintst(string tst_lid, string tstnm, string reqV,string tstV ,string _cmnt, string _stat )
        {
            ListViewItem lv = ed_lvMtst.Items.Add(""); for (int l = 0; l < ed_lvMtst.Columns.Count; l++) lv.SubItems.Add("");

            lv.SubItems[0].Text = tst_lid;
            lv.SubItems[1].Text = tstnm ;
            lv.SubItems[2].Text = NAb(reqV); if (_stat == "T") lv.SubItems[2].Tag = lv.SubItems[2].Text;
            lv.SubItems[3].Text = NAb(tstV); if (_stat == "T") lv.SubItems[3].Tag = lv.SubItems[3].Text; 
            lv.SubItems[4].Text = _cmnt ;
            lv.SubItems[5].Text = _stat ;
        }

        private void add_ToOtherst(string tst_lid, string tstnm, string tstV, string xl_pos)
        {
            ListViewItem lv = ed_LVOthers.Items.Add(""); for (int l = 0; l < ed_LVOthers.Columns.Count; l++) lv.SubItems.Add("");

            lv.SubItems[0].Text = tst_lid;
            lv.SubItems[1].Text = tstnm; 
            lv.SubItems[2].Text =  NAb(tstV);
            lv.SubItems[3].Text = xl_pos;
        }
        
        private void add_ToStps(string cd, string _lid, string tstnm, string tstV ,string xl_pos ,int _rnk)
        {

            ListViewItem lv =null ;
            if ( _rnk > ed_LVStps.Items.Count -1 ) 
            {
                   lv = ed_LVStps.Items.Add(""); 
                   for (int l = 0; l < ed_LVStps.Columns.Count; l++) lv.SubItems.Add("");
            }
            else   lv = ed_LVStps.Items[_rnk ];  
            switch (cd)
            {
                case "C":
                    lv.SubItems[0].Text =_lid;
                    lv.SubItems[1].Text = tstnm ;
                    lv.SubItems[2].Text = tstV;
                    lv.SubItems[3].Text = xl_pos;
                    break;
                case "A":
                    lv.SubItems[4].Text = _lid;
                    lv.SubItems[5].Text = tstnm;
                    lv.SubItems[6].Text = tstV;
                    lv.SubItems[7].Text = xl_pos;
                    break;
                case "L":
                    lv.SubItems[8].Text = _lid;
                    int ipos=tstnm.IndexOf("~~");
                    if (ipos > -1)
                    {
                        lv.SubItems[9].Text = tstnm.Substring(0,ipos );   // for STACK NNNN
                        lv.SubItems[9].Tag = tstnm.Substring(ipos + 2, tstnm.Length - ipos - 2); 
                    }
                    else
                    {
                        lv.SubItems[9].Text = tstnm;
                        lv.SubItems[9].Tag = "";
                    }
                    lv.SubItems[10].Text = tstV;
                    lv.SubItems[11].Text = xl_pos;
                    break;
            }

        }
    
        

        private void fill_MainTR()
        {

     //       for (int i = 0; i < 100 ; i++)
    //            for (int j = 0; j < 3 ; j++) arr_Rectif_TList[i, j] = "";

            string stSql = " SELECT * FROM PSM_C_RECTIF_TR where typ <>'H' ORDER BY testLID";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int ii = 0;
            HT_titles.Clear ();
             
            bool New_TR = ed_lvMtst.Items.Count == 0;
            while (Oreadr.Read())
            {
                ListViewItem lv = ed_lvMtst.Items.Add(""); for (int l = 0; l < ed_lvMtst.Columns.Count; l++) lv.SubItems.Add("");
                int ed_rows = (ed_lvMtst.Items.Count - 1);
                string st = Oreadr["TestNam"].ToString();
                lv.SubItems[1].Text = st; lv.SubItems[1].Tag = Oreadr["typ"].ToString();
                st = (Oreadr["xl_ReqV"].ToString() == "*") ? "" : Oreadr["xl_ReqV"].ToString();
                if (Oreadr["typ"].ToString()=="T")
                {
                    lv.SubItems[2].Text = st; lv.SubItems[2].Tag = st; 
                    HT_titles.Add(Oreadr["TestNam"].ToString()+ "~" +ed_rows.ToString () +"R" , st); 
                }

                st = (Oreadr["xl_TestV"].ToString() == "*") ? "" : Oreadr["xl_TestV"].ToString();
                if (Oreadr["typ"].ToString() == "T") 
                {
                    lv.SubItems[3].Text = st; lv.SubItems[3].Tag = st; 
                   //Oreadr["testLID"].ToString()+"|" +
                    HT_titles.Add(Oreadr["TestNam"].ToString() + "~" + ed_rows.ToString() + "V", st);
                }

               // st = (Oreadr["testLID"].ToString() == "*") ? "" : Oreadr["testLID"].ToString();
                //if (New_TR)
               // lv.SubItems[5].Text = st;
                lv.SubItems[5].Text = Oreadr["typ"].ToString();
                //             if (Oreadr["typ"].ToString() == "T")
                //           {
                //               ed_lvMtst.Items[ed_lvMtst.Items.Count -1].UseItemStyleForSubItems = false;

                //       }


            }

            OConn.Close();
        
            edit_edLV('M');
          //  out_arr_rectif_MT ();
        }


        private void edit_edLV(char cd)
        {
            switch (cd)
            {
                case 'M':
                    ed_lvMtst.AddEditableCell(-1, 2);
                    ed_lvMtst.AddEditableCell(-1, 3);
                    ed_lvMtst.AddEditableCell(-1, 4);
                    break;

                case 'S':
                    ed_LVStps.AddEditableCell(-1, 2);
                    ed_LVStps.AddEditableCell(-1, 6);
                    ed_LVStps.AddEditableCell(-1, 10);
                    break;
            
                case 'O':
                    ed_LVOthers.AddEditableCell(-1, 2);
                    break;
            }

        }
    
        private void fill_StpsRTR()
        {

   //         for (int i = 0; i < arr_Rectif_Stps.Length; i++)
  //              for (int j = 0; j < 3; j++) arr_Rectif_Stps[i, j] = "";

            string stSql = " SELECT * FROM PSM_C_STPbySTP_rep where s_CH_REC='R' OR s_CH_REC='B' ORDER BY s_LID";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int ii = 0;
            bool New_TR =( ed_lvMtst.Items.Count == 0);
            int c = 0, a = 0, lvl = 0;
            while (Oreadr.Read())
            {
                ListViewItem lv=null ;
                int yy = ed_LVStps.Items.Count;   
                if ("CALO".IndexOf(Oreadr["s_Col"].ToString()) > -1)
                {
                    
                    switch (Oreadr["s_Col"].ToString())
                    {
                        case "C":
                            if (c > ed_LVStps.Items.Count - 1)
                            {
                                lv = ed_LVStps.Items.Add(""); for (int l = 0; l < ed_LVStps.Columns.Count; l++) lv.SubItems.Add("");
                            }
                           
                            ed_LVStps.Items[c].SubItems[1].Text = Oreadr["s_Desc"].ToString();
                            ed_LVStps.Items[c++].SubItems[3].Text = Oreadr["Xl_pos"].ToString();
                            break;
                        case "A":
                            //  lv.SubItems[3].Text = Oreadr["s_Desc"].ToString();
                            // lv = ed_LVStps.Items.Add(""); for (int l = 0; l < ed_LVStps.Columns.Count; l++) lv.SubItems.Add("");
                           if (a > ed_LVStps.Items.Count - 1)
                           {
                               lv = ed_LVStps.Items.Add(""); for (int l = 0; l < ed_LVStps.Columns.Count; l++) lv.SubItems.Add("");
                           }
                            ed_LVStps.Items[a].SubItems[5].Text = Oreadr["s_Desc"].ToString();
                            ed_LVStps.Items[a++].SubItems[7].Text = Oreadr["Xl_pos"].ToString();

                            break;
                        case "L":
                            //  lv.SubItems[5].Text = Oreadr["s_Desc"].ToString();
                            // lv = ed_LVStps.Items.Add(""); for (int l = 0; l < ed_LVStps.Columns.Count; l++) lv.SubItems.Add("");
                            if (lvl > ed_LVStps.Items.Count - 1)
                            {
                                lv = ed_LVStps.Items.Add(""); for (int l = 0; l < ed_LVStps.Columns.Count; l++) lv.SubItems.Add("");
                            }
                            ed_LVStps.Items[lvl].SubItems[9].Text = Oreadr["s_Desc"].ToString();
                            ed_LVStps.Items[lvl].SubItems[9].Tag = "";
                            if (Oreadr["s_Dflt"].ToString().Length > 1) if (Oreadr["s_Dflt"].ToString()[0] == '~') ed_LVStps.Items[lvl].SubItems[9].Tag =  Oreadr["s_Dflt"].ToString().Substring(1, Oreadr["s_Dflt"].ToString().Length - 1) ;  //for stack NNN
                            
                            ed_LVStps.Items[lvl++].SubItems[11].Text = Oreadr["Xl_pos"].ToString();
                          


                            break;
                        case "O":
                            ListViewItem lvOther = ed_LVOthers.Items.Add(""); for (int l = 0; l < ed_LVOthers.Columns.Count; l++) lvOther.SubItems.Add("");
                            lvOther.SubItems[1].Text = Oreadr["s_Desc"].ToString();
                            lvOther.SubItems[2].Text = Oreadr["s_Dflt"].ToString();
                            lvOther.SubItems[3].Text = Oreadr["Xl_pos"].ToString();
                            break;
                    }
                }


            }

            OConn.Close();
            edit_edLV('S');
            edit_edLV('O');



        }
        private void Colr_Title(char cd_lv)
        {
            switch (cd_lv)
            {
                case 'M':
                    for (int i = 0; i < ed_lvMtst.Items.Count; i++)
                    {
                        if (ed_lvMtst.Items[i].SubItems[5].Text == "T")
                        {
                            ed_lvMtst.Items[i].UseItemStyleForSubItems = false;
                            for (int s = 0; s < ed_lvMtst.Columns.Count; s++)
                            {
                                ed_lvMtst.Items[i].SubItems[s].BackColor = Color.Gray ;// .Black;
                                ed_lvMtst.Items[i].SubItems[s].ForeColor = Color.White;
                                //   ed_lvMtst.Items[ed_lvMtst.Items.Count - 1].SubItems[s].ForeColor = Color.White;
                            }

                        }
                    }
                    break;
            }

        }
        private void colr_valueZone(char cd_lv)
        {

            switch (cd_lv)
            {
                case 'M':

                    for (int i = 0; i < ed_lvMtst.Items.Count; i++)
                    {
                        if (ed_lvMtst.Items[i].SubItems[0].Tag != "T")
                        {
                            ed_lvMtst.Items[i].UseItemStyleForSubItems = false;
                            ed_lvMtst.Items[i].SubItems[3].BackColor = Color.Violet;
                        }
                        else
                        {
                            for (int s = 0; s < ed_lvMtst.Columns.Count; s++)
                            {
                                ed_lvMtst.Items[ed_lvMtst.Items.Count - 1].SubItems[s].BackColor = Color.Gray;// .Black;
                                //   ed_lvMtst.Items[ed_lvMtst.Items.Count - 1].SubItems[s].ForeColor = Color.White;
                            }

                        }
                    }
                    break;
                case 'S':
                    for (int i = 0; i < ed_LVStps.Items.Count; i++)
                    {
                        ed_LVStps.Items[i].UseItemStyleForSubItems = false;
                        ed_LVStps.Items[i].SubItems[2].BackColor = Color.Violet;
                        ed_LVStps.Items[i].SubItems[6].BackColor = Color.Violet;
                        ed_LVStps.Items[i].SubItems[10].BackColor = Color.Violet;
                    }
                    break;
            }
        
        }




        private void fill_Boards(string _SN)
        {

            string stSql = " SELECT PSM_R_Boards.*, PSM_R_Detail.PrimaxSN, PSM_C_Boards_List.Brd_Name FROM  PSM_R_Boards INNER JOIN PSM_R_Detail ON PSM_R_Boards.b_RRevDetLID = PSM_R_Detail.Rdetail_LID INNER JOIN PSM_C_Boards_List ON PSM_R_Boards.brd_Code = PSM_C_Boards_List.brd_Code " +
                           " WHERE     PSM_R_Detail.PrimaxSN ='" + _SN + "'"; 
            
     

            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            ed_lvBRD.Items.Clear();
            while (Oreadr.Read())
            {
               
                ListViewItem lv = ed_lvBRD.Items.Add(Oreadr["R_BrdLID"].ToString());
                lv.SubItems.Add(Oreadr["Brd_Name"].ToString());
                lv.SubItems.Add(Oreadr["brd_Ver"].ToString());
                lv.SubItems.Add(Oreadr["firmwr_Ver"].ToString());
                lv.SubItems.Add(Oreadr["b_BOM_Rev"].ToString());
                lv.SubItems.Add(MainMDI.SQLdateTOst(Oreadr["b_PCB_date"].ToString()));
                lv.SubItems.Add(MainMDI.SQLdateTOst(Oreadr["b_assembly_date"].ToString()));
                lv.SubItems.Add(Oreadr["brd_SN"].ToString());
                lv.SubItems.Add(Oreadr["b_connTo"].ToString());
                lv.SubItems.Add(Oreadr["b_Manual"].ToString());


            }
            OConn.Close();

        }



        private void cbSerItems_Ref(string _cflid)
        {



            if (CBSerItems.Visible)
            {
                PX_Model.Text = "";
                txSTKnb.Text  = "";
                tTRuser.Text = MainMDI.Find_One_Field("select FullName from PSM_users_New where [user]='" + MainMDI.User + "'");
                lItemSer.Text = CBSerItems.Text;
                string st= MainMDI.Find_One_Field ("SELECT d_ItemDesc FROM  PSM_R_CFDetail WHERE d_CFLID =" + _cflid + " ORDER BY d_Rnk ");
                if (st != MainMDI.VIDE)
                {
                    int ipos = st.IndexOf("P5500");
                    if (ipos > -1) PX_Model.Text = st.Substring(ipos, st.Length - ipos);
                    int ipos2 = st.IndexOf("E-CELL");
                    if (ipos2 > -1)
                    {
                        ipos = st.IndexOf("/ ");
                        if (ipos > -1)
                        {
                            txSTKnb.ReadOnly = true;
                         //   txSTKnb.Text = st.Substring(ipos + 2, ipos2 - ipos - 1);
                            txSTKnb.Text = st.Substring(ipos + 2, ipos2 - ipos - 3);
                          //  maj_STKinfo();
                            if (!Tools.IsNumeric(txSTKnb.Text)) txSTKnb.Text = "???????";   // + 26/11/2008
                           
                        }
                    }

                }
                fill_Boards(CBSerItems.Text);
                fill_MainTR();
                fill_StpsRTR();
         
                ed_LVStps.Enabled = false;
                maj_STKinfo();
                ed_LVStps.Enabled = true;
                btnSTK.Visible = false;

                colr_valueZone('M');
                colr_valueZone('S');
                Colr_Title('M');
                if (tTRuser.Text == "" ) MessageBox.Show("This Config is INVALID for Tests Report... (invalid Usr OR invalid Config):: " + tTRuser.Text);
                //MessageBox.Show("ThisYour Test Report is Empty or Invalid.. !!!!");  
                else
                {
                    //  tvTR.Nodes.Add("RTR_" + CBSerItems.Text);
                    lcurTRNm = New_tvTR_node("RTR_" + CBSerItems.Text, "-1");
                    lcurTRndx = Convert.ToString(tvTR.Nodes.Count - 1);
                    tvTR.SelectedNode = tvTR.Nodes[tvTR.Nodes.Count - 1];
                }
            }

            lItemSer.Focus();


        }




        private void cbSerItems_RefOLd(string _cflid)
        {
            /*      
                    bool isRectifier = false;


                    string stSql = "SELECT  PSM_R_CFinfo.c_SN AS SNb, PSM_R_CFDetail.d_ItemDesc, PSM_R_CFDetail.cf_tecVal as TV, PSM_R_CFinfo.c_RRevLID,PSM_R_CFDetail.d_Rnk " +
                        " FROM   PSM_R_CFinfo INNER JOIN  PSM_R_CFDetail ON PSM_R_CFinfo.CFLID = PSM_R_CFDetail.d_CFLID " +
                        " WHERE     (PSM_R_CFinfo.ConfigNm = '" + CBSerItems.Text + "') AND (PSM_R_CFinfo.c_RRevLID = " + in_IRRevID  + ") ORDER BY PSM_R_CFDetail.d_Rnk ";
                        // " WHERE     (PSM_R_CFinfo.ConfigNm = '" + cbSerItems.Text + "') AND (PSM_R_CFinfo.c_RRevLID = " + lIRRevID.Text + ") ORDER BY PSM_R_CFDetail.d_Rnk ";
                    SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                    OConn.Open();
                    SqlCommand Ocmd = OConn.CreateCommand();
                    Ocmd.CommandText = stSql;
                    SqlDataReader Oreadr = Ocmd.ExecuteReader();
                    tTRuser.Text = "";
                    lItemSer.Text = CBSerItems.Text;
    
                    string st = "";
                    bool fin = false;
                    while (Oreadr.Read() && !fin)
                    {
                        if (Oreadr["d_Rnk"].ToString() == "0")
                        {
                            //kim added for rectifiers testing"
                            isRectifier = (Oreadr["d_ItemDesc"].ToString().IndexOf("RECTIFIER P5500") > -1);
                            //kim
                            TRLsn.Text = Oreadr["SNb"].ToString();
                            tTRuser.Text = MainMDI.Find_One_Field("select FullName from PSM_users_New where [user]='" + MainMDI.User + "'");
                            string t1 = "", t2 = "", t3 = "", t4 = "";
                            stSql = "SELECT PSM_Boards.brd_Desc, PSM_Boards.brd_SN  " +
                                " FROM  PSM_R_CFinfo INNER JOIN  PSM_R_Detail ON PSM_R_CFinfo.c_RRevLID = PSM_R_Detail.IRRev_LID INNER JOIN " +
                                " PSM_Boards ON PSM_R_Detail.Rdetail_LID = PSM_Boards.b_RRevDetLID " +
                                " WHERE     (PSM_R_CFinfo.ConfigNm = '" + cbSerItems.Text + "') AND (PSM_R_Detail.PrimaxSN ='" + TRLsn.Text + "' )";
                            string BRD = "", r_brdSN = "";
                            MainMDI.Find_2_Field(stSql, ref BRD, ref r_brdSN);
                            string[] ar_T = new string[6];
                            get_BoardInfo(BRD, ref ar_T);
                            lbrdNm.Text = ar_T[0]; lbrdVer.Text = ar_T[1]; lbrdSoftV.Text = ar_T[2]; lConTO.Text = ar_T[3]; Lman.Text = ar_T[4];
                            lBsn.Text = r_brdSN;
                            TecVMainSn.Text = Oreadr["TV"].ToString();
                            PX_Model.Text = TEA.look_Req_Value("C_MODEL", Oreadr["TV"].ToString(), 'C');
                            if (PX_Model.Text == "???") //&& !isRectifier)
                            {
                                MessageBox.Show("This Config is INVALID for Test Report .....Model=" + PX_Model.Text);

                                init_TR_Info();
                                fin = true;
                            }
                            else
                            {
                                //  Rectif_TR frm_Rect_TR = new Rectif_TR(LRID.Text, lIRRevID.Text, "XXXXX");
                                //   frm_Rect_TR.Show();
                                //   init_TR_Info();
                                //   fin = true;
                            }
                            if (st_NE.Text == "E") break;
                        }
                        else
                        {
                            string VCS_FRML = Oreadr["TV"].ToString();
                            string dv = "";
                            string UNx = "";
                            string Desc = TEA.look_Req_Value("C_DESC", VCS_FRML, 'A');
                            if ((Desc != MainMDI.VIDE && Desc != "???" && Desc != "" && Desc != " ")) //|| VCS_FRML=="~" )  // && VCS_FRML!="*" && VCS_FRML!="")
                            {
                                string unDV = "", unDY = "", unRY = "", unTO = "";
                                if (Desc == "free") Desc = Oreadr["d_ItemDesc"].ToString();
                                else
                                {
                                    dv = TEA.boolToCar(TEA.look_Req_Value("C_DV", VCS_FRML, 'A'), 'T', ref unDV, 'F');
                                    Desc += " (" + TEA.look_Req_Value("C_SNB", VCS_FRML, 'A') + ")";
                                }
                                ListViewItem lv = MLV_EqAlrm.Items.Add(""); lv.ImageIndex = 9;
                                lv.SubItems.Add(Desc);
                                lv.SubItems.Add(dv + " " + unDV);
                                lv.SubItems.Add(dv);
                                st = TEA.boolToCar(TEA.look_Req_Value("C_DY", VCS_FRML, 'A'), 'T', ref unDY, 'F'); lv.SubItems.Add(st + " " + unDY); lv.SubItems.Add(st);
                                st = TEA.boolToCar(TEA.look_Req_Value("C_RY", VCS_FRML, 'A'), 'T', ref unRY, 'F'); lv.SubItems.Add(st + " " + unRY); lv.SubItems.Add(st);
                                st = TEA.boolToCar(TEA.look_Req_Value("C_TO", VCS_FRML, 'A'), 'T', ref unTO, 'F'); lv.SubItems.Add(st + " " + unTO); lv.SubItems.Add(st);
                                st = TEA.boolToCar(TEA.look_Req_Value("C_ML", VCS_FRML, 'A'), 'B', ref UNx, 'F'); if (st == "~") st = ""; lv.SubItems.Add(st); lv.SubItems.Add(st);
                                st = TEA.boolToCar(TEA.look_Req_Value("C_RL", VCS_FRML, 'A'), 'B', ref UNx, 'F'); if (st == "~") st = ""; lv.SubItems.Add(st); lv.SubItems.Add(st);
                                st = TEA.boolToCar(TEA.look_Req_Value("C_FS", VCS_FRML, 'A'), 'B', ref UNx, 'F'); if (st == "~") st = ""; lv.SubItems.Add(st); lv.SubItems.Add(st);
                                lv.SubItems.Add(" ");  //cmnt

                                //typ 0=EQ     1=Alarm      2:Alarm/tst free ";"
                                if (Oreadr["d_ItemDesc"].ToString().Substring(0, 3) == "_EQ") lv.SubItems.Add("E");
                                else lv.SubItems.Add("M");
                                lv.SubItems.Add(VCS_FRML);
                                lv.SubItems.Add(VCS_FRML);
                                lv.SubItems.Add(""); //LID
                                lv.SubItems.Add(unDV); lv.SubItems.Add(unDY); lv.SubItems.Add(unRY); lv.SubItems.Add(unTO);
                                lv.SubItems.Add(""); lv.SubItems.Add(""); lv.SubItems.Add("");  //unit for ML,RL,FS
                                if (VCS_FRML == ";" || VCS_FRML == "~")
                                {
                                    lv.SubItems[17].Text = "O";
                                    for (int i = 2; i < 10; i++) lv.SubItems[i].Text = "[]";

                                }
                                lv.UseItemStyleForSubItems = false;
                                for (int i = 3; i < 17; i += 2)
                                    lv.SubItems[i].BackColor = (lv.SubItems[i].Text != "" && lv.SubItems[i].Text != " ") ? Color.Violet : Color.WhiteSmoke;
                            }

                        }
                    }
                    OConn.Close();
                    if (cbSerItems.Visible && !fin)
                    {
                        if (tTRuser.Text == "") MessageBox.Show("This Config is INVALID for Tests Report... empty Testing Usr=" + tTRuser.Text);
                        //MessageBox.Show("ThisYour Test Report is Empty or Invalid.. !!!!");  
                        else
                        {
                            tvTR.Nodes.Add("TR_" + TRLsn.Text);
                            lcurTRndx.Text = Convert.ToString(tvTR.Nodes.Count - 1);
                            lcurTRNm.Text = "TR_" + TRLsn.Text;
                            tvTR.SelectedNode = tvTR.Nodes[tvTR.Nodes.Count - 1];
                            fill_All_TstIO();
                            fill_ChkList(cbSerItems.Text);
                        }
                    }
             * */


        }





        // just testing
        private void fill_TVConfig()
        {
            tvTR.Nodes.Clear();

            string stSql = "SELECT ConfigNm , CFLID from PSM_R_CFinfo where c_RRevLID=" + in_IRRevID;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();

            while (Oreadr.Read())
            {
                string STsn = Oreadr["ConfigNm"].ToString().Substring(Oreadr["ConfigNm"].ToString().IndexOf("-S"));
                TreeNode n = new TreeNode();
                n.Text = "RTR" + STsn;
                n.Tag = Oreadr["CFLID"].ToString();
                tvTR.Nodes.Add(n);
            }
            OConn.Close();

        }
        private string New_tvTR_node(string STsn, string val)
        {
            TreeNode n = new TreeNode();
            n.Text = STsn;
            n.Tag = val;
            tvTR.Nodes.Add(n);
            return n.Text;
        }
        private void Open_RTR()
        {
            if (ed_lvMtst.Items.Count < 1)
            {
                //      ed_lvInfo_Mtst.Height = tabCRtst.Height - 408;// 128-24-200-24-32 ; 
                init_RTR_Info();
                if (CBSerItems.Items.Count < 1) fill_CBSerItems(true );
                fill_TVTR();
                if (tvTR.Nodes.Count > 0) tvTR.SelectedNode = tvTR.Nodes[tvTR.Nodes.Count - 1];
                picTM.Visible = (tvTR.Nodes.Count == 0);

            }
        }
        private void fill_TVTR()
        {
            tvTR.Nodes.Clear();

            string stSql = "SELECT tr_TRName, tr_LID from PSM_R_TRREC_Info where tr_iRRevID=" + in_IRRevID;
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                New_tvTR_node(Oreadr["tr_TRName"].ToString(), Oreadr["tr_LID"].ToString());

            }
            OConn.Close();

        }

        private void fill_CBSerItems(bool chkRectif)
        {
            CBSerItems.Items.Clear();
            string stSql = "SELECT c_SN,  CFLID   FROM PSM_R_CFinfo INNER JOIN PSM_R_CFDetail ON PSM_R_CFinfo.CFLID = PSM_R_CFDetail.d_CFLID where c_sta='1' and c_RRevLID=" + in_IRRevID + " AND PSM_R_CFDetail.d_ItemDesc LIKE '%EDI RECTIFIER P5500%'";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            while (Oreadr.Read())
            {
                System.Web.UI.WebControls.ListItem li = new System.Web.UI.WebControls.ListItem();
                li.Text = Oreadr["c_SN"].ToString();
                li.Value = Oreadr["CFLID"].ToString();
                CBSerItems.Items.Add(li);
            }
            if (CBSerItems.Items.Count == 0) if ( chkRectif  ) MessageBox.Show(" Sorry,  NO RECTIFIER Testing Report due to invalid Rectifier or invalid Configuration....!!!  "); 
            //	cbSerItems.BringToFront ();
            OConn.Close();

        }
        private void NewTR_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_TR", true))
            {

                init_RTR_Info();
                st_NE.Text = "N";
                btnSTK.Visible = true;
                if (CBSerItems.Items.Count < 1) fill_CBSerItems(true);

                CBSerItems.BringToFront();
                CBSerItems.Visible = true;
                dpTRdate.Visible = true;
                gifHere.Visible = true;
                tvTR.Enabled = false; 
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //  fill_TVConfig();   use text and tag in TreeView

            CBSerItems.Visible = true;
            fill_CBSerItems(true);

        }
    
         

        private void tvTR_AfterSelect(object sender, TreeViewEventArgs e)
        {
            //  MessageBox.Show ("Txt= " +tvTR.SelectedNode.Text + "   lid: " +tvTR.SelectedNode.Tag.ToString ());
            Select_TVR();

        }
        private void Select_TVR()
        {

            errr.Enabled = true;
            if (st_NE.Text == "E")
            {
                init_RTR_Info();
            //    ed_lvMtst.Clear();
            //    ed_LVStps.Items.Clear();

            }
            
            lcurTRndx = tvTR.SelectedNode.Index.ToString();
            tvTR.SelectedNode.BackColor = MainMDI.Clr_Select;
            if (OLDTVTR_Selndx != -1 && OLDTVTR_Selndx < tvTR.Nodes.Count) tvTR.Nodes[OLDTVTR_Selndx].BackColor = Color.WhiteSmoke;
            lcurTRNm = tvTR.SelectedNode.Text;
            TRndxDel = tvTR.SelectedNode.Index.ToString();
            string rtr_lid = tvTR.SelectedNode.Tag.ToString();

            if (st_NE.Text == "E")
            {

                fill_RTR_Info(rtr_lid);  // fill  RTR info ,  main report items and  ed_lv_stps
                Colr_Title('M');
                dpTRdate.Visible = false;
                OLDTVTR_Selndx = (lcurTRNm == "") ? -1 : Convert.ToInt32(lcurTRndx);
             //   fill_DocsTP(lTRLID);
                get_Manuals (lTRLID);
                fill_Boards_by_TR_REC (lTRLID );
                fill_DocsTP(lTRLID);
            }
            //picNsrt.Visible = (ar_CF[0]!=-1 || ar_CurCF[0,0]!="-1")  ; 
          //  lTRstat.Text = LVs_TR_status();

        }




        private void fill_ChkList(string cfNM)
        {
            /*
                        string stSql = "SELECT PSM_R_CFDetail.CfDet_LID, PSM_R_CFDetail.d_ItemDesc, PSM_R_CFDetail.d_cf_chk FROM  PSM_R_CFDetail INNER JOIN  PSM_R_CFinfo ON PSM_R_CFDetail.d_CFLID = PSM_R_CFinfo.CFLID " +
                            " WHERE     PSM_R_CFinfo.ConfigNm = '" + cfNM + "' AND PSM_R_CFinfo.c_RRevLID =" + lIRRevID.Text + " ORDER BY PSM_R_CFDetail.d_Rnk ";
                        SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                        OConn.Open();
                        SqlCommand Ocmd = OConn.CreateCommand();
                        Ocmd.CommandText = stSql;
                        SqlDataReader Oreadr = Ocmd.ExecuteReader();
                        while (Oreadr.Read())
                        {
                            ListViewItem lv = MLV_ChkList.Items.Add("");
                            lv.ImageIndex = (Oreadr["d_cf_chk"].ToString() == "8") ? 8 : 9;
                            lv.SubItems.Add(Oreadr["d_ItemDesc"].ToString());
                            lv.SubItems.Add(Oreadr["CfDet_LID"].ToString());


                        }

                        OConn.Close();
             * */

        }



      

        private void CBSerItems_SelectedValueChanged(object sender, EventArgs e)
        {
            //	if (MainMDI.VIDE != MainMDI.Find_One_Field("select tr_LID from PSM_R_TRInfo where tr_ConfNm='" + cbSerItems.Text + "' where  tr_ConfNm='" + cbSerItems.Text +"'")) 


            System.Web.UI.WebControls.ListItem itm = new System.Web.UI.WebControls.ListItem();
            itm = (System.Web.UI.WebControls.ListItem)CBSerItems.Items[CBSerItems.SelectedIndex];
            LcurConflid = itm.Value;
            if (MainMDI.VIDE != MainMDI.Find_One_Field("select tr_LID from PSM_R_TRREC_info where tr_ConfLID='" + LcurConflid + "'"))
            {
                MessageBox.Show("Tests report already exists for the Config: " + CBSerItems.Text);
                if (tvTR.Nodes.Count > 0)
                {

                    tvTR.SelectedNode = tvTR.Nodes[tvTR.Nodes.Count - 1];
                    Select_TVR();

                }
                st_NE.Text = "E";
            }
            else
            {
                //string cflid = tvTR.SelectedNode.Tag.ToString (); 
                cbSerItems_Ref(LcurConflid);
                if (tvTR.Nodes.Count > 0)
                {
                    tvTR.SelectedNode = tvTR.Nodes[tvTR.Nodes.Count - 1];
                    Select_TVR();
                }
            }
            gifHere.Visible = false;
            lItemSer.BringToFront();
        }

        private void CBSerItems_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        private string LVs_TR_status(string stat_tabs)
        {
            
            switch (stat_tabs)
            {
                case "00":
                    return "StandBy";
                case "01":
                case "10":
                    return "In Proccess";
                case "11":
                    return "Completed";
                 default :
                    return "???????";

            }

        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (ed_lvMtst.Items.Count > 0)
            {
                tabControl1.TabPages[tabControl1.SelectedIndex].ImageIndex = 1;
                lTRstat.Text = LVs_TR_status(tabControl1.TabPages[0].ImageIndex.ToString() + tabControl1.TabPages[1].ImageIndex.ToString());
            }

            
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (ed_LVStps.Items.Count > 0)
            {
                tabControl1.TabPages[tabControl1.SelectedIndex].ImageIndex = 0;
                lTRstat.Text = LVs_TR_status(tabControl1.TabPages[0].ImageIndex.ToString() + tabControl1.TabPages[1].ImageIndex.ToString());
            }
        }


        private void restore_titles(int cdlv)
        {
            switch (cdlv)
            {
                case 'M':
                    for (int i = 0; i < ed_lvMtst.Items.Count; i++)
                    {
                        if (ed_lvMtst.Items[i].SubItems[5].Text == "T")
                        {
                            ed_lvMtst.Items[i].SubItems[2].Text = ed_lvMtst.Items[i].SubItems[2].Tag.ToString();
                            ed_lvMtst.Items[i].SubItems[3].Text = ed_lvMtst.Items[i].SubItems[3].Tag.ToString();

                         //   MessageBox.Show(ed_lvMtst.Items[i].SubItems[2].Tag.ToString() + "    V= " + ed_lvMtst.Items[i].SubItems[3].Tag.ToString());
                         //   ed_lvMtst.Items[i].SubItems[2].Text = HT_titles[ed_lvMtst.Items[i].SubItems[1].Text + "~" + i.ToString() + "R"].ToString();
                         //   ed_lvMtst.Items[i].SubItems[3].Text = HT_titles[ed_lvMtst.Items[i].SubItems[1].Text + "~" + i.ToString() + "V"].ToString();
                        }
                    }
                    break;
            }

                                

        }
        private void Save_Click(object sender, System.EventArgs e)
        {
            if (txSTKnb.Text != "???????")
            {
                if (MainMDI.ALWD_USR("OR_TR", true))
                {
                    restore_titles('M');
                    if (txSTKnb.Text != "" && !btnSTK.Visible)
                    {
                        // lTRstat.Text = LVs_TR_status();
                        Save_ALL_RTR();
                        if (st_NE.Text == "N")
                        {
                            st_NE.Text = "E";
                            Select_TVR();

                        }
                    }
                    else
                    {
                        if (btnSTK.Visible) MessageBox.Show("Sorry, you have to  Press Button 'Stack #' before saving !!!");
                        else MessageBox.Show("Sorry, You missed Stack #.......");
                    }

                }
                //  else MessageBox.Show("This User:" + MainMDI.User + "    is NOT allowed to perform this option, contact you Admin....! ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                tvTR.Enabled = true;
            }
            else MessageBox.Show("Sorry, INVALID Stack #....... ", "Stack ERROR ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }


        private void Save_ALL_RTR()
        {
        bool t1 = false;  

            if (lcurTRNm != "" && ed_lvMtst.Items.Count   > 0 && ed_LVStps.Items.Count > 0)
            {
                string _stat = tabControl1.TabPages[0].ImageIndex.ToString() + tabControl1.TabPages[1].ImageIndex.ToString();
                string stSql = "";
                tTRuser.Text = MainMDI.Find_One_Field("select FullName from PSM_users_New where [user]='" + MainMDI.User + "'");
                string mdl = (PX_Model.Text == "") ? MainMDI.VIDE : PX_Model.Text;
                dpTRdate.Text = System.DateTime.Now.ToShortDateString();

                mdl += "||" + ((tcust_Model.Text == "") ? MainMDI.VIDE : tcust_Model.Text);
                if (lTRLID == "")
                {
                    
                    stSql = "INSERT INTO PSM_R_TRREC_info ([tr_iRRevID],[tr_ConfLID],[tr_TRName],[tr_Date],[tr_TesterNm],[tr_Cust_Model],[tr_nbSTK],[tr_Cmnt],[tr_stat],[tr_Rnk]) VALUES ('" +
                       in_IRRevID + "', '" + LcurConflid + "', '" + lcurTRNm + "', " + MainMDI.SSV_date(lTRdate.Text) + ", '" + tTRuser.Text + "', '" + mdl + "', " + txSTKnb.Text + ", '" + TRcmnt.Text.Replace("'", "''") + "', '" + _stat  + "', " + lcurTRndx + ")";
                    t1 = MainMDI.ExecSql(stSql);
                    MainMDI.Write_JFS(stSql);
                    string stId = MainMDI.Find_One_Field("select tr_LID from PSM_R_TRREC_info where tr_TRName='" + lcurTRNm + "' AND tr_iRRevID='" + in_IRRevID + "'");
                    if (stId == MainMDI.VIDE) MessageBox.Show("Error Occurs while Saving this Test Report !!!, contact your Admin !!!" + MainMDI.stXP);
                    else
                    {
                        lTRLID = stId;
                        tvTR.Nodes[tvTR.Nodes.Count - 1].Tag = lTRLID;
                        SaveAll_elv();
                    }

                }
                else   //update Changes made in RTR Info
                {
                    //if (MainMDI.User.ToUpper()  == tTRuser.Text.ToUpper () )
                    //{
                    stSql = "UPDATE PSM_R_TRREC_info SET " + " [tr_Cust_Model]='" + mdl + "', [tr_TesterNm]='" + tTRuser.Text + "', [tr_stat]='" + _stat + "',[tr_Date]=" + MainMDI.SSV_date(lTRdate.Text) + ",[tr_Cmnt]='" + TRcmnt.Text + "' WHERE TR_LID=" + lTRLID;
                    t1 = MainMDI.ExecSql(stSql);
                    TosaveCF = t1;
                    MainMDI.Write_JFS(stSql);
                    if (TosaveCF) SaveAll_elv ();
                    //}
                    //else MessageBox.Show("Only Owner can save modifications !"); 
                    //MainMDI.Write_JFS("Tests Report Modified by " + MainMDI.User + " (" + System.DateTime.Now.ToString());       
                }

                stSql = "INSERT INTO PSM_R_TRUsers ([u_tr_LID],[u_tr_UsrNM_date]) VALUES ('" +
                    lTRLID + "', '" + tTRuser.Text + ": " + System.DateTime.Now.ToString() + "')";
                t1 = MainMDI.ExecSql(stSql);

            }
            //		if (tvTR.Nodes.Count >=0)
            //		{
            //			tvTR.SelectedNode =tvTR.Nodes[0]  ; 
            //			tvTR.SelectedNode =tvTR.Nodes[tvTR.Nodes.Count-1] ; 
            //		}
            PX_Model.ReadOnly = true;
            MainMDI.Exec_SQL_JFS("UPDATE  PSM_R_Rev SET Tests ='" + lTRstat.Text[0]  + "' WHERE IRRevID =" + in_IRRevID , "update Rectifier test_status Tested: "); //to review for rrev having many rectifiers


        }
        private void SaveAll_elv()
        {
            //Main tsts
            for (int i = 0; i < ed_lvMtst.Items.Count; i++)
            {
                if (ed_lvMtst.Items[i].SubItems[1].Text.Length > 1)
                {
                    string _stat = (tabControl1.TabPages[0].ImageIndex == 1) ? "C" : "U";
                                           //  if (ed_lvMtst.Items[i].SubItems[5].Text !="T" )   _stat = (tabControl1.TabPages[0].ImageIndex == 1) ? "C" : "U";         //  C=checked  U=Unchecked
                    if (!Save_RTR_ed_Details(ed_lvMtst.Items[i].SubItems[0].Text, lTRLID, ed_lvMtst.Items[i].SubItems[5].Text, _stat, ed_lvMtst.Items[i].SubItems[1].Text, ed_lvMtst.Items[i].SubItems[2].Text, ed_lvMtst.Items[i].SubItems[3].Text, ed_lvMtst.Items[i].SubItems[4].Text, i))
                    {
                        MessageBox.Show("Error Occurs while Saving current Test report Details (RTR main )......contact your Admin !!!" + MainMDI.stXP);
                        break;
                    }
                    TosaveRTR = false;
                }
            }

            //stps tsts
            string st999 = "";
            for (int i = 0; i < ed_LVStps.Items.Count; i++)
            {                                                                                                              //  C=checked  U=Unchecked
                 bool _saved=false;

                 if (ed_LVStps.Items[i].SubItems[1].Text.Length > 1) _saved = Save_RTR_ed_Details(ed_LVStps.Items[i].SubItems[0].Text, lTRLID, "C", ((tabControl1.TabPages[1].ImageIndex == 1) ? "C" : "U"), ed_LVStps.Items[i].SubItems[1].Text, ed_LVStps.Items[i].SubItems[3].Text, ed_LVStps.Items[i].SubItems[2].Text, MainMDI.VIDE, i);
                 if (ed_LVStps.Items[i].SubItems[5].Text.Length > 1) _saved = Save_RTR_ed_Details(ed_LVStps.Items[i].SubItems[4].Text, lTRLID, "A", ((tabControl1.TabPages[1].ImageIndex == 1) ? "C" : "U"), ed_LVStps.Items[i].SubItems[5].Text, ed_LVStps.Items[i].SubItems[7].Text, ed_LVStps.Items[i].SubItems[6].Text, MainMDI.VIDE, i);
                 st999 = (ed_LVStps.Items[i].SubItems[9].Tag.ToString().Length > 1) ? ed_LVStps.Items[i].SubItems[9].Text + "~~" + ed_LVStps.Items[i].SubItems[9].Tag.ToString() : ed_LVStps.Items[i].SubItems[9].Text ; 
                 if (ed_LVStps.Items[i].SubItems[9].Text.Length > 1) _saved = Save_RTR_ed_Details(ed_LVStps.Items[i].SubItems[8].Text, lTRLID, "L", ((tabControl1.TabPages[1].ImageIndex == 1) ? "C" : "U"), st999, ed_LVStps.Items[i].SubItems[11].Text, ed_LVStps.Items[i].SubItems[10].Text, MainMDI.VIDE, i);
       
                
                if (!_saved )
                {
                    MessageBox.Show("Error Occurs while Saving current Test report Details (RTR stps)......contact your Admin !!!" + MainMDI.stXP);
                    break;
                }
                TosaveRTR = false;
            }


            //Other tsts
            for (int i = 0; i < ed_LVOthers.Items.Count; i++)
            {                                                                                                              //  C=checked  U=Unchecked
                if (!Save_RTR_ed_Details(ed_LVOthers.Items[i].SubItems[0].Text, lTRLID, "O", ((tabControl1.TabPages[1].ImageIndex == 1) ? "C" : "U"), ed_LVOthers.Items[i].SubItems[1].Text, ed_LVOthers.Items[i].SubItems[3].Text, ed_LVOthers.Items[i].SubItems[2].Text, MainMDI.VIDE, i))
                {
                    MessageBox.Show("Error Occurs while Saving current Test report Details (RTR Other )......contact your Admin !!!" + MainMDI.stXP);
                    break;
                }
                TosaveRTR = false;
            }



        }

        private bool Save_RTR_ed_Details(string d_TRDet_LID, string TRLID, string Typ, string stat, string TstName, string ReqTV, string TstTV, string Cmnt, int rnk)
        {

            string stSql = "";
            if (stat == "") stat = MainMDI.VIDE;
            if (d_TRDet_LID == "")
                stSql = "INSERT INTO PSM_R_TRREC_Detail ([d_TR_LID],[d_TR_Ttyp], " +
                    "[d_TR_TName], [d_TR_Tstat],[d_TecVALreq],[d_TecVALTST],[d_TR_Cmnt],[d_TR_Rnk]) VALUES ('" +
                    TRLID + "', '" + Typ + "', '" + TstName.Replace("'", "''") + "', '" + stat.Substring(stat.Length - 1, 1) + "', '" +
                    ReqTV.Replace("'", "''") + "', '" + TstTV.Replace("'", "''") + "', '" +
                    Cmnt.Replace("'", "''") + "', '" + rnk + "')";

            else stSql = "UPDATE PSM_R_TRREC_Detail  SET " +
                     " [d_TR_Tstat]='" + stat.Substring(stat.Length - 1, 1) + "', " +
                     " [d_TecVALreq]='" + ReqTV.Replace("'", "''") + "', " +
                     " [d_TecVALTST]='" + TstTV.Replace("'", "''") + "', " +
                     " [d_TR_Cmnt]='" + Cmnt.Replace("'", "''") + "' WHERE [d_trDetLID]=" + d_TRDet_LID;
            MainMDI.Write_JFS(stSql);
            return MainMDI.ExecSql(stSql);


        }

        private void lItemSer_Click(object sender, EventArgs e)
        {

        }

        private void dpTRdate_ValueChanged(object sender, EventArgs e)
        {
            lTRdate.Text = dpTRdate.Value.ToShortDateString(); 
        }

        private void  fill_HTs()
        {

            HT_XL_ReqV.Clear ();
            HT_XL_TestV.Clear ();
            string stSql = " SELECT * FROM PSM_C_RECTIF_TR where typ <> 'H' ORDER BY testLID";
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int i = 0;

            try
            {
                while (Oreadr.Read())
                {

                    if (Oreadr["TestNam"].ToString() != "" || Oreadr["TestNam"].ToString() != "*")
                    {
                       
                        HT_XL_ReqV.Add(Oreadr["TestNam"].ToString(), Oreadr["xl_ReqV"].ToString());  //Oreadr["testLID"].ToString()+"|" +
                        HT_XL_TestV.Add(Oreadr["TestNam"].ToString(), Oreadr["xl_TestV"].ToString());  //Oreadr["testLID"].ToString() + "|" +
                    }
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("Error: " + e.Message);
            }
                finally
                {
                    OConn.Close();
                }

          
        }

     
        private void Rectif_TR_Load(object sender, EventArgs e)
        {
            if (HT_XL_ReqV.Count < 1 || HT_XL_TestV.Count<1 ) fill_HTs();
            if (ed_lvMtst.Items.Count < 1)
            {
                //lvLTest.Height = tabCRtst.Height - 408;// 128-24-200-24-32 ; 
                init_RTR_Info ();
                if (CBSerItems.Items.Count < 1) fill_CBSerItems(false );
                fill_TVTR();
                if (tvTR.Nodes.Count > 0) tvTR.SelectedNode = tvTR.Nodes[tvTR.Nodes.Count - 1];
                picTM.Visible = (tvTR.Nodes.Count == 0);

            }
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
        }

        private void txSTKnb_TextChanged(object sender, EventArgs e)
        {

            
        }
        private void maj_STKinfo()
        {
            for (int i = 0; i < ed_LVStps.Items.Count; i++)
            {
                string st = ed_LVStps.Items[i].SubItems[9].Text;
                if (st.IndexOf("NNNN") > -1) ed_LVStps.Items[i].SubItems[9].Text = st.Replace("NNNN", txSTKnb.Text);
                if (ed_LVStps.Items[i].SubItems[9].Text == "STK Number") ed_LVStps.Items[i].SubItems[10].Text = txSTKnb.Text;
                 
            }
        }


        private void txSTKnb_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = Tools.OnlyInt(e.KeyChar); 
        }

        private void btnSTK_Click(object sender, EventArgs e)
        {
            if (st_NE.Text == "N" && !txSTKnb.ReadOnly)
            {
                string ststk = (Int32.Parse(txSTKnb.Text) > 1) ? " E-CELL stacks" : " E-CELL stack";
                if (PX_Model.Text.IndexOf("Stack") == -1) PX_Model.Text += " / " + txSTKnb.Text + ststk;
                maj_STKinfo();
                ed_LVStps.Enabled = true;
                btnSTK.Visible = false;

            }
            else MessageBox.Show("Can not update Stacks...please enter the right stacks # and press button : [stacks #] above..."); 
          //  else if (txSTKnb.ReadOnly) maj_STKinfo();
          
        }

        private void del_RTR_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_TR", true))
            {
                if (lTRstat.Text[0] != 'C' || MainMDI.profile == 'S')
                {
                    if (TRndxDel != "")
                    {
                        string stSql="delete PSM_R_TRREC_info where tr_LID=" + lTRLID;
                        MainMDI.ExecSql(stSql); 
                        MainMDI.Exec_SQL_JFS( stSql , "Delete Rectifier TST REport");
                        if (tvTR.SelectedNode.BackColor == MainMDI.Clr_Select) OLDTVTR_Selndx = -1;
                        tvTR.Nodes[Convert.ToInt32(TRndxDel)].Remove();
                        init_RTR_Info();
                        if (tvTR.Nodes.Count < 1) TRndxDel = "";
                        else
                        {
                            tvTR.SelectedNode = tvTR.Nodes[0];
                            Select_TVR();
                            TRndxDel = "0";
                        }
                        //MessageBox.Show( ndxDel.Text);
                    }
                }

            }
        }

        private void picPrintRTR_Click(object sender, EventArgs e)
        {

            if (MainMDI.ALWD_USR("OR_TR", true))
            {
                //  \RECTIF_MTR_Stps_PRT.xls"
                restore_titles('M');
                string Xlfname = "RECTIF_MTR_Stps";
                try
                {

                    File.Delete(MainMDI.XL_Path + @"\" + Xlfname + "_PRT.xls");
                    XLport_Mtest(Xlfname);

                    MainMDI.OpenKnownFile(MainMDI.XL_Path + @"\" + Xlfname + "_PRT.xls");
                }
                catch (Exception  ex)
                {
                    MessageBox.Show("Can not export this report since XL File already Opened......\n msg= " + ex.Message  ); 
                }
            }


          
        }

        private string get_BoardsVal(string frml, int brd_rnk)
        {
            string res="";
            if (brd_rnk < ed_lvBRD.Items.Count ) 
            {
            switch (frml)
            {
                case "!b_name":
                    res=ed_lvBRD.Items[brd_rnk].SubItems[1].Text ;
                    break;

                case "!b_sn":
                        res=ed_lvBRD.Items[brd_rnk].SubItems[7].Text ;
                    break;
                    
                case "!b_ver":
                        res=ed_lvBRD.Items[brd_rnk].SubItems[2].Text ;
                    break;
                    
                case "!b_softv":
                        res=ed_lvBRD.Items[brd_rnk].SubItems[3].Text ;
                    break;

                case "!b_con":
                        res=ed_lvBRD.Items[brd_rnk].SubItems[8].Text ;
                    break;
                case "!b_man":
                        res=ed_lvBRD.Items[brd_rnk].SubItems[9].Text ;
                    break;


            }
            }
            return res;
        }





        private string get_HdrVal(string frml)
        {
            string res="";
            switch (frml)
            {
                case "!cmpny":
                    res=in_cmpany ;
                    break;

                    case "!model":
                        res = PX_Model.Text;
                    break;

                    case "!prj":
                    res = in_RID ;
                    break;

                    case "!sn":
                        res = lItemSer.Text ;
                    break;

                    case "!cmnt":
                        res = TRcmnt.Text ;
                    break;

                    case "!usr":
                        res = tTRuser.Text ;
                    break;

                    case "!datetst":
                        res = lTRdate.Text ;
                    break;

            }
            return res;
        }


        private int get_Hdrs(ref string[,] _arr, int lim_arr)
        {
            string stSql = " SELECT * FROM PSM_C_RECTIF_TR where typ='H' ORDER BY testLID"; //where typ='H'
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int i = 0,j=0;
            while (Oreadr.Read())
            {
                if (Oreadr["typ"].ToString() == "H")
                {
                    if (Oreadr["xl_ReqV"].ToString().IndexOf("|") > -1)
                    {
                        get_boards_info(ref _arr, ref i, Oreadr["xl_ReqV"].ToString(), Oreadr["xl_TestV"].ToString(), lim_arr);
                    }
                    else 
                    {
                        _arr[i, 0] = get_HdrVal(Oreadr["xl_TestV"].ToString());
                        _arr[i, 1] = Oreadr["xl_ReqV"].ToString();

                        _arr[i++, lim_arr - 1] = "H";
                    }
                }
          


            }
         
             OConn.Close();
             return i;     
        }

        private void get_boards_info(ref string[,] _arr, ref int i, string _stRows, string _val, int lim_arr)
        {

            for (int r = 0, ndx=0; r < _stRows.Length ; r+=4, ndx++)
            {
               string res=get_BoardsVal(_val,ndx);
               if (res.Length > 0)
               {
                   _arr[i, 0] = res;
                   _arr[i, 1] = _stRows.Substring(r, 3);
                   _arr[i++, lim_arr - 1] = "H";
               }
               else r = _stRows.Length; 

            }

        }

        private int get_Hdrs_stps(ref string[,] _arr, int lim_arr)
        {
            string stSql = " SELECT * FROM PSM_C_STPbySTP_rep where s_COL='H' ORDER BY s_LID"; //where typ='H'
            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int i = 0, j = 0;
            while (Oreadr.Read())
            {
                if (Oreadr["s_COL"].ToString() == "H")
                {
                    if (Oreadr["xl_pos"].ToString().IndexOf("|") > -1)
                    {
                        get_boards_info(ref _arr, ref i, Oreadr["xl_pos"].ToString(), Oreadr["s_Dflt"].ToString(), lim_arr);
                    }
                    else
                    {
                        _arr[i, 0] = get_HdrVal(Oreadr["s_Dflt"].ToString());
                        _arr[i, 1] = Oreadr["xl_pos"].ToString();

                        _arr[i++, lim_arr - 1] = "H";
                    }
                }



            }

            OConn.Close();
            return i;
        }

        private void add_Mtst(ref string[,]  _arr, int i, int  lim_arr)
        {

            for (int j = 0; j < ed_lvMtst.Items.Count; j++)
            {
                if (ed_lvMtst.Items[j].SubItems[5].Text != "T")
                {

                    string Tstnam = ed_lvMtst.Items[j].SubItems[1].Text;

                    if (Tstnam.Length > 1)
                    {
                        _arr[i, lim_arr - 1] = "M";

                        if (ed_lvMtst.Items[j].SubItems[2].Text.Length > 0 && ed_lvMtst.Items[j].SubItems[2].Text !=" ")
                        {
                            _arr[i, 0] = ed_lvMtst.Items[j].SubItems[2].Text;
                            _arr[i, 1] = HT_XL_ReqV[Tstnam].ToString();
                        }
                        if (ed_lvMtst.Items[j].SubItems[3].Text.Length > 0 && ed_lvMtst.Items[j].SubItems[3].Text != " ")
                        {
                            _arr[i, 2] = ed_lvMtst.Items[j].SubItems[3].Text;
                            _arr[i++, 3] = HT_XL_TestV[Tstnam].ToString();
                        }


                    }
                    else j = ed_lvMtst.Items.Count;
                }
            }
    
        }

        private void add_all_Stps(ref string[,] _arr, int i, int lim_arr)
        {
            int cl = 0;
            for (int j = 0; j < ed_LVStps.Items.Count; j++)
            {
                for (cl = 1; cl < ed_LVStps.Columns.Count; cl += 4)
                {
                    string Tstnam = ed_LVStps.Items[j].SubItems[cl].Text;

                    if (Tstnam.Length > 1)
                    {
                        _arr[i, lim_arr - 1] = "G";  // a voir

                        if (ed_LVStps.Items[j].SubItems[cl + 1].Text.Length > 0)
                        {
                            _arr[i, 0] = ed_LVStps.Items[j].SubItems[cl + 1].Text;
                            _arr[i++, 1] = ed_LVStps.Items[j].SubItems[cl + 2].Text;

                        }
                        if ( cl==9 && ed_LVStps.Items[j].SubItems[cl].Tag.ToString().Length > 0)
                        {
                            _arr[i, lim_arr - 1] = "G";
                            _arr[i, 0] = ed_LVStps.Items[j].SubItems[cl].Text;
                            _arr[i++, 1] = ed_LVStps.Items[j].SubItems[cl].Tag.ToString ();
                        }


                    }
                }

            }

            for (int j = 0; j < ed_LVOthers.Items.Count; j++)
            {
                string Tstnam = ed_LVOthers.Items[j].SubItems[1].Text;
                if (Tstnam.Length > 1)
                {
                    _arr[i, lim_arr - 1] = "G";  // a voir

                    if (ed_LVOthers.Items[j].SubItems[2].Text.Length > 0)
                    {
                        _arr[i, 0] = ed_LVOthers.Items[j].SubItems[2].Text;
                        _arr[i++, 1] = ed_LVOthers.Items[j].SubItems[3].Text;
                    }

                }
            }   



        }

        private void XLport_MtestOld(string xlname)
        {
            const int lim_arr = 5;


            Object m_objOpt = System.Reflection.Missing.Value;
            Excel.Application m_objXL = new Excel.Application();
            Excel.Workbook m_objbook = m_objXL.Workbooks.Open(MainMDI.XL_Path + @"\" + xlname + ".xls", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "", false, false, 0, true, m_objOpt, m_objOpt);

            //   Excel.Workbook m_objBook = m_objbooks(m_objOpt);
            Excel.Sheets m_objSheets = m_objbook.Worksheets;
            Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
            Excel.Range m_objRng = m_objSheet.get_Range("A1", "E1"); // "C1", "D1", "E1", "F1", "G1", "H1", "I1", "J1", "K1", "L1", "M1", "N1", "O1", "P1", "Q1", "R1", "S1", "T1", "U1");
            int i = 0, j = 0;
            string[,] arr_Hdrs = new string[100, lim_arr];
            for (i = 0; i < 100; i++) for (j = 0; j < lim_arr; j++) arr_Hdrs[i, j] = "";
            string _row = "", _col = "";
            int II = get_Hdrs(ref arr_Hdrs, lim_arr);
            add_Mtst(ref arr_Hdrs, II, lim_arr);
            for (i = 0; i < 100; i++)
            {
                if (arr_Hdrs[i, lim_arr - 1] != "")
                {
                    if (arr_Hdrs[i, lim_arr - 1] == "H")
                    {
                        if (arr_Hdrs[i, 1].IndexOf("|") > -1)
                        {


                        }
                        else
                        {
                            _row = arr_Hdrs[i, 1].Substring(0, 1);
                            _col = arr_Hdrs[i, 1].Substring(1, arr_Hdrs[i, 1].Length - 1);
                            m_objRng = m_objSheet.get_Range(arr_Hdrs[i, 1].ToString(), m_objOpt);
                            m_objRng.Value2 = arr_Hdrs[i, 0].ToString();
                        }
                    }
                    else
                    {
                        if (arr_Hdrs[i, 1].Length > 1)
                        {
                            _row = arr_Hdrs[i, 1].Substring(0, 1);
                            _col = arr_Hdrs[i, 1].Substring(1, arr_Hdrs[i, 1].Length - 1);
                            m_objRng = m_objSheet.get_Range(arr_Hdrs[i, 1].ToString(), m_objOpt);
                            m_objRng.Value2 = arr_Hdrs[i, 0].ToString();
                        }
                        if (arr_Hdrs[i, 3].Length > 1)
                        {
                            _row = arr_Hdrs[i, 3].Substring(0, 1);
                            _col = arr_Hdrs[i, 3].Substring(1, arr_Hdrs[i, 3].Length - 1);
                            m_objRng = m_objSheet.get_Range(arr_Hdrs[i, 3].ToString(), m_objOpt);
                            m_objRng.Value2 = arr_Hdrs[i, 2].ToString();
                        }



                    }
                }
                else i = 100;
            }
            // print stepBYstep

            m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(2);

            for (i = 0; i < 100; i++) for (j = 0; j < lim_arr; j++) arr_Hdrs[i, j] = "";
            _row = ""; _col = "";
            II = get_Hdrs_stps(ref arr_Hdrs, lim_arr);
            add_all_Stps(ref arr_Hdrs, II, lim_arr);
            for (i = 0; i < 100; i++)
            {
                if (arr_Hdrs[i, lim_arr - 1] != "")
                {
                    if (arr_Hdrs[i, lim_arr - 1] == "H")
                    {
                        if (arr_Hdrs[i, 1].IndexOf("|") > -1)
                        {
                            //boards
                        }
                        else
                        {
                            _row = arr_Hdrs[i, 1].Substring(0, 1);
                            _col = arr_Hdrs[i, 1].Substring(1, arr_Hdrs[i, 1].Length - 1);
                            m_objRng = m_objSheet.get_Range(arr_Hdrs[i, 1].ToString(), m_objOpt);
                            m_objRng.Value2 = arr_Hdrs[i, 0].ToString();
                        }
                    }
                    else
                    {
                        if (arr_Hdrs[i, 1].Length > 1)
                        {
                            _row = arr_Hdrs[i, 1].Substring(0, 1);
                            _col = arr_Hdrs[i, 1].Substring(1, arr_Hdrs[i, 1].Length - 1);
                            m_objRng = m_objSheet.get_Range(arr_Hdrs[i, 1].ToString(), m_objOpt);
                            m_objRng.Value2 = arr_Hdrs[i, 0].ToString();
                        }
                        if (arr_Hdrs[i, 3].Length > 1)
                        {
                            _row = arr_Hdrs[i, 3].Substring(0, 1);
                            _col = arr_Hdrs[i, 3].Substring(1, arr_Hdrs[i, 3].Length - 1);
                            m_objRng = m_objSheet.get_Range(arr_Hdrs[i, 3].ToString(), m_objOpt);
                            m_objRng.Value2 = arr_Hdrs[i, 2].ToString();
                        }



                    }
                }
                else i = 100;
            }

            m_objbook.SaveAs(MainMDI.XL_Path + @"\" + xlname + "_PRT.xls", m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objbook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();


        }

        private void XLport_Mtest(string xlname)
        {
            const int lim_arr=5;


            Object m_objOpt = System.Reflection.Missing.Value;
            Excel.Application m_objXL = new Excel.Application();
            Excel.Workbook m_objbook = m_objXL.Workbooks.Open(MainMDI.XL_Path + @"\" + xlname +".xls", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "", false, false, 0, true, m_objOpt, m_objOpt);

            //   Excel.Workbook m_objBook = m_objbooks(m_objOpt);
            Excel.Sheets m_objSheets = m_objbook.Worksheets;
            Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);
            Excel.Range m_objRng = m_objSheet.get_Range("A1", "E1"); // "C1", "D1", "E1", "F1", "G1", "H1", "I1", "J1", "K1", "L1", "M1", "N1", "O1", "P1", "Q1", "R1", "S1", "T1", "U1");
            int i =0,j=0;
            string[,] arr_Hdrs = new string[100, lim_arr];
            for (i = 0; i < 100; i++) for (j = 0; j < lim_arr; j++) arr_Hdrs [i, j] = "";
            string _row ="", _col="";
            int II = get_Hdrs(ref arr_Hdrs, lim_arr);
            add_Mtst(ref arr_Hdrs , II,lim_arr );
            for (i= 0; i < 100; i++)
            {
                if (arr_Hdrs[i, lim_arr-1] != "")
                {
                    if (arr_Hdrs[i, lim_arr-1] == "H")
                    {
                        if (arr_Hdrs[i, 1].IndexOf("|") > -1)
                        {
                            

                        }
                        else
                        {
                            _row = arr_Hdrs[i, 1].Substring(0, 1);
                            _col = arr_Hdrs[i, 1].Substring(1, arr_Hdrs[i, 1].Length - 1);
                            m_objRng = m_objSheet.get_Range(arr_Hdrs[i, 1].ToString(), m_objOpt);
                            m_objRng.Value2 = arr_Hdrs[i, 0].ToString();
                        }
                    }
                    else
                    {
                        if (arr_Hdrs[i, 1].Length > 1)
                        {
                            _row = arr_Hdrs[i, 1].Substring(0, 1);
                            _col = arr_Hdrs[i, 1].Substring(1, arr_Hdrs[i, 1].Length - 1);
                            m_objRng = m_objSheet.get_Range(arr_Hdrs[i, 1].ToString(), m_objOpt);
                            m_objRng.Value2 = arr_Hdrs[i, 0].ToString();
                        }
                        if (arr_Hdrs[i, 3].Length > 1)
                        {
                            _row = arr_Hdrs[i, 3].Substring(0, 1);
                            _col = arr_Hdrs[i, 3].Substring(1, arr_Hdrs[i, 3].Length - 1);
                            m_objRng = m_objSheet.get_Range(arr_Hdrs[i, 3].ToString(), m_objOpt);
                            m_objRng.Value2 = arr_Hdrs[i, 2].ToString();
                        }



                    }
                }
                else i = 100;
            }
// print stepBYstep

            m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(2);

            for (i = 0; i < 100; i++) for (j = 0; j < lim_arr; j++) arr_Hdrs[i, j] = "";
            _row = ""; _col = "";
            II = get_Hdrs_stps (ref arr_Hdrs, lim_arr);
            add_all_Stps(ref arr_Hdrs, II, lim_arr);
            for (i = 0; i < 100; i++)
            {
                if (arr_Hdrs[i, lim_arr - 1] != "")
                {
                    if (arr_Hdrs[i, lim_arr - 1] == "H")
                    {
                        if (arr_Hdrs[i, 1].IndexOf("|") > -1)
                        {
                            //boards
                        }
                        else
                        {
                            _row = arr_Hdrs[i, 1].Substring(0, 1);
                            _col = arr_Hdrs[i, 1].Substring(1, arr_Hdrs[i, 1].Length - 1);
                            m_objRng = m_objSheet.get_Range(arr_Hdrs[i, 1].ToString(), m_objOpt);
                            m_objRng.Value2 = arr_Hdrs[i, 0].ToString();
                        }
                    }
                    else
                    {
                        if (arr_Hdrs[i, 1].Length > 1)
                        {
                            _row = arr_Hdrs[i, 1].Substring(0, 1);
                            _col = arr_Hdrs[i, 1].Substring(1, arr_Hdrs[i, 1].Length - 1);
                            m_objRng = m_objSheet.get_Range(arr_Hdrs[i, 1].ToString(), m_objOpt);
                            m_objRng.Value2 = arr_Hdrs[i, 0].ToString();
                        }
                        if (arr_Hdrs[i, 3].Length > 1)
                        {
                            _row = arr_Hdrs[i, 3].Substring(0, 1);
                            _col = arr_Hdrs[i, 3].Substring(1, arr_Hdrs[i, 3].Length - 1);
                            m_objRng = m_objSheet.get_Range(arr_Hdrs[i, 3].ToString(), m_objOpt);
                            m_objRng.Value2 = arr_Hdrs[i, 2].ToString();
                        }



                    }
                }
                else i = 100;
            }

            m_objbook.SaveAs(MainMDI.XL_Path + @"\" + xlname + "_PRT.xls", m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objbook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();


        }





        private void XLport_Steps(string xlname)
        {
            const int lim_arr = 5;


            Object m_objOpt = System.Reflection.Missing.Value;
            Excel.Application m_objXL = new Excel.Application();
            Excel.Workbook m_objbook = m_objXL.Workbooks.Open(MainMDI.XL_Path + @"\" + xlname + ".xls", 0, true, 5, "", "", true, Excel.XlPlatform.xlWindows, "", false, false, 0, true, m_objOpt, m_objOpt);

            //   Excel.Workbook m_objBook = m_objbooks(m_objOpt);
            Excel.Sheets m_objSheets = m_objbook.Worksheets;
            Excel._Worksheet m_objSheet = (Excel._Worksheet)m_objSheets.get_Item(1);

            //         object[] objHdrs = { "Sales", "Project#", "Serial#", "Model", "VAC-PHS-HRZ", "Enclosure", "Batteries", "Battery RACK", "Options", "BIN", "Panel Assy.", "Panel Wired", "Mecha. Assy.", "Encl. Wired", "Tests", "Customer", "PO#", "Delivery Date", "Invoice Date", "Handling & Packaging", "Notes" };
            Excel.Range m_objRng = m_objSheet.get_Range("A1", "E1"); // "C1", "D1", "E1", "F1", "G1", "H1", "I1", "J1", "K1", "L1", "M1", "N1", "O1", "P1", "Q1", "R1", "S1", "T1", "U1");
            //           Excel.Font m_objFont = m_objRng.Font;
            //          m_objFont.Bold = true;
            int i = 0, j = 0;
            //    object[,] objData = new object[100, 5];
            string[,] arr_Hdrs = new string[100, lim_arr];
            for (i = 0; i < 100; i++) for (j = 0; j < lim_arr; j++) arr_Hdrs[i, j] = "";
            string _row = "", _col = "";
            int II = get_Hdrs(ref arr_Hdrs, lim_arr);
            add_Mtst(ref arr_Hdrs, II, lim_arr);
            for (i = 0; i < 100; i++)
            {
                if (arr_Hdrs[i, lim_arr - 1] != "")
                {
                    if (arr_Hdrs[i, lim_arr - 1] == "H")
                    {
                        if (arr_Hdrs[i, 1].IndexOf("|") > -1)
                        {


                        }
                        else
                        {
                            _row = arr_Hdrs[i, 1].Substring(0, 1);
                            _col = arr_Hdrs[i, 1].Substring(1, arr_Hdrs[i, 1].Length - 1);
                            m_objRng = m_objSheet.get_Range(arr_Hdrs[i, 1].ToString(), m_objOpt);
                            m_objRng.Value2 = arr_Hdrs[i, 0].ToString();
                        }
                    }
                    else
                    {
                        if (arr_Hdrs[i, 1].Length > 1)
                        {
                            _row = arr_Hdrs[i, 1].Substring(0, 1);
                            _col = arr_Hdrs[i, 1].Substring(1, arr_Hdrs[i, 1].Length - 1);
                            m_objRng = m_objSheet.get_Range(arr_Hdrs[i, 1].ToString(), m_objOpt);
                            m_objRng.Value2 = arr_Hdrs[i, 0].ToString();
                        }
                        if (arr_Hdrs[i, 3].Length > 1)
                        {
                            _row = arr_Hdrs[i, 3].Substring(0, 1);
                            _col = arr_Hdrs[i, 3].Substring(1, arr_Hdrs[i, 3].Length - 1);
                            m_objRng = m_objSheet.get_Range(arr_Hdrs[i, 3].ToString(), m_objOpt);
                            m_objRng.Value2 = arr_Hdrs[i, 2].ToString();
                        }



                    }
                }
                else i = 100;
            }

            m_objbook.SaveAs(MainMDI.XL_Path + @"\" + xlname + "_PRT.xls", m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt, Excel.XlSaveAsAccessMode.xlNoChange, m_objOpt, m_objOpt, m_objOpt, m_objOpt, m_objOpt);
            m_objbook.Close(false, m_objOpt, m_objOpt);
            m_objXL.Quit();


        }


        private void Rectif_TR_Resize(object sender, EventArgs e)
        {
            tabControl1.Height = this.Height - 286;

            tabControl1.Width = this.Width -260 ;
            groupBox2.Height = this.Height - 442;
        }

        private void errr_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        string GetDocsFNM(string st)
        {

            int ipos = st.LastIndexOf("\\");
            if (ipos < st.Length)
            {
                return (st.Substring(ipos + 1, st.Length - ipos - 1));
            }
            else return "";
        }
        private void New_Docs_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_TR_DTP_N", true))
            {
                openFileDialog3.Filter = "PDF files (*.pdf)|*.pdf";
                openFileDialog3.Multiselect = true;
                // ldocs.Text = ""; 
                DialogResult res = openFileDialog3.ShowDialog();
                if (res == DialogResult.OK)
                {
                    string[] files_list = openFileDialog3.FileNames;
                    for (int i = 0; i < files_list.Length; i++)
                    {
                        // ldocs.Text += files_list[i] + "~~";
                        ListViewItem lv = elv_docsP.Items.Add("");
                        lv.SubItems.Add(GetDocsFNM(files_list[i]));
                        lv.SubItems.Add(files_list[i]);
                        lv.SubItems.Add("NO");
                        //   lst_DocTP.Items.Add(files_list[i]);// +"\n";
                    }

                    //   G_Stout += files_list[i] + "\n";
                    //     MessageBox.Show("files: " + files_list.Length.ToString() + "\n" + G_Stout);
                }
            }
        }

        private void Sav_DocsTPRNT(string lDTPid, string DocNM, string pth, int PRT, int rnk)
        {
            string stSql = "";
            //  if (MainMDI.ALWD_USR("OR_SR2", true))
            //    {
            if (lDTPid == "")
            {
                // MainMDI.ExecSql("delete  PSM_Boards where b_RRevDetLID=" + lvCurRev.Items[Selndx].SubItems[4].Text);
                stSql = "INSERT INTO PSM_R_TRREC_DocsTP ([TR_LID],[DocName],[DocPath],[rnk],[Printed]) VALUES (" +
                       lTRLID + " , '" +
                       DocNM + "' , '" +
                       pth + "' , " +
                       rnk.ToString() + " , " +
                       PRT + ")";
                MainMDI.Exec_SQL_JFS(stSql, "inserting DocsTobePrinted...");
            }
            else
            {
                //"',[status]='O'" +
                stSql = "UPDATE PSM_R_TRREC_DocsTP SET " + " [DocName]='" + DocNM + "', [DocPath]='" + pth + "', [rnk]=" + rnk.ToString() + ", [Printed]=" + PRT.ToString() + " WHERE DTP_id=" + lDTPid;
                MainMDI.Exec_SQL_JFS(stSql, "Updating DocsTobePrinted...");
                //fill_Boards(in_DetLID);
            }


            // }
            //else MessageBox.Show("Some fields are Empty.....");
        }

        private void color_item(int _ndx, string prt)
        {
            Color myclr = (prt == "YES") ? Color.Green : Color.Red;
            for (int j = 0; j < elv_docsP.Items[_ndx].SubItems.Count; j++)
            {
                elv_docsP.Items[_ndx].UseItemStyleForSubItems = true;
                elv_docsP.Items[_ndx].SubItems[j].ForeColor = myclr;
            }

        }

        private void fill_DocsTP(string _TR_LID)
        {

            string stSql = "SELECT * FROM PSM_R_TRREC_DocsTP where tr_LID =" + _TR_LID;


            SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
            OConn.Open();
            SqlCommand Ocmd = OConn.CreateCommand();
            Ocmd.CommandText = stSql;
            SqlDataReader Oreadr = Ocmd.ExecuteReader();
            elv_docsP.Items.Clear();

            while (Oreadr.Read())
            {
                ListViewItem lv = elv_docsP.Items.Add(Oreadr["DTP_id"].ToString());

                lv.SubItems.Add(Oreadr["DocName"].ToString());
                lv.SubItems.Add(Oreadr["DocPath"].ToString());
                string prt = (Oreadr["Printed"].ToString() == "True") ? "YES" : "NO";
                lv.SubItems.Add(prt);
                color_item(elv_docsP.Items.Count - 1, prt);
            }

            OConn.Close();

        }



        private void tls_Save_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_TR_DTP_N", false) || MainMDI.ALWD_USR("OR_TR_DTP_G", false))
            {
                for (int i = 0; i < elv_docsP.Items.Count; i++)
                {
                    //  string _prt = (elv_docsP.Items[i].SubItems[3].Text == "YES") ? "1" : "0";
                    Sav_DocsTPRNT(elv_docsP.Items[i].SubItems[0].Text, elv_docsP.Items[i].SubItems[1].Text, elv_docsP.Items[i].SubItems[2].Text, (elv_docsP.Items[i].SubItems[3].Text == "YES") ? 1 : 0, i);
                }
                //       else MessageBox.Show(MainMDI.User + ": is NOT allowed to perform this option, contact you Admin....! ", "ACCESS DENIED", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                fill_DocsTP(lTRLID);
            }
        }

        private void DelDocs_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_TR_DTP_N", true))
            {
                if (MainMDI.Confirm("You Want to delete selected documents ?"))
                {
                    for (int i = 0; i < elv_docsP.SelectedItems.Count; i++)
                    {
                        int ndx = elv_docsP.SelectedItems[i].Index;
                        string stSql = "delete PSM_R_TRREC_DocsTP WHERE DTP_id=" + elv_docsP.Items[ndx].SubItems[0].Text;
                        MainMDI.Exec_SQL_JFS(stSql, "Deleting DocsTobePrinted...");

                    }
                    fill_DocsTP(lTRLID);
                }
            }
        }

        void send_ReadyTOPRINT()
        {
                     string tstman = MainMDI.Find_One_Field("select f2 from  PSM_C_GConfig where F1_Code='tstman'");
                lRateTbl.Text = tstman;
                if (tstman != MainMDI.VIDE)
                {
                    string st_owner = "\n\nThank you. \n\nUser Name: " + MainMDI.User.ToLower() + ".";
                    if (elv_docsP.Items.Count > 0 && lTRstat.Text.ToLower() == "completed")
                    {
                        MainMDI.send_email("Test_Team@primax-e.com", tstman, "Printing Test Documents: " + lcurTRNm + " of Project#" + in_RID, "Please proceed to print all test documents for the following system: " + lcurTRNm + " of Project#" + in_RID + st_owner);
                        MessageBox.Show(" Message sent to :  " + tstman);
                    }
                    else
                    {
                        string msg = "";
                        if (elv_docsP.Items.Count == 0) msg = " You must add  Documents to this List....";
                        else if (lTRstat.Text.ToLower() != "completed") msg = " This Test Report is NOT Compeleted....";
                        MessageBox.Show(msg);
                    }
                }
                else MessageBox.Show("Sorry,   NO Name, No e-mail are configured to Print Those Manuals........call you Admin.....!!!!");
           

        }
        private void RFP_Click(object sender, EventArgs e)
        {

            //string st_owner = "\n\nThank you. \n\nUser Name: " + MainMDI.User.ToLower() + ".";
            //if (MainMDI.ALWD_USR("OR_TR_DTP_N", true) && elv_docsP.Items.Count > 0 && lTRstat.Text.ToLower() == "completed")
            //{
            //    MainMDI.send_email("Test_Team@primax-e.com", "szhdanova@primax-e.com,hedebbab@primax-e.com", "Printing Test Documents for RECTIFIER: " + lcurTRNm + " of Project#" + in_RID, "Please proceed to print all test documents for the following system: " + lcurTRNm + " of Project#" + in_RID + st_owner);
            //    //     MainMDI.send_email("Test_Team@primax-e.com", "hedebbab@primax-e.com", "Printing Test Documents for RECTIFIER: " + lcurTRNm + " of Project#" + in_RID, "Please proceed to print all test documents for the following system: " + lcurTRNm + " of Project#" + in_RID + st_owner);
            //    MessageBox.Show(" Message sent ............");
            //}
            //else if (elv_docsP.Items.Count == 0) MessageBox.Show(" You must add  Documents to this List....");

            send_ReadyTOPRINT();
        }

        private void Pdoc_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_TR_DTP_N", false) || MainMDI.ALWD_USR("OR_TR_DTP_G", false))
            {
                if (elv_docsP.SelectedItems.Count == 1)
                {
                    int ndx = elv_docsP.SelectedItems[0].Index;
                    string flnme = elv_docsP.Items[ndx].SubItems[2].Text;
                    MainMDI.EXEC_FILE("Acrobat.exe", flnme);
                }
            }
        }


        private void DocsPrinted(string prt)
        {

            for (int i = 0; i < elv_docsP.SelectedItems.Count; i++)
            {
                int ndx = elv_docsP.SelectedItems[i].Index;
                elv_docsP.Items[ndx].SubItems[3].Text = prt;
                color_item(ndx, prt);
            }

        }


        private void Doc_Printed_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_TR_DTP_G", true)) DocsPrinted("YES");
        }

        private void Doc_NOTPrinted_Click(object sender, EventArgs e)
        {
            if (MainMDI.ALWD_USR("OR_TR_DTP_G", true)) DocsPrinted("NO");
        }

        private void pic_BManag_Click(object sender, EventArgs e)
        {
            manag_BRD_Manuals();
            get_Manuals(lTRLID);
            fill_Boards_by_TR_REC(lTRLID);
        }


        void manag_BRD_Manuals()
        {
            Orders_Boards_New brds = new Orders_Boards_New(lTRLID,"R" );
            brds.ShowDialog();
        }

        private void get_Manuals(string _TR_LID)
        {
            if (_TR_LID != "")
            {
                string st = "";
                mdl_sel_man.Items.Clear();
                string tt = MainMDI.Find_One_Field("select tr_manuals from PSM_R_TRREC_info where tr_LID=" + _TR_LID);
                if (tt != MainMDI.VIDE)
                {
                    int i = 0;
                    int ipos = 0;

                    while (tt.Length > 0)
                    {
                        ipos = tt.IndexOf("~~");
                        if (ipos > -1)
                        {
                            st = tt.Substring(0, ipos);
                            tt = tt.Substring(ipos + 2, tt.Length - (ipos + 2));
                        }
                        else
                        {
                            st = tt;
                            tt = "";
                        }
                        if (st != "")
                        {

                            ListViewItem lv = mdl_sel_man.Items.Add(" ");
                            lv.SubItems.Add(st);

                        }
                    }
                }
            }

        }



        private void fill_Boards_by_TR_REC(string _TR_LID)
        {
            if (_TR_LID != "")
            {
                string stSql = "SELECT B.* , C.Brd_Name from   PSM_R_Boards_RCTFR  B inner join PSM_C_Boards_List C on B.brd_Code = C.brd_Code where B.TR_LID =" + _TR_LID;


                SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
                OConn.Open();
                SqlCommand Ocmd = OConn.CreateCommand();
                Ocmd.CommandText = stSql;
                SqlDataReader Oreadr = Ocmd.ExecuteReader();
                mdl_brds_REC.Items.Clear();

                while (Oreadr.Read())
                {
                    ListViewItem lv = mdl_brds_REC.Items.Add(Oreadr["R_BrdLID"].ToString());

                    lv.SubItems.Add(Oreadr["Brd_Name"].ToString());
                    lv.SubItems.Add(Oreadr["Brd_SN"].ToString());
                    lv.SubItems.Add(Oreadr["brd_Ver"].ToString());
                    lv.SubItems.Add(Oreadr["firmwr_Ver"].ToString());
                    lv.SubItems.Add(Oreadr["b_connTo"].ToString());


                }

                OConn.Close();
            }

        }


        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
          //  if (tabControl1.SelectedIndex == 2)
         //   {
//
         //       get_Manuals(lTRLID);
         //       fill_Boards_by_TR_REC(lTRLID);
        //        fill_DocsTP(lTRLID);
         //   }
        }





        /*
          private void Export2Excel()
        {
            try
            {                
                //lvPDF is nothing but the listview control name
                string[] st = new string[lvPDF.Columns.Count];
                DirectoryInfo di = new DirectoryInfo(@"c:\PDFExtraction\");
                if (di.Exists == false)
                    di.Create();
                StreamWriter sw = new StreamWriter(@"c:\PDFExtraction\" + txtBookName.Text.Trim() + ".xls", false);
                sw.AutoFlush = true;
                for (int col = 0; col < lvPDF.Columns.Count; col++)
                {
                    sw.Write("\t" + lvPDF.Columns[col].Text.ToString());                    
                }
                
                int rowIndex = 1;
                int row = 0;
                string st1 = "";                
                for (row = 0; row < lvPDF.Items.Count; row++)
                {
                    if (rowIndex <= lvPDF.Items.Count)
                        rowIndex++;
                    st1 = "\n";
                    for (int col = 0; col < lvPDF.Columns.Count; col++)
                    {
                        st1 = st1 + "\t" + "'" + lvPDF.Items[row].SubItems[col].Text.ToString();                        
                    }
                    sw.WriteLine(st1);
                }
                sw.Close();
                FileInfo fil = new FileInfo(@"c:\PDFExtraction\" + txtBookName.Text.Trim() + ".xls");
                if (fil.Exists == true)
                    MessageBox.Show("Process Completed", "Export to Excel", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
            }
        }
         * 
         * */

    }
}
