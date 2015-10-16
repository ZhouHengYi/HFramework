using H.Core.Utility;
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Website.Facade.Facade
{
    public class ProductFacade
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static List<ProductEntity> Search(QueryCondition<ProductEntity> entity)
        {
            return RestClient.Post<List<ProductEntity>>("ProductService/Search", entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static int InsertProduct(ProductEntity entity)
        {
            return RestClient.Post<int>("ProductService/InsertProduct", entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static int UpdateProduct(ProductEntity entity)
        {
            return RestClient.Post<int>("ProductService/UpdateProduct", entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static int DeleteProduct(string sysno)
        {
            return RestClient.Post<int>("ProductService/DeleteProduct", sysno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static ProductEntity LoadEntity(int sysno)
        {
            return RestClient.Get<ProductEntity>("ProductService/LoadEntity/" + sysno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static ProductEntity ByProductNameGetInfo(ProductEntity entity)
        {
            return RestClient.Post<ProductEntity>("ProductService/ByProductNameGetInfo", entity);
        }
        
    }
}
