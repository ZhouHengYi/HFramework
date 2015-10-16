
using H.Core.DataAccess;
using H.Core.Utility;
using H.Entity;
using H.Service.IDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace H.Service.SqlDataAccess
{
    /// <summary>
    /// ClubMembersDA
    /// </summary>
    [VersionExport(typeof(IClubMembersDataAccess))]
    public class ClubMembersDataAccess : IClubMembersDataAccess
    {

        public List<ClubMembersEntity> Search(QueryCondition<ClubMembersEntity> entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ClubMembersSearch");
            using (DynamicSqlBuilder sqlBuilder = new DynamicSqlBuilder(command, entity.PagingInfo, "SysNo Desc"))
            {
                ClubMembersEntity query = entity.Condition;
                sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " Status <> -1");
                if (query != null)
                {
                    if (!string.IsNullOrEmpty(query.Title))
                    {
                        sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " (Title Like'%'+@Title+'%')");
                        command.AddInputParameter("@Title", DbType.String, query.Title);
                    }
                    if (!string.IsNullOrEmpty(query.InDateCondition) &&
                        query.InDateCondition.IndexOf('-') > 0)
                    {
                        sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " InDate BETWEEN @BeginInDate AND @EndInDate");
                        command.AddInputParameter("@BeginInDate", DbType.String, query.InDateCondition.Split('-')[0]);
                        command.AddInputParameter("@EndInDate", DbType.String, query.InDateCondition.Split('-')[1]);
                    }
                }
                command.CommandText = sqlBuilder.BuildQuerySql();
                return command.ExecuteEntityList<ClubMembersEntity>();
            }
        }


        public int InsertClubMembers(ClubMembersEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("InsertClubMembers");
            command.SetParameterValue("@Title", entity.Title);
            command.SetParameterValue("@SmallImageUrl", entity.SmallImageUrl);
            command.SetParameterValue("@BigImageUrl", entity.BigImageUrl);
            command.SetParameterValue("@Status", entity.Status);
            command.SetParameterValue("@InUser", entity.InUser);
            command.SetParameterValue("@InDate", entity.InDate);
            object obj = command.ExecuteScalar();
            if (obj != null)
                return Convert.ToInt32(obj);
            else
                return 0;

        }


        public int UpdateClubMembers(ClubMembersEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("UpdateClubMembers");
            command.SetParameterValue("@SysNo", entity.SysNo);
            command.SetParameterValue("@Title", entity.Title);
            command.SetParameterValue("@SmallImageUrl", entity.SmallImageUrl);
            command.SetParameterValue("@BigImageUrl", entity.BigImageUrl);
            command.SetParameterValue("@Status", entity.Status);
            return command.ExecuteNonQuery();

        }


        public int DeleteClubMembers(string sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("DeleteClubMembers");
            command.CommandText = command.CommandText.Replace("#SysNo#", sysno);
            return command.ExecuteNonQuery();
        }

        public ClubMembersEntity LoadEntity(string sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ClubMembersLoadEntity");
            command.SetParameterValue("@SysNo", sysno);
            ClubMembersEntity result = command.ExecuteEntity<ClubMembersEntity>();
            return result;
        }
    }
}

