using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using ExcelDna.Integration.CustomUI;

namespace GraduationDesignManagement.Views
{
    public partial class ChooseStudent : UserControl
    {
        //当前活动窗体句柄
        //private readonly int _hwnd = (ExcelHelper.GetXlApplication()).ActiveWindow.Hwnd;
        public CustomTaskPane TaskPaneChooseStudent { get; set; }
        public ChooseStudent()
        {
            InitializeComponent();
        }

        #region 搜索

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.FromArgb(255, 144, 13);
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.BackColor = Color.FromArgb(255, 255, 255);
        }

        private void txtSearch_KeyUp(object sender, KeyEventArgs e)
        {
         
        }

        #endregion

        private void cmbOk_SelectionChangeCommitted(object sender, EventArgs e)
        {
            btnOk.Text = cmbOk.Text;
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            switch (btnOk.Text)
            {
                case "提交并导出":
                    break;
                case "提交":
                    break;
                case "导出":
                    break;
            }

            //关闭当前窗体
            TaskPaneChooseStudent.Visible = false;
        }
    }
}
