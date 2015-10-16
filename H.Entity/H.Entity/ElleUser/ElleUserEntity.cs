using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Entity
{
    [DataContract(Namespace = "http://zhy.seo.sh.cn")]
    [Serializable]
    public class ElleUserEntity : PageBase
    {
        public ElleUserEntity() { }
        public ElleUserEntity(int _SysNo)
        {
            this.SysNo = _SysNo;
        }
        [DataMember]
        public int SysNo { get; set; }
        [DataMember]
        public string ComputerName { get; set; }
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Head { get; set; }
        [DataMember]
        public DateTime? LastLoginDate { get; set; }
        [DataMember]
        public int Status { get; set; }
        [DataMember]
        public DateTime? InDate { get; set; }
    }
}
