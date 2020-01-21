namespace SFTPClient
{
    partial class ProgressForm2
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
            this.PgBCurrent = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // PgBCurrent
            // 
            this.PgBCurrent.Location = new System.Drawing.Point(12, 12);
            this.PgBCurrent.Name = "PgBCurrent";
            this.PgBCurrent.Size = new System.Drawing.Size(428, 36);
            this.PgBCurrent.TabIndex = 1;
            // 
            // ProgressForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(452, 63);
            this.ControlBox = false;
            this.Controls.Add(this.PgBCurrent);
            this.Name = "ProgressForm2";
            this.Text = "진행 상황";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ProgressBar PgBCurrent;
    }
}