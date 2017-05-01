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
using GraduationDesignManagement.EnumClass;
using GraduationDesignManagement.MysqlData;
using SumscopeAddIn.Views;

namespace GraduationDesignManagement.Views
{
    public partial class ChooseTearch : UserControl
    {
        //当前活动窗体句柄
        //private readonly int _hwnd = (ExcelHelper.GetXlApplication()).ActiveWindow.Hwnd;
        public CustomTaskPane TaskPaneChooseTearch { get; set; }

        private LogonBusinessService _logonBusinessService;
        private DataQuery _dataQuery;
        /// <summary> 系名称List </summary>
        private List<string> _deparList;
        /// <summary> 教师List </summary>
        private List<Teacher> _teacherList;
        /// <summary> 系对应老师Dic </summary>
        Dictionary<string,List<Teacher>>_deparTeacherDic=new Dictionary<string, List<Teacher>>();

        public ChooseTearch()
        {
            InitializeComponent();
        }

        private void ChooseTearch_Load(object sender, EventArgs e)
        {
            _logonBusinessService=LogonBusinessService.Instance;
            _dataQuery = DataQuery.Instance;
            _deparList = _dataQuery.GetDataTableDepartment();
            _teacherList = _dataQuery.GeTeacherList();

            _deparList.Insert(0,"全部");
            _deparTeacherDic[_deparList[0]] = _teacherList;
            foreach (string teacherDeper in _deparList)
            {
                if (!_deparTeacherDic.Keys.Contains(teacherDeper))
                {
                    _deparTeacherDic[teacherDeper] = _teacherList.Where(s => s.Department == teacherDeper).ToList();
                }
            }
            cbxDepartment.DataSource = _deparList;
            SetLeftListViewValue(_teacherList);
            //已选的老师
            List<Teacher> selecTeacherList = _teacherList.Where(s => s.IsCan == "1").ToList();
            SetSelectListViewValue(selecTeacherList);
        }

        /// <summary>
        /// 筛选院系老师
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void cbxDepartment_TextChanged(object sender, EventArgs e)
        {
            List<Teacher> teacherList = new List<Teacher>();
            string deperSt = cbxDepartment.Text.Trim();
            string searchSt = txtSearch.Text.Trim();
            if (deperSt == "全部")
                teacherList = _teacherList;
            else
            {
                foreach (KeyValuePair<string, List<Teacher>> keyValuePair in _deparTeacherDic)
                {
                    if (keyValuePair.Key == deperSt)
                    {
                        teacherList = keyValuePair.Value;
                        break;
                    }
                }
            }

            if (!string.IsNullOrEmpty(searchSt))
                teacherList = SearchTeacherList(searchSt, teacherList);
            SetLeftListViewValue(teacherList);
        }
        
        /// <summary> 左边的Listview </summary>
        List<ListViewItem> _leftViewItemList = new List<ListViewItem>();
        /// <summary> 右边的Listview </summary>
        List<ListViewItem> _rightViewItemList = new List<ListViewItem>();
        /// <summary> 已选老师Listview </summary>
        List<ListViewItem> _selectViewItemList = new List<ListViewItem>();
        /// <summary>
        /// 显示搜索结果在左边listview上
        /// </summary>
        /// <param name="value"></param>
        private void SetLeftListViewValue(List<Teacher> value)
        {
            _leftViewItemList = new List<ListViewItem>();
            foreach (var item in value)
            {
                var items = new ListViewItem();
                items.SubItems[0].Text = item.TeacherId;
                items.SubItems.Add(item.TeacherName);
                items.SubItems.Add(item.Department);
                items.Tag = item.TeacherId;
                _leftViewItemList.Add(items);
            }
            mlvUp.Items.Clear();
            mlvUp.VirtualListSize = _leftViewItemList.Count;
            mlvUp.Refresh();
            labLeftNum.Text = mlvUp.Items.Count.ToString();
        }

        /// <summary> 设置已选老师Listview </summary>
        private void SetSelectListViewValue(List<Teacher> value)
        {
            _selectViewItemList = new List<ListViewItem>();
            foreach (var item in value)
            {
                var items = new ListViewItem();
                items.SubItems[0].Text = item.TeacherId;
                items.SubItems.Add(item.TeacherName);
                items.SubItems.Add(item.Department);
                items.Tag = item.TeacherId;
                _selectViewItemList.Add(items);
            }
            mlvSelect.Items.Clear();
            mlvSelect.VirtualListSize = _selectViewItemList.Count;
            mlvSelect.Refresh();
            labSelect.Text =@"共"+  mlvSelect.Items.Count.ToString()+ @"人";
        }

        private void mlvUp_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (_leftViewItemList == null || _leftViewItemList.Count == 0)
            {
                return;
            }

            e.Item = _leftViewItemList[e.ItemIndex];
            if (e.ItemIndex == _leftViewItemList.Count)
            {
                _leftViewItemList = null;
            }
        }

        private void mlvDown_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (_rightViewItemList == null || _rightViewItemList.Count == 0)
            {
                return;
            }

