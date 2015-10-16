
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Entity
{
    //ClubMembers
    [DataContract(Namespace = "http://zhy.seo.sh.cn")]
    [Serializable]
    public class ClubMembersEntity : PageBase
    {

        public ClubMembersEntity() { }
        public ClubMembersEntity(int _SysNo)
        {
            this.SysNo = _SysNo;
        }


        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int SysNo
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Title
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string SmallImageUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string BigImageUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Status
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string InUser
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public DateTime? InDate
        {
            get;
            set;
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
        public string InDateCondition { get; set; }
    }
}
