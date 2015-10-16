using H.Core.Utility;
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Website.Facade.Facade
{
    public class SystemUserFacade
    {
        public static List<SystemUserEntity> Seach(QueryCondition<SystemUserEntity> entity)
        {
            return RestClient.Post<List<SystemUserEntity>>("SystemUserService/Search", entity);
        }

        public static int SystemUserInsert(SystemUserEntity entity)
        {
            int result = RestClient.Post<int>("SystemUserService/SystemUserInsert", entity);
            if (result > 0)
                EmailHelper.SendEmail(entity.Email, entity.Password);
            return result;
        }

        public static int SystemUserUpdate(SystemUserEntity entity)
        {
            return RestClient.Post<int>("SystemUserService/SystemUserUpdate", entity);
        }

        public static bool Login(SystemUserEntity entity)
        {

            SystemUserEntity resultEntity = RestClient.Post<SystemUserEntity>("SystemUserService/Login", entity);
            if (resultEntity == null || resultEntity.SysNo == 0)
            {
                return false;
            }
            else
            {
                AuthUserEntity login = new AuthUserEntity();
                login.UserName = resultEntity.UserName;
                login.SysNo = resultEntity.SysNo;
                login.Email = resultEntity.Email;
                WebContext.Login(login);
                return true;
            }
        }

        public static SystemUserEntity ByUserNameGetInfo(string userName)
        {
            return RestClient.Post<SystemUserEntity>("SystemUserService/ByUserNameGetInfo", userName);
        }

        public static SystemUserEntity LoadEntity(int sysNo)
        {
            return RestClient.Get<SystemUserEntity>("SystemUserService/LoadEntity/" + sysNo);
        }

        public static int UpdatePassword(SystemUserEntity entity)
        {
            return RestClient.Post<int>("SystemUserService/UpdatePassword", entity);
        }

        public static int SystemUserDelete(string sysNo)
        {
            return RestClient.Post<int>("SystemUserService/SystemUserDelete", sysNo);
        }

        /// <summary>
        /// 获取系统用户所有权限
        /// </summary>
        /// <param name="sysno"></param>
        /// <returns></returns>
        public static List<SystemUser_PrivilegeEntity> GetSystemUserPrivilege(int sysno)
        {
            return RestClient.Post<List<SystemUser_PrivilegeEntity>>("SystemUserService/GetSystemUserPrivilege", sysno);
        }

        /// <summary>
        /// 获取系统用户所有角色
        /// </summary>
        /// <param name="sysno"></param>
        /// <returns></returns>
        public static List<SystemUser_RoleEntity> GetSystemUserRole(int sysno)
        {
            return RestClient.Post<List<SystemUser_RoleEntity>>("SystemUserService/GetSystemUserRole", sysno);
        }
    }
}
