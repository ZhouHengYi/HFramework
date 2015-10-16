using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace H.Core.Utility
{
    /// <summary>
    /// RestWebService启动类，继承IStartup统一接口.方便服务启动时在自定义Config中定义
    /// </summary>
    public class FileSystemWatcherStartup : IStartup
    {
        private string m_CustomBizExceptionTypeName;

        private static string GetAutorunXmlPath()
        {
            string path = WebConfig.FileWatcherConfigPath;
            if (path == null || path.Trim().Length <= 0)
            {
                return Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Configuration/FileWatcher.config");
            }
            string p = Path.GetPathRoot(path);
            if (p == null || p.Trim().Length <= 0) // 说明是相对路径
            {
                path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
            }
            return path;
        }

        public FileSystemWatcherStartup()
            : this(null)
        {

        }

        public FileSystemWatcherStartup(string customBizExceptionTypeName)
        {
            m_CustomBizExceptionTypeName = customBizExceptionTypeName;
        }

        public void Start()
        {
            string filePath = GetAutorunXmlPath();
            if (!string.IsNullOrEmpty(filePath))
            {
                FileWatcherList list = XmlHelper.LoadFromXml<FileWatcherList>(filePath);
                foreach (var item in list.ItemList) new FileSystemWatcherManager(item.Value).SetupWacher();
            }
        }

        [XmlRoot("fileWatcherList", Namespace = "http://www.hosting.cn/")]
        public class FileWatcherList
        {
            public class FileItem {
                [XmlAttribute("value")]
                public string Value { get; set; }
            }

            [XmlElement("fileItem")]
            public FileItem[] ItemList { get; set; }

        }
    }
}
