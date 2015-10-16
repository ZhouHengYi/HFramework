using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using autocoder.Function;
using System.Windows.Forms;

namespace WindowsFormsApplication1.Function
{
    class MakeModel
    {
        private static DataSet dsTableDetails;//表字段详细信息
        protected static DataSet TabDetails;    //表详细信息

        public static string GetModelCode(string CON, string dbName, string tableName)
        {
            TabDetails = SqlHelper.ExecuteDataset(CON, CommandType.Text, Common.GetTabDetails(dbName, tableName));
            StringBuilder retCode = new StringBuilder();
            dsTableDetails = SqlHelper.ExecuteDataset(CON, CommandType.Text, string.Format(Common.GetTableDetails, dbName, tableName));
            DataView dv = new DataView(dsTableDetails.Tables[0]);
            if (dv.Count > 0)
            {
                retCode.Append("using System;\n");
                retCode.Append("using System.Text;\n");
                retCode.Append("using System.Collections.Generic;\n");
                retCode.Append("using System.Data;\n");
                retCode.Append("using DBUtility.Model;\n");
                retCode.Append("namespace Model\n");
                retCode.Append("{\n");
                if (TabDetails != null && TabDetails.Tables.Count > 0 && TabDetails.Tables[0].Rows.Count > 0)
                    retCode.Append("\t//" + TabDetails.Tables[0].Rows[0]["Remark"] + "\n");
                else
                    retCode.Append("\t//" + tableName + "\n");
                retCode.Append("\t[DataTbName(\"" + tableName + "\")]\n");
                retCode.Append("\t[Serializable]\n");
                retCode.Append("\tpublic class " + tableName + "DO\n");
                retCode.Append("\t{\n");
                retCode.Append("\t\tpublic " + tableName + "DO(){  }\n");
                retCode.Append("\t\tpublic " + tableName + "DO(int _id){  \n\t\t\tthis.Id = _id ;\n\t\t}\n");
                for (int i = 0; i < dv.Count; i++)//FieldName FieldType FieldLength IsIdentity
                {
                    string type = "";
                    string sss = dv[i]["FieldType"].ToString();
                    switch (dv[i]["FieldType"].ToString())
                    {
                        case "int":
                            type = "int?";
                            break;
                        case "datetime":
                            type = "DateTime?";
                            break;
                        case "money":
                            type = "decimal?";
                            break;
                        case "decimal":
                            type = "decimal?";
                            break;
                        case "float":
                            type = "float?";
                            break;
                        default:
                            type = "string";
                            break;
                    }

                    //string privateName = string.Empty;

                    //retCode.Append("\t\tprivate " + type + " _" + dv[i]["FieldName"] + ";\n");
                    retCode.Append("\t\t/// <summary>\n");
                    retCode.Append("\t\t/// " + dv[i]["Remark"] + "\n");
                    retCode.Append("\t\t/// </summary>\n");

                    if (dv[i]["IsPrimary"].ToString() == "1")
                        retCode.Append("\t\t[DataField(\"" + dv[i]["FieldName"] + "\", IsPrimaryKey = true)]\n");
                    else
                        retCode.Append("\t\t[DataField(\"" + dv[i]["FieldName"] + "\")]\n");

                    retCode.Append("\t\tpublic " + type + " " + dv[i]["FieldName"] + "\n");
                    retCode.Append("\t\t{\n");
                    //retCode.Append("\t\t\tget { return _" + dv[i]["FieldName"] + " ;}\n");
                    //retCode.Append("\t\t\tset { _" + dv[i]["FieldName"] + " = value; }\n");
                    retCode.Append("\t\t\tget;set;\n");
                    retCode.Append("\t\t}\n");
                    retCode.Append("\t\t\n");
                }
                retCode.Append("\t}\n");
                retCode.Append("}");
            }
            return retCode.ToString();
        }

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
            retCode.Append(XmlHelper.Model());
            retCode.Replace("$$$Remark$$$", tableRemark.ToString());
            retCode.Replace("$$$DBName$$$", dbName);
            retCode.Replace("$$$TableName$$$", tableName);

            //字段样式
            int fildeStartIndex = retCode.ToString().IndexOf("$$%FildBegin%$$");
            int fildeEndIndex = retCode.ToString().IndexOf("$$%FildEnd%$$");
            string oldFildeTemplate = retCode.ToString().Substring(fildeStartIndex, fildeEndIndex - fildeStartIndex + "$$%FildEnd%$$".Length);
            string newFildeTemplate = retCode.ToString().Substring(fildeStartIndex + "$$%FildBegin%$$".Length, fildeEndIndex - fildeStartIndex - "$$%FildEnd%$$".Length - 2);

            retCode.Replace(oldFildeTemplate,"$$$Content$$$");

