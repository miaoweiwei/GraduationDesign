using System;
using System.Text.RegularExpressions;

namespace GraduationDesignManagement.Common
{
    static class DateTimeHelper
    {
        /// <summary>
        /// 时间戳转为C#格式时间
        /// </summary>
        /// <param name=”timeStamp”></param>
        /// <returns></returns>
        public static DateTime GetTime(string timeStamp)
        {
            DateTime dtStart = TimeZone.CurrentTimeZone.ToLocalTime(new DateTime(1970, 1, 1));
            long lTime = long.Parse(timeStamp + "0000000");
            TimeSpan toNow = new TimeSpan(lTime); return dtStart.Add(toNow);
        }
        /// <summary>
        /// c#时间转为c++ time_t
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public static long DateTimeToTime_t(DateTime dateTime)
        {
            DateTime dt1 = new DateTime(1970, 1, 1, 0, 0, 0);
            TimeSpan ts = dateTime - dt1;
            var timeT = ts.Ticks / 10000000 - 28800;
            return timeT;
        }

        public static DateTime Unixtime2DateTime(double unixtime)
        {
            double seconds = unixtime + 28800;
            DateTime dt = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(seconds);
            return dt;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="str"></param>
        /// <param name="format">yyyyMMdd</param>
        /// <returns></returns>
        public static bool String2DateTime(string str, string format, out DateTime dt)
        {
            try
            {
                dt = DateTime.ParseExact(str, format, System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                dt = DateTime.Now;
                return false;
            }

            return true;
        }

        public static DateTime String2DateTime(string dtStr)
        {
            try
            {
                //if (dtStr.)

                return DateTime.ParseExact(dtStr, "yyyyMMdd", System.Globalization.CultureInfo.CurrentCulture);
            }
            catch (Exception)
            {
                return DateTime.Now;
            }
        }

        /// <summary>
        /// 获取当前时间的时间戳
        /// </summary>
        /// <returns></returns>
        public static long GetUnixTimestamp()
        {
            DateTime timeStamp = new DateTime(1970, 1, 1); //得到1970年的时间戳
            return (DateTime.UtcNow.Ticks - timeStamp.Ticks) / 10000000; //注意这里有时区问题，用now就要减掉8个小时
        }

        /// <summary>
        /// 获取月份的最后一天
        /// </summary>
        /// <returns></returns>
        public static int GetLastDay(int year, int month)
        {
            if (year == DateTime.Now.Year && month == DateTime.Now.Month) //如果选择的是当前月份
                return DateTime.Now.Day - 1;//
            if (month == 12)
                return 31;
            var dt = new DateTime(year, month + 1, 1, 0, 0, 0);
            var newDt = dt.AddDays(-1);
            return newDt.Day;
        }
        
        /// <summary>
        /// 判断2个时间段是否有交集
        /// </summary>
        /// <returns></returns>
        public static bool IsMixed(DateTime dtStart1, DateTime dtEnd1, DateTime dtStart2, DateTime dtEnd2)
        {
            return (dtStart2 < dtEnd1 && dtStart1 < dtEnd2) || (dtStart1 < dtEnd2 && dtStart2 < dtEnd1);
        }


        /// <summary>
        /// 日期转换
        /// </summary>
        /// <param name="dateStr"></param>
        /// <returns></returns>
        public static DateTime DateConvert(string dateStr)
        {
            DateTime date = new DateTime();

            if (string.IsNullOrEmpty(dateStr)) { return new DateTime(); }

            decimal dateDec = 0;
            if (decimal.TryParse(dateStr, out dateDec) && dateDec < 100000)
            {
                date = DateTime.FromOADate(Convert.ToDouble(dateStr));
                return date;
            }
            if (dateDec > 1000000000 && dateDec < 2000000000)
            {
                double seconds = (double)dateDec + 28800;
                date = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc).AddSeconds(seconds);
                return date;
            }

            if (dateDec > 100000 || dateDec == 0)
            {
                Match m = Regex.Match(dateStr,
                        @"(?<year>\d{4})(?<split1>\D)?(?<month>\d{1,2})(\k<split1>)?(?<day>\d{1,2})(\s(?<hour>\d{2})\:(?<minute>\d{2})(\:(?<second>\d{2}))?)?");

                if (m.Value != "")
                {
                    GroupCollection gc = m.Groups;
                    int year = int.Parse(gc["year"].Value);
                    int month = int.Parse(gc["month"].Value);
                    int day = int.Parse(gc["day"].Value);

                    if (year != 0 || month != 0 || day != 0)
                    {
                        bool isError = false;
                        if (month == 2 && day > 28)
                        {
                            switch (day)
                            {
                                case 29:
                                    if ((year % 400) != 0 || ((year % 4) == 0 && (year % 100) != 0))
                                    {
                                        isError = true;
                                    }
                                    break;
                                //case 30: break;
                                //default: break;
                            }
                        }
                        if (!isError)
                        {
                            int hour, minute, second;
                            int.TryParse(gc["hour"].Value, out hour);
                            int.TryParse(gc["minute"].Value, out minute);
                            int.TryParse(gc["second"].Value, out second);
                            if (hour < 24 && minute < 60 && second < 60)
                                date = new DateTime(year, month, day, hour, minute, second);
                        }
                    }
                }
            }
            return date;
        }

        /// <summary>
        /// 格式化时间
        /// </summary>
        /// <param name="dateTimeStr"></param>
        /// <returns></returns>
        public static string FormatDateTime(string dateTimeStr)
        {
            if (string.IsNullOrEmpty(dateTimeStr)) { return ""; }

            return DateConvert(dateTimeStr).ToString("yyyy-MM-dd");
        }

    }
}
