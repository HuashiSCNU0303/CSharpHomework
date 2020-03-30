namespace CayleyTree
{
    partial class Form1
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnStartDrawing = new System.Windows.Forms.Button();
            this.btnSelectColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.lblColorText = new System.Windows.Forms.Label();
            this.lblColor = new System.Windows.Forms.Label();
            this.trbRightRatio = new System.Windows.Forms.TrackBar();
            this.lblRightRatio = new System.Windows.Forms.Label();
            this.lblLeftRatio = new System.Windows.Forms.Label();
            this.trbLeftRatio = new System.Windows.Forms.TrackBar();
            this.lblDepth = new System.Windows.Forms.Label();
            this.txtDepth = new System.Windows.Forms.TextBox();
            this.lblLength = new System.Windows.Forms.Label();
            this.txtLength = new System.Windows.Forms.TextBox();
            this.lblRightAngle = new System.Windows.Forms.Label();
            this.lblLeftAngle = new System.Windows.Forms.Label();
            this.cmbRightAngle = new System.Windows.Forms.ComboBox();
            this.cmbLeftAngle = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.trbRightRatio)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLeftRatio)).BeginInit();
            this.SuspendLayout();
            // 
            // btnStartDrawing
            // 
            this.btnStartDrawing.Location = new System.Drawing.Point(529, 31);
            this.btnStartDrawing.Name = "btnStartDrawing";
            this.btnStartDrawing.Size = new System.Drawing.Size(95, 43);
            this.btnStartDrawing.TabIndex = 0;
            this.btnStartDrawing.Text = "开始绘画";
            this.btnStartDrawing.UseVisualStyleBackColor = true;
            this.btnStartDrawing.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnSelectColor
            // 
            this.btnSelectColor.Location = new System.Drawing.Point(407, 31);
            this.btnSelectColor.Name = "btnSelectColor";
            this.btnSelectColor.Size = new System.Drawing.Size(95, 42);
            this.btnSelectColor.TabIndex = 1;
            this.btnSelectColor.Text = "选择颜色";
            this.btnSelectColor.UseVisualStyleBackColor = true;
            this.btnSelectColor.Click += new System.EventHandler(this.button2_Click);
            // 
            // lblColorText
            // 
            this.lblColorText.AutoSize = true;
            this.lblColorText.Location = new System.Drawing.Point(154, 43);
            this.lblColorText.Name = "lblColorText";
            this.lblColorText.Size = new System.Drawing.Size(98, 18);
            this.lblColorText.TabIndex = 2;
            this.lblColorText.Text = "当前颜色：";
            // 
            // lblColor
            // 
            this.lblColor.AutoSize = true;
            this.lblColor.Location = new System.Drawing.Point(258, 43);
            this.lblColor.Name = "lblColor";
            this.lblColor.Size = new System.Drawing.Size(53, 18);
            this.lblColor.TabIndex = 3;
            this.lblColor.Text = "     ";
            // 
            // trbRightRatio
            // 
            this.trbRightRatio.Location = new System.Drawing.Point(222, 189);
            this.trbRightRatio.Name = "trbRightRatio";
            this.trbRightRatio.Size = new System.Drawing.Size(151, 69);
            this.trbRightRatio.TabIndex = 4;
            this.trbRightRatio.Value = 6;
            // 
            // lblRightRatio
            // 
            this.lblRightRatio.AutoSize = true;
            this.lblRightRatio.Location = new System.Drawing.Point(77, 200);
            this.lblRightRatio.Name = "lblRightRatio";
            this.lblRightRatio.Size = new System.Drawing.Size(116, 18);
            this.lblRightRatio.TabIndex = 5;
            this.lblRightRatio.Text = "右分支长度比";
            // 
            // lblLeftRatio
            // 
            this.lblLeftRatio.AutoSize = true;
            this.lblLeftRatio.Location = new System.Drawing.Point(437, 200);
            this.lblLeftRatio.Name = "lblLeftRatio";
            this.lblLeftRatio.Size = new System.Drawing.Size(116, 18);
            this.lblLeftRatio.TabIndex = 6;
            this.lblLeftRatio.Text = "左分支长度比";
            // 
            // trbLeftRatio
            // 
            this.trbLeftRatio.Location = new System.Drawing.Point(576, 189);
            this.trbLeftRatio.Name = "trbLeftRatio";
            this.trbLeftRatio.Size = new System.Drawing.Size(151, 69);
            this.trbLeftRatio.TabIndex = 7;
            this.trbLeftRatio.Value = 7;
            // 
            // lblDepth
            // 
            this.lblDepth.AutoSize = true;
            this.lblDepth.Location = new System.Drawing.Point(77, 126);
            this.lblDepth.Name = "lblDepth";
            this.lblDepth.Size = new System.Drawing.Size(80, 18);
            this.lblDepth.TabIndex = 8;
            this.lblDepth.Text = "递归深度";
            // 
            // txtDepth
            // 
            this.txtDepth.Location = new System.Drawing.Point(222, 120);
            this.txtDepth.Name = "txtDepth";
            this.txtDepth.Size = new System.Drawing.Size(100, 28);
            this.txtDepth.TabIndex = 9;
            this.txtDepth.Text = "10";
            // 
            // lblLength
            // 
            this.lblLength.AutoSize = true;
            this.lblLength.Location = new System.Drawing.Point(437, 123);
            this.lblLength.Name = "lblLength";
            this.lblLength.Size = new System.Drawing.Size(80, 18);
            this.lblLength.TabIndex = 10;
            this.lblLength.Text = "主干长度";
            // 
            // txtLength
            // 
            this.txtLength.Location = new System.Drawing.Point(576, 120);
            this.txtLength.Name = "txtLength";
            this.txtLength.Size = new System.Drawing.Size(100, 28);
            this.txtLength.TabIndex = 11;
            this.txtLength.Text = "100";
            // 
            // lblRightAngle
            // 
            this.lblRightAngle.AutoSize = true;
            this.lblRightAngle.Location = new System.Drawing.Point(77, 269);
            this.lblRightAngle.Name = "lblRightAngle";
            this.lblRightAngle.Size = new System.Drawing.Size(98, 18);
            this.lblRightAngle.TabIndex = 12;
            this.lblRightAngle.Text = "右分支角度";
            // 
            // lblLeftAngle
            // 
            this.lblLeftAngle.AutoSize = true;
            this.lblLeftAngle.Location = new System.Drawing.Point(437, 269);
            this.lblLeftAngle.Name = "lblLeftAngle";
            this.lblLeftAngle.Size = new System.Drawing.Size(98, 18);
            this.lblLeftAngle.TabIndex = 13;
            this.lblLeftAngle.Text = "左分支角度";
            // 
            // cmbRightAngle
            // 
            this.cmbRightAngle.FormattingEnabled = true;
            this.cmbRightAngle.Items.AddRange(new object[] {
            "0",
            "15",
            "30",
            "45",
            "60",
            "75",
            "90",
            "105",
            "120",
            "135",
            "150",
            "165",
            "180"});
            this.cmbRightAngle.Location = new System.Drawing.Point(222, 264);
            this.cmbRightAngle.Name = "cmbRightAngle";
            this.cmbRightAngle.Size = new System.Drawing.Size(121, 26);
            this.cmbRightAngle.TabIndex = 14;
            // 
            // cmbLeftAngle
            // 
            this.cmbLeftAngle.FormattingEnabled = true;
            this.cmbLeftAngle.Items.AddRange(new object[] {
            "0",
            "15",
            "30",
            "45",
            "60",
            "75",
            "90",
            "105",
            "120",
            "135",
            "150",
            "165",
            "180"});
            this.cmbLeftAngle.Location = new System.Drawing.Point(576, 266);
            this.cmbLeftAngle.Name = "cmbLeftAngle";
            this.cmbLeftAngle.Size = new System.Drawing.Size(121, 26);
            this.cmbLeftAngle.TabIndex = 15;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 345);
            this.Controls.Add(this.cmbLeftAngle);
            this.Controls.Add(this.cmbRightAngle);
            this.Controls.Add(this.lblLeftAngle);
            this.Controls.Add(this.lblRightAngle);
            this.Controls.Add(this.txtLength);
            this.Controls.Add(this.lblLength);
            this.Controls.Add(this.txtDepth);
            this.Controls.Add(this.lblDepth);
            this.Controls.Add(this.trbLeftRatio);
            this.Controls.Add(this.lblLeftRatio);
            this.Controls.Add(this.lblRightRatio);
            this.Controls.Add(this.trbRightRatio);
            this.Controls.Add(this.lblColor);
            this.Controls.Add(this.lblColorText);
            this.Controls.Add(this.btnSelectColor);
            this.Controls.Add(this.btnStartDrawing);
            this.Name = "Form1";
            this.Text = "Cayley树绘制";
            ((System.ComponentModel.ISupportInitialize)(this.trbRightRatio)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.trbLeftRatio)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnStartDrawing;
        private System.Windows.Forms.Button btnSelectColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.Label lblColorText;
        private System.Windows.Forms.Label lblColor;
        private System.Windows.Forms.TrackBar trbRightRatio;
        private System.Windows.Forms.Label lblRightRatio;
        private System.Windows.Forms.Label lblLeftRatio;
        private System.Windows.Forms.TrackBar trbLeftRatio;
        private System.Windows.Forms.Label lblDepth;
        private System.Windows.Forms.TextBox txtDepth;
        private System.Windows.Forms.Label lblLength;
        private System.Windows.Forms.TextBox txtLength;
        private System.Windows.Forms.Label lblRightAngle;
        private System.Windows.Forms.Label lblLeftAngle;
        private System.Windows.Forms.ComboBox cmbRightAngle;
        private System.Windows.Forms.ComboBox cmbLeftAngle;
    }
}

