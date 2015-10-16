using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;

namespace H.Core.Utility
{
    public static class WebConfig
    {
        /// <summary>
        /// Rest返回类型
        /// </summary>
        public static string RestResponseFormat
        {
            get
            {
                if (string.IsNullOrEmpty(ConfigurationManager.AppSettings["RestResponseFormat"]))
                    return "application/json";
                return ConfigurationManager.AppSettings["RestResponseFormat"].ToString();
            }
        }

        /// <summary>
        /// 项目名称
        /// </summary>
        public static string ProjectName
        {
            get
            {
                return ConfigurationManager.AppSettings["ProjectName"].ToString();
            }
        }

        /// <summary>
        /// 加密字符串
        /// </summary>
        public static string InteractionKey
        {
            get
            {
                return ConfigurationManager.AppSettings["InteractionKey"].ToString();
            }
        }

        /// <summary>
        /// Rest 服务地址
        /// </summary>
        public static string RestServiceHost
        {
            get
            {
                return ConfigurationManager.AppSettings["RestServiceHost"].ToString();
            }
        }

        /// <summary>
        /// 是否隐藏程序错误异常 True | False
        /// </summary>
        public static string HandlerError
        {
            get
            {
                return ConfigurationManager.AppSettings["HandlerError"].ToString();
            }
        }

        /// <summary>
        /// REST Services 配置地址
        /// </summary>
        public static string RestServiceConfigPath
        {
            get
            {
                return ConfigurationManager.AppSettings["RestServiceConfigPath"].ToString();
            }
        }

        /// <summary>
        /// 设置网站启动时和网站关闭时自动执行的任务的配置文件路径， 
        /// 支持绝对路径或相对于WebHost跟目录的路径
        /// </summary>
        public static string AutorunConfigPath
        {
            get
            {
                return ConfigurationManager.AppSettings["AutorunConfigPath"].ToString();
            }
        }

        /// <summary>
        /// Cookie过期时间
        /// </summary>
        public static string CookieTimeOut
        {
            get
            {
                return ConfigurationManager.AppSettings["CookieTimeOut"].ToString();
            }
        }

        /// <summary>
        /// 图片上传服务路径
        /// </summary>
        public static string UploadService
        {
            get
            {
                return ConfigurationManager.AppSettings["UploadService"].ToString();
            }
        }

        /// <summary>
        /// 图片地址
        /// </summary>
        public static string UploadImageUrl
        {
            get
            {
                return ConfigurationManager.AppSettings["UploadImageUrl"].ToString();
            }
        }
        /// <summary>
        /// 前台学校logo地址
        /// </summary>
        public static string SchoolLogoUrlWebSite
        {
            get {
                return ConfigurationManager.AppSettings["SchoolLogoUrlWebSite"].ToString();
            }
 
        }

        /// <summary>
        /// 编辑器图片上传服务
        /// </summary>
        public static string EditorUploadService
        {
            get
            {
                return ConfigurationManager.AppSettings["EditorUploadService"].ToString();
            }
        }        

        /// <summary>
        /// 页面路径配置
        /// </summary>
        public static string PageConfigPath
        {
            get
            {
                return ConfigurationManager.AppSettings["PageConfigPath"].ToString();
            }
        }

        /// <summary>
        /// 导航路径配置
        /// </summary>
        public static string SiteMapConfigPath
        {
            get
            {
                return ConfigurationManager.AppSettings["SiteMapConfigPath"].ToString();
            }
        }

        /// <summary>
        /// 文件监控配置
        /// </summary>
        public static string FileWatcherConfigPath
        {
            get
            {
                return ConfigurationManager.AppSettings["FileWatcherConfigPath"].ToString();
            }
        }

        /// <summary>
        /// 路由配置
        /// </summary>
        public static string UrlMapping
        {
            get
            {
                return ConfigurationManager.AppSettings["UrlMapping"].ToString();
            }
        }
        
        /// <summary>
        /// 申请流程项目方案
        /// </summary>
        public static string SepasPorjectConfig
        {
            get
            {
                return ConfigurationManager.AppSettings["SepasPorjectConfig"].ToString();
            }
        }
    }
}