            if (dv.Count > 0)
            {
                defaultStructure.Append("\tpublic " + tableName + "Entity(){  }\n");
                defaultStructure.Append("\t\tpublic " + tableName + "Entity(int _$$$Primary$$$){  \n\t\t\tthis.$$$Primary$$$ = _$$$Primary$$$ ;\n\t\t}\n");

                for (int i = 0; i < dv.Count; i++)//FieldName FieldType FieldLength IsIdentity
                {
                    string type = "";
                    string dbType = "";
                    switch (dv[i]["FieldType"].ToString())
                    {
                        case "int":
                            type = "int";
                            dbType = "DbType.Int32";
                            break;
                        case "datetime":
                            type = "DateTime?";
                            dbType = "DbType.DateTime";
                            break;
                        case "money":
                            type = "decimal";
                            dbType = "DbType.Decimal";
                            break;
                        case "decimal":
                            type = "decimal";
                            dbType = "DbType.Decimal";
                            break;
                        case "float":
                            type = "float";
                            dbType = "DbType.Double";
                            break;
                        default:
                            type = "string";
                            dbType = "DbType.String";
                            break;
                    }

                    string contentCode = newFildeTemplate.Replace("$$$FileName$$$", dv[i]["FieldName"].ToString());
                    contentCode = contentCode.Replace("$$$FileRemark$$$", dv[i]["Remark"].ToString());
                    contentCode = contentCode.Replace("$$$FileType$$$", type);
                    contentCode = contentCode.Replace("$$$FileDBType$$$", dbType);
                    content.Append("\t\t" + contentCode);

                    if (dv[i]["IsPrimary"].ToString() == "1")
                        primary.Append(dv[i]["FieldName"].ToString());
                }
            }

            retCode.Replace("$$$DefaultStructure$$$", defaultStructure.ToString());
            retCode.Replace("$$$Primary$$$", primary.ToString());
            retCode.Replace("$$$Content$$$", content.ToString());
            return retCode.ToString();
        }


        public static string GetModelCode2(string CON, string dbName, string tableName)
        {
            TabDetails = SqlHelper.ExecuteDataset(CON, CommandType.Text, Common.GetTabDetails(dbName, tableName));
            StringBuilder retCode = new StringBuilder();
            dsTableDetails = SqlHelper.ExecuteDataset(CON, CommandType.Text, string.Format(Common.GetTableDetails, dbName, tableName));
            DataView dv = new DataView(dsTableDetails.Tables[0]);
            string primary = string.Empty;

            if (dv.Count > 0)
            {
                retCode.Append("using System;\n");
                retCode.Append("using System.Data;\n");
                retCode.Append("using System.Runtime.Serialization;\n");
                retCode.Append("using IPP.Framework.Entity;\n");
                retCode.Append("\n");
                retCode.Append("namespace IPP.VendorPortal.DataContracts\n");
                retCode.Append("{\n");
                if (TabDetails != null && TabDetails.Tables.Count > 0 && TabDetails.Tables[0].Rows.Count > 0)
                    retCode.Append("\t//" + TabDetails.Tables[0].Rows[0]["Remark"] + "\n");
                else
                    retCode.Append("\t//" + tableName + "\n");
                retCode.Append("\t[DataContract]\n");
                retCode.Append("\t[Serializable]\n");
                retCode.Append("\t[TableMapping(\"" + dbName + "\", \"" + tableName + "\", \"{0}\")]\n");
                retCode.Append("\tpublic class " + tableName + "Entity\n");
                retCode.Append("\t{\n");
                retCode.Append("\t\tpublic " + tableName + "Entity(){  }\n");
                retCode.Append("\t\tpublic " + tableName + "Entity(int _{0}){  \n\t\t\tthis.{0} = _{0} ;\n\t\t}\n");
                for (int i = 0; i < dv.Count; i++)//FieldName FieldType FieldLength IsIdentity
                {
                    string type = "";
                    string dbType = "";
                    string sss = dv[i]["FieldType"].ToString();
                    switch (dv[i]["FieldType"].ToString())
                    {
                        case "int":
                            type = "int";
                            dbType = "DbType.Int32";
                            break;
                        case "datetime":
                            type = "DateTime";
                            dbType = "DbType.DateTime";
                            break;
                        case "money":
                            type = "decimal";
                            dbType = "DbType.Decimal";
                            break;
                        case "decimal":
                            type = "decimal";
                            dbType = "DbType.Decimal";
                            break;
                        case "float":
                            type = "float";
                            dbType = "DbType.Double";
                            break;
                        default:
                            type = "string";
                            dbType = "DbType.String";
                            break;
                    }

                    

                    //retCode.Append("\t\tprivate " + type + " _" + dv[i]["FieldName"] + ";\n");
                    retCode.Append("\t\t/// <summary>\n");
                    retCode.Append("\t\t/// " + dv[i]["Remark"] + "\n");
                    retCode.Append("\t\t/// </summary>\n");
                    retCode.Append("\t\t[DataMember]\n");
                    retCode.Append("\t\t[DataMapping(\"" + dv[i]["FieldName"] + "\", " + dbType + ")]\n");
                    retCode.Append("\t\tpublic " + type + " " + dv[i]["FieldName"] + "\n");
                    retCode.Append("\t\t{\n");
                    //retCode.Append("\t\t\tget { return _" + dv[i]["FieldName"] + " ;}\n");
                    //retCode.Append("\t\t\tset { _" + dv[i]["FieldName"] + " = value; }\n");
                    retCode.Append("\t\t\tget;set;\n");
                    retCode.Append("\t\t}\n");
                    retCode.Append("\t\t\n");


                    if (dv[i]["IsPrimary"].ToString() == "1")
                        primary = dv[i]["FieldName"].ToString();
                }
                retCode.Append("\t}\n");
                retCode.Append("}");
            }
            if (primary == string.Empty)
            {
                MessageBox.Show("该表未发现主键...");
                return "";
            }
            string returnCode = retCode.ToString().Replace("{0}",primary);
            return returnCode;
        }
    }
}
