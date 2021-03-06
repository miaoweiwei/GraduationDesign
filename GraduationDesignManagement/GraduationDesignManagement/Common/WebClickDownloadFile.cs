﻿using System;
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

        private string _localFilePath;

        /// <summary>
        /// 下载完成并更新下载次数
        /// </summary>
        public delegate void ReciveCompleteEventHandler(ServerFile serverFile, bool success);
        public event ReciveCompleteEventHandler DownLoadUpDateDownLoadTime;

        private ServerFile _serverFile; //文件的本地路径 如果下载失败就删除文件
        
        Timer timer = new Timer();
        /// <summary>
        /// 下载文件
        /// </summary>
        /// <param name="serverFile">指定要下载的ServerFile</param>
        /// <param name="filePath">输入到本地文件夹</param>
        public void DownLoderFile(ServerFile serverFile, string filePath)
        {
            _serverFile = serverFile;
            TotalBytesToReceive = serverFile.Size;

            string fileName = serverFile.FileName.Split('-')[1].Split('.')[0];
            string fileSuffix = serverFile.FileName.Split('-')[1].Split('.')[1];
            _localFilePath = filePath + "\\" + fileName + "." + fileSuffix;//获得文件路径带文件名 

            if (!Directory.Exists(filePath))
                Directory.CreateDirectory(filePath);
            int iTemp = 1;
            while (true)
            {
                if (!File.Exists(_localFilePath))
                    break;
                _localFilePath = filePath + "\\" + fileName + iTemp + "." + fileSuffix;
                iTemp++;
            }
            
            //创建文件后会返回该文件的Stream 所以要close（）一下
            Stream outStream = File.Create(_localFilePath);
            outStream.Close();

            WebClient webClient = new WebClient();
            webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
            webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;

            string serverFilePath = InitConfig.DomainName + InitConfig.ServerUpLoadPath + serverFile.FileName;
            Uri uri = new Uri(serverFilePath);

            webClient.DownloadFileAsync(uri, _localFilePath);

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
                DownLoadUpDateDownLoadTime(_serverFile, success);
            if (!success)
                File.Delete(_localFilePath);
            timer.Enabled = false;
            DownCell.Value = stTemp;
            DownCell.Enabled = true;
        }

        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            ProgressPercentage = e.ProgressPercentage + "%";
        }
    }
}
