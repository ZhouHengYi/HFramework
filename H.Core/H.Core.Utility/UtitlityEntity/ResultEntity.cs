using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Core.Utility
{
    [DataContract(Name = "ResultEntity",Namespace = "http://zhy.seo.sh.cn")]
    public class ResultEntity<T>
    {
        [DataMember]
        public RestServiceError ServiceError { get; set; }

        [DataMember]
        public T Result { get; set; }
    }
}
