using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_Custom_Controls.Inherits
{
    public class HeaderLabel : System.Windows.Forms.Label
    {
        public HeaderLabel()
        {

            IsRequire = false;
            RequireColor = Color.Red;
            RequireChar = '*';
        }

        #region Fields

        [Category("Appearance")]
        [DefaultValue(false)]
        public bool IsRequire { get; set; }
        [DefaultValue(typeof(Color), "Red")]
        [Category("Appearance")]
        public Color RequireColor { get; set; }
        [Category("Appearance")]
        [DefaultValue('*')]
        public char RequireChar { get; set; }

        #endregion

        #region Functions

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }

        #endregion
    }
}