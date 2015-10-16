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
    /// ProductTypeDA
    /// </summary>
    [VersionExport(typeof(IProductTypeDataAccess))]
    public class ProductTypeDataAccess : IProductTypeDataAccess
    {
        public List<ProductTypeEntity> Search(QueryCondition<ProductTypeEntity> entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ProductTypeSearch");
            using (DynamicSqlBuilder sqlBuilder = new DynamicSqlBuilder(command, entity.PagingInfo, "SysNo Desc"))
            {
                ProductTypeEntity query = entity.Condition;
                sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " Status <> -1");
                if (query != null)
                {
                    if (!string.IsNullOrEmpty(query.ProductTypeName))
                    {
                        sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " (ProductTypeName Like'%'+@ProductTypeName+'%')");
                        command.AddInputParameter("@ProductTypeName", DbType.String, query.ProductTypeName);
                    }
                    if (query.DropParentSysNo > -1)
                    {
                        sqlBuilder.Conditions.AddCondition("ParentSysNo", DbType.Int32, "@ParentSysNo", query.DropParentSysNo);
                    }
                }
                command.CommandText = sqlBuilder.BuildQuerySql();
                return command.ExecuteEntityList<ProductTypeEntity>();
            }
        }

        public int InsertProductType(ProductTypeEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("InsertProductType");
            command.SetParameterValue("@ParentSysNo", entity.ParentSysNo);
            command.SetParameterValue("@ProductTypeName", entity.ProductTypeName);
            command.SetParameterValue("@Order", entity.Order);
            command.SetParameterValue("@Status", entity.Status);
            command.SetParameterValue("@InUser", entity.InUser);
            command.SetParameterValue("@InDate", entity.InDate);
            object obj = command.ExecuteScalar();
            if (obj != null)
                return Convert.ToInt32(obj);
            else
                return 0;
        }

        public int UpdateProductType(ProductTypeEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("UpdateProductType");
            command.SetParameterValue("@SysNo", entity.SysNo);
            command.SetParameterValue("@ParentSysNo", entity.ParentSysNo);
            command.SetParameterValue("@ProductTypeName", entity.ProductTypeName);
            command.SetParameterValue("@Order", entity.Order);
            command.SetParameterValue("@Status", entity.Status);
            command.SetParameterValue("@InUser", entity.InUser);
            command.SetParameterValue("@InDate", entity.InDate);
            return command.ExecuteNonQuery();
        }

        public int DeleteProductType(string sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("DeleteProductType");
            command.CommandText = command.CommandText.Replace("#SysNo#", sysno);
            return command.ExecuteNonQuery();
        }

        public ProductTypeEntity ByProductTypeNameGetInfo(ProductTypeEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ByProductTypeNameGetInfo");
            command.SetParameterValue("@ProductTypeName", entity.ProductTypeName);
            command.SetParameterValue("@SysNo", entity.SysNo);
            ProductTypeEntity result = command.ExecuteEntity<ProductTypeEntity>();
            return result;
        }

        public ProductTypeEntity LoadEntity(string sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ProductTypeLoadEntity");
            command.SetParameterValue("@SysNo", sysno);
            ProductTypeEntity result = command.ExecuteEntity<ProductTypeEntity>();
            return result;
        }

        public List<ProductTypeEntity> LoadParent()
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ProductTypeLoadParent");
            List<ProductTypeEntity> result = command.ExecuteEntityList<ProductTypeEntity>();
            return result;
        }
    }
}

