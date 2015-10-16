using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using System.ServiceModel.Security;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using System.Xml;
using H.Core.Utility;
namespace H.Core.Rest
{
    /// <summary>
    /// 处理异常
    /// </summary>
    public class RestServiceErrorHandler : IErrorHandler
    {

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            HttpStatusCode statusCode;
            if (error is SecurityAccessDeniedException)
            {
                statusCode = HttpStatusCode.Unauthorized;
            }
            else if (error is BizException)
            {
                statusCode = HttpStatusCode.ServiceUnavailable;
            }
            else
            {
                statusCode = HttpStatusCode.InternalServerError;
            }
            H.Core.Utility.ResultEntity<object> eb = new ResultEntity<object>();

            H.Core.Utility.RestServiceError errorData = new RestServiceError()
            {
                StatusCode = (int)statusCode,
                StatusDescription = HttpWorkerRequest.GetStatusDescription((int)statusCode),
                Faults = new List<Error>()
            };

            var errorEntity = new Error();
            errorEntity.ErrorCode = "00000";
            errorEntity.ErrorDescription = error.ToString();
            errorEntity.ErrorMessage = error.Message;
            errorData.Faults.Add(errorEntity);
            eb.ServiceError = errorData;


            if (version == MessageVersion.None && WebOperationContext.Current != null)
            {
                WebMessageFormat messageFormat = WebOperationContext.Current.OutgoingResponse.Format ?? WebMessageFormat.Xml;
                WebContentFormat contentFormat = WebContentFormat.Xml;
                string contentType = "application/xml";

                if (messageFormat == WebMessageFormat.Json)
                {
                    contentFormat = WebContentFormat.Json;
                    contentType = "application/json";
                }

                WebBodyFormatMessageProperty bodyFormat = new WebBodyFormatMessageProperty(contentFormat);

                HttpResponseMessageProperty responseMessage = new HttpResponseMessageProperty();
                responseMessage.StatusCode = statusCode;
                responseMessage.StatusDescription = HttpWorkerRequest.GetStatusDescription((int)responseMessage.StatusCode);
                responseMessage.Headers[HttpResponseHeader.ContentType] = contentType;
                responseMessage.Headers["X-HTTP-StatusCode-Override"] = "500";

                fault = Message.CreateMessage(MessageVersion.None, null, new RestServiceErrorWriter() { Error = eb, Format = contentFormat });
                fault.Properties[WebBodyFormatMessageProperty.Name] = bodyFormat;
                fault.Properties[HttpResponseMessageProperty.Name] = responseMessage;
            }

            //记录日志
            if (!(error is BizException))
            {
                ExceptionHelper.HandleException(error);
            }
        }

        class RestServiceErrorWriter : BodyWriter
        {
            public RestServiceErrorWriter()
                : base(true)
            { }

            public ResultEntity<object> Error { get; set; }

            public WebContentFormat Format { get; set; }

            protected override BodyWriter OnCreateBufferedCopy(int maxBufferSize)
            {
                return base.OnCreateBufferedCopy(maxBufferSize);
            }

            protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
            {
                if (Format == WebContentFormat.Json)
                {
                    new DataContractJsonSerializer(typeof(ResultEntity<object>)).WriteObject(writer, Error);
                }
                else
                {
                    new DataContractSerializer(typeof(ResultEntity<object>)).WriteObject(writer, Error);
                }
            }
        }

        public bool HandleError(Exception error)
        {
            return true;
        }
    }
}
