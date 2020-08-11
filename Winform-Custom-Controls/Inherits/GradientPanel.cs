using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Winform_Custom_Controls.Inherits
{
    public sealed class GradientPanel : System.Windows.Forms.Panel
    {
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
        #region Behavior Properties

        [Category("Behavior"), Description("Usable Gradient"), DefaultValue(true), Browsable(true)]
        public bool EnableGradient { get; set; }
        #endregion

        #region Appearance Properties

        [Category("Appearance"), Description("Gradient Color When Start"),
         Browsable(true), DefaultValue(typeof(System.Drawing.Color), "Control")]
        public System.Drawing.Color PageStartColor { get; set; }

        [Category("Appearance"), Description("Gradient Color When End"),
         Browsable(true), DefaultValue(typeof(System.Drawing.Color), "Control")]
        public System.Drawing.Color PageEndColor { get; set; }

        [Category("Appearance"), Browsable(true), Description("Gradient Mode"), DefaultValue(typeof(System.Drawing.Drawing2D.LinearGradientMode), "Vertical")]
        public System.Drawing.Drawing2D.LinearGradientMode GradientMode { get; set; }
        #endregion

        #region Override Functions
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

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                components?.Dispose();
            }
            base.Dispose(disposing);
        }

        #endregion

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
