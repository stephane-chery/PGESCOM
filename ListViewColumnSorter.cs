using System;
using System.Collections;
using System.Text.RegularExpressions;	
using System.Windows.Forms;

namespace PGESCOM
{
	/// <summary>
	/// This class is an implementation of the 'IComparer' interface.
	/// </summary>
	public class ListViewColumnSorter : IComparer
	{
		/// <summary>
		/// Specifies the column to be sorted
		/// </summary>
		private int ColumnToSort;
		/// <summary>
		/// Specifies the order in which to sort (i.e. 'Ascending').
		/// </summary>
		private SortOrder OrderOfSort;
		/// <summary>
		/// Case insensitive comparer object
		/// </summary>
		//private CaseInsensitiveComparer ObjectCompare;
		private NumberCaseInsensitiveComparer ObjectCompare;
		private ImageTextComparer FirstObjectCompare;

		/// <summary>
		/// Class constructor. Initializes various elements
		/// </summary>
		public ListViewColumnSorter()
		{
			//Initialize the column to '0'
			ColumnToSort = 0;

			//Initialize the sort order to 'none'
			//OrderOfSort = SortOrder.None;
			OrderOfSort = System.Windows.Forms.SortOrder.Ascending;

			//Initialize the CaseInsensitiveComparer object
			ObjectCompare = new NumberCaseInsensitiveComparer(); //CaseInsensitiveComparer();
			FirstObjectCompare = new ImageTextComparer();
		}

		/// <summary>
		/// This method is inherited from the IComparer interface. It compares the two objects passed using a case insensitive comparison.
		/// </summary>
		/// <param name="x">First object to be compared</param>
		/// <param name="y">Second object to be compared</param>
		/// <returns>The result of the comparison. "0" if equal, negative if 'x' is less than 'y' and positive if 'x' is greater than 'y'</returns>
		public int Compare(object x, object y)
		{
			int compareResult;
			ListViewItem listviewX, listviewY;

			//Cast the objects to be compared to ListViewItem objects
			listviewX = (ListViewItem) x;
			listviewY = (ListViewItem) y;
			//hakim added on 180707
			if (ColumnToSort == -1) return 0;
			//hakim
			if (ColumnToSort == 0) compareResult = FirstObjectCompare.Compare(x, y);
			else
			{
				//Compare the two items
			
				compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
			}
			//hakim removed on 180707
			//if (ColumnToSort == -1) OrderOfSort = SortOrder.None;
			//hakim

			//Calculate correct return value based on object comparison
			if (OrderOfSort == System.Windows.Forms.SortOrder.Ascending)
			{
				//Ascending sort is selected, return normal result of compare operation
				return compareResult;
			}
			else if (OrderOfSort == System.Windows.Forms.SortOrder.Descending)
			{
				//Descending sort is selected, return negative result of compare operation
				return (-compareResult);
			}
			else
			{
				//Return '0' to indicate they are equal
				return 0;
			}
		}

		/// <summary>
		/// Gets or sets the number of the column to which to apply the sorting operation (Defaults to '0').
		/// </summary>
		public int SortColumn
		{
			set
			{
				ColumnToSort = value;
			}
			get
			{
				return ColumnToSort;
			}
		}

		/// <summary>
		/// Gets or sets the order of sorting to apply (for example, 'Ascending' or 'Descending').
		/// </summary>
		public SortOrder Order
		{
			set
			{
				OrderOfSort = value;
			}
			get
			{
				return OrderOfSort;
			}
		}
	}

	public class ImageTextComparer : IComparer
	{
		//private CaseInsensitiveComparer ObjectCompare;
		private NumberCaseInsensitiveComparer ObjectCompare;

		public ImageTextComparer()
		{
			//Initialize the CaseInsensitiveComparer object
			ObjectCompare = new NumberCaseInsensitiveComparer(); //CaseInsensitiveComparer();
		}

