using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using GraduationDesignManagement.Common;
using GraduationDesignManagement.Enum;
using GraduationDesignManagement.MysqlData;
using Newtonsoft.Json;

namespace GraduationDesignManagement.BusinessServices
{
    class LogonBusinessService
    {
        private DataQuery _dataQuery;

        /// <summary> 登录状态 </summary>
        public bool IsAddInLogon { get; private set; }
        /// <summary> 老师 学生 密码错误 不存在用户 </summary>
        public UserTypeInfo UserTypeInfo { get; private set; }

        /// <summary> 用户Id </summary>
        public string UserId;
        /// <summary> 用户名 </summary>
        public string UserName;
        /// <summary> 用户名 </summary>
        public object UserObj;
        /// <summary> 用户名对应的系 系里的所有班级 </summary>
        public List<string> ClassList;

        /// <summary> 保存用户的权限列表 </summary>
        public Dictionary<string, bool> AuthDic =new Dictionary<string, bool>();
        
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

        private LogonBusinessService()
        {
            _dataQuery = DataQuery.Instance;
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
                UserObj = GetUserInfo(user, userTypeInfo);

                ClassList = GetDepartmentClass(userTypeInfo,UserId);
                AuthDic =GetAuthList(UserObj, userTypeInfo);
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
            UserObj = null;
            IsAddInLogon = false;
        }

        /// <summary>
        /// 获取用户信息
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userType"></param>
        /// <returns></returns>
        private object GetUserInfo(string userId,UserTypeInfo userType)
        {
            object obj = null;
            DataRow dataRow = null;
            switch (UserTypeInfo)
            {
                case UserTypeInfo.Teacher:
                    dataRow = _dataQuery.GetTeacherDataRow(UserId);
                    obj = _dataQuery.DataRowToObject<Teacher>(dataRow);
                    UserName = ((Teacher) obj).TeacherName;
                    break;
                case UserTypeInfo.Student:
                    dataRow = _dataQuery.GetStudentDataRow(UserId);
                    obj = _dataQuery.DataRowToObject<Student>(dataRow);
                    UserName = ((Student) obj).StudentName;
                    break;
            }
            return obj;
        }
        
        /// <summary>
        /// 获得用户权限
        /// </summary>
        private Dictionary<string,bool> GetAuthList(object obj, UserTypeInfo userType)
        {
            Dictionary < string, bool> dictionary=new Dictionary<string, bool>();
            if (!IsAddInLogon || (userType !=UserTypeInfo.Student && userType != UserTypeInfo.Teacher))
                return dictionary;
            switch (UserTypeInfo)
            {
                case UserTypeInfo.Teacher:
                    Teacher teacher = (Teacher) obj;
                    if (!string.IsNullOrEmpty(teacher.TeacherName))
                        UserName = teacher.TeacherName;
                    dictionary = GetTeacherAuth(teacher);
                    break;
                case UserTypeInfo.Student:
                    Student student = (Student) obj;
                    if (string.IsNullOrEmpty(student.StudentName))
                        UserName = student.StudentName;
                    dictionary = GetStudentAuth(student);
                    break;
            }
            return dictionary;
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
                    {"btnShcedule", true}, //毕设日程设定
                    {"btnCandidateMentor", true}, //选择毕设候选导师
                    {"btnCandidateStudent", true}, //选择毕设候选学生

                    {"groupManagement", (!string.IsNullOrEmpty(teacher.IsCan) && teacher.IsCan == "1")}, //毕设管理group
                    { "btnAccessMaterials",false},
                    {"groupStudent", false}, //我的毕业设计group

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

                    {"groupManagement", (!string.IsNullOrEmpty(teacher.IsCan) && teacher.IsCan == "1")}, //毕设管理group
                    { "btnAccessMaterials",(!string.IsNullOrEmpty(teacher.IsCan) && teacher.IsCan == "1")},//导师毕设管理里的资料管理
                    {"groupStudent", false}, //我的毕业设计group

                    {"btnBeginReply", (!string.IsNullOrEmpty(teacher.IsCan) && teacher.IsCan == "1")}, //开题
                    {"btnMiddleReply", (!string.IsNullOrEmpty(teacher.IsCan) && teacher.IsCan == "1")}, //中期
                    {"btnEndReply", (!string.IsNullOrEmpty(teacher.IsCan) && teacher.IsCan == "1")}, //结题

                    {"btnScorestSort", (!string.IsNullOrEmpty(teacher.IsCan) && teacher.IsCan == "1")}, //毕设成绩分析
                    {"btnScorestChart", (!string.IsNullOrEmpty(teacher.IsCan) && teacher.IsCan == "1")}, //图表
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

                    {"groupManagement", false}, //毕设管理group
                    {"groupStudent", (!string.IsNullOrEmpty(student.IsCan) && student.IsCan == "1")}, //我的毕业设计group

                    {"btnBeginReply", (!string.IsNullOrEmpty(student.IsCan) && student.IsCan == "1")}, //开题
                    {"btnMiddleReply", (!string.IsNullOrEmpty(student.IsCan) && student.IsCan == "1")}, //中期
                    {"btnEndReply", (!string.IsNullOrEmpty(student.IsCan) && student.IsCan == "1")}, //结题

                    {"btnScorestSort", (!string.IsNullOrEmpty(student.IsCan) && student.IsCan == "1")}, //毕设成绩分析
                    {"btnScorestChart", (!string.IsNullOrEmpty(student.IsCan) && student.IsCan == "1")}, //图表
                };
            return dic;
        }

        /*******************************************数据解析************************************************/

        /// <summary>
        /// 获取用户所在系的班级
        /// </summary>
        /// <returns></returns>
        public List<string> GetDepartmentClass(UserTypeInfo userType,string userId)
        {
            List<string> classList=new List<string>();
            if (!IsAddInLogon || string.IsNullOrEmpty(userId))
                return classList;
            if (userType!=UserTypeInfo.Student && userType!=UserTypeInfo.Teacher)
                return classList;

            DataTable dataTable = null;
            dataTable = _dataQuery.GetClassDataTable(userId,userType);

            if (dataTable == null || dataTable.Rows.Count <= 0)
                return classList;
            foreach (DataRow dataRow in dataTable.Rows)
            {
                classList.Add(dataRow[0].ToString());
            }
            return classList;
        }
    }
}
