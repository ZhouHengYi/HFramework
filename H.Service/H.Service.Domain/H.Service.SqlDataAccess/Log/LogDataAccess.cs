using H.Core.DataAccess;
using H.Core.Utility;
using H.Core.Utility.Log;
using H.Service.IDataAccess;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Text;

namespace H.Service.SqlDataAccess
{
    [VersionExport(typeof(ILogDataAccess))]
    public class LogDataAccess : ILogDataAccess
    {
        /// <summary>
        /// 记录错误日志
        /// </summary>
        /// <param name="log"></param>
        public void Log(LogEntry log)
        {
            string m_LogFolderPath = Path.Combine(AppDomain.CurrentDomain.SetupInformation.ApplicationBase, "Log");
            try
            {
                CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("CreateLogo");
                command.SetParameterValue<LogEntry>(log);
                int result = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                if (!Directory.Exists(m_LogFolderPath))
                {
                    Directory.CreateDirectory(m_LogFolderPath);
                }
                WriteToFile(new XmlSerializer().Serialization(log, log.GetType()),
                Path.Combine(m_LogFolderPath, DateTime.Now.ToString("yyyy-MM-dd") + ".txt"));
            }
        }

        private static void WriteToFile(string log, string filePath)
        {
            log += "\r\n数据库连接失败**********************************************************************\r\n";
            byte[] textByte = System.Text.Encoding.GetEncoding("gb2312").GetBytes(log);
            using (FileStream logStream = new FileStream(filePath, FileMode.Append, FileAccess.Write, FileShare.Write))
            {
                logStream.Write(textByte, 0, textByte.Length);
            }
        }
    }
}
