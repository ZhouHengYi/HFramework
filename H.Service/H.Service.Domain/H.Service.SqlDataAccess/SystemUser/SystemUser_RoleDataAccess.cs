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
    [VersionExport(typeof(ISystemUser_RoleDataAccess))]
    public class SystemUser_RoleDataAccess : ISystemUser_RoleDataAccess
    {
        public List<SystemUser_RoleEntity> Search(QueryCondition<SystemUser_RoleEntity> entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("SystemUser_RoleSearch");
            using (DynamicSqlBuilder sqlBuilder = new DynamicSqlBuilder(command, entity.PagingInfo, "SysNo Desc"))
            {
                SystemUser_RoleEntity query = entity.Condition;
                sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " Status <> -1");
                if (query != null)
                {
                    if (!string.IsNullOrEmpty(query.RoleName))
                    {
                        sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " (RoleName Like'%'+@RoleName+'%')");
                        command.AddInputParameter("@RoleName", DbType.String, query.RoleName);
                    }
                }
                command.CommandText = sqlBuilder.BuildQuerySql();
                return command.ExecuteEntityList<SystemUser_RoleEntity>();
            }
        }

        public List<SystemUser_RoleEntity> GetAllRole()
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("GetAllRole");
            return command.ExecuteEntityList<SystemUser_RoleEntity>();
        }

        public int InsertSystemUser_Role(SystemUser_RoleEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("InsertSystemUser_Role");
            command.SetParameterValue("@RoleName", entity.RoleName);
            command.SetParameterValue("@Status", entity.Status);
            command.SetParameterValue("@InUser", entity.InUser);
            command.SetParameterValue("@InDate", entity.InDate);
            object obj = command.ExecuteScalar();
            if (obj != null)
            {
                int sysno = Convert.ToInt32(obj);
                ClearSystemUser_Role_Privilege(sysno);
                //添加权限关联
                foreach (var item in entity.PrivilegeList)
                {
                    InsertSystemUser_Role_Privilege(sysno, item.SysNo, entity.InUser);
                }
                return sysno;
            }
            else
                return 0;
        }


        public int UpdateSystemUser_Role(SystemUser_RoleEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("UpdateSystemUser_Role");
            command.SetParameterValue("@SysNo", entity.SysNo);
            command.SetParameterValue("@RoleName", entity.RoleName);
            command.SetParameterValue("@Status", entity.Status);
            command.SetParameterValue("@InUser", entity.InUser);
            command.SetParameterValue("@InDate", entity.InDate);
            int result = command.ExecuteNonQuery();
            //添加权限关联
            ClearSystemUser_Role_Privilege(entity.SysNo);
            foreach (var item in entity.PrivilegeList)
            {
                InsertSystemUser_Role_Privilege(entity.SysNo, item.SysNo, entity.InUser);
            }
            return result;
        }

        public int InsertSystemUser_Role_Privilege(int roleSysNo,int privilegeSysNo,string inUser) {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("InsertSystemUser_Role_Privilege");
            command.SetParameterValue("@RoleSysNo", roleSysNo);
            command.SetParameterValue("@PrivilegeSysNo", privilegeSysNo);
            command.SetParameterValue("@InUser", inUser);
            return command.ExecuteNonQuery();
        }

        public int ClearSystemUser_Role_Privilege(int roleSysNo)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ClearSystemUser_Role_Privilege");
            command.SetParameterValue("@RoleSysNo", roleSysNo);
            return command.ExecuteNonQuery();
        }


        public int DeleteSystemUser_Role(string sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("DeleteSystemUser_Role");
            command.CommandText = command.CommandText.Replace("#SysNo#", sysno);
            return command.ExecuteNonQuery();
        }

        public SystemUser_RoleEntity ByRoleNameGetInfo(SystemUser_RoleEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ByRoleNameGetInfo");
            command.SetParameterValue("@RoleName", entity.RoleName);
            command.SetParameterValue("@SysNo", entity.SysNo);
            SystemUser_RoleEntity result = command.ExecuteEntity<SystemUser_RoleEntity>();
            return result;
        }

        public SystemUser_RoleEntity LoadEntity(int sysNo)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("SystemUser_RoleLoadEntity");
            command.SetParameterValue("@SysNo", sysNo);
            SystemUser_RoleEntity result = command.ExecuteEntity<SystemUser_RoleEntity>();

            CustomDataCommand privilegecommand = DataCommandManager.CreateCustomDataCommandFromConfig("SystemUser_RoleGetPrivilege");
            privilegecommand.SetParameterValue("@SysNo", sysNo);
            result.PrivilegeList = privilegecommand.ExecuteEntityList<SystemUser_PrivilegeEntity>();

            return result;
        }
    }
}
