using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GraduationDesignManagement.MysqlData;
using Newtonsoft.Json;

namespace GraduationDesignManagement.BusinessServices
{
    class LogonBusinessService
    {
        /// <summary> 登录状态 </summary>
        public bool IsAddInLogon { get; private set; }
        /// <summary> 老师 学生 密码错误 不存在用户 </summary>
        public UserTypeInfo UserTypeInfo { get; private set; }

        /// <summary> 用户Id </summary>
        public string UserId;
        /// <summary> 用户名 </summary>
        public string UserName;
        /// <summary> 保存用户的权限列表 </summary>
        public Dictionary<string, bool> AuthDic =new Dictionary<string, bool>();

        private DataQuery _dataQuery = new DataQuery();
        
        #region 单例

        private static LogonBusinessService _logonBusinessService;
        public static LogonBusinessService Instance
        {
            get
            {
                if (_logonBusinessService != null)
                {
                    return _logonBusinessService;
                }
                _logonBusinessService = new LogonBusinessService();
                return _logonBusinessService;
            }
        }

        #endregion

        /// <summary>
        /// 请求登录
        /// </summary>
        /// <param name="user">用户名</param>
        /// <param name="password">密码</param>
        /// <param name="logInInfo">登录信息</param>
        public void Login(string user,string password,out string logInInfo)
        {
            logInInfo = string.Empty;
            UserTypeInfo userTypeInfo;
            if (_dataQuery.GetLoginState(user, password, out userTypeInfo))
            {
                UserId = user;
                IsAddInLogon = true;
                UserTypeInfo = userTypeInfo;
                GetAuthList();
            }
            else
            {
                IsAddInLogon = false;
                logInInfo = "登录失败请确认用户名和密码是否正确";
            }
            UserTypeInfo = userTypeInfo;
        }

        /// <summary>
        /// 注销登录
        /// </summary>
        public void LogOut()
        {
            UserId = "";
            AuthDic.Clear();
            IsAddInLogon = false;
        }


        /// <summary>
        /// 获得用户权限
        /// </summary>
        private void GetAuthList()
        {
            if (!IsAddInLogon || string.IsNullOrEmpty(UserId))
                return;
            DataRow dataRow = null;
            switch (UserTypeInfo)
            {
                case UserTypeInfo.Teacher:
                    dataRow = _dataQuery.GetTeacherDataRow(UserId);
                    Teacher teacher = _dataQuery.DataRowToObject<Teacher>(dataRow);
                    if (string.IsNullOrEmpty(teacher.Teachername))
                        UserName = teacher.Teachername;
                    AuthDic= GetTeacherAuth(teacher);
                    break;
                case UserTypeInfo.Student:
                    dataRow = _dataQuery.GetStudentDataRow(UserId);
                    Student student = _dataQuery.DataRowToObject<Student>(dataRow);
                    if (string.IsNullOrEmpty(student.Studentname))
                        UserName = student.Studentname;
                    AuthDic = GetStudentAuth(student);
                    break;
            }
        }

        /// <summary>
        /// 获取老师权限
        /// </summary>
        /// <param name="teacher"></param>
        /// <returns></returns>
        private Dictionary<string, bool> GetTeacherAuth(Teacher teacher)
        {
            Dictionary<string, bool> dic;
            if (!string.IsNullOrEmpty(teacher.Position) && teacher.Position == "系主任")
            {
                dic = new Dictionary<string, bool>()
                {
                    {"groupSystemManage", true}, //毕设系统管理group
                    {"btnShcedule", false}, //毕设日程设定
                    {"btnCandidateMentor", false}, //选择毕设候选导师
                    {"btnCandidateStudent", false}, //选择毕设候选学生

                    {"groupManagement", (string.IsNullOrEmpty(teacher.Iscan) && teacher.Iscan == "1")}, //毕设管理group

                    {"btnBeginReply", true}, //开题
                    {"btnMiddleReply", true}, //中期
                    {"btnEndReply", true}, //结题

                    {"btnScorestSort", true}, //毕设成绩分析
                    {"btnScorestChart", true}, //图表
                };
            }
            else
            {
                dic = new Dictionary<string, bool>()
                {
                    {"groupSystemManage", false}, //毕设系统管理group
                    {"btnShcedule", false}, //毕设日程设定
                    {"btnCandidateMentor", false}, //选择毕设候选导师
                    {"btnCandidateStudent", false}, //选择毕设候选学生

                    {"groupManagement", (string.IsNullOrEmpty(teacher.Iscan) && teacher.Iscan == "1")}, //毕设管理group

                    {"btnBeginReply", (string.IsNullOrEmpty(teacher.Iscan) && teacher.Iscan == "1")}, //开题
                    {"btnMiddleReply", (string.IsNullOrEmpty(teacher.Iscan) && teacher.Iscan == "1")}, //中期
                    {"btnEndReply", (string.IsNullOrEmpty(teacher.Iscan) && teacher.Iscan == "1")}, //结题

                    {"btnScorestSort", (string.IsNullOrEmpty(teacher.Iscan) && teacher.Iscan == "1")}, //毕设成绩分析
                    {"btnScorestChart", (string.IsNullOrEmpty(teacher.Iscan) && teacher.Iscan == "1")}, //图表
                };
            }
            return dic;
        }

        /// <summary>
        /// 获取学生权限
        /// </summary>
        /// <param name="student"></param>
        /// <returns></returns>
        private Dictionary<string, bool> GetStudentAuth(Student student)
        {
            Dictionary<string, bool> dic;
            dic = new Dictionary<string, bool>()
                {
                    {"groupSystemManage", false}, //毕设系统管理group
                    {"btnShcedule", false}, //毕设日程设定
                    {"btnCandidateMentor", false}, //选择毕设候选导师
                    {"btnCandidateStudent", false}, //选择毕设候选学生

                    {"groupManagement", (string.IsNullOrEmpty(student.Iscan) && student.Iscan == "1")}, //毕设管理group

                    {"btnBeginReply", (string.IsNullOrEmpty(student.Iscan) && student.Iscan == "1")}, //开题
                    {"btnMiddleReply", (string.IsNullOrEmpty(student.Iscan) && student.Iscan == "1")}, //中期
                    {"btnEndReply", (string.IsNullOrEmpty(student.Iscan) && student.Iscan == "1")}, //结题

                    {"btnScorestSort", true}, //毕设成绩分析
                    {"btnScorestChart", true}, //图表
                };
            return dic;
        }

        /*******************************************数据解析************************************************/
        /// <summary>
        /// 解析数据库返回的用户信息
        /// </summary>
        /// <param name="dataRow"> DataRow </param>
        /// <returns> 返回Dictionary&lt;string, string&gt; </returns>
        private Dictionary<string, string> GetStudentInfo( DataRow dataRow)
        {
            Dictionary<string, string> dictionary=new Dictionary<string, string>();
            if (dataRow==null || dataRow.Table.Columns.Count<=0)
                return dictionary;
            foreach (DataColumn dataColumn in dataRow.Table.Columns)
                dictionary.Add(dataColumn.ColumnName, dataRow[dataColumn.ColumnName].ToString());
            return dictionary;
        }
    }
}
