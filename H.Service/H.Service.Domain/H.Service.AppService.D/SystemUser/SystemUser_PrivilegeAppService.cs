
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
    /// SystemUser_PrivilegeService
    /// </summary>
    [VersionExport(typeof(SystemUser_PrivilegeAppService))]
    public class SystemUser_PrivilegeAppService
    {
        public List<SystemUser_PrivilegeEntity> Search(QueryCondition<SystemUser_PrivilegeEntity> entity)
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.Search(entity);
        }

        public List<SystemUser_PrivilegeEntity> GetALlPrivilege()
        { 
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.GetALlPrivilege();
        }

        public int InsertSystemUser_Privilege(SystemUser_PrivilegeEntity entity)
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.InsertSystemUser_Privilege(entity);
        }

        public int UpdateSystemUser_Privilege(SystemUser_PrivilegeEntity entity)
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.UpdateSystemUser_Privilege(entity);
        }

        public int DeleteSystemUser_Privilege(string sysno)
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.DeleteSystemUser_Privilege(sysno);
        }

        public SystemUser_PrivilegeEntity ByPrivilegeNameGetInfo(SystemUser_PrivilegeEntity entity)
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.ByPrivilegeNameGetInfo(entity);
        }

        public SystemUser_PrivilegeEntity ByPageAliceGetInfo(SystemUser_PrivilegeEntity entity)
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.ByPageAliceGetInfo(entity);
        }

        public SystemUser_PrivilegeEntity LoadEntity(int sysNo)
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.LoadEntity(sysNo);
        }

        public List<SystemUser_PrivilegeEntity> LoadParent()
        {
            return ObjectFactory<ISystemUser_PrivilegeDataAccess>.Instance.LoadParent();
        }
    }
}

