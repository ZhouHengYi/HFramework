using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using H.Core.Utility.Resources;

namespace H.Website.Facade
{
    public class UrlHelper
    {
        /// <summary>
        /// 构造Url
        /// </summary>
        /// <param name="pageAlias"></param>
        /// <returns></returns>
        public static string BuildUrl(Enum pageAlias)
        {
            PageList.PageItem pageInfo = PageConfig.GetPage(pageAlias.ToString());
            string baseUrl = pageInfo.Path;
            if (pageInfo.Path.StartsWith("~/"))
                baseUrl = VirtualPathUtility.ToAbsolute(pageInfo.Path);
            return baseUrl;
        }
        /// <summary>
        /// 构造Url
        /// </summary>
        /// <param name="pageAlias"></param>
        /// <param name="queryString">The query string. in the format of param1, value1, param2, value2, ...</param>
        /// <returns></returns>
        public static string BuildUrl(Enum pageAlias, params string[] queryString)
        {
            string url = BuildUrl(pageAlias);
            for (int i = 0; i < queryString.Length; i += 2)
            {
                if (url.IndexOf("?") < 0)
                    url += string.Format("?{0}={1}", queryString[i], queryString[i + 1]);
                else
                    url += string.Format("&{0}={1}", queryString[i], queryString[i + 1]);
            }
            return url;
        }

    }
}
