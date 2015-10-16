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

namespace H.Service.Rest
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public class ErrorService
    {
        [WebInvoke(UriTemplate = "/ErrorToBizException", Method = "GET", RequestFormat = WebMessageFormat.Json)]
        public Log ErrorToBizException()
        {
            throw new BizException("测试自定义错误");
        }

        [WebInvoke(UriTemplate = "/ErrorToApplicationException", Method = "GET", RequestFormat = WebMessageFormat.Json)]
        public Log ErrorToApplicationException()
        {
            throw new ApplicationException("测试系统错误");
        }

        [WebInvoke(UriTemplate = "/TestMethod", Method = "GET")]
        public List<string> TestMethod() {
            List<string> list = new List<string>();
            list.Add("1");
            list.Add("2");
            list.Add("3");
            list.Add("4");
            list.Add("5");
            return list;
        }
    }
}
