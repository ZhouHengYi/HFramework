using H.Entity;
using H.Website.Facade;
using H.Website.Facade.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H.Website.IISHost.Pages.Common
{
    public partial class BrowsingHistory : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string cmd = Request["cmd"];
                switch (cmd)
                {
                    case "add":
                        string pageName = Request["pageName"];
                        string pageUrl = Request["pageUrl"];
                        BrowsingHistoryEntity entity = new BrowsingHistoryEntity() { 
                            PageName = pageName,
                            PageUrl = pageUrl,
                            SystemUserSysNo = WebContext.LoginUser.SysNo,
                            InUser = WebContext.LoginUser.UserName,
                            InDate = DateTime.Now
                        };
                        new BrowsingHistoryFacade().InsertBrowsingHistory(entity);
                        break;
                    case "get":

                        break;
                }
            }
        }
    }
}