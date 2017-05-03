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

        private static int nowVersion = 2350;//2.3.5.0֮ǰ��winform��װ����
        #region Methods

        #region ���Excel��ƽ̨ ���Ƕ���λ��

        [CustomAction]
        public static ActionResult CacheckExcelBitness(Session session)
        {
            _pulicSession = session;
            bool foundOffice = false;
            session.Log("��ʼ���Excel��ƽ̨......");
            try
            {
                Parameters parameters = Parameters.ExtractFromSession(session);
                foreach (string officeVersionKey in parameters.SupportedOfficeVersion)
                {
                    double version = double.Parse(officeVersionKey, NumberStyles.Any, CultureInfo.InvariantCulture);
                    session.Log("����ע���{0}", BaseAddInKey + officeVersionKey);
                    string excelBaseKey = BaseAddInKey + officeVersionKey + @"\Excel";
                    if (IsOfficeExcelInstalled(excelBaseKey))
                    {
                        if (!foundOffice) foundOffice = true;
                        string xllToRegister = GetAddInName(parameters.Xll32Name, parameters.Xll64Name,
                            officeVersionKey, version);
                        session.Log("GetAddInName��ȡֵΪ��{0}", xllToRegister);
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
                session.Log("ʼ���Excel��ƽ̨:" + ex);
                foundOffice = false;
            }
            return foundOffice ? ActionResult.Success : ActionResult.Failure;
        }

        #endregion
        
        #region CaRegisterAddIn
        [CustomAction]
        public static ActionResult CaRegisterAddIn(Session session)
        {
            //MessageBox.Show("����ע���");
            _pulicSession = session;
            bool foundOffice = false;

            session.Log("��ʼע�����XLL���ڣ�CaRegisterAddIn��......");

            try
            {
                session.Log("������������,���ṹ��......");
                Parameters parameters = Parameters.ExtractFromSession(session);

                var registryAdapator = new RegistryAbstractor();

                foreach (string officeVersionKey in parameters.SupportedOfficeVersion)
                {
                    double version = double.Parse(officeVersionKey, NumberStyles.Any, CultureInfo.InvariantCulture);

                    session.Log("����ע���{0}", BaseAddInKey + officeVersionKey);

                    string excelBaseKey = BaseAddInKey + officeVersionKey + @"\Excel";

                    if (IsOfficeExcelInstalled(excelBaseKey))
                    {
                        if (!foundOffice) foundOffice = true;
                        string excelOptionKey = excelBaseKey + @"\Options";
                        using (RegistryKey rkExcelXll = registryAdapator.OpenOrCreateHkcuKey(excelOptionKey))
                        {
                            string xllToRegister = GetAddInName(parameters.Xll32Name, parameters.Xll64Name, officeVersionKey, version);
                            session.Log("GetAddInName��ȡֵΪ��{0}", xllToRegister);

                            if (xllToRegister == parameters.Xll32Name)
                            {
                                session["OFFICEBITNESS"] = "x86";
                            }
                            else if (xllToRegister == parameters.Xll64Name)
                            {
                                session["OFFICEBITNESS"] = "x64";
                            }
                            string fullPathToXll = Path.Combine(parameters.InstallDirectory, xllToRegister);

                            session.Log("��ע���HKCU�гɹ�������: " + excelOptionKey);

                            string[] valueNames = rkExcelXll.GetValueNames();
                            bool isOpen = false;
                            int maxOpen = -1;
                            foreach (string valueName in valueNames)
                            {
                                session.Log(string.Format("���� value {0}", valueName));

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
                                        session.Log("�Ѿ����� OPEN key " + excelOptionKey);
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
                                session.Log("Ϊ {0} ��ֵ {1}", keyToUse, value);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("��ע���HKLM��û�м�����: {0}. ����汾��Office����û�а�װ", excelBaseKey);
                    }
                }
                session.Log("����ע�����XLL���ڣ�CaRegisterAddIn��......");
            }
            catch (System.Security.SecurityException ex)
            {
                session.Log("�쳣��CaRegisterAddIn SecurityException" + ex.Message);
                foundOffice = false;
            }
            catch (System.UnauthorizedAccessException ex)
            {
                session.Log("�쳣��CaRegisterAddIn UnauthorizedAccessException" + ex.Message);
                foundOffice = false;
            }
            catch (Exception ex)
            {
                session.Log("�쳣��CaRegisterAddIn Exception" + ex.Message);
                foundOffice = false;
            }
            if (!foundOffice)
            {
                MessageBox.Show("��װ�����г��ִ�����ر�ɱ��������ٴγ��԰�װ", "SumscopeAddIn");
            }
            return foundOffice ? ActionResult.Success : ActionResult.Failure;
        }
        #endregion

        #region CaUnRegisterAddIn
        [CustomAction]
        public static ActionResult CaUnRegisterAddIn(Session session)
        {
            //MessageBox.Show("ж��ע���");
            _pulicSession = session;

            bool foundOffice = false;

            try
            {
                session.Log("��ʼע��ж��XLL���ڣ�CaUnRegisterAddIn��......");

                session.Log("������������,���ṹ��......");
                Parameters parameters = Parameters.ExtractFromSession(session);

                if (parameters.SupportedOfficeVersion.Count > 0)
                {
                    foreach (string officeVersionKey in parameters.SupportedOfficeVersion)
                    {
                        string officeKey = BaseAddInKey + officeVersionKey;
                        session.Log("��ͼ��HKCU�д�{0}", officeKey);

                        if (Registry.CurrentUser.OpenSubKey(officeKey, false) != null)
                        {
                            foundOffice = true;

                            string keyName = BaseAddInKey + officeVersionKey + @"\Excel\Options";
                            session.Log("��ͼ��HKCU�д�{0}", keyName);

                            using (RegistryKey rkAddInKey = Registry.CurrentUser.OpenSubKey(keyName, true))
                            {
                                if (rkAddInKey != null)
                                {
                                    session.Log("���ڣ�{0}", keyName);
                                    string[] valueNames = rkAddInKey.GetValueNames();
                                    foreach (string valueName in valueNames)
                                    {
                                        //unregister both 32 and 64 xll
                                        if (valueName.StartsWith("OPEN") && (rkAddInKey.GetValue(valueName).ToString().Contains(parameters.Xll64Name) || rkAddInKey.GetValue(valueName).ToString().Contains(parameters.Xll32Name)))
                                        {
                                            Console.WriteLine("ɾ���� {0}", valueName);
                                            rkAddInKey.DeleteValue(valueName);
                                        }
                                    }
                                }
                                else
                                {
                                    session.Log("�����ڣ�{0}", keyName);
                                }
                            }
                        }
                        else
                        {
                            session.Log("�����ڣ�{0}", officeKey);
                        }
                    }
                }
                session.Log("����ע��ж��XLL���ڣ�CaUnRegisterAddIn��......");
            }
            catch (Exception ex)
            {
                session.Log(ex.Message);
            }
            if (!foundOffice)
            {
                MessageBox.Show("��װ�����г��ִ�����ر�ɱ��������ٴγ��԰�װ", "SumscopeAddIn");
            }
            return foundOffice ? ActionResult.Success : ActionResult.Failure;
        }
        #endregion

        #region ClosePrompt
        [CustomAction]
        public static ActionResult ClosePrompt(Session session)
        {
            //MessageBox.Show("���ر�");
            session.Log("Begin PromptToCloseApplications");
            try
            {
                var productName = session["ProductName"];
                var processes = session["PromptToCloseProcesses"].Split(',');
                var displayNames = session["PromptToCloseDisplayNames"].Split(',');

                if (processes.Length != displayNames.Length)
                {
                    session.Log(@"Please check that 'PromptToCloseProcesses' and 'PromptToCloseDisplayNames' exist and have same number of items.");
                    MessageBox.Show("��װ�����г��ִ�����ر�ɱ��������ٴγ��԰�װ", "SumscopeAddIn");
                    return ActionResult.Failure;
                }

                for (var i = 0; i < processes.Length; i++)
                {
                    session.Log("Prompting process {0} with name {1} to close.", processes[i], displayNames[i]);
                    using (var prompt = new PromptCloseApplication(productName, processes[i], displayNames[i]))
                    {
                        if (!prompt.Prompt())
                        {
                            MessageBox.Show("��װ�����г��ִ�����ر�ɱ��������ٴγ��԰�װ", "SumscopeAddIn");
                            return ActionResult.Failure;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                session.Log("Missing properties or wrong values. Please check that 'PromptToCloseProcesses' and 'PromptToCloseDisplayNames' exist and have same number of items. \nException:" + ex.Message);
                MessageBox.Show("��װ�����г��ִ�����ر�ɱ��������ٴγ��԰�װ", "SumscopeAddIn");
                return ActionResult.Failure;
            }

            session.Log("End PromptToCloseApplications");
            return ActionResult.Success;
        }
        #endregion

        #region GetAddInName
        private static string GetAddInName(string szXll32Name, string szXll64Name, string szOfficeVersionKey, double nVersion)
        {
            _pulicSession.Log("���Officeλ�� " + nVersion + "...");
            //Console.WriteLine("���Officeλ�� {0}...", nVersion);
            var officeBitness = GetOfficeBitness(szOfficeVersionKey, nVersion);
            _pulicSession.Log("GetOfficeBitnessֵΪ��{0}", officeBitness);
            switch (officeBitness)
            {
                case OfficeBitness.X86:
                    _pulicSession.Log("Office 32 bits.");
                    _pulicSession.Log("�������أ�" + szXll32Name);
                    return szXll32Name;

                case OfficeBitness.X64:
                    _pulicSession.Log("Office 64 bits.");
                    return szXll64Name;

                default:
                    throw new InvalidOperationException("�쳣��δ�ܼ���Office�汾λ�� " + nVersion);
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

            //����win10�û�λ���ڵ㴦��
            var cfgNotVerRegKey = cfgNotVerRegKey86 ?? cfgNotVerRegKey64;
            if (cfgNotVerRegKey == null) _pulicSession.Log(@"win10 �ڵ�check Ϊnull���ڵ�Ϊ��Software\Microsoft\Office\ClickToRun\Configuration");
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

        #region IsOfficeExcelInstalled �ж�ָ���汾��excel�Ƿ�װ ��Ϊ���ܻᰲװ����汾��excel ��ÿһ���汾��excel�������� excelAddin
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

        #region ����û����� ��ʱ��ʹ��

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

            //Console.Write("��ǰ�û��Ľ�ɫ�ǣ�");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.Guest);
            //if (IsUser)
            //    Console.WriteLine("����");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.User);
            //if (IsUser)
            //    Console.WriteLine("��ͨ�û�");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.PowerUser);
            //if (IsUser)
            //    Console.WriteLine("�����û�");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.Administrator);
            //if (IsUser)
            //    Console.WriteLine("ϵͳ����Ա");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.SystemOperator);
            //if (IsUser)
            //    Console.WriteLine("ϵͳ����Ա");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.BackupOperator);
            //if (IsUser)
            //    Console.WriteLine("���ݲ���Ա");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.PrintOperator);
            //if (IsUser)
            //    Console.WriteLine("��ӡ����Ա");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.AccountOperator);
            //if (IsUser)
            //    Console.WriteLine("�˻�����Ա");
            //IsUser = wp.IsInRole(WindowsBuiltInRole.Replicator);
            //if (IsUser)
            //    Console.WriteLine("���Ƴ���Ա");
            //return foundFolder ? ActionResult.Success : ActionResult.Failure;

            #endregion

            isUser = wp.IsInRole(WindowsBuiltInRole.Administrator);
            if (isUser)
            {
                session.Log("��ǰ�û�Ϊϵͳ����Ա\n");
                return ActionResult.Success;
            }
            else
            {
                session.Log("��ǰ�û�����ϵͳ����Ա\n");
                MessageBox.Show("��ǰ��¼�û�����ϵͳ����Ա������ϵϵͳ����Ա");
                return ActionResult.Failure;
            }
        }

        #endregion

        #region ж��֮ǰ�İ汾��VSTO�� �� Winform�棩
        [CustomAction]
        public static ActionResult CaOldUninstall(Session session)
        {
            //MessageBox.Show("�����ǰ�İ�װ����");
            bool foundFolder = true;
            string toPath = @"C:\Sumscope\Quoteboard\AddIn";
            string message;
            _pulicSession = session;

            #region ���ɰ汾VSTO����ж��
            string installVstoPath = OfficeInfo.CheckInstallVSTO();
            if (!string.IsNullOrEmpty(installVstoPath))
            {
                CancellationDll(session, ref foundFolder, toPath);//ע��DLL
                if (!foundFolder)
                {
                    MessageBox.Show("��װ�����г��ִ�����ر�ɱ��������ٴγ��԰�װ", "SumscopeAddIn");
                    return ActionResult.Failure;
                }
                #region ע��ж��XLL

                if (CaUnRegisterAddIn(session) == ActionResult.Failure)
                {
                    session.Log("ж��XLL����ʧ��");
                    MessageBox.Show("��װ�����г��ִ�����ر�ɱ��������ٴγ��԰�װ", "SumscopeAddIn");
                    return ActionResult.Failure;
                }
                #endregion

                #region ж�ؾɰ汾VSTO��װ����

                try
                {
                    session.Log("ж�ؾɰ汾VSTO��װ����......\n");
                    //��Ĭж��
                    string vstoInstallerPath = @"cd /d ""C:\Program Files\Common Files\Microsoft Shared\VSTO\10.0""";
                    string strCommand = @"VSTOInstaller /Uninstall """ + installVstoPath + "\"" + " /s";
                    string[] commandVsto = new string[2];
                    commandVsto[0] = vstoInstallerPath;
                    commandVsto[1] = strCommand;

                    bool b = RegisterDll(commandVsto, out message);
                    if (!b)
                    {
                        session.Log(message);
                        session.Log("ж�ؾɰ汾ʧ�ܣ����е�����������ж�أ�");
                    }

                    //ɾ��AddIn�ļ����µ������ļ�
                    Directory.Delete(@"C:\Sumscope\Quoteboard\AddIn", true);
                    session.Log("��ж�ؾɰ汾VSTO��װ����\n");
                }
                catch (Exception e)
                {
                    session.Log(e.ToString() + "\n");
                    session.Log("ж�ؾɰ汾VSTO��װ����ʧ��\n");
                    MessageBox.Show("��װ�����г��ִ�����ر�ɱ��������ٴγ��԰�װ", "SumscopeAddIn");
                    return ActionResult.Failure;
                }

                #endregion

            }
            #endregion

            #region ���ɰ汾WinForm��ж��
            string toPathDll = toPath + @"\SumscopeAddIn.dll";
            if (File.Exists(toPathDll))
            {
                try
                {
                    FileVersionInfo myFileVersionInfo = FileVersionInfo.GetVersionInfo(toPathDll);
                    string outputStrings = myFileVersionInfo.FileVersion.Replace(".", "");
                    if (int.Parse(outputStrings) < nowVersion)
                    {
                        CancellationDll(session, ref foundFolder, toPath);//ע��DLL
                        if (!foundFolder)
                        {
                            MessageBox.Show("��װ�����г��ִ�����ر�ɱ��������ٴγ��԰�װ", "SumscopeAddIn");
                            return ActionResult.Failure;
                        }
                        #region ע��ж��XLL
                        CaUnRegisterAddIn(session);
                        #endregion
                        DirectoryInfo di = new DirectoryInfo(toPath);
                        di.Delete(true);
                        session.Log("��ж�ؾɰ汾Winfrom��װ����\n");
                    }
                }
                catch (Exception e)
                {
                    session.Log(e.ToString() + "\n");
                    session.Log("ɾ���ļ�ʧ�� ж��winform��װ����ʧ��\n");
                    MessageBox.Show("��װ�����г��ִ�����ر�ɱ��������ٴγ��԰�װ", "SumscopeAddIn");
                    return ActionResult.Failure;
                }
            }
            #endregion

            session.Log("��ж�ؾɰ汾��װ����\n");
            if (!foundFolder)
            {
                MessageBox.Show("��װ�����г��ִ�����ر�ɱ��������ٴγ��԰�װ", "SumscopeAddIn");
            }
            return foundFolder ? ActionResult.Success : ActionResult.Failure;
        }
        /// <summary>
        /// ע��DLL
        /// </summary>
        /// <param name="session"></param>
        /// <param name="foundFolder"></param>
        /// <param name="toPath"></param>
        private static void CancellationDll(Session session, ref bool foundFolder, string toPath)
        {
            string message;
            try
            {
                session.Log("������������,���ṹ��......");
                Parameters parameters = Parameters.ExtractFromSession(session);

                foreach (string officeVersionKey in parameters.SupportedOfficeVersion)
                {
                    double version = double.Parse(officeVersionKey, NumberStyles.Any, CultureInfo.InvariantCulture);

                    session.Log("����ע���{0}", BaseAddInKey + officeVersionKey);

                    string excelBaseKey = BaseAddInKey + officeVersionKey + @"\Excel";

                    if (IsOfficeExcelInstalled(excelBaseKey))
                    {
                        string xllToRegister = GetAddInName(parameters.Xll32Name, parameters.Xll64Name,
                            officeVersionKey, version);
                        session.Log("GetAddInName��ȡֵΪ��{0}", xllToRegister);

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
                MessageBox.Show("�쳣��CaRegisterAddIn SecurityException" + ex.Message);
                foundFolder = false;
            }
            catch (System.UnauthorizedAccessException ex)
            {
                MessageBox.Show("�쳣��CaRegisterAddIn UnauthorizedAccessException" + ex.Message);
                foundFolder = false;
            }
            catch (Exception ex)
            {
                MessageBox.Show("�쳣��CaRegisterAddIn Exception" + ex.Message + "&" + ex.StackTrace);
                foundFolder = false;
            }

            if (File.Exists(Path.Combine(toPath, "SSMQCliWrapper.dll")))
            {

                session.Log("��ʼע�� SSMQCliWrapper\n");
                string[] unregistercommand = UnregisterCommand(_regasmPath, toPath,
                    "SSMQCliWrapper.dll");
                if (!RegisterDll(unregistercommand, out message))
                {
                    session.Log(message + "\nSSMQCliWrapper ע��ʧ��\n");
                }
                else
                {
                    session.Log(message + "\n�ɹ�ע�� SSMQCliWrapper\n");
                }
            }

            if (File.Exists(Path.Combine(toPath, "SumscopeServices.dll")))
            {
                session.Log("��ʼע�� SumscopeServices\n");
                string[] unregistercommand = UnregisterCommand(_regasmPath, toPath,
                    "SumscopeServices.dll");
                if (!RegisterDll(unregistercommand, out message))
                {
                    session.Log(message + "\nSumscopeServices ע��ʧ��\n");
                }
                else
                {
                    session.Log(message + "\n�ɹ�ע�� SumscopeServices\n");
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
        /// ִ��cmd
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
                        UseShellExecute = false,//�Ƿ�ʹ�ò���ϵͳshell����
                        RedirectStandardInput = true,//�������Ե��ó����������Ϣ
                        RedirectStandardOutput = true,//�ɵ��ó����ȡ�����Ϣ
                        RedirectStandardError = true,//�ض����׼�������
                        CreateNoWindow = true,//����ʾ���򴰿�
                        Verb = "runAs"//�Թ���ԱȨ������
                    }

                };

                p.Start();//��������

                //��cmd���ڷ���������Ϣ
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
