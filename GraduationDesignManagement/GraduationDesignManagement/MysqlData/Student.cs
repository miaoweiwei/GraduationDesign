﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationDesignManagement.MysqlData
{
    /// <summary>
    /// 学生
    /// </summary>
    public class Student
    {
        /// <summary>
        /// 学生Id
        /// </summary>
        public string StudentId { get; set; }
        /// <summary>
        /// 学生姓名
        /// </summary>
        public string StudentName { get; set; }
        /// <summary>
        /// 学生班级
        /// </summary>
        public string Class { get; set; }
        /// <summary>
        /// 是否可以参加毕业设计
        /// </summary>
        public string IsCan { get; set; }
    }
}
