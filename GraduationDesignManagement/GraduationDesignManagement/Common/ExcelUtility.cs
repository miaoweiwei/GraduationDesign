using System;
using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;
using System.Text.RegularExpressions;
using ICSharpCode.SharpZipLib.Zip;
using DataTable = System.Data.DataTable;
using Excel = Microsoft.Office.Interop.Excel;
using Word = Microsoft.Office.Interop.Word;

namespace GraduationDesignManagement.Common
{
    /// <summary>
    /// Excel 操作类
    /// </summary>
    public static class ExcelUtility
    {
        /// <summary>
        /// 获取excel的列Key的索引（将数值转化为字母）
        /// eg. 输入 30, 将会返回 'AD'.
        ///     输入 2, 将会返回 'B'
        /// 注意: 支持 A 到 ZZ.
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        ///
        public static string GetExcelColumnByIndex(int index)
        {
            string returnValue = string.Empty;

            if (index <= 26)
            {
                returnValue = Convert.ToChar(index + 65 - 1).ToString();
            }
            else
            {
                //decade
                int decade = (index - 1) / 26;
                //units
                int units = (index - 1) % 26;

                char charDecade = Convert.ToChar(decade + 65 - 1);
                char charUnits = Convert.ToChar(units + 65);

                returnValue = charDecade.ToString() + charUnits.ToString();
            }
            return returnValue;
        }

        /// <summary>
        /// 将字符串转换成Excel DateTime
        /// </summary>
        /// <param name="strDateTime">时间字符串</param>
        /// <returns>返回Excel DateTime</returns>
        public static DateTime ConvertExcelDate(string strDateTime)
        {
            DateTime dt = DateTime.MinValue;
            int intValue = 0;
            if (strDateTime.Length == 5 &&
                int.TryParse(strDateTime, out intValue))
            {
                dt = Convert.ToDateTime(DateTime.FromOADate(long.Parse(strDateTime)).ToShortDateString());
            }
            else
            {
                DateTime.TryParse(strDateTime, out dt);
            }
            return dt;
        }

        /// <summary>
        /// 返回OA到dt之间的天数
        /// </summary>
        /// <param name="OA"></param>
        /// <param name="dt"></param>
        /// <returns></returns>
        public static int GetOaDaySpanDtDate(string OA, DateTime dt)
        {
            return (Convert.ToDateTime(DateTime.FromOADate(long.Parse(OA)).ToShortDateString()) - Convert.ToDateTime(dt.ToShortDateString())).Days;
        }

        /// <summary>
        /// OA日期与今天相比,返回天OA到今天Today的天数
        /// </summary>
        /// <param name="OA"></param>
        /// <returns></returns>
        public static int GetOaDaySpanToday(string OA)
        {
            return (DateTime.FromOADate(long.Parse(OA)) - DateTime.Today).Days;
        }

        /// <summary>
        /// 关闭excel
        /// </summary>
        /// <param name="excelApplication"></param>
        /// <param name="workbook"></param>
        public static void DisposeExcel(Excel._Application excelApplication, Excel.Workbook workbook)
        {
            if (workbook != null)
            {
                workbook.Close();
            }

            if (excelApplication != null)
            {
                excelApplication.Quit();
                KillExcel.Kill(new IntPtr(excelApplication.Hwnd));
            }
        }

