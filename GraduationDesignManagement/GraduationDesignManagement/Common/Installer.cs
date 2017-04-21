using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace GetWebRequest
{
    public class Installer
    {

        private List<Install> _install = new List<Install>();
        [XmlElement]
        public List<Install> Installs
        {
            get { return _install; }
            set { _install = value; }
        }
    }

    public class Install : IComparable
    {
        public string FileVersion { get; set; }
        public string Timedata { get; set; }
        public string FilerPath { get; set; }
        public string FilerName { get; set; }

        /// <summary>
        /// 用于比较安装程序的版本
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int CompareTo(object obj)
        {
            int res = 0;
            try
            {
                Install install = (Install)obj;
                Version thisVersion, objVersion;
                if (Version.TryParse(this.FileVersion, out thisVersion) && Version.TryParse(install.FileVersion, out objVersion))
                {
                    res = thisVersion <= objVersion ? 1 : -1;
                }
                else
                {
                    res = -1;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("比较异常", ex.InnerException);
            }
            return res;
        }
    }
}
