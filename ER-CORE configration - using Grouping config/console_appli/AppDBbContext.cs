
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE_External_Configuration3
{
    public class AppDBbContext : DbContext
    {
        
        public DbSet<User> User { get; set; } = null!;
        public DbSet<Tweet> Tweet { get; set; } = null!;
        public DbSet<Comment> Comment { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            ////-------------- indivisual calling the configuration ------------
            //new UserConfigration().Configure(modelBuilder.Entity<User>());

            //new TweetConfigration().Configure(modelBuilder.Entity<Tweet>());

            //new CommentConfigration().Configure(modelBuilder.Entity<Comment>());

            //--------------- Call grouping configreation from assembly ----------------
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommentConfigration).Assembly);

            // note you can use either two  (indivisual Or grouping) configreation


        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configring = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

            var connectionString = configring.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(connectionString);
        }

    }
}
