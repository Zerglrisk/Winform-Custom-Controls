using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Winform_Custom_Controls.UserControls
{
    [DefaultEvent("BtnClick")]
    public partial class CtrlTabButton : UserControl
    {
        public CtrlTabButton()
        {
            InitializeComponent();

            BorderSize = new Padding(1);
            SelectedSizeUp = HideBorderOnSelected = false;
            this.border.BackColor = BaseColor = SystemColors.Control;
            BorderColor = Color.Black;
            SelectedColor = Color.Black;
            BaseFontColor = Color.Black;
            OnFontColor = Color.Black;
            SelectedFontColor = Color.Black;
            expandWidth = expandHeight = 5;
            label1.Parent = border;
            label1.BackColor = Color.Transparent;
            label1.BringToFront();
        }


        //외부이벤트 발생용
        public event EventHandlers.BtnClickEventHandler BtnClick;


        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override Font Font
        {
            get => base.Font;
            set
            {
                base.Font = value;             
                label1.Font = base.Font;
            }
        }

        private Padding _borderSize;
        [Category("BackColor")]
        [DefaultValue(typeof(Padding), "1,1,1,1")]
        public Padding BorderSize
        {
            get => _borderSize;
            set
            {
                _borderSize = value;
                this.Padding = _borderSize;
            }
        }
        [Category("BackColor")]
        [DefaultValue(typeof(Color), "Black")]
        public Color SelectedColor { get; set; }

        public Color _baseColor;
        [Category("BackColor")]
        [DefaultValue(typeof(Color),"Control")]
        public Color BaseColor
        {
            get => _baseColor;
            set => _baseColor = border.BackColor = value;
        }

        #region variable int ExpandWidth
        private int expandWidth = 0;
        // Declare an expandWidth property of type int:
        [DefaultValue(5)]
        [Category("Expand")]
        public int ExpandWidth
        {
            get
            {
                return expandWidth;
            }
            set
            {
                expandWidth = value;
            }
        }
        #endregion variable int ExpandWidth
        #region variable int ExpandHeight
        
        private int expandHeight = 0;
        // Declare an expandHeight property of type int:
        [Category("Expand")]
        [DefaultValue(5)]
        public int ExpandHeight
        {
            get
            {
                return expandHeight;
            }
            set
            {
                expandHeight = value;
            }
        }
        #endregion variable int ExpandHeight

        [Category("ForeColor")]
        [DefaultValue(typeof(Color), "Black")]
        public Color BaseFontColor { get; set; }

        [Category("ForeColor")]
        [DefaultValue(typeof(Color), "Black")]
        public Color OnFontColor { get; set; }

        [Category("ForeColor")]
        [DefaultValue(typeof(Color), "Black")]
        public Color SelectedFontColor { get; set; }

        [Category("BackColor")]
        [DefaultValue(false)]
        public bool HideBorderOnSelected { get; set; }
        private bool _selected= false;
        [Category("Tab Function")]
        [DefaultValue(false)]
        public bool Selected
        {
            get => _selected;
            set
            {
                if (_selected == value) return;
                _selected = value;
                if (value)
                {
                    border.BackColor = SelectedColor;
                    //label1.BorderStyle = BorderStyle.Fixed3D;

                    if(HideBorderOnSelected)
                        this.BackColor = SelectedColor;

                    label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size, FontStyle.Bold);
                    label1.ForeColor = SelectedFontColor;

                    if (SelectedSizeUp)
                    {
                        this.Size = new Size(this.Size.Width + ExpandWidth, this.Size.Height + ExpandHeight);//this.Size = new Size(this.Size.Width + 10, this.Size.Height + 5);
                        this.Location = new Point(this.Location.X, this.Location.Y - ExpandHeight);
                        for (var next = nextButton; next != null; next = next.nextButton)
                        {
                            next.Location = new Point(next.Location.X + ExpandWidth, next.Location.Y);
                        }
                    }

                    for (var next = nextButton; next != null; next = next.nextButton)
                    {
                        next.Selected = false;
                    }
                    for (var prev = prevButton; prev != null; prev = prev.prevButton)
                    {
                        prev.Selected = false;
                    }
                }
                else
                {
                    border.BackColor = BaseColor;
                    //label1.BorderStyle = BorderStyle.None;
                    this.BackColor = prevBorderColor;
                    label1.Font = new Font(label1.Font.FontFamily, label1.Font.Size);
                    label1.ForeColor = BaseFontColor;
                    if (SelectedSizeUp)
                    {
                        this.Size = new Size(this.Size.Width - ExpandWidth, this.Size.Height - ExpandHeight);
                        this.Location = new Point(this.Location.X, this.Location.Y + ExpandHeight);
                        for (var next = nextButton; next != null; next = next.nextButton)
                        {
                            next.Location = new Point(next.Location.X - ExpandWidth, next.Location.Y);
                        }
                    }
                }
            }
        }
        #region variable Color BorderColor
        
        private Color prevBorderColor;
        // Declare an _borderColor property of type Color:
        [Category("BackColor")]
        [DefaultValue(typeof(Color), "Black")]
        public Color BorderColor
        {
            get
            {
                return prevBorderColor;
            }
            set
            {
                
                 this.BackColor =  prevBorderColor = value;
            }
        }

        [Browsable(false)]
        public override Color BackColor
        {
            get { return base.BackColor;}
            set { base.BackColor = value; }
        }

        #endregion variable Color BorderColor


        #region variable bool SelectedSizeUp
        private CtrlTabButton nextButton;
        [Description("가로 또는 세로로 나열 시 사이즈에 의해 크기와 위치가 같이 변경하여야 한다. 이에 따른 연결된 다음 버튼을 선택한다."), Category("Expand")]
        public CtrlTabButton NextButton
        {
            get
            {
                return nextButton;
            }
            set
            {
                if (nextButton == this)
                {
                    //throw new InvalidEnumArgumentException(nameof(value),(int)value,typeof(TabButton));
                    //throw new ArgumentException("You Cannot Select TabButton itself.");
                }
                nextButton = value;
            }
        }
        CtrlTabButton prevButton;
        [Description("select를 하나만 하면 그 외 연결된 버튼은 전부 select를 false하기 위해 사용된다."), Category("Expand")]
        public CtrlTabButton PrevButton
        {
            get
            {
                return prevButton;
            }
            set
            {
                if(value == prevButton) new WarningException("This is a warning");
                prevButton = value;
            }
        }

        // Declare an _selectedSizeUp property of type bool:
        [Description("사용하면, 선택된 버튼의 크기의 사이즈가 변경이 된다."),Category("Expand")]
        [DefaultValue(false)]
        public bool SelectedSizeUp { get; set; }

        #endregion variable bool SelectedSizeUp
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        [Editor(typeof(System.ComponentModel.Design.MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;
                this.label1.Text = base.Text;
            }
        }

        
        
        
        

        private void label1_Click(object sender, EventArgs e)
        {
            this.Selected = true;
            if (BtnClick != null)
            {
                BtnClick(this, e);
            }
        }

        private void label1_MouseEnter(object sender, EventArgs e)
        {
            if(!Selected)
            {
                border.BackColor = SelectedColor;
                label1.ForeColor = OnFontColor;
            }
                
        }

        private void label1_MouseLeave(object sender, EventArgs e)
        {
            if (!Selected)
            {
                border.BackColor = BaseColor;
                label1.ForeColor = BaseFontColor;
            }
                
        }

        public void applyBackColorSet(CtrlTabButton btncolor)
        {
            btncolor.BaseColor = this.BaseColor;
            btncolor.SelectedColor = this.SelectedColor;
        }
        
    }
}
