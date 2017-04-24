using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using ExcelDna.Integration;
using ExcelDna.Integration.CustomUI;
using GraduationDesignManagement.BusinessServices;
using GraduationDesignManagement.Common;
using GraduationDesignManagement.Dictionary;
using GraduationDesignManagement.Game.GluttonousSnake;
using GraduationDesignManagement.Properties;
using GraduationDesignManagement.Views;
using log4net.Config;
using SumscopeAddIn.Views;
using Excel=Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using Image = System.Drawing.Image;

namespace GraduationDesignManagement
{
    [ComVisible(true)]
    public class RibbonMenu : ExcelRibbon
    {
        /// <summary>
        /// Excel Application
        /// </summary>
        private static readonly Application XlApp = (Application)ExcelDnaUtil.Application;

        private LogonBusinessService _logonBusinessService;
        //保存打开的CTP窗体
        private static readonly List<CustomTaskPane> CustomTaskPaneList = new List<CustomTaskPane>();

        private IRibbonUI _ribbonUi;

        public void RibbonMenu_Load(IRibbonUI ribbonUi)
        {
            _ribbonUi = ribbonUi;
            //初始化log4net配置
            var appDomain = AppDomain.CurrentDomain;
            XmlConfigurator.Configure(new FileInfo(Path.Combine(appDomain.BaseDirectory, @"Config\App.config")));
            //加载配置文件
            var config = Path.Combine(appDomain.BaseDirectory, "GraduationDesignManagement.dll");
            InitConfig.Init(config);
        }

        #region 登录
        
        public void btnLogin_Click(IRibbonControl control)
        {
            _logonBusinessService = LogonBusinessService.Instance;
            if (!_logonBusinessService.IsAddInLogon)
            {
                LogInFrm frmLogin = new LogInFrm();
                frmLogin.ShowDialog();
                if ((frmLogin.DialogResult == DialogResult.OK) &&(_logonBusinessService.IsAddInLogon))
                {
                    //todo 登录成功
                    _loginLable = "注销";
                    _loginImage = Resources.logout;
                    SetUiAuth(_logonBusinessService.AuthDic);
                }
            }
            else
            {
                _logonBusinessService.LogOut();
                SetUiAuth(_logonBusinessService.AuthDic);
                _loginLable = "登录";
                _loginImage = Resources.login;
            }
            _ribbonUi.Invalidate(); //刷新显示
        }

        private string _loginLable = "登录";

        public string GetLoginLabel(IRibbonControl control)
        {
            return _loginLable;
        }

        private Image _loginImage = Resources.login;
        public Image GetLoginImage(IRibbonControl control)
        {
            return _loginImage;
        }

        #endregion
        
        #region 毕设系统管理

        /// <summary> 毕设日程设定 </summary>
        public void btnShcedule_Click(IRibbonControl control)
        {
            CloseVisibleCtp();

            SetSchedule setSchedule = new SetSchedule();
            CustomTaskPane setSchedulePane = CustomTaskPaneFactory.CreateCustomTaskPane(setSchedule, "选择老师");
            setSchedulePane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionBottom; //在下面弹出
            
            CustomTaskPaneList.Add(setSchedulePane);
            //传递CTP
            setSchedule.TaskPaneSetSchedule = setSchedulePane;

            setSchedulePane.Visible = true;
        }
        /// <summary> 选择毕设候选导师 </summary>
        public void btnCandidateMentor_Click(IRibbonControl control)
        {
            CloseVisibleCtp();

            ChooseTearch chooseTearch = new ChooseTearch();
            var chooseTearchPane = CustomTaskPaneFactory.CreateCustomTaskPane(chooseTearch, "选择老师");
            chooseTearchPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionBottom; //在下面弹出

            CustomTaskPaneList.Add(chooseTearchPane);
            //传递CTP
            chooseTearch.TaskPaneChooseTearch = chooseTearchPane;
            chooseTearchPane.Visible = true;
        }
        /// <summary> 选择毕设候选学生 </summary>
        public void btnCandidateStudent_Click(IRibbonControl control)
        {
            CloseVisibleCtp();

            ChooseStudent chooseStudent = new ChooseStudent();
            var chooseStudentPane = CustomTaskPaneFactory.CreateCustomTaskPane(chooseStudent, "选择学生");
            chooseStudentPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionBottom; //在下面弹出

            CustomTaskPaneList.Add(chooseStudentPane);
            //传递CTP
            chooseStudent.TaskPaneChooseStudent = chooseStudentPane;
            chooseStudentPane.Visible = true;
        }

        #endregion

        #region 毕设管理

