using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;
using ExcelDna.Integration.CustomUI;
using GraduationDesignManagement.BusinessServices;
using GraduationDesignManagement.Common;
using GraduationDesignManagement.EnumClass;
using GraduationDesignManagement.MysqlData;
using log4net.Appender;
using SumscopeAddIn.Views;
using Excel= Microsoft.Office.Interop.Excel;

namespace GraduationDesignManagement.Views
{
    public partial class ReplyStudent : UserControl
    {

        //当前活动窗体句柄
        //private readonly int _hwnd = (ExcelHelper.GetXlApplication()).ActiveWindow.Hwnd;
        public CustomTaskPane TaskPaneReplyStudent { get; set; }

        private LogonBusinessService _logonBusinessService;
        private DataQuery _dataQuery;

        private GraduationDesign _myDesign=new GraduationDesign();

        private List<GraduationDesignFile> _graduationFileList=new List<GraduationDesignFile>();

        private DataTable _dataTableBegin=new DataTable();
        private DataTable _dataTableMiddle=new DataTable();
        private DataTable _dataTableEnd=new DataTable();

        private string _filePath;

        public ReplyStudent()
        {
            InitializeComponent();

            rdgvBegin.ColumnHeadersHeight = 40;
            rdgvBegin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            rdgvBegin.AddSpanHeader(0, 3, "开题");//合并列

            rdgvMiddle.ColumnHeadersHeight = 40;
            rdgvMiddle.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            rdgvMiddle.AddSpanHeader(0, 3, "中期");

            rdgvEnd.ColumnHeadersHeight = 40;
            rdgvEnd.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            rdgvEnd.AddSpanHeader(0, 3, "结题");
        }

        private void ReplyStudent_Load(object sender, EventArgs e)
        {
            _logonBusinessService=LogonBusinessService.Instance;
            _dataQuery=DataQuery.Instance;

            _myDesign = _dataQuery.GetMyGraduationDesign(_logonBusinessService.UserId);
            _graduationFileList = _dataQuery.GetGraduationDesignFileList(_logonBusinessService.UserId);
            
            _dataTableBegin =new DataTable();
            _dataTableBegin.Columns.Add("FileName");
            _dataTableBegin.Columns.Add("UpLoadTime");
            _dataTableBegin.Columns.Add("DownLoad");
            _dataTableBegin.Columns.Add("FileCode");

            _dataTableMiddle = new DataTable();
            _dataTableMiddle.Columns.Add("FileName");
            _dataTableMiddle.Columns.Add("UpLoadTime");
            _dataTableMiddle.Columns.Add("DownLoad");
            _dataTableMiddle.Columns.Add("FileCode");

            _dataTableEnd = new DataTable();
            _dataTableEnd.Columns.Add("FileName");
            _dataTableEnd.Columns.Add("UpLoadTime");
            _dataTableEnd.Columns.Add("DownLoad");
            _dataTableEnd.Columns.Add("FileCode");

            foreach (GraduationDesignFile designFile in _graduationFileList)
            {
                DataRow dataRow;
                switch ((PleaType)System.Enum.Parse(typeof(PleaType), designFile.DateType))
                {
                    case PleaType.BeginReply:
                        dataRow = _dataTableBegin.NewRow();
                        dataRow.ItemArray = new object[]
                        {
                            designFile.FileName.Split('-')[1],
                            DateTimeHelper.GetTime(designFile.UpLoadTime).ToString("yyyy-MM-dd HH:mm:ss"),
                            "",
                            designFile.FileCode,
                        };
                        _dataTableBegin.Rows.Add(dataRow);
                        break;
                    case PleaType.MiddleReply:
                        dataRow = _dataTableMiddle.NewRow();
                        dataRow.ItemArray = new object[]
                        {
                            designFile.FileName.Split('-')[1],
                            DateTimeHelper.GetTime(designFile.UpLoadTime).ToString("yyyy-MM-dd HH:mm:ss"),
                            "",
                            designFile.FileCode,
                        };
                        _dataTableMiddle.Rows.Add(dataRow);
                        break;
                    case PleaType.EndReply:
                        dataRow = _dataTableEnd.NewRow();
                        dataRow.ItemArray = new object[]
                        {
                            designFile.FileName.Split('-')[1],
                            DateTimeHelper.GetTime(designFile.UpLoadTime).ToString("yyyy-MM-dd HH:mm:ss"),
                            "",
                            designFile.FileCode,
                        };
                        _dataTableEnd.Rows.Add(dataRow);
                        break;
                }
            }
            rdgvBegin.DataSource = _dataTableBegin;
            rdgvMiddle.DataSource = _dataTableMiddle;
            rdgvEnd.DataSource = _dataTableEnd;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog(this) == DialogResult.OK)
            {
                _filePath = folderBrowserDialog.SelectedPath;
                txbDownLoad.Text = _filePath;
            }
        }

        private void rdgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;

            RowMergeView rowMergeView=sender as RowMergeView;

