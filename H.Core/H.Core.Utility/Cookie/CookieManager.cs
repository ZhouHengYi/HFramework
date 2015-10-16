using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web;
using H.Core.Utility;

namespace H.Core.Utility
{
    /// <summary>
    /// Cookie静态操作类
    /// </summary>
    public static class CookieManager
    {
        static EncryHelper hepler = new EncryHelper();
        #region 静态方法

        /// <summary>
        /// 创建或修改COOKIE对象并赋Value值
        /// </summary>
        /// <param name="strCookieName">COOKIE对象名</param>
        /// <param name="strValue">COOKIE对象Value值</param>
        /// <remarks>
        /// 对COOKIE修改必须重新设Expires
        /// </remarks>
        public static void SetObject(string strCookieName, string strValue)
        {
            SetObject(strCookieName, Convert.ToInt32(WebConfig.CookieTimeOut), strValue, true);
        }

        public static void SetObject(string strCookieName, string strValue, bool isEncrypt)
        {
            SetObject(strCookieName, Convert.ToInt32(WebConfig.CookieTimeOut), strValue, isEncrypt);
        }

        /// <summary>
        /// 创建或修改COOKIE对象并赋Value值
        /// </summary>
        /// <param name="strCookieName">COOKIE对象名</param>
        /// <param name="iExpires">
        /// COOKIE对象有效时间（秒数）
        /// 1表示永久有效，0和负数都表示不设有效时间
        /// 大于等于2表示具体有效秒数
        /// 86400秒 = 1天 = （60*60*24）
        /// 604800秒 = 1周 = （60*60*24*7）
        /// 2593000秒 = 1月 = （60*60*24*30）
        /// 31536000秒 = 1年 = （60*60*24*365）
        /// </param>
        /// <param name="strValue">COOKIE对象Value值</param>
        /// <remarks>
        /// 对COOKIE修改必须重新设Expires
        /// </remarks>
        public static void SetObject(string strCookieName, int iExpires, string strValue, bool isEncrypt)
        {
            //加密
            if (isEncrypt)
                strValue = hepler.DoEncrypt(strValue, WebConfig.ProjectName + WebConfig.InteractionKey, Encoding.UTF8);

            HttpCookie objCookie = new HttpCookie(strCookieName.Trim());
            objCookie.Value = HttpContext.Current.Server.UrlEncode(strValue.Trim());
            if (iExpires > 0)
            {
                if (iExpires == 1)
                {
                    objCookie.Expires = DateTime.MaxValue;
                }
                else
                {
                    objCookie.Expires = DateTime.Now.AddSeconds(iExpires);
                }
            }
            HttpContext.Current.Response.Cookies.Add(objCookie);
        }

        /// <summary>
        /// 创建COOKIE对象并赋多个KEY键值
        /// </summary>
        /// <param name="strCookieName">COOKIE对象名</param>
        /// <param name="iExpires">
        /// COOKIE对象有效时间（秒数）
        /// 1表示永久有效，0和负数都表示不设有效时间
        /// 大于等于2表示具体有效秒数
        /// 86400秒 = 1天 = （60*60*24）
        /// 604800秒 = 1周 = （60*60*24*7）
        /// 2593000秒 = 1月 = （60*60*24*30）
        /// 31536000秒 = 1年 = （60*60*24*365）
        /// </param>
        /// <param name="KeyValue">键/值对集合</param>
        public static void SetObject(string strCookieName, int iExpires, NameValueCollection KeyValue)
        {
            HttpCookie objCookie = new HttpCookie(strCookieName.Trim());
            foreach (string key in KeyValue.AllKeys)
            {
                objCookie[key] = HttpContext.Current.Server.UrlEncode(KeyValue[key].Trim());
            }
            if (iExpires > 0)
            {
                if (iExpires == 1)
                {
                    objCookie.Expires = DateTime.MaxValue;
                }
                else
                {
                    objCookie.Expires = DateTime.Now.AddSeconds(iExpires);
                }
            }
            HttpContext.Current.Response.Cookies.Add(objCookie);
        }

