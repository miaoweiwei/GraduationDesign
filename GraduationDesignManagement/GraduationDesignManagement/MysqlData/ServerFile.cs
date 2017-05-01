using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationDesignManagement.MysqlData
{
    public class ServerFile
    {
        /// <summary>
        /// 文件Code
        /// </summary>
        public string FileCode { get; set; }
        /// <summary>
        /// 文件名
        /// </summary>
        public string FileName { get; set; }
        /// <summary>
        /// 上传时间
        /// </summary>
        public string UpLoadTime { get; set; }
        /// <summary>
        /// 上传人
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 下载次数
        /// </summary>
        public int DownLoadTime { get; set; }
        /// <summary>
        /// 文件大小
        /// </summary>
        public long Size { get; set; }
    }
}
