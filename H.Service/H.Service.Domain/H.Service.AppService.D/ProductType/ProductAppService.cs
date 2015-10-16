
using H.Core.Utility;
using H.Core.Utility.Log;
using H.Entity;
using H.Service.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.AppService
{
    /// <summary>
    /// ProductService
    /// </summary>
    [VersionExport(typeof(ProductAppService))]
    public class ProductAppService
    {

        public List<ProductEntity> Search(QueryCondition<ProductEntity> entity)
        {
            return ObjectFactory<IProductDataAccess>.Instance.Search(entity);
        }

        public int InsertProduct(ProductEntity entity)
        {
            return ObjectFactory<IProductDataAccess>.Instance.InsertProduct(entity);
        }

        public int UpdateProduct(ProductEntity entity)
        {
            return ObjectFactory<IProductDataAccess>.Instance.UpdateProduct(entity);
        }

        public int DeleteProduct(string sysno)
        {
            return ObjectFactory<IProductDataAccess>.Instance.DeleteProduct(sysno);
        }

        public ProductEntity LoadEntity(string sysno)
        {
            return ObjectFactory<IProductDataAccess>.Instance.LoadEntity(sysno);
        }

        public ProductEntity ByProductNameGetInfo(ProductEntity entity) {
            return ObjectFactory<IProductDataAccess>.Instance.ByProductNameGetInfo(entity);
        }
    }
}

