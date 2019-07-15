namespace UlteriusRealTime
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonFreeze = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonStart.Location = new System.Drawing.Point(793, 967);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.buttonStart.Size = new System.Drawing.Size(225, 113);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "START";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(361, 116);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(1164, 824);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("宋体", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.label1.Location = new System.Drawing.Point(763, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(253, 33);
            this.label1.TabIndex = 4;
            this.label1.Text = "Real time Show";
            // 
            // buttonFreeze
            // 
            this.buttonFreeze.BackColor = System.Drawing.SystemColors.Info;
            this.buttonFreeze.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonFreeze.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.buttonFreeze.ForeColor = System.Drawing.SystemColors.ControlText;
            this.buttonFreeze.Location = new System.Drawing.Point(49, 945);
            this.buttonFreeze.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonFreeze.Name = "buttonFreeze";
            this.buttonFreeze.Size = new System.Drawing.Size(164, 135);
            this.buttonFreeze.TabIndex = 5;
            this.buttonFreeze.Text = "ToggleFreeze";
            this.buttonFreeze.UseVisualStyleBackColor = false;
            this.buttonFreeze.Click += new System.EventHandler(this.buttonFreeze_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("宋体", 16F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.button2.Location = new System.Drawing.Point(49, 36);
            this.button2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(185, 93);
            this.button2.TabIndex = 6;
            this.button2.Text = "Connect";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1856, 1151);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.buttonFreeze);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.buttonStart);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button buttonFreeze;
        private System.Windows.Forms.Button button2;
    }
}

