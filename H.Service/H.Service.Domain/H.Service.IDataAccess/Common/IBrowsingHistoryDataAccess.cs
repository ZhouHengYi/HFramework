
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.IDataAccess
{
    /// <summary>
    /// BrowsingHistoryInterface
    /// </summary>
    public interface IBrowsingHistoryDataAccess
    {
        List<BrowsingHistoryEntity> Search(QueryCondition<BrowsingHistoryEntity> entity);

        int InsertBrowsingHistory(BrowsingHistoryEntity entity);

        int UpdateBrowsingHistory(BrowsingHistoryEntity entity);

        int DeleteBrowsingHistory(string sysno);

        List<BrowsingHistoryEntity> BrowsingHistoryBySystemUserSysNo(string systemUserSysno);
    }
}

