using System;
using System.Drawing;
using GraduationDesignManagement.Common;
using Excel = Microsoft.Office.Interop.Excel;

namespace GraduationDesignManagement.Game
{
    /// <summary>
    /// 设置Excel单元格以适应贪吃蛇游戏
    /// </summary>
    public static class ExcelSet
    {
        private static Excel.Application _xlApp;

        /// <summary>
        /// 游戏界面范围大小
        /// </summary>
        /// <param name="xlWorksheet">sheet对象</param>
        /// <param name="sizeHeightX">活动范围的高就是行数</param>
        /// <param name="sSizeWidthY">活动范围的宽就是列数</param>
        /// <param name="rowHeight">小方块的高</param>
        /// <param name="columnWidth">小方块的宽</param>
        public static void SetCellSize(Excel.Worksheet xlWorksheet, int sizeHeightX, int sSizeWidthY, double rowHeight,
            double columnWidth)
        {
            try
            {
                _xlApp = xlWorksheet.Application;
                _xlApp.ActiveWindow.DisplayGridlines = false; //去掉网格线
                
                //设置该sheet的cells无边框
                xlWorksheet.Cells.Borders.LineStyle = Excel.XlLineStyle.xlLineStyleNone;
                
                Excel.Range range = xlWorksheet.Range[xlWorksheet.Cells[1, 1], xlWorksheet.Cells[sizeHeightX, sSizeWidthY]];
                //设置行高列宽
                range.RowHeight = rowHeight;
                range.ColumnWidth = columnWidth;

                //边框 设置每个单元格的边框 为无边框
                range.Interior.Color = Color.White;
                range.Cells.Borders.LineStyle = Excel.XlLineStyle.xlLineStyleNone;

                //设置range的外边框
                range.BorderAround(Excel.XlLineStyle.xlContinuous,
                    Excel.XlBorderWeight.xlMedium,
                    Excel.XlColorIndex.xlColorIndexAutomatic,
                    Color.Black.ToArgb());
                //range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;//每个单元格都有边框
                //range的外边框
                //Excel.XlLineStyle.xlContinuous 实线
                //Excel.XlLineStyle.xlDash 虚线
                //Excel.XlLineStyle.xlDashDot 。 点线点线 ._._._
                //Excel.XlLineStyle.xlDashDotDot
                //Excel.XlLineStyle.xlDot
                //Excel.XlLineStyle.xlDouble
                //Excel.XlLineStyle.xlLineStyleNone
                //Excel.XlLineStyle.xlSlantDashDot 斜虚线
            }
            catch (Exception exception)
            {
                LogUtil.Error("SetCellSize(Excel.Worksheet xlWorksheet, int sizeHeightX, int sSizeWidthY, double rowHeight, double columnWidth)->"+ exception);
            }
        }
    }
}