using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using H.Website.Facade;

namespace H.Portal.IISHost.Pages.Common
{
    [AjaxPro.AjaxNamespace("Portal.Dashboard")]
    public partial class Dashboard : PageBase
    {
        /// <summary> 
        /// 不需要权限验证
        /// </summary>
        protected override bool RequirePermissionAuth
        {
            get { return false; }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Dashboard));
            //SELECT TOP 100 * FROM IPP3.dbo.VendorUser WITH(NOLOCK)
            //--权限
            //SELECT TOP 100 * FROM IPP3.dbo.VendorUser_Privilege WITH(NOLOCK)
            //--角色
            //SELECT TOP 100 * FROM IPP3.dbo.VendorUser_Role WITH(NOLOCK)
            //--角色与权限
            //SELECT TOP 100 * FROM IPP3.dbo.VendorUser_Role_Privilege WITH(NOLOCK)
            //--用户与角色
            //SELECT TOP 100 * FROM IPP3.dbo.VendorUser_RoleMapping WITH(NOLOCK)
        }

        /// <summary>
        /// 退出登录
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public string LoginOut() {
            WebContext.SignOut();
            string retHtml = "{\"Code\": \"OK\"," + "\"Return\": \"" + UrlHelper.BuildUrl(PageAlias.SystemLogin) + "\"}";
            return retHtml;
        }
    }
}