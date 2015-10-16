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
    public class ClubMemberService
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/Search", Method = "POST")]
        public List<ClubMembersEntity> Search(QueryCondition<ClubMembersEntity> entity)
        {
            return ObjectFactory<IClubMembersDataAccess>.Instance.Search(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/InsertClubMembers", Method = "POST")]
        public int InsertClubMembers(ClubMembersEntity entity)
        {
            return ObjectFactory<IClubMembersDataAccess>.Instance.InsertClubMembers(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/UpdateClubMembers", Method = "POST")]
        public int UpdateClubMembers(ClubMembersEntity entity)
        {
            return ObjectFactory<IClubMembersDataAccess>.Instance.UpdateClubMembers(entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/DeleteClubMembers", Method = "POST")]
        public int DeleteClubMembers(string sysno)
        {
            return ObjectFactory<IClubMembersDataAccess>.Instance.DeleteClubMembers(sysno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        [WebInvoke(UriTemplate = "/LoadEntity/{SysNo}", Method = "GET")]
        public ClubMembersEntity LoadEntity(string sysno)
        {
            return ObjectFactory<IClubMembersDataAccess>.Instance.LoadEntity(sysno);
        }
    }
}
