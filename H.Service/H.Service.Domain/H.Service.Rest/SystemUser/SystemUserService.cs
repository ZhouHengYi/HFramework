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
    public class SystemUserService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/Search", Method = "POST")]
        public List<SystemUserEntity> Search(QueryCondition<SystemUserEntity> entity)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.Search(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/SystemUserInsert", Method = "POST")]
        public int SystemUserInsert(SystemUserEntity entity)
        {
            //检查用户是否存在
            SystemUserEntity cheEntity = ObjectFactory<ISystemUserDataAccess>.Instance.ByUserNameGetInfo(entity.UserName);
            if (cheEntity == null || cheEntity.SysNo == 0)
            {
                return ObjectFactory<ISystemUserDataAccess>.Instance.SystemUserInsert(entity);
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/SystemUserUpdate", Method = "POST")]
        public int SystemUserUpdate(SystemUserEntity entity)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.SystemUserUpdate(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/SystemUserDelete", Method = "POST")]
        public int SystemUserDelete(string sysNo)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.SystemUserDelete(sysNo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/Login", Method = "POST")]
        public SystemUserEntity Login(SystemUserEntity entity)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.Login(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/ByUserNameGetInfo", Method = "POST")]
        public SystemUserEntity ByUserNameGetInfo(string userName)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.ByUserNameGetInfo(userName);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/LoadEntity/{sysNo}", Method = "GET")]
        public SystemUserEntity LoadEntity(string sysNo)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.LoadEntity(sysNo);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/UpdatePassword", Method = "POST")]
        public int UpdatePassword(SystemUserEntity entity)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.UpdatePassword(entity);
        }

        /// <summary>
        /// 获取系统用户所有权限
        /// </summary>
        /// <param name="sysno"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/GetSystemUserPrivilege", Method = "POST")]
        public List<SystemUser_PrivilegeEntity> GetSystemUserPrivilege(int sysno)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.GetSystemUserPrivilege(sysno);
        }

        /// <summary>
        /// 获取系统用户所有角色
        /// </summary>
        /// <param name="sysno"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/GetSystemUserRole", Method = "POST")]
        public List<SystemUser_RoleEntity> GetSystemUserRole(int sysno)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.GetSystemUserRole(sysno);
        }
    }
}
