
namespace H.Core.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Data.Common;

    public interface IDbFactory
    {
        DbCommand CreateCommand();
        DbConnection CreateConnection();
        DbConnection CreateConnection(string connectionString);
        DbDataAdapter CreateDataAdapter();
        DbParameter CreateParameter();
    }
}
