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
    public class ProductTypeService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/Search", Method = "POST")]
        public List<ProductTypeEntity> Search(QueryCondition<ProductTypeEntity> entity)
        {
            return ObjectFactory<IProductTypeDataAccess>.Instance.Search(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/InsertProductType", Method = "POST")]
        public int InsertProductType(ProductTypeEntity entity)
        {
            return ObjectFactory<IProductTypeDataAccess>.Instance.InsertProductType(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/UpdateProductType", Method = "POST")]
        public int UpdateProductType(ProductTypeEntity entity)
        {
            return ObjectFactory<IProductTypeDataAccess>.Instance.UpdateProductType(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/DeleteProductType", Method = "POST")]
        public int DeleteProductType(string sysno)
        {
            return ObjectFactory<IProductTypeDataAccess>.Instance.DeleteProductType(sysno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/ByProductTypeNameGetInfo", Method = "POST")]
        public ProductTypeEntity ByProductTypeNameGetInfo(ProductTypeEntity entity)
        {
            return ObjectFactory<IProductTypeDataAccess>.Instance.ByProductTypeNameGetInfo(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/LoadEntity/{SysNo}", Method = "GET")]
        public ProductTypeEntity LoadEntity(string sysno)
        {
            return ObjectFactory<IProductTypeDataAccess>.Instance.LoadEntity(sysno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/LoadParent", Method = "GET")]
        public List<ProductTypeEntity> LoadParent()
        {
            return ObjectFactory<IProductTypeDataAccess>.Instance.LoadParent();
        }
    }
}