        /// <summary>
        /// 读取excel表数据到数据表（Datatable）
        /// </summary>
        /// <param name="filePath">excel的路径</param>
        /// <param name="sheetName">要读取的Sheet的名字</param>
        /// <param name="isFirstRowTitle">True=use sheet first row as column name. False=read from sheet first row, without column name.</param>
        /// True 表示用sheetName的第一行作为Datatable的列名，False 从sheetName的第一行开始读取没有列名
        /// <param name="password">excel的密码</param>
        /// <returns></returns>
        public static DataTable GetExcelDataTable(string filePath, string sheetName, bool isFirstRowTitle, string password)
        {
            DataTable dtReturn = null;
            Excel.Application excelApplication = null;
            Excel.Workbook workbook = null;

            try
            {
                if (!string.IsNullOrEmpty(password))
                {

                    excelApplication = new Excel.Application();
                    excelApplication.Visible = false;
                    workbook = excelApplication.Workbooks.Open(filePath, Type.Missing, false, Type.Missing, password, password,
                        Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

                }

                string connStr = string.Empty;
                if (isFirstRowTitle)
                {
                    connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=YES;IMEX=1\"";
                }
                else
                {
                    connStr = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filePath + ";Extended Properties=\"Excel 12.0;HDR=NO;IMEX=1\"";
                }
                OleDbConnection OleConn = new OleDbConnection(connStr);
                OleConn.Open();

                string sql = "SELECT * FROM [" + sheetName + "$]";
                OleDbDataAdapter OleDaExcel = new OleDbDataAdapter(sql, OleConn);
                DataSet OleDsExcle = new DataSet();
                OleDaExcel.Fill(OleDsExcle, sheetName);
                OleConn.Close();

                dtReturn = OleDsExcle.Tables[sheetName];
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //if (excelApplication != null)
                //{
                //    excelApplication.Visible = false;
                //    KillExcel.Kill(new IntPtr(excelApplication.Hwnd));
                //}
                DisposeExcel(excelApplication, workbook);
            }
            return dtReturn;
        }

        /// <summary>
        /// 由Datatable填充Excel 可设置标题
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="worksheet"></param>
        /// <param name="isGenerateTitle">是否生成标题</param>
        /// <param name="titleColor">标题颜色</param>
        /// <param name="TitleFontColor">标题字体颜色</param>
        public static void FillSheetByDataTable(DataTable dataTable, Excel.Worksheet worksheet, bool isGenerateTitle, Color titleColor, Color TitleFontColor)
        {
            if (dataTable == null || dataTable.Rows.Count == 0)
            {
                return;
            }

            Excel.Range rangedata;

            System.Reflection.Missing miss = System.Reflection.Missing.Value;

            if (isGenerateTitle)
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    Excel.Range rangeColumn = worksheet.Cells[1, i + 1];
                    rangeColumn.Value2 = dataTable.Columns[i].ColumnName.ToString();
                    rangeColumn.Interior.Color = titleColor;
                    rangeColumn.Font.Color = TitleFontColor;
                    rangeColumn.Font.Bold = true;
                    rangeColumn.Font.Size = 11;
                    rangeColumn.HorizontalAlignment = Excel.XlHAlign.xlHAlignCenter;
                    rangeColumn.BorderAround(Microsoft.Office.Interop.Excel.XlLineStyle.xlContinuous, Microsoft.Office.Interop.Excel.XlBorderWeight.xlThin, Microsoft.Office.Interop.Excel.XlColorIndex.xlColorIndexAutomatic, null);
                    rangeColumn.EntireColumn.AutoFit();
                    rangeColumn.EntireRow.AutoFit();
                }
            }

            rangedata = worksheet.get_Range("a2", miss);
            Excel.Range xlrang = null;
            int irowcount = dataTable.Rows.Count;
            int iparstedrow = 0, icurrsize = 0;
            int ieachsize = 1000;
            int icolumnaccount = dataTable.Columns.Count;
            object[,] objval = new object[ieachsize, icolumnaccount];
            icurrsize = ieachsize;
            while (iparstedrow < irowcount)
            {
                if ((irowcount - iparstedrow) < ieachsize)
                {
                    icurrsize = irowcount - iparstedrow;
                }
                for (int i = 0; i < icurrsize; i++)
                {
                    for (int j = 0; j < icolumnaccount; j++)
                    {
                        objval[i, j] = dataTable.Rows[i + iparstedrow][j].ToString();
                    }
                }
                string X = "A" + ((int)(iparstedrow + 2)).ToString();
                string col = "";
                if (icolumnaccount <= 26)
                {
                    col = ((char)('A' + icolumnaccount - 1)).ToString() + ((int)(iparstedrow + icurrsize + 1)).ToString();
                }
                else
                {
                    col = GetExcelColumnByIndex(icolumnaccount) + ((int)(iparstedrow + icurrsize + 1)).ToString();
                }
                xlrang = worksheet.get_Range(X, col);
                xlrang.Value2 = objval;
                xlrang.EntireRow.AutoFit();
                iparstedrow = iparstedrow + icurrsize;
            }
            Marshal.ReleaseComObject(xlrang);
            xlrang = null;
        }

