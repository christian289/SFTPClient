using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WinSCP;

namespace SFTPClient
{
    public partial class SftpMain : Form
    {
        SessionOptions sessionOptions;
        BindingList<string> LocalSideFilePathBasket { get; set; }
        BindingList<string> ServerSideFilePathBasket { get; set; }
        //ProgressForm pForm;
        string SelectedLocalPath { get; set; }
        string SelectedServerPath { get; set; }

        public SftpMain()
        {
            InitializeComponent();

            LocalSideFilePathBasket = new BindingList<string>();
            ServerSideFilePathBasket = new BindingList<string>();
            LiLocalBasket.DataSource = LocalSideFilePathBasket;
            LiServerBasket.DataSource = ServerSideFilePathBasket;

            //pForm = new ProgressForm();

            TreeLocalFileList.AfterSelect += TreeLocalFileList_AfterSelect;
            TreeServerFileList.AfterSelect += TreeServerFileList_AfterSelect;
            BtnConnection.Click += BtnConnection_Click;
            BtnUpload.Click += (sender, e) => { BgwUpload.RunWorkerAsync(); };
            BtnDownload.Click += (sender, e) => { BgwDownload.RunWorkerAsync(); };
            BtnToLocalBasket.Click += BtnToLocalBasket_Click;
            BtnToServerBasket.Click += BtnToServerBasket_Click;
            BtnLocalBasketClear.Click += (sender, e) => LocalSideFilePathBasket.Clear();
            BtnServerBasketClear.Click += (sender, e) => ServerSideFilePathBasket.Clear();

            BgwUpload.WorkerReportsProgress = true;
            BgwUpload.WorkerSupportsCancellation = true;
            BgwUpload.DoWork += BgwUpload_DoWork;
            BgwUpload.RunWorkerCompleted += (sender, e) => { LocalSideFilePathBasket.Clear(); };

            BgwDownload.WorkerReportsProgress = true;
            BgwDownload.WorkerSupportsCancellation = true;
            BgwDownload.DoWork += BgwDownload_DoWork;
            BgwDownload.RunWorkerCompleted += (sender, e) => { ServerSideFilePathBasket.Clear(); };

            BgwChecker.WorkerReportsProgress = false;
            BgwChecker.WorkerSupportsCancellation = false;
            BgwChecker.DoWork += BgwChecker_DoWork;

            BgwChecker.RunWorkerAsync();
        }

        /// <summary>
        /// Background에서 컨트롤 유효성 검사
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgwChecker_DoWork(object sender, DoWorkEventArgs e)
        {
            while(true)
            {
                if (sessionOptions is null)
                {
                    panel1.BeginInvoke(new MethodInvoker(delegate { panel1.Enabled = false; }));
                }
                else
                {
                    panel1.BeginInvoke(new MethodInvoker(delegate { panel1.Enabled = true; }));

                    if (LocalSideFilePathBasket.Count == 0)
                    {
                        BtnUpload.BeginInvoke(new MethodInvoker(delegate { BtnUpload.Enabled = false; }));
                    }
                    else
                    {
                        BtnUpload.BeginInvoke(new MethodInvoker(delegate { BtnUpload.Enabled = true; }));
                    }

                    if (ServerSideFilePathBasket.Count == 0)
                    {
                        BtnDownload.BeginInvoke(new MethodInvoker(delegate { BtnDownload.Enabled = false; }));
                    }
                    else
                    {
                        BtnDownload.BeginInvoke(new MethodInvoker(delegate { BtnDownload.Enabled = true; ; }));
                    }
                }

                Thread.Sleep(400);
            }
        }

        /// <summary>
        /// 로컬에서 서버로 보낼 파일 목록 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnToServerBasket_Click(object sender, EventArgs e)
        {
            using (Session session = new Session())
            {
                session.Open(sessionOptions);
                RemoteFileInfo fileInfo = session.GetFileInfo(TreeServerFileList.SelectedNode.Tag.ToString());

                if (!fileInfo.IsDirectory)
                {
                    ServerSideFilePathBasket.Add(TreeServerFileList.SelectedNode.Tag.ToString());
                }
            }
        }

        /// <summary>
        /// 서버에서 로컬로 보낼 파일 목록 추가
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnToLocalBasket_Click(object sender, EventArgs e)
        {
            FileAttributes file = File.GetAttributes(TreeLocalFileList.SelectedNode.Tag.ToString());

            if ((file & FileAttributes.Directory) != FileAttributes.Directory)
            {
                LocalSideFilePathBasket.Add(TreeLocalFileList.SelectedNode.Tag.ToString());
            }
        }

        /// <summary>
        /// 로컬의 현재 선택된 노드 파일경로 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeLocalFileList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TxtLocalCurrentPath.Text = e.Node.Tag.ToString();
            SelectedLocalPath = e.Node.Tag.ToString() + @"\"; // 로컬 경로는 \로, 서버 경로는 /로
        }

