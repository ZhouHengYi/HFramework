
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.IDataAccess
{
    /// <summary>
    /// ManagementInterface
    /// </summary>
    public interface IManagementDataAccess
    {

        List<ManagementEntity> Search(QueryCondition<ManagementEntity> entity);

        int InsertManagement(ManagementEntity entity);

        int UpdateManagement(ManagementEntity entity);

        int DeleteManagement(string sysno);

        ManagementEntity LoadEntity(string sysno);

    }
}

