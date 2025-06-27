using Domain.entities;
using Domain.Interfaces.Generic;
using System.Formats.Asn1;

namespace OnlineStorAccess.Services
{
    public class InventoryService 
    {
         private readonly IUnitOfWork _unitOfwork;

        public InventoryService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }
        public async Task< int> AddAsync(Inventory inventory)
        {
            if (inventory != null)
            {
              await  _unitOfwork.Inventorys.AddAsync(inventory);
               
                return inventory.Id;
            }
            return 0;
        }

        public async Task< bool> DeleteAsync(int ID)
        {
           if (ID>0)
            {
             await   _unitOfwork.Inventorys.DeleteAsync(ID);
               return true;
            }
           return false;
        }

        public async Task < Inventory ?> GetByIDAsync(int id)
        {
            var inventory = await _unitOfwork.Inventorys.GetByIDAsync(id);
            if (inventory != null)
                return inventory;
            else return null;


        }

        public async Task< IEnumerable<Inventory>> GettallAsync()
        {
            var inventorys = await _unitOfwork.Inventorys.GetAllAsync();

            return inventorys;
        }

        public async Task UpdateAsync( Inventory Inventory)
        {
         
               await _unitOfwork.Inventorys.UpdateAsync(Inventory);
               
            
        }
    }
}
