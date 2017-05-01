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
    public partial class MyStudent : UserControl
    {
        //当前活动窗体句柄
        //private readonly int _hwnd = (ExcelHelper.GetXlApplication()).ActiveWindow.Hwnd;
        public CustomTaskPane TaskPaneMyStudent { get; set; }

        private LogonBusinessService _logonBusinessService;
        private DataQuery _dataQuery;


        List<GraduationDesign>_graduationDesignList=new List<GraduationDesign>();
        List<Project>_projectList=new List<Project>();
        List<Student>_studentList=new List<Student>();
        

        public MyStudent()
        {
            InitializeComponent();
        }

        private void MyStudent_Load(object sender, EventArgs e)
        {
            _logonBusinessService=LogonBusinessService.Instance;
            _dataQuery= DataQuery.Instance;
            _graduationDesignList = _dataQuery.GetGraduationDesign(_logonBusinessService.UserTypeInfo, _logonBusinessService.UserId);
            _studentList = _dataQuery.GetStudentListById(_graduationDesignList.Select(s=>s.StudentId).ToList());
            _projectList = _dataQuery.GetProjectListByCode(_graduationDesignList.Select(s => s.ProjectCode).ToList());

            DataTable dataTable=new DataTable();
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

        private void dgvMyStudent_CurrentCellChanged(object sender, EventArgs e)
        {
            DataGridViewRow dataGridViewRow = dgvMyStudent.CurrentRow;
            if(dataGridViewRow==null)
                return;
            string projectName = dataGridViewRow.Cells[3].Value.ToString();
            string projectCode = dataGridViewRow.Cells[4].Value.ToString();
            string projectIntroduce = "";
            foreach (Project project in _projectList)
            {
                if (project.Projectcode == projectCode)
                {
                    projectIntroduce = project.Introduce;
                    break;
                }
            }

            txbProjectName.Text = projectName;
            txbIntroduce.Text = projectIntroduce;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            object[,] objects=new object[dgvMyStudent.Rows.Count+1,4];

            objects[0, 0] = "学号";
            objects[0, 1] = "姓名";
            objects[0, 2] = "班级";
            objects[0, 3] = "项目名称";

            for (int i = 0; i < dgvMyStudent.Rows.Count; i++)
            {
                objects[i + 1, 0] = dgvMyStudent.Rows[i].Cells[0].Value.ToString();
                objects[i + 1, 1] = dgvMyStudent.Rows[i].Cells[1].Value.ToString();
                objects[i + 1, 2] = dgvMyStudent.Rows[i].Cells[2].Value.ToString();
                objects[i + 1, 3] = dgvMyStudent.Rows[i].Cells[3].Value.ToString();
            }
            ExcelHelper.ExportToExcel(objects);
        }

        private void btnProjress_Click(object sender, EventArgs e)
        {
            object[,] objects = new object[2, 2];
            objects[0, 0] = "项目名称";
            objects[0, 1] = "项目说明";
            objects[1, 0] = txbProjectName.Text;
            objects[1, 1] = txbIntroduce.Text;
            ExcelHelper.ExportToExcel(objects);
        }
    }
}
