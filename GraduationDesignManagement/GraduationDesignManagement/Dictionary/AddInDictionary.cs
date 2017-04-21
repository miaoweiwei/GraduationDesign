using System.Collections.Generic;

namespace GraduationDesignManagement.Dictionary
{
    public static class AddInDictionary
    {
        private static Dictionary<string, string> _studentDictionary;
        /// <summary>
        /// 学生字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> StudentDictionary()
        {
            if (_studentDictionary == null)
            {
                _studentDictionary = new Dictionary<string, string>
                {
                    {"studentid", "学号"},
                    {"studentname", "姓名"},
                    {"studentgender", "性别"},
                    {"tudentclass", "班级"},
                    {"stupassword", "登录密码"},
                };
            }
            return _studentDictionary;
        }

        private static Dictionary<string, string> _teacherDictionary;
        /// <summary>
        /// 教师字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> TeacherDictionary()
        {
            if (_teacherDictionary==null)
            {
                _teacherDictionary=new Dictionary<string, string>()
                {
                    { "teacherid","教师工号"},
                    { "teachername","姓名"},
                    { "gender","性别"},
                    { "teapassword","登录密码"},

                    { "positioncode","职位代码"},
                    {"positionname", "职位名称"},

                    {"departmentid", "部门Id"},
                    {"departmentname", "部门名称"},
                };
            }
            return _teacherDictionary;
        }

        private static Dictionary<string, string> _positionDictionary;
        /// <summary>
        /// 教师职位字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> PositionDictionary()
        {
            if (_positionDictionary == null)
            {
                _positionDictionary = new Dictionary<string, string>
                {
                    {"positioncode", "职位代码"},
                    {"positionname", "职位名称"},
                };
            }
            return _positionDictionary;
        }


        private static Dictionary<string, string> _departmentDictionary;
        /// <summary>
        /// 教师部门字典
        /// </summary>
        /// <returns></returns>
        public static Dictionary<string, string> DepartmentDictionary()
        {
            if (_departmentDictionary == null)
            {
                _departmentDictionary = new Dictionary<string, string>
                {
                    {"departmentid", "部门Id"},
                    {"departmentname", "部门名称"},
                };
            }
            return _departmentDictionary;
        }
    }
}