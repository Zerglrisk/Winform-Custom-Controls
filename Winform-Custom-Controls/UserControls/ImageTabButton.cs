using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Winform_Custom_Controls.UserControls
{
    [DefaultEvent("BtnClick")]
    public partial class ImageTabButton : UserControl
    {
        public ImageTabButton()
        {
            InitializeComponent();
        }


        //외부이벤트 발생용
        /// <summary>
        /// 버튼이벤트 처리로 조회시작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void BtnClickEventHandler(object sender, EventArgs e);
        public event BtnClickEventHandler BtnClick;

        private Image _checkimage;
        public Image CheckImage
        {
            get
            {
                return _checkimage;
            }
            set
            {
                _checkimage = value;
            }
        }

        private Image _baseimage;
        public Image BaseImage
        {
            get
            {
                return _baseimage;
            }
            set
            {
                _baseimage = value;
            }
        }

        private bool _selected= false;
        public bool Selected
        {
            get
            {
                return _selected;
            }
            set
            {
                _selected = value;

                if (value)
                {
                    btnBase.BackgroundImage = _checkimage;
                }
                else
                {
                    btnBase.BackgroundImage = _baseimage;
                }
            }
        }

        private string _text = "";
        public string Title
        {
            get
            {
                return _text;
            }
            set
            {
                _text = value;
                label1.Text = _text;
            }
        }


        private void usrTabButton_Load(object sender, EventArgs e)
        {
            btnBase.BackgroundImage = BaseImage;
        }

        private void usrTabButton_Resize(object sender, EventArgs e)
        {
            this.btnBase.Size = this.Size;
        }

        private void usrTabButton_Click(object sender, EventArgs e)
        {
            
        }

        private void btnBase_Click(object sender, EventArgs e)
        {
            if (BtnClick != null)
            {
                BtnClick(sender, e);
            }
        }
    }
}
