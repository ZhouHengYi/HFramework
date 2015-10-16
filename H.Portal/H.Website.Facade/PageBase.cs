using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using H.Entity;
using H.Core.Utility;
using H.Core.Utility.Resources;
using System.Configuration;

namespace H.Website.Facade
{
    public class PageBase : Page
    {
        /// <summary>
        /// 登陆认证
        /// </summary>
        protected virtual bool RequireAuth
        {
            get { return true; }
        }

        /// <summary>
        /// 只有登陆认证通过，才会进行权限认证
        /// </summary>
        protected virtual bool RequirePermissionAuth
        {
            get { return true; }
        }

        protected string CurrentUrl
        {
            get { return HttpContext.Current.Request.CurrentExecutionFilePath; }
        }

        protected string BuildUrl(Enum pageAlias)
        {
            return UrlHelper.BuildUrl(pageAlias);
        }
        protected string BuildUrl(Enum pageAlias, params string[] queryString)
        {
            return UrlHelper.BuildUrl(pageAlias, queryString);
        }

        /// <summary>
        /// 登录用户
        /// </summary>
        public AuthUserEntity LoginUser
        {
            get
            {
                return WebContext.GetCurrentLoginUser();
            }
        }
        /// <summary>
        /// 当前页面。
        /// </summary>
        public PageAlias PageAlias
        {
            get
            {
                //根据页面路径获取PageAlice
                string url = this.Page.Request.FilePath;
                PageList.PageItem item = PageConfig.GetPagePath(url);
                return EnumHelper.GetEnumByKey<PageAlias>(item.Name);
            }
        }

        /// <summary>
        /// 登录验证
        /// </summary>
        protected virtual void Authenticate()
        {
            if (this.RequireAuth)
            {
                if (this.LoginUser == null)
                {
                    Response.Redirect(BuildUrl(PageAlias.Login, ResourceKeys.ReturnUrl, HttpContext.Current.Server.UrlEncode(CurrentUrl)), true);
                }
                //if (this.RequirePermissionAuth &&
                //    !WebContext.LoginUser.Privilege.Exists(x => { return x.PageAlice == PageAlias.ToString(); }))
                //{
                //    Response.Write("没有权限访问该页面，请联系管理员维护...");
                //    Response.End();
                //}
            }            
        }

        /// <summary>
        /// 设置页面不缓存。
        /// </summary>
        public void SetNoCache()
        {
            Response.Cache.SetExpires(DateTime.Now.AddHours(-1));
            Response.CacheControl = "no-cache";
            Response.Cache.SetCacheability(HttpCacheability.NoCache);
            Response.Cache.SetValidUntilExpires(true);
        }

        #region [ Initilize ]

        protected override void OnPreInit(EventArgs e)
        {
            Page.Title = ConfigurationManager.AppSettings["WebSiteTitle"];
            base.OnPreInit(e);
            Authenticate(); //验证应该先于控件的OnInit事件执行
        }

        protected override void OnInit(EventArgs e)
        {
            base.OnInit(e);
            Initialize();
        }

        /// <summary>
        /// 不要在此方法中操作ViewState
        /// </summary>
        protected virtual void Initialize() { }
        #endregion

    }
}
