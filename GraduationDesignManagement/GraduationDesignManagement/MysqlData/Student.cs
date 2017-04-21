using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationDesignManagement.MysqlData
{
    public class Student
    {
        /// <summary>
        /// 学生Id
        /// </summary>
        public string Studentid { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string Studentname { get; set; }
        /// <summary>
        /// 学生班级
        /// </summary>
        public string Studentclass { get; set; }
        /// <summary>
        /// 是否可以参加毕业设计
        /// </summary>
        public string Iscan { get; set; }
    }
}
