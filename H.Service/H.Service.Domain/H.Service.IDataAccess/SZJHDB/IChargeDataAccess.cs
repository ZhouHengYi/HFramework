
using H.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace H.Service.IDataAccess
{
    /// <summary>
    /// ChargeInterface
    /// </summary>
    public interface IChargeDataAccess
    {

        List<ChargeEntity> Search(QueryCondition<ChargeEntity> entity);

        int InsertCharge(ChargeEntity entity);

        int UpdateCharge(ChargeEntity entity);

        int DeleteCharge(string sysno);

        ChargeEntity LoadEntity(string sysno);
    }
}

