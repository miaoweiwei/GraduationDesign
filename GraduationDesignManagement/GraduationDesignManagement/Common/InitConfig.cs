using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace GraduationDesignManagement.Common
{
   /// <summary>
   /// 配置文件初始化类
   /// </summary>
    public static class InitConfig
    {
        /// <summary>  服务器IP </summary>
        public static string ServerHhost { get; set; }
        /// <summary>  域名 </summary>
        public static string DomainName { get; set; }
        /// <summary>  FTP用户名 </summary>
        public static string FtpUser { get; set; }
        /// <summary>  FTP密码 </summary>
        public static string FtpPassword { get; set; }
        /// <summary>  安装包服务器路径 </summary>
        public static string ServerInstallPath { get; set; }
        /// <summary>  安装包版本文件name </summary>
        public static string CheckFileName { get; set; }

        /// <summary> 上传文件保存的服务器路径 </summary>
        public static string ServerUpLoadPath { get; set; }

        /// <summary> 上传文件保存的毕业设计的项目文件 </summary>
        public static string GraduationDesignFilePath { get; set; }
        /// <summary> 毕业设计信息管理系统网页介绍 </summary>
        public static string GraduationDesignHtml { get; set; }

        /// <summary>  mysql连接字符串 </summary>
        public static string MysqlConnectSt { get; set; }


        /// <summary>  上传文件连接超时时间 </summary>
        public static int UpLoadOutTime { get; set; }
        /// <summary>  下载文件连接超时时间 </summary>
        public static int DownLoadOutTime { get; set; }

        /// <summary>
        /// 初始化配置文件
        /// </summary>
        public static void Init(string configPath)
        {
            try
            {
                LogUtil.Info("加载获取配置文件信息");
                var config = ConfigurationManager.OpenExeConfiguration(configPath);
                ServerHhost = config.AppSettings.Settings["ServerHhost"].Value;
                DomainName = config.AppSettings.Settings["DomainName"].Value;
                FtpUser = config.AppSettings.Settings["FtpUser"].Value;
                FtpPassword = config.AppSettings.Settings["FtpPassword"].Value;
                ServerInstallPath = config.AppSettings.Settings["ServerInstallPath"].Value;
                CheckFileName = config.AppSettings.Settings["CheckFileName"].Value;

                ServerUpLoadPath = config.AppSettings.Settings["ServerUpLoadPath"].Value;
                GraduationDesignFilePath= config.AppSettings.Settings["GraduationDesignFilePath"].Value;

                GraduationDesignHtml = config.AppSettings.Settings["GraduationDesignHtml"].Value;

                UpLoadOutTime = int.Parse(config.AppSettings.Settings["UpLoadOutTime"].Value);
                DownLoadOutTime = int.Parse(config.AppSettings.Settings["DownLoadOutTime"].Value);

                MysqlConnectSt = config.ConnectionStrings.ConnectionStrings["MysqlConnectSt"].ConnectionString;
            }
            catch (Exception ex)
            {
                LogUtil.Error("Init(string configPath)->"+ex);
            }
        }
    }
}
