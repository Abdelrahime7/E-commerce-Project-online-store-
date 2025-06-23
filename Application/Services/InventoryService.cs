using Domain.entities;
using Domain.Interfaces;

namespace OnlineStorAccess.Services
{
    public class InventoryService 
    {
         private readonly IUnitOfWork _unitOfwork;

        public InventoryService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        public void Add(Inventory inventory)
        {
            if (inventory != null)
            {
                _unitOfwork.Inventorys.AddAsync(inventory);
                _unitOfwork.SaveAsync();
            }
        }

        public void Delete(int ID)
        {
           if (ID>0)
            {
                _unitOfwork.Inventorys.DeleteAsync(ID);
                _unitOfwork.SaveAsync();

            }
        }

        public Inventory ? GetByID(int id)
        {
            var inventory = _unitOfwork.Inventorys.GetByIDAsync(id).Result;
            if (inventory != null)
                return inventory;
            else return null;


        }

        public IEnumerable<Inventory> Gettall()
        {
            var inventorys = _unitOfwork.Inventorys.GetAllAsync().Result;

            return inventorys;
        }

        public void Update(Inventory Inventory)
        {
            if (GetByID(Inventory.Id)!= null)
            {
                _unitOfwork.Inventorys.UpdateAsync(Inventory);
                _unitOfwork.SaveAsync();
            }
        }
    }
}
