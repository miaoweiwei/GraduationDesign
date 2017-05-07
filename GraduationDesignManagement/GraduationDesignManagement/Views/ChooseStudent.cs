using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Windows.Forms;
using ExcelDna.Integration.CustomUI;
using GraduationDesignManagement.BusinessServices;
using GraduationDesignManagement.Common;
using GraduationDesignManagement.EnumClass;
using GraduationDesignManagement.MysqlData;

namespace GraduationDesignManagement.Views
{
    public partial class ChooseStudent : UserControl
    {
        //当前活动窗体句柄
        //private readonly int _hwnd = (ExcelHelper.GetXlApplication()).ActiveWindow.Hwnd;
        public CustomTaskPane TaskPaneChooseStudent { get; set; }

        private LogonBusinessService _logonBusinessService;
        private DataQuery _dataQuery;

        /// <summary> 老师所在系里的班级 </summary>
        private List<string> _clasList = new List<string>();
        /// <summary> 老师所在系的所有学生 </summary>
        private List<Student>_studentList=new List<Student>();
        private Dictionary<string,List<Student>>_derpStudenDic=new Dictionary<string, List<Student>>();

        List<Student>_studentSelectList=new List<Student>();
        public ChooseStudent()
        {
            InitializeComponent();
        }
        
        private void ChooseStudent_Load(object sender, EventArgs e)
        {
            _dataQuery = DataQuery.Instance;
            _logonBusinessService = LogonBusinessService.Instance;
            _clasList = _logonBusinessService.ClassList;
            _studentList = _dataQuery.GetStudentList(_clasList);
            
            //组织数据Dic
            foreach (string s in _clasList)
                if (!_derpStudenDic.Keys.Contains(s))
                    _derpStudenDic[s] = new List<Student>();

            //设置班级Listview
            foreach (Student student in _studentList)
                _derpStudenDic[student.Class].Add(student);
            SetClassListView(_clasList);

            //已选学生
            foreach (KeyValuePair<string, List<Student>> keyValuePair in _derpStudenDic)
            {
                if (_clasList.Contains(keyValuePair.Key))
                {
                    var students = keyValuePair.Value.Where(s => s.IsCan == "1").ToList();
                    _studentSelectList.AddRange(students);
                }
            }
            SetRightStudentListView(_studentSelectList);
        }
        
        #region 搜索

        private void mlvClass_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            List<string> selectClassList = new List<string>();
            foreach (ListViewItem item in mlvClass.Items)
            {
                if (item.Checked)
                    selectClassList.Add(item.Text);
            }
            List<Student> studentList = new List<Student>();
            
