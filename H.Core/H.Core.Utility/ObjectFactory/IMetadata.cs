using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Core.Utility
{
    public interface IMetadata
    {
        string Version { get; }

        string[] Filter { get; }
    }
}
