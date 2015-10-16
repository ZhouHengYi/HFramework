using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using H.Core.Utility;
using System.Threading;

namespace NPOI
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void btn_selctFile_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Open1.Filter = "图片文件(*.jpg,*.gif,*.bmp)|*.jpg|*.gif|*.bmp";
            openFileDialog1.Filter = "Excel文件(*.xls)|*.xls";

            txt_dataType.Text = "1";
            txt_default.Text = "3";
            txt_description.Text = "4";
            txt_fieldName.Text = "0";
            txt_remark.Text = "5";
            txt_filePath.Text = @"D:\HomeTFS\Project\Code\尚普\Document\DataBase.xls";
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            txt_filePath.Text =  openFileDialog1.FileName;
        }
        static HSSFWorkbook hssfworkbook;
        private void btn_Generate_Click(object sender, EventArgs e)
        {
            try
            {
                string fieldName = txt_fieldName.Text;
                string dataType = txt_dataType.Text;
                string defa = txt_default.Text;
                string description = txt_description.Text;
                string endRow = txt_endRow.Text;
                string startRow = txt_startRow.Text;
                if (string.IsNullOrEmpty(fieldName) || string.IsNullOrEmpty(dataType) || string.IsNullOrEmpty(defa)
                    || string.IsNullOrEmpty(description) || string.IsNullOrEmpty(endRow) || string.IsNullOrEmpty(startRow))
                {
                    MessageBox.Show("请输入相关信息!");
                    return;
                };
                using (FileStream file = new FileStream(txt_filePath.Text, FileMode.Open, FileAccess.Read))
                {
                    hssfworkbook = new HSSFWorkbook(file);
                }
                ISheet sheet = hssfworkbook.GetSheetAt(0);

                Thread.Sleep(1000);

                System.Collections.IEnumerator rows = sheet.GetRowEnumerator();
                StringBuilder sqlBuilder = new StringBuilder();
                sqlBuilder.Append(string.Format("CREATE TABLE [dbo].[{0}](\r\n", txt_tableName.Text.Trim()));

                StringBuilder sqlRemarkBuilder = new StringBuilder();
                sqlRemarkBuilder.Append(string.Format("EXECUTE sp_addextendedproperty N'MS_Description','{0}',N'user',N'dbo',N'table',N'{1}',NULL,NULL\r\n", "", txt_tableName.Text.Trim()));

                for (int i = startRow.ToInt32() - 1; i < endRow.ToInt32(); i++)
                {
                    IRow row = sheet.GetRow(i);
                    string fieldNameValue = row.GetCell(txt_fieldName.Text.ToInt32()).StringCellValue.Trim();
                    string defaValue = row.GetCell(txt_default.Text.ToInt32()).StringCellValue.Trim();
                    string dataTypeValue = row.GetCell(txt_dataType.Text.ToInt32()).StringCellValue.Trim();
                    string descriptionValue = row.GetCell(txt_description.Text.ToInt32()).StringCellValue.Trim();
                    string def = string.Empty;
                    if (string.IsNullOrEmpty(defaValue) && dataTypeValue.ToLower().IndexOf("int") >= 0)
                        def = "0";
                    if (string.IsNullOrEmpty(defaValue) && dataTypeValue.ToLower().IndexOf("datetime") >= 0)
                        def = "GETDATE()";
                    if (string.IsNullOrEmpty(defaValue) && dataTypeValue.ToLower().IndexOf("float") >= 0)
                        def = "0";
                    if (string.IsNullOrEmpty(defaValue) && dataTypeValue.ToLower().IndexOf("double") >= 0)
                        def = "0";
                    if (string.IsNullOrEmpty(defaValue) && dataTypeValue.ToLower().IndexOf("decimal") >= 0)
                        def = "0";
                    if (string.IsNullOrEmpty(defaValue) && dataTypeValue.ToLower().IndexOf("nvarchar") >= 0)
                        def = "''";
                    if (string.IsNullOrEmpty(defaValue) && dataTypeValue.ToLower().IndexOf("varchar") >= 0)
                        def = "''";
                    if (string.IsNullOrEmpty(defaValue) && dataTypeValue.ToLower().IndexOf("ntext") >= 0)
                        def = "''";
                    if (string.IsNullOrEmpty(defaValue) && dataTypeValue.ToLower().IndexOf("text") >= 0)
                        def = "''";
                    def = " DEFAULT(" + def + ")";
                    sqlBuilder.Append(string.Format("[{0}] {1} NULL{2},\r\n", fieldNameValue, dataTypeValue, def));

                    sqlRemarkBuilder.Append(string.Format("EXECUTE sp_addextendedproperty N'MS_Description','{0}',N'user',N'dbo',N'table',N'{1}',N'column',N'{2}'\r\n", descriptionValue, txt_tableName.Text.Trim(), fieldNameValue));

                }
                sqlBuilder.Append(")\r\n");
                txt_sql.Text = sqlBuilder.ToString();
                txt_sql.Text += sqlRemarkBuilder.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btn_clear_Click(object sender, EventArgs e)
        {
            txt_sql.Text = "";
        }
    }
}
