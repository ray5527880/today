namespace bigtal
{
    partial class frmMain
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
            this.rdoRevise = new System.Windows.Forms.RadioButton();
            this.rdoPrediction = new System.Windows.Forms.RadioButton();
            this.rdoSearch = new System.Windows.Forms.RadioButton();
            this.btnOK = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rdoPrediction2 = new System.Windows.Forms.RadioButton();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // rdoRevise
            // 
            this.rdoRevise.AutoSize = true;
            this.rdoRevise.Location = new System.Drawing.Point(34, 36);
            this.rdoRevise.Name = "rdoRevise";
            this.rdoRevise.Size = new System.Drawing.Size(80, 17);
            this.rdoRevise.TabIndex = 0;
            this.rdoRevise.TabStop = true;
            this.rdoRevise.Text = "新增/修改";
            this.rdoRevise.UseVisualStyleBackColor = true;
            // 
            // rdoPrediction
            // 
            this.rdoPrediction.AutoSize = true;
            this.rdoPrediction.Location = new System.Drawing.Point(189, 36);
            this.rdoPrediction.Name = "rdoPrediction";
            this.rdoPrediction.Size = new System.Drawing.Size(51, 17);
            this.rdoPrediction.TabIndex = 1;
            this.rdoPrediction.TabStop = true;
            this.rdoPrediction.Text = "預測";
            this.rdoPrediction.UseVisualStyleBackColor = true;
            // 
            // rdoSearch
            // 
            this.rdoSearch.AutoSize = true;
            this.rdoSearch.Location = new System.Drawing.Point(127, 36);
            this.rdoSearch.Name = "rdoSearch";
            this.rdoSearch.Size = new System.Drawing.Size(51, 17);
            this.rdoSearch.TabIndex = 2;
            this.rdoSearch.TabStop = true;
            this.rdoSearch.Text = "搜尋";
            this.rdoSearch.UseVisualStyleBackColor = true;
            // 
            // btnOK
            // 
            this.btnOK.Location = new System.Drawing.Point(400, 27);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(87, 25);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "確定";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(14, 67);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(960, 541);
            this.panel1.TabIndex = 4;
            // 
            // rdoPrediction2
            // 
            this.rdoPrediction2.AutoSize = true;
            this.rdoPrediction2.Location = new System.Drawing.Point(495, 35);
            this.rdoPrediction2.Name = "rdoPrediction2";
            this.rdoPrediction2.Size = new System.Drawing.Size(57, 17);
            this.rdoPrediction2.TabIndex = 6;
            this.rdoPrediction2.TabStop = true;
            this.rdoPrediction2.Text = "預測2";
            this.rdoPrediction2.UseVisualStyleBackColor = true;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Location = new System.Drawing.Point(565, 36);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(87, 17);
            this.radioButton1.TabIndex = 7;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "radioButton1";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1002, 632);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.rdoPrediction2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.rdoSearch);
            this.Controls.Add(this.rdoPrediction);
            this.Controls.Add(this.rdoRevise);
            this.Font = new System.Drawing.Font("新細明體", 9.75F);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RadioButton rdoRevise;
        private System.Windows.Forms.RadioButton rdoPrediction;
        private System.Windows.Forms.RadioButton rdoSearch;
        private System.Windows.Forms.Button btnOK;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.RadioButton rdoPrediction2;
        private System.Windows.Forms.RadioButton radioButton1;
    }
}