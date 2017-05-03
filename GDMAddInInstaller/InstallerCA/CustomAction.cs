using Microsoft.Deployment.WindowsInstaller;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Globalization;
using System.Security;
using System.Security.Permissions;
using System.Security.Principal;
using System.Threading;
using System.Windows.Forms;

namespace InstallerCA
{
    public class CustomActions
    {
        private const string BaseAddInKey = @"Software\Microsoft\Office\";
        private static Session _pulicSession;
        private static string _regasmPath;

        [CustomAction]
        public static ActionResult CuActionResult(Session session)
        {
            
            return ActionResult.Success;
        }

        private static int nowVersion = 2350;//2.3.5.0之前用winform安装程序
        #region Methods

        #region 检查Excel的平台 就是多少位的

        [CustomAction]
        public static ActionResult CacheckExcelBitness(Session session)
        {
            _pulicSession = session;
            bool foundOffice = false;
            session.Log("开始检查Excel的平台......");
            try
            {
                Parameters parameters = Parameters.ExtractFromSession(session);
                foreach (string officeVersionKey in parameters.SupportedOfficeVersion)
                {
                    double version = double.Parse(officeVersionKey, NumberStyles.Any, CultureInfo.InvariantCulture);
                    session.Log("检索注册表：{0}", BaseAddInKey + officeVersionKey);
                    string excelBaseKey = BaseAddInKey + officeVersionKey + @"\Excel";
                    if (IsOfficeExcelInstalled(excelBaseKey))
                    {
                        if (!foundOffice) foundOffice = true;
                        string xllToRegister = GetAddInName(parameters.Xll32Name, parameters.Xll64Name,
                            officeVersionKey, version);
                        session.Log("GetAddInName获取值为：{0}", xllToRegister);
                        if (xllToRegister == parameters.Xll32Name)
                        {
                            session["OFFICEBITNESS"] = "x86";
                        }
                        else if (xllToRegister == parameters.Xll64Name)
                        {
                            session["OFFICEBITNESS"] = "x64";
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                session.Log("始检查Excel的平台:" + ex);
                foundOffice = false;
            }
            return foundOffice ? ActionResult.Success : ActionResult.Failure;
        }

        #endregion
        
        #region CaRegisterAddIn
        [CustomAction]
        public static ActionResult CaRegisterAddIn(Session session)
        {
            //MessageBox.Show("加载注册表");
            _pulicSession = session;
            bool foundOffice = false;

            session.Log("开始注册加载XLL环节（CaRegisterAddIn）......");

            try
            {
                session.Log("整理属性数据,并结构化......");
                Parameters parameters = Parameters.ExtractFromSession(session);

                var registryAdapator = new RegistryAbstractor();

                foreach (string officeVersionKey in parameters.SupportedOfficeVersion)
                {
                    double version = double.Parse(officeVersionKey, NumberStyles.Any, CultureInfo.InvariantCulture);

                    session.Log("检索注册表：{0}", BaseAddInKey + officeVersionKey);

                    string excelBaseKey = BaseAddInKey + officeVersionKey + @"\Excel";

                    if (IsOfficeExcelInstalled(excelBaseKey))
                    {
                        if (!foundOffice) foundOffice = true;
                        string excelOptionKey = excelBaseKey + @"\Options";
                        using (RegistryKey rkExcelXll = registryAdapator.OpenOrCreateHkcuKey(excelOptionKey))
                        {
                            string xllToRegister = GetAddInName(parameters.Xll32Name, parameters.Xll64Name, officeVersionKey, version);
                            session.Log("GetAddInName获取值为：{0}", xllToRegister);

                            if (xllToRegister == parameters.Xll32Name)
                            {
                                session["OFFICEBITNESS"] = "x86";
                            }
                            else if (xllToRegister == parameters.Xll64Name)
                            {
                                session["OFFICEBITNESS"] = "x64";
                            }
                            string fullPathToXll = Path.Combine(parameters.InstallDirectory, xllToRegister);

                            session.Log("在注册表HKCU中成功检索到: " + excelOptionKey);

                            string[] valueNames = rkExcelXll.GetValueNames();
                            bool isOpen = false;
                            int maxOpen = -1;
                            foreach (string valueName in valueNames)
                            {
                                session.Log(string.Format("检索 value {0}", valueName));

                                if (valueName.StartsWith("OPEN"))
                                {
                                    int openVersion = int.TryParse(valueName.Substring(4), out openVersion) ? openVersion : 0;
                                    int newOpen = valueName == "OPEN" ? 0 : openVersion;
                                    if (newOpen > maxOpen)
                                    {
                                        maxOpen = newOpen;
                                    }

                                    if (rkExcelXll.GetValue(valueName).ToString().Contains(xllToRegister))
                                    {
                                        isOpen = true;
                                        session.Log("已经发现 OPEN key " + excelOptionKey);
                                    }
                                }
                            }
                            if (!isOpen)
                            {
                                string value = "/R \"" + fullPathToXll + "\"";
                                string keyToUse;
                                if (maxOpen == -1)
                                {
                                    keyToUse = "OPEN";
                                }
                                else
                                {
                                    keyToUse = "OPEN" + (maxOpen + 1).ToString(CultureInfo.InvariantCulture);

                                }
                                rkExcelXll.SetValue(keyToUse, value);
                                session.Log("为 {0} 赋值 {1}", keyToUse, value);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("在注册表HKLM中没有检索到: {0}. 这个版本的Office可能没有安装", excelBaseKey);
                    }
                }
                session.Log("结束注册加载XLL环节（CaRegisterAddIn）......");
            }
            catch (System.Security.SecurityException ex)
            {
                session.Log("异常：CaRegisterAddIn SecurityException" + ex.Message);
                foundOffice = false;
            }
            catch (System.UnauthorizedAccessException ex)
            {
                session.Log("异常：CaRegisterAddIn UnauthorizedAccessException" + ex.Message);
                foundOffice = false;
            }
            catch (Exception ex)
            {
                session.Log("异常：CaRegisterAddIn Exception" + ex.Message);
                foundOffice = false;
            }
            if (!foundOffice)
            {
                MessageBox.Show("安装过程中出现错误，请关闭杀毒软件后再次尝试安装", "SumscopeAddIn");
            }
            return foundOffice ? ActionResult.Success : ActionResult.Failure;
        }
        #endregion

        #region CaUnRegisterAddIn
        [CustomAction]
        public static ActionResult CaUnRegisterAddIn(Session session)
        {
            //MessageBox.Show("卸载注册表");
            _pulicSession = session;

            bool foundOffice = false;

            try
            {
                session.Log("开始注销卸载XLL环节（CaUnRegisterAddIn）......");

                session.Log("整理属性数据,并结构化......");
                Parameters parameters = Parameters.ExtractFromSession(session);

                if (parameters.SupportedOfficeVersion.Count > 0)
                {
                    foreach (string officeVersionKey in parameters.SupportedOfficeVersion)
                    {
                        string officeKey = BaseAddInKey + officeVersionKey;
                        session.Log("试图在HKCU中打开{0}", officeKey);

                        if (Registry.CurrentUser.OpenSubKey(officeKey, false) != null)
                        {
                            foundOffice = true;

                            string keyName = BaseAddInKey + officeVersionKey + @"\Excel\Options";
                            session.Log("试图在HKCU中打开{0}", keyName);

                            using (RegistryKey rkAddInKey = Registry.CurrentUser.OpenSubKey(keyName, true))
                            {
                                if (rkAddInKey != null)
                                {
                                    session.Log("存在：{0}", keyName);
                                    string[] valueNames = rkAddInKey.GetValueNames();
                                    foreach (string valueName in valueNames)
                                    {
                                        //unregister both 32 and 64 xll
                                        if (valueName.StartsWith("OPEN") && (rkAddInKey.GetValue(valueName).ToString().Contains(parameters.Xll64Name) || rkAddInKey.GetValue(valueName).ToString().Contains(parameters.Xll32Name)))
                                        {
                                            Console.WriteLine("删除： {0}", valueName);
                                            rkAddInKey.DeleteValue(valueName);
                                        }
                                    }
                                }
                                else
                                {
                                    session.Log("不存在：{0}", keyName);
                                }
                            }
                        }
                        else
                        {
                            session.Log("不存在：{0}", officeKey);
                        }
                    }
                }
                session.Log("结束注销卸载XLL环节（CaUnRegisterAddIn）......");
            }
            catch (Exception ex)
            {
                session.Log(ex.Message);
            }
            if (!foundOffice)
            {
                MessageBox.Show("安装过程中出现错误，请关闭杀毒软件后再次尝试安装", "SumscopeAddIn");
            }
            return foundOffice ? ActionResult.Success : ActionResult.Failure;
        }
        #endregion

        #region ClosePrompt
        [CustomAction]
        public static ActionResult ClosePrompt(Session session)
        {
            //MessageBox.Show("检查关闭");
            session.Log("Begin PromptToCloseApplications");
            try
            {
                var productName = session["ProductName"];
                var processes = session["PromptToCloseProcesses"].Split(',');
                var displayNames = session["PromptToCloseDisplayNames"].Split(',');

                if (processes.Length != displayNames.Length)
                {
                    session.Log(@"Please check that 'PromptToCloseProcesses' and 'PromptToCloseDisplayNames' exist and have same number of items.");
                    MessageBox.Show("安装过程中出现错误，请关闭杀毒软件后再次尝试安装", "SumscopeAddIn");
                    return ActionResult.Failure;
                }

                for (var i = 0; i < processes.Length; i++)
                {
                    session.Log("Prompting process {0} with name {1} to close.", processes[i], displayNames[i]);
                    using (var prompt = new PromptCloseApplication(productName, processes[i], displayNames[i]))
                    {
                        if (!prompt.Prompt())
                        {
                            MessageBox.Show("安装过程中出现错误，请关闭杀毒软件后再次尝试安装", "SumscopeAddIn");
                            return ActionResult.Failure;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                session.Log("Missing properties or wrong values. Please check that 'PromptToCloseProcesses' and 'PromptToCloseDisplayNames' exist and have same number of items. \nException:" + ex.Message);
                MessageBox.Show("安装过程中出现错误，请关闭杀毒软件后再次尝试安装", "SumscopeAddIn");
                return ActionResult.Failure;
            }

            session.Log("End PromptToCloseApplications");
            return ActionResult.Success;
        }
        #endregion

        #region GetAddInName
        private static string GetAddInName(string szXll32Name, string szXll64Name, string szOfficeVersionKey, double nVersion)
        {
            _pulicSession.Log("检测Office位数 " + nVersion + "...");
            //Console.WriteLine("检测Office位数 {0}...", nVersion);
            var officeBitness = GetOfficeBitness(szOfficeVersionKey, nVersion);
            _pulicSession.Log("GetOfficeBitness值为：{0}", officeBitness);
            switch (officeBitness)
            {
                case OfficeBitness.X86:
                    _pulicSession.Log("Office 32 bits.");
                    _pulicSession.Log("即将返回：" + szXll32Name);
                    return szXll32Name;

                case OfficeBitness.X64:
                    _pulicSession.Log("Office 64 bits.");
                    return szXll64Name;

                default:
                    throw new InvalidOperationException("异常：未能检测出Office版本位数 " + nVersion);
            }
        }

        #endregion

        #region GetOfficeBitness
        private static OfficeBitness GetOfficeBitness(string szOfficeVersionKey, double nVersion)
        {
            // before office 2010, no 64 bits version of office exists. also only 32 bits can be installed on 32 bits systems.
            if (nVersion < 14 || !Environment.Is64BitOperatingSystem)
            {
                return OfficeBitness.X86;
            }

            // Check the ClickToRun registry (x86+x64). Both must be checked.
            // http://msdn.microsoft.com/en-us/library/office/ff864733(v=office.15).aspx
            RegistryKey clickToRunRegKey86 = RegistryKey
                .OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                .OpenSubKey(@"Software\Microsoft\Office\" + szOfficeVersionKey + @"\ClickToRun\Configuration", false);
            _pulicSession.Log("Office bitness using clicktorun x64 office installation: " + (clickToRunRegKey86 == null ? "not " : "") + "present");
            //Console.WriteLine("Office bitness using clicktorun x86 office installation: {0}present", clickToRunRegKey86 == null ? "not " : "");
            RegistryKey clickToRunRegKey64 = RegistryKey
                .OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                .OpenSubKey(@"Software\Microsoft\Office\" + szOfficeVersionKey + @"\ClickToRun\Configuration", false);
            _pulicSession.Log("Office bitness using clicktorun x64 office installation: " + (clickToRunRegKey64 == null ? "not " : "") + "present");
            //Console.WriteLine("Office bitness using clicktorun x64 office installation: {0}present", clickToRunRegKey64 == null ? "not " : "");


            // Check the Outlook\Bitness registry key
            // Using a registry key of outlook to determine the bitness of office may look like weird but that's the reality.
            // http://stackoverflow.com/questions/2203980/detect-whether-office-2010-is-32bit-or-64bit-via-the-registry

            // Note about upgrading office with "keep previous version" option:
            // Only one version of Outlook can be installed at a time. However, we can have several excel, word, etc versions at the same time.
            // One of the Outlook registry key is removed when upgrading Office. Thus the bitness is not found, resulting in the setup to fail.
            // Checking both x86/64 keys for office bitness seems to do the job.

            // Another alternative might be to check the bitness of any version of Office. It seems that you can't install 32bits and 64bits version
            // of office side-by-side (https://msdn.microsoft.com/en-us/library/ee691831.aspx#Anchor_6, https://technet.microsoft.com/en-us/library/ee681792.aspx)

            RegistryKey outlookRegKey86 =
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                    .OpenSubKey(@"Software\Microsoft\Office\" + szOfficeVersionKey + @"\Outlook", false);
            _pulicSession.Log(@"Office bitness using std x64 office installation: " + (outlookRegKey86 == null ? "not " : "") + "present");
            //Console.WriteLine("Office bitness using std x86 office installation: {0}present", outlookRegKey86 == null ? "not " : "");
            RegistryKey outlookRegKey64 =
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                    .OpenSubKey(@"Software\Microsoft\Office\" + szOfficeVersionKey + @"\Outlook", false);
            _pulicSession.Log(@"Office bitness using std x64 office installation: " + (outlookRegKey64 == null ? "not " : "") + "present");
            //Console.WriteLine("Office bitness using std x64 office installation: {0}present", outlookRegKey64 == null ? "not " : "");


            RegistryKey cfgNotVerRegKey86 = RegistryKey
                                   .OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
                                   .OpenSubKey(@"Software\Microsoft\Office\ClickToRun\Configuration", false);
            _pulicSession.Log(@"Office bitness using Software\Microsoft\Office\ClickToRun\Configuration x86 office installation: " + (cfgNotVerRegKey86 == null ? "not " : "") + "present");
            //Console.WriteLine(@"Office bitness using Software\Microsoft\Office\ClickToRun\Configuration x86 office installation: {0}present", cfgNotVerRegKey86 == null ? "not " : "");
            RegistryKey cfgNotVerRegKey64 = RegistryKey
                                    .OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64)
                                    .OpenSubKey(@"Software\Microsoft\Office\ClickToRun\Configuration", false);
            _pulicSession.Log(@"Office bitness using Software\Microsoft\Office\ClickToRun\Configuration x64 office installation: " + (cfgNotVerRegKey64 == null ? "not " : "") + "present");
            //Console.WriteLine(@"Office bitness using Software\Microsoft\Office\ClickToRun\Configuration x64 office installation: {0}present", cfgNotVerRegKey64 == null ? "not " : "");

            //部分win10用户位数节点处理
            var cfgNotVerRegKey = cfgNotVerRegKey86 ?? cfgNotVerRegKey64;
            if (cfgNotVerRegKey == null) _pulicSession.Log(@"win10 节点check 为null，节点为：Software\Microsoft\Office\ClickToRun\Configuration");
            if (cfgNotVerRegKey != null)
            {
                switch ((cfgNotVerRegKey.GetValue("Platform") ?? "").ToString())
                {
                    case "x64":
                        return OfficeBitness.X64;
                    case "x86":
                        return OfficeBitness.X86;
                }
            }

            // First check clicktorun (skip if not defined), new deployment tool from microsoft
            var bitnessRegKey = clickToRunRegKey86 ?? clickToRunRegKey64;
            if (bitnessRegKey != null)
            {
                switch ((bitnessRegKey.GetValue("Platform") ?? "").ToString())
                {
                    case "x64":
                        return OfficeBitness.X64;
                    case "x86":
                        return OfficeBitness.X86;
                }
            }

            // Then check outlook bitness registry key
            var outlookRegKeys = new List<RegistryKey> { outlookRegKey86, outlookRegKey64 };
            foreach (var outlookRegKey in outlookRegKeys.Where(x => x != null))
            {
                object oBitValue = outlookRegKey.GetValue("Bitness");
                if (oBitValue != null)
                {
                    switch (oBitValue.ToString())
                    {
                        case "x64":
                            return OfficeBitness.X64;
                        case "": // Empty key means x86 for older install of office.
                        case "x86":
                            return OfficeBitness.X86;
                    }
                }
            }
            // If not found, then unknown
            return OfficeBitness.Unknown;
        }
        #endregion

        #region IsOfficeExcelInstalled 判断指定版本的excel是否安装 因为可能会安装多个版本的excel 让每一个版本的excel都加载上 excelAddin
        private static bool IsOfficeExcelInstalled(string excelBaseKey)
        {
            // Check both x86 and x64 registry
            var hklmRoot = new List<RegistryKey>
            {
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry64),
                RegistryKey.OpenBaseKey(RegistryHive.LocalMachine, RegistryView.Registry32)
            };

            /*
             * Here, we check if excel is trully installed on the system by checking Office installation root + application name.
             * HKLM\Software\Microsoft\Office\x.x\Excel\InstallRoot | Path
             */

            var excelInstallRootKey = excelBaseKey + @"\InstallRoot";
            foreach (var root in hklmRoot)
            {
                var installRootKey = root.OpenSubKey(excelInstallRootKey, false);
                if (installRootKey == null)
                {
                    continue;
                }

                var pathKey = installRootKey.GetValue("Path") as string;
                if (string.IsNullOrEmpty(pathKey))
                {
                    continue;
                }

                try
                {
                    var excelApplicationPath = Path.Combine(pathKey, "excel.exe");
                    if (File.Exists(excelApplicationPath))
                    {
                        return true;
                    }
                }
                catch (ArgumentException ex)
                {
                    // if the registry key is corrupted (Path.Combine call), we don't want to throw. but log it just in case.
                    _pulicSession.Log("IsOfficeExcelInstalled failed due to invalid value in registry key " + excelInstallRootKey + ". Consider Microsoft Office Excel not installed for this version. Exception: " + ex);
                    //Console.WriteLine("IsOfficeExcelInstalled failed due to invalid value in registry key {0}. Consider Microsoft Office Excel not installed for this version. Exception: {1}", excelInstallRootKey, ex);
                }
            }

            return false;
        }
        #endregion

        #endregion

        #region 检查用户类型 暂时不使用

        [CustomAction]
        public static ActionResult CheckPermission(Session session)
        {
            //bool foundFolder = true;
            AppDomain appDomain = Thread.GetDomain();
            appDomain.SetPrincipalPolicy(PrincipalPolicy.WindowsPrincipal);
            WindowsPrincipal wp =
                Thread.CurrentPrincipal as WindowsPrincipal;

            bool isUser;

            #region

            //Console.Write("当前用户的角色是：");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.Guest);
            //if (IsUser)
            //    Console.WriteLine("来宾");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.User);
            //if (IsUser)
            //    Console.WriteLine("普通用户");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.PowerUser);
            //if (IsUser)
            //    Console.WriteLine("超级用户");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.Administrator);
            //if (IsUser)
            //    Console.WriteLine("系统管理员");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.SystemOperator);
            //if (IsUser)
            //    Console.WriteLine("系统操作员");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.BackupOperator);
            //if (IsUser)
            //    Console.WriteLine("备份操作员");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.PrintOperator);
            //if (IsUser)
            //    Console.WriteLine("打印操作员");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.AccountOperator);
            //if (IsUser)
            //    Console.WriteLine("账户操作员");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.Replicator);
            //if (IsUser)
            //    Console.WriteLine("复制程序员");
            //return foundFolder ? ActionResult.Success : ActionResult.Failure;

            #endregion

            isUser = wp.IsInRole(WindowsBuiltInRole.Administrator);
            if (isUser)
            {
                session.Log("当前用户为系统管理员\n");
                return ActionResult.Success;
            }
            else
            {
                session.Log("当前用户不是系统管理员\n");
                MessageBox.Show("当前登录用户不是系统管理员，请联系系统管理员");
                return ActionResult.Failure;
            }
        }

        #endregion

        #region 卸载之前的版本（VSTO版 和 Winform版）
        [CustomAction]
        public static ActionResult CaOldUninstall(Session session)
        {
            //MessageBox.Show("检查以前的安装程序");
            bool foundFolder = true;
            string toPath = @"C:\Sumscope\Quoteboard\AddIn";
            string message;
            _pulicSession = session;

            #region 检测旧版本VSTO，并卸载
            string installVstoPath = OfficeInfo.CheckInstallVSTO();
            if (!string.IsNullOrEmpty(installVstoPath))
            {
                CancellationDll(session, ref foundFolder, toPath);//注销DLL
                if (!foundFolder)
                {
                    MessageBox.Show("安装过程中出现错误，请关闭杀毒软件后再次尝试安装", "SumscopeAddIn");
                    return ActionResult.Failure;
                }
                #region 注销卸载XLL

                if (CaUnRegisterAddIn(session) == ActionResult.Failure)
                {
                    session.Log("卸载XLL环节失败");
                    MessageBox.Show("安装过程中出现错误，请关闭杀毒软件后再次尝试安装", "SumscopeAddIn");
                    return ActionResult.Failure;
                }
                #endregion

                #region 卸载旧版本VSTO安装程序

                try
                {
                    session.Log("卸载旧版本VSTO安装程序......\n");
                    //静默卸载
                    string vstoInstallerPath = @"cd /d ""C:\Program Files\Common Files\Microsoft Shared\VSTO\10.0""";
                    string strCommand = @"VSTOInstaller /Uninstall """ + installVstoPath + "\"" + " /s";
                    string[] commandVsto = new string[2];
                    commandVsto[0] = vstoInstallerPath;
                    commandVsto[1] = strCommand;

                    bool b = RegisterDll(commandVsto, out message);
                    if (!b)
                    {
                        session.Log(message);
                        session.Log("卸载旧版本失败！请行到控制面板进行卸载！");
                    }

                    //删除AddIn文件夹下的所有文件
                    Directory.Delete(@"C:\Sumscope\Quoteboard\AddIn", true);
                    session.Log("已卸载旧版本VSTO安装程序\n");
                }
                catch (Exception e)
                {
                    session.Log(e.ToString() + "\n");
                    session.Log("卸载旧版本VSTO安装程序失败\n");
                    MessageBox.Show("安装过程中出现错误，请关闭杀毒软件后再次尝试安装", "SumscopeAddIn");
                    return ActionResult.Failure;
                }

                #endregion

            }
            #endregion

            #region 检测旧版本WinForm并卸载
            string toPathDll = toPath + @"\SumscopeAddIn.dll";
            if (File.Exists(toPathDll))
            {
                try
                {
                    FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(toPathDll);
                    string outputStrings = myFileVersionInfo.FileVersion.Replace(".", "");
                    if (int.Parse(outputStrings) < nowVersion)
                    {
                        CancellationDll(session, ref foundFolder, toPath);//注销DLL
                        if (!foundFolder)
                        {
                            MessageBox.Show("安装过程中出现错误，请关闭杀毒软件后再次尝试安装", "SumscopeAddIn");
                            return ActionResult.Failure;
                        }
                        #region 注销卸载XLL
                        CaUnRegisterAddIn(session);
                        #endregion
                        DirectoryInfo di = new DirectoryInfo(toPath);
                        di.Delete(true);
                        session.Log("已卸载旧版本Winfrom安装程序\n");
                    }
                }
                catch (Exception e)
                {
                    session.Log(e.ToString() + "\n");
                    session.Log("删除文件失败 卸载winform安装程序失败\n");
                    MessageBox.Show("安装过程中出现错误，请关闭杀毒软件后再次尝试安装", "SumscopeAddIn");
                    return ActionResult.Failure;
                }
            }
            #endregion

            session.Log("已卸载旧版本安装程序\n");
            if (!foundFolder)
            {
                MessageBox.Show("安装过程中出现错误，请关闭杀毒软件后再次尝试安装", "SumscopeAddIn");
            }
            return foundFolder ? ActionResult.Success : ActionResult.Failure;
        }
        /// <summary>
        /// 注销DLL
        /// </summary>
        /// <param name="session"></param>
        /// <param name="foundFolder"></param>
        /// <param name="toPath"></param>
        private static void CancellationDll(Session session, ref bool foundFolder, string toPath)
        {
            string message;
            try
            {
                session.Log("整理属性数据,并结构化......");
                Parameters parameters = Parameters.ExtractFromSession(session);

                foreach (string officeVersionKey in parameters.SupportedOfficeVersion)
                {
                    double version = double.Parse(officeVersionKey, NumberStyles.Any, CultureInfo.InvariantCulture);

                    session.Log("检索注册表：{0}", BaseAddInKey + officeVersionKey);

                    string excelBaseKey = BaseAddInKey + officeVersionKey + @"\Excel";

                    if (IsOfficeExcelInstalled(excelBaseKey))
                    {
                        string xllToRegister = GetAddInName(parameters.Xll32Name, parameters.Xll64Name,
                            officeVersionKey, version);
                        session.Log("GetAddInName获取值为：{0}", xllToRegister);

                        if (xllToRegister == parameters.Xll32Name)
                        {
                            _regasmPath = @"cd /d ""C:\Windows\Microsoft.NET\Framework\v4.0.30319""";
                        }
                        else if (xllToRegister == parameters.Xll64Name)
                        {
                            _regasmPath = @"cd /d ""C:\Windows\Microsoft.NET\Framework64\v4.0.30319""";
                        }
                    }
                }
            }
            catch (System.Security.SecurityException ex)
            {
                MessageBox.Show("异常：CaRegisterAddIn SecurityException" + ex.Message);
                foundFolder = false;
            }
            catch (System.UnauthorizedAccessException ex)
            {
                MessageBox.Show("异常：CaRegisterAddIn UnauthorizedAccessException" + ex.Message);
                foundFolder = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("异常：CaRegisterAddIn Exception" + ex.Message + "&" + ex.StackTrace);
                foundFolder = false;
            }

            if (File.Exists(Path.Combine(toPath, "SSMQCliWrapper.dll")))
            {

                session.Log("开始注销 SSMQCliWrapper\n");
                string[] unregistercommand = UnregisterCommand(_regasmPath, toPath,
                    "SSMQCliWrapper.dll");
                if (!RegisterDll(unregistercommand, out message))
                {
                    session.Log(message + "\nSSMQCliWrapper 注销失败\n");
                }
                else
                {
                    session.Log(message + "\n成功注销 SSMQCliWrapper\n");
                }
            }

            if (File.Exists(Path.Combine(toPath, "SumscopeServices.dll")))
            {
                session.Log("开始注销 SumscopeServices\n");
                string[] unregistercommand = UnregisterCommand(_regasmPath, toPath,
                    "SumscopeServices.dll");
                if (!RegisterDll(unregistercommand, out message))
                {
                    session.Log(message + "\nSumscopeServices 注销失败\n");
                }
                else
                {
                    session.Log(message + "\n成功注销 SumscopeServices\n");
                }
            }
        }

        public static string[] UnregisterCommand(string regasmPath, string toPath, string dllName)
        {
            string ssmqCliWrapperPath = Path.Combine(toPath, dllName);
            string unregister = @"regasm  /u """ + ssmqCliWrapperPath + "\"";

            string[] command = new string[2];
            command[0] = regasmPath;
            command[1] = unregister;

            return command;
        }
        /// <summary>
        /// 执行cmd
        /// </summary>
        /// <param name="command"></param>
        /// <param name="message"></param>
        /// <returns></returns>
        public static bool RegisterDll(string[] command, out string message)
        {
            try
            {
                Process p = new Process
                {
                    StartInfo =
                    {
                        FileName = @"cmd.exe",
                        UseShellExecute = false,//是否使用操作系统shell启动
                        RedirectStandardInput = true,//接受来自调用程序的输入信息
                        RedirectStandardOutput = true,//由调用程序获取输出信息
                        RedirectStandardError = true,//重定向标准错误输出
                        CreateNoWindow = true,//不显示程序窗口
                        Verb = "runAs"//以管理员权限运行
                    }

                };

                p.Start();//启动程序

                //向cmd窗口发送输入信息
                p.StandardInput.AutoFlush = true;

                for (int i = 0; i < command.Length; i++)
                {
                    p.StandardInput.WriteLine(command[i]);
                }

                p.StandardInput.WriteLine("exit");

                string output = p.StandardOutput.ReadToEnd();
                string error = p.StandardError.ReadToEnd();

                message = string.Format("{0}\n{1}", output, error);

                if (error.Contains("error"))
                {
                    return false;
                }

                return true;
            }
            catch (Exception exception)
            {
                message = string.Format("{0}", exception);
                return false;
            }
        }

        #endregion

        private enum OfficeBitness
        {
            Unknown,
            X86,
            X64
        }
    }
}
