using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Winform_Custom_Controls.Inherits
{
    public class ImageButton : PictureBox
    {
        public ImageButton()
        {
            this.DoubleBuffered = true;

            ImageSizeMode = PictureBoxSizeMode.StretchImage;
            InvertImageOnDisabled = false;
        }
        private bool _invertImageOnDisabled;

        [Category("ButtonAppearance"), DefaultValue(false)]
        public bool InvertImageOnDisabled
        {
            get => _invertImageOnDisabled;
            set
            {
                _invertImageOnDisabled = value;
                BaseImage_Changed();
            }
        }

        [Category("ButtonAppearance"), DefaultValue(typeof(Image), null)]
        public Image HoverImage { get; set; }

        [Category("ButtonAppearance")]
        [DefaultValue(typeof(PictureBoxSizeMode), "StretchImage")]
        public PictureBoxSizeMode ImageSizeMode
        {
            get => base.SizeMode;
            set => base.SizeMode = value;
        }

        private Image _baseImage;
        [Category("ButtonAppearance"), DefaultValue(typeof(Image), null)]
        public Image BaseImage
        {
            get => _baseImage;
            set
            {
                _baseImage = value;
                BaseImage_Changed();
            }
        }

        [Category("ButtonAppearance"), DefaultValue(typeof(Image), null)]
        public Image MouseDownImage { get; set; }

        protected override void OnPaint(PaintEventArgs pe)
        {
            base.OnPaint(pe);
        }

        private Image _disabledImage;
        [Category("ButtonAppearance"), DefaultValue(typeof(Image), null)]
        public Image DisabledImage
        {
            get => _disabledImage;
            set
            {
                _disabledImage = value;
                if (_disabledImage != null)
                    BaseImage_Changed();
            }
        }
        private void BaseImage_Changed()
        {
            this.Image = this.Enabled ? BaseImage : this.InvertImageOnDisabled ? GetInvertImage(BaseImage) : DisabledImage;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            this.Image = this.Enabled ? BaseImage : this.InvertImageOnDisabled ? GetInvertImage(BaseImage) : DisabledImage;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (this.Enabled && HoverImage != null)
            {
                this.Image = HoverImage;
            }
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            if (this.Enabled)
            {
                this.Image = BaseImage;
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            if (this.Enabled && MouseDownImage != null)
            {
                this.Image = MouseDownImage;
            }
        }
        protected override void OnMouseUp(MouseEventArgs e)
        {
            base.OnMouseUp(e);
            if (this.Enabled)
            {
                this.Image = BaseImage;
            }
        }

        /// <summary>
        /// Invert the Image
        /// </summary>
        /// <param name="image"></param>
        /// <see href="https://stackoverflow.com/a/33024899/6485333"/>
        /// <returns>A inverted <code>Image</code>.</returns>
        private Image GetInvertImage(Image image)
        {
            if (image == null) return null;
            Bitmap pic = new Bitmap(image);
            for (int y = 0; (y <= (pic.Height - 1)); y++)
            {
                for (int x = 0; (x <= (pic.Width - 1)); x++)
                {
                    Color inv = pic.GetPixel(x, y);
                    inv = Color.FromArgb(255, (255 - inv.R), (255 - inv.G), (255 - inv.B));
                    pic.SetPixel(x, y, inv);
                }
            }
            return pic;
        }
    }
}
