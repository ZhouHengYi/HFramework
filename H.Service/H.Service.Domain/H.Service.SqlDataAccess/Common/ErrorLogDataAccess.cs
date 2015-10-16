
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
    /// 错误日志表DA
    /// </summary>
    [VersionExport(typeof(IErrorLogDataAccess))]
    public class ErrorLogDataAccess : IErrorLogDataAccess
    {
        public List<ErrorLogEntity> Seach(QueryCondition<ErrorLogEntity> entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ErrorLogSearch");
            using (DynamicSqlBuilder sqlBuilder = new DynamicSqlBuilder(command, entity.PagingInfo, "SysNo Desc"))
            {
                ErrorLogEntity query = entity.Condition;
                if (query != null)
                {
                    if (!string.IsNullOrEmpty(query.GlobalName))
                    {
                        sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " (GlobalName Like'%'+@GlobalName+'%')");
                        command.AddInputParameter("@GlobalName", DbType.String, query.GlobalName);
                        //sqlBuilder.Conditions.AddCondition("UserName", DbType.String, "@UserName", query.UserName);
                    }
                }
                command.CommandText = sqlBuilder.BuildQuerySql();
                return command.ExecuteEntityList<ErrorLogEntity>();
            }
        }

        public ErrorLogEntity GetDetails(string sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ErrorLogGetDetails");
            command.SetParameterValue("@SysNo", sysno);
            ErrorLogEntity result = command.ExecuteEntity<ErrorLogEntity>();
            return result;
        }
    }
}

