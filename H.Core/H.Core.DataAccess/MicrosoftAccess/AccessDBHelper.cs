using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.OleDb;
using System.Configuration; 

namespace H.Core.DataAccess.MicrosoftAccess
{
    public class AccessDBHelper
    {
        //引导数据库连接数据库调用Web.Config文件      
        private static OleDbConnection connection;
        //创建连接|DataDirectory|/SchoolDB.mdb  
        public static OleDbConnection Connection
        {//Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" & server.mappath("tushu.mdb")";Persist Security Info=False  
            get
            {
                OleDbConnection myConn = new OleDbConnection(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source=|DataDirectory|/taobao.mdb");
                string connectionString = myConn.ConnectionString;
                if (connection == null)
                {
                    connection = new OleDbConnection(connectionString);
                    //打开连接  
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
                else if (connection.State == System.Data.ConnectionState.Broken)
                {
                    connection.Close();
                    connection.Open();
                }
                return connection;
            }
        }
        //（无参）返回执行的行数(删除修改更新)  
        public static int ExecuteCommand(string safeSql)
        {
            OleDbCommand cmd = new OleDbCommand(safeSql, Connection);
            int result = cmd.ExecuteNonQuery();
            return result;
        }
        //（有参）  
        public static int ExecuteCommand(string sql, params OleDbParameter[] values)
        {
            OleDbCommand cmd = new OleDbCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            return cmd.ExecuteNonQuery();
        }
        //（无参）返回第一行第一列(删除修改更新)  
        public static int GetScalar(string safeSql)
        {
            OleDbCommand cmd = new OleDbCommand(safeSql, Connection);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        //（有参）  
        public static int GetScalar(string sql, params OleDbParameter[] values)
        {
            OleDbCommand cmd = new OleDbCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            int result = Convert.ToInt32(cmd.ExecuteScalar());
            return result;
        }
        //返回一个DataReader（查询）  
        public static OleDbDataReader GetReader(string safeSql)
        {
            OleDbCommand cmd = new OleDbCommand(safeSql, Connection);
            OleDbDataReader reader = cmd.ExecuteReader();
            return reader;
        }
        public static OleDbDataReader GetReader(string sql, params OleDbParameter[] values)
        {
            OleDbCommand cmd = new OleDbCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            OleDbDataReader reader = cmd.ExecuteReader();
            return reader;
        }

        //返回一个DataTable  
        public static DataTable GetDataSet(string safeSql)
        {
            DataSet ds = new DataSet();
            OleDbCommand cmd = new OleDbCommand(safeSql, Connection);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }
        public static DataTable GetDataSet(string sql, params OleDbParameter[] values)
        {
            DataSet ds = new DataSet();
            OleDbCommand cmd = new OleDbCommand(sql, Connection);
            cmd.Parameters.AddRange(values);
            OleDbDataAdapter da = new OleDbDataAdapter(cmd);
            da.Fill(ds);
            return ds.Tables[0];
        }  
    }
}
