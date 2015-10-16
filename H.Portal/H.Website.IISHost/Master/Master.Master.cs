using H.Website.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H.Website.IISHost.Master
{
    public partial class Master : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public string CurrentUrl
        {
            get { return HttpContext.Current.Request.CurrentExecutionFilePath; }
        }

        public string BuildUrl(Enum pageAlias)
        {
            return UrlHelper.BuildUrl(pageAlias);
        }
        public string BuildUrl(Enum pageAlias, params string[] queryString)
        {
            return UrlHelper.BuildUrl(pageAlias, queryString);
        }
    }
}