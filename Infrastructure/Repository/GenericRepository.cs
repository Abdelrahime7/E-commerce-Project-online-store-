using Microsoft.EntityFrameworkCore;


namespace OnlineStorAccess.DataAccessCls
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
            await _dbSet.AddAsync(entity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _dbSet.FindAsync(id);
            if (entity != null)
            {
                _dbSet.Remove(entity);
                await _dbContext.SaveChangesAsync();
            }
            
        }
        public async Task<T> GetByIDAsync(int id) => await _dbSet.FindAsync(id);
       

        public  async Task UpdateAsync(T entity)
        {
             _dbSet.Update(entity);
            await _dbContext.SaveChangesAsync();
        }
    }
}