        /// <summary>
        /// 设置Range的背景颜色
        /// </summary>
        /// <param name="range"></param>
        /// <param name="color"></param>
        public static void MarkRangeColor(Excel.Range range, Color color)
        {
            range.Interior.Color = color;
        }

        /// <summary>
        /// 设置Range的字体颜色
        /// </summary>
        /// <param name="range"></param>
        /// <param name="color"></param>
        public static void MarkRangeFontColor(Excel.Range range, Color color)
        {
            range.Font.Color = color;
        }

        /// <summary>
        /// 返回指定 字段 在Datatable中列索引
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="columnName"></param>
        /// <returns></returns>
        public static int GetColumnIndexByColumnName(DataTable dataTable, string columnName)
        {
            int returnValue = -1;
            if (dataTable.Columns.Contains(columnName))
            {
                for (int i = 0; i < dataTable.Columns.Count; i++)
                {
                    if (dataTable.Columns[i].ColumnName.Equals(columnName))
                    {
                        returnValue = i;
                        break;
                    }
                }
            }
            return returnValue;
        }

        /// <summary>
        /// 由 Datatable 中的列的索引和行的索引 来查找对应Excel中的Range单元格
        /// Datatable中要存在列名为columnName的列
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="columnName">Datatable中列的名字</param>
        /// <param name="rowIndexInDataTable">Datatable中行的索引</param>
        /// <param name="worksheet"></param>
        /// <returns></returns>
        public static Excel.Range GetRangeByColumnAndIndex(DataTable dataTable, string columnName, int rowIndexInDataTable, Excel.Worksheet worksheet)
        {
            int columnIndex = GetColumnIndexByColumnName(dataTable, columnName);
            string columnKey = GetExcelColumnByIndex(columnIndex + 1);
            var range = worksheet.Range[columnKey + (rowIndexInDataTable + 2)];
            return range;
        }

        /// <summary>
        /// Append comments, with formula originalComments + spliter + commentsToAppend
        /// </summary>
        /// <param name="originalComments"></param>
        /// <param name="commentsToAppend"></param>
        /// <param name="spliter"></param>
        /// <returns></returns>
        public static string AppendComments(string originalComments, string commentsToAppend, char spliter)
        {
            string returnValue = string.Empty;
            if (string.IsNullOrEmpty(originalComments))
            {
                returnValue = commentsToAppend;
            }
            else
            {
                returnValue = originalComments + spliter + commentsToAppend;
            }
            return returnValue;
        }

        /// <summary>
        /// 压缩文件
        /// </summary>
        /// <param name="GzipFileNameInput">要压缩的文件</param>
        /// <param name="CompressionLevel">0-9, 0=store only, 9=best compression 压缩级别</param>
        /// <param name="password">压缩文件密码. 如果没有密码就传空</param>
        /// <param name="GzipFileNameOutput">压缩文件的输出</param>
        /// <returns></returns>
        public static string CompressFile(string GzipFileNameInput, int CompressionLevel, string password, string GzipFileNameOutput)
        {
            ZipOutputStream s = new ZipOutputStream(File.Create(GzipFileNameOutput));
            try
            {
                if (!string.IsNullOrEmpty(password))
                {
                    s.Password = password;
                }

                s.SetLevel(CompressionLevel);   //0 - store only to 9 - means best compression

                FileStream fs = null;
                FileInfo file = new FileInfo(GzipFileNameInput);
                fs = file.Open(FileMode.Open, FileAccess.ReadWrite);

                byte[] data = new byte[2048];
                int size = 2048;
                ZipEntry entry = new ZipEntry(Path.GetFileName(file.Name));
                entry.DateTime = (file.CreationTime > file.LastWriteTime ? file.LastWriteTime : file.CreationTime);
                s.PutNextEntry(entry);
                while (true)
                {
                    size = fs.Read(data, 0, size);
                    if (size <= 0) break;
                    s.Write(data, 0, size);
                }
                fs.Close();
                //file.Delete();
                //Thread.Sleep(SleepTimer);
            }
            finally
            {
                s.Finish();
                s.Close();
            }
            return GzipFileNameOutput;
        }

