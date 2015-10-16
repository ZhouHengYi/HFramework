using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using autocoder.Function;

namespace WindowsFormsApplication1.Function
{
    class MakeFacade
    {
        private static DataSet dsTableDetails;//表字段详细信息
        protected static DataSet TabDetails;    //表详细信息

        public static string GetCode(string CON, string dbName, string tableName)
        {
            TabDetails = SqlHelper.ExecuteDataset(CON, CommandType.Text, Common.GetTabDetails(dbName, tableName));
            dsTableDetails = SqlHelper.ExecuteDataset(CON, CommandType.Text, string.Format(Common.GetTableDetails, dbName, tableName));
            DataView dv = new DataView(dsTableDetails.Tables[0]);

            StringBuilder primary = new StringBuilder(100);
            StringBuilder tableRemark = new StringBuilder(100);
            StringBuilder defaultStructure = new StringBuilder(100);
            StringBuilder content = new StringBuilder(100);

            if (TabDetails != null && TabDetails.Tables.Count > 0 && TabDetails.Tables[0].Rows.Count > 0)
                tableRemark.Append(TabDetails.Tables[0].Rows[0]["Remark"].ToString());
            else
                tableRemark.Append(tableName);

            StringBuilder retCode = new StringBuilder(1000);
            retCode.Append(XmlHelper.Facade_Assembly());
            retCode.Replace("$$$Remark$$$", tableRemark.ToString());
            retCode.Replace("$$$TableName$$$", tableName);

            return retCode.ToString();
        }
    }
}
