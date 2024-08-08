
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
        
        public DbSet<User> User { get; set; } = null!;
        public DbSet<Tweet> Tweet { get; set; } = null!;
        public DbSet<Comment> Comment { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().ToTable("Users");

            modelBuilder.Entity<Tweet>().ToTable("Tweets");

            modelBuilder.Entity<Comment>().ToTable("Comments");

            //making modelBuilder for tweetText 
            modelBuilder.Entity<Comment>().Property(p => p.Id).HasColumnName("CommentId");

            //making modelBuilder for TweetId
            modelBuilder.Entity<Tweet>().Property(p => p.TheTextOfTweet).HasColumnName("tweetText");
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
