using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using H.Core.Utility;
using H.Entity;
using H.Core.Utility.Log;
using H.Service.IDataAccess;

namespace H.Service.Rest
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public class LogService
    {
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/CreateLog", Method = "POST")]
        public void Log(LogEntry log)
        {
            ObjectFactory<ILogDataAccess>.Instance.Log(log);
        }
    }
}
