using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelDna.Integration.CustomUI;
using GraduationDesignManagement.BusinessServices;
using GraduationDesignManagement.Common;
using GraduationDesignManagement.EnumClass;
using log4net.Appender;
using Excel = Microsoft.Office.Interop.Excel;

namespace GraduationDesignManagement.Views
{
    public partial class SetSchedule : UserControl
    {
        //当前活动窗体句柄
        //private readonly int _hwnd = (ExcelHelper.GetXlApplication()).ActiveWindow.Hwnd;
        public CustomTaskPane TaskPaneSetSchedule { get; set; }

        private DataQuery _dataQuery;

        private DataTable _beginDataTable;
        private DataTable _endDataTable;
        private DataTable _middlDataTable;

        public SetSchedule()
        {
            InitializeComponent();
        }

        private void SetSchedule_Load(object sender, EventArgs e)
        {
            _dataQuery = new DataQuery();
            DataTable dataTable = _dataQuery.GetScheduleDataTable();
            SetReplyDataTable(dataTable);

            dgvBegin.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvMiddle.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEnd.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void SetReplyDataTable(DataTable dataTable)
        {
            if (dataTable == null)
                return;
            _beginDataTable = new DataTable();
            _beginDataTable.Columns.Add("BeginDate");
            _beginDataTable.Columns.Add("EndDate");
            _beginDataTable.Columns.Add("Matter");

            _endDataTable = new DataTable();
            _endDataTable.Columns.Add("BeginDate");
            _endDataTable.Columns.Add("EndDate");
            _endDataTable.Columns.Add("Matter");

            _middlDataTable = new DataTable();
            _middlDataTable.Columns.Add("BeginDate");
            _middlDataTable.Columns.Add("EndDate");
            _middlDataTable.Columns.Add("Matter");

            foreach (DataRow dataTableRow in dataTable.Rows)
            {
                DataRow dataRow;
                switch (dataTableRow[0].ToString())
                {
                    case "BeginReply":
                        dataRow = _beginDataTable.NewRow();
                        dataRow.ItemArray = new[]
                        {
                            dataTableRow[1],
                            dataTableRow[2],
                            dataTableRow[3],
                        };
                        _beginDataTable.Rows.Add(dataRow);
                        break;
                    case "MiddleReply":
                        dataRow = _middlDataTable.NewRow();
                        dataRow.ItemArray = new[]
                        {
                            dataTableRow[1],
                            dataTableRow[2],
                            dataTableRow[3],
                        };
                        _middlDataTable.Rows.Add(dataRow);
                        break;
                    case "EndReply":
                        dataRow = _endDataTable.NewRow();
                        dataRow.ItemArray = new[]
                        {
                            dataTableRow[1],
                            dataTableRow[2],
                            dataTableRow[3],
                        };
                        _endDataTable.Rows.Add(dataRow);
                        break;
                }
            }
            dgvBegin.DataSource = _beginDataTable;
            if (_beginDataTable.Rows.Count > 0) dgvBegin.Rows[0].Cells[0].Selected = true;

            dgvMiddle.DataSource = _middlDataTable;
            if (_middlDataTable.Rows.Count > 0) dgvMiddle.Rows[0].Cells[0].Selected = true;

            dgvEnd.DataSource = _endDataTable;
            if (_endDataTable.Rows.Count > 0) dgvEnd.Rows[0].Cells[0].Selected = true;
        }


        #region 开题
        
        /// <summary> 选择修改或添加 </summary> 
        private void cmbMatter1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string text= cmbMatter1.Text.Trim();
            btnMatter1.Text = text;
            if (text== "修改事项")
                ModifyMatter(dgvBegin, _beginDataTable, out _beginDataRow, dtpStart1, dtpEnd1, txbMatter1);
        }

        /// <summary> 修改事项的DataGridViewRow </summary>
        private DataRow _beginDataRow;

        /// <summary> 添加或修改 </summary> 
        private void btnMatter1_Click(object sender, EventArgs e)
        {
            switch (btnMatter1.Text)
            {
                case "添加事项":
                    AddDataGridViewRow(_beginDataTable, dtpStart1,dtpEnd1,txbMatter1);
                    break;
                case "修改事项":
                    ModifyMatter(_beginDataRow, dtpStart1, dtpEnd1, txbMatter1);
                    break;
            }
            dgvBegin.DataSource = _beginDataTable;
            dgvBegin.Refresh();
        }

