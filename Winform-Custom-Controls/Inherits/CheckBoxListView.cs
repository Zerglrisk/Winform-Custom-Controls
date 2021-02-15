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
        private CustomListViewColumnSorter lvwColumnSorter;
        public CheckBoxListView()
        {
            this.CheckBoxes = true;
            this.OwnerDraw = true;
            this.FullRowSelect = true;
            this.GridLines = true;
            this.HideSelection = false;
            this.MultiSelect = false;
            this.View = View.Details;

            //Init Custom Properties
            this.EnableColumnSort = true;

            // Set the ListViewItemSorter property to a new ListViewItemComparer 
            // object. 
            lvwColumnSorter = new CustomListViewColumnSorter();
            this.ListViewItemSorter = lvwColumnSorter;
        }

        [Category("Behavior")]
        [DefaultValue(true)]
        public bool EnableColumnSort { get; set; }
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
                //https://docs.microsoft.com/ko-kr/troubleshoot/dotnet/csharp/sort-listview-by-column
                if (EnableColumnSort)
                {
                    var beforeSortColumn = lvwColumnSorter.SortColumn;
                    //Sorting
                    if (e.Column == lvwColumnSorter.SortColumn)
                    {
                        var title = this.Columns[lvwColumnSorter.SortColumn].Text.Replace(" ▲", "").Replace(" ▼", "");

                        // Reverse the current sort direction for this column.
                        if (lvwColumnSorter.Order == SortOrder.Ascending)
                        {
                            lvwColumnSorter.Order = SortOrder.Descending;
                            this.Columns[lvwColumnSorter.SortColumn].Text = title + " ▼";
                        }
                        else
                        {
                            lvwColumnSorter.Order = SortOrder.Ascending;
                            this.Columns[lvwColumnSorter.SortColumn].Text = title + " ▲";
                        }
                    }
                    else
                    {
                        // Set the column number that is to be sorted; default to ascending.
                        lvwColumnSorter.SortColumn = e.Column;
                        lvwColumnSorter.Order = SortOrder.Ascending;

                        var title = this.Columns[lvwColumnSorter.SortColumn].Text.Replace(" ▲", "").Replace(" ▼", "");
                        this.Columns[lvwColumnSorter.SortColumn].Text = title + " ▲";

                        //remove other's sort
                        if (beforeSortColumn > -1 && beforeSortColumn < this.Columns.Count)
                        {
                            this.Columns[beforeSortColumn].Text = this.Columns[beforeSortColumn].Text.Replace(" ▲", "").Replace(" ▼", "");
                        }
                    }
                    // Call the sort method to manually sort. 
                    this.Sort();
                }
            }
        }

    }
}
