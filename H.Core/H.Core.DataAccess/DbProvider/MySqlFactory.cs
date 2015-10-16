
namespace H.Core.DataAccess
{
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;
    using System.Text;

    internal class MySqlFactory : IDbFactory
    {
        private static MySqlFactory s_Instance = new MySqlFactory();

        public static MySqlFactory Instance
        {
            get
            {
                return s_Instance;
            }
        }

        private MySqlFactory()
        {

        }

        #region IDbFactory Members

        public System.Data.Common.DbCommand CreateCommand()
        {
            return new MySqlCommand();
        }

        public System.Data.Common.DbConnection CreateConnection()
        {
            return new MySqlConnection();
        }

        public System.Data.Common.DbConnection CreateConnection(string connectionString)
        {
            return new MySqlConnection(connectionString);
        }

        public System.Data.Common.DbDataAdapter CreateDataAdapter()
        {
            return new MySqlDataAdapter();
        }

        public System.Data.Common.DbParameter CreateParameter()
        {
            return new MySqlParameter();
        }

        #endregion
    }
}
