
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
    /// BrowsingHistoryDA
    /// </summary>
    [VersionExport(typeof(IBrowsingHistoryDataAccess))]
    public class BrowsingHistoryDataAccess : IBrowsingHistoryDataAccess
    {
        public List<BrowsingHistoryEntity> Search(QueryCondition<BrowsingHistoryEntity> entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("BrowsingHistorySearch");
            using (DynamicSqlBuilder sqlBuilder = new DynamicSqlBuilder(command, entity.PagingInfo, "SysNo Desc"))
            {
                BrowsingHistoryEntity query = entity.Condition;
                sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " Status <> -1");
                if (query != null)
                {
                    if (!string.IsNullOrEmpty(query.PageName))
                    {
                        sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " (PageName Like'%'+@PageName+'%')");
                        command.AddInputParameter("@PageName", DbType.String, query.PageName);
                    }
                }
                command.CommandText = sqlBuilder.BuildQuerySql();
                return command.ExecuteEntityList<BrowsingHistoryEntity>();
            }
        }

        public int InsertBrowsingHistory(BrowsingHistoryEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("InsertBrowsingHistory");
            command.SetParameterValue("@SystemUserSysNo", entity.SystemUserSysNo);
            command.SetParameterValue("@PageName", entity.PageName);
            command.SetParameterValue("@PageUrl", entity.PageUrl);
            command.SetParameterValue("@Status", entity.Status);
            command.SetParameterValue("@InUser", entity.InUser);
            command.SetParameterValue("@InDate", entity.InDate);
            object obj = command.ExecuteScalar();
            if (obj != null)
                return Convert.ToInt32(obj);
            else
                return 0;
        }
        
        public int UpdateBrowsingHistory(BrowsingHistoryEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("UpdateBrowsingHistory");
            command.SetParameterValue("@SysNo", entity.SysNo);
            command.SetParameterValue("@SystemUserSysNo", entity.SystemUserSysNo);
            command.SetParameterValue("@PageName", entity.PageName);
            command.SetParameterValue("@PageUrl", entity.PageUrl);
            command.SetParameterValue("@Status", entity.Status);
            command.SetParameterValue("@InUser", entity.InUser);
            command.SetParameterValue("@InDate", entity.InDate);
            return command.ExecuteNonQuery();
        }

        public int DeleteBrowsingHistory(string sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("DeleteBrowsingHistory");
            command.CommandText = command.CommandText.Replace("#SysNo#", sysno);
            return command.ExecuteNonQuery();
        }

        public List<BrowsingHistoryEntity> BrowsingHistoryBySystemUserSysNo(string systemUserSysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("BrowsingHistoryBySystemUserSysNo");
            command.SetParameterValue("@SystemUserSysNo", systemUserSysno);
            return command.ExecuteEntityList<BrowsingHistoryEntity>();
        }
    }
}

