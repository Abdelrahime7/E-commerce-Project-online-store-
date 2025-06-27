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


        public IUserRepository<User> Users {  get; private set; }

        public ICustomerRepository<Customer> Customers { get; private set; }

        public IOrderRepository<Order> Orders { get; private set; }

        public IItemRepository<Item> Items { get; private set; }
        public IInvoiceRepository<Invoice> Invoices { get; private set; }

        public IItemGalleryRepository<ItemGallery> ItemGallerys { get; private set; }

        public IInventoryRepository<Inventory> Inventorys { get; private set; }

        public IReviewRepository<Review> Reviews { get; private set; }

        public ISaleRepository<Sale> Salles { get; private set; }

        public IPersonRepository<Person> People {get; private set;}

        public IPurchaseHistoryRepository<PurchaseHistory> PurchasesHistory { get; private set; }
        public async Task SaveAsync() => await _appDbContext.SaveChangesAsync();

        public void Dispose()=>_appDbContext.Dispose();

        
    }
}
