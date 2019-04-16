namespace Winform_Custom_Controls.UserControls
{
    partial class ImageButton
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
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마십시오.
        /// </summary>
        private void InitializeComponent()
        {
            this.picButton = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.picButton)).BeginInit();
            this.SuspendLayout();
            // 
            // picButton
            // 
            this.picButton.BackColor = System.Drawing.Color.Transparent;
            this.picButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.picButton.Location = new System.Drawing.Point(0, 0);
            this.picButton.Margin = new System.Windows.Forms.Padding(0);
            this.picButton.Name = "picButton";
            this.picButton.Size = new System.Drawing.Size(100, 50);
            this.picButton.TabIndex = 0;
            this.picButton.TabStop = false;
            this.picButton.Click += new System.EventHandler(this.picButton_Click);
            this.picButton.MouseDown += new System.Windows.Forms.MouseEventHandler(this.picButton_MouseDown);
            this.picButton.MouseLeave += new System.EventHandler(this.picButton_MouseLeave);
            this.picButton.MouseHover += new System.EventHandler(this.picButton_MouseHover);
            this.picButton.MouseMove += new System.Windows.Forms.MouseEventHandler(this.picButton_MouseMove);
            this.picButton.MouseUp += new System.Windows.Forms.MouseEventHandler(this.picButton_MouseUp);
            // 
            // ImageButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.picButton);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ImageButton";
            this.Size = new System.Drawing.Size(100, 50);
            this.EnabledChanged += new System.EventHandler(this.usrButton_EnabledChanged);
            ((System.ComponentModel.ISupportInitialize)(this.picButton)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox picButton;




    }
}
