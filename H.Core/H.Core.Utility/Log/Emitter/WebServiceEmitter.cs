using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Core.Utility.Log
{
    internal class WebServiceEmitter : ILogEmitter
    {
        private string m_ServiceAddress;

        public void Init(string configParam)
        {
            m_ServiceAddress = configParam;
        }

        /// <summary>
        /// 调用REST 服务记录日志到数据库
        /// </summary>
        /// <param name="log"></param>
        public void EmitLog(LogEntry log)
        {
            RestClient.Post<LogEntry>(m_ServiceAddress, log);
        }
    }
}
