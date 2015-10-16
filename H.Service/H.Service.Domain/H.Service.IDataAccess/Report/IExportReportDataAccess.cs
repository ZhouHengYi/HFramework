using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using H.Entity;

namespace H.Service.IDataAccess
{
    public interface IExportReportDataAccess
    {
        /// <summary>
        /// 单品销售TOP10
        /// </summary>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        List<SaleTopEntity> GetSaleTopReport(string startdate, string enddate);

        /// <summary>
        /// 历史单品销售TOP10
        /// </summary>
        /// <returns></returns>
        List<SaleTopEntity> GetALLSaleTopReport();
    }
}
