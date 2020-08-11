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
    public class ColorizeButton : Button
    {
        private bool isMouseEnter;
        private Color CurrentBackColor;
        private Color CurrentBorderColor;
        private Color _backDisabledColor;
        private Color _borderColor;
        private Color _borderDisabledColor;
        private bool mouseleavedactivatetrigger;

        public ColorizeButton()
        {
            BorderSize = new Padding(1);
            CurrentBackColor = BackColor = SystemColors.ControlLight;
            BackHoverColor = ColorTranslator.FromHtml("#E5F1FB");
            BackMouseDownColor = ColorTranslator.FromHtml("#CCE4F7");
            BackDisabledColor = ColorTranslator.FromHtml("#CCCCCC");

            CurrentBorderColor = BorderColor = SystemColors.ButtonShadow;
            BorderHoverColor = SystemColors.Highlight;
            BorderMouseDownColor = ColorTranslator.FromHtml("#005499");
            BorderDisabledColor = ColorTranslator.FromHtml("#BFBFBF");
            BorderFocusCuesColor = Color.Black;
            BorderHoverSize = new Padding(2);

            ForeDisabledColor = SystemColors.ButtonShadow;

            isMouseEnter = false;
            this.UseVisualStyleBackColor = true;

            mouseleavedactivatetrigger = false;

        }

        #region Back Colors Properties

        [Category("Back Colors")]
        [DefaultValue(typeof(Color), "204, 228, 247")]
        public Color BackMouseDownColor { get; set; }

        [Category("Back Colors")]
        [DefaultValue(typeof(Color), "229, 241, 251")]
        public Color BackHoverColor { get; set; }

        [Category("Back Colors")]
        [DefaultValue(typeof(Color), "ControlLight")]
        public override Color BackColor
        {
            get => base.BackColor;
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

        [Category("Back Colors"), Description("The background color of the component when disabled")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "204, 204, 204")]
        public Color BackDisabledColor
        {
            get => _backDisabledColor;
            set
            {
                _backDisabledColor = value;

                CurrentBackColor = this.Enabled ? BackColor : value.IsEmpty ? BackColor : BackDisabledColor;
                Invalidate();
            }
        }

        #endregion
        #region Border Colors Properties

        [Category("Border Color")]
        [DefaultValue(typeof(Color), "ButtonShadow")]
        public Color BorderColor
        {
            get => _borderColor;
            set
            {
                if (value == Color.Empty)
                {
                    CurrentBorderColor = _borderColor = SystemColors.ButtonShadow;
                }
                else
                {
                    CurrentBorderColor = _borderColor = value;
                }
            }
        }
        [Category("Border Color"),
         Description("This Variable is support.(don't create yet)"),
         Browsable(false)]
        [DefaultValue(typeof(Padding), "1,1,1,1")]
        public Padding BorderSize { get; set; }

        [Category("Border Color"),
        Description("This Variable is support.(don't create yet)"),
        Browsable(false)]
        [DefaultValue(typeof(Padding), "2,2,2,2")]
        public Padding BorderHoverSize { get; set; }

        [Category("Border Color"),
         Description("This focus color is FocusCues color. When FocusCues is True, will can see dotted line with you specified color.")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderFocusCuesColor { get; set; }
        [Category("Border Color"),
         Description("")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "0, 84, 153")]
        public Color BorderMouseDownColor { get; set; }
        [Category("Border Color"),
         Description("")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "Highlight")]
        public Color BorderHoverColor { get; set; }

        [Category("Border Color"),
         Description("")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "191, 191, 191")]
        public Color BorderDisabledColor
        {
            get => _borderDisabledColor;
            set
            {
                _borderDisabledColor = value;
                CurrentBorderColor = this.Enabled ? BorderColor : value.IsEmpty ? BorderColor : BorderDisabledColor;
            }
        }
        #endregion
        #region Appearance Properties

        [Category("Appearance"),
        Description("When Disabled Button, Apply This Color.")]
        [DefaultValue(typeof(Color), "ButtonShadow")]
        public Color ForeDisabledColor { get; set; }

        #endregion

        //외부이벤트 발생용

        public event EventHandlers.BtnClickEventHandler BtnClick;

        #region functions

        #region Override Functions

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (this.Enabled)
            {
                CurrentBackColor = !BackHoverColor.IsEmpty ? BackHoverColor : CurrentBackColor;
                CurrentBorderColor = !BorderHoverColor.IsEmpty ? BorderHoverColor : CurrentBorderColor;
            }

            isMouseEnter = true;
            Invalidate();
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (this.Enabled)
            {
                CurrentBackColor = BackColor;
                CurrentBorderColor = !this.Focused ? BorderColor : !BorderHoverColor.IsEmpty ? BorderHoverColor : CurrentBorderColor;
            }

            isMouseEnter = false;
            Invalidate();
        }

        protected override void OnMouseDown(MouseEventArgs mevent)
        {
            base.OnMouseDown(mevent);
            if (this.Enabled)
            {
                CurrentBackColor = !BackMouseDownColor.IsEmpty ? BackMouseDownColor : CurrentBackColor;
                CurrentBorderColor = !BorderMouseDownColor.IsEmpty ? BorderMouseDownColor : CurrentBorderColor;
            }

            mouseleavedactivatetrigger = false;
            Invalidate();
        }

        protected override void OnMouseMove(MouseEventArgs mevent)
        {
            base.OnMouseMove(mevent);
            if (!this.Bounds.Contains(this.Parent.PointToClient(MousePosition)) && !mouseleavedactivatetrigger)
            {
                //MouseLeave while MouseDown
                mouseleavedactivatetrigger = true;

                //Execute OnMouseEnter
                if (this.Enabled)
                {
                    CurrentBackColor = !BackHoverColor.IsEmpty ? BackHoverColor : CurrentBackColor;
                    CurrentBorderColor = !BorderHoverColor.IsEmpty ? BorderHoverColor : CurrentBorderColor;
                }
            }
            else if (this.Bounds.Contains(this.Parent.PointToClient(MousePosition)) && mouseleavedactivatetrigger)
            {
                //When MouseLeave, MouseEnter while MouseDown
                mouseleavedactivatetrigger = false;

                //Execute OnMouseDown
                if (this.Enabled)
                {
                    CurrentBackColor = !BackMouseDownColor.IsEmpty ? BackMouseDownColor : CurrentBackColor;
                    CurrentBorderColor = !BorderMouseDownColor.IsEmpty ? BorderMouseDownColor : CurrentBorderColor;
                }
            }
        }

        protected override void OnMouseUp(MouseEventArgs mevent)
        {
            base.OnMouseUp(mevent);
            if (this.Enabled)
            {
                CurrentBackColor = !BackHoverColor.IsEmpty ? BackHoverColor : CurrentBackColor;
                CurrentBorderColor = !BorderHoverColor.IsEmpty ? BorderHoverColor : CurrentBorderColor;
            }

            mouseleavedactivatetrigger = true;
            Invalidate();
        }

        protected override void OnKeyDown(KeyEventArgs kevent)
        {
            base.OnKeyDown(kevent);
            if (kevent.KeyCode == Keys.Space && Focused)
            {
                CurrentBackColor = BackMouseDownColor;

                Invalidate();
            }
        }

        protected override void OnKeyUp(KeyEventArgs kevent)
        {
            base.OnKeyUp(kevent);
            if (kevent.KeyCode == Keys.Space && Focused)
            {
                CurrentBackColor = BackColor;
                Invalidate();
            }
        }

        protected override void OnGotFocus(EventArgs e)
        {
            base.OnGotFocus(e);
            if (this.Enabled)
            {

                //단순히 탭눌러서 포커스(선택)하면 보더가 회색임. 마우스 클릭해서 포커스(선택)하면 보더가 하이라이트인 현상 수정
                CurrentBorderColor = BorderHoverColor;
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            base.OnLostFocus(e);
            if (this.Enabled)
            {
                CurrentBorderColor = BorderColor;
            }
        }

        protected override void OnPaintBackground(PaintEventArgs pevent)
        {
            base.OnPaintBackground(pevent);
        }

        protected override void OnPaint(PaintEventArgs pevent)
        {
            base.OnPaint(pevent);

            //Draw BackColor
            pevent.Graphics.FillRectangle(new SolidBrush(this.Enabled ? CurrentBackColor : BackDisabledColor), 0, 0, Width, Height);
            //TextFormatFlags flags = TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter;qx  
            //TextRenderer.DrawText(pevent.Graphics, Text, Font, new Point(Width + 3, (TextRenderer.MeasureText(this.Text, this.Font).Height)), this.Enabled ? ForeColor : ForeDisabledColor, flags);
            //Draw Text
            pevent.Graphics.DrawString(this.Text, this.Font,
                new SolidBrush(this.Enabled ? ForeColor : ForeDisabledColor),
                AlignDrawingPoint(pevent.Graphics, pevent.Graphics.MeasureString(this.Text, this.Font).ToSize(), this.DisplayRectangle,
                    this.TextAlign));

            //DrawBorder
            ControlPaint.DrawBorder(pevent.Graphics, DisplayRectangle, this.Enabled ? CurrentBorderColor : BorderDisabledColor, ButtonBorderStyle.Solid);
            if (Focused) //선택 시 포커스
            {
                if (!isMouseEnter)
                {
                    ControlPaint.DrawBorder(pevent.Graphics, new Rectangle(1, 1, Width - 2, Height - 2), BorderHoverColor, ButtonBorderStyle.Solid);
                }

                if (this.ShowFocusCues)
                {

                    ControlPaint.DrawBorder(pevent.Graphics, new Rectangle(2, 2, Width - 4, Height - 4), BorderFocusCuesColor, ButtonBorderStyle.Dotted);
                }
            }

        }

        #endregion

        void DrawImageCore(Graphics graphics, Image image, Rectangle imageBounds, Point imageStart)
        {
            // FOR EVERETT COMPATIBILITY - DO NOT CHANGE
            imageBounds.Width += 1;
            imageBounds.Height += 1;
            imageBounds.X = imageStart.X + 1;
            imageBounds.Y = imageStart.Y + 1;

            try
            {
                if (!this.Enabled)
                    // need to specify width and height
                    ControlPaint.DrawImageDisabled(graphics, image, imageBounds.X, imageBounds.Y, this.BackColor);

                else
                {
                    graphics.DrawImage(image, imageBounds.X, imageBounds.Y, image.Width, image.Height);
                }
            }

            finally
            {
            }
        }
        //TextImageRelation RtlTranslateRelation(TextImageRelation relation)
        //{
        //    // If RTL, we swap ImageBeforeText and TextBeforeImage
        //    if (this.RightToLeft == RightToLeft.Yes)
        //    {
        //        switch (relation)
        //        {
        //            case TextImageRelation.ImageBeforeText:
        //                return TextImageRelation.TextBeforeImage;
        //            case TextImageRelation.TextBeforeImage:
        //                return TextImageRelation.ImageBeforeText;
        //        }
        //    }
        //    return relation;
        //}

        //protected virtual Size GetTextSize(Size proposedSize)
        //{
        //    //set the Prefix field of TextFormatFlags 
        //    proposedSize = this.Size;//LayoutUtils.FlipSizeIf(false /*verticalText*/, proposedSize);
        //    Size textSize = Size.Empty;

        //    if (UseCompatibleTextRendering)
        //    { // GDI+ text rendering.
        //        using (Graphics g = new System.Drawing.Printing.PrinterSettings().CreateMeasurementGraphics())
        //        {
        //            var format = new StringFormat();
        //            using (StringFormat gdipStringFormat = Control.c)
        //            {
        //                Size.Ceiling(g.MeasureString(this.Text,this.Font,new SizeF(proposedSize.Width, proposedSize.Height)))
        //                textSize = Size.Ceiling(g.MeasureString(text, font, new SizeF(proposedSize.Width, proposedSize.Height), gdipStringFormat));
        //            }
        //        }
        //    }
        //    else if (!string.IsNullOrEmpty(text))
        //    { // GDI text rendering (Whidbey feature).
        //        textSize = TextRenderer.MeasureText(text, font, proposedSize, this.TextFormatFlags);
        //    }
        //    //else skip calling MeasureText, it should return 0,0

        //    return LayoutUtils.FlipSizeIf(verticalText, textSize);

        //}

        //void LayoutTextAndImage()
        //{
        //    // Translate for Rtl applications.  This intentially shadows the member variables.
        //    ContentAlignment imageAlign = RtlTranslateContent(this.ImageAlign);
        //    ContentAlignment textAlign = RtlTranslateContent(this.TextAlign);
        //    TextImageRelation textImageRelation = RtlTranslateRelation(this.TextImageRelation);

        //    // Figure out the maximum bounds for text & image
        //    Rectangle maxBounds = Rectangle.Inflate(this.DisplayRectangle,-2, -2);
        //    if (/*growBorderBy1PxWhenDefault && */IsDefault)
        //    {
        //        maxBounds.Inflate(1, 1);
        //    }

        //    // Compute the final image and text bounds.
        //    if (this.Image.Size == Size.Empty || this.Text == null || this.Text.Length == 0 || textImageRelation == TextImageRelation.Overlay)
        //    {
        //        // Do not worry about text/image overlaying
        //        Size textSize = GetTextSize(maxBounds.Size);

        //        // FOR EVERETT COMPATIBILITY - DO NOT CHANGE
        //        Size size = imageSize;
        //        if (layout.options.everettButtonCompat && imageSize != Size.Empty)
        //        {
        //            size = new Size(size.Width + 1, size.Height + 1);
        //        }

        //        layout.imageBounds = LayoutUtils.Align(size, maxBounds, imageAlign);
        //        layout.textBounds = LayoutUtils.Align(textSize, maxBounds, textAlign);

        //    }
        //    else
        //    {
        //        // Rearrage text/image to prevent overlay.  Pack text into maxBounds - space reserved for image
        //        Size maxTextSize = LayoutUtils.SubAlignedRegion(maxBounds.Size, imageSize, textImageRelation);
        //        Size textSize = GetTextSize(maxTextSize);
        //        Rectangle maxCombinedBounds = maxBounds;

        //        // Combine text & image into one rectangle that we center within maxBounds.
        //        Size combinedSize = LayoutUtils.AddAlignedRegion(textSize, imageSize, textImageRelation);
        //        maxCombinedBounds.Size = LayoutUtils.UnionSizes(maxCombinedBounds.Size, combinedSize);
        //        Rectangle combinedBounds = LayoutUtils.Align(combinedSize, maxCombinedBounds, ContentAlignment.MiddleCenter);

        //        // imageEdge indicates whether the combination of imageAlign and textImageRelation place
        //        // the image along the edge of the control.  If so, we can increase the space for text.
        //        bool imageEdge = (AnchorStyles)(ImageAlignToRelation(imageAlign) & textImageRelation) != AnchorStyles.None;

        //        // textEdge indicates whether the combination of textAlign and textImageRelation place
        //        // the text along the edge of the control.  If so, we can increase the space for image.
        //        bool textEdge = (AnchorStyles)(TextAlignToRelation(textAlign) & textImageRelation) != AnchorStyles.None;

        //        if (imageEdge)
        //        {
        //            // If imageEdge, just split imageSize off of maxCombinedBounds.
        //            LayoutUtils.SplitRegion(maxCombinedBounds, imageSize, (AnchorStyles)textImageRelation, out layout.imageBounds, out layout.textBounds);
        //        }
        //        else if (textEdge)
        //        {
        //            // Else if textEdge, just split textSize off of maxCombinedBounds.
        //            LayoutUtils.SplitRegion(maxCombinedBounds, textSize, (AnchorStyles)LayoutUtils.GetOppositeTextImageRelation(textImageRelation), out layout.textBounds, out layout.imageBounds);
        //        }
        //        else
        //        {
        //            // Expand the adjacent regions to maxCombinedBounds (centered) and split the rectangle into imageBounds and textBounds.
        //            LayoutUtils.SplitRegion(combinedBounds, imageSize, (AnchorStyles)textImageRelation, out layout.imageBounds, out layout.textBounds);
        //            LayoutUtils.ExpandRegionsToFillBounds(maxCombinedBounds, (AnchorStyles)textImageRelation, ref layout.imageBounds, ref layout.textBounds);
        //        }

        //        // align text/image within their regions.
        //        layout.imageBounds = LayoutUtils.Align(imageSize, layout.imageBounds, imageAlign);
        //        layout.textBounds = LayoutUtils.Align(textSize, layout.textBounds, textAlign);
        //    }

        //    //Don't call "layout.imageBounds = Rectangle.Intersect(layout.imageBounds, maxBounds);"
        //    // because that is a breaking change that causes images to be scaled to the dimensions of the control.
        //    //adjust textBounds so that the text is still visible even if the image is larger than the button's size
        //    //fixes Whidbey 234985
        //    //why do we intersect with layout.field for textBounds while we intersect with maxBounds for imageBounds?
        //    //this is because there are some legacy code which squeezes the button so small that text will get clipped
        //    //if we intersect with maxBounds. Have to do this for backward compatibility.
        //    //See Whidbey 341480
        //    if (textImageRelation == TextImageRelation.TextBeforeImage || textImageRelation == TextImageRelation.ImageBeforeText)
        //    {
        //        //adjust the vertical position of textBounds so that the text doesn't fall off the boundary of the button
        //        int textBottom = Math.Min(layout.textBounds.Bottom, layout.field.Bottom);
        //        layout.textBounds.Y = Math.Max(Math.Min(layout.textBounds.Y, layout.field.Y + (layout.field.Height - layout.textBounds.Height) / 2), layout.field.Y);
        //        layout.textBounds.Height = textBottom - layout.textBounds.Y;
        //    }
        //    if (textImageRelation == TextImageRelation.TextAboveImage || textImageRelation == TextImageRelation.ImageAboveText)
        //    {
        //        //adjust the horizontal position of textBounds so that the text doesn't fall off the boundary of the button
        //        int textRight = Math.Min(layout.textBounds.Right, layout.field.Right);
        //        layout.textBounds.X = Math.Max(Math.Min(layout.textBounds.X, layout.field.X + (layout.field.Width - layout.textBounds.Width) / 2), layout.field.X);
        //        layout.textBounds.Width = textRight - layout.textBounds.X;
        //    }
        //    if (textImageRelation == TextImageRelation.ImageBeforeText && layout.imageBounds.Size.Width != 0)
        //    {
        //        //squeezes imageBounds.Width so that text is visible
        //        layout.imageBounds.Width = Math.Max(0, Math.Min(maxBounds.Width - layout.textBounds.Width, layout.imageBounds.Width));
        //        layout.textBounds.X = layout.imageBounds.X + layout.imageBounds.Width;
        //    }
        //    if (textImageRelation == TextImageRelation.ImageAboveText && layout.imageBounds.Size.Height != 0)
        //    {
        //        //squeezes imageBounds.Height so that the text is visible
        //        layout.imageBounds.Height = Math.Max(0, Math.Min(maxBounds.Height - layout.textBounds.Height, layout.imageBounds.Height));
        //        layout.textBounds.Y = layout.imageBounds.Y + layout.imageBounds.Height;
        //    }
        //    //make sure that textBound is contained in layout.field
        //    layout.textBounds = Rectangle.Intersect(layout.textBounds, layout.field);
        //    if (hintTextUp)
        //    {
        //        layout.textBounds.Y--;
        //    }
        //    if (textOffset)
        //    {
        //        layout.textBounds.Offset(1, 1);
        //    }

        //    // FOR EVERETT COMPATIBILITY - DO NOT CHANGE
        //    if (layout.options.everettButtonCompat)
        //    {
        //        layout.imageStart = layout.imageBounds.Location;
        //        layout.imageBounds = Rectangle.Intersect(layout.imageBounds, layout.field);
        //    }
        //    else if (!Application.RenderWithVisualStyles)
        //    {
        //        // Not sure why this is here, but we can't remove it, since it might break
        //        // ToolStrips on non-themed machines
        //        layout.textBounds.X++;
        //    }

        //    // clip
        //    //
        //    int bottom;
        //    // If we are using GDI to measure text, then we can get into a situation, where
        //    // the proposed height is ignore. In this case, we want to clip it against
        //    // maxbounds. VSWhidbey #480670
        //    if (!UseCompatibleTextRendering)
        //    {
        //        bottom = Math.Min(layout.textBounds.Bottom, maxBounds.Bottom);
        //        layout.textBounds.Y = Math.Max(layout.textBounds.Y, maxBounds.Y);
        //    }
        //    else
        //    {
        //        // If we are using GDI+ (like Everett), then use the old Everett code
        //        // This ensures that we have pixel-level rendering compatibility
        //        bottom = Math.Min(layout.textBounds.Bottom, layout.field.Bottom);
        //        layout.textBounds.Y = Math.Max(layout.textBounds.Y, layout.field.Y);
        //    }
        //    layout.textBounds.Height = bottom - layout.textBounds.Y;

        //    //This causes a breaking change because images get shrunk to the new clipped size instead of clipped.
        //    //********** bottom = Math.Min(layout.imageBounds.Bottom, maxBounds.Bottom);
        //    //********** layout.imageBounds.Y = Math.Max(layout.imageBounds.Y, maxBounds.Y);
        //    //********** layout.imageBounds.Height = bottom - layout.imageBounds.Y;                
        //}

        /// <summary>
        /// 
        /// </summary>
        /// <see href="https://stackoverflow.com/questions/26148619/content-alignment-for-custom-control"/>
        /// <param name="g"></param>
        /// <param name="objectSize"></param>
        /// <param name="clientRectangle"></param>
        /// <param name="alignment"></param>
        /// <returns></returns>
        public static Point AlignDrawingPoint(Graphics g, Size objectSize, Rectangle clientRectangle, ContentAlignment alignment)
        {
            int margin = 4;
            Point center = new Point((clientRectangle.Width >> 1) - (objectSize.Width >> 1), (clientRectangle.Height >> 1) - (objectSize.Height >> 1));
            int rightMargin = clientRectangle.Width - (objectSize.Width + margin);
            int bottomMargin = clientRectangle.Height - (objectSize.Height + margin);
            Point p = Point.Empty;
            switch (alignment)
            {
                case ContentAlignment.TopLeft:
                    p = new Point(margin, margin);
                    break;
                case ContentAlignment.TopCenter:
                    p = new Point(center.X, margin);
                    break;
                case ContentAlignment.TopRight:
                    p = new Point(rightMargin, margin);
                    break;
                case ContentAlignment.MiddleLeft:
                    p = new Point(margin, center.Y);
                    break;
                case ContentAlignment.MiddleCenter:
                    p = new Point(center.X, center.Y);
                    break;
                case ContentAlignment.MiddleRight:
                    p = new Point(rightMargin, center.Y);
                    break;
                case ContentAlignment.BottomLeft:
                    p = new Point(margin, bottomMargin);
                    break;
                case ContentAlignment.BottomCenter:
                    p = new Point(center.X, bottomMargin);
                    break;
                case ContentAlignment.BottomRight:
                    p = new Point(rightMargin, bottomMargin);
                    break;
            }
            p.Offset(clientRectangle.X, clientRectangle.Y);
            return p;
        }

        public override void NotifyDefault(bool value)
        {
            base.NotifyDefault(value);
            //Focus 미사용
            //base.NotifyDefault(false); 
        }

        #endregion
    }
}