            e.Item = _rightViewItemList[e.ItemIndex];
            if (e.ItemIndex == _rightViewItemList.Count)
            {
                _rightViewItemList = null;
            }
        }

        private void mlvSelect_RetrieveVirtualItem(object sender, RetrieveVirtualItemEventArgs e)
        {
            if (_selectViewItemList == null || _selectViewItemList.Count == 0)
            {
                return;
            }

            e.Item = _selectViewItemList[e.ItemIndex];
            if (e.ItemIndex == _selectViewItemList.Count)
            {
                _selectViewItemList = null;
            }
        }

        /// <summary> 设置筛选数量 </summary>
        private void SetLabelNum()
        {
            labLeftNum.Text = _leftViewItemList.Count.ToString();
            labRightNum.Text = _rightViewItemList.Count.ToString();
        }
        
        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
            List<Teacher>teacherListTemp=new List<Teacher>();
            string daper = cbxDepartment.Text.Trim();
            foreach (KeyValuePair<string, List<Teacher>> keyValuePair in _deparTeacherDic)
            {
                if (keyValuePair.Key==daper)
                {
                    teacherListTemp = keyValuePair.Value;
                    break;
                }
            }

            List<Teacher>teacherList= SearchTeacherList(txtSearch.Text.Trim(), teacherListTemp);
            SetLeftListViewValue(teacherList);
        }

        private List<Teacher> SearchTeacherList(string param, List<Teacher> teacherList)
        {
            List<Teacher> thrListTemp = new List<Teacher>();
            List<Teacher> thrList = new List<Teacher>();
            param = param.ToUpper();
            foreach (Teacher teacher in teacherList)
            {
                if (teacher.TeacherId.ToUpper().StartsWith(param))
                {
                    thrListTemp.Add(teacher);
                    continue;
                }
                if (teacher.TeacherId.ToUpper().Contains(param))
                {
                    thrListTemp.Add(teacher);
                    continue;
                }
                if (teacher.TeacherName.ToUpper().Contains(param))
                {
                    thrListTemp.Add(teacher);
                    continue;
                }
                if (teacher.Department.ToUpper().Contains(param))
                {
                    thrListTemp.Add(teacher);
                    continue;
                }
            }
            thrList.AddRange(thrListTemp);
            return thrList;
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.ForeColor = Color.White;
            txtSearch.BackColor = Color.FromArgb(110, 108, 75);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.ForeColor=Color.Black;
            txtSearch.BackColor = Color.White;
        }

        #region 导入

        private void btnBatchImp_Click(object sender, EventArgs e)
        {
            var bondImpFrm = new ImportFrm(ImportParam);
            bondImpFrm.ShowDialog();
        }

        private void ImportParam(List<string> paramList)
        {
            foreach (var item in paramList)
            {
                var teacherList = _teacherList.Where(s => s.TeacherId == item).ToList();

                foreach (Teacher teacher in teacherList)
                {
                    if (!_rightViewItemList.Exists(
                        lvt => lvt.Tag.Equals(teacher.TeacherId)
                    ))
                    {
                        var items = new ListViewItem();
                        items.SubItems[0].Text = teacher.TeacherId;
                        items.SubItems.Add(teacher.TeacherName);
                        items.SubItems.Add(teacher.Department);
                        items.Tag = teacher.TeacherId;
                        _rightViewItemList.Add(items);
                        mlvDown.VirtualListSize = _rightViewItemList.Count;
                    }
                }
            }
            SetLabelNum();
        }

        #endregion

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            SubmitToMysql();
            MoveSelectAll();
        }
        private void btnDelect_Click(object sender, EventArgs e)
        {
            List<ListViewItem> itemListTemp = new List<ListViewItem>();
            List<string> tearList=new List<string>();
            if (mlvSelect.Items.Count == 0 || mlvSelect.SelectedIndices.Count == 0)
                return;
            mlvSelect.BeginUpdate();
            var num = 0;
            foreach (var index in mlvSelect.SelectedIndices)
            {
                //遍历几次就移除几项，索引就减少几
                int currIndex = (int)index - num;
                {
                    tearList.Add(_selectViewItemList[currIndex].SubItems[0].Text);
                }
                _selectViewItemList.RemoveAt(currIndex);
                mlvSelect.VirtualListSize = _selectViewItemList.Count;
                num++;
            }
            mlvSelect.EndUpdate();
            labSelect.Text = @"共" + mlvSelect.Items.Count.ToString() + @"人";
            _dataQuery.UpDataTeacherIsCan(tearList, 0, UserTypeInfo.Teacher);
        }


        private void btnExport_Click(object sender, EventArgs e)
        {
            object[,] objects= GetObjects(_selectViewItemList);
            ExcelHelper.ExportToExcel(objects);
        }

        /// <summary> 提交 </summary>
        private void SubmitToMysql()
        {
            List<string> teacherIdList = new List<string>();
            try
            {
                foreach (ListViewItem listViewItem in _rightViewItemList)
                {
                    teacherIdList.Add(listViewItem.SubItems[0].Text);
                }
                _dataQuery.UpDataTeacherIsCan(teacherIdList, 1, UserTypeInfo.Teacher);
            }
            catch (Exception exception)
            {
                LogUtil.Error("毕业设日候选老师提交出错->" + exception);
            }
        }
        /// <summary> 导出到Excel </summary> 
        private void ExportToExcel(object[,] objectArr)
        {
            if (objectArr == null || objectArr.GetLength(0) < 2 || objectArr.GetLength(1) <= 0)
                objectArr = new object[,] { { "无数据", "" }, };
            Microsoft.Office.Interop.Excel.Application xlApp = ExcelHelper.GetXlApplication();
            Microsoft.Office.Interop.Excel.Worksheet xlSheet = xlApp.ActiveSheet;
            var xlRange = (Microsoft.Office.Interop.Excel.Range)xlApp.Selection;
            var startRow = xlRange.Row;
            var startCol = xlRange.Column;

            int endRow = objectArr.GetLength(0) + startRow - 1;
            int endCol = objectArr.GetLength(1) + startCol - 1;

            ExcelHelper.SetData(xlSheet, startRow, startCol, endRow, endCol, objectArr);
        }
        /// <summary> 组织数据 </summary> 
        private object[,] GetObjects(List<ListViewItem> listViewItems)
        {
            object[,] objectArr = new object[listViewItems.Count + 2, 3];
            objectArr[0, 0] = ((Teacher)_logonBusinessService.UserObj).Department + "毕业设计候选老师";
            objectArr[1, 0] = "工号";
            objectArr[1, 1] = "姓名";
            objectArr[1, 2] = "院系";

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
                LogUtil.Error("选择老师 组织数据出错->" + exception);
            }

            return objectArr;
        }
        
        #region 移动

        private void btnDown_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(mlvUp, mlvDown, MoveDirect.Right);
        }

        private void btnAllDown_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(mlvUp, mlvDown, MoveDirect.RightAll);
        }

        private void btnUp_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(mlvUp, mlvDown, MoveDirect.Left);
        }

        private void btnAllUp_Click(object sender, EventArgs e)
        {
            MoveSelectedItem(mlvUp, mlvDown, MoveDirect.LeftAll);
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
            SetLabelNum();
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
                if (!_rightViewItemList.Exists(
                        delegate (ListViewItem lvt)
                        {
                            if (lvt.Tag.Equals(_leftViewItemList[currIndex].Tag))
                                return true;
                            else
                                return false;
                        }))
                {
                    _rightViewItemList.Add(_leftViewItemList[currIndex]);
                    rightListView.VirtualListSize = _rightViewItemList.Count;
                }
                _leftViewItemList.RemoveAt(currIndex);
                leftListView.VirtualListSize = _leftViewItemList.Count;
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
                if (!_leftViewItemList.Exists(
                        delegate (ListViewItem lvt)
                        {
                            if (lvt.Tag.Equals(_rightViewItemList[currIndex].Tag))
                                return true;
                            else
                                return false;
                        }))
                {
                    _leftViewItemList.Add(_rightViewItemList[currIndex]);
                    leftListView.VirtualListSize = _leftViewItemList.Count;
                }
                _rightViewItemList.RemoveAt(currIndex);
                rightListView.VirtualListSize = _rightViewItemList.Count;
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
            _rightViewItemList =
                   _rightViewItemList.Union(_leftViewItemList).Distinct(new Compare<ListViewItem>((x, y) => x.Tag.Equals(y.Tag))).ToList();
            rightListView.VirtualListSize = _rightViewItemList.Count;
            _leftViewItemList.Clear();
            leftListView.VirtualListSize = _leftViewItemList.Count;
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
            _leftViewItemList =
                   _leftViewItemList.Union(_rightViewItemList).Distinct(new Compare<ListViewItem>((x, y) => x.Tag.Equals(y.Tag))).ToList();
            leftListView.VirtualListSize = _leftViewItemList.Count;
            _rightViewItemList.Clear();
            rightListView.VirtualListSize = _rightViewItemList.Count;
        }
        
        /// <summary> 提交已选 </summary>
        private void MoveSelectAll()
        {
            if (mlvDown.Items.Count == 0)
                return;
            _selectViewItemList =
                   _selectViewItemList.Union(_rightViewItemList).Distinct(new Compare<ListViewItem>((x, y) => x.Tag.Equals(y.Tag))).ToList();
            mlvSelect.VirtualListSize = _selectViewItemList.Count;
            _rightViewItemList.Clear();
            mlvDown.VirtualListSize = _rightViewItemList.Count;
        }
        
        #endregion
    }

    //定义一个委托实现比较2个listviewitem
    public delegate bool EqualsComparer<T>(T x, T y);
    /// <summary>
    /// 弄一个类实现IEqualityComparer接口，来比较2个对象相等
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class Compare<T> : IEqualityComparer<T>
    {
        private EqualsComparer<T> _equalsComparer;

        public Compare(EqualsComparer<T> equalsComparer)
        {
            _equalsComparer = equalsComparer;
        }

        public bool Equals(T x, T y)
        {
            return null != _equalsComparer && _equalsComparer(x, y);
        }

        public int GetHashCode(T obj)
        {
            return obj.ToString().GetHashCode();
        }
    }
}
