using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Threading.Tasks;
using H.Core.Utility;
using H.Entity;
using H.Core.Utility.Log;
using H.Service.IDataAccess;

namespace H.Service.Rest
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single, AddressFilterMode = AddressFilterMode.Any)]
    public class ProductService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/Search", Method = "POST")]
        public List<ProductEntity> Search(QueryCondition<ProductEntity> entity)
        {
            return ObjectFactory<IProductDataAccess>.Instance.Search(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/InsertProduct", Method = "POST")]
        public int InsertProduct(ProductEntity entity)
        {
            return ObjectFactory<IProductDataAccess>.Instance.InsertProduct(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/UpdateProduct", Method = "POST")]
        public int UpdateProduct(ProductEntity entity)
        {
            return ObjectFactory<IProductDataAccess>.Instance.UpdateProduct(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/DeleteProduct", Method = "POST")]
        public int DeleteProduct(string sysno)
        {
            return ObjectFactory<IProductDataAccess>.Instance.DeleteProduct(sysno);
        }
        
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/LoadEntity/{SysNo}", Method = "GET")]
        public ProductEntity LoadEntity(string sysno)
        {
            return ObjectFactory<IProductDataAccess>.Instance.LoadEntity(sysno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/ByProductNameGetInfo", Method = "POST")]
        public ProductEntity ByProductNameGetInfo(ProductEntity entity)
        {
            return ObjectFactory<IProductDataAccess>.Instance.ByProductNameGetInfo(entity);
        }
    }
}