            foreach (string s in selectClassList)
            {
                studentList.AddRange(_derpStudenDic[s]);
            }
            string stTemp = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(stTemp))
            {
                if (selectClassList.Count <= 0)
                    studentList = _studentList;
                studentList = searchStudents(stTemp, studentList);
            }
            SetLeftStudentListView(studentList);
            SetLabNum();
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.FromArgb(110, 108, 75);
            txtSearch.ForeColor = Color.White;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.White;
            txtSearch.ForeColor = Color.Black;
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            string stTemp = txtSearch.Text.Trim();
            List<Student> studentList = new List<Student>();
            List<string> selectClassList = new List<string>();
            foreach (ListViewItem item in mlvClass.Items)
            {
                if (item.Checked)
                    selectClassList.Add(item.Text);
            }
            if (selectClassList.Count > 0)
            {
                foreach (string s in selectClassList)
                {
                    studentList.AddRange(_derpStudenDic[s]);
                }
            }
            else
            {
                studentList = _studentList;
            }
            studentList = searchStudents(stTemp, studentList);
            SetLeftStudentListView(studentList);
            SetLabNum();
        }
        /// <summary> 根据输入的参数搜索 Student </summary>
        private List<Student> searchStudents(string param, List<Student> studentList)
        {
            List<Student> studentListTemp = new List<Student>();
            param = param.ToUpper();
            foreach (Student student in studentList)
            {
                if (student.StudentId.ToUpper().Contains(param))
                {
                    studentListTemp.Add(student);
                    continue;
                }
                if (student.StudentName.ToUpper().Contains(param))
                {
                    studentListTemp.Add(student);
                    continue;
                }
                if (student.Class.ToUpper().Contains(param))
                {
                    studentListTemp.Add(student);
                    continue;
                }
            }
            return studentListTemp;
        }

        #endregion

        #region 设置MyListView

        List<ListViewItem> _classListViewItem = new List<ListViewItem>();
        List<ListViewItem>_leftListViewItem=new List<ListViewItem>();
        List<ListViewItem>_rightListViewItem=new List<ListViewItem>();
        
        /// <summary>
        /// 设置班级Listview
        /// </summary>
        /// <param name="clasList"></param>
        private void SetClassListView(List<string> clasList)
        {
            mlvClass.Items.Clear();
            foreach (string clas in clasList)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.SubItems[0].Text = clas;
                listViewItem.Tag = clas;
                mlvClass.Items.Add(listViewItem);
            }
            mlvClass.Refresh();
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
            mlvLeft.Items.Clear();
            mlvLeft.VirtualListSize = _leftListViewItem.Count;
            mlvLeft.Refresh();
        }

        private void SetRightStudentListView(List<Student> studentList)
        {
            _rightListViewItem.Clear();
            foreach (Student student in studentList)
            {
                ListViewItem listViewItem = new ListViewItem();
                listViewItem.SubItems[0].Text = student.StudentId;
                listViewItem.SubItems.Add(student.StudentName);
                listViewItem.SubItems.Add(student.Class);
                listViewItem.Tag = student.StudentId;
                _rightListViewItem.Add(listViewItem);
            }
            mlvReft.Items.Clear();
            mlvReft.VirtualListSize = _rightListViewItem.Count;
            mlvReft.Refresh();
        }
        
        private void mlvLeft_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (_leftListViewItem == null || _leftListViewItem.Count == 0)
                return;
            e.Item = _leftListViewItem[e.ItemIndex];
            if (e.ItemIndex == _leftListViewItem.Count)
                _leftListViewItem = null;
        }

        private void mlvReft_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (_rightListViewItem == null || _rightListViewItem.Count == 0)
                return;
            e.Item = _rightListViewItem[e.ItemIndex];
            if (e.ItemIndex == _rightListViewItem.Count)
                _rightListViewItem = null;
        }

        #endregion

        private void SetLabNum()
        {
            labLeftNum.Text = mlvLeft.Items.Count.ToString();
            labRightNum.Text = mlvReft.Items.Count.ToString();
        }

        //全选或全不选
        private void chbxAll_CheckedChanged(object sender, EventArgs e)
        {
            if (mlvClass.Items.Count <= 0) return;
            CheckBox checkBox = sender as CheckBox;
            if (checkBox == null) return;
            mlvClass.BeginUpdate();
            foreach (ListViewItem item in mlvClass.Items)
            {
                item.Checked = checkBox.Checked;
            }
            mlvClass.EndUpdate();   
        }
        
        private void cmbOk_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnOk.Text = cmbOk.Text.Trim();
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            object[,] objectArr;
            switch (btnOk.Text)
            {
                case "提交并导出":
                    SubmitToMysql();
                    objectArr = GetObjects(_rightListViewItem);
                    ExcelHelper.ExportToExcel(objectArr);
                    break;
                case "提交":
                    SubmitToMysql();
                    break;
                case "导出":
                    objectArr = GetObjects(_rightListViewItem);
                    ExcelHelper.ExportToExcel(objectArr);
                    break;
            }
            //关闭当前窗体
            TaskPaneChooseStudent.Visible = false;
        }

        /// <summary> 提交 </summary>
        private void SubmitToMysql()
        {
            List<string> studentIdList = new List<string>();
            try
            {
                foreach (ListViewItem listViewItem in _rightListViewItem)
                    studentIdList.Add(listViewItem.SubItems[0].Text);
                _dataQuery.UpDataTeacherIsCan(studentIdList, 1 ,UserTypeInfo.Student);


                List<string> cancelSelecyList =
                    _studentSelectList.Where(s => !studentIdList.Contains(s.StudentId))
                        .Select(s => s.StudentId)
                        .ToList();
                _dataQuery.UpDataTeacherIsCan(cancelSelecyList, 0, UserTypeInfo.Student);

            }
            catch (Exception exception)
            {
                LogUtil.Error("毕业设日候选学生提交出错->" + exception);
            }
        }

        /// <summary> 组织数据 </summary> 
        private object[,] GetObjects(List<ListViewItem> listViewItems)
        {
            object[,] objectArr = new object[listViewItems.Count + 2, 3];
            objectArr[0, 0] = ((Teacher)_logonBusinessService.UserObj).Department + "毕业设计候选学生";
            objectArr[1, 0] = "学号";
            objectArr[1, 1] = "姓名";
            objectArr[1, 2] = "班级";

            try
            {
                for (int i = 0; i < listViewItems.Count; i++)
                {
                    objectArr[i + 2, 0] = listViewItems[i].SubItems[0].Text;
                    objectArr[i + 2, 1] = listViewItems[i].SubItems[1].Text;
                    objectArr[i + 2, 2] = listViewItems[i].SubItems[2].Text;
                }
            }
            catch (Exception exception)
            {
                LogUtil.Error("选择学生 组织数据出错->" + exception);
            }

            return objectArr;
        }

        private void btnBatchImp_Click(object sender, EventArgs e)
        {
            var bondImpFrm = new ImportFrm(ImportParam);
            bondImpFrm.ShowDialog();
        }

        private void ImportParam(List<string> paramList)
        {
            foreach (var item in paramList)
            {
                var teacherList = _studentList.Where(s => s.StudentId == item).ToList();
                foreach (Student student in teacherList)
                {
                    if (!_rightListViewItem.Exists(
                        lvt => lvt.Tag.Equals(student.StudentId)
                    ))
                    {
                        var items = new ListViewItem();
                        items.SubItems[0].Text = student.StudentId;
                        items.SubItems.Add(student.StudentName);
                        items.SubItems.Add(student.Class);
                        items.Tag = student.StudentId;
                        _rightListViewItem.Add(items);
                        mlvReft.VirtualListSize = _rightListViewItem.Count;
                    }
                }
            }
            SetLabNum();
        }

        #region 移动

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(mlvLeft,mlvReft,MoveDirect.Right);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(mlvLeft, mlvReft, MoveDirect.Left);
        }

        private void btnAllDown_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(mlvLeft, mlvReft, MoveDirect.RightAll);
        }

        private void btnAllUp_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(mlvLeft, mlvReft, MoveDirect.LeftAll);
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
            SetLabNum();
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
    }
}
