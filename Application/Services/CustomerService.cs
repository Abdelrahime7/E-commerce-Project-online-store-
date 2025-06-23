
using Domain.entities;
using Domain.Interfaces;

namespace OnlineStorAccess.Services
{
    
     public  class CustomerService


    {
        private readonly IUnitOfWork _unitOfwork;

        public  CustomerService(IUnitOfWork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public void Add(Customer customer)
        {
            
            if (customer != null) { 
                _unitOfwork.Customers.AddAsync(customer);
                _unitOfwork.SaveAsync();

            }
        }

        public void Delete(int ID)
        {
            var Customer = GetByID(ID);
            if (Customer != null)
            {
                _unitOfwork.Customers.DeleteAsync(ID);
                _unitOfwork.SaveAsync();
            }

        }

        public Customer? GetByID(int id)
        {
         var customer=   _unitOfwork.Customers.GetByIDAsync(id);
            if (customer != null)
            {
                return  customer.Result;
            }
            return null;
           //
        }

        public IEnumerable<Customer> Gettall()
        {
            var Customers= _unitOfwork.Customers.GetAllAsync().Result;

            return Customers;
           // 
        }

        public void Update(Customer customer)
        {
          

            if (GetByID(customer.Id)!=null)
            {
                _unitOfwork.Customers.UpdateAsync(customer);
                _unitOfwork.SaveAsync();

            }
        }
       



    }
}
    