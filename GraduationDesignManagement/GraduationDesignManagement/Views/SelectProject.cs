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
            _dataQuery = DataQuery.Instance;
            _projectList = _dataQuery.GetProjectList(null);
            foreach (Project project in _projectList)
            {
                DataGridViewRow dataRow = new DataGridViewRow();
                dataRow.Cells.Add(new DataGridViewTextBoxCell() { Value = project.ProjectName });
                dataRow.Cells.Add(new DataGridViewTextBoxCell() { Value = project.Projectcode });
                if (project.State == "1")
                {
                    dataRow.DefaultCellStyle.BackColor = Color.Aquamarine;
                }
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
            string teacherId = "";
            foreach (Project project in _projectList)
            {
                if (project.ProjectName == projectName)
                {
                    teacherId = project.TeacherId;
                    projectIntroduce = project.Introduce;
                    break;
                }
            }
            DataRow dataRow = _dataQuery.GetTeacherDataRow(teacherId);
            Teacher teacher = _dataQuery.DataRowToObject<Teacher>(dataRow);
            txbTeacherName.Text = teacher.TeacherName;
            txbProjectName.Text = projectName;
            txbIntroduce.Text = projectIntroduce;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            DataGridViewRow dataGridViewRow = dgvProject.CurrentRow;
            if (dataGridViewRow == null)
                return;
            string projectCode = dataGridViewRow.Cells[1].Value.ToString();

            Project project=new Project();
            foreach (Project project1 in _projectList)
            {
                if (project1.Projectcode == projectCode)
                {
                    project = project1;
                    break;
                }
            }
            if (project.State == "1")
            {
                MessageBox.Show(@"该项目已被选择请选择其他项目！", @"选择项目");
                return;
            }

            int temp = _dataQuery.SelectProject(project, _logonBusinessService.UserId);
            if (temp == 1)
            {
                MessageBox.Show(@"项目选择成功！", @"选择项目");
                TaskPaneSelectProject.Visible = false;
            }
        }

        private void cmbExport_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnExport.Text = cmbExport.Text;
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            object[,] objects=null;
            switch (btnExport.Text.Trim())
            {
                case "导出全部":
                    objects = new object[dgvProject.Rows.Count, 3];
                    objects[0, 0] = "项目名称";
                    objects[0, 0] = "指导老师";
                    objects[0, 0] = "项目说明";
                    for (int i = 0; i < dgvProject.Rows.Count; i++)
                    {
                        string projectName = dgvProject.Rows[i].Cells[0].Value.ToString();
                        objects[i + 1, 0] = projectName;

                        string teacherId = "";
                        string projectIntroduce = "";
                        foreach (Project project in _projectList)
                        {
                            if (project.ProjectName == projectName)
                            {
                                teacherId = project.TeacherId;
                                projectIntroduce = project.Introduce;
                                break;
                            }
                        }
                        DataRow dataRow = _dataQuery.GetTeacherDataRow(teacherId);
                        Teacher teacher = _dataQuery.DataRowToObject<Teacher>(dataRow);

                        objects[i + 1, 1] = teacher.TeacherName;
                        objects[i + 1, 2] = projectIntroduce;
                    }
                    break;
                case "导出选中":
                    objects = new object[2, 3];
                    objects[0, 0] = "项目名称";
                    objects[0, 0] = "指导老师";
                    objects[0, 0] = "项目说明";
                    objects[1, 0] = txbProjectName.Text;
                    objects[1, 0] = txbTeacherName.Text;
                    objects[1, 0] = txbIntroduce.Text;
                    ExcelHelper.ExportToExcel(objects);
                    break;
            }
        }
    }
}
