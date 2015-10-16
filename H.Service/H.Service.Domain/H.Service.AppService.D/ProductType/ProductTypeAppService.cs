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
    /// ProductTypeService
    /// </summary>
    [VersionExport(typeof(ProductTypeAppService))]
    public class ProductTypeAppService
    {
        public List<ProductTypeEntity> Search(QueryCondition<ProductTypeEntity> entity)
        {
            return ObjectFactory<IProductTypeDataAccess>.Instance.Search(entity);
        }

        public int InsertProductType(ProductTypeEntity entity)
        {
            return ObjectFactory<IProductTypeDataAccess>.Instance.InsertProductType(entity);
        }

        public int UpdateProductType(ProductTypeEntity entity)
        {
            return ObjectFactory<IProductTypeDataAccess>.Instance.UpdateProductType(entity);
        }

        public int DeleteProductType(string sysno)
        {
            return ObjectFactory<IProductTypeDataAccess>.Instance.DeleteProductType(sysno);
        }

        public ProductTypeEntity ByProductTypeNameGetInfo(ProductTypeEntity entity)
        {
            return ObjectFactory<IProductTypeDataAccess>.Instance.ByProductTypeNameGetInfo(entity);
        }

        public ProductTypeEntity LoadEntity(string sysno)
        {
            return ObjectFactory<IProductTypeDataAccess>.Instance.LoadEntity(sysno);
        }

        public List<ProductTypeEntity> LoadParent()
        {
            return ObjectFactory<IProductTypeDataAccess>.Instance.LoadParent();
        }
    }
}

