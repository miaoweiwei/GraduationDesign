using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using GraduationDesignManagement.Common;

namespace GraduationDesignManagement.Views
{
    public partial class FrmVersion : Form
    {
        /// <summary>  当前版本 </summary>
        private readonly Version _currentVer;
        /// <summary> 安装包的本地路径 </summary>
        private string _installPackagePath;

        readonly ServerHelper _upDownHelper=new ServerHelper();
        /// <summary> 安装包URL路径  </summary>
        private string _downloadFilePath;
        /// <summary> 安装包名称  </summary>
        private string _fileName;
        /// <summary> 新的安装包的版本 </summary>
        private Version _newVersion;
        private readonly WebClient _webClient = new WebClient();
        #region 单例

        private static FrmVersion _instance = null;
        private static readonly object LockHelper = new object();

        public static FrmVersion Instance
        {
            get
            {
                if (_instance == null || _instance.IsDisposed)
                {
                    lock (LockHelper)
                    {
                        if (_instance == null || _instance.IsDisposed)
                        {
                            _instance = new FrmVersion();
                        }
                    }
                }
                return _instance;
            }
        }

        #endregion

        private FrmVersion()
        {
            InitializeComponent();
            _currentVer = System.Reflection.Assembly.GetExecutingAssembly().GetName().Version;
            labCurrentVer.Text = _currentVer.ToString();

            var appDomain = AppDomain.CurrentDomain;
            var directory = Path.Combine(appDomain.BaseDirectory, "Installer");
            _installPackagePath = directory;
        }

        private void btnCheckUpDate_Click(object sender, EventArgs e)
        {
            LogUtil.Info("检查更新");
            try
            {
                string installerFilePath, fileName;
                Version newVersion;
                if (CheckUpDate(out newVersion,out installerFilePath,out fileName))
                {
                    _newVersion = newVersion;
                    _downloadFilePath = installerFilePath;
                    _fileName = fileName;
                    
                    btnDownload.Visible = true;//下载按钮
                    btnCancel.Visible = true;  //取消按钮

                    labNewVerson.Text = _newVersion.ToString();

                    labnewVer.Visible = true;  //可用更新label
                    labNewVerson.Visible = true;//可用更用的版本

                    btnCheckUpDate.Visible = false;//检查更新
                }
                else
                {
                    MessageBox.Show(@"无最新版本");
                }
            }
            catch 
            {
                MessageBox.Show(@"检测更新失败");
            }
        }

        /// <summary>
        /// 检测版本更新
        /// </summary>
        /// <param name="version">文件版本</param>
        /// <param name="installerFilePath">out 出安装包的下载路径</param>
        /// <param name="fileName">out 出安装包的名称</param>
        /// <returns>是否有更新</returns>
        private bool CheckUpDate(out Version version, out string installerFilePath, out string fileName)
        {
            version = new Version();
            installerFilePath = string.Empty;
            fileName = string.Empty;
            bool flag = false;
            string serverFilePath = InitConfig.DomainName + InitConfig.ServerInstallPath;
            string checkFileName = serverFilePath + InitConfig.CheckFileName;
            string installerSt = _upDownHelper.GetHtml(checkFileName);
            Installer installers = XmlUtil.Deserialize<Installer>(installerSt);
            installers.Installs.Sort();
            if (installers.Installs.Any())
            {
                for (int i = 0; i < installers.Installs.Count; i++)
                {
                    if (string.IsNullOrEmpty(installers.Installs[i].FileVersion) || string.IsNullOrEmpty(installers.Installs[i].FilerPath))
                    {
                        if (i == installers.Installs.Count - 1)
                        {
                            flag = false;
                        }
                        continue;
                    }
                    Version newVersion;
                    if (Version.TryParse(installers.Installs[i].FileVersion, out newVersion) && newVersion > _currentVer)
                    {
                        serverFilePath = string.Format("{0}//{1}//{2}", serverFilePath, installers.Installs[i].FilerPath, installers.Installs[i].FilerName);
                        installerFilePath = serverFilePath;
                        version = newVersion;
                        fileName = installers.Installs[i].FilerName;
                        flag = true;
                    }
                    else
                    {
                        flag = false;
                    }
                    break;
                }
            }
            return flag;
        }

        #region 下载

        /// <summary>
        /// 下载安装包
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnDownload_Click(object sender, EventArgs e)
        {
            pgbDownload.Visible = true;
            labDownloadprg.Visible = true;
            labDownprg.Visible = true;

            btnDownload.Enabled = false;
            btnCancel.Enabled = false;
            try
            {
                string fileLocalPath = Path.Combine(_installPackagePath, _fileName);
                if (!Directory.Exists(_installPackagePath))
                    Directory.CreateDirectory(_installPackagePath);
                if (File.Exists(fileLocalPath))
                    File.Delete(fileLocalPath);

                //创建文件后会返回该文件的Stream 所以要close（）一下
                Stream outStream = File.Create(fileLocalPath);
                outStream.Close();
                _webClient.DownloadProgressChanged += WebClient_DownloadProgressChanged;
                _webClient.DownloadFileCompleted += WebClient_DownloadFileCompleted;
                Uri uri = new Uri(_downloadFilePath);
                _webClient.DownloadFileAsync(uri, fileLocalPath);
            }
            catch (Exception exception)
            {
                LogUtil.Error("btnDownload_Click(object sender, EventArgs e)->" + exception);
            }
        }

        //下载完成
        private void WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            if (e.Error!=null) 
            {
                LogUtil.Error("WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)->" + e.Error);
                return;
            }
            try
            {
                Invoke(new Action(delegate
                {
                    if (MessageBox.Show("\t升级插件需要关闭Excel\r\n \t是否立即升级?", @"升级提示", MessageBoxButtons.OKCancel) ==
                        DialogResult.OK)
                    {
                        _installPackagePath = Path.Combine(_installPackagePath, _fileName);
                        Process.Start(_installPackagePath);
                    }
                    this.Close();
                }));
            }
            catch (Exception exception)
            {
                LogUtil.Error("WebClient_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)->" + exception);
            }
        }

        //进度条
        private void WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            try
            {
                Debug.WriteLine(e.ProgressPercentage);
                this.Invoke(new Action(delegate
                {
                    labDownloadprg.Text = e.ProgressPercentage + @"%";
                    pgbDownload.Value = e.ProgressPercentage;
                }));
            }
            catch (Exception ex)
            {
                LogUtil.Error("WebClient_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)" +
                              ex);
            }
        }

        #endregion
        
        /// <summary>
        /// 取消更新
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        //禁用Winform的Close按钮
        //protected override CreateParams CreateParams
        //{
        //    get
        //    {
        //        CreateParams parameters = base.CreateParams;
        //        int CS_NOCLOSE = 0x200;
        //        parameters.ClassStyle |= CS_NOCLOSE;
        //        return parameters;
        //    }
        //}

    }
}