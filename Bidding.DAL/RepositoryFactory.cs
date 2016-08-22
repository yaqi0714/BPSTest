using Bidding.IDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bidding.DAL
{
    public static class RepositoryFactory
    {
        /// <summary>
        /// 用户仓储
        /// </summary>
        public static IUserRepository UserRepository { get { return new UserRepository(); } }
    }

}
