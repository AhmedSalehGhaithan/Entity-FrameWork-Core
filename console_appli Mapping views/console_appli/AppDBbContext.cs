using console_appli;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
namespace EF_CORE
{
    public class AppDBbContext : DbContext
    {
        // Represent the collection of all tables
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; } 
        public DbSet<OrderWithDetailsView> orderWithDetails {  get; set; }
        public DbSet<OrderBill> OrderGivenBill { get; set; } 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Product>().ToTable("Products", schema: "Inventory").HasKey(x => x.Id);

            modelBuilder.Entity<Order>().ToTable("Orders", schema: "Sales").HasKey(x => x.Id);

            modelBuilder.Entity<OrderDetail>().ToTable("OrderDetails", schema: "Sales").HasKey(x => x.Id);

            modelBuilder.Entity<OrderWithDetailsView>().ToView("OrderWithDetailsView").HasNoKey();

            modelBuilder.Entity<OrderBill>().ToFunction("GetOrderBill").HasNoKey();

            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var configuration = new ConfigurationBuilder().AddJsonFile("appSettings.json").Build();
                
            var Connection_String = configuration.GetSection("constr").Value;

            optionsBuilder.UseSqlServer(Connection_String);
        }


    }
}
