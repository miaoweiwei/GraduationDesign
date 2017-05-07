using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationDesignManagement.MysqlData
{
    public class GraduationDesignFile
    {
        /// <summary> 项目文件Code </summary>
        public string FileCode { get; set; }
        /// <summary> 项目文件名 </summary>
        public string FileName { get; set; }
        /// <summary> 上传时间 </summary>
        public string UpLoadTime { get; set; }
        /// <summary> 项目文件的类型 课题 中期 结题 </summary>
        public string DateType { get; set; }
        /// <summary> 项目学生ID </summary>
        public string StudentId { get; set; }
        /// <summary> 项目Code </summary>
        public string ProjectCode { get; set; }
    }
}
