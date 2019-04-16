using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Winform_Custom_Controls.UserControls
{
    [DefaultEvent("BtnClick")]
    public partial class ImageButton : UserControl
    {
        public ImageButton()
        {
            InitializeComponent();

            ImageSizeMode = PictureBoxSizeMode.StretchImage;
            
        }

        //외부이벤트 발생용
        /// <summary>
        /// 버튼이벤트 처리로 조회시작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void BtnClickEventHandler(object sender, EventArgs e);
        public event BtnClickEventHandler BtnClick;

        private bool _invertImageOnDisabled;

        [Category("ButtonAppearance"), DefaultValue(false)]
        public bool InvertImageOnDisabled
        {
            get { return _invertImageOnDisabled;}
            set
            {
                _invertImageOnDisabled = value;
                BaseImage_Changed();
            }
        }

        private Image _hoverimage;
        [Category("ButtonAppearance"),DefaultValue(typeof(Image),null)]
        public Image HoverImage
        {
            get
            {
                return _hoverimage;
            }
            set
            {
                _hoverimage = value;
            }
        }
        [Category("ButtonAppearance")]
        [DefaultValue(typeof(PictureBoxSizeMode), "StretchImage")]
        public PictureBoxSizeMode ImageSizeMode
        {
            get { return picButton.SizeMode; }
            set { picButton.SizeMode = value; }
        }

        private Image _baseimage;
        [Category("ButtonAppearance"), DefaultValue(typeof(Image), null)]
        public Image BaseImage
        {
            get
            {
                return _baseimage;
            }
            set
            {
                _baseimage = value;
                BaseImage_Changed();
            }
        }

        private Image _mouseDownImage;
        [Category("ButtonAppearance"), DefaultValue(typeof(Image), null)]
        public Image MouseDownImage
        {
            get
            {
                return _mouseDownImage;
            }
            set
            {
                _mouseDownImage = value;
            }
        }

        private Image _disabledimage;
        [Category("ButtonAppearance"), DefaultValue(typeof(Image), null)]
        public Image DisabledImage
        {
            get
            {
                return _disabledimage;
            }
            set
            {
                _disabledimage = value;
                if(_disabledimage != null)
                    BaseImage_Changed();
            }
        }
        
        private void BaseImage_Changed()
        {
            picButton.Image = this.Enabled ? BaseImage : this.InvertImageOnDisabled ? GetInvertImage(BaseImage) : DisabledImage;
        }

        private void picButton_Click(object sender, EventArgs e)
        {
            if (!this.Enabled)
                return;

            BtnClick?.Invoke(sender, e);
        }
        

        private void usrButton_EnabledChanged(object sender, EventArgs e)
        {
            picButton.Image = this.Enabled ? BaseImage : this.InvertImageOnDisabled ? GetInvertImage(BaseImage): DisabledImage;
        }

        private void picButton_MouseHover(object sender, EventArgs e)
        {
            if (this.Enabled && HoverImage != null)
            {
                picButton.Image = HoverImage;
            }

            //this.BorderStyle = BorderStyle.FixedSingle;
        }

        private void picButton_MouseLeave(object sender, EventArgs e)
        {
            if (this.Enabled && HoverImage != null)
            {
                picButton.Image = BaseImage;
            }

            //this.BorderStyle = BorderStyle.None;
        }

        private void picButton_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Enabled && MouseDownImage != null)
            {
                picButton.Image = MouseDownImage;
            }


            //UserControl 이벤트와 연결
            //MouseDown을 에 창 드래그를 넣으면 Click은 작동하지 않습니다. 
            this.OnMouseDown(e);
        }

        private void picButton_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Enabled && MouseDownImage != null)
            {
                picButton.Image = BaseImage;
            }
        }

        private void picButton_MouseMove(object sender, MouseEventArgs e)
        {
            //UserControl 이벤트와 연결
            this.OnMouseMove(e);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="image"></param>
        /// <see href="https://stackoverflow.com/a/33024899/6485333"/>
        /// <returns></returns>
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
