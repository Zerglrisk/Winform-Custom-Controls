using System;
using System.Drawing;
using System.Windows.Forms;

namespace Winform_Custom_Controls.Inherits
{
    public sealed class FlatButton : Button
    {
        private bool isMouseHover;
        private bool parentShowFocusCues;
        public FlatButton()
        {
            BackColor = Color.DodgerBlue;
            ForeColor = Color.White;
            _currentBackColor = BackColor;

            isMouseHover = false;
            parentShowFocusCues = false;
          
            
        }
        
        protected override void OnParentChanged(EventArgs e)
        {
            base.OnParentChanged(e);
            if (Parent != null)
            {
                base.Parent.ChangeUICues += ParentOnChangeUiCues;
            }
        }


        private void ParentOnChangeUiCues(object sender, UICuesEventArgs e)
        {
            parentShowFocusCues = e.ChangeFocus;
        }

        private Color _currentBackColor;

        public override Color BackColor { get { return base.BackColor; }
            set { base.BackColor = value;
                _currentBackColor = base.BackColor;
            }
        }

        private Color _onHoverBackColor = Color.DarkOrchid;
        public Color OnHoverBackColor
        {
            get => _onHoverBackColor;
            set { _onHoverBackColor = value; Invalidate(); }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            _currentBackColor = _onHoverBackColor;
            isMouseHover = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            _currentBackColor = BackColor;
            isMouseHover = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            _currentBackColor = Color.RoyalBlue;

            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            _currentBackColor = BackColor;
            Invalidate();
        }
        
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.FillRectangle(new SolidBrush(_currentBackColor), 0, 0, Width, Height);
            TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;

            TextRenderer.DrawText(pevent.Graphics, Text, Font, new Point(Width + 3, (TextRenderer.MeasureText(this.Text, this.Font).Height)), ForeColor, flags);
            ControlPaint.DrawBorder(pevent.Graphics, DisplayRectangle, Color.Red, ButtonBorderStyle.Solid);
            if (Focused)
            {
                if (!isMouseHover)
                {
                    ControlPaint.DrawBorder(pevent.Graphics, new Rectangle(1, 1, Width - 2, Height - 2), Color.Red, ButtonBorderStyle.Solid);
                }

                if (IsDefault && Focused && parentShowFocusCues)
                {

                    ControlPaint.DrawBorder(pevent.Graphics, new Rectangle(2, 2, Width - 4, Height - 4), Color.Black, ButtonBorderStyle.Dotted);
                }
            }
            
        }

        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(value);
            //Focus 미사용
            //base.NotifyDefault(false); 
        }
    }
}
