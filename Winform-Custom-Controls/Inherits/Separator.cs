using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Winform_Custom_Controls.Inherits
{
    public class Separator : Panel
    {
        [Category("Appearance"), DefaultValue(typeof(Padding), "0,0,0,0")]
        public Padding SeparatorPadding { get; set; }
        [Category("Appearance"), DefaultValue(typeof(Color), "Black")]
        public Color SeparatorColor { get; set; }

        public Separator()
        {
            SeparatorColor = Color.Black;
            SeparatorPadding = new Padding(0);
            DoubleBuffered = true;
            //this.BackColor = Color.Transparent;
        }
        protected override void WndProc(ref Message m)
        {
            base.WndProc(ref m);
            if (m.Msg == 0xF) //WM_PAINT
            {
                using (var g = Graphics.FromHwnd(this.Handle))
                {
                    using (var b = new SolidBrush(SeparatorColor))
                    {
                        //Draw Separator
                        g.FillRectangle(b,
                            new Rectangle(SeparatorPadding.Left, SeparatorPadding.Top,
                                this.Width - SeparatorPadding.Right - SeparatorPadding.Left,
                                this.Height - SeparatorPadding.Bottom - SeparatorPadding.Top));
                    }
                    
                }
            }

            else if (m.Msg == 0x14) //WM_ERASEBKGND
            {
                using (var g = Graphics.FromHwnd(this.Handle))
                {
                    if (SeparatorPadding.All != 0)
                    {
                        //Draw Border
                        g.FillRectangle(Brushes.Transparent, new Rectangle(0, 0, this.Width, this.Height));
                    }
                }
            }
        }
        [Browsable(false)]
        public override Color BackColor { get; set; }
        [Browsable(false)]
        public override Image BackgroundImage { get; set; }
        [Browsable(false)]
        public override ImageLayout BackgroundImageLayout { get; set; }

        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    using (var g = e.Graphics)
        //    {
        //        using (var b = new SolidBrush(this.SeparatorColor))
        //        {
        //            if (SeparatorPadding.All != 0)
        //            {
        //                ////Top Draw
        //                //g.DrawRectangle(Pens.Transparent, new Rectangle(0, 0, this.Width, SeparatorPadding.Top));
        //                ////Left Draw
        //                //g.DrawRectangle(Pens.Transparent, new Rectangle(0, 0, SeparatorPadding.Left, this.Height));
        //                ////Down Draw
        //                //g.DrawRectangle(Pens.Transparent, new Rectangle(0, this.Height - SeparatorPadding.Bottom, this.Width, SeparatorPadding.Bottom));
        //                ////Right Draw
        //                //g.DrawRectangle(Pens.Transparent, new Rectangle(this.Width - SeparatorPadding.Right, 0, SeparatorPadding.Right, this.Height));

        //                //Draw Border
        //                //g.FillRectangle(Brushes.Transparent, new Rectangle(0, 0, this.Width, this.Height));
        //                //Draw Separator
        //                g.FillRectangle(b,
        //                    new Rectangle(SeparatorPadding.Left, SeparatorPadding.Top,
        //                        this.Width - SeparatorPadding.Right - SeparatorPadding.Left,
        //                        this.Height - SeparatorPadding.Bottom - SeparatorPadding.Top));


        //            }
        //        }
        //    }

        //    // this assumes we're in a workspace, on MainForm (the whole Parent.Parent thing)
        //    //IBackgroundPaintProvider bgPaintProvider = Parent.Parent as IBackgroundPaintProvider;
        //    //if (bgPaintProvider != null)
        //    //{
        //    //    Rectangle rcPaint = e.ClipRectangle;
        //    //    // use the parent, since it's the workspace position in the Form we want, 
        //    //    // not our position in the workspace
        //    //    rcPaint.Offset(Parent.Left, Parent.Top);
        //    //    bgPaintProvider.PaintBackground(e.Graphics, e.ClipRectangle, rcPaint);
        //    //}

        //    base.OnPaint(e);
        //}

        protected override void OnPaintBackground(PaintEventArgs e)
        {
            //WndProc 이후 BackColor 색으로 리드로우 방지
            base.OnPaintBackground(e);
        }

    }

    //interface IBackgroundPaintProvider
    //{
    //    void PaintBackground(Graphics g, Rectangle targetRect, Rectangle sourceRect);
    //    Image BackgroundImage { get; set; }
    //}
}
