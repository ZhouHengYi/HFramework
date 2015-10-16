
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
    /// <summary>
    /// SystemUser_RoleService
    /// </summary>
    [VersionExport(typeof(SystemUser_RoleAppService))]
    public class SystemUser_RoleAppService
    {
        public List<SystemUser_RoleEntity> Search(QueryCondition<SystemUser_RoleEntity> entity)
        {
            return ObjectFactory<ISystemUser_RoleDataAccess>.Instance.Search(entity);
        }

        public List<SystemUser_RoleEntity> GetAllRole()
        {
            return ObjectFactory<ISystemUser_RoleDataAccess>.Instance.GetAllRole();
        }

        public int InsertSystemUser_Role(SystemUser_RoleEntity entity)
        {
            return ObjectFactory<ISystemUser_RoleDataAccess>.Instance.InsertSystemUser_Role(entity);
        }

        public int UpdateSystemUser_Role(SystemUser_RoleEntity entity)
        {
            return ObjectFactory<ISystemUser_RoleDataAccess>.Instance.UpdateSystemUser_Role(entity);
        }

        public int DeleteSystemUser_Role(string sysno)
        {
            return ObjectFactory<ISystemUser_RoleDataAccess>.Instance.DeleteSystemUser_Role(sysno);
        }

        public SystemUser_RoleEntity ByRoleNameGetInfo(SystemUser_RoleEntity entity)
        {
            return ObjectFactory<ISystemUser_RoleDataAccess>.Instance.ByRoleNameGetInfo(entity);
        }

        public SystemUser_RoleEntity LoadEntity(int sysNo)
        {
            return ObjectFactory<ISystemUser_RoleDataAccess>.Instance.LoadEntity(sysNo);
        }
    }
}

