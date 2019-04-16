using System;
using System.Drawing;
using System.Windows.Forms;

namespace Winform_Custom_Controls.Inherits
{
    public class FlatButton : Button
    {
        private bool isMouseHover;
        private bool parentShowFocusCues;
        public FlatButton()
        {
            BackColor = Color.DodgerBlue;
            ForeColor = Color.White;
            CurrentBackColor = BackColor;

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

        private Color CurrentBackColor;

        public override Color BackColor { get { return base.BackColor; }
            set { base.BackColor = value;
                CurrentBackColor = base.BackColor;
            }
        }

        private Color onHoverBackColor = Color.DarkOrchid;
        public Color OnHoverBackColor
        {
            get { return onHoverBackColor; }
            set { onHoverBackColor = value; Invalidate(); }
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            CurrentBackColor = onHoverBackColor;
            isMouseHover = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            CurrentBackColor = BackColor;
            isMouseHover = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            CurrentBackColor = Color.RoyalBlue;

            Invalidate();
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            CurrentBackColor = BackColor;
            Invalidate();
        }
        
        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);
            pevent.Graphics.FillRectangle(new SolidBrush(CurrentBackColor), 0, 0, Width, Height);
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
