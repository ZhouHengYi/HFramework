using H.Core.DataAccess;
using H.Core.Utility;
using H.Entity;
using H.Service.IDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace H.Service.SqlDataAccess.SystemUser
{
    [VersionExport(typeof(ISystemUserDataAccess))]
    public class SystemUserDataAccess : ISystemUserDataAccess
    {
        public List<SystemUserEntity> Search(QueryCondition<SystemUserEntity> entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("SystemUserSearch");
            using (DynamicSqlBuilder sqlBuilder = new DynamicSqlBuilder(command, entity.PagingInfo, "SysNo Desc"))
            {
                SystemUserEntity query = entity.Condition;
                sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " Status <> -1");
                if (query != null)
                {
                    if (!string.IsNullOrEmpty(query.UserName))
                    {
                        sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " (UserName Like'%'+@UserName+'%')");
                        command.AddInputParameter("@UserName", DbType.String, query.UserName);
                        //sqlBuilder.Conditions.AddCondition("UserName", DbType.String, "@UserName", query.UserName);
                    }
                    if (query.DropRole > 0)
                    {
                        sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " SysNo IN (SELECT SystemUserSysNo FROM SystemUser_RoleMapping WHERE RoleSysNo = RoleSysNo)");
                        command.AddInputParameter("@RoleSysNo", DbType.Int32, query.DropRole);
                    }
                    if (!string.IsNullOrEmpty(query.InDateCondition) &&
                        query.InDateCondition.IndexOf('-') > 0)
                    {
                        sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " InDate BETWEEN @BeginInDate AND @EndInDate");
                        command.AddInputParameter("@BeginInDate", DbType.String, query.InDateCondition.Split('-')[0]);
                        command.AddInputParameter("@EndInDate", DbType.String, query.InDateCondition.Split('-')[1]);
                    }
                }
                command.CommandText = sqlBuilder.BuildQuerySql();
                return command.ExecuteEntityList<SystemUserEntity>();
            }
        }
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public SystemUserEntity Login(SystemUserEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("Login");
            command.SetParameterValue("@UserName", entity.UserName);
            command.SetParameterValue("@Password", entity.Password);
            SystemUserEntity result = command.ExecuteEntity<SystemUserEntity>();
            if (result != null && result.SysNo > 0)
            {
                result.Privilege = GetSystemUserPrivilege(result.SysNo);
            }
            return result;
        }

        /// <summary>
        /// 添加系统用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SystemUserInsert(SystemUserEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("SystemUserInsert");
            command.SetParameterValue<SystemUserEntity>(entity);
            int result = Convert.ToInt32(command.ExecuteScalar());
            foreach (var item in entity.Role)
            {
                InsertSystemUser_RoleMapping(result, item.SysNo, entity.InUser);
            }
            return result;
        }

        /// <summary>
        /// 根据用户名查询信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public SystemUserEntity ByUserNameGetInfo(string userName)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ByUserNameGetInfo");
            command.SetParameterValue("@UserName", userName);
            SystemUserEntity result = command.ExecuteEntity<SystemUserEntity>();
            return result;
        }

        /// <summary>
        /// 根据系统编号获取信息
        /// </summary>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        public SystemUserEntity LoadEntity(string sysNo)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("LoadEntity");
            command.SetParameterValue("@SysNo", sysNo);
            SystemUserEntity result = command.ExecuteEntity<SystemUserEntity>();
            if (result != null && result.SysNo > 0)
            {
                result.Privilege = GetSystemUserPrivilege(result.SysNo);
                result.Role = GetSystemUserRole(result.SysNo);
            }
            return result;
        }

        /// <summary>
        /// 修改密码
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int UpdatePassword(SystemUserEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("UpdatePassword");
            command.SetParameterValue("@SysNo", entity.SysNo);
            command.SetParameterValue("@Password", entity.Password);
            return command.ExecuteNonQuery();
        }
        /// <summary>
        /// 更新用户信息
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int SystemUserUpdate(SystemUserEntity entity)
        {
            ClearSystemUser_RoleMapping(entity.SysNo);
            foreach (var item in entity.Role)
            {
                InsertSystemUser_RoleMapping(entity.SysNo,item.SysNo,entity.InUser);
            }
            return 1;
        }
        /// <summary>
        /// 清除用户与角色信息
        /// </summary>
        /// <param name="systemUserSysNo"></param>
        /// <returns></returns>
        public int ClearSystemUser_RoleMapping(int systemUserSysNo)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ClearSystemUser_RoleMapping");
            command.SetParameterValue("@SystemUserSysNo", systemUserSysNo);
            return command.ExecuteNonQuery();
        }
        
        /// <summary>
        /// 添加用户与角色信息
        /// </summary>
        /// <param name="systemUserSysNo"></param>
        /// <param name="roleSysno"></param>
        /// <param name="inUser"></param>
        /// <returns></returns>
        public int InsertSystemUser_RoleMapping(int systemUserSysNo, int roleSysno,string inUser)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("InsertSystemUser_RoleMapping");
            command.SetParameterValue("@SystemUserSysNo", systemUserSysNo);
            command.SetParameterValue("@RoleSysNo", roleSysno);
            command.SetParameterValue("@InUser", inUser);
            return command.ExecuteNonQuery();
        }

        /// <summary>
        /// 删除系统用户
        /// </summary>
        /// <param name="sysNo"></param>
        /// <returns></returns>
        public int SystemUserDelete(string sysNo)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("SystemUserDelete");
            command.CommandText = command.CommandText.Replace("#SysNo#",sysNo);
            return command.ExecuteNonQuery();
        }

        /// <summary>
        /// 获取系统用户所有权限
        /// </summary>
        /// <param name="sysno"></param>
        /// <returns></returns>
        public List<SystemUser_PrivilegeEntity> GetSystemUserPrivilege(int sysno) {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("GetSystemUserPrivilege");
            command.SetParameterValue("@SysNo", sysno);
            return command.ExecuteEntityList<SystemUser_PrivilegeEntity>();
        }

        /// <summary>
        /// 获取系统用户所有角色
        /// </summary>
        /// <param name="sysno"></param>
        /// <returns></returns>
        public List<SystemUser_RoleEntity> GetSystemUserRole(int sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("GetSystemUserRole");
            command.SetParameterValue("@SysNo", sysno);
            return command.ExecuteEntityList<SystemUser_RoleEntity>();
        }
    }
}
