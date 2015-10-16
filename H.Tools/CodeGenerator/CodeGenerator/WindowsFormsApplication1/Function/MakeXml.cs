using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;
using System.Data;
using autocoder.Function;

namespace WindowsFormsApplication1.Function
{
    class MakeXml
    {
        private static DataSet dsTableDetails;//表字段详细信息
        protected static DataSet TabDetails;    //表详细信息

        private static string GetParams(DataView dv)

        {
            StringBuilder retCode = new StringBuilder();
            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["IsPrimary"].ToString() != "1")
                {
                    string dbType = "";
                    switch (dv[i]["FieldType"].ToString())
                    {
                        case "int":
                            dbType = "Int32";
                            break;
                        case "datetime":
                            dbType = "DateTime";
                            break;
                        case "money":
                            dbType = "Decimal";
                            break;
                        case "decimal":
                            dbType = "Decimal";
                            break;
                        case "float":
                            dbType = "Double";
                            break;
                        default:
                            dbType = "String";
                            break;
                    }
                    retCode.Append("\t\t\t<param name=\"@" + dv[i]["FieldName"] + "\" dbType=\"" + dbType + "\" />\n");
                }
            }
            return retCode.ToString();
        }
        private static string GetParams2(DataView dv)
        {
            StringBuilder retCode = new StringBuilder();
            for (int i = 0; i < dv.Count; i++)
            {
                string dbType = "";
                if (dv[i]["FieldName"].ToString() != "InDate" && dv[i]["FieldName"].ToString() != "InUser")
                {
                    switch (dv[i]["FieldType"].ToString())
                    {
                        case "int":
                            dbType = "Int32";
                            break;
                        case "datetime":
                            dbType = "DateTime";
                            break;
                        case "money":
                            dbType = "Decimal";
                            break;
                        case "decimal":
                            dbType = "Decimal";
                            break;
                        case "float":
                            dbType = "Double";
                            break;
                        default:
                            dbType = "String";
                            break;
                    }
                    retCode.Append("\t\t\t<param name=\"@" + dv[i]["FieldName"] + "\" dbType=\"" + dbType + "\" />\n");
                }
            }
            return retCode.ToString();
        }
        private static string GetParams3(DataView dv)
        {
            StringBuilder retCode = new StringBuilder();
            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["IsPrimary"].ToString() == "1")
                {
                    string dbType = "";
                    switch (dv[i]["FieldType"].ToString())
                    {
                        case "int":
                            dbType = "Int32";
                            break;
                        case "datetime":
                            dbType = "DateTime";
                            break;
                        case "money":
                            dbType = "Decimal";
                            break;
                        case "decimal":
                            dbType = "Decimal";
                            break;
                        case "float":
                            dbType = "Double";
                            break;
                        default:
                            dbType = "String";
                            break;
                    }
                    retCode.Append("\t\t\t<param name=\"@" + dv[i]["FieldName"] + "\" dbType=\"" + dbType + "\" />\n");
                    break;
                }
            }
            return retCode.ToString();
        }


        public static string GetXmlCode(string CON, string dbName, string tableName)
        {
            dsTableDetails = SqlHelper.ExecuteDataset(CON, CommandType.Text, string.Format(Common.GetTableDetails, dbName, tableName));
            DataView dv = new DataView(dsTableDetails.Tables[0]);

            string filde = string.Empty;
            string value = string.Empty;
            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["IsPrimary"].ToString() != "1")
                {
                    filde += dv[i]["FieldName"] + ",";
                    value += "@" + dv[i]["FieldName"] + ",";
                }
            }
            string sql = XmlHelper.DbCommand();
            //sql = sql.Replace("$$$DataBaseName$$$",dbName);
            sql = sql.Replace("$$$TableName$$$", tableName);
            StringBuilder insert = new StringBuilder();

            insert.Append("\t\t\tINSERT INTO DBO." + tableName + "(" + filde.Substring(0, filde.Length - 1) + ")\n");
            insert.Append("\t\t\tVALUES (" + value.Substring(0, value.Length - 1) + ")\n");
            insert.Append("\t\t\tSELECT @@IDENTITY\n");



            string where = string.Empty;
            string upfilde = string.Empty;
            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["IsPrimary"].ToString() != "1")
                {
                    upfilde += dv[i]["FieldName"] + " = @" + dv[i]["FieldName"] + ",";
                }
                else
                {
                    where = dv[i]["FieldName"] + " = @" + dv[i]["FieldName"];
                }
            }
            sql = sql.Replace("$$$IsertSql$$$", insert.ToString());
            sql = sql.Replace("$$$ParamsNoPrimary$$$", GetParams(dv));
            StringBuilder update = new StringBuilder();

            filde = string.Empty;
            where = string.Empty;
            for (int i = 0; i < dv.Count; i++)
            {
                if (dv[i]["FieldName"].ToString() != "InDate" && dv[i]["FieldName"].ToString() != "InUser")
                {
                    if (dv[i]["IsPrimary"].ToString() != "1")
                    {
                        filde += dv[i]["FieldName"] + " = @" + dv[i]["FieldName"] + ",";
                    }
                    else
                    {
                        where = dv[i]["FieldName"] + " = @" + dv[i]["FieldName"];
                    }
                }
            }
            update.Append("\t\t\tUPDATE DBO." + tableName + "\n");
            update.Append("\t\t\tSET " + filde.Substring(0, filde.Length - 1).Replace(",Status = @Status","") + "\n");
            update.Append("\t\t\tWHERE " + where + "\n");
            update.Append("\t\t\tSELECT @@IDENTITY\n");
            
            sql = sql.Replace("$$$UpdateSql$$$", update.ToString());
            sql = sql.Replace("$$$Params$$$", GetParams2(dv));
            return sql;
        }
    }
}
