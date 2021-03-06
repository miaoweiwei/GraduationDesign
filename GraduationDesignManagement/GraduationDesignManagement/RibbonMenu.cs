﻿using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data;
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
using GraduationDesignManagement.EnumClass;
using GraduationDesignManagement.Game.GluttonousSnake;
using GraduationDesignManagement.MysqlData;
using GraduationDesignManagement.Properties;
using GraduationDesignManagement.Views;
using log4net.Config;
using Microsoft.Office.Interop.Word;
using SumscopeAddIn.Views;
using Excel=Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using DataTable = System.Data.DataTable;
using Image = System.Drawing.Image;

namespace GraduationDesignManagement
{
    [ComVisible(true)]
    public class RibbonMenu : ExcelRibbon
    {
        /// <summary>
        /// Excel Application
        /// </summary>
        private static  Application _xlApp = (Application)ExcelDnaUtil.Application;

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
            _xlApp = ExcelHelper.GetXlApplication();
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
                CloseVisibleCtp();
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
            CustomTaskPane setSchedulePane = CustomTaskPaneFactory.CreateCustomTaskPane(setSchedule, "设置毕业日程");
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
        /// <summary> 资料管理 </summary>
        public void btnUpDateFile_Click(IRibbonControl control)
        {
            CloseVisibleCtp();

            FileManagement fileManagement = new FileManagement();
            var fileManagementPane = CustomTaskPaneFactory.CreateCustomTaskPane(fileManagement, "资料管理");
            fileManagementPane.Width = 200;
            fileManagementPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionTop; //在上面弹出

            CustomTaskPaneList.Add(fileManagementPane);
            //传递CTP
            fileManagement.TaskPaneFileManagement = fileManagementPane;
            fileManagementPane.Visible = true;
        }
        /// <summary> 答辩分组 </summary>
        public void btnReplyTeacher_Click(IRibbonControl control)
        {
            CloseVisibleCtp();

            ReplyGroup replyGroup = new ReplyGroup();
            var replyGroupPane = CustomTaskPaneFactory.CreateCustomTaskPane(replyGroup, "选择学生");
            replyGroupPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionBottom; //在下面弹出

            CustomTaskPaneList.Add(replyGroupPane);
            //传递CTP
            replyGroup.TaskPaneReplyGroup = replyGroupPane;
            replyGroupPane.Visible = true;
        }

        #endregion

        #region 毕设管理

        /// <summary> 获取毕设日程 </summary>
        public void btnTeacherGetPlan_Click(IRibbonControl control)
        {
            ScheduleExportToExcel();
        }
        /// <summary> 添加毕设项目 </summary>
        public void btnAddProject_Click(IRibbonControl control)
        {
            CloseVisibleCtp();
            AddProjectFrm addProjectFrm = new AddProjectFrm();
            CustomTaskPane addProjectFrmPane = CustomTaskPaneFactory.CreateCustomTaskPane(addProjectFrm, "添加毕设项目");
            addProjectFrmPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionBottom; //在下面弹出

            CustomTaskPaneList.Add(addProjectFrmPane);
            //传递CTP
            addProjectFrm.TaskPaneAddProjectFrm = addProjectFrmPane;
            addProjectFrmPane.Visible = true;
        }
        /// <summary> 我的毕业生 </summary>
        public void btnSelectStudent_Click(IRibbonControl control)
        {
            CloseVisibleCtp();
            MyStudent myStudent = new MyStudent();
            CustomTaskPane myStudentPane = CustomTaskPaneFactory.CreateCustomTaskPane(myStudent, "我的毕业生");
            myStudentPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionBottom; //在下面弹出

            CustomTaskPaneList.Add(myStudentPane);
            //传递CTP
            myStudent.TaskPaneMyStudent = myStudentPane;
            myStudentPane.Visible = true;
        }
        /// <summary> 资料获取 </summary>
        public void btnAccessMaterials_Click(IRibbonControl control)
        {
            CloseVisibleCtp();
            FileManagement fileManagement = new FileManagement();
            var fileManagementPane = CustomTaskPaneFactory.CreateCustomTaskPane(fileManagement, "资料管理");
            fileManagementPane.Width = 200;
            fileManagementPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionTop; //在上面弹出

            CustomTaskPaneList.Add(fileManagementPane);
            //传递CTP
            fileManagement.TaskPaneFileManagement = fileManagementPane;
            fileManagementPane.Visible = true;
        }
        /// <summary> 答辩 </summary>
        public void btnTeacherReply_Click(IRibbonControl control)
        {
            CloseVisibleCtp();
            
            ReplyTeacher replyTeacher = new ReplyTeacher();
            CustomTaskPane replyTeacherPane = CustomTaskPaneFactory.CreateCustomTaskPane(replyTeacher, "答辩");
            replyTeacherPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionTop; //在上面弹出
            
            CustomTaskPaneList.Add(replyTeacherPane);
            //传递CTP
            replyTeacher.TaskPaneReplyTeacher = replyTeacherPane;
            replyTeacherPane.Visible = true;
        }

