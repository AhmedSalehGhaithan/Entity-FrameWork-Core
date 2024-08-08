using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF_CORE
{
    public class AppDBbContext : DbContext
    {
        //// Represent the collection of all tables
        //public DbSet<Wallets> Wallets { get; set; } = null!;
        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    base.OnConfiguring(optionsBuilder);

        //    var configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

        //    var Connection_String = configuration.GetSection("constr").Value;

        //    optionsBuilder.UseSqlServer(Connection_String);
        //}





        // Represent the collection of all tables
        public DbSet<Wallets> Wallets { get; set; } = null!;

        //     Override this method to configure the database (and other options) to be used
        //     for this context. This method is called for each instance of the context that  is created. The base implementation does nothing.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {//   DbContextOptionsBuilder:  Provides a simple API surface for configuring Microsoft.EntityFrameworkCore.DbContextOptions.
         //     Databases (and other extensions) typically define extension methods on this object
         //     that allow you to configure the database connection (and other options) to be  used for a context.
            base.OnConfiguring(optionsBuilder);
            var configration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
            //  ConfigurationBuilder: Used to build key/value based configuration settings for use in an application.  Returns the sources used to obtain configuration values.

            var connection_String = configration.GetSection("constr").Value;

            // UseSqlServer: Configures the context to connect to a Microsoft SQL Server database.
            optionsBuilder.UseSqlServer(connection_String);


        }
    }
}
