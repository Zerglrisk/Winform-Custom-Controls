using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform_Custom_Controls.Core.Data;

namespace Winform_Custom_Controls.Inherits
{
    //https://stackoverflow.com/questions/9692524/override-label-onpaint
    public class ContentLabel : System.Windows.Forms.Label
    {

        private Color CurrentBackColor;
        private Color _backDisabledColor;
        private bool _isRequire;
        private LayoutUtils.MeasureTextCache textMeasurementCache;

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
            get { return _isRequire; }
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

        #region internal Fields

        internal LayoutUtils.MeasureTextCache MeasureTextCache
        {
            get
            {
                if (this.textMeasurementCache == null)
                    this.textMeasurementCache = new LayoutUtils.MeasureTextCache();
                return this.textMeasurementCache;
            }
        }

        #endregion
        #region Functions

        protected override void OnTextChanged(EventArgs e)
        {
            if (IsRequire && this.Text.Length > 0 && this.Text.Substring(this.Text.Length - 1, 1) != " ")
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
            //if (IsRequire)
            //{
            //    pevent.Graphics.DrawString(this.RequireChar.ToString(), this.Font, new SolidBrush(this.RequireColor), size.Width-(this.AutoSize ? 5 : 0), 0);
            //}
            var rectangle = LayoutUtils.DeflateRect(this.ClientRectangle, this.Padding);
            IntPtr hdc = pevent.Graphics.GetHdc();
            Color nearestColor;
            try
            {
                nearestColor = WindowGraphics.GetNearestColor(this.Enabled ? this.ForeColor : this.ForeColor, hdc); //this.DisabledColor);
            }
            finally
            {
                pevent.Graphics.ReleaseHdc();
            }

            TextFormatFlags textFormatFlags = this.CreateTextFormatFlags();
            if (IsRequire)
            {
                TextRenderer.DrawText((IDeviceContext)pevent.Graphics, this.Text.Trim() + this.RequireChar.ToString(), this.Font, rectangle, this.RequireColor, textFormatFlags);
            }
            TextRenderer.DrawText((IDeviceContext)pevent.Graphics, this.Text, this.Font, rectangle, nearestColor, textFormatFlags);
            //if (IsRequire)
            //{
            //    var x = 0;
            //    var y = 0;
            //    if (AutoSize)
            //    {
            //        x = size.Width - (int)(this.Font.Size /2);
            //    }
            //    else
            //    {
            //        x = (size.Width % rectangle.Width);
            //        y = size.Height * (size.Width / rectangle.Width);
            //    }
            //    TextRenderer.DrawText((IDeviceContext)pevent.Graphics,this.RequireChar.ToString(),this.Font, new Point(x,y),this.RequireColor);
            //}
            //pevent.Graphics.DrawString(this.Text, this.Font, new SolidBrush(this.Enabled ? ForeColor : ForeDisabledColor), 0,0);


        }

        private TextFormatFlags CreateTextFormatFlags()
        {
            return this.CreateTextFormatFlags(this.Size - this.GetBordersAndPadding());
        }

        internal virtual TextFormatFlags CreateTextFormatFlags(Size constrainingSize)
        {
            TextFormatFlags textFormatFlags = WindowFormsUtils.CreateTextFormatFlags((Control)this, this.TextAlign, this.AutoEllipsis, this.UseMnemonic,this.ShowKeyboardCues);
            if (!this.MeasureTextCache.TextRequiresWordBreak(this.Text, this.Font, constrainingSize, textFormatFlags))
                textFormatFlags &= ~(TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak);
            return textFormatFlags;
        }

        private Size GetBordersAndPadding()
        {
            Size size = this.Padding.Size;
            if (this.UseCompatibleTextRendering)
            {
                if (this.BorderStyle != BorderStyle.None)
                {
                    size.Height += 6;
                    size.Width += 2;
                }
                else
                    size.Height += 3;
            }
            else
            {
                size += this.SizeFromClientSize(Size.Empty);
                if (this.BorderStyle == BorderStyle.Fixed3D)
                    size += new Size(2, 2);
            }
            return size;
        }


        

       

        #endregion
    }
}