using H.Core.Utility;
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Website.Facade.Facade
{
    public class SystemUser_RoleFacade
    {
        public static List<SystemUser_RoleEntity> Seach(QueryCondition<SystemUser_RoleEntity> entity)
        {
            return RestClient.Post<List<SystemUser_RoleEntity>>("SystemUser_RoleService/Search", entity);
        }

        public static List<SystemUser_RoleEntity> GetAllRole() {
            return RestClient.Get<List<SystemUser_RoleEntity>>("SystemUser_RoleService/GetAllRole");
        }

        public static int InsertSystemUser_Role(SystemUser_RoleEntity entity)
        {
            return RestClient.Post<int>("SystemUser_RoleService/InsertSystemUser_Role", entity);
        }

        public static int UpdateSystemUser_Role(SystemUser_RoleEntity entity)
        {
            return RestClient.Post<int>("SystemUser_RoleService/UpdateSystemUser_Role", entity);
        }

        public static int DeleteSystemUser_Role(string sysno)
        {
            return RestClient.Post<int>("SystemUser_RoleService/DeleteSystemUser_Role", sysno);
        }

        public static SystemUser_RoleEntity ByRoleNameGetInfo(SystemUser_RoleEntity entity)
        {
            return RestClient.Post<SystemUser_RoleEntity>("SystemUser_RoleService/ByRoleNameGetInfo", entity);
        }

        public static SystemUser_RoleEntity LoadEntity(int sysNo)
        {
            return RestClient.Post<SystemUser_RoleEntity>("SystemUser_RoleService/LoadEntity", sysNo);
        }

    }
}
