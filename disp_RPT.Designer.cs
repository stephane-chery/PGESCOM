namespace PGESCOM
{
    partial class disp_RPT
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
            this.CRV_C = new CrystalDecisions.Windows.Forms.CrystalReportViewer();
            this.P_Config1 = new PGESCOM.CR_Reports.P_Config();
            this.SuspendLayout();
            // 
            // CRV_C
            // 
            this.CRV_C.ActiveViewIndex = -1;
            this.CRV_C.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.CRV_C.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CRV_C.Location = new System.Drawing.Point(0, 0);
            this.CRV_C.Name = "CRV_C";
            this.CRV_C.SelectionFormula = "";
            this.CRV_C.ShowCloseButton = false;
            this.CRV_C.ShowExportButton = false;
            this.CRV_C.ShowGotoPageButton = false;
            this.CRV_C.ShowGroupTreeButton = false;
            this.CRV_C.ShowRefreshButton = false;
            this.CRV_C.ShowTextSearchButton = false;
            this.CRV_C.ShowZoomButton = false;
            this.CRV_C.Size = new System.Drawing.Size(975, 448);
            this.CRV_C.TabIndex = 0;
            this.CRV_C.ViewTimeSelectionFormula = "";
            this.CRV_C.DoubleClick += new System.EventHandler(this.CRV_C_DoubleClick);
            // 
            // P_Config1
            // 
            this.P_Config1.InitReport += new System.EventHandler(this.disp_RPT_Load);
            // 
            // disp_RPT
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(975, 448);
            this.Controls.Add(this.CRV_C);
            this.Name = "disp_RPT";
            this.Text = "disp_RPT";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.disp_RPT_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private CrystalDecisions.Windows.Forms.CrystalReportViewer CRV_C;
        private PGESCOM.CR_Reports.P_Config P_Config1;
       
    }
}