        /// <summary> 获取毕设日程 </summary>
        public void btnTeacherGetPlan_Click(IRibbonControl control)
        {

        }
        /// <summary> 添加毕设项目 </summary>
        public void btnAddProject_Click(IRibbonControl control)
        {

        }
        /// <summary> 选择学生 </summary>
        public void btnSelectStudent_Click(IRibbonControl control)
        {

        }
        /// <summary> 已选学生 </summary>
        public void btnSelectedStudent_Click(IRibbonControl control)
        {

        }


        #endregion

        #region 我的毕业设计

        /// <summary> 获取毕设日程 </summary>
        public void btnStudentGetPlan_Click(IRibbonControl control)
        {

        }
        /// <summary> 选择毕业设计项目 </summary>
        public void btnSelectProject_Click(IRibbonControl control)
        {

        }
        /// <summary> 资料获取 </summary>
        public void btnGetData_Click(IRibbonControl control)
        {

        }

        #endregion

        #region 毕设成绩分析

        public void btnScorestSort_Click(IRibbonControl control)
        {
            
        }

        public void btnScorestChart_Click(IRibbonControl control)
        {

        }

        #endregion

        #region 娱乐

        /// <summary>
        /// 贪吃蛇
        /// </summary>
        /// <param name="control"></param>
        public void btnSnake_Click(IRibbonControl control)
        {
            CloseVisibleCtp();
            var snakeControl = new SnakeControl();
            var snakeControlTaskPane = CustomTaskPaneFactory.CreateCustomTaskPane(snakeControl, "贪吃蛇");
            snakeControlTaskPane.Width = 270;
            snakeControlTaskPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionRight; //在右边弹出

            CustomTaskPaneList.Add(snakeControlTaskPane);
            snakeControlTaskPane.Visible = true;
        }

        #endregion

        #region 关于

        public void btnVerInfo_Click(IRibbonControl control)
        {
            //ServerHelper server = new ServerHelper();
            //server.UploadFile("http://mmilu.cn//GraduationDesign//File//SumscopeAddInInstaller.exe", @"D:\Myproject\毕业设计\GraduationDesign\GraduationDesignManagement\GraduationDesignManagement\bin\Debug\Installer\SumscopeAddInInstaller.exe");
            if (FrmVersion.Instance != null && FrmVersion.Instance.Visible == false)
                FrmVersion.Instance.Show(NativeWindow.FromHandle(Process.GetCurrentProcess().MainWindowHandle));
        }

        #endregion

        #region 权限

        /// <summary>
        /// 根据权限列表设置按钮是否可用
        /// </summary>
        private void SetUiAuth(Dictionary<string, bool> authorityDic)
        {
            //毕业设计系统管理group
            if (authorityDic.ContainsKey("groupSystemManage"))
            {
                _isgroupSystemManage = authorityDic["groupSystemManage"];
                _ribbonUi.InvalidateControl("groupSystemManage");
            }
            else
            {
                _isgroupSystemManage = false;
                _ribbonUi.InvalidateControl("groupSystemManage");
            }
            //毕业日程设定
            if (authorityDic.ContainsKey("btnShcedule"))
            {
                _isbtnShcedule = authorityDic["btnShcedule"];
                _ribbonUi.InvalidateControl("btnShcedule");
            }
            else
            {
                _isbtnShcedule = false;
                _ribbonUi.InvalidateControl("btnShcedule");
            }
            //选择毕业候选老师
            if (authorityDic.ContainsKey("btnCandidateMentor"))
            {
                _isbtnCandidateMentor = authorityDic["btnCandidateMentor"];
                _ribbonUi.InvalidateControl("btnCandidateMentor");
            }
            else
            {
                _isbtnCandidateMentor = false;
                _ribbonUi.InvalidateControl("btnCandidateMentor");
            }
            //选择毕设候选学生
            if (authorityDic.ContainsKey("btnCandidateStudent"))
            {
                _isbtnCandidateStudent = authorityDic["btnCandidateStudent"];
                _ribbonUi.InvalidateControl("btnCandidateStudent");
            }
            else
            {
                _isbtnCandidateStudent = false;
                _ribbonUi.InvalidateControl("btnCandidateStudent");
            }
            //毕设管理group 
            if (authorityDic.ContainsKey("groupManagement"))
            {
                _isgroupManagement = authorityDic["groupManagement"];
                _ribbonUi.InvalidateControl("groupManagement");
            }
            else
            {
                _isgroupManagement = false;
                _ribbonUi.InvalidateControl("groupManagement");
            }

            //我的毕业设计group
            if (authorityDic.ContainsKey("groupStudent"))
            {
                _isgroupStudent = authorityDic["groupStudent"];
                _ribbonUi.InvalidateControl("groupStudent");
            }
            else
            {
                _isgroupStudent = false;
                _ribbonUi.InvalidateControl("groupStudent");
            }
            //开题
            if (authorityDic.ContainsKey("btnBeginReply"))
            {
                _isbtnBeginReply = authorityDic["btnBeginReply"];
                _ribbonUi.InvalidateControl("btnBeginReply");
            }
            else
            {
                _isbtnBeginReply = false;
                _ribbonUi.InvalidateControl("btnBeginReply");
            }
            //中期
            if (authorityDic.ContainsKey("btnMiddleReply"))
            {
                _isbtnMiddleReply = authorityDic["btnMiddleReply"];
                _ribbonUi.InvalidateControl("btnMiddleReply");
            }
            else
            {
                _isbtnMiddleReply = false;
                _ribbonUi.InvalidateControl("btnMiddleReply");
            }
            //结题
            if (authorityDic.ContainsKey("btnEndReply"))
            {
                _isbtnEndReply = authorityDic["btnEndReply"];
                _ribbonUi.InvalidateControl("btnEndReply");
            }
            else
            {
                _isbtnEndReply = false;
                _ribbonUi.InvalidateControl("btnEndReply");
            }
            //毕设成绩分析
            if (authorityDic.ContainsKey("btnScorestSort"))
            {
                _isbtnScorestSort = authorityDic["btnScorestSort"];
                _ribbonUi.InvalidateControl("btnScorestSort");
            }
            else
            {
                _isbtnScorestSort = false;
                _ribbonUi.InvalidateControl("btnScorestSort");
            }
            //图表
            if (authorityDic.ContainsKey("btnScorestChart"))
            {
                _isbtnScorestChart = authorityDic["btnScorestChart"];
                _ribbonUi.InvalidateControl("btnScorestChart");
            }
            else
            {
                _isbtnScorestChart = false;
                _ribbonUi.InvalidateControl("btnScorestChart");
            }
        }

