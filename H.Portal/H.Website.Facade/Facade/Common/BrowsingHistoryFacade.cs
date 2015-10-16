using H.Core.Utility;
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Website.Facade.Facade
{
    public class BrowsingHistoryFacade
    {
        public List<BrowsingHistoryEntity> Search(QueryCondition<BrowsingHistoryEntity> entity)
        {
            return RestClient.Post<List<BrowsingHistoryEntity>>("BrowsingHistoryService/Search", entity);
        }

        public int InsertBrowsingHistory(BrowsingHistoryEntity entity)
        {
            return RestClient.Post<int>("BrowsingHistoryService/InsertBrowsingHistory", entity);
        }

        public int UpdateBrowsingHistory(BrowsingHistoryEntity entity)
        {
            return RestClient.Post<int>("BrowsingHistoryService/UpdateBrowsingHistory", entity);
        }

        public int DeleteBrowsingHistory(string sysno)
        {
            return RestClient.Post<int>("BrowsingHistoryService/DeleteBrowsingHistory", sysno);
        }

        public List<BrowsingHistoryEntity> BrowsingHistoryBySystemUserSysNo(string systemUserSysno)
        {
            return RestClient.Get<List<BrowsingHistoryEntity>>("BrowsingHistoryService/DeleteBrowsingHistory/" + systemUserSysno);
        }
    }
}
