using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Serialization;

namespace GraduationDesignManagement.Common
{
    /// <summary>
    /// XML操作
    /// </summary>
    public class XmlUtil
    {
        /*
         *     [System.Xml.Serialization.XmlRoot("ItemName")]//根
         *     [System.Xml.Serialization.XmlAttribute("ItemName")]//属性
         *     [System.Xml.Serialization.XmlElement("ItemName")]//元素
         *     [System.Xml.Serialization.XmlArrayItemAttribute("ItemName", typeof(T))]//派生类型
         */

        #region 序列化

        /// <summary>
        /// 序列化object对象为XML字符串
        /// </summary>
        /// <param name="ObjectToSerialize">要序列化的类</param>
        /// <returns>结果</returns>
        public static string Serializable(object ObjectToSerialize, bool indent = false)
        {
            string result = null;
            try
            {
                #region 去除XML自带命名空间
                XmlSerializerNamespaces ns = new XmlSerializerNamespaces();
                ns.Add("", "");
                #endregion

                #region 格式化

                XmlWriterSettings setting = new XmlWriterSettings();
                setting.Indent = indent;
                setting.Encoding = Encoding.Default;

                #endregion

                XmlSerializer xmlSerializer = new XmlSerializer(ObjectToSerialize.GetType());
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    XmlTextWriter xmlTextWriter = new XmlTextWriter(memoryStream, new UTF8Encoding(false));
                    xmlTextWriter.Formatting = Formatting.Indented;
                    xmlSerializer.Serialize(xmlTextWriter, ObjectToSerialize, ns);//最后一个ns参数为指定命名空间
                    xmlTextWriter.Flush();
                    xmlTextWriter.Close();
                    UTF8Encoding uTF8Encoding = new UTF8Encoding(false, true);
                    result = uTF8Encoding.GetString(memoryStream.ToArray());
                }
            }
            catch (Exception innerException)
            {
                throw new ApplicationException("Couldn't Serialize Object:" + ObjectToSerialize.GetType().Name, innerException);
            }
            return result;
        }

        #endregion

        #region 反序列化

        /// <summary>
        /// 反序列化XML字符串为指定类型
        /// </summary>
        /// <param name="Xml">包含XML的字符串</param>
        /// <param name="ThisType">转换后的类型</param>
        /// <returns>结果</returns>
        public static object Deserialize(string Xml, Type ThisType)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(ThisType);
            object result;
            try
            {
                using (StringReader stringReader = new StringReader(Xml))
                {
                    result = xmlSerializer.Deserialize(stringReader);
                }
            }
            catch (Exception innerException)
            {
                bool flag = false;
                if (Xml != null)
                {
                    if (Xml.StartsWith(Encoding.UTF8.GetString(Encoding.UTF8.GetPreamble())))
                    {
                        flag = true;
                    }
                }
                throw new ApplicationException(string.Format("Couldn't parse XML: '{0}'; Contains BOM: {1}; Type: {2}.", Xml, flag, ThisType.FullName), innerException);
            }
            return result;
        }

        /// <summary>
        /// 反序列化XML字符串为指定类型
        /// </summary>
        /// <typeparam name="T">转换后的类型</typeparam>
        /// <param name="xmlString">包含XML的字符串</param>
        /// <param name="Normalization">是否忽略属性里的换行符</param>
        /// <returns></returns>
        public static T Deserialize<T>(string xmlString, bool normalization = true)
        {
            T rt = default(T);
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(T));
            using (Stream xmlStream = new MemoryStream(Encoding.UTF8.GetBytes(xmlString)))
            {
                if (!normalization)
                {
                    using (XmlTextReader reader = new XmlTextReader(xmlStream))
                    {
                        // 注意一定要创建出一个 XmlTextReader出来，   
                        // 因为MS默认的 reader.Normalization = true   
                        // 设置成false就不会把回车去掉了   
                        reader.Normalization = false;
                        Object obj = xmlSerializer.Deserialize(reader);
                        rt = (T)obj;
                    }
                }
                else
                {
                    Object obj = xmlSerializer.Deserialize(xmlStream);
                    rt = (T)obj;
                }
            }
            return rt;
        }

        #endregion

        #region 格式化

        /// <summary>
        /// 格式化显示Xml
        /// </summary>
        /// <param name="source">Xml字符串</param>
        /// <returns>格式化后的Xml字符串</returns>
        private string FormatXml(string source)
        {
            StringBuilder sb = new StringBuilder();
            XmlTextWriter writer = null;
            try
            {
                XmlDocument doc = new XmlDocument();
                doc.LoadXml(source);

                writer = new XmlTextWriter(new StringWriter(sb));
                writer.Formatting = Formatting.Indented;

                doc.WriteTo(writer);
            }
            finally
            {
                if (writer != null) writer.Close();
            }

            return sb.ToString();
        }

        #endregion
    }
}
