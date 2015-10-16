
using H.Core.DataAccess;
using H.Core.Utility;
using H.Entity;
using H.Service.IDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace H.Service.SqlDataAccess
{
    [VersionExport(typeof(IExportReportDataAccess))]
    public class ExportReportDataAccess : IExportReportDataAccess
    {
        /// <summary>
        /// 单品销售TOP10
        /// </summary>
        /// <param name="startdate"></param>
        /// <param name="enddate"></param>
        /// <returns></returns>
        public List<SaleTopEntity> GetSaleTopReport(string startdate, string enddate)
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("GetSaleTopReport");
            cmd.SetParameterValue("@STARTDATE", startdate);
            cmd.SetParameterValue("@ENDDATE", enddate);
            return cmd.ExecuteEntityList<SaleTopEntity>();
        }

        /// <summary>
        /// 历史单品销售TOP10
        /// </summary>
        /// <returns></returns>
        public List<SaleTopEntity> GetALLSaleTopReport()
        {
            DataCommand cmd = DataCommandManager.GetDataCommand("GetALLSaleTopReport");
            return cmd.ExecuteEntityList<SaleTopEntity>();
        }
    }
}
