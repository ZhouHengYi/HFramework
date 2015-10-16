using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using H.Core.Utility;
using H.Entity;
using H.Website.Facade.Facade;

namespace H.Website.IISHost.Page.Report
{
    [AjaxPro.AjaxNamespace("Portal.SalesTop10")]
    public partial class SalesTop10 : H.Website.Facade.PageBase
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
            AjaxPro.Utility.RegisterTypeForAjax(typeof(SalesTop10));
        }

        /// <summary>
        /// 根据时间获取 单品销售TOP10
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public string GetSaleTopReport(string startdate)
        {
            List<SaleTopEntity> result = ExportReportFacade.GetSaleTopReport(startdate);
            return new JsonSerializer().Serialization(result, typeof(List<SaleTopEntity>));
        }

        /// <summary>
        /// 历史单品销售TOP10
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public string GetALLSaleTopReport()
        {
            List<SaleTopEntity> result = ExportReportFacade.GetALLSaleTopReport();
            return new JsonSerializer().Serialization(result, typeof(List<SaleTopEntity>));
        }
    }
}