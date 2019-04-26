using Winform_Custom_Controls.Inherits;

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
            this.threeWayCheckBox1 = new Winform_Custom_Controls.UserControls.ThreeWayCheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new Winform_Custom_Controls.Inherits.TextBox();
            this.cTextBox1 = new Winform_Custom_Controls.Inherits.CTextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.flatButton1 = new Winform_Custom_Controls.Inherits.FlatButton();
            this.usrButtonTest1 = new Winform_Custom_Controls.Inherits.usrButtonTest();
            this.colorizeButton1 = new Winform_Custom_Controls.UserControls.ColorizeButton();
            this.imageButton1 = new Winform_Custom_Controls.Inherits.ImageButton();
            this.imageTabButton1 = new Winform_Custom_Controls.UserControls.ImageTabButton();
            this.tabButton1 = new Winform_Custom_Controls.UserControls.TabButton();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton1)).BeginInit();
            this.SuspendLayout();
            // 
            // _textCheckBox1
            // 
            this._textCheckBox1.AutoIncreaseSize = true;
            this._textCheckBox1.Checked = false;
            this._textCheckBox1.FalseText = "No";
            this._textCheckBox1.Location = new System.Drawing.Point(12, 33);
            this._textCheckBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this._textCheckBox1.MultiLine = false;
            this._textCheckBox1.Name = "_textCheckBox1";
            this._textCheckBox1.Size = new System.Drawing.Size(88, 21);
            this._textCheckBox1.TabIndex = 0;
            this._textCheckBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this._textCheckBox1.TrueText = "Yes";
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(12, 12);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(86, 16);
            this.checkBox1.TabIndex = 1;
            this.checkBox1.Text = "checkBox1";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // threeWayCheckBox1
            // 
            this.threeWayCheckBox1.AutoIncreaseSize = true;
            this.threeWayCheckBox1.BackColor = System.Drawing.SystemColors.Window;
            this.threeWayCheckBox1.FirstState = "Yes";
            this.threeWayCheckBox1.Location = new System.Drawing.Point(12, 59);
            this.threeWayCheckBox1.Name = "threeWayCheckBox1";
            this.threeWayCheckBox1.ReadOnly = true;
            this.threeWayCheckBox1.SecondState = "No";
            this.threeWayCheckBox1.Size = new System.Drawing.Size(88, 21);
            this.threeWayCheckBox1.TabIndex = 2;
            this.threeWayCheckBox1.Text = "Yes";
            this.threeWayCheckBox1.ThirdState = "None";
            this.threeWayCheckBox1.Value = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(117, 7);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.BorderFocusColor = System.Drawing.Color.Maroon;
            this.textBox2.Location = new System.Drawing.Point(117, 60);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 4;
            // 
            // cTextBox1
            // 
            this.cTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.cTextBox1.BorderFocusColor = System.Drawing.SystemColors.Highlight;
            this.cTextBox1.Location = new System.Drawing.Point(117, 33);
            this.cTextBox1.Name = "cTextBox1";
            this.cTextBox1.Size = new System.Drawing.Size(100, 21);
            this.cTextBox1.TabIndex = 5;
            this.cTextBox1.WaterMark = "Default Watermark...";
            this.cTextBox1.WaterMarkActiveForeColor = System.Drawing.Color.Gray;
            this.cTextBox1.WaterMarkFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cTextBox1.WaterMarkForeColor = System.Drawing.Color.LightGray;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(240, 5);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 6;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // flatButton1
            // 
            this.flatButton1.BackColor = System.Drawing.Color.DodgerBlue;
            this.flatButton1.ForeColor = System.Drawing.Color.White;
            this.flatButton1.Location = new System.Drawing.Point(240, 31);
            this.flatButton1.Name = "flatButton1";
            this.flatButton1.OnHoverBackColor = System.Drawing.Color.DarkOrchid;
            this.flatButton1.Size = new System.Drawing.Size(75, 23);
            this.flatButton1.TabIndex = 7;
            this.flatButton1.Text = "flatButton1";
            this.flatButton1.UseVisualStyleBackColor = false;
            // 
            // usrButtonTest1
            // 
            this.usrButtonTest1.BackColor = System.Drawing.SystemColors.Window;
            this.usrButtonTest1.Location = new System.Drawing.Point(240, 84);
            this.usrButtonTest1.Name = "usrButtonTest1";
            this.usrButtonTest1.Size = new System.Drawing.Size(75, 23);
            this.usrButtonTest1.TabIndex = 8;
            this.usrButtonTest1.Text = "usrButtonTest1";
            this.usrButtonTest1.UseVisualStyleBackColor = false;
            // 
            // colorizeButton1
            // 
            this.colorizeButton1.BackDisabledColor = System.Drawing.Color.Empty;
            this.colorizeButton1.Location = new System.Drawing.Point(240, 60);
            this.colorizeButton1.Margin = new System.Windows.Forms.Padding(0);
            this.colorizeButton1.Name = "colorizeButton1";
            this.colorizeButton1.Size = new System.Drawing.Size(100, 21);
            this.colorizeButton1.TabIndex = 9;
            this.colorizeButton1.Text = "colorizeButton1";
            // 
            // imageButton1
            // 
            this.imageButton1.Location = new System.Drawing.Point(240, 113);
            this.imageButton1.Name = "imageButton1";
            this.imageButton1.Size = new System.Drawing.Size(100, 50);
            this.imageButton1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imageButton1.TabIndex = 10;
            this.imageButton1.TabStop = false;
            // 
            // imageTabButton1
            // 
            this.imageTabButton1.BackColor = System.Drawing.Color.Transparent;
            this.imageTabButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imageTabButton1.BaseImage = null;
            this.imageTabButton1.CheckImage = null;
            this.imageTabButton1.Location = new System.Drawing.Point(492, 235);
            this.imageTabButton1.Margin = new System.Windows.Forms.Padding(0);
            this.imageTabButton1.Name = "imageTabButton1";
            this.imageTabButton1.Selected = false;
            this.imageTabButton1.Size = new System.Drawing.Size(100, 50);
            this.imageTabButton1.TabIndex = 11;
            this.imageTabButton1.Title = "";
            // 
            // tabButton1
            // 
            this.tabButton1.BackColor = System.Drawing.Color.Black;
            this.tabButton1.Location = new System.Drawing.Point(240, 166);
            this.tabButton1.Margin = new System.Windows.Forms.Padding(0);
            this.tabButton1.Name = "tabButton1";
            this.tabButton1.NextButton = null;
            this.tabButton1.Padding = new System.Windows.Forms.Padding(1);
            this.tabButton1.PrevButton = null;
            this.tabButton1.Size = new System.Drawing.Size(100, 50);
            this.tabButton1.TabIndex = 12;
            this.tabButton1.Text = "tabButton1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabButton1);
            this.Controls.Add(this.imageTabButton1);
            this.Controls.Add(this.imageButton1);
            this.Controls.Add(this.colorizeButton1);
            this.Controls.Add(this.usrButtonTest1);
            this.Controls.Add(this.flatButton1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cTextBox1);
            this.Controls.Add(this.textBox2);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.threeWayCheckBox1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this._textCheckBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.imageButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Winform_Custom_Controls.UserControls.TextCheckBox _textCheckBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private Winform_Custom_Controls.UserControls.ThreeWayCheckBox threeWayCheckBox1;
        private System.Windows.Forms.TextBox textBox1;
        private Winform_Custom_Controls.Inherits.TextBox textBox2;
        private Winform_Custom_Controls.Inherits.CTextBox cTextBox1;
        private System.Windows.Forms.Button button1;
        private Winform_Custom_Controls.Inherits.FlatButton flatButton1;
        private Winform_Custom_Controls.Inherits.usrButtonTest usrButtonTest1;
        private Winform_Custom_Controls.UserControls.ColorizeButton colorizeButton1;
        private ImageButton imageButton1;
        private Winform_Custom_Controls.UserControls.ImageTabButton imageTabButton1;
        private Winform_Custom_Controls.UserControls.TabButton tabButton1;
    }
}

