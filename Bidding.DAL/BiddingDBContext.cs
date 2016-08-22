using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Bidding.Models;

namespace Bidding.DAL
{
    public class BiddingDBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> Roles { get; set; }

        public DbSet<UserRoleRelation> UserRoleRelations { get; set; }
        public DbSet<UserConfig> UserConfig { get; set; }
        public BiddingDBContext()
            : base("DefaultConnection")
        {
        }

    }
}
