using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Web;
using System.Text;

namespace H.Core.Rest
{
    /// <summary>
    /// 使用url参数上的数据来修改Get方式时的http头，同时如果有传当前用户信息，还会验证签名，并作授权验证
    /// 此方法优先级比IEndpointBehavior 低
    /// 用户访问方法时才会调用
    /// </summary>
    public class RestServiceMessageInspector : IDispatchMessageInspector
    {

        #region IDispatchMessageInspector Members
        /// <summary>
        /// 授权验证
        /// </summary>
        /// <param name="request"></param>
        /// <param name="channel"></param>
        /// <param name="instanceContext"></param>
        /// <returns></returns>
        public object AfterReceiveRequest(ref Message request, System.ServiceModel.IClientChannel channel, System.ServiceModel.InstanceContext instanceContext)
        {
            //try
            //{
            //    HttpRequestMessageProperty httpRequest = request.Properties[HttpRequestMessageProperty.Name] as HttpRequestMessageProperty;
            //    //验证用户访问权限
            //    //身份验证KEY
            //    string encryIndentity = ConfigurationManager.AppSettings["ProjectName"].ToString() + "&" + ConfigurationManager.AppSettings["InteractionKey"].ToString();
            //    string url = httpRequest.Headers.Get("MethodName");
            //    string encryKey = new EncryHelper().DoEncrypt(url, encryIndentity, Encoding.UTF8);
            //    string requestEncryKey = httpRequest.Headers.Get("EncryKey");
            //    //记录用户请求信息日志..
            //    if (encryKey != requestEncryKey)
            //    {
            //        throw new BizException("未经授权访问..");
            //    }
            //}
            //catch (Exception ex)
            //{
            //    throw new BizException("未经授权访问..");
            //}
            return null;
        }

        private string GetQueryStringValue(IncomingWebRequestContext context, string key)
        {
            try
            {
                var queryStrings = context.UriTemplateMatch.QueryParameters;
                return queryStrings[key];
            }
            catch
            {
                return null;
            }
        }

        public void BeforeSendReply(ref Message reply, object correlationState)
        {
            HttpResponseMessageProperty response = reply.Properties[HttpResponseMessageProperty.Name] as HttpResponseMessageProperty;
            response.Headers["Cache-Control"] = "No-Cache";
        }

        #endregion
    }
}
