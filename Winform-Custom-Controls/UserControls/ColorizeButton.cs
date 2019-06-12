using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Winform_Custom_Controls.UserControls
{
    [DefaultEvent("BtnClick")]
    public partial class ColorizeButton : UserControl
    {
        public new bool Focused;

        public ColorizeButton()
        {
            InitializeComponent();

            BorderSize = new Padding(1);
            BorderColor = SystemColors.ButtonShadow;
            BackColor = SystemColors.ControlLight;
            HoverColor = ColorTranslator.FromHtml("#E5F1FB");
            MouseDownColor = ColorTranslator.FromHtml("#CCE4F7");
            BackDisabledColor = ColorTranslator.FromHtml("#cccccc");
            BorderHoverColor = SystemColors.MenuHighlight;
            BorderMouseDownColor = ColorTranslator.FromHtml("#005499");
            BorderFocusColor = ColorTranslator.FromHtml("#0078D7");
            BorderFocusSize = new Padding(2);
            ForeColor = SystemColors.ControlText;
            ForeHoverColor = SystemColors.ControlText;
            ForeMouseDownColor = SystemColors.ControlText;
            ForeDisabledColor = SystemColors.GrayText;
            Focused = false;

            label1.Parent = btnColor;
            label1.BringToFront();
        }

        //외부이벤트 발생용
        /// <summary>
        /// 버튼이벤트 처리로 조회시작
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public delegate void BtnClickEventHandler(object sender, EventArgs e);
        public event BtnClickEventHandler BtnClick;


        #region Back Colors Properties
        [Category("Back Colors")]
        [DefaultValue(typeof(Color), "229, 241, 251")]
        public Color HoverColor { get; set; }

        [Category("Back Colors")]
        [DefaultValue(typeof(Color), "204, 228, 247")]
        public Color MouseDownColor { get; set; }

        private Color _backcolor;
        [Category("Back Colors")]
        [DefaultValue(typeof(Color), "ControlLight")]
        public override Color BackColor
        {
            get
            {
                return _backcolor;
            }
            set
            {
                if (value == Color.Empty)
                {
                    btnColor.BackColor = _backcolor = SystemColors.ControlLight;
                    //throw new ArgumentNullException("Color.Empty","BackColor Cannot Be Empty");
                }
                else
                {
                    btnColor.BackColor = _backcolor = value;
                }
                
            }
        }

        private Color _backDisabledColor;
        [Category("Back Colors"), Description("The background color of the component when disabled")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "204, 204, 204")]
        public Color BackDisabledColor
        {
            get
            {
                return _backDisabledColor;
            }
            set
            {
                _backDisabledColor = value;


                btnColor.BackColor = this.Enabled ? BackColor : value.IsEmpty ? BackColor : BackDisabledColor;

            }
        }

        #endregion

        #region Fore Colors Properties

        [Category("ForeColors"), DefaultValue(typeof(Color), "ControlText")]
        public Color ForeHoverColor { get; set; }
        [Category("ForeColors"), DefaultValue(typeof(Color), "ControlText")]
        public Color ForeMouseDownColor { get; set; }

        private Color _foreColor;
        [Category("ForeColors"),DefaultValue(typeof(Color), "ControlText")]
        public override Color ForeColor
        {
            get { return _foreColor;}
            set
            {
                if (value == Color.Empty)
                {
                    label1.ForeColor = _foreColor = SystemColors.ControlText;
                    //throw new ArgumentNullException("Color.Empty","BackColor Cannot Be Empty");
                }
                else
                {
                    label1.ForeColor = _foreColor = value;
                }
                
            }
        }

        private Color _foreDisabledColor;

        [Description("Label Control need Customize. (Froms.Label always set GrayText when disabled")]
        [Browsable(false)]
        [Category("ForeColors"), DefaultValue(typeof(Color), "GrayText")]
        public Color ForeDisabledColor
        {
            get { return _foreDisabledColor;}
            set
            {
                _foreDisabledColor = value;
                label1.ForeColor = this.Enabled ? ForeColor : value.IsEmpty ? ForeColor : _foreDisabledColor;
            }
        }

        #endregion

        #region Border Colors Properties
        private Color _borderColor;
        [Category("Border Color")]
        [DefaultValue(typeof(Color), "ButtonShadow")]
        public Color BorderColor
        {
            get { return _borderColor; }
            set
            {
                if (value == Color.Empty)
                {
                    border.BackColor = _borderColor = SystemColors.ButtonShadow;
                    //throw new ArgumentNullException("Color.Empty", "BorderColor Cannot Be Empty");
                }
                border.BackColor = _borderColor = value;
            }
        }

        [Category("Border Color"),
         Description("The background color of the component when disabled")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "MenuHighlight")]
        public Color BorderHoverColor { get; set; }

        [Category("Border Color"),
         Description("The background color of the component when disabled")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "0, 84, 153")]
        public Color BorderMouseDownColor { get; set; }

        private Padding _borderSize;
        [Category("Border Color")]
        [DefaultValue(typeof(Padding), "1,1,1,1")]
        public Padding BorderSize
        {
            get { return _borderSize; }
            set
            {
                _borderSize = value;
                border.Padding = _borderSize;
            }
        }
        [Category("Border Color"),
         Description("The background color of the component when disabled")]
        [Browsable(true)]
        [DefaultValue(typeof(Color), "0, 120, 215")]
        public Color BorderFocusColor { get; set; }

        [Category("Border Color")]
        [DefaultValue(typeof(Padding), "2,2,2,2")]
        public Padding BorderFocusSize { get; set; }

        #endregion



        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override string Text
        {
            get { return base.Text; }
            set { label1.Text =  base.Text = value; }
        }
       

        //public new bool Enabled
        //{
        //    get
        //    {
        //        return this.Enabled;
        //    }
        //    set
        //    {
        //        this.Enabled = value;
        //        border.BackColor = this.Enabled ? BackColor : BackDisabledColor;
        //    }
        //}


        private void usrButtonColor_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(0, 122, 204);
            //this.BackDisabledColor = Color.LightGray;
            //this.OnColor = Color.FromArgb(0, 122, 204);

            //btnColor.BackColor = BackColor;
            if (!this.Enabled)
            {
                btnColor.BackColor = BackDisabledColor;
                label1.ForeColor = ForeDisabledColor;
                btnColor.ForeColor = ForeDisabledColor;
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            if (!this.Enabled)
                return;

            BtnClick?.Invoke(sender, e);
        }


        private void btnColor_MouseLeave(object sender, EventArgs e)
        {
            if (this.Enabled)
            {

                btnColor.BackColor = BackColor;
                border.BackColor = !this.Focused ? BorderColor : !BorderFocusColor.IsEmpty ? BorderFocusColor : BorderColor;
                label1.ForeColor = ForeColor;
                //this.Padding = !this.Focused ? BorderSize : BorderFocusSize;
            }
            

            //this.label1.Font = new Font(this.label1.Font.FontFamily, label1.Font.Size);
        }

        private void usrButtonColor_EnabledChanged(object sender, EventArgs e)
        {
            btnColor.BackColor = this.Enabled ? BackColor : BackDisabledColor;
            //border.BackColor = this.Enabled ? BorderColor : border
            label1.ForeColor = this.Enabled ? ForeColor : ForeDisabledColor;
        }

        private void btnColor_MouseEnter(object sender, EventArgs e)
        {
            if (this.Enabled)
            {
                border.BackColor = !BorderHoverColor.IsEmpty ? BorderHoverColor : border.BackColor; ;
                btnColor.BackColor = !HoverColor.IsEmpty ? HoverColor : btnColor.BackColor;
                label1.ForeColor = !ForeHoverColor.IsEmpty ? ForeHoverColor : label1.ForeColor;
            }

            //this.label1.Font = new Font(this.label1.Font.FontFamily, label1.Font.Size, FontStyle.Italic);
        }

        private void btnColor_MouseDown(object sender, MouseEventArgs e)
        {
            if (this.Enabled)
            {
                btnColor.BackColor = !MouseDownColor.IsEmpty ? MouseDownColor : btnColor.BackColor; ;
                border.BackColor = !BorderMouseDownColor.IsEmpty ? BorderMouseDownColor : btnColor.BackColor;
                label1.ForeColor = !ForeMouseDownColor.IsEmpty ? ForeMouseDownColor : label1.ForeColor;
            }
        }

        private void btnColor_MouseUp(object sender, MouseEventArgs e)
        {
            if (this.Enabled)
            {
                btnColor.BackColor = !HoverColor.IsEmpty ? HoverColor : btnColor.BackColor;
                border.BackColor = !BorderHoverColor.IsEmpty ? BorderHoverColor : border.BackColor;
                label1.ForeColor = !ForeHoverColor.IsEmpty ? ForeHoverColor : label1.ForeColor;
            }

            //Focused = true;
        }
        
    }


}
