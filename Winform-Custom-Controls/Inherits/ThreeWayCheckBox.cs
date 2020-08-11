using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Windows.Forms;

namespace Winform_Custom_Controls.UserControls
{
    public sealed class ThreeWayCheckBox : TextBox
    {
        public ThreeWayCheckBox()
        {
            #region Readonly(No Change This)
            var backcolor = this.BackColor;
            ReadOnly = true;
            this.BackColor = backcolor; 
            #endregion

            FirstState = "Yes";
            SecondState = "No";
            ThirdState = "None";
            FirstValue = 1;
            SecondValue = 0;
            ThirdValue = -1;
            AutoIncreaseSize = true;
            this.Text = FirstState;
            Value = FirstValue;
        }

        #region Unusable Properties
        [Browsable(false)]
        private new bool ReadOnly
        {
            get => base.ReadOnly;
            set => base.ReadOnly = value;
        }
        /// <summary>
        /// 미사용(숨김 표시처리용)
        /// </summary>
        [Browsable(false)]
        private new string Text 
        { 
            get => base.Text;
            set => base.Text = value;
        }
        #endregion

        #region CheckBox Properties

        /// <summary>
        /// 텍스트 정렬
        /// </summary>
        [Category("CheckBox")]
        public new System.Windows.Forms.HorizontalAlignment TextAlign
        {
            get => base.TextAlign;
            set => base.TextAlign = value;
        }

        private string _firstState;
        [Description("Checked가 True일 경우 표시되는 텍스트"), Category("CheckBox")]
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string FirstState
        {
            get => _firstState;
            set
            {
                _firstState = value;
                if (this.Value == FirstValue) this.Text = _firstState.Replace("\\n", Environment.NewLine);
                CheckAutoResize();
            }
        }

        private string _secondState;

        [Description("Checked가 False 경우 표시되는 텍스트"), Category("CheckBox")]
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string SecondState
        {
            get => _secondState;
            set
            {

                _secondState = value;
                if (this.Value == SecondValue) this.Text = _secondState.Replace("\\n", Environment.NewLine);
                CheckAutoResize();
            }
        }

        private string _thirdState;
        [Description("Checked가 False 경우 표시되는 텍스트"), Category("CheckBox")]
        [Editor(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public string ThirdState
        {
            get => _thirdState;
            set
            {

                _thirdState = value;
                if (this.Value == ThirdValue) this.Text = _thirdState.Replace("\\n", Environment.NewLine);
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
                if (Value == SecondValue)
                {
                    return SecondState;
                }
                if (Value == ThirdValue)
                {
                    return ThirdState;
                }

                return string.Empty;
            }
        }

        [Description("표시되는 텍스트의 크기가 컨트롤의 크기보다 커질 경우 자동으로 증가시켜줍니다. 만약 Multiline을 사용 시 작동되지 않습니다."), Category("CheckBox")]
        public bool AutoIncreaseSize { get; set; }
        [Description("텍스트의 여러 줄을 사용합니다."), Category("CheckBox")]
        public override bool Multiline
        {
            get => base.Multiline;
            set
            {
                base.Multiline = value;
                if (!base.Multiline)
                {
                    this.Height = TextRenderer.MeasureText(this.Text, this.Font).Width;
                }
            }
        }
        #endregion

        #region CheckBoxValues Properties

        [Category("CheckBoxValues"), Description("Checked 가 True가 될 때 Value 값")]
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
            set => _value = value;
            get
            {
                if (_value.HasValue && _value.Value == FirstValue)
                    return (int?)FirstValue;
                else if (_value.HasValue && _value.Value == SecondValue)
                {
                    return (int?)SecondValue;
                }
                else if (_value.HasValue && _value.Value == ThirdValue)
                {
                    return (int?)ThirdValue;
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region Private Functions
        private void CheckAutoResize()
        {
            if (!AutoIncreaseSize || Multiline) return;

            if (TextRenderer.MeasureText(FirstState, this.Font).Width > this.Width || TextRenderer.MeasureText(SecondState, this.Font).Width > this.Width || TextRenderer.MeasureText(SecondState, this.Font).Width > this.Width)
            {
                if (TextRenderer.MeasureText(FirstState, this.Font).Width >
                    TextRenderer.MeasureText(SecondState, this.Font).Width)
                {
                    this.Width = TextRenderer.MeasureText(FirstState, this.Font).Width > TextRenderer.MeasureText(ThirdState, this.Font).Width ? TextRenderer.MeasureText(FirstState, this.Font).Width : TextRenderer.MeasureText(ThirdState, this.Font).Width;
                }
                else
                {
                    this.Width = TextRenderer.MeasureText(SecondState, this.Font).Width > TextRenderer.MeasureText(ThirdState, this.Font).Width ? TextRenderer.MeasureText(SecondState, this.Font).Width : TextRenderer.MeasureText(ThirdState, this.Font).Width;
                }

            }
        }
        #endregion

        #region Override Functions

        protected override void OnMouseDown(MouseEventArgs e)
        {
            base.OnMouseDown(e);
            //마우스 밑으로 누르자마자 변경하고 싶을 때
            //Checked = !Checked;
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            this.Cursor = Cursors.Hand;
        }

        protected override void OnMouseLeave(EventArgs e)
        {
            base.OnMouseLeave(e);
            this.Cursor = Cursors.Default;
        }

        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            if (!this.Multiline)
            {
                this.Height = TextRenderer.MeasureText(this.Text, this.Font).Width;
            }
        }

        protected override void OnClick(EventArgs e)
        {
            base.OnClick(e);

            if (Value == FirstValue)
                Value = SecondValue;
            else if (Value == SecondValue)
                Value = ThirdValue;
            else if (Value == ThirdValue)
                Value = FirstValue;

            this.Text = State;
        } 
        #endregion
    }
}
