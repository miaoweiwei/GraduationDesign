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
using GraduationDesignManagement.EnumClass;
using GraduationDesignManagement.MysqlData;

namespace GraduationDesignManagement.Views
{
    public partial class ReplyGroup : UserControl
    {
        //当前活动窗体句柄
        //private readonly int _hwnd = (ExcelHelper.GetXlApplication()).ActiveWindow.Hwnd;
        public CustomTaskPane TaskPaneReplyGroup { get; set; }

        private DataQuery _dataQuery;

        List<GraduationDesign> _graduationList = new List<GraduationDesign>();
        List<Project> _projectList = new List<Project>();
        List<string> _studentIdList = new List<string>();
        List<string> _teacherIdList = new List<string>();
        List<string> _pleaTeacherIdList = new List<string>();
        List<Teacher> _teacherList = new List<Teacher>();
        List<Teacher> _pleaTeacherList = new List<Teacher>();
        List<Student> _studentList = new List<Student>();
        public ReplyGroup()
        {
            InitializeComponent();
        }

        private void ReplyGroup_Load(object sender, EventArgs e)
        {
            _dataQuery = DataQuery.Instance;
            _graduationList = _dataQuery.GetGraduationDesign(UserTypeInfo.Teacher, null);

            if (_graduationList == null || _graduationList.Count <= 0)
                return;

            _projectList = _dataQuery.GetProjectListByCode(_graduationList.Select(s => s.ProjectCode).ToList());

            _studentIdList = _graduationList.Select(s => s.StudentId).ToList();
            _teacherIdList = _graduationList.Select(s => s.TeacherId).ToList();
            _pleaTeacherIdList = _graduationList.Select(s => s.PleaTeacherId).ToList();
            _teacherList = _dataQuery.GeTeacherList(_teacherIdList);
            _pleaTeacherList = _dataQuery.GeTeacherList(_pleaTeacherIdList);
            _studentList = _dataQuery.GetStudentListById(_studentIdList);

            List<string> colName = new List<string>()
            {
                "分组","序号","学号","学生姓名","所在班级","毕业设计(论文)题目",
                "指导教师姓名","审阅成绩","评阅成绩","答辩成绩","总成绩","备注",
            };
            foreach (string s in colName)
            {
                ListViewItem listViewItem = new ListViewItem() { };
                listViewItem.SubItems[0].Text = s;
                lvwElemSource.Items.Add(listViewItem);
            }
            foreach (Teacher teacher in _pleaTeacherList)
            {
                ListViewItem listViewItem = new ListViewItem() { };
                listViewItem.SubItems[0].Text = teacher.TeacherId;
                listViewItem.SubItems.Add(teacher.TeacherName);
                lvwpleaTeacher.Items.Add(listViewItem);
            }
        }
        private void chbxAll_Click(object sender, EventArgs e)
        {
            bool state = chbxAll.Checked;

            if (lvwpleaTeacher.Items.Count == 0)
                return;
            foreach (ListViewItem listViewItem in lvwpleaTeacher.Items)
            {
                listViewItem.Checked = state;
            }
        }

        private object[,] GetObjData(List<string> pleaTeacheIdList, List<string> colNameList)
        {
            if (pleaTeacheIdList == null || pleaTeacheIdList.Count <= 0 || colNameList == null || colNameList.Count <= 0)
                return null;

            List<string> idList = new List<string>();
            List<Teacher> teacherList = _pleaTeacherList.FindAll(t => pleaTeacheIdList.Contains(t.TeacherId));
            idList = teacherList.Select(s => s.TeacherId).ToList();
            List<GraduationDesign> graduationList = _graduationList.FindAll(g => idList.Contains(g.PleaTeacherId));

            int col = teacherList.Count * 3 + graduationList.Count;
            object[,] objData = new object[col, colNameList.Count];
            
