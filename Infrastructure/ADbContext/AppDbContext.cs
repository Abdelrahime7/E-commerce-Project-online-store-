using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;


namespace Infrastructure.ADbContext
{ 

    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Person> People { get; set; }
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ItemGallery> ItemGalleries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Sale> Salles { get; set; }
        public DbSet<PurchaseHistory> PurchasesHistory { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configu = new ConfigurationBuilder().AddJsonFile("jsconfig1.json").Build();
            var constr = configu.GetSection("Constr").Value;
            optionsBuilder.UseSqlServer(constr);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
      
    }
}