            if (rowMergeView!=null && rowMergeView.CurrentCell.GetType().Name == "DataGridViewDisableButtonCell")
            {
                int row = e.RowIndex;
                int col = e.ColumnIndex;
                DataGridViewDisableButtonCell btnButtonCell = rowMergeView.CurrentCell as DataGridViewDisableButtonCell;
                string fileCode = (rowMergeView.Rows[row].Cells[3].Value ?? "").ToString();
                GraduationDesignFile graduationFile = new GraduationDesignFile();
                foreach (GraduationDesignFile graduationFileTemp in _graduationFileList)
                {
                    if (graduationFileTemp.FileCode == fileCode)
                    {
                        graduationFile = graduationFileTemp;
                        break;
                    }
                }
                if (col == 2) //下载
                {
                    if (string.IsNullOrEmpty(_filePath))
                    {
                        MessageBox.Show(@"请先选择文件夹！", @"提示");
                        return;
                    }
                    if (btnButtonCell != null && btnButtonCell.Enabled == true)
                    {
                        btnButtonCell.Enabled = false;
                        GraduationFileUpDown graduationFileUpDown=new GraduationFileUpDown();
                        graduationFileUpDown.DownCell = btnButtonCell;
                        graduationFileUpDown.DownLoadGraduationDesignFile(graduationFile,_filePath);
                    }
                }
            }
        }

        private void btnUpLoad_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(_myDesign.ProjectCode))
            {
                MessageBox.Show(@"你还没有选择毕业项目，请选择毕业设计项目！");
                return;
            }
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                PleaType pleaType = PleaType.BeginReply;
                if (rdbtnBegin.Checked) pleaType = PleaType.BeginReply;
                if (rdbtnMiddle.Checked) pleaType = PleaType.MiddleReply;
                if (rdbtnEnd.Checked) pleaType = PleaType.EndReply;

                btnUpLoad.Enabled = false;
                rdbtnBegin.Enabled = false;
                rdbtnMiddle.Enabled = false;
                rdbtnEnd.Enabled = false;

                string filePath = openFileDialog.FileName;
                string fileName = DateTimeHelper.DateTimeToTime_t(DateTime.Now) + "-" + openFileDialog.SafeFileName;

                FileInfo fileInfo = new FileInfo(openFileDialog.FileName);
                GraduationDesignFile graduationDesignFile = new GraduationDesignFile()
                {
                    FileCode = Guid.NewGuid().ToString("N"),
                    FileName = fileName,
                    UpLoadTime = DateTimeHelper.DateTimeToTime_t(DateTime.Now).ToString(),
                    DateType = Enum.GetName(typeof(PleaType), pleaType),
                    StudentId = _logonBusinessService.UserId,
                    ProjectCode = _myDesign.ProjectCode,
                };

                Thread thread = new Thread(new ThreadStart(delegate
                {
                    UpDateFile(graduationDesignFile, filePath, fileName);
                }));
                thread.Start();
            }
        }
        private void UpDateFile(GraduationDesignFile graduationDesignFile, string filePath, string fileName)
        {
            FtpUpLoadFile ftpUpLoadFile = new FtpUpLoadFile();
            ftpUpLoadFile.ObjectFile = graduationDesignFile;
             
            ftpUpLoadFile.UploadFtpProgresChange += FtpUpLoadFile_UploadFtpProgresChange;
            ftpUpLoadFile.UploadFtpFileCompleted += FtpUpLoadFile_UploadFtpFileCompleted;

            string uri = InitConfig.ServerHhost + "//" + InitConfig.GraduationDesignFilePath;
            ftpUpLoadFile.UploadFileFtp(filePath, uri, fileName, InitConfig.FtpUser, InitConfig.FtpPassword);
        }

        private void FtpUpLoadFile_UploadFtpFileCompleted(object obj, bool upLoadFtpState)
        {
            if (upLoadFtpState)
            {
                GraduationDesignFile graduationDesignFile = (GraduationDesignFile) obj;
                _dataQuery.InsertGraduationDesignFile(new List<GraduationDesignFile>() {graduationDesignFile});

                this.Invoke(new Action(delegate
                {
                    _graduationFileList.Add(graduationDesignFile);

                    DataRow dataRow = null;
                    DataTable dataTable = null;
                    switch ((PleaType) System.Enum.Parse(typeof(PleaType), graduationDesignFile.DateType))
                    {
                        case PleaType.BeginReply:
                            dataTable = _dataTableBegin;
                            dataRow = _dataTableBegin.NewRow();
                            break;
                        case PleaType.MiddleReply:
                            dataTable = _dataTableMiddle;
                            dataRow = _dataTableMiddle.NewRow();
                            break;
                        case PleaType.EndReply:
                            dataTable = _dataTableEnd;
                            dataRow = _dataTableEnd.NewRow();
                            break;
                    }

                    if (dataRow != null && dataTable != null)
                    {
                        dataRow.ItemArray = new object[]
                        {
                            graduationDesignFile.FileName.Split('-')[1],
                            DateTimeHelper.GetTime(graduationDesignFile.UpLoadTime).ToString("yyyy-MM-dd HH:mm:ss"),
                            "",
                            graduationDesignFile.FileCode,
                        };
                        dataTable.Rows.Add(dataRow);
                    }
                    labProgress.Text = @"上传完成！";
                    btnUpLoad.Enabled = true;
                    rdbtnBegin.Enabled = true;
                    rdbtnMiddle.Enabled = true;
                    rdbtnEnd.Enabled = true;
                }));
            }
            else
            {
                Invoke(new Action(delegate
                {
                    labProgress.Text = @"上传失败！";
                    btnUpLoad.Enabled = true;
                    rdbtnBegin.Enabled = true;
                    rdbtnMiddle.Enabled = true;
                    rdbtnEnd.Enabled = true;
                }));
            }
        }

        private void FtpUpLoadFile_UploadFtpProgresChange(object obj, float uploadFileFtpProgres)
        {
            labProgress.Invoke(new Action(delegate
            {
                labProgress.Text = Math.Round(uploadFileFtpProgres * 100, 2) + @"%";
            }));
        }
    }
}