        /// <summary>
        /// 서버의 현재 선택된 노드 파일경로 변경
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeServerFileList_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TxtServerCurrentPath.Text = e.Node.FullPath;
            SelectedServerPath = e.Node.Tag.ToString() + @"/";
        }

        /// <summary>
        /// SFTP 연결 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnConnection_Click(object sender, EventArgs e)
        {
            TreeLocalFileList.Nodes.Clear();
            TreeServerFileList.Nodes.Clear();

            try
            {
                sessionOptions = new SessionOptions
                {
                    Protocol = Protocol.Sftp,
                    HostName = TxtAddress.Text,
                    UserName = TxtID.Text,
                    Password = TxtPassword.Text,
                    PortNumber = Convert.ToInt32(TxtPort.Text),
                    SshHostKeyFingerprint = "ssh-rsa 1024 YKV2Oy2ygc1MFwaCwYBohn9cPdrJvPg+2U1n0zJ4A6Q=",
                    GiveUpSecurityAndAcceptAnySshHostKey = true
                };

                using (Session session = new Session())
                {
                    session.Open(sessionOptions);
                    RemoteDirectoryInfo directory = session.ListDirectory(@"/"); // Server에서 Root로 지정된 경로의 상대경로를 지정. 서버의 C:\부터 지정하는게 아님
                    TreeServerFileList.Nodes.Add(ServerRecuresiveDirectory(session, @"/", @"/")); // 재귀 함수 시작
                }

                TxtServerCurrentPath.Text = @"/";
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            DirectoryInfo localDirectoryInfo = new DirectoryInfo(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments)); // 내 문서 절대 경로
            TreeLocalFileList.Nodes.Add(LocalRecuresiveDirectory(localDirectoryInfo.FullName, localDirectoryInfo.Name)); // 재귀 함수 시작
            TxtLocalCurrentPath.Text = localDirectoryInfo.FullName;
        }

        /// <summary>
        /// 서버 루트 디렉토리 탐색 재귀 함수
        /// </summary>
        /// <param name="session"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        private TreeNode ServerRecuresiveDirectory(Session session, string Path, string FileName)
        {
            TreeNode rtnValue = new TreeNode { Text = FileName, Tag = Path };
            RemoteDirectoryInfo directory = session.ListDirectory(Path);

            foreach (RemoteFileInfo fileInfo in directory.Files)
            {
                if (fileInfo.Name.Equals(".") || fileInfo.Name.Equals(".."))
                {
                    continue;
                }

                if (fileInfo.IsDirectory)
                {
                    rtnValue.Nodes.Add(ServerRecuresiveDirectory(session, string.Format("{0}/{1}", Path, fileInfo.Name), fileInfo.Name));
                }
                else
                {
                    rtnValue.Nodes.Add(new TreeNode { Text = fileInfo.Name, Tag = fileInfo.FullName });
                }
            }

            return rtnValue;
        }

        /// <summary>
        /// 로컬 루트 디렉토리 탐색 재귀 함수
        /// </summary>
        /// <param name="session"></param>
        /// <param name="Path"></param>
        /// <returns></returns>
        private TreeNode LocalRecuresiveDirectory(string Path, string FileName)
        {
            TreeNode rtnValue = new TreeNode { Text = FileName, Tag = Path };
            DirectoryInfo directoryInfo = new DirectoryInfo(Path);

            foreach (DirectoryInfo directory in directoryInfo.GetDirectories())
            {
                try
                {
                    rtnValue.Nodes.Add(LocalRecuresiveDirectory(directory.FullName, directory.Name));
                }
                catch (UnauthorizedAccessException)
                {
                    // 권한 관련하여 exception이 발생하면 건너뛴다.
                }
            }

            foreach (FileInfo file in directoryInfo.GetFiles())
            {
                rtnValue.Nodes.Add(new TreeNode { Text = file.Name, Tag = file.FullName });
            }

            return rtnValue;
        }

        /// <summary>
        /// Upload 버튼 (->)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgwUpload_DoWork(object sender, DoWorkEventArgs e)
        {
            using (Session session = new Session())
            {
                session.FileTransferProgress += SessionFileTransferProgress;
                //pForm.Show();

                session.Open(sessionOptions);
                TransferOptions transferOptions = new TransferOptions { TransferMode = TransferMode.Binary };

                foreach (string TargetPath in LocalSideFilePathBasket)
                {
                    TransferOperationResult transferResult = session.PutFiles(
                        localPath: TargetPath, 
                        remotePath: (SelectedServerPath.Equals("/")) ? "/" : SelectedServerPath.Substring(1),
                        remove: false, 
                        options: transferOptions);
                    transferResult.Check();
                }
                /*
                // Print results
                foreach (TransferEventArgs transfer in transferResult.Transfers)
                {
                    LiLog.Items.Add(string.Format("Upload of {0} succeeded", transfer.FileName));
                }*/
            }
        }

        /// <summary>
        /// Download 버튼 (<-)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgwDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            using (Session session = new Session())
            {
                session.FileTransferProgress += SessionFileTransferProgress;
                //pForm.Show();

                session.Open(sessionOptions);
                TransferOptions transferOptions = new TransferOptions { TransferMode = TransferMode.Binary };

                foreach (string TargetPath in ServerSideFilePathBasket)
                {
                    TransferOperationResult transferResult = session.GetFiles(
                        localPath: SelectedLocalPath,
                        remotePath: TargetPath,
                        remove: false,
                        options: transferOptions);
                    transferResult.Check();
                }
                /*
                // Print results
                foreach (TransferEventArgs transfer in transferResult.Transfers)
                {
                    LiLog.Items.Add(string.Format("Upload of {0} succeeded", transfer.FileName));
                }*/
            }
        }

        private void SessionFileTransferProgress(object sender, FileTransferProgressEventArgs e)
        {
            //pForm.SetValue(Convert.ToInt32(e.OverallProgress), Convert.ToInt32(e.FileProgress));
        }
    }
}
