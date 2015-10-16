
using H.Core.Utility;
using H.Core.Utility.Log;
using H.Entity;
using H.Service.IDataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.AppService
{
    /// <summary>
    /// BrowsingHistoryService
    /// </summary>
    [VersionExport(typeof(BrowsingHistoryAppService))]
    public class BrowsingHistoryAppService
    {
        public List<BrowsingHistoryEntity> Search(QueryCondition<BrowsingHistoryEntity> entity)
        {
            return ObjectFactory<IBrowsingHistoryDataAccess>.Instance.Search(entity);
        }

        public int InsertBrowsingHistory(BrowsingHistoryEntity entity)
        {
            return ObjectFactory<IBrowsingHistoryDataAccess>.Instance.InsertBrowsingHistory(entity);
        }

        public int UpdateBrowsingHistory(BrowsingHistoryEntity entity)
        {
            return ObjectFactory<IBrowsingHistoryDataAccess>.Instance.UpdateBrowsingHistory(entity);
        }

        public int DeleteBrowsingHistory(string sysno)
        {
            return ObjectFactory<IBrowsingHistoryDataAccess>.Instance.DeleteBrowsingHistory(sysno);
        }

        public List<BrowsingHistoryEntity> BrowsingHistoryBySystemUserSysNo(string systemUserSysno)
        {
            return ObjectFactory<IBrowsingHistoryDataAccess>.Instance.BrowsingHistoryBySystemUserSysNo(systemUserSysno);
        }
    }
}

