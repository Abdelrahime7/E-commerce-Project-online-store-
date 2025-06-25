using Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {

       private readonly  DbContext  _dbContext ;
       private readonly DbSet<T> _dbSet;

        public GenericRepository(DbContext context)
        {
            _dbContext = context;
            _dbSet = _dbContext.Set<T>();

        }

        public async Task<IEnumerable<T>> GetAllAsync() => await _dbSet.ToListAsync();


        public async Task AddAsync(T entity)
        {
            try
            {
                await _dbSet.AddAsync(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex) 
            {
                throw new Exception(ex.Message);

            }

        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var entity = await _dbSet.FindAsync(id);
                if (entity != null)
                {
                    _dbSet.Remove(entity);
                    await _dbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex) {
                throw new Exception(ex.Message);
            }
        }
        public async Task<T> GetByIDAsync(int id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch ( Exception ex) { throw new Exception(ex.Message); }
        }

        public  async Task UpdateAsync( T entity)
        {
            try
            {

                _dbSet.Update(entity);
                await _dbContext.SaveChangesAsync();
            }
            catch (Exception ex){ throw new Exception(ex.Message); }
        }
    }
}
