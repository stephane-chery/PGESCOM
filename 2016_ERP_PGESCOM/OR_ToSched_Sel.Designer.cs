namespace PGESCOM
{
    partial class OR_ToSched_Sel
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OR_ToSched_Sel));
            this.grpBrd = new System.Windows.Forms.GroupBox();
            this.grpSTD = new System.Windows.Forms.GroupBox();
            this.mdl_STD = new PGESCOM.Modified_EditListView();
            this.sel = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AWG_CPT = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Dura = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.AWGCPTlid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.lineID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ed_Options = new PGESCOM.ed_LVmodif();
            this.selOp = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SCHMnb = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.opt = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sc_desc = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.duraPC = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.optLID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.sc_OPTlid = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnOK = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.grpBrd.SuspendLayout();
            this.grpSTD.SuspendLayout();
            this.SuspendLayout();
            // 
            // grpBrd
            // 
            this.grpBrd.Controls.Add(this.grpSTD);
            this.grpBrd.Controls.Add(this.ed_Options);
            this.grpBrd.Dock = System.Windows.Forms.DockStyle.Top;
            this.grpBrd.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            this.grpBrd.Location = new System.Drawing.Point(0, 0);
            this.grpBrd.Name = "grpBrd";
            this.grpBrd.Size = new System.Drawing.Size(750, 469);
            this.grpBrd.TabIndex = 370;
            this.grpBrd.TabStop = false;
            // 
            // grpSTD
            // 
            this.grpSTD.Controls.Add(this.mdl_STD);
            this.grpSTD.Dock = System.Windows.Forms.DockStyle.Fill;
            this.grpSTD.Location = new System.Drawing.Point(3, 22);
            this.grpSTD.Name = "grpSTD";
            this.grpSTD.Size = new System.Drawing.Size(744, 444);
            this.grpSTD.TabIndex = 391;
            this.grpSTD.TabStop = false;
            this.grpSTD.Enter += new System.EventHandler(this.grpSTD_Enter);
            // 
            // mdl_STD
            // 
            this.mdl_STD.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.mdl_STD.AutoArrange = false;
            this.mdl_STD.BackColor = System.Drawing.Color.LightBlue;
            this.mdl_STD.CheckBoxes = true;
            this.mdl_STD.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.sel,
            this.AWG_CPT,
            this.Dura,
            this.AWGCPTlid,
            this.lineID});
            this.mdl_STD.Dock = System.Windows.Forms.DockStyle.Left;
            this.mdl_STD.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mdl_STD.ForeColor = System.Drawing.Color.Black;
            this.mdl_STD.FullRowSelect = true;
            this.mdl_STD.GridLines = true;
            this.mdl_STD.Location = new System.Drawing.Point(3, 22);
            this.mdl_STD.Name = "mdl_STD";
            this.mdl_STD.Size = new System.Drawing.Size(495, 419);
            this.mdl_STD.TabIndex = 380;
            this.mdl_STD.UseCompatibleStateImageBehavior = false;
            this.mdl_STD.View = System.Windows.Forms.View.Details;
            // 
            // sel
            // 
            this.sel.Text = "Select";
            this.sel.Width = 44;
            // 
            // AWG_CPT
            // 
            this.AWG_CPT.Text = "AWG / Component";
            this.AWG_CPT.Width = 349;
            // 
            // Dura
            // 
            this.Dura.Text = "Time";
            this.Dura.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.Dura.Width = 74;
            // 
            // AWGCPTlid
            // 
            this.AWGCPTlid.Text = "";
            this.AWGCPTlid.Width = 0;
            // 
            // lineID
            // 
            this.lineID.Text = "";
            this.lineID.Width = 0;
            // 
            // ed_Options
            // 
            this.ed_Options.Alignment = System.Windows.Forms.ListViewAlignment.Default;
            this.ed_Options.AutoArrange = false;
            this.ed_Options.BackColor = System.Drawing.Color.Moccasin;
            this.ed_Options.CheckBoxes = true;
            this.ed_Options.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.selOp,
            this.SCHMnb,
            this.opt,
            this.sc_desc,
            this.duraPC,
            this.optLID,
            this.sc_OPTlid});
            this.ed_Options.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ed_Options.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ed_Options.ForeColor = System.Drawing.Color.Black;
            this.ed_Options.FullRowSelect = true;
            this.ed_Options.GridLines = true;
            this.ed_Options.Location = new System.Drawing.Point(3, 22);
            this.ed_Options.Name = "ed_Options";
            this.ed_Options.Size = new System.Drawing.Size(744, 444);
            this.ed_Options.TabIndex = 390;
            this.ed_Options.UseCompatibleStateImageBehavior = false;
            this.ed_Options.View = System.Windows.Forms.View.Details;
            // 
            // selOp
            // 
            this.selOp.Text = "Select";
            this.selOp.Width = 42;
            // 
            // SCHMnb
            // 
            this.SCHMnb.Text = "Schema #";
            this.SCHMnb.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.SCHMnb.Width = 75;
            // 
            // opt
            // 
            this.opt.Text = "Options";
            this.opt.Width = 206;
            // 
            // sc_desc
            // 
            this.sc_desc.Text = "Description";
            this.sc_desc.Width = 329;
            // 
            // duraPC
            // 
            this.duraPC.Text = "Time";
            this.duraPC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // optLID
            // 
            this.optLID.Text = "";
            this.optLID.Width = 0;
            // 
            // sc_OPTlid
            // 
            this.sc_OPTlid.Text = "";
            this.sc_OPTlid.Width = 0;
            // 
            // btnOK
            // 
            this.btnOK.BackColor = System.Drawing.Color.LimeGreen;
            this.btnOK.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnOK.Location = new System.Drawing.Point(554, 475);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(85, 43);
            this.btnOK.TabIndex = 393;
            this.btnOK.Text = "SAVE";
            this.btnOK.UseVisualStyleBackColor = false;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.LimeGreen;
            this.btnCancel.Font = new System.Drawing.Font("Verdana", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(645, 475);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(91, 43);
            this.btnCancel.TabIndex = 394;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click_1);
            // 
            // OR_ToSched_Sel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(750, 530);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.grpBrd);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "OR_ToSched_Sel";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Standards / Options  SELECTION";
            this.Load += new System.EventHandler(this.dlg_Vaca_EvSELECT_Load);
            this.grpBrd.ResumeLayout(false);
            this.grpSTD.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grpBrd;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Button btnCancel;
        private ed_LVmodif ed_Options;
        private System.Windows.Forms.ColumnHeader selOp;
        private System.Windows.Forms.ColumnHeader SCHMnb;
        private System.Windows.Forms.ColumnHeader opt;
        private System.Windows.Forms.ColumnHeader sc_desc;
        private System.Windows.Forms.ColumnHeader optLID;
        private System.Windows.Forms.ColumnHeader duraPC;
        private System.Windows.Forms.GroupBox grpSTD;
        public Modified_EditListView mdl_STD;
        private System.Windows.Forms.ColumnHeader sel;
        private System.Windows.Forms.ColumnHeader AWG_CPT;
        private System.Windows.Forms.ColumnHeader Dura;
        private System.Windows.Forms.ColumnHeader AWGCPTlid;
        private System.Windows.Forms.ColumnHeader lineID;
        private System.Windows.Forms.ColumnHeader sc_OPTlid;
    }
}