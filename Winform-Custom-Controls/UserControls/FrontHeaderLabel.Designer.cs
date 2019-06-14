using Winform_Custom_Controls.Inherits;
using Winform_Custom_Controls.UserControls;

namespace TrueInfoUserControls
{
    partial class FrontHeaderLabel
    {
        /// <summary> 
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 구성 요소 디자이너에서 생성한 코드

        /// <summary> 
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.label = new System.Windows.Forms.Label();
            this.label_header = new System.Windows.Forms.Label();
            this.pictureBox1 = new Winform_Custom_Controls.Inherits.ImageButton();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // label
            // 
            this.label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label.Location = new System.Drawing.Point(33, 0);
            this.label.Name = "label";
            this.label.Size = new System.Drawing.Size(72, 20);
            this.label.TabIndex = 4;
            this.label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_header
            // 
            this.label_header.Dock = System.Windows.Forms.DockStyle.Left;
            this.label_header.Location = new System.Drawing.Point(18, 0);
            this.label_header.Name = "label_header";
            this.label_header.Size = new System.Drawing.Size(15, 20);
            this.label_header.TabIndex = 5;
            this.label_header.Text = "■";
            this.label_header.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Dock = System.Windows.Forms.DockStyle.Left;
            this.pictureBox1.ImageSizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(18, 20);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pictureBox1.TabIndex = 1;
            this.pictureBox1.TabStop = false;
            // 
            // FrontHeaderLabel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label);
            this.Controls.Add(this.label_header);
            this.Controls.Add(this.pictureBox1);
            this.Name = "FrontHeaderLabel";
            this.Size = new System.Drawing.Size(105, 20);
            this.AutoSizeChanged += new System.EventHandler(this.usrLabelWithDot_AutoSizeChanged);
            this.SizeChanged += new System.EventHandler(this.FrontHeaderLabel_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private ImageButton pictureBox1;
        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Label label_header;
    }
}
