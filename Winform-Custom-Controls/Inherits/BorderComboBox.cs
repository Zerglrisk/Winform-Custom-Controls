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
    /// <summary>
    /// If you Apply Background Color, Must Set FlatStyle Standard to PopUp.
    /// </summary>
    public class BorderComboBox : ComboBox
    {
        private Color _drawBorder;
        private Color _borderColor;

        private const int WM_PAINT = 0xF;
        private int buttonWidth = SystemInformation.HorizontalScrollBarArrowWidth; // SystemInformation.VerticalScrollBarWidth; //Also Can This
        [Category("Appearance"), Browsable(true), Description("Border Color."), DefaultValue(typeof(Color), "DimGray")]
        public Color BorderColor
        {
            get { return this._borderColor; }
            set { _drawBorder = this._borderColor = value; }
        }
        [Category("Appearance"), Description("When Mouse Over Chnage Border Color. It doesn't work the controls is disabled.")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderHoverColor { get; set; }
        [Category("Appearance"), Browsable(true), Description("Border Style."), DefaultValue(typeof(ButtonBorderStyle), "Solid")]
        public ButtonBorderStyle BorderStyle { get; set; }

        [Category("Appearance"), Browsable(true), Description("Background Color For Disabled Color. it means enabled is false."), DefaultValue(typeof(Color), "Control")]
        public Color BackDisabledColor { get; set; }

        private Color _backDefaultColor;
        [Category("Appearance"), Browsable(true), Description("Background Color For Default Color. it means enabled is false."), DefaultValue(typeof(Color), "Window")]
        public Color BackDefaultColor
        {
            get { return this._backDefaultColor; }
            set { this.BackColor = this._backDefaultColor = value; }
        }

        [Browsable(false)]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        //[Browsable(true)]
        //public override bool AutoSize {
        //    get { return base.AutoSize; }
        //    set { base.AutoSize = value; } }

        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            try
            {
                if (m.Msg == WM_PAINT)
                {
                    using (var g = Graphics.FromHwnd(Handle))
                    {
                        using (var p = new Pen(this._drawBorder))
                        {
                            //g.DrawRectangle(p, 0, 0, Width - 1, Height - 1);
                            ControlPaint.DrawBorder(g, this.DisplayRectangle, this._drawBorder, BorderStyle);
                            if (this.FlatStyle == FlatStyle.Standard)
                            {
                                g.DrawLine(p, this.Width - buttonWidth, 0, this.Width - buttonWidth, this.Height);
                            }
                            else
                            {
                                g.DrawLine(p, this.Width - buttonWidth - 1, 0, this.Width - buttonWidth - 1, this.Height);
                            }

                            //if (!this.Enabled)
                            //{
                            //    using (var b = new SolidBrush(this.BackDisabledColor))
                            //    {
                            //        g.FillRectangle(b, this.DisplayRectangle.X + 1, this.DisplayRectangle.Y + 1,
                            //            this.Width - buttonWidth - 1, this.DisplayRectangle.Height - 2);
                            //    }
                            //}
                        }
                    }
                }
            }
            catch (Exception)
            {

            }
        }


        public BorderComboBox()
        {
            this.SetStyle(
                ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer,
                true);
            this.DoubleBuffered = true;
            _drawBorder = BorderColor = Color.DimGray;
            BorderHoverColor = Color.Black;
            BorderStyle = ButtonBorderStyle.Solid;
            BackDisabledColor = SystemColors.Control;
            this.BackColor = BackDefaultColor = SystemColors.Window;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            this.BackColor = this.Enabled ? BackDefaultColor : BackDisabledColor;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            //base.OnMouseEnter(e);
            _drawBorder = BorderHoverColor;
        }
        protected override void OnMouseLeave(EventArgs e)
        {
            //base.OnMouseLeave(e);
            _drawBorder = BorderColor;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            Invalidate();
        }
    }
}
