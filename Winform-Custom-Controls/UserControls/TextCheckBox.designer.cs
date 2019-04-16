namespace Winform_Custom_Controls.UserControls
{
    partial class TextCheckBox
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
            this.txt_Shown = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_Shown
            // 
            this.txt_Shown.BackColor = System.Drawing.SystemColors.Window;
            this.txt_Shown.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_Shown.Location = new System.Drawing.Point(0, 0);
            this.txt_Shown.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.txt_Shown.Name = "txt_Shown";
            this.txt_Shown.ReadOnly = true;
            this.txt_Shown.Size = new System.Drawing.Size(88, 21);
            this.txt_Shown.TabIndex = 0;
            this.txt_Shown.Click += new System.EventHandler(this.txt_Shown_Click);
            this.txt_Shown.MouseDown += new System.Windows.Forms.MouseEventHandler(this.txt_Shown_MouseDown);
            this.txt_Shown.MouseEnter += new System.EventHandler(this.txt_Shown_MouseEnter);
            this.txt_Shown.MouseLeave += new System.EventHandler(this.txt_Shown_MouseLeave);
            // 
            // TextCheckBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.txt_Shown);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "TextCheckBox";
            this.Size = new System.Drawing.Size(88, 20);
            this.Resize += new System.EventHandler(this.usrCheckBox_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_Shown;
    }
}
