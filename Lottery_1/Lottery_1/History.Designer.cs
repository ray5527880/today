namespace Lottery_1
{
    partial class History
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置 Managed 資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器
        /// 修改這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.dgView = new System.Windows.Forms.DataGridView();
            this.nud_n1 = new System.Windows.Forms.NumericUpDown();
            this.nud_n2 = new System.Windows.Forms.NumericUpDown();
            this.nud_n3 = new System.Windows.Forms.NumericUpDown();
            this.nud_n4 = new System.Windows.Forms.NumericUpDown();
            this.nud_n5 = new System.Windows.Forms.NumericUpDown();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtpDate = new System.Windows.Forms.DateTimePicker();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.button3 = new System.Windows.Forms.Button();
            this.openExcelFile = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_n1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_n2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_n3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_n4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_n5)).BeginInit();
            this.SuspendLayout();
            // 
            // dgView
            // 
            this.dgView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgView.Location = new System.Drawing.Point(4, 110);
            this.dgView.Margin = new System.Windows.Forms.Padding(4);
            this.dgView.Name = "dgView";
            this.dgView.RowTemplate.Height = 24;
            this.dgView.Size = new System.Drawing.Size(824, 542);
            this.dgView.TabIndex = 0;
            this.dgView.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgView_CellClick);
            // 
            // nud_n1
            // 
            this.nud_n1.Location = new System.Drawing.Point(263, 41);
            this.nud_n1.Margin = new System.Windows.Forms.Padding(4);
            this.nud_n1.Maximum = new decimal(new int[] {
            39,
            0,
            0,
            0});
            this.nud_n1.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_n1.Name = "nud_n1";
            this.nud_n1.Size = new System.Drawing.Size(60, 25);
            this.nud_n1.TabIndex = 1;
            this.nud_n1.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_n2
            // 
            this.nud_n2.Location = new System.Drawing.Point(331, 41);
            this.nud_n2.Margin = new System.Windows.Forms.Padding(4);
            this.nud_n2.Maximum = new decimal(new int[] {
            39,
            0,
            0,
            0});
            this.nud_n2.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_n2.Name = "nud_n2";
            this.nud_n2.Size = new System.Drawing.Size(60, 25);
            this.nud_n2.TabIndex = 2;
            this.nud_n2.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_n3
            // 
            this.nud_n3.Location = new System.Drawing.Point(399, 41);
            this.nud_n3.Margin = new System.Windows.Forms.Padding(4);
            this.nud_n3.Maximum = new decimal(new int[] {
            39,
            0,
            0,
            0});
            this.nud_n3.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_n3.Name = "nud_n3";
            this.nud_n3.Size = new System.Drawing.Size(60, 25);
            this.nud_n3.TabIndex = 3;
            this.nud_n3.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_n4
            // 
            this.nud_n4.Location = new System.Drawing.Point(467, 41);
            this.nud_n4.Margin = new System.Windows.Forms.Padding(4);
            this.nud_n4.Maximum = new decimal(new int[] {
            39,
            0,
            0,
            0});
            this.nud_n4.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_n4.Name = "nud_n4";
            this.nud_n4.Size = new System.Drawing.Size(60, 25);
            this.nud_n4.TabIndex = 4;
            this.nud_n4.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // nud_n5
            // 
            this.nud_n5.Location = new System.Drawing.Point(535, 41);
            this.nud_n5.Margin = new System.Windows.Forms.Padding(4);
            this.nud_n5.Maximum = new decimal(new int[] {
            39,
            0,
            0,
            0});
            this.nud_n5.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.nud_n5.Name = "nud_n5";
            this.nud_n5.Size = new System.Drawing.Size(60, 25);
            this.nud_n5.TabIndex = 5;
            this.nud_n5.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(5, 73);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 6;
            this.button1.Text = "新增";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(113, 74);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(100, 29);
            this.button2.TabIndex = 7;
            this.button2.Text = "修改";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(57, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(37, 15);
            this.label1.TabIndex = 8;
            this.label1.Text = "日期";
            // 
            // dtpDate
            // 
            this.dtpDate.Location = new System.Drawing.Point(5, 41);
            this.dtpDate.Name = "dtpDate";
            this.dtpDate.Size = new System.Drawing.Size(145, 25);
            this.dtpDate.TabIndex = 9;
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(156, 40);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(100, 25);
            this.txtNo.TabIndex = 10;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(188, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 15);
            this.label2.TabIndex = 11;
            this.label2.Text = "期數";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(271, 15);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(44, 15);
            this.label3.TabIndex = 12;
            this.label3.Text = "獎號1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(339, 15);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(44, 15);
            this.label4.TabIndex = 13;
            this.label4.Text = "獎號2";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(407, 15);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(44, 15);
            this.label5.TabIndex = 14;
            this.label5.Text = "獎號3";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(475, 15);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "獎號4";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(543, 15);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(44, 15);
            this.label7.TabIndex = 16;
            this.label7.Text = "獎號5";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(221, 74);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(100, 29);
            this.button3.TabIndex = 17;
            this.button3.Text = "匯入";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // openExcelFile
            // 
            this.openExcelFile.FileName = "openFileDialog1";
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtNo);
            this.Controls.Add(this.dtpDate);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.nud_n5);
            this.Controls.Add(this.nud_n4);
            this.Controls.Add(this.nud_n3);
            this.Controls.Add(this.nud_n2);
            this.Controls.Add(this.nud_n1);
            this.Controls.Add(this.dgView);
            this.Font = new System.Drawing.Font("新細明體", 11F);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "History";
            this.Size = new System.Drawing.Size(840, 660);
            this.Load += new System.EventHandler(this.UserControl1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_n1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_n2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_n3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_n4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.nud_n5)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgView;
        private System.Windows.Forms.NumericUpDown nud_n1;
        private System.Windows.Forms.NumericUpDown nud_n2;
        private System.Windows.Forms.NumericUpDown nud_n3;
        private System.Windows.Forms.NumericUpDown nud_n4;
        private System.Windows.Forms.NumericUpDown nud_n5;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpDate;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.OpenFileDialog openExcelFile;
    }
}
