using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using H.Entity;
using H.Core.Utility;
using H.Core.Utility.Log;

namespace H.Website.Facade
{
    public class LogFacade
    {
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="log"></param>
        public static void Log(LogEntry log)
        {
            RestClient.Post<LogEntry>("LogService/CreateLog", log);
        }

        public static void ErrorToBizException()
        {
            RestClient.Get<LogEntry>("ErrorService/ErrorToBizException");
        }

        public static void ErrorToApplicationException()
        {
            RestClient.Get<LogEntry>("ErrorService/ErrorToApplicationException");
        }

        public static void TsstMethod() {
            var a = RestClient.Get<List<string>>("ErrorService/TestMethod");
        }
    }
}
