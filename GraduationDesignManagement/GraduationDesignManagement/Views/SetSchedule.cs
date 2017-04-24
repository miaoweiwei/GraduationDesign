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
using GraduationDesignManagement.Common;
using GraduationDesignManagement.EnumClass;
using log4net.Appender;
using Excel= Microsoft.Office.Interop.Excel;

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
            SetDatePicker();
            _dataQuery = new DataQuery();
            DataTable dataTable = _dataQuery.GetScheduleDataTable();
            SetReplyDataTable(dataTable);
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
            dgvMiddle.DataSource = _middlDataTable;
            dgvEnd.DataSource = _endDataTable;
        }

        #region datagridview设置日期列

        DateTimePicker dtpBegin = new DateTimePicker();
        DateTimePicker dtpMiddle=new DateTimePicker();
        DateTimePicker dtpEnd = new DateTimePicker();

        private Rectangle rectangle;
        private void SetDatePicker()
        {
            dtpBegin.Visible = false;  //先不让它显示  
            dtpBegin.Format = DateTimePickerFormat.Custom;  //设置日期格式为2010-08-05  
            dtpBegin.CustomFormat = @"yyyy-MM-dd";
            dtpBegin.TextChanged += new EventHandler(dtp_TextChange); //为时间控件加入事件dtp_TextChange 
            dgvBegin.Controls.Add(dtpBegin);  //把时间控件加入DataGridView 

            dtpMiddle.Visible = false;  //先不让它显示  
            dtpMiddle.Format = DateTimePickerFormat.Custom;  //设置日期格式为2010-08-05  
            dtpMiddle.CustomFormat = @"yyyy-MM-dd";
            dtpMiddle.TextChanged += new EventHandler(dtp_TextChange); //为时间控件加入事件dtp_TextChange 
            dgvMiddle.Controls.Add(dtpMiddle);  //把时间控件加入DataGridView 

            dtpEnd.Visible = false;  //先不让它显示  
            dtpEnd.Format = DateTimePickerFormat.Custom;  //设置日期格式为2010-08-05  
            dtpEnd.CustomFormat = @"yyyy-MM-dd";
            dtpEnd.TextChanged += new EventHandler(dtp_TextChange); //为时间控件加入事件dtp_TextChange 
            dgvEnd.Controls.Add(dtpEnd);  //把时间控件加入DataGridView 
        }

        private void dtp_TextChange(object sender, EventArgs e)
        {
            DateTimePicker dateTimePicker=sender as DateTimePicker;
            if (dateTimePicker == null)
                return;

            switch (tabControl.SelectedTab.Name)
            {
                case "tabBegin":
                    dgvBegin.CurrentCell.Value = dateTimePicker.Value.ToString();
                    break;
                case "tabMiddle":
                    dgvMiddle.CurrentCell.Value = dateTimePicker.Value.ToString();
                    break;
                case "tabEnd":
                    dgvEnd.CurrentCell.Value = dateTimePicker.Value.ToString();
                    break;
            }
        }

        private void dataTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                DataGridView dataGridView = sender as DataGridView;
                if (dataGridView == null)
                    return;
                DateTimePicker dateTimePicker = new DateTimePicker();
                switch (tabControl.SelectedTab.Name)
                {
                    case "tabBegin":
                        dateTimePicker = dtpBegin;
                        break;
                    case "tabMiddle":
                        dateTimePicker = dtpMiddle;
                        break;
                    case "tabEnd":
                        dateTimePicker = dtpEnd;
                        break;
                }
                int col = dataGridView.CurrentCell.ColumnIndex;
                int row = dataGridView.CurrentCell.RowIndex;

                if (col == 0 || col == 1)
                {
                    rectangle = dataGridView.GetCellDisplayRectangle(col, row, true); //得到所在单元格位置和大小  
                    dateTimePicker.Size = new Size(rectangle.Width, rectangle.Height); //把单元格大小赋给时间控件  
                    dateTimePicker.Location = new Point(rectangle.X, rectangle.Y); //把单元格位置赋给时间控件  
                    dateTimePicker.Visible = true;  //可以显示控件了  
                }
                else
                    dateTimePicker.Visible = false;
            }
            catch (Exception exception)
            {
                LogUtil.Error("毕业设计 日程设定：->"+exception);
            }
        }

        /***********当列的宽度变化时，时间控件先隐藏起来，不然单元格变大时间控件无法跟着变大哦***********/
        private void dataGridView_ColumnWidthChanged(object sender, DataGridViewColumnEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView == null)
                return;
            switch (dataGridView.Name)
            {
                case "dgvBegin":
                    dtpBegin.Visible = false;
                    break;
                case "dgvMiddle":
                    dtpMiddle.Visible = false;
                    break;
                case "dgvEnd":
                    dtpEnd.Visible = false;
                    break;
            }
        }
        
        /***********滚动条滚动时，单元格位置发生变化，也得隐藏时间控件，不然时间控件位置不动就乱了********/
        private void dataGridView_Scroll(object sender, ScrollEventArgs e)
        {
            DataGridView dataGridView = sender as DataGridView;
            if (dataGridView == null)
                return;
            switch (dataGridView.Name)
            {
                case "dgvBegin":
                    dtpBegin.Visible = false;
                    break;
                case "dgvMiddle":
                    dtpMiddle.Visible = false;
                    break;
                case "dgvEnd":
                    dtpEnd.Visible = false;
                    break;
            }
        }
        
        #endregion

        private void btnDataGridViewRowAdd_Click(object sender, EventArgs e)
        {
            switch (tabControl.SelectedTab.Name)
            {
                case "tabBegin":
                    _beginDataTable.Rows.Add();
                    break;
                case "tabMiddle":
                    _middlDataTable.Rows.Add();
                    break;
                case "tabEnd":
                    _endDataTable.Rows.Add();
                    break;
                default:
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            //关闭当前窗体
            TaskPaneSetSchedule.Visible = false;
        }
        
        /// <summary> 选择提交类型 </summary>
        private void cmbOk_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnOk.Text = cmbOk.Text;
        }
        
        /// <summary> 提交 或 导出 </summary>
        private void btnOk_Click(object sender, EventArgs e)
        {
            object[,] objectArr;
            switch (btnOk.Text)
            {
                case "提交并导出":
                    SubmitToMysql();
                    objectArr = GetObjects();
                    ExportToExcel(objectArr);
                    break;
                case "提交":
                    SubmitToMysql();
                    break;
                case "导出":
                    objectArr = GetObjects();
                    ExportToExcel(objectArr);
                    break;
            }
            //关闭当前窗体
            TaskPaneSetSchedule.Visible = false;
        }

        /// <summary> 提交 </summary>
        private void SubmitToMysql()
        {
            DataTable dataTable=new DataTable("schedule_table");

            dataTable.Columns.Add("datetype");
            dataTable.Columns.Add("begindate");
            dataTable.Columns.Add("enddate");
            dataTable.Columns.Add("matter");

            foreach (DataRow dataRow in _beginDataTable.Rows)
            {
                DataRow data = dataTable.NewRow();
                data.ItemArray=new object[]
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

                MySqlDataHelper.BulkInsert(InitConfig.MysqlConnectSt, dataTable);

            }
            catch (Exception exception)
            {

            }
        }

        /// <summary> 导出到Excel </summary> 
        private void ExportToExcel(object[,] objectArr)
        {
            if (objectArr == null || objectArr.GetLength(0)<2 || objectArr.GetLength(1) <=0)
                objectArr=new object[,] { {"无数据",""}, };
            Excel.Application xlApp = ExcelHelper.GetXlApplication();
            Excel.Worksheet xlSheet = xlApp.ActiveSheet;
            var xlRange = (Excel.Range)xlApp.Selection;
            var startRow = xlRange.Row;
            var startCol = xlRange.Column;
            
            int endRow = objectArr.GetLength(0) + startRow-1;
            int endCol = objectArr.GetLength(1) + startCol-1;

            ExcelHelper.SetData(xlSheet, startRow, startCol, endRow, endCol, objectArr);
        }

        /// <summary> 组织数据 </summary> 
        private object[,] GetObjects()
        {
            int rowBegin = dgvBegin.Rows.Count;
            int rowMiddle = dgvMiddle.Rows.Count;
            int rowEnd = dgvEnd.Rows.Count;

            int max = rowBegin;
            if (max<rowMiddle)
                max = rowMiddle;
            if(max<rowEnd)
                max = rowEnd;

            object[,] objectArr = new object[max+2, 9];
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
                Console.WriteLine(exception);
            }

            return objectArr;
        }
    }
}
