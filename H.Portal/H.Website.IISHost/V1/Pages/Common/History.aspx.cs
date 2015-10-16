using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using H.Website.Facade;

namespace H.Portal.IISHost.Pages.Common
{
    public partial class History : PageBase
    {
        /// <summary> 
        /// 不需要权限验证
        /// </summary>
        protected override bool RequirePermissionAuth
        {
            get { return false; }
        }

        protected override void Initialize()
        {
            //加载浏览历史记录
        }
    }
}