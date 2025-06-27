

using Domain.entities;
using Domain.Interfaces.Generic;

namespace Application.Interface
{
    public interface IPersonRepository <T> : IGenericRepository<Person>
    {


    }
}