        /// <summary>
        /// 通过日期一应的数字字符串获得对应的日期
        /// 如果输入数字,形成返回日期,否则输入作为输出返回
        /// </summary>
        /// <param name="date">输入日期的对应的数字字符串</param>
        /// <returns></returns>
        public static string GetDateFormation(string date)
        {
            string returnValue = string.Empty;
            string pattern = "^[0-9]*$";
            bool isNumber = false;
            Regex rx = new Regex(pattern);
            isNumber = rx.IsMatch(date);

            if (isNumber)
            {
                returnValue = DateTime.FromOADate(long.Parse(date)).Date.ToShortDateString();
            }
            else
            {
                returnValue = date;
            }
            return returnValue;
        }

        /// <summary>
        /// Validate the given date is date formation. support OA date.
        /// 验证给定的date是不是日期的形式
        /// </summary>
        /// <param name="date"></param>
        /// <returns></returns>
        public static bool IsDateFormationMmddyyyy(string date)
        {
            bool returnValue = false;
            date = GetDateFormation(date);
            string pattern = @"^(?:(?:(?:0?[1-9]|1[0-2])([-/.]?)(?:0?[1-9]|1[0-9]|2[0-8])|(?:0?[13-9]|1[0-2])([-/.]?)(?:29|30)|(?:0?[13578]|1[02])([-/.]?)31)([-/.]?)(?!0000)[0-9]{4}|29([-/.]?)0?2([-/.]?)(?:[0-9]{2}(?:0[48]|[2468][048]|[13579][26])|(?:0[48]|[2468][048]|[13579][26])00))$";
            Regex rx = new Regex(pattern);
            returnValue = rx.IsMatch(date);
            return returnValue;
        }

