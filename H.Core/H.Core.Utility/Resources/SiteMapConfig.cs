using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace H.Core.Utility.Resources
{
    public class SiteMapConfig
    {
        public static SiteMapList s_PageCache = null;
        private static object s_SyncObj = new object();
        private static string GetConfigPath()
        {
            string path = WebConfig.SiteMapConfigPath;
            if (path == null || path.Trim().Length <= 0)
            {
                return Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Configs/SiteMap.config");
            }
            string p = Path.GetPathRoot(path);
            if (p == null || p.Trim().Length <= 0) // 说明是相对路径
            {
                path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
            }
            return path;
        }

        public static SiteMapList GetAllSiteMap()
        {
            //if (s_PageCache == null)
            //{
            //    lock (s_SyncObj)
            //    {
                    string path = GetConfigPath();
                    s_PageCache = XmlHelper.LoadFromXml<SiteMapList>(path);
                    return s_PageCache;
            //    }
            //}
            //else
            //    return s_PageCache;
        }
    }

    [XmlRoot("SiteMap", Namespace = "http://zhy.seo.sh.cn/SiteMap")]
    public class SiteMapList
    {
        public class NodeListEntity
        {
            [XmlAttribute("key")]
            public string Key
            {
                get;
                set;
            }

            [XmlElement("Node")]
            public List<NodeEntity> Node
            {
                get;
                set;
            }

            public class NodeEntity
            {
                [XmlAttribute("pageAlice")]
                public string PageAlice
                {
                    get;
                    set;
                }
                [XmlAttribute("key")]
                public string Key
                {
                    get;
                    set;
                }
            }

        }

        [XmlElement("NodeList")]
        public List<NodeListEntity> NodeList
        {
            get;
            set;
        }
    }
}
