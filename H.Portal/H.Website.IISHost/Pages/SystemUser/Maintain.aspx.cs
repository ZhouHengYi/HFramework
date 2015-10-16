using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using H.Website.Facade;
using H.Entity;
using H.Website.Facade.Facade;
using H.Core.Utility;


namespace H.Website.IISHost.Pages.SystemUser
{
    [AjaxPro.AjaxNamespace("Portal.Maintain")]
    public partial class Maintain : H.Website.Facade.PageBase
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
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Maintain));
        }

        /// <summary>
        /// 创建
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public int Create(SystemUserEntity obj)
        {
            obj.InDate = DateTime.Now;
            obj.InUser = WebContext.LoginUser.UserName;
            obj.Status = 0;
            obj.Password = System.Web.Security.FormsAuthentication.HashPasswordForStoringInConfigFile(obj.Password, "MD5");
            return SystemUserFacade.SystemUserInsert(obj);
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public int ByUserNameGetInfo(string userName)
        {
            SystemUserEntity cheEntity = SystemUserFacade.ByUserNameGetInfo(userName);
            if (cheEntity == null || cheEntity.SysNo == 0)
            {
                return 1;
            }
            return 0;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public SystemUserEntity LoadEntity(int sysNo)
        {
            SystemUserEntity resultEntity = SystemUserFacade.LoadEntity(sysNo);
            return resultEntity;
        }
    }
}