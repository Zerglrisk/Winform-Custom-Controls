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
 public class TextBox : System.Windows.Forms.TextBox
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
            BorderFocusColor = SystemColors.MenuHighlight;
            _drawColor = BackColor = BackDefaultColor;
            EnableBorderFocusColor = true;
            AutoSize = false;
            TextMode = TextMode.Text;
            //this.BorderStyle = BorderStyle.FixedSingle;

            _cursorPosition = 0;
        }

        private int _cursorPosition;
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
            get => base.AutoSize;
            set => base.AutoSize = value;
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
            get => _backDefaultColor;
            set => this.BackColor = _backDefaultColor = value;
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
            get => base.BackColor;
            set => base.BackColor = value;
        }

        [Category("Behavior"), Description("Usable BorderFocusColor"), DefaultValue(true), Browsable(true)]
        public bool EnableBorderFocusColor { get; set; }
        [Category("Behavior"),Description("Text Mode"),DefaultValue(typeof(TextMode),"Text"),Browsable(true)]
        public TextMode TextMode { get; set; }

        protected override void WndProc(ref Message m)
        {
            //WM_PRINT
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

            //WM_NCPAINT
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
            //WM_PASTE
            if (m.Msg == 770)
            {
                //block the Paste
                var digitStr = "";
                if (!string.IsNullOrWhiteSpace(this.Text))
                {
                    var regex = new Regex(@"[^\d]");
                    digitStr = regex.Replace(this.Text, "");
                }
                if (this.TextMode == TextMode.Number )
                {
                    this.Text = digitStr;
                }
                else if (this.TextMode == TextMode.Currency)
                {
                    this.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:#,##.##}", double.Parse(Regex.Replace(!string.IsNullOrEmpty(digitStr) ? digitStr : "0", @"[^\d]", string.Empty)));
                }
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
                // If double value over handled

                var lengh = this.Text.Length;
                _cursorPosition = this.SelectionLength;// this.Text.Length; 
                var curLengh = this.SelectionStart;
                //[Need Fix] 소수점 안적히는 오류 수정하기
                this.Text = string.Format(System.Globalization.CultureInfo.CurrentCulture, "{0:#,##.##}", double.Parse(Regex.Replace(!string.IsNullOrEmpty(this.Text) ? this.Text : "0", @"[^\d]", string.Empty)));
                //수정본
                //var digitText = Regex.Replace(!string.IsNullOrEmpty(this.Text) ? this.Text : "", @"[^\d]", string.Empty);
                //var resultText = string.Empty;
                //for (var i = 0; i < digitText.Length; ++i)
                //{
                //    resultText += digitText[i];

                //    if (i != 0 && (i+1) % 3 == 0)
                //    {
                //        resultText += ",";
                //    }
                //}
                //this.Text = resultText;

                var subtract = this.Text.Length - lengh;

                this.SelectionLength = _cursorPosition + subtract;
                this.SelectionStart = curLengh + subtract;

            }
        }
    }
}
