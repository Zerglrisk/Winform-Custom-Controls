using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Winform_Custom_Controls.Inherits
{
    public class DateTimePicker : System.Windows.Forms.DateTimePicker
    {
        private Color _drawBorder;
        private Color _borderColor;

        public DateTimePicker() : base()
        {
            this.SetStyle(
                ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer,
                true);
            BackDisabledColor = Color.FromKnownColor(KnownColor.Control);
            BorderStyle = ButtonBorderStyle.Solid;
            BorderColor = Color.Gray;
            BorderHoverColor = Color.Black;
            BackDisabledColor = SystemColors.Control;
            BackColor = SystemColors.Window;
        }

        /// <summary>
        ///     Gets or sets the background color of the control
        /// </summary>
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Window")]
        public override Color BackColor
        {
            get { return base.BackColor; }
            set { base.BackColor = value; }
        }

        /// <summary>
        ///     Gets or sets the background color of the control when disabled
        /// </summary>
        [Category("Appearance"),
         Description("The background color of the component when disabled")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Control")]
        public Color BackDisabledColor
        {
           get;set;
        }

        [Category("Appearance")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Gray")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set { _drawBorder = _borderColor = value; }
        }
        [Category("Appearance"),Description("When Mouse Over Chnage Border Color. It doesn't work the controls is disabled.")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderHoverColor { get; set; }

        [Category("Appearance")]
        [Browsable(true)]
        [DefaultValue(typeof(ButtonBorderStyle), "Solid")]
        public ButtonBorderStyle BorderStyle { get; set; }

        ///// <summary>
        ///// For 2008
        ///// </summary>
        ///// <param name="e"></param>
        protected override void OnPaint(System.Windows.Forms.PaintEventArgs e)
        {
            //g.Dispose();
            base.OnPaint(e);

            //This CreateGraphics function doesn't work if use doublebuffer.
            //Graphics g = this.CreateGraphics();

            //The dropDownRectangle defines position and size of dropdownbutton block, 
            //the width is fixed to 17 and height to 16. 
            //The dropdownbutton is aligned to right
            Rectangle dropDownRectangle =
                new Rectangle(ClientRectangle.Width - this.Height + 2, 2, this.Height - 4, this.Height - 4);
            Brush bkgBrush;
            ComboBoxState visualState;
            ButtonState visualState2;

            //When the control is enabled the brush is set to Backcolor, 
            //otherwise to color stored in BackDisabledColor
            if (this.Enabled)
            {
                bkgBrush = new SolidBrush(this.BackColor);
                visualState = ComboBoxState.Normal;
                visualState2 = ButtonState.Flat;
            }
            else
            {
                bkgBrush = new SolidBrush(this.BackDisabledColor);
                visualState = ComboBoxState.Disabled;
                visualState2 = ButtonState.Inactive;
            }

            // Painting...in action

            //Filling the background
            e.Graphics.FillRectangle(bkgBrush, 0, 0, ClientRectangle.Width, ClientRectangle.Height );

            float height = 2;
            //Set text algin middle
            if (TextRenderer.MeasureText(this.Text, this.Font).Height <= this.Height)
            {
                height = ((this.Height - TextRenderer.MeasureText(this.Text, this.Font).Height) / 2);
            }

            if (this.Focused)
            {
                e.Graphics.FillRectangle(SystemBrushes.Highlight,
                    new Rectangle(4, 4, this.ClientSize.Width - SystemInformation.VerticalScrollBarWidth - 8,
                        this.ClientSize.Height - 8));
                using (var b = new SolidBrush(SystemColors.HighlightText))
                {
                    e.Graphics.DrawString(this.Text, this.Font, b, 0, height);
                }
            }
            else
            {
                using (var b = new SolidBrush(ForeColor))
                {
                    //Drawing the datetime text
                    e.Graphics.DrawString(this.Text, this.Font, b, 0, height);
                }
            }

            //Drawing the dropdownbutton using ComboBoxRenderer
            //ComboBoxRenderer.DrawDropDownButton(g, dropDownRectangle, visualState);
            ControlPaint.DrawComboButton(e.Graphics,
                new Rectangle(this.ClientRectangle.Left + this.ClientRectangle.Width - 20, this.ClientRectangle.Top, 20,
                    this.ClientRectangle.Height), visualState2);

            //Drawing Border
            ControlPaint.DrawBorder(e.Graphics, this.DisplayRectangle, _drawBorder, BorderStyle);
            using (var p = new Pen(this._drawBorder))
            {
                e.Graphics.DrawLine(p, Width - 20, 0, Width - 20, Height);
            }

            bkgBrush.Dispose();

            base.OnPaint(e);
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _drawBorder = BorderHoverColor;
            this.Invalidate();
        }
        protected override void OnMouseLeave(EventArgs e)

        {

            base.OnMouseLeave(e);
            _drawBorder = BorderColor;
            this.Invalidate();

        }
    }
}
   
    