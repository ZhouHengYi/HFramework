
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
    /// ManagementDA
    /// </summary>
    [VersionExport(typeof(IManagementDataAccess))]
    public class ManagementDataAccess : IManagementDataAccess
    {

        public List<ManagementEntity> Search(QueryCondition<ManagementEntity> entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ManagementSearch");
            using (DynamicSqlBuilder sqlBuilder = new DynamicSqlBuilder(command, entity.PagingInfo, "SysNo Desc"))
            {
                ManagementEntity query = entity.Condition;
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
                return command.ExecuteEntityList<ManagementEntity>();
            }
        }


        public int InsertManagement(ManagementEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("InsertManagement");
            command.SetParameterValue("@Title", entity.Title);
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
                    entity.Files.ForEach(x => {
                        x.FSysNo = result;
                        new FilesDataAccess().InsertFiles(x);
                    });
                }
                return Convert.ToInt32(obj);
            }
            else
                return 0;
        }


        public int UpdateManagement(ManagementEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("UpdateManagement");
            command.SetParameterValue("@SysNo", entity.SysNo);
            command.SetParameterValue("@Title", entity.Title);
            command.SetParameterValue("@Content", entity.Content);
            command.SetParameterValue("@Field1", entity.Field1);
            command.SetParameterValue("@Field2", entity.Field2);
            command.SetParameterValue("@Field3", entity.Field3);
            command.SetParameterValue("@Field4", entity.Field4);
            command.SetParameterValue("@Field5", entity.Field5);
            command.SetParameterValue("@Status", entity.Status);
            command.SetParameterValue("@InUser", entity.InUser);
            command.SetParameterValue("@InDate", entity.InDate);
            int result= command.ExecuteNonQuery();
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


        public int DeleteManagement(string sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("DeleteManagement");
            command.CommandText = command.CommandText.Replace("#SysNo#", sysno);
            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                FilesDataAccess fda = new FilesDataAccess();
                fda.DeleteFilesByFSysNos(sysno);
            }
            return result;
        }

        public ManagementEntity LoadEntity(string sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ManagementLoadEntity");
            command.SetParameterValue("@SysNo", sysno);
            ManagementEntity result = command.ExecuteEntity<ManagementEntity>();
            if (result != null && result.SysNo > 0)
            {
                result.Files = new FilesDataAccess().GetFileByFSysNo(result.SysNo);
            }
            return result;
        }


    }
}

