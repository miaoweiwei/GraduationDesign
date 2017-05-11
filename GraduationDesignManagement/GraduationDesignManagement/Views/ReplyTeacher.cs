using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelDna.Integration.CustomUI;
using GraduationDesignManagement.BusinessServices;
using GraduationDesignManagement.Common;
using GraduationDesignManagement.EnumClass;
using GraduationDesignManagement.MysqlData;

namespace GraduationDesignManagement.Views
{
    public partial class ReplyTeacher : UserControl
    {
        //当前活动窗体句柄
        //private readonly int _hwnd = (ExcelHelper.GetXlApplication()).ActiveWindow.Hwnd;
        public CustomTaskPane TaskPaneReplyTeacher { get; set; }

        private LogonBusinessService _logonBusinessService;
        private DataQuery _dataQuery;

        List<GraduationDesign> _graduationDesignList = new List<GraduationDesign>();
        List<Project> _projectList = new List<Project>();
        List<Student> _studentList = new List<Student>();

        Dictionary<string, List<GraduationDesignFile>> _gradutionFileDic = new Dictionary<string, List<GraduationDesignFile>>();

        private DataTable _rdgvProjectTable = new DataTable();
        private DataTable _fileTable = new DataTable();
        private string _filePath;

        public ReplyTeacher()
        {
            InitializeComponent();
        }

