
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Entity
{
    //Files
    [DataContract(Namespace = "http://zhy.seo.sh.cn")]
    [Serializable]
    public class FilesEntity : PageBase
    {

        public FilesEntity() { }
        public FilesEntity(int _SysNo)
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
        /// 1.规章制度 2.收费标准
        /// </summary>
        [DataMember]
        public int Flag
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int FSysNo
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string FileName
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Path
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
    }
}
