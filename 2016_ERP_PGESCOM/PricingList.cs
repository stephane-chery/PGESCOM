using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace PGESCOM
{
	/// <summary>
	/// Summary description for PricingList.
	/// </summary>
	public class PricingList : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public PricingList()
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
			// 
			// PricingList
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(616, 273);
			this.Name = "PricingList";
			this.Text = "PricingList";
			this.Load += new System.EventHandler(this.PricingList_Load);

		}
		#endregion

		private void PricingList_Load(object sender, System.EventArgs e)
		{
		
		}
		private void PRICE_ALL_CHARGERS()
	
		/*{
Dim i As Long, Imax As Long, PL As Long
Dim NBCh As Long, pbadd As Long
Dim t1
Dim debutTrouve As Boolean */


 rmADO_Table ("CHARGERS_COST0" & p)
 PL = 1
 adoChargers_Cost.RecordSource = " select * from CHARGERS_COST0" & p
 CR_TBL6  'Create TBL6
 NBCh = 0
  adoCHRG_REF.Recordset.MoveFirst
 While Not adoCHRG_REF.Recordset.EOF
    NBCh = NBCh + 1
   adoCHRG_REF.Recordset.MoveNext
 Wend
 pbadd = Int((1000 / NBCh))
 framePB.Visible = True
 framePB.Refresh
 pbchargers.Value = 0
 debutTrouve = False
 adoCHRG_REF.Recordset.MoveFirst
 While Not adoCHRG_REF.Recordset.EOF
   Call Price_ALL_CPT_1CHRG(cmdphs.Caption, adoCHRG_REF.Recordset(1), PL)
   c.Caption = adoCHRG_REF.Recordset(0)
  If 1000 - pbchargers.Value > pbadd Then
       pbchargers.Value = pbchargers.Value + pbadd
  Else: pbchargers.Value = pbchargers.Value + (1000 - pbchargers.Value)
  End If
  lblNBC.Caption = lblNBC.Caption - 1
  pbchargers.Refresh
  DoEvents
  'Me.Refresh
  adoCHRG_REF.Recordset.MoveNext
 Wend
 AllVCS.Text = "Price_ALL_CPT_1CHRG: ....Time=" & Timer - t1
 Me.Refresh
 DoEvents
 TOTBLXL (p)
 Me.MousePointer = 0
 framePB.Visible = False
 
		}
	}
}
