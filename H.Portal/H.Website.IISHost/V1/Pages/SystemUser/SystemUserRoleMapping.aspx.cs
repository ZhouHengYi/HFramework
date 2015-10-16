using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using H.Website.Facade;
using H.Entity;
using H.Website.Facade.Facade;

namespace H.Website.IISHost.Pages.SystemUser
{
    [AjaxPro.AjaxNamespace("Portal.SystemUserRoleMapping")]
    public partial class SystemUserRoleMapping : H.Website.Facade.PageBase
    {

        protected override void Initialize()
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(SystemUserRoleMapping));
        }

        /// <summary>
        /// 创建
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public int Submit(SystemUserEntity obj)
        {
            obj.InDate = DateTime.Now;
            obj.InUser = WebContext.LoginUser.UserName;
            obj.Status = 0;
            return SystemUserFacade.SystemUserUpdate(obj);
        }

        /// <summary>
        /// 根据系统编号获取用户信息
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public SystemUserEntity LoadEntity(string sysNo)
        {
            int SysNo;
            int.TryParse(sysNo, out SysNo);
            SystemUserEntity entity = SystemUserFacade.LoadEntity(SysNo);
            return entity;
        }
    }
}