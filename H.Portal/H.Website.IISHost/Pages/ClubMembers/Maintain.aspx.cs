using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using H.Website.Facade;
using H.Entity;
using H.Website.Facade.Facade;

namespace H.Website.IISHost.Pages.ClubMembers
{
    [AjaxPro.AjaxNamespace("Portal.Maintain")]
    public partial class Maintain : H.Website.Facade.PageBase
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

        /// <summary>
        /// 不需登录验证
        /// </summary>
        protected override bool RequireAuth
        {
            get { return true; }
        }

        protected override void Initialize()
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Maintain));
            UploadUrl = H.Core.Utility.WebConfig.UploadService;
            UploadImageUrl = H.Core.Utility.WebConfig.UploadImageUrl;

        }/// <summary>
        /// 根据系统编号获取用户信息
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public ClubMembersEntity LoadEntity(string sysno)
        {
            ClubMembersEntity entity = ClubMemberFacade.LoadEntity(Convert.ToInt32(sysno));
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public int Insert(ClubMembersEntity entity)
        {
            H.Core.Utility.ImageHelper ih = new Core.Utility.ImageHelper();
            entity.InDate = DateTime.Now;
            entity.InUser = WebContext.LoginUser.UserName;
            return ClubMemberFacade.InsertClubMembers(entity);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public int Update(ClubMembersEntity entity)
        {
            return ClubMemberFacade.UpdateClubMembers(entity);
        }
    }
}