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

namespace H.Website.IISHost.Pages.Product
{
    [AjaxPro.AjaxNamespace("Portal.ProductMaintain")]
    public partial class ProductMaintain : H.Website.Facade.PageBase
    {
        public string UploadUrl
        {
            get;
            set;
        }

        protected override void Initialize()
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(ProductMaintain));
            UploadUrl = WebConfig.UploadService;
        }

        /// <summary>
        /// 创建
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public int Create(ProductEntity obj)
        {
            obj.InDate = DateTime.Now;
            obj.InUser = WebContext.LoginUser.UserName;
            obj.Status = 0;
            if (obj.SysNo == 0)
            {
                return ProductFacade.InsertProduct(obj);
            }
            else
            {
                return ProductFacade.UpdateProduct(obj);
            }
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public int ByProductNameGetInfo(string productName, string sysno)
        {
            int SysNo;
            int.TryParse(sysno, out SysNo);
            ProductEntity entity = new ProductEntity() { ProductName = productName, SysNo = SysNo };
            ProductEntity cheEntity = ProductFacade.ByProductNameGetInfo(entity);
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
        public ProductEntity LoadEntity(string sysNo)
        {
            int SysNo;
            int.TryParse(sysNo, out SysNo);
            ProductEntity cheEntity = ProductFacade.LoadEntity(SysNo);
            return cheEntity;
        }

        /// <summary>
        /// 获取顶级权限信息
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public List<ProductTypeEntity> LoadParent()
        {
            return ProductTypeFacade.LoadParent();
        }
    }
}