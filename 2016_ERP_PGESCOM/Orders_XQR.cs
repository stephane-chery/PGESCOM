using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb ;
using System.Data.SqlClient ;
namespace PGESCOM
{
	/// <summary>
	/// Summary description for Company.
	/// </summary>
	public class Orders_XQR: System.Windows.Forms.Form
	{
        private string In_QR_ID;
		private char in_c;
		private System.Windows.Forms.GroupBox groupBox3;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label14;
		private System.Windows.Forms.Label label15;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Button btnCancel;
		public System.Windows.Forms.TextBox tLang;
		private System.Windows.Forms.Label lstatus;
		public System.Windows.Forms.TextBox tOprice;
		public System.Windows.Forms.TextBox tQprice;
		public System.Windows.Forms.TextBox tEmp;
		public System.Windows.Forms.TextBox tdd;
		public System.Windows.Forms.TextBox tQid;
		public System.Windows.Forms.TextBox tpo;
		public System.Windows.Forms.TextBox tComp;
		public System.Windows.Forms.TextBox tPname;
		private System.Windows.Forms.TextBox tCon;
		public System.Windows.Forms.TextBox tOdate;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		public System.Windows.Forms.TextBox tRid;
		private System.ComponentModel.IContainer components;

		public Orders_XQR(char X_c,string x_QR_ID)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			in_c=X_c ;
			In_QR_ID = x_QR_ID;
			fill_Quote();
         
			

