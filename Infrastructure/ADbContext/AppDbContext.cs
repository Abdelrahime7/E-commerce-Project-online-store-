using Domain.entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Infrastructure.ADbContext
{ 

    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; } 
        public DbSet<Inventory> Inventories { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<ItemGallery> ItemGalleries { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        }
    }
}
