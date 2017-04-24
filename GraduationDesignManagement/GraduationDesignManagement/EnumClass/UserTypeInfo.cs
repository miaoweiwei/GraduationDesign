using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GraduationDesignManagement.Enum
{
    public enum UserTypeInfo
    {
        /// <summary>
        /// 学生
        /// </summary>
        Student,
        /// <summary>
        /// 教师
        /// </summary>
        Teacher,
        /// <summary>
        /// 不存在该用户
        /// </summary>
        NotExist,
        /// <summary>
        /// 密码错误
        /// </summary>
        PasswordError
    }
}
