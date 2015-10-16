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
    public class ErrorLogService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/Search", Method = "POST")]
        public List<ErrorLogEntity> Search(QueryCondition<ErrorLogEntity> entity)
        {
            return ObjectFactory<IErrorLogDataAccess>.Instance.Seach(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/GetDetails/{sysno}", Method = "GET")]
        public ErrorLogEntity GetDetails(string sysno)
        {
            return ObjectFactory<IErrorLogDataAccess>.Instance.GetDetails(sysno);
        }
    }
}
