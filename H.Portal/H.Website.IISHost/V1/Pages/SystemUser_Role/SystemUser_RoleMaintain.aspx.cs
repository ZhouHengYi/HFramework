using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using H.Website.Facade;
using H.Entity;
using H.Website.Facade.Facade;

namespace H.Website.IISHost.Pages.SystemUser_Role
{
    [AjaxPro.AjaxNamespace("Portal.SystemUser_RoleMaintain")]
    public partial class SystemUser_RoleMaintain : H.Website.Facade.PageBase
    {
        public List<SystemUser_PrivilegeEntity> Privilege
        {
            set { ViewState["Privilege"] = value; }
            get { return ViewState["Privilege"] as List<SystemUser_PrivilegeEntity>; }
        }

        protected override void Initialize()
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(SystemUser_RoleMaintain));
            LoadPrivilege();
        }       

        public void LoadPrivilege() {
            Privilege = SystemUser_PrivilegeFacade.GetALlPrivilege(); ;
            rp_parentPrivilege.DataSource = Privilege.FindAll(x => { return x.ParentSysNo == 0; });
            rp_parentPrivilege.DataBind();
        }

        protected void rp_parentPrivilege_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            Repeater child = e.Item.FindControl("rp_childPrivilege") as Repeater;
            HiddenField hide = e.Item.FindControl("hideSysNo") as HiddenField;
            child.DataSource = Privilege.FindAll(x => { return x.ParentSysNo == Convert.ToInt32(hide.Value); });
            child.DataBind();
        }

        /// <summary>
        /// 创建
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public int Create(SystemUser_RoleEntity obj)
        {
            obj.InDate = DateTime.Now;
            obj.InUser = WebContext.LoginUser.UserName;
            obj.Status = 0;
            if (obj.SysNo == 0)
            {
                return SystemUser_RoleFacade.InsertSystemUser_Role(obj);
            }
            else
            {
                return SystemUser_RoleFacade.UpdateSystemUser_Role(obj);
            }
        }

        /// <summary>
        /// 检查角色是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public int ByRoleNameGetInfo(string roleName, string sysno)
        {
            int SysNo;
            int.TryParse(sysno, out SysNo);
            SystemUser_RoleEntity entity = new SystemUser_RoleEntity() { RoleName = roleName, SysNo = SysNo };
            SystemUser_RoleEntity cheEntity = SystemUser_RoleFacade.ByRoleNameGetInfo(entity);
            if (cheEntity == null || cheEntity.SysNo == 0)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public SystemUser_RoleEntity LoadEntity(string sysNo)
        {
            int SysNo;
            int.TryParse(sysNo, out SysNo);
            SystemUser_RoleEntity cheEntity = SystemUser_RoleFacade.LoadEntity(SysNo);
            return cheEntity;
        }
    }
}