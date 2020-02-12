using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform_Custom_Controls.Model
{
    public class ComboBoxItems
    {
        public List<ComboBoxItem> Item { get; set; }
        public object DefaultValue { get; set; }

        public ComboBoxItems(List<ComboBoxItem> item, object defaultValue)
        {
            Item = item;
            this.DefaultValue = defaultValue;
        }

        public ComboBoxItems()
        {
            Item = new List<ComboBoxItem>();
            DefaultValue = null;
        }


        /// <summary>
        /// DataTable To ComboBoxItems. DataTable Must Have 'Text' And 'Value' Column.
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="defaultValue"></param>
        /// <returns></returns>
        public static ComboBoxItems DataTableToComboBoxItems(DataTable dataTable, object defaultValue = null)
        {
            if (dataTable == null)
            {
                throw new Exception("Data is Empty.");
            }
            if (!dataTable.Columns.Contains("Text") || !dataTable.Columns.Contains("Value"))
            {
                throw new Exception("Text or Value Columns is not exists.");
            }

            var items = new ComboBoxItems();

            foreach (DataRow row in dataTable.Rows)
            {
                items.Item.Add(new ComboBoxItem(row["Text"].ToString(),row["Value"]));
            }

            items.DefaultValue = defaultValue;

            return items;
        }

        public static ComboBoxItems Clone(ComboBoxItems comboBoxItems)
        {
            var cloneComboBoxItems = new ComboBoxItems();
            //comboBoxItems.Item.ForEach(item => { cloneComboBoxItems.Item.Add(new ComboBoxItem(item.Text,item.Value));});
            cloneComboBoxItems.Item.AddRange(comboBoxItems.Item);
            cloneComboBoxItems.DefaultValue = comboBoxItems.DefaultValue;

            return cloneComboBoxItems;
        }
    }
}
