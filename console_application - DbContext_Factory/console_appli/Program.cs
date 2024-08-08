using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF_CORE_DbContext_Factory
{
    class Program
    {
        public static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

            var Connection_String = configuration.GetSection("constr").Value;

            var services = new ServiceCollection();

            // adding the AddDbContextFactory
            services.AddDbContextFactory<AppDBContext>( options=> options.UseSqlServer(Connection_String));

            // calling the services
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            // get th4 service from the factory
            var contextFactory = serviceProvider.GetService<IDbContextFactory<AppDBContext>>();

            // using the service
            using (var context = contextFactory!.CreateDbContext())
            {
                foreach (var wallet in context!.Wallets)
                {
                    Console.WriteLine(wallet);
                }
            }

                Console.ReadKey();
        }
    }
}