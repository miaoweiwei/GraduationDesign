using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using GraduationDesignManagement.Common;
using Excel=Microsoft.Office.Interop.Excel;
using Point = System.Drawing.Point;

namespace GraduationDesignManagement.Game
{
    /// <summary>
    /// excel单元格显示类
    /// </summary>
    public static class ExcelDisplay
    {
        /// <summary>
        /// 刷新显示
        /// </summary>
        /// <param name="xlWorksheet">要绘制的worksheet</param>
        /// <param name="snakePointList">蛇身体的坐标集合</param>
        /// <param name="color">蛇身体的颜色</param>
        public static void Display(Excel.Worksheet xlWorksheet, List<Point> snakePointList,Color color)
        {
            try
            {
                var lastPoint = snakePointList[0];
                Excel.Range lsatRange = xlWorksheet.Cells[lastPoint.X + 1, lastPoint.Y + 1];

                snakePointList.RemoveAt(0);
                //避免当蛇穿过自己的身体时使身体变空
                if (!snakePointList.Any(point => (point.X == lastPoint.X) && (point.Y == lastPoint.Y)))
                {
                    lsatRange.Interior.Color = Color.White;
                }
                snakePointList.Insert(0, lastPoint);

                var currentPoint = snakePointList.Last();
                Excel.Range currentRange = xlWorksheet.Cells[currentPoint.X + 1, currentPoint.Y + 1];
                currentRange.Interior.Color = color;
            }
            catch (Exception e)
            {
                LogUtil.Error("刷新蛇显示：Display(Excel.Worksheet xlWorksheet, List<Point> snakePointList,Color color)" + e);
            }
        }

        /// <summary>
        /// 显示初始化的蛇
        /// </summary>
        /// <param name="xlWorksheet">要绘制的worksheet</param>
        /// <param name="snakePointList">蛇身体的坐标集合</param>
        /// <param name="color">初始化时蛇的颜色</param>
        public static void DisplayInit(Excel.Worksheet xlWorksheet,List<Point> snakePointList,Color color)
        {
            try
            {
                foreach (var point in snakePointList)
                {
                    Excel.Range range = xlWorksheet.Range[xlWorksheet.Cells[point.X + 1, point.Y + 1], xlWorksheet.Cells[point.X + 1, point.Y + 1]];
                    range.Interior.Color = color;
                }
            }
            catch (Exception e)
            {
                LogUtil.Error("显示初始化的蛇：DisplayInit(Excel.Worksheet xlWorksheet,List<Point> snakePointList,Color color)" + e);
            }
        }

        /// <summary>
        /// 显示果实
        /// </summary>
        /// <param name="xlWorksheet"></param>
        /// <param name="point">果实的位置</param>
        /// <param name="color">果实的颜色</param>
        public static void DislayRandomPoint(Excel.Worksheet xlWorksheet, Point point, Color color)
        {
            try
            {
                Excel.Range range = xlWorksheet.Range[xlWorksheet.Cells[point.X + 1, point.Y + 1], xlWorksheet.Cells[point.X + 1, point.Y + 1]];
                range.Interior.Color = color;
            }
            catch (Exception e)
            {
                LogUtil.Error("显示果实：DislayRandomPoint(Excel.Worksheet xlWorksheet, Point point, Color color->)" + e);
            }
        }

        /// <summary>
        /// 刷新显示cellList里的所有单元格，用于俄罗斯方块
        /// </summary>
        /// <param name="xlWorksheet">excel Worksheet</param>
        /// <param name="cellList">刷新显示的List</param>
        /// <param name="color">单元格的颜色</param>
        public static void DisplayCells(Excel.Worksheet xlWorksheet, List<Point> cellList, Color color)
        {
            try
            {
                Excel.Range cellRange;
                foreach (var point in cellList)
                {
                    cellRange = xlWorksheet.Cells[point.X + 1, point.Y + 1];
                    cellRange.Interior.Color = color;
                }
            }
            catch (Exception exception)
            {
                LogUtil.Error("刷新显示cellList里的所有单元格：DisplayCells(Excel.Worksheet xlWorksheet, List<Point> cellList, Color color)-->"+exception);
                throw;
            }
        }

        /// <summary>
        /// 指定范围单元格的内容清空背景色设置成白色
        /// </summary>
        /// <param name="xlWorksheet">指定的WorkSheet</param>
        /// <param name="startPoint">开始位置</param>
        /// <param name="endPoint">结束位置</param>
        public static void CellsClear(Excel.Worksheet xlWorksheet, Point startPoint, Point endPoint)
        {
            try
            {
                Excel.Range xlRange = xlWorksheet.Range[ xlWorksheet.Cells[startPoint.X, startPoint.Y], xlWorksheet.Cells[endPoint.X, endPoint.Y]];
                xlRange.ClearContents();
                xlRange.Interior.Color = Color.White;
            }
            catch (Exception exception)
            {
                LogUtil.Error("清空活动单元格：CellsClear(Excel.Worksheet xlWorksheet,int row,int col)"+exception);
            }
        }
    }
}