        /// <summary> 删除 </summary> 
        private void btnDelete1_Click(object sender, EventArgs e)
        {
            int row = dgvBegin.CurrentCell.RowIndex;
            if(row<0)
                return;
            _beginDataTable.Rows.RemoveAt(row);
            dgvBegin.DataSource = _beginDataTable;
            dgvBegin.Refresh();
        }

        /// <summary> 选择提交类型 </summary>
        private void cmbOk1_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnOk1.Text = cmbOk1.Text;
        }

        /// <summary> 提交 或 导出 </summary>
        private void btnOk1_Click(object sender, EventArgs e)
        {
            object[,] objectArr;
            switch (btnOk1.Text.Trim())
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
            TaskPaneSetSchedule.Visible = false;
        }

        /// <summary> 关闭 </summary>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            //关闭当前窗体
            TaskPaneSetSchedule.Visible = false;
        }

        private void dgvBegin_CurrentCellChanged(object sender, EventArgs e)
        {
            if (btnMatter1.Text.Trim() == "修改事项")
            {
                ModifyMatter(dgvBegin, _beginDataTable, out _beginDataRow, dtpStart1, dtpEnd1, txbMatter1);
            }
        }

        private void dtpStart1_CloseUp(object sender, EventArgs e)
        {
            DateTime startDateTime = dtpStart1.Value;
            DateTime endDateTime = dtpEnd1.Value;
            if (startDateTime > endDateTime)
            {
                MessageBox.Show(@"开始时间应小于结束时间！");
                dtpStart1.Value = startDateTime.AddDays(-1);
            }

        }

        private void dtpEnd1_CloseUp(object sender, EventArgs e)
        {
            DateTime startDateTime = dtpStart1.Value;
            DateTime endDateTime = dtpEnd1.Value;
            if (startDateTime > endDateTime)
            {
                MessageBox.Show(@"结束时间应大于开始时间！");
                dtpEnd1.Value = endDateTime.AddDays(1);
            }
        }

        #endregion
        
        #region 中期

        private void cmbMatter2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string text = cmbMatter2.Text.Trim();
            btnMatter2.Text = text;
            if (text == "修改事项")
                ModifyMatter(dgvMiddle, _middlDataTable, out _middlDataRow, dtpStart2, dtpEnd2, txbMatter2);
        }

        private DataRow _middlDataRow;

        private void btnMatter2_Click(object sender, EventArgs e)
        {
            switch (btnMatter2.Text)
            {
                case "添加事项":
                    AddDataGridViewRow(_middlDataTable, dtpStart2, dtpEnd2, txbMatter2);
                    break;
                case "修改事项":
                    ModifyMatter(_middlDataRow, dtpStart2, dtpEnd2, txbMatter2);
                    break;
            }
            dgvMiddle.DataSource = _middlDataTable;
            dgvMiddle.Refresh();
        }

        private void btnDelete2_Click(object sender, EventArgs e)
        {
            int row = dgvMiddle.CurrentCell.RowIndex;
            if (row < 0)
                return;
            _middlDataTable.Rows.RemoveAt(row);
            dgvMiddle.DataSource = _middlDataTable;
            dgvMiddle.Refresh();
        }

        private void cmbOk2_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnOk2.Text = cmbOk2.Text;
        }

        private void btnOk2_Click(object sender, EventArgs e)
        {
            object[,] objectArr;
            switch (btnOk2.Text.Trim())
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
            TaskPaneSetSchedule.Visible = false;
        }

        private void btnCancel2_Click(object sender, EventArgs e)
        {
            //关闭当前窗体
            TaskPaneSetSchedule.Visible = false;
        }

        private void dgvMiddle_CurrentCellChanged(object sender, EventArgs e)
        {
            if (btnMatter2.Text.Trim() == "修改事项")
            {
                ModifyMatter(dgvMiddle, _middlDataTable, out _middlDataRow, dtpStart2, dtpEnd2, txbMatter2);
            }
        }

        private void dtpStart2_CloseUp(object sender, EventArgs e)
        {
            DateTime startDateTime = dtpStart2.Value;
            DateTime endDateTime = dtpEnd2.Value;
            if (startDateTime > endDateTime)
            {
                MessageBox.Show(@"开始时间应小于结束时间！");
                dtpStart2.Value = startDateTime.AddDays(-1);
            }
        }

        private void dtpEnd2_CloseUp(object sender, EventArgs e)
        {
            DateTime startDateTime = dtpStart2.Value;
            DateTime endDateTime = dtpEnd2.Value;
            if (startDateTime > endDateTime)
            {
                MessageBox.Show(@"结束时间应大于开始时间！");
                dtpEnd2.Value = endDateTime.AddDays(1);
            }
        }

        #endregion

        #region 结题

        private void cmbMatter3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            string text = cmbMatter3.Text.Trim();
            btnMatter3.Text = text;
            if (text == "修改事项")
                ModifyMatter(dgvEnd, _endDataTable, out _endDataRow, dtpStart3, dtpEnd3, txbMatter3);
        }

        private DataRow _endDataRow;

        private void btnMatter3_Click(object sender, EventArgs e)
        {
            switch (btnMatter3.Text.Trim())
            {
                case "添加事项":
                    AddDataGridViewRow(_endDataTable, dtpStart3, dtpEnd3, txbMatter3);
                    break;
                case "修改事项":
                    ModifyMatter(_endDataRow, dtpStart3, dtpEnd3, txbMatter3);
                    break;
            }
            dgvEnd.DataSource = _endDataTable;
            dgvEnd.Refresh();
        }

        private void btnDelete3_Click(object sender, EventArgs e)
        {
            int row = dgvEnd.CurrentCell.RowIndex;
            if (row < 0)
                return;
            _endDataTable.Rows.RemoveAt(row);
            dgvEnd.DataSource = _endDataTable;
            dgvEnd.Refresh();
        }

        private void cmbOk3_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnOk3.Text = cmbOk3.Text;
        }

        private void btnOk3_Click(object sender, EventArgs e)
        {
            object[,] objectArr;
            switch (btnOk3.Text.Trim())
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
            TaskPaneSetSchedule.Visible = false;
        }

        private void btnCancel3_Click(object sender, EventArgs e)
        {
            //关闭当前窗体
            TaskPaneSetSchedule.Visible = false;
        }

        private void dgvEnd_CurrentCellChanged(object sender, EventArgs e)
        {
            if (btnMatter3.Text.Trim() == "修改事项")
            {
                ModifyMatter(dgvEnd, _endDataTable, out _endDataRow, dtpStart3, dtpEnd3, txbMatter3);
            }
        }

        private void dtpStart3_CloseUp(object sender, EventArgs e)
        {
            DateTime startDateTime = dtpStart3.Value;
            DateTime endDateTime = dtpEnd3.Value;
            if (startDateTime > endDateTime)
            {
                MessageBox.Show(@"开始时间应小于结束时间！");
                dtpStart3.Value= startDateTime.AddDays(-1);
            }
        }

        private void dtpEnd3_CloseUp(object sender, EventArgs e)
        {
            DateTime startDateTime = dtpStart3.Value;
            DateTime endDateTime = dtpEnd3.Value;
            if (startDateTime > endDateTime)
            {
                MessageBox.Show(@"结束时间应大于开始时间！");
                dtpEnd3.Value = endDateTime.AddDays(1);
            }
        }

        #endregion

        /// <summary> 提交 </summary>
        private void SubmitToMysql()
        {
            DataTable dataTable = new DataTable("schedule_table");

            dataTable.Columns.Add("datetype");
            dataTable.Columns.Add("begindate");
            dataTable.Columns.Add("enddate");
            dataTable.Columns.Add("matter");

            foreach (DataRow dataRow in _beginDataTable.Rows)
            {
                DataRow data = dataTable.NewRow();
                data.ItemArray = new object[]
                {
                    "BeginReply",
                    dataRow[0],
                    dataRow[1],
                    dataRow[2],
                };
                dataTable.Rows.Add(data);
            }
            foreach (DataRow dataRow in _middlDataTable.Rows)
            {
                DataRow data = dataTable.NewRow();
                data.ItemArray = new object[]
                {
                    "MiddleReply",
                    dataRow[0],
                    dataRow[1],
                    dataRow[2],
                };
                dataTable.Rows.Add(data);
            }
            foreach (DataRow dataRow in _endDataTable.Rows)
            {
                DataRow data = dataTable.NewRow();
                data.ItemArray = new object[]
                {
                    "EndReply",
                    dataRow[0],
                    dataRow[1],
                    dataRow[2],
                };
                dataTable.Rows.Add(data);
            }
            try
            {
                MySqlDataHelper.BatchDeleteByTableName(InitConfig.MysqlConnectSt, "schedule_table");
                MySqlDataHelper.BulkInsert(InitConfig.MysqlConnectSt, dataTable);
            }
            catch (Exception exception)
            {
                LogUtil.Error("毕业设日程设计提交出错->" + exception);
            }
        }

        /// <summary> 组织数据 </summary> 
        private object[,] GetObjects()
        {
            int rowBegin = dgvBegin.Rows.Count;
            int rowMiddle = dgvMiddle.Rows.Count;
            int rowEnd = dgvEnd.Rows.Count;

            int max = rowBegin;
            if (max < rowMiddle)
                max = rowMiddle;
            if (max < rowEnd)
                max = rowEnd;

            object[,] objectArr = new object[max + 2, 9];
            objectArr[0, 0] = "开题";
            objectArr[0, 3] = "开题";
            objectArr[0, 6] = "结题";
            objectArr[1, 0] = "开始时间";
            objectArr[1, 1] = "结束时间";
            objectArr[1, 2] = "事项";

            objectArr[1, 3] = "开始时间";
            objectArr[1, 4] = "结束时间";
            objectArr[1, 5] = "事项";

            objectArr[1, 6] = "开始时间";
            objectArr[1, 7] = "结束时间";
            objectArr[1, 8] = "事项";
            try
            {
                for (int i = 0; i < dgvBegin.Rows.Count; i++)
                {
                    objectArr[i + 2, 0] = dgvBegin.Rows[i].Cells[0].Value.ToString();
                    objectArr[i + 2, 1] = dgvBegin.Rows[i].Cells[1].Value.ToString();
                    objectArr[i + 2, 2] = dgvBegin.Rows[i].Cells[2].Value.ToString();
                }
                for (int i = 0; i < dgvMiddle.Rows.Count; i++)
                {
                    objectArr[i + 2, 3] = dgvMiddle.Rows[i].Cells[0].Value.ToString();
                    objectArr[i + 2, 4] = dgvMiddle.Rows[i].Cells[1].Value.ToString();
                    objectArr[i + 2, 5] = dgvMiddle.Rows[i].Cells[2].Value.ToString();
                }
                for (int i = 0; i < dgvEnd.Rows.Count; i++)
                {
                    objectArr[i + 2, 6] = dgvEnd.Rows[i].Cells[0].Value.ToString();
                    objectArr[i + 2, 7] = dgvEnd.Rows[i].Cells[1].Value.ToString();
                    objectArr[i + 2, 8] = dgvEnd.Rows[i].Cells[2].Value.ToString();
                }
            }
            catch (Exception exception)
            {
                LogUtil.Error("日程设定 组织数据出错->"+exception);
            }

            return objectArr;
        }
        
        /// <summary>
        /// 添加事项
        /// </summary>
        private void AddDataGridViewRow(DataTable dataTable, DateTimePicker startDate, DateTimePicker endDate, TextBox textBox)
        {
            if (string.IsNullOrEmpty(textBox.Text))
            {
                MessageBox.Show(@"请填写事项");
                return;
            }

            DataRow dataRow = null;

            dataRow = dataTable.NewRow();
                    dataRow.ItemArray=new object[]
                    {
                        startDate.Value.ToString("yyyy-MM-dd"),
                        endDate.Value.ToString("yyyy-MM-dd"),
                        textBox.Text,
                    };
            dataTable.Rows.Add(dataRow);
        }

        /// <summary>
        /// 修改事项时 取出要修改的行数据
        /// </summary>
        private void ModifyMatter(DataGridView dataGridView,DataTable dataTable ,out DataRow dataRow ,DateTimePicker startDate, DateTimePicker endDate,TextBox textBox)
        {
            var row = dataGridView.CurrentCell.RowIndex;
            dataRow = dataTable.Rows[row];

            DateTime starDateTime, endDateTime;
            if (DateTime.TryParse(dataRow[0].ToString(), out starDateTime))
                startDate.Value = starDateTime;
            if (DateTime.TryParse(dataRow[1].ToString(), out endDateTime))
                endDate.Value = endDateTime;
            textBox.Text = dataRow[2].ToString();
        }

        /// <summary>
        /// 修改事项
        /// </summary>
        private void ModifyMatter(DataRow dataRow, DateTimePicker startDate, DateTimePicker endDate, TextBox textBox)
        {
            string matter = textBox.Text.Trim();
            if (string.IsNullOrEmpty(matter))
            {
                MessageBox.Show(@"请填写事项");
                return;
            }

            dataRow.ItemArray=new object[]
            {
                startDate.Value.ToString("yy年MM月dd日"),
                endDate.Value.ToString("yy年MM月dd日"),
                matter
            };
        }
    }
}
