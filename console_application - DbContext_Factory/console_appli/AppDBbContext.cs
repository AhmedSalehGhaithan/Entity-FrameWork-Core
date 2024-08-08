using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE_DbContext_Factory
{
    public class AppDBContext : DbContext
    {
        // Represent the collection of all tables
        public DbSet<Wallets> Wallets { get; set; } = null!;
        public AppDBContext(DbContextOptions options) : base(options) { }

    }
}
