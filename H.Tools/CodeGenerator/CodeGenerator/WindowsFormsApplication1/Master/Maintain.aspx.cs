using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using H.Website.Facade;
using H.Entity;

namespace H.Website.IISHost.Pages.$$$TableName$$$
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

        }

        /// <summary>
        /// 根据系统编号获取用户信息
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public $$$TableName$$$Entity LoadEntity(string sysno)
        {
            $$$TableName$$$Entity entity = $$$TableName$$$Facade.LoadEntity(Convert.ToInt32(sysno));
            return entity;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public int Insert($$$TableName$$$Entity entity)
        {
            entity.InDate = DateTime.Now;
            entity.InUser = WebContext.LoginUser.UserName;
            if (entity.Files != null && entity.Files.Count > 0)
            {
                entity.Files.ForEach(x =>
                {
                    x.InDate = DateTime.Now;
                    x.InUser = WebContext.LoginUser.UserName;
                });
            }
            return $$$TableName$$$Facade.Insert$$$TableName$$$(entity);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public int Update($$$TableName$$$Entity entity)
        {
            if (entity.Files != null && entity.Files.Count > 0)
            {
                entity.Files.ForEach(x =>
                {
                    x.InDate = DateTime.Now;
                    x.InUser = WebContext.LoginUser.UserName;
                    x.FSysNo = entity.SysNo;
                });
            }
            return $$$TableName$$$Facade.Update$$$TableName$$$(entity);
        }
    }
}