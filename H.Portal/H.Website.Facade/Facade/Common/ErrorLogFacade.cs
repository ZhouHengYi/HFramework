using H.Core.Utility;
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Website.Facade.Facade
{
    public class ErrorLogFacade
    {
        public static List<ErrorLogEntity> Seach(QueryCondition<ErrorLogEntity> entity)
        {
            return RestClient.Post<List<ErrorLogEntity>>("ErrorLogService/Search", entity);
        }

        public static ErrorLogEntity GetDetails(int sysno)
        {
            return RestClient.Get<ErrorLogEntity>("ErrorLogService/GetDetails/" + sysno);
        }
    }
}
