using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationDesignManagement.MysqlData
{
    /// <summary>
    /// 教师类
    /// </summary>
    public class Teacher
    {
        /// <summary>
        /// 教师ID
        /// </summary>
        public int Teacherid { get; set; }
        /// <summary>
        /// 教师名字
        /// </summary>
        public string Teachername { get; set; }
        /// <summary>
        /// 职位
        /// </summary>
        public string Position { get; set; }
        /// <summary>
        /// 教师部门
        /// </summary>
        public string Department { get; set; }
        /// <summary>
        /// 是否允许做毕设导师
        /// </summary>
        public string Iscan { get; set; }
    }
}
