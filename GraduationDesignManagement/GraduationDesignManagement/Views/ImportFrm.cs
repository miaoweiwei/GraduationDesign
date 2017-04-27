using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GraduationDesignManagement.Views
{
    public partial class ImportFrm : Form
    {
        public ImportFrm(GetListDelegate getlistDelegate)
        {
            GetlistDelegate = getlistDelegate;
            InitializeComponent();
        }
        public delegate void GetListDelegate(List<string> paramList);
        public GetListDelegate GetlistDelegate;


        private void btnFinish_Click(object sender, EventArgs e)
        {
            if (GetlistDelegate != null)
            {
                var paramSt = txtParam.Text;
                var arr = paramSt.Split('\n');
                var paramListTemp = arr.ToList();
                // 调用方法
                GetlistDelegate(paramListTemp);
                Close();
            }
        }
    }
}
