
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Entity
{
    //BrowsingHistory
    [DataContract(Namespace = "http://zhy.seo.sh.cn")]
    [Serializable]
    public class BrowsingHistoryEntity : PageBase
    {

        public BrowsingHistoryEntity() { }
        public BrowsingHistoryEntity(int _SysNo)
        {
            this.SysNo = _SysNo;
        }


        /// <summary>
        /// 用户表系统编号
        /// </summary>
        [DataMember]
        public int SysNo
        {
            get;
            set;
        }

        /// <summary>
        /// 用户系统编号
        /// </summary>
        [DataMember]
        public int SystemUserSysNo
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string PageName
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string PageUrl
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
        public DateTime InDate
        {
            get;
            set;
        }

    }
}
