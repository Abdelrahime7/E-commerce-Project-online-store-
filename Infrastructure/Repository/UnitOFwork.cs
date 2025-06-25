using Domain.entities;
using Domain.Interfaces;
using Infrastructure.ADbContext;

namespace Infrastructure.Repository
{
    public class UnitOFwork : IUnitOfWork
    {

        private readonly AppDbContext _appDbContext;

        public UnitOFwork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Users = new GenericRepository<User>(_appDbContext);
            Customers = new GenericRepository<Customer>(_appDbContext);
            Orders = new GenericRepository<Order>(_appDbContext);
            Items = new GenericRepository<Item>(_appDbContext);
            Invoices = new GenericRepository<Invoice>(_appDbContext);
            ItemGallerys = new GenericRepository<ItemGallery>(_appDbContext);
            Inventorys = new GenericRepository<Inventory>(_appDbContext);
            Reviews = new GenericRepository<Review>(_appDbContext);
            Salles = new GenericRepository<Sale>(_appDbContext);
            People = new GenericRepository<Person>(_appDbContext);
            PurchasesHistory= new GenericRepository<PurchaseHistory>(_appDbContext);

        }


        public IGenericRepository<User> Users {  get; private set; }

        public IGenericRepository<Customer> Customers { get; private set; }

        public IGenericRepository<Order> Orders { get; private set; }

        public IGenericRepository<Item> Items { get; private set; }
        public IGenericRepository<Invoice> Invoices { get; private set; }

        public IGenericRepository<ItemGallery> ItemGallerys { get; private set; }

        public IGenericRepository<Inventory> Inventorys { get; private set; }

        public IGenericRepository<Review> Reviews { get; private set; }

        public IGenericRepository<Sale> Salles { get; private set; }

        public IGenericRepository<Person> People {get; private set;}

        public IGenericRepository<PurchaseHistory> PurchasesHistory { get; private set; }
        public async Task SaveAsync() => await _appDbContext.SaveChangesAsync();

        public void Dispose()=>_appDbContext.Dispose();

        
    }
}
