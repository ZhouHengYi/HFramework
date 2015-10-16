using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using H.Core.Utility;

namespace H.Core.Rest
{
    /// <summary>
    /// RestWebService启动类，继承IStartup统一接口.方便服务启动时在自定义Config中定义
    /// </summary>
    public class RestWebServiceStartup : IStartup
    {
        private string m_CustomBizExceptionTypeName;

        public RestWebServiceStartup()
            : this(null)
        {

        }

        public RestWebServiceStartup(string customBizExceptionTypeName)
        {
            m_CustomBizExceptionTypeName = customBizExceptionTypeName;
        }

        public void Start()
        {
            RestWebServiceHost.Open(m_CustomBizExceptionTypeName);
        }
    }
}
