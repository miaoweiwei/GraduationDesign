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


        /// <summary> 第一位答辩老师 </summary>
        public string FirstTeacherId { get; set; }
        /// <summary> 第二位答辩老师 </summary>
        public string SecondTeacherId { get; set; }
        /// <summary> 第三位答辩老师 </summary>
        public string ThirdTeacherId { get; set; }

        /// <summary> 开题答辩第一个老师的成绩 </summary>
        public string BeginFirst { get; set; }
        /// <summary> 开题答辩第二个老师的成绩 </summary>
        public string BeginSecond { get; set; }
        /// <summary> 开题答辩第三个老师的成绩 </summary>
        public string BeginThird { get; set; }

        /// <summary> 中期答辩第一个老师的成绩 </summary>
        public string MiddleFirst { get; set; }
        /// <summary> 中期答辩第二个老师的成绩 </summary>
        public string MiddleSecond { get; set; }
        /// <summary> 中期答辩第三个老师的成绩  </summary>
        public string MiddleThird { get; set; }

        /// <summary> 结题答辩第一个老师的成绩 </summary>
        public string EndFirst { get; set; }
        /// <summary> 结题答辩第二个老师的成绩 </summary>
        public string EndSecond { get; set; }
        /// <summary> 结题答辩第三个老师的成绩 </summary>
        public string EndThird { get; set; }
    }
}
