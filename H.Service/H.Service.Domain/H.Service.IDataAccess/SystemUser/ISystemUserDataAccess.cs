using H.Core.Utility.Log;
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.IDataAccess
{
    public interface ISystemUserDataAccess
    {
        List<SystemUserEntity> Search(QueryCondition<SystemUserEntity> entity);

        int SystemUserInsert(SystemUserEntity entity);

        int SystemUserUpdate(SystemUserEntity entity);

        int SystemUserDelete(string sysNo);

        SystemUserEntity Login(SystemUserEntity entity);

        SystemUserEntity ByUserNameGetInfo(string userName);

        SystemUserEntity LoadEntity(string sysNo);

        int UpdatePassword(SystemUserEntity entity);

        List<SystemUser_PrivilegeEntity> GetSystemUserPrivilege(int sysno);

        List<SystemUser_RoleEntity> GetSystemUserRole(int sysno);
    }
}
