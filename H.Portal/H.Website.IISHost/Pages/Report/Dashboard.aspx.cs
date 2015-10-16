﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H.Website.IISHost.Page.Report
{
    public partial class Dashboard : H.Website.Facade.PageBase
    {
        /// <summary>
        /// 不需登录验证
        /// </summary>
        protected override bool RequireAuth
        {
            get { return true; }
        }
    }
}