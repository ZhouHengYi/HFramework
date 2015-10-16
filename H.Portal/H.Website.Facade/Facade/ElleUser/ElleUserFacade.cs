using H.Core.Utility;
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Website.Facade.Facade
{
    public class ElleUserFacade
    {
        public static bool Login(ElleUserEntity entity)
        {
            ElleUserEntity resultEntity = RestClient.Post<ElleUserEntity>("ElleUserService/ElleUserLogin", entity);
            if (resultEntity == null || resultEntity.SysNo == 0)
            {
                return false;
            }
            else
            {
                AuthUserEntity login = new AuthUserEntity();
                login.UserName = resultEntity.ComputerName;
                login.SysNo = resultEntity.SysNo;
                WebContext.Login(login);
                return true;
            }
        }

        public static int Register(ElleUserEntity entity) {
            ElleUserEntity resultEntity = RestClient.Post<ElleUserEntity>("ElleUserService/ElleUserByComputerName", entity);
            if (resultEntity == null || resultEntity.SysNo == 0)
            {
                int result = RestClient.Post<int>("ElleUserService/ElleUserRegister", entity);
                EmailHelper.SendEmail(entity.Email,entity.Password);
                return result;
            }
            return 0;
        }
    }
}
