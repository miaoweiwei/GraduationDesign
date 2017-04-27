using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationDesignManagement.MysqlData
{
    /// <summary>
    /// 毕业日程设计
    /// </summary>
    public class Schedule
    {
        /// <summary> 日程类型 </summary>
        public string DateType { get; set; }

        /// <summary> 开始时间 </summary>
        public DateTime BeginDate { get; set; }

        /// <summary> 结束时间 </summary>
        public DateTime EndDate { get; set; }

        /// <summary> 事项 </summary>
        public string Matter { get; set; }
    }
}
