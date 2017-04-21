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
        /// 项目Id
        /// </summary>
        public int Projectid { get; set; }
        /// <summary>
        /// 项目名称
        /// </summary>
        public string Projectname{ get; set; }
        /// <summary>
        /// 教师Id
        /// </summary>
        public string Teacherid { get; set; }
        /// <summary>
        /// 项目状态
        /// </summary>
        public string State { get; set; }
    }
}
