
namespace H.Core.DataAccess
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal static class DbFactories
    {
        public static IDbFactory GetFactory(ProviderType providerType)
        {
            switch (providerType)
            {
                case ProviderType.SqlServer:
                    return SqlServerFactory.Instance;
                case ProviderType.Odbc:
                    return OdbcFactory.Instance;
                case ProviderType.MySql:
                    return MySqlFactory.Instance;
                default:
                    return OleDbFactory.Instance;
            }
        }
    }

    public enum ProviderType
    {
        SqlServer,
        Odbc,
        OleDb,
        MySql
    }
}
