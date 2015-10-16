using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.Text;

namespace H.Core.Rest
{
    /// <summary>
    /// 客户端调用Service 方法时会启动，优先级高于 IServiceBehavior
    /// 用户不仅访问方法会调用，访问服务时也会触发
    /// </summary>
    public class RestServiceOperationSelector : IDispatchOperationSelector
    {
        private IDispatchOperationSelector m_Operation;

        public RestServiceOperationSelector(IDispatchOperationSelector endpoint)
        {
            m_Operation = endpoint;
        }

        public string SelectOperation(ref Message message)
        {
            //身份验证
            return m_Operation.SelectOperation(ref message);
        }
    }
}
