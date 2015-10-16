using H.Core.Utility.Log;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.IDataAccess
{
    public interface ILogDataAccess
    {
        void Log(LogEntry log);
    }
}