        /// <summary>
        /// 创建或修改COOKIE对象并赋Value值
        /// </summary>
        /// <param name="strCookieName">COOKIE对象名</param>
        /// <param name="iExpires">
        /// COOKIE对象有效时间（秒数）
        /// 1表示永久有效，0和负数都表示不设有效时间
        /// 大于等于2表示具体有效秒数
        /// 86400秒 = 1天 = （60*60*24）
        /// 604800秒 = 1周 = （60*60*24*7）
        /// 2593000秒 = 1月 = （60*60*24*30）
        /// 31536000秒 = 1年 = （60*60*24*365）
        /// </param>
        /// <param name="strDomain">作用域</param>
        /// <param name="strValue">COOKIE对象Value值</param>
        /// <remarks>
        /// 对COOKIE修改必须重新设Expires
        /// </remarks>
        public static void SetObject(string strCookieName, int iExpires, string strValue, string strDomain)
        {
            HttpCookie objCookie = new HttpCookie(strCookieName.Trim());
            objCookie.Value = HttpContext.Current.Server.UrlEncode(strValue.Trim());
            objCookie.Domain = strDomain.Trim();
            if (iExpires > 0)
            {
                if (iExpires == 1)
                {
                    objCookie.Expires = DateTime.MaxValue;
                }
                else
                {
                    objCookie.Expires = DateTime.Now.AddSeconds(iExpires);
                }
            }
            HttpContext.Current.Response.Cookies.Add(objCookie);
        }

        /// <summary>
        /// 创建COOKIE对象并赋多个KEY键值
        /// </summary>
        /// <param name="strCookieName">COOKIE对象名</param>
        /// <param name="iExpires">
        /// COOKIE对象有效时间（秒数）
        /// 1表示永久有效，0和负数都表示不设有效时间
        /// 大于等于2表示具体有效秒数
        /// 86400秒 = 1天 = （60*60*24）
        /// 604800秒 = 1周 = （60*60*24*7）
        /// 2593000秒 = 1月 = （60*60*24*30）
        /// 31536000秒 = 1年 = （60*60*24*365）
        /// </param>
        /// <param name="strDomain">作用域</param>
        /// <param name="KeyValue">键/值对集合</param>
        public static void SetObject(string strCookieName, int iExpires, NameValueCollection KeyValue, string strDomain)
        {
            HttpCookie objCookie = new HttpCookie(strCookieName.Trim());
            foreach (string key in KeyValue.AllKeys)
            {
                objCookie[key] = HttpContext.Current.Server.UrlEncode(KeyValue[key].Trim());
            }
            objCookie.Domain = strDomain.Trim();
            if (iExpires > 0)
            {
                if (iExpires == 1)
                {
                    objCookie.Expires = DateTime.MaxValue;
                }
                else
                {
                    objCookie.Expires = DateTime.Now.AddSeconds(iExpires);
                }
            }
            HttpContext.Current.Response.Cookies.Add(objCookie);
        }

        /// <summary>
        /// 读取Cookie某个对象的Value值，返回Value值
        /// </summary>
        /// <param name="strCookieName">Cookie对象名称</param>
        /// <returns>Value值，如果对象本就不存在，则返回 null</returns>
        public static string GetValue(string strCookieName)
        {
            if (HttpContext.Current.Request.Cookies[strCookieName] == null)
            {
                return null;
            }
            else
            {
                return HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Cookies[strCookieName].Value);
            }
        }

