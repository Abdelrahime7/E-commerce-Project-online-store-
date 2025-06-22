using OnlineStorAccess.DataAccessCls;
using OnlineStorAccess.entities;

namespace OnlineStorAccess.Services
{
    public  class ItemGalleryService 
    {
        readonly private IUnitOfwork _unitOfwork;
        public ItemGalleryService(IUnitOfwork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

      

        public void Add(ItemGallery gallery)
        {

            if (gallery != null)
            {
                _unitOfwork.ItemGallerys.AddAsync(gallery);
                _unitOfwork.SaveAsync();

            }
        }


        public void Delete(int ID)
        {
            var itemGallery = GetByID(ID);
            if (itemGallery != null)
            {
                _unitOfwork.ItemGallerys.DeleteAsync(ID);
                _unitOfwork.SaveAsync();
            }
        }

        public ItemGallery ? GetByID(int id)
        {

            var itemGalery = _unitOfwork.ItemGallerys.GetByIDAsync(id);
            if (itemGalery != null)
            {
                return itemGalery.Result;
            }
            return null;
        }

        public IEnumerable<ItemGallery> Gettall()
        {
            var ItemsGallery = _unitOfwork.ItemGallerys.GetAllAsync().Result;

            return  ItemsGallery;
        }

        public void Update(ItemGallery itemGallery)
        {
            if (GetByID(itemGallery.ID) != null)
            {
                _unitOfwork.ItemGallerys.UpdateAsync(itemGallery);
                _unitOfwork.SaveAsync();

            }
        }

      
      
    }
}
