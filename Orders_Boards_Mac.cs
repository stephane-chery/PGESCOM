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
	public class Orders_Boards_Mac: System.Windows.Forms.Form
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
        private Button btnCan;
        private Button btnNewSNb;
        public TextBox tBrdMAC;
        private Label label66;
        private Button btnSave;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

        public Orders_Boards_Mac()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

	

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Orders_Boards_Mac));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnCan = new System.Windows.Forms.Button();
            this.btnNewSNb = new System.Windows.Forms.Button();
            this.tBrdMAC = new System.Windows.Forms.TextBox();
            this.label66 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.del = new System.Windows.Forms.ToolStripButton();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnNewSNb);
            this.groupBox1.Controls.Add(this.tBrdMAC);
            this.groupBox1.Controls.Add(this.label66);
            this.groupBox1.Controls.Add(this.btnCan);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Top;
            this.groupBox1.ForeColor = System.Drawing.Color.Blue;
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(806, 60);
            this.groupBox1.TabIndex = 329;
            this.groupBox1.TabStop = false;
            // 
            // btnCan
            // 
            this.btnCan.ForeColor = System.Drawing.Color.Black;
            this.btnCan.Location = new System.Drawing.Point(719, 19);
            this.btnCan.Name = "btnCan";
            this.btnCan.Size = new System.Drawing.Size(81, 31);
            this.btnCan.TabIndex = 0;
            this.btnCan.Text = "Cancel";
            this.btnCan.UseVisualStyleBackColor = true;
            this.btnCan.Click += new System.EventHandler(this.btnCan_Click);
            // 
            // btnNewSNb
            // 
            this.btnNewSNb.ForeColor = System.Drawing.Color.Maroon;
            this.btnNewSNb.Location = new System.Drawing.Point(383, 23);
            this.btnNewSNb.Name = "btnNewSNb";
            this.btnNewSNb.Size = new System.Drawing.Size(66, 23);
            this.btnNewSNb.TabIndex = 339;
            this.btnNewSNb.Text = "New";
            this.btnNewSNb.UseVisualStyleBackColor = true;
            this.btnNewSNb.Click += new System.EventHandler(this.btnNewSNb_Click);
            // 
            // tBrdMAC
            // 
            this.tBrdMAC.BackColor = System.Drawing.Color.Lavender;
            this.tBrdMAC.Font = new System.Drawing.Font("Microsoft Sans Serif", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tBrdMAC.ForeColor = System.Drawing.Color.DarkRed;
            this.tBrdMAC.Location = new System.Drawing.Point(201, 16);
            this.tBrdMAC.MaxLength = 49;
            this.tBrdMAC.Multiline = true;
            this.tBrdMAC.Name = "tBrdMAC";
            this.tBrdMAC.ReadOnly = true;
            this.tBrdMAC.Size = new System.Drawing.Size(182, 37);
            this.tBrdMAC.TabIndex = 338;
            this.tBrdMAC.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label66
            // 
            this.label66.BackColor = System.Drawing.SystemColors.Control;
            this.label66.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.label66.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label66.ForeColor = System.Drawing.Color.Black;
            this.label66.Location = new System.Drawing.Point(12, 27);
            this.label66.Name = "label66";
            this.label66.Size = new System.Drawing.Size(189, 25);
            this.label66.TabIndex = 337;
            this.label66.Text = "Board MAC Adress:";
            this.label66.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(621, 19);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(92, 31);
            this.btnSave.TabIndex = 340;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
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
            // Orders_Boards_Mac
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(806, 66);
            this.Controls.Add(this.groupBox1);
            this.ForeColor = System.Drawing.SystemColors.Desktop;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Orders_Boards_Mac";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Restore Config  / Test Report";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion




       




        private void btnCan_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

     
	


        private void btnNewSNb_Click(object sender, EventArgs e)
        {
            //      string macAdrs = MainMDI.Find_One_Field("SELECT mac_adrs  FROM [Orig_PSM_FDB].[dbo].[PSM_B_MAC_GenID] where flaged='false' order by MAC_adrs");

            tBrdMAC.Text = "";
            string macAdrs = MainMDI.Find_One_Field("SELECT mac_adrs   FROM [Orig_PSM_FDB].[dbo].[PSM_B_MAC_GenID]  order by MAC_adrs desc");
            if (macAdrs != MainMDI.VIDE)
            {
                tBrdMAC.Text = Convert.ToString(Int32.Parse(macAdrs) + 1);
            }
            else
            {

                MessageBox.Show("Sorry, Can not generate MAC adress....check with your Admin !!!");

            }
            btnSave.Enabled = (tBrdMAC.Text.Length > 1);


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string log="MAC by=" + MainMDI.User + " on=" + DateTime.Now.ToShortDateString ();
            MainMDI.Exec_SQL_JFS("insert into PSM_B_MAC_GenID ([flaged],[log]) VALUES (1,'" + log + "')","new MAC adrs...");
            this.Hide();
        }
		
		
	
		
	}
}
