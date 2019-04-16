namespace Example
{
    partial class Form1
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

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this._textCheckBox1 = new Winform_Custom_Controls.UserControls.TextCheckBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // _textCheckBox1
            // 
            this._textCheckBox1.AutoIncreaseSize = true;
            this._textCheckBox1.Checked = false;
            this._textCheckBox1.FalseText = "No";
            this._textCheckBox1.Location = new System.Drawing.Point(391, 191);
            this._textCheckBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._textCheckBox1.MultiLine = false;
            this._textCheckBox1.Name = "_textCheckBox1";
            this._textCheckBox1.Size = new System.Drawing.Size(88, 20);
            this._textCheckBox1.TabIndex = 0;
            this._textCheckBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._textCheckBox1.TrueText = "Yes";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(391, 170);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this._textCheckBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Winform_Custom_Controls.UserControls.TextCheckBox _textCheckBox1;
        private System.Windows.Forms.CheckBox checkBox1;
    }
}

