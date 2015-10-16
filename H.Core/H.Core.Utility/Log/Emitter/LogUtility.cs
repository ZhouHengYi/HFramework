using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace H.Core.Utility.Log
{
    public static class LogUtility
    {
        /// <summary>
        /// 建造异常信息
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public static string BuildExceptionMessage(Exception x)
        {
            StringBuilder sb = new StringBuilder();

            Exception logException = x;
            if (x.InnerException != null)
                logException = x.InnerException;

            sb.AppendFormat("Machine:{0}\r\n", Environment.MachineName);
            sb.AppendFormat("Source : {0}\r\n", logException.Source);
            sb.AppendFormat("Message : {0}\r\n", logException.Message);
            sb.AppendFormat("Stack Trace : {0}\r\n", logException.StackTrace);
            sb.AppendFormat("TargetSite : {0}\r\n", BuildMethodMessage(logException.TargetSite));

            return sb.ToString();
        }

        /// <summary>
        /// 执行上下文Method信息
        /// </summary>
        /// <param name="method"></param>
        /// <returns></returns>
        private static string BuildMethodMessage(MethodBase method)
        {
            StringBuilder methodBuilder = new StringBuilder();
            if (method != null)
            {
                ParameterInfo[] pi = method.GetParameters();
                methodBuilder.AppendFormat("MoudleName: {0}\r\n", method.Module.FullyQualifiedName);
                methodBuilder.AppendFormat("MethodName: {0}\r\n", method.Name);

                methodBuilder.Append("<MethodParameters>\r\n");
                foreach (ParameterInfo info in pi)
                {
                    methodBuilder.Append("<parameter name=\"");
                    methodBuilder.Append(info.Name);
                    methodBuilder.Append("\"  ");
                    methodBuilder.Append("type=\"");
                    methodBuilder.Append(info.ParameterType.ToString());
                    methodBuilder.Append("/>\r\n");
                }
                methodBuilder.Append("</MethodParameters>\r\n");
            }

            return methodBuilder.ToString();
        }
    }
}
