using H.Core.Utility;
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Website.Facade.Facade
{
    public class ProductTypeFacade
    {
        public static List<ProductTypeEntity> Search(QueryCondition<ProductTypeEntity> entity)
        {
            return RestClient.Post<List<ProductTypeEntity>>("ProductTypeService/Search", entity);
        }

        public static int InsertProductType(ProductTypeEntity entity)
        {
            return RestClient.Post<int>("ProductTypeService/InsertProductType", entity);
        }

        public static int UpdateProductType(ProductTypeEntity entity)
        {
            return RestClient.Post<int>("ProductTypeService/UpdateProductType", entity);
        }

        public static int DeleteProductType(string sysno)
        {
            return RestClient.Post<int>("ProductTypeService/DeleteProductType", sysno);
        }

        public static ProductTypeEntity ByProductTypeNameGetInfo(ProductTypeEntity entity)
        {
            return RestClient.Post<ProductTypeEntity>("ProductTypeService/ByProductTypeNameGetInfo", entity);
        }

        public static ProductTypeEntity LoadEntity(int sysno)
        {
            return RestClient.Get<ProductTypeEntity>("ProductTypeService/LoadEntity/" + sysno);
        }

        public static List<ProductTypeEntity> LoadParent()
        {
            return RestClient.Get<List<ProductTypeEntity>>("ProductTypeService/LoadParent");
        }
    }
}