        /// <summary>
        /// 读取Cookie某个对象的Value值，返回Value值
        /// </summary>
        /// <param name="strCookieName">Cookie对象名称</param>
        /// <returns>Value值，如果对象本就不存在，则返回 null</returns>
        public static string GetValue(string strCookieName, bool isEncrypt)
        {
            if (HttpContext.Current.Request.Cookies[strCookieName] == null)
            {
                return null;
            }
            else
            {
                string val = HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Cookies[strCookieName].Value);
                if (isEncrypt)
                        val = hepler.DoDecrypt(val, WebConfig.ProjectName + WebConfig.InteractionKey, Encoding.UTF8);
                return val;
            }
        }

        /// <summary>
        /// 读取Cookie某个对象的某个Key键的键值
        /// </summary>
        /// <param name="strCookieName">Cookie对象名称</param>
        /// <param name="strKeyName">Key键名</param>
        /// <returns>Key键值，如果对象或键值就不存在，则返回 null</returns>
        public static string GetValue(string strCookieName, string strKeyName)
        {
            if (HttpContext.Current.Request.Cookies[strCookieName] == null)
            {
                return null;
            }
            else
            {
                string strObjValue = HttpContext.Current.Request.Cookies[strCookieName].Value;
                string strKeyName2 = strKeyName + "=";
                if (strObjValue.IndexOf(strKeyName2) == -1)
                {
                    return null;
                }
                else
                {
                    return HttpContext.Current.Server.UrlDecode(HttpContext.Current.Request.Cookies[strCookieName][strKeyName]);
                }
            }
        }

        /// <summary>
        /// 修改某个COOKIE对象某个Key键的键值或给某个COOKIE对象添加Key键
        /// </summary>
        /// <param name="strCookieName">Cookie对象名称</param>
        /// <param name="strKeyName">Key键名</param>
        /// <param name="KeyValue">Key键值</param>
        /// <param name="iExpires">
        /// COOKIE对象有效时间（秒数）
        /// 1表示永久有效，0和负数都表示不设有效时间
        /// 大于等于2表示具体有效秒数
        /// 86400秒 = 1天 = （60*60*24）
        /// 604800秒 = 1周 = （60*60*24*7）
        /// 2593000秒 = 1月 = （60*60*24*30）
        /// 31536000秒 = 1年 = （60*60*24*365）
        /// </param>
        /// <returns>如果对象本就不存在，则返回 false</returns>
        public static bool Edit(string strCookieName, string strKeyName, string KeyValue, int iExpires)
        {
            if (HttpContext.Current.Request.Cookies[strCookieName] == null)
            {
                return false;
            }
            else
            {
                HttpCookie objCookie = HttpContext.Current.Request.Cookies[strCookieName];
                objCookie[strKeyName] = HttpContext.Current.Server.UrlEncode(KeyValue.Trim());
                if (iExpires > 0)
                {
                    if (iExpires == 1)
                    {
                        objCookie.Expires = DateTime.MaxValue;
                    }
                    else
                    {
                        objCookie.Expires = DateTime.Now.AddSeconds(iExpires);
                    }
                }
                HttpContext.Current.Response.Cookies.Add(objCookie);
                return true;
            }
        }

        /// <summary>
        /// 删除COOKIE对象
        /// </summary>
        /// <param name="strCookieName">Cookie对象名称</param>
        public static void Delete(string strCookieName)
        {
            HttpCookie objCookie = new HttpCookie(strCookieName.Trim());
            objCookie.Expires = DateTime.Now.AddYears(-5);
            HttpContext.Current.Response.Cookies.Add(objCookie);
        }

        /// <summary>
        /// 删除某个COOKIE对象某个Key子键
        /// </summary>
        /// <param name="strCookieName">Cookie对象名称</param>
        /// <param name="strKeyName">Key键名</param>
        /// <param name="iExpires">
        /// COOKIE对象有效时间（秒数）
        /// 1表示永久有效，0和负数都表示不设有效时间
        /// 大于等于2表示具体有效秒数
        /// 86400秒 = 1天 = （60*60*24）
        /// 604800秒 = 1周 = （60*60*24*7）
        /// 2593000秒 = 1月 = （60*60*24*30）
        /// 31536000秒 = 1年 = （60*60*24*365）
        /// </param>
        /// <returns>如果对象本就不存在，则返回 false</returns>
        public static bool Delete(string strCookieName, string strKeyName, int iExpires)
        {
            if (HttpContext.Current.Request.Cookies[strCookieName] == null)
            {
                return false;
            }
            else
            {
                HttpCookie objCookie = HttpContext.Current.Request.Cookies[strCookieName];
                objCookie.Values.Remove(strKeyName);
                if (iExpires > 0)
                {
                    if (iExpires == 1)
                    {
                        objCookie.Expires = DateTime.MaxValue;
                    }
                    else
                    {
                        objCookie.Expires = DateTime.Now.AddSeconds(iExpires);
                    }
                }
                HttpContext.Current.Response.Cookies.Add(objCookie);
                return true;
            }
        }

        #endregion
    }
}
