using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Winform_Custom_Controls.Model
{
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }

        public ComboBoxItem(string text, object value)
        {
            this.Text = text;
            this.Value = value;
        }

        public ComboBoxItem()
        {
        }

        public override bool Equals(object obj)
        {
            if (!(obj is ComboBoxItem other)) return false;
            return this.Text == other.Text && Equals(this.Value, other.Value);
        }
        public override int GetHashCode()
        {
            unchecked
            {
                return ((this.Text != null ? this.Text.GetHashCode() : 0) * 397) ^ (this.Value != null ? this.Value.GetHashCode() : 0);
            }
        }
    }
}
