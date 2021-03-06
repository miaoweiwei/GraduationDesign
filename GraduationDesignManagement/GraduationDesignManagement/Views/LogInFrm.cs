﻿using System;
using System.Threading;
using System.Windows.Forms;
using GraduationDesignManagement.BusinessServices;
using GraduationDesignManagement.Common;

namespace GraduationDesignManagement.Views
{
    public partial class LogInFrm : Form
    {
        private LogonBusinessService _logonBusinessService;

        private string _userId;
        private string _userPassword;

        public LogInFrm() 
        {
            InitializeComponent();
            _logonBusinessService = LogonBusinessService.Instance;
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string logInInfo=null;
            _userId = txbUserId.Text;
            _userPassword = txbUserPassword.Text;
            if (string.IsNullOrEmpty(_userId)|| string.IsNullOrEmpty(_userPassword))
            {
                logInInfo = @"用户名和密码不能为空！";
            }
            else
            {
                _logonBusinessService.Login(_userId, _userPassword, out logInInfo);
                if (_logonBusinessService.IsAddInLogon)
                {
                    //登录成功
                    this.DialogResult = DialogResult.OK;
                    Close();
                }
            }
            labInfo.Text = logInInfo;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}
