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
    public class ManagementService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/Search", Method = "POST")]
        public List<ManagementEntity> Search(QueryCondition<ManagementEntity> entity)
        {
            return ObjectFactory<IManagementDataAccess>.Instance.Search(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/InsertManagement", Method = "POST")]
        public int InsertManagement(ManagementEntity entity)
        {
            return ObjectFactory<IManagementDataAccess>.Instance.InsertManagement(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/UpdateManagement", Method = "POST")]
        public int UpdateManagement(ManagementEntity entity)
        {
            return ObjectFactory<IManagementDataAccess>.Instance.UpdateManagement(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/DeleteManagement", Method = "POST")]
        public int DeleteManagement(string sysno)
        {
            return ObjectFactory<IManagementDataAccess>.Instance.DeleteManagement(sysno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/LoadEntity/{SysNo}", Method = "GET")]
        public ManagementEntity LoadEntity(string sysno)
        {
            return ObjectFactory<IManagementDataAccess>.Instance.LoadEntity(sysno);
        }
    }
}
