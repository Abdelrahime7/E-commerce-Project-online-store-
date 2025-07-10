using Application.Interface;
using Domain.Interfaces.Generic;


namespace Application.Interfaces.Specific.IunitOW
{
    public interface ICustomerUnitOfWork :IUnitOfWork
    {
        public ICustomerRepository CustomerRepository { get; }
        public IPersonRepository PersonRepository { get; }



    }
}
