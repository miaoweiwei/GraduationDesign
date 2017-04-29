using System;
using System.Collections.Generic;
using System.Threading;
using ExcelDna.Integration;
using Excel= Microsoft.Office.Interop.Excel;

namespace GraduationDesignManagement.Common
{
    public static class ExcelHelper
    {
        /// <summary>
        /// 获取当前excel application对象
        /// </summary>
        /// <returns></returns>
        public static Excel.Application GetXlApplication()
        {
            return (Excel.Application)ExcelDnaUtil.Application;
        }
        /// <summary>
        /// 在指定Sheet上获取指定起始Cell和指定结束Cell的Range
        /// </summary>
        /// <param name="sheet">指定Sheet</param>
        /// <param name="startRow">指定起始Cell的行号</param>
        /// <param name="startColumn">指定起始Cell的列号</param>
        /// <param name="endRow">指定结束Cell的行号</param>
        /// <param name="endColumn">指定结束Cell的列号</param>
        /// <returns></returns>
        public static Excel.Range SelectRange(Excel.Worksheet sheet, int startRow, int startColumn, int endRow, int endColumn)
        {
            Excel.Range rng = sheet.Range[(Excel.Range)sheet.Cells[startRow, startColumn], (Excel.Range)sheet.Cells[endRow, endColumn]];
            return rng;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="sheet"></param>
        /// <param name="startRow"></param>
        /// <param name="startColumn"></param>
        /// <param name="endRow"></param>
        /// <param name="endColumn"></param>
        /// <param name="objData"></param>
        public static void SetData(Excel.Worksheet sheet, int startRow, int startColumn, int endRow, int endColumn, object objData)
        {
            try
            {
                var dataRange = SelectRange(sheet, startRow, startColumn, endRow, endColumn);
                dataRange.Value = objData;
            }
            catch (Exception ee)
            {
                LogUtil.Error("数据写入错误" + ee);
            }
        }
        internal delegate List<string> sendRequestSyncCallBack(Dictionary<string, dynamic> date);
        /// <summary>
        /// 设置进度条
        /// </summary>
        /// <param name="callBack"></param>
        /// <param name="param"></param>
        /// <returns></returns>
        internal static object SetStatusBar(sendRequestSyncCallBack callBack, Dictionary<string, dynamic> param)
        {
            bool runStart = true;
            object result = null;
            Thread thread = new Thread(() =>
            {
                result = callBack(param);
                runStart = false;
            });
            thread.Start();

            while (runStart)
            {
                Thread.Sleep(100);
                SetStatusBar(0, 0, ChengeBar(20));
            }
            SetStatusBar(0, 0, "");
            return result;
        }

        private static int index = 0;
        private static string bar = "";
        public static string ChengeBar(int barLength)
        {
            if (barLength == 0)
            { return bar; }

            if (bar.Length == 0)
            { bar = bar.PadRight(barLength, '□'); }

            if (index >= bar.Length)
            { index = bar.Length; }

            char[] point = bar.ToCharArray();
            point[index] = (point[index] == '□' ? '■' : '□');
            bar = new string(point);

            if (index == (bar.Length - 1))
            {
                index = 0;
            }
            else
            {
                index++;
            }
            return bar;
        }

        static readonly Excel.Application XlApp = GetXlApplication();
        /// <summary>
        /// 设置进度条 
        /// </summary>
        /// <param name="curValue"></param>
        /// <param name="maxValue"></param>
        /// <param name="desText"></param>
        internal static void SetStatusBar(int curValue, int maxValue, string desText = "当前计算进度：")
        {
            try
            {
                if (XlApp == null)
                {
                    return;
                }
                if (curValue == 0 && maxValue == 0)
                {
                    if (string.IsNullOrEmpty(desText))
                        XlApp.StatusBar = false;
                    else
                    {
                        XlApp.StatusBar = desText;
                    }
                    return;
                }
                string s = "";
                if (curValue >= maxValue)
                {
                    s = s.PadRight(100, '■');
                    XlApp.StatusBar = desText + s + "  100%";
                }
                int j = curValue * 100 / maxValue;
                s = s.PadRight(j, '■');
                s = s.PadRight(100, '□');
                XlApp.StatusBar = desText + s + "  " + j + "%";
            }
            catch
            {

            }
        }
        
        /// <summary>
        /// 用excel表格展示数据
        /// </summary>
        /// <param name="row"> 开始单元格的行</param>
        /// <param name="col">开始单元格的列</param>
        /// <param name="objData">展示的内容</param>
        public static void PrintfoExcel(int row, int col, object[,] objData)
        {
            Excel.Application xlApp = (Excel.Application)ExcelDnaUtil.Application;
            Excel.Workbook xlWorkbook = xlApp.ActiveWorkbook;
            Excel.Worksheet xlSheet = xlWorkbook.ActiveSheet;
            Excel.Range xlRange = xlSheet.Range[xlSheet.Cells[row, col], xlSheet.Cells[row + objData.GetLength(0) - 1, col + objData.GetLength(1) - 1]];
            xlRange.Value2 = objData;
        }

        /// <summary>
        /// 把object[,]从当前选中的cell开始填充到excel
        /// </summary>
        /// <param name="objectArr"></param>
        public static void ExportToExcel(object[,] objectArr)
        {
            if (objectArr == null || objectArr.GetLength(0) < 2 || objectArr.GetLength(1) <= 0)
                objectArr = new object[,] { { "无数据", "" }, };
            Excel.Application xlApp = GetXlApplication();
            Excel.Worksheet xlSheet = xlApp.ActiveSheet;
            var xlRange = (Excel.Range)xlApp.Selection;
            var startRow = xlRange.Row;
            var startCol = xlRange.Column;

            int endRow = objectArr.GetLength(0) + startRow - 1;
            int endCol = objectArr.GetLength(1) + startCol - 1;

            SetData(xlSheet, startRow, startCol, endRow, endCol, objectArr);
        }
    }
}
