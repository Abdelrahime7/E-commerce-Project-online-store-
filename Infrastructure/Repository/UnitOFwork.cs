using Domain.entities;
using Infrastructure.ADbContext;
using Application.Interface;
using Domain.Interfaces.Generic;

namespace Infrastructure.Repository
{
    public class UnitOFwork : IUnitOfWork
    {

        private readonly AppDbContext _appDbContext;

        public UnitOFwork(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
            Users = (IUserRepository<User>) new GenericRepository<User>(_appDbContext);
            Customers = (ICustomerRepository<Customer>)new GenericRepository<Customer>(_appDbContext);
            Orders =(IOrderRepository<Order>) new GenericRepository<Order>(_appDbContext);
            Items = (IItemRepository<Item>)new GenericRepository<Item>(_appDbContext);
            Invoices = (IInvoiceRepository<Invoice>)new GenericRepository<Invoice>(_appDbContext);
            ItemGallerys =(IItemGalleryRepository<ItemGallery>) new GenericRepository<ItemGallery>(_appDbContext);
            Inventorys =(IInventoryRepository<Inventory>) new GenericRepository<Inventory>(_appDbContext);
            Reviews =(IReviewRepository<Review>) new GenericRepository<Review>(_appDbContext);
            Salles =(ISaleRepository<Sale>) new GenericRepository<Sale>(_appDbContext);
            People =(IPersonRepository<Person>) new GenericRepository<Person>(_appDbContext);
            PurchasesHistory= (IPurchaseHistoryRepository<PurchaseHistory>)new GenericRepository<PurchaseHistory>(_appDbContext);

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