            int row = 0;
            for (int i = 0; i < teacherList.Count; i++)
            {
                List<GraduationDesign> graduations = graduationList.FindAll(g => g.PleaTeacherId == teacherList[i].TeacherId);

                objData[row, 0] = "导出时间："+DateTime.Now.ToString("yyyy年MM月dd日 HH:mm:ss")+ "  答辩小组："+ (i + 1) +"  答辩老师："+ teacherList[i].TeacherName;
                    row = row + 1;
                for (int j = 0; j < colNameList.Count; j++)
                    objData[row, j] = colNameList[j];
                
                for (int j = 0; j < graduations.Count; j++)
                {
                    for (int k = 0; k < colNameList.Count; k++)
                    {
                        switch (colNameList[k])
                        {
                            case "分组":
                                objData[row + j+1, k] = i + 1;
                                break;
                            case "序号":
                                objData[row + j+1, k] = j + 1;
                                break;
                            case "学号":
                                objData[row + j+1, k] = graduations[j].StudentId;
                                break;
                            case "学生姓名":
                                objData[row + j + 1, k] = _studentList.Find(s => s.StudentId == graduations[j].StudentId).StudentName;
                                break;
                            case "所在班级":
                                objData[row + j + 1, k] =
                                    _studentList.Find(s => s.StudentId == graduations[j].StudentId).Class;
                                break;
                            case "毕业设计(论文)题目":
                                objData[row + j + 1, k] =
                                    _projectList.Find(s => s.Projectcode == graduations[j].ProjectCode).ProjectName;
                                break;
                            case "指导教师姓名":
                                var teacher = _teacherList.Find(s => s.TeacherId == graduations[j].TeacherId);
                                objData[row + j + 1, k] = teacher.TeacherName;
                                break;
                        }
                    }
                }
                row = row+ graduations.Count+2;
            }
            return objData;
        }

        #region 移动

        private void btnSecDown_Click(object sender, EventArgs e)
        {
            MoveSelectedItemsSub(lvwElemSource, lvwElemSelected);
        }

        private void btnSecAllDown_Click(object sender, EventArgs e)
        {
            MoveAllItemsSub(lvwElemSource, lvwElemSelected);
        }

        private void btnSecUp_Click(object sender, EventArgs e)
        {
            MoveSelectedItemsSub(lvwElemSelected, lvwElemSource);
        }

        private void btnSecAllUp_Click(object sender, EventArgs e)
        {
            MoveAllItemsSub(lvwElemSelected, lvwElemSource);
        }

        private static void MoveSelectedItemsSub(ListView listViewFrom, ListView listViewTo)
        {
            if (listViewFrom.Items.Count == 0 || listViewFrom.SelectedIndices.Count == 0)
                return;

            listViewFrom.BeginUpdate();
            listViewTo.BeginUpdate();
            foreach (ListViewItem item in listViewFrom.SelectedItems)
            {
                listViewTo.Items.Add((ListViewItem)item.Clone());
                listViewFrom.Items.Remove(item);
            }

            listViewTo.EndUpdate();
            listViewFrom.EndUpdate();
        }

        private static void MoveAllItemsSub(ListView listViewFrom, ListView listViewTo)
        {

            if (listViewFrom.Items.Count == 0)
                return;

            listViewTo.BeginUpdate();
            foreach (ListViewItem item in listViewFrom.Items)
            {
                listViewTo.Items.Add((ListViewItem)item.Clone());
            }
            listViewTo.EndUpdate();
            listViewFrom.Items.Clear();

        }

        #endregion

        private void lvwpleaTeacher_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            bool state = true;
            foreach (ListViewItem listViewItem in lvwpleaTeacher.Items)
            {
                if (listViewItem.Checked != true)
                {
                    state = false;
                    break;
                }
            }
            chbxAll.Checked = state;
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            List<string> colNameList = new List<string>();
            foreach (ListViewItem listViewItem in lvwElemSelected.Items)
            {
                colNameList.Add(listViewItem.SubItems[0].Text);
            }
            List<string> pleaTeacheIdList = new List<string>();
            foreach (ListViewItem listViewItem in lvwpleaTeacher.Items)
            {
                if (listViewItem.Checked)
                {
                    pleaTeacheIdList.Add(listViewItem.SubItems[0].Text);
                }
            }
            object[,] obData = null;
            if (pleaTeacheIdList.Count <= 0 || colNameList.Count <= 0)
            {
                obData = new object[1, 1] { { "请选择答辩老师和要输入的列！"} };
            }
            else
            {
                obData = GetObjData(pleaTeacheIdList, colNameList);
            }
            
            if(obData == null)
                obData=new object[1,1] { {"没有数据！"} };

            ExcelHelper.ExportToExcel(obData);
            TaskPaneReplyGroup.Visible = false;
        }
    }
}
