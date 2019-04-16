using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Winform_Custom_Controls.Inherits
{
    public class usrButtonTest : Button
    {
        private Color _drawColor;
        [DllImport("user32.dll")]
        static extern IntPtr GetWindowDC(IntPtr hWnd);
        [DllImport("user32.dll")]
        static extern int ReleaseDC(IntPtr hWnd, IntPtr hDC);
        
        public usrButtonTest()
        {
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer,
                true);
            this.UpdateStyles();
            BackDisabledColor = SystemColors.Control;
            BackDefaultColor = SystemColors.Window;
            BorderColor = ColorTranslator.FromHtml("#7A7A7A");
            BorderHoverColor = SystemColors.MenuHighlight;
            _drawColor = BackColor = BackDefaultColor;
            

            this.FlatStyle = FlatStyle.Flat;
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
        [Category("Appearance"),Browsable(true),DefaultValue(typeof(FlatStyle), "Flat")]
        public new FlatStyle FlatStyle
        {
            get { return base.FlatStyle; }
             set { base.FlatStyle = value; }
        }
        [Category("Appearance"),
         Description("현재 미구현")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Control")]
        public Color BackDisabledColor { get; set; }

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

        private Color _borderColor;
        [Category("Appearance"),
         Description("The background color of the component when disabled")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "122,122,122")]
        public Color BorderColor { get { return  _borderColor; }
            set
            {
                _borderColor = value;
                if (FlatStyle == FlatStyle.Flat)
                {
                    this.FlatAppearance.BorderColor = _borderColor;
                }
            }
        }

        [Category("Appearance"),
         Description("The background color of the component when disabled")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "MenuHighlight")]
        public Color BorderHoverColor { get; set; }

        [Browsable(false)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (FlatStyle == FlatStyle.Flat && this.Enabled)
            {
                this.FlatAppearance.BorderColor = BorderHoverColor;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (FlatStyle == FlatStyle.Flat && this.Enabled)
            {
                this.FlatAppearance.BorderColor = BorderColor;
            }
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            ControlPaint.DrawBorder(pevent.Graphics, this.ClientRectangle,
                Color.LightGreen, 1, ButtonBorderStyle.Solid,
                Color.LightGreen, 1, ButtonBorderStyle.Solid,
                Color.LightGreen, 1, ButtonBorderStyle.Solid,
                Color.LightGreen, 1, ButtonBorderStyle.Solid
            );
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
        
        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);

            BackColor = this.Enabled ? BackDefaultColor : this.BackDisabledColor;
        }
        
    }
}
