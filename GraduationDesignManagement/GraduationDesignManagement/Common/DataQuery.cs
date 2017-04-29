﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using GraduationDesignManagement.Enum;
using GraduationDesignManagement.MysqlData;
using MySql.Data.MySqlClient;
using DataTable = System.Data.DataTable;

namespace GraduationDesignManagement.Common
{
    public class DataQuery
    {
        MySqlDataHelper _mySqlDataHelper=new MySqlDataHelper(InitConfig.MysqlConnectSt);

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
        /// <summary>
        /// 获取学学生信息
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataRow GetStudentDataRow(string userId)
        {
            string sql = "SELECT * FROM student_table WHERE studentid=?User;";
            MySqlParameter[] param = { new MySqlParameter("User", userId), };
            var dataRow = _mySqlDataHelper.ExecuteDataRow(sql, param);
            return dataRow;
        }

        /// <summary>
        /// 获取用户对应的系 系里的班级
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="userType">用户类型</param>
        /// <returns></returns>
        public DataTable GetClassDataTable(string userId ,UserTypeInfo userType)
        {
            string sqlSt = "";
            switch (userType)
            {
                case UserTypeInfo.Teacher:
                    sqlSt = "SELECT d.class FROM teacher_table t, department_table d WHERE t.teacherid=?User And t.department=d.departmentname;";
                    break;
                case UserTypeInfo.Student:
                    sqlSt =
                        "SELECT class FROM department_table " +
                        "WHERE departmentname=( " +
                        "SELECT d.dep artmentname FROM student_table s , department_table d " +
                        "WHERE s.studentid=?User AND s.class=d.class " +
                        ");";
                    break;
            }
            MySqlParameter[] param = { new MySqlParameter("User", userId), };
            var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);
            return dataTable;
        }

        /// <summary>
        /// 获取毕设日程
        /// </summary>
        /// <returns></returns>
        public DataTable GetScheduleDataTable()
        {
            string sqlSt = "SELECT datetype,begindate,enddate,matter FROM schedule_table;";
            MySqlParameter[] param = {};
             var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);
            return dataTable;
        }

        /// <summary>
        /// 获取 系 名单List
        /// </summary>
        /// <returns></returns>
        public List<string> GetDataTableDepartment()
        {
            string sqlSt = "SELECT * FROM department_table;";
            MySqlParameter[] param = {};
            var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);

            List<string> deparList=new List<string>();
            if (dataTable != null && dataTable.Rows.Count>0)
            {
                foreach (DataRow dataRow in dataTable.Rows)
                {
                    if (!deparList.Contains(dataRow[1].ToString()))
                        deparList.Add(dataRow[1].ToString());
                }
            }
            return deparList;
        }

        /// <summary>
        /// 获取老师List
        /// </summary>
        /// <returns></returns>
        public List<Teacher> GeTeacherList()
        {
            List<Teacher> teacherList=new List<Teacher>();

            //SELECT * FROM teacher_table;

            string sqlSt = "SELECT * FROM teacher_table;";
            MySqlParameter[] param = {};
            var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);

            teacherList = DataTableToList<Teacher>(dataTable);
            return teacherList;
        }

        /// <summary>
        /// 获取老师所在系的 系里所有的老师
        /// </summary>
        /// <param name="userId"></param>
        /// <returns></returns>
        public DataTable GetTeacherDataTable(string userId)
        {
            string sqlSt =
                "SELECT * FROM teacher_table " +
                "WHERE department = ( " +
                "SELECT department FROM teacher_table " +
                "WHERE teacherid = ?User )";
            MySqlParameter[] param = { new MySqlParameter("User", userId), };
            var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);
            return dataTable;
        }

        /// <summary>
        /// 更新选择毕设老师的iscan状态返回更新行数
        /// </summary>
        /// <param name="teacherIdList"></param>
        /// <param name="state">1表示设为导师 0或其他表示不是导师</param>
        /// <param name="userType">用户类型</param>
        /// <returns></returns>
        public int UpDataTeacherIsCan(List<string> teacherIdList, int state,UserTypeInfo userType)
        {
            if (teacherIdList==null || teacherIdList.Count<=0)
                return 0;
            string sqlSt ="";
            switch (userType)
            {
                case UserTypeInfo.Teacher:
                    sqlSt = "UPDATE teacher_table SET iscan = " + state + " WHERE teacherid IN (";
                    break;
                case UserTypeInfo.Student:
                    sqlSt = "UPDATE student_table SET iscan = " + state + " WHERE studentid IN (";
                    break;
            }
            foreach (string s in teacherIdList)
            {
                sqlSt = sqlSt + s + ",";
            }
            sqlSt = sqlSt.Remove(sqlSt.Length - 1) + ")";
            MySqlParameter[] param = { };
            return _mySqlDataHelper.ExecuteNonQuery(sqlSt,param);
        }

        /// <summary>
        /// 根据班级获取学生list
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudentList(List<string>clasList )
        {
            List<Student> students=new List<Student>();
            if (clasList == null || clasList.Count <= 0)
                return students;
            string sqlSt = "SELECT * FROM student_table WHERE class in (";
            foreach (string s in clasList)
            {
                sqlSt = sqlSt +"'"+ s + "',";
            }
            sqlSt = sqlSt.Remove(sqlSt.Length - 1) + ")";
            MySqlParameter[] param = { };
            var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);
            students = DataTableToList<Student>(dataTable);
            return students;
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
        /// 列名 对象属性名转小写对比
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
            
            List<string> columList=new List<string>();
            foreach (DataColumn column in dataRow.Table.Columns)
                columList.Add(column.ColumnName.ToLower());

            foreach (PropertyInfo pro in propertys)
            {
                //检查dataRow是否包含此列（列名==对象的属性名）  
                if (columList.Contains(pro.Name.ToLower()))
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
}