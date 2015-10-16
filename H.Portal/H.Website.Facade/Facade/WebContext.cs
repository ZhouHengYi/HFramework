using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using H.Core.Utility;
using H.Entity;
using System.Web;
using H.Website.Facade.Facade;

namespace H.Website.Facade
{
    public sealed class WebContext
    {
        static EncryHelper hepler = new EncryHelper();
        /// <summary>
        /// 获取登陆用户信息
        /// </summary>
        public static AuthUserEntity LoginUser
        {
            get
            {
                string login = CookieManager.GetValue("HenryProjectUser");
                if (!string.IsNullOrEmpty(login))
                {
                    login = hepler.DoDecrypt(login, WebConfig.ProjectName + WebConfig.InteractionKey, Encoding.UTF8);
                    AuthUserEntity entity = new JsonSerializer().Deserialize<AuthUserEntity>(login);
                    if (HttpContext.Current.Session["HenryProjectUser"] == null)
                    {
                        SystemUserEntity resultEntity = SystemUserFacade.LoadEntity(entity.SysNo);
                        //ElleUserEntity resultEntity = RestClient.Post<ElleUserEntity>("ElleUserService/ElleUserByComputerName",
                        //    new ElleUserEntity() { ComputerName = entity.UserName });
                        if (resultEntity != null)
                        {
                            //entity.Privilege = resultEntity.Privilege;
                            HttpContext.Current.Session["HenryProjectUser"] = entity;
                        }
                        else
                        {
                            return null;
                        }

                        
                    }
                    return HttpContext.Current.Session["HenryProjectUser"] as AuthUserEntity;
                }
                else
                    return null;
            }
        }

        /// <summary>
        /// 获取当前登陆用户信息
        /// </summary>
        /// <returns></returns>
        public static AuthUserEntity GetCurrentLoginUser()
        {
            AuthUserEntity auth = WebContext.LoginUser;
            //if (auth == null)
            //{
            //    var identity = HttpContext.Current.User.Identity;
            //    if (identity != null && identity.IsAuthenticated && !string.IsNullOrEmpty(identity.Name))
            //    {
            //        string userName = identity.Name;
            //        auth = GetAuthUserByUserID(userName);
            //        StateValues.LoginUser = auth;
            //    }
            //}
            return auth;
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="entity"></param>
        public static void Login(AuthUserEntity entity)
        {
            string jsonEntity = new JsonSerializer().Serialization(entity, typeof(AuthUserEntity));
            CookieManager.SetObject("HenryProjectUser", jsonEntity);
            //HttpContext.Current.Session.Add("VendorLogin", jsonEntity);
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        public static void SignOut()
        {
            //清除缓存的权限
            //string authCacheKey = FunctionFacade.GenerateCacheKey();
            //if (!string.IsNullOrEmpty(authCacheKey))
            //{
            //    CacheManager.Remove(authCacheKey);
            //}
            //HttpContext.Current.Session.Remove("VendorLogin");
            CookieManager.Delete("HenryProjectUser");
            CookieManager.Delete("LoginReturnUrl");
            HttpContext.Current.Session.Clear();
            //HttpContext.Current.Response.Redirect(UrlHelper.BuildUrl(PageAlias.SystemLogin), true);
        }

        /// <summary>
        /// 设置加载URL
        /// </summary>
        /// <param name="url"></param>
        public static void SetLoginReturnUrl(string url)
        {
            CookieManager.SetObject("LoginReturnUrl", url, false);
        }
    }
}
