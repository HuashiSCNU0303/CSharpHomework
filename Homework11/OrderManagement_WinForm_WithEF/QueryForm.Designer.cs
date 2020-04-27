namespace OrderManagement_WinForm
{
    partial class QueryForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.btnQuery = new System.Windows.Forms.Button();
            this.lbl_1 = new System.Windows.Forms.Label();
            this.lbl_2 = new System.Windows.Forms.Label();
            this.cmbQueryField = new System.Windows.Forms.ComboBox();
            this.txtQueryKeyword = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 5;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 7.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 32.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.25F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 18.75F));
            this.tableLayoutPanel1.Controls.Add(this.btnQuery, 4, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_1, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.lbl_2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.cmbQueryField, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtQueryKeyword, 3, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(27, 45);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(746, 100);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // btnQuery
            // 
            this.btnQuery.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnQuery.Location = new System.Drawing.Point(617, 30);
            this.btnQuery.Name = "btnQuery";
            this.btnQuery.Size = new System.Drawing.Size(114, 40);
            this.btnQuery.TabIndex = 0;
            this.btnQuery.Text = "开始查询";
            this.btnQuery.UseVisualStyleBackColor = true;
            this.btnQuery.Click += new System.EventHandler(this.btnQuery_Click);
            // 
            // lbl_1
            // 
            this.lbl_1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_1.AutoSize = true;
            this.lbl_1.Location = new System.Drawing.Point(5, 41);
            this.lbl_1.Name = "lbl_1";
            this.lbl_1.Size = new System.Drawing.Size(44, 18);
            this.lbl_1.TabIndex = 1;
            this.lbl_1.Text = "按照";
            // 
            // lbl_2
            // 
            this.lbl_2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.lbl_2.AutoSize = true;
            this.lbl_2.Location = new System.Drawing.Point(175, 41);
            this.lbl_2.Name = "lbl_2";
            this.lbl_2.Size = new System.Drawing.Size(224, 18);
            this.lbl_2.TabIndex = 2;
            this.lbl_2.Text = "来查询，请输入查询字段：";
            // 
            // cmbQueryField
            // 
            this.cmbQueryField.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cmbQueryField.FormattingEnabled = true;
            this.cmbQueryField.Items.AddRange(new object[] {
            "订单号",
            "产品名",
            "客户名"});
            this.cmbQueryField.Location = new System.Drawing.Point(58, 37);
            this.cmbQueryField.Name = "cmbQueryField";
            this.cmbQueryField.Size = new System.Drawing.Size(105, 26);
            this.cmbQueryField.TabIndex = 3;
            // 
            // txtQueryKeyword
            // 
            this.txtQueryKeyword.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtQueryKeyword.Location = new System.Drawing.Point(415, 36);
            this.txtQueryKeyword.Name = "txtQueryKeyword";
            this.txtQueryKeyword.Size = new System.Drawing.Size(181, 28);
            this.txtQueryKeyword.TabIndex = 4;
            // 
            // QueryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 187);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "QueryForm";
            this.Text = "查询订单";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnQuery;
        private System.Windows.Forms.Label lbl_1;
        private System.Windows.Forms.Label lbl_2;
        private System.Windows.Forms.ComboBox cmbQueryField;
        private System.Windows.Forms.TextBox txtQueryKeyword;
    }
}