using Domain.entities;
using Domain.Interfaces;

namespace OnlineStorAccess.Services
{
    public  class OrderService 
    {
        readonly private IUnitOfWork _unitOfwork;
        public OrderService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public void Add(Order order)
        {

            if (order != null)
            {
                _unitOfwork.Orders.AddAsync(order);
                _unitOfwork.SaveAsync();

            }
        }

        public void Delete(int ID)
        {
            var Order = GetByID(ID);
            if (Order != null)
            {
                _unitOfwork.Orders.DeleteAsync(ID);
                _unitOfwork.SaveAsync();
            }
        }

        public Order? GetByID(int id)
        {
            var order = _unitOfwork.Orders.GetByIDAsync(id);
            if (order != null)
            {
                return order.Result;
            }
            return null;
        }

        public IEnumerable<Order> Gettall()
        {
            var Orders = _unitOfwork.Orders.GetAllAsync().Result;

            return Orders;
        }

        public void Update(Order order)
        {
            if (GetByID(order.Id) != null)
            {
                _unitOfwork.Orders.UpdateAsync(order);
                _unitOfwork.SaveAsync();

            }
        }
    }
}
