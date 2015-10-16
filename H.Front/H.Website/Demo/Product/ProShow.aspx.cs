using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H.Website.Product
{
    public partial class ProShow : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            Response.Write("产品详细页面！ID ： " + Page.RouteData.Values["proSysNo"] as string);
        }
    }
}