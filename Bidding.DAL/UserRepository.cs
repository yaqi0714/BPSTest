using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bidding.IDAL;
using Bidding.Models;

namespace Bidding.DAL
{
    class UserRepository : BaseRepository<User>, IUserRepository
    {
    }
}