        private void ReplyTeacher_Load(object sender, EventArgs e)
        {
            rdgvProject.ColumnHeadersHeight = 40;
            rdgvProject.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            rdgvProject.AddSpanHeader(0, 4, "我的答辩项目");//合并列

            rdgvFile.ColumnHeadersHeight = 40;
            rdgvFile.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            rdgvFile.AddSpanHeader(0, 3, "相关项目文件");

            _fileTable = new DataTable();
            _fileTable.Columns.Add("FileName");
            _fileTable.Columns.Add("UpLoadTime");
            _fileTable.Columns.Add("DownLoad");
            _fileTable.Columns.Add("FileCode");

            _rdgvProjectTable = new DataTable();
            _rdgvProjectTable.Columns.Add("StudentId");
            _rdgvProjectTable.Columns.Add("StudentName");
            _rdgvProjectTable.Columns.Add("StudentClass");
            _rdgvProjectTable.Columns.Add("ProjectName");

            _logonBusinessService = LogonBusinessService.Instance;
            _dataQuery = DataQuery.Instance;

            _graduationDesignList = _dataQuery.GetGraduationDesign(_logonBusinessService.UserId);

            List<string> studentIdList = _graduationDesignList.Select(s => s.StudentId).ToList();
            List<string> projectCodeList = _graduationDesignList.Select(s => s.ProjectCode).ToList();

            _studentList = _dataQuery.GetStudentListById(studentIdList);
            _projectList = _dataQuery.GetProjectListByCode(projectCodeList);

            foreach (string s in studentIdList)
            {
                List<GraduationDesignFile> graduationFileList = _dataQuery.GetGraduationDesignFileList(s);
                if (graduationFileList != null && graduationFileList.Count > 0)
                    if (_gradutionFileDic.ContainsKey(s))
                        _gradutionFileDic[s].AddRange(graduationFileList);
                    else
                        _gradutionFileDic[s] = graduationFileList;
            }


            foreach (GraduationDesign graduationDesign in _graduationDesignList)
            {
                DataRow dataRow = _rdgvProjectTable.NewRow();
                dataRow.ItemArray = new object[]
                {
                    graduationDesign.StudentId,
                    _studentList.Where(s => s.StudentId == graduationDesign.StudentId).ToList()[0].StudentName,
                    _studentList.Where(s => s.StudentId == graduationDesign.StudentId).ToList()[0].Class,
                    _projectList.Where(s => s.Projectcode == graduationDesign.ProjectCode).ToList()[0].ProjectName,
                };
                _rdgvProjectTable.Rows.Add(dataRow);
            }
            rdgvProject.DataSource = _rdgvProjectTable;
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
        private void button2_Click(object sender, EventArgs e)
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

        private void rdgvProject_CurrentCellChanged(object sender, EventArgs e)
        {
            if (rdgvProject.CurrentCell == null || rdgvProject.CurrentCell.RowIndex < 0)
                return;
            int row = rdgvProject.CurrentCell.RowIndex;
            PleaType pleaType = PleaType.BeginReply;
            if (rdBtnBegin.Checked)
                pleaType = PleaType.BeginReply;
            if (rdBtnMiddle.Checked)
                pleaType = PleaType.MiddleReply;
            if (rdBtnEnd.Checked)
                pleaType = PleaType.EndReply;

            string studentId = (rdgvProject.Rows[row].Cells[0].Value ?? "").ToString();

            List<GraduationDesignFile> graduationFileList=new List<GraduationDesignFile>();

            if (_gradutionFileDic.ContainsKey(studentId))
            {
                graduationFileList = _gradutionFileDic[studentId];
            }
            _fileTable.Rows.Clear();
            foreach (GraduationDesignFile designFile in graduationFileList)
            {
                if ((PleaType)System.Enum.Parse(typeof(PleaType), designFile.DateType) != pleaType)
                    continue;
                DataRow dataRow = _fileTable.NewRow();
                dataRow.ItemArray = new object[]
                {
                    designFile.FileName.Split('-')[1],
                    DateTimeHelper.GetTime(designFile.UpLoadTime).ToString("yyyy-MM-dd HH:mm:ss"),
                    "",
                    designFile.FileCode,
                };
                _fileTable.Rows.Add(dataRow);
            }
            rdgvFile.DataSource = _fileTable;

            GraduationDesign graduation = _graduationDesignList.Find(s => s.StudentId == studentId);
            switch (pleaType)
            {
                case PleaType.BeginReply:
                    txbScore.Text = graduation.BeginScore.ToString();
                    txbComment.Text = graduation.BeginComment;
                    break;
                case PleaType.MiddleReply:
                    txbScore.Text = graduation.MiddleScore.ToString();
                    txbComment.Text = graduation.MiddleComment;
                    break;
                case PleaType.EndReply:
                    txbScore.Text = graduation.EndScore.ToString();
                    txbComment.Text = graduation.EndComment;
                    break;
            }
        }

        private void rdBtn_CheckedChanged(object sender, EventArgs e)
        {
            rdgvProject_CurrentCellChanged(sender, e);
        }

        private void rdgvFile_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.ColumnIndex < 0)
                return;
            RowMergeView rowMergeView = sender as RowMergeView;
            if (rowMergeView != null && rowMergeView.CurrentCell.GetType().Name == "DataGridViewDisableButtonCell")
            {
                int row = e.RowIndex;
                int col = e.ColumnIndex;
                DataGridViewDisableButtonCell btnButtonCell = rowMergeView.CurrentCell as DataGridViewDisableButtonCell;
                string fileCode = (rowMergeView.Rows[row].Cells[3].Value ?? "").ToString();
                
                GraduationDesignFile graduationFile = new GraduationDesignFile();
                foreach (KeyValuePair<string, List<GraduationDesignFile>> keyValuePair in _gradutionFileDic)
                {
                    foreach (GraduationDesignFile designFile in keyValuePair.Value)
                    {
                        if (designFile.FileCode == fileCode)
                        {
                            graduationFile = designFile;
                            break;
                        }
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
                        GraduationFileUpDown graduationFileUpDown = new GraduationFileUpDown();
                        graduationFileUpDown.DownCell = btnButtonCell;
                        graduationFileUpDown.DownLoadGraduationDesignFile(graduationFile, _filePath);
                    }
                }
            }
        }
        
