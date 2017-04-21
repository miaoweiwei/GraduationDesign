using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Reflection;
using System.Text;
using GraduationDesignManagement.Common;
using GraduationDesignManagement.MysqlData;
using MySql.Data.MySqlClient;

namespace GraduationDesignManagement.BusinessServices
{
    public class DataQuery
    {
        MySqlDataHelper  _mySqlDataHelper=new MySqlDataHelper(InitConfig.MysqlConnectSt);

        /// <summary>
        /// 返回登录是否成功查询用户是否存在 并 返回返回用户类型
        /// </summary>
        /// <param name="user">userId</param>
        /// <param name="password">密码</param>
        /// <param name="userTypeInfo">
        /// 返回用户类型</param>
        /// <returns>返回登录是否成功</returns>
        public bool GetLoginState(string user, string password,out UserTypeInfo userTypeInfo)
        {
            userTypeInfo = UserTypeInfo.NotExist;
            try
            {
                DataRow dataRow=null;
                MySqlParameter[] parameters=new MySqlParameter[] {new MySqlParameter("User",user), };

                string sql = "SELECT stupassword FROM student_table WHERE studentid=?User;";
                dataRow = _mySqlDataHelper.ExecuteDataRow(sql, parameters);
                if (dataRow != null)
                {
                    string tempPassword = dataRow["stupassword"].ToString();
                    if (tempPassword == password)
                    {
                        userTypeInfo = UserTypeInfo.Student;
                        LogUtil.Info("学生用户登录 用户名：" + user);
                        return true;
                    }
                    else
                    {
                        userTypeInfo = UserTypeInfo.PasswordError;
                        LogUtil.Info("学生用户登录失败密码错误 用户名：" + user);
                        return false;
                    }
                }
                sql = "SELECT teapassword FROM teacher_table WHERE teacherid=?User;";
                dataRow = null;
                dataRow = _mySqlDataHelper.ExecuteDataRow(sql, parameters);
                if (dataRow != null)
                {
                    string tempPassword = dataRow["teapassword"].ToString();
                    if (tempPassword == password)
                    {
                        userTypeInfo = UserTypeInfo.Teacher;
                        LogUtil.Info("教师用户登录 用户名：" + user);
                        return true;
                    }
                    else
                    {
                        userTypeInfo = UserTypeInfo.PasswordError;
                        LogUtil.Info("教师用户登录失败密码错误 用户名：" + user);
                        return false;
                    }
                }
                userTypeInfo = UserTypeInfo.NotExist;
                LogUtil.Info("不存在该用户 用户名：" + user);
                return false;
            }
            catch (Exception e)
            {
                userTypeInfo = UserTypeInfo.NotExist;
                LogUtil.Error("登录失败出现错误 用户名：" + user+"->"+e);
                return false;
            }
        }
        /// <summary>
        /// 获取教师信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataRow GetTeacherDataRow(string userId)
        {
            string sql = "SELECT * FROM teacher_table WHERE teacherid=?User;";
            MySqlParameter[] param=new MySqlParameter[] {new MySqlParameter("User",userId), };
            var dataRow = _mySqlDataHelper.ExecuteDataRow(sql, param);
            return dataRow;
        }

        public DataRow GetStudentDataRow(string userId)
        {
            string sql = "SELECT * FROM student_table WHERE studentid=?User;";
            MySqlParameter[] param = new MySqlParameter[] { new MySqlParameter("User", userId), };
            var dataRow = _mySqlDataHelper.ExecuteDataRow(sql, param);
            return dataRow;
        }

        /// <summary>
        /// 把datatable转化为指定的对象List
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="className"></param>
        /// <returns></returns>
        public List<T> DataTableToList<T>(DataTable dt) where T : new()
        {
            if (dt == null)
                return null;
            List<T> list = new List<T>();
            //遍历DataTable中所有的数据行
            foreach (DataRow dr in dt.Rows)
            {
                //类所在的namespace
                Type type = typeof(T);
                T t = DataRowToObject<T>(dr);
                //对象添加到泛型集合中
                list.Add(t);
            }
            return list;
        }

        /// <summary>
        /// 把DataRow转成对应的对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dataRow"></param>
        /// <returns></returns>
        public T DataRowToObject<T>(DataRow dataRow) where T : new()
        {
            if (dataRow==null)
                return new T();
            //类所在的namespace
            Type type = typeof(T);
            T t = new T();
            PropertyInfo[] propertys = t.GetType().GetProperties();
            foreach (PropertyInfo pro in propertys)
            {
                //检查dataRow是否包含此列（列名==对象的属性名）  
                if (dataRow.Table.Columns.Contains(pro.Name))
                {
                    object value = dataRow[pro.Name];
                    Type tmpType = Nullable.GetUnderlyingType(pro.PropertyType) ?? pro.PropertyType;
                    object safeValue = (value == null) ? null : Convert.ChangeType(value, tmpType);
                    //如果非空，则赋给对象的属性  PropertyInfo
                    if (safeValue != DBNull.Value)
                    {
                        pro.SetValue(t, safeValue, null);
                    }
                }
            }
            return t;
        }
    }

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
