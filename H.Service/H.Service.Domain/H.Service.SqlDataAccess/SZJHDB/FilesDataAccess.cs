
using H.Core.DataAccess;
using H.Core.Utility;
using H.Entity;
using H.Service.IDataAccess;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace H.Service.SqlDataAccess
{
    /// <summary>
    /// FilesDA
    /// </summary>
    public class FilesDataAccess
    {
        public int InsertFiles(FilesEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("InsertFiles");
            command.SetParameterValue("@Flag", entity.Flag);
            command.SetParameterValue("@FSysNo", entity.FSysNo);
            command.SetParameterValue("@FileName", entity.FileName);
            command.SetParameterValue("@Path", entity.Path);
            command.SetParameterValue("@Status", entity.Status);
            command.SetParameterValue("@InUser", entity.InUser);
            command.SetParameterValue("@InDate", entity.InDate);
            object obj = command.ExecuteScalar();
            if (obj != null)
                return Convert.ToInt32(obj);
            else
                return 0;
        }


        public int UpdateFiles(FilesEntity entity)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("UpdateFiles");
            command.SetParameterValue("@SysNo", entity.SysNo);
            command.SetParameterValue("@Flag", entity.Flag);
            command.SetParameterValue("@FSysNo", entity.FSysNo);
            command.SetParameterValue("@FileName", entity.FileName);
            command.SetParameterValue("@Path", entity.Path);
            command.SetParameterValue("@Status", entity.Status);
            command.SetParameterValue("@InUser", entity.InUser);
            command.SetParameterValue("@InDate", entity.InDate);
            return command.ExecuteNonQuery();
        }


        public int DeleteFiles(string sysno)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("DeleteFiles");
            command.CommandText = command.CommandText.Replace("#SysNo#", sysno);
            return command.ExecuteNonQuery();
        }

        public int DeleteFilesByFSysNo(int fSysNo)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("DeleteFilesByFSysNo");
            command.SetParameterValue("@FSysNo", fSysNo);
            return command.ExecuteNonQuery();
        }

        public int DeleteFilesByFSysNos(string fSysNo)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("DeleteFilesByFSysNos");
            command.CommandText = command.CommandText.Replace("#FSysNo#", fSysNo);
            return command.ExecuteNonQuery();
        }

        public List<FilesEntity> GetFileByFSysNo(int fSysNo)
        {
            CustomDataCommand command = DataCommandManager.CreateCustomDataCommandFromConfig("GetFileByFSysNo");
            command.SetParameterValue("@FSysNo", fSysNo);
            return command.ExecuteEntityList<FilesEntity>();
        }
    }
}

