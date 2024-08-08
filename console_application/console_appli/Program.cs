using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Data.SqlTypes;

namespace EF_CORE_External_Configuration
{
    class Program
    {
        public static void Main(string[] args)
        {

            var configration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

            var connection_string = configration.GetSection("constr").Value;

            var optionBuilder = new DbContextOptionsBuilder();

            optionBuilder.UseSqlServer(connection_string);

            var options = optionBuilder.Options;

            using (var context = new AppDBbContext(options))
            {
                foreach(var wallet in context.Wallets)
                {
                    Console.WriteLine(wallet);
                }
            }

            Console.ReadKey();
        }
    }
}