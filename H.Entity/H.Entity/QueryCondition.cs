using H.Core.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Entity
{
    [DataContract(Namespace = "http://zhy.seo.sh.cn")]
    [Serializable]
    public class QueryCondition<T>
    {
        [DataMember]
        public T Condition { get; set; }

        [DataMember]
        public PagingInfo PagingInfo { get; set; }
    }
}
