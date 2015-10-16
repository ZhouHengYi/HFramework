
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Entity
{
    //SystemUser_Role
    [DataContract(Namespace = "http://zhy.seo.sh.cn")]
    [Serializable]
    public class SystemUser_RoleEntity : PageBase
    {

        public SystemUser_RoleEntity() { }
        public SystemUser_RoleEntity(int _SysNo)
        {
            this.SysNo = _SysNo;
        }


        private int _SysNo;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int SysNo
        {
            get { return _SysNo; }
            set { _SysNo = value; }
        }

        private string _RoleName;
        /// <summary>
        /// 角色名称
        /// </summary>
        [DataMember]
        public string RoleName
        {
            get { return _RoleName; }
            set { _RoleName = value; }
        }

        private int _Status;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Status
        {
            get { return _Status; }
            set { _Status = value; }
        }

        private string _InUser;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string InUser
        {
            get { return _InUser; }
            set { _InUser = value; }
        }

        private DateTime? _InDate;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime? InDate
        {
            get { return _InDate; }
            set { _InDate = value; }
        }

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
        public List<SystemUser_PrivilegeEntity> PrivilegeList { get; set; }
    }
}
