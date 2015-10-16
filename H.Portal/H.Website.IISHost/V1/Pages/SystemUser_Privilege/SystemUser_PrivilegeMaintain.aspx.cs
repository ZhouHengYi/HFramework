using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using H.Website.Facade;
using H.Entity;
using H.Website.Facade.Facade;

namespace H.Website.IISHost.Pages.SystemUser_Privilege
{
    [AjaxPro.AjaxNamespace("Portal.SystemUser_PrivilegeMaintain")]
    public partial class SystemUser_PrivilegeMaintain : H.Website.Facade.PageBase
    {
        protected override void Initialize()
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(SystemUser_PrivilegeMaintain));
        }

        /// <summary>
        /// 创建
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public int Create(SystemUser_PrivilegeEntity obj)
        {
            obj.InDate = DateTime.Now;
            obj.InUser = WebContext.LoginUser.UserName;
            obj.Status = 0;
            if (obj.SysNo == 0)
            {
                return SystemUser_PrivilegeFacade.InsertSystemUser_Privilege(obj);
            }
            else
            {
                return SystemUser_PrivilegeFacade.UpdateSystemUser_Privilege(obj);
            }
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public int ByPrivilegeNameGetInfo(string privilegeName,string sysno)
        {
            int SysNo;
            int.TryParse(sysno,out SysNo);
            SystemUser_PrivilegeEntity entity = new SystemUser_PrivilegeEntity() { PrivilegeName = privilegeName, SysNo = SysNo };
            SystemUser_PrivilegeEntity cheEntity = SystemUser_PrivilegeFacade.ByPrivilegeNameGetInfo(entity);
            if (cheEntity == null || cheEntity.SysNo == 0)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public int ByPageAliceGetInfo(string pageAlice,string sysno)
        {
            int SysNo;
            int.TryParse(sysno, out SysNo);
            SystemUser_PrivilegeEntity entity = new SystemUser_PrivilegeEntity() { PageAlice = pageAlice, SysNo = SysNo };
            SystemUser_PrivilegeEntity cheEntity = SystemUser_PrivilegeFacade.ByPageAliceGetInfo(entity);
            if (cheEntity == null || cheEntity.SysNo == 0)
            {
                return 1;
            }
            return 0;
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public SystemUser_PrivilegeEntity LoadEntity(string sysNo)
        {
            int SysNo;
            int.TryParse(sysNo,out SysNo);
            SystemUser_PrivilegeEntity cheEntity = SystemUser_PrivilegeFacade.LoadEntity(SysNo);
            return cheEntity;
        }

        /// <summary>
        /// 获取顶级权限信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public List<SystemUser_PrivilegeEntity> LoadParent() {
            return SystemUser_PrivilegeFacade.LoadParent();
        }
    }
}