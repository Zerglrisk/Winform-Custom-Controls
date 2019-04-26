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

namespace TrueInfoUserControls
{
    public partial class FrontHeaderLabel : UserControl
    {

        public FrontHeaderLabel()
        {
            InitializeComponent();
            this.DoubleBuffered = true;
            

            ImageSizeMode = PictureBoxSizeMode.CenterImage;
            AutoSize = true;
            TextAlign = ContentAlignment.MiddleLeft;
            ImageSize = new Size(0, 0);
        }
        [Category("DotImages"), Browsable(true)]
        public Image Image
        {
            get { return pictureBox1.Image; }
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
        [Category("DotImages"), Browsable(true), DefaultValue(typeof(Size), "0, 0")]
        public Size ImageSize
        {
            get { return pictureBox1.Size; }
            set
            {
                CheckAutoResize();
                pictureBox1.Size = value;
            }
        }
        [Category("DotImages"), Browsable(true),DefaultValue(typeof(PictureBoxSizeMode),"CenterImage")]
        public PictureBoxSizeMode ImageSizeMode
        {
            get { return pictureBox1.SizeMode; }
            set { pictureBox1.SizeMode = value; }
        }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        [EditorAttribute(typeof(MultilineStringEditor), typeof(System.Drawing.Design.UITypeEditor))]
        public override string Text
        {
            get { return base.Text; }
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
        public  override Font Font { get { return base.Font; } set { base.Font = value;
            label.Font = base.Font; CheckAutoResize();
            } }
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Bindable(true)]
        public override Color ForeColor { get { return base.ForeColor; } set { base.ForeColor = value;
            label.ForeColor = base.ForeColor;
        } }

        [DefaultValue(true)]
        public override bool AutoSize { get; set; }

        private ContentAlignment _textAlign;
        [Category("Appearance"),DefaultValue(typeof(ContentAlignment), "MiddleLeft")]
        public ContentAlignment TextAlign
        {
            get { return _textAlign; }
            set { label.TextAlign = _textAlign = value; }
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
            this.Width = TextRenderer.MeasureText(label.Text, label.Font).Width + pictureBox1.Size.Width;

                this.Height = TextRenderer.MeasureText(label.Text, label.Font).Height > pictureBox1.Size.Height
                    ? TextRenderer.MeasureText(label.Text, label.Font).Height
                    : pictureBox1.Size.Height;
            this.PerformAutoScale();
        }

        private void usrLabelWithDot_AutoSizeChanged(object sender, EventArgs e)
        {
            CheckAutoResize();
        }

        private void ChildControls_MouseDown(object sender, MouseEventArgs e)
        {
            //UserControl 이벤트와 연결
            this.OnMouseDown(e);
        }

        private void ChildControls_MouseMove(object sender, MouseEventArgs e)
        {
            //UserControl 이벤트와 연결
            this.OnMouseMove(e);
        }
        
    }
}