        #endregion

        #region 我的毕业设计

        /// <summary> 获取毕设日程 </summary>
        public void btnStudentGetPlan_Click(IRibbonControl control)
        {
            ScheduleExportToExcel();
        }
        /// <summary> 选择毕业设计项目 </summary>
        public void btnSelectProject_Click(IRibbonControl control)
        {
            CloseVisibleCtp();
            
            SelectProject selectProject = new SelectProject();
            var selectProjectPane = CustomTaskPaneFactory.CreateCustomTaskPane(selectProject, "选择项目");
            selectProjectPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionBottom; //在下面弹出

            CustomTaskPaneList.Add(selectProjectPane);
            //传递CTP
            selectProject.TaskPaneSelectProject = selectProjectPane;
            
            MyProject myProject=new MyProject();
            var myProjectPane = CustomTaskPaneFactory.CreateCustomTaskPane(myProject, "我的项目");
            myProjectPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionBottom; //在下面弹出

            CustomTaskPaneList.Add(myProjectPane);
            //传递CTP
            myProject.TaskPaneMyProject = myProjectPane;
            myProject.TaskPaneSelectProject = selectProjectPane;

            DataQuery dataQuery = DataQuery.Instance;
            var gradations = dataQuery.GetGraduationDesign(_logonBusinessService.UserTypeInfo, _logonBusinessService.UserId);
            if (gradations == null || gradations.Count <= 0)
                selectProjectPane.Visible = true;
            else
            {
                myProjectPane.Visible = true;
            }
        }
        /// <summary> 资料获取 </summary>
        public void btnGetData_Click(IRibbonControl control)
        {
            CloseVisibleCtp();
            FileManagement fileManagement = new FileManagement();
            var fileManagementPane = CustomTaskPaneFactory.CreateCustomTaskPane(fileManagement, "获取资料");
            fileManagementPane.Width = 200;
            fileManagementPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionTop; //在上面弹出

            CustomTaskPaneList.Add(fileManagementPane);
            //传递CTP
            fileManagement.TaskPaneFileManagement = fileManagementPane;
            fileManagementPane.Visible = true;
        }
        /// <summary> 我的毕业设计答辩 </summary>
        public void btnStudentReply_Click(IRibbonControl control)
        {
            CloseVisibleCtp();

            ReplyStudent replyStudent = new ReplyStudent();
            CustomTaskPane replyStudentPane = CustomTaskPaneFactory.CreateCustomTaskPane(replyStudent, "我的答辩");
            replyStudentPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionTop; //在上面弹出

            CustomTaskPaneList.Add(replyStudentPane);
            //传递CTP
            replyStudent.TaskPaneReplyStudent = replyStudentPane;
            replyStudentPane.Visible = true;
        }

        #endregion
        
        #region 毕设成绩

        public void btnScorestSort_Click(IRibbonControl control)
        {
            CloseVisibleCtp();

            ScorestAnalysis secAnalysis = new ScorestAnalysis();
            var secAnalysisPane = CustomTaskPaneFactory.CreateCustomTaskPane(secAnalysis, "毕设成绩");
            secAnalysisPane.Width = 250;
            secAnalysisPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionBottom; //在下面弹出
            
            ChartUserControl chartUser=new ChartUserControl();
            var chartUserPane= CustomTaskPaneFactory.CreateCustomTaskPane(chartUser, "导出成绩");
            chartUserPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionBottom; //在下面弹出
            
            //传递CTP
            secAnalysis.TaskPaneScorestAnalysis = secAnalysisPane;
            secAnalysis.TaskPaneChartUserControl = chartUserPane;

            chartUser.TaskPaneScorestAnalysis = secAnalysisPane;
            chartUser.TaskPaneChartUserControl = chartUserPane;

            CustomTaskPaneList.Add(secAnalysisPane);
            CustomTaskPaneList.Add(chartUserPane);
            
            secAnalysisPane.Visible = true;
        }

