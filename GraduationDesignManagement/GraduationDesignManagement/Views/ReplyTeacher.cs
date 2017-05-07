using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelDna.Integration.CustomUI;
using GraduationDesignManagement.BusinessServices;
using GraduationDesignManagement.Common;
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

        public ReplyTeacher()
        {
            InitializeComponent();
        }
         
        private void ReplyTeacher_Load(object sender, EventArgs e)
        {
            _logonBusinessService=LogonBusinessService.Instance;
            _dataQuery=DataQuery.Instance;

            _graduationDesignList = _dataQuery.GetGraduationDesign(_logonBusinessService.UserId);
            _studentList = _dataQuery.GetStudentListById(_graduationDesignList.Select(s => s.StudentId).ToList());
            _projectList = _dataQuery.GetProjectListByCode(_graduationDesignList.Select(s => s.ProjectCode).ToList());


            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("StudentId");
            dataTable.Columns.Add("StudentName");
            dataTable.Columns.Add("Class");
            dataTable.Columns.Add("ProjectName");
            dataTable.Columns.Add("ProjectCode");

            foreach (GraduationDesign graduationDesign in _graduationDesignList)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow.ItemArray = new object[]
                {
                    graduationDesign.StudentId,
                    _studentList.Where(s => s.StudentId == graduationDesign.StudentId).ToList()[0].StudentName,
                    _studentList.Where(s => s.StudentId == graduationDesign.StudentId).ToList()[0].Class,
                    _projectList.Where(s => s.Projectcode == graduationDesign.ProjectCode).ToList()[0].ProjectName,
                    graduationDesign.ProjectCode,
                };
                dataTable.Rows.Add(dataRow);
            }
            dgvMyStudent.DataSource = dataTable;
        }

    }
}
