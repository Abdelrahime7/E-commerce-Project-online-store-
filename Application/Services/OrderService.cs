using Domain.entities;
using Domain.Interfaces.Generic;
using System.Threading.Tasks;

namespace OnlineStorAccess.Services
{
    public  class OrderService 
    {
        readonly private IUnitOfWork _unitOfwork;
        public OrderService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public async Task< int> AddAsync(Order order)
        {

            if (order != null)
            {
              await  _unitOfwork.Orders.AddAsync(order);
                return order.Id;

            }
            return 0;   
        }

        public async Task< bool> DeleteAsync(int ID)
        {
           
            if (ID>0)
            {
              await  _unitOfwork.Orders.DeleteAsync(ID);
              return true;
            }
             return false;
        }

        public async  Task< Order?> GetByIDAsync(int id)
        {
            var order =await _unitOfwork.Orders.GetByIDAsync(id);
            if (order != null)
            {
                return order;
            }
            return null;
        }

        public async Task< IEnumerable<Order>> GettallAsync()
        {
            var Orders = await _unitOfwork.Orders.GetAllAsync();

            return Orders;
        }

        public async Task UpdateAsync(Order order)
        {
            if (await GetByIDAsync(order.Id) != null)
            {
            await _unitOfwork.Orders.UpdateAsync(order);
                

            }
        }
    }
}
