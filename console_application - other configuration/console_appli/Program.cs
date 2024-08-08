using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EF_CORE_Other_Configuration
{
    class Program
    {
        public static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

            var Connection_String = configuration.GetSection("constr").Value;

            var opitionBuilder = new DbContextOptionsBuilder();

            opitionBuilder.UseSqlServer(Connection_String)
                .LogTo(Console.WriteLine,LogLevel.Information) ;

            var option = opitionBuilder.Options;

            using (var context = new AppDBContext(option))
            {
                var w1 = new Wallets { Id = 6, Holder = "Samy", Balance = 1000M };
                context.Wallets.Add(w1);

                var w2 = new Wallets { Id = 7, Holder = "hany", Balance = 2000M };
                context.Wallets.Add(w2);

                context.SaveChanges();
            }

           


                Console.ReadKey();
        }
    }
}