        private void txbScore_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsNumber(e.KeyChar) || e.KeyChar == (char) Keys.Back)
            {
                e.Handled = false; //让操作生效
            }
            else
            {
                e.Handled = true; //让操作生效
            }
        }

        private void txbScore_TextChanged(object sender, EventArgs e)
        {
            string text = txbScore.Text.Trim();
            int score = 0;
            if (int.TryParse(text, out score))
            {
                if (score<0 || score>100)
                {
                    MessageBox.Show(@"请输入正确的成绩！");
                    txbScore.Text = "";
                    return;
                }
            }
        }

        /// <summary> 提交 </summary> 
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txbScore.Text))
            {
                MessageBox.Show(@"请输入成绩！");
                return;
            }
            int score = int.Parse(txbScore.Text);
            string commentSt = txbComment.Text;

            int row = rdgvProject.CurrentCell.RowIndex;

            string studentId = (rdgvProject.Rows[row].Cells[0].Value ?? "").ToString();

            PleaType pleaType = PleaType.BeginReply;
            if (rdBtnBegin.Checked)
                pleaType = PleaType.BeginReply;
            if (rdBtnMiddle.Checked)
                pleaType = PleaType.MiddleReply;
            if (rdBtnEnd.Checked)
                pleaType = PleaType.EndReply;

            GraduationDesign graduation=new GraduationDesign();
            foreach (GraduationDesign graduationDesign in _graduationDesignList)
            {
                if (graduationDesign.StudentId == studentId)
                {
                    graduation = graduationDesign;
                    switch (pleaType)
                    {
                        case PleaType.BeginReply:
                            graduationDesign.BeginScore = score;
                            graduationDesign.BeginComment = commentSt;
                            break;
                        case PleaType.MiddleReply:
                            graduationDesign.MiddleScore= score;
                            graduationDesign.MiddleComment= commentSt;
                            break;
                        case PleaType.EndReply:
                            graduationDesign.EndScore = score;
                            graduationDesign.EndComment = commentSt;
                            break;
                    }
                }
            }
            if (_dataQuery.UpDataGraduationDesignScoreComment(graduation, pleaType)==1)
            {
                MessageBox.Show(@"提交成功！","");
            }
        }

        /// <summary> 导出 </summary> 
        private void btnExport_Click(object sender, EventArgs e)
        {
            object[,] objects = GetObjects(_rdgvProjectTable);
            ExcelHelper.ExportToExcel(objects);
        }
        /// <summary> 组织数据 </summary> 
        private object[,] GetObjects(DataTable dataTable)
        {
            object[,] objectArr = new object[dataTable.Rows.Count + 1, dataTable.Columns.Count+3];
            objectArr[0, 0] = "学号";
            objectArr[0, 1] = "姓名";
            objectArr[0, 2] = "班级";
            objectArr[0, 3] = "项目名称";
            objectArr[0, 4] = "开题答辩成绩";
            objectArr[0, 5] = "中期答辩成绩";
            objectArr[0, 6] = "结题答辩成绩";

            try
            {
                for (int i = 0; i < dataTable.Rows.Count; i++)
                {
                    string studentId= dataTable.Rows[i][0].ToString();
                    objectArr[i + 1, 0] = studentId;
                    objectArr[i + 1, 1] = dataTable.Rows[i][1].ToString();
                    objectArr[i + 1, 2] = dataTable.Rows[i][2].ToString();
                    objectArr[i + 1, 3] = dataTable.Rows[i][3].ToString();

                    objectArr[i + 1, 4] = _graduationDesignList.Find(s => s.StudentId == studentId).BeginScore;
                    objectArr[i + 1, 5] = _graduationDesignList.Find(s => s.StudentId == studentId).MiddleScore;
                    objectArr[i + 1, 6] = _graduationDesignList.Find(s => s.StudentId == studentId).EndScore;
                }
            }
            catch (Exception exception)
            {
                LogUtil.Error("选择老师 组织数据出错->" + exception);
            }

            return objectArr;
        }
    }
}