        public void btnScorestChart_Click(IRibbonControl control)
        {
            object[,] dataObj;

            DataQuery dataQuery=DataQuery.Instance;
            Student student = (Student) _logonBusinessService.UserObj;
            GraduationDesign graduation = dataQuery.GetMyGraduationDesign(student.StudentId);

            if (graduation == null)
                dataObj=new object[1,1] { {"不存在该学生！"} };
            else
            {
                dataObj = new object[2, 6];
                dataObj[0, 0] = "学号";
                dataObj[0, 1] = "姓名";
                dataObj[0, 2] = "开题成绩";
                dataObj[0, 3] = "中期成绩";
                dataObj[0, 4] = "结题成绩";
                dataObj[0, 5] = "总成绩";

                dataObj[1, 0] = student.StudentId;
                dataObj[1, 1] = student.StudentName;
                dataObj[1, 2] = graduation.BeginScore;
                dataObj[1, 3] = graduation.MiddleScore;
                dataObj[1, 4] = graduation.EndScore;
                dataObj[1, 5] =
                    Math.Round(graduation.BeginScore * 0.3 + graduation.MiddleScore * 0.3 + graduation.EndScore * 0.4, 0);
            }
            ExcelHelper.ExportToExcel(dataObj);
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
            snakeControlTaskPane.DockPosition = MsoCTPDockPosition.msoCTPDockPositionLeft; //在右边弹出

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

            //导师毕设管理group 
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
            //导师毕设管理里的资料管理
            if (authorityDic.ContainsKey("btnAccessMaterials"))
            {
                _isbtnAccessMaterials = authorityDic.ContainsKey("_isbtnAccessMaterials");
                _ribbonUi.InvalidateControl("btnAccessMaterials");
            }
            else
            {
                _isbtnAccessMaterials = false;
                _ribbonUi.InvalidateControl("btnAccessMaterials");
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

        private bool _isbtnAccessMaterials;

        /// <summary> 我的毕业设计group </summary>
        private bool _isgroupStudent;

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
                case "btnAccessMaterials":  //资料管理
                    return _isbtnAccessMaterials;

                case "groupStudent":        //我的毕业设计
                    return _isgroupStudent;
                    
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

        /// <summary> 导出毕设日程 </summary>
        private void ScheduleExportToExcel()
        {
            try
            {
                DataQuery dataQuery = DataQuery.Instance;
                DataTable dataTable = dataQuery.GetScheduleDataTable();

                List<Schedule> schedules = dataQuery.DataTableToList<Schedule>(dataTable);
            
                List<Schedule> beginList = schedules.Where(s => s.DateType == "BeginReply").ToList();
                List<Schedule> middleList = schedules.Where(s => s.DateType == "MiddleReply").ToList();
                List<Schedule> endList = schedules.Where(s => s.DateType == "EndReply").ToList();

                object[,] objectArr = new object[beginList.Count + middleList .Count+ endList .Count+ 9, 3];

                int row = 0;
                objectArr[row, 0] = "开题日程";
                objectArr[row+1, 0] = "开始时间";
                objectArr[row+1, 1] = "结束时间";
                objectArr[row+1, 2] = "事项";
                row = row + 2;
                for (int i = 0; i < beginList.Count; i++)
                {
                    objectArr[row + i, 0] = beginList[i].BeginDate;
                    objectArr[row + i, 1] = beginList[i].EndDate;
                    objectArr[row + i, 2] = beginList[i].Matter;
                }
                row = row + beginList.Count+1;

                objectArr[row, 0] = "中期日程";
                objectArr[row+1, 0] = "开始时间";
                objectArr[row+1, 1] = "结束时间";
                objectArr[row+1, 2] = "事项";
                row = row + 2;
                for (int i = 0; i < middleList.Count; i++)
                {
                    objectArr[row + i, 0] = middleList[i].BeginDate;
                    objectArr[row + i, 1] = middleList[i].EndDate;
                    objectArr[row + i, 2] = middleList[i].Matter;
                }
                row = row + middleList.Count + 1;

                objectArr[row, 0] = "结题日程";
                objectArr[row + 1, 0] = "开始时间";
                objectArr[row + 1, 1] = "结束时间";
                objectArr[row + 1, 2] = "事项";
                row = row + 2;
                for (int i = 0; i < endList.Count; i++)
                {
                    objectArr[row + i, 0] = endList[i].BeginDate;
                    objectArr[row + i, 1] = endList[i].EndDate;
                    objectArr[row + i, 2] = endList[i].Matter;
                }
                ExcelHelper.ExportToExcel(objectArr);
            }
            catch (Exception exception)
            {
                LogUtil.Error("日程获取 组织数据出错->" + exception);
            }
        }

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