using System;
using System.Data;
using System.Configuration;
using System.Diagnostics;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.IO;
using System.Net;
using System.Net.Mime;
using System.Threading;
using System.Windows.Forms;

namespace GraduationDesignManagement.Common
{
    /// <summary>
    /// 从服务器下载和上传文件
    /// </summary>
    public class UpDownHelper
    {
        #region 下载

        /// <summary> 下载文件的大小 </summary>
        public long DownFileSize { get; set; }
        
        /// <summary> 下载进度改变事件 </summary>
        public event EventHandler DopwnloadProgresChange;
        private static float _downloadProgres;
        /// <summary> 下载进度 </summary>
        public float DownloadProgres
        {
            get { return _downloadProgres; }
            set
            {
                _downloadProgres = value;
                if (DopwnloadProgresChange != null)
                {
                    DopwnloadProgresChange(this, new EventArgs());
                }
            }
        }

        /// <summary> 下载完成 </summary>
        public event EventHandler DopwnLoadComplete;
        private bool _downLoadComplete;
        /// <summary> 下载状态 </summary>
        public bool DownLoadState
        {
            get { return _downLoadComplete; }
            set
            {
                _downLoadComplete = value;
                if (DopwnLoadComplete != null)
                {
                    DopwnLoadComplete(this, new EventArgs());
                }
            }
        }
        
        /// <summary>
        /// 从服务器上下载文件
        /// </summary>
        /// <param name="url">指定下载服务器文件路径</param>
        /// <param name="filePath"></param>
        /// <param name="fileName">本地文件路径</param>
        public bool DownloadFile(string url, string filePath, string fileName)
        {
            if (string.IsNullOrEmpty(url) || string.IsNullOrEmpty(filePath) || string.IsNullOrEmpty(fileName))
            {
                LogUtil.Info("DownloadFile(string url, string filePath, string fileName)-> url,filePath,fileName都不能为空");
                return false;
            }
            bool value = false;
            try
            {
                HttpWebRequest request = (HttpWebRequest) WebRequest.Create(url);
                request.Timeout = InitConfig.DownLoadOutTime;
                var response = request.GetResponse();
                DownFileSize = request.ContentLength;
                //"application/x-msdownload"为可执行文件（.exe  .dll）
                if (response.ContentType.ToLower() == "application/x-msdownload")
                {
                    value = SaveBinaryFile(response, filePath, fileName);
                }
            }
            catch (Exception ex)
            {
                LogUtil.Error("DownloadFile->" + ex);
                value = false;
            }
            return value;
        }

        /// <summary>
        /// 将二进制文件保存到磁盘
        /// </summary>
        /// <param name="response">来自 Internet 资源的响应</param>
        /// <param name="filePath">保存文件的路径</param>
        /// <param name="fileName">保存文件的名称</param>
        /// <returns></returns>
        private bool SaveBinaryFile(WebResponse response, string filePath, string fileName)
        {
            if (response == null)
            {
                return false;
            }
            long fileLength = response.ContentLength;
            bool value = true;
            byte[] buffer = new byte[10240];
            try
            {
                if (!Directory.Exists(filePath))
                    Directory.CreateDirectory(filePath);
                fileName = Path.Combine(filePath, fileName);
                if (File.Exists(fileName))
                    File.Delete(fileName);
                Stream outStream = File.Create(fileName);
                Stream inStream = response.GetResponseStream();
                int i;
                int sum = 0;
                do
                {
                    i = inStream.Read(buffer, 0, buffer.Length);
                    if (i > 0)
                    {
                        outStream.Write(buffer, 0, i);
                    }
                    sum = i + sum;
                    if (sum == fileLength)
                    {
                        outStream.Close();
                        inStream.Close();
                        i = 0;
                    }
                    DownloadProgres = (float) (sum*1.0/fileLength);
                } while (i > 0);
                DownLoadState = true;
            }
            catch (Exception ex)
            {
                value = false;
                LogUtil.Error("SaveBinaryFile->" + ex);
            }
            return value;
        }

        #endregion

        #region FTP上传文件

        /// <summary>
        /// FTP上传进度改变事件
        /// </summary>
        public event EventHandler UploadFtpProgresChange;
        private float _uploadFtpProgres;

        /// <summary>
        /// FTP上传进度
        /// </summary>
        public float UploadFtpProgres
        {
            get { return _uploadFtpProgres; }
            set
            {
                _uploadFtpProgres = value;
                if (UploadFtpProgresChange != null)
                {
                    UploadFtpProgresChange(this, new EventArgs());
                }
            }
        }

        /// <summary> FTP上传完成 </summary>
        public event EventHandler UpLoadFtpComplete;
        private bool _upLoadFtpComplete;
        /// <summary> FTP上传状态 </summary>
        public bool UpLoadFtpState
        {
            get { return _upLoadFtpComplete; }
            set
            {
                _upLoadFtpComplete = value;
                if (UpLoadFtpComplete != null)
                {
                    UpLoadFtpComplete(this, new EventArgs());
                }
            }
        }

        /// <summary>
        /// FTP上传文件到服务器
        /// </summary>
        /// <param name="filePath">本地文件路径</param>
        /// <param name="targetDir">服务器路径uri</param>
        /// <param name="hostName">服务器地址IP</param>
        /// <param name="ftpUserName">FTP用户名</param>
        /// <param name="ftpPassword">FTP用户密码</param>
        public void UploadFileFtp(string filePath, string targetDir, string hostName, string ftpUserName,
            string ftpPassword)
        {
            try
            {
                FileInfo fileInf = new FileInfo(filePath);
                string uri = "ftp://" + hostName + targetDir + fileInf.Name;
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

        #region WebClient上传文件

        /// <summary>
        /// 上传文件到服务器上
        /// </summary>
        /// <param name="url">指定上传服务器文件路径</param>
        /// <param name="filePath">本地文件路径</param>
        public void UploadFile(string url, string filePath)
        {
            Uri uri = new Uri(url);
            WebClient client = new WebClient();
            client.UploadProgressChanged += client_UploadProgressChanged;
            client.UploadFileCompleted += Client_UploadFileCompleted;
            client.UploadFileAsync(uri, filePath);
        }

        private void Client_UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            //todo 上传完成
        }

        private void client_UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            var sad = e.ProgressPercentage;
            Debug.WriteLine(sad);
            //todo 文件上传进度
        }

        #endregion
        
        /// <summary>
        /// 读取服务器上文件的内容
        /// </summary>
        /// <param name="url">服务上文件的地址</param>
        /// <returns>文件的内容</returns>
        public string GetHtml(string url)
        {
            string html = "";
            HttpWebResponse response = null;
            StreamReader sr = null;
            try
            {
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                request.Method = "GET";
                request.Timeout = InitConfig.DownLoadOutTime;//连接超时
                response = (HttpWebResponse)request.GetResponse();
                using (Stream s = response.GetResponseStream())
                {
                    sr = new StreamReader(s);
                    html = sr.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                LogUtil.Error("GetHtml(string url)->" + ex);
            }
            finally
            {
                if (response != null)
                { response.Close(); }
                if (sr != null)
                {
                    sr.Close();
                    sr.Dispose();
                }
            }
            return html;
        }
    }
}
