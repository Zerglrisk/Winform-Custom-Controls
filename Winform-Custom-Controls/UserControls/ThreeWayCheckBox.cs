using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace Winform_Custom_Controls.UserControls
{
    public partial class ThreeWayCheckBox : UserControl
    {
        public ThreeWayCheckBox()
        {
            InitializeComponent();

            FirstState = "Yes";
            SecondState = "No";
            ThirdState = "None";
            FirstValue = 1;
            SecondValue = 0;
            ThirdValue = -1;
            AutoIncreaseSize = true;
            txt_Shown.Text = SecondState;

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

        private string _firstState;
        [Description("Checked가 True일 경우 표시되는 텍스트"), Category("CheckBox")]
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string FirstState
        {
            get { return _firstState; }
            set
            {
                _firstState = value;
                if (this.Value == FirstValue) txt_Shown.Text = _firstState.Replace("\\n", Environment.NewLine);
                CheckAutoResize();
            }
        }

        private string _secondState;

        [Description("Checked가 False 경우 표시되는 텍스트"), Category("CheckBox")]
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SecondState
        {
            get { return _secondState; }
            set
            {

                _secondState = value;
                if (this.Value == SecondValue) txt_Shown.Text = _secondState.Replace("\\n", Environment.NewLine);
                CheckAutoResize();
            }
        }

        private string _thirdState;
        [Description("Checked가 False 경우 표시되는 텍스트"), Category("CheckBox")]
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string ThirdState
        {
            get { return _secondState; }
            set
            {

                _secondState = value;
                if (this.Value == ThirdValue) txt_Shown.Text = _secondState.Replace("\\n", Environment.NewLine);
                CheckAutoResize();
            }
        }

        

        [Category("CheckBox")]
        public string State
        {
            get
            {
                if (Value == FirstValue)
                    return FirstState;
                else if (Value == SecondValue)
                {
                    return SecondState;
                }
                else if (Value == ThirdValue)
                {
                    return ThirdState;
                }
                else
                {
                    return string.Empty;
                }
            }
        }
        
        [Category("CheckBoxValues"),Description("Checked 가 True가 될 때 Value 값")]
        [DefaultValue(1)]
        public int FirstValue { get; set; }
        [Category("CheckBoxValues"), Description("Checked 가 False가 될 때 Value 값")]
        [DefaultValue(0)]
        public int SecondValue { get; set; }
        [Category("CheckBoxValues"), Description("Checked 가 False가 될 때 Value 값")]
        [DefaultValue(-1)]
        public int ThirdValue { get; set; }

        private int? _value;
        [Browsable(false)]
        [Category("CheckBoxValues")]
        public int? Value
        {
            set { _value = value;}
            get
            {
                if (Value == FirstValue)
                    return FirstValue;
                else if (Value == SecondValue)
                {
                    return SecondValue;
                }
                else if (Value == ThirdValue)
                {
                    return ThirdValue;
                }
                else
                {
                    return null;
                }
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
            
            if (TextRenderer.MeasureText(FirstState, txt_Shown.Font).Width > txt_Shown.Width || TextRenderer.MeasureText(SecondState, txt_Shown.Font).Width > txt_Shown.Width || TextRenderer.MeasureText(SecondState, txt_Shown.Font).Width > txt_Shown.Width)
            {
                if (TextRenderer.MeasureText(FirstState, txt_Shown.Font).Width >
                    TextRenderer.MeasureText(SecondState, txt_Shown.Font).Width)
                {
                    if (TextRenderer.MeasureText(FirstState, txt_Shown.Font).Width > TextRenderer.MeasureText(ThirdState, txt_Shown.Font).Width)
                    {
                        this.Width = TextRenderer.MeasureText(FirstState, txt_Shown.Font).Width;
                    }
                    else
                    {
                        this.Width = TextRenderer.MeasureText(ThirdState, txt_Shown.Font).Width;
                    }
                }
                else
                {
                    if (TextRenderer.MeasureText(SecondState, txt_Shown.Font).Width > TextRenderer.MeasureText(ThirdState, txt_Shown.Font).Width)
                    {
                        this.Width = TextRenderer.MeasureText(SecondState, txt_Shown.Font).Width;
                    }
                    else
                    {
                        this.Width = TextRenderer.MeasureText(ThirdState, txt_Shown.Font).Width;
                    }
                }
                 
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
                this.Height =  25;
            }
        }

        private void txt_Shown_Click(object sender, EventArgs e)
        {
            if (Value == FirstValue)
                Value = SecondValue;
            else if (Value == SecondValue)
                Value = ThirdValue;
            else if (Value == ThirdValue)
                Value = FirstValue;

        }
    }
}
