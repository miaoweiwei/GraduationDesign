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
    public partial class SelectProject : UserControl
    {
        //当前活动窗体句柄
        //private readonly int _hwnd = (ExcelHelper.GetXlApplication()).ActiveWindow.Hwnd;
        public CustomTaskPane TaskPaneSelectProject { get; set; }

        private LogonBusinessService _logonBusinessService;
        private DataQuery _dataQuery;

        /// <summary> 项目List </summary>
        private List<Project> _projectList = new List<Project>();
        public SelectProject()
        {
            InitializeComponent();
        }

        private void SelectProject_Load(object sender, EventArgs e)
        {
            _logonBusinessService = LogonBusinessService.Instance;
            _dataQuery = new DataQuery();
            _projectList = _dataQuery.GetProjectList(null);
            foreach (Project project in _projectList)
            {
                DataGridViewRow dataRow = new DataGridViewRow();
                dataRow.Cells.Add(new DataGridViewTextBoxCell() { Value = project.ProjectName });
                dataRow.Cells.Add(new DataGridViewTextBoxCell() { Value = project.Projectcode });
                dgvProject.Rows.Add(dataRow);
            }
        }

        private void dgvProject_CurrentCellChanged(object sender, EventArgs e)
        {
            if (dgvProject.CurrentCell == null || dgvProject.CurrentCell.RowIndex < 0)
                return;
            string projectName = "";
            if (dgvProject.CurrentRow != null)
                projectName = dgvProject.CurrentRow.Cells[0].Value?.ToString() ?? "";
            string projectIntroduce = "";
            foreach (Project project in _projectList)
            {
                if (project.ProjectName == projectName)
                {
                    projectIntroduce = project.Introduce;
                    break;
                }
            }
            txbProjectName.Text = projectName;
            txbIntroduce.Text = projectIntroduce;
        }
    }
}
