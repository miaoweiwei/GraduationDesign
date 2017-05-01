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
    public partial class MyProject : UserControl
    {
        private LogonBusinessService _logonBusinessService;
        private DataQuery _dataQuery;

        //当前活动窗体句柄
        //private readonly int _hwnd = (ExcelHelper.GetXlApplication()).ActiveWindow.Hwnd;
        public CustomTaskPane TaskPaneMyProject { get; set; }

        public CustomTaskPane TaskPaneSelectProject { get; set; }

        public MyProject()
        {
            InitializeComponent();
        }

        private void MyProject_Load(object sender, EventArgs e)
        {
            _logonBusinessService=LogonBusinessService.Instance;
            _dataQuery=DataQuery.Instance;

            var gradations= _dataQuery.GetGraduationDesign(_logonBusinessService.UserTypeInfo, _logonBusinessService.UserId);
            if (gradations==null || gradations.Count<=0)
                return;
            string teacherId = gradations[0].TeacherId;
            string projectCode = gradations[0].ProjectCode;

            DataRow dataRow = _dataQuery.GetTeacherDataRow(teacherId);
            Teacher teacher = _dataQuery.DataRowToObject<Teacher>(dataRow);

            if (teacher != null)
            {
                txbTeacherName.Text = teacher.TeacherName;
            }

            var projects= _dataQuery.GetProjectListByCode(new List<string>() {projectCode});
            if(projects==null || projects.Count<=0)
                return;

            txbProjectName.Text = projects[0].ProjectName;
            txbIntroduce.Text = projects[0].Introduce;
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            TaskPaneMyProject.Visible = false;
            TaskPaneSelectProject.Visible = true;
        }
    }
}
