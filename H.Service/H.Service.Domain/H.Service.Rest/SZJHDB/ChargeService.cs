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
    public class ChargeService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/Search", Method = "POST")]
        public List<ChargeEntity> Search(QueryCondition<ChargeEntity> entity)
        {
            return ObjectFactory<IChargeDataAccess>.Instance.Search(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/InsertCharge", Method = "POST")]
        public int InsertCharge(ChargeEntity entity)
        {
            return ObjectFactory<IChargeDataAccess>.Instance.InsertCharge(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/UpdateCharge", Method = "POST")]
        public int UpdateCharge(ChargeEntity entity)
        {
            return ObjectFactory<IChargeDataAccess>.Instance.UpdateCharge(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/DeleteCharge", Method = "POST")]
        public int DeleteCharge(string sysno)
        {
            return ObjectFactory<IChargeDataAccess>.Instance.DeleteCharge(sysno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/LoadEntity/{SysNo}", Method = "GET")]
        public ChargeEntity LoadEntity(string sysno)
        {
            return ObjectFactory<IChargeDataAccess>.Instance.LoadEntity(sysno);
        }
    }
}
