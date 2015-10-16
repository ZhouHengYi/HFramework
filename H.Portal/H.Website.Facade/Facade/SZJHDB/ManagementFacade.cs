using H.Core.Utility;
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Website.Facade.Facade
{
    public class ManagementFacade
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static List<ManagementEntity> Search(QueryCondition<ManagementEntity> entity)
        {
            return RestClient.Post<List<ManagementEntity>>("ManagementService/Search", entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static int InsertManagement(ManagementEntity entity)
        {
            return RestClient.Post<int>("ManagementService/InsertManagement", entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static int UpdateManagement(ManagementEntity entity)
        {
            return RestClient.Post<int>("ManagementService/UpdateManagement", entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static int DeleteManagement(string sysno)
        {
            return RestClient.Post<int>("ManagementService/DeleteManagement", sysno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static ManagementEntity LoadEntity(int sysno)
        {
            return RestClient.Get<ManagementEntity>("ManagementService/LoadEntity/" + sysno);
        }
    }
}
