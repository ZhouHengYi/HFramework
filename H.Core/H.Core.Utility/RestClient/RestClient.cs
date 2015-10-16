using System;
using System.Collections.Generic;
using System.Configuration;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.Linq;
using System.Text;
using Microsoft.Http;
using System.Web;


namespace H.Core.Utility
{
    public static class RestClient
    {
        public static string domain = WebConfig.RestServiceHost + "{0}";
        public static string HandlerError = WebConfig.HandlerError;
        /// <summary>
        /// 返回数据转换为对应的实体
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="message"></param>
        /// <returns></returns>
        public static T Convert<T>(HttpResponseMessage message)
        {
            string contentType = message.Content.ContentType.Split(';')[0];
            ISerializer seri = SerializerFactory.GetSerializer(contentType);
            if (seri != null)
            {
                if ((int)message.StatusCode != 200)
                {
                    ResultEntity<object> result = (ResultEntity<object>)seri.Deserialize(message.Content.ReadAsStream(), typeof(ResultEntity<object>));
                    //判断是否为自定义异常，如果不是的话..根据Web.config进行的配置 判断是否输出页面异常..
                    if (result != null && result.ServiceError != null)
                    {
                        if (HandlerError == "True" && result.ServiceError.StatusCode != 503)
                        {
                            //隐藏错误信息
                            result.ServiceError.Faults[0].ErrorMessage = "系统繁忙..";
                            //记录日志
                            //ExceptionHelper.HandleException(new ApplicationException(GetErrorMsg(result.ServiceError.Faults)));
                        }
                        //HttpContext.Current.Response.Write(GetErrorMsg(result.ServiceError.Faults));
                        throw new BizException(GetErrorMsg(result.ServiceError.Faults));
                    }
                    return default(T);
                }
                else
                    return (T)seri.Deserialize(message.Content.ReadAsStream(), typeof(T));
            }
            else
                return default(T);
        }

        /// <summary>
        /// 已Get 方式请求Rest服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">服务地址</param>
        /// <returns></returns>
        public static T Get<T>(string url)
        {
            HttpResponseMessage message = CreatetHtpClient(url).Get(string.Format(domain, url));
            return Convert<T>(message);
        }

        public static T Get<T>(string url,string _domain)
        {
            HttpResponseMessage message = CreatetHtpClient(url).Get(_domain + url);
            return Convert<T>(message);
        }

        /// <summary>
        /// 已Post 方式请求Rest 服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">服务地址</param>
        /// <param name="parms">传递参数</param>
        /// <returns></returns>
        public static T Post<T>(string url, object parms)
        {
            HttpResponseMessage message = CreatetHtpClient(url).Post(string.Format(domain, url), GetContent(parms));
            return Convert<T>(message);
        }

        /// <summary>
        /// 已Post 方式请求Rest 服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">服务地址</param>
        /// <param name="parms">传递参数</param>
        /// <returns></returns>
        public static T Post<T>(string url, object parms, string _domain)
        {
            HttpResponseMessage message = CreatetHtpClient(url).Post(string.Format(_domain, url), GetContent(parms));
            return Convert<T>(message);
        }

        /// <summary>
        /// 已Put 方式请求Rest 服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">服务地址</param>
        /// <param name="parms">传递参数</param>
        /// <returns></returns>
        public static T Put<T>(string url, object parms)
        {
            HttpResponseMessage message = CreatetHtpClient(url).Put(string.Format(domain, url), GetContent(parms));
            return Convert<T>(message);
        }

        /// <summary>
        /// 已Put 方式请求Rest 服务
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="url">服务地址</param>
        /// <param name="parms">传递参数</param>
        /// <returns></returns>
        public static T Put<T>(string url, object parms, string _domain)
        {
            HttpResponseMessage message = CreatetHtpClient(url).Put(string.Format(_domain, url), GetContent(parms));
            return Convert<T>(message);
        }

        /// <summary>
        /// 创建HttpClient对象
        /// 对一些需要验证信息做统一处理
        /// </summary>
        /// <returns></returns>
        public static HttpClient CreatetHtpClient(string url)
        {
            HttpClient client = new HttpClient();
            //添加验证信息
            client.DefaultHeaders.Add("MethodName", url);
            client.DefaultHeaders.Add("Accept", WebConfig.RestResponseFormat);
            EncryHelper hepler = new EncryHelper();
            //身份验证KEY
            string encryIndentity = WebConfig.ProjectName + "&" + WebConfig.InteractionKey;
            string encryKey = hepler.DoEncrypt(url, encryIndentity, Encoding.UTF8);
            client.DefaultHeaders.Add("EncryKey", encryKey);
            return client;
        }

        /// <summary>
        /// 获取 HttpContent区域数据
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public static HttpContent GetContent(object entity)
        {
            string strContent = new JsonSerializer().Serialization(entity, entity.GetType());
            var data = System.Text.Encoding.UTF8.GetBytes(strContent);
            return HttpContent.Create(data, "application/json");
        }

        public static string GetErrorMsg(List<Error> list)
        {
            string retStr = string.Empty;
            list.ForEach(e => { retStr += e.ErrorMessage; });
            return retStr;
        }
    }
}
