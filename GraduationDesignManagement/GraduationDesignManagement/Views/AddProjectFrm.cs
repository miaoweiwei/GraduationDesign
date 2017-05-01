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
using GraduationDesignManagement.Enum;
using GraduationDesignManagement.MysqlData;

namespace GraduationDesignManagement.Views
{
    public partial class AddProjectFrm : UserControl
    {
        //当前活动窗体句柄
        //private readonly int _hwnd = (ExcelHelper.GetXlApplication()).ActiveWindow.Hwnd;
        public CustomTaskPane TaskPaneAddProjectFrm { get; set; }

        private LogonBusinessService _logonBusinessService;
        private DataQuery _dataQuery;
        /// <summary> 项目List </summary>
        private  List<Project> _projectList= new List<Project>();
        /// <summary> 已提交的项目Code </summary>
        private List<string>_projectCodeList=new List<string>();
        
        public AddProjectFrm()
        {
            InitializeComponent();
        }

        private void AddProjectFrm_Load(object sender, EventArgs e)
        {
            _logonBusinessService=LogonBusinessService.Instance;
            _dataQuery= DataQuery.Instance;
            _projectList = _dataQuery.GetProjectList(_logonBusinessService.UserId);
            _projectCodeList = _projectList.Select(s => s.Projectcode).ToList();
            foreach (Project project in _projectList)
            {
                DataGridViewRow dataRow=new DataGridViewRow();
                dataRow.Cells.Add(new DataGridViewTextBoxCell() {Value = project.ProjectName});
                dataRow.Cells.Add(new DataGridViewTextBoxCell() {Value = project.Projectcode});
                dgvProject.Rows.Add(dataRow);
            }
        }

        private void dgvProject_CurrentCellChanged(object sender, EventArgs e)
        {
            if (!rbtnAdd.Checked)
                SetTextView();
        }

        private void RadioButton_CheckedChanged(object sender, EventArgs e)
        {
            if (!rbtnAdd.Checked)
                SetTextView();
            else
            {
                txbProjectName.Text = "";
                txbIntroduce.Text = "";
            }

            if (!rbtnView.Checked)
            {
                btnModifyOk.Enabled = true;
                txbProjectName.ReadOnly = false;
                txbIntroduce.ReadOnly = false;
            }
            else
            {
                btnModifyOk.Enabled = false;
                txbProjectName.ReadOnly = true;
                txbIntroduce.ReadOnly = true;
            }
        }

        /// <summary> 设置查看或修改 </summary>
        private void SetTextView()
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

        private void btnDelect_Click(object sender, EventArgs e)
        {
            string projectCode = "";
            if (dgvProject.CurrentRow != null)
            {
                projectCode = dgvProject.CurrentRow.Cells[1].Value.ToString();
                dgvProject.Rows.Remove(dgvProject.CurrentRow);
            }
            foreach (Project project in _projectList)
            {
                if (project.Projectcode == projectCode)
                {
                    _projectList.Remove(project);
                    break;
                }
            }
        }

        private void cmbOk_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnOk.Text = cmbOk.Text;
        }

        private void btnModifyOk_Click(object sender, EventArgs e)
        {
            string projectName = txbProjectName.Text.Trim();
            string st = txbIntroduce.Text.Trim();
            string projectCode = "";

            if (rtnModify.Checked)
            {
                if (dgvProject.CurrentRow != null)
                {
                    projectCode = dgvProject.CurrentRow.Cells[1].Value.ToString();
                    dgvProject.CurrentRow.Cells[0].Value = projectName;
                }
                foreach (Project project in _projectList)
                {
                    if (project.Projectcode == projectCode)
                    {
                        project.ProjectName = projectName;
                        project.Introduce = st;
                        break;
                    }
                }
            }
            else if (rbtnAdd.Checked)
            {
                projectCode = Guid.NewGuid().ToString("N");
                Project project = new Project()
                {
                    ProjectName = projectName,
                    Introduce = st,
                    TeacherId = _logonBusinessService.UserId,
                    Projectcode = projectCode,
                };
                _projectList.Add(project);
                DataGridViewRow dataRow = new DataGridViewRow();
                dataRow.Cells.Add(new DataGridViewTextBoxCell() { Value = project.ProjectName });
                dataRow.Cells.Add(new DataGridViewTextBoxCell() { Value = project.Projectcode });
                dgvProject.Rows.Add(dataRow);
                txbProjectName.Text = "";
                txbIntroduce.Text = "";
            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            object[,] objectArr;
            switch (btnOk.Text)
            {
                case "提交并导出":
                    SubmitToMysql();
                    objectArr = GetObjects();
                    ExcelHelper.ExportToExcel(objectArr);
                    break;
                case "提交":
                    SubmitToMysql();
                    break;
                case "导出":
                    objectArr = GetObjects();
                    ExcelHelper.ExportToExcel(objectArr);
                    break;
            }
            //关闭当前窗体
            TaskPaneAddProjectFrm.Visible = false;
        }
        /// <summary> 提交 </summary>
        private void SubmitToMysql()
        {
            try
            {
                List<string>delectList=new List<string>();
                List<Project>upDataProjects=new List<Project>();
                List<Project> addProjects = new List<Project>();
                List<string> codeTempList = _projectList.Select(s => s.Projectcode).ToList();
                foreach (string s in _projectCodeList)
                {
                    if (!codeTempList.Contains(s))
                        delectList.Add(s);
                }
                foreach (Project project in _projectList)
                {
                    if (!_projectCodeList.Contains(project.Projectcode))
                        addProjects.Add(project);
                    else
                        upDataProjects.Add(project);
                }

                if (delectList.Count > 0)
                    _dataQuery.DelectProject(delectList);
                if (upDataProjects.Count > 0)
                    _dataQuery.UpDataProject(upDataProjects);
                if (addProjects.Count > 0)
                    _dataQuery.InsertProject(addProjects);
            }
            catch (Exception exception)
            {
                LogUtil.Error("添加项目提交出错->" + exception);
            }
        }

        /// <summary> 组织数据 </summary> 
        private object[,] GetObjects()
        {
            object[,] objectArr = new object[_projectList.Count + 1, 2];
            objectArr[0, 0] = "项目名称";
            objectArr[0, 1] = "项目说明";
            try
            {
                for (int i = 0; i < _projectList.Count; i++)
                {
                    objectArr[i + 1, 0] = _projectList[i].ProjectName;
                    objectArr[i + 1, 1] = _projectList[i].Introduce;
                }
            }
            catch (Exception exception)
            {
                LogUtil.Error("添加项目 组织数据出错->" + exception);
            }
            return objectArr;
        }
    }
}
