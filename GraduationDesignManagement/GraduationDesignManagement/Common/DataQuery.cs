using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Windows.Forms;
using GraduationDesignManagement.EnumClass;
using GraduationDesignManagement.MysqlData;
using ICSharpCode.SharpZipLib.Zip;
using MySql.Data.MySqlClient;
using DataTable = System.Data.DataTable;

namespace GraduationDesignManagement.Common
{
    public class DataQuery
    {
        private readonly MySqlDataHelper _mySqlDataHelper;
        
        #region 单例

        private static DataQuery _instance;
        public static DataQuery Instance
        {
            get
            {
                if (_instance != null)
                {
                    return _instance;
                }
                _instance = new DataQuery();
                return _instance;
            }
        }

        private DataQuery()
        {
            _mySqlDataHelper = new MySqlDataHelper(InitConfig.MysqlConnectSt);
            if (!_mySqlDataHelper.ConnSucceed)
            {
                MessageBox.Show(@"数据库连接失败,请检查配置是否正确！", @"提示");
            }
        }

        #endregion
        
        /// <summary>
        /// 返回登录是否成功查询用户是否存在 并 返回返回用户类型
        /// </summary>
        /// <param name="user">userId</param>
        /// <param name="password">密码</param>
        /// <param name="userTypeInfo">
        /// 返回用户类型</param>
        /// <returns>返回登录是否成功</returns>
        public bool GetLoginState(string user, string password, out UserTypeInfo userTypeInfo)
        {
            userTypeInfo = UserTypeInfo.NotExist;
            try
            {
                DataRow dataRow = null;
                MySqlParameter[] parameters = new MySqlParameter[] { new MySqlParameter("User", user), };

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
                LogUtil.Error("登录失败出现错误 用户名：" + user + "->" + e);
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
            MySqlParameter[] param = new MySqlParameter[] { new MySqlParameter("User", userId), };
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
        public DataTable GetClassDataTable(string userId, UserTypeInfo userType)
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
                        "SELECT d.departmentname FROM student_table s , department_table d " +
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
            MySqlParameter[] param = { };
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
            MySqlParameter[] param = { };
            var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);

            List<string> deparList = new List<string>();
            if (dataTable != null && dataTable.Rows.Count > 0)
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
            List<Teacher> teacherList = new List<Teacher>();

            //SELECT * FROM teacher_table;

            string sqlSt = "SELECT * FROM teacher_table;";
            MySqlParameter[] param = { };
            var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);

            teacherList = DataTableToList<Teacher>(dataTable);
            return teacherList;
        }

        /// <summary>
        /// 获取是否可以参加毕设的老师List
        /// </summary>
        /// <param name="iscan"></param>
        /// <returns></returns>
        public List<Teacher> GeTeacherList(string iscan)
        {
            List<Teacher> teacherList = new List<Teacher>();
            string sqlSt = "SELECT * FROM teacher_table WHERE iscan=?Iscan;";
            MySqlParameter[] param = {new MySqlParameter("Iscan", iscan),  };
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
        public int UpDataTeacherIsCan(List<string> teacherIdList, int state, UserTypeInfo userType)
        {
            if (teacherIdList == null || teacherIdList.Count <= 0)
                return 0;
            string sqlSt = "";
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
            return _mySqlDataHelper.ExecuteNonQuery(sqlSt, param);
        }
        /// <summary>
        /// 根据班级获取学生list
        /// </summary>
        /// <returns></returns>
        public List<Student> GetStudentList(List<string> clasList)
        {
            List<Student> students = new List<Student>();
            if (clasList == null || clasList.Count <= 0)
                return students;
            string sqlSt = "SELECT * FROM student_table WHERE class in (";
            foreach (string s in clasList)
            {
                sqlSt = sqlSt + "'" + s + "',";
            }
            sqlSt = sqlSt.Remove(sqlSt.Length - 1) + ")";
            MySqlParameter[] param = { };
            var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);
            students = DataTableToList<Student>(dataTable);
            return students;
        }

