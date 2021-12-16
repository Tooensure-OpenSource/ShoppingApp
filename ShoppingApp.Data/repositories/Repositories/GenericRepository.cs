using Microsoft.EntityFrameworkCore;
using shoppingApp.Data.repositories.IRepostories;

namespace shoppingApp.Data.repositories.Repositories
{
    public abstract class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly DbContext _context;
        protected DbSet<T> _dbSet;
        public GenericRepository(DbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }
        public virtual async Task<bool> Add(T entity)
        {
            await _dbSet.AddAsync(entity);
            return true;
        }

        public virtual void  Delete(T entity)
        {

        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await _dbSet.ToListAsync();
        }

        public virtual async Task<T?> Get(Guid Id)
        {
            return await _dbSet.FirstOrDefaultAsync();
        }
    }
}