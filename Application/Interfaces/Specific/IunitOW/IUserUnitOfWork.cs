using Application.Interface;
using Domain.Interfaces.Generic;


namespace Application.Interfaces.Specific.IunitOW
{
    public interface IUserUnitOfWork : IUnitOfWork
    {
        public IUserRepository UserRepository { get; }
        public IPersonRepository PersonRepository { get; }
       
    }
}
