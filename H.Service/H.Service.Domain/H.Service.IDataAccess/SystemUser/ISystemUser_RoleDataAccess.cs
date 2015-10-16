
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.IDataAccess
{
    /// <summary>
    /// SystemUser_RoleInterface
    /// </summary>
    public interface ISystemUser_RoleDataAccess
    {
        List<SystemUser_RoleEntity> Search(QueryCondition<SystemUser_RoleEntity> entity);

        List<SystemUser_RoleEntity> GetAllRole();

        int InsertSystemUser_Role(SystemUser_RoleEntity entity);

        int UpdateSystemUser_Role(SystemUser_RoleEntity entity);

        int DeleteSystemUser_Role(string sysno);

        SystemUser_RoleEntity ByRoleNameGetInfo(SystemUser_RoleEntity entity);

        SystemUser_RoleEntity LoadEntity(int sysNo);
    }
}

