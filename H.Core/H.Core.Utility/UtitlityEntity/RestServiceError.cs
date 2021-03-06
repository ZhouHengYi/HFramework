﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace H.Core.Utility
{
    [DataContract(Name = "ServiceError", Namespace = "http://zhy.seo.sh.cn")]
    public class RestServiceError
    {
        [DataMember]
        public int StatusCode { get; set; }

        [DataMember]
        public string StatusDescription { get; set; }

        [DataMember]
        public List<Error> Faults { get; set; }

        public RestServiceError()
        {
            Faults = new List<Error>();
        }
    }

    [DataContract(Name = "Error", Namespace = "http://zhy.seo.sh.cn")]
    public class Error
    {
        [DataMember]
        public string ErrorCode { get; set; }

        [DataMember]
        public string ErrorMessage { get; set; }

        [DataMember]
        public string ErrorDescription { get; set; }
    }
}
