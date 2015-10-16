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


namespace H.Website.IISHost.Pages.SystemUser
{
    [AjaxPro.AjaxNamespace("Portal.SystemUser")]
    public partial class SystemUser : H.Website.Facade.PageBase
    {
        protected override void Initialize()
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(SystemUser));
            LoadRole();
        }

        protected void LoadRole() {
            List<SystemUser_RoleEntity> list = SystemUser_RoleFacade.GetAllRole();
            list.ForEach(x => {
                lit_dropRole.Text += "<option value=\"" + x.SysNo + "\">" + x.RoleName + "</option>";
            });
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public string Search(QueryCondition<SystemUserEntity> query)
        {
            try
            {
                List<SystemUserEntity> list = SystemUserFacade.Seach(query);
                return new JsonSerializer().Serialization(list, typeof(List<SystemUserEntity>));
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
        public int Delete(string ids) {
            return SystemUserFacade.SystemUserDelete(ids);
        }
    }
}