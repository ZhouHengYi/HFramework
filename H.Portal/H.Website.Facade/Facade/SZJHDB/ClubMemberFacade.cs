using H.Core.Utility;
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Website.Facade.Facade
{
    public class ClubMemberFacade
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static List<ClubMembersEntity> Search(QueryCondition<ClubMembersEntity> entity)
        {
            return RestClient.Post<List<ClubMembersEntity>>("ClubMemberService/Search", entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static int InsertClubMembers(ClubMembersEntity entity)
        {
            return RestClient.Post<int>("ClubMemberService/InsertClubMembers", entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static int UpdateClubMembers(ClubMembersEntity entity)
        {
            return RestClient.Post<int>("ClubMemberService/UpdateClubMembers", entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static int DeleteClubMembers(string sysno)
        {
            return RestClient.Post<int>("ClubMemberService/DeleteClubMembers", sysno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static ClubMembersEntity LoadEntity(int sysno)
        {
            return RestClient.Get<ClubMembersEntity>("ClubMemberService/LoadEntity/" + sysno);
        }

    }
}
