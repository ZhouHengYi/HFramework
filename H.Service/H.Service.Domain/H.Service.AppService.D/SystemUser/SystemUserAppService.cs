using H.Core.Utility;
using H.Core.Utility.Log;
using H.Entity;
using H.Service.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.AppService
{
    [VersionExport(typeof(SystemUserAppService))]
    public class SystemUserAppService
    {
        public List<SystemUserEntity> Search(QueryCondition<SystemUserEntity> entity)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.Search(entity);
        }

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

        public int SystemUserUpdate(SystemUserEntity entity)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.SystemUserUpdate(entity);
        }

        public int SystemUserDelete(string sysNo)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.SystemUserDelete(sysNo);
        }

        public SystemUserEntity Login(SystemUserEntity entity)
        {            
            return ObjectFactory<ISystemUserDataAccess>.Instance.Login(entity); ;
        }

        public SystemUserEntity ByUserNameGetInfo(string userName)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.ByUserNameGetInfo(userName);
        }

        public SystemUserEntity LoadEntity(string sysNo)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.LoadEntity(sysNo);
        }

        public int UpdatePassword(SystemUserEntity entity)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.UpdatePassword(entity);
        }

        public List<SystemUser_PrivilegeEntity> GetSystemUserPrivilege(int sysno)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.GetSystemUserPrivilege(sysno);
        }

        public List<SystemUser_RoleEntity> GetSystemUserRole(int sysno)
        {
            return ObjectFactory<ISystemUserDataAccess>.Instance.GetSystemUserRole(sysno);
        }
    }
}
