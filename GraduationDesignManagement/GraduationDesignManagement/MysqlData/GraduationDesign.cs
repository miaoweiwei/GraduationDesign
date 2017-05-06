using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationDesignManagement.MysqlData
{
    public class GraduationDesign
    {
        /// <summary>
        /// 项目Code
        /// </summary>
        public string ProjectCode { get; set; }
        /// <summary>
        /// 教师ID
        /// </summary>
        public string TeacherId { get; set; }
        /// <summary>
        /// 学生ID
        /// </summary>
        public string StudentId { get; set; }
        
        /// <summary> 答辩老师 </summary>
        public string PleaTeacherId { get; set; }
        
        /// <summary> 开题成绩 </summary>
        public int BeginScore { get; set; }
        /// <summary> 中期成绩 </summary>
        public int MiddleScore { get; set; }
        /// <summary> 结题成绩 </summary>
        public int EndScore { get; set; }
        /// <summary> 评语 </summary>
        public string Comment { get; set; }
    }
}
