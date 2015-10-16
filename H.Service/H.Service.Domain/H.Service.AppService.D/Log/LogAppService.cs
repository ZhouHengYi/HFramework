using H.Core.Utility;
using H.Core.Utility.Log;
using H.Service.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.AppService
{
    [VersionExport(typeof(LogAppService))]
    public class LogAppService
    {
        public void Log(LogEntry log)
        {
            ObjectFactory<ILogDataAccess>.Instance.Log(log);
        }
    }
}
