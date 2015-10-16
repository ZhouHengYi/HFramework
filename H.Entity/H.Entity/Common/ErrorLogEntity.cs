
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Entity
{
    //错误日志表
    [DataContract(Namespace = "http://zhy.seo.sh.cn")]
    [Serializable]
    public class ErrorLogEntity : PageBase
    {

        public ErrorLogEntity() { }
        public ErrorLogEntity(int _SysNo)
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

        private string _LogID;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string LogID
        {
            get { return _LogID; }
            set { _LogID = value; }
        }

        private string _GlobalName;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string GlobalName
        {
            get { return _GlobalName; }
            set { _GlobalName = value; }
        }

        private string _LocalName;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string LocalName
        {
            get { return _LocalName; }
            set { _LocalName = value; }
        }

        private string _Content;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Content
        {
            get { return _Content; }
            set { _Content = value; }
        }

        private string _LogUserName;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string LogUserName
        {
            get { return _LogUserName; }
            set { _LogUserName = value; }
        }

        private string _Category;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Category
        {
            get { return _Category; }
            set { _Category = value; }
        }

        private string _LogServerIP;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string LogServerIP
        {
            get { return _LogServerIP; }
            set { _LogServerIP = value; }
        }

        private string _LogServerName;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string LogServerName
        {
            get { return _LogServerName; }
            set { _LogServerName = value; }
        }

        private string _ReferenceKey;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ReferenceKey
        {
            get { return _ReferenceKey; }
            set { _ReferenceKey = value; }
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

    }
}
