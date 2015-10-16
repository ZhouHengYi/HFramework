
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace H.Core.Utility.Resources
{
    public static class PageConfig
    {
        public static PageList s_PageCache = null;
        private static object s_SyncObj = new object();
        private static string GetConfigPath()
        {
            string path = WebConfig.PageConfigPath;
            if (path == null || path.Trim().Length <= 0)
            {
                return Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Configs/Page.config");
            }
            string p = Path.GetPathRoot(path);
            if (p == null || p.Trim().Length <= 0) // 说明是相对路径
            {
                path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
            }
            return path;
        }

        public static PageList GetAllPage()
        {
            if (s_PageCache == null)
            {
                lock (s_SyncObj)
                {
                    string path = GetConfigPath();
                    s_PageCache = XmlHelper.LoadFromXmlCache<PageList>(path);
                    return s_PageCache;
                }
            }
            else
                return s_PageCache;
        }

        public static PageList.PageItem GetPage(string name)
        {
            PageList list = GetAllPage();
            return list.ItemList.First(a => { return a.Name.Trim().ToLower() == name.ToLower(); });
        }

        public static PageList.PageItem GetPagePath(string path)
        {
            try
            {

                PageList list = GetAllPage();
                return list.ItemList.First(a => { return a.Path.ToLower() == path.ToLower(); });
            }
            catch (Exception ex)
            {
               //throw new BizException("请访问重写过的URL地址!");
                return new PageList.PageItem();
            }
        }
    }

    [XmlRoot("pages", Namespace = "http://zhy.seo.sh.cn/Pages")]
    public class PageList
    {
        public class PageItem
        {
            [XmlAttribute("path")]
            public string Path
            {
                get;
                set;
            }

            [XmlAttribute("name")]
            public string Name
            {
                get;
                set;
            }
        }

        [XmlElement("page")]
        public PageItem[] ItemList
        {
            get;
            set;
        }
    }
}
