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
            this.components = new System.ComponentModel.Container();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker2 = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.test1ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.test2ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.splitButton1 = new Winform_Custom_Controls.Inherits.SplitButton();
            this.checkBoxListView1 = new Winform_Custom_Controls.Inherits.CheckBoxListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader3 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.ContentLabel2 = new Winform_Custom_Controls.Inherits.ContentLabel();
            this.ContentLabel1 = new Winform_Custom_Controls.Inherits.ContentLabel();
            this.colorizeButtonTest2 = new Winform_Custom_Controls.Inherits.ColorizeButton();
            this.textBox10 = new Winform_Custom_Controls.Inherits.TextBox();
            this.textBox9 = new Winform_Custom_Controls.Inherits.TextBox();
            this.colorizeButtonTest1 = new Winform_Custom_Controls.Inherits.ColorizeButton();
            this.textBox8 = new Winform_Custom_Controls.Inherits.TextBox();
            this.textBox7 = new Winform_Custom_Controls.Inherits.TextBox();
            this.textBox6 = new Winform_Custom_Controls.Inherits.TextBox();
            this.textBox5 = new Winform_Custom_Controls.Inherits.TextBox();
            this.dateTimePicker1 = new Winform_Custom_Controls.Inherits.DateTimePicker();
            this.tabButton1 = new Winform_Custom_Controls.UserControls.CtrlTabButton();
            this.imageTabButton1 = new Winform_Custom_Controls.UserControls.CtrlImageTabButton();
            this.imageButton1 = new Winform_Custom_Controls.Inherits.ImageButton();
            this.colorizeButton1 = new Winform_Custom_Controls.UserControls.CtrlColorizeButton();
            this.usrButtonTest1 = new Winform_Custom_Controls.Inherits.usrButtonTest();
            this.flatButton1 = new Winform_Custom_Controls.Inherits.FlatButton();
            this.cTextBox1 = new Winform_Custom_Controls.Inherits.CTextBox();
            this.textBox2 = new Winform_Custom_Controls.Inherits.TextBox();
            this.threeWayCheckBox1 = new Winform_Custom_Controls.UserControls.ThreeWayCheckBox();
            this._textCheckBox1 = new Winform_Custom_Controls.UserControls.CtrlTextCheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.contextMenuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imageButton1)).BeginInit();
            this.SuspendLayout();
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
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(117, 33);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(100, 21);
            this.textBox1.TabIndex = 3;
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
            // dateTimePicker2
            // 
            this.dateTimePicker2.Location = new System.Drawing.Point(480, 60);
            this.dateTimePicker2.Name = "dateTimePicker2";
            this.dateTimePicker2.Size = new System.Drawing.Size(201, 21);
            this.dateTimePicker2.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(115, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 12);
            this.label1.TabIndex = 15;
            this.label1.Text = "Default TextBox";
            // 
            // textBox3
            // 
            this.textBox3.Location = new System.Drawing.Point(117, 59);
            this.textBox3.Name = "textBox3";
            this.textBox3.ReadOnly = true;
            this.textBox3.Size = new System.Drawing.Size(100, 21);
            this.textBox3.TabIndex = 16;
            this.textBox3.Text = "Readonly";
            // 
            // textBox4
            // 
            this.textBox4.Enabled = false;
            this.textBox4.Location = new System.Drawing.Point(117, 86);
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(100, 21);
            this.textBox4.TabIndex = 17;
            this.textBox4.Text = "Disabled";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(115, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 12);
            this.label2.TabIndex = 18;
            this.label2.Text = "Customize TextBox";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(573, 292);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(126, 23);
            this.button2.TabIndex = 24;
            this.button2.Text = "button2";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(569, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 133);
            this.label3.TabIndex = 28;
            this.label3.Text = "label3tttttttttttttttttttttttt";
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.test1ToolStripMenuItem,
            this.test2ToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(101, 48);
            // 
            // test1ToolStripMenuItem
            // 
            this.test1ToolStripMenuItem.Name = "test1ToolStripMenuItem";
            this.test1ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.test1ToolStripMenuItem.Text = "test1";
            // 
            // test2ToolStripMenuItem
            // 
            this.test2ToolStripMenuItem.Name = "test2ToolStripMenuItem";
            this.test2ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.test2ToolStripMenuItem.Text = "test2";
            // 
            // splitButton1
            // 
            this.splitButton1.ClickedImage = "Clicked";
            this.splitButton1.ContextMenuStrip = this.contextMenuStrip1;
            this.splitButton1.DisabledImage = "Disabled";
            this.splitButton1.FocusedImage = "Focused";
            this.splitButton1.HoverImage = "Hover";
            this.splitButton1.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.splitButton1.ImageKey = "Normal";
            this.splitButton1.Location = new System.Drawing.Point(593, 365);
            this.splitButton1.Name = "splitButton1";
            this.splitButton1.NormalImage = "Normal";
            this.splitButton1.Size = new System.Drawing.Size(163, 23);
            this.splitButton1.TabIndex = 32;
            this.splitButton1.Text = "splitButton1";
            this.splitButton1.UseVisualStyleBackColor = true;
            // 
            // checkBoxListView1
            // 
            this.checkBoxListView1.CheckBoxes = true;
            this.checkBoxListView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2,
            this.columnHeader3});
            this.checkBoxListView1.FullRowSelect = true;
            this.checkBoxListView1.HideSelection = false;
            this.checkBoxListView1.Location = new System.Drawing.Point(311, 274);
            this.checkBoxListView1.Name = "checkBoxListView1";
            this.checkBoxListView1.OwnerDraw = true;
            this.checkBoxListView1.Size = new System.Drawing.Size(210, 164);
            this.checkBoxListView1.TabIndex = 31;
            this.checkBoxListView1.UseCompatibleStateImageBehavior = false;
            this.checkBoxListView1.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 25;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "col1";
            // 
            // columnHeader3
            // 
            this.columnHeader3.Text = "col2";
            // 
            // ContentLabel2
            // 
            this.ContentLabel2.AutoSize = true;
            this.ContentLabel2.Font = new System.Drawing.Font("굴림", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ContentLabel2.IsRequire = true;
            this.ContentLabel2.Location = new System.Drawing.Point(446, 179);
            this.ContentLabel2.Name = "ContentLabel2";
            this.ContentLabel2.Size = new System.Drawing.Size(230, 19);
            this.ContentLabel2.TabIndex = 30;
            this.ContentLabel2.Text = "ContentLabel15555555555 ";
            // 
            // ContentLabel1
            // 
            this.ContentLabel1.Font = new System.Drawing.Font("굴림", 13F);
            this.ContentLabel1.IsRequire = true;
            this.ContentLabel1.Location = new System.Drawing.Point(445, 89);
            this.ContentLabel1.Name = "ContentLabel1";
            this.ContentLabel1.Size = new System.Drawing.Size(100, 125);
            this.ContentLabel1.TabIndex = 29;
            this.ContentLabel1.Text = "ContentLabel15555555555 ";
            // 
            // colorizeButtonTest2
            // 
            this.colorizeButtonTest2.BorderFocusCuesColor = System.Drawing.Color.Red;
            this.colorizeButtonTest2.BorderHoverSize = new System.Windows.Forms.Padding(4);
            this.colorizeButtonTest2.BorderSize = new System.Windows.Forms.Padding(4);
            this.colorizeButtonTest2.Location = new System.Drawing.Point(573, 263);
            this.colorizeButtonTest2.Name = "colorizeButtonTest2";
            this.colorizeButtonTest2.Size = new System.Drawing.Size(126, 23);
            this.colorizeButtonTest2.TabIndex = 27;
            this.colorizeButtonTest2.Text = "colorizeButton";
            this.colorizeButtonTest2.UseVisualStyleBackColor = true;
            // 
            // textBox10
            // 
            this.textBox10.BackColor = System.Drawing.SystemColors.Window;
            this.textBox10.BorderFocusColor = System.Drawing.Color.Maroon;
            this.textBox10.Location = new System.Drawing.Point(117, 318);
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(100, 21);
            this.textBox10.TabIndex = 26;
            this.textBox10.TextMode = Winform_Custom_Controls.enums.TextMode.Currency;
            // 
            // textBox9
            // 
            this.textBox9.BackColor = System.Drawing.SystemColors.Window;
            this.textBox9.BorderFocusColor = System.Drawing.Color.Maroon;
            this.textBox9.Location = new System.Drawing.Point(117, 155);
            this.textBox9.Name = "textBox9";
            this.textBox9.Size = new System.Drawing.Size(100, 21);
            this.textBox9.TabIndex = 25;
            this.textBox9.TextMode = Winform_Custom_Controls.enums.TextMode.Number;
            // 
            // colorizeButtonTest1
            // 
            this.colorizeButtonTest1.BorderFocusCuesColor = System.Drawing.Color.Red;
            this.colorizeButtonTest1.BorderHoverSize = new System.Windows.Forms.Padding(4);
            this.colorizeButtonTest1.BorderSize = new System.Windows.Forms.Padding(4);
            this.colorizeButtonTest1.Location = new System.Drawing.Point(240, 219);
            this.colorizeButtonTest1.Name = "colorizeButtonTest1";
            this.colorizeButtonTest1.Size = new System.Drawing.Size(126, 23);
            this.colorizeButtonTest1.TabIndex = 23;
            this.colorizeButtonTest1.Text = "colorizeButtonTest1";
            this.colorizeButtonTest1.UseVisualStyleBackColor = true;
            // 
            // textBox8
            // 
            this.textBox8.BackColor = System.Drawing.SystemColors.Window;
            this.textBox8.BackDisabledColor = System.Drawing.Color.MistyRose;
            this.textBox8.BorderFocusColor = System.Drawing.Color.Maroon;
            this.textBox8.Enabled = false;
            this.textBox8.Location = new System.Drawing.Point(117, 263);
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(100, 21);
            this.textBox8.TabIndex = 22;
            this.textBox8.Text = "Disabled 2";
            // 
            // textBox7
            // 
            this.textBox7.BackColor = System.Drawing.Color.MistyRose;
            this.textBox7.BackReadOnlyColor = System.Drawing.Color.MistyRose;
            this.textBox7.BorderFocusColor = System.Drawing.Color.Maroon;
            this.textBox7.Location = new System.Drawing.Point(117, 209);
            this.textBox7.Name = "textBox7";
            this.textBox7.ReadOnly = true;
            this.textBox7.Size = new System.Drawing.Size(100, 21);
            this.textBox7.TabIndex = 21;
            this.textBox7.Text = "Readonly 2";
            // 
            // textBox6
            // 
            this.textBox6.BackColor = System.Drawing.SystemColors.Window;
            this.textBox6.BorderFocusColor = System.Drawing.Color.Maroon;
            this.textBox6.Enabled = false;
            this.textBox6.Location = new System.Drawing.Point(117, 236);
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(100, 21);
            this.textBox6.TabIndex = 20;
            this.textBox6.Text = "Disabled";
            // 
            // textBox5
            // 
            this.textBox5.BackColor = System.Drawing.SystemColors.Control;
            this.textBox5.BorderFocusColor = System.Drawing.Color.Maroon;
            this.textBox5.Location = new System.Drawing.Point(117, 182);
            this.textBox5.Name = "textBox5";
            this.textBox5.ReadOnly = true;
            this.textBox5.Size = new System.Drawing.Size(100, 21);
            this.textBox5.TabIndex = 19;
            this.textBox5.Text = "Readonly";
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.Location = new System.Drawing.Point(481, 28);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(200, 21);
            this.dateTimePicker1.TabIndex = 13;
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
            // imageTabButton1
            // 
            this.imageTabButton1.BackColor = System.Drawing.Color.Transparent;
            this.imageTabButton1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.imageTabButton1.BaseImage = null;
            this.imageTabButton1.CheckImage = null;
            this.imageTabButton1.Location = new System.Drawing.Point(573, 207);
            this.imageTabButton1.Margin = new System.Windows.Forms.Padding(0);
            this.imageTabButton1.Name = "imageTabButton1";
            this.imageTabButton1.Selected = false;
            this.imageTabButton1.Size = new System.Drawing.Size(100, 50);
            this.imageTabButton1.TabIndex = 11;
            this.imageTabButton1.Title = "";
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
            // cTextBox1
            // 
            this.cTextBox1.BackColor = System.Drawing.SystemColors.Window;
            this.cTextBox1.BorderFocusColor = System.Drawing.SystemColors.Highlight;
            this.cTextBox1.Location = new System.Drawing.Point(117, 291);
            this.cTextBox1.Name = "cTextBox1";
            this.cTextBox1.Size = new System.Drawing.Size(100, 21);
            this.cTextBox1.TabIndex = 5;
            this.cTextBox1.WaterMark = "Default Watermark...";
            this.cTextBox1.WaterMarkActiveForeColor = System.Drawing.Color.Gray;
            this.cTextBox1.WaterMarkFont = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cTextBox1.WaterMarkForeColor = System.Drawing.Color.LightGray;
            // 
            // textBox2
            // 
            this.textBox2.BackColor = System.Drawing.SystemColors.Window;
            this.textBox2.BorderFocusColor = System.Drawing.Color.Maroon;
            this.textBox2.Location = new System.Drawing.Point(117, 128);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(100, 21);
            this.textBox2.TabIndex = 4;
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
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "121",
            "12131`"});
            this.comboBox1.Location = new System.Drawing.Point(419, 221);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(144, 20);
            this.comboBox1.TabIndex = 34;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.splitButton1);
            this.Controls.Add(this.checkBoxListView1);
            this.Controls.Add(this.ContentLabel2);
            this.Controls.Add(this.ContentLabel1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.colorizeButtonTest2);
            this.Controls.Add(this.textBox10);
            this.Controls.Add(this.textBox9);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.colorizeButtonTest1);
            this.Controls.Add(this.textBox8);
            this.Controls.Add(this.textBox7);
            this.Controls.Add(this.textBox6);
            this.Controls.Add(this.textBox5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBox4);
            this.Controls.Add(this.textBox3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dateTimePicker2);
            this.Controls.Add(this.dateTimePicker1);
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
            this.contextMenuStrip1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imageButton1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Winform_Custom_Controls.UserControls.CtrlTextCheckBox _textCheckBox1;
        private System.Windows.Forms.CheckBox checkBox1;
        private Winform_Custom_Controls.UserControls.ThreeWayCheckBox threeWayCheckBox1;
        private System.Windows.Forms.TextBox textBox1;
        private Winform_Custom_Controls.Inherits.TextBox textBox2;
        private Winform_Custom_Controls.Inherits.CTextBox cTextBox1;
        private System.Windows.Forms.Button button1;
        private Winform_Custom_Controls.Inherits.FlatButton flatButton1;
        private Winform_Custom_Controls.Inherits.usrButtonTest usrButtonTest1;
        private Winform_Custom_Controls.UserControls.CtrlColorizeButton colorizeButton1;
        private ImageButton imageButton1;
        private Winform_Custom_Controls.UserControls.CtrlTabButton tabButton1;
        private DateTimePicker dateTimePicker1;
        private System.Windows.Forms.DateTimePicker dateTimePicker2;
        private Winform_Custom_Controls.UserControls.CtrlImageTabButton imageTabButton1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.Label label2;
        private TextBox textBox5;
        private TextBox textBox6;
        private TextBox textBox7;
        private TextBox textBox8;
        private ColorizeButton colorizeButtonTest1;
        private System.Windows.Forms.Button button2;
        private TextBox textBox9;
        private TextBox textBox10;
        private ColorizeButton colorizeButtonTest2;
        private System.Windows.Forms.Label label3;
        private ContentLabel ContentLabel1;
        private ContentLabel ContentLabel2;
        private CheckBoxListView checkBoxListView1;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.ColumnHeader columnHeader3;
        private SplitButton splitButton1;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem test1ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem test2ToolStripMenuItem;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}

