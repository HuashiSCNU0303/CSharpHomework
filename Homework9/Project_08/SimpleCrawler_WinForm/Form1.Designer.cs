namespace SimpleCrawler_WinForm
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
            this.components = new System.ComponentModel.Container();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHint1 = new System.Windows.Forms.Label();
            this.txtStartSite = new System.Windows.Forms.TextBox();
            this.btnStart = new System.Windows.Forms.Button();
            this.btnStop = new System.Windows.Forms.Button();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.lblHint2 = new System.Windows.Forms.Label();
            this.lblCurrentSite = new System.Windows.Forms.Label();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.lbxFailureList = new System.Windows.Forms.ListBox();
            this.simpleCrawlerBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.lblHint4 = new System.Windows.Forms.Label();
            this.lblHint3 = new System.Windows.Forms.Label();
            this.lbxSuccessList = new System.Windows.Forms.ListBox();
            this.simpleCrawlerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simpleCrawlerBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleCrawlerBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 4;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.lblHint1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtStartSite, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStart, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.btnStop, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(-1, 12);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(801, 54);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // lblHint1
            // 
            this.lblHint1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHint1.AutoSize = true;
            this.lblHint1.Location = new System.Drawing.Point(4, 18);
            this.lblHint1.Name = "lblHint1";
            this.lblHint1.Size = new System.Drawing.Size(152, 18);
            this.lblHint1.TabIndex = 0;
            this.lblHint1.Text = "开始爬虫的网址：";
            // 
            // txtStartSite
            // 
            this.txtStartSite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.txtStartSite.Location = new System.Drawing.Point(163, 13);
            this.txtStartSite.Name = "txtStartSite";
            this.txtStartSite.Size = new System.Drawing.Size(394, 28);
            this.txtStartSite.TabIndex = 1;
            this.txtStartSite.Text = "http://www.cnblogs.com/dstang2000/";
            // 
            // btnStart
            // 
            this.btnStart.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStart.Location = new System.Drawing.Point(567, 7);
            this.btnStart.Name = "btnStart";
            this.btnStart.Size = new System.Drawing.Size(106, 40);
            this.btnStart.TabIndex = 2;
            this.btnStart.Text = "开始爬虫";
            this.btnStart.UseVisualStyleBackColor = true;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnStop.Location = new System.Drawing.Point(689, 7);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(102, 40);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "停止爬虫";
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tableLayoutPanel2.Controls.Add(this.lblHint2, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.lblCurrentSite, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(51, 72);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(682, 49);
            this.tableLayoutPanel2.TabIndex = 1;
            // 
            // lblHint2
            // 
            this.lblHint2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHint2.AutoSize = true;
            this.lblHint2.Location = new System.Drawing.Point(8, 15);
            this.lblHint2.Name = "lblHint2";
            this.lblHint2.Size = new System.Drawing.Size(188, 18);
            this.lblHint2.TabIndex = 1;
            this.lblHint2.Text = "当前正在爬取的网址：";
            // 
            // lblCurrentSite
            // 
            this.lblCurrentSite.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblCurrentSite.AutoSize = true;
            this.lblCurrentSite.Location = new System.Drawing.Point(443, 15);
            this.lblCurrentSite.Name = "lblCurrentSite";
            this.lblCurrentSite.Size = new System.Drawing.Size(0, 18);
            this.lblCurrentSite.TabIndex = 2;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel3.ColumnCount = 2;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel3.Controls.Add(this.lbxFailureList, 1, 1);
            this.tableLayoutPanel3.Controls.Add(this.lblHint4, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.lblHint3, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.lbxSuccessList, 0, 1);
            this.tableLayoutPanel3.Location = new System.Drawing.Point(51, 127);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 90F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(682, 311);
            this.tableLayoutPanel3.TabIndex = 2;
            // 
            // lbxFailureList
            // 
            this.lbxFailureList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxFailureList.DataSource = this.simpleCrawlerBindingSource1;
            this.lbxFailureList.FormattingEnabled = true;
            this.lbxFailureList.ItemHeight = 18;
            this.lbxFailureList.Location = new System.Drawing.Point(344, 34);
            this.lbxFailureList.Name = "lbxFailureList";
            this.lbxFailureList.Size = new System.Drawing.Size(335, 274);
            this.lbxFailureList.TabIndex = 5;
            // 
            // simpleCrawlerBindingSource1
            // 
            this.simpleCrawlerBindingSource1.DataSource = typeof(SimpleCrawler_WinForm.SimpleCrawler);
            // 
            // lblHint4
            // 
            this.lblHint4.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHint4.AutoSize = true;
            this.lblHint4.Location = new System.Drawing.Point(440, 6);
            this.lblHint4.Name = "lblHint4";
            this.lblHint4.Size = new System.Drawing.Size(143, 18);
            this.lblHint4.TabIndex = 4;
            this.lblHint4.Text = "爬取失败URL列表";
            // 
            // lblHint3
            // 
            this.lblHint3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lblHint3.AutoSize = true;
            this.lblHint3.Location = new System.Drawing.Point(99, 6);
            this.lblHint3.Name = "lblHint3";
            this.lblHint3.Size = new System.Drawing.Size(143, 18);
            this.lblHint3.TabIndex = 2;
            this.lblHint3.Text = "成功爬取URL列表";
            // 
            // lbxSuccessList
            // 
            this.lbxSuccessList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lbxSuccessList.DataSource = this.simpleCrawlerBindingSource;
            this.lbxSuccessList.FormattingEnabled = true;
            this.lbxSuccessList.ItemHeight = 18;
            this.lbxSuccessList.Location = new System.Drawing.Point(3, 34);
            this.lbxSuccessList.Name = "lbxSuccessList";
            this.lbxSuccessList.Size = new System.Drawing.Size(335, 274);
            this.lbxSuccessList.TabIndex = 3;
            // 
            // simpleCrawlerBindingSource
            // 
            this.simpleCrawlerBindingSource.DataSource = typeof(SimpleCrawler_WinForm.SimpleCrawler);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel3);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.tableLayoutPanel3.ResumeLayout(false);
            this.tableLayoutPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.simpleCrawlerBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.simpleCrawlerBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label lblHint1;
        private System.Windows.Forms.TextBox txtStartSite;
        private System.Windows.Forms.Button btnStart;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label lblHint2;
        private System.Windows.Forms.Label lblCurrentSite;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private System.Windows.Forms.Label lblHint4;
        private System.Windows.Forms.Label lblHint3;
        private System.Windows.Forms.ListBox lbxSuccessList;
        private System.Windows.Forms.ListBox lbxFailureList;
        private System.Windows.Forms.BindingSource simpleCrawlerBindingSource;
        private System.Windows.Forms.BindingSource simpleCrawlerBindingSource1;
        private System.Windows.Forms.Button btnStop;
    }
}

