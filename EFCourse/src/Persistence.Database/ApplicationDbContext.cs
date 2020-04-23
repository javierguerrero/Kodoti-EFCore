using Common;
using Microsoft.EntityFrameworkCore;
using Models;
using Persistence.Database.Config;

namespace Persistence.Database
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Client> Clients { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<OrderNumber> OrderNumbers { get; set; }
        public DbSet<Sale> Sales { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<Warehouse> Warehouses { get; set; }
        public DbSet<WarehouseProduct> WarehouseProduct { get; set; }
        public DbSet<ProductExtraInformation> ProductsExtraInformation { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(Parameter.ConnectionString);
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Models configuration or contraints
            new ClientConfig(builder.Entity<Client>());
            new ProductConfig(builder.Entity<Product>());
            new OrderConfig(builder.Entity<Order>());
            new OrderDetailConfig(builder.Entity<OrderDetail>());
            new OrderNumberConfig(builder.Entity<OrderNumber>());
            new SaleConfig(builder.Entity<Sale>());
            new CountryConfig(builder.Entity<Country>());
            new WarehouseConfig(builder.Entity<Warehouse>());
            new ProductExtraInformationConfig(builder.Entity<ProductExtraInformation>());

            // Query filters
            builder.Entity<Warehouse>().HasQueryFilter(x => !x.IsDeleted);
        }
    }
}