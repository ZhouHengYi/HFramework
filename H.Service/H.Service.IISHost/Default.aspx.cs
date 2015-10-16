using H.Core.Rest;
using H.Core.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H.Service.IISHost
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ServiceList list = XmlHelper.LoadFromXmlCache<ServiceList>(GetConfigPath());
            Response.Write("<ul>");
            list.ItemList.ForEach(item => {
                Response.Write("<li><a href=\"/" + item.Path + "\">" + item.Path + "</a></li>");
            });
            Response.Write("</ul>");
        }

        private string GetConfigPath()
        {
            string path = WebConfig.RestServiceConfigPath;
            if (path == null || path.Trim().Length <= 0)
            {
                return Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Configuration/RestService.config");
            }
            string p = Path.GetPathRoot(path);
            if (p == null || p.Trim().Length <= 0) // 说明是相对路径
            {
                path = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, path);
            }
            return path;
        }
    }
}