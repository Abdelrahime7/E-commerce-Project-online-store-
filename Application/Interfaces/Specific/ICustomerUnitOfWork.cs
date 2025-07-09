using Application.Interface;
using Domain.Interfaces.Generic;


namespace Application.Interfaces.Specific
{
    public interface ICustomerUnitOfWork :IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; }
        public IPersonRepository PersonRepository { get; }



    }
}
