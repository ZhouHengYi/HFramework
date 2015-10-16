using H.Core.Utility;
using H.Entity;
using H.Website.Facade.Facade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace H.Website.IISHost.Pages.Product
{
    [AjaxPro.AjaxNamespace("Portal.Product")]
    public partial class Product : H.Website.Facade.PageBase
    {
        protected override void Initialize()
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(Product));
            LoadParent();
        }

        public void LoadParent()
        {
            ProductTypeFacade.LoadParent().ForEach(x =>
            {
                lit_parentSysNo.Text += "<option value=\"" + x.SysNo + "\">" + x.ProductTypeName + "</option>";
            });
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        [AjaxPro.AjaxMethod()]
        public string Search(QueryCondition<ProductEntity> query)
        {
            try
            {
                List<ProductEntity> list = ProductFacade.Search(query);
                return new JsonSerializer().Serialization(list, typeof(List<ProductEntity>));
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
            return ProductFacade.DeleteProduct(ids);
        }
    }
}