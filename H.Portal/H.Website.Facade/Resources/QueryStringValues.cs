using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace H.Website.Facade
{
    public class QueryStringValues
    {
        /// <summary>
        /// 页面返回路径
        /// </summary>
        public static string ReturnUrl
        {
            get
            {
                return HttpContext.Current.Request.QueryString[ResourceKeys.ReturnUrl];
            }
        }
    }
}
