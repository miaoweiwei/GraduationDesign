using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using GraduationDesignManagement.MysqlData;

namespace GraduationDesignManagement.Common
{
    public class FtpUpLoadFile
    {
        #region FTP上传文件

        public ServerFile ServerFile { get; set; }

        private float _uploadFtpProgres;
        /// <summary> FTP上传进度 </summary>
        public float UploadFtpProgres
        {
            get { return _uploadFtpProgres; }
            set
            {
                _uploadFtpProgres = value;
                if (UploadFtpProgresChange != null)
                {
                    UploadFtpProgresChange(ServerFile, value);
                }
            }
        }

        /// <summary>
        /// 上传进度
        /// </summary>
        /// <param name="serverFile"></param>
        /// <param name="num">上传进度</param>
        public delegate void UploadFileFtpProgresChange(ServerFile serverFile, float uploadFileFtpProgres);
        public event UploadFileFtpProgresChange UploadFtpProgresChange;


        private bool _upLoadFtpComplete;
        /// <summary> FTP上传状态 </summary>
        public bool UpLoadFtpState
        {
            get { return _upLoadFtpComplete; }
            set
            {
                _upLoadFtpComplete = value;
                if (UploadFtpFileCompleted != null)
                {
                    UploadFtpFileCompleted(ServerFile, value);
                }
            }
        }
        /// <summary>
        /// FTP上传完成
        /// </summary>
        /// <param name="serverFile"></param>
        /// <param name="upLoadFtpState"></param>
        public delegate void UploadFileCompleted(ServerFile serverFile, bool upLoadFtpState);
        public event UploadFileCompleted UploadFtpFileCompleted;

        Timer timer = new Timer();


        /// <summary>
        /// FTP上传文件到服务器
        /// </summary>
        /// <param name="filePath">本地文件路径</param>
        /// <param name="targetDir">服务器路径uri</param>
        /// <param name="fileName">上传到服务器上的文件的名字</param>
        /// <param name="ftpUserName">FTP用户名</param>
        /// <param name="ftpPassword">FTP用户密码</param>
        public void UploadFileFtp(string filePath, string targetDir, string fileName, string ftpUserName, string ftpPassword)
        {
            try
            {
                FileInfo fileInf = new FileInfo(filePath);
                string uri = "ftp://" + targetDir + fileName;
                var reqFtp = (FtpWebRequest)WebRequest.Create(new Uri(uri));
                reqFtp.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
                reqFtp.Timeout = InitConfig.UpLoadOutTime;
                reqFtp.KeepAlive = false;
                reqFtp.Method = WebRequestMethods.Ftp.UploadFile;
                reqFtp.UseBinary = true;
                reqFtp.ContentLength = fileInf.Length;
                long fileLength = fileInf.Length;

                int buffLength = 2048;
                byte[] buff = new byte[buffLength];
                int sum = 0;
                FileStream fs = fileInf.OpenRead();

                Stream strm = reqFtp.GetRequestStream();
                int contentLen;
                do
                {
                    contentLen = fs.Read(buff, 0, buffLength);
                    if (contentLen > 0)
                    {
                        strm.Write(buff, 0, contentLen);
                    }
                    sum = contentLen + sum;
                    if (sum == fileLength)
                    {
                        fs.Close();
                        strm.Close();
                        contentLen = 0;
                    }
                    UploadFtpProgres = (float)(sum * 1.0 / fileLength);
                } while (contentLen > 0);
                UpLoadFtpState = true;
            }
            catch (Exception ex)
            {
                LogUtil.Error(
                    "UploadFile(string filePath, string targetDir, string hostName, string ftpUserName, string ftpPassword)->" +
                    ex);
            }
        }

        #endregion

        
        #region FTP删除文件

        public bool DelectFileFileFtp(string targetDir, string fileName, string ftpUserName, string ftpPassword)
        {
            string uri = "ftp://" + targetDir + fileName;
            FtpWebRequest reqFtp = (FtpWebRequest)WebRequest.Create(new Uri(uri));

            reqFtp.Credentials = new NetworkCredential(ftpUserName, ftpPassword);
            reqFtp.KeepAlive = false;
            reqFtp.Method = WebRequestMethods.Ftp.DeleteFile;
            reqFtp.UseBinary = true;

            try
            {
                using (FtpWebResponse response = (FtpWebResponse) reqFtp.GetResponse())
                {
                    if (response.StatusCode == FtpStatusCode.FileActionOK)
                    {
                        #region MyRegion

                        //long size = response.ContentLength;
                        //using (Stream datastream = response.GetResponseStream())
                        //{
                        //    if (datastream != null)
                        //    {
                        //        using (StreamReader sr = new StreamReader(datastream))
                        //        {
                        //            sr.ReadToEnd();
                        //            sr.Close();
                        //        }
                        //        datastream.Close();
                        //    }
                        //}

                        #endregion

                        response.Close();
                        return true;
                    }
                    response.Close();
                    return false;
                }
            }
            catch (WebException e)
            {
                FtpWebResponse response = (FtpWebResponse)e.Response;
                if (response.StatusCode == FtpStatusCode.ActionNotTakenFileUnavailable)
                {
                    MessageBox.Show(@"文件不存在");
                }
            }
            return false;
        }

        #endregion
    }
}
