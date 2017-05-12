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
            DataQuery dataQuery = DataQuery.Instance;
            _graduationList = dataQuery.GetGraduationDesign(UserTypeInfo.Teacher, null);
            _studentIdList = _graduationList.Select(s => s.StudentId).ToList();
            _teacherIdList = _graduationList.Select(s => s.TeacherId).ToList();
            _pleaTeacherIdList = _graduationList.Select(s => s.PleaTeacherId).ToList();
            _teacherList = dataQuery.GeTeacherList(_teacherIdList);
            _pleaTeacherList = dataQuery.GeTeacherList(_pleaTeacherIdList);
            _studentList = dataQuery.GetStudentListById(_studentIdList);

            List<string> colName = new List<string>()
            {
                "分组","序号","学号","学号","学生姓名","所在班级","毕业设计(论文)题目",
                "指导教师姓名","审阅","评阅","答辩","成绩明细","总成绩","备注",
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
        
        private object[,] GetObjData()
        {
            List<string>colNameList=new List<string>();
            foreach (ListViewItem listViewItem in lvwElemSelected.Items)
            {
                colNameList.Add(listViewItem.SubItems[0].Text);
            }
            List<string>pleaTeacheIdList=new List<string>();
            foreach (ListViewItem listViewItem in lvwpleaTeacher.Items)
            {
                if (listViewItem.Checked)
                {
                    pleaTeacheIdList.Add(listViewItem.SubItems[0].Text);
                }
            }

            int col = _pleaTeacherList.Count * 3 + _studentList.Count;
            object[,] objData = new object[col, 12];

            //时间：2017年5月14日 8:30     地点：15 - 518         答辩小组：  陈林 李斌   陈哲
            //分组  序号 学号  学生姓名 所在班级    毕业设计(论文)题目 指导教师姓名  审阅 评阅  答辩    成绩明细 总成绩 备注

            for (int i = 0; i < _pleaTeacherList.Count; i++)
            {
                string stHead = "导出时间：" + DateTime.Now.ToString("yyy年MM月dd日 HH:mm:ss") +
                                " 答辩人：" + _pleaTeacherList[i].TeacherName;
                objData[i + 1, 0] = stHead;
                objData[i + 2, 0] = "分组";
                objData[i + 2, 1] = "序号";
                objData[i + 2, 2] = "学号";
                objData[i + 2, 3] = "学生姓名";
                objData[i + 2, 4] = "所在班级";
                objData[i + 2, 5] = "毕业设计(论文)题目";
                objData[i + 2, 6] = "指导教师姓名";
                objData[i + 2, 6] = "审阅";
                objData[i + 2, 6] = "评阅";
                objData[i + 2, 6] = "答辩";
                objData[i + 2, 6] = "成绩明细";
                objData[i + 2, 6] = "总成绩";
                objData[i + 2, 6] = "备注";

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
            MoveSelectedItemsSub(lvwElemSelected,lvwElemSource);
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
            object[,] obData = GetObjData();
            ExcelHelper.ExportToExcel(obData);
        }
    }
}
