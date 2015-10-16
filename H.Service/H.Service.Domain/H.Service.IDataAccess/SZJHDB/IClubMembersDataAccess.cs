
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.IDataAccess
{
    /// <summary>
    /// ClubMembersInterface
    /// </summary>
    public interface IClubMembersDataAccess
    {

        List<ClubMembersEntity> Search(QueryCondition<ClubMembersEntity> entity);

        int InsertClubMembers(ClubMembersEntity entity);

        int UpdateClubMembers(ClubMembersEntity entity);

        int DeleteClubMembers(string sysno);


        ClubMembersEntity LoadEntity(string sysno);
    }
}

