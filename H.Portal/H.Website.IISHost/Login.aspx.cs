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
using System.Security.Principal;
using System.Configuration;

namespace H.Website.IISHost
{
    [AjaxPro.AjaxNamespace("Portal.Login")]
    public partial class Login : H.Website.Facade.PageBase
    {
        /// <summary>
        /// 不需登录验证
        /// </summary>
        protected override bool RequireAuth
        {
            get { return false; }
        }

        protected string UserName
        {
            get
            {
                WindowsPrincipal wp = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                string[] logon = wp.Identity.Name.Split('\\');
                string UserName = logon[1].ToString().ToLower();//登陆名;
                return UserName;
            }
        }

        protected string UserDomain
        {
            get
            {
                WindowsPrincipal wp = new WindowsPrincipal(WindowsIdentity.GetCurrent());
                string[] logon = wp.Identity.Name.Split('\\');
                string UserDomain = logon[0];//网域
                return UserDomain;
            }
        }

        protected string ComputerName
        {
            get{
                return Server.MachineName;
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.Title = ConfigurationManager.AppSettings["WebSiteTitle"];
            if (this.LoginUser != null)
                Response.Redirect(BuildUrl(PageAlias.SystemUser));
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Login));

            //txt_LoginName.Value = UserName;
            //txt_NewLoginName.Value = UserName;
            //txt_Email.Value = UserName + "@hearst.com.cn";

            string loginUserName = CookieManager.GetValue("HenryProjectLoginUserName");
            if (!string.IsNullOrEmpty(loginUserName)) { txt_LoginName.Value = new EncryHelper().DoDecrypt(loginUserName, WebConfig.ProjectName + WebConfig.InteractionKey, Encoding.UTF8); }

            SetNoCache();
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public string Register(string newLogin, string email)
        {
            SystemUserEntity entity = new SystemUserEntity()
            {
                //Email = email + "@hearst.com.cn",
                UserName = newLogin,
                Email = email,
                Password = "escenter",
                LastLoginDate = DateTime.Now,
                Role = new List<SystemUser_RoleEntity>(),
                Privilege = new List<SystemUser_PrivilegeEntity>(),
                Status = 0,
                InUser = "Login",
                InDate = DateTime.Now
            };
            if (SystemUserFacade.SystemUserInsert(entity) > 0)
            {
                return "{\"Code\": \"OK\"," + "\"Message\": \"发送成功,请注意接收邮箱!\"}";
            }
            else
            {
                return "{\"Code\": \"NO\"," + "\"Message\": \"请勿重复注册!\"}";
            }
        }

        [AjaxPro.AjaxMethod(AjaxPro.HttpSessionStateRequirement.ReadWrite)]
        public string Loging(string loginName,string pwd)
        {
            SystemUserEntity entity = new SystemUserEntity()
            {
                UserName = loginName,
                Password = pwd,
                LastLoginDate = DateTime.Now
            };
            CookieManager.SetObject("HenryProjectLoginUserName", loginName);
            if (SystemUserFacade.Login(entity))
            {
                return "{\"Code\": \"OK\"," + "\"Return\": \"" + BuildUrl(PageAlias.SystemUser) + "\"}";
            }
            else
            {
                return "{\"Code\": \"NO\"," + "\"Message\": \"登陆失败.用户名或密码错误!\"}";
            }
        }
    }
}