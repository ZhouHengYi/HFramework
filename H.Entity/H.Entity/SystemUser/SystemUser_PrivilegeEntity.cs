using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Entity
{
    [DataContract(Namespace = "http://zhy.seo.sh.cn")]
    [Serializable]
    public class SystemUser_PrivilegeEntity : PageBase
    {
        [DataMember]
        public int SysNo { get; set; }

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

        /// <summary>
        /// 权限名称
        /// </summary>
        [DataMember]
        public string PrivilegeName { get; set; }

        [DataMember]
        public int DropParentSysNo { get; set; }

        /// <summary>
        /// 权限对应的页面标示
        /// </summary>
        [DataMember]
        public string PageAlice { get; set; }

        /// <summary>
        /// 父权限SysNo,默认0
        /// </summary>
        [DataMember]
        public int ParentSysNo { get; set; }

        /// <summary>
        /// 父权限
        /// </summary>
        [DataMember]
        public string ParentPrivilegeName { get; set; }
    }
}
