using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
namespace PGESCOM
{
	/// <summary>
	/// Summary description for Fill_BigFile13.
	/// </summary>
	public class Fill_BigFile13 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Label t1;
		private System.Windows.Forms.Label t2;
		private System.Windows.Forms.Label lAVID;
		private System.Windows.Forms.Label lCpt;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label lDone;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label lPHS;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Label label6;
        public PictureBox picCIP;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Fill_BigFile13()
		{
			//
			//Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			//TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose(bool disposing)
		{
			if(disposing)
			{
				if(components != null)
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Fill_BigFile13));
            this.button1 = new System.Windows.Forms.Button();
            this.t1 = new System.Windows.Forms.Label();
            this.t2 = new System.Windows.Forms.Label();
            this.lAVID = new System.Windows.Forms.Label();
            this.lCpt = new System.Windows.Forms.Label();
            this.lDone = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.lPHS = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label6 = new System.Windows.Forms.Label();
            this.picCIP = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(154, 37);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(192, 28);
            this.button1.TabIndex = 0;
            this.button1.Text = "FILLing Big FILES";
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // t1
            // 
            this.t1.Location = new System.Drawing.Point(115, 332);
            this.t1.Name = "t1";
            this.t1.Size = new System.Drawing.Size(144, 19);
            this.t1.TabIndex = 1;
            // 
            // t2
            // 
            this.t2.Location = new System.Drawing.Point(442, 332);
            this.t2.Name = "t2";
            this.t2.Size = new System.Drawing.Size(144, 19);
            this.t2.TabIndex = 2;
            // 
            // lAVID
            // 
            this.lAVID.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lAVID.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lAVID.Location = new System.Drawing.Point(134, 120);
            this.lAVID.Name = "lAVID";
            this.lAVID.Size = new System.Drawing.Size(106, 37);
            this.lAVID.TabIndex = 3;
            this.lAVID.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lCpt
            // 
            this.lCpt.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lCpt.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lCpt.Location = new System.Drawing.Point(134, 166);
            this.lCpt.Name = "lCpt";
            this.lCpt.Size = new System.Drawing.Size(221, 46);
            this.lCpt.TabIndex = 5;
            this.lCpt.Text = "-";
            this.lCpt.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lDone
            // 
            this.lDone.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lDone.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lDone.ForeColor = System.Drawing.Color.Firebrick;
            this.lDone.Location = new System.Drawing.Point(134, 222);
            this.lDone.Name = "lDone";
            this.lDone.Size = new System.Drawing.Size(87, 46);
            this.lDone.TabIndex = 6;
            this.lDone.Text = "0";
            this.lDone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(19, 185);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 27);
            this.label2.TabIndex = 7;
            this.label2.Text = "Component REF:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(115, 28);
            this.label3.TabIndex = 8;
            this.label3.Text = "Avail_ID:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(67, 240);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(58, 18);
            this.label4.TabIndex = 9;
            this.label4.Text = "Done:";
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(48, 323);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(58, 28);
            this.label1.TabIndex = 10;
            this.label1.Text = "Start At:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label5
            // 
            this.label5.Location = new System.Drawing.Point(346, 323);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(86, 28);
            this.label5.TabIndex = 11;
            this.label5.Text = "Finished At:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lPHS
            // 
            this.lPHS.Location = new System.Drawing.Point(538, 102);
            this.lPHS.Name = "lPHS";
            this.lPHS.Size = new System.Drawing.Size(57, 27);
            this.lPHS.TabIndex = 12;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(355, 37);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(240, 28);
            this.button2.TabIndex = 13;
            this.button2.Text = "Update_FRMLs";
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(461, 157);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(86, 55);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 14;
            this.pictureBox1.TabStop = false;
            // 
            // label6
            // 
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(355, 37);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(240, 28);
            this.label6.TabIndex = 15;
            this.label6.Text = "Tables rebuilt successfully";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picCIP
            // 
            this.picCIP.Cursor = System.Windows.Forms.Cursors.Hand;
            this.picCIP.Image = ((System.Drawing.Image)(resources.GetObject("picCIP.Image")));
            this.picCIP.Location = new System.Drawing.Point(500, 240);
            this.picCIP.Name = "picCIP";
            this.picCIP.Size = new System.Drawing.Size(47, 48);
            this.picCIP.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.picCIP.TabIndex = 266;
            this.picCIP.TabStop = false;
            this.picCIP.Visible = false;
            // 
            // Fill_BigFile13
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(6, 15);
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(714, 310);
            this.Controls.Add(this.picCIP);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lPHS);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lDone);
            this.Controls.Add(this.lCpt);
            this.Controls.Add(this.lAVID);
            this.Controls.Add(this.t2);
            this.Controls.Add(this.t1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label6);
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Fill_BigFile13";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Fill_BigFile13";
            this.Load += new System.EventHandler(this.Fill_BigFile13_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.picCIP)).EndInit();
            this.ResumeLayout(false);

		}
		#endregion

		private void button1_Click(object sender, System.EventArgs e)
		{
			t1.Text = System.DateTime.Now.ToLongTimeString();
			t1.Refresh();
			button1.Enabled = false;
			CR_TBL6();
			MainMDI.ExecSql("Delete BGF_COST13");
			MainMDI.ExecSql("Delete BGF_VCS13");
			lPHS.Text = "1"; lPHS.Refresh();
			Cross_Avail("1", "P4500");
			lPHS.Text = "3"; lPHS.Refresh();
			Cross_Avail("3", "P4500");
			t2.Text = System.DateTime.Now.ToLongTimeString();
			t2.Refresh();
		}

		private void Aff_arr_CAL_FRML(string p, string Avail_ID)
		{
			string st = "";
			int ipos = -1;
			for (int i = 1; i < Charger.NB_FRML; i++)
			{
				if (Charger.arr_CAL_FRML[i] != "")
				{   st = Charger.arr_CAL_FRML[i];
					ipos = st.IndexOf("||", 0);
                	string stSql2 = "INSERT INTO BGF_VCS13 ([phs],[Avail_ID],[VCS_NAME], " +
						" [value]) " + " VALUES ('" + p + "', " +
						Avail_ID + ", '" + st.Substring(0, ipos) + "', '" +
						st.Substring(ipos + 2, st.Length - 2 - ipos) + "')";
					MainMDI.ExecSql(stSql2);
				}
				else break;
			}
		}

		private void Cal_AllCpt_41_Charger(string p, string Avail_id)
		{
			//this.Cursor = Cursors.WaitCursor;

			string stSql = "SELECT TBLAVAIL" + p + ".Avail_ID, COMPNT_LIST.Component_ID,COMPNT_LIST.COMPONENT_REF, TBLAVAIL" + p + ".charger, TBLAVAIL" + p + ".vdc, TBLAVAIL" + p + ".idc, link_COMPNT_AVAIL.Qty, " +
				" COMPNT_LIST.CAT1_TABLE_ID, COMPNT_LIST.CAT2_TABLE_ID, COMPNT_LIST.CAT3_TABLE_ID, COMPNT_LIST.Compnt_Type, COMPNT_LIST.Value_Type, COMPNT_LIST.nbc3Cat " +
				" FROM (TBLAVAIL" + p + " INNER JOIN link_COMPNT_AVAIL ON TBLAVAIL" + p + ".Avail_ID = link_COMPNT_AVAIL.Avail_ID) INNER JOIN COMPNT_LIST ON link_COMPNT_AVAIL.Compnt_ID = COMPNT_LIST.Component_ID " +
				" Where (((link_COMPNT_AVAIL.phs) = '" + p + "') and ((link_COMPNT_AVAIL.Avail_ID) = " + Avail_id + ")) ORDER BY TBLAVAIL" + p + ".Avail_ID, COMPNT_LIST.Component_ID";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
		    Component Cpt = new Component();
			while (Oreadr.Read())
			{
				//Cpt.CPT_COST(Convert.ToInt32(Oreadr["Component_ID"].ToString()));
				Cpt.Cal_chrg_CostADO(Convert.ToInt32(Oreadr["Component_ID"].ToString()), "C");
				lCpt.Text = Oreadr["Component_REF"].ToString();
				lCpt.Refresh();
				if (Cpt.G_PRICE != Charger.VIDE)
				{
					try
					{
						string stSql2 = "INSERT INTO BGF_COST13 ([phs],[Avail_ID],[Compnt_ID],[Desc],[Real_QTY], " + 
							" [Cost],[CAP1],[CAP2],[CAP3], " + 
							" [CAP4],[CAP5],[CAP6],[CAP7]) " + " VALUES ('" + p + "', " +
							Avail_id + ", " +
							Oreadr["Component_ID"].ToString() + ", '" +
							Cpt.G_Desc.ToString() + "', '" +
							Cpt.Real_QTY.ToString() + "', '" +
							Cpt.G_PRICE.ToString() + "', '" +
							Cpt.CAP1 + "', '" +
							Cpt.CAP2 + "', '" +
							Cpt.CAP3 + "', '" +
							Cpt.CAP4 + "', '" +
							Cpt.CAP5 + "', '" +
							Cpt.CAP6 + "', '" +
							Cpt.CAP7 + "')";
				
						MainMDI.ExecSql(stSql2);
					}
					catch (SqlException Oexp)
					{
						MessageBox.Show("Adding BG_COST13 Error...= " + Oexp.Message);
					}
				}
			}
			OConn.Close();
			Cpt.Cal_VCS(0, "C_VDCMIN");
			
			//this.Cursor = Cursors.Default;
		}

		private void Cross_Avail(string p, string x_charger)
		{
			string stSql = "SELECT charger, vdc , idc , Avail_ID FROM TBLAVAIL" + p + 
				" WHERE (charger='" + x_charger + "') order by cast(vdc AS float) ,cast(idc AS float) ";
			SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
			OConn.Open();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
            int j = 1;
			while (Oreadr.Read())
			{
				Charger CHRGR = new Charger(Convert.ToInt32(Oreadr["Avail_ID"].ToString()), "F", Oreadr["charger"].ToString(), p, Oreadr["vdc"].ToString(), Oreadr["idc"].ToString(), "0", "0");
				Cal_AllCpt_41_Charger(p, Oreadr["Avail_ID"].ToString());
				lAVID.Text = Oreadr["Avail_ID"].ToString();
				lAVID.Refresh();
				lDone.Text = Convert.ToString(j++);
				this.Refresh();
				Aff_arr_CAL_FRML(p, Oreadr["Avail_ID"].ToString());
		
				//MessageBox.Show("CONTINUE.............");
			}
		}	

	    private void CR_TBL6()
        {
	        //Create TBL6   table is 'pgm_SeekTBL6_empty'

            //MessageBox.Show("Pls Check!!!!, may be this is not workinnnnnnnnnnnnnnnng in SQL SERVER  !!  IIF() !! ");
	        MainMDI.ExecSql("delete pgm_SeekTBL6_empty ");
            //string stSql = "INSERT INTO pgm_SeekTBL6_empty ( Col1, col2, col3, col4, col5, col6, VALUE1,TABLE_NAME ) SELECT  IIf(IsNumeric([COL1]),cast[COL1] AS float),[COL1]) AS col1, IIf(IsNumeric([COL2]),cast([COL2] AS float),[COL2]) AS col2, " +
                //" IIf(IsNumeric([COL3]),cast([COL3] AS float),[COL3]) AS col3, IIf(IsNumeric([COL4]),cast([COL4] AS float),[COL4]) AS col4,  IIf(IsNumeric([COL5]),cast([COL5] AS float),[COL5]) AS col5, IIf(IsNumeric([COL6]),cast([COL6] AS float),[COL6]) AS col6, TABLES_CONTENT.VALUE1,TABLES_LIST.TABLE_NAME  " +
                //" FROM TABLES_LIST INNER JOIN TABLES_CONTENT ON TABLES_LIST.TABLE_ID = TABLES_CONTENT.TABLE_ID ";

            //ExecSql(stSql);
		    string stSql = "INSERT INTO pgm_SeekTBL6_empty (Col1, col2, col3, col4, col5, col6, VALUE1, TABLE_NAME) " +
                "  SELECT     TABLES_CONTENT.COL1 AS col1, TABLES_CONTENT.COL2 AS col2, TABLES_CONTENT.COL3 AS col3, TABLES_CONTENT.COL4 AS col4,  " +
                "  TABLES_CONTENT.COL5 AS col5, TABLES_CONTENT.COL6 AS col6, TABLES_CONTENT.VALUE1, TABLES_LIST.TABLE_NAME " +
                " FROM         TABLES_LIST INNER JOIN TABLES_CONTENT ON TABLES_LIST.TABLE_ID = TABLES_CONTENT.TABLE_ID " +
                "   ORDER BY TABLES_LIST.TABLE_NAME ";
		    MainMDI.ExecSql(stSql);
	    }

	    private void ExecSqlOLD(string stSql)
        {
	        SqlConnection OConn = new SqlConnection(MainMDI.M_stCon);
	        OConn.Open();
	        SqlCommand Ocmd = OConn.CreateCommand();
	        Ocmd.CommandText = stSql;
	        Ocmd.ExecuteNonQuery();
	        OConn.Close();
        }

		private void Fill_BigFile13_Load(object sender, System.EventArgs e)
		{
            //if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!";
            picCIP.Visible = (MainMDI.currDB == "Back_PSM_FDB" || !MainMDI.Env_PROD);
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
		    //pictureBox1.Visible = true;
			this.Cursor = Cursors.WaitCursor;
			
			CR_TBL6();

			this.Cursor = Cursors.Default;
			button2.Visible = false;
			//pictureBox1.Visible = false;
		}
    }
}