using H.Core.Utility;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H.Portal.IISHost.UploadDemo
{
    public partial class UploadImage : System.Web.UI.Page
    {
        public string UploadUrl
        {
            get;
            set;
        }

        public string UploadImageUrl
        {
            get;
            set;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                UploadUrl = H.Core.Utility.WebConfig.UploadService;
                UploadImageUrl = H.Core.Utility.WebConfig.UploadImageUrl;
            }
        }
    }
}