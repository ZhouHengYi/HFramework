using H.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace H.Website
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
            AutorunManager.Startup(ex =>
            {
                ExceptionHelper.HandleException(ex);
            });
        }

        protected void Session_Start(object sender, EventArgs e)
        {

        }

        protected void Application_BeginRequest(object sender, EventArgs e)
        {

        }

        protected void Application_AuthenticateRequest(object sender, EventArgs e)
        {

        }

        protected void Application_Error(object sender, EventArgs e)
        {
            //不记录自定义异常信息
            Exception ex = HttpContext.Current.Server.GetLastError();

            if (!(ex.InnerException is BizException) && ex.InnerException != null)
            {
                ExceptionHelper.HandleException(ex);
            }
            else if (ex.InnerException is BizException)
            {
                Response.Write(new XmlSerializer().Serialization(ex, ex.GetType()));
                Response.End();
            }
        }

        protected void Session_End(object sender, EventArgs e)
        {

        }

        protected void Application_End(object sender, EventArgs e)
        {

        }
    }
}