using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.IDataAccess
{
    public interface ISystemUser_PrivilegeDataAccess
    {
        List<SystemUser_PrivilegeEntity> Search(QueryCondition<SystemUser_PrivilegeEntity> entity);

        List<SystemUser_PrivilegeEntity> GetALlPrivilege();

        int InsertSystemUser_Privilege(SystemUser_PrivilegeEntity entity);

        int UpdateSystemUser_Privilege(SystemUser_PrivilegeEntity entity);

        int DeleteSystemUser_Privilege(string sysno);

        SystemUser_PrivilegeEntity ByPrivilegeNameGetInfo(SystemUser_PrivilegeEntity entity);

        SystemUser_PrivilegeEntity ByPageAliceGetInfo(SystemUser_PrivilegeEntity entity);

        SystemUser_PrivilegeEntity LoadEntity(int sysNo);

        List<SystemUser_PrivilegeEntity> LoadParent();
    }
}
