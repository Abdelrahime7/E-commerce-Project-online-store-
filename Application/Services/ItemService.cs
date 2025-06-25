using Domain.entities;
using Domain.Interfaces;

namespace OnlineStorAccess.Services
{
    public  class ItemService
    {
        readonly private IUnitOfWork _unitOfwork;
        public ItemService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task< int> AddAsync(Item item)
        {
            if (item != null)
            {
              await  _unitOfwork.Items.AddAsync(item);
               return item.Id;
            }
            return 0;
        }

        public async Task<  bool> DeleteAsync(int ID)
        {
            
            if (ID>0)
            {
               await _unitOfwork.Items.DeleteAsync(ID);
                return true;

            }
            return false;
        }

        public async Task< Item ? > GetByIDAsync(int id)
        {
            var Item=  await _unitOfwork.Items.GetByIDAsync(id);
            if (Item != null)
            {
                return Item;
            }
            return null;
        }

        public async Task< IEnumerable<Item>> GettallAsync()
        {
            var Items = await _unitOfwork.Items.GetAllAsync();

            return Items;
        }

        public async Task UpdateAsync(Item item)
            
        {

            if (await GetByIDAsync(item.Id) != null)
            {
                await _unitOfwork.Items.UpdateAsync(item);

            }
        }
    }
}
