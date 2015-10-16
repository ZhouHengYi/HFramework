using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Description;
using System.Text;

namespace H.Core.Rest
{
    /// <summary>
    /// 自定义RestWebServiceHost工厂类，方便全局信息处理
    /// 例如：判断客户端的请求是否恶意请求
    /// </summary>
    internal class RestWebServiceHostFactory : WebServiceHostFactory
    {
        private string m_BizExceptionTypeName;
        private const int MAX_MSG_SIZE = 12000000;

        public RestWebServiceHostFactory(string bizExceptionTypeName)
        {
            m_BizExceptionTypeName = bizExceptionTypeName;
        }

        protected override ServiceHost CreateServiceHost(Type serviceType, Uri[] baseAddresses)
        {
            ServiceHost host = base.CreateServiceHost(serviceType, baseAddresses);
            host.Opening += new EventHandler(Host_Opening);
            host.Opened += new EventHandler(Host_Opened);
            return host;
        }

        private void Host_Opened(object sender, EventArgs e)
        {

        }

        private void Host_Opening(object sender, EventArgs e)
        {
            ServiceHost host = sender as ServiceHost;

            if (host == null)
            {
                return;
            }

            RestServiceBehavior b = host.Description.Behaviors.Find<RestServiceBehavior>();
            if (b == null)
            {
                host.Description.Behaviors.Add(new RestServiceBehavior());
            }
            //------- 设置 dataContractSerializer的 maxItemsInObjectGraph属性为int.MaxValue
            Type t = host.GetType();
            object obj = t.Assembly.CreateInstance("System.ServiceModel.Dispatcher.DataContractSerializerServiceBehavior", true, BindingFlags.CreateInstance | BindingFlags.Instance | BindingFlags.NonPublic, null, new object[] { false, int.MaxValue }, null, null);
            IServiceBehavior myServiceBehavior = obj as IServiceBehavior;
            if (myServiceBehavior != null)
            {
                host.Description.Behaviors.Add(myServiceBehavior);
            }
            foreach (var endpoint in host.Description.Endpoints)
            {
                //WCF 传输大小
                WebHttpBinding binding = endpoint.Binding as WebHttpBinding;
                if (binding != null)
                {
                    binding.MaxReceivedMessageSize = MAX_MSG_SIZE;
                    binding.ReaderQuotas.MaxStringContentLength = MAX_MSG_SIZE;
                    binding.ReaderQuotas.MaxArrayLength = MAX_MSG_SIZE;
                    binding.ReaderQuotas.MaxBytesPerRead = MAX_MSG_SIZE;
                    binding.ReaderQuotas.MaxDepth = MAX_MSG_SIZE;
                    binding.ReaderQuotas.MaxNameTableCharCount = MAX_MSG_SIZE;
                }

                //帮助
                WebHttpEndpoint p = endpoint as WebHttpEndpoint;
                if (p != null)
                {
                    p.HelpEnabled = true;
                    p.AutomaticFormatSelectionEnabled = true;
                }
                WebHttpBehavior b0 = endpoint.Behaviors.Find<WebHttpBehavior>();
                if (b0 == null)
                {
                    endpoint.Behaviors.Add(new WebHttpBehavior() { HelpEnabled = true, FaultExceptionEnabled = true, AutomaticFormatSelectionEnabled = true });
                }
                else
                {
                    b0.HelpEnabled = true;
                    b0.FaultExceptionEnabled = true;
                    b0.AutomaticFormatSelectionEnabled = true;
                }

                //添加用户访问Service 进行 监控，优先级高于 RestServiceBehavior
                RestEndpointBehavior b1 = endpoint.Behaviors.Find<RestEndpointBehavior>();
                if (b1 == null)
                {                    
                    endpoint.Behaviors.Add(new RestEndpointBehavior());
                }
            }

        }
    }
}
