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
    public partial class ChooseTearch : UserControl
    {
        //当前活动窗体句柄
        //private readonly int _hwnd = (ExcelHelper.GetXlApplication()).ActiveWindow.Hwnd;
        public CustomTaskPane TaskPaneChooseTearch { get; set; }
        public ChooseTearch()
        {
            InitializeComponent();
        }

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
            TaskPaneChooseTearch.Visible = false;
        }
    }
}
