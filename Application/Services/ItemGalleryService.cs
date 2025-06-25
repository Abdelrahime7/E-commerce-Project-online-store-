using Domain.entities;
using Domain.Interfaces;

namespace OnlineStorAccess.Services
{
    public  class ItemGalleryService 
    {
        readonly private IUnitOfWork _unitOfwork;
        public ItemGalleryService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

      

        public async Task< int> AddAsync(ItemGallery gallery)
        {

            if (gallery != null)
            {
               await _unitOfwork.ItemGallerys.AddAsync(gallery);
                return gallery.Id;

            }
            return 0;
        }

        
        public async Task<bool> DeleteAsync(int ID)
        {
            
            if (ID>0)
            {
                await _unitOfwork.ItemGallerys.DeleteAsync(ID);
                return true;
            }
            return false;
        }
        
        public async Task  <ItemGallery ?> GetByIDAsync(int id)
        {

            var itemGalery =await _unitOfwork.ItemGallerys.GetByIDAsync(id);
            if (itemGalery != null)
            {
                return itemGalery;
            }
            return null;
        }

        public async Task <IEnumerable<ItemGallery>> GettallAsync()
        {
            var ItemsGallery = await _unitOfwork.ItemGallerys.GetAllAsync();

            return  ItemsGallery;
        }

        public async Task UpdateAsync(ItemGallery itemGallery)
        {
            if (await GetByIDAsync(itemGallery.Id) != null)
            {
                 await _unitOfwork.ItemGallerys.UpdateAsync(itemGallery);

            }
        }

      
      
    }
}
