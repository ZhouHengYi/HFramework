using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.Routing;
using System.Xml.Serialization;

namespace H.Core.Utility
{
    public class UrlMappingWatcherStartup : IStartup
    {
        public static UrlMappingList s_PageCache = null;
        private static object s_SyncObj = new object();
        private string m_CustomBizExceptionTypeName;

        private static string GetAutorunXmlPath()
        {
            string path = WebConfig.UrlMapping;
            if (path == null || path.Trim().Length <= 0)
            {
                return Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Configuration/Page/UrlMapping.config");
            }
            string p = Path.GetPathRoot(path);
            if (p == null || p.Trim().Length <= 0) // 说明是相对路径
            {
                path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
            }
            return path;
        }

        public static UrlMappingList GetAllUrlMapping()
        {
            if (s_PageCache == null)
            {
                lock (s_SyncObj)
                {
                    string path = GetAutorunXmlPath();
                    s_PageCache = XmlHelper.LoadFromXmlCache<UrlMappingList>(path);
                    return s_PageCache;
                }
            }
            else
                return s_PageCache;
        }

        public static UrlMappingList.RoteItem GetUrlMapping(string name)
        {
            UrlMappingList list = GetAllUrlMapping();
            return list.RoteList.First(a => { return a.RoteName.Trim().ToLower() == name.ToLower(); });
        }

        public UrlMappingWatcherStartup()
            : this(null)
        {

        }

        public UrlMappingWatcherStartup(string customBizExceptionTypeName)
        {
            m_CustomBizExceptionTypeName = customBizExceptionTypeName;
        }

        public void Start()
        {
            string filePath = GetAutorunXmlPath();
            if (!string.IsNullOrEmpty(filePath))
            {
                UrlMappingList list = GetAllUrlMapping();

                list.RoteList.ForEach(r => {
                    RouteTable.Routes.MapPageRoute(
                    r.RoteName,           //路由名称
                    r.RoteUrl,    //路由地址
                    r.PhysicalFile);  //物理文件
                });

            }
        }

        [XmlRoot("urlMapping", Namespace = "http://www.hosting.cn/")]
        public class UrlMappingList
        {
            public class RoteItem
            {
                [XmlAttribute("roteName")]
                public string RoteName { get; set; }

                [XmlAttribute("roteUrl")]
                public string RoteUrl { get; set; }

                [XmlAttribute("physicalFile")]
                public string PhysicalFile { get; set; }
            }

            [XmlElement("rote")]
            public RoteItem[] RoteList { get; set; }
        }
    }
}
