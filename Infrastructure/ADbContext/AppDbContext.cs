using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace OnlineStorAccess.ADbContext
{ 

    internal class AppDbContext :DbContext
    {
        public DbSet<entities.Customer> Customers { get; set; } 
        public DbSet<entities.Inventory> Inventorys { get; set; }
        public DbSet<entities.Item> Items { get; set; }
        public DbSet<entities.Invoice> Invoices { get; set; }
        public DbSet<entities.ItemGallery> ItemGallerys { get; set; }
        public DbSet<entities.Order> Orders { get; set; }
        public DbSet<entities.Review> Reviews { get; set; }
        public DbSet<entities.User> Users { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);

            var Configuration = new ConfigurationBuilder()
               .AddJsonFile("jsconfig1.json").Build();
            var Constr = Configuration.GetSection("Constr").Value;

            
           
            

        }

    }
}
