using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Winform_Custom_Controls.Inherits
{
    public class GradientPanel : System.Windows.Forms.Panel
    {
        private System.Drawing.Color startColor;
        private System.Drawing.Color endColor;
        private System.ComponentModel.IContainer components = null;
        public GradientPanel()
        {
            InitializeComponent();

            GradientMode = System.Drawing.Drawing2D.LinearGradientMode.Vertical;
            PageStartColor = PageEndColor = System.Drawing.SystemColors.Control;
            EnableGradient = true;
            //PaintGradient();

            this.DoubleBuffered = true;
        }
        [Category("Behavior"), Description("Usable Gradient"), DefaultValue(true), Browsable(true)]
        public bool EnableGradient { get; set; }
        [Category("Appearance"), Description("Gradient Color When Start"),
         Browsable(true), DefaultValue(typeof(System.Drawing.Color), "Control")]
        public System.Drawing.Color PageStartColor
        {
            get { return startColor; }
            set
            {
                startColor = value;
                //PaintGradient();
            }
        }
        [Category("Appearance"), Description("Gradient Color When End"),
         Browsable(true), DefaultValue(typeof(System.Drawing.Color), "Control")]
        public System.Drawing.Color PageEndColor
        {
            get { return endColor; }
            set
            {
                endColor = value;
                //PaintGradient();
            }
        }
        [Category("Appearance"), Browsable(true), Description("Gradient Mode"), DefaultValue(typeof(System.Drawing.Drawing2D.LinearGradientMode), "Vertical")]
        public System.Drawing.Drawing2D.LinearGradientMode GradientMode { get; set; }

        //protected override void WndProc(ref Message m)
        //{
        //    base.WndProc(ref m);
        //    if (m.Msg == 0xF) //WM_PAINT
        //    {
        //        //Foreground이므로 다른 컨트롤에서 transparent가 안먹히므로 미사용
        //        //using (var g = Graphics.FromHwnd(this.Handle))
        //        //{
        //        //    if (this.EnableGradient)
        //        //    {
        //        //        using (var grad = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height),
        //        //            PageStartColor, PageEndColor, GradientMode))
        //        //        {
        //        //            g.FillRectangle(grad, new Rectangle(0, 0, this.Width, this.Height));
        //        //        }
        //        //    }
        //        //}
        //    }
        //    else if (m.Msg == 0x14) //WM_ERASEBKGND
        //    {

        //    }
        //}

        protected override void OnPaintBackground(PaintEventArgs e)
        {

            if (this.EnableGradient)
            {
                try
                {
                    var grad = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height),
                        PageStartColor, PageEndColor, GradientMode);
                    e.Graphics.FillRectangle(grad, new Rectangle(0, 0, this.Width, this.Height));
                    grad.Dispose();
                }
                catch (ArgumentException ex)
                {
                    //Width 0일때 에러 발생 무시
                }
            }
            else
            {
                base.OnPaintBackground(e);
            }
        }
        //protected override void OnPaint(PaintEventArgs e)
        //{
        //    base.OnPaint(e);
        //    using (var g = e.Graphics)
        //    {
        //        using (var grad = new LinearGradientBrush(new Rectangle(0, 0, this.Width, this.Height),
        //            PageStartColor, PageEndColor, GradientMode))
        //        {
        //            g.FillRectangle(grad, new Rectangle(0, 0, this.Width, this.Height));
        //        }
        //    }

        //}


        private void PaintGradient()
        {
            var gradientBrush = new System.Drawing.Drawing2D.LinearGradientBrush(new System.Drawing.Rectangle(0, 0, this.Width, this.Height), PageStartColor, PageEndColor, GradientMode);

            var bitmap = new System.Drawing.Bitmap(this.Width, this.Height);
            var g = System.Drawing.Graphics.FromImage(bitmap);

            g.FillRectangle(gradientBrush, new System.Drawing.Rectangle(0, 0, this.Width, this.Height));
            this.BackgroundImage = bitmap;
            this.BackgroundImageLayout = ImageLayout.Stretch;
        }


        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            //GradientPanel
            this.ResumeLayout(false);
        }

    }
}
