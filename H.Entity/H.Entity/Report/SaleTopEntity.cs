using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Entity
{
    [DataContract(Namespace = "http://zhy.seo.sh.cn")]
    [Serializable]
    public class SaleTopEntity
    {
        [DataMember]
        public string RowNo { get; set; }

        [DataMember]
        public string ProductID { get; set; }

        [DataMember]
        public string merchantProductID { get; set; }

        [DataMember]
        public string BrandName_Ch { get; set; }

        [DataMember]
        public string ProductName { get; set; }

        [DataMember]
        public string CurrentPrice { get; set; }

        [DataMember]
        public string VendorName { get; set; }

        [DataMember]
        public string TotalQty { get; set; }
    }
}
