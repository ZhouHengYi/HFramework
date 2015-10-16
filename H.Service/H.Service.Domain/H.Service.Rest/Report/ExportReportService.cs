using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using H.Core.Utility;
using H.Entity;
using H.Service.IDataAccess;

namespace H.Service.Rest
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public class ExportReportService
    {
        /// <summary>
        /// 单品销售TOP10
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/GetSaleTopReport/{startdate}", Method = "GET", ResponseFormat = WebMessageFormat.Json)]
        public List<SaleTopEntity> GetSaleTopReport(string startdate)
        {
            DateTime start = Convert.ToDateTime(startdate + "-01");
            return ObjectFactory<IExportReportDataAccess>.Instance.GetSaleTopReport(start.ToString("yyyy-MM-dd"),
                    start.AddMonths(1).ToString("yyyy-MM-dd"));
        }

        /// <summary>
        /// 历史单品销售TOP10
        /// 缓存1小时
        /// </summary>
        /// <returns></returns>
        [WebGet(UriTemplate = "/GetALLSaleTopReport")]
        [AspNetCacheProfile("CacheFor3600Seconds")] 
        public List<SaleTopEntity> GetALLSaleTopReport()
        {
            return ObjectFactory<IExportReportDataAccess>.Instance.GetALLSaleTopReport();
        }
    }
}
