using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using H.Website.Facade;
using H.Entity;
using H.Website.Facade.Facade;
using H.Core.Utility;

namespace H.Website.IISHost.Pages.SystemUser_Privilege
{
    [AjaxPro.AjaxNamespace("Portal.SystemUser_Privilege")]
    public partial class SystemUser_Privilege : H.Website.Facade.PageBase
    {
        protected override void Initialize()
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(SystemUser_Privilege));
            LoadParent();
        }

        public void LoadParent()
        {
            SystemUser_PrivilegeFacade.LoadParent().ForEach(x =>
            {
                lit_parentSysNo.Text += "<option value=\"" + x.SysNo + "\">" + x.PrivilegeName + "</option>";
            });
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public string Search(QueryCondition<SystemUser_PrivilegeEntity> query)
        {
            try
            {
                List<SystemUser_PrivilegeEntity> list = SystemUser_PrivilegeFacade.Seach(query);
                return new JsonSerializer().Serialization(list, typeof(List<SystemUser_PrivilegeEntity>));
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// 批量删除选中信息
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public int Delete(string ids)
        {
            return SystemUser_PrivilegeFacade.DeleteSystemUser_Privilege(ids);
        }
    }
}