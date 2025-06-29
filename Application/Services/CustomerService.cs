
using Application.Interface;
using Domain.entities;
using Domain.Interfaces.Generic;

namespace Application.Services
{

    public class CustomerService(IUnitOfWork unitOfwork)
        



    {
        private readonly IUnitOfWork _unitOfwork = unitOfwork;
     
        public async Task<int> AddAsync(Customer customer)
        { 
           
       
            if (customer != null)
            {
                await _unitOfwork.Customers.AddAsync(customer);
                return customer.Id;
            }


            return 0;
        }

        public async Task<bool> DeleteAsync(int ID)
        {

            if (ID > 0)
            {
                await _unitOfwork.Customers.DeleteAsync(ID);

                return true;
            }
            return false;

        }

        public async Task<Customer?> GetByIDAsync(int id)
        {
            var customer = await _unitOfwork.Customers.GetByIDAsync(id);
            if (customer != null)
            {
                return customer;
            }
            return null;
            //
        }

        public async Task<IEnumerable<Customer>> GetAllAsync()
        {
            var Customers = await _unitOfwork.Customers.GetAllAsync();

            return Customers;
            // 
        }

        public async Task UpdateAsync(Customer customer)
        {
            await _unitOfwork.Customers.UpdateAsync(customer);

        }

    }
}
    