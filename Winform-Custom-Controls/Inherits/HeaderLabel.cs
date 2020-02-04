using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Winform_Custom_Controls.Inherits
{
    //https://stackoverflow.com/questions/9692524/override-label-onpaint
    public class HeaderLabel : System.Windows.Forms.Label
    {

        private Color CurrentBackColor;
        private Color _backDisabledColor;
        private bool _isRequire;

        public HeaderLabel()
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
            //if (IsRequire)
            //{
            //    pevent.Graphics.DrawString(this.RequireChar.ToString(), this.Font, new SolidBrush(this.RequireColor), size.Width-(this.AutoSize ? 5 : 0), 0);
            //}
            var rectangle = DeflateRect(this.ClientRectangle, this.Padding);
            IntPtr hdc = pevent.Graphics.GetHdc();
            Color nearestColor;
            try
            {
                nearestColor = GetNearestColors(this.Enabled ? this.ForeColor : this.ForeColor,hdc); //this.DisabledColor);
            }
            finally
            {
                pevent.Graphics.ReleaseHdc();
            }

            TextFormatFlags textFormatFlags = this.CreateTextFormatFlags();
            if (IsRequire)
            {
                TextRenderer.DrawText((IDeviceContext)pevent.Graphics, this.Text.Trim()+this.RequireChar.ToString(), this.Font, rectangle, this.RequireColor, textFormatFlags);
            }
            TextRenderer.DrawText((IDeviceContext)pevent.Graphics, this.Text, this.Font, rectangle, nearestColor,textFormatFlags);
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

        public static Rectangle DeflateRect(Rectangle rect, Padding padding)
        {
            rect.X += padding.Left;
            rect.Y += padding.Top;
            rect.Width -= padding.Horizontal;
            rect.Height -= padding.Vertical;
            return rect;
        }
        [DllImport("gdi32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        public static extern int GetNearestColor(HandleRef hDC, int color);
        public Color GetNearestColors(Color color, IntPtr hdc)
        {
            return ColorTranslator.FromWin32(GetNearestColor(new HandleRef((object)null, hdc ), ColorTranslator.ToWin32(color)));
        }


        private TextFormatFlags CreateTextFormatFlags()
        {
            return this.CreateTextFormatFlags(this.Size - this.GetBordersAndPadding());
        }

        internal virtual TextFormatFlags CreateTextFormatFlags(Size constrainingSize)
        {
            TextFormatFlags textFormatFlags = CreateTextFormatFlags( this.TextAlign, this.AutoEllipsis, this.UseMnemonic);
            if (!this.TextRequiresWordBreak(this.Text, this.Font, constrainingSize, textFormatFlags))
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
        public static readonly ContentAlignment AnyTopAlign = ContentAlignment.TopLeft | ContentAlignment.TopCenter | ContentAlignment.TopRight;
        public static readonly ContentAlignment AnyBottomAlign = ContentAlignment.BottomLeft | ContentAlignment.BottomCenter | ContentAlignment.BottomRight;
        public static readonly ContentAlignment AnyMiddleAlign = ContentAlignment.MiddleLeft | ContentAlignment.MiddleCenter | ContentAlignment.MiddleRight;
        protected internal ContentAlignment RtlTranslateContents(ContentAlignment align)
        {
            if (RightToLeft.Yes == this.RightToLeft)
            {
                if ((align & AnyTopAlign) != (ContentAlignment)0)
                {
                    if (align == ContentAlignment.TopLeft)
                        return ContentAlignment.TopRight;
                    if (align == ContentAlignment.TopRight)
                        return ContentAlignment.TopLeft;
                }
                if ((align & AnyMiddleAlign) != (ContentAlignment)0)
                {
                    if (align == ContentAlignment.MiddleLeft)
                        return ContentAlignment.MiddleRight;
                    if (align == ContentAlignment.MiddleRight)
                        return ContentAlignment.MiddleLeft;
                }
                if ((align & AnyBottomAlign) != (ContentAlignment)0)
                {
                    if (align == ContentAlignment.BottomLeft)
                        return ContentAlignment.BottomRight;
                    if (align == ContentAlignment.BottomRight)
                        return ContentAlignment.BottomLeft;
                }
            }
            return align;
        }
        internal TextFormatFlags CreateTextFormatFlags(
            System.Drawing.ContentAlignment textAlign,
            bool showEllipsis,
            bool useMnemonic)
        {
            textAlign = RtlTranslateContents(textAlign);
            TextFormatFlags textFormatFlags = TextFormatFlagsForAlignmentGDI(textAlign) | TextFormatFlags.TextBoxControl | TextFormatFlags.WordBreak;
            if (showEllipsis)
                textFormatFlags |= TextFormatFlags.EndEllipsis;
            if (this.RightToLeft == RightToLeft.Yes)
                textFormatFlags |= TextFormatFlags.RightToLeft;
            if (!useMnemonic)
                textFormatFlags |= TextFormatFlags.NoPrefix;
            else if (!this.ShowKeyboardCues)
                textFormatFlags |= TextFormatFlags.HidePrefix;
            return textFormatFlags;
        }


        
        public static readonly Size InvalidSize = new Size(int.MinValue, int.MinValue);
        public static readonly Size MaxSize = new Size(int.MaxValue, int.MaxValue);
        private static Size unconstrainedPreferredSize = InvalidSize;
        private Size GetUnconstrainedSize(string text, Font font, TextFormatFlags flags)
        {
            if (unconstrainedPreferredSize == InvalidSize)
            {
                flags &= ~TextFormatFlags.WordBreak;
                unconstrainedPreferredSize = TextRenderer.MeasureText(text, font, MaxSize, flags);
            }
            return unconstrainedPreferredSize;
        }

        public bool TextRequiresWordBreak(string text, Font font, Size size, TextFormatFlags flags)
        {
            return this.GetUnconstrainedSize(text, font, flags).Width > size.Width;
        }

        private static readonly System.Drawing.ContentAlignment anyRight = System.Drawing.ContentAlignment.TopRight | System.Drawing.ContentAlignment.MiddleRight | System.Drawing.ContentAlignment.BottomRight;
        private static readonly System.Drawing.ContentAlignment anyBottom = System.Drawing.ContentAlignment.BottomLeft | System.Drawing.ContentAlignment.BottomCenter | System.Drawing.ContentAlignment.BottomRight;
        private static readonly System.Drawing.ContentAlignment anyCenter = System.Drawing.ContentAlignment.TopCenter | System.Drawing.ContentAlignment.MiddleCenter | System.Drawing.ContentAlignment.BottomCenter;
        private static readonly System.Drawing.ContentAlignment anyMiddle = System.Drawing.ContentAlignment.MiddleLeft | System.Drawing.ContentAlignment.MiddleCenter | System.Drawing.ContentAlignment.MiddleRight;


        internal static TextFormatFlags TextFormatFlagsForAlignmentGDI(
            System.Drawing.ContentAlignment align)
        {
            return TextFormatFlags.Default | TranslateAlignmentForGDI(align) | TranslateLineAlignmentForGDI(align);
        }

        internal static TextFormatFlags TranslateAlignmentForGDI(System.Drawing.ContentAlignment align)
        {
            return (align & anyBottom) == (System.Drawing.ContentAlignment)0 ? ((align & anyMiddle) == (System.Drawing.ContentAlignment)0 ? TextFormatFlags.Default : TextFormatFlags.VerticalCenter) : TextFormatFlags.Bottom;
        }

        internal static TextFormatFlags TranslateLineAlignmentForGDI(
            System.Drawing.ContentAlignment align)
        {
            return (align & anyRight) == (System.Drawing.ContentAlignment)0 ? ((align & anyCenter) == (System.Drawing.ContentAlignment)0 ? TextFormatFlags.Default : TextFormatFlags.HorizontalCenter) : TextFormatFlags.Right;
        }

        #endregion
    }
}