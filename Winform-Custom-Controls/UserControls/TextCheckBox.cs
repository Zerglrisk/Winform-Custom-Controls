using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace Winform_Custom_Controls.UserControls
{
    public partial class TextCheckBox : UserControl
    {
        public TextCheckBox()
        {
            InitializeComponent();

            TrueText = "Yes";
            FalseText = "No";
            HasValue = false;
            TrueValue = 100000001;
            FalseValue = 100000000;
            AutoIncreaseSize = true;
            txt_Shown.Text = FalseText;

        }

        /// <summary>
        /// 미사용(숨김 표시처리용)
        /// </summary>
        [Browsable(false)]
        public override string Text { get; set; }

        /// <summary>
        /// 텍스트 정렬
        /// </summary>
        [Category("CheckBox")]
        public System.Windows.Forms.HorizontalAlignment TextAlign
        {
            get { return txt_Shown.TextAlign; }
            set { txt_Shown.TextAlign = value; }
        }

        private string _trueText;
        [Description("Checked가 True일 경우 표시되는 텍스트"), Category("CheckBox")]
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string TrueText
        {
            get { return _trueText; }
            set
            {
                _trueText = value;
                if (_checked) txt_Shown.Text = _trueText.Replace("\\n", Environment.NewLine);
                CheckAutoResize();
            }
        }

        private string _falseText;

        [Description("Checked가 False 경우 표시되는 텍스트"), Category("CheckBox")]
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string FalseText
        {
            get { return _falseText; }
            set
            {

                _falseText = value;
                if (!_checked) txt_Shown.Text = _falseText.Replace("\\n", Environment.NewLine);
                CheckAutoResize();
            }
        }

        private bool _checked;

        [Category("CheckBox")]
        public bool Checked
        {
            get { return _checked; }
            set
            {
                _checked = value;
                txt_Shown.Text = _checked ? TrueText : FalseText;
            }
        }

        [Category("CheckBoxValues")]
        [DefaultValue(false)]
        public bool HasValue { get; set; }
        [Category("CheckBoxValues"),Description("Checked 가 True가 될 때 Value 값")]
        [DefaultValue(100000001)]
        public int TrueValue { get; set; }
        [Category("CheckBoxValues"), Description("Checked 가 False가 될 때 Value 값")]
        [DefaultValue(100000000)]
        public int FalseValue { get; set; }

        [Browsable(false)]
        [Category("CheckBoxValues")]
        public int? Value
        {
            get
            {
                if (HasValue)
                    return Checked ? TrueValue : FalseValue;
                else return null;
            }
        }

        [Description("표시되는 텍스트의 크기가 컨트롤의 크기보다 커질 경우 자동으로 증가시켜줍니다. 만약 Multiline을 사용 시 작동되지 않습니다."), Category("CheckBox")]
        public bool AutoIncreaseSize { get; set; }
        [Description("텍스트의 여러 줄을 사용합니다."), Category("CheckBox")]
        public bool MultiLine
        {
            get { return txt_Shown.Multiline;}
            set
            {
                txt_Shown.Multiline = value;
                if (!txt_Shown.Multiline)
                {
                    this.Height = 25;
                }
            }
        }

        private void CheckAutoResize()
        {
            if (!AutoIncreaseSize || MultiLine) return;
            
            if (TextRenderer.MeasureText(_trueText, txt_Shown.Font).Width > txt_Shown.Width || TextRenderer.MeasureText(_falseText, txt_Shown.Font).Width > txt_Shown.Width)
            {
                this.Width = TextRenderer.MeasureText(_trueText, txt_Shown.Font).Width > TextRenderer.MeasureText(_falseText, txt_Shown.Font).Width 
                    ? TextRenderer.MeasureText(_trueText, txt_Shown.Font).Width : TextRenderer.MeasureText(_falseText, txt_Shown.Font).Width;
            }
        }
        private void txt_Shown_MouseDown(object sender, MouseEventArgs e)
        {
            //마우스 밑으로 누르자마자 변경하고 싶을 때
            //Checked = !Checked;
        }

        private void txt_Shown_MouseEnter(object sender, EventArgs e)
        {
            txt_Shown.Cursor = Cursors.Hand;
        }

        private void txt_Shown_MouseLeave(object sender, EventArgs e)
        {
            txt_Shown.Cursor = Cursors.Default;
        }
        
        private void usrCheckBox_Resize(object sender, EventArgs e)
        {
            if (!txt_Shown.Multiline)
            {
                this.Height =  txt_Shown.Height;
            }
        }

        private void txt_Shown_Click(object sender, EventArgs e)
        {
            Checked = !Checked;

        }
    }
}
