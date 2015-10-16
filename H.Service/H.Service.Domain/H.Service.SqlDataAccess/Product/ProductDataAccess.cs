
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
    /// ProductDA
    /// </summary>
    [VersionExport(typeof(IProductDataAccess))]
    public class ProductDataAccess : IProductDataAccess
    {

        public List<ProductEntity> Search(QueryCondition<ProductEntity> entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ProductSearch");
            using (DynamicSqlBuilder sqlBuilder = new DynamicSqlBuilder(command, entity.PagingInfo, "sm.SysNo Desc"))
            {
                ProductEntity query = entity.Condition;
                sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " sm.Status <> -1");
                if (query != null)
                {
                    if (!string.IsNullOrEmpty(query.ProductName))
                    {
                        sqlBuilder.Conditions.AddCustomCondition(RelationType.AND, " (ProductName Like'%'+@ProductName+'%')");
                        command.AddInputParameter("@ProductName", DbType.String, query.ProductName);
                    }
                    if (query.DropProductTypeSysNo > 0)
                    {
                        sqlBuilder.Conditions.AddCondition("ProductTypeSysNo", DbType.Int32, "@ProductTypeSysNo", query.DropProductTypeSysNo);
                    }
                }
                command.CommandText = sqlBuilder.BuildQuerySql();
                return command.ExecuteEntityList<ProductEntity>();
            }
        }

        public int InsertProduct(ProductEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("InsertProduct");
            command.SetParameterValue("@ProductTypeSysNo", entity.ProductTypeSysNo);
            command.SetParameterValue("@ProductName", entity.ProductName);
            command.SetParameterValue("@Price", entity.Price);
            command.SetParameterValue("@Weight", entity.Weight);
            command.SetParameterValue("@Mdient", entity.Mdient);
            command.SetParameterValue("@Sdient", entity.Sdient);
            command.SetParameterValue("@Method", entity.Method);
            command.SetParameterValue("@Order", entity.Order);
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

        public int UpdateProduct(ProductEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("UpdateProduct");
            command.SetParameterValue("@SysNo", entity.SysNo);
            command.SetParameterValue("@ProductTypeSysNo", entity.ProductTypeSysNo);
            command.SetParameterValue("@ProductName", entity.ProductName);
            command.SetParameterValue("@Price", entity.Price);
            command.SetParameterValue("@Weight", entity.Weight);
            command.SetParameterValue("@Mdient", entity.Mdient);
            command.SetParameterValue("@Sdient", entity.Sdient);
            command.SetParameterValue("@Method", entity.Method);
            command.SetParameterValue("@Order", entity.Order);
            command.SetParameterValue("@SmallImageUrl", entity.SmallImageUrl);
            command.SetParameterValue("@BigImageUrl", entity.BigImageUrl);
            command.SetParameterValue("@Status", entity.Status);
            command.SetParameterValue("@InUser", entity.InUser);
            command.SetParameterValue("@InDate", entity.InDate);
            return command.ExecuteNonQuery();
        }

        public int DeleteProduct(string sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("DeleteProduct");
            command.CommandText = command.CommandText.Replace("#SysNo#", sysno);
            return command.ExecuteNonQuery();
        }

        public ProductEntity LoadEntity(string sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ProductLoadEntity");
            command.SetParameterValue("@SysNo", sysno);
            ProductEntity result = command.ExecuteEntity<ProductEntity>();
            return result;
        }

        public ProductEntity ByProductNameGetInfo(ProductEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("ByProductNameGetInfo");
            command.SetParameterValue("@ProductName", entity.ProductName);
            command.SetParameterValue("@SysNo", entity.SysNo);
            ProductEntity result = command.ExecuteEntity<ProductEntity>();
            return result;
        }
    }
}

