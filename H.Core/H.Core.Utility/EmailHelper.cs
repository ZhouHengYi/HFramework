using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Net.Mail;
using System.Runtime.Serialization;
using System.Text;

namespace H.Core.Utility
{
    //Email
    [DataContract(Namespace = "http://zhy.seo.sh.cn")]
    [Serializable]
    public class EmailEntity
    {

        public EmailEntity() { }
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Profile_name
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Recipients
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Subject
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Body
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string RegionName
        {
            get;
            set;
        }
    }

    public class EmailHelper
    {
        public static void SendEmail(string Recipients, string Subject,string Body,string RegionName)
        {
            EmailEntity entity = new EmailEntity()
            {
                Profile_name = ConfigurationManager.AppSettings["Mail_Profile_name"],
                Recipients = Recipients,
                Subject = Subject,
                Body = Body,
                RegionName = RegionName
            };
            RestClient.Post<int>("SendMail", entity, ConfigurationManager.AppSettings["Mail_Service"]);
        }
    }
}
