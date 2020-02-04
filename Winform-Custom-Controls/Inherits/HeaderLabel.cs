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
    public class ContentLabel : System.Windows.Forms.Label
    {

        private Color CurrentBackColor;
        private Color _backDisabledColor;
        private bool _isRequire;

        public ContentLabel()
        {


            IsRequire = false;
            RequireColor = Color.Red;
            RequireChar = '*';

            CurrentBackColor = BackColor = SystemColors.Control;
            ForeDisabledColor = SystemColors.ButtonShadow;
            BackDisabledColor = ColorTranslator.FromHtml("#CCCCCC");
        }

        #region Fields

        [Category("Appearance")]
        [DefaultValue(false)]
        public bool IsRequire
        {
            get { return _isRequire;}
            set
            {
                _isRequire = value;
                if (value)
                {
                    this.Text += $@" ";
                }
                else
                {
                    this.Text = this.Text.TrimEnd();
                }
            }
        }
        [DefaultValue(typeof(Color), "Red")]
        [Category("Appearance")]
        public Color RequireColor { get; set; }
        [Category("Appearance")]
        [DefaultValue('*')]
        public char RequireChar { get; set; }

        [Category("Appearance")]
        [DefaultValue(typeof(Color), "Control")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set
            {
                if (value == Color.Empty)
                {
                    CurrentBackColor = base.BackColor = SystemColors.ControlLight;
                }
                else
                {
                    CurrentBackColor = base.BackColor = value;
                }
            }
        }

        [Category("Appearance"), Description("The background color of the component when disabled")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "204, 204, 204")]
        public Color BackDisabledColor
        {
            get { return _backDisabledColor; }
            set
            {
                _backDisabledColor = value;

                CurrentBackColor = this.Enabled ? BackColor : value.IsEmpty ? BackColor : BackDisabledColor;
                Invalidate();
            }
        }

        [Category("Appearance"),
         Description("When Disabled Button, Apply This Color.")]
        [DefaultValue(typeof(Color), "ButtonShadow")]
        public Color ForeDisabledColor { get; set; }

        #endregion

        #region Functions

        protected override void OnTextChanged(EventArgs e)
        {
            if (IsRequire && this.Text.Length > 0 && this.Text.Substring(this.Text.Length-1, 1) != " ")
            {
                this.Text += $@" ";

            }
            base.OnTextChanged(e);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
           
            base.OnPaint(pevent);
            var size = TextRenderer.MeasureText(this.Text.Trim(), this.Font);
            //Draw BackColor
            pevent.Graphics.FillRectangle(new SolidBrush(this.Enabled ? CurrentBackColor : BackDisabledColor), 0, 0, Width, Height);
            //TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;qx  
            //TextRenderer.DrawText(pevent.Graphics, Text, Font, new Point(Width + 3, (TextRenderer.MeasureText(this.Text, this.Font).Height)), this.Enabled ? ForeColor : ForeDisabledColor, flags);
            //Draw Text
            if (IsRequire)
            {
                pevent.Graphics.DrawString(this.RequireChar.ToString(), this.Font, new SolidBrush(this.RequireColor), size.Width-5, 0);
            }
            pevent.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.Enabled ? ForeColor : ForeDisabledColor), 0,0);
        }


        #endregion
    }
}