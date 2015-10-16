using H.Core.DataAccess;
using H.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;

namespace MailService
{


    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public class MailDataAccess
    {    
        /// <summary>
        /// 单品销售TOP10
        /// </summary>
        /// <param name="mail">dynamic mail = {  
        /// Profile_name = 数据库配置的发送邮箱文件
        /// Recipients = 接收者
        /// Subject = 标题
        /// Body = 内容
        /// RegionName = 请求发送邮件项目
        /// }</param>
        /// <returns></returns>
        [WebInvoke(UriTemplate = "/SendMail", Method = "POST", ResponseFormat = WebMessageFormat.Json)]
        public int SendMail(EmailEntity mail) {
            try
            {
                CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("InsertEmail");
                command.SetParameterValue("@Profile_name", mail.Profile_name);
                command.SetParameterValue("@Recipients", mail.Recipients);
                command.SetParameterValue("@Subject", mail.Subject);
                command.SetParameterValue("@Body", mail.Body);
                command.SetParameterValue("@RegionName", mail.RegionName);
                object obj = command.ExecuteScalar();
                return obj.ToInt32();
            }
            catch (Exception ex)
            {                
                throw ex;
            }
        }
    }
}