using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using H.Website.Facade;
using H.Entity;
using H.Website.Facade.Facade;

namespace H.Website.IISHost.Pages.Product
{
    [AjaxPro.AjaxNamespace("Portal.ProductTypeMaintain")]
    public partial class ProductTypeMaintain : H.Website.Facade.PageBase
    {
        protected override void Initialize()
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(ProductTypeMaintain));
        }

        /// <summary>
        /// 创建
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public int Create(ProductTypeEntity obj)
        {
            obj.InDate = DateTime.Now;
            obj.InUser = WebContext.LoginUser.UserName;
            obj.Status = 0;
            if (obj.SysNo == 0)
            {
                return ProductTypeFacade.InsertProductType(obj);
            }
            else
            {
                return ProductTypeFacade.UpdateProductType(obj);
            }
        }

        /// <summary>
        /// 检查用户名是否存在
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        [AjaxPro.AjaxMethod()]
        public int ByProductTypeNameGetInfo(string productTypeName, string sysno)
        {
            int SysNo;
            int.TryParse(sysno, out SysNo);
            ProductTypeEntity entity = new ProductTypeEntity() { ProductTypeName = productTypeName, SysNo = SysNo };
            ProductTypeEntity cheEntity = ProductTypeFacade.ByProductTypeNameGetInfo(entity);
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
        public ProductTypeEntity LoadEntity(string sysNo)
        {
            int SysNo;
            int.TryParse(sysNo, out SysNo);
            ProductTypeEntity cheEntity = ProductTypeFacade.LoadEntity(SysNo);
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