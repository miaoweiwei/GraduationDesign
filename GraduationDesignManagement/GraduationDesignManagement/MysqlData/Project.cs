using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationDesignManagement.MysqlData
{
    /// <summary>
    /// 毕业设计项目
    /// </summary>
    public class Project
    {
        /// <summary>
        /// 项目名称
        /// </summary>
        public string ProjectName{ get; set; }
        /// <summary>
        /// 项目说明
        /// </summary>
        public string Introduce { get; set; }
        /// <summary>
        /// 教师Id
        /// </summary>
        public string TeacherId { get; set; }
        /// <summary>
        /// 项目代码
        /// </summary>
        public string Projectcode { get; set; }
        /// <summary>
        /// 项目状态
        /// </summary>
        public string State { get; set; }
    }
}
