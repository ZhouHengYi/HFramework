using H.Entity;
using H.Website.Facade.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H.Website.IISHost.UserContorl.SystemUser
{
    public partial class SystemUser_RoleMapping : System.Web.UI.UserControl
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                InitRole();
            }
        }

        public void InitRole()
        {
            List<SystemUser_RoleEntity> list = SystemUser_RoleFacade.GetAllRole();
            rp_roleList.DataSource = list;
            rp_roleList.DataBind();
        }
    }
}