using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Activation;
using System.Text;
using System.Web.Routing;

namespace H.Core.Rest
{
    /// <summary>
    /// 启动RestWebService类
    /// </summary>
    public static class RestWebServiceHost
    {
        /// <summary>
        /// 读取config文件里的Service配置，来启动Restful WCF服务
        /// </summary>
        public static void Open()
        {
            Open(null);
        }

        /// <summary>
        /// 读取config文件里的Service配置，来启动Restful WCF服务
        /// </summary>
        /// <param name="customBizExceptionTypeName">自定义的业务异常类型的类型全名，该类型必须继承自System.Exception；当不需要定义自定义业务异常时，可以传入null。</param>
        public static void Open(string customBizExceptionTypeName)
        {
            //方便全局信息处理，使用了工厂类进行处理。
            WebServiceHostFactory factory = new RestWebServiceHostFactory(customBizExceptionTypeName);
            //此处是根据Config 配置信息获取 REST Service
            //获取数据格式：
            //<serviceList>
            //  <service path="MyRESTService" type="H.Service.Restful.MyREST.MyRESTService, H.Service.Restful" />
            //</serviceList>
            ServiceList list = ServiceConfig.GetAllService();
            foreach (H.Core.Rest.ServiceList.Service de in list.ItemList)
            {
                string routePrefix = (de.Path == null ? string.Empty : de.Path.Trim());
                Type serviceType = Type.GetType(de.Type.Trim(), true);
                //添加到路由
                RouteTable.Routes.Add(new ServiceRoute(routePrefix, factory, serviceType));
            }
        }
    }
}
