using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.IDataAccess
{
    public interface IElleUserDataAccess
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        int ElleUserRegister(ElleUserEntity entity);

        /// <summary>
        /// 根据用户ComputerName 获取
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ElleUserEntity ElleUserByComputerName(ElleUserEntity entity);

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        ElleUserEntity ElleUserLogin(ElleUserEntity entity);
    }
}
