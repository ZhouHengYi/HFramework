using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using autocoder.Function;
using WindowsFormsApplication1.Function;
using System.Data.SqlClient;
using System.IO;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 获取所有表
        /// </summary>
        protected void GetTable()
        {

            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(Config.Conn, CommandType.Text, string.Format(Common.GetTableName, Config.DataBase)))
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        Lbx_TableList.Items.Clear();
                        foreach (DataRow dr in ds.Tables[0].Rows)
                        {
                            Lbx_TableList.Items.Add(dr["name"].ToString());
                        }
                    }
                }
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            }
        }

        private void tsb_Referensh_Click(object sender, EventArgs e)
        {
            GetTable();
        }

        private void tsb_Logoff_Click(object sender, EventArgs e)
        {
            this.Dispose();
            Login login = new Login();
            login.Show();
        }

        private void Lbx_TableList_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                SelectTblGetModelCode();
                SelectTblGetXmlCode();
                SelectTblGetInterfaceCode();
                SelectTblGetDACode();
                SelectTblGetRestCode();
                SelectTblGetFacadeCode();
                GetWebsiteInfo();
            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            }
        }

        protected void SelectTblGetModelCode()
        {
            if (Lbx_TableList.SelectedIndex > -1)
            {
                //Rtb_ModelCode.Text = MakeModel.GetModelCode2(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString());

                Rtb_ModelCode.Text = MakeModel.GetCode(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString());
            }
        }

        protected void SelectTblGetXmlCode()
        {
            if (Lbx_TableList.SelectedIndex > -1)
                Rtb_XmlCode.Text = MakeXml.GetXmlCode(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString());
        }

        protected void SelectTblGetInterfaceCode()
        {
            if (Lbx_TableList.SelectedIndex > -1)
                Rtb_InterfaceCode.Text = MakeInterface.GetCode(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString());
        }

        protected void SelectTblGetDACode()
        {
            if (Lbx_TableList.SelectedIndex > -1)
                Rtb_DACode.Text = MakeDA.GetCode(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString());
        }

        protected void SelectTblGetRestCode()
        {
            if (Lbx_TableList.SelectedIndex > -1)
                Rtb_RestCode.Text = MakeRestService.GetCode(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString());
        }

        protected void SelectTblGetFacadeCode()
        {
            if (Lbx_TableList.SelectedIndex > -1)
                Rtb_FacadeCode.Text = MakeFacade.GetCode(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString());
        }



        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Dispose();
            Application.Exit();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            GetTable();

        }

        private void btn_saveUrl_Click(object sender, EventArgs e)
        {
            folder_saveModel.ShowDialog();
            txt_saveUrl.Text = folder_saveModel.SelectedPath;
        }

        private void Btn_Model_CreateSel_Click(object sender, EventArgs e)
        {
            if (Lbx_TableList.SelectedItem == null)
            {
                MessageBox.Show("请选择左侧数据表!");
                return;
            }
            string modelCode = MakeModel.GetCode(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString());

            if (txt_saveUrl.Text == string.Empty)
            {
                if (!Directory.Exists(Config.DataBase + "/Entity/"))
                    Directory.CreateDirectory(Config.DataBase + "/Entity/");
                File.WriteAllText(Config.DataBase + "/Entity/" + Lbx_TableList.SelectedItem.ToString() + "Entity.cs", modelCode, Encoding.UTF8);
            }
            else
            {
                if (!Directory.Exists(txt_saveUrl.Text + "/Entity/"))
                    Directory.CreateDirectory(txt_saveUrl.Text + "/Entity/");
                File.WriteAllText(txt_saveUrl.Text + "/Entity/" + Lbx_TableList.SelectedItem.ToString() + "Entity.cs", modelCode, Encoding.UTF8);
            }
            MessageBox.Show("生成成功!");
        }

        private void Btn_CreateModelAll_Click(object sender, EventArgs e)
        {
            if (Lbx_TableList.Items.Count == 0)
            {
                MessageBox.Show("暂无表结构可生成!");
                return;
            }
            progressBar1.Maximum = Lbx_TableList.Items.Count;
            progressBar1.Minimum = 0;
            for (int i = 0; i < Lbx_TableList.Items.Count; i++)
            {
                string modelCode = MakeModel.GetCode(Config.Conn, Config.DataBase, Lbx_TableList.Items[i].ToString());

                if (txt_saveUrl.Text == string.Empty)
                {
                    if (!Directory.Exists(Config.DataBase + "/Entity/"))
                        Directory.CreateDirectory(Config.DataBase + "/Entity/");
                    File.WriteAllText(Config.DataBase + "/Entity/" + Lbx_TableList.Items[i].ToString() + "Entity.cs", modelCode, Encoding.UTF8);
                }
                else
                {
                    if (!Directory.Exists(txt_saveUrl.Text + "/Entity/"))
                        Directory.CreateDirectory(txt_saveUrl.Text + "/Entity/");
                    File.WriteAllText(txt_saveUrl.Text + "/Entity/" + Lbx_TableList.Items[i].ToString() + "Entity.cs", modelCode, Encoding.UTF8);
                }
                progressBar1.Value = i + 1;
            }
            progressBar1.Value = 0;
            MessageBox.Show("生成成功!");
        }

        private void Btn_xml_CreateSel_Click(object sender, EventArgs e)
        {
            if (Lbx_TableList.SelectedItem == null)
            {
                MessageBox.Show("请选择左侧数据表!");
                return;
            }
            string modelCode = MakeXml.GetXmlCode(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString());

            if (txt_saveUrl.Text == string.Empty)
            {
                if (!Directory.Exists(Config.DataBase + "/DbCommand/SqlServer"))
                    Directory.CreateDirectory(Config.DataBase + "/DbCommand/SqlServer");
                File.WriteAllText(Config.DataBase + "/DbCommand/SqlServer/Sql" + Lbx_TableList.SelectedItem.ToString() + "DataCommand.config", modelCode, Encoding.UTF8);

                string dbCommandFile = "<file name=\"SqlServerDbCommand/Sql" + Lbx_TableList.SelectedItem.ToString() + "DataCommand.config\" />";
                File.WriteAllText(Config.DataBase + "/DbCommand/DbCommandFiles.config", dbCommandFile, Encoding.UTF8);

            }
            else
            {
                if (!Directory.Exists(txt_saveUrl.Text + "/DbCommand/SqlServer"))
                    Directory.CreateDirectory(txt_saveUrl.Text + "/DbCommand/SqlServer");
                File.WriteAllText(txt_saveUrl.Text + "/DbCommand/SqlServer/Sql" + Lbx_TableList.SelectedItem.ToString() + "DataCommand.config", modelCode, Encoding.UTF8);

                string dbCommandFile = "<file name=\"SqlServerDbCommand/Sql" + Lbx_TableList.SelectedItem.ToString() + "DataCommand.config\" />";
                File.WriteAllText(txt_saveUrl.Text + "/DbCommand/DbCommandFiles.config", dbCommandFile, Encoding.UTF8);

            }
            
            MessageBox.Show("生成成功!");
        }

        private void Btn_CreateXmlAll_Click(object sender, EventArgs e)
        {
            if (Lbx_TableList.Items.Count == 0)
            {
                MessageBox.Show("暂无表结构可生成!");
                return;
            }
            progressBar1.Maximum = Lbx_TableList.Items.Count;
            progressBar1.Minimum = 0;
            string dbCommandFile = string.Empty;


            for (int i = 0; i < Lbx_TableList.Items.Count; i++)
            {
                string modelCode = MakeXml.GetXmlCode(Config.Conn, Config.DataBase, Lbx_TableList.Items[i].ToString());

                if (txt_saveUrl.Text == string.Empty)
                {
                    if (!Directory.Exists(Config.DataBase + "/DbCommand/SqlServer"))
                        Directory.CreateDirectory(Config.DataBase + "/DbCommand/SqlServer");
                    File.WriteAllText(Config.DataBase + "/DbCommand/SqlServer/Sql" + Lbx_TableList.Items[i].ToString() + "DataCommand.config", modelCode, Encoding.UTF8);
                }
                else
                {
                    if (!Directory.Exists(txt_saveUrl.Text + "/DbCommand/SqlServer"))
                        Directory.CreateDirectory(txt_saveUrl.Text + "/DbCommand/SqlServer");
                    File.WriteAllText(txt_saveUrl.Text + "/DbCommand/SqlServer/Sql" + Lbx_TableList.Items[i].ToString() + "DataCommand.config", modelCode, Encoding.UTF8);
                }
                progressBar1.Value = i + 1;
                dbCommandFile += "<file name=\"SqlServerDbCommand/Sql" + Lbx_TableList.SelectedItem.ToString() + "DataCommand.config\" />";
            }
            progressBar1.Value = 0;
            if (txt_saveUrl.Text == string.Empty)
            {
                File.WriteAllText(Config.DataBase + "/DbCommand/DbCommandFiles.config", dbCommandFile, Encoding.UTF8);
            }
            else
            {
                File.WriteAllText(txt_saveUrl.Text + "/DbCommand/DbCommandFiles.config", dbCommandFile, Encoding.UTF8);
            }
            MessageBox.Show("生成成功!");
        }

        private void Btn_Interface_CreateSel_Click(object sender, EventArgs e)
        {
            if (Lbx_TableList.SelectedItem == null)
            {
                MessageBox.Show("请选择左侧数据表!");
                return;
            }
            string modelCode = MakeInterface.GetCode(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString());

            if (txt_saveUrl.Text == string.Empty)
            {
                if (!Directory.Exists(Config.DataBase + "/IDataAccess/"))
                    Directory.CreateDirectory(Config.DataBase + "/IDataAccess/");
                File.WriteAllText(Config.DataBase + "/IDataAccess/I" + Lbx_TableList.SelectedItem.ToString() + "IDataAccess.cs", modelCode, Encoding.UTF8);
            }
            else
            {
                if (!Directory.Exists(txt_saveUrl.Text + "/IDataAccess/"))
                    Directory.CreateDirectory(txt_saveUrl.Text + "/IDataAccess/");
                File.WriteAllText(txt_saveUrl.Text + "/IDataAccess/I" + Lbx_TableList.SelectedItem.ToString() + "IDataAccess.cs", modelCode, Encoding.UTF8);
            }
            MessageBox.Show("生成成功!");
        }

        private void Btn_CreateInterfaceAll_Click(object sender, EventArgs e)
        {
            if (Lbx_TableList.Items.Count == 0)
            {
                MessageBox.Show("暂无表结构可生成!");
                return;
            }
            progressBar1.Maximum = Lbx_TableList.Items.Count;
            progressBar1.Minimum = 0;
            for (int i = 0; i < Lbx_TableList.Items.Count; i++)
            {
                string modelCode = MakeInterface.GetCode(Config.Conn, Config.DataBase, Lbx_TableList.Items[i].ToString());

                if (txt_saveUrl.Text == string.Empty)
                {
                    if (!Directory.Exists(Config.DataBase + "/IDataAccess/"))
                        Directory.CreateDirectory(Config.DataBase + "/IDataAccess/");
                    File.WriteAllText(Config.DataBase + "/IDataAccess/I" + Lbx_TableList.Items[i].ToString() + "IDataAccess.cs", modelCode, Encoding.UTF8);
                }
                else
                {
                    if (!Directory.Exists(txt_saveUrl.Text + "/IDataAccess/"))
                        Directory.CreateDirectory(txt_saveUrl.Text + "/IDataAccess/");
                    File.WriteAllText(txt_saveUrl.Text + "/IDataAccess/I" + Lbx_TableList.Items[i].ToString() + "IDataAccess.cs", modelCode, Encoding.UTF8);
                }
                progressBar1.Value = i + 1;
            }
            progressBar1.Value = 0;
            MessageBox.Show("生成成功!");
        }        

        private void Btn_DA_CreateSel_Click(object sender, EventArgs e)
        {
            if (Lbx_TableList.SelectedItem == null)
            {
                MessageBox.Show("请选择左侧数据表!");
                return;
            }
            string modelCode = MakeDA.GetCode(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString());

            if (txt_saveUrl.Text == string.Empty)
            {
                if (!Directory.Exists(Config.DataBase + "/DataAccess/"))
                    Directory.CreateDirectory(Config.DataBase + "/DataAccess/");
                File.WriteAllText(Config.DataBase + "/DataAccess/" + Lbx_TableList.SelectedItem.ToString() + "DataAccess.cs", modelCode, Encoding.UTF8);
            }
            else
            {
                if (!Directory.Exists(txt_saveUrl.Text + "/DataAccess/"))
                    Directory.CreateDirectory(txt_saveUrl.Text + "/DataAccess/");
                File.WriteAllText(txt_saveUrl.Text + "/DataAccess/" + Lbx_TableList.SelectedItem.ToString() + "DataAccess.cs", modelCode, Encoding.UTF8);
            }
            MessageBox.Show("生成成功!");
        }

        private void Btn_CreateDAAll_Click(object sender, EventArgs e)
        {
            if (Lbx_TableList.Items.Count == 0)
            {
                MessageBox.Show("暂无表结构可生成!");
                return;
            }
            progressBar1.Maximum = Lbx_TableList.Items.Count;
            progressBar1.Minimum = 0;
            for (int i = 0; i < Lbx_TableList.Items.Count; i++)
            {
                string modelCode = MakeDA.GetCode(Config.Conn, Config.DataBase, Lbx_TableList.Items[i].ToString());

                if (txt_saveUrl.Text == string.Empty)
                {
                    if (!Directory.Exists(Config.DataBase + "/DataAccess/"))
                        Directory.CreateDirectory(Config.DataBase + "/DataAccess/");
                    File.WriteAllText(Config.DataBase + "/DataAccess/" + Lbx_TableList.Items[i].ToString() + "DataAccess.cs", modelCode, Encoding.UTF8);
                }
                else
                {
                    if (!Directory.Exists(txt_saveUrl.Text + "/DataAccess/"))
                        Directory.CreateDirectory(txt_saveUrl.Text + "/DataAccess/");
                    File.WriteAllText(txt_saveUrl.Text + "/DataAccess/" + Lbx_TableList.Items[i].ToString() + "DataAccess.cs", modelCode, Encoding.UTF8);
                }
                progressBar1.Value = i + 1;
            }
            progressBar1.Value = 0;
            MessageBox.Show("生成成功!");
        }

        private void btn_CompanyCode_Click(object sender, EventArgs e)
        {
            Thread t = new Thread(CompanyStart);
            t.IsBackground = true;
            t.Start();            
        }

        protected void CompanyStart() {
            List<string> dataBaseList = new List<string>();
            //获取数据库
            string CONN = "Server=" + Config.Server +
                     ";User=" + Config.User +
                     ";Pwd=" + Config.Conn + ";";
            try
            {
                using (DataSet ds = SqlHelper.ExecuteDataset(CONN, CommandType.Text, Common.GetDataBase))
                {
                    if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                    {
                        for (int i = 0; i < ds.Tables[0].DefaultView.Count; i++)
                        {
                            dataBaseList.Add(ds.Tables[0].DefaultView[i]["name"].ToString());
                        }
                    }
                }

                //根据数据库查询表信息
                foreach (string dataBase in dataBaseList)
                {
                    List<string> dataTableList = new List<string>();

                    using (DataSet ds = SqlHelper.ExecuteDataset(CONN, CommandType.Text, string.Format(Common.GetTableName, dataBase)))
                    {
                        if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                        {
                            for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                            {
                                string tableName = ds.Tables[0].Rows[i]["name"].ToString();

                                //查询当前表的Company是否存在 或者为 NULL
                                string sql = string.Format("SELECT * FROM {0}.dbo.{1} WHERE CompanyCode = '' OR CompanyCode is null", dataBase, tableName);
                                try
                                {
                                    using (DataSet tDs = SqlHelper.ExecuteDataset(CONN, CommandType.Text, sql))
                                    {
                                        if (tDs != null && tDs.Tables.Count > 0 && tDs.Tables[0].Rows.Count > 0)
                                        {
                                            this.BeginInvoke(new MethodInvoker(() =>
                                            {
                                                //Rtb_CompanyCode.Text += sql + "\r\n";
                                            }));
                                        }
                                    }
                                }
                                catch (Exception ex)
                                {
                                    this.BeginInvoke(new MethodInvoker(() =>
                                    {
                                        //Rtb_CompanyCode.Text += sql + "\r\n";
                                    }));
                                }
                            }
                        }
                    }
                }

            }
            catch (SqlException se)
            {
                MessageBox.Show(se.ToString());
            }

        }

        private void Btn_Rest_CreateSel_Click(object sender, EventArgs e)
        {
            if (Lbx_TableList.SelectedItem == null)
            {
                MessageBox.Show("请选择左侧数据表!");
                return;
            }
            string modelCode = MakeRestService.GetCode(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString());

            if (txt_saveUrl.Text == string.Empty)
            {
                if (!Directory.Exists(Config.DataBase + "/RestService/"))
                    Directory.CreateDirectory(Config.DataBase + "/RestService/");
                File.WriteAllText(Config.DataBase + "/RestService/" + Lbx_TableList.SelectedItem.ToString() + "Service.cs", modelCode, Encoding.UTF8);
            }
            else
            {
                if (!Directory.Exists(txt_saveUrl.Text + "/RestService/"))
                    Directory.CreateDirectory(txt_saveUrl.Text + "/RestService/");
                File.WriteAllText(txt_saveUrl.Text + "/RestService/" + Lbx_TableList.SelectedItem.ToString() + "Service.cs", modelCode, Encoding.UTF8);
            }
            MessageBox.Show("生成成功!");
        }

        private void Btn_CreateRestAll_Click(object sender, EventArgs e)
        {
            if (Lbx_TableList.Items.Count == 0)
            {
                MessageBox.Show("暂无表结构可生成!");
                return;
            }
            progressBar1.Maximum = Lbx_TableList.Items.Count;
            progressBar1.Minimum = 0;
            for (int i = 0; i < Lbx_TableList.Items.Count; i++)
            {
                string modelCode = MakeRestService.GetCode(Config.Conn, Config.DataBase, Lbx_TableList.Items[i].ToString());

                if (txt_saveUrl.Text == string.Empty)
                {
                    if (!Directory.Exists(Config.DataBase + "/RestService/"))
                        Directory.CreateDirectory(Config.DataBase + "/RestService/");
                    File.WriteAllText(Config.DataBase + "/RestService/" + Lbx_TableList.Items[i].ToString() + "Service.cs", modelCode, Encoding.UTF8);
                }
                else
                {
                    if (!Directory.Exists(txt_saveUrl.Text + "/RestService/"))
                        Directory.CreateDirectory(txt_saveUrl.Text + "/RestService/");
                    File.WriteAllText(txt_saveUrl.Text + "/RestService/" + Lbx_TableList.Items[i].ToString() + "Service.cs", modelCode, Encoding.UTF8);
                }
                progressBar1.Value = i + 1;
            }
            progressBar1.Value = 0;
            MessageBox.Show("生成成功!");
        }

        private void Btn_Facade_CreateSel_Click(object sender, EventArgs e)
        {
            if (Lbx_TableList.SelectedItem == null)
            {
                MessageBox.Show("请选择左侧数据表!");
                return;
            }
            string modelCode = MakeFacade.GetCode(Config.Conn, Config.DataBase, Lbx_TableList.SelectedItem.ToString());

            if (txt_saveUrl.Text == string.Empty)
            {
                if (!Directory.Exists(Config.DataBase + "/Facade/"))
                    Directory.CreateDirectory(Config.DataBase + "/Facade/");
                File.WriteAllText(Config.DataBase + "/Facade/" + Lbx_TableList.SelectedItem.ToString() + "Facade.cs", modelCode, Encoding.UTF8);
            }
            else
            {
                if (!Directory.Exists(txt_saveUrl.Text + "/Facade/"))
                    Directory.CreateDirectory(txt_saveUrl.Text + "/Facade/");
                File.WriteAllText(txt_saveUrl.Text + "/Facade/" + Lbx_TableList.SelectedItem.ToString() + "Facade.cs", modelCode, Encoding.UTF8);
            }
            MessageBox.Show("生成成功!");
        }

        private void Btn_CreateFacadeAll_Click(object sender, EventArgs e)
        {
            

            if (Lbx_TableList.Items.Count == 0)
            {
                MessageBox.Show("暂无表结构可生成!");
                return;
            }
            progressBar1.Maximum = Lbx_TableList.Items.Count;
            progressBar1.Minimum = 0;
            for (int i = 0; i < Lbx_TableList.Items.Count; i++)
            {
                string modelCode = MakeFacade.GetCode(Config.Conn, Config.DataBase, Lbx_TableList.Items[i].ToString());

                if (txt_saveUrl.Text == string.Empty)
                {
                    if (!Directory.Exists(Config.DataBase + "/Facade/"))
                        Directory.CreateDirectory(Config.DataBase + "/Facade/");
                    File.WriteAllText(Config.DataBase + "/Facade/" + Lbx_TableList.Items[i].ToString() + "Facade.cs", modelCode, Encoding.UTF8);
                }
                else
                {
                    if (!Directory.Exists(txt_saveUrl.Text + "/Facade/"))
                        Directory.CreateDirectory(txt_saveUrl.Text + "/Facade/");
                    File.WriteAllText(txt_saveUrl.Text + "/Facade/" + Lbx_TableList.Items[i].ToString() + "Facade.cs", modelCode, Encoding.UTF8);
                }
                progressBar1.Value = i + 1;
            }
            progressBar1.Value = 0;
            MessageBox.Show("生成成功!");
        }

        private void btn_batchGenerate_Click(object sender, EventArgs e)
        {
            Btn_CreateModelAll_Click(null, null);
            Btn_CreateXmlAll_Click(null, null);
            Btn_CreateInterfaceAll_Click(null, null);
            Btn_CreateDAAll_Click(null, null);
            Btn_CreateRestAll_Click(null, null);
            Btn_CreateFacadeAll_Click(null, null);
        }

        private void GetWebsiteInfo()
        {

            string page = "";
            string pageAlias = "";
            string url = "";

            string table = Lbx_TableList.SelectedItem.ToString();
            page += "<page name=\"" + table + "\" path=\"/" + table + "\"/>\r\n";
            page += "<page name=\"" + table + "Maintain\" path=\"/" + table + "Maintain\"/>\r\n";

            pageAlias += "/// <summary>\r\n";
            pageAlias += "/// \r\n";
            pageAlias += "/// </summary>\r\n";
            pageAlias += table + ",\r\n";

            pageAlias += "/// <summary>\r\n";
            pageAlias += "/// \r\n";
            pageAlias += "/// </summary>\r\n";
            pageAlias += table + "Maintain,\r\n";

            url += "<rote roteName=\"" + table + "Maintain\" roteUrl=\"" + table + "\" physicalFile=\"~/Pages/" + table + "/Maintain.aspx\"></rote>\r\n";
            url += "<rote roteName=\"" + table + "\" roteUrl=\"" + table + "\" physicalFile=\"~/Pages/" + table + "/" + table + ".aspx\"></rote>\r\n";

            lit_website.Text += page;
            lit_website.Text += "\r\n------------------------------------------------------------------------\r\n";
            lit_website.Text += pageAlias;
            lit_website.Text += "------------------------------------------------------------------------\r\n";
            lit_website.Text += url;
        }

        private void GetAllWebsiteInfo()
        {
            string page = "";
            string pageAlias = "";
            string url = "";
            for (int i = 0; i < Lbx_TableList.Items.Count; i++)
            {
                string table = Lbx_TableList.Items[i].ToString();
                page += "<page name=\"" + table + "\" path=\"/" + table + "\"/>\r\n";
                page += "<page name=\"" + table + "Maintain\" path=\"/" + table + "Maintain\"/>\r\n";

                pageAlias += "/// <summary>\r\n";
                pageAlias += "/// \r\n";
                pageAlias += "/// </summary>\r\n";
                pageAlias += table + ",\r\n";

                pageAlias += "/// <summary>\r\n";
                pageAlias += "/// \r\n";
                pageAlias += "/// </summary>\r\n";
                pageAlias += table + "Maintain,\r\n";

                url += "<rote roteName=\"" + table + "Maintain\" roteUrl=\"" + table + "\" physicalFile=\"~/Pages/" + table + "/Maintain.aspx\"></rote>\r\n";
                url += "<rote roteName=\"" + table + "\" roteUrl=\"" + table + "\" physicalFile=\"~/Pages/" + table + "/" + table + ".aspx\"></rote>\r\n";
            }
            lit_website.Text += page;
            lit_website.Text += "\r\n------------------------------------------------------------------------\r\n";
            lit_website.Text += pageAlias;
            lit_website.Text += "------------------------------------------------------------------------\r\n";
            lit_website.Text += url;
        }

        private void btn_aspx_Click(object sender, EventArgs e)
        {
            string aspx = XmlHelper.PageAspx().Replace("$$$TableName$$$", Lbx_TableList.SelectedItem.ToString());
            lit_Aspx.Text = aspx;
        }

        private void btn_aspxcs_Click(object sender, EventArgs e)
        {
            string aspx = XmlHelper.PageAspxCs().Replace("$$$TableName$$$", Lbx_TableList.SelectedItem.ToString()); ;
            lit_Aspx.Text = aspx;
        }

        private void btn_designer_Click(object sender, EventArgs e)
        {
            string aspx = XmlHelper.PageDesign().Replace("$$$TableName$$$", Lbx_TableList.SelectedItem.ToString()); ;
            lit_Aspx.Text = aspx;
        }

        private void btn_aspx2_Click(object sender, EventArgs e)
        {
            string aspx = XmlHelper.PageAspx2().Replace("$$$TableName$$$", Lbx_TableList.SelectedItem.ToString());
            lit_Aspx.Text = aspx;
        }

        private void btn_aspxcs2_Click(object sender, EventArgs e)
        {
            string aspx = XmlHelper.PageAspxCs2().Replace("$$$TableName$$$", Lbx_TableList.SelectedItem.ToString()); ;
            lit_Aspx.Text = aspx;
        }

        private void btn_designer2_Click(object sender, EventArgs e)
        {
            string aspx = XmlHelper.PageDesign2().Replace("$$$TableName$$$", Lbx_TableList.SelectedItem.ToString()); ;
            lit_Aspx.Text = aspx;
        }

        private void btn_pageSave_Click(object sender, EventArgs e)
        {
            string aspx = XmlHelper.PageAspx().Replace("$$$TableName$$$", Lbx_TableList.SelectedItem.ToString());
            SavePage(Lbx_TableList.SelectedItem.ToString() +".aspx", Lbx_TableList.SelectedItem.ToString(), aspx);
            aspx = XmlHelper.PageAspxCs().Replace("$$$TableName$$$", Lbx_TableList.SelectedItem.ToString()); ;
            SavePage(Lbx_TableList.SelectedItem.ToString() + ".aspx.cs", Lbx_TableList.SelectedItem.ToString(), aspx);
            aspx = XmlHelper.PageDesign().Replace("$$$TableName$$$", Lbx_TableList.SelectedItem.ToString()); ;
            SavePage(Lbx_TableList.SelectedItem.ToString() + ".aspx.designer.cs", Lbx_TableList.SelectedItem.ToString(), aspx);

            aspx = XmlHelper.PageAspx2().Replace("$$$TableName$$$", Lbx_TableList.SelectedItem.ToString());
            SavePage("Maintain.aspx", Lbx_TableList.SelectedItem.ToString(), aspx);
            aspx = XmlHelper.PageAspxCs2().Replace("$$$TableName$$$", Lbx_TableList.SelectedItem.ToString()); ;
            SavePage("Maintain.aspx.cs", Lbx_TableList.SelectedItem.ToString(), aspx);
            aspx = XmlHelper.PageDesign2().Replace("$$$TableName$$$", Lbx_TableList.SelectedItem.ToString()); ;
            SavePage("Maintain.aspx.designer.cs", Lbx_TableList.SelectedItem.ToString(), aspx);
        }

        private void SavePage(string ext,string tb,string code) {

            if (txt_saveUrl.Text == string.Empty)
            {
                if (!Directory.Exists(Config.DataBase + "/Pages/" + tb + "/"))
                    Directory.CreateDirectory(Config.DataBase + "/Pages/" + tb + "/");
                File.WriteAllText(Config.DataBase + "/Pages/" + tb + "/" + ext, code, Encoding.UTF8);
            }
            else
            {
                if (!Directory.Exists(txt_saveUrl.Text + "/Pages/" + tb + "/"))
                    Directory.CreateDirectory(txt_saveUrl.Text + "/Pages/" + tb + "/");
                File.WriteAllText(txt_saveUrl.Text + "/Pages/" + tb + "/" + ext, code, Encoding.UTF8);
            }


        }
    }
}
