using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using H.Core.Utility;
using H.Entity;
using H.Service.IDataAccess;

namespace H.Service.Rest
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public class ElleUserService
    {
        /// <summary>
        /// 注册用户
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/ElleUserRegister", Method = "POST")]
        public int ElleUserRegister(ElleUserEntity entity)
        {
            return ObjectFactory<IElleUserDataAccess>.Instance.ElleUserRegister(entity);
        }

        /// <summary>
        /// 根据用户ComputerName 获取
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/ElleUserByComputerName", Method = "POST")]
        public ElleUserEntity ElleUserByComputerName(ElleUserEntity entity)
        {
            return ObjectFactory<IElleUserDataAccess>.Instance.ElleUserByComputerName(entity);
        }

        /// <summary>
        /// 登录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/ElleUserLogin", Method = "POST")]
        public ElleUserEntity ElleUserLogin(ElleUserEntity entity)
        {
            return ObjectFactory<IElleUserDataAccess>.Instance.ElleUserLogin(entity);
        }
    }
}
