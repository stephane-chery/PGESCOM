using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb ;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class frmCMPNY : System.Windows.Forms.Form
	{
		private System.Windows.Forms.LinkLabel linkLabel1;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.Button button1;
		private System.ComponentModel.IContainer components;

		public frmCMPNY()
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
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmCMPNY));
			System.Windows.Forms.ListViewItem listViewItem1 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "aaaaaaaaaaaaaaaaaa", System.Drawing.Color.Crimson, System.Drawing.SystemColors.HighlightText, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)), true)),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "AAAAAAAAAAAA"),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "AAAAAAAAAAAA"),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "AAAAAAAAAAA")}, -1);
			System.Windows.Forms.ListViewItem listViewItem2 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "bbbbbbbbbbbbbbbb", System.Drawing.Color.Crimson, System.Drawing.SystemColors.HighlightText, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)))),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "tttttttttttt", System.Drawing.Color.FromArgb(((System.Byte)(255)), ((System.Byte)(128)), ((System.Byte)(0))), System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)))),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "tttttttttttttttt", System.Drawing.Color.Black, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)))),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "uuuuuuuuuuuuuu")}, -1);
			System.Windows.Forms.ListViewItem listViewItem3 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "ccccccccccccc", System.Drawing.Color.Crimson, System.Drawing.SystemColors.HighlightText, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)))),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "hhhhh", System.Drawing.Color.LightCoral, System.Drawing.SystemColors.Window, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)))),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "hhhh"),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "hhh")}, -1);
			System.Windows.Forms.ListViewItem listViewItem4 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "ddddddddddddd", System.Drawing.Color.Crimson, System.Drawing.SystemColors.HighlightText, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)))),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "hhhh"),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "hhh"),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "")}, -1);
			System.Windows.Forms.ListViewItem listViewItem5 = new System.Windows.Forms.ListViewItem(new System.Windows.Forms.ListViewItem.ListViewSubItem[] {
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "zzzzzzzzzzzzzzzzz", System.Drawing.Color.Crimson, System.Drawing.SystemColors.HighlightText, new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)))),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, ""),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, ""),
																																								new System.Windows.Forms.ListViewItem.ListViewSubItem(null, "")}, -1);
			this.linkLabel1 = new System.Windows.Forms.LinkLabel();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.button1 = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// linkLabel1
			// 
			this.linkLabel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.linkLabel1.Location = new System.Drawing.Point(8, 0);
			this.linkLabel1.Name = "linkLabel1";
			this.linkLabel1.Size = new System.Drawing.Size(128, 16);
			this.linkLabel1.TabIndex = 0;
			this.linkLabel1.TabStop = true;
			this.linkLabel1.Text = "info@primax-e.com";
			this.linkLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
			this.linkLabel1.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.linkLabel1_LinkClicked);
			// 
			// imageList1
			// 
			this.imageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// listView1
			// 
			this.listView1.Alignment = System.Windows.Forms.ListViewAlignment.Default;
			this.listView1.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.listView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader4});
			this.listView1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.listView1.ForeColor = System.Drawing.SystemColors.Highlight;
			this.listView1.FullRowSelect = true;
			this.listView1.Items.AddRange(new System.Windows.Forms.ListViewItem[] {
																					  listViewItem1,
																					  listViewItem2,
																					  listViewItem3,
																					  listViewItem4,
																					  listViewItem5});
			this.listView1.LabelWrap = false;
			this.listView1.Location = new System.Drawing.Point(8, 32);
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(496, 368);
			this.listView1.SmallImageList = this.imageList1;
			this.listView1.Sorting = System.Windows.Forms.SortOrder.Ascending;
			this.listView1.TabIndex = 10;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "name";
			this.columnHeader1.Width = 120;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "code";
			this.columnHeader2.Width = 120;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "phone#";
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "e-mail";
			// 
			// button1
			// 
			this.button1.BackColor = System.Drawing.SystemColors.Control;
			this.button1.FlatStyle = System.Windows.Forms.FlatStyle.System;
			this.button1.Location = new System.Drawing.Point(408, 8);
			this.button1.Name = "button1";
			this.button1.TabIndex = 11;
			this.button1.Text = "Company";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// frmCMPNY
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.BackColor = System.Drawing.Color.LightSteelBlue;
			this.ClientSize = new System.Drawing.Size(512, 414);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.button1,
																		  this.listView1,
																		  this.linkLabel1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Name = "frmCMPNY";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Form1";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void linkLabel1_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("mailto:info@primax-e.com");
		}

		private void btnDel_Click(object sender, System.EventArgs e)
		{
			MessageBox.Show("HiiiiiiiiiiiiiiiiiiiXP...");
		}

		private void Form1_Load1111(object sender, System.EventArgs e)
		{

				// Create a new ListView control.
				ListView listView1 = new ListView();
				listView1.Bounds = new Rectangle(new Point(10,10), new Size(300,200));

				// Set the view to show details.
				listView1.View = View.Details;
				// Allow the user to edit item text.
				listView1.LabelEdit = true;
				// Allow the user to rearrange columns.
				listView1.AllowColumnReorder = true;
				// Display check boxes.
				listView1.CheckBoxes = true;
				// Select the item and subitems when selection is made.
				listView1.FullRowSelect = true;
				// Display grid lines.
				listView1.GridLines = true;
				// Sort the items in the list in ascending order.
				listView1.Sorting = SortOrder.Ascending;
                     
				// Create three items and three sets of subitems for each item.
				ListViewItem item1 = new ListViewItem("item1",0);
				// Place a check mark next to the item.
				item1.Checked = true;
				item1.SubItems.Add("1");
				item1.SubItems.Add("2");
				item1.SubItems.Add("3");
				ListViewItem item2 = new ListViewItem("item2",1);
				item2.SubItems.Add("4");
				item2.SubItems.Add("5");
				item2.SubItems.Add("6");
				ListViewItem item3 = new ListViewItem("item3",0);
				// Place a check mark next to the item.
				item3.Checked = true;
				item3.SubItems.Add("7");
				item3.SubItems.Add("8");
				item3.SubItems.Add("9");

				// Create columns for the items and subitems.
				listView1.Columns.Add("Item Column", -2, HorizontalAlignment.Left);
				listView1.Columns.Add("Column 2", -2, HorizontalAlignment.Left);
				listView1.Columns.Add("Column 3", -2, HorizontalAlignment.Left);
				listView1.Columns.Add("Column 4", -2, HorizontalAlignment.Center);

				//Add the items to the ListView.
				listView1.Items.AddRange(new ListViewItem[]{item1,item2,item3});

				// Create two ImageList objects.
				ImageList imageListSmall = new ImageList();
				ImageList imageListLarge = new ImageList();

				// Initialize the ImageList objects with bitmaps.
				//imageListSmall.Images.Add(Bitmap.FromFile("C:\\MySmallImage1.bmp"));
				//imageListSmall.Images.Add(Bitmap.FromFile("C:\\MySmallImage2.bmp"));
				//imageListLarge.Images.Add(Bitmap.FromFile("C:\\MyLargeImage1.bmp"));
				//imageListLarge.Images.Add(Bitmap.FromFile("C:\\MyLargeImage2.bmp"));

				//Assign the ImageList objects to the ListView.
				listView1.LargeImageList = imageListLarge;
				listView1.SmallImageList = imageListSmall;

				// Add the ListView to the control collection.
				this.Controls.Add(listView1);
			}

		private void Form1_Load(object sender, System.EventArgs e)
		{
		
		}

		private void listView1_DoubleClick(object sender, System.EventArgs e)
		{
			MessageBox.Show(listView1.SelectedItems[0].Text.ToString ()+ "   sub= " + listView1.SelectedItems[0].SubItems[0].Text    ) ;  
			listView1.Columns[1].Text ="COMPANY NAME";  
		}

		private void button1_Click(object sender, System.EventArgs e)
		{


			Company frmCMP = new Company();
			frmCMP.ShowDialog(this); // form Modal

            
			
		}

	

	
		

		}

}
