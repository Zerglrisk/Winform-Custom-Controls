using System;
using System.Collections;
using System.Windows.Forms;

namespace Winform_Custom_Controls.Core.Models
{
    public class CustomListViewComparer : IComparer
    {
        private int col;
        private SortOrder order;
        public CustomListViewComparer()
        {
            this.col = 0;
            this.order = SortOrder.Ascending;
        }
        public CustomListViewComparer(int column, SortOrder order)
        {
            this.col = column;
            this.order = order;
        }
        public int Compare(object x, object y)
        {
            int returnVal = -1;
            returnVal = String.Compare(((ListViewItem)x).SubItems[this.col].Text, ((ListViewItem)y).SubItems[this.col].Text);
            // Determine whether the sort order is descending.
            if (this.order == SortOrder.Descending)
                // Invert the value returned by String.Compare. 
                returnVal *= -1;
            return returnVal;
        }
    }
}
