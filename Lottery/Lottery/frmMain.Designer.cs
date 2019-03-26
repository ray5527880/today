namespace Lottery
{
    partial class frmMain
    {
        /// <summary>
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 設計工具產生的程式碼

        /// <summary>
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.btnAdd = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnSOpen = new System.Windows.Forms.Button();
            this.btnSDistributed = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnAdd
            // 
            this.btnAdd.Location = new System.Drawing.Point(13, 13);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(75, 23);
            this.btnAdd.TabIndex = 0;
            this.btnAdd.Text = "新增修改";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // panel1
            // 
            this.panel1.Location = new System.Drawing.Point(13, 43);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1560, 800);
            this.panel1.TabIndex = 1;
            // 
            // btnSOpen
            // 
            this.btnSOpen.Location = new System.Drawing.Point(94, 14);
            this.btnSOpen.Name = "btnSOpen";
            this.btnSOpen.Size = new System.Drawing.Size(75, 23);
            this.btnSOpen.TabIndex = 2;
            this.btnSOpen.Text = "查詢(開獎)";
            this.btnSOpen.UseVisualStyleBackColor = true;
            // 
            // btnSDistributed
            // 
            this.btnSDistributed.Location = new System.Drawing.Point(175, 14);
            this.btnSDistributed.Name = "btnSDistributed";
            this.btnSDistributed.Size = new System.Drawing.Size(75, 23);
            this.btnSDistributed.TabIndex = 3;
            this.btnSDistributed.Text = "查詢(分布)";
            this.btnSDistributed.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(257, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 4;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1584, 861);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnSDistributed);
            this.Controls.Add(this.btnSOpen);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.btnAdd);
            this.Font = new System.Drawing.Font("新細明體", 9.75F);
            this.Name = "frmMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnSOpen;
        private System.Windows.Forms.Button btnSDistributed;
        private System.Windows.Forms.Button button1;
    }
}

