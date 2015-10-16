using H.Core.Utility;
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Website.Facade.Facade
{
    public class SystemUser_PrivilegeFacade
    {
        public static List<SystemUser_PrivilegeEntity> Seach(QueryCondition<SystemUser_PrivilegeEntity> entity)
        {
            return RestClient.Post<List<SystemUser_PrivilegeEntity>>("SystemUser_PrivilegeService/Search", entity);
        }

        public static List<SystemUser_PrivilegeEntity> GetALlPrivilege()
        {
            return RestClient.Get<List<SystemUser_PrivilegeEntity>>("SystemUser_PrivilegeService/GetALlPrivilege");
        }

        public static int InsertSystemUser_Privilege(SystemUser_PrivilegeEntity entity)
        {
            return RestClient.Post<int>("SystemUser_PrivilegeService/InsertSystemUser_Privilege", entity);
        }

        public static int UpdateSystemUser_Privilege(SystemUser_PrivilegeEntity entity)
        {
            return RestClient.Post<int>("SystemUser_PrivilegeService/UpdateSystemUser_Privilege", entity);
        }

        public static int DeleteSystemUser_Privilege(string sysno)
        {
            return RestClient.Post<int>("SystemUser_PrivilegeService/DeleteSystemUser_Privilege", sysno);
        }

        public static SystemUser_PrivilegeEntity ByPrivilegeNameGetInfo(SystemUser_PrivilegeEntity entity)
        {
            return RestClient.Post<SystemUser_PrivilegeEntity>("SystemUser_PrivilegeService/ByPrivilegeNameGetInfo", entity);
        }

        public static SystemUser_PrivilegeEntity ByPageAliceGetInfo(SystemUser_PrivilegeEntity entity)
        {
            return RestClient.Post<SystemUser_PrivilegeEntity>("SystemUser_PrivilegeService/ByPageAliceGetInfo", entity);
        }

        public static SystemUser_PrivilegeEntity LoadEntity(int sysNo)
        {
            return RestClient.Post<SystemUser_PrivilegeEntity>("SystemUser_PrivilegeService/LoadEntity", sysNo);
        }

        public static List<SystemUser_PrivilegeEntity> LoadParent() {
            return RestClient.Get<List<SystemUser_PrivilegeEntity>>("SystemUser_PrivilegeService/LoadParent");
        }
    }
}
