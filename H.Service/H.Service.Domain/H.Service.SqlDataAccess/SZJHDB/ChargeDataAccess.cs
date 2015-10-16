
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
    /// ChargeDA
    /// </summary>
    [VersionExport(typeof(IChargeDataAccess))]
    public class ChargeDataAccess : IChargeDataAccess
    {

        public List<ChargeEntity> Search(QueryCondition<ChargeEntity> entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ChargeSearch");
            using (DynamicSqlBuilder sqlBuilder = new DynamicSqlBuilder(command, entity.PagingInfo, "SysNo Desc"))
            {
                ChargeEntity query = entity.Condition;
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
                return command.ExecuteEntityList<ChargeEntity>();
            }
        }


        public int InsertCharge(ChargeEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("InsertCharge");
            command.SetParameterValue("@Title", entity.Title);
            command.SetParameterValue("@Remark", entity.Remark);
            command.SetParameterValue("@Content", entity.Content);
            command.SetParameterValue("@Field1", entity.Field1);
            command.SetParameterValue("@Field2", entity.Field2);
            command.SetParameterValue("@Field3", entity.Field3);
            command.SetParameterValue("@Field4", entity.Field4);
            command.SetParameterValue("@Field5", entity.Field5);
            command.SetParameterValue("@Status", entity.Status);
            command.SetParameterValue("@InUser", entity.InUser);
            command.SetParameterValue("@InDate", entity.InDate);

            object obj = command.ExecuteScalar();
            if (obj != null)
            {
                int result = Convert.ToInt32(obj);
                if (result > 0)
                {
                    entity.Files.ForEach(x =>
                    {
                        x.FSysNo = result;
                        new FilesDataAccess().InsertFiles(x);
                    });
                }
                return Convert.ToInt32(obj);
            }
            else
                return 0;
        }


        public int UpdateCharge(ChargeEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("UpdateCharge");
            command.SetParameterValue("@SysNo", entity.SysNo);
            command.SetParameterValue("@Title", entity.Title);
            command.SetParameterValue("@Remark", entity.Remark);
            command.SetParameterValue("@Content", entity.Content);
            command.SetParameterValue("@Field1", entity.Field1);
            command.SetParameterValue("@Field2", entity.Field2);
            command.SetParameterValue("@Field3", entity.Field3);
            command.SetParameterValue("@Field4", entity.Field4);
            command.SetParameterValue("@Field5", entity.Field5);
            command.SetParameterValue("@Status", entity.Status);
            command.SetParameterValue("@InUser", entity.InUser);
            command.SetParameterValue("@InDate", entity.InDate);
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                FilesDataAccess fda = new FilesDataAccess();
                fda.DeleteFilesByFSysNo(entity.SysNo);
                entity.Files.ForEach(x =>
                {
                    new FilesDataAccess().InsertFiles(x);
                });
            }
            return result;
        }


        public int DeleteCharge(string sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("DeleteCharge");
            command.CommandText = command.CommandText.Replace("#SysNo#", sysno);
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                FilesDataAccess fda = new FilesDataAccess();
                fda.DeleteFilesByFSysNos(sysno);
            }
            return result;
        }


        public ChargeEntity LoadEntity(string sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ChargeLoadEntity");
            command.SetParameterValue("@SysNo", sysno);
            ChargeEntity result = command.ExecuteEntity<ChargeEntity>();
            if (result != null && result.SysNo > 0)
            {
                result.Files = new FilesDataAccess().GetFileByFSysNo(result.SysNo);
            }
            return result;
        }
    }
}

