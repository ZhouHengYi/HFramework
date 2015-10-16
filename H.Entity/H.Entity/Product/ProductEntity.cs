
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Entity
{
    //Product
    [DataContract(Namespace = "http://zhy.seo.sh.cn")]
    [Serializable]
    public class ProductEntity : PageBase
    {

        public ProductEntity() { }
        public ProductEntity(int _SysNo)
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
        /// 商品分类SysNo
        /// </summary>
        [DataMember]
        public int ProductTypeSysNo { get; set; }

        /// <summary>
        /// 商品分类名称
        /// </summary>
        [DataMember]
        public string ProductTypeName { get; set; }

        /// <summary>
        /// 商品分类SysNo
        /// </summary>
        [DataMember]
        public int DropProductTypeSysNo { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string ProductName
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public decimal Price
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public int Weight
        {
            get;
            set;
        }

        /// <summary>
        /// 主料
        /// </summary>
        [DataMember]
        public string Mdient
        {
            get;
            set;
        }

        /// <summary>
        /// 
        /// </summary>
        [DataMember]
        public string Sdient
        {
            get;
            set;
        }

        /// <summary>
        /// 做法
        /// </summary>
        [DataMember]
        public string Method
        {
            get;
            set;
        }

        /// <summary>
        /// 排序
        /// </summary>
        [DataMember]
        public int Order
        {
            get;
            set;
        }

        /// <summary>
        /// 小图
        /// </summary>
        [DataMember]
        public string SmallImageUrl
        {
            get;
            set;
        }

        /// <summary>
        /// 大图
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