        private static String[] Ls_ShZ = { "零", "壹", "贰", "叁", "肆", "伍", "陆", "柒", "捌", "玖", "拾" };
        private static String[] Ls_DW_Zh = { "元", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾", "佰", "仟", "万" };
        private static String[] Num_DW = { "", "拾", "佰", "仟", "万", "拾", "佰", "仟", "亿", "拾", "佰", "仟", "万" };
        private static String[] Ls_DW_X = { "角", "分" };

        /// <summary>
        /// 人民币类型转换
        /// Double转换为对应的大写中文
        /// </summary>
        /// <param name="Num"></param>
        /// <returns></returns>
        public static String NumGetStr(Double Num)
        {
            Boolean iXSh_bool = false;//是否含有小数，默认没有(0则视为没有)
            Boolean iZhSh_bool = true;//是否含有整数,默认有(0则视为没有)
            string NumStr;//整个数字字符串
            string NumStr_Zh;//整数部分
            string NumSr_X = "";//小数部分
            string NumStr_DQ;//当前的数字字符
            string NumStr_R = "";//返回的字符串
            Num = Math.Round(Num, 2);//四舍五入取两位
            //各种非正常情况处理
            if (Num < 0)
                return "不转换欠条";
            if (Num > 9999999999999.99)
                return "很难想象谁会有这么多钱！";
            if (Num == 0)
                return Ls_ShZ[0];
            //判断是否有整数
            if (Num < 1.00)
                iZhSh_bool = false;
            NumStr = Num.ToString();
            NumStr_Zh = NumStr;//默认只有整数部分
            if (NumStr_Zh.Contains("."))
            {//分开整数与小数处理
                NumStr_Zh = NumStr.Substring(0, NumStr.IndexOf("."));
                NumSr_X = NumStr.Substring((NumStr.IndexOf(".") + 1), (NumStr.Length - NumStr.IndexOf(".") - 1));
                iXSh_bool = true;
            }
            if (NumSr_X == "" || int.Parse(NumSr_X) <= 0)
            {//判断是否含有小数部分
                iXSh_bool = false;
            }
            if (iZhSh_bool)
            {//整数部分处理
                NumStr_Zh = Reversion_Str(NumStr_Zh);//反转字符串
                for (int a = 0; a < NumStr_Zh.Length; a++)
                {//整数部分转换
                    NumStr_DQ = NumStr_Zh.Substring(a, 1);
                    if (int.Parse(NumStr_DQ) != 0)
                        NumStr_R = Ls_ShZ[int.Parse(NumStr_DQ)] + Ls_DW_Zh[a] + NumStr_R;
                    else if (a == 0 || a == 4 || a == 8)
                    {
                        if (NumStr_Zh.Length > 8 && a == 4)
                            continue;
                        NumStr_R = Ls_DW_Zh[a] + NumStr_R;
                    }
                    else if (int.Parse(NumStr_Zh.Substring(a - 1, 1)) != 0)
                        NumStr_R = Ls_ShZ[int.Parse(NumStr_DQ)] + NumStr_R;
                }
                if (!iXSh_bool)
                    return NumStr_R + "整";
                //NumStr_R += "零";
            }
            for (int b = 0; b < NumSr_X.Length; b++)
            {//小数部分转换
                NumStr_DQ = NumSr_X.Substring(b, 1);
                if (int.Parse(NumStr_DQ) != 0)
                    NumStr_R += Ls_ShZ[int.Parse(NumStr_DQ)] + Ls_DW_X[b];
                else if (b != 1 && iZhSh_bool)
                    NumStr_R += Ls_ShZ[int.Parse(NumStr_DQ)];
            }
            return NumStr_R;
        }

        private static String Reversion_Str(String Rstr)
        {
            Char[] LS_Str = Rstr.ToCharArray();
            Array.Reverse(LS_Str);
            String ReturnSte = "";
            ReturnSte = new String(LS_Str);//反转字符串

            return ReturnSte;
        }

        /// <summary>
        /// 将日期转化为中国的日期（阴历）
        /// </summary>
        /// <param name="dt">Date input</param>
        /// <param name="isArab">阿拉伯数字用于年、月、日. True=用阿拉伯数字, False=using Chinese case</param>
        /// <returns></returns>
        public static string ConvertDateToChinese(DateTime dt, bool isArab)
        {
            string returnValue = string.Empty;

            if (dt != null)
            {
                string year = dt.Year.ToString();
                string month = dt.Month.ToString();
                string day = dt.Day.ToString();

                string[] chineseChar = new string[] { "○", "一", "二", "三", "四", "五", "六", "七", "八", "九", "十", "年", "月", "日" };

                if (isArab)
                {
                    returnValue = year + chineseChar[11] + month + chineseChar[12] + day + chineseChar[13];
                }
                else
                {
                    if (dt.Month >= 10)
                    {
                        if (month.Substring(0, 1).Equals("1"))
                        {
                            month = chineseChar[10] + month.Substring(1, 1);
                        }
                    }

                    if (dt.Day >= 10 && dt.Day < 20)
                    {
                        if (day.Substring(0, 1).Equals("1"))
                        {
                            day = chineseChar[10] + day.Substring(1, 1);
                        }
                    }

                    if (dt.Day >= 20)
                    {
                        if (day.Substring(0, 1).Equals("2") || day.Substring(0, 1).Equals("3"))
                        {
                            day = day.Substring(0, 1) + chineseChar[10] + day.Substring(1, 1);
                        }
                    }

                    returnValue = year + chineseChar[11] + month + chineseChar[12] + day + chineseChar[13];
                    StringBuilder str = new StringBuilder();
                    for (int count = 0; count < returnValue.Length; count++)
                    {
                        string temp = returnValue.Substring(count, 1);
                        switch (temp)
                        {
                            case "1": str.Append(chineseChar[1]);
                                break;
                            case "2": str.Append(chineseChar[2]);
                                break;
                            case "3": str.Append(chineseChar[3]);
                                break;
                            case "4": str.Append(chineseChar[4]);
                                break;
                            case "5": str.Append(chineseChar[5]);
                                break;
                            case "6": str.Append(chineseChar[6]);
                                break;
                            case "7": str.Append(chineseChar[7]);
                                break;
                            case "8": str.Append(chineseChar[8]);
                                break;
                            case "9": str.Append(chineseChar[9]);
                                break;
                            case "0": str.Append(chineseChar[0]);
                                break;
                            case "十": str.Append(chineseChar[10]);
                                break;
                            case "年": str.Append(chineseChar[11]);
                                break;
                            case "月": str.Append(chineseChar[12]);
                                break;
                            case "日": str.Append(chineseChar[13]);
                                break;
                            default:
                                break;
                        }
                    }

                    returnValue = str.ToString();
                }
            }

            return returnValue;
        }

        /// <summary>
        /// 通过身份证号获取生日
        /// </summary>
        /// <param name="idNumber">身份证号长度18</param>
        /// <returns>若idNumber的长度不是18则返回最小时间{0001-1-1 00:00:00}</returns>
        public static DateTime GetBirthdayFromChineseIdNumber(string idNumber)
        {
            DateTime returnValue = DateTime.MinValue;
            try
            {
                if (idNumber.Length == 18)
                {
                    int year = int.Parse(idNumber.Substring(6, 4));
                    int month = int.Parse(idNumber.Substring(10, 2));
                    int day = int.Parse(idNumber.Substring(12, 2));
                    returnValue = new DateTime(year, month, day);
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {

            }
            return returnValue;
        }

        /// <summary>
        /// 把word读成HTML 返回HTML
        /// 实际上是先把word另存为HTML随机生成名字 存放到 word的目录下
        /// 然后在读成HTML 最后删除HTML文件
        /// </summary>
        /// <param name="wordPath"></param>
        /// <returns>返回HTML字符串</returns>
        public static string WordToHtml(string wordPath)
        {
            string retureValue = string.Empty;
            object unknow = Type.Missing;
            Word.Application wordApp = new Word.Application();
            Word.Document wordDoc = wordApp.Documents.Open(wordPath,
                unknow, unknow, unknow, unknow, unknow,
                unknow, unknow, unknow, unknow, unknow,
                unknow, unknow, unknow, unknow, unknow);

            object format = Word.WdSaveFormat.wdFormatFilteredHTML;
            FileInfo file = new FileInfo(wordPath);
            if (file.DirectoryName != null)
            {
                string newPath = Path.Combine(file.DirectoryName, new Random().Next().ToString() + "temp.html");
                wordDoc.SaveAs(newPath, format, unknow, unknow, unknow, unknow, unknow, unknow, unknow, unknow, unknow, unknow, unknow, unknow, unknow, unknow);
                wordDoc.Close(unknow, unknow, unknow);
                wordApp.Quit(unknow, unknow, unknow);

                FileStream fs = new FileStream(newPath, FileMode.Open);
                StreamReader sr = new StreamReader(fs,Encoding.Default);
                retureValue = sr.ReadToEnd();

                fs.Close();
                sr.Close();
                File.Delete(newPath);
            }

            return retureValue;
        }

        /// <summary>
        /// Update dtDestination with Data of dtSource
        /// </summary>
        /// <param name="dtSource"></param>
        /// <param name="dtDestination"></param>
        /// <param name="mappingKeySource"></param>
        /// <param name="mappingKeyDestination"></param>
        /// <param name="listColumn"></param>
        /// <param name="isOverwrite">Ture=Overwrite value from source to destination. False=if destination value is null, overwrite value from source to destination, else leave it.</param>
        /// <returns></returns>
        public static DataTable MapDataTable(DataTable dtSource, DataTable dtDestination, string mappingKeySource, string mappingKeyDestination, List<DataTableMapping> listColumn, bool isOverwrite)
        {
            foreach (DataRow drDestination in dtDestination.Rows)
            {
                foreach (DataRow drSource in dtSource.Rows)
                {
                    if (drDestination[mappingKeyDestination].ToString().Trim().Equals(drSource[mappingKeySource].ToString().Trim()))
                    {
                        foreach (DataTableMapping mapping in listColumn)
                        {
                            if (isOverwrite || string.IsNullOrEmpty(drDestination[mapping.ColumnNameDestination].ToString().Trim()))
                            {
                                drDestination[mapping.ColumnNameDestination] = drSource[mapping.ColumnNameSource];
                            }
                        }
                    }
                }
            }

            return dtDestination;
        }

        /// <summary>
        /// word另存为PDF
        /// </summary>
        /// <param name="inputPath">word的完整文件路径</param>
        /// <param name="outputPath">PDF 文件的额输出路径</param>
        /// <returns></returns>
        public static string WordToPdf(string inputPath, string outputPath)
        {
            string result = "false";
            object file = inputPath;// _fileFullPath;            
            object readOnly = true;
            object isVisible = false;
            object confirmConverisons = false;
            object openAndRepair = false;
            object _missing = Type.Missing;
            Microsoft.Office.Interop.Word.Application wordApp = new Microsoft.Office.Interop.Word.Application();
            Word.Document doc = null;
            try
            {
                doc = wordApp.Documents.Open(ref file, ref confirmConverisons, ref readOnly,
                    ref _missing, ref _missing, ref _missing, ref _missing, ref _missing, ref _missing,
                    ref _missing, ref _missing, ref isVisible, ref openAndRepair, ref _missing, ref _missing, ref _missing);
                //Word.WdStatistic stat = Word.WdStatistic.wdStatisticPages;
                //FilePageCount = doc.ComputeStatistics(stat, _missing);
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            if (doc.ActiveWindow.ActivePane.View.Type != Word.WdViewType.wdPrintView)
            {
                if (doc.ActiveWindow.View.SplitSpecial == Word.WdSpecialPane.wdPaneNone)
                    doc.ActiveWindow.ActivePane.View.Type = Word.WdViewType.wdPrintView;
                else
                    doc.ActiveWindow.View.Type = Word.WdViewType.wdPrintView;
            }

            try
            {
                if (!System.IO.File.Exists(outputPath))
                    doc.ExportAsFixedFormat(outputPath, Word.WdExportFormat.wdExportFormatPDF, false,
                        Word.WdExportOptimizeFor.wdExportOptimizeForPrint, Word.WdExportRange.wdExportFromTo, 1, 100,
                        Word.WdExportItem.wdExportDocumentContent, false, true, Word.WdExportCreateBookmarks.wdExportCreateNoBookmarks, true, true, false, _missing);
                result = string.Empty;
            }
            catch (Exception ex)
            {
                result = ex.ToString();
            }
            finally
            {
                if (doc != null)
                {
                    doc.Close(ref _missing, ref _missing, ref _missing);
                    doc = null;
                }
                if (wordApp != null)
                {
                    wordApp.Quit(ref _missing, ref _missing, ref _missing);
                    wordApp = null;
                }
                GC.Collect();
                GC.WaitForPendingFinalizers();
                GC.Collect();
                GC.WaitForPendingFinalizers();
            } return result;
        }


        /// <summary>
        /// 验证WorkSheet是否存在Workbook里
        /// </summary>
        /// <param name="workbook"></param>
        /// <param name="sheetArr"></param>
        /// <returns></returns>
        public static bool IsSheetExisted(Excel.Workbook workbook, string[] sheetArr)
        {
            bool returnValue = true;
            if (workbook == null || sheetArr == null || sheetArr.Length == 0)
            {
                returnValue = false;
            }
            else
            {
                foreach (string sheetName in sheetArr)
                {
                    bool isExisted = false;
                    foreach (Excel.Worksheet sheet in workbook.Sheets)
                    {
                        if (sheet.Name == sheetName)
                        {
                            isExisted = true;
                            break;
                        }
                    }
                    returnValue = returnValue && isExisted;
                    if (!returnValue)
                    {
                        break;
                    }
                }
            }
            return returnValue;
        }

        /// <summary>
        /// Business Day calculation, weekend included only
        /// 工作日计算,只包括工作日
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="days"></param>
        /// <returns></returns>
        public static DateTime AddWorkingDay(DateTime dt, int days)
        {
            DateTime dtReturn = dt;

            if (days > 0)
            {
                while (days > 0)
                {
                    dtReturn = dtReturn.AddDays(1);
                    if (dtReturn.DayOfWeek != System.DayOfWeek.Saturday && dtReturn.DayOfWeek != System.DayOfWeek.Sunday)
                    {
                        days--;
                    }
                }
            }
            else if (days < 0)
            {
                while (days < 0)
                {
                    dtReturn = dtReturn.AddDays(-1);
                    if (dtReturn.DayOfWeek != System.DayOfWeek.Saturday && dtReturn.DayOfWeek != System.DayOfWeek.Sunday)
                    {
                        days++;
                    }
                }
            }

            return dtReturn;
        }

        /// <summary>
        /// 得到两个工作日之间差的天数
        /// </summary>
        /// <param name="dateTime1"></param>
        /// <param name="dateTime2"></param>
        /// <returns></returns>
        public static int WorkingDayDiff(DateTime dateTime1, DateTime dateTime2)
        {
            int returnValue = 0;
            returnValue = Math.Abs(WorkingDayDiffCompared(dateTime1, dateTime2));
            return returnValue;
        }

        /// <summary>
        /// 得到两个工作日之间差的天数 正数表示dateTime1大于dateTime2
        /// </summary>
        /// <param name="dateTime1"></param>
        /// <param name="dateTime2"></param>
        /// <returns>若 dateTime1 小于 dateTime2,返回负数</returns>
        public static int WorkingDayDiffCompared(DateTime dateTime1, DateTime dateTime2)
        {
            int returnValue = 0;
            DateTime dt1;
            DateTime dt2;
            bool isMore = false;

            if (dateTime1 > dateTime2)
            {
                dt2 = Convert.ToDateTime(dateTime1.ToShortDateString());
                dt1 = Convert.ToDateTime(dateTime2.ToShortDateString());
                isMore = true;
            }
            else
            {
                dt1 = Convert.ToDateTime(dateTime1.ToShortDateString());
                dt2 = Convert.ToDateTime(dateTime2.ToShortDateString());
            }

            TimeSpan ts1 = dt2.Subtract(dt1);
            int countday = ts1.Days;

            for (int i = 0; i < countday; i++)
            {
                DateTime tempdt = dt1.Date.AddDays(i);
                if (tempdt.DayOfWeek != System.DayOfWeek.Saturday && tempdt.DayOfWeek != System.DayOfWeek.Sunday)
                {
                    returnValue++;
                }
            }
            if (isMore)
            {
                returnValue = returnValue * (-1);
            }
            return returnValue;
        }
    }

    /// <summary>
    /// Entity for DataTable Mapping
    /// </summary>
    public class DataTableMapping
    {
        public DataTableMapping(string columnNameSource, string columnNameDestination)
        {
            this.columnNameSource = columnNameSource;
            this.columnNameDestination = columnNameDestination;
        }

        private string columnNameSource;

        public string ColumnNameSource
        {
            get { return columnNameSource; }
            set { columnNameSource = value; }
        }
        private string columnNameDestination;

        public string ColumnNameDestination
        {
            get { return columnNameDestination; }
            set { columnNameDestination = value; }
        }

    }

    /// <summary>
    /// Kill given excel process
    /// </summary>
    public class KillExcel
    {
        [DllImport("User32.dll", CharSet = CharSet.Auto)]
        public static extern int GetWindowThreadProcessId(IntPtr hwnd, out int ID);

        /// <summary>
        /// 杀死了excel进程
        /// </summary>
        /// <param name="intPtr"></param>
        public static void Kill(IntPtr intPtr)
        {
            try
            {
                Process[] ps = Process.GetProcesses();
                int excelId = 0;
                GetWindowThreadProcessId(intPtr, out excelId);
                foreach (Process p in ps)
                {
                    if (p.ProcessName.ToLower().Equals("excel"))
                    {
                        if (p.Id == excelId)
                        {
                            p.Kill();
                        }
                    }
                }
            }
            catch
            {
            }
        }
    }
}
