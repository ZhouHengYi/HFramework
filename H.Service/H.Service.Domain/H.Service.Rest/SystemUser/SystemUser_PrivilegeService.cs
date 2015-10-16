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
    public class SystemUser_PrivilegeService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/Search", Method = "POST")]
        public List<SystemUser_PrivilegeEntity> Search(QueryCondition<SystemUser_PrivilegeEntity> entity)
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.Search(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/GetALlPrivilege", Method = "GET")]
        public List<SystemUser_PrivilegeEntity> GetALlPrivilege()
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.GetALlPrivilege();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/InsertSystemUser_Privilege", Method = "POST")]
        public int InsertSystemUser_Privilege(SystemUser_PrivilegeEntity entity)
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.InsertSystemUser_Privilege(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/UpdateSystemUser_Privilege", Method = "POST")]
        public int UpdateSystemUser_Privilege(SystemUser_PrivilegeEntity entity)
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.UpdateSystemUser_Privilege(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/DeleteSystemUser_Privilege", Method = "POST")]
        public int DeleteSystemUser_Privilege(string sysno)
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.DeleteSystemUser_Privilege(sysno);
        }

        [WebInvoke(UriTemplate = "/ByPrivilegeNameGetInfo", Method = "POST")]
        public SystemUser_PrivilegeEntity ByPrivilegeNameGetInfo(SystemUser_PrivilegeEntity entity)
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.ByPrivilegeNameGetInfo(entity);
        }

        [WebInvoke(UriTemplate = "/ByPageAliceGetInfo", Method = "POST")]
        public SystemUser_PrivilegeEntity ByPageAliceGetInfo(SystemUser_PrivilegeEntity entity)
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.ByPageAliceGetInfo(entity);
        }

        [WebInvoke(UriTemplate = "/LoadEntity", Method = "POST")]
        public SystemUser_PrivilegeEntity LoadEntity(int sysNo)
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.LoadEntity(sysNo);
        }

        [WebInvoke(UriTemplate = "/LoadParent", Method = "GET")]
        public List<SystemUser_PrivilegeEntity> LoadParent() {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.LoadParent();
        }
    }
}
