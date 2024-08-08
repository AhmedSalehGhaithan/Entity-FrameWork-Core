using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF_CORE_Dependency_Injection
{
    class Program
    {
        public static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

            var Connection_String = configuration.GetSection("constr").Value;

            var services = new ServiceCollection();
            
            // adding the services
            services.AddDbContext<AppDBContext>(options => options.UseSqlServer(Connection_String));

            // calling the services
            IServiceProvider serviceProvider = services.BuildServiceProvider();

            // using the service
            using (var context = serviceProvider.GetService<AppDBContext>())
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