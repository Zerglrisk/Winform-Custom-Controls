using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform_Custom_Controls.Model;

namespace Winform_Custom_Controls
{
    public static class ComboBoxBinder
    {
        public static void BindComboBoxItems(this ComboBox box, ComboBoxItems items)
        {
            if (items == null || items.Item.Count == 0)
            {
                return;
            }

            box.DataSource = items.Item;
            box.DisplayMember = "Text";
            box.ValueMember = "Value";
            if (box.BindingContext == null)
            {
                box.BindingContext = new BindingContext();
            }

            if (items.DefaultValue != null)
            {
                foreach (ComboBoxItem boxItem in box.Items)
                {
                    if (boxItem.Value != items.DefaultValue) continue;
                    box.SelectedItem = boxItem;
                    break;
                }
            }
        }

        /// <summary>
        /// Need Test
        /// </summary>
        /// <param name="box"></param>
        /// <param name="item"></param>
        public static void AddComboBoxItem(this ComboBox box, ComboBoxItem item)
        {
            if (item == null) return;
            if (box.DataSource != null)
            {
                var items = (List<ComboBoxItem>) box.DataSource;
                items.Add(item);
            }
        }
    }
}
