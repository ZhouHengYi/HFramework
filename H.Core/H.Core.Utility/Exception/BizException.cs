using System;
namespace H.Core.Utility
{
    public class BizException : Exception
    {
        public BizException(string message)
            : base(message)
        {

        }
    }
}
