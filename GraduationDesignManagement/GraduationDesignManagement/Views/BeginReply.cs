using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using GraduationDesignManagement.BusinessServices;
using GraduationDesignManagement.Common;
using GraduationDesignManagement.MysqlData;

namespace GraduationDesignManagement.Views
{
    public partial class BeginReply : UserControl
    {
        private LogonBusinessService _logonBusinessService;
        private DataQuery _dataQuery;

        List<GraduationDesign> _graduationDesignList = new List<GraduationDesign>();
        List<Project> _projectList = new List<Project>();
        List<Student> _studentList = new List<Student>();

        public BeginReply()
        {
            InitializeComponent();
        }

        private void BeginReply_Load(object sender, EventArgs e)
        {
            _logonBusinessService=LogonBusinessService.Instance;
            _dataQuery=DataQuery.Instance;

            _graduationDesignList = _dataQuery.GetGraduationDesign(_logonBusinessService.UserId);


        }
    }
}
