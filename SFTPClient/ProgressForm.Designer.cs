namespace SFTPClient
{
    partial class ProgressForm
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
            this.PgBTotal = new System.Windows.Forms.ProgressBar();
            this.PgBCurrent = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.BtnHide = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // PgBTotal
            // 
            this.PgBTotal.Location = new System.Drawing.Point(12, 37);
            this.PgBTotal.Name = "PgBTotal";
            this.PgBTotal.Size = new System.Drawing.Size(428, 36);
            this.PgBTotal.TabIndex = 0;
            // 
            // PgBCurrent
            // 
            this.PgBCurrent.Location = new System.Drawing.Point(12, 119);
            this.PgBCurrent.Name = "PgBCurrent";
            this.PgBCurrent.Size = new System.Drawing.Size(428, 36);
            this.PgBCurrent.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.label1.Location = new System.Drawing.Point(21, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 25);
            this.label1.TabIndex = 2;
            this.label1.Text = "전체";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 14F);
            this.label2.Location = new System.Drawing.Point(21, 91);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 25);
            this.label2.TabIndex = 3;
            this.label2.Text = "현재";
            // 
            // BtnHide
            // 
            this.BtnHide.Location = new System.Drawing.Point(181, 164);
            this.BtnHide.Name = "BtnHide";
            this.BtnHide.Size = new System.Drawing.Size(83, 31);
            this.BtnHide.TabIndex = 4;
            this.BtnHide.Text = "닫기";
            this.BtnHide.UseVisualStyleBackColor = true;
            // 
            // ProgressForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 202);
            this.ControlBox = false;
            this.Controls.Add(this.BtnHide);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.PgBCurrent);
            this.Controls.Add(this.PgBTotal);
            this.Name = "ProgressForm";
            this.Text = "진행 상황";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ProgressBar PgBTotal;
        private System.Windows.Forms.ProgressBar PgBCurrent;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button BtnHide;
    }
}