        /// <summary>
        /// 根据学生Id获取学生List
        /// </summary>
        /// <param name="studentIdList"></param>
        /// <returns></returns>
        public List<Student> GetStudentListById(List<string> studentIdList)
        {
            List<Student>students=new List<Student>();
            if (studentIdList.Count <= 0)
                return students;
            string sqlSt = "SELECT * FROM student_table WHERE studentid in (";
            foreach (string s in studentIdList)
            {
                sqlSt = sqlSt + s + ",";
            }
            sqlSt = sqlSt.Remove(sqlSt.Length - 1) + ")";
            MySqlParameter[]param=new MySqlParameter[] {};
            var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);
            students = DataTableToList<Student>(dataTable);
            return students;
        }

        /// <summary>
        /// 获取ProjectList当userId为Null是获取所有ProjectList
        /// </summary>
        /// <returns></returns>
        public List<Project> GetProjectList(string userId)
        {
            string sqlSt = "";
            MySqlParameter[] param;
            if (userId == null)
            {
                sqlSt = "SELECT * FROM project_table;";
                param = new MySqlParameter[] { };
            }
            else
            {
                sqlSt = "SELECT * FROM project_table WHERE teacherid= ?User";
                param=new MySqlParameter[] { new MySqlParameter("User", userId), };
            }
            var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);
            var projects = DataTableToList<Project>(dataTable);
            return projects;
        }
        /// <summary>
        /// 根据项目Code获取项目List
        /// </summary>
        /// <param name="codeList"></param>
        /// <returns></returns>
        public List<Project> GetProjectListByCode(List<string>codeList )
        {
            List<Project> projects=new List<Project>();
            if (codeList.Count <= 0)
                return projects;
            string sqlSt = "SELECT * FROM project_table WHERE projectcode in (";

            foreach (string s in codeList)
            {
                sqlSt = sqlSt + "'" + s + "',";
            }
            sqlSt = sqlSt.Remove(sqlSt.Length - 1) + ")";
            MySqlParameter[] param=new MySqlParameter[] {};
            var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);
            projects = DataTableToList<Project>(dataTable);
            return projects;
        }

        /// <summary>
        /// 删除项目
        /// </summary>
        /// <param name="projectCodeList"></param>
        /// <returns></returns>
        public int DelectProject(List<string>projectCodeList )
        {
            if (projectCodeList.Count <= 0)
                return 0;
            string sqlSt = "DELETE FROM project_table WHERE projectcode IN (";
            foreach (string s in projectCodeList)
                sqlSt = sqlSt + "'" + s + "'" + ",";
            sqlSt = sqlSt.Remove(sqlSt.Length - 1) + ");";
            MySqlParameter[] param = { };
            return _mySqlDataHelper.ExecuteNonQuery(sqlSt, param);
        }
        /// <summary>
        /// 更新项目相关信息
        /// </summary>
        /// <param name="projects"></param>
        /// <returns></returns>
        public int UpDataProject(List<Project>projects )
        {
            if (projects.Count <= 0)
                return 0;
            string sqlSt = "UPDATE project_table ";
            string projectName = "SET projectname = CASE projectcode ";
            string projectIntroduce = "introduce = CASE projectcode ";
            string projectCode = "WHERE projectcode IN (";
            foreach (Project project in projects)
            {
                projectCode = projectCode + "'" + project.Projectcode + "',";
                projectName = projectName + "WHEN '" + project.Projectcode + "' THEN '" + project.ProjectName + "' ";
                projectIntroduce = projectIntroduce + "WHEN '" + project.Projectcode + "' THEN '" + project.Introduce + "' ";
            }

            projectName = projectName + "END, ";
            projectIntroduce = projectIntroduce + "END ";
            projectCode = projectCode.Remove(projectCode.Length - 1) + ")";
            sqlSt = sqlSt + projectName + projectIntroduce + projectCode;
            MySqlParameter[] param = { };
            return _mySqlDataHelper.ExecuteNonQuery(sqlSt, param);
        }
        /// <summary>
        /// 插入新的项目
        /// </summary>
        /// <param name="projects"></param>
        /// <returns></returns>
        public int InsertProject(List<Project>projects )
        {
            if (projects.Count <= 0)
                return 0;
            string sqlSt = "INSERT INTO project_table(projectname,introduce,teacherid,projectcode) VALUES";
            foreach (Project project in projects)
            {
                string temp = "('" + project.ProjectName + "','" + project.Introduce + "','" + project.TeacherId + "','" + project.Projectcode + "'),";
                sqlSt = sqlSt + temp;
            }
            sqlSt = sqlSt.Remove(sqlSt.Length - 1);
            MySqlParameter[] param = {};
            return _mySqlDataHelper.ExecuteNonQuery(sqlSt, param);
        }

        /// <summary>
        /// 选择项目时更新项目状态 或 更改选择项目时更改项目状态
        /// </summary>
        /// <param name="projectCode"></param>
        /// <param name="state"></param>
        /// <returns></returns>
        public int UpDataProjectState(string projectCode,string state)
        {
            string sqlSt = "UPDATE project_table SET state=?state WHERE projectcode=?projectCode";
            MySqlParameter[] param = new MySqlParameter[]
            {
                new MySqlParameter("state", state), 
                new MySqlParameter("projectCode",projectCode), 
            };
            return _mySqlDataHelper.ExecuteNonQuery(sqlSt, param);
        }

        /// <summary>
        /// 取消之前的项目选择
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public int CancelSelectProject(string studentId)
        {
            //先判断是不是已经选过  若选过 就先设置project 的状态为0
            string sql0 = "SELECT * FROM graduationdesign_table WHERE studentid=?StudentId;";
            MySqlParameter[] param0 = new MySqlParameter[] { new MySqlParameter("StudentId", studentId), };
            var dataRow0 = _mySqlDataHelper.ExecuteDataRow(sql0, param0);
            if (dataRow0 != null)
            {
                GraduationDesign graduation = DataRowToObject<GraduationDesign>(dataRow0);
                if (graduation != null && !string.IsNullOrEmpty(graduation.ProjectCode))
                {
                    string projectCode = graduation.ProjectCode;
                    if (UpDataProjectState(projectCode, "0") == 0)
                        return 0;
                }
            }
            //先判断是不是已经选过  若选过 就先设置project 的状态为0（就是上面的语句）然后再删除这一条记录；
            string sql1 = "DELETE FROM graduationdesign_table WHERE studentid=?StudentId;";
            MySqlParameter[] param1 = new MySqlParameter[] { new MySqlParameter("StudentId", studentId), };
            return _mySqlDataHelper.ExecuteNonQuery(sql1, param1);
        }

        #region 毕业设计的项目 GraduationDesign

        /// <summary>
        /// 选择项目或重新选择项目
        /// </summary>
        /// <param name="project"></param>
        /// <param name="studentId"></param>
        /// <param name="pleaTeacherId">答辩老师</param>
        /// <returns></returns>
        public int SelectProject(Project project,string studentId,string pleaTeacherId)
        {
            //先设置项目的state状态为1
            UpDataProjectState(project.Projectcode, "1");
            string sql2 = "SELECT * FROM project_table WHERE projectcode=?ProjectCode";
            MySqlParameter[] param2=new MySqlParameter[] { new MySqlParameter("ProjectCode", project.Projectcode), };
            var dataRow = _mySqlDataHelper.ExecuteDataRow(sql2, param2);
            Project projectTemp = DataRowToObject<Project>(dataRow);
            if (projectTemp == null || projectTemp.State != "1")
                return 0;

            //然后在向graduationdesign_table里添加一条新的记录；
            string sqlSt = "INSERT INTO graduationdesign_table(projectcode,teacherid,studentid,pleateacherid) VALUES (?ProjectCode,?TeacherId,?StudentId,?PleaTeacherId);";
            MySqlParameter[] param = new MySqlParameter[]
            {
                new MySqlParameter("ProjectCode", project.Projectcode),
                new MySqlParameter("TeacherId",project.TeacherId),
                new MySqlParameter("StudentId",studentId),
                new MySqlParameter("PleaTeacherId",pleaTeacherId), 
            };
            return _mySqlDataHelper.ExecuteNonQuery(sqlSt, param);
        }

        /// <summary>
        /// 获取GraduationDesignList userId为null获取全部
        /// </summary>
        /// <param name="userType"></param>
        /// <param name="userId"> 学生ID或导师的ID</param>
        /// <returns></returns>
        public List<GraduationDesign> GetGraduationDesign(UserTypeInfo userType,string userId)
        {
            string sqlSt = "";
            MySqlParameter[] param;
            if (string.IsNullOrEmpty(userId))
            {
                sqlSt = "SELECT * FROM graduationdesign_table;";
                param=new MySqlParameter[] {};
            }
            else
            {
                param = new MySqlParameter[] { new MySqlParameter("UserId", userId), };
                switch (userType)
                {
                    case UserTypeInfo.Teacher:
                        sqlSt = "SELECT * FROM graduationdesign_table WHERE teacherid=?UserId";
                        break;
                    case UserTypeInfo.Student:
                        sqlSt = "SELECT * FROM graduationdesign_table WHERE studentid=?UserId";
                        break;
                }
            }
            var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);
            var graduationList = DataTableToList<GraduationDesign>(dataTable);
            return graduationList;
        }

        /// <summary>
        /// 根据答辩老师的id获取要答辩的项目
        /// </summary>
        /// <param name="pleaTeacherId"></param>
        /// <returns></returns>
        public List<GraduationDesign> GetGraduationDesign(string pleaTeacherId)
        {
            string sqlSt = sqlSt = "SELECT * FROM graduationdesign_table WHERE pleateacherid=?UserId";
            MySqlParameter[] param=new MySqlParameter[] {new MySqlParameter("UserId", pleaTeacherId), };
            var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);
            var graduationList = DataTableToList<GraduationDesign>(dataTable);
            return graduationList;
        }
        /// <summary>
        /// 根据学生id获取学生的毕业项目
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public GraduationDesign GetMyGraduationDesign(string studentId)
        {
            GraduationDesign graduation=new GraduationDesign();
            string sql = "SELECT * FROM graduationdesign_table WHERE studentid=?StudentId;";
            MySqlParameter[] param = { new MySqlParameter("StudentId", studentId), };
            var dataRow = _mySqlDataHelper.ExecuteDataRow(sql, param);
            graduation = DataRowToObject<GraduationDesign>(dataRow);
            return graduation;
        }
        

        #endregion

        /// <summary>
        /// 上传文件List
        /// </summary>
        /// <param name="serverFileList"></param>
        /// <returns></returns>
        public int UpLoadFile(List<ServerFile> serverFileList)
        {
            if (serverFileList == null || serverFileList.Count <= 0)
                return 0;

            string sqlSt = " INSERT INTO file_table (filecode, filename, uploadtime, username, size) VALUES (";

            foreach (ServerFile serverFile in serverFileList)
            {
                string temp = "('" +
                    serverFile.FileCode + "','" +
                    serverFile.FileName + "','" +
                    serverFile.UpLoadTime + "','" +
                    serverFile.UserName + "','" +
                    serverFile.Size +
                    "'),";
                sqlSt = sqlSt + temp;
            }
            sqlSt = sqlSt.Remove(sqlSt.Length - 1);
            MySqlParameter[] param =new MySqlParameter[] {};
            return _mySqlDataHelper.ExecuteNonQuery(sqlSt, param);
        }

        /// <summary>
        /// 删除资料文件记录
        /// </summary>
        /// <param name="serverFileList"></param>
        /// <returns></returns>
        public int DelectServerFile(List<ServerFile> serverFileList)
        {
            if (serverFileList.Count <= 0)
                return 0;
            string sqlSt = "DELETE FROM file_table WHERE filecode IN (";
            foreach (ServerFile s in serverFileList)
                sqlSt = sqlSt + "'" + s.FileCode + "'" + ",";

            sqlSt = sqlSt.Remove(sqlSt.Length - 1) + ");";
            MySqlParameter[] param = { };
            return _mySqlDataHelper.ExecuteNonQuery(sqlSt, param);
        }

        /// <summary>
        /// 获取服务器文件list
        /// </summary>
        /// <returns></returns>
        public List<ServerFile> GetFileInfoList()
        {
            List<ServerFile>fileInfos=new List<ServerFile>();
            string sqlSt = "SELECT *FROM file_table;";
            MySqlParameter[] param = new MySqlParameter[] { };
            var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);
            fileInfos = DataTableToList<ServerFile>(dataTable);
            return fileInfos;
        }

        /// <summary>
        /// 更新文件的下载次数
        /// </summary>
        /// <param name="fileCode"></param>
        /// <returns>返回文件的下载次数</returns>
        public int UpDateFileDownLoadTime(string fileCode,out int downLoadTime)
        {
            downLoadTime = 0;
            string stTemp = "SELECT downloadtime FROM file_table WHERE filecode=?FileCode";
            MySqlParameter[] paramTemp = new MySqlParameter[] {new MySqlParameter("FileCode", fileCode),};
            var dataRow = _mySqlDataHelper.ExecuteDataRow(stTemp, paramTemp);

            int num = 0;
            if (int.TryParse(string.IsNullOrEmpty(dataRow[0].ToString()) ? "0" : dataRow[0].ToString(), out num))
            {
                num += 1;
            }
            downLoadTime = num;
            string sqlSt = "UPDATE file_table SET downloadtime=?Num WHERE filecode=?FileCode";
            MySqlParameter[] param = new MySqlParameter[]
            {
                new MySqlParameter("FileCode", fileCode),
                new MySqlParameter("Num",num), 
            };
            return _mySqlDataHelper.ExecuteNonQuery(sqlSt, param);
        }
        
        #region 项目文件的操作
        /// <summary>
        /// 根据学生id获取已经提交的项目文件
        /// </summary>
        /// <param name="studentId"></param>
        /// <returns></returns>
        public List<GraduationDesignFile> GetGraduationDesignFileList(string studentId)
        {
            List<GraduationDesignFile> graduationList=new List<GraduationDesignFile>();
            string sqlSt = "SELECT * FROM graduationfile_table WHERE studentid=?StudentId;";
            MySqlParameter[] param=new MySqlParameter[] {new MySqlParameter("StudentId",studentId), };
            var dataTable = _mySqlDataHelper.ExecuteDataTable(sqlSt, param);
            graduationList = DataTableToList<GraduationDesignFile>(dataTable);
            return graduationList;
        }
        /// <summary>
        /// 上传项目文件
        /// </summary>
        /// <param name="graduations"></param>
        /// <returns></returns>
        public int InsertGraduationDesignFile(List<GraduationDesignFile> graduations)
        {
            if (graduations.Count <= 0)
                return 0;
            string sqlSt = "INSERT INTO graduationfile_table(" +
                           "filecode," +
                           "filename," +
                           "uploadtime," +
                           "datetype," +
                           "studentid," +
                           "projectcode" +
                           ") " +
                           "VALUES";
            foreach (GraduationDesignFile graduation in graduations)
            {
                string temp = "('" +
                              graduation.FileCode + "','" +
                              graduation.FileName + "','" +
                              graduation.UpLoadTime + "','" +
                              graduation.DateType + "','" +
                              graduation.StudentId + "','" +
                              graduation.ProjectCode +
                              "'),";
                sqlSt = sqlSt + temp;
            }
            sqlSt = sqlSt.Remove(sqlSt.Length - 1);
            MySqlParameter[] param = { };
            return _mySqlDataHelper.ExecuteNonQuery(sqlSt, param);
        }

        #endregion


        /************************************************************************************/

        /// <summary>
        /// 把datatable转化为指定的对象List
        /// </summary>
        /// <param name="dt"></param>
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
            if (dataRow == null)
                return new T();
            //类所在的namespace
            Type type = typeof(T);
            T t = new T();
            PropertyInfo[] propertys = t.GetType().GetProperties();

            List<string> columList = new List<string>();
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
