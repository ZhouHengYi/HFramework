using H.Entity;
using H.Website.Facade.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H.Website.IISHost.Pages.Common
{
    [AjaxPro.AjaxNamespace("Portal.ErrorLogDetails")]
    public partial class ErrorLogDetails : H.Website.Facade.PageBase
    {
        protected override void Initialize()
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(ErrorLogDetails));
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public ErrorLogEntity GetDetails(string sysno)
        {
            int SysNo;
            int.TryParse(sysno,out SysNo);
            return ErrorLogFacade.GetDetails(SysNo);
        }
    }
}