using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Entity
{
    [DataContract(Namespace = "http://zhy.seo.sh.cn")]
    public class AuthUserEntity
    {
        [DataMember]
        public int SysNo { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public string Email { get; set; }

        /// <summary>
        ///权限字典,key=functionKey value=VendorExSysNo列表
        /// </summary>
        [DataMember]
        public List<SystemUser_PrivilegeEntity> Privilege { get; set; }
    }
}
