using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using H.Website.Facade;
using H.Entity;
using H.Website.Facade.Facade;
using H.Core.Utility;
using System.Text;

namespace H.Portal.IISHost
{
    [AjaxPro.AjaxNamespace("Portal.SystemLogin")]
    public partial class SystemLogin : H.Website.Facade.PageBase
    {
        /// <summary>
        /// 不需登录验证
        /// </summary>
        protected override bool RequireAuth
        {
            get { return false; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (this.LoginUser != null)
                Response.Redirect(BuildUrl(PageAlias.Main));
            AjaxPro.Utility.RegisterTypeForAjax(typeof(SystemLogin));
            string loginUserName = CookieManager.GetValue("LoginUserName");
            if (!string.IsNullOrEmpty(loginUserName))
            {
                che_rem.Checked = true;
                txt_UserName.Value = new EncryHelper().DoDecrypt(loginUserName, WebConfig.ProjectName + WebConfig.InteractionKey, Encoding.UTF8);
            }
            SetNoCache();
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public string Loging(string parms, string userName, string pwd, string rem)
        {
            //登录成功 已Json 格式保存在 Cookie
            SystemUserEntity user = new SystemUserEntity();
            user.UserName = userName.Trim();
            user.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(pwd.Trim(), "MD5");
            if (SystemUserFacade.Login(user))
            {
                if (!string.IsNullOrEmpty(parms))
                    WebContext.SetLoginReturnUrl(parms.Replace("~", ""));

                string returnUrl = BuildUrl(PageAlias.Main);
                returnUrl = returnUrl.IndexOf("~/") > -1 ? returnUrl.Replace("~/", "") : returnUrl;

                //记住用户名
                if (rem == "checked")
                {
                    CookieManager.SetObject("LoginUserName", userName);
                }
                return "{\"Code\": \"OK\"," + "\"Return\": \"" + returnUrl + "\"}";
            }
            return "{\"Code\": \"NO\"," + "\"Message\": \"登陆失败.用户名或密码错误!\"}"; ;
        }


        #region 服务端控件登录
        /// <summary>
        /// 服务端控件登录
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Button1_Click(object sender, EventArgs e)
        {
            //登录成功
            HttpCookie loginCookie = FormsAuthentication.GetAuthCookie("Henry", false);
            HttpContext.Current.Response.Cookies.Add(loginCookie);

            string returnUrl = string.Empty;
            if (!string.IsNullOrEmpty(QueryStringValues.ReturnUrl))
                returnUrl = QueryStringValues.ReturnUrl;
        }
        #endregion
    }
}