
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
        
        public DbSet<User> Users { get; set; } = null!;
        public DbSet<Tweet> Tweets { get; set; } = null!;
        public DbSet<Comment> Comments { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configring = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

            var connectionString = configring.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(connectionString);


        }

    }
}
