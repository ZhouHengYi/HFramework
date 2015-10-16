using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Entity
{
    [DataContract(Namespace = "http://zhy.seo.sh.cn")]
    [Serializable]
    public class SystemUserEntity : PageBase
    {
        [DataMember]
        public int SysNo { get; set; }        

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        [DataMember]
        public string Email { get; set; }

        [DataMember]
        public DateTime? LastLoginDate { get; set; }

        [DataMember]
        public string LastLoginDateStr
        {
            get
            {
                if (LastLoginDate != null)
                {
                    return Convert.ToDateTime(LastLoginDate).ToString("yyyy-MM-dd HH:dd:ss");
                }
                else
                {
                    return "";
                }
            }
            set { }
        }

        [DataMember]
        public string OldPassword { get; set; }

        [DataMember]
        public int DropRole { get; set; }

        [DataMember]
        public List<SystemUser_RoleEntity> Role { get; set; }

        [DataMember]
        public int Status { get; set; }

        [DataMember]
        public string InUser { get; set; }

        [DataMember]
        public DateTime? InDate { get; set; }

        [DataMember]
        public string InDateStr
        {
            get
            {
                if (InDate != null)
                {
                    return Convert.ToDateTime(InDate).ToString("yyyy-MM-dd HH:dd:ss");
                }
                else
                {
                    return "";
                }
            }
            set { }
        }

        [DataMember]
        public string InDateCondition { get; set; }

        [DataMember]
        public List<SystemUser_PrivilegeEntity> Privilege { get; set; }
    }
}
