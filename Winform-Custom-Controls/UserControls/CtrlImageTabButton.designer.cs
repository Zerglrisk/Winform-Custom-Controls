namespace Winform_Custom_Controls.UserControls
{
    partial class CtrlImageTabButton
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
            this.btnBase = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnBase
            // 
            this.btnBase.BackColor = System.Drawing.Color.Transparent;
            this.btnBase.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBase.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnBase.FlatAppearance.BorderSize = 0;
            this.btnBase.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBase.Location = new System.Drawing.Point(0, 0);
            this.btnBase.Margin = new System.Windows.Forms.Padding(0);
            this.btnBase.Name = "btnBase";
            this.btnBase.Size = new System.Drawing.Size(100, 50);
            this.btnBase.TabIndex = 0;
            this.btnBase.UseVisualStyleBackColor = false;
            this.btnBase.Click += new System.EventHandler(this.btnBase_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(-2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "label1";
            // 
            // ImageTabButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnBase);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "ImageTabButton";
            this.Size = new System.Drawing.Size(100, 50);
            this.Load += new System.EventHandler(this.usrTabButton_Load);
            this.Click += new System.EventHandler(this.usrTabButton_Click);
            this.Resize += new System.EventHandler(this.usrTabButton_Resize);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnBase;
        private System.Windows.Forms.Label label1;
    }
}
