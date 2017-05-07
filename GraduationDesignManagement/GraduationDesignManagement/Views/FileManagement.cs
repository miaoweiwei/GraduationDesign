using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using ExcelDna.Integration.CustomUI;
using GraduationDesignManagement.BusinessServices;
using GraduationDesignManagement.Common;
using GraduationDesignManagement.EnumClass;
using GraduationDesignManagement.MysqlData;

namespace GraduationDesignManagement.Views
{
    public partial class FileManagement : UserControl
    {
        //当前活动窗体句柄
        //private readonly int _hwnd = (ExcelHelper.GetXlApplication()).ActiveWindow.Hwnd;
        public CustomTaskPane TaskPaneFileManagement { get; set; }

        private LogonBusinessService _logonBusinessService;
        private DataQuery _dataQuery;

        List<ServerFile> _serverFileList = new List<ServerFile>();
        DataTable _dataTable = new DataTable();
        /// <summary> 文件保存路径 </summary>
        private string _filePath;
        public FileManagement()
        {
            InitializeComponent();
        }

        private void FileManagement_Load(object sender, EventArgs e)
        {
            _logonBusinessService = LogonBusinessService.Instance;
            _dataQuery = DataQuery.Instance;
            if (_logonBusinessService.UserTypeInfo == UserTypeInfo.Teacher)
                palUpDate.Visible = true;
            else
                palUpDate.Visible = false;

            _serverFileList = _dataQuery.GetFileInfoList();

            _dataTable = new DataTable();
            _dataTable.Columns.Add("FileName");
            _dataTable.Columns.Add("UpLoadTime");
            _dataTable.Columns.Add("UserName");
            _dataTable.Columns.Add("DownLoadTime");
            _dataTable.Columns.Add("DownLoad");
            _dataTable.Columns.Add("DeleteFile");
            _dataTable.Columns.Add("FileCode");
            dgvFileList.DataSource = _dataTable;

            dgvFileList.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (_logonBusinessService.UserTypeInfo == UserTypeInfo.Teacher)
            {
                Teacher teacher = (Teacher) _logonBusinessService.UserObj;
                if (teacher.Position == "系主任")
                    dgvFileList.Columns[5].Visible = true;
                else
                    dgvFileList.Columns[5].Visible = false;
            }
            else
                dgvFileList.Columns[5].Visible = false;


            GetFileList();
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            GetFileList();
        }

