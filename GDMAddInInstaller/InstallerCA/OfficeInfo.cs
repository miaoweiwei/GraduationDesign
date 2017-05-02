using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace InstallerCA
{
    class OfficeInfo
    {
        /// <summary>
        /// 获取安装的路径
        /// </summary>
        /// <returns></returns>
        public static string CheckInstallVSTO()
        {
            var registryAddins =
                Microsoft.Win32.Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Office\Excel\Addins\SumscopeAddIn");

            string setupPath = string.Empty;

            if (registryAddins != null)
            {
                string manifest = registryAddins.GetValue("Manifest").ToString();

                string[] sArr = manifest.Split(new[] { "///" }, StringSplitOptions.RemoveEmptyEntries);

                if (sArr[1].Contains("|"))
                {
                    sArr = sArr[1].Split(new[] { "|" }, StringSplitOptions.RemoveEmptyEntries);
                    setupPath = sArr[0]; //获取已安装程序的路径
                }
                else
                {
                    setupPath = sArr[1]; //获取已安装程序的路径
                }

                if (!setupPath.Contains("."))
                {
                    setupPath = Path.Combine(setupPath, "SumscopeAddIn.vsto");
                }
            }


            return setupPath;
        }
    }
}
