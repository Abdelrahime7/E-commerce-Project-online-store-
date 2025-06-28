using Domain.entities;
using Infrastructure.ADbContext;
using Application.Interface;
using Domain.Interfaces.Generic;

namespace Infrastructure.Repository.GenericRepo
{
    public class UnitOFwork : IUnitOfWork
    {

        private readonly AppDbContext _appDbContext;

        public UnitOFwork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Users = (IUserRepository) new GenericRepository<User>(_appDbContext);
            Customers = (ICustomerRepository)new GenericRepository<Customer>(_appDbContext);
            Orders =(IOrderRepository) new GenericRepository<Order>(_appDbContext);
            Items = (IItemRepository)new GenericRepository<Item>(_appDbContext);
            Invoices = (IInvoiceRepository)new GenericRepository<Invoice>(_appDbContext);
            ItemGallerys =(IItemGalleryRepository) new GenericRepository<ItemGallery>(_appDbContext);
            Inventorys =(IInventoryRepository) new GenericRepository<Inventory>(_appDbContext);
            Reviews =(IReviewRepository) new GenericRepository<Review>(_appDbContext);
            Salles =(ISaleRepository) new GenericRepository<Sale>(_appDbContext);
            People =(IPersonRepository) new GenericRepository<Person>(_appDbContext);
            PurchasesHistory= (IPurchaseRepository)new GenericRepository<PurchaseHistory>(_appDbContext);

        }


        public IUserRepository Users {  get; private set; }

        public ICustomerRepository Customers { get; private set; }

        public IOrderRepository Orders { get; private set; }

        public IItemRepository Items { get; private set; }
        public IInvoiceRepository Invoices { get; private set; }
        public IItemGalleryRepository ItemGallerys { get; private set; }

        public IInventoryRepository Inventorys { get; private set; }

        public IReviewRepository Reviews { get; private set; }

        public ISaleRepository Salles { get; private set; }

        public IPersonRepository People {get; private set;}

        public IPurchaseRepository PurchasesHistory { get; private set; }

        IGenericRepository<User> IUnitOfWork.Users => Users;

        IGenericRepository<Customer> IUnitOfWork.Customers => Customers;

        IGenericRepository<Order> IUnitOfWork.Orders => Orders;

        IGenericRepository<Item> IUnitOfWork.Items => Items;

        IGenericRepository<Invoice> IUnitOfWork.Invoices => Invoices;

        IGenericRepository<ItemGallery> IUnitOfWork.ItemGallerys => ItemGallerys;

        IGenericRepository<Inventory> IUnitOfWork.Inventorys => Inventorys;

        IGenericRepository<Review> IUnitOfWork.Reviews => Reviews;

        IGenericRepository<Sale> IUnitOfWork.Salles => Salles;

        IGenericRepository<Person> IUnitOfWork.People => People;

        IGenericRepository<PurchaseHistory> IUnitOfWork.PurchasesHistory => PurchasesHistory;

        public async Task SaveAsync() => await _appDbContext.SaveChangesAsync();

        public void Dispose()=>_appDbContext.Dispose();

        
    }
}
