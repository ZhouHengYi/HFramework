using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using H.Core.Utility;

namespace H.Core.Rest
{
    internal static class ServiceConfig
    {
        private static ServiceList s_ServiceCache = null;
        private static object s_SyncObj = new object();
        private static string GetConfigPath()
        {
            string path = WebConfig.RestServiceConfigPath;
            if (path == null || path.Trim().Length <= 0)
            {
                return Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Configuration/RestService.config");
            }
            string p = Path.GetPathRoot(path);
            if (p == null || p.Trim().Length <= 0) // 说明是相对路径
            {
                path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
            }
            return path;
        }

        public static ServiceList GetAllService()
        {
            if (s_ServiceCache == null)
            {
                lock (s_SyncObj)
                {
                    string path = GetConfigPath();
                    s_ServiceCache = XmlHelper.LoadFromXmlCache<ServiceList>(path);
                    return s_ServiceCache;
                }
            }
            else
                return s_ServiceCache;
        }
    }


    [XmlRoot("serviceList", Namespace = "http://oversea.newegg.com/ServiceList")]
    public class ServiceList
    {
        public class Service
        {
            [XmlAttribute("path")]
            public string Path
            {
                get;
                set;
            }

            [XmlAttribute("type")]
            public string Type
            {
                get;
                set;
            }
        }

        [XmlElement("service")]
        public Service[] ItemList
        {
            get;
            set;
        }
    }
}
