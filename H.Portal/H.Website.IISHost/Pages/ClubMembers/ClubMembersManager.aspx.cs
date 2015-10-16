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

namespace H.Website.IISHost.Pages.ClubMembers
{
    [AjaxPro.AjaxNamespace("Portal.ClubMembersManager")]
    public partial class ClubMembersManager : H.Website.Facade.PageBase
    {
        /// <summary>
        /// 不需登录验证
        /// </summary>
        protected override bool RequireAuth
        {
            get { return true; }
        }

        protected override void Initialize()
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(ClubMembersManager));
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public string Search(QueryCondition<ClubMembersEntity> query)
        {
            try
            {
                List<ClubMembersEntity> list = ClubMemberFacade.Search(query);
                return new JsonSerializer().Serialization(list, typeof(List<ClubMembersEntity>));
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
            return ClubMemberFacade.DeleteClubMembers(ids);
        }
    }
}