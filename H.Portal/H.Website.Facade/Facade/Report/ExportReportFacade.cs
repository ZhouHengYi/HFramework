using H.Core.Utility;
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Website.Facade.Facade
{
    public class ExportReportFacade
    {
        /// <summary>
        /// 根据时间获取 单品销售TOP10
        /// </summary>
        /// <param name="beginDate"></param>
        /// <returns></returns>
        public static List<SaleTopEntity> GetSaleTopReport(string startdate)
        {
            List<SaleTopEntity> result = RestClient.Get<List<SaleTopEntity>>("ExportReportService/GetSaleTopReport/" + startdate, "http://rest.elleshop.com.cn/");
            return result;
        }

        /// <summary>
        /// 历史单品销售TOP10
        /// 缓存1小时
        /// </summary>
        /// <returns></returns>
        public static List<SaleTopEntity> GetALLSaleTopReport()
        {
            List<SaleTopEntity> result = RestClient.Get<List<SaleTopEntity>>("ExportReportService/GetALLSaleTopReport", "http://rest.elleshop.com.cn/");
            return result;
        }
    }
}
