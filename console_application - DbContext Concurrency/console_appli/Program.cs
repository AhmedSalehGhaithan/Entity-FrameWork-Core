using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace EF_CORE_Dependency_Injection
{
    class Program
    {
        static AppDBContext context;
        public static void Main(string[] args)
        {

            var configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();

            var Connection_String = configuration.GetSection("constr").Value;

            var services = new ServiceCollection();

            // adding the services
            services.AddDbContext<AppDBContext>( options=> options.UseSqlServer(Connection_String));

            // calling the services
            IServiceProvider serviceProvider = services.BuildServiceProvider();

             context = serviceProvider.GetRequiredService<AppDBContext>();

            // doing both jobs in the same time
            var tasks = new[]
            {
                Task.Factory.StartNew(()=>Job1()),
                Task.Factory.StartNew(()=>Job2())
            };

            Task.WhenAll(tasks).ContinueWith(t =>
            {
                Console.WriteLine("Job1 & Job2 executed concurrently");
            });

                Console.ReadKey();
        }

        static async Task Job1()
        {
            var w1 = new Wallets { Id = 10, Holder = "Rathaan", Balance = 500m };
            context.Wallets.Add(w1);
           await context.SaveChangesAsync();
        }

        static async Task Job2()
        {
            var w2 = new Wallets { Id = 11, Holder = "Moath", Balance = 700m };
            context.Wallets.Add(w2);
             await context.SaveChangesAsync();
        }
    }
}