using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.IDataAccess
{
    /// <summary>
    /// ProductTypeInterface
    /// </summary>
    public interface IProductTypeDataAccess
    {
        List<ProductTypeEntity> Search(QueryCondition<ProductTypeEntity> entity);

        int InsertProductType(ProductTypeEntity entity);

        int UpdateProductType(ProductTypeEntity entity);

        int DeleteProductType(string sysno);

        ProductTypeEntity ByProductTypeNameGetInfo(ProductTypeEntity entity);

        ProductTypeEntity LoadEntity(string sysno);

        List<ProductTypeEntity> LoadParent();
    }
}

