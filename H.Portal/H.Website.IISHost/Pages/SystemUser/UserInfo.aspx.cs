using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using H.Website.Facade;
using H.Entity;
using H.Website.Facade.Facade;

namespace H.Website.IISHost.Page
{
    [AjaxPro.AjaxNamespace("Portal.UpdatePassword")]
    public partial class UserInfo : H.Website.Facade.PageBase
    {
        /// <summary>
        /// 不需登录验证
        /// </summary>
        protected override bool RequireAuth
        {
            get { return true; }
        }

        protected override void Initialize()
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(UserInfo));
            txt_UserName.Value = WebContext.LoginUser.UserName;
            txt_Email.Value = WebContext.LoginUser.Email;
        }
        
        /// <summary>
        /// 根据系统编号获取用户信息
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public SystemUserEntity LoadEntity()
        {
            SystemUserEntity entity = SystemUserFacade.LoadEntity(WebContext.LoginUser.SysNo);
            return entity;
        }

        /// <summary>
        /// 验证密码是否输入正确
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public int ValidatePassword(string oldPassword)
        {
            SystemUserEntity entity = SystemUserFacade.LoadEntity(WebContext.LoginUser.SysNo);
            if (entity != null && entity.SysNo > 0)
            {
                //oldPassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(oldPassword, "MD5");
                if (oldPassword == entity.Password)
                    return 1;
                else
                    return 0;
            }
            else
                return 0;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public int UpdatePasswordMethod(SystemUserEntity entity)
        {
            SystemUserEntity resultEntity = SystemUserFacade.LoadEntity(WebContext.LoginUser.SysNo);
            if (resultEntity != null && resultEntity.SysNo > 0)
            {
                //string oldPassword = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(entity.OldPassword, "MD5");
                string oldPassword = entity.OldPassword;
                if (oldPassword == resultEntity.Password)
                {
                    entity.SysNo = WebContext.LoginUser.SysNo;
                    entity.UserName = resultEntity.UserName;
                    //entity.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(entity.Password, "MD5");
                    return SystemUserFacade.UpdatePassword(entity);
                }
                else
                    return 0;
            }
            else
                return 0;
        }
    }
}