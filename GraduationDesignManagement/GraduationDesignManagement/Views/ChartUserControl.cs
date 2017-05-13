using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelDna.Integration.CustomUI;
using GraduationDesignManagement.Common;
using GraduationDesignManagement.MysqlData;

namespace GraduationDesignManagement.Views
{
    public partial class ChartUserControl : UserControl
    {
        //当前活动窗体句柄
        public CustomTaskPane TaskPaneChartUserControl { get; set; }
        public CustomTaskPane TaskPaneScorestAnalysis { get; set; }


        public List<Student> StudentList { get; set; }
        public List<GraduationDesign> GraduationList { get; set; }


        public DataTable ScoreDataTable { get; set; }

        public ChartUserControl()
        {
            InitializeComponent();
        }

        private void ChartUserControl_Load(object sender, EventArgs e)
        {
            rdgvScore.ColumnHeadersHeight = 40;
            rdgvScore.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            rdgvScore.AddSpanHeader(0, 6, "毕业设计成绩（开题、中期、结题各占30%、0%、40%）");//合并列

            List<string> iitemStList = new List<string>()
            {
                "开题成绩",
                "中期成绩",
                "结题成绩",
                "总成绩",
            };
            lvwElemSource.Items.Clear();
            foreach (string s in iitemStList)
            {
                ListViewItem listViewItem=new ListViewItem();
                listViewItem.SubItems[0].Text = s;
                lvwElemSource.Items.Add(listViewItem);
            }
        }

        private void btnPrevious_Click(object sender, EventArgs e)
        {
            TaskPaneChartUserControl.Visible = false;
            TaskPaneScorestAnalysis.Visible = true;
        }

        private void btnComplete_Click(object sender, EventArgs e)
        {
            if (lvwElemSelected.Items.Count <= 0)
            {
                MessageBox.Show(@"请选择要导出的成绩类型！",@"提醒",MessageBoxButtons.OK,MessageBoxIcon.Information);
                return;
            }
            List<string> colNameList=new List<string>();
            foreach (ListViewItem item in lvwElemSelected.Items)
                colNameList.Add(item.SubItems[0].Text);
            object[,] dataObj = GetDataobj(colNameList);
            ExcelHelper.ExportToExcel(dataObj);
        }

        private object[,] GetDataobj(List<string>colNameList )
        {
            colNameList.Insert(0, "姓名");
            colNameList.Insert(0, "学号");
            object[,] dataObj=new object[ScoreDataTable.Rows.Count+1, colNameList.Count];
  
            for (int i = 0; i < colNameList.Count; i++)
                dataObj[0, i] = colNameList[i];

            for (int i = 1; i < dataObj.GetLength(0); i++)
            {
                for (int j = 0; j < colNameList.Count; j++)
                {
                    switch (colNameList[j])
                    {
                        case "学号":
                            dataObj[i, j] = ScoreDataTable.Rows[i - 1][0];
                            break;
                        case "姓名":
                            dataObj[i, j] = ScoreDataTable.Rows[i - 1][1];
                            break;
                        case "开题成绩":
                            dataObj[i, j] = ScoreDataTable.Rows[i - 1][2];
                            break;
                        case "中期成绩":
                            dataObj[i, j] = ScoreDataTable.Rows[i - 1][3];
                            break;
                        case "结题成绩":
                            dataObj[i, j] = ScoreDataTable.Rows[i - 1][4];
                            break;
                        case "总成绩":
                            dataObj[i, j] = ScoreDataTable.Rows[i - 1][5];
                            break;
                    }
                }
            }
            
            return dataObj;
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
        
    }
}
