using H.Core.Utility;
using H.Entity;
using H.Website.Facade.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H.Website.IISHost.Pages.SystemUser_Role
{
    [AjaxPro.AjaxNamespace("Portal.SystemUser_Role")]
    public partial class SystemUser_Role : H.Website.Facade.PageBase
    {
        protected override void Initialize()
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(SystemUser_Role));
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public string Search(QueryCondition<SystemUser_RoleEntity> query)
        {
            try
            {
                List<SystemUser_RoleEntity> list = SystemUser_RoleFacade.Seach(query);
                return new JsonSerializer().Serialization(list, typeof(List<SystemUser_RoleEntity>));
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
            return SystemUser_RoleFacade.DeleteSystemUser_Role(ids);
        }
    }
}