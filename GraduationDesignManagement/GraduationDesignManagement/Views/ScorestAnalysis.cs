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
    public partial class ScorestAnalysis : UserControl
    {
        //当前活动窗体句柄
        public CustomTaskPane TaskPaneScorestAnalysis { get; set; }
        public CustomTaskPane TaskPaneChartUserControl { get; set; }

        /// <summary>
        /// 是否第一次显示当前窗口
        /// </summary>
        private bool isFirst = true;

        private DataQuery _dataQuery;
        private LogonBusinessService _logonBusinessService;

        /// <summary> 所有的毕业设计项目 </summary>
        List<GraduationDesign> _graduationList = new List<GraduationDesign>();
        /// <summary> 所有的毕业设计指导老师 </summary>
        List<Teacher> _teacherList = new List<Teacher>();
        /// <summary> 所有的毕业设计答辩老师 </summary>
        List<Teacher> _pleaTeacherList = new List<Teacher>();
        /// <summary> 所有参加毕业设计的学生 </summary>
        List<Student> _studentList = new List<Student>();

        List<ListViewItem> _leftListViewItem = new List<ListViewItem>();
        List<ListViewItem> _rightListViewItem = new List<ListViewItem>();

        public ScorestAnalysis()
        {
            InitializeComponent();
        }

        private void ScorestAnalysis_Load(object sender, EventArgs e)
        {
            _logonBusinessService=LogonBusinessService.Instance;
            _dataQuery = DataQuery.Instance;
            Teacher teacher = (Teacher) _logonBusinessService.UserObj;
            if (teacher.Position == "系主任")
            {
                _graduationList = _dataQuery.GetGraduationDesign(UserTypeInfo.Teacher, null);
                _teacherList = _dataQuery.GeTeacherList(_graduationList.Select(s => s.TeacherId).ToList());
                _pleaTeacherList = _dataQuery.GeTeacherList(_graduationList.Select(s => s.PleaTeacherId).ToList());
                _studentList = _dataQuery.GetStudentListById(_graduationList.Select(s => s.StudentId).ToList());
            }
            else
            {
                List<GraduationDesign> graduation1 = _dataQuery.GetGraduationDesign(_logonBusinessService.UserTypeInfo, teacher.TeacherId);
                List<GraduationDesign> graduation2 = _dataQuery.GetGraduationDesign(teacher.TeacherId);
                _graduationList.AddRange(graduation1);
                _graduationList.AddRange(graduation2);
                _teacherList=new List<Teacher>() {teacher};
                _pleaTeacherList = new List<Teacher>() { teacher };

                _studentList = _dataQuery.GetStudentListById(_graduationList.Select(s => s.StudentId).ToList());

            }
            

            List<string> itmStList = new List<string>()
            {
                "全部","答辩老师","指导老师",
            };
            cbxType.DataSource = itmStList;
        }

        private void cbxType_TextChanged(object sender, EventArgs e)
        {
            List<Teacher> teachers = new List<Teacher>();
            switch (cbxType.Text)
            {
                case "全部":
                    lvwpleaTeacher.Enabled = false;
                    SetLeftStudentListView(_studentList);
                    return;
                case "答辩老师":
                    lvwpleaTeacher.Enabled = true;
                    teachers = _pleaTeacherList;
                    break;
                case "指导老师":
                    lvwpleaTeacher.Enabled = true;
                    teachers = _teacherList;
                    break;
            }
            lvwpleaTeacher.Items.Clear();
            foreach (Teacher teacher in teachers)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.SubItems[0].Text = teacher.TeacherId;
                listViewItem.SubItems.Add(teacher.TeacherName);
                lvwpleaTeacher.Items.Add(listViewItem);
            }
        }

        private void chbxAll_Click(object sender, EventArgs e)
        {
            bool state = chbxAll.Checked;
            if (lvwpleaTeacher.Items.Count <= 0)
                return;
            foreach (ListViewItem item in lvwpleaTeacher.Items)
                item.Checked = state;
        }

        private void lvwpleaTeacher_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            bool state = true;
            string type = cbxType.Text;
            List<Student> studentList = new List<Student>();
            List<ListViewItem> listViewList = new List<ListViewItem>();
            foreach (ListViewItem listViewItem in lvwpleaTeacher.Items)
            {
                if (listViewItem.Checked != true)
                    state = false;
                else
                {
                    string teacherId = listViewItem.SubItems[0].Text;
                    List<Student> stuTemp = new List<Student>();
                    List<string> studentIdList = new List<string>();
                    switch (type)
                    {
                        case "答辩老师":
                            studentIdList =
                                _graduationList.FindAll(s => s.PleaTeacherId == teacherId)
                                    .Select(s => s.StudentId)
                                    .ToList();
                            stuTemp = _studentList.FindAll(s => studentIdList.Contains(s.StudentId));
                            studentList.AddRange(stuTemp);
                            break;
                        case "指导老师":
                            studentIdList =
                                _graduationList.FindAll(s => s.TeacherId == teacherId)
                                    .Select(s => s.StudentId)
                                    .ToList();
                            stuTemp = _studentList.FindAll(s => studentIdList.Contains(s.StudentId));
                            studentList.AddRange(stuTemp);
                            break;
                    }
                }
            }
            chbxAll.Checked = state;
            _leftListViewItem.Clear();
            foreach (Student student in studentList)
            {
                ListViewItem item = new ListViewItem();
                item.SubItems[0].Text = student.StudentId;
                item.SubItems.Add(student.StudentName);
                _leftListViewItem.Add(item);
            }
            lvwElemSource.VirtualListSize = _leftListViewItem.Count;
        }

        private void lvwElemSource_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (_leftListViewItem == null || _leftListViewItem.Count == 0)
                return;
            e.Item = _leftListViewItem[e.ItemIndex];
            if (e.ItemIndex == _leftListViewItem.Count)
                _leftListViewItem = null;
        }

        private void lvwElemSelected_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (_rightListViewItem == null || _rightListViewItem.Count == 0)
                return;
            e.Item = _rightListViewItem[e.ItemIndex];
            if (e.ItemIndex == _rightListViewItem.Count)
                _rightListViewItem = null;
        }

        private void SetLeftStudentListView(List<Student> studentList)
        {
            _leftListViewItem.Clear();
            foreach (Student student in studentList)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.SubItems[0].Text = student.StudentId;
                listViewItem.SubItems.Add(student.StudentName);
                listViewItem.SubItems.Add(student.Class);
                listViewItem.Tag = student.StudentId;
                _leftListViewItem.Add(listViewItem);
            }
            lvwElemSource.Items.Clear();
            lvwElemSource.VirtualListSize = _leftListViewItem.Count;
            lvwElemSource.Refresh();
        }

        #region 移动

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(lvwElemSource, lvwElemSelected, MoveDirect.Right);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(lvwElemSource, lvwElemSelected, MoveDirect.Left);
        }

        private void btnAllDown_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(lvwElemSource, lvwElemSelected, MoveDirect.RightAll);
        }

        private void btnAllUp_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(lvwElemSource, lvwElemSelected, MoveDirect.LeftAll);
        }

        private void MoveSelectedItem(ListView leftListView, ListView rightListView, MoveDirect direct)
        {
            switch (direct)
            {
                case MoveDirect.Right:
                    MoveRight(leftListView, rightListView);
                    break;
                case MoveDirect.Left:
                    MoveLeft(leftListView, rightListView);
                    break;
                case MoveDirect.RightAll:
                    MoveRightAll(leftListView, rightListView);
                    break;
                case MoveDirect.LeftAll:
                    MoveLeftAll(leftListView, rightListView);
                    break;
            }
            SetLabNum(leftListView, rightListView);
        }

        private void SetLabNum(ListView leftListView, ListView rightListView)
        {
            labLeftNum.Text = leftListView.Items.Count.ToString();
            labRightNum.Text = rightListView.Items.Count.ToString();
        }
        /// <summary>
        /// 向右边移动
        /// </summary>
        /// <param name="leftListView"></param>
        /// <param name="rightListView"></param>
        private void MoveRight(ListView leftListView, ListView rightListView)
        {
            if (leftListView.Items.Count == 0 || leftListView.SelectedIndices.Count == 0)
                return;
            leftListView.BeginUpdate();
            rightListView.BeginUpdate();
            var num = 0;
            foreach (var index in leftListView.SelectedIndices)
            {
                //遍历几次就移除几项，索引就减少几
                int currIndex = (int)index - num;
                if (!_rightListViewItem.Exists(
                        delegate (ListViewItem lvt)
                        {
                            if (lvt.Tag.Equals(_leftListViewItem[currIndex].Tag))
                                return true;
                            else
                                return false;
                        }))
                {
                    _rightListViewItem.Add(_leftListViewItem[currIndex]);
                    rightListView.VirtualListSize = _rightListViewItem.Count;
                }
                _leftListViewItem.RemoveAt(currIndex);
                leftListView.VirtualListSize = _leftListViewItem.Count;
                num++;
            }
            rightListView.EndUpdate();
            leftListView.EndUpdate();
        }

        /// <summary>
        /// 向左边
        /// </summary>
        /// <param name="leftListView"></param>
        /// <param name="rightListView"></param>
        private void MoveLeft(ListView leftListView, ListView rightListView)
        {
            if (rightListView.Items.Count == 0 || rightListView.SelectedIndices.Count == 0)
                return;
            leftListView.BeginUpdate();
            rightListView.BeginUpdate();
            var num = 0;
            foreach (var index in rightListView.SelectedIndices)
            {
                //遍历几次就移除几项，索引就减少几
                int currIndex = (int)index - num;
                if (!_leftListViewItem.Exists(
                        delegate (ListViewItem lvt)
                        {
                            if (lvt.Tag.Equals(_rightListViewItem[currIndex].Tag))
                                return true;
                            else
                                return false;
                        }))
                {
                    _leftListViewItem.Add(_rightListViewItem[currIndex]);
                    leftListView.VirtualListSize = _leftListViewItem.Count;
                }
                _rightListViewItem.RemoveAt(currIndex);
                rightListView.VirtualListSize = _rightListViewItem.Count;
                num++;
            }
            rightListView.EndUpdate();
            leftListView.EndUpdate();
        }

        /// <summary>
        /// 向右边全部
        /// </summary>
        /// <param name="leftListView"></param>
        /// <param name="rightListView"></param>
        private void MoveRightAll(ListView leftListView, ListView rightListView)
        {
            if (leftListView.Items.Count == 0)
                return;
            _rightListViewItem =
                   _rightListViewItem.Union(_leftListViewItem).Distinct(new Compare<ListViewItem>((x, y) => x.Tag.Equals(y.Tag))).ToList();
            rightListView.VirtualListSize = _rightListViewItem.Count;
            _leftListViewItem.Clear();
            leftListView.VirtualListSize = _leftListViewItem.Count;
        }

        /// <summary>
        /// 向左边全部
        /// </summary>
        /// <param name="leftListView"></param>
        /// <param name="rightListView"></param>
        private void MoveLeftAll(ListView leftListView, ListView rightListView)
        {
            if (rightListView.Items.Count == 0)
                return;
            _leftListViewItem =
                   _leftListViewItem.Union(_rightListViewItem).Distinct(new Compare<ListViewItem>((x, y) => x.Tag.Equals(y.Tag))).ToList();
            leftListView.VirtualListSize = _leftListViewItem.Count;
            _rightListViewItem.Clear();
            rightListView.VirtualListSize = _rightListViewItem.Count;
        }

        #endregion

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (_rightListViewItem.Count <= 0)
            {
                MessageBox.Show(@"请选择要导出的学生！",@"提醒",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }


            List<string> studentIdList = new List<string>();
            foreach (ListViewItem item in _rightListViewItem)
            {
                studentIdList.Add(item.SubItems[0].Text);
            }

            _studentedList = _studentList.FindAll(s => studentIdList.Contains(s.StudentId));
            _graduationedList = _graduationList.FindAll(s => studentIdList.Contains(s.StudentId));

            //关闭当前窗体，显示第二步窗体
            TaskPaneScorestAnalysis.Visible = false;
            if (isFirst)
            {
                TaskPaneChartUserControl.VisibleStateChange += TaskPaneChartUserControl_VisibleStateChange;
                isFirst = false;
            }
            TaskPaneChartUserControl.Visible = true;
        }
        /// <summary> 选择导出毕业设计成绩的学生 </summary>
        List<Student> _studentedList = new List<Student>();
        /// <summary> 选择导出毕业设计成绩的项目 </summary>
        List<GraduationDesign> _graduationedList = new List<GraduationDesign>();
        private void TaskPaneChartUserControl_VisibleStateChange(CustomTaskPane customTaskPaneInst)
        {
            if (!customTaskPaneInst.Visible) return;
            ((ChartUserControl)customTaskPaneInst.ContentControl).StudentList = _studentedList;
            ((ChartUserControl)customTaskPaneInst.ContentControl).GraduationList = _graduationedList;

            DataTable dataTable = new DataTable();
            dataTable.Columns.Add("StudentId");
            dataTable.Columns.Add("StudentName");
            dataTable.Columns.Add("BeginScore");
            dataTable.Columns.Add("MiddleScore");
            dataTable.Columns.Add("EndScore");
            dataTable.Columns.Add("SumScore");

            foreach (GraduationDesign design in _graduationedList)
            {
                DataRow dataRow = dataTable.NewRow();
                dataRow.ItemArray = new object[]
                {
                        design.StudentId,
                        _studentedList.Find(s => s.StudentId == design.StudentId).StudentName,
                        design.BeginScore,
                        design.MiddleScore,
                        design.EndScore,
                        Math.Round((design.BeginScore*0.3+design.MiddleScore*0.3+design.EndScore*0.4),0),
                };
                dataTable.Rows.Add(dataRow);
            }
            ((ChartUserControl)customTaskPaneInst.ContentControl).ScoreDataTable = dataTable;
            ((ChartUserControl)customTaskPaneInst.ContentControl).rdgvScore.DataSource = dataTable;
        }
    }
}
