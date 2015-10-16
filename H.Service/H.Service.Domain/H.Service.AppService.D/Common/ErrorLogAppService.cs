
using H.Core.Utility;
using H.Core.Utility.Log;
using H.Entity;
using H.Service.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.AppService
{
    /// <summary>
    /// 错误日志表Service
    /// </summary>
    [VersionExport(typeof(ErrorLogAppService))]
    public class ErrorLogAppService
    {
        public List<ErrorLogEntity> Seach(QueryCondition<ErrorLogEntity> entity)
        {
            return ObjectFactory<IErrorLogDataAccess>.Instance.Seach(entity);
        }

        public ErrorLogEntity GetDetails(string sysno)
        {
            return ObjectFactory<IErrorLogDataAccess>.Instance.GetDetails(sysno);
        }
    }
}

