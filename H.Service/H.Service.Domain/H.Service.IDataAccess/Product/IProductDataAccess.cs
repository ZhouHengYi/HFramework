
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.IDataAccess
{
    /// <summary>
    /// ProductInterface
    /// </summary>
    public interface IProductDataAccess
    {

        List<ProductEntity> Search(QueryCondition<ProductEntity> entity);

        int InsertProduct(ProductEntity entity);

        int UpdateProduct(ProductEntity entity);

        int DeleteProduct(string sysno);

        ProductEntity LoadEntity(string sysno);

        ProductEntity ByProductNameGetInfo(ProductEntity entity);
    }
}