		//	Fill_frmCompany ();
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Orders_XQR));
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.tRid = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.tOdate = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tLang = new System.Windows.Forms.TextBox();
            this.lstatus = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.tOprice = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.tQprice = new System.Windows.Forms.TextBox();
            this.tEmp = new System.Windows.Forms.TextBox();
            this.tdd = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.tQid = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.tpo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.tComp = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.tPname = new System.Windows.Forms.TextBox();
            this.tCon = new System.Windows.Forms.TextBox();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.tRid);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.tOdate);
            this.groupBox3.Controls.Add(this.label3);
            this.groupBox3.Controls.Add(this.btnCancel);
            this.groupBox3.Controls.Add(this.label7);
            this.groupBox3.Controls.Add(this.tLang);
            this.groupBox3.Controls.Add(this.lstatus);
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.tOprice);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.tQprice);
            this.groupBox3.Controls.Add(this.tEmp);
            this.groupBox3.Controls.Add(this.tdd);
            this.groupBox3.Controls.Add(this.label15);
            this.groupBox3.Controls.Add(this.tQid);
            this.groupBox3.Controls.Add(this.label14);
            this.groupBox3.Controls.Add(this.tpo);
            this.groupBox3.Controls.Add(this.label8);
            this.groupBox3.Controls.Add(this.tComp);
            this.groupBox3.Controls.Add(this.label1);
            this.groupBox3.Controls.Add(this.label10);
            this.groupBox3.Controls.Add(this.label9);
            this.groupBox3.Controls.Add(this.label2);
            this.groupBox3.Controls.Add(this.tPname);
            this.groupBox3.Controls.Add(this.tCon);
            this.groupBox3.Location = new System.Drawing.Point(8, 8);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(584, 184);
            this.groupBox3.TabIndex = 63;
            this.groupBox3.TabStop = false;
            // 
            // tRid
            // 
            this.tRid.BackColor = System.Drawing.Color.AliceBlue;
            this.tRid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tRid.Location = new System.Drawing.Point(229, 11);
            this.tRid.Name = "tRid";
            this.tRid.ReadOnly = true;
            this.tRid.Size = new System.Drawing.Size(108, 20);
            this.tRid.TabIndex = 97;
            // 
            // label4
            // 
            this.label4.Location = new System.Drawing.Point(176, 11);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 20);
            this.label4.TabIndex = 96;
            this.label4.Text = "Order #:";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tOdate
            // 
            this.tOdate.BackColor = System.Drawing.Color.AliceBlue;
            this.tOdate.Location = new System.Drawing.Point(80, 92);
            this.tOdate.Name = "tOdate";
            this.tOdate.ReadOnly = true;
            this.tOdate.Size = new System.Drawing.Size(80, 20);
            this.tOdate.TabIndex = 95;
            this.tOdate.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.Location = new System.Drawing.Point(10, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(68, 20);
            this.label3.TabIndex = 94;
            this.label3.Text = "Order Date:";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnCancel
            // 
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.btnCancel.Location = new System.Drawing.Point(501, 150);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(72, 24);
            this.btnCancel.TabIndex = 93;
            this.btnCancel.Text = "Exit";
            // 
            // label7
            // 
            this.label7.Location = new System.Drawing.Point(340, 32);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(61, 20);
            this.label7.TabIndex = 92;
            this.label7.Text = "Language:";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tLang
            // 
            this.tLang.BackColor = System.Drawing.Color.AliceBlue;
            this.tLang.Location = new System.Drawing.Point(403, 33);
            this.tLang.Name = "tLang";
            this.tLang.ReadOnly = true;
            this.tLang.Size = new System.Drawing.Size(173, 20);
            this.tLang.TabIndex = 91;
            // 
            // lstatus
            // 
            this.lstatus.Font = new System.Drawing.Font("Comic Sans MS", 20.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstatus.ForeColor = System.Drawing.Color.Red;
            this.lstatus.Location = new System.Drawing.Point(379, 86);
            this.lstatus.Name = "lstatus";
            this.lstatus.Size = new System.Drawing.Size(189, 31);
            this.lstatus.TabIndex = 90;
            this.lstatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.ForeColor = System.Drawing.Color.Blue;
            this.label6.Location = new System.Drawing.Point(10, 157);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(95, 20);
            this.label6.TabIndex = 89;
            this.label6.Text = "Total Order Price:";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tOprice
            // 
            this.tOprice.BackColor = System.Drawing.Color.AliceBlue;
            this.tOprice.ForeColor = System.Drawing.Color.DarkBlue;
            this.tOprice.Location = new System.Drawing.Point(105, 157);
            this.tOprice.Name = "tOprice";
            this.tOprice.ReadOnly = true;
            this.tOprice.Size = new System.Drawing.Size(167, 20);
            this.tOprice.TabIndex = 88;
            // 
            // label5
            // 
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(8, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(98, 20);
            this.label5.TabIndex = 87;
            this.label5.Text = "Total Quote Price:";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tQprice
            // 
            this.tQprice.BackColor = System.Drawing.Color.AliceBlue;
            this.tQprice.ForeColor = System.Drawing.Color.Brown;
            this.tQprice.Location = new System.Drawing.Point(105, 137);
            this.tQprice.Name = "tQprice";
            this.tQprice.ReadOnly = true;
            this.tQprice.Size = new System.Drawing.Size(167, 20);
            this.tQprice.TabIndex = 86;
            // 
            // tEmp
            // 
            this.tEmp.BackColor = System.Drawing.Color.AliceBlue;
            this.tEmp.Location = new System.Drawing.Point(80, 72);
            this.tEmp.Name = "tEmp";
            this.tEmp.ReadOnly = true;
            this.tEmp.Size = new System.Drawing.Size(258, 20);
            this.tEmp.TabIndex = 85;
            // 
            // tdd
            // 
            this.tdd.BackColor = System.Drawing.Color.AliceBlue;
            this.tdd.Location = new System.Drawing.Point(240, 92);
            this.tdd.Name = "tdd";
            this.tdd.ReadOnly = true;
            this.tdd.Size = new System.Drawing.Size(98, 20);
            this.tdd.TabIndex = 79;
            this.tdd.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label15
            // 
            this.label15.Location = new System.Drawing.Point(160, 92);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(82, 20);
            this.label15.TabIndex = 78;
            this.label15.Text = "Delivery Date:";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tQid
            // 
            this.tQid.BackColor = System.Drawing.Color.AliceBlue;
            this.tQid.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tQid.Location = new System.Drawing.Point(80, 12);
            this.tQid.Name = "tQid";
            this.tQid.ReadOnly = true;
            this.tQid.Size = new System.Drawing.Size(93, 20);
            this.tQid.TabIndex = 77;
            // 
            // label14
            // 
            this.label14.Location = new System.Drawing.Point(27, 12);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(49, 20);
            this.label14.TabIndex = 76;
            this.label14.Text = "Quote #:";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tpo
            // 
            this.tpo.BackColor = System.Drawing.Color.AliceBlue;
            this.tpo.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tpo.Location = new System.Drawing.Point(80, 112);
            this.tpo.Name = "tpo";
            this.tpo.ReadOnly = true;
            this.tpo.Size = new System.Drawing.Size(109, 20);
            this.tpo.TabIndex = 71;
            // 
            // label8
            // 
            this.label8.Location = new System.Drawing.Point(2, 113);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 20);
            this.label8.TabIndex = 70;
            this.label8.Text = "Customer PO:";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tComp
            // 
            this.tComp.BackColor = System.Drawing.Color.AliceBlue;
            this.tComp.Location = new System.Drawing.Point(80, 32);
            this.tComp.Name = "tComp";
            this.tComp.ReadOnly = true;
            this.tComp.Size = new System.Drawing.Size(257, 20);
            this.tComp.TabIndex = 65;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(14, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 57;
            this.label1.Text = "Company:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label10
            // 
            this.label10.Location = new System.Drawing.Point(15, 72);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(59, 20);
            this.label10.TabIndex = 27;
            this.label10.Text = "Employee:";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label9
            // 
            this.label9.Location = new System.Drawing.Point(20, 51);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(60, 23);
            this.label9.TabIndex = 15;
            this.label9.Text = "Contact:";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(343, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 13;
            this.label2.Text = "Project:";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tPname
            // 
            this.tPname.BackColor = System.Drawing.Color.AliceBlue;
            this.tPname.Location = new System.Drawing.Point(403, 13);
            this.tPname.Name = "tPname";
            this.tPname.ReadOnly = true;
            this.tPname.Size = new System.Drawing.Size(173, 20);
            this.tPname.TabIndex = 12;
            // 
            // tCon
            // 
            this.tCon.BackColor = System.Drawing.Color.AliceBlue;
            this.tCon.Location = new System.Drawing.Point(80, 52);
            this.tCon.Name = "tCon";
            this.tCon.ReadOnly = true;
            this.tCon.Size = new System.Drawing.Size(257, 20);
            this.tCon.TabIndex = 82;
            // 
            // Orders_XQR
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(602, 200);
            this.Controls.Add(this.groupBox3);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Orders_XQR";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Old Orders";
            this.Load += new System.EventHandler(this.Orders_XQR_Load);
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);

		}
		#endregion

	

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			
			this.Hide ();
		}
		private void fill_Quote()
		{
			string stSql = "select * FROM PSM_PXOrders where OldRlid=" + In_QR_ID;
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ())
			{
				tComp.Text =  Oreadr["CompanyName"].ToString(); 
				tQid.Text =  Oreadr["QuoteNumber"].ToString(); 
				tRid.Text =  Oreadr["OrderNumber"].ToString(); 
				tCon.Text =  Oreadr["ContactName"].ToString(); 
				tEmp.Text =  Oreadr["EmployeeName"].ToString(); 
				if (Oreadr["DeliveryDate"].ToString()!="" ) tdd.Text =  Oreadr["DeliveryDate"].ToString().Substring(0,10); 
				tpo.Text =  Oreadr["CustomerPO"].ToString(); 
				tPname.Text =  Oreadr["ProjectName"].ToString(); 
				tLang.Text =  Oreadr["Language"].ToString(); 
				tQprice.Text =  "$ " + Oreadr["TotalQuotePrice"].ToString(); 
				tOprice.Text = "$ " +  Oreadr["TotalOrderPrice"].ToString(); 
				tOdate.Text =  Oreadr["OrderDate"].ToString().Substring(0,10) ; 
				if (Oreadr["Shipped"].ToString()=="True" ) lstatus.Text ="Shipped";
				if (Oreadr["Cancelled"].ToString()=="True" ) lstatus.Text ="Cancelled";
			}
	
			OConn.Close(); 
				 
		}

		private void Orders_XQR_Load(object sender, System.EventArgs e)
		{
            if (MainMDI.currDB == "Back_PSM_FDB") this.Text = "Back_PSM_FDB !!!!!!!!!!!!!!!!!!!"; 
		}

		/*
		private void tabPage1_Click(object sender, System.EventArgs e)
		{
		
		}

	

		private void btnAdrs_Click(object sender, System.EventArgs e)
		{
		    
			
			dlgAdrs dAdrs = new dlgAdrs(lMainAdrs.Text  );
			dAdrs.ShowDialog(); 
			if (dAdrs.tStreet.Text   != ""  )  lMainAdrs.Text = dAdrs.tStreet.Text + ", " + dAdrs.cbCity.Text + ", " + dAdrs.cbSP.Text  + ", " + dAdrs.tZip.Text  + ", " + dAdrs.cbCountry .Text     ;
		}

	

	


		private void Company_Load(object sender, System.EventArgs e)
		{
		    
		}

	

		private void cbActivity_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
		//	string tt=e.KeyChar.ToString ();
		//	int ndx=cbActivity.FindString(tt  );
		//	MessageBox.Show ("ndx= " + ndx.ToString ()+ "  tt= " +tt);
		//	cbActivity.SelectedIndex=ndx; 
		}

		private void tabControl1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}


		private bool fields_ok()
		{
			return true;
		}
		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if (fields_ok()) 
			{ 
				if (btnOK.Text == "&Save") 
				{
					try
					{
						string stSql= "INSERT INTO PSM_COMPANY ([Cpny_Name1],[M_Adrs], " + 
							" [Tel1],[Fax],[TollFree],[Web],[Email],[Customer],[Supplier], " + 
							" [Manufacturer],[Cpny_Name2],[Cpny_Main],[Q_Adrs],[P_Adrs],[S_Adrs],[I_Adrs],[Tel2], " + 
							"[CustomerType],[TermID],[CreditLim],[Currency],[ShipVia_ID],[IncoTerm_ID], " +
							"[City],[Province_State],[Country_Name],[actvId]) VALUES ('" +
							tCompanyName1.Text.Replace("'","''")   + "', '" + 	lMainAdrs.Text.Replace("'","''")    + "', '" + tTel1.Text    + "', '" +
							tFax.Text   + "', '" + tToll.Text + "', '" + tWeb.Text + "', '" +
							tEmail.Text + "', " + chkCust.Checked   + ", " + chkSupp.Checked   + ", " +  chkManufac.Checked  + ", '" +
							tCompanyName2.Text.Replace("'","''") + "', "    + lMainCpnyID.Text + ", '" + lQA.Text.Replace("'","''") + "', '" +
							lPA.Text.Replace("'","''") +  "', '"  +  lSA.Text.Replace("'","''") + "', '" + lIA.Text.Replace("'","''") + "', '" +
							tTel2.Text + "', " +	lcustmTp.Text + ", " + lTermsId.Text  + ", '" + tCreditLim.Text + "', '" +
							cbCurr.Text + "', " +lViaId.Text + ", " + lInTermId.Text + ", '" +
							"" + "', '" +"" + "', '" + "" + "', " + lActId.Text +")" ;
						MainMDI.ExecSql(stSql);
					}
					catch (OleDbException Oexp)
					{
						MessageBox.Show("Adding Option Error...= " + Oexp.Message );
					}
				}
				else 
				{	
					try
					{
						string stSql= "UPDATE PSM_COMPANY SET " +
							" [Cpny_Name1]='" + tCompanyName1.Text.Replace("'","''") + "', " +
							" [M_Adrs]='" + lMainAdrs.Text.Replace("'","''") + "', " +
							" [Tel1]='" + tTel1.Text  + "', " +
							" [Fax]='" + tFax.Text   + "', " +
							" [TollFree]='" +  tToll.Text   + "', " +
							" [Web]='" + tWeb.Text   + "', " +
							" [Email]='" + tEmail.Text + "', " +
							" [Customer]=" + chkCust.Checked   + ", " +
							" [Supplier]=" + chkSupp.Checked   + ", " +
							" [Manufacturer]=" + chkManufac.Checked   + ", " +
							" [Cpny_Name2]='" + tCompanyName2.Text.Replace("'","''")  + "', " +
							" [Cpny_Main]=" + lMainCpnyID.Text + ", " +
							" [Q_Adrs]='" + lQA.Text.Replace("'","''")  + "', " +
							" [P_Adrs]='" + lPA.Text.Replace("'","''")  + "', " +
							" [S_Adrs]='" + lSA.Text.Replace("'","''")  + "', " +
							" [I_Adrs]='" + lIA.Text.Replace("'","''")  + "', " +
							" [Tel2]='" + tTel2.Text  + "', " +
							" [CustomerType]=" + lcustmTp.Text   + ", " +
							" [TermID]=" + lTermsId.Text   + ", " +
							" [CreditLim]='" + tCreditLim.Text.Replace("'","''")   + "', " +
							" [Currency]='" + cbCurr.Text.Replace("'","''")   + "', " +
							" [ShipVia_ID]=" + lViaId.Text   + ", " +
							" [IncoTerm_ID]=" + lInTermId.Text  + ", " +
							" [City]='" + ""  + "', " +
							" [Province_State]='" + "" + "', " +
							" [Country_Name]='" + ""  + "', " +
							" [actvId]=" + lActId.Text + " " +
							" WHERE [Cpny_ID]=" + tCompanyID.Text ;
						MainMDI.ExecSql(stSql);
						btnOK.Text ="&Save"; 
					}
					catch (OleDbException Oexp) 
					{
						MessageBox.Show("Updating Option Error...= " + Oexp.Message );
					}
						
				}
			}
			else MessageBox.Show ("You missed some data....."); 
		}



		private void btnComnt_Click(object sender, System.EventArgs e)
		{
			
		}

		private void cbMainCmpny_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lMainCpnyID.Text="0";
			if (cbMainCmpny.Text !="")
			{
				lMainCpnyID.Text = MainMDI.Find_One_Field("select Cpny_ID from PSM_COMPANY where Cpny_Name1='" + cbMainCmpny.Text + "'");  
				if (lMainCpnyID.Text   == MainMDI.VIDE ) lMainCpnyID.Text  = "0" ; 
			}
		
		}

		private void btnAQ_Click(object sender, System.EventArgs e)
		{
			QuoteXAdrs('Q',lQA.Text );
		}
		private void QuoteXAdrs(char c_adrs, string adrs)
		{
			dlgAdrs dAdrs = new dlgAdrs(adrs );
			//	dAdrs.chkSave.Visible=true;   
			dAdrs.ShowDialog(); 
			if (dAdrs.tStreet.Text   != ""  ) 
			{
				switch (c_adrs)
				{
					case 'Q':
						lQA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text  + "," + dAdrs.tZip.Text  + "," + dAdrs.cbCountry .Text     ;
						break;
					case 'S':
						lSA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text  + "," + dAdrs.tZip.Text  + "," + dAdrs.cbCountry .Text     ;
						break;
					case 'I':
						lIA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text  + "," + dAdrs.tZip.Text  + "," + dAdrs.cbCountry .Text     ;
						break;
					case 'P':
						lPA.Text = dAdrs.tStreet.Text + "," + dAdrs.cbCity.Text + "," + dAdrs.cbSP.Text  + "," + dAdrs.tZip.Text  + "," + dAdrs.cbCountry .Text     ;
						break;
				}
			}
			

		}






		private void init_scr()
		{
			tFax.Clear();
			tFname.Clear();
			tLname.Clear();
			tcpny.Clear();
			tdepart.Clear();
			tEmail.Clear();
			tCell.Clear ();
			tCatalog.Clear ();
			tpager.Clear (); 
		}
		private void fill_cbCompany()
		{
			string stSql = "select Cpny_Name1 FROM PSM_Company order by Cpny_Name1";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ()) cbMainCmpny.Items.Add( Oreadr["Cpny_Name1"].ToString()  ); 
	
			OConn.Close(); 
				 
		}
		private void fill_cbPrefx()
		{
			string stSql = "select [Prefix] FROM PSM_Prefix ";
			SqlConnection OConn  = new SqlConnection(MainMDI.M_stCon  );
			OConn.Open ();
			SqlCommand Ocmd = OConn.CreateCommand();
			Ocmd.CommandText = stSql ;
			SqlDataReader Oreadr = Ocmd.ExecuteReader();
			while (Oreadr.Read ()) cbPrefx.Items.Add( Oreadr["Prefix"].ToString()  ); 
	
			OConn.Close(); 
				 
		}

		private void cbMainCmpny_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			lcomp.Text =cbMainCmpny.Text ;
			string st=MainMDI.Find_One_Field("SELECT [Cpny_ID] FROM PSM_Company where  Cpny_Name1='" + cbMainCmpny.Text   +"'") ;
			lcpnyIDD.Text = (st==MainMDI.VIDE) ? "0" : st;
		}

		private void cbPrefx_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			string st=MainMDI.Find_One_Field("SELECT [Prefix ID] FROM PSM_Prefix where  Prefix='" + cbPrefx.Text   +"'") ;
			lprefID.Text = (st==MainMDI.VIDE) ? "0" : st;
		}

	

		private void Contacts_Load(object sender, System.EventArgs e)
		{
		
		}

		private void groupBox3_Enter(object sender, System.EventArgs e)
		{
		
		}

		private void pictureBox1_Click(object sender, System.EventArgs e)
		{
			if (tFname.Text !="" && tLname.Text !="" && cbMainCmpny.Text!="" && cbPrefx.Text!="")
			{
				lsave.Text = "Y";
				this.Hide();
			}
			else MessageBox.Show("First/Last Name or Company  are empty...."); 
		}

	*/	
	
	

		



	
	}
}
