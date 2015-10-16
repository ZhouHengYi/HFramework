using H.Core.DataAccess;
using H.Core.Utility;
using H.Entity;
using H.Service.IDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace H.Service.MySql
{
    [VersionExport(typeof(ISystemUserDataAccess), Version = "3.0.0.0")]
    public class SystemUserDataAccess : ISystemUserDataAccess
    {
        /// <summary>
        /// 登陆
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public SystemUserEntity Login(SystemUserEntity entity)
        {
            DataCommand command = DataCommandManager.GetDataCommand("MySql_Login");
            command.SetParameterValue("@UserName", entity.UserName);
            command.SetParameterValue("@Password", entity.Password);
            SystemUserEntity result = command.ExecuteEntity<SystemUserEntity>();
            return result;
        }

        #region ISystemUserDataAccess 成员

        public List<SystemUserEntity> Search(QueryCondition<SystemUserEntity> entity)
        {
            throw new NotImplementedException();
        }

        public int SystemUserInsert(SystemUserEntity entity)
        {
            throw new NotImplementedException();
        }

        public int SystemUserUpdate(SystemUserEntity entity)
        {
            throw new NotImplementedException();
        }

        public int SystemUserDelete(string sysNo)
        {
            throw new NotImplementedException();
        }

        public SystemUserEntity ByUserNameGetInfo(string userName)
        {
            throw new NotImplementedException();
        }

        public SystemUserEntity LoadEntity(string sysNo)
        {
            throw new NotImplementedException();
        }

        public int UpdatePassword(SystemUserEntity entity)
        {
            throw new NotImplementedException();
        }

        public List<SystemUser_PrivilegeEntity> GetSystemUserPrivilege(int sysno)
        {
            throw new NotImplementedException();
        }

        public List<SystemUser_RoleEntity> GetSystemUserRole(int sysno)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
