using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Winform_Custom_Controls.UserControls
{
    [DefaultEvent("BtnClick")]
    public partial class CtrlImageTabButton : UserControl
    {
        public CtrlImageTabButton()
        {
            InitializeComponent();
        }


        //외부이벤트 발생용
        public event EventHandlers.BtnClickEventHandler BtnClick;

        public Image CheckImage { get; set; }

        public Image BaseImage { get; set; }

        private bool _selected= false;
        public bool Selected
        {
            get => _selected;
            set
            {
                _selected = value;

                btnBase.BackgroundImage = value ? CheckImage : BaseImage;
            }
        }

        private string _text = "";
        public string Title
        {
            get => _text;
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
            BtnClick?.Invoke(sender, e);
        }
    }
}
