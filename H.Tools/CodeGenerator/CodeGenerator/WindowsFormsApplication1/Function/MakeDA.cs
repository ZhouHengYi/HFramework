using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using autocoder.Function;

namespace WindowsFormsApplication1.Function
{
    class MakeDA
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
            retCode.Append(XmlHelper.DA_Assembly());
            retCode.Replace("$$$Remark$$$", tableRemark.ToString());
            retCode.Replace("$$$TableName$$$", tableName);
            //方法样式

            if (dv.Count > 0)
            {
                for (int i = 0; i < dv.Count; i++)//FieldName FieldType FieldLength IsIdentity
                {
                    if (dv[i]["IsPrimary"].ToString() == "1")
                    {
                        primary.Append(dv[i]["FieldName"].ToString());
                        break;
                    }
                }
            }
            retCode.Replace("$$$ParamsNoPrimary$$$", GetParams(dv, 1));
            retCode.Replace("$$$Params$$$", GetParams(dv, 2));
            return retCode.ToString();
        }

        private static string GetParams(DataView dv,int flag)
        {
            StringBuilder retCode = new StringBuilder();
            if (dv.Count > 0)
            {

                for (int i = 0; i < dv.Count; i++)//FieldName FieldType FieldLength IsIdentity
                {
                    if ( (flag == 1) ||(dv[i]["FieldName"].ToString() != "InDate" && dv[i]["FieldName"].ToString() != "InUser" && flag == 2))
                    {
                        if (dv[i]["IsPrimary"].ToString() == "1" && flag == 1)
                        {
                            continue;
                        }
                        retCode.Append("                command.SetParameterValue(\"@" + dv[i]["FieldName"].ToString() + "\",entity." + dv[i]["FieldName"].ToString() + ");\n");
                    }
                }
            }
            return retCode.ToString();
        }

        private static string GetPrimaryParams(DataView dv)
        {
            StringBuilder retCode = new StringBuilder();
            if (dv.Count > 0)
            {
                for (int i = 0; i < dv.Count; i++)//FieldName FieldType FieldLength IsIdentity
                {
                    if (dv[i]["IsPrimary"].ToString() == "1")
                    {
                        retCode.Append("                command.SetParameterValue(\"@" + dv[i]["FieldName"].ToString() + "\"," + dv[i]["FieldName"].ToString().ToLower() + ");\n");
                        break;
                    }
                }
            }
            return retCode.ToString();
        }
    }
}
