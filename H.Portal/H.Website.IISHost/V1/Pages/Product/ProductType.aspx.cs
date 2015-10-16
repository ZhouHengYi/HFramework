﻿using H.Core.Utility;
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
    [AjaxPro.AjaxNamespace("Portal.ProductType")]
    public partial class ProductType : H.Website.Facade.PageBase
    {
        protected override void Initialize()
        {
            AjaxPro.Utility.RegisterTypeForAjax(typeof(ProductType));
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
        public string Search(QueryCondition<ProductTypeEntity> query)
        {
            try
            {
                List<ProductTypeEntity> list = ProductTypeFacade.Search(query);
                return new JsonSerializer().Serialization(list, typeof(List<ProductTypeEntity>));
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
            return ProductTypeFacade.DeleteProductType(ids);
        }
    }
}