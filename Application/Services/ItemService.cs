using OnlineStorAccess.DataAccessCls;
using OnlineStorAccess.entities;

namespace OnlineStorAccess.Services
{
    public  class ItemService
    {
        readonly private IUnitOfwork _unitOfwork;
        public ItemService(IUnitOfwork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public void Add(Item item)
        {
            if (item != null)
            {
                _unitOfwork.Items.AddAsync(item);
                _unitOfwork.SaveAsync();

            }
        }

        public void Delete(int ID)
        {
            var item = GetByID(ID);
            if (item != null)
            {
                _unitOfwork.Items.DeleteAsync(ID);
                _unitOfwork.SaveAsync();
            }
        }

        public Item ? GetByID(int id)
        {
            var Item= _unitOfwork.Items.GetByIDAsync(id);
            if (Item != null)
            {
                return Item.Result;
            }
            return null;
        }

        public IEnumerable<Item> Gettall()
        {
            var Items = _unitOfwork.Items.GetAllAsync().Result;

            return Items;
        }

        public void Update(Item item)
            
        {

            if (GetByID(item.Id) != null)
            {
                _unitOfwork.Items.UpdateAsync(item);
                _unitOfwork.SaveAsync();

            }
        }
    }
}