		public int Compare(object x, object y)
		{
			//int compareResult;
			int image1, image2;
			ListViewItem listviewX, listviewY;

			//Cast the objects to be compared to ListViewItem objects
			listviewX = (ListViewItem) x;
			image1 = listviewX.ImageIndex;
			listviewY = (ListViewItem) y;
			image2 = listviewY.ImageIndex;

			if (image1 < image2) return -1;
			else if (image1 == image2) return ObjectCompare.Compare(listviewX.Text, listviewY.Text);
			else return 1;
		}
	}

	public class NumberCaseInsensitiveComparer : CaseInsensitiveComparer
	{
		public NumberCaseInsensitiveComparer()
		{
			
		}

		//public new int Compare(object x, object y)
		//{
			//if ((x is System.String) && IsWholeNumber((string) x) && (y is System.String) && IsWholeNumber((string) y))
			//{
				////return base.Compare(System.Convert.ToInt32(x), System.Convert.ToInt32(y));
				//return base.Compare(System.Convert.ToInt64(x), System.Convert.ToInt64(y));
			//}
			//else
			//{ //if (IsDoubleNumber(string))
				//return base.Compare(x, y);
			//}
		//}

		public new int Compare(object x, object y)
		{
			if ((x is System.String) && (y is System.String))
			{
				if (IsWholeNumber((string) x) && IsWholeNumber((string) y)) 
					return base.Compare(System.Convert.ToInt64(x), System.Convert.ToInt64(y));
				else
				{
					if (IsDoubleNumber((string) x) && IsDoubleNumber((string) y)) 
						return base.Compare(System.Convert.ToDouble(x), System.Convert.ToDouble(y));
					else return base.Compare(x, y);
				}
			}
			else return base.Compare(x, y);
		}

		private bool IsWholeNumber(string strNumber)
		{
			Regex objNotWholePattern = new Regex("[^0-9]");
			return !objNotWholePattern.IsMatch(strNumber);
		}

		private bool IsDoubleNumber(string strNumber)
		{
			Regex objNotNumberPattern = new Regex("[^0-9.-]");
			Regex objTwoDotPattern = new Regex("[0-9]*[.][0-9]*[.][0-9]*");
			Regex objTwoMinusPattern = new Regex("[0-9]*[-][0-9]*[-][0-9]*");
			String strValidRealPattern = "^([-]|[.]|[-.]|[0-9])[0-9]*[.]*[0-9]+$";
			String strValidIntegerPattern = "^([-]|[0-9])[0-9]*$";
			Regex objNumberPattern = new Regex("(" + strValidRealPattern + ")|(" + strValidIntegerPattern + ")");

			return !objNotNumberPattern.IsMatch(strNumber) && !objTwoDotPattern.IsMatch(strNumber) && !objTwoMinusPattern.IsMatch(strNumber) && 
				objNumberPattern.IsMatch(strNumber);
		}

		/*
		*
		* 
		public int Compare(object x, object y)
		{
			int compareResult;
			ListViewItem listviewX, listviewY;

			//Cast the objects to be compared to ListViewItem objects
			listviewX = (ListViewItem) x;
			listviewY = (ListViewItem) y;

			if (ColumnToSort == 0)
			{
				compareResult = FirstObjectCompare.Compare(x, y);
			}
			else
			{
				//Compare the two items
			
				compareResult = ObjectCompare.Compare(listviewX.SubItems[ColumnToSort].Text, listviewY.SubItems[ColumnToSort].Text);
			}
			//hakim
			if (ColumnToSort == -1) OrderOfSort = SortOrder.None;
			//hakim

			//Calculate correct return value based on object comparison
			if (OrderOfSort == SortOrder.Ascending)
			{
				//Ascending sort is selected, return normal result of compare operation
				return compareResult;
			}
			else if (OrderOfSort == SortOrder.Descending)
			{
				//Descending sort is selected, return negative result of compare operation
				return (-compareResult);
			}
			else
			{
				//Return '0' to indicate they are equal
				return 0;
			}
		}
		*/
	}
}