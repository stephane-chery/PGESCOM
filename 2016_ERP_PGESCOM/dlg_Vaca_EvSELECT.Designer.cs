namespace PGESCOM
{
    partial class dlg_Vaca_EvSELECT
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(dlg_Vaca_EvSELECT));
            this.grpBrd = new System.Windows.Forms.GroupBox();
            this.ed_EVTYPE = new PGESCOM.ed_LVmodif();
            this.Evtype = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EvTypeName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.grpID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EvTABR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.mdl_Selection = new PGESCOM.Modified_EditListView();
            this.Sell = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SELev = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.selLID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.EvABR = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.picDel = new System.Windows.Forms.PictureBox();
            this.mdl_EventDep = new PGESCOM.Modified_EditListView();
            this.sel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ItemNM = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.picSeek = new System.Windows.Forms.PictureBox();
            this.pic_GRPtoList = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lABR = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpBrd.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picDel)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_GRPtoList)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // grpBrd
            // 
            this.grpBrd.Controls.Add(this.ed_EVTYPE);
            this.grpBrd.Controls.Add(this.mdl_Selection);
            this.grpBrd.Controls.Add(this.groupBox1);
            this.grpBrd.Controls.Add(this.mdl_EventDep);
            this.grpBrd.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBrd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.grpBrd.Location = new System.Drawing.Point(0, 0);
            this.grpBrd.Name = "grpBrd";
            this.grpBrd.Size = new System.Drawing.Size(650, 412);
            this.grpBrd.TabIndex = 370;
            this.grpBrd.TabStop = false;
            // 
            // ed_EVTYPE
            // 
            this.ed_EVTYPE.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_EVTYPE.AutoArrange = false;
            this.ed_EVTYPE.BackColor = System.Drawing.Color.Moccasin;
            this.ed_EVTYPE.CheckBoxes = true;
            this.ed_EVTYPE.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Evtype,
            this.EvTypeName,
            this.grpID,
            this.EvTABR});
            this.ed_EVTYPE.Dock = System.Windows.Forms.DockStyle.Left;
            this.ed_EVTYPE.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_EVTYPE.ForeColor = System.Drawing.Color.Black;
            this.ed_EVTYPE.FullRowSelect = true;
            this.ed_EVTYPE.GridLines = true;
            this.ed_EVTYPE.Location = new System.Drawing.Point(359, 22);
            this.ed_EVTYPE.Name = "ed_EVTYPE";
            this.ed_EVTYPE.Size = new System.Drawing.Size(280, 387);
            this.ed_EVTYPE.TabIndex = 390;
            this.ed_EVTYPE.UseCompatibleStateImageBehavior = false;
            this.ed_EVTYPE.View = System.Windows.Forms.View.Details;
            this.ed_EVTYPE.SelectedIndexChanged += new System.EventHandler(this.ed_EVTYPE_SelectedIndexChanged);
            // 
            // Evtype
            // 
            this.Evtype.Text = "Select ";
            this.Evtype.Width = 46;
            // 
            // EvTypeName
            // 
            this.EvTypeName.Text = "Event Group";
            this.EvTypeName.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.EvTypeName.Width = 203;
            // 
            // grpID
            // 
            this.grpID.Text = "";
            this.grpID.Width = 0;
            // 
            // EvTABR
            // 
            this.EvTABR.Text = "";
            this.EvTABR.Width = 0;
            // 
            // mdl_Selection
            // 
            this.mdl_Selection.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.mdl_Selection.AutoArrange = false;
            this.mdl_Selection.BackColor = System.Drawing.Color.White;
            this.mdl_Selection.CheckBoxes = true;
            this.mdl_Selection.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Sell,
            this.SELev,
            this.selLID,
            this.EvABR});
            this.mdl_Selection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mdl_Selection.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdl_Selection.ForeColor = System.Drawing.Color.Black;
            this.mdl_Selection.FullRowSelect = true;
            this.mdl_Selection.GridLines = true;
            this.mdl_Selection.Location = new System.Drawing.Point(359, 22);
            this.mdl_Selection.Name = "mdl_Selection";
            this.mdl_Selection.Size = new System.Drawing.Size(288, 387);
            this.mdl_Selection.TabIndex = 389;
            this.mdl_Selection.UseCompatibleStateImageBehavior = false;
            this.mdl_Selection.View = System.Windows.Forms.View.Details;
            // 
            // Sell
            // 
            this.Sell.Text = "";
            this.Sell.Width = 0;
            // 
            // SELev
            // 
            this.SELev.Text = "Selection";
            this.SELev.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SELev.Width = 263;
            // 
            // selLID
            // 
            this.selLID.Text = "";
            this.selLID.Width = 0;
            // 
            // EvABR
            // 
            this.EvABR.Text = "";
            this.EvABR.Width = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.picDel);
            this.groupBox1.Location = new System.Drawing.Point(760, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(82, 387);
            this.groupBox1.TabIndex = 380;
            this.groupBox1.TabStop = false;
            // 
            // picDel
            // 
            this.picDel.BackColor = System.Drawing.Color.Transparent;
            this.picDel.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picDel.Image = ((System.Drawing.Image)(resources.GetObject("picDel.Image")));
            this.picDel.Location = new System.Drawing.Point(6, 157);
            this.picDel.Name = "picDel";
            this.picDel.Size = new System.Drawing.Size(66, 63);
            this.picDel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picDel.TabIndex = 391;
            this.picDel.TabStop = false;
            this.picDel.Click += new System.EventHandler(this.picDel_Click);
            // 
            // mdl_EventDep
            // 
            this.mdl_EventDep.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.mdl_EventDep.AutoArrange = false;
            this.mdl_EventDep.BackColor = System.Drawing.Color.LightBlue;
            this.mdl_EventDep.CheckBoxes = true;
            this.mdl_EventDep.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sel,
            this.ItemNM,
            this.lid});
            this.mdl_EventDep.Dock = System.Windows.Forms.DockStyle.Left;
            this.mdl_EventDep.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdl_EventDep.ForeColor = System.Drawing.Color.Black;
            this.mdl_EventDep.FullRowSelect = true;
            this.mdl_EventDep.GridLines = true;
            this.mdl_EventDep.Location = new System.Drawing.Point(3, 22);
            this.mdl_EventDep.Name = "mdl_EventDep";
            this.mdl_EventDep.Size = new System.Drawing.Size(356, 387);
            this.mdl_EventDep.TabIndex = 379;
            this.mdl_EventDep.UseCompatibleStateImageBehavior = false;
            this.mdl_EventDep.View = System.Windows.Forms.View.Details;
            // 
            // sel
            // 
            this.sel.Text = "Select";
            this.sel.Width = 42;
            // 
            // ItemNM
            // 
            this.ItemNM.Text = "Vacation / Departement";
            this.ItemNM.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.ItemNM.Width = 278;
            // 
            // lid
            // 
            this.lid.Text = "";
            this.lid.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.lid.Width = 0;
            // 
            // picSeek
            // 
            this.picSeek.BackColor = System.Drawing.Color.Transparent;
            this.picSeek.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picSeek.Image = ((System.Drawing.Image)(resources.GetObject("picSeek.Image")));
            this.picSeek.Location = new System.Drawing.Point(830, 415);
            this.picSeek.Name = "picSeek";
            this.picSeek.Size = new System.Drawing.Size(80, 68);
            this.picSeek.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picSeek.TabIndex = 389;
            this.picSeek.TabStop = false;
            this.picSeek.Click += new System.EventHandler(this.picSeek_Click);
            // 
            // pic_GRPtoList
            // 
            this.pic_GRPtoList.BackColor = System.Drawing.Color.Transparent;
            this.pic_GRPtoList.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pic_GRPtoList.Image = ((System.Drawing.Image)(resources.GetObject("pic_GRPtoList.Image")));
            this.pic_GRPtoList.Location = new System.Drawing.Point(12, 418);
            this.pic_GRPtoList.Name = "pic_GRPtoList";
            this.pic_GRPtoList.Size = new System.Drawing.Size(80, 68);
            this.pic_GRPtoList.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic_GRPtoList.TabIndex = 390;
            this.pic_GRPtoList.TabStop = false;
            this.pic_GRPtoList.Visible = false;
            this.pic_GRPtoList.Click += new System.EventHandler(this.pic_GRPtoList_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(98, 415);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(80, 68);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 391;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Visible = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // lABR
            // 
            this.lABR.BackColor = System.Drawing.Color.Bisque;
            this.lABR.Location = new System.Drawing.Point(203, 427);
            this.lABR.Name = "lABR";
            this.lABR.Size = new System.Drawing.Size(35, 21);
            this.lABR.TabIndex = 392;
            this.lABR.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.LimeGreen;
            this.btnOK.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(457, 418);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 32);
            this.btnOK.TabIndex = 393;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LimeGreen;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(548, 418);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 32);
            this.btnCancel.TabIndex = 394;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // dlg_Vaca_EvSELECT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(650, 458);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.picSeek);
            this.Controls.Add(this.lABR);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.grpBrd);
            this.Controls.Add(this.pic_GRPtoList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "dlg_Vaca_EvSELECT";
            this.Text = "Events / Vacations  SELECTION";
            this.Load += new System.EventHandler(this.dlg_Vaca_EvSELECT_Load);
            this.grpBrd.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picDel)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picSeek)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_GRPtoList)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBrd;
        public Modified_EditListView mdl_Selection;
        private System.Windows.Forms.ColumnHeader Sell;
        private System.Windows.Forms.ColumnHeader SELev;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox picSeek;
        private System.Windows.Forms.PictureBox picDel;
        private System.Windows.Forms.PictureBox pic_GRPtoList;
        public Modified_EditListView mdl_EventDep;
        private System.Windows.Forms.ColumnHeader sel;
        private System.Windows.Forms.ColumnHeader ItemNM;
        private System.Windows.Forms.ColumnHeader lid;
        private System.Windows.Forms.ColumnHeader selLID;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lABR;
        private System.Windows.Forms.ColumnHeader EvABR;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private ed_LVmodif ed_EVTYPE;
        private System.Windows.Forms.ColumnHeader Evtype;
        private System.Windows.Forms.ColumnHeader EvTypeName;
        private System.Windows.Forms.ColumnHeader grpID;
        private System.Windows.Forms.ColumnHeader EvTABR;
    }
}