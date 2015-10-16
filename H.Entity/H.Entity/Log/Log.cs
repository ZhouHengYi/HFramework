using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Entity
{
    [DataContract(Namespace = "http://zhy.seo.sh.cn")]
    public class Log
    {
        [DataMember]
        public int SysNo { get; set; }
        [DataMember]
        public string Title { get; set; }
        [DataMember]
        public DateTime AddDate { get; set; }

    }
}
