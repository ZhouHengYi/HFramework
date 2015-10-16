using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Web;
using System.Text;

namespace H.Core.Utility
{
    public static class ServiceContext
    {
        public static IContext Current
        {
            get
            {
                // 可以配置自定义的上下文对象容器，便于以后切换服务端具体的技术框架容器，以及方便做UnitTest（可以定义mock的上下文对象）
                string contextTypeName = ConfigurationManager.AppSettings["ServiceContextType"];
                if (contextTypeName != null && contextTypeName.Trim().Length > 0)
                {
                    return (IContext)Activator.CreateInstance(Type.GetType(contextTypeName, true));
                }
                // 默认不配置则使用WCF Restfull的方式的上下文
                return new WCFRestServiceContext();
            }
        }
    }

    public interface IContext
    {
        /// <summary>
        /// 当前操作用户的系统唯一编号
        /// </summary>
        int UserSysNo { get; }

        /// <summary>
        /// 当前操作客户端的IP地址
        /// </summary>
        string ClientIP { get; }
    }

    internal class WCFRestServiceContext : IContext
    {
        private const string X_User_SysNo = "X-User-SysNo";
        //private const string X_Portal_TimeZone = "X-Portal-TimeZone";

        public int UserSysNo
        {
            get
            {
                if (WebOperationContext.Current != null
                    && WebOperationContext.Current.IncomingRequest != null
                    && WebOperationContext.Current.IncomingRequest.Headers != null)
                {
                    int tmp;
                    string userSysNo = WebOperationContext.Current.IncomingRequest.Headers[X_User_SysNo];
                    if (userSysNo != null && userSysNo.Trim().Length > 0 && int.TryParse(userSysNo, out tmp))
                    {
                        return tmp;
                    }
                }

                //支持WCF Host时读取上下文
                if (OperationContext.Current != null
                    && OperationContext.Current.IncomingMessageHeaders != null)
                {
                    return OperationContext.Current.IncomingMessageHeaders
                        .GetHeader<int>(X_User_SysNo, string.Empty);
                }
                return -1;
            }
        }

        public string ClientIP
        {
            get
            {
                if (OperationContext.Current != null)
                {
                    RemoteEndpointMessageProperty endpointProperty = OperationContext.Current.IncomingMessageProperties[RemoteEndpointMessageProperty.Name] as RemoteEndpointMessageProperty;
                    if (endpointProperty != null)
                    {
                        return endpointProperty.Address;
                    }
                }
                return string.Empty;
            }
        }
    }
}
