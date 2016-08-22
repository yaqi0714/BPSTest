using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Runtime.Remoting.Messaging;

namespace Bidding.DAL
{
    public class ContextFactory
    {

        /// <summary>
        /// 获取当前数据上下文
        /// </summary>
        /// <returns></returns>
        public static BiddingDBContext GetCurrentContext()
        {
            BiddingDBContext _nContext = CallContext.GetData("NineskyContext") as BiddingDBContext;
            if (_nContext == null)
            {
                _nContext = new BiddingDBContext();
                CallContext.SetData("NineskyContext", _nContext);
            }
            return _nContext;
        }

    }
}
