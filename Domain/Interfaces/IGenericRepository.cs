﻿
namespace OnlineStorAccess.DataAccessCls
{
    public interface IGenericRepository <T> where T : class
    {
       Task< IEnumerable<T>> GetAllAsync();
       Task <T>GetByIDAsync(int id);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);

    }
}
