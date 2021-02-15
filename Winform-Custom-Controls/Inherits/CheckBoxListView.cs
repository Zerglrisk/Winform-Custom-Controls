using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform_Custom_Controls.Core.Models;

namespace Winform_Custom_Controls.Inherits
{
    /// <summary>
    /// You Must Create First Column that width is 25 and text is empty.
    /// </summary>
    /// <see cref="https://crazylobelia.tistory.com/29"/>
    public class CheckBoxListView : ListView
    {
        private int sortColumn = -1;
        public CheckBoxListView()
        {
            this.CheckBoxes = true;
            this.OwnerDraw = true;
            this.View = View.Details;
        }
        
        //if use this Row Check Box not draw
        //[DefaultValue(true)]
        //public new bool CheckBoxes { get; private set; }

        //If use this Column Check Box not draw
        //[DefaultValue(true)]
        //public  bool OwnerDraw { get; private set; }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

        }

        protected override void OnDrawColumnHeader(DrawListViewColumnHeaderEventArgs e)
        {
            base.OnDrawColumnHeader(e);

            if (e.ColumnIndex == 0)
            {
                e.DrawBackground();
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(e.Header.Tag);
                }
                catch (Exception)
                {

                }
                CheckBoxRenderer.DrawCheckBox(e.Graphics,
                    new Point(e.Bounds.Left + 4, e.Bounds.Top + 4),
                    value ? System.Windows.Forms.VisualStyles.CheckBoxState.CheckedNormal : System.Windows.Forms.VisualStyles.CheckBoxState.UncheckedNormal);
            }
            else
            {
                e.DrawDefault = true;
            }
        }

        protected override void OnDrawItem(DrawListViewItemEventArgs e)
        {
            base.OnDrawItem(e);

            e.DrawDefault = true;
        }

        protected override void OnDrawSubItem(DrawListViewSubItemEventArgs e)
        {
            base.OnDrawSubItem(e);

            e.DrawDefault = true;
        }

        protected override void OnColumnClick(ColumnClickEventArgs e)
        {
            base.OnColumnClick(e);

            //If Click Header Checkbox
            if (e.Column == 0)
            {
                bool value = false;
                try
                {
                    value = Convert.ToBoolean(this.Columns[e.Column].Tag);
                }
                catch (Exception)
                {

                }

                this.Columns[e.Column].Tag = !value;
                foreach (ListViewItem item in this.Items)
                {
                    item.Checked = !value;
                }
                this.Invalidate();
            }
            else
            {
                //Sorting
                if (e.Column != sortColumn)
                {
                    // Set the sort column to the new column.
                    this.sortColumn = e.Column;
                    // Set the sort order to ascending by default.
                    this.Sorting = SortOrder.Ascending;

                    var title = this.Columns[sortColumn].Text.Replace(" ▲", "").Replace(" ▼", "");
                    this.Columns[sortColumn].Text = title + " ▲";
                }
                else
                {
                   var title = this.Columns[sortColumn].Text.Replace(" ▲", "").Replace(" ▼", "");

                    // Determine what the last sort order was and change it. 
                    if (this.Sorting == SortOrder.Ascending)
                    {
                        this.Sorting = SortOrder.Descending;
                        this.Columns[sortColumn].Text = title + " ▼";
                    }
                    else
                    {
                        this.Sorting = SortOrder.Ascending;
                        this.Columns[sortColumn].Text = title + " ▲"; 
                    }
                }

                //remove other's sort
                for(var i = 0; i < this.Columns.Count; ++i)
                {
                    if(i != sortColumn)
                    {
                        this.Columns[i].Text = this.Columns[i].Text.Replace(" ▲", "").Replace(" ▼", "");
                    }
                }
            }

            // Call the sort method to manually sort. 
            this.Sort();
            // Set the ListViewItemSorter property to a new ListViewItemComparer 
            // object. 
            this.ListViewItemSorter = new CustomListViewComparer(e.Column, this.Sorting);
        }
    }
}
