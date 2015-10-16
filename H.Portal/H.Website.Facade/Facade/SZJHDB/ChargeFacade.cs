using H.Core.Utility;
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Website.Facade.Facade
{
    public class ChargeFacade
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static List<ChargeEntity> Search(QueryCondition<ChargeEntity> entity)
        {
            return RestClient.Post<List<ChargeEntity>>("ChargeService/Search", entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static int InsertCharge(ChargeEntity entity)
        {
            return RestClient.Post<int>("ChargeService/InsertCharge", entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static int UpdateCharge(ChargeEntity entity)
        {
            return RestClient.Post<int>("ChargeService/UpdateCharge", entity);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static int DeleteCharge(string sysno)
        {
            return RestClient.Post<int>("ChargeService/DeleteCharge", sysno);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="log"></param>
        public static ChargeEntity LoadEntity(int sysno)
        {
            return RestClient.Get<ChargeEntity>("ChargeService/LoadEntity/" + sysno);
        }
    }
}
