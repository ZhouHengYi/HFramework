using H.Core.DataAccess;
using H.Core.Utility;
using H.Entity;
using H.Service.IDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace H.Service.SqlDataAccess
{
    [VersionExport(typeof(ISystemUser_PrivilegeDataAccess))]
    public class SystemUser_PrivilegeDataAccess : ISystemUser_PrivilegeDataAccess
    {
        public List<SystemUser_PrivilegeEntity> Search(QueryCondition<SystemUser_PrivilegeEntity> entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("SystemUser_PrivilegeSearch");
            using (DynamicSqlBuilder sqlBuilder = new DynamicSqlBuilder(command, entity.PagingInfo, "SysNo Desc"))
            {
                SystemUser_PrivilegeEntity query = entity.Condition;
                sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " Status <> -1");
                if (query != null)
                {
                    if (!string.IsNullOrEmpty(query.PrivilegeName))
                    {
                        sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " (PrivilegeName Like'%'+@PrivilegeName+'%')");
                        command.AddInputParameter("@PrivilegeName", DbType.String, query.PrivilegeName);
                    } 
                    if (query.DropParentSysNo > -1)
                    {
                        sqlBuilder.Conditions.AddCondition("ParentSysNo", DbType.Int32, "@ParentSysNo", query.DropParentSysNo);
                    }
                }
                command.CommandText = sqlBuilder.BuildQuerySql();
                return command.ExecuteEntityList<SystemUser_PrivilegeEntity>();
            }
        }

        public List<SystemUser_PrivilegeEntity> GetALlPrivilege() {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("GetALlPrivilege");
            return command.ExecuteEntityList<SystemUser_PrivilegeEntity>();
        }

        public int InsertSystemUser_Privilege(SystemUser_PrivilegeEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("InsertSystemUser_Privilege");
            command.SetParameterValue("@PrivilegeName", entity.PrivilegeName);
            command.SetParameterValue("@PageAlice", entity.PageAlice);
            command.SetParameterValue("@ParentSysNo", entity.ParentSysNo);
            command.SetParameterValue("@Status", entity.Status);
            command.SetParameterValue("@InUser", entity.InUser);
            command.SetParameterValue("@InDate", entity.InDate);
            object obj = command.ExecuteScalar();
            if (obj != null)
                return Convert.ToInt32(obj);
            else
                return 0;
        }


        public int UpdateSystemUser_Privilege(SystemUser_PrivilegeEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("UpdateSystemUser_Privilege");
            command.SetParameterValue("@SysNo", entity.SysNo);
            command.SetParameterValue("@PrivilegeName", entity.PrivilegeName);
            command.SetParameterValue("@PageAlice", entity.PageAlice);
            command.SetParameterValue("@ParentSysNo", entity.ParentSysNo);
            command.SetParameterValue("@Status", entity.Status);
            command.SetParameterValue("@InUser", entity.InUser);
            command.SetParameterValue("@InDate", entity.InDate);
            return command.ExecuteNonQuery();
        }


        public int DeleteSystemUser_Privilege(string sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("DeleteSystemUser_Privilege");
            command.CommandText = command.CommandText.Replace("#SysNo#", sysno);
            return command.ExecuteNonQuery();
        }

        public SystemUser_PrivilegeEntity ByPrivilegeNameGetInfo(SystemUser_PrivilegeEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ByPrivilegeNameGetInfo");
            command.SetParameterValue("@PrivilegeName", entity.PrivilegeName);
            command.SetParameterValue("@SysNo", entity.SysNo);
            SystemUser_PrivilegeEntity result = command.ExecuteEntity<SystemUser_PrivilegeEntity>();
            return result;
        }

        public SystemUser_PrivilegeEntity ByPageAliceGetInfo(SystemUser_PrivilegeEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ByPageAliceGetInfo");
            command.SetParameterValue("@PageAlice", entity.PageAlice);
            command.SetParameterValue("@SysNo", entity.SysNo);
            SystemUser_PrivilegeEntity result = command.ExecuteEntity<SystemUser_PrivilegeEntity>();
            return result;
        }

        public SystemUser_PrivilegeEntity LoadEntity(int sysNo)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("SystemUser_PrivilegeLoadEntity");
            command.SetParameterValue("@SysNo", sysNo);
            SystemUser_PrivilegeEntity result = command.ExecuteEntity<SystemUser_PrivilegeEntity>();
            return result;
        }

        public List<SystemUser_PrivilegeEntity> LoadParent() {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("SystemUser_PrivilegeLoadParent");
            List<SystemUser_PrivilegeEntity> result = command.ExecuteEntityList<SystemUser_PrivilegeEntity>();
            return result;
        }
    }
}
