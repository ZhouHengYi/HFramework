using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Core.Utility.Log
{
    public interface ILogEmitter
    {
        void Init(string configParam);

        void EmitLog(LogEntry log);
    }
}
