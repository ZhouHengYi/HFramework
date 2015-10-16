using H.Core.Utility;
using H.Entity;
using H.Website.Facade;
using H.Website.Facade.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H.Website.IISHost.Pages.Common
{
    [AjaxPro.AjaxNamespace("Portal.ErrorLog")]
    public partial class ErrorLog : H.Website.Facade.PageBase
    {
        protected override void Initialize()
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(ErrorLog));
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public string Search(QueryCondition<ErrorLogEntity> query)
        {
            List<ErrorLogEntity> list = ErrorLogFacade.Seach(query);
            return new JsonSerializer().Serialization(list, typeof(List<ErrorLogEntity>));
        }
    }
}