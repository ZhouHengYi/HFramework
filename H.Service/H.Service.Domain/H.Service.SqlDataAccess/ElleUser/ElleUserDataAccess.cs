using H.Core.DataAccess;
using H.Core.Utility;
using H.Entity;
using H.Service.IDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace H.Service.SqlDataAccess.ElleUser
{
    [VersionExport(typeof(IElleUserDataAccess))]
    public class ElleUserDataAccess : IElleUserDataAccess
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public int ElleUserRegister(ElleUserEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ElleUserRegister");
            command.SetParameterValue("@ComputerName", entity.ComputerName);
            command.SetParameterValue("@Email", entity.Email);
            command.SetParameterValue("@Password", entity.Password);
            command.SetParameterValue("@Head", entity.Head);
            int result = command.ExecuteScalar<int>();
            return result;
        }

        /// <summary>
        /// 根据用户ComputerName 获取
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ElleUserEntity ElleUserByComputerName(ElleUserEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ElleUserByComputerName");
            command.SetParameterValue("@ComputerName", entity.ComputerName);
            ElleUserEntity result = command.ExecuteEntity<ElleUserEntity>();
            return result;
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public ElleUserEntity ElleUserLogin(ElleUserEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ElleUserLogin");
            command.SetParameterValue("@ComputerName", entity.ComputerName);
            command.SetParameterValue("@Password", entity.Password);
            ElleUserEntity result = command.ExecuteEntity<ElleUserEntity>();
            return result;
        }
    }
}
