using Domain.entities;
using OnlineStorAccess.entities;

namespace OnlineStorAccess.DataAccessCls
{
     public interface IUnitOfwork:IDisposable

    {

        IGenericRepository<User> Users { get; }
        IGenericRepository<Customer> Customers { get; }
        IGenericRepository<Order> Orders { get; }
        IGenericRepository<Item> Items { get; }
        IGenericRepository<Invoice> Invoices { get; }
        IGenericRepository<ItemGallery> ItemGallerys { get; }
        IGenericRepository<Inventory> Inventorys { get; }
        IGenericRepository<Review> Reviews { get; }
        IGenericRepository<Salle> Salles { get; }
        IGenericRepository<Person> People { get; }
        IGenericRepository<PurchaseHistory> PurchasesHistory { get; }




        Task SaveAsync();

    

    }
}
