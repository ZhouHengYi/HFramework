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
    public class SystemUser_RoleService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/Search", Method = "POST")]
        public List<SystemUser_RoleEntity> Search(QueryCondition<SystemUser_RoleEntity> entity)
        {
            return ObjectFactory<ISystemUser_RoleDataAccess>.Instance.Search(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/GetAllRole", Method = "GET")]
        public List<SystemUser_RoleEntity> GetAllRole()
        {
            return ObjectFactory<ISystemUser_RoleDataAccess>.Instance.GetAllRole();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/InsertSystemUser_Role", Method = "POST")]
        public int InsertSystemUser_Role(SystemUser_RoleEntity entity)
        {
            return ObjectFactory<ISystemUser_RoleDataAccess>.Instance.InsertSystemUser_Role(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/UpdateSystemUser_Role", Method = "POST")]
        public int UpdateSystemUser_Role(SystemUser_RoleEntity entity)
        {
            return ObjectFactory<ISystemUser_RoleDataAccess>.Instance.UpdateSystemUser_Role(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/DeleteSystemUser_Role", Method = "POST")]
        public int DeleteSystemUser_Role(string sysno)
        {
            return ObjectFactory<ISystemUser_RoleDataAccess>.Instance.DeleteSystemUser_Role(sysno);
        }

        [WebInvoke(UriTemplate = "/ByPrivilegeNameGetInfo", Method = "POST")]
        public SystemUser_RoleEntity ByRoleNameGetInfo(SystemUser_RoleEntity entity)
        {
            return ObjectFactory<ISystemUser_RoleDataAccess>.Instance.ByRoleNameGetInfo(entity);
        }

        [WebInvoke(UriTemplate = "/LoadEntity", Method = "POST")]
        public SystemUser_RoleEntity LoadEntity(int sysNo)
        {
            return ObjectFactory<ISystemUser_RoleDataAccess>.Instance.LoadEntity(sysNo);
        }
    }
}