        #endregion

        #region 设置控件的可用状态

        /// <summary> 毕设系统管理group </summary>
        private bool _isgroupSystemManage;
        /// <summary> 毕设日程设定 </summary>
        private bool _isbtnShcedule;
        /// <summary> 选择毕设候选导师 </summary>
        private bool _isbtnCandidateMentor;
        /// <summary> 选择毕设候选学生 </summary>
        private bool _isbtnCandidateStudent;

        /// <summary> 毕设管理group </summary>
        private bool _isgroupManagement;

        /// <summary> 我的毕业设计group </summary>
        private bool _isgroupStudent;


        /// <summary> 开题 </summary>
        private bool _isbtnBeginReply;
        /// <summary> 中期 </summary>
        private bool _isbtnMiddleReply;
        /// <summary> 结题 </summary>
        private bool _isbtnEndReply;

        /// <summary> 毕设成绩分析 </summary>
        private bool _isbtnScorestSort;
        /// <summary> 图表 </summary>
        private bool _isbtnScorestChart;

        /// <summary> 当前按钮是否可用(excel启动时候默认的状态) </summary>
        public bool GetControlsVisible(IRibbonControl control)
        {
            switch (control.Id)
            {
                case "groupSystemManage":   //毕设系统管理group
                    return _isgroupSystemManage;
                case "btnShcedule":         //毕设日程设定
                    return _isbtnShcedule;
                case "btnCandidateMentor":  //选择毕设候选导师
                    return _isbtnCandidateMentor;
                case "btnCandidateStudent": //选择毕设候选学生
                    return _isbtnCandidateStudent;
                case "groupManagement":     //毕设管理
                    return _isgroupManagement;

                case "groupStudent":        //我的毕业设计
                    return _isgroupStudent;

                case "btnBeginReply":      //开题
                    return _isbtnBeginReply;
                case "btnMiddleReply":      //中期
                    return _isbtnMiddleReply;
                case "btnEndReply":      //结题
                    return _isbtnEndReply;


                case "btnScorestSort":       //毕设成绩分析
                    return _isbtnScorestSort;
                case "btnScorestChart":       //图表
                    return _isbtnScorestChart;
                default:
                    break;
            }
            return true;
        }

        #endregion
        
        /// <summary> 关闭当前活动的workbook已经打开的窗体 </summary>
        private static void CloseVisibleCtp()
        {
            if (CustomTaskPaneList.Count > 0)
            {
                for (var i = 0; i < CustomTaskPaneList.Count; i++)
                {
                    CustomTaskPaneList[i].Delete();
                    CustomTaskPaneList[i] = null;
                }
                CustomTaskPaneList.Clear();
            }
        }
    }
}