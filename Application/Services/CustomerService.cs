using Microsoft.EntityFrameworkCore.Migrations.Operations;
using OnlineStorAccess.ADbContext;
using OnlineStorAccess.DataAccessCls;
using OnlineStorAccess.entities;

namespace OnlineStorAccess.Services
{
    
     public  class CustomerService
    {
         private readonly  IUnitOfwork _unitOfwork;

        public  CustomerService(IUnitOfwork unitOfwork)
        {
            _unitOfwork = unitOfwork;
        }

        public void add()
        {
            var customer = new Customer();
            _unitOfwork.Customers.AddAsync(customer);
        }
     


    }
}
    