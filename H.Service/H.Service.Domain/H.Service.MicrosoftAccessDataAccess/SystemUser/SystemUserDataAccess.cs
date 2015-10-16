using H.Core.DataAccess;
using H.Core.Utility;
using H.Entity;
using H.Service.IDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace H.Service.MicrosoftAccessDataAccess.SystemUser
{
    [VersionExport(typeof(ISystemUserDataAccess), Version = "2.0.0.0")]
    public class SystemUserDataAccess : ISystemUserDataAccess
    {
        public List<SystemUserEntity> Search(QueryCondition<SystemUserEntity> entity)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public SystemUserEntity Login(SystemUserEntity entity)
        {
            DataCommand command = DataCommandManager.GetDataCommand("Access_Login");
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
            DataCommand command = DataCommandManager.GetDataCommand("SystemUserInsert");
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
            DataCommand command = DataCommandManager.GetDataCommand("ByUserNameGetInfo");
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
            DataCommand command = DataCommandManager.GetDataCommand("LoadEntity");
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
            DataCommand command = DataCommandManager.GetDataCommand("UpdatePassword");
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
                InsertSystemUser_RoleMapping(entity.SysNo, item.SysNo, entity.InUser);
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
            DataCommand command = DataCommandManager.GetDataCommand("ClearSystemUser_RoleMapping");
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
        public int InsertSystemUser_RoleMapping(int systemUserSysNo, int roleSysno, string inUser)
        {
            DataCommand command = DataCommandManager.GetDataCommand("InsertSystemUser_RoleMapping");
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
            DataCommand command = DataCommandManager.GetDataCommand("SystemUserDelete");
            //command.CommandText = command.CommandText.Replace("#SysNo#", sysNo);
            return command.ExecuteNonQuery();
        }

        /// <summary>
        /// 获取系统用户所有权限
        /// </summary>
        /// <param name="sysno"></param>
        /// <returns></returns>
        public List<SystemUser_PrivilegeEntity> GetSystemUserPrivilege(int sysno)
        {
            DataCommand command = DataCommandManager.GetDataCommand("GetSystemUserPrivilege");
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
            DataCommand command = DataCommandManager.GetDataCommand("GetSystemUserRole");
            command.SetParameterValue("@SysNo", sysno);
            return command.ExecuteEntityList<SystemUser_RoleEntity>();
        }
    }
}
