using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Entity
{
    //ProductType
    [DataContract(Namespace = "http://zhy.seo.sh.cn")]
    [Serializable]
    public class ProductTypeEntity : PageBase
    {

        public ProductTypeEntity() { }
        public ProductTypeEntity(int _SysNo)
        {
            this.SysNo = _SysNo;
        }


        private int _SysNo;
        /// <summary>
        /// 用户表系统编号
        /// </summary>
        [DataMember]
        public int SysNo
        {
            get { return _SysNo; }
            set { _SysNo = value; }
        }

        private int _ParentSysNo;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int ParentSysNo
        {
            get { return _ParentSysNo; }
            set { _ParentSysNo = value; }
        }


        private string _ParentName;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
            public string ParentName
        {
            get { return _ParentName; }
            set { _ParentName = value; }
        }

        private string _ProductTypeName;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ProductTypeName
        {
            get { return _ProductTypeName; }
            set { _ProductTypeName = value; }
        }

        [DataMember]
        public int DropParentSysNo { get; set; }

        private int _Order;
        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Order
        {
            get { return _Order; }
            set { _Order = value; }
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

    }
}
