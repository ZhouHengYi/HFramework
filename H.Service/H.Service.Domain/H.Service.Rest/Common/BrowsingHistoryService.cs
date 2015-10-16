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
    public class BrowsingHistoryService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/Search", Method = "POST")]
        public List<BrowsingHistoryEntity> Search(QueryCondition<BrowsingHistoryEntity> entity)
        {
            return ObjectFactory<IBrowsingHistoryDataAccess>.Instance.Search(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/InsertBrowsingHistory", Method = "POST")]
        public int InsertBrowsingHistory(BrowsingHistoryEntity entity)
        {
            return ObjectFactory<IBrowsingHistoryDataAccess>.Instance.InsertBrowsingHistory(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/UpdateBrowsingHistory", Method = "POST")]
        public int UpdateBrowsingHistory(BrowsingHistoryEntity entity)
        {
            return ObjectFactory<IBrowsingHistoryDataAccess>.Instance.UpdateBrowsingHistory(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/DeleteBrowsingHistory", Method = "POST")]
        public int DeleteBrowsingHistory(string sysno)
        {
            return ObjectFactory<IBrowsingHistoryDataAccess>.Instance.DeleteBrowsingHistory(sysno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/BrowsingHistoryBySystemUserSysNo/{systemUserSysno}", Method = "GET")]
        public List<BrowsingHistoryEntity> BrowsingHistoryBySystemUserSysNo(string systemUserSysno)
        {
            return ObjectFactory<IBrowsingHistoryDataAccess>.Instance.BrowsingHistoryBySystemUserSysNo(systemUserSysno);
        }
    }
}
