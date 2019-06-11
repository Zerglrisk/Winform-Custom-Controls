﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform_Custom_Controls.enums;

namespace Winform_Custom_Controls.Inherits
{
 public   class TextBox : System.Windows.Forms.TextBox
    {
        private Color _drawColor;
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        public TextBox()
        {
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer,
                true);
            SetStyle(ControlStyles.ContainerControl, false);
            SetStyle(ControlStyles.Opaque, true);
            this.UpdateStyles();
            BackReadOnlyColor = SystemColors.Control;
            BackDisabledColor = SystemColors.Control;
            BackDefaultColor = SystemColors.Window;
            BorderColor = ColorTranslator.FromHtml("#7A7A7A");
            BorderFocusColor = SystemColors.Highlight;
            _drawColor = BackColor = BackDefaultColor;
            EnableBorderFocusColor = true;
            AutoSize = false;
            TextMode = TextMode.Text;
            //this.BorderStyle = BorderStyle.FixedSingle;
        }
        //[Category("Appearance"),
        // Description("편집 컨트롤에 테두리를 표시할지 여부를 나타냅니다.")]
        //[Browsable(true)]
        //[DefaultValue(typeof(BorderStyle), "FixedSingle")]
        //public new BorderStyle BorderStyle
        //{
        //    get
        //    { return base.BorderStyle; }
        //    set { base.BorderStyle = value; }
        //}
        [DefaultValue(false)]
        [Browsable(true)]
        public override bool AutoSize
        {
            get
            {
                return base.AutoSize;
            }
            set
            {
                base.AutoSize = value;
            }
        }

        [Category("Appearance"),
         Description("현재 미구현")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Control")]
        public Color BackDisabledColor { get; set; }
        [Category("Appearance"),
         Description("현재 미구현")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Control")]
        public Color BackReadOnlyColor { get; set; }

        private Color _backDefaultColor;
        [Category("Appearance"),
         Description("The background color of the component when disabled")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Window")]
        public Color BackDefaultColor
        {
            get { return _backDefaultColor; }
            set { this.BackColor = _backDefaultColor = value; }
        }

        [Category("Appearance"),
         Description("The background color of the component when disabled")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "122,122,122")]
        public Color BorderColor { get; set; }

        [Category("Appearance"),
         Description("The background color of the component when disabled")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "MenuHighlight")]
        public Color BorderFocusColor { get; set; }

        [Browsable(false)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        [Category("Behavior"), Description("Usable BorderFocusColor"), DefaultValue(true), Browsable(true)]
        public bool EnableBorderFocusColor { get; set; }
        [Category("Behavior"),Description("Text Mode"),DefaultValue(typeof(TextMode),"Text"),Browsable(true)]
        public TextMode TextMode { get; set; }

        protected override void WndProc(ref Message m)
        {
            //if (m.Msg == 791) return;
            //base.WndProc(ref m);

            //if (m.Msg == WM_NCPAINT && BorderColor != Color.Transparent &&
            //    BorderStyle == System.Windows.Forms.BorderStyle.Fixed3D)
            //{
            //    var hdc = GetWindowDC(this.Handle);
            //    using (var g = Graphics.FromHdcInternal(hdc))
            //    using (var p = new Pen(BorderColor))
            //        g.DrawRectangle(p, new Rectangle(0, 0, Width - 1, Height - 1));
            //    ReleaseDC(this.Handle, hdc);
            //    return;
            //}
            //base.WndProc(ref m);

            base.WndProc(ref m);

            if (m.Msg == 133)
            {
                var dc = GetWindowDC(Handle);
                using (Graphics g = Graphics.FromHdc(dc))
                {
                    using (var p = new Pen(this.Focused && EnableBorderFocusColor ? BorderFocusColor : BorderColor))
                    {
                        g.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
                    }

                }
                ReleaseDC(this.Handle, dc);
            }
        }

        //protected override void OnPaintBackground(PaintEventArgs e)
        //{
        //    base.OnPaintBackground(e);

        //    _drawColor = this.Enabled ? this.ReadOnly ? BackReadOnlyColor : BackDefaultColor : this.BackDisabledColor;

        //    using (var b = new SolidBrush(_drawColor))
        //    {
        //        e.Graphics.FillRectangle(b, 1, 1, Width - 2, Height - 2);
        //    }
        //}

        protected override void OnReadOnlyChanged(EventArgs e)
        {
            base.OnReadOnlyChanged(e);
            BackColor = this.Enabled ? this.ReadOnly ? BackReadOnlyColor : BackDefaultColor : this.BackDisabledColor;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            BackColor = this.Enabled ? this.ReadOnly ? BackReadOnlyColor : BackDefaultColor : this.BackDisabledColor;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }

        protected override void OnKeyPress(KeyPressEventArgs e)
        {
            base.OnKeyPress(e);
            if (TextMode == TextMode.Number)
            {
                // Reference : https://stackoverflow.com/questions/463299/how-do-i-make-a-textbox-that-only-accepts-numbers
                // Reference : https://ourcodeworld.com/articles/read/507/how-to-allow-only-numbers-inside-a-textbox-in-winforms-c-sharp
                // Verify that the pressed key isn't CTRL or any non-numeric digit
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // If you want, you can allow decimal (float) numbers
                if ((e.KeyChar == '.') && ((this).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
            }else if (TextMode == TextMode.Currency)
            {
                // Verify that the pressed key isn't CTRL or any non-numeric digit
                if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
                {
                    e.Handled = true;
                }

                // If you want, you can allow decimal (float) numbers
                if ((e.KeyChar == '.') && ((this).Text.IndexOf('.') > -1))
                {
                    e.Handled = true;
                }
                //소수점 안적히는 오류 수정하기
                this.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:#,##.##}", double.Parse(Regex.Replace(!string.IsNullOrEmpty(this.Text) ? this.Text : "0", @"[^\d]", string.Empty)));
            }
        }
    }
}
