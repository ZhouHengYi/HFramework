
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.IDataAccess
{
    /// <summary>
    /// 错误日志表Interface
    /// </summary>
    public interface IErrorLogDataAccess
    {
        List<ErrorLogEntity> Seach(QueryCondition<ErrorLogEntity> entity);

        ErrorLogEntity GetDetails(string sysno);
    }
}

