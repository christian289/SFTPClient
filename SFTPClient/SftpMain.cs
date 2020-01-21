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
    /*
     * 1. Upload, Download 후 대상 경로 Node Update
     * 2. Upload, Download 시 panel1을 Enable false, true 하는데 TreeView에서 node가 사라지는 것
     */
    public partial class SftpMain : Form
    {
        private static ProgressForm pForm { get; set; }
        private static ProgressForm2 pForm2 { get; set; } 

        private SessionOptions sessionOptions { get; set; }
        private BindingList<string> LocalSideFilePathBasket { get; set; }
        private BindingList<string> ServerSideFilePathBasket { get; set; }
        private string SelectedLocalPath { get; set; }
        private string SelectedServerPath { get; set; }

        public SftpMain()
        {
            InitializeComponent();
            pForm = new ProgressForm();
            pForm2 = new ProgressForm2();

            LocalSideFilePathBasket = new BindingList<string>();
            ServerSideFilePathBasket = new BindingList<string>();
            LiLocalBasket.DataSource = LocalSideFilePathBasket;
            LiServerBasket.DataSource = ServerSideFilePathBasket;

            TreeLocalFileList.AfterSelect += TreeLocalFileList_AfterSelect;
            TreeServerFileList.AfterSelect += TreeServerFileList_AfterSelect;
            BtnConnection.Click += BtnConnection_Click;
            BtnUpload.Click += BtnUpload_Click;
            BtnDownload.Click += BtnDownload_Click;
            BtnToLocalBasket.Click += BtnToLocalBasket_Click;
            BtnToServerBasket.Click += BtnToServerBasket_Click;
            BtnLocalBasketClear.Click += (sender, e) => LocalSideFilePathBasket.Clear();
            BtnServerBasketClear.Click += (sender, e) => ServerSideFilePathBasket.Clear();

            BgwUpload.WorkerReportsProgress = true;
            BgwUpload.WorkerSupportsCancellation = false;
            BgwUpload.DoWork += BgwUpload_DoWork;
            BgwUpload.RunWorkerCompleted += BgwUpload_RunWorkerCompleted;

            BgwDownload.WorkerReportsProgress = true;
            BgwDownload.WorkerSupportsCancellation = false;
            BgwDownload.DoWork += BgwDownload_DoWork;
            BgwDownload.RunWorkerCompleted += BgwDownload_RunWorkerCompleted;

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
        private async void BtnToServerBasket_Click(object sender, EventArgs e)
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

            panel1.Enabled = false;

            using (Session session = new Session())
            {
                session.Open(sessionOptions);
                string TargetFullPath = TreeServerFileList.SelectedNode.Tag.ToString();
                RemoteFileInfo fileInfo = await Task.Run(() => session.GetFileInfo(TargetFullPath)); // 비동기로 처리한 것에 큰 의미는 없다.

                if (!fileInfo.IsDirectory)
                {
                    ServerSideFilePathBasket.Add(TreeServerFileList.SelectedNode.Tag.ToString());
                }
            }
            
            panel1.Enabled = true;
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
                //TreeServerFileList.Nodes.Add(ServerRecuresiveDirectory(session, @"/", @"/")); // 원본
                TreeServerFileList.Nodes.Add(ServerRecuresiveDirectory(session, directory.Files[0].Name, directory.Files[0].FullName)); // 재귀 함수 시작
                
            }

            TxtServerCurrentPath.Text = @"/";

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

        private void BtnUpload_Click(object sender, EventArgs e)
        {
            //pForm.Show();
            pForm2.Show();
            panel1.Enabled = false;
            BgwUpload.RunWorkerAsync();
        }

        /// <summary>
        /// Upload 버튼 (->)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgwUpload_DoWork(object sender, DoWorkEventArgs e)
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
                session.FileTransferProgress += SessionFileTransferProgress;

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

        private void BgwUpload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panel1.Enabled = true;
            LocalSideFilePathBasket.Clear();
            pForm2.Hide(); // BackgroundWorker 작업이 끝난 시점이라 Main Thread로 이미 작업이 옮겨왔기 때문에 Cross Thread가 발생하지 않는다.

            int selectedNodeLevel = TreeServerFileList.SelectedNode.Level;
            int selectedNodeIndex = TreeServerFileList.SelectedNode.Index;

            //TreeServerFileList.Nodes.RemoveAt(selectedNodeIndex);

            using (Session session = new Session())
            {
                session.Open(sessionOptions);
                RemoteDirectoryInfo directory = session.ListDirectory(SelectedServerPath);
                //TreeServerFileList.Nodes.Insert(selectedNodeIndex, ServerRecuresiveDirectory(session, directory.Files[0].Name, directory.Files[0].FullName));
            }
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            //pForm.Show();
            pForm2.Show();
            panel1.Enabled = false;
            BgwDownload.RunWorkerAsync();
        }

        /// <summary>
        /// Download 버튼 (<-)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BgwDownload_DoWork(object sender, DoWorkEventArgs e)
        {
            sessionOptions = new SessionOptions
            {
                Protocol = Protocol.Sftp,
                HostName = TxtAddress.Text,
                UserName = TxtID.Text,
                Password = TxtPassword.Text,
                PortNumber = Convert.ToInt32(TxtPort.Text),
                SshHostKeyFingerprint = "ssh-rsa 1024 YKV2Oy2ygc1MFwaCwYBohn9cPdrJvPg+2U1n0zJ4A6Q=",
                GiveUpSecurityAndAcceptAnySshHostKey = true,
            };

            using (Session session = new Session())
            {
                session.FileTransferProgress += SessionFileTransferProgress;

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

        private void BgwDownload_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            panel1.Enabled = true;
            ServerSideFilePathBasket.Clear();
            pForm2.Hide(); // BackgroundWorker 작업이 끝난 시점이라 Main Thread로 이미 작업이 옮겨왔기 때문에 Cross Thread가 발생하지 않는다.

            int selectedNodeLevel = TreeLocalFileList.SelectedNode.Level;
            int selectedNodeIndex = TreeLocalFileList.SelectedNode.Index;
            //TreeLocalFileList.Nodes.RemoveAt(selectedNodeIndex);

            DirectoryInfo SelectedNodeDirectoryInfo = new DirectoryInfo(SelectedLocalPath);
            //TreeLocalFileList.Nodes.Insert(selectedNodeIndex, LocalRecuresiveDirectory(SelectedNodeDirectoryInfo.FullName, SelectedNodeDirectoryInfo.Name));
        }

        private void SessionFileTransferProgress(object sender, FileTransferProgressEventArgs e)
        {
            //pForm.SetValue(e.OverallProgress, e.FileProgress);
            pForm2.SetValue(e.FileProgress);
        }
    }
}
