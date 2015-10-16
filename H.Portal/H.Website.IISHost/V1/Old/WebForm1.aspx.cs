using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using H.Website.Facade;
using H.Core.Utility.Log;

namespace H.Website.IISHost
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object  sender, EventArgs e)
        {
            //LogFacade.ErrorToBizException();
            LogFacade.ErrorToApplicationException();
            //throw new ApplicationException("测试Website错误..");
            LogFacade.TsstMethod();
        }
    }
}