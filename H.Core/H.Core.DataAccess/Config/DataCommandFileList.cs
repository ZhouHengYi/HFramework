
namespace H.Core.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Xml.Serialization;

    [XmlRoot("dataCommandFiles", Namespace = "http://oversea.newegg.com/DbCommandFiles")]
    public class DataCommandFileList
    {
        public class DataCommandFile
        {
            [XmlAttribute("name")]
            public string FileName
            {
                get;
                set;
            }
        }

        [XmlElement("file")]
        public DataCommandFile[] FileList
        {
            get;
            set;
        }
    }
}
