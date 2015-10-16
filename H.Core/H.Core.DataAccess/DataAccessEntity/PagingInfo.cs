using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace H.Core.DataAccess
{
    [Serializable]
    [DataContract]
    public class PagingInfo
    {
        [DataMember]
        public int PageIndex { get; set; }

        [DataMember]
        public int PageSize { get; set; }

        private List<SortItem> m_SortList = new List<SortItem>();
        [DataMember]
        public List<SortItem> SortList
        {
            get { return m_SortList; }
            set
            {
                if (value == null)
                {
                    m_SortList.Clear();
                }
                else
                {
                    m_SortList = value;
                }
            }
        }

        [DataMember]
        public string SortType { get; set; }

        [DataMember]
        public int TotalCount { get; set; }

        [DataMember]
        public int PageCount { get; set; }

        [DataMember]
        public string SortField { get; set; }
    }

    [Serializable]
    [DataContract]
    public enum SortType
    {
        [EnumMember]
        DESC,
        [EnumMember]
        ASC
    }

    [Serializable]
    [DataContract]
    public class SortItem
    {
        [DataMember]
        public string SortFeild { get; set; }

        [DataMember]
        public SortType SortType { get; set; }
    }
}