        private void GetFileList()
        {
            _dataTable.Rows.Clear();
            _serverFileList.Clear();
            _serverFileList = _dataQuery.GetFileInfoList();
            foreach (ServerFile serverFile in _serverFileList)
            {
                DataRow dataRow = _dataTable.NewRow();
                dataRow.ItemArray = new object[]
                {
                    serverFile.FileName.Split('-')[1],
                    DateTimeHelper.GetTime(serverFile.UpLoadTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    serverFile.UserName,
                    serverFile.DownLoadTime,
                    "",
                    "",
                    serverFile.FileCode,
                };
                _dataTable.Rows.Add(dataRow.ItemArray);
            }
        }

        private void btnOpen_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_filePath))
            {
                MessageBox.Show(@"请先选择文件夹！", @"提示");
                return;
            }
            Process p = new Process();
            p.StartInfo.FileName = "explorer.exe";
            p.StartInfo.Arguments = @" /, " + _filePath;
            p.Start();
        }

        private void btnBrowseDirectory_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                _filePath = folderBrowserDialog.SelectedPath;
                txbFilePath.Text = _filePath;
            }
        }

        private void dgvFileList_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            if (dgvFileList.CurrentCell.GetType().Name == "DataGridViewDisableButtonCell")
            {
                int row = e.RowIndex;
                int col = e.ColumnIndex;
                DataGridViewDisableButtonCell btnButtonCell = dgvFileList.CurrentCell as DataGridViewDisableButtonCell;
                string fileCode = (dgvFileList.Rows[row].Cells[6].Value ?? "").ToString();
                ServerFile serverFile = new ServerFile();
                foreach (ServerFile file in _serverFileList)
                {
                    if (file.FileCode == fileCode)
                    {
                        serverFile = file;
                        break;
                    }
                }
                if (col == 4) //下载
                {
                    if (string.IsNullOrEmpty(_filePath))
                    {
                        MessageBox.Show(@"请先选择文件夹！", @"提示");
                        return;
                    }
                    if (btnButtonCell != null && btnButtonCell.Enabled == true)
                    {
                        btnButtonCell.Enabled = false;
                        WebClickDownloadFile webClick = new WebClickDownloadFile();
                        webClick.DownLoadUpDateDownLoadTime += WebClick_DownLoadUpDateDownLoadTime;
                        webClick.DownCell = btnButtonCell;
                        webClick.DownLoderFile(serverFile, _filePath);
                    }
                }
                else if (col == 5)//删除
                {
                    if (MessageBox.Show(@"确定要删除文件！",@"删除文件提醒",MessageBoxButtons.OKCancel,MessageBoxIcon.Warning) != DialogResult.OK)
                        return;
                    FtpUpLoadFile ftpUpLoadFile = new FtpUpLoadFile();
                    string uri = InitConfig.ServerHhost + "//" + InitConfig.ServerUpLoadPath;
                    bool success = ftpUpLoadFile.DelectFileFileFtp(uri, serverFile.FileName, InitConfig.FtpUser, InitConfig.FtpPassword);
                    var num = _dataQuery.DelectServerFile(new List<ServerFile>() {serverFile});

                    if (success && num>0)
                    {
                        _dataTable.Rows.RemoveAt(row);
                        MessageBox.Show(@"删除成功！");
                    }
                    else
                        MessageBox.Show(@"删除失败！");
                }
            }
        }

        /// <summary>
        /// 下载完成时更新文件的下载次数（包括dataGridview里的和_serverFileList里的）
        /// </summary>
        /// <param name="serverFile"></param>
        /// <param name="success"></param>
        private void WebClick_DownLoadUpDateDownLoadTime(ServerFile serverFile, bool success)
        {
            if (success)
            {
                int num = serverFile.DownLoadTime;
                DataQuery dataQuery = DataQuery.Instance;
                dataQuery.UpDateFileDownLoadTime(serverFile.FileCode, out num);

                foreach (ServerFile serverFileTemp in _serverFileList)
                {
                    if (serverFileTemp.FileCode == serverFile.FileCode)
                    {
                        serverFile.DownLoadTime = num;
                        break;
                    }
                }
                foreach (DataGridViewRow dataGridViewRow in dgvFileList.Rows)
                {
                    if (dataGridViewRow.Cells[5].Value.ToString() == serverFile.FileCode)
                    {
                        dataGridViewRow.Cells[3].Value = num.ToString();
                        break;
                    }
                }

            }
        }

        #region 上传文件

        private void btnUpDte_Click(object sender, EventArgs e)
        {
            btnUpDte.Enabled = false;
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = openFileDialog.FileName;
                string fileName = DateTimeHelper.DateTimeToTime_t(DateTime.Now) + "-" + openFileDialog.SafeFileName;

                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                ServerFile serverFile = new ServerFile()
                {
                    FileCode = Guid.NewGuid().ToString("N"),
                    FileName = fileName,
                    UpLoadTime = DateTimeHelper.DateTimeToTime_t(DateTime.Now).ToString(),
                    UserName = _logonBusinessService.UserName,
                    Size = fileInfo.Length,
                    DownLoadTime = 0,
                };

                Thread thread = new Thread(new ThreadStart(delegate
                  {
                      UpDateFile(serverFile, filePath, fileName);
                  }));
                thread.Start();
            }
        }

        private void UpDateFile(ServerFile serverFile, string filePath, string fileName)
        {
            FtpUpLoadFile ftpUpLoadFile = new FtpUpLoadFile();
            ftpUpLoadFile.ObjectFile = serverFile;

            ftpUpLoadFile.UploadFtpProgresChange += FtpUpLoadFile_UploadFtpProgresChange;
            ftpUpLoadFile.UploadFtpFileCompleted += FtpUpLoadFile_UploadFtpFileCompleted;

            string uri = InitConfig.ServerHhost + "//" + InitConfig.ServerUpLoadPath;
            ftpUpLoadFile.UploadFileFtp(filePath, uri, fileName, InitConfig.FtpUser, InitConfig.FtpPassword);
        }

        private void FtpUpLoadFile_UploadFtpFileCompleted(object obj, bool upLoadFtpState)
        {
            if (upLoadFtpState)
            {
                ServerFile serverFile = (ServerFile) obj;
                _dataQuery.UpLoadFile(new List<ServerFile>() { serverFile });

                labUpDateProgres.Invoke(new Action(delegate
                {
                    _serverFileList.Add(serverFile);
                    DataRow dataRow = _dataTable.NewRow();
                    dataRow.ItemArray = new object[]
                    {
                        serverFile.FileName.Split('-')[1],
                        DateTimeHelper.GetTime(serverFile.UpLoadTime).ToString("yyyy-MM-dd HH:mm:ss"),
                        serverFile.UserName,
                        serverFile.DownLoadTime,
                        "",
                        "",
                        serverFile.FileCode,
                    };
                    _dataTable.Rows.Add(dataRow);
                    labUpDateProgres.Text = @"上传完成";
                    btnUpDte.Enabled = true;
                }));
            }
        }

        private void FtpUpLoadFile_UploadFtpProgresChange(object obj, float uploadFileFtpProgres)
        {
            labUpDateProgres.Invoke(new Action(delegate
            {
                labUpDateProgres.Text = Math.Round(uploadFileFtpProgres * 100, 2) + @"%";
            }));
        }

        #endregion
    }
}
