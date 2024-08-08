using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE_External_Configuration
{
    public class AppDBbContext : DbContext
    {
        // Represent the collection of all tables
        public DbSet<Wallets> Wallets { get; set; } = null!;
        public AppDBbContext(DbContextOptions options):base(options) { }


    }
}
