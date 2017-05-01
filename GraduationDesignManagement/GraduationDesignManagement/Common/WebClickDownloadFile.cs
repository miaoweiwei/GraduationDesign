using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using GraduationDesignManagement.MysqlData;
using GraduationDesignManagement.Views;

namespace GraduationDesignManagement.Common
{
    /// <summary>
    /// 使用WebClient下载文件
    /// </summary>
    public class WebClickDownloadFile
    {
        /// <summary>
        /// 按钮Cell
        /// </summary>
        public DataGridViewDisableButtonCell DownCell;
        /// <summary>
        /// 要下载的文件的大小
        /// </summary>
        public long TotalBytesToReceive { get; set; }
        /// <summary>
        /// 下载进度
        /// </summary>
        public string ProgressPercentage { get; private set; }

        /// <summary>
        /// 下载完成并更新下载次数
        /// </summary>
        /// <param name="fileCode">文件的Code</param>
        public delegate void ReciveCompleteEventHandler(ServerFile serverFile, bool success);
        public event ReciveCompleteEventHandler DownLoadUpDateDownLoadTime;

        private ServerFile _serverFile;


        Timer timer = new Timer();
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="serverFile"></param>
        /// <param name="filePath">输入到本地文件夹</param>
        public void DownLoderFile(ServerFile serverFile, string filePath)
        {
            _serverFile = serverFile;
            TotalBytesToReceive = serverFile.Size;
            string localFilePath = filePath + "\\" + serverFile.FileName.Split('-')[1]; //获得文件路径带文件名 
            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            if (File.Exists(localFilePath))
                File.Delete(localFilePath);

            //创建文件后会返回该文件的Stream 所以要close（）一下
            Stream outStream = File.Create(localFilePath);
            outStream.Close();

            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;

            string serverFilePath = InitConfig.DomainName + InitConfig.ServerUpLoadPath + serverFile.FileName;
            Uri uri = new Uri(serverFilePath);

            webClient.DownloadFileAsync(uri, localFilePath);

            timer.Interval = 300;
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            DownCell.Value = ProgressPercentage;
        }

        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            string stTemp = "";
            bool success;
            if (e.Error == null)
            {
                stTemp = "已下载完成";
                success = true;
            }
            else
            {
                stTemp = "下载失败重试";
                success = false;
            }
            if (DownLoadUpDateDownLoadTime != null)
            {
                DownLoadUpDateDownLoadTime(_serverFile, success);
            }
            timer.Enabled = false;
            DownCell.Value = stTemp;
            DownCell.Enabled = true;
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressPercentage = e.ProgressPercentage + "%";
            Debug.WriteLine(e.ProgressPercentage + " " + e.TotalBytesToReceive + " " + e.BytesReceived);
        }
    }
}
