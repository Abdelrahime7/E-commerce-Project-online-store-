

using Application.Interface;

namespace Domain.Interfaces.Generic
    
{
     public interface IUnitOfWork:IDisposable
    {
       
        Task SaveAsync();
    }
}
