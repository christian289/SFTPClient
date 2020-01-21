namespace SFTPClient
{
    partial class SftpMain
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
            this.TxtAddress = new System.Windows.Forms.TextBox();
            this.TxtPort = new System.Windows.Forms.TextBox();
            this.LblAddress = new System.Windows.Forms.Label();
            this.LblPort = new System.Windows.Forms.Label();
            this.GrpSFTPInfo = new System.Windows.Forms.GroupBox();
            this.LblID = new System.Windows.Forms.Label();
            this.LblPassword = new System.Windows.Forms.Label();
            this.TxtPassword = new System.Windows.Forms.TextBox();
            this.TxtID = new System.Windows.Forms.TextBox();
            this.GrpLocalFileList = new System.Windows.Forms.GroupBox();
            this.TreeLocalFileList = new System.Windows.Forms.TreeView();
            this.TxtLocalCurrentPath = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.BtnServerBasketClear = new System.Windows.Forms.Button();
            this.BtnToServerBasket = new System.Windows.Forms.Button();
            this.GrpServerBasket = new System.Windows.Forms.GroupBox();
            this.LiServerBasket = new System.Windows.Forms.ListBox();
            this.GrpServerFileList = new System.Windows.Forms.GroupBox();
            this.TreeServerFileList = new System.Windows.Forms.TreeView();
            this.TxtServerCurrentPath = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.BtnDownload = new System.Windows.Forms.Button();
            this.BtnUpload = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.BtnLocalBasketClear = new System.Windows.Forms.Button();
            this.BtnToLocalBasket = new System.Windows.Forms.Button();
            this.GrpLocalBasket = new System.Windows.Forms.GroupBox();
            this.LiLocalBasket = new System.Windows.Forms.ListBox();
            this.BtnConnection = new System.Windows.Forms.Button();
            this.LiLog = new System.Windows.Forms.ListBox();
            this.GrpLog = new System.Windows.Forms.GroupBox();
            this.BgwUpload = new System.ComponentModel.BackgroundWorker();
            this.BgwDownload = new System.ComponentModel.BackgroundWorker();
            this.BgwChecker = new System.ComponentModel.BackgroundWorker();
            this.GrpSFTPInfo.SuspendLayout();
            this.GrpLocalFileList.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.GrpServerBasket.SuspendLayout();
            this.GrpServerFileList.SuspendLayout();
            this.panel3.SuspendLayout();
            this.panel2.SuspendLayout();
            this.GrpLocalBasket.SuspendLayout();
            this.GrpLog.SuspendLayout();
            this.SuspendLayout();
            // 
            // TxtAddress
            // 
            this.TxtAddress.Location = new System.Drawing.Point(60, 20);
            this.TxtAddress.Name = "TxtAddress";
            this.TxtAddress.Size = new System.Drawing.Size(134, 21);
            this.TxtAddress.TabIndex = 0;
            this.TxtAddress.Text = "192.168.1.100";
            // 
            // TxtPort
            // 
            this.TxtPort.Location = new System.Drawing.Point(60, 47);
            this.TxtPort.Name = "TxtPort";
            this.TxtPort.Size = new System.Drawing.Size(134, 21);
            this.TxtPort.TabIndex = 1;
            this.TxtPort.Text = "880";
            // 
            // LblAddress
            // 
            this.LblAddress.AutoSize = true;
            this.LblAddress.Location = new System.Drawing.Point(14, 23);
            this.LblAddress.Name = "LblAddress";
            this.LblAddress.Size = new System.Drawing.Size(16, 12);
            this.LblAddress.TabIndex = 2;
            this.LblAddress.Text = "IP";
            // 
            // LblPort
            // 
            this.LblPort.AutoSize = true;
            this.LblPort.Location = new System.Drawing.Point(14, 50);
            this.LblPort.Name = "LblPort";
            this.LblPort.Size = new System.Drawing.Size(27, 12);
            this.LblPort.TabIndex = 3;
            this.LblPort.Text = "Port";
            // 
            // GrpSFTPInfo
            // 
            this.GrpSFTPInfo.Controls.Add(this.LblID);
            this.GrpSFTPInfo.Controls.Add(this.LblPassword);
            this.GrpSFTPInfo.Controls.Add(this.TxtPassword);
            this.GrpSFTPInfo.Controls.Add(this.TxtID);
            this.GrpSFTPInfo.Controls.Add(this.LblAddress);
            this.GrpSFTPInfo.Controls.Add(this.TxtPort);
            this.GrpSFTPInfo.Controls.Add(this.LblPort);
            this.GrpSFTPInfo.Controls.Add(this.TxtAddress);
            this.GrpSFTPInfo.Location = new System.Drawing.Point(12, 12);
            this.GrpSFTPInfo.Name = "GrpSFTPInfo";
            this.GrpSFTPInfo.Size = new System.Drawing.Size(206, 133);
            this.GrpSFTPInfo.TabIndex = 4;
            this.GrpSFTPInfo.TabStop = false;
            this.GrpSFTPInfo.Text = "연결 정보";
            // 
            // LblID
            // 
            this.LblID.AutoSize = true;
            this.LblID.Location = new System.Drawing.Point(14, 77);
            this.LblID.Name = "LblID";
            this.LblID.Size = new System.Drawing.Size(16, 12);
            this.LblID.TabIndex = 7;
            this.LblID.Text = "ID";
            // 
            // LblPassword
            // 
            this.LblPassword.AutoSize = true;
            this.LblPassword.Location = new System.Drawing.Point(14, 104);
            this.LblPassword.Name = "LblPassword";
            this.LblPassword.Size = new System.Drawing.Size(23, 12);
            this.LblPassword.TabIndex = 6;
            this.LblPassword.Text = "PW";
            // 
            // TxtPassword
            // 
            this.TxtPassword.Location = new System.Drawing.Point(60, 101);
            this.TxtPassword.Name = "TxtPassword";
            this.TxtPassword.PasswordChar = '*';
            this.TxtPassword.Size = new System.Drawing.Size(134, 21);
            this.TxtPassword.TabIndex = 5;
            this.TxtPassword.Text = "nss2109";
            // 
            // TxtID
            // 
            this.TxtID.Location = new System.Drawing.Point(60, 74);
            this.TxtID.Name = "TxtID";
            this.TxtID.Size = new System.Drawing.Size(134, 21);
            this.TxtID.TabIndex = 4;
            this.TxtID.Text = "nss";
            // 
            // GrpLocalFileList
            // 
            this.GrpLocalFileList.Controls.Add(this.TreeLocalFileList);
            this.GrpLocalFileList.Controls.Add(this.TxtLocalCurrentPath);
            this.GrpLocalFileList.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpLocalFileList.Location = new System.Drawing.Point(2, 2);
            this.GrpLocalFileList.Name = "GrpLocalFileList";
            this.GrpLocalFileList.Size = new System.Drawing.Size(342, 283);
            this.GrpLocalFileList.TabIndex = 6;
            this.GrpLocalFileList.TabStop = false;
            this.GrpLocalFileList.Text = "로컬 파일 목록";
            // 
            // TreeLocalFileList
            // 
            this.TreeLocalFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeLocalFileList.FullRowSelect = true;
            this.TreeLocalFileList.Location = new System.Drawing.Point(3, 38);
            this.TreeLocalFileList.Name = "TreeLocalFileList";
            this.TreeLocalFileList.Size = new System.Drawing.Size(336, 242);
            this.TreeLocalFileList.TabIndex = 2;
            // 
            // TxtLocalCurrentPath
            // 
            this.TxtLocalCurrentPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtLocalCurrentPath.Location = new System.Drawing.Point(3, 17);
            this.TxtLocalCurrentPath.Name = "TxtLocalCurrentPath";
            this.TxtLocalCurrentPath.ReadOnly = true;
            this.TxtLocalCurrentPath.Size = new System.Drawing.Size(336, 21);
            this.TxtLocalCurrentPath.TabIndex = 1;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(12, 151);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(776, 411);
            this.panel1.TabIndex = 7;
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.BtnServerBasketClear);
            this.panel4.Controls.Add(this.BtnToServerBasket);
            this.panel4.Controls.Add(this.GrpServerBasket);
            this.panel4.Controls.Add(this.GrpServerFileList);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel4.Location = new System.Drawing.Point(429, 0);
            this.panel4.Name = "panel4";
            this.panel4.Padding = new System.Windows.Forms.Padding(2);
            this.panel4.Size = new System.Drawing.Size(347, 411);
            this.panel4.TabIndex = 2;
            // 
            // BtnServerBasketClear
            // 
            this.BtnServerBasketClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnServerBasketClear.Location = new System.Drawing.Point(252, 285);
            this.BtnServerBasketClear.Name = "BtnServerBasketClear";
            this.BtnServerBasketClear.Size = new System.Drawing.Size(93, 24);
            this.BtnServerBasketClear.TabIndex = 9;
            this.BtnServerBasketClear.Text = "비우기";
            this.BtnServerBasketClear.UseVisualStyleBackColor = true;
            // 
            // BtnToServerBasket
            // 
            this.BtnToServerBasket.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnToServerBasket.Location = new System.Drawing.Point(2, 285);
            this.BtnToServerBasket.Name = "BtnToServerBasket";
            this.BtnToServerBasket.Size = new System.Drawing.Size(250, 24);
            this.BtnToServerBasket.TabIndex = 9;
            this.BtnToServerBasket.Text = "전송 목록에 추가 ↓";
            this.BtnToServerBasket.UseVisualStyleBackColor = true;
            // 
            // GrpServerBasket
            // 
            this.GrpServerBasket.Controls.Add(this.LiServerBasket);
            this.GrpServerBasket.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrpServerBasket.Location = new System.Drawing.Point(2, 309);
            this.GrpServerBasket.Name = "GrpServerBasket";
            this.GrpServerBasket.Size = new System.Drawing.Size(343, 100);
            this.GrpServerBasket.TabIndex = 7;
            this.GrpServerBasket.TabStop = false;
            this.GrpServerBasket.Text = "전송 리스트";
            // 
            // LiServerBasket
            // 
            this.LiServerBasket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LiServerBasket.FormattingEnabled = true;
            this.LiServerBasket.ItemHeight = 12;
            this.LiServerBasket.Location = new System.Drawing.Point(3, 17);
            this.LiServerBasket.Name = "LiServerBasket";
            this.LiServerBasket.Size = new System.Drawing.Size(337, 80);
            this.LiServerBasket.TabIndex = 0;
            // 
            // GrpServerFileList
            // 
            this.GrpServerFileList.Controls.Add(this.TreeServerFileList);
            this.GrpServerFileList.Controls.Add(this.TxtServerCurrentPath);
            this.GrpServerFileList.Dock = System.Windows.Forms.DockStyle.Top;
            this.GrpServerFileList.Location = new System.Drawing.Point(2, 2);
            this.GrpServerFileList.Name = "GrpServerFileList";
            this.GrpServerFileList.Size = new System.Drawing.Size(343, 283);
            this.GrpServerFileList.TabIndex = 8;
            this.GrpServerFileList.TabStop = false;
            this.GrpServerFileList.Text = "서버 파일 목록";
            // 
            // TreeServerFileList
            // 
            this.TreeServerFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.TreeServerFileList.Location = new System.Drawing.Point(3, 38);
            this.TreeServerFileList.Name = "TreeServerFileList";
            this.TreeServerFileList.PathSeparator = "/";
            this.TreeServerFileList.Size = new System.Drawing.Size(337, 242);
            this.TreeServerFileList.TabIndex = 2;
            // 
            // TxtServerCurrentPath
            // 
            this.TxtServerCurrentPath.Dock = System.Windows.Forms.DockStyle.Top;
            this.TxtServerCurrentPath.Location = new System.Drawing.Point(3, 17);
            this.TxtServerCurrentPath.Name = "TxtServerCurrentPath";
            this.TxtServerCurrentPath.ReadOnly = true;
            this.TxtServerCurrentPath.Size = new System.Drawing.Size(337, 21);
            this.TxtServerCurrentPath.TabIndex = 1;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.BtnDownload);
            this.panel3.Controls.Add(this.BtnUpload);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel3.Location = new System.Drawing.Point(346, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(83, 411);
            this.panel3.TabIndex = 1;
            // 
            // BtnDownload
            // 
            this.BtnDownload.Location = new System.Drawing.Point(6, 165);
            this.BtnDownload.Name = "BtnDownload";
            this.BtnDownload.Size = new System.Drawing.Size(70, 68);
            this.BtnDownload.TabIndex = 1;
            this.BtnDownload.Text = "<-";
            this.BtnDownload.UseVisualStyleBackColor = true;
            // 
            // BtnUpload
            // 
            this.BtnUpload.Location = new System.Drawing.Point(6, 66);
            this.BtnUpload.Name = "BtnUpload";
            this.BtnUpload.Size = new System.Drawing.Size(70, 68);
            this.BtnUpload.TabIndex = 0;
            this.BtnUpload.Text = "->";
            this.BtnUpload.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.BtnLocalBasketClear);
            this.panel2.Controls.Add(this.BtnToLocalBasket);
            this.panel2.Controls.Add(this.GrpLocalBasket);
            this.panel2.Controls.Add(this.GrpLocalFileList);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Padding = new System.Windows.Forms.Padding(2);
            this.panel2.Size = new System.Drawing.Size(346, 411);
            this.panel2.TabIndex = 0;
            // 
            // BtnLocalBasketClear
            // 
            this.BtnLocalBasketClear.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnLocalBasketClear.Location = new System.Drawing.Point(252, 285);
            this.BtnLocalBasketClear.Name = "BtnLocalBasketClear";
            this.BtnLocalBasketClear.Size = new System.Drawing.Size(92, 24);
            this.BtnLocalBasketClear.TabIndex = 9;
            this.BtnLocalBasketClear.Text = "비우기";
            this.BtnLocalBasketClear.UseVisualStyleBackColor = true;
            // 
            // BtnToLocalBasket
            // 
            this.BtnToLocalBasket.Dock = System.Windows.Forms.DockStyle.Left;
            this.BtnToLocalBasket.Location = new System.Drawing.Point(2, 285);
            this.BtnToLocalBasket.Margin = new System.Windows.Forms.Padding(0);
            this.BtnToLocalBasket.Name = "BtnToLocalBasket";
            this.BtnToLocalBasket.Size = new System.Drawing.Size(250, 24);
            this.BtnToLocalBasket.TabIndex = 8;
            this.BtnToLocalBasket.Text = "전송 목록에 추가 ↓";
            this.BtnToLocalBasket.UseVisualStyleBackColor = true;
            // 
            // GrpLocalBasket
            // 
            this.GrpLocalBasket.Controls.Add(this.LiLocalBasket);
            this.GrpLocalBasket.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.GrpLocalBasket.Location = new System.Drawing.Point(2, 309);
            this.GrpLocalBasket.Name = "GrpLocalBasket";
            this.GrpLocalBasket.Size = new System.Drawing.Size(342, 100);
            this.GrpLocalBasket.TabIndex = 7;
            this.GrpLocalBasket.TabStop = false;
            this.GrpLocalBasket.Text = "전송 리스트";
            // 
            // LiLocalBasket
            // 
            this.LiLocalBasket.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LiLocalBasket.FormattingEnabled = true;
            this.LiLocalBasket.ItemHeight = 12;
            this.LiLocalBasket.Location = new System.Drawing.Point(3, 17);
            this.LiLocalBasket.Name = "LiLocalBasket";
            this.LiLocalBasket.Size = new System.Drawing.Size(336, 80);
            this.LiLocalBasket.TabIndex = 0;
            // 
            // BtnConnection
            // 
            this.BtnConnection.Location = new System.Drawing.Point(224, 62);
            this.BtnConnection.Name = "BtnConnection";
            this.BtnConnection.Size = new System.Drawing.Size(92, 48);
            this.BtnConnection.TabIndex = 8;
            this.BtnConnection.Text = "연결";
            this.BtnConnection.UseVisualStyleBackColor = true;
            // 
            // LiLog
            // 
            this.LiLog.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LiLog.FormattingEnabled = true;
            this.LiLog.ItemHeight = 12;
            this.LiLog.Location = new System.Drawing.Point(3, 17);
            this.LiLog.Name = "LiLog";
            this.LiLog.Size = new System.Drawing.Size(457, 113);
            this.LiLog.TabIndex = 9;
            // 
            // GrpLog
            // 
            this.GrpLog.Controls.Add(this.LiLog);
            this.GrpLog.Location = new System.Drawing.Point(322, 12);
            this.GrpLog.Name = "GrpLog";
            this.GrpLog.Size = new System.Drawing.Size(463, 133);
            this.GrpLog.TabIndex = 10;
            this.GrpLog.TabStop = false;
            this.GrpLog.Text = "로그";
            this.GrpLog.Visible = false;
            // 
            // SftpMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 574);
            this.Controls.Add(this.GrpLog);
            this.Controls.Add(this.BtnConnection);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.GrpSFTPInfo);
            this.Name = "SftpMain";
            this.Text = "SFTP Client";
            this.GrpSFTPInfo.ResumeLayout(false);
            this.GrpSFTPInfo.PerformLayout();
            this.GrpLocalFileList.ResumeLayout(false);
            this.GrpLocalFileList.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.GrpServerBasket.ResumeLayout(false);
            this.GrpServerFileList.ResumeLayout(false);
            this.GrpServerFileList.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.GrpLocalBasket.ResumeLayout(false);
            this.GrpLog.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox TxtAddress;
        private System.Windows.Forms.TextBox TxtPort;
        private System.Windows.Forms.Label LblAddress;
        private System.Windows.Forms.Label LblPort;
        private System.Windows.Forms.GroupBox GrpSFTPInfo;
        private System.Windows.Forms.Label LblID;
        private System.Windows.Forms.Label LblPassword;
        private System.Windows.Forms.TextBox TxtPassword;
        private System.Windows.Forms.TextBox TxtID;
        private System.Windows.Forms.GroupBox GrpLocalFileList;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.GroupBox GrpServerFileList;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button BtnDownload;
        private System.Windows.Forms.Button BtnUpload;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button BtnConnection;
        private System.Windows.Forms.ListBox LiLog;
        private System.Windows.Forms.GroupBox GrpLog;
        private System.Windows.Forms.Button BtnToServerBasket;
        private System.Windows.Forms.GroupBox GrpServerBasket;
        private System.Windows.Forms.ListBox LiServerBasket;
        private System.Windows.Forms.Button BtnToLocalBasket;
        private System.Windows.Forms.GroupBox GrpLocalBasket;
        private System.Windows.Forms.ListBox LiLocalBasket;
        private System.Windows.Forms.Button BtnServerBasketClear;
        private System.Windows.Forms.Button BtnLocalBasketClear;
        private System.Windows.Forms.TreeView TreeLocalFileList;
        private System.Windows.Forms.TextBox TxtLocalCurrentPath;
        private System.Windows.Forms.TreeView TreeServerFileList;
        private System.Windows.Forms.TextBox TxtServerCurrentPath;
        private System.ComponentModel.BackgroundWorker BgwUpload;
        private System.ComponentModel.BackgroundWorker BgwDownload;
        private System.ComponentModel.BackgroundWorker BgwChecker;
    }
}

