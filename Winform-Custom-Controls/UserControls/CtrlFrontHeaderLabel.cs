using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Winform_Custom_Controls.enums;

namespace TrueInfoUserControls
{
    public sealed partial class FrontHeaderLabel : UserControl
    {

        public FrontHeaderLabel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            
            ImageSizeMode = PictureBoxSizeMode.CenterImage;
            AutoSize = true;
            TextAlign = ContentAlignment.MiddleLeft;
            ImageSize = new Size(0, 0);
            HeaderType = FrontHeaderType.Image;
            HeaderText = "■";
        }

        private FrontHeaderType _headerType;
        [Category("Behavior"),Browsable(true),DefaultValue(typeof(FrontHeaderType), "Image")]
        public FrontHeaderType HeaderType
        {
            get => _headerType;
            set
            {
                switch (value)
                {
                    case FrontHeaderType.Image:
                        pictureBox1.Visible = true;
                        label_header.Visible = false;
                        break;
                    case FrontHeaderType.Text:
                        pictureBox1.Visible = false;
                        label_header.Visible = true;
                        break;
                    default:
                        break;
                        //throw new ArgumentOutOfRangeException(nameof(value), value, null);
                }

                _headerType = value;
                CheckAutoResize();
            } }

        [Category("HeaderText"), Browsable(true), DefaultValue("■")]
        public string HeaderText {
            get => label_header.Text;
            set { label_header.Text = value; CheckAutoResize(); }
        }
        [Category("HeaderText"), Browsable(true),DefaultValue(typeof(Font),null)]
        [AmbientValue(null)]
        public Font HeaderFont
        {
            get => label_header.Font;
            set => label_header.Font = value;
        }
        [Category("HeaderImage"), Browsable(true)]
        public Image Image
        {
            get => pictureBox1.Image;
            set
            {
                if (value != null)
                {
                    CheckAutoResize();
                }

                pictureBox1.Image = value;

                ImageSize = value?.Size ?? new Size(0,0);
            }
        }
        [Category("HeaderImage"), Browsable(true), DefaultValue(typeof(Size), "0, 0")]
        public Size ImageSize
        {
            get => pictureBox1.Size;
            set
            {
                CheckAutoResize();
                pictureBox1.Size = value;
            }
        }
        [Category("HeaderImage"), Browsable(true),DefaultValue(typeof(PictureBoxSizeMode),"CenterImage")]
        public PictureBoxSizeMode ImageSizeMode
        {
            get => pictureBox1.SizeMode;
            set => pictureBox1.SizeMode = value;
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        [EditorAttribute(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public override string Text
        {
            get => base.Text;
            set
            {
                base.Text = value;//value.Replace("\\n", Environment.NewLine);
                label.Text = base.Text;
                CheckAutoResize();
            }
        }
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public  override Font Font 
        { 
            get => base.Font;
            set 
            {
                base.Font = value; 
                label.Font = base.Font; CheckAutoResize();
            }
        }
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override Color ForeColor 
        { 
            get => base.ForeColor;
            set 
            { 
                base.ForeColor = value;
                label.ForeColor = base.ForeColor;
            }
        }

        [DefaultValue(true)]
        public override bool AutoSize { get; set; }

        private ContentAlignment _textAlign;
        [Category("Appearance"),DefaultValue(typeof(ContentAlignment), "MiddleLeft")]
        public ContentAlignment TextAlign
        {
            get => _textAlign;
            set => label.TextAlign = _textAlign = value;
        }
        private void CheckAutoResize()
        {
            //if (!AutoSize)
            //{
            //    if (this.Width < TextRenderer.MeasureText(label.Text, label.Font).Width + pictureBoxSize.Width)
            //    {
            //        this.Width = TextRenderer.MeasureText(label.Text, label.Font).Width + pictureBoxSize.Width;
            //    }

            //    var nowHeight = TextRenderer.MeasureText(label.Text, label.Font).Height > pictureBoxSize.Height
            //        ? TextRenderer.MeasureText(label.Text, label.Font).Height
            //        : pictureBoxSize.Height;
            //    if (this.Height < nowHeight)
            //    {
            //        this.Height = nowHeight;
            //    }
            //}
            //else
            //{
            //    this.Width = TextRenderer.MeasureText(label.Text, label.Font).Width + pictureBoxSize.Width;

            //    this.Height = TextRenderer.MeasureText(label.Text, label.Font).Height > pictureBoxSize.Height
            //        ? TextRenderer.MeasureText(label.Text, label.Font).Height
            //        : pictureBoxSize.Height;
            //}
            if (!AutoSize) return;
            if (HeaderType == FrontHeaderType.Image)
            {
                this.Width = TextRenderer.MeasureText(label.Text, label.Font).Width + pictureBox1.Size.Width;

                this.Height = TextRenderer.MeasureText(label.Text, label.Font).Height > pictureBox1.Size.Height
                    ? TextRenderer.MeasureText(label.Text, label.Font).Height
                    : pictureBox1.Size.Height;
            }
            else if (HeaderType == FrontHeaderType.Text)
            {
                this.Width = TextRenderer.MeasureText(label.Text, label.Font).Width + TextRenderer.MeasureText(label_header.Text, label_header.Font).Width;

                this.Height = TextRenderer.MeasureText(label.Text, label.Font).Height > TextRenderer.MeasureText(label_header.Text, label_header.Font).Height
                    ? TextRenderer.MeasureText(label.Text, label.Font).Height
                    : TextRenderer.MeasureText(label_header.Text, label_header.Font).Height;
            }

            this.PerformAutoScale();
        }

        private void usrLabelWithDot_AutoSizeChanged(object sender, EventArgs e)
        {
            CheckAutoResize();
        }

        private void FrontHeaderLabel_SizeChanged(object sender, EventArgs e)
        {
            CheckAutoResize();
        }
    }